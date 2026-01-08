Public Class sending


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Timer1.Stop()
        Me.Close()
        MessageBox.Show("Attachment Sent to email", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Dim f1 As New Assessment
        'f1.MdiParent = MainMenu
        'f1.Close()

        'Dim f2 As New Assessor
        'f2.MdiParent = MainMenu
        'f2()
    End Sub

    Private Sub sending_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Timer1.Start()
        Timer1.Interval = 5200
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class