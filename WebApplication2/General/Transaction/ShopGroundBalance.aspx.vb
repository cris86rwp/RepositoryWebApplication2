Public Class ShopGroundBalance
    Inherits System.Web.UI.Page
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents lblUserID As System.Web.UI.WebControls.Label
    Protected WithEvents lblCostCentre As System.Web.UI.WebControls.Label
    Protected WithEvents lblConsignee As System.Web.UI.WebControls.Label
    Protected WithEvents lblShopCode As System.Web.UI.WebControls.Label
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblGroup As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents chkGoNextMonth As System.Web.UI.WebControls.CheckBox
    Protected WithEvents lblyear As System.Web.UI.WebControls.Label
    Protected WithEvents lblMonth As System.Web.UI.WebControls.Label
    Protected WithEvents rblTrnType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblWO As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtTrnQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents dgItems As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblPlNo As System.Web.UI.WebControls.Label
    Protected WithEvents lblItem As System.Web.UI.WebControls.Label
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents lblTranDt As System.Web.UI.WebControls.Label
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblShop As System.Web.UI.WebControls.Label
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
        lblTranDt.Visible = False
        chkGoNextMonth.Visible = False
        lblUserID.Visible = False
        lblConsignee.Visible = False
        lblGroup.Visible = False
        lblShopCode.Visible = False
        lblCostCentre.Visible = False
        If IsPostBack = False Then
            Try
                'Session("UserID") = "074510"
                'Session("UserID") = "111111"
                'Session("Group") = "MLDING"
                'Session("Group") = "WHLMLT"
                lblUserID.Text = Session("UserID")
                lblGroup.Text = Session("Group")
                Dim dt As DataTable
                dt = RWF.tables.ShopCodes(lblGroup.Text)
                lblShop.Text = dt.Rows(0)("Shop")
                lblShopCode.Text = dt.Rows(0)("Shop_Code")
                lblConsignee.Text = dt.Rows(0)("Consignee")
                lblCostCentre.Text = dt.Rows(0)("CostCentre")
                UpdateScreen()
                dt = Nothing
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub PLData(ByVal sGroup As String, ByVal dt As Date, ByVal PLNumber As String)
        Try
            DataGrid2.DataSource = RWF.tables.GBPlData(lblGroup.Text.Trim, CDate(lblTranDt.Text), PLNumber.Trim)
            DataGrid2.DataBind()
            DataGrid2.Visible = rblTrnType.SelectedItem.Value = "Consumption"
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub UpdateScreen()
        Dim dt As Date
        Try
            dt = RWF.MLDING.GetRecordDate(lblShopCode.Text)
            If IsNothing(dt) Then
                dt = Today.Date
            End If
            lblyear.Text = dt.Year
            lblMonth.Text = MonthName(dt.Month)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        lblTranDt.Text = CDate("01/" & lblMonth.Text.ToString & "/" & lblyear.Text)
        txtDate.Text = CDate("01/" & lblMonth.Text.ToString & "/" & lblyear.Text).AddMonths(1).Subtract(New TimeSpan(1, 0, 0, 0))
        ' receipt date is saved in tooltip property of txtdate and text property contains consumption date.
        txtDate.ToolTip = CDate("05/" & CDate(txtDate.Text).Month.ToString & "/" & CDate(txtDate.Text).Year.ToString)
        If txtDate.Text <> "" Then
            PopulateDg(lblCostCentre.Text, dt)
        Else
            dgItems.Visible = False
        End If
        PopulateGrid()
        PopulateGridList()
        dt = Nothing
    End Sub

    Private Function PopulateDg(ByVal sUser As String, ByVal dt As Date) As Boolean
        Dim char1, char2, char3, char4 As String
        Dim wo As String
        Try
            char4 = RWF.MLDING.GetCostCentre(sUser)
            char1 = Right(txtDate.Text, 1)
            char2 = "ZABCDEFGHIJKL"
            char2 = char2.Substring(Month(dt), 1)
            char3 = "%"
            wo = char1 & char2 & char3 & char4
            wo = wo.Trim
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        Dim dtWO As New DataTable()
        Dim dtGroundBalance As New DataTable()
        Try
            dtWO = RWF.MLDING.WONumbers(wo)
            Session("woTbl") = dtWO
            ' Session("woTbl") = "0A0A"
            rblWO.DataSource = dtWO.DefaultView
            rblWO.DataTextField = dtWO.Columns(0).ColumnName
            rblWO.DataValueField = dtWO.Columns(0).ColumnName
            rblWO.DataBind()
            rblWO.SelectedIndex = 0
            rblWO.Visible = rblTrnType.SelectedItem.Value = "Consumption"
            txtTrnQty.Text = "0"
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dtWO.Dispose()
            dtGroundBalance.Dispose()
            dtWO = Nothing
            dtGroundBalance = Nothing
        End Try
        wo = Nothing
        char1 = Nothing
        char2 = Nothing
        char3 = Nothing
        char4 = Nothing
    End Function

    Private Sub rblTrnType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblTrnType.SelectedIndexChanged
        lblMessage.Text = ""
        If lblPlNo.Text.Trim.Length = 0 Then
            lblMessage.Text = "Please select PL Number from Grid below before proceeding further !"
        End If
        rblWO.Visible = rblTrnType.SelectedItem.Value = "Consumption"
        DataGrid2.Visible = rblTrnType.SelectedItem.Value = "Consumption"
        txtTrnQty.Text = "0"
    End Sub

    Private Sub PopulateGrid()
        dgItems.SelectedIndex = -1
        dgItems.DataSource = Nothing
        dgItems.DataBind()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        Dim dt As DataTable = RWF.tables.GBPls(lblGroup.Text.Trim)
        If IsNothing(dgItems.CurrentPageIndex) Then dgItems.CurrentPageIndex = 0
        If dt.Rows.Count > 5 Then
            dgItems.AllowPaging = True
            dgItems.PageSize = 5
            dgItems.PagerStyle.Mode = PagerMode.NumericPages
        End If
        dgItems.DataSource = dt
        dgItems.DataBind()
        dt = Nothing
    End Sub

    Private Sub PopulateGridList()
        DataGrid1.SelectedIndex = -1
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Dim dt As DataTable = RWF.tables.GBPlsList(lblGroup.Text.Trim, CDate(txtDate.Text))
        If IsNothing(DataGrid1.CurrentPageIndex) Then DataGrid1.CurrentPageIndex = 0
        If dt.Rows.Count > 5 Then
            DataGrid1.AllowPaging = True
            DataGrid1.PageSize = 5
            DataGrid1.PagerStyle.Mode = PagerMode.NumericPages
        End If
        DataGrid1.DataSource = dt
        DataGrid1.DataBind()
        dt = Nothing
    End Sub

    Private Sub dgItems_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgItems.PageIndexChanged
        lblMessage.Text = ""
        lblItem.Text = ""
        lblPlNo.Text = ""
        rblTrnType.SelectedIndex = 0
        rblWO.Visible = rblTrnType.SelectedItem.Value = "Consumption"
        txtTrnQty.Text = 0
        Try
            dgItems.CurrentPageIndex = e.NewPageIndex
            dgItems.EditItemIndex = -1
            PopulateGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub dgItems_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgItems.ItemCommand
        lblMessage.Text = ""
        rblTrnType.SelectedIndex = 0
        rblWO.Visible = rblTrnType.SelectedItem.Value = "Consumption"
        txtTrnQty.Text = 0
        If e.CommandName = "Select" Then
            rblWO.Visible = rblTrnType.SelectedItem.Value = "Consumption"
            lblItem.Text = e.Item.Cells(2).Text + ", UOM: " + e.Item.Cells(3).Text
            lblPlNo.Text = e.Item.Cells(1).Text
            Try
                PLData(lblGroup.Text, CDate(lblTranDt.Text), lblPlNo.Text)
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub DataGrid1_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid1.PageIndexChanged
        lblMessage.Text = ""
        Try
            DataGrid1.CurrentPageIndex = e.NewPageIndex
            DataGrid1.EditItemIndex = -1
            PopulateGridList()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        If lblPlNo.Text.Trim.Length = 0 Then
            lblMessage.Text = "Please select PL Number from Grid below before proceeding further !"
            Exit Sub
        End If
        If Val(txtTrnQty.Text) < 0 Then
            lblMessage.Text = "InValid Qty  !"
            Exit Sub
        End If
        Dim Done As Boolean
        Try
            Done = New RWF.GroundBalance().Update(lblUserID.Text, lblConsignee.Text, CDate(lblTranDt.Text), rblTrnType.SelectedItem.Text, lblPlNo.Text, rblWO.SelectedItem.Text, CDbl(txtTrnQty.Text))
            PopulateGridList()
            PLData(lblGroup.Text, CDate(lblTranDt.Text), lblPlNo.Text)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If Done Then
            lblMessage.Text = "Data Saved !"
        End If
        Done = Nothing
    End Sub

End Class
