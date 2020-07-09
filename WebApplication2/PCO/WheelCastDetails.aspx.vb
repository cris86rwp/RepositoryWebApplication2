
Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports System.Data
Imports System.Net.Mail
Imports System.Net
Imports System
Imports System.Configuration
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Collections.Generic
Imports System.Linq
Imports System.IO



Public Class WheelCastDetails

    Inherits System.Web.UI.Page
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents TextBox1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents TextBox2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents DropDownList1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DropDownList2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents Datagrid1 As System.Web.UI.WebControls.DataGrid

    Dim year As String
    Dim month As String
    Dim wheel_cast As String
    Dim wheel_xc As String
    Dim good_wheel As String
    Dim x As Integer
    Dim y As Integer


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        year = DropDownList2.SelectedItem.Text
        month = DropDownList1.SelectedItem.Text
        BindGrid1()
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        year = DropDownList2.SelectedItem.Text
        month = DropDownList1.SelectedItem.Text

        wheel_cast = TextBox1.Text
        wheel_xc = TextBox2.Text
        good_wheel = Integer.Parse(TextBox1.Text) - Integer.Parse(TextBox1.Text) * Integer.Parse(TextBox2.Text) / 100

        'good_wheel = (Integer.Parse(TextBox1.Text) - Integer.Parse(TextBox1.Text) * Integer.Parse(TextBox2.Text) / 100)


        update()
    End Sub

    Private Sub BindGrid1()
        Dim con As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
        con.Open()
        Dim sqlstring2 As String = "select YEAR, MONTH,WHEEL_CAST,WHEEL_XC, GOOD_WHEEL from WHEEL_CAST where YEAR='" & year & "' and  MONTH ='" & month & "' "
        Dim myCommand As New SqlDataAdapter(sqlstring2, con)
        Dim ds As New DataSet()
        myCommand.Fill(ds)
        Datagrid1.DataSource = ds
        Datagrid1.DataBind()
        con.Close()
    End Sub

    Sub update()

        Dim con As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
        con.Open()
        Dim cmd As New SqlCommand("SELECT COUNT(*) from WHEEL_CAST where YEAR=@year and  MONTH =@month ", con)
        cmd.Parameters.AddWithValue("@year", year)
        cmd.Parameters.AddWithValue("@month", month)
        Dim i As Integer = Convert.ToInt32(cmd.ExecuteScalar())
        cmd = Nothing
        con.Close()
        If i >= 1 Then


            lblMessage.Text = "Data Already Available"



        Else
            Dim updatestr As String = "insert into WHEEL_CAST values('" & year & "', '" & month & "', '" & wheel_cast & "', '" & wheel_xc & "' ,'" & good_wheel & "' )"
            SqlHelper.ExecuteNonQuery(con, CommandType.Text, updatestr)
            'Dim updatestr1 As String = "insert into WHEEL_CAST (GOOD_WHEEL) values(WHEEL_CAST-WHEEL_XC)"
            'SqlHelper.ExecuteNonQuery(con, CommandType.Text, updatestr1)
            lblMessage.Text = "Data Updated Successfully"
            'con.Close()
        End If
    End Sub

End Class