Public Class ConvertedMoulds
    Inherits System.Web.UI.Page
    Protected WithEvents ddlMould As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtMould As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
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
        If IsPostBack = False Then
            txtDate.Text = Now.Date
            Dim dt As DataTable
            dt = MouldMaster.MRSMRS.CondemnedMould
            ddlMould.DataSource = dt
            ddlMould.DataTextField = dt.Columns(0).ColumnName
            ddlMould.DataValueField = dt.Columns(0).ColumnName
            ddlMould.DataBind()
            ddlMould.SelectedIndex = 0
            Try
                GetMouldDetails()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            dt = Nothing
        End If
    End Sub

    Private Sub GetMouldDetails()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            DataGrid1.DataSource = MouldMaster.MRSMRS.MouldOldDetails(ddlMould.SelectedItem.Text)
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub ddlMould_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMould.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            GetMouldDetails()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtMould_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMould.TextChanged
        lblMessage.Text = ""
        Try
            If MouldMaster.MRSMRS.CheckMldNumber(txtMould.Text.Trim) = False Then
                lblMessage.Text = "Mould Number : '" & txtMould.Text & "' is InValid !"
                txtMould.Text = ""
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        If txtMould.Text.Trim.Length = 0 Then Exit Sub
        Dim done As Boolean
        Try
            done = New MouldMaster.MRSMRS().UpdateNewMouldNumber(ddlMould.SelectedItem.Text, txtMould.Text.Trim, CDate(txtDate.Text))
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If done Then
            Try
                GetMouldDetails()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            lblMessage.Text &= " Updation OK !"
        Else
            lblMessage.Text &= " Updation Failed !"
        End If
        done = Nothing
    End Sub
End Class
