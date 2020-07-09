Public Class StockIDNItemListDelete1
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents ddlIDNNumber As System.Web.UI.WebControls.DropDownList
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
    Protected WithEvents lblIDNid As System.Web.UI.WebControls.Label
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents lblConsignee As System.Web.UI.WebControls.Label
    Protected WithEvents dgStockIDN As System.Web.UI.WebControls.DataGrid

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
                Response.Redirect("/wap/logon.aspx")
            End If
            lblIDNid.Visible = False
            ClearVal()
            PopulateDDL()
            dgStockIDN.DataSource = Nothing
            dgStockIDN.DataBind()
        End If
    End Sub
    Private Sub PopulateDDL()
        Dim dv As New DataView()
        Try
            dv = CriticalItems.ItemTables.GetIDNs(lblConsignee.Text).DefaultView
            ddlIDNNumber.DataSource = dv
            ddlIDNNumber.DataTextField = dv.Table.Columns(0).ColumnName
            ddlIDNNumber.DataValueField = dv.Table.Columns(0).ColumnName
            ddlIDNNumber.DataBind()
            ddlIDNNumber.Items.Insert(0, "select")
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
    Private Sub ddlIDNNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlIDNNumber.SelectedIndexChanged
        lblMessage.Text = ""
        ClearVal()
        Dim dv As New DataView()
        Try
            dv = CriticalItems.ItemTables.SavedIDNDetails(ddlIDNNumber.SelectedItem.Text.Trim, lblConsignee.Text).DefaultView
            If dv.Table.Rows.Count > 0 Then
                lblIDNDate.Text = dv.Table.Rows(0).Item(1)
                lblPLNumber.Text = dv.Table.Rows(0).Item(2)
                lblPLDesc.Text = dv.Table.Rows(0).Item(3)
                lblPONumber.Text = dv.Table.Rows(0).Item(4)
                lblPOSupplier.Text = dv.Table.Rows(0).Item(5)
                lblIDNid.Text = dv.Table.Rows(0).Item(6)
                txtReceivedDate.Text = dv.Table.Rows(0).Item(7)
                txtClearedDate.Text = dv.Table.Rows(0).Item(8)
                txtRemarks.Text = dv.Table.Rows(0).Item(9)
                PopulateSavedData(ddlIDNNumber.SelectedItem.Text.Trim)
            Else
                lblMessage.Text = " No Details for IDN Number : '" & ddlIDNNumber.SelectedItem.Text.Trim & "' "
                ddlIDNNumber.SelectedIndex = 0
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
        If ddlIDNNumber.SelectedItem.Text.ToLower = "select" Then
            lblMessage.Text = " Please select IDN Number !"
            Exit Sub
        Else
            Try
                Dim IDNs As New CriticalItems.StockIDNS(lblConsignee.Text)
                Dim blnSave As Boolean
                Try
                    IDNs.IDNNumber = ddlIDNNumber.SelectedItem.Text.Trim
                    IDNs.DeleteStatus = True
                    IDNs.IDNid = Val(lblIDNid.Text)
                    If IDNs.SaveIDNs(IDNs.IDNid, True) Then
                        blnSave = True
                        ClearVal()
                    End If
                    PopulateSavedData(ddlIDNNumber.SelectedItem.Text.Trim)
                    ddlIDNNumber.SelectedIndex = 0
                Catch exp As Exception
                    lblMessage.Text = IDNs.Message & exp.Message
                Finally
                    IDNs = Nothing
                End Try
                If blnSave Then
                    lblMessage.Text = " Data Deleted ! "
                Else
                    lblMessage.Text &= "  Data Not Deleted ! "
                End If
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try

        End If
    End Sub
End Class
