Public Class ShpFlrGndBal
    Inherits System.Web.UI.Page
    Protected WithEvents BtnShow As System.Web.UI.WebControls.Button
    Protected WithEvents cboCode As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblConsignee As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents rblYear As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents Panel2 As System.Web.UI.WebControls.Panel
    Protected WithEvents btnPCDO As System.Web.UI.WebControls.Button
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents rblMonth As System.Web.UI.WebControls.RadioButtonList
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

    'Public Sub New()

    '    AddHandler PreInit, New EventHandler(AddressOf Page_PreInit)
    'End Sub

    'Private Sub Page_PreInit(ByVal sender As Object, ByVal e As EventArgs)

    '    Page.Theme = themeValue
    'End Sub


    'Protected Sub Dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
    '    themeValue = Dd1.SelectedItem.Value
    '    Response.Redirect(Request.Url.ToString())

    'End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Panel1.Visible = True
        lblConsignee.Visible = False
        cboCode.Enabled = False
        If Not Page.IsPostBack Then
            Session("UserID") = "111111"
            'Session("Group") = "MLDING"
            Session("Group") = "WHLMLT"
            Dim dt As DataTable
            dt = RWF.tables.ShopCodes(Session("Group"))
            lblConsignee.Text = dt.Rows(0)("Consignee")
            populate_Code()
            dt = Nothing
        End If
    End Sub

    Private Sub populate_Code()
        Dim ds As DataSet
        Try
            ds = PCO.tables.GetShopCodes(lblConsignee.Text.Trim)
            cboCode.DataSource = ds.Tables(0)
            cboCode.DataTextField = ds.Tables(0).Columns("stnid_desc").ColumnName
            cboCode.DataValueField = ds.Tables(0).Columns("stn_id").ColumnName
            cboCode.DataBind()
            rblYear.DataSource = ds.Tables(1)
            rblYear.DataTextField = ds.Tables(1).Columns("ConsumedYear").ColumnName
            rblYear.DataValueField = ds.Tables(1).Columns("ConsumedYear").ColumnName
            rblYear.DataBind()
            rblMonth.DataSource = ds.Tables(2)
            rblMonth.DataTextField = ds.Tables(2).Columns("MName").ColumnName
            rblMonth.DataValueField = ds.Tables(2).Columns("MNo").ColumnName
            rblMonth.DataBind()
            Dim i As Int16
            rblYear.SelectedIndex = 0
            i = 0
            rblMonth.ClearSelection()
            For i = 0 To rblMonth.Items.Count - 1
                If rblMonth.Items(i).Value = ds.Tables(3).Rows(0)(0) Then
                    rblMonth.Items(i).Selected = True
                    Exit For
                End If
            Next
            i = Nothing
            Panel2.Visible = False
            If lblConsignee.Text = "MEME" Then
                Panel2.Visible = True
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            ds = Nothing
        End Try
    End Sub

    Private Sub BtnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShow.Click
        Dim strPathName, rptName As String
        rptName = "mm_shop_ground_balance_sheet"
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?id=24966&apsuser=Administrator&apspassword=Cris@123&apsauthtype=secEnterprise&user0=sa&password0=sadev123&promptonrefresh=0"
        strPathName &= "&promptex0=" & Val(rblMonth.SelectedItem.Value)
        strPathName &= "&promptex1=" & rblYear.SelectedItem.Text.Trim
        strPathName &= "&promptex2=" & cboCode.SelectedItem.Value
        Response.Redirect(strPathName)
    End Sub

    Private Sub btnPCDO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPCDO.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?id=16985&apsuser=Administrator&apspassword=Cris@123&apsauthtype=secEnterprise&user0=sa&password0=sadev123&promptonrefresh=0" &
                      "&prompt0=" & rblYear.SelectedItem.Text.Trim + rblMonth.SelectedItem.Value.Trim &
                      "&prompt1=1"

        '"&user0@PCDO2.rpt=report&password0@PCDO2.rpt=report" &
        '"&user0@PCDO3.rpt=report&password0@PCDO3.rpt=report" &
        '"&user0@PCDO4.rpt=report&password0@PCDO4.rpt=report" &
        '"&user0@PCDO5.rpt=report&password0@PCDO5.rpt=report" &
        '"&user0@PCDO6.rpt=report&password0@PCDO6.rpt=report" &
        '"&user0@PCDO7.rpt=report&password0@PCDO7.rpt=report" &
        '"&user0@PCDO8.rpt=report&password0@PCDO8.rpt=report" &

        Response.Redirect(strPathName)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim strServer, strPathName, rptName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?id=16572&apsuser=Administrator&apspassword=Cris@123&apsauthtype=secEnterprise&user0=sa&password0=sadev123&promptonrefresh=0" &
                    "&prompt0=" & rblYear.SelectedItem.Text.Trim + rblMonth.SelectedItem.Value.Trim &
                    "&prompt1=0"
        Response.Redirect(strPathName)
    End Sub
End Class
