Public Class toolCalibration
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblMaintenance_group As System.Web.UI.WebControls.Label
    Protected WithEvents cboTool As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtAccuracy As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPerson As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtVerified As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator3 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator4 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator5 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RangeValidator1 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents btnClear As System.Web.UI.WebControls.Button
    Protected WithEvents BtnExit As System.Web.UI.WebControls.Button
    Protected WithEvents RequiredFieldValidator6 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtTemp As System.Web.UI.WebControls.TextBox
    Protected WithEvents Requiredfieldvalidator7 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtError_plus As System.Web.UI.WebControls.TextBox
    Protected WithEvents Requiredfieldvalidator8 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtError_minus As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtstandrad_reading As System.Web.UI.WebControls.TextBox
    Protected WithEvents Requiredfieldvalidator9 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtInstrument_Number As System.Web.UI.WebControls.TextBox
    Protected WithEvents Requiredfieldvalidator10 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents cboShop_code As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblShop_code As System.Web.UI.WebControls.Label
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents lblMode As System.Web.UI.WebControls.Label
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblCalibration_code As System.Web.UI.WebControls.Label
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
        'lblMode.Text = Request.QueryString("mode")
        ' Session("Group") = "TOOLS"
        lblMaintenance_group.Text = Session("Group")
        lblMode.Text = "add"
        '  lblMode.Text = "edit"
        'lblMode.Text = "delete"
        lblCalibration_code.Visible = False
        If Not IsPostBack Then
            Try
                If lblMode.Text.Equals("add") Then
                    getShop_codes()
                End If 'End of add Mode
                If lblMode.Text.Equals("edit") Or lblMode.Text.Equals("delete") Then
                    getShop_codes()
                End If 'End of edit Mode
                getTools()
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
    Private Sub getShop_codes()
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
    Private Sub getTools()
        cboTool.Items.Clear()
        Dim dt As New DataTable()
        Try
            dt = ToolRoom.Tables.GetCalibrationInstrumentNumber(lblMode.Text.Trim, cboShop_code.SelectedItem.Value)
            If dt.Rows.Count > 0 Then
                FillDDL(cboTool, dt)
                cboTool.Items.Insert("0", "Select")
                cboTool.SelectedIndex = 0
            Else
                lblMessage.Text = "No Instruments for this Shop Code !"
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
        End Try
    End Sub
    Private Sub cboShop_code_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboShop_code.SelectedIndexChanged
        lblMessage.Text = ""
        If cboShop_code.SelectedItem.Text.ToUpper <> "SELECT" Then
            lblShop_code.Text = cboShop_code.SelectedItem.Value + " : " + cboShop_code.SelectedItem.Text
        End If
        Try
            getTools()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        Dim rdt, cdt, idt As Date
        Dim ds As New DataSet()
        Dim oToolCali As New ToolRoom.Tool("T")
        Try
            ds = ToolRoom.Tables.GetInstrumentNumberDetails(txtInstrument_Number.Text.Trim, cboShop_code.SelectedItem.Value)
            rdt = IIf(IsDBNull(ds.Tables(0).Rows(0)(0)), "1900-01-01", ds.Tables(0).Rows(0)(0))
            idt = IIf(IsDBNull(ds.Tables(1).Rows(0)(0)), "1900-01-01", ds.Tables(1).Rows(0)(0))
            cdt = IIf(IsDBNull(ds.Tables(2).Rows(0)(0)), "1900-01-01", ds.Tables(2).Rows(0)(0))
            If Not lblMode.Text.ToLower.Equals("delete") Then
                If Format(cdt, "MM/dd/yyyy") = Format(CDate(txtDate.Text.Trim), "MM/dd/yyyy") Then
                    lblMessage.Text = "already calibrated for given date"
                    Exit Sub
                End If
            End If
            oToolCali.MaintenanceGroup = lblMaintenance_group.Text.Trim
            oToolCali.ShopCode = cboShop_code.SelectedItem.Value.Trim
            oToolCali.InstrumentNumber = txtInstrument_Number.Text.Trim
            oToolCali.CalibrationDate = CDate(txtDate.Text)
            oToolCali.AccuracyCalibrated = txtAccuracy.Text.Trim
            oToolCali.CalibratingPerson = txtPerson.Text.Trim
            oToolCali.VerifiedBy = txtVerified.Text.Trim
            oToolCali.Remarks = txtRemarks.Text.Trim
            oToolCali.AmbientTemp = txtTemp.Text.Trim
            oToolCali.PlusError = txtError_plus.Text.Trim
            oToolCali.MinusError = txtError_minus.Text.Trim
            oToolCali.StandradReading = txtstandrad_reading.Text.Trim
            oToolCali.ReceiptCode = IIf(IsDBNull(ds.Tables(4).Rows(0)(0)), "0", ds.Tables(4).Rows(0)(0))
            If lblMode.Text.Equals("add") Then
                If oToolCali.SaveToolsCalibration Then
                    lblMessage.Text = "Record Inserted"
                End If
            ElseIf lblMode.Text.Equals("edit") Then
                oToolCali.CalibrationCode = IIf(IsDBNull(ds.Tables(6).Rows(0)(0)), "0", ds.Tables(6).Rows(0)(0))
                If oToolCali.SaveToolsCalibration(oToolCali.InstrumentNumber) Then
                    lblMessage.Text = "Record UpDated"
                End If
            ElseIf lblMode.Text.ToLower.Equals("delete") Then
                oToolCali.CalibrationCode = IIf(IsDBNull(ds.Tables(6).Rows(0)(0)), "0", ds.Tables(6).Rows(0)(0))
                If oToolCali.SaveToolsCalibration(oToolCali.InstrumentNumber, True) Then
                    lblMessage.Text = "Record deleted"
                End If
            End If
            GetToolsCalibrated()
            clear()
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        Finally
            ds.Dispose()
        End Try
    End Sub

    Private Sub GetData()
        lblMessage.Text = ""
        Dim dt As New DataTable()
        Try
            If lblMode.Text.Equals("edit") Or lblMode.Text.Equals("delete") Then
                dt = ToolRoom.Tables.GetToolsCalibrationDetails(lblCalibration_code.Text)
                If Not IsDBNull(dt.Rows(0)(0)) Then txtDate.Text = dt.Rows(0)(0)
                If Not IsDBNull(dt.Rows(0)(1)) Then txtAccuracy.Text = dt.Rows(0)(1)
                If Not IsDBNull(dt.Rows(0)(2)) Then txtPerson.Text = dt.Rows(0)(2)
                If Not IsDBNull(dt.Rows(0)(3)) Then txtVerified.Text = dt.Rows(0)(3)
                If Not IsDBNull(dt.Rows(0)(4)) Then txtRemarks.Text = dt.Rows(0)(4)
                If Not IsDBNull(dt.Rows(0)(5)) Then txtTemp.Text = dt.Rows(0)(5)
                If Not IsDBNull(dt.Rows(0)(6)) Then txtError_plus.Text = dt.Rows(0)(6)
                If Not IsDBNull(dt.Rows(0)(7)) Then txtError_minus.Text = dt.Rows(0)(7)
                If Not IsDBNull(dt.Rows(0)(8)) Then txtstandrad_reading.Text = dt.Rows(0)(8)
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
        End Try
    End Sub

    Private Sub cboTool_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTool.SelectedIndexChanged
        lblCalibration_code.Text = ""
        If cboTool.SelectedItem.Text.ToUpper <> "SELECT" Then
            txtInstrument_Number.Text = cboTool.SelectedItem.Text
            lblCalibration_code.Text = cboTool.SelectedItem.Value
        End If
        Try
            GetData()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        clear()
    End Sub

    Sub clear()
        cboShop_code.SelectedIndex = 0
        cboTool.SelectedIndex = 0
        txtAccuracy.Text = ""
        txtDate.Text = ""
        txtPerson.Text = ""
        txtRemarks.Text = ""
        txtVerified.Text = ""
        txtTemp.Text = ""
        txtError_minus.Text = ""
        txtError_plus.Text = ""
        txtstandrad_reading.Text = ""
        txtInstrument_Number.Text = ""
        lblShop_code.Text = ""
    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Server.Transfer("/mss/selectModule.aspx")
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
                cboTool.SelectedIndex = 0
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
                        If cdt.Date > rdt.Date Then
                            lblMessage.Text = "Instrument already calibrated"
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
                If idt.Date < rdt.Date And cdt.Date < rdt.Date Then
                    lblMessage.Text = "This instrument is not calibrated after receiving "
                    lblMessage.Text &= "Last Receipt DT : " & rdt.Date & ", Last Calibration DT : " & cdt & ", Last Issued DT : " & idt.Date
                    txtInstrument_Number.Text = ""
                    lblShop_code.Text = ""
                    Exit Sub
                End If
                If rdt.Date = "1/1/1900" Then
                    lblMessage.Text = "Instrument never received"
                    txtInstrument_Number.Text = ""
                    lblShop_code.Text = ""
                    Exit Sub
                Else
                    GetData()
                End If
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub GetToolsCalibrated()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            DataGrid1.DataSource = ToolRoom.Tables.GetToolsCalibrated(CDate(txtDate.Text))
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
    End Sub

    Private Sub txtDate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        lblMessage.Text = ""
        Dim ds As New DataSet()
        Try
            Dim rdt, cdt, idt As Date
            ds = ToolRoom.Tables.GetInstrumentNumberDetails(txtInstrument_Number.Text.Trim)
            rdt = IIf(IsDBNull(ds.Tables(0).Rows(0)(0)), "1900-01-01", ds.Tables(0).Rows(0)(0))
            idt = IIf(IsDBNull(ds.Tables(1).Rows(0)(0)), "1900-01-01", ds.Tables(1).Rows(0)(0))
            cdt = IIf(IsDBNull(ds.Tables(2).Rows(0)(0)), "1900-01-01", ds.Tables(2).Rows(0)(0))
            If lblMode.Text.Equals("add") Then
                If CDate(txtDate.Text) < rdt.Date Then
                    lblMessage.Text = "Calibration Date cannot be smaller then received date : " & rdt.Date
                    txtDate.Text = ""
                    Exit Sub
                End If
                If CDate(txtDate.Text) < idt.Date Then
                    lblMessage.Text = "Insrtument is already issued On : " & idt.Date
                    txtDate.Text = ""
                End If
            End If

            If lblMode.Text.Equals("edit") Then
                If rdt.Date < idt.Date Then
                    If CDate(txtDate.Text) > idt.Date Then
                        lblMessage.Text = "Calibration date cannot be greater than last issue date : " & idt.Date
                        txtDate.Text = ""
                        Exit Sub
                    End If
                Else
                    If CDate(txtDate.Text) < idt.Date Then
                        lblMessage.Text = "Calibration date cannot be smaller than last issue date : " & idt.Date
                        txtDate.Text = ""
                        Exit Sub
                    End If
                End If

                If CDate(txtDate.Text) < rdt.Date Then
                    lblMessage.Text = "Calibration date cannot be smaller than last received date : " & rdt.Date
                    txtDate.Text = ""
                    Exit Sub
                End If
            End If
            GetToolsCalibrated()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            ds.Dispose()
        End Try
    End Sub
End Class
