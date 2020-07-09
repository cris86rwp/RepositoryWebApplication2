Public Class HSDConsumption1
    Inherits System.Web.UI.Page
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents rblDataPoints As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents lblShop As System.Web.UI.WebControls.Label
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblConsumption As System.Web.UI.WebControls.Label
    Protected WithEvents txtPreDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents Panel2 As System.Web.UI.WebControls.Panel
    Protected WithEvents txtPreMeterReading As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMeterReading As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents DD1 As System.Web.UI.WebControls.DropDownList
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


    Protected Sub Dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = DD1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        'Put user code to initialize the page here
        If Page.IsPostBack = False Then
            txtDate.Text = Now.Date
            Session("UserID") = "078844"
            Session("Group") = "SSMOLD"
            Dim dt As DataTable
            Try
                dt = UtilityShop.DataTables.DataPointsList(Session("Group"), "MSS")
                rblDataPoints.DataSource = dt
                rblDataPoints.DataTextField = dt.Columns(0).ColumnName
                rblDataPoints.DataValueField = dt.Columns(0).ColumnName
                rblDataPoints.DataBind()
                rblDataPoints.SelectedIndex = 0
                lblShop.Text = dt.Rows(0)(1)
                GetValue()
                GetGridData()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            Finally
                dt.Dispose()
            End Try
        End If
    End Sub
    'Private Sub Setfocus(ByVal ctrl As Control)
    '    'Define the JavaScript function for the specefied control.
    '    Dim focusScript As String = "<script language = 'javascript'>" & _
    '    "document.getElementById('" + ctrl.ClientID & _
    '    "').focus();</script>"
    '    'Add the JavaScript code to the page.
    '    Page.RegisterStartupScript("FocusScript", focusScript)
    '    ' MarkControlsAsSelected(ctrl)
    'End Sub

    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        lblMessage.Text = ""
        Dim dt As New Date()
        Try
            dt = CDate(txtDate.Text)
            If dt > Now.Date Then
                txtDate.Text = Now.Date
                lblMessage.Text = "Date cannot be greater than Today !"
            ElseIf Not dt > CDate(txtPreDate.Text) Then
                txtDate.Text = Now.Date
                lblMessage.Text = "Date cannot be less than or equal to PreDate !"
            Else
                txtDate.Text = dt
                GetGridData()
            End If
        Catch exp As Exception
            txtDate.Text = ""
            lblMessage.Text = exp.Message
        End Try
        txtMeterReading.Text = 0
        lblConsumption.Text = 0
    End Sub
    Private Sub GetValue()
        Dim dt, dt1 As DataTable
        Try
            dt = UtilityShop.DataTables.PreDatePointValue(rblDataPoints.SelectedItem.Text)
            If dt.Rows.Count > 0 Then
                txtPreDate.Text = dt.Rows(0)("DataDate")
                txtPreMeterReading.Text = dt.Rows(0)("MeterReading")
                lblConsumption.Text = dt.Rows(0)("Consumption")
                txtRemarks.Text = IIf(IsDBNull(dt.Rows(0)("Remarks")), "", dt.Rows(0)("Remarks"))
                dt1 = UtilityShop.DataTables.NextPointValue(CDate(txtPreDate.Text), rblDataPoints.SelectedItem.Text)
                If dt1.Rows.Count > 0 Then
                    txtDate.Text = dt1.Rows(0)("DataDate")
                    txtMeterReading.Text = dt1.Rows(0)("MeterReading")
                    If lblConsumption.Text = 0 Then
                        lblConsumption.Text = dt1.Rows(0)("MeterReading") - dt.Rows(0)("MeterReading")
                    End If
                Else
                    txtDate.Text = Now.Date
                    txtMeterReading.Text = 0
                End If
                dt1.Dispose()
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
        End Try
    End Sub
    Private Sub GetGridData()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Dim dt As DataTable
        Try
            dt = UtilityShop.DataTables.HSDConsumption(Session("Group"), CDate(txtPreDate.Text))
            DataGrid1.DataSource = dt
            DataGrid1.DataBind()
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            dt.Dispose()
        End Try
    End Sub

    Private Sub rblDataPoints_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblDataPoints.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            GetValue()
            GetGridData()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtPreDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPreDate.TextChanged
        lblMessage.Text = ""
        Dim dt, dt1 As DataTable
        Try
            dt = UtilityShop.DataTables.PointValue(CDate(txtPreDate.Text), rblDataPoints.SelectedItem.Text)
            If dt.Rows.Count > 0 Then
                txtPreDate.Text = dt.Rows(0)("DataDate")
                txtPreMeterReading.Text = IIf(IsDBNull(dt.Rows(0)("MeterReading")), "", dt.Rows(0)("MeterReading"))
                lblConsumption.Text = IIf(IsDBNull(dt.Rows(0)("Consumption")), "", dt.Rows(0)("Consumption"))
                txtRemarks.Text = IIf(IsDBNull(dt.Rows(0)("Remarks")), "", dt.Rows(0)("Remarks"))
                dt1 = UtilityShop.DataTables.NextPointValue(CDate(txtPreDate.Text), rblDataPoints.SelectedItem.Text)
                If dt1.Rows.Count > 0 Then
                    txtDate.Text = dt1.Rows(0)("DataDate")
                    txtMeterReading.Text = IIf(IsDBNull(dt1.Rows(0)("MeterReading")), "", dt1.Rows(0)("MeterReading"))
                    If lblConsumption.Text = 0 Then
                        lblConsumption.Text = txtMeterReading.Text - txtPreMeterReading.Text
                    End If
                Else
                    txtDate.Text = Now.Date
                    txtMeterReading.Text = 0
                End If
                dt1.Dispose()
            Else
                txtPreDate.Text = CDate(txtPreDate.Text)
                txtPreMeterReading.Text = 0
                lblConsumption.Text = 0
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
        End Try
        Try
            GetGridData()
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
    End Sub

    Private Sub txtPreMeterReading_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPreMeterReading.TextChanged
        lblMessage.Text = ""
        txtPreMeterReading.Text = Val(txtPreMeterReading.Text)
    End Sub

    Private Sub txtMeterReading_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMeterReading.TextChanged
        lblMessage.Text = ""
        txtMeterReading.Text = Val(txtMeterReading.Text)
        lblConsumption.Text = Val(txtMeterReading.Text) - Val(txtPreMeterReading.Text)
        If Val(lblConsumption.Text) < 0 Then
            txtMeterReading.Text = 0
            lblMessage.Text = "InValid Consumption Value !"
            Exit Sub
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Val(lblConsumption.Text) < 0 Then
            lblMessage.Text = "InValid Consumption Value !"
            Exit Sub
        End If
        Try
            lblMessage.Text = New UtilityShop.FlowMeter().Save(rblDataPoints.SelectedItem.Text, CDate(txtPreDate.Text), Val(txtPreMeterReading.Text), Val(lblConsumption.Text), txtRemarks.Text.Trim, CDate(txtDate.Text), Val(txtMeterReading.Text), Session("UserID"))
            GetGridData()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
End Class
