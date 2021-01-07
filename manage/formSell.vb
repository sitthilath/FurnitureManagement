Imports MySql.Data.MySqlClient

Public Class formSell
    Dim connection As New MySqlConnection("server=localhost;user=root;password='';database=index")
    Dim cmd As MySqlCommand
    Dim dr As MySqlDataReader
    Dim da As MySqlDataAdapter
    Dim ds As DataSet
    Dim sql As String
    Dim table As New DataTable()
    Dim loopMoney As Integer

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub formSell_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txt_Barcode.Focus()

        Timer1.Start()
        'labelDate.Text = DateTime.Now.ToLongDateString("dd/MM/yyyy")
        labelDate.Text = DateTime.Now.ToString("ວັນທີ : " + "dd/MM/yyyy")
        labelTime.Text = DateTime.Now.ToLongTimeString()
        'show name in label



        show_data()


        '/////////////////
        loopMoneys()

        'Load bill_id setting
        showbill_id.Text = My.Settings.bill_id
        'end
    End Sub


    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click

        Me.Dispose()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        labelTime.Text = DateTime.Now.ToLongTimeString()
        Timer1.Start()

    End Sub

    Private Sub txt_Barcode_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Barcode.KeyDown
        Try

            If e.KeyData = Keys.Enter Then

                If connection.State = ConnectionState.Closed Then
                    connection.Open()
                End If

                Dim cmd_select As New MySqlCommand
                cmd_select.CommandText = "SELECT * from product where id='" & txt_Barcode.Text & "'"
                cmd_select.Connection = connection

                dr = cmd_select.ExecuteReader()

                Dim Setpid, Setpname As String
                Dim Setqty, Settype_catagory, Pqty As Integer
                Dim Setprice As Double


                If dr.HasRows Then
                    dr.Read()
                    Pqty = dr.Item("qty")

                    Setpid = dr.Item("id")
                    Setpname = dr.Item("Pname")
                    Setqty = txt_amoung.Text
                    Setprice = dr.Item("price")
                    Settype_catagory = dr.Item("type_catagory")


                End If
                dr.Close()

                'Check Product is Exist Select For Sell 
                Dim cmd_checkExist As New MySqlCommand
                cmd_checkExist.CommandText = "SELECT count(*) from listsell where Pid = @pid"
                cmd_checkExist.Connection = connection
                cmd_checkExist.Parameters.AddWithValue("@pid", Setpid)
                Dim count = Convert.ToInt32(cmd_checkExist.ExecuteScalar())
                'End Check



                If txt_Barcode.Text = "" Then
                    Return
                ElseIf Setpid = "" Then
                    Return
                ElseIf Setpname = "" Then
                    Return
                ElseIf Setqty = Nothing Then
                    Return
                ElseIf Setprice = Nothing Then
                    Return
                ElseIf Settype_catagory = Nothing Then
                    Return
                ElseIf count > 0 Then


                    'Get QTY set to variable
                    Dim cmd_qty As New MySqlCommand
                    cmd_qty.CommandText = "SELECT * from listsell where Pid='" & txt_Barcode.Text & "'"
                    cmd_qty.Connection = connection

                    Dim reader As MySqlDataReader
                    reader = cmd_qty.ExecuteReader()

                    Dim qty As Integer

                    If reader.Read() Then

                        qty = reader.Item("qty")

                        reader.Close()
                    End If
                    'End Get QTY set to variable

                    'If Product Exist QTY + 1


                    Dim amoung As Integer
                    amoung = txt_amoung.Text
                    If Pqty <= qty Then

                        MsgBox("ສິນຄ້າໃນຄັງບໍ່ພຽງພໍ!")
                    ElseIf Pqty - amoung <= -1 Then
                        MsgBox("ສິນຄ້າໃນຄັງບໍ່ພຽງພໍ!")

                    Else


                        Dim cmd_updateQTY As New MySqlCommand
                        cmd_updateQTY.Connection = connection
                        cmd_updateQTY.CommandType = CommandType.Text
                        cmd_updateQTY.CommandText = " Update `listsell` set qty=@qty where Pid=@Pid"
                        cmd_updateQTY.Parameters.AddWithValue("@Pid", Setpid)
                        cmd_updateQTY.Parameters.AddWithValue("@qty", qty + amoung)




                        cmd_updateQTY.ExecuteScalar()

                        '    connection.Close()

                    End If

                    'End If Product Exist QTY + 1
                Else

                    'Insert Product To ListSell
                    Dim amoung As Integer
                    amoung = txt_amoung.Text

                    If Pqty = 0 Then
                        MsgBox("ສິນຄ້າໃນຄັງບໍ່ພຽງພໍ!")
                    ElseIf Pqty - amoung <= -1 Then
                        MsgBox("ສິນຄ້າໃນຄັງບໍ່ພຽງພໍ!")
                    Else

                        'If connection.State = ConnectionState.Closed Then
                        '    connection.Open()
                        'End If
                        Dim cmd_insert As New MySqlCommand
                        cmd_insert.Connection = connection
                        cmd_insert.CommandType = CommandType.Text
                        cmd_insert.CommandText = " INSERT INTO `listsell`( `Pid`, `Pname`, `qty`, `price`, `type_catagory`, `seller`) VALUES (@Pid,@Pname,@qty,@price,@type_catagory,@seller)"
                        cmd_insert.Parameters.AddWithValue("@Pid", Setpid)
                        cmd_insert.Parameters.AddWithValue("@Pname", Setpname)
                        cmd_insert.Parameters.AddWithValue("@qty", Setqty)
                        cmd_insert.Parameters.AddWithValue("@price", Setprice)
                        cmd_insert.Parameters.AddWithValue("@type_catagory", Settype_catagory)
                        cmd_insert.Parameters.AddWithValue("@seller", Class1.name) ' Class1.name



                        cmd_insert.ExecuteScalar()


                    End If
                    'End Insert Product To ListSell

                End If
                connection.Close()
                show_data()




                loopMoneys()


            End If


        Catch ex As Exception

        End Try

    End Sub


    Sub show_data()
        Try

            '   Dim connection As New MySqlConnection("server=localhost;user=root;password='';database=index")
            connection.Open()

            Dim table As New DataTable()
            Dim adapter As New MySqlDataAdapter("SELECT  `Pid`, `Pname`, `qty`, `price`, `type_catagory`, `seller` FROM `listsell` ", connection)
            adapter.Fill(table)
            DGVlistsell.DataSource = table
            DGVlistsell.RowHeadersVisible = True
            Me.DGVlistsell.DefaultCellStyle.Font = New Font("Phetsarath OT", 12)
            Me.DGVlistsell.ColumnHeadersDefaultCellStyle.Font = New Font("Phetsarath OT", 13)
            DGVlistsell.Columns(0).HeaderText = "ລະຫັດ"
            DGVlistsell.Columns(1).HeaderText = "ສິນຄ້າ"
            DGVlistsell.Columns(2).HeaderText = "ຈຳນວນ"
            DGVlistsell.Columns(3).HeaderText = "ລາຄາ"
            DGVlistsell.Columns(4).HeaderText = "ປະເພດ"
            DGVlistsell.Columns(5).HeaderText = "ຜູ້ຂາຍ"
            connection.Close()
        Catch ex As Exception
            MsgBox("Connect Database fail!" + ex.Message)

        End Try
    End Sub

    Private Sub Guna2Button1_Click_1(sender As Object, e As EventArgs) Handles Guna2Button1.Click







        If connection.State = ConnectionState.Closed Then
            connection.Open()
        End If
        If DGVlistsell.Rows.Count = 1 Then
            MsgBox("ບໍ່ມີລາຍການສິນຄ້າ")
            Return

        End If

        Dim i As Integer
        For i = 0 To DGVlistsell.Rows.Count - 2 Step 1

            Dim comm As New MySqlCommand
            comm.CommandText = "INSERT INTO `aftersell`(`Pid`, `Pname`, `qty`, `price`, `type_catagory`, `seller`,bill_id) VALUES (@Pid, @Pname, @qty, @price, @type_catagory, @seller,@bill_id)"
            comm.Connection = connection
            comm.Parameters.AddWithValue("@Pid", DGVlistsell.Rows(i).Cells(0).Value)
            comm.Parameters.AddWithValue("@Pname", DGVlistsell.Rows(i).Cells(1).Value)
            comm.Parameters.AddWithValue("@qty", DGVlistsell.Rows(i).Cells(2).Value)
            comm.Parameters.AddWithValue("@price", DGVlistsell.Rows(i).Cells(3).Value)
            comm.Parameters.AddWithValue("@type_catagory", DGVlistsell.Rows(i).Cells(4).Value)
            comm.Parameters.AddWithValue("@seller", DGVlistsell.Rows(i).Cells(5).Value)
            comm.Parameters.AddWithValue("@bill_id", showbill_id.Text)

            comm.ExecuteScalar()

        Next


        ' deleete stock
        Dim o As Integer
        For o = 0 To DGVlistsell.Rows.Count - 2 Step 1




            Dim comm_selectid As New MySqlCommand
            comm_selectid.CommandText = "SELECT  qty FROM product WHERE id=@id"
            comm_selectid.Connection = connection
            comm_selectid.Parameters.AddWithValue("@id", DGVlistsell.Rows(o).Cells(0).Value)



            Dim qty As Integer

            MsgBox(comm_selectid.ExecuteScalar())

            qty = comm_selectid.ExecuteScalar()

            'If dr.Read() Then
            '    qty = dr.Item("qty")
            '    dr.Close()
            'End If






            Dim comm_stock As New MySqlCommand
            comm_stock.CommandText = "update product set qty=@qty  where id=@id"
            comm_stock.Connection = connection
            comm_stock.Parameters.AddWithValue("@id", DGVlistsell.Rows(o).Cells(0).Value)
            comm_stock.Parameters.AddWithValue("@qty", qty - (DGVlistsell.Rows(o).Cells(2).Value))


            comm_stock.ExecuteScalar()


        Next


        Dim comm_delete As New MySqlCommand
        comm_delete.CommandText = "delete from  listsell"
        comm_delete.Connection = connection
        comm_delete.ExecuteScalar()

        '//////////////////////

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try


        connection.Close()

        show_data()
        loopMoneys()
        'Store bill_id to setting
        Dim bill_ids As Integer
        bill_ids = showbill_id.Text
        My.Settings.bill_id = bill_ids + 1
        My.Settings.Save()
        'end
        showbill_id.Text = My.Settings.bill_id
    End Sub



    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        Try
            'delete all item
            connection.Open()
            Dim comm_delete As New MySqlCommand
            comm_delete.CommandText = "delete from listsell "
            comm_delete.Connection = connection
            comm_delete.ExecuteScalar()
            connection.Close()
            show_data()


            loopMoneys()


        Catch ex As Exception

        End Try
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Try
            'delete one item
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            Dim comm_delete As New MySqlCommand
            comm_delete.CommandText = "delete from listsell where Pid=@pid"
            comm_delete.Connection = connection
            comm_delete.Parameters.AddWithValue("@pid", txt_Barcode.Text)
            comm_delete.ExecuteScalar()
            connection.Close()
            show_data()


            loopMoneys()


        Catch ex As Exception

        End Try
    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click


        Bills.Show()

    End Sub

    Private Sub btnCheckCus_Click(sender As Object, e As EventArgs) Handles btnCheckCus.Click
        Try
            connection.Open()
            'Check CusID is Exist Select For Sell 
            Dim cmd_checkExist As New MySqlCommand
            cmd_checkExist.CommandText = "SELECT count(*) from customer where cid = @cid"
            cmd_checkExist.Connection = connection
            cmd_checkExist.Parameters.AddWithValue("@cid", Guna2TextBox1.Text)
            Dim count = Convert.ToInt32(cmd_checkExist.ExecuteScalar())
            'End Check
            If count >= 1 Then
                MsgBox("Complete")

                'show info customer
                Dim cmd_info As New MySqlCommand
                cmd_info.CommandText = "SELECT * from customer where cid = @cid"
                cmd_info.Connection = connection
                cmd_info.Parameters.AddWithValue("@cid", Guna2TextBox1.Text)
                dr = cmd_info.ExecuteReader()

                If dr.Read() Then
                    label_name.Text = dr.Item("nane")
                    Label_surname.Text = dr.Item("surname")
                    label_address.Text = dr.Item("adress")
                    label_phone.Text = dr.Item("adress")
                    label_email.Text = dr.Item("email")
                    label_sendadress.Text = dr.Item("sendaddress")
                    label_phoneadress.Text = dr.Item("sendphone")

                End If
                dr.Close()
            Else
                MsgBox("No Result")
            End If




            connection.Close()



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub



    Private Sub DGVlistsell_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVlistsell.CellClick
        Try
            Dim selected As DataGridViewRow
            selected = DGVlistsell.Rows(e.RowIndex)
            txt_Barcode.Text = selected.Cells(0).Value
            txt_amoung.Text = selected.Cells(2).Value
        Catch ex As Exception
            MsgBox("ກາລຸນາເລືອກສິນຄ້າ")

        End Try
    End Sub

    Private Sub btn_UpdateAmoung_Click(sender As Object, e As EventArgs) Handles btn_UpdateAmoung.Click

        Try

            connection.Open()
            Dim cmd_select As New MySqlCommand
            cmd_select.CommandText = "SELECT * from product where id='" & txt_Barcode.Text & "'"
            cmd_select.Connection = connection
            dr = cmd_select.ExecuteReader()

            Dim Pqty As Integer

            If dr.HasRows Then
                dr.Read()
                Pqty = dr.Item("qty")
            End If
            dr.Close()

            Dim amoung As Integer
            amoung = txt_amoung.Text

            If Pqty = 0 Then
                MsgBox("ສິນຄ້າໃນຄັງບໍ່ພຽງພໍ!")
            ElseIf Pqty - amoung <= -1 Then
                MsgBox("ສິນຄ້າໃນຄັງບໍ່ພຽງພໍ!")
            Else
                Dim cmd_update As New MySqlCommand
                cmd_update.Connection = connection
                cmd_update.CommandType = CommandType.Text
                cmd_update.CommandText = " update listsell set qty=@qty where Pid=@pid"
                cmd_update.Parameters.AddWithValue("@pid", txt_Barcode.Text)
                cmd_update.Parameters.AddWithValue("@qty", amoung)
                cmd_update.ExecuteScalar()
            End If

            connection.Close()
            loopMoneys()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        show_data()

    End Sub


    Sub loopMoneys()
        Dim money As Double = 0
        For loopMoney = 0 To DGVlistsell.Rows.Count - 2 Step 1
            money += DGVlistsell.Rows(loopMoney).Cells(3).Value * DGVlistsell.Rows(loopMoney).Cells(2).Value
        Next
        labelKip.Text = money.ToString()
        labelDolar.Text = (money / 8000).ToString
    End Sub

    Private Sub txt_Barcode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_Barcode.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MessageBox.Show("ກາລຸນາປ່ອນພຽງຕົວເລກເທົ່ານັ້ນ!.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Handled = True
        End If
    End Sub

    Private Sub txt_amoung_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_amoung.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MessageBox.Show("ກາລຸນາປ່ອນພຽງຕົວເລກເທົ່ານັ້ນ!.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Handled = True
        End If
    End Sub

    Private Sub Guna2Button7_Click(sender As Object, e As EventArgs) Handles Guna2Button7.Click
        formCustormer.ShowDialog()
    End Sub

    Private Sub Guna2Button8_Click(sender As Object, e As EventArgs) Handles Guna2Button8.Click
        Me.Close()
    End Sub
End Class