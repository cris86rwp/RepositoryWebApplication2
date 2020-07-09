Public Class MouldTransaction
    Inherits System.Web.UI.Page
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblShift As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents ddlMoulds As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnUpdate As System.Web.UI.WebControls.Button
    Protected WithEvents ddlRemarks As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList

    Protected WithEvents txtshift As System.Web.UI.WebControls.TextBox
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

        If IsPostBack = False Then
            Dim str As String
            'Try

            '    Dim a As String = DateTime.Now.ToString("7 / 2 / 2020 8:00:00")
            '    Dim ti As String = DateTime.Now.ToString("07/02/2020 14:00:00")
            '    Dim ti2 As String = DateTime.Now.ToString("07/02/2020 22:00:00")
            '    Dim txtshift As DateTime = DateTime.Now.ToLongTimeString
            '    If txtshift > a And txtshift < ti Then

            '        rblShift.SelectedItem.Text = "A"
            '    ElseIf txtshift > ti And txtshift < ti2 Then
            '        rblShift.SelectedItem.Text = "B"
            '    Else
            '        rblShift.SelectedItem.Text = "C"
            '    End If
            'Catch ex As Exception
            '    lblMessage.Text = ex.Message
            'End Try

            'Try
            '    FillGrid()
            '    GetRemarks()
            'Catch exp As Exception
            '    lblMessage.Text = exp.Message
            'End Try

            Select Case Now.Hour
                Case 6 To 13
                    Str = "A"
                Case 14 To 21
                    Str = "B"
                Case Else
                    Str = "C"
            End Select
            rblShift.ClearSelection()
            Dim i As Integer
            For i = 0 To rblShift.Items.Count - 1
                If str = rblShift.Items(i).Text Then
                    rblShift.Items(i).Selected = True
                    Exit For
                End If
            Next
            txtDate.Text = Now.Date
            Try
                FillGrid()
                GetRemarks()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            'str = Nothing
            'i = Nothing
        End If
    End Sub
    Private Sub GetRemarks()
        Dim dt As DataTable
        Try
            dt = MouldMaster.MRSMRS.MouldsRemarks
            ddlRemarks.DataSource = dt
            ddlRemarks.DataTextField = dt.Columns(0).ColumnName
            ddlRemarks.DataValueField = dt.Columns(0).ColumnName
            ddlRemarks.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub FillGrid()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Dim dt As DataTable
        Try
            dt = MouldMaster.MRSMRS.MRTransMlds(CDate(txtDate.Text), rblShift.SelectedItem.Text)
            ddlMoulds.DataSource = dt
            ddlMoulds.DataTextField = dt.Columns(3).ColumnName
            ddlMoulds.DataTextField = dt.Columns(3).ColumnName
            ddlMoulds.DataBind()
            If dt.Rows.Count > 0 Then
                DataGrid1.DataSource = dt
                DataGrid1.DataBind()
            Else
                lblMessage.Text = "No Moulds Transfered From MR !"
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        dt = Nothing
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lblMessage.Text = ""
        Try
            FillGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnExportDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
            lblMessage.Text = "No Moulds to export !"
        End If
    End Sub

    Private Sub ddlMoulds_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMoulds.SelectedIndexChanged
        lblMessage.Text = ""
        ddlRemarks.SelectedIndex = 0
    End Sub

    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        lblMessage.Text = ""
        Try
            FillGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        lblMessage.Text = ""
        Dim done As Boolean
        Try
            done = New MouldMaster.MRSMRS().UpdateRemarks(ddlMoulds.SelectedItem.Text, ddlRemarks.SelectedItem.Text.Trim, rblShift.SelectedItem.Text, CDate(txtDate.Text))
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If done Then
            Try
                FillGrid()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            ddlRemarks.SelectedIndex = 0
            lblMessage.Text = "Record Updated !"
        Else
            lblMessage.Text = "Record Updation Failed !"
        End If
        done = Nothing
    End Sub

    Private Sub rblShift_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblShift.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            FillGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
End Class
