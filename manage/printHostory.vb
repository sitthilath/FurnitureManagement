Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports MySql.Data.MySqlClient
Public Class printHostory
    Private Sub printHostory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim rpd As ReportDocument
        'rpd = New history

        'Me.CRV1.ReportSource = rpd



    End Sub

    Private Sub CRV1_Load(sender As Object, e As EventArgs) Handles CRV1.Load
        load()

    End Sub

    Sub load()
        Try
            Dim connection As New MySqlConnection("server=localhost;user=root;password='';database=index")

            Dim SqlQuery As String = "SELECT * FROM aftersell WHERE afterID = " & Historysell.viewAllsell.SelectedRows(0).Cells(0).Value.ToString() & ""
            Dim SqlCommand As New MySqlCommand
            Dim SqlAdepter As New MySqlDataAdapter
            Dim TABLE As New DataTable

            With SqlCommand
                .CommandText = SqlQuery
                .Connection = connection
            End With
            With SqlAdepter
                .SelectCommand = SqlCommand
                .Fill(TABLE)
            End With
            Dim crystal As New history()
            crystal.SetDataSource(Historysell.viewAllsell.DataSource)
            CRV1.ReportSource = crystal
            'CRV1.Refresh()


        Catch ex As Exception

        End Try
    End Sub
End Class