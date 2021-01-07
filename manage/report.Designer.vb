<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class report
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
        Me.reportproduct = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'reportproduct
        '
        Me.reportproduct.ActiveViewIndex = -1
        Me.reportproduct.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.reportproduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.reportproduct.Cursor = System.Windows.Forms.Cursors.Default
        Me.reportproduct.Location = New System.Drawing.Point(0, 0)
        Me.reportproduct.Name = "reportproduct"
        Me.reportproduct.Size = New System.Drawing.Size(800, 450)
        Me.reportproduct.TabIndex = 0
        Me.reportproduct.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'report
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.reportproduct)
        Me.Name = "report"
        Me.Text = "report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents reportproduct As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
