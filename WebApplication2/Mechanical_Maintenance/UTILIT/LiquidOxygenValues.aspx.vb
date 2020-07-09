Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports System.DateTime
Public Class LiquidOxygenValues
    Inherits System.Web.UI.Page
    Protected WithEvents rblHour As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblArea As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblQuant As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtCallanNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCallanDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtValue As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents dgSavedData As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgMeterRdg As System.Web.UI.WebControls.DataGrid
    Protected WithEvents CheckBox1 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtInitial As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMax As System.Web.UI.WebControls.TextBox
    Protected WithEvents Panel2 As System.Web.UI.WebControls.Panel
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
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
        If Not Page.IsPostBack Then
            txtDate.Text = Now.Date
            Try
                GetGridData()
                GetValue()
                Setfocus(txtValue)
                Panel2.Visible = CheckBox1.Checked
            Catch exp As Exception
                txtDate.Text = ""
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
    Private Sub Setfocus(ByVal ctrl As Control)
        'Define the JavaScript function for the specefied control.
        Dim focusScript As String = "<script language = 'javascript'>" &
        "document.getElementById('" + ctrl.ClientID &
        "').focus();</script>"
        'Add the JavaScript code to the page.
        Page.RegisterStartupScript("FocusScript", focusScript)
        ' MarkControlsAsSelected(ctrl)
    End Sub
    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        lblMessage.Text = ""
        Dim dt As New Date()
        Try
            Panel2.Visible = CheckBox1.Checked
            dt = CDate(txtDate.Text)
            txtDate.Text = dt
            If CDate(txtDate.Text) > Now Then
                lblMessage.Text = " Date  & Time selected cannot be greater than current DateTime "
                txtDate.Text = ""
            Else
                GetGridData()
                GetValue()
            End If
        Catch exp As Exception
            txtDate.Text = ""
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub GetGridData()
        Dim objCmd As SqlCommand
        Dim objDr As SqlDataReader
        Dim con As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")
        Panel2.Visible = CheckBox1.Checked
        dgSavedData.DataSource = Nothing
        dgSavedData.DataBind()

        Dim ds As New DataSet()

        If con.State = ConnectionState.Closed Then
            con.Open()
        Else
            con.Close()
            con.Open()
        End If
        Dim strSql As String
        Try

            Try
                ds = UtilityShop.DataTables.LiquidOxygenValues(CDate(txtDate.Text), CDate(txtDate.Text))
                dgSavedData.DataSource = ds.Tables(0).Copy
                dgSavedData.DataBind()

                Setfocus(txtValue)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
            End Try


            Dim strArg As String

            strArg = "select * from ms_LiquidOxygenValues  where OxyDate='" & Format(CDate(txtDate.Text), "MM/dd/yyyy") & "' and Item = '" & rblHour.SelectedItem.Value & " '"
            objCmd = New SqlCommand(strArg, con)

            objDr = objCmd.ExecuteReader()
            Dim arr() As String
            dgMeterRdg.DataSource = arr
            dgMeterRdg.DataBind()
            dgMeterRdg.DataSource = objDr
            dgMeterRdg.DataBind()
        Catch exp As SqlException
            strSql = exp.StackTrace
            lblMessage.Text = "Line :  " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message

        Catch exp As Exception
            strSql = exp.StackTrace
            lblMessage.Text = "Line  " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message
        End Try

        con.Close()

    End Sub

    Protected Sub DataGrid1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dgMeterRdg.SelectedIndexChanged
        Dim i As String
        dgMeterRdg.SelectedIndex = i
        txtDate.Text = Trim(dgMeterRdg.Items(i).Cells(1).Text)
        rblHour.SelectedItem.Value = dgMeterRdg.Items(i).Cells(2).Text
        rblArea.SelectedItem.Value = dgMeterRdg.Items(i).Cells(3).Text
        rblQuant.SelectedItem.Value = dgMeterRdg.Items(i).Cells(2).Text
        txtValue.Text = dgMeterRdg.Items(i).Cells(5).Text
        txtRemarks.Text = dgMeterRdg.Items(i).Cells(6).Text

        txtCallanNumber.Text = Trim(dgMeterRdg.Items(i).Cells(7).Text)
        txtCallanDate.Text = dgMeterRdg.Items(i).Cells(8).Text


    End Sub

    Private Sub DataGrid1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgMeterRdg.ItemCommand
        Dim i As String
        i = e.Item.ItemIndex()
    End Sub

    Private Sub clear()
        txtValue.Text = ""
        txtRemarks.Text = ""
        txtMax.Text = ""
        txtInitial.Text = ""
    End Sub
    Private Sub GetValue()
        Panel2.Visible = CheckBox1.Checked
        clear()
        Dim dt As New DataTable()
        Try
            dt = UtilityShop.DataTables.LOValues(CDate(txtDate.Text), rblArea.SelectedItem.Text.Trim)
            If dt.Rows.Count > 0 Then
                txtValue.Text = IIf(IsDBNull(dt.Rows(0)("ItemValue")), 0, dt.Rows(0)("ItemValue"))
                txtRemarks.Text = IIf(IsDBNull(dt.Rows(0)("Remarks")), "", dt.Rows(0)("Remarks"))
                txtCallanDate.Text = IIf(IsDBNull(dt.Rows(0)("ChallanDate")), "", dt.Rows(0)("ChallanDate"))
                txtCallanNumber.Text = IIf(IsDBNull(dt.Rows(0)("ChallanNumber")), "", dt.Rows(0)("ChallanNumber"))

                If IIf(IsDBNull(dt.Rows(0)("Reset")), 0, dt.Rows(0)("Reset")) Then
                    Panel2.Visible = True
                    CheckBox1.Checked = True
                    txtMax.Text = IIf(IsDBNull(dt.Rows(0)("PreMaxValue")), "", dt.Rows(0)("PreMaxValue"))
                    txtInitial.Text = IIf(IsDBNull(dt.Rows(0)("NextIniValue")), "", dt.Rows(0)("NextIniValue"))
                End If
            End If
            Setfocus(txtValue)
        Catch exp As Exception
            dt = Nothing
            Throw New Exception(exp.Message)
        Finally
            dt.Dispose()
        End Try
    End Sub
    Private Sub rblHour_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblHour.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            GetValue()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub rblArea_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblArea.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            GetValue()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub rblQuant_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblArea.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            GetValue()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        Dim oCmd As New SqlClient.SqlCommand()
        oCmd.Connection = rwfGen.Connection.ConObj
        Dim done As New Boolean()
        Try
            done = New UtilityShop.FlowMeter().SaveLiqOxy(CDate(txtDate.Text), rblArea.SelectedItem.Text, rblHour.SelectedItem.Value, rblQuant.SelectedItem.Text, Val(txtValue.Text), txtRemarks.Text.Trim, txtCallanNumber.Text.Trim, txtCallanDate.Text.Trim, CheckBox1.Checked, Val(txtMax.Text), Val(txtValue.Text), Val(txtInitial.Text))
        Catch exp As Exception
            done = False
            lblMessage.Text = "Adding of Liquid Oxygen values failed !" & exp.Message
        Finally
            If done Then
                lblMessage.Text = "Records Updated"
            Else
                lblMessage.Text = "Updation failed"
            End If
        End Try
        Try
            GetGridData()
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
    End Sub
    Private Sub txtValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtValue.TextChanged
        lblMessage.Text = ""
        Dim V As Double
        Try
            V = txtValue.Text.Trim
            Setfocus(txtRemarks)
        Catch exp As Exception
            If exp.Message.StartsWith("Cast from string") Then
                lblMessage.Text = " InValid Value! : '" & txtValue.Text.Trim & "'"
            Else
                lblMessage.Text = exp.Message
            End If
            txtValue.Text = ""
        End Try
    End Sub
    Private Sub txtRemarks_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRemarks.TextChanged
        Setfocus(btnSave)
    End Sub
    Private Sub txtChallanNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRemarks.TextChanged
        Setfocus(btnSave)
    End Sub
    Private Sub txtChallanDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRemarks.TextChanged
        Setfocus(btnSave)
    End Sub
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        lblMessage.Text = ""
        Try
            Panel2.Visible = CheckBox1.Checked
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
End Class
