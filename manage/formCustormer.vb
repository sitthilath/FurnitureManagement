Imports MySql.Data.MySqlClient

Public Class formCustormer
    Dim connection As New MySqlConnection("server=localhost;user=root;password='';database=index")
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Try
            Dim a As String
            Dim b As Integer
            a = txt_address.Text
            b = txt_phone.Text
            txt_sentphone.Text = b
            txt_sendaress.Text = a
            txt_email.Focus()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub formCustormer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        showdata()
    End Sub
    Sub showdata()
        Try
            Dim table As New DataTable
            Dim adapter As New MySqlDataAdapter("SELECT  cid,nane, surname, adress, phone,  sendaddress, sendphone ,email FROM customer", connection)
            adapter.Fill(table)
            viewdata_custormer.DataSource = table
            viewdata_custormer.RowHeadersVisible = True
            Me.viewdata_custormer.DefaultCellStyle.Font = New Font("Phetsarath OT", 12)
            Me.viewdata_custormer.ColumnHeadersDefaultCellStyle.Font = New Font("Phetsarath OT", 13)
            Dim header() As String = {"ລະຫັດ", "ຊື່", "ນາມສະກຸນ", "ທີ່ຢູ່", "ເບີ", "ສະຖະທີ່ສົ່ງ", "ເບີໂທ", "ອີເມວ"}
            For i As Integer = 0 To viewdata_custormer.ColumnCount - 1
                viewdata_custormer.Columns(i).HeaderText = header(i)
            Next


        Catch ex As Exception

        End Try

    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        Try
            If txt_name.Text = "" Or txt_surname.Text = "" Or txt_phone.Text = "" Or txt_address.Text = "" Or txt_sendaress.Text = "" Or txt_sentphone.Text = "" Then
                MsgBox("ກາລຸນປ້ອນຂໍ້ມູນໃຫ້ຄົບ!")

                Return

            End If
            If connection.State = ConnectionState.Closed Then
                connection.Open()
                Dim cmd_insert As New MySqlCommand
                cmd_insert.Connection = connection
                cmd_insert.CommandType = CommandType.Text
                cmd_insert.CommandText = " INSERT INTO customer ( nane, surname, adress, phone, email, sendaddress, sendphone) VALUES (@nane, @surname, @adress, @phone, @email, @sendaddress, @sendphone)"

                cmd_insert.Parameters.AddWithValue("@nane", txt_name.Text.Trim)
                cmd_insert.Parameters.AddWithValue("@surname", txt_surname.Text.Trim)
                cmd_insert.Parameters.AddWithValue("@adress", txt_address.Text.Trim)
                cmd_insert.Parameters.AddWithValue("@phone", txt_phone.Text.Trim)
                cmd_insert.Parameters.AddWithValue("@email", txt_email.Text.Trim)
                cmd_insert.Parameters.AddWithValue("@sendaddress", txt_sendaress.Text.Trim)
                cmd_insert.Parameters.AddWithValue("@sendphone", txt_sentphone.Text.Trim)
                If cmd_insert.ExecuteNonQuery() = 0 Then
                    MsgBox("ການບັນທຶກບໍ່ສຳເລັດ!")
                End If
                connection.Close()
                showdata()
                clear()
                txt_name.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles btn_update.Click
        Try
            If txt_id.Text = "" Then
                Return
            End If
            If connection.State = ConnectionState.Closed Then
                connection.Open()

                Dim cmd_update As New MySqlCommand
                cmd_update.Connection = connection
                cmd_update.CommandType = CommandType.Text
                cmd_update.CommandText = " update customer set  nane=@nane, surname=@surname, adress=@adress, phone=@phone, email=@email, sendaddress=@sendaddress, sendphone=@sendphone where cid=@cid"
                cmd_update.Parameters.AddWithValue("@cid", txt_id.Text.Trim)
                cmd_update.Parameters.AddWithValue("@nane", txt_name.Text.Trim)
                cmd_update.Parameters.AddWithValue("@surname", txt_surname.Text.Trim)
                cmd_update.Parameters.AddWithValue("@adress", txt_address.Text.Trim)
                cmd_update.Parameters.AddWithValue("@phone", txt_phone.Text.Trim)
                cmd_update.Parameters.AddWithValue("@email", txt_email.Text.Trim)
                cmd_update.Parameters.AddWithValue("@sendaddress", txt_sendaress.Text.Trim)
                cmd_update.Parameters.AddWithValue("@sendphone", txt_sentphone.Text.Trim)
                If cmd_update.ExecuteNonQuery() = 0 Then
                    MsgBox("ການປ່ຽນແປງບໍ່ສຳເລັດ")
                End If
                connection.Close()
                showdata()
                clear()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub clear()
        Try
            txt_id.Text = ""
            txt_name.Text = ""
            txt_surname.Text = ""
            txt_address.Text = ""
            txt_phone.Text = ""
            txt_sendaress.Text = ""
            txt_sentphone.Text = ""
            txt_email.Text = ""
            txt_search.Text = ""

        Catch ex As Exception

        End Try

    End Sub

    Private Sub viewdata_custormer_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles viewdata_custormer.CellClick
        Try
            Dim selected As DataGridViewRow
            selected = viewdata_custormer.Rows(e.RowIndex)
            txt_id.Text = selected.Cells(0).Value
            txt_name.Text = selected.Cells(1).Value
            txt_surname.Text = selected.Cells(2).Value
            txt_address.Text = selected.Cells(3).Value
            txt_phone.Text = selected.Cells(4).Value
            txt_sendaress.Text = selected.Cells(5).Value
            txt_sentphone.Text = selected.Cells(6).Value
            txt_email.Text = selected.Cells(7).Value
            ' cid,nane, surname, adress, phone,  sendaddress, sendphone ,email 

        Catch ex As Exception

        End Try
    End Sub
    Friend Function confirm(text As String, Optional title As String = "ຍືນຍັນ")
        Return MsgBox(text, vbQuestion + vbYesNo, title)
    End Function
    Sub msg_ok(text As String, Optional title As String = "ສຳເລັດ")
        MsgBox(text, vbInformation + vbOKOnly, title)
    End Sub
    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click
        If confirm("ເຈົ້າຕ້ອງການທີ່ຈະລົບ ຫຼື ບໍ?") = vbYes Then


            Try
                If txt_id.Text = "" Then
                    Return
                End If
                If connection.State = ConnectionState.Closed Then
                    connection.Open()
                    Dim cmd_delete As New MySqlCommand
                    cmd_delete.Connection = connection
                    cmd_delete.CommandType = CommandType.Text
                    '  cmd_delete.CommandText = " delete from customer  where cid=@cid)"
                    cmd_delete.CommandText = "Delete from customer  where cid=@cid"
                    cmd_delete.Parameters.AddWithValue("@cid", txt_id.Text.Trim)

                    If cmd_delete.ExecuteNonQuery() = 0 Then
                        MsgBox("ການລົບບໍ່ສຳເລັດ")
                    End If
                    connection.Close()
                    showdata()
                    clear()
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub txt_search_TextChanged(sender As Object, e As EventArgs) Handles txt_search.TextChanged
        Try
            Dim search_commnd As New MySqlCommand("SELECT * FROM customer where nane =@name ", connection)
            search_commnd.Parameters.Add("@name ", MySqlDbType.VarChar).Value = txt_search.Text
            Dim table As New DataTable
            Dim adapter As New MySqlDataAdapter(search_commnd)
            adapter.Fill(table)
            viewdata_custormer.DataSource = table

            txt_search.BorderColor = Color.Gainsboro
            If txt_search.Text = "" Then
                showdata()

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        clear()
        showdata()

    End Sub

    Private Sub Guna2Button4_Click_1(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        Me.Close()

    End Sub
End Class