<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Historysell
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.viewAllsell = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.TimePicker = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.Guna2HtmlLabel2 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2HtmlLabel3 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.cobo_product = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Guna2HtmlLabel4 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2HtmlLabel5 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2Button1 = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Separator1 = New Guna.UI2.WinForms.Guna2Separator()
        Me.Guna2Separator2 = New Guna.UI2.WinForms.Guna2Separator()
        CType(Me.viewAllsell, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'viewAllsell
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.viewAllsell.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.viewAllsell.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.viewAllsell.BackgroundColor = System.Drawing.Color.White
        Me.viewAllsell.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.viewAllsell.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.viewAllsell.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.viewAllsell.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.viewAllsell.ColumnHeadersHeight = 50
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.viewAllsell.DefaultCellStyle = DataGridViewCellStyle3
        Me.viewAllsell.EnableHeadersVisualStyles = False
        Me.viewAllsell.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.viewAllsell.Location = New System.Drawing.Point(0, 133)
        Me.viewAllsell.Name = "viewAllsell"
        Me.viewAllsell.RowHeadersVisible = False
        Me.viewAllsell.RowHeadersWidth = 51
        Me.viewAllsell.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.viewAllsell.Size = New System.Drawing.Size(1117, 437)
        Me.viewAllsell.TabIndex = 0
        Me.viewAllsell.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.[Default]
        Me.viewAllsell.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.viewAllsell.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.viewAllsell.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.viewAllsell.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.viewAllsell.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.viewAllsell.ThemeStyle.BackColor = System.Drawing.Color.White
        Me.viewAllsell.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.viewAllsell.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.viewAllsell.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.viewAllsell.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.viewAllsell.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.viewAllsell.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        Me.viewAllsell.ThemeStyle.HeaderStyle.Height = 50
        Me.viewAllsell.ThemeStyle.ReadOnly = False
        Me.viewAllsell.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.viewAllsell.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.viewAllsell.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.viewAllsell.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.viewAllsell.ThemeStyle.RowsStyle.Height = 22
        Me.viewAllsell.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.viewAllsell.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'Guna2HtmlLabel1
        '
        Me.Guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel1.Font = New System.Drawing.Font("Saysettha OT", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(12, 12)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(302, 36)
        Me.Guna2HtmlLabel1.TabIndex = 1
        Me.Guna2HtmlLabel1.Text = "ການຂາຍພາຍໃນຮ້ານ Index Future"
        '
        'TimePicker
        '
        Me.TimePicker.Animated = True
        Me.TimePicker.AutoRoundedCorners = True
        Me.TimePicker.BorderRadius = 17
        Me.TimePicker.CheckedState.Parent = Me.TimePicker
        Me.TimePicker.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TimePicker.FillColor = System.Drawing.Color.LightGreen
        Me.TimePicker.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.TimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.TimePicker.HoverState.Parent = Me.TimePicker
        Me.TimePicker.Location = New System.Drawing.Point(417, 91)
        Me.TimePicker.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.TimePicker.MinDate = New Date(2000, 2, 17, 0, 0, 0, 0)
        Me.TimePicker.Name = "TimePicker"
        Me.TimePicker.ShadowDecoration.Parent = Me.TimePicker
        Me.TimePicker.Size = New System.Drawing.Size(289, 36)
        Me.TimePicker.TabIndex = 2
        Me.TimePicker.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TimePicker.Value = New Date(2020, 11, 11, 16, 10, 43, 495)
        '
        'Guna2HtmlLabel2
        '
        Me.Guna2HtmlLabel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel2.Font = New System.Drawing.Font("Phetsarath OT", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel2.Location = New System.Drawing.Point(417, 48)
        Me.Guna2HtmlLabel2.Name = "Guna2HtmlLabel2"
        Me.Guna2HtmlLabel2.Size = New System.Drawing.Size(132, 34)
        Me.Guna2HtmlLabel2.TabIndex = 3
        Me.Guna2HtmlLabel2.Text = "ເວລາ ການຂາຍ : "
        '
        'Guna2HtmlLabel3
        '
        Me.Guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel3.Location = New System.Drawing.Point(12, 581)
        Me.Guna2HtmlLabel3.Name = "Guna2HtmlLabel3"
        Me.Guna2HtmlLabel3.Size = New System.Drawing.Size(3, 2)
        Me.Guna2HtmlLabel3.TabIndex = 6
        Me.Guna2HtmlLabel3.Text = Nothing
        '
        'cobo_product
        '
        Me.cobo_product.Animated = True
        Me.cobo_product.AutoRoundedCorners = True
        Me.cobo_product.BackColor = System.Drawing.Color.Transparent
        Me.cobo_product.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cobo_product.BorderRadius = 17
        Me.cobo_product.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom
        Me.cobo_product.BorderThickness = 2
        Me.cobo_product.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cobo_product.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cobo_product.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cobo_product.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cobo_product.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cobo_product.FocusedState.Parent = Me.cobo_product
        Me.cobo_product.Font = New System.Drawing.Font("Phetsarath OT", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cobo_product.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cobo_product.HoverState.Parent = Me.cobo_product
        Me.cobo_product.ItemHeight = 30
        Me.cobo_product.Items.AddRange(New Object() {"ທັງໝົດ", "ສິນຄ້າຂາຍດີ", "ສິນຄ້າຂາຍໄດ້ໜ້ອຍ", "ລາຍງານສິນຄ້າຂາຍດີ 10 ລາຍການ", "ລາຍງານສິນຄ້າຂາຍໄດ້ໜ້ອຍ 10 ລາຍການ", "ລາຍງານສິນຄ້າປະຈຳເດື່ອນນີ້", "ລາຍງານສິນຄ້າເດື່ອນກ່ອນ", "ລາຍງານສິນຄ້າ 2 ເດື່ອນກ່ອນ"})
        Me.cobo_product.ItemsAppearance.Parent = Me.cobo_product
        Me.cobo_product.Location = New System.Drawing.Point(741, 91)
        Me.cobo_product.Name = "cobo_product"
        Me.cobo_product.ShadowDecoration.Parent = Me.cobo_product
        Me.cobo_product.Size = New System.Drawing.Size(339, 36)
        Me.cobo_product.StartIndex = 0
        Me.cobo_product.TabIndex = 7
        Me.cobo_product.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.cobo_product.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit
        '
        'Guna2HtmlLabel4
        '
        Me.Guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel4.Font = New System.Drawing.Font("Phetsarath OT", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel4.Location = New System.Drawing.Point(761, 51)
        Me.Guna2HtmlLabel4.Name = "Guna2HtmlLabel4"
        Me.Guna2HtmlLabel4.Size = New System.Drawing.Size(77, 34)
        Me.Guna2HtmlLabel4.TabIndex = 9
        Me.Guna2HtmlLabel4.Text = "ເພີ່ມເຕີມ:"
        '
        'Guna2HtmlLabel5
        '
        Me.Guna2HtmlLabel5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2HtmlLabel5.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel5.Font = New System.Drawing.Font("Phetsarath OT", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel5.Location = New System.Drawing.Point(12, 93)
        Me.Guna2HtmlLabel5.Name = "Guna2HtmlLabel5"
        Me.Guna2HtmlLabel5.Size = New System.Drawing.Size(189, 34)
        Me.Guna2HtmlLabel5.TabIndex = 10
        Me.Guna2HtmlLabel5.Text = "ອັດຕາການຂາຍລາຍວັນ :"
        '
        'Guna2Button1
        '
        Me.Guna2Button1.BorderRadius = 6
        Me.Guna2Button1.CheckedState.Parent = Me.Guna2Button1
        Me.Guna2Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Guna2Button1.CustomImages.Parent = Me.Guna2Button1
        Me.Guna2Button1.Font = New System.Drawing.Font("Nasalization Rg", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2Button1.ForeColor = System.Drawing.Color.White
        Me.Guna2Button1.HoverState.Parent = Me.Guna2Button1
        Me.Guna2Button1.Location = New System.Drawing.Point(1026, 576)
        Me.Guna2Button1.Name = "Guna2Button1"
        Me.Guna2Button1.ShadowDecoration.Parent = Me.Guna2Button1
        Me.Guna2Button1.Size = New System.Drawing.Size(90, 45)
        Me.Guna2Button1.TabIndex = 13
        Me.Guna2Button1.Text = "Print"
        '
        'Guna2Separator1
        '
        Me.Guna2Separator1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2Separator1.FillThickness = 2
        Me.Guna2Separator1.Location = New System.Drawing.Point(317, 594)
        Me.Guna2Separator1.Name = "Guna2Separator1"
        Me.Guna2Separator1.Size = New System.Drawing.Size(694, 10)
        Me.Guna2Separator1.TabIndex = 16
        '
        'Guna2Separator2
        '
        Me.Guna2Separator2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2Separator2.FillThickness = 2
        Me.Guna2Separator2.Location = New System.Drawing.Point(8, 43)
        Me.Guna2Separator2.Name = "Guna2Separator2"
        Me.Guna2Separator2.Size = New System.Drawing.Size(333, 10)
        Me.Guna2Separator2.TabIndex = 18
        '
        'Historysell
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1128, 624)
        Me.Controls.Add(Me.Guna2Separator2)
        Me.Controls.Add(Me.Guna2Separator1)
        Me.Controls.Add(Me.Guna2Button1)
        Me.Controls.Add(Me.Guna2HtmlLabel5)
        Me.Controls.Add(Me.Guna2HtmlLabel4)
        Me.Controls.Add(Me.cobo_product)
        Me.Controls.Add(Me.Guna2HtmlLabel3)
        Me.Controls.Add(Me.Guna2HtmlLabel2)
        Me.Controls.Add(Me.TimePicker)
        Me.Controls.Add(Me.Guna2HtmlLabel1)
        Me.Controls.Add(Me.viewAllsell)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Historysell"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "sell"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.viewAllsell, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents viewAllsell As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents TimePicker As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents Guna2HtmlLabel2 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel3 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents cobo_product As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Guna2HtmlLabel4 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel5 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2Button1 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Separator1 As Guna.UI2.WinForms.Guna2Separator
    Friend WithEvents Guna2Separator2 As Guna.UI2.WinForms.Guna2Separator
End Class
