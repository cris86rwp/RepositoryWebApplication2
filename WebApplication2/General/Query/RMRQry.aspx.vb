Public Class RMRQry
    Inherits System.Web.UI.Page
    Protected WithEvents ddlPLs As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents rblQry As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnShow As System.Web.UI.WebControls.Button
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents rblYear As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents ddlMonth As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblConsumDate As System.Web.UI.WebControls.Label
    Protected WithEvents lblConsignee As System.Web.UI.WebControls.Label
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList

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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        'Session("Group") = "SSMOLD"
        'Session("UserID") = "073533"

        lblConsumDate.Visible = False
        If IsPostBack = False Then
            Dim Group As String = Session("Group")
            Dim strMode As String = Request.QueryString("mode")
            Dim UserId As String = Session("UserID")
            Dim InValid As Boolean = False
            ''''''''''''''''
            'Group = "SSMOLD"
            'UserId = "073533"
            ''''''''''''''''
            'If UserId = "073533" Then
            '    Try
            lblConsignee.Text = ProductionConsumables.GetConsignee(Group, UserId)
            '        If lblConsignee.Text.Trim.Length = 4 Then InValid = True
            Dim dt As DataTable = ProductionConsumables.GetRMRYear
            rblYear.DataSource = dt
            rblYear.DataValueField = dt.Columns(0).ColumnName
            rblYear.DataTextField = dt.Columns(0).ColumnName
            rblYear.DataBind()
            dt = ProductionConsumables.GetRMRMonth
            ddlMonth.DataSource = dt
            ddlMonth.DataValueField = dt.Columns(0).ColumnName
            ddlMonth.DataTextField = dt.Columns(1).ColumnName
            ddlMonth.DataBind()
            dt.Dispose()
            '    Catch exp As Exception
            '        lblMessage.Text = exp.Message
            '    End Try
            'If Not InValid Then
            'Response.Redirect("/mss/logon.aspx")
            'End If
            Dim i As Integer
                rblYear.ClearSelection()
                i = 0
                For i = 0 To rblYear.Items.Count - 1
                    If rblYear.Items(i).Value = Now.Year Then
                        rblYear.Items(i).Selected = True
                        Exit For
                    End If
                Next
                i = 0
                ddlMonth.ClearSelection()
                For i = 0 To ddlMonth.Items.Count - 1
                    If ddlMonth.Items(i).Value = Now.Month Then
                        ddlMonth.Items(i).Selected = True
                        Exit For
                    End If
                Next
                Try
                    GetPLs()
                    FillGrid()
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                End Try
            ' Else
            'Response.Redirect("/mss/logon.aspx")
        End If
        'End If
    End Sub
    Private Sub GetPLs()
        Dim dt1 As DataTable
        dt1 = ProductionConsumables.RMRPLs(lblConsignee.Text.Trim, ddlMonth.SelectedItem.Value, rblYear.SelectedItem.Value)
        ddlPLs.DataSource = dt1
        ddlPLs.DataTextField = dt1.Columns(1).ColumnName
        ddlPLs.DataValueField = dt1.Columns(0).ColumnName
        ddlPLs.DataBind()
        ddlPLs.Items.Insert(0, "ALL")
        ddlPLs.SelectedIndex = 0
        dt1 = Nothing
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
            End Try
        Else
            lblMessage.Text = "No Data to export !"
        End If
    End Sub


    Private Sub FillGrid()
        Try
            Dim dt As DataTable
            DataGrid1.DataSource = Nothing
            DataGrid1.DataBind()
            If rblQry.SelectedItem.Text = "Entry" Then
                dt = ProductionConsumables.RMRConsumptionEntry(lblConsignee.Text, ddlMonth.SelectedItem.Value, rblYear.SelectedItem.Text, ddlPLs.SelectedItem.Value)
            ElseIf rblQry.SelectedItem.Text = "UnUsed" Then
                dt = ProductionConsumables.RMRUnUsed(lblConsignee.Text, ddlMonth.SelectedItem.Value, rblYear.SelectedItem.Text, ddlPLs.SelectedItem.Value)
            ElseIf rblQry.SelectedItem.Text = "Statement" Then
                dt = ProductionConsumables.RMRConsumptionStatement(lblConsignee.Text, ddlMonth.SelectedItem.Value, rblYear.SelectedItem.Text)
            ElseIf rblQry.SelectedItem.Text = "New Statement" Then
                lblConsumDate.Text = Now.DaysInMonth(rblYear.SelectedItem.Value, ddlMonth.SelectedItem.Value)
                lblConsumDate.Text = CDate(lblConsumDate.Text & "/" & ddlMonth.SelectedItem.Value & "/" & rblYear.SelectedItem.Value)
                dt = ProductionConsumables.RMRConsumptionNewStatement(CDate(lblConsumDate.Text))
            Else
                dt = ProductionConsumables.StockNonStockItems(rblQry.SelectedItem.Text)
            End If
            If dt.Rows.Count > 0 Then
                DataGrid1.DataSource = dt
                DataGrid1.DataBind()
            Else
                lblMessage.Text = "No Data for the given selection !"
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        lblMessage.Text = ""
        FillGrid()
    End Sub

    Private Sub ddlMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMonth.SelectedIndexChanged
        lblMessage.Text = ""
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            GetPLs()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub rblYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblYear.SelectedIndexChanged
        lblMessage.Text = ""
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            GetPLs()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub ddlPLs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlPLs.SelectedIndexChanged
        lblMessage.Text = ""
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
    End Sub
End Class
