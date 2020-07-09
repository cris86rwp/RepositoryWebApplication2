Public Class StockIDNStatusListDetails
    Inherits System.Web.UI.Page
    Protected WithEvents txtToDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFromDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlType As System.Web.UI.WebControls.DropDownList
    Protected WithEvents rblType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnDetails As System.Web.UI.WebControls.Button
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents btnShow As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblName As System.Web.UI.WebControls.Label
    Protected WithEvents txtPO As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSandPO As System.Web.UI.WebControls.Button
    Protected WithEvents btnDateDetails As System.Web.UI.WebControls.Button
    Protected WithEvents txtFr As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTo As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblPO As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnUsage As System.Web.UI.WebControls.Button
    Protected WithEvents rblNS As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblDetails As System.Web.UI.WebControls.RadioButtonList

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
        If IsPostBack = False Then
            txtFromDate.Text = "01/" + CStr(Now.Month) + "/" + CStr(Now.Year)
            txtToDate.Text = Now.Date
            btnShow.Text = "Show " + rblDetails.SelectedItem.Text
            btnDateDetails.Text = "Show " & rblNS.SelectedItem.Text
            btnSandPO.Text = "Show " & rblPO.SelectedItem.Text & "  of PO : " + txtPO.Text.Trim
            txtFr.Text = Now.Date
            txtTo.Text = Now.Date
            Try
                FillDDL("", IIf(rblType.SelectedIndex = 0, 1, 2))
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub FillDDL(ByVal Type As String, ByVal ID As Integer)
        Dim dt As DataTable
        lblName.Text = ""
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            dt = ProductionConsumables.GetStockIDNStatusListDetails(CDate(txtFromDate.Text), CDate(txtToDate.Text), Type, ID)
            If dt.Rows.Count > 0 Then
                ddlType.DataSource = dt
                ddlType.DataTextField = dt.Columns(0).ColumnName
                If rblType.SelectedIndex = 0 Then
                    ddlType.DataValueField = dt.Columns(0).ColumnName
                    ddlType.DataBind()
                Else
                    ddlType.DataValueField = dt.Columns(1).ColumnName
                    ddlType.DataBind()
                    lblName.Text = ddlType.SelectedItem.Value
                End If
                btnDetails.Text = "Show IDN " + rblType.SelectedItem.Text + " No " + ddlType.SelectedItem.Text + " Details "
                btnUsage.Text = "Show IDN " + rblType.SelectedItem.Text + " No " + ddlType.SelectedItem.Text + " Usage Details "
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt = Nothing
        End Try
    End Sub

    Private Sub txtFromDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFromDate.TextChanged
        lblMessage.Text = ""
        Try
            FillDDL("", IIf(rblType.SelectedIndex = 0, 1, 2))
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtToDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtToDate.TextChanged
        lblMessage.Text = ""
        Try
            FillDDL("", IIf(rblType.SelectedIndex = 0, 1, 2))
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub rblType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblType.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            FillDDL("", IIf(rblType.SelectedIndex = 0, 1, 2))
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub ddlType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlType.SelectedIndexChanged
        lblMessage.Text = ""
        If rblType.SelectedIndex > 0 Then
            lblName.Text = ddlType.SelectedItem.Value
        End If
        btnDetails.Text = "Show IDN " + rblType.SelectedItem.Text + " No " + ddlType.SelectedItem.Text + " Details "
        btnUsage.Text = "Show IDN " + rblType.SelectedItem.Text + " No " + ddlType.SelectedItem.Text + " Usage Details "
    End Sub

    Private Sub btnDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        lblMessage.Text = ""
        FillGrid(True)
    End Sub

    Private Sub FillGrid(ByVal Details As Boolean)
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Dim dt As DataTable
        Try
            If Details Then
                dt = ProductionConsumables.GetStockIDNStatusListDetails(CDate(txtFromDate.Text), CDate(txtToDate.Text), ddlType.SelectedItem.Text, IIf(rblType.SelectedItem.Value = 1, 3, 4))
            Else
                dt = ProductionConsumables.GetStockIDNStatusListDetails(CDate(txtFromDate.Text), CDate(txtToDate.Text), ddlType.SelectedItem.Text, IIf(rblType.SelectedItem.Value = 1, 11, 12))
            End If
            If dt.Rows.Count > 0 Then
                DataGrid1.DataSource = dt
                DataGrid1.DataBind()
            Else
                lblMessage.Text = "No Data for the selection made !"
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt = Nothing
        End Try

    End Sub
    Private Sub rblDetails_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblDetails.SelectedIndexChanged
        lblMessage.Text = ""
        btnShow.Text = "Show " + rblDetails.SelectedItem.Text
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        lblMessage.Text = ""
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Dim dt As DataTable
        Try
            dt = ProductionConsumables.GetStockIDNStatusListDetails(CDate(txtFromDate.Text), CDate(txtToDate.Text), "", rblDetails.SelectedItem.Value)
            If dt.Rows.Count > 0 Then
                DataGrid1.DataSource = dt
                DataGrid1.DataBind()
            Else
                lblMessage.Text = "No Data for the selection made !"
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt = Nothing
        End Try
    End Sub

    Private Sub txtPO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPO.TextChanged
        lblMessage.Text = ""
        btnSandPO.Text = "Show " & rblPO.SelectedItem.Text & "  of PO : " + txtPO.Text.Trim
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
    End Sub

    Private Sub btnSandPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSandPO.Click
        lblMessage.Text = ""
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Dim dt As DataTable
        Try
            dt = ProductionConsumables.GetStockIDNStatusListDetails(CDate(txtFromDate.Text), CDate(txtToDate.Text), txtPO.Text.Trim, rblPO.SelectedItem.Value)
            If dt.Rows.Count > 0 Then
                DataGrid1.DataSource = dt
                DataGrid1.DataBind()
            Else
                lblMessage.Text = "No Data for the selection made !"
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt = Nothing
        End Try
    End Sub

    Private Sub btnDateDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDateDetails.Click
        lblMessage.Text = ""
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Dim dt As DataTable
        Try
            dt = ProductionConsumables.GetStockIDNStatusListDetails(CDate(txtFr.Text), CDate(txtTo.Text), "", rblNS.SelectedItem.Value)
            If dt.Rows.Count > 0 Then
                DataGrid1.DataSource = dt
                DataGrid1.DataBind()
            Else
                lblMessage.Text = "No Data for the selection made !"
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt = Nothing
        End Try
    End Sub

    Private Sub rblPO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblPO.SelectedIndexChanged
        btnSandPO.Text = "Show " & rblPO.SelectedItem.Text & "  of PO : " + txtPO.Text.Trim
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
    End Sub

    Private Sub btnUsage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUsage.Click
        lblMessage.Text = ""
        FillGrid(False)
    End Sub

    Private Sub rblNS_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblNS.SelectedIndexChanged
        btnDateDetails.Text = "Show " & rblNS.SelectedItem.Text
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
    End Sub
End Class
