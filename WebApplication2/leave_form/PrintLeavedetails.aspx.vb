Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports System.Data

Public Class PrintLeavedetails
    Inherits System.Web.UI.Page
    Protected WithEvents cmdReport As System.Web.UI.WebControls.Button
    ' Protected WithEvents cmdExit As System.Web.UI.WebControls.Button
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblEmployee_name As System.Web.UI.WebControls.Label
    Protected WithEvents txtEmployee_code As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Dim sqlString As String
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Dim rdr As SqlDataReader
    Private con As New SqlConnection(ConfigurationManager.AppSettings("DBcon"))
    Dim strServer, strPathName As String
    Protected WithEvents cmdClear As System.Web.UI.WebControls.Button
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList

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
        'Put user code to initialize the page here
        txtEmployee_code.Text = Session("Ecode")
        Dim available As Boolean = False
        lblMessage.Text = ""
        lblEmployee_name.Text = ""
        sqlString = "select empname from employee_master where empno='" & Trim(txtEmployee_code.Text) & "'"
        rdr = SqlHelper.ExecuteReader(ConfigurationSettings.AppSettings("con"), CommandType.Text, sqlString)
        While rdr.Read
            If IsDBNull(rdr.Item("empname")) = True Then

            Else
                available = True
                lblEmployee_name.Text = rdr.Item("empname")
            End If
        End While
        If available = False Then
            lblMessage.Text = " "
            Dim i As Integer
            ' Response.Write("<script language=""javascript"">alert('Congratulations!');</script>")
            i = MsgBox("Record is not available...", 0, "Information")
        End If
        con.Open()
    End Sub



    Private Sub txtEmployee_code_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEmployee_code.TextChanged


    End Sub
    Private Sub cmdReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReport.Click
        'strServer = Server.MachineName
        'strPathName = "http://" & strServer
        'strPathName = strPathName & "/wapLeave/rptMainLeave_balance.rpt?user0=wap&password0=wap"
        'strPathName = strPathName & "&sf={employee_master.empno} = '" & Trim(txtEmployee_code.Text) & "'"
        'Response.Redirect(strPathName)

        'Dim strPathName As String

        'strPathName = "http://10.55.16.6:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?id=7351&apsuser=Administrator&apspassword=Cris@123&apsauthtype=Enterprise&user0=sa&password0=sadev123&promptonrefresh=0"

        'Response.Redirect(strPathName)

        DataGrid1.Visible = True

        bind_grid1()
    End Sub
    Private Sub bind_grid1()
        Dim sqlstring2 As String = "select distinct application_number,application_type, leavecode, convert(varchar,from_date,103) [from_date],convert(varchar,to_date,103) [to_date],l_convert,number_of_days,reason,l_confirm,outstation_or_hq from hr_leave_application_details where empno='" & Trim(txtEmployee_code.Text) & "'"

        Dim myCommand As New SqlDataAdapter(sqlstring2, con)
        Dim ds As New DataSet()
        myCommand.Fill(ds)

        DataGrid1.DataSource = ds
        DataGrid1.DataBind()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        lblMessage.Text = ""
        lblEmployee_name.Text = ""
        txtEmployee_code.Text = ""
        DataGrid1.Visible = False
    End Sub
End Class
