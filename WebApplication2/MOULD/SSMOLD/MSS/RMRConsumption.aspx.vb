Public Class RMRConsumption
    Inherits System.Web.UI.Page
    Protected WithEvents rblYear As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblMonth As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents rblWO As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents ddlPLs As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlRMR As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblConsignee As System.Web.UI.WebControls.Label
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRMRDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
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
            txtRMRDate.Text = Now.Date
            Dim Group As String = Session("Group")
            Dim strMode As String = Request.QueryString("mode")
            Dim UserId As String = Session("UserID")
            Dim InValid As Boolean = False
            ''''''''''''''''
            Group = "SSMOLD"
            UserId = "073533"
            ''''''''''''''''
            If UserId = "073533" Then
                Try
                    lblConsignee.Text = ProductionConsumables.GetConsignee(Group, UserId)
                    If lblConsignee.Text.Trim.Length = 4 Then InValid = True
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                End Try
                If Not InValid Then
                    Response.Redirect("/mss/logon.aspx")
                End If
                Try
                    SetMonthYear()
                    SetWO()
                    If lblMessage.Text = "No RMRs issued !" Then
                        ddlPLs.Items.Clear()
                        ddlRMR.Items.Clear()
                        DataGrid1.DataSource = Nothing
                        DataGrid1.DataBind()
                        DataGrid2.DataSource = Nothing
                        DataGrid2.DataBind()
                        Exit Sub
                    End If
                    GetPLs()
                    GetPLsRMR()
                    FillGrid()
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                End Try
            Else
                Response.Redirect("/mss/logon.aspx")
            End If
        End If
    End Sub
    Private Sub SetMonthYear()
        Dim dt1, dt2 As DataTable
        'dt1 = ProductionConsumables.GetYearMonth(0)
        'rblMonth.DataSource = dt1
        'rblMonth.DataTextField = dt1.Columns(0).ColumnName
        'rblMonth.DataValueField = dt1.Columns(1).ColumnName
        'rblMonth.DataBind()
        'rblMonth.SelectedIndex = 0
        'dt2 = ProductionConsumables.GetYearMonth(1)
        'rblYear.DataSource = dt2
        'rblYear.DataTextField = dt2.Columns(0).ColumnName
        'rblYear.DataValueField = dt2.Columns(0).ColumnName
        'rblYear.DataBind()
        Dim dt As DataTable = ProductionConsumables.GetRMRYear
        rblYear.DataSource = dt
        rblYear.DataValueField = dt.Columns(0).ColumnName
        rblYear.DataTextField = dt.Columns(0).ColumnName
        rblYear.DataBind()
        dt = ProductionConsumables.GetRMRMonth
        rblMonth.DataSource = dt
        rblMonth.DataValueField = dt.Columns(0).ColumnName
        rblMonth.DataTextField = dt.Columns(1).ColumnName
        rblMonth.DataBind()
        dt.Dispose()
        rblYear.ClearSelection()
        Dim int As Int16
        For int = 0 To rblYear.Items.Count - 1
            If rblYear.Items(int).Value = Now.Year Then
                rblYear.Items(int).Selected = True
                Exit For
            End If
        Next
        int = 0
        rblMonth.ClearSelection()
        For int = 0 To rblMonth.Items.Count - 1
            If rblMonth.Items(int).Value = Now.Month Then
                rblMonth.Items(int).Selected = True
                Exit For
            End If
        Next
        dt1 = Nothing
        dt2 = Nothing
    End Sub
    Private Sub SetWO()
        Dim dt1 As DataTable
        dt1 = ProductionConsumables.GetRMRMonthYearWO(rblMonth.SelectedItem.Value, rblYear.SelectedItem.Value)
        If dt1.Rows.Count > 0 Then
            rblWO.DataSource = dt1
            rblWO.DataTextField = dt1.Columns(0).ColumnName
            rblWO.DataValueField = dt1.Columns(0).ColumnName
            rblWO.DataBind()
            rblWO.SelectedIndex = 0
        Else
            rblWO.Items.Clear()
            lblMessage.Text = "No RMRs issued !"
        End If
        dt1 = Nothing
    End Sub
    Private Sub GetPLs()
        Dim dt1 As DataTable
        dt1 = ProductionConsumables.GetRMRWOPLs(lblConsignee.Text.Trim, rblWO.SelectedItem.Value, rblMonth.SelectedItem.Value, rblYear.SelectedItem.Value)
        ddlPLs.DataSource = dt1
        ddlPLs.DataTextField = dt1.Columns(1).ColumnName
        ddlPLs.DataValueField = dt1.Columns(0).ColumnName
        ddlPLs.DataBind()
        ddlPLs.SelectedIndex = 0
        dt1 = Nothing
    End Sub
    Private Sub GetPLsRMR()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        Dim dt1, dt2 As DataTable
        dt1 = ProductionConsumables.GetRMRPLsRMRNumber(ddlPLs.SelectedItem.Value, rblWO.SelectedItem.Value, rblMonth.SelectedItem.Value, rblYear.SelectedItem.Value, lblConsignee.Text)
        ddlRMR.DataSource = dt1
        ddlRMR.DataTextField = dt1.Columns("RMR").ColumnName
        ddlRMR.DataValueField = dt1.Columns("RMR").ColumnName
        ddlRMR.DataBind()
        ddlRMR.SelectedIndex = 0
        dt1 = Nothing
        dt2 = ProductionConsumables.GetRMRPLsConsumption(ddlPLs.SelectedItem.Value, rblWO.SelectedItem.Value, rblMonth.SelectedItem.Value, rblYear.SelectedItem.Value, lblConsignee.Text)
        DataGrid2.DataSource = dt2
        DataGrid2.DataBind()
        dt2 = Nothing
    End Sub
    Private Sub rblYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblYear.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            SetWO()
            If lblMessage.Text = "No RMRs issued !" Then
                ddlPLs.Items.Clear()
                ddlRMR.Items.Clear()
                DataGrid1.DataSource = Nothing
                DataGrid1.DataBind()
                DataGrid2.DataSource = Nothing
                DataGrid2.DataBind()
                Exit Sub
            End If
            GetPLs()
            GetPLsRMR()
            FillGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub rblMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblMonth.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            SetWO()
            If lblMessage.Text = "No RMRs issued !" Then
                ddlPLs.Items.Clear()
                ddlRMR.Items.Clear()
                DataGrid1.DataSource = Nothing
                DataGrid1.DataBind()
                DataGrid2.DataSource = Nothing
                DataGrid2.DataBind()
                Exit Sub
            End If
            GetPLs()
            GetPLsRMR()
            FillGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub rblWO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblWO.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            GetPLs()
            GetPLsRMR()
            FillGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub ddlPLs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlPLs.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            GetPLsRMR()
            FillGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub FillGrid()
        lblMessage.Text = ""
        Try
            Dim dt As DataTable
            dt = ProductionConsumables.GetRMRNumberDetails(ddlRMR.SelectedItem.Value, ddlPLs.SelectedItem.Value, rblWO.SelectedItem.Value, rblMonth.SelectedItem.Value, rblYear.SelectedItem.Value, lblConsignee.Text)
            DataGrid1.DataSource = dt
            DataGrid1.DataBind()
            dt = Nothing
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub ddlRMR_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlRMR.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            FillGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        Dim Done As Boolean
        Try
            Done = New ProductionConsumables().SaveRMR(ddlRMR.SelectedItem.Value, Val(txtQty.Text), CDate(txtRMRDate.Text))
        Catch exp As Exception
            Done = False
            lblMessage.Text = exp.Message
        End Try
        If Done Then
            Try
                GetPLsRMR()
                FillGrid()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub txtQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQty.TextChanged
        lblMessage.Text = ""
        Try
            txtQty.Text = Val(txtQty.Text)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
End Class
