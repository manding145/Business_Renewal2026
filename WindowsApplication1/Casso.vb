Imports MySql.Data.MySqlClient
Public Class Casso
    Private SQL As New sqlcontrol2
    Private authuser As String

    Private intuser As Integer = LogIn.lblid.Text
    Dim mRow As Integer = 0
    Dim newpage As Boolean = True
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        MainMenu.btncasso.Enabled = True
    End Sub

    Private Sub Casso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadrptdata()
        LoadAdmingrid()
        dt_Appoinment.Value = Date.Now()
        selectpending()
        selectall()
        selectforwarded()
    End Sub

    Public Sub LoadAdmingrid()


        'Dim cmbeval As New DataGridViewComboBoxColumn()
        'rptgrid.Columns.Add(cmbeval)

        'With cmbeval
        '    .HeaderText = "ASSESSOR"
        '    .Width = 150
        '    .Name = "cmbeval"
        '    .MaxDropDownItems = 5


        '    SQL.AddParam("@admin", "RPT_ADMIN")
        '    SQL.AddParam("@eval", "RPT_ASSESSOR")
        '    SQL.ExecQuery("Select system_userid, Full_name From business_users where user_position = @admin or user_position = @eval ")
        '    SQL.bsource.DataSource = SQL.DBDT

        '    cmbeval.DataSource = SQL.bsource


        '    .DisplayMember = ("Full_name")
        '    .ValueMember = ("system_userid")


        '    '.Items.Add("EMMA ORTEGA")
        '    '.Items.Add("LYNDYDELAPENA")
        '    '.Items.Add("EDNA DELACRUZ")
        '    .DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox


        'End With

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

        'Dim btnAssess As New DataGridViewButtonColumn()
        'rptgrid.Columns.Add(btnAssess)
        'With btnAssess
        '    .HeaderText = "ASSESS"
        '    .Width = 70
        '    .Name = "btnAssess"
        '    .Text = "Assess"
        '    .UseColumnTextForButtonValue = True
        '    .FlatStyle = FlatStyle.Flat
        'End With


    End Sub


    Public Sub LoadAdmingridDone()


        'Dim cmbeval As New DataGridViewComboBoxColumn()
        'rptgrid.Columns.Add(cmbeval)

        'With cmbeval
        '    .HeaderText = "ASSESSOR"
        '    .Width = 150
        '    .Name = "cmbeval"
        '    .MaxDropDownItems = 5


        '    SQL.AddParam("@admin", "RPT_ADMIN")
        '    SQL.AddParam("@eval", "RPT_ASSESSOR")
        '    SQL.ExecQuery("Select system_userid, Full_name From business_users where user_position = @admin or user_position = @eval ")
        '    SQL.bsource.DataSource = SQL.DBDT

        '    cmbeval.DataSource = SQL.bsource


        '    .DisplayMember = ("Full_name")
        '    .ValueMember = ("system_userid")


        '    '.Items.Add("EMMA ORTEGA")
        '    '.Items.Add("LYNDYDELAPENA")
        '    '.Items.Add("EDNA DELACRUZ")
        '    .DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox


        'End With

        Dim btneval As New DataGridViewButtonColumn()

        rptgrid.Columns.Add(btneval)
        With btneval
            .HeaderText = "ACTION"
            .Width = 70
            .Name = "btneval"
            .Text = "DONE"

            .UseColumnTextForButtonValue = True
            .FlatStyle = FlatStyle.Flat
            '  .HeaderCell.ReadOnly = True

        End With





    End Sub


    Public Sub loadrptdata()
        Sql.AddParam("@stat", "P")
        SQL.ExecQuery("select * from ONLINE.rpt_application a inner join ONLINE.rpt_record_hdr b on a.TDN_no = b.TDN_no where casso_status = 'P' order by Application_timedt")
        For Each r As DataRow In Sql.DBDT.Rows
            rptgrid.Rows.Add(r("rptrecord_id"), r("rpt_applicationid"), r("TDN_no"), r("ARP"), r("owner_name"), r("Owner_Address"), r("Location"))
        Next
    End Sub
    Public Sub loadrptdatadone()
        SQL.AddParam("@stat", "P")
        SQL.ExecQuery("select * from ONLINE.rpt_application a inner join rpt_record_hdr b on a.TDN_no = b.TDN_no where casso_status = 'V' order by Application_timedt limit 10")
        For Each r As DataRow In SQL.DBDT.Rows
            rptgrid.Rows.Add(r("rptrecord_id"), r("rpt_applicationid"), r("TDN_no"), r("ARP"), r("owner_name"), r("Owner_Address"), r("Location"))
        Next
    End Sub

    Public Sub selectpending()

        'pending
        SQL.AddParam("@stat", "P")
        '   SQL.AddParam("@userid", intuser)
        SQL.ExecQuery("select count(rpt_applicationid) as pcount from ONLINE.rpt_application where casso_status = @stat ")
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
    Public Sub selectforwarded()

        'pending
        SQL.AddParam("@stat", "V")
        '   SQL.AddParam("@userid", intuser)
        SQL.ExecQuery("select count(rpt_applicationid) as pcount from rpt_application where casso_status = @stat ")
        For Each r As DataRow In SQL.DBDT.Rows
            labelstat.Text = (r("pcount"))
        Next

        ''done
        'SQL.AddParam("@stat", "V")
        'SQL.AddParam("@userid", intuser)
        'SQL.ExecQuery("select count(rpt_applicationid) as pcount from rpt_application where assess_status = @stat  and user_assess = @userid")
        'For Each r As DataRow In SQL.DBDT.Rows
        '    lblcountissued.Text = (r("pcount"))
        'Next
    End Sub
    Public Sub selectall()

        'pending
        SQL.AddParam("@stat", "P")
        '   SQL.AddParam("@userid", intuser)
        SQL.ExecQuery("select count(rpt_applicationid) as pcount from rpt_application")
        For Each r As DataRow In SQL.DBDT.Rows
            Lbltotals.Text = (r("pcount"))
        Next

        ''done
        'SQL.AddParam("@stat", "V")
        'SQL.AddParam("@userid", intuser)
        'SQL.ExecQuery("select count(rpt_applicationid) as pcount from rpt_application where assess_status = @stat  and user_assess = @userid")
        'For Each r As DataRow In SQL.DBDT.Rows
        '    lblcountissued.Text = (r("pcount"))
        'Next
    End Sub

    Private Sub rptgrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles rptgrid.CellContentClick
        If e.RowIndex = -1 Then
            Exit Sub

        End If

        'for queue
        'If e.RowIndex <> 0 Then
        '    MessageBox.Show("Please prioritize requests according to queue", "CANNOT FORWARD", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    Exit Sub
        'End If


        'for selection
        'Dim strevalfwd As String = rptgrid.CurrentRow.Cells(6).Value
        If e.ColumnIndex = 8 Then
            '    If strevalfwd = "" Then
            '        MessageBox.Show("Please Select Assessor ! ", "INCOMPLETE", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '        Exit Sub
            '    End If



            'idisplay an text assess preee
            'Dim strevaltext As String
            'SQL.AddParam("@assessid", strevalfwd)
            'SQL.ExecQuery("Select Full_name from business_users where system_userid = @assessid")
            'For Each r As DataRow In SQL.DBDT.Rows
            '    strevaltext = (r("Full_name"))
            'Next



            'update database
            ' Dim strEval As Integer = rptgrid.CurrentRow.Cells(6).Value
            Dim intappid As Integer = rptgrid.CurrentRow.Cells(1).Value
            '   Dim dt As System.DateTime

            SQL.AddParam("@appid", intappid)
            ' SQL.AddParam("@assess", strEval)
            SQL.AddParam("@stat", "P")
            SQL.AddParam("@assessstat", "V")
            SQL.AddParam("@timeforwarded", dt_Appoinment.Value)
            SQL.AddParam("@userf", intuser)
            SQL.ExecQuery("Update ONLINE.rpt_application set admin_status = @stat, casso_timepassed = @timeforwarded, casso_status = @assessstat ,casso_user = @userf where rpt_applicationID = @appid ")

            'labelstat.Text = strevaltext
            MessageBox.Show("FORWARDED TO RPT DIVISION ", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Exit Sub
        End If





        '  labelstat.Text = AdminGrid.Columns.Count.ToString
        'DataGridView1.ClearSelection()

        'DataGridView1.DataSource = Nothing
        rptgrid.Rows.Clear()
        ' DataGridView1.Columns.Clear()
        '      DataGridView1.Refresh()


        loadrptdata()
        selectforwarded()

        'If e.ColumnIndex = 9 Then

        '    '    lblappid.Text = EvalGrid.CurrentRow.Cells(1).Value
        '    Dim f As New rpt_assessment
        '        f.MdiParent = MainMenu
        '        f.Show()
        '        Me.Hide()

        'End If

    End Sub

    Private Sub timerpending_Tick(sender As Object, e As EventArgs) Handles timerpending.Tick
        selectpending()
        selectall()

    End Sub

    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click
        rptgrid.Rows.Clear()
        loadrptdata()
        selectpending()
        selectall()

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        rptgrid.Rows.Clear()
        If rptgrid.Columns.Contains("btneval") Then
            rptgrid.Columns.Remove("btneval")
        End If
        loadrptdatadone()
        PanelF.BackColor = Color.LightBlue
        PanelP.BackColor = Color.White
        cmb_appointmentstatus.Text = "FORWARDED"
     
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        rptgrid.Rows.Clear()
        If rptgrid.Columns.Contains("btneval") Then
            rptgrid.Columns.Remove("btneval")
        End If
        loadrptdata()
        LoadAdmingrid()
        PanelP.BackColor = Color.LightBlue
        PanelF.BackColor = Color.White
        cmb_appointmentstatus.Text = "PENDING"
    End Sub

    Private Sub BtnSearchRecord_Click(sender As Object, e As EventArgs) Handles BtnSearchRecord.Click
        rptgrid.Rows.Clear()
        loadrptdatasearch()
    End Sub

    Public Sub loadrptdatasearch()
        SQL.AddParam("@stat", "P")
        SQL.AddParam("@tdn", "%" + txt_name.Text + "%")
        SQL.ExecQuery("select * from ONLINE.rpt_application a inner join ONLINE.rpt_record_hdr b on a.TDN_no = b.TDN_no where casso_status = 'P' and a.TDN_no LIKE @tdn order by Application_timedt limit 10")
        For Each r As DataRow In SQL.DBDT.Rows
            rptgrid.Rows.Add(r("rptrecord_id"), r("rpt_applicationid"), r("TDN_no"), r("ARP"), r("owner_name"), r("Owner_Address"), r("Location"))
        Next
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class