Public Class WFPSSummary
    Inherits System.Web.UI.Page
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnShow As System.Web.UI.WebControls.Button
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid3 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid4 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid5 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid6 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid7 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid8 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid9 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid10 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid11 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid12 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid13 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid14 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid15 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid16 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid17 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid18 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid19 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid20 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid21 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid22 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid23 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid24 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid25 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid26 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid27 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
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
    Protected Sub dd1_SelectedIndexChanged(sender As Object, e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If IsPostBack = False Then
            txtDate.Text = Now.Date
        End If
    End Sub

    Private Sub Clear()
        lblMessage.Text = ""
        DataGrid1.DataSource = Nothing
        DataGrid2.DataSource = Nothing
        DataGrid3.DataSource = Nothing
        DataGrid4.DataSource = Nothing
        DataGrid5.DataSource = Nothing
        DataGrid6.DataSource = Nothing
        DataGrid7.DataSource = Nothing
        DataGrid8.DataSource = Nothing
        DataGrid9.DataSource = Nothing
        DataGrid10.DataSource = Nothing
        DataGrid11.DataSource = Nothing
        DataGrid12.DataSource = Nothing
        DataGrid13.DataSource = Nothing
        DataGrid14.DataSource = Nothing
        DataGrid15.DataSource = Nothing
        DataGrid16.DataSource = Nothing
        DataGrid17.DataSource = Nothing
        DataGrid18.DataSource = Nothing
        DataGrid19.DataSource = Nothing
        DataGrid20.DataSource = Nothing
        DataGrid21.DataSource = Nothing
        DataGrid22.DataSource = Nothing
        DataGrid23.DataSource = Nothing
        DataGrid24.DataSource = Nothing
        DataGrid25.DataSource = Nothing
        DataGrid26.DataSource = Nothing
        DataGrid27.DataSource = Nothing

        DataGrid1.DataBind()
        DataGrid2.DataBind()
        DataGrid3.DataBind()
        DataGrid4.DataBind()
        DataGrid5.DataBind()
        DataGrid6.DataBind()
        DataGrid7.DataBind()
        DataGrid8.DataBind()
        DataGrid9.DataBind()
        DataGrid10.DataBind()
        DataGrid11.DataBind()
        DataGrid12.DataBind()
        DataGrid13.DataBind()
        DataGrid14.DataBind()
        DataGrid15.DataBind()
        DataGrid16.DataBind()
        DataGrid17.DataBind()
        DataGrid18.DataBind()
        DataGrid19.DataBind()
        DataGrid20.DataBind()
        DataGrid21.DataBind()
        DataGrid22.DataBind()
        DataGrid23.DataBind()
        DataGrid24.DataBind()
        DataGrid25.DataBind()
        DataGrid26.DataBind()
        DataGrid27.DataBind()
    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        Clear()
        Dim ds As DataSet
        Try
            ds = RWF.WFPSQuerry.WFPSSummary(CDate(txtDate.Text))
            DataGrid1.DataSource = ds.Tables(0)
            DataGrid2.DataSource = ds.Tables(1)
            DataGrid3.DataSource = ds.Tables(2)
            DataGrid4.DataSource = ds.Tables(3)
            DataGrid5.DataSource = ds.Tables(4)
            DataGrid6.DataSource = ds.Tables(5)
            DataGrid7.DataSource = ds.Tables(6)
            DataGrid8.DataSource = ds.Tables(7)
            DataGrid9.DataSource = ds.Tables(8)
            DataGrid10.DataSource = ds.Tables(9)
            DataGrid11.DataSource = ds.Tables(10)
            DataGrid12.DataSource = ds.Tables(11)
            DataGrid13.DataSource = ds.Tables(12)
            DataGrid14.DataSource = ds.Tables(13)
            DataGrid15.DataSource = ds.Tables(14)
            DataGrid16.DataSource = ds.Tables(15)
            DataGrid17.DataSource = ds.Tables(16)
            DataGrid18.DataSource = ds.Tables(17)
            DataGrid19.DataSource = ds.Tables(18)
            DataGrid20.DataSource = ds.Tables(19)
            DataGrid21.DataSource = ds.Tables(20)
            DataGrid22.DataSource = ds.Tables(21)
            DataGrid21.DataSource = ds.Tables(22)
            DataGrid22.DataSource = ds.Tables(23)
            DataGrid23.DataSource = ds.Tables(24)
            DataGrid24.DataSource = ds.Tables(25)
            DataGrid25.DataSource = ds.Tables(26)

            DataGrid1.DataBind()
            DataGrid2.DataBind()
            DataGrid3.DataBind()
            DataGrid4.DataBind()
            DataGrid5.DataBind()
            DataGrid6.DataBind()
            DataGrid7.DataBind()
            DataGrid8.DataBind()
            DataGrid9.DataBind()
            DataGrid10.DataBind()
            DataGrid11.DataBind()
            DataGrid12.DataBind()
            DataGrid13.DataBind()
            DataGrid14.DataBind()
            DataGrid15.DataBind()
            DataGrid16.DataBind()
            DataGrid17.DataBind()
            DataGrid18.DataBind()
            DataGrid19.DataBind()
            DataGrid20.DataBind()
            DataGrid21.DataBind()
            DataGrid22.DataBind()
            DataGrid23.DataBind()
            DataGrid24.DataBind()
            DataGrid25.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub


End Class
