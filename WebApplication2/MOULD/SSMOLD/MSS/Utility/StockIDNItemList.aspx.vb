Public Class StockIDNItemList1
    Inherits System.Web.UI.Page
    Protected WithEvents txtIDNNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblIDNDate As System.Web.UI.WebControls.Label
    Protected WithEvents lblPLNumber As System.Web.UI.WebControls.Label
    Protected WithEvents lblPLDesc As System.Web.UI.WebControls.Label
    Protected WithEvents lblPONumber As System.Web.UI.WebControls.Label
    Protected WithEvents lblPOSupplier As System.Web.UI.WebControls.Label
    Protected WithEvents txtReceivedDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtClearedDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents dgStockIDN As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblSupplierCode As System.Web.UI.WebControls.Label
    Protected WithEvents lblConsignee As System.Web.UI.WebControls.Label
    Protected WithEvents lblIDNQty As System.Web.UI.WebControls.Label
    Protected WithEvents lblPLUnit As System.Web.UI.WebControls.Label
    Protected WithEvents lblPOQty As System.Web.UI.WebControls.Label
    Protected WithEvents lblDumpNo1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblPODate As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage11 As System.Web.UI.WebControls.Label

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
                lblConsignee.Text = CriticalItems.ItemTables.GetConsignee(Group, UserId)
                If lblConsignee.Text.Trim.Length = 4 Then InValid = True
            Catch exp As Exception
                lblMessage11.Text = exp.Message
            End Try
            If Not InValid Then
                Response.Redirect("/wap/logon.aspx")
            End If
            lblSupplierCode.Visible = False
        End If
    End Sub

    Private Sub txtReceivedDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReceivedDate.TextChanged
        lblMessage11.Text = ""
        Dim dt As Date
        Try
            dt = CDate(txtReceivedDate.Text.Trim)
        Catch exp As Exception
            lblMessage11.Text = " Date : '" & txtReceivedDate.Text.Trim & "' not in correct format.  " & exp.Message
            txtReceivedDate.Text = ""
        End Try
    End Sub

    Private Sub txtClearedDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtClearedDate.TextChanged
        lblMessage11.Text = ""
        Dim dt As Date
        Try
            dt = CDate(txtClearedDate.Text.Trim)
        Catch exp As Exception
            lblMessage11.Text = " Date : '" & txtClearedDate.Text.Trim & "' not in correct format.  " & exp.Message
            txtClearedDate.Text = ""
        End Try
    End Sub

    Private Sub txtIDNNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIDNNumber.TextChanged
        lblMessage11.Text = ""
        ClearVal()
        Dim dv As New DataView()
        Try
            dv = CriticalItems.ItemTables.GetIDNDetails(txtIDNNumber.Text.Trim).DefaultView
            If dv.Table.Rows.Count > 0 Then
                lblIDNDate.Text = dv.Table.Rows(0).Item(1)
                lblPLNumber.Text = dv.Table.Rows(0).Item(2)
                lblPLDesc.Text = dv.Table.Rows(0).Item(3)
                lblPONumber.Text = dv.Table.Rows(0).Item(4)
                lblPOSupplier.Text = dv.Table.Rows(0).Item(5)
                lblSupplierCode.Text = dv.Table.Rows(0).Item(6)
                lblDumpNo1.Text = IIf(IsDBNull(dv.Table.Rows(0).Item(7)), "", dv.Table.Rows(0).Item(7))
                lblIDNQty.Text = IIf(IsDBNull(dv.Table.Rows(0).Item(8)), "", dv.Table.Rows(0).Item(8))
                lblPOQty.Text = IIf(IsDBNull(dv.Table.Rows(0).Item(9)), "", dv.Table.Rows(0).Item(9))
                lblPLUnit.Text = IIf(IsDBNull(dv.Table.Rows(0).Item(10)), "", dv.Table.Rows(0).Item(10))
                lblPODate.Text = IIf(IsDBNull(dv.Table.Rows(0).Item(11)), "", dv.Table.Rows(0).Item(11))
                PopulateSavedData(txtIDNNumber.Text.Trim)
            Else
                lblMessage11.Text = " No Details for IDN Number : '" & txtIDNNumber.Text.Trim & "' "
                txtIDNNumber.Text = ""
            End If
        Catch exp As Exception
            lblMessage11.Text = exp.Message
            dv = Nothing
        Finally
            dv.Dispose()
        End Try
    End Sub
    Private Sub PopulateSavedData(ByVal IDNNumber As String)
        dgStockIDN.DataSource = Nothing
        dgStockIDN.DataBind()
        Dim dv As New DataView()
        Try
            dv = CriticalItems.ItemTables.SavedIDNDetails(IDNNumber, lblConsignee.Text).DefaultView
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
        lblIDNDate.Text = ""
        lblPLNumber.Text = ""
        lblPLDesc.Text = ""
        lblPONumber.Text = ""
        lblPOSupplier.Text = ""
        lblSupplierCode.Text = ""
        txtReceivedDate.Text = "1900-01-01"
        txtClearedDate.Text = "1900-01-01"
        txtRemarks.Text = ""
        lblDumpNo1.Text = ""
        lblIDNQty.Text = ""
        lblPOQty.Text = ""
        lblPLUnit.Text = ""
        lblPODate.Text = ""
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage11.Text = ""
        Dim blnSave As Boolean
        Dim IDNs As New CriticalItems.StockIDNS(lblConsignee.Text)
        Try
            IDNs.IDNNumber = txtIDNNumber.Text.Trim
            IDNs.IdnDate = CDate(lblIDNDate.Text.Trim)
            IDNs.PLNumber = lblPLNumber.Text
            IDNs.PONumber = lblPONumber.Text
            IDNs.SupplierCode = lblSupplierCode.Text
            IDNs.ReceivedDate = CDate(txtReceivedDate.Text.Trim)
            IDNs.Remarks = txtRemarks.Text.Trim.ToUpper
            IDNs.Consignee = lblConsignee.Text
            IDNs.DeleteStatus = False
            If IDNs.SaveIDNs Then
                blnSave = True
                ClearVal()
            End If
            PopulateSavedData(txtIDNNumber.Text.Trim)
        Catch exp As Exception
            lblMessage11.Text = IDNs.Message & exp.Message
        Finally
            IDNs = Nothing
        End Try
        If blnSave Then
            lblMessage11.Text = " Data Saved ! "
        Else
            lblMessage11.Text &= "  Data Not Saved ! "
        End If
    End Sub
End Class
