Public Class FinalTestResultRemark
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtPTremarks1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPTremarks2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPTremarks3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCTremarks1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCTremarks2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCTremarks3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLabnumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents label1 As System.Web.UI.WebControls.Label

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
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        Dim Done As Boolean
        Try
            Done = SaveRemarks()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If Done Then
            lblMessage.Text = "Remarks saved Successfully"
        End If
    End Sub

    Public Function SaveRemarks() As Boolean

        Dim done As Boolean

        Dim Cmd As SqlClient.SqlCommand
        Cmd = rwfGen.Connection.CmdObj

        Cmd.Connection.Open()

        Cmd.CommandText = "insert into Metlab_Results_Remarks values('" & txtLabnumber.Text.Trim & "','" & txtPTremarks1.Text.Trim & "','" & txtPTremarks2.Text.Trim & "', '" & txtPTremarks3.Text.Trim & "',
                   '" & txtCTremarks1.Text.Trim & "', '" & txtCTremarks2.Text.Trim & "', '" & txtCTremarks3.Text.Trim & "' )"
        Try
            If Cmd.Connection.State = ConnectionState.Closed Then Cmd.Connection.Open()

            If Cmd.ExecuteNonQuery() = 1 Then done = True

        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            If Cmd.Connection.State = ConnectionState.Open Then Cmd.Connection.Close()
            Cmd.Dispose()
        End Try
    End Function

End Class