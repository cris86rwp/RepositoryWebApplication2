Public Class InspectionCertificateWAS
    Inherits System.Web.UI.Page
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents ddlProductCode As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlWagon As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtDCNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnReport As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList



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
        If IsPostBack = True Then
            btnReport.Text = "Show " & rblType.SelectedItem.Text & "  QAC Report"
        End If
    End Sub

    Private Sub txtDCNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDCNumber.TextChanged
        lblMessage.Text = ""
        txtDCNumber.Text = txtDCNumber.Text.ToUpper
        If rblType.SelectedItem.Value = "A" Then
            If Not txtDCNumber.Text.StartsWith("A") Then
                lblMessage.Text = "DC Number Should start with 'A' for Loose Axles"
                txtDCNumber.Text = ""
                Exit Sub
            End If
        End If
        If rblType.SelectedItem.Value = "W" Then
            If Not txtDCNumber.Text.StartsWith("W") Then
                lblMessage.Text = "DC Number Should start with 'W' for Loose Wheels"
                txtDCNumber.Text = ""
                Exit Sub
            End If
        End If
        If rblType.SelectedItem.Value = "S" Then
            If Not txtDCNumber.Text.StartsWith("S") Then
                lblMessage.Text = "DC Number Should start with 'S' for WheelSets"
                txtDCNumber.Text = ""
                Exit Sub
            End If
        End If
        SetDDLs()
    End Sub

    Private Sub rblType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblType.SelectedIndexChanged
        lblMessage.Text = ""
        txtDCNumber.Text = ""
        btnReport.Text = "Show " & rblType.SelectedItem.Text & "  QAC Report"
        ddlProductCode.Items.Clear()
        ddlWagon.Items.Clear()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
    End Sub

    Private Sub SetDDLs()
        ddlProductCode.DataSource = Nothing
        ddlProductCode.DataBind()
        ddlWagon.DataSource = Nothing
        ddlWagon.DataBind()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Dim ds As DataSet
        Try
            ds = RWF.CLRINS.DCDetails(txtDCNumber.Text.Trim)
            If ds.Tables(0).Rows.Count > 0 Then
                ddlWagon.DataSource = ds.Tables(0)
                ddlWagon.DataTextField = ds.Tables(0).Columns("wagon_lorry_number").ColumnName
                ddlWagon.DataValueField = ds.Tables(0).Columns("wagon_lorry_number").ColumnName
                ddlWagon.DataBind()
                If rblType.SelectedItem.Value = "S" Then
                    If txtDCNumber.Text.StartsWith("S") Then
                        populateProductList()
                    End If
                Else
                    ddlProductCode.DataSource = ds.Tables(1)
                    ddlProductCode.DataTextField = ds.Tables(1).Columns("product_code").ColumnName
                    ddlProductCode.DataValueField = ds.Tables(1).Columns("product_code").ColumnName
                    ddlProductCode.DataBind()
                End If
                DataGrid1.DataSource = ds.Tables(2)
                DataGrid1.DataBind()
            Else
                Throw New Exception("InValid DC Number")
            End If
        Catch exp As Exception
            txtDCNumber.Text = ""
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub populateProductList()
        ddlProductCode.Items.Clear()
        If ddlWagon.Items.Count <> 0 Then
            If ddlWagon.SelectedItem.Text <> "" Then
                Dim dt As DataTable
                dt = AxleProcessing.CLRINS.ProductNumbers(txtDCNumber.Text.Trim, ddlWagon.SelectedItem.Text.Trim)
                ddlProductCode.DataSource = dt
                ddlProductCode.DataTextField = dt.Columns("ReportType").ColumnName
                ddlProductCode.DataValueField = dt.Columns("product_code").ColumnName
                ddlProductCode.DataBind()
                dt = Nothing
            End If
        End If
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim strPathName As String
        If txtDCNumber.Text.Trim.Length = 0 Then
            lblMessage.Text = "InValid DC Number!"
            Exit Sub
        End If
        If rblType.SelectedItem.Value = "W" Then
            If txtDCNumber.Text.StartsWith("W") Then
                strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=26764&user0=sa&password0=sadev123" &
                     "&prompt0=" & txtDCNumber.Text.Trim & "" &
                     "&prompt1=" & ddlWagon.SelectedItem.Text.Trim & "" &
                     "&prompt2=" & ddlProductCode.SelectedItem.Text.Trim & ""
            End If
        ElseIf rblType.SelectedItem.Value = "A" Then
            If txtDCNumber.Text.StartsWith("A") Then
                strPathName = "http://" & rwfGen.ReportServer.ServerName & "" &
                    "/mmsreports/clrins/formats/AxleQAC_New.rpt?user0=report&password0=report&promptonrefresh=0" &
                    "&prompt0=" & txtDCNumber.Text.Trim & "" &
                    "&prompt1=" & ddlWagon.SelectedItem.Text.Trim & "" &
                    "&prompt2=" & ddlProductCode.SelectedItem.Text.Trim & ""
            End If
        ElseIf rblType.SelectedItem.Value = "S" Then
            If txtDCNumber.Text.StartsWith("S") Then
                If ddlProductCode.SelectedItem.Text.Substring(ddlProductCode.SelectedItem.Text.LastIndexOfAny("_") + 1, 3).StartsWith("RWF") Then
                    strPathName = "http://" & rwfGen.ReportServer.ServerName & "" &
                                        "/mmsreports/clrins/formats/RWFWheelRWFAxleWheelSets.rpt?user0=report&password0=report&promptonrefresh=0" &
                                        "&prompt0=" & txtDCNumber.Text.Trim & "&prompt1=" & ddlWagon.SelectedItem.Text.Trim & "&prompt2=" & ddlProductCode.SelectedItem.Value.ToString.Trim
                Else
                    strPathName = "http://" & rwfGen.ReportServer.ServerName & "" &
                        "/mmsreports/clrins/formats/RWFWheelNonRWFAxleWheelSets.rpt?user0=report&password0=report&promptonrefresh=0" &
                        "&prompt0=" & txtDCNumber.Text.Trim & "&prompt1=" & ddlWagon.SelectedItem.Text.Trim & "&prompt2=" & ddlProductCode.SelectedItem.Value.ToString.Trim
                End If
            End If
        End If
        Response.Redirect(strPathName)
    End Sub

    Private Sub ddlWagon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlWagon.SelectedIndexChanged
        If rblType.SelectedItem.Value = "S" Then
            If txtDCNumber.Text.StartsWith("S") Then
                populateProductList()
            End If
        End If
    End Sub
End Class
