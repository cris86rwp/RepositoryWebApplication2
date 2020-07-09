Public Class Calibration
    Inherits System.Web.UI.Page
    Protected WithEvents txtToDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFromDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents BtnShow As System.Web.UI.WebControls.Button
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList



    Shared themeValue As String

    Public Sub New()

        AddHandler PreInit, New EventHandler(AddressOf Page_PreInit)
    End Sub


    Private Sub Page_PreInit(ByVal sender As Object, ByVal e As EventArgs)

        ' Page.Theme = themeValue
        Page.Theme = Session("Theme")
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
            txtFromDate.Text = Now.Date
            txtToDate.Text = Now.Date
        End If
    End Sub

    Private Sub BtnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShow.Click
        Dim dt1 As Date, dt2 As Date
        dt1 = CDate(txtFromDate.Text)
        dt2 = CDate(txtToDate.Text)
        If dt2.Subtract(dt1).Days > 31 And dt2.Subtract(dt1).Days > 0 Then
            lblMessage.Text = "Period should be within 31 days"
            Exit Sub
        Else
            lblMessage.Text = ""
        End If
        dt1 = Nothing
        dt2 = Nothing
        Dim strPathName As String
        If rblType.SelectedItem.Text = "BHN" Then
            strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?id=29892&apsuser=Administrator&apspassword=Cris@123&apsauthtype=secEnterprise&user0=sa&password0=sadev123&promptonrefresh=0" &
                    "&prompt0=DateTime(" & CStr(CDate(txtFromDate.Text).Year) & "," & CStr(CDate(txtFromDate.Text).Month) & "," & CStr(CDate(txtFromDate.Text).Day) & ", 0,0,0)" &
                    "&prompt1=DateTime(" & CStr(CDate(txtToDate.Text).Year) & "," & CStr(CDate(txtToDate.Text).Month) & "," & CStr(CDate(txtToDate.Text).Day) & ", 0,0,0)"
            Response.Redirect(strPathName)
        End If
        If rblType.SelectedItem.Text = "MAGNAGLOW" Then
            strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?id=27245&apsuser=Administrator&apspassword=Cris@123&apsauthtype=secEnterprise&user0=sa&password0=sadev123&promptonrefresh=0" &
                    "&prompt0=DateTime(" & CStr(CDate(txtFromDate.Text).Year) & "," & CStr(CDate(txtFromDate.Text).Month) & "," & CStr(CDate(txtFromDate.Text).Day) & ", 0,0,0)" &
                    "&prompt1=DateTime(" & CStr(CDate(txtToDate.Text).Year) & "," & CStr(CDate(txtToDate.Text).Month) & "," & CStr(CDate(txtToDate.Text).Day) & ", 0,0,0)"
            Response.Redirect(strPathName)
        End If
        If rblType.SelectedItem.Text = "ULTRASONIC" Then
            strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?id=27191&apsuser=Administrator&apspassword=Cris@123&apsauthtype=secEnterprise&user0=sa&password0=sadev123&promptonrefresh=0" &
                    "&prompt0=DateTime(" & CStr(CDate(txtFromDate.Text).Year) & "," & CStr(CDate(txtFromDate.Text).Month) & "," & CStr(CDate(txtFromDate.Text).Day) & ", 0,0,0)" &
                    "&prompt1=DateTime(" & CStr(CDate(txtToDate.Text).Year) & "," & CStr(CDate(txtToDate.Text).Month) & "," & CStr(CDate(txtToDate.Text).Day) & ", 0,0,0)"
            Response.Redirect(strPathName)
        End If
        If rblType.SelectedItem.Text = "UV" Then
            strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?id=29900&apsuser=Administrator&apspassword=Cris@123&apsauthtype=secEnterprise&user0=sa&password0=sadev123&promptonrefresh=0" &
                    "&prompt0=DateTime(" & CStr(CDate(txtFromDate.Text).Year) & "," & CStr(CDate(txtFromDate.Text).Month) & "," & CStr(CDate(txtFromDate.Text).Day) & ", 0,0,0)" &
                    "&prompt1=DateTime(" & CStr(CDate(txtToDate.Text).Year) & "," & CStr(CDate(txtToDate.Text).Month) & "," & CStr(CDate(txtToDate.Text).Day) & ", 0,0,0)"
            Response.Redirect(strPathName)
        End If
    End Sub
End Class
