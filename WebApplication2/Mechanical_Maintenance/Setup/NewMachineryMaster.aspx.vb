Public Class NewMachineryMaster
    Inherits System.Web.UI.Page
    Protected WithEvents ddlLocation As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlEqpCode As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtMachine As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMachineCode As System.Web.UI.WebControls.Label
    Protected WithEvents txtDescription As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblMechMaint As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblElecMaint As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtAMBasedate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtManufacturer As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtModel As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtVendor As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPO As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCost As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPODt As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDtInService As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWarrantyFrom As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWarrantyTo As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblGroupCode As System.Web.UI.WebControls.Label
    Protected WithEvents lblGroupName As System.Web.UI.WebControls.Label
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
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


    Protected Sub dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not IsPostBack Then
            rblMechMaint.Enabled = True
            rblElecMaint.Enabled = True
            txtAMBasedate.Text = Now.Date
            txtDtInService.Text = Now.Date
            txtPODt.Text = Now.Date
            txtWarrantyFrom.Text = Now.Date
            txtWarrantyTo.Text = Now.Date
            Try
                PopulateListBoxes()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
    Private Sub FillDDL(ByRef ddl As System.Web.UI.WebControls.DropDownList, ByRef dt As DataTable)
        ddl.DataSource = dt.DefaultView
        ddl.DataTextField = dt.Columns(1).ColumnName
        ddl.DataValueField = dt.Columns(0).ColumnName
        ddl.DataBind()
        ddl.Items.Insert("0", "Select")
    End Sub
    Private Sub PopulateListBoxes()
        Dim ds As New DataSet()
        Try
            ds = Maintenance.tables.PopulateListBoxes
            FillDDL(ddlLocation, ds.Tables(0))
            FillDDL(ddlEqpCode, ds.Tables(1))
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            ds.Dispose()
        End Try
        Exit Sub
    End Sub

    Private Sub ddlLocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlLocation.SelectedIndexChanged
        lblMessage.Text = ""
        lblMachineCode.Text = ""
        ddlEqpCode.ClearSelection()
        ddlEqpCode.SelectedIndex = 0
        If ddlLocation.SelectedIndex = 0 Then
            lblMessage.Text = "Please select Location code !"
        Else
            lblMachineCode.Text = Trim(ddlLocation.SelectedItem.Value)
            SetMaint()
        End If
    End Sub
    Private Sub SetMaint()
        rblMechMaint.ClearSelection()
        rblElecMaint.ClearSelection()
        lblGroupCode.Text = ""
        lblGroupName.Text = ""
        Try
            Select Case Trim(ddlLocation.SelectedItem.Value)
                Case "AA"
                    SetMechMaint("MA2")
                    SetElecMaint("EAC")
                    lblGroupCode.Text = "WHLSET"
                    lblGroupName.Text = "Axle Assembly"
                Case "AM"
                    SetMechMaint("MA2")
                    SetElecMaint("EAC")
                    lblGroupCode.Text = "AXLST1"
                    lblGroupName.Text = "Axle Machine"
                Case "AC"
                    SetElecMaint("EAC")
                Case "AP"
                    SetElecMaint("EAP")
                Case "CL"
                    SetMechMaint("MW3")
                    SetElecMaint("EW3")
                    lblGroupCode.Text = "AWMCLR"
                    lblGroupName.Text = "Cleaning Room"
                Case "EM"
                    SetMechMaint("EMMS")
                    SetElecMaint("EAC")
                Case "FO"
                    SetMechMaint("MA1")
                    SetElecMaint("EAC")
                    lblGroupCode.Text = "AXLEFG"
                    lblGroupName.Text = "Forge Shop"
                Case "ME"
                    SetMechMaint("MW1")
                    SetElecMaint("EW1")
                    lblGroupCode.Text = "WHLMLT"
                    lblGroupName.Text = "Melting"
                Case "MS"
                    SetMechMaint("MW2")
                    SetElecMaint("EW3")
                    lblGroupCode.Text = "MRSMRS"
                    lblGroupName.Text = "Mould Repair Shop"
                Case "MO"
                    SetMechMaint("MW2")
                    SetElecMaint("EW2")
                    lblGroupCode.Text = "MLDING"
                    lblGroupName.Text = "MOULDING ROOM"
                Case "RT"
                    SetMechMaint("MRT")
                Case "WC"
                    SetElecMaint("EWC")
                Case "WP"
                    SetElecMaint("EWP")
            End Select
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub SetMechMaint(ByVal Loc As String)
        Dim i As Integer
        For i = 0 To rblMechMaint.Items.Count - 1
            If Loc.Trim = rblMechMaint.Items(i).Value.Trim Then
                rblMechMaint.Items(i).Selected = True
                Exit For
            End If
        Next
    End Sub

    Private Sub SetElecMaint(ByVal Loc As String)
        Dim i As Integer
        For i = 0 To rblElecMaint.Items.Count - 1
            If Loc.Trim = rblElecMaint.Items(i).Value.Trim Then
                rblElecMaint.Items(i).Selected = True
                Exit For
            End If
        Next
    End Sub

    Private Sub ddlEqpCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlEqpCode.SelectedIndexChanged
        lblMessage.Text = ""
        lblMachineCode.Text = ""
        If ddlLocation.SelectedIndex = 0 Then
            lblMessage.Text = "Please select Location code !"
        ElseIf ddlEqpCode.SelectedIndex = 0 Then
            lblMessage.Text = "Please Equipment Code !"
        Else
            lblMachineCode.Text = Trim(ddlLocation.SelectedItem.Value)
            lblMachineCode.Text &= Trim(ddlEqpCode.SelectedItem.Value)
        End If
    End Sub

    Private Sub txtMachine_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMachine.TextChanged
        lblMessage.Text = ""
        lblMachineCode.Text = ""
        If ddlLocation.SelectedIndex = 0 Then
            lblMessage.Text = "Please select Location code !"
        ElseIf ddlEqpCode.SelectedIndex = 0 Then
            lblMessage.Text = "Please Equipment Code !"
        ElseIf txtMachine.Text.Trim.Length = 0 Then
            lblMessage.Text = "Please indicate Machine Code !"
        Else
            lblMachineCode.Text = Trim(ddlLocation.SelectedItem.Value)
            lblMachineCode.Text &= Trim(ddlEqpCode.SelectedItem.Value)
            lblMachineCode.Text &= txtMachine.Text.Trim.ToUpper.Trim
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        If txtDescription.Text.Trim.Length = 0 Then
            lblMessage.Text = "InValid Machine description !"
            Exit Sub
        End If
        Dim blnDone As Boolean
        Dim MechUser, ElecUser As String
        Dim done, MechUserSelected, ElecUserSelected As Boolean
        MechUser = ""
        ElecUser = ""
        Dim i As Integer
        For i = 0 To rblMechMaint.Items.Count
            If rblMechMaint.Items(i).Selected Then
                MechUser = rblMechMaint.Items(i).Text.Trim
                MechUserSelected = True
                Exit For
            End If
        Next
        Dim j As Integer
        For j = 0 To rblElecMaint.Items.Count
            If rblElecMaint.Items(j).Selected Then
                ElecUser = rblElecMaint.Items(j).Text.Trim
                ElecUserSelected = True
                Exit For
            End If
        Next
        If MechUserSelected = False AndAlso ElecUserSelected = False Then
            lblMessage.Text = "Please select atleast one from MechMaint and ElecMaint to save the data !"
            Exit Sub
        Else
            Dim am_basedate, po_date, warranty_from, warranty_to, DtInService As Date
            Try
                am_basedate = CDate(txtAMBasedate.Text)
            Catch exp As Exception
                am_basedate = CDate("1900-01-01")
            End Try
            Try
                DtInService = CDate(txtPODt.Text)
            Catch exp As Exception
                DtInService = CDate("1900-01-01")
            End Try
            Try
                po_date = CDate(txtPODt.Text)
            Catch exp As Exception
                po_date = CDate("1900-01-01")
            End Try
            Try
                warranty_from = CDate(txtWarrantyFrom.Text)
            Catch exp As Exception
                warranty_from = CDate("1900-01-01")
            End Try
            Try
                warranty_to = CDate(txtWarrantyTo.Text)
            Catch exp As Exception
                warranty_to = CDate("1900-01-01")
            End Try
            Try
                done = New Maintenance.Machinery().MachineMaster(ddlLocation.SelectedItem.Value, ddlEqpCode.SelectedItem.Value, lblMachineCode.Text, txtDescription.Text.Trim, am_basedate, txtManufacturer.Text.Trim, txtModel.Text, txtVendor.Text, txtPO.Text.Trim, po_date, Val(txtCost.Text.Trim), DtInService, warranty_from, warranty_to, MechUser.Trim, lblGroupCode.Text, lblGroupName.Text, MechUserSelected, ElecUser.Trim)
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            If done Then
                rblMechMaint.ClearSelection()
                rblElecMaint.ClearSelection()
                lblMessage.Text = "Data Saved !"
            Else
                lblMessage.Text &= "Data Not Saved !"
            End If
        End If
    End Sub
End Class
