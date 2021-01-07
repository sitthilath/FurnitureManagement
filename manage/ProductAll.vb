Imports System.ComponentModel
Imports MySql.Data.MySqlClient

Public Class ProductAll
    Dim connection As New MySqlConnection("server=localhost;user=root;password='';database=index")
    Dim dr As MySqlDataReader

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Try
            connection.Open()

            If txt_id.Text = "" Or txt_name.Text = "" Then
                Return
            End If


            Dim cmd_select As New MySqlCommand
            cmd_select.CommandText = "SELECT * from product where id='" & txt_id.Text & "'"
            cmd_select.Connection = connection

            dr = cmd_select.ExecuteReader()
            Dim Setpid As String
            If dr.HasRows() Then
                dr.Read()
                Setpid = dr.Item("id")
            End If
            dr.Close()

            'Check Product is Exist Select For Sell 
            Dim cmd_checkExist As New MySqlCommand
            cmd_checkExist.CommandText = "SELECT count(*) from product where id = @pid"
            cmd_checkExist.Connection = connection
            cmd_checkExist.Parameters.AddWithValue("@pid", Setpid)
            Dim count = Convert.ToInt32(cmd_checkExist.ExecuteScalar())
            'End Check

            If count > 0 Then
                'Get QTY set to variable
                Dim cmd_qty As New MySqlCommand
                cmd_qty.CommandText = "SELECT * from product where id='" & txt_id.Text & "'"
                cmd_qty.Connection = connection

                Dim reader As MySqlDataReader
                reader = cmd_qty.ExecuteReader()

                Dim qty As Integer

                If reader.HasRows() Then
                    reader.Read()
                    qty = reader.Item("qty")
                End If
                reader.Close()
                'End Get QTY set to variable

                'If Product Exist QTY + 1
                Dim qtys As Integer
                qtys = txt_qty.Text
                Dim cmd_updateQTY As New MySqlCommand
                cmd_updateQTY.Connection = connection
                cmd_updateQTY.CommandType = CommandType.Text
                cmd_updateQTY.CommandText = " Update `product` set qty=@qty where id=@Pid"
                cmd_updateQTY.Parameters.AddWithValue("@Pid", Setpid)
                cmd_updateQTY.Parameters.AddWithValue("@qty", qty + qtys)

                cmd_updateQTY.ExecuteScalar()
                'End If Product Exist QTY + 1


            Else

                Dim cmd_insert As New MySqlCommand
                cmd_insert.Connection = connection
                cmd_insert.CommandType = CommandType.Text
                cmd_insert.CommandText = " INSERT INTO product (id, Pname, qty, price, type_catagory) VALUES (@PID, @Pname, @qty, @price, @type_catagory)"
                cmd_insert.Parameters.AddWithValue("@PID", txt_id.Text.Trim)
                cmd_insert.Parameters.AddWithValue("@Pname", txt_name.Text.Trim)
                cmd_insert.Parameters.AddWithValue("@qty", txt_qty.Text.Trim)
                cmd_insert.Parameters.AddWithValue("@price", txt_price.Text.Trim)
                cmd_insert.Parameters.AddWithValue("@type_catagory", combo_catagory.SelectedValue)
                cmd_insert.ExecuteScalar()
            End If





            clear()
            txt_id.Focus()
        Catch ex As Exception
            '     MsgBox("error ! " + ex.Message)
        Finally
            connection.Close()
        End Try
        showdata()
    End Sub


    Private Sub ProductAll_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cat()
        showdata()

    End Sub
    'show item from sql (combobox)
    Sub cat()
        Try
            Dim connection As New MySqlConnection("server=localhost;user=root;password='';database=index")
            Dim table As New DataTable
            Dim adapter As New MySqlDataAdapter("SELECT * FROM catagory  ", connection)
            adapter.Fill(table)
            combo_catagory.DataSource = table
            combo_catagory.DisplayMember = "type_catagory"
            combo_catagory.ValueMember = "CID"


        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_price_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_price.KeyPress

        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MessageBox.Show("ກາລຸນາປ່ອນພຽງຕົວເລກເທົ່ານັ້ນ!.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Handled = True

        End If
    End Sub

    Private Sub txt_qty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_qty.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MessageBox.Show("ກາລຸນາປ່ອນພຽງຕົວເລກເທົ່ານັ້ນ!.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Handled = True
        End If
    End Sub

    Private Sub txt_id_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_id.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MessageBox.Show("ກາລຸນາປ່ອນພຽງຕົວເລກເທົ່ານັ້ນ!.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Handled = True
        End If
    End Sub


    Public Sub addItems(ByVal col As AutoCompleteStringCollection)
        col.Add("Abel")
        col.Add("Bing")
        col.Add("Catherine")
        col.Add("Varghese")
        col.Add("John")
        col.Add("Kerry")
    End Sub



    Private Sub Guna2Button1_Click_1(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        cat()
        clear()
        showdata()


    End Sub
    Sub clear()
        txt_id.Text = ""
        txt_name.Text = ""
        txt_qty.Text = ""
        txt_price.Text = ""
        txt_search.Text = ""

    End Sub
    Sub showdata()
        Try
            connection.Open()
            Dim table As New DataTable
            ' Dim adapter As New MySqlDataAdapter("SELECT `id`, `Pname`, `qty`, `price`, catagory.type_catagory FROM `product`,catagory where product.type_catagory = catagory.CID", connection)
            Dim adapter As New MySqlDataAdapter("select id, Pname, qty, price, catagory.type_catagory from product INNER JOIN catagory ON catagory.CID = product.type_catagory", connection)
            adapter.Fill(table)
            dataviewProduct.DataSource = table
            dataviewProduct.RowHeadersVisible = True
            Me.dataviewProduct.DefaultCellStyle.Font = New Font("Phetsarath OT", 12)
            Me.dataviewProduct.ColumnHeadersDefaultCellStyle.Font = New Font("Phetsarath OT", 13)
            dataviewProduct.Columns(0).HeaderText = "ລະຫັດ"
            dataviewProduct.Columns(1).HeaderText = "ຊື່"
            dataviewProduct.Columns(2).HeaderText = "ຈຳນວນ"
            dataviewProduct.Columns(3).HeaderText = "ລາຄາ"
            dataviewProduct.Columns(4).HeaderText = "ປະເພດ"



        Catch ex As Exception
            MsgBox("Error!.." + ex.Message)
        Finally
            connection.Close()
        End Try
    End Sub

    Private Sub btn_sav_Click(sender As Object, e As EventArgs) Handles btn_sav.Click
        Try
            connection.Open()
            If txt_id.Text = "" Then
                MsgBox("ກາລຸນາເລືອກຂໍ້ມູນທີ່ຈະລົບ!")
                Return
            End If



            Dim cmd_insert As New MySqlCommand
            cmd_insert.Connection = connection
            cmd_insert.CommandType = CommandType.Text
            cmd_insert.CommandText = " update product set Pname= @Pname,qty= @qty,price= @price,type_catagory= @type_catagory where id=@pid"
            cmd_insert.Parameters.AddWithValue("@pid", txt_id.Text.Trim)
            cmd_insert.Parameters.AddWithValue("@Pname", txt_name.Text.Trim)
            cmd_insert.Parameters.AddWithValue("@qty", txt_qty.Text.Trim)
            cmd_insert.Parameters.AddWithValue("@price", txt_price.Text.Trim)
            cmd_insert.Parameters.AddWithValue("@type_catagory", combo_catagory.SelectedValue)
            cmd_insert.ExecuteScalar()


        Catch ex As Exception
            '  MsgBox("error ! " + ex.Message)
        Finally
            connection.Close()
        End Try
        showdata()
    End Sub

    Private Sub dataviewProduct_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataviewProduct.CellClick
        Try
            Dim selected As DataGridViewRow
            selected = dataviewProduct.Rows(e.RowIndex)
            txt_id.Text = selected.Cells(0).Value
            txt_name.Text = selected.Cells(1).Value
            txt_qty.Text = selected.Cells(2).Value
            txt_price.Text = selected.Cells(3).Value
            combo_catagory.Text = selected.Cells(4).Value

        Catch ex As Exception

        End Try
    End Sub
    Friend Function confirm(text As String, Optional title As String = "ຍືນຍັນ")
        Return MsgBox(text, vbQuestion + vbYesNo, title)
    End Function
    Sub msg_ok(text As String, Optional title As String = "ສຳເລັດ")
        MsgBox(text, vbInformation + vbOKOnly, title)
    End Sub

    Private Sub btn_delete_Click(sender As Object, e As EventArgs) Handles btn_delete.Click
        If confirm("ເຈົ້າຕ້ອງການທີ່ຈະລົບ ຫຼື ບໍ?") = vbYes Then


            Try
                connection.Open()

                If txt_id.Text = "" Then
                    MsgBox("ກາລຸນາປ້ອນຂໍ້ມູນໃຫ້ຄົບ!")
                    Return
                End If
                Dim cmd_delete As New MySqlCommand
                cmd_delete.Connection = connection
                cmd_delete.CommandType = CommandType.Text
                cmd_delete.CommandText = "Delete from product  where id=@id"
                cmd_delete.Parameters.AddWithValue("@id", txt_id.Text.Trim)
                If cmd_delete.ExecuteNonQuery() = 0 Then
                    MsgBox("ແກ້ໄຂຂໍ້ມູນສຳເລັດ")
                End If




                clear()
            Catch ex As Exception
                MessageBox.Show("error syatem" + ex.Message)
            Finally
                connection.Close()
            End Try
        End If
        showdata()
    End Sub

    Private Sub txt_search_TextChanged(sender As Object, e As EventArgs) Handles txt_search.TextChanged

        Try
            connection.Open()
            Dim search_commnd As New MySqlCommand("select id, Pname, qty, price, catagory.type_catagory from product INNER JOIN catagory ON catagory.CID = product.type_catagory where id = @id OR Pname = @id  ", connection)
            search_commnd.Parameters.Add("@id", MySqlDbType.VarChar).Value = txt_search.Text

            Dim table As New DataTable
            Dim adapter As New MySqlDataAdapter(search_commnd)
            adapter.Fill(table)
            dataviewProduct.DataSource = table
            If (table.Rows.Count > 0) Then
                txt_id.Text = table(0)(0)
                txt_name.Text = table(0)(1)
                txt_qty.Text = table(0)(2)
                txt_price.Text = table(0)(3)
                combo_catagory.Text = table(0)(4)
                txt_search.BorderColor = Color.Gainsboro

            ElseIf txt_search.Text = "" Then


                Dim table2 As New DataTable
                Dim adapter2 As New MySqlDataAdapter("select id, Pname, qty, price, catagory.type_catagory from product INNER JOIN catagory ON catagory.CID = product.type_catagory ", connection)
                adapter2.Fill(table2)
                dataviewProduct.DataSource = table2
                dataviewProduct.RowHeadersVisible = True
                Me.dataviewProduct.DefaultCellStyle.Font = New Font("Phetsarath OT", 12)
                Me.dataviewProduct.ColumnHeadersDefaultCellStyle.Font = New Font("Phetsarath OT", 13)
                txt_id.Text = ""
                txt_name.Text = ""
                txt_qty.Text = ""
                txt_price.Text = ""

                txt_search.BorderColor = Color.Gainsboro

            Else
                txt_id.Text = ""
                txt_name.Text = ""
                txt_qty.Text = ""
                txt_price.Text = ""
                txt_search.BorderColor = Color.Red
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            connection.Close()

        End Try




    End Sub




    Private Sub Guna2ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
        cat()
    End Sub

    Private Sub combo_catagory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combo_catagory.SelectedIndexChanged

    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        txt_id.Clear()
        txt_name.Clear()
        txt_qty.Clear()
        txt_price.Clear()

    End Sub


End Class