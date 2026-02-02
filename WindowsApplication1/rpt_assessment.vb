Imports MySql.Data.MySqlClient
Imports System.IO

Public Class rpt_assessment
    Private SQL As New sqlcontrol2
    Private sqlMY As New sqlcontrol
    Private authuser As String
    Dim rpt_Assessor As rpt_assessor = CType(Application.OpenForms("rpt_Assessor"), rpt_assessor)
    Private straccountno As String = rpt_Assessor.rptgrid.CurrentRow.Cells(2).Value
    Private strfname As String = rpt_Assessor.rptgrid.CurrentRow.Cells(3).Value
    Private intappid As String = rpt_Assessor.rptgrid.CurrentRow.Cells(1).Value
    'Private intappid2 As String = Casso.rptgrid.CurrentRow.Cells(1).Value


    Private intuser As Integer = LogIn.lblid.Text

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Me.Close()
        Dim f2 As New rpt_assessor
        f2.MdiParent = MainMenu
        f2.Show()
    End Sub

    Private Sub rpt_assessment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getrecord()

    End Sub

    Private Sub btnemail_Click(sender As Object, e As EventArgs) Handles btnemail.Click
        If txtamount.Text <> txtamount2.Text Then
            MessageBox.Show("Amount does not match")
            Exit Sub
        End If


        Dim FileToMove As String
        Dim MoveLocation As String

        '  SQL.AddParam("")
        Dim strfilename As String = straccountno + "_Assessment.pdf"
        FileToMove = txtdirec.Text


        Sql.AddParam("@acct", straccountno)
        Dim strfolder As String
        Dim strnumber As String
        SQL.ExecQuery("select * from ONLINE.rpt_record_hdr where TDN_no = @acct ")
        For Each r As DataRow In Sql.DBDT.Rows
            strfolder = (r("folder_directory"))
            strnumber = (r("contact"))
        Next


        Dim strprefix As String
        SQL.ExecQuery("Select PrefixURL from ONLINE.m_prefix_attachments ")
        For Each prefix As DataRow In Sql.DBDT.Rows
            strprefix = (prefix("PrefixURL").ToString)
        Next

        MoveLocation = strprefix & strfolder & strfilename





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
            Dim stremail As String
            Sql.AddParam("@acct", straccountno)
            SQL.ExecQuery("Select * from ONLINE.rpt_record_hdr where TDN_no = @acct")
            For Each r As DataRow In Sql.DBDT.Rows
                stremail = (r("email_add").ToString)
            Next


            ' insert ha email_sender
            Dim inttotalamt As Decimal = lblamount.Text
            Dim strloc As String = strfolder & strfilename
            'SQL.AddParam("@intappid", intappid)
            sqlMY.AddParam("@acctno", straccountno)
            sqlMY.AddParam("@totalamt", inttotalamt)
            sqlMY.AddParam("@filename", strfilename)
            sqlMY.AddParam("@loc", strloc)
            sqlMY.AddParam("@intuser", intuser)
            sqlMY.AddParam("@email", stremail)
            sqlMY.AddParam("@num", strnumber)
            sqlMY.AddParam("@datesend", dt_Appoinment.Value)
            sqlMY.ExecQuery("Insert into email_send (accountno_tdn,total_amount, FileDirectory ,user_send, email,attachment_type,phonenumber, datesend,Status)" &
                          "values (@acctno,@totalamt,@loc,@intuser,@email, 'RPT_AS', @num, @datesend,0 )")

            'update it status ha applicationstatus
            SQL.AddParam("@intappid", intappid)
            Sql.AddParam("@dt", dt_Appoinment.Value)
            SQL.AddParam("@totalamt", inttotalamt)
            SQL.ExecQuery("update ONLINE.rpt_application set casso_status = 'V',admin_status = 'V' ,assess_status = 'V', payment_status = 'P' ,assess_timedt = @dt ,total_amt = @totalamt  where rpt_applicationID = @intappid")




            'update it amount ha application
            'Sql.AddParam("@intappid", intappid)
            'Sql.AddParam("@totalamt", txtamount.Text)
            'SQL.ExecQuery("update business_application_tbl set amountToPay = @totalamt where ced_applicationID = @intappid")






            'if exists
            Dim stracctexist As String
            SQL.AddParam("@aid", straccountno)
            SQL.ExecQuery("Select * from ONLINE.rpt_assessment_dtl where TDN = @aid")
            For Each r As DataRow In SQL.DBDT.Rows
                stracctexist = (r("TDN").ToString)
            Next


            If stracctexist = "" Then


                'insert ha assessment
                Dim strpath As String = "https:" + "//businessportalsub.tacloban.gov.ph/uploads/RPT"
                Dim inttotal As Decimal = lblamount.Text

                SQL.AddParam("@intappid", intappid)
                SQL.AddParam("@tdn", straccountno)
                SQL.AddParam("@totalamt", inttotal)
                SQL.AddParam("@filename", strfilename)
                SQL.AddParam("@path", strpath)
                SQL.AddParam("@intuser", intuser)
                SQL.AddParam("@dt", dt_Appoinment.Value)
                SQL.ExecQuery("Insert into  ONLINE.rpt_assessment_dtl (rpt_applicationID , TDN,Total_amt, assessment_pdf ,assess_path , assessed_timedt , user_assess) " &
                              "values (@intappid, @tdn,@totalamt,@filename,@path, @dt, @intuser)")

            Else
                Dim inttotal As Decimal = lblamount.Text
                SQL.AddParam("@tdn", straccountno)
                SQL.AddParam("@totalamt", inttotal)

                SQL.AddParam("@dt", dt_Appoinment.Value)
                ' SQL.AddParam("@filename", strfilename)
                SQL.ExecQuery("update ONLINE.rpt_assessment_dtl set Total_amt = @totalamt , assessed_timedt = @dt where TDN = @tdn  ")

            End If
            Try
                System.IO.File.Copy(FileToMove, MoveLocation)
            Catch ex As Exception
                MsgBox(Err)

            End Try




            'sending kuno with animation
            'Dim f As New sending
            'f.MdiParent = MainMenu
            'f.Show()

            MessageBox.Show("REAL PROPERTY ASSESSMENT SENT SUCCESSFULLY!", "SUCCESS")

        Else
            MessageBox.Show("Please upload a file", "NO FILE", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End If





    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

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




        ' AxAcroPDF1.setView("Fit")
    End Sub

    Private Sub txtamount_TextChanged(sender As Object, e As EventArgs) Handles txtamount.TextChanged
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


    Public Sub getrecord()
        '   Dim Evaluator As Evaluator = CType(Application.OpenForms("Evaluator"), Evaluator)


        ' lblappid.Text = Evaluator.EvalGrid.CurrentRow.Cells(1).Value

        SQL.AddParam("@appid", intappid)
        SQL.ExecQuery("select * from ONLINE.rpt_application a inner join ONLINE.rpt_record_hdr b on a.TDN_no = b.TDN_no where rpt_applicationid = @appid")
        For Each r As DataRow In SQL.DBDT.Rows

            lblbname.Text = If(IsDBNull(r("Owner_Name")), String.Empty, r("Owner_Name").ToString())
            lblbnature.Text = If(IsDBNull(r("Location")), String.Empty, r("Location").ToString())
            txtaccountno.Text = If(IsDBNull(r("TDN_no")), String.Empty, r("TDN_no").ToString())
            lbladdress.Text = If(IsDBNull(r("Owner_Address")), String.Empty, r("Owner_Address").ToString())
            LblPin.Text = If(IsDBNull(r("email_add")), String.Empty, r("email_add").ToString())
            txtaccountno.Text = If(String.IsNullOrEmpty(straccountno), String.Empty, straccountno)

            ' txtgross.Text = (r("gross_dec"))
        Next




    End Sub



    Private Sub btndeny_Click(sender As Object, e As EventArgs) Handles btndeny.Click
        denyrequest()

    End Sub


    Public Sub denyrequest()
        SQL.AddParam("@appid", intappid)
        SQL.ExecQuery("update rpt_application set assess_status = 'D' where rpt_applicationID = @appid")


        MessageBox.Show("Request Denied")
        Me.Close()
        rpt_Assessor.Close()

        MainMenu.btnrptassess.Enabled = True




        Dim stremail As String
        SQL.AddParam("@acct", straccountno)
        SQL.ExecQuery("Select * from rpt_record_hdr where TDN_no = @acct")
        For Each r As DataRow In SQL.DBDT.Rows
            stremail = (r("email_add").ToString)





        Next


        Dim strremarks As String = txtrmrks.Text

        SQL.AddParam("@acctn", straccountno)
        SQL.AddParam("@fname", strfname)
        SQL.AddParam("@email", stremail)
        SQL.AddParam("@denydt", dt_Appoinment.Value)
        SQL.AddParam("@remarks", "Your Request is Denied :" + " yeah " + strremarks)
        SQL.AddParam("@atype", "Deny_rpt")

        SQL.ExecQuery("Insert into email_deny_application (AccountID,fullname,email,DenyDateTime,Remarks,attachment_type)" & _
                      "Values (@acctn,@fname,@email,@denydt,@remarks,@atype)")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim MoveLocation2 As String
        Dim strfilefolder As String
        Dim strfiletomove2 As String
        ' SQL.ExecQuery("select * from rpt_assessment_dtl")
        SQL.ExecQuery("select * from business_assessment_dtl")
        For Each r As DataRow In SQL.DBDT.Rows
            'strfilefolder = r("TDN").ToString
            strfilefolder = r("accountno").ToString


            strfiletomove2 = "D:\reattach\" & strfilefolder & ".pdf"
            MoveLocation2 = "\\10.0.27.194\FileAttachment\BUSINESS\" & strfilefolder & "\" & strfilefolder & "_Assessment.pdf"
            'MoveLocation2
            If System.IO.File.Exists(strfiletomove2) = True Then

                If System.IO.File.Exists(MoveLocation2) Then
                    System.IO.File.Delete(MoveLocation2)
                    ' System.IO.File.Copy(strfiletomove2, MoveLocation2)
                    'donothing


                End If
                ' System.IO.File.Delete(MoveLocation2)
                System.IO.File.Copy(strfiletomove2, MoveLocation2)
            Else
                'donothing
            End If
                txtdirec.Text = MoveLocation2
        Next
        MessageBox.Show("ok")
    End Sub

    Private Sub txtdirec_Click(sender As Object, e As EventArgs) Handles txtdirec.Click

    End Sub

    Private Sub AxAcroPDF1_Enter(sender As Object, e As EventArgs) Handles AxAcroPDF1.Enter
        AxAcroPDF1.setView("FitV")
    End Sub
End Class