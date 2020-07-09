Public Class BreakDownMemo
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents rblShift As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents lblDepartment_code As System.Web.UI.WebControls.Label
    Protected WithEvents rblShop As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents lblGroupCode As System.Web.UI.WebControls.Label
    Protected WithEvents txtOperator As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMemoslip As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMemo As System.Web.UI.WebControls.Label
    Protected WithEvents ddlMachineCodes As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents rblBDType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents lstBDCodes As System.Web.UI.WebControls.ListBox
    Protected WithEvents radYN As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtFrom_date As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFrom_time As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents btnClear As System.Web.UI.WebControls.Button
    Protected WithEvents btnExit As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents lblMode As System.Web.UI.WebControls.Label
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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        lblMode.Text = "add"
        'Session("UserID") = "013901"
        'Session("Group") = "WHLMLT"
        txtOperator.Text = Session("UserID")
        lblGroupCode.Text = Session("Group")
        lblDepartment_code.Text = "M"
        If Not Page.IsPostBack Then
            Try
                SetDefaultDateTime()
                GetShopCodes()
                getBreakdown_number()
                PopulateMachines()
                GetBDCodes()
                GetBreakDownMemos()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
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
    Private Sub GetShopCodes()
        Dim dt As DataTable
        dt = RWF.BreakDown.GetShopCodes(lblGroupCode.Text)
        rblShop.DataSource = dt
        rblShop.DataTextField = dt.Columns(0).ColumnName
        rblShop.DataValueField = dt.Columns(1).ColumnName
        rblShop.DataBind()
        rblShop.SelectedIndex = 0
        dt = Nothing
    End Sub

    Private Sub SetDefaultDateTime()
        Dim dtshift As New rwfGen.DateShift("ms_breakdown_memo", "breakdown_Date", "memo_number")
        txtDate.Text = dtshift.DefaultDate
        Dim i As Integer
        i = 0
        rblShift.ClearSelection()
        For i = 0 To rblShift.Items.Count - 1
            If rblShift.Items(i).Text.Trim = dtshift.DefaultShift Then
                rblShift.Items(i).Selected = True
                Exit For
            End If
        Next
        txtFrom_date.Text = Now.Date
        txtFrom_time.Text = Right(("0" + Now.Hour.ToString), 2) + ":" + Right(("0" + Now.Minute.ToString), 2)
        i = Nothing
        dtshift = Nothing
    End Sub

    Private Sub getBreakdown_number()
        lblMemo.Text = RWF.BreakDown.GetMemoNumber(lblGroupCode.Text.Trim)
    End Sub

    Private Sub PopulateMachines()
        Dim dt As DataTable
        dt = RWF.BreakDown.GetMachineCodes(lblGroupCode.Text.Trim, rblShop.SelectedItem.Text.Trim)
        ddlMachineCodes.DataSource = dt
        ddlMachineCodes.DataTextField = dt.Columns(0).ColumnName
        ddlMachineCodes.DataValueField = dt.Columns(1).ColumnName
        ddlMachineCodes.DataBind()
        ddlMachineCodes.Items.Insert(0, "Select")
        ddlMachineCodes.SelectedIndex = 0
        dt = Nothing
    End Sub

    Private Sub GetBDCodes(Optional ByVal EqpID As String = "BAK")
        Dim dt As DataTable
        Dim Eqp As String
        If ddlMachineCodes.SelectedItem.Text.Trim.ToLower = "select" Then
            Eqp = EqpID
        Else
            Eqp = ddlMachineCodes.SelectedItem.Value.Substring(2, 3)
        End If
        dt = RWF.BreakDown.GetBDCodes(Eqp, lblGroupCode.Text.Trim)
        rblBDType.DataSource = dt
        rblBDType.DataTextField = dt.Columns(1).ColumnName
        rblBDType.DataValueField = dt.Columns(0).ColumnName
        rblBDType.DataBind()
        rblBDType.ClearSelection()
        Dim i As Integer
        i = 0
        For i = 0 To rblBDType.Items.Count - 1
            If rblBDType.Items(i).Value = "BDM" Then
                rblBDType.Items(i).Selected = True
                Exit For
            End If
        Next
        GetBDCodeDesc()
        dt = Nothing
        Eqp = Nothing
        i = Nothing
    End Sub

    Private Sub rblBDType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblBDType.SelectedIndexChanged
        lblMessage.Text = ""
        If ddlMachineCodes.SelectedItem.Text.Trim.ToLower = "select" Then
            lblMessage.Text = "Please selet Machine Code !"
        Else
            Try
                GetBDCodeDesc()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub rblShop_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblShop.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            PopulateMachines()
            getBreakdown_number()
            GetBDCodes()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub GetBDCodeDesc()
        Dim dt As DataTable
        dt = RWF.BreakDown.GetBDCodeDesc(rblBDType.SelectedItem.Value, ddlMachineCodes.SelectedItem.Value.Substring(2, 3), lblGroupCode.Text.Trim)
        lstBDCodes.DataSource = dt
        lstBDCodes.DataTextField = dt.Columns(0).ColumnName
        lstBDCodes.DataValueField = dt.Columns(1).ColumnName
        lstBDCodes.DataBind()
        dt = Nothing
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        clear()
    End Sub

    Private Sub clear()
        SetDefaultDateTime()
        txtMemoslip.Text = ""
        ddlMachineCodes.SelectedIndex = 0
        txtRemarks.Text = ""
        lstBDCodes.ClearSelection()
        lstBDCodes.Items.Clear()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Server.Transfer("/mms/selectModule.aspx")
    End Sub

    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        lblMessage.Text = ""
        If txtDate.Text <> "" Then
            If CDate(Trim(txtDate.Text)) > Now Then
                lblMessage.Text = "Date Can't be Greater Than Current Date"
                txtDate.Text = ""
                btnSave.Enabled = False
                Exit Sub
            ElseIf CDate(Trim(txtDate.Text)) < DateAdd(DateInterval.Day, -7, Now.Date) Then
                lblMessage.Text = "Date Can't be too early to Current Date"
                txtDate.Text = ""
                btnSave.Enabled = False
                Exit Sub
            Else
                Try
                    lblMessage.Text = ""
                    btnSave.Enabled = True
                    GetBreakDownMemos()
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                End Try
            End If
        End If
    End Sub

    Private Sub GetBreakDownMemos()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        DataGrid1.DataSource = RWF.BreakDown.GetBDDetails(lblGroupCode.Text.Trim, CDate(Trim(txtDate.Text)), rblShift.SelectedItem.Text.Trim)
        DataGrid1.DataBind()
    End Sub

    Private Sub rblShift_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblShift.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            GetBreakDownMemos()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub ddlMachineCodes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMachineCodes.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            GetBDCodes()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtFrom_date_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFrom_date.TextChanged
        btnSave.Enabled = True
        If txtDate.Text = "" Then
            lblMessage.Text = "Please Enter The date"
            Exit Sub
        End If
        If CDate(Trim(txtFrom_date.Text)) > CDate(Trim(txtDate.Text)) Then
            If rblShift.SelectedItem.Text.Trim <> "C" Then
                lblMessage.Text = "Start Date Can't be Greater Than Current Date or BreakDown Date"
                txtFrom_date.Text = ""
                btnSave.Enabled = False
                Exit Sub
            Else
                If CDate(Trim(txtFrom_date.Text)) > DateAdd(DateInterval.Day, 1, CDate(Trim(txtDate.Text))) Then
                    lblMessage.Text = "Start Date Can't be Greater Than Current Date or BreakDown Date"
                    txtFrom_date.Text = ""
                    btnSave.Enabled = False
                    Exit Sub
                End If
            End If
        ElseIf CDate(Trim(txtFrom_date.Text)) < CDate(Trim(txtDate.Text)) Then
            lblMessage.Text = "Start Date Can't be lesser Than  BreakDown Date"
            txtFrom_date.Text = ""
            btnSave.Enabled = False
            Exit Sub
        Else
            lblMessage.Text = ""
            btnSave.Enabled = True
        End If
    End Sub

    Private Sub txtMemoslip_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMemoslip.TextChanged
        If Val(txtMemoslip.Text) = 0 Then
            lblMessage.Text = "Invalid memoslip number " & txtMemoslip.Text.Trim
            txtMemoslip.Text = ""
            Exit Sub
        End If
        If RWF.BreakDown.MemoSlipNumber(lblGroupCode.Text.Trim, txtMemoslip.Text.Trim) Then
            lblMessage.Text = "Already used Memo Slip : " & txtMemoslip.Text
            txtMemoslip.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        If Trim(txtDate.Text) = "" Then
            lblMessage.Text = "Data Not Saved , Enter the breakdown Date...."
            Exit Sub
        End If
        Try
            If lstBDCodes.SelectedIndex = -1 Then
                lblMessage.Text = "Data Not Saved , Please select any BDCode ! "
                Exit Sub
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        Dim i As Int16
        If (txtFrom_time.Text.IndexOf(":") <> 1 AndAlso txtFrom_time.Text.IndexOf(":") <> 2) Then
            lblMessage.Text = "Data Not Saved, InValid From Time ! "
            txtFrom_time.Text = ""
            Exit Sub
        End If
        If RWF.BreakDown.CheckFrDate(CDate(txtDate.Text), rblShift.SelectedItem.Text, CDate(txtFrom_date.Text).Year.ToString + "-" + CDate(txtFrom_date.Text).Month.ToString.PadLeft(2, "0").Substring(0, 2) + "-" + CDate(txtFrom_date.Text).Day.ToString.PadLeft(2, "0").Substring(0, 2) + " " + txtFrom_time.Text.Trim) = False Then
            lblMessage.Text = "Data Not Saved, Please check BkDown date & shift with BkD Start Date & Time !"
            Exit Sub
        End If

        If RWF.BreakDown.MemoNumber(lblGroupCode.Text.Trim, txtMemoslip.Text.Trim, lblMemo.Text) > 0 Then
            lblMessage.Text = "Entry Already Exists For This " & lblGroupCode.Text & " Group"
            lblMessage.Text &= "<br> and This" & lblMemo.Text & " Memo Number"
            lblMessage.Text &= "<br> and This" & txtMemoslip.Text & " Memo Slip Number"
            Exit Sub
        End If
        Dim counter As Integer
        Dim flag As Boolean
        flag = True
        If flag = True Then
            For counter = 0 To Me.lstBDCodes.Items.Count - 1
                If Me.lstBDCodes.Items(counter).Selected = True Then flag = True
            Next
        End If
        If flag = False Then
            lblMessage.Text = "Please select code for breakdown"
            Exit Sub
        End If
        If Trim(rblShift.SelectedItem.Text).ToLower = "c" Then
            If CDate(Trim(txtDate.Text)) = CDate(txtFrom_date.Text) Then
                If CDate(txtFrom_date.Text & " " & txtFrom_time.Text).Hour = 22 OrElse CDate(txtFrom_date.Text & " " & txtFrom_time.Text).Hour = 23 Then
                Else
                    lblMessage.Text = "Breakdown Date & Shift compared with  Breakdown From Time does not match ! Data Not Saved !"
                    Exit Sub
                End If
            Else
                If CDate(Trim(txtDate.Text)) = CDate(txtFrom_date.Text).AddDays(-1) Then
                    If CDate(txtFrom_date.Text & " " & txtFrom_time.Text).Hour = 0 OrElse CDate(txtFrom_date.Text & " " & txtFrom_time.Text).Hour = 1 OrElse CDate(txtFrom_date.Text & " " & txtFrom_time.Text).Hour = 2 OrElse CDate(txtFrom_date.Text & " " & txtFrom_time.Text).Hour = 3 OrElse CDate(txtFrom_date.Text & " " & txtFrom_time.Text).Hour = 4 OrElse CDate(txtFrom_date.Text & " " & txtFrom_time.Text).Hour = 5 Then
                    Else
                        lblMessage.Text = "Breakdown Date & Shift compared with   Breakdown From Time does not match ! Data Not Saved !"
                        Exit Sub
                    End If
                Else
                    lblMessage.Text = "Breakdown Date & Shift compared with   Breakdown From Time does not match !  Data Not Saved !"
                    Exit Sub
                End If
            End If
        End If
        Dim BDMemo As New RWF.BreakDown()
        Try
            BDMemo.Group = lblGroupCode.Text.Trim
            BDMemo.MemoSlip = txtMemoslip.Text.Trim
            BDMemo.BDCode = lstBDCodes.SelectedItem.Value.Trim
            BDMemo.MemoNo = CInt(lblMemo.Text)
            BDMemo.BDFromTime = CDate(txtFrom_date.Text & " " & txtFrom_time.Text)
            BDMemo.Remarks = txtRemarks.Text.Trim
            BDMemo.BDDate = CDate(txtDate.Text)
            BDMemo.Shift = rblShift.SelectedItem.Text.Trim
            BDMemo.Shop = rblShop.SelectedItem.Text.Trim
            BDMemo.Machine = ddlMachineCodes.SelectedItem.Value.Trim
            BDMemo.Operator1 = txtOperator.Text.Trim
            BDMemo.Aff = radYN.SelectedItem.Value
            BDMemo.BDType = rblBDType.SelectedItem.Value
            If BDMemo.SaveMemo Then lblMessage.Text = "Break Down Registered.Thank You"
            clear()
            getBreakdown_number()
        Catch exp As Exception
            lblMessage.Text = BDMemo.Message + " ;" + exp.Message
        End Try
        Try
            GetBreakDownMemos()
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
        i = Nothing
        counter = Nothing
        flag = Nothing
        BDMemo = Nothing
    End Sub


End Class
