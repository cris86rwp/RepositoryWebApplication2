Public Class WheelMachining
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblMode As System.Web.UI.WebControls.Label
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfvDate As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents ddlShift As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cvshift As System.Web.UI.WebControls.CustomValidator
    Protected WithEvents txtOperator As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfvOperator As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents ddlSetForWhlType As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cvwhltype As System.Web.UI.WebControls.CustomValidator
    Protected WithEvents ddlSetForMcn As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cvmcnopn As System.Web.UI.WebControls.CustomValidator
    Protected WithEvents ddlMcnAgency As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cvMcnAgency As System.Web.UI.WebControls.CustomValidator
    Protected WithEvents ddlMachineId As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtWheel As System.Web.UI.WebControls.TextBox
    Protected WithEvents GrdInfo As System.Web.UI.WebControls.DataGrid
    Protected WithEvents cvOperator As System.Web.UI.WebControls.CustomValidator
    Protected WithEvents chkOverride As System.Web.UI.WebControls.CheckBox
    Protected WithEvents rfvwheel As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents btnSend As System.Web.UI.WebControls.Button
    Protected WithEvents btnMachined As System.Web.UI.WebControls.Button
    Protected WithEvents btnRecd As System.Web.UI.WebControls.Button
    Protected WithEvents btnClear As System.Web.UI.WebControls.Button
    Protected WithEvents cvmcnId As System.Web.UI.WebControls.CustomValidator
    'Protected WithEvents txtGatePass As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMcnMark As System.Web.UI.WebControls.Label
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    Private mcnwheel As New WheelMachiningClass()
    Dim cvMcnAgencyPage, cvmcnIdpage, cvmcnopnpage, cvwhltypepage, cvshiftPage, cvOperatorPage As Boolean
    Dim iCurPage As Integer
    Dim blnValidPage As Boolean
    Dim sSortFld As String

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
        If Page.IsPostBack = False Then
            Session("UserID") = "077614"
            If Session("UserID") = Nothing Then
                ' Response.Redirect("/mms/invalidsession.aspx")
                Response.Redirect("InvalidSession.aspx")
                Exit Sub
            End If
            txtOperator.Text = Session("UserID")
            txtOperator.ReadOnly = True
            lblMode.Text = "Add/Delete"
            blnValidPage = False
            Session("mcnwheel") = mcnwheel
            'Session("mcnwheel").constring = ConfigurationSettings.AppSettings("con")
            Session("mcnwheel").constring = ConfigurationManager.AppSettings("con")
            Session("mcnwheel").MachineDDL(ddlMachineId)
            Session("mcnwheel").Operator1 = txtOperator.Text
            blnValidPage = True
            ViewState("iCurpage") = 0
            ViewState("sSortFld") = "EnteredOrder"
            ' txtGatePass.Enabled = False
        Else
            checkservervalidations()
            If txtWheel.Text = "" Then
                Session("mcnwheel").Wheel = ""
            End If
        End If
    End Sub
    Sub PopulateGrid(Optional ByVal iPage As Integer = 0, Optional ByVal sSortField As String = "EnteredOrder")
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        Try
            da.SelectCommand.CommandText = "select Wheel, McnCode McnOpn, machine_code, MarkedBy, " &
                " convert(varchar(10),MarkedOn,103) MarkedDate ,McnAgency Agency, " &
                " convert(varchar(10),McnDate,103) MachinedDate ,status , Remarks, sl_no EnteredOrder " &
                " from mm_wheel_machining_details" &
                " where mcnDate = '" & Format(Session("mcnwheel").ProcessDate, "MM/dd/yyyy") & "' " &
                " and shiftcode = '" & Session("mcnwheel").shift & "' order by sl_no desc "
            da.Fill(ds)
            Dim source As DataView = ds.Tables(0).DefaultView
            GrdInfo.DataSource = source
            GrdInfo.AllowPaging = True
            GrdInfo.AllowSorting = True
            source.Sort = sSortField & " DESC"
            GrdInfo.PageSize = 2
            GrdInfo.PagerStyle.Mode = PagerMode.NumericPages
            GrdInfo.CurrentPageIndex = iPage
            GrdInfo.DataBind()
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            da.Dispose()
            ds.Dispose()
            ds = Nothing
            da = Nothing
        End Try
    End Sub
    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        lblMcnMark.Text = ""
        Try
            Session("mcnwheel").shift = ddlShift.SelectedItem.Text.ToUpper
            Session("mcnwheel").ProcessDate = (CDate(txtDate.Text))
            lblMessage.Text = ""
        Catch exp As Exception
            lblMessage.Text = exp.Message
            Exit Sub
        End Try
        If Session("mcnwheel").ErrStatus Then
            lblMessage.Text = Session("mcnwheel").Message
            PopulateGrid()
            txtDate.Text = ""
            txtWheel.Text = ""
            Session("mcnwheel").Wheel = ""
            Exit Sub
        End If
        If Session("mcnwheel").Wheel = "" Then
            Exit Sub
        Else
            PopulateGrid()
            Session("mcnwheel").CheckWheel(txtWheel.Text)
            If Session("mcnwheel").ErrStatus Then
                txtWheel.Text = ""
                lblMessage.Text = Session("mcnwheel").Message
                Session("mcnwheel").Wheel = ""
            End If
        End If
    End Sub
    Private Sub txtWheel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWheel.TextChanged
        Try
            lblMcnMark.Text = ""
            Session("mcnwheel").Refresh()
            If txtWheel.Text.StartsWith("0") = True Then
                lblMessage.Text = "Do Not Pre-Fix Wheel Number with '" & 0 & "' "
                txtWheel.Text = ""
            Else
                Session("mcnwheel").Wheel = txtWheel.Text
                lblMcnMark.Text = Session("mcnwheel").McnMark
                If Session("mcnwheel").ErrStatus = True Then
                    lblMessage.Text = Session("mcnwheel").Message
                    chkOverride.Visible = Session("mcnwheel").IsOverridable
                    clearform(False)
                    Exit Sub
                End If
                If Session("mcnwheel").isoverriden = True Then
                    lblMessage.Text = Session("mcnwheel").Message & " { Overriden By Your Choice } "
                Else
                    lblMessage.Text = Session("mcnwheel").Message
                End If
            End If
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
    End Sub
    Private Sub clearform(ByVal clearall As Boolean)
        txtWheel.Text = ""
        If clearall = True Then
            lblMessage.Text = ""
            Session("mcnwheel").Refresh()
        End If
        Try
            Session("mcnwheel").objcheck = True
            blnValidPage = True
        Catch exp As Exception
            blnValidPage = False
        End Try

    End Sub
    Private Sub ddlMcnAgency_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMcnAgency.SelectedIndexChanged
        ddlMachineId.Enabled = False
        ddlMachineId.ClearSelection()
        ddlMachineId.Items(0).Selected = True
        If ddlMcnAgency.SelectedItem.Text.ToString.ToLower = "rwp" Then
            ddlMachineId.Enabled = True
            'txtGatePass.Enabled = False
            ' txtGatePass.Text = ""
        Else
            ' txtGatePass.Enabled = True
            cvmcnIdpage = True
        End If
        Session("mcnwheel").McnAgency = ddlMcnAgency.SelectedItem.Text
        If Session("mcnwheel").ErrStatus = True Then
            lblMessage.Text = Session("mcnwheel").Message
            txtWheel.Text = ""
        Else
            lblMessage.Text = Session("mcnwheel").Message
        End If
    End Sub
    Private Sub ddlMachineId_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMachineId.SelectedIndexChanged
        If ddlMachineId.SelectedItem.Text.ToString.ToLower <> "select" Then
            ddlMcnAgency.ClearSelection()
            ddlMcnAgency.Items(1).Selected = True
            Session("mcnwheel").McnAgency = ddlMcnAgency.SelectedItem.Text
            Session("mcnwheel").MachineID = ddlMachineId.SelectedItem.Value
        Else
            Session("mcnwheel").MachineID = ""
        End If
        If Session("mcnwheel").ErrStatus = True Then
            lblMessage.Text = Session("mcnwheel").Message
            txtWheel.Text = ""
        Else
            lblMessage.Text = Session("mcnwheel").Message
        End If

    End Sub
    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        checkservervalidations()
        If blnValidPage = False Then
            lblMessage.Text = "Please check inputs"
            Exit Sub
        End If
        ' Session("mcnwheel").GatePass = txtGatePass.Text
        Session("mcnwheel").Remarks = txtRemarks.Text
        Select Case ddlSetForMcn.SelectedItem.Text
            Case "BNC"
                Session("mcnwheel").SendForMachining("CLFI")
            Case "UB"
                Session("mcnwheel").SendForMachining("CLFI")
            Case Else
                Session("mcnwheel").SendForMachining("CLMT")
        End Select
        lblMessage.Text = Session("mcnwheel").Message
        PopulateGrid()
        chkOverride.Checked = False
    End Sub
    Private Sub btnMachined_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMachined.Click
        checkservervalidations()
        If blnValidPage = False Then
            lblMessage.Text = "Please check inputs"
            Exit Sub
        End If
        Session("mcnwheel").GatePass = ""
        Session("mcnwheel").Remarks = txtRemarks.Text
        Select Case ddlSetForMcn.SelectedItem.Text
            Case "BNC"
                Session("mcnwheel").MachinedInRWF("CLFI")
            Case "UB"
                Session("mcnwheel").MachinedInRWF("CLFI")
            Case Else
                Session("mcnwheel").MachinedInRWF("CLMT")
        End Select
        lblMessage.Text = Session("mcnwheel").Message
        clearform(False)
        PopulateGrid()
        chkOverride.Checked = False
    End Sub
    Private Sub ddlSetForWhlType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlSetForWhlType.SelectedIndexChanged
        Session("mcnwheel").WheelTypeSet = ddlSetForWhlType.SelectedItem.Text
        If Session("mcnwheel").ErrStatus = True Then
            lblMessage.Text = Session("mcnwheel").Message
            txtWheel.Text = ""
            Session("mcnwheel").Wheel = txtWheel.Text
            Exit Sub
        End If
        Session("mcnwheel").ProductCode = ddlSetForWhlType.SelectedItem.Value
        Session("mcnwheel").CheckWheel(Session("mcnwheel").Wheel)
        lblMessage.Text = Session("mcnwheel").Message
    End Sub
    Private Sub btnRecd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecd.Click
        checkservervalidations()
        If blnValidPage = False Then
            lblMessage.Text = "Please check inputs"
            Exit Sub
        End If
        Session("mcnwheel").GatePass = Session("mcnwheel").gatepass
        Session("mcnwheel").Remarks = txtRemarks.Text
        Select Case ddlSetForMcn.SelectedItem.Text
            Case "BNC"
                Session("mcnwheel").ReceiveAfterMachining("CLFI")
            Case "UB"
                Session("mcnwheel").ReceiveAfterMachining("CLFI")
            Case Else
                Session("mcnwheel").ReceiveAfterMachining()
        End Select
        lblMessage.Text = Session("mcnwheel").Message
        PopulateGrid()
        chkOverride.Checked = False
    End Sub

    Private Sub cvMcnAgency_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cvMcnAgency.ServerValidate
        If args.Value.ToString.ToLower <> "select" Then
            If ddlMachineId.SelectedItem.Text.ToString.ToLower <> "select" Then
                If args.Value.ToString.ToLower <> "rwf" Then
                    args.IsValid = False
                Else
                    args.IsValid = True
                End If
            Else
                args.IsValid = True
            End If
        Else
            args.IsValid = False
        End If
        If args.IsValid = False Then
            If Session("mcnwheel").canbeRecd = True Then
                args.IsValid = True
            End If
        End If
        cvMcnAgencyPage = args.IsValid
    End Sub

    Private Sub cvshift_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cvshift.ServerValidate
        args.IsValid = args.Value.ToString.ToLower <> "select"
        cvshiftPage = args.IsValid
    End Sub

    Private Sub cvwhltype_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cvwhltype.ServerValidate
        args.IsValid = args.Value.ToString.ToLower <> "select"
        cvwhltypepage = args.IsValid
    End Sub

    Private Sub cvmcnopn_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cvmcnopn.ServerValidate
        args.IsValid = args.Value.ToString.ToLower <> "select"
        If args.IsValid = False Then
            If Session("mcnwheel").canbeRecd = True Then
                args.IsValid = True
            End If
        End If
        cvmcnopnpage = args.IsValid
    End Sub

    Private Sub cvmcnId_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cvmcnId.ServerValidate, cvMcnAgency.ServerValidate
        args.IsValid = ddlMcnAgency.SelectedItem.Text.ToString.ToLower <> "rwp" And ddlMcnAgency.SelectedItem.Text.ToString.ToLower <> "select"
        If ddlMcnAgency.SelectedItem.Text.Trim.ToLower = "rwp" Then
            If args.Value.ToString.ToLower <> "select" Then
                args.IsValid = True
            Else
                args.IsValid = False
            End If
        End If
        If Session("mcnwheel").canbeRecd = True Then
            args.IsValid = True
        End If
        cvmcnIdpage = args.IsValid
    End Sub

    Private Sub ddlShift_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlShift.SelectedIndexChanged
        Session("mcnwheel").Shift = ddlShift.SelectedItem.Text
        If Session("mcnwheel").ErrStatus = True Then
            txtWheel.Text = ""
        End If
        lblMessage.Text = Session("mcnwheel").Message
        PopulateGrid()
    End Sub

    Private Sub txtOperator_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOperator.TextChanged
        Session("mcnwheel").Operator = txtOperator.Text
        If Session("mcnwheel").ErrStatus = True Then
            txtWheel.Text = ""
        End If
        lblMessage.Text = Session("mcnwheel").Message
    End Sub

    Private Sub ddlSetForMcn_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlSetForMcn.SelectedIndexChanged
        lblMcnMark.Text = ""
        Session("mcnwheel").McnOpnSet = ddlSetForMcn.SelectedItem.Text
        Session("mcnwheel").Wheel = txtWheel.Text
        If Session("mcnwheel").ErrStatus = True Then
            lblMessage.Text = Session("mcnwheel").Message
            txtWheel.Text = ""
            Session("mcnwheel").Wheel = ""
            Exit Sub
        End If
        'Session("mcnwheel").Wheel = txtWheel.Text
        If Session("mcnwheel").canbeRecd = True Then
            txtWheel.Text = Session("mcnwheel").Wheel
        End If
        Session("mcnwheel").CheckWheel(Session("mcnwheel").Wheel)
        lblMessage.Text = Session("mcnwheel").Message
    End Sub

    Private Sub cvOperator_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cvOperator.ServerValidate
        Dim oCmd As SqlClient.SqlCommand
        oCmd = rwfGen.Connection.CmdObj
        oCmd.Parameters.Add("@cnt", SqlDbType.Float, 8).Direction = ParameterDirection.Output
        Try
            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            oCmd.CommandText = "select @cnt = count(*) from hr_employee_master where employee_code = '" & args.Value.ToString & "'"
            oCmd.ExecuteScalar()
            args.IsValid = (IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)) > 0
            cvOperatorPage = args.IsValid
        Catch exp As Exception
            cvOperatorPage = 0.0
            Throw New Exception(exp.Message)
        Finally
            If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
            oCmd.Dispose()
            oCmd = Nothing
        End Try
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        clearform(True)
    End Sub
    Private Sub checkservervalidations()
        blnValidPage = cvMcnAgencyPage And cvmcnIdpage And cvmcnopnpage And cvwhltypepage And cvshiftPage And cvOperatorPage
    End Sub

    Private Sub GrdInfo_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles GrdInfo.PageIndexChanged
        viewstate("iCurpage") = e.NewPageIndex
        PopulateGrid(viewstate("iCurpage"), viewstate("sSortFld"))
    End Sub

    Private Sub GrdInfo_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles GrdInfo.SortCommand
        viewstate("sSortFld") = e.SortExpression
        PopulateGrid(viewstate("iCurpage"), viewstate("sSortFld"))
    End Sub

    Private Sub chkOverride_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOverride.CheckedChanged
        lblMcnMark.Text = ""
        Session("mcnwheel").IsOverriden = chkOverride.Checked
    End Sub

    Private Sub GrdInfo_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles GrdInfo.DeleteCommand
        Session("mcnwheel").DeleteRecord(Val(e.Item.Cells(10).Text))
        lblMessage.Text = Session("mcnwheel").Message
        PopulateGrid()
    End Sub
End Class
