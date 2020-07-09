Public Class ChangeMouldStatus
    Inherits System.Web.UI.Page
    Protected WithEvents txtMldNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents dgMo As System.Web.UI.WebControls.DataGrid
    Protected WithEvents rblSts As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnUpdate As System.Web.UI.WebControls.Button
    Protected WithEvents lblSts As System.Web.UI.WebControls.Label
    Protected WithEvents lblMcnDt As System.Web.UI.WebControls.Label
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


    Protected Sub dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub



    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Page.IsPostBack = False Then
            'Session("UserID") = "079708"
            'Session("Group") = "MRSMRS"
            Try
                If Session("Group") = "" AndAlso Session("UserID") = "" Then
                    Response.Redirect("InvalidSession.aspx")
                    Exit Sub
                End If
            Catch exp As Exception
                Response.Redirect("InvalidSession.aspx")
                Exit Sub
            End Try
            lblSts.Visible = False
            lblSts.Text = ""
            lblMcnDt.Visible = False
            lblMcnDt.Text = ""
            Dim dt As DataTable
            Try

                dt = MouldMaster.tables.FillSts
                If dt.Rows.Count > 0 Then
                    rblSts.DataSource = dt
                    rblSts.DataTextField = dt.Columns(0).ColumnName
                    rblSts.DataValueField = dt.Columns(0).ColumnName
                    rblSts.DataBind()
                    rblSts.SelectedIndex = 0
                Else
                    lblMessage.Text = " InValid Mould Number "
                End If
            Catch exp As Exception
                dt.Dispose()
                lblMessage.Text = exp.Message
            End Try
            dt = Nothing
        End If
    End Sub

    Private Sub txtMldNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMldNo.TextChanged
        lblMessage.Text = ""
        lblSts.Visible = False
        lblSts.Text = ""
        lblMcnDt.Visible = False
        lblMcnDt.Text = ""
        If txtMldNo.Text.Trim.Length < 1 Then
            lblMessage.Text = "Provide Mould Number !"
        Else
            Try
                FillGrid()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
    Private Sub FillGrid()
        Dim dt As New DataTable()
        dgMo.DataSource = Nothing
        dgMo.DataBind()
        Try
            dt = MouldMaster.tables.FillMouldSts(txtMldNo.Text.Trim)
            If dt.Rows.Count > 0 Then
                dgMo.DataSource = dt
                dgMo.DataBind()
                lblSts.Text = IIf(IsDBNull(dt.Rows(0)("MasterSts")), "", dt.Rows(0)("MasterSts"))
                lblMcnDt.Text = IIf(IsDBNull(dt.Rows(0)("MachinigDt")), "1900-01-01", dt.Rows(0)("MachinigDt"))
            Else
                lblMessage.Text = " InValid Mould Number "
            End If
        Catch exp As Exception
            lblMessage.Text = "Unable to retrieve data " & exp.Message
        Finally
            dt.Dispose()
            dt = Nothing
        End Try
    End Sub
    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        lblMessage.Text = ""
        If lblSts.Text.Trim = "" Then
            lblMessage.Text = "InValid Mould Status !"
            Exit Sub
        ElseIf CDate(lblMcnDt.Text) = "1900-01-01" Then
            lblMessage.Text = "InValid Last MachiningDate !"
            Exit Sub
        Else
            Dim blnDone As New Boolean()
            Try
                blnDone = New MouldMaster.MRSMRS().UpdateMouldSts(txtMldNo.Text.Trim, rblSts.SelectedItem.Text.Trim.Trim, Session("UserID"), CDate(lblMcnDt.Text.Trim))
            Catch exp As Exception
                blnDone = False
                lblMessage.Text = exp.Message
            Finally
                If blnDone Then
                    lblMessage.Text = "Data saved !"
                    lblSts.Text = ""
                    txtMldNo.Text = ""
                    lblMcnDt.Text = ""
                    dgMo.DataSource = Nothing
                    dgMo.DataBind()
                Else
                    lblMessage.Text &= ". Data Not saved"
                End If
            End Try
            blnDone = Nothing
        End If
    End Sub
End Class
