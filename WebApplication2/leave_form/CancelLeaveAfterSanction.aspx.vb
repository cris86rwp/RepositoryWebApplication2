Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports System.Data
Imports Scripting

Public Class CancelLeaveAfterSanction
    Inherits System.Web.UI.Page
    Protected WithEvents txtAppl As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEmployee_Code As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLeave_from As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLeave_to As System.Web.UI.WebControls.TextBox
    Protected WithEvents cmdSave As System.Web.UI.WebControls.Button
    Protected WithEvents cmdCancel As System.Web.UI.WebControls.Button
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblName As System.Web.UI.WebControls.Label
    Protected WithEvents lblDesignation As System.Web.UI.WebControls.Label
    Protected WithEvents lblMode As System.Web.UI.WebControls.Label
    Dim con As New SqlConnection(ConfigurationManager.AppSettings("con"))
    Dim sqlPara(4) As SqlParameter
    Dim group_code As String
    Dim strsql As String
    Protected WithEvents txtdays As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLeaveCode As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtleaveDescription As System.Web.UI.WebControls.TextBox
    Dim rdr As SqlDataReader
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Ddldate As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Shared themeValue As String

    Public Sub New()

        AddHandler PreInit, New EventHandler(AddressOf Page_PreInit)
    End Sub

    Private Sub Page_PreInit(ByVal sender As Object, ByVal e As EventArgs)

        Page.Theme = themeValue
    End Sub


    Protected Sub Dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Dd1.SelectedIndexChanged
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
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not IsPostBack Then
            If Session("Ecode") Is Nothing Then
                '  Response.Redirect("InvalidSession.aspx")
            End If
            BindGrid1()
            Dim tmp As String
            ' lblMode.Text = "Cancel"
            lblMode.Text = ""
            strsql = "Select distinct application_number from hr_leave_application_details where application_type='D' and office_order_number is not null and len(isnull(office_order_number,''))>0 order by application_number desc"
            tmp = "application_number"
            cmdSave.Text = "Cancel Leave"
            txtLeaveCode.ReadOnly = True
            txtdays.ReadOnly = True
            '  txtEmployee_Code.Text = Session("ecode")
            ' employeedetails()
        End If

    End Sub

    'Private Sub txtAppl_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAppl.TextChanged
    '    If validateAppl() = False Then
    '        If lblMode.Text = "cancel" Then
    '            lblMessage.Text = "Memorandum No. not yet generated/invalid No."
    '        End If
    '        Exit Sub
    '    End If
    '    txtdays.Text = ""
    '    Dim query As String
    '    Dim cn As SqlConnection
    '    Dim cm As New SqlCommand()
    '    Try
    '        cn = New SqlConnection(ConfigurationManager.AppSettings("con"))
    '        cn.Open()
    '        cm.Connection = cn
    '        cm.CommandType = CommandType.Text
    '        query = "select a.application_number, a.empno, a.leavecode,a.from_Date, a.to_date, "
    '        query = query & " a.Number_of_days, b.empname, b.desigcode as designation"
    '        query = query & " from hr_leave_application_details as a, employee_master as b"
    '        query = query & " where a.application_number='" & txtAppl.Text & "' and a.empno = b.empno "

    '        cm.CommandText = query
    '        rdr = cm.ExecuteReader
    '        While rdr.Read
    '            txtEmployee_Code.Text = rdr("empno")
    '            txtLeave_from.Text = Format(CDate(rdr("from_date")), "dd/MM/yyyy")
    '            txtLeave_to.Text = Format(CDate(rdr("to_date")), "dd/MM/yyyy")
    '            txtdays.Text = rdr("number_of_days")
    '            ' group_code = Trim(rdr("group_code"))
    '            txtLeaveCode.Text = rdr("leavecode")

    '            lblName.Text = rdr("empname")
    '            lblDesignation.Text = rdr("designation")

    '            selectCombo(rdr("leavecode"))
    '            Exit While
    '        End While
    '        rdr.Close()
    '        ' employeedetails()
    '    Catch ex As Exception
    '        lblMessage.Text = ex.Message
    '    Finally
    '        cm.Dispose()
    '        cn.Close()
    '    End Try
    'End Sub

    Sub employeedetails()
        Dim rdr2 As SqlDataReader
        Dim sqlstring2 As String

        sqlstring2 = "select empname,desigcode,billunit from employee_master where empno='" & Trim(txtEmployee_Code.Text) & "'"
        rdr2 = SqlHelper.ExecuteReader(con, CommandType.Text, sqlstring2)
        'Dim d As Date
        While rdr2.Read
            lblName.Text = IIf(IsDBNull(rdr2.Item("empname")), "", rdr2.Item("empname"))
            Session("code") = (Trim(rdr2.Item("desigcode")))
            Session("billunit") = IIf(IsDBNull(rdr2.Item("billunit")), "", rdr2.Item("billunit"))
        End While
        rdr2.Close()
        lblDesignation.Text = SqlHelper.ExecuteScalar(con, CommandType.Text, "select desigcode from employee_master where desigcode='" & Session("code") & "'")

        Dim leavecodestring As String = "select from_date FROM hr_leave_application_details where empno='" & txtEmployee_Code.Text & "'"
        'And l_confirm='p' 
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, leavecodestring)
        'ddlleave_code.DataValueField = "leave_code"
        Ddldate.DataTextField = "from_date"
        Ddldate.DataSource = rdr
        Ddldate.DataBind()
        Ddldate.Items.Insert(0, "SELECT DATE")
        txtEmployee_Code.ReadOnly = True
        txtLeave_from.ReadOnly = True
        txtLeave_to.ReadOnly = True
        txtleaveDescription.ReadOnly = True

        ' lblDesignation.Text = SqlHelper.ExecuteScalar(con, CommandType.Text, "select isnull(desigcode,'')long_description  from employee_master where desigcode='" & Trim(Session("code")) & "'")
    End Sub
    Private Function validateAppl() As Boolean
        validateAppl = False
        Dim query As String
        query = "Select count(application_number)  from hr_leave_application_details where application_type='C'  "
        query &= " and application_number='" & txtAppl.Text & "' "
        Dim i As Integer
        i = SqlHelper.ExecuteScalar(ConfigurationSettings.AppSettings("con"), CommandType.Text, query)
        If i > 0 Then
            validateAppl = True
        End If
    End Function

    Private Sub selectCombo(ByVal LeaveCode As String)
        strsql = "select distinct description FROM hr_leave_master where leave_Code = '" & LeaveCode & "'"
        txtleaveDescription.Text = SqlHelper.ExecuteScalar(con, CommandType.Text, strsql)
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim rdr As SqlDataReader
        Dim strSql, l_confirm As String
        Dim i As Integer
        Dim cn As SqlConnection
        Dim sqltran As SqlTransaction
        cn = New SqlConnection(ConfigurationSettings.AppSettings("con"))
        cn.Open()

        Try
            strSql = "  update hr_leave_application_details set application_type='K'"
            strSql &= " ,user_id='" & Session("UserId") & "'"

            strSql &= " ,change_date='" & Format(Date.Now, "MM/dd/yyyy") & "'"
            strSql &= " ,change_time='" & Format(Date.Now, "MM/dd/yyyy hh:mm:ss") & "'"
            strSql &= ",posted='F'"
            strSql &= " where application_number='" & txtAppl.Text & "'"
            sqltran = cn.BeginTransaction
            i = SqlHelper.ExecuteNonQuery(sqltran, CommandType.Text, strSql)
            strSql = " update leave_header set leaveavailed=leaveavailed - " & Val(txtdays.Text.Trim)
            strSql &= " where empno='" & Trim(txtEmployee_Code.Text) & "'"
            strSql &= " and leavecode='" & txtLeaveCode.Text.Trim & "'"
            i = SqlHelper.ExecuteNonQuery(sqltran, CommandType.Text, strSql)
            strSql = "Delete from hr_leave_application_details where application_number='" & txtAppl.Text.Trim & "'"
            i = SqlHelper.ExecuteNonQuery(sqltran, CommandType.Text, strSql)
            lblMessage.Text = ""
            If txtEmployee_Code.Text = "" Or Ddldate.SelectedIndex < -1 Then '~~~~~~~~~~~~~``changes'

                Dim myscript1 As String = "window.alert('Kindly fill the necessary details!');"
                ClientScript.RegisterStartupScript(Me.GetType(), "myscript1", myscript1, True)
            Else
                Dim j As Integer

                '    j = MsgBox("                       LEAVE CANCELLED..                       ", 0, "Information")
                Dim myscript As String = "window.alert('LEAVE CANCELLED');"
                ClientScript.RegisterStartupScript(Me.GetType(), "myscript", myscript, True)
                Call clearall()
                sqltran.Commit()
            End If  '~~~~~~~~~~`if else changes'
        Catch ex As Exception
            lblMessage.Text = ex.Message
            sqltran.Rollback()
        Finally
            cn.Close()
            sqltran.Dispose()
        End Try

    End Sub

    Sub clearall() '~~~~~~~~~~~`clear all changes'
        txtAppl.Text = ""
        txtdays.Text = ""
        txtEmployee_Code.Text = ""
        txtLeaveCode.Text = ""
        txtLeave_from.Text = ""
        txtLeave_to.Text = ""
        lblName.Text = ""
        txtleaveDescription.Text = ""
        lblDesignation.Text = ""
        Ddldate.Items.Clear()
        'txtEmployee_Code.ReadOnly = False
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click '~~~~~~~~~'
        txtAppl.Text = ""
        txtEmployee_Code.Text = ""
        txtLeave_from.Text = ""
        txtLeave_to.Text = ""
        txtLeaveCode.Text = ""
        txtleaveDescription.Text = ""
        txtdays.Text = ""
        lblName.Text = ""
        Ddldate.Items.Clear() '~~~~~~~~~~~~change'
        lblDesignation.Text = "" '~~~~~~change'
        txtEmployee_Code.ReadOnly = False
    End Sub

    Protected Sub ddldate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Ddldate.SelectedIndexChanged


        txtdays.Text = ""
        Dim query As String
        Dim cn As SqlConnection

        Dim cm As New SqlCommand()
        Try
            ' cn = New SqlConnection(ConfigurationManager.AppSettings("con"))
            '  cn.Open()
            'cm.Connection = cn
            'cm.CommandType = CommandType.Text
            Dim a As String = Ddldate.SelectedItem.Text
            Dim a1 As DateTime = Convert.ToDateTime(a)
            Dim conn As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
            conn.Open()
            Dim toffc As New SqlCommand("select a.application_number, a.empno, a.leavecode,a.from_Date, a.to_date,  a.Number_of_days from hr_leave_application_details as a where a.empno='" & txtEmployee_Code.Text & "' and a.from_date=@a1", conn)
            toffc.Parameters.AddWithValue("@a1", a1)
            'query = "select a.application_number, a.empno, a.leavecode,a.from_Date, a.to_date, "
            'query = query & " a.Number_of_days, b.empname, b.desigcode as designation"
            'query = query & " from hr_leave_application_details as a, employee_master as b"
            'query = query & " where a.empno='" & txtEmployee_Code.Text & "' and a.from_date=@a1"

            ' cm.CommandText = query
            'rdr = cm.ExecuteReader
            rdr = toffc.ExecuteReader
            While rdr.Read
                ' txtEmployee_Code.Text = rdr("empno")
                txtAppl.Text = rdr("application_number")
                txtLeave_from.Text = Format(CDate(rdr("from_date")), "dd/MM/yyyy")
                txtLeave_to.Text = Format(CDate(rdr("to_date")), "dd/MM/yyyy")
                txtdays.Text = rdr("number_of_days")
                ' group_code = Trim(rdr("group_code"))
                txtLeaveCode.Text = rdr("leavecode")

                'lblName.Text = rdr("empname")
                'lblDesignation.Text = rdr("designation")

                selectCombo(rdr("leavecode"))
                Exit While
            End While
            rdr.Close()
            ' employeedetails()
        Catch ex As Exception
            lblMessage.Text = ex.Message
        Finally
            'cm.Dispose()
            ' cn.Close()
        End Try
    End Sub

    Private Sub BindGrid1()
        Dim ec As String = Session("Ecode")
        Dim con As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
        con.Open()
        Dim s As String = "select distinct a.empno, b.description, convert(varchar,a.from_date,103) [from_date],convert(varchar,a.to_date,103) [to_date],a.number_of_days from hr_leave_application_details a, hr_leave_master b where  a.leavecode=b.leave_code and a.applied_to='" & ec & "' and a.l_confirm='y'"
        Dim myCmd As New SqlDataAdapter(s, con)
        Dim ds As New DataSet()
        myCmd.Fill(ds)
        DataGrid1.DataSource = ds
        DataGrid1.DataBind()
    End Sub

    Protected Sub txtEmployee_Code_TextChanged(sender As Object, e As EventArgs) Handles txtEmployee_Code.TextChanged
        employeedetails()
    End Sub
End Class
