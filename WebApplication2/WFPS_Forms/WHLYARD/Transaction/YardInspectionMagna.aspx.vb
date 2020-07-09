Public Class YardInspectionMagna
    Inherits System.Web.UI.Page
    Protected WithEvents lblMode As System.Web.UI.WebControls.Label
    Protected WithEvents rfvTechInsp As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtTechnicalAuthority As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblLabAuthority As System.Web.UI.WebControls.Label
    Protected WithEvents lblShift As System.Web.UI.WebControls.Label
    Protected WithEvents rfvDate As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtWheelNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfvWhlNum As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents rfvHtNum As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtHeatNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblLoca As System.Web.UI.WebControls.Label
    Protected WithEvents lblStatus As System.Web.UI.WebControls.Label
    Protected WithEvents txtWheelDisposition As System.Web.UI.WebControls.TextBox
    Protected WithEvents chkReMachine As System.Web.UI.WebControls.CheckBox
    Protected WithEvents txtBHN As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBdNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTreadDiameter As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBorestatus As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPlateThickness As System.Web.UI.WebControls.TextBox
    Protected WithEvents chkAllowStockWheel As System.Web.UI.WebControls.CheckBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents btnClear As System.Web.UI.WebControls.Button
    Protected WithEvents btnDelete As System.Web.UI.WebControls.Button
    Protected WithEvents btnExit As System.Web.UI.WebControls.Button
    Protected WithEvents grdYard As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    'new
    Protected WithEvents txtmr As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtsms As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtwfps As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtautech As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtjicstatus As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtjicremark As System.Web.UI.WebControls.TextBox


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
        Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None
        'Put user code to initialize the page here
        If IsPostBack = False Then
            'Session("Group") = "CLRQCI"
            'Session("UserID") = "076697"
            'Session("Group") = "WHLYARD"
            'Session("UserID") = "111111"
            Try
                'If Session("Group") <> "WHLYARD" Then
                '    'Response.Redirect("/mms/InvalidSession.aspx")
                '    Response.Redirect("InvalidSession.aspx")
                '    Exit Sub
                'End If
                'If Session("UserID") = "" Then
                '    'Response.Redirect("/mms/InvalidSession.aspx")
                '    Response.Redirect("InvalidSession.aspx")
                '    Exit Sub
                'End If
                lblLabAuthority.Text = Session("UserID")
            Catch exp As Exception
                'Response.Redirect("/mms/InvalidSession.aspx")
                Response.Redirect("InvalidSession.aspx")
                Exit Sub
            End Try
            txtTreadDiameter.ReadOnly = True
            txtBorestatus.ReadOnly = True
            txtPlateThickness.ReadOnly = True
            chkAllowStockWheel.Visible = False
            lblMode.Text = "Add/Delete"
            txtWheelDisposition.Text = ""
            btnSave.Text = "SY_"
            Dim dt As Date = Date.Today
            txtDate.Text = Format(dt, "dd/MM/yyyy")

            grdYard.Visible = False
            CheckDate()
            rfEnable()
            dt = Nothing
        End If
    End Sub
    Private Sub rfEnable()
        rfvHtNum.Enabled = True
        rfvWhlNum.Enabled = True
        rfvDate.Enabled = True
        rfvTechInsp.Enabled = True
    End Sub
    Private Sub rfDisable()
        rfvHtNum.Enabled = False
        rfvWhlNum.Enabled = False
        rfvDate.Enabled = False
        rfvTechInsp.Enabled = False
    End Sub
    Private Sub CheckDate()
        Try
            Dim intcount As Integer = RWF.CLRINS.ValidDate(CDate(txtDate.Text))
            If intcount > 0 Then
                btnSave.Enabled = False
                lblMessage.Text = "You Can Not Add or Edit the Data for the date For Which Pink Sheet Already Generated"
            Else
                btnSave.Enabled = True
            End If
            intcount = Nothing
        Catch exp As Exception
            lblMessage.Text = exp.Message
            txtDate.Text = ""
        End Try
        If txtDate.Text = "" Then
            grdYard.Visible = False
            Exit Sub
        Else
            populategrid()
        End If
    End Sub
    Private Sub populategrid()
        Try
            grdYard.DataSource = RWF.CLRINS.YardWheels(CDate(txtDate.Text))
            grdYard.DataBind()
            grdYard.Visible = True
        Catch exp As Exception
            lblMessage.Text = exp.Message
            grdYard.Visible = False
        End Try
    End Sub
    Private Sub Clear(Optional ByVal ClearMessage As Boolean = True)
        If ClearMessage Then lblMessage.Text = ""
        lblLoca.Text = ""
        lblStatus.Text = ""
        txtHeatNumber.Text = ""
        txtWheelNumber.Text = ""
        txtPlateThickness.Text = "OK"
        txtBHN.Text = ""
        txtBorestatus.Text = "OK"
        txtTreadDiameter.Text = ""
        txtWheelDisposition.Text = ""
        btnSave.Text = "SY_"
    End Sub
    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        lblMessage.Text = ""
        Try
            CheckDate()
            If txtDate.Text <> "" Then
                populategrid()
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Clear()
    End Sub

    Private Sub txtWheelNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWheelNumber.TextChanged
        txtBHN.Enabled = Val(txtBHN.Text) <= 0
        lblMessage.Text = ""
        lblLoca.Text = ""
        lblStatus.Text = ""
        txtHeatNumber.Text = ""
        txtPlateThickness.Text = "OK"
        txtBHN.Text = "0"
        txtBorestatus.Text = "OK"
    End Sub

    Private Sub txtHeatNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHeatNumber.TextChanged
        lblMessage.Text = ""
        If txtDate.Text = "" Then
            txtWheelNumber.Text = ""
            txtHeatNumber.Text = ""
            lblMessage.Text = "Input Date first"
            Exit Sub
        ElseIf txtWheelNumber.Text = "" Then
            lblMessage.Text = "Enter the wheel number"
            Exit Sub
        ElseIf txtHeatNumber.Text = "" Then
            lblMessage.Text = "Enter the heat number"
            Exit Sub
        End If
        txtBHN.Enabled = Val(txtBHN.Text) <= 0
        txtTreadDiameter.ReadOnly = txtWheelNumber.Text = "" Or txtHeatNumber.Text = ""
        txtBorestatus.ReadOnly = txtWheelNumber.Text = "" Or txtHeatNumber.Text = ""
        txtPlateThickness.ReadOnly = txtWheelNumber.Text = "" Or txtHeatNumber.Text = ""
        If txtWheelNumber.Text <> "" Then
            checkwheel()
        End If
        ' enable delete button
        If txtWheelNumber.Text <> "" Then
            Dim dt As DataTable
            Try
                dt = RWF.CLRINS.YardWheelDetails(Val(txtWheelNumber.Text), Val(txtHeatNumber.Text))
                If dt.Rows.Count > 0 Then
                    btnDelete.Enabled = True
                    btnSave.Enabled = False
                    lblMessage.Text = "Delete button is enabled to delete as wheel is already in " &
                    " Yard Inspection Magna on " & dt.Rows(0)(0) & " at '" & dt.Rows(0)(2) & "' "
                Else
                    btnDelete.Enabled = False
                End If
            Catch exp As Exception
                lblMessage.Text = exp.Message
                btnDelete.Enabled = False
            End Try
            dt = Nothing
        End If
    End Sub
    Private Sub checkwheel()
        Dim sqlStatus, whlLoc, whlMasterSta, whlMcnSta, whlStatus As String
        Dim dt As DataTable
        Try
            dt = RWF.CLRINS.YardWheelStatus(Val(txtWheelNumber.Text.Trim), Val(txtHeatNumber.Text.Trim))
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt.Rows(0)("sts")) = False Then
                    whlStatus = dt.Rows(0)("sts")
                Else
                    whlStatus = ""
                End If
                lblLoca.Text = dt.Rows(0)("loc") & ""
                lblStatus.Text = dt.Rows(0)("mcnsts") & ""
                whlMcnSta = dt.Rows(0)("masterSts") & ""
                If IsDBNull(dt.Rows(0)("BHN")) = False Then
                    txtBHN.Text = dt.Rows(0)("BHN")
                Else
                    txtBHN.Text = ""
                End If
                If IsDBNull(dt.Rows(0)("TreDia")) = False Then
                    txtTreadDiameter.Text = dt.Rows(0)("TreDia")
                Else
                    txtTreadDiameter.Text = ""
                End If
                txtPlateThickness.Text = dt.Rows(0)("PlaTh") & ""
                txtBorestatus.Text = dt.Rows(0)("BoSta") & ""
                If txtPlateThickness.Text = "" Then txtPlateThickness.Text = "OK"
                If txtBorestatus.Text = "" Then txtBorestatus.Text = "OK"
            Else
                lblMessage.Text = "InValid Wheel !"
            End If
        Catch exp As Exception
            txtWheelNumber.Text = ""
            txtHeatNumber.Text = ""
            lblMessage.Text = exp.Message
        End Try
        If txtWheelNumber.Text = "" Then
            Exit Sub
        End If
        Select Case whlStatus
            Case 1
                lblMessage.Text = " Already Passed " & txtWheelNumber.Text.Trim & "/" & txtHeatNumber.Text.Trim
                If RWF.CLRINS.WaitingForVerfication(Val(txtWheelNumber.Text.Trim), Val(txtHeatNumber.Text.Trim)) Then
                    btnSave.Enabled = False
                    lblMessage.Text &= "Please Delete this wheel."
                Else
                    Clear(False)
                End If
            Case 2
                lblMessage.Text = " Already Rejected  " & txtWheelNumber.Text.Trim & "/" & txtHeatNumber.Text.Trim
                If RWF.CLRINS.WaitingForVerfication(Val(txtWheelNumber.Text.Trim), Val(txtHeatNumber.Text.Trim)) Then
                    btnSave.Enabled = False
                    lblMessage.Text &= "Please Delete this wheel."
                Else
                    Clear(False)
                End If
            Case 3
                lblMessage.Text = " Not Plate Passed " & txtWheelNumber.Text.Trim & "/" & txtHeatNumber.Text.Trim
                Try
                    Dim stockwheel As Integer = RWF.CLRINS.stockwheelVerfication(CLng(txtWheelNumber.Text), CLng(txtHeatNumber.Text))
                    If IsDBNull(stockwheel) OrElse IsNothing(stockwheel) Then stockwheel = 0
                    If stockwheel > 0 Then
                        lblMessage.Text = "Stocked Wheel. Verify wheel & heat number and check allow stock wheel to save"
                        chkAllowStockWheel.Visible = True
                        btnSave.Enabled = False
                    Else
                        btnSave.Enabled = True
                    End If
                    stockwheel = Nothing
                Catch exp1 As Exception
                    lblMessage.Text = exp1.Message
                    btnSave.Enabled = False
                End Try
                If btnSave.Enabled Then Clear(False)
            Case 4
                lblMessage.Text = "Stocked Wheel. Verify wheel & heat number and check allow stock wheel to save"
                chkAllowStockWheel.Visible = True
                btnSave.Enabled = False
            Case -1
                lblMessage.Text = " InValid Wheel " & txtWheelNumber.Text.Trim & "/" & txtHeatNumber.Text.Trim
                Clear(False)
            Case Else
                If lblLoca.Text.ToUpper.Trim = "CLMT" Then
                    Try
                        Dim PendVerification As String
                        PendVerification = RWF.CLRINS.PendVerification(Val(txtWheelNumber.Text.Trim), Val(txtHeatNumber.Text.Trim))
                        If IsDBNull(PendVerification) = False AndAlso PendVerification <> "" Then
                            lblMessage.Text = PendVerification
                        Else
                            Dim stockwheel As Integer = RWF.CLRINS.stockwheelVerfication(CLng(txtWheelNumber.Text), CLng(txtHeatNumber.Text))
                            If IsDBNull(stockwheel) OrElse IsNothing(stockwheel) Then stockwheel = 0
                            If stockwheel > 0 Then
                                lblMessage.Text = "Stocked Wheel. Verify wheel & heat number and check allow stock wheel to save"
                                chkAllowStockWheel.Visible = True
                                btnSave.Enabled = False
                            Else
                                btnSave.Enabled = True
                            End If
                        End If
                        PendVerification = Nothing
                    Catch exp As Exception
                        lblMessage.Text = exp.Message
                        txtWheelNumber.Text = ""
                        txtHeatNumber.Text = ""
                    End Try
                Else
                    lblMessage.Text = ""
                    ' store latest magna yard wheeldisposition in txtwheeldisposition.text
                    Try
                        Dim latestStatusInYard As String
                        latestStatusInYard = RWF.CLRINS.MagnaDisposition(CLng(txtWheelNumber.Text), CLng(txtHeatNumber.Text))
                        If IsDBNull(latestStatusInYard) = False AndAlso latestStatusInYard <> "" Then
                            txtWheelDisposition.Text = latestStatusInYard
                            If txtWheelDisposition.Text = "" Then
                                btnSave.Text = "SY_"
                            Else
                                Dim YardWhlRej As New YardInsp.Rejection()
                                YardWhlRej.WheelStatus = txtWheelDisposition.Text
                                lblMessage.Text = YardWhlRej.Message
                                txtWheelDisposition.Text = YardWhlRej.WheelStatus
                                If txtWheelDisposition.Text = "" Then
                                    btnSave.Text = "SY_"
                                Else
                                    btnSave.Text = txtWheelDisposition.Text.ToUpper.Trim
                                End If
                                YardWhlRej = Nothing
                            End If
                        End If
                        latestStatusInYard = Nothing
                    Catch exp As Exception
                        lblMessage.Text = exp.Message
                        txtWheelNumber.Text = ""
                        txtHeatNumber.Text = ""
                    End Try
                End If
        End Select
        sqlStatus = Nothing
        whlLoc = Nothing
        whlMasterSta = Nothing
        whlMcnSta = Nothing
        whlStatus = Nothing
        dt = Nothing
    End Sub

    Private Sub txtBHN_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBHN.TextChanged
        lblMessage.Text = ""
        Try
            If Not RWF.CLRINS.CheckBHN(Val(txtBHN.Text), CLng(txtWheelNumber.Text), CLng(txtHeatNumber.Text)) Then
                lblMessage.Text &= " BHN out of range"
            Else
                lblMessage.Text.Replace(" BHN out of range", "")
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtWheelDisposition_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWheelDisposition.TextChanged
        If txtWheelDisposition.Text = "" Then
            btnSave.Text = "SY_"
        Else
            Dim YardWhlRej As New YardInsp.Rejection()
            YardWhlRej.WheelStatus = txtWheelDisposition.Text
            lblMessage.Text = YardWhlRej.Message
            txtWheelDisposition.Text = YardWhlRej.WheelStatus
            If txtWheelDisposition.Text = "" Then
                btnSave.Text = "SY_"
            Else
                btnSave.Text = txtWheelDisposition.Text.ToUpper.Trim
            End If
            YardWhlRej = Nothing
        End If
    End Sub

    Private Sub txtTechnicalAuthority_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTechnicalAuthority.TextChanged
        lblMessage.Text = ""
        Dim i As Integer
        Try
            i = RWF.CLRINS.CheckEmp(txtTechnicalAuthority.Text.Trim)
            If IsNothing(i) OrElse IsDBNull(i) Then
                i = 0
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
            i = 0
        End Try
        If i = 0 Then
            lblMessage.Text = "Invalid Technical Employee code : " & txtTechnicalAuthority.Text
            txtTechnicalAuthority.Text = ""
        Else
            lblMessage.Text = ""
        End If
        i = Nothing
    End Sub

    Private Sub chkReMachine_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkReMachine.CheckedChanged
        If chkReMachine.Checked Then
            txtWheelDisposition.Text = ""
            If lblStatus.Text.EndsWith("/P") = True Then
                btnSave.Text = "W" & lblStatus.Text
            Else
                lblMessage.Text = "No Rework found for wheel : " & txtWheelNumber.Text & "/" & txtHeatNumber.Text
                txtWheelNumber.Text = ""
                txtHeatNumber.Text = ""
                txtWheelDisposition.Text = ""
                btnSave.Text = "SY_"
            End If
        Else
            If txtWheelDisposition.Text <> "" Then
                btnSave.Text = txtWheelDisposition.Text
            Else
                btnSave.Text = "SY_"
            End If
        End If
    End Sub

    Private Sub chkAllowStockWheel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAllowStockWheel.CheckedChanged
        btnSave.Enabled = chkAllowStockWheel.Checked
    End Sub

    Private Sub txtTreadDiameter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTreadDiameter.TextChanged
        lblMessage.Text = ""
        Dim sProdCode As String
        Dim minTd, MaxTd, givenTd As Decimal
        Dim dt As DataTable
        Try
            givenTd = CDec(txtTreadDiameter.Text)
            sProdCode = RWF.CLRINS.CheckProdCode(Val(txtTreadDiameter), CLng(txtWheelNumber.Text), CLng(txtHeatNumber.Text))
            If sProdCode.Trim = "" Then
                Exit Sub
            Else
                dt = RWF.CLRINS.TreadDia(sProdCode)
                If dt.Rows.Count > 0 Then
                    MaxTd = dt.Rows(0)(1)
                    minTd = dt.Rows(0)(0)
                End If
            End If
            givenTd = IIf(givenTd < 10, givenTd + 1000, givenTd)
            If givenTd < minTd OrElse givenTd > MaxTd Then
                lblMessage.Text = "Tread Dia " & givenTd.ToString & " not between " & minTd.ToString & " and " & MaxTd.ToString
                txtTreadDiameter.Text = ""
            Else
                lblMessage.Text = ""
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        dt = Nothing
        sProdCode = Nothing
        minTd = Nothing
        MaxTd = Nothing
        givenTd = Nothing
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        Dim done As Boolean
        Try
            done = New RWF.CLRINS().SaveYardWheelMagna(Val(txtWheelNumber.Text), Val(txtHeatNumber.Text), CDate(txtDate.Text), lblShift.Text, txtTechnicalAuthority.Text.Trim, txtBdNo.Text, lblStatus.Text, lblLoca.Text, lblLabAuthority.Text, btnSave.Text, Val(txtBHN.Text), Val(txtTreadDiameter.Text), txtBorestatus.Text.Trim, Val(txtPlateThickness.Text), Val(txtmr.Text), Val(txtsms.Text), Val(txtwfps.Text), Val(txtautech.Text), Val(txtjicstatus.Text), Val(txtjicremark.Text))
            If done Then
                chkAllowStockWheel.Checked = False
                lblMessage.Text = "Record Saved"
                populategrid()
            Else
                lblMessage.Text = "could not save the record"
            End If
            Clear(False)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        done = Nothing
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        lblMessage.Text = ""
        Dim done As Boolean
        Try
            done = New RWF.CLRINS().DeleteYardWheel(Val(txtWheelNumber.Text), Val(txtHeatNumber.Text))
            If done Then
                lblMessage.Text = "Not deleted"
            Else
                lblMessage.Text = "Deleted"
                populategrid()
                Clear(False)
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        done = Nothing
    End Sub
End Class
