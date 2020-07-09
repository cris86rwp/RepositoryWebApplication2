Public Class BoreInspectionUnBorePassedWheels
    Inherits System.Web.UI.Page
    Protected WithEvents dgDespHistory As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgPressHistory As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgWhlLoadHistory As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgQChistory As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgYIHistory As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgFIHistory As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgMagHistory As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgMasterHistory As System.Web.UI.WebControls.DataGrid
    Protected WithEvents pnlHistory As System.Web.UI.WebControls.Panel
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtInspector As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblShift As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtWheelNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtHeatNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents dgWheels As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgScore As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgLastInsp As System.Web.UI.WebControls.DataGrid
    Protected WithEvents chkBoreWheel As System.Web.UI.WebControls.CheckBox
    Protected WithEvents txtBoreDia As System.Web.UI.WebControls.TextBox
    Protected WithEvents chkHelp As System.Web.UI.WebControls.CheckBox
    Protected WithEvents pnlHelp As System.Web.UI.WebControls.Panel
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnClear As System.Web.UI.WebControls.Button
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
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
        Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None
        'Put user code to initialize the page here
        Session("UserID") = "079484"
        If Page.IsPostBack = False Then
            If IsNothing(Session("UserID")) = True Then
                Response.Redirect("InvalidSession.aspx")
                Exit Sub
            Else
                txtInspector.Text = Session("UserID")
                txtInspector.ReadOnly = True
                chkHelp.Checked = False
                pnlHelp.Visible = chkHelp.Checked
                Try
                    txtDate.Text = RWF.CLRINS.LastBoreDate
                    populateGrid()
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                End Try
            End If
            SetFocus(txtDate)
        End If
    End Sub

    Private Sub populateGrid()
        If CDate(txtDate.Text) > Now.Date Then
            lblMessage.Text = "Date : '" & CDate(txtDate.Text) & "' cannot be greater than Today !"
            txtDate.Text = ""
        Else
            txtDate.Text = CDate(txtDate.Text)
            Dim dt As DataTable
            Try
                dt = RWF.CLRINS.GetDetails(CDate(txtDate.Text), rblShift.SelectedItem.Text.Trim)
                dgWheels.DataSource = dt
                dgWheels.DataBind()
                dgWheels.Visible = True
            Catch exp As Exception
                lblMessage.Text = exp.Message
            Finally
                dt.Dispose()
                dt = Nothing
            End Try
            ShowScore()
        End If
    End Sub

    Private Sub ShowScore()
        Dim dt As DataTable
        Try
            dt = RWF.CLRINS.ShowScore(CDate(txtDate.Text), rblShift.SelectedItem.Text)
            dgScore.DataSource = dt
            dgScore.DataBind()
        Catch exp As Exception
            dgScore.DataSource = Nothing
            dgScore.DataBind()
        Finally
            dt.Dispose()
            dt = Nothing
        End Try
    End Sub

    Private Sub chkHelp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHelp.CheckedChanged
        pnlHelp.Visible = chkHelp.Checked
    End Sub

    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        populateGrid()
    End Sub

    Private Sub rblShift_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblShift.SelectedIndexChanged
        populateGrid()
    End Sub

    Private Sub SetFocus(ByVal ctrl As Control)
        Dim focusScript As String = "<script language=" & "javascript" & " > " & _
        "document.getElementById('" + ctrl.ClientID.ToString.Trim & _
        "').focus();</script>"
        Page.RegisterStartupScript("FocusScript", focusScript)
    End Sub

    Private Sub txtWheelNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWheelNumber.TextChanged
        lblMessage.Text = ""
        If Val(txtWheelNumber.Text) > 100000 Then
            txtHeatNumber.Text = 0
            txtHeatNumber.ReadOnly = True
            txtHeatNumber.TabIndex = -1
        Else
            txtHeatNumber.Text = ""
            txtHeatNumber.ReadOnly = False
            txtHeatNumber.TabIndex = txtWheelNumber.TabIndex + 1
        End If
        btnSave.Text = "Save"
        DispWheelStatus()
        SetFocus(txtHeatNumber)
    End Sub

    Private Sub DispWheelStatus()
        Dim dt As DataTable
        If Not (txtWheelNumber.Text <> "" And txtHeatNumber.Text <> "") Then Exit Sub
        dt = RWF.CLRINS.InspectedDateShift(Val(txtWheelNumber.Text), Val(txtHeatNumber.Text))
        If dt.Rows.Count > 0 Then
            If CDate(txtDate.Text) < dt.Rows(0)(0) Then
                lblMessage.Text = "You cannot edit earlier records"
                txtWheelNumber.Text = ""
                txtHeatNumber.Text = ""
                Exit Sub
            ElseIf CDate(txtDate.Text) = dt.Rows(0)(0) Then
                If dt.Rows(0)(1) > rblShift.SelectedItem.Text Then
                    lblMessage.Text = "You cannot edit earlier records"
                    txtWheelNumber.Text = ""
                    txtHeatNumber.Text = ""
                    Exit Sub
                End If
            End If
        End If
        If txtWheelNumber.Text = "" AndAlso txtHeatNumber.Text = "" Then Exit Sub
        Try
            lblMessage.Text = RWF.CLRINS.IsWheelDesp(Val(txtWheelNumber.Text), Val(txtHeatNumber.Text))
            If lblMessage.Text.Trim.Length = 0 Then
                lblMessage.Text = RWF.CLRINS.CheckWheel(Val(txtWheelNumber.Text), Val(txtHeatNumber.Text))
            End If
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
        If Not lblMessage.Text.EndsWith("OK") Then
            txtWheelNumber.Text = ""
            txtHeatNumber.Text = ""
            Exit Sub
        End If
        If Not RWF.CLRINS.IsInMaster(Val(txtWheelNumber.Text), Val(txtHeatNumber.Text)) Then
            lblMessage.Text = "Not in Master"
            txtWheelNumber.Text = ""
            txtHeatNumber.Text = ""
            Exit Sub
        End If
        Dim strPassLocation As String = RWF.CLRINS.GetUnBorePassedWheelLocation(Val(txtWheelNumber.Text), Val(txtHeatNumber.Text))
        If strPassLocation.Trim.Length = 0 Then
            lblMessage.Text = "Not Unbore Passed wheel"
            txtWheelNumber.Text = ""
            txtHeatNumber.Text = ""
            Exit Sub
        End If
        Dim dInspDate As Date
        Dim sInspShift As String
        Dim dBoreInspDate As Date = CDate(txtDate.Text)
        Dim sBoreInspShift As String = rblShift.SelectedItem.Value
        If strPassLocation = "CLFI" Then
            dt = RWF.CLRINS.getInspDateShift(dInspDate, sInspShift, "mm_final_inspection", Val(txtWheelNumber.Text), Val(txtHeatNumber.Text))
            dInspDate = IIf(IsDBNull(dt.Rows(0)("Inspection_Date")), #1/1/1900#, dt.Rows(0)("Inspection_Date"))
            sInspShift = IIf(IsDBNull(dt.Rows(0)("Shift_Code")), "", dt.Rows(0)("Shift_code"))
        End If
        If strPassLocation = "CLQC" Then
            dt = RWF.CLRINS.getInspDateShift(dInspDate, sInspShift, "mm_yard_inspection", Val(txtWheelNumber.Text), Val(txtHeatNumber.Text))
            dInspDate = IIf(IsDBNull(dt.Rows(0)("Yard_Inspection_Date")), #1/1/1900#, dt.Rows(0)("Yard_Inspection_Date"))
            sInspShift = IIf(IsDBNull(dt.Rows(0)("Shift_Code")), "", dt.Rows(0)("Shift_code"))
        End If
        If dInspDate > dBoreInspDate Then
            lblMessage.Text = "UnBore Passed on : " & Format(dInspDate, "dd/MM/yyyy")
            txtWheelNumber.Text = ""
            txtHeatNumber.Text = ""
            Exit Sub
        ElseIf dInspDate = dBoreInspDate Then
            If sInspShift > sBoreInspShift Then
                lblMessage.Text = "UnBore Passed on : " & Format(dInspDate, "dd/MM/yyyy") & " " & sInspShift
                txtWheelNumber.Text = ""
                txtHeatNumber.Text = ""
                Exit Sub
            End If
        End If
        Try
            If txtWheelNumber.Text <> "" And txtHeatNumber.Text <> "" Then
                dt = RWF.CLRINS.LastInsp(txtWheelNumber.Text, txtHeatNumber.Text)
                dgLastInsp.DataSource = dt
            Else
                dgLastInsp.DataSource = Nothing
            End If
            dgLastInsp.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
            dt = Nothing
        End Try
        showWheelHistory()
        dInspDate = Nothing
        sInspShift = Nothing
        dBoreInspDate = Nothing
        sBoreInspShift = Nothing
    End Sub

    Private Sub ClearGrid()
        dgMasterHistory.DataSource = Nothing
        dgMasterHistory.DataBind()
        dgMagHistory.DataSource = Nothing
        dgMagHistory.DataBind()
        dgFIHistory.DataSource = Nothing
        dgFIHistory.DataBind()
        dgYIHistory.DataSource = Nothing
        dgYIHistory.DataBind()
        dgQChistory.DataSource = Nothing
        dgQChistory.DataBind()
        dgWhlLoadHistory.DataSource = Nothing
        dgWhlLoadHistory.DataBind()
        dgPressHistory.DataSource = Nothing
        dgPressHistory.DataBind()
        dgDespHistory.DataSource = Nothing
        dgDespHistory.DataBind()
    End Sub

    Private Sub showWheelHistory()
        ClearGrid()
        Dim ds As New DataSet()
        Dim dvMaster As New DataView()
        Dim dvMag As New DataView()
        Dim dvFI As New DataView()
        Dim dvYI As New DataView()
        Dim dvqc As New DataView()
        Dim dvWhlLoad As New DataView()
        Dim dvPress As New DataView()
        Dim dvDesp As New DataView()
        Try
            ds = RWF.CLRINS.getBriefHistory(Val(txtWheelNumber.Text), Val(txtHeatNumber.Text))
            If ds.Tables(0).Rows(0)("Bore") <> -1 Then
                txtBoreDia.Text = ds.Tables(0).Rows(0)("Bore")
            Else
                txtBoreDia.Text = CDec(Val(txtBoreDia.Text))
            End If
            dvMaster.Table = ds.Tables(0)
            dvMag.Table = ds.Tables(1)
            dvFI.Table = ds.Tables(2)
            dvYI.Table = ds.Tables(3)
            dvqc.Table = ds.Tables(4)
            dvWhlLoad.Table = ds.Tables(5)
            dvPress.Table = ds.Tables(6)
            dvDesp.Table = ds.Tables(7)
            dgMasterHistory.DataSource = dvMaster
            dgMasterHistory.DataBind()
            dgMagHistory.DataSource = dvMag
            dgMagHistory.DataBind()
            dgFIHistory.DataSource = dvFI
            dgFIHistory.DataBind()
            dgYIHistory.DataSource = dvYI
            dgYIHistory.DataBind()
            dgQChistory.DataSource = dvqc
            dgQChistory.DataBind()
            dgWhlLoadHistory.DataSource = dvWhlLoad
            dgWhlLoadHistory.DataBind()
            dgPressHistory.DataSource = dvPress
            dgPressHistory.DataBind()
            dgDespHistory.DataSource = dvDesp
            dgDespHistory.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            ds.Dispose()
            ds = Nothing
        End Try

        dvMaster = Nothing
        dvMag = Nothing
        dvFI = Nothing
        dvYI = Nothing
        dvqc = Nothing
        dvWhlLoad = Nothing
        dvPress = Nothing
        dvDesp = Nothing
    End Sub

    Private Sub txtHeatNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHeatNumber.TextChanged
        lblMessage.Text = ""
        Try
            CheckWheel()
            SetFocus(txtBoreDia)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub CheckWheel()
        If Val(txtHeatNumber.Text) < 0 Then
            lblMessage.Text = "Heat Number to be more >= 0"
            txtWheelNumber.Text = ""
            txtHeatNumber.Text = ""
            Exit Sub
        ElseIf Val(txtHeatNumber.Text) = 0 Then
            If Val(txtWheelNumber.Text) >= 100000 Then
            Else
                lblMessage.Text = "Wheel Number Invalid : " & txtWheelNumber.Text + "/" + txtHeatNumber.Text
                txtWheelNumber.Text = ""
                txtHeatNumber.Text = ""
                Exit Sub
            End If
        End If
        DispWheelStatus()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        btnSave.Text = "Save"
        txtWheelNumber.Text = ""
        txtHeatNumber.Text = ""
        txtBoreDia.Text = ""
        txtRemarks.Text = ""
        chkBoreWheel.Checked = False
        lblMessage.Text = ""
        btnSave.BackColor = System.Drawing.SystemColors.Control
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If RWF.CLRINS.BoreDiaCheck(Val(txtWheelNumber.Text), Val(txtHeatNumber.Text), CDec(txtBoreDia.Text)) Then
            If CDec(txtBoreDia.Text) < 1 Then
                lblMessage.Text &= "Illogical Data : Cannot save"
                Exit Sub
            End If
            If txtWheelNumber.Text = "" Then
                lblMessage.Text = ". Expected wheel for saving...!"
                Exit Sub
            End If
            If Val(txtWheelNumber.Text) <= 100000 And Val(txtHeatNumber.Text) <= 0 Then
                lblMessage.Text &= ". Expected wheel for saving...!"
                Exit Sub
            End If
            If txtWheelNumber.Text.IndexOf("/") >= 0 Then
                lblMessage.Text &= ". Enter Heat Number separately"
                Exit Sub
            End If
            btnSave.BackColor = System.Drawing.SystemColors.ControlLightLight
            btnSave.Text = "Not Saved"
            If CDec(txtBoreDia.Text) = 0 And IIf(chkBoreWheel.Checked, "UnBore", "B") = "B" Then
                lblMessage.Text &= "Illogical Data : Cannot save"
                Exit Sub
            End If
            If CDec(txtBoreDia.Text) > 0 And IIf(chkBoreWheel.Checked, "UnBore", "B") <> "B" Then
                lblMessage.Text &= ". Illogical Data : Cannot save ; Kindly Check MinBoreDia and OverSizeMax values for this product in Wheel parameters screen !"
                Exit Sub
            End If
            Dim bore As Decimal = CDec(txtBoreDia.Text)
            Try
                lblMessage.Text = New RWF.CLRINS().Save(Val(txtWheelNumber.Text), Val(txtHeatNumber.Text), txtInspector.Text.Trim, chkBoreWheel.Checked, CDate(txtDate.Text), rblShift.SelectedItem.Text, bore, txtRemarks.Text.Trim)
                btnSave.Text = "Saved"
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            Try
                populateGrid()
                btnSave.BackColor = System.Drawing.SystemColors.Control
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        Else
            lblMessage.Text &= ". Illogical Data : Cannot save"
        End If
    End Sub

End Class
