Public Class ProdCalcinedLimeDetails
    Inherits System.Web.UI.Page
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblSl As System.Web.UI.WebControls.Label
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtReceiptDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblConsignee As System.Web.UI.WebControls.Label
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtDCNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFromHeat As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtToHeat As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblDBRNo As System.Web.UI.WebControls.Label
    Protected WithEvents lblLabNo As System.Web.UI.WebControls.Label
    Protected WithEvents DataGrid3 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtRecQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtUsedDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNoOfBags As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblResult As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtYearSl As System.Web.UI.WebControls.TextBox
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
                    txtUsedDate.Text = Now.Date
                    FillGrid()
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                End Try
            End If
        'End If
    End Sub

    Private Sub FillGrid()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        DataGrid3.DataSource = Nothing
        DataGrid3.DataBind()
        Clear()
        Try
            DataGrid1.DataSource = ProductionConsumables.CalcinedLimeDetails(CDate(txtReceiptDate.Text))
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub Clear()
        lblDBRNo.Text = ""
        txtRecQty.Text = ""
        lblLabNo.Text = ""
        txtDCNo.Text = ""
        txtFromHeat.Text = ""
        txtToHeat.Text = ""
        txtNoOfBags.Text = ""
        txtRemarks.Text = ""
        txtYearSl.Text = ""
        rblResult.ClearSelection()
    End Sub

    Private Sub txtReceiptDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReceiptDate.TextChanged
        lblMessage.Text = ""
        FillGrid()
    End Sub

    Private Sub txtDCNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDCNo.TextChanged
        lblMessage.Text = ""
        lblDBRNo.Text = ""
        txtRecQty.Text = ""
        lblLabNo.Text = ""
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        DataGrid3.DataSource = Nothing
        DataGrid3.DataBind()
        If txtDCNo.Text.Trim.Length = 0 Then
            lblMessage.Text = "Please provide DC Number !"
            Exit Sub
        Else
            Dim ds As DataSet
            Try
                ds = ProductionConsumables.CalcinedLimeDetails(txtDCNo.Text.Trim)
                If ds.Tables.Count = 0 Then
                    lblMessage.Text = "InValid DC Number !"
                    Exit Sub
                Else
                    If ds.Tables(0).Rows.Count = 0 Then
                        lblMessage.Text = "InValid DBR Details !"
                        Exit Sub
                    Else
                        If ds.Tables(0).Rows.Count = 1 Then
                            lblDBRNo.Text = ds.Tables(0).Rows(0)("dbr_number")
                            txtRecQty.Text = ds.Tables(0).Rows(0)("AccQty")
                            txtReceiptDate.Text = ds.Tables(0).Rows(0)("DCDate")
                        End If
                        DataGrid2.DataSource = ds.Tables(0)
                        DataGrid2.DataBind()
                    End If
                    If ds.Tables(1).Rows.Count = 0 Then
                        'lblMessage.Text = "InValid Test Details !"
                        'Exit Sub
                    Else
                        If ds.Tables(1).Rows.Count = 1 Then
                            lblLabNo.Text = ds.Tables(1).Rows(0)("LabNo")
                        End If
                        DataGrid3.DataSource = ds.Tables(1)
                        DataGrid3.DataBind()
                    End If
                    If ds.Tables(2).Rows.Count > 0 Then
                        lblMessage.Text = "DC No Details already exists ! Please select from Saved Data Grid ( Bottom ) to Edit !"
                    End If
                End If
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub DataGrid2_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid2.ItemCommand
        lblMessage.Text = ""
        lblDBRNo.Text = ""
        txtRecQty.Text = ""
        Try
            Select Case e.CommandName
                Case "Select"
                    lblDBRNo.Text = e.Item.Cells(2).Text.Replace("&nbsp;", "").Trim
                    txtRecQty.Text = e.Item.Cells(10).Text.Replace("&nbsp;", "").Trim
            End Select
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub DataGrid3_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid3.ItemCommand
        lblMessage.Text = ""
        lblLabNo.Text = ""
        Try
            Select Case e.CommandName
                Case "Select"
                    lblLabNo.Text = e.Item.Cells(1).Text.Replace("&nbsp;", "").Trim
            End Select
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        If lblDBRNo.Text.Trim.Length = 0 Then
            lblMessage.Text = "Please select DBR Details !"
            Exit Sub
        End If
        'If lblLabNo.Text.Trim.Length = 0 Then
        '    lblMessage.Text = "Please select LAB Details !"
        '    Exit Sub
        'End If
        Dim done As Boolean
        done = False
        Dim i As Int16 = 0
        For i = 0 To rblResult.Items.Count - 1
            If rblResult.Items(i).Selected = True Then
                done = True
                Exit For
            End If
        Next
        Try
            If done = False Then
                done = New ProductionConsumables().SaveCalcinedLimeDetails(CDate(txtReceiptDate.Text), txtDCNo.Text.Trim, lblDBRNo.Text, lblLabNo.Text, Val(txtRecQty.Text), Val(txtFromHeat.Text), Val(txtToHeat.Text), txtRemarks.Text.Trim, CDate(txtUsedDate.Text), Val(txtNoOfBags.Text), "", txtYearSl.Text.Trim, Val(lblSl.Text))
            Else
                done = False
                done = New ProductionConsumables().SaveCalcinedLimeDetails(CDate(txtReceiptDate.Text), txtDCNo.Text.Trim, lblDBRNo.Text, lblLabNo.Text, Val(txtRecQty.Text), Val(txtFromHeat.Text), Val(txtToHeat.Text), txtRemarks.Text.Trim, CDate(txtUsedDate.Text), Val(txtNoOfBags.Text), rblResult.SelectedIndex, txtYearSl.Text.Trim, Val(lblSl.Text))
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If done Then
            FillGrid()
            lblMessage.Text &= "  Data Saved !"
            DataGrid1.SelectedIndex = -1
        Else
            lblMessage.Text &= "  Data Saving Failed !"
        End If
    End Sub

    Private Sub txtFromHeat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFromHeat.TextChanged
        lblMessage.Text = ""
        If Val(txtFromHeat.Text) = 0 Then
            lblMessage.Text = "InValid FromHeat !"
            Exit Sub
        End If
        Try
            txtUsedDate.Text = ProductionConsumables.GetTappedDate(Val(txtFromHeat.Text))
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub DataGrid1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.ItemCommand
        lblMessage.Text = ""
        lblDBRNo.Text = ""
        txtRecQty.Text = ""
        lblLabNo.Text = ""
        lblSl.Text = ""
        Try
            Select Case e.CommandName
                Case "Select"
                    txtYearSl.Text = e.Item.Cells(2).Text.Replace("&nbsp;", "").Trim
                    txtDCNo.Text = e.Item.Cells(3).Text.Replace("&nbsp;", "").Trim
                    txtReceiptDate.Text = e.Item.Cells(4).Text.Replace("&nbsp;", "").Trim
                    lblDBRNo.Text = e.Item.Cells(5).Text.Replace("&nbsp;", "").Trim
                    lblLabNo.Text = e.Item.Cells(6).Text.Replace("&nbsp;", "").Trim
                    txtRecQty.Text = e.Item.Cells(7).Text.Replace("&nbsp;", "").Trim
                    txtFromHeat.Text = e.Item.Cells(8).Text.Replace("&nbsp;", "").Trim
                    txtToHeat.Text = e.Item.Cells(9).Text.Replace("&nbsp;", "").Trim
                    txtNoOfBags.Text = e.Item.Cells(10).Text.Replace("&nbsp;", "").Trim
                    rblResult.ClearSelection()
                    If e.Item.Cells(11).Text.Trim = "Passed" Then
                        rblResult.SelectedIndex = 0
                    ElseIf e.Item.Cells(11).Text.Trim = "Failed" Then
                        rblResult.SelectedIndex = 1
                    End If
                    txtRemarks.Text = e.Item.Cells(12).Text.Replace("&nbsp;", "").Trim
                    lblSl.Text = e.Item.Cells(15).Text.Replace("&nbsp;", "").Trim
                    lblMessage.Text = ""
                Case "Delete"
                    Try '
                        If New ProductionConsumables().DeleteCalcinedLimeDetails(e.Item.Cells(15).Text) Then
                            lblMessage.Text = "Data deleted !"
                            FillGrid()
                        Else
                            lblMessage.Text = "Data deletetion failed !"
                        End If
                    Catch exp As Exception
                        lblMessage.Text = exp.Message
                    End Try
            End Select
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
End Class
