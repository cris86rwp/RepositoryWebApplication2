Public Class ProdMaterialDumpRegister
    Inherits System.Web.UI.Page
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblPLDescr As System.Web.UI.WebControls.Label
    Protected WithEvents ddlPLs As System.Web.UI.WebControls.DropDownList
    Protected WithEvents bntShow As System.Web.UI.WebControls.Button
    Protected WithEvents txtFromHeat As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtToHeat As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtUsedQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtInspectedBy As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents lblInspectedBy As System.Web.UI.WebControls.Label
    Protected WithEvents lblDBRNo As System.Web.UI.WebControls.Label
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblSl As System.Web.UI.WebControls.Label
    Protected WithEvents lblConsignee As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents DataGrid3 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid4 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtFrom As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTo As System.Web.UI.WebControls.TextBox
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


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
                    GetPLs()
                    txtFrom.Text = Now.Date
                    txtTo.Text = Now.Date
                    FillGrid()
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                End Try
            End If
        'End If
    End Sub

    Private Sub GetPLs()
        Dim dt1 As DataTable
        dt1 = ProductionConsumables.MaterialDumpRegisterPLs(lblConsignee.Text.Trim)
        ddlPLs.DataSource = dt1
        ddlPLs.DataTextField = dt1.Columns(0).ColumnName
        ddlPLs.DataValueField = dt1.Columns(1).ColumnName
        ddlPLs.DataBind()
        ddlPLs.SelectedIndex = 0
        lblPLDescr.Text = ddlPLs.SelectedItem.Value
        dt1 = Nothing
    End Sub

    Private Sub GetPLsDetails()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        lblInspectedBy.Text = ""
        Try
            Dim dt1 As DataTable
            dt1 = ProductionConsumables.MaterialDumpRegister(lblConsignee.Text, ddlPLs.SelectedItem.Text, CDate(txtFrom.Text), CDate(txtTo.Text))
            If dt1.Rows.Count > 0 Then
                DataGrid1.DataSource = dt1
                DataGrid1.DataBind()
                lblInspectedBy.Text = IIf(IsDBNull(dt1.Rows(0)("receipt_note_remarks")), "", dt1.Rows(0)("receipt_note_remarks"))
            Else
                lblMessage.Text = "No DBRs for dates betweem  " & txtFrom.Text & "  and " & txtTo.Text & "  !"
            End If
            dt1 = Nothing
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub bntShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntShow.Click
        lblMessage.Text = ""
        Try
            GetPLsDetails()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub ddlPLs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlPLs.SelectedIndexChanged
        lblMessage.Text = ""
        lblPLDescr.Text = ddlPLs.SelectedItem.Value
        DataGrid2.CurrentPageIndex = 0
        DataGrid3.SelectedIndex = -1
        DataGrid4.DataSource = Nothing
        DataGrid4.DataBind()
        FillGrid()
    End Sub

    Private Sub DataGrid1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.ItemCommand
        lblMessage.Text = ""
        lblDBRNo.Text = ""
        txtUsedQty.Text = ""
        Try
            Select Case e.CommandName
                Case "Select"
                    lblDBRNo.Text = e.Item.Cells(2).Text.Replace("&nbsp;", "").Trim
                    txtUsedQty.Text = e.Item.Cells(7).Text.Replace("&nbsp;", "").Trim
                    lblInspectedBy.Text = ""
                    Try
                        Dim dt1 As DataTable
                        dt1 = ProductionConsumables.MaterialDumpInspectedBy(lblDBRNo.Text)
                        If dt1.Rows.Count > 0 Then
                            lblInspectedBy.Text = IIf(IsDBNull(dt1.Rows(0)("receipt_note_remarks")), "", dt1.Rows(0)("receipt_note_remarks"))
                        Else
                            lblMessage.Text = "No DBRs for dates betweem  " & txtFrom.Text & "  and " & txtTo.Text & "  !"
                        End If
                        dt1 = Nothing
                    Catch exp As Exception
                        lblMessage.Text = exp.Message
                    End Try
            End Select
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        If lblDBRNo.Text.Trim.Length = 0 Then
            lblMessage.Text = "InValid Selection of DBR Number !"
            Exit Sub
        End If
        If Val(txtFromHeat.Text) = 0 Then
            lblMessage.Text = "InValid From Heat Number !"
            Exit Sub
        End If
        If Val(txtToHeat.Text) = 0 Then
            lblMessage.Text = "InValid To Heat Number !"
            Exit Sub
        End If
        If Val(txtUsedQty.Text) = 0 Then
            lblMessage.Text = "InValid Used Qty !"
            Exit Sub
        End If
        Dim done As Boolean
        Try
            If Val(txtFromHeat.Text) > Val(txtToHeat.Text) Then
                Throw New Exception("InValid From and To Heat !")
            End If
            done = New ProductionConsumables().SaveMaterialDumpRegister(ddlPLs.SelectedItem.Text, lblDBRNo.Text, Val(txtFromHeat.Text), Val(txtToHeat.Text), Val(txtUsedQty.Text), txtInspectedBy.Text.Trim, txtRemarks.Text.Trim, Val(lblSl.Text))
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If done Then
            DataGrid2.CurrentPageIndex = 0
            FillGrid()
            txtUsedQty.Text = ""
            lblDBRNo.Text = ""
            txtFromHeat.Text = ""
            txtToHeat.Text = ""
            txtInspectedBy.Text = ""
            txtRemarks.Text = ""
            lblMessage.Text &= " Data Saved! "
        Else
            lblMessage.Text &= "Data Saving Failed ! "
        End If
    End Sub

    Private Sub FillGrid()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        DataGrid3.DataSource = Nothing
        DataGrid3.DataBind()
        DataGrid2.SelectedIndex = -1
        Try
            Dim ds As DataSet
            ds = ProductionConsumables.MaterialDumpRegisterPLDetails(lblConsignee.Text, ddlPLs.SelectedItem.Text)
            If IsNothing(DataGrid2.CurrentPageIndex) Then DataGrid2.CurrentPageIndex = 0
            If ds.Tables(0).Rows.Count > 3 Then
                DataGrid2.AllowPaging = True
                DataGrid2.PageSize = 3
                DataGrid2.PagerStyle.Mode = PagerMode.NumericPages
            End If
            DataGrid2.DataSource = ds.Tables(0)
            DataGrid2.DataBind()
            DataGrid3.DataSource = ds.Tables(1)
            DataGrid3.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub DataGrid2_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid2.ItemCommand
        lblMessage.Text = ""
        lblDBRNo.Text = ""
        txtUsedQty.Text = ""
        DataGrid3.SelectedIndex = -1
        Try
            Select Case e.CommandName
                Case "Select"
                    lblDBRNo.Text = e.Item.Cells(2).Text.Replace("&nbsp;", "").Trim
                    txtFromHeat.Text = e.Item.Cells(3).Text.Replace("&nbsp;", "").Trim
                    txtToHeat.Text = e.Item.Cells(4).Text.Replace("&nbsp;", "").Trim
                    txtUsedQty.Text = e.Item.Cells(5).Text.Replace("&nbsp;", "").Trim
                    txtInspectedBy.Text = e.Item.Cells(6).Text.Replace("&nbsp;", "").Trim
                    txtRemarks.Text = e.Item.Cells(7).Text.Replace("&nbsp;", "").Trim
                    lblSl.Text = e.Item.Cells(8).Text.Replace("&nbsp;", "").Trim
            End Select
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub DataGrid2_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid2.PageIndexChanged
        lblMessage.Text = ""
        Try
            DataGrid2.CurrentPageIndex = e.NewPageIndex
            DataGrid2.EditItemIndex = -1
            DataGrid3.SelectedIndex = -1
            FillGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub DataGrid3_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid3.ItemCommand
        Try
            Select Case e.CommandName
                Case "Select"
                    DataGrid4.DataSource = ProductionConsumables.MaterialDumpRegisterData(e.Item.Cells(1).Text.Replace("&nbsp;", "").Trim)
                    DataGrid4.DataBind()
            End Select
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
End Class
