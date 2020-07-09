Public Class NewMouldIntroductionEdit
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblShift As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents lblOperator As System.Web.UI.WebControls.Label
    Protected WithEvents rblType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtCope_drag_number As System.Web.UI.WebControls.TextBox
    Protected WithEvents PanelEngraved_number As System.Web.UI.WebControls.Panel
    Protected WithEvents txtEngraved_number As System.Web.UI.WebControls.TextBox
    Protected WithEvents panelEngraved_box As System.Web.UI.WebControls.Panel
    Protected WithEvents ddlProductCode As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblDrawing_number As System.Web.UI.WebControls.Label
    Protected WithEvents ddlSupplier As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtBlank_number As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtIntial_height As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtStandard_height As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPermiability As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtAsh_content As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboMouldStatus As System.Web.UI.WebControls.DropDownList
    Protected WithEvents rblMouldSize As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtRelease_date As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPONumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents rblPL As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents pnlDrag As System.Web.UI.WebControls.Panel
    Protected WithEvents rblSupplier As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblPresentIng As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
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
            txtDate.Text = Now.Date
            txtRelease_date.Text = Now.Date
            'Session("UserID") = "074405"
            lblOperator.Text = Session("UserID")
            Try
                If rblType.SelectedItem.Value = "C" Then
                    PanelEngraved_number.Visible = False
                    panelEngraved_box.Visible = False
                    rblPresentIng.Visible = False
                    pnlDrag.Visible = False
                    Label1.Visible = False
                Else
                    Label1.Visible = True
                    rblPresentIng.Visible = True
                    pnlDrag.Visible = True
                    PanelEngraved_number.Visible = True
                    panelEngraved_box.Visible = True
                End If
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
    Private Sub setobj()
        If Not IsNothing(Session("NewMld")) Then Session.Remove("Mld")
        Session.Remove("NewMld")
        Dim oMld As New MouldMaster.Moulds(txtCope_drag_number.Text.Trim, CDate(txtDate.Text), "NewMouldEdit")
        Session("NewMld") = oMld
        CType(Session("NewMld"), MouldMaster.Moulds).NewMouldIntroductionEdit = True
        getProduct_codes()
        getSupplier_codes()
        oMld = Nothing
    End Sub
    Private Sub getSupplier_codes()
        Dim dt As New DataTable()
        Try
            dt = MouldMaster.tables.getSupplier_codes
            ddlSupplier.DataSource = dt
            ddlSupplier.DataTextField = "Supplier_name"
            ddlSupplier.DataValueField = "supplier_code"
            ddlSupplier.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
            dt = Nothing
        End Try
    End Sub
    Private Sub getProduct_codes()
        Dim dt As New DataTable()
        Try
            dt = MouldMaster.tables.ProductCodesInMouldMasterTable(False)
            ddlProductCode.DataSource = dt
            ddlProductCode.DataTextField = "description"
            ddlProductCode.DataValueField = "product_code"
            ddlProductCode.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
            dt = Nothing
        End Try
    End Sub
    Private Sub clearform()
        txtPONumber.Text = ""
        txtAsh_content.Text = ""
        txtBlank_number.Text = ""
        rblType.SelectedIndex = 0
        ddlProductCode.SelectedIndex = 0
        txtEngraved_number.Text = ""
        txtIntial_height.Text = ""
        txtPermiability.Text = ""
        txtRemarks.Text = ""
        txtCope_drag_number.Text = ""
        lblDrawing_number.Text = ""
    End Sub
    Private Sub txtCope_drag_number_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCope_drag_number.TextChanged
        lblMessage.Text = ""
        Try
            setobj()
            If CType(Session("NewMld"), MouldMaster.Moulds).AllowMouldIntroductionEdit Then
                rblType.ClearSelection()
                Dim i As Integer
                For i = 0 To rblType.Items.Count - 1
                    If rblType.Items(i).Value = Trim(CType(Session("NewMld"), MouldMaster.Moulds).MouldType) Then
                        rblType.Items(i).Selected = True
                        If rblType.SelectedItem.Value = "C" Then
                            PanelEngraved_number.Visible = False
                            panelEngraved_box.Visible = False
                            rblPresentIng.Visible = False
                            Label1.Visible = False
                            pnlDrag.Visible = False
                        Else
                            Label1.Visible = True
                            rblPresentIng.Visible = True
                            PanelEngraved_number.Visible = True
                            panelEngraved_box.Visible = True
                            pnlDrag.Visible = True
                        End If
                        Exit For
                    End If
                Next
                txtDate.Text = CDate(Trim(CType(Session("NewMld"), MouldMaster.Moulds).MouldDate))
                CType(Session("NewMld"), MouldMaster.Moulds).MouldDate = CDate(txtDate.Text)
                rblShift.ClearSelection()
                i = 0
                For i = 0 To rblShift.Items.Count - 1
                    If rblShift.Items(i).Text = Trim(CType(Session("NewMld"), MouldMaster.Moulds).Shift) Then
                        rblShift.Items(i).Selected = True
                        Exit For
                    End If
                Next
                lblDrawing_number.Text = Trim(CType(Session("NewMld"), MouldMaster.Moulds).wap_drawing_number)
                ddlProductCode.ClearSelection()
                i = 0
                For i = 0 To ddlProductCode.Items.Count - 1
                    If Trim(ddlProductCode.Items(i).Value) = Trim(CType(Session("NewMld"), MouldMaster.Moulds).ProductCode) Then
                        ddlProductCode.Items(i).Selected = True
                        Exit For
                    End If
                Next
                txtEngraved_number.Text = Trim(CType(Session("NewMld"), MouldMaster.Moulds).engraved_number)
                i = 0
                For i = 0 To rblPresentIng.Items.Count - 1
                    If Trim(rblPresentIng.Items(i).Text) = Trim(CType(Session("NewMld"), MouldMaster.Moulds).ingate_number) Then
                        rblPresentIng.Items(i).Selected = True
                        Exit For
                    End If
                Next
                i = 0
                For i = 0 To rblSupplier.Items.Count - 1
                    If Trim(rblSupplier.Items(i).Text) = Trim(CType(Session("NewMld"), MouldMaster.Moulds).IngSupplier) Then
                        rblSupplier.Items(i).Selected = True
                        Exit For
                    End If
                Next
                txtRelease_date.Text = CDate(Trim(CType(Session("NewMld"), MouldMaster.Moulds).released_date))
                txtIntial_height.Text = Val(CType(Session("NewMld"), MouldMaster.Moulds).Mould_intial_height)
                txtPermiability.Text = Val(CType(Session("NewMld"), MouldMaster.Moulds).Permiability)
                txtAsh_content.Text = Val(CType(Session("NewMld"), MouldMaster.Moulds).Ash_content)
                cboMouldStatus.ClearSelection()
                i = 0
                For i = 0 To cboMouldStatus.Items.Count - 1
                    If Trim(cboMouldStatus.Items(i).Value) = Trim(CType(Session("NewMld"), MouldMaster.Moulds).MouldStatus) Then
                        cboMouldStatus.Items(i).Selected = True
                        Exit For
                    End If
                Next
                ddlSupplier.ClearSelection()
                i = 0
                For i = 0 To ddlSupplier.Items.Count - 1
                    If ddlSupplier.Items(i).Text = Trim(CType(Session("NewMld"), MouldMaster.Moulds).SupplierCode) Then
                        ddlSupplier.Items(i).Selected = True
                        Exit For
                    End If
                Next
                txtBlank_number.Text = Trim(CType(Session("NewMld"), MouldMaster.Moulds).BlankNumber)
                txtStandard_height.Text = Val(CType(Session("NewMld"), MouldMaster.Moulds).Standard_height)
                txtRemarks.Text = Trim(CType(Session("NewMld"), MouldMaster.Moulds).Remarks)
                rblMouldSize.ClearSelection()
                i = 0
                For i = 0 To rblMouldSize.Items.Count - 1
                    If rblMouldSize.Items(i).Text = Val(CType(Session("NewMld"), MouldMaster.Moulds).mould_size) Then
                        rblMouldSize.Items(i).Selected = True
                        Exit For
                    End If
                Next
                txtPONumber.Text = Trim(CType(Session("NewMld"), MouldMaster.Moulds).PONumber)
                i = Nothing
            Else
                lblMessage.Text = " New Mould Number '" & txtCope_drag_number.Text.Trim & "' is InValid !"
            End If
            FillGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        If txtPONumber.Text.Trim.Length = 0 Then
            lblMessage.Text = "In Valid PO Number !"
            Exit Sub
        End If
        If Val(txtIntial_height.Text) = 0 Then
            lblMessage.Text = "In Valid Initial Height !"
            Exit Sub
        End If
        Try
            CType(Session("NewMld"), MouldMaster.Moulds).AllowMouldIntroduction = True
            CType(Session("NewMld"), MouldMaster.Moulds).Operator1 = lblOperator.Text
            CType(Session("NewMld"), MouldMaster.Moulds).MouldType = rblType.SelectedItem.Value
            CType(Session("NewMld"), MouldMaster.Moulds).Shift = rblShift.SelectedItem.Value
            CType(Session("NewMld"), MouldMaster.Moulds).wap_drawing_number = lblDrawing_number.Text
            CType(Session("NewMld"), MouldMaster.Moulds).ProductCode = ddlProductCode.SelectedItem.Value
            If rblType.SelectedItem.Value = "C" Then
                CType(Session("NewMld"), MouldMaster.Moulds).engraved_number = ""
                CType(Session("NewMld"), MouldMaster.Moulds).ingate_number = ""
                CType(Session("NewMld"), MouldMaster.Moulds).IngSupplier = ""
            Else
                CType(Session("NewMld"), MouldMaster.Moulds).engraved_number = txtEngraved_number.Text.Trim
                CType(Session("NewMld"), MouldMaster.Moulds).ingate_number = rblPresentIng.SelectedItem.Text.Trim
                CType(Session("NewMld"), MouldMaster.Moulds).IngSupplier = rblSupplier.SelectedItem.Text.Trim
            End If
            CType(Session("NewMld"), MouldMaster.Moulds).released_date = CDate(txtRelease_date.Text)
            CType(Session("NewMld"), MouldMaster.Moulds).Mould_intial_height = IIf((txtIntial_height.Text.Trim.Length = 0), 0.0, Val(txtIntial_height.Text))
            CType(Session("NewMld"), MouldMaster.Moulds).Permiability = IIf((txtPermiability.Text.Trim.Length = 0), 0.0, Val(txtPermiability.Text))
            CType(Session("NewMld"), MouldMaster.Moulds).Ash_content = IIf((txtAsh_content.Text.Trim.Length = 0), 0.0, Val(txtAsh_content.Text))
            CType(Session("NewMld"), MouldMaster.Moulds).MouldStatus = cboMouldStatus.SelectedItem.Value
            CType(Session("NewMld"), MouldMaster.Moulds).Standard_height = IIf((txtStandard_height.Text.Trim.Length = 0), 0.0, Val(txtStandard_height.Text))
            CType(Session("NewMld"), MouldMaster.Moulds).Operator1 = lblOperator.Text.Trim & ""
            CType(Session("NewMld"), MouldMaster.Moulds).Remarks = txtRemarks.Text.Trim & ""
            CType(Session("NewMld"), MouldMaster.Moulds).mould_size = rblMouldSize.SelectedItem.Text
            'If Not MouldMaster.tables.CheckPO(txtPONumber.Text.Trim, ddlSupplier.SelectedItem.Value, rblPL.SelectedItem.Text.Trim) Then
            '    txtPONumber.Text = ""
            '    Throw New Exception("PO Number : '" & txtPONumber.Text.Trim & "'  InValid !")
            '    Exit Try
            'Else
            CType(Session("NewMld"), MouldMaster.Moulds).PONumber = txtPONumber.Text
            'End If
            CType(Session("NewMld"), MouldMaster.Moulds).SupplierCode = ddlSupplier.SelectedItem.Text
            CType(Session("NewMld"), MouldMaster.Moulds).BlankNumber = txtBlank_number.Text.Trim
            CType(Session("NewMld"), MouldMaster.Moulds).NewMouldValues("edit")
            CType(Session("NewMld"), MouldMaster.Moulds).MouldDate = CDate(txtDate.Text)
            FillGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            clearform()
            lblMessage.Text &= CType(Session("NewMld"), MouldMaster.Moulds).Message
        End Try
    End Sub
    'Private Sub txtPONumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPONumber.TextChanged
    '    lblMessage.Text = ""
    '    Try
    '        If Len(txtPONumber.Text.Trim) > 0 Then
    '            If rblMouldSize.SelectedItem.Text.Trim = "52.5" Then
    '                If rblPL.SelectedItem.Text.Trim <> "76971510" Then
    '                    lblMessage.Text = "PL Number : '" & rblPL.SelectedItem.Text.Trim & "'  mis-match with Mould Size !"
    '                    txtPONumber.Text = ""
    '                End If
    '            ElseIf rblMouldSize.SelectedItem.Text = "48.5" Then
    '                If rblPL.SelectedItem.Text.Trim <> "81980802" Then
    '                    lblMessage.Text = "PL Number : '" & rblPL.SelectedItem.Text.Trim & "'  mis-match with Mould Size !"
    '                    txtPONumber.Text = ""
    '                End If
    '            ElseIf rblMouldSize.SelectedItem.Text = "43.5" Then
    '                If rblPL.SelectedItem.Text.Trim <> "81980851" Then
    '                    lblMessage.Text = "PL Number : '" & rblPL.SelectedItem.Text.Trim & "'  mis-match with Mould Size !"
    '                    txtPONumber.Text = ""
    '                End If
    '            ElseIf Not MouldMaster.tables.CheckPO(txtPONumber.Text.Trim, ddlSupplier.SelectedItem.Value, rblPL.SelectedItem.Value) Then
    '                lblMessage.Text = "PO Number : '" & txtPONumber.Text.Trim & "'  InValid !"
    '                txtPONumber.Text = ""
    '            End If
    '        End If
    '    Catch exp As Exception
    '        lblMessage.Text = exp.Message
    '        txtPONumber.Text = ""
    '    End Try
    'End Sub
    Private Sub FillGrid()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            DataGrid1.DataSource = CType(Session("NewMld"), MouldMaster.Moulds).SavedData
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
    End Sub
    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        lblMessage.Text = ""
        Try
            If Not IsNothing(Session("NewMld")) Then
                CType(Session("NewMld"), MouldMaster.Moulds).MouldDate = txtDate.Text
                FillGrid()
            End If
        Catch exp As Exception
            txtDate.Text = ""
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub ddlProductCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlProductCode.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            lblDrawing_number.Text = CType(Session("NewMld"), MouldMaster.tables).GetDrawingNumber(ddlProductCode.SelectedItem.Value)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub DataGrid1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.ItemCommand
        lblMessage.Text = ""
        Try
            Select Case e.CommandName
                Case "Delete"
                    Try
                        If Not IsNothing(Session("NewMld")) Then Session.Remove("Mld")
                        Session.Remove("NewMld")
                        Dim oMld As New MouldMaster.Moulds(e.Item.Cells(1).Text.Trim, True)
                        Session("NewMld") = oMld
                        CType(Session("NewMld"), MouldMaster.Moulds).NewMouldIntroductionDelete = True
                        CType(Session("NewMld"), MouldMaster.Moulds).NewMouldValues("delete")
                        FillGrid()
                    Catch exp As Exception
                        lblMessage.Text = exp.Message
                    Finally
                        clearform()
                        lblMessage.Text &= CType(Session("NewMld"), MouldMaster.Moulds).Message
                    End Try
            End Select
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
End Class
