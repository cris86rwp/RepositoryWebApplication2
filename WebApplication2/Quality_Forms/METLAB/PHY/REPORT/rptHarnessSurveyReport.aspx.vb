Public Class rptHarnessSurveyReport
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents txtWheelNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlWheelNumber As System.Web.UI.WebControls.DropDownList
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
        If Not IsPostBack Then
            getWheelNumbers()
        End If
    End Sub
    Private Function ReturnWheel(ByVal mystr As String) As Long
        Dim myarray As Array
        Dim mywheel, myheat As Long
        If mystr <> "" Then
            myarray = Split(mystr, "/")
            mywheel = myarray(0)
            myheat = myarray(1)
            Return mywheel
        End If
    End Function
    Private Function ReturnHeat(ByVal mystr As String) As Long
        Dim myarray As Array
        Dim mywheel, myheat As Long
        If mystr <> "" Then
            myarray = Split(mystr, "/")
            mywheel = myarray(0)
            myheat = myarray(1)
            Return myheat
        End If
    End Function
    Private Sub getWheelNumbers()
        ddlWheelNumber.Items.Clear()
        Dim dt As DataTable = metLab.tables.getHardnessTestWheelNumbers
        Try
            ddlWheelNumber.DataSource = dt
            ddlWheelNumber.DataTextField = dt.Columns(0).ColumnName
            ddlWheelNumber.DataValueField = dt.Columns(1).ColumnName
            ddlWheelNumber.DataBind()
            ddlWheelNumber.Items.Add("Select")
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim mywheel As Long
        Dim myheat As Long
        mywheel = ReturnWheel(Trim(txtWheelNumber.Text.Trim))
        myheat = ReturnHeat(Trim(txtWheelNumber.Text.Trim))
        Dim str As String = metLab.tables.getLabNo(mywheel, myheat)
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=19136&user0=sa&password0=sadev123&promptonrefresh=0&prompt0=" & str.Trim & ""
        Response.Redirect(strPathName)
    End Sub

    Private Sub ddlWheelNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlWheelNumber.SelectedIndexChanged
        txtWheelNumber.Text = ddlWheelNumber.SelectedItem.Text.Trim
    End Sub
End Class
