Public Class ms_machinesparesNew
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblMaintenance_group As System.Web.UI.WebControls.Label
    Protected WithEvents cboLocation As System.Web.UI.WebControls.DropDownList
    Protected WithEvents rdoTypeOfSpares As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents lblMachine As System.Web.UI.WebControls.Label
    Protected WithEvents lblSubAssembly As System.Web.UI.WebControls.Label
    Protected WithEvents btnChangeMachine As System.Web.UI.WebControls.Button
    Protected WithEvents txtPLNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtQtyReqd As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPurpose As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
    Protected WithEvents lblSubAssm As System.Web.UI.WebControls.Label
    Protected WithEvents cboAssembly As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblLocation As System.Web.UI.WebControls.Label
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents pnlLocation As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlSpares As System.Web.UI.WebControls.Panel
    Protected WithEvents lblUnit As System.Web.UI.WebControls.Label
    Protected WithEvents lblPlDesc As System.Web.UI.WebControls.Label
    Protected WithEvents ddlMachineGroup As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblLocationG As System.Web.UI.WebControls.Label
    Protected WithEvents ddlMachineCode As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblLocationM As System.Web.UI.WebControls.Label
    Protected WithEvents lblGroupM As System.Web.UI.WebControls.Label
    Protected WithEvents lblGroupG As System.Web.UI.WebControls.Label
    Protected WithEvents lstMachineCode As System.Web.UI.WebControls.ListBox
    Protected WithEvents txtPlNumberG As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblPlDescG As System.Web.UI.WebControls.Label
    Protected WithEvents txtQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblUnitG As System.Web.UI.WebControls.Label
    Protected WithEvents pnlGroup As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlMachine As System.Web.UI.WebControls.Panel
    Protected WithEvents rdoTypeOfGroup As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnSaveGroup As System.Web.UI.WebControls.Button
    Protected WithEvents txtPurposeG As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnChangeGroupG As System.Web.UI.WebControls.Button
    Protected WithEvents btnChangeGroup As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblLocationS As System.Web.UI.WebControls.Label
    Protected WithEvents lblGroupS As System.Web.UI.WebControls.Label
    Protected WithEvents lstSubAssemblyCode As System.Web.UI.WebControls.ListBox
    Protected WithEvents txtPlNumberS As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblPlDescS As System.Web.UI.WebControls.Label
    Protected WithEvents lblUnitS As System.Web.UI.WebControls.Label
    Protected WithEvents txtPurposeS As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnChangeGroupS As System.Web.UI.WebControls.Button
    Protected WithEvents btnSaveSubAssembly As System.Web.UI.WebControls.Button
    Protected WithEvents pnlSubAssembly As System.Web.UI.WebControls.Panel
    Protected WithEvents txtQtyS As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblUserID As System.Web.UI.WebControls.Label
    Protected WithEvents lblGrp As System.Web.UI.WebControls.Label


    Dim grp, saveMode, strsql, strMode As String
    Dim blnTable, blnIsSubAssembly, Notvalid As Boolean
    Protected WithEvents lblMachineCode As System.Web.UI.WebControls.Label
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


    Protected Sub Dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'strMode = Request.QueryString("mode")
        lblGrp.Visible = False
        lblUserID.Visible = False
        strMode = "add"
        'Session("UserID") = "068005"
        'Session("group") = "MW3"
        lblUserID.Text = Trim(Session("UserID"))
        lblGrp.Text = Session("group")
        grp = lblGrp.Text
        lblMaintenance_group.Text = grp.Substring(1)
        If strMode = LCase("ADD") Then
            btnSave.Text = "Save"
        ElseIf strMode = LCase("EDIT") Then
            btnSave.Text = "Update"
        ElseIf strMode = LCase("DELETE") Then
            btnSave.Text = "Delete"
        End If
        If Not Page.IsPostBack Then
            pnlLocation.Visible = True
            pnlSpares.Visible = False
            pnlGroup.Visible = False
            pnlMachine.Visible = False
            pnlSubAssembly.Visible = False
            rdoTypeOfSpares.Visible = False
            PopulateLocation()
        End If
    End Sub
    Private Sub PopulateLocation()
            Dim dvGroup As New DataView()
            Dim ds As New DataSet()
            Try
                ds = Maintenance.tables.PopulateLocation(lblUserID.Text.Trim)
                cboLocation.DataSource = ds.Tables(0).DefaultView
                cboLocation.DataTextField = ds.Tables(0).Columns(1).ColumnName
                cboLocation.DataValueField = ds.Tables(0).Columns(0).ColumnName
                cboLocation.DataBind()
                cboLocation.Items.Insert(0, New ListItem("Select", "0"))
                cboLocation.SelectedIndex = 0
                dvGroup.Table = ds.Tables(1)
            If dvGroup.Item(0)(0) = "RTSHOP" Then
                lblGrp.Text = "MRT"
                lblMaintenance_group.Text = lblGrp.Text.Trim.Substring(1)
            Else
                lblGrp.Text = dvGroup.Item(0)(0)
                    lblMaintenance_group.Text = lblGrp.Text.Trim.Substring(1)
                End If
            Catch exp As Exception
                lblMessage.Text = exp.Message
            Finally
                dvGroup.Dispose()
                ds.Dispose()
            End Try
        End Sub
        Private Sub PopulateMachineGroup()
            ddlMachineGroup.Items.Clear()
            Dim dt As New DataTable()
            Try
                dt = Maintenance.tables.PopulateMachineGroup(cboLocation.SelectedItem.Value)
                ddlMachineGroup.DataSource = dt.DefaultView
                ddlMachineGroup.DataValueField = dt.Columns(0).ColumnName
                ddlMachineGroup.DataTextField = dt.Columns(1).ColumnName
                ddlMachineGroup.DataBind()
                ddlMachineGroup.Items.Insert(0, New ListItem("Select", "0"))
                ddlMachineGroup.SelectedIndex = 0
            Catch exp As Exception
                lblMessage.Text = exp.Message
            Finally
                dt.Dispose()
            End Try
        End Sub
        Private Sub PopulateMachineCode()
            Dim dt As New DataTable()
            ddlMachineCode.Items.Clear()
            Try
                dt = Maintenance.tables.PopulateMachineCode(Trim(cboLocation.SelectedItem.Value), ddlMachineGroup.SelectedItem.Value.Trim)
                ddlMachineCode.DataSource = dt.DefaultView
                ddlMachineCode.DataValueField = dt.Columns(0).ColumnName
                ddlMachineCode.DataTextField = dt.Columns(1).ColumnName
                ddlMachineCode.DataBind()
                ddlMachineCode.Items.Insert(0, New ListItem("Select", "0"))
                ddlMachineCode.SelectedIndex = 0
            Catch exp As Exception
                lblMessage.Text = exp.Message
            Finally
                dt.Dispose()
            End Try
        End Sub
        Private Sub PopulateGrid(ByVal blnIsSubAssembly As Boolean)
            Dim ds As New DataSet()
            Try
                ds = Maintenance.tables.PopulateSparesGrid(blnIsSubAssembly, lblGrp.Text.Trim, ddlMachineCode.SelectedItem.Value.Trim)
                ViewState("vPLNum") = ds
                If ds.Tables(0).Rows.Count > 0 Then DataGrid1.DataSource = ds.Tables(0).DefaultView Else DataGrid1.DataSource = Nothing
                DataGrid1.DataBind()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            Finally
                ds.Dispose()
            End Try
        End Sub
        Private Sub PopulateSubAssembly()
            Dim dt As New DataTable()
            Try
                dt = Maintenance.tables.PopulateSubAssembly(lblGrp.Text, ddlMachineCode.SelectedItem.Value)
                cboAssembly.DataSource = dt.DefaultView
                cboAssembly.DataValueField = dt.Columns(0).ColumnName
                cboAssembly.DataTextField = dt.Columns(1).ColumnName
                cboAssembly.DataBind()
                cboAssembly.Items.Insert(0, New ListItem("Select", "0"))
                cboAssembly.SelectedIndex = 0
            Catch exp As Exception
                lblMessage.Text = exp.Message
            Finally
                dt.Dispose()
            End Try
        End Sub
        Private Sub PopulateMachineList()
            lstMachineCode.Items.Clear()
            Dim dt As New DataTable()
            Try
                dt = Maintenance.tables.PopulateMachineCode(Trim(cboLocation.SelectedItem.Value), ddlMachineGroup.SelectedItem.Value.Trim)
                lstMachineCode.DataSource = dt.DefaultView
                lstMachineCode.DataValueField = dt.Columns(0).ColumnName
                lstMachineCode.DataTextField = dt.Columns(1).ColumnName
                lstMachineCode.DataBind()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            Finally
                dt.Dispose()
            End Try
        End Sub
        Private Sub PopulateSubAssemblyList()
            lstSubAssemblyCode.Items.Clear()
            Dim dt As New DataTable()
            Try
                dt = Maintenance.tables.PopulateSubAssemblyList(cboLocation.SelectedItem.Value, ddlMachineGroup.SelectedItem.Value, lblGrp.Text)
                ViewState("SubAssemblyList") = dt
                lstSubAssemblyCode.DataSource = dt.DefaultView
                lstSubAssemblyCode.DataValueField = dt.Columns(0).ColumnName
                lstSubAssemblyCode.DataTextField = dt.Columns(1).ColumnName
                lstSubAssemblyCode.DataBind()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            Finally
                dt.Dispose()
            End Try
        End Sub
        Private Sub PopulateGrid2()
            Dim ds As New DataSet()
            Try
                If rdoTypeOfGroup.SelectedIndex = 0 Then
                    ds = Maintenance.tables.PopulateSparesGrid2(cboLocation.SelectedItem.Value.Trim, ddlMachineGroup.SelectedItem.Value.Trim, lblGrp.Text.Trim, rdoTypeOfGroup.SelectedIndex)
                    ViewState("vPLNumG") = ds
                ElseIf rdoTypeOfGroup.SelectedIndex = 2 Then
                    ds = Maintenance.tables.PopulateSparesGrid2(cboLocation.SelectedItem.Value.Trim, ddlMachineGroup.SelectedItem.Value.Trim, lblGrp.Text.Trim, rdoTypeOfGroup.SelectedIndex)
                    ViewState("vPLNumS") = ds
                End If
                If ds.Tables(0).Rows.Count > 0 Then DataGrid2.DataSource = ds.Tables(0).DefaultView Else DataGrid2.DataSource = Nothing
                DataGrid2.DataBind()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            Finally
                ds.Dispose()
            End Try
        End Sub
        Private Sub PopulatePLDesc(ByVal TableName As String)
            lblMessage.Text = ""
            If CheckPls(TableName) = False Then
                Dim dt As New DataTable()
                Try
                    If rdoTypeOfGroup.SelectedIndex = 0 Then
                        dt = Maintenance.tables.GetPlDesc(Trim(txtPlNumberG.Text))
                        lblPlDescG.Text = dt.Rows(0)("PlDesc")
                        lblUnitG.Text = dt.Rows(0)("PlUnit")
                    ElseIf rdoTypeOfGroup.SelectedIndex = 2 Then
                        dt = Maintenance.tables.GetPlDesc(Trim(txtPlNumberS.Text))
                        lblPlDescS.Text = dt.Rows(0)("PlDesc")
                        lblUnitS.Text = dt.Rows(0)("PlUnit")
                    End If
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                Finally
                    dt.Dispose()
                End Try
            End If
        End Sub
        Private Sub ClearSpares()
            lblMessage.Text = ""
            txtPurpose.Text = ""
            txtQtyReqd.Text = ""
            txtPLNumber.Text = ""
            lblPlDesc.Text = ""
            lblUnit.Text = ""
            lblSubAssembly.Text = ""
            cboAssembly.Items.Clear()
            lblMachine.Text = ""
            lblMachineCode.Text = ""
            lblLocation.Text = ""
            lblSubAssm.Visible = False
        End Sub
        Private Sub clearG()
            lstMachineCode.ClearSelection()
            txtPlNumberG.Text = ""
            txtQty.Text = ""
            lblPlDescG.Text = ""
            lblUnitG.Text = ""
            txtPurposeG.Text = ""
        End Sub
        Private Sub ClearS()
            lstSubAssemblyCode.ClearSelection()
            txtPlNumberS.Text = ""
            txtQtyS.Text = ""
            lblPlDescS.Text = ""
            lblUnitS.Text = ""
            txtPurposeS.Text = ""
        End Sub
        Private Sub Clear()
            txtPLNumber.Text = ""
            lblPlDesc.Text = ""
            lblUnit.Text = ""
            txtQtyReqd.Text = ""
            txtPurpose.Text = ""
        End Sub
        Private Sub txtPLNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPLNumber.TextChanged
            lblMessage.Text = ""
            Dim dsPL As New DataSet()
            Dim dvPL As New DataView()
            Dim dt As New DataTable()
            Try
                dsPL = CType(ViewState("vPLNum"), DataSet)
                If dsPL.Tables(0).Rows.Count > 0 Then
                    dvPL.Table = dsPL.Tables(0)
                    Try
                        If lblSubAssm.Visible Then
                            dvPL.RowFilter = "PLNumber = '" & Trim(txtPLNumber.Text) & "' and MachineCode = '" & lblMachineCode.Text.Trim & "' and SubAssemblyCode = '" & cboAssembly.SelectedItem.Value & "'"
                        Else
                            dvPL.RowFilter = "PLNumber = '" & Trim(txtPLNumber.Text) & "' and MachineCode = '" & lblMachineCode.Text.Trim & "'"
                        End If
                        lblPlDesc.Text = dvPL.Item(0)(3)
                        txtQtyReqd.Text = dvPL.Item(0)(4)
                        txtPurpose.Text = dvPL.Item(0)(5)
                        lblUnit.Text = dvPL.Item(0)(6)
                        ViewState("saveMode") = "edit"
                        lblMessage.Text = "PLNumber = '" & Trim(txtPLNumber.Text) & "' already exists ! "
                    Catch
                        ViewState("saveMode") = "add"
                    End Try
                Else
                    ViewState("saveMode") = "add"
                End If
                If CType(ViewState("saveMode"), String) = "add" Then
                    dt = Maintenance.tables.GetPlDesc(Trim(txtPLNumber.Text))
                    lblPlDesc.Text = dt.Rows(0)("PlDesc")
                    lblUnit.Text = dt.Rows(0)("PlUnit")
                End If
            Catch exp As Exception
                lblMessage.Text = exp.Message
            Finally
            End Try
            btnSaveText()
        End Sub
        Private Sub txtPlNumberS_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPlNumberS.TextChanged
            PopulatePLDesc(btnSaveSubAssembly.Text)
        End Sub
    Private Sub txtPlNumberG_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPlNumberG.TextChanged
        PopulatePLDesc(btnSaveGroup.Text)
    End Sub

    Private Sub CustomValidator1_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        Dim blnMachine = CType(ViewState("vSubAssCount"), Boolean)
        If blnMachine = False OrElse rdoTypeOfSpares.SelectedIndex = 0 Then
            blnTable = True
        ElseIf blnMachine = True AndAlso rdoTypeOfSpares.SelectedIndex = 0 Then
            blnTable = True
        ElseIf blnMachine = True AndAlso rdoTypeOfSpares.SelectedIndex = 1 Then
            blnTable = False
        End If
    End Sub
    Private Sub DataGrid1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.ItemCommand
            lblMessage.Text = ""
            Select Case e.CommandName
                Case "Delete"
                    Try
                        Dim i As Integer
                        Dim bMac = CType(ViewState("vSubAssCount"), Boolean)
                        If Not e.Item.Cells(1).Text Is Nothing Then
                            If bMac Then
                                For i = 0 To cboAssembly.Items.Count - 1
                                    If cboAssembly.Items(i).Value.Trim = e.Item.Cells(2).Text.Trim Then
                                        cboAssembly.SelectedIndex = i
                                    End If
                                Next
                            Else
                                For i = 0 To ddlMachineCode.Items.Count - 1
                                    If ddlMachineCode.Items(i).Value.Trim = e.Item.Cells(1).Text.Trim Then
                                        ddlMachineCode.SelectedIndex = i
                                    End If
                                Next
                            End If
                        End If
                        txtPLNumber.Text = e.Item.Cells(3).Text
                        txtQtyReqd.Text = IIf(IsDBNull(e.Item.Cells(5).Text), 0, e.Item.Cells(5).Text)
                        txtPurpose.Text = IIf(IsDBNull(e.Item.Cells(6).Text), "", e.Item.Cells(6).Text.Replace("&nbsp;", ""))
                        lblPlDesc.Text = IIf(IsDBNull(e.Item.Cells(4).Text), "", e.Item.Cells(4).Text)
                        lblUnit.Text = IIf(IsDBNull(e.Item.Cells(7).Text), "", e.Item.Cells(7).Text)
                        ViewState("saveMode") = "delete"
                        btnSaveText()
                    Catch exp As Exception
                        lblMessage.Text = exp.Message
                    End Try
            End Select
        End Sub
        Private Function CheckPls(ByVal TableName As String) As Boolean
            Dim x As Integer
            Dim li As ListItem
            Dim strcmd, strMessage As String
            Dim blnDone As Boolean
            strMessage = ""
            Select Case TableName
                Case "SaveSubAssemblyPLs"
                    For Each li In lstSubAssemblyCode.Items
                        If li.Selected = True Then
                            Dim dsS As New DataSet()
                            Dim dsSm As New DataTable()
                            Dim dvS As New DataView()
                            Dim dvSm As New DataView()
                            dsS = CType(ViewState("vPLNumS"), DataSet)
                            dsSm = CType(ViewState("SubAssemblyList"), DataTable)
                            dvS.Table = dsS.Tables(0)
                            dvS.RowFilter = "PLNumber = '" & Trim(txtPlNumberS.Text) & "' and SubAssemblyCode = '" & li.Value.Trim & "'"
                            dvSm.Table = dsSm
                            dvSm.RowFilter = "code = '" & li.Value.Trim & "'"
                            If dvS.Count > 0 Then
                                Dim dt As New DataTable()
                                Try
                                    dt = Maintenance.tables.CheckPls("SaveSubAssemblyPLs", Trim(lblGrp.Text.ToUpper), Trim(txtPlNumberS.Text.Trim), dvSm.Item(0)(2), li.Value.Trim)
                                    If (IIf(IsDBNull(dt.Rows(0)("Cnt")), 0, dt.Rows(0)("Cnt")) > 0) Then
                                        strMessage = strMessage + " '" & li.Text.Trim & " ' ; "
                                        lblPlDescS.Text = IIf(IsDBNull(dt.Rows(0)("PlShortName")), 0, dt.Rows(0)("PlShortName"))
                                        lblUnitS.Text = IIf(IsDBNull(dt.Rows(0)("PlUnitName")), 0, dt.Rows(0)("PlUnitName"))
                                        blnDone = True
                                    End If
                                Catch exp As Exception
                                    lblMessage.Text = exp.Message
                                Finally
                                    dt.Dispose()
                                End Try
                            End If
                        End If
                    Next
                    If strMessage.Trim.Length > 0 Then
                        lblMessage.Text = " Pl Nuber : '" & Trim(txtPlNumberS.Text) & "' already present for : -  '" & Trim(strMessage.Trim) & "'"
                    End If
                Case "SaveGroupPLs"
                    For Each li In lstMachineCode.Items
                        If li.Selected = True Then
                            Dim dsG As New DataSet()
                            Dim dvG As New DataView()
                            dsG = CType(ViewState("vPLNumG"), DataSet)
                            dvG.Table = dsG.Tables(0)
                            'dvG.RowFilter = "PLNumber = '" & Trim(txtPlNumberG.Text) & "' and MachineCode = '" & li.Value.Trim & "' and SubAssemblyCode = '0'"
                            dvG.RowFilter = "PLNumber = '" & Trim(txtPlNumberG.Text) & "' and MachineCode = '" & li.Value.Trim & "'"
                            If dvG.Count > 0 Then
                                Dim dt As New DataTable()
                                Try
                                    dt = Maintenance.tables.CheckPls("SaveGroupPLs", lblGrp.Text.Trim, Trim(txtPlNumberG.Text), li.Value.Trim, "")
                                    If dt.Rows.Count > 0 Then
                                        If (IIf(IsDBNull(dt.Rows(0)("Cnt")), 0, dt.Rows(0)("Cnt")) > 0) Then
                                            strMessage = strMessage + " '" & li.Text.Trim & " ' ; "
                                            lblPlDescG.Text = IIf(IsDBNull(dt.Rows(0)("PlShortName")), 0, dt.Rows(0)("PlShortName"))
                                            lblUnitG.Text = IIf(IsDBNull(dt.Rows(0)("PlUnitName")), 0, dt.Rows(0)("PlUnitName"))
                                            blnDone = True
                                        End If
                                    End If
                                Catch exp As Exception
                                    lblMessage.Text = exp.Message
                                Finally
                                    dt.Dispose()
                                End Try
                            End If
                        End If
                    Next
                    If strMessage.Trim.Length > 0 Then
                        lblMessage.Text = " Pl Nuber : '" & Trim(txtPlNumberG.Text) & "' already present for : -  '" & Trim(strMessage.Trim) & "'"
                    End If
                Case Else
            End Select
            Return blnDone
        End Function
        Private Sub ddlMachineGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMachineGroup.SelectedIndexChanged
            rdoTypeOfGroup.Visible = True
            rdoTypeOfGroup.ClearSelection()
            pnlGroup.Visible = False
            pnlMachine.Visible = False
        End Sub
        Private Sub cboLocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLocation.SelectedIndexChanged
            rdoTypeOfSpares.ClearSelection()
            lblMessage.Text = ""
            PopulateMachineGroup()
        End Sub
        Private Sub ddlMachineCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMachineCode.SelectedIndexChanged
            lblLocation.Text = cboLocation.SelectedItem.Text
            lblMachineCode.Text = ddlMachineCode.SelectedItem.Value
            lblMachine.Text = ddlMachineCode.SelectedItem.Text
            pnlGroup.Visible = False
            'rdoTypeOfSpares.ClearSelection()
            lblMessage.Text = ""
            ViewState("saveMode") = "add"
            btnSaveText()
            Try
                If Maintenance.tables.CheckSubAssemblySpare(lblGrp.Text, ddlMachineCode.SelectedItem.Value) > 0 Then
                    rdoTypeOfSpares.Visible = True
                    lblSubAssm.Visible = True
                    cboAssembly.Visible = True
                    pnlLocation.Visible = False
                    pnlSpares.Visible = False
                    pnlMachine.Visible = True
                    blnIsSubAssembly = True
                Else
                    pnlLocation.Visible = False
                    pnlSpares.Visible = True
                    pnlMachine.Visible = False
                    lblSubAssm.Visible = False
                    cboAssembly.Visible = False
                    rdoTypeOfSpares.Visible = False
                    blnIsSubAssembly = False
                    PopulateGrid(blnIsSubAssembly)
                End If
                ViewState("vSubAssCount") = blnIsSubAssembly

                Dim blnMachine = CType(ViewState("vSubAssCount"), Boolean)
                If blnMachine = False OrElse rdoTypeOfSpares.SelectedIndex = 0 Then
                    blnTable = True
                ElseIf blnMachine = True AndAlso rdoTypeOfSpares.SelectedIndex = 0 Then
                    blnTable = True
                ElseIf blnMachine = True AndAlso rdoTypeOfSpares.SelectedIndex = 1 Then
                    blnTable = False
                End If
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End Sub
        Private Sub rdoTypeOfSpares_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoTypeOfSpares.SelectedIndexChanged
            Dim blnIsSubAssembly As Boolean
            pnlLocation.Visible = False
            pnlSpares.Visible = True
            pnlMachine.Visible = False
            If rdoTypeOfSpares.SelectedIndex = 0 Then
                blnIsSubAssembly = False
                lblSubAssm.Visible = False
                cboAssembly.Visible = False
                lblSubAssembly.Text = ""
                lblSubAssembly.Visible = False
            Else
                blnIsSubAssembly = True
                lblSubAssm.Visible = True
                cboAssembly.Visible = True
                lblSubAssembly.Visible = True
                PopulateSubAssembly()
            End If
            PopulateGrid(blnIsSubAssembly)
        End Sub
        Private Sub cboAssembly_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAssembly.SelectedIndexChanged
            If cboAssembly.SelectedItem.Text.Equals("Select") Then lblSubAssembly.Text = "" Else lblSubAssembly.Text = cboAssembly.SelectedItem.Text
            Clear()
        End Sub
        Private Sub rdoTypeOfGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoTypeOfGroup.SelectedIndexChanged
            If ddlMachineGroup.Items.Count = 0 OrElse ddlMachineGroup.SelectedItem.Text = "Select" OrElse ddlMachineGroup.SelectedIndex = 0 Then
                lblMessage.Text = " Please select machine group"
                rdoTypeOfGroup.ClearSelection()
                Exit Sub
            End If
            lblMessage.Text = ""
            pnlLocation.Visible = False
            If rdoTypeOfGroup.SelectedIndex = 0 Then
                pnlGroup.Visible = True
                pnlMachine.Visible = False
                pnlSubAssembly.Visible = False
                lblLocationG.Text = cboLocation.SelectedItem.Text
                lblGroupG.Text = ddlMachineGroup.SelectedItem.Text.Trim
                PopulateMachineList()
                ViewState("PopGroup") = True
                PopulateGrid2()
            ElseIf rdoTypeOfGroup.SelectedIndex = 1 Then
                rdoTypeOfSpares.Visible = True
                pnlGroup.Visible = False
                pnlMachine.Visible = True
                pnlSubAssembly.Visible = False
                ViewState("PopGroup") = False
                lblLocationM.Text = cboLocation.SelectedItem.Text
                lblGroupM.Text = ddlMachineGroup.SelectedItem.Text.Trim
                PopulateMachineCode()
            Else
                pnlGroup.Visible = False
                pnlMachine.Visible = False
                pnlSubAssembly.Visible = True
                lblLocationS.Text = cboLocation.SelectedItem.Text
                lblGroupS.Text = ddlMachineGroup.SelectedItem.Text.Trim
                PopulateSubAssemblyList()
                ViewState("PopGroup") = True
                PopulateGrid2()
            End If

        End Sub
        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Clear()
        End Sub
        Private Sub btnChangeMachine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeMachine.Click
            ClearSpares()
            pnlSpares.Visible = False
            pnlLocation.Visible = False
            pnlGroup.Visible = False
            pnlMachine.Visible = True
            'rdoTypeOfSpares.Visible = False
            'rdoTypeOfSpares.ClearSelection()
            ddlMachineCode.SelectedIndex = 0
            DataGrid1.DataSource = Nothing
            DataGrid1.DataBind()
            DataGrid2.DataSource = Nothing
            DataGrid2.DataBind()
            ViewState("vSubAssCount") = Nothing
        End Sub
        Private Sub btnChangeGroupS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeGroupS.Click
            lblMessage.Text = ""
            rdoTypeOfGroup.ClearSelection()
            lstSubAssemblyCode.ClearSelection()
            lstSubAssemblyCode.Items.Clear()
            txtPlNumberS.Text = ""
            lblPlDescS.Text = ""
            txtQtyS.Text = ""
            lblGroupS.Text = ""
            pnlLocation.Visible = True
            pnlGroup.Visible = False
            pnlSubAssembly.Visible = False
            cboLocation.SelectedIndex = 0
            ddlMachineGroup.SelectedIndex = 0
            ddlMachineGroup.Items.Clear()
            DataGrid1.DataSource = Nothing
            DataGrid1.DataBind()
            DataGrid2.DataSource = Nothing
            DataGrid2.DataBind()
        End Sub
        Private Sub btnChangeGroupG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeGroupG.Click
            lblMessage.Text = ""
            rdoTypeOfGroup.ClearSelection()
            lstMachineCode.ClearSelection()
            lstMachineCode.Items.Clear()
            txtPlNumberG.Text = ""
            lblPlDescG.Text = ""
            txtQty.Text = ""
            lblGroupG.Text = ""
            pnlLocation.Visible = True
            pnlGroup.Visible = False
            pnlSubAssembly.Visible = False
            cboLocation.SelectedIndex = 0
            ddlMachineGroup.SelectedIndex = 0
            ddlMachineGroup.Items.Clear()
            DataGrid1.DataSource = Nothing
            DataGrid1.DataBind()
            DataGrid2.DataSource = Nothing
            DataGrid2.DataBind()
        End Sub
        Private Sub btnChangeGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeGroup.Click
            lblMessage.Text = ""
            rdoTypeOfGroup.ClearSelection()
            lstMachineCode.ClearSelection()
            lstMachineCode.Items.Clear()
            txtPLNumber.Text = ""
            lblPlDesc.Text = ""
            txtQty.Text = ""
            lblGroupM.Text = ""
            pnlLocation.Visible = True
            pnlGroup.Visible = False
            pnlSpares.Visible = False
            cboLocation.SelectedIndex = 0
            ddlMachineGroup.SelectedIndex = 0
            ddlMachineGroup.Items.Clear()
            DataGrid1.DataSource = Nothing
            DataGrid1.DataBind()
            DataGrid2.DataSource = Nothing
            DataGrid2.DataBind()
        End Sub
        Private Sub btnSaveGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveGroup.Click
            If lstMachineCode.SelectedItem.Selected = False Then
                Exit Sub
            End If
            Dim li As ListItem
            Dim strcmd As String
            Dim blnDone As Boolean
            For Each li In lstMachineCode.Items
                If li.Selected = True Then
                    Dim dsG As New DataSet()
                    Dim dvG As New DataView()
                    dsG = CType(ViewState("vPLNumG"), DataSet)
                    dvG.Table = dsG.Tables(0)
                    dvG.RowFilter = "PLNumber = '" & Trim(txtPlNumberG.Text) & "' and MachineCode = '" & li.Value.Trim & "'"
                    Dim oMacSpares As New Maintenance.Machinery()
                    Try
                        oMacSpares.GroupCode = Trim(lblGrp.Text.ToUpper)
                        oMacSpares.Location = Trim(txtPlNumberG.Text.Trim)
                        oMacSpares.Qty = IIf(IsDBNull(Val(txtQty.Text.Trim)), 0, Val(txtQty.Text.Trim))
                        oMacSpares.EquipmentId = li.Value.Trim
                        oMacSpares.Purpose = IIf(IsDBNull(Trim(txtPurposeG.Text.Trim)), " ", Trim(txtPurposeG.Text.Trim))
                        If oMacSpares.SaveMachineSpares(dvG.Count) Then blnDone = True
                    Catch exp As Exception
                        lblMessage.Text = exp.Message
                    Finally
                        If blnDone Then
                            lblMessage.Text = " Records Updated"
                        Else
                            lblMessage.Text = " Records Not Updated"
                        End If
                    End Try
                    blnDone = False
                End If
            Next
            ViewState("PopGroup") = True
            PopulateGrid2()
            clearG()
        End Sub
        Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
            If Val(txtQtyReqd.Text) = Nothing OrElse Val(txtQtyReqd.Text) = 0 Then
                lblMessage.Text = "  Please fill Qty Required value "
                Exit Sub
            End If
            Dim oSpares As New Maintenance.Machinery()
            Dim strTable As String
            Dim blnDone As Boolean
            Dim blnMachine = CType(ViewState("vSubAssCount"), Boolean)
            If blnMachine = False OrElse rdoTypeOfSpares.SelectedIndex = 0 Then
                blnTable = True
            ElseIf blnMachine = True AndAlso rdoTypeOfSpares.SelectedIndex = 0 Then
                blnTable = True
            ElseIf blnMachine = True AndAlso rdoTypeOfSpares.SelectedIndex = 1 Then
                blnTable = False
            End If
            Try
                saveMode = CType(ViewState("saveMode"), String)
                If blnTable Then
                    strTable = "ms_machine_spares"
                Else
                    strTable = "ms_SubAssembly_spares"
                End If
                oSpares.GroupCode = Trim(lblGrp.Text.ToUpper)
                oSpares.Location = Trim(txtPLNumber.Text.Trim)
                oSpares.Qty = IIf(IsDBNull(Val(txtQtyReqd.Text.Trim)), 0, Val(txtQtyReqd.Text.Trim))
                oSpares.EquipmentId = Trim(ddlMachineCode.SelectedItem.Value.Trim)
                oSpares.Purpose = IIf(IsDBNull(Trim(txtPurpose.Text.Trim)), " ", Trim(txtPurpose.Text.Trim))
                If cboAssembly.SelectedIndex = -1 Then
                    oSpares.Description = ""
                Else
                    oSpares.Description = IIf(IsDBNull(cboAssembly.SelectedItem.Value.Trim), "", Trim(cboAssembly.SelectedItem.Value.Trim))
                End If
                If oSpares.SaveSpares(strTable, saveMode) Then blnDone = True
            Catch exp As Exception
                lblMessage.Text = oSpares.Message & exp.Message
            Finally
                If blnDone Then
                    lblMessage.Text = " Records Updated"
                Else
                    lblMessage.Text &= " Records Not Updated"
                End If
                oSpares = Nothing
                If strTable.Equals("ms_machine_spares") Then
                    PopulateGrid(False)
                Else
                    PopulateGrid(True)
                End If
            End Try
            ViewState("saveMode") = Nothing
            Clear()
            btnSave.Text = "Save"
        End Sub
        Private Sub btnSaveSubAssembly_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveSubAssembly.Click
            If lstSubAssemblyCode.SelectedItem.Selected = False Then
                Exit Sub
            End If
            Dim li As ListItem
            Dim strcmd As String
            Dim blnDone As Boolean
            Try
                For Each li In lstSubAssemblyCode.Items
                    If li.Selected = True Then
                        Dim dsS As New DataSet()
                        Dim dsSm As New DataTable()
                        Dim dvS As New DataView()
                        Dim dvSm As New DataView()
                        dsS = CType(ViewState("vPLNumS"), DataSet)
                        dsSm = CType(ViewState("SubAssemblyList"), DataTable)
                        dvS.Table = dsS.Tables(0)
                        dvS.RowFilter = "PLNumber = '" & Trim(txtPlNumberS.Text) & "' and SubAssemblyCode = '" & li.Value.Trim & "'"
                        dvSm.Table = dsSm
                        dvSm.RowFilter = "code = '" & li.Value.Trim & "'"
                        Dim oSubSpares As New Maintenance.Machinery()
                        Try
                            oSubSpares.GroupCode = Trim(lblGrp.Text.ToUpper)
                            oSubSpares.Location = Trim(txtPlNumberS.Text.Trim)
                            oSubSpares.QtyS = IIf(IsDBNull(Val(txtQtyS.Text.Trim)), 0, Val(txtQtyS.Text.Trim))
                            oSubSpares.Purpose = IIf(IsDBNull(Trim(txtPurposeS.Text.Trim)), " ", Trim(txtPurposeS.Text.Trim))
                            oSubSpares.EquipmentId = dvSm.Item(0)(2)
                            oSubSpares.Description = li.Value.Trim
                            If oSubSpares.SaveSubAssemblySpares(dvS.Count) Then blnDone = True
                        Catch exp As Exception
                            blnDone = False
                            lblMessage.Text = exp.Message
                        Finally
                            If blnDone Then
                                lblMessage.Text = " Records Updated"
                            Else
                                lblMessage.Text = " Records Not Updated"
                            End If
                            oSubSpares = Nothing
                            blnDone = False
                        End Try
                    End If
                Next
                ViewState("PopGroup") = True
                PopulateGrid2()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try

            ClearS()
        End Sub
        Private Sub btnSaveText()
            Dim strText As String
            strText = CType(ViewState("saveMode"), String)
            If strText = "add" Then
                btnSave.Text = "Save"
            ElseIf strText = "edit" Then
                btnSave.Text = "Update"
            ElseIf strText = "delete" Then
                btnSave.Text = "Confirm"
            End If
        End Sub
    End Class
