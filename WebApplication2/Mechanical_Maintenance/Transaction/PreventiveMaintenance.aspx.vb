Public Class PreventiveMaintenance
    Inherits System.Web.UI.Page

    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents lblMode As System.Web.UI.WebControls.Label
    Protected WithEvents txtFrom As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTo As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnClear As System.Web.UI.WebControls.Button
    Protected WithEvents btnExit As System.Web.UI.WebControls.Button
    Protected WithEvents txtAttendent As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents grdSpares As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtpl_qty As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPLNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFrom_time As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTo_time As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWorkOrderNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboMachine As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboAssembly As System.Web.UI.WebControls.DropDownList
    Protected WithEvents radType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents ddlShopCode As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtWork_done As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboWorkOrderNo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblDept As System.Web.UI.WebControls.Label
    Protected WithEvents lblUserID As System.Web.UI.WebControls.Label
    Protected WithEvents lblGroup As System.Web.UI.WebControls.Label
    Protected WithEvents txtSupervisor As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboSpares As System.Web.UI.WebControls.DropDownList
    Protected WithEvents rblSpareType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents lblMGroup As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage1 As System.Web.UI.WebControls.Label
    Protected WithEvents txtSpareCost As System.Web.UI.WebControls.TextBox
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


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim grp As String
        Dim plQty As Integer
        Dim PlNumber As String
        lblUserID.Visible = False
        lblGroup.Visible = False
        lblMode.Text = Request.QueryString("mode")
        lblUserID.Text = Session("UserID")
        '  lblMode.Text = "edit"
        lblMode.Text = "add"
        'Session("group") = "MW1"
        'lblUserID.Text = "078844"
        If Session("group") = "RTSHOP" Then
            Session("group") = "MRT"
        End If
        grp = Session("group")
        lblDept.Text = grp.Substring(0, 1)
        lblDept.Text = "MRT"
        lblDept.Visible = False
        lblMGroup.Text = grp.Substring(1)
        lblUserID.Text = Session("UserID")
        lblGroup.Text = Session("group")
        If Not Page.IsPostBack Then
            Try
                If lblMode.Text = "add" Then
                    lblMode.Text = "add"
                    txtFrom.Visible = True
                    cboWorkOrderNo.Visible = False
                    txtWorkOrderNo.Visible = True
                    txtWorkOrderNo.Enabled = False
                    txtFrom.Text = Date.Today
                    txtTo.Text = Date.Today
                    txtFrom_time.Text = "00:00"
                    txtTo_time.Text = "00:00"
                    txtDate.Text = Date.Today
                ElseIf lblMode.Text = "edit" Then
                    lblMode.Text = "edit"
                    txtFrom.Visible = True
                    cboWorkOrderNo.Visible = True
                    txtWorkOrderNo.Visible = False
                    txtFrom_time.Visible = True
                    txtpl_qty.Text = 0
                End If
                PopulateLocation(lblMode.Text.Trim, lblMGroup.Text)
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub


    Protected Sub dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())
    End Sub

    Private Sub PopulateLocation(ByVal mode As String, ByVal group As String)
        lblMessage.Text = ""
        lblMessage1.Text = ""
        Dim ds As DataSet
        Try
            ds = Maintenance.tables.Location(mode, group, "U")
            ddlShopCode.DataSource = ds.Tables(0).DefaultView
            ddlShopCode.DataTextField = ds.Tables(0).Columns("Location").ColumnName
            ddlShopCode.DataValueField = ds.Tables(0).Columns("code").ColumnName
            ddlShopCode.DataBind()
            ddlShopCode.Items.Insert(0, "Select")
            Dim memo As Int16
            If mode = "add" Then
                If Not IsDBNull(ds.Tables(1).Rows(0)(0)) Then
                    memo = ds.Tables(1).Rows(0)(0) + 1
                Else
                    memo = 1
                End If
                txtWorkOrderNo.Text = memo
            Else
                txtWorkOrderNo.Visible = False
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub ddlShopCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlShopCode.SelectedIndexChanged
        Clear()
        lblMessage.Text = ""
        lblMessage1.Text = ""
        If ddlShopCode.SelectedItem.Text.ToLower = "select" Then
            lblMessage.Text = "Please select Machine ID to save data !"
            lblMessage1.Text = "Please select Machine ID to save data !"
        Else
            If txtDate.Text.Trim.Length = 0 Then
                lblMessage.Text = "Please fill date !"
                lblMessage1.Text = "Please fill date !"
                ddlShopCode.SelectedIndex = 0
                Exit Sub
            Else
                If lblMode.Text.ToLower.Equals("edit") Then
                    PopulateWorkOrders()
                End If
                PopulateMachineCode(lblMode.Text, Trim(ddlShopCode.SelectedItem.Value), lblGroup.Text.Trim)
                cboAssembly.Items.Clear()
            End If
        End If
    End Sub

    Private Sub PopulateMachineCode(ByVal mode As String, ByVal shopcode As String, ByVal Group As String)
        cboMachine.Items.Clear()
        Dim dt As DataTable
        Try
            dt = Maintenance.tables.UnSchMachineCode(mode, shopcode, CDate(txtDate.Text), lblGroup.Text.Trim)
            cboMachine.DataSource = dt.DefaultView
            cboMachine.DataValueField = dt.Columns("machine_code").ColumnName
            cboMachine.DataTextField = dt.Columns("Description").ColumnName
            cboMachine.DataBind()
            cboMachine.Items.Insert(0, "Select")
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
        End Try
    End Sub

    Private Sub cboMachine_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMachine.SelectedIndexChanged
        lblMessage.Text = ""
        lblMessage1.Text = ""
        If lblMode.Text = "edit" Then
            If cboWorkOrderNo.SelectedItem.Text.ToLower = "select" Then
                lblMessage.Text = "Please select workorder number !"
                cboMachine.SelectedIndex = 0
                Exit Sub
            Else
                Dim dt As New DataTable()
                Dim dtSpares As New DataTable()
                Dim i As Integer
                Try
                    dt = Maintenance.tables.GetUnSchDetails(lblMGroup.Text, cboWorkOrderNo.SelectedItem.Text, CDate(txtDate.Text))
                    Dim from, too As DateTime
                    Dim from1, too1 As Array
                    cboAssembly.Items.Clear()
                    Try
                        PopulateSubAssembly()
                        If IsNothing(Trim(dt.Rows(0)("sub_assembly"))) = False Then
                            If Trim(dt.Rows(0)("sub_assembly")).Length > 0 Then
                                For i = 0 To cboAssembly.Items.Count
                                    If cboAssembly.Items(i).Value.Trim = Trim(dt.Rows(0)("sub_assembly")) Then
                                        cboAssembly.SelectedIndex = i
                                        Exit For
                                    End If
                                Next
                            End If
                        End If
                    Catch exp As Exception
                        lblMessage.Text = exp.Message
                    End Try
                    If lblMessage.Text.StartsWith("Index") Then
                        lblMessage.Text = ""
                    End If
                    from = dt.Rows(0)("date_from")
                    too = dt.Rows(0)("date_to")
                    txtWork_done.Text = dt.Rows(0)("work_done")
                    txtAttendent.Text = dt.Rows(0)("attendent")
                    txtRemarks.Text = dt.Rows(0)("remarks")
                    Dim b As Int16 = 0
                    For b = 0 To radType.Items.Count - 1
                        If radType.Items(b).Value.Trim = dt.Rows(0)("maintenance_type") Then
                            radType.Items(b).Selected = True
                            Exit For
                        End If
                    Next
                    If from.ToString.Substring(11, 5) = "00:00" Then
                        txtFrom.Text = from
                    Else
                        from1 = Split(from, " ")
                        txtFrom.Text = from1(0)
                        txtFrom_time.Text = from1(1)
                    End If

                    If too.ToString.Substring(11, 5) = "00:00" Then
                        txtTo.Text = too
                    Else
                        too1 = Split(too, " ")
                        txtTo.Text = too1(0)
                        txtTo_time.Text = too1(1)
                    End If
                    dtSpares = Maintenance.tables.Spares(lblGroup.Text.Trim, cboMachine.SelectedItem.Value.Trim)
                    cboSpares.DataSource = dtSpares
                    cboSpares.DataTextField = dtSpares.Columns("pl_desc").ColumnName
                    cboSpares.DataValueField = dtSpares.Columns("pl_number").ColumnName
                    cboSpares.DataBind()
                    i = cboSpares.Items.Count
                    cboSpares.Items.Insert(0, "Select")
                    If i = 0 Then
                        lblMessage.Text = "No Spares Exist For The Given Date..."
                    End If
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                Finally
                    dtSpares.Dispose()
                    dt.Dispose()
                End Try
            End If
        Else
            Try
                cboAssembly.Items.Clear()
                PopulateSubAssembly()
                get_Spares()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            Finally

            End Try
        End If
    End Sub

    Private Sub FillDDLs(ByVal dt As DataTable, ByVal ddl As DropDownList)
        ddl.DataSource = dt.DefaultView
        ddl.DataTextField = dt.Columns(1).ColumnName
        ddl.DataValueField = dt.Columns(0).ColumnName
        ddl.DataBind()
    End Sub

    Private Sub get_Spares()
        Dim group As String
        Dim dt As DataTable
        group = lblDept.Text + lblMGroup.Text
        Try
            cboSpares.Items.Clear()
            If cboAssembly.SelectedIndex < 1 Then
                dt = Maintenance.tables.Spares(group, cboMachine.SelectedItem.Value)
            Else
                dt = Maintenance.tables.Spares(group, cboMachine.SelectedItem.Value, cboAssembly.SelectedItem.Value)
            End If
            FillDDLs(dt, cboSpares)
            cboSpares.Items.Insert(0, "select")
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
        End Try
    End Sub

    Private Sub PopulateSubAssembly()
        Dim dt As DataTable
        Dim grp As String
        grp = lblDept.Text + lblMGroup.Text
        Try
            dt = Maintenance.tables.GetUnSchSubAssemblyList(lblMode.Text, cboMachine.SelectedItem.Value, grp, ddlShopCode.SelectedItem.Value)
            cboAssembly.DataSource = dt
            cboAssembly.DataTextField = dt.Columns("description").ColumnName
            cboAssembly.DataValueField = dt.Columns("code").ColumnName
            cboAssembly.DataBind()
            cboAssembly.Items.Insert(0, "Select")
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
        End Try
    End Sub

    Private Sub ClearDetails()
        txtFrom.Text = ""
        txtFrom_time.Text = ""
        txtTo.Text = ""
        txtTo_time.Text = ""
    End Sub

    Private Function CheckDate() As Boolean
        Dim fr_dt, to_dt As DateTime
        Dim wo_dt As Date
        Try
            fr_dt = txtFrom.Text & " " & txtFrom_time.Text
            to_dt = txtTo.Text & " " & txtTo_time.Text
            wo_dt = CDate(txtDate.Text)
            If fr_dt.Hour < 6 AndAlso fr_dt.Date.AddDays(-1) = wo_dt.Date Then
                CheckDate = True
            ElseIf fr_dt.Hour >= 6 AndAlso fr_dt.Date = wo_dt.Date Then
                CheckDate = True
            ElseIf to_dt.Hour < 6 AndAlso to_dt.Date.AddDays(-1) = wo_dt.Date Then
                CheckDate = True
            ElseIf to_dt.Hour >= 6 AndAlso to_dt.Date = wo_dt.Date Then
                CheckDate = True
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try

    End Function

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        lblMessage1.Text = ""
        If Not CheckDate() Then
            lblMessage.Text = "Work Order date does not match with From Date time !"
            lblMessage1.Text = "Work Order date does not match with From Date time !"
            Exit Sub
        End If
        Dim fr_dt, to_dt As DateTime
        fr_dt = txtFrom.Text & " " & txtFrom_time.Text
        to_dt = txtTo.Text & " " & txtTo_time.Text
        If cboMachine.SelectedItem.Text.ToLower = "select" Then
            lblMessage.Text = "Please select Machine ID to save data !"
            lblMessage1.Text = "Please select Machine ID to save data !"
        ElseIf ddlShopCode.SelectedItem.Value.ToLower = "select" Then
            lblMessage.Text = "Please select SHOP CODE to save data !"
            lblMessage1.Text = "Please select SHOP CODE to save data !"
        ElseIf fr_dt > Now Then
            lblMessage.Text = "From date-time is greater than current time !"
            lblMessage1.Text = "From date-time is greater than current time !"
        ElseIf to_dt > Now Then
            lblMessage.Text = " To date-time is greater than current time !"
            lblMessage1.Text = "To date-time is greater than current time !"
        ElseIf fr_dt > to_dt Then
            lblMessage.Text = "From date-time   is greater thano To date-time !"
            lblMessage1.Text = "From date-time   is greater thano To date-time !"
        Else
            Dim Done As Boolean
            Dim cnt As Int16
            Dim dt As New DataTable()
            Dim dr As DataRow
            Dim oUnSch As New Maintenance.UnScheduled()
            Try
                Try
                    dt.TableName = "spares"
                    dt.Columns.Add("PlNumber", GetType(System.String))
                    dt.Columns.Add("Quantity", GetType(System.Decimal))
                    dt.Columns.Add("ReplacedQuantity", GetType(System.Decimal))
                    dt.Columns.Add("SpareType", GetType(System.String))
                    dt.Columns.Add("SpareCost", GetType(System.Decimal))
                    If grdSpares.Items.Count > 0 Then
                        For cnt = 0 To grdSpares.Items.Count - 1
                            dr = dt.NewRow
                            dr("PlNumber") = grdSpares.Items(cnt).Cells(0).Text
                            dr("Quantity") = grdSpares.Items(cnt).Cells(3).Text
                            dr("ReplacedQuantity") = grdSpares.Items(cnt).Cells(3).Text
                            dr("SpareType") = grdSpares.Items(cnt).Cells(4).Text
                            dr("SpareCost") = grdSpares.Items(cnt).Cells(5).Text
                            dt.Rows.Add(dr)
                        Next
                    End If
                    oUnSch.SparesList = dt
                    Done = True
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                Finally
                    dt.Dispose()
                    dr = Nothing
                End Try
                If Done = True Then
                    Done = False
                Else
                    oUnSch = Nothing
                    Exit Sub
                End If

                oUnSch.Machinery.GroupCode = lblMGroup.Text.Trim
                If lblMode.Text = "add" Then
                    oUnSch.Number = txtWorkOrderNo.Text.Trim
                    oUnSch.SparesNumber = txtWorkOrderNo.Text.Trim
                Else
                    oUnSch.Number = IIf(IsNothing(cboWorkOrderNo.SelectedItem.Value), "", cboWorkOrderNo.SelectedItem.Value)
                    oUnSch.SparesNumber = IIf(IsNothing(cboWorkOrderNo.SelectedItem.Value), "", cboWorkOrderNo.SelectedItem.Value)
                End If
                oUnSch.MachineCode = cboMachine.SelectedItem.Value
                oUnSch.Machinery.Location = ddlShopCode.SelectedItem.Value
                oUnSch.SubAssembly = IIf((cboAssembly.SelectedItem.Value.ToLower = "select"), "", cboAssembly.SelectedItem.Value)
                oUnSch.FromDate = fr_dt
                oUnSch.ToDate = to_dt
                oUnSch.WorkDone = txtWork_done.Text.Trim
                oUnSch.Attendent = txtAttendent.Text.Trim
                oUnSch.Remarks = txtRemarks.Text
                oUnSch.MaintenanceType = radType.SelectedItem.Value
                oUnSch.WODate = txtDate.Text.Trim
                oUnSch.Operator1 = lblUserID.Text
                oUnSch.Group = lblMGroup.Text
                oUnSch.Type = "U"
                oUnSch.Supervisor = txtSupervisor.Text.Trim
                'If oUnSch.SavePMDoneDetails(oUnSch.Number) Then
                If oUnSch.SaveWorkDoneDetails(oUnSch.Number) Then

                    Done = True
                End If
                PopulateLocation(lblMode.Text.Trim, lblMGroup.Text)
                ddlShopCode.SelectedIndex = 0
            Catch exp As Exception
                lblMessage.Text = exp.Message
            Finally
                dt.Dispose()
                oUnSch = Nothing
            End Try
            If Done Then
                lblMessage.Text = "Record Updated..."
                lblMessage1.Text = "Record Updated... "
                'Clear()
                grdSpares.DataSource = Nothing
                grdSpares.DataBind()
                ClearDetails()
            Else
                lblMessage.Text = "Record Updatedtion Failed ! "
                lblMessage1.Text = "Record Updatedtion Failed ! "
            End If
        End If

    End Sub

    Private Sub Clear()
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim cnt As Int16
        dt.TableName = "spares"
        dt.Columns.Add("Pl Number")
        dt.Columns.Add("Description")
        dt.Columns.Add("Unit")
        dt.Columns.Add("Quantity")
        grdSpares.DataSource = dt
        grdSpares.DataBind()

        txtAttendent.Text = ""
        txtRemarks.Text = ""
        txtWork_done.Text = ""
        txtPLNumber.Text = ""
        txtpl_qty.Text = ""
        txtSpareCost.Text = ""
        cboAssembly.Items.Clear()
        cboMachine.Items.Clear()
        cboSpares.Items.Clear()
    End Sub

    Private Sub cboAssembly_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAssembly.SelectedIndexChanged
        txtPLNumber.Text = ""
        txtpl_qty.Text = ""
        'get_Spares()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            PopulateDatatable()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub PopulateDatatable()
        Dim dt As New DataTable()
        Dim dtPl As New DataTable()
        Dim dr As DataRow
        Dim cnt As Int16
        Dim desc, unit As String
        Try
            dt.TableName = "spares"
            dt.Columns.Add("Pl Number", GetType(System.String))
            dt.Columns.Add("Description", GetType(System.String))
            dt.Columns.Add("Unit", GetType(System.String))
            dt.Columns.Add("Quantity", GetType(System.Decimal))
            dt.Columns.Add("SpareType", GetType(System.String))
            dt.Columns.Add("SpareCost", GetType(System.Decimal))
            If grdSpares.Items.Count > 0 Then
                For cnt = 0 To grdSpares.Items.Count - 1
                    If grdSpares.Items(cnt).Cells(0).Text.Trim <> Trim(txtPLNumber.Text) Then
                        dr = dt.NewRow
                        dr("Pl Number") = grdSpares.Items(cnt).Cells(0).Text
                        dr("Description") = grdSpares.Items(cnt).Cells(1).Text
                        dr("Unit") = grdSpares.Items(cnt).Cells(2).Text
                        dr("Quantity") = grdSpares.Items(cnt).Cells(3).Text
                        dr("SpareType") = grdSpares.Items(cnt).Cells(4).Text
                        dr("SpareCost") = grdSpares.Items(cnt).Cells(5).Text
                        dt.Rows.Add(dr)
                    End If
                Next
            End If

            dtPl = Maintenance.tables.PLDetails(Trim(txtPLNumber.Text))

            If Trim(IIf(IsDBNull(dtPl.Rows(0)("pl_number")), "", dtPl.Rows(0)("pl_number"))) = "" Then
                lblMessage.Text = "Pl Number do not exists..."
                Exit Sub
            Else
                desc = Trim(IIf(IsDBNull(dtPl.Rows(0)("PlShortName")), "", dtPl.Rows(0)("PlShortName")))
                unit = Trim(IIf(IsDBNull(dtPl.Rows(0)("PlUnitName")), "", dtPl.Rows(0)("PlUnitName")))
            End If

            dr = dt.NewRow
            dr("Pl Number") = txtPLNumber.Text
            dr("Description") = Trim(desc)
            dr("Unit") = Trim(unit)
            dr("Quantity") = Val(txtpl_qty.Text)
            dr("SpareType") = rblSpareType.SelectedItem.Text
            dr("SpareCost") = Val(txtSpareCost.Text)
            dt.Rows.Add(dr)
            grdSpares.DataSource = dt
            grdSpares.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
            dtPl.Dispose()
        End Try
    End Sub

    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        lblMessage.Text = ""
        lblMessage1.Text = ""
        Clear()
        ddlShopCode.SelectedIndex = 0
        Dim dt As Date
        Try
            dt = CDate(txtDate.Text)
            txtDate.Text = dt
            If lblMode.Text.Equals("edit") Then
                If ddlShopCode.SelectedItem.Text.ToLower = "select" Then
                    lblMessage.Text = "Please select Shop Code "
                Else
                    PopulateWorkOrders()
                End If
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
            If lblMode.Text.Equals("edit") Then
                cboWorkOrderNo.Items.Clear()
            End If
            txtDate.Text = ""
        End Try
    End Sub

    Public Sub PopulateWorkOrders()
        Dim dt As DataTable
        Dim count As Integer
        cboWorkOrderNo.Items.Clear()
        dt = Maintenance.tables.UnSchWorkorders(lblMGroup.Text.Trim, CDate(txtDate.Text), ddlShopCode.SelectedItem.Value.Trim)
        cboWorkOrderNo.DataSource = dt.DefaultView
        cboWorkOrderNo.DataTextField = dt.Columns("workorder_number").ColumnName
        cboWorkOrderNo.DataValueField = dt.Columns("workorder_number").ColumnName
        cboWorkOrderNo.DataBind()
        count = cboWorkOrderNo.Items.Count
        cboWorkOrderNo.Items.Insert(0, "Select")
        txtWorkOrderNo.Visible = False
        If count = 0 Then
            lblMessage.Text = "No WorkOrders Exist For The Given Date..."
        End If
        dt.Dispose()
    End Sub

    Private Sub cboWorkOrderNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboWorkOrderNo.SelectedIndexChanged
        lblMessage.Text = ""
        lblMessage1.Text = ""
        If cboWorkOrderNo.SelectedItem.Text.ToLower = "select" Then
            lblMessage.Text = "Please select workorder !"
            Exit Sub
        ElseIf ddlShopCode.SelectedItem.Text.ToLower = "select" Then
            lblMessage.Text = "Please select Location !"
            cboWorkOrderNo.SelectedIndex = 0
            Exit Sub
        Else
            Dim dt, dtSpares As DataTable
            Dim i As Integer
            Try
                dt = Maintenance.tables.GetUnSchDetails(lblMGroup.Text, cboWorkOrderNo.SelectedItem.Text, CDate(txtDate.Text))
                For i = 0 To cboMachine.Items.Count - 1
                    If cboMachine.Items(i).Value.Trim = Trim(dt.Rows(0)("machine_code")) Then
                        cboMachine.SelectedIndex = i
                        Exit For
                    End If
                Next
                cboAssembly.Items.Clear()
                PopulateSubAssembly()
                If IsNothing(Trim(dt.Rows(0)("sub_assembly"))) = False Then
                    For i = 0 To cboAssembly.Items.Count - 1
                        If cboAssembly.Items(i).Value.Trim = Trim(dt.Rows(0)("sub_assembly")) Then
                            cboAssembly.SelectedIndex = i
                            Exit For
                        End If
                    Next
                End If
                Dim from, too As DateTime
                Dim from1, too1 As Array
                from = dt.Rows(0)("date_from")
                too = dt.Rows(0)("date_to")
                txtWork_done.Text = dt.Rows(0)("work_done")
                txtAttendent.Text = dt.Rows(0)("attendent")
                txtRemarks.Text = dt.Rows(0)("remarks")
                Dim b As Int16 = 0
                For b = 0 To radType.Items.Count - 1
                    If radType.Items(b).Value.Trim = dt.Rows(0)("maintenance_type") Then
                        radType.Items(b).Selected = True
                        Exit For
                    End If
                Next
                If from.ToString.Substring(11, 5) = "00:00" Then
                    txtFrom.Text = from
                Else
                    from1 = Split(from, " ")
                    txtFrom.Text = from1(0)
                    txtFrom_time.Text = Left(from1(1), 5)
                End If

                If too.ToString.Substring(11, 5) = "00:00" Then
                    txtTo.Text = too
                Else
                    too1 = Split(too, " ")
                    txtTo.Text = too1(0)
                    txtTo_time.Text = Left(too1(1), 5)
                End If

                dtSpares = Maintenance.tables.WOSpares("U", cboWorkOrderNo.SelectedItem.Text.Trim, lblMGroup.Text.Trim)
                cboSpares.DataSource = dtSpares
                cboSpares.DataTextField = dtSpares.Columns("pl_desc").ColumnName
                cboSpares.DataValueField = dtSpares.Columns("pl_number").ColumnName
                cboSpares.DataBind()
                i = cboSpares.Items.Count
                cboSpares.Items.Insert(0, "Select")
                If i = 0 Then
                    lblMessage.Text = "No Spares Exist For The Given Date..."
                End If
            Catch exp As Exception
                lblMessage.Text = exp.Message
            Finally
                dt.Dispose()
                dtSpares.Dispose()
            End Try
        End If
    End Sub

    Private Sub txtpl_qty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpl_qty.TextChanged
        Session("plQty") = txtpl_qty.Text
    End Sub

    Private Sub cboSpares_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSpares.SelectedIndexChanged
        lblMessage.Text = ""
        lblMessage1.Text = ""
        txtpl_qty.Text = ""
        txtPLNumber.Text = ""
        Dim strCmd As String
        If cboSpares.SelectedIndex = 0 Then
            lblMessage.Text = "Please select Spares List !"
            Exit Sub
        Else
            Dim dt As New DataTable()
            Dim group As String
            group = lblDept.Text + lblMGroup.Text
            Try
                txtPLNumber.Text = cboSpares.SelectedItem.Value
                If cboAssembly.SelectedItem.Text = "Select" Then
                    dt = Maintenance.tables.Spares(group, cboMachine.SelectedItem.Value, , txtPLNumber.Text.Trim)
                Else
                    dt = Maintenance.tables.Spares(group, cboMachine.SelectedItem.Value, cboAssembly.SelectedItem.Value.Trim, txtPLNumber.Text.Trim)
                End If
                If lblMode.Text.Equals("edit") Then
                    dt = Maintenance.tables.WOSpares("U", cboWorkOrderNo.SelectedItem.Value, lblMGroup.Text, cboSpares.SelectedItem.Value)
                    If Not IsDBNull(dt.Rows(0)("replaced_quantity")) Then
                        txtpl_qty.Text = dt.Rows(0)("replaced_quantity")
                        'Session("plQty") = txtpl_qty.Text
                    End If
                Else
                    If Not IsDBNull(dt.Rows(0)("qtyreqd")) Then
                        txtpl_qty.Text = dt.Rows(0)("qtyreqd")
                        'Session("plQty") = txtpl_qty.Text
                    End If
                End If
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub txtFrom_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFrom.TextChanged
        Dim dt1 As Date
        Dim dt1IsValid As Boolean
        dt1IsValid = False
        lblMessage.Text = ""
        lblMessage1.Text = ""
        Try
            dt1 = txtFrom.Text.Trim
            txtFrom.Text = dt1
            dt1IsValid = True
            If dt1 > Today.Date Then
                lblMessage.Text = "From Date:'" & txtFrom.Text.Trim & "' Can Not Be Greater Than Current Date. "
                lblMessage1.Text = "From Date:'" & txtFrom.Text.Trim & "' Can Not Be Greater Than Current Date. "
                txtFrom.Text = ""
            End If
        Catch exp As Exception
            If exp.Message.StartsWith("Cast") Then
                If dt1IsValid = False Then
                    lblMessage.Text &= " From Date:'" & txtFrom.Text.Trim & "'  is not Valid. "
                    lblMessage1.Text &= " From Date:'" & txtFrom.Text.Trim & "'  is not Valid. "
                    txtFrom.Text = ""
                End If
            End If
        Finally
            dt1 = Nothing
            dt1IsValid = Nothing
        End Try
    End Sub

    Private Sub txtTo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTo.TextChanged
        Dim dt1 As Date
        Dim dt1IsValid As Boolean
        dt1IsValid = False
        lblMessage.Text = ""
        lblMessage1.Text = ""
        Try
            dt1 = txtTo.Text.Trim
            txtTo.Text = dt1
            dt1IsValid = True
            If dt1 > Today.Date Then
                lblMessage.Text = "To Date:'" & txtTo.Text.Trim & "' Can Not Be Greater Than Current Date. "
                lblMessage1.Text = "To Date:'" & txtTo.Text.Trim & "' Can Not Be Greater Than Current Date. "
                txtTo.Text = ""
            End If

        Catch exp As Exception
            If exp.Message.StartsWith("Cast") Then
                If dt1IsValid = False Then
                    lblMessage.Text &= " To Date:'" & txtTo.Text.Trim & "'  is not Valid. "
                    lblMessage1.Text &= " To Date:'" & txtTo.Text.Trim & "'  is not Valid. "
                    txtTo.Text = ""
                End If
            End If
        Finally
            dt1 = Nothing
            dt1IsValid = Nothing
        End Try
    End Sub

End Class