Public Class MRSMouldCampaign
    Inherits System.Web.UI.Page
    Protected WithEvents CampaignDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents UsableCopes1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents UsableCopes2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents UsableDrags1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents UsableDrags2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents ShortfallCopes1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents ShortfallCopes2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents ShortfallDrags1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents ShortfallDrags2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Remarks1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Remarks2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
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
        If Page.IsPostBack = False Then
            CampaignDate.Text = Now.Date
            Try
                GetData()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
    Private Sub clear()
        UsableCopes1.Text = 0
        UsableCopes2.Text = 0
        UsableDrags1.Text = 0
        UsableDrags2.Text = 0
        ShortfallCopes1.Text = 0
        ShortfallCopes2.Text = 0
        ShortfallDrags1.Text = 0
        ShortfallDrags2.Text = 0
        Remarks1.Text = ""
        Remarks2.Text = ""
    End Sub

    Private Sub CampaignDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CampaignDate.TextChanged
        lblMessage.Text = ""
        Dim dt As Date
        Try
            dt = CDate(CampaignDate.Text)
            If dt > Now.Date Then
                lblMessage.Text = "Future date not allowed "
                CampaignDate.Text = ""
            Else
                CampaignDate.Text = dt
                GetData()
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt = Nothing
        End Try
    End Sub
    Private Sub GetData()
        clear()
        Dim dt As DataTable
        dt = MouldMaster.tables.getMRSMouldCampaign(CDate(CampaignDate.Text))
        Try
            If dt.Rows.Count > 0 Then
                If Trim(dt.Rows(0)("Product")) = "BGC" Then
                    UsableCopes2.Text = IIf(IsDBNull(dt.Rows(0)("UsableCopes")), 0, dt.Rows(0)("UsableCopes"))
                    UsableDrags2.Text = IIf(IsDBNull(dt.Rows(0)("UsableDrags")), 0, dt.Rows(0)("UsableDrags"))
                    ShortfallCopes2.Text = IIf(IsDBNull(dt.Rows(0)("ShortfallCopes")), 0, dt.Rows(0)("ShortfallCopes"))
                    ShortfallDrags2.Text = IIf(IsDBNull(dt.Rows(0)("ShortfallDrags")), 0, dt.Rows(0)("ShortfallDrags"))
                    Remarks2.Text = IIf(IsDBNull(dt.Rows(0)("Remarks")), "", dt.Rows(0)("Remarks"))
                End If
                If Trim(dt.Rows(1)("Product")) = "BoxN" Then
                    UsableCopes1.Text = IIf(IsDBNull(dt.Rows(1)("UsableCopes")), 0, dt.Rows(1)("UsableCopes"))
                    UsableDrags1.Text = IIf(IsDBNull(dt.Rows(1)("UsableDrags")), 0, dt.Rows(1)("UsableDrags"))
                    ShortfallCopes1.Text = IIf(IsDBNull(dt.Rows(1)("ShortfallCopes")), 0, dt.Rows(1)("ShortfallCopes"))
                    ShortfallDrags1.Text = IIf(IsDBNull(dt.Rows(1)("ShortfallDrags")), 0, dt.Rows(1)("ShortfallDrags"))
                    Remarks1.Text = IIf(IsDBNull(dt.Rows(1)("Remarks")), "", dt.Rows(1)("Remarks"))
                End If
            Else
                dt = MouldMaster.tables.getMROutTurnMRS
                If Trim(dt.Rows(0)("Product")) = "BOXN WHL" Then
                    UsableCopes1.Text = IIf(IsDBNull(dt.Rows(0)("UsableCopes")), 0, dt.Rows(0)("UsableCopes"))
                    UsableDrags1.Text = IIf(IsDBNull(dt.Rows(0)("UsableDrags")), 0, dt.Rows(0)("UsableDrags"))
                    ShortfallCopes1.Text = IIf(IsDBNull(dt.Rows(0)("ShortfallCopes")), 0, dt.Rows(0)("ShortfallCopes"))
                    ShortfallDrags1.Text = IIf(IsDBNull(dt.Rows(0)("ShortfallDrags")), 0, dt.Rows(0)("ShortfallDrags"))
                End If
                If Trim(dt.Rows(1)("Product")) = "ICF WHL" Then
                    UsableCopes2.Text = IIf(IsDBNull(dt.Rows(1)("UsableCopes")), 0, dt.Rows(1)("UsableCopes"))
                    UsableDrags2.Text = IIf(IsDBNull(dt.Rows(1)("UsableDrags")), 0, dt.Rows(1)("UsableDrags"))
                    ShortfallCopes2.Text = IIf(IsDBNull(dt.Rows(1)("ShortfallCopes")), 0, dt.Rows(1)("ShortfallCopes"))
                    ShortfallDrags2.Text = IIf(IsDBNull(dt.Rows(1)("ShortfallDrags")), 0, dt.Rows(1)("ShortfallDrags"))
                End If
            End If
        Catch exp As Exception
            lblMessage.Text = "Data Filling  Failed : " & exp.Message
        Finally
            dt.Dispose()
            dt = Nothing
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        Dim Done As Boolean
        Try
            Done = New MouldMaster.MRSMRS().AddMRS(CDate(CampaignDate.Text), Val(UsableCopes1.Text), Val(UsableDrags1.Text), Val(ShortfallCopes1.Text), Val(ShortfallDrags1.Text), Remarks1.Text.Trim, Val(UsableCopes2.Text), Val(UsableDrags2.Text), Val(ShortfallCopes2.Text), Val(ShortfallDrags2.Text), Remarks2.Text.Trim)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            If Done Then
                lblMessage.Text = " Updation Successful !"
                clear()
            Else
                lblMessage.Text &= " Updation Failed ! "
            End If
        End Try
        Done = Nothing
    End Sub
End Class
