Public Class DeleteGroupTools
    Inherits System.Web.UI.Page
    Protected WithEvents lblMode As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblMaintenance_group As System.Web.UI.WebControls.Label
    Protected WithEvents radType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtInstrument_number As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtHistory_number As System.Web.UI.WebControls.TextBox
    Protected WithEvents pnlTool As System.Web.UI.WebControls.Panel
    Protected WithEvents cboTool As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtMake As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtModel As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtStranded As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboShop_code As System.Web.UI.WebControls.DropDownList
    Protected WithEvents RequiredFieldValidator12 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator14 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents cboHistory_number As System.Web.UI.WebControls.DropDownList
    Protected WithEvents pnlEdit As System.Web.UI.WebControls.Panel
    Protected WithEvents rfvHistory As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents lblShop_code As System.Web.UI.WebControls.Label
    Protected WithEvents txtGroup As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfvGroup As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtRange As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator7 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtUnit_of_measure As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator4 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtCriteria As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator8 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents cboFrequency As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtLink As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator9 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtTolerance As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator5 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtInstruction_number As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator10 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtError_plus As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator6 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtError_minus As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator11 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtcalibration_prodedure As System.Web.UI.WebControls.TextBox
    Protected WithEvents Requiredfieldvalidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtType As System.Web.UI.WebControls.TextBox
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents cboGroup As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents btnClear As System.Web.UI.WebControls.Button
    Protected WithEvents btnExit As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtEntry As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator13 As System.Web.UI.WebControls.RequiredFieldValidator
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
        lblMaintenance_group.Text = Session("Group")
        'lblMaintenance_group.Text = "MC-001"
        'strMode = "add"
        'strMode = "edit"
        'lblMode.Text = "edit"
        lblMode.Text = "delete"
        ' lblMode.Text = Request.QueryString("mode")
        If Not IsPostBack Then
            txtEntry.Text = Now.Date
            FillDDLs()
            If lblMode.Text.Equals("edit") Then
                txtGroup.Enabled = False
                cboShop_code.Visible = False
                lblShop_code.Visible = True

                pnlEdit.Visible = True
                txtHistory_number.Enabled = False
                rfvHistory.Enabled = False
                rfvHistory.Visible = False
                cboGroup.Visible = False
                txtGroup.Visible = True
                rfvGroup.Visible = True
                rfvGroup.Enabled = True
            End If 'End of edit Mode

            If lblMode.Text.Equals("delete") Then
                cboShop_code.Visible = True
                lblShop_code.Visible = True

                pnlEdit.Visible = True
                txtHistory_number.Enabled = False
                rfvHistory.Enabled = False
                rfvHistory.Visible = False
                cboGroup.Visible = False
                txtGroup.Visible = True
                rfvGroup.Visible = True
                rfvGroup.Enabled = True
                radType.Enabled = False
                btnSave.Text = "delete"
            End If 'End of delete Mode

        End If 'End of IsPostBack
    End Sub
    Private Sub FillDDL(ByRef ddl As System.Web.UI.WebControls.DropDownList, ByRef dt As DataTable)
        ddl.DataSource = dt.DefaultView
        ddl.DataTextField = dt.Columns(0).ColumnName
        ddl.DataValueField = dt.Columns(1).ColumnName
        ddl.DataBind()
    End Sub
    Private Sub FillDDLs()
        cboGroup.Items.Clear()
        cboShop_code.Items.Clear()
        cboTool.Items.Clear()
        cboFrequency.Items.Clear()
        cboHistory_number.Items.Clear()
        Dim ds As New DataSet()
        Try
            ds = ToolRoom.Tables.getTables
            FillDDL(cboGroup, ds.Tables(0))
            FillDDL(cboShop_code, ds.Tables(1))
            FillDDL(cboTool, ds.Tables(2))
            FillDDL(cboFrequency, ds.Tables(3))
            If lblMode.Text.Equals("edit") Or lblMode.Text.Equals("delete") Then
                FillDDL(cboHistory_number, ds.Tables(4))
            End If
            cboFrequency.Items.Insert("0", "select")
        Catch exp As Exception
            'Throw New Exception(exp.Message)
        Finally
            ds.Dispose()
        End Try
    End Sub
    Private Sub radType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radType.SelectedIndexChanged
        clear()
        lblMessage.Text = ""
        lblShop_code.Text = ""
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        If lblMode.Text.Equals("add") Then
            If radType.SelectedItem.Value = "G" Then
                pnlTool.Visible = False
                cboGroup.Visible = False
                txtGroup.Visible = True
                rfvGroup.Visible = True
                rfvGroup.Enabled = True
            End If
            If radType.SelectedItem.Value = "T" Then
                pnlTool.Visible = True
                cboGroup.Visible = True
                txtGroup.Visible = False
                rfvGroup.Visible = False
                rfvGroup.Enabled = False
            End If
        End If 'End of add Mode

        If lblMode.Text.Equals("edit") Or lblMode.Text.Equals("delete") Then
            If radType.SelectedItem.Value = "G" Then
                pnlEdit.Visible = False
                pnlTool.Visible = False
                cboGroup.Visible = True
                txtGroup.Visible = False
                rfvGroup.Visible = False
                rfvGroup.Enabled = False
            End If
            If radType.SelectedItem.Value = "T" Then
                pnlEdit.Visible = True
                pnlTool.Visible = True
                cboGroup.Visible = False
                txtGroup.Visible = True
                rfvGroup.Visible = True
                rfvGroup.Enabled = True
            End If
        End If 'End of edit Mode
    End Sub
    Private Sub cboGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboGroup.SelectedIndexChanged
        lblMessage.Text = ""
        Dim ds As New DataSet()
        Try
            ds = ToolRoom.Tables.GetToolsGroupDetails(cboGroup.SelectedItem.Text.Trim)
            If Not IsDBNull(ds.Tables(0).Rows(0)(2)) Then txtRange.Text = Trim(ds.Tables(0).Rows(0)(2))
            If Not IsDBNull(ds.Tables(0).Rows(0)(3)) Then txtUnit_of_measure.Text = Trim(ds.Tables(0).Rows(0)(3))
            If Not IsDBNull(ds.Tables(0).Rows(0)(4)) Then txtCriteria.Text = Trim(ds.Tables(0).Rows(0)(4))
            Dim intCnt As Integer
            If Not IsDBNull(Trim(ds.Tables(0).Rows(0)(5))) Then
                For intCnt = 0 To cboFrequency.Items.Count - 1
                    If cboFrequency.Items(intCnt).Value = Trim(ds.Tables(0).Rows(0)(5)) Then
                        cboFrequency.SelectedIndex = intCnt
                        Exit For
                    End If
                Next
            End If
            If Not IsDBNull(ds.Tables(0).Rows(0)(6)) Then txtLink.Text = Trim(ds.Tables(0).Rows(0)(6))
            If Not IsDBNull(ds.Tables(0).Rows(0)(7)) Then txtTolerance.Text = Trim(ds.Tables(0).Rows(0)(7))
            If Not IsDBNull(ds.Tables(0).Rows(0)(8)) Then txtInstruction_number.Text = Trim(ds.Tables(0).Rows(0)(8))
            If Not IsDBNull(ds.Tables(0).Rows(0)(9)) Then txtError_plus.Text = Trim(ds.Tables(0).Rows(0)(9))
            If Not IsDBNull(ds.Tables(0).Rows(0)(10)) Then txtError_minus.Text = Trim(ds.Tables(0).Rows(0)(10))
            If Not IsDBNull(ds.Tables(0).Rows(0)(11)) Then txtcalibration_prodedure.Text = Trim(ds.Tables(0).Rows(0)(11))
            If Not IsDBNull(ds.Tables(0).Rows(0)(12)) Then txtType.Text = Trim(ds.Tables(0).Rows(0)(12))
            If lblMode.Text.Equals("add") Then
                txtInstrument_number.Text = Trim(cboGroup.SelectedItem.Value) & "-"
            End If
            DataGrid1.DataSource = Nothing
            DataGrid1.DataBind()
            DataGrid1.DataSource = ds.Tables(1)
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            ds.Dispose()
        End Try
    End Sub
    Private Sub cboHistory_number_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboHistory_number.SelectedIndexChanged
        clear()
        lblMessage.Text = ""
        lblShop_code.Text = ""
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Dim dt As New DataTable()
        Try
            dt = ToolRoom.Tables.GetToolsHistoryCardDetails(cboHistory_number.SelectedItem.Text.Trim)

            If Not IsDBNull(dt.Rows(0)(0)) Then txtHistory_number.Text = Trim(dt.Rows(0)(0))
            If Not IsDBNull(dt.Rows(0)(3)) Then txtInstrument_number.Text = Trim(dt.Rows(0)(3))
            If Not IsDBNull(dt.Rows(0)(4)) Then txtMake.Text = Trim(dt.Rows(0)(4))
            If Not IsDBNull(dt.Rows(0)(5)) Then txtModel.Text = Trim(dt.Rows(0)(5))
            If Not IsDBNull(dt.Rows(0)(6)) Then txtStranded.Text = Trim(dt.Rows(0)(6))
            Dim intCnt As Integer
            If Not IsDBNull(dt.Rows(0)(1)) Then lblShop_code.Text = Trim(dt.Rows(0)(1))
            'For intCnt = 0 To cboTool.Items.Count - 1
            '    If cboTool.Items(intCnt).Value = rdrTemp(7) Then
            '        cboTool.SelectedIndex = intCnt
            '        Exit For
            '    End If
            'Next
            If Not IsDBNull(dt.Rows(0)(8)) Then txtGroup.Text = Trim(dt.Rows(0)(8))
            If Not IsDBNull(dt.Rows(0)(9)) Then txtRange.Text = Trim(dt.Rows(0)(9))
            If Not IsDBNull(dt.Rows(0)(10)) Then
                txtUnit_of_measure.Text = "MM"
            Else
                txtUnit_of_measure.Text = Trim(dt.Rows(0)(10))
            End If
            If Not IsDBNull(dt.Rows(0)(11)) Then txtCriteria.Text = Trim(dt.Rows(0)(11))
            For intCnt = 0 To cboFrequency.Items.Count - 1
                If cboFrequency.Items(intCnt).Value.Trim = Trim(dt.Rows(0)(12)) Then
                    cboFrequency.SelectedIndex = intCnt
                    Exit For
                End If
            Next
            If Not IsDBNull(dt.Rows(0)(13)) Then txtLink.Text = Trim(dt.Rows(0)(13))
            If Not IsDBNull(dt.Rows(0)(14)) Then txtTolerance.Text = Trim(dt.Rows(0)(14))
            If Not IsDBNull(dt.Rows(0)(15)) Then txtInstruction_number.Text = Trim(dt.Rows(0)(15))
            If Not IsDBNull(dt.Rows(0)(16)) Then txtError_plus.Text = Trim(dt.Rows(0)(16))
            If Not IsDBNull(dt.Rows(0)(17)) Then txtError_minus.Text = Trim(dt.Rows(0)(17))
            If Not IsDBNull(dt.Rows(0)(19)) Then txtcalibration_prodedure.Text = Trim(dt.Rows(0)(19))
            If Not IsDBNull(dt.Rows(0)(20)) Then txtEntry.Text = Trim(dt.Rows(0)(20))

            dt.Clear()
            Dim ds As DataSet
            ds = ToolRoom.Tables.GetToolsGroupDetails(txtGroup.Text.Trim)

            If Not IsDBNull(ds.Tables(0).Rows(0)(2)) Then txtRange.Text = Trim(ds.Tables(0).Rows(0)(2))
            If Not IsDBNull(ds.Tables(0).Rows(0)(4)) Then txtCriteria.Text = Trim(ds.Tables(0).Rows(0)(4))
            If Not IsDBNull(ds.Tables(0).Rows(0)(6)) Then txtLink.Text = Trim(ds.Tables(0).Rows(0)(6))
            If Not IsDBNull(ds.Tables(0).Rows(0)(8)) Then txtInstruction_number.Text = Trim(ds.Tables(0).Rows(0)(8))
            If Not IsDBNull(ds.Tables(0).Rows(0)(12)) Then txtType.Text = Trim(ds.Tables(0).Rows(0)(12))
            If Not IsDBNull(ds.Tables(0).Rows(0)(3)) Then txtUnit_of_measure.Text = Trim(ds.Tables(0).Rows(0)(3))
            If Not IsDBNull(ds.Tables(0).Rows(0)(7)) Then txtTolerance.Text = Trim(ds.Tables(0).Rows(0)(7))
            If lblMode.Text.Equals("add") Then
                txtInstrument_number.Text = cboGroup.SelectedItem.Value & "-"
            End If
            ds.Dispose()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
        End Try
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        Dim Done As New Boolean()
        If cboFrequency.SelectedIndex = 0 Then
            lblMessage.Text = "You Need To Select The Frequency"
            Exit Sub
        End If
        If Not radType.SelectedItem.Text.StartsWith("G") Then
            If txtHistory_number.Text.Trim.Substring(txtHistory_number.Text.Trim.Length - 6) <> txtInstrument_number.Text.Trim.Substring(txtInstrument_number.Text.Trim.Length - 6) Then
                lblMessage.Text = "History Card Number and Instrument Number Mis-Match !"
                Exit Sub
            End If
        End If
        Try
            Dim oTool As New ToolRoom.Tool(radType.SelectedItem.Value)
            oTool.Range = Trim(txtRange.Text)
            oTool.UnitOfMeasure = Trim(txtUnit_of_measure.Text)
            oTool.AccuracyCriteria = Trim(txtCriteria.Text)
            oTool.CalibrationFrequency = cboFrequency.SelectedItem.Value.Trim
            oTool.CalibrationLink = Trim(txtLink.Text)
            oTool.ProcessTolerance = Trim(txtTolerance.Text)
            oTool.WorkInstructionNumber = Trim(txtInstruction_number.Text)
            oTool.MaintenanceGroup = lblMaintenance_group.Text.Trim
            oTool.CalibrationProdedure = Trim(txtcalibration_prodedure.Text)
            oTool.TypeIns = txtType.Text.Trim
            oTool.HistoryCardNumber = Trim(txtHistory_number.Text)
            oTool.MaintenanceGroup = lblMaintenance_group.Text
            oTool.InstrumentNumber = Trim(txtInstrument_number.Text)
            oTool.Make = Trim(txtMake.Text)
            oTool.Model = Trim(txtModel.Text)
            oTool.Standard = Trim(txtStranded.Text)
            oTool.Introduced_date = CDate(txtEntry.Text)
            If lblMode.Text.Equals("add") Then
                If radType.SelectedItem.Value = "G" Then
                    oTool.GroupName = txtGroup.Text.Trim
                    oTool.Plus_error = Trim(txtError_plus.Text)
                    oTool.Minus_error = Trim(txtError_minus.Text)
                Else
                    oTool.PlusError = Trim(txtError_plus.Text)
                    oTool.MinusError = Trim(txtError_minus.Text)
                    oTool.GroupName = Trim(cboGroup.SelectedItem.Text)
                End If
                oTool.ShopCode = Trim(cboShop_code.SelectedItem.Value)
                If oTool.CheckHistoryCard(txtHistory_number.Text.Trim) Then
                    lblMessage.Text = "Already This History Card Number Is Given"
                    Exit Try
                Else
                    If oTool.SaveTools(radType.SelectedItem.Value, , lblMode.Text) Then
                        lblMessage.Text = "Record Inserted"
                        clear()
                        Done = True
                    End If
                End If
            ElseIf lblMode.Text.Equals("edit") Then
                If radType.SelectedItem.Value = "G" Then
                    oTool.GroupName = Trim(cboGroup.SelectedItem.Text)
                Else
                    oTool.GroupName = txtGroup.Text.Trim
                End If
                oTool.ShopCode = Trim(lblShop_code.Text)
                If oTool.SaveTools(radType.SelectedItem.Value, oTool.HistoryCardNumber, lblMode.Text) Then
                    lblMessage.Text = "Record UpDated"
                    clear()
                    Done = True
                End If
            ElseIf lblMode.Text.Equals("delete") Then
                If radType.SelectedItem.Value = "T" Then
                    If oTool.SaveTools(radType.SelectedItem.Value, oTool.HistoryCardNumber, lblMode.Text) Then
                        lblMessage.Text = "Record Deleted"
                        clear()
                        Done = True
                    End If
                End If
            End If
            If Done Then
                FillDDLs()
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try

    End Sub
    Private Sub clear()
        txtType.Text = ""
        txtGroup.Text = ""
        txtRange.Text = ""
        txtUnit_of_measure.Text = ""
        txtCriteria.Text = ""
        cboFrequency.SelectedIndex = 0
        txtLink.Text = ""
        txtTolerance.Text = ""
        txtInstruction_number.Text = ""
        txtError_plus.Text = ""
        txtError_minus.Text = ""
        txtcalibration_prodedure.Text = ""
        txtHistory_number.Text = ""
        txtInstrument_number.Text = ""
        txtMake.Text = ""
        txtModel.Text = ""
        txtStranded.Text = ""
        cboShop_code.SelectedIndex = 0
        cboTool.SelectedIndex = 0
        cboGroup.SelectedIndex = 0
    End Sub
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        clear()
        lblMessage.Text = ""
        lblShop_code.Text = ""
    End Sub
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Server.Transfer("/mss/selectModule.aspx")
    End Sub
End Class
