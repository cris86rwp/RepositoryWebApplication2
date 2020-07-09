Public Class ToolsDelete
    Inherits System.Web.UI.Page
    Protected WithEvents ddlIns As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents txtDeletedDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDeletedBy As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtReasons As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLetterNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator3 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator4 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents btnDelete As System.Web.UI.WebControls.Button
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
        If Not IsPostBack Then
            txtDeletedDate.Text = Now.Date
            Try
                GetInstruments()
            Catch exp As Exception
                lblMessage.Text = ""
            End Try
        End If
    End Sub

    Private Sub GetInstruments()
        Dim dt As DataTable
        Try
            dt = ToolRoom.Tables.GetDeletedCardsDetail ' 'GetHistoryCards
            If dt.Rows.Count > 0 Then
                ddlIns.DataSource = dt
                ddlIns.DataTextField = dt.Columns(0).ColumnName
                ddlIns.DataValueField = dt.Columns(0).ColumnName
                ddlIns.DataBind()
                ddlIns.SelectedIndex = 0
                GetInsDetails()
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt = Nothing
        End Try
    End Sub

    Private Sub GetInsDetails()
        Dim dt As DataTable
        Try
            dt = ToolRoom.Tables.GetDeletedCardsDetails(ddlIns.SelectedItem.Text)
            If dt.Rows.Count > 0 Then
                txtDeletedDate.Text = IIf(IsDBNull(dt.Rows(0)("DeletedDate")), Now.Date, dt.Rows(0)("DeletedDate"))
                txtDeletedBy.Text = IIf(IsDBNull(dt.Rows(0)("DeletedBy")), "", dt.Rows(0)("DeletedBy"))
                txtReasons.Text = IIf(IsDBNull(dt.Rows(0)("Reasons")), "", dt.Rows(0)("Reasons"))
                txtLetterNo.Text = IIf(IsDBNull(dt.Rows(0)("LetterNo")), "", dt.Rows(0)("LetterNo"))
                txtRemarks.Text = IIf(IsDBNull(dt.Rows(0)("Remarks")), "", dt.Rows(0)("Remarks"))
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt = Nothing
        End Try
    End Sub

    Private Sub ddlIns_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlIns.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            GetInsDetails()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim done As Boolean
        Try
            done = New ToolRoom.Tool("T").DeleteTool(ddlIns.SelectedItem.Text, CDate(txtDeletedDate.Text), txtDeletedBy.Text.Trim, txtReasons.Text.Trim, txtLetterNo.Text.Trim, txtRemarks.Text.Trim)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        Try
            GetInstruments()
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
        If done Then
            lblMessage.Text &= " Data Updated !"
            txtDeletedDate.Text = ""
            txtDeletedBy.Text = ""
            txtReasons.Text = ""
            txtLetterNo.Text = ""
            txtRemarks.Text = ""
        End If
        done = Nothing
    End Sub
End Class
