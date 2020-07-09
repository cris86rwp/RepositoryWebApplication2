Public Class CharpyCastTest
    Inherits System.Web.UI.Page
    Protected WithEvents btnExit As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents txtMo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCu As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNi As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCr As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSi As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtS As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMn As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtP As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtC As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtV As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtP_S As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtUT_strength As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtElongation As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCharpy As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtYield_strength As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtReduction As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMode As System.Web.UI.WebControls.Label
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents radResult As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents cboLab_number As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents Rangevalidator8 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents lblLabNumber As System.Web.UI.WebControls.Label
    Protected WithEvents lblProdno As System.Web.UI.WebControls.Label
    Protected WithEvents lblCast_number As System.Web.UI.WebControls.Label
    Protected WithEvents lblSend_Date As System.Web.UI.WebControls.Label
    Protected WithEvents lblRecived_date As System.Web.UI.WebControls.Label
    Protected WithEvents lblGropu As System.Web.UI.WebControls.Label
    Protected WithEvents radTesttype As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtASTM As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtVert_macro As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLong_macro As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtAxleNumber As System.Web.UI.WebControls.TextBox



    Shared themeValue As String

    Public Sub New()

        AddHandler PreInit, New EventHandler(AddressOf Page_PreInit)
    End Sub


    Private Sub Page_PreInit(ByVal sender As Object, ByVal e As EventArgs)

        ' Page.Theme = themeValue
        Page.Theme = Session("Theme")
    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None
        'Put user code to initialize the page here
        'strMode = Request.QueryString("mode")
        'strMode = "add"
        'strMode = "delete"
        lblMode.Text = "edit"
        lblMessage.Text = ""
        If Not IsPostBack Then
            txtDate.Text = Date.Today
            getLab_numbers()
            Select Case lblMode.Text
                Case "edit"
                    cboLab_number.Visible = True
                    txtAxleNumber.Visible = False
            End Select
        End If 'End of IsPostBack
    End Sub

    Sub getLab_numbers()
        cboLab_number.Items.Clear()
        Dim dt As DataTable
        Try
            dt = metLab.tables.getLab_numbers(lblMode.Text)
            cboLab_number.DataSource = dt
            cboLab_number.DataTextField = dt.Columns(0).ColumnName
            cboLab_number.DataValueField = dt.Columns(1).ColumnName
            cboLab_number.DataBind()
            cboLab_number.Items.Add(New ListItem("Select"))
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
    End Sub

    Private Sub ForEditModeOnAxleNumberChange()
        lblMessage.Text = ""
        Dim billet_number As String
        billet_number = ""
        lblSend_Date.Text = ""
        lblRecived_date.Text = ""
        lblCast_number.Text = ""
        lblProdno.Text = ""
        lblGropu.Text = ""
        lblLabNumber.Text = cboLab_number.SelectedItem.Value
        If lblMode.Text.Equals("edit") Or lblMode.Text.Equals("delete") Then
            getValues()
        End If
        Dim ds As DataSet
        Try
            ds = metLab.tables.getAxleDetails(lblLabNumber.Text.Trim, txtAxleNumber.Text.Trim)
            If ds.Tables(0).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0)(0)) Then
                    lblSend_Date.Text = ds.Tables(0).Rows(0)(0)
                End If
                If Not IsDBNull(ds.Tables(0).Rows(0)(1)) Then
                    lblRecived_date.Text = ds.Tables(0).Rows(0)(1)
                End If
                If Not IsDBNull(ds.Tables(0).Rows(0)(2)) Then
                    lblCast_number.Text = ds.Tables(0).Rows(0)(2)
                End If
                If Not IsDBNull(ds.Tables(0).Rows(0)(3)) Then
                    lblProdno.Text = ds.Tables(0).Rows(0)(3)
                End If
                If Not IsDBNull(ds.Tables(0).Rows(0)(4)) Then
                    If CStr(ds.Tables(0).Rows(0)(4)).ToUpper = "P" Then
                        radResult.SelectedIndex = 0
                    ElseIf CStr(ds.Tables(0).Rows(0)(4)).ToUpper = "R" Then
                        radResult.SelectedIndex = 1
                    End If
                End If
            End If

            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0)(0)) Then
                    lblCast_number.Text = ds.Tables(1).Rows(0)(0)
                End If
                If Not IsDBNull(ds.Tables(1).Rows(0)(1)) Then
                    billet_number = ds.Tables(1).Rows(0)(1)
                End If
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub cboLab_number_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLab_number.SelectedIndexChanged
        Dim billet_number As String
        billet_number = ""
        lblSend_Date.Text = ""
        lblRecived_date.Text = ""
        lblCast_number.Text = ""
        lblProdno.Text = ""
        lblGropu.Text = ""
        If cboLab_number.SelectedItem.Text = "Select" Then
            lblMessage.Text = "Please select Axle Number ! "
            Exit Sub
        End If
        txtAxleNumber.Text = cboLab_number.SelectedItem.Text
        lblLabNumber.Text = cboLab_number.SelectedItem.Value
        If lblMode.Text.Equals("edit") Or lblMode.Text.Equals("delete") Then
            getValues()
        End If
        Dim dt As DataTable
        Try
            dt = metLab.tables.getLabNoDetails(lblLabNumber.Text.Trim)
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0)(0)) Then
                    lblSend_Date.Text = dt.Rows(0)(0)
                End If
                If Not IsDBNull(dt.Rows(0)(1)) Then
                    lblRecived_date.Text = dt.Rows(0)(1)
                End If
                If Not IsDBNull(dt.Rows(0)(2)) Then
                    lblCast_number.Text = dt.Rows(0)(2)
                End If
                If Not IsDBNull(dt.Rows(0)(3)) Then
                    lblProdno.Text = dt.Rows(0)(3)
                End If
            End If
            lblMessage.Text = ""
            If lblCast_number.Text <> "" Then
                dt = metLab.tables.getCastDetails(lblCast_number.Text.Trim)
                If dt.Rows.Count > 0 Then
                    lblMessage.Text = dt.Rows(0)(0)
                End If
                If lblMessage.Text <> "" Then
                    lblMessage.Text = "Details of Last test : " & lblMessage.Text
                End If
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
        End Try
        If IsNothing(lblLabNumber.Text.Trim) Then
            lblMessage.Text = "Chemical Analysis values not available "
        Else
            ShowAxleValues()
        End If
    End Sub
    Private Sub ShowAxleValues()
        Dim dt As DataTable
        Try
            dt = metLab.tables.ShowAxleValues(lblLabNumber.Text.Trim)
            If dt.Rows.Count > 0 Then
                txtC.Text = IIf(IsDBNull(dt.Rows(0)(1)), "0.0", dt.Rows(0)(1))
                txtP.Text = IIf(IsDBNull(dt.Rows(0)(2)), "0.0", dt.Rows(0)(2))
                txtMn.Text = IIf(IsDBNull(dt.Rows(0)(3)), "0.0", dt.Rows(0)(3))
                txtS.Text = IIf(IsDBNull(dt.Rows(0)(4)), "0.0", dt.Rows(0)(4))
                txtSi.Text = IIf(IsDBNull(dt.Rows(0)(5)), "0.0", dt.Rows(0)(5))
                txtCr.Text = IIf(IsDBNull(dt.Rows(0)(6)), "0.0", dt.Rows(0)(6))
                txtNi.Text = IIf(IsDBNull(dt.Rows(0)(7)), "0.0", dt.Rows(0)(7))
                txtCu.Text = IIf(IsDBNull(dt.Rows(0)(8)), "0.0", dt.Rows(0)(8))
                txtV.Text = IIf(IsDBNull(dt.Rows(0)(9)), "0.0", dt.Rows(0)(9))
                txtMo.Text = IIf(IsDBNull(dt.Rows(0)(10)), "0.0", dt.Rows(0)(10))
                txtP_S.Text = IIf(IsDBNull(dt.Rows(0)(11)), "0.0", dt.Rows(0)(11))
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
        End Try
    End Sub

    Private Sub getValues()
        Dim dt As DataTable
        Try
            clear()
            ShowAxleValues()
            dt = metLab.tables.getCasttestPhysical(lblLabNumber.Text.Trim)
            If dt.Rows.Count > 0 Then
                txtUT_strength.Text = dt.Rows(0)("ut_strength")
                txtYield_strength.Text = dt.Rows(0)("yield_strength")
                txtElongation.Text = dt.Rows(0)("elongation")
                txtReduction.Text = dt.Rows(0)("reduction")
                txtCharpy.Text = dt.Rows(0)("charpy")
                txtASTM.Text = dt.Rows(0)("astm")
                txtVert_macro.Text = dt.Rows(0)("macro_vert")
                txtLong_macro.Text = dt.Rows(0)("macro_long")
                If Not IsDBNull(dt.Rows(0)("remarks")) Then
                    txtRemarks.Text = dt.Rows(0)("remarks")
                End If
                txtDate.Text = dt.Rows(0)("test_date")
            End If
        Catch expGen As Exception
            lblMessage.Text = expGen.Message
        End Try
    End Sub

    Private Sub updateValues()
        Dim Done As Boolean
        Try
            Done = New metLab.AxleCastTest().UpdateValues(lblLabNumber.Text.Trim, CDate(txtDate.Text), Val(txtCharpy.Text))
            If Done Then
                lblMessage.Text = "Record UpDated"
            Else
                lblMessage.Text = "Record Not UpDated !"
            End If
        Catch Genexp As Exception
            lblMessage.Text = Genexp.Message
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If lblMode.Text.Equals("edit") Then
            updateValues()
            clear()
            lblSend_Date.Text = ""
            lblRecived_date.Text = ""
            lblCast_number.Text = ""
            lblProdno.Text = ""
            lblGropu.Text = ""
            lblLabNumber.Text = ""
            getLab_numbers()
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        clear()
    End Sub

    Private Sub clear()
        txtDate.Text = Date.Today
        txtASTM.Text = ""
        txtC.Text = ""
        txtCharpy.Text = ""
        txtCr.Text = ""
        txtCu.Text = ""
        txtElongation.Text = ""
        txtLong_macro.Text = ""
        txtMn.Text = ""
        txtMo.Text = ""
        txtNi.Text = ""
        txtP.Text = ""
        txtP_S.Text = ""
        txtReduction.Text = ""
        txtRemarks.Text = ""
        txtUT_strength.Text = ""
        txtS.Text = ""
        txtSi.Text = ""
        txtUT_strength.Text = ""
        txtV.Text = ""
        txtVert_macro.Text = ""
        txtYield_strength.Text = ""
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Server.Transfer("/mss/selectModule.aspx")
    End Sub

    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim d As Date
        Try
            d = CDate(txtDate.Text)
            If d.Compare(d, Date.Today) > 0 Then
                lblMessage.Text = "Date Should Not Be More Than Today"
                Exit Sub
            End If
        Catch exp As Exception
            lblMessage.Text = "Enter Proper Date"
            Exit Sub
        End Try
    End Sub

    Private Sub txtP_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtP.TextChanged
        sumP_S()
    End Sub

    Private Sub sumP_S()
        Try
            Dim p, s, p_s As Double
            If Not txtS.Text = "" Then
                s = txtS.Text
            End If
            If Not txtP.Text = "" Then
                p = txtP.Text
            End If
            p_s = p + s
            txtP_S.Text = p_s
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtS_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtS.TextChanged
        sumP_S()
    End Sub

    Private Sub InitializeComponent()

    End Sub

    Private Sub txtAxleNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAxleNumber.TextChanged
        Dim i As Integer = 0
        For i = 0 To Me.cboLab_number.Items.Count() - 1
            If Trim(cboLab_number.Items(i).Text.ToUpper) = Trim(txtAxleNumber.Text.ToUpper) Then
                cboLab_number.SelectedIndex = i
                ForEditModeOnAxleNumberChange()
                Exit Sub
            End If
        Next i
        lblMessage.Text = "Invalid axle number"
        txtAxleNumber.Text = ""
    End Sub
End Class

