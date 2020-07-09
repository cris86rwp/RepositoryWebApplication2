
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
Public Class WMS_Wheel

    Inherits System.Web.UI.Page
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents TextBox1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents TextBox2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents dbtyear As System.Web.UI.WebControls.TextBox
    Protected WithEvents DropDownList1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DropDownList2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DropDownList3 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button
    Protected WithEvents GridView1 As System.Web.UI.WebControls.GridView
    Protected WithEvents lblMessage1 As System.Web.UI.WebControls.Label
    Protected WithEvents Datagrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Datagrid3 As System.Web.UI.WebControls.DataGrid
    Dim head As String
    Dim type As String
    Dim planhead As String
    Dim ph As String
    Dim year As String
    Dim month As String
    Dim db As TextBox
    Dim db1 As String
    Dim planhead1 As String
    Dim a As String
    Dim planheadnew As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not Me.IsPostBack Then
        '    planhead = DropDownList1.SelectedItem.Text
        '    BindGrid1()
        'End If

    End Sub

    Protected Sub OnSelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        For Each row As GridViewRow In GridView1.Rows
            planhead = row.Cells(0).Text
            head = row.Cells(1).Text
            type = row.Cells(2).Text
            db = DirectCast(row.FindControl("debit"), TextBox)
            db1 = db.Text
            year = DropDownList1.SelectedItem.Text
            month = DropDownList2.SelectedItem.Text
            update()
        Next



    End Sub
    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        planhead = DropDownList3.SelectedItem.Text

        'lblMessage.Text = "Leave Sanctioned" + planhead
        BindGrid1()
    End Sub
    Sub BindGrid1()
        Dim con As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
        Dim s As String = "select distinct PLANHEAD, HEAD, TYPE from PLAN_HEAD_DETAILS where PLANHEAD='" & planhead & "'"
        Dim myCmd As New SqlDataAdapter(s, con)
        Dim ds As New DataTable()
        myCmd.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()

    End Sub
    Sub update()

        Dim con As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
        con.Open()
        Dim updatestr As String = "insert into PLAN_HEAD_DETAILS values( '" & planhead & "','" & head & "','" & type & "', '" & year & "','" & month & "', '" & db1 & "' ,null)"
        'Dim updatestr As String = "update PLAN_HEAD_DETAILS set YEAR='" & year & "', MONTH ='" & month & "',  DEBIT='" & db1 & "' where PLANHEAD='" & planhead & "' and HEAD='" & head & "'"
        'Dim updatestr As String = "update PLAN_HEAD_DETAILS set YEAR='2019', MONTH ='01',  DEBIT='500' where PLANHEAD='" & ph & "' and HEAD='05'"
        SqlHelper.ExecuteNonQuery(con, CommandType.Text, updatestr)
        lblMessage1.Text = "Data Updated Successfully"
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        planhead = DropDownList3.SelectedItem.Text
        planhead1 = planhead.Substring(0, 5)
        a = "%"
        planheadnew = planhead1 + a

        year = DropDownList1.SelectedItem.Text
        month = DropDownList2.SelectedItem.Text
        'lblMessage.Text = "Planhead" + planhead
        BindGrid1()
        BindGrid2()
        BindGrid3()


    End Sub
    Private Sub BindGrid2()
        Dim con As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
        con.Open()
        Dim sqlstring2 As String = "select PLANHEAD, HEAD, TYPE,YEAR, MONTH, DEBIT from PLAN_HEAD_DETAILS where YEAR='" & year & "' and  MONTH ='" & month & "' and PLANHEAD like '" & planheadnew & "'"
        Dim myCommand As New SqlDataAdapter(sqlstring2, con)
        Dim ds As New DataSet()
        myCommand.Fill(ds)
        Datagrid2.DataSource = ds
        Datagrid2.DataBind()
    End Sub
    Private Sub BindGrid3()
        Dim con As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
        con.Open()
        Dim sqlstring2 As String = "select sum(DEBIT) as TOTAL from PLAN_HEAD_DETAILS where YEAR='" & year & "' and  MONTH ='" & month & "' and PLANHEAD like '" & planheadnew & "'"
        Dim myCommand As New SqlDataAdapter(sqlstring2, con)
        Dim ds As New DataSet()
        myCommand.Fill(ds)
        Datagrid3.DataSource = ds
        Datagrid3.DataBind()
    End Sub
End Class