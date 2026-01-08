
Imports MySql.Data.MySqlClient

Public Class Evaluator
    Private SQL As New sqlcontrol2
    Private authuser As String

    Private loginuserid As Integer = LogIn.lblid.Text
    Dim mRow As Integer = 0
    Dim newpage As Boolean = True
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
        Me.Refresh()


        MainMenu.btneval.Enabled = True

    End Sub

    Private Sub Evaluator_Load(sender As Object, e As EventArgs) Handles MyBase.Load




        LoadAdmingrid()
        LoadData()
        selectpending()

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DataGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub AdminGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles EvalGrid.CellContentClick
        If e.RowIndex = -1 Then
            'Do nothing
            'ElseIf e.RowIndex <> 0 Then
            '    MessageBox.Show("Please prioritize requests according to queue", "CANNOT EVALUATE", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '    Exit Sub
        End If


        If e.ColumnIndex = 7 Then
            lblappid.Text = EvalGrid.CurrentRow.Cells(1).Value
            Dim f As New Evaluation
            f.MdiParent = MainMenu
            f.Show()
            Me.Hide()

        End If
    End Sub


    Public Sub LoadAdmingrid()
       

        Dim btneval As New DataGridViewButtonColumn
        EvalGrid.Columns.Add(btneval)
        With btneval
            .HeaderText = "ACTION"
            .Width = 130
            .Name = "btneval"
            .Text = "EVALUATE GROSS"
            .UseColumnTextForButtonValue = True


        End With




    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub
    Public Sub LoadData()



        SQL.AddParam("@adstat", "V")
        SQL.AddParam("@evalstat", "P")
        SQL.AddParam("@userid", loginuserid)

        SQL.ExecQuery("Select a.recordid, a.applicationid , a.accountno, a.businessname , a.gross_dec, a.businessline, c.admin_status, c.eval_status ,adminpassed_timedt, IsPendingTemp from ONLINE.business_application_tbl a " &
                      "inner join ONLINE.business_applicationstatus_dtl c on a.applicationID = c.applicationID where admin_status = @adstat and eval_status = @evalstat and user_eval = @userid  order by adminpassed_timedt asc")

        For Each r As DataRow In SQL.DBDT.Rows
            EvalGrid.Rows.Add(r("recordid"), r("applicationid"), r("accountno"), r("businessname"), r("gross_dec"), r("businessline"), r("eval_status"))
        Next
    End Sub

    Private Sub PanelAppoinment_Paint(sender As Object, e As PaintEventArgs) Handles PanelAppoinment.Paint

    End Sub

    Private Sub cmb_appointmentstatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbtype.SelectedIndexChanged
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
        ElseIf cmbtype.Text = "EVALUATED" Then
            EvalGrid.Rows.Clear()
            LoadDoneData()
            Paneldone.BackColor = Color.LightBlue
            PanelP.BackColor = Color.WhiteSmoke
            Panelre.BackColor = Color.WhiteSmoke
        End If



    End Sub




    Public Sub LoadReuploadData()
        SQL.AddParam("@adstat", "V")
        SQL.AddParam("@evalstat", "P")
        SQL.AddParam("@userid", loginuserid)
        SQL.ExecQuery("Select a.recordid, b.applicationid , a.accountno, b_name , b.gross_dec, a.b_line, c.admin_status, c.eval_status, isReupload , IsPendingTemp from ONLINE.business_record_hdr a " &
                      "inner join ONLINE.business_application_tbl b on a.recordID = b.recordID inner join ONLINE.business_applicationstatus_dtl c on b.applicationID = c.applicationID where admin_status = @adstat and IsReupload = 1 and eval_status = @evalstat and user_eval = @userid and  IsPendingTemp = 0")

        For Each r As DataRow In SQL.DBDT.Rows
            EvalGrid.Rows.Add(r("recordid"), r("applicationid"), r("accountno"), r("b_name"), r("gross_dec"), r("b_line"), r("eval_status"))
        Next
    End Sub




    Public Sub LoadDoneData()

        SQL.AddParam("@adstat", "V")
        SQL.AddParam("@evalstat", "V")
        SQL.AddParam("@userid", loginuserid)

        SQL.ExecQuery("Select a.recordid, b.applicationid , a.accountno, b_name , b.final_gross, a.b_line, c.admin_status, c.eval_status, isReupload,adminpassed_timedt , IsPendingTemp from ONLINE.business_record_hdr a " &
                      "inner join ONLINE.business_application_tbl b on a.recordID = b.recordID inner join ONLINE.business_applicationstatus_dtl c on b.applicationID = c.applicationID where admin_status = @adstat and eval_status = @evalstat and user_eval = @userid and IsPendingTemp = 0 order by eval_timedt desc")

        For Each r As DataRow In SQL.DBDT.Rows
            EvalGrid.Rows.Add(r("recordid"), r("applicationid"), r("accountno"), r("b_name"), r("final_gross"), r("b_line"), r("eval_status"))
        Next
    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Panelre.Paint

    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        'Dim intconfirm As Integer = MessageBox.Show("Switch to Reuploaded requests?", "QUESTION", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        ' If intconfirm = DialogResult.OK Then
        EvalGrid.Rows.Clear()
        LoadReuploadData()
        cmbtype.SelectedIndex = 2
        Panelre.BackColor = Color.LightBlue
        PanelP.BackColor = Color.WhiteSmoke
        Paneldone.BackColor = Color.WhiteSmoke
        ' Else
        ' Exit Sub
        ' End If



    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click

        EvalGrid.Rows.Clear()
        LoadData()

        cmbtype.SelectedIndex = 0
        PanelP.BackColor = Color.LightBlue
        Panelre.BackColor = Color.WhiteSmoke
        Paneldone.BackColor = Color.WhiteSmoke
    End Sub



    Public Sub selectpending()
        SQL.AddParam("@stat", "P")
        SQL.AddParam("@userid", loginuserid)
        SQL.ExecQuery("select count(applicationid) as pcount from ONLINE.business_applicationstatus_dtl where eval_status = @stat  and user_eval = @userid")
        For Each r As DataRow In SQL.DBDT.Rows
            lbl_countpending.Text = (r("pcount"))
        Next



        'SQL.AddParam("@stat", "P")
        'SQL.AddParam("@userid", loginuserid)
        'SQL.ExecQuery("select count(applicationid) as pcount from ONLINE.business_applicationstatus_dtl where eval_status = @stat  and user_eval = @userid and isreupload = 1 ")
        'For Each r As DataRow In SQL.DBDT.Rows
        '    lblreupload.Text = (r("pcount"))

        'Next





        SQL.AddParam("@stat", "V")
        SQL.AddParam("@userid", loginuserid)
        SQL.ExecQuery("select count(applicationid) as pcount from ONLINE.business_applicationstatus_dtl where eval_status = @stat  and user_eval = @userid ")
        For Each r As DataRow In SQL.DBDT.Rows
            lbldone.Text = (r("pcount"))
        Next

    End Sub

    Private Sub timerpending_Tick(sender As Object, e As EventArgs) Handles timerpending.Tick
        '  MsgBox("wewewewew")
        '   EvalGrid.Rows.Clear()
        selectpending()
        '  loadassesspending()

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub PanelP_Paint(sender As Object, e As PaintEventArgs) Handles PanelP.Paint

    End Sub

    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click
        EvalGrid.Rows.Clear()
        LoadData()
        cmbtype.SelectedIndex = 0
        PanelP.BackColor = Color.LightBlue
        Panelre.BackColor = Color.WhiteSmoke
        Paneldone.BackColor = Color.WhiteSmoke
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        EvalGrid.Rows.Clear()
        LoadDoneData()

        cmbtype.SelectedIndex = 1
        Paneldone.BackColor = Color.LightBlue
        Panelre.BackColor = Color.WhiteSmoke
        PanelP.BackColor = Color.WhiteSmoke
    End Sub
End Class