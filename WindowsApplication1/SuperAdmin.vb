Imports MySql.Data.MySqlClient


Public Class SuperAdmin

    Private SQL As New sqlcontrol2
    Private authuser As String


    Dim mRow As Integer = 0
    Dim newpage As Boolean = True
    ' Dim connection As New MySqlConnection("datasource=10.0.14.117;username=usera2;password=passa2")



    Private Sub SuperAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()

        LoadAdmingrid()
        loadevalpending()

        selectpending()
        dt_Appoinment.Value = Date.Now()
    End Sub

  

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()

        MainMenu.btnadmin.Enabled = True
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub AdminGrid_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'If e.ColumnIndex = 6 Then
        '    MsgBox("sure ka?")
        'End If
    End Sub

    Private Sub AdminGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.RowIndex = -1 Then
            Exit Sub

        End If


        If e.RowIndex <> 0 Then
            MessageBox.Show("Please prioritize requests according to queue", "CANNOT FORWARD", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        Dim strevalfwd As String = DataGridView1.CurrentRow.Cells(6).Value
        If e.ColumnIndex = 7 Then
            If strevalfwd = "" Then
                MessageBox.Show("Please Select Evaluator ! ", "INCOMPLETE", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If




            'idisplay an text eval preee
            Dim strevaltext As String
            SQL.AddParam("@evalid", strevalfwd)
            SQL.ExecQuery("Select Full_name from ONLINE.business_users where system_userid = @evalid")
            For Each r As DataRow In SQL.DBDT.Rows
                strevaltext = (r("Full_name"))
            Next


            'update database
            Dim strEval As Integer = DataGridView1.CurrentRow.Cells(6).Value
            Dim intappid As Integer = DataGridView1.CurrentRow.Cells(1).Value
            '   Dim dt As System.DateTime

            SQL.AddParam("@appid", intappid)
            SQL.AddParam("@eval", strEval)
            SQL.AddParam("@stat", "V")
            SQL.AddParam("@evalstat", "V")
            SQL.AddParam("@statA", "P")



            SQL.AddParam("@timeforwarded", dt_Appoinment.Value)
            SQL.ExecQuery("Update ONLINE.business_applicationstatus_dtl set assess_status = @statA, user_assess = @eval , admin_status = @stat,adminpassed_timedt = @timeforwarded, user_eval = @eval, eval_status = @evalstat where ApplicationID = @appid  ")

            labelstat.Text = strevaltext
            MessageBox.Show("FORWARDED TO EVALUATOR : " + strevaltext, "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Exit Sub
        End If

        '  labelstat.Text = AdminGrid.Columns.Count.ToString
        'DataGridView1.ClearSelection()

        'DataGridView1.DataSource = Nothing
        DataGridView1.Rows.Clear()
        ' DataGridView1.Columns.Clear()
        '      DataGridView1.Refresh()
        DataGridView2.Rows.Clear()

        LoadData()
        loadevalpending()
        selectpending()


    End Sub
    Public Sub LoadData()
        SQL.AddParam("@stat", "P")
        SQL.AddParam("@vstat", "V")
        SQL.ExecQuery("Select a.recordid, a.applicationid , a.accountno, a.gross_dec, a.businessline, c.admin_status, c.verified_timedt, isReupload from ONLINE.business_application_tbl a " &
                      "inner join ONLINE.business_applicationstatus_dtl c on a.applicationID = c.applicationID where c.admin_status = @stat and c.verify_status = @vstat and Isreupload = 0 order by verified_timedt ")

        For Each r As DataRow In SQL.DBDT.Rows
            DataGridView1.Rows.Add(r("recordid"), r("applicationid"), r("accountno"), r("gross_dec"), r("businessline"), r("admin_status"))
        Next

    End Sub
    Public Sub LoadAdmingrid()


        Dim cmbeval As New DataGridViewComboBoxColumn()
        DataGridView1.Columns.Add(cmbeval)

        With cmbeval
            .HeaderText = "EVALUATOR"
            .Width = 150
            .Name = "cmbeval"
            .MaxDropDownItems = 5


            SQL.AddParam("@admin", "ADMIN")
            SQL.AddParam("@eval", "EVALUATOR")
            SQL.ExecQuery("Select system_userid, Full_name From ONLINE.business_users")
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

        DataGridView1.Columns.Add(btneval)
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

    Public Sub loadevalpending()

        SQL.AddParam("@admin", "ADMIN")
        SQL.AddParam("@eval", "EVALUATOR")
        SQL.ExecQuery("Select system_userid,Full_name from ONLINE.business_users where user_position = @admin or user_position = @eval")

        For Each r As DataRow In SQL.DBDT.Rows
            Dim intid As Integer = r("system_userid")
            Dim strname As String = r("Full_name")

            SQL.AddParam("@id", intid)
            SQL.ExecQuery("Select count(ApplicationID) as Pending from ONLINE.business_applicationstatus_dtl where user_eval = @id and eval_status = 'P' ")
            For Each r2 As DataRow In SQL.DBDT.Rows
                DataGridView2.Rows.Add(r("system_userid"), r("Full_name"), r2("Pending"))
            Next
        Next

    

        DataGridView2.Sort(DataGridView2.Columns(2), System.ComponentModel.ListSortDirection.Descending)
    End Sub


    Public Sub selectpending()
        SQL.AddParam("@stat", "P")
        SQL.ExecQuery("select count(applicationid) as pcount from ONLINE.business_applicationstatus_dtl where admin_status = @stat")
        For Each r As DataRow In SQL.DBDT.Rows
            lbl_countpending.Text = (r("pcount"))
        Next
    End Sub









    Public Sub malinacodeperobackupankola()
        'SQL.AddParam("@stat", "FA")
        'SQL.ExecQuery("Select * from tryadmin where status= @stat ")
        'For Each Val As DataRow In SQL.DBDT.Rows
        '    labelstat.Text = (Val("acctno"))
        'Next



        'SQL.bsource.DataSource = SQL.DBDT

        'DataGridView1.DataSource = SQL.bsource


        'With DataGridView1

        '    .RowHeadersVisible = False
        '    .Columns(0).HeaderCell.Value = "ID"
        '    .Columns(0).Width = 10
        '    .Columns(0).Visible = False


        '    .RowHeadersVisible = False
        '    .Columns(1).HeaderCell.Value = "APPID"
        '    .Columns(1).Width = 10
        '    .Columns(1).Visible = False

        '    .RowHeadersVisible = False
        '    .Columns(2).HeaderCell.Value = "ACCOUNT NO"
        '    .Columns(2).Width = 100


        '    .Columns(3).HeaderCell.Value = "GROSS"
        '    .Columns(3).Width = 200


        '    .Columns(4).HeaderCell.Value = "BUSINESSLINE"
        '    .Columns(4).Width = 200

        '    .Columns(5).HeaderCell.Value = "STATUS"
        '    .Columns(5).Width = 50
        '    .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        '    .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        '    .MultiSelect = False

        'End With
    End Sub


    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles timerpending.Tick
        ' lbl_countpending.Text = ""
        '  MsgBox("wewewewew")
        DataGridView2.Rows.Clear()
        selectpending()
        loadevalpending()
        dt_Appoinment.Value = DateTime.Now
    End Sub

    Private Sub Panel3_Paint_1(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub


    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click
        DataGridView1.Rows.Clear()

        LoadData()

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class