Imports System.Globalization
Public Class ProdConsumableDetailsReport
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents txtToDt As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFrDt As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnReport As System.Web.UI.WebControls.Button
    Protected WithEvents rblTypeHeader As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents lblConsignee As System.Web.UI.WebControls.Label
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList

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


    Protected Sub Dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If IsPostBack = False Then
            Dim Group As String = Session("Group")
            Dim UserId As String = Session("UserID")
            Dim InValid As Boolean = False
            '''''''''''''''''
            Group = "SSMELT"
            UserId = "000459"
            ''''''''''''''''
            Try
                lblConsignee.Text = ProductionConsumables.GetConsignee(Group, UserId)
                If lblConsignee.Text.Trim.Length = 4 Then InValid = True
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            'If Not InValid Then
            '    Response.Redirect("/mss/logon.aspx")
            'Else
            txtFrDt.Text = Now.Date
                txtToDt.Text = Now.Date
                SetReport()
                SetReportList()
            End If
        'End If
    End Sub

    Private Sub SetReport()
        Dim dt As DataTable
        Try
            dt = ProductionConsumables.GetReportList
            rblTypeHeader.DataSource = dt
            rblTypeHeader.DataTextField = dt.Columns(1).ColumnName
            rblTypeHeader.DataValueField = dt.Columns(0).ColumnName
            rblTypeHeader.DataBind()
            rblTypeHeader.SelectedIndex = 0
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
    End Sub

    Private Sub SetReportList()
        Dim dt As DataTable
        Try
            dt = ProductionConsumables.GetReportItems(rblTypeHeader.SelectedItem.Value)
            rblType.DataSource = dt
            rblType.DataTextField = dt.Columns(0).ColumnName
            rblType.DataValueField = dt.Columns(1).ColumnName
            rblType.DataBind()
            rblType.SelectedIndex = 0
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim Done As Boolean
        lblMessage.Text = ""
        Try
            txtFrDt.Text = CDate(txtFrDt.Text)
            txtToDt.Text = CDate(txtToDt.Text)


        Catch exp As Exception
            lblMessage.Text = exp.Message
            Done = True
        End Try
        If Not Done Then
            Dim strPathName As String
            Select Case rblType.SelectedItem.Value
                Case 1
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=16408&user0=sa&password0=sadev123" &
                    "&promptex0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & "," & CDate(txtFrDt.Text).Day & ",0,0,0)" &
                    "&promptex1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)" &
                    "&promptex2=0"
                    '"&user0@FurnaceWiseElecEnergyConsumptionSubReport.rpt=report&password0@FurnaceWiseElecEnergyConsumptionSubReport.rpt=report"
                Case 2
                    strPathName = " http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=23401&user0=sa&password0=sadev123" &
                    "&prompt0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & "," & CDate(txtFrDt.Text).Day & ", 0,0,0)" &
                    "&prompt1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)" &
                    "&prompt2=2"
                Case 3
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=23317&user0=sa&password0=sadev123" &
                    "&prompt0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & "," & CDate(txtFrDt.Text).Day & ", 0,0,0)" &
                    "&prompt1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)" &
                    "&prompt2=0"
                    '"&user0@FurnaceWiseScrapReceiptSummary.rpt=report&password0@FurnaceWiseScrapReceiptSummary.rpt=report" &
                    '"&user0@Report.rpt=report&password0@Report.rpt=report"
                Case 4
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=13694&user0=sa&password0=sadev123" &
                    "&prompt0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & "," & CDate(txtFrDt.Text).Day & ", 0,0,0)" &
                    "&prompt1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)" &
                    "&prompt2=0"
                    '"&user0@HSDReceiptSummary.rpt=report&password0@HSDReceiptSummary.rpt=report"
                Case 5
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=13956&user0=sa&password0=sadev123" &
                    "&prompt0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & "," & CDate(txtFrDt.Text).Day & ", 0,0,0)" &
                    "&prompt1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)" &
                    "&prompt2=2"
                Case 6
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=10871&user0=sa&password0=sadev123" &
                    "&prompt0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & "," & CDate(txtFrDt.Text).Day & ", 0,0,0)" &
                    "&prompt1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)" &
                    "&prompt2=0"
                    '"&user0@Report.rpt=report&password0@Report.rpt=report"
                Case 7
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=22347&user0=sa&password0=sadev123" &
                    "&prompt0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & "," & CDate(txtFrDt.Text).Day & ", 0,0,0)" &
                    "&prompt1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)" &
                    "&prompt2=0"
                Case 8
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=22960&user0=sa&password0=sadev123" &
                    "&prompt0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & "," & CDate(txtFrDt.Text).Day & ", 0,0,0)" &
                    "&prompt1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)" &
                    "&prompt2=0"
                Case 9
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=26502&user0=sa&password0=sadev123" &
                    "&prompt0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & "," & CDate(txtFrDt.Text).Day & ", 0,0,0)" &
                    "&prompt1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)" &
                    "&prompt2=1"
                   ' "&user0@ScrapReceiptSummary.rpt=report&password0@ScrapReceiptSummary.rpt=report"
                Case 10
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=21852&user0=sa&password0=sadev123" &
                    "&prompt0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & "," & CDate(txtFrDt.Text).Day & ", 0,0,0)" &
                    "&prompt1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)" &
                    "&prompt2=0"
                Case 11
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=23010&user0=sa&password0=sadev123" &
                    "&prompt0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & "," & CDate(txtFrDt.Text).Day & ", 0,0,0)" &
                    "&prompt1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)" &
                    "&prompt2=4"
                Case 12
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=14000&user0=sa&password0=sadev123" &
                    "&prompt0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & "," & CDate(txtFrDt.Text).Day & ", 0,0,0)" &
                    "&prompt1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)" &
                    "&prompt2=4"
                Case 13
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=23017&user0=sa&password0=sadev123" &
                    "&prompt0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & "," & CDate(txtFrDt.Text).Day & ", 0,0,0)" &
                    "&prompt1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)" &
                    "&prompt2=2"
                Case 14
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=22116&user0=sa&password0=sadev123" &
                    "&prompt0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & "," & CDate(txtFrDt.Text).Day & ", 0,0,0)" &
                    "&prompt1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)" &
                    "&prompt2=3"
                Case 15
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=23025&user0=sa&password0=sadev123" &
                    "&prompt0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & "," & CDate(txtFrDt.Text).Day & ", 0,0,0)" &
                    "&prompt1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)" &
                    "&prompt2=4"
                Case 16
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=24997&user0=sa&password0=sadev123" &
                    "&prompt0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & "," & CDate(txtFrDt.Text).Day & ", 0,0,0)" &
                    "&prompt1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)" &
                    "&prompt2=4"
                Case 17
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=13714&user0=sa&password0=sadev123" &
                    "&prompt0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & "," & CDate(txtFrDt.Text).Day & ", 0,0,0)" &
                    "&prompt1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)" &
                    "&prompt2=5"
                Case 18
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=24989&user0=sa&password0=sadev123" &
                    "&prompt0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & "," & CDate(txtFrDt.Text).Day & ", 0,0,0)" &
                    "&prompt1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)" &
                    "&prompt2=5"
                Case 19
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=13824&user0=sa&password0=sadev123" &
                    "&prompt0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & "," & CDate(txtFrDt.Text).Day & ", 0,0,0)" &
                    "&prompt1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)" &
                    "&prompt2=2" &
                    "&prompt3=''"
                Case 20
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=13830&user0=sa&password0=sadev123" &
                    "&prompt0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & "," & CDate(txtFrDt.Text).Day & ", 0,0,0)" &
                    "&prompt1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)" &
                    "&prompt2=3" &
                    "&prompt3=''"
                Case 21
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=21951&user0=sa&password0=sadev123" &
                    "&prompt0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & "," & CDate(txtFrDt.Text).Day & ", 0,0,0)" &
                    "&prompt1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)" &
                    "&prompt2=6"
                Case 22
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=14006&user0=sa&password0=sadev123" &
                    "&prompt0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & "," & CDate(txtFrDt.Text).Day & ", 0,0,0)" &
                    "&prompt1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)" &
                    "&prompt2=5"
                Case 23
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=22960&user0=sa&password0=sadev123" &
                    "&prompt0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & "," & CDate(txtFrDt.Text).Day & ", 0,0,0)" &
                    "&prompt1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)" &
                    "&prompt2=1"
                Case 24
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=22125&user0=sa&password0=sadev123" &
                    "&prompt0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & "," & CDate(txtFrDt.Text).Day & ", 0,0,0)" &
                    "&prompt1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)" &
                    "&prompt2=7"
                Case 25
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=23258&user0=sa&password0=sadev123" &
                    "&prompt0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & "," & CDate(txtFrDt.Text).Day & ", 0,0,0)" &
                    "&prompt1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)" &
                    "&prompt2=8"
                Case 26
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=13976&user0=sa&password0=sadev123" &
                    "&prompt0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & "," & CDate(txtFrDt.Text).Day & ", 0,0,0)" &
                    "&prompt1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)" &
                    "&prompt2=9"
                Case 27
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=23240&user0=sa&password0=sadev123" &
                    "&prompt0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & "," & CDate(txtFrDt.Text).Day & ", 0,0,0)" &
                    "&prompt1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)" &
                    "&prompt2=10"
                Case 28
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=13583&user0=sa&password0=sadev123" &
                    "&prompt0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & "," & CDate(txtFrDt.Text).Day & ", 0,0,0)" &
                    "&prompt1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)" &
                    "&prompt2=11"
                Case 29
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=13589&user0=sa&password0=sadev123" &
                    "&prompt0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & "," & CDate(txtFrDt.Text).Day & ", 0,0,0)" &
                    "&prompt1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)" &
                    "&prompt2=12"
                Case 30
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=13569&user0=sa&password0=sadev123" &
                    "&prompt0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & "," & CDate(txtFrDt.Text).Day & ", 0,0,0)" &
                    "&prompt1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)" &
                    "&prompt2=13"
                Case 31
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=13576&user0=sa&password0=sadev123" &
                    "&prompt0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & "," & CDate(txtFrDt.Text).Day & ", 0,0,0)" &
                    "&prompt1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)" &
                    "&prompt2=14"
                Case 32
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=24883&user0=sa&password0=sadev123" &
                    "&prompt0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & "," & CDate(txtFrDt.Text).Day & ", 0,0,0)" &
                    "&prompt1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)" &
                    "&prompt2=15"
                Case 33
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=24825&user0=sa&password0=sadev123" &
                    "&prompt0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & "," & CDate(txtFrDt.Text).Day & ", 0,0,0)" &
                    "&prompt1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)" &
                    "&prompt2=16"
                Case 34
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=13775&user0=sa&password0=sadev123" &
                    "&prompt0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & "," & CDate(txtFrDt.Text).Day & ", 0,0,0)" &
                    "&prompt1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)" &
                    "&prompt2=17"
                Case 35
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=13788&user0=sa&password0=sadev123" &
                    "&prompt0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & "," & CDate(txtFrDt.Text).Day & ", 0,0,0)" &
                    "&prompt1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)" &
                    "&prompt2=18"
                Case 36
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=23249&user0=sa&password0=sadev123" &
                    "&prompt0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & "," & CDate(txtFrDt.Text).Day & ", 0,0,0)" &
                    "&prompt1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)" &
                    "&prompt2=5"
                    '"&user0@ProdConsumableStatementSummary.rpt=report&password0@ProdConsumableStatementSummary.rpt=report"
                Case 37
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=22338&user0=sa&password0=sadev123" &
                    "&prompt0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & "," & CDate(txtFrDt.Text).Day & ", 0,0,0)" &
                    "&prompt1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)" &
                    "&prompt2=19"
                Case 38
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=22354&user0=sa&password0=sadev123" &
                    "&prompt0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & "," & CDate(txtFrDt.Text).Day & ", 0,0,0)" &
                    "&prompt1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)" &
                    "&prompt2=20"
            End Select
            Response.Redirect(strPathName)
        End If
    End Sub

    Private Sub rblTypeHeader_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblTypeHeader.SelectedIndexChanged
        lblMessage.Text = ""
        SetReportList()
    End Sub
End Class
