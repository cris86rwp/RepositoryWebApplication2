Public Class WorkOrder
    Inherits System.Web.UI.Page
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents BtnSave As System.Web.UI.WebControls.Button
    Protected WithEvents LblEdDt As System.Web.UI.WebControls.Label
    Protected WithEvents LblStDt As System.Web.UI.WebControls.Label
    Protected WithEvents TxtQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents LblWO As System.Web.UI.WebControls.Label
    Protected WithEvents Panel2 As System.Web.UI.WebControls.Panel
    Protected WithEvents LblDescription As System.Web.UI.WebControls.Label
    Protected WithEvents DdlProductCode As System.Web.UI.WebControls.DropDownList
    Protected WithEvents RblMake As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents RblType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents RblShopCode As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents RblShop As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents RblYear As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents RblMonth As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents LblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
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


    Private Overloads Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        Session("UserID") = "111111"
        Session("Group") = "PCOPCO"
        If Page.IsPostBack = False Then
            Try
                SetMonthYear()
                SetValues()
            Catch exp As Exception
                LblMessage.Text = exp.Message
            End Try
        End If
    End Sub
    Private Overloads Sub SetMonthYear()
        Dim dt1, dt2 As DataTable
        dt1 = PCO.tables.GetMonthYr(0)
        RblMonth.DataSource = dt1
        RblMonth.DataTextField = dt1.Columns(0).ColumnName
        RblMonth.DataValueField = dt1.Columns(1).ColumnName
        RblMonth.DataBind()
        RblMonth.SelectedIndex = 0
        dt2 = PCO.tables.GetMonthYr(1)
        RblYear.DataSource = dt2
        RblYear.DataTextField = dt2.Columns(0).ColumnName
        RblYear.DataValueField = dt2.Columns(0).ColumnName
        RblYear.DataBind()
        RblYear.SelectedIndex = 0
        dt1 = Nothing
        dt2 = Nothing
    End Sub
    Private Overloads Sub SetValues()
        GetShopCodes()
        GetProductCode()
        If RblType.SelectedItem.Text = "New" Then
            GetWO()
        Else
            If RblType.SelectedItem.Text = "Delete" Then
                LblMessage.Text = "Under Developement !"
            Else
                LblMessage.Text = "Please select any WorkOrder from Grid below to process "
            End If
            LblWO.Text = ""
            LblStDt.Text = ""
            LblEdDt.Text = ""
        End If
        If RblType.SelectedItem.Text = "Resume" Then
            GetSuspendedWorkOrderList()
        Else
            GetWorkOrderList()
        End If
    End Sub
    Private Overloads Sub GetSuspendedWorkOrderList()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        DataGrid1.SelectedIndex = -1
        Try
            DataGrid1.DataSource = PCO.tables.WorkOrderListSuspended(RblMonth.SelectedItem.Value + "/" + RblYear.SelectedItem.Value, RblShopCode.SelectedItem.Value, RblMake.SelectedItem.Text)
            DataGrid1.DataBind()
            DataGrid2.DataSource = PCO.tables.MonthWorkOrders(RblMonth.SelectedItem.Value, RblYear.SelectedItem.Value)
            DataGrid2.DataBind()
        Catch exp As Exception
            LblMessage.Text = exp.Message
        End Try
    End Sub
    Private Overloads Sub GetWorkOrderList()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        DataGrid1.SelectedIndex = -1
        Try
            DataGrid1.DataSource = PCO.tables.WorkOrderList(RblMonth.SelectedItem.Value + "/" + RblYear.SelectedItem.Value, RblShopCode.SelectedItem.Value, RblMake.SelectedItem.Text)
            DataGrid1.DataBind()
            DataGrid2.DataSource = PCO.tables.MonthWorkOrders(RblMonth.SelectedItem.Value, RblYear.SelectedItem.Value)
            DataGrid2.DataBind()
        Catch exp As Exception
            LblMessage.Text = exp.Message
        End Try
    End Sub
    Private Overloads Sub GetShopCodes()
        Dim dt As DataTable
        RblShopCode.DataSource = Nothing
        RblShopCode.DataBind()
        Try
            dt = PCO.tables.GetShopCode(RblShop.SelectedItem.Value)
            RblShopCode.DataSource = dt
            RblShopCode.DataTextField = dt.Columns("ShopCode").ColumnName
            RblShopCode.DataValueField = dt.Columns("CostCentre").ColumnName
            RblShopCode.DataBind()
            RblShopCode.SelectedIndex = 0
        Catch exp As Exception
            LblMessage.Text = exp.Message
        End Try
        dt = Nothing
    End Sub
    Private Overloads Sub GetProductCode()
        Dim dt As DataTable
        DdlProductCode.DataSource = Nothing
        DdlProductCode.DataBind()
        Try
            dt = PCO.tables.FillProductCumbo(RblMonth.SelectedItem.Value, RblYear.SelectedItem.Value, RblShopCode.SelectedItem.Value, RblType.SelectedItem.Text, RblMake.SelectedItem.Text)
            DdlProductCode.DataSource = dt
            DdlProductCode.DataTextField = dt.Columns("Product_code").ColumnName
            DdlProductCode.DataValueField = dt.Columns("Descr").ColumnName
            DdlProductCode.DataBind()
            LblDescription.Text = DdlProductCode.SelectedItem.Value
        Catch exp As Exception
            LblMessage.Text = exp.Message
        End Try
        dt = Nothing
    End Sub
    Private Overloads Sub GetWO()
        LblWO.Text = ""
        LblStDt.Text = ""
        LblEdDt.Text = ""
        If PCO.tables.isHolidayPosted(RblMonth.SelectedItem.Value + "/" + RblYear.SelectedItem.Value) = False Then
            LblMessage.Text = "Holidays for workorder month are not posted yet. Work Order cannot be generated."
            Exit Sub
        End If
        Dim dt As DataTable
        Try
            dt = PCO.tables.GenerateWorkOrder(RblMonth.SelectedItem.Value + "/" + RblYear.SelectedItem.Value, RblShopCode.SelectedItem.Value)
            LblWO.Text = dt.Rows(0)("WO")
            LblStDt.Text = dt.Rows(0)("StDt")
            LblEdDt.Text = dt.Rows(0)("EdDt")
        Catch exp As Exception
            LblMessage.Text = exp.Message
        End Try
        dt = Nothing
    End Sub

    Private Overloads Sub RblMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RblMonth.SelectedIndexChanged
        LblMessage.Text = ""
        If RblYear.Items.Count > 1 Then
            RblYear.SelectedIndex = RblMonth.SelectedIndex
        End If
        Try
            SetValues()
        Catch exp As Exception
            LblMessage.Text = exp.Message
        End Try
    End Sub

    Private Overloads Sub RblShop_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RblShop.SelectedIndexChanged
        LblMessage.Text = ""
        Try
            SetValues()
        Catch exp As Exception
            LblMessage.Text = exp.Message
        End Try
    End Sub

    Private Overloads Sub RblShopCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RblShopCode.SelectedIndexChanged
        LblMessage.Text = ""
        Try
            GetProductCode()
            GetWO()
            If RblType.SelectedItem.Text = "Resume" Then
                GetSuspendedWorkOrderList()
            Else
                GetWorkOrderList()
            End If
        Catch exp As Exception
            LblMessage.Text = exp.Message
        End Try
    End Sub

    Private Overloads Sub RblMake_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RblMake.SelectedIndexChanged
        LblMessage.Text = ""
        Try
            GetProductCode()
            GetWO()
            If RblType.SelectedItem.Text = "Resume" Then
                GetSuspendedWorkOrderList()
            Else
                GetWorkOrderList()
            End If
        Catch exp As Exception
            LblMessage.Text = exp.Message
        End Try
    End Sub

    Private Overloads Sub RblYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RblYear.SelectedIndexChanged
        LblMessage.Text = ""
        Try
            SetValues()
        Catch exp As Exception
            LblMessage.Text = exp.Message
        End Try
    End Sub

    Private Overloads Sub DdlProductCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DdlProductCode.SelectedIndexChanged
        LblMessage.Text = ""
        LblDescription.Text = DdlProductCode.SelectedItem.Value
        If PCO.tables.CheckBOM(DdlProductCode.SelectedItem.Text) = False Then
            LblMessage.Text = "Bill of material not available, RMR's cannot be generated !"
        End If
    End Sub

    Private Overloads Sub RblType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RblType.SelectedIndexChanged
        LblMessage.Text = ""
        Try
            SetValues()
        Catch exp As Exception
            LblMessage.Text = exp.Message
        End Try
        DataGrid1.SelectedIndex = -1
    End Sub

    Private Overloads Sub DataGrid1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.ItemCommand
        LblMessage.Text = ""
        If RblType.SelectedItem.Text = "New" Then LblMessage.Text = "Not allowed For Editing when selection of Type is 'New' "
        If LblMessage.Text <> "" Then Exit Sub
        LblWO.Text = ""
        LblStDt.Text = ""
        LblEdDt.Text = ""
        Try
            Select Case e.CommandName
                Case "Select"
                    LblMessage.Text = PCO.tables.CheckWorkOrder(e.Item.Cells(1).Text, RblType.SelectedItem.Text)
                    If LblMessage.Text.Trim.Length = 0 Then
                        LblWO.Text = e.Item.Cells(1).Text
                        Dim i As Integer
                        i = 0
                        DdlProductCode.ClearSelection()
                        LblDescription.Text = ""
                        For i = 0 To DdlProductCode.Items.Count - 1
                            If DdlProductCode.Items(i).Text = e.Item.Cells(2).Text Then
                                DdlProductCode.Items(i).Selected = True
                                LblDescription.Text = DdlProductCode.SelectedItem.Value
                                Exit For
                            End If
                        Next
                        i = Nothing
                        LblStDt.Text = e.Item.Cells(6).Text
                        LblEdDt.Text = e.Item.Cells(7).Text
                        TxtQty.Text = e.Item.Cells(8).Text
                    End If
            End Select
        Catch exp As Exception
            LblMessage.Text = exp.Message
        End Try
    End Sub

    Private Overloads Sub TxtQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtQty.TextChanged
        LblMessage.Text = ""
        Try
            LblMessage.Text = PCO.tables.CheckWorkOrderQty(LblWO.Text, RblType.SelectedItem.Text, Val(TxtQty.Text))
            If LblMessage.Text.Trim.Length > 0 Then TxtQty.Text = ""
        Catch exp As Exception
            LblMessage.Text = exp.Message
        End Try
    End Sub

    Private Overloads Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        LblMessage.Text = ""
        If LblDescription.Text.Trim.Length = 0 Then
            LblMessage.Text = "InValid Description !"
            Exit Sub
        ElseIf LblStDt.Text.Trim.Length = 0 Then
            LblMessage.Text = "InValid Start Date !"
            Exit Sub
        ElseIf LblEdDt.Text.Trim.Length = 0 Then
            LblMessage.Text = "InValid Start Date !"
            Exit Sub
        ElseIf TxtQty.Text.Trim.Length = 0 Then
            LblMessage.Text = "InValid Quantity !"
            Exit Sub
        ElseIf PCO.tables.isHolidayPosted(RblMonth.SelectedItem.Value + "/" + RblYear.SelectedItem.Value) = False Then
            LblMessage.Text = "Holidays for workorder month are not posted yet. Work Order cannot be generated."
            Exit Sub
        End If
        LblMessage.Text = PCO.tables.CheckWorkOrderQty(LblWO.Text, RblType.SelectedItem.Text, Val(TxtQty.Text))
        If LblMessage.Text.Trim.Length > 0 Then TxtQty.Text = ""
        LblMessage.Text = PCO.tables.CheckWorkOrder(LblWO.Text.Trim, RblType.SelectedItem.Text)
        If LblMessage.Text.Trim.Length > 0 Then TxtQty.Text = ""
        Try
            LblMessage.Text = New PCO.WorkOrder().Save(RblType.SelectedItem.Text, LblWO.Text, Val(TxtQty.Text), DdlProductCode.SelectedItem.Text, DdlProductCode.SelectedItem.Value, RblShopCode.SelectedItem.Value, CDate(LblStDt.Text), CDate(LblEdDt.Text))
            If PCO.tables.CheckBOM(DdlProductCode.SelectedItem.Text) = False Then
                LblMessage.Text &= " Bill of material not available, RMR's cannot be generated !"
            End If
            If LblMessage.Text.EndsWith("Successfully") Then
                SetMonthYear()
                RblType.SelectedIndex = 0
                SetValues()
            End If
        Catch exp As Exception
            LblMessage.Text &= exp.Message
        End Try
    End Sub

End Class
