Public Class ProdConsumableCB
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblConsignee As System.Web.UI.WebControls.Label
    Protected WithEvents lblPLDescr As System.Web.UI.WebControls.Label
    Protected WithEvents ddlPLs As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents txtCB As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCBasOn As System.Web.UI.WebControls.TextBox
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents chkCum As System.Web.UI.WebControls.CheckBox
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
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
            'UserId = "111111"
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
                    GetPLCB()
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                End Try
            End If
        'End If
    End Sub

    Private Sub GetPLs()
        Dim dt1 As DataTable
        dt1 = ProductionConsumables.GetConsumablePLs(lblConsignee.Text.Trim)
        ddlPLs.DataSource = dt1
        ddlPLs.DataTextField = dt1.Columns(0).ColumnName
        ddlPLs.DataValueField = dt1.Columns(1).ColumnName
        ddlPLs.DataBind()
        ddlPLs.SelectedIndex = 0
        lblPLDescr.Text = ddlPLs.SelectedItem.Value
        dt1 = Nothing
    End Sub

    Private Sub GetPLCB()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        Try
            DataGrid2.DataSource = ProductionConsumables.GetPLCB(lblConsignee.Text, CDate(txtCBasOn.Text), ddlPLs.SelectedItem.Text, Val(txtCB.Text))
            DataGrid2.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub ddlPLs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlPLs.SelectedIndexChanged
        lblMessage.Text = ""
        lblPLDescr.Text = ddlPLs.SelectedItem.Value
        GetPLsDetails()
        GetPLCB()
    End Sub

    Private Sub GetPLsDetails()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            Dim dt1 As DataTable
            dt1 = ProductionConsumables.GetConsumablePLCB(lblConsignee.Text, ddlPLs.SelectedItem.Text)
            txtCBasOn.Text = IIf(IsDBNull(dt1.Rows(0)(1)), Now.Date, dt1.Rows(0)(1))
            txtCB.Text = IIf(IsDBNull(dt1.Rows(0)(2)), "", dt1.Rows(0)(2))
            txtRemarks.Text = IIf(IsDBNull(dt1.Rows(0)(3)), "", dt1.Rows(0)(3))
            DataGrid1.DataSource = ProductionConsumables.GetConsumablePLsCB(lblConsignee.Text, CDate(txtCBasOn.Text))
            DataGrid1.DataBind()
            dt1 = Nothing
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        If chkCum.Checked Then
            If DataGrid2.Items.Count = 0 Then
                lblMessage.Text = "Data cannot be saved without PL details !"
                Exit Sub
            End If
        End If
        Dim Done As Boolean
        Try
            Done = New ProductionConsumables().SavePLCB(lblConsignee.Text, ddlPLs.SelectedItem.Text, CDate(txtCBasOn.Text), Val(txtCB.Text), txtRemarks.Text.Trim, chkCum.Checked)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If Done Then
            Try
                GetPLsDetails()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            lblMessage.Text = " Data Saved ! " & lblMessage.Text
        End If
    End Sub

    Private Sub txtCBasOn_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCBasOn.TextChanged
        lblMessage.Text = ""
        Try
            GetPLCB()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtCB_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCB.TextChanged
        lblMessage.Text = ""
        Try
            GetPLCB()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
End Class
