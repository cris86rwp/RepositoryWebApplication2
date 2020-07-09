Public Class BHNSampleSendAdd
    Inherits System.Web.UI.Page
    Protected WithEvents btnExit As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
    Protected WithEvents rfvtoheat As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtHeatTo As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfvfrheat As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtHeatFrom As System.Web.UI.WebControls.TextBox
    Protected WithEvents RangeValidator1 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblLab As System.Web.UI.WebControls.Label
    Protected WithEvents rblShift As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents lblInsp As System.Web.UI.WebControls.Label
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents grdReadings As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnSubmit As System.Web.UI.WebControls.Button
    Protected WithEvents lblLabNumber As System.Web.UI.WebControls.Label
    Protected WithEvents rblWhClass As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents pnlHelp As System.Web.UI.WebControls.Panel
    Protected WithEvents chkHelp As System.Web.UI.WebControls.CheckBox
    Protected WithEvents rblTesttype As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents ddlWheelType As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlWheel As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtHeatNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents pnlExperimental As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlRegular As System.Web.UI.WebControls.Panel
    Protected WithEvents txtWheelNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents chkForce As System.Web.UI.WebControls.CheckBox
    Protected WithEvents txtExpectedTestDate As System.Web.UI.WebControls.TextBox
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
        Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None
        'Put user code to initialize the page here
        'Session("UserID") = "074940"
        If Not IsPostBack Then
            txtExpectedTestDate.Text = Now.Date
            chkForce.Enabled = False
            txtDate.ReadOnly = True
            pnlHelp.Visible = False
            txtHeatFrom.ReadOnly = True
            txtHeatTo.ReadOnly = True
            txtDate.Text = Date.Today
            lblInsp.Text = CType(Session("UserID"), String)
            Try
                GetWheelTypes()
                GetClass()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            Setfocus(txtDate)
            If rblTesttype.SelectedIndex = 0 Then
                pnlRegular.Visible = True
                pnlExperimental.Visible = False
            Else
                pnlRegular.Visible = False
                pnlExperimental.Visible = True
            End If
        End If
    End Sub

    Private Sub GetWheelTypes()
        ddlWheelType.DataSource = Nothing
        ddlWheelType.DataBind()
        Dim dt As New DataTable()
        Try
            dt = metLab.tables.GetWheelTypes()
            ddlWheelType.DataSource = dt
            ddlWheelType.DataTextField = dt.Columns(0).ColumnName
            ddlWheelType.DataValueField = dt.Columns(1).ColumnName
            ddlWheelType.DataBind()
            ddlWheelType.SelectedIndex = 0
            BindGrid()
        Catch exp As Exception
            Throw New Exception(exp.Message)
        End Try
    End Sub

    Private Sub BindGrid(Optional ByVal iPageNo As Integer = 0)
        chkForce.Checked = False
        chkForce.Enabled = False
        Dim dt As New DataTable()
        Try
            grdReadings.SelectedIndex = -1
            dt = metLab.tables.GetHeatRangeForHardnessTest(ddlWheelType.SelectedItem.Value.Trim, chkForce.Checked)
            If dt.Rows.Count > 0 Then
                grdReadings.DataSource = dt
                grdReadings.CurrentPageIndex = iPageNo
                grdReadings.DataBind()
            Else
                chkForce.Enabled = True
                Throw New Exception("No wheels for selected WheelType or TestType !")
            End If
        Catch exp As Exception
            grdReadings.DataSource = Nothing
            grdReadings.DataBind()
            Throw New Exception(exp.Message)
        Finally
            dt.Dispose()
        End Try
    End Sub

    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        lblMessage.Text = ""
        Dim d As Date
        Try
            d = CDate(txtDate.Text)
            If d.Compare(d, Date.Today) > 0 Then
                lblMessage.Text = "Date Should Not Be More Than Today"
                txtDate.Text = ""
                Exit Sub
            End If
            Setfocus(ddlWheelType)
        Catch exp As Exception
            txtDate.Text = ""
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub rblTesttype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblTesttype.SelectedIndexChanged
        lblMessage.Text = ""
        txtHeatFrom.Text = ""
        txtHeatTo.Text = ""
        txtWheelNumber.Text = ""
        txtHeatNumber.Text = ""
        Try
            ddlWheel.Items.Clear()
            ddlWheel.ClearSelection()
            txtHeatNumber.Text = ""
            If rblTesttype.SelectedIndex = 0 Then
                pnlRegular.Visible = True
                pnlExperimental.Visible = False
                BindGrid()
            Else
                grdReadings.DataSource = Nothing
                grdReadings.DataBind()
                pnlRegular.Visible = False
                pnlExperimental.Visible = True
                GetClass()
            End If
            Setfocus(btnSubmit)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub GetClass()
        lblMessage.Text = ""
        rblWhClass.ClearSelection()
        Dim WhClass As String
        Try
            WhClass = metLab.tables.GetClass(ddlWheelType.SelectedItem.Value)
            If WhClass.Trim.Length > 0 Then
                Dim i As Int16 = 0
                For i = 0 To rblWhClass.Items.Count - 1
                    If Trim(WhClass) = rblWhClass.Items(i).Value.Trim Then
                        rblWhClass.Items(i).Selected = True
                    End If
                Next
            Else
                Clear()
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub Validity(ByVal myheat As Long)
        Try
            If Not metLab.tables.GetHeatValidity(myheat) Then
                lblMessage.Text = " Heat No. " & myheat & " is Invalid or doesn't exist..."
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub Setfocus(ByVal ctrl As Control)
        'Define the JavaScript function for the specefied control.
        Dim focusScript As String = "<script language = 'javascript'>" & _
        "document.getElementById('" + ctrl.ClientID & _
        "').focus();</script>"
        'Add the JavaScript code to the page.
        Page.RegisterStartupScript("FocusScript", focusScript)
        ' MarkControlsAsSelected(ctrl)
    End Sub

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim Done As New Boolean()
        If lblMessage.Text.Trim.Length > 0 Then
            Exit Sub
        End If
        Try
            If rblTesttype.SelectedIndex = 0 Then
                Dim n As New metLab.RegularTest(ReturnWheel(ddlWheel.SelectedItem.Text.Trim), ReturnHeat(ddlWheel.SelectedItem.Text.Trim), txtHeatFrom.Text, txtHeatTo.Text)
                Session("n") = n
                CType(Session("n"), metLab.RegularTest).WheelNumber = ReturnWheel(ddlWheel.SelectedItem.Text.Trim)
                CType(Session("n"), metLab.RegularTest).HeatNumber = ReturnHeat(ddlWheel.SelectedItem.Text.Trim)
                Done = True
                Try
                    CType(Session("n"), metLab.RegularTest).inspector = lblInsp.Text
                    CType(Session("n"), metLab.RegularTest).sent_date = CDate(txtDate.Text)
                    CType(Session("n"), metLab.RegularTest).shift_code = rblShift.SelectedItem.Value
                    CType(Session("n"), metLab.RegularTest).HeatFrom = Val(txtHeatFrom.Text.Trim)
                    CType(Session("n"), metLab.RegularTest).HeatTo = Val(txtHeatTo.Text.Trim)
                    CType(Session("n"), metLab.RegularTest).LabNumber = CType(Session("n"), metLab.RegularTest).GetLabNumber
                    CType(Session("n"), metLab.RegularTest).wheel = ddlWheel.SelectedItem.Text.Trim
                    CType(Session("n"), metLab.RegularTest).wheel_class = rblWhClass.SelectedItem.Value
                    CType(Session("n"), metLab.RegularTest).TestType = rblTesttype.SelectedItem.Text.Trim
                    CType(Session("n"), metLab.RegularTest).WheelType = ddlWheelType.SelectedItem.Text
                    Try
                        CType(Session("n"), metLab.RegularTest).expected_test_date = CDate(txtExpectedTestDate.Text)
                    Catch exp As Exception
                        CType(Session("n"), metLab.RegularTest).expected_test_date = Now.Date
                    End Try
                    If CType(Session("n"), metLab.RegularTest).SaveSample(CType(Session("n"), metLab.RegularTest).TestType) Then
                        Done = True
                        Clear()
                        BindGrid()
                    End If
                Catch exp As Exception
                    lblMessage.Text = exp.Message & "; " & CType(Session("n"), metLab.RegularTest).Message
                End Try
                If Done Then
                    lblLabNumber.Text = CType(Session("n"), metLab.RegularTest).LabNumber
                    lblMessage.Text = "Data Saved !"
                Else
                    lblMessage.Text &= "Data Not Saved !"
                End If
            Else
                Dim n As New metLab.ExperimentalTest(txtWheelNumber.Text, txtHeatNumber.Text, txtHeatFrom.Text, txtHeatTo.Text)
                Session("n") = n
                CType(Session("n"), metLab.ExperimentalTest).WheelNumber = Val(txtWheelNumber.Text.Trim)
                CType(Session("n"), metLab.ExperimentalTest).HeatNumber = Val(txtHeatNumber.Text.Trim)
                Done = True
                Try
                    CType(Session("n"), metLab.ExperimentalTest).inspector = lblInsp.Text
                    CType(Session("n"), metLab.ExperimentalTest).sent_date = CDate(txtDate.Text)
                    CType(Session("n"), metLab.ExperimentalTest).shift_code = rblShift.SelectedItem.Value
                    CType(Session("n"), metLab.ExperimentalTest).HeatFrom = Val(txtHeatFrom.Text.Trim)
                    CType(Session("n"), metLab.ExperimentalTest).HeatTo = Val(txtHeatTo.Text.Trim)
                    CType(Session("n"), metLab.ExperimentalTest).LabNumber = CType(Session("n"), metLab.ExperimentalTest).GetLabNumber
                    CType(Session("n"), metLab.ExperimentalTest).wheel = txtWheelNumber.Text.Trim + "/" + txtHeatNumber.Text.Trim
                    CType(Session("n"), metLab.ExperimentalTest).wheel_class = rblWhClass.SelectedItem.Value
                    CType(Session("n"), metLab.ExperimentalTest).TestType = rblTesttype.SelectedItem.Text.Trim
                    CType(Session("n"), metLab.ExperimentalTest).WheelType = ddlWheelType.SelectedItem.Text
                    If CType(Session("n"), metLab.ExperimentalTest).SaveSample(CType(Session("n"), metLab.ExperimentalTest).TestType) Then
                        Done = True
                        Clear()
                        BindGrid()
                    End If
                Catch exp As Exception
                    lblMessage.Text = exp.Message & "; " & CType(Session("n"), metLab.ExperimentalTest).Message
                End Try
                If Done Then
                    lblLabNumber.Text = CType(Session("n"), metLab.ExperimentalTest).LabNumber
                    lblMessage.Text = "Data Saved !"
                Else
                    lblMessage.Text &= "Data Not Saved !"
                End If
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Server.Transfer("/mss/selectModule.aspx")
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Clear()
    End Sub

    Private Sub Clear()
        txtHeatFrom.Text = ""
        txtHeatTo.Text = ""
        lblLabNumber.Text = ""
        ddlWheel.Items.Clear()
    End Sub

    Private Sub chkHelp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHelp.CheckedChanged
        lblMessage.Text = ""
        pnlHelp.Visible = False
        If chkHelp.Checked Then
            pnlHelp.Visible = True
        End If
    End Sub

    Private Sub ddlWheelType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlWheelType.SelectedIndexChanged
        lblMessage.Text = ""
        If rblTesttype.SelectedIndex = 0 Then
            Try
                BindGrid()
                GetClass()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub grdReadings_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdReadings.ItemCommand
        lblMessage.Text = ""
        Dim dt As New DataTable()
        ddlWheel.DataSource = Nothing
        ddlWheel.DataBind()
        Try
            If e.CommandName = "Select" Then
                txtHeatFrom.Text = e.Item.Cells(2).Text.Trim
                txtHeatTo.Text = e.Item.Cells(3).Text.Trim
                dt = metLab.tables.GetXCWheels(txtHeatFrom.Text, txtHeatTo.Text, ddlWheelType.SelectedItem.Text.Trim)
                If dt.Rows.Count > 0 Then
                    ddlWheel.DataSource = dt
                    ddlWheel.DataTextField = dt.Columns(0).ColumnName
                    ddlWheel.DataValueField = dt.Columns(0).ColumnName
                    ddlWheel.DataBind()
                Else
                    dt = metLab.tables.GetGoodWheels(txtHeatFrom.Text, txtHeatTo.Text, ddlWheelType.SelectedItem.Text.Trim)
                    ddlWheel.DataSource = dt
                    ddlWheel.DataTextField = dt.Columns(0).ColumnName
                    ddlWheel.DataValueField = dt.Columns(0).ColumnName
                    ddlWheel.DataBind()
                End If
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
        End Try
    End Sub

    Private Sub grdReadings_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdReadings.PageIndexChanged
        lblMessage.Text = ""
        txtHeatFrom.Text = ""
        txtHeatTo.Text = ""
        ddlWheel.Items.Clear()
        ddlWheel.ClearSelection()
        txtHeatNumber.Text = ""
        Try
            BindGrid(e.NewPageIndex)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtHeatNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHeatNumber.TextChanged
        lblMessage.Text = ""
        If rblTesttype.SelectedIndex = 1 Then
            If txtHeatNumber.Text.Trim.Length > 0 And Val(txtHeatNumber.Text) > 0 And txtWheelNumber.Text.Trim.Length > 0 And Val(txtWheelNumber.Text) > 0 Then
                Try
                    Check()
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                End Try
            End If
        End If
    End Sub

    Private Sub txtWheelNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWheelNumber.TextChanged
        lblMessage.Text = ""
        If rblTesttype.SelectedIndex = 1 Then
            If txtWheelNumber.Text.Trim.Length > 0 And Val(txtWheelNumber.Text) > 0 And txtHeatNumber.Text.Trim.Length > 0 And Val(txtHeatNumber.Text) > 0 Then
                Try
                    Check()
                    Setfocus(txtHeatNumber)
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                End Try
            End If
        End If
    End Sub

    Private Sub Check()
        lblMessage.Text = ""
        txtHeatFrom.Text = ""
        txtHeatTo.Text = ""
        Dim done As New Boolean()
        Try
            done = metLab.tables.CheckValidity(Val(txtHeatNumber.Text), Val(txtWheelNumber.Text))
            If done Then
                txtHeatFrom.Text = Val(txtHeatNumber.Text)
                txtHeatTo.Text = Val(txtHeatNumber.Text)
            Else
                txtWheelNumber.Text = ""
                txtHeatNumber.Text = ""
                Throw New Exception("InValid Wheel !")
            End If
        Catch exp As Exception
            Throw New Exception(exp.Message)
        End Try
    End Sub
    Private Function ReturnWheel(ByVal mystr As String) As String
        Dim myarray As Array
        Dim mywheel, myheat As String
        If mystr <> "" Then
            myarray = Split(mystr, "/")
            mywheel = myarray(0)
            myheat = myarray(1)
            Return mywheel
        End If
    End Function
    Private Function ReturnHeat(ByVal mystr As String) As String
        Dim myarray As Array
        Dim mywheel, myheat As String
        If mystr <> "" Then
            myarray = Split(mystr, "/")
            mywheel = myarray(0)
            myheat = myarray(1)
            Return myheat
        End If
    End Function

    Private Sub chkForce_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkForce.CheckedChanged
        If chkForce.Checked Then
            Dim dt As New DataTable()
            Try
                grdReadings.SelectedIndex = -1
                dt = metLab.tables.GetHeatRangeForHardnessTest(ddlWheelType.SelectedItem.Value.Trim, 1)
                If dt.Rows.Count > 0 Then
                    grdReadings.DataSource = dt
                    grdReadings.DataBind()
                Else
                    chkForce.Enabled = True
                    Throw New Exception("No wheels for selected WheelType or HeatRange !")
                End If
            Catch exp As Exception
                grdReadings.DataSource = Nothing
                grdReadings.DataBind()
                lblMessage.Text = exp.Message
            Finally
                dt.Dispose()
            End Try
        End If
    End Sub
End Class
