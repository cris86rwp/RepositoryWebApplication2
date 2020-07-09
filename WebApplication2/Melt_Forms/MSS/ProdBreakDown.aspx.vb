Public Class ProdBreakDown
    Inherits System.Web.UI.Page
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents txtBrDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtLoss As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnUpdate As System.Web.UI.WebControls.Button
    Protected WithEvents txtMemoSlipNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMemoNo As System.Web.UI.WebControls.Label
    Protected WithEvents lblSlipNo As System.Web.UI.WebControls.Label
    Protected WithEvents rblAff As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnRem As System.Web.UI.WebControls.Button
    Protected WithEvents txtHeatRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtHeatNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents pnlOff As System.Web.UI.WebControls.Panel
    Protected WithEvents Panel2 As System.Web.UI.WebControls.Panel
    Protected WithEvents lblMess As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
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
        lblMemoNo.Visible = False
        lblSlipNo.Visible = False
        If IsPostBack = False Then
            lblMemoNo.Text = ""
            lblSlipNo.Text = ""
            Try
                txtBrDate.Text = ProductionConsumables.GetTopBrDate
                txtHeatNo.Text = ProductionConsumables.GetTopOffHeat
                txtHeatRemarks.Text = ProductionConsumables.GetOffHeatRemarks(Val(txtHeatNo.Text))
                BrDownMemoEdit()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub BrDownMemoEdit()
        DataGrid1.SelectedIndex = -1
        Try
            Dim dt As DataTable = ProductionConsumables.BrDownMemoEdit(CDate(txtBrDate.Text))
            DataGrid1.DataSource = dt
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtBrDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBrDate.TextChanged
        lblMessage.Text = ""
        lblMemoNo.Text = ""
        lblSlipNo.Text = ""
        txtMemoSlipNo.Text = ""
        rblAff.SelectedIndex = -1
        Try
            BrDownMemoEdit()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub DataGrid1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.ItemCommand
        lblMessage.Text = ""
        lblMemoNo.Text = ""
        lblSlipNo.Text = ""
        Try
            Select Case e.CommandName
                Case "Select"
                    txtLoss.Text = e.Item.Cells(12).Text.Replace("&nbsp;", "").Trim
                    txtMemoSlipNo.Text = e.Item.Cells(5).Text.Replace("&nbsp;", "").Trim
                    lblSlipNo.Text = e.Item.Cells(5).Text.Replace("&nbsp;", "").Trim
                    lblMemoNo.Text = e.Item.Cells(4).Text.Replace("&nbsp;", "").Trim
                    Dim i As Int16 = 0
                    For i = 0 To rblAff.Items.Count - 1
                        If rblAff.Items(i).Text = e.Item.Cells(13).Text.Replace("&nbsp;", "").Trim Then
                            rblAff.Items(i).Selected = True
                            Exit For
                        End If
                    Next
            End Select
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        lblMessage.Text = ""
        If CInt(lblMemoNo.Text) = 0 Then
            lblMessage.Text = "InValid Memo No !"
            Exit Sub
        End If
        'If CInt(txtLoss.Text) = 0 Then
        '    lblMessage.Text = "InValid Time Loss !"
        '    Exit Sub
        'End If
        Dim Done As Boolean
        Try
            Done = New ProductionConsumables().UpdateBreakDown(Val(lblMemoNo.Text), txtMemoSlipNo.Text.Trim, Val(txtLoss.Text), lblSlipNo.Text.Trim, rblAff.SelectedItem.Value)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If Done Then
            Try
                BrDownMemoEdit()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            lblMessage.Text = " Data Updated ! " & lblMessage.Text
            lblMemoNo.Text = ""
            lblSlipNo.Text = ""
            txtMemoSlipNo.Text = ""
            rblAff.SelectedIndex = -1
        Else
            lblMessage.Text = " Data Updation Failed ! " & lblMessage.Text
        End If
    End Sub

    Private Sub txtHeatNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHeatNo.TextChanged
        lblMessage.Text = ""
        Try
            txtHeatRemarks.Text = ProductionConsumables.GetOffHeatRemarks(Val(txtHeatNo.Text))
        Catch exp As Exception
            txtHeatNo.Text = ""
            txtHeatRemarks.Text = ""
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnRem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRem.Click
        lblMessage.Text = ""
        If Val(txtHeatNo.Text) = 0 Then
            lblMessage.Text = "InValid HeatNo !"
            Exit Sub
        End If
        Dim Done As Boolean
        Try
            Done = New ProductionConsumables().UpdateOffheatRemarks(Val(txtHeatNo.Text), txtHeatRemarks.Text.Trim)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If Done Then
            lblMessage.Text = " Data Updated !"
            txtHeatNo.Text = ""
            txtHeatRemarks.Text = ""
        Else
            lblMessage.Text = " Data Updation Failed ! " & lblMessage.Text
        End If
    End Sub
End Class
