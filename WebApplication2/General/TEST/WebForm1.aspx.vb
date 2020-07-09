Imports System.Data.SqlClient


Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles UDate.TextChanged

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim con As New SqlClient.SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Purva\source\repos\WebApplication1\WebApplication1\App_Data\FeedbackDatabase.mdf;Integrated Security=True")
        Dim cmd As New SqlCommand()
        cmd.CommandType = System.Data.CommandType.Text
        cmd.CommandText = "Insert into [Table] Values ('" & TextBox3.Text & "','" & UDate.Text.ToString & "','" & TextBox1.Text & "','" & TextBox4.Text & "'," & RadioButtonList1.SelectedValue & "," & RadioButtonList2.SelectedValue & "," & RadioButtonList3.SelectedValue & "," & RadioButtonList4.SelectedValue & "," & RadioButtonList5.SelectedValue & "," & RadioButtonList6.SelectedValue & "," & RadioButtonList7.SelectedValue & "," & RadioButtonList8.SelectedValue & "," & RadioButtonList9.SelectedValue & "," & RadioButtonList10.SelectedValue & "," & RadioButtonList11.SelectedValue & ");"
        cmd.Connection = con
        con.Open()
        cmd.ExecuteNonQuery()

        con.Close()
    End Sub
End Class