Public Class PouringTube
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtHeatNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTubeNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtAlDipTemp As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtTapDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents txtTop As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMiddle As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBottom As System.Web.UI.WebControls.TextBox
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


    Protected Sub dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        'Session("UserID") = "078844"
        'Session("Group") = "MLDING"
        If IsPostBack = False Then
            txtTapDate.Text = Now.Date
            Try
                PopulateGrid()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub PopulateGrid()
        Dim dt As New DataTable()
        Try
            dt = RWF.MLDING.GetPouringTubes(CDate(txtTapDate.Text))
            If dt.Rows.Count > 0 Then
                If IsNothing(DataGrid1.CurrentPageIndex) Then DataGrid1.CurrentPageIndex = 0
                DataGrid1.DataSource = dt
                DataGrid1.DataBind()
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
            dt = Nothing
        End Try
    End Sub

    Private Sub DataGrid1_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid1.PageIndexChanged
        DataGrid1.SelectedIndex = -1
        DataGrid1.CurrentPageIndex = e.NewPageIndex
        PopulateGrid()
    End Sub

    Private Sub txtTapDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTapDate.TextChanged
        lblMessage.Text = ""
        DataGrid1.SelectedIndex = -1
        DataGrid1.CurrentPageIndex = 0
        Try
            PopulateGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub DataGrid1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.ItemCommand
        Select Case e.CommandName
            Case "Select"
                txtHeatNo.Text = e.Item.Cells(2).Text
                txtTubeNo.Text = e.Item.Cells(3).Text
                txtAlDipTemp.Text = e.Item.Cells(6).Text
                txtTop.Text = e.Item.Cells(7).Text.Replace("&nbsp;", "")
                txtMiddle.Text = e.Item.Cells(8).Text.Replace("&nbsp;", "")
                txtBottom.Text = e.Item.Cells(9).Text.Replace("&nbsp;", "")
                txtRemarks.Text = e.Item.Cells(10).Text.Replace("&nbsp;", "")
        End Select
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        Dim Done As Boolean
        Try
            Done = New RWF.MLDING().PouringTubes(Val(txtHeatNo.Text), txtTubeNo.Text.Trim, txtTop.Text, txtMiddle.Text, txtBottom.Text, txtRemarks.Text.Trim)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If Done Then
            PopulateGrid()
        End If
    End Sub


End Class
