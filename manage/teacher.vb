Imports MySql.Data.MySqlClient

Public Class teacher
    Dim connection As New MySqlConnection("server=localhost;user=root;password='';database=teacher")
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        'Dim connection As New MySqlConnection("server=localhost;user=root;password='';database=teacher")
        'Dim table As New DataTable()
        'Dim adapter As New MySqlDataAdapter("SELECT * FROM stduent", connection)
        'adapter.Fill(table)
        'viewstudent.DataSource = table
        'Me.viewstudent.DefaultCellStyle.Font = New Font("Phetsarath OT", 12)
        'Me.viewstudent.ColumnHeadersDefaultCellStyle.Font = New Font("Phetsarath OT", 13)
        'viewstudent.Columns(0).HeaderText = "ລະຫັດ"
        'viewstudent.Columns(1).HeaderText = "ຊື່"
        'viewstudent.Columns(2).HeaderText = "ນາມສະກຸນ"
        'viewstudent.Columns(3).HeaderText = "ເບີໂທ"
        'connection.Close()
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            Dim cmd_insert As New MySqlCommand
            cmd_insert.Connection = connection
            cmd_insert.CommandType = CommandType.Text
            cmd_insert.CommandText = " INSERT INTO exam (Mname) VALUES (@name)"
            cmd_insert.Parameters.AddWithValue("@name", txt_name.Text)
            cmd_insert.ExecuteNonQuery()
            showdata()
            txt_name.Text = ""
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Guna2ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)


    End Sub
    Dim a As String
    Private Sub teacher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        showdata()
    End Sub

    'Private Sub cbb()
    '    Dim connection As New MySqlConnection("server=localhost;user=root;password='';database=teacher")
    '    connection.Open()

    '    a = "SELECT * FROM stduent"

    '    Dim adapter As New MySqlDataAdapter(a, connection)
    '    Dim table As New DataTable()
    '    adapter.Fill(table)
    '    With combo_name
    '        .DataSource = table
    '        .ValueMember = "id"
    '        .DisplayMember = "name"
    '    End With
    'End Sub


    Function showdata()
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            Dim table As New DataTable
            Dim adapter As New MySqlDataAdapter("SELECT * FROM exam  ", connection)
            adapter.Fill(table)
            DataGridView1.DataSource = table
            DataGridView1.RowHeadersVisible = True
            Me.DataGridView1.DefaultCellStyle.Font = New Font("Phetsarath OT", 12)
            Me.DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("Phetsarath OT", 13)

            Dim head() As String = {"ລະຫັດ", "ວິຊາ"}
            For i As Integer = 0 To DataGridView1.ColumnCount - 1
                DataGridView1.Columns(i).HeaderText = head(i)
            Next

        Catch ex As Exception
            MsgBox("error!" + ex.Message)
        End Try
    End Function
End Class