Public Class ProdPreHeatedLadleNo
    Inherits System.Web.UI.Page
    Protected WithEvents lblSl As System.Web.UI.WebControls.Label
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblConsignee As System.Web.UI.WebControls.Label
    Protected WithEvents rblLadleNo As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents lblLadleNo As System.Web.UI.WebControls.Label
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtPreHeatDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents DataGrid3 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
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


    Protected Sub Dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        'Put user code to initialize the page here
        lblSl.Visible = False
        If IsPostBack = False Then
            Dim Group As String = Session("Group")
            Dim UserId As String = Session("UserID")
            Dim InValid As Boolean = False
            ''''''''''''''''
            'Session("Group") = "SSMELT"
            'Session("UserID") = "074510"
            'Group = "SSMELT"
            'UserId = "074510"
            ''''''''''''''''
            Try
                lblConsignee.Text = ProductionConsumables.GetConsignee(Group, UserId)
                If lblConsignee.Text.Trim.Length = 4 Then InValid = True
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            'If Not InValid Then
            '    Response.Redirect("/mss/logon.aspx")
            'Else
            Try
                    txtPreHeatDate.Text = Now.Date
                    Dim dt As DataTable
                    dt = ProductionConsumables.GetLadleNo
                    rblLadleNo.DataSource = dt
                    rblLadleNo.DataTextField = dt.Columns(0).ColumnName
                    rblLadleNo.DataValueField = dt.Columns(0).ColumnName
                    rblLadleNo.DataBind()
                    rblLadleNo.SelectedIndex = 0
                    lblLadleNo.Text = rblLadleNo.SelectedItem.Text
                    FillGrid()
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                End Try
            End If
        'End If
    End Sub

    Private Sub FillGrid()
        Dim ds As DataSet
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        DataGrid3.DataSource = Nothing
        DataGrid3.DataBind()
        Try
            ds = ProductionConsumables.PreHeatedLadleDetails(CDate(txtPreHeatDate.Text), rblLadleNo.SelectedItem.Text)
            DataGrid1.DataSource = ds.Tables(0)
            DataGrid1.DataBind()
            DataGrid2.DataSource = ds.Tables(1)
            DataGrid2.DataBind()
            DataGrid3.DataSource = ds.Tables(2)
            DataGrid3.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub rblLadleNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblLadleNo.SelectedIndexChanged
        lblMessage.Text = ""
        lblLadleNo.Text = rblLadleNo.SelectedItem.Text
        FillGrid()
    End Sub

    Private Sub txtPreHeatDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPreHeatDate.TextChanged
        lblMessage.Text = ""
        FillGrid()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        Dim done As Boolean
        Try
            done = New ProductionConsumables().SavePreHeatedLadleDetails(rblLadleNo.SelectedItem.Text, CDate(txtPreHeatDate.Text))
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If done Then
            FillGrid()
            lblMessage.Text &= "  Data Saved !"
        Else
            lblMessage.Text &= "  Data Saving Failed !"
        End If
    End Sub

    Private Sub DataGrid3_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid3.ItemCommand
        lblMessage.Text = ""
        lblSl.Text = ""
        Try
            Select Case e.CommandName
                Case "Delete"
                    Dim Group As String = Session("Group")
                    Dim UserId As String = Session("UserID")
                    If Group = "SSMELT" AndAlso UserId = "074510" Then
                        Try
                            lblSl.Text = e.Item.Cells(3).Text.Trim
                            If New ProductionConsumables().DeletePreHeatedLadleDetails(lblSl.Text) Then
                                lblMessage.Text = "Data deleted !"
                                FillGrid()
                            Else
                                lblMessage.Text &= "Data deletetion failed !"
                            End If
                        Catch exp As Exception
                            lblMessage.Text = exp.Message
                        End Try
                    Else
                        lblMessage.Text = "Data deletetion Not Allowed !"
                    End If
            End Select
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
End Class
