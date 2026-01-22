Imports MySql.Data.MySqlClient
Imports System.IO
Public Class cedulacorp_assess
    Dim cedulareq As Cedulareq = CType(Application.OpenForms("cedulareq"), Cedulareq)
    ' Private intcedid As Integer = cedulareq.ctcGrid.CurrentRow.Cells(0).Value





    Private SQL As New sqlcontrol2

    Private SQL2 As New sqlcontrolgeo
    Private authuser As String

    Public intbid As Integer
    Dim mRow As Integer = 0
    Dim newpage As Boolean = True
    Private Sub txttax1_AcceptsTabChanged(sender As Object, e As EventArgs) Handles txttax1.AcceptsTabChanged


    End Sub

    Private Sub txttax1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txttax1.KeyPress
        If e.KeyChar = Chr(13) Then
          
            If lbltype.Text = "1" Or lbltype.Text = "4" Then
                txtdue.Text = 5
                addgrosssolo()

            Else
                txtdue.Text = 500
                addgross()
            End If

        End If
     

    End Sub
    Private Sub txttax1_LostFocus(sender As Object, e As EventArgs) Handles txttax1.LostFocus


        'Dim intax1 As Decimal = txttax1.Text

        'txttaxamt1.Text = intax1 / 1000

        'Dim inttaxamt1 As Decimal = txttaxamt1.Text
        'If inttaxamt1 > 5000 Then
        '    txttaxamt1.Text = "5000.00"

        'End If


        ''   txttaxamt1.Text = Format((inttaxamt1), "0.00")
        'If txttax1.Text.Length >= 7 Then
        '    txttax1.Text = Format((intax1), "0,000.00")
        'End If

        'getTotal()

    End Sub


    Private Sub txttax1_TextChanged(sender As Object, e As EventArgs) Handles txttax1.TextChanged
        'formula
        'yearly income divide by 1000
        'plus due


    End Sub

    Public Sub getTotal()
        Dim intdue As Decimal = txtdue.Text
        Dim inttaxamt1 As Decimal = txttaxamt1.Text
        Dim inttaxamt2 As Decimal = txttaxamt2.Text
        Dim inttaxamt3 As Decimal = txttaxamt3.Text


        txttotal.Text = intdue + inttaxamt1 + inttaxamt2 + inttaxamt3
        Dim inttotalr As Decimal = txttotal.Text
        txttotal.Text = Math.Round([inttotalr], 2)

        'getinterest
        Dim strprcnt As String
        If CheckBox1.Checked = True Then
            strprcnt = "0.00"
          
        Else

            SQL2.ExecQuery("Select CTC_interest from georecords.dbo.ctcyear")
            For Each y As DataRow In SQL2.DBDT.Rows
                strprcnt = (y("CTC_interest").ToString)
            Next
        End If
      

        Dim interestamt As Decimal = txttotal.Text * strprcnt

        txtinterest.Text = Math.Round([interestamt], 2)
        'end





        Dim inttotal As Decimal = txttotal.Text
        Dim intinterest As Decimal = txtinterest.Text

        txtgrandtotal.Text = inttotal + intinterest
        Dim intgrandtotal As Decimal = txtgrandtotal.Text
        txtgrandtotal.Text = Math.Round([intgrandtotal], 2)

        If txtgrandtotal.Text.Length >= 7 Then
            txtgrandtotal.Text = Format((intgrandtotal), "0,000.00")
        End If

    End Sub

    Public Sub getTotalsingle()
        Dim intdueS As Decimal = txtdues1.Text
        Dim inttaxamt1 As Decimal = txttaxamts.Text
        Dim inttaxamt2 As Decimal = txttaxamt2.Text
        Dim inttaxamt3 As Decimal = txttaxamt3.Text


        txtgrandtotalS.Text = intdueS + inttaxamt1 + inttaxamt2 + inttaxamt3


        Dim inttotal As Decimal = txtgrandtotalS.Text
        Dim intinterest As Decimal = txtinterests.Text

        txtgrandtotalS.Text = inttotal + intinterest

    End Sub

    Private Sub cedula_assess_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getTotal()
        ' getdata()
        loaddocdata()
        LoadAdmingrid()


    End Sub

    Private Sub btnprevsmall_Click(sender As Object, e As EventArgs) Handles btnprevsmall.Click

    End Sub

    Private Sub btnprevsmall_MouseHover(sender As Object, e As EventArgs) Handles btnprevsmall.MouseHover
        btnprevsmall.Visible = False
        btnpreview.Visible = True
    End Sub

    Private Sub btnpreview_Click(sender As Object, e As EventArgs) Handles btnpreview.Click

        Dim intdue As Decimal = txtdue.Text

        Dim inttax1 As Decimal = txttax1.Text
        Dim inttaxamt1 As Decimal = txttaxamt1.Text



        Dim inttaxamt2 As Decimal = txttaxamt2.Text
        Dim inttaxamt3 As Decimal = txttaxamt3.Text


        Dim inttotal As Decimal = txttotal.Text
        Dim intinterest As Decimal = txtinterest.Text
        Dim intgrandtotal As Decimal = txtgrandtotal.Text
        Dim intconfirm As Integer = MessageBox.Show("Save Assessment ? ", "CONFIRMATION", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If intconfirm = DialogResult.OK Then

            'for MYSQL bportal
            '' SQL.AddParam("@cedid", intcedid)
            'SQL.AddParam("@acct", txtpre.Text + "-" + txtaccount.Text)
            'SQL.AddParam("@tax1", inttax1)
            'SQL.AddParam("@taxamt1", inttaxamt1)
            'SQL.AddParam("@totalamt", inttotal)
            'SQL.AddParam("@grandtotal", intgrandtotal)
            'SQL.ExecQuery("insert into business_ceduladetail_hdr set ced_accountno = @acct , ced_taxableamt1 = @tax1 , ced_taxamt1 = @taxamt1 , ced_totalamt = @totalamt , ced_GRANDTOTAL = @grandtotal ")
            ''for update
            ''SQL.ExecQuery("update business_ceduladetail_hdr set ced_accountno = @acct , ced_taxableamt1 = @tax1 , ced_taxamt1 = @taxamt1 , ced_totalamt = @totalamt , ced_GRANDTOTAL = @grandtotal where ced_id = @cedid ")


            'For Offline/Remote MSSQL
            ' SQL.AddParam("@cedid", intcedid)
            SQL2.AddParam("@acct", txtpre.Text + "-" + txtaccount.Text)
            SQL2.AddParam("@tax1", inttax1)
            SQL2.AddParam("@taxamt1", inttaxamt1)
            SQL2.AddParam("@totalamt", inttotal)
            SQL2.AddParam("@grandtotal", intgrandtotal)
            SQL2.ExecQuery("INSERT INTO  georecords.dbo.ceduladetail (ced_accountno,ced_taxableamt1,ced_taxamt1,ced_totalamt,ced_GRANDTOTAL) VALUES (@acct,@tax1,@taxamt1,@totalamt,@grandtotal)")
            '    'for update
            '    'SQL.ExecQuery("update business_ceduladetail_hdr set ced_accountno = @acct , ced_taxableamt1 = @tax1 , ced_taxamt1 = @taxamt1 , ced_totalamt = @totalamt , ced_GRANDTOTAL = @grandtotal where ced_id = @cedid ")



        End If

        assessmentcedula_crpt.Show()


    End Sub

    Private Sub btnpreview_MouseLeave(sender As Object, e As EventArgs) Handles btnpreview.MouseLeave
        btnprevsmall.Visible = True
        btnpreview.Visible = False
    End Sub


    Public Sub getdata()
        '  SQL.AddParam("@cedid", intcedid)
        SQL2.ExecQuery("Select * from business_ceduladetail_hdr a inner join business_cedulaapplication_hdr b on a.ced_id = b.ced_id where a.ced_id = @cedid")
        For Each r As DataRow In SQL.DBDT.Rows
            LBLBID.Text = (r("ced_lastname").ToString)
            lblbname.Text = (r("ced_firstname").ToString)
            lbladdress.Text = (r("ced_midname").ToString)
            ' txtoccupation.Text = (r("ced_occupation").ToString)
            'txtcompany.Text = (r("ced_company").ToString)
            lblid.Text = (r("ced_id"))
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        MainMenu.btnced.Enabled = True

        'Dim f As New Cedulareq
        'f.MdiParent = MainMenu
        'f.Show()

    End Sub
    Public Sub loaddocdata()



        SQL.ExecQuery("Select * from cedula_attachment_m")
        For Each r As DataRow In SQL.DBDT.Rows
            Dim strattach As String = (r("attachmentCode"))
            Dim strattachname As String = (r("AttachmentDescription"))

            ' SQL.AddParam("@intappid", intcedid)
            SQL.AddParam("@attachment", strattach)
            SQL.ExecQuery("Select * from business_ceduladetail_hdr where ced_ID = @intappid ")
            For Each r2 As DataRow In SQL.DBDT.Rows
                Dim strattach2 As String = (r2(strattach).ToString)
                If strattach2 = "" Then
                    'Do nothing
                Else
                    '  docgrid.Rows.Add(r2("ced_ID"), r2(strattach).ToString, r("AttachmentDescription"))
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
        '  docgrid.Columns.Add(btneval)
        With btneval
            .HeaderText = "ACTION"
            .Width = 120
            .Name = "btneval"
            .Text = "View"
            .UseColumnTextForLinkValue = True


        End With

    End Sub

    Private Sub docgrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
        Dim strprefix As String

        SQL.ExecQuery("Select * from m_prefix_attachments ")
        For Each r As DataRow In SQL.DBDT.Rows
            strprefix = r("PrefixURL")
        Next




        'id tikang ha gridview
        'Dim intappid2 As Integer = docgrid.CurrentRow.Cells(0).Value
        Dim intrecid As Integer
        Dim folder_dir As String

        'connect ha recordID na database gamit an APPID
        '   SQL.AddParam("@appid", intappid2)
        '  SQL.ExecQuery("select recordID from business_application_tbl where applicationID = @appid")

        '  For Each r2 As DataRow In SQL.DBDT.Rows
        'intrecid = r2("recordID")
        '  Next

        'Kuhaa an folder directory gamit an recordID
        'SQL.AddParam("@recid", intcedid)
        SQL.ExecQuery("Select folder_directory from business_ceduladetail_hdr where ced_ID = @recid")

        For Each r As DataRow In SQL.DBDT.Rows
            folder_dir = r("folder_directory").ToString
        Next

        'lblappid.Text = intappid.ToString

        ' CLick view

        'If e.ColumnIndex = 3 Then

        '    'combine all strings to one link preee
        '    Dim link_string As String = strprefix & folder_dir & docgrid.CurrentRow.Cells(1).Value



        '    Dim extension = System.IO.Path.GetExtension(link_string)

        '    If (extension = ".pdf") Then
        '        'MsgBox("pdf man ito doy")

        '        '      pdfviewer.Text = docgrid.CurrentRow.Cells(2).Value + " of Account : " + txtaccountno.Text + " _ " + docgrid.CurrentRow.Cells(1).Value

        '        pdfviewer.AxAcroPDF1.src = link_string
        '        pdfviewer.ShowDialog()
        '    Else

        '        Try
        '            '    imageviewer.Text = docgrid.CurrentRow.Cells(2).Value + " of Account : " + txtaccountno.Text + " _ " + docgrid.CurrentRow.Cells(1).Value

        '            imageviewer.PictureBox1.Image = Image.FromFile(link_string)
        '            imageviewer.ShowDialog()
        '        Catch ex As Exception
        '            MsgBox("Invalid Attachment or Attachment Not Found")
        '        End Try 

        '    End If

        'End If
    End Sub

    Private Sub txtpob_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtaddress_TextChanged(sender As Object, e As EventArgs) Handles Txt_Status.TextChanged

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click



        SQL.AddParam("@bact", txtpre.Text + "-" + txtaccount.Text)
        SQL.ExecQuery("Select * from ONLINE.business_application_tbl where accountno = @bact")
        If SQL.DBDT.Rows.Count = 0 Then

            Txt_Birthday.Text = "-"
            Txt_BirthPlace.Text = "-"
            Txt_Status.Text = "-"
        Else

            For Each r As DataRow In SQL.DBDT.Rows
                Txt_Birthday.Text = r("Birthdate").ToString()
                Txt_BirthPlace.Text = r("placeOfBirth").ToString()
                Txt_Status.Text = r("civilStatus").ToString()
            Next
        End If



        txttax1.Text = "0.00"
        SQL2.AddParam("@bacct", txtpre.Text + "-" + txtaccount.Text)
        SQL2.ExecQuery("Select * from GeoRecords.BPLS.businessrecord_hdr a inner join Georecords.bpls.aowner b on a.ownerid = b.ownerid where AccountNo = @bacct")
        For Each r As DataRow In SQL2.DBDT.Rows
            LBLBID.Text = r("BusinessId").ToString
            lblbname.Text = r("OwnerName").ToString
            lbladdress.Text = r("BusinessAddress").ToString
            lbltype.Text = r("BusinessTypeID").ToString
            txtbusiness.Text = r("Businessname").ToString

        Next



        If lbltype.Text = "1" Or lbltype.Text = "4" Then
            rdbsolo.Checked = True
            rdbcorp.Checked = False
        Else
            rdbcorp.Checked = True
            rdbsolo.Checked = False
        End If

        Dim stryearctc As String
        SQL2.ExecQuery("Select YearCTC from georecords.dbo.ctcyear")
        For Each y As DataRow In SQL2.DBDT.Rows
            stryearctc = (y("YearCTC").ToString)
        Next


        'ADJUST YEAR TO DABASE BASED
        SQL2.AddParam("@bid", LBLBID.Text)
        SQL2.AddParam("@yr", stryearctc)
        SQL2.ExecQuery("Select Top 1 * from GeoRecords.BPLS.BusinessDetail a inner join GeoRecords.BPLS.BusinessDetail_Renewal b on a.businessid = b.businessid where b.businessID = @bid and a.Year = @yr and b.year = @yr and a.MainLine = 1 order by Gross DESC")
        For Each r As DataRow In SQL2.DBDT.Rows
            txttax1.Text = (r("Gross").ToString)

            'Dim str2020 As Decimal = txttax1.Text

            'txttax1.Text = Format((str2020), "0,000.00")
            'If txttax1.Text = "0,000.00" Then
            '    txttax1.Text = "0"
            '  End If
            '  txttaxS.Text = txttax1.Text
        Next


        If lbltype.Text = "1" Or lbltype.Text = "4" Then
            txtdue.Text = 5
            addgrosssolo()

        Else
            txtdue.Text = 500
            addgross()
        End If


    End Sub
    Public Sub addgross()
        Dim intax1 As Decimal = txttax1.Text
        '    Dim intlimit10 As Decimal = txtlimit.Text
        Dim inttaxamt1 As Decimal = (intax1 / 5000) * 2
        Dim intlimit As Decimal = txtlimit.Text
        'Computation = monthly income x 12 /5000 x 2 + 500 :CORP





        If inttaxamt1 >= 10000 Then

            txttaxamt1.Text = intlimit
        Else
            txttaxamt1.Text = inttaxamt1
            Dim inttotalr As Decimal = txttaxamt1.Text
            txttaxamt1.Text = Math.Round([inttotalr], 2)




            ''txttaxamt1.Text = Format((inttaxamt1), "0.00")
            If txttax1.Text.Length >= 7 Then
                txttax1.Text = Format((intax1), "0,000.00")
              
            End If
        End If
        getTotal()
    End Sub
    Public Sub addgrosssolo()
        Dim intax1 As Decimal = txttax1.Text
        '    Dim intlimit10 As Decimal = txtlimit.Text



        Dim inttaxamt1 As Decimal = (intax1 / 1000)
        Dim intlimit As Decimal = 5000
        'Computation = monthly income x 12 /5000 x 2 + 500 :CORP





        If inttaxamt1 >= 5000 Then

            txttaxamt1.Text = intlimit

        ElseIf inttaxamt1 = 0 Then
            txttaxamt1.Text = 70
        Else
            txttaxamt1.Text = inttaxamt1
            Dim inttotalr As Decimal = txttaxamt1.Text
            txttaxamt1.Text = Math.Round([inttotalr], 2)



            ''txttaxamt1.Text = Format((inttaxamt1), "0.00")
            If txttax1.Text.Length >= 7 Then
                txttax1.Text = Format((intax1), "0,000.00")
            End If
        End If


        getTotal()
    End Sub




    'Public Sub addgrossSingle()
    '    Dim intax1 As Decimal = txttaxS.Text
    '    '    Dim intlimit10 As Decimal = txtlimit.Text
    '    Dim inttaxamt1 As Decimal = (intax1 / 1000)
    '    Dim intlimit As Decimal = 5000
    '    'Computation = monthly income x 12 /1000 x 1 + 5 :SINGLE





    '    If inttaxamt1 >= 5000 Then

    '        txttaxamts.Text = intlimit
    '    Else
    '        txttaxamts.Text = inttaxamt1




    '        ''txttaxamt1.Text = Format((inttaxamt1), "0.00")
    '        If txttaxS.Text.Length >= 7 Then
    '            txttaxS.Text = Format((intax1), "0,000.00")
    '        End If
    '    End If

    '    getTotalsingle()

    'End Sub

    Private Sub txtpre_TextChanged(sender As Object, e As EventArgs) Handles txtpre.TextChanged
        txtaccount.Focus()
        txtaccount.Clear()

    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub txttaxS_TextChanged(sender As Object, e As EventArgs) Handles txttaxS.TextChanged


    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        ' addgrossSingle()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        SQL2.AddParam("@bacct", txtpreS.Text + "-" + txtaccountS.Text)
        SQL2.ExecQuery("Select * from GeoRecords.BPLS.businessrecord_hdr where AccountNo = @bacct")
        For Each r As DataRow In SQL2.DBDT.Rows
            lblidS.Text = r("BusinessId").ToString
            lblbnameS.Text = r("BusinessName").ToString
            lbladdressS.Text = r("BusinessAddress").ToString

        Next




        'ADJUST YEAR TO DABASE BASED
        SQL2.AddParam("@bid", lblidS.Text)
        SQL2.AddParam("@yr", 2022)
        SQL2.ExecQuery("Select Top 1 * from GeoRecords.BPLS.BusinessDetail a inner join GeoRecords.BPLS.BusinessDetail_Renewal b on a.businessid = b.businessid where b.businessID = @bid and a.Year = @yr and b.year = @yr and a.MainLine = 1 order by Gross DESC")
        For Each r As DataRow In SQL2.DBDT.Rows
            txttaxS.Text = (r("Gross").ToString)

            'Dim str2020 As Decimal = txttax1.Text

            'txttax1.Text = Format((str2020), "0,000.00")
            'If txttax1.Text = "0,000.00" Then
            '    txttax1.Text = "0"
            '  End If
            '  txttaxS.Text = txttax1.Text
        Next
        '   addgrossSingle()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles rdbcorp.CheckedChanged

    End Sub







    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged




        getTotal()




    End Sub

    Private Sub txtaccount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtaccount.KeyPress






        If e.KeyChar = Chr(13) Then

            txttax1.Text = "0.00"
            SQL2.AddParam("@bacct", txtpre.Text + "-" + txtaccount.Text)
            SQL2.ExecQuery("Select * from GeoRecords.BPLS.businessrecord_hdr a inner join Georecords.bpls.aowner b on a.ownerid = b.ownerid where AccountNo = @bacct")
            For Each r As DataRow In SQL2.DBDT.Rows
                LBLBID.Text = r("BusinessId").ToString
                lblbname.Text = r("OwnerName").ToString
                lbladdress.Text = r("BusinessAddress").ToString
                lbltype.Text = r("BusinessTypeID").ToString
                txtbusiness.Text = r("Businessname").ToString


            Next


            If lbltype.Text = "1" Or lbltype.Text = "4" Then
                rdbsolo.Checked = True
                rdbcorp.Checked = False
            Else
                rdbcorp.Checked = True
                rdbsolo.Checked = False
            End If

            Dim stryearctc As String
            SQL2.ExecQuery("Select YearCTC from georecords.dbo.ctcyear")
            For Each y As DataRow In SQL2.DBDT.Rows
                stryearctc = (y("YearCTC").ToString)
            Next


            'ADJUST YEAR TO DABASE BASED
            SQL2.AddParam("@bid", LBLBID.Text)
            SQL2.AddParam("@yr", stryearctc)
            SQL2.ExecQuery("Select Top 1 * from GeoRecords.BPLS.BusinessDetail a inner join GeoRecords.BPLS.BusinessDetail_Renewal b on a.businessid = b.businessid where b.businessID = @bid and a.Year = @yr and b.year = @yr and a.MainLine = 1 order by Gross DESC")
            For Each r As DataRow In SQL2.DBDT.Rows
                txttax1.Text = (r("Gross").ToString)

                'Dim str2020 As Decimal = txttax1.Text

                'txttax1.Text = Format((str2020), "0,000.00")
                'If txttax1.Text = "0,000.00" Then
                '    txttax1.Text = "0"
                '  End If
                '  txttaxS.Text = txttax1.Text
            Next


            If lbltype.Text = "1" Or lbltype.Text = "4" Then
                txtdue.Text = 5
                addgrosssolo()

            Else
                txtdue.Text = 500
                addgross()
            End If


        End If


    End Sub

    Private Sub txtaccount_TextChanged(sender As Object, e As EventArgs) Handles txtaccount.TextChanged

    End Sub
End Class