Public Class NewMachineryMasterDelete
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtMachine As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDescription As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblSerialNumber As System.Web.UI.WebControls.Label
    Protected WithEvents txtAuthority As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
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
        Session("UserId") = "013397"
        Session("UserId") = "037920"
        If Page.IsPostBack = False Then
            lblSerialNumber.Visible = False
            '    If Session("UserId") = "013397" OrElse Session("UserId") = "037920" Then
            '    Else
            '        Response.Redirect("wap\InvalidSession.aspx")
            '        Exit Sub
            '    End If
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


    Private Sub txtMachine_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMachine.TextChanged
        lblMessage.Text = ""
        lblSerialNumber.Text = ""
        If txtMachine.Text.Trim.Length = 0 Then
            lblMessage.Text = "Please enter Machine Code !"
        Else
            Dim dt As DataTable
            Try
                dt = Maintenance.tables.MachineCodeName(txtMachine.Text.ToUpper)
                If dt.Rows.Count > 0 Then
                    txtDescription.Text = dt.Rows(0)("description") & ""
                    lblSerialNumber.Text = dt.Rows(0)("serial_number") & ""
                    txtMachine.Text = txtMachine.Text.ToUpper
                Else
                    lblMessage.Text = "InValid Machine Code !"
                End If
            Catch exp As Exception
                dt = Nothing
                lblMessage.Text = exp.Message
            Finally
                dt.Dispose()
            End Try
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        Dim done As Boolean
        Try
            done = New Maintenance.Machinery().MachineDelete(txtMachine.Text, txtDescription.Text.Trim, txtAuthority.Text.Trim, txtRemarks.Text.Trim, Val(lblSerialNumber.Text))
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If done Then
            lblMessage.Text = "Data Deleted !"
            txtMachine.Text = ""
            txtDescription.Text = ""
            txtRemarks.Text = ""
        Else
            lblMessage.Text = "Data Not Deleted !"
        End If
    End Sub
End Class
