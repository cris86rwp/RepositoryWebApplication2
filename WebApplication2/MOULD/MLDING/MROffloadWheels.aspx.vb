Public Class MROffloadWheels
    Inherits System.Web.UI.Page
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents txtHeatNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWheelNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSIC As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPresentDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents txtPresentSIC As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPresentSts As System.Web.UI.WebControls.TextBox
    Protected WithEvents pnlOne As System.Web.UI.WebControls.Panel
    Protected WithEvents dgData16 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgData15 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents dgData14 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgData13 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents dgData12 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgData11 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents dgData10 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgData9 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents dgData8 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgData7 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents dgData6 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgData5 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents dgData4 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgData3 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents dgData2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgData1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents pnlTwo As System.Web.UI.WebControls.Panel
    Protected WithEvents rblOffloadCode As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblMode As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnDelete As System.Web.UI.WebControls.Button
    Protected WithEvents Label9 As System.Web.UI.WebControls.Label
    Protected WithEvents rblShift As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtHeatDt As System.Web.UI.WebControls.TextBox
    Protected WithEvents dgData18 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgData17 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
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
        'Put user code to initialize the page here
        'Session("UserID") = "078844"
        'Session("Group") = "MLDING"
        If IsPostBack = False Then
            txtPresentDate.Text = Now.Date
            txtHeatDt.Text = Now.Date
            Try
                SetType()
                PopulateDdls()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub PopulateDdls()
        Dim dt As New DataTable()
        Try
            dt = RWF.MLDING.GetMROffloadType
            rblType.DataSource = dt
            rblType.DataTextField = dt.Columns(0).ColumnName
            rblType.DataValueField = dt.Columns(1).ColumnName
            rblType.DataBind()
            rblType.SelectedIndex = 0
            dt = RWF.MLDING.OffloadCode
            rblOffloadCode.DataSource = dt.DefaultView
            rblOffloadCode.DataTextField = "code"
            rblOffloadCode.DataValueField = "code"
            rblOffloadCode.DataBind()
            rblOffloadCode.SelectedIndex = 0
        Catch exp As Exception
            rblOffloadCode.DataSource = Nothing
            rblOffloadCode.DataBind()
        Finally
            dt.Dispose()
            dt = Nothing
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        If rblMode.SelectedItem.Value = 1 Then
            Dim done As Boolean
            Try
                done = New RWF.MLDING().MROffloadWheels(Val(txtHeatNo.Text), Val(txtWheelNo.Text), Val(rblType.SelectedItem.Value), txtSIC.Text.ToUpper.Trim, rblOffloadCode.SelectedItem.Text, txtPresentSts.Text.ToUpper.Trim, txtRemarks.Text.ToUpper.Trim, CDate(txtPresentDate.Text), txtPresentSIC.Text.ToUpper.Trim)
                GetHeatData()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            If done Then
                lblMessage.Text &= " Data Saved !"
                txtWheelNo.Text = ""
            Else
                lblMessage.Text &= "  Not Saved !"
            End If
        Else
            Try
                If IsNothing(rblType.SelectedItem.Value) Then
                End If
                If IsNothing(rblOffloadCode.SelectedItem.Value) Then

                End If
                Dim done As Boolean
                Dim dt As New DataTable()
                Dim dr As DataRow
                dt.TableName = "OffLoads"
                dt.Columns.Add("HeatNo")
                dt.Columns.Add("WheelNo")
                Dim i As Integer = 0
                Dim chkBox As CheckBox
                For i = 0 To dgData1.Items.Count - 1
                    chkBox = dgData1.Items(i).FindControl("chkWheel")
                    If chkBox.Checked Then
                        dr = dt.NewRow
                        dr("HeatNo") = Val(Label1.Text.Trim)
                        dr("WheelNo") = Val(dgData1.Items(i).Cells(1).Text)
                        dt.Rows.Add(dr)
                    End If
                Next
                i = 0
                For i = 0 To dgData2.Items.Count - 1
                    chkBox = dgData2.Items(i).FindControl("chkWheel")
                    If chkBox.Checked Then
                        dr = dt.NewRow
                        dr("HeatNo") = Val(Label1.Text.Trim)
                        dr("WheelNo") = Val(dgData2.Items(i).Cells(1).Text)
                        dt.Rows.Add(dr)
                    End If
                Next
                i = 0
                For i = 0 To dgData3.Items.Count - 1
                    chkBox = dgData3.Items(i).FindControl("chkWheel")
                    If chkBox.Checked Then
                        dr = dt.NewRow
                        dr("HeatNo") = Val(Label2.Text.Trim)
                        dr("WheelNo") = Val(dgData3.Items(i).Cells(1).Text)
                        dt.Rows.Add(dr)
                    End If
                Next
                i = 0
                For i = 0 To dgData4.Items.Count - 1
                    chkBox = dgData4.Items(i).FindControl("chkWheel")
                    If chkBox.Checked Then
                        dr = dt.NewRow
                        dr("HeatNo") = Val(Label2.Text.Trim)
                        dr("WheelNo") = Val(dgData4.Items(i).Cells(1).Text)
                        dt.Rows.Add(dr)
                    End If
                Next
                i = 0
                For i = 0 To dgData5.Items.Count - 1
                    chkBox = dgData5.Items(i).FindControl("chkWheel")
                    If chkBox.Checked Then
                        dr = dt.NewRow
                        dr("HeatNo") = Val(Label3.Text.Trim)
                        dr("WheelNo") = Val(dgData5.Items(i).Cells(1).Text)
                        dt.Rows.Add(dr)
                    End If
                Next
                i = 0
                For i = 0 To dgData6.Items.Count - 1
                    chkBox = dgData6.Items(i).FindControl("chkWheel")
                    If chkBox.Checked Then
                        dr = dt.NewRow
                        dr("HeatNo") = Val(Label3.Text.Trim)
                        dr("WheelNo") = Val(dgData6.Items(i).Cells(1).Text)
                        dt.Rows.Add(dr)
                    End If
                Next
                i = 0
                For i = 0 To dgData7.Items.Count - 1
                    chkBox = dgData7.Items(i).FindControl("chkWheel")
                    If chkBox.Checked Then
                        dr = dt.NewRow
                        dr("HeatNo") = Val(Label4.Text.Trim)
                        dr("WheelNo") = Val(dgData7.Items(i).Cells(1).Text)
                        dt.Rows.Add(dr)
                    End If
                Next
                i = 0
                For i = 0 To dgData8.Items.Count - 1
                    chkBox = dgData8.Items(i).FindControl("chkWheel")
                    If chkBox.Checked Then
                        dr = dt.NewRow
                        dr("HeatNo") = Val(Label4.Text.Trim)
                        dr("WheelNo") = Val(dgData8.Items(i).Cells(1).Text)
                        dt.Rows.Add(dr)
                    End If
                Next
                i = 0
                For i = 0 To dgData9.Items.Count - 1
                    chkBox = dgData9.Items(i).FindControl("chkWheel")
                    If chkBox.Checked Then
                        dr = dt.NewRow
                        dr("HeatNo") = Val(Label5.Text.Trim)
                        dr("WheelNo") = Val(dgData9.Items(i).Cells(1).Text)
                        dt.Rows.Add(dr)
                    End If
                Next
                i = 0
                For i = 0 To dgData10.Items.Count - 1
                    chkBox = dgData10.Items(i).FindControl("chkWheel")
                    If chkBox.Checked Then
                        dr = dt.NewRow
                        dr("HeatNo") = Val(Label5.Text.Trim)
                        dr("WheelNo") = Val(dgData10.Items(i).Cells(1).Text)
                        dt.Rows.Add(dr)
                    End If
                Next
                i = 0
                For i = 0 To dgData11.Items.Count - 1
                    chkBox = dgData11.Items(i).FindControl("chkWheel")
                    If chkBox.Checked Then
                        dr = dt.NewRow
                        dr("HeatNo") = Val(Label6.Text.Trim)
                        dr("WheelNo") = Val(dgData11.Items(i).Cells(1).Text)
                        dt.Rows.Add(dr)
                    End If
                Next
                i = 0
                For i = 0 To dgData12.Items.Count - 1
                    chkBox = dgData12.Items(i).FindControl("chkWheel")
                    If chkBox.Checked Then
                        dr = dt.NewRow
                        dr("HeatNo") = Val(Label6.Text.Trim)
                        dr("WheelNo") = Val(dgData12.Items(i).Cells(1).Text)
                        dt.Rows.Add(dr)
                    End If
                Next
                i = 0
                For i = 0 To dgData13.Items.Count - 1
                    chkBox = dgData13.Items(i).FindControl("chkWheel")
                    If chkBox.Checked Then
                        dr = dt.NewRow
                        dr("HeatNo") = Val(Label7.Text.Trim)
                        dr("WheelNo") = Val(dgData13.Items(i).Cells(1).Text)
                        dt.Rows.Add(dr)
                    End If
                Next
                i = 0
                For i = 0 To dgData14.Items.Count - 1
                    chkBox = dgData14.Items(i).FindControl("chkWheel")
                    If chkBox.Checked Then
                        dr = dt.NewRow
                        dr("HeatNo") = Val(Label7.Text.Trim)
                        dr("WheelNo") = Val(dgData14.Items(i).Cells(1).Text)
                        dt.Rows.Add(dr)
                    End If
                Next
                i = 0
                For i = 0 To dgData15.Items.Count - 1
                    chkBox = dgData15.Items(i).FindControl("chkWheel")
                    If chkBox.Checked Then
                        dr = dt.NewRow
                        dr("HeatNo") = Val(Label8.Text.Trim)
                        dr("WheelNo") = Val(dgData15.Items(i).Cells(1).Text)
                        dt.Rows.Add(dr)
                    End If
                Next
                i = 0
                For i = 0 To dgData16.Items.Count - 1
                    chkBox = dgData16.Items(i).FindControl("chkWheel")
                    If chkBox.Checked Then
                        dr = dt.NewRow
                        dr("HeatNo") = Val(Label8.Text.Trim)
                        dr("WheelNo") = Val(dgData16.Items(i).Cells(1).Text)
                        dt.Rows.Add(dr)
                    End If
                Next
                i = 0
                For i = 0 To dgData17.Items.Count - 1
                    chkBox = dgData17.Items(i).FindControl("chkWheel")
                    If chkBox.Checked Then
                        dr = dt.NewRow
                        dr("HeatNo") = Val(Label9.Text.Trim)
                        dr("WheelNo") = Val(dgData17.Items(i).Cells(1).Text)
                        dt.Rows.Add(dr)
                    End If
                Next
                i = 0
                For i = 0 To dgData18.Items.Count - 1
                    chkBox = dgData18.Items(i).FindControl("chkWheel")
                    If chkBox.Checked Then
                        dr = dt.NewRow
                        dr("HeatNo") = Val(Label9.Text.Trim)
                        dr("WheelNo") = Val(dgData18.Items(i).Cells(1).Text)
                        dt.Rows.Add(dr)
                    End If
                Next
                done = New RWF.MLDING().MROffloadWheelsNew(dt, Val(rblType.SelectedItem.Value), txtSIC.Text.ToUpper.Trim, rblOffloadCode.SelectedItem.Text, "", txtRemarks.Text.ToUpper.Trim, Now.Date, "")
                If done Then
                    FillRBLs()
                    lblMessage.Text &= lblMessage.Text
                Else
                    lblMessage.Text &= "  Not Saved !"
                End If
            Catch exp As Exception
                lblMessage.Text &= exp.Message
                If lblMessage.Text.StartsWith("Object") Then
                    lblMessage.Text = "In Valid OffLoad Type or Code !"
                End If
            End Try
        End If

    End Sub

    Private Sub txtHeatNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHeatNo.TextChanged
        lblMessage.Text = ""
        If Val(txtHeatNo.Text) = 0 Then
            lblMessage.Text = "InValid HeatNo !"
            txtHeatNo.Text = ""
        Else
            If Val(txtWheelNo.Text) = 0 Then
                txtWheelNo.Text = ""
            Else
                GetWheelData()
            End If
            GetHeatData()
        End If
    End Sub

    Private Sub GetHeatData()
        Dim dt As New DataTable()
        DataGrid1.Visible = True
        Try
            dt = RWF.MLDING.GetOffloadedHeatDetails(Val(txtHeatNo.Text))
            DataGrid1.DataSource = dt
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
            dt = Nothing
        End Try
    End Sub

    Private Sub txtWheelNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWheelNo.TextChanged
        lblMessage.Text = ""
        If Val(txtWheelNo.Text) = 0 Then
            lblMessage.Text = "InValid WheelNo !"
            txtWheelNo.Text = ""
        Else
            If Val(txtHeatNo.Text) = 0 Then
                txtHeatNo.Text = ""
            Else
                GetWheelData()
            End If
        End If
    End Sub

    Private Sub GetWheelData()
        Dim dt As New DataTable()
        Try
            dt = RWF.MLDING.GetOffloadedWheelsDetails(Val(txtHeatNo.Text), Val(txtWheelNo.Text))
            If dt.Rows.Count > 0 Then
                Dim i As Int16 = 0
                rblType.ClearSelection()
                For i = 0 To rblType.Items.Count - 1
                    If rblType.Items(i).Value = dt.Rows(0)("TypeID") Then
                        rblType.Items(i).Selected = True
                        Exit For
                    End If
                Next
                i = 0
                rblOffloadCode.ClearSelection()
                For i = 0 To rblOffloadCode.Items.Count - 1
                    If rblOffloadCode.Items(i).Value = dt.Rows(0)("OffCode") Then
                        rblOffloadCode.Items(i).Selected = True
                        Exit For
                    End If
                Next
                txtPresentDate.Text = dt.Rows(0)("PresentStsDate")
                txtSIC.Text = dt.Rows(0)("SIC")
                txtPresentSts.Text = dt.Rows(0)("PresentCode")
                txtPresentSIC.Text = dt.Rows(0)("PresentSIC")
                txtRemarks.Text = dt.Rows(0)("Remarks")
            End If
        Catch exp As Exception
            txtHeatNo.Text = ""
            txtWheelNo.Text = ""
            rblOffloadCode.DataSource = Nothing
            rblOffloadCode.DataBind()
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
            dt = Nothing
        End Try
    End Sub

    Private Sub rblFur_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SetType()
    End Sub

    Private Sub SetType()
        pnlOne.Visible = False
        pnlTwo.Visible = False
        DataGrid1.Visible = False
        If rblMode.SelectedItem.Value = 1 Then
            pnlOne.Visible = True
            DataGrid1.Visible = True
        Else
            pnlTwo.Visible = True
            FillRBLs()
        End If
    End Sub

    Private Sub txtHeatDt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHeatDt.TextChanged
        SetType()
    End Sub

    Private Sub ClearHeatLables()
        Label1.Text = ""
        Label2.Text = ""
        Label3.Text = ""
        Label4.Text = ""
        Label5.Text = ""
        Label6.Text = ""
        Label7.Text = ""
        Label8.Text = ""
        Label9.Text = ""
    End Sub

    Private Sub FillRBLs()
        Dim dt As New DataTable()
        Dim dtHeat As DataTable
        Try
            dt = RWF.MLDING.GetHeats(CDate(txtHeatDt.Text), rblShift.SelectedItem.Text, True)
            Dim i As Integer
            For i = 0 To dt.Rows.Count - 1
                txtSIC.Text = Trim(dt.Rows(i)(1))
                Select Case i
                    Case 0
                        Label1.Text = dt.Rows(i)(0)
                        dtHeat = GetWheels(Val(Label1.Text), 0)
                        dgData1.DataSource = dtHeat
                        dgData1.DataBind()
                        Dim A As Int16
                        For A = 0 To dtHeat.Rows.Count - 1
                            If Not IsDBNull(dtHeat.Rows(A)("WheelNo")) Then 'Wheel
                                If dtHeat.Rows(A)("WheelNo") = dgData1.Items(A).Cells(1).Text Then
                                    dgData1.Items(A).Cells(1).BackColor = System.Drawing.Color.Pink
                                    dgData1.Items(A).Cells(0).BackColor = System.Drawing.Color.Pink
                                    dgData1.Items(A).Cells(0).Enabled = False
                                End If
                            End If
                        Next
                        dtHeat = GetWheels(Val(Label1.Text), 1)
                        If dtHeat.Rows.Count > 1 Then
                            dgData2.DataSource = dtHeat
                            dgData2.DataBind()
                            For A = 0 To dtHeat.Rows.Count - 1
                                If Not IsDBNull(dtHeat.Rows(A)("WheelNo")) Then
                                    If dtHeat.Rows(A)("WheelNo") = dgData2.Items(A).Cells(1).Text Then
                                        dgData2.Items(A).Cells(1).BackColor = System.Drawing.Color.Pink
                                        dgData2.Items(A).Cells(0).BackColor = System.Drawing.Color.Pink
                                        dgData2.Items(A).Cells(0).Enabled = False
                                    End If
                                End If
                            Next
                        End If
                    Case 1
                        Label2.Text = dt.Rows(i)(0)
                        dtHeat = GetWheels(Val(Label2.Text), 0)
                        dgData3.DataSource = dtHeat
                        dgData3.DataBind()


                        Dim A As Int16
                        For A = 0 To dtHeat.Rows.Count - 1
                            If Not IsDBNull(dtHeat.Rows(A)("WheelNo")) Then
                                If dtHeat.Rows(A)("WheelNo") = dgData3.Items(A).Cells(1).Text Then
                                    dgData3.Items(A).Cells(1).BackColor = System.Drawing.Color.Pink
                                    dgData3.Items(A).Cells(0).BackColor = System.Drawing.Color.Pink
                                    dgData3.Items(A).Cells(0).Enabled = False
                                End If
                            End If
                        Next

                        dtHeat = GetWheels(Val(Label2.Text), 1)
                        If dtHeat.Rows.Count > 1 Then
                            dgData4.DataSource = dtHeat
                            dgData4.DataBind()

                            For A = 0 To dtHeat.Rows.Count - 1
                                If Not IsDBNull(dtHeat.Rows(A)("WheelNo")) Then
                                    If dtHeat.Rows(A)("WheelNo") = dgData4.Items(A).Cells(1).Text Then
                                        dgData4.Items(A).Cells(1).BackColor = System.Drawing.Color.Pink
                                        dgData4.Items(A).Cells(0).BackColor = System.Drawing.Color.Pink
                                        dgData4.Items(A).Cells(0).Enabled = False
                                    End If
                                End If
                            Next

                        End If
                    Case 2
                        Label3.Text = dt.Rows(i)(0)
                        dtHeat = GetWheels(Val(Label3.Text), 0)
                        dgData5.DataSource = dtHeat
                        dgData5.DataBind()


                        Dim A As Int16
                        For A = 0 To dtHeat.Rows.Count - 1
                            If Not IsDBNull(dtHeat.Rows(A)("WheelNo")) Then
                                If dtHeat.Rows(A)("WheelNo") = dgData5.Items(A).Cells(1).Text Then
                                    dgData5.Items(A).Cells(1).BackColor = System.Drawing.Color.Pink
                                    dgData5.Items(A).Cells(0).BackColor = System.Drawing.Color.Pink
                                    dgData5.Items(A).Cells(0).Enabled = False
                                End If
                            End If
                        Next

                        dtHeat = GetWheels(Val(Label3.Text), 1)
                        If dtHeat.Rows.Count > 1 Then
                            dgData6.DataSource = dtHeat
                            dgData6.DataBind()

                            For A = 0 To dtHeat.Rows.Count - 1
                                If Not IsDBNull(dtHeat.Rows(A)("WheelNo")) Then
                                    If dtHeat.Rows(A)("WheelNo") = dgData6.Items(A).Cells(1).Text Then
                                        dgData6.Items(A).Cells(1).BackColor = System.Drawing.Color.Pink
                                        dgData6.Items(A).Cells(0).BackColor = System.Drawing.Color.Pink
                                        dgData6.Items(A).Cells(0).Enabled = False
                                    End If
                                End If
                            Next

                        End If
                    Case 3
                        Label4.Text = dt.Rows(i)(0)
                        dtHeat = GetWheels(Val(Label4.Text), 0)
                        dgData7.DataSource = dtHeat
                        dgData7.DataBind()

                        Dim A As Int16
                        For A = 0 To dtHeat.Rows.Count - 1
                            If Not IsDBNull(dtHeat.Rows(A)("WheelNo")) Then
                                If dtHeat.Rows(A)("WheelNo") = dgData7.Items(A).Cells(1).Text Then
                                    dgData7.Items(A).Cells(1).BackColor = System.Drawing.Color.Pink
                                    dgData7.Items(A).Cells(0).BackColor = System.Drawing.Color.Pink
                                    dgData7.Items(A).Cells(0).Enabled = False
                                End If
                            End If
                        Next

                        dtHeat = GetWheels(Val(Label4.Text), 1)
                        If dtHeat.Rows.Count > 1 Then
                            dgData8.DataSource = dtHeat
                            dgData8.DataBind()

                            For A = 0 To dtHeat.Rows.Count - 1
                                If Not IsDBNull(dtHeat.Rows(A)("WheelNo")) Then
                                    If dtHeat.Rows(A)("WheelNo") = dgData8.Items(A).Cells(1).Text Then
                                        dgData8.Items(A).Cells(1).BackColor = System.Drawing.Color.Pink
                                        dgData8.Items(A).Cells(0).BackColor = System.Drawing.Color.Pink
                                        dgData8.Items(A).Cells(0).Enabled = False
                                    End If
                                End If
                            Next

                        End If
                    Case 4
                        Label5.Text = dt.Rows(i)(0)
                        dtHeat = GetWheels(Val(Label5.Text), 0)
                        dgData9.DataSource = dtHeat
                        dgData9.DataBind()

                        Dim A As Int16
                        For A = 0 To dtHeat.Rows.Count - 1
                            If Not IsDBNull(dtHeat.Rows(A)("WheelNo")) Then
                                If dtHeat.Rows(A)("WheelNo") = dgData9.Items(A).Cells(1).Text Then
                                    dgData9.Items(A).Cells(1).BackColor = System.Drawing.Color.Pink
                                    dgData9.Items(A).Cells(0).BackColor = System.Drawing.Color.Pink
                                    dgData9.Items(A).Cells(0).Enabled = False
                                End If
                            End If
                        Next

                        dtHeat = GetWheels(Val(Label5.Text), 1)
                        If dtHeat.Rows.Count > 1 Then
                            dgData10.DataSource = dtHeat
                            dgData10.DataBind()

                            For A = 0 To dtHeat.Rows.Count - 1
                                If Not IsDBNull(dtHeat.Rows(A)("WheelNo")) Then
                                    If dtHeat.Rows(A)("WheelNo") = dgData10.Items(A).Cells(1).Text Then
                                        dgData10.Items(A).Cells(1).BackColor = System.Drawing.Color.Pink
                                        dgData10.Items(A).Cells(0).BackColor = System.Drawing.Color.Pink
                                        dgData10.Items(A).Cells(0).Enabled = False
                                    End If
                                End If
                            Next

                        End If
                    Case 5
                        Label6.Text = dt.Rows(i)(0)
                        dtHeat = GetWheels(Val(Label6.Text), 0)
                        dgData11.DataSource = dtHeat
                        dgData11.DataBind()
                        Dim A As Int16
                        For A = 0 To dtHeat.Rows.Count - 1
                            If Not IsDBNull(dtHeat.Rows(A)("WheelNo")) Then
                                If dtHeat.Rows(A)("WheelNo") = dgData11.Items(A).Cells(1).Text Then
                                    dgData11.Items(A).Cells(1).BackColor = System.Drawing.Color.Pink
                                    dgData11.Items(A).Cells(0).BackColor = System.Drawing.Color.Pink
                                    dgData11.Items(A).Cells(0).Enabled = False
                                End If
                            End If
                        Next

                        dtHeat = GetWheels(Val(Label6.Text), 1)
                        If dtHeat.Rows.Count > 1 Then
                            dgData12.DataSource = dtHeat
                            dgData12.DataBind()

                            For A = 0 To dtHeat.Rows.Count - 1
                                If Not IsDBNull(dtHeat.Rows(A)("WheelNo")) Then
                                    If dtHeat.Rows(A)("WheelNo") = dgData12.Items(A).Cells(1).Text Then
                                        dgData12.Items(A).Cells(1).BackColor = System.Drawing.Color.Pink
                                        dgData12.Items(A).Cells(0).BackColor = System.Drawing.Color.Pink
                                        dgData12.Items(A).Cells(0).Enabled = False
                                    End If
                                End If
                            Next

                        End If
                    Case 6
                        Label7.Text = dt.Rows(i)(0)
                        dtHeat = GetWheels(Val(Label7.Text), 0)
                        dgData13.DataSource = dtHeat
                        dgData13.DataBind()
                        Dim A As Int16
                        For A = 0 To dtHeat.Rows.Count - 1
                            If Not IsDBNull(dtHeat.Rows(A)("WheelNo")) Then
                                If dtHeat.Rows(A)("WheelNo") = dgData13.Items(A).Cells(1).Text Then
                                    dgData13.Items(A).Cells(1).BackColor = System.Drawing.Color.Pink
                                    dgData13.Items(A).Cells(0).BackColor = System.Drawing.Color.Pink
                                    dgData13.Items(A).Cells(0).Enabled = False
                                End If
                            End If
                        Next
                        dtHeat = GetWheels(Val(Label7.Text), 1)
                        If dtHeat.Rows.Count > 1 Then
                            dgData14.DataSource = dtHeat
                            dgData14.DataBind()
                            For A = 0 To dtHeat.Rows.Count - 1
                                If Not IsDBNull(dtHeat.Rows(A)("WheelNo")) Then
                                    If dtHeat.Rows(A)("WheelNo") = dgData14.Items(A).Cells(1).Text Then
                                        dgData14.Items(A).Cells(1).BackColor = System.Drawing.Color.Pink
                                        dgData14.Items(A).Cells(0).BackColor = System.Drawing.Color.Pink
                                        dgData14.Items(A).Cells(0).Enabled = False
                                    End If
                                End If
                            Next
                        End If
                    Case 7
                        Label8.Text = dt.Rows(i)(0)
                        dtHeat = GetWheels(Val(Label8.Text), 0)
                        dgData15.DataSource = dtHeat
                        dgData15.DataBind()
                        Dim A As Int16
                        For A = 0 To dtHeat.Rows.Count - 1
                            If Not IsDBNull(dtHeat.Rows(A)("WheelNo")) Then
                                If dtHeat.Rows(A)("WheelNo") = dgData15.Items(A).Cells(1).Text Then
                                    dgData15.Items(A).Cells(1).BackColor = System.Drawing.Color.Pink
                                    dgData15.Items(A).Cells(0).BackColor = System.Drawing.Color.Pink
                                    dgData15.Items(A).Cells(0).Enabled = False
                                End If
                            End If
                        Next
                        dtHeat = GetWheels(Val(Label8.Text), 1)
                        If dtHeat.Rows.Count > 1 Then
                            dgData16.DataSource = dtHeat
                            dgData16.DataBind()
                            For A = 0 To dtHeat.Rows.Count - 1
                                If Not IsDBNull(dtHeat.Rows(A)("WheelNo")) Then
                                    If dtHeat.Rows(A)("WheelNo") = dgData16.Items(A).Cells(1).Text Then
                                        dgData16.Items(A).Cells(1).BackColor = System.Drawing.Color.Pink
                                        dgData16.Items(A).Cells(0).BackColor = System.Drawing.Color.Pink
                                        dgData16.Items(A).Cells(0).Enabled = False
                                    End If
                                End If
                            Next
                        End If
                    Case 8
                        Label9.Text = dt.Rows(i)(0)
                        dtHeat = GetWheels(Val(Label9.Text), 0)
                        dgData17.DataSource = dtHeat
                        dgData17.DataBind()
                        Dim A As Int16
                        For A = 0 To dtHeat.Rows.Count - 1
                            If Not IsDBNull(dtHeat.Rows(A)("WheelNo")) Then
                                If dtHeat.Rows(A)("WheelNo") = dgData17.Items(A).Cells(1).Text Then
                                    dgData17.Items(A).Cells(1).BackColor = System.Drawing.Color.Pink
                                    dgData17.Items(A).Cells(0).BackColor = System.Drawing.Color.Pink
                                    dgData17.Items(A).Cells(0).Enabled = False
                                End If
                            End If
                        Next
                        dtHeat = GetWheels(Val(Label9.Text), 1)
                        If dtHeat.Rows.Count > 1 Then
                            dgData18.DataSource = dtHeat
                            dgData18.DataBind()
                            For A = 0 To dtHeat.Rows.Count - 1
                                If Not IsDBNull(dtHeat.Rows(A)("WheelNo")) Then
                                    If dtHeat.Rows(A)("WheelNo") = dgData18.Items(A).Cells(1).Text Then
                                        dgData18.Items(A).Cells(1).BackColor = System.Drawing.Color.Pink
                                        dgData18.Items(A).Cells(0).BackColor = System.Drawing.Color.Pink
                                        dgData18.Items(A).Cells(0).Enabled = False
                                    End If
                                End If
                            Next
                        End If
                End Select
            Next
            PopulateDdls()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
            dt = Nothing
        End Try
        dt = Nothing
    End Sub

    Private Function GetWheels(ByVal Heat As Double, ByVal Type As Int16) As DataTable
        Dim dt As New DataTable()
        Try
            dt = RWF.MLDING.GetHeatWheels(Heat, Type)
            Return dt
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Function

    Private Sub rblShift_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblShift.SelectedIndexChanged
        SetType()
    End Sub

    Private Sub rblMode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblMode.SelectedIndexChanged
        SetType()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        lblMessage.Text = ""
        Dim done As Boolean
        Try
            done = New RWF.MLDING().MROffloadWheelsDelete(Val(txtHeatNo.Text), Val(txtWheelNo.Text))
            GetHeatData()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If done Then
            lblMessage.Text = "Data Deleted !"
            txtPresentDate.Text = Now.Date
            txtPresentSIC.Text = ""
            txtSIC.Text = ""
            txtPresentSts.Text = ""
            txtRemarks.Text = ""
            txtWheelNo.Text = ""
            txtHeatNo.Text = ""
        Else
            lblMessage.Text &= "  Not Saved !"
        End If
    End Sub
End Class
