Imports MySql.Data.MySqlClient


Public Class rptadmin
    Private SQL As New sqlcontrol2
    Private authuser As String


    Dim mRow As Integer = 0
    Dim newpage As Boolean = True
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        MainMenu.btnrptreq.Enabled = True
    End Sub

    Private Sub rptadmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadrptdata()
        LoadAdmingrid()
        loadevalpending()
        dt_Appoinment.Value = Date.Now()
    End Sub

    Public Sub loadrptdata()
        SQL.AddParam("@stat", "P")
        SQL.ExecQuery("select * from ONLINE.rpt_application a inner join ONLINE.rpt_record_hdr b on a.TDN_no = b.TDN_no where admin_status = 'P' order by Application_timedt limit 10")
        For Each r As DataRow In SQL.DBDT.Rows
            rptgrid.Rows.Add(r("rptrecord_id"), r("rpt_applicationid"), r("TDN_no"), r("owner_name"), r("Location"))
        Next
    End Sub

    Public Sub LoadAdmingrid()


        Dim cmbeval As New DataGridViewComboBoxColumn()
        rptgrid.Columns.Add(cmbeval)

        With cmbeval
            .HeaderText = "ASSESSOR"
            .Width = 150
            .Name = "cmbeval"
            .MaxDropDownItems = 5


            SQL.AddParam("@admin", "RPT_ADMIN")
            SQL.AddParam("@eval", "RPT_ASSESSOR")
            SQL.ExecQuery("Select system_userid, Full_name From ONLINE.business_users where user_position = @admin or user_position = @eval ")
            SQL.bsource.DataSource = SQL.DBDT

            cmbeval.DataSource = SQL.bsource


            .DisplayMember = ("Full_name")
            .ValueMember = ("system_userid")


            '.Items.Add("EMMA ORTEGA")
            '.Items.Add("LYNDYDELAPENA")
            '.Items.Add("EDNA DELACRUZ")
            .DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox


        End With

        Dim btneval As New DataGridViewButtonColumn()

        rptgrid.Columns.Add(btneval)
        With btneval
            .HeaderText = "ACTION"
            .Width = 70
            .Name = "btneval"
            .Text = "Forward"

            .UseColumnTextForButtonValue = True
            .FlatStyle = FlatStyle.Flat
            '  .HeaderCell.ReadOnly = True

        End With





    End Sub




    Private Sub rptgrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles rptgrid.CellContentClick
        If e.RowIndex = -1 Then
            Exit Sub

        End If


        'If e.RowIndex <> 0 Then
        '    MessageBox.Show("Please prioritize requests according to queue", "CANNOT FORWARD", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Exit Sub
        'End If

        Dim strevalfwd As String = rptgrid.CurrentRow.Cells(6).Value
        If e.ColumnIndex = 7 Then
            If strevalfwd = "" Then
                MessageBox.Show("Please Select Assessor ! ", "INCOMPLETE", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If



            'idisplay an text assess preee
            Dim strevaltext As String
            SQL.AddParam("@assessid", strevalfwd)
            SQL.ExecQuery("Select Full_name from ONLINE.business_users where system_userid = @assessid")
            For Each r As DataRow In SQL.DBDT.Rows
                strevaltext = (r("Full_name"))
            Next



            'update database
            Dim strEval As Integer = rptgrid.CurrentRow.Cells(6).Value
            Dim intappid As Integer = rptgrid.CurrentRow.Cells(1).Value
            '   Dim dt As System.DateTime

            SQL.AddParam("@appid", intappid)
            SQL.AddParam("@assess", strEval)
            SQL.AddParam("@stat", "V")
            SQL.AddParam("@assessstat", "P")
            SQL.AddParam("@timeforwarded", dt_Appoinment.Value)
            SQL.ExecQuery("Update ONLINE.rpt_application set admin_status = @stat, time_passed = @timeforwarded, user_assess = @assess, assess_status = @assessstat where rpt_applicationID = @appid ")

            labelstat.Text = strevaltext
            MessageBox.Show("FORWARDED TO : " + strevaltext, "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Exit Sub
        End If

        '  labelstat.Text = AdminGrid.Columns.Count.ToString
        'DataGridView1.ClearSelection()

        'DataGridView1.DataSource = Nothing
        rptgrid.Rows.Clear()
        ' DataGridView1.Columns.Clear()
        '      DataGridView1.Refresh()
        DataGridView2.Rows.Clear()

        loadrptdata()
        loadevalpending()

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
    Public Sub loadevalpending()

        SQL.AddParam("@admin", "RPT_ADMIN")
        SQL.AddParam("@eval", "RPT_ASSESSOR")
        SQL.ExecQuery("Select system_userid,Full_name from ONLINE.business_users where user_position = @admin or user_position = @eval")

        For Each r As DataRow In SQL.DBDT.Rows
            Dim intid As Integer = r("system_userid")
            Dim strname As String = (r("Full_name").ToString)

            SQL.AddParam("@id", intid)
            SQL.ExecQuery("Select count(rpt_applicationID) as Pending from ONLINE.rpt_application where user_assess = @id and assess_status = 'P' ")
            For Each r2 As DataRow In SQL.DBDT.Rows
                DataGridView2.Rows.Add(r("system_userid"), r("Full_name"), r2("Pending"))
            Next
        Next



        DataGridView2.Sort(DataGridView2.Columns(2), System.ComponentModel.ListSortDirection.Descending)
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub timerpending_Tick(sender As Object, e As EventArgs) Handles timerpending.Tick
        selectpending()
        dt_Appoinment.Value = DateTime.Now


    End Sub
    Public Sub selectpending()

        'pending
        SQL.AddParam("@stat", "P")
        '   SQL.AddParam("@userid", intuser)
        SQL.ExecQuery("select count(rpt_applicationid) as pcount from ONLINE.rpt_application where admin_status = @stat ")
        For Each r As DataRow In SQL.DBDT.Rows
            lbl_countpending.Text = (r("pcount"))
        Next

        ''done
        'SQL.AddParam("@stat", "V")
        'SQL.AddParam("@userid", intuser)
        'SQL.ExecQuery("select count(rpt_applicationid) as pcount from rpt_application where assess_status = @stat  and user_assess = @userid")
        'For Each r As DataRow In SQL.DBDT.Rows
        '    lblcountissued.Text = (r("pcount"))
        'Next
    End Sub

    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click
        rptgrid.Rows.Clear()

        loadrptdata()
    End Sub

    Private Sub BtnSearchRecord_Click(sender As Object, e As EventArgs) Handles BtnSearchRecord.Click
        Dim f As New Managerptreq
        f.MdiParent = MainMenu
        f.Show()
        Me.Hide()

        '  btnced.Enabled = False
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        rptgrid.Rows.Clear()

        loadrptdata()
    
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        rptgrid.Rows.Clear()

        loadrptdatasearch()
    End Sub


    Public Sub loadrptdatasearch()
        SQL.AddParam("@stat", "P")
        SQL.AddParam("@tdn", "%" + txt_name.Text + "%")
        SQL.ExecQuery("select * from ONLINE.rpt_application a inner join ONLINE.rpt_record_hdr b on a.TDN_no = b.TDN_no where admin_status = 'P'and a.TDN_no LIKE @tdn order by Application_timedt limit 10")
        For Each r As DataRow In SQL.DBDT.Rows
            rptgrid.Rows.Add(r("rptrecord_id"), r("rpt_applicationid"), r("TDN_no"), r("owner_name"), r("Location"))
        Next
    End Sub
End Class