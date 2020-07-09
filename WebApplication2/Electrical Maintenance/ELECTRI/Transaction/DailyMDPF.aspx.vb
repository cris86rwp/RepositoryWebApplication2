Public Class DailyMDPF
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtPF As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMD As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSubmit_Clicks As System.Web.UI.WebControls.Button
    Protected WithEvents txtMDTrippings As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTotalTime As System.Web.UI.WebControls.TextBox
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnExit As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents txtConsumptionDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtHr As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtShootUpDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMin As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMVA As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblSL As System.Web.UI.WebControls.Label
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox

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
        lblSL.Visible = False
        If Page.IsPostBack = False Then
            txtDate.Text = Now.Date
            txtConsumptionDate.Text = Now.Date
            txtShootUpDate.Text = Now.Date
            txtHr.Text = "00"
            txtMin.Text = "00"
            Dim DT As Date
            Try
                DT = txtDate.Text.Trim
                GetData()
                GetShootUpMD()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            Finally
            End Try
        End If
    End Sub

    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        lblMessage.Text = ""
        Dim DT As Date
        Try
            DT = txtDate.Text.Trim
            GetData()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
        End Try
    End Sub

    Private Sub GetData()
        Dim dt As DataTable
        txtPF.Text = ""
        txtMD.Text = ""
        txtMDTrippings.Text = ""
        txtTotalTime.Text = ""
        Try
            dt = Maintenance.ElecTables.DailyMDPF(CDate(txtDate.Text))
            If dt.Rows.Count > 0 Then
                txtPF.Text = IIf(IsDBNull(dt.Rows(0)("PowerFactor")), 0, dt.Rows(0)("PowerFactor"))
                txtMD.Text = IIf(IsDBNull(dt.Rows(0)("RecordedMD")), 0, dt.Rows(0)("RecordedMD"))
                txtMDTrippings.Text = IIf(IsDBNull(dt.Rows(0)("MDTrippings")), 0, dt.Rows(0)("MDTrippings"))
                txtTotalTime.Text = IIf(IsDBNull(dt.Rows(0)("TotalTime")), 0, dt.Rows(0)("TotalTime"))
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
        End Try
    End Sub

    Private Sub GetShootUpMD()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            DataGrid1.DataSource = Maintenance.ElecTables.ShootUpMD(CDate(txtConsumptionDate.Text))
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnSubmit_Clicks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit_Clicks.Click
        Dim Done As Boolean
        Dim slno As Integer
        Try
            Done = New Maintenance.Electrical().DailyMDPF(CDate(txtDate.Text), Val(txtMD.Text), Val(txtPF.Text.Trim), Val(txtMDTrippings.Text), Val(txtTotalTime.Text.Trim))
        Catch exp As Exception
            lblMessage.Text = " InValid Data !"
            Exit Sub
        End Try
        If Done Then
            lblMessage.Text = " Updation Successful !"
        Else
            lblMessage.Text &= " Updation Failed !"
        End If
    End Sub

    Private Sub txtConsumptionDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtConsumptionDate.TextChanged
        lblMessage.Text = ""
        Try
            GetShootUpMD()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        lblMessage.Text = ""
        Dim Hr, Min As String
        Dim ShootUpDate As DateTime
        Dim Done As Boolean
        Try
            Hr = "0" + txtHr.Text
            Min = "0" + txtMin.Text
            ShootUpDate = CDate(txtShootUpDate.Text) & " " & Right(Hr, 2) + ":" + Right(Min, 2)

            Done = New Maintenance.Electrical().SaveShootUpMD(CDate(txtConsumptionDate.Text), ShootUpDate, Val(txtMVA.Text), Val(lblSL.Text))

        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If Done Then
            Try
                GetShootUpMD()
            Catch exp As Exception
                lblMessage.Text &= exp.Message
            End Try
            lblMessage.Text &= " Updation Successful !"
        Else
            lblMessage.Text &= " Updation Failed !"
        End If
    End Sub

    Private Sub DataGrid1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.ItemCommand
        lblMessage.Text = ""
        lblSL.Text = ""
        Try
            Select Case e.CommandName
                Case "Select"
                    txtConsumptionDate.Text = e.Item.Cells(1).Text.Replace("&nbsp;", "").Trim
                    'txtRecQty.Text = e.Item.Cells(10).Text.Replace("&nbsp;", "").Trim
            End Select
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Protected Sub txtMin_TextChanged(sender As Object, e As EventArgs) Handles txtMin.TextChanged
        lblSL.Visible = True
        lblSL.Text = GETSL()
    End Sub
    Private Function GETSL() As Integer

        'Dim oDs As New DataSet()
        'Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        'oDa.SelectCommand.Parameters.Add("@ConsumptionDate", SqlDbType.SmallDateTime, 4).Value = CDate(txtDate.Text)
        'oDa.SelectCommand.CommandText = "select MAX(Sl) from  ms_ShootUpMD WHERE ConsumptionDate=@ConsumptionDate "
        Dim Cmd As System.Data.SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Cmd.Parameters.Add("@Cons", SqlDbType.Int, 4).Direction = ParameterDirection.Output
        Cmd.Parameters.Add("@ConsumptionDate", SqlDbType.SmallDateTime, 4).Value = CDate(txtDate.Text)
        Cmd.CommandText = "select @Cons =MAX(Sl) from  ms_ShootUpMD WHERE ConsumptionDate=@ConsumptionDate "
        Try
            If Cmd.Connection.State = ConnectionState.Closed Then Cmd.Connection.Open()
            Cmd.ExecuteScalar()
            GETSL = IIf(IsDBNull(Cmd.Parameters("@Cons").Value), 0, Cmd.Parameters("@Cons").Value)
        Catch exp As Exception
            GETSL = 0
            Throw New Exception(exp.Message)
        Finally
            If Cmd.Connection.State = ConnectionState.Open Then Cmd.Connection.Close()
            Cmd.Dispose()
        End Try
    End Function
End Class
