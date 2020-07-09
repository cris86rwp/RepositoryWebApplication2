Public Class PinkSheet
    Inherits System.Web.UI.Page
    Protected WithEvents ddlType As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnShow As System.Web.UI.WebControls.Button
    Protected WithEvents ddlPinkDate As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnCWE As System.Web.UI.WebControls.Button
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
            Try
                PinkSheetDates()
                PinkSheetProducts()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
    Private Sub PinkSheetDates()
        Dim dt As DataTable
        dt = RWF.tables.GetPinkSheetDates()
        ddlPinkDate.DataSource = dt
        ddlPinkDate.DataTextField = dt.Columns(0).ColumnName
        ddlPinkDate.DataValueField = dt.Columns(1).ColumnName
        ddlPinkDate.DataBind()
        ddlPinkDate.SelectedIndex = 0
        dt.Dispose()
        dt = Nothing
    End Sub
    Private Sub PinkSheetProducts()
        Dim dt As DataTable
        dt = RWF.Magna.GetPinkReportDateTypes(ddlPinkDate.SelectedItem.Value)
        ddlType.DataSource = dt
        ddlType.DataTextField = dt.Columns(0).ColumnName
        ddlType.DataValueField = dt.Columns(0).ColumnName
        ddlType.DataBind()
        ddlType.SelectedIndex = 0
        dt.Dispose()
        dt = Nothing
    End Sub
    Private Sub ddlType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlType.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            If Not RWF.tables.IsTypePresent(ddlPinkDate.SelectedItem.Text, ddlType.SelectedItem.Text) Then
                lblMessage.Text = "Pink Cummulative Report Only"
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        Dim strPathName As String
        If RWF.tables.IsTypePresent(ddlPinkDate.SelectedItem.Text, ddlType.SelectedItem.Text) Then
            strPathName = "http://" & rwfGen.ReportServer.ServerName & "" & _
                "/mmsreports/clrmag/formats/PinkSheet.rpt?user0=report&password0=report&promptonrefresh=0" & _
                "&user0@PinkSheetLeftOver.rpt=report&password0@PinkSheetLeftOver.rpt=report" & _
                "&user0@PinkSheetTotalNewReLoad.rpt=report&password0@PinkSheetTotalNewReLoad.rpt=report" & _
                "&user0@PinkSheetCummValues.rpt=report&password0@PinkSheetCummValues.rpt=report" & _
                "&user0@PinkSheetOffLoadAtMagna.rpt=report&password0@PinkSheetOffLoadAtMagna.rpt=report" & _
                "&user0@PinkSheetOffLoadAtFI.rpt=report&password0@PinkSheetOffLoadAtFI.rpt=report" & _
                "&user0@PinkSheetHeatWiseCumm.rpt=report&password0@PinkSheetHeatWiseCumm.rpt=report" & _
                "&user0@PinkSheetHeats.rpt=report&password0@PinkSheetHeats.rpt=report" & _
                "&user0@PinkSheetLocationWiseRej.rpt=report&password0@PinkSheetLocationWiseRej.rpt=report" & _
                "&user0@PinkSheetLocationWiseRejTotal.rpt=report&password0@PinkSheetLocationWiseRejTotal.rpt=report" & _
                "&user0@PinkSheetLocationWiseRejPer.rpt=report&password0@PinkSheetLocationWiseRejPer.rpt=report" & _
                "&user0@PinkSheetSeriesWheels.rpt=report&password0@PinkSheetSeriesWheels.rpt=report" & _
                "&user0@PinkSheetLine2Wheels.rpt=report&password0@PinkSheetLine2Wheels.rpt=report" & _
                "&user0@PinkSheetLine2WheelsList.rpt=report&password0@PinkSheetLine2WheelsList.rpt=report" & _
                "&user0@PinkSheetLine2AWheels.rpt=report&password0@PinkSheetLine2AWheels.rpt=report" & _
                "&user0@PinkSheetLine2AWheelsList.rpt=report&password0@PinkSheetLine2AWheelsList.rpt=report" & _
                "&user0@PinkSheetMagnaXC.rpt=report&password0@PinkSheetMagnaXC.rpt=report" & _
                "&user0@PinkSheetFIXC.rpt=report&password0@PinkSheetFIXC.rpt=report" & _
                "&user0@PinkSheetMRXC.rpt=report&password0@PinkSheetMRXC.rpt=report" & _
                "&prompt0=DateTime(" & CDate(ddlPinkDate.SelectedItem.Value).Year & "," & CDate(ddlPinkDate.SelectedItem.Value).Month & "," & CDate(ddlPinkDate.SelectedItem.Value).Day & "), 0,0,0)" & _
                "&prompt1=" & Trim(ddlType.SelectedItem.Text)
            Response.Redirect(strPathName)
        Else
            strPathName = "http://" & rwfGen.ReportServer.ServerName & "" & _
                "/mmsreports/clrmag/formats/PinkSheetCummulative.rpt?user0=report&password0=report&promptonrefresh=0" & _
                "&prompt0=DateTime(" & CDate(ddlPinkDate.SelectedItem.Value).Year & "," & CDate(ddlPinkDate.SelectedItem.Value).Month & "," & CDate(ddlPinkDate.SelectedItem.Value).Day & "), 0,0,0)" & _
                "&prompt1=" & Trim(ddlType.SelectedItem.Text)
            Response.Redirect(strPathName)
        End If
    End Sub

    Private Sub ddlPinkDate_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlPinkDate.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            PinkSheetProducts()
        Catch exp As Exception
            lblMessage.Text = "Enter valid Date in dd/mm/yyyy format"
        End Try
    End Sub

    Private Sub btnCWE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCWE.Click
        Dim strPathName As String
        strPathName = "http://" & rwfGen.ReportServer.ServerName & "" & _
            "/mmsreports/clrmag/formats/CWEPink.rpt?user0=report&password0=report&promptonrefresh=0" & _
            "&user0@PinkSheetLeftOver.rpt=report&password0@PinkSheetLeftOver.rpt=report" & _
            "&user0@PinkSheetTotalNewReLoad.rpt=report&password0@PinkSheetTotalNewReLoad.rpt=report" & _
            "&user0@PinkSheetCummValues.rpt=report&password0@PinkSheetCummValues.rpt=report" & _
            "&user0@PinkSheetOffLoadAtMagna.rpt=report&password0@PinkSheetOffLoadAtMagna.rpt=report" & _
            "&user0@PinkSheetOffLoadAtFI.rpt=report&password0@PinkSheetOffLoadAtFI.rpt=report" & _
            "&user0@PinkSheetHeatWiseCumm.rpt=report&password0@PinkSheetHeatWiseCumm.rpt=report" & _
            "&user0@PinkSheetHeats.rpt=report&password0@PinkSheetHeats.rpt=report" & _
            "&user0@PinkSheetLocationWiseRej.rpt=report&password0@PinkSheetLocationWiseRej.rpt=report" & _
            "&user0@PinkSheetLocationWiseRejTotal.rpt=report&password0@PinkSheetLocationWiseRejTotal.rpt=report" & _
            "&user0@PinkSheetLocationWiseRejPer.rpt=report&password0@PinkSheetLocationWiseRejPer.rpt=report" & _
            "&user0@PinkSheetSeriesWheels.rpt=report&password0@PinkSheetSeriesWheels.rpt=report" & _
            "&user0@PinkSheetLine2Wheels.rpt=report&password0@PinkSheetLine2Wheels.rpt=report" & _
            "&user0@PinkSheetLine2WheelsList.rpt=report&password0@PinkSheetLine2WheelsList.rpt=report" & _
            "&user0@PinkSheetLine2AWheels.rpt=report&password0@PinkSheetLine2AWheels.rpt=report" & _
            "&user0@PinkSheetLine2AWheelsList.rpt=report&password0@PinkSheetLine2AWheelsList.rpt=report" & _
            "&user0@PinkSheetMagnaXC.rpt=report&password0@PinkSheetMagnaXC.rpt=report" & _
            "&user0@PinkSheetFIXC.rpt=report&password0@PinkSheetFIXC.rpt=report" & _
            "&prompt0=DateTime(" & CDate(ddlPinkDate.SelectedItem.Value).Year & "," & CDate(ddlPinkDate.SelectedItem.Value).Month & "," & CDate(ddlPinkDate.SelectedItem.Value).Day & "), 0,0,0)" & _
            "&prompt1=" & Trim(ddlType.SelectedItem.Text)
        Response.Redirect(strPathName)
    End Sub
End Class
