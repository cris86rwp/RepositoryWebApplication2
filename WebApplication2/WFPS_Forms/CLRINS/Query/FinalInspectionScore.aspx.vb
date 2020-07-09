Public Class FinalInspectionScore
    Inherits System.Web.UI.Page
    Protected WithEvents chkRefresh As System.Web.UI.WebControls.CheckBox
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents chkToday As System.Web.UI.WebControls.CheckBox
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents btnRework As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents btnReworkWheels As System.Web.UI.WebControls.Button
    Protected WithEvents txtFr As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTo As System.Web.UI.WebControls.TextBox
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents dgScore As System.Web.UI.WebControls.DataGrid
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
        If Page.IsPostBack = False Then
            Dim dt As Date
            dt = Now
            If ((dt.Hour >= 22 And dt.Hour < 24) Or (dt.Hour < 6)) Then
                txtDate.Text = dt.AddDays(-1)
                txtFr.Text = dt.AddDays(-1)
                txtTo.Text = dt.AddDays(-1)
            Else
                txtDate.Text = dt.Date
                txtFr.Text = dt.Date
                txtTo.Text = dt.Date
            End If
            FillGrid()
            dt = Nothing
        End If
    End Sub

    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged, chkRefresh.CheckedChanged, chkToday.CheckedChanged, MyBase.Load
        Dim dt As Date
        If chkToday.Checked = True Or txtDate.Text = "" Then
            dt = Now
            If ((dt.Hour >= 22 And dt.Hour < 24) Or (dt.Hour < 6)) Then
                txtDate.Text = dt.AddDays(-1)
            Else
                txtDate.Text = dt.Date
            End If
        End If
        Try
            FillGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        dt = Nothing
    End Sub

    Private Sub FillGrid()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        dgScore.DataSource = Nothing
        dgScore.DataBind()
        dgScore.DataSource = RWF.CLRINS.fi_Score(CDate(txtDate.Text))
        dgScore.DataBind()
    End Sub
    Private Sub btnRework_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRework.Click
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        dgScore.DataSource = Nothing
        dgScore.DataBind()
        Dim dt As Date
        If chkToday.Checked = True Or txtDate.Text = "" Then
            dt = Now
            If ((dt.Hour >= 22 And dt.Hour < 24) Or (dt.Hour < 6)) Then
                txtFr.Text = dt.AddDays(-1)
                txtTo.Text = dt.AddDays(-1)
            Else
                txtFr.Text = dt.Date
                txtTo.Text = dt.Date
            End If
        End If
        Try
            DataGrid1.DataSource = RWF.CLRINS.FiOffloads(CDate(txtFr.Text), CDate(txtTo.Text))
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = "Saved Records Retrieval Error : " & exp.Message
        End Try
        dt = Nothing
    End Sub

    Private Sub btnReworkWheels_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReworkWheels.Click
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        dgScore.DataSource = Nothing
        dgScore.DataBind()
        Dim dt As Date
        If chkToday.Checked = True Or txtDate.Text = "" Then
            dt = Now
            If ((dt.Hour >= 22 And dt.Hour < 24) Or (dt.Hour < 6)) Then
                txtFr.Text = dt.AddDays(-1)
                txtTo.Text = dt.AddDays(-1)
            Else
                txtFr.Text = dt.Date
                txtTo.Text = dt.Date
            End If
        End If
        Try
            DataGrid1.DataSource = RWF.CLRINS.FiOffloadsDistinctWheels(CDate(txtFr.Text), CDate(txtTo.Text))
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = "Saved Records Retrieval Error : " & exp.Message
        End Try
        dt = Nothing
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        dgScore.DataSource = Nothing
        dgScore.DataBind()
        Dim dt As Date
        If chkToday.Checked = True Or txtDate.Text = "" Then
            dt = Now
            If ((dt.Hour >= 22 And dt.Hour < 24) Or (dt.Hour < 6)) Then
                txtFr.Text = dt.AddDays(-1)
                txtTo.Text = dt.AddDays(-1)
            Else
                txtFr.Text = dt.Date
                txtTo.Text = dt.Date
            End If
        End If
        Try
            DataGrid1.DataSource = RWF.CLRINS.FiOffloadsPassedWheels(CDate(txtFr.Text), CDate(txtTo.Text))
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = "Saved Records Retrieval Error : " & exp.Message
        End Try
        dt = Nothing
    End Sub

    Private Sub chkRefresh_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRefresh.CheckedChanged
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        dgScore.DataSource = Nothing
        dgScore.DataBind()
        Dim dt As Date
        If chkToday.Checked = True Or txtDate.Text = "" Then
            dt = Now
            If ((dt.Hour >= 22 And dt.Hour < 24) Or (dt.Hour < 6)) Then
                txtFr.Text = dt.AddDays(-1)
                txtTo.Text = dt.AddDays(-1)
            Else
                txtFr.Text = dt.Date
                txtTo.Text = dt.Date
            End If
        End If
        Try
            FillGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        dt = Nothing
    End Sub

    Private Sub chkToday_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkToday.CheckedChanged
        Dim dt As Date
        If chkToday.Checked = True Or txtDate.Text = "" Then
            dt = Now
            If ((dt.Hour >= 22 And dt.Hour < 24) Or (dt.Hour < 6)) Then
                txtDate.Text = dt.AddDays(-1)
            Else
                txtDate.Text = dt.Date
            End If
        End If
        Try
            FillGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        dt = Nothing
    End Sub
End Class
