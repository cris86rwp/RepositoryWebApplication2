Public Class LiquidOxygenValuesReport
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtFromDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtToDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents CustomValidator1 As System.Web.UI.WebControls.CustomValidator
    Protected WithEvents lblConsignee As System.Web.UI.WebControls.Label
    Protected WithEvents pnlProductNo As System.Web.UI.WebControls.Panel
    Protected WithEvents btnMeter As System.Web.UI.WebControls.Button
    Protected WithEvents btnHourly As System.Web.UI.WebControls.Button
    Protected WithEvents btnDaily As System.Web.UI.WebControls.Button
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

        ' Page.Theme = themeValue
        Page.Theme = Session("Theme")
    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None
        'Put user code to initialize the page here
        If IsPostBack = False Then
            Notvalid = False
            Dim Group As String = Session("Group")
            Dim strMode As String = Request.QueryString("mode")
            Dim UserId As String = Session("UserID")
            Dim InValid As Boolean = False
            Group = "utilit"
            UserId = "078852"
            txtFromDate.Text = Now.Date
            txtToDate.Text = Now.Date
            If Group <> "STORES" Then
                Try
                    lblConsignee.Text = CriticalItems.ItemTables.GetConsignee(Group, UserId)
                    If lblConsignee.Text.Trim.Length = 4 Then InValid = True
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                End Try
                'If Not InValid Then
                '    Response.Redirect("/mss/logon.aspx")
                'End If
            End If
        End If
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
        If lblConsignee.Text.ToLower = "spares" Then lblConsignee.Text = ""
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=19002&user0=sa&password0=sadev123&prompt0=DateTime(" & Format(CDate(txtFromDate.Text), "yyyy,MM,dd, 00, 00, 00") & ")&prompt1=DateTime(" & Format(CDate(txtToDate.Text), "yyyy,MM,dd, 00, 00, 00") & ")&prompt2=2"
        strPathName &= "&user0@SubReportforSpareCell.rpt=sa&password0@SubReportforSpareCell.rpt=sadev123"
        'strPathName = "/testmss/sseimb/reports/formats/NsIdnStatusReport.rpt?user0=report&password0=report&promptonrefresh=0&prompt0=DateTime(" & Format(CDate(txtFromDate.Text), "yyyy,MM,dd 00, 00, 00") & ")&prompt1=DateTime(" & Format(CDate(txtToDate.Text), "yyyy,MM,dd 00, 00, 00") & ")"
        Response.Redirect(strPathName)
    End Sub

    Private Sub btnHourly_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHourly.Click
        If Notvalid = True Then
            Exit Sub
        End If
        Dim strPathName As String
        If lblConsignee.Text.ToLower = "spares" Then lblConsignee.Text = ""
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=27548&user0=sa&password0=sadev123&prompt0=DateTime(" & Format(CDate(txtFromDate.Text), "yyyy,MM,dd 00, 00, 00") & ")&prompt1=DateTime(" & Format(CDate(txtToDate.Text), "yyyy,MM,dd 00, 00, 00") & ")&prompt2=0"
        strPathName &= "&user0@SubReportforSpareCell.rpt=sa&password0@SubReportforSpareCell.rpt=sadev123"
        'strPathName = "/testmss/sseimb/reports/formats/NsIdnStatusReport.rpt?user0=report&password0=report&promptonrefresh=0&prompt0=DateTime(" & Format(CDate(txtFromDate.Text), "yyyy,MM,dd 00, 00, 00") & ")&prompt1=DateTime(" & Format(CDate(txtToDate.Text), "yyyy,MM,dd 00, 00, 00") & ")"
        Response.Redirect(strPathName)
    End Sub

    Private Sub btnDaily_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDaily.Click
        If Notvalid = True Then
            Exit Sub
        End If
        Dim strPathName As String
        If lblConsignee.Text.ToLower = "spares" Then lblConsignee.Text = ""
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=19038&user0=sa&password0=sadev123&prompt0=DateTime(" & Format(CDate(txtFromDate.Text), "yyyy,MM,dd 00, 00, 00") & ")&prompt1=DateTime(" & Format(CDate(txtToDate.Text), "yyyy,MM,dd 00, 00, 00") & ")&prompt2=1"
        strPathName &= "&user0@SubReportforSpareCell.rpt=sa&password0@SubReportforSpareCell.rpt=sadev123"
        'strPathName = "/testmss/sseimb/reports/formats/NsIdnStatusReport.rpt?user0=report&password0=report&promptonrefresh=0&prompt0=DateTime(" & Format(CDate(txtFromDate.Text), "yyyy,MM,dd 00, 00, 00") & ")&prompt1=DateTime(" & Format(CDate(txtToDate.Text), "yyyy,MM,dd 00, 00, 00") & ")"
        Response.Redirect(strPathName)
    End Sub
End Class
