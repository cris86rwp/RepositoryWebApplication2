Public Class mmHsdConsumption
    Inherits System.Web.UI.Page
    Protected WithEvents lblMultiplyingFactor As System.Web.UI.WebControls.Label
    Protected WithEvents lblMtrUnit As System.Web.UI.WebControls.Label
    Protected WithEvents ddlHsdPoints As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblHelp As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblConsumption As System.Web.UI.WebControls.Label
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents dgData As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblPrevRdgDate As System.Web.UI.WebControls.Label
    Protected WithEvents lblPrevRdgShift As System.Web.UI.WebControls.Label
    Protected WithEvents lblPrevRdg As System.Web.UI.WebControls.Label
    Protected WithEvents txtCurRdgDt As System.Web.UI.WebControls.TextBox
    Protected WithEvents rdoCurRdgShift As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
    Protected WithEvents lblMode As System.Web.UI.WebControls.Label
    Protected WithEvents lblLogInEmpCode As System.Web.UI.WebControls.Label
    Protected WithEvents lblMtrUsedFor As System.Web.UI.WebControls.Label
    Protected WithEvents txtCurRdg As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents chkHelp As System.Web.UI.WebControls.CheckBox

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
        If Page.IsPostBack = False Then
            Session("UserID") = "016002"
            Session("Group") = "MLDING"
            ClearScreen(0)
            Dim oEmp As rwfGen.Employee
            Dim oHsdConsumption As HSD_Data.HsdConsumption
            Try
                lblMode.Text = Request.QueryString("mode") & ""
                btnSave.Enabled = False
                oHsdConsumption = New HSD_Data.HsdConsumption(Session("UserID"), Session("Group"))
                lblHeader.Text = oHsdConsumption.HsdPoint.ScreenHeader
                lblLogInEmpCode.Text = oHsdConsumption.HsdPoint.EnteredBy
                txtCurRdgDt.Text = oHsdConsumption.DateShift.ConsumptionDate
                Dim i As Integer
                rdoCurRdgShift.ClearSelection()
                For i = 0 To rdoCurRdgShift.Items.Count - 1
                    If rdoCurRdgShift.Items(i).Value = oHsdConsumption.DateShift.ConsumptionShift Then
                        rdoCurRdgShift.Items(i).Selected = True
                        Exit For
                    End If
                Next
                i = Nothing
                Session("oHsdConsumption") = oHsdConsumption
                populateDDL()
                PopulateGrid()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            oEmp = Nothing
            oHsdConsumption = Nothing
        End If
    End Sub
    Private Sub ClearScreen(ByVal After As Integer)
        Select Case After
            Case 0
                lblMessage.Text = ""
                btnSave.Enabled = False
                lblConsumption.Text = ""
                lblPrevRdg.Text = ""
                lblPrevRdgShift.Text = ""
                lblPrevRdgDate.Text = ""
                lblMultiplyingFactor.Text = ""
                lblMtrUnit.Text = ""
                ddlHsdPoints.ClearSelection()
                If ddlHsdPoints.Items.Count > 0 Then ddlHsdPoints.Items(0).Selected = True
                rdoCurRdgShift.ClearSelection()
                txtCurRdgDt.Text = ""
            Case 1
                lblMessage.Text = ""
                btnSave.Enabled = False
                lblConsumption.Text = ""
                lblPrevRdg.Text = ""
                lblPrevRdgShift.Text = ""
                lblPrevRdgDate.Text = ""
                lblMultiplyingFactor.Text = ""
                lblMtrUnit.Text = ""
                ddlHsdPoints.ClearSelection()
                If ddlHsdPoints.Items.Count > 0 Then ddlHsdPoints.Items(0).Selected = True
                rdoCurRdgShift.ClearSelection()
                txtCurRdgDt.Text = ""
            Case 2
                lblMessage.Text = ""
                btnSave.Enabled = False
                lblConsumption.Text = ""
                lblPrevRdg.Text = ""
                lblPrevRdgShift.Text = ""
                lblPrevRdgDate.Text = ""
                lblMultiplyingFactor.Text = ""
                lblMtrUnit.Text = ""
                ddlHsdPoints.ClearSelection()
                If ddlHsdPoints.Items.Count > 0 Then ddlHsdPoints.Items(0).Selected = True
                ' txtCurRdgDt.Text = ""
            Case 3
                lblMessage.Text = ""
                btnSave.Enabled = False
                lblConsumption.Text = ""
                lblPrevRdg.Text = ""
                lblPrevRdgShift.Text = ""
                lblPrevRdgDate.Text = ""
                lblMultiplyingFactor.Text = ""
                lblMtrUnit.Text = ""
                'txtCurRdgDt.Text = ""
            Case 4
                lblMessage.Text = ""
                btnSave.Enabled = False
                lblConsumption.Text = ""
        End Select
    End Sub
    Private Sub populateDDL()
        Dim dv As New DataView()
        dv.Table = CType(Session("oHsdConsumption"), HSD_Data.HsdConsumption).HsdPoint.HsdPointsTable
        dv.Sort = "HsdPoint"
        Dim i As Integer
        For i = 0 To dv.Count - 1
            ddlHsdPoints.Items.Add(New ListItem(dv(i)("HsdPoint"), dv(i)("HsdUsedFor")))
        Next
        ddlHsdPoints.Items.Insert(0, "Select")
        dv.Dispose()
        dv = Nothing
    End Sub

    Private Sub ddlHsdPoints_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlHsdPoints.SelectedIndexChanged
        ClearScreen(3)
        If ddlHsdPoints.SelectedItem.Text <> "Select" Then
            Try
                If IsNothing(rdoCurRdgShift.SelectedItem) = True Then
                    Throw New Exception("Select Reading Times -- Shift ")
                End If
                CType(Session("oHsdConsumption"), HSD_Data.HsdConsumption).SelectedHsdPoint = ddlHsdPoints.SelectedItem.Text
                Dim oUpdateConsumption As New HSD_Data.UpdateConsumption(CType(Session("oHsdConsumption"), HSD_Data.HsdConsumption).HsdPoint.HsdPoint, CType(Session("oHsdConsumption"), HSD_Data.HsdConsumption).HsdPoint.ShopCode)
                oUpdateConsumption.Calculate()
                CheckUp()
                PopulateGrid()
                oUpdateConsumption = Nothing
            Catch exp As Exception
                lblMessage.Text = "Update Consumption Error : " & exp.Message
            End Try
        End If
    End Sub
    Private Sub CheckUp()
        lblMtrUsedFor.Text = CType(Session("oHsdConsumption"), HSD_Data.HsdConsumption).HsdPoint.ProcessHsdUsed
        Dim dv As New DataView()
        dv.Table = CType(Session("oHsdConsumption"), HSD_Data.HsdConsumption).HsdPoint.HsdPointsTable
        dv.RowFilter = "HsdPoint = '" & ddlHsdPoints.SelectedItem.Text.Trim & "'"
        If dv.Count > 0 Then
            lblMtrUsedFor.Text = dv(0)("HsdUsedFor")
            lblMultiplyingFactor.Text = dv(0)("MtrMultiplyFactor")
            lblMtrUnit.Text = dv(0)("ReadingUnit")
        Else
            lblMtrUsedFor.Text = ""
            lblMultiplyingFactor.Text = ""
            lblMtrUnit.Text = ""
        End If
        dv.Dispose()
        lblPrevRdg.Text = CType(Session("oHsdConsumption"), HSD_Data.HsdConsumption).Reading.Previous
        lblPrevRdgShift.Text = CType(Session("oHsdConsumption"), HSD_Data.HsdConsumption).Reading.PrevRdgShift
        lblPrevRdgDate.Text = CType(Session("oHsdConsumption"), HSD_Data.HsdConsumption).Reading.PrevRdgDt
        dv = Nothing
    End Sub

    Private Sub txtCurRdg_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCurRdg.TextChanged
        ClearScreen(4)
        Try
            CType(Session("oHsdConsumption"), HSD_Data.HsdConsumption).Reading.Current = Val(txtCurRdg.Text)
            lblConsumption.Text = CType(Session("oHsdConsumption"), HSD_Data.HsdConsumption).Reading.Consumption
            If ddlHsdPoints.SelectedItem.Text <> "Select" AndAlso txtCurRdgDt.Text <> "" AndAlso IsNothing(rdoCurRdgShift.SelectedItem) = False AndAlso lblLogInEmpCode.Text <> "" Then
                btnSave.Enabled = True
            End If           
        Catch exp As Exception
            viewState("Error") = True
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        Dim oUpdateConsumption As HSD_Data.UpdateConsumption
        'If Session("UserID") & "" = "016002" Then Exit Sub
        Try
            CType(Session("oHsdConsumption"), HSD_Data.HsdConsumption).Save(lblMode.Text = "Delete")
            lblMessage.Text = CType(Session("oHsdConsumption"), HSD_Data.HsdConsumption).Message
            oUpdateConsumption = New HSD_Data.UpdateConsumption(CType(Session("oHsdConsumption"), HSD_Data.HsdConsumption).HsdPoint.HsdPoint, CType(Session("oHsdConsumption"), HSD_Data.HsdConsumption).HsdPoint.ShopCode)
            oUpdateConsumption.Calculate()
            PopulateGrid()
            ClearScreen(5)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        oUpdateConsumption = Nothing
    End Sub
    Private Sub PopulateGrid()
        Dim dv As New DataView()
        dv.Table = CType(Session("oHsdConsumption"), HSD_Data.HsdConsumption).HsdConsumptionTable.Copy
        dv.RowFilter = "HsdDate = '" & Format(CDate(txtCurRdgDt.Text), "dd/MM/yyyy") & "' and HsdShift = '" & rdoCurRdgShift.SelectedItem.Value & "'"
        dv.Sort = "Slno desc"
        dgData.DataSource = dv
        dgData.DataBind()
        dv.Dispose()
        dv = Nothing
    End Sub

    Private Sub txtCurRdgDt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCurRdgDt.TextChanged
        Dim dt As String = txtCurRdgDt.Text
        ClearScreen(1)
        txtCurRdgDt.Text = dt
        Try
            CType(Session("oHsdConsumption"), HSD_Data.HsdConsumption).ConsumptionDate = CDate(txtCurRdgDt.Text)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        dt = Nothing
    End Sub

    Private Sub rdoCurRdgShift_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoCurRdgShift.SelectedIndexChanged
        ClearScreen(2)
        Try
            CType(Session("oHsdConsumption"), HSD_Data.HsdConsumption).ConsumptionShift = rdoCurRdgShift.SelectedItem.Value.Trim
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtRemarks_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRemarks.TextChanged
        Try
            CType(Session("oHsdConsumption"), HSD_Data.HsdConsumption).Remarks = txtRemarks.Text.ToUpper
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Protected Sub dgData_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
End Class
