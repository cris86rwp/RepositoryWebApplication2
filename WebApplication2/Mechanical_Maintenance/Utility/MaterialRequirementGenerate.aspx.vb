Public Class MaterialRequirementGenerate
    Inherits System.Web.UI.Page
    Protected WithEvents lblConsignee As System.Web.UI.WebControls.Label
    Protected WithEvents rblType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblYear As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnShow As System.Web.UI.WebControls.Button
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    Shared themeValue As String
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
    Private Sub Page_PreInit(ByVal sender As Object, ByVal e As EventArgs)

        Page.Theme = themeValue
    End Sub
    Public Sub New()

        AddHandler PreInit, New EventHandler(AddressOf Page_PreInit)
    End Sub
    Protected Sub dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Page.IsPostBack = False Then
            lblMessage.Text = ""
            'Session("Group") = "MW2"
            'Session("UserID") = "073533"
            Dim Group As String = Session("Group")
            Dim UserId As String = Session("UserID")
            Dim InValid As Boolean = False
            'Group = "MW1"
            'UserId = "077585"
            Try
                lblConsignee.Text = CriticalItems.ItemTables.GetConsignee(Group, UserId)
                If lblConsignee.Text.Trim.Length = 4 Then InValid = True
                PopulateRBLs()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            If Not InValid Then
                'Response.Redirect("/wap/logon.aspx")
            End If
        End If
    End Sub
    Private Sub PopulateRBLs()
        lblMessage.Text = ""
        rblYear.DataSource = Nothing
        rblYear.DataBind()
        Dim dvPLNumber As New DataView()
        Try
            dvPLNumber.Table = CriticalItems.ItemTables.GetConsigneeMaterialPlYears(lblConsignee.Text)
            rblYear.DataSource = dvPLNumber
            rblYear.DataTextField = dvPLNumber.Table.Columns(0).ColumnName
            rblYear.DataValueField = dvPLNumber.Table.Columns(0).ColumnName
            rblYear.DataBind()
            rblYear.SelectedIndex = 0
            If rblYear.Items.Count < 1 Then
                lblMessage.Text = "Items for '" & lblConsignee.Text & "' not existing !"
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        lblMessage.Text = ""
        Dim done As Boolean
        Dim Cmd As System.Data.SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.CommandText = "ms_sp_MaterialRequirementItemListGenerate"
            Cmd.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = lblConsignee.Text.Trim
            Cmd.Parameters.Add("@StockType", SqlDbType.VarChar, 20).Value = rblType.SelectedItem.Text.Trim
            Cmd.Parameters.Add("@Year", SqlDbType.VarChar, 10).Value = rblYear.SelectedItem.Text.Trim
            If Cmd.Connection.State = ConnectionState.Closed Then Cmd.Connection.Open()
            If Cmd.ExecuteNonQuery > 0 Then
                done = True
            End If
        Catch exp As Exception
            lblMessage.Text = " Not generated. " & exp.Message
        Finally
            If Cmd.Connection.State = ConnectionState.Open Then Cmd.Connection.Close()
            Cmd.Dispose()
        End Try
        If done Then
            lblMessage.Text = "Generated successfully !"
        End If
    End Sub
End Class
