Public Class HSD
    Inherits System.Web.UI.Page
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents ConsumptionDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents LPH As System.Web.UI.WebControls.TextBox
    Protected WithEvents NF As System.Web.UI.WebControls.TextBox
    Protected WithEvents DF As System.Web.UI.WebControls.TextBox
    Protected WithEvents SP As System.Web.UI.WebControls.TextBox
    Protected WithEvents AxleShop As System.Web.UI.WebControls.TextBox
    Protected WithEvents RTShop As System.Web.UI.WebControls.TextBox
    Protected WithEvents DG As System.Web.UI.WebControls.TextBox
    Protected WithEvents Save As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Remarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnEnergy As System.Web.UI.WebControls.Button
    Protected WithEvents Wheel As System.Web.UI.WebControls.TextBox
    Protected WithEvents HubCut As System.Web.UI.WebControls.TextBox
    Protected WithEvents BilletCut As System.Web.UI.WebControls.TextBox
    Protected WithEvents AxleEndCut As System.Web.UI.WebControls.TextBox
    Protected WithEvents PCBay As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
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
        If IsPostBack = False Then
            ConsumptionDate.Text = Now.Date
            Try
                GetData()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub GetData()
        btnEnergy.Text = "RWF Energy Report as on " & CDate(ConsumptionDate.Text)
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Dim dt As DataTable
        Try
            dt = UtilityShop.DataTables.NewHSD(CDate(ConsumptionDate.Text))
            If dt.Rows.Count > 0 Then
                DataGrid1.DataSource = dt
                DataGrid1.DataBind()
                LPH.Text = IIf(IsDBNull(dt.Rows(0)(0)), 0, dt.Rows(0)(0))
                NF.Text = IIf(IsDBNull(dt.Rows(0)(1)), 0, dt.Rows(0)(1))
                DF.Text = IIf(IsDBNull(dt.Rows(0)(2)), 0, dt.Rows(0)(2))
                SP.Text = IIf(IsDBNull(dt.Rows(0)(3)), 0, dt.Rows(0)(3))
                AxleShop.Text = IIf(IsDBNull(dt.Rows(0)(4)), 0, dt.Rows(0)(4))
                RTShop.Text = IIf(IsDBNull(dt.Rows(0)(5)), 0, dt.Rows(0)(5))
                DG.Text = IIf(IsDBNull(dt.Rows(0)(6)), 0, dt.Rows(0)(6))
                Remarks.Text = IIf(IsDBNull(dt.Rows(0)(7)), "", dt.Rows(0)(7))
                Wheel.Text = IIf(IsDBNull(dt.Rows(0)(8)), 0, dt.Rows(0)(8))
                HubCut.Text = IIf(IsDBNull(dt.Rows(0)(9)), 0, dt.Rows(0)(9))
                BilletCut.Text = IIf(IsDBNull(dt.Rows(0)(10)), 0, dt.Rows(0)(10))
                AxleEndCut.Text = IIf(IsDBNull(dt.Rows(0)(11)), 0, dt.Rows(0)(11))
                PCBay.Text = IIf(IsDBNull(dt.Rows(0)(12)), 0, dt.Rows(0)(12))
            End If
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            dt.Dispose()
        End Try
    End Sub

    Private Sub ConsumptionDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsumptionDate.TextChanged
        lblMessage.Text = ""
        Try
            GetData()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save.Click
        lblMessage.Text = ""
        Try
            lblMessage.Text = New UtilityShop.FlowMeter().SaveNewHSD(CDate(ConsumptionDate.Text), Val(LPH.Text), Val(NF.Text), Val(DF.Text), Val(SP.Text), Val(AxleShop.Text), Val(RTShop.Text), Val(DG.Text), Remarks.Text.Trim, Val(Wheel.Text), Val(HubCut.Text), Val(BilletCut.Text), Val(AxleEndCut.Text), Val(PCBay.Text))
            GetData()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnEnergy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnergy.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=27519&user0=sa&password0=sadev123" &
        "&prompt0=DateTime(" & CDate(ConsumptionDate.Text).Year & "," & CDate(ConsumptionDate.Text).Month & "," & CDate(ConsumptionDate.Text).Day & " ,0,0,0)"
        Response.Redirect(strPathName)
    End Sub
End Class
