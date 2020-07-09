Public Class Pouring
    Inherits System.Web.UI.Page
    Protected WithEvents txtHeat_number As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblWoval As System.Web.UI.WebControls.Label
    Protected WithEvents lblWODesc As System.Web.UI.WebControls.Label
    Protected WithEvents lblWoval1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblWODesc1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblHtNo As System.Web.UI.WebControls.Label
    Protected WithEvents lblSlNo As System.Web.UI.WebControls.Label
    Protected WithEvents txtPourOrder As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPourTime As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCopeNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCopeUsed As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDragNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEngrNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents rdoByPass As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtDragUsed As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtIngateUsed As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSplitTime As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboFastContinuous As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DDLPourStatus_code As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtRejCode As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtldlInsl_metal As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtShift_supervisor As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtOperator_mould As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtControledRate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFastRate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTITDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTube_intime As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTOTDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTube_outtime As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblGroup As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents rblWO As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtPourDate As System.Web.UI.WebControls.TextBox
    'Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCHOtemp As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtbakectemp As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtsprayctemp As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDHOtemp As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtspraydtemp As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlcho As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddldho As System.Web.UI.WebControls.DropDownList
    Protected WithEvents pnlPour As System.Web.UI.WebControls.Panel
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents btnClear As System.Web.UI.WebControls.Button
    Protected WithEvents btnExit As System.Web.UI.WebControls.Button
    Protected WithEvents lblNotInMR As System.Web.UI.WebControls.Label
    Protected WithEvents lblUser As System.Web.UI.WebControls.Label
    Protected WithEvents grdPouring As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtCastDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPourHH As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPourMM As System.Web.UI.WebControls.TextBox
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList

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
        lblSlNo.Visible = True

        If Page.IsPostBack = False Then
            'Session("UserID") = "111111"
            'Session("Group") = "MLDING"
            Try
                SetScreen()
                Dim PreNPost As New RWF.PreNPostPouring()
                Try
                    txtHeat_number.Text = RWF.tables.GetLatestPrePourHeat
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                End Try

                Session("PreNPost") = PreNPost
                PreNPost = Nothing
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub SetScreen()
        lblNotInMR.Text = ""
        pnlPour.Visible = True

        grdPouring.DataSource = Nothing
        grdPouring.DataBind()
        Try
            If Val(txtHeat_number.Text) > 0 Then
                txtHeat_number.Text = Val(txtHeat_number.Text)
                GetPourHeatDetails()
            Else
                setPour()
            End If
            SetFocus(txtHeat_number)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub GetPourHeatDetails()
        If txtHeat_number.Text = "" Then
            lblMessage.Text = "In Vaild Heat Number !"
            txtHeat_number.Text = ""
            SetFocus(txtHeat_number)
            Exit Sub
        End If
        Try
            GetData()
            PopulatePourData()
            SetFocus(txtCopeNo)
        Catch exp As Exception
            SetFocus(txtHeat_number)
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub setPour()
        btnSave.AccessKey = "S"
        Try
            txtHeat_number.Text = RWF.tables.GetLatestHeat
            GetData()
            txtPourDate.Text = RWF.tables.GetWorkingDate(Session("Group"))
            txtPourDate.Text = Now.Date
            txtCastDate.Text = Now.Date
            txtPourOrder.Text = GetCumulativeCnt()
            txtPourTime.Text = Right(("0" + Now.Hour.ToString), 2) + ":" + Right(("0" + Now.Minute.ToString), 2)
            txtSplitTime.Text = "09:30"
            btnEnable(True, True, True)
            btnSave.Text = "Save"
            txtPourTime.Text = Hour(Now) & ":" & Minute(Now)
            txtCopeUsed.ReadOnly = True
            txtDragUsed.ReadOnly = True
            txtIngateUsed.ReadOnly = True
            cboFastContinuous.Items(0).Selected = True

            txtTITDate.Text = Now.Date
            txtTube_intime.Text = Right(("0" + Now.Hour.ToString), 2) + ":" + Right(("0" + Now.Minute.ToString), 2)
            txtTOTDate.Text = Now.Date
            txtTube_outtime.Text = Right(("0" + Now.Hour.ToString), 2) + ":" + Right(("0" + Now.Minute.ToString), 2)

        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub Clear()
        txtOperator_mould.Text = ""
        txtShift_supervisor.Text = ""
        ddldho.SelectedIndex = 0
        txtTube_intime.Text = ""
        txtTube_outtime.Text = ""
        txtldlInsl_metal.Text = ""
        txtTITDate.Text = ""
        txtTOTDate.Text = ""
    End Sub

    Private Sub GetHeatDetails()
        Clear()
        Dim dt As New DataTable()

        dt = RWF.tables.GetPrePourHeatDetails(txtHeat_number.Text)
        If dt.Rows.Count > 0 Then
            CType(Session("PreNPost"), RWF.PreNPostPouring).Operator1 = IIf(IsDBNull(dt.Rows(0)("operator_mould")), "", Trim(dt.Rows(0)("operator_mould")))
            txtOperator_mould.Text = CType(Session("PreNPost"), RWF.PreNPostPouring).Operator1
            CType(Session("PreNPost"), RWF.PreNPostPouring).SIC = IIf(IsDBNull(dt.Rows(0)("shift_supervisor")), "", Trim(dt.Rows(0)("shift_supervisor")))
            txtShift_supervisor.Text = CType(Session("PreNPost"), RWF.PreNPostPouring).SIC
            CType(Session("PreNPost"), RWF.PreNPostPouring).ShiftGroup = IIf(IsDBNull(dt.Rows(0)("ShiftGroup")), "", Trim(dt.Rows(0)("ShiftGroup")))
            Dim i As Int16 = 0
            rblGroup.ClearSelection()
            If CType(Session("PreNPost"), RWF.PreNPostPouring).ShiftGroup <> "" Then
                For i = 0 To rblGroup.Items.Count - 1
                    If rblGroup.Items(i).Text = CType(Session("PreNPost"), RWF.PreNPostPouring).ShiftGroup Then
                        rblGroup.Items(i).Selected = True
                    End If
                Next
            End If
        End If

    End Sub
    Private Sub PopulatePourData()
        Clear()
        Dim dt As New DataTable()

        dt = RWF.tables.GetPourSessionDetails(CInt(txtHeat_number.Text))
        If dt.Rows.Count > 0 Then

            If IsDBNull(dt.Rows(0)("OPERATOR")) = False Then
                txtOperator_mould.Text = dt.Rows(0)("OPERATOR")
            Else
                txtOperator_mould.Text = ""
            End If
            If IsDBNull(dt.Rows(0)("SHIFTID")) = False Then
                rblGroup.SelectedItem.Value = dt.Rows(0)("SHIFTID")
            Else
                rblGroup.SelectedItem.Value = ""
            End If
            If IsDBNull(dt.Rows(0)("LIM")) = False Then
                txtldlInsl_metal.Text = dt.Rows(0)("LIM")
            Else
                txtldlInsl_metal.Text = ""
            End If
            If IsDBNull(dt.Rows(0)("SIC")) = False Then
                txtShift_supervisor.Text = dt.Rows(0)("SIC")
            Else
                txtShift_supervisor.Text = ""
            End If
            If IsDBNull(dt.Rows(0)("TBINT")) = False Then
                txtTITDate.Text = dt.Rows(0)("TBINT").Date
                txtTube_intime.Text = Right(("0" + dt.Rows(0)("TBINT").Hour.ToString), 2) + ":" + Right(("0" + dt.Rows(0)("TBINT").Minute.ToString), 2)
            Else
                txtTITDate.Text = Now.Date
                txtTube_intime.Text = Right(("0" + Now.Hour.ToString), 2) + ":" + Right(("0" + Now.Minute.ToString), 2)
            End If
            If IsDBNull(dt.Rows(0)("TBOUTT")) = False Then
                txtTOTDate.Text = dt.Rows(0)("TBOUTT").Date
                txtTube_outtime.Text = Right(("0" + dt.Rows(0)("TBOUTT").Hour.ToString), 2) + ":" + Right(("0" + dt.Rows(0)("TBOUTT").Minute.ToString), 2)
            Else
                txtTOTDate.Text = Now.Date
                txtTube_outtime.Text = Right(("0" + Now.Hour.ToString), 2) + ":" + Right(("0" + Now.Minute.ToString), 2)
            End If
        Else
            lblMessage.Text = "No data exists for this Heat " & txtHeat_number.Text

        End If
        dt = Nothing
    End Sub

    Private Sub ClearForm()
        rdoByPass.SelectedIndex = 0
        lblSlNo.Text = 0
        txtCopeNo.Text = ""
        txtCopeUsed.Text = ""
        txtDragNo.Text = ""
        txtEngrNo.Text = ""
        txtDragUsed.Text = ""
        txtIngateUsed.Text = ""
        ' remarked on 14/8/2008 to retain previous status of pouring
        'cboFastContinuous.SelectedIndex = 0
        txtRejCode.Text = ""
        txtRemarks.Text = ""
        btnSave.Text = "Save"
        txtPourOrder.Text = GetCumulativeCnt()
        ViewState("CopeNo") = ""
        ViewState("DragNo") = ""
    End Sub

    Private Function GetCumulativeCnt() As Integer
        Try
            GetCumulativeCnt = RWF.tables.GetCumulativeCnt(CInt(txtHeat_number.Text))
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Function

    Private Function GetWOProdId(ByVal strwo As String) As String
        Try
            GetWOProdId = RWF.tables.GetWOProdId(strwo)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Function

    Private Function GetWoDesc(ByVal strwo As String) As String
        Try
            GetWoDesc = RWF.tables.GetWoDesc(strwo)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Function

    Private Sub GetWoNo()
        rblWO.Items.Clear()
        Try
            rblWO.DataSource = RWF.tables.getWO(Val(txtHeat_number.Text))
            rblWO.DataTextField = "wonumber"
            rblWO.DataValueField = "number"
            rblWO.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub GetHeatWoNo()
        Dim dt As New DataTable()
        dt = RWF.tables.GetMeltingWO(Val(txtHeat_number.Text))
        If dt.Rows.Count > 0 Then
            lblWoval1.Text = IIf(IsDBNull(dt.Rows(0)("WO")), "", dt.Rows(0)("WO"))
            lblWODesc1.Text = IIf(IsDBNull(dt.Rows(0)("WODesc")), "", dt.Rows(0)("WODesc"))
        Else
            lblWoval1.Text = ""
            lblWODesc1.Text = ""
        End If
        dt = Nothing
    End Sub

    Private Sub btnEnable(ByVal Save As Boolean, ByVal Clear As Boolean, ByVal BlExit As Boolean)
        btnSave.Enabled = Save
        btnClear.Enabled = Clear
        btnExit.Enabled = BlExit
    End Sub

    Private Sub PopulateGrid()
        grdPouring.SelectedIndex = -1
        Dim dt As DataTable
        Try
            'grdPouring.Columns.Add("Column", "sno");
            dt = RWF.tables.PopulateGridnew(CInt(txtHeat_number.Text))
            grdPouring.Visible = True
            grdPouring.DataSource = dt
            grdPouring.DataBind()
            If grdPouring.Items.Count = 0 Then
                lblMessage.Text = "No Pouring Data exists for the HeatNo: " & txtHeat_number.Text
                grdPouring.Visible = False
            End If
            txtPourOrder.Text = CInt(grdPouring.Items.Count) + 1
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
            dt = Nothing
        End Try
    End Sub

    Private Sub txtRejCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRejCode.TextChanged
        lblMessage.Text = ""

        SetFocus(btnSave)
        If txtRejCode.Text = "6&7" Then
            txtDragUsed.Text = 0
            txtCopeUsed.Text = 0
            txtIngateUsed.Text = 0
            rdoByPass.ClearSelection()
            rdoByPass.Items(1).Selected = True
        ElseIf txtRejCode.Text.Trim = "7" Then
            txtDragUsed.Text = 0
            txtIngateUsed.Text = 0
            rdoByPass.ClearSelection()
            rdoByPass.Items(2).Selected = True
            'ElseIf txtRejCode.Text.Trim = "6" Then
            '    txtRejCode.Text = txtRejCode.Text = DDLPourStatus_code.SelectedItem.Value
            '    rdoByPass.ClearSelection()
            '    rdoByPass.Items(0).Selected = True
        End If

    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("http://" & Server.MachineName & "/mms/selectModule.aspx")
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        ClearForm()
        SetFocus(txtHeat_number)
    End Sub

    Private Sub txtDragNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDragNo.TextChanged
        lblMessage.Text = ""
        Try
            ValidateDrag()
            If rdoByPass.SelectedItem.Value = "7" Or rdoByPass.SelectedItem.Value.EndsWith("7") Then
                txtDragUsed.Text = "0"
                txtIngateUsed.Text = "0"
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtCopeNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCopeNo.TextChanged
        lblMessage.Text = ""
        Try
            ValidateCope()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub ValidateDrag()
        If txtDragNo.Text = "" Or txtDragNo.Text = "0" Then
            Exit Sub
        End If
        Dim Len As String
        Dim dt As DataTable
        Try
            Len = RWF.tables.ValidateDrag(txtDragNo.Text.Trim, CInt(txtHeat_number.Text))
            If Len.Trim.Length = 0 Then
                dt = RWF.tables.GetDragDetails(txtDragNo.Text.Trim)
                txtEngrNo.Text = dt.Rows(0)("engraved_number")
                If Not IsDBNull(dt.Rows(0)("cpdglf")) Then txtDragUsed.Text = CInt(dt.Rows(0)("cpdglf")) + 1
                If Not IsDBNull(dt.Rows(0)("inglif")) Then txtIngateUsed.Text = CInt(dt.Rows(0)("inglif")) + 1
                btnSave.Enabled = True
                SetFocus(txtRejCode)
            Else
                lblMessage.Text = Len
                btnSave.Enabled = False
                txtDragNo.Text = ""
                txtDragUsed.Text = ""
                txtIngateUsed.Text = ""
                txtEngrNo.Text = ""
                SetFocus(txtDragNo)
                Exit Sub
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If rdoByPass.SelectedItem.Value = "7" Or rdoByPass.SelectedItem.Value.EndsWith("7") Then
            txtDragUsed.Text = "0"
            txtIngateUsed.Text = "0"
        End If
        Len = Nothing
        dt = Nothing
    End Sub

    Private Sub ValidateCope()
        If txtCopeNo.Text = "" Or txtCopeNo.Text = "0" Then
            Exit Sub
        End If
        Dim Len As String
        Try
            Len = RWF.tables.ValidateCope(txtCopeNo.Text.Trim, CInt(txtHeat_number.Text))
            If Len.Trim.Length = 0 Then
                txtCopeUsed.Text = RWF.tables.GetCopeLife(txtCopeNo.Text.Trim)
                btnSave.Enabled = True
                SetFocus(txtDragNo)
            Else
                lblMessage.Text = Len
                btnSave.Enabled = False
                txtCopeUsed.Text = ""
                txtCopeNo.Text = ""
                SetFocus(txtCopeNo)
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If rdoByPass.SelectedItem.Value.StartsWith("6") Then
            txtCopeUsed.Text = "0"
        End If
        Len = Nothing
    End Sub

    Private Sub rdoByPass_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoByPass.SelectedIndexChanged
        lblMessage.Text = ""
        txtRejCode.Text = rdoByPass.SelectedItem.Value
        txtCopeNo.ReadOnly = False
        txtDragNo.ReadOnly = False
        If txtRejCode.Text.IndexOf("6&7") >= 0 Then

        ElseIf txtRejCode.Text.IndexOf("6") >= 0 Then
            txtDragNo.Text = ""
            txtDragUsed.Text = "0"
            txtIngateUsed.Text = "0"
            txtEngrNo.Text = ""
        ElseIf txtRejCode.Text.IndexOf("7") >= 0 Then
            txtCopeNo.Text = ""
            txtCopeUsed.Text = "0"
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        If lblUser.Text = "076857" Then
            If lblNotInMR.Text = "NotInMR" Then
                If txtRejCode.Text.Trim.ToUpper.StartsWith("X") Then
                    lblMessage.Text = "Status cannot be changed !'"
                    Exit Sub
                End If
            End If
        End If
        Dim Done As Boolean
        If Val(txtHeat_number.Text) = 0 Then
            lblMessage.Text = "InValid Heat"
        Else
            If txtDragNo.Text = "" And txtRejCode.Text.Trim.StartsWith("6") = True Then
            ElseIf txtDragNo.Text = "" Then
                If lblMessage.Text <> "" Then
                    lblMessage.Text &= "Cannot be saved. Check data for drag."
                Else
                    lblMessage.Text = "Cannot be saved. Check data for drag."
                End If
                Exit Sub
            End If
            If txtCopeNo.Text = "" And txtRejCode.Text.Trim.StartsWith("7") = True Then
            ElseIf txtCopeNo.Text = "" Then
                If lblMessage.Text <> "" Then
                    lblMessage.Text &= " Cannot be saved. Check data for cope"
                Else
                    lblMessage.Text = " Cannot be saved. Check data for cope"
                End If
                Exit Sub
            End If
            Dim Pour As New RWF.Pouring()
            Dim StrPour, StrWheel, workorder, Description As String
            Try

                workorder = rblWO.SelectedItem.Value.Trim
                Description = GetWoDesc(rblWO.SelectedItem.Value.Trim)
                Pour.Heat = CInt(txtHeat_number.Text.Trim)
                Pour.WorkOrder = workorder
                Pour.PourOrder = txtPourOrder.Text.Trim
                Pour.PourTime = CDate(txtPourDate.Text + " " & txtPourTime.Text)
                'Pour.PourTime = CDate(txtPourDate.Text + " " & txtPourHH.Text.Trim + ":" + txtPourMM.Text.Trim)
                Pour.CopeNumber = txtCopeNo.Text.Trim
                Pour.CopeLife = CInt(txtCopeUsed.Text.Trim)
                Pour.DragNumber = txtDragNo.Text.Trim
                Pour.Wheel = CInt(txtEngrNo.Text.Trim)
                Pour.DragLife = CInt(txtDragUsed.Text.Trim)
                Pour.IngLife = CInt(txtIngateUsed.Text.Trim)
                Pour.SplitTime = CDate(txtPourDate.Text + " 00:" & txtSplitTime.Text)
                Pour.PourRate = cboFastContinuous.SelectedItem.Text.Trim
                Pour.PourStatus = txtRejCode.Text.Trim
                Pour.Remarks = txtRemarks.Text.Trim
                Pour.WhlType = Description
                Pour.MeltDate = CDate(txtPourDate.Text)
                Pour.MouldDate = CDate(txtPourDate.Text)
                Pour.PourStatus = txtRejCode.Text.Trim
                Pour.WhlType = Description
                Pour.ControledRate = Val(txtControledRate.Text)
                Pour.FastRate = Val(txtFastRate.Text)
                '' New Itme added
                Pour.CHOTMP = Val(txtCHOtemp.Text.Trim)
                Pour.BCTMP = Val(txtbakectemp.Text.Trim)
                Pour.SCTMP = Val(txtsprayctemp.Text.Trim)
                Pour.DHOTMP = Val(txtDHOtemp.Text.Trim)
                Pour.SDTMP = Val(txtspraydtemp.Text.Trim)

                Pour.CHONO = ddlcho.SelectedItem.Text.Trim
                Pour.DHONO = ddldho.SelectedItem.Text.Trim

                'Pour.TBINT = CDate(txtPourDate.Text + " " & txtPourTime.Text) ' CDate(Now.Date)
                'Pour.TBOUTT = CDate(txtPourDate.Text + " " & txtPourTime.Text) ' CDate(Now.Date)
                Pour.LIM = Val(txtldlInsl_metal.Text)
                Pour.OPERATOR1 = txtOperator_mould.Text.Trim
                Pour.SIC = txtShift_supervisor.Text.Trim
                Pour.SHIFTID = rblGroup.SelectedItem.Value
                If rdoByPass.SelectedItem.Value = "No ByPass" Then
                    txtPourOrder.Text = GetCumulativeCnt()
                Else
                    txtPourOrder.Text = 0
                End If

                If Val(lblSlNo.Text) > 0 Then
                    Pour.PreCopeNo = ViewState("CopeNo")
                    Pour.PreDragNo = ViewState("DragNo")
                    Pour.PreEngraved = ViewState("EngrNo")
                End If
                Dim PourRate As New RWF.Pouring(Val(txtHeat_number.Text), CInt(txtEngrNo.Text.Trim), Val(txtControledRate.Text), Val(txtFastRate.Text))
                Done = Pour.savePourDetail(Val(lblSlNo.Text))
                If Done Then
                    lblMessage.Text = "Data Saved!"
                Else
                    lblMessage.Text = Pour.Message
                End If
                lblSlNo.Text = ""
            Catch exp As Exception
                lblMessage.Text = Pour.Message & exp.Message
            Finally
                Pour = Nothing
            End Try
            If Done Then
                Try
                    PopulateGrid()
                    ClearForm()
                Catch exp As Exception
                    lblMessage.Text &= exp.Message
                End Try
            End If
            StrPour = Nothing
            StrWheel = Nothing
            workorder = Nothing
            Description = Nothing
            Done = Nothing
        End If
    End Sub

    Private Sub txtHeat_numberChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHeat_number.TextChanged
        lblMessage.Text = ""
        If RWF.tables.CheckHeat(Val(txtHeat_number.Text)) Then
            Try
                Response.Write("text event")
                GetPourHeatDetails()
                GetCopetemp()
                GetDragtemp()
                GetBakCopetemp()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        Else
            lblMessage.Text = "InValid Heat Number '" & txtHeat_number.Text & "'"
            txtHeat_number.Text = ""
        End If
    End Sub

    Private Sub GetData()
        Try
            If Not RWF.tables.CheckHeat(CInt(txtHeat_number.Text)) Then
                lblMessage.Text = "In Vaild Heat Number '" & txtHeat_number.Text
                txtHeat_number.Text = ""
                Exit Try
            End If
            Dim dt As New DataTable()
            dt = RWF.tables.GetMeltingWO(Val(txtHeat_number.Text))
            If dt.Rows.Count > 0 Then
                lblWoval.Text = IIf(IsDBNull(dt.Rows(0)("WO")), "", dt.Rows(0)("WO"))
                lblWODesc.Text = IIf(IsDBNull(dt.Rows(0)("WODesc")), "", dt.Rows(0)("WODesc"))
            Else
                lblWoval.Text = ""
                lblWODesc.Text = ""
            End If
            GetWoNo()
            Dim i As Int16
            rblWO.ClearSelection()
            For i = 0 To rblWO.Items.Count - 1
                If lblWoval.Text.Trim = rblWO.Items(i).Value Then
                    rblWO.Items(i).Selected = True
                    Exit For
                End If
            Next
            PopulateGrid()
            txtPourOrder.Text = GetCumulativeCnt()
            Dim PourTime As DateTime = RWF.tables.GetPouringDate(txtHeat_number.Text)
            If PourTime.Date = CDate("1900-01-01") Then
                ''  txtPourDate.Text = CDate(txtCastDate.Text)

            Else
                txtPourDate.Text = PourTime.Date
            End If
            If Hour(PourTime) = 0 Then
                txtPourTime.Text = Right(("0" + Now.Hour.ToString), 2) + ":" + Right(("0" + Now.Minute.ToString), 2)
            Else
                txtPourTime.Text = Right(("0" + PourTime.Hour.ToString), 2) + ":" + Right(("0" + PourTime.Minute.ToString), 2)
            End If
            txtSplitTime.Text = "09:30"
            btnEnable(True, True, True)
            btnSave.Text = "Save"
            txtCopeUsed.ReadOnly = True
            txtDragUsed.ReadOnly = True
            txtIngateUsed.ReadOnly = True
            cboFastContinuous.Items(0).Selected = True
            dt = Nothing
            i = Nothing
            PourTime = Nothing
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub GetCopetemp()
        Dim dt As New DataTable()
        Response.Write("get cope 1")

        dt = RWF.tables.GetCopetempDetails(CInt(txtHeat_number.Text), txtCopeNo.Text)
        Response.Write("get cope")
        If dt.Rows.Count > 0 Then
            If IsDBNull(dt.Rows(0)("cope_temp")) = False Then
                Response.Write(" cope details")

                txtsprayctemp.Text = dt.Rows(0)("cope_temp")
            Else
                txtsprayctemp.Text = ""
            End If
        Else
            lblMessage.Text = "No data exists for this Cope " & txtCopeNo.Text
        End If
        dt = Nothing
    End Sub

    Private Sub GetDragtemp()
        Dim dt As New DataTable()
        dt = RWF.tables.GetDragtempDetails(CInt(txtHeat_number.Text), txtDragNo.Text)
        If dt.Rows.Count > 0 Then
            If IsDBNull(dt.Rows(0)("drag_temp")) = False Then
                txtspraydtemp.Text = dt.Rows(0)("drag_temp")
            Else
                txtspraydtemp.Text = ""
            End If
        Else
            lblMessage.Text = "No data exists for this Drag " & txtDragNo.Text
        End If
        dt = Nothing
    End Sub

    Private Sub GetBakCopetemp()
        Dim dt As New DataTable()
        dt = RWF.tables.GetBakCopeTempDetails(CInt(txtHeat_number.Text), txtCopeNo.Text)
        If dt.Rows.Count > 0 Then
            If IsDBNull(dt.Rows(0)("cope_tmp")) = False Then
                txtbakectemp.Text = dt.Rows(0)("cope_tmp")
            Else
                txtbakectemp.Text = ""
            End If
        Else
            lblMessage.Text = "No data exists for this Cope " & txtCopeNo.Text
        End If
        dt = Nothing
    End Sub

    Private Sub txtPourDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPourDate.TextChanged
        lblMessage.Text = ""
        Dim dt As Date
        Try
            dt = CDate(txtPourDate.Text)
            txtPourDate.Text = dt
            SetFocus(txtPourTime)
        Catch exp As Exception
            SetFocus(txtPourDate)
            lblMessage.Text = "Invalid Pour Date : " & txtPourDate.Text
            txtPourDate.Text = ""
        End Try
        dt = Nothing
    End Sub

    Private Sub txtPourTime_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPourTime.TextChanged
        lblMessage.Text = ""
        Dim strDt, strTval As String
        Dim dtDate, dtDate1 As DateTime
        Try
            dtDate = Now()
            strTval = (CStr(CDate(txtPourDate.Text)) & " " & Trim(txtPourTime.Text))
            dtDate1 = Convert.ToDateTime(strTval)
            If (dtDate1 > dtDate) Then
                lblMessage.Text = "Pour Time Can't be greater than present time"
                txtPourTime.Text = Format(Now, "HH:mm")
                Exit Sub
            End If
            If Val(lblSlNo.Text) > 0 Then
                If RWF.tables.CheckPourTime(txtHeat_number.Text, txtPourOrder.Text, dtDate1) = 0 Then
                    lblMessage.Text = "Entered time is not in Valid Range"
                    txtPourTime.Text = Format(Now, "HH:mm")
                End If
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            If lblMessage.Text.Trim.Length = 0 Then
                SetFocus(txtCopeNo)
            Else
                SetFocus(txtPourTime)
            End If
        End Try
        strDt = Nothing
        strTval = Nothing
        dtDate = Nothing
        dtDate1 = Nothing
    End Sub

    Private Sub txtSplitTime_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSplitTime.TextChanged
        lblMessage.Text = ""
        Dim dt As Date
        Try
            dt = CDate(txtPourDate.Text) & " " & Trim(txtSplitTime.Text)
            SetFocus(txtRejCode)
        Catch exp As Exception
            SetFocus(txtSplitTime)
            lblMessage.Text = "Invalid time formatin Split Time : " & txtSplitTime.Text
            txtSplitTime.Text = ""
        End Try
        dt = Nothing
    End Sub

    Private Sub txtTITDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTITDate.TextChanged
        lblMessage.Text = ""
        Try
            txtTITDate.Text = CDate(txtTITDate.Text)
            SetFocus(txtTube_intime)
        Catch exp As Exception
            lblMessage.Text = "Invalid Date format in TubeIn Date : " & txtTITDate.Text
            txtTITDate.Text = ""
            SetFocus(txtTITDate)
        End Try
    End Sub

    Private Sub txtTube_intime_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTube_intime.TextChanged
        lblMessage.Text = ""
        Dim dt As DateTime
        Try
            dt = CDate(txtTITDate.Text) & " " & Trim(txtTube_intime.Text)
            CType(Session("PreNPost"), RWF.PreNPostPouring).TubeInTime = dt
            SetFocus(txtTOTDate)
        Catch exp As Exception
            lblMessage.Text = "Invalid time format in IIIrd Imm Time : " & txtTube_intime.Text
            txtTube_intime.Text = ""
            SetFocus(txtTube_intime)
        End Try
        dt = Nothing
    End Sub

    Private Sub txtTOTDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTOTDate.TextChanged
        lblMessage.Text = ""
        Try
            txtTOTDate.Text = CDate(txtTOTDate.Text)
            SetFocus(txtTube_outtime)
        Catch exp As Exception
            lblMessage.Text = "Invalid Date format in TubeIn Date : " & txtTOTDate.Text
            txtTOTDate.Text = ""
            SetFocus(txtTOTDate)
        End Try
    End Sub

    Private Sub grdPouring_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdPouring.ItemCommand
        lblMessage.Text = ""
        lblSlNo.Text = 0
        ViewState("CopeNo") = ""
        ViewState("DragNo") = ""
        ViewState("EngrNo") = ""
        Dim workorder As String
        Try
            ClearForm()
            Select Case e.CommandName
                Case "Select"
                    If e.Item.Cells(18).Text = "NotInMR" Then
                        lblNotInMR.Text = e.Item.Cells(18).Text.Trim
                    End If
                    If lblUser.Text <> "076857" Then
                        If e.Item.Cells(18).Text = "NotInMR" Then
                            lblMessage.Text = "Wheel Not in Mould Room ,  Cannot edit"
                            grdPouring.SelectedIndex = -1
                            Exit Sub
                        End If
                    End If
                    rdoByPass.ClearSelection()
                    rdoByPass.Items(0).Selected = True
                    txtPourOrder.Text = e.Item.Cells(0).Text
                    txtPourTime.Text = e.Item.Cells(1).Text
                    txtCopeNo.Text = e.Item.Cells(2).Text.Replace("&nbsp;", "")
                    ViewState("CopeNo") = txtCopeNo.Text
                    txtCopeUsed.Text = e.Item.Cells(3).Text
                    txtDragNo.Text = e.Item.Cells(8).Text.Replace("&nbsp;", "")
                    ViewState("DragNo") = txtDragNo.Text.Trim
                    txtEngrNo.Text = e.Item.Cells(9).Text
                    ViewState("EngrNo") = txtEngrNo.Text
                    txtDragUsed.Text = e.Item.Cells(10).Text
                    txtIngateUsed.Text = e.Item.Cells(14).Text
                    txtSplitTime.Text = e.Item.Cells(15).Text

                    txtCHOtemp.Text = e.Item.Cells(5).Text
                    txtbakectemp.Text = e.Item.Cells(6).Text
                    txtsprayctemp.Text = e.Item.Cells(7).Text
                    txtDHOtemp.Text = e.Item.Cells(12).Text
                    txtspraydtemp.Text = e.Item.Cells(13).Text
                    If Trim(e.Item.Cells(9).Text) = "C" Then
                        cboFastContinuous.SelectedIndex = 0
                    Else
                        cboFastContinuous.SelectedIndex = 1
                    End If
                    If e.Item.Cells(10).Text <> "&nbsp;" Then
                        txtControledRate.Text = Trim(e.Item.Cells(17).Text)
                    Else
                        txtControledRate.Text = ""
                    End If

                    If e.Item.Cells(11).Text <> "&nbsp;" Then
                        txtFastRate.Text = Trim(e.Item.Cells(18).Text)
                    Else
                        txtFastRate.Text = ""
                    End If
                    If e.Item.Cells(12).Text <> "&nbsp;" Then
                        txtRejCode.Text = e.Item.Cells(19).Text
                    Else
                        txtRejCode.Text = ""
                    End If
                    If e.Item.Cells(13).Text <> "&nbsp;" Then
                        txtRemarks.Text = Trim(e.Item.Cells(20).Text)
                    Else
                        txtRemarks.Text = ""
                    End If
                    If txtRejCode.Text = "6&7" Then
                        rdoByPass.Items(1).Selected = True
                    ElseIf txtRejCode.Text = "7" Then
                        rdoByPass.Items(2).Selected = True
                    Else
                        rdoByPass.Items(0).Selected = True
                    End If
                    Dim i As Integer
                    rblWO.ClearSelection()
                    For i = 0 To rblWO.Items.Count - 1
                        If Not rblWO.Items(i).Text.ToLower = "select" Then
                            If rblWO.Items(i).Text.Substring(5, 4).Trim = Trim(e.Item.Cells(14).Text) Then
                                rblWO.Items(i).Selected = True
                                'WorkOrder = rblWO.SelectedItem.Value.Trim
                                Exit For
                            End If
                        End If
                    Next
                    ' lblSlNo.Text = e.Item.Cells(22).Text

                    lblSlNo.Text = e.Item.Cells(24).Text
                    i = Nothing
            End Select
            btnSave.Text = "UPDATE"
            txtPourOrder.ReadOnly = True
            btnSave.Enabled = True
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    'Protected Sub DDLPourStatus_code_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDLPourStatus_code.SelectedIndexChanged
    '    lblMessage.Text = ""
    '    SetFocus(txtRejCode)
    '    txtRejCode.Text = DDLPourStatus_code.SelectedValue


    '    'If rdoByPass.SelectedItem.Value = "No ByPass" Then
    '    '    'If DDLPourStatus_code.SelectedItem.Text.ToLower <> "select" Then
    '    '    txtRejCode.Text = DDLPourStatus_code.SelectedItem.Text
    '    '    'End If
    '    'End If
    'End Sub

    Private Sub DDLPourStatus_code_TextChanged(sender As Object, e As EventArgs) Handles DDLPourStatus_code.TextChanged
        txtRejCode.Text = DDLPourStatus_code.SelectedItem.Value
    End Sub

End Class