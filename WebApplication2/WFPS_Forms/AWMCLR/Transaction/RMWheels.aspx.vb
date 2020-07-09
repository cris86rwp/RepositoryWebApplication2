Public Class RMWheels
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblUserGroup As System.Web.UI.WebControls.Label
    Protected WithEvents lblPcode As System.Web.UI.WebControls.Label
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents dgSaveData As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtPart As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLoadedDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLoadedIn As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblSentIn As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button
    Protected WithEvents Button3 As System.Web.UI.WebControls.Button
    Protected WithEvents Panel2 As System.Web.UI.WebControls.Panel
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
        lblPcode.Visible = False
        If Page.IsPostBack = False Then
            'Session("UserID") = "074261"
            'Session("Group") = "AWMCLR"
            txtLoadedDate.Text = Now.Date
            'Try
            Dim oEmp As New rwfGen.Employee()
            '    If oEmp.Check(Session("UserID") & "", Session("Group")) Then
            lblUserGroup.Text = Session("Group")
            '    Else
            '        Throw New Exception("Invalid Login")
            '    End If
            GetSavedData()
            'Catch exp As Exception
            '    lblMessage.Text = exp.Message
            'End Try
        End If
    End Sub

    Private Sub GetSavedData()
        Dim ds As DataSet
        dgSaveData.DataSource = Nothing
        dgSaveData.DataBind()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        Try
            ds = RWF.AWMCLR.GetSavedRMWheels(lblUserGroup.Text, txtLoadedIn.Text.Trim, CDate(txtLoadedDate.Text))
            dgSaveData.DataSource = ds.Tables(0)
            dgSaveData.DataBind()
            DataGrid1.DataSource = ds.Tables(1)
            DataGrid1.DataBind()
            DataGrid2.DataSource = ds.Tables(2)
            DataGrid2.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        ds = Nothing
    End Sub

    Private Sub txtPart_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPart.TextChanged
        lblMessage.Text = ""
        If txtPart.Text.Trim.Length = 0 OrElse txtPart.Text.IndexOf("/") < 0 Then
            lblMessage.Text = "InValid Wheel "
            txtPart.Text = ""
        Else
            Dim a As Array
            a = txtPart.Text.Split("/")
            txtPart.Text = CStr(CInt(a(0))) + "/" + CStr(CInt(a(1)))
            Session("oRM") = Nothing
            Dim oRM As New RWF.RMWheels(a(0), a(1))
            Try
                lblMessage.Text = oRM.Message
                If lblMessage.Text.Trim.StartsWith("Message") Then
                    txtPart.Text = ""
                Else
                    Session("oRM") = oRM
                End If
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            a = Nothing
            oRM = Nothing
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtPart.Text.Trim.Length = 0 OrElse txtPart.Text.IndexOf("/") < 0 Then
            lblMessage.Text = "InValid Wheel "
            txtPart.Text = ""
        ElseIf txtLoadedIn.Text.Trim.Length = 0 Then
            lblMessage.Text = "Provide Wagon No !"
            txtLoadedIn.Text = ""
        Else
            Dim Done As Boolean
            Dim a As Array
            a = txtPart.Text.Split("/")
            txtPart.Text = CStr(CInt(a(0))) + "/" + CStr(CInt(a(1)))
            Try
                Done = CType(Session("oRM"), RWF.RMWheels).RMWheelsAdd(Session("UserID"), txtPart.Text.Trim, a(0), a(1), Session("Group"), txtLoadedIn.Text.Trim.ToUpper, "", CDate(txtLoadedDate.Text.Trim), rblSentIn.SelectedItem.Value, CType(Session("oRM"), RWF.RMWheels).NotPostedWheel)
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            If Done Then
                lblMessage.Text = "Data Inserted Successfully !"
                Try
                    GetSavedData()
                Catch exp As Exception
                    lblMessage.Text &= exp.Message
                End Try
            Else
                lblMessage.Text = "Data Insertion Failed !"
            End If
            Done = Nothing
            a = Nothing
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If dgSaveData.Items.Count > 0 Then
            Dim prevstate As Boolean = Me.EnableViewState
            Dim tw As New System.IO.StringWriter()
            Dim hw As New System.Web.UI.HtmlTextWriter(tw)
            Try
                Response.ContentType = "application/vnd.ms_excel"
                Response.Charset = ""
                Me.EnableViewState = False
                dgSaveData.RenderControl(hw)
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
            lblMessage.Text = "No Data to export!"
        End If
    End Sub

    Private Sub txtLoadedIn_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLoadedIn.TextChanged
        lblMessage.Text = ""
        txtPart.Text = ""
        If txtLoadedIn.Text.Trim.Length > 0 Then
            Try
                GetSavedData()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        Else
            lblMessage.Text = "Provide Wagon No !"
        End If
    End Sub

    Private Sub txtLoadedDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLoadedDate.TextChanged
        lblMessage.Text = ""
        txtPart.Text = ""
        Dim dt As Date
        Try
            dt = CDate(txtLoadedDate.Text)
            If dt > Now.Date Then
                lblMessage.Text = " AdviceNoteDate : '" & txtLoadedDate.Text & "' cannot be greater then TODAY !"
                txtLoadedDate.Text = ""
            End If
            GetSavedData()
        Catch exp As Exception
            lblMessage.Text = " AdviceNoteDate : '" & txtLoadedDate.Text & "' is INVALID !"
            txtLoadedDate.Text = ""
        End Try
        dt = Nothing
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
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
            lblMessage.Text = "No Data to export!"
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If DataGrid2.Items.Count > 0 Then
            Dim prevstate As Boolean = Me.EnableViewState
            Dim tw As New System.IO.StringWriter()
            Dim hw As New System.Web.UI.HtmlTextWriter(tw)
            Try
                Response.ContentType = "application/vnd.ms_excel"
                Response.Charset = ""
                Me.EnableViewState = False
                DataGrid2.RenderControl(hw)
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
            lblMessage.Text = "No Data to export!"
        End If
    End Sub
End Class
