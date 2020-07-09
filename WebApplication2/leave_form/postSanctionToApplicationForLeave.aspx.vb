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
Imports System.Drawing
Public Class Sanction
    Inherits System.Web.UI.Page
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cmdUpdate As System.Web.UI.WebControls.Button
    Protected WithEvents show As System.Web.UI.WebControls.Button
    Protected WithEvents lv As System.Web.UI.WebControls.Button
    Protected WithEvents check As System.Web.UI.WebControls.CheckBox
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtremark As System.Web.UI.WebControls.TextBox
    Protected WithEvents GridView1 As System.Web.UI.WebControls.GridView
    Protected WithEvents GridView2 As System.Web.UI.WebControls.GridView
    Protected WithEvents DataGrid3 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid4 As System.Web.UI.WebControls.DataGrid
    Shared themeValue As String
    Dim ecode As String
    Dim ename As String
    Dim fdate As String
    Dim tdate As String
    Dim appno As String
    Dim desc As String
    Dim lvcode As String
    Dim ndays As String
    Dim reason As String
    Dim remark As String


    Public Sub New()

        AddHandler PreInit, New EventHandler(AddressOf Page_PreInit)
    End Sub

    Private Sub Page_PreInit(ByVal sender As Object, ByVal e As EventArgs)

        Page.Theme = themeValue
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ecode = Session("Ecode")
            'ecode = "22729804339"
            BindGrid1()
            'MsgBox("To View Document select only one employee at a time")
        End If
    End Sub

    Protected Sub dd1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dd1.SelectedIndexChanged
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())
    End Sub


    Protected Sub cmdUpdate_Click(sender As Object, e As EventArgs) Handles cmdUpdate.Click
        For Each row As GridViewRow In GridView1.Rows
            Dim CheckBox1 As CheckBox = CType(row.FindControl("check1"), CheckBox)
            Dim CheckBox2 As CheckBox = CType(row.FindControl("check2"), CheckBox)
            Dim btn As Button = CType(row.FindControl("view"), Button)
            If CheckBox1.Checked Then
                appno = row.Cells(0).Text
                ecode = row.Cells(1).Text
                ename = row.Cells(2).Text
                desc = row.Cells(3).Text
                lvcode = row.Cells(4).Text
                fdate = row.Cells(5).Text
                tdate = row.Cells(6).Text
                ndays = row.Cells(7).Text
                reason = row.Cells(8).Text
                remark = row.Cells(9).Text
                Dim tb As TextBox = DirectCast(row.FindControl("txtremark"), TextBox)
                remark = tb.Text

                ' update()
                availability()
                'lblMessage.Text = tdate
            End If
            If CheckBox2.Checked Then
                appno = row.Cells(0).Text
                ecode = row.Cells(1).Text
                ename = row.Cells(2).Text
                fdate = row.Cells(4).Text
                tdate = row.Cells(5).Text
                Dim tb As TextBox = DirectCast(row.FindControl("txtremark"), TextBox)
                remark = tb.Text

                reject()

            End If
            'If row.RowType = DataControlRowType.DataRow Then
            '    appno = row.Cells(0).Text
            '    ecode = row.Cells(1).Text
            '    LoadImages()

            'End If
            CheckBox1.Checked = False
            CheckBox2.Checked = False
        Next
        ' GridView2.Visible = False
        BindGrid1()
    End Sub
    Protected Sub update()

        lblMessage.Text = "updating..."
        Dim con As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
        con.Open()
        Dim updatestr As String = "update hr_leave_application_details set l_confirm='Y', remark='" & remark & "' where empno='" & ecode & "' and application_number='" & appno & "'"
        SqlHelper.ExecuteNonQuery(con, CommandType.Text, updatestr)

        Dim Update1 As String = "Update leave_header set LEAVEAVAILED=LEAVEAVAILED+b.number_of_days from leave_header a inner join hr_leave_application_details b on a.LEAVECODE=b.leavecode where a.EMPNO='" & ecode & "' and b.application_number='" & appno & "'"
        SqlHelper.ExecuteNonQuery(con, CommandType.Text, Update1)

        Dim Update2 As String = "Update leave_header set LEAVEOB=LEAVEOB-b.number_of_days from leave_header a inner join hr_leave_application_details b on a.LEAVECODE=b.leavecode where a.EMPNO='" & ecode & "' and b.application_number='" & appno & "'"
        SqlHelper.ExecuteNonQuery(con, CommandType.Text, Update2)

        Dim Update3 As String = "Update leave_header set LEAVEAVAILED=isnull(LEAVEAVAILED,0)+b.number_of_days/2 from leave_header a inner join hr_leave_application_details b on a.LEAVECODE=b.leavecode where a.EMPNO='" & ecode & "' and b.application_number='" & appno & "' and a.LEAVECODE='EC'"
        SqlHelper.ExecuteNonQuery(con, CommandType.Text, Update3)

        'Dim Update4 As String = "update leave_header set HALFCREDITED=HALFCREDITED + '" & Session("HALFCREDITED") & "' where EMPNO='" & ecode & "'  and LEAVECODE='" &  & "'"
        'SqlHelper.ExecuteNonQuery(con, CommandType.Text, Update4)


        Dim message = "Leave sanctioned for " + ename + " where From date: " + fdate + " To date: " + tdate + " Remark: " + remark
        Dim cmd As New SqlCommand("SELECT * FROM emp_details_new where empno=@empno", con)
        cmd.Parameters.AddWithValue("@empno", ecode)
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

        Dim APIKey As String = "95f0f61edc6954a4ba18bd8d0a687a64"
        Dim SecretKey As String = "a6a93c7cdb139d42799bef64b0b44845"
        '    Dim From As String = "jindalmohiniagrawal@gmail.com"
        Dim From As String = "pankaj.motwani@cris.org.in"

        Dim empno1 As String = ecode
        Dim cmd1 As New SqlCommand("SELECT * FROM emp_details_new where empno=@empno  ", con)
        cmd1.Parameters.AddWithValue("@empno", empno1)
        Dim reader1 As SqlDataReader = cmd1.ExecuteReader()
        Dim to1 As String
        While reader1.Read()

            to1 = reader1("email_id")

        End While
        Dim msg As New MailMessage()

        msg.From = New MailAddress(From)

        msg.To.Add(New MailAddress(to1))

        msg.Subject = "Leave status"

        msg.Body = "Leave sanctioned for " + ename + " From date: " + fdate + " To date: " + tdate

        Dim client As New SmtpClient("in-v3.mailjet.com", 587)

        client.EnableSsl = True

        client.Credentials = New NetworkCredential(APIKey, SecretKey)

        client.Send(msg)

    End Sub

    Sub reject()

        Dim con As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
        con.Open()
        Dim updatestr As String = "update hr_leave_application_details set l_confirm='N', remark='" & remark & "' where empno='" & ecode & "'  and application_number='" & appno & "'"
        SqlHelper.ExecuteNonQuery(con, CommandType.Text, updatestr)
        lblMessage.Text = "Leave Rejected"

        Dim message = "Leave rejected for " + ename + " From date: " + fdate + " To date: " + tdate + " Remark: " + remark
        Dim empno As String = ecode
        Dim cmd As New SqlCommand("SELECT * FROM emp_details_new where empno=@empno  ", con)
        cmd.Parameters.AddWithValue("@empno", empno)
        'cmd.Parameters.AddWithValue("@mpo", mpo)
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



        Dim APIKey As String = "95f0f61edc6954a4ba18bd8d0a687a64"
        Dim SecretKey As String = "a6a93c7cdb139d42799bef64b0b44845"
        '    Dim From As String = "jindalmohiniagrawal@gmail.com"
        Dim From As String = "pankaj.motwani@cris.org.in"

        'Dim cmd As New SqlCommand("SELECT mobile_no FROM emp_details where shop_code=@sc ", con)
        Dim empno1 As String = ecode
        Dim cmd1 As New SqlCommand("SELECT * FROM emp_details_new where empno=@empno  ", con)
        cmd1.Parameters.AddWithValue("@empno", empno1)
        Dim reader1 As SqlDataReader = cmd1.ExecuteReader()
        Dim to1 As String
        While reader1.Read()
            to1 = reader1("email_id")
        End While
        Dim msg As New MailMessage()

        msg.From = New MailAddress(From)

        msg.To.Add(New MailAddress(to1))

        msg.Subject = "Leave status"

        msg.Body = "Leave rejected for " + ename + "  From date: " + fdate + " To date: " + tdate

        Dim client As New SmtpClient("in-v3.mailjet.com", 587)

        client.EnableSsl = True

        client.Credentials = New NetworkCredential(APIKey, SecretKey)

        client.Send(msg)

    End Sub

    Protected Sub LoadImages()
        Dim rdr As SqlDataReader
        Dim conn2 As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
        conn2.Open()
        Dim j2 As Integer
        Dim toffc2 As New SqlCommand("SELECT COUNT(*) FROM  doc_upload1 where bytes is not null and appno='" & appno & "' and empno= '" & ecode & "'", conn2)
        j2 = Convert.ToInt32(toffc2.ExecuteScalar())
        If j2 > 0 Then
            'lblMessage.Text = appno
            Dim con As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
            con.Open()
            Dim cmd As New SqlCommand("SELECT bytes FROM doc_upload1 where appno='" & appno & "' and empno= '" & ecode & "' ", con)
            rdr = cmd.ExecuteReader()
            GridView2.Visible = True
            GridView2.DataSource = rdr
            GridView2.DataBind()
        Else
            Dim myscript As String = "window.alert('No document was uploaded by the employee!');"
            ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
        End If

    End Sub
    Sub availability()
        Dim rdr As SqlDataReader
        Dim con As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
        Dim strsql As String = "select leave_eligibility from hr_leave_master where leave_code='" & desc & "'"
        Dim leave_eligibility As String
        leave_eligibility = SqlHelper.ExecuteScalar(con, CommandType.Text, strsql)
        If leave_eligibility = "T" Then
            strsql = " Select LEAVECODE,(LEAVEOB+LEAVECREDITED-LEAVEAVAILED) tot_bal from leave_header where EMPNO='" & ecode & "' and LEAVECODE='" & desc & "'"
            rdr = SqlHelper.ExecuteReader(ConfigurationSettings.AppSettings("DBcon"), CommandType.Text, strsql)
            While rdr.Read
                If rdr.Item("tot_bal") > ndays Or rdr.Item("tot_bal") = ndays Then
                    lblMessage.Text = "going to update"
                    update()
                    lblMessage.Text = "Leave Sanctioned"
                End If
                If rdr.Item("tot_bal") < ndays Then
                    lblMessage.Text = "Not Enough Leave Balance"
                End If
            End While
        End If
    End Sub

    Sub BindGrid1()
        Dim con As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
        Dim str As String = "select from_date from hr_leave_application_details where l_confirm='p'"
        'Dim s As String = "select distinct a.application_number,a.empno,b.empname,a.leavecode,convert(varchar,a.from_date,103) [from_date],convert(varchar,a.to_date,103) [to_date],a.number_of_days from hr_leave_application_details a, employee_master b,leave_master c where a.l_confirm='p' and a.empno=b.empno  and convert(date,a.from_date) between convert(date,sysdatetime()) and convert(date,dateadd(month,3,sysdatetime())) order by a.application_number"
        Dim s As String = "select distinct a.application_number,a.empno,b.empname, a.leavecode, lvcode=(select distinct description from hr_leave_master where leave_code=a.leavecode),convert(varchar,a.from_date,103) [from_date],convert(varchar,a.to_date,103) [to_date],a.number_of_days, a.reason from hr_leave_application_details a, employee_master b where a.l_confirm='p' and a.empno=b.empno  order by a.application_number"
        Dim myCmd As New SqlDataAdapter(s, con)
        Dim ds As New DataTable()
        myCmd.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()

    End Sub
    Protected Sub OnPageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridView1.PageIndex = e.NewPageIndex
        Me.BindGrid1()
    End Sub

    Private Sub BindGrid3()
        Dim con As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
        'Dim sqlstring2 As String = "select distinct b.description,convert(varchar,a.from_date,103) [from_date],convert(varchar,a.to_date,103) [to_date],a.number_of_days, a.reason, a.l_confirm from hr_leave_application_details a, hr_leave_master b where a.leavecode=b.leave_code and a.empno='" & ecode & "' order by a.application_number"
        Dim sqlstring2 As String = "Select description = (select distinct description from  hr_leave_master where leavecode=leave_code),convert(varchar,a.from_date,103) [from_date],convert(varchar,a.to_date,103) [to_date],a.number_of_days, a.reason, a.l_confirm from hr_leave_application_details a where a.empno='" & ecode & "' order by a.application_number desc"
        Dim myCommand As New SqlDataAdapter(sqlstring2, con)
        Dim ds As New DataSet()
        myCommand.Fill(ds)
        DataGrid3.DataSource = ds
        DataGrid3.DataBind()
    End Sub
    Private Sub BindGrid4()
        Dim con As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
        Dim sqlstring2 As String
        'sqlstring2= "select leave_code, total_leave_availed, total_leave_accumulated + total_leave_eligibility - total_leave_availed AS balance from hr_leave_header where employee_code='" & Trim(txtemployee_code.Text) & "'"
        sqlstring2 = "  select distinct b.description as leavecode, leaveavailed, leaveob + leavecredited - leaveavailed AS balance "
        sqlstring2 &= " from leave_header a, hr_leave_master b"
        sqlstring2 &= " where a.empno='" & ecode & "'"
        sqlstring2 &= " and a.leavecode=b.leave_code and b.leave_code <> '00'"

        Dim myCommand As New SqlDataAdapter(sqlstring2, con)
        Dim ds As New DataSet()
        myCommand.Fill(ds)

        DataGrid4.DataSource = ds
        DataGrid4.DataBind()

    End Sub
    'Protected Sub show_Click(sender As Object, e As EventArgs) Handles show.Click
    '    For Each row As GridViewRow In GridView1.Rows
    '        Dim CheckBox3 As CheckBox = CType(row.FindControl("check3"), CheckBox)
    '        If CheckBox3.Checked Then
    '            ' Response.Write("A checkbox is checked")
    '            appno = row.Cells(0).Text
    '            ecode = row.Cells(1).Text
    '            LoadImages()
    '            lblMessage.Text = tdate
    '        End If

    '    Next

    'End Sub

    'Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
    '    ' Dim row As GridViewRow
    '    Select Case e.CommandName
    '        Case "Select"
    '            For Each row As GridViewRow In GridView1.Rows
    '                appno = row.Cells(0).Text
    '                ecode = row.Cells(1).Text
    '                lblMessage.Text = "BELA"
    '                LoadImages()

    '            Next
    '    End Select
    'End Sub

    Protected Sub view_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim gvRow As GridViewRow = CType(CType(sender, Control).Parent.Parent,
                                            GridViewRow)
        Dim index As Integer = gvRow.RowIndex
        appno = gvRow.Cells(0).Text
        ecode = gvRow.Cells(1).Text
        'lblMessage.Text = appno
        LoadImages()
    End Sub
    Protected Sub show_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim gvRow As GridViewRow = CType(CType(sender, Control).Parent.Parent,
                                            GridViewRow)
        Dim index As Integer = gvRow.RowIndex

        ecode = gvRow.Cells(1).Text
        'ecode = "52416005562"
        lblMessage.Text = appno
        BindGrid3()
        BindGrid4()
    End Sub

    Protected Sub OnSelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        For Each row As GridViewRow In GridView1.Rows
            'Dim CheckBox1 As CheckBox = CType(row.FindControl("check1"), CheckBox)
            'Dim CheckBox2 As CheckBox = CType(row.FindControl("check2"), CheckBox)
            'If CheckBox1.Checked Or CheckBox2.Checked Then
            If row.RowIndex = GridView1.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
                'Else
                '    row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
            End If
            ' End If
        Next
    End Sub




End Class