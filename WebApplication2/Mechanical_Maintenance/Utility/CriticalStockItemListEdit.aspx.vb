Public Class CriticalStockItemListEdit
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtSlNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblPlDesc As System.Web.UI.WebControls.Label
    Protected WithEvents lblRecoupType As System.Web.UI.WebControls.Label
    Protected WithEvents lblRecoupQty As System.Web.UI.WebControls.Label
    Protected WithEvents lblLastIssueDate As System.Web.UI.WebControls.Label
    Protected WithEvents txtEquip As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNum As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDt As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSup As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDD As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRecdQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtQtyUT As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtQtyDue As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblRecID As System.Web.UI.WebControls.Label
    Protected WithEvents ddlPLNumber As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblConsignee As System.Web.UI.WebControls.Label
    Protected WithEvents dgSavedData As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button

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
        Session("Group") = "MW2"
        Session("UserId") = "078844"
        'Put user code to initialize the page here
        If Page.IsPostBack = False Then
            lblMessage.Text = ""
            lblRecID.Visible = False
            Dim Group As String = Session("Group")
            Dim strMode As String = Request.QueryString("mode")
            Dim UserId As String = Session("UserID")
            Dim InValid As Boolean = False
            Try
                lblConsignee.Text = CriticalItems.ItemTables.GetConsignee(Group, UserId)
                If lblConsignee.Text.Trim.Length = 4 Then InValid = True
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            If Not InValid Then
                'Response.Redirect("/wap/logon.aspx")
            End If
            ClearPLVal()
            ClearVal()
            PopulateDDL()
            dgSavedData.DataSource = Nothing
            dgSavedData.DataBind()
        End If
    End Sub
    Private Sub PopulateDDL()
        lblMessage.Text = ""
        ddlPLNumber.DataSource = Nothing
        ddlPLNumber.DataBind()
        Dim dvPLNumber As New DataView()
        Try
            dvPLNumber.Table = CriticalItems.ItemTables.GetConsigneePls(lblConsignee.Text, , True)
            ddlPLNumber.DataSource = dvPLNumber
            ddlPLNumber.DataTextField = dvPLNumber.Table.Columns(0).ColumnName
            ddlPLNumber.DataValueField = dvPLNumber.Table.Columns(0).ColumnName
            ddlPLNumber.DataBind()
            ddlPLNumber.Items.Insert(0, "Select")
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub PopulateSavedData(ByVal PLNumber As String, ByVal Consignee As String)
        dgSavedData.Visible = False
        dgSavedData.DataSource = Nothing
        dgSavedData.DataBind()
        Dim ds As New DataSet()
        Dim dv As New DataView()
        Try
            ds = CriticalItems.ItemTables.SavedCriticalList(PLNumber, lblConsignee.Text.Trim)
            dgSavedData.DataSource = ds.Tables(0).DefaultView
            dgSavedData.DataBind()
            If ds.Tables(0).Rows.Count > 0 Then dgSavedData.Visible = True
            If ds.Tables(1).Rows(0)(0) > 0 Then
                lblMessage.Text = " There are " & ds.Tables(1).Rows(0)(0) & " item(s) in deleted list. "
            End If
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            dv.Dispose()
        End Try
    End Sub
    Private Sub ClearPLVal()
        lblPlDesc.Text = ""
        txtSlNo.Text = ""
        lblRecoupType.Text = ""
        lblRecoupQty.Text = ""
        lblLastIssueDate.Text = "1900-01-01"
        txtEquip.Text = ""
    End Sub
    Private Sub ClearVal()
        txtNum.Text = ""
        txtDt.Text = "1900-01-01"
        txtQty.Text = "0"
        txtSup.Text = ""
        txtRecdQty.Text = "0"
        txtQtyUT.Text = "0"
        txtQtyDue.Text = "0"
        txtDD.Text = ""
        txtRemarks.Text = ""
        lblRecID.Text = "0"
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim blnSave As Boolean = False
        Dim SaveList As New CriticalItems.Listing(lblConsignee.Text.Trim)
        Try
            SaveList.PLNumber = ddlPLNumber.SelectedItem.Text.Trim
            SaveList.SlNo = IIf(IsDBNull(txtSlNo.Text.Trim), 0, txtSlNo.Text.Trim)
            SaveList.Equip = txtEquip.Text.Trim & ""
            SaveList.PO = txtNum.Text
            SaveList.PODt = IIf(IsDBNull(txtDt.Text.Trim), "1900-01-01", Format(CDate(txtDt.Text.Trim), "yyyy-MM-dd"))
            SaveList.POQty = IIf(IsDBNull(txtQty.Text), 0, txtQty.Text)
            SaveList.PODD = IIf(IsDBNull(txtDD.Text.Trim), "", txtDD.Text.Trim)
            SaveList.POSup = txtSup.Text.Trim
            SaveList.RecdQty = IIf(IsDBNull(txtRecdQty.Text), 0, txtRecdQty.Text)
            SaveList.QtyUT = IIf(IsDBNull(txtQtyUT.Text), 0, txtQtyUT.Text)
            SaveList.QtyDue = IIf(IsDBNull(txtQtyDue.Text), 0, txtQtyDue.Text)
            SaveList.Remarks = txtRemarks.Text.Trim.ToUpper & ""
            SaveList.Consignee = lblConsignee.Text
            If SaveList.SaveConsignee(SaveList.Consignee, lblRecID.Text) Then
                blnSave = True
                ClearVal()
                dgSavedData.SelectedIndex = -1
            End If
            PopulateSavedData(ddlPLNumber.SelectedItem.Text.Trim, lblConsignee.Text)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            SaveList = Nothing
        End Try
        If blnSave Then
            lblMessage.Text = " DATA Updated !"
        Else
            lblMessage.Text = " Data not Updated !" & SaveList.Message
        End If
    End Sub

    Private Sub ddlPLNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlPLNumber.SelectedIndexChanged
        lblMessage.Text = ""
        ClearVal()
        dgSavedData.DataSource = Nothing
        dgSavedData.DataBind()
        dgSavedData.SelectedIndex = -1
        Dim ds As New DataSet()
        Dim Done As Boolean
        Try
            ds = CriticalItems.ItemTables.StockDetails(ddlPLNumber.SelectedItem.Text.Trim, lblConsignee.Text)
            If ds.Tables(0).Rows.Count <= 0 Then
                lblMessage.Text = " PL Number : '" & ddlPLNumber.SelectedItem.Text.Trim & "' does not exists in ItemMaster !"
                ddlPLNumber.SelectedIndex = 0
                ds.Dispose()
                Exit Try
            End If
            lblPlDesc.Text = ds.Tables(0).Rows(0).Item(1)
            lblRecoupType.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item(2)), "", ds.Tables(0).Rows(0).Item(2))
            lblRecoupQty.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item(3)), "", ds.Tables(0).Rows(0).Item(3))
            lblLastIssueDate.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item(5)), "01-01-1900", ds.Tables(0).Rows(0).Item(5))
            txtEquip.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item(6)), "", ds.Tables(0).Rows(0).Item(6))
            dgSavedData.DataSource = ds.Tables(2).DefaultView
            dgSavedData.DataBind()
            PopulateSavedData(ddlPLNumber.SelectedItem.Text.Trim, lblConsignee.Text)
            Done = True
        Catch exp As Exception
            lblMessage.Text = exp.Message
            ds = Nothing
        Finally
            If Done = True Then
                ds.Dispose()
            End If
        End Try
    End Sub

    Private Sub dgSavedData_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgSavedData.ItemCommand
        lblMessage.Text = ""
        ClearVal()
        Try
            Select Case e.CommandName
                Case "Select"
                    txtSlNo.Text = e.Item.Cells(2).Text.Trim
                    txtEquip.Text = e.Item.Cells(3).Text.Trim.Replace("&nbsp;", "")
                    txtNum.Text = e.Item.Cells(5).Text.Trim
                    txtDt.Text = e.Item.Cells(6).Text.Trim
                    txtQty.Text = e.Item.Cells(7).Text.Trim
                    txtDD.Text = IIf(IsDBNull(e.Item.Cells(8).Text.Trim), "", e.Item.Cells(8).Text.Trim).Replace("&nbsp;", "0")
                    txtSup.Text = e.Item.Cells(9).Text.Trim.Replace("&nbsp;", "")
                    txtRecdQty.Text = IIf(IsDBNull(e.Item.Cells(10).Text.Trim), "0.000", e.Item.Cells(10).Text.Trim).Replace("&nbsp;", "0")
                    txtQtyUT.Text = IIf(IsDBNull(e.Item.Cells(11).Text.Trim), "0.000", e.Item.Cells(11).Text.Trim).Replace("&nbsp;", "0")
                    txtQtyDue.Text = IIf(IsDBNull(e.Item.Cells(12).Text.Trim), "0.000", e.Item.Cells(12).Text.Trim).Replace("&nbsp;", "0")
                    txtRemarks.Text = e.Item.Cells(13).Text.Trim.Replace("&nbsp;", "")
                    lblRecID.Text = e.Item.Cells(14).Text.Trim
            End Select
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
End Class
