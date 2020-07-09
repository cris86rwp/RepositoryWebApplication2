Public Class rptSpectroChemicalResults
    Inherits System.Web.UI.Page
    Protected WithEvents txtFromDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtToDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnProductNo As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents TextBox1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents TextBox2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button
    Protected WithEvents rblType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rdoProduct As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents Panel4 As System.Web.UI.WebControls.Panel
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Dim Notvalid As Boolean

    'new
    Protected WithEvents labtxt As System.Web.UI.WebControls.TextBox
    Protected WithEvents lab As System.Web.UI.WebControls.Label
    Protected WithEvents testrbl As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents shiftrbl As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents statusrbl As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents labbtn As System.Web.UI.WebControls.Button

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
        If IsPostBack = False Then
            txtFromDate.Text = Now.Date
            txtToDate.Text = Now.Date
            'TextBox1.Text = metLab.tables.Top1JMPHeat
            'TextBox2.Text = metLab.tables.Top1JMPHeat
            TextBox1.Text = "114279"
            TextBox2.Text = "114280"
        End If
    End Sub


    Private Sub btnProductNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProductNo.Click
        If IsNothing(rdoProduct.SelectedItem) = True Then
            lblMessage.Text = " Please select any one Product "
            Exit Sub
        End If
        DataGrid1.Visible = True
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Dim str As String
        Try
            DataGrid1.DataSource = metLab.tables.TestSampleDetails(CDate(txtFromDate.Text.Trim), CDate(txtToDate.Text.Trim), rdoProduct.SelectedItem.Value)
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = "Data grid failed"
        End Try
    End Sub

    Private Sub clear()
        lblMessage.Text = ""
        txtFromDate.Text = Now.Date
        txtToDate.Text = Now.Date
    End Sub

    Private Sub CustomValidator1_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            DataGrid1.DataSource = metLab.tables.JMPDetails(Val(TextBox1.Text.Trim), Val(TextBox2.Text.Trim), rblType.SelectedItem.Value)
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If DataGrid1.Items.Count > 0 Then
            Dim prevstate As Boolean = Me.EnableViewState
            Dim tw As New System.IO.StringWriter()
            Dim hw As New System.Web.UI.HtmlTextWriter(tw)
            Try
                Response.ContentType = "application/vnd.ms_excel"
                Response.Charset = ""
                Me.EnableViewState = False
                DataGrid1.RenderControl(hw)
                Response.Write(tw.ToString)
                Response.End()
                Me.EnableViewState = prevstate
            Catch exp As Exception
                lblMessage.Text = exp.Message
            Finally
            End Try
        Else
            lblMessage.Text = "No Data in Grid to Export !"
        End If
    End Sub

    Protected Sub labbtn_Click(sender As Object, e As EventArgs) Handles labbtn.Click
        Dim shift As String = shiftrbl.SelectedItem.Value.ToString()
        Dim test As String = testrbl.SelectedItem.Value.ToString()
        Dim status As String = statusrbl.SelectedItem.Value.ToString()
        Dim nowDateTime As DateTime = DateTime.Now
        Dim y As String = DateTime.Now.Year.ToString().Substring(2, 2)
        Dim m As String = nowDateTime.Month.ToString().PadLeft(2, "0")
        Dim d As String = nowDateTime.Day.ToString().PadLeft(2, "0")
        Dim fix As String = "TC7603"
        lab.Visible = True
        labtxt.Visible = True
        labtxt.Text = fix + y + test + m + d + shift + status


    End Sub
End Class
