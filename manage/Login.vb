Imports System.Data.OleDb
Imports MySql.Data.MySqlClient

Public Class Login
    Dim cn As New MySqlConnection("server=localhost;user=root;password='';database=index")
    Dim cmd As MySqlCommand
    Dim da As MySqlDataAdapter
    Dim ds As DataSet
    Dim sql As String





    Private Sub Guna2CircleButton1_Click(sender As Object, e As EventArgs)
        Close()

    End Sub
    Sub frm_login()
        If cn.State = ConnectionState.Closed Then

        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txt_user.Focus()
        txt_user.Text = My.Settings.username
        If My.Settings.username = "" Then
            chk_remeber.Checked = False
        Else
            chk_remeber.Checked = True
        End If


    End Sub

    Private Sub Guna2CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles showpassword.CheckedChanged
        If txt_password.UseSystemPasswordChar = False Then
            'showpassword
            txt_password.UseSystemPasswordChar = True
        Else
            'hide password
            txt_password.UseSystemPasswordChar = False
        End If
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        '////////////////////////////////////////////
        Try
            If txt_user.Text = "" Or txt_password.Text = "" Then
                msg_ok("ກາລຸນາປ້ອນຂໍ້ມູນໃຫ້ຄົບ!")
                Return
            End If

            sql = "select *from  manageusers where mail='" & txt_user.Text & "' and password='" & txt_password.Text & " '"
            da = New MySqlDataAdapter(sql, cn)
            ds = New DataSet

            da.Fill(ds, "datatable")
            If ds.Tables("datatable").Rows.Count <= 0 Then
                MsgBox("mail and password fail!")
            Else
                If ds.Tables("datatable").Rows(0)("status") = "Admin" Or ds.Tables("datatable").Rows(0)("status") = "admin" Then
                    Me.Hide()
                    Home.Show()
                    txt_password.Clear()


                    Class1.name = ds.Tables("datatable").Rows(0)("name")
                    Class1.lastname = ds.Tables("datatable").Rows(0)("surname")
                    Class1.age = ds.Tables("datatable").Rows(0)("age")
                    Class1.statu = ds.Tables("datatable").Rows(0)("status")

                ElseIf ds.Tables("datatable").Rows(0)("status") = "Seller" Or ds.Tables("datatable").Rows(0)("status") = "seller" Then
                    Me.Hide()
                    Home.Show()

                    txt_password.Clear()
                    Class1.name = ds.Tables("datatable").Rows(0)("name")
                    Class1.lastname = ds.Tables("datatable").Rows(0)("surname")
                    Class1.age = ds.Tables("datatable").Rows(0)("age")
                    Class1.statu = ds.Tables("datatable").Rows(0)("status")
                Else
                    MsgBox("You Block!")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Guna2HtmlLabel4_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel4.Click


    End Sub

    Private Sub txt_user_TextChanged(sender As Object, e As EventArgs) Handles txt_user.TextChanged

    End Sub

    Private Sub txt_user_Enter(sender As Object, e As EventArgs) Handles txt_user.Enter


    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs)

    End Sub
    Friend Function confirm(text As String, Optional title As String = "ຍືນຍັນ")
        Return MsgBox(text, vbQuestion + vbYesNo, title)
    End Function
    Sub msg_ok(text As String, Optional title As String = "ແຈ້ງເຕື່ອນ!")
        MsgBox(text, vbInformation + vbOKOnly, title)
    End Sub

    Private Sub btn_close_Click_1(sender As Object, e As EventArgs) Handles btn_close.Click
        If confirm("ເຈົ້າຕ້ອງການທີ່ຈະອອກຈາກໂປຣແກຣມ ຫຼື ບໍ່?") = vbYes Then
            Me.Close()
        End If
    End Sub

    Private Sub chk_remeber_CheckedChanged(sender As Object, e As EventArgs) Handles chk_remeber.CheckedChanged
        If chk_remeber.Checked = True Then
            My.Settings.username = txt_user.Text
            My.Settings.Save()
        Else
            My.Settings.username = ""
        End If
        My.Settings.Save()

    End Sub

    Private Sub Guna2HtmlLabel6_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel6.Click
        Me.Hide()
        Home.ShowDialog()
    End Sub

    Private Sub Guna2CirclePictureBox1_Click(sender As Object, e As EventArgs) Handles Guna2CirclePictureBox1.Click



    End Sub
End Class
