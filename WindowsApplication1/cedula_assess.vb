Imports MySql.Data.MySqlClient
Imports System.IO
Public Class cedula_assess
    Dim cedulareq As Cedulareq = CType(Application.OpenForms("cedulareq"), Cedulareq)
    Private intcedid As Integer = cedulareq.ctcGrid.CurrentRow.Cells(0).Value





    Private SQL As New sqlcontrol
    Private authuser As String


    Dim mRow As Integer = 0
    Dim newpage As Boolean = True
    Private Sub txttax1_AcceptsTabChanged(sender As Object, e As EventArgs) Handles txttax1.AcceptsTabChanged


    End Sub

    Private Sub txttax1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txttax1.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim intax1 As Decimal = txttax1.Text
            '    Dim intlimit10 As Decimal = txtlimit.Text
            Dim inttaxamt1 As Decimal = intax1 / 1000
            Dim intlimit As Decimal = txtlimit.Text





            If inttaxamt1 >= 5000 Then

                txttaxamt1.Text = intlimit
            Else
                txttaxamt1.Text = inttaxamt1
            End If




            ''txttaxamt1.Text = Format((inttaxamt1), "0.00")
            If txttax1.Text.Length >= 7 Then
                txttax1.Text = Format((intax1), "0,000.00")
            End If
        End If
            getTotal()

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


        Dim inttotal As Decimal = txttotal.Text
        Dim intinterest As Decimal = txtinterest.Text

        txtgrandtotal.Text = inttotal + intinterest

    End Sub

    Private Sub cedula_assess_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getTotal()
        getdata()
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

            SQL.AddParam("@cedid", intcedid)
            SQL.AddParam("@tax1", inttax1)
            SQL.AddParam("@taxamt1", inttaxamt1)
            SQL.AddParam("@totalamt", inttotal)
            SQL.AddParam("@grandtotal", intgrandtotal)
            SQL.ExecQuery("update business_ceduladetail_hdr set ced_taxableamt1 = @tax1 , ced_taxamt1 = @taxamt1 , ced_totalamt = @totalamt , ced_GRANDTOTAL = @grandtotal where ced_id = @cedid ")
        End If

        assessmentcedula_crpt.Show()


    End Sub

    Private Sub btnpreview_MouseLeave(sender As Object, e As EventArgs) Handles btnpreview.MouseLeave
        btnprevsmall.Visible = True
        btnpreview.Visible = False
    End Sub


    Public Sub getdata()
        SQL.AddParam("@cedid", intcedid)
        SQL.ExecQuery("Select * from business_ceduladetail_hdr a inner join business_cedulaapplication_hdr b on a.ced_id = b.ced_id where a.ced_id = @cedid")
        For Each r As DataRow In SQL.DBDT.Rows
            lbllastname.Text = (r("ced_lastname").ToString)
            lblfirstname.Text = (r("ced_firstname").ToString)
            lblmid.Text = (r("ced_midname").ToString)
            txtoccupation.Text = (r("ced_occupation").ToString)
            txtcompany.Text = (r("ced_company").ToString)
            lblid.Text = (r("ced_id"))
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()

        Dim f As New Cedulareq
        f.MdiParent = MainMenu
        f.Show()

    End Sub
    Public Sub loaddocdata()



        SQL.ExecQuery("Select * from cedula_attachment_m")
        For Each r As DataRow In SQL.DBDT.Rows
            Dim strattach As String = (r("attachmentCode"))
            Dim strattachname As String = (r("AttachmentDescription"))

            SQL.AddParam("@intappid", intcedid)
            SQL.AddParam("@attachment", strattach)
            SQL.ExecQuery("Select * from business_ceduladetail_hdr where ced_ID = @intappid ")
            For Each r2 As DataRow In SQL.DBDT.Rows
                Dim strattach2 As String = (r2(strattach).ToString)
                If strattach2 = "" Then
                    'Do nothing
                Else
                    docgrid.Rows.Add(r2("ced_ID"), r2(strattach).ToString, r("AttachmentDescription"))
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

    Private Sub docgrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles docgrid.CellContentClick
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
        SQL.AddParam("@recid", intcedid)
        SQL.ExecQuery("Select folder_directory from business_ceduladetail_hdr where ced_ID = @recid")

        For Each r As DataRow In SQL.DBDT.Rows
            folder_dir = r("folder_directory").ToString
        Next

        'lblappid.Text = intappid.ToString

        ' CLick view

        If e.ColumnIndex = 3 Then

            'combine all strings to one link preee
            Dim link_string As String = strprefix & folder_dir & docgrid.CurrentRow.Cells(1).Value



            Dim extension = System.IO.Path.GetExtension(link_string)

            If (extension = ".pdf") Then
                'MsgBox("pdf man ito doy")

                '      pdfviewer.Text = docgrid.CurrentRow.Cells(2).Value + " of Account : " + txtaccountno.Text + " _ " + docgrid.CurrentRow.Cells(1).Value

                pdfviewer.AxAcroPDF1.src = link_string
                pdfviewer.ShowDialog()
            Else

                Try
                    '    imageviewer.Text = docgrid.CurrentRow.Cells(2).Value + " of Account : " + txtaccountno.Text + " _ " + docgrid.CurrentRow.Cells(1).Value

                    imageviewer.PictureBox1.Image = Image.FromFile(link_string)
                    imageviewer.ShowDialog()
                Catch ex As Exception
                    MsgBox("Invalid Attachment or Attachment Not Found")
                End Try

            End If

        End If
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub
End Class