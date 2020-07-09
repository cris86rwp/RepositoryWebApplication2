Public Class ProductionHighlights_45C
    Inherits System.Web.UI.Page
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents rfvld1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnGenerate As System.Web.UI.WebControls.Button
    Protected WithEvents dgMmyrprdn As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblMeltDtUpdtMsg As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents rblPink As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents chkRegen As System.Web.UI.WebControls.CheckBox
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
        If Page.IsPostBack = False Then
            Dim strGroup, strUserID As String
            Panel1.Visible = True
            strGroup = Trim(Request.QueryString("group"))
            'Session("UserID") = "078844"
            'Session("Group") = "PCOPCO"
            'strGroup = "PCOPCO"
            'strUserID = "078844"
            If Trim(strGroup) = "PCOPCO" Then
                btnGenerate.Visible = True
            Else
                btnGenerate.Visible = False
            End If
            chkRegen.Visible = False
            chkRegen.Checked = False
            dgMmyrprdn.Visible = False
            strGroup = Nothing
            strUserID = Nothing
        End If
    End Sub
    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        Dim ReGen As Boolean
        Dim blnSaved As Boolean
        ReGen = chkRegen.Visible And chkRegen.Checked
        Try
            blnSaved = New PCO.PCO().GeneratePHL(CDate(txtDate.Text), txtDate.Text, ReGen, Session("UserID"), rblPink.SelectedItem.Value)
            showMmyrprdn(CDate(txtDate.Text))
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If blnSaved Then
            Me.lblMessage.Text = "Report have been generated."
            btnGenerate.Visible = True
            txtDate.Text = ""
        End If
        ReGen = Nothing
        blnSaved = Nothing
    End Sub
    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        lblMessage.Text = ""
        dgMmyrprdn.Visible = False
        Try
            CheckDate()
        Catch exp As Exception
            txtDate.Text = ""
            lblMessage.Text = exp.Message
        End Try
        If txtDate.Text = "" Then
            btnGenerate.Enabled = False
        End If
    End Sub
    Private Sub CheckDate()
        Dim dt As Date
        dt = CDate(txtDate.Text)
        Try
            DataGrid2.DataSource = PCO.tables.GetDespatchCount(IIf(Day(CDate(txtDate.Text)) = 1, CDate(txtDate.Text).AddDays(-1), CDate(txtDate.Text)))
            DataGrid2.DataBind()
            If PCO.tables.CheckDate(CDate(txtDate.Text), rblPink.SelectedItem.Value) > 0 Then
                If chkRegen.Checked And chkRegen.Visible Then
                    btnGenerate.Enabled = True
                    showMmyrprdn(CDate(txtDate.Text))
                Else
                    showMmyrprdn(dt)
                    chkRegen.Visible = True
                    chkRegen.Checked = False
                    Throw New Exception("Highlights Already Generated for : " & txtDate.Text)
                End If
            End If
        Catch exp As Exception
            txtDate.Text = ""
            lblMessage.Text = " Message : " + exp.Message
        End Try
        dt = Nothing
    End Sub
    Private Sub showMmyrprdn(ByVal dt As Date)
        Dim ds As DataSet
        Try
            ds = PCO.tables.showMmyrprdn(dt, rblPink.SelectedItem.Value)
            dgMmyrprdn.DataSource = ds.Tables(0).DefaultView
            dgMmyrprdn.DataBind()
            dgMmyrprdn.Visible = True
            DataGrid1.DataSource = ds.Tables(1).DefaultView
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text &= ". Grid Population Error : " & exp.Message
            dgMmyrprdn.Visible = False
        Finally
#Disable Warning BC42104 ' Variable is used before it has been assigned a value
            ds.Dispose()
#Enable Warning BC42104 ' Variable is used before it has been assigned a value
            ds = Nothing
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
                lblMessage.Text = exp.Message
            Finally
                prevstate = Nothing
                tw = Nothing
                hw = Nothing
            End Try
        Else
            lblMessage.Text = "No Data in Grid to export !"
        End If
    End Sub
End Class

