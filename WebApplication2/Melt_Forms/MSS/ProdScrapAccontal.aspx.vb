Public Class ProdScrapAccontal
    Inherits System.Web.UI.Page
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents TxtUsageDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents Panel2 As System.Web.UI.WebControls.Panel
    Protected WithEvents TxtMRXC As System.Web.UI.WebControls.TextBox
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblCOB As System.Web.UI.WebControls.Label
    Protected WithEvents lblLOB As System.Web.UI.WebControls.Label
    Protected WithEvents lblRHOB As System.Web.UI.WebControls.Label
    'Protected WithEvents lblAEOB As System.Web.UI.WebControls.Label
    'Protected WithEvents lblRCOB As System.Web.UI.WebControls.Label
    Protected WithEvents lblWCOB As System.Web.UI.WebControls.Label
    Protected WithEvents lblCR As System.Web.UI.WebControls.Label
    Protected WithEvents TxtLU As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblLR As System.Web.UI.WebControls.Label
    Protected WithEvents TxtRHU As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblRHR As System.Web.UI.WebControls.Label
    'Protected WithEvents TxtAEU As System.Web.UI.WebControls.TextBox
    'Protected WithEvents lblAER As System.Web.UI.WebControls.Label
    Protected WithEvents TxtRCU As System.Web.UI.WebControls.TextBox
    'Protected WithEvents lblRCR As System.Web.UI.WebControls.Label
    Protected WithEvents TxtWCU As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblWCR As System.Web.UI.WebControls.Label
    Protected WithEvents TxtCU As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblOB As System.Web.UI.WebControls.Label
    Protected WithEvents lbl As System.Web.UI.WebControls.Label
    Protected WithEvents lblDate As System.Web.UI.WebControls.Label
    Protected WithEvents TxtMRRisersHub As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    'Protected WithEvents TxtPRU As System.Web.UI.WebControls.TextBox
    'Protected WithEvents lblPRR As System.Web.UI.WebControls.Label
    'Protected WithEvents lblPROB As System.Web.UI.WebControls.Label
    Protected WithEvents lblAvg As System.Web.UI.WebControls.Label
    Protected WithEvents lblTU As System.Web.UI.WebControls.Label
    Protected WithEvents lblTR As System.Web.UI.WebControls.Label
    Protected WithEvents lblTOB As System.Web.UI.WebControls.Label
    Protected WithEvents lblC As System.Web.UI.WebControls.Label
    Protected WithEvents lblH As System.Web.UI.WebControls.Label
    Protected WithEvents Panel3 As System.Web.UI.WebControls.Panel
    Protected WithEvents lblConsignee As System.Web.UI.WebControls.Label
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


    Protected Sub Dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        'Put user code to initialize the page here
        If IsPostBack = False Then
            Dim Group As String = Session("Group")
            Dim UserId As String = Session("UserID")
            Dim InValid As Boolean = False
            ''''''''''''''''
            'Group = "SSMELT"
            'UserId = "074510"
            ''''''''''''''''
            Try
                lblConsignee.Text = ProductionConsumables.GetConsignee(Group, UserId)
                If lblConsignee.Text.Trim.Length = 4 Then InValid = True
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            'If Not InValid Then
            '    Response.Redirect("/mss/logon.aspx")
            'Else
            Try
                    TxtUsageDate.Text = ProductionConsumables.GetTopAccontalDate
                    SetPanel()
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                End Try
                If IIf(IsDBNull(ProductionConsumables.ScrapReceipt(CDate(TxtUsageDate.Text))), 0, ProductionConsumables.ScrapReceipt(CDate(TxtUsageDate.Text))) = 0 Then lblMessage.Text &= "Scrap Receipt not posted for the given date !"
            End If
        'End If
    End Sub


    Private Sub ClearLbl()
        lblH.Text = ""
        lblC.Text = ""
        lblWCR.Text = ""
        lblWCOB.Text = ""
        'lblRCOB.Text = ""
        'lblAER.Text = ""
        'lblAEOB.Text = ""
        ' lblPRR.Text = ""
        'lblPROB.Text = ""
        lblRHR.Text = ""
        'lblRCR.Text = ""
        lblRHOB.Text = ""
        lblLR.Text = ""
        lblLOB.Text = ""
        lblCR.Text = ""
        lblCOB.Text = ""
        lblTR.Text = ""
        lblTU.Text = ""
        lblTOB.Text = ""
    End Sub

    Private Sub ClearTxt()
        TxtWCU.Text = ""
        'TxtRCU.Text = ""
        'TxtAEU.Text = ""
        'TxtRHU.Text = ""
        TxtLU.Text = ""
        TxtCU.Text = ""
    End Sub

    Private Sub SetPanel()
        Panel2.Visible = False
        Panel3.Visible = False
        lblOB.Visible = False
        ClearTxt()
        ClearLbl()
        If rblType.SelectedIndex = 0 Then
            Panel3.Visible = True
            lblOB.Visible = True
            lbl.Text = "Usage"
            lblDate.Text = "Accountal"
            GetAccountalData()
        Else
            Panel2.Visible = True
            lbl.Text = "ClosingBal"
            lblDate.Text = "ClosingBal"
            lbl.ForeColor = System.Drawing.Color.Red
            GetAccountalCBData()
            lblMessage.Text &= " Please provide Riser & Hub Weight along with MRXC Wheel Weight and rest Items as CB instead of Usage "
        End If
    End Sub

    Private Sub GetAccountalData()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            Dim dt1, dt2, dt3 As DataTable
            dt1 = ProductionConsumables.ScrapAccontal(CDate(TxtUsageDate.Text))
            DataGrid1.DataSource = dt1
            DataGrid1.DataBind()
            dt1 = Nothing
            dt2 = ProductionConsumables.ScrapAccontalReceipt(CDate(TxtUsageDate.Text))
            If dt2.Rows.Count > 0 Then
                lblWCR.Text = IIf(IsDBNull(dt2.Rows(0)("RWheelCut")), "", dt2.Rows(0)("RWheelCut"))
                'lblRCR.Text = IIf(IsDBNull(dt2.Rows(0)("RRailCut")), "", dt2.Rows(0)("RRailCut"))
                'lblAER.Text = IIf(IsDBNull(dt2.Rows(0)("RAxleEndCut")), "", dt2.Rows(0)("RAxleEndCut"))
                lblLR.Text = IIf(IsDBNull(dt2.Rows(0)("RLMS")), "", dt2.Rows(0)("RLMS"))
                lblCR.Text = IIf(IsDBNull(dt2.Rows(0)("RChipsAMSCR")), "", dt2.Rows(0)("RChipsAMSCR"))
                'lblPRR.Text = IIf(IsDBNull(dt2.Rows(0)("RPRS")), "", dt2.Rows(0)("RPRS"))
                lblTR.Text = IIf(IsDBNull(dt2.Rows(0)("TotalR")), "", dt2.Rows(0)("TotalR"))
                TxtWCU.Text = IIf(IsDBNull(dt2.Rows(0)("WheelCut")), "", dt2.Rows(0)("WheelCut"))
                ' TxtRCU.Text = IIf(IsDBNull(dt2.Rows(0)("RailCut")), "", dt2.Rows(0)("RailCut"))
                'TxtAEU.Text = IIf(IsDBNull(dt2.Rows(0)("AxleEndCut")), "", dt2.Rows(0)("AxleEndCut"))
                TxtRHU.Text = IIf(IsDBNull(dt2.Rows(0)("RisersHub")), "", dt2.Rows(0)("RisersHub"))
                TxtLU.Text = IIf(IsDBNull(dt2.Rows(0)("LMS")), "", dt2.Rows(0)("LMS"))
                TxtCU.Text = IIf(IsDBNull(dt2.Rows(0)("ChipsAMSCR")), "", dt2.Rows(0)("ChipsAMSCR"))
                ' TxtPRU.Text = IIf(IsDBNull(dt2.Rows(0)("ProScrap")), "", dt2.Rows(0)("ProScrap"))
                lblTU.Text = IIf(IsDBNull(dt2.Rows(0)("TotalU")), "", dt2.Rows(0)("TotalU"))
            End If
            dt3 = ProductionConsumables.ScrapAccontalData(CDate(TxtUsageDate.Text))
            If dt3.Rows.Count > 0 Then
                lblH.Text = IIf(IsDBNull(dt3.Rows(0)("DayHeats")), "", dt3.Rows(0)("DayHeats"))
                lblC.Text = IIf(IsDBNull(dt3.Rows(0)("DayCastWheels")), "", dt3.Rows(0)("DayCastWheels"))
                lblWCOB.Text = IIf(IsDBNull(dt3.Rows(0)("WheelCutOB")), "", dt3.Rows(0)("WheelCutOB"))
                'lblRCOB.Text = IIf(IsDBNull(dt3.Rows(0)("RailCutOB")), "", dt3.Rows(0)("RailCutOB"))
                'lblAEOB.Text = IIf(IsDBNull(dt3.Rows(0)("AxleEndCutOB")), "", dt3.Rows(0)("AxleEndCutOB"))
                'lblPROB.Text = IIf(IsDBNull(dt3.Rows(0)("ProScrapOB")), "", dt3.Rows(0)("ProScrapOB"))
                lblRHR.Text = IIf(IsDBNull(dt3.Rows(0)("DayHeats")), 0, dt3.Rows(0)("DayHeats")) * IIf(IsDBNull(dt3.Rows(0)("RisersHubRate")), 0, dt3.Rows(0)("RisersHubRate"))
                lblRHOB.Text = IIf(IsDBNull(dt3.Rows(0)("RisersHubOB")), "", dt3.Rows(0)("RisersHubOB"))
                lblLOB.Text = IIf(IsDBNull(dt3.Rows(0)("LMSOB")), "", dt3.Rows(0)("LMSOB"))
                lblCOB.Text = IIf(IsDBNull(dt3.Rows(0)("ChipsAMSCROB")), "", dt3.Rows(0)("ChipsAMSCROB"))
                lblTOB.Text = IIf(IsDBNull(dt3.Rows(0)("TotalOB")), "", dt3.Rows(0)("TotalOB"))
            End If
            If Val(lblH.Text) > 0 Then
                lblAvg.Text = Val(lblTU.Text) / Val(lblH.Text)
                lblAvg.Text = CDec(Val(lblAvg.Text)).Round(CDec(Val(lblAvg.Text)), 2)
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub GetAccountalCBData()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            Dim dt As DataTable
            dt = ProductionConsumables.ScrapAccontalCB(CDate(TxtUsageDate.Text))
            DataGrid1.DataSource = dt
            DataGrid1.DataBind()
            If dt.Rows.Count > 0 Then
                TxtWCU.Text = IIf(IsDBNull(dt.Rows(0)("WheelCut")), "", dt.Rows(0)("WheelCut"))
                'TxtRCU.Text = IIf(IsDBNull(dt.Rows(0)("RailCut")), "", dt.Rows(0)("RailCut"))
                'TxtAEU.Text = IIf(IsDBNull(dt.Rows(0)("AxleEndCut")), "", dt.Rows(0)("AxleEndCut"))
                'TxtPRU.Text = IIf(IsDBNull(dt.Rows(0)("ProScrap")), "", dt.Rows(0)("ProScrap"))
                TxtRHU.Text = IIf(IsDBNull(dt.Rows(0)("RisersHub")), "", dt.Rows(0)("RisersHub"))
                TxtLU.Text = IIf(IsDBNull(dt.Rows(0)("LMS")), "", dt.Rows(0)("LMS"))
                TxtCU.Text = IIf(IsDBNull(dt.Rows(0)("ChipsAMSCR")), "", dt.Rows(0)("ChipsAMSCR"))
                TxtMRXC.Text = IIf(IsDBNull(dt.Rows(0)("MRXCWheel")), "", dt.Rows(0)("MRXCWheel"))
                TxtMRRisersHub.Text = IIf(IsDBNull(dt.Rows(0)("MRRisersHub")), "", dt.Rows(0)("MRRisersHub"))
            End If
            dt = Nothing
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub rblType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblType.SelectedIndexChanged
        lblMessage.Text = ""
        SetPanel()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        If rblType.SelectedIndex = 0 Then
            If Val(lblH.Text) = 0 Then
                lblMessage.Text = "InValid Date !"
                Exit Sub
            End If
        End If
        Dim done As Boolean
        If rblType.SelectedIndex = 0 Then
            done = New ProductionConsumables().SaveScrapAccontal(CDate(TxtUsageDate.Text), Val(TxtWCU.Text), Val(TxtRHU.Text), Val(TxtLU.Text), Val(TxtCU.Text))
        Else
            done = New ProductionConsumables().SaveScrapAccontalCB(CDate(TxtUsageDate.Text), Val(TxtWCU.Text), Val(TxtRHU.Text), Val(TxtLU.Text), Val(TxtCU.Text), Val(TxtMRXC.Text), Val(TxtMRRisersHub.Text))
            If done Then
                done = New ProductionConsumables().SaveScrapAccontalReverseUpdate(CDate(TxtUsageDate.Text))
            End If
        End If
        If done Then
            SetPanel()
            If rblType.SelectedIndex = 0 Then
                lblMessage.Text &= "Data Saved ! "
            Else
                lblMessage.Text = "Data Saved ! "
            End If
        Else
            lblMessage.Text = "Data Saving Failed ! "
        End If
        lblMessage.Text &= IIf(IsDBNull(ProductionConsumables.ScrapReceipt(CDate(TxtUsageDate.Text))), "No Receipt posted for the given date !", ProductionConsumables.ScrapReceipt(CDate(TxtUsageDate.Text)))
    End Sub

    Private Sub TxtUsageDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtUsageDate.TextChanged
        lblMessage.Text = ""
        Try
            TxtUsageDate.Text = CDate(TxtUsageDate.Text)
            SetPanel()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        lblMessage.Text &= IIf(IsDBNull(ProductionConsumables.ScrapReceipt(CDate(TxtUsageDate.Text))), "No Receipt posted for the given date !", ProductionConsumables.ScrapReceipt(CDate(TxtUsageDate.Text)))
    End Sub

    Private Sub AvgCal()
        lblTU.Text = CDec(Val(TxtWCU.Text) + Val(TxtRHU.Text) + Val(TxtLU.Text) + Val(TxtCU.Text))
        lblAvg.Text = (Val(TxtWCU.Text) + Val(TxtRHU.Text) + Val(TxtLU.Text) + Val(TxtCU.Text)) / Val(lblH.Text)
        lblAvg.Text = CDec(Val(lblAvg.Text)).Round(CDec(Val(lblAvg.Text)), 2)
    End Sub

    Private Sub TxtWCU_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtWCU.TextChanged
        lblMessage.Text = ""
        AvgCal()
    End Sub

    'Private Sub TxtRCU_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRCU.TextChanged
    '    lblMessage.Text = ""
    '    AvgCal()
    'End Sub

    'Private Sub txtAEU_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAEU.TextChanged
    '    lblMessage.Text = ""
    '    AvgCal()
    'End Sub

    Private Sub TxtRHU_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRHU.TextChanged
        lblMessage.Text = ""
        AvgCal()
    End Sub

    Private Sub TxtLU_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLU.TextChanged
        lblMessage.Text = ""
        AvgCal()
    End Sub

    Private Sub TxtCU_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCU.TextChanged
        lblMessage.Text = ""
        AvgCal()
    End Sub

    'Private Sub TxtPRU_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPRU.TextChanged
    '    lblMessage.Text = ""
    '    AvgCal()
    'End Sub

    Protected Sub DataGrid1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DataGrid1.SelectedIndexChanged

    End Sub

    Protected Sub txtMRXC_TextChanged(sender As Object, e As EventArgs) Handles TxtMRXC.TextChanged

    End Sub
End Class
