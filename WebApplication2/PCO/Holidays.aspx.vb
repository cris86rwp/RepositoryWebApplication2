Public Class Holidays
    Inherits System.Web.UI.Page
    Protected WithEvents txtFromDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDays As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtToDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents chkMEME As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkMOPO As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkWFPS As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkAMA As System.Web.UI.WebControls.CheckBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents dgHolidays As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnDelete As System.Web.UI.WebControls.Button
    Protected WithEvents ddlReasons As System.Web.UI.WebControls.DropDownList
    Protected WithEvents chkSundays As System.Web.UI.WebControls.CheckBox
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid3 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtReason As System.Web.UI.WebControls.TextBox
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

        If Page.IsPostBack = False Then
            Session("UserID") = "111111"
            'Session("UserID") = "078844"
            PopulateReasons()
            Try
                If IsNothing(Session("UserID")) Then
                    Response.Redirect(Page.ErrorPage)
                    Exit Sub
                End If
            Catch exp As Exception
                Response.Redirect(Page.ErrorPage)
                Exit Sub
            End Try
            PopulateGrid()
            Setfocus(txtFromDate)
        End If
    End Sub
    Private Sub PopulateReasons()
        Dim dt As DataTable
        Try
            dt = PCO.tables.GetHolidayReason
            ddlReasons.DataSource = dt
            ddlReasons.DataTextField = dt.Columns("HolidayReason").ColumnName
            ddlReasons.DataValueField = dt.Columns("HolidayReason").ColumnName
            ddlReasons.DataBind()
            ddlReasons.Items.Insert(0, "Select")
            btnSave.Enabled = True
            btnDelete.Enabled = True
        Catch exp As Exception
            ddlReasons.Items.Clear()
            lblMessage.Text = exp.Message
            btnSave.Enabled = False
            btnDelete.Enabled = False
        Finally
#Disable Warning BC42104 ' Variable is used before it has been assigned a value
            dt.Dispose()
#Enable Warning BC42104 ' Variable is used before it has been assigned a value
            dt = Nothing
        End Try
    End Sub
    Private Sub PopulateGrid()
        Dim ds As DataSet
        Dim Dt As Boolean
        Try
            If txtFromDate.Text.Trim = "" Then
                txtFromDate.Text = Now.Date
                Dt = True
            End If
            ds = PCO.tables.GetHolidayList1(CDate(txtFromDate.Text.Trim), chkMEME.Checked, chkMOPO.Checked, chkWFPS.Checked, chkAMA.Checked)
            If Dt Then
                txtFromDate.Text = ""
            End If
            DataGrid1.DataSource = ds.Tables(0)
            DataGrid1.DataBind()
            DataGrid2.DataSource = ds.Tables(1)
            DataGrid2.DataBind()
            DataGrid3.DataSource = ds.Tables(2)
            DataGrid3.DataBind()
            dgHolidays.DataSource = PCO.tables.GetHolidayList(txtToDate.Text.Trim, txtFromDate.Text.Trim, ddlReasons.SelectedItem.Value, chkMEME.Checked, chkMOPO.Checked, chkWFPS.Checked, chkAMA.Checked)
            dgHolidays.DataBind()
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
    Private Sub txtFromDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFromDate.TextChanged
        lblMessage.Text = ""
        txtDays.Text = ""
        txtToDate.Text = ""
        If CheckDate(txtFromDate.Text) = False Then
            Setfocus(txtFromDate)
            txtFromDate.Text = ""
        Else
            Setfocus(txtDays)
            PopulateGrid()
        End If
    End Sub
    Private Function CheckDate(ByVal sDate As String) As Boolean
        Dim dt1 As Date
        CheckDate = True
        Try
            dt1 = CDate(sDate)
            If dt1 < dt1.Today.Date Then
                lblMessage.Text = " Previous Date : " & txtFromDate.Text.Trim & " "
                CheckDate = False
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message & ":" & txtFromDate.Text
            CheckDate = False
        End Try
        dt1 = Nothing
    End Function
    Private Sub txtDays_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDays.TextChanged
        lblMessage.Text = ""
        Setfocus(txtToDate)
        Dim dt1 As Date
        If IsNumeric(txtDays.Text) Then
            If Val(txtDays.Text) > 0 Then
                txtToDate.Text = ""
                If Val(txtDays.Text) = 1 Then
                    txtToDate.Text = txtFromDate.Text
                Else
                    dt1 = CDate(txtFromDate.Text)
                    dt1 = dt1.AddDays(Val(txtDays.Text) - 1)
                    txtToDate.Text = Format(dt1, "dd/MM/yyyy")
                    PopulateGrid()
                End If
            End If
        Else
            lblMessage.Text = "InValid Days : " & txtDays.Text
            txtDays.Text = ""
            Setfocus(txtDays)
        End If
        dt1 = Nothing
    End Sub
    Private Sub txtToDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtToDate.TextChanged
        lblMessage.Text = ""
        Setfocus(chkMEME)
        txtDays.Text = ""
        If CheckDate(txtToDate.Text) = False Then
            txtToDate.Text = ""
            Exit Sub
        End If
        Dim dt1, dt2 As Date
        dt1 = CDate(txtFromDate.Text)
        dt2 = CDate(txtToDate.Text)
        txtDays.Text = CType(dt2.Subtract(dt1), System.TimeSpan).Days + 1
        PopulateGrid()
        dt1 = Nothing
        dt2 = Nothing
    End Sub

    Private Sub txtReason_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReason.TextChanged
        lblMessage.Text = ""
        Setfocus(btnSave)
        If ddlReasonSelected() = False Then
            AddReason()
        End If
        txtReason.Text = ddlReasons.SelectedItem.Text
        PopulateGrid()
    End Sub
    Private Function ddlReasonSelected() As Boolean
        Dim i As Byte, blnFound As Boolean
        ddlReasons.ClearSelection()
        If txtReason.Text = "Select" Then
            ddlReasons.SelectedIndex = 0
            ddlReasonSelected = True
            Exit Function
        End If
        For i = 0 To ddlReasons.Items.Count - 1
            If ddlReasons.Items(i).Text.ToLower.Trim = txtReason.Text.ToLower.Trim Then
                ddlReasons.Items(i).Selected = True
                blnFound = True
            End If
        Next
        ddlReasonSelected = blnFound
        i = Nothing
        blnFound = Nothing
    End Function
    Private Sub AddReason()
        If txtReason.Text = "Select" Then
            Exit Sub
        End If
        Dim Done As Boolean
        Try
            Done = New PCO.PCO().AddReason(txtReason.Text.ToUpper.Trim)
        Catch exp As Exception

        End Try
        If Done Then
            PopulateReasons()
            ddlReasonSelected()
        End If
        Done = Nothing
    End Sub
    Private Sub MarkControlsAsSelected(ByRef ctrl As Control)
        txtFromDate.BackColor = System.Drawing.Color.White
        txtDays.BackColor = System.Drawing.Color.White
        txtToDate.BackColor = System.Drawing.Color.White
        chkMEME.BackColor = System.Drawing.Color.White
        chkMOPO.BackColor = System.Drawing.Color.White
        chkWFPS.BackColor = System.Drawing.Color.White
        'chkAMA.BackColor = System.Drawing.Color.White
        ddlReasons.BackColor = System.Drawing.Color.White
        txtReason.BackColor = System.Drawing.Color.White
        Select Case ctrl.ID.ToString
            Case "txtFromDate"
                txtFromDate.BackColor = System.Drawing.Color.GreenYellow
            Case "txtDays"
                txtDays.BackColor = System.Drawing.Color.GreenYellow
            Case "txtToDate"
                txtToDate.BackColor = System.Drawing.Color.GreenYellow
            Case "chkMEME"
                chkMEME.BackColor = System.Drawing.Color.GreenYellow
            Case "chkMOPO"
                chkMOPO.BackColor = System.Drawing.Color.GreenYellow
            Case "chkWFPS"
                chkWFPS.BackColor = System.Drawing.Color.GreenYellow
            'Case "chkAMA"
            '    chkAMA.BackColor = System.Drawing.Color.GreenYellow
            Case "ddlReasons"
                ddlReasons.BackColor = System.Drawing.Color.GreenYellow
            Case "txtReason"
                txtReason.BackColor = System.Drawing.Color.GreenYellow
            Case "chkSundays"
                chkSundays.BackColor = System.Drawing.Color.GreenYellow
        End Select
    End Sub
    Private Function ShopCode(ByVal chk As System.Web.UI.WebControls.CheckBox) As String
        Select Case chk.Text
            Case "Melting"
                ShopCode = "MEME"
            Case "Moulding"
                ShopCode = "MOPO"
            Case "WFP Shop"
                ShopCode = "CLCL"
                'Case "Axle Shop"
                '    ShopCode = "AMA"
            Case Else
                Response.Write("Heavenly Shop found in RWF by you !  Please inform MIS Centre without fail.")
        End Select
    End Function

    Private Sub chkMEME_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMEME.CheckedChanged
        lblMessage.Text = ""
        Setfocus(chkMOPO)
        PopulateGrid()
    End Sub

    Private Sub chkMOPO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMOPO.CheckedChanged
        lblMessage.Text = ""
        Setfocus(chkWFPS)
        PopulateGrid()
    End Sub

    Private Sub chkWFPS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkWFPS.CheckedChanged
        lblMessage.Text = ""
        Setfocus(chkAMA)
        PopulateGrid()
    End Sub


    Private Sub chkASS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lblMessage.Text = ""
        Setfocus(ddlReasons)
        PopulateGrid()
    End Sub

    Private Sub chkSundays_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSundays.CheckedChanged
        lblMessage.Text = ""
        txtReason.Text = "SUNDAY"
        AddReason()
        Setfocus(btnSave)
    End Sub
    'Private Sub chkAMA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAMA.CheckedChanged
    '    lblMessage.Text = ""
    '    Setfocus(ddlReasons)
    '    PopulateGrid()
    'End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        Setfocus(txtFromDate)
        If txtReason.Text = "" Then
            lblMessage.Text = "Enter Reason"
            Exit Sub
        End If
        Dim dt1, dt2 As Date
        Try
            dt1 = CDate(txtFromDate.Text.Trim)
            dt2 = CDate(txtToDate.Text.Trim)
            'chkAMA.Text,
            Dim Done As Boolean
            lblMessage.Text = ""
            If chkMEME.Checked = True OrElse chkMOPO.Checked = True OrElse chkWFPS.Checked = True OrElse chkAMA.Checked = True Then
                Done = New PCO.PCO().Holiday(dt1, dt2, txtReason.Text.Trim, chkMEME.Checked, chkMOPO.Checked, chkWFPS.Checked, chkMEME.Text, chkMOPO.Text, chkWFPS.Text, chkSundays.Checked, False)
                'chkAMA.Checked,
                If Done Then
                    lblMessage.Text = "Saved"
                    PopulateGrid()
                Else
                    lblMessage.Text = "Check Inputs!"
                End If
            Else
                lblMessage.Text = "Check atleast one shop"
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
            Exit Sub
        End Try
        dt1 = Nothing
        dt2 = Nothing
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        lblMessage.Text = ""
        Setfocus(txtFromDate)
        Dim dt1, dt2 As Date
        Try
            dt1 = CDate(txtFromDate.Text.Trim)
            dt2 = CDate(txtToDate.Text.Trim)
        Catch exp As Exception
            lblMessage.Text = exp.Message
            Exit Sub
        End Try
        If txtReason.Text = "" Then
            lblMessage.Text = "Enter reason"
            Exit Sub
        End If
        Dim Done As Boolean
        'OrElse chkAMA.Checked = True
        ' chkAMA.Checked,
        If chkMEME.Checked = True OrElse chkMOPO.Checked = True OrElse chkWFPS.Checked = True Then
            Try
                Done = New PCO.PCO().Holiday(dt1, dt2, txtReason.Text.Trim, chkMEME.Checked, chkMOPO.Checked, chkWFPS.Checked, chkMEME.Text, chkMOPO.Text, chkWFPS.Text, chkSundays.Checked, True)
                If Done Then
                    lblMessage.Text = "Deleted"
                Else
                    lblMessage.Text = "Check Inputs!"
                End If
                PopulateGrid()
                If lblMessage.Text = "" Then
                    lblMessage.Text = "Check Inputs!"
                End If
            Catch exp As Exception
                lblMessage.Text &= exp.Message
            End Try
        Else
            lblMessage.Text = "Check atleast one shop"
            Exit Sub
        End If
        dt1 = Nothing
        dt2 = Nothing
    End Sub
    Private Sub ddlReasons_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlReasons.SelectedIndexChanged
        lblMessage.Text = ""
        Setfocus(txtReason)
        txtReason.Text = ""
        chkSundays.Checked = False
        If ddlReasons.SelectedItem.Text.ToLower <> "select" Then
            txtReason.Text = ddlReasons.SelectedItem.Text
        End If
        PopulateGrid()
    End Sub
End Class

