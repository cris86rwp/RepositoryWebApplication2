Public Class MagnaQuerry
    Inherits System.Web.UI.Page
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents btnReport As System.Web.UI.WebControls.Button
    Protected WithEvents rblQry As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents lblmessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtFrom As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTo As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblList As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel

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

        ' Page.Theme = themeValue
        Page.Theme = Session("Theme")
    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Page.IsPostBack = False Then
            If rblList.SelectedIndex = 0 Then
                txtFrom.Text = Now.Date
                txtTo.Text = Now.Date
            End If
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
        Try
            FillGrid(rblList.SelectedIndex)
        Catch exp As Exception
            lblmessage.Text = exp.Message
        End Try
    End Sub
    Private Sub FillGrid(ByVal List As Int16)
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        DataGrid2.Visible = False
        Dim dt, dt1 As DataTable
        Try
            Select Case rblQry.SelectedIndex
                Case 0
                    If List = 0 Then
                        dt = RWF.MagnaQuerryDetails.MagnaPinkXC(0, CDate(txtFrom.Text), CDate(txtTo.Text), 0, 0)
                    Else
                        dt = RWF.MagnaQuerryDetails.MagnaPinkXC(0, CDate("1900-01-01"), CDate("1900-01-01"), Val(txtFrom.Text), Val(txtTo.Text))
                    End If

                    If List = 0 Then
                        dt1 = RWF.MagnaQuerryDetails.MagnaPinkXC(1, CDate(txtFrom.Text), CDate(txtTo.Text), 0, 0)
                    Else
                        dt1 = RWF.MagnaQuerryDetails.MagnaPinkXC(1, CDate("1900-01-01"), CDate("1900-01-01"), Val(txtFrom.Text), Val(txtTo.Text))
                    End If
                    DataGrid2.Visible = True
                    DataGrid2.DataSource = dt1
                    DataGrid2.DataBind()
                Case 1
                    If List = 0 Then
                        dt = RWF.MagnaQuerryDetails.MagnaPinkXC(2, CDate(txtFrom.Text), CDate(txtTo.Text), 0, 0)
                    Else
                        dt = RWF.MagnaQuerryDetails.MagnaPinkXC(2, CDate("1900-01-01"), CDate("1900-01-01"), Val(txtFrom.Text), Val(txtTo.Text))
                    End If
                Case 2
                    If List = 0 Then
                        dt = RWF.MagnaQuerryDetails.MagnaMCNOffloads(0, CDate(txtFrom.Text), CDate(txtTo.Text), 0, 0)
                    Else
                        dt = RWF.MagnaQuerryDetails.MagnaMCNOffloads(0, CDate("1900-01-01"), CDate("1900-01-01"), Val(txtFrom.Text), Val(txtTo.Text))
                    End If

                    If List = 0 Then
                        dt1 = RWF.MagnaQuerryDetails.MagnaMCNOffloads(1, CDate(txtFrom.Text), CDate(txtTo.Text), 0, 0)
                    Else
                        dt1 = RWF.MagnaQuerryDetails.MagnaMCNOffloads(1, CDate("1900-01-01"), CDate("1900-01-01"), Val(txtFrom.Text), Val(txtTo.Text))
                    End If
                    DataGrid2.Visible = True
                    DataGrid2.DataSource = dt1
                    DataGrid2.DataBind()
                Case 3
                    If List = 0 Then
                        dt = RWF.MagnaQuerryDetails.MagnaMCNOffloads(2, CDate(txtFrom.Text), CDate(txtTo.Text), 0, 0)
                    Else
                        dt = RWF.MagnaQuerryDetails.MagnaMCNOffloads(2, CDate("1900-01-01"), CDate("1900-01-01"), Val(txtFrom.Text), Val(txtTo.Text))
                    End If
                Case 4, 5, 6, 7
                    dt = RWF.MagnaQuerryDetails.MagnaOffloads(rblQry.SelectedIndex, CDate(txtFrom.Text), CDate(txtTo.Text))
                Case 8
                    If List = 0 Then
                        dt = RWF.MagnaQuerryDetails.MagnaPinkXC(3, CDate(txtFrom.Text), CDate(txtTo.Text), 0, 0)
                        'Else
                        '    dt = RWF.MagnaQuerryDetails.MagnaPinkXC(0, CDate("1900-01-01"), CDate("1900-01-01"), Val(txtFrom.Text), Val(txtTo.Text))
                    End If

                    If List = 0 Then
                        dt1 = RWF.MagnaQuerryDetails.MagnaPinkXC(4, CDate(txtFrom.Text), CDate(txtTo.Text), 0, 0)
                        'Else
                        '    dt1 = RWF.MagnaQuerryDetails.MagnaPinkXC(1, CDate("1900-01-01"), CDate("1900-01-01"), Val(txtFrom.Text), Val(txtTo.Text))
                    End If
                    DataGrid2.Visible = True
                    DataGrid2.DataSource = dt1
                    DataGrid2.DataBind()
            End Select
            DataGrid1.DataSource = dt
            DataGrid1.DataBind()
        Catch exp As Exception
            lblmessage.Text = exp.Message
        Finally
            dt.Dispose()
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
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
End Class
