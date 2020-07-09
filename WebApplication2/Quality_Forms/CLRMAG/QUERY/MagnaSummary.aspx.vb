Public Class MagnaSummary
    Inherits System.Web.UI.Page
    Protected WithEvents lblmessage As System.Web.UI.WebControls.Label
    Protected WithEvents rblList As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtFrom As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTo As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblQry As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnReport As System.Web.UI.WebControls.Button
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents rblLine As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblShift As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel

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
            If rblList.SelectedIndex = 0 Then
                txtFrom.Text = Now.Date
                txtTo.Text = Now.Date
            End If
        End If
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click
        lblmessage.Text = ""
        If rblList.SelectedIndex = 0 Then
            Try
                If CDate(txtTo.Text) < CDate(txtFrom.Text) Then
                    lblmessage.Text = "To Date is less than From date : " & txtFrom.Text & " - " & txtTo.Text
                    txtFrom.Text = ""
                    txtTo.Text = ""
                End If
            Catch exp As Exception
                lblmessage.Text = exp.Message & " : " & txtFrom.Text & " - " & txtTo.Text
                txtFrom.Text = ""
                txtTo.Text = ""
            End Try
            If txtFrom.Text = "" Then
                Exit Sub
            End If
        End If
        lblmessage.Text = ""
        Try
            FillGrid(rblQry.SelectedItem.Value)
        Catch exp As Exception
            lblmessage.Text = exp.Message
        End Try
    End Sub
    Private Sub FillGrid(ByVal QryNo As Int16)
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Dim dt As DataTable
        Try
            If rblQry.SelectedItem.Value = 5 Or rblQry.SelectedItem.Value = 8 Or rblQry.SelectedItem.Value = 10 Or rblQry.SelectedItem.Value = 12 Or rblQry.SelectedItem.Value = 13 Then
                If Not rblList.SelectedIndex = 0 Then
                    lblmessage.Text = "Data Available only for FromDate and ToDate parameters !"
                Else
                    dt = RWF.MagnaQuerryDetails.WheelsNotPostedAtMagna(CDate(txtFrom.Text), CDate(txtTo.Text), rblQry.SelectedItem.Value)
                End If
            ElseIf rblQry.SelectedItem.Value = 9 Then
                If Not rblList.SelectedIndex = 0 Then
                    lblmessage.Text = "Data Available only for FromDate and ToDate parameters !"
                Else
                    dt = RWF.MagnaQuerryDetails.MagnaDailyPosition(CDate(txtFrom.Text), CDate(txtTo.Text), rblShift.SelectedItem.Text)
                End If
            Else
                If rblList.SelectedIndex = 0 Then
                    dt = RWF.MagnaQuerryDetails.MagnaWhlTypeSummary(CDate(txtFrom.Text), CDate(txtTo.Text), 0, 0, rblShift.SelectedItem.Text.Trim, rblLine.SelectedItem.Text.Trim, QryNo)
                Else
                    dt = RWF.MagnaQuerryDetails.MagnaWhlTypeSummary("1900-01-01", "1900-01-01", Val(txtFrom.Text), Val(txtTo.Text), rblShift.SelectedItem.Text.Trim, rblLine.SelectedItem.Text.Trim, QryNo)
                End If
            End If
            If lblmessage.Text.Trim.Length = 0 Then
                DataGrid1.DataSource = dt
                DataGrid1.DataBind()
            Else
                Exit Sub
            End If
            dt.Dispose()
            dt = Nothing
        Catch exp As Exception
            lblmessage.Text = exp.Message
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
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
                lblmessage.Text = exp.Message
            Finally
                prevstate = Nothing
                tw = Nothing
                hw = Nothing
            End Try
        Else
            lblmessage.Text = "No Data in Grid to export !"
        End If
    End Sub

    Private Sub rblList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblList.SelectedIndexChanged
        lblmessage.Text = ""
        txtFrom.Text = ""
        txtTo.Text = ""
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        If rblList.SelectedIndex = 0 Then
            Try
                txtFrom.Text = Now.Date
                txtTo.Text = Now.Date
            Catch exp As Exception
                lblmessage.Text = exp.Message
            End Try
        End If
    End Sub

End Class
