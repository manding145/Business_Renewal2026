<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Evaluator
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.PanelAppoinment = New System.Windows.Forms.Panel()
        Me.EvalGrid = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BtnSearchRecord = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.lblappid = New System.Windows.Forms.Label()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbtype = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.dt_Appoinment = New System.Windows.Forms.DateTimePicker()
        Me.Paneldone = New System.Windows.Forms.Panel()
        Me.lbldone = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.Panelre = New System.Windows.Forms.Panel()
        Me.lblreupload = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.PanelP = New System.Windows.Forms.Panel()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.lbl_countpending = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.timerpending = New System.Windows.Forms.Timer(Me.components)
        Me.Panel3.SuspendLayout()
        Me.PanelAppoinment.SuspendLayout()
        CType(Me.EvalGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Paneldone.SuspendLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panelre.SuspendLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelP.SuspendLayout()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel3.Controls.Add(Me.PanelAppoinment)
        Me.Panel3.Controls.Add(Me.Paneldone)
        Me.Panel3.Controls.Add(Me.Panelre)
        Me.Panel3.Controls.Add(Me.PanelP)
        Me.Panel3.Location = New System.Drawing.Point(12, 54)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(907, 576)
        Me.Panel3.TabIndex = 55
        '
        'PanelAppoinment
        '
        Me.PanelAppoinment.BackColor = System.Drawing.Color.White
        Me.PanelAppoinment.Controls.Add(Me.EvalGrid)
        Me.PanelAppoinment.Controls.Add(Me.BtnSearchRecord)
        Me.PanelAppoinment.Controls.Add(Me.Button7)
        Me.PanelAppoinment.Controls.Add(Me.lblappid)
        Me.PanelAppoinment.Controls.Add(Me.Button6)
        Me.PanelAppoinment.Controls.Add(Me.Label11)
        Me.PanelAppoinment.Controls.Add(Me.cmbtype)
        Me.PanelAppoinment.Controls.Add(Me.Label8)
        Me.PanelAppoinment.Controls.Add(Me.Label13)
        Me.PanelAppoinment.Controls.Add(Me.dt_Appoinment)
        Me.PanelAppoinment.Location = New System.Drawing.Point(3, 90)
        Me.PanelAppoinment.Name = "PanelAppoinment"
        Me.PanelAppoinment.Size = New System.Drawing.Size(874, 386)
        Me.PanelAppoinment.TabIndex = 88
        '
        'EvalGrid
        '
        Me.EvalGrid.AllowUserToAddRows = False
        Me.EvalGrid.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.EvalGrid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.EvalGrid.BackgroundColor = System.Drawing.Color.White
        Me.EvalGrid.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.EvalGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.EvalGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Navy
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.EvalGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.EvalGrid.ColumnHeadersHeight = 35
        Me.EvalGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.EvalGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column7, Me.Column4, Me.Column5, Me.Column6})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "Select"
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.EvalGrid.DefaultCellStyle = DataGridViewCellStyle3
        Me.EvalGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.EvalGrid.EnableHeadersVisualStyles = False
        Me.EvalGrid.Location = New System.Drawing.Point(2, 49)
        Me.EvalGrid.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.EvalGrid.MultiSelect = False
        Me.EvalGrid.Name = "EvalGrid"
        Me.EvalGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(49, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.EvalGrid.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.EvalGrid.RowHeadersVisible = False
        Me.EvalGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.EvalGrid.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.EvalGrid.RowTemplate.Height = 25
        Me.EvalGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.EvalGrid.Size = New System.Drawing.Size(870, 324)
        Me.EvalGrid.TabIndex = 156
        '
        'Column1
        '
        Me.Column1.HeaderText = "ID"
        Me.Column1.Name = "Column1"
        Me.Column1.Visible = False
        '
        'Column2
        '
        Me.Column2.HeaderText = "APPID"
        Me.Column2.Name = "Column2"
        Me.Column2.Visible = False
        '
        'Column3
        '
        Me.Column3.HeaderText = "ACCOUNT #"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 70
        '
        'Column7
        '
        Me.Column7.HeaderText = "BUSINESS NAME"
        Me.Column7.Name = "Column7"
        Me.Column7.Width = 300
        '
        'Column4
        '
        Me.Column4.HeaderText = "GROSS"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "BUSINESSLINE"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 250
        '
        'Column6
        '
        Me.Column6.HeaderText = "STATUS"
        Me.Column6.Name = "Column6"
        Me.Column6.Visible = False
        '
        'BtnSearchRecord
        '
        Me.BtnSearchRecord.BackColor = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.BtnSearchRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSearchRecord.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSearchRecord.ForeColor = System.Drawing.Color.White
        Me.BtnSearchRecord.Location = New System.Drawing.Point(14, 12)
        Me.BtnSearchRecord.Name = "BtnSearchRecord"
        Me.BtnSearchRecord.Size = New System.Drawing.Size(184, 31)
        Me.BtnSearchRecord.TabIndex = 155
        Me.BtnSearchRecord.Text = "&Search Record"
        Me.BtnSearchRecord.UseVisualStyleBackColor = False
        '
        'Button7
        '
        Me.Button7.Image = Global.WindowsApplication1.My.Resources.Resources.enable
        Me.Button7.Location = New System.Drawing.Point(53, 394)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(33, 36)
        Me.Button7.TabIndex = 139
        Me.Button7.UseVisualStyleBackColor = True
        Me.Button7.Visible = False
        '
        'lblappid
        '
        Me.lblappid.AutoSize = True
        Me.lblappid.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblappid.Location = New System.Drawing.Point(784, 394)
        Me.lblappid.Name = "lblappid"
        Me.lblappid.Size = New System.Drawing.Size(19, 20)
        Me.lblappid.TabIndex = 138
        Me.lblappid.Text = "0"
        '
        'Button6
        '
        Me.Button6.Image = Global.WindowsApplication1.My.Resources.Resources.delete
        Me.Button6.Location = New System.Drawing.Point(14, 394)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(33, 36)
        Me.Button6.TabIndex = 89
        Me.Button6.UseVisualStyleBackColor = True
        Me.Button6.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(545, 416)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(299, 13)
        Me.Label11.TabIndex = 136
        Me.Label11.Text = "*Status - P for Pending, V for Verified, D for Denied"
        Me.Label11.Visible = False
        '
        'cmbtype
        '
        Me.cmbtype.BackColor = System.Drawing.Color.AliceBlue
        Me.cmbtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbtype.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbtype.FormattingEnabled = True
        Me.cmbtype.Items.AddRange(New Object() {"PENDING", "EVALUATED", "RE-UPLOADED"})
        Me.cmbtype.Location = New System.Drawing.Point(732, 14)
        Me.cmbtype.Name = "cmbtype"
        Me.cmbtype.Size = New System.Drawing.Size(130, 23)
        Me.cmbtype.TabIndex = 134
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(616, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(103, 15)
        Me.Label8.TabIndex = 133
        Me.Label8.Text = "Application Status"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(432, 18)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(31, 15)
        Me.Label13.TabIndex = 113
        Me.Label13.Text = "Date"
        '
        'dt_Appoinment
        '
        Me.dt_Appoinment.CustomFormat = "mm/dd/yyyy"
        Me.dt_Appoinment.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt_Appoinment.Location = New System.Drawing.Point(469, 15)
        Me.dt_Appoinment.Name = "dt_Appoinment"
        Me.dt_Appoinment.Size = New System.Drawing.Size(141, 20)
        Me.dt_Appoinment.TabIndex = 112
        '
        'Paneldone
        '
        Me.Paneldone.BackColor = System.Drawing.Color.White
        Me.Paneldone.Controls.Add(Me.lbldone)
        Me.Paneldone.Controls.Add(Me.Label7)
        Me.Paneldone.Controls.Add(Me.Label6)
        Me.Paneldone.Controls.Add(Me.PictureBox7)
        Me.Paneldone.Location = New System.Drawing.Point(614, 10)
        Me.Paneldone.Name = "Paneldone"
        Me.Paneldone.Size = New System.Drawing.Size(272, 71)
        Me.Paneldone.TabIndex = 87
        '
        'lbldone
        '
        Me.lbldone.AutoSize = True
        Me.lbldone.BackColor = System.Drawing.Color.Transparent
        Me.lbldone.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldone.ForeColor = System.Drawing.Color.Red
        Me.lbldone.Location = New System.Drawing.Point(139, 7)
        Me.lbldone.Name = "lbldone"
        Me.lbldone.Size = New System.Drawing.Size(39, 30)
        Me.lbldone.TabIndex = 89
        Me.lbldone.Text = "00"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(122, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 21)
        Me.Label7.TabIndex = 87
        Me.Label7.Text = "EVALUATED"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(99, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(0, 21)
        Me.Label6.TabIndex = 86
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = Global.WindowsApplication1.My.Resources.Resources.calendar
        Me.PictureBox7.Location = New System.Drawing.Point(14, 3)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(79, 60)
        Me.PictureBox7.TabIndex = 0
        Me.PictureBox7.TabStop = False
        '
        'Panelre
        '
        Me.Panelre.BackColor = System.Drawing.Color.White
        Me.Panelre.Controls.Add(Me.lblreupload)
        Me.Panelre.Controls.Add(Me.Label5)
        Me.Panelre.Controls.Add(Me.PictureBox6)
        Me.Panelre.Location = New System.Drawing.Point(333, 9)
        Me.Panelre.Name = "Panelre"
        Me.Panelre.Size = New System.Drawing.Size(272, 71)
        Me.Panelre.TabIndex = 87
        '
        'lblreupload
        '
        Me.lblreupload.AutoSize = True
        Me.lblreupload.BackColor = System.Drawing.Color.Transparent
        Me.lblreupload.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblreupload.ForeColor = System.Drawing.Color.Red
        Me.lblreupload.Location = New System.Drawing.Point(156, 10)
        Me.lblreupload.Name = "lblreupload"
        Me.lblreupload.Size = New System.Drawing.Size(39, 30)
        Me.lblreupload.TabIndex = 88
        Me.lblreupload.Text = "00"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(122, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(121, 21)
        Me.Label5.TabIndex = 86
        Me.Label5.Text = "RE-UPLOADED" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = Global.WindowsApplication1.My.Resources.Resources.register
        Me.PictureBox6.Location = New System.Drawing.Point(14, 3)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(79, 66)
        Me.PictureBox6.TabIndex = 0
        Me.PictureBox6.TabStop = False
        '
        'PanelP
        '
        Me.PanelP.BackColor = System.Drawing.Color.LightBlue
        Me.PanelP.Controls.Add(Me.PictureBox9)
        Me.PanelP.Controls.Add(Me.lbl_countpending)
        Me.PanelP.Controls.Add(Me.Label4)
        Me.PanelP.Controls.Add(Me.PictureBox5)
        Me.PanelP.Location = New System.Drawing.Point(26, 7)
        Me.PanelP.Name = "PanelP"
        Me.PanelP.Size = New System.Drawing.Size(289, 71)
        Me.PanelP.TabIndex = 0
        '
        'PictureBox9
        '
        Me.PictureBox9.Image = Global.WindowsApplication1.My.Resources.Resources.reload
        Me.PictureBox9.Location = New System.Drawing.Point(257, 4)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(31, 34)
        Me.PictureBox9.TabIndex = 88
        Me.PictureBox9.TabStop = False
        '
        'lbl_countpending
        '
        Me.lbl_countpending.AutoSize = True
        Me.lbl_countpending.BackColor = System.Drawing.Color.Transparent
        Me.lbl_countpending.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_countpending.ForeColor = System.Drawing.Color.Red
        Me.lbl_countpending.Location = New System.Drawing.Point(168, 10)
        Me.lbl_countpending.Name = "lbl_countpending"
        Me.lbl_countpending.Size = New System.Drawing.Size(39, 30)
        Me.lbl_countpending.TabIndex = 87
        Me.lbl_countpending.Text = "00"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(118, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(143, 21)
        Me.Label4.TabIndex = 86
        Me.Label4.Text = "FOR EVALUATION"
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = Global.WindowsApplication1.My.Resources.Resources.behavior3
        Me.PictureBox5.Location = New System.Drawing.Point(23, 2)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(79, 66)
        Me.PictureBox5.TabIndex = 0
        Me.PictureBox5.TabStop = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(871, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(37, 31)
        Me.Button1.TabIndex = 156
        Me.Button1.Text = "X"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Location = New System.Drawing.Point(0, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(917, 36)
        Me.Panel1.TabIndex = 58
        '
        'timerpending
        '
        Me.timerpending.Enabled = True
        Me.timerpending.Interval = 5000
        '
        'Evaluator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(913, 561)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Evaluator"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel3.ResumeLayout(False)
        Me.PanelAppoinment.ResumeLayout(False)
        Me.PanelAppoinment.PerformLayout()
        CType(Me.EvalGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Paneldone.ResumeLayout(False)
        Me.Paneldone.PerformLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panelre.ResumeLayout(False)
        Me.Panelre.PerformLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelP.ResumeLayout(False)
        Me.PanelP.PerformLayout()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents PanelAppoinment As System.Windows.Forms.Panel
    Friend WithEvents BtnSearchRecord As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents lblappid As System.Windows.Forms.Label
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Panelre As System.Windows.Forms.Panel
    Friend WithEvents lblreupload As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PanelP As System.Windows.Forms.Panel
    Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
    Friend WithEvents lbl_countpending As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Paneldone As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents EvalGrid As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmbtype As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents dt_Appoinment As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents timerpending As System.Windows.Forms.Timer
    Friend WithEvents lbldone As System.Windows.Forms.Label
End Class
