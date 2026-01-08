
Imports MySql.Data.MySqlClient

Public Class rpt_assessor
    Private SQL As New sqlcontrol2
    Private authuser As String

    Private intuser As Integer = LogIn.lblid.Text
    Dim mRow As Integer = 0
    Dim newpage As Boolean = True
    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    'para kun ibalik an damu na office an ma tira
    'Public Sub loadrptdata()


    '    Panelp.BackColor = Color.LightCoral
    '    Panelas.BackColor = Color.WhiteSmoke
    '    rptgrid.Rows.Clear()
    '    rptgrid.Columns(5).HeaderText = "OWNER ADDRESS"

    '    SQL.AddParam("@stat", "P")
    '    SQL.AddParam("@userid", intuser)
    '    SQL.ExecQuery("select * from ONLINE.rpt_application a inner join ONLINE.rpt_record_hdr b on a.TDN_no = b.TDN_no where assess_status = @stat and  user_assess = @userid order by Time_passed ")
    '    For Each r As DataRow In SQL.DBDT.Rows
    '        rptgrid.Rows.Add(r("rptrecord_id"), r("rpt_applicationid"), r("TDN_no"), r("owner_name"), r("ARP"), r("Owner_address"))
    '    Next



    'End Sub

    Public Sub loadrptdata()


        Panelp.BackColor = Color.LightCoral
        Panelas.BackColor = Color.WhiteSmoke
        rptgrid.Rows.Clear()
        rptgrid.Columns(5).HeaderText = "OWNER ADDRESS"

        SQL.AddParam("@stat", "P")
        SQL.AddParam("@userid", intuser)
        SQL.ExecQuery("select * from ONLINE.rpt_application a inner join ONLINE.rpt_record_hdr b on a.TDN_no = b.TDN_no where (assess_status is null or assess_status = @stat) order by Application_timedt ")
        For Each r As DataRow In SQL.DBDT.Rows
            rptgrid.Rows.Add(r("rptrecord_id"), r("rpt_applicationid"), r("TDN_no"), r("owner_name"), r("ARP"), r("Owner_address"))
        Next



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        MainMenu.btnrptassess.Enabled = True
    End Sub

    Private Sub rpt_assessor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rptgrid.Rows.Clear()

        loadrptdata()
        LoadAdmingrid()

    End Sub
    Public Sub LoadAdmingrid()


        Dim btneval As New DataGridViewButtonColumn
        rptgrid.Columns.Add(btneval)
        With btneval

            .HeaderText = "ACTION"
            .Width = 60
            .Name = "btneval"

            .Text = "ASSESS"

            .UseColumnTextForButtonValue = True


        End With






        Dim btndone As New DataGridViewButtonColumn
        rptgrid.Columns.Add(btndone)
        With btndone

            .HeaderText = "DONE"
            .Width = 60
            .Name = "btneval"

            .Text = "DONE"

            .UseColumnTextForButtonValue = True


        End With
    End Sub

    Private Sub rptgrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles rptgrid.CellContentClick
        If e.ColumnIndex = 7 Then
            '    lblappid.Text = EvalGrid.CurrentRow.Cells(1).Value
            Dim f As New rpt_assessment
            f.MdiParent = MainMenu
            f.Show()
            Me.Hide()
        End If



        If e.ColumnIndex = 8 Then
            Dim intconfirm As Integer = MessageBox.Show("This request will be removed from list, continue?", "CONFIRMATION", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            If intconfirm = DialogResult.OK Then
                Dim intrptid As Integer = rptgrid.CurrentRow.Cells(1).Value
                SQL.AddParam("@rptid", intrptid)
                SQL.ExecQuery("update ONLINE.rpt_application set assess_status = 'DONE' where rpt_applicationid = @rptid")
                rptgrid.Rows.Clear()
                loadrptdata()

            End If
        End If
    End Sub

    Private Sub cmb_appointmentstatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_appointmentstatus.SelectedIndexChanged
        If cmb_appointmentstatus.SelectedIndex = 0 Then
            rptgrid.Rows.Clear()
            loadrptdata()
        ElseIf cmb_appointmentstatus.SelectedIndex = 1 Then
            LoadDoneData()
        End If
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        If cmb_appointmentstatus.SelectedIndex = 0 Then
            rptgrid.Rows.Clear()
            loadrptdata()
        Else
            cmb_appointmentstatus.SelectedIndex = 0
        End If
    End Sub

    Public Sub LoadDoneData()


        Panelas.BackColor = Color.LightCoral
        Panelp.BackColor = Color.WhiteSmoke
        rptgrid.Rows.Clear()

        rptgrid.Columns(5).HeaderText = "AMOUNT"

        SQL.AddParam("@stat", "V")
        SQL.AddParam("@userid", intuser)
        SQL.ExecQuery("select * from rpt_application a inner join rpt_record_hdr b on a.TDN_no = b.TDN_no where assess_status = @stat and  user_assess = @userid order by assess_timedt desc")
        For Each r As DataRow In SQL.DBDT.Rows
            rptgrid.Rows.Add(r("rptrecord_id"), r("rpt_applicationid"), r("TDN_no"), r("owner_name"), r("Location"), r("Total_amt"))
        Next
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        'rptgrid.Rows.Clear()
        cmb_appointmentstatus.SelectedIndex = 1
        '  LoadAdmingrid()

    End Sub


    'Public Sub LoadAdmingridre()
    '    '    rptgrid.Columns(6).


    '    Dim btneval As New DataGridViewButtonColumn
    '    rptgrid.Columns.Add(btneval)
    '    With btneval

    '        .HeaderText = "ACTION"
    '        .Width = 120
    '        .Name = "btneval"

    '        .Text = "RE-ASSESS"

    '        .UseColumnTextForButtonValue = True


    '    End With
    'End Sub

    Private Sub timerpending_Tick(sender As Object, e As EventArgs) Handles timerpending.Tick
        selectpending()
        dt_Appoinment.Value = Date.Now()


    End Sub


    Public Sub selectpending()

        'pending
        SQL.AddParam("@stat", "P")
        SQL.AddParam("@userid", intuser)
        SQL.ExecQuery("select count(rpt_applicationid) as pcount from ONLINE.rpt_application where (assess_status is null or assess_status = @stat)")
        For Each r As DataRow In SQL.DBDT.Rows
            lbl_countpending.Text = (r("pcount"))
        Next

        'done
        SQL.AddParam("@stat", "V")
        SQL.AddParam("@userid", intuser)
        SQL.ExecQuery("select count(rpt_applicationid) as pcount from ONLINE.rpt_application where assess_status = @stat  and user_assess = @userid")
        For Each r As DataRow In SQL.DBDT.Rows
            lblcountissued.Text = (r("pcount"))
        Next
    End Sub

    Private Sub Panelas_Paint(sender As Object, e As PaintEventArgs) Handles Panelas.Paint

    End Sub

    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click
        rptgrid.Rows.Clear()
        loadrptdata()
        selectpending()

    End Sub

    Private Sub BtnSearchRecord_Click(sender As Object, e As EventArgs) Handles BtnSearchRecord.Click
        rptgrid.Rows.Clear()

        loadrptdatasearch()
        ' LoadAdmingrid()
    End Sub


    Public Sub loadrptdatasearch()


        Panelp.BackColor = Color.LightCoral
        Panelas.BackColor = Color.WhiteSmoke
        rptgrid.Rows.Clear()
        rptgrid.Columns(5).HeaderText = "OWNER ADDRESS"

        SQL.AddParam("@stat", "P")
        SQL.AddParam("@tdn", "%" + txt_name.Text + "%")
        SQL.AddParam("@userid", intuser)
        SQL.ExecQuery("select * from ONLINE.rpt_application a inner join ONLINE.rpt_record_hdr b on a.TDN_no = b.TDN_no where (assess_status is null or assess_status = @stat)  and a.TDN_no LIKE @tdn ")
        For Each r As DataRow In SQL.DBDT.Rows
            rptgrid.Rows.Add(r("rptrecord_id"), r("rpt_applicationid"), r("TDN_no"), r("owner_name"), r("ARP"), r("Owner_address"))
        Next



    End Sub

    Private Sub lbl_countpending_Click(sender As Object, e As EventArgs) Handles lbl_countpending.Click

    End Sub
End Class