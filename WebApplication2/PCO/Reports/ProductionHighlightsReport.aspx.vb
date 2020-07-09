Public Class ProductionHighlightsReport
    Inherits System.Web.UI.Page
    Protected WithEvents ddlPHLs As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblmessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtPHLDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents txtRejDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button
    Protected WithEvents Button3 As System.Web.UI.WebControls.Button
    Protected WithEvents Button4 As System.Web.UI.WebControls.Button
    Protected WithEvents btnCWEW As System.Web.UI.WebControls.Button
    Protected WithEvents btnCWEA As System.Web.UI.WebControls.Button
    Protected WithEvents btnMag As System.Web.UI.WebControls.Button
    Protected WithEvents txtFromDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtToDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnPCOQry As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents rblPCO As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents Button5 As System.Web.UI.WebControls.Button
    Protected WithEvents Button6 As System.Web.UI.WebControls.Button
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
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


    Protected Sub dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        'Response.Redirect("http://" & rwfGen.ReportServer.ServerName & "/mmsreports/pcopco/ProductionHighlightsReport.aspx")
        If Page.IsPostBack = False Then

            Dim dtPhl As Date
            Try
                dtPhl = PCO.tables.GetTopPHLDate
                If IsNothing(dtPhl) OrElse IsDBNull(dtPhl) Then
                    dtPhl = Now.Date.Today
                End If
            Catch exp As Exception
                dtPhl = Now.Date.Today
            End Try
            txtPHLDate.Text = dtPhl
            'txtRejDate.Text = dtPhl
            'txtFromDate.Text = dtPhl
            'txtToDate.Text = dtPhl
            Dim dt As DataTable
            Try
                dt = PCO.tables.PHLDates
                ddlPHLs.DataSource = dt
                ddlPHLs.DataTextField = dt.Columns(0).ColumnName
                ddlPHLs.DataValueField = dt.Columns(1).ColumnName
                ddlPHLs.DataBind()
                ddlPHLs.Items.Insert(0, "Select")
                lblmessage.Text = "Select a Date or Input a date DD/MM/YYYY"
            Catch exp As Exception
                ddlPHLs.Items.Clear()
                lblmessage.Text = exp.Message
            Finally

                ' dt.Dispose()
                dtPhl = Nothing
                dt = Nothing
            End Try
        End If
    End Sub

    Private Sub ddlPHLs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlPHLs.SelectedIndexChanged
        txtDate.Text = ""
        txtDate.Text = CDate(ddlPHLs.SelectedItem.Value)
        ShowReport()
    End Sub

    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        ddlPHLs.ClearSelection()
        Dim dt As Date
        Dim blnSelected As Boolean
        Try
            dt = CDate(txtDate.Text)
            Dim i As Integer
            For i = 0 To ddlPHLs.Items.Count - 1
                If dt.ToString.Trim.StartsWith(ddlPHLs.Items(i).Text) Then
                    ddlPHLs.Items(i).Selected = True
                    blnSelected = True
                    Exit Try
                End If
            Next
            If blnSelected = False Then
                lblmessage.Text = "Report not generated for : " & txtDate.Text
                txtDate.Text = ""
            End If
            i = Nothing
        Catch exp As Exception
            lblmessage.Text = exp.Message & ":" & txtDate.Text
            txtDate.Text = ""
        End Try
        If txtDate.Text <> "" Then
            ShowReport()
        End If
        blnSelected = Nothing
        dt = Nothing
    End Sub

    Private Sub ShowReport()
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=25560&user0=sa&password0=sadev123" &
            "&prompt0=DateTime(" & CStr(CDate(txtDate.Text).Year) & "," & CStr(CDate(txtDate.Text).Month) & "," & CStr(CDate(txtDate.Text).Day) & ", 00, 00, 00)" &
            "&user0@RBTargets.rpt=sa&password0@RBTargets.rpt=sa" &
            "&user0@Summary.rpt=sa&password0@Summary.rpt=sa" &
            "&user0@mm_GMHeat.rpt=sa&password0@mm_GMHeat.rpt=sa" &
            "&user0@AxleShopNumbersUnits.rpt=sa&password0@AxleShopNumbersUnits.rpt=sa" &
            "&user0@WheelSets.rpt=sa&password0@WheelSets.rpt=sa" &
            "&user0@Breakdowns.rpt=sa&password0@Breakdowns.rpt=sa" &
            "&user0@WheelsAvailable=sa&password0@WheelsAvailable=sa" &
            "&user0@DmWhlsAsPerSSE=sa&password0@DmWhlsAsPerSSE=sa" &
            "&user0@AMSLooseAxlesAvailable.rpt=sa&password0@AMSLooseAxlesAvailable.rpt=sa" &
            "&user0@WheelsetInventory.rpt=sa&password0@WheelsetInventory.rpt=sa" &
            "&user0@WheelsetInventoryStores.rpt=sa&password0@WheelsetInventoryStores.rpt=sa" &
            "&user0@DespatchedWheels.rpt=sa&password0@DespatchedWheels.rpt=sa" &
            "&user0@DespatchedAxles.rpt=sa&password0@DespatchedAxles.rpt=sa" &
            "&user0@DespatchedWheelSets.rpt=sa&password0@DespatchedWheelSets.rpt=sa"
        Response.Redirect(strPathName)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=15947&user0=sa&password0=sadev123" &
            "&prompt0=DateTime(" & CStr(CDate(txtPHLDate.Text).Year) & "," & CStr(CDate(txtPHLDate.Text).Month) & "," & CStr(CDate(txtPHLDate.Text).Day) & ", 00, 00, 00)" &
            "&user0@RBTargets.rpt=sa&password0@RBTargets.rpt=sa" &
            "&user0@Summary.rpt=sa&password0@Summary.rpt=sa" &
            "&user0@mm_GMHeat.rpt=sa&password0@mm_GMHeat.rpt=sa" &
            "&user0@AxleShopNumbersUnits.rpt=sa&password0@AxleShopNumbersUnits.rpt=sa" &
            "&user0@WheelSets.rpt=sa&password0@WheelSets.rpt=sa" &
            "&user0@Breakdowns.rpt=sa&password0@Breakdowns.rpt=sa" &
            "&user0@WheelsAvailable=report&password0@WheelsAvailable=report" &
            "&user0@DmWhlsAsPerSSE=report&password0@DmWhlsAsPerSSE=report" &
            "&user0@AMSLooseAxlesAvailable.rpt=sa&password0@AMSLooseAxlesAvailable.rpt=sa" &
            "&user0@WheelsetInventory.rpt=sa&password0@WheelsetInventory.rpt=sa" &
            "&user0@WheelsetInventoryStores.rpt=sa&password0@WheelsetInventoryStores.rpt=sa" &
            "&user0@DespatchedWheels.rpt=sa&password0@DespatchedWheels.rpt=sa" &
            "&user0@DespatchedAxles.rpt=sa&password0@DespatchedAxles.rpt=sa" &
            "&user0@DespatchedWheelSets.rpt=sa&password0@DespatchedWheelSets.rpt=sa"
        Response.Redirect(strPathName)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        lblmessage.Text = ""
        Dim dt As DataTable
        Try
            dt = PCO.tables.AxleShopRejData(CDate(txtRejDate.Text))
            If dt.Rows.Count > 0 Then
                lblmessage.Text = "Data Generated !"
            End If
        Catch exp As Exception
            lblmessage.Text = exp.Message
        Finally
            dt = Nothing
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim strPathName As String
        strPathName = "http://" & rwfGen.ReportServer.ServerName & "" &
                    "/mmsreports/pcopco/formats/AxleShopRej.rpt?user0=report&password0=report" &
            "&prompt0=DateTime(" & CStr(CDate(txtPHLDate.Text).Year) & "," & CStr(CDate(txtPHLDate.Text).Month) & "," & CStr(CDate(txtPHLDate.Text).Day) & ", 00, 00, 00)"
        Response.Redirect(strPathName)
    End Sub

    'Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
    '    Dim strPathName As String
    '    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=13875&user0=sa&password0=sadev123" &
    '        "&prompt0=DateTime(" & CStr(CDate(txtPHLDate.Text).Year) & "," & CStr(CDate(txtPHLDate.Text).Month) & "," & CStr(CDate(txtPHLDate.Text).Day) & ", 00, 00, 00)"
    '    Response.Redirect(strPathName)
    'End Sub

    Private Sub btnCWEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCWEW.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=25753&user0=sa&password0=sadev123" &
            "&prompt0=DateTime(" & CStr(CDate(txtPHLDate.Text).Year) & "," & CStr(CDate(txtPHLDate.Text).Month) & "," & CStr(CDate(txtPHLDate.Text).Day) & ", 00, 00, 00)" &
            "&user0@RBTargets.rpt=sa&password0@RBTargets.rpt=sa" &
            "&user0@Summary.rpt=sa&password0@Summary.rpt=sa" &
            "&user0@mm_GMHeat.rpt=sa&password0@mm_GMHeat.rpt=sa" &
            "&user0@AxleShopNumbersUnits.rpt=sa&password0@AxleShopNumbersUnits.rpt=sa" &
            "&user0@WheelSets.rpt=sa&password0@WheelSets.rpt=sa" &
            "&user0@Breakdowns.rpt=sa&password0@Breakdowns.rpt=sa" &
            "&user0@WheelsAvailable=report&password0@WheelsAvailable=report" &
            "&user0@DmWhlsAsPerSSE=report&password0@DmWhlsAsPerSSE=report" &
            "&user0@AMSLooseAxlesAvailable.rpt=sa&password0@AMSLooseAxlesAvailable.rpt=sa" &
            "&user0@WheelsetInventory.rpt=sa&password0@WheelsetInventory.rpt=sa" &
            "&user0@WheelsetInventoryStores.rpt=sa&password0@WheelsetInventoryStores.rpt=sa" &
            "&user0@DespatchedWheels.rpt=sa&password0@DespatchedWheels.rpt=sa" &
            "&user0@DespatchedAxles.rpt=sa&password0@DespatchedAxles.rpt=sa" &
            "&user0@DespatchedWheelSets.rpt=sa&password0@DespatchedWheelSets.rpt=sa"
        Response.Redirect(strPathName)
    End Sub

    Private Sub btnCWEA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCWEA.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=25526&user0=sa&password0=sadev123" &
            "&prompt0=DateTime(" & CStr(CDate(txtPHLDate.Text).Year) & "," & CStr(CDate(txtPHLDate.Text).Month) & "," & CStr(CDate(txtPHLDate.Text).Day) & ", 00, 00, 00)" &
            "&user0@RBTargets.rpt=sa&password0@RBTargets.rpt=sa" &
            "&user0@Summary.rpt=sa&password0@Summary.rpt=sa" &
            "&user0@mm_GMHeat.rpt=sa&password0@mm_GMHeat.rpt=sa" &
            "&user0@AxleShopNumbersUnits.rpt=sa&password0@AxleShopNumbersUnits.rpt=sa" &
            "&user0@WheelSets.rpt=sa&password0@WheelSets.rpt=sa" &
            "&user0@Breakdowns.rpt=sa&password0@Breakdowns.rpt=sa" &
            "&user0@WheelsAvailable=report&password0@WheelsAvailable=report" &
            "&user0@DmWhlsAsPerSSE=report&password0@DmWhlsAsPerSSE=report" &
            "&user0@AMSLooseAxlesAvailable.rpt=sa&password0@AMSLooseAxlesAvailable.rpt=sa" &
            "&user0@WheelsetInventory.rpt=sa&password0@WheelsetInventory.rpt=sa" &
            "&user0@WheelsetInventoryStores.rpt=sa&password0@WheelsetInventoryStores.rpt=sa" &
            "&user0@DespatchedWheels.rpt=sa&password0@DespatchedWheels.rpt=sa" &
            "&user0@DespatchedAxles.rpt=sa&password0@DespatchedAxles.rpt=sa" &
            "&user0@DespatchedWheelSets.rpt=sa&password0@DespatchedWheelSets.rpt=sa"
        Response.Redirect(strPathName)
    End Sub

    Private Sub btnMag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMag.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=27474&user0=sa&password0=sadev123" &
            "&prompt0=DateTime(" & CStr(CDate(txtPHLDate.Text).Year) & "," & CStr(CDate(txtPHLDate.Text).Month) & "," & CStr(CDate(txtPHLDate.Text).Day) & ", 00, 00, 00)&prompt1=0" &
            "&user0@Sub.rpt=sa&password0@Sub.rpt=sa"
        Response.Redirect(strPathName)
    End Sub

    Private Sub btnPCOQry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPCOQry.Click
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            DataGrid1.DataSource = PCO.tables.SetInventory(CDate(txtFromDate.Text), CDate(txtToDate.Text), rblPCO.SelectedItem.Value)
            DataGrid1.DataBind()
        Catch exp As Exception
            lblmessage.Text = exp.Message
        Finally
        End Try
    End Sub

    'Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
    '    DataGrid1.DataSource = Nothing 'txtPHLDate
    '    DataGrid1.DataBind()
    '    Try
    '        DataGrid1.DataSource = PCO.tables.NewProductionGlanceData(CDate(txtPHLDate.Text))
    '        DataGrid1.DataBind()
    '        lblmessage.Text = "Generated Data for New  Production at Glance for " & CDate(txtPHLDate.Text)
    '    Catch exp As Exception
    '        lblmessage.Text = exp.Message
    '    Finally
    '    End Try
    'End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=25547&user0=sa&password0=sadev123" &
            "&prompt0=DateTime(" & CStr(CDate(txtPHLDate.Text).Year) & "," & CStr(CDate(txtPHLDate.Text).Month) & "," & CStr(CDate(txtPHLDate.Text).Day) & ", 00, 00, 00)"
        Response.Redirect(strPathName)
    End Sub
End Class
