Public Class mm_MonthlyWorkOrders
    Inherits System.Web.UI.Page
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents rblQry As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnForAppr As System.Web.UI.WebControls.Button
    Protected WithEvents rblYear As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblMonth As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnShow As System.Web.UI.WebControls.Button
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
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
        'Response.Redirect("http://mmsserver/mmsreports/pcopco/mm_MonthlyWorkOrders.aspx")
        btnForAppr.Visible = False
        If Page.IsPostBack = False Then
            SetRbls()
            Button1.Text = "Show " & rblQry.SelectedItem.Text & " data in Grid"
        End If
    End Sub

    Private Sub SetRbls()
        Dim i As Int16
        Try
            Dim ds As DataSet = PCO.tables.WorkorderParameters
            rblYear.DataSource = ds.Tables(0)
            rblYear.DataTextField = ds.Tables(0).Columns(0).ColumnName
            rblYear.DataValueField = ds.Tables(0).Columns(1).ColumnName
            rblYear.DataBind()

            rblMonth.DataSource = ds.Tables(1)
            rblMonth.DataTextField = ds.Tables(1).Columns(1).ColumnName
            rblMonth.DataValueField = ds.Tables(1).Columns(0).ColumnName
            rblMonth.DataBind()

            rblYear.ClearSelection()
            For i = 0 To rblYear.Items.Count - 1
                If rblYear.Items(i).Text = Now.Year Then
                    rblYear.Items(i).Selected = True
                    Exit For
                End If
            Next
            i = 0
            rblMonth.ClearSelection()
            For i = 0 To rblMonth.Items.Count - 1
                If rblMonth.Items(i).Value = Chr(Now.Month + 64) Then
                    rblMonth.Items(i).Selected = True
                    Exit For
                End If
            Next
            i = Nothing
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        Dim strPathName As String
        If PCO.tables.WorkorderCount(Right(rblYear.SelectedItem.Text, 1) + rblMonth.SelectedItem.Value) > 0 Then
            strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?id=25760&apsuser=Administrator&apspassword=Cris@123&apsauthtype=secEnterprise&user0=sa&password0=sadev123&promptonrefresh=0" &
                "&user0=sa&password0=sadev123&prompt1=" & rblYear.SelectedItem.Value + rblMonth.SelectedItem.Value & "&prompt0=" & rblMonth.SelectedItem.Text.ToUpper & ", " & rblYear.SelectedItem.Text & "" &
                "&user0@SubReport.rpt=sa&password0@SubReport.rpt=sadev123"
            Response.Redirect(strPathName)
        Else
            lblMessage.Text = "InValid Selection"
        End If
    End Sub

    Private Sub Qry(ByVal type As String)
        lblMessage.Text = ""
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Dim dt As New DataTable()
        Try
            If type = 0 Then
                If PCO.tables.WorkorderCount(Right(rblYear.SelectedItem.Text, 1) + rblMonth.SelectedItem.Value) > 0 Then
                    dt = PCO.tables.WOQry(Right(rblYear.SelectedItem.Text, 1) + rblMonth.SelectedItem.Value)
                Else
                    lblMessage.Text = "InValid Selection"
                    Exit Sub
                End If
            Else
                dt = PCO.tables.PCOQry(type.Trim)
            End If
            DataGrid1.DataSource = dt
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
            dt = Nothing
        End Try
    End Sub

    Private Sub btnForAppr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnForAppr.Click
        Dim strPathName As String
        'strPathName = "http://" & rwfGen.ReportServer.ServerName & "" & _
        '            "/MMSREPORTS/pcopco/formats/mm_monthlyWorkOrdersForCosting.rpt?user0=wap&password0=wap" & _
        '            "&user0=wap&password0=wap&prompt1=" & rblYear.SelectedItem.Value + rblMonth.SelectedItem.Value & "&prompt0=" & rblMonth.SelectedItem.Text.ToUpper & ", " & rblYear.SelectedItem.Text
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?id=8265&apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&user0=sa&password0=sadev123&promptonrefresh=0" &
            "http://" & rwfGen.ReportServer.ServerName & "" &
                    "/MMSREPORTS/pcopco/formats/mm_monthlyWorkOrdersForCosting.rpt?user0=report&password0=report&promptonrefresh=0" &
                    "&user0=report&password0=report&prompt0=" & rblYear.SelectedItem.Value + rblMonth.SelectedItem.Value & ""
        Response.Redirect(strPathName)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        lblMessage.Text = ""
        Try
            Qry(rblQry.SelectedIndex)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub rblQry_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblQry.SelectedIndexChanged
        lblMessage.Text = ""
        Button1.Text = "Show " & rblQry.SelectedItem.Text & " data in Grid"
    End Sub
End Class
