Imports MySql.Data.MySqlClient
Public Class Historysell
    Dim connection As New MySqlConnection("server=localhost;user=root;password='';database=index")


    Private Sub sell_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        showdata()

    End Sub

    Private Sub Guna2ComboBox1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cobo_product.SelectedIndexChanged
        If cobo_product.SelectedItem = "ສິນຄ້າຂາຍດີ" Then
            Try

                Dim table As New DataTable()
                Dim adapter As New MySqlDataAdapter("SELECT `Pid`, `Pname`, qty ,`seller` ,datetime FROM aftersell order by qty desc", connection)
                adapter.Fill(table)
                viewAllsell.DataSource = table
                viewAllsell.RowHeadersVisible = True
                Me.viewAllsell.DefaultCellStyle.Font = New Font("Phetsarath OT", 12)
                Me.viewAllsell.ColumnHeadersDefaultCellStyle.Font = New Font("Phetsarath OT", 13)
                Dim heade_data() As String = {"ລະຫັດ", "ສິນຄ້າ", "ຈຳນວນ", "ລາຄາ", "ປະເພດ", "ຜູ້ຂາຍ", "ວັນທີ່ຂາຍ", "ເລກໃບບິນ"}
                For i As Integer = 0 To viewAllsell.ColumnCount - 1
                    viewAllsell.Columns(i).HeaderText = heade_data(i)
                Next
                connection.Close()
            Catch ex As Exception
                MsgBox("Connect Database fail!" + ex.Message)

            End Try
        ElseIf cobo_product.SelectedItem = "ສິນຄ້າຂາຍໄດ້ໜ້ອຍ" Then
            Try

                Dim table As New DataTable()
                Dim adapter As New MySqlDataAdapter("SELECT `Pid`, `Pname`, qty, `seller`,datetime FROM aftersell order by qty asc", connection)
                adapter.Fill(table)
                viewAllsell.DataSource = table
                viewAllsell.RowHeadersVisible = True
                Me.viewAllsell.DefaultCellStyle.Font = New Font("Phetsarath OT", 12)
                Me.viewAllsell.ColumnHeadersDefaultCellStyle.Font = New Font("Phetsarath OT", 13)
                Dim heade_data() As String = {"ລະຫັດ", "ສິນຄ້າ", "ຈຳນວນ", "ລາຄາ", "ປະເພດ", "ຜູ້ຂາຍ", "ວັນທີ່ຂາຍ", "ເລກໃບບິນ"}
                For i As Integer = 0 To viewAllsell.ColumnCount - 1
                    viewAllsell.Columns(i).HeaderText = heade_data(i)
                Next
                connection.Close()
            Catch ex As Exception
                MsgBox("Connect Database fail!" + ex.Message)

            End Try
        Else
            showdata()
        End If


    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)


    End Sub
    Sub showdata()
        Try

            Dim table As New DataTable()
            Dim adapter As New MySqlDataAdapter("SELECT `Pid`, `Pname`, `qty`, `price`, `type_catagory`, `seller`, `datetime`, `bill_id` FROM aftersell", connection)
            adapter.Fill(table)
            viewAllsell.DataSource = table
            viewAllsell.RowHeadersVisible = True
            Me.viewAllsell.DefaultCellStyle.Font = New Font("Phetsarath OT", 12)
            Me.viewAllsell.ColumnHeadersDefaultCellStyle.Font = New Font("Phetsarath OT", 13)
            Dim heade_data() As String = {"ລະຫັດ", "ສິນຄ້າ", "ຈຳນວນ", "ລາຄາ", "ປະເພດ", "ຜູ້ຂາຍ", "ວັນທີ່ຂາຍ", "ເລກໃບບິນ"}
            For i As Integer = 0 To viewAllsell.ColumnCount - 1
                viewAllsell.Columns(i).HeaderText = heade_data(i)
            Next
            connection.Close()
        Catch ex As Exception
            MsgBox("Connect Database fail!" + ex.Message)

        End Try
    End Sub

    Private Sub TimePicker_ValueChanged(sender As Object, e As EventArgs) Handles TimePicker.ValueChanged
        connection.Open()

        Dim myDate As DateTime = TimePicker.Value.Date
        Dim SQl = String.Format("SELECT `Pid`, `Pname`, `qty`, `seller`,datetime FROM aftersell WHERE YEAR(datetime) = {0} AND MONTH(datetime) = {1} AND DAY(datetime) = {2}", myDate.Year, myDate.Month, myDate.Day)
        Dim table As New DataTable()
        Dim adapter As New MySqlDataAdapter(SQl, connection)
        adapter.Fill(table)
        viewAllsell.DataSource = table
        Me.viewAllsell.DefaultCellStyle.Font = New Font("Phetsarath OT", 12)
        Me.viewAllsell.ColumnHeadersDefaultCellStyle.Font = New Font("Phetsarath OT", 13)
        connection.Close()


    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Dim dt As New DataTable
        With dt
            .Columns.Add("Pid")
            .Columns.Add("Pname")
        End With

        For Each dr As DataGridViewRow In Me.viewAllsell.Rows
            dt.Rows.Add(dr.Cells("Pid").Value, dr.Cells("Pname").Value)
        Next
        Dim drt As CrystalDecisions.CrystalReports.Engine.ReportDocument
        drt = New history
        printHostory.ShowDialog()
    End Sub
End Class