Imports System.IO
Public Class MMSOfflineReports
    Inherits System.Web.UI.Page
    Protected WithEvents ddlProductionHighlights As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlPinkSheets As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents ddlAMSDaily As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlASSDaily As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlUTMPTDaily As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlAFSDaily As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblmessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblAfsReps As System.Web.UI.WebControls.Label
    Protected WithEvents lblAmsDlyReps As System.Web.UI.WebControls.Label
    Protected WithEvents lblAasDlyReps As System.Web.UI.WebControls.Label
    Protected WithEvents lblUtMptDlyReps As System.Web.UI.WebControls.Label
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
    Public Property Admin As Object

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
        'Response.Redirect("http://reportserver/mmsreports/mms/offlineReports/MMSOfflineReports.aspx")
        If IsPostBack = False Then
            showFiles()
        End If
    End Sub

    Private Sub showFiles()
        PrepareNewDDL(ddlProductionHighlights, "phs")
        PrepareNewDDL(ddlPinkSheets, "pink")
        ddlAMSDaily.Visible = False
        ddlAFSDaily.Visible = False
        ddlUTMPTDaily.Visible = False
        ddlASSDaily.Visible = False
    End Sub
    Private Sub PrepareNewDDL(ByRef ddl As System.Web.UI.WebControls.DropDownList, ByVal FilesStartWith As String)
        Dim dt As DataTable
        Try
            dt = Admin.GetUploadedReports(FilesStartWith)
            ddl.DataSource = dt
            ddl.DataTextField = dt.Columns(0).ColumnName
            ddl.DataValueField = dt.Columns(0).ColumnName
            ddl.DataBind()
            ddl.Items.Insert(0, "Select")
        Catch exp As Exception
            lblmessage.Text &= exp.Message
        End Try
        dt = Nothing
    End Sub
    Private Sub prepareddl(ByRef ddl As System.Web.UI.WebControls.DropDownList, ByVal FilesStartWith As String)
        Dim files() As String
        Dim str, path, l, f, f2, p As String
        Dim i, j As Integer
        path = Server.MapPath("spooledReports")
        l = Len(path) + 1
        files = Directory.GetFiles(path, FilesStartWith & "*.rpt")
        j = 0
        For Each f In files
            i = 0
            For Each f2 In files
                If FileDateTime(files(j)) > FileDateTime(files(i)) Then
                    Dim temp = files(j)
                    files(j) = files(i)
                    files(i) = temp
                End If
                i += 1
            Next
            j += 1
        Next
        For Each f In files
            Dim ReportDate As Date
            Dim ReportName As String
            p = Right(f, (Len(f) - l)).ToUpper.Trim
            If p.ToLower.StartsWith("phs") Then
                ReportName = p
                lblmessage.Text = p.Remove(0, 3).Remove(8, 4)
                ReportDate = CDate(Left(lblmessage.Text, 2) + "/" + lblmessage.Text.Substring(2, 2) + "/" + Right(lblmessage.Text, 4))
            ElseIf p.ToLower.StartsWith("pink") Then
                ReportName = p
                lblmessage.Text = p.Remove(0, 4).Remove(8, 4)
                ReportDate = CDate(Left(lblmessage.Text, 2) + "/" + lblmessage.Text.Substring(2, 2) + "/" + Right(lblmessage.Text, 4))
            End If
            ddl.Items.Add(p.ToLower.Trim)
            ReportDate = Nothing
            ReportName = Nothing
        Next
        ddl.Items.Insert(0, "Select")
        files = Nothing
        str = Nothing
        path = Nothing
        l = Nothing
        f = Nothing
        f2 = Nothing
        p = Nothing
        i = Nothing
        j = Nothing
    End Sub

    Private Sub ddlProductionHighlights_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlProductionHighlights.SelectedIndexChanged
        showReport(ddlProductionHighlights.SelectedItem.Text)
    End Sub
    Private Sub showReport(ByVal sFileName As String)
        Dim strPathName As String
        If sFileName.ToLower = "select" Then
            Exit Sub
        End If
        'strPathName = "http://" & rwfGen.ReportServer.ServerName & ""
        'strPathName &= "/mmsreports/mms/offlineReports/spooledReports/" & sFileName.ToLower.Trim
        Response.Redirect(strPathName)
    End Sub
    Private Sub ddlPinkSheets_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlPinkSheets.SelectedIndexChanged
        showReport(ddlPinkSheets.SelectedItem.Text)
    End Sub
    Private Sub ddlAMSDaily_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlAMSDaily.SelectedIndexChanged
        showReport(ddlAMSDaily.SelectedItem.Text)
    End Sub
    Private Sub ddlASSDaily_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlASSDaily.SelectedIndexChanged
        showReport(ddlASSDaily.SelectedItem.Text)
    End Sub
    Private Sub ddlUTMPTDaily_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlUTMPTDaily.SelectedIndexChanged
        showReport(ddlUTMPTDaily.SelectedItem.Text)
    End Sub
    Private Sub ddlAFSDaily_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlAFSDaily.SelectedIndexChanged
        showReport(ddlAFSDaily.SelectedItem.Text)
    End Sub
End Class
