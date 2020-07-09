Public Class RMWheelsQry
    Inherits System.Web.UI.Page
    Protected WithEvents ddlRMDates As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnShow As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button
    Protected WithEvents txtToDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents txtFromDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label

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
        'Response.Redirect("http://reportserver/mmsreports/awmclr/RMWheelsQry.aspx")
        If IsPostBack = False Then
            txtFromDate.Text = Now.Date
            txtToDate.Text = Now.Date
            Dim dt As New DataTable()
            Try
                Session("Group") = "AWMCLR"
                dt = RWF.AWMCLR.GetRMWheelsDatesForDS8(Session("Group"))
                ddlRMDates.DataSource = dt
                ddlRMDates.DataTextField = dt.Columns("LoadedDate").ColumnName
                ddlRMDates.DataValueField = dt.Columns("LoadedDt").ColumnName
                ddlRMDates.DataBind()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            Finally
                dt.Dispose()
                dt = Nothing
            End Try
        End If
    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        Dim prmpt As String
        Dim rmdt As Date = CDate(ddlRMDates.SelectedItem.Text)
        prmpt = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=8650&user0=sa&password0=sadev123" &
      "&prompt0=DateTime(" & rmdt.Year & "," & rmdt.Month & "," & rmdt.Day & " ,0,0,0)" &
                "&prompt1=" & Session("Group") & ""
        Response.Redirect(prmpt)
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
            lblMessage.Text = "No Data to export !"
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        lblMessage.Text = ""
        Try
            DataGrid1.DataSource = RWF.AWMCLR.RMWheelsSummary(CDate(txtFromDate.Text), CDate(txtToDate.Text), rblType.SelectedItem.Value)
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
End Class
