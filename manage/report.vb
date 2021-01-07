Imports MySql.Data.MySqlClient
Imports System.Data

Public Class report

    Dim conection As New MySqlConnection("server=localhost;user=root;password='';database=index")
    Dim cmd As MySqlCommand
    Dim da As MySqlDataAdapter
    Dim ds As New DATAproduct
    Dim reportPro As cryReportProduct

    Private Sub CrystalReportViewer1_Load(sender As Object, e As EventArgs) Handles reportproduct.Load

    End Sub

    Sub report()

        cmd = New MySqlCommand("Select * From product", conection)
        da = New MySqlDataAdapter(cmd)
        da.Fill(ds.product)

        reportPro = New cryReportProduct()

        reportPro.SetDataSource(ds)
        reportproduct.ReportSource = reportPro
        reportproduct.RefreshReport()

    End Sub

    Private Sub report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        report()
    End Sub
End Class