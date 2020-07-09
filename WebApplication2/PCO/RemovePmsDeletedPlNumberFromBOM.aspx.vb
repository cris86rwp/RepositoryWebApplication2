Public Class RemovePmsDeletedPlNumberFromBOM
    Inherits System.Web.UI.Page
    Protected WithEvents txtPlNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnRemove As System.Web.UI.WebControls.Button
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtLtrNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtLtrDt As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator3 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents lblLoggedIn As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
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
            Try
                Session("UserID") = "072442"
                Dim oLogInEmp As New rwfGen.Employee()
                If oLogInEmp.Check(Session("UserID") & "", "PCOPCO") = False Then
                    lblMessage.Text = "Invalid Access to this Program."
                    Exit Sub
                End If
                btnRemove.Visible = True
                oLogInEmp = Nothing
            Catch exp As Exception
                lblMessage.Text = "Access Control Check Failed : " & exp.Message
            End Try
            If lblMessage.Text = "" Then
                lblLoggedIn.Text = Session("UserID") & ""
            Else
                btnRemove.Visible = False
            End If
        End If
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        lblMessage.Text = ""
        Try
            Dim oLogInEmp As New rwfGen.Employee()
            If oLogInEmp.Check(Session("UserID") & "", "PCOPCO") = False Then
                lblMessage.Text = "Invalid Access to this Program."
                Exit Sub
            End If
            oLogInEmp = Nothing
        Catch exp As Exception
            lblMessage.Text = "Access Control Check Failed : " & exp.Message
        End Try
        If lblMessage.Text <> "" Then
            Exit Sub
        End If
        Dim blnDeleted As Boolean
        Try
            blnDeleted = New PCO.PCO().DeletePLFromBOM(Session("UserID"), txtLtrNo.Text.Trim & " dtd " & CDate(txtLtrDt.Text).Date.ToString, txtPlNumber.Text.Trim.ToUpper)
        Catch exp As Exception
            lblMessage.Text = " Delete Error : " & exp.Message
        Finally
            If blnDeleted Then
                lblMessage.Text = "PL Number Removed from bill of material successfully. : " & txtPlNumber.Text
            Else
                lblMessage.Text &= "Deleted PL Number : " & txtPlNumber.Text
            End If
            txtPlNumber.Text = ""
        End Try
        blnDeleted = Nothing
    End Sub
End Class
