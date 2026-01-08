Imports CrystalDecisions.Shared
Public Class assessmentcedula_crpt
    Dim cedulacorp_assess As cedulacorp_assess = CType(Application.OpenForms("cedulacorp_assess"), cedulacorp_assess)
    '  Private intcedid As Integer = cedula_assess.lblid.Text
    Private inttaxableamt As Decimal = cedulacorp_assess.txttax1.Text
    Private inttaxamt As Decimal = cedulacorp_assess.txttaxamt1.Text
    Private intsubamt As Decimal = cedulacorp_assess.txttotal.Text
    Private intinterest As Decimal = cedulacorp_assess.txtinterest.Text
    Public intgrandtotal As String = cedulacorp_assess.txtgrandtotal.Text
    Private strbname As String = cedulacorp_assess.lblbname.Text
    Private straddress As String = cedulacorp_assess.lbladdress.Text
    Dim RPT As New assessmentcedula

    Private Sub assessmentcedula1_InitReport(sender As Object, e As EventArgs) Handles assessmentcedula1.InitReport

    End Sub

    Private Sub CrystalReportViewer1_Load(sender As Object, e As EventArgs) Handles CrystalReportViewer1.Load
        GetReport()

    End Sub


    Public Sub GetReport()


        Dim rpt As New assessmentcedula
        rpt.Load(Application.StartupPath & "\assessmentcedula.rpt")



        Dim pfields As New ParameterFields

        Dim pfieldID As New ParameterField
        Dim pdiscreteID As New ParameterDiscreteValue

        Dim pfieldtax1 As New ParameterField
        Dim pdiscretetax1 As New ParameterDiscreteValue

        Dim pfieldamt As New ParameterField
        Dim pdiscreteamt As New ParameterDiscreteValue

        Dim pfieldsubamt As New ParameterField
        Dim pdiscretesubamt As New ParameterDiscreteValue

        Dim pfieldintamt As New ParameterField
        Dim pdiscreteintamt As New ParameterDiscreteValue

        Dim pfieldgamt As New ParameterField
        Dim pdiscretegamt As New ParameterDiscreteValue

        Dim pfieldbname As New ParameterField
        Dim pdiscretebname As New ParameterDiscreteValue

        Dim pfieldaddress As New ParameterField
        Dim pdiscreteaddress As New ParameterDiscreteValue

        pfieldID.Name = "CEDID"
        pdiscreteID.Value = 1
        pfieldID.CurrentValues.Add(pdiscreteID)
        pfields.Add(pfieldID)


        pfieldtax1.Name = "taxableamt"
        pdiscretetax1.Value = inttaxableamt
        pfieldtax1.CurrentValues.Add(pdiscretetax1)
        pfields.Add(pfieldtax1)

        pfieldamt.Name = "amt"
        pdiscreteamt.Value = inttaxamt
        pfieldamt.CurrentValues.Add(pdiscreteamt)
        pfields.Add(pfieldamt)

        pfieldsubamt.Name = "subtotalamt"
        pdiscretesubamt.Value = intsubamt
        pfieldsubamt.CurrentValues.Add(pdiscretesubamt)
        pfields.Add(pfieldsubamt)

        pfieldintamt.Name = "interestamt"
        pdiscreteintamt.Value = intinterest
        pfieldintamt.CurrentValues.Add(pdiscreteintamt)
        pfields.Add(pfieldintamt)

        pfieldgamt.Name = "grandtotalamt"
        pdiscretegamt.Value = intgrandtotal
        pfieldgamt.CurrentValues.Add(pdiscretegamt)
        pfields.Add(pfieldgamt)

        pfieldbname.Name = "bname"
        pdiscretebname.Value = strbname
        pfieldbname.CurrentValues.Add(pdiscretebname)
        pfields.Add(pfieldbname)

        pfieldaddress.Name = "baddress"
        pdiscreteaddress.Value = straddress
        pfieldaddress.CurrentValues.Add(pdiscreteaddress)
        pfields.Add(pfieldaddress)




        'Dim user As String = "usera2"
        'Dim pass As String = "passa2"
        'Dim srvr As String = "10.0.14.117"
        'Dim dtabase As String = "Bankrecords"
        ' rpt.SetDatabaseLogon("usera2", "passa2", "10.0.14.117", "businessportal", True)
        CrystalReportViewer1.ReportSource = rpt
        CrystalReportViewer1.ParameterFieldInfo = pfields




    End Sub

    Private Sub assessmentcedula_crpt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetReportdirect()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim Assessment As Assessment = CType(Application.OpenForms("Assessment"), Assessment)


        Try
            '  Dim rpt1 As New assessmentcedula
            Dim straccount As String = Assessment.refCode
            Dim strpretext As String = "\\10.0.27.194\FileAttachment\BUSINESS_APPLICATION\"
            Dim strfilename As String = straccount + "_CTC_Assessment.pdf"


            Dim CrExportOptions As ExportOptions
            Dim CrDiskFileDestinationOptions As New  _
            DiskFileDestinationOptions()
            Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
            CrDiskFileDestinationOptions.DiskFileName = _
                                      strpretext & straccount & "\" & strfilename
            CrExportOptions = RPT.ExportOptions
            With CrExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.PortableDocFormat
                .DestinationOptions = CrDiskFileDestinationOptions
                .FormatOptions = CrFormatTypeOptions
            End With
            RPT.Export()

            Assessment.lblctc.Text = intgrandtotal
            Assessment.lblctcfile.Text = strfilename
            Assessment.getTOTAL()


        Catch ex As Exception

            MsgBox(ex.ToString)
        End Try
        MessageBox.Show("Saved Successfully")
        cedulacorp_assess.Close()


        Me.Close()


    End Sub

    Public Sub GetReportdirect()



        RPT.PrintOptions.ApplyPageMargins(New CrystalDecisions.Shared.PageMargins(200, 200, 200, 200))


        Dim TxtBnameCR As CrystalDecisions.CrystalReports.Engine.TextObject = RPT.ReportDefinition.Sections(3).ReportObjects("txtbnameCR")
        Dim TxtaddressCR As CrystalDecisions.CrystalReports.Engine.TextObject = RPT.ReportDefinition.Sections(3).ReportObjects("TxtaddressCR")
        Dim TxttaxCR As CrystalDecisions.CrystalReports.Engine.TextObject = RPT.ReportDefinition.Sections(3).ReportObjects("txttaxableCR")
        Dim TxttaxamtCR As CrystalDecisions.CrystalReports.Engine.TextObject = RPT.ReportDefinition.Sections(3).ReportObjects("TxttaxamtCR")
        Dim TxtsubtotalCR As CrystalDecisions.CrystalReports.Engine.TextObject = RPT.ReportDefinition.Sections(3).ReportObjects("TxtsubtotalCR")
        Dim TxtinterestCR As CrystalDecisions.CrystalReports.Engine.TextObject = RPT.ReportDefinition.Sections(3).ReportObjects("TxtinterestCR")
        Dim TxtgrandtotalCR As CrystalDecisions.CrystalReports.Engine.TextObject = RPT.ReportDefinition.Sections(3).ReportObjects("TxtgrandtotalCR")
        Dim TxtacctCR As CrystalDecisions.CrystalReports.Engine.TextObject = RPT.ReportDefinition.Sections(3).ReportObjects("TxtacctCR")
        Dim TxtdueCR As CrystalDecisions.CrystalReports.Engine.TextObject = RPT.ReportDefinition.Sections(3).ReportObjects("TxtdueCR")


        TxtBnameCR.Text = strbname
        TxtaddressCR.Text = straddress
        TxttaxCR.Text = inttaxableamt.ToString("N")
        TxttaxamtCR.Text = inttaxamt.ToString("N")
        TxtsubtotalCR.Text = intsubamt
        TxtinterestCR.Text = intinterest
        TxtgrandtotalCR.Text = intgrandtotal
        TxtacctCR.Text = cedulacorp_assess.txtpre.Text + " - " + cedulacorp_assess.txtaccount.Text
        TxtdueCR.Text = cedulacorp_assess.txtdue.Text

        CrystalReportViewer1.ReportSource = RPT


    End Sub
End Class