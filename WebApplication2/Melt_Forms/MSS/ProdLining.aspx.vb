Public Class ProdLining
    Inherits System.Web.UI.Page
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents rblLiningType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblLinedBy As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblLiningItemNo As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents lblItemName As System.Web.UI.WebControls.Label
    Protected WithEvents DataGrid3 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents pnlFWP As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlLadle As System.Web.UI.WebControls.Panel
    Protected WithEvents txtFFLNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLiningNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLastHeatNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPreLiningNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtHandedOverOnDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWorkStartedOnDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWorkCompletedOnDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtHandedOverOnTime As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWorkStartedOnTime As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWorkCompletedOnTime As System.Web.UI.WebControls.TextBox
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtBTT As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBMOM As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTTT As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTMOM As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDepth As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLOANo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLOADate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtScheduledQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCompletedQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents txtGroupLeader1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtGroupLeader2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtInspectionNote As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents txtLOARemarks As System.Web.UI.WebControls.TextBox
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


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If IsPostBack = False Then
            Dim Group As String = Session("Group")
            Dim UserId As String = Session("UserID")
            Dim InValid As Boolean = False
            ''''''''''''''''
            'Session("Group") = "SSMELT"
            'Session("UserID") = "074510"
            'Group = "SSMELT"
            'UserId = "111111"
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
            txtLOADate.Text = Now.Date
                Dim dt As DataTable
                dt = ProductionConsumables.GetLiningType
                rblLiningType.DataSource = dt
                rblLiningType.DataTextField = dt.Columns(1).ColumnName
                rblLiningType.DataValueField = dt.Columns(0).ColumnName
                rblLiningType.DataBind()
                rblLiningType.SelectedIndex = 0
                'lblLadleNo.Text = rblLadleNo.SelectedItem.Text
                dt = ProductionConsumables.GetLiningBy
                rblLinedBy.DataSource = dt
                rblLinedBy.DataTextField = dt.Columns(1).ColumnName
                rblLinedBy.DataValueField = dt.Columns(0).ColumnName
                rblLinedBy.DataBind()
                rblLinedBy.SelectedIndex = 0
                txtHandedOverOnDate.Text = Now.Date
                txtWorkStartedOnDate.Text = Now.Date
                txtWorkCompletedOnDate.Text = Now.Date
                txtHandedOverOnTime.Text = "00:00"
                txtWorkStartedOnTime.Text = "00:00"
                txtWorkCompletedOnTime.Text = "00:00"
                SetType()
            End If
        'End If
    End Sub

    Private Sub SetType()
        txtLiningNo.Text = ""
        txtLastHeatNo.Text = ""
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        DataGrid3.DataSource = Nothing
        DataGrid3.DataBind()
        pnlLadle.Visible = False
        pnlFWP.Visible = False
        txtFFLNo.Text = ""
        If rblLiningType.SelectedItem.Text.StartsWith("FURNACE") Then
            lblItemName.Text = "FurnaceNo"
        ElseIf rblLiningType.SelectedItem.Text.StartsWith("LADLE") Then
            lblItemName.Text = "LadleNo"
            pnlLadle.Visible = True
        ElseIf rblLiningType.SelectedItem.Text.StartsWith("ROOF") Then
            lblItemName.Text = "RoofNo"
        End If
        Dim dt As DataTable
        Try
            dt = ProductionConsumables.GetLiningItems(lblItemName.Text)
            rblLiningItemNo.DataSource = dt
            rblLiningItemNo.DataTextField = dt.Columns(0).ColumnName
            rblLiningItemNo.DataValueField = dt.Columns(0).ColumnName
            rblLiningItemNo.DataBind()
            rblLiningItemNo.SelectedIndex = 0
            GetTopDetails()
            GetLiningSavedData()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt = Nothing
        End Try
        If rblLiningType.SelectedItem.Value = 1 Then
            pnlFWP.Visible = True
            txtFFLNo.Text = ProductionConsumables.GetTopFFL(rblLiningItemNo.SelectedItem.Text)
        End If
    End Sub

    Private Sub GetLiningSavedData()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        Try
            DataGrid2.DataSource = ProductionConsumables.GetLiningSavedData(rblLiningType.SelectedItem.Value, rblLinedBy.SelectedItem.Value)
            DataGrid2.DataBind()
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
    End Sub

    Private Sub GetTopDetails()
        DataGrid3.DataSource = Nothing
        DataGrid3.DataBind()
        Dim dt As DataTable
        Try
            dt = ProductionConsumables.GetTopDetails(rblLiningItemNo.SelectedItem.Text, rblLiningType.SelectedItem.Value)
            If dt.Rows.Count > 0 Then
                DataGrid3.DataSource = dt
                DataGrid3.DataBind()
                txtPreLiningNo.Text = dt.Rows(0)(0)
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub rblLiningType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblLiningType.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            SetType()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtLastHeatNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLastHeatNo.TextChanged
        lblMessage.Text = ""
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Dim dt As DataTable
        Try
            dt = ProductionConsumables.GetLiningHeatData(Val(txtLastHeatNo.Text.Trim), rblLiningType.SelectedItem.Value)
            If dt.Rows.Count > 0 Then
                Dim ItemName As String = rblLiningItemNo.SelectedItem.Text
                If ItemName.Trim = Trim(dt.Rows(0)("No")) Then
                    DataGrid1.DataSource = dt
                    DataGrid1.DataBind()
                Else
                    lblMessage.Text = "InValid HeatNo : " & txtLastHeatNo.Text & "  !"
                    txtLastHeatNo.Text = ""
                End If
                ItemName = Nothing
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt = Nothing
        End Try
    End Sub

    Private Sub txtLiningNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLiningNo.TextChanged
        lblMessage.Text = ""
        txtLastHeatNo.Text = ""
        txtPreLiningNo.Text = ""
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        txtHandedOverOnDate.Text = Now.Date
        txtWorkStartedOnDate.Text = Now.Date
        txtWorkCompletedOnDate.Text = Now.Date
        txtHandedOverOnTime.Text = "00:00"
        txtWorkStartedOnTime.Text = "00:00"
        txtWorkCompletedOnTime.Text = "00:00"
        txtInspectionNote.Text = ""
        txtLOARemarks.Text = ""
        Dim dt As DataTable
        Try
            dt = ProductionConsumables.GetLiningData(txtLiningNo.Text.Trim, rblLiningType.SelectedItem.Value)
            If dt.Rows.Count > 0 Then
                rblLiningType.ClearSelection()
                If dt.Rows(0)("LingType") = "FWP" Then
                    rblLiningType.SelectedIndex = 0
                ElseIf dt.Rows(0)("LingType") = "FFL" Then
                    rblLiningType.SelectedIndex = 1
                ElseIf dt.Rows(0)("LingType") = "LRL" Then
                    rblLiningType.SelectedIndex = 2
                ElseIf dt.Rows(0)("LingType") = "RRL" Then
                    rblLiningType.SelectedIndex = 3
                End If
                If dt.Rows(0)("LinedBy") = "DEPARTMENT" Then
                    rblLinedBy.SelectedIndex = 0
                Else
                    rblLinedBy.SelectedIndex = 1
                End If
                rblLiningItemNo.ClearSelection()
                Dim i As Int16
                For i = 0 To rblLiningItemNo.Items.Count - 1
                    If rblLiningItemNo.Items(i).Text = dt.Rows(0)("LiningItemNo") Then
                        rblLiningItemNo.Items(i).Selected = True
                        Exit For
                    End If
                Next
                i = Nothing
                txtLastHeatNo.Text = IIf(IsDBNull(dt.Rows(0)("LastHeatNo")), 0, dt.Rows(0)("LastHeatNo"))
                txtPreLiningNo.Text = IIf(IsDBNull(dt.Rows(0)("PreLiningNo")), "", dt.Rows(0)("PreLiningNo"))
                txtHandedOverOnDate.Text = IIf(IsDBNull(dt.Rows(0)("HODt")), Now.Date, dt.Rows(0)("HODt"))
                txtWorkStartedOnDate.Text = IIf(IsDBNull(dt.Rows(0)("WSDt")), Now.Date, dt.Rows(0)("WSDt"))
                txtWorkCompletedOnDate.Text = IIf(IsDBNull(dt.Rows(0)("WCDt")), Now.Date, dt.Rows(0)("WCDt"))
                txtHandedOverOnTime.Text = IIf(IsDBNull(dt.Rows(0)("HOTime")), "", dt.Rows(0)("HOTime"))
                txtWorkStartedOnTime.Text = IIf(IsDBNull(dt.Rows(0)("WSTime")), "", dt.Rows(0)("WSTime"))
                txtWorkCompletedOnTime.Text = IIf(IsDBNull(dt.Rows(0)("WCTime")), "", dt.Rows(0)("WCTime"))
                txtInspectionNote.Text = IIf(IsDBNull(dt.Rows(0)("InspectionNote")), "", dt.Rows(0)("InspectionNote"))
                txtLOANo.Text = IIf(IsDBNull(dt.Rows(0)("LOANo")), "", dt.Rows(0)("LOANo"))
                txtLOADate.Text = IIf(IsDBNull(dt.Rows(0)("LOADt")), Now.Date, dt.Rows(0)("LOADt"))
                txtScheduledQty.Text = IIf(IsDBNull(dt.Rows(0)("ScheduledQty")), "", dt.Rows(0)("ScheduledQty"))
                txtCompletedQty.Text = IIf(IsDBNull(dt.Rows(0)("CompletedQty")), "", dt.Rows(0)("CompletedQty"))
                txtBTT.Text = IIf(IsDBNull(dt.Rows(0)("BTT")), "", dt.Rows(0)("BTT"))
                txtBMOM.Text = IIf(IsDBNull(dt.Rows(0)("BMOM")), "", dt.Rows(0)("BMOM"))
                txtTTT.Text = IIf(IsDBNull(dt.Rows(0)("TTT")), "", dt.Rows(0)("TTT"))
                txtTMOM.Text = IIf(IsDBNull(dt.Rows(0)("TMOM")), "", dt.Rows(0)("TMOM"))
                txtDepth.Text = IIf(IsDBNull(dt.Rows(0)("Depth")), "", dt.Rows(0)("Depth"))
                txtGroupLeader1.Text = IIf(IsDBNull(dt.Rows(0)("GroupLeader1")), "", dt.Rows(0)("GroupLeader1"))
                txtGroupLeader2.Text = IIf(IsDBNull(dt.Rows(0)("GroupLeader2")), "", dt.Rows(0)("GroupLeader2"))
                txtLOARemarks.Text = IIf(IsDBNull(dt.Rows(0)("LOARemarks")), "", dt.Rows(0)("LOARemarks"))
            End If
            If txtLOANo.Text.Trim.Length > 0 Then
                GetLOADetails()
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt = Nothing
        End Try
    End Sub

    Private Sub GetLOADetails()
        Dim dt As DataTable
        Try
            dt = ProductionConsumables.GetLOADetails(txtLOANo.Text.Trim)
            If dt.Rows.Count > 0 Then
                txtLOADate.Text = IIf(IsDBNull(dt.Rows(0)("LOADate")), Now.Date, dt.Rows(0)("LOADate"))
                txtScheduledQty.Text = IIf(IsDBNull(dt.Rows(0)("SchQty")), 0, dt.Rows(0)("SchQty"))
                Label1.Text = IIf(IsDBNull(dt.Rows(0)("SchQty")), 0, dt.Rows(0)("SchQty")) - IIf(IsDBNull(dt.Rows(0)("CompQty")), 0, dt.Rows(0)("CompQty"))
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtLOANo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLOANo.TextChanged
        lblMessage.Text = ""
        Try
            GetLOADetails()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtPreLiningNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPreLiningNo.TextChanged
        lblMessage.Text = ""
        txtLastHeatNo.Text = ""
    End Sub

    Private Sub rblLiningItemNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblLiningItemNo.SelectedIndexChanged
        lblMessage.Text = ""
        txtLastHeatNo.Text = ""
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        pnlFWP.Visible = False
        Try
            If rblLiningType.SelectedItem.Value = 1 Then
                pnlFWP.Visible = True
                txtFFLNo.Text = ProductionConsumables.GetTopFFL(rblLiningItemNo.SelectedItem.Text)
            End If
            GetTopDetails()
            txtLiningNo.Text = ""
            txtLastHeatNo.Text = ""
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        If txtLiningNo.Text = "" Then
            lblMessage.Text = "InValid Lining No"
            Exit Sub
        End If
        Dim Line As Int16 = Val(Left(txtLiningNo.Text, 1))
        If Line = 0 Then
            lblMessage.Text = "InValid Lining No"
            Exit Sub
        End If
        Line = Nothing
        If txtLastHeatNo.Text = "" Then
            lblMessage.Text = "InValid HeatNo"
            Exit Sub
        End If
        Dim HandedOverOn, WorkStartedOn, WorkCompletedOn As DateTime
        Dim Done As Boolean
        Try
            HandedOverOn = CDate(txtHandedOverOnDate.Text) & " " & txtHandedOverOnTime.Text
            Done = True
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If Done = False Then
            lblMessage.Text = "InValid HandedOverOn Date Time !"
            Exit Sub
        Else
            Done = False
        End If

        Try
            WorkStartedOn = CDate(txtWorkStartedOnDate.Text) & " " & txtWorkStartedOnTime.Text
            Done = True
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If Done = False Then
            lblMessage.Text = "InValid WorkStartedOn Date Time !"
            Exit Sub
        Else
            Done = False
        End If

        Try
            WorkCompletedOn = CDate(txtWorkCompletedOnDate.Text) & " " & txtWorkCompletedOnTime.Text
            Done = True
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If Done = False Then
            lblMessage.Text = "InValid WorkCompletedOn Date Time !"
            Exit Sub
        Else
            Done = False
        End If
        If rblLiningType.SelectedItem.Value <> 3 Then
            txtBTT.Text = ""
            txtBMOM.Text = ""
            txtTTT.Text = ""
            txtTMOM.Text = ""
            txtDepth.Text = ""
        End If

        Try
            Done = New ProductionConsumables().SaveFurnaceLining(txtLiningNo.Text.Trim, rblLiningType.SelectedItem.Value, rblLinedBy.SelectedItem.Value, rblLiningItemNo.SelectedItem.Text, Val(txtLastHeatNo.Text), HandedOverOn, WorkStartedOn, WorkCompletedOn, txtLOANo.Text.Trim, CDate(txtLOADate.Text), Val(txtScheduledQty.Text), Val(txtCompletedQty.Text), txtInspectionNote.Text.Trim, Val(txtBTT.Text), Val(txtBMOM.Text), Val(txtTTT.Text), Val(txtTMOM.Text), Val(txtDepth.Text), txtPreLiningNo.Text.Trim, txtFFLNo.Text.Trim, txtGroupLeader1.Text.Trim, txtGroupLeader2.Text.Trim, txtLOARemarks.Text.Trim)
            lblMessage.Text = "Data Saved successfully !"
        Catch exp As Exception
            lblMessage.Text &= "Data Not Saved ! " & exp.Message
        End Try
        If Done Then
            GetTopDetails()
            GetLiningSavedData()
            txtLiningNo.Text = ""
            txtLastHeatNo.Text = ""
        End If
    End Sub

    Protected Sub rblLinedBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblLinedBy.SelectedIndexChanged

    End Sub
End Class
