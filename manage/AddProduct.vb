Public Class AddProduct
    Sub swichpanel(ByVal PA As Form)
        pathshow.Controls.Clear()
        PA.TopLevel = False
        pathshow.Controls.Add(PA)
        PA.Show()
    End Sub
    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        swichpanel(addcat)
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        swichpanel(ProductAll)
    End Sub

    Private Sub AddProduct_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        swichpanel(ProductAll)
    End Sub
End Class