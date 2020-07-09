Public Class ReferenceTaxDetails
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents ddlRefID As System.Web.UI.WebControls.DropDownList
    Protected WithEvents rblGroup As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtInvoiceDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTotalValue As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTaxableValue As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtGoodsHSN As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtGoodsDescription As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlUnitCode As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtQuantity As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRate As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblITC As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtIGSTRate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtIGSTChargedAmt As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCGSTRate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCGSTChargedAmt As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCessRate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCessChargedAmt As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtGoodsName As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPlaceOfSupply As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRecepientGSTIN As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblReverseTax As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtTDS As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents pnlPCO As System.Web.UI.WebControls.Panel
    Protected WithEvents ddlDespatchAdviceNo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents rblInvoice As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents pnlGen As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlMrk As System.Web.UI.WebControls.Panel
    Protected WithEvents lblWagonNo As System.Web.UI.WebControls.Label
    Protected WithEvents pnlWard As System.Web.UI.WebControls.Panel
    Protected WithEvents ddlSaleOrders As System.Web.UI.WebControls.DropDownList
    Protected WithEvents pnlInvoice As System.Web.UI.WebControls.Panel
    Protected WithEvents txtSGSTRate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSGSTChargedAmt As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtUGSTRate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtUGSTChargedAmt As System.Web.UI.WebControls.TextBox
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


    Protected Sub dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        rblGroup.Visible = False
        If IsPostBack = False Then
            Session("Group") = "PCOPCO"
            txtInvoiceDate.Text = Now.Date
            rblGroup.ClearSelection()
            Try
                Dim i As Int16
                For i = 0 To rblGroup.Items.Count - 1
                    If rblGroup.Items(i).Text = Session("Group") Then
                        rblGroup.Items(i).Selected = True
                        Exit For
                    End If
                Next
                UnitCodes()
                SetGroup()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            If lblMessage.Text.StartsWith("Object") Then lblMessage.Text = "No Details available !"
        End If
    End Sub

    Private Sub SetGroup()
        Clear()
        lblWagonNo.Text = ""
        pnlMrk.Visible = False
        pnlPCO.Visible = False
        pnlWard.Visible = False
        pnlInvoice.Visible = False
        If rblGroup.SelectedItem.Text.Trim = "MRKTING" Then
            pnlMrk.Visible = True
            pnlInvoice.Visible = True
            SavedReferenceIds()
            SavedDespatchInvoiceNos()
            InvoiceDetails()
        ElseIf rblGroup.SelectedItem.Text = "PCOPCO" OrElse rblGroup.SelectedItem.Text = "C&F" Then
            pnlInvoice.Visible = True
            txtGoodsHSN.Text = "8607"
            pnlPCO.Visible = True
            SavedDespatchAdvices()
            SavedDespatchInvoiceNos()
            InvoiceDetails()
            If rblGroup.SelectedItem.Text = "PCOPCO" Then
                If Not Marketing.CheckDCNo(rblGroup.SelectedItem.Text.Trim, ddlDespatchAdviceNo.SelectedItem.Text.Trim, rblInvoice.SelectedItem.Text.Trim) Then lblMessage.Text = "No DC Number Available for the selected Invoice No "
            End If
        ElseIf rblGroup.SelectedItem.Text = "WARD30" Then
            pnlInvoice.Visible = True
            pnlWard.Visible = True
            SavedSaleOrders()
            SavedDespatchInvoiceNos()
            InvoiceDetails()
        End If
        If rblGroup.SelectedItem.Text.Trim = "WARD30" Then
            SavedSaleInvoiceDetails(ddlSaleOrders.SelectedItem.Value)
        ElseIf rblGroup.SelectedItem.Text.Trim = "PCOPCO" OrElse rblGroup.SelectedItem.Text.Trim = "C&F" Then
            SavedSaleInvoiceDetails(ddlDespatchAdviceNo.SelectedItem.Value)
        ElseIf rblGroup.SelectedItem.Text.Trim = "MRKTING" Then
            SavedSaleInvoiceDetails(ddlRefID.SelectedItem.Text)
        End If
    End Sub

    Private Sub SavedSaleInvoiceDetails(ByVal GroupReference As String)
        DataGrid1.SelectedIndex = -1
        DataGrid1.DataSource = Marketing.SavedSaleInvoiceDetails(rblGroup.SelectedItem.Text.Trim, GroupReference.Trim)
        DataGrid1.DataBind()
    End Sub

    Private Sub UnitCodes()
        Try
            Dim dt As DataTable = Marketing.UnitCodes
            ddlUnitCode.DataSource = dt
            ddlUnitCode.DataTextField = dt.Columns(0).ColumnName
            ddlUnitCode.DataValueField = dt.Columns(1).ColumnName
            ddlUnitCode.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub SavedDespatchAdvices()
        Try
            Dim dt As DataTable = Marketing.SavedDespatchAdvices(rblGroup.SelectedItem.Text)
            ddlDespatchAdviceNo.DataSource = dt
            ddlDespatchAdviceNo.DataTextField = dt.Columns(0).ColumnName
            ddlDespatchAdviceNo.DataValueField = dt.Columns(0).ColumnName
            ddlDespatchAdviceNo.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub SavedDespatchInvoiceNos()
        Try
            Dim dt As DataTable
            If rblGroup.SelectedItem.Text = "PCOPCO" OrElse rblGroup.SelectedItem.Text = "C&F" Then
                dt = Marketing.SavedDespatchInvoiceNos(ddlDespatchAdviceNo.SelectedItem.Value, rblGroup.SelectedItem.Text)
            ElseIf rblGroup.SelectedItem.Text = "WARD30" Then
                dt = Marketing.SavedDespatchInvoiceNos(ddlSaleOrders.SelectedItem.Value, rblGroup.SelectedItem.Text)
            ElseIf rblGroup.SelectedItem.Text = "MRKTING" Then
                dt = Marketing.SavedDespatchInvoiceNos(ddlRefID.SelectedItem.Text, rblGroup.SelectedItem.Text)
            End If
            rblInvoice.DataSource = dt
            rblInvoice.DataTextField = dt.Columns(0).ColumnName
            rblInvoice.DataValueField = dt.Columns(0).ColumnName
            rblInvoice.DataBind()
            rblInvoice.SelectedIndex = 0
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub InvoiceDetails()
        Try
            Dim dt As DataTable = Marketing.InvoiceDetails(rblInvoice.SelectedItem.Value, rblGroup.SelectedItem.Text)
            If dt.Rows.Count > 0 Then
                txtInvoiceDate.Text = IIf(IsDBNull(dt.Rows(0)(0)), Now.Date, dt.Rows(0)(0))
                txtQuantity.Text = IIf(IsDBNull(dt.Rows(0)(1)), 0, dt.Rows(0)(1))
                txtRate.Text = IIf(IsDBNull(dt.Rows(0)(2)), 0, dt.Rows(0)(2))
                txtGoodsName.Text = IIf(IsDBNull(dt.Rows(0)(3)), "", dt.Rows(0)(3))
                txtGoodsDescription.Text = IIf(IsDBNull(dt.Rows(0)(5)), "", dt.Rows(0)(5))
                txtTotalValue.Text = Val(txtQuantity.Text) * Val(txtRate.Text)
                txtTaxableValue.Text = Val(txtQuantity.Text) * Val(txtRate.Text)
                lblWagonNo.Text = IIf(IsDBNull(dt.Rows(0)(6)), "", dt.Rows(0)(6))
                txtRecepientGSTIN.Text = IIf(IsDBNull(dt.Rows(0)(7)), "", dt.Rows(0)(7))
                txtGoodsHSN.Text = IIf(IsDBNull(dt.Rows(0)(8)), "", dt.Rows(0)(8))
                txtPlaceOfSupply.Text = IIf(IsDBNull(dt.Rows(0)(9)), "", dt.Rows(0)(9))
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub SavedReferenceIds()
        Try
            Dim dt As DataTable = Marketing.SavedReferenceIDs
            ddlRefID.DataSource = dt
            ddlRefID.DataTextField = dt.Columns(0).ColumnName
            ddlRefID.DataValueField = dt.Columns(1).ColumnName
            ddlRefID.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub SavedSaleOrders()
        Try
            Dim dt As DataTable = Marketing.SavedSaleOrders(rblGroup.SelectedItem.Text)
            ddlSaleOrders.DataSource = dt
            ddlSaleOrders.DataTextField = dt.Columns(0).ColumnName
            ddlSaleOrders.DataValueField = dt.Columns(0).ColumnName
            ddlSaleOrders.DataBind()
            ddlSaleOrders.SelectedIndex = 0
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub SavedSaleInvoices()
        Try
            Dim dt As DataTable = Marketing.SavedSaleInvoices(rblGroup.SelectedItem.Text, ddlSaleOrders.SelectedItem.Value)
            rblInvoice.DataSource = dt
            rblInvoice.DataTextField = dt.Columns(0).ColumnName
            rblInvoice.DataValueField = dt.Columns(0).ColumnName
            rblInvoice.DataBind()
            rblInvoice.SelectedIndex = 0
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub rblGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblGroup.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            SetGroup()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        If rblGroup.SelectedItem.Text = "PCOPCO" Then
            If Not Marketing.CheckDCNo(rblGroup.SelectedItem.Text.Trim, ddlDespatchAdviceNo.SelectedItem.Text.Trim, rblInvoice.SelectedItem.Text.Trim) Then
                lblMessage.Text = "No DC Number Available for the selected Invoice No "
                Exit Sub
            End If
        End If
        Dim done As Boolean
        Try
            If rblGroup.SelectedItem.Text.Trim = "WARD30" Then
                done = New Marketing().SaveSaleInvoiceDetails(rblGroup.SelectedItem.Text.Trim, ddlSaleOrders.SelectedItem.Value, rblInvoice.SelectedItem.Text.Trim, CDate(txtInvoiceDate.Text), Val(txtTotalValue.Text), Val(txtTaxableValue.Text), txtGoodsHSN.Text.Trim, txtGoodsDescription.Text.Trim, ddlUnitCode.SelectedItem.Value, Val(txtQuantity.Text), Val(txtRate.Text), rblITC.SelectedItem.Value, Val(txtIGSTRate.Text), Val(txtIGSTChargedAmt.Text), Val(txtCGSTRate.Text), Val(txtCGSTChargedAmt.Text), Val(txtSGSTRate.Text), Val(txtSGSTChargedAmt.Text), Val(txtCessRate.Text), Val(txtCessChargedAmt.Text), txtGoodsName.Text.Trim, txtPlaceOfSupply.Text.Trim, txtRecepientGSTIN.Text, rblReverseTax.SelectedItem.Value, txtTDS.Text.Trim, Val(txtUGSTRate.Text), Val(txtUGSTChargedAmt.Text))
            ElseIf rblGroup.SelectedItem.Text.Trim = "PCOPCO" OrElse rblGroup.SelectedItem.Text.Trim = "C&F" Then
                done = New Marketing().SaveSaleInvoiceDetails(rblGroup.SelectedItem.Text.Trim, ddlDespatchAdviceNo.SelectedItem.Value, rblInvoice.SelectedItem.Text.Trim, CDate(txtInvoiceDate.Text), Val(txtTotalValue.Text), Val(txtTaxableValue.Text), txtGoodsHSN.Text.Trim, txtGoodsDescription.Text.Trim, ddlUnitCode.SelectedItem.Value, Val(txtQuantity.Text), Val(txtRate.Text), rblITC.SelectedItem.Value, Val(txtIGSTRate.Text), Val(txtIGSTChargedAmt.Text), Val(txtCGSTRate.Text), Val(txtCGSTChargedAmt.Text), Val(txtSGSTRate.Text), Val(txtSGSTChargedAmt.Text), Val(txtCessRate.Text), Val(txtCessChargedAmt.Text), txtGoodsName.Text.Trim, txtPlaceOfSupply.Text.Trim, txtRecepientGSTIN.Text, rblReverseTax.SelectedItem.Value, txtTDS.Text.Trim, Val(txtUGSTRate.Text), Val(txtUGSTChargedAmt.Text))
            ElseIf rblGroup.SelectedItem.Text.Trim = "MRKTING" Then
                done = New Marketing().SaveSaleInvoiceDetails(rblGroup.SelectedItem.Text.Trim, ddlRefID.SelectedItem.Text, rblInvoice.SelectedItem.Text.Trim, CDate(txtInvoiceDate.Text), Val(txtTotalValue.Text), Val(txtTaxableValue.Text), txtGoodsHSN.Text.Trim, txtGoodsDescription.Text.Trim, ddlUnitCode.SelectedItem.Value, Val(txtQuantity.Text), Val(txtRate.Text), rblITC.SelectedItem.Value, Val(txtIGSTRate.Text), Val(txtIGSTChargedAmt.Text), Val(txtCGSTRate.Text), Val(txtCGSTChargedAmt.Text), Val(txtSGSTRate.Text), Val(txtSGSTChargedAmt.Text), Val(txtCessRate.Text), Val(txtCessChargedAmt.Text), txtGoodsName.Text.Trim, txtPlaceOfSupply.Text.Trim, txtRecepientGSTIN.Text, rblReverseTax.SelectedItem.Value, txtTDS.Text.Trim, Val(txtUGSTRate.Text), Val(txtUGSTChargedAmt.Text))
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If done Then
            If rblGroup.SelectedItem.Text.Trim = "WARD30" Then
                SavedSaleInvoiceDetails(ddlSaleOrders.SelectedItem.Value)
            ElseIf rblGroup.SelectedItem.Text.Trim = "PCOPCO" OrElse rblGroup.SelectedItem.Text.Trim = "C&F" Then
                SavedSaleInvoiceDetails(ddlDespatchAdviceNo.SelectedItem.Value)
            ElseIf rblGroup.SelectedItem.Text.Trim = "MRKTING" Then
                SavedSaleInvoiceDetails(ddlRefID.SelectedItem.Text)
            End If
            Clear()
            lblMessage.Text = "Invoice Generated !"
        End If
    End Sub

    Private Sub ddlDespatchAdviceNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlDespatchAdviceNo.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            Clear()
            SavedDespatchInvoiceNos()
            InvoiceDetails()
            If rblGroup.SelectedItem.Text = "PCOPCO" Then
                If Not Marketing.CheckDCNo(rblGroup.SelectedItem.Text.Trim, ddlDespatchAdviceNo.SelectedItem.Text.Trim, rblInvoice.SelectedItem.Text.Trim) Then lblMessage.Text = "No DC Number Available for the selected Invoice No "
            End If
            If rblGroup.SelectedItem.Text.Trim = "WARD30" Then
                SavedSaleInvoiceDetails(ddlSaleOrders.SelectedItem.Value)
            ElseIf rblGroup.SelectedItem.Text.Trim = "PCOPCO" OrElse rblGroup.SelectedItem.Text.Trim = "C&F" Then
                SavedSaleInvoiceDetails(ddlDespatchAdviceNo.SelectedItem.Value)
            ElseIf rblGroup.SelectedItem.Text.Trim = "MRKTING" Then
                SavedSaleInvoiceDetails(ddlRefID.SelectedItem.Text)
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub rblInvoice_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblInvoice.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            Clear()
            InvoiceDetails()
            If rblGroup.SelectedItem.Text = "PCOPCO" Then
                If Not Marketing.CheckDCNo(rblGroup.SelectedItem.Text.Trim, ddlDespatchAdviceNo.SelectedItem.Text.Trim, rblInvoice.SelectedItem.Text.Trim) Then lblMessage.Text = "No DC Number Available for the selected Invoice No "
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtIGSTRate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIGSTRate.TextChanged
        lblMessage.Text = ""
        txtIGSTChargedAmt.Text = Val(txtTaxableValue.Text) * Val(txtIGSTRate.Text)
    End Sub

    Private Sub txtCGSTRate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCGSTRate.TextChanged
        lblMessage.Text = ""
        txtCGSTChargedAmt.Text = Val(txtTaxableValue.Text) * Val(txtCGSTRate.Text)
    End Sub

    Private Sub txtCessRate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCessRate.TextChanged
        lblMessage.Text = ""
        txtCessChargedAmt.Text = Val(txtTaxableValue.Text) * Val(txtCessRate.Text)
    End Sub

    Private Sub ddlSaleOrders_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlSaleOrders.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            Clear()
            SavedDespatchInvoiceNos()
            InvoiceDetails()
            If rblGroup.SelectedItem.Text.Trim = "WARD30" Then
                SavedSaleInvoiceDetails(ddlSaleOrders.SelectedItem.Value)
            ElseIf rblGroup.SelectedItem.Text.Trim = "PCOPCO" OrElse rblGroup.SelectedItem.Text.Trim = "C&F" Then
                SavedSaleInvoiceDetails(ddlDespatchAdviceNo.SelectedItem.Value)
            ElseIf rblGroup.SelectedItem.Text.Trim = "MRKTING" Then
                SavedSaleInvoiceDetails(ddlRefID.SelectedItem.Text)
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub DataGrid1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.ItemCommand
        lblMessage.Text = ""
        Select Case e.CommandName
            Case "Select"
                Try
                    Dim i As Integer = 0
                    Dim dt As DataTable = Marketing.SaleInvoiceDetails(rblGroup.SelectedItem.Text, e.Item.Cells(1).Text.Trim, e.Item.Cells(2).Text.Trim)
                    If dt.Rows.Count > 0 Then
                        If rblGroup.SelectedItem.Text = "PCOPCO" OrElse rblGroup.SelectedItem.Text = "C&F" Then
                            ddlDespatchAdviceNo.ClearSelection()
                            For i = 0 To ddlDespatchAdviceNo.Items.Count - 1
                                If ddlDespatchAdviceNo.Items(i).Value = IIf(IsDBNull(dt.Rows(0)("GroupReference")), 0, dt.Rows(0)("GroupReference")) Then
                                    ddlDespatchAdviceNo.Items(i).Selected = True
                                    Exit For
                                End If
                            Next
                        ElseIf rblGroup.SelectedItem.Text = "WARD30" Then
                            ddlSaleOrders.ClearSelection()
                            For i = 0 To ddlSaleOrders.Items.Count - 1
                                If ddlSaleOrders.Items(i).Value = IIf(IsDBNull(dt.Rows(0)("GroupReference")), 0, dt.Rows(0)("GroupReference")) Then
                                    ddlSaleOrders.Items(i).Selected = True
                                    Exit For
                                End If
                            Next
                        ElseIf rblGroup.SelectedItem.Text = "MRKTING" Then
                            ddlSaleOrders.ClearSelection()
                            For i = 0 To ddlSaleOrders.Items.Count - 1
                                If ddlRefID.Items(i).Text = IIf(IsDBNull(dt.Rows(0)("GroupReference")), 0, dt.Rows(0)("GroupReference")) Then
                                    ddlRefID.Items(i).Selected = True
                                    Exit For
                                End If
                            Next
                        End If
                        Try
                            SavedDespatchInvoiceNos()
                        Catch exp As Exception
                            lblMessage.Text = exp.Message
                        End Try
                        rblInvoice.ClearSelection()
                        For i = 0 To rblInvoice.Items.Count - 1
                            If rblInvoice.Items(i).Value = IIf(IsDBNull(dt.Rows(0)("InvoiceNo")), "", dt.Rows(0)("InvoiceNo")) Then
                                rblInvoice.Items(i).Selected = True
                                Exit For
                            End If
                        Next
                        InvoiceDetails()
                        txtInvoiceDate.Text = IIf(IsDBNull(dt.Rows(0)("InvoiceDate")), Now.Date, dt.Rows(0)("InvoiceDate"))
                        txtQuantity.Text = IIf(IsDBNull(dt.Rows(0)("Quantity")), 0, dt.Rows(0)("Quantity"))
                        txtRate.Text = IIf(IsDBNull(dt.Rows(0)("Rate")), 0, dt.Rows(0)("Rate"))
                        rblITC.ClearSelection()
                        For i = 0 To rblITC.Items.Count - 1
                            If rblITC.Items(i).Value = IIf(IsDBNull(dt.Rows(0)("ITC")), 0, dt.Rows(0)("ITC")) Then
                                rblITC.Items(i).Selected = True
                                Exit For
                            End If
                        Next
                        ddlUnitCode.ClearSelection()
                        i = 0
                        For i = 0 To ddlUnitCode.Items.Count - 1
                            If ddlUnitCode.Items(i).Value = IIf(IsDBNull(dt.Rows(0)("UnitCode")), "", dt.Rows(0)("UnitCode")) Then
                                ddlUnitCode.Items(i).Selected = True
                                Exit For
                            End If
                        Next
                        txtIGSTRate.Text = IIf(IsDBNull(dt.Rows(0)("IGSTRate")), 0, dt.Rows(0)("IGSTRate"))
                        txtIGSTChargedAmt.Text = IIf(IsDBNull(dt.Rows(0)("IGSTChargedAmt")), 0, dt.Rows(0)("IGSTChargedAmt"))
                        txtCGSTRate.Text = IIf(IsDBNull(dt.Rows(0)("CGSTRate")), 0, dt.Rows(0)("CGSTRate"))
                        txtCGSTChargedAmt.Text = IIf(IsDBNull(dt.Rows(0)("CGSTChargedAmt")), 0, dt.Rows(0)("CGSTChargedAmt"))
                        txtSGSTRate.Text = IIf(IsDBNull(dt.Rows(0)("SGSTRate")), 0, dt.Rows(0)("SGSTRate"))
                        txtSGSTChargedAmt.Text = IIf(IsDBNull(dt.Rows(0)("SGSTChargedAmt")), 0, dt.Rows(0)("SGSTChargedAmt"))
                        txtCessRate.Text = IIf(IsDBNull(dt.Rows(0)("CessRate")), 0, dt.Rows(0)("CessRate"))
                        txtCessChargedAmt.Text = IIf(IsDBNull(dt.Rows(0)("CessChargedAmt")), 0, dt.Rows(0)("CessChargedAmt"))
                        txtGoodsName.Text = IIf(IsDBNull(dt.Rows(0)("GoodsName")), 0, dt.Rows(0)("GoodsName"))
                        txtPlaceOfSupply.Text = IIf(IsDBNull(dt.Rows(0)("PlaceOfSupply")), 0, dt.Rows(0)("PlaceOfSupply"))
                        txtGoodsDescription.Text = IIf(IsDBNull(dt.Rows(0)("GoodsDescription")), 0, dt.Rows(0)("GoodsDescription"))
                        txtTotalValue.Text = Val(txtQuantity.Text) * Val(txtRate.Text)
                        txtTaxableValue.Text = Val(txtQuantity.Text) * Val(txtRate.Text)
                        txtRecepientGSTIN.Text = IIf(IsDBNull(dt.Rows(0)("RecepientGSTIN")), 0, dt.Rows(0)("RecepientGSTIN"))
                        i = 0
                        For i = 0 To rblReverseTax.Items.Count - 1
                            If rblReverseTax.Items(i).Value = IIf(IsDBNull(dt.Rows(0)("ReverseTax")), 0, dt.Rows(0)("ReverseTax")) Then
                                rblReverseTax.Items(i).Selected = True
                                Exit For
                            End If
                        Next
                        txtTDS.Text = IIf(IsDBNull(dt.Rows(0)("TDS")), 0, dt.Rows(0)("TDS"))
                        txtUGSTRate.Text = IIf(IsDBNull(dt.Rows(0)("UGSTRate")), 0, dt.Rows(0)("UGSTRate"))
                        txtUGSTChargedAmt.Text = IIf(IsDBNull(dt.Rows(0)("UGSTChargedAmt")), 0, dt.Rows(0)("UGSTChargedAmt"))
                    End If
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                End Try
        End Select
    End Sub

    Private Sub Clear()
        txtInvoiceDate.Text = Now.Date
        txtQuantity.Text = 0
        txtRate.Text = 0
        txtIGSTRate.Text = 0
        txtIGSTChargedAmt.Text = 0
        txtCGSTRate.Text = 0
        txtCGSTChargedAmt.Text = 0
        txtSGSTRate.Text = 0
        txtSGSTChargedAmt.Text = 0
        txtCessRate.Text = 0
        txtCessChargedAmt.Text = 0
        txtGoodsName.Text = ""
        txtPlaceOfSupply.Text = ""
        txtGoodsDescription.Text = ""
        txtTotalValue.Text = 0
        txtTaxableValue.Text = 0
        lblWagonNo.Text = ""
        txtRecepientGSTIN.Text = ""
        txtTDS.Text = ""
        txtUGSTRate.Text = 0
        txtUGSTChargedAmt.Text = 0
    End Sub

    Private Sub txtSGSTRate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSGSTRate.TextChanged
        lblMessage.Text = ""
        txtSGSTChargedAmt.Text = Val(txtTaxableValue.Text) * Val(txtSGSTRate.Text)
    End Sub

    Private Sub txtUGSTRate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUGSTRate.TextChanged
        lblMessage.Text = ""
        txtUGSTChargedAmt.Text = Val(txtTaxableValue.Text) * Val(txtUGSTRate.Text)
    End Sub

    Private Sub ddlRefID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlRefID.SelectedIndexChanged
        lblMessage.Text = ""
        Dim dt As DataTable
        Try
            dt = Marketing.SavedDespatchInvoiceNos(ddlRefID.SelectedItem.Text, rblGroup.SelectedItem.Text)
            rblInvoice.DataSource = dt
            rblInvoice.DataTextField = dt.Columns(0).ColumnName
            rblInvoice.DataValueField = dt.Columns(0).ColumnName
            rblInvoice.DataBind()
            rblInvoice.SelectedIndex = 0
            InvoiceDetails()
            SavedSaleInvoiceDetails(ddlRefID.SelectedItem.Text)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
End Class
