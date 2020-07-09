Public Class measurableToolIssue
    Inherits System.Web.UI.Page
    Protected WithEvents cboShop_code As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblMode As System.Web.UI.WebControls.Label
    Protected WithEvents lblMaintenance_group As System.Web.UI.WebControls.Label
    Protected WithEvents btnExit As System.Web.UI.WebControls.Button
    Protected WithEvents btnClear As System.Web.UI.WebControls.Button
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents Requiredfieldvalidator3 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtIssued_to As System.Web.UI.WebControls.TextBox
    Protected WithEvents Requiredfieldvalidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtIssued_by As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RangeValidator1 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboInstrument_number As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblShop_code As System.Web.UI.WebControls.Label
    Protected WithEvents txtInstrument_Number As System.Web.UI.WebControls.TextBox
    Protected WithEvents Requiredfieldvalidator10 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblIssue_code As System.Web.UI.WebControls.Label
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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        'Session("USERID") = "078844"
        lblMaintenance_group.Text = "     TOOLS"
        'lblMode.Text = "add"
        'lblMode.Text = "edit"
        'lblMode.Text = "delete"
        lblMode.Text = Request.QueryString("mode")
        lblIssue_code.Visible = False
        If Not IsPostBack Then
            If lblMode.Text.Equals("add") Then
                txtDate.Text = Date.Today
            End If
            Try
                getShop_codes()
                GetInstrument()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
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

    Private Sub GetToolsIssued()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            DataGrid1.DataSource = ToolRoom.Tables.GetToolsIssued(CDate(txtDate.Text))
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
    End Sub

    Private Sub GetInstrument()
        lblMessage.Text = ""
        Dim dt As New DataTable()
        Try
            cboInstrument_number.Items.Clear()
            dt = ToolRoom.Tables.GetIssueInstrumentNumber(lblMode.Text, cboShop_code.SelectedItem.Value.Trim)
            If dt.Rows.Count > 0 Then
                FillDDL(cboInstrument_number, dt)
                cboInstrument_number.Items.Insert("0", "Select")
                cboInstrument_number.SelectedIndex = 0
            Else
                lblMessage.Text = "No Instruments for this Shop Code !"
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub cboShop_code_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboShop_code.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            If cboShop_code.SelectedItem.Text.ToUpper <> "SELECT" Then
                lblShop_code.Text = cboShop_code.SelectedItem.Value + " : " + cboShop_code.SelectedItem.Text
                GetInstrument()
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub GetData()
        lblMessage.Text = ""
        Dim dt As New DataTable()
        Try
            If Val(lblIssue_code.Text) <> 0 Then
                dt = ToolRoom.Tables.GetToolsIssueDetails(lblIssue_code.Text)
                If Not IsDBNull(dt.Rows(0)(0)) Then txtDate.Text = dt.Rows(0)(0)
                If Not IsDBNull(dt.Rows(0)(1)) Then txtIssued_to.Text = dt.Rows(0)(1)
                If Not IsDBNull(dt.Rows(0)(2)) Then txtIssued_by.Text = dt.Rows(0)(2)
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
        End Try
    End Sub

    Private Sub cboInstrument_number_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboInstrument_number.SelectedIndexChanged
        lblMessage.Text = ""
        lblIssue_code.Text = ""
        If cboInstrument_number.SelectedItem.Text.ToUpper <> "SELECT" Then
            txtInstrument_Number.Text = cboInstrument_number.SelectedItem.Text
            lblIssue_code.Text = cboInstrument_number.SelectedItem.Value.Trim
        End If
        Try
            GetData()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        Dim oToolReci As New ToolRoom.Tool("T")
        Dim ds As New DataSet()
        Try
            oToolReci.InstrumentNumber = cboInstrument_number.SelectedItem.Text.Trim
            oToolReci.ShopCode = cboShop_code.SelectedItem.Value.Trim
            ds = ToolRoom.Tables.GetInstrumentNumberDetails(oToolReci.InstrumentNumber, oToolReci.ShopCode)
            oToolReci.ReceiptCode = IIf(IsDBNull(ds.Tables(4).Rows(0)(0)), 0, ds.Tables(4).Rows(0)(0))
            oToolReci.IssuedDate = CDate(txtDate.Text.Trim)
            If IIf(IsDBNull(ds.Tables(2).Rows(0)(0)), CDate("1900-01-01"), ds.Tables(2).Rows(0)(0)) = CDate("1900-01-01") Then
                lblMessage.Text = "Please check for Tools Calibration date !"
                Exit Try
            End If
            oToolReci.MaintenanceGroup = lblMaintenance_group.Text.Trim
            oToolReci.IssuedTo = txtIssued_to.Text.Trim
            oToolReci.IssuedBy = txtIssued_by.Text.Trim
            oToolReci.UserID = CStr(Session("USERID"))
            If lblMode.Text.Equals("add") Then
                If oToolReci.CheckIssue(oToolReci.InstrumentNumber, oToolReci.IssuedDate, oToolReci.ShopCode, oToolReci.MaintenanceGroup) Then
                    lblMessage.Text = "already issued for then given date !"
                    Exit Sub
                Else
                    If oToolReci.SaveToolsIssue() Then
                        clear()
                        lblMessage.Text = "Record Inserted "
                    End If
                End If
            ElseIf lblMode.Text.ToLower.Equals("edit") Then
                lblMessage.Text = IIf(IsDBNull(ds.Tables(7).Rows(0)(0)), 0, ds.Tables(7).Rows(0)(0))
                oToolReci.IssueCode = lblIssue_code.Text.Trim
                If oToolReci.SaveToolsIssue(oToolReci.InstrumentNumber) Then
                    clear()
                    lblMessage.Text = "Record UpDated"
                End If
            ElseIf lblMode.Text.ToLower.Equals("delete") Then
                oToolReci.IssueCode = lblIssue_code.Text.Trim
                If oToolReci.SaveToolsIssue(oToolReci.InstrumentNumber, True) Then
                    clear()
                    lblMessage.Text = "Record Deleted"
                End If
            End If
            GetToolsIssued()
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        Finally
            ds.Dispose()
            oToolReci = Nothing
        End Try
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        clear()
    End Sub

    Sub clear()
        cboShop_code.SelectedIndex = 0
        cboInstrument_number.SelectedIndex = 0
        If lblMode.Text.Equals("edit") Or lblMode.Text.Equals("delete") Then
            txtDate.Text = ""
        Else
            txtDate.Text = Date.Today
        End If
        txtIssued_by.Text = ""
        txtIssued_to.Text = ""
        lblMessage.Text = ""
        txtInstrument_Number.Text = ""
        lblShop_code.Text = ""
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Server.Transfer("/mss/selectModule.aspx")
    End Sub

    Private Sub txtInstrument_Number_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInstrument_Number.TextChanged
        lblMessage.Text = ""
        If txtInstrument_Number.Text = "" Then
            lblShop_code.Text = ""
            Exit Sub
        Else
            Dim ds As New DataSet()
            Try
                If ToolRoom.Tool.CheckHistoryCard(txtInstrument_Number.Text.Trim) = False Then
                    lblMessage.Text = "Invalid instrument number"
                    txtInstrument_Number.Text = ""
                    lblShop_code.Text = ""
                    cboInstrument_number.SelectedIndex = 0
                    Exit Sub
                End If
                Dim rdt, idt, cdt As Date
                ds = ToolRoom.Tables.GetInstrumentNumberDetails(txtInstrument_Number.Text.Trim, cboShop_code.SelectedItem.Value)
                rdt = IIf(IsDBNull(ds.Tables(0).Rows(0)(0)), "1900-01-01", ds.Tables(0).Rows(0)(0))
                idt = IIf(IsDBNull(ds.Tables(1).Rows(0)(0)), "1900-01-01", ds.Tables(1).Rows(0)(0))
                cdt = IIf(IsDBNull(ds.Tables(2).Rows(0)(0)), "1900-01-01", ds.Tables(2).Rows(0)(0))
                If lblMode.Text.Equals("add") Then
                    If rdt.Date = "1/1/1900" Then
                        lblMessage.Text = "Instrument is been never received"
                        txtInstrument_Number.Text = ""
                        lblShop_code.Text = ""
                        Exit Sub
                    Else
                        If idt.Date <> "1/1/1900" Then
                            If rdt.Date < idt.Date Then
                                lblMessage.Text = "Instrument is not yet received"
                                lblMessage.Text &= " : Last Receipt DT : " & rdt.Date & ", Last Calibration DT : " & cdt & ", Last Issued DT : " & idt.Date
                                txtInstrument_Number.Text = ""
                                lblShop_code.Text = ""
                                Exit Sub
                            End If
                        End If

                        If cdt.Date <> "1/1/1900" Then
                            If cdt.Date < rdt.Date Then
                                lblMessage.Text = "Instrument not yet calibrated"
                                lblMessage.Text &= " : Last Receipt DT : " & rdt.Date & ", Last Calibration DT : " & cdt & ", Last Issued DT : " & idt.Date
                                txtInstrument_Number.Text = ""
                                lblShop_code.Text = ""
                                Exit Sub
                            End If

                            If idt.Date > cdt.Date Then
                                lblMessage.Text = "Instrument already issued"
                                lblMessage.Text &= " : Last Receipt DT : " & rdt.Date & ", Last Calibration DT : " & cdt & ", Last Issued DT : " & idt.Date
                                txtInstrument_Number.Text = ""
                                lblShop_code.Text = ""
                                Exit Sub
                            End If
                        End If
                    End If
                End If
                lblMessage.Text = "Last Receipt DT : " & rdt.Date & ", Last Calibration DT : " & cdt & ", Last Issued DT : " & idt.Date
                lblShop_code.Text = IIf(IsDBNull(ds.Tables(3).Rows(0)(0)), "", ds.Tables(3).Rows(0)(0))
                If lblMode.Text.Equals("edit") Then
                    If rdt.Date = "1/1/1900" Then
                        lblMessage.Text = "Instrument never received"
                        txtInstrument_Number.Text = ""
                        lblShop_code.Text = ""
                        Exit Sub
                    End If

                    If cdt.Date > rdt.Date Then
                        If idt.Date < cdt.Date Then
                            lblMessage.Text = "This instrument is not issued after calibrating "
                            lblMessage.Text &= "Last Receipt DT : " & rdt.Date & ", Last Calibration DT : " & cdt & ", Last Issued DT : " & idt.Date
                            txtInstrument_Number.Text = ""
                            lblShop_code.Text = ""
                            Exit Sub
                        End If
                    Else
                        lblMessage.Text = "This instrument is not calibrated "
                        lblMessage.Text &= "Last Receipt DT : " & rdt.Date & ", Last Calibration DT : " & cdt & ", Last Issued DT : " & idt.Date
                        txtInstrument_Number.Text = ""
                        lblShop_code.Text = ""
                        Exit Sub
                    End If
                    GetData()
                End If
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If

    End Sub

    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        lblMessage.Text = ""
        Dim ds As New DataSet()
        Try
            Dim rdt, cdt, idt As Date
            ds = ToolRoom.Tables.GetInstrumentNumberDetails(txtInstrument_Number.Text.Trim)
            rdt = IIf(IsDBNull(ds.Tables(0).Rows(0)(0)), "1900-01-01", ds.Tables(0).Rows(0)(0))
            idt = IIf(IsDBNull(ds.Tables(1).Rows(0)(0)), "1900-01-01", ds.Tables(1).Rows(0)(0))
            cdt = IIf(IsDBNull(ds.Tables(2).Rows(0)(0)), "1900-01-01", ds.Tables(2).Rows(0)(0))
            If lblMode.Text.Equals("edit") Then
                If rdt.Date > cdt.Date Then
                    If CDate(txtDate.Text) > rdt.Date Then
                        lblMessage.Text = "Issue date cannot be greater then last received date : " & rdt.Date
                        txtDate.Text = ""
                        Exit Sub
                    End If
                Else
                    If CDate(txtDate.Text) < cdt.Date Then
                        lblMessage.Text = "Issue date cannot be smaller then calibration date :" & cdt.Date
                        txtDate.Text = ""
                        Exit Sub
                    End If
                End If
            End If

            If lblMode.Text.Equals("add") Then
                If CDate(txtDate.Text) < cdt.Date Then
                    lblMessage.Text = "Issue date cannot be smaller then calibration date :" & cdt.Date
                    txtDate.Text = ""
                    Exit Sub
                End If
            End If
            GetToolsIssued()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            ds.Dispose()
        End Try
    End Sub
End Class
