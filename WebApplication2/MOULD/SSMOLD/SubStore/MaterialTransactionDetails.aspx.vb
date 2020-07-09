Imports System.Data.SqlClient
Public Class MaterialTransactionDetails

    Inherits System.Web.UI.Page
    Protected WithEvents Submit As Global.System.Web.UI.WebControls.Button

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    End Sub

    Protected Sub Button_Click(sender As Object, e As EventArgs) Handles Submit1.Click
        If IsNumeric(PLNo) Then
            '
            Exit Sub
        Else
            MsgBox("Enter valid year")
            Exit Sub
        End If

        If IsNumeric(POBalQty) Then
            '
            Exit Sub
        Else
            MsgBox("Enter valid year")
            Exit Sub
        End If


        Dim rd1 As String
        If Stock.Checked Then
            rd1 = "Stock"
        ElseIf (NonStock.Checked) Then
            rd1 = "Non-Stock"
        ElseIf (Others.Checked) Then
            rd1 = "Others"
        End If
        Dim con As SqlConnection = New SqlConnection()
        con.ConnectionString = "Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;Persist Security Info=True;User Id=sa;Password=sadev123"
        Dim cmd As New SqlCommand("INSERT INTO Mat_tran_Detail(mat_type,Item_desc,pl_no,with_date,with_qty,unit1,po_no,po_date,po_qty,f_name,sup_qty,po_bal_qty,con_city,ma_bal_qty,sho_bal_qty,tot_bal_qty,mat_drawn,no1) VALUES (@mat_type,@Item_desc,@pl_no,@with_date,@with_qty,@unit1,@po_no,@po_date,@po_qty,@f_name,@sup_qty,@po_bal_qty,@con_city,@ma_bal_qty,@sho_bal_qty,@tot_bal_qty,@mat_drawn,@no1)")
        cmd.Connection = con
        cmd.Parameters.AddWithValue("@mat_type", rd1)
        cmd.Parameters.AddWithValue("@Item_desc", ItemDesc.Text)
        cmd.Parameters.AddWithValue("@pl_no", PLNo.Text)
        cmd.Parameters.AddWithValue("@with_date", WithDate.Text)
        cmd.Parameters.AddWithValue("@with_qty", WithQty.Text)
        cmd.Parameters.AddWithValue("@unit1", Unit1.Text)
        cmd.Parameters.AddWithValue("@po_no", PONo.Text)
        cmd.Parameters.AddWithValue("@po_date", PODate.Text)
        cmd.Parameters.AddWithValue("@po_qty", POQty.Text)
        cmd.Parameters.AddWithValue("@f_name", FirmName.Text)
        cmd.Parameters.AddWithValue("@sup_qty", SupQty.Text)
        cmd.Parameters.AddWithValue("@po_bal_qty", POBalQty.Text)
        cmd.Parameters.AddWithValue("@con_city", POConCity.Text)
        cmd.Parameters.AddWithValue("@ma_bal_qty", MBalQty.Text)
        cmd.Parameters.AddWithValue("@sho_bal_qty", SBalQty.Text)
        cmd.Parameters.AddWithValue("@tot_bal_qty", TBalQty.Text)
        cmd.Parameters.AddWithValue("@mat_drawn", MatDrawn.SelectedItem.Text)
        cmd.Parameters.AddWithValue("@no1", No1.Text)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        MsgBox("Submitted Sucessfully")
        Response.Redirect(Request.Url.AbsoluteUri)
    End Sub

End Class



