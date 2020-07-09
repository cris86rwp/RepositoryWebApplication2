Public Class majorSubAssemblyNew
    Inherits System.Web.UI.Page
    Protected WithEvents ddlMachineGroup As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblMaintenance_group As System.Web.UI.WebControls.Label
    Protected WithEvents radParent As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents ddlLocation As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents btnSaveGroup As System.Web.UI.WebControls.Button
    Protected WithEvents btnChangeGroupG As System.Web.UI.WebControls.Button
    Protected WithEvents lstMachineCode As System.Web.UI.WebControls.ListBox
    Protected WithEvents lblGroupG As System.Web.UI.WebControls.Label
    Protected WithEvents lblLocationG As System.Web.UI.WebControls.Label
    Protected WithEvents btnChangeGroupS As System.Web.UI.WebControls.Button
    Protected WithEvents lstSubAssemblyCode As System.Web.UI.WebControls.ListBox
    Protected WithEvents lblGroupS As System.Web.UI.WebControls.Label
    Protected WithEvents lblLocationS As System.Web.UI.WebControls.Label
    Protected WithEvents pnlSubAssembly As System.Web.UI.WebControls.Panel
    Protected WithEvents txtSubAssemblyCode As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSubAssemblyDesc As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNextSubAssemblyCode As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNextSubAssemblyDesc As System.Web.UI.WebControls.TextBox
    Protected WithEvents pnlMachineList As System.Web.UI.WebControls.Panel
    Protected WithEvents ddlMachineCode As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblGroupM As System.Web.UI.WebControls.Label
    Protected WithEvents lblLocationM As System.Web.UI.WebControls.Label
    Protected WithEvents pnlMachine As System.Web.UI.WebControls.Panel
    Protected WithEvents btnSaveSubAssemblies As System.Web.UI.WebControls.Button
    Protected WithEvents btnChangeGroup As System.Web.UI.WebControls.Button
    Protected WithEvents btnSaveSubAssembly As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtMacSubAssemblyCode As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMacSubAssemblyDesc As System.Web.UI.WebControls.TextBox
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblGrp As System.Web.UI.WebControls.Label
    Protected WithEvents lblUserID As System.Web.UI.WebControls.Label
    Protected WithEvents pnlLocation As System.Web.UI.WebControls.Panel
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
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        lblGrp.Visible = False
        lblUserID.Visible = False
        'Dim strMod As String = "ADD"
        'Session("UserID") = "271080"
        'Session("group") = "MW2"
        'Session("UserID") = "430094"
        'Session("group") = "MW1"
        lblGrp.Text = Trim(Session("group"))
        lblUserID.Text = Trim(Session("UserID"))
        lblMaintenance_group.Text = lblGrp.Text.Trim.Substring(1)
        If ViewState("saveMode") Is Nothing Then
            btnSaveSubAssembly.Text = "SaveSubAssembly"
        End If
        If Not Page.IsPostBack Then
            pnlLocation.Visible = True
            pnlMachine.Visible = False
            pnlMachineList.Visible = False
            pnlSubAssembly.Visible = False
            PopulateLocation()
        End If
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



    Private Sub PopulateLocation()
        Dim dvGroup As New DataView()
        Dim ds As New DataSet()
        Try
            ds = Maintenance.tables.PopulateLocation(lblUserID.Text.Trim)
            ddlLocation.DataSource = ds.Tables(0).DefaultView
            ddlLocation.DataTextField = ds.Tables(0).Columns(1).ColumnName
            ddlLocation.DataValueField = ds.Tables(0).Columns(0).ColumnName
            ddlLocation.DataBind()
            ddlLocation.Items.Insert(0, New ListItem("Select", "0"))
            ddlLocation.SelectedIndex = 0
            dvGroup.Table = ds.Tables(1)
            lblGrp.Text = dvGroup.Item(0)(0)
            lblMaintenance_group.Text = lblGrp.Text.Trim.Substring(1)
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
            dt = Maintenance.tables.PopulateMachineGroup(ddlLocation.SelectedItem.Value)
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
            dt = Maintenance.tables.PopulateMachineCode(Trim(ddlLocation.SelectedItem.Value), ddlMachineGroup.SelectedItem.Value.Trim)
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
    Private Sub PopulateMachineList()
        Dim dt As New DataTable()
        lstMachineCode.Items.Clear()
        Try
            dt = Maintenance.tables.PopulateMachineCode(Trim(ddlLocation.SelectedItem.Value), ddlMachineGroup.SelectedItem.Value.Trim)
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
            dt = Maintenance.tables.PopulateSubAssemblyList(Trim(ddlLocation.SelectedItem.Value), ddlMachineGroup.SelectedItem.Value.Trim)
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
    Private Sub PopulateGrid1()
        Dim ds As New DataSet()
        Try
            ds = Maintenance.tables.PopulateGrid(radParent.SelectedIndex, lblGrp.Text.Trim, IIf(IsNothing(ddlMachineGroup.SelectedItem.Value.Trim), "", ddlMachineGroup.SelectedItem.Value.Trim), IIf(IsNothing(ddlLocation.SelectedItem.Value.Trim), "", ddlLocation.SelectedItem.Value.Trim), IIf(IsNothing(ddlMachineCode.SelectedItem.Value.Trim), "", ddlMachineCode.SelectedItem.Value.Trim))
            If radParent.SelectedIndex = 0 Then
                viewstate("SubAssm") = ds
                If ds.Tables(0).Rows.Count > 0 Then DataGrid2.DataSource = ds.Tables(0).DefaultView Else DataGrid2.DataSource = Nothing
                DataGrid2.DataBind()
            ElseIf radParent.SelectedIndex = 1 Then
                viewstate("SubAssmList") = ds
                If ds.Tables(0).Rows.Count > 0 Then DataGrid1.DataSource = ds.Tables(0).DefaultView Else DataGrid1.DataSource = Nothing
                DataGrid1.DataBind()
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            ds.Dispose()
        End Try
    End Sub
    Private Sub ddlLocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlLocation.SelectedIndexChanged
        PopulateMachineGroup()
    End Sub
    Private Sub radParent_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radParent.SelectedIndexChanged
        lblMessage.Text = ""
        If ddlMachineGroup.Items.Count = 0 OrElse ddlMachineGroup.SelectedItem.Text = "Select" OrElse ddlMachineGroup.SelectedIndex = 0 Then
            lblMessage.Text = " Please select machine group"
            radParent.ClearSelection()
        Else
            If radParent.SelectedIndex = 0 Then
                pnlLocation.Visible = False
                pnlMachineList.Visible = False
                pnlSubAssembly.Visible = False
                pnlMachine.Visible = True
                lblLocationM.Text = ddlLocation.SelectedItem.Text
                lblGroupM.Text = ddlMachineGroup.SelectedItem.Text.Trim
                PopulateMachineCode()
            ElseIf radParent.SelectedIndex = 1 Then
                pnlLocation.Visible = False
                pnlMachineList.Visible = True
                pnlSubAssembly.Visible = False
                pnlMachine.Visible = False
                lblLocationG.Text = ddlLocation.SelectedItem.Text
                lblGroupG.Text = ddlMachineGroup.SelectedItem.Text.Trim
                PopulateMachineList()
            ElseIf radParent.SelectedIndex = 2 Then
                pnlLocation.Visible = False
                pnlMachineList.Visible = False
                pnlSubAssembly.Visible = True
                pnlMachine.Visible = False
                lblLocationS.Text = ddlLocation.SelectedItem.Text
                lblGroupS.Text = ddlMachineGroup.SelectedItem.Text.Trim
                PopulateSubAssemblyList()
            End If
            PopulateGrid1()
        End If
    End Sub
    Private Sub btnChangeGroupS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeGroupS.Click
        lblMessage.Text = ""
        radParent.ClearSelection()
        lstSubAssemblyCode.ClearSelection()
        lstSubAssemblyCode.Items.Clear()
        txtNextSubAssemblyCode.Text = ""
        txtNextSubAssemblyDesc.Text = ""
        lblLocationS.Text = ""
        lblGroupS.Text = ""
        pnlLocation.Visible = True
        pnlMachine.Visible = False
        pnlMachineList.Visible = False
        pnlSubAssembly.Visible = False
        ddlLocation.SelectedIndex = 0
        ddlMachineGroup.SelectedIndex = 0
        ddlMachineGroup.Items.Clear()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
    End Sub
    Private Sub btnChangeGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeGroup.Click
        lblMessage.Text = ""
        radParent.ClearSelection()
        lstMachineCode.ClearSelection()
        lstMachineCode.Items.Clear()
        txtMacSubAssemblyCode.Text = ""
        txtMacSubAssemblyDesc.Text = ""
        lblLocationM.Text = ""
        lblGroupM.Text = ""
        pnlLocation.Visible = True
        pnlSubAssembly.Visible = False
        pnlMachine.Visible = False
        pnlMachineList.Visible = False
        ddlLocation.SelectedIndex = 0
        ddlMachineGroup.SelectedIndex = 0
        ddlMachineGroup.Items.Clear()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
    End Sub
    Private Sub btnChangeGroupG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeGroupG.Click
        lblMessage.Text = ""
        radParent.ClearSelection()
        lstMachineCode.ClearSelection()
        lstMachineCode.Items.Clear()
        txtSubAssemblyCode.Text = ""
        txtSubAssemblyDesc.Text = ""
        lblLocationG.Text = ""
        lblGroupG.Text = ""
        pnlLocation.Visible = True
        pnlSubAssembly.Visible = False
        pnlMachineList.Visible = False
        pnlMachine.Visible = False
        ddlLocation.SelectedIndex = 0
        ddlMachineGroup.SelectedIndex = 0
        ddlMachineGroup.Items.Clear()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
    End Sub
    Private Sub btnSaveSubAssembly_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveSubAssembly.Click
        lblMessage.Text = ""
        If IsNothing(ddlMachineCode.SelectedItem) Then
            lblMessage.Text = "Please select a MachineCode from dropdownlist"
        Else
            Dim strcmd, saveMode As String
            Dim blnDone, blnMacSubAssmNotFound As Boolean
            Dim strCode, strGroup, strCodeCheck As String
            strGroup = lblGrp.Text.Trim
            strCode = txtMacSubAssemblyCode.Text.ToUpper.Trim + ddlMachineCode.SelectedItem.Value.Substring(5, (ddlMachineCode.SelectedItem.Value.Length - 5))
            strCodeCheck = txtMacSubAssemblyCode.Text.ToUpper.Trim
            Dim dsM As New DataSet()
            Dim dvM As New DataView()
            dsM = CType(viewstate("SubAssm"), DataSet)
            dvM.Table = dsM.Tables(0)
            dvM.RowFilter = "parent_equipment_code = '" & ddlMachineCode.SelectedItem.Value.Trim & "' and SubAssemblyCode = '" & strCodeCheck.Trim & "'"
            If viewstate("saveMode") = "delete" Then
                saveMode = "delete"
                btnSaveSubAssembly.Text = "CONFIRM"
            Else
                btnSaveSubAssembly.Text = "SaveSubAssembly"
                If dvM.Count = 0 Then
                    dvM.RowFilter = "parent_equipment_code = '" & ddlMachineCode.SelectedItem.Value.Trim & "' and SubAssemblyCode = '" & strCode.Trim & "'"
                    If dvM.Count = 0 Then
                        blnMacSubAssmNotFound = True
                    Else
                        blnMacSubAssmNotFound = False
                    End If
                Else
                    blnMacSubAssmNotFound = False
                End If
                If blnMacSubAssmNotFound Then saveMode = "add" Else saveMode = "edit"
            End If
            Dim oSub As New Maintenance.Machinery()
            Try
                oSub.EquipmentId = ddlMachineCode.SelectedItem.Value.Trim
                If dvM.Count = 0 Then
                    oSub.Location = strCode.Trim
                    oSub.Description = ddlMachineCode.SelectedItem.Value.ToString.Substring(5, (ddlMachineCode.SelectedItem.Value.Length - 5)) + "  " + txtMacSubAssemblyDesc.Text.ToUpper.Trim
                ElseIf viewstate("saveMode") = "delete" Then
                    oSub.Location = strCodeCheck.Trim
                    oSub.Description = txtMacSubAssemblyDesc.Text.ToUpper.Trim
                Else
                    oSub.Location = strCodeCheck.Trim
                    oSub.Description = txtMacSubAssemblyDesc.Text.ToUpper.Trim
                End If
                oSub.GroupCode = strGroup.Trim
                oSub.Purpose = radParent.SelectedItem.Value.Substring(0, 1).ToLower
                If oSub.SaveSubAssembly(saveMode) Then blnDone = True
            Catch exp As Exception
                blnDone = False
                lblMessage.Text = exp.Message
            Finally
                If blnDone Then
                    lblMessage.Text = " Records Updated"
                Else
                    lblMessage.Text = " Records Not Updated"
                End If
                oSub = Nothing
            End Try
            viewstate("PopGroup") = True
            If viewstate("saveMode") = "delete" Then
                viewstate("saveMode") = Nothing
                btnSaveSubAssembly.Text = "SaveSubAssembly"
            End If
            PopulateGrid1()
            clearM()
        End If
    End Sub
    Private Sub btnSaveGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveGroup.Click
        lblMessage.Text = ""
        If IsNothing(lstMachineCode.SelectedItem) Then
            lblMessage.Text = "Please select at least one machine from Machine List"
        Else
            Dim li As ListItem
            Dim strcmd As String
            Dim blnDone As Boolean
            For Each li In lstMachineCode.Items
                If li.Selected = True Then
                    Dim strCode, strGroup, strCodeCheck As String
                    Dim blnSubAssmNotFound As Boolean
                    strGroup = lblGrp.Text.Trim
                    strCode = txtSubAssemblyCode.Text.ToUpper.Trim + li.Value.Substring(5, li.Value.Length - 5)
                    strCodeCheck = txtSubAssemblyCode.Text.ToUpper.Trim
                    Dim dsG As New DataSet()
                    Dim dvG As New DataView()
                    dsG = CType(viewstate("SubAssmList"), DataSet)
                    dvG.Table = dsG.Tables(0)
                    dvG.RowFilter = "parent_equipment_code = '" & li.Value.Trim & "' and SubAssemblyCode = '" & strCodeCheck.Trim & "'"
                    If dvG.Count = 0 Then
                        dvG.RowFilter = "parent_equipment_code = '" & li.Value.Trim & "' and SubAssemblyCode = '" & strCode.Trim & "'"
                        If dvG.Count = 0 Then blnSubAssmNotFound = True Else blnSubAssmNotFound = False
                    Else
                        blnSubAssmNotFound = False
                    End If
                    Dim saveMode As String
                    If blnSubAssmNotFound Then saveMode = "add" Else saveMode = "edit"
                    Dim oSub As New Maintenance.Machinery()
                    Try
                        oSub.EquipmentId = li.Value.Trim
                        If blnSubAssmNotFound Then
                            oSub.Location = strCode.Trim
                            oSub.Description = li.Value.Substring(5, (li.Value.Length - 5)) + "   " + txtSubAssemblyDesc.Text.ToUpper.Trim
                        Else
                            oSub.Location = strCodeCheck.Trim
                            oSub.Description = txtSubAssemblyDesc.Text.ToUpper.Trim
                        End If
                        oSub.GroupCode = strGroup.Trim
                        oSub.Purpose = radParent.SelectedItem.Value.Substring(0, 1).ToLower
                        If oSub.SaveSubAssembly(saveMode) Then blnDone = True
                    Catch exp As Exception
                        blnDone = False
                        lblMessage.Text = exp.Message
                    Finally
                        If blnDone Then
                            lblMessage.Text = " Records Updated"
                        Else
                            lblMessage.Text = " Records Not Updated"
                        End If
                    End Try
                End If
            Next
            viewstate("PopGroup") = True
            PopulateGrid1()
            clearG()
        End If

    End Sub
    Private Sub clearG()
        lstMachineCode.ClearSelection()
        txtSubAssemblyCode.Text = ""
        txtSubAssemblyDesc.Text = ""
    End Sub
    Private Sub clearM()
        ddlMachineCode.ClearSelection()
        txtMacSubAssemblyCode.Text = ""
        txtMacSubAssemblyDesc.Text = ""
    End Sub
    Private Sub ddlMachineCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMachineCode.SelectedIndexChanged
        PopulateGrid1()
    End Sub
    Private Sub btnSaveSubAssemblies_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveSubAssemblies.Click

    End Sub
    Private Sub DataGrid2_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid2.ItemCommand
        lblMessage.Text = ""
        Select Case e.CommandName
            Case "Delete"
                Dim i As Integer
                If Not e.Item.Cells(1).Text Is Nothing Then
                    For i = 0 To ddlMachineCode.Items.Count - 1
                        If ddlMachineCode.Items(i).Value.Trim = e.Item.Cells(1).Text.Trim Then
                            ddlMachineCode.SelectedIndex = i
                        End If
                    Next
                End If
                txtMacSubAssemblyCode.Text = e.Item.Cells(2).Text
                txtMacSubAssemblyDesc.Text = IIf(IsDBNull(e.Item.Cells(3).Text), "", e.Item.Cells(3).Text)
                viewstate("saveMode") = "delete"
                btnSaveSubAssembly.Text = "CONFIRM"
        End Select
    End Sub

    Private Sub ddlMachineGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMachineGroup.SelectedIndexChanged

    End Sub
End Class
