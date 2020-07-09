Public Class ProdConsumableRegister
    Inherits System.Web.UI.Page
    Protected WithEvents btnReport As System.Web.UI.WebControls.Button
    Protected WithEvents rblType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtToDt As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFrDt As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblConsignee As System.Web.UI.WebControls.Label
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents ddlDumpPl As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblPLDescr1 As System.Web.UI.WebControls.Label
    Protected WithEvents pnlConsumables As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlMain As System.Web.UI.WebControls.Panel
    Protected WithEvents ddlRejPOs As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblRejPOs As System.Web.UI.WebControls.Label
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button
    Protected WithEvents ddlPLs As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnDataForReport As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents ddlPONumber As System.Web.UI.WebControls.DropDownList
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



    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        'Put user code to initialize the page here
        If IsPostBack = False Then
            Dim Group As String = Session("Group")
            Dim UserId As String = Session("UserID")
            Dim InValid As Boolean = False
            ''''''''''''''''
            Group = "SSMELT"
            UserId = "111111"
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
            GetPls()
            'GetDumpPls()
            'GetDumpPOs()
            GetRejPOs()
        End If
        'End If
    End Sub

    'Private Sub GetDumpPls()
    '    Dim dt As DataTable
    '    Try
    '        dt = ProductionConsumables.GetProdConsumableDumpRegisterPLs()
    '        ddlDumpPl.DataSource = dt
    '        ddlDumpPl.DataTextField = dt.Columns(1).ColumnName
    '        ddlDumpPl.DataValueField = dt.Columns(2).ColumnName
    '        ddlDumpPl.DataBind()
    '        ddlDumpPl.SelectedIndex = 0
    '        lblPLDescr1.Text = ddlDumpPl.SelectedItem.Value
    '    Catch exp As Exception
    '        lblMessage.Text = exp.Message
    '    Finally
    '        dt = Nothing
    '    End Try
    'End Sub

    Private Sub GetPls()
        Dim dt As DataTable
        Try
            dt = ProductionConsumables.GetProdConsumableRegisterPL(lblConsignee.Text)
            ddlPLs.DataSource = dt
            ddlPLs.DataTextField = dt.Columns(2).ColumnName
            ddlPLs.DataValueField = dt.Columns(1).ColumnName
            ddlPLs.DataBind()
            ddlPLs.SelectedIndex = 0
            'lblPLDescr.Text = ddlPLs.SelectedItem.Value
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt = Nothing
        End Try
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim Done As Boolean
        lblMessage.Text = ""
        Try
            txtFrDt.Text = CDate(txtFrDt.Text)
            txtToDt.Text = CDate(txtToDt.Text)
            If rblType.SelectedItem.Value = 4 Then
                If Done = ProductionConsumables.GetProdConsumablesDataForReport(CDate(txtFrDt.Text), CDate(txtToDt.Text)) Then
                    Throw New Exception("No generated data for the said period. Please generate data before report viewing !")
                End If
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
            Done = True
        End Try
        If Not Done Then
            Dim strPathName As String
            Select Case rblType.SelectedItem.Value
                Case 1
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?id=24028&apsuser=Administrator&apspassword=Cris@123&apsauthtype=secEnterprise&user0=sa&password0=sadev123&promptonrefresh=0" &
                    "&promptex0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & "," & CDate(txtFrDt.Text).Day & ", 0,0,0)" &
                    "&promptex1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)" &
                    "&promptex2=" & ddlPLs.SelectedItem.Value & "" &
                    "&promptex3=0" &
                    "&user0@ProdConsumableRegisterMultipleSummary.rpt=sa&password0@ProdConsumableRegisterMultipleSummary.rpt=sadev123"
                Case 2
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=24058&user0=sa&password0=sadev123" &
                    "&promptex0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & "," & CDate(txtFrDt.Text).Day & ", 0,0,0)" &
                    "&promptex1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)" &
                    "&promptex2=" & ddlPLs.SelectedItem.Value & "" &
                    "&promptex3=0" &
                    "&user0@ProdConsumableRegisterMultipleSummary.rpt=sa&password0@ProdConsumableRegisterMultipleSummary.rpt=sadev123"
                Case 3
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=10871&user0=sa&password0=sadev123" &
                    "&promptex0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & "," & CDate(txtFrDt.Text).Day & ", 0,0,0)" &
                    "&promptex1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)" &
                    "&promptex2=0" &
                    "&promptex3=" & ddlPLs.SelectedItem.Value & "" &
                    "&user0@Supplier.rpt=sa&password0@Supplier.rpt=sadev123"
                Case 4
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=24039&user0=sa&password0=sadev123" &
                    "&promptex0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & "," & CDate(txtFrDt.Text).Day & ", 0,0,0)" &
                    "&promptex1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)" &
                    "&promptex2=ALL" &
                    "&promptex3=1" &
                    "&user0@ProdConsumableRegisterMultipleSummary.rpt=sa&password0@ProdConsumableRegisterMultipleSummary.rpt=sadev123"
                Case 5
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=24049&user0=sa&password0=sadev123" &
                    "&promptex0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & "," & CDate(txtFrDt.Text).Day & ", 0,0,0)" &
                    "&promptex1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)" &
                    "&promptex2=" & ddlPLs.SelectedItem.Value & "" &
                    "&promptex3=2"
            End Select
            Response.Redirect(strPathName)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=13707&user0=sa&password0=sadev123" &
                            "&prompt0=" & ddlPONumber.SelectedItem.Text & ""
        Response.Redirect(strPathName)
    End Sub

    'Private Sub ddlDumpPl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlDumpPl.SelectedIndexChanged
    '    lblMessage.Text = ""
    '    lblPLDescr1.Text = ddlDumpPl.SelectedItem.Value
    '    GetDumpPOs()
    'End Sub

    'Private Sub GetDumpPOs()
    '    Dim dt As DataTable
    '    Try
    '        dt = ProductionConsumables.GetProdConsumableDumpRegisterPOs(ddlDumpPl.SelectedItem.Text)
    '        ddlPONumber.DataSource = dt
    '        ddlPONumber.DataTextField = dt.Columns(0).ColumnName
    '        ddlPONumber.DataValueField = dt.Columns(0).ColumnName
    '        ddlPONumber.DataBind()
    '        ddlPONumber.SelectedIndex = 0
    '    Catch exp As Exception
    '        lblMessage.Text = exp.Message
    '    Finally
    '        dt = Nothing
    '    End Try
    'End Sub

    Private Sub GetRejPOs()
        Dim dt As DataTable
        Try
            dt = ProductionConsumables.GetCALCINEDLIMERejPOs()
            ddlRejPOs.DataSource = dt
            ddlRejPOs.DataTextField = dt.Columns(0).ColumnName
            ddlRejPOs.DataValueField = dt.Columns(1).ColumnName
            ddlRejPOs.DataBind()
            ddlRejPOs.SelectedIndex = 0
            lblRejPOs.Text = ddlRejPOs.SelectedItem.Value
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt = Nothing
        End Try
    End Sub

    Private Sub ddlRejPOs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlRejPOs.SelectedIndexChanged
        lblMessage.Text = ""
        lblRejPOs.Text = ddlRejPOs.SelectedItem.Value
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=24981&user0=sa&password0=sadev123" &
                            "&prompt0=" & ddlRejPOs.SelectedItem.Text & ""
        Response.Redirect(strPathName)
    End Sub

    Private Sub btnDataForReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDataForReport.Click
        lblMessage.Text = ""
        If CDate(txtFrDt.Text).Month <> CDate(txtToDt.Text).Month Then
            lblMessage.Text = "InValid Dates for data generation!"
            Exit Sub
        End If
        If CDate(txtToDt.Text).DaysInMonth(CDate(txtToDt.Text).Year, CDate(txtToDt.Text).Month) <> CDate(txtToDt.Text).Day Then
            lblMessage.Text = "InValid Dates for data generation!"
            Exit Sub
        End If
        Dim dt As DataTable
        Try
            dt = ProductionConsumables.ProdConsumableRegisterDataForReport(CDate(txtFrDt.Text), CDate(txtToDt.Text))
            If dt.Rows.Count > 0 Then
                lblMessage.Text = "Data Generated ! "
            Else
                lblMessage.Text = "Data Generation failed !"
            End If
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
    End Sub

    Protected Sub ddlPLs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlPLs.SelectedIndexChanged

    End Sub
End Class
