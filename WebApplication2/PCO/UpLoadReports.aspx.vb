Public Class UpLoadReports
    Inherits System.Web.UI.Page
    Protected WithEvents ddlReportTypes As System.Web.UI.WebControls.DropDownList
    Protected WithEvents chkHelp As System.Web.UI.WebControls.CheckBox
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents File1 As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents Submit1 As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents SubmitFile1 As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblEmployee As System.Web.UI.WebControls.Label
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents chkAddStr As System.Web.UI.WebControls.CheckBox
    Protected WithEvents txtAddToFileName As System.Web.UI.WebControls.TextBox
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
        Session("UserID") = "078844"
        Response.Redirect("http://" & rwfGen.ReportServer.ServerName & "mms/OfflineReports/UpLoadReports.aspx?sUser=" & Session("UserID") & "")
        'Response.Redirect("http:\\172.16.13.145\mms\OfflineReports\MMSOfflineReports.aspx")
        If Page.IsPostBack = False Then
            Panel1.Visible = chkHelp.Checked
            Session("UserID") = "078844"
            If Session("UserID") = Nothing Then
                Response.Redirect("InvalidSession.aspx")
                Exit Sub
            End If
            chkAddStr.Visible = False
            txtAddToFileName.Visible = False
            lblEmployee.Text = Session("UserID")
        End If
    End Sub

    Private Sub SubmitFile1_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubmitFile1.ServerClick
        If File1.PostedFile.FileName Is Nothing Or File1.PostedFile.ContentLength = 0 Then
            lblMessage.Text = "Select/Input a file to upload."
            lblMessage.ForeColor = System.Drawing.Color.Red
            Exit Sub
        End If
        Dim filetype As String = File1.PostedFile.ContentType
        If filetype <> "application/x-rpt" Then
            lblMessage.Text = "Does not seem to be a report"
            Exit Sub
        End If
        Dim dt As Date
        Try
            dt = CDate(txtDate.Text)
        Catch exp As Exception
            lblMessage.Text = exp.Message
            Exit Sub
        End Try
        If ddlReportTypes.SelectedItem.Text.ToLower = "select" Then
            lblMessage.Text = "Select a Report Type from drop down"
            Exit Sub
        End If
        If chkAddStr.Visible = True And chkAddStr.Checked = True Then
            If txtAddToFileName.Text <> "" Then
                Dim chrarray() As Char = txtAddToFileName.Text.ToCharArray()
                Dim i As Integer
                For i = 0 To chrarray.Length - 1
                    Select Case chrarray(i).ToString.ToLower
                        Case "a" To "z"
                        Case "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "_"
                        Case Else
                            lblMessage.Text = "Invalid chars in Add to File Name box (a-z;0-9; _ only allowed) : " & txtAddToFileName.Text
                            txtAddToFileName.Text = ""
                            Exit Sub
                    End Select
                Next
            End If
        End If
        Dim fn As String
        If txtAddToFileName.Text = "" Then
            fn = ddlReportTypes.SelectedItem.Value.Trim & Right("00" & dt.Date.Day.ToString, 2) & _
            Right("00" & dt.Date.Month.ToString, 2) & dt.Date.Year.ToString.Trim + ".rpt"
        Else
            fn = ddlReportTypes.SelectedItem.Value.Trim & txtAddToFileName.Text.Trim & Right("00" & dt.Date.Day.ToString, 2) & _
             Right("00" & dt.Date.Month.ToString, 2) & dt.Date.Year.ToString.Trim + ".rpt"
        End If
        ' System.IO.Path.GetFileName(File1.PostedFile.FileName)
        Dim SaveLocation As String = Server.MapPath("SpooledReports") & "\" & fn
        Try
            File1.PostedFile.SaveAs(SaveLocation)
            lblMessage.Text = "File Uploaded"
            lblMessage.ForeColor = System.Drawing.Color.Black
            Dim Done As Boolean
            Try
                Done = New Admin().UploadReport(lblEmployee.Text, ddlReportTypes.SelectedItem.Text, File1.PostedFile.FileName)
                If Done Then
                    Done = False
                    Done = New Admin().UploadReportName(fn, dt.Date)
                End If
            Catch exp1 As Exception
                Response.Redirect("Unexpected Error Ocurred after file transfer. Please inform MIS Centre")
            End Try
            If Done = False Then
                lblMessage.Text = "File Upload Failed !"
            End If
            Done = Nothing
        Catch exp As Exception
            lblMessage.Text = exp.Message
            lblMessage.ForeColor = System.Drawing.Color.Red
        End Try
        filetype = Nothing
        dt = Nothing
        fn = Nothing
        SaveLocation = Nothing
    End Sub

    Private Sub chkHelp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHelp.CheckedChanged
        Panel1.Visible = chkHelp.Checked
    End Sub

    Private Sub ddlReportTypes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlReportTypes.SelectedIndexChanged
        chkAddStr.Visible = False
        Select Case ddlReportTypes.SelectedItem.Value.ToLower
            Case "pink"
                chkAddStr.Visible = True
            Case Else

        End Select
        txtAddToFileName.Visible = chkAddStr.Visible
    End Sub

    Private Sub txtAddToFileName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAddToFileName.TextChanged
        lblMessage.Text = ""
        Dim chrarray() As Char = txtAddToFileName.Text.ToCharArray()
        Dim i As Integer
        For i = 0 To chrarray.Length - 1
            Select Case chrarray(i).ToString.ToLower
                Case "a" To "z"
                Case "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "_"
                Case Else
                    lblMessage.Text = "Invalid chars in Add to File Name box (a-z;0-9; _ only allowed) : " & txtAddToFileName.Text
                    txtAddToFileName.Text = ""
            End Select
        Next
        i = Nothing
        chrarray = Nothing
    End Sub

End Class
