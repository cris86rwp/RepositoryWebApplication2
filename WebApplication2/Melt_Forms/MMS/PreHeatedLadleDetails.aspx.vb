Public Class PreHeatedLadleDetails
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtLiftingTemp As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtStartDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtStartTime As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEndDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEndTime As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtLiningNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblLadleNo As System.Web.UI.WebControls.Label
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtStaffNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFromHeat As System.Web.UI.WebControls.TextBox
    Protected WithEvents pnlDetails As System.Web.UI.WebControls.Panel
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents rblType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents pnlTemp As System.Web.UI.WebControls.Panel
    Protected WithEvents rblLPH As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtHSDQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSetTemp As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtActualTemp As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtUser As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSetDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSetTime As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRemark As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblSet As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents DataGrid3 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblPreHeatID As System.Web.UI.WebControls.Label
    Protected WithEvents btnTemp As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid4 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents PreHeatID As System.Web.UI.WebControls.Label
    Protected WithEvents txtToHeat As System.Web.UI.WebControls.TextBox
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
        lblPreHeatID.Visible = False
        PreHeatID.Visible = False
        If IsPostBack = False Then
            'Session("UserID") = "078844"
            txtStaffNo.Text = Session("UserID")
            txtUser.Text = Session("UserID")
            Try
                SetType()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        If lblLadleNo.Text.Trim.Length = 0 Then
            lblMessage.Text = "InValid selection of LadleNo !"
            Exit Sub
        End If
        Dim dtStart, dtEnd As Date, Done As Boolean
        Try
            dtStart = CDate(txtStartDate.Text + " " + Right("0" + txtStartTime.Text, 5))
        Catch exp As Exception
            dtStart = Now.Date
        End Try
        Try
            dtEnd = CDate(txtEndDate.Text + " " + Right("0" + txtEndTime.Text, 5))
        Catch exp As Exception
            dtEnd = Now.Date
        End Try
        Try
            Done = New RWF.Melting().SavePreHeatedLadleDetails(lblLadleNo.Text.Trim, dtStart, dtEnd, Val(txtLiftingTemp.Text), Val(txtFromHeat.Text), Val(txtToHeat.Text), txtRemark.Text.Trim, txtLiningNo.Text.Trim, txtStaffNo.Text.Trim, rblSet.SelectedItem.Value, Val(PreHeatID.Text))
            PreHeatID.Text = ""
            If Done Then GetPreHeatedLadleDetails()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If Done Then lblMessage.Text &= " Data saved !"
    End Sub

    Private Sub GetPreHeatedLadleDetails()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Dim dt As DataTable
        Try
            dt = RWF.Melting.GetPreHeatedLadleDetails(txtLiningNo.Text.Trim)
            If dt.Rows.Count > 0 Then
                DataGrid1.DataSource = dt
                DataGrid1.DataBind()
            Else
                lblMessage.Text = "No Ladles Pre Heated for the given Date !"
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        dt = Nothing
    End Sub

    Private Sub DataGrid1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.ItemCommand
        lblMessage.Text = ""
        lblPreHeatID.Text = ""
        Dim Done As Boolean
        Select Case e.CommandName
            Case "Select"
                Try
                    lblLadleNo.Text = IIf(IsDBNull(e.Item.Cells(2).Text), Now.Date, e.Item.Cells(2).Text)
                    Try
                        txtStartDate.Text = IIf(IsDBNull(e.Item.Cells(3).Text), Now.Date, e.Item.Cells(3).Text)
                    Catch exp As Exception
                        txtStartDate.Text = Now.Date
                    End Try
                    Try
                        txtStartTime.Text = IIf(IsDBNull(e.Item.Cells(4).Text), Now.Date, e.Item.Cells(4).Text)
                    Catch exp As Exception
                        txtStartTime.Text = "00:00"
                    End Try
                    Try
                        txtEndDate.Text = IIf(IsDBNull(e.Item.Cells(5).Text), Now.Date, e.Item.Cells(5).Text)
                    Catch exp As Exception
                        txtEndDate.Text = Now.Date
                    End Try
                    Try
                        txtEndTime.Text = IIf(IsDBNull(e.Item.Cells(6).Text), Now.Date, e.Item.Cells(6).Text)
                    Catch exp As Exception
                        txtEndTime.Text = "00:00"
                    End Try

                    txtLiftingTemp.Text = IIf(IsDBNull(e.Item.Cells(8).Text), "", e.Item.Cells(8).Text)
                    txtFromHeat.Text = IIf(IsDBNull(e.Item.Cells(9).Text), "", e.Item.Cells(9).Text)
                    txtToHeat.Text = IIf(IsDBNull(e.Item.Cells(10).Text), "", e.Item.Cells(10).Text)
                    txtStaffNo.Text = IIf(IsDBNull(e.Item.Cells(11).Text), "", e.Item.Cells(11).Text.Replace("&nbsp;", ""))
                    rblSet.ClearSelection()
                    Dim i As Int16
                    For i = 0 To rblType.Items.Count - 1
                        If e.Item.Cells(12).Text = rblSet.Items(i).Text Then
                            rblSet.Items(i).Selected = True
                            Exit For
                        End If
                    Next
                    txtRemark.Text = IIf(IsDBNull(e.Item.Cells(13).Text), "", e.Item.Cells(13).Text.Replace("&nbsp;", ""))
                    PreHeatID.Text = e.Item.Cells(14).Text
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                End Try
            Case "Delete"
                PreHeatID.Text = e.Item.Cells(14).Text
                Try
                    Done = New RWF.Melting().SavePreHeatedLadleDetails(lblLadleNo.Text.Trim, Now, Now, Val(txtLiftingTemp.Text), Val(txtFromHeat.Text), Val(txtToHeat.Text), txtRemark.Text.Trim, txtLiningNo.Text.Trim, txtStaffNo.Text.Trim, rblSet.SelectedItem.Value, Val(PreHeatID.Text), True)
                    PreHeatID.Text = ""
                    If Done Then GetPreHeatedLadleDetails()
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                End Try
                If Done Then lblMessage.Text &= " Data Deleted along with set temperature details !"
        End Select
    End Sub

    Private Sub txtLiningNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLiningNo.TextChanged
        lblMessage.Text = ""
        lblPreHeatID.Text = ""
        Try
            GetLiningNoDetails()
            GetPreHeatedLadleDetails()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub GetLiningNoDetails()
        lblPreHeatID.Text = ""
        DataGrid2.SelectedIndex = -1
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        Dim dt As DataTable
        Try
            dt = RWF.Melting.GetLiningNoDetails(txtLiningNo.Text)
            If dt.Rows.Count > 0 Then
                lblLadleNo.Text = dt.Rows(0)(0)
                DataGrid2.DataSource = dt
                DataGrid2.DataBind()
            Else
                lblMessage.Text = "No Ladle Lining details for " & txtLiningNo.Text & "!"
                txtLiningNo.Text = ""
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        dt = Nothing
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
        pnlDetails.Visible = False
        pnlTemp.Visible = False
        lblPreHeatID.Text = ""
        lblLadleNo.Text = ""
        txtLiftingTemp.Text = ""
        txtFromHeat.Text = ""
        txtToHeat.Text = ""
        txtRemark.Text = ""
        txtLiningNo.Text = ""
        txtHSDQty.Text = ""
        txtSetTemp.Text = ""
        txtActualTemp.Text = ""
        txtRemarks.Text = ""
        If rblType.SelectedItem.Value = 1 Then
            pnlDetails.Visible = True
            txtStartDate.Text = Now.Date
            txtEndDate.Text = Now.Date
            txtStartTime.Text = "00:00"
            txtEndTime.Text = "00:00"
        Else
            pnlTemp.Visible = True
            txtSetDate.Text = Now.Date
            txtSetTime.Text = "00:00"
            GetPreHeatIDs()
        End If
    End Sub

    Private Sub GetPreHeatIDs()
        DataGrid4.DataSource = Nothing
        DataGrid4.DataBind()
        DataGrid3.SelectedIndex = -1
        DataGrid3.DataSource = Nothing
        DataGrid3.DataBind()
        Dim dt As DataTable
        Try
            dt = RWF.Melting.GetPreHeatIDs
            If IsNothing(DataGrid3.CurrentPageIndex) Then DataGrid3.CurrentPageIndex = 0
            If dt.Rows.Count > 3 Then
                DataGrid3.AllowPaging = True
                DataGrid3.PageSize = 3
                DataGrid3.PagerStyle.Mode = PagerMode.NumericPages
            End If
            DataGrid3.DataSource = dt
            DataGrid3.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        dt = Nothing
    End Sub

    Private Sub btnTemp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTemp.Click
        lblMessage.Text = ""
        If Val(lblPreHeatID.Text) = 0 Then
            lblMessage.Text = "InValid Lining No selection !"
            Exit Sub
        End If
        lblMessage.Text = ""
        Dim dtSet As Date, Done As Boolean
        Try
            dtSet = CDate(txtSetDate.Text + " " + Right("0" + txtSetTime.Text, 5))
        Catch exp As Exception
            dtSet = Now.Date
        End Try
        Try
            Done = New RWF.Melting().SavePreHeatedLadleSetTemp(Val(lblPreHeatID.Text), dtSet, Val(rblLPH.SelectedItem.Text), Val(txtHSDQty.Text), Val(txtSetTemp.Text), Val(txtActualTemp.Text), txtRemarks.Text.Trim, txtUser.Text.Trim)
            If Done Then GetPreHeatedLadleSetTemp()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If Done Then lblMessage.Text &= " Data saved !"
    End Sub

    Private Sub DataGrid3_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid3.ItemCommand
        lblMessage.Text = ""
        lblPreHeatID.Text = ""
        Select Case e.CommandName
            Case "Select"
                lblPreHeatID.Text = e.Item.Cells(6).Text
                GetPreHeatedLadleSetTemp()
        End Select
    End Sub

    Private Sub GetPreHeatedLadleSetTemp()
        DataGrid4.SelectedIndex = -1
        DataGrid4.DataSource = Nothing
        DataGrid4.DataBind()
        Dim dt As DataTable
        Try
            dt = RWF.Melting.GetPreHeatedLadleSetTemp(Val(lblPreHeatID.Text))
            If dt.Rows.Count > 0 Then
                DataGrid4.DataSource = dt
                DataGrid4.DataBind()
            Else
                lblMessage.Text = "No Set Temp details for the given ladle !"
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        dt = Nothing
    End Sub

    Private Sub DataGrid4_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid4.ItemCommand
        lblMessage.Text = ""
        Select Case e.CommandName
            Case "Delete"
                lblPreHeatID.Text = e.Item.Cells(1).Text
                Dim dtSet As Date, Done As Boolean
                Try
                    dtSet = CDate(e.Item.Cells(2).Text + " " + Right("0" + e.Item.Cells(3).Text, 5))
                Catch exp As Exception
                    dtSet = Now.Date
                End Try
                Try
                    Done = New RWF.Melting().SavePreHeatedLadleSetTemp(Val(lblPreHeatID.Text), dtSet, Val(rblLPH.SelectedItem.Text), Val(txtHSDQty.Text), Val(txtSetTemp.Text), Val(txtActualTemp.Text), txtRemarks.Text.Trim, txtUser.Text.Trim, Val(e.Item.Cells(10).Text))
                    If Done Then GetPreHeatedLadleSetTemp()
                    lblPreHeatID.Text = ""
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                End Try
        End Select
    End Sub

    Private Sub DataGrid3_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid3.PageIndexChanged
        lblMessage.Text = ""
        Try
            DataGrid3.CurrentPageIndex = e.NewPageIndex
            DataGrid3.EditItemIndex = -1
            GetPreHeatIDs()
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
    End Sub

    Protected Sub DataGrid3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DataGrid3.SelectedIndexChanged

    End Sub
End Class
