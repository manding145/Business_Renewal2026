Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports Tulpep.NotificationWindow

Public Class MainMenu





    Private SQL As New sqlcontrol2
    Private sql4 As New sqlcontrol4
    Private SQL2 As New sqlcontrol2
    Private authuser As String




    Public loginuserid As Integer = LogIn.lblid.Text
    Private loginuserpos As String = LogIn.lblpos.Text
    Dim mRow As Integer = 0
    Dim newpage As Boolean = True
    Private Sub BtnSearchRecord_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub MainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer2.Start()
        If loginuserpos = "ADMIN" Then
            loadpopup()
        ElseIf loginuserpos = "EVALUATOR" Then
            loadpopupeval()
        ElseIf loginuserpos = "ASSESSOR" Then
            loadpopupassess()
        ElseIf loginuserpos = "RPT_ADMIN" Then
            loadpopuprpt_admin()
        ElseIf loginuserpos = "RPT_ASSESSOR" Then
            loadpopuprpt_assess()
        ElseIf loginuserpos = "CASSO_ADMIN" Then
            loadpopupcasso()
        End If





        For Each ctl As Control In Me.Controls
            If TypeOf ctl Is MdiClient Then
                ctl.BackColor = Me.BackColor
            End If
        Next ctl



        lblfname.Text = LogIn.lblfullname.Text
        lbluserrole.Text = LogIn.lblpos.Text
    End Sub



    Private Sub btneval_Click_1(sender As Object, e As EventArgs) Handles btneval.Click
        If loginuserpos = "ADMIN" OrElse loginuserpos = "EVALUATOR" Then

            Dim f As New Evaluator
            f.MdiParent = Me
            f.Show()
            btneval.Enabled = False

        Else
            MessageBox.Show("You have no access for this module", "INACCESSIBLE", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Exit Sub
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnadmin.Click

        If loginuserpos <> "ADMIN" Then
            MessageBox.Show("You have no access for this module", "INACCESSIBLE", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Exit Sub
        End If


        Dim f As New SuperAdmin
        f.MdiParent = Me
        f.Show()
        btnadmin.Enabled = False
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
        LogIn.Show()

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs)
        '  lbltime.Text = DateTime.Now.ToString
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs)

    End Sub

    Private Sub Timer1_Tick_1(sender As Object, e As EventArgs) Handles Timer1.Tick
        lbltime.Text = DateTime.Now.DayOfWeek.ToString + "  " + DateTime.Now.ToString
    End Sub

    Private Sub btnassess_Click(sender As Object, e As EventArgs) Handles btnassess.Click


        If loginuserpos = "ADMIN" OrElse loginuserpos = "ASSESSOR" Then
            Dim f As New Assessor
            f.MdiParent = Me
            f.Show()
            btnassess.Enabled = False
        Else
            MessageBox.Show("You have no access for this module", "INACCESSIBLE", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Exit Sub
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnbusiness.Click
        Panelrpt.Visible = False
        Panelctc.Visible = False
        Panelcol.Visible = False


        If Panelbusiness.Visible = True Then
            Panelbusiness.Visible = False
        ElseIf Panelbusiness.Visible = False Then
            Panelbusiness.Visible = True
        End If

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnrpt.Click
        Panelbusiness.Visible = False
        Panelctc.Visible = False
        Panelcol.Visible = False

        If Panelrpt.Visible = True Then
            Panelrpt.Visible = False
        ElseIf Panelrpt.Visible = False Then
            Panelrpt.Visible = True
        End If
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles btnctc.Click
        Panelbusiness.Visible = False
        Panelrpt.Visible = False
        Panelcol.Visible = False

        If Panelctc.Visible = True Then
            Panelctc.Visible = False
        ElseIf Panelctc.Visible = False Then
            Panelctc.Visible = True
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles btncol.Click
        Panelbusiness.Visible = False
        Panelrpt.Visible = False
        Panelctc.Visible = False

        If Panelcol.Visible = True Then
            Panelcol.Visible = False
        ElseIf Panelcol.Visible = False Then
            Panelcol.Visible = True
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnced.Click
        Dim f As New cedulacorp_assess
        f.MdiParent = Me
        f.Show()
        btnced.Enabled = False
    End Sub

    Private Sub btnrptreq_Click(sender As Object, e As EventArgs) Handles btnrptreq.Click
        If loginuserpos <> "RPT_ADMIN" Then
            MessageBox.Show("You have no access for this module", "INACCESSIBLE", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Exit Sub
        End If



        Dim f As New rptadmin
        f.MdiParent = Me
        f.Show()
        btnrptreq.Enabled = False
    End Sub

    Private Sub btnadmin_MouseHover(sender As Object, e As EventArgs) Handles btnadmin.MouseHover
        ' btnadmin.BackColor = Color.Aqua
    End Sub

    Private Sub btnbusinesssmall_Click(sender As Object, e As EventArgs) Handles btnbusinesssmall.Click
        Panelrpt.Visible = False
        Panelctc.Visible = False
        Panelcol.Visible = False


        If Panelbusiness.Visible = True Then
            Panelbusiness.Visible = False
        ElseIf Panelbusiness.Visible = False Then
            Panelbusiness.Visible = True
        End If
    End Sub

    Private Sub btnbusinesssmall_MouseHover(sender As Object, e As EventArgs) Handles btnbusinesssmall.MouseHover
        btnbusinesssmall.Visible = False
        btnbusiness.Visible = True
    End Sub

    Private Sub btnbusiness_MouseHover(sender As Object, e As EventArgs) Handles btnbusiness.MouseHover
        'btnbusiness.Height = 47
        'btnbusiness.Width = 183

        'Dim fBold As New Font("Segoe UI", 12, FontStyle.Bold, FontStyle.Italic)
        'btnbusiness.Font = fBold
        ''  btnbusiness.Font = New Font(btnbusiness.Font, FontStyle.Italic)
        ''con4.Font = New Font(con4.Font, FontStyle.Bold)
    End Sub

    Private Sub btnbusiness_MouseLeave(sender As Object, e As EventArgs) Handles btnbusiness.MouseLeave
        btnbusinesssmall.Visible = True
        btnbusiness.Visible = False
    End Sub

    Private Sub btnrptsmall_Click(sender As Object, e As EventArgs) Handles btnrptsmall.Click
        Panelbusiness.Visible = False
        Panelctc.Visible = False
        Panelcol.Visible = False

        If Panelrpt.Visible = True Then
            Panelrpt.Visible = False
        ElseIf Panelrpt.Visible = False Then
            Panelrpt.Visible = True
        End If
    End Sub

    Private Sub btnrptsmall_MouseHover(sender As Object, e As EventArgs) Handles btnrptsmall.MouseHover
        btnrptsmall.Visible = False
        btnrpt.Visible = True

    End Sub

    Private Sub btnrpt_MouseLeave(sender As Object, e As EventArgs) Handles btnrpt.MouseLeave
        btnrptsmall.Visible = True
        btnrpt.Visible = False

    End Sub

    Private Sub btnctcsmall_Click(sender As Object, e As EventArgs) Handles btnctcsmall.Click
        Panelbusiness.Visible = False
        Panelrpt.Visible = False
        Panelcol.Visible = False

        If Panelctc.Visible = True Then
            Panelctc.Visible = False
        ElseIf Panelctc.Visible = False Then
            Panelctc.Visible = True
        End If
    End Sub

    Private Sub btnctcsmall_MouseHover(sender As Object, e As EventArgs) Handles btnctcsmall.MouseHover
        btnctcsmall.Visible = False
        btnctc.Visible = True

    End Sub

    Private Sub btnctc_MouseLeave(sender As Object, e As EventArgs) Handles btnctc.MouseLeave
        btnctcsmall.Visible = True
        btnctc.Visible = False
    End Sub

    Private Sub btncolsmall_Click(sender As Object, e As EventArgs) Handles btncolsmall.Click
        Panelbusiness.Visible = False
        Panelrpt.Visible = False
        Panelctc.Visible = False

        If Panelcol.Visible = True Then
            Panelcol.Visible = False
        ElseIf Panelcol.Visible = False Then
            Panelcol.Visible = True
        End If

    End Sub

    Private Sub btncolsmall_MouseHover(sender As Object, e As EventArgs) Handles btncolsmall.MouseHover
        btncolsmall.Visible = False
        btncol.Visible = True
    End Sub

    Private Sub btncol_MouseLeave(sender As Object, e As EventArgs) Handles btncol.MouseLeave
        btncolsmall.Visible = True
        btncol.Visible = False
    End Sub

    Private Sub btnmaintenancesmall_Click(sender As Object, e As EventArgs) Handles btnmaintenancesmall.Click

    End Sub

    Private Sub btnmaintenancesmall_MouseHover(sender As Object, e As EventArgs) Handles btnmaintenancesmall.MouseHover
        btnmaintenancesmall.Visible = False
        btnmaintenance.Visible = True
    End Sub

    Private Sub btnmaintenance_Click(sender As Object, e As EventArgs) Handles btnmaintenance.Click
        If Panelmaintenance.Visible = True Then
            Panelmaintenance.Visible = False
        ElseIf Panelmaintenance.Visible = False Then
            Panelmaintenance.Visible = True
        End If
    End Sub

    Private Sub btnmaintenance_MouseLeave(sender As Object, e As EventArgs) Handles btnmaintenance.MouseLeave
        btnmaintenancesmall.Visible = True
        btnmaintenance.Visible = False
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles btnbusinesscol.Click
        Dim f As New Collector
        f.MdiParent = Me
        f.Show()
        btnbusinesscol.Enabled = False
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles btnrptassess.Click
        Dim f As New rpt_assessor
        f.MdiParent = Me
        f.Show()
        btnrptassess.Enabled = False
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btndash.Click
        Dim f As New reqStatus
        f.MdiParent = Me
        f.Show()
        btndash.Enabled = False
    End Sub

    Public Sub loadpopup()
        Dim intcounter As String

        SQL.AddParam("@stat", "P")
        SQL.AddParam("@userid", loginuserid)
        SQL.ExecQuery("select count(applicationid) as pcount from ONLINE.business_applicationstatus_dtl where admin_status = @stat   and isreupload = 0 and  Ispendingtemp = 0")
        For Each r As DataRow In SQL.DBDT.Rows
            intcounter = (r("pcount").ToString)
        Next



        Dim popup As New PopupNotifier
        popup.ContentColor = Color.Blue
        popup.TitleText = "BUSINESS PORTAL"
        popup.TitleFont = New Font("Tw Cen Mt", 12, FontStyle.Bold)
        popup.ContentFont = New Font("Segoe UI", 14, FontStyle.Italic)
        popup.ContentText = "You have " + intcounter + " Pending requests as " + loginuserpos
        'popup.AnimationDuration = 2
        If intcounter <> "0" Then
            popup.Popup()
        End If
    End Sub



    Public Sub loadpopupeval()
        Dim intcounter As String

        SQL.AddParam("@stat", "P")
        SQL.AddParam("@userid", loginuserid)
        SQL.ExecQuery("select count(applicationid) as pcount from ONLINE.business_applicationstatus_dtl where eval_status = @stat  and user_eval = @userid and isreupload = 0 and  Ispendingtemp = 0")
        For Each r As DataRow In SQL.DBDT.Rows
            intcounter = (r("pcount").ToString)
        Next



        Dim popup As New PopupNotifier
        popup.ContentColor = Color.Blue
        popup.TitleText = "BUSINESS PORTAL"
        popup.TitleFont = New Font("Tw Cen Mt", 12, FontStyle.Bold)
        popup.ContentFont = New Font("Segoe UI", 14, FontStyle.Italic)
        popup.ContentText = "You have " + intcounter + " Pending requests as " + loginuserpos
        'popup.AnimationDuration = 2
        If intcounter <> "0" Then
            popup.Popup()
        End If
    End Sub




    Public Sub loadpopupassess()
        Dim intcounter As String

        SQL.AddParam("@stat", "P")
        SQL.AddParam("@userid", loginuserid)
        SQL.ExecQuery("select count(applicationid) as pcount from ONLINE.business_applicationstatus_dtl where assess_status = @stat  and user_assess = @userid and isreupload = 0  and Ispendingtemp = 0")
        For Each r As DataRow In SQL.DBDT.Rows
            intcounter = (r("pcount").ToString)
        Next



        Dim popup As New PopupNotifier
        popup.ContentColor = Color.Blue
        popup.TitleText = "BUSINESS PORTAL"
        popup.TitleFont = New Font("Tw Cen Mt", 12, FontStyle.Bold)
        popup.ContentFont = New Font("Segoe UI", 14, FontStyle.Italic)
        popup.ContentText = "You have " + intcounter + " Pending requests as " + loginuserpos
        'popup.AnimationDuration = 2
        If intcounter <> "0" Then
            popup.Popup()
        End If
    End Sub




    Public Sub loadpopuprpt_assess()
        Dim intcounter As String

        SQL.AddParam("@stat", "P")
        SQL.AddParam("@userid", loginuserid)
        SQL.ExecQuery("select count(rpt_applicationid) as pcount from rpt_application where assess_status = @stat  and user_assess = @userid")
        For Each r As DataRow In SQL.DBDT.Rows
            intcounter = (r("pcount").ToString)
        Next



        Dim popup As New PopupNotifier
        popup.ContentColor = Color.Blue
        popup.TitleText = "BUSINESS PORTAL"
        popup.TitleFont = New Font("Tw Cen Mt", 12, FontStyle.Bold)
        popup.ContentFont = New Font("Segoe UI", 14, FontStyle.Italic)
        popup.ContentText = "You have " + intcounter + " Pending requests as " + loginuserpos
        'popup.AnimationDuration = 2
        If intcounter <> "0" Then
            popup.Popup()
        End If
    End Sub



    Public Sub loadpopuprpt_admin()
        Dim intcounter As String

        SQL.AddParam("@stat", "P")
        SQL.AddParam("@userid", loginuserid)
        SQL.ExecQuery("select count(rpt_applicationid) as pcount from rpt_application where admin_status = @stat ")
        For Each r As DataRow In SQL.DBDT.Rows
            intcounter = (r("pcount").ToString)
        Next



        Dim popup As New PopupNotifier
        popup.ContentColor = Color.Blue
        popup.TitleText = "BUSINESS PORTAL"
        popup.TitleFont = New Font("Tw Cen Mt", 12, FontStyle.Bold)
        popup.ContentFont = New Font("Segoe UI", 14, FontStyle.Italic)
        popup.ContentText = "You have " + intcounter + " Pending requests as " + loginuserpos
        'popup.AnimationDuration = 2
        If intcounter <> "0" Then
            popup.Popup()
        End If
    End Sub


    Public Sub loadpopupcasso()
        Dim intcounter As String

        SQL.AddParam("@stat", "P")
        SQL.AddParam("@userid", loginuserid)
        SQL.ExecQuery("select count(rpt_applicationid) as pcount from rpt_application where casso_status = @stat ")
        For Each r As DataRow In SQL.DBDT.Rows
            intcounter = (r("pcount").ToString)
        Next



        Dim popup As New PopupNotifier
        popup.ContentColor = Color.Blue
        popup.TitleText = "BUSINESS PORTAL"
        popup.TitleFont = New Font("Tw Cen Mt", 12, FontStyle.Bold)
        popup.ContentFont = New Font("Segoe UI", 14, FontStyle.Italic)
        popup.ContentText = "You have " + intcounter + " Pending requests as " + loginuserpos
        'popup.AnimationDuration = 2
        If intcounter <> "0" Then
            popup.Popup()
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If loginuserpos = "ADMIN" Then
            loadpopup()
        ElseIf loginuserpos = "EVALUATOR" Then
            loadpopupeval()
        ElseIf loginuserpos = "ASSESSOR" Then
            loadpopupassess()
        ElseIf loginuserpos = "RPT_ADMIN" Then
            loadpopuprpt_admin()
        ElseIf loginuserpos = "RPT_ASSESSOR" Then
            loadpopuprpt_assess()
        ElseIf loginuserpos = "CASSO_ADMIN" Then
            loadpopupcasso()
        End If
    End Sub

    Private Sub lbltime_Click(sender As Object, e As EventArgs) Handles lbltime.Click

    End Sub




    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles btnhcsend.Click
        Dim f As New HealthCardsend
        f.MdiParent = Me
        f.Show()
        btnhcsend.Enabled = False
    End Sub

    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles btnrptcol.Click
        Dim f As New Collection
        f.MdiParent = Me
        f.Show()
        btnrptcol.Enabled = False
    End Sub


    Private Sub btnpost_Click(sender As Object, e As EventArgs) Handles btnpost.Click
        SQL2.AddParam("@taxdec", "12-0006-10430")
        SQL2.ExecQuery("SELECT * FROM PATAS.TDN where TDN = @taxdec ")
        For Each r As DataRow In sql2.DBDT.Rows
            btnpost.Text = (r("TDN").ToString)
        Next
    End Sub

    Private Sub Button1_Click_3(sender As Object, e As EventArgs) Handles btncasso.Click

        'If loginuserpos <> "CASSO_ADMIN" Then
        '    MessageBox.Show("You have no access for this module", "INACCESSIBLE", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        '    Exit Sub
        'End If
        Dim f As New Casso
        f.MdiParent = Me
        f.Show()
        btncasso.Enabled = False
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub
End Class