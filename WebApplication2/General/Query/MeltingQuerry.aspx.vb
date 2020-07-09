Public Class MeltingQuerry
    Inherits System.Web.UI.Page
    Protected WithEvents rblList As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtFrom As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTo As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblQry As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnReport As System.Web.UI.WebControls.Button
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtCar As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList

    Shared themeValue As String

    Public Sub New()

        AddHandler PreInit, New EventHandler(AddressOf Page_PreInit)
    End Sub

    Private Sub Page_PreInit(ByVal sender As Object, ByVal e As EventArgs)

        Page.Theme = themeValue
    End Sub


    Protected Sub Dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub

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
        If Page.IsPostBack = False Then
            If rblList.SelectedIndex = 0 Then
                txtFrom.Text = Now.Date
                txtTo.Text = Now.Date
            End If
        End If
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
                lblmessage.Text = exp.Message
            Finally
                prevstate = Nothing
                tw = Nothing
                hw = Nothing
            End Try
        Else
            lblmessage.Text = "No Data in Grid to export !"
        End If
    End Sub

    Private Sub rblList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblList.SelectedIndexChanged
        lblmessage.Text = ""
        txtFrom.Text = ""
        txtTo.Text = ""
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        If rblList.SelectedIndex = 0 Then
            Try
                txtFrom.Text = Now.Date
                txtTo.Text = Now.Date
            Catch exp As Exception
                lblmessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click
        lblmessage.Text = ""
        If rblList.SelectedIndex = 0 Then
            Try
                If CDate(txtTo.Text) < CDate(txtFrom.Text) Then
                    lblmessage.Text = "To Date is less than From date : " & txtFrom.Text & " - " & txtTo.Text
                    txtFrom.Text = ""
                    txtTo.Text = ""
                End If
            Catch exp As Exception
                lblmessage.Text = exp.Message & " : " & txtFrom.Text & " - " & txtTo.Text
                txtFrom.Text = ""
                txtTo.Text = ""
            End Try
            If txtFrom.Text = "" Then
                Exit Sub
            End If
        End If
        lblmessage.Text = ""
        If rblQry.SelectedItem.Value = 1 Then
            If Val(txtCar.Text) = 0 Then
                txtCar.Text = ""
                lblmessage.Text = "Please provide Carbon value !"
                Exit Sub
            End If
        End If
        Try
            FillGrid(rblQry.SelectedItem.Value)
        Catch exp As Exception
            lblmessage.Text = exp.Message
        End Try
    End Sub

    Private Sub FillGrid(ByVal QryNo As Int16)
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Dim dt As DataTable
        Try
            If rblQry.SelectedItem.Value = 1 Then
                If rblList.SelectedIndex = 0 Then
                    dt = RWF.Melting.Carbon(CDate(txtFrom.Text), CDate(txtTo.Text), 0, 0, 0, Val(txtCar.Text))
                Else
                    dt = RWF.Melting.Carbon(CDate("1900-01-01"), CDate("1900-01-01"), Val(txtFrom.Text), Val(txtTo.Text), 1, Val(txtCar.Text))
                End If
            Else
                If rblList.SelectedIndex = 0 Then
                    If rblQry.SelectedItem.Value = 12 Then
                        Throw New Exception("Not allowed for Date selection !")
                    Else
                        dt = RWF.Melting.MeltingData(rblQry.SelectedItem.Value, CDate(txtFrom.Text), CDate(txtTo.Text), 0, 0, 0)
                    End If
                Else
                    If rblQry.SelectedItem.Value = 10 OrElse rblQry.SelectedItem.Value = 13 OrElse rblQry.SelectedItem.Value = 14 OrElse rblQry.SelectedItem.Value = 15 Then
                        Throw New Exception("Not allowed for Heat Range selection !")
                    Else
                        dt = RWF.Melting.MeltingData(rblQry.SelectedItem.Value, CDate("1900-01-01"), CDate("1900-01-01"), Val(txtFrom.Text), Val(txtTo.Text), 1)
                    End If
                End If
            End If
            DataGrid1.DataSource = dt
            DataGrid1.DataBind()
            dt.Dispose()
            dt = Nothing
        Catch exp As Exception
            Throw New Exception(exp.Message)
        End Try
    End Sub

    Protected Sub rblQry_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
End Class
