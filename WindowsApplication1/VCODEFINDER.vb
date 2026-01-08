
Imports MySql.Data.MySqlClient
Imports System.IO
Public Class VCODEFINDER


    Private SQL As New sqlcontrol3
    Private authuser As String



    Private Sub VCODEFINDER_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim strcode As String
        SQL.AddParam("@num", txtnum.Text)
        SQL.ExecQuery("Select * from t_registration where reg_moba = @num")
        For Each r As DataRow In SQL.DBDT.Rows

            strcode = (r("reg_verification"))
        
        Next
        If strcode = Nothing Then
            MessageBox.Show("Mobile Not found", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            txtcode.Text = strcode
        End If
    End Sub

    Private Sub txtnum_TextChanged(sender As Object, e As EventArgs) Handles txtnum.TextChanged
        txtcode.Text = "0000"
    End Sub
End Class