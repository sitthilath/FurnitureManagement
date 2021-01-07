Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class printHostory
    Private Sub printHostory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim rpd As ReportDocument
        rpd = New history

        Me.CrystalReportViewer1.ReportSource = rpd



    End Sub
End Class