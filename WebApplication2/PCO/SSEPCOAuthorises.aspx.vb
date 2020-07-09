Public Class SSEPCOAuthorises
    Inherits System.Web.UI.Page
    Protected WithEvents BtnAllow As System.Web.UI.WebControls.Button
    Protected WithEvents txtAuthorisationRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents chkAutorisableItems As System.Web.UI.WebControls.CheckBoxList
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
            Session("Group") = "SSPCO"
            Session("UserID") = "072442"
            Try
                If IsNothing(Session("group")) OrElse CStr(Session("group")) = "" OrElse IsNothing(Session("userID")) OrElse CStr(Session("UserID")) = "" Then
                    Response.Redirect("InvalidSession.aspx")
                    Exit Sub
                End If
                If Session("group") <> "SSPCO" Then
                    Response.Redirect("InvalidSession.aspx")
                    Exit Sub
                End If
            Catch exp As Exception
                Response.Redirect("InvalidSession.aspx")
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub BtnAllow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAllow.Click
        Dim done As Boolean
        Dim dt As New DataTable()
        Dim dr As DataRow
        dt.TableName = "AUTHORISATION"
        dt.Columns.Add("Authorise")
        Dim i As Integer
        Try
            For i = 0 To chkAutorisableItems.Items.Count - 1
                If chkAutorisableItems.Items(i).Selected = True Then
                    dr = dt.NewRow
                    dr("Authorise") = chkAutorisableItems.Items(i).Value
                    dt.Rows.Add(dr)
                End If
            Next
            done = New PCO.PCO().InsertAuthorisation(dt, CStr(Session("Group")).Trim.ToUpper, Left(CStr(Session("UserID")).Trim, 6), txtAuthorisationRemarks.Text)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            If done Then
                lblMessage.Text = "AUTHORISATION Successfull !"
            Else
                lblMessage.Text &= "AUTHORISATION Failed !"
            End If
        End Try
        done = Nothing
        dt = Nothing
        dr = Nothing
        i = Nothing
    End Sub
End Class
