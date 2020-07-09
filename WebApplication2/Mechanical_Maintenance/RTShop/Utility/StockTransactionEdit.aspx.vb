Public Class StockTransactionEdit
    Inherits System.Web.UI.Page
    Protected WithEvents lblGroup As System.Web.UI.WebControls.Label
    Protected WithEvents lblUserID As System.Web.UI.WebControls.Label
    Protected WithEvents lblConsignee As System.Web.UI.WebControls.Label
    Protected WithEvents lblPLID As System.Web.UI.WebControls.Label
    Protected WithEvents ddlTransType As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtPlNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLedgerNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPageNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlLocation As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtOrderQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblPlDesc As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlMachineID As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblReceiveType1 As System.Web.UI.WebControls.Label
    Protected WithEvents txtIDNLPNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtIDNLPDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTransDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblReceiveType2 As System.Web.UI.WebControls.Label
    Protected WithEvents txtPOChalNoteNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblDate As System.Web.UI.WebControls.Label
    Protected WithEvents txtPOChalNoteDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBalance As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtReceiptRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblPlUnit As System.Web.UI.WebControls.Label
    Protected WithEvents lblPlUnit1 As System.Web.UI.WebControls.Label
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents pnlPlDesc As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlMain As System.Web.UI.WebControls.Panel
    Protected WithEvents dgData As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblTransID As System.Web.UI.WebControls.Label
    Protected WithEvents txtRate As System.Web.UI.WebControls.TextBox
    Protected WithEvents pnlIssue1 As System.Web.UI.WebControls.Panel

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
        'Session("Group") = "MW2"
        'Session("UserId") = "078844"
        'Put user code to initialize the page here
        If Not IsPostBack Then
            lblGroup.Visible = False
            lblUserID.Visible = False
            lblPLID.Visible = False
            lblTransID.Visible = False
            Dim dt As Date
            dt = Now.Date
            txtTransDate.Text = dt
            'Session("group") = "MA2"
            lblUserID.Text = Session("UserID")
            lblGroup.Text = Session("group")
            Dim InValid As Boolean = False
            Try
                lblConsignee.Text = CriticalItems.ItemTables.GetConsignee(lblGroup.Text.Trim, lblUserID.Text.Trim)
                If lblConsignee.Text.Trim.Length = 4 Then InValid = True
                PopulateType()
                PopulateLocation()
                PopulateMachineIDs()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            If Not InValid Then
                ' Response.Redirect("/wap/logon.aspx")
            End If
        End If
    End Sub
    Private Sub ClearPLDesc()
        lblTransID.Text = 0
        lblPLID.Text = 0
        lblPlDesc.Text = ""
        lblPlUnit.Text = ""
        lblPlUnit1.Text = ""
        txtLedgerNo.Text = ""
        txtPageNo.Text = ""
        txtOrderQty.Text = ""
        ddlLocation.SelectedIndex = 0
        ddlMachineID.SelectedIndex = 0
    End Sub
    Private Sub ClearIDNno()
        txtIDNLPNo.Text = ""
        txtIDNLPDate.Text = ""
        txtPOChalNoteNo.Text = ""
        txtPOChalNoteDate.Text = ""
        txtReceiptRemarks.Text = ""
    End Sub
    Private Sub ClearAcc()
        txtQty.Text = ""
        txtBalance.Text = ""
    End Sub
    Private Sub Clear()
        lblPlDesc.Text = ""
        lblPlUnit.Text = ""
        lblPlUnit1.Text = ""
        txtIDNLPNo.Text = ""
        txtIDNLPDate.Text = ""
        txtPOChalNoteNo.Text = ""
        txtPOChalNoteDate.Text = ""
    End Sub
    Private Sub PopulateType()
        Dim dt As New DataTable()
        Try
            dt = SubStoreStock.Tables.TransType
            ddlTransType.DataSource = dt.DefaultView
            ddlTransType.DataTextField = dt.Columns(0).ColumnName
            ddlTransType.DataValueField = dt.Columns(1).ColumnName
            ddlTransType.DataBind()
            ddlTransType.Items.Insert(0, New ListItem("ALL", 0))
        Catch exp As Exception
            lblMessage.Text = ""
        End Try
    End Sub
    Private Sub PopulateMachineIDs()
        Dim dt As New DataTable()
        Try
            dt = SubStoreStock.Tables.MachineIDs(lblGroup.Text.Trim)
            ddlMachineID.DataSource = dt.DefaultView
            ddlMachineID.DataTextField = dt.Columns(1).ColumnName
            ddlMachineID.DataValueField = dt.Columns(0).ColumnName
            ddlMachineID.DataBind()
        Catch exp As Exception
            lblMessage.Text = ""
        End Try
    End Sub
    Private Sub PopulateLocation()
        Dim dt As New DataTable()
        Try
            dt = SubStoreStock.Tables.Location(lblConsignee.Text.Trim)
            ddlLocation.DataSource = dt.DefaultView
            ddlLocation.DataTextField = dt.Columns(0).ColumnName
            ddlLocation.DataValueField = dt.Columns(2).ColumnName
            ddlLocation.DataBind()
            ddlLocation.Items.Insert(0, New ListItem("Select", "0"))
        Catch exp As Exception
            lblMessage.Text = ""
        Finally
            dt.Dispose()
        End Try
    End Sub
    Private Sub txtPlNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPlNumber.TextChanged
        lblMessage.Text = ""
        ClearPLDesc()
        ClearIDNno()
        ClearAcc()
        If txtPlNumber.Text.Trim.Length <> 8 Then
            lblMessage.Text = "InValid PL Number : " & txtPlNumber.Text.Trim & "!"
            txtPlNumber.Text = ""
            Exit Sub
        ElseIf ddlTransType.SelectedItem.Value = 6 Then
            If Not txtPlNumber.Text.StartsWith("0") Then
                lblMessage.Text = "InValid PL Number : " & txtPlNumber.Text.Trim & "!"
                txtPlNumber.Text = ""
                Exit Sub
            End If
        End If
        Try
            GetPlDetails(txtPlNumber.Text.Trim)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub GetPlDetails(ByVal PlNumber As String)
        Dim ds As New DataSet()
        Dim PLnum, strPreData As String
        Dim dv As New DataView()
        Dim dv1 As New DataView()
        Dim i As Integer
        dgData.DataSource = Nothing
        dgData.DataBind()
        Try
            ds = SubStoreStock.Tables.GetPLDetailsForEdit(PlNumber.Trim, ddlTransType.SelectedItem.Value, lblGroup.Text.Trim, lblConsignee.Text.Trim)
            If ds.Tables(0).Rows.Count <= 0 Then
                lblMessage.Text &= "PL Number : " & txtPlNumber.Text.Trim & " not found in Master"
                lblPlDesc.Text = ""
                lblPlUnit.Text = ""
                txtPlNumber.Text = ""
                Exit Try
            ElseIf ds.Tables(1).Rows.Count = 0 Then
                lblMessage.Text &= "PL Number : " & txtPlNumber.Text.Trim & " not entered in Store Master or no entries for '" & ddlTransType.SelectedItem.Text.Trim & "' TransactionType !"
                txtPlNumber.Text = ""
                Exit Try
            End If
            lblPlDesc.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item(1)), "", Trim(ds.Tables(0).Rows(0).Item(1)))
            lblPlUnit.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item(2)), "", Trim(ds.Tables(0).Rows(0).Item(2)))
            lblPlUnit1.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item(2)), "", Trim(ds.Tables(0).Rows(0).Item(2)))
            dgData.DataSource = ds.Tables(1).DefaultView
            dgData.DataBind()
        Catch exp As Exception
            Throw New Exception(exp.Message)
        End Try
    End Sub
    Private Sub dgData_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgData.ItemCommand
        lblMessage.Text = ""
        Dim i As Int16
        Try
            Select Case e.CommandName
                Case "Select"
                    txtTransDate.Text = IIf(IsDBNull(e.Item.Cells(1).Text.Trim), "", e.Item.Cells(1).Text.Trim.Replace("&nbsp;", ""))
                    If IIf(IsDBNull(e.Item.Cells(2).Text.Trim), "0", e.Item.Cells(2).Text.Trim) > 0 Then
                        For i = 0 To ddlTransType.Items.Count - 1
                            If ddlTransType.Items(i).Value = e.Item.Cells(2).Text.Trim Then
                                ddlTransType.SelectedIndex = i
                                Exit For
                            End If
                        Next
                    End If
                    txtLedgerNo.Text = IIf(IsDBNull(e.Item.Cells(3).Text.Trim), "", e.Item.Cells(3).Text.Trim.Replace("&nbsp;", ""))
                    txtPageNo.Text = IIf(IsDBNull(e.Item.Cells(4).Text.Trim), "", e.Item.Cells(4).Text.Trim.Replace("&nbsp;", ""))
                    If IIf(IsDBNull(e.Item.Cells(5).Text.Trim), "0", e.Item.Cells(5).Text.Trim) > 0 Then
                        For i = 0 To ddlLocation.Items.Count - 1
                            If ddlLocation.Items(i).Value = e.Item.Cells(5).Text.Trim Then
                                ddlLocation.SelectedIndex = i
                                Exit For
                            End If
                        Next
                    End If
                    txtOrderQty.Text = IIf(IsDBNull(e.Item.Cells(6).Text.Trim), 0, e.Item.Cells(6).Text.Trim.Replace("&nbsp;", ""))
                    If IIf(IsDBNull(e.Item.Cells(7).Text.Trim), "", e.Item.Cells(7).Text.Trim) <> "" Then
                        For i = 0 To ddlMachineID.Items.Count - 1
                            If ddlMachineID.Items(i).Value = e.Item.Cells(7).Text.Trim Then
                                ddlMachineID.SelectedIndex = i
                                Exit For
                            End If
                        Next
                    End If
                    lblReceiveType1.Text = IIf(IsDBNull(e.Item.Cells(8).Text.Trim), "", e.Item.Cells(8).Text.Trim.Replace("&nbsp;", ""))
                    txtIDNLPNo.Text = IIf(IsDBNull(e.Item.Cells(9).Text.Trim), "", e.Item.Cells(9).Text.Trim.Replace("&nbsp;", ""))
                    txtIDNLPDate.Text = IIf(IsDBNull(e.Item.Cells(10).Text.Trim), "", e.Item.Cells(10).Text.Trim.Replace("&nbsp;", ""))
                    lblReceiveType2.Text = IIf(IsDBNull(e.Item.Cells(11).Text.Trim), 0, e.Item.Cells(11).Text.Trim.Replace("&nbsp;", ""))
                    txtPOChalNoteNo.Text = IIf(IsDBNull(e.Item.Cells(12).Text.Trim), "", e.Item.Cells(12).Text.Trim.Replace("&nbsp;", ""))
                    txtPOChalNoteDate.Text = IIf(IsDBNull(e.Item.Cells(13).Text.Trim), "", e.Item.Cells(13).Text.Trim.Replace("&nbsp;", ""))
                    txtReceiptRemarks.Text = IIf(IsDBNull(e.Item.Cells(14).Text.Trim), "", e.Item.Cells(14).Text.Trim.Replace("&nbsp;", ""))
                    txtQty.Text = IIf(IsDBNull(e.Item.Cells(15).Text.Trim), "", e.Item.Cells(15).Text.Trim)
                    txtBalance.Text = IIf(IsDBNull(e.Item.Cells(16).Text.Trim), "", e.Item.Cells(16).Text.Trim)
                    lblPLID.Text = IIf(IsDBNull(e.Item.Cells(17).Text.Trim), "", e.Item.Cells(17).Text.Trim)
                    lblTransID.Text = IIf(IsDBNull(e.Item.Cells(18).Text.Trim), "", e.Item.Cells(18).Text.Trim)
                    txtPlNumber.Text = IIf(IsDBNull(e.Item.Cells(19).Text.Trim), "", e.Item.Cells(19).Text.Trim)
                    txtRate.Text = IIf(IsDBNull(e.Item.Cells(20).Text.Trim), 0, e.Item.Cells(20).Text.Trim.Replace("&nbsp;", ""))
            End Select
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        If ddlTransType.SelectedItem.Text.StartsWith("Receipt") = True Then
            If IsDBNull(txtBalance.Text) = True OrElse Val(txtBalance.Text) < 0 Then
                lblMessage.Text &= " Not valid Balance Quantity! "
                txtBalance.Text = ""
            End If
        End If
        If lblMessage.Text <> "" Then Exit Sub
        lblMessage.Text = ""
        Dim blnSaveOK As Boolean
        Dim oStore As New SubStoreStock.StockMaster()
        Try
            oStore.PLNumber = txtPlNumber.Text.Trim
            oStore.Consignee = lblConsignee.Text.Trim
            oStore.OrderQty = Val(txtOrderQty.Text.Trim)
            oStore.LedgerNo = txtLedgerNo.Text.Trim
            oStore.PageNo = txtPageNo.Text.Trim
            oStore.Rate = Val(txtRate.Text.Trim)
            oStore.TransactionNumber = txtIDNLPNo.Text.Trim
            Try
                oStore.TransactionDate = CDate(txtTransDate.Text.Trim)
            Catch EXP As Exception
                oStore.TransactionDate = "1900-01-01"
            End Try

            oStore.RackID = ddlLocation.SelectedItem.Value
            oStore.TypeID = ddlTransType.SelectedItem.Value
            Try
                oStore.Dated = CDate(txtIDNLPDate.Text.Trim)
            Catch EXP As Exception
                oStore.Dated = "1900-01-01"
            End Try

            oStore.Qty = txtQty.Text
            oStore.Balance = Val(txtBalance.Text.Trim)
            oStore.Remarks = txtReceiptRemarks.Text
            oStore.TransactionLink = txtPOChalNoteNo.Text.Trim
            oStore.LinkDate = IIf((txtPOChalNoteDate.Text.Trim = ""), "1900-01-01", CDate(txtPOChalNoteDate.Text))
            oStore.MachineCode = ddlMachineID.SelectedItem.Value.Trim
            If oStore.SaveStore(lblPLID.Text, lblTransID.Text) Then
                lblMessage.Text = oStore.Message
                GetPlDetails(txtPlNumber.Text.Trim)
                dgData.SelectedIndex = -1
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        txtPlNumber.Text = ""
        txtTransDate.Text = ""
        ClearPLDesc()
        ClearIDNno()
        ClearAcc()
    End Sub
End Class
