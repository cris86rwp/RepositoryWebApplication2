Public Class RoofFixing
    Inherits System.Web.UI.Page
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents rblRoofNo As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblFur As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtFromHeatNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtToHeatNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblReason As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents pnlRoof As System.Web.UI.WebControls.Panel
    Protected WithEvents rblType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents pnlCon As System.Web.UI.WebControls.Panel
    Protected WithEvents txtContractNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnCon As System.Web.UI.WebControls.Button
    Protected WithEvents txtQty As System.Web.UI.WebControls.TextBox
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


    Protected Sub Dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put User code to initialize the page here
        'If IsPostBack = False Then
        '    SetType()
        'End If
    End Sub

    Private Sub SetType()

        txtContractNo.Text = ""
        txtQty.Text = ""
        pnlRoof.Visible = False
        pnlCon.Visible = False
        If rblType.SelectedIndex = 0 Then
            pnlRoof.Visible = True
        Else
            pnlCon.Visible = True
        End If
    End Sub

    Private Sub rblRoofNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblRoofNo.SelectedIndexChanged
        lblMessage.Text = ""
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        DataGrid1.SelectedIndex = -1
        Try
            DataGrid1.DataSource = RWF.Melting.RoofFixingList(rblRoofNo.SelectedItem.Text)
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        Dim done As Boolean
        Try
            done = New RWF.Melting().SaveRoofFixingDetails(rblRoofNo.SelectedItem.Text, rblFur.SelectedItem.Text, (txtFromHeatNo.Text), Val(txtToHeatNo.Text), rblReason.SelectedItem.Text, txtRemarks.Text.Trim)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If done Then
            lblMessage.Text &= "Data Saved !"
            DataGrid1.DataSource = Nothing
            DataGrid1.DataBind()
            Try
                DataGrid1.DataSource = RWF.Melting.RoofFixingList(rblRoofNo.SelectedItem.Text)
                DataGrid1.DataBind()
            Catch exp As Exception
                lblMessage.Text &= exp.Message
            End Try
        Else
            lblMessage.Text &= "Data Savaing Failed !"
        End If
    End Sub

    Private Sub ClearVal()
        txtFromHeatNo.Text = 0
        txtToHeatNo.Text = 0
    End Sub

    Private Sub DataGrid1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.ItemCommand
        lblMessage.Text = ""
        ClearVal()
        Try
            Select Case e.CommandName
                Case "Select"
                    Dim i As Integer
                    For i = 0 To rblFur.Items.Count - 1
                        If rblFur.Items(i).Text = e.Item.Cells(2).Text.Trim Then
                            rblFur.Items(i).Selected = True
                            Exit For
                        End If
                    Next
                    txtFromHeatNo.Text = e.Item.Cells(3).Text.Trim.Replace("&nbsp;", "")
                    txtToHeatNo.Text = e.Item.Cells(4).Text.Trim.Replace("&nbsp;", "")
                    i = 0
                    For i = 0 To rblReason.Items.Count - 1
                        If rblReason.Items(i).Text = e.Item.Cells(5).Text.Trim Then
                            rblReason.Items(i).Selected = True
                            Exit For
                        End If
                    Next
                    txtRemarks.Text = e.Item.Cells(6).Text.Trim.Replace("&nbsp;", "")
            End Select
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub rblType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblType.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            SetType()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtContractNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtContractNo.TextChanged
        lblMessage.Text = ""
        Try
            GetContractDetails()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub GetContractDetails()
        lblMessage.Text = ""
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        Dim dt As DataTable
        Try
            dt = RWF.Melting.ContractDetails(txtContractNo.Text.Trim)
            DataGrid2.DataSource = dt
            DataGrid2.DataBind()
            If dt.Rows.Count > 0 Then
                txtQty.Text = IIf(IsDBNull(dt.Rows(0)(2)), 0, dt.Rows(0)(2))
            End If
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
    End Sub

    Private Sub btnCon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCon.Click
        lblMessage.Text = ""
        Dim done As Boolean
        Try
            done = New RWF.Melting().SaveContractNo(txtContractNo.Text.Trim, Val(txtQty.Text))
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If done Then
            lblMessage.Text &= "Data Saved !"
            DataGrid2.DataSource = Nothing
            DataGrid2.DataBind()
            Try
                DataGrid2.DataSource = RWF.Melting.ContractDetails(txtContractNo.Text.Trim)
                DataGrid2.DataBind()
            Catch exp As Exception
                lblMessage.Text &= exp.Message
            End Try
        Else
            lblMessage.Text &= "Data Savaing Failed !"
        End If
    End Sub

    Protected Sub rblFur_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblFur.SelectedIndexChanged
        Dim dt As DataTable
        Dim rbf As String
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        rbf = rblFur.SelectedItem.Text

        Try
            dt = RWF.Melting.RoofNos(rbf)
            rblRoofNo.DataSource = dt
            rblRoofNo.DataTextField = dt.Columns(0).ColumnName
            rblRoofNo.DataValueField = dt.Columns(0).ColumnName

            rblRoofNo.DataBind()
            rblRoofNo.SelectedIndex = 0
            DataGrid1.DataSource = RWF.Melting.RoofFixingList(rblRoofNo.SelectedItem.Text)
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        'txtContractNo.Text = ""
        'txtQty.Text = ""
        'pnlRoof.Visible = False
        'pnlCon.Visible = False
        'If rblType.SelectedIndex = 0 Then
        '    pnlRoof.Visible = True
        'Else
        '    pnlCon.Visible = True
        'End If
    End Sub
End Class
