Public Class machineModified
    Inherits System.Web.UI.Page
    Protected WithEvents btnExit As System.Web.UI.WebControls.Button
    Protected WithEvents btnClear As System.Web.UI.WebControls.Button
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents txtWork_done As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtObservation As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFrom As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtAttendent As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtApproved As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtAdvantages As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMode As System.Web.UI.WebControls.Label
    Dim strsql, strmode As String
    Protected WithEvents txtPLNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents grdSpares As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblMaintenance_group As System.Web.UI.WebControls.Label
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTo_time As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFrom_time As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPl_qty As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMessage1 As System.Web.UI.WebControls.Label
    Protected WithEvents ddlMachineCode As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlAssembly As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboSpares As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblUserID As System.Web.UI.WebControls.Label
    Protected WithEvents lblDept As System.Web.UI.WebControls.Label
    Protected WithEvents ddlShopCode As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboWorkOrderNo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblWorkOrderNo As System.Web.UI.WebControls.Label
    Protected WithEvents lblGroup As System.Web.UI.WebControls.Label
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList


    Dim grp As String
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
        lblUserID.Visible = False
        lblDept.Visible = False
        lblGroup.Visible = False
        lblUserID.Text = Session("UserID")
        strmode = Request.QueryString("mode")
        'Session("group") = "MW1"
        strmode = "add"
        'strmode = "edit"
        'lblUserID.Text = "078844"
        grp = Session("group")
        lblGroup.Text = Session("group")
        lblDept.Text = grp.Substring(0, 1)
        lblMaintenance_group.Text = grp.Substring(1)
        If Not Page.IsPostBack Then
            Try
                If strmode.Equals("add") Then
                    lblMode.Text = "add"
                    txtDate.Text = Date.Today
                    cboWorkOrderNo.Visible = False
                ElseIf strmode.Equals("edit") Then
                    lblMode.Text = "edit"
                    cboWorkOrderNo.Visible = True
                End If
                PopulateLocation(strmode.Trim, lblMaintenance_group.Text)
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            txtFrom.Text = Date.Today
            txtTo.Text = Date.Today
            txtFrom_time.Text = "00:00"
            txtTo_time.Text = "00:00"
        End If
    End Sub
    Private Sub PopulateLocation(ByVal mode As String, ByVal group As String)
        lblMessage.Text = ""
        Dim ds As DataSet
        Try
            ds = Maintenance.tables.Location(mode, group, "M")
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
                lblWorkOrderNo.Text = memo
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

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
                If strmode.ToLower.Equals("edit") Then
                    PopulateWorkOrders()
                End If
                If txtDate.Text.Trim.Length > 0 Then
                    PopulateMachineCode(strmode, Trim(ddlShopCode.SelectedItem.Value), lblGroup.Text)
                    ddlAssembly.Items.Clear()
                End If
            End If
        End If
    End Sub

    Private Sub PopulateMachineCode(ByVal mode As String, ByVal shopcode As String, ByVal Group As String)
        ddlMachineCode.Items.Clear()
        Dim dt As DataTable
        Try
            dt = Maintenance.tables.MachineModification(mode, shopcode, CDate(txtDate.Text), lblGroup.Text)
            ddlMachineCode.DataSource = dt.DefaultView
            ddlMachineCode.DataValueField = dt.Columns("machine_code").ColumnName
            ddlMachineCode.DataTextField = dt.Columns("Description").ColumnName
            ddlMachineCode.DataBind()
            ddlMachineCode.Items.Insert(0, "Select")
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
        End Try
    End Sub

    Private Sub ddlMachineCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMachineCode.SelectedIndexChanged
        lblMessage.Text = ""
        If lblMode.Text = "edit" Then
            If cboWorkOrderNo.SelectedItem.Text.ToLower = "select" Then
                lblMessage.Text = "Please select workorder number !"
                ddlMachineCode.SelectedIndex = 0
                Exit Sub
            Else
                Dim dt As New DataTable()
                Dim dtSpares As New DataTable()
                Dim i As Integer
                Try
                    dt = Maintenance.tables.GetUnSchDetails(lblMaintenance_group.Text, cboWorkOrderNo.SelectedItem.Text, CDate(txtDate.Text))
                    Dim from, too As DateTime
                    Dim from1, too1 As Array
                    ddlAssembly.Items.Clear()
                    PopulateSubAssembly()
                    If IsNothing(Trim(dt.Rows(0)("sub_assembly"))) = False Then
                        For i = 0 To ddlAssembly.Items.Count
                            If ddlAssembly.Items(i).Value.Trim = Trim(dt.Rows(0)("sub_assembly")) Then
                                ddlAssembly.SelectedIndex = i
                                Exit For
                            End If
                        Next
                    End If
                    from = dt.Rows(0)("date_from")
                    too = dt.Rows(0)("date_to")
                    txtWork_done.Text = dt.Rows(0)("work_done")
                    txtAttendent.Text = dt.Rows(0)("attendent")
                    txtRemarks.Text = dt.Rows(0)("remarks")
                    Dim b As Int16 = 0
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

                    'dtSpares = Maintenance.tables.WOSpares("U", cboWorkOrderNo.SelectedItem.Text.Trim, lblMaintenance_group.Text.Trim)
                    dtSpares = Maintenance.tables.Spares(lblGroup.Text.Trim, ddlMachineCode.SelectedItem.Value.Trim)
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
                ddlAssembly.Items.Clear()
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
        group = lblDept.Text + lblMaintenance_group.Text
        Try
            cboSpares.Items.Clear()
            If ddlAssembly.SelectedIndex < 1 Then
                dt = Maintenance.tables.Spares(group, ddlMachineCode.SelectedItem.Value)
            Else
                dt = Maintenance.tables.Spares(group, ddlMachineCode.SelectedItem.Value, ddlAssembly.SelectedItem.Value)
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
        grp = lblDept.Text + lblMaintenance_group.Text
        Try
            dt = Maintenance.tables.GetMachineModifiedSubAssemblyList(lblMode.Text, ddlMachineCode.SelectedItem.Value, grp, ddlShopCode.SelectedItem.Value)
            ddlAssembly.DataSource = dt
            ddlAssembly.DataTextField = dt.Columns("description").ColumnName
            ddlAssembly.DataValueField = dt.Columns("code").ColumnName
            ddlAssembly.DataBind()
            ddlAssembly.Items.Insert(0, "Select")
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
    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        lblMessage1.Text = ""
        If ddlMachineCode.SelectedItem.Text.ToLower = "select" Then
            lblMessage.Text = "Please select Machine ID to save data !"
            lblMessage1.Text = "Please select Machine ID to save data !"
        Else
            Dim Done As Boolean
            Dim cnt As Int16
            Dim dt As New DataTable()
            Dim dr As DataRow
            Dim oMchMod As New Maintenance.Modification()
            Try
                Try
                    dt.TableName = "spares"
                    dt.Columns.Add("PlNumber")
                    dt.Columns.Add("Quantity")
                    dt.Columns.Add("ReplacedQuantity")
                    If grdSpares.Items.Count > 0 Then
                        For cnt = 0 To grdSpares.Items.Count - 1
                            dr = dt.NewRow
                            dr("PlNumber") = grdSpares.Items(cnt).Cells(0).Text
                            dr("Quantity") = grdSpares.Items(cnt).Cells(3).Text
                            dr("ReplacedQuantity") = grdSpares.Items(cnt).Cells(3).Text
                            dt.Rows.Add(dr)
                        Next
                    End If
                    oMchMod.SparesList = dt
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
                    oMchMod = Nothing
                    Exit Sub
                End If
                Dim fr_dt, to_dt As DateTime
                fr_dt = txtFrom.Text & " " & txtFrom_time.Text
                to_dt = txtTo.Text & " " & txtTo_time.Text
                oMchMod.Machinery.GroupCode = lblMaintenance_group.Text.Trim
                If lblMode.Text = "add" Then
                    oMchMod.Number = lblWorkOrderNo.Text.Trim
                    oMchMod.SparesNumber = lblWorkOrderNo.Text.Trim
                Else
                    oMchMod.Number = IIf(IsNothing(cboWorkOrderNo.SelectedItem.Value), "", cboWorkOrderNo.SelectedItem.Value)
                    oMchMod.SparesNumber = IIf(IsNothing(cboWorkOrderNo.SelectedItem.Value), "", cboWorkOrderNo.SelectedItem.Value)
                End If
                oMchMod.MachineCode = ddlMachineCode.SelectedItem.Value
                oMchMod.Machinery.Location = ddlShopCode.SelectedItem.Value
                oMchMod.SubAssembly = IIf((ddlAssembly.SelectedItem.Value.ToLower = "select"), "", ddlAssembly.SelectedItem.Value)
                oMchMod.FromDate = fr_dt
                oMchMod.ToDate = to_dt
                oMchMod.Details = txtWork_done.Text.Trim
                oMchMod.Reason = txtObservation.Text.Trim
                oMchMod.InitiatedBy = txtAttendent.Text.Trim
                oMchMod.ApprovedBy = txtApproved.Text.Trim
                oMchMod.Benifits = txtAdvantages.Text.Trim
                oMchMod.Remarks = txtRemarks.Text
                oMchMod.WODate = txtDate.Text.Trim
                oMchMod.Group = lblMaintenance_group.Text
                oMchMod.Operator1 = lblUserID.Text
                oMchMod.Type = "M"
                If oMchMod.SaveWorkDoneDetails(oMchMod.Number) Then
                    Done = True
                End If
                PopulateLocation(strmode.Trim, lblMaintenance_group.Text)
                ddlShopCode.SelectedIndex = 0
            Catch exp As Exception
                lblMessage.Text = exp.Message
            Finally
                dt.Dispose()
                oMchMod = Nothing
            End Try
            If Done Then
                lblMessage.Text = "Record Updated..."
                lblMessage1.Text = "Record Updated... "
                Clear()
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
        dt.Columns.Add("Pl_Number")
        dt.Columns.Add("Description")
        dt.Columns.Add("Unit")
        dt.Columns.Add("Quantity")
        grdSpares.DataSource = dt
        grdSpares.DataBind()

        txtAdvantages.Text = ""
        txtApproved.Text = ""
        txtAttendent.Text = ""
        txtObservation.Text = ""
        txtPLNumber.Text = ""
        txtRemarks.Text = ""
        txtWork_done.Text = ""
        txtPl_qty.Text = ""
        ddlAssembly.Items.Clear()
        ddlMachineCode.Items.Clear()
        cboSpares.Items.Clear()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        PopulateDatatable()
    End Sub

    Private Sub PopulateDatatable()
        Dim dt As New DataTable()
        Dim dtPl As New DataTable()
        Dim dr As DataRow
        Dim cnt As Int16
        Dim desc, unit As String
        Try
            dt.TableName = "spares"
            dt.Columns.Add("Pl Number")
            dt.Columns.Add("Description")
            dt.Columns.Add("Unit")
            dt.Columns.Add("Quantity")
            If grdSpares.Items.Count > 0 Then
                For cnt = 0 To grdSpares.Items.Count - 1
                    If grdSpares.Items(cnt).Cells(0).Text.Trim <> Trim(txtPLNumber.Text) Then
                        dr = dt.NewRow
                        dr("Pl Number") = grdSpares.Items(cnt).Cells(0).Text
                        dr("Description") = grdSpares.Items(cnt).Cells(1).Text
                        dr("Unit") = grdSpares.Items(cnt).Cells(2).Text
                        dr("Quantity") = grdSpares.Items(cnt).Cells(3).Text
                        dt.Rows.Add(dr)
                    End If
                Next
            End If

            dtPl = Maintenance.tables.PLDetails(Trim(txtPLNumber.Text))

            If Trim(IIf(IsDBNull(dtPl.Rows(0)("pl_number")), 0, dtPl.Rows(0)("pl_number"))) = 0 Then
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
            dr("Quantity") = Session("plQty")
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

    Private Sub cboSpares_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSpares.SelectedIndexChanged
        lblMessage.Text = ""
        txtPl_qty.Text = ""
        txtPLNumber.Text = ""
        Dim strCmd As String
        If cboSpares.SelectedIndex = 0 Then
            lblMessage.Text = "Please select Spares List !"
            Exit Sub
        Else
            Dim dt As New DataTable()
            Dim group As String
            group = lblDept.Text + lblMaintenance_group.Text
            Try
                txtPLNumber.Text = cboSpares.SelectedItem.Value
                If ddlAssembly.SelectedItem.Text = "Select" Then
                    dt = Maintenance.tables.Spares(group, ddlMachineCode.SelectedItem.Value, , txtPLNumber.Text.Trim)
                Else
                    dt = Maintenance.tables.Spares(group, ddlMachineCode.SelectedItem.Value, ddlAssembly.SelectedItem.Value.Trim, txtPLNumber.Text.Trim)
                End If
                If strmode.Equals("edit") Then
                    dt = Maintenance.tables.WOSpares("M", cboWorkOrderNo.SelectedItem.Value, lblMaintenance_group.Text, cboSpares.SelectedItem.Value)
                    If Not IsDBNull(dt.Rows(0)("Quantity")) Then
                        txtPl_qty.Text = dt.Rows(0)("Quantity")
                        Session("plQty") = txtPl_qty.Text
                    End If
                Else
                    If Not IsDBNull(dt.Rows(0)("qtyreqd")) Then
                        txtPl_qty.Text = dt.Rows(0)("qtyreqd")
                        Session("plQty") = txtPl_qty.Text
                    End If
                End If
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub FillSpares()
        Dim dt As New DataTable()
        Dim group As String
        group = lblDept.Text + lblMaintenance_group.Text
        Try
            If ddlAssembly.SelectedItem.Text = "Select" Then
                dt = Maintenance.tables.Spares(group, ddlMachineCode.SelectedItem.Value, , txtPLNumber.Text.Trim)
            Else
                dt = Maintenance.tables.Spares(group, ddlMachineCode.SelectedItem.Value, ddlAssembly.SelectedItem.Value.Trim, txtPLNumber.Text.Trim)
            End If
            If strmode.Equals("edit") Then
                dt = Maintenance.tables.WOSpares("M", cboWorkOrderNo.SelectedItem.Value, lblMaintenance_group.Text, txtPLNumber.Text.Trim)
                If Not IsDBNull(dt.Rows(0)("Quantity")) Then
                    txtPl_qty.Text = dt.Rows(0)("Quantity")
                    Session("plQty") = txtPl_qty.Text
                End If
            Else
                If Not IsDBNull(dt.Rows(0)("qtyreqd")) Then
                    txtPl_qty.Text = dt.Rows(0)("qtyreqd")
                    Session("plQty") = txtPl_qty.Text
                End If
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub ddlAssembly_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlAssembly.SelectedIndexChanged
        txtPLNumber.Text = ""
        txtPl_qty.Text = ""
        get_Spares()
    End Sub
    Public Sub PopulateWorkOrders()
        Dim dt As DataTable
        Dim count As Integer
        cboWorkOrderNo.Items.Clear()
        dt = Maintenance.tables.MachineModifiedWorkorders(lblMaintenance_group.Text.Trim, CDate(txtDate.Text), ddlShopCode.SelectedItem.Value)
        cboWorkOrderNo.DataSource = dt.DefaultView
        cboWorkOrderNo.DataTextField = dt.Columns("workorder_number").ColumnName
        cboWorkOrderNo.DataValueField = dt.Columns("workorder_number").ColumnName
        cboWorkOrderNo.DataBind()
        count = cboWorkOrderNo.Items.Count
        If count = 0 Then
            lblMessage.Text = "No WorkOrders Exist For The Given Date..."
            txtDate.Text = ""
        End If
        cboWorkOrderNo.Items.Insert(0, "Select")
        dt.Dispose()
    End Sub
    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        lblMessage.Text = ""
        Clear()
        ddlShopCode.SelectedIndex = 0
        Dim dt As Date
        Try
            dt = CDate(txtDate.Text)
            txtDate.Text = dt
            If strmode.Equals("edit") Then
                If ddlShopCode.SelectedItem.Text.ToLower = "select" Then
                    lblMessage.Text = "Please select shop code "
                Else
                    PopulateWorkOrders()
                End If
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
            If strmode.Equals("edit") Then
                cboWorkOrderNo.Items.Clear()
            End If
            txtDate.Text = ""
        End Try
    End Sub

    Private Sub cboWorkOrderNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboWorkOrderNo.SelectedIndexChanged
        lblMessage.Text = ""
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
                dt = Maintenance.tables.GetMachineModificationDetails(lblMaintenance_group.Text, cboWorkOrderNo.SelectedItem.Text, CDate(txtDate.Text))
                For i = 0 To ddlMachineCode.Items.Count - 1
                    If ddlMachineCode.Items(i).Value.Trim = Trim(dt.Rows(0)("machine_code")) Then
                        ddlMachineCode.SelectedIndex = i
                        Exit For
                    End If
                Next
                ddlAssembly.Items.Clear()
                PopulateSubAssembly()
                If IsNothing(Trim(dt.Rows(0)("sub_assembly"))) = False AndAlso Trim(dt.Rows(0)("sub_assembly")) <> "N/A" Then
                    For i = 0 To ddlAssembly.Items.Count - 1
                        If ddlAssembly.Items(i).Value.Trim = Trim(dt.Rows(0)("sub_assembly")).Replace("N/A", 0) Then
                            ddlAssembly.SelectedIndex = i
                            Exit For
                        End If
                    Next
                End If
                Dim from, too As DateTime
                Dim from1, too1 As Array
                from = dt.Rows(0)("date_from")
                too = dt.Rows(0)("date_to")
                txtWork_done.Text = dt.Rows(0)("details")
                txtObservation.Text = dt.Rows(0)("reason")
                txtAttendent.Text = dt.Rows(0)("initiated_by")
                txtApproved.Text = dt.Rows(0)("approved_by")
                txtAdvantages.Text = dt.Rows(0)("benifits")
                txtRemarks.Text = dt.Rows(0)("remarks")
                Dim b As Int16 = 0
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

                dtSpares = Maintenance.tables.WOSpares("M", cboWorkOrderNo.SelectedItem.Text.Trim, lblMaintenance_group.Text.Trim)
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

    Private Sub txtPl_qty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPl_qty.TextChanged
        Session("plQty") = txtPl_qty.Text
    End Sub

    Private Sub txtPLNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPLNumber.TextChanged
        FillSpares()
    End Sub
End Class
