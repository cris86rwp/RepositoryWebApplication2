Public Class YardInspectionFinal
    Inherits System.Web.UI.Page
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents ddlRej As System.Web.UI.WebControls.DropDownList
    Protected WithEvents rdoDisposition As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtHeatNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents dgVerify As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblFinalInsp As System.Web.UI.WebControls.Label
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents lblDisposition As System.Web.UI.WebControls.Label
    Protected WithEvents lblCode As System.Web.UI.WebControls.Label
    Protected WithEvents lblTreadDia As System.Web.UI.WebControls.Label
    Protected WithEvents lblBoreSts As System.Web.UI.WebControls.Label
    Protected WithEvents lblPlateSts As System.Web.UI.WebControls.Label
    Protected WithEvents lblminTD As System.Web.UI.WebControls.Label
    Protected WithEvents lblMaxTD As System.Web.UI.WebControls.Label
    Protected WithEvents txtTreaddia As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblhdTreadDia As System.Web.UI.WebControls.Label
    Protected WithEvents lblhdBoreStatus As System.Web.UI.WebControls.Label
    Protected WithEvents lblhdPlateStatus As System.Web.UI.WebControls.Label
    Protected WithEvents txtBoreSts As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPlateSts As System.Web.UI.WebControls.TextBox
    Protected WithEvents chkXCWheels As System.Web.UI.WebControls.CheckBox
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblMagDisposition As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents pnlhelp As System.Web.UI.WebControls.Panel
    Protected WithEvents CheckBox1 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkReInspect As System.Web.UI.WebControls.CheckBox
    Protected WithEvents lstWheelsForVerfiy As System.Web.UI.WebControls.ListBox
    Protected WithEvents lblBoreDia As System.Web.UI.WebControls.Label
    Protected WithEvents txtBoreDia As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblSaveMessage As System.Web.UI.WebControls.Label
    Protected WithEvents ddlGridOption As System.Web.UI.WebControls.DropDownList
    Protected WithEvents dgYardInsp As System.Web.UI.WebControls.DataGrid
    Protected WithEvents ddlRew As System.Web.UI.WebControls.DropDownList
    Protected WithEvents chkRLPTWheels As System.Web.UI.WebControls.CheckBox
    Protected WithEvents txtWheelNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    '
    Protected WithEvents txt1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txt2 As System.Web.UI.WebControls.TextBox

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
        If Page.IsPostBack = False Then
            Try
                pnlhelp.Visible = False
                'Session("UserID") = "078887"
                'Session("Group") = "CLRINS"
                Session("Group") = "SSINSP"
                Session("UserID") = "071811"
                If Session("Group") <> "SSINSP" Then
                    'Response.Redirect("/mms/InvalidSession.aspx")
                    Response.Redirect("InvalidSession.aspx")
                    Exit Sub
                End If
                lblFinalInsp.Text = CStr(Session("UserID"))
                If lblFinalInsp.Text = "" Then
                    'Response.Redirect("/mms/InvalidSession.aspx")
                    Response.Redirect("InvalidSession.aspx")
                    Exit Sub
                End If
                lblCode.Visible = False
                lblTreadDia.Visible = False
                lblBoreSts.Visible = False
                lblPlateSts.Visible = False
                lblMaxTD.Visible = False
                lblminTD.Visible = False
            Catch exp As Exception
                If lblFinalInsp.Text = "" Then
                    'Response.Redirect("/mms/InvalidSession.aspx")
                    Response.Redirect("InvalidSession.aspx")
                    Exit Sub
                End If
            End Try
            Try
                getreworkcodes()
                getrejcodes()
                ReListWheels(chkXCWheels.Checked)
                populateGrid()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
    Private Sub populateGrid(Optional ByVal SavedData As Boolean = True)
        Dim dt As New DataTable()
        Try
            dt = RWF.CLRINS.YardInspData(SavedData)
            dgYardInsp.DataSource = dt
            dgYardInsp.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message & " : show after save error. Contact MIS Center"
        Finally
            If Not IsNothing(dt) Then dt.Dispose()
            dt = Nothing
        End Try
    End Sub
    Private Sub CheckWheel()
        Dim dt As New DataTable()
        Try
            dt = RWF.CLRINS.YardInspectedWhl(txtWheelNumber.Text, txtHeatNumber.Text)
            lblTreadDia.Text = dt.Rows(0)("@Thread_Diameter")
            lblBoreSts.Text = dt.Rows(0)("@Bore_Status")
            lblPlateSts.Text = dt.Rows(0)("@Plate_status")
        Catch exp As Exception
            lblTreadDia.Text = ""
            lblBoreSts.Text = ""
            lblPlateSts.Text = ""
            lblMessage.Text = exp.Message & " : " & txtWheelNumber.Text & "/" & txtHeatNumber.Text
        Finally
            dt.Dispose()
            dt = Nothing
        End Try
    End Sub
    Private Sub getreworkcodes()
        Dim dt As New DataTable()
        Try
            dt = RWF.CLRINS.YardRew
            ddlRew.DataSource = dt
            ddlRew.DataTextField = dt.Columns("mctype_desc").ColumnName
            ddlRew.DataValueField = dt.Columns("mcn_type").ColumnName
            ddlRew.DataBind()
            ddlRew.Items.Insert(0, "Select")
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
            dt = Nothing
        End Try
    End Sub
    Private Sub getrejcodes()
        Dim dt As New DataTable()
        Try
            dt = RWF.CLRINS.YardRej
            ddlRej.DataSource = dt
            ddlRej.DataTextField = dt.Columns("rjtype_desc").ColumnName
            ddlRej.DataValueField = dt.Columns("rej_code").ColumnName
            ddlRej.DataBind()
            ddlRej.Items.Insert(0, "Select")
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
            dt = Nothing
        End Try
    End Sub

    Private Sub rdoDisposition_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoDisposition.SelectedIndexChanged
        Select Case rdoDisposition.SelectedItem.Value
            Case "P"
                ddlRej.Visible = False
                ddlRew.Visible = False
                If chkReInspect.Checked = True Then
                    updateReInspStsInGrid()
                Else
                    updatePassInGrid()
                End If
                lblCode.Visible = False
            Case "W"
                ddlRew.Visible = True
                ddlRej.Visible = False
                lblCode.Visible = True
            Case "R"
                ddlRew.Visible = False
                ddlRej.Visible = True
                lblCode.Visible = True
            Case Else
                lblCode.Visible = False
                btnSave.Enabled = False
                ddlRej.Visible = False
                ddlRew.Visible = False
                Clear(False)
        End Select
    End Sub
    Private Sub updatePassInGrid()
        Try
            If New RWF.CLRINS().updatePassInGrid(CLng(txtWheelNumber.Text), CLng(txtHeatNumber.Text)) > 0 Then
                lblMessage.Text = "Updated grid"
            Else
                lblMessage.Text = "Update grid failed"
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            getdata(txtWheelNumber.Text & "/" & txtHeatNumber.Text)
        End Try
    End Sub
    Private Sub Clear(Optional ByVal ClearMessage As Boolean = True)
        If ClearMessage Then lblMessage.Text = ""
        txtWheelNumber.Text = ""
        txtHeatNumber.Text = ""
        txtBoreDia.Text = "0.0"
        txtBoreSts.Text = "B"
        rdoDisposition.ClearSelection()
        ReListWheels(chkXCWheels.Checked, chkReInspect.Checked)
    End Sub
    Private Sub ReListWheels(Optional ByVal XcWheels As Boolean = False, Optional ByVal ReInspWheels As Boolean = False, Optional ByVal FIRejWheels As Boolean = False) ' by default all wheels will be listed
        Dim dt As DataTable
        Try
            dt = RWF.CLRINS.ReListWheels(XcWheels, ReInspWheels, FIRejWheels)
            lstWheelsForVerfiy.DataSource = dt
            lstWheelsForVerfiy.DataTextField = dt.Columns(0).ColumnName
            lstWheelsForVerfiy.DataValueField = dt.Columns(1).ColumnName
            lstWheelsForVerfiy.DataBind()
            If lstWheelsForVerfiy.Items.Count > 0 Then
                txtWheelNumber.Enabled = True
                txtHeatNumber.Enabled = True
            End If
        Catch exp As Exception
            lstWheelsForVerfiy.Visible = False
            lblMessage.Text = exp.Message
            txtWheelNumber.Enabled = False
            txtHeatNumber.Enabled = False
            btnSave.Enabled = False
        Finally
            dt.Dispose()
            dt = Nothing
        End Try
    End Sub

    Private Sub lstWheelsForVerfiy_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstWheelsForVerfiy.SelectedIndexChanged
        lblMessage.Text = ""
        Dim whlstr As String = lstWheelsForVerfiy.SelectedItem.Text
        Dim whlarr() As String = whlstr.Split("/")
        txtWheelNumber.Text = whlarr(0)
        txtHeatNumber.Text = whlarr(1)
        getdata(lstWheelsForVerfiy.SelectedItem.Text, chkReInspect.Checked)
        If lblMessage.Text = "" Then
            getTreadDiaBoundary(getwheeltype())
        End If
        whlstr = Nothing
        whlarr = Nothing
    End Sub
    Private Sub getdata(ByVal wheel As String, Optional ByVal ReInspWheel As Boolean = False)
        Dim dt As New DataTable()
        Try
            dt = RWF.CLRINS.YardWhlDetails(wheel, ReInspWheel)
            Dim row As DataRow
            For Each row In dt.Rows
                txtTreaddia.Text = IIf(IsDBNull(row("treaddia")), 0.0, row("treaddia"))
                txtBoreSts.Text = IIf(IsDBNull(row("borests")), "", row("borests"))
                txtPlateSts.Text = IIf(IsDBNull(row("PlateSts")), "", row("PlateSts"))
                lblMagDisposition.Text = IIf(IsDBNull(row("MagnaDisposition")), "", row("MagnaDisposition"))
            Next
            dgVerify.DataSource = dt.DefaultView
            dgVerify.DataBind()
            dgVerify.Visible = True
            Dim dr As DataRow
            For Each dr In dt.Rows
                If CStr(dr("disposition")).StartsWith("XC") Or CStr(dr("MagnaDisposition")).StartsWith("W") Then
                    rdoDisposition.Visible = False
                    lblCode.Visible = False
                    ddlRej.Visible = False
                    ddlRew.Visible = False
                    lblDisposition.Visible = False
                Else
                    lblDisposition.Visible = True
                    rdoDisposition.Visible = True
                    lblCode.Visible = True
                End If
            Next
            dr = Nothing
            row = Nothing
        Catch exp As Exception
            lblMessage.Text = exp.Message
            dgVerify.Visible = False
        Finally
            dt.Dispose()
            dt = Nothing
        End Try
        If lblMagDisposition.Text.ToLower.StartsWith("xc") = True Then
            txtBoreSts.Text = ""
            txtTreaddia.Text = 0
            txtPlateSts.Text = ""
            txtBoreSts.ReadOnly = True
            txtTreaddia.ReadOnly = True
            txtPlateSts.ReadOnly = True
        Else
            txtBoreSts.ReadOnly = False
            txtTreaddia.ReadOnly = False
            txtPlateSts.ReadOnly = False
        End If
    End Sub

    Private Sub txtWheelNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWheelNumber.TextChanged
        lblMessage.Text = ""
        dgVerify.Visible = False
        txtHeatNumber.Text = ""
        lblMessage.Text = "Please input heat number"
    End Sub

    Private Sub txtHeatNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHeatNumber.TextChanged
        lblMessage.Text = ""
        dgVerify.Visible = False
        If txtWheelNumber.Text = "" Then
            lblMessage.Text = "Please input wheel number"
            Exit Sub
        End If
        If txtWheelNumber.Text <> "" AndAlso txtHeatNumber.Text <> "" Then
            getdata(txtWheelNumber.Text & "/" & txtHeatNumber.Text, chkReInspect.Checked)
            dgVerify.Visible = True
            getTreadDiaBoundary(getwheeltype())
        End If
        Dim i As Integer = dgVerify.Items.Count
        Dim j As Integer
        If i = 0 Then
            Dim dt As New DataTable()
            Try
                dt = RWF.CLRINS.YardWhlLocation(txtWheelNumber.Text, txtHeatNumber.Text)
                If dt.Rows.Count > 0 Then
                    lblMessage.Text = " Location : " & dt.Rows(0)("Location") & " Status : " & dt.Rows(0)("status") & " TD: " & dt.Rows(0)("Thread_diameter") & " Bore: " & dt.Rows(0)("Bore_Status") & " B.Dia: " & dt.Rows(0)("Bore_Diameter") & " Press Status : " & IIf(IsDBNull(dt.Rows(0)("press_status")), "", dt.Rows(0)("press_status")) & " L/Despatch : " & IIf(IsDBNull(dt.Rows(0)("despatch_note_number")), "", dt.Rows(0)("despatch_note_number")) & " WheelNumber: " & txtWheelNumber.Text & "/" & txtHeatNumber.Text
                    j = 1
                End If
            Catch exp As Exception
                lblMessage.Text = exp.Message
            Finally
            End Try
            If j = 0 Then lblMessage.Text = "Wheel not entered by Yard Insp Magna : " & txtWheelNumber.Text & "/" & txtHeatNumber.Text
            txtWheelNumber.Text = ""
            txtHeatNumber.Text = ""
        End If
        i = Nothing
        j = Nothing
    End Sub

    Private Sub dgVerify_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgVerify.EditCommand
        Exit Sub
        btnSave.Enabled = False
        dgVerify.EditItemIndex = e.Item.ItemIndex
        getdata(txtWheelNumber.Text & "/" & txtHeatNumber.Text)
        getTreadDiaBoundary(getwheeltype())
    End Sub
    Private Function getwheeltype() As String
        Dim sProdCode As String = RWF.CLRINS.getwheeltype(txtWheelNumber.Text, txtHeatNumber.Text)
        Return sProdCode
    End Function
    Private Sub getTreadDiaBoundary(ByVal ProdCode As String)
        Dim dt As DataTable
        Try
            dt = RWF.CLRINS.getTreadDiaBoundary(ProdCode)
            lblminTD.Text = dt.Rows(0)("minTreadDia")
            lblMaxTD.Text = dt.Rows(0)("maxTreadDia")
            Dim mintd, maxtd, td As Decimal
            mintd = dt.Rows(0)("minTreadDia")
            maxtd = dt.Rows(0)("maxTreadDia")
            td = Val(txtTreaddia.Text)
            If td > 0 Then
                If td >= mintd And td <= maxtd Then
                    rdoDisposition.ClearSelection()
                    Dim i As Integer
                    For i = 0 To rdoDisposition.Items.Count - 1
                        If rdoDisposition.Items(i).Value = "P" Then
                            rdoDisposition.Items(i).Selected = True
                            Exit For
                        End If
                    Next
                    i = Nothing
                End If
            End If
            mintd = Nothing
            maxtd = Nothing
            td = Nothing
        Catch exp As Exception
            lblminTD.Text = "0.0"
            lblMaxTD.Text = "0.0"
            lblMessage.Text = exp.Message & ":" & txtWheelNumber.Text & "/" & txtHeatNumber.Text
            txtWheelNumber.Text = ""
            txtHeatNumber.Text = ""
        Finally
            dt.Dispose()
            dt = Nothing
        End Try
    End Sub

    Private Sub dgVerify_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgVerify.UpdateCommand
        Exit Sub
        Dim mintd, maxtd, td As Decimal
        lblMessage.Text = ""
        btnSave.Enabled = True
        Dim txtTreadDia As New TextBox(), txtBoreSts As New TextBox(), txtPlateSts As New TextBox(), txtRimSts As New TextBox(), txtSts As New TextBox()
        Try

            txtTreadDia = e.Item.Cells(7).Controls(0)
            txtBoreSts = e.Item.Cells(8).Controls(0)
            txtPlateSts = e.Item.Cells(9).Controls(0)

            lblTreadDia.Text = txtTreadDia.Text
            lblBoreSts.Text = txtBoreSts.Text
            lblPlateSts.Text = txtPlateSts.Text
            ' donot call checkwheel as that restores old values and updated values will be lost.
            td = CDec(lblTreadDia.Text)
            mintd = CDec(lblminTD.Text)
            maxtd = CDec(lblMaxTD.Text)
            If Not (td >= mintd And td <= maxtd) Then
                lblMessage.Text = "Tread Dia " & td.ToString & " out of Range (min: " & mintd.ToString & " max: " & maxtd.ToString & ")"
            End If
            Select Case txtBoreSts.Text.ToUpper
                Case "OK", "BOS", "UB", "RBS", "WBS", "B"
                Case Else
                    lblMessage.Text = "Bore Status can be one of : OK, BOS, UB, RBS, WBS "
            End Select
            Select Case txtPlateSts.Text.ToUpper
                Case "OK", "RPS"
                Case Else
                    lblMessage.Text = "Plate Status can be one of : OK, RPS"
            End Select
            If lblMessage.Text = "" Then
                lblMessage.Text = "Updated"
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dgVerify.EditItemIndex = -1
            getdata(txtWheelNumber.Text & "/" & txtHeatNumber.Text)
        End Try
        If lblMessage.Text <> "Updated" Then
            Exit Sub
        End If
        Try
            If New RWF.CLRINS().VerifyUpdate(CLng(txtWheelNumber.Text), CLng(txtHeatNumber.Text), CDec(txtTreadDia.Text), txtBoreSts.Text.ToUpper, txtPlateSts.Text.ToUpper) > 0 Then
                lblMessage.Text = "Updated"
            Else
                lblMessage.Text = "Update Failed"
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dgVerify.EditItemIndex = -1
            getdata(txtWheelNumber.Text & "/" & txtHeatNumber.Text)
        End Try
        mintd = Nothing
        maxtd = Nothing
        td = Nothing
        txtTreadDia = Nothing
        txtBoreSts = Nothing
        txtPlateSts = Nothing
        txtRimSts = Nothing
        txtSts = Nothing
    End Sub

    Private Sub dgVerify_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgVerify.CancelCommand
        Exit Sub
        btnSave.Enabled = True
        dgVerify.EditItemIndex = -1
        getdata(txtWheelNumber.Text & "/" & txtHeatNumber.Text)
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtBoreDia.Text = "" Then
            txtBoreDia.Text = "0.0"
        End If
        lblMessage.Text = lblMessage.Text.Replace("Updated grid", "")
        If lblFinalInsp.Text = "" Or CStr(Session("UserID")).Trim = "" Then  ' added on 12/10/2006 to prevent blank fi emp code if session is lost.
            lblMessage.Text = "Login employee code not found"
            Exit Sub
        End If
        If ddlRej.Visible AndAlso ddlRej.SelectedItem.Text.ToLower = "select" Then
            lblMessage.Text = "Please select a Rejection Code"
            Exit Sub
        End If
        If ddlRew.Visible AndAlso ddlRew.SelectedItem.Text.ToLower = "select" Then
            lblMessage.Text = "Please select a Rejwork Code"
            Exit Sub
        End If
        If txtTreaddia.Text = "" OrElse txtBoreSts.Text = "" OrElse txtPlateSts.Text = "" Then
            If lblMagDisposition.Text.ToLower.StartsWith("xc") = False AndAlso lblMagDisposition.Text.ToLower.StartsWith("r") = False Then
                If RWF.CLRINS.wheelPassed(txtWheelNumber.Text, txtHeatNumber.Text) Then
                    lblMessage.Text = "FI Data not completely entered"
                    Exit Sub
                End If
            End If
        End If
        If txtWheelNumber.Text = "" Or txtHeatNumber.Text = "" Then
            lblMessage.Text = "Insuffieint data to save"
            Exit Sub
        End If
        If lblMagDisposition.Text.ToLower.StartsWith("xc") = False Then
            txtBoreSts.Text = txtBoreSts.Text.ToUpper
            Select Case txtBoreSts.Text.ToUpper
                Case "OK", "BOS", "UB", "RBS", "WBS", "B"
                Case Else
                    If RWF.CLRINS.wheelPassed(txtWheelNumber.Text, txtHeatNumber.Text) Then
                        lblMessage.Text = "Bore Status can be one of : OK, BOS, UB, RBS, WBS "
                    End If
            End Select
            Select Case txtPlateSts.Text.ToUpper
                Case "OK", "RPS"
                Case Else
                    If RWF.CLRINS.wheelPassed(txtWheelNumber.Text, txtHeatNumber.Text) Then
                        lblMessage.Text = "Plate Status can be one of : OK, RPS"
                    End If
            End Select
        Else
            txtBoreSts.Text = ""
            txtPlateSts.Text = ""
            txtTreaddia.Text = 0
        End If
        If lblMessage.Text <> "" Then
            Exit Sub
        End If
        lblMessage.Text = ""

        If chkReInspect.Checked = False Then
            If CDec(txtTreaddia.Text) < 1 Then
                If lblMagDisposition.Text.ToLower.StartsWith("xc") = False Then
                    If rdoDisposition.SelectedItem.Value = "P" Then
                        lblMessage.Text = "Cannot be Passed when Tread Dia is : " & txtTreaddia.Text
                        Exit Sub
                    End If
                End If
            Else
                If rdoDisposition.SelectedItem.Value <> "P" Then
                    lblMessage.Text = "Cannot be Hold/Rejected when Tread Dia is : " & txtTreaddia.Text
                    Exit Sub
                End If
            End If
            If New RWF.CLRINS().SaveYardWhl(txtWheelNumber.Text, txtHeatNumber.Text, txtTreaddia.Text, txtBoreSts.Text, txtPlateSts.Text, txtBoreDia.Text, txt1.Text, txt2.Text, Session("UserID")) Then
                lblMessage.Text = " Saved wheel : " & txtWheelNumber.Text & "/" & txtHeatNumber.Text & ". Select/input Another wheel"
            End If
            lblSaveMessage.Text = lblMessage.Text
            lblMessage.Text = ""
        Else
            If CDbl(txtTreaddia.Text) < 1 Then
                If lblMagDisposition.Text.ToLower.StartsWith("xc") = False Then
                    If rdoDisposition.SelectedItem.Value = "P" Then
                        lblMessage.Text = "Cannot be passed when Tread Dia is : " & txtTreaddia.Text
                        Exit Sub
                    End If
                End If
            End If
            lblMessage.Text = ""
            Dim lab_inspector As String = RWF.CLRINS.getLabInsp(txtWheelNumber.Text, txtHeatNumber.Text)
            If lab_inspector = "Not Found" Then
                Exit Sub
            End If
            Dim tech_inspector As String = RWF.CLRINS.getTechInsp(txtWheelNumber.Text, txtHeatNumber.Text)
            If tech_inspector = "Not Found" Then
                Exit Sub
            End If
            Dim pre_status As String = RWF.CLRINS.getPrestatus(txtWheelNumber.Text, txtHeatNumber.Text)
            If pre_status = "Not Found" Then
                Exit Sub
            End If
            Dim blnSaved As Boolean
            blnSaved = New RWF.CLRINS().SaveYardWhlReInspect(txtWheelNumber.Text, txtHeatNumber.Text, IIf(txtBoreSts.Text.ToUpper.StartsWith("U"), "Un-Bore", "B"), rdoDisposition.SelectedItem.Value, Session("UserID"), lab_inspector, tech_inspector, CDbl(txtTreaddia.Text), txtPlateSts.Text, pre_status)
            If blnSaved = False Then
                lblMessage.Text &= " Wheel : " & txtWheelNumber.Text & "/" & txtHeatNumber.Text & " Not Saved "
            Else
                lblMessage.Text = "Saved : " & txtWheelNumber.Text & "/" & txtHeatNumber.Text & " "
            End If
            txtWheelNumber.Text = ""
            txtHeatNumber.Text = ""
            lab_inspector = Nothing
            pre_status = Nothing
            tech_inspector = Nothing
            blnSaved = Nothing
        End If
        ReListWheels(chkXCWheels.Checked, chkReInspect.Checked, chkRLPTWheels.Checked)
        populateGrid()
        dgVerify.Visible = False
        txtWheelNumber.Text = ""
        txtHeatNumber.Text = ""
        Clear()
    End Sub

    Private Sub ddlRej_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlRej.SelectedIndexChanged
        If ddlRej.SelectedItem.Text.ToLower = "select" Then
            lblMessage.Text = "Please select a Rejection Code"
            Exit Sub
        End If
        If chkReInspect.Checked = True Then
            updateReInspStsInGrid()
        Else
            ' update wheel disposition in mm_yardInspection_magna with new disposition
            Dim sqlcmd As New SqlClient.SqlCommand()
            'sqlcmd.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
            sqlcmd.Connection = New SqlClient.SqlConnection(ConfigurationManager.AppSettings("con"))
            sqlcmd.CommandText = "Update c set c.treaddia = 0, c.platestatus = '', c.borestatus = '', c.wheelDisposition = 'R'+'" & ddlRej.SelectedItem.Value & "' from  " & _
                                 "  mm_yardInspection_technical a inner join mm_yardInspection_magna  b on b.techslno = a.slno inner join mm_yardInspection_final  c on c.magslno = b.slno " & _
                                 " where a.wheelNumber = @wheelNumber and a.heatNumber = @heatNumber AND b.wheelDisposition = 'SY_P'"
            sqlcmd.Parameters.Add("@WheelNumber", SqlDbType.BigInt, 8)
            sqlcmd.Parameters.Add("@HeatNumber", SqlDbType.BigInt, 8)
            sqlcmd.Parameters("@WheelNumber").Direction = ParameterDirection.Input
            sqlcmd.Parameters("@HeatNumber").Direction = ParameterDirection.Input
            sqlcmd.Parameters("@WheelNumber").Value = CLng(txtWheelNumber.Text)
            sqlcmd.Parameters("@HeatNumber").Value = CLng(txtHeatNumber.Text)
            Try
                sqlcmd.Connection.Open()
                sqlcmd.ExecuteNonQuery()
                sqlcmd.CommandText = "SELECT  COUNT(*) from  " & _
                                 "  mm_yardInspection_technical a inner join mm_yardInspection_magna  b on b.techslno = a.slno inner join mm_yardInspection_final  c on " & _
                                 " c.magslno = b.slno where a.wheelNumber = @wheelNumber and a.heatNumber = @heatNumber AND c.wheelDisposition = 'R'+'" & ddlRej.SelectedItem.Value & "'"
                If sqlcmd.ExecuteScalar > 0 Then
                    lblMessage.Text = "Updated grid"
                Else
                    lblMessage.Text = "Update grid failed"
                End If
            Catch exp As Exception
                lblMessage.Text = exp.Message
            Finally
                If sqlcmd.Connection.State = ConnectionState.Open Then sqlcmd.Connection.Close()
                sqlcmd.Dispose()
                sqlcmd = Nothing
                getdata(txtWheelNumber.Text & "/" & txtHeatNumber.Text)
            End Try
        End If

    End Sub

    Private Sub ddlRew_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ddlRew.SelectedItem.Text.ToLower = "select" Then
            lblMessage.Text = "Please select a Rework Code"
            Exit Sub
        End If
        If chkReInspect.Checked = True Then
            updateReInspStsInGrid()
        Else
            Dim sqlcmd As New SqlClient.SqlCommand()
            sqlcmd.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
            sqlcmd.CommandText = "Update c set c.treaddia = 0, c.platestatus = '', c.borestatus = '', c.wheelDisposition = 'W'+'" & ddlRew.SelectedItem.Value & "' from  " & _
                                 "  mm_yardInspection_technical a inner join mm_yardInspection_magna  b on b.techslno = a.slno inner join mm_yardInspection_final  c on " & _
                                 " c.magslno = b.slno where a.wheelNumber = @wheelNumber and a.heatNumber = @heatNumber AND b.wheelDisposition = 'SY_P'"
            sqlcmd.Parameters.Add("@WheelNumber", SqlDbType.BigInt, 8)
            sqlcmd.Parameters.Add("@HeatNumber", SqlDbType.BigInt, 8)
            sqlcmd.Parameters("@WheelNumber").Direction = ParameterDirection.Input
            sqlcmd.Parameters("@HeatNumber").Direction = ParameterDirection.Input
            sqlcmd.Parameters("@WheelNumber").Value = CLng(txtWheelNumber.Text)
            sqlcmd.Parameters("@HeatNumber").Value = CLng(txtHeatNumber.Text)
            Try
                sqlcmd.Connection.Open()
                sqlcmd.ExecuteNonQuery()
                sqlcmd.CommandText = "SELECT  COUNT(*) from  " & _
                                 "  mm_yardInspection_technical a inner join mm_yardInspection_magna  b on b.techslno = a.slno inner join mm_yardInspection_final  c on " & _
                                 " c.magslno = b.slno where a.wheelNumber = @wheelNumber and a.heatNumber = @heatNumber AND c.wheelDisposition = 'W'+'" & ddlRew.SelectedItem.Value & "'"
                If sqlcmd.ExecuteScalar > 0 Then
                    lblMessage.Text = "Updated grid"
                Else
                    lblMessage.Text = "Update grid failed"
                End If
            Catch exp As Exception
                lblMessage.Text = exp.Message
            Finally
                If sqlcmd.Connection.State = ConnectionState.Open Then sqlcmd.Connection.Close()
                sqlcmd.Dispose()
                sqlcmd = Nothing
                getdata(txtWheelNumber.Text & "/" & txtHeatNumber.Text)
            End Try
        End If
    End Sub

    Private Sub txtTreaddia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTreaddia.TextChanged
        Dim mintd, maxtd, td As Decimal
        mintd = lblminTD.Text
        maxtd = lblMaxTD.Text
        rdoDisposition.ClearSelection()
        td = txtTreaddia.Text
        If td < mintd OrElse td > maxtd Then
            lblMessage.Text = "Tread Dia " & td.ToString & " out of Range (min: " & mintd.ToString & " max: " & maxtd.ToString & ")"
            txtTreaddia.Text = "0"
        Else
            If (td Mod 0.5) > 0 Then
                lblMessage.Text = "Tread dia must end with .0 or 0.5 : " & txtTreaddia.Text
                txtTreaddia.Text = "0"
                Exit Sub
            End If
            Dim i As Integer
            For i = 0 To rdoDisposition.Items.Count - 1
                If rdoDisposition.Items(i).Value = "P" Then
                    rdoDisposition.Items(i).Selected = True
                    Exit For
                End If
            Next
            lblMessage.Text = ""
            i = Nothing
        End If
        mintd = Nothing
        maxtd = Nothing
        td = Nothing
    End Sub

    Private Sub txtBoreSts_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBoreSts.TextChanged
        txtBoreSts.Text = txtBoreSts.Text.ToUpper
        Select Case txtBoreSts.Text.ToUpper
            Case "OK", "BOS", "UB", "RBS", "WBS", "B"
            Case Else
                lblMessage.Text = "Bore Status can be one of : OK, BOS, UB, RBS, WBS "
                txtBoreSts.Text = ""
        End Select
        If txtBoreDia.Text <> "" Then
            CheckBoreDiaAndStatus()
        End If
    End Sub

    Private Sub txtPlateSts_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPlateSts.TextChanged
        Select Case txtPlateSts.Text.ToUpper
            Case "OK", "RPS"
            Case Else
                lblMessage.Text = "Plate Status can be one of : OK, RPS"
                txtPlateSts.Text = ""
        End Select
    End Sub

    Private Sub chkXCWheels_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkXCWheels.CheckedChanged
        ReListWheels(chkXCWheels.Checked)
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        pnlhelp.Visible = CheckBox1.Checked
    End Sub

    Private Sub chkReInspect_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkReInspect.CheckedChanged
        ' Load Hold wheels in List Box.
        Clear()
        If chkReInspect.Checked Then
            If chkXCWheels.Checked = True Then
                chkXCWheels.Checked = False
            End If
            ReListWheels(False, True)
        Else
            ReListWheels()
        End If
    End Sub
    Private Sub updateReInspStsInGrid()
        Dim dt As New DataTable()
        dt.Columns.Add(New DataColumn("wheel"))
        dt.Columns("wheel").DataType = GetType(System.String)
        dt.Columns("wheel").MaxLength = 50

        dt.Columns.Add(New DataColumn("waitingFrom"))
        dt.Columns("waitingFrom").DataType = GetType(System.DateTime)

        dt.Columns.Add(New DataColumn("shift"))
        dt.Columns("shift").DataType = GetType(System.String)
        dt.Columns("shift").MaxLength = 1

        dt.Columns.Add(New DataColumn("lastmcnopn"))
        dt.Columns("lastmcnopn").DataType = GetType(System.String)
        dt.Columns("lastmcnopn").MaxLength = 50

        dt.Columns.Add(New DataColumn("disposition"))
        dt.Columns("disposition").DataType = GetType(System.String)
        dt.Columns("disposition").MaxLength = 50

        dt.Columns.Add(New DataColumn("MagnaDisposition"))
        dt.Columns("MagnaDisposition").DataType = GetType(System.String)
        dt.Columns("MagnaDisposition").MaxLength = 50

        dt.Columns.Add(New DataColumn("treaddia"))
        dt.Columns("MagnaDisposition").DataType = GetType(System.Double)

        dt.Columns.Add(New DataColumn("borests"))
        dt.Columns("borests").DataType = GetType(System.String)
        dt.Columns("borests").MaxLength = 50

        dt.Columns.Add(New DataColumn("platests"))
        dt.Columns("borests").DataType = GetType(System.String)
        dt.Columns("borests").MaxLength = 50

        Dim row As DataRow
        Dim i As Integer
        For i = 0 To dgVerify.Items.Count - 1
            row = dt.NewRow
            row("wheel") = dgVerify.Items(i).Cells(1).Text
            row("waitingFrom") = CDate(dgVerify.Items(i).Cells(2).Text)
            row("shift") = dgVerify.Items(i).Cells(3).Text
            row("lastmcnopn") = dgVerify.Items(i).Cells(4).Text
            Select Case rdoDisposition.SelectedItem.Text
                Case "Pass"
                    row("disposition") = "SY_P"
                Case "Hold"
                    row("disposition") = "W" & ddlRew.SelectedItem.Value
                Case "Reject"
                    row("disposition") = "R" & ddlRej.SelectedItem.Value
                Case Else
                    btnSave.Enabled = False
                    ddlRej.Visible = False
                    ddlRew.Visible = False
                    Clear(False)
                    Exit Sub
            End Select
            ' row("MagnaDisposition") = CStr(dgVerify.Items(i).Cells(6).Text).Trim
            row("treaddia") = CDbl(txtTreaddia.Text)
            row("borests") = txtBoreSts.Text.ToUpper
            row("platests") = txtPlateSts.Text.ToUpper
            dt.Rows.Add(row)
        Next
        dgVerify.DataSource = dt.DefaultView
        dgVerify.DataBind()
        dt = Nothing
        row = Nothing
        i = Nothing
    End Sub

    Private Sub txtBoreDia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBoreDia.TextChanged
        If txtBoreSts.Text <> "" Then
            CheckBoreDiaAndStatus()
        End If
    End Sub
    Private Sub CheckBoreDiaAndStatus()
        Dim ofiWheel As New InspectionAssistant()
        Dim prevMessage As String = lblMessage.Text
        lblMessage.Text = ""
        If txtBoreDia.Text = "" Then
            txtBoreDia.Text = "0.0"
        End If
        Try
            ofiWheel.CheckWheel(CLng(txtWheelNumber.Text), CLng(txtHeatNumber.Text))
            ofiWheel.BoreDia = CDec(txtBoreDia.Text)
        Catch

        End Try

        Try
            lblMessage.Text = ""
            ofiWheel.BoreDia = CDec(txtBoreDia.Text)
            If ofiWheel.BoreOverSize And txtBoreSts.Text = "BOS" Then
            ElseIf ofiWheel.IsBoreDiaOK And (txtBoreSts.Text = "B" Or txtBoreSts.Text = "OK") And Not ofiWheel.BoreOverSize Then
            ElseIf ofiWheel.BoreStatus = "UB" And txtBoreDia.Text < 0 Then
            Else
                lblMessage.Text = "Bore Dia " & txtBoreDia.Text & " and Bore Status " & txtBoreSts.Text & " mismatch"
                txtBoreSts.Text = ""
                txtBoreDia.Text = ""
            End If

        Catch exp As Exception
            lblMessage.Text = exp.Message
            txtBoreSts.Text = ""
            txtBoreDia.Text = ""
        End Try
        ofiWheel = Nothing
        prevMessage = Nothing
    End Sub

    Private Sub ddlGridOption_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ddlGridOption.SelectedItem.Value = "Score" Then populateGrid(False) Else populateGrid()
    End Sub

    Private Sub chkRLPTWheels_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRLPTWheels.CheckedChanged
        Clear()
        If chkRLPTWheels.Checked Then
            ReListWheels(False, False, True)
        Else
            ReListWheels()
        End If
    End Sub
End Class