Public Class StockIDNItemListEdit
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblIDNDate As System.Web.UI.WebControls.Label
    Protected WithEvents lblPLNumber As System.Web.UI.WebControls.Label
    Protected WithEvents lblPLDesc As System.Web.UI.WebControls.Label
    Protected WithEvents lblPONumber As System.Web.UI.WebControls.Label
    Protected WithEvents lblSupplierCode As System.Web.UI.WebControls.Label
    Protected WithEvents lblPOSupplier As System.Web.UI.WebControls.Label
    Protected WithEvents txtReceivedDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtClearedDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents dgStockIDN As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblIDNid1 As System.Web.UI.WebControls.Label
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents lblConsignee1 As System.Web.UI.WebControls.Label
    Protected WithEvents ddlIDNNumber1 As System.Web.UI.WebControls.DropDownList

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
            lblMessage.Text = ""
            lblIDNid1.Visible = False
            Dim Group As String = Session("Group")
            Dim strMode As String = Request.QueryString("mode")
            Dim UserId As String = Session("UserID")
            Dim InValid As Boolean = False
            Try
                lblConsignee1.Text = CriticalItems.ItemTables.GetConsignee(Group, UserId)
                If lblConsignee1.Text.Trim.Length = 4 Then InValid = True
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            If Not InValid Then
                Response.Redirect("/wap/logon.aspx")
            End If
            ClearVal()
            PopulateDDL()
            dgStockIDN.DataSource = Nothing
            dgStockIDN.DataBind()
        End If
    End Sub
    Private Sub PopulateDDL()
        Dim dv As New DataView()
        Try
            dv = CriticalItems.ItemTables.GetIDNs(lblConsignee1.Text).DefaultView
            ddlIDNNumber1.DataSource = dv
            ddlIDNNumber1.DataTextField = dv.Table.Columns(0).ColumnName
            ddlIDNNumber1.DataValueField = dv.Table.Columns(0).ColumnName
            ddlIDNNumber1.DataBind()
            ddlIDNNumber1.Items.Insert(0, "select")
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            dv.Dispose()
        End Try
    End Sub
    Private Sub ClearVal()
        lblIDNDate.Text = ""
        lblPLNumber.Text = ""
        lblPLDesc.Text = ""
        lblPONumber.Text = ""
        lblPOSupplier.Text = ""
        lblSupplierCode.Text = ""
        txtReceivedDate.Text = ""
        txtClearedDate.Text = ""
        txtRemarks.Text = ""
    End Sub
    Private Sub txtReceivedDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReceivedDate.TextChanged
        lblMessage.Text = ""
        Dim dt As Date
        Try
            dt = CDate(txtReceivedDate.Text.Trim)
        Catch exp As Exception
            lblMessage.Text = " Date : '" & txtReceivedDate.Text.Trim & "' not in correct format.  " & exp.Message
            txtReceivedDate.Text = ""
        End Try
    End Sub
    Private Sub txtClearedDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtClearedDate.TextChanged
        lblMessage.Text = ""
        Dim dt As Date
        Try
            dt = CDate(txtClearedDate.Text.Trim)
        Catch exp As Exception
            lblMessage.Text = " Date : '" & txtClearedDate.Text.Trim & "' not in correct format.  " & exp.Message
            txtClearedDate.Text = ""
        End Try
    End Sub
    Private Sub PopulateSavedData(ByVal IDNNumber As String)
        dgStockIDN.DataSource = Nothing
        dgStockIDN.DataBind()
        Dim dv As New DataView()
        Try
            dv = CriticalItems.ItemTables.SavedIDNDetails(IDNNumber, lblConsignee1.Text).DefaultView
            dgStockIDN.DataSource = dv
            dgStockIDN.DataBind()
            If dv.Table.Rows.Count > 0 Then dgStockIDN.Visible = True
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            dv.Dispose()
        End Try
    End Sub
    Private Sub ddlIDNNumber1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlIDNNumber1.SelectedIndexChanged
        lblMessage.Text = ""
        ClearVal()
        Dim dv As New DataView()
        Try
            dv = CriticalItems.ItemTables.SavedIDNDetails(ddlIDNNumber1.SelectedItem.Text.Trim, lblConsignee1.Text).DefaultView
            If dv.Table.Rows.Count > 0 Then
                lblIDNDate.Text = dv.Table.Rows(0).Item(1)
                lblPLNumber.Text = dv.Table.Rows(0).Item(2)
                lblPLDesc.Text = dv.Table.Rows(0).Item(3)
                lblPONumber.Text = dv.Table.Rows(0).Item(4)
                lblPOSupplier.Text = dv.Table.Rows(0).Item(5)
                lblIDNid1.Text = dv.Table.Rows(0).Item(6)
                txtReceivedDate.Text = dv.Table.Rows(0).Item(7)
                txtClearedDate.Text = dv.Table.Rows(0).Item(8)
                txtRemarks.Text = dv.Table.Rows(0).Item(9)
                PopulateSavedData(ddlIDNNumber1.SelectedItem.Text.Trim)
            Else
                lblMessage.Text = " No Details for IDN Number : '" & ddlIDNNumber1.SelectedItem.Text.Trim & "' "
                ddlIDNNumber1.SelectedIndex = 0
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
            dv = Nothing
        Finally
            dv.Dispose()
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        Dim IDNs As New CriticalItems.StockIDNS(lblConsignee1.Text)
        If ddlIDNNumber1.SelectedItem.Text.ToLower = "select" Then
            lblMessage.Text = " Please select IDN Number !"
            Exit Sub
        Else
            Dim blnSave As Boolean
            Try
                IDNs.ReceivedDate = CDate(txtReceivedDate.Text.Trim)
                IDNs.ClearedDate = CDate(txtClearedDate.Text.Trim)
                IDNs.Remarks = txtRemarks.Text.Trim.ToUpper
                IDNs.IDNNumber = ddlIDNNumber1.SelectedItem.Text.Trim
                IDNs.IDNid = lblIDNid1.Text.Trim
                IDNs.Consignee = lblConsignee1.Text
                If IDNs.SaveIDNs(IDNs.IDNid) Then
                    blnSave = True
                    ClearVal()
                End If
                PopulateSavedData(ddlIDNNumber1.SelectedItem.Text.Trim)
                ddlIDNNumber1.SelectedIndex = 0
            Catch exp As Exception
                lblMessage.Text = IDNs.Message & exp.Message
            Finally
                IDNs = Nothing
            End Try
            If blnSave Then
                lblMessage.Text = " Data Edited ! "
            Else
                lblMessage.Text &= "  Data Not Edited ! "
            End If
        End If
    End Sub

End Class
