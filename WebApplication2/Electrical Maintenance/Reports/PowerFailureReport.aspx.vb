Public Class PowerFailureReport
    Inherits System.Web.UI.Page
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button
    Protected WithEvents ddlMonth As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlYear As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents btnYear As System.Web.UI.WebControls.Button
    Protected WithEvents ToMonth As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ToYear As System.Web.UI.WebControls.DropDownList
    Protected WithEvents FromMonth As System.Web.UI.WebControls.DropDownList
    Protected WithEvents FromYear As System.Web.UI.WebControls.DropDownList
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
        'Put user code to initialize the page here
        If Not IsPostBack Then
            getYears()
        End If
    End Sub
    Sub getYears()
        Dim ds As New DataSet()
        Dim dt As New DataTable()
        Try
            ds = Maintenance.ElecTables.getMonthYear("ms_power_failure", "failure_date")
            ddlMonth.DataSource = ds.Tables(0)
            ddlMonth.DataTextField = ds.Tables(0).Columns(1).ColumnName
            ddlMonth.DataValueField = ds.Tables(0).Columns(0).ColumnName
            ddlMonth.DataBind()

            FromMonth.DataSource = ds.Tables(0)
            FromMonth.DataTextField = ds.Tables(0).Columns(1).ColumnName
            FromMonth.DataValueField = ds.Tables(0).Columns(0).ColumnName
            FromMonth.DataBind()

            ToMonth.DataSource = ds.Tables(0)
            ToMonth.DataTextField = ds.Tables(0).Columns(1).ColumnName
            ToMonth.DataValueField = ds.Tables(0).Columns(0).ColumnName
            ToMonth.DataBind()

            dt = ds.Tables(1)
            ddlYear.DataSource = dt
            ddlYear.DataTextField = dt.Columns(0).ColumnName
            ddlYear.DataValueField = dt.Columns(0).ColumnName
            ddlYear.DataBind()
            ddlMonth.SelectedIndex = Now.Month - 1
            FromYear.DataSource = dt
            FromYear.DataTextField = dt.Columns(0).ColumnName
            FromYear.DataValueField = dt.Columns(0).ColumnName
            FromYear.DataBind()
            FromMonth.SelectedIndex = Now.Month - 1
            ToYear.DataSource = dt
            ToYear.DataTextField = dt.Columns(0).ColumnName
            ToYear.DataValueField = dt.Columns(0).ColumnName
            ToYear.DataBind()
            ToMonth.SelectedIndex = Now.Month - 1
        Catch exp As Exception
            dt = Nothing
            lblMessage.Text = exp.Message
        Finally
            ' dt.Dispose()
            ds.Dispose()
        End Try
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim yea As Int16
        Dim mon As Int16
        mon = ddlMonth.SelectedItem.Value
        yea = ddlYear.SelectedItem.Text
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?id=15965&apsuser=Administrator&apspassword=Cris@123&apsauthtype=secEnterprise&user0=sa&password0=sadev123&promptonrefresh=0 &prompt0=" & yea & "&prompt1=" & mon & ""
        Response.Redirect(strPathName)
    End Sub

    Private Sub btnYear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnYear.Click
        'ToYear.SelectedItem.Value + ToMonth.SelectedItem.Value
        Dim FromYearValue, ToYearValue As String
        FromYearValue = CStr(FromYear.SelectedItem.Value) + IIf(FromMonth.SelectedItem.Value.Length = 1, "0" + CStr(FromMonth.SelectedItem.Value), CStr(FromMonth.SelectedItem.Value))
        ToYearValue = CStr(ToYear.SelectedItem.Value) + IIf(ToMonth.SelectedItem.Value.Length = 1, "0" + CStr(ToMonth.SelectedItem.Value), CStr(FromMonth.SelectedItem.Value))
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?id=18702&apsuser=Administrator&apspassword=Cris@123&apsauthtype=secEnterprise&user0=sa&password0=sadev123&promptonrefresh=0 &prompt0=" & FromYearValue.Trim & "&prompt1=" & ToYearValue.Trim & ""
        Response.Redirect(strPathName)
    End Sub
End Class
