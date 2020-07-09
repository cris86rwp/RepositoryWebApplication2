Public Class ProdConsumables
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents ddlPLs As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblPLDescr As System.Web.UI.WebControls.Label
    Protected WithEvents txtAdvisedNorm As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPerUnit As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtPerDay As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtShelfLife As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLifeUnit As System.Web.UI.WebControls.TextBox
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


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        'Put user code to initialize the page here
        If IsPostBack = False Then
            Dim Group As String = Session("Group")
            Dim UserId As String = Session("UserID")
            Dim InValid As Boolean = False
            ''''''''''''''''
            'Group = "SSMELT"
            'UserId = "074510"
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
                    GetPLs()
                    GetPLsDetails()
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                End Try
            End If
        'End If
    End Sub

    Private Sub GetPLs()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Dim dt1 As DataTable
        dt1 = ProductionConsumables.GetConsumablePLs(lblConsignee.Text.Trim)
        ddlPLs.DataSource = dt1
        ddlPLs.DataTextField = dt1.Columns(0).ColumnName
        ddlPLs.DataValueField = dt1.Columns(1).ColumnName
        ddlPLs.DataBind()
        ddlPLs.SelectedIndex = 0
        lblPLDescr.Text = ddlPLs.SelectedItem.Value
        DataGrid1.DataSource = dt1
        DataGrid1.DataBind()
        dt1 = Nothing
    End Sub

    Private Sub GetPLsDetails()
        Try
            Dim dt1 As DataTable
            dt1 = ProductionConsumables.GetConsumablePLsDetails(lblConsignee.Text.Trim, ddlPLs.SelectedItem.Text)
            txtAdvisedNorm.Text = IIf(IsDBNull(dt1.Rows(0)(2)), "", dt1.Rows(0)(2))
            txtPerUnit.Text = IIf(IsDBNull(dt1.Rows(0)(3)), "", dt1.Rows(0)(3))
            txtPerDay.Text = IIf(IsDBNull(dt1.Rows(0)(5)), "", dt1.Rows(0)(5))
            txtShelfLife.Text = IIf(IsDBNull(dt1.Rows(0)(6)), 0, dt1.Rows(0)(6))
            txtLifeUnit.Text = IIf(IsDBNull(dt1.Rows(0)(7)), "", dt1.Rows(0)(7))
            dt1 = Nothing
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub ddlPLs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlPLs.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            lblPLDescr.Text = ddlPLs.SelectedItem.Value
            GetPLsDetails()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        Dim Done As Boolean
        Try
            Done = New ProductionConsumables().SavePLDetails(lblConsignee.Text, ddlPLs.SelectedItem.Text, Val(txtAdvisedNorm.Text), txtPerUnit.Text.Trim, Val(txtPerDay.Text), Val(txtShelfLife.Text), txtLifeUnit.Text.Trim)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If Done Then
            Try
                GetPLs()
                GetPLsDetails()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            lblMessage.Text = " Data Saved ! " & lblMessage.Text
        End If
    End Sub

    Protected Sub DataGrid1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DataGrid1.SelectedIndexChanged

    End Sub
End Class
