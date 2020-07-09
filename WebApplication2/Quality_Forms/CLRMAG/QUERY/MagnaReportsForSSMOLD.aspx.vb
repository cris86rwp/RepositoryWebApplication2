Public Class MagnaReportsForSSMOLD
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtHeatNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button
    Protected WithEvents Button3 As System.Web.UI.WebControls.Button
    Protected WithEvents Button4 As System.Web.UI.WebControls.Button
    Protected WithEvents Button5 As System.Web.UI.WebControls.Button
    Protected WithEvents rblLine As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents Button6 As System.Web.UI.WebControls.Button
    Protected WithEvents Button7 As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents rblShift As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents Button8 As System.Web.UI.WebControls.Button
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel

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
        If Page.IsPostBack = False Then
            txtDate.Text = Now.Date
        End If
    End Sub
    Private Sub FillGrid(ByVal Number As Integer)
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        If Number = 1 Then
            da.SelectCommand.CommandText = "mm_sp_Magna_302Details"
            da.SelectCommand.Parameters.Add("@HeatNo", SqlDbType.BigInt, 8).Value = Val(txtHeatNo.Text)
        ElseIf Number = 2 Then
            da.SelectCommand.CommandText = "mm_sp_Magna_FIScore"
            da.SelectCommand.Parameters.Add("@Date", SqlDbType.SmallDateTime, 4).Value = CDate(txtDate.Text)
        ElseIf Number = 3 Then
            da.SelectCommand.CommandText = "mm_sp_Magna_HourlyStatus"
            da.SelectCommand.Parameters.Add("@Date", SqlDbType.SmallDateTime, 4).Value = CDate(txtDate.Text)
        ElseIf Number = 4 Then
            da.SelectCommand.CommandText = "mm_sp_Magna_Score"
            da.SelectCommand.Parameters.Add("@Date", SqlDbType.SmallDateTime, 4).Value = CDate(txtDate.Text)
        ElseIf Number = 5 Then
            da.SelectCommand.CommandText = "mm_sp_Magna_OffloadScore"
            da.SelectCommand.Parameters.Add("@Date", SqlDbType.SmallDateTime, 4).Value = CDate(txtDate.Text)
        ElseIf Number = 6 Then
            da.SelectCommand.CommandText = "mm_sp_Magna_WheelsSaved"
            da.SelectCommand.Parameters.Add("@Date", SqlDbType.SmallDateTime, 4).Value = CDate(txtDate.Text)
            da.SelectCommand.Parameters.Add("@Line", SqlDbType.VarChar, 3).Value = rblLine.SelectedItem.Text.Trim
            da.SelectCommand.Parameters.Add("@Shift", SqlDbType.VarChar, 3).Value = ""
        ElseIf Number = 7 Then
            da.SelectCommand.CommandText = "mm_sp_magna_XC_Score"
            da.SelectCommand.Parameters.Add("@Date", SqlDbType.SmallDateTime, 4).Value = CDate(txtDate.Text)
        ElseIf Number = 8 Then
            da.SelectCommand.CommandText = "mm_sp_Magna_WheelsSaved"
            da.SelectCommand.Parameters.Add("@Date", SqlDbType.SmallDateTime, 4).Value = CDate(txtDate.Text)
            da.SelectCommand.Parameters.Add("@Line", SqlDbType.VarChar, 3).Value = rblLine.SelectedItem.Text.Trim
            da.SelectCommand.Parameters.Add("@Shift", SqlDbType.VarChar, 3).Value = rblShift.SelectedItem.Text.Trim
        End If

        Try
            da.Fill(ds)
            DataGrid1.DataSource = ds.Tables(0).Copy
            DataGrid1.DataBind()
        Catch exp As Exception
            DataGrid1.DataSource = Nothing
            DataGrid1.DataBind()
            lblMessage.Text = exp.Message
        Finally
            da.Dispose()
            ds.Dispose()
            ds = Nothing
            da = Nothing
        End Try
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        FillGrid(1)
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        FillGrid(2)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        FillGrid(3)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        FillGrid(4)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        FillGrid(5)
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        FillGrid(6)
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        FillGrid(7)
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        FillGrid(8)
    End Sub
End Class
