Public Class MouldRepairShopReports
    Inherits System.Web.UI.Page
    Protected WithEvents txtBlank As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnMouldPopulation As System.Web.UI.WebControls.Button
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents rblQry As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents rblMouldType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
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
        If IsPostBack = False Then
            Dim dt As DataTable
            dt = MouldMaster.MRSMRS.MouldTypeList
            rblMouldType.DataSource = dt
            rblMouldType.DataTextField = dt.Columns(0).ColumnName
            rblMouldType.DataValueField = dt.Columns(0).ColumnName
            rblMouldType.DataBind()
            rblMouldType.Items.Insert(0, "ALL")
        End If
    End Sub
    Private Sub FillGrid()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Dim done As Boolean
        Dim i As Int16
        For i = 0 To rblQry.Items.Count - 1
            If rblQry.Items(i).Selected = True Then
                done = True
                Exit For
            End If
        Next
        If done Then
            i = 0
            done = False
            For i = 0 To rblMouldType.Items.Count - 1
                If rblMouldType.Items(i).Selected = True Then
                    done = True
                    Exit For
                End If
            Next
            If done = False Then
                lblMessage.Text = "Please select Mould Description !"
                i = Nothing
                done = Nothing
                Exit Sub
            End If
        Else
            lblMessage.Text = "Please select Mould Type !"
            Exit Sub
        End If
        Try
            DataGrid1.DataSource = MouldMaster.MRSMRS.MouldDetails(rblQry.SelectedItem.Value, rblMouldType.SelectedItem.Text)
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        i = Nothing
        done = Nothing
    End Sub

    Private Sub rblQry_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblQry.SelectedIndexChanged
        lblMessage.Text = ""
        txtBlank.Text = ""
        Try
            FillGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtBlank_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBlank.TextChanged
        lblMessage.Text = ""
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        rblQry.ClearSelection()
        Try
            DataGrid1.DataSource = MouldMaster.MRSMRS.MouldsBlank(txtBlank.Text.Trim)
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub printReport()
        Dim strPathName As String
        strPathName = "http://192.168.0.127:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?id=8542&apsuser=Administrator&apspassword=Rajesh&1225&apsauthtype=Enterprise&user0=pankaj&password0=pankaj&promptonrefresh=0" &
                    "&user0@MRSPopulationOfDRAGs.rpt=sa&password0@MRSPopulationOfDRAGs.rpt=sa&user0@MRSPopulationOfDragIngates.rpt=sa&password0@MRSPopulationOfDragIngates.rpt=sa&user0@MRSPopulationOfDragGraphiteAvailable.rpt=sa&password0@MRSPopulationOfDragGraphiteAvailable.rpt=sa"
        Response.Redirect(strPathName)
    End Sub

    Private Sub btnMouldPopulation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMouldPopulation.Click
        printReport()
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

    Private Sub rblMouldType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblMouldType.SelectedIndexChanged
        lblMessage.Text = ""
        txtBlank.Text = ""
        Try
            FillGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
End Class
