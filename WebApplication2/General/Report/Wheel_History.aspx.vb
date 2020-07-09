Public Class Wheel_History
    Inherits System.Web.UI.Page
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents BtnShow As System.Web.UI.WebControls.Button
    Protected WithEvents rfvld2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents lblerr As System.Web.UI.WebControls.Label
    Protected WithEvents txtWheel As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtHeat As System.Web.UI.WebControls.TextBox
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList



    Shared themeValue As String

    Public Sub New()

        AddHandler PreInit, New EventHandler(AddressOf Page_PreInit)
    End Sub

    Private Sub Page_PreInit(ByVal sender As Object, ByVal e As EventArgs)

        Page.Theme = themeValue
    End Sub


    Protected Sub Dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub

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
        'Response.Redirect("http://reportserver/mmsreports/clrmag/Wheel_History.aspx")
    End Sub

    Private Sub BtnShow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnShow.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=26464&user0=sa&password0=sadev123" &
            "&prompt0=" & txtWheel.Text & "&prompt1=" & txtHeat.Text & "" &
        "&promptex0=" & txtWheel.Text & "&promptex1=" & txtHeat.Text & "" &
        "&user0@Magna.rpt=sa&password0@Magna.rpt=sadev123" &
        "&user0@FinalInsp.rpt=sa&password0@FinalInsp.rpt=sadev123" &
        "&user0@Machining.rpt=sa&password0@Machining.rpt=sadev123" &
        "&user0@UnBoreInsp.rpt=sa&password0@UnBoreInsp.rpt=sadev123" &
        "&user0@YardInsp.rpt=sa&password0@YardInsp.rpt=sadev123" &
        "&user0@QCIInsp.rpt=sa&password0@QCIInsp.rpt=sadev123" &
        "&user0@LooseWheelDesp.rpt=sa&password0@LooseWheelDesp.rpt=sadev123"
        Response.Redirect(strPathName)
    End Sub

    Private Sub txtHeat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHeat.TextChanged
        If Not IsNumeric(txtHeat.Text) Then
            txtHeat.Text = ""
            lblerr.Text = "Enter Numeric Value"
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Not IsNumeric(txtHeat.Text) Then
            txtHeat.Text = ""
            lblerr.Text = "Enter Numeric Value"
            Exit Sub
        End If
        Dim dt As New DataTable()
        Try
            dt = RWF.tables.SetWOforGivenWheel(Val(txtWheel.Text), Val(txtHeat.Text))
            DataGrid1.DataSource = dt
            DataGrid1.DataBind()
        Catch exp As Exception
            lblerr.Text = exp.Message
        Finally
            dt.Dispose()
        End Try
    End Sub
End Class
