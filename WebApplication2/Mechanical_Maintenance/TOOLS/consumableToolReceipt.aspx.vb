Public Class measurableToolReceipt
    Inherits System.Web.UI.Page
    Protected WithEvents lblMode As System.Web.UI.WebControls.Label
    Protected WithEvents cboShop_code As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtRecived As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtError_plus As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtError_minus As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtAccuracy_received As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RangeValidator1 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents RequiredFieldValidator3 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator4 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator5 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents cboInstrument_number As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnExit As System.Web.UI.WebControls.Button
    Protected WithEvents btnClear As System.Web.UI.WebControls.Button
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents lblMaintenance_group As System.Web.UI.WebControls.Label
    Protected WithEvents lblReceipt_code As System.Web.UI.WebControls.Label
    Protected WithEvents cboReceipt_code As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtRecipt_date As System.Web.UI.WebControls.TextBox
    Protected WithEvents Requiredfieldvalidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Rangevalidator3 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents Rangevalidator4 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents Rangevalidator5 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents txtInstrument_Number As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblShop_code As System.Web.UI.WebControls.Label
    Protected WithEvents lblreceipt As System.Web.UI.WebControls.Label
    Protected WithEvents txtDiscripency As System.Web.UI.WebControls.TextBox
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Requiredfieldvalidator7 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
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
        Session("Group") = "TOOLS"
        lblMaintenance_group.Text = Session("Group")
        'lblMode.Text = "add"
        'lblMode.Text = "edit"
        'lblMode.Text = "delete"
        lblMode.Text = Request.QueryString("mode")
        If Not IsPostBack Then
            If lblMode.Text.Equals("add") Then
                txtRecipt_date.Text = Date.Today
            End If
            Try
                getShop_codes()
                GetInstrumentNumber()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub



    Private Sub FillDDL(ByRef ddl As System.Web.UI.WebControls.DropDownList, ByRef dt As DataTable)
        ddl.DataSource = dt.DefaultView
        ddl.DataTextField = dt.Columns(0).ColumnName
        ddl.DataValueField = dt.Columns(1).ColumnName
        ddl.DataBind()
    End Sub

    Sub getShop_codes()
        cboShop_code.Items.Clear()
        Dim ds As New DataSet()
        Try
            ds = ToolRoom.Tables.getTables
            FillDDL(cboShop_code, ds.Tables(1))
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            ds.Dispose()
        End Try
    End Sub
    Private Sub cboShop_code_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboShop_code.SelectedIndexChanged
        lblMessage.Text = ""
        If cboShop_code.SelectedItem.Text.ToUpper <> "SELECT" Then
            lblShop_code.Text = cboShop_code.SelectedItem.Value & " : " & cboShop_code.SelectedItem.Text
            Try
                GetInstrumentNumber()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
    Private Sub GetInstrumentNumber()
        cboInstrument_number.Items.Clear()
        Dim dt As New DataTable()
        Try
            dt = ToolRoom.Tables.GetReceiptInstrumentNumber(lblMode.Text.Trim, cboShop_code.SelectedItem.Value)
            FillDDL(cboInstrument_number, dt)
            cboInstrument_number.Items.Insert("0", "Select")
            cboInstrument_number.SelectedIndex = 0
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
        End Try
    End Sub
    Private Sub GetInstrumentsList()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            DataGrid1.DataSource = ToolRoom.Tables.GetToolsReceipt(CDate(txtRecipt_date.Text))
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
    End Sub
    Private Sub GetData()
        If cboInstrument_number.SelectedIndex = 0 Then
            txtRecipt_date.Text = ""
            txtRecived.Text = ""
            txtError_plus.Text = ""
            txtError_minus.Text = ""
            txtAccuracy_received.Text = ""
            txtRemarks.Text = ""
        End If
        Dim dt As New DataTable()
        Try
            dt = ToolRoom.Tables.GetToolsReceiptDetails(lblreceipt.Text.Trim)
            If Not IsDBNull(dt.Rows(0)(0)) Then txtRecipt_date.Text = dt.Rows(0)(0)
            If Not IsDBNull(dt.Rows(0)(1)) Then txtRecived.Text = dt.Rows(0)(1)
            If Not IsDBNull(dt.Rows(0)(2)) Then txtError_plus.Text = dt.Rows(0)(2)
            If Not IsDBNull(dt.Rows(0)(3)) Then txtError_minus.Text = dt.Rows(0)(3)
            If Not IsDBNull(dt.Rows(0)(4)) Then txtAccuracy_received.Text = dt.Rows(0)(4)
            If Not IsDBNull(dt.Rows(0)(7)) Then txtRemarks.Text = dt.Rows(0)(7)
            If Not IsDBNull(dt.Rows(0)(8)) Then txtDiscripency.Text = dt.Rows(0)(8)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub cboInstrument_number_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboInstrument_number.SelectedIndexChanged
        lblMessage.Text = ""
        txtInstrument_Number.Text = ""
        lblreceipt.Text = ""
        If cboInstrument_number.SelectedItem.Text.ToUpper <> "SELECT" Then
            txtInstrument_Number.Text = cboInstrument_number.SelectedItem.Text
            lblreceipt.Text = cboInstrument_number.SelectedItem.Value
        End If
        If lblMode.Text.Equals("edit") Or lblMode.Text.Equals("delete") Then
            GetData()
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim user_id As String = Session("UserID")
        lblMessage.Text = ""
        Dim ds As New DataSet()
        Dim rdt, cdt, idt As Date
        Try
            lblMessage.Text = ""
            ds = ToolRoom.Tables.GetInstrumentNumberDetails(txtInstrument_Number.Text.Trim)
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
            oToolReci.MaintenanceGroup = lblMaintenance_group.Text.Trim
            oToolReci.ShopCode = cboShop_code.SelectedItem.Value.Trim
            oToolReci.InstrumentNumber = txtInstrument_Number.Text.Trim
            oToolReci.ReceiptDate = txtRecipt_date.Text
            oToolReci.ReceivedBy = txtRecived.Text.Trim
            oToolReci.PlusError = txtError_plus.Text.Trim
            oToolReci.MinusError = txtError_minus.Text.Trim
            oToolReci.AccuracyReceived = txtAccuracy_received.Text.Trim
            oToolReci.UserID = user_id.ToUpper
            oToolReci.ChangeDate = Now.Date
            oToolReci.Remarks = txtRemarks.Text.Trim
            oToolReci.Discripency = txtDiscripency.Text.Trim
            If lblMode.Text.Equals("add") Then
                If oToolReci.SaveToolsReceipt Then
                    lblMessage.Text = "Record Inserted"
                    clear()
                    cboInstrument_number.Items.Clear()
                End If
            ElseIf lblMode.Text.Equals("edit") Then
                oToolReci.ReceiptCode = cboInstrument_number.SelectedItem.Value
                If oToolReci.SaveToolsReceipt(cboInstrument_number.SelectedItem.Text) Then
                    lblMessage.Text = "Record UpDated"
                    clear()
                    cboInstrument_number.Items.Clear()
                End If
            ElseIf lblMode.Text.Equals("delete") Then
                oToolReci.ReceiptCode = cboInstrument_number.SelectedItem.Value
                If oToolReci.SaveToolsReceipt(cboInstrument_number.SelectedItem.Text, True) Then
                    lblMessage.Text = "Record Deleted"
                    clear()
                    cboInstrument_number.Items.Clear()
                End If
            End If
            GetInstrumentsList()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            ds.Dispose()
        End Try
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        clear()
    End Sub

    Sub clear()
        cboShop_code.SelectedIndex = 0
        lblShop_code.Text = ""
        txtInstrument_Number.Text = ""
        lblreceipt.Text = ""
        cboInstrument_number.SelectedIndex = 0
        If lblMode.Text.Equals("add") Then
            txtRecipt_date.Text = Date.Today
        Else
            txtRecipt_date.Text = ""
        End If
        txtError_minus.Text = ""
        txtError_plus.Text = ""
        txtRecived.Text = ""
        txtRemarks.Text = ""
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Server.Transfer("/mss/selectModule.aspx")
    End Sub

    Private Sub InitializeComponent()

    End Sub

    Private Sub txtRecipt_date_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRecipt_date.TextChanged
        lblMessage.Text = ""
        Dim ds As New DataSet()
        Try
            lblMessage.Text = ""
            Dim rdt, cdt, idt As Date
            ds = ToolRoom.Tables.GetInstrumentNumberDetails(txtInstrument_Number.Text.Trim)
            rdt = IIf(IsDBNull(ds.Tables(0).Rows(0)(0)), "1900-01-01", ds.Tables(0).Rows(0)(0))
            idt = IIf(IsDBNull(ds.Tables(1).Rows(0)(0)), "1900-01-01", ds.Tables(1).Rows(0)(0))
            cdt = IIf(IsDBNull(ds.Tables(2).Rows(0)(0)), "1900-01-01", ds.Tables(2).Rows(0)(0))

            If lblMode.Text.Equals("add") Then
                If idt.Date <> "1/1/1900" Then
                    If CDate(txtRecipt_date.Text) < rdt Then
                        lblMessage.Text = "Receipt Date should be greater than last receipt date : " & rdt.Date
                        txtRecipt_date.Text = ""
                        Exit Sub
                    End If
                End If
            End If

            If lblMode.Text.Equals("edit") Then
                rdt = IIf(IsDBNull(ds.Tables(5).Rows(0)(0)), "1900-01-01", ds.Tables(5).Rows(0)(0))
                If rdt <> "1/1/1900" Then
                    If CDate(txtRecipt_date.Text) < rdt Then
                        lblMessage.Text = "Receipt Date should be greater than last receipt date : " & rdt.Date
                        txtRecipt_date.Text = ""
                        Exit Sub
                    End If
                End If
            End If

            If cdt.Date <> "1/1/1900" Then
                If CDate(txtRecipt_date.Text) < cdt Then
                    lblMessage.Text = "Receipt Date should be greater than last calibration date : " & cdt.Date
                    txtRecipt_date.Text = ""
                    Exit Sub
                End If
            End If


            If idt.Date <> "1/1/1900" Then
                If CDate(txtRecipt_date.Text) <= idt Then
                    lblMessage.Text = "Receipt Date should be greater than last issue date : " & idt.Date
                    txtRecipt_date.Text = ""
                    Exit Sub
                End If
            End If
            GetInstrumentsList()
        Catch exp As Exception
            lblMessage.Text = exp.Message
            txtRecipt_date.Text = ""
            If CStr(exp.Message).StartsWith("Cast from string") Then
                lblMessage.Text = "Invalid date format"
            End If
        Finally
            ds.Dispose()
        End Try
    End Sub

    Private Sub txtInstrument_Number_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInstrument_Number.TextChanged
        lblMessage.Text = ""
        Dim ds As New DataSet()
        Try
            If txtInstrument_Number.Text = "" Then
                lblShop_code.Text = ""
                Exit Sub
            End If
            If ToolRoom.Tool.CheckHistoryCard(txtInstrument_Number.Text.Trim) = False Then
                lblMessage.Text = "Invalid instrument number"
                txtInstrument_Number.Text = ""
                lblShop_code.Text = ""
                cboInstrument_number.SelectedIndex = 0
                Exit Sub
            End If
            Dim rdt, idt, cdt As Date
            ds = ToolRoom.Tables.GetInstrumentNumberDetails(txtInstrument_Number.Text.Trim)
            rdt = IIf(IsDBNull(ds.Tables(0).Rows(0)(0)), "1900-01-01", ds.Tables(0).Rows(0)(0))
            idt = IIf(IsDBNull(ds.Tables(1).Rows(0)(0)), "1900-01-01", ds.Tables(1).Rows(0)(0))
            cdt = IIf(IsDBNull(ds.Tables(2).Rows(0)(0)), "1900-01-01", ds.Tables(2).Rows(0)(0))
            If lblMode.Text.Equals("add") Then
                If rdt.Date = "1/1/1900" Then
                    lblMessage.Text = "Receiving Instrument for the first time"
                Else
                    If rdt.Date > idt.Date Then
                        lblMessage.Text = "Instrument is already received"
                        lblMessage.Text &= " : Last Receipt DT : " & rdt.Date & ", Last Calibration DT : " & cdt & ", Last Issued DT : " & idt.Date
                        txtInstrument_Number.Text = ""
                        lblShop_code.Text = ""
                        Exit Sub
                    End If
                End If
            End If
            If lblMode.Text.Equals("edit") Then
                If cdt.Date >= rdt.Date Then
                    lblMessage.Text = "Instrument is already calibrated : " & cdt.Date
                    txtInstrument_Number.Text = ""
                    lblShop_code.Text = ""
                    Exit Sub
                End If
            End If
            lblMessage.Text &= "; Last Receipt DT : " & rdt.Date & ", Last Calibration DT : " & cdt & ", Last Issued DT : " & idt.Date
            lblShop_code.Text = IIf(IsDBNull(ds.Tables(3).Rows(0)(0)), "", ds.Tables(3).Rows(0)(0))
            If lblMode.Text.Equals("edit") Then
                If rdt.Date = "1/1/1900" Then
                    lblMessage.Text &= "; Instrument never received"
                    Exit Sub
                Else
                    lblreceipt.Text = IIf(IsDBNull(ds.Tables(4).Rows(0)(0)), "", ds.Tables(4).Rows(0)(0))
                    GetData()
                End If
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            ds.Dispose()
        End Try
    End Sub
End Class
