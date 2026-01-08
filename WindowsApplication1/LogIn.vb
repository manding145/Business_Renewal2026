Imports MySql.Data.MySqlClient
Imports Tulpep.NotificationWindow
Public Class LogIn
    Dim drag, drag1 As Boolean

    Private SQL As New sqlcontrol2
    Private authuser As String


    Dim mRow As Integer = 0
    Dim newpage As Boolean = True



    Private Sub LogIn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txt_username.Text = My.Settings.setusername
        txt_password.Text = My.Settings.setpassword

        If My.Settings.setusername = "" And My.Settings.setpassword = "" Then
            With txt_username
                .SelectionStart = .TextLength
                .SelectionLength = 0
                .SelectionStart = 0
                .ScrollToCaret()
            End With

            With txt_password
                .SelectionStart = .TextLength
                .SelectionLength = 0
                .SelectionStart = 0
                .ScrollToCaret()
            End With
            txt_username.ForeColor = Color.Gray
            txt_password.ForeColor = Color.Gray
        Else
            txt_username.ForeColor = Color.Black
            txt_password.ForeColor = Color.Black
        End If


    End Sub

    Private Sub txt_password_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_password.KeyDown
        With txt_password
            If .Text = "Password" And .ForeColor = Color.Gray Then
                If e.KeyCode = Keys.Right Or e.KeyCode = Keys.Left Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.Home Then
                    e.Handled = True
                End If

            End If
        End With
    End Sub

    Private Sub txt_password_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_password.KeyPress
        'If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
        '    Try
        '        Con = New SqlConnection(cs)
        '        Con.Open()
        '        conn = "SELECT  * FROM sysmngr where Username='" & txt_username.Text & "' and Password='" & txt_password.Text & "'"

        '        cmd = New SqlCommand(conn, Con)
        '        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
        '        If rdr.Read = True Then
        '            If chckRemMe.Checked = True Then
        '                My.Settings.setusername = txt_username.Text
        '                My.Settings.setpassword = txt_password.Text
        '                My.Settings.Save()
        '            Else
        '                My.Settings.setusername = ""
        '                My.Settings.setpassword = ""
        '                My.Settings.Save()
        '            End If
        '            'userid = rdr("UserID")
        '            ''MainMenu.lbl_UserFirstname.Text = rdr("Fullname")
        '            'userfullname = rdr("Fullname")
        '            lblfname1 = rdr("Fullname")
        '            lbluserrole1 = rdr("Userlevel")
        '            'link_prefix = rdr("link_prefix")
        '            'myemail = rdr("email")

        '            'MainForm.lblfname.Text = rdr("Fullname")
        '            'MainForm.lbluserrole.Text = rdr("Userlevel")
        '            userid = rdr("UserID")
        '            Con.Close()
        '            MainMenu.Show()
        '            Me.Hide()
        '        Else
        '            MsgBox("Invalid Username or Password", vbOKOnly & vbExclamation, "Tacloban City Health Office Management System")
        '        End If

        '        Con.Close()
        '    Catch ex As Exception
        '        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End Try


        'Else
        'End If
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)
        'ConnectionConfiguration.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles BtnLogin.Click
        
        loginuser()


        'Try
        '    Con = New SqlConnection(cs)
        '    con.Open()
        '    conn = "SELECT  * FROM sysmngr where Username='" & txt_username.Text & "' and Password='" & txt_password.Text & "'"

        '    cmd = New SqlCommand(conn, Con)
        '    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
        '    If rdr.Read = True Then
        '        If chckRemMe.Checked = True Then
        '            My.Settings.setusername = txt_username.Text
        '            My.Settings.setpassword = txt_password.Text
        '            My.Settings.Save()
        '        Else
        '            My.Settings.setusername = ""
        '            My.Settings.setpassword = ""
        '            My.Settings.Save()
        '        End If
        '        'userid = rdr("UserID")
        '        ''MainMenu.lbl_UserFirstname.Text = rdr("Fullname")
        '        'userfullname = rdr("Fullname")
        '        lblfname1 = rdr("Fullname")
        '        lbluserrole1 = rdr("Userlevel")
        '        'link_prefix = rdr("link_prefix")
        '        'myemail = rdr("email")

        '        'MainForm.lblfname.Text = rdr("Fullname")
        '        'MainForm.lbluserrole.Text = rdr("Userlevel")
        '        userid = rdr("UserID")
        '        con.Close()
        '        MainMenu.Show()
        '        Me.Hide()
        '    Else
        '        MsgBox("Invalid Username or Password", vbOKOnly & vbExclamation, "Tacloban City Health Office Management System")
        '    End If

        '    con.Close()
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try







    End Sub

    Private Sub txt_password_MouseDown(sender As Object, e As MouseEventArgs) Handles txt_password.MouseDown
        drag1 = True
        With txt_password
            If .Text = "Password" And .ForeColor = Color.Gray Then
                .SelectionStart = .TextLength
                .SelectionLength = 0
                .SelectionStart = 0
                .ScrollToCaret()

            End If

        End With
    End Sub

    Private Sub txt_password_MouseMove(sender As Object, e As MouseEventArgs) Handles txt_password.MouseMove
        If drag1 Then
            With txt_password
                If .Text = "Password" And .ForeColor = Color.Gray Then
                    .Select(0, 0)
                End If
            End With


        End If
    End Sub

    Private Sub txt_password_TextChanged(sender As Object, e As EventArgs) Handles txt_password.TextChanged
        With txt_password
            If .Text = "" Then
                .Text = "Password"
                .ForeColor = Color.Gray
            End If
            If .Text = "Password" And .ForeColor = Color.Gray Then
                .ShortcutsEnabled = False
                .UseSystemPasswordChar = False
            Else
                .ShortcutsEnabled = True
                .UseSystemPasswordChar = True
            End If

            If .TextLength > 8 Then
                If StrReverse(StrReverse(.Text).Remove(8)) = "Password" Then
                    .Text = .Text.Remove(.TextLength - 8)
                    .ForeColor = Color.Black
                    .SelectionStart = .TextLength
                    .ScrollToCaret()
                    .UseSystemPasswordChar = True
                End If
            End If
        End With
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        'ConnectionConfiguration.ShowDialog()
    End Sub

    Private Sub txt_username_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_username.KeyDown
        With txt_username

            If .Text = "Username" And .ForeColor = Color.Gray Then
                If e.KeyCode = Keys.Right Or e.KeyCode = Keys.Left Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.Home Then
                    e.Handled = True
                End If

            End If
        End With
    End Sub

    Private Sub txt_username_MouseDown(sender As Object, e As MouseEventArgs) Handles txt_username.MouseDown
        drag = True
        With txt_username
            If .Text = "Username" And .ForeColor = Color.Gray Then
                .SelectionStart = .TextLength
                .SelectionLength = 0
                .SelectionStart = 0
                .ScrollToCaret()

            End If

        End With
    End Sub

    Private Sub txt_username_MouseMove(sender As Object, e As MouseEventArgs) Handles txt_username.MouseMove
        If drag Then
            With txt_username
                If .Text = "Username" And .ForeColor = Color.Gray Then
                    .Select(0, 0)
                End If
            End With


        End If
    End Sub

    Private Sub txt_username_TextChanged(sender As Object, e As EventArgs) Handles txt_username.TextChanged
        With txt_username
            If .Text = "" Then
                .Text = "Username"
                .ForeColor = Color.Gray
            End If
            If .Text = "Username" And .ForeColor = Color.Gray Then
                .ShortcutsEnabled = False
            Else
                .ShortcutsEnabled = True
            End If

            If .TextLength > 8 Then
                If StrReverse(StrReverse(.Text).Remove(8)) = "Username" Then
                    .Text = .Text.Remove(.TextLength - 8)
                    .ForeColor = Color.Black
                    .SelectionStart = .TextLength
                    .ScrollToCaret()
                End If
            End If
        End With
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        ConnectionConfiguration.ShowDialog()
    End Sub


    Public Sub loginuser()
        Dim intuserid As Integer
        SQL.AddParam("@username", txt_username.Text)
        SQL.AddParam("@password", txt_password.Text)
        SQL.ExecQuery("Select system_userid , user_name , password, user_position,full_name from ONLINE.business_users where user_name = @username and password = @password")
        For Each r As DataRow In SQL.DBDT.Rows
            intuserid = (r("system_userid").ToString)
            lblid.Text = (r("system_userid").ToString)
            lblpos.Text = (r("user_position").ToString)
            lblfullname.Text = (r("full_name").ToString)
        Next



        If intuserid = Nothing Then
            MessageBox.Show("Invalid username or password")
        Else



            Me.Hide()
            MainMenu.Show()

        End If
    End Sub
End Class