Public Class WorkOrderClose
    Inherits System.Web.UI.Page
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents ddlMonth As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlYear As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblWO As System.Web.UI.WebControls.Label
    Protected WithEvents txtPassed As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRej As System.Web.UI.WebControls.TextBox
    Protected WithEvents p As System.Web.UI.WebControls.Label
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents rblShops As System.Web.UI.WebControls.RadioButtonList
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


    'Protected Sub dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
    '    themeValue = Dd1.SelectedItem.Value
    '    Response.Redirect(Request.Url.ToString())

    'End Sub

    Private Overloads Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        ddlYear.Enabled = False
        ddlMonth.Enabled = False
        p.Visible = False
        If IsPostBack = False Then
            Dim i As Int16
            ddlYear.ClearSelection()
            For i = 0 To ddlYear.Items.Count - 1
                If ddlYear.Items(i).Text = Now.AddMonths(-1).Year Then
                    ddlYear.Items(i).Selected = True
                    Exit For
                End If
            Next
            i = 0
            ddlMonth.ClearSelection()
            For i = 0 To ddlMonth.Items.Count - 1
                If ddlMonth.Items(i).Value = Chr(Now.AddMonths(-1).Month + 64) Then
                    ddlMonth.Items(i).Selected = True
                    Exit For
                End If
            Next
            i = Nothing
            Try
                GetShops()
                Qry()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub GetShops()
        Dim dt As New DataTable()
        Try
            dt = PCO.tables.GetWOShops()
            rblShops.DataSource = dt
            rblShops.DataTextField = dt.Columns(0).ColumnName
            rblShops.DataValueField = dt.Columns(0).ColumnName
            rblShops.DataBind()
            rblShops.SelectedIndex = 0
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
            dt = Nothing
        End Try
    End Sub

    Private Overloads Sub Qry()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Dim ds As New DataSet()
        lblWO.Text = ""
        txtPassed.Text = ""
        txtRej.Text = ""
        p.Text = ""
        Try
            ds = PCO.tables.WorkOrderOutTurn(Right(ddlYear.SelectedItem.Text, 1) + ddlMonth.SelectedItem.Value, rblShops.SelectedItem.Text.Trim)
            If IsNothing(DataGrid1.CurrentPageIndex) Then DataGrid1.CurrentPageIndex = 0
            If ds.Tables(2).Rows.Count > 10 Then
                DataGrid1.AllowPaging = True
                DataGrid1.PageSize = 10
                DataGrid1.PagerStyle.Mode = PagerMode.NumericPages
            End If
            DataGrid1.DataSource = ds.Tables(2)
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            ds.Dispose()
            ds = Nothing
        End Try
    End Sub

    Private Overloads Sub DataGrid1_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid1.PageIndexChanged
        lblMessage.Text = ""
        Try
            DataGrid1.CurrentPageIndex = e.NewPageIndex
            DataGrid1.SelectedIndex = -1
            Qry()
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
    End Sub

    Private Overloads Sub DataGrid1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.ItemCommand
        lblMessage.Text = ""
        lblWO.Text = ""
        txtPassed.Text = ""
        txtRej.Text = ""
        p.Text = ""
        Select Case e.CommandName
            Case "Select"
                'Dim dt As DataTable
                Try
                    lblWO.Text = e.Item.Cells(1).Text
                    p.Text = e.Item.Cells(2).Text
                    txtPassed.Text = e.Item.Cells(7).Text.Replace("&nbsp;", 0)
                    txtRej.Text = e.Item.Cells(8).Text.Replace("&nbsp;", 0)
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                End Try
        End Select
    End Sub

    Private Overloads Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        Try
            lblMessage.Text = New PCO.WorkOrder().UpdateWOQty(lblWO.Text, p.Text, Now.Date.AddMonths(-1), Val(txtPassed.Text), Val(txtRej.Text))
            If lblMessage.Text.EndsWith("Successfully") Then
                DataGrid1.SelectedIndex = -1
                DataGrid1.CurrentPageIndex = 0
                Qry()
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Overloads Sub rblShops_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblShops.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            DataGrid1.SelectedIndex = -1
            DataGrid1.CurrentPageIndex = 0
            Qry()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
End Class
