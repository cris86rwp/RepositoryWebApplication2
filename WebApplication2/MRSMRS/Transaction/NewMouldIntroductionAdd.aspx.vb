Public Class NewMouldIntroductionAdd
    Inherits System.Web.UI.Page
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblShift As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents lblOperator As System.Web.UI.WebControls.Label
    Protected WithEvents rblType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtEngraved_number As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCope_drag_number As System.Web.UI.WebControls.TextBox
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
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents pnlIng As System.Web.UI.WebControls.Panel
    Protected WithEvents rblSupplier As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblPL As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblPresentIng As System.Web.UI.WebControls.RadioButtonList
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
        rblPL.Visible = False
        lblOperator.Visible = False
        If Page.IsPostBack = False Then
            txtDate.Text = Now.Date
            txtRelease_date.Text = Now.Date
            'Session("UserID") = "078916"
            lblOperator.Text = Session("UserID")
            Try
                getDateShift()
                setobj()
                If rblType.SelectedItem.Value = "C" Then
                    pnlIng.Visible = False
                Else
                    pnlIng.Visible = True
                End If
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
    Private Sub getDateShift()
        If Now.Hour = 0 OrElse Now.Hour = 1 OrElse Now.Hour = 2 OrElse Now.Hour = 3 OrElse Now.Hour = 4 OrElse Now.Hour = 5 Then
            txtDate.Text = Now.Date.AddDays(-1)
        Else
            txtDate.Text = Now.Date
        End If
        Dim dt As Date
        Dim Shift As String
        dt = Now
        Select Case dt.Hour
            Case 6 To 13
                Shift = "A"
            Case 14 To 21
                Shift = "B"
            Case Else
                Shift = "C"
        End Select
        Dim i As Integer = 0
        rblShift.ClearSelection()
        For i = 0 To rblShift.Items.Count - 1
            If rblShift.Items(i).Text = Shift Then
                rblShift.Items(i).Selected = True
                Exit For
            End If
        Next
        dt = Nothing
        Shift = Nothing
        i = Nothing
    End Sub
    Private Sub setobj()
        If Not IsNothing(Session("NewMld")) Then Session.Remove("Mld")
        Session.Remove("NewMld")
        Dim oMld As New MouldMaster.Moulds()
        Session("NewMld") = oMld
        CType(Session("NewMld"), MouldMaster.Moulds).NewMouldIntroduction = True
        CType(Session("NewMld"), MouldMaster.Moulds).MouldDate = txtDate.Text
        getProduct_codes()
        getSupplier_codes()
        FillGrid()
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
    End Sub
    Private Sub FillGrid()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            DataGrid1.DataSource = CType(Session("NewMld"), MouldMaster.Moulds).SavedData
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        lblMessage.Text = ""
        Try
            CType(Session("NewMld"), MouldMaster.Moulds).MouldDate = txtDate.Text
            FillGrid()
        Catch exp As Exception
            txtDate.Text = ""
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub rblType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblType.SelectedIndexChanged
        If rblType.SelectedItem.Value = "C" Then
            pnlIng.Visible = False
        Else
            pnlIng.Visible = True
        End If
    End Sub

    Private Sub txtCope_drag_number_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCope_drag_number.TextChanged
        lblMessage.Text = ""
        Try
            If Val(txtCope_drag_number.Text.Trim) > 0 Then
                CType(Session("NewMld"), MouldMaster.Moulds).MouldNumber = txtCope_drag_number.Text.Trim
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
            txtCope_drag_number.Text = ""
        End Try
    End Sub

    Private Sub ddlProductCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlProductCode.SelectedIndexChanged
        lblMessage.Text = ""
        lblDrawing_number.Text = ""
        Try
            If Val(ddlProductCode.SelectedItem.Value.Trim) > 0 Then
                lblDrawing_number.Text = MouldMaster.tables.fillDrawing_number(ddlProductCode.SelectedItem.Value)
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
            lblDrawing_number.Text = ""
        End Try
    End Sub

    Private Sub txtPONumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPONumber.TextChanged
        lblMessage.Text = ""
        Try
            'If Len(txtPONumber.Text.Trim) > 0 Then
            '    If rblMouldSize.SelectedItem.Text.Trim = "52.5" Then
            '        If rblPL.SelectedItem.Text.Trim <> "76971510" Then
            '            lblMessage.Text = "PL Number : '" & rblPL.SelectedItem.Text.Trim & "'  mis-match with Mould Size !"
            '            txtPONumber.Text = ""
            '        End If
            '    ElseIf rblMouldSize.SelectedItem.Text = "48.5" Then
            '        If rblPL.SelectedItem.Text.Trim <> "81980802" Then
            '            lblMessage.Text = "PL Number : '" & rblPL.SelectedItem.Text.Trim & "'  mis-match with Mould Size !"
            '            txtPONumber.Text = ""
            '        End If
            '    ElseIf rblMouldSize.SelectedItem.Text = "42.5" Then
            '        If rblPL.SelectedItem.Text.Trim <> "81980851" Then
            '            lblMessage.Text = "PL Number : '" & rblPL.SelectedItem.Text.Trim & "'  mis-match with Mould Size !"
            '            txtPONumber.Text = ""
            '        End If
            '    ElseIf Not MouldMaster.tables.CheckPO(txtPONumber.Text.Trim, ddlSupplier.SelectedItem.Value, rblPL.SelectedItem.Value) Then
            '        lblMessage.Text = "PO Number : '" & txtPONumber.Text.Trim & "'  InValid !"
            '        txtPONumber.Text = ""
            '    End If
            'End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
            txtPONumber.Text = ""
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        If Val(txtPermiability.Text) > 1 Then
            lblMessage.Text = "In Valid Permiability !"
            Exit Sub
        End If
        If Val(txtAsh_content.Text) > 1 Then
            lblMessage.Text = "In Valid Ash Content !"
            Exit Sub
        End If
        If txtPONumber.Text.Trim.Length = 0 Then
            lblMessage.Text = "In Valid PO Number !"
            Exit Sub
        End If
        If txtCope_drag_number.Text.Trim.Length = 0 Then
            lblMessage.Text = "In Valid Mould Number !"
            Exit Sub
        End If
        Try
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
                CType(Session("NewMld"), MouldMaster.Moulds).IngSupplier = rblSupplier.SelectedItem.Text
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
            '    CType(Session("NewMld"), MouldMaster.Moulds).PONumber = txtPONumber.Text
            'End If
            CType(Session("NewMld"), MouldMaster.Moulds).PONumber = txtPONumber.Text
            CType(Session("NewMld"), MouldMaster.Moulds).SupplierCode = ddlSupplier.SelectedItem.Text
            CType(Session("NewMld"), MouldMaster.Moulds).BlankNumber = txtBlank_number.Text.Trim

            CType(Session("NewMld"), MouldMaster.Moulds).NewMouldValues("add")
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            clearform()
            lblMessage.Text &= CType(Session("NewMld"), MouldMaster.Moulds).Message
            setobj()
        End Try
    End Sub
End Class
