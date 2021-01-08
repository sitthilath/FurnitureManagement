<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Bills
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
        Me.CRVbill = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'CRVbill
        '
        Me.CRVbill.ActiveViewIndex = -1
        Me.CRVbill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRVbill.Cursor = System.Windows.Forms.Cursors.Default
        Me.CRVbill.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRVbill.Location = New System.Drawing.Point(0, 0)
        Me.CRVbill.Name = "CRVbill"
        Me.CRVbill.Size = New System.Drawing.Size(800, 450)
        Me.CRVbill.TabIndex = 0
        Me.CRVbill.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'Bills
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.CRVbill)
        Me.Name = "Bills"
        Me.Text = "Bills"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CRVbill As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
