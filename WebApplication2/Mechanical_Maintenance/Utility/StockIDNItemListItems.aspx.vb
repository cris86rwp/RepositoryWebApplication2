Public Class StockIDNItemListItems
    Inherits System.Web.UI.Page
    Protected WithEvents txtQtyTested As System.Web.UI.WebControls.TextBox
    Protected WithEvents dgStockIDN As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnUsage As System.Web.UI.WebControls.Button
    Protected WithEvents txtToHeatNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFromHeatNo1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblConsignee1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage1 As System.Web.UI.WebControls.Label
    Protected WithEvents ddlIDNs1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblItemsID1 As System.Web.UI.WebControls.Label
    Protected WithEvents txtRemarks1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtUsedFromDate1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtUsedToDate1 As System.Web.UI.WebControls.TextBox
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
                txtUsedFromDate1.Text = Now.Date
                txtUsedToDate1.Text = Now.Date
                'Group = "SSMOLD"
                'UserId = "073533"
                lblConsignee1.Text = CriticalItems.ItemTables.GetConsignee(Group, UserId)
                If lblConsignee1.Text.Trim.Length = 4 Then
                    InValid = True
                    SetType()
                    GetIDNs(lblConsignee1.Text)
                    IDNDetails()
                    PopulateSavedData(ddlIDNs1.SelectedItem.Value)
                End If
            Catch exp As Exception
                lblMessage1.Text = exp.Message
            End Try
            If Not InValid Then
                Response.Redirect("/mss/logon.aspx")
            End If
            lblItemsID1.Visible = False
        End If
    End Sub

    Private Sub GetIDNs(ByVal Consigenee As String)
        ddlIDNs1.DataSource = Nothing
        ddlIDNs1.DataBind()
        Dim dv As New DataView()
        Try
            dv = CriticalItems.ItemTables.GetSavedIDNs(Consigenee).DefaultView
            ddlIDNs1.DataSource = dv
            ddlIDNs1.DataTextField = dv.Table.Columns(0).ColumnName
            ddlIDNs1.DataValueField = dv.Table.Columns(1).ColumnName
            ddlIDNs1.DataBind()
            ddlIDNs1.SelectedIndex = 0
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            dv.Dispose()
        End Try
    End Sub

    Private Sub ddlIDNs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlIDNs1.SelectedIndexChanged
        lblMessage1.Text = ""
        Try
            IDNDetails()
            PopulateSavedData(ddlIDNs1.SelectedItem.Value)
        Catch exp As Exception
            lblMessage1.Text = exp.Message
        End Try
    End Sub

    Private Sub IDNDetails()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        Dim dv As New DataView()
        Try
            dv = CriticalItems.ItemTables.SavedIDNDetails(ddlIDNs1.SelectedItem.Text.Trim, lblConsignee1.Text).DefaultView
            If dv.Table.Rows.Count > 0 Then
                DataGrid2.DataSource = dv
                DataGrid2.DataBind()
            Else
                lblMessage1.Text &= " No Details for IDN Number : '" & ddlIDNs1.SelectedItem.Text.Trim & "' "
            End If
        Catch exp As Exception
            lblMessage1.Text = exp.Message
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
        txtUsedFromDate1.Text = ""
        txtUsedToDate1.Text = ""
        txtFromHeatNo1.Text = ""
        txtToHeatNo.Text = ""
        txtQtyTested.Text = ""
        txtRemarks1.Text = ""
        lblItemsID1.Text = 0
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
        lblMessage1.Text = ""
        ClearVal()
        Try
            Select Case e.CommandName
                Case "Select"
                    txtUsedFromDate1.Text = e.Item.Cells(2).Text.Trim
                    txtUsedToDate1.Text = e.Item.Cells(3).Text.Trim.Replace("&nbsp;", "")
                    txtFromHeatNo1.Text = e.Item.Cells(4).Text.Trim.Replace("&nbsp;", "")
                    txtToHeatNo.Text = e.Item.Cells(5).Text.Trim.Replace("&nbsp;", "")
                    txtQtyTested.Text = e.Item.Cells(6).Text.Trim.Replace("&nbsp;", "")
                    txtRemarks1.Text = e.Item.Cells(7).Text.Trim.Replace("&nbsp;", "")
                    lblItemsID1.Text = e.Item.Cells(8).Text.Trim
                Case "Delete"
                    Dim done As New Boolean()
                    Try
                        done = New CriticalItems.StockIDNS(lblConsignee1.Text).DeleteStockIDNStatusListItems(Val(e.Item.Cells(7).Text.Trim), ddlIDNs1.SelectedItem.Value)
                        If done Then
                            lblMessage1.Text = "Deleted ItemsID : '" & Val(e.Item.Cells(7).Text.Trim) & "' Successfully ! "
                        Else
                            Throw New Exception("Deletion of ItemsID : '" & Val(e.Item.Cells(7).Text.Trim) & "' failed ! ")
                        End If
                    Catch exp As Exception
                        done = False
                        lblMessage1.Text = exp.Message
                    End Try
                    If done Then
                        Try
                            PopulateSavedData(ddlIDNs1.SelectedItem.Value)
                        Catch exp As Exception
                            lblMessage1.Text = "Filling of  StockIDNStatusListItems Grid failed ; " & exp.Message
                        Finally
                            ClearVal()
                        End Try
                    End If
                    done = Nothing
            End Select
        Catch exp As Exception
            lblMessage1.Text = exp.Message
        End Try
    End Sub

    Private Sub btnUsage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUsage.Click
        If ddlIDNs1.SelectedIndex = 0 Then
            lblMessage1.Text = "Please select idn_number !"
            Exit Sub
        Else
            Dim ItemsID As Long
            Dim done As Boolean
            Try
                ItemsID = New CriticalItems.StockIDNS(lblConsignee1.Text).StockIDNStatusListItems(ddlIDNs1.SelectedItem.Value, CDate(txtUsedFromDate1.Text), Val(txtFromHeatNo1.Text), Val(txtToHeatNo.Text), Val(txtQtyTested.Text), txtRemarks1.Text.Trim, CDate(txtUsedToDate1.Text), Val(lblItemsID1.Text))
            Catch exp As Exception
                lblMessage1.Text = exp.Message
            End Try

            If Val(lblItemsID1.Text) = 0 Then
                If ItemsID > 0 Then
                    lblMessage1.Text &= "Generated ItemsID : '" & ItemsID & "' Successfully ! "
                    done = True
                Else
                    lblMessage1.Text &= "Generation of ItemsID failed ! "
                End If

                done = Nothing
                ItemsID = Nothing
            Else
                If ItemsID > 0 Then
                    lblMessage1.Text &= "Updation of IDN : '" & ddlIDNs1.SelectedItem.Text & "' Successfully ! "
                    done = True
                Else
                    lblMessage1.Text &= "Updation of  ItemsID failed ! "
                End If
            End If
            Try
                PopulateSavedData(ddlIDNs1.SelectedItem.Value)
            Catch exp As Exception
                lblMessage1.Text &= "Filling of  StockIDNStatusListItems Grid failed ; " & exp.Message
            Finally
                ClearVal()
            End Try
        End If
    End Sub

    Private Sub txtUsedFromDate1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUsedFromDate1.TextChanged
        lblMessage1.Text = ""
        Dim dt As New Date()
        Try
            dt = CDate(txtUsedFromDate1.Text.Trim)
            txtUsedFromDate1.Text = dt
        Catch exp As Exception
            lblMessage1.Text = " Date : '" & txtUsedFromDate1.Text.Trim & "' not in correct format.  " & exp.Message
            txtUsedFromDate1.Text = ""
        Finally
            dt = Nothing
        End Try
    End Sub

    Private Sub txtUsedToDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUsedToDate1.TextChanged
        lblMessage1.Text = ""
        Dim dt As New Date()
        Try
            dt = CDate(txtUsedFromDate1.Text.Trim)
            txtUsedFromDate1.Text = dt
        Catch exp As Exception
            lblMessage1.Text = " Date : '" & txtUsedFromDate1.Text.Trim & "' not in correct format.  " & exp.Message
            txtUsedFromDate1.Text = ""
        Finally
            dt = Nothing
        End Try
    End Sub

    Private Sub rblType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblType.SelectedIndexChanged
        lblMessage1.Text = ""
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
            lblMessage1.Text = "Please provide dbr_number !"
            Exit Sub
        Else
            Dim done As Boolean
            Try
                done = New CriticalItems.StockIDNS(lblConsignee1.Text).SandUsage(txtPONo.Text.Trim, Val(txtSandFr.Text), Val(txtSandTo.Text), txtSandRemarks.Text.Trim, Val(lblSandItemsID.Text))
            Catch exp As Exception
                lblMessage1.Text = exp.Message
            End Try
            If done Then
                lblMessage1.Text = "Data saved Successfully ! "
                SavedPOs()
                ClearSandVal()
            Else
                lblMessage1.Text = "Data saving failed ! "
            End If
        End If
    End Sub

    Private Sub dgSand_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgSand.ItemCommand
        lblMessage1.Text = ""
        ClearVal()
        Try
            Select Case e.CommandName
                Case "Delete"
                    Dim done As New Boolean()
                    Try
                        done = New CriticalItems.StockIDNS(lblConsignee1.Text).SandUsage("", 0, 0, "", Val(e.Item.Cells(15).Text.Trim))
                        If done Then
                            lblMessage1.Text = "Deleted ItemsID : '" & Val(e.Item.Cells(15).Text.Trim) & "' Successfully ! "
                        Else
                            Throw New Exception("Deletion of ItemsID : '" & Val(e.Item.Cells(15).Text.Trim) & "' failed ! ")
                        End If
                    Catch exp As Exception
                        done = False
                        lblMessage1.Text = exp.Message
                    End Try
                    If done Then
                        ClearSandVal()
                    End If
                    done = Nothing
            End Select
        Catch exp As Exception
            lblMessage1.Text = exp.Message
        End Try
    End Sub

    Private Sub txtPONo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPONo.TextChanged
        lblMessage1.Text = ""
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
                lblMessage1.Text = "InValid PO No !"
                txtPONo.Text = ""
            End If
            SavedPOs()
        Catch exp As Exception
            lblMessage1.Text = exp.Message
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
            lblMessage1.Text = exp.Message
        End Try
    End Sub

    Private Sub dgPO_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgPO.ItemCommand
        lblMessage1.Text = ""
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
                        done = New CriticalItems.StockIDNS(lblConsignee1.Text).SandUsage("", 0, 0, "", Val(e.Item.Cells(4).Text.Trim), True)
                        SavedPOs()
                        If done Then
                            lblMessage1.Text = "Deleted ItemsID : '" & Val(e.Item.Cells(7).Text.Trim) & "' Successfully ! "
                        Else
                            Throw New Exception("Deletion of ItemsID : '" & Val(e.Item.Cells(7).Text.Trim) & "' failed ! ")
                        End If
                    Catch exp As Exception
                        done = False
                        lblMessage1.Text = exp.Message
                    End Try
                    done = Nothing
            End Select
        Catch exp As Exception
            lblMessage1.Text = exp.Message
        End Try
    End Sub
End Class
