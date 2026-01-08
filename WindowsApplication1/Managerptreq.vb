Imports MySql.Data.MySqlClient

Public Class Managerptreq
    Private SQL As New sqlcontrol
    Private authuser As String


    Dim mRow As Integer = 0
    Dim newpage As Boolean = True
    Private Sub Managerptreq_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadcmb()
        loadcmb2()
        loadrptdata()
        LoadAdmingrid()
        loadevalpending()

    End Sub


    Public Sub loadcmb()
        Sql.AddParam("@admin", "RPT_ADMIN")
        Sql.AddParam("@eval", "RPT_ASSESSOR")
        Sql.ExecQuery("Select system_userid, Full_name From business_users where user_position = @admin or user_position = @eval ")
        Sql.bsource.DataSource = Sql.DBDT

        cmbeval.DataSource = Sql.bsource



        With cmbeval
            .DisplayMember = ("Full_name")
            .ValueMember = ("system_userid")
        End With
       
    End Sub


    Public Sub loadcmb2()
        SQL.AddParam("@admin", "RPT_ADMIN")
        SQL.AddParam("@eval", "RPT_ASSESSOR")
        SQL.ExecQuery("Select system_userid, Full_name From business_users where user_position = @admin or user_position = @eval ")
        SQL.bsource.DataSource = SQL.DBDT

        cmbmove.DataSource = SQL.bsource



        With cmbmove
            .DisplayMember = ("Full_name")
            .ValueMember = ("system_userid")
        End With

    End Sub


    Public Sub loadrptdata()
        rptgrid.Rows.Clear()


        SQL.AddParam("@user", cmbeval.SelectedValue)
        SQL.AddParam("@stat", "P")
        SQL.ExecQuery("select * from rpt_application a inner join rpt_record_hdr b on a.TDN_no = b.TDN_no where assess_status = 'P' and user_assess = @user order by Application_timedt limit 20")
        For Each r As DataRow In SQL.DBDT.Rows
            rptgrid.Rows.Add(r("rptrecord_id"), r("rpt_applicationid"), r("TDN_no"), r("owner_name"), r("Location"))
        Next
    End Sub

    Public Sub LoadAdmingrid()


        Dim cmbeval As New DataGridViewComboBoxColumn()
        rptgrid.Columns.Add(cmbeval)

        With cmbeval
            .HeaderText = "ASSESSOR"
            .Width = 180
            .Name = "cmbeval"
            .MaxDropDownItems = 5


            SQL.AddParam("@admin", "RPT_ADMIN")
            SQL.AddParam("@eval", "RPT_ASSESSOR")
            SQL.ExecQuery("Select system_userid, Full_name From business_users where user_position = @admin or user_position = @eval ")
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
            .Width = 80
            .Name = "btneval"
            .Text = "Forward"

            .UseColumnTextForButtonValue = True
            .FlatStyle = FlatStyle.Flat
            '  .HeaderCell.ReadOnly = True

        End With





    End Sub

    Private Sub dt_Appoinment_ValueChanged(sender As Object, e As EventArgs) Handles dt_Appoinment.ValueChanged

    End Sub

    Private Sub cmbeval_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbeval.SelectedIndexChanged
        loadrptdata()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbmove.SelectedIndexChanged

    End Sub

    Public Sub loadevalpending()

        SQL.AddParam("@admin", "RPT_ADMIN")
        SQL.AddParam("@eval", "RPT_ASSESSOR")
        SQL.ExecQuery("Select system_userid,Full_name from business_users where user_position = @admin or user_position = @eval")

        For Each r As DataRow In SQL.DBDT.Rows
            Dim intid As Integer = r("system_userid")
            Dim strname As String = (r("Full_name").ToString)

            SQL.AddParam("@id", intid)
            SQL.ExecQuery("Select count(rpt_applicationID) as Pending from rpt_application where user_assess = @id and assess_status = 'P' ")
            For Each r2 As DataRow In SQL.DBDT.Rows
                DataGridView2.Rows.Add(r("system_userid"), r("Full_name"), r2("Pending"))
            Next
        Next



        DataGridView2.Sort(DataGridView2.Columns(2), System.ComponentModel.ListSortDirection.Descending)
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint
        '  loadevalpending()
    End Sub

    Private Sub rptgrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles rptgrid.CellContentClick
        If e.RowIndex = -1 Then
            Exit Sub

        End If


        If e.RowIndex <> 0 Then
            MessageBox.Show("Please prioritize requests according to queue", "CANNOT FORWARD", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        Dim strevalfwd As String = rptgrid.CurrentRow.Cells(6).Value
        If e.ColumnIndex = 7 Then
            If strevalfwd = "" Then
                MessageBox.Show("Please Select Assessor ! ", "INCOMPLETE", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If



            'idisplay an text assess preee
            Dim strevaltext As String
            SQL.AddParam("@assessid", strevalfwd)
            SQL.ExecQuery("Select Full_name from business_users where system_userid = @assessid")
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
            SQL.ExecQuery("Update rpt_application set admin_status = @stat, time_passed = @timeforwarded, user_assess = @assess, assess_status = @assessstat where rpt_applicationID = @appid ")

            labelstat.Text = strevaltext
            MessageBox.Show("FORWARDED TO ASSESSOR : " + strevaltext, "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
        Dim f2 As New rptadmin
        f2.MdiParent = MainMenu
        f2.Show()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles ChkMove.CheckedChanged
        If ChkMove.Checked = True Then
            cmbmove.Enabled = True
            btnmove.Enabled = True
        ElseIf ChkMove.Checked = False Then
            cmbmove.Enabled = False
            btnmove.Enabled = False
        End If

    End Sub

    Private Sub btnmove_Click(sender As Object, e As EventArgs) Handles btnmove.Click
        Dim intconfirm As Integer = MessageBox.Show("Move all pending Request ?", "CONFIRMATION", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If intconfirm = DialogResult.OK Then
            SQL.AddParam("@from", cmbeval.SelectedValue)
            SQL.AddParam("@to", cmbmove.SelectedValue)
            SQL.ExecQuery("update rpt_application set user_assess = @to where user_assess = @from and assess_status = 'P' ")
            MessageBox.Show("Moved Successfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            loadrptdata()
            DataGridView2.Rows.Clear()
            loadevalpending()
        Else
            'do nothing
        End If
  
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub timerpending_Tick(sender As Object, e As EventArgs) Handles timerpending.Tick
        selectpending()
    End Sub
    Public Sub selectpending()

        'pending
        SQL.AddParam("@stat", "P")
        '   SQL.AddParam("@userid", intuser)
        SQL.ExecQuery("select count(rpt_applicationid) as pcount from rpt_application where assess_status = @stat or admin_status = 'P' ")
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
End Class