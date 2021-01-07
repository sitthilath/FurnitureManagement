Imports MySql.Data.MySqlClient

Public Class Home
    Dim MysqlConn As MySqlConnection
    Dim COMMAND As MySqlCommand
    Dim dr As MySqlDataReader
    Sub swichpanel(ByVal PA As Form)
        panelMain.Controls.Clear()
        PA.TopLevel = False
        panelMain.Controls.Add(PA)
        PA.Show()

    End Sub
    Private Sub Guna2ControlBox1_Click(sender As Object, e As EventArgs) Handles Guna2ControlBox1.Click
        Me.Close()

    End Sub

    Private Sub Guna2HtmlLabel1_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel1.Click

    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles btn_historysell.Click
        btn_historysell.BorderColor = Color.DarkOrange
        btn_product.BorderColor = Color.Gray
        btn_user.BorderColor = Color.Gray
        btn_report.BorderColor = Color.Gray
        btn_sellproduct.BorderColor = Color.Gray
        btn_custromer.BorderColor = Color.Gray

        swichpanel(Historysell)
    End Sub

    Private Sub panelMain_Paint(sender As Object, e As PaintEventArgs) Handles panelMain.Paint
        Try
            lable_name.Text = Class1.name
            label_surname.Text = Class1.lastname
            label_statu.Text = Class1.statu

            If label_statu.Text = "Seller" Then
                btn_user.Visible = False
                btn_historysell.Visible = False
                btn_report.Visible = False
            End If


        Catch ex As Exception

        End Try
    End Sub



    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles btn_report.Click
        btn_historysell.BorderColor = Color.Gray
        btn_product.BorderColor = Color.Gray
        btn_user.BorderColor = Color.Gray
        btn_report.BorderColor = Color.DarkBlue
        btn_sellproduct.BorderColor = Color.Gray
        btn_custromer.BorderColor = Color.Gray

        swichpanel(report)
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles btn_user.Click
        btn_historysell.BorderColor = Color.Gray
        btn_product.BorderColor = Color.Gray
        btn_user.BorderColor = Color.DarkOrange
        btn_report.BorderColor = Color.Gray
        btn_sellproduct.BorderColor = Color.Gray
        btn_custromer.BorderColor = Color.Gray

        swichpanel(ManageUser)
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles btn_product.Click
        btn_historysell.BorderColor = Color.Gray
        btn_product.BorderColor = Color.DarkOrange
        btn_user.BorderColor = Color.Gray
        btn_report.BorderColor = Color.Gray
        btn_sellproduct.BorderColor = Color.Gray
        btn_custromer.BorderColor = Color.Gray


        swichpanel(AddProduct)
    End Sub

    Private Sub Guna2PictureBox1_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox1.Click



    End Sub

    Private Sub Guna2HtmlLabel2_Click(sender As Object, e As EventArgs) Handles showuser.Click

    End Sub

    Private Sub Guna2GradientCircleButton1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Guna2Button1_Click_1(sender As Object, e As EventArgs) Handles btn_logout.Click
        Login.Show()
        Me.Dispose()

    End Sub


    Dim connection As New MySqlConnection("server=localhost;user=root;password='';database=index")
    Private Sub Guna2CircleButton1_Click(sender As Object, e As EventArgs) Handles Guna2CircleButton1.Click
        Try
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If


            '////////////
            Dim cmd As New MySqlCommand
            cmd.Connection = connection
            cmd.CommandText = "select CID from catagory  ORDER BY CID DESC LIMIT 1"
            Dim numtype, i As Integer
            numtype = cmd.ExecuteScalar()

            '//////////////////////////////////////////////
            '/////////////////////////
            Dim cmd_countCat As New MySqlCommand
            cmd_countCat.Connection = connection
            cmd_countCat.CommandType = CommandType.Text
            cmd_countCat.CommandText = "Select COUNT(*) FROM catagory "
            Dim numCat As Integer
            numCat = cmd_countCat.ExecuteScalar()




            For i = 1 To numtype Step 1


                '////////////////////////
                Dim cmd_select As New MySqlCommand
                cmd_select.CommandText = "SELECT * from catagory where CID='" & i & "'"
                cmd_select.Connection = connection

                dr = cmd_select.ExecuteReader()

                Dim Setname As String
                Dim id As Integer

                If dr.HasRows Then
                    dr.Read()
                    Setname = dr.Item("type_catagory")
                    id = dr.Item("CID")
                End If
                dr.Close()





                If id <> i Then

                Else
                    Chart1.Series.Add(Setname)

                    '/////////////////////////
                    MsgBox("Error")
                    Dim cmd_insert As New MySqlCommand
                    cmd_insert.Connection = connection
                    cmd_insert.CommandType = CommandType.Text
                    cmd_insert.CommandText = "Select COUNT(*) FROM aftersell WHERE type_catagory = '" & id & "'"
                    Dim xChart As String
                    xChart = cmd_insert.ExecuteScalar()


                    Dim x As Double = numCat
                    Dim y As Double = xChart
                    Dim z As Double = xChart
                    Chart1.Series(0).Points.Add(x)
                    Chart1.Series(1).Points.Add(y)
                    Chart1.Series(2).Points.Add(z)
                    Chart1.Series(3).Points.Add(x)
                    Chart1.Series(4).Points.Add(y)
                    Chart1.Series(5).Points.Add(z)
                End If
            Next






        Catch ex As Exception
            MsgBox("error" + ex.Message)
        End Try

    End Sub

    Private Sub Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '  lable_username.Text = Class1.setname
    End Sub

    Private Sub Guna2Button4_Click_1(sender As Object, e As EventArgs) Handles btn_sellproduct.Click
        swichpanel(formSell)
        btn_historysell.BorderColor = Color.Gray
        btn_product.BorderColor = Color.Gray
        btn_user.BorderColor = Color.Gray
        btn_report.BorderColor = Color.Gray
        btn_sellproduct.BorderColor = Color.DarkOrange
        btn_custromer.BorderColor = Color.Gray

    End Sub

    Private Sub Guna2Button2_Click_1(sender As Object, e As EventArgs) Handles btn_custromer.Click
        btn_historysell.BorderColor = Color.Gray
        btn_product.BorderColor = Color.Gray
        btn_user.BorderColor = Color.Gray
        btn_report.BorderColor = Color.Gray
        btn_sellproduct.BorderColor = Color.Gray
        btn_custromer.BorderColor = Color.DarkOrange

        swichpanel(formCustormer)
    End Sub

    Private Sub btn_sent_Click(sender As Object, e As EventArgs)
        btn_historysell.BorderColor = Color.Gray
        btn_product.BorderColor = Color.Gray
        btn_user.BorderColor = Color.Gray
        btn_report.BorderColor = Color.Gray
        btn_sellproduct.BorderColor = Color.Gray
        btn_custromer.BorderColor = Color.Gray

    End Sub

    Private Sub Guna2Button1_Click_2(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        panelMain.Controls.Clear()

    End Sub
End Class