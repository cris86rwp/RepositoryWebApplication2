Public Class MRShiftWiseReport
    Inherits System.Web.UI.Page
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblShift As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnGen As System.Web.UI.WebControls.Button
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button
    Protected WithEvents Button3 As System.Web.UI.WebControls.Button
    Protected WithEvents txtFrHt As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtToHt As System.Web.UI.WebControls.TextBox
    Protected WithEvents Button4 As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnShow As System.Web.UI.WebControls.Button
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
            Try
                txtFrHt.Text = RWF.tables.GetLatestPrePourHeat
                txtToHt.Text = RWF.tables.GetLatestPrePourHeat
                lblMessage.Text = RWF.MLDING.GetMRShiftDetailsDate
                lblMessage.Text = "Report Data Available for Date : " & lblMessage.Text
                getDateShift()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
    Private Sub getDateShift()
        If Now.Hour = 0 OrElse Now.Hour = 1 OrElse Now.Hour = 2 OrElse Now.Hour = 3 OrElse Now.Hour = 4 OrElse Now.Hour = 5 Then
            txtDate.Text = Now.Date.AddDays(-1)
        Else
            txtDate.Text = Now.Date
        End If
        Dim dt As Date
        Dim Shift As String
        dt = Now
        Select Case dt.Hour
            Case 6 To 13
                Shift = "A"
            Case 14 To 21
                Shift = "B"
            Case Else
                Shift = "C"
        End Select
        Dim i As Integer = 0
        rblShift.ClearSelection()
        For i = 0 To rblShift.Items.Count - 1
            If rblShift.Items(i).Text = Shift Then
                rblShift.Items(i).Selected = True
                Exit For
            End If
        Next
        dt = Nothing
        Shift = Nothing
        i = Nothing
    End Sub

    Private Sub btnGen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGen.Click
        lblMessage.Text = ""
        Dim Done As Boolean
        Try
            Done = RWF.MLDING.CheckShift(CDate(txtDate.Text), rblShift.SelectedItem.Value)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If Done Then
            Done = False
            Done = New RWF.MLDING().MRShiftDetails(CDate(txtDate.Text), rblShift.SelectedItem.Value)
        Else
            Exit Sub
        End If
        If Done Then
            lblMessage.Text = "Data Generated for Date : " & RWF.MLDING.GetMRShiftDetailsDate
        Else
            lblMessage.Text = "Data Generation Failed !"
        End If
        Done = Nothing
    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        If RWF.MLDING.CheckMRShiftDetailsDate(CDate(txtDate.Text), rblShift.SelectedItem.Value) Then
            Dim strPathName As String
            strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?id=10273&apsuser=Administrator&apspassword=Cris@123&apsauthtype=secEnterprise&user0=sa&password0=sadev123&promptonrefresh=0" &
                "&user0@MROnLineMould.rpt=sa&password0@MROnLineMould.rpt=sa" &
                "&user0@MRMouldRemoverFromLine.rpt=sa&password0@MRMouldRemoverFromLine.rpt=sa" &
                "&user0@MagnaOutTurnShiftWise.rpt=sa&password0@MagnaOutTurnShiftWise.rpt=sa" &
                "&user0@MagnaOffLoads.rpt=sa&password0@MagnaOffLoads.rpt=sa" &
                "&user0@MROffLoadstShiftWise.rpt=sa&password0@MROffLoadstShiftWise.rpt=sa" &
                "&prompt0=DateTime(" & CDate(txtDate.Text).Year & ", " & CDate(txtDate.Text).Month & ", " & CDate(txtDate.Text).Day & ", 0, 0, 0)" &
                "&prompt1=" & rblShift.SelectedItem.Value
            Response.Redirect(strPathName)
        Else
            lblMessage.Text = "Data Not Generated for selected Date & Shift !"
        End If
    End Sub

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    If RWF.MLDING.CheckMRShiftDetailsDate(CDate(txtDate.Text), rblShift.SelectedItem.Value) Then
    '        Dim strPathName As String
    '        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?id=8157&apsuser=Administrator&apspassword=Cris@123&apsauthtype=secEnterprise&user0=sa&password0=sadev123&promptonrefresh=0" &
    '            "&user0@MROutTurnShiftWise.rpt=sa&password0@MROutTurnShiftWise.rpt=sa" &
    '            "&user0@MRXCListShiftWise.rpt=sa&password0@MRXCListShiftWise.rpt=sa" &
    '            "&user0@MagnaXCDetailsShiftWise.rpt=sa&password0@MagnaXCDetailsShiftWise.rpt=sa" &
    '            "&prompt0=DateTime(" & CDate(txtDate.Text).Year & ", " & CDate(txtDate.Text).Month & ", " & CDate(txtDate.Text).Day & ", 0, 0, 0)" &
    '            "&prompt1=" & rblShift.SelectedItem.Value
    '        Response.Redirect(strPathName)
    '    Else
    '        lblMessage.Text = "Data Not Generated for selected Date & Shift !"
    '    End If
    'End Sub

    'Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    '    If RWF.MLDING.CheckMRShiftDetailsDate(CDate(txtDate.Text), rblShift.SelectedItem.Value) Then
    '        Dim strPathName As String
    '        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?id=8169&apsuser=Administrator&apspassword=Cris@123&apsauthtype=secEnterprise&user0=sa&password0=sadev123&promptonrefresh=0" &
    '            "&user0@MagnaXCShiftWise.rpt=sa&password0@MagnaXCShiftWise.rpt=sa" &
    '            "&user0@MRBreakDowns.rpt=sa&password0@MRBreakDowns.rpt=sa" &
    '            "&prompt0=DateTime(" & CDate(txtDate.Text).Year & ", " & CDate(txtDate.Text).Month & ", " & CDate(txtDate.Text).Day & ", 0, 0, 0)" &
    '            "&prompt1=" & rblShift.SelectedItem.Value
    '        Response.Redirect(strPathName)
    '    Else
    '        lblMessage.Text = "Data Not Generated for selected Date & Shift !"
    '    End If
    'End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        lblMessage.Text = ""
        Dim Done As Boolean
        Try
            Done = New RWF.MLDING().MRShiftDetailsNew(Val(txtFrHt.Text), Val(txtToHt.Text))
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If Done Then
            lblMessage.Text = "Data Generated "
        Else
            lblMessage.Text = "Data Generation Failed !"
        End If
        Done = Nothing
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        lblMessage.Text = Nothing
        DataGrid1.DataBind()
        Try
            DataGrid1.DataSource = New RWF.MLDING().MRShiftDetailsNewData(Val(txtFrHt.Text), Val(txtToHt.Text))
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
End Class
