Public Class magnaglowTestingEdit
    Inherits System.Web.UI.Page
    Protected WithEvents txtWhl As System.Web.UI.WebControls.TextBox
    Protected WithEvents chkTypeOverride As System.Web.UI.WebControls.CheckBox
    Protected WithEvents txtGrindStatus As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMcnOperation As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblEmpCode As System.Web.UI.WebControls.Label
    Protected WithEvents lblWheelTypeChanged As System.Web.UI.WebControls.Label
    Protected WithEvents lblbhnInfo As System.Web.UI.WebControls.Label
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents btnClear As System.Web.UI.WebControls.Button
    Protected WithEvents lblWheel As System.Web.UI.WebControls.Label
    Protected WithEvents lblHeat As System.Web.UI.WebControls.Label
    Protected WithEvents txtWheelStatus As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBHN0Value As System.Web.UI.WebControls.TextBox
    Protected WithEvents chkUTPassed As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkPlatePass As System.Web.UI.WebControls.CheckBox
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents grdMagnaGlow As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents ddlwo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label

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

        ' Page.Theme = themeValue
        Page.Theme = Session("Theme")
    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        lblHeat.Visible = False
        lblWheel.Visible = False
        lblEmpCode.Visible = False
        If Page.IsPostBack = False Then
            Dim blnWheelObjCreated As Boolean = False
            Try
                lblMessage.Text = ""
                lblbhnInfo.Text = ""
                Dim strMode As String = "edit"
                Session("UserId") = "078844"
                Session("Group") = "CMTWHL"
                lblEmpCode.Text = Session("UserId")
                Dim oEmp As New rwfGen.Employee()
                'If oEmp.Check(lblEmpCode.Text, Session("Group")) = False Then
                '    lblEmpCode.Text = ""
                'End If
                'If lblEmpCode.Text.Trim = "" Then
                '    Response.Redirect("http://172.16.25.53/mms/InvalidSession.aspx")
                '    Exit Sub
                'End If
                ViewState("PermitForReworkOnly") = False
                lblMessage.Text = "Pl. enter the wheel No/Heat No. to Edit details."
                btnSave.Visible = True
                strMode = Nothing
                oEmp = Nothing
            Catch exp As Exception
                lblMessage.Text = exp.Message
                Response.Redirect("http://172.16.25.53/mms/InvalidSession.aspx")
            End Try
            Session("myform") = New Magwheelfrm()
            CType(Session("myForm"), Magwheelfrm).LineNumber = "1A"
            CType(Session("myForm"), Magwheelfrm).getformdata()
            CType(Session("myForm"), Magwheelfrm).productsddl(ddlwo)
            Session("blnWheelObjCreated") = blnWheelObjCreated
            SetFocus(txtWhl)

        End If
    End Sub

    Private Sub SetFocus(ByVal ctrl As Control)
        Dim focusScript As String = "<script language=" & "javascript" & " > " & _
        "document.getElementById('" + ctrl.ClientID.ToString.Trim & _
        "').focus();</script>"
        Page.RegisterStartupScript("FocusScript", focusScript)
    End Sub

    Private Sub txtWhl_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWhl.TextChanged
        Try
            Session("wheel").dispose()
        Catch
        End Try
        Try
            Session("wheel") = New MagWheel()
            lblMessage.Text = validwheel()
            If lblMessage.Text = "" Then
                lblMessage.ForeColor = System.Drawing.Color.Black
                PopulateGrid(Val(lblWheel.Text), Val(lblHeat.Text))
                If RWF.Magna.CheckDt(Val(lblHeat.Text), Val(lblWheel.Text)) = 0 Then
                    ' edit of xc8rht allowed on 03-05-2005 svi
                    If Left(txtWheelStatus.Text, 1) = "S" Or (Left(txtWheelStatus.Text, 1) = "X" And Left(txtWheelStatus.Text, 6) <> "XC8RHT") Then
                        lblMessage.Text = "Already Pink Sheet Generated for this Wheel"
                        btnSave.Enabled = False
                        ClearForm(False)
                        Exit Sub
                    Else
                        viewstate("PermitForReworkOnly") = True
                    End If
                End If
                CType(Session("wheel"), MagWheel).LineNumber = "1A"
                Dim dtd As Date
                dtd = dtd.Date.Today
                CType(Session("wheel"), MagWheel).getwheeldata(dtd, Session("myform").pinkdate)
                updateObject(True)
                CType(Session("wheel"), MagWheel).CurrentWheelType = ddlwo.SelectedItem.Text.ToUpper
                lblWheelTypeChanged.Text = CType(Session("wheel"), MagWheel).ErrMessage
                btnSave.Enabled = True
                SetFocus(txtGrindStatus)
            Else
                lblMessage.ForeColor = System.Drawing.Color.Red
                btnSave.Enabled = False
                ClearForm(False)
                CType(Session("wheel"), MagWheel).dispose()
                SetFocus(txtWhl)
            End If
            If lblMessage.Text = "" Then
                lblMessage.ForeColor = System.Drawing.Color.Black
                PopulateGrid(Val(lblWheel.Text), Val(lblHeat.Text))
                CType(Session("wheel"), MagWheel).LineNumber = "1A"
                Dim dtd As Date
                dtd = dtd.Date.Today
                CType(Session("wheel"), MagWheel).getwheeldata(dtd, Session("myform").pinkdate)
                updateObject(True)
                CType(Session("wheel"), MagWheel).CurrentWheelType = ddlwo.SelectedItem.Text.ToUpper
                lblWheelTypeChanged.Text = CType(Session("wheel"), MagWheel).ErrMessage
                btnSave.Enabled = True
                SetFocus(txtGrindStatus)
            Else
                lblMessage.ForeColor = System.Drawing.Color.Red
                btnSave.Enabled = False
                ClearForm(False)
                CType(Session("wheel"), MagWheel).dispose()
                SetFocus(txtWhl)
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Function validwheel(Optional ByVal Revalidate As Boolean = False) As String
        Dim strsql As String
        validwheel = ""
        If InStr(txtWhl.Text, "/") <= 1 Then
            validwheel = "Invalid Wheel Number"
            Exit Function
        End If
        Dim testwhl() As String = Split(txtWhl.Text, "/")
        Dim i As Integer
        Try
            For i = 0 To CStr(testwhl(0)).Length - 1
                If IsNumeric(CStr(testwhl(0)).Substring(i, 1)) = False Then
                    txtWhl.Text = ""
                End If
            Next
            If txtWhl.Text <> "" Then
                For i = 0 To CStr(testwhl(1)).Length - 1
                    If IsNumeric(CStr(testwhl(1)).Substring(i, 1)) = False Then
                        txtWhl.Text = ""
                    End If
                Next
            End If
        Catch
            txtWhl.Text = ""
        End Try

        If txtWhl.Text.Trim = "" Then
            btnSave.Enabled = False
            validwheel = "Wheel Number is blank/non-numeric characters in wheel number found"
            Exit Function
        End If

        Dim strarr = Split(txtWhl.Text, "/")
        lblWheel.Text = Val(strarr(0))
        lblHeat.Text = Val(strarr(1))

        Dim iDespMounted As Integer = RWF.Magna.DespMounted(Val(lblHeat.Text), Val(lblWheel.Text))
        If iDespMounted = Nothing Then
            iDespMounted = 0
        End If
        If iDespMounted = 0 Then
            validwheel = "Wheel is either despatched/Pressed"
            Exit Function
        End If
        If Revalidate = False Then
            CType(Session("wheel"), MagWheel).wheel_Number = txtWhl.Text
            Session("blnWheelObjCreated") = True
            CType(Session("wheel"), MagWheel).McnOpnCodes = CType(Session("myForm"), Magwheelfrm).McnOpnCodes
            CType(Session("wheel"), MagWheel).DefCodes = CType(Session("myForm"), Magwheelfrm).DefCodes
            CType(Session("wheel"), MagWheel).LocCodes = CType(Session("myForm"), Magwheelfrm).LocCodes
        End If
        Dim whllocation As String = RWF.Magna.whllocation(Val(lblHeat.Text), Val(lblWheel.Text))
        If whllocation Is Nothing Then
            whllocation = ""
        End If
        If whllocation.ToUpper.Trim <> "CLMT" = True Then
            validwheel = "Wheel Not in CLMT"
            Exit Function
        End If
        If CType(Session("wheel"), MagWheel).ErrStatus = True Then
            validwheel = CType(Session("wheel"), MagWheel).ErrMessage
        End If
    End Function

    Private Sub ClearForm(Optional ByVal DoNotEraseErrorMessage As Boolean = True)
        Dim intCnt, intCnt1 As Integer
        If DoNotEraseErrorMessage = True Then
            lblMessage.Text = ""
            lblMessage.ForeColor = System.Drawing.Color.Black
            Dim st As New Style()
            lblMessage.Font.Size = st.Font.Size.Small
        Else
            lblMessage.ForeColor = System.Drawing.Color.Red
            Dim st As New Style()
            lblMessage.Font.Size = st.Font.Size.Medium
        End If
        txtWhl.Text = ""
        txtGrindStatus.Text = ""
        txtMcnOperation.Text = ""
        txtWheelStatus.Text = ""
        txtRemarks.Text = ""
        txtBHN0Value.Text = ""
        chkPlatePass.Checked = False
        chkUTPassed.Checked = False
        Dim arr As String
        grdMagnaGlow.DataSource = arr
        grdMagnaGlow.DataBind()
    End Sub

    Private Sub PopulateGrid(ByVal wheel As Long, ByVal heat As Long)
        Dim dt As DataTable
        Try
            dt = RWF.Magna.WhlDetails(wheel, heat)
            grdMagnaGlow.DataSource = dt
            grdMagnaGlow.DataBind()
            Dim i As Integer
            i = 0
            If grdMagnaGlow.Items.Count > 0 Then
                If i = 0 Then
                    txtGrindStatus.Text = grdMagnaGlow.Items(0).Cells(3).Text.Trim
                    txtMcnOperation.Text = grdMagnaGlow.Items(0).Cells(4).Text.Trim
                    txtWheelStatus.Text = grdMagnaGlow.Items(0).Cells(5).Text.Trim
                    txtBHN0Value.Text = grdMagnaGlow.Items(0).Cells(7).Text.Trim
                    txtRemarks.Text = grdMagnaGlow.Items(0).Cells(8).Text.Trim
                    chkUTPassed.Checked = IIf(grdMagnaGlow.Items(0).Cells(6).Text.Trim.ToUpper = "P", True, False)
                    chkPlatePass.Checked = IIf(Right(txtMcnOperation.Text.Trim.ToUpper, 2) = "/P", True, False)
                    If txtGrindStatus.Text = "&nbsp;" Then txtGrindStatus.Text = ""
                    If txtMcnOperation.Text = "&nbsp;" Then txtMcnOperation.Text = ""
                    If txtRemarks.Text = "&nbsp;" Then txtRemarks.Text = ""
                    If txtBHN0Value.Text = "&nbsp;" Then txtBHN0Value.Text = ""
                    i = 1
                    Dim a As Integer = 0
                    ddlwo.ClearSelection()
                    For a = 0 To ddlwo.Items.Count - 1
                        If ddlwo.Items(a).Text.ToUpper.Trim = grdMagnaGlow.Items(0).Cells(10).Text.Trim Then
                            ddlwo.Items(a).Selected = True
                            Exit For
                        End If
                    Next
                End If
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub updateObject(ByVal FirstTime As Boolean)
        If txtMcnOperation.Text = "&nbsp;" Then txtMcnOperation.Text = ""
        If txtGrindStatus.Text = "&nbsp;" Then txtGrindStatus.Text = ""
        If FirstTime = False Then
            If txtMcnOperation.Text <> "" Then
                CType(Session("wheel"), MagWheel).McnOperation = Replace(Replace(CType(Session("wheel"), MagWheel).ConvertToSingleMcnCode(txtMcnOperation.Text), ",", ""), "MC", "")
            End If
            If txtGrindStatus.Text <> "" Then
                CType(Session("wheel"), MagWheel).GrindStatus = Replace(txtGrindStatus.Text, "+", "")
            End If
        End If
        CType(Session("wheel"), MagWheel).UTPassed(chkUTPassed.Checked)
        If CType(Session("wheel"), MagWheel).CurWheelRHT = True Then
            lblbhnInfo.Text = CType(Session("wheel"), MagWheel).ErrMessage
            txtWheelStatus.Text = CType(Session("wheel"), MagWheel).WheelStatusText
        Else
            lblbhnInfo.Text = ""
        End If
        chkUTPassed.Checked = CType(Session("wheel"), MagWheel).UTStatus = "P"
        CType(Session("wheel"), MagWheel).WheelStatus = txtWheelStatus.Text
        chkPlatePass.Visible = CType(Session("wheel"), MagWheel).CanBePlatePassed(txtMcnOperation.Text, True)
        If CType(Session("wheel"), MagWheel).ErrStatus = True Then
            lblMessage.Text &= CType(Session("wheel"), MagWheel).ErrMessage
        End If
    End Sub

    Private Sub ddlwo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlwo.SelectedIndexChanged
        SelectWheelType()
    End Sub

    Private Sub SelectWheelType()
        CType(Session("wheel"), MagWheel).CurrentWheelType = ddlwo.SelectedItem.Text.ToUpper
        lblWheelTypeChanged.Text = CType(Session("wheel"), MagWheel).ErrMessage
        If CType(Session("wheel"), MagWheel).curWheelTypeChanged = True Then
            ddlwo.ForeColor = System.Drawing.Color.Red
            btnSave.Enabled = False
        Else
            ReValidate()
            ddlwo.ForeColor = System.Drawing.Color.Black
        End If
    End Sub

    Private Sub ReValidate()
        lblMessage.Text = validwheel(True)
        If lblMessage.Text <> "" Then
            lblMessage.ForeColor = System.Drawing.Color.Red
            btnSave.Enabled = False
            ClearForm(False)
            CType(Session("wheel"), MagWheel).dispose()
            txtWhl.Text = ""
        Else
            btnSave.Enabled = True
        End If
    End Sub

    Private Sub chkTypeOverride_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTypeOverride.CheckedChanged
        If btnSave.Enabled = True Then
            CType(Session("wheel"), MagWheel).TypeOverride = chkTypeOverride.Checked
            btnSave.Enabled = chkTypeOverride.Checked
        Else
            ReValidate()
        End If
    End Sub

    Private Sub txtGrindStatus_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGrindStatus.TextChanged
        Try
            If Session("blnWheelObjCreated") = False Then
                lblMessage.Text = "Enter Wheel Number / Heat Number "
                Exit Sub
            End If
            CType(Session("wheel"), MagWheel).GrindStatus = Replace(txtGrindStatus.Text, "+", "")
            txtGrindStatus.Text = Replace(CStr(CType(Session("wheel"), MagWheel).GrindStatus), "+", "")
            If CType(Session("wheel"), MagWheel).ErrStatus = True Or CType(Session("wheel"), MagWheel).CurWheelRHT = True Then
                lblMessage.Text = CType(Session("wheel"), MagWheel).ErrMessage
            Else
                lblMessage.Text = ""
            End If
            If txtMcnOperation.Text <> "" Then
                txtMcnOperation.Text = Replace(txtMcnOperation.Text, "MC", "")
            End If
            fillstatuses()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub fillstatuses()
        If CType(Session("wheel"), MagWheel).CurWheelRHT = True Then
            lblbhnInfo.Text = CType(Session("wheel"), MagWheel).ErrMessage
            txtWheelStatus.Text = CType(Session("wheel"), MagWheel).WheelStatusText
        Else
            lblbhnInfo.Text = ""
        End If
        If txtMcnOperation.Text.Trim = "" Then
            CType(Session("wheel"), MagWheel).McnOperation = txtMcnOperation.Text
        End If
        If txtGrindStatus.Text.Trim = "" Then
            CType(Session("wheel"), MagWheel).GrindStatus = txtGrindStatus.Text
        End If
        CType(Session("wheel"), MagWheel).UTPassed(chkUTPassed.Checked)
        CType(Session("wheel"), MagWheel).WheelStatus = txtWheelStatus.Text
        txtWheelStatus.Text = CType(Session("wheel"), MagWheel).WheelStatusText
        txtMcnOperation.Text = Replace(CStr(CType(Session("wheel"), MagWheel).McnOperation), "MC", "")
        txtGrindStatus.Text = Replace(CStr(CType(Session("wheel"), MagWheel).GrindStatus), "+", "")
        chkUTPassed.Checked = CType(Session("wheel"), MagWheel).UTStatus = "P"
        chkPlatePass.Visible = CType(Session("wheel"), MagWheel).CanBePlatePassed(txtMcnOperation.Text, True)
        If CType(Session("wheel"), MagWheel).ErrStatus = True Then
            lblMessage.Text = CType(Session("wheel"), MagWheel).ErrMessage
        End If
        CType(Session("wheel"), MagWheel).WorkOrder = CType(Session("myForm"), Magwheelfrm).workorder
        If CType(Session("wheel"), MagWheel).NewSeriesWheel = True Then
            txtWhl.ForeColor = System.Drawing.Color.Red
        Else
            txtWhl.ForeColor = System.Drawing.Color.Black
        End If
        ReValidate()
    End Sub

    Private Sub txtMcnOperation_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMcnOperation.TextChanged
        If Session("blnWheelObjCreated") = False Then
            lblMessage.Text = "Enter Wheel Number / Heat Number "
            Exit Sub
        End If
        CType(Session("wheel"), MagWheel).McnOperation = txtMcnOperation.Text
        chkPlatePass.Visible = CType(Session("wheel"), MagWheel).CanBePlatePassed(txtMcnOperation.Text, True)
        txtMcnOperation.Text = CType(Session("wheel"), MagWheel).McnOperation
        If CType(Session("wheel"), MagWheel).ErrStatus = True Or CType(Session("wheel"), MagWheel).CurWheelRHT = True Then
            lblMessage.Text = CType(Session("wheel"), MagWheel).ErrMessage
        End If
        fillstatuses()
    End Sub

    Private Sub txtBHN0Value_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBHN0Value.TextChanged
        If Session("blnWheelObjCreated") = False Then
            lblMessage.Text = "Enter Wheel Number / Heat Number "
            Exit Sub
        End If
        CType(Session("wheel"), MagWheel).BHNStatus_forCurWheel(CType(Session("wheel"), MagWheel).CurrentWheelType.Trim) = Val(txtBHN0Value.Text)
        fillstatuses()
    End Sub

    Private Sub chkUTPassed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUTPassed.CheckedChanged
        If Session("blnWheelObjCreated") = False Then
            lblMessage.Text = "Enter Wheel Number / Heat Number "
            Exit Sub
        End If
        CType(Session("wheel"), MagWheel).UTPassed(chkUTPassed.Checked)
        txtWheelStatus.Text = CType(Session("wheel"), MagWheel).WheelStatus
        fillstatuses()
    End Sub

    Private Sub chkPlatePass_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPlatePass.CheckedChanged
        txtMcnOperation.Text = CType(Session("wheel"), MagWheel).PlatePassed(chkPlatePass.Checked)
        If CType(Session("wheel"), MagWheel).McnOperation = "" Then
            CType(Session("wheel"), MagWheel).McnOperation = txtMcnOperation.Text
        End If
        fillstatuses()
    End Sub

    Private Sub txtWheelStatus_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWheelStatus.TextChanged
        If Session("blnWheelObjCreated") = False Then
            lblMessage.Text = "Enter Wheel Number / Heat Number "
            Exit Sub
        End If
        CType(Session("wheel"), MagWheel).WheelStatus = txtWheelStatus.Text
        If CType(Session("wheel"), MagWheel).ErrStatus = True Or CType(Session("wheel"), MagWheel).CurWheelRHT = True Then
            lblMessage.Text = CType(Session("wheel"), MagWheel).ErrMessage
        Else
            lblMessage.Text = ""
        End If
        fillstatuses()
    End Sub

    Private Sub txtRemarks_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRemarks.TextChanged
        CType(Session("wheel"), MagWheel).Remarks = txtRemarks.Text
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        ClearForm()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If lblEmpCode.Text.Trim.Length = 0 Then
            lblMessage.Text = "InValid Employee Code !"
            Exit Sub
        End If
        Dim oEmp As New rwfGen.Employee()
        If oEmp.Check(lblEmpCode.Text, "CMTWHL") = False Then
            Response.Redirect("http://172.16.25.53/mms/InvalidSession.aspx")
        End If
        Try
            lblMessage.Text = validwheel(True)
            updateObject(False)
            Dim dt As DataTable
            If lblMessage.Text = "" Then
                If viewstate("PermitForReworkOnly") = True Then
                    Select Case Left(txtWheelStatus.Text, 1)
                        Case "S", "X"
                            lblMessage.Text = "You cannot Stock/XC old Wheels"
                            Exit Sub
                        Case Else
                    End Select
                End If
                Update(Val(lblWheel.Text), Val(lblHeat.Text))
                dt = RWF.Magna.WhlDetails(Val(lblWheel.Text), Val(lblHeat.Text))
                grdMagnaGlow.DataSource = dt
                grdMagnaGlow.DataBind()
                lblMessage.ForeColor = System.Drawing.Color.Black
                SetFocus(txtWhl)
            Else
                lblMessage.ForeColor = System.Drawing.Color.Red
                SetFocus(btnSave)
            End If
        Catch exp As Exception
            lblMessage.Text = ""
        End Try
    End Sub

    Private Sub Update(ByVal Wheel As Long, ByVal Heat As Long)
        Dim cMagSts As String = ""
        If CType(Session("wheel"), MagWheel).WheelStatusText.ToLower = "rework" Then
            If CType(Session("wheel"), MagWheel).GrindStatus <> "" And CType(Session("wheel"), MagWheel).McnOperation = "" Then
                cMagSts = "G"
            ElseIf CType(Session("wheel"), MagWheel).McnOperation <> "" Then
                cMagSts = "M"
            Else
                cMagSts = " "
                lblMessage.Text = "Illogical Data : Rework wheel should have grind or mcn sts"
                Exit Sub
            End If
        ElseIf CType(Session("wheel"), MagWheel).WheelStatusText.ToLower = "xc8rht" Then
            cMagSts = "H"
        ElseIf CType(Session("wheel"), MagWheel).WheelStatusText.ToLower = "stock" Then
            If CType(Session("wheel"), MagWheel).McnOperation <> "" Or CType(Session("wheel"), MagWheel).GrindStatus <> "" Then
                lblMessage.Text = "Illogical Data : Stock wheel should not have grind or mcn sts"
                Exit Sub
            End If
            cMagSts = "S"
        Else
            cMagSts = "X"
        End If
        If CType(Session("wheel"), MagWheel).WheelStatusText.Trim = "" Then
            lblMessage.Text = "Invalid Wheel Status. Cannot be updated"
            Exit Sub
        End If
        Dim Done As Boolean
        Try
            Done = New RWF.Magna().Update(Val(lblWheel.Text), Val(lblHeat.Text), lblEmpCode.Text, CType(Session("wheel"), MagWheel).McnOperation, CType(Session("wheel"), MagWheel).GrindStatus(), CType(Session("wheel"), MagWheel).WheelStatusText, CType(Session("wheel"), MagWheel).UTStatus, CType(Session("wheel"), MagWheel).Remarks, ddlwo.SelectedItem.Value, CType(Session("wheel"), MagWheel).CurrentWheelType, CType(Session("wheel"), MagWheel).MagWheelNumber, CType(Session("wheel"), MagWheel).MagHeatNumber, cMagSts, Val(txtBHN0Value.Text))
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            If Done Then
                lblMessage.Text = "Updated Successfully."
            Else
                lblMessage.Text = "Updation Failed !."
            End If
        End Try
    End Sub
End Class
