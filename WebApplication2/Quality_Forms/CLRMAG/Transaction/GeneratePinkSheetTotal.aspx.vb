Public Class GeneratePinkSheetTotal
    Inherits System.Web.UI.Page
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents btnGenerate As System.Web.UI.WebControls.Button
    Protected WithEvents chkReGenerate As System.Web.UI.WebControls.CheckBox
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid

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
        Session("UserID") = "078844"
        Session("Group") = "CLRMAG"
        If Session("UserID") = Nothing Then
            Response.Redirect("/mms/InvalidSession.aspx")
            Exit Sub
        End If
        If CType(Session("Group"), System.String).ToLower <> "clrmag" Then
            Response.Redirect("/mms/InvalidSession.aspx")
            Exit Sub
        End If
        If Page.IsPostBack = False Then
            chkReGenerate.Visible = False
            Try
                txtDate.Text = RWF.Magna.GetTop1MagnaDate
            Catch exp As Exception
                lblMessage.Text = ""
            End Try
        End If
    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        lblMessage.Text = ""
        Dim Err As Boolean
        Try
            txtDate.Text = CDate(txtDate.Text)
            lblMessage.Text = RWF.Magna.CheckPinkDate(CDate(txtDate.Text), chkReGenerate.Visible, chkReGenerate.Checked)
        Catch exp As Exception
            lblMessage.Text = IIf(exp.Message.StartsWith("Cast from"), "InValid Date !", exp.Message)
            Err = True
            Exit Try
        End Try
        If Err Then Exit Sub
        If lblMessage.Text.StartsWith("Authorise") Then
            txtDate.Text = ""
            chkReGenerate.Visible = True
            Exit Sub
        ElseIf lblMessage.Text.Trim.Length > 0 Then
            txtDate.Text = ""
            Exit Sub
        End If
        Err = False
        Try
            If New RWF.Magna().GeneratePinkSheet(CDate(txtDate.Text)) Then lblMessage.Text = "Pink Sheet Generated"
        Catch exp As Exception
            Err = True
            lblMessage.Text = "Pink Sheet not generated: " & exp.Message
        End Try
        If Not Err Then
            DataGrid1.DataSource = Nothing
            DataGrid1.DataBind()
            Try
                DataGrid1.DataSource = RWF.Magna.PinkGridDetails(CDate(txtDate.Text))
                DataGrid1.DataBind()
            Catch exp As Exception
                lblMessage.Text &= exp.Message
            End Try
        End If
        Err = Nothing
    End Sub

    Private Sub CheckDate(ByRef dt As Date)
        If txtDate.Text = "" Then
            Exit Sub
        End If
        Dim DLastPinkDate As Date
        Try
            dt = CDate(txtDate.Text & " 00:00:00")
            If dt >= Today Then
                lblMessage.Text = "You cannot generate pink sheet for : " & txtDate.Text
                txtDate.Text = ""
                Exit Sub
            End If
            Dim sqlcomm As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            sqlcomm.CommandText = "select top 1 @Pink_Date = pink_date from mm_pink_sheet order by pink_date desc "
            sqlcomm.CommandType = CommandType.Text
            sqlcomm.Parameters.Add("@Pink_Date", SqlDbType.DateTime, 8)
            sqlcomm.Parameters("@Pink_Date").Direction = ParameterDirection.Output
            Try
                sqlcomm.Connection.Open()
                sqlcomm.ExecuteScalar()
                DLastPinkDate = sqlcomm.Parameters("@Pink_Date").Value

                If dt >= Today Then
                    lblMessage.Text = "You cannot Generate pink sheet for : " & txtDate.Text
                    txtDate.Text = ""
                ElseIf dt < DLastPinkDate Then
                    lblMessage.Text = "You cannot Re-Generate previous pink sheets. Input Date : " & txtDate.Text & " is rejected."
                    txtDate.Text = ""
                ElseIf dt = DLastPinkDate Then
                    If chkReGenerate.Visible = True Then
                        If chkReGenerate.Checked = False Then
                            lblMessage.Text = "You have not authorised Re-Generation for : " & txtDate.Text
                            txtDate.Text = ""
                        End If
                    Else
                        chkReGenerate.Visible = True
                        lblMessage.Text = "Authorise Re-Generation by Ticking Re-Generate check box."
                        txtDate.Text = ""
                    End If
                End If
            Catch exp1 As Exception
                lblMessage.Text = exp1.Message & ":" & txtDate.Text
                txtDate.Text = ""
            Finally
                If sqlcomm.Connection.State = ConnectionState.Open Then
                    sqlcomm.Connection.Close()
                End If
                sqlcomm.Dispose()
                DLastPinkDate = Nothing
                sqlcomm = Nothing
            End Try
        Catch exp As Exception
            lblMessage.Text = exp.Message & " : " & txtDate.Text
            txtDate.Text = ""
        End Try
    End Sub
    Private Function NoDataInputs() As Boolean
        '  Return False
        Dim sqlcmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        sqlcmd.CommandText = "select top 1 @cnt = count(wheel_number) from mm_magnaglow_results where test_date = @Test_Date"
        sqlcmd.Parameters.Add("@Test_Date", SqlDbType.DateTime, 8)
        sqlcmd.Parameters("@Test_Date").Direction = ParameterDirection.Input
        sqlcmd.Parameters("@Test_Date").Value = CDate(txtDate.Text)
        sqlcmd.Parameters.Add("@cnt", SqlDbType.Int, 4)
        sqlcmd.Parameters("@cnt").Direction = ParameterDirection.Output
        Dim i As Integer
        Try
            sqlcmd.Connection.Open()
            sqlcmd.ExecuteReader()
            i = sqlcmd.Parameters("@cnt").Value
            If i = Nothing Or i = 0 Then
                NoDataInputs = True
            Else
                NoDataInputs = False
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message & " : " & txtDate.Text
            txtDate.Text = ""
            NoDataInputs = True
        Finally
            If sqlcmd.Connection.State = ConnectionState.Open Then
                sqlcmd.Connection.Close()
            End If
            sqlcmd.Dispose()
            sqlcmd = Nothing
            i = Nothing
        End Try
    End Function

End Class
