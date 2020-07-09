Public Class Offload
    Inherits System.Web.UI.Page
    Protected WithEvents rblShift As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents dgWheels As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtHeatNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblOffloadCode As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblMcnList As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents dgData As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblWheelNo As System.Web.UI.WebControls.Label
    Protected WithEvents txtProcessed As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblType As System.Web.UI.WebControls.RadioButtonList
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
        'Session("UserID") = "078844"
        'Session("Group") = "MLDING"
        lblWheelNo.Visible = False
        If IsPostBack = False Then
            txtDate.Text = Now.Date
            Try
                txtHeatNo.Text = RWF.tables.GetLatestPourHeat
                PopulateDdls()
                PopulateWheelsGrid()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub txtHeatNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHeatNo.TextChanged
        lblMessage.Text = ""
        Try
            PopulateWheelsGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub PopulateDdls()
        Dim ds As New DataSet()
        Try
            ds = HotWheelLine1.PopulateDdls(rblType.SelectedItem.Value)
            If rblType.SelectedItem.Value <> 2 Then
                rblMcnList.DataSource = ds.Tables(0).DefaultView
                rblMcnList.DataTextField = "Machine_code"
                rblMcnList.DataValueField = "Machine_code"
                rblMcnList.DataBind()
                rblMcnList.SelectedIndex = 0
            Else
                rblMcnList.DataSource = ds.Tables(0).DefaultView
                rblMcnList.DataTextField = "OffLoadType"
                rblMcnList.DataValueField = "TypeID"
                rblMcnList.DataBind()
                rblMcnList.SelectedIndex = 0
            End If
            rblOffloadCode.DataSource = ds.Tables(1).DefaultView
            rblOffloadCode.DataTextField = "code"
            rblOffloadCode.DataValueField = "code"
            rblOffloadCode.DataBind()
            rblOffloadCode.SelectedIndex = 0
        Catch exp As Exception
            rblOffloadCode.DataSource = Nothing
            rblMcnList.DataSource = Nothing
            rblOffloadCode.DataBind()
            rblOffloadCode.DataBind()
            lblMessage.Text &= exp.Message
        Finally
            ds.Dispose()
            ds = Nothing
        End Try
    End Sub

    Private Sub PopulateWheelsGrid(Optional ByVal PageIndex As Integer = -1)
        Dim ds As New DataSet()
        dgWheels.DataSource = Nothing
        dgWheels.DataBind()
        dgData.DataSource = Nothing
        dgData.DataBind()
        dgData.SelectedIndex = -1
        lblWheelNo.Text = ""
        Try
            ds = RWF.MLDING.PopulateWheelsGrid(Val(txtHeatNo.Text), rblType.SelectedItem.Value)
            If ds.Tables(0).Rows.Count > 0 Then
                dgWheels.DataSource = ds.Tables(0)
                If PageIndex >= 0 Then dgWheels.CurrentPageIndex = PageIndex
                dgWheels.DataBind()
            Else
                lblMessage.Text = "No Poured Wheels available for selected heat !"
            End If
            If ds.Tables(1).Rows.Count > 0 Then
                dgData.Visible = True
                dgData.DataSource = ds.Tables(1)
                dgData.DataBind()
            End If
        Catch exp As Exception
            lblMessage.Text = "Error getting wheels of the heat : " & exp.Message
        Finally
            ds.Dispose()
            ds = Nothing
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        Dim Done As Boolean
        Try
            Dim chkBox As CheckBox
            Dim checked As Integer
            Dim RecIDs As String
            Dim i As Integer
            checked = 0
            RecIDs = ""
            For i = 0 To dgWheels.Items.Count - 1
                chkBox = dgWheels.Items(i).FindControl("chkSelected")
                If chkBox.Checked Then
                    checked = checked + 1
                    If checked > 1 Then
                        RecIDs &= ", "
                    End If
                    RecIDs &= "" & dgWheels.Items(i).Cells(2).Text & ""
                End If
            Next
            Dim Mcn As String = ""
            If rblMcnList.Visible = True Then Mcn = rblMcnList.SelectedItem.Text
            If rblType.SelectedItem.Value = 1 Then
                Done = New RWF.MLDING().NFOffloads(RecIDs, Val(txtHeatNo.Text), CDate(txtDate.Text), rblShift.SelectedItem.Text, rblMcnList.SelectedItem.Text, rblOffloadCode.SelectedItem.Text, Val(lblWheelNo.Text), txtProcessed.Text.Trim)
            ElseIf rblType.SelectedItem.Value = 0 Then
                Done = New HotWheelLine1().AddHubCutRec(Val(txtHeatNo.Text), RecIDs, rblOffloadCode.SelectedItem.Text, CDate(txtDate.Text), rblShift.SelectedItem.Text, "", "", "", "", "", "", CDate(txtDate.Text), CDate(txtDate.Text), 0, "", "")
            ElseIf rblType.SelectedItem.Value = 2 Then
                Done = New RWF.MLDING().MROffloadWheels(Val(txtHeatNo.Text), RecIDs, rblMcnList.SelectedItem.Value, "", rblOffloadCode.SelectedItem.Text, "", "", CDate(txtDate.Text), "")
            End If
            chkBox = Nothing
            checked = Nothing
            RecIDs = Nothing
            i = Nothing
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If Done Then
            PopulateWheelsGrid()
            lblMessage.Text &= "Data Saved !"
        Else
            lblMessage.Text = "Data Not Saved !"
        End If
    End Sub

    Private Sub dgData_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgData.ItemCommand
        lblMessage.Text = ""
        lblWheelNo.Text = ""
        txtProcessed.Text = ""
        Try
            If rblType.SelectedItem.Value = 1 Then
                If e.CommandName = "Select" Then
                    lblWheelNo.Text = e.Item.Cells(2).Text
                    txtProcessed.Text = e.Item.Cells(8).Text.Replace("&nbsp;", "")
                Else
                    lblMessage.Text &= "InValid Operation !"
                End If
            Else
                If e.CommandName = "Delete" Then
                    Try
                        If New HotWheelLine1().DeleteHubCutRec(e.Item.Cells(2).Text) Then
                            PopulateWheelsGrid()
                            lblMessage.Text &= " Data Deleted !"
                        Else
                            lblMessage.Text &= " Data Not Deleted !"
                        End If
                    Catch exp As Exception
                        lblMessage.Text &= exp.Message
                    End Try
                End If
            End If
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
    End Sub

    Private Sub rblType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblType.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            PopulateWheelsGrid()
            PopulateDdls()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

End Class
