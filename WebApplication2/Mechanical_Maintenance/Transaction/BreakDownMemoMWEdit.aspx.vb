Imports System.Net
Imports System.Web
Imports System.Collections.Specialized
Imports System.IO
Imports System.Text
Imports System.Net.Mail
Public Class BreakDownMemoMWEdit
    Inherits System.Web.UI.Page
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblGroup As System.Web.UI.WebControls.Label
    Protected WithEvents lblUserID As System.Web.UI.WebControls.Label
    Protected WithEvents rblBDShop As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblBDType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblMemo As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtStaff As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPLNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnPls As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents rblSpares As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents ddlSparesList As System.Web.UI.WebControls.DropDownList
    Protected WithEvents pnlSpares As System.Web.UI.WebControls.Panel
    Protected WithEvents txtWorkDone As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnClear As System.Web.UI.WebControls.Button
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents grdSpares As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtPlQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMachineCode As System.Web.UI.WebControls.Label
    Protected WithEvents lblSubAssembly As System.Web.UI.WebControls.Label
    Protected WithEvents rblTypeOfFailure As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents lblFailure As System.Web.UI.WebControls.Label
    Protected WithEvents lblMaintenanceGroup As System.Web.UI.WebControls.Label
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
    Public Property MessageBox As Object
    Public Property MessageBoxButtons As Object
    Public Property MessageBoxIcon As Object

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
        lblMachineCode.Visible = False
        lblSubAssembly.Visible = False
        lblFailure.Visible = False
        If Not Page.IsPostBack Then
            lblGroup.Visible = False
            lblUserID.Visible = False
            txtDate.Text = Now.Date
            lblUserID.Text = Session("UserID")
            If Trim(Session("Group")) = "RTSHOP" Then
                lblGroup.Text = "MRT"
            Else
                lblGroup.Text = Trim(Session("Group"))
            End If
            ''+++++++++++++
            lblUserID.Text = Session("UserID")
            lblGroup.Text = Session("Group")
            'lblUserID.Text = "430094"
            'lblGroup.Text = "MW1"

            ''+++++++++++++
            Try
                pnlSpares.Visible = False
                Clear()
                ClearSpares()
                ClearDetails()
                FillBDShop()
                If rblBDShop.Items.Count > 0 Then
                    FillBDType()
                    FillMemoSlipNos()
                    FillMemoDetails()
                End If
            Catch exp As Exception
                lblMessage.Text &= exp.Message
            End Try
        End If
    End Sub

    Private Sub Clear()
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim cnt As Int16
        dt.TableName = "spares"
        dt.Columns.Add("PlNumber")
        dt.Columns.Add("Description")
        dt.Columns.Add("Unit")
        dt.Columns.Add("Quantity")
        grdSpares.DataSource = dt
        grdSpares.DataBind()
        ddlSparesList.Items.Clear()
        rblSpares.SelectedIndex = 0
        pnlSpares.Visible = False
    End Sub

    Private Sub ClearSpares()
        txtPLNumber.Text = ""
        txtPlQty.Text = ""
    End Sub

    Private Sub ClearDetails()
        txtStaff.Text = ""
        txtWorkDone.Text = ""
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
    End Sub

    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        lblMessage.Text = ""
        Try
            Clear()
            ClearSpares()
            ClearDetails()
            txtDate.Text = CDate(txtDate.Text)
            rblBDShop.Items.Clear()
            rblBDType.Items.Clear()
            rblMemo.Items.Clear()
            FillBDShop()
            If rblBDShop.Items.Count > 0 Then
                FillBDType()
                If lblMessage.Text.Trim.Length = 0 Then
                    FillMemoSlipNos()
                    FillMemoDetails()
                End If
            End If
        Catch
            If lblMessage.Text.Trim.Length = 0 Then
                lblMessage.Text = "Enter BreakDown date in 'dd/MM/yyyy' Format"
                txtDate.Text = ""
            End If
        End Try
    End Sub

    Private Sub FillBDShop()
        Clear()
        ClearSpares()
        ClearDetails()
        Dim dtMemo As DataTable
        rblBDShop.Items.Clear()
        Try
            dtMemo = Maintenance.NewBDMemo.GetBDShops(CDate(txtDate.Text), lblGroup.Text)
            If dtMemo.Rows.Count > 0 Then
                rblBDShop.DataSource = dtMemo
                rblBDShop.DataTextField = dtMemo.Columns(0).ColumnName
                rblBDShop.DataValueField = dtMemo.Columns(1).ColumnName
                rblBDShop.DataBind()
                rblBDShop.SelectedIndex = 0
            Else
                Throw New Exception("No Break-Downs booked for the Date : " & CDate(txtDate.Text) & " for your Login !")
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dtMemo.Dispose()
            dtMemo = Nothing
        End Try
    End Sub

    Private Sub FillBDType()
        Clear()
        ClearSpares()
        ClearDetails()
        Dim dtMemo As DataTable
        rblBDType.Items.Clear()
        Try
            dtMemo = Maintenance.NewBDMemo.GetBDCodeType(CDate(txtDate.Text), lblGroup.Text.Trim, rblBDShop.SelectedItem.Value)
            If dtMemo.Rows.Count > 0 Then
                rblBDType.DataSource = dtMemo
                rblBDType.DataTextField = dtMemo.Columns(0).ColumnName
                rblBDType.DataValueField = dtMemo.Columns(1).ColumnName
                rblBDType.DataBind()
                rblBDType.SelectedIndex = 0
            Else
                Throw New Exception("No Break-Downs Types !")
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dtMemo.Dispose()
            dtMemo = Nothing
        End Try
    End Sub

    Private Sub FillMemoSlipNos()
        Clear()
        ClearSpares()
        ClearDetails()
        Dim dtMemo As DataTable
        rblMemo.Items.Clear()
        Try
            dtMemo = Maintenance.NewBDMemo.GetBDMemoSlipNos(CDate(txtDate.Text), lblGroup.Text, rblBDShop.SelectedItem.Value, rblBDType.SelectedItem.Value)
            If dtMemo.Rows.Count > 0 Then
                rblMemo.DataSource = dtMemo
                rblMemo.DataTextField = dtMemo.Columns(1).ColumnName
                rblMemo.DataValueField = dtMemo.Columns(0).ColumnName
                rblMemo.DataBind()
                rblMemo.SelectedIndex = 0
            Else
                Throw New Exception("No Break-Downs Memos !")
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dtMemo.Dispose()
            dtMemo = Nothing
        End Try
    End Sub

    Private Sub FillMemoDetails()
        Clear()
        ClearSpares()
        ClearDetails()
        Dim dtMemo As DataTable
        Try
            dtMemo = Maintenance.NewBDMemo.GetBDMemoSlipDetails(CDate(txtDate.Text), rblBDShop.SelectedItem.Value, rblMemo.SelectedItem.Value)
            If dtMemo.Rows.Count > 0 Then
                lblMachineCode.Text = IIf(IsDBNull(dtMemo.Rows(0)("machine_code")), "", dtMemo.Rows(0)("machine_code"))
                lblSubAssembly.Text = IIf(IsDBNull(dtMemo.Rows(0)("SubAssemblyName")), "", dtMemo.Rows(0)("SubAssemblyName"))
                lblFailure.Text = IIf(IsDBNull(dtMemo.Rows(0)("failure_nature")), "", dtMemo.Rows(0)("failure_nature"))
                lblMaintenanceGroup.Text = IIf(IsDBNull(dtMemo.Rows(0)("maintenance_group")), "", dtMemo.Rows(0)("maintenance_group"))
                txtStaff.Text = IIf(IsDBNull(dtMemo.Rows(0)("staff")), "", dtMemo.Rows(0)("staff"))
                txtWorkDone.Text = IIf(IsDBNull(dtMemo.Rows(0)("work_done")), "", dtMemo.Rows(0)("work_done"))
                DataGrid1.DataSource = Maintenance.NewBDMemo.GetBDMemoSlipDetails1(CDate(txtDate.Text), rblBDShop.SelectedItem.Value, rblMemo.SelectedItem.Value)
                DataGrid1.DataBind()
                dtMemo = Maintenance.NewBDMemo.GetBDMemoSlipSparesDetails(lblMachineCode.Text, lblGroup.Text.Substring(1), rblMemo.SelectedItem.Value)
                If dtMemo.Rows.Count > 0 Then
                    grdSpares.DataSource = dtMemo
                    grdSpares.DataBind()
                    pnlSpares.Visible = True
                End If
            Else
                Throw New Exception("No Break-Downs Memos !")
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dtMemo.Dispose()
            dtMemo = Nothing
        End Try
    End Sub

    Private Sub rblBDShop_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblBDShop.SelectedIndexChanged
        Clear()
        ClearSpares()
        ClearDetails()
        lblMessage.Text = ""
        Try
            FillBDType()
            If lblMessage.Text.Trim.Length = 0 Then
                FillMemoSlipNos()
                If lblMessage.Text.Trim.Length = 0 Then
                    FillMemoDetails()
                End If
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub rblBDType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblBDType.SelectedIndexChanged
        lblMessage.Text = ""
        Clear()
        ClearSpares()
        ClearDetails()
        Try
            FillMemoSlipNos()
            If lblMessage.Text.Trim.Length = 0 Then
                FillMemoDetails()
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub rblMemo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblMemo.SelectedIndexChanged
        lblMessage.Text = ""
        Clear()
        ClearSpares()
        ClearDetails()
        Try
            FillMemoDetails()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub rblSpares_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblSpares.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            SetSpares()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub SetSpares()
        If grdSpares.Items.Count = 0 Then
            grdSpares.DataSource = Nothing
            grdSpares.DataBind()
        End If
        pnlSpares.Visible = False
        If rblSpares.SelectedIndex > 0 Then
            pnlSpares.Visible = True
            get_Spares()
        Else
            ddlSparesList.Items.Clear()
        End If
    End Sub

    Private Sub get_Spares()
        Dim dt As DataTable
        Try
            ddlSparesList.Items.Clear()
            If lblSubAssembly.Text.Trim.Length < 1 Then
                dt = Maintenance.tables.Spares(lblGroup.Text, lblMachineCode.Text)
            Else
                dt = Maintenance.tables.Spares(lblGroup.Text, lblMachineCode.Text, lblSubAssembly.Text)
            End If
            If dt.Rows.Count > 0 Then
                ddlSparesList.DataSource = dt.DefaultView
                ddlSparesList.DataTextField = dt.Columns(1).ColumnName
                ddlSparesList.DataValueField = dt.Columns(0).ColumnName
                ddlSparesList.DataBind()
                ddlSparesList.Items.Insert(0, "select")
            Else
                Throw New Exception("No Spares List for the Machine Code : " & lblMachineCode.Text & " ! But Spares can be added by entering PL Number in PL TextBox !")
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
            dt = Nothing
        End Try
    End Sub

    Private Sub btnPls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPls.Click
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
            dt.Columns.Add("PlNumber")
            dt.Columns.Add("PLDescription")
            dt.Columns.Add("Unit")
            dt.Columns.Add("Qty")
            If grdSpares.Items.Count > 0 Then
                For cnt = 0 To grdSpares.Items.Count - 1
                    If grdSpares.Items(cnt).Cells(0).Text.Trim <> Trim(txtPLNumber.Text) Then
                        dr = dt.NewRow
                        dr("PlNumber") = grdSpares.Items(cnt).Cells(0).Text
                        dr("PLDescription") = grdSpares.Items(cnt).Cells(1).Text
                        dr("Unit") = grdSpares.Items(cnt).Cells(2).Text
                        dr("Qty") = grdSpares.Items(cnt).Cells(3).Text
                        dt.Rows.Add(dr)
                    Else
                        lblMessage.Text = "PL Number : " & txtPLNumber.Text & " already exists !"
                    End If
                Next
            End If
            dtPl = Maintenance.tables.PLDetails(Trim(txtPLNumber.Text))
            If Trim(IIf(IsDBNull(dtPl.Rows(0)("pl_number")), 0, dtPl.Rows(0)("pl_number"))) = 0 Then
                lblMessage.Text = "Pl Number : " & txtPLNumber.Text & " do not exists..."
                txtPLNumber.Text = ""
                Exit Sub
            Else
                desc = Trim(IIf(IsDBNull(dtPl.Rows(0)("PlShortName")), "", dtPl.Rows(0)("PlShortName")))
                unit = Trim(IIf(IsDBNull(dtPl.Rows(0)("PlUnitName")), "", dtPl.Rows(0)("PlUnitName")))
            End If

            dr = dt.NewRow
            dr("PlNumber") = txtPLNumber.Text
            dr("PLDescription") = Trim(desc)
            dr("Unit") = Trim(unit)
            dr("Qty") = txtPlQty.Text
            dt.Rows.Add(dr)
            grdSpares.DataSource = dt
            grdSpares.DataBind()
            txtPLNumber.Text = ""
            txtPlQty.Text = ""
            ddlSparesList.SelectedIndex = 0
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        Finally
            dt.Dispose()
            dtPl.Dispose()
            dt = Nothing
            dtPl = Nothing
        End Try
    End Sub

    Private Sub ddlSparesList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlSparesList.SelectedIndexChanged
        lblMessage.Text = ""
        txtPlQty.Text = ""
        If ddlSparesList.SelectedIndex = 0 Then
            txtPLNumber.Text = ""
            Exit Sub
        End If
        Dim dt As DataTable
        Try
            txtPLNumber.Text = ddlSparesList.SelectedItem.Value
            If lblSubAssembly.Text = "" Then
                dt = Maintenance.tables.Spares(lblGroup.Text, lblMachineCode.Text, , txtPLNumber.Text.Trim)
            Else
                dt = Maintenance.tables.Spares(lblGroup.Text, lblMachineCode.Text, lblSubAssembly.Text.Trim, txtPLNumber.Text.Trim)
            End If

            If Not IsDBNull(dt.Rows(0)("qtyreqd")) Then
                txtPlQty.Text = dt.Rows(0)("qtyreqd")
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
            dt = Nothing
        End Try
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        lblMessage.Text = ""
        Clear()
        ClearSpares()
        ClearDetails()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim Done As Boolean
        Dim oBrk As New Maintenance.Breakdown()
        Try
            Dim cnt As Int16
            Dim dt As New DataTable()
            Dim dr As DataRow
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
                oBrk.SparesList = dt
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
                oBrk = Nothing
                Exit Sub
            End If
            oBrk.Machinery.GroupCode = lblMaintenanceGroup.Text.Trim
            oBrk.MemoNumber = rblMemo.SelectedItem.Value
            oBrk.SparesNumber = rblMemo.SelectedItem.Value
            oBrk.MachineCode = lblMachineCode.Text
            oBrk.ShopCode = rblBDShop.SelectedItem.Value
            oBrk.Staff = txtStaff.Text.Trim
            oBrk.FailureNature = lblFailure.Text
            oBrk.SubAssembly = lblSubAssembly.Text
            oBrk.WorkDone = txtWorkDone.Text.Trim
            oBrk.Operator1 = lblUserID.Text
            oBrk.Group = lblGroup.Text.Substring(1)
            oBrk.Type = "B"
            oBrk.FailureType = rblTypeOfFailure.SelectedItem.Value
            oBrk.BreakdownType = ""
            If oBrk.SaveWorkDoneDetails(oBrk.MemoNumber) Then Done = True
        Catch exp As Exception
            lblMessage.Text &= exp.Message
            oBrk = Nothing
        End Try
        If Done Then
            lblMessage.Text &= "Record Updated..."


            Clear()
            ClearSpares()
            ClearDetails()
            rblBDType.SelectedIndex = 0
            rblBDShop.SelectedIndex = 0
        Else
            lblMessage.Text &= "Record Updatedtion Failed ! "
        End If
    End Sub

End Class
