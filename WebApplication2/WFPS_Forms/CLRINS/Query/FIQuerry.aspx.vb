Public Class FIQuerry
    Inherits System.Web.UI.Page
    Protected WithEvents txtFromDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfvFrDate As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtToDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfvToDt As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents rblShift As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnShow As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents txtGrind As System.Web.UI.WebControls.TextBox
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
        If Page.IsPostBack = False Then
            txtFromDate.Text = Now.Date
            txtToDate.Text = Now.Date
        End If
    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        lblMessage.Text = ""
        Dim dt1, dt2 As Date
        Try
            dt1 = CDate(txtFromDate.Text)
            dt2 = CDate(txtToDate.Text)
            If dt2 < dt1 Then
                lblMessage.Text = "To Date is less than From date : " & txtFromDate.Text & " - " & txtToDate.Text
                txtFromDate.Text = ""
                txtToDate.Text = ""
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message & " : " & txtFromDate.Text & " - " & txtToDate.Text
            txtFromDate.Text = ""
            txtToDate.Text = ""
        End Try
        If txtFromDate.Text = "" Then
            Exit Sub
        End If
        lblMessage.Text = ""
        If rblShift.SelectedItem.Text.ToLower <> "all" AndAlso (rblType.SelectedItem.Value = 1 Or rblType.SelectedItem.Value = 7) Then
            lblMessage.Text = "Data will be for All Shifts !"
        End If
        Try
            FillGrid(rblType.SelectedItem.Value)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub FillGrid(ByVal List As Int16)
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Dim dt As DataTable
        Try
            Select Case List
                Case 1
                    dt = RWF.FIQuerryDetails.StockedNotTestedInFI(CDate(txtFromDate.Text), CDate(txtToDate.Text))
                Case 2, 3, 4, 5, 6, 23
                    dt = RWF.FIQuerryDetails.FIQuerry(List, CDate(txtFromDate.Text), CDate(txtToDate.Text), rblShift.SelectedItem.Text, "")
                Case 25, 26
                    dt = RWF.FIQuerryDetails.FIQuerry(List, CDate(txtFromDate.Text), CDate(txtToDate.Text), txtGrind.Text.Trim, "")
                Case 7
                    dt = RWF.FIQuerryDetails.QCIReClaimedWheels(CDate(txtFromDate.Text), CDate(txtToDate.Text))
                Case 8, 9, 10, 11, 12, 13, 14, 24
                    dt = RWF.FIQuerryDetails.WheelSetQuerry(List, CDate(txtFromDate.Text), CDate(txtToDate.Text))
                Case 15
                    dt = RWF.FIQuerryDetails.ClosureValues(CDate(txtFromDate.Text), CDate(txtToDate.Text))
                Case 16
                    dt = RWF.FIQuerryDetails.SieveAnalysis(CDate(txtFromDate.Text), CDate(txtToDate.Text))
                Case 17, 18, 19, 20, 21, 22, 27, 28
                    dt = RWF.FIQuerryDetails.DespatchList(CDate(txtFromDate.Text), CDate(txtToDate.Text), List)
            End Select
            DataGrid1.DataSource = dt
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
            dt = Nothing
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If DataGrid1.Items.Count > 0 Then
            Dim prevstate As Boolean = Me.EnableViewState
            Dim tw As New System.IO.StringWriter()
            Dim hw As New System.Web.UI.HtmlTextWriter(tw)
            Try
                Response.ContentType = "application/vnd.ms_excel"
                Response.Charset = ""
                Me.EnableViewState = False
                DataGrid1.RenderControl(hw)
                Response.Write(tw.ToString)
                Response.End()
                Me.EnableViewState = prevstate
            Catch exp As Exception
                lblMessage.Text = exp.Message
            Finally
                prevstate = Nothing
                tw = Nothing
                hw = Nothing
            End Try
        Else
            lblMessage.Text = "No Data in Grid to export !"
        End If
    End Sub
End Class
