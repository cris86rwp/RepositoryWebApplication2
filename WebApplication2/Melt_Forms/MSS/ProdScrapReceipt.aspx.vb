Public Class ProdScrapReceipt
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtWagonNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtReceiptQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtReceiptDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblScrap As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblSl As System.Web.UI.WebControls.Label
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents rblType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents lblTypeDate As System.Web.UI.WebControls.Label
    Protected WithEvents lblTypeNo As System.Web.UI.WebControls.Label
    Protected WithEvents lblTypeQty As System.Web.UI.WebControls.Label
    Protected WithEvents lblConsignee As System.Web.UI.WebControls.Label
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
                txtReceiptDate.Text = Now.Date
                SetType()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
        'End If
    End Sub

    Private Sub SetType()
        If rblType.SelectedIndex = 0 Then
            lblTypeDate.Text = "Receipt"
            lblTypeNo.Text = "Wagon"
            lblTypeQty.Text = "Receipt"
        Else
            lblTypeDate.Text = "Returned"
            lblTypeNo.Text = "WeigtSlip"
            lblTypeQty.Text = "Returned"
        End If
        Dim dt As DataTable
        dt = ProductionConsumables.GetScrapType(rblType.SelectedItem.Text)
        rblScrap.DataSource = dt
        rblScrap.DataTextField = dt.Columns(1).ColumnName
        rblScrap.DataValueField = dt.Columns(0).ColumnName
        rblScrap.DataBind()
        rblScrap.SelectedIndex = 0
        FillGrid()
    End Sub

    Private Sub FillGrid()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        Try
            If rblType.SelectedIndex = 0 Then
                Dim ds As DataSet
                ds = ProductionConsumables.ScrapDetails(CDate(txtReceiptDate.Text), rblScrap.SelectedItem.Value)
                DataGrid1.DataSource = ds.Tables(0)
                DataGrid1.DataBind()
                DataGrid2.DataSource = ds.Tables(1)
                DataGrid2.DataBind()
            Else
                DataGrid1.DataSource = ProductionConsumables.ReturnedStoresDetails(CDate(txtReceiptDate.Text))
                DataGrid1.DataBind()
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub DataGrid1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.ItemCommand
        lblMessage.Text = ""
        txtWagonNo.Text = ""
        txtReceiptQty.Text = ""
        lblSl.Text = ""
        Try
            Select Case e.CommandName
                Case "Select"
                    txtWagonNo.Text = e.Item.Cells(4).Text.Replace("&nbsp;", "").Trim
                    rblScrap.ClearSelection()
                    Dim i As Int16
                    i = 0
                    For i = 0 To rblScrap.Items.Count - 1
                        If e.Item.Cells(5).Text = rblScrap.Items(i).Text Then
                            rblScrap.Items(i).Selected = True
                            Exit For
                        End If
                    Next
                    txtReceiptQty.Text = e.Item.Cells(6).Text.Replace("&nbsp;", "").Trim
                    txtRemarks.Text = e.Item.Cells(7).Text.Replace("&nbsp;", "").Trim
                    If rblType.SelectedIndex = 0 Then
                        lblSl.Text = e.Item.Cells(15).Text.Trim
                    Else
                        lblSl.Text = e.Item.Cells(12).Text.Trim
                    End If
                Case "Delete"
                    Dim Group As String = Session("Group")
                    Dim UserId As String = Session("UserID")
                    If Group = "SSMELT" Then
                        Try
                            If rblType.SelectedIndex = 0 Then
                                lblSl.Text = e.Item.Cells(15).Text.Trim
                            Else
                                lblSl.Text = e.Item.Cells(12).Text.Trim
                            End If
                            If New ProductionConsumables().DeleteScrapDetails(lblSl.Text) Then
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

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        Dim done As Boolean
        If txtWagonNo.Text.Trim.Length = 0 Then
            lblMessage.Text = "Please provide Wagon/WeigtSlip Number !"
            Exit Sub
        End If
        If Val(txtReceiptQty.Text) = 0 Then
            lblMessage.Text = "Please provide Receipt/Returned Qty !"
            Exit Sub
        End If
        Try
            done = New ProductionConsumables().SaveScrapDetails(rblScrap.SelectedItem.Value, CDate(txtReceiptDate.Text), txtWagonNo.Text.Trim, Val(txtReceiptQty.Text), Val(lblSl.Text), txtRemarks.Text.Trim)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If done Then
            FillGrid()
            txtWagonNo.Text = ""
            txtReceiptQty.Text = ""
            lblSl.Text = ""
            lblMessage.Text &= "Data Saved ! " & lblMessage.Text
        Else
            lblMessage.Text = "Data Saving Failed ! "
        End If
    End Sub

    Private Sub txtReceiptDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReceiptDate.TextChanged
        lblMessage.Text = ""
        FillGrid()
    End Sub

    Private Sub rblType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblType.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            SetType()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub rblScrap_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblScrap.SelectedIndexChanged
        lblMessage.Text = ""
        FillGrid()
    End Sub

    Protected Sub DataGrid1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DataGrid1.SelectedIndexChanged

    End Sub
End Class
