Public Class NewMachineSparesDelete1
    Inherits System.Web.UI.Page
    Protected WithEvents lblUserID As System.Web.UI.WebControls.Label
    Protected WithEvents lblGrp As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents rdoTypeOfGroup As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents ddlSubAssemlies As System.Web.UI.WebControls.DropDownList
    Protected WithEvents pnlSubAssemlies As System.Web.UI.WebControls.Panel
    Protected WithEvents ddlMachines As System.Web.UI.WebControls.DropDownList
    Protected WithEvents pnlMachine As System.Web.UI.WebControls.Panel
    Protected WithEvents ddlPLNumber As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblUnit As System.Web.UI.WebControls.Label
    Protected WithEvents txtPurpose As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button

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
        If Not IsPostBack Then
            'Session("UserID") = "073533"
            'Session("group") = "RTSHOP"
            If Session("Group") = "RTSHOP" Then
                Session("group") = "MRT"
                lblGrp.Text = "MRT"
                rdoTypeOfGroup.Enabled = False
            Else
                lblGrp.Text = Session("group")
            End If
            Try
                lblUserID.Text = Trim(Session("UserID"))
                lblGrp.Text = Session("group")
                FillDDLs()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
    Private Sub rdoTypeOfGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoTypeOfGroup.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            FillDDLs()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub FillDDLs()
        lblMessage.Text = ""
        Dim dt As New DataTable()
        pnlMachine.Visible = False
        pnlSubAssemlies.Visible = False
        Try
            dt = Maintenance.tables.GetMachineList(lblGrp.Text.Trim, rdoTypeOfGroup.SelectedItem.Text.Trim)
            If rdoTypeOfGroup.SelectedIndex = 0 Then
                pnlMachine.Visible = True
                ddlMachines.DataSource = dt
                ddlMachines.DataTextField = dt.Columns(0).ColumnName
                ddlMachines.DataValueField = dt.Columns(1).ColumnName
                ddlMachines.DataBind()
            Else
                pnlSubAssemlies.Visible = True
                ddlSubAssemlies.DataSource = dt
                ddlSubAssemlies.DataTextField = dt.Columns(0).ColumnName
                ddlSubAssemlies.DataValueField = dt.Columns(1).ColumnName
                ddlSubAssemlies.DataBind()
            End If
        Catch exp As Exception
            Throw New Exception("Data retrival error !")
        End Try
    End Sub

    Private Sub ddlMachines_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMachines.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            GetPLs(ddlMachines.SelectedItem.Value.Trim)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub ddlSubAssemlies_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlSubAssemlies.SelectedIndexChanged
        lblMessage.Text = ""
        Dim pl As Array
        Dim Machine, SubAssembly As String
        Try
            pl = ddlSubAssemlies.SelectedItem.Value.Split("-")
            Machine = pl(0)
            SubAssembly = pl(1)
            GetPLs(Machine.Trim, SubAssembly.Trim)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub GetPLs(ByVal Machine As String, Optional ByVal SubAssembly As String = "")
        lblMessage.Text = ""
        Dim dt As New DataTable()
        txtQty.Text = ""
        txtPurpose.Text = ""
        lblUnit.Text = ""
        pnlMachine.Visible = False
        pnlSubAssemlies.Visible = False
        Try
            If rdoTypeOfGroup.SelectedIndex = 0 Then
                pnlMachine.Visible = True
                dt = Maintenance.tables.GetPLList(lblGrp.Text.Trim, rdoTypeOfGroup.SelectedItem.Text.Trim, Machine)
            Else
                pnlSubAssemlies.Visible = True
                dt = Maintenance.tables.GetPLList(lblGrp.Text.Trim, rdoTypeOfGroup.SelectedItem.Text.Trim, Machine, SubAssembly)
            End If
            ddlPLNumber.DataSource = dt
            ddlPLNumber.DataTextField = dt.Columns(0).ColumnName
            ddlPLNumber.DataValueField = dt.Columns(1).ColumnName
            ddlPLNumber.DataBind()
            ddlPLNumber.Items.Insert("0", "select")
        Catch exp As Exception
            Throw New Exception("Data retrival error !")
        End Try
    End Sub

    Private Sub ddlPLNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlPLNumber.SelectedIndexChanged
        lblMessage.Text = ""
        txtQty.Text = ""
        txtPurpose.Text = ""
        lblUnit.Text = ""
        If ddlPLNumber.SelectedIndex = 0 Then
            lblMessage.Text = "Please select PL Number !"
            Exit Sub
        Else
            Dim dt As New DataTable()
            Dim pl As Array
            Dim Machine, SubAssembly As String
            Try
                If rdoTypeOfGroup.SelectedIndex = 0 Then
                    pnlMachine.Visible = True
                    dt = Maintenance.tables.GetPLListValues(ddlPLNumber.SelectedItem.Value.Trim, lblGrp.Text.Trim, rdoTypeOfGroup.SelectedItem.Text.Trim, ddlMachines.SelectedItem.Value.Trim)
                Else
                    pl = ddlSubAssemlies.SelectedItem.Value.Split("-")
                    Machine = pl(0)
                    SubAssembly = pl(1)
                    pnlSubAssemlies.Visible = True
                    dt = Maintenance.tables.GetPLListValues(ddlPLNumber.SelectedItem.Value.Trim, lblGrp.Text.Trim, rdoTypeOfGroup.SelectedItem.Text.Trim, Machine, SubAssembly)
                End If
                txtQty.Text = dt.Rows(0)("qtyreqd") & ""
                txtPurpose.Text = dt.Rows(0)("purpose") & ""
                lblUnit.Text = dt.Rows(0)("Unit") & ""
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Val(txtQty.Text) = Nothing OrElse Val(txtQty.Text) = 0 Then
            lblMessage.Text = "  Please fill Qty Required value "
            Exit Sub
        End If
        Dim oSpares As New Maintenance.Machinery()
        Dim strTable As String
        Dim blnDone As Boolean
        Try
            If rdoTypeOfGroup.SelectedIndex = 0 Then
                strTable = "ms_machine_spares"
                oSpares.Location = ddlPLNumber.SelectedItem.Value.Trim
                oSpares.Qty = IIf(IsDBNull(Val(txtQty.Text.Trim)), 0, Val(txtQty.Text.Trim))
                oSpares.EquipmentId = Trim(ddlMachines.SelectedItem.Value.Trim)
                oSpares.Description = ""
            Else
                strTable = "ms_SubAssembly_spares"
                oSpares.Location = ddlPLNumber.SelectedItem.Value.Trim
                oSpares.Qty = IIf(IsDBNull(Val(txtQty.Text.Trim)), 0, Val(txtQty.Text.Trim))
                Dim pl As Array
                Dim Machine, SubAssembly As String
                pl = ddlSubAssemlies.SelectedItem.Value.Split("-")
                Machine = pl(0)
                SubAssembly = pl(1)
                oSpares.EquipmentId = Trim(Machine)
                oSpares.Description = IIf(IsDBNull(SubAssembly.Trim), "", Trim(SubAssembly))
            End If
            oSpares.GroupCode = Trim(lblGrp.Text.ToUpper)
            oSpares.Purpose = IIf(IsDBNull(Trim(txtPurpose.Text.Trim)), " ", Trim(txtPurpose.Text.Trim))
            If oSpares.SaveSpares(strTable, "delete") Then blnDone = True
        Catch exp As Exception
            lblMessage.Text = oSpares.Message & exp.Message
        Finally
            If blnDone Then
                lblMessage.Text = " Records Updated"
            Else
                lblMessage.Text = " Records Not Updated"
            End If
            oSpares = Nothing
        End Try
    End Sub

End Class
