Imports MySql.Data.MySqlClient


Public Class Assessor

    Private SQL As New sqlcontrol2
    Private authuser As String
    Private loginuserid As Integer = LogIn.lblid.Text

    Dim mRow As Integer = 0
    Dim newpage As Boolean = True
    ' Dim connection As New MySqlConnection("datasource=10.0.14.117;username=usera2;password=passa2")


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
        Me.Refresh()


        ' MainMenu.btneval.Enabled = True

        MainMenu.btnassess.Enabled = True


    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub Assessor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAdmingrid()
        LoadData()
        '    txtd.Text = dt_Appoinment.Value.Day
    End Sub


    Public Sub LoadData()

        EvalGrid.Columns(4).HeaderText = "GROSS"
        SQL.AddParam("@adstat", "V")
        SQL.AddParam("@assessstat", "P")
        SQL.AddParam("@userid", loginuserid)

        SQL.ExecQuery("Select a.recordid, a.applicationid , a.accountno, a.businessname , a.gross_dec, a.businessline, c.eval_status, c.assess_status , IsPendingTemp from  ONLINE.business_application_tbl a " &
                      "inner join ONLINE.business_applicationstatus_dtl c on a.applicationID = c.applicationID where eval_status = @adstat and assess_status = @assessstat and user_assess = @userid order by eval_timedt ")

        For Each r As DataRow In SQL.DBDT.Rows
            EvalGrid.Rows.Add(r("recordid"), r("applicationid"), r("accountno"), r("businessname"), r("gross_dec"), r("businessline"), r("assess_status"))
        Next



    End Sub

    Public Sub LoadAdmingrid()


        Dim btneval As New DataGridViewButtonColumn
        EvalGrid.Columns.Add(btneval)
        With btneval
            .HeaderText = "ACTION"
            .Width = 130
            .Name = "btneval"
            .Text = "ASSESS"
            .UseColumnTextForButtonValue = True


        End With
    End Sub

    Private Sub EvalGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles EvalGrid.CellContentClick
        If e.RowIndex = -1 Then
            Exit Sub
            'ElseIf e.RowIndex <> 0 Then
            '    MessageBox.Show("Please prioritize requests according to queue", "CANNOT EVALUATE", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '    Exit Sub
        End If


        If e.ColumnIndex = 7 Then
            Dim f As New Assessment
            f.MdiParent = MainMenu
            f.Show()
            Me.Hide()

        End If
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        EvalGrid.Rows.Clear()
        LoadData()
        cmbtype.SelectedIndex = 0

        Panelp.BackColor = Color.LightBlue
        Panelre.BackColor = Color.WhiteSmoke
        Paneldone.BackColor = Color.WhiteSmoke
    End Sub

    Private Sub cmbtype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbtype.SelectedIndexChanged
        If cmbtype.Text = "PENDING" Then
            EvalGrid.Rows.Clear()
            LoadData()

            PanelP.BackColor = Color.LightBlue
            Panelre.BackColor = Color.WhiteSmoke
            Paneldone.BackColor = Color.WhiteSmoke
        ElseIf cmbtype.Text = "RE-UPLOADED" Then
            EvalGrid.Rows.Clear()
            LoadReuploadData()
            Panelre.BackColor = Color.LightBlue
            PanelP.BackColor = Color.WhiteSmoke
            Paneldone.BackColor = Color.WhiteSmoke
        ElseIf cmbtype.Text = "ASSESSED" Then
            EvalGrid.Rows.Clear()
            LoadDoneData()
            Paneldone.BackColor = Color.LightBlue
            Panelp.BackColor = Color.WhiteSmoke
            Panelre.BackColor = Color.WhiteSmoke
        End If
    End Sub

    Public Sub LoadReuploadData()
        EvalGrid.Columns(4).HeaderText = "GROSS"
        SQL.AddParam("@adstat", "V")
        SQL.AddParam("@stat", "P")
        SQL.AddParam("@userid", loginuserid)
        SQL.ExecQuery("Select a.recordid, b.applicationid , a.accountno, b_name , b.gross_dec, a.b_line, c.admin_status, c.eval_status, isReupload , IsPendingTemp from BREC.business_record_hdr a " &
                      "inner join ONLINE.business_application_tbl b on a.recordID = b.recordID inner join ONLINE.business_applicationstatus_dtl c on b.applicationID = c.applicationID where eval_status = @adstat and IsReupload = 1 and assess_status = @stat and user_assess = @userid and IsPendingTemp = 0 ")

        For Each r As DataRow In SQL.DBDT.Rows
            EvalGrid.Rows.Add(r("recordid"), r("applicationid"), r("accountno"), r("b_name"), r("gross_dec"), r("b_line"), r("eval_status"))
        Next
    End Sub

    Public Sub LoadDoneData()


        EvalGrid.Columns(4).HeaderText = "AMOUNT"

        Dim stryear As String = dt_Appoinment.Value.Year
        Dim strmonth As String = dt_Appoinment.Value.Month
        Dim strday As String = dt_Appoinment.Value.Day

        SQL.AddParam("@adstat", "V")
        SQL.AddParam("@stat", "V")
        SQL.AddParam("@userid", loginuserid)
        SQL.AddParam("@yr", stryear)
        SQL.AddParam("@mo", strmonth)
        SQL.AddParam("@dy", strday)

        SQL.ExecQuery("Select a.recordid, b.applicationid , a.accountno, b_name , b.AmountToPay, a.b_line, c.admin_status, c.eval_status, isReupload,adminpassed_timedt ,IsPendingTemp,assess_timedt  from business_record_hdr a " & _
                      "inner join business_application_tbl b on a.recordID = b.recordID inner join business_applicationstatus_dtl c on b.applicationID = c.applicationID where eval_status = @adstat and assess_status = @stat and user_assess = @userid and IsPendingTemp = 0 and year(assess_timedt) = @yr and month(assess_timedt) = @mo and day(assess_timedt) = @dy order by assess_timedt desc")

        For Each r As DataRow In SQL.DBDT.Rows
            EvalGrid.Rows.Add(r("recordid"), r("applicationid"), r("accountno"), r("b_name"), r("AmountToPay"), r("b_line"), r("eval_status"))
        Next
    End Sub
    Public Sub selectpending()


        SQL.AddParam("@stat", "P")
        SQL.AddParam("@userid", loginuserid)
        SQL.ExecQuery("select count(applicationid) as pcount from ONLINE.business_applicationstatus_dtl where assess_status = @stat  and user_assess = @userid")
        For Each r As DataRow In SQL.DBDT.Rows
            lbl_countpending.Text = (r("pcount"))
        Next



        'SQL.AddParam("@stat", "P")
        'SQL.AddParam("@userid", loginuserid)
        'SQL.ExecQuery("select count(applicationid) as pcount from ONLINE.business_applicationstatus_dtl where assess_status = @stat  and user_assess = @userid and isreupload = 1 ")
        'For Each r As DataRow In SQL.DBDT.Rows
        '    lblreupload.Text = (r("pcount"))

        'Next





        SQL.AddParam("@stat", "V")
        SQL.AddParam("@userid", loginuserid)
        SQL.ExecQuery("select count(applicationid) as pcount from ONLINE.business_applicationstatus_dtl where assess_status = @stat  and user_assess = @userid ")
        For Each r As DataRow In SQL.DBDT.Rows
            lbldone.Text = (r("pcount"))
        Next

    End Sub

    Private Sub timerpending_Tick(sender As Object, e As EventArgs) Handles timerpending.Tick
        selectpending()

    End Sub

    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click
        EvalGrid.Rows.Clear()
        LoadData()
        cmbtype.SelectedIndex = 0

        Panelp.BackColor = Color.LightBlue
        Panelre.BackColor = Color.WhiteSmoke
        Paneldone.BackColor = Color.WhiteSmoke
    End Sub

    Private Sub dt_Appoinment_ValueChanged(sender As Object, e As EventArgs) Handles dt_Appoinment.ValueChanged

        If cmbtype.Text = "PENDING" Then
            'Do nothing
            Exit Sub
        ElseIf cmbtype.Text = "RE-UPLOADED" Then
            'Do nothing
            Exit Sub
        ElseIf cmbtype.Text = "" Then
            'Do nothing
            Exit Sub
        End If

        EvalGrid.Rows.Clear()
        LoadDoneData()

    End Sub

    Private Sub Panelp_Paint(sender As Object, e As PaintEventArgs) Handles Panelp.Paint
      
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        EvalGrid.Rows.Clear()
        LoadReuploadData()
        cmbtype.SelectedIndex = 2

        Panelre.BackColor = Color.LightBlue
        Panelp.BackColor = Color.WhiteSmoke
        Paneldone.BackColor = Color.WhiteSmoke
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        EvalGrid.Rows.Clear()
        LoadDoneData()
        cmbtype.SelectedIndex = 1


        Paneldone.BackColor = Color.LightBlue
        Panelp.BackColor = Color.WhiteSmoke
        Panelre.BackColor = Color.WhiteSmoke
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class