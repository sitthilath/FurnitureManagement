Imports MySql.Data.MySqlClient
Imports System.Data
Public Class Bills
    Dim conection As New MySqlConnection("server=localhost;user=root;password='';database=index")
    Dim cmd As MySqlCommand
    Dim da As MySqlDataAdapter
    Dim ds As New DATAproduct
    Dim ReportBills As ReportBill


    Private Sub Bills_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        report()



    End Sub

    Sub report()

        cmd = New MySqlCommand("select listID,Pid, Pname, qty, price, catagory.type_catagory, seller from listsell INNER JOIN catagory ON catagory.CID = listsell.type_catagory", conection)
        da = New MySqlDataAdapter(cmd)
        da.Fill(ds.listsell)
        ReportBills = New ReportBill()
        ReportBills.SetDataSource(ds)

        ReportBills.DataDefinition.FormulaFields.Item("bill_id").Text = formSell.showbill_id.Text
        ReportBills.SetParameterValue("lable_name", formSell.label_name.Text)
        ReportBills.SetParameterValue("Label_surname", formSell.Label_surname.Text)
        ReportBills.SetParameterValue("label_address", formSell.label_address.Text)
        ReportBills.SetParameterValue("label_phone ", formSell.label_phone.Text)
        ReportBills.SetParameterValue("label_email", formSell.label_email.Text)
        ReportBills.SetParameterValue("label_phoneadress", formSell.label_phoneadress.Text)
        ReportBills.SetParameterValue("label_sendadress", formSell.label_sendadress.Text)


        CRVbill.ReportSource = ReportBills
        'CrystalReportViewer1.RefreshReport()

    End Sub

End Class