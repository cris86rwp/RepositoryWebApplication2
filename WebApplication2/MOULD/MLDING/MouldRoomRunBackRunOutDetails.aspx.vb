Public Class MouldRoomRunBackRunOutDetails
    Inherits System.Web.UI.Page
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblPO As System.Web.UI.WebControls.Label
    Protected WithEvents lblHeat As System.Web.UI.WebControls.Label
    Protected WithEvents lblWheel As System.Web.UI.WebControls.Label
    Protected WithEvents txtPourOperator As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPlungerPr As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCentringRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblCope As System.Web.UI.WebControls.Label
    Protected WithEvents txtCTCOperator As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblDD As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtPipeCondition As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblDrag As System.Web.UI.WebControls.Label
    Protected WithEvents txtDTOperator As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents dgXCWheels As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgSavedWheels As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblStatus As System.Web.UI.WebControls.Label
    Protected WithEvents txtCloseDownRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSeatingRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTubeSinkRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPrgCraneRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCopeConditionRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDragConditionRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    'new
    Protected WithEvents txtIngateReamerOperator As System.Web.UI.WebControls.TextBox
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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        'Put user code to initialize the page here
        Session("UserID") = "016002"
        Session("Group") = "MLDING"
        If Page.IsPostBack = False Then
            txtDate.Text = Now.Date
        End If
    End Sub

    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        'lblMessage.Text = "87420"

        Dim dt As Date
        Try
            dt = CDate(txtDate.Text)
            txtDate.Text = dt
            GetWheels()
            FillGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub GetWheels()
        dgXCWheels.DataSource = Nothing
        dgXCWheels.DataBind()
        Dim dt As New DataTable()
        Try
            dt = RWF.MLDING.MouldXCWheels(CDate(txtDate.Text))
            dgXCWheels.DataSource = dt
            dgXCWheels.DataBind()
        Catch exp As Exception
            dgXCWheels.DataSource = Nothing
            dgXCWheels.DataBind()
            Throw New Exception(exp.Message)
        Finally
            dt.Dispose()
        End Try
    End Sub

    Private Sub FillGrid()
        dgSavedWheels.DataSource = Nothing
        dgSavedWheels.DataBind()
        Dim dt As New DataTable()
        Try
            dt = RWF.MLDING.MRRunBackWheels(CDate(txtDate.Text))
            dgSavedWheels.DataSource = dt
            dgSavedWheels.DataBind()
        Catch exp As Exception
            lblMessage.Text = "Data Grid Filling Failed : " & exp.Message
        Finally
            dt.Dispose()
        End Try
    End Sub

    Private Sub dgXCWheels_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgXCWheels.ItemCommand
        lblMessage.Text = ""
        Try
            Select Case e.CommandName
                Case "Select"
                    lblHeat.Text = e.Item.Cells(1).Text
                    lblWheel.Text = e.Item.Cells(2).Text
                    lblStatus.Text = e.Item.Cells(3).Text
                    lblPO.Text = e.Item.Cells(4).Text
                    txtPourOperator.Text = e.Item.Cells(5).Text.Replace("&nbsp;", "")
                    txtPlungerPr.Text = e.Item.Cells(6).Text.Replace("&nbsp;", "")
                    txtCentringRemarks.Text = e.Item.Cells(7).Text.Replace("&nbsp;", "")
                    txtCTCOperator.Text = e.Item.Cells(8).Text.Replace("&nbsp;", "")
                    Dim i As Integer
                    If Not e.Item.Cells(9).Text Is Nothing Then
                        For i = 0 To rblDD.Items.Count - 1
                            If rblDD.Items(i).Value = e.Item.Cells(9).Text Then
                                rblDD.SelectedIndex = i
                                Exit For
                            End If
                        Next
                    End If
                    txtPipeCondition.Text = e.Item.Cells(10).Text.Replace("&nbsp;", "")
                    txtDTOperator.Text = e.Item.Cells(11).Text.Replace("&nbsp;", "")
                    txtRemarks.Text = e.Item.Cells(12).Text.Replace("&nbsp;", "")
                    lblDrag.Text = e.Item.Cells(13).Text
                    lblCope.Text = e.Item.Cells(14).Text
                    txtCloseDownRemarks.Text = e.Item.Cells(15).Text.Replace("&nbsp;", "")
                    txtSeatingRemarks.Text = e.Item.Cells(16).Text.Replace("&nbsp;", "")
                    txtTubeSinkRemarks.Text = e.Item.Cells(17).Text.Replace("&nbsp;", "")
                    txtPrgCraneRemarks.Text = e.Item.Cells(18).Text.Replace("&nbsp;", "")
                    txtDragConditionRemarks.Text = e.Item.Cells(19).Text.Replace("&nbsp;", "")
                    txtCopeConditionRemarks.Text = e.Item.Cells(20).Text.Replace("&nbsp;", "")
                    'new
                    txtIngateReamerOperator.Text = e.Item.Cells(21).Text.Replace("&nbsp;", "")
                Case "Delete"
                    Try
                        FillGrid()
                    Catch exp As Exception
                        lblMessage.Text = exp.Message
                    End Try
            End Select
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        dgXCWheels.SelectedIndex = -1
        Dim Done As Boolean
        Try
            Done = New RWF.MLDING().MRRunBackWheelsAdd(CDate(txtDate.Text), lblHeat.Text, lblWheel.Text, lblStatus.Text.Trim, txtPourOperator.Text.Trim, txtPlungerPr.Text.Trim, txtCentringRemarks.Text.Trim, txtCTCOperator.Text.Trim, rblDD.SelectedItem.Value.Trim, txtPipeCondition.Text.Trim, txtDTOperator.Text.Trim, txtRemarks.Text.Trim, txtCloseDownRemarks.Text.Trim, txtSeatingRemarks.Text.Trim, txtTubeSinkRemarks.Text.Trim, txtPrgCraneRemarks.Text.Trim, txtDragConditionRemarks.Text.Trim, txtCopeConditionRemarks.Text.Trim, txtIngateReamerOperator.Text.Trim)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If Done Then
            lblMessage.Text = " Updation Successful !"
            Try
                FillGrid()
                Clear()
            Catch exp As Exception
                lblMessage.Text &= exp.Message
            End Try
        Else
            lblMessage.Text &= " Updation Failed ! "
        End If
    End Sub
    Private Sub Clear()
        lblHeat.Text = ""
        lblWheel.Text = ""
        lblStatus.Text = ""
        txtPourOperator.Text = ""
        txtPlungerPr.Text = ""
        txtCentringRemarks.Text = ""
        txtCTCOperator.Text = ""
        txtPipeCondition.Text = ""
        txtDTOperator.Text = ""
        txtRemarks.Text = ""
        txtIngateReamerOperator.Text = ""
    End Sub

    Protected Sub dgXCWheels_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dgXCWheels.SelectedIndexChanged

    End Sub
End Class