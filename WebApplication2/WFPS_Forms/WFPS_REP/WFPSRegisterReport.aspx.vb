Public Class WFPSRegisterReport
    Inherits System.Web.UI.Page
    Protected WithEvents txtHeatNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnShow As System.Web.UI.WebControls.Button
    Protected WithEvents rblType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents rblReport As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblShift As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents pnlMPO As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlReg As System.Web.UI.WebControls.Panel
    Protected WithEvents rblRep As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnReport As System.Web.UI.WebControls.Button
    Protected WithEvents txtHeat As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtFrDt As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtToDt As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents btnDetails As System.Web.UI.WebControls.Button



    Shared themeValue As String
    Public Function DateTime(x As Date) As String
        DateTime = "Date(" & Year(x) & "," & Month(x) & "," & Day(x) & " 0,0,0)"
    End Function

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


    '#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If IsPostBack = False Then
            txtFrDt.Text = Now.Date
            txtToDt.Text = Now.Date
            Textbox1.Text = Now.Date
            Textbox2.Text = Now.Date

        End If
    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        Dim strPathName As String
        If rblType.SelectedItem.Value = 1 Then
            strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=26683&user0=sa&password0=sadev123" &
      "&prompt0=" & Val(txtHeatNumber.Text) & "" &
                    "&prompt1=" & Val(rblType.SelectedItem.Value) & ""
            Response.Redirect(strPathName)
            'ElseIf rblType.SelectedItem.Value = 2 Then
            '    strPathName =  "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=26691&user0=sa&password0=sadev123" &
            '            "&prompt0=" & Val(txtHeatNumber.Text) & "" &
            '            "&prompt1=" & Val(rblType.SelectedItem.Value) & ""
            '    Response.Redirect(strPathName)
        ElseIf rblType.SelectedItem.Value = 3 Then
            strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=26709&user0=sa&password0=sadev123" &
     "&prompt0=" & Val(txtHeatNumber.Text) & "" &
                    "&prompt1=" & Val(rblType.SelectedItem.Value) & ""
            Response.Redirect(strPathName)
            'ElseIf rblType.SelectedItem.Value = 4 Then
            '    strPathName =  "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=26717&user0=sa&password0=sadev123" &
            '            "&prompt0=" & Val(txtHeatNumber.Text) & "" &
            '            "&prompt1=" & Val(rblType.SelectedItem.Value) & ""
            '    Response.Redirect(strPathName)
        ElseIf rblType.SelectedItem.Value = 5 Then
            strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=26717&user0=sa&password0=sadev123" &
                    "&prompt0=" & Val(txtHeatNumber.Text) & "" &
                    "&prompt1=" & Val(rblType.SelectedItem.Value) & ""
            Response.Redirect(strPathName)
        ElseIf rblType.SelectedItem.Value = 6 Then
            strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=26736&user0=sa&password0=sadev123" &
                     "&prompt0=" & Val(txtHeatNumber.Text) & "" &
                    "&prompt1=" & Val(rblType.SelectedItem.Value) & ""
            Response.Redirect(strPathName)
        ElseIf rblType.SelectedItem.Value = 7 Then
            strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=26743&user0=sa&password0=sadev123" &
              "&prompt0=" & Val(txtHeatNumber.Text) & "" &
                    "&prompt1=" & Val(rblType.SelectedItem.Value) & ""
            Response.Redirect(strPathName)
        ElseIf rblType.SelectedItem.Value = 8 Then
            strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=26750&user0=sa&password0=sadev123" &
                     "&prompt0=" & Val(txtHeatNumber.Text) & "" &
                    "&prompt1=" & Val(rblType.SelectedItem.Value) & ""
            Response.Redirect(strPathName)
        ElseIf rblType.SelectedItem.Value = 9 Then
            strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=26757&user0=sa&password0=sadev123" &
                    "&prompt0=" & Val(txtHeatNumber.Text) & "" &
                    "&prompt1=" & Val(rblType.SelectedItem.Value) & ""
            Response.Redirect(strPathName)
        End If
    End Sub
    Private Sub btnDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        Dim Done As Boolean
        lblMessage.Text = ""
        Try
            txtFrDt.Text = CDate(txtFrDt.Text)
            txtToDt.Text = CDate(txtToDt.Text)
        Catch exp As Exception
            lblMessage.Text = exp.Message
            Done = True
        End Try
        If CDate(txtFrDt.Text) > Now.Date Then
            lblMessage.Text = "From Date cannot greater than Today!"
            Exit Sub
        End If
        If CDate(txtToDt.Text) > Now.Date Then
            lblMessage.Text = "To Date cannot greater than Today!"
            Exit Sub
        End If
        If CDate(txtFrDt.Text) > CDate(txtToDt.Text) Then
            lblMessage.Text = "To Date cannot be less than From Date !"
            Exit Sub
        End If

        If Not Done Then
            Dim strPathName As String

            strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=8497&user0=sa&password0=sadev123" &
             "&promptex0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & ", " & CDate(txtFrDt.Text).Day & ", 0,0,0)" &
            "&promptex1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)"
            Response.Redirect(strPathName)
        End If

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Done As Boolean
        lblMessage.Text = ""
        Try
            Textbox1.Text = CDate(Textbox1.Text)
            Textbox2.Text = CDate(Textbox2.Text)
        Catch exp As Exception
            lblMessage.Text = exp.Message
            Done = True
        End Try
        If CDate(Textbox1.Text) > Now.Date Then
            lblMessage.Text = "From Date cannot greater than Today!"
            Exit Sub
        End If
        If CDate(Textbox2.Text) > Now.Date Then
            lblMessage.Text = "To Date cannot greater than Today!"
            Exit Sub
        End If
        If CDate(Textbox2.Text) < CDate(Textbox1.Text) Then
            lblMessage.Text = "To Date cannot be less than From Date !"
            Exit Sub
        End If

        If Not Done Then
            Dim strPathName As String

            strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=8517&user0=sa&password0=sadev123" &
      "&promptex0=DateTime(" & CDate(Textbox1.Text).Year & "," & CDate(Textbox1.Text).Month & ", " & CDate(Textbox1.Text).Day & ", 0,0,0)" &
            "&promptex1=DateTime(" & CDate(Textbox2.Text).Year & "," & CDate(Textbox2.Text).Month & "," & CDate(Textbox2.Text).Day & ", 0,0,0)"
            Response.Redirect(strPathName)
        End If

    End Sub






End Class
