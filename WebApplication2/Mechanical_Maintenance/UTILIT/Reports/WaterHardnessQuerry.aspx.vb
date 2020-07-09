Public Class WaterHardnessQuerry
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblSofteningHrs As System.Web.UI.WebControls.Label
    Protected WithEvents lblSoft_Qty As System.Web.UI.WebControls.Label
    Protected WithEvents lblByPass_Qty As System.Web.UI.WebControls.Label
    Protected WithEvents lblTotal_Qty As System.Web.UI.WebControls.Label
    Protected WithEvents chkRefersh As System.Web.UI.WebControls.CheckBox
    Protected WithEvents Panel2 As System.Web.UI.WebControls.Panel
    Protected WithEvents CustomValidator1 As System.Web.UI.WebControls.CustomValidator
    Protected WithEvents btnPoNo As System.Web.UI.WebControls.Button
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtToDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFromDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
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
    Private Sub GetData(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged, MyBase.Load, chkRefersh.CheckedChanged
        If IsPostBack = False Then
            txtDate.Text = Now.Date
            Notvalid = False
            txtFromDate.Text = Now.Date
            txtToDate.Text = Now.Date
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

            If dt1 > dt2 Then
                lblMessage.Text &= " From  Date is more than To  Date ! (From  Date:" & txtFromDate.Text & " To  Date: " & txtToDate.Text & "). "
                txtFromDate.Text = ""
                txtToDate.Text = ""
            End If

        Catch exp As Exception
            If exp.Message.StartsWith("Cast") Then
                If dt1IsValid = False Then
                    lblMessage.Text &= " From  Date:'" & txtFromDate.Text.Trim & "'  is not Valid. "
                    txtFromDate.Text = ""
                ElseIf dt2IsValid = False Then
                    lblMessage.Text &= " To  Date:'" & txtToDate.Text.Trim & "'  is not Valid. "
                    txtToDate.Text = ""
                End If
            End If
        End Try
        If txtFromDate.Text = "" Or txtToDate.Text = "" Then
            Notvalid = True
        End If
    End Sub
    Private Sub btnPoNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPoNo.Click
        lblMessage.Text = ""
        Try
            GetHardNessData()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        lblMessage.Text = ""
        Try
            GetData()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub GetHardNessData()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        Dim dt As DataTable
        Try
            dt = UtilityShop.DataTables.WaterHardnessDetails(CDate(txtFromDate.Text), CDate(txtToDate.Text))
            If dt.Rows.Count > 0 Then
                DataGrid2.DataSource = dt.DefaultView
                DataGrid2.DataBind()
            Else
                lblMessage.Text &= "No Data for the given date !"
            End If
        Catch exp As Exception
            lblMessage.Text &= " ; Data Grid Filling Failed "
        Finally
            dt.Dispose()
        End Try
    End Sub
    Private Sub GetData()
        lblSofteningHrs.Text = ""
        lblSoft_Qty.Text = ""
        lblByPass_Qty.Text = ""
        lblTotal_Qty.Text = ""
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        If txtDate.Text = "" Then
            Exit Sub
        End If
        lblMessage.Text = ""
        Try
            If CDate(txtDate.Text) > Now.Date Then
                lblMessage.Text = "Date cannot be greater than Today !"
                txtDate.Text = ""
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If txtDate.Text = "" Then
            Exit Sub
        End If
        Dim dt As DataTable
        Try
            dt = UtilityShop.DataTables.WaterHardness(CDate(txtDate.Text))
            If dt.Rows.Count > 0 Then
                DataGrid1.DataSource = dt.DefaultView
                DataGrid1.DataBind()
                lblSofteningHrs.Text = IIf(IsDBNull(dt.Rows(0)("SofteningHrs")), "", dt.Rows(0)("SofteningHrs"))
                lblSoft_Qty.Text = IIf(IsDBNull(dt.Rows(0)("Soft_Qty")), "", dt.Rows(0)("Soft_Qty"))
                lblByPass_Qty.Text = IIf(IsDBNull(dt.Rows(0)("ByPass_Qty")), "", dt.Rows(0)("ByPass_Qty"))
                lblTotal_Qty.Text = IIf(IsDBNull(dt.Rows(0)("Total_Qty")), "", dt.Rows(0)("Total_Qty"))
            Else
                lblMessage.Text &= "No Data for the given date !"
            End If
        Catch exp As Exception
            lblMessage.Text &= " ; Data Grid Filling Failed "
        Finally
            dt.Dispose()
        End Try
    End Sub

    Private Sub chkRefersh_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRefersh.CheckedChanged
        lblMessage.Text = ""
        Try
            GetData()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
End Class
