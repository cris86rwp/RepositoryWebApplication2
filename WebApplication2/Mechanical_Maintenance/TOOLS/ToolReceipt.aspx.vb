Public Class ToolReceipt
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents rblShop As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents ddlInstruments As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnExit As System.Web.UI.WebControls.Button
    Protected WithEvents btnClear As System.Web.UI.WebControls.Button
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDiscripency As System.Web.UI.WebControls.TextBox
    Protected WithEvents Requiredfieldvalidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Rangevalidator3 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents txtAccuracy_received As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator5 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Rangevalidator4 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents txtError_minus As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator4 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Rangevalidator5 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents txtError_plus As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator3 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtRecived As System.Web.UI.WebControls.TextBox
    Protected WithEvents RangeValidator1 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents RequiredFieldValidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtRecipt_date As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblreceipt As System.Web.UI.WebControls.Label
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents pnlEdit As System.Web.UI.WebControls.Panel
    Protected WithEvents txtInstrumentNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtShop As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblInstrumentType As System.Web.UI.WebControls.Label
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
        If IsPostBack = False Then
            pnlEdit.Visible = False
            Try
                txtRecipt_date.Text = Now.Date
                GetShops()
                GetInstrumentsList()
                GetInstrumentsDetails()
                CheckDate()
                DataGrid2.CurrentPageIndex = 0
                DataGrid2.SelectedIndex = -1
                GetInstrumentsReceived()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub GetShops()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Dim dt As DataTable
        dt = ToolRoom.Tables.ToolsListing("")
        rblShop.DataSource = dt
        rblShop.DataTextField = dt.Columns("ShopName").ColumnName
        rblShop.DataValueField = dt.Columns("ShopCode").ColumnName
        rblShop.DataBind()
        rblShop.SelectedIndex = 0
    End Sub

    Private Sub GetInstrumentsList()
        pnlEdit.Visible = False
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        Dim dt As DataTable
        dt = ToolRoom.Tables.ToolsListing("Receipt", rblShop.SelectedItem.Value)

        ddlInstruments.DataSource = dt
        ddlInstruments.DataTextField = dt.Columns("history_card_number").ColumnName
        ddlInstruments.DataValueField = dt.Columns("InstrumentType").ColumnName
        ddlInstruments.DataBind()
        ddlInstruments.SelectedIndex = 0
        lblInstrumentType.Text = ddlInstruments.SelectedItem.Value

    End Sub

    Private Sub GetInstrumentsDetails()
        pnlEdit.Visible = False
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        DataGrid1.DataSource = ToolRoom.Tables.InstrumentsDetails(rblShop.SelectedItem.Value, ddlInstruments.SelectedItem.Text)
        DataGrid1.DataBind()
    End Sub

    Private Sub rblShop_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblShop.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            GetInstrumentsList()
            GetInstrumentsDetails()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub ddlInstruments_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlInstruments.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            lblInstrumentType.Text = ddlInstruments.SelectedItem.Value
            GetInstrumentsDetails()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        clear()
    End Sub

    Sub clear()
        rblShop.SelectedIndex = 0
        lblreceipt.Text = ""
        ddlInstruments.SelectedIndex = 0
        txtRecipt_date.Text = Date.Today
        txtError_minus.Text = ""
        txtError_plus.Text = ""
        txtRecived.Text = ""
        txtRemarks.Text = ""
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Server.Transfer("/mss/selectModule.aspx")
    End Sub

    Private Sub txtRecipt_date_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRecipt_date.TextChanged
        lblMessage.Text = ""
        Try
            txtRecipt_date.Text = CDate(txtRecipt_date.Text)
            CheckDate()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub CheckDate()
        Dim ds As New DataSet()
        Try
            Dim idt As Date
            ds = ToolRoom.Tables.GetInstrumentNumberDetails(ddlInstruments.SelectedItem.Text.Trim)
            idt = IIf(IsDBNull(ds.Tables(1).Rows(0)(0)), "1900-01-01", ds.Tables(1).Rows(0)(0))
            If idt.Date <> "1/1/1900" Then
                If CDate(txtRecipt_date.Text) <= idt Then
                    lblMessage.Text = "Receipt Date should be greater than last issue date : " & idt.Date
                    txtRecipt_date.Text = ""
                    Exit Sub
                End If
            End If
            GetInstrumentsReceived()
        Catch exp As Exception
            lblMessage.Text &= exp.Message
            txtRecipt_date.Text = ""
            If CStr(exp.Message).StartsWith("Cast from string") Then
                lblMessage.Text = "Invalid date format"
            End If
        Finally
            ds.Dispose()
            ds = Nothing
        End Try
    End Sub

    Private Sub GetInstrumentsReceived()
        pnlEdit.Visible = False
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        Dim dt As DataTable
        Try
            dt = ToolRoom.Tables.GetToolsReceipt(CDate(txtRecipt_date.Text))
            If IsNothing(DataGrid2.CurrentPageIndex) Then DataGrid2.CurrentPageIndex = 0
            If dt.Rows.Count > 5 Then
                DataGrid2.AllowPaging = True
                DataGrid2.PageSize = 5
                DataGrid2.PagerStyle.Mode = PagerMode.NumericPages
            End If
            DataGrid2.DataSource = dt
            DataGrid2.DataBind()
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        Finally
            dt = Nothing
        End Try
    End Sub

    Private Sub DataGrid2_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid2.PageIndexChanged
        DataGrid2.SelectedIndex = -1
        DataGrid2.CurrentPageIndex = e.NewPageIndex
        GetInstrumentsReceived()
    End Sub

    Private Sub DataGrid2_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid2.ItemCommand
        lblMessage.Text = ""
        lblreceipt.Text = ""
        pnlEdit.Visible = False
        Select Case e.CommandName
            Case "Select"
                'If e.Item.Cells(10).Text = "&nbsp;" Then
                    pnlEdit.Visible = True
                txtInstrumentNumber.Text = e.Item.Cells(2).Text.Trim
                txtShop.Text = e.Item.Cells(3).Text.Trim.Replace("&nbsp;", "")
                txtRecived.Text = e.Item.Cells(4).Text.Trim.Replace("&nbsp;", "")
                txtError_plus.Text = e.Item.Cells(5).Text.Trim.Replace("&nbsp;", "")
                txtError_minus.Text = e.Item.Cells(6).Text.Trim.Replace("&nbsp;", "")
                txtAccuracy_received.Text = e.Item.Cells(7).Text.Trim.Replace("&nbsp;", "")
                txtDiscripency.Text = e.Item.Cells(8).Text.Trim.Replace("&nbsp;", "")
                txtRemarks.Text = e.Item.Cells(9).Text.Trim.Replace("&nbsp;", "")
                lblreceipt.Text = e.Item.Cells(11).Text
                    'Else
                    '    DataGrid2.SelectedIndex = -1
                    '    lblMessage.Text = "Cannot be Edited because Instrument is already Calibrated !"
                    '    GetInstrumentsReceived()
                    'End If
        End Select
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim user_id As String = Session("UserID")
        lblMessage.Text = ""
        Dim ds As New DataSet()
        Dim rdt, cdt, idt As Date
        Try
            If Val(lblreceipt.Text) = 0 Then
                ds = ToolRoom.Tables.GetInstrumentNumberDetails(ddlInstruments.SelectedItem.Text.Trim)
            Else
                ds = ToolRoom.Tables.GetInstrumentNumberDetails(txtInstrumentNumber.Text.Trim)
            End If
            rdt = IIf(IsDBNull(ds.Tables(0).Rows(0)(0)), "1900-01-01", ds.Tables(0).Rows(0)(0))
            idt = IIf(IsDBNull(ds.Tables(1).Rows(0)(0)), "1900-01-01", ds.Tables(1).Rows(0)(0))
            cdt = IIf(IsDBNull(ds.Tables(2).Rows(0)(0)), "1900-01-01", ds.Tables(2).Rows(0)(0))

            If rdt.Date <> "1/1/1900" Then
                If rdt > CDate(txtRecipt_date.Text) Then
                    lblMessage.Text = "Receipt Date cannot be smaller than last receipt date : " & rdt.Date
                    Exit Sub
                End If
            ElseIf idt.Date <> "1/1/1900" Then
                If idt > CDate(txtRecipt_date.Text) Then
                    lblMessage.Text = "Receipt Date should be greater than last Issue date : " & idt.Date
                    Exit Sub
                End If
            ElseIf cdt.Date <> "1/1/1900" Then
                If cdt > CDate(txtRecipt_date.Text) Then
                    lblMessage.Text = "Receipt Date should be greater than last Calibration date : " & cdt.Date
                    Exit Sub
                End If
            End If

            Dim oToolReci As New ToolRoom.Tool("T")
            oToolReci.MaintenanceGroup = "TOOLS"
            oToolReci.ReceiptDate = txtRecipt_date.Text
            oToolReci.ReceivedBy = txtRecived.Text.Trim
            oToolReci.PlusError = txtError_plus.Text.Trim
            oToolReci.MinusError = txtError_minus.Text.Trim
            oToolReci.AccuracyReceived = txtAccuracy_received.Text.Trim
            oToolReci.UserID = IIf(IsNothing(user_id), "", user_id)
            oToolReci.ChangeDate = Now.Date
            oToolReci.Remarks = txtRemarks.Text.Trim
            oToolReci.Discripency = txtDiscripency.Text.Trim
            If Val(lblreceipt.Text) = 0 Then
                oToolReci.ShopCode = rblShop.SelectedItem.Value.Trim
                oToolReci.InstrumentNumber = ddlInstruments.SelectedItem.Text.Trim
                If oToolReci.SaveToolsReceipt Then
                    lblMessage.Text = "Record Inserted"
                    clear()
                End If
            Else
                oToolReci.ShopCode = txtShop.Text.Trim
                oToolReci.InstrumentNumber = txtInstrumentNumber.Text.Trim
                oToolReci.ReceiptCode = Val(lblreceipt.Text)
                If oToolReci.SaveToolsReceipt(txtInstrumentNumber.Text) Then
                    lblMessage.Text = "Record UpDated"
                    clear()
                End If
            End If
            GetInstrumentsReceived()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            ds.Dispose()
        End Try
    End Sub
End Class
