Public Class ToolsHistoryCard
    Inherits System.Web.UI.Page
    Protected WithEvents cboIns As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents Submit As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents ddlDeletedHC As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button
    Protected WithEvents Panel2 As System.Web.UI.WebControls.Panel
    Protected WithEvents BTNInHouse As System.Web.UI.WebControls.Button
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtToDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFromDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
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
        If Not IsPostBack Then
            Try
                txtFromDate.Text = ToolRoom.Tables.GetTopCalibrationDate
                txtToDate.Text = ToolRoom.Tables.GetTopCalibrationDate
                Dim dt As DataTable = ToolRoom.Tables.GetHistoryCards 'GetHistoryCardsDeleted
                cboIns.DataSource = dt
                cboIns.DataTextField = dt.Columns(0).ColumnName
                cboIns.DataValueField = dt.Columns(0).ColumnName
                cboIns.DataBind()
                dt = ToolRoom.Tables.GetHistoryCardsDeleted
                ddlDeletedHC.DataSource = dt
                ddlDeletedHC.DataTextField = dt.Columns(0).ColumnName
                ddlDeletedHC.DataValueField = dt.Columns(0).ColumnName
                ddlDeletedHC.DataBind()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub Submit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Submit.Click
        ShowReport()
    End Sub

    Private Sub ShowReport()
        Dim strPathName, strServer As String
        Dim cntRec As Integer

        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&apsauthtype=secEnterprise&id=27485&user0=sa&password0=sadev123&promptonrefresh=0&prompt0=" & Trim(cboIns.SelectedItem.Text) & "&promptonrefresh=0"
        Response.Redirect(strPathName)
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ds As DataSet
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        Try
            ds = ToolRoom.Tables.ToolHistory(cboIns.SelectedItem.Text.Trim)
            DataGrid1.DataSource = ds.Tables(0)
            DataGrid1.DataBind()
            DataGrid2.DataSource = ds.Tables(1)
            DataGrid2.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub cboIns_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboIns.SelectedIndexChanged
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim ds As DataSet
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        Try
            ds = ToolRoom.Tables.ToolHistoryDeleted(ddlDeletedHC.SelectedItem.Text.Trim)
            DataGrid1.DataSource = ds.Tables(0)
            DataGrid1.DataBind()
            DataGrid2.DataSource = ds.Tables(1)
            DataGrid2.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub ddlDeletedHC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlDeletedHC.SelectedIndexChanged
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
    End Sub

    Private Sub BTNInHouse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNInHouse.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=19490&user0=sa&password0=sadev123"
        strPathName &= "&prompt0=DateTime(" & CDate(txtFromDate.Text).Year & "," & CDate(txtFromDate.Text).Month & "," & CDate(txtFromDate.Text).Day & ", 00, 00, 00)"
        strPathName &= "&prompt1=DateTime(" & CDate(txtToDate.Text).Year & "," & CDate(txtToDate.Text).Month & "," & CDate(txtToDate.Text).Day & ", 00, 00, 00)"
        Response.Redirect(strPathName)
    End Sub
End Class
