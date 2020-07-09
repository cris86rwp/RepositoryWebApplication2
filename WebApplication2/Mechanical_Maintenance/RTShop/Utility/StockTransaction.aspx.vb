Public Class StockTransaction
    Inherits System.Web.UI.Page
    Protected WithEvents pnlMain As System.Web.UI.WebControls.Panel
    Protected WithEvents ddlTransType As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtPlNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLedgerNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPageNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblPlDesc As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblTrDt As System.Web.UI.WebControls.Label
    Protected WithEvents lblTrTy As System.Web.UI.WebControls.Label
    Protected WithEvents lblBa As System.Web.UI.WebControls.Label
    Protected WithEvents pnlPlDesc As System.Web.UI.WebControls.Panel
    Protected WithEvents txtTransDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBalance As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblPlUnit As System.Web.UI.WebControls.Label
    Protected WithEvents pnlIssue1 As System.Web.UI.WebControls.Panel
    Protected WithEvents txtPOChalNoteDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPOChalNoteNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblReceiveType2 As System.Web.UI.WebControls.Label
    Protected WithEvents txtIDNLPDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtIDNLPNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblReceiveType1 As System.Web.UI.WebControls.Label
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents pnlSave As System.Web.UI.WebControls.Panel
    Protected WithEvents lblGroup As System.Web.UI.WebControls.Label
    Protected WithEvents lblUserID As System.Web.UI.WebControls.Label
    Protected WithEvents lblConsignee As System.Web.UI.WebControls.Label
    Protected WithEvents txtOrderQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblPLID As System.Web.UI.WebControls.Label
    Protected WithEvents lblQty As System.Web.UI.WebControls.Label
    Protected WithEvents lblPlUnit1 As System.Web.UI.WebControls.Label
    Protected WithEvents ddlLocation As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlMachineID As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtReceiptRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblDate As System.Web.UI.WebControls.Label
    Protected WithEvents lblLastIss As System.Web.UI.WebControls.Label
    Protected WithEvents txtRate As System.Web.UI.WebControls.TextBox
    Dim grp As String
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
            Dim dt As Date
            dt = Now.Date
            txtTransDate.Text = dt
            'Session("group") = "MA1"
            'Session("UserID") = "073306"
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
    Private Sub ClearPrev()
        lblTrDt.Text = ""
        lblTrTy.Text = ""
        lblQty.Text = ""
        lblBa.Text = ""
        lblLastIss.Text = ""
    End Sub
    Private Sub ClearPLDesc()
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
            ddlTransType.Items.Insert(0, "Select")
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
            ddlMachineID.Items.Insert(0, New ListItem("Select", "0"))
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
        ClearPrev()
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
        If ddlTransType.SelectedIndex = 0 Then
            lblMessage.Text = " Please select Transaction Type ! "
            txtPlNumber.Text = ""
            Exit Sub
        Else
            Try
                ds = SubStoreStock.Tables.GetPLDetails(PlNumber.Trim, ddlTransType.SelectedItem.Value, lblGroup.Text.Trim, lblConsignee.Text.Trim)
                If IIf(IsDBNull(ds.Tables(0).Rows(0).Item(0)), 0, ds.Tables(0).Rows(0).Item(0)) = 0 Then
                    lblMessage.Text &= "PL Number and Description not found in Master"
                    lblPlDesc.Text = ""
                    lblPlUnit.Text = ""
                    Exit Try
                End If
                lblPlDesc.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item(1)), "", Trim(ds.Tables(0).Rows(0).Item(1)))
                lblPlUnit.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item(2)), "", Trim(ds.Tables(0).Rows(0).Item(2)))
                lblPlUnit1.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item(2)), "", Trim(ds.Tables(0).Rows(0).Item(2)))
                If ds.Tables(1).Rows.Count > 0 Then
                    lblPLID.Text = IIf(IsDBNull(ds.Tables(1).Rows(0).Item(0)), 0, ds.Tables(1).Rows(0).Item(0)) 'ds.Tables(1).Rows(0).Item(0)
                    txtOrderQty.Text = IIf(IsDBNull(ds.Tables(1).Rows(0).Item(1)), 0, ds.Tables(1).Rows(0).Item(1))
                    txtLedgerNo.Text = IIf(IsDBNull(ds.Tables(1).Rows(0).Item(2)), "", ds.Tables(1).Rows(0).Item(2))
                    txtPageNo.Text = IIf(IsDBNull(ds.Tables(1).Rows(0).Item(3)), 0, ds.Tables(1).Rows(0).Item(3))
                    If Val(txtRate.Text) = 0 Then
                        txtRate.Text = IIf(IsDBNull(ds.Tables(1).Rows(0).Item(4)), 0, ds.Tables(1).Rows(0).Item(4))
                    End If
                    dv.Table = ds.Tables(2)
                    If ds.Tables(2).Rows.Count > 0 Then
                        lblTrDt.Text = IIf(IsDBNull(dv.Item(0)(0)), "", dv.Item(0)(0))
                        lblTrTy.Text = IIf(IsDBNull(dv.Item(0)(1)), "", dv.Item(0)(1))
                        lblQty.Text = IIf(IsDBNull(dv.Item(0)(2)), "0", dv.Item(0)(2))
                        lblBa.Text = IIf(IsDBNull(dv.Item(0)(3)), "", dv.Item(0)(3))
                        If Not dv.Item(0)(4) Is Nothing Then
                            For i = 0 To ddlLocation.Items.Count - 1
                                If ddlLocation.Items(i).Value = dv.Item(0)(4) Then
                                    ddlLocation.SelectedIndex = i
                                    Exit For
                                End If
                            Next
                        End If
                        lblLastIss.Text = IIf(IsDBNull(dv.Item(0)(5)), "", dv.Item(0)(5).Replace("&nbsp;", ""))
                    End If
                Else
                    lblMessage.Text = "No previous entry exists !"
                End If
            Catch exp As Exception
                lblMessage.Text = exp.Message
            Finally
                ds.Dispose()
                dv.Dispose()
                dv1.Dispose()
            End Try
        End If
    End Sub
    Private Sub ddlTransType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlTransType.SelectedIndexChanged
        ClearPLDesc()
        ClearIDNno()
        ClearAcc()
        ClearPrev()
        lblMessage.Text = ""
        txtPlNumber.Text = ""
        lblReceiveType1.Text = ""
        lblReceiveType2.Text = ""
        If ddlTransType.SelectedIndex = 0 Then
            lblMessage.Text = "Please select Transaction Type !"
        Else
            Dim dt As New DataTable()
            lblReceiveType2.Visible = False
            txtPOChalNoteNo.Visible = False
            txtPOChalNoteDate.Visible = False
            lblDate.Visible = False
            Try
                dt = SubStoreStock.Tables.TransactionName(ddlTransType.SelectedItem.Value)
                lblReceiveType1.Text = IIf(IsDBNull(IsNothing(dt.Rows(0)(0))), "", Trim(dt.Rows(0)(0)))
                lblReceiveType2.Text = IIf(IsDBNull(IsNothing(dt.Rows(0)(1))), "", Trim(dt.Rows(0)(1)))
                If ddlTransType.SelectedItem.Value <> 1 Then
                    lblReceiveType2.Visible = True
                    txtPOChalNoteNo.Visible = True
                    txtPOChalNoteDate.Visible = True
                    lblDate.Visible = True
                End If
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
    Private Sub GetINDENTDetails()
        lblMessage.Text = ""
        Dim ds As New DataSet()
        Try
            ds = imb.GetINDENTDetails(txtIDNLPNo.Text.Trim)
            If IIf(IsDBNull(ds.Tables(0).Rows(0)(0)), 0, ds.Tables(0).Rows(0)(0)) = 0 Then
                lblMessage.Text = " This INDENT No : '" & txtIDNLPNo.Text & "' is not valid "
                txtIDNLPNo.Text = ""
                Exit Sub
            Else
                txtIDNLPNo.Text = txtIDNLPNo.Text.ToUpper
            End If
            txtIDNLPNo.Text = ds.Tables(1).Rows(0)(0)
            txtIDNLPDate.Text = ds.Tables(1).Rows(0)(1)
            txtPlNumber.Text = ds.Tables(1).Rows(0)(3)
            lblPlDesc.Text = ds.Tables(1).Rows(0)(4)
            lblPlUnit.Text = ds.Tables(1).Rows(0)(5)
            lblPlUnit1.Text = ds.Tables(1).Rows(0)(5)
            txtPOChalNoteNo.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)(6)), "", ds.Tables(1).Rows(0)(6))
            txtPOChalNoteDate.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)(7)), "", ds.Tables(1).Rows(0)(7))
            txtRate.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)(8)), "", ds.Tables(1).Rows(0)(8))
            GetPlDetails(Trim(ds.Tables(1).Rows(0)(3)))
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            ds.Dispose()
        End Try
    End Sub
    Private Sub GetNSIDNDetails()
        Dim ds As New DataSet()
        Try
            ds = imb.GetNSIDNDetails(txtIDNLPNo.Text.Trim)
            If ds.Tables(0).Rows.Count = 0 Then
                lblMessage.Text = " This NS IDN No : '" & txtIDNLPNo.Text & "' is not valid "
                txtIDNLPNo.Text = ""
                Exit Try
            End If
            If ds.Tables(1).Rows.Count = 0 Then
                lblMessage.Text = " This NSIDNno : '" & txtIDNLPNo.Text.Trim & "' is not valid  "
                txtIDNLPNo.Text = ""
                Exit Try
            End If
            If IIf(IsDBNull(ds.Tables(1).Rows(0)(0)), "", ds.Tables(1).Rows(0)(0)) = "" Then
                lblMessage.Text = " This NSIDNno : '" & txtIDNLPNo.Text.Trim & "' is not valid  "
                txtIDNLPNo.Text = ""
                Exit Try
            End If
            txtIDNLPDate.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)(2)), "", ds.Tables(1).Rows(0)(2)) 'ds.Tables(1).Rows(0)(2)
            txtPOChalNoteNo.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)(3)), "", ds.Tables(1).Rows(0)(3)) 'ds.Tables(1).Rows(0)(3)
            txtPOChalNoteDate.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)(4)), "", ds.Tables(1).Rows(0)(4)) 'ds.Tables(1).Rows(0)(4)
            txtPlNumber.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)(6)), "", ds.Tables(1).Rows(0)(6)) ' ds.Tables(1).Rows(0)(6)
            lblPlDesc.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)(7)), "", ds.Tables(1).Rows(0)(7)) ' ds.Tables(1).Rows(0)(7)
            lblPlUnit.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)(8)), "", ds.Tables(1).Rows(0)(8)) 'ds.Tables(1).Rows(0)(8)
            lblPlUnit1.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)(8)), "", ds.Tables(1).Rows(0)(8)) 'ds.Tables(1).Rows(0)(8)
            GetPlDetails(Trim(ds.Tables(1).Rows(0)(6)))
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            ds.Dispose()
        End Try
    End Sub
    Private Sub GetS1313Details()
        lblMessage.Text = ""
        Dim ds As New DataSet()
        Try
            ds = SubStoreStock.Tables.S1313Details(lblConsignee.Text.Trim, txtPlNumber.Text.Trim, txtIDNLPNo.Text.Trim)
            If ds.Tables(0).Rows.Count = 0 Then
                lblMessage.Text = " This Requesition No : '" & txtIDNLPNo.Text & "' is not valid "
                txtIDNLPNo.Text = ""
                Exit Sub
            Else
                txtIDNLPNo.Text = ds.Tables(0).Rows(0)(0)
                txtIDNLPDate.Text = ds.Tables(0).Rows(0)(1)
                txtPlNumber.Text = ds.Tables(0).Rows(0)(2)
                lblPlDesc.Text = ds.Tables(0).Rows(0)(3)
                lblPlUnit.Text = ds.Tables(0).Rows(0)(4)
                lblPlUnit1.Text = ds.Tables(0).Rows(0)(4)
                GetPlDetails(Trim(ds.Tables(0).Rows(0)(2)))
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            ds.Dispose()
        End Try
    End Sub
    Private Sub GetPODetails()
        Dim ds As New DataSet()
        Try
            ds = SubStoreStock.Tables.PODetails(lblConsignee.Text.Trim, txtPlNumber.Text.Trim, txtIDNLPNo.Text.Trim)
            If ds.Tables(0).Rows.Count = 0 Then
                lblMessage.Text = " This PO No : '" & txtIDNLPNo.Text & "' is not valid "
                txtIDNLPNo.Text = ""
                Exit Try
            End If
            txtIDNLPDate.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)(1)), "", ds.Tables(0).Rows(0)(1)) 'ds.Tables(1).Rows(0)(2)
            txtPlNumber.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)(5)), "", ds.Tables(0).Rows(0)(5)) ' ds.Tables(1).Rows(0)(6)
            lblPlDesc.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)(6)), "", ds.Tables(0).Rows(0)(6)) ' ds.Tables(1).Rows(0)(7)
            lblPlUnit.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)(8)), "", ds.Tables(0).Rows(0)(8)) 'ds.Tables(1).Rows(0)(8)
            lblPlUnit1.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)(8)), "", ds.Tables(0).Rows(0)(8)) 'ds.Tables(1).Rows(0)(8)
            GetPlDetails(Trim(ds.Tables(0).Rows(0)(5)))
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            ds.Dispose()
        End Try
    End Sub
    Private Sub txtIDNLPNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIDNLPNo.TextChanged
        lblMessage.Text = ""
        'ClearPLDesc()
        ClearAcc()
        If Not lblReceiveType1.Text.StartsWith("ISS") Then
            ClearPrev()
        End If
        Try
            If lblReceiveType1.Text = "NSIDN No" Then
                'code for fetching NS IDN Details
                GetNSIDNDetails()
            ElseIf lblReceiveType1.Text = "Indent No" Then
                'code for fetching indent number Details  
                GetINDENTDetails()
            ElseIf lblReceiveType1.Text = "Requisition No" Then
                'code for fetching s1313 Details  
                GetS1313Details()
            ElseIf lblReceiveType1.Text = "PO Number" Then
                'code for fetching s1313 Details  
                GetPODetails()
            End If
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
            Try
                oStore.LinkDate = CDate(txtPOChalNoteDate.Text)
            Catch EXP As Exception
                oStore.LinkDate = "1900-01-01"
            End Try
            'oStore.LinkDate = IIf((txtPOChalNoteDate.Text.Trim = ""), CDate("1900-01-01"), CDate(txtPOChalNoteDate.Text))
            oStore.MachineCode = ddlMachineID.SelectedItem.Value.Trim
            If oStore.SaveStore(lblPLID.Text) Then
                lblMessage.Text = oStore.Message
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        txtPlNumber.Text = ""
        txtTransDate.Text = ""
        ClearPLDesc()
        ClearIDNno()
        ClearAcc()
        ClearPrev()
    End Sub
End Class
