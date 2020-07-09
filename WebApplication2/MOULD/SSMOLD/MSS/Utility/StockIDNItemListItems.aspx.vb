Public Class StockIDNItemListItems1
    Inherits System.Web.UI.Page
    Protected WithEvents txtQtyTested As System.Web.UI.WebControls.TextBox
    Protected WithEvents dgStockIDN As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnUsage As System.Web.UI.WebControls.Button
    Protected WithEvents txtToHeatNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFromHeatNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblConsignee As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents ddlIDNs As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblItemsID As System.Web.UI.WebControls.Label
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtUsedFromDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtUsedToDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents pnlIDN As System.Web.UI.WebControls.Panel
    Protected WithEvents rblType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents pnlSand As System.Web.UI.WebControls.Panel
    Protected WithEvents dgSand As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtSandTo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSandFr As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSandRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSand As System.Web.UI.WebControls.Button
    Protected WithEvents lblSandItemsID As System.Web.UI.WebControls.Label
    Protected WithEvents txtPONo As System.Web.UI.WebControls.TextBox
    Protected WithEvents dgPO As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Panel2 As System.Web.UI.WebControls.Panel

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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        Session("UserID") = "078844"
        Session("Group") = "SSMOLD"

        If Page.IsPostBack = False Then
            Dim Group As String = Session("Group")
            Dim strMode As String = Request.QueryString("mode")
            Dim UserId As String = Session("UserID")
            Dim InValid As Boolean = False
            Try
                txtUsedFromDate.Text = Now.Date
                txtUsedToDate.Text = Now.Date
                'Group = "SSMOLD"
                'UserId = "073533"
                lblConsignee.Text = CriticalItems.ItemTables.GetConsignee(Group, UserId)
                If lblConsignee.Text.Trim.Length = 4 Then
                    InValid = True
                    SetType()
                    GetIDNs(lblConsignee.Text)
                    IDNDetails()
                    PopulateSavedData(ddlIDNs.SelectedItem.Value)
                End If
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            If Not InValid Then
                Response.Redirect("/mss/logon.aspx")
            End If
            lblItemsID.Visible = False
        End If
    End Sub

    Private Sub GetIDNs(ByVal Consigenee As String)
        ddlIDNs.DataSource = Nothing
        ddlIDNs.DataBind()
        Dim dv As New DataView()
        Try
            dv = CriticalItems.ItemTables.GetSavedIDNs(Consigenee).DefaultView
            ddlIDNs.DataSource = dv
            ddlIDNs.DataTextField = dv.Table.Columns(0).ColumnName
            ddlIDNs.DataValueField = dv.Table.Columns(1).ColumnName
            ddlIDNs.DataBind()
            ddlIDNs.SelectedIndex = 0
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            dv.Dispose()
        End Try
    End Sub

    Private Sub ddlIDNs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlIDNs.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            IDNDetails()
            PopulateSavedData(ddlIDNs.SelectedItem.Value)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub IDNDetails()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        Dim dv As New DataView()
        Try
            dv = CriticalItems.ItemTables.SavedIDNDetails(ddlIDNs.SelectedItem.Text.Trim, lblConsignee.Text).DefaultView
            If dv.Table.Rows.Count > 0 Then
                DataGrid2.DataSource = dv
                DataGrid2.DataBind()
            Else
                lblMessage.Text &= " No Details for IDN Number : '" & ddlIDNs.SelectedItem.Text.Trim & "' "
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
            dv = Nothing
        Finally
            dv.Dispose()
        End Try
    End Sub

    Private Sub PopulateSavedData(ByVal IDN As Long)
        dgStockIDN.SelectedIndex = -1
        dgStockIDN.DataSource = Nothing
        dgStockIDN.DataBind()
        Dim dv As New DataView()
        Try
            dv = CriticalItems.ItemTables.GetSavedIDNItems(IDN).DefaultView
            dgStockIDN.DataSource = dv
            dgStockIDN.DataBind()
            If dv.Table.Rows.Count > 0 Then dgStockIDN.Visible = True
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            dv.Dispose()
        End Try
    End Sub

    Private Sub ClearVal()
        txtUsedFromDate.Text = ""
        txtUsedToDate.Text = ""
        txtFromHeatNo.Text = ""
        txtToHeatNo.Text = ""
        txtQtyTested.Text = ""
        txtRemarks.Text = ""
        lblItemsID.Text = 0
    End Sub

    Private Sub ClearSandVal()
        txtSandFr.Text = ""
        txtSandTo.Text = ""
        txtSandRemarks.Text = ""
        lblSandItemsID.Text = 0
        dgSand.DataSource = Nothing
        dgSand.DataBind()
    End Sub

    Private Sub dgStockIDN_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgStockIDN.ItemCommand
        lblMessage.Text = ""
        ClearVal()
        Try
            Select Case e.CommandName
                Case "Select"
                    txtUsedFromDate.Text = e.Item.Cells(2).Text.Trim
                    txtUsedToDate.Text = e.Item.Cells(3).Text.Trim.Replace("&nbsp;", "")
                    txtFromHeatNo.Text = e.Item.Cells(4).Text.Trim.Replace("&nbsp;", "")
                    txtToHeatNo.Text = e.Item.Cells(5).Text.Trim.Replace("&nbsp;", "")
                    txtQtyTested.Text = e.Item.Cells(6).Text.Trim.Replace("&nbsp;", "")
                    txtRemarks.Text = e.Item.Cells(7).Text.Trim.Replace("&nbsp;", "")
                    lblItemsID.Text = e.Item.Cells(8).Text.Trim
                Case "Delete"
                    Dim done As New Boolean()
                    Try
                        done = New CriticalItems.StockIDNS(lblConsignee.Text).DeleteStockIDNStatusListItems(Val(e.Item.Cells(7).Text.Trim), ddlIDNs.SelectedItem.Value)
                        If done Then
                            lblMessage.Text = "Deleted ItemsID : '" & Val(e.Item.Cells(7).Text.Trim) & "' Successfully ! "
                        Else
                            Throw New Exception("Deletion of ItemsID : '" & Val(e.Item.Cells(7).Text.Trim) & "' failed ! ")
                        End If
                    Catch exp As Exception
                        done = False
                        lblMessage.Text = exp.Message
                    End Try
                    If done Then
                        Try
                            PopulateSavedData(ddlIDNs.SelectedItem.Value)
                        Catch exp As Exception
                            lblMessage.Text = "Filling of  StockIDNStatusListItems Grid failed ; " & exp.Message
                        Finally
                            ClearVal()
                        End Try
                    End If
                    done = Nothing
            End Select
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnUsage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUsage.Click
        If ddlIDNs.SelectedIndex = 0 Then
            lblMessage.Text = "Please select idn_number !"
            Exit Sub
        Else
            Dim ItemsID As Long
            Dim done As Boolean
            Try
                ItemsID = New CriticalItems.StockIDNS(lblConsignee.Text).StockIDNStatusListItems(ddlIDNs.SelectedItem.Value, CDate(txtUsedFromDate.Text), Val(txtFromHeatNo.Text), Val(txtToHeatNo.Text), Val(txtQtyTested.Text), txtRemarks.Text.Trim, CDate(txtUsedToDate.Text), Val(lblItemsID.Text))
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try

            If Val(lblItemsID.Text) = 0 Then
                If ItemsID > 0 Then
                    lblMessage.Text &= "Generated ItemsID : '" & ItemsID & "' Successfully ! "
                    done = True
                Else
                    lblMessage.Text &= "Generation of ItemsID failed ! "
                End If

                done = Nothing
                ItemsID = Nothing
            Else
                If ItemsID > 0 Then
                    lblMessage.Text &= "Updation of IDN : '" & ddlIDNs.SelectedItem.Text & "' Successfully ! "
                    done = True
                Else
                    lblMessage.Text &= "Updation of  ItemsID failed ! "
                End If
            End If
            Try
                PopulateSavedData(ddlIDNs.SelectedItem.Value)
            Catch exp As Exception
                lblMessage.Text &= "Filling of  StockIDNStatusListItems Grid failed ; " & exp.Message
            Finally
                ClearVal()
            End Try
        End If
    End Sub

    Private Sub txtUsedFromDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUsedFromDate.TextChanged
        lblMessage.Text = ""
        Dim dt As New Date()
        Try
            dt = CDate(txtUsedFromDate.Text.Trim)
            txtUsedFromDate.Text = dt
        Catch exp As Exception
            lblMessage.Text = " Date : '" & txtUsedFromDate.Text.Trim & "' not in correct format.  " & exp.Message
            txtUsedFromDate.Text = ""
        Finally
            dt = Nothing
        End Try
    End Sub

    Private Sub txtUsedToDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUsedToDate.TextChanged
        lblMessage.Text = ""
        Dim dt As New Date()
        Try
            dt = CDate(txtUsedToDate.Text.Trim)
            txtUsedToDate.Text = dt
        Catch exp As Exception
            lblMessage.Text = " Date : '" & txtUsedToDate.Text.Trim & "' not in correct format.  " & exp.Message
            txtUsedToDate.Text = ""
        Finally
            dt = Nothing
        End Try
    End Sub

    Private Sub rblType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblType.SelectedIndexChanged
        lblMessage.Text = ""
        SetType()
    End Sub

    Private Sub SetType()
        pnlIDN.Visible = False
        pnlSand.Visible = False
        ClearVal()
        ClearSandVal()
        If rblType.SelectedIndex = 0 Then
            pnlIDN.Visible = True
        Else
            pnlSand.Visible = True
        End If
    End Sub

    Private Sub btnSand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSand.Click
        If txtPONo.Text.Trim.Length = 0 Then
            lblMessage.Text = "Please provide dbr_number !"
            Exit Sub
        Else
            Dim done As Boolean
            Try
                done = New CriticalItems.StockIDNS(lblConsignee.Text).SandUsage(txtPONo.Text.Trim, Val(txtSandFr.Text), Val(txtSandTo.Text), txtSandRemarks.Text.Trim, Val(lblSandItemsID.Text))
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            If done Then
                lblMessage.Text = "Data saved Successfully ! "
                SavedPOs()
                ClearSandVal()
            Else
                lblMessage.Text = "Data saving failed ! "
            End If
        End If
    End Sub

    Private Sub dgSand_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgSand.ItemCommand
        lblMessage.Text = ""
        ClearVal()
        Try
            Select Case e.CommandName
                Case "Delete"
                    Dim done As New Boolean()
                    Try
                        done = New CriticalItems.StockIDNS(lblConsignee.Text).SandUsage("", 0, 0, "", Val(e.Item.Cells(15).Text.Trim))
                        If done Then
                            lblMessage.Text = "Deleted ItemsID : '" & Val(e.Item.Cells(15).Text.Trim) & "' Successfully ! "
                        Else
                            Throw New Exception("Deletion of ItemsID : '" & Val(e.Item.Cells(15).Text.Trim) & "' failed ! ")
                        End If
                    Catch exp As Exception
                        done = False
                        lblMessage.Text = exp.Message
                    End Try
                    If done Then
                        ClearSandVal()
                    End If
                    done = Nothing
            End Select
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtPONo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPONo.TextChanged
        lblMessage.Text = ""
        dgSand.SelectedIndex = -1
        dgSand.DataSource = Nothing
        dgSand.DataBind()
        Dim dv As New DataView()
        Try
            dv = CriticalItems.ItemTables.SandDBRDetails(txtPONo.Text.Trim).DefaultView
            dgSand.DataSource = dv
            dgSand.DataBind()
            If dv.Table.Rows.Count > 0 Then
                dgSand.Visible = True
            Else
                lblMessage.Text = "InValid PO No !"
                txtPONo.Text = ""
            End If
            SavedPOs()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dv.Dispose()
            dv = Nothing
        End Try
    End Sub

    Private Sub SavedPOs()
        dgPO.SelectedIndex = -1
        dgPO.DataSource = Nothing
        dgPO.DataBind()
        Try
            dgPO.DataSource = CriticalItems.ItemTables.GetSavedPOItems(txtPONo.Text.Trim)
            dgPO.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub dgPO_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgPO.ItemCommand
        lblMessage.Text = ""
        ClearSandVal()
        Try
            Select Case e.CommandName
                Case "Select"
                    txtSandFr.Text = e.Item.Cells(1).Text.Trim.Replace("&nbsp;", "")
                    txtSandTo.Text = e.Item.Cells(2).Text.Trim.Replace("&nbsp;", "")
                    txtSandRemarks.Text = e.Item.Cells(3).Text.Trim.Replace("&nbsp;", "")
                    lblSandItemsID.Text = e.Item.Cells(4).Text.Trim.Replace("&nbsp;", "")
                Case "Delete"
                    Dim done As New Boolean()
                    Try
                        done = New CriticalItems.StockIDNS(lblConsignee.Text).SandUsage("", 0, 0, "", Val(e.Item.Cells(4).Text.Trim), True)
                        SavedPOs()
                        If done Then
                            lblMessage.Text = "Deleted ItemsID : '" & Val(e.Item.Cells(7).Text.Trim) & "' Successfully ! "
                        Else
                            Throw New Exception("Deletion of ItemsID : '" & Val(e.Item.Cells(7).Text.Trim) & "' failed ! ")
                        End If
                    Catch exp As Exception
                        done = False
                        lblMessage.Text = exp.Message
                    End Try
                    done = Nothing
            End Select
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
End Class
