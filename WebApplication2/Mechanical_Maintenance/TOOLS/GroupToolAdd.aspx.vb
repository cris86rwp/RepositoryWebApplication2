Public Class GroupToolAdd
    Inherits System.Web.UI.Page
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents pnlGroup As System.Web.UI.WebControls.Panel
    Protected WithEvents RequiredFieldValidator11 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtError_minus As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator6 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtError_plus As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator10 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtInstruction_number As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator5 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtTolerance As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator9 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtLink As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator8 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtCriteria As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator4 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtUnit_of_measure As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator7 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtRange As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfvGroup As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtGroup As System.Web.UI.WebControls.TextBox
    Protected WithEvents pnlTool As System.Web.UI.WebControls.Panel
    Protected WithEvents txtEntry As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator12 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtStranded As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator13 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtModel As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfvHistory As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtHistory_number As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator14 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtMake As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtInstrument_number As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlFrequency As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Requiredfieldvalidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtType As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlShop As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlGroup As System.Web.UI.WebControls.DropDownList
    Protected WithEvents dgGroup As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgTools As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnGroup As System.Web.UI.WebControls.Button
    Protected WithEvents btnTool As System.Web.UI.WebControls.Button
    Protected WithEvents txtcalibration_prodedure As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblType As System.Web.UI.WebControls.RadioButtonList
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
            txtEntry.Text = Now.Date
            FillDDLs()
            SetType()
        End If
    End Sub

    Private Sub SetType()
        pnlGroup.Visible = False
        pnlTool.Visible = False
        dgGroup.DataSource = Nothing
        dgGroup.DataBind()
        dgTools.DataSource = Nothing
        dgTools.DataBind()
        If rblType.SelectedIndex = 0 Then
            pnlGroup.Visible = True
        Else
            pnlTool.Visible = True
        End If
        FillGroup()
    End Sub

    Private Sub rblType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblType.SelectedIndexChanged
        lblMessage.Text = ""
        SetType()
    End Sub

    Private Sub FillDDL(ByRef ddl As System.Web.UI.WebControls.DropDownList, ByRef dt As DataTable)
        ddl.DataSource = dt.DefaultView
        ddl.DataTextField = dt.Columns(0).ColumnName
        ddl.DataValueField = dt.Columns(1).ColumnName
        ddl.DataBind()
    End Sub

    Private Sub FillDDLs()
        ddlShop.Items.Clear()
        ddlFrequency.Items.Clear()
        Dim ds As New DataSet()
        Try
            ds = ToolRoom.Tables.getTables
            FillDDL(ddlGroup, ds.Tables(0))
            FillDDL(ddlShop, ds.Tables(1))
            'FillDDL(cboTool, ds.Tables(2))
            FillDDL(ddlFrequency, ds.Tables(3))
            ddlFrequency.Items.Insert("0", "select")
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            ds.Dispose()
        End Try
    End Sub

    Private Sub ddlGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlGroup.SelectedIndexChanged
        lblMessage.Text = ""
        FillGroup()
    End Sub

    Private Sub FillGroup()
        Dim ds As New DataSet()
        Dim Plus, Minus As Decimal
        Try
            ds = ToolRoom.Tables.GetGroupDetails(ddlGroup.SelectedItem.Text)
            dgGroup.DataSource = ds.Tables(0)
            dgGroup.DataBind()
            dgTools.DataSource = ds.Tables(1)
            dgTools.DataBind()
            If pnlTool.Visible Then
                Try
                    Plus = dgGroup.Items(0).Cells(7).Text
                Catch exp As Exception
                    lblMessage.Text = "InValid Plus Error ! Please rectify it before saving."
                End Try
                Try
                    Minus = CDec(ds.Tables(0).Rows(0)(8))
                Catch exp As Exception
                    lblMessage.Text &= " InValid Minus Error ! Please rectify it before saving. "
                End Try
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGroup.Click
        lblMessage.Text = ""
        If ddlFrequency.SelectedIndex = 0 Then
            lblMessage.Text = "You Need To Select The Frequency"
            Exit Sub
        ElseIf Not rblType.SelectedItem.Text.StartsWith("G") Then
            If txtHistory_number.Text.Trim.Substring(txtHistory_number.Text.Trim.Length - 6) <> txtInstrument_number.Text.Trim.Substring(txtInstrument_number.Text.Trim.Length - 6) Then
                lblMessage.Text = "History Card Number and Instrument Number Mis-Match !"
                Exit Sub
            End If
        ElseIf Val(txtError_plus.Text) < 0 Then
            lblMessage.Text = "InValid Plus Error"
            Exit Sub
        ElseIf Val(txtError_minus.Text) < 0 Then
            lblMessage.Text = "InValid Minus Error"
            Exit Sub
        End If
        Dim blnDone As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            cmd.Parameters.Add("@group_name", SqlDbType.VarChar, 50).Value = txtGroup.Text.Trim.ToUpper
            cmd.Parameters.Add("@range", SqlDbType.VarChar, 50).Value = txtRange.Text.Trim
            cmd.Parameters.Add("@unit_of_measure", SqlDbType.VarChar, 50).Value = txtUnit_of_measure.Text.Trim
            cmd.Parameters.Add("@accuracy_criteria", SqlDbType.VarChar, 50).Value = txtCriteria.Text.Trim
            cmd.Parameters.Add("@calibration_frequency", SqlDbType.VarChar, 50).Value = ddlFrequency.SelectedItem.Value.Trim
            cmd.Parameters.Add("@calibration_link", SqlDbType.VarChar, 50).Value = txtLink.Text.Trim
            cmd.Parameters.Add("@process_tolerance", SqlDbType.VarChar, 50).Value = txtTolerance.Text.Trim
            cmd.Parameters.Add("@work_instruction_number", SqlDbType.VarChar, 50).Value = txtInstruction_number.Text.Trim
            cmd.Parameters.Add("@plus_error", SqlDbType.VarChar, 50).Value = txtError_plus.Text.Trim
            cmd.Parameters.Add("@minus_error", SqlDbType.VarChar, 50).Value = txtError_minus.Text.Trim
            cmd.Parameters.Add("@calibration_prodedure", SqlDbType.VarChar, 100).Value = txtcalibration_prodedure.Text.Trim
            cmd.Parameters.Add("@type_ins", SqlDbType.VarChar, 50).Value = txtType.Text.Trim
            cmd.Connection.Open()
            cmd.CommandText = " insert into ms_tools_group ( group_name , range , unit_of_measure , accuracy_criteria , " & _
                                    " calibration_frequency , calibration_link , process_tolerance , work_instruction_number , " & _
                                    " plus_error , minus_error , calibration_prodedure , type_ins ) " & _
                                    " values ( @group_name , @range , @unit_of_measure , @accuracy_criteria , " & _
                                    " @calibration_frequency , @calibration_link , @process_tolerance , @work_instruction_number , " & _
                                    " @plus_error , @minus_error ,  @calibration_prodedure , @type_ins )"
            If cmd.ExecuteNonQuery = 0 Then Throw New Exception(" tools master error")
            lblMessage.Text = "Record Inserted"
            clear()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
        End Try
    End Sub

    Private Sub clear()
        txtType.Text = ""
        txtGroup.Text = ""
        txtRange.Text = ""
        txtUnit_of_measure.Text = ""
        txtCriteria.Text = ""
        ddlFrequency.SelectedIndex = 0
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
        ddlShop.SelectedIndex = 0
        ddlGroup.SelectedIndex = 0
    End Sub

    Private Sub btnTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTool.Click
        lblMessage.Text = ""
        Dim Plus, Minus As Decimal
        If pnlTool.Visible Then
            Try
                Plus = CDec(dgGroup.Items(0).Cells(7).Text)
            Catch exp As Exception
                lblMessage.Text = "InValid Plus Error ! Please rectify it before saving."
            End Try
            Try
                Minus = CDec(dgGroup.Items(0).Cells(8).Text)
            Catch exp As Exception
                lblMessage.Text &= " InValid Minus Error ! Please rectify it before saving. "
            End Try
        End If
        If lblMessage.Text.Trim.Length > 0 Then
            Exit Sub
        Else
            Dim Int As Array
            Int = txtHistory_number.Text.Trim.Split("-")
            If txtHistory_number.Text.Trim.ToLower.StartsWith("mc") Then
                If Int.Length <> 3 Then
                    lblMessage.Text = "InValid Instrument Number !"
                    Exit Sub
                End If
            Else
                If Int.Length <> 4 Then
                    lblMessage.Text = "InValid Instrument Number !"
                    Exit Sub
                End If
            End If
            If ToolRoom.Tool.CheckHistoryCard(txtHistory_number.Text.Trim) Then
                lblMessage.Text = "Already This History Card Number Is Given"
                Exit Sub
            End If
            Dim blnDone As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Parameters.Add("@history_card_number", SqlDbType.VarChar, 50).Value = txtHistory_number.Text.Trim.ToUpper
                cmd.Parameters.Add("@instrument_number", SqlDbType.VarChar, 50).Value = txtInstrument_number.Text.Trim
                cmd.Parameters.Add("@make", SqlDbType.VarChar, 50).Value = txtMake.Text.Trim
                cmd.Parameters.Add("@model", SqlDbType.VarChar, 50).Value = txtModel.Text.Trim
                cmd.Parameters.Add("@standard", SqlDbType.VarChar, 50).Value = txtStranded.Text.Trim
                cmd.Parameters.Add("@shop_code", SqlDbType.VarChar, 50).Value = ddlShop.SelectedItem.Value.Trim
                cmd.Parameters.Add("@introduced_date", SqlDbType.SmallDateTime, 4).Value = CDate(txtEntry.Text)
                cmd.Parameters.Add("@group_name", SqlDbType.VarChar, 50).Value = ddlGroup.SelectedItem.Value
                cmd.Connection.Open()
                cmd.CommandText = " insert into ms_tools_master ( history_card_number , instrument_number , " & _
                    " make , model , standard , shop_code , introduced_date , tool_code , maintenance_group ," & _
                    " group_name , range , unit_of_measure , accuracy_criteria , " & _
                    " calibration_frequency , calibration_link , process_tolerance , work_instruction_number , " & _
                    " plus_error , minus_error , calibration_prodedure ) " & _
                    " select @history_card_number , @instrument_number , @make , @model , @standard , @shop_code , " & _
                    " @introduced_date , 'I' , 'TOOLS' , group_name , range , unit_of_measure , accuracy_criteria , " & _
                    " calibration_frequency , calibration_link , process_tolerance , work_instruction_number , " & _
                    " convert(float,plus_error) , convert(float,minus_error) , calibration_prodedure from ms_tools_group" & _
                    " where group_name = @group_name "
                If cmd.ExecuteNonQuery = 0 Then Throw New Exception(" tools master error")
                lblMessage.Text = "Record Inserted"
                FillGroup()
                clear()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
            End Try
        End If
    End Sub

    Private Sub txtHistory_number_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHistory_number.TextChanged
        lblMessage.Text = ""
        If ToolRoom.Tool.CheckHistoryCard(txtHistory_number.Text.Trim) Then
            lblMessage.Text = "Already This History Card Number Is Given"
            Exit Sub
        End If
    End Sub
End Class
