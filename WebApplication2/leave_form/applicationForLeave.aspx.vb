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

Public Class applicationForLeave
    Inherits System.Web.UI.Page
    Protected WithEvents lblMode As System.Web.UI.WebControls.Label
    Protected WithEvents lblhol As System.Web.UI.WebControls.Label
    Protected WithEvents Txtupload As System.Web.UI.WebControls.TextBox
    Protected WithEvents FileUpload1 As System.Web.UI.WebControls.FileUpload
    Protected WithEvents btndoc As System.Web.UI.WebControls.Button
    Protected WithEvents lblmessage1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblout As System.Web.UI.WebControls.Label
    Protected WithEvents lblreason As System.Web.UI.WebControls.Label
    Protected WithEvents lbladd As System.Web.UI.WebControls.Label
    Protected WithEvents cal1 As System.Web.UI.WebControls.Calendar
    Protected WithEvents cal2 As System.Web.UI.WebControls.Calendar
    Protected WithEvents img1 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents img2 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lblcl1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblcl2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblcommute As System.Web.UI.WebControls.Label
    Protected WithEvents ddlconvert As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlout As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlleave_code As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtleave_from As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtaddress As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtapplication_number As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlfirst_half_from As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtleave_to As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlfirst_half_to As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtdays As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtemployee_code As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lbl1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblcom As System.Web.UI.WebControls.Label
    Protected WithEvents lbl2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblholiday As System.Web.UI.WebControls.Label
    Protected WithEvents lblempcode As System.Web.UI.WebControls.Label
    Protected WithEvents txtreason As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator3 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents ddloutstation_or_hq As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlholiday As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Datagrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblname As System.Web.UI.WebControls.Label
    Protected WithEvents lbldesignation As System.Web.UI.WebControls.Label
    Protected WithEvents cmdSave As System.Web.UI.WebControls.Button
    Protected WithEvents cmdCancel As System.Web.UI.WebControls.Button
    'Protected WithEvents cmdExit As System.Web.UI.WebControls.Button
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Public con As New SqlConnection(ConfigurationManager.AppSettings("con"))
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList

    Shared themeValue As String
    Dim fromdate As DateTime
    Public Sub New()

        AddHandler PreInit, New EventHandler(AddressOf Page_PreInit)
    End Sub

    Private Sub Page_PreInit(ByVal sender As Object, ByVal e As EventArgs)

        Page.Theme = themeValue
    End Sub


    Protected Sub Dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub



#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Dim rdr As SqlDataReader
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        'Put user code to initialize the page here
        'redirecting during leave credits'
        ' Response.Redirect("/wap/leavemessage.htm")
        'redirecting during leave credits'
        'Session("UserId") = "52405556247"
        Session("UserId") = Session("Ecode")
        'If Session("UserId") Is Nothing Then
        '    Response.Redirect("InvalidSession.aspx")
        'End If
        Session("Group") = "TOFFIC"
        txtapplication_number.Text = getApplicationNumber()

        'If Not Session("Group") = "TOFFIC" Then
        '    Response.Redirect("/wapwapAppUnavailablel.aspx")
        'End If

        lblMessage.Text = ""

        If Not IsPostBack Then
            cal1.Visible = False
            cal2.Visible = False
            'con.Open()           'Dim ecode As Integer = Session("Ecode")

            'txtemployee_code.Text = ecode
            '   lblMode.Text = Request.QueryString("mode")

            txtemployee_code.Text = Session("Ecode")
            txtemployee_code.ReadOnly = True
            txtemployee_code.Visible = False
            lblempcode.Text = Session("Ecode")
            txtleave_from.ReadOnly = False
            txtleave_to.ReadOnly = False
            getEmployeeDetails()
            '  lblMode.Text = "add"
            'lblMode.Text = Request.QueryString("mode")
            '  txtapplication_number.Text = getApplicationNumber()
            'ddlsanctioned.Enabled = False
            ' txtemployee_code.Text = "12400503337"
            ' txtemployee_code.Text = Session("empCode")
            '  txtemployee_code.ReadOnly = True
            '  getEmployeeDetails()
            ddlout.Visible = False
            ddlfirst_half_from.Visible = False
            ddlfirst_half_to.Visible = False
            ddlconvert.Visible = False
            ' ddlout.Items.Insert(0, "Outside India/Within India")
            Session("half_days") = 0
        End If

    End Sub


    'Function isPreviousDayHoliday() As Boolean
    '    'Dim answer = today.AddDays(-5)
    '    '  Dim s = CDate(Session("leave_from"))
    '    ' Session("date") = s.AddDays(-1)
    '    'Dim holiday_string As String = "SELECT type FROM holiday_master1 WHERE calender_date = '" & Format(Session("date"), "YYYY/MM/DD") & "'"
    '    Dim holiday_string As String = "SELECT type FROM holiday_master1 WHERE calender_date = '" & DateAdd(DateInterval.Day, -1, CDate(Session("leave_from"))) & "'"

    '    Session("leave_type") = SqlHelper.ExecuteScalar(con, CommandType.Text, holiday_string)
    '    If IsDBNull(Session("leave_type")) Then
    '        Return False
    '    Else
    '        Return True
    '    End If

    'End Function
    Function isPreviousDayHoliday() As Boolean
        Dim DD As Date
        DD = Format(CDate(txtleave_from.Text), "yyyy-MM-dd")
        'Dim holiday_string As String = "SELECT type FROM hr_holidays_master WHERE calender_date = '" & DateAdd(DateInterval.Day, -1, CDate(Now)) & "'"
        Dim holiday_string As String = "SELECT type FROM holiday_master1 WHERE calender_date = '" & Format(DateAdd(DateInterval.DayOfYear, -1, DD), "yyyy-MM-dd") & "'"

        Session("leave_type") = SqlHelper.ExecuteScalar(con, CommandType.Text, holiday_string)
        If IsDBNull(Session("leave_type")) Then
            Return False
        Else
            Return True
        End If

    End Function

    'Function checkforCL() As Boolean
    '    Dim leave_code_string As String
    '    Dim isholiday As Boolean = isPreviousDayHoliday()

    '    If (isholiday) = True Then
    '        leave_code_string = "select leavecode from hr_leave_application_details where empno='" & Trim(txtemployee_code.Text) & "'and to_date='" & DateAdd(DateInterval.Day, -2, CDate(Session("leave_from"))) & "'"
    '    Else
    '        leave_code_string = "select leavecode from hr_leave_application_details where empno='" & Trim(txtemployee_code.Text) & "'and to_date='" & DateAdd(DateInterval.Day, -1, CDate(Session("leave_from"))) & "'"
    '    End If

    '    Session("leave_code_previous_day") = SqlHelper.ExecuteScalar(con, CommandType.Text, leave_code_string)

    '    If IsDBNull(Session("leave_code_previous_day")) Then
    '        Return False
    '    ElseIf Session("leave_code_previous_day") = "14" Then
    '        Return True
    '    Else
    '        Return False
    '    End If
    'End Function
    Function checkforCL() As Boolean
        Dim leave_code_string As String
        Dim DD As Date
        DD = Format(CDate(txtleave_from.Text), "yyyy-MM-dd")
        Dim isholiday As Boolean = isPreviousDayHoliday()

        If (isholiday) = True Then
            leave_code_string = "select leavecode from hr_leave_application_details where empno='" & Trim(txtemployee_code.Text) & "'and to_date='" & Format(DateAdd(DateInterval.DayOfYear, -2, DD), "yyyy-MM-dd") & "'"
        Else
            leave_code_string = "select leavecode from hr_leave_application_details where empno='" & Trim(txtemployee_code.Text) & "'and to_date='" & Format(DateAdd(DateInterval.DayOfYear, -1, DD), "yyyy-MM-dd") & "'"
        End If

        Session("leave_code_previous_day") = SqlHelper.ExecuteScalar(con, CommandType.Text, leave_code_string)

        If IsDBNull(Session("leave_code_previous_day")) Then
            Return False
        ElseIf Session("leave_code_previous_day") = "14" Then
            Return True
        Else
            Return False
        End If
    End Function

    Function checkforLAP()
        Dim leave_code_string As String
        Dim isholiday As Boolean = isPreviousDayHoliday()

        If (isholiday) = True Then
            leave_code_string = "select leavecode from hr_leave_application_details where empno='" & Trim(txtemployee_code.Text) & "'and to_date='" & DateAdd(DateInterval.Day, -1, CDate(Session("leave_from"))) & "'"
        Else
            leave_code_string = "select leavecode from hr_leave_application_details where empno='" & Trim(txtemployee_code.Text) & "'and to_date='" & DateAdd(DateInterval.Day, -1, CDate(Session("leave_from"))) & "'"
        End If

        'leave_code_string = "select leave_code from hr_leave_details where employee_code='" & Trim(txtemployee_code.Text) & "'and to_date='" & DateAdd(DateInterval.Day, -1, CDate(session("leave_from"))) & "'"

        Session("leave_code_previous_day") = SqlHelper.ExecuteScalar(con, CommandType.Text, leave_code_string)
        If IsDBNull(Session("leave_code_previous_day")) Then
            Return False
        ElseIf Session("leave_code_previous_day") = "11" Then
            Return True
        Else
            Return False
        End If
    End Function

    'Function getApplicationNumber()
    '    '''insert into code values ('PP','LA','LEAVE','2003001815','')
    '    Dim rdr11 As SqlDataReader
    '    Try
    '        'rdr11 = SqlHelper.ExecuteReader(ConfigurationSettings.AppSettings("con"), CommandType.Text, "select max(application_number)+1 sequence_number from hr_leave_application_details")
    '        Dim QUERY As String
    '        ' QUERY = "select DESCRIPTION from code where application='PP' AND code_type='LA' and code='LEAVE'"


    '        'autonumber = CLng(SqlHelper.ExecuteScalar(ConfigurationManager.AppSettings("con"), CommandType.Text, QUERY))
    '        'autonumber += 1
    '        'QUERY = "update code set DESCRIPTION ='" & autonumber & "'where application='PP' AND code_type='LA' and code='LEAVE'"
    '        QUERY = "select MAX(application_number) from hr_leave_application_details "

    '        Dim appnumber As String
    '        Dim autonumber As Long
    '        appnumber = SqlHelper.ExecuteScalar(ConfigurationSettings.AppSettings("con"), CommandType.Text, QUERY)
    '        '  If Left(appnumber, 4) = Trim(CStr(Year(Now.Date))) Then
    '        autonumber = CLng(appnumber) + 1

    '        ' Else
    '        ' autonumber = Trim(CStr(Year(Now.Date))) + "000001"

    '        '            End If

    '        ' QUERY = "update code set DESCRIPTION ='" & Trim(CStr(autonumber)) & "'where application='PP' AND code_type='LA' and code='LEAVE'"
    '        QUERY = "insert into hr_leave_application_details(application_number,EMPNO,application_type,LEAVECODE,from_date,to_date,l_convert,number_of_days,half_days,address,reason,l_confirm,outstation_or_hq,applied_to) values('" & Trim(CStr(autonumber)) & "','txtemployee_code.Text','C','ddlleave_code.SelectedItem.Value','txtleave_from.Text','txtleave_to.Text','ddlconvert.SelectedIndex.Value',txtdays.Text,0,'txtaddress.Text','txtreason.Text','P', 'ddloutstation_or_hq.SelectedItem.Value','12400503337')"

    '        SqlHelper.ExecuteNonQuery(ConfigurationManager.AppSettings("con"), CommandType.Text, QUERY)
    '        Return autonumber
    '    Catch ee As Exception
    '        lblMessage.Text = ee.Message
    '    End Try
    'End Function
    Function getApplicationNumber()
        Try
            Dim QUERY As String
            '  QUERY = "select DESCRIPTION from code where application='PP' AND code_type='LA' and code='LEAVE'"
            QUERY = "select MAX (CAST(application_number as INT)) from hr_leave_application_details "

            Dim appnumber As String
            Dim autonumber As Long
            'appnumber = SqlHelper.ExecuteScalar(ConfigurationSettings.AppSettings("con"), CommandType.Text, QUERY)
            '  If Left(appnumber, 4) = Trim(CStr(Year(Now.Date))) Then
            If IsDBNull(SqlHelper.ExecuteScalar(ConfigurationSettings.AppSettings("con"), CommandType.Text, QUERY)) Then
                'If IsDBNull(appnumber) Then
                autonumber = 1
            Else
                appnumber = SqlHelper.ExecuteScalar(ConfigurationSettings.AppSettings("con"), CommandType.Text, QUERY)
                autonumber = CLng(appnumber) + 1
            End If
            ' Else
            ' autonumber = Trim(CStr(Year(Now.Date))) + "000001"

            '            End If

            ' QUERY = "update code set DESCRIPTION ='" & Trim(CStr(autonumber)) & "'where application='PP' AND code_type='LA' and code='LEAVE'"
            ' QUERY = "insert into hr_leave_application_details(application_number,EMPNO,application_type,LEAVECODE,from_date,to_date,l_convert,number_of_days,half_days,address,reason,l_confirm,outstation_or_hq,applied_to) values('" & Trim(CStr(autonumber)) & "',txtemployee_code.Text,'C',ddlleave_code.SelectedItem.Value,'txtleave_from.Text','txtleave_to.Text','ddlconvert.SelectedIndex.Value',txtdays.Text,0,'txtaddress.Text','txtreason.Text','P', 'ddloutstation_or_hq.SelectedItem.Value','12400503337')"

            ' SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings("con"), CommandType.Text, QUERY)
            Return autonumber
        Catch ee As Exception
            lblMessage.Text = ee.Message
        End Try
    End Function
    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click

        If Trim(txtreason.Text) = "" Then
            ' lblMessage.Text = "Reason not filled up"
            Dim myscript As String = "window.alert('Reason not filled up');"
            ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
            lblreason.Text = "*"
            lblreason.Visible = True
            lblout.Visible = False
            lbladd.Visible = False
            lblholiday.Visible = False
            Exit Sub
        End If
        If ddloutstation_or_hq.SelectedItem.Text = "" Then
            '  lblMessage.Text = "Headquarter/Outstation not filled up"
            Dim myscript As String = "window.alert('Headquarter/Outstation not filled up');"
            ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
            lblout.Text = "*"
            lblout.Visible = True
            lblreason.Visible = False
            lbladd.Visible = False
            lblholiday.Visible = False
            Exit Sub
        End If
        If Trim(txtaddress.Text) = "" Then
            ' lblMessage.Text = "Address not filled up"
            Dim myscript As String = "window.alert('Address not filled up');"
            ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
            lbladd.Text = "*"
            lbladd.Visible = True
            lblout.Visible = False
            lblreason.Visible = False
            lblholiday.Visible = False
            Exit Sub
        End If

        If ddlleave_code.SelectedItem.Value = "31" Then
            If ddlconvert.SelectedItem.Value = "" Then
                ' lblMessage.Text = "All fields not filled up"
                Dim myscript As String = "window.alert('All fields not filled up');"
                ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
                lblcom.Text = "*"
                lblcom.Visible = True
                lbl1.Visible = False
                lblholiday.Visible = False
                lbladd.Visible = False
                lblout.Visible = False
                lblreason.Visible = False
                lbl2.Visible = False
                Exit Sub
            End If
        End If

        If ddlleave_code.SelectedItem.Value = "CR" Then
            If ddlholiday.SelectedItem.Value = "" Then
                '  lblMessage.Text = "All fields not filled up"
                Dim myscript As String = "window.alert('All fields not filled up');"
                ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
                lblholiday.Text = "*"
                lblholiday.Visible = True
                lblcom.Visible = False
                lbl1.Visible = False

                lbladd.Visible = False
                lblout.Visible = False
                lblreason.Visible = False
                lbl2.Visible = False
                Exit Sub
            End If
        End If


        If ddlleave_code.SelectedItem.Value = "14" Then
            If ddlfirst_half_from.SelectedItem.Value = "" Then
                '   lblMessage.Text = "All fields not filled up"
                Dim myscript As String = "window.alert('All fields not filled up');"
                ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
                lblholiday.Visible = False
                lbl1.Text = "*"
                lbl1.Visible = True
                lblcom.Visible = False
                lbl2.Visible = False


                lbladd.Visible = False
                lblout.Visible = False
                lblreason.Visible = False
                Exit Sub
            End If


            If ddlfirst_half_to.SelectedItem.Value = "" Then
                ' lblMessage.Text = "All fields not filled up"
                Dim myscript As String = "window.alert('All fields not filled up');"
                ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
                lbl2.Text = "*"
                lbl2.Visible = True
                lblcom.Visible = False
                lbl1.Visible = False


                lbladd.Visible = False
                lblout.Visible = False
                lblreason.Visible = False
                Exit Sub
            End If
        End If

        Dim strSQL As String
        Dim tot_bal, leave_pending As Integer
        strSQL = "Select (LEAVEOB+LEAVECREDITED-leaveavailed) tot_bal from leave_header where empno='" & Trim(txtemployee_code.Text) & "' and leavecode='" & ddlleave_code.SelectedItem.Value & "'"
        tot_bal = SqlHelper.ExecuteScalar(ConfigurationSettings.AppSettings("Dbcon"), CommandType.Text, strSQL)

        strSQL = "Select isnull(sum(number_of_days),0) from hr_leave_application_details where empno='" & Trim(txtemployee_code.Text) & "' and leaveCode='" & ddlleave_code.SelectedItem.Value & "' and l_confirm='p'"
        leave_pending = SqlHelper.ExecuteScalar(ConfigurationSettings.AppSettings("Dbcon"), CommandType.Text, strSQL)
        strSQL = "select leave_eligibility from hr_leave_master where leave_code='" & Trim(ddlleave_code.SelectedItem.Value) & "'"
        Dim leave_eligibility As String
        leave_eligibility = SqlHelper.ExecuteScalar(con, CommandType.Text, strSQL)
        'If leave_eligibility = "T" Then
        '    If (leave_pending + Val(txtdays.Text) > tot_bal) Then 'And (Trim(ddlleave_code.SelectedItem.Value) <> "08") And (Trim(ddlleave_code.SelectedItem.Value) <> "PL" And (Trim(ddlleave_code.SelectedItem.Value) <> "18")) Then
        '        'lblMessage.Text = "Not Enough Leave Balance!!!"
        '        Dim myscript As String = "window.alert('Not Enough Leave Balance!');"
        '        ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
        '        Exit Sub
        '    End If
        'End If
        If ddlleave_code.SelectedItem.Value = "CCL" Then
            If (Val(txtdays.Text) > 730) Then 'And (Trim(ddlleave_code.SelectedItem.Value) <> "08") And (Trim(ddlleave_code.SelectedItem.Value) <> "PL" And (Trim(ddlleave_code.SelectedItem.Value) <> "18")) Then
                '  lblMessage.Text = "You cannot apply leave more than 730 days!!!"
                Dim myscript As String = "window.alert('You cannot apply leave more than 730 days!');"
                ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
                Exit Sub
            End If
        End If
        Dim hd_availed As Integer = SqlHelper.ExecuteScalar(con, CommandType.Text, "select isnull(halfcredited,0) from leave_header where empno='" & txtemployee_code.Text & "' and leavecode='11'")
        Dim hd_total As Integer = SqlHelper.ExecuteScalar(con, CommandType.Text, "select isnull(halfcredited,0) from leave_header where empno='" & txtemployee_code.Text & "' and leavecode='11'")

        If (Session("pay_category1") = "5" And hd_availed + Session("half_days") > hd_total) Then
            ' lblMessage.Text = "U have Availed Max of LAP halfdays...."
            Dim myscript As String = "window.alert('You have Availed Max of LAP halfdays!');"
            ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
            Exit Sub
        End If


        'Employee Hierarchy
        Session("date") = SqlHelper.ExecuteScalar(con, CommandType.Text, "SELECT max(W_E_F_) FROM employee_hierarchy where empno='" & Trim(txtemployee_code.Text) & "'")
        Dim date1 As Date = Session("date")
        Session("dept") = SqlHelper.ExecuteScalar(con, CommandType.Text, "SELECT deptcode FROM employee_master where empno='" & Trim(txtemployee_code.Text) & "'")

        Dim con1 As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
        con1.Open()

        Dim empno2 As String = txtemployee_code.Text
        Dim cmd2 As New SqlCommand("SELECT * FROM employee_hierarchy where empno=@empno and w_e_f_=@date  ", con1)
        cmd2.Parameters.AddWithValue("@empno", empno2)
        cmd2.Parameters.AddWithValue("@date", date1)
        Dim reader2 As SqlDataReader = cmd2.ExecuteReader()
        Dim rep As String
        While reader2.Read()
            If Session("dept") = "MECHANICAL" Then

                Dim rep1 As String = reader2("REPORTING_OFFICER").ToString()
                Session("rep") = rep1
                Dim curDate As Date = Date.Now()

                Dim conn1 As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
                conn1.Open()
                Dim j As Integer
                Dim toffc As New SqlCommand("select count(*) from hr_leave_application_details where empno=@rep and CAST(CAST(GETDATE() AS DATE)as datetime) between from_date and to_date", conn1)
                toffc.Parameters.AddWithValue("@rep", rep1)
                j = Convert.ToInt32(toffc.ExecuteScalar())
                If j >= 1 Then
                    Dim rep2 As String = reader2("reviewing_officer").ToString()
                    Session("rep") = rep2
                End If


                If ddlout.SelectedItem.Value = "out" Then
                    Dim rep2 As String = reader2("accepting_officer").ToString()
                    Session("rep") = rep2
                End If
            End If
            If Session("dept") = "electrical" Then
                Dim rep1 As String = reader2("REPORTING_OFFICER").ToString()
                Session("rep") = rep1
                Dim curDate As Date = Date.Now()

                Dim conn1 As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
                conn1.Open()
                Dim j As Integer
                Dim toffc As New SqlCommand("select count(*) from hr_leave_application_details where empno=@rep and CAST(CAST(GETDATE() AS DATE)as datetime) between from_date and to_date", conn1)
                toffc.Parameters.AddWithValue("@rep", rep1)
                j = Convert.ToInt32(toffc.ExecuteScalar())
                If j >= 1 Then
                    Dim rep2 As String = reader2("reviewing_officer").ToString()
                    Session("rep") = rep2
                End If


                If ddlout.SelectedItem.Value = "out" Then
                    Dim rep2 As String = reader2("accepting_officer").ToString()
                    Session("rep") = rep2
                End If
            End If
            If Session("dept") = "MEDICAL" Or Session("dept") = "PERSONNEL" Then
                If ddlleave_code.SelectedItem.Value = "11" Or ddlleave_code.SelectedItem.Value = "31" Then
                    If txtdays.Text <= 30 Then
                        Dim rep1 As String = reader2("REPORTING_OFFICER").ToString()
                        Session("rep") = rep1
                        Dim curDate As Date = Date.Now()

                        Dim conn1 As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
                        conn1.Open()
                        Dim j As Integer
                        Dim toffc As New SqlCommand("select count(*) from hr_leave_application_details where empno=@rep and CAST(CAST(GETDATE() AS DATE)as datetime) between from_date and to_date", conn1)
                        toffc.Parameters.AddWithValue("@rep", rep1)
                        j = Convert.ToInt32(toffc.ExecuteScalar())
                        If j >= 1 Then
                            Dim rep2 As String = reader2("reviewing_officer").ToString()
                            Session("rep") = rep2
                        End If
                    Else
                        Dim rep2 As String = reader2("reviewing_officer").ToString()
                        Session("rep") = rep2
                    End If
                Else
                    Dim rep1 As String = reader2("REPORTING_OFFICER").ToString()
                    Session("rep") = rep1
                    Dim curDate As Date = Date.Now()

                    Dim conn1 As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
                    conn1.Open()
                    Dim j As Integer
                    Dim toffc As New SqlCommand("select count(*) from hr_leave_application_details where empno=@rep and CAST(CAST(GETDATE() AS DATE)as datetime) between from_date and to_date", conn1)
                    toffc.Parameters.AddWithValue("@rep", rep1)
                    j = Convert.ToInt32(toffc.ExecuteScalar())
                    If j >= 1 Then
                        Dim rep2 As String = reader2("reviewing_officer").ToString()
                        Session("rep") = rep2
                    End If
                End If
            End If

            If Session("dept") = "Personnel" Then
                Session("desigcode") = SqlHelper.ExecuteScalar(con, CommandType.Text, "SELECT desigcode FROM employee_master where empno='" & Trim(txtemployee_code.Text) & "'")
                If Session("desgicode") = "Sr. personnel officer-B" Then
                    Dim rep1 As String = reader2("REPORTING_OFFICER").ToString()
                    Session("rep") = rep1
                    Dim curDate As Date = Date.Now()

                    Dim conn1 As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
                    conn1.Open()
                    Dim j As Integer
                    Dim toffc As New SqlCommand("select count(*) from hr_leave_application_details where empno=@rep and CAST(CAST(GETDATE() AS DATE)as datetime) between from_date and to_date", conn1)
                    toffc.Parameters.AddWithValue("@rep", rep1)
                    j = Convert.ToInt32(toffc.ExecuteScalar())
                    If j >= 1 Then
                        Dim rep2 As String = reader2("reviewing_officer").ToString()
                        Session("rep") = rep2
                    End If
                ElseIf Session("desigcode") = "Asst. Pers. Officer-B-JR" Then
                    If ddlleave_code.SelectedItem.Value = "11" Or ddlleave_code.SelectedItem.Value = "31" Then

                        If txtdays.Text <= 21 Then
                            Dim rep1 As String = reader2("REPORTING_OFFICER").ToString()
                            Session("rep") = rep1
                            Dim curDate As Date = Date.Now()

                            Dim conn1 As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
                            conn1.Open()
                            Dim j As Integer
                            Dim toffc As New SqlCommand("select count(*) from hr_leave_application_details where empno=@rep and CAST(CAST(GETDATE() AS DATE)as datetime) between from_date and to_date", conn1)
                            toffc.Parameters.AddWithValue("@rep", rep1)
                            j = Convert.ToInt32(toffc.ExecuteScalar())
                            If j >= 1 Then
                                Dim rep2 As String = reader2("reviewing_officer").ToString()
                                Session("rep") = rep2
                            End If
                        Else
                            Dim rep2 As String = reader2("reviewing_officer").ToString()
                            Session("rep") = rep2
                        End If
                    Else
                        Dim rep1 As String = reader2("REPORTING_OFFICER").ToString()
                        Session("rep") = rep1
                        Dim curDate As Date = Date.Now()

                        Dim conn1 As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
                        conn1.Open()
                        Dim j As Integer
                        Dim toffc As New SqlCommand("select count(*) from hr_leave_application_details where empno=@rep and CAST(CAST(GETDATE() AS DATE)as datetime) between from_date and to_date", conn1)
                        toffc.Parameters.AddWithValue("@rep", rep1)
                        j = Convert.ToInt32(toffc.ExecuteScalar())
                        If j >= 1 Then
                            Dim rep2 As String = reader2("reviewing_officer").ToString()
                            Session("rep") = rep2
                        End If
                    End If

                ElseIf Session("desigcode") = "stenographer grade I" Then
                    If ddlleave_code.SelectedItem.Value = "11" Or ddlleave_code.SelectedItem.Value = "31" Then

                        If txtdays.Text <= 30 Then
                            Dim rep1 As String = reader2("REPORTING_OFFICER").ToString()
                            Session("rep") = rep1
                            Dim curDate As Date = Date.Now()

                            Dim conn1 As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
                            conn1.Open()
                            Dim j As Integer
                            Dim toffc As New SqlCommand("select count(*) from hr_leave_application_details where empno=@rep and CAST(CAST(GETDATE() AS DATE)as datetime) between from_date and to_date", conn1)
                            toffc.Parameters.AddWithValue("@rep", rep1)
                            j = Convert.ToInt32(toffc.ExecuteScalar())
                            If j >= 1 Then
                                Dim rep2 As String = reader2("reviewing_officer").ToString()
                                Session("rep") = rep2
                            End If

                        ElseIf txtdays.Text > 30 And txtdays.Text <= 45 Then
                            Dim rep2 As String = reader2("reviewing_officer").ToString()
                            Session("rep") = rep2

                        Else
                            Dim rep2 As String = reader2("accepting_officer").ToString()
                            Session("rep") = rep2

                        End If
                    ElseIf ddlleave_code.SelectedItem.Value = "14" Or ddlleave_code.SelectedItem.Value = "17" Then
                        If txtdays.Text <= 30 Then
                            Dim rep1 As String = reader2("REPORTING_OFFICER").ToString()
                            Session("rep") = rep1
                            Dim curDate As Date = Date.Now()

                            Dim conn1 As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
                            conn1.Open()
                            Dim j As Integer
                            Dim toffc As New SqlCommand("select count(*) from hr_leave_application_details where empno=@rep and CAST(CAST(GETDATE() AS DATE)as datetime) between from_date and to_date", conn1)
                            toffc.Parameters.AddWithValue("@rep", rep1)
                            j = Convert.ToInt32(toffc.ExecuteScalar())
                            If j >= 1 Then
                                Dim rep2 As String = reader2("reviewing_officer").ToString()
                                Session("rep") = rep2
                            End If
                        Else
                            Dim rep2 As String = reader2("revieing_officer").ToString()
                            Session("rep") = rep2
                        End If
                    End If
                ElseIf Session("desigcode") = "OFFICE SUPERINTENDENT" Then
                    If ddlleave_code.SelectedItem.Value = "14" Or ddlleave_code.SelectedItem.Value = "17" Then

                        If txtdays.Text <= 30 Then
                            Dim rep1 As String = reader2("REPORTING_OFFICER").ToString()
                            Session("rep") = rep1
                            Dim curDate As Date = Date.Now()

                            Dim conn1 As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
                            conn1.Open()
                            Dim j As Integer
                            Dim toffc As New SqlCommand("select count(*) from hr_leave_application_details where empno=@rep and CAST(CAST(GETDATE() AS DATE)as datetime) between from_date and to_date", conn1)
                            toffc.Parameters.AddWithValue("@rep", rep1)
                            j = Convert.ToInt32(toffc.ExecuteScalar())
                            If j >= 1 Then
                                Dim rep2 As String = reader2("reviewing_officer").ToString()
                                Session("rep") = rep2
                            End If
                        Else
                            Dim rep2 As String = reader2("reviewing_officer").ToString()
                            Session("rep") = rep2
                        End If
                    Else
                        Dim rep1 As String = reader2("REPORTING_OFFICER").ToString()
                        Session("rep") = rep1
                        Dim curDate As Date = Date.Now()
                        Dim conn1 As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
                        conn1.Open()
                        Dim j As Integer
                        Dim toffc As New SqlCommand("select count(*) from hr_leave_application_details where empno=@rep and CAST(CAST(GETDATE() AS DATE)as datetime) between from_date and to_date", conn1)
                        toffc.Parameters.AddWithValue("@rep", rep1)
                        j = Convert.ToInt32(toffc.ExecuteScalar())
                        If j >= 1 Then
                            Dim rep2 As String = reader2("reviewing_officer").ToString()
                            Session("rep") = rep2
                        End If
                    End If
                End If
            End If
            If Session("dept") = "ENGINEERING" Then
                Session("desigcode") = SqlHelper.ExecuteScalar(con, CommandType.Text, "SELECT desigcode FROM employee_master where empno='" & Trim(txtemployee_code.Text) & "'")
                If Session("desgicode") = "technicican III" Or Session("desgicode") = "khalasi helper" Or Session("desgicode") = "khalasi(multi purpose)" Or Session("desgicode") = "helper" Then

                    If ddlleave_code.SelectedItem.Value = "11" Or ddlleave_code.SelectedItem.Value = "31" Then

                        If txtdays.Text <= 15 Then
                            Dim rep1 As String = reader2("REPORTING_OFFICER").ToString()
                            Session("rep") = rep1
                            Dim curDate As Date = Date.Now()

                            Dim conn1 As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
                            conn1.Open()
                            Dim j As Integer
                            Dim toffc As New SqlCommand("select count(*) from hr_leave_application_details where empno=@rep and CAST(CAST(GETDATE() AS DATE)as datetime) between from_date and to_date", conn1)
                            toffc.Parameters.AddWithValue("@rep", rep1)
                            j = Convert.ToInt32(toffc.ExecuteScalar())
                            If j >= 1 Then
                                Dim rep2 As String = reader2("reviewing_officer").ToString()
                                Session("rep") = rep2
                            End If
                        ElseIf txtdays.Text > 15 And txtdays.Text <= 30 Then
                            Dim rep2 As String = reader2("reviewing_officer").ToString()
                            Session("rep") = rep2

                        ElseIf txtdays.Text > 30 And txtdays.Text <= 45 Then
                            Dim rep2 As String = reader2("accepting_officer").ToString()
                            Session("rep") = rep2

                        ElseIf txtdays.Text > 45 Then
                            Dim rep2 As String = reader2("final_officer").ToString()
                            Session("rep") = rep2
                        End If


                    Else
                        Dim rep1 As String = reader2("REPORTING_OFFICER").ToString()
                        Session("rep") = rep1
                        Dim curDate As Date = Date.Now()
                        Dim conn1 As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
                        conn1.Open()
                        Dim j As Integer
                        Dim toffc As New SqlCommand("select count(*) from hr_leave_application_details where empno=@rep and CAST(CAST(GETDATE() AS DATE)as datetime) between from_date and to_date", conn1)
                        toffc.Parameters.AddWithValue("@rep", rep1)
                        j = Convert.ToInt32(toffc.ExecuteScalar())
                        If j >= 1 Then
                            Dim rep2 As String = reader2("reviewing_officer").ToString()
                            Session("rep") = rep2
                        End If
                    End If
                ElseIf Session("desigcode") = "executuive engineer-B" Or Session("desigcode") = "asst. enngineer-B-SR" Then

                    If ddlleave_code.SelectedItem.Value = "11" Or ddlleave_code.SelectedItem.Value = "31" Then

                        If txtdays.Text <= 21 Then
                            Dim rep1 As String = reader2("REPORTING_OFFICER").ToString()
                            Session("rep") = rep1
                            Dim curDate As Date = Date.Now()

                            Dim conn1 As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
                            conn1.Open()
                            Dim j As Integer
                            Dim toffc As New SqlCommand("select count(*) from hr_leave_application_details where empno=@rep and CAST(CAST(GETDATE() AS DATE)as datetime) between from_date and to_date", conn1)
                            toffc.Parameters.AddWithValue("@rep", rep1)
                            j = Convert.ToInt32(toffc.ExecuteScalar())
                            If j >= 1 Then
                                Dim rep2 As String = reader2("reviewing_officer").ToString()
                                Session("rep") = rep2
                            End If

                        Else
                            Dim rep2 As String = reader2("reviewing_officer").ToString()
                            Session("rep") = rep2
                        End If


                    Else
                        Dim rep1 As String = reader2("REPORTING_OFFICER").ToString()
                        Session("rep") = rep1
                        Dim curDate As Date = Date.Now()

                        Dim conn1 As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
                        conn1.Open()
                        Dim j As Integer
                        Dim toffc As New SqlCommand("select count(*) from hr_leave_application_details where empno=@rep and CAST(CAST(GETDATE() AS DATE)as datetime) between from_date and to_date", conn1)
                        toffc.Parameters.AddWithValue("@rep", rep1)
                        j = Convert.ToInt32(toffc.ExecuteScalar())
                        If j >= 1 Then
                            Dim rep2 As String = reader2("reviewing_officer").ToString()
                            Session("rep") = rep2
                        End If
                    End If
                ElseIf Session("desigcode") = "Dy. chief engineer-JAG" Then
                    Dim rep1 As String = reader2("REPORTING_OFFICER").ToString()
                    Session("rep") = rep1
                    Dim curDate As Date = Date.Now()

                    Dim conn1 As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
                    conn1.Open()
                    Dim j As Integer
                    Dim toffc As New SqlCommand("select count(*) from hr_leave_application_details where empno=@rep and CAST(CAST(GETDATE() AS DATE)as datetime) between from_date and to_date", conn1)
                    toffc.Parameters.AddWithValue("@rep", rep1)
                    j = Convert.ToInt32(toffc.ExecuteScalar())
                    If j >= 1 Then
                        Dim rep2 As String = reader2("reviewing_officer").ToString()
                        Session("rep") = rep2
                    End If
                Else
                    If ddlleave_code.SelectedItem.Value = "11" Or ddlleave_code.SelectedItem.Value = "31" Then

                        If txtdays.Text <= 30 Then
                            Dim rep1 As String = reader2("REPORTING_OFFICER").ToString()
                            Session("rep") = rep1
                            Dim curDate As Date = Date.Now()

                            Dim conn1 As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
                            conn1.Open()
                            Dim j As Integer
                            Dim toffc As New SqlCommand("select count(*) from hr_leave_application_details where empno=@rep and CAST(CAST(GETDATE() AS DATE)as datetime) between from_date and to_date", conn1)
                            toffc.Parameters.AddWithValue("@rep", rep1)
                            j = Convert.ToInt32(toffc.ExecuteScalar())
                            If j >= 1 Then
                                Dim rep2 As String = reader2("reviewing_officer").ToString()
                                Session("rep") = rep2
                            End If
                        ElseIf txtdays.Text > 30 And txtdays.Text <= 45 Then
                            Dim rep2 As String = reader2("reviewing_officer").ToString()
                            Session("rep") = rep2


                        ElseIf txtdays.Text > 45 Then
                            Dim rep2 As String = reader2("accepting_officer").ToString()
                            Session("rep") = rep2
                        End If


                    Else
                        Dim rep1 As String = reader2("REPORTING_OFFICER").ToString()
                        Session("rep") = rep1
                        Dim curDate As Date = Date.Now()

                        Dim conn1 As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
                        conn1.Open()
                        Dim j As Integer
                        Dim toffc As New SqlCommand("select count(*) from hr_leave_application_details where empno=@rep and CAST(CAST(GETDATE() AS DATE)as datetime) between from_date and to_date", conn1)
                        toffc.Parameters.AddWithValue("@rep", rep1)
                        j = Convert.ToInt32(toffc.ExecuteScalar())
                        If j >= 1 Then
                            Dim rep2 As String = reader2("reviewing_officer").ToString()
                            Session("rep") = rep2
                        End If
                    End If

                End If
            End If
        End While
        con.Close()

        'Notification to sanctioning authority

        'SMS Notification

        Dim message1 = "Leave request by " + lblname.Text + " From date: " + txtleave_from.Text + " To date: " + txtleave_to.Text

        Try


            Dim conc As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
            conc.Open()

            'Dim cmd As New SqlCommand("SELECT mobile_no FROM emp_details where shop_code=@sc ", con)
            Dim empno3 As String = Session("rep")
            Dim cmd11 As New SqlCommand("SELECT * FROM emp_details_new where empno=@empno  ", conc)
            cmd11.Parameters.AddWithValue("@empno", empno3)
            'cmd.Parameters.AddWithValue("@mpo", mpo)
            Dim reader As SqlDataReader = cmd11.ExecuteReader()

            While reader.Read()

                'Dim no As String = reader("Mobile_no").ToString()
                Dim no As String = reader("Mobileno").ToString()
                Dim number As String = "91" + no

                Dim strGet As String
                ' Dim url As String = "http://enterprise.smsgupshup.com/GatewayAPI/rest?method=SendMessage&send_to=919461013570?msg=message&msg_type=TEXT&userid=2000184632&auth_scheme=plain&password=pWK3H5&v=1.1&format=text"
                Dim url1 As String = "http://enterprise.smsgupshup.com/GatewayAPI/rest?method=SendMessage&send_to="
                Dim url2 As String = "&msg="
                Dim url3 As String = "&msg_type=TEXT&userid=2000184632&auth_scheme=plain&password=pWK3H5&v=1.1&format=text"

                strGet = url1 + number + url2 + message1 + url3

                Dim webClient As New System.Net.WebClient
                Dim result As String = webClient.DownloadString(strGet)
            End While
            conc.Close()




        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        'Email notification

        Dim APIKey1 As String = "95f0f61edc6954a4ba18bd8d0a687a64"
        Dim SecretKey1 As String = "a6a93c7cdb139d42799bef64b0b44845"
        Dim From1 As String = "pankaj.motwani@cris.org.in"
        Dim connc As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
        connc.Open()

        'Dim cmd As New SqlCommand("SELECT mobile_no FROM emp_details where shop_code=@sc ", con)
        Dim empno11 As String = Session("rep")
        Dim cmd12 As New SqlCommand("SELECT * FROM emp_details_new where empno=@empno  ", connc)
        cmd12.Parameters.AddWithValue("@empno", empno11)
        Dim reader12 As SqlDataReader = cmd12.ExecuteReader()
        Dim to11, to123 As String '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~```change'
        While reader12.Read()

            to11 = reader12("email_id")
            to123 = reader12("empname") '~~~~~~~~~~~~~~~~~~~~~~~~~~`change'

        End While

        'Dim To1 As String = "adiiig98@gmail.com"

        Dim msg1 As New MailMessage()

        msg1.From = New MailAddress(From1)

        msg1.To.Add(New MailAddress(to11))

        msg1.Subject = "New Leave Request"
        msg1.Body = "Leave request by " + lblname.Text + " From date: " + txtleave_from.Text + " To date: " + txtleave_to.Text


        Dim client1 As New SmtpClient("in-v3.mailjet.com", 587)

        client1.EnableSsl = True

        client1.Credentials = New NetworkCredential(APIKey1, SecretKey1)

        client1.Send(msg1)




        Dim sqlpara(16) As SqlParameter

        sqlpara(0) = New SqlParameter("@txtapplication_number", txtapplication_number.Text)
        sqlpara(1) = New SqlParameter("@txtemployee_code", txtemployee_code.Text)
        sqlpara(2) = New SqlParameter("@ddlleave_code", ddlleave_code.SelectedItem.Value)
        sqlpara(3) = New SqlParameter("@txtfrom_date", Session("leave_from"))
        sqlpara(4) = New SqlParameter("@txtto_date", Session("leave_to"))
        sqlpara(5) = New SqlParameter("@ddlfrom_f_a_indicator", ddlfirst_half_from.SelectedItem.Value)
        sqlpara(6) = New SqlParameter("@ddlto_f_a_indicator", ddlfirst_half_to.SelectedItem.Value)
        sqlpara(7) = New SqlParameter("@ddll_convert", ddlconvert.SelectedItem.Value)
        sqlpara(8) = New SqlParameter("@txtnumber_of_days", txtdays.Text)
        sqlpara(9) = New SqlParameter("@txtaddress", txtaddress.Text)
        sqlpara(10) = New SqlParameter("@txtreason", txtreason.Text)
        sqlpara(11) = New SqlParameter("@ddloutstationHqrs", ddloutstation_or_hq.SelectedItem.Value)
        sqlpara(12) = New SqlParameter("@half_days", Session("half_days"))
        sqlpara(13) = New SqlParameter("@change_date", Format(CDate(Now), "MM/dd/yyyy"))
        sqlpara(14) = New SqlParameter("@change_time", Format(CDate(Now), "MM/dd/yyyy HH:mm:ss"))
        sqlpara(15) = New SqlParameter("@userid", UCase(Session("bill_unit")))
        sqlpara(16) = New SqlParameter("@rep", Session("rep"))

        Dim insertStr As String
        insertStr = "insert into hr_leave_application_details (application_number,application_type,l_confirm,applied_to,empno,leavecode,from_date,"
        insertStr = insertStr & "to_date,from_f_a_indicator,to_f_a_indicator,l_convert,number_of_days,address,reason,"
        insertStr = insertStr & "outstation_or_hq,half_days,change_time,change_date,user_id) values (@txtapplication_number,"
        insertStr = insertStr & "'C','p',@rep,@txtemployee_code,@ddlleave_code,@txtfrom_date,@txtto_date,@ddlfrom_f_a_indicator,@ddlto_f_a_indicator,"
        insertStr = insertStr & "@ddll_convert,@txtnumber_of_days,@txtaddress,@txtreason,@ddloutstationHqrs,@half_days,"
        insertStr = insertStr & "@change_time,@change_date,@userid)"
        '~~~~~~~~~~for knowing name of sanctioning authority'

        Try
            SqlHelper.ExecuteNonQuery(con, CommandType.Text, insertStr, sqlpara)
            '   lblMessage.Text = "Note the Application number: " & txtapplication_number.Text
            Dim i As Integer
            'i = MsgBox("Note the Application number: " & txtapplication_number.Text, 0, "Information")
            'Dim myscript As String = "window.alert('Leave applied successfully  '" + to123 + ");"
            'ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
            Response.Write("<script>alert('Leave applied successfully to " + to123 + "')</script>") '~~~~~~~~~~~~change'
            'lblMode.Text = "Updated...."

            'txtapplication_number.Text = getApplicationNumber()
        Catch ee As Exception
            Response.Write(ee.Message)
        End Try
        ' Response.Redirect("leaveQuery.aspx")

        '~~~~~~~~~~~~~~~~~~~~~SMS Notification

        Dim message = "Leave applied successfully to " + to123 + " From Date: " + txtleave_from.Text + " To date: " + txtleave_to.Text

        Try


            Dim con As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
            con.Open()

            'Dim cmd As New SqlCommand("SELECT mobile_no FROM emp_details where shop_code=@sc ", con)
            Dim empno As String = txtemployee_code.Text
            Dim cmd As New SqlCommand("SELECT * FROM emp_details_new where empno=@empno  ", con)
            cmd.Parameters.AddWithValue("@empno", empno)
            'cmd.Parameters.AddWithValue("@mpo", mpo)
            Dim reader As SqlDataReader = cmd.ExecuteReader()

            While reader.Read()

                'Dim no As String = reader("Mobile_no").ToString()
                Dim no As String = reader("Mobileno").ToString()
                Dim number As String = "91" + no

                Dim strGet As String
                ' Dim url As String = "http://enterprise.smsgupshup.com/GatewayAPI/rest?method=SendMessage&send_to=919461013570?msg=message&msg_type=TEXT&userid=2000184632&auth_scheme=plain&password=pWK3H5&v=1.1&format=text"
                Dim url1 As String = "http://enterprise.smsgupshup.com/GatewayAPI/rest?method=SendMessage&send_to="
                Dim url2 As String = "&msg="
                Dim url3 As String = "&msg_type=TEXT&userid=2000184632&auth_scheme=plain&password=pWK3H5&v=1.1&format=text"

                strGet = url1 + number + url2 + message + url3

                Dim webClient As New System.Net.WebClient
                Dim result As String = webClient.DownloadString(strGet)
            End While






            con.Close()




        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        'Email notification

        Dim APIKey As String = "95f0f61edc6954a4ba18bd8d0a687a64"
        Dim SecretKey As String = "a6a93c7cdb139d42799bef64b0b44845"
        Dim From As String = "pankaj.motwani@cris.org.in"
        Dim conn As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
        conn.Open()

        'Dim cmd As New SqlCommand("SELECT mobile_no FROM emp_details where shop_code=@sc ", con)
        Dim empno1 As String = txtemployee_code.Text
        Dim cmd1 As New SqlCommand("SELECT * FROM emp_details_new where empno=@empno  ", conn)
        cmd1.Parameters.AddWithValue("@empno", empno1)
        Dim reader1 As SqlDataReader = cmd1.ExecuteReader()
        Dim to1 As String
        While reader1.Read()
            to1 = reader1("email_id")
        End While
        Dim msg As New MailMessage()

        msg.From = New MailAddress(From)

        msg.To.Add(New MailAddress(to1))

        msg.Subject = "Leave application status"
        msg.Body = "Leave applied successfully to " + to123 + " From date: " + txtleave_from.Text + " To date: " + txtleave_to.Text


        Dim client As New SmtpClient("in-v3.mailjet.com", 587)

        client.EnableSsl = True

        client.Credentials = New NetworkCredential(APIKey, SecretKey)

        client.Send(msg)

        Call clearall()
        Call BindGrid1()
    End Sub



    Private Sub getEmployeeDetails()
        '   Session("empno") = txtemployee_code.Text
        Dim available1 As Boolean = validateemployeenumber()
        If available1 = True Then

            Call employeedetails()
            txtleave_from.Text = ""
            txtleave_to.Text = ""
            ddlfirst_half_from.SelectedIndex = -1
            ddlfirst_half_to.SelectedIndex = -1
            txtdays.Text = ""

            'SELECT DISTINCT leave_code FROM(hr_leave_master)WHERE (sex = 'a') OR (sex = 'f')
            Session("sex") = SqlHelper.ExecuteScalar(con, CommandType.Text, "select sex from employee_master where empno='" & Trim(txtemployee_code.Text) & "'")
            Session("pay_category1") = SqlHelper.ExecuteScalar(con, CommandType.Text, "select paycategory from employee_master where empno='" & Trim(txtemployee_code.Text) & "'")

            Dim leavecodestring As String = "select distinct leave_code,description FROM hr_leave_master where sex = 'A' OR sex ='" & Session("sex") & "' and pay_category='" & Session("pay_category1") & "'"
            rdr = SqlHelper.ExecuteReader(con, CommandType.Text, leavecodestring)
            'ddlleave_code.DataValueField = "leave_code"
            'ddlleave_code.DataTextField = "description"
            'ddlleave_code.DataSource = rdr
            'ddlleave_code.DataBind()
            If (Session("sex").Equals("M")) Then
                ddlleave_code.Items.Remove(ddlleave_code.Items.FindByValue("08"))
            End If
            If (Session("sex").Equals("F")) Then
                ddlleave_code.Items.Remove(ddlleave_code.Items.FindByValue("PL"))
            End If
            rdr.Close()
            Dim conn As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
            conn.Open()

            'Dim cmd As New SqlCommand("SELECT mobile_no FROM emp_details where shop_code=@sc ", con)
            Dim empno As String = txtemployee_code.Text
            Dim cmd As New SqlCommand("SELECT * FROM employee_master where empno=@empno  ", conn)
            cmd.Parameters.AddWithValue("@empno", empno)
            'cmd.Parameters.AddWithValue("@mpo", mpo)
            Dim reader As SqlDataReader = cmd.ExecuteReader()

            While reader.Read()

                'Dim no As String = reader("Mobile_no").ToString()
                Dim no As String = reader("payband").ToString()
                If no = "3" Or no = "4" Then
                    ddlleave_code.Items.Remove(ddlleave_code.Items.FindByValue("CR"))

                ElseIf no = "2" Then
                    Dim scode As String = reader("scalecode")
                    If scode = "5400" Then
                        ddlleave_code.Items.Remove(ddlleave_code.Items.FindByValue("CR"))
                    End If
                End If
            End While

            'ddlleave_code.Items.Insert(0, "")

            ' to clear the message lable and enable the fields
            ddlfirst_half_from.Enabled = True
            ddlfirst_half_to.Enabled = True
            'lblMessage.Text = ""
            'lblMode.Text = ""

            ' to get the sex of the employee
            getemployeesex()

            Call BindGrid1()
            Call BindGrid2()

        Else
            'lblMessage.Text = "Invalid Employee.."
            Dim myscript As String = "Invalid Employee..');"
            ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
            Exit Sub

        End If
    End Sub

    Sub employeedetails()
        Dim rdr2 As SqlDataReader
        Dim sqlstring2 As String

        sqlstring2 = "select empname,desigcode,billunit from employee_master where empno='" & Trim(txtemployee_code.Text) & "'"
        rdr2 = SqlHelper.ExecuteReader(con, CommandType.Text, sqlstring2)
        'Dim d As Date
        While rdr2.Read
            lblname.Text = IIf(IsDBNull(rdr2.Item("empname")), "", rdr2.Item("empname"))
            Session("code") = (Trim(rdr2.Item("desigcode")))
            Session("billunit") = IIf(IsDBNull(rdr2.Item("billunit")), "", rdr2.Item("billunit"))
        End While
        rdr2.Close()
        lbldesignation.Text = SqlHelper.ExecuteScalar(con, CommandType.Text, "select desigcode from employee_master where desigcode='" & Session("code") & "'")
    End Sub

    Sub getemployeesex()
        Session("sex") = SqlHelper.ExecuteScalar(con, CommandType.Text, "select sex from employee_master where empno='" & Trim(txtemployee_code.Text) & "'")
    End Sub

    Function validateemployeenumber() As Boolean
        Dim available As Boolean

        Dim rdr1 As SqlDataReader
        Dim sqlstring As String
        'Dim pass As String

        sqlstring = "select empno from employee_master where empno='" & Trim(txtemployee_code.Text) & "'"
        rdr1 = SqlHelper.ExecuteReader(ConfigurationSettings.AppSettings("con"), CommandType.Text, sqlstring)

        While rdr1.Read
            If IsDBNull(rdr1.Item("empno")) = True Then
                available = False
            Else
                available = True
            End If
        End While
        rdr1.Close()
        Return available
    End Function

    Private Sub ddlleave_code_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlleave_code.SelectedIndexChanged
        'clear the selections in Forenoon,Afternoon indicators
        ddlfirst_half_from.SelectedIndex = -1
        ddlfirst_half_to.SelectedIndex = -1
        lblcom.Visible = False
        lbl1.Visible = False
        lbl2.Visible = False

        If ddlleave_code.SelectedItem.Value = "07" Then
            Dim conn As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
            conn.Open()
            Dim j As Integer
            Dim toffc As New SqlCommand("SELECT COUNT(*) FROM hr_leave_application_details where LEAVECODE='07' and empno='" & Trim(txtemployee_code.Text) & "'", conn)
            'toffc.Parameters.AddWithValue("@startDate", startdate)
            j = Convert.ToInt32(toffc.ExecuteScalar())
            If j >= 2 Then
                Dim i As Integer
                ' i = MsgBox("STUDY LEAVE cannot be applied more than two times", 0, "Information")
                Dim myscript As String = "window.alert('Study leave cannnot be applied more than two times');"
                ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)

                cmdSave.Enabled = False
                Exit Sub
            Else
                cmdSave.Enabled = True
            End If

            Dim regDate As Date = Date.Now()
            Dim myyear = regDate.Year
            'Session("year") = SqlHelper.ExecuteScalar(con, CommandType.Text, "select rlyjoindate from employee_master where empno='" & Trim(txtemployee_code.Text) & "'")
            'Dim myyear1 = Session("Year").Year
            Dim con As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
            con.Open()

            'Dim cmd As New SqlCommand("SELECT mobile_no FROM emp_details where shop_code=@sc ", con)
            Dim empno As String = txtemployee_code.Text
            Dim cmd As New SqlCommand("SELECT * FROM employee_master where empno=@empno  ", con)
            cmd.Parameters.AddWithValue("@empno", empno)
            'cmd.Parameters.AddWithValue("@mpo", mpo)
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            Dim myyear1 As Integer
            While reader.Read()

                'Dim no As String = reader("Mobile_no").ToString()
                Dim y As Date = reader("rlyjoindate")
                myyear1 = y.Year
            End While

            Dim dif As Integer
            dif = myyear - myyear1
            If dif < 5 Then
                Dim i As Integer
                '   i = MsgBox("STUDY LEAVE cannot be applied as less than 5 years", 0, "Information")
                Dim myscript As String = "window.alert('Study leave cannot be applied as less than 5 years of experience');"
                ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)

                cmdSave.Enabled = False
                Exit Sub
            Else
                cmdSave.Enabled = True
            End If

        End If



        If ddlleave_code.SelectedItem.Value = "CCL" Then
            Dim regDate As Date = Date.Now()
            Dim myyear = regDate.Year
            Dim conn As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
            conn.Open()
            Dim toffc As New SqlCommand("select count(*) from hr_leave_application_details where empno='" & txtemployee_code.Text & "' and year(from_date)=@year and leavecode ='CCL'", conn)
            toffc.Parameters.AddWithValue("@year", myyear)
            Dim i As Integer

            i = Convert.ToInt32(toffc.ExecuteScalar())



            If i >= 3 Then
                Dim j As Integer
                'j = MsgBox("CCL can not be applied", 0, "Information")
                Dim myscript As String = "window.alert('CCL cannot be applied');"
                ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)

                cmdSave.Enabled = False
            Else
                cmdSave.Enabled = True
            End If

        End If
        'If ddlleave_code.SelectedItem.Value = "14" Then

        '    Dim QUERY As String
        '    QUERY = "select count(*) from hr_leave_application_details where empno='" & txtemployee_code.Text & "' and l_confirm='p' and leavecode !='SCL'"

        '    Dim i As Integer

        '    i = SqlHelper.ExecuteScalar(ConfigurationSettings.AppSettings("con"), CommandType.Text, QUERY)
        '    If i > 0 Then
        '        Dim j As Integer
        '        '  j = MsgBox("CL can not be applied", 0, "Information")
        '        Dim myscript As String = "window.alert('CL cannot be applied');"
        '        ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)

        '        cmdSave.Enabled = False
        '    Else
        '        cmdSave.Enabled = True
        '    End If
        'End If

        If ddlleave_code.SelectedItem.Value <> "14" Then

            Dim QUERY As String
            QUERY = "select count(*) from hr_leave_application_details where empno='" & txtemployee_code.Text & "' and l_confirm='p' and leavecode ='14'"

            Dim i As Integer

            i = SqlHelper.ExecuteScalar(ConfigurationSettings.AppSettings("con"), CommandType.Text, QUERY)
            If i > 0 Then
                Dim j As Integer
                '  j = MsgBox("CL can not be merged with this leave code", 0, "Information")
                Dim myscript As String = "window.alert('CL cannot be merged with this leave code');"
                ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)

                cmdSave.Enabled = False
            Else
                cmdSave.Enabled = True
            End If
        End If


        If (ddlleave_code.SelectedItem.Value = "31") Then

            lblcl1.Text = ""
            lblcl2.Text = ""
            ddlfirst_half_from.Visible = False
            ddlfirst_half_to.Visible = False
            lblcommute.Text = "Commute :"
            lblhol.Visible = False
            ddlconvert.Visible = True
            ddlholiday.Visible = False

        ElseIf (ddlleave_code.SelectedItem.Value = "14") Then
            lblcommute.Text = ""
            ddlholiday.Visible = False

            ddlconvert.Visible = False
            lblhol.Visible = False
            lblcl1.Text = "1st half/2nd half :"
            lblcl2.Text = "1st half/2nd half :"
            ddlfirst_half_from.Visible = True
            ddlfirst_half_to.Visible = True

        ElseIf (ddlleave_code.SelectedItem.Value = "CR") Then
            lblcommute.Text = ""

            ddlconvert.Visible = False
            lblhol.Text = "Holidays"
            lblhol.Visible = True
            lblcl1.Text = ""
            lblcl2.Text = ""
            ddlfirst_half_from.Visible = False
            ddlfirst_half_to.Visible = False
            Dim leavecodestring As String = "select distinct calender_date,description FROM holiday_master1"
            rdr = SqlHelper.ExecuteReader(con, CommandType.Text, leavecodestring)
            ddlholiday.DataValueField = "calender_date"
            ddlholiday.DataTextField = "description"
            ddlholiday.DataSource = rdr
            ddlholiday.DataBind()
            ddlholiday.Visible = True
        Else

            lblcl1.Text = ""
            lblcl2.Text = ""
            ddlfirst_half_from.Visible = False
            ddlfirst_half_to.Visible = False
            lblcommute.Text = ""
            ddlholiday.Visible = False
            lblhol.Visible = False
            ddlconvert.Visible = False

        End If
        If (ddlleave_code.SelectedItem.Value = "CC") Then
            Dim QUERY As String
            QUERY = "select count(*) from hr_leave_application_details where empno='" & Trim(txtemployee_code.Text) & "' and l_convert='Y'"

            Dim i As Integer

            i = SqlHelper.ExecuteScalar(ConfigurationSettings.AppSettings("con"), CommandType.Text, QUERY)
            If i > 0 Then
                Dim strSQL As String
                Dim tot_bal, tot_bal1 As Integer
                strSQL = "Select (LEAVEOB+LEAVECREDITED-leaveavailed) tot_bal from leave_header where empno='" & Trim(txtemployee_code.Text) & "' and leavecode='11'"
                tot_bal = SqlHelper.ExecuteScalar(ConfigurationSettings.AppSettings("Dbcon"), CommandType.Text, strSQL)
                strSQL = "Select (LEAVEOB+LEAVECREDITED-leaveavailed) tot_bal from leave_header where empno='" & Trim(txtemployee_code.Text) & "' and leavecode='31'"
                tot_bal1 = SqlHelper.ExecuteScalar(ConfigurationSettings.AppSettings("Dbcon"), CommandType.Text, strSQL)

                If tot_bal > 0 Or tot_bal1 > 0 Then
                    '  MsgBox("You can't apply for CCL", 0, "Information")
                    Dim myscript As String = "window.alert('You can't apply for CCL');"
                    ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)

                    ddlleave_code.Items.Remove(ddlleave_code.Items.FindByValue("CC"))
                End If
            End If
        End If
        'If ddlleave_code.SelectedItem.Value = "14" Or ddlleave_code.SelectedItem.Value = "01" Or ddlleave_code.SelectedItem.Value = "06" Then
        '    ddlfirst_half_from.Enabled = True
        '    ddlfirst_half_to.Enabled = True
        'Else
        '    ddlfirst_half_from.Enabled = False
        '    ddlfirst_half_to.Enabled = False
        'End If

        'If ddlleave_code.SelectedItem.Value = "02" Then
        '    ddlconvert.Enabled = True
        'Else
        '    ddlconvert.Enabled = False
        'End If

        If (Session("pay_category1") = "5" And (ddlleave_code.SelectedItem.Value = "11")) Then
            ddlfirst_half_from.Enabled = True
            ddlfirst_half_to.Enabled = True
        End If
        calculateDays()
    End Sub

    Private Sub txtleave_to_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtleave_to.TextChanged
        calculateDays()
    End Sub

    Private Sub calculateDays()
        Dim from_Date, to_date As Date
        lblMessage.Text = ""
        If Not Len(txtleave_from.Text) > 0 Then
            Exit Sub
        End If
        If Not Len(txtleave_to.Text) > 0 Then
            Exit Sub
        End If

        Session("leave_from") = CDate(txtleave_from.Text)
        Session("leave_to") = CDate(txtleave_to.Text)


        'Session("leave_from") = cal1.SelectedDate.ToString
        'Session("leave_to") = cal2.SelectedDate.ToString
        'Session("leave_from") = Convert.ToDateTime(Session("leave_from1"))


        'Session("leave_to1") = cal2.SelectedDate
        'Session("leave_to") = Convert.ToDateTime(Session("leave_to1"))
        If CDate(Session("leave_from")) > CDate(Session("leave_to")) Then
            ' lblMessage.Text = "From Leave Date Cant be More than To leave Date...."
            Dim myscript As String = "window.alert('From Leave Date Cant be More than To leave Date!');"
            ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)

            Session("leave_from") = ""
            txtleave_to.Text = ""
            txtleave_from.Text = ""
            ddlconvert.SelectedIndex = -1
            ddlleave_code.SelectedIndex = -1
            txtdays.Text = ""
            cmdSave.Enabled = False
            Exit Sub
        Else
            cmdSave.Enabled = True
        End If

        Dim rdr1 As SqlDataReader
        Dim sqlst As String = "select from_date,to_date from hr_leave_application_details where empno='" & Trim(txtemployee_code.Text) & "'"
        rdr1 = SqlHelper.ExecuteReader(ConfigurationSettings.AppSettings("con"), CommandType.Text, sqlst)
        If Not IsDBNull(rdr1) Then
            While rdr1.Read
                Dim ch As Boolean = checkdateinbetween(CDate(Session("leave_from")), CDate(rdr1.Item("from_date")), CDate(rdr1.Item("to_date")))
                If ch = True Then
                    'lblMessage.Text = "Leave already Availed for this Period.."
                    Dim myscript As String = "window.alert('Leave already Availed for this Period!');"
                    ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
                    Call clearfields()
                    Exit Sub
                End If

                Dim ch1 As Boolean = checkdateinbetween(CDate(Session("leave_to")), CDate(rdr1.Item("from_date")), CDate(rdr1.Item("to_date")))
                If ch1 = True Then
                    'lblMessage.Text = "Leave already Availed for this Period.."
                    Dim myscript As String = "window.alert('Leave already Availed for this Period!');"
                    ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
                    Call clearfields()
                    Exit Sub
                End If

            End While
            rdr1.Close()
            rdr1 = Nothing
        End If

        Dim sqlst1 As String = "select lv_prdfm,lv_prdto from hr_payroll_system_files where pay_category='" & Session("pay_category1") & "'"
        rdr1 = SqlHelper.ExecuteReader(ConfigurationSettings.AppSettings("con"), CommandType.Text, sqlst1)
        If Not IsDBNull(rdr1) Then

            '''''''''''''''''''''''''''
            While rdr1.Read
                Dim ch As Boolean = checkdateinbetween(CDate(Session("leave_from")), CDate(rdr1.Item("lv_prdfm")), CDate(rdr1.Item("lv_prdto")))
                Dim ch1 As Boolean = checkdateinbetween(CDate(Session("leave_to")), CDate(rdr1.Item("lv_prdfm")), CDate(rdr1.Item("lv_prdto")))
                If ch = False And CDate(Session("leave_from")) < CDate(rdr1.Item("lv_prdfm")) Then
                    'lblMessage.Text = "Leave Requested is out of Leave Period.."
                    Dim myscript As String = "window.alert('Leave Requested is out of Leave Period!');"
                    ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
                    Call clearfields()
                    Exit Sub
                End If

                If ch1 = False And CDate(Session("leave_to")) < CDate(rdr1.Item("lv_prdto")) Then
                    'lblMessage.Text = "Leave Requested is out of Leave Period.."
                    Dim myscript As String = "window.alert('Leave Requested is out of Leave Period!');"
                    ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
                    Call clearfields()
                    Exit Sub
                End If

            End While
            rdr1.Close()
            rdr1 = Nothing
            '''''''''''''''''''''''''''''

        End If


        'get the number of days applied for leave
        txtdays.Text = DateDiff(DateInterval.Day, CDate(Session("leave_from")), CDate(Session("leave_to"))) + 1


        If ddlleave_code.SelectedItem.Value = "07" Then

            If txtdays.Text > 365 Or txtdays.Text > 366 Then
                Dim i As Integer
                ' i = MsgBox("STUDY LEAVE cannot be applied", 0, "Information")
                Dim myscript As String = "window.alert('Study leave cannnot be applied');"
                ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)

                cmdSave.Enabled = False
                Exit Sub
            Else
                cmdSave.Enabled = True
            End If
        End If

        If ddlleave_code.SelectedItem.Value = "11" Or ddlleave_code.SelectedItem.Value = "31" Then

            Dim con As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
            con.Open()

            'Dim cmd As New SqlCommand("SELECT mobile_no FROM emp_details where shop_code=@sc ", con)
            Dim empno As String = txtemployee_code.Text
            Dim cmd As New SqlCommand("SELECT * FROM employee_master where empno=@empno  ", con)
            cmd.Parameters.AddWithValue("@empno", empno)
            'cmd.Parameters.AddWithValue("@mpo", mpo)
            Dim reader As SqlDataReader = cmd.ExecuteReader()

            While reader.Read()

                'Dim no As String = reader("Mobile_no").ToString()
                Dim no As String = reader("payband").ToString()
                If no = "3" Or no = "4" Then
                    If ddlleave_code.SelectedItem.Value = "11" Then
                        If txtdays.Text > 120 Then
                            Dim i As Integer
                            ' i = MsgBox("LAP cannot exceed 120 days", 0, "Information")
                            Dim myscript As String = "window.alert('LAP cannot exceed 120 days');"
                            ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)

                            cmdSave.Enabled = False
                            Exit Sub
                        Else
                            cmdSave.Enabled = True

                        End If
                    End If
                    If ddlleave_code.SelectedItem.Value = "31" Then
                        If txtdays.Text > 240 Then
                            Dim i As Integer
                            '     i = MsgBox("LHAP cannot exceed 240 days", 0, "Information")

                            Dim myscript As String = "window.alert('LHAP cannot exceed 240 days');"
                            ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
                            cmdSave.Enabled = False
                            Exit Sub
                        Else
                            cmdSave.Enabled = True

                        End If
                    End If

                ElseIf no = "2" Then
                    Dim scode As String = reader("scalecode")
                    If scode = "5400" Then
                        If ddlleave_code.SelectedItem.Value = "11" Then
                            If txtdays.Text > 120 Then
                                Dim i As Integer
                                'i = MsgBox("LAP cannot exceed 120 days", 0, "Information")

                                Dim myscript As String = "window.alert('LAP cannot exceed 120 days');"
                                ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
                                cmdSave.Enabled = False
                                Exit Sub
                            Else
                                cmdSave.Enabled = True

                            End If
                        End If
                        If ddlleave_code.SelectedItem.Value = "31" Then
                            If txtdays.Text > 240 Then
                                Dim i As Integer
                                '    i = MsgBox("LHAP cannot exceed 240 days", 0, "Information")

                                Dim myscript As String = "window.alert('LHAP cannot exceed 240 days');"
                                ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
                                cmdSave.Enabled = False
                                Exit Sub
                            Else
                                cmdSave.Enabled = True

                            End If
                        End If
                    Else
                        If ddlleave_code.SelectedItem.Value = "11" Then
                            If txtdays.Text > 30 Then



                                Dim myscript As String = "window.alert('LAP can be availed for within last 30 days only!');"
                                ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
                                cmdSave.Enabled = False
                                Exit Sub

                                'If txtdays.Text > 60 Then
                                '    Dim i As Integer
                                '    '  i = MsgBox("LAP cannot exceed 60 days", 0, "Information")

                                '    Dim myscript1 As String = "window.alert('LAP cannot exceed 60 days');"
                                '    ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript1, True)
                                '    cmdSave.Enabled = False
                                '    Exit Sub
                                'Else
                                '    cmdSave.Enabled = True

                                'End If
                            End If
                        End If
                        If ddlleave_code.SelectedItem.Value = "31" Then
                            If txtdays.Text > 180 Then
                                Dim i As Integer
                                '   i = MsgBox("LHAP cannot exceed 180 days", 0, "Information")

                                Dim myscript As String = "window.alert('LHAP cannot exceed 180 days');"
                                ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
                                cmdSave.Enabled = False
                                Exit Sub
                            Else
                                cmdSave.Enabled = True

                            End If
                        End If

                    End If
                Else
                    If ddlleave_code.SelectedItem.Value = "11" Then
                        If txtdays.Text > 180 Then
                            Dim i As Integer
                            ' i = MsgBox("LAP cannot exceed 60 days", 0, "Information")

                            Dim myscript As String = "window.alert('LAP cannot exceed 180 days');"
                            ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
                            cmdSave.Enabled = False
                            Exit Sub
                        Else
                            cmdSave.Enabled = True

                        End If
                    End If
                    If ddlleave_code.SelectedItem.Value = "31" Then
                        If txtdays.Text > 180 Then
                            Dim i As Integer
                            '   i = MsgBox("LHAP cannot exceed 180 days", 0, "Information")

                            Dim myscript As String = "window.alert('LHAP cannot exceed 180 days');"
                            ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
                            cmdSave.Enabled = False
                            Exit Sub
                        Else
                            cmdSave.Enabled = True

                        End If
                    End If

                End If
            End While
        End If
        If ddlleave_code.SelectedItem.Value = "CCL" Then
            If txtdays.Text < 15 Then
                Dim i As Integer
                ' i = MsgBox("CCL cannot be applied", 0, "Information")

                Dim myscript As String = "window.alert('CCL cannot be applied');"
                ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
                cmdSave.Enabled = False
                Exit Sub
            Else
                cmdSave.Enabled = True
            End If
        End If



        If ddlleave_code.SelectedItem.Value = "PL" Then
            If txtdays.Text > 15 Then
                Dim i As Integer
                Dim myscript As String = "window.alert('Paternity leave cannot be applied for more than 15 days');"
                ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
                '   i = MsgBox("Paternity leave cannot be applied for more than 15 days", 0, "Information")
                cmdSave.Enabled = False
                Exit Sub
            Else
                cmdSave.Enabled = True
            End If
        End If




        If ddlleave_code.SelectedItem.Value = "08" Then
            If txtdays.Text > 90 Then
                Dim i As Integer
                Dim myscript As String = "window.alert('Maternity leave cannot be applied for more than 3 months');"
                ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)

                '   i = MsgBox("MATERNITY LEAVE cannot be applied for more than 3 months", 0, "Information")
                cmdSave.Enabled = False
                Exit Sub
            Else
                cmdSave.Enabled = True
            End If
        End If




        If ddlleave_code.SelectedItem.Value = "CR" Then
            If txtdays.Text > 1 Then
                Dim i As Integer
                Dim myscript As String = "window.alert('CR cannot be applied');"
                ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)

                'i = MsgBox("CR cannot be applied", 0, "Information")
                cmdSave.Enabled = False
                Exit Sub
            Else
                cmdSave.Enabled = True
            End If
        End If
        If ddlleave_code.SelectedItem.Value = "17" Then
            If txtdays.Text > 1 Then
                Dim i As Integer
                Dim myscript As String = "window.alert('RH cannot be applied');"
                ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)

                ' i = MsgBox("RH cannot be applied", 0, "Information")
                cmdSave.Enabled = False
                Exit Sub
            Else
                cmdSave.Enabled = True
            End If
        End If









        If ddlleave_code.SelectedItem.Value = "SCL" Then
            Session("sex") = SqlHelper.ExecuteScalar(con, CommandType.Text, "select sex from employee_master where empno='" & Trim(txtemployee_code.Text) & "'")
            Session("mstatus") = SqlHelper.ExecuteScalar(con, CommandType.Text, "select maritalstatus from employee_master where empno='" & Trim(txtemployee_code.Text) & "'")

            If (Session("sex").Equals("M")) Then
                If txtdays.Text > 6 Then
                    Dim i As Integer
                    '  i = MsgBox("Total days cannot exceed 6 days", 0, "Information")
                    Dim myscript As String = "window.alert('Total days cannot exceed 6 days');"
                    ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)

                End If
            End If
            If (Session("sex").Equals("F")) And (Session("mstatus").Equals("Married")) Then
                If txtdays.Text > 14 Then
                    Dim i As Integer
                    Dim myscript As String = "window.alert('Total days cannot exceed 14 days');"
                    ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)

                    '   i = MsgBox("Total days cannot exceed 14 days", 0, "Information")
                End If
            End If

        End If




        If ddlleave_code.SelectedItem.Value = "31" And ddlconvert.SelectedItem.Value = "Y" Then
            txtdays.Text = CDbl(txtdays.Text) * 2
        End If

        If ddlleave_code.SelectedItem.Value = "14" Then
            Dim startDate1 As String = txtleave_from.Text
            Dim startdate As DateTime = Convert.ToDateTime(startDate1)
            Dim toDate1 As String = txtleave_to.Text
            Dim toDate As DateTime = Convert.ToDateTime(toDate1)
            Dim count As Integer
            Dim j As Integer
            count = txtdays.Text
            While (startdate <= toDate)
                Dim day As String

                day = DateTime.Parse(startdate).DayOfWeek
                Dim conn As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
                conn.Open()
                Dim toffc As New SqlCommand("SELECT COUNT(*) FROM holiday_master1 where calender_date=@startdate", conn)
                toffc.Parameters.AddWithValue("@startDate", startdate)
                j = Convert.ToInt32(toffc.ExecuteScalar())
                'If j = 1 And day = "sunday" Then
                '    count = count - 1
                'End If
                If j = 1 Then
                    count = count - 1
                End If
                'If day = "sunday" Then
                '    count = count - 1
                'End If
                startdate = startdate.AddDays(1)
            End While
            If count > "3" Then
                Dim myscript As String = "window.alert('CL can be applied for within 3 days only!');"
                ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
                cmdSave.Enabled = False
                Exit Sub
            End If

            '  count = DateDiff(DateInterval.Day, CDate(Session("leave_from")), CDate(Session("leave_to"))) + 1

            Dim con As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
            con.Open()

            'Dim cmd As New SqlCommand("SELECT mobile_no FROM emp_details where shop_code=@sc ", con)
            Dim empno As String = txtemployee_code.Text
            Dim cmd As New SqlCommand("SELECT * FROM employee_master where empno=@empno  ", con)
            cmd.Parameters.AddWithValue("@empno", empno)
            'cmd.Parameters.AddWithValue("@mpo", mpo)
            Dim reader As SqlDataReader = cmd.ExecuteReader()

            While reader.Read()

                'Dim no As String = reader("Mobile_no").ToString()
                Dim no As String = reader("payband").ToString()
                If no = "3" Or no = "4" Then
                    While (startdate <= toDate)
                        Dim day As String

                        day = DateTime.Parse(startdate).DayOfWeek
                        Dim conn As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
                        conn.Open()
                        Dim toffc As New SqlCommand("SELECT COUNT(*) FROM holiday_master1 where calender_date=@startdate", conn)
                        toffc.Parameters.AddWithValue("@startDate", startdate)
                        j = Convert.ToInt32(toffc.ExecuteScalar())
                        If j = 1 And day = "0" Then
                            count = count - 1
                        End If
                        If j = 1 Then
                            count = count - 1
                        End If
                        If day = "0" Then
                            count = count - 1
                        End If
                        startdate = startdate.AddDays(1)
                    End While



                ElseIf no = "2" Then
                    Dim scode As String = reader("scalecode")
                    If scode = "5400" Then
                        While (startdate <= toDate)
                            Dim day As String

                            day = DateTime.Parse(startdate).DayOfWeek
                            Dim conn As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
                            conn.Open()
                            Dim toffc As New SqlCommand("SELECT COUNT(*) FROM holiday_master1 where calender_date=@startdate", conn)
                            toffc.Parameters.AddWithValue("@startDate", startdate)
                            j = Convert.ToInt32(toffc.ExecuteScalar())
                            If j = 1 And day = "sunday" Then
                                count = count - 1
                            End If
                            If j = 1 Then
                                count = count - 1
                            End If
                            If day = "sunday" Then
                                count = count - 1
                            End If
                            startdate = startdate.AddDays(1)
                        End While


                    Else
                        While (startdate <= toDate)
                            Dim day As String

                            day = DateTime.Parse(startdate).DayOfWeek
                            Dim conn As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
                            conn.Open()
                            Dim toffc As New SqlCommand("SELECT COUNT(*) FROM holiday_master1 where calender_date=@startdate", conn)
                            toffc.Parameters.AddWithValue("@startDate", startdate)
                            j = Convert.ToInt32(toffc.ExecuteScalar())
                            'If j = 1 And day = "sunday" Then
                            '    count = count - 1
                            'End If
                            If j = 1 Then
                                count = count - 1
                            End If
                            'If day = "sunday" Then
                            '    count = count - 1
                            'End If
                            startdate = startdate.AddDays(1)
                        End While


                    End If
                Else
                    While (startdate <= toDate)
                        Dim day As String

                        day = DateTime.Parse(startdate).DayOfWeek
                        Dim conn As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
                        conn.Open()
                        Dim toffc As New SqlCommand("SELECT COUNT(*) FROM holiday_master1 where calender_date=@startdate", conn)
                        toffc.Parameters.AddWithValue("@startDate", startdate)
                        j = Convert.ToInt32(toffc.ExecuteScalar())
                        'If j = 1 And day = "sunday" Then
                        '    count = count - 1
                        'End If
                        If j = 1 Then
                            count = count - 1
                        End If
                        'If day = "sunday" Then
                        '    count = count - 1
                        'End If
                        startdate = startdate.AddDays(1)
                    End While


                End If
            End While


            Session("total_days1") = count
            txtdays.Text = count
            'If ddlfirst_half_from.SelectedItem.Value = "F" And ddlfirst_half_to.SelectedItem.Value = "A" Then
            '    ' Session("total_days1") = Session("total_days1")
            '    txtdays.Text = txtdays.Text
            'End If
            'If ddlfirst_half_from.SelectedItem.Value = "F" And ddlfirst_half_to.SelectedItem.Value = "F" Then
            '    '   Session("total_days1") = Session("total_days1") - 0.5
            '    txtdays.Text = txtdays.Text - 0.5
            '    lblMessage.Text = txtdays.Text
            'End If
            'If ddlfirst_half_from.SelectedItem.Value = "A" And ddlfirst_half_to.SelectedItem.Value = "F" Then
            '    '  Session("total_days1") = Session("total_days1") - 1
            '    txtdays.Text = txtdays.Text - 1

            'End If
            'If ddlfirst_half_from.SelectedItem.Value = "A" And ddlfirst_half_to.SelectedItem.Value = "A" Then
            '    '  Session("total_days1") = Session("total_days1") - 0.5
            '    txtdays.Text = txtdays.Text - 0.5

            'End If
            '  Session("total_days1") = Session("total_days1")
            ' txtdays.Text = Session("total_days1")
        End If

        Dim con1 As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
        con1.Open()

        'Dim cmd As New SqlCommand("SELECT mobile_no FROM emp_details where shop_code=@sc ", con)
        Dim empno1 As String = txtemployee_code.Text
        Dim cmd1 As New SqlCommand("SELECT * FROM employee_master where empno=@empno  ", con1)
        cmd1.Parameters.AddWithValue("@empno", empno1)
        'cmd.Parameters.AddWithValue("@mpo", mpo)
        Dim reader1 As SqlDataReader = cmd1.ExecuteReader()

        While reader1.Read()

            'Dim no As String = reader("Mobile_no").ToString()
            Dim no As String = reader1("payband").ToString()
            If no = "3" Or no = "4" Then

            ElseIf no = "2" Then
                Dim scode As String = reader1("scalecode")
                If scode <> "5400" Then

                    If ddlleave_code.SelectedItem.Value = "14" Or ddlleave_code.SelectedItem.Value = "17" Then
                        Dim startDate1 As String = txtleave_from.Text
                        Dim startdate As DateTime = Convert.ToDateTime(startDate1)
                        Dim toDate1 As String = txtleave_to.Text
                        Dim toDate As DateTime = Convert.ToDateTime(toDate1)
                        Dim count1 As Integer
                        Dim j As Integer
                        Dim j1 As Integer
                        count1 = txtdays.Text
                        ' count1 = DateDiff(DateInterval.Day, CDate(Session("leave_from")), CDate(Session("leave_to"))) + 1

                        '  count = DateDiff(DateInterval.Day, CDate(Session("leave_from")), CDate(Session("leave_to"))) + 1
                        While (startdate <= toDate)
                            Dim day As String

                            day = DateTime.Parse(startdate).DayOfWeek
                            Dim conn As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
                            conn.Open()
                            If day = "1" Then

                                Dim toffc As New SqlCommand("SELECT COUNT(*) FROM shift_master where monshift=1 and empno='" & Trim(txtemployee_code.Text) & "'", conn)
                                j = Convert.ToInt32(toffc.ExecuteScalar())
                                If j > 0 Then
                                    count1 = count1 - j

                                    Dim conn1 As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
                                    conn1.Open()
                                    Dim toffc1 As New SqlCommand("SELECT COUNT(*) FROM holiday_master1 where calender_date=@startdate", conn1)
                                    toffc1.Parameters.AddWithValue("@startDate", startdate)
                                    j1 = Convert.ToInt32(toffc1.ExecuteScalar())
                                    If j1 = 1 Then
                                        count1 = count1 + 1
                                    End If
                                    conn1.Close()
                                End If
                            ElseIf day = "2" Then

                                Dim toffc As New SqlCommand("SELECT COUNT(*) FROM shift_master where tuesshift=@tuesshift and empno='" & Trim(txtemployee_code.Text) & "'", conn)
                                toffc.Parameters.AddWithValue("@tuesshift", "1")

                                j = Convert.ToInt32(toffc.ExecuteScalar())
                                If j > 0 Then
                                    count1 = count1 - j

                                    Dim conn1 As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
                                    conn1.Open()
                                    Dim toffc1 As New SqlCommand("SELECT COUNT(*) FROM holiday_master1 where calender_date=@startdate", conn1)
                                    toffc1.Parameters.AddWithValue("@startDate", startdate)
                                    j1 = Convert.ToInt32(toffc1.ExecuteScalar())
                                    If j1 = 1 Then
                                        count1 = count1 + 1
                                    End If
                                    conn1.Close()
                                End If
                            ElseIf day = "3" Then

                                Dim toffc As New SqlCommand("SELECT COUNT(*) FROM shift_master where wedshift=1 and empno='" & Trim(txtemployee_code.Text) & "'", conn)
                                j = Convert.ToInt32(toffc.ExecuteScalar())
                                If j > 0 Then
                                    count1 = count1 - j

                                    Dim conn1 As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
                                    conn1.Open()
                                    Dim toffc1 As New SqlCommand("SELECT COUNT(*) FROM holiday_master1 where calender_date=@startdate", conn1)
                                    toffc1.Parameters.AddWithValue("@startDate", startdate)
                                    j1 = Convert.ToInt32(toffc1.ExecuteScalar())
                                    If j1 = 1 Then
                                        count1 = count1 + 1
                                    End If
                                    conn1.Close()
                                End If
                            ElseIf day = "4" Then

                                Dim toffc As New SqlCommand("SELECT COUNT(*) FROM shift_master where thrushift=1 and empno='" & Trim(txtemployee_code.Text) & "'", conn)
                                j = Convert.ToInt32(toffc.ExecuteScalar())
                                If j > 0 Then
                                    count1 = count1 - j

                                    Dim conn1 As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
                                    conn1.Open()
                                    Dim toffc1 As New SqlCommand("SELECT COUNT(*) FROM holiday_master1 where calender_date=@startdate", conn1)
                                    toffc1.Parameters.AddWithValue("@startDate", startdate)
                                    j1 = Convert.ToInt32(toffc1.ExecuteScalar())
                                    If j1 = 1 Then
                                        count1 = count1 + 1
                                    End If
                                    conn1.Close()
                                End If
                            ElseIf day = "5" Then

                                Dim toffc As New SqlCommand("SELECT COUNT(*) FROM shift_master where frishift=1 and empno='" & Trim(txtemployee_code.Text) & "'", conn)
                                j = Convert.ToInt32(toffc.ExecuteScalar())
                                If j > 0 Then
                                    count1 = count1 - j

                                    Dim conn1 As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
                                    conn1.Open()
                                    Dim toffc1 As New SqlCommand("SELECT COUNT(*) FROM holiday_master1 where calender_date=@startdate", conn1)
                                    toffc1.Parameters.AddWithValue("@startDate", startdate)
                                    j1 = Convert.ToInt32(toffc1.ExecuteScalar())
                                    If j1 = 1 Then
                                        count1 = count1 + 1
                                    End If
                                    conn1.Close()
                                End If
                            ElseIf day = "6" Then

                                Dim toffc As New SqlCommand("SELECT COUNT(*) FROM shift_master where satshift=1 and empno='" & Trim(txtemployee_code.Text) & "'", conn)
                                j = Convert.ToInt32(toffc.ExecuteScalar())
                                If j > 0 Then
                                    count1 = count1 - j

                                    Dim conn1 As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
                                    conn1.Open()
                                    Dim toffc1 As New SqlCommand("SELECT COUNT(*) FROM holiday_master1 where calender_date=@startdate", conn1)
                                    toffc1.Parameters.AddWithValue("@startDate", startdate)
                                    j1 = Convert.ToInt32(toffc1.ExecuteScalar())
                                    If j1 = 1 Then
                                        count1 = count1 + 1
                                    End If
                                    conn1.Close()
                                End If
                            ElseIf day = "0" Then

                                Dim toffc As New SqlCommand("SELECT COUNT(*) FROM shift_master where sunshift=1 and empno='" & Trim(txtemployee_code.Text) & "'", conn)
                                j = Convert.ToInt32(toffc.ExecuteScalar())
                                If j > 0 Then
                                    count1 = count1 - j

                                    Dim conn1 As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
                                    conn1.Open()
                                    Dim toffc1 As New SqlCommand("SELECT COUNT(*) FROM holiday_master1 where calender_date=@startdate", conn1)
                                    toffc1.Parameters.AddWithValue("@startDate", startdate)
                                    j1 = Convert.ToInt32(toffc1.ExecuteScalar())
                                    If j1 = 1 Then
                                        count1 = count1 + 1
                                    End If
                                    conn1.Close()
                                End If
                            End If
                            startdate = startdate.AddDays(1)
                        End While
                        Session("total_days1") = count1
                        txtdays.Text = Session("total_days1")
                    End If
                End If
            Else
                If ddlleave_code.SelectedItem.Value = "14" Or ddlleave_code.SelectedItem.Value = "17" Then
                    Dim startDate1 As String = txtleave_from.Text
                    Dim startdate As DateTime = Convert.ToDateTime(startDate1)
                    Dim toDate1 As String = txtleave_to.Text
                    Dim toDate As DateTime = Convert.ToDateTime(toDate1)
                    Dim count1 As Integer
                    Dim j As Integer
                    Dim j1 As Integer
                    count1 = txtdays.Text
                    ' count1 = DateDiff(DateInterval.Day, CDate(Session("leave_from")), CDate(Session("leave_to"))) + 1

                    '  count = DateDiff(DateInterval.Day, CDate(Session("leave_from")), CDate(Session("leave_to"))) + 1
                    While (startdate <= toDate)
                        Dim day As String

                        day = DateTime.Parse(startdate).DayOfWeek
                        Dim conn As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
                        conn.Open()
                        If day = "1" Then

                            Dim toffc As New SqlCommand("SELECT COUNT(*) FROM shift_master where monshift=1 and empno='" & Trim(txtemployee_code.Text) & "'", conn)
                            j = Convert.ToInt32(toffc.ExecuteScalar())
                            If j > 0 Then
                                count1 = count1 - j

                                Dim conn1 As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123
")
                                conn1.Open()
                                Dim toffc1 As New SqlCommand("SELECT COUNT(*) FROM holiday_master1 where calender_date=@startdate", conn1)
                                toffc1.Parameters.AddWithValue("@startDate", startdate)
                                j1 = Convert.ToInt32(toffc1.ExecuteScalar())
                                If j1 = 1 Then
                                    count1 = count1 + 1
                                End If
                                conn1.Close()
                            End If
                        ElseIf day = "2" Then

                            Dim toffc As New SqlCommand("SELECT COUNT(*) FROM shift_master where tuesshift=@tuesshift and empno='" & Trim(txtemployee_code.Text) & "'", conn)
                            toffc.Parameters.AddWithValue("@tuesshift", "1")

                            j = Convert.ToInt32(toffc.ExecuteScalar())
                            If j > 0 Then
                                count1 = count1 - j

                                Dim conn1 As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
                                conn1.Open()
                                Dim toffc1 As New SqlCommand("SELECT COUNT(*) FROM holiday_master1 where calender_date=@startdate", conn1)
                                toffc1.Parameters.AddWithValue("@startDate", startdate)
                                j1 = Convert.ToInt32(toffc1.ExecuteScalar())
                                If j1 = 1 Then
                                    count1 = count1 + 1
                                End If
                                conn1.Close()
                            End If
                        ElseIf day = "3" Then

                            Dim toffc As New SqlCommand("SELECT COUNT(*) FROM shift_master where wedshift=1 and empno='" & Trim(txtemployee_code.Text) & "'", conn)
                            j = Convert.ToInt32(toffc.ExecuteScalar())
                            If j > 0 Then
                                count1 = count1 - j

                                Dim conn1 As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
                                conn1.Open()
                                Dim toffc1 As New SqlCommand("SELECT COUNT(*) FROM holiday_master1 where calender_date=@startdate", conn1)
                                toffc1.Parameters.AddWithValue("@startDate", startdate)
                                j1 = Convert.ToInt32(toffc1.ExecuteScalar())
                                If j1 = 1 Then
                                    count1 = count1 + 1
                                End If
                                conn1.Close()
                            End If
                        ElseIf day = "4" Then

                            Dim toffc As New SqlCommand("SELECT COUNT(*) FROM shift_master where thrushift=1 and empno='" & Trim(txtemployee_code.Text) & "'", conn)
                            j = Convert.ToInt32(toffc.ExecuteScalar())
                            If j > 0 Then
                                count1 = count1 - j

                                Dim conn1 As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
                                conn1.Open()
                                Dim toffc1 As New SqlCommand("SELECT COUNT(*) FROM holiday_master1 where calender_date=@startdate", conn1)
                                toffc1.Parameters.AddWithValue("@startDate", startdate)
                                j1 = Convert.ToInt32(toffc1.ExecuteScalar())
                                If j1 = 1 Then
                                    count1 = count1 + 1
                                End If
                                conn1.Close()
                            End If
                        ElseIf day = "5" Then

                            Dim toffc As New SqlCommand("SELECT COUNT(*) FROM shift_master where frishift=1 and empno='" & Trim(txtemployee_code.Text) & "'", conn)
                            j = Convert.ToInt32(toffc.ExecuteScalar())
                            If j > 0 Then
                                count1 = count1 - j

                                Dim conn1 As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
                                conn1.Open()
                                Dim toffc1 As New SqlCommand("SELECT COUNT(*) FROM holiday_master1 where calender_date=@startdate", conn1)
                                toffc1.Parameters.AddWithValue("@startDate", startdate)
                                j1 = Convert.ToInt32(toffc1.ExecuteScalar())
                                If j1 = 1 Then
                                    count1 = count1 + 1
                                End If
                                conn1.Close()
                            End If
                        ElseIf day = "6" Then

                            Dim toffc As New SqlCommand("SELECT COUNT(*) FROM shift_master where satshift=1 and empno='" & Trim(txtemployee_code.Text) & "'", conn)
                            j = Convert.ToInt32(toffc.ExecuteScalar())
                            If j > 0 Then
                                count1 = count1 - j

                                Dim conn1 As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
                                conn1.Open()
                                Dim toffc1 As New SqlCommand("SELECT COUNT(*) FROM holiday_master1 where calender_date=@startdate", conn1)
                                toffc1.Parameters.AddWithValue("@startDate", startdate)
                                j1 = Convert.ToInt32(toffc1.ExecuteScalar())
                                If j1 = 1 Then
                                    count1 = count1 + 1
                                End If
                                conn1.Close()
                            End If
                        ElseIf day = "0" Then

                            Dim toffc As New SqlCommand("SELECT COUNT(*) FROM shift_master where sunshift=1 and empno='" & Trim(txtemployee_code.Text) & "'", conn)
                            j = Convert.ToInt32(toffc.ExecuteScalar())
                            If j > 0 Then
                                count1 = count1 - j

                                Dim conn1 As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
                                conn1.Open()
                                Dim toffc1 As New SqlCommand("SELECT COUNT(*) FROM holiday_master1 where calender_date=@startdate", conn1)
                                toffc1.Parameters.AddWithValue("@startDate", startdate)
                                j1 = Convert.ToInt32(toffc1.ExecuteScalar())
                                If j1 = 1 Then
                                    count1 = count1 + 1
                                End If
                                conn1.Close()
                            End If
                        End If
                        startdate = startdate.AddDays(1)
                    End While
                    Session("total_days1") = count1
                    txtdays.Text = Session("total_days1")
                End If
            End If
        End While

        'If (ddlleave_code.SelectedItem.Value = "14" Or ddlleave_code.SelectedItem.Value = "01" Or ddlleave_code.SelectedItem.Value = "06") Then
        '    If (((ddlfirst_half_from.SelectedItem.Value = "F") Or (ddlfirst_half_from.SelectedItem.Value = "A")) And (CDate(Session("leave_from")) = CDate(Session("leave_to")))) Then
        '        txtdays.Text = "0.5"
        '    ElseIf (((ddlfirst_half_from.SelectedItem.Value = "A") And (ddlfirst_half_to.SelectedItem.Value = "F")) And (CDate(Session("leave_from")) <> CDate(Session("leave_to")))) Then
        '        Session("total_days1") = Session("total_days1") - 1
        '        txtdays.Text = Session("total_days1")
        '    ElseIf (((ddlfirst_half_from.SelectedItem.Value = "F") And (ddlfirst_half_to.SelectedItem.Value = "A")) And (CDate(Session("leave_from")) <> CDate(Session("leave_to")))) Then
        '        Session("total_days1") = DateDiff(DateInterval.Day, CDate(Session("leave_from")), CDate(Session("leave_to"))) + 1
        '        'Session("total_days1") = Session("total_days1")
        '        txtdays.Text = Session("total_days1")
        '    ElseIf (((ddlfirst_half_from.SelectedItem.Value = "F") And (ddlfirst_half_to.SelectedItem.Value = "F")) And (CDate(Session("leave_from")) <> CDate(Session("leave_to")))) Then
        '        Session("total_days1") = Session("total_days1") - 0.5
        '        txtdays.Text = Session("total_days1")
        '    ElseIf (((ddlfirst_half_from.SelectedItem.Value = "A") And (ddlfirst_half_to.SelectedItem.Value = "A")) And (CDate(Session("leave_from")) <> CDate(Session("leave_to")))) Then
        '        Session("total_days1") = Session("total_days1") - 0.5
        '        txtdays.Text = Session("total_days1")
        '    ElseIf (((ddlfirst_half_from.SelectedItem.Value = "A") And (ddlfirst_half_to.SelectedItem.Value = "")) And (CDate(Session("leave_from")) <> CDate(Session("leave_to")))) Then
        '        Session("total_days1") = Session("total_days1") - 0.5
        '        txtdays.Text = Session("total_days1")
        '    End If


        'End If


    End Sub










    Sub clearfields()
        Session("leave_from") = ""
        txtleave_to.Text = ""
        txtleave_from.Text = ""
        ddlconvert.SelectedIndex = -1
        ddlleave_code.SelectedIndex = -1
        txtdays.Text = ""
    End Sub

    Function checkdateinbetween(ByVal d As Date, ByVal d1 As Date, ByVal d2 As Date)
        If d >= d1 And d <= d2 Then
            Return True
            Exit Function
        End If
    End Function

    Sub clearall()
        txtaddress.Text = ""
        txtapplication_number.Text = ""
        txtdays.Text = ""
        txtemployee_code.Text = ""
        txtleave_from.Text = ""
        txtleave_to.Text = ""
        txtreason.Text = ""
        ddlconvert.SelectedIndex = -1
        ddlfirst_half_from.SelectedIndex = -1
        ddlfirst_half_to.SelectedIndex = -1
        ddlleave_code.SelectedIndex = -1
        ddloutstation_or_hq.SelectedIndex = -1
    End Sub

    Private Sub BindGrid1()
        Dim sqlstring2 As String = "select distinct b.description,convert(varchar,a.from_date,103) [from_date],convert(varchar,a.to_date,103) [to_date],a.number_of_days, a.l_confirm from hr_leave_application_details a, hr_leave_master b where a.leavecode=b.leave_code and a.empno='" & Trim(txtemployee_code.Text) & "'"
        Dim myCommand As New SqlDataAdapter(sqlstring2, con)
        Dim ds As New DataSet()
        myCommand.Fill(ds)
        DataGrid1.DataSource = ds
        DataGrid1.DataBind()
    End Sub

    Private Sub BindGrid2()
        Dim sqlstring2 As String
        'sqlstring2= "select leave_code, total_leave_availed, total_leave_accumulated + total_leave_eligibility - total_leave_availed AS balance from hr_leave_header where employee_code='" & Trim(txtemployee_code.Text) & "'"
        sqlstring2 = "  select distinct b.description as leavecode, leaveavailed, leaveob + leavecredited - leaveavailed AS balance "
        sqlstring2 &= " from leave_header a, hr_leave_master b"
        sqlstring2 &= " where empno='" & Trim(txtemployee_code.Text) & "'"
        sqlstring2 &= " and a.leavecode=b.leave_code and b.leave_code <> '00'"

        Dim myCommand As New SqlDataAdapter(sqlstring2, con)
        Dim ds As New DataSet()
        myCommand.Fill(ds)

        Datagrid2.DataSource = ds
        Datagrid2.DataBind()

    End Sub

    Private Sub txtleave_from_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtleave_from.TextChanged
        lblMessage.Text = ""

        calculateDays()
        'to check if from date is greater than to date
        If (txtleave_to.Text <> "") Then
            If CDate(Session("leave_from")) > CDate(Session("leave_to")) Then
                ' lblMessage.Text = "From Leave Date Cant be More than To leave Date...."
                Dim myscript As String = "window.alert('From Leave Date Cant be More than To leave Date!');"
                ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
                Session("leave_from") = ""
                txtleave_to.Text = ""
                txtleave_from.Text = ""
                ddlconvert.SelectedIndex = -1
                ddlleave_code.SelectedIndex = -1
                txtdays.Text = ""
                ' Call clearfields()
                cmdSave.Enabled = False
                Exit Sub
            Else
                cmdSave.Enabled = True
            End If

        End If

        ' check if the leave code field is empty
        If ddlleave_code.SelectedItem.Value = "" Then
            '   lblMessage.Text = "Leave Code Empty!"
            Dim myscript As String = "window.alert('Leave Code Empty!');"
            ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
            Exit Sub
        End If

        ' check if the previous day is applied CL
        If ddlleave_code.SelectedItem.Value = "11" Then
            Dim clcombination As Boolean = checkforCL()
            If clcombination = True Then
                ' lblMessage.Text = "CL combination with LAP is not allowed"
                Dim myscript As String = "window.alert('CL combination with LAP is not allowed!');"
                ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
                Call clearfields()
                Exit Sub
            End If
            '' check if the previous day is LAP
            ''ElseIf ddlleave_code.SelectedItem.Value = "14" Then
            ''    Dim lapcombination As Boolean = checkforLAP()
            ''    If lapcombination = True Then
            ''        lblMessage.Text = "LAP combination with CL is not allowed"
            ''        Call clearfields()
            ''        Exit Sub
            ''    End If
        End If


        'If (ddlleave_code.SelectedItem.Value = "14") Then
        '    If txtleave_to.Text <> "" Then

        '        Session("total_days1") = DateDiff(DateInterval.Day, CDate(Session("leave_from")), CDate(Session("leave_to"))) + 1
        '        If (CDate(Session("leave_from")) = CDate(Session("leave_to")) And ddlfirst_half_from.SelectedItem.Value = "" And ddlfirst_half_to.SelectedItem.Value = "") Then
        '            txtdays.Text = "1"

        '        ElseIf (CDate(Session("leave_from")) = CDate(Session("leave_to")) And ddlfirst_half_from.SelectedItem.Value = "A" And (ddlfirst_half_to.SelectedItem.Value = "" Or ddlfirst_half_to.SelectedItem.Value = "A" Or ddlfirst_half_to.SelectedItem.Value = "F")) Then
        '            txtdays.Text = "0.5"

        '        ElseIf (CDate(Session("leave_from")) = CDate(Session("leave_to")) And ddlfirst_half_from.SelectedItem.Value = "F" And (ddlfirst_half_to.SelectedItem.Value = "" Or ddlfirst_half_to.SelectedItem.Value = "A" Or ddlfirst_half_to.SelectedItem.Value = "F")) Then
        '            txtdays.Text = "1"

        '        ElseIf (((ddlfirst_half_from.SelectedItem.Value = "A") And (ddlfirst_half_to.SelectedItem.Value = "F")) And (CDate(Session("leave_from")) <> CDate(Session("leave_to")))) Then
        '            Session("total_days1") = Session("total_days1") - 1
        '            txtdays.Text = Session("total_days1")

        '        ElseIf (((ddlfirst_half_from.SelectedItem.Value = "F") And (ddlfirst_half_to.SelectedItem.Value = "A")) And (CDate(Session("leave_from")) <> CDate(Session("leave_to")))) Then
        '            Session("total_days1") = Session("total_days1")
        '            txtdays.Text = Session("total_days1")

        '        ElseIf (((ddlfirst_half_from.SelectedItem.Value = "F") And (ddlfirst_half_to.SelectedItem.Value = "F")) And (CDate(Session("leave_from")) <> CDate(Session("leave_to")))) Then
        '            Session("total_days1") = Session("total_days1") - 0.5
        '            txtdays.Text = Session("total_days1")

        '        ElseIf (((ddlfirst_half_from.SelectedItem.Value = "A") And (ddlfirst_half_to.SelectedItem.Value = "A")) And (CDate(Session("leave_from")) <> CDate(Session("leave_to")))) Then
        '            Session("total_days1") = Session("total_days1") - 0.5
        '            txtdays.Text = Session("total_days1")

        '        ElseIf (((ddlfirst_half_from.SelectedItem.Value = "") And (ddlfirst_half_to.SelectedItem.Value = "")) And (CDate(Session("leave_from")) <> CDate(Session("leave_to")))) Then
        '            txtdays.Text = DateDiff(DateInterval.Day, CDate(Session("leave_from")), CDate(Session("leave_to"))) + 1
        '            'txtdays.Text = Session("total_days1")
        '        End If
        '    End If

        'End If

    End Sub

    'Private Sub ddlfirst_half_to_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlfirst_half_to.SelectedIndexChanged

    '    Session("total_days1") = DateDiff(DateInterval.Day, CDate(Session("leave_from")), CDate(Session("leave_to"))) + 1
    '    If (ddlleave_code.SelectedItem.Value = "14" Or (ddlleave_code.SelectedItem.Value = "01" And Session("pay_category1") = "5")) Then
    '        If (((ddlfirst_half_from.SelectedItem.Value = "F") Or (ddlfirst_half_from.SelectedItem.Value = "A")) And (CDate(Session("leave_from")) = CDate(Session("leave_to")))) Then
    '            txtdays.Text = "0.5"
    '        ElseIf (((ddlfirst_half_from.SelectedItem.Value = "A") And (ddlfirst_half_to.SelectedItem.Value = "F")) And (CDate(Session("leave_from")) <> CDate(Session("leave_to")))) Then
    '            Session("total_days1") = Session("total_days1") - 1
    '            txtdays.Text = Session("total_days1")
    '        ElseIf (((ddlfirst_half_from.SelectedItem.Value = "F") And (ddlfirst_half_to.SelectedItem.Value = "A")) And (CDate(Session("leave_from")) <> CDate(Session("leave_to")))) Then
    '            Session("total_days1") = Session("total_days1")
    '            txtdays.Text = Session("total_days1")
    '        ElseIf (((ddlfirst_half_from.SelectedItem.Value = "F") And (ddlfirst_half_to.SelectedItem.Value = "F")) And (CDate(Session("leave_from")) <> CDate(Session("leave_to")))) Then
    '            Session("total_days1") = Session("total_days1") - 0.5
    '            txtdays.Text = Session("total_days1")
    '        ElseIf (((ddlfirst_half_from.SelectedItem.Value = "A") And (ddlfirst_half_to.SelectedItem.Value = "A")) And (CDate(Session("leave_from")) <> CDate(Session("leave_to")))) Then
    '            Session("total_days1") = Session("total_days1") - 0.5
    '            txtdays.Text = Session("total_days1")
    '        ElseIf (((ddlfirst_half_from.SelectedItem.Value = "F") And (ddlfirst_half_to.SelectedItem.Value = "")) And (CDate(Session("leave_from")) <> CDate(Session("leave_to")))) Then
    '            Session("total_days1") = DateDiff(DateInterval.Day, CDate(Session("leave_from")), CDate(Session("leave_to"))) + 1
    '            txtdays.Text = Session("total_days1")
    '        ElseIf (((ddlfirst_half_from.SelectedItem.Value = "F") And (ddlfirst_half_to.SelectedItem.Value = "")) And (CDate(Session("leave_from")) <> CDate(Session("leave_to")))) Then
    '            Session("total_days1") = DateDiff(DateInterval.Day, CDate(Session("leave_from")), CDate(Session("leave_to"))) + 1
    '            Session("total_days1") = Session("total_days1") - 0.5
    '            txtdays.Text = Session("total_days1")
    '        ElseIf (((ddlfirst_half_from.SelectedItem.Value = "") And (ddlfirst_half_to.SelectedItem.Value = "F")) And (CDate(Session("leave_from")) <> CDate(Session("leave_to")))) Then
    '            Session("total_days1") = DateDiff(DateInterval.Day, CDate(Session("leave_from")), CDate(Session("leave_to"))) + 1
    '            Session("total_days1") = Session("total_days1") - 0.5
    '            txtdays.Text = Session("total_days1")
    '        ElseIf (((ddlfirst_half_from.SelectedItem.Value = "") And (ddlfirst_half_to.SelectedItem.Value = "A")) And (CDate(Session("leave_from")) <> CDate(Session("leave_to")))) Then
    '            Session("total_days1") = DateDiff(DateInterval.Day, CDate(Session("leave_from")), CDate(Session("leave_to"))) + 1
    '            Session("total_days1") = Session("total_days1")
    '            txtdays.Text = Session("total_days1")
    '        End If

    '    End If





    'End Sub
    'Private Sub ddlfirst_half_from_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlfirst_half_from.SelectedIndexChanged

    '    If (txtleave_to.Text <> "") Then
    '        Session("total_days1") = DateDiff(DateInterval.Day, CDate(Session("leave_from")), CDate(Session("leave_to"))) + 1

    '        If (ddlleave_code.SelectedItem.Value = "14" Or (ddlleave_code.SelectedItem.Value = "01" And Session("pay_category1") = "5")) Then
    '            If (((ddlfirst_half_from.SelectedItem.Value = "F") Or (ddlfirst_half_from.SelectedItem.Value = "A")) And (CDate(Session("leave_from")) = CDate(Session("leave_to")))) Then
    '                txtdays.Text = "0.5"
    '            ElseIf (((ddlfirst_half_from.SelectedItem.Value = "A") And (ddlfirst_half_to.SelectedItem.Value = "F")) And (CDate(Session("leave_from")) <> CDate(Session("leave_to")))) Then
    '                Session("total_days1") = DateDiff(DateInterval.Day, CDate(Session("leave_from")), CDate(Session("leave_to"))) + 1
    '                Session("total_days1") = Session("total_days1") - 1
    '                txtdays.Text = Session("total_days1")
    '            ElseIf (((ddlfirst_half_from.SelectedItem.Value = "F") And (ddlfirst_half_to.SelectedItem.Value = "A")) And (CDate(Session("leave_from")) <> CDate(Session("leave_to")))) Then
    '                Session("total_days1") = Session("total_days1")
    '                txtdays.Text = Session("total_days1")
    '            ElseIf (((ddlfirst_half_from.SelectedItem.Value = "F") And (ddlfirst_half_to.SelectedItem.Value = "F")) And (CDate(Session("leave_from")) <> CDate(Session("leave_to")))) Then
    '                Session("total_days1") = DateDiff(DateInterval.Day, CDate(Session("leave_from")), CDate(Session("leave_to"))) + 1
    '                Session("total_days1") = Session("total_days1") - 0.5
    '                txtdays.Text = Session("total_days1")
    '            ElseIf (((ddlfirst_half_from.SelectedItem.Value = "A") And (ddlfirst_half_to.SelectedItem.Value = "A")) And (CDate(Session("leave_from")) <> CDate(Session("leave_to")))) Then
    '                Session("total_days1") = DateDiff(DateInterval.Day, CDate(Session("leave_from")), CDate(Session("leave_to"))) + 1
    '                Session("total_days1") = Session("total_days1") - 0.5
    '                txtdays.Text = Session("total_days1")
    '            ElseIf (((ddlfirst_half_from.SelectedItem.Value = "A") And (ddlfirst_half_to.SelectedItem.Value = "")) And (CDate(Session("leave_from")) <> CDate(Session("leave_to")))) Then
    '                Session("total_days1") = DateDiff(DateInterval.Day, CDate(Session("leave_from")), CDate(Session("leave_to"))) + 1
    '                Session("total_days1") = Session("total_days1") - 0.5
    '                txtdays.Text = Session("total_days1")
    '            ElseIf (((ddlfirst_half_from.SelectedItem.Value = "") And (ddlfirst_half_to.SelectedItem.Value = "")) And (CDate(Session("leave_from")) <> CDate(Session("leave_to")))) Then
    '                Session("total_days1") = DateDiff(DateInterval.Day, CDate(Session("leave_from")), CDate(Session("leave_to"))) + 1
    '                txtdays.Text = Session("total_days1")
    '            ElseIf (((ddlfirst_half_from.SelectedItem.Value = "F") And (ddlfirst_half_to.SelectedItem.Value = "")) And (CDate(Session("leave_from")) <> CDate(Session("leave_to")))) Then
    '                Session("total_days1") = DateDiff(DateInterval.Day, CDate(Session("leave_from")), CDate(Session("leave_to"))) + 1
    '                txtdays.Text = Session("total_days1")
    '            End If
    '        End If
    '    End If
    'End Sub
    Private Sub DataGrid1_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid1.PageIndexChanged
        DataGrid1.CurrentPageIndex = e.NewPageIndex
        BindGrid1()
    End Sub
    Private Sub ddlconvert_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlconvert.SelectedIndexChanged
        calculateDays()
    End Sub

    Private Sub Datagrid2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Datagrid2.SelectedIndexChanged

    End Sub


    Private Sub txtemployee_code_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtemployee_code.TextChanged
        getEmployeeDetails()
        cmdSave.Enabled = True

    End Sub

    Protected Sub img2_Click(sender As Object, e As ImageClickEventArgs) Handles img2.Click

        cal1.Visible = False
        cal2.Visible = True
    End Sub

    Protected Sub img1_Click(sender As Object, e As ImageClickEventArgs) Handles img1.Click
        cal1.Visible = True

    End Sub
    Protected Sub cal1_SelectionChanged(sender As Object, e As EventArgs) Handles cal1.SelectionChanged

        txtleave_from.Text = CDate(cal1.SelectedDate.ToString())

        cal1.Visible = False
        calculateDays()
        ' Dim myDate As DateTime = CDate(txtleave_from.Text)
        Dim startDate2 As String = txtleave_from.Text
        Dim mydate As DateTime = Convert.ToDateTime(startDate2)
        Dim regDate As Date = Date.Today
        Dim holdate As DateTime
        If (mydate < regDate) Then
            If ddlleave_code.SelectedValue = "31" Or ddlleave_code.SelectedValue = "17" Or ddlleave_code.SelectedValue = "CCL" Or ddlleave_code.SelectedValue = "04" Or ddlleave_code.SelectedValue = "07" Or ddlleave_code.SelectedValue = "08" Or ddlleave_code.SelectedValue = "CR" Or ddlleave_code.SelectedValue = "PL" Or ddlleave_code.SelectedValue = "SCL" Then
                Dim i As Integer
                Dim myscript As String = "window.alert('Date cannot be less than today date');"
                ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)

                '  i = MsgBox("Date cannot be less than today's date", 0, "Information")
                cmdSave.Enabled = False

                Exit Sub
            End If
        Else
            cmdSave.Enabled = True

        End If
        If ddlleave_code.SelectedItem.Value = "17" Then
            Dim startDate1 As String = txtleave_from.Text
            Dim startdate As DateTime = Convert.ToDateTime(startDate1)
            Dim conn2 As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
            conn2.Open()
            Dim j2 As Integer
            Dim toffc2 As New SqlCommand("SELECT COUNT(*) FROM holiday_master1 where calender_date=@startdate", conn2)
            toffc2.Parameters.AddWithValue("@startDate", startdate)
            j2 = Convert.ToInt32(toffc2.ExecuteScalar())

            If j2 > 0 Then
                Dim conn1 As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
                conn1.Open()
                Dim j1 As Integer
                Dim toffc1 As New SqlCommand("SELECT count(*) FROM holiday_master1 where calender_date=@startdate and type='R'", conn1)
                toffc1.Parameters.AddWithValue("@startDate", startdate)
                j1 = Convert.ToInt32(toffc1.ExecuteScalar())

                If j1 = 0 Then
                    Dim i As Integer
                    Dim myscript As String = "window.alert('Selected date is not a restricted holiday');"
                    ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)

                    '  i = MsgBox("Selected date is not a restricted holiday", 0, "Information")
                    cmdSave.Enabled = False
                    txtapplication_number.Text = getApplicationNumber()
                    Exit Sub
                Else
                    cmdSave.Enabled = True

                End If
            Else
                Dim i As Integer
                'i = MsgBox("Selected date is not a restricted holiday", 0, "Information")
                Dim myscript As String = "window.alert('Selected date is not a restricted holiday');"
                ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)

                Call clearall()
                Exit Sub
            End If
        End If

        If ddlleave_code.SelectedItem.Value = "CR" Then
            If ddlholiday.SelectedItem.Text = "" Then
                ' lblMessage.Text = " All fields not filled up"
                Dim myscript As String = "window.alert('All fields not filled up');"
                ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
                lblholiday.Text = "*"

                cmdSave.Enabled = False
                Exit Sub
            Else
                cmdSave.Enabled = True
            End If

            holdate = ddlholiday.SelectedItem.Value
            Dim count As Integer

            count = DateDiff(DateInterval.Day, CDate(holdate), mydate) + 1
            If count > 15 Then
                Dim i As Integer
                '    i = MsgBox("CR cannot be applied as date interval exceed 15", 0, "Information")
                Dim myscript As String = "window.alert('CR cannot be applied as date interval exceed 15');"
                ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)

                cmdSave.Enabled = False
                Exit Sub
            Else
                cmdSave.Enabled = True

            End If
        End If
        lblMessage.Text = ""


        'to check if from date is greater than to date
        If (txtleave_to.Text <> "") Then
            If CDate(Session("leave_from")) > CDate(Session("leave_to")) Then
                'lblMessage.Text = "From Leave Date Cant be More than To leave Date...."
                Dim myscript As String = "window.alert('From Leave Date cannot be more than to leave date');"
                ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
                Call clearfields()
                Exit Sub
            End If

        End If

        ' check if the leave code field is empty
        If ddlleave_code.SelectedItem.Value = "" Then
            ' lblMessage.Text = "Leave Code Empty!"
            Dim myscript As String = "window.alert('Leave code empty');"
            ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
            Exit Sub
        End If

        ' check if the previous day is applied CL
        If ddlleave_code.SelectedItem.Value = "11" Then
            Dim clcombination As Boolean = checkforCL()
            If clcombination = True Then
                'lblMessage.Text = "CL combination with LAP is not allowed"
                Dim myscript As String = "window.alert('CL combination with LAP is not allowed');"
                ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
                Call clearfields()
                Exit Sub
            End If
        End If
    End Sub
    Protected Sub cal2_SelectionChanged(sender As Object, e As EventArgs) Handles cal2.SelectionChanged
        txtleave_to.Text = CDate(cal2.SelectedDate.ToString())
        cal2.Visible = False
    End Sub

    Protected Sub Cal2_SelectionChanged1(sender As Object, e As EventArgs) Handles cal2.SelectionChanged
        calculateDays()
    End Sub

    Protected Sub ddlfirst_half_to_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlfirst_half_to.SelectedIndexChanged
        If ddlfirst_half_from.SelectedItem.Value = "F" And ddlfirst_half_to.SelectedItem.Value = "A" Then
            ' Session("total_days1") = Session("total_days1")
            txtdays.Text = Session("total_days1")
        End If
        If ddlfirst_half_from.SelectedItem.Value = "F" And ddlfirst_half_to.SelectedItem.Value = "F" Then
            '   Session("total_days1") = Session("total_days1") - 0.5
            txtdays.Text = Session("total_days1") - 0.5

        End If
        If ddlfirst_half_from.SelectedItem.Value = "A" And ddlfirst_half_to.SelectedItem.Value = "F" Then
            '  Session("total_days1") = Session("total_days1") - 1
            txtdays.Text = Session("total_days1") - 1

        End If
        If ddlfirst_half_from.SelectedItem.Value = "A" And ddlfirst_half_to.SelectedItem.Value = "A" Then
            '  Session("total_days1") = Session("total_days1") - 0.5
            txtdays.Text = Session("total_days1") - 0.5

        End If
    End Sub

    Protected Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Call clearall()
    End Sub

    'Protected Sub ddloutstation_or_hq_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddloutstation_or_hq.SelectedIndexChanged
    '    If ddloutstation_or_hq.SelectedItem.Value = "H" Then
    '        ddlout.Visible = False
    '        Dim con1 As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
    '        con1.Open()

    '        Dim empno2 As String = txtemployee_code.Text
    '        Dim cmd2 As New SqlCommand("SELECT * FROM employee_master where empno=@empno", con1)
    '        cmd2.Parameters.AddWithValue("@empno", empno2)
    '        Dim reader2 As SqlDataReader = cmd2.ExecuteReader()
    '        Dim rep As String
    '        While reader2.Read()
    '            txtaddress.Text = reader2("PERMADDRESS1")
    '        End While
    '    End If

    '    If ddloutstation_or_hq.SelectedItem.Value = "O" Then
    '        txtaddress.ReadOnly = True
    '        ddlout.Visible = True
    '    End If


    'End Sub

    Protected Sub Btndoc_Click(sender As Object, e As EventArgs) Handles btndoc.Click

        Dim postedFile As HttpPostedFile = FileUpload1.PostedFile
        Dim filename As String = Path.GetFileName(postedFile.FileName)
        Dim fileExtension As String = Path.GetExtension(filename)
        If fileExtension.ToLower() = ".jpg" Or fileExtension.ToLower() = ".gif" Or fileExtension.ToLower() = ".png" Or fileExtension.ToLower() = ".bmp" Or fileExtension.ToLower() = ".txt" Or fileExtension.ToLower() = ".docx" Then

            Dim Stream As Stream = postedFile.InputStream
            Dim BinaryReader As BinaryReader = New BinaryReader(Stream)
            ' Dim bytes As Byte() = BinaryReader.ReadBytes((Int())Stream.Length)

            Dim bytes() As Byte = BinaryReader.ReadBytes(Stream.Length)

            'txtemployee_code.Text = "4"
            'Dim connc As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
            'conc.Open()
            Dim query As String = String.Empty
            query &= "INSERT INTO doc_upload1 (empno, appno,filename, bytes) "
            query &= "VALUES (@empno,@appno,@filename, @bytes)"
            Using conn As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
                Using comm As New SqlCommand()
                    With comm
                        .Connection = conn
                        .CommandType = CommandType.Text
                        .CommandText = query
                        .Parameters.AddWithValue("@empno", txtemployee_code.Text)
                        .Parameters.AddWithValue("@appno", txtapplication_number.Text)
                        .Parameters.AddWithValue("@filename", filename)
                        .Parameters.AddWithValue("@bytes", bytes)

                    End With
                    Try
                        conn.Open()
                        comm.ExecuteNonQuery()
                        Dim myscript As String = "window.alert('Successfully uploaded!');"
                        ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
                        'lblMessage.Visible = True
                        'lblMessage.Text = "Successfully uploaded"
                    Catch ee As Exception
                        Response.Write(ee.Message)
                    End Try
                End Using
            End Using
        Else
            lblMessage.Visible = True
            lblMessage.ForeColor = System.Drawing.Color.Red
            lblMessage.Text = "Only images (.jpg, .png, .gif and .bmp) can be uploaded"
        End If
    End Sub

    'Protected Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
    '    Response.Redirect("wapframeset.aspx")
    'End Sub
End Class




