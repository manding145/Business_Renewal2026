Imports MySql.Data.MySqlClient
Imports System.IO



Imports System.Data
Imports System.Data.SqlClient
Public Class Evaluation

    Dim Evaluator As Evaluator = CType(Application.OpenForms("Evaluator"), Evaluator)
    Private intappid As Integer = Evaluator.EvalGrid.CurrentRow.Cells(1).Value



    Private intuser As Integer = LogIn.lblid.Text

    Private SQL As New sqlcontrol2
    Private authuser As String



    Private SQL2 As New sqlcontrol4
    Private authuser2 As String


    Dim mRow As Integer = 0
    Dim newpage As Boolean = True


    Dim mRow2 As Integer = 0
    Dim newpage2 As Boolean = True

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
        Dim f As New Evaluator
        f.MdiParent = MainMenu
        f.Show()

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub CheckBox8_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Evaluation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadassesspending()
        getrecord()
        loaddocdata()
        LoadAdmingrid()
        fillassessbox()
        loadremarks()
        getgross()
    End Sub
    Public Sub loadassesspending()


        ' Sql.AddParam("@admin", "ADMIN")
        SQL.AddParam("@eval", "ASSESSOR")
        SQL.ExecQuery("Select system_userid,Full_name from ONLINE.business_users where  user_position = @eval")

        For Each r As DataRow In SQL.DBDT.Rows
            Dim intid As Integer = r("system_userid")
            Dim strname As String = r("Full_name")

            SQL.AddParam("@id", intid)
            SQL.ExecQuery("Select count(ApplicationID) as Pending from ONLINE.business_applicationstatus_dtl where user_assess = @id and assess_status = 'P' and eval_status = 'V' ")
            For Each r2 As DataRow In SQL.DBDT.Rows
                assesspending.Rows.Add(r("system_userid"), r("Full_name"), r2("Pending"))
            Next
        Next



        assesspending.Sort(assesspending.Columns(2), System.ComponentModel.ListSortDirection.Descending)
    End Sub

    Private Sub chkdeny_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Public Sub LoadAdmingrid()

        Dim btneval As New DataGridViewLinkColumn
        docgrid.Columns.Add(btneval)
        With btneval
            .HeaderText = "ACTION"
            .Width = 150

            .Name = "btneval"
            .Text = "View"
            .UseColumnTextForLinkValue = True

        End With

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
                    docgrid.Rows.Add(r2("applicationID"), r2(strattach).ToString, r("AttachmentDescription"))
                End If
            Next

        Next

        'Dim Evaluator As Evaluator = CType(Application.OpenForms("Evaluator"), Evaluator)
        'Dim intid As Integer = Evaluator.EvalGrid.CurrentRow.Cells(1).Value

        'SQL.AddParam("@id", intid)
        'SQL.ExecQuery("Select * from business_application_tbl where applicationID = @id ")
        'For Each r As DataRow In SQL.DBDT.Rows
        '    'unified form
        '    Dim strmyda As String = r("unified_form").ToString
        '    If strmyda <> "" Then
        '        
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

        '   docgrid.Sort(docgrid.Columns(2), System.ComponentModel.ListSortDirection.Ascending)

    End Sub


    Private Sub docgrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles docgrid.CellContentClick
        'Dim strprefix As String
        'SQL.ExecQuery("Select * from m_prefix_attachments ")
        'For Each r As DataRow In SQL.DBDT.Rows
        '    strprefix = r("PrefixURL")
        'Next


        Dim strprefix As String
        'SQL.ExecQuery("Select PrefixURL from ONLINE.m_prefix_attachments ")
        'For Each prefix As DataRow In SQL.DBDT.Rows
        '    strprefix = (prefix("PrefixURL").ToString)
        'Next

        strprefix = "\\10.0.27.194\FileAttachment\BUSINESS_APPLICATION\" & referencecode.Text & "\"
        'MoveLocation = "\\10.0.27.194\FileAttachment\" & strfolder & strfilename

        'id tikang ha gridview
        Dim intappid2 As Integer = docgrid.CurrentRow.Cells(0).Value
        Dim intrecid As Integer
        Dim folder_dir As String

        'connect ha recordID na database gamit an APPID
        SQL.AddParam("@appid", intappid2)
        SQL.ExecQuery("select recordID from ONLINE.business_application_tbl where applicationID = @appid")

        For Each r2 As DataRow In SQL.DBDT.Rows
            intrecid = r2("recordID")
        Next

        'Kuhaa an folder directory gamit an recordID
        'SQL.AddParam("@recid", intrecid)
        'SQL.ExecQuery("Select folder_directory from ONLINE.business_record_hdr where recordID = @recid")

        'For Each r As DataRow In SQL.DBDT.Rows
        '    folder_dir = r("folder_directory")
        'Next

        'lblappid.Text = intappid.ToString

        ' CLick view

        If e.ColumnIndex = 3 Then

            'combine all strings to one link preee
            Dim link_string As String = strprefix & docgrid.CurrentRow.Cells(1).Value



            Dim extension = System.IO.Path.GetExtension(link_string)

            If (extension = ".pdf") Then
                'MsgBox("pdf man ito doy")

                'maam lyndyonly
                ' Process.Start(link_string)

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

    Public Sub getrecord()
        Dim Evaluator As Evaluator = CType(Application.OpenForms("Evaluator"), Evaluator)


        lblappid.Text = Evaluator.EvalGrid.CurrentRow.Cells(1).Value

        SQL.AddParam("@appid", intappid)
        SQL.ExecQuery("Select a.recordid, a.RefCode, a.businessname, a.applicationid , a.accountno,a.final_gross, a.gross_dec, a.businessline, c.track_status , a.b_itr4 from ONLINE.business_application_tbl a " &
                      "left join ONLINE.business_applicationstatus_dtl c on a.applicationID = c.applicationID where a.applicationid = @appid")
        For Each r As DataRow In SQL.DBDT.Rows
            lblbname.Text = (r("businessname"))
            lblbline.Text = (r("businessline"))
            txtaccountno.Text = (r("accountno"))

            If (r("gross_dec").ToString() = "") Then
                txtgross.Text = "0"
            Else
                txtgross.Text = (r("gross_dec"))
            End If

            referencecode.Text = r("RefCode")

            Dim strq4 As Decimal = If(IsDBNull(r("b_itr4")), 0D, Convert.ToDecimal(r("b_itr4")))
            'Dim strq4 As Integer = (r("b_itr4").ToString)
            Dim intfinal As Decimal = If(IsDBNull(r("final_gross")), 0D, Convert.ToDecimal(r("final_gross")))

            If intfinal = 0.0 Then
                Dim intgross As Decimal = txtgross.Text
                txtevalgross.Text = Format((intgross), "0,000.00")
            Else
                txtevalgross.Text = Format((intfinal), "0,000.00")
            End If

            txtq4.Text = Format((strq4), "0,000.00")
        Next

    End Sub

    Private Sub btndeny_Click(sender As Object, e As EventArgs)
        denyrequest()

    End Sub


    Public Sub denyrequest()

        Dim Evaluator As Evaluator = CType(Application.OpenForms("Evaluator"), Evaluator)
        '   Dim intappid As Integer = lblappid.Text

        SQL.AddParam("@appid", intappid)
        SQL.ExecQuery("select applicationID from ONLINE.business_denytemp where applicationid = @appid")

        For Each r As DataRow In SQL.DBDT.Rows
            Dim intappexist As String = (r("applicationID").ToString)


            If intappexist <> "" Then
                MessageBox.Show("This application is already denied")
                Exit Sub

            End If
        Next

        Dim intconfirm As Integer = MessageBox.Show("Are you sure you want to deny this request?", "CONFIRMATION", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If intconfirm = DialogResult.OK Then




            'checkboxess
            Dim intgross As Integer
            If Chkgross.Checked = True Then
                intgross = 1
            Else
                intgross = 0
            End If

            Dim intitr As Integer
            If ChkITR.Checked = True Then
                intitr = 1
            Else
                intitr = 0
            End If


            Dim intoldfire As Integer
            If chkoldfire.Checked = True Then
                intoldfire = 1
            Else
                intoldfire = 0
            End If

            Dim intbrgyclearance As Integer
            If chkbrgyc.Checked = True Then
                intbrgyclearance = 1
            Else
                intbrgyclearance = 0
            End If




            'bago

            Dim intmarketclearance As Integer
            If Chkmarket.Checked = True Then
                intmarketclearance = 1
            Else
                intmarketclearance = 0
            End If

            Dim intslaughter As Integer
            If ChkSlaughter.Checked = True Then
                intslaughter = 1
            Else
                intslaughter = 0
            End If






            'ITRnew
            Dim intitr2 As Integer
            If CHKitr2.Checked = True Then
                intitr2 = 1
            Else
                intitr2 = 0
            End If

            Dim intitr3 As Integer
            If CHKitr3.Checked = True Then
                intitr3 = 1
            Else
                intitr3 = 0
            End If

            Dim intitr4 As Integer
            If CHKitr4.Checked = True Then
                intitr4 = 1
            Else
                intitr4 = 0
            End If


            '  MsgBox("aaaaaaaaaaaaa")
            SQL.AddParam("@appidd", intappid)
            SQL.AddParam("@uf", "0")
            SQL.AddParam("@gross", intgross)
            SQL.AddParam("@itr", intitr)
            SQL.AddParam("@oldfire", intoldfire)
            SQL.AddParam("@brgyc", intbrgyclearance)
            SQL.AddParam("@user", intuser)
            SQL.AddParam("@dt", dt_Appoinment.Value)
            SQL.AddParam("@type", "E")
            SQL.AddParam("@market", intmarketclearance)
            SQL.AddParam("@slaughter", intslaughter)
            SQL.AddParam("@remarks", txtremarks.Text)
            SQL.AddParam("@itr2", intitr2)
            SQL.AddParam("@itr3", intitr3)
            SQL.AddParam("@itr4", intitr4)
            SQL.ExecQuery("insert into ONLINE.business_denytemp (applicationID,unifiedform_islacking,deny_status,itr1_islacking,gross_islacking, old_fire_IsLacking,deny_dt, user_id , type_deny ,Market_isLacking, Slaughter_isLacking, remarks, brgy_clearance_IsLacking, itr2_islacking , itr3_islacking , itr4_islacking) " &
                          "values(@appidd,@uf,'P',@itr,@gross, @oldfire, @dt , @user , @type, @market, @slaughter , @remarks, @brgyc , @itr2,@itr3,@itr4) ")




            'ispending temp to 1
            SQL.AddParam("@id", intappid)
            SQL.ExecQuery("Update business_applicationstatus_dtl set IsPendingTemp = 1 where applicationID = @id")


            'SQL.AddParam("@appid", intappid)
            'SQL.AddParam("@dt", dt_Appoinment.Value)
            'SQL.ExecQuery("update business_applicationstatus_dtl set eval_status = 'D' , eval_deny_dttime = @dt where applicationID = @appid")


            '  Dim Evaluator As Evaluator = CType(Application.OpenForms("Evaluator"), Evaluator)
            '    Evaluator.EvalGrid.Rows.Clear()
            MessageBox.Show("Request Denied")


            Me.Close()
            MainMenu.btneval.Enabled = True

        Else
            'do nothing
        End If


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        addremarks()

    End Sub


    Private Sub Checkgross_CheckedChanged(sender As Object, e As EventArgs) Handles Checkgross.CheckedChanged
        If Checkgross.Checked = False Then
            txtevalgross.Enabled = True


        ElseIf Checkgross.Checked = True Then
            txtevalgross.Enabled = False

        End If
    End Sub

    Private Sub txtgross_TextChanged(sender As Object, e As EventArgs) Handles txtgross.TextChanged


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Dim intappid As Integer = Evaluator.EvalGrid.CurrentRow.Cells(1).Value
        lblcb.Text = cbassess.SelectedValue
        lblappid.Text = intappid
        Dim intevalgross As String = txtevalgross.Text
        SQL.AddParam("@user", lblcb.Text)
        SQL.AddParam("@appid", intappid)
        SQL.AddParam("@evalstat", "V")
        SQL.AddParam("@assessstat", "P")
        SQL.AddParam("@timeforwarded", dt_Appoinment.Value)
        SQL.ExecQuery("update ONLINE.business_applicationstatus_dtl set eval_status = @evalstat, assess_status = @assessstat , user_assess = @user, eval_timedt = @timeforwarded where applicationID = @appid")


        SQL.AddParam("@appid", intappid)
        SQL.AddParam("@evalgross", intevalgross)
        SQL.ExecQuery("Update ONLINE.business_application_tbl set final_gross = @evalgross where ApplicationID = @appid")




        MessageBox.Show("Evaluated Successfully")

        Me.Close()
        Dim f As New Evaluator
        f.MdiParent = MainMenu
        f.Show()

    End Sub

    Private Sub txtaccountno_Click(sender As Object, e As EventArgs) Handles txtaccountno.Click

    End Sub


    Public Sub fillassessbox()



        SQL.AddParam("@admin", "ADMIN")
        SQL.AddParam("@eval", "ASSESSOR")
        SQL.ExecQuery("Select system_userid, Full_name From ONLINE.business_users where user_position = @eval ")
        SQL.bsource.DataSource = SQL.DBDT
        cbassess.DataSource = SQL.bsource
        cbassess.ValueMember = ("system_userid")
        cbassess.DisplayMember = ("Full_name")



        ' cbassess.DataSource
        '   cbassess.ValueMember = r("system_userid")

        ' Next










    End Sub

    Private Sub btndeny_Click_1(sender As Object, e As EventArgs) Handles btndeny.Click
        denyrequest()

    End Sub

    Private Sub Panel7_Paint(sender As Object, e As PaintEventArgs) Handles Panel7.Paint


    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles txtremarks.TextChanged

    End Sub

    Private Sub txtevalgross_TextChanged(sender As Object, e As EventArgs) Handles txtevalgross.TextChanged
        'If txtevalgross.Text = Nothing Then
        '    txtgross2.Text = 0
        '    Exit Sub
        'End If
        'Dim stramt As Decimal = txtevalgross.Text
        'If txtevalgross.Text.Length >= 4 Then
        '    txtgross2.Text = Format((stramt), "0,000.00")
        'ElseIf txtevalgross.Text.Length <= 3 Then
        '    txtgross2.Text = Format((stramt), "0.00")
        'End If
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

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

    Private Sub RemarksGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles RemarksGrid.CellContentClick

    End Sub
    Public Sub addremarks()

        Dim strrem As String = Txtrem.Text
        SQL.AddParam("@id", intappid)
        SQL.AddParam("@rem", strrem)
        SQL.ExecQuery("update business_applicationstatus_dtl set eval_remarks = @rem where applicationID = @id")
        MessageBox.Show("Remarks Added!")
        RemarksGrid.Rows.Clear()
        loadremarks()
        Txtrem.Clear()
    End Sub

    Private Sub CHKitr4_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles assesspending.CellContentClick

    End Sub


    Public Sub getgross()

        Dim stract As String = txtaccountno.Text
        SQL2.AddParam("@act", stract)
        SQL2.ExecQuery("Select * from GeoRecords.BPLS.BusinessRecord_HDR where AccountNo = @act ")
        For Each r2 As DataRow In SQL2.DBDT.Rows
            lblbid.Text = (r2("BusinessID"))
        Next

        'get 2021
        SQL2.AddParam("@bid", lblbid.Text)
        'YEAR ON DATABASE
        Dim last2years As Integer = DateTime.Now.Year - 2

        SQL2.AddParam("@yr", last2years)
        SQL2.ExecQuery("Select Top 1 * from GeoRecords.BPLS.BusinessDetail a inner join GeoRecords.BPLS.BusinessDetail_Renewal b on a.businessid = b.businessid where b.businessID = @bid and a.Year = @yr and b.year = @yr and a.MainLine = 1 order by Gross DESC")
        For Each r As DataRow In SQL2.DBDT.Rows
            txt2019.Text = (r("Gross"))


            Dim str2019 As Decimal = txt2019.Text
            txt2019.Text = Format((str2019), "0,000.00")

            If txt2019.Text = "0,000.00" Then
                txt2019.Text = "0"
            End If

        Next




        'get2022
        SQL2.AddParam("@bid", lblbid.Text)
        'ADJUST YEAR TO DABASE BASED
        Dim previousyear As Integer = DateTime.Now.Year - 1
        SQL2.AddParam("@yr", previousyear)
        SQL2.ExecQuery("Select Top 1 * from GeoRecords.BPLS.BusinessDetail a inner join GeoRecords.BPLS.BusinessDetail_Renewal b on a.businessid = b.businessid where b.businessID = @bid and a.Year = @yr and b.year = @yr and a.MainLine = 1 order by Gross DESC")
        For Each r As DataRow In SQL2.DBDT.Rows
            txt2020.Text = (r("Gross").ToString)

            Dim str2020 As Decimal = txt2020.Text

            txt2020.Text = Format((str2020), "0,000.00")
            If txt2020.Text = "0,000.00" Then
                txt2020.Text = "0"
            End If
        Next


        lblprvs.Text = "Gross " + previousyear.ToString + ":"
        lblprvs2.Text = "Gross " + last2years.ToString + ":"
    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Panel5.Paint

    End Sub
End Class