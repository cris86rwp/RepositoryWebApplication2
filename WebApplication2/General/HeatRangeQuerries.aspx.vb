Public Class HeatRangeQuerries
    Inherits System.Web.UI.Page
    Protected WithEvents BtnShow As System.Web.UI.WebControls.Button
    Protected WithEvents rfvld2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtToHeatNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfvld1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtFromHeatNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents rblQue As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnExportDetails As System.Web.UI.WebControls.Button
    Protected WithEvents txtXC As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
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

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If IsPostBack = False Then
            txtFromHeatNo.Text = RWF.tables.GetLatestPrePourHeat - 1
            txtToHeatNo.Text = RWF.tables.GetLatestPrePourHeat - 1
        End If
    End Sub
    Private Sub BtnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShow.Click
        If Val(txtFromHeatNo.Text) > Val(txtToHeatNo.Text) Then
            lblMessage.Text = "InValid Heat Numbers !"
        Else
            lblMessage.Text = ""
            Try
                If rblQue.SelectedItem.Value = 8 Or rblQue.SelectedItem.Value = 9 Then
                    FillGrid(rblQue.SelectedItem.Value, Val(txtXC.Text.Trim))
                Else
                    FillGrid(rblQue.SelectedItem.Value)
                End If
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub FillGrid(ByVal QuerryID As Integer, Optional ByVal XC As Integer = 0)
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            If XC = 0 Then
                DataGrid1.DataSource = RWF.MRQuerry.HeatRangeData(rblQue.SelectedItem.Value, Val(txtFromHeatNo.Text), Val(txtToHeatNo.Text))
                DataGrid1.DataBind()
            Else
                If QuerryID = 8 Or QuerryID = 9 Then
                    DataGrid1.DataSource = RWF.MRQuerry.RejectionCodewiseDetails(XC, Val(txtFromHeatNo.Text), Val(txtToHeatNo.Text), QuerryID)
                    DataGrid1.DataBind()
                End If
            End If
        Catch exp As Exception
            Throw New Exception("Data Retrieval Error : " & exp.Message)
        Finally
        End Try
    End Sub

    Private Sub btnExportDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportDetails.Click
        If DataGrid1.Items.Count > 0 Then
            Dim prevstate As Boolean = Me.EnableViewState
            Dim tw As New System.IO.StringWriter()
            Dim hw As New System.Web.UI.HtmlTextWriter(tw)
            Try
                Response.ContentType = "application/vnd.ms_excel"
                Response.Charset = ""
                Me.EnableViewState = False
                DataGrid1.RenderControl(hw)
                Response.Write(tw.ToString)
                Response.End()
                Me.EnableViewState = prevstate
            Catch exp As Exception
                lblMessage.Text = exp.Message
            Finally
                prevstate = Nothing
                tw = Nothing
                hw = Nothing
            End Try
        Else
            lblMessage.Text = "No Data in Grid to export !"
        End If
    End Sub
End Class
