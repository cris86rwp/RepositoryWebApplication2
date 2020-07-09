Imports System.Data.SqlClient

Public Class Log
    Inherits System.Web.UI.Page
    Protected WithEvents label1 As System.Web.UI.WebControls.Label
    Protected WithEvents label2 As System.Web.UI.WebControls.Label
    Protected WithEvents ec As System.Web.UI.WebControls.TextBox
    Protected WithEvents pswd As System.Web.UI.WebControls.TextBox
    Protected WithEvents login As System.Web.UI.WebControls.Button
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub login_Click(sender As Object, e As EventArgs) Handles login.Click

        Dim Ecode As String = ec.Text
        Dim Pass As String = pswd.Text

        Dim con As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
        con.Open()
        Dim cmd As New SqlCommand("SELECT COUNT(*) FROM menu_your_password_new where employee_code=@Ecode and password=@Pass ", con)
        cmd.Parameters.AddWithValue("@Ecode", Ecode)
        cmd.Parameters.AddWithValue("@Pass", Pass)
        Dim i As Integer = Convert.ToInt32(cmd.ExecuteScalar())
        cmd = Nothing

        Dim s As New SqlCommand("Select role_id from menu_your_password_new where employee_code=@Ecode and password=@Pass", con)
        s.Parameters.AddWithValue("@Ecode", Ecode)
        s.Parameters.AddWithValue("@Pass", Pass)
        Session("role") = s.ExecuteScalar()

        Dim rl As String = Session("role")
        Dim s2 As New SqlCommand("Select permission from role_permission where role_id=@rl", con)
        s2.Parameters.AddWithValue("@rl", rl)

        Session("permission") = s2.ExecuteScalar()
        con.Close()

        If i >= 1 Then
            ' Session("Group") = Grp
            Session("Ecode") = Ecode
            'Session("Apps") = App
            Response.Redirect("WapGroupset.aspx")
            'Response.Write(Session("Ecode"))
        Else
            'lblmessage.Visible = True
            'lblmessage.Text = "invalid login"
            Response.Write("Invalid Login")
        End If
    End Sub

End Class