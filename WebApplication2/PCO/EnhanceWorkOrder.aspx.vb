Public Class EnhanceWorkOrder
    Inherits System.Web.UI.Page
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents rblWO As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtRevisedQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnEnchance As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
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
        Session("UserID") = "078844"
        If IsPostBack = False Then
            Dim WorkingDate As Date = PCO.tables.WorkingDate
            If Now.Date = WorkingDate Then
                Try
                    GetWo()
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                End Try
            Else
                Response.Redirect("InvalidSession.aspx")
                Exit Sub
            End If
        End If
    End Sub

    Private Sub GetWo()
        rblWO.Items.Clear()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Dim dt As DataTable
        dt = PCO.tables.GetPreMonthWO
        If dt.Rows.Count > 0 Then
            rblWO.DataSource = dt
            rblWO.DataTextField = dt.Columns(0).ColumnName
            rblWO.DataValueField = dt.Columns(6).ColumnName
            rblWO.DataBind()
            rblWO.SelectedIndex = 0
            DataGrid1.DataSource = dt
            DataGrid1.DataBind()
        Else
            lblMessage.Text &= " No Workorders pending for enhancement ! "
        End If
    End Sub

    Private Sub btnEnchance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnchance.Click
        lblMessage.Text = ""
        If Val(txtRevisedQty.Text) = 0 Then
            lblMessage.Text = "InValid Revised Qty !"
            Exit Sub
        Else
            Try
                lblMessage.Text = New PCO.WorkOrder().UpdateWO(rblWO.SelectedItem.Text, Val(txtRevisedQty.Text))
                If lblMessage.Text.EndsWith("Successfully") Then
                    GetWo()
                End If
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub txtRevisedQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRevisedQty.TextChanged
        lblMessage.Text = ""
        If Not Val(txtRevisedQty.Text) > rblWO.SelectedItem.Value Then
            lblMessage.Text = "InValid Revised Qty !"
            txtRevisedQty.Text = ""
        End If
    End Sub
End Class
