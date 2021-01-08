Imports System.IO
Imports MySql.Data.MySqlClient

Public Class ManageUser
    ' function chack sql
    Dim connection As New MySqlConnection("server=localhost;user=root;password='';database=index")
    Function exeCommand(ByVal cmd As MySqlCommand) As Boolean
        If connection.State = ConnectionState.Closed Then
            connection.Open()

            If cmd.ExecuteNonQuery() = 1 Then
                Return True
            End If
        Else
            Return True
        End If
        If connection.State = ConnectionState.Open Then
            connection.Close()
        End If
    End Function
    Private Sub ManageUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        showdata()
        adminCount()
        sellerCount()
        blockCount()




    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        'If txt_id.Text = "" Then
        '    MsgBox("hello")
        '    Return
        'End If
        'Try
        '    Dim insert As New MySqlCommand("insert into manageusers(MID, name, surname, age, gender, address, mail, password, status, pic) value(@id, ????????)", connection)
        '    insert.Parameters.AddWithValue("@id", MySqlDbType.Int64).Value = txt_id.Text
        '    insert.Parameters.Add("?", MySqlDbType.VarChar).Value = txt_name.Text
        '    insert.Parameters.Add("?", MySqlDbType.VarChar).Value = txt_surname.Text
        '    insert.Parameters.Add("?", MySqlDbType.VarChar).Value = txt_name.Text

        '    If exeCommand(insert) Then
        '        MsgBox("saved")
        '        viewAlluser.Refresh()
        '    Else
        '        MsgBox("data don't  saved")
        '    End If


        'Catch ex As Exception
        '    MsgBox("save to sql error !!!")
        'End Try
        '***********************************
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            Dim cmd_insert As New MySqlCommand
            cmd_insert.Connection = connection
            cmd_insert.CommandType = CommandType.Text
            cmd_insert.CommandText = " INSERT INTO manageusers (name, surname, age, gender, address, mail, password, status, pic) VALUES (@name, @surname, @age, @gender, @address, @mail, @password, @status, @pic)"
            cmd_insert.Parameters.AddWithValue("@name", txt_name.Text.Trim)
            cmd_insert.Parameters.AddWithValue("@surname", txt_surname.Text.Trim)
            cmd_insert.Parameters.AddWithValue("@age", txt_age.Text.Trim)
            cmd_insert.Parameters.AddWithValue("@address", txt_address.Text.Trim)
            cmd_insert.Parameters.AddWithValue("@mail", txt_mail.Text.Trim)
            cmd_insert.Parameters.AddWithValue("@password", txt_password.Text.Trim)
            cmd_insert.Parameters.AddWithValue("@status", cobo_stastu.Text)
            Dim ms As New MemoryStream
            picture_user.Image.Save(ms, picture_user.Image.RawFormat)
            cmd_insert.Parameters.Add("@pic", MySqlDbType.Blob).Value = ms.ToArray

            Dim sex As String
            If radio_man.Checked = True Then
                sex = "ຊາຍ"
            Else
                sex = "ຍິງ"
            End If
            cmd_insert.Parameters.AddWithValue("@gender", sex.Trim)

            If cmd_insert.ExecuteNonQuery() = 1 Then
                MsgBox("yet")
            End If
            connection.Close()

        Catch ex As Exception
            MsgBox("error ! " + ex.Message)
        End Try
        showdata()
        clear()
    End Sub

    Private Sub brn_update_Click(sender As Object, e As EventArgs) Handles brn_update.Click


        If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            Dim cmd_update As New MySqlCommand
            cmd_update.Connection = connection
        cmd_update.CommandType = CommandType.Text
        If picture_user.Image.Equals("") Then
            cmd_update.CommandText = " UPDATE manageusers SET name=@name,surname=@surname,age=@age,gender=@gender,address=@address,mail=@mail,password=@password,status=@status WHERE MID = @id"
        Else
            cmd_update.CommandText = " UPDATE manageusers SET name=@name,surname=@surname,age=@age,gender=@gender,address=@address,mail=@mail,password=@password,status=@status,pic=@pic WHERE MID = @id"

        End If
        cmd_update.Parameters.AddWithValue("@id", txt_id.Text.Trim)
        cmd_update.Parameters.AddWithValue("@name", txt_name.Text.Trim)
            cmd_update.Parameters.AddWithValue("@surname", txt_surname.Text.Trim)
            cmd_update.Parameters.AddWithValue("@age", txt_age.Text.Trim)
            cmd_update.Parameters.AddWithValue("@address", txt_address.Text.Trim)
            cmd_update.Parameters.AddWithValue("@mail", txt_mail.Text.Trim)
            cmd_update.Parameters.AddWithValue("@password", txt_password.Text.Trim)
            cmd_update.Parameters.AddWithValue("@status", cobo_stastu.Text)
            Dim ms As New MemoryStream
                picture_user.Image.Save(ms, picture_user.Image.RawFormat)
            cmd_update.Parameters.Add("@pic", MySqlDbType.Blob).Value = ms.ToArray

            Dim sex As String
                If radio_man.Checked = True Then
            sex = "ຊາຍ"
        Else
            sex = "ຍິງ"
        End If
            cmd_update.Parameters.AddWithValue("@gender", sex.Trim)

            If cmd_update.ExecuteNonQuery() = 1 Then
            MsgBox("Complete !!!")
        End If
            connection.Close()


        showdata()
        clear()
    End Sub

    Private Sub btn_delete_Click(sender As Object, e As EventArgs) Handles btn_delete.Click
        Try
            Dim delete As New MySqlCommand("delete form manageusers where  id =?", connection)
            delete.Parameters.Add("?", MySqlDbType.Int64).Value = txt_id.Text

            If exeCommand(delete) Then
                MsgBox("deleted")
                viewAlluser.Refresh()
            Else
                MsgBox("data don't  deleted")
            End If


        Catch ex As Exception
            MsgBox("deleted to sql error !!!" + ex.Message)
        End Try

        showdata()
        clear()
    End Sub

    Private Sub picture_Click(sender As Object, e As EventArgs) Handles picture_user.Click
        openfile_user.Filter = "Choose Image(*.JPG;*.PNG)|*.jpg;*.png"
        If openfile_user.ShowDialog = DialogResult.OK Then
            Dim img As Image
            img = Image.FromFile(openfile_user.FileName)

            picture_user.Image = img


        End If

        'Dim opf As New OpenFileDialog

        'opf.Filter = "Choose Image(*.JPG;*.PNG)|*.jpg;*.png"

        'If opf.ShowDialog = Windows.Forms.DialogResult.OK Then

        '    picture_user.Image = Image.FromFile(opf.FileName)

        'End If


    End Sub

    Private Sub txt_age_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_age.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MessageBox.Show("ກາລຸນາປ່ອນພຽງຕົວເລກເທົ່ານັ້ນ!.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Handled = True
        End If
    End Sub

    Private Sub viewAlluser_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles viewAlluser.CellClick

        Try
            Dim show As New MySqlCommand("selecte  form  manageusers where pic =@pic ", connection)

            Dim selected As DataGridViewRow
            selected = viewAlluser.Rows(e.RowIndex)
            txt_id.Text = selected.Cells(0).Value
            txt_name.Text = selected.Cells(1).Value
            txt_surname.Text = selected.Cells(2).Value
            txt_age.Text = selected.Cells(3).Value
            Dim gender As String = selected.Cells(4).Value
            If (gender = "ຊາຍ") Then
                radio_man.Checked = True
            Else
                radio_woman.Checked = True
            End If
            txt_address.Text = selected.Cells(5).Value
            txt_mail.Text = selected.Cells(6).Value
            txt_password.Text = selected.Cells(7).Value
            cobo_stastu.Text = selected.Cells(8).Value
            Dim pic() As Byte = selected.Cells(9).Value
            picture_user.Image = Image.FromStream(New MemoryStream(CType(pic, Byte())))

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Guna2ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Guna2ComboBox2.SelectedIndexChanged
        If connection.State = ConnectionState.Closed Then
            connection.Open()
        End If


        If Guna2ComboBox2.SelectedItem = "All" Then
            showdata()
            clear()

            Return
        End If

        Try
            Dim SQl As String = "SELECT * FROM manageusers where status='" & Guna2ComboBox2.Text & "'"
            Dim table As New DataTable()
            Dim adapter As New MySqlDataAdapter(SQl, connection)
            adapter.Fill(table)
            viewAlluser.DataSource = table
            Me.viewAlluser.DefaultCellStyle.Font = New Font("Phetsarath OT", 12)
            Me.viewAlluser.ColumnHeadersDefaultCellStyle.Font = New Font("Phetsarath OT", 13)
            connection.Close()
        Catch ex As Exception

        End Try

    End Sub
    Sub showdata()
        Try
            Dim table As New DataTable
            Dim adapter As New MySqlDataAdapter("SELECT * FROM manageusers", connection)
            adapter.Fill(table)
            viewAlluser.DataSource = table
            viewAlluser.RowHeadersVisible = True
            Me.viewAlluser.DefaultCellStyle.Font = New Font("Phetsarath OT", 12)
            Me.viewAlluser.ColumnHeadersDefaultCellStyle.Font = New Font("Phetsarath OT", 13)
            viewAlluser.Columns(0).HeaderText = "ລຳດັບ"
            viewAlluser.Columns(1).HeaderText = "ຊື່"
            viewAlluser.Columns(2).HeaderText = "ນາມສະກຸນ"
            viewAlluser.Columns(3).HeaderText = "ອາຍຸ"
            viewAlluser.Columns(4).HeaderText = "ເພດ"
            viewAlluser.Columns(5).HeaderText = "ທີຢູ່"
            viewAlluser.Columns(6).HeaderText = "ອີເມວ"
            viewAlluser.Columns(7).HeaderText = "ລະຫັດ"
            viewAlluser.Columns(8).HeaderText = "ສະຖານະ"
            viewAlluser.Columns(9).HeaderText = "ຮູບ"

            'viewAlluser.Columns(0).Width = 50
            'viewAlluser.Columns(1).Width = 110
            'viewAlluser.Columns(2).Width = 120
            'viewAlluser.Columns(3).Width = 70
            'viewAlluser.Columns(4).Width = 70
            'viewAlluser.Columns(5).Width = 120
            'viewAlluser.Columns(6).Width = 130
            ' viewAlluser.Columns(7).Width = 0
            'viewAlluser.Columns(8).Width = 110
            'viewAlluser.Columns(9).Width = 200



        Catch ex As Exception

        End Try

    End Sub
    Sub clear()
        txt_id.Text = ""
        txt_name.Text = ""
        cobo_stastu.Text = Nothing
        txt_surname.Text = ""
        txt_age.Text = ""
        txt_mail.Text = ""
        txt_password.Text = ""
        txt_address.Text = ""
        showdata()


    End Sub

    Private Sub label_admin_Click(sender As Object, e As EventArgs) Handles label_admin.Click
        clear()

    End Sub


    Sub adminCount()
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            Dim cmd_insert As New MySqlCommand
            cmd_insert.Connection = connection
            cmd_insert.CommandType = CommandType.Text
            cmd_insert.CommandText = "Select COUNT(*) FROM manageusers WHERE status Like 'admin'"
            Dim a As String
            a = cmd_insert.ExecuteScalar()

            label_admin.Text = "Admin :" + a




            connection.Close()

        Catch ex As Exception
            MsgBox("error ! " + ex.Message)
        End Try
    End Sub


    Sub sellerCount()
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            Dim cmd_insert As New MySqlCommand
            cmd_insert.Connection = connection
            cmd_insert.CommandType = CommandType.Text
            cmd_insert.CommandText = "Select COUNT(*) FROM manageusers WHERE status Like 'seller'"
            Dim a As String
            a = cmd_insert.ExecuteScalar()

            Guna2Button1.Text = "Seller :" + a




            connection.Close()

        Catch ex As Exception
            MsgBox("error ! " + ex.Message)
        End Try
    End Sub


    Sub blockCount()
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            Dim cmd_insert As New MySqlCommand
            cmd_insert.Connection = connection
            cmd_insert.CommandType = CommandType.Text
            cmd_insert.CommandText = "Select COUNT(*) FROM manageusers WHERE status Like 'block'"
            Dim a As String
            a = cmd_insert.ExecuteScalar()

            Guna2Button3.Text = "Block :" + a




            connection.Close()

        Catch ex As Exception
            MsgBox("error ! " + ex.Message)
        End Try
    End Sub



    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        clear()

    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        Me.Close()

    End Sub
End Class