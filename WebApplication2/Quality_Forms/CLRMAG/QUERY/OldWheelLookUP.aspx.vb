Public Class OldWheelLookUP
    Inherits System.Web.UI.Page
    Protected WithEvents lblwhlno As System.Web.UI.WebControls.Label
    Protected WithEvents txtwhl As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblHeatNo As System.Web.UI.WebControls.Label
    Protected WithEvents txtHeatNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblWheel As System.Web.UI.WebControls.Label
    Protected WithEvents txtWheelNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnShow As System.Web.UI.WebControls.Button
    Protected WithEvents dgOldWheelDetails As System.Web.UI.WebControls.DataGrid
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
    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        Dim sqlstr As String
        If txtwhl.Text <> "" Then
            sqlstr = "select "
            sqlstr &= " wheel_number, heat_number,location, wheel_sts Status , mag_sts magnaglow_status, bhn_rate, ut_sts ut_status, desp_nt_no  despatch_note_number "
            sqlstr &= " from mms_not_regularly_used.dbo.mm_mmwhlpre where wheel_no = '" & txtwhl.Text & "'"
        ElseIf txtWheelNo.Text <> "" And txtHeatNo.Text <> "" Then
            sqlstr = "select "
            sqlstr &= " wheel_number, heat_number,location, wheel_sts Status , mag_sts magnaglow_status, bhn_rate, ut_sts ut_status, desp_nt_no  despatch_note_number "
            sqlstr &= " from mms_not_regularly_used.dbo.mm_mmwhlpre where wheel_number = " & txtWheelNo.Text & " and heat_number = " & txtHeatNo.Text
        ElseIf txtWheelNo.Text = "" And txtHeatNo.Text <> "" Then
            sqlstr = "select "
            sqlstr &= " wheel_number, heat_number,location, wheel_sts Status , mag_sts magnaglow_status, bhn_rate, ut_sts ut_status, desp_nt_no  despatch_note_number "
            sqlstr &= " from mms_not_regularly_used.dbo.mm_mmwhlpre where heat_number = " & txtHeatNo.Text & " order by wheel_number "
        ElseIf txtWheelNo.Text <> "" And txtHeatNo.Text = "" Then
            sqlstr = "select "
            sqlstr &= " wheel_number, heat_number,location, wheel_sts Status , mag_sts magnaglow_status, bhn_rate, ut_sts ut_status, desp_nt_no  despatch_note_number "
            sqlstr &= " from mms_not_regularly_used.dbo.mm_mmwhlpre where wheel_number = " & txtWheelNo.Text & " order by heat_number "
        Else

            sqlstr = ""
        End If
        If sqlstr <> "" Then
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = "sqlstr"
                da.Fill(ds)
                dgOldWheelDetails.DataSource = ds.Tables(0).DefaultView
                dgOldWheelDetails.DataBind()
                dgOldWheelDetails.Visible = True
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        Else
            dgOldWheelDetails.Visible = False
        End If
    End Sub
End Class
