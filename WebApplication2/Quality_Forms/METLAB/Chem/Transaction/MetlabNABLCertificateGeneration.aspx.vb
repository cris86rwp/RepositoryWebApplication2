Public Class MetlabNABLCertificateGeneration
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents rblNABLType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblTestType As System.Web.UI.WebControls.RadioButtonList
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
        Dim labno, na, tt As String
        labno = txtLabnumber.Text.Trim
        tt = rblTestType.SelectedItem.Value.Trim
        na = rblNABLType.SelectedItem.Value.Trim
        Try
            Done = generateCertificate(labno, tt, na)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If Done Then
            lblMessage.Text = "Certificate Generated Successfully"
        End If
    End Sub

    Public Function generateCertificate(ByVal labnumber As String, ByVal TestType As String, ByVal NABLType As String) As Boolean

        Dim done As Boolean

        Dim Cmd As SqlClient.SqlCommand
        Cmd = rwfGen.Connection.CmdObj

        Cmd.Connection.Open()

        Cmd.Parameters.Add("@labnumber", SqlDbType.VarChar, 10).Value = labnumber
        Cmd.Parameters.Add("@TestType", SqlDbType.VarChar, 2).Value = TestType
        Cmd.Parameters.Add("@NABLType", SqlDbType.VarChar, 1).Value = NABLType
        Cmd.CommandText = "exec ms_sp_NABLCertGen_Metlab @labnumber ,@TestType , @NABLType "
        Try
            If Cmd.Connection.State = ConnectionState.Closed Then Cmd.Connection.Open()
            ''  Cmd.ExecuteScalar()
            If Cmd.ExecuteNonQuery = 1 Then
                done = True
            Else
                done = False
            End If

        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            If Cmd.Connection.State = ConnectionState.Open Then Cmd.Connection.Close()
            Cmd.Dispose()
        End Try
    End Function

    Protected Sub rblTestType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblTestType.SelectedIndexChanged
        label1.Text = txtLabnumber.Text.Trim + rblTestType.SelectedItem.Value + rblNABLType.SelectedItem.Value
    End Sub

    Protected Sub rblNABLType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblNABLType.SelectedIndexChanged

    End Sub

End Class


