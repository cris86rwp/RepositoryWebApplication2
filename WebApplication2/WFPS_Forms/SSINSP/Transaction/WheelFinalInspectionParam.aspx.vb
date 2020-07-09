Public Class WheelFinalInspectionParam
    Inherits System.Web.UI.Page
    Protected WithEvents ddlProduct As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents MinTD As System.Web.UI.WebControls.TextBox
    Protected WithEvents MaxTD As System.Web.UI.WebControls.TextBox
    Protected WithEvents MinBore As System.Web.UI.WebControls.TextBox
    Protected WithEvents MaxBore As System.Web.UI.WebControls.TextBox
    Protected WithEvents minHubLen As System.Web.UI.WebControls.TextBox
    Protected WithEvents maxHubLen As System.Web.UI.WebControls.TextBox
    Protected WithEvents minRimTh As System.Web.UI.WebControls.TextBox
    Protected WithEvents maxRimTh As System.Web.UI.WebControls.TextBox
    Protected WithEvents minHubProj As System.Web.UI.WebControls.TextBox
    Protected WithEvents maxHubProj As System.Web.UI.WebControls.TextBox
    Protected WithEvents MaxPT As System.Web.UI.WebControls.TextBox
    Protected WithEvents MinPT As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnUpdate As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents McnMinDia As System.Web.UI.WebControls.TextBox
    Protected WithEvents OverSizeMin As System.Web.UI.WebControls.TextBox
    Protected WithEvents OverSizeMax As System.Web.UI.WebControls.TextBox
    Protected WithEvents MinWhlNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents MaxWhlNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents pnlW As System.Web.UI.WebControls.Panel
    Protected WithEvents min_pressure As System.Web.UI.WebControls.TextBox
    Protected WithEvents max_pressure As System.Web.UI.WebControls.TextBox
    Protected WithEvents pnlM As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlT As System.Web.UI.WebControls.Panel
    Protected WithEvents Min_Guage As System.Web.UI.WebControls.TextBox
    Protected WithEvents max_Guage As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    'new
    Protected WithEvents TextBox1 As System.Web.UI.WebControls.TextBox

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

        ' Page.Theme = themeValue
        Page.Theme = Session("Theme")
    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If IsPostBack = False Then
            Dim dt As DataTable
            Try
                SetType()
                GetData()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try

            'If rblType.SelectedItem.Text.StartsWith("W") Then
            '    dt = RWF.WFPSQuerry.FIWheelsParam
            '    ddlProduct.DataSource = dt
            '    ddlProduct.DataTextField = dt.Columns(0).ColumnName
            '    ddlProduct.DataValueField = dt.Columns(1).ColumnName
            '    ddlProduct.DataBind()
            '    ddlProduct.SelectedIndex = 0
            '    DataGrid1.DataSource = RWF.WFPSQuerry.FIWheelsParamData()
            '    DataGrid1.DataBind()
            'Else
            '    dt = RWF.WFPSQuerry.WheelSetParam(rblType.SelectedItem.Text)
            '    ddlProduct.DataSource = dt
            '    ddlProduct.DataTextField = dt.Columns(0).ColumnName
            '    ddlProduct.DataValueField = dt.Columns(1).ColumnName
            '    ddlProduct.DataBind()
            '    ddlProduct.SelectedIndex = 0
            '    DataGrid1.DataSource = RWF.WFPSQuerry.WheelSetParamData("", rblType.SelectedItem.Text, True)
            '    DataGrid1.DataBind()
            'End If

        End If
    End Sub

    Private Sub ClearW()
        MinTD.Text = ""
        MaxTD.Text = ""
        MinBore.Text = ""
        MaxBore.Text = ""
        minHubLen.Text = ""
        maxHubLen.Text = ""
        minRimTh.Text = ""
        maxRimTh.Text = ""
        minHubProj.Text = ""
        maxHubProj.Text = ""
        MaxPT.Text = ""
        MinPT.Text = ""
        MinWhlNo.Text = ""
        MaxWhlNo.Text = ""
    End Sub

    Private Sub ClearT()
        Min_Guage.Text = ""
        max_Guage.Text = ""
    End Sub

    Private Sub ClearM()
        min_pressure.Text = ""
        max_pressure.Text = ""
    End Sub

    Private Sub GetData()
        ClearW()
        ClearM()
        ClearT()
        Dim dt As DataTable
        If rblType.SelectedItem.Text.StartsWith("W") Then
            dt = RWF.WFPSQuerry.FIWheelsParamData(ddlProduct.SelectedItem.Value)
            MinTD.Text = IIf(IsDBNull(dt.Rows(0)("MinTD")), 0, dt.Rows(0)("MinTD"))
            MaxTD.Text = IIf(IsDBNull(dt.Rows(0)("MaxTD")), 0, dt.Rows(0)("MaxTD"))
            MinBore.Text = IIf(IsDBNull(dt.Rows(0)("MinBore")), 0, dt.Rows(0)("MinBore"))
            MaxBore.Text = IIf(IsDBNull(dt.Rows(0)("MaxBore")), 0, dt.Rows(0)("MaxBore"))
            minHubLen.Text = IIf(IsDBNull(dt.Rows(0)("minHubLen")), 0, dt.Rows(0)("minHubLen"))
            maxHubLen.Text = IIf(IsDBNull(dt.Rows(0)("maxHubLen")), 0, dt.Rows(0)("maxHubLen"))
            minRimTh.Text = IIf(IsDBNull(dt.Rows(0)("minRimTh")), 0, dt.Rows(0)("minRimTh"))
            maxRimTh.Text = IIf(IsDBNull(dt.Rows(0)("maxRimTh")), 0, dt.Rows(0)("maxRimTh"))
            minHubProj.Text = IIf(IsDBNull(dt.Rows(0)("minHubProj")), 0, dt.Rows(0)("minHubProj"))
            maxHubProj.Text = IIf(IsDBNull(dt.Rows(0)("maxHubProj")), 0, dt.Rows(0)("maxHubProj"))
            MinPT.Text = IIf(IsDBNull(dt.Rows(0)("MinPT")), 0, dt.Rows(0)("MinPT"))
            MaxPT.Text = IIf(IsDBNull(dt.Rows(0)("MaxPT")), 0, dt.Rows(0)("MaxPT"))
            McnMinDia.Text = IIf(IsDBNull(dt.Rows(0)("McnMinDia")), 0, dt.Rows(0)("McnMinDia"))
            OverSizeMin.Text = IIf(IsDBNull(dt.Rows(0)("OverSizeMin")), 0, dt.Rows(0)("OverSizeMin"))
            OverSizeMax.Text = IIf(IsDBNull(dt.Rows(0)("OverSizeMax")), 0, dt.Rows(0)("OverSizeMax"))
            MinWhlNo.Text = IIf(IsDBNull(dt.Rows(0)("MinWhlNo")), 0, dt.Rows(0)("MinWhlNo"))
            MaxWhlNo.Text = IIf(IsDBNull(dt.Rows(0)("MaxWhlNo")), 0, dt.Rows(0)("MaxWhlNo"))
            TextBox1.Text = IIf(IsDBNull(dt.Rows(0)("minrimthickness")), 0, dt.Rows(0)("minrimthickness"))
        ElseIf rblType.SelectedItem.Text.StartsWith("T") Then
            dt = RWF.WFPSQuerry.WheelSetParamData(ddlProduct.SelectedItem.Value, rblType.SelectedItem.Text, False)
            Min_Guage.Text = IIf(IsDBNull(dt.Rows(0)("MinGuage")), 0, dt.Rows(0)("MinGuage"))
            max_Guage.Text = IIf(IsDBNull(dt.Rows(0)("MaxGuage")), 0, dt.Rows(0)("MaxGuage"))
        ElseIf rblType.SelectedItem.Text.StartsWith("M") Then
            dt = RWF.WFPSQuerry.WheelSetParamData(ddlProduct.SelectedItem.Value, rblType.SelectedItem.Text, False)
            min_pressure.Text = IIf(IsDBNull(dt.Rows(0)("MinPres")), 0, dt.Rows(0)("MinPres"))
            max_pressure.Text = IIf(IsDBNull(dt.Rows(0)("MaxPres")), 0, dt.Rows(0)("MaxPres"))
        End If
        dt = Nothing
    End Sub

    Private Sub ddlProduct_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlProduct.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            GetData()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        lblMessage.Text = ""
        Try
            If rblType.SelectedItem.Text.StartsWith("W") Then
                lblMessage.Text = New InspectionAssistant().UpdateWhlParameters(ddlProduct.SelectedItem.Value, Val(MinTD.Text), Val(MaxTD.Text), Val(MinBore.Text), Val(MaxBore.Text), Val(minHubLen.Text), Val(maxHubLen.Text), Val(minRimTh.Text), Val(maxRimTh.Text), Val(minHubProj.Text), Val(maxHubProj.Text), Val(MinPT.Text), Val(MaxPT.Text), Val(McnMinDia.Text), Val(OverSizeMin.Text), Val(OverSizeMax.Text), Val(MinWhlNo.Text), Val(MaxWhlNo.Text), Val(TextBox1.Text))
                DataGrid1.DataSource = RWF.WFPSQuerry.FIWheelsParamData()
                DataGrid1.DataBind()
            ElseIf rblType.SelectedItem.Text.StartsWith("T") Then
                lblMessage.Text = New InspectionAssistant().UpdateSetTrackGauges(ddlProduct.SelectedItem.Value, Val(Min_Guage.Text), Val(max_Guage.Text))
                DataGrid1.DataSource = RWF.WFPSQuerry.WheelSetParamData("", rblType.SelectedItem.Text, True)
                DataGrid1.DataBind()
            ElseIf rblType.SelectedItem.Text.StartsWith("M") Then
                lblMessage.Text = New InspectionAssistant().UpdateSetMountPressures(ddlProduct.SelectedItem.Value, Val(min_pressure.Text), Val(max_pressure.Text))
                DataGrid1.DataSource = RWF.WFPSQuerry.WheelSetParamData("", rblType.SelectedItem.Text, True)
                DataGrid1.DataBind()
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub rblType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblType.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            SetType()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub SetType()
        pnlW.Visible = False
        pnlT.Visible = False
        pnlM.Visible = False
        If rblType.SelectedItem.Text.StartsWith("W") Then
            pnlW.Visible = True
        ElseIf rblType.SelectedItem.Text.StartsWith("T") Then
            pnlT.Visible = True
        ElseIf rblType.SelectedItem.Text.StartsWith("M") Then
            pnlM.Visible = True
        End If
        Dim dt As DataTable
        If rblType.SelectedItem.Text.StartsWith("W") Then
            dt = RWF.WFPSQuerry.FIWheelsParam
            ddlProduct.DataSource = dt
            ddlProduct.DataTextField = dt.Columns(0).ColumnName
            ddlProduct.DataValueField = dt.Columns(1).ColumnName
            ddlProduct.DataBind()
            ddlProduct.SelectedIndex = 0
            DataGrid1.DataSource = RWF.WFPSQuerry.FIWheelsParamData()
            DataGrid1.DataBind()
        Else
            dt = RWF.WFPSQuerry.WheelSetParam(rblType.SelectedItem.Text)
            ddlProduct.DataSource = dt
            ddlProduct.DataTextField = dt.Columns(0).ColumnName
            ddlProduct.DataValueField = dt.Columns(1).ColumnName
            ddlProduct.DataBind()
            ddlProduct.SelectedIndex = 0
            DataGrid1.DataSource = RWF.WFPSQuerry.WheelSetParamData("", rblType.SelectedItem.Text, True)
            DataGrid1.DataBind()
        End If
        GetData()
    End Sub
End Class
