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
Public Class StaffOnLeave
    Inherits System.Web.UI.Page
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents check As System.Web.UI.WebControls.CheckBox
    Protected WithEvents GridView1 As System.Web.UI.WebControls.GridView
    Protected WithEvents GridView2 As System.Web.UI.WebControls.GridView
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents cmdUpdate As System.Web.UI.WebControls.Button
    Shared themeValue As String
    Dim ecode1 As String
    Dim empno As String
    Dim empname As String
    Dim deptcode As String
    Dim description As String
    Dim leavecode As String
    Dim from_date As String
    Dim to_date As String
    Dim number_of_days As String
    Dim l_confirm As String
    Dim application_number As String


    Public Sub New()

        AddHandler PreInit, New EventHandler(AddressOf Page_PreInit)
    End Sub

    Private Sub Page_PreInit(ByVal sender As Object, ByVal e As EventArgs)

        Page.Theme = themeValue
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            ecode1 = Session("Ecode")
            'ecode1 = "22729804339"
            BindGrid1()
            BindGrid2()
            'MsgBox("To View Document select only one employee at a time")
        End If
    End Sub

    Protected Sub dd1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dd1.SelectedIndexChanged
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())
    End Sub
    Dim rdr As SqlDataReader

    Sub BindGrid1()
        ecode1 = Session("Ecode")
        'ecode1 = "22729804339"
        Dim con As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")

        'Dim s As String = "select distinct a.empno,b.empname,b.deptcode,c.description,convert(varchar,a.from_date,103) [from_date],convert(varchar,a.to_date,103) [to_date],a.number_of_days from hr_leave_application_details a, employee_master b, hr_leave_master c where a.LEAVECODE=c.leave_code and a.empno=b.empno and convert(date,a.from_date) between convert(date,dateadd(day,-15,sysdatetime())) and convert(date,dateadd(day,15,sysdatetime())) order by b.deptcode"
        Dim s As String = "Select empno, empname, deptcode, leavecode,  description, from_date, to_date, number_of_days, l_confirm, application_number From emp_lv_details where applied_to='" & ecode1 & "' and l_confirm ='Y' order by application_number desc "
        Dim myCmd As New SqlDataAdapter(s, con)
        Dim ds As New DataTable()
        myCmd.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()
    End Sub
    'Dim dc As String = Session("deptcode")

    Sub BindGrid2()
        Dim con As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")

        ' Dim s As String = "select a.empno,b.empname,b.deptcode,a.leavecode,convert(varchar,a.from_date,103) [from_date],convert(varchar,a.to_date,103) [to_date],a.number_of_days, a.l_confirm  from hr_leave_application_details a, employee_master b where b.deptcode='medical'  and a.empno=b.empno and convert(date,a.from_date)=convert(date,sysdatetime())"
        Dim s As String = "select distinct  a.empno,b.empname,b.deptcode,c.description,convert(varchar,a.from_date,103) [from_date],convert(varchar,a.to_date,103) [to_date],a.number_of_days, a.l_confirm  from hr_leave_application_details a, employee_master b, hr_leave_master c where b.deptcode='medical' and a.LEAVECODE=c.leave_code  and a.empno=b.empno and convert(date,sysdatetime()) between convert(date,a.from_date) and convert(date,a.to_date)"

        Dim myCmd As New SqlDataAdapter(s, con)
        Dim ds As New DataTable()
        myCmd.Fill(ds)
        GridView2.DataSource = ds
        GridView2.DataBind()
    End Sub

    Protected Sub OnPageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridView1.PageIndex = e.NewPageIndex
        Me.BindGrid1()
        GridView2.PageIndex = e.NewPageIndex
        Me.BindGrid2()
    End Sub
    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        For Each row As GridViewRow In GridView1.Rows
            Dim CheckBox1 As CheckBox = CType(row.FindControl("check1"), CheckBox)

            If CheckBox1.Checked Then
                empno = row.Cells(0).Text
                empname = row.Cells(1).Text
                deptcode = row.Cells(2).Text
                leavecode = row.Cells(3).Text
                description = row.Cells(4).Text
                from_date = row.Cells(5).Text
                to_date = row.Cells(6).Text
                number_of_days = row.Cells(7).Text
                l_confirm = row.Cells(8).Text
                application_number = row.Cells(9).Text


                'lblMessage.Text = tdate
            End If

            CheckBox1.Checked = False

        Next
        ' GridView2.Visible = False
        BindGrid1()

        Dim strSql As String
        Dim i As Integer
        Dim cn As SqlConnection
        Dim sqltran As SqlTransaction
        cn = New SqlConnection(ConfigurationSettings.AppSettings("con"))
        cn.Open()

        Try
            strSql = "  update hr_leave_application_details set application_type='K'"
            strSql &= " ,change_date='" & Format(Date.Now, "MM/dd/yyyy") & "'"
            strSql &= " ,change_time='" & Format(Date.Now, "MM/dd/yyyy hh:mm:ss") & "'"
            strSql &= ",posted='F'"
            strSql &= " where application_number='" & application_number & "'"
            sqltran = cn.BeginTransaction
            i = SqlHelper.ExecuteNonQuery(sqltran, CommandType.Text, strSql)
            strSql = " update leave_header set leaveavailed=leaveavailed - '" & number_of_days & "'"
            strSql &= " where empno='" & empno & "'"
            strSql &= " and leavecode='" & leavecode & "'"
            i = SqlHelper.ExecuteNonQuery(sqltran, CommandType.Text, strSql)
            strSql = " update leave_header set leaveob=leaveob + '" & number_of_days & "'"
            strSql &= " where empno='" & empno & "'"
            strSql &= " and leavecode='" & leavecode & "'"
            i = SqlHelper.ExecuteNonQuery(sqltran, CommandType.Text, strSql)
            strSql = "Delete from hr_leave_application_details where application_number='" & application_number & "'"
            i = SqlHelper.ExecuteNonQuery(sqltran, CommandType.Text, strSql)
            'lblMessage.Text = ""

            Dim j As Integer

            '    j = MsgBox("                       LEAVE CANCELLED..                       ", 0, "Information")
            Dim myscript As String = "window.alert('LEAVE CANCELLED');"
            ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
            Dim message = "Leave Cancelled for " + empno + " where From date: " + from_date + " To date: " + to_date
            Dim conc As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
            conc.Open()
            Dim cmd As New SqlCommand("SELECT * FROM emp_details_new where empno=@empno", conc)
            cmd.Parameters.AddWithValue("@empno", empno)
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            While reader.Read()

                Dim no As String = reader("Mobileno").ToString()
                Dim number As String = "91" + no

                Dim strGet As String
                Dim url As String = "http://enterprise.smsgupshup.com/GatewayAPI/rest?method=SendMessage&send_to=919461013570?msg=message&msg_type=TEXT&userid=2000184632&auth_scheme=plain&password=pWK3H5&v=1.1&format=text"
                Dim url1 As String = "http://enterprise.smsgupshup.com/GatewayAPI/rest?method=SendMessage&send_to="
                Dim url2 As String = "&msg="
                Dim url3 As String = "&msg_type=TEXT&userid=2000184632&auth_scheme=plain&password=pWK3H5&v=1.1&format=text"

                strGet = url1 + number + url2 + message + url3

                Dim webClient As New System.Net.WebClient
                Dim result As String = webClient.DownloadString(strGet)
            End While
            reader.Close()
            ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)

            sqltran.Commit()

        Catch ex As Exception
            lblMessage.Text = "Error"
            sqltran.Rollback()
        Finally
            cn.Close()
            sqltran.Dispose()
        End Try
        BindGrid1()
    End Sub
End Class