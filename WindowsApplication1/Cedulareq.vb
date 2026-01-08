
Imports MySql.Data.MySqlClient
Imports System.IO

Public Class Cedulareq
    Private SQL As New sqlcontrol
    Private authuser As String

    Private loginuserid As Integer = LogIn.lblid.Text
    Dim mRow As Integer = 0
    Dim newpage As Boolean = True
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        MainMenu.btnced.Enabled = True

    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub




    Public Sub loaddata()
        ' Sql.addparam("")
        SQL.ExecQuery("Select * from business_ceduladetail_hdr a inner join business_cedulaapplication_hdr b on a.ced_id = b.ced_id")
        For Each r As DataRow In SQL.DBDT.Rows
            ctcGrid.Rows.Add(r("ced_id"), r("ced_applicationID"), r("ced_fullname"), r("ced_company"), r("ced_occupation"), r("ced_income"))
        Next
    End Sub

    Private Sub Cedulareq_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loaddata()
        LoadAdmingrid()


    End Sub

    Public Sub LoadAdmingrid()


        Dim btneval As New DataGridViewButtonColumn
        ctcGrid.Columns.Add(btneval)
        With btneval
            .HeaderText = "ACTION"
            .Width = 130
            .Name = "btneval"
            .Text = "Generate Assessment"
            .UseColumnTextForButtonValue = True


        End With




    End Sub

    Private Sub ctcGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles ctcGrid.CellContentClick
        If e.RowIndex = -1 Then
            Exit Sub
            'ElseIf e.RowIndex <> 0 Then
            '    MessageBox.Show("Please prioritize requests according to queue", "CANNOT EVALUATE", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '    Exit Sub
        End If


        If e.ColumnIndex = 6 Then
            '  lblappid.Text = ctcGrid.CurrentRow.Cells(1).Value
            Dim f As New cedula_assess
            f.MdiParent = MainMenu
            f.Show()
            Me.Hide()

        End If
    End Sub
End Class