
Public Class WheelCost
    Inherits System.Web.UI.Page
    Dim strRptName As String
    Dim strRptFormula As String
    Dim strRptNameWithPath As String
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected strSql As String
    'Private objTs As TextStream
    Protected WithEvents BtnShow As System.Web.UI.WebControls.Button
    Protected WithEvents rfvld2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtYear As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFrommonth As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTomonth As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfvld1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents lblerr As System.Web.UI.WebControls.Label
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
    'Private objFs As New FileSystemObject()
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
    End Sub

    'Private Function getHeader() As String
    '    Dim tmp As String
    '    Static pgcnt = 1
    '    'tmp = "Wheel & Axle Plant, Yellahanka, Bangalore" & Space(20) & "Run Date :" & CStr(Format(Date.Now, "dd-MMMM-yyyy"))
    '    tmp = Space(32) & "WHEEL AND AXLE PLANT, YELAHANKA" & Space(20) & "Date :" & CStr(Format(Date.Now, "dd-MMMM-yyyy HH:mm:ss"))

    '    tmp &= vbNewLine
    '    tmp &= Space(41) & " BANGALORE ."
    '    getHeader = tmp
    'End Function
    'Private Function getLine(ByVal ch As String, ByVal cnt As Integer) As String
    '    Dim i As Integer
    '    Dim retChars As String

    '    retChars = ""
    '    For i = 1 To cnt
    '        retChars &= ch
    '    Next
    '    getLine = retChars
    'End Function

    Private Sub BtnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShow.Click
        'PrintableReport()
        Dim strPathName As String
        'strServer = Server.MachineName
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=26352&user0=sa&password0=sadev123" &
         "&promptex0=" & CInt(txtYear.Text) &
         "&promptex1=" & CInt(txtFrommonth.Text) &
        "&promptex2=" & CInt(txtTomonth.Text)
        'strPathName &= "&user0@mm_302_mould_room_report1.rpt=report&password0@mm_302_mould_room_report1.rpt=report"
        'strPathName &= "&user0@mm_302_mould_room_report.rpt=report&password0@mm_302_mould_room_report.rpt=report"
        Response.Redirect(strPathName)
    End Sub

End Class
