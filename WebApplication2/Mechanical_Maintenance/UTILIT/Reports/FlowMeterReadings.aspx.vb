Public Class FlowMeterReadings
    Inherits System.Web.UI.Page
    Protected WithEvents lblConsignee As System.Web.UI.WebControls.Label
    Protected WithEvents CustomValidator1 As System.Web.UI.WebControls.CustomValidator
    Protected WithEvents btnMeter As System.Web.UI.WebControls.Button
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtToDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFromDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents pnlProductNo As System.Web.UI.WebControls.Panel
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnAxleForgeShop As System.Web.UI.WebControls.Button
    Protected WithEvents btnMouldRoom As System.Web.UI.WebControls.Button
    Protected WithEvents Button3 As System.Web.UI.WebControls.Button
    Protected WithEvents btnLO As System.Web.UI.WebControls.Button
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    Dim Notvalid As Boolean
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

    Shared themeValue As String

    Public Sub New()

        AddHandler PreInit, New EventHandler(AddressOf Page_PreInit)
    End Sub

    Private Sub Page_PreInit(ByVal sender As Object, ByVal e As EventArgs)

        Page.Theme = themeValue
    End Sub


    Protected Sub dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        '  Session("Group") = "utilit"
        'Session("UserID") = "078852"
        'If IsPostBack = False Then
        '    txtFromDate.Text = Now.Date
        '    txtToDate.Text = Now.Date
        '    Notvalid = False
        '    Dim Group As String = Session("Group")
        '    Dim strMode As String = Request.QueryString("mode")
        '    Dim UserId As String = Session("UserID")
        '    Dim InValid As Boolean = False
        '    Group = "utilit"
        '    UserId = "078852"
        '    Try
        '        lblConsignee.Text = CriticalItems.ItemTables.GetConsignee(Group, UserId)
        '        If lblConsignee.Text.Trim.Length = 4 Then InValid = True
        '    Catch exp As Exception
        '        lblMessage.Text = exp.Message
        '    End Try
        '    If Not InValid Then
        '        Response.Redirect("/mss/logon.aspx")
        '    End If
        'End If
    End Sub
    Private Sub CustomValidator1_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CustomValidator1.ServerValidate
        lblMessage.Text = ""
        Dim dt1, dt2 As Date
        Dim dt1IsValid, dt2IsValid As Boolean
        dt1IsValid = False
        dt2IsValid = False
        Try
            dt1 = txtFromDate.Text.Trim
            dt1IsValid = True
            dt2 = txtToDate.Text.Trim
            dt2IsValid = True
            If dt1 > Today.Date Then
                lblMessage.Text = "From Date:'" & txtFromDate.Text.Trim & "' Can Not Be Greater Than Current Date. "
                txtFromDate.Text = ""
            End If

            If dt2 > Today.Date Then
                lblMessage.Text &= "To Date:'" & txtToDate.Text.Trim & "' Can Not Be Greater Than Current Date. "
                txtToDate.Text = ""
            End If

            If dt1 > dt2 Then
                lblMessage.Text &= "From Date is more than To Date ! (From :" & txtFromDate.Text & " To : " & txtToDate.Text & "). "
                txtFromDate.Text = ""
                txtToDate.Text = ""
            End If

        Catch exp As Exception
            If exp.Message.StartsWith("Cast") Then
                If dt1IsValid = False Then
                    lblMessage.Text &= " From Date:'" & txtFromDate.Text.Trim & "'  is not Valid. "
                    txtFromDate.Text = ""
                ElseIf dt2IsValid = False Then
                    lblMessage.Text &= " To Date:'" & txtToDate.Text.Trim & "'  is not Valid. "
                    txtToDate.Text = ""
                End If
            End If
        End Try
        If txtFromDate.Text = "" Or txtToDate.Text = "" Then
            Notvalid = True
        End If
    End Sub


    Private Sub btnMeter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMeter.Click
        If Notvalid = True Then
            Exit Sub
        End If
        Dim strPathName As String
        strPathName = "/mss/mss/utilityShop/reports/formats/UtilityShop.rpt?user0=report&password0=report&promptonrefresh=0&prompt0=DateTime(" & Format(CDate(txtFromDate.Text), "yyyy,MM,dd 00, 00, 00") & ")&prompt1=DateTime(" & Format(CDate(txtToDate.Text), "yyyy,MM,dd 00, 00, 00") & ")&prompt2=0"
        Response.Redirect(strPathName)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            DataGrid1.DataSource = UtilityShop.DataTables.FlowMeterReadings(CDate(txtFromDate.Text), CDate(txtToDate.Text))
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnAxleForgeShop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAxleForgeShop.Click
        If Notvalid = True Then
            Exit Sub
        End If
        Dim strPathName As String
        strPathName = "/mss/mss/utilityShop/reports/formats/AxleForgeShop.rpt?user0=report&password0=report&promptonrefresh=0&prompt0=DateTime(" & Format(CDate(txtFromDate.Text), "yyyy,MM,dd 00, 00, 00") & ")&prompt1=DateTime(" & Format(CDate(txtToDate.Text), "yyyy,MM,dd 00, 00, 00") & ")&prompt2=0"
       Response.Redirect(strPathName)
    End Sub

    Private Sub btnMouldRoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMouldRoom.Click
        If Notvalid = True Then
            Exit Sub
        End If
        Dim strPathName As String
        strPathName = "/mss/mss/utilityShop/reports/formats/MouldRoom.rpt?user0=report&password0=report&promptonrefresh=0&prompt0=DateTime(" & Format(CDate(txtFromDate.Text), "yyyy,MM,dd 00, 00, 00") & ")&prompt1=DateTime(" & Format(CDate(txtToDate.Text), "yyyy,MM,dd 00, 00, 00") & ")&prompt2=0"
        Response.Redirect(strPathName)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If DataGrid1.Items.Count > 0 Then
            Dim prevstate As Boolean = Me.EnableViewState
            Dim tw As New System.IO.StringWriter()
            Dim hw As New System.Web.UI.HtmlTextWriter(tw)
            Try
                Response.ContentType = "application/vnd.ms_excel"
                Response.Charset = ""
                Me.EnableViewState = False
                DataGrid1.RenderControl(hw)
                Response.Write(tw.ToString)
                Response.End()
                Me.EnableViewState = prevstate
            Catch exp As Exception
                lblMessage.Text = exp.Message
            Finally
                prevstate = Nothing
                tw = Nothing
                hw = Nothing
            End Try
        Else
            lblMessage.Text = "No Data in Grid to export !"
        End If
    End Sub

    Private Sub btnLO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLO.Click
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            DataGrid1.DataSource = UtilityShop.DataTables.LOConsumptionSSFORG(CDate(txtFromDate.Text), CDate(txtToDate.Text))
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
End Class
