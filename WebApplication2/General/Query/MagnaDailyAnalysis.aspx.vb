Public Class MagnaDailyAnalysis
    Inherits System.Web.UI.Page
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents dgResults As System.Web.UI.WebControls.DataGrid
    Protected WithEvents hlBack As System.Web.UI.WebControls.HyperLink
    Protected WithEvents rblLine As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents rblQuerry As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblShift As System.Web.UI.WebControls.RadioButtonList

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

        ' Page.Theme = themeValue
        Page.Theme = Session("Theme")
    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Page.IsPostBack = False Then
            txtDate.Text = Now.Date
            Try
                dgResults.CurrentPageIndex = 0
                dgResults.EditItemIndex = -1
                FillGrid(rblQuerry.SelectedItem.Value)
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
    Private Sub FillGrid(ByVal Type As Int16)
        dgResults.DataSource = Nothing
        dgResults.DataBind()
        Dim da As New SqlClient.SqlDataAdapter()
        da.SelectCommand = New SqlClient.SqlCommand()
        da.SelectCommand.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
        da.SelectCommand.CommandTimeout = 60 * 60
        Dim dt1 As DataTable
        Dim ds As New DataSet()
        If Type = 1 Then
            da.SelectCommand.CommandText = "mm_sp_magnaAnalysis"
        ElseIf Type = 2 Then
            da.SelectCommand.CommandText = "mm_sp_magnascoreNew"
        ElseIf Type = 3 Then
            da.SelectCommand.CommandText = "mm_sp_magnaSummary"
        ElseIf Type = 4 Then
            da.SelectCommand.CommandText = "mm_sp_magnaOffload"
        ElseIf Type = 5 Then
            da.SelectCommand.CommandText = "mm_sp_magnaDetails"
        ElseIf Type = 6 Then
            da.SelectCommand.CommandText = "mm_sp_magnaMagCalibration"
        ElseIf Type = 7 Then
            da.SelectCommand.CommandText = "mm_sp_magnaUTCalibration"
        ElseIf Type = 8 Then
            da.SelectCommand.CommandText = "mm_sp_magnaBHNCalibration"
        ElseIf Type = 9 Then
            da.SelectCommand.CommandText = "mm_sp_magnaUVCalibration"
        End If

        da.SelectCommand.CommandType = CommandType.StoredProcedure
        Try
            da.SelectCommand.Parameters.Add("@Date", SqlDbType.SmallDateTime, 4).Value = CDate(txtDate.Text)
            da.SelectCommand.Parameters.Add("@Shift", SqlDbType.VarChar, 3).Value = rblShift.SelectedItem.Value
            da.SelectCommand.Parameters.Add("@linenumber", SqlDbType.VarChar, 3).Value = rblLine.SelectedItem.Value
            da.Fill(ds)
            If IsNothing(dgResults.CurrentPageIndex) Then dgResults.CurrentPageIndex = 0
            dt1 = ds.Tables(0)
            If dt1.Rows.Count > 10 Then
                dgResults.AllowPaging = True
                dgResults.PageSize = 10
                dgResults.PagerStyle.Mode = PagerMode.NumericPages
            End If
            dgResults.DataSource = dt1.DefaultView
            dgResults.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
            dgResults.Visible = False
        End Try
    End Sub

    Private Sub dgResults_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgResults.PageIndexChanged
        lblMessage.Text = ""
        Try
            dgResults.CurrentPageIndex = e.NewPageIndex
            dgResults.EditItemIndex = -1
            FillGrid(rblQuerry.SelectedItem.Value)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub rblQuerry_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblQuerry.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            dgResults.CurrentPageIndex = 0
            dgResults.EditItemIndex = -1
            FillGrid(rblQuerry.SelectedItem.Value)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub rblLine_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblLine.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            dgResults.CurrentPageIndex = 0
            dgResults.EditItemIndex = -1
            FillGrid(rblQuerry.SelectedItem.Value)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub rblShift_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblShift.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            dgResults.CurrentPageIndex = 0
            dgResults.EditItemIndex = -1
            FillGrid(rblQuerry.SelectedItem.Value)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        lblMessage.Text = ""
        Dim dt As Date
        Try
            dt = CDate(txtDate.Text)
            If dt > Today Then
                lblMessage.Text = "Future Date : " & txtDate.Text
                txtDate.Text = ""
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message & ":" & txtDate.Text
            txtDate.Text = ""
        End Try
        If txtDate.Text = "" Then
            Exit Sub
        End If
        Try
            dgResults.CurrentPageIndex = 0
            dgResults.EditItemIndex = -1
            FillGrid(rblQuerry.SelectedItem.Value)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
End Class
