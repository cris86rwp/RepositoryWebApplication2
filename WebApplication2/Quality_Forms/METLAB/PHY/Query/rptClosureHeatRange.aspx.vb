Public Class rptClosureHeatRange
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtFromDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtToDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents btnProductNo As System.Web.UI.WebControls.Button
    Protected WithEvents CustomValidator1 As System.Web.UI.WebControls.CustomValidator
    Protected WithEvents pnlProductNo As System.Web.UI.WebControls.Panel
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents rblChoice As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents ddlWheelType As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnDesp As System.Web.UI.WebControls.Button
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Dim Notvalid As Boolean

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
        btnDesp.Visible = False
        If IsPostBack = False Then
            Notvalid = False
            txtFromDate.Text = Now.Date
            txtToDate.Text = Now.Date
            GetWheelTypes()
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
            ddlWheelType.Items.Insert(0, New ListItem("ALL", "ALL"))
            ddlWheelType.SelectedIndex = 0
        Catch exp As Exception
            Throw New Exception(exp.Message)
        End Try
    End Sub
    Private Sub btnProductNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProductNo.Click
        DataGrid1.Visible = True
        DataGrid1.DataSource = Nothing
        Dim str As String
        If Notvalid Then
            DataGrid1.Visible = False
            DataGrid1.DataSource = Nothing
            Exit Sub
        End If
        Try
            DataGrid1.DataSource = metLab.tables.WheelHardnessTestValues(CDate(txtFromDate.Text.Trim), CDate(txtToDate.Text.Trim), rblChoice.SelectedIndex, ddlWheelType.SelectedItem.Value)
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub clear()
        lblMessage.Text = ""
        txtFromDate.Text = ""
        txtToDate.Text = ""
    End Sub
    Private Sub CustomValidator1_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CustomValidator1.ServerValidate
        lblMessage.Text = ""
        Dim dt1, dt2 As Date
        Dim dt1IsValid, dt2IsValid As Boolean
        dt1IsValid = False
        dt2IsValid = False
        Try
            dt1 = txtFromDate.Text.Trim
            dt1IsValid = True
            dt2 = txtToDate.Text.Trim
            dt2IsValid = True
            If dt1 > Today.Date Then
                lblMessage.Text = "From Date:'" & txtFromDate.Text.Trim & "' Can Not Be Greater Than Current Date. "
                txtFromDate.Text = ""
            End If

            If dt2 > Today.Date Then
                lblMessage.Text &= "To Date:'" & txtToDate.Text.Trim & "' Can Not Be Greater Than Current Date. "
                txtToDate.Text = ""
            End If

            If dt1 > dt2 Then
                lblMessage.Text &= "From Date is more than To Date ! (From :" & txtFromDate.Text & " To : " & txtToDate.Text & "). "
                txtFromDate.Text = ""
                txtToDate.Text = ""
            End If

        Catch exp As Exception
            If exp.Message.StartsWith("Cast") Then
                If dt1IsValid = False Then
                    lblMessage.Text &= " From Date:'" & txtFromDate.Text.Trim & "'  is not Valid. "
                    txtFromDate.Text = ""
                ElseIf dt2IsValid = False Then
                    lblMessage.Text &= " To Date:'" & txtToDate.Text.Trim & "'  is not Valid. "
                    txtToDate.Text = ""
                End If
            End If
        End Try
        If txtFromDate.Text = "" Or txtToDate.Text = "" Then
            Notvalid = True
        End If
    End Sub

    Private Sub btnDesp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDesp.Click
        DataGrid1.Visible = True
        DataGrid1.DataSource = Nothing
        Dim str As String
        If Notvalid Then
            DataGrid1.Visible = False
            DataGrid1.DataSource = Nothing
            Exit Sub
        End If
        Try
            DataGrid1.DataSource = metLab.tables.LabStatusForDespatchedWheels(CDate(txtFromDate.Text.Trim), CDate(txtToDate.Text.Trim))
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
End Class
