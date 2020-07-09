Public Class GeneratePinkSheet
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents ddlPinkDate As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlType As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnReport As System.Web.UI.WebControls.Button
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
        Session("UserID") = "078844"
        If Session("UserID") = Nothing Then
            Response.Redirect("/mms/InvalidSession.aspx")
            Exit Sub
        End If
        Session("Group") = "CLRMAG"
        If CType(Session("Group"), System.String).ToLower <> "clrmag" Then
            Response.Redirect("/mms/InvalidSession.aspx")
            Exit Sub
        End If
        If Page.IsPostBack = False Then
            Try
                GetPinkReportDates()
                GetPinkReportDateTypes()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub GetPinkReportDates()
        Dim dt As DataTable
        dt = RWF.Magna.GetPinkReportDates
        ddlPinkDate.DataSource = dt
        ddlPinkDate.DataTextField = dt.Columns(0).ColumnName
        ddlPinkDate.DataValueField = dt.Columns(1).ColumnName
        ddlPinkDate.DataBind()
        ddlPinkDate.SelectedIndex = 0
        dt = Nothing
    End Sub

    Private Sub GetPinkReportDateTypes()
        Dim dt As DataTable
        dt = RWF.Magna.GetPinkReportDateTypes(ddlPinkDate.SelectedItem.Value)
        ddlType.DataSource = dt
        ddlType.DataTextField = dt.Columns(0).ColumnName
        ddlType.DataValueField = dt.Columns(0).ColumnName
        ddlType.DataBind()
        ddlType.SelectedIndex = 0
        dt = Nothing
    End Sub

    Private Sub ddlPinkDate_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlPinkDate.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            GetPinkReportDateTypes()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click
        lblMessage.Text = ""
        If RWF.Magna.PinkSheetCount(ddlPinkDate.SelectedItem.Value, ddlType.SelectedItem.Value) Then
            Try
                If New RWF.Magna().GeneratePinkSheetreportData(ddlPinkDate.SelectedItem.Value, ddlType.SelectedItem.Value) Then lblMessage.Text = "Pink Sheet Report Data Generated for :  " & ddlType.SelectedItem.Value
            Catch exp As Exception
                lblMessage.Text = "Pink Sheet not generated: " & exp.Message
            End Try
        Else
            lblMessage.Text = "Pink Sheet Cumulative Report will be generated for :  " & ddlType.SelectedItem.Value
        End If
    End Sub
End Class
