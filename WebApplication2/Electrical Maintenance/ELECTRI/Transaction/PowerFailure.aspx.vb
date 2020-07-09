Public Class PowerFailure
    Inherits System.Web.UI.Page
    Protected WithEvents RangeValidator1 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents grdStatistics As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnExit As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
    Protected WithEvents btnSubmit_Clicks As System.Web.UI.WebControls.Button
    Protected WithEvents txtFrom_time As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTo_time As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblDuration As System.Web.UI.WebControls.Label
    Protected WithEvents txtSf_to_time As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSf_from_time As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblSf_duration As System.Web.UI.WebControls.Label
    Protected WithEvents txtDf_from_time As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDf_to_time As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblDf_duration As System.Web.UI.WebControls.Label
    Protected WithEvents lblMode As System.Web.UI.WebControls.Label
    Protected WithEvents grdPower As System.Web.UI.WebControls.DataGrid
    Protected WithEvents RequiredFieldValidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator3 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator4 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator5 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator6 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator7 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents lblTotalRes As System.Web.UI.WebControls.Label
    Protected WithEvents txtSlNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList


#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    '<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    'End Sub

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
        ' lblMode.Text = Request.QueryString("mode")
        lblMode.Text = "add"
        'lblMode.Text = "edit"
        'lblMode.Text = "delete"
        If Not Page.IsPostBack Then
            txtFrom_time.Text = Now
            txtTo_time.Text = Now
            txtDate.Text = Now.Date
            BindGrid()
            If lblMode.Text.Equals("add") Then
                getSerailNumber()
            End If
        End If
    End Sub

    Private Sub getSerailNumber()
        Try
            txtSlNo.Text = Maintenance.ElecTables.getSerailNumber(CDate(txtDate.Text))
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnSubmit_Clicks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit_Clicks.Click
        Try
            Dim d As DateTime
            d = txtFrom_time.Text
            d = txtTo_time.Text
            d = txtSf_from_time.Text
            d = txtSf_to_time.Text
            d = txtDf_from_time.Text
            d = txtDf_to_time.Text
        Catch exp As Exception
            lblMessage.Text = "Enter proper Values"
            Exit Sub
        End Try
        Dim Done As Boolean
        Try
            Done = New Maintenance.Electrical().PowerFailure(lblMode.Text, CDate(txtDate.Text), Format(CDate(txtFrom_time.Text), "yyyy/MM/dd HH:mm:ss"), Format(CDate(txtTo_time.Text), "yyyy/MM/dd HH:mm:ss"), Format(CDate(txtSf_from_time.Text), "yyyy/MM/dd HH:mm:ss"), Format(CDate(txtSf_to_time.Text), "yyyy/MM/dd HH:mm:ss"), lblSf_duration.Text, Format(CDate(txtDf_from_time.Text), "yyyy/MM/dd HH:mm:ss"), Format(CDate(txtDf_to_time.Text), "yyyy/MM/dd HH:mm:ss"), lblDf_duration.Text, lblTotalRes.Text, txtRemarks.Text.Trim, lblDuration.Text, Val(txtSlNo.Text))
            clear()
            lblMessage.Text = "Record Inserted"
            BindGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub BindGrid()
        grdPower.DataSource = Maintenance.ElecTables.PowerFailureValues(CDate(txtDate.Text), 0, True)
        grdPower.DataBind()
    End Sub

    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        BindGrid()
        If lblMode.Text.Equals("edit") Then
            txtSlNo.Text = ""
        Else
            getSerailNumber()
        End If
    End Sub

    Private Sub txtTo_time_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTo_time.TextChanged
        TimeDiff(txtFrom_time, txtTo_time, lblDuration)
    End Sub

    Private Sub txtSf_to_time_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSf_to_time.TextChanged
        TimeDiff(txtSf_from_time, txtSf_to_time, lblSf_duration)
        lblTotalRes.Text = lblSf_duration.Text + lblDf_duration.Text
    End Sub

    Private Sub txtDf_to_time_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDf_to_time.TextChanged
        TimeDiff(txtDf_from_time, txtDf_to_time, lblDf_duration)
    End Sub
    Sub TimeAdd(ByVal txtFrom As Label, ByVal txtTo As Label, ByVal lblResult As Label)
        Dim from_time, to_time As TimeSpan
        Dim time As TimeSpan
        Try
            time = to_time.Add(from_time)
            lblResult.Text = time.ToString
        Catch exp As Exception
            lblMessage.Text = "Enter Proper Time"
            Exit Sub
        End Try
    End Sub

    Sub TimeDiff(ByVal txtFrom As TextBox, ByVal txtTo As TextBox, ByVal lblResult As Label)
        Dim from_time, to_time As DateTime
        Dim time As TimeSpan
        Try
            from_time = txtFrom.Text
            to_time = txtTo.Text
            time = to_time.Subtract(from_time)
            lblResult.Text = time.ToString
        Catch exp As Exception
            lblMessage.Text = "Enter Proper Time"
            Exit Sub
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        clear()
    End Sub

    Private Sub clear()
        lblDf_duration.Text = ""
        lblDuration.Text = ""
        lblMessage.Text = ""
        lblSf_duration.Text = ""
        txtDate.Text = Date.Today
        txtDf_from_time.Text = ""
        txtDf_to_time.Text = ""
        txtFrom_time.Text = ""
        txtSf_to_time.Text = ""
        txtSf_from_time.Text = ""
        txtTo_time.Text = ""
        getSerailNumber()
    End Sub

    Private Sub InitializeComponent()

    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Server.Transfer("/mss/selectModule.aspx")
    End Sub

    Private Sub txtSlNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSlNo.TextChanged
        Try
            If lblMode.Text.Equals("edit") Then
                getDetails()
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub getDetails()
        Dim dt As DataTable
        Try
            dt = Maintenance.ElecTables.PowerFailureValues(CDate(txtDate.Text), Val(txtSlNo.Text))
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0)(1)) Then
                    txtDate.Text = dt.Rows(0)(1)
                End If
                If Not IsDBNull(dt.Rows(0)(2)) Then
                    txtFrom_time.Text = dt.Rows(0)(2)
                End If
                If Not IsDBNull(dt.Rows(0)(3)) Then
                    txtTo_time.Text = dt.Rows(0)(3)
                End If
                If Not IsDBNull(dt.Rows(0)(4)) Then
                    lblDuration.Text = dt.Rows(0)(4)
                End If
                If Not IsDBNull(dt.Rows(0)(5)) Then
                    Dim time As DateTime
                    time = dt.Rows(0)(5)
                    txtSf_from_time.Text = Format(time, "dd/MM/yyyy HH:mm:ss")
                End If
                If Not IsDBNull(dt.Rows(0)(6)) Then
                    Dim time As DateTime
                    time = dt.Rows(0)(6)
                    txtSf_to_time.Text = Format(time, "dd/MM/yyyy HH:mm:ss")
                End If
                If Not IsDBNull(dt.Rows(0)(7)) Then
                    Dim time As String
                    time = dt.Rows(0)(7)
                    lblSf_duration.Text = time
                End If
                If Not IsDBNull(dt.Rows(0)(8)) Then
                    Dim time As DateTime
                    time = dt.Rows(0)(8)
                    txtDf_from_time.Text = Format(time, "dd/MM/yyyy HH:mm:ss")
                End If
                If Not IsDBNull(dt.Rows(0)(9)) Then
                    Dim time As DateTime
                    time = dt.Rows(0)(9)
                    txtDf_to_time.Text = Format(time, "dd/MM/yyyy HH:mm:ss")
                End If
                If Not IsDBNull(dt.Rows(0)(10)) Then
                    Dim time As String
                    time = dt.Rows(0)(10)
                    lblDf_duration.Text = time
                End If

                If Not IsDBNull(dt.Rows(0)(11)) Then
                    lblTotalRes.Text = dt.Rows(0)(11)
                End If
                If Not IsDBNull(dt.Rows(0)(12)) Then
                    txtRemarks.Text = dt.Rows(0)(12)
                End If
            End If
            grdPower.DataSource = dt
            grdPower.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
        End Try
    End Sub
End Class
