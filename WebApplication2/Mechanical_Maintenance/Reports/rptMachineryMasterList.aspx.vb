Public Class rptMachineryMasterList
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblMaintenance_group As System.Web.UI.WebControls.Label
    Protected WithEvents cboLocation As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnShowReport As System.Web.UI.WebControls.Button
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    Shared themeValue As String
    Private strMode As String
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
    Private Sub Page_PreInit(ByVal sender As Object, ByVal e As EventArgs)
        Page.Theme = themeValue
    End Sub

    Public Sub New()
        AddHandler PreInit, New EventHandler(AddressOf Page_PreInit)
    End Sub

    Protected Sub dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        'strMode = Request.QueryString("mode")
        'Session("group") = "AC"
        Dim grp As String
        If Session("group") = "RTSHOP" Then
            grp = "MRT"
        Else
            grp = Session("group")
        End If
        lblMaintenance_group.Text = Session("group")
        If Not Page.IsPostBack Then
            PopulateLocation()
        End If
    End Sub
    Private Sub PopulateLocation()
        Dim dt As New DataTable()
        Try
            dt = Maintenance.tables.PopulateReportLocation(lblMaintenance_group.Text.Trim)
            cboLocation.DataSource = dt.DefaultView
            cboLocation.DataTextField = dt.Columns(1).ColumnName
            cboLocation.DataValueField = dt.Columns(0).ColumnName
            cboLocation.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
        End Try
        cboLocation.Items.Insert(0, New ListItem("ALL", "ALL"))
    End Sub

    Private Sub btnShowReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowReport.Click
        Dim strPathName As String
        Dim grp As String
        If Session("group") = "RTSHOP" Then
            grp = "MRT"
        Else
            grp = Session("group")
        End If
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=27898&user0=sa&password0=sadev123" &
     "&prompt0=" & cboLocation.SelectedItem.Value.Trim & "&prompt1=" & grp.Trim & ""
        '        strPathName = "/wap/mss/spares/reports/formats/rptMachineryMasterList.rpt?user0=report&password0=report&promptonrefresh=0&prompt0='" & grp.Trim & "'&prompt1='" & cboLocation.SelectedItem.Value.Trim & "'"
        'strPathName = "/wap/mss/spares/reports/formats/rptMachineryMasterList.rpt?user0=report&password0=report&promptonrefresh=0&prompt0=DateTime(" & Format(CDate(txtFromDate.Text), "yyyy,MM,dd 00, 00, 00") & ")&prompt1=DateTime(" & Format(CDate(txtToDate.Text), "yyyy,MM,dd 00, 00, 00") & ")"
        'strPathName &= "&user0@SubReportforSpareCell.rpt=report&password0@SubReportforSpareCell.rpt=report"
        'strPathName = "/testmss/sseimb/reports/formats/NsIdnSentToHQ.rpt?user0=report&password0=report&promptonrefresh=0&prompt0=DateTime(" & Format(CDate(txtFromDate.Text), "yyyy,MM,dd 00, 00, 00") & ")&prompt1=DateTime(" & Format(CDate(txtToDate.Text), "yyyy,MM,dd 00, 00, 00") & ")"
        Response.Redirect(strPathName)
    End Sub
End Class
