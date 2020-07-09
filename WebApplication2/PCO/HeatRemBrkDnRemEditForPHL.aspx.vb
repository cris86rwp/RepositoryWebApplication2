Public Class HeatRemBrkDnRemEditForPHL
    Inherits System.Web.UI.Page
    Protected WithEvents lblDate As System.Web.UI.WebControls.Label
    Protected WithEvents rdoDataHead As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents lblEmpCode As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents btnUpdate As System.Web.UI.WebControls.Button
    Protected WithEvents dgData As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtNewData As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblHeatNo As System.Web.UI.WebControls.Label
    Protected WithEvents lblBrkFrom As System.Web.UI.WebControls.Label
    Protected WithEvents lblMaintGrp As System.Web.UI.WebControls.Label
    Protected WithEvents lblMcnCode As System.Web.UI.WebControls.Label
    Protected WithEvents lblMemoNumber As System.Web.UI.WebControls.Label
    Protected WithEvents rblProdAffect As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblProdAff As System.Web.UI.WebControls.Label
    Protected WithEvents rdoMeltOrPourRems As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtBreakFromTime As System.Web.UI.WebControls.TextBox
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents lblOriginalData As System.Web.UI.WebControls.Label
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
            Session("Group") = "PCOPCO"
            Session("UserID") = "072442"
            Try
                If CStr(Session("Group")).Trim <> "PCOPCO" Or CStr(Session("UserID")).Trim = "" Then
                    Response.Redirect("InvalidSession.aspx")
                    Exit Sub
                End If
            Catch exp As Exception
                Response.Redirect("InvalidSession.aspx")
                Exit Sub
            End Try
            rdoMeltOrPourRems.Visible = False
            rblProdAffect.Visible = False
            btnUpdate.Enabled = False
            Try
                lblDate.Text = PCO.tables.lastphldt
                lblEmpCode.Text = Session("UserID")
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            lblHeatNo.Visible = True
            lblBrkFrom.Visible = True
            lblMaintGrp.Visible = True
            lblMcnCode.Visible = True
            lblMemoNumber.Visible = True
            lblProdAff.Text = ""
            Label1.Visible = True
            rblProdAffect.ClearSelection()
            rblProdAffect.Visible = True
        End If
    End Sub
    Private Sub rdoDataHead_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoDataHead.SelectedIndexChanged
        btnUpdate.Enabled = False
        dgData.Visible = False
        lblHeatNo.Text = ""
        lblBrkFrom.Text = ""
        lblMaintGrp.Text = ""
        lblMcnCode.Text = ""
        lblMemoNumber.Text = ""
        lblProdAff.Text = ""
        Label1.Visible = False
        rblProdAffect.Visible = False
        rblProdAffect.ClearSelection()
        If IsNothing(rdoDataHead.SelectedItem) = True Then
            Exit Sub
        End If
        rdoMeltOrPourRems.Visible = rdoDataHead.SelectedIndex = 0
        rblProdAffect.Visible = rdoDataHead.SelectedIndex = 1
        FillGrid()
    End Sub
    Private Sub FillGrid()
        dgData.SelectedIndex = -1
        dgData.DataSource = Nothing
        dgData.DataBind()
        Dim dt As DataTable = PCO.tables.PCOEdit(CDate(lblDate.Text), rdoDataHead.SelectedItem.Text.Trim)
        If rdoDataHead.SelectedItem.Text.StartsWith("Exce") Then
            Dim dv As New DataView()
            Try
                dv.Table = dt
                dv.RowFilter = "MeltRemarks <> '' or PouringRemarks <> ''"
                dgData.DataSource = dv 'ds.Tables("HeatExceptions").DefaultView
                dgData.DataBind()
                dgData.Visible = True
                lblMessage.Text = "Select Heat Number"
            Catch exp As Exception
                dgData.Visible = False
                lblMessage.Text = exp.Message
            Finally
                dt.Dispose()
                dv.Dispose()
                dt = Nothing
                dv = Nothing
            End Try
            rblProdAffect.Visible = False
            txtBreakFromTime.Visible = False
            txtBreakFromTime.Text = ""
        ElseIf rdoDataHead.SelectedItem.Text.StartsWith("Break") Then
            rblProdAffect.Visible = True
            txtBreakFromTime.Visible = True
            Try
                dgData.DataSource = dt
                dgData.DataBind()
                dgData.Visible = True
            Catch exp As Exception
                dgData.Visible = False
                lblMessage.Text = exp.Message
                lblProdAff.Text = ""
            Finally
                dt.Dispose()
                dt = Nothing
            End Try
        Else
            dgData.Visible = False
        End If
    End Sub
    Private Sub dgData_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgData.ItemCommand
        lblMessage.Text = ""
        If rdoDataHead.SelectedItem.Text.StartsWith("Exce") Then
            If IsNothing(rdoDataHead.SelectedItem) = True Then
                lblMessage.Text = "Select Melt or Pour Remarks"
                Exit Sub
            Else
                If rdoMeltOrPourRems.SelectedIndex = 0 Or rdoMeltOrPourRems.SelectedIndex = 1 Then
                Else
                    lblMessage.Text = "Select Melt or Pour Remarks"
                    Exit Sub
                End If
            End If
        End If
        If rdoDataHead.SelectedItem.Text.StartsWith("Exce") Then
            If IsNothing(rdoDataHead.SelectedItem) = True Then
                lblMessage.Text = "Select Melt or Pour Remarks"
            Else
                If rdoMeltOrPourRems.SelectedIndex = 0 Or rdoMeltOrPourRems.SelectedIndex = 1 Then

                Else
                    lblMessage.Text = "Select Melt or Pour Remarks"
                End If
            End If
        End If
        lblProdAff.Text = ""
        rblProdAffect.ClearSelection()
        Label1.Visible = True
        rblProdAffect.Visible = True
        If e.CommandName = "Select" Then
            If rdoDataHead.SelectedItem.Text.StartsWith("Exce") Then
                If rdoMeltOrPourRems.SelectedIndex = 0 Then
                    lblOriginalData.Text = e.Item.Cells(2).Text
                Else
                    lblOriginalData.Text = e.Item.Cells(3).Text
                End If
                lblHeatNo.Text = e.Item.Cells(1).Text
                lblBrkFrom.Text = ""
                lblMaintGrp.Text = ""
                lblMcnCode.Text = ""
                lblMemoNumber.Text = ""
                rblProdAffect.Visible = False
                txtBreakFromTime.Text = ""
                txtBreakFromTime.Visible = False
            ElseIf rdoDataHead.SelectedItem.Text.StartsWith("Break") Then
                lblOriginalData.Text = e.Item.Cells(4).Text
                lblHeatNo.Text = ""
                lblMemoNumber.Text = e.Item.Cells(1).Text
                lblBrkFrom.Text = e.Item.Cells(2).Text
                txtBreakFromTime.Text = e.Item.Cells(2).Text
                lblMaintGrp.Text = e.Item.Cells(3).Text
                lblMcnCode.Text = e.Item.Cells(5).Text
                lblProdAff.Text = e.Item.Cells(6).Text
                If e.Item.Cells(6).Text.StartsWith("Y") Then
                    rblProdAffect.SelectedIndex = 0
                Else
                    rblProdAffect.SelectedIndex = 1
                End If
                rblProdAffect.Visible = True
            End If
        End If
        btnUpdate.Enabled = True
    End Sub
    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If rdoDataHead.SelectedItem.Text.StartsWith("Exce") Then
            If lblHeatNo.Text = "" Then
                lblMessage.Text = "Heat Number not found"
                Exit Sub
            End If
        ElseIf rdoDataHead.SelectedItem.Text.StartsWith("Break") Then
            If lblMemoNumber.Text = "" Then
                lblMessage.Text = "Memo Number not found"
                Exit Sub
            End If
        Else
            lblMessage.Text = "Facility Not available"
            Exit Sub
        End If
        Dim blnSaved As Boolean
        Try
            blnSaved = New PCO.PCO().PCORemarksEdit(rdoDataHead.SelectedItem.Text, rblProdAffect.Visible, lblMaintGrp.Text, lblMemoNumber.Text, CDate(txtBreakFromTime.Text.Trim), lblOriginalData.Text, txtNewData.Text, lblEmpCode.Text, Val(lblHeatNo.Text), rdoMeltOrPourRems.SelectedIndex)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If blnSaved = False Then
            Exit Sub
        End If
        If blnSaved = False Then
            lblMessage.Text = "Update Failed. "
        Else
            lblMessage.Text = "Updated"
            FillGrid()
        End If
        blnSaved = Nothing
        txtBreakFromTime.Text = ""
        lblProdAff.Text = ""
        Label1.Visible = True
        rblProdAffect.ClearSelection()
        rblProdAffect.Visible = True
    End Sub
    Private Sub rdoMeltOrPourRems_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoMeltOrPourRems.SelectedIndexChanged
        btnUpdate.Enabled = False
        lblOriginalData.Text = ""
        lblMessage.Text = "Select Heat Number"
    End Sub
End Class
