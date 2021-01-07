Imports MySql.Data.MySqlClient

Public Class addcat

    Dim conection As New MySqlConnection("server=localhost;user=root;password='';database=index")
    Private Sub addcat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        showdata()

    End Sub




    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Try

            Dim table As New DataTable
            Dim adapter As New MySqlDataAdapter("SELECT * FROM catagory  ", conection)
            adapter.Fill(table)
            dataviewCatagory.DataSource = table
            dataviewCatagory.RowHeadersVisible = True
            Me.dataviewCatagory.DefaultCellStyle.Font = New Font("Phetsarath OT", 12)
            Me.dataviewCatagory.ColumnHeadersDefaultCellStyle.Font = New Font("Phetsarath OT", 13)
            dataviewCatagory.Columns(0).HeaderText = "ລະຫັດ"
            dataviewCatagory.Columns(1).HeaderText = "ຊື່"
            txt_name.Text = ""
            txt_id.Text = ""
            txt_search.Text = ""
            txt_search.BorderColor = Color.Gainsboro

        Catch ex As Exception
            MessageBox.Show("error SQL")
        End Try

    End Sub
    Sub clear()
        txt_id.Text = ""
        txt_name.Text = ""
        txt_search.Text = ""
        txt_search.BorderColor = Color.Gainsboro
    End Sub
    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        txt_name.Focus()
        Try
            If txt_name.Text = "" Then
                MsgBox("ບໍ່ມີຂໍ້ມູນ")
                Return
            End If


            If conection.State = ConnectionState.Closed Then
                conection.Open()
            End If
            Dim cmd As New MySqlCommand

            With cmd

                .Connection = conection
                .CommandType = CommandType.Text
                .CommandText = " INSERT INTO catagory (type_catagory) VALUES (@name)"
                .Parameters.AddWithValue("@name", txt_name.Text.Trim)
            End With
            If cmd.ExecuteScalar = 0 Then


            End If
            conection.Close()
            clear()
            showdata()
        Catch ex As Exception
            MessageBox.Show("error syatem" + ex.Message)
        End Try
    End Sub
    Function execCommand(ByVal cmd As MySqlCommand) As Boolean
        If conection.State = ConnectionState.Closed Then
            conection.Open()

            If cmd.ExecuteNonQuery() = 1 Then
                Return True
            End If


        Else
            Return True
        End If
        If conection.State = ConnectionState.Open Then
            conection.Close()
        End If
    End Function


    Private Sub btn_sav_Click(sender As Object, e As EventArgs) Handles btn_sav.Click
        Try
            If conection.State = ConnectionState.Closed Then
                conection.Open()
            End If
            Dim cmd_update As New MySqlCommand
            cmd_update.Connection = conection
            cmd_update.CommandType = CommandType.Text
            cmd_update.CommandText = "UPDATE catagory SET type_catagory=@name where CID=@id"
            cmd_update.Parameters.AddWithValue("@name", txt_name.Text.Trim)
            cmd_update.Parameters.AddWithValue("@id", txt_id.Text.Trim)
            cmd_update.ExecuteNonQuery()
            conection.Close()
            showdata()
            clear()
        Catch ex As Exception
            MessageBox.Show("error syatem" + ex.Message)
        End Try

    End Sub

    Private Sub txt_id_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_id.KeyPress

    End Sub
    Friend Function confirm(text As String, Optional title As String = "ຍືນຍັນ")
        Return MsgBox(text, vbQuestion + vbYesNo, title)
    End Function
    Private Sub btn_delete_Click(sender As Object, e As EventArgs) Handles btn_delete.Click
        If confirm("ເຈົ້າຕ້ອງການທີ່ຈະລົບ ຫຼື ບໍ່?") = vbYes Then
            If txt_id.Text = "" Then
                MsgBox("ກາລຸນາເລືອກປະເພດທີ່ຕ້ອງການລົບ")
                Return
            End If
            Try
                If conection.State = ConnectionState.Closed Then
                    conection.Open()
                End If
                Dim cmd_delete As New MySqlCommand
                cmd_delete.Connection = conection
                cmd_delete.CommandType = CommandType.Text
                cmd_delete.CommandText = "Delete from catagory  where CID=@id"
                cmd_delete.Parameters.AddWithValue("@id", txt_id.Text.Trim)
                cmd_delete.ExecuteScalar()
                conection.Close()
                showdata()
                clear()
            Catch ex As Exception
                MessageBox.Show("error syatem" + ex.Message)
            End Try

        End If

    End Sub

    Private Sub dataviewCatagory_Click(sender As Object, e As EventArgs) Handles dataviewCatagory.Click

    End Sub
    Function showdata()
        Try
            If conection.State = ConnectionState.Closed Then
                conection.Open()
            End If

            Dim table As New DataTable
            Dim adapter As New MySqlDataAdapter("SELECT * FROM catagory  ", conection)
            adapter.Fill(table)
            dataviewCatagory.DataSource = table
            dataviewCatagory.RowHeadersVisible = True
            Me.dataviewCatagory.DefaultCellStyle.Font = New Font("Phetsarath OT", 12)
            Me.dataviewCatagory.ColumnHeadersDefaultCellStyle.Font = New Font("Phetsarath OT", 13)
            'dataviewCatagory.Columns(0).HeaderText = "ລະຫັດ"
            'dataviewCatagory.Columns(1).HeaderText = "ຊື່"
            Dim head() As String = {"ລະຫັດ", "ຊື່"}
            For i As Integer = 0 To dataviewCatagory.ColumnCount - 1
                dataviewCatagory.Columns(i).HeaderText = head(i)
            Next
            conection.Close()
        Catch ex As Exception
            MsgBox("error!" + ex.Message)
        End Try
    End Function

    Private Sub dataviewCatagory_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataviewCatagory.CellContentClick


    End Sub

    Private Sub dataviewCatagory_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataviewCatagory.CellClick
        Try
            Dim selected As DataGridViewRow
            selected = dataviewCatagory.Rows(e.RowIndex)
            txt_id.Text = selected.Cells(0).Value
            txt_name.Text = selected.Cells(1).Value
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txt_search_TextChanged(sender As Object, e As EventArgs) Handles txt_search.TextChanged

        Try

            Dim search_commnd As New MySqlCommand("SELECT * FROM catagory where CID = @id OR type_catagory = @id", conection)
            search_commnd.Parameters.Add("@id", MySqlDbType.VarChar).Value = txt_search.Text

            Dim table As New DataTable
            Dim adapter As New MySqlDataAdapter(search_commnd)
            adapter.Fill(table)
            dataviewCatagory.DataSource = table
            If (table.Rows.Count > 0) Then
                txt_id.Text = table(0)(0)
                txt_name.Text = table(0)(1)
                txt_search.BorderColor = Color.Gainsboro

            ElseIf txt_search.Text = "" Then


                Dim table2 As New DataTable
                Dim adapter2 As New MySqlDataAdapter("SELECT * FROM catagory  ", conection)
                adapter2.Fill(table2)
                dataviewCatagory.DataSource = table2
                dataviewCatagory.RowHeadersVisible = True
                Me.dataviewCatagory.DefaultCellStyle.Font = New Font("Phetsarath OT", 12)
                Me.dataviewCatagory.ColumnHeadersDefaultCellStyle.Font = New Font("Phetsarath OT", 13)

                txt_name.Text = ""
                txt_id.Text = ""
                txt_search.Text = ""
                txt_search.BorderColor = Color.Gainsboro

            Else
                txt_id.Text = ""
                txt_name.Text = ""
                txt_search.BorderColor = Color.Red
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try




    End Sub

    Private Sub txt_id_TextChanged(sender As Object, e As EventArgs) Handles txt_id.TextChanged

    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        report.ShowDialog()
    End Sub
End Class