Public Class ManageTools
    Inherits System.Web.UI.Page
    Protected WithEvents rblShop As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblInstrumentType As System.Web.UI.WebControls.Label
    Protected WithEvents ddlInstruments As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDiscripency As System.Web.UI.WebControls.TextBox
    Protected WithEvents Requiredfieldvalidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Rangevalidator3 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents txtAccuracy_received As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator5 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Rangevalidator4 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents txtError_minus As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator4 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Rangevalidator5 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents txtError_plus As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator3 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtRecived As System.Web.UI.WebControls.TextBox
    Protected WithEvents RangeValidator1 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents RequiredFieldValidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtRecipt_date As System.Web.UI.WebControls.TextBox
    Protected WithEvents pnlReceipt As System.Web.UI.WebControls.Panel
    Protected WithEvents rblType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents btnReceiptClear As System.Web.UI.WebControls.Button
    Protected WithEvents btnReceiptExit As System.Web.UI.WebControls.Button
    Protected WithEvents txtShop As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtInstrumentNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents pnlEdit As System.Web.UI.WebControls.Panel
    Protected WithEvents btnExit As System.Web.UI.WebControls.Button
    Protected WithEvents btnClear As System.Web.UI.WebControls.Button
    Protected WithEvents Requiredfieldvalidator16 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtIssued_to As System.Web.UI.WebControls.TextBox
    Protected WithEvents Requiredfieldvalidator17 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtIssued_by As System.Web.UI.WebControls.TextBox
    Protected WithEvents Requiredfieldvalidator18 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Rangevalidator6 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents pnlCalibrate As System.Web.UI.WebControls.Panel
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents RangeValidator2 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents RequiredFieldValidator15 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtstandrad_reading As System.Web.UI.WebControls.TextBox
    Protected WithEvents Requiredfieldvalidator9 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtCaliPlusErr As System.Web.UI.WebControls.TextBox
    Protected WithEvents Requiredfieldvalidator7 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtCaliMinusErr As System.Web.UI.WebControls.TextBox
    Protected WithEvents Requiredfieldvalidator8 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtAccuracy As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator14 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtTemp As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator6 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtPerson As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator13 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtVerified As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator12 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtCaliRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator11 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents lblCalibrationCode As System.Web.UI.WebControls.Label
    Protected WithEvents btnCalibrateSave As System.Web.UI.WebControls.Button
    Protected WithEvents btnCalibrateClear As System.Web.UI.WebControls.Button
    Protected WithEvents btnCalibrateExit As System.Web.UI.WebControls.Button
    Protected WithEvents pnlIssue As System.Web.UI.WebControls.Panel
    Protected WithEvents txtIssueDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnIssue As System.Web.UI.WebControls.Button
    Protected WithEvents lblUserID As System.Web.UI.WebControls.Label
    Protected WithEvents lblreceiptCode As System.Web.UI.WebControls.Label
    Protected WithEvents lblIssueCode As System.Web.UI.WebControls.Label
    Protected WithEvents ddlIssFrq As System.Web.UI.WebControls.DropDownList
    Protected WithEvents chkFRQ As System.Web.UI.WebControls.CheckBox
    Protected WithEvents lblPlusErr As System.Web.UI.WebControls.Label
    Protected WithEvents lblMinusErr As System.Web.UI.WebControls.Label
    Protected WithEvents pnlData As System.Web.UI.WebControls.Panel
    Protected WithEvents txtDataDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents DataGrid3 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblCaliCode As System.Web.UI.WebControls.Label
    Protected WithEvents txtSl As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSize As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtReading As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtError As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnInHouseData As System.Web.UI.WebControls.Button
    Protected WithEvents lblInHouseID As System.Web.UI.WebControls.Label
    Protected WithEvents DataGrid4 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents pnlMain As System.Web.UI.WebControls.Panel
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
        lblInHouseID.Visible = False
        lblUserID.Visible = False
        lblPlusErr.Visible = False
        lblMinusErr.Visible = False
        lblCaliCode.Visible = False
        If IsPostBack = False Then
            ' Session("UserID") = "074229"
            lblUserID.Text = Session("UserID")
            txtDataDate.Text = ToolRoom.Tables.GetTopCalibrationDate
            Try
                SetType()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub rblType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblType.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            SetType()
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
    End Sub

    Private Sub SetType()
        DataClear()
        ReceiptClear()
        CalibrateClear()
        IssueClear()
        Dim Done As Boolean
        pnlReceipt.Visible = False
        pnlCalibrate.Visible = False
        pnlIssue.Visible = False
        ddlIssFrq.Enabled = False
        pnlData.Visible = False
        Try
            GetShops()
            GetInstrumentsList()
            GetInstrumentsDetails()
            DataGrid2.CurrentPageIndex = 0
            DataGrid2.SelectedIndex = -1
            DataGrid3.Visible = False
        Catch exp As Exception
            Done = True
            lblMessage.Text &= exp.Message
        End Try
        If Done Then
            '    Exit Sub
            'Else
            If rblType.SelectedItem.Text = "Receipt" Then
                pnlReceipt.Visible = True
                pnlEdit.Visible = False
                Try
                    txtRecipt_date.Text = Now.Date
                    CheckDate()
                    GetInstrumentsDone()
                Catch exp As Exception
                    lblMessage.Text &= exp.Message
                End Try
            ElseIf rblType.SelectedItem.Text = "Calibrate" Then
                If txtDate.Text.Trim.Length = 0 Then
                    txtDate.Text = ""
                Else
                    GetInstrumentsDone()
                End If
                pnlCalibrate.Visible = True
            ElseIf rblType.SelectedItem.Text = "Issue" Then
                If txtIssueDate.Text.Trim.Length = 0 Then
                    txtIssueDate.Text = Now.Date
                End If
                GetIssueFRQs()
                GetInstrumentsDone()
                pnlIssue.Visible = True
            ElseIf rblType.SelectedItem.Text = "InHouseCalibration" Then
                pnlData.Visible = True
                ' txtDataDate.Text = Date.Now
                DataGrid2.Visible = False
                DataGrid3.Visible = True
            End If
        End If
    End Sub

    Private Sub GetShops()
        rblShop.Items.Clear()
        ddlInstruments.Items.Clear()
        lblInstrumentType.Text = ""
        pnlEdit.Visible = False
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        Dim dt As DataTable
        If rblType.SelectedItem.Text = "InHouseCalibration" Then
            dt = ToolRoom.Tables.CalibratedShops(CDate(txtDataDate.Text))
        Else
            dt = ToolRoom.Tables.ToolsListing(rblType.SelectedItem.Text)
        End If
        If dt.Rows.Count > 0 Then
            rblShop.DataSource = dt
            rblShop.DataTextField = dt.Columns("ShopName").ColumnName
            rblShop.DataValueField = dt.Columns("ShopCode").ColumnName
            rblShop.DataBind()
            rblShop.SelectedIndex = 0
        Else
            Throw New Exception("No Instruments to " & rblType.SelectedItem.Text)
        End If
    End Sub

    Private Sub GetInstrumentsList()
        lblInstrumentType.Text = ""
        ddlInstruments.Items.Clear()
        pnlEdit.Visible = False
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        Dim dt As DataTable
        If rblType.SelectedItem.Text = "InHouseCalibration" Then
            dt = ToolRoom.Tables.CalibratedInstruments(CDate(txtDataDate.Text), rblShop.SelectedItem.Value)
        Else
            dt = ToolRoom.Tables.ToolsListing(rblType.SelectedItem.Text, rblShop.SelectedItem.Value)
        End If
        If dt.Rows.Count > 0 Then
            ddlInstruments.DataSource = dt
            ddlInstruments.DataTextField = dt.Columns("history_card_number").ColumnName
            ddlInstruments.DataValueField = dt.Columns("InstrumentType").ColumnName
            ddlInstruments.DataBind()
            ddlInstruments.SelectedIndex = 0
            lblInstrumentType.Text = ddlInstruments.SelectedItem.Value
        Else
            Throw New Exception("No Instruments to " & rblType.SelectedItem.Text)
        End If
    End Sub

    Private Sub GetInstrumentsDetails()
        lblMinusErr.Text = ""
        lblPlusErr.Text = ""
        pnlEdit.Visible = False
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        DataGrid3.DataSource = Nothing
        DataGrid3.DataBind()
        DataGrid4.DataSource = Nothing
        DataGrid4.DataBind()
        Dim dt As DataTable
        dt = ToolRoom.Tables.InstrumentsDetails(rblShop.SelectedItem.Value, ddlInstruments.SelectedItem.Text)
        DataGrid1.DataSource = dt
        DataGrid1.DataBind()
        lblPlusErr.Text = dt.Rows(0)(7)
        lblMinusErr.Text = dt.Rows(0)(8)
        lblCaliCode.Text = ToolRoom.Tables.CalibrationCode(CDate(txtDataDate.Text), ddlInstruments.SelectedItem.Text)
        If rblType.SelectedItem.Text = "InHouseCalibration" Then
            DataGrid3.DataSource = ToolRoom.Tables.InHouseCalibratedData(Val(lblCaliCode.Text))
            DataGrid3.DataBind()
            DataGrid4.DataSource = ToolRoom.Tables.InHouseCalibratedPreData(Val(lblCaliCode.Text))
            DataGrid4.DataBind()
        End If
        If rblType.SelectedItem.Text = "Issue" Then
            If Not ToolRoom.Tables.InHouseCalibrationCheck(ddlInstruments.SelectedItem.Text) Then
                lblMessage.Text &= " No InHouse Data available for " & ddlInstruments.SelectedItem.Text
            End If
        End If
    End Sub

    Private Sub CheckDate()
        Dim ds As New DataSet()
        Try
            Dim rdt, cdt, idt As Date
            If Val(lblreceiptCode.Text) > 0 Or Val(lblCalibrationCode.Text) > 0 Or Val(lblIssueCode.Text) > 0 Then
                ds = ToolRoom.Tables.GetInstrumentNumberDetails(txtInstrumentNumber.Text.Trim)
            Else
                ds = ToolRoom.Tables.GetInstrumentNumberDetails(ddlInstruments.SelectedItem.Text.Trim)
            End If
            rdt = IIf(IsDBNull(ds.Tables(0).Rows(0)(0)), "1900-01-01", ds.Tables(0).Rows(0)(0))
            idt = IIf(IsDBNull(ds.Tables(1).Rows(0)(0)), "1900-01-01", ds.Tables(1).Rows(0)(0))
            cdt = IIf(IsDBNull(ds.Tables(2).Rows(0)(0)), "1900-01-01", ds.Tables(2).Rows(0)(0))
            idt = IIf(IsDBNull(ds.Tables(1).Rows(0)(0)), "1900-01-01", ds.Tables(1).Rows(0)(0))
            If rblType.SelectedItem.Text = "Receipt" Then
                If idt.Date <> "1/1/1900" Then
                    If CDate(txtRecipt_date.Text) < idt Then
                        lblMessage.Text = "Receipt Date should be greater than last issue date : " & idt.Date
                        txtRecipt_date.Text = ""
                        Exit Sub
                    End If
                End If
            End If
            If rblType.SelectedItem.Text = "Calibrate" Then
                If CDate(txtDate.Text) < rdt.Date Then
                    lblMessage.Text = "Calibration Date cannot be smaller then received date : " & rdt.Date
                    txtDate.Text = ""
                    Exit Sub
                End If
                If CDate(txtDate.Text) < idt.Date Then
                    lblMessage.Text = "Insrtument is already issued On : " & idt.Date
                    txtDate.Text = ""
                End If
            ElseIf rblType.SelectedItem.Text = "Issue" Then
                If Val(lblIssueCode.Text) > 0 Then
                    If rdt.Date > cdt.Date Then
                        If CDate(txtIssueDate.Text) > rdt.Date Then
                            lblMessage.Text = "Issue date cannot be greater then last received date : " & rdt.Date
                            txtDate.Text = ""
                            Exit Sub
                        End If
                    Else
                        If CDate(txtIssueDate.Text) < cdt.Date Then
                            lblMessage.Text = "Issue date cannot be smaller then calibration date :" & cdt.Date
                            txtDate.Text = ""
                            Exit Sub
                        End If
                    End If
                End If
                If Val(lblIssueCode.Text) = 0 Then
                    If CDate(txtIssueDate.Text) < cdt.Date Then
                        lblMessage.Text = "Issue date cannot be smaller then calibration date :" & cdt.Date
                        txtDate.Text = ""
                        Exit Sub
                    End If
                End If
            End If
            DataGrid2.CurrentPageIndex = 0
        Catch exp As Exception
            lblMessage.Text &= exp.Message
            txtRecipt_date.Text = ""
            If CStr(exp.Message).StartsWith("Cast from string") Then
                lblMessage.Text = "Invalid date format"
            End If
        Finally
            ds.Dispose()
            ds = Nothing
        End Try
    End Sub

    Private Sub GetIssueFRQs()
        Dim ds As DataSet
        ds = ToolRoom.Tables.GetIssueFRQs(ddlInstruments.SelectedItem.Text)
        If ds.Tables(0).Rows.Count > 0 Then
            ddlIssFrq.DataSource = ds.Tables(0)
            ddlIssFrq.DataTextField = ds.Tables(0).Columns("Frequency").ColumnName
            ddlIssFrq.DataValueField = ds.Tables(0).Columns("FrequencyCode").ColumnName
            ddlIssFrq.DataBind()
            ddlIssFrq.ClearSelection()
            Dim i As Int16 = 0
            'If ds.Tables(2).Rows.Count > 0 Then
            '    For i = 0 To ddlIssFrq.Items.Count - 1
            '        If ds.Tables(2).Rows(0)(0) = ddlIssFrq.Items(i).Value Then
            '            ddlIssFrq.Items(i).Selected = True
            '            Exit For
            '        End If
            '    Next
            'Else
            For i = 0 To ddlIssFrq.Items.Count - 1
                If ds.Tables(1).Rows(0)(0) = ddlIssFrq.Items(i).Value Then
                    ddlIssFrq.Items(i).Selected = True
                    Exit For
                End If
            Next
            'End If
            If chkFRQ.Checked Then
                ddlIssFrq.Enabled = True
            Else
                ddlIssFrq.Enabled = False
            End If
        End If
    End Sub

    Private Sub GetInstrumentsDone()
        pnlEdit.Visible = False
        DataGrid2.EditItemIndex = -1
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        Dim dt As DataTable
        Try
            If rblType.SelectedItem.Text = "Receipt" Then
                dt = ToolRoom.Tables.GetToolsReceipt(CDate(txtRecipt_date.Text))
            ElseIf rblType.SelectedItem.Text = "Calibrate" Then
                dt = ToolRoom.Tables.GetToolsCalibrated(CDate(txtDate.Text))
            ElseIf rblType.SelectedItem.Text = "Issue" Then
                dt = ToolRoom.Tables.GetToolsIssued(CDate(txtIssueDate.Text))
            End If
            If IsNothing(DataGrid2.CurrentPageIndex) Then DataGrid2.CurrentPageIndex = 0
            If dt.Rows.Count > 5 Then
                DataGrid2.AllowPaging = True
                DataGrid2.PageSize = 5
                DataGrid2.PagerStyle.Mode = PagerMode.NumericPages
            End If
            DataGrid2.DataSource = dt
            DataGrid2.DataBind()
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        Finally
            dt = Nothing
        End Try
    End Sub

    Private Sub ddlInstruments_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlInstruments.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            lblInstrumentType.Text = ddlInstruments.SelectedItem.Value
            GetInstrumentsDetails()
            txtDate.Text = ""
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub rblShop_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblShop.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            GetInstrumentsList()
            GetInstrumentsDetails()
            If rblType.SelectedItem.Text = "Issue" Then
                If txtIssueDate.Text.Trim.Length = 0 Then
                    txtIssueDate.Text = Now.Date
                End If
                GetIssueFRQs()
                GetInstrumentsDone()
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        lblMessage.Text = ""
        Try
            If CDate(txtDate.Text) > Now.Date Then
                lblMessage.Text = "Calibraion Date should be greater than Today date !"
                txtDate.Text = ""
                Exit Sub
            End If
            CheckDate()
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        If lblUserID.Text.Trim.Length = 0 Then
            lblMessage.Text = "InValid User !"
            Exit Sub
        End If
        If Val(txtError_plus.Text) > Val(lblPlusErr.Text) Then
            If Not lblUserID.Text = "078916" Then
                lblMessage.Text = "Cannot be saved with Discripency !"
                Exit Sub
            End If
        End If
        If Val(txtError_minus.Text) > Val(lblMinusErr.Text) Then
            If Not lblUserID.Text = "078916" Then
                lblMessage.Text = "Cannot be saved with Discripency !"
                Exit Sub
            End If
        End If

        If Val(txtError_plus.Text.Trim) > 0 Then
            If Val(txtAccuracy_received.Text.Trim) <> Val(txtError_plus.Text.Trim) Then
                lblMessage.Text = "Accuracy Received to be same as Plus Error Received !"
                Exit Sub
            End If
        End If

        If Val(txtError_minus.Text.Trim) > 0 Then
            If Val(txtAccuracy_received.Text.Trim) <> Val(txtError_minus.Text.Trim) Then
                lblMessage.Text = "Accuracy Received to be same as Minus Error Received !"
                Exit Sub
            End If
        End If

        Dim ds As New DataSet()
        Dim rdt, cdt, idt As Date
        Try
            If Val(lblreceiptCode.Text) = 0 Then
                ds = ToolRoom.Tables.GetInstrumentNumberDetails(ddlInstruments.SelectedItem.Text.Trim)
            Else
                ds = ToolRoom.Tables.GetInstrumentNumberDetails(txtInstrumentNumber.Text.Trim)
            End If
            rdt = IIf(IsDBNull(ds.Tables(0).Rows(0)(0)), "1900-01-01", ds.Tables(0).Rows(0)(0))
            idt = IIf(IsDBNull(ds.Tables(1).Rows(0)(0)), "1900-01-01", ds.Tables(1).Rows(0)(0))
            cdt = IIf(IsDBNull(ds.Tables(2).Rows(0)(0)), "1900-01-01", ds.Tables(2).Rows(0)(0))

            If rdt.Date <> "1/1/1900" Then
                If Val(lblreceiptCode.Text) = 0 Then
                    If rdt > CDate(txtRecipt_date.Text) Then
                        lblMessage.Text = "Receipt Date cannot be smaller than last receipt date : " & rdt.Date
                        Exit Sub
                    End If
                End If
            ElseIf idt.Date <> "1/1/1900" Then
                If idt > CDate(txtRecipt_date.Text) Then
                    lblMessage.Text = "Receipt Date should be greater than last Issue date : " & idt.Date
                    Exit Sub
                End If
            ElseIf cdt.Date <> "1/1/1900" Then
                If cdt > CDate(txtRecipt_date.Text) Then
                    lblMessage.Text = "Receipt Date should be greater than last Calibration date : " & cdt.Date
                    Exit Sub
                End If
            End If

            Dim oToolReci As New ToolRoom.Tool("T")
            oToolReci.MaintenanceGroup = "TOOLS"
            oToolReci.ReceiptDate = txtRecipt_date.Text
            oToolReci.ReceivedBy = txtRecived.Text.Trim
            oToolReci.PlusError = txtError_plus.Text.Trim
            oToolReci.MinusError = txtError_minus.Text.Trim
            oToolReci.AccuracyReceived = txtAccuracy_received.Text.Trim
            oToolReci.UserID = lblUserID.Text
            oToolReci.ChangeDate = Now.Date
            oToolReci.Remarks = txtRemarks.Text.Trim

            If Val(txtError_plus.Text) > Val(lblPlusErr.Text) Then
                oToolReci.Discripency = "Not OK"
            Else
                oToolReci.Discripency = "OK"
            End If
            If Val(txtError_minus.Text) > Val(lblMinusErr.Text) Then
                oToolReci.Discripency = "Not OK"
            Else
                oToolReci.Discripency = "OK"
            End If
            If Val(lblreceiptCode.Text) = 0 Then
                oToolReci.ShopCode = rblShop.SelectedItem.Value.Trim
                oToolReci.InstrumentNumber = ddlInstruments.SelectedItem.Text.Trim
                If oToolReci.SaveToolsReceipt Then
                    lblMessage.Text = "Record Inserted"
                    ReceiptClear()
                End If
            Else
                oToolReci.ShopCode = txtShop.Text.Trim
                oToolReci.InstrumentNumber = txtInstrumentNumber.Text.Trim
                oToolReci.ReceiptCode = Val(lblreceiptCode.Text)
                If oToolReci.SaveToolsReceipt(txtInstrumentNumber.Text) Then
                    lblMessage.Text = "Record UpDated"
                    ReceiptClear()
                    pnlEdit.Visible = False
                End If
            End If
            GetInstrumentsDone()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            ds.Dispose()
            ds = Nothing
        End Try
    End Sub

    Private Sub btnReceiptClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReceiptClear.Click
        lblMessage.Text = ""
        ReceiptClear()
    End Sub

    Private Sub ReceiptClear()
        rblShop.SelectedIndex = 0
        lblreceiptCode.Text = ""
        ddlInstruments.SelectedIndex = 0
        txtRecipt_date.Text = Date.Today
        txtError_minus.Text = ""
        txtError_plus.Text = ""
        txtRecived.Text = ""
        txtRemarks.Text = ""
    End Sub

    Private Sub btnReceiptExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReceiptExit.Click
        Server.Transfer("/mss/selectModule.aspx")
    End Sub

    Private Sub txtRecipt_date_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRecipt_date.TextChanged
        lblMessage.Text = ""
        If CDate(txtRecipt_date.Text) > Now.Date Then
            lblMessage.Text = "Receipt Date should be greater than Today date !"
            txtRecipt_date.Text = ""
            Exit Sub
        End If
        If Val(lblreceiptCode.Text) = 0 Then
            Try
                txtRecipt_date.Text = CDate(txtRecipt_date.Text)
                GetInstrumentsDone()
                CheckDate()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub DataGrid2_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid2.PageIndexChanged
        DataGrid2.SelectedIndex = -1
        DataGrid2.CurrentPageIndex = e.NewPageIndex
        GetInstrumentsDone()
    End Sub

    Private Sub CaliClear()
        txtInstrumentNumber.Text = ""
        txtShop.Text = ""
        txtstandrad_reading.Text = ""
        txtCaliPlusErr.Text = ""
        txtCaliMinusErr.Text = ""
        txtAccuracy.Text = ""
        txtTemp.Text = ""
        txtPerson.Text = ""
        txtVerified.Text = ""
        txtCaliRemarks.Text = ""
        lblCalibrationCode.Text = ""
    End Sub

    Private Sub RecClear()
        txtInstrumentNumber.Text = ""
        txtShop.Text = ""
        txtRecived.Text = ""
        txtError_plus.Text = ""
        txtError_minus.Text = ""
        txtAccuracy_received.Text = ""
        txtDiscripency.Text = ""
        txtRemarks.Text = ""
        lblreceiptCode.Text = ""
    End Sub

    Private Sub IssClear()
        txtInstrumentNumber.Text = ""
        txtShop.Text = ""
        txtIssued_by.Text = ""
        txtIssued_to.Text = ""
        lblIssueCode.Text = ""

    End Sub

    Private Sub DataGrid2_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid2.ItemCommand
        lblMessage.Text = ""
        lblreceiptCode.Text = ""
        pnlEdit.Visible = False
        RecClear()
        CaliClear()
        IssClear()
        Select Case e.CommandName
            Case "Select"
                If rblType.SelectedItem.Text = "Receipt" Then
                    If e.Item.Cells(10).Text = "&nbsp;" Then
                        pnlEdit.Visible = True
                        txtInstrumentNumber.Text = e.Item.Cells(2).Text.Trim
                        txtShop.Text = e.Item.Cells(3).Text.Trim.Replace("&nbsp;", "")
                        txtRecived.Text = e.Item.Cells(4).Text.Trim.Replace("&nbsp;", "")
                        txtError_plus.Text = e.Item.Cells(5).Text.Trim.Replace("&nbsp;", "")
                        txtError_minus.Text = e.Item.Cells(6).Text.Trim.Replace("&nbsp;", "")
                        txtAccuracy_received.Text = e.Item.Cells(7).Text.Trim.Replace("&nbsp;", "")
                        txtDiscripency.Text = e.Item.Cells(8).Text.Trim.Replace("&nbsp;", "")
                        txtRemarks.Text = e.Item.Cells(9).Text.Trim.Replace("&nbsp;", "")
                        lblreceiptCode.Text = e.Item.Cells(11).Text
                    Else
                        DataGrid2.SelectedIndex = -1
                        lblMessage.Text = "Cannot be Edited because Instrument is already Calibrated !"
                        GetInstrumentsDone()
                    End If
                ElseIf rblType.SelectedItem.Text = "Calibrate" Then
                    If e.Item.Cells(13).Text = "&nbsp;" Then
                        pnlEdit.Visible = True
                        txtInstrumentNumber.Text = e.Item.Cells(2).Text.Trim
                        txtShop.Text = e.Item.Cells(3).Text.Trim.Replace("&nbsp;", "")
                        txtstandrad_reading.Text = e.Item.Cells(4).Text.Replace("&nbsp;", "")
                        txtCaliPlusErr.Text = e.Item.Cells(5).Text.Replace("&nbsp;", "")
                        txtCaliMinusErr.Text = e.Item.Cells(6).Text.Replace("&nbsp;", "")
                        txtAccuracy.Text = e.Item.Cells(7).Text.Replace("&nbsp;", "")
                        txtTemp.Text = e.Item.Cells(8).Text.Replace("&nbsp;", "")
                        txtPerson.Text = e.Item.Cells(9).Text.Replace("&nbsp;", "")
                        txtVerified.Text = e.Item.Cells(10).Text.Replace("&nbsp;", "")
                        txtCaliRemarks.Text = e.Item.Cells(11).Text.Replace("&nbsp;", "")
                        lblCalibrationCode.Text = e.Item.Cells(12).Text
                    Else
                        DataGrid2.SelectedIndex = -1
                        lblMessage.Text = "Cannot be Edited because Instrument is already Issued !"
                        GetInstrumentsDone()
                    End If
                ElseIf rblType.SelectedItem.Text = "Issue" Then
                    If e.Item.Cells(8).Text = "ForEdit" Then
                        pnlEdit.Visible = True
                        txtInstrumentNumber.Text = e.Item.Cells(2).Text.Trim
                        txtShop.Text = e.Item.Cells(3).Text.Trim.Replace("&nbsp;", "")
                        txtIssued_to.Text = e.Item.Cells(4).Text.Trim.Replace("&nbsp;", "")
                        txtIssued_by.Text = e.Item.Cells(5).Text.Trim.Replace("&nbsp;", "")
                        lblIssueCode.Text = e.Item.Cells(6).Text.Trim.Replace("&nbsp;", "")
                        lblreceiptCode.Text = e.Item.Cells(7).Text.Trim.Replace("&nbsp;", "")
                        ddlIssFrq.Enabled = False
                        chkFRQ.Checked = False
                    Else
                        DataGrid2.SelectedIndex = -1
                        lblMessage.Text = "Cannot be Edited because Instrument is already Received for Calibration !"
                        GetInstrumentsDone()
                    End If
                End If
        End Select
    End Sub

    Private Sub btnCalibrateClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalibrateClear.Click
        lblMessage.Text = ""
        CalibrateClear()
    End Sub

    Private Sub CalibrateClear()
        If txtDate.Text.Trim.Length = 0 Then txtDate.Text = ""
        txtAccuracy.Text = ""
        txtPerson.Text = ""
        txtCaliRemarks.Text = ""
        txtVerified.Text = ""
        txtTemp.Text = ""
        txtCaliMinusErr.Text = ""
        txtCaliPlusErr.Text = ""
        txtstandrad_reading.Text = ""
        txtInstrumentNumber.Text = ""
        txtShop.Text = ""
    End Sub

    Private Sub btnCalibrateExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalibrateExit.Click
        Server.Transfer("/mss/selectModule.aspx")
    End Sub

    Private Sub btnCalibrateSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalibrateSave.Click
        lblMessage.Text = ""
        Dim rdt, cdt, idt As Date
        Dim ds As New DataSet()
        Dim oToolCali As New ToolRoom.Tool("T")
        Try
            If Val(lblCalibrationCode.Text) = 0 Then
                ds = ToolRoom.Tables.GetInstrumentNumberDetails(ddlInstruments.SelectedItem.Text.Trim)
            Else
                ds = ToolRoom.Tables.GetInstrumentNumberDetails(txtInstrumentNumber.Text.Trim)
            End If
            rdt = IIf(IsDBNull(ds.Tables(0).Rows(0)(0)), "1900-01-01", ds.Tables(0).Rows(0)(0))
            idt = IIf(IsDBNull(ds.Tables(1).Rows(0)(0)), "1900-01-01", ds.Tables(1).Rows(0)(0))
            cdt = IIf(IsDBNull(ds.Tables(2).Rows(0)(0)), "1900-01-01", ds.Tables(2).Rows(0)(0))
            oToolCali.MaintenanceGroup = "TOOLS"
            oToolCali.CalibrationDate = CDate(txtDate.Text)
            oToolCali.AccuracyCalibrated = txtAccuracy.Text.Trim
            oToolCali.CalibratingPerson = txtPerson.Text.Trim
            oToolCali.VerifiedBy = txtVerified.Text.Trim
            oToolCali.Remarks = txtCaliRemarks.Text.Trim
            oToolCali.AmbientTemp = txtTemp.Text.Trim
            oToolCali.PlusError = txtCaliPlusErr.Text.Trim
            oToolCali.MinusError = txtCaliMinusErr.Text.Trim
            oToolCali.StandradReading = txtstandrad_reading.Text.Trim
            oToolCali.ReceiptCode = IIf(IsDBNull(ds.Tables(4).Rows(0)(0)), "0", ds.Tables(4).Rows(0)(0))
            If Val(lblCalibrationCode.Text) = 0 Then
                oToolCali.ShopCode = rblShop.SelectedItem.Value.Trim
                oToolCali.InstrumentNumber = ddlInstruments.SelectedItem.Text.Trim
                If oToolCali.SaveToolsCalibration Then
                    lblMessage.Text = "Record Inserted"
                    ReceiptClear()
                End If
            ElseIf Val(lblCalibrationCode.Text) > 0 Then
                oToolCali.ShopCode = txtShop.Text.Trim
                oToolCali.InstrumentNumber = txtInstrumentNumber.Text.Trim
                oToolCali.CalibrationCode = Val(lblCalibrationCode.Text)
                If oToolCali.SaveToolsCalibration(oToolCali.InstrumentNumber) Then
                    lblMessage.Text = "Record UpDated"
                    CalibrateClear()
                End If
            End If
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        Finally
            ds.Dispose()
            ds = Nothing
        End Try
        Try
            SetType()
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
    End Sub

    Private Sub txtIssueDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIssueDate.TextChanged
        lblMessage.Text = ""
        If CDate(txtIssueDate.Text) > Now.Date Then
            lblMessage.Text = "Issue Date should be greater than Today date !"
            txtIssueDate.Text = ""
            Exit Sub
        End If
        Try
            CheckDate()
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
    End Sub

    Private Sub btnIssue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIssue.Click
        lblMessage.Text = ""
        Dim oToolIssue As New ToolRoom.Tool("T")
        Dim ds As New DataSet()
        Try
            If Val(lblIssueCode.Text) = 0 Then
                oToolIssue.InstrumentNumber = ddlInstruments.SelectedItem.Text.Trim
                oToolIssue.ShopCode = rblShop.SelectedItem.Value.Trim
            Else
                oToolIssue.InstrumentNumber = txtInstrumentNumber.Text.Trim
                oToolIssue.ShopCode = txtShop.Text.Trim
            End If
            ds = ToolRoom.Tables.GetInstrumentNumberDetails(oToolIssue.InstrumentNumber, oToolIssue.ShopCode)
            oToolIssue.ReceiptCode = IIf(IsDBNull(ds.Tables(4).Rows(0)(0)), 0, ds.Tables(4).Rows(0)(0))
            oToolIssue.IssuedDate = CDate(txtIssueDate.Text.Trim)
            If Val(lblIssueCode.Text) = 0 Then
                If IIf(IsDBNull(ds.Tables(2).Rows(0)(0)), CDate("1900-01-01"), ds.Tables(2).Rows(0)(0)) = CDate("1900-01-01") Then
                    lblMessage.Text = "Please check for Tools Calibration date !"
                    Exit Try
                End If
            End If
            oToolIssue.MaintenanceGroup = "TOOLS"
            oToolIssue.IssuedTo = txtIssued_to.Text.Trim
            oToolIssue.IssuedBy = txtIssued_by.Text.Trim
            oToolIssue.UserID = lblUserID.Text
            oToolIssue.CalibrationFrequency = ddlIssFrq.SelectedItem.Value
            If Val(lblIssueCode.Text) = 0 Then
                If oToolIssue.CheckIssue(oToolIssue.InstrumentNumber, oToolIssue.IssuedDate, oToolIssue.ShopCode, oToolIssue.MaintenanceGroup) Then
                    lblMessage.Text = "already issued for then given date !"
                    Exit Sub
                Else
                    If oToolIssue.SaveToolsIssue() Then
                        IssueClear()
                        lblMessage.Text = "Record Inserted "
                    Else
                        lblMessage.Text &= oToolIssue.Message
                    End If
                End If
            ElseIf Val(lblIssueCode.Text) > 0 Then
                lblMessage.Text = IIf(IsDBNull(ds.Tables(7).Rows(0)(0)), 0, ds.Tables(7).Rows(0)(0))
                oToolIssue.IssueCode = lblIssueCode.Text.Trim
                If oToolIssue.SaveToolsIssue(oToolIssue.InstrumentNumber, False, IIf(chkFRQ.Checked, ddlIssFrq.SelectedItem.Value, "")) Then
                    IssueClear()
                    lblMessage.Text &= "Record UpDated"
                Else
                    lblMessage.Text &= "UpDation Failed"
                End If
            End If
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        Finally
            ds.Dispose()
            oToolIssue = Nothing
        End Try
        Try
            SetType()
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
    End Sub

    Private Sub IssueClear()
        txtIssued_by.Text = ""
        txtIssued_to.Text = ""
        txtInstrumentNumber.Text = ""
        txtShop.Text = ""
        chkFRQ.Checked = False
        ddlIssFrq.Enabled = False
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Server.Transfer("/mss/selectModule.aspx")
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        lblMessage.Text = ""
        IssueClear()
    End Sub

    Private Sub chkFRQ_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFRQ.CheckedChanged
        lblMessage.Text = ""
        If chkFRQ.Checked Then
            ddlIssFrq.Enabled = True
        Else
            ddlIssFrq.Enabled = False
        End If
    End Sub

    Private Sub txtError_plus_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtError_plus.TextChanged
        lblMessage.Text = ""
        txtError_plus.ForeColor = System.Drawing.Color.Transparent
        If Val(txtError_plus.Text) > Val(lblPlusErr.Text) Then
            lblMessage.Text = "Plus Error Value greater than Criteria of : " & Val(lblPlusErr.Text)
            txtError_plus.ForeColor = System.Drawing.Color.Red
        End If
    End Sub

    Private Sub txtError_minus_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtError_minus.TextChanged
        lblMessage.Text = ""
        txtError_minus.ForeColor = System.Drawing.Color.Transparent
        If Val(txtError_minus.Text) > Val(lblMinusErr.Text) Then
            lblMessage.Text = "Minus Error Value lesser than Criteria of : " & Val(lblMinusErr.Text)
            txtError_minus.ForeColor = System.Drawing.Color.Red
        End If
    End Sub

    Private Sub DataClear()
        txtSl.Text = ""
        txtSize.Text = ""
        txtReading.Text = ""
        txtError.Text = ""
    End Sub

    Private Sub txtDataDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDataDate.TextChanged
        lblMessage.Text = ""
        Try
            SetType()
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
    End Sub

    Private Sub btnInHouseData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInHouseData.Click
        lblMessage.Text = ""
        Dim oToolIssue As New ToolRoom.Tool("T")
        Try
            oToolIssue.SlNo = Val(txtSl.Text)
            oToolIssue.SizeOfValue = Val(txtSize.Text.Trim)
            oToolIssue.Reading = Val(txtReading.Text.Trim)
            oToolIssue.ErrorValue = Val(txtError.Text)
            oToolIssue.CalibrationCode = Val(lblCaliCode.Text)
            oToolIssue.InHouseID = Val(lblInHouseID.Text)
            If oToolIssue.InHouseData() Then
                DataClear()
                lblMessage.Text &= "Record UpDated"
                DataGrid3.DataSource = ToolRoom.Tables.InHouseCalibratedData(Val(lblCaliCode.Text))
                DataGrid3.DataBind()
            Else
                lblMessage.Text &= "UpDation Failed"
            End If
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        Finally
            oToolIssue = Nothing
        End Try
    End Sub

    Private Sub DataGrid3_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid3.ItemCommand
        lblMessage.Text = ""
        lblInHouseID.Text = ""
        Select Case e.CommandName
            Case "Delete"
                lblMessage.Text = ""
                Dim oToolIssue As New ToolRoom.Tool("T")
                Try
                    lblInHouseID.Text = e.Item.Cells(5).Text
                    oToolIssue.InHouseID = Val(lblInHouseID.Text)
                    If oToolIssue.InHouseData(True) Then
                        DataClear()
                        lblMessage.Text &= "Record Deleted"
                    Else
                        lblMessage.Text &= "Deletion Failed"
                    End If
                Catch exp As Exception
                    lblMessage.Text &= exp.Message
                Finally
                    oToolIssue = Nothing
                End Try
                Try
                    SetType()
                Catch exp As Exception
                    lblMessage.Text &= exp.Message
                End Try
        End Select
    End Sub
End Class
