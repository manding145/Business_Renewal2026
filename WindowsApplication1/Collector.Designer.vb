<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Collector
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.PanelAppoinment = New System.Windows.Forms.Panel()
        Me.txtacct1 = New System.Windows.Forms.TextBox()
        Me.txtacct2 = New System.Windows.Forms.TextBox()
        Me.ColGrid = New System.Windows.Forms.DataGridView()
        Me.BtnSearchRecord = New System.Windows.Forms.Button()
        Me.cmb_appointmentstatus = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.dt_Appoinment = New System.Windows.Forms.DateTimePicker()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CTCamount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FULLNAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ADDRESS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BIRTHDATE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel5.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.PanelAppoinment.SuspendLayout()
        CType(Me.ColGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.White
        Me.Button5.Location = New System.Drawing.Point(1165, 1)
        Me.Button5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(48, 34)
        Me.Button5.TabIndex = 169
        Me.Button5.Text = "X"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Panel5.Controls.Add(Me.Label1)
        Me.Panel5.Controls.Add(Me.Button5)
        Me.Panel5.Location = New System.Drawing.Point(1, 1)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1219, 38)
        Me.Panel5.TabIndex = 189
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label1.Location = New System.Drawing.Point(9, 12)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(159, 23)
        Me.Label1.TabIndex = 170
        Me.Label1.Text = "Collected Accounts"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel3.Controls.Add(Me.PanelAppoinment)
        Me.Panel3.Location = New System.Drawing.Point(16, 44)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1199, 667)
        Me.Panel3.TabIndex = 190
        '
        'PanelAppoinment
        '
        Me.PanelAppoinment.BackColor = System.Drawing.Color.White
        Me.PanelAppoinment.Controls.Add(Me.txtacct1)
        Me.PanelAppoinment.Controls.Add(Me.txtacct2)
        Me.PanelAppoinment.Controls.Add(Me.ColGrid)
        Me.PanelAppoinment.Controls.Add(Me.BtnSearchRecord)
        Me.PanelAppoinment.Controls.Add(Me.cmb_appointmentstatus)
        Me.PanelAppoinment.Controls.Add(Me.Label8)
        Me.PanelAppoinment.Controls.Add(Me.Label13)
        Me.PanelAppoinment.Controls.Add(Me.dt_Appoinment)
        Me.PanelAppoinment.Location = New System.Drawing.Point(4, 4)
        Me.PanelAppoinment.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PanelAppoinment.Name = "PanelAppoinment"
        Me.PanelAppoinment.Size = New System.Drawing.Size(1165, 638)
        Me.PanelAppoinment.TabIndex = 88
        '
        'txtacct1
        '
        Me.txtacct1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtacct1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtacct1.Location = New System.Drawing.Point(24, 20)
        Me.txtacct1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtacct1.MaxLength = 1
        Me.txtacct1.Name = "txtacct1"
        Me.txtacct1.Size = New System.Drawing.Size(37, 34)
        Me.txtacct1.TabIndex = 0
        Me.txtacct1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtacct2
        '
        Me.txtacct2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtacct2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtacct2.Location = New System.Drawing.Point(71, 20)
        Me.txtacct2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtacct2.MaxLength = 5
        Me.txtacct2.Name = "txtacct2"
        Me.txtacct2.Size = New System.Drawing.Size(119, 34)
        Me.txtacct2.TabIndex = 157
        Me.txtacct2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ColGrid
        '
        Me.ColGrid.AllowUserToAddRows = False
        Me.ColGrid.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.ColGrid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.ColGrid.BackgroundColor = System.Drawing.Color.White
        Me.ColGrid.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ColGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.ColGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.ColGrid.ColumnHeadersHeight = 35
        Me.ColGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.ColGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column7, Me.Column4, Me.Column8, Me.CTCamount, Me.Column5, Me.Column6, Me.FULLNAME, Me.ADDRESS, Me.BIRTHDATE})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "Select"
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColGrid.DefaultCellStyle = DataGridViewCellStyle4
        Me.ColGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.ColGrid.EnableHeadersVisualStyles = False
        Me.ColGrid.Location = New System.Drawing.Point(24, 78)
        Me.ColGrid.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ColGrid.MultiSelect = False
        Me.ColGrid.Name = "ColGrid"
        Me.ColGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(49, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColGrid.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.ColGrid.RowHeadersVisible = False
        Me.ColGrid.RowHeadersWidth = 51
        Me.ColGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColGrid.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.ColGrid.RowTemplate.Height = 25
        Me.ColGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ColGrid.Size = New System.Drawing.Size(1124, 550)
        Me.ColGrid.TabIndex = 156
        '
        'BtnSearchRecord
        '
        Me.BtnSearchRecord.BackColor = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.BtnSearchRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSearchRecord.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSearchRecord.ForeColor = System.Drawing.Color.White
        Me.BtnSearchRecord.Location = New System.Drawing.Point(199, 18)
        Me.BtnSearchRecord.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnSearchRecord.Name = "BtnSearchRecord"
        Me.BtnSearchRecord.Size = New System.Drawing.Size(97, 38)
        Me.BtnSearchRecord.TabIndex = 155
        Me.BtnSearchRecord.Text = "&Search"
        Me.BtnSearchRecord.UseVisualStyleBackColor = False
        '
        'cmb_appointmentstatus
        '
        Me.cmb_appointmentstatus.BackColor = System.Drawing.Color.AliceBlue
        Me.cmb_appointmentstatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_appointmentstatus.FormattingEnabled = True
        Me.cmb_appointmentstatus.Items.AddRange(New Object() {"ALL", "PENDING", "DELINQUENT", "EVALUATED", "DENIED"})
        Me.cmb_appointmentstatus.Location = New System.Drawing.Point(976, 25)
        Me.cmb_appointmentstatus.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmb_appointmentstatus.Name = "cmb_appointmentstatus"
        Me.cmb_appointmentstatus.Size = New System.Drawing.Size(132, 28)
        Me.cmb_appointmentstatus.TabIndex = 134
        Me.cmb_appointmentstatus.Text = "PENDING"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(821, 28)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(130, 20)
        Me.Label8.TabIndex = 133
        Me.Label8.Text = "Application Status"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(576, 30)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(41, 20)
        Me.Label13.TabIndex = 113
        Me.Label13.Text = "Date"
        '
        'dt_Appoinment
        '
        Me.dt_Appoinment.CustomFormat = "mm/dd/yyyy"
        Me.dt_Appoinment.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt_Appoinment.Location = New System.Drawing.Point(625, 26)
        Me.dt_Appoinment.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dt_Appoinment.Name = "dt_Appoinment"
        Me.dt_Appoinment.Size = New System.Drawing.Size(187, 22)
        Me.dt_Appoinment.TabIndex = 112
        '
        'Column1
        '
        Me.Column1.HeaderText = "ID"
        Me.Column1.MinimumWidth = 6
        Me.Column1.Name = "Column1"
        Me.Column1.Visible = False
        Me.Column1.Width = 125
        '
        'Column2
        '
        Me.Column2.HeaderText = "APPID"
        Me.Column2.MinimumWidth = 6
        Me.Column2.Name = "Column2"
        Me.Column2.Visible = False
        Me.Column2.Width = 125
        '
        'Column3
        '
        Me.Column3.HeaderText = "ACCOUNT #"
        Me.Column3.MinimumWidth = 6
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 70
        '
        'Column7
        '
        Me.Column7.HeaderText = "BUSINESS NAME"
        Me.Column7.MinimumWidth = 6
        Me.Column7.Name = "Column7"
        Me.Column7.Width = 300
        '
        'Column4
        '
        Me.Column4.HeaderText = "TAX AMOUNT"
        Me.Column4.MinimumWidth = 6
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 125
        '
        'Column8
        '
        Me.Column8.HeaderText = "FIRE AMOUNT"
        Me.Column8.MinimumWidth = 6
        Me.Column8.Name = "Column8"
        Me.Column8.Width = 125
        '
        'CTCamount
        '
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.CTCamount.DefaultCellStyle = DataGridViewCellStyle3
        Me.CTCamount.HeaderText = "CTC AMOUNT"
        Me.CTCamount.MinimumWidth = 6
        Me.CTCamount.Name = "CTCamount"
        Me.CTCamount.Width = 120
        '
        'Column5
        '
        Me.Column5.HeaderText = "EMAIL"
        Me.Column5.MinimumWidth = 6
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 220
        '
        'Column6
        '
        Me.Column6.HeaderText = "STATUS"
        Me.Column6.MinimumWidth = 6
        Me.Column6.Name = "Column6"
        Me.Column6.Visible = False
        Me.Column6.Width = 125
        '
        'FULLNAME
        '
        Me.FULLNAME.HeaderText = "FULLNAME"
        Me.FULLNAME.MinimumWidth = 6
        Me.FULLNAME.Name = "FULLNAME"
        Me.FULLNAME.Width = 250
        '
        'ADDRESS
        '
        Me.ADDRESS.HeaderText = "ADDRESS"
        Me.ADDRESS.MinimumWidth = 6
        Me.ADDRESS.Name = "ADDRESS"
        Me.ADDRESS.Width = 300
        '
        'BIRTHDATE
        '
        Me.BIRTHDATE.HeaderText = "BIRTHDATE"
        Me.BIRTHDATE.MinimumWidth = 6
        Me.BIRTHDATE.Name = "BIRTHDATE"
        Me.BIRTHDATE.Width = 150
        '
        'Collector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1217, 690)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Collector"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.PanelAppoinment.ResumeLayout(False)
        Me.PanelAppoinment.PerformLayout()
        CType(Me.ColGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents PanelAppoinment As System.Windows.Forms.Panel
    Friend WithEvents ColGrid As System.Windows.Forms.DataGridView
    Friend WithEvents BtnSearchRecord As System.Windows.Forms.Button
    Friend WithEvents cmb_appointmentstatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents dt_Appoinment As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtacct1 As System.Windows.Forms.TextBox
    Friend WithEvents txtacct2 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents CTCamount As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents FULLNAME As DataGridViewTextBoxColumn
    Friend WithEvents ADDRESS As DataGridViewTextBoxColumn
    Friend WithEvents BIRTHDATE As DataGridViewTextBoxColumn
End Class
