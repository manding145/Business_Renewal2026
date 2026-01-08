Imports MySql.Data.MySqlClient
Imports System.IO


Public Class Assessment
    Private SQL As New sqlcontrol2
    Private authuser As String


    Dim Assessor As Assessor = CType(Application.OpenForms("Assessor"), Assessor)
    Private intappid As Integer = Assessor.EvalGrid.CurrentRow.Cells(1).Value
    Private straccountno As String = Assessor.EvalGrid.CurrentRow.Cells(2).Value
    Private intuser As Integer = LogIn.lblid.Text
    Dim mRow As Integer = 0
    Dim newpage As Boolean = True
    Public refCode As String = ""




    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
        Dim f2 As New Assessor
        f2.MdiParent = MainMenu
        f2.Show()


    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CheckBox7_CheckedChanged(sender As Object, e As EventArgs)




    End Sub
    Private Sub Assessment_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Dim today As DateTime = DateTime.Now

        ' Find the last day of the current month
        Dim lastDay As DateTime = New DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month))

        ' Set the DateTimePicker to the last day of the current month
        validity.Value = lastDay


        loaddocdata()
        LoadAdmingrid()
        getrecord()

        loadremarks()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        '   Dim path As String = "D:\Mahesh"

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click, Button4.Click, Button1.Click


        Dim ofd As New OpenFileDialog
        ' ofd.Filter = "Adobe Acrobat Document|*.pdf "

        ' ofd.Filter = " Bitmap|*.bmp|JPEG|*.jpg "
        If ofd.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        ' If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
        Dim extension = System.IO.Path.GetExtension(ofd.FileName)
        Dim FileName = System.IO.Path.GetFileName(OpenFileDialog1.FileName)
        If (extension = ".pdf") Then
            txtdirec.Text = ofd.FileName
            AxAcroPDF1.src = ofd.FileName
            '  txtfilename.Text = FileName
            If AxAcroPDF1.src <> "" Then
                btnemail.Enabled = True
            End If
        Else
            MsgBox("Please select a pdf file")
        End If


        ' End If
    End Sub

    Private Sub btnemail_Click(sender As Object, e As EventArgs) Handles btnemail.Click
        If txtamount.Text <> txtamount2.Text Then
            MessageBox.Show("Amount does not match")
            Exit Sub
        End If


        Dim FileToMove As String
        Dim MoveLocation As String

        '  SQL.AddParam("")
        Dim strfilename As String = refCode + "_Assessment.pdf"
        FileToMove = txtdirec.Text


        'SQL.AddParam("@acct", straccountno)
        Dim strfolder As String
        Dim strnumber As String
        'SQL.ExecQuery("select * from ONLINE.business_record_hdr where accountno = @acct ")
        'For Each r As DataRow In SQL.DBDT.Rows
        strfolder = "BUSINESS_APPLICATION\" + refCode + "\"
        'strnumber = (r("b_contactno"))
        'Next

        'txtno.Text = strnumber
        Dim strprefix As String
        'SQL.ExecQuery("Select PrefixURL from ONLINE.m_prefix_attachments ")
        'For Each prefix As DataRow In SQL.DBDT.Rows
        '    strprefix = (prefix("PrefixURL").ToString)
        'Next

        strprefix = "\\10.0.27.194\FileAttachment\BUSINESS_APPLICATION\"
        MoveLocation = "\\10.0.27.194\FileAttachment\" & strfolder & strfilename
        Dim ctclocation As String = "\\10.0.27.194\FileAttachment\" & strfolder & refCode & "_CTC_Assessment.pdf"




        If System.IO.File.Exists(FileToMove) = True Then
            If System.IO.File.Exists(MoveLocation) = True Then
                Dim intconfirm As Integer = MessageBox.Show("Attachment with same filename exists ! continue? ", "CONFIRMATION", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                If intconfirm = DialogResult.OK Then
                    System.IO.File.Delete(MoveLocation)
                Else
                    MessageBox.Show("User Cancelled")
                    Exit Sub
                End If

            End If




            'check anay kun existing
            'Dim idexist As Integer
            'SQL.AddParam("@intappid1", intappid)
            '' SQL.AddParam("@qtr" 1)
            'SQL.ExecQuery("Select applicationID from business_assessment_dtl where applicationID = @intappid1")
            'For Each r As DataRow In SQL.DBDT.Rows
            '    idexist = (r("applicationID").ToString)
            'Next
            'If idexist <> Nothing Then
            '    Dim intconfirm As Integer = MessageBox.Show("You have previously sent an attachment with the same file name , do you wish to resend it?", "CONFIRMATION", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            '    If intconfirm = DialogResult.Cancel Then
            '        Exit Sub

            '    End If
            '    If intconfirm = DialogResult.OK Then
            '        ' waitiiiing
            '        Exit Sub
            '    End If


            ' End If



            'get email
            'Dim stremail As String
            'SQL.AddParam("@acct", straccountno)
            'SQL.ExecQuery("Select * from ONLINE.business_record_hdr where accountno = @acct")
            'For Each r As DataRow In SQL.DBDT.Rows
            '    stremail = (r("email_add"))
            'Next


            ' insert ha email_sender -- gncomment kay may fire

            'Dim inttotalamt As Decimal = lbltotal.Text
            'Dim strloc As String = strfolder & strfilename
            'SQL.AddParam("@acctno", straccountno)
            'SQL.AddParam("@totalamt", inttotalamt)
            'SQL.AddParam("@filename", strfilename)
            'SQL.AddParam("@loc", strloc)
            'SQL.AddParam("@intuser", intuser)
            'SQL.AddParam("@email", stremail)
            'SQL.AddParam("@num", strnumber)
            'SQL.AddParam("@datesend", dt_Appoinment.Value)
            'SQL.ExecQuery("Insert into ONLINE.email_send (accountno_tdn,total_amount, FileDirectory ,user_send, email, attachment_type, phonenumber , datesend)" &
            '              "values (@acctno,@totalamt,@loc,@intuser,@email, 'BUSINESS_AS' , @num , @datesend)")





            'update it status ha applicationstatus
            SQL.AddParam("@intappid", intappid)
            SQL.AddParam("@dt", dt_Appoinment.Value.ToString("yyyy-MM-dd"))
            SQL.ExecQuery("update ONLINE.business_applicationstatus_dtl set assess_status = 'V', assess_timedt = @dt , payment_status = 'P' where applicationID = @intappid")

            Dim fullname As String = ""
            Dim email As String = ""

            SQL.AddParam("@userid", userid)
            SQL.ExecQuery("Select * from ONLINE.SysMngr WHERE UserID=@userid")
            For Each r As DataRow In SQL.DBDT.Rows

                fullname = (r("Firstname").ToString) & " " & (r("Middlename").ToString) & " " & (r("Lastname").ToString)
                email = (r("Email").ToString)

            Next


            'email outbox
            Dim inttotalamt As Decimal = lbltotal.Text
            Dim strloc As String = strfolder & strfilename
            SQL.AddParam("@accountno", txtaccountno.Text)
            SQL.AddParam("@Sent", 0)
            SQL.AddParam("@email", email)
            SQL.AddParam("@Subject", "Business Tax Assessment")
            SQL.AddParam("@fullname", fullname)
            SQL.AddParam("@assessment_path", MoveLocation)
            SQL.AddParam("@CTC_path", ctclocation)
            SQL.AddParam("@userid", userid)
            SQL.AddParam("@referencecode", refCode)
            SQL.AddParam("@datesend", dt_Appoinment.Value)
            SQL.AddParam("@validity", validity.Value.ToString("yyyy-MM-dd"))
            SQL.ExecQuery("Insert into ONLINE.email_outbox (validitydate, accountno, Sent, email, Subject, fullname, assessment_path, ctc_assess_path, userid, referencecode, datesend)" &
                          "values (@validity, @accountno, @Sent, @email, @Subject, @fullname, @assessment_path, @CTC_path, @userid, @referencecode, @datesend)")



            'update it amount ha application
            SQL.AddParam("@intappid", intappid)
            SQL.AddParam("@totalamt", txtamount.Text)
            SQL.ExecQuery("update ONLINE.business_application_tbl set amountToPay = @totalamt where applicationID = @intappid")


            Dim stracctexist As String
            SQL.AddParam("@aid", intappid)
            SQL.ExecQuery("Select * from ONLINE.business_assessment_dtl where applicationID = @aid")
            For Each r As DataRow In SQL.DBDT.Rows
                stracctexist = (r("accountno").ToString)

            Next
            If stracctexist = "" Then

                'insert ha assessment
                Dim strpath As String = "https:" + "//businessportalsub.tacloban.gov.ph/uploads/BUSINESS_APPLICATION"
                Dim inttotal As Decimal = lbltotal.Text
                Dim intamt As Decimal = lblamount.Text
                Dim intctc As Decimal = lblctc.Text

                SQL.AddParam("@intappid", intappid)
                SQL.AddParam("@acctno", straccountno)
                SQL.AddParam("@totalamt", inttotal)
                SQL.AddParam("@filename", strfilename)
                SQL.AddParam("@path", strpath)
                SQL.AddParam("@intuser", intuser)
                SQL.AddParam("@dt", dt_Appoinment.Value)
                SQL.AddParam("@taxamt", intamt)
                SQL.AddParam("@ctc", intctc)
                SQL.AddParam("@validity", validity.Value)
                SQL.AddParam("@ctcpdf", refCode + "_CTC_Assessment.pdf")

                SQL.ExecQuery("Insert into  ONLINE.business_assessment_dtl (validity, applicationID , accountno,Total_amt, assessment_pdf ,assess_path , assessed_timedt , user_assess,tax_amt,cedula_amt,cedula_pdf) " &
                              "values (@validity, @intappid, @acctno,@totalamt,@filename,@path, @dt, @intuser,@taxamt,@ctc,@ctcpdf)")

            Else
                Dim inttotal As Decimal = lbltotal.Text
                Dim intamt As Decimal = lblamount.Text
                Dim intctc As Decimal = lblctc.Text


                SQL.AddParam("@intappid", intappid)
                SQL.AddParam("@totalamt", inttotal)
                SQL.AddParam("@taxamt", intamt)
                SQL.AddParam("@ctc", intctc)


                SQL.AddParam("@dt", dt_Appoinment.Value)

                ' SQL.AddParam("@filename", strfilename)
                SQL.ExecQuery("update ONLINE.business_assessment_dtl set Total_amt = @totalamt , assessed_timedt = @dt , tax_amt = @taxamt , cedula_amt = @ctc where applicationID = @intappid  ")
            End If


            Try
                System.IO.File.Copy(FileToMove, MoveLocation)
            Catch ex As Exception

            End Try




            'sending kuno
            Dim f As New sending
            f.MdiParent = MainMenu
            f.Show()


        Else
            MessageBox.Show("Please upload a file", "NO FILE", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End If





    End Sub


    Public Sub loaddocdata()



        SQL.ExecQuery("Select * from ONLINE.business_attachment_m")
        For Each r As DataRow In SQL.DBDT.Rows
            Dim strattach As String = (r("attachmentCode"))
            Dim strattachname As String = (r("AttachmentDescription"))

            SQL.AddParam("@intappid", intappid)
            SQL.AddParam("@attachment", strattach)
            SQL.ExecQuery("Select * from ONLINE.business_application_tbl where applicationID = @intappid ")
            For Each r2 As DataRow In SQL.DBDT.Rows
                Dim strattach2 As String = (r2(strattach).ToString)
                If strattach2 = "" Then
                    'Do nothing
                Else
                    docgrid.Rows.Add(r2("applicationID"), r2(strattach).ToString, r("AttachmentDescription"), r2("RefCode"))
                End If
            Next

        Next

        ''Dim intid As Integer = 3

        'SQL.AddParam("@id", intappid)
        'SQL.ExecQuery("Select * from business_application_tbl where applicationID = @id ")
        'For Each r As DataRow In SQL.DBDT.Rows
        '    'unified form
        '    Dim strmyda As String = r("unified_form").ToString
        '    If strmyda <> "" Then
        '        docgrid.Rows.Add(r("applicationID"), r("unified_form"), "UNIFIED FORM")
        '    End If

        '    ''brgyclearance
        '    Dim strmyda2 As String = r("brgy_clearance").ToString
        '    If strmyda2 <> "" Then
        '        docgrid.Rows.Add(r("applicationID"), r("brgy_clearance"), "BRGY CLEARANCE")
        '    End If


        '    ''marketclearance
        '    Dim strmyda3 As String = r("market_clearance").ToString
        '    If strmyda3 <> "" Then
        '        docgrid.Rows.Add(r("applicationID"), r("market_clearance"), "MARKET CLEARANCE")
        '    End If

        'Next

        'docgrid.Sort(docgrid.Columns(2), System.ComponentModel.ListSortDirection.Ascending)
    End Sub
    Public Sub LoadAdmingrid()


        Dim btneval As New DataGridViewLinkColumn
        docgrid.Columns.Add(btneval)
        With btneval
            .HeaderText = "ACTION"
            .Width = 120
            .Name = "btneval"
            .Text = "View"
            .UseColumnTextForLinkValue = True


        End With

    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub docgrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles docgrid.CellContentClick
        Dim strprefix As String

        'SQL.ExecQuery("Select * from m_prefix_attachments ")
        'For Each r As DataRow In SQL.DBDT.Rows
        '    strprefix = r("PrefixURL")
        'Next


        strprefix = "\\10.0.27.194\FileAttachment\BUSINESS_APPLICATION\"


        'id tikang ha gridview
        Dim intappid2 As Integer = docgrid.CurrentRow.Cells(0).Value
        Dim intrecid As Integer
        Dim folder_dir As String

        'connect ha recordID na database gamit an APPID
        SQL.AddParam("@appid", intappid2)
        SQL.ExecQuery("select recordID from business_application_tbl where applicationID = @appid")

        For Each r2 As DataRow In SQL.DBDT.Rows
            intrecid = r2("recordID")
        Next

        'Kuhaa an folder directory gamit an recordID
        SQL.AddParam("@recid", intrecid)
        SQL.ExecQuery("Select folder_directory from business_record_hdr where recordID = @recid")

        For Each r As DataRow In SQL.DBDT.Rows
            folder_dir = r("folder_directory")
        Next

        'lblappid.Text = intappid.ToString

        ' CLick view

        If e.ColumnIndex = 4 Then

            'combine all strings to one link preee
            Dim link_string As String = strprefix & docgrid.CurrentRow.Cells(3).Value & "\" & docgrid.CurrentRow.Cells(1).Value



            Dim extension = System.IO.Path.GetExtension(link_string)

            If (extension = ".pdf") Then
                'MsgBox("pdf man ito doy")

                pdfviewer.Text = docgrid.CurrentRow.Cells(2).Value + " of Account : " + txtaccountno.Text + " _ " + docgrid.CurrentRow.Cells(1).Value

                pdfviewer.AxAcroPDF1.src = link_string
                pdfviewer.ShowDialog()
            Else

                Try
                    imageviewer.Text = docgrid.CurrentRow.Cells(2).Value + " of Account : " + txtaccountno.Text + " _ " + docgrid.CurrentRow.Cells(1).Value

                    imageviewer.PictureBox1.Image = Image.FromFile(link_string)
                    imageviewer.ShowDialog()
                Catch ex As Exception
                    MsgBox("Invalid Attachment or Attachment Not Found")
                End Try

            End If

        End If
    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Panel5.Paint

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)
  
    End Sub

    Private Sub txtamount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtamount.KeyPress

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtamount.TextChanged
        If txtamount.Text = Nothing Then
            lblamount.Text = "0.00"
            Exit Sub
        End If
        Dim stramt As Decimal = txtamount.Text
        If txtamount.Text.Length >= 4 Then
            lblamount.Text = Format((stramt), "0,000.00")
        ElseIf txtamount.Text.Length <= 3 Then
            lblamount.Text = Format((stramt), "0.00")
        End If

        getTOTAL()


    End Sub

    Private Sub txtamount2_TextChanged(sender As Object, e As EventArgs) Handles txtamount2.TextChanged
        If txtamount2.Text = Nothing Then
            lblamount2.Text = "0.00"
            Exit Sub
        End If
        Dim stramt As Decimal = txtamount2.Text
        If txtamount2.Text.Length >= 4 Then
            lblamount2.Text = Format((stramt), "0,000.00")
        ElseIf txtamount2.Text.Length <= 3 Then
            lblamount2.Text = Format((stramt), "0.00")
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub txtaccountno_Click(sender As Object, e As EventArgs) Handles txtaccountno.Click

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Public Sub getrecord()
        '   Dim Evaluator As Evaluator = CType(Application.OpenForms("Evaluator"), Evaluator)


        ' lblappid.Text = Evaluator.EvalGrid.CurrentRow.Cells(1).Value

        SQL.AddParam("@appid", intappid)
        SQL.ExecQuery("Select a.user_id, a.modeofpayment, a.refcode, a.recordid, a.businessname, a.businessline, a.applicationid , a.accountno, a.gross_dec, a.final_gross , c.track_status  from ONLINE.business_application_tbl a left join ONLINE.business_applicationstatus_dtl c on c.applicationID = a.applicationID where a.applicationid = @appid")
        For Each r As DataRow In SQL.DBDT.Rows
            lblbname.Text = (r("businessname"))
            lblbline.Text = (r("businessline"))
            txtaccountno.Text = (r("accountno"))
            txtaccountno.Text = straccountno
            lblgross.Text = (r("gross_dec"))
            refCode = (r("refcode"))
            modeofpayment.Text = (r("modeofpayment"))
            userid = (r("user_id"))
            ' txtgross.Text = (r("gross_dec"))
        Next

        '

    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub lblamount_TextChanged(sender As Object, e As EventArgs) Handles lblamount.TextChanged

    End Sub

    Private Sub btndeny_Click(sender As Object, e As EventArgs)
        denyrequest()
    End Sub



  

    Private Sub TabPage4_Click(sender As Object, e As EventArgs) Handles TabPage4.Click

    End Sub
    Public Sub loadremarks()

        '   Dim Evaluator As Evaluator = CType(Application.OpenForms("Evaluator"), Evaluator)
        ' Dim intid As Integer = Evaluator.EvalGrid.CurrentRow.Cells(1).Value

        SQL.AddParam("@id", intappid)
        SQL.ExecQuery("Select applicationID , verify_remarks, eval_remarks, assess_remarks , printed_remarks from business_applicationstatus_dtl where applicationID = @id ")
        For Each r As DataRow In SQL.DBDT.Rows
            'verify
            Dim strmyda As String = r("verify_remarks").ToString
            If strmyda <> "" Then
                RemarksGrid.Rows.Add(r("applicationID"), r("verify_remarks"), "BPLO REMARKS")
            End If

            ''eval
            Dim strmyda2 As String = r("eval_remarks").ToString
            If strmyda2 <> "" Then
                RemarksGrid.Rows.Add(r("applicationID"), r("eval_remarks"), "EVALUATOR")
            End If


            ''assess
            Dim strmyda3 As String = r("assess_remarks").ToString
            If strmyda3 <> "" Then
                RemarksGrid.Rows.Add(r("applicationID"), r("assess_remarks"), "ASSESSOR")
            End If

            Dim strmyda4 As String = r("printed_remarks").ToString
            If strmyda4 <> "" Then
                RemarksGrid.Rows.Add(r("applicationID"), r("printed_remarks"), "BPLO PERMIT")
            End If

        Next

        '   docgrid.Sort(docgrid.Columns(2), System.ComponentModel.ListSortDirection.Ascending)
    End Sub

    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        addremarks()
    End Sub
    Public Sub addremarks()

        Dim strrem As String = txtrem.Text
        SQL.AddParam("@id", intappid)
        SQL.AddParam("@rem", strrem)
        SQL.ExecQuery("update business_applicationstatus_dtl set assess_remarks = @rem where applicationID = @id")
        MessageBox.Show("Remarks Added!")
        RemarksGrid.Rows.Clear()
        loadremarks()
        txtrem.Clear()

    End Sub

    Private Sub btndeny_Click_1(sender As Object, e As EventArgs) Handles btndeny.Click
        denyrequest()
    End Sub


    Public Sub denyrequest()

        Dim MainMenu As MainMenu = CType(Application.OpenForms("MainMenu"), MainMenu)
        Dim Evaluator As Evaluator = CType(Application.OpenForms("Evaluator"), Evaluator)
        '   Dim intappid As Integer = lblappid.Text


        Dim userid As Integer
        Dim RefCode As String = ""
        SQL.AddParam("@appid", intappid)
        SQL.ExecQuery("select user_id, RefCode from ONLINE.business_application_tbl where applicationid = @appid")

        For Each r As DataRow In SQL.DBDT.Rows

            userid = (r("user_id").ToString)
            refCode = (r("RefCode").ToString)

        Next




        Dim intconfirm As Integer = MessageBox.Show("Are you sure you want to deny this request?", "CONFIRMATION", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If intconfirm = DialogResult.OK Then



            SQL.AddParam("@appid", intappid)
            SQL.AddParam("@datetime", DateTime.Now)
            SQL.AddParam("@userid", MainMenu.loginuserid)
            SQL.AddParam("@Denied_remarks", txtremarks.Text)

            SQL.ExecQuery("UPDATE ONLINE.business_applicationstatus_dtl SET admin_status = NULL, adminpassed_timedt = NULL, eval_status = NULL, eval_timedt= NULL, user_eval = NULL, assess_status= NULL, verify_status = 'D', user_deny =@userid, Denied_remarks=@Denied_remarks, verify_deny_dttime = @datetime WHERE applicationID= @appid")



            Dim fullname As String = ""
            Dim email As String = ""

            SQL.AddParam("@userid", userid)
            SQL.ExecQuery("Select Firstname,Email  from ONLINE.SysMngr WHERE UserID=@userid")
            For Each r As DataRow In SQL.DBDT.Rows

                fullname = (r("Firstname").ToString)
                email = (r("Email").ToString)

            Next

        
            SQL.AddParam("@referencecode", RefCode)

            SQL.AddParam("@accountno", txtaccountno.Text)
            SQL.AddParam("@Remarks", txtremarks.Text)
            SQL.AddParam("@email", email)
            SQL.AddParam("@fullname", fullname)
            SQL.AddParam("@datesend", DateTime.Now)
            SQL.AddParam("@userid", userid)
     
            SQL.ExecQuery("insert into ONLINE.email_outbox (accountno,Remarks,Sent,email,Subject, fullname,referencecode, datesend, userid ) " & _
                          "values(@accountno,@Remarks,0,@email,'Business Deny Application', @fullname, @referencecode , @datesend , @userid) ")

            If SQL.Exception <> "" Then
                MessageBox.Show(SQL.Exception, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            ''update email



            'Dim inttotalamt As Decimal = lbltotal.Text
            'Dim strloc As String = strfolder & strfilename
            'SQL.AddParam("@acctno", straccountno)
            'SQL.AddParam("@totalamt", inttotalamt)
            'SQL.AddParam("@filename", strfilename)
            'SQL.AddParam("@loc", strloc)
            'SQL.AddParam("@intuser", intuser)
            'SQL.AddParam("@email", stremail)
            'SQL.AddParam("@num", strnumber)
            'SQL.AddParam("@datesend", dt_Appoinment.Value)
            'SQL.ExecQuery("Insert into ONLINE.email_send (accountno_tdn,total_amount, FileDirectory ,user_send, email, attachment_type, phonenumber , datesend)" &
            '              "values (@acctno,@totalamt,@loc,@intuser,@email, 'BUSINESS_AS' , @num , @datesend)")




            ''checkboxess
            'Dim intgross As Integer
            'If Chkgross.Checked = True Then
            '    intgross = 1
            'Else
            '    intgross = 0
            'End If

            'Dim intitr As Integer
            'If ChkITR.Checked = True Then
            '    intitr = 1
            'Else
            '    intitr = 0
            'End If


            'Dim intoldfire As Integer
            'If chkoldfire.Checked = True Then
            '    intoldfire = 1
            'Else
            '    intoldfire = 0
            'End If

            'Dim intbrgyclearance As Integer
            'If chkbrgyc.Checked = True Then
            '    intbrgyclearance = 1
            'Else
            '    intbrgyclearance = 0
            'End If




            ''bago

            'Dim intmarketclearance As Integer
            'If Chkmarket.Checked = True Then
            '    intmarketclearance = 1
            'Else
            '    intmarketclearance = 0
            'End If

            'Dim intslaughter As Integer
            'If ChkSlaughter.Checked = True Then
            '    intslaughter = 1
            'Else
            '    intslaughter = 0
            'End If






            ''ITRnew
            'Dim intitr2 As Integer
            'If CHKitr2.Checked = True Then
            '    intitr2 = 1
            'Else
            '    intitr2 = 0
            'End If

            'Dim intitr3 As Integer
            'If CHKitr3.Checked = True Then
            '    intitr3 = 1
            'Else
            '    intitr3 = 0
            'End If

            'Dim intitr4 As Integer
            'If CHKitr4.Checked = True Then
            '    intitr4 = 1
            'Else
            '    intitr4 = 0
            'End If


            '  MsgBox("aaaaaaaaaaaaa")
          




            'ispending temp to 1
            'SQL.AddParam("@id", intappid)
            'SQL.ExecQuery("Update business_applicationstatus_dtl set IsPendingTemp = 1 where applicationID = @id")


            'SQL.AddParam("@appid", intappid)
            'SQL.AddParam("@dt", dt_Appoinment.Value)
            'SQL.ExecQuery("update business_applicationstatus_dtl set eval_status = 'D' , eval_deny_dttime = @dt where applicationID = @appid")


            '  Dim Evaluator As Evaluator = CType(Application.OpenForms("Evaluator"), Evaluator)
            '    Evaluator.EvalGrid.Rows.Clear()
            MessageBox.Show("Request Denied")


            Me.Close()
            MainMenu.btnassess.Enabled = True

        Else
            'do nothing
        End If


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub LinkLabel1_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        getTOTAL()

    End Sub

    Private Sub computebtn_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles computebtn.LinkClicked
        Dim f As New cedulacorp_assess
        f.MdiParent = MainMenu
        f.Show()


        Dim firstsring As String = txtaccountno.Text
        Dim cedulacorp_assess As cedulacorp_assess = CType(Application.OpenForms("cedulacorp_assess"), cedulacorp_assess)
        cedulacorp_assess.txtpre.Text = firstsring(0)
        cedulacorp_assess.txtaccount.Text = Strings.Right(firstsring, 5)

    End Sub
    Public Sub getTOTAL()
        Dim intamount As Decimal = lblamount.Text
        Dim intctc As Decimal = lblctc.Text


        lbltotal.Text = intamount + intctc
    End Sub

    Private Sub lblctc_TextChanged(sender As Object, e As EventArgs) Handles lblctc.TextChanged
        ' getTOTAL()

    End Sub

    Private Sub panelamt_Paint(sender As Object, e As PaintEventArgs) Handles panelamt.Paint

    End Sub

    Private Sub lblbname_Click(sender As Object, e As EventArgs) Handles lblbname.Click

    End Sub

    Private Sub AxAcroPDF1_Enter(sender As Object, e As EventArgs) Handles AxAcroPDF1.Enter

    End Sub

    Private Sub lblbline_Click(sender As Object, e As EventArgs) Handles lblbline.Click

    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click

    End Sub

    Private Sub txtrem_TextChanged(sender As Object, e As EventArgs) Handles txtrem.TextChanged

    End Sub
End Class