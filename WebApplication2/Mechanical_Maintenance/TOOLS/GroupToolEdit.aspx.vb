Public Class GroupToolEdit
    Inherits System.Web.UI.Page
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents ddlGroup As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnGroup As System.Web.UI.WebControls.Button
    Protected WithEvents txtType As System.Web.UI.WebControls.TextBox
    Protected WithEvents Requiredfieldvalidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtcalibration_prodedure As System.Web.UI.WebControls.TextBox
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
    Protected WithEvents ddlFrequency As System.Web.UI.WebControls.DropDownList
    Protected WithEvents RequiredFieldValidator8 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtCriteria As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator4 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtUnit_of_measure As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator7 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtRange As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
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
        If IsPostBack = False Then
            FillDDLs()
            FillGroupDetails()
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
    Private Sub FillDDLs()
        Dim ds As New DataSet()
        Try
            ds = ToolRoom.Tables.getTables
            FillDDL(ddlGroup, ds.Tables(0))
            FillDDL(ddlFrequency, ds.Tables(3))
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            ds.Dispose()
        End Try
    End Sub

    Private Sub FillDDL(ByRef ddl As System.Web.UI.WebControls.DropDownList, ByRef dt As DataTable)
        ddl.DataSource = dt.DefaultView
        ddl.DataTextField = dt.Columns(0).ColumnName
        ddl.DataValueField = dt.Columns(1).ColumnName
        ddl.DataBind()
        ddl.SelectedIndex = 0
    End Sub

    Private Sub ddlGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlGroup.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            FillGroupDetails()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub FillGroupDetails()
        Dim dt As New DataTable()
        Try
            dt = ToolRoom.Tables.GroupDetails(ddlGroup.SelectedItem.Text)
            txtRange.Text = IIf(IsDBNull(dt.Rows(0)("range")), "", dt.Rows(0)("range"))
            txtUnit_of_measure.Text = IIf(IsDBNull(dt.Rows(0)("unit_of_measure")), "", dt.Rows(0)("unit_of_measure"))
            txtCriteria.Text = IIf(IsDBNull(dt.Rows(0)("accuracy_criteria")), "", dt.Rows(0)("accuracy_criteria"))
            txtLink.Text = IIf(IsDBNull(dt.Rows(0)("calibration_link")), "", dt.Rows(0)("calibration_link"))
            txtTolerance.Text = IIf(IsDBNull(dt.Rows(0)("process_tolerance")), "", dt.Rows(0)("process_tolerance"))
            txtInstruction_number.Text = IIf(IsDBNull(dt.Rows(0)("work_instruction_number")), "", dt.Rows(0)("work_instruction_number"))
            txtError_plus.Text = IIf(IsDBNull(dt.Rows(0)("plus_error")), "", dt.Rows(0)("plus_error"))
            txtError_minus.Text = IIf(IsDBNull(dt.Rows(0)("minus_error")), "", dt.Rows(0)("minus_error"))
            txtcalibration_prodedure.Text = IIf(IsDBNull(dt.Rows(0)("calibration_prodedure")), "", dt.Rows(0)("calibration_prodedure"))
            txtType.Text = IIf(IsDBNull(dt.Rows(0)("type_ins")), "", dt.Rows(0)("type_ins"))
            ddlFrequency.ClearSelection()
            Dim i As Integer
            i = 0
            For i = 0 To ddlFrequency.Items.Count - 1
                If ddlFrequency.Items(i).Value = IIf(IsDBNull(dt.Rows(0)("calibration_frequency")), "", Trim(dt.Rows(0)("calibration_frequency"))) Then
                    ddlFrequency.Items(i).Selected = True
                    Exit For
                End If
            Next
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
        End Try
    End Sub

    Private Sub btnGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGroup.Click
        lblMessage.Text = ""
        Dim blnDone As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            cmd.Parameters.Add("@group_name", SqlDbType.VarChar, 50).Value = ddlGroup.SelectedItem.Text
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
            cmd.CommandText = " update ms_tools_group set  range = @range , unit_of_measure = @unit_of_measure ,  " & _
                  " accuracy_criteria = @accuracy_criteria , calibration_frequency = @calibration_frequency , " & _
                  " calibration_link = @calibration_link , process_tolerance = @process_tolerance , " & _
                  " work_instruction_number = @work_instruction_number , calibration_prodedure = @calibration_prodedure ," & _
                  " plus_error = @plus_error , minus_error = @minus_error , type_ins = @type_ins  " & _
                  " where group_name = @group_name  "
            If cmd.ExecuteNonQuery = 0 Then Throw New Exception(" tools group error")
            lblMessage.Text = "Record Updated !"
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
        ddlGroup.SelectedIndex = 0
    End Sub
End Class
