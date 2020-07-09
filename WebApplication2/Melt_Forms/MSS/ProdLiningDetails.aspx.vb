Public Class ProdLiningDetails
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents pnlMain As System.Web.UI.WebControls.Panel
    Protected WithEvents rblItemName As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblItems As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents pnl1 As System.Web.UI.WebControls.Panel
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents txtFirstHeatNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLastHeatNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents pnl2 As System.Web.UI.WebControls.Panel
    Protected WithEvents txtBottom As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSideWall As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
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
            ''''''''''''''''
            'Session("Group") = "SSMELT"
            'Session("UserID") = "074510"
            'Group = "SSMELT"
            'UserId = "074510"

            'If Not (Group = "SSMELT" AndAlso UserId = "074510") Then
            '    Response.Redirect("/mss/logon.aspx")
            'End If
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
            Try
                    SetType()
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                End Try
            End If
        'End If
    End Sub

    Private Sub SetType()
        lblMessage.Text = ""
        txtBottom.Text = ""
        txtSideWall.Text = ""
        txtRemarks.Text = ""
        pnl1.Visible = False
        pnl2.Visible = False
        Dim dt As DataTable
        Try
            dt = ProductionConsumables.GetItems(rblItemName.SelectedItem.Value, rblType.SelectedItem.Value)
            rblItems.DataSource = dt
            rblItems.DataTextField = dt.Columns(0).ColumnName
            rblItems.DataValueField = dt.Columns(0).ColumnName
            rblItems.DataBind()
            rblItems.SelectedIndex = 0
            GetLiningDetails()
            If rblType.SelectedItem.Value = 1 Then
                pnl1.Visible = True
                btnSave.Text = "Update"
            ElseIf rblType.SelectedItem.Value = 2 Then
                pnl2.Visible = True
                btnSave.Text = rblType.SelectedItem.Text
            ElseIf rblType.SelectedItem.Value = 3 Then
                lblMessage.Text = "Only the Latest LiningNo will be Allowed to Deleted !"
                btnSave.Text = "Delete"
            ElseIf rblType.SelectedItem.Value = 4 Then
                pnl1.Visible = True
                btnSave.Text = "Update First Heat No"
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt = Nothing
        End Try
    End Sub

    Private Sub GetLiningDetails()
        Dim ds As DataSet
        ds = ProductionConsumables.GetFurnaceLiningDetails(rblItemName.SelectedItem.Value, rblItems.SelectedItem.Value)
        DataGrid1.DataSource = ds.Tables(0)
        DataGrid1.DataBind()
        txtFirstHeatNo.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)(1)), 0, ds.Tables(0).Rows(0)(1))
        txtLastHeatNo.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)(2)), 0, ds.Tables(0).Rows(0)(2))
    End Sub

    Private Sub rblItemName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblItemName.SelectedIndexChanged
        Try
            SetType()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub rblType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblType.SelectedIndexChanged
        Try
            SetType()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        Dim done As Boolean
        Try
            If rblType.SelectedItem.Value = 3 Then
                done = New ProductionConsumables().SaveLiningDetails(rblItemName.SelectedItem.Value, rblType.SelectedItem.Value, rblItems.SelectedItem.Text, Val(txtFirstHeatNo.Text), Val(txtLastHeatNo.Text), txtBottom.Text.Trim, txtSideWall.Text.Trim, txtRemarks.Text.Trim, True)
            Else
                done = New ProductionConsumables().SaveLiningDetails(rblItemName.SelectedItem.Value, rblType.SelectedItem.Value, rblItems.SelectedItem.Text, Val(txtFirstHeatNo.Text), Val(txtLastHeatNo.Text), txtBottom.Text.Trim, txtSideWall.Text.Trim, txtRemarks.Text.Trim)
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If done Then
            Try
                SetType()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            lblMessage.Text &= " Data Saved !"
        Else
            lblMessage.Text &= " Data Not Saved !"
        End If
    End Sub



    Private Sub rblItems_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblItems.SelectedIndexChanged
        Try
            GetLiningDetails()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
End Class
