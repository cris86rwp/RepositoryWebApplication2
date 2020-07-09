Public Class mouldAssemblyAdd
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents rblShift As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents lblMouldType As System.Web.UI.WebControls.Label
    Protected WithEvents lblMouldInit As System.Web.UI.WebControls.Label
    Protected WithEvents lblMouldFinal As System.Web.UI.WebControls.Label
    Protected WithEvents lblGrphiteRmvd As System.Web.UI.WebControls.Label
    Protected WithEvents txtCntIngate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtOperator_id As System.Web.UI.WebControls.TextBox
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents grdMouldAssembly As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtMouldNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents btnClear As System.Web.UI.WebControls.Button
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
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
        txtOperator_id.Visible = False
        If Page.IsPostBack = False Then
            'Session("UserID") = "072557"
            txtOperator_id.Text = Session("UserID")
            Try
                Dim oChkEmp As New rwfGen.Employee()
                If oChkEmp.Check(Session("UserID"), "MRSMRS") = False Then
                    '  Response.Redirect("../../InvalidSession.aspx")
                End If
                oChkEmp = Nothing
            Catch exp As Exception
                ' Response.Redirect("../../InvalidSession.aspx")
            End Try
            Try
                getDateShift()
                PopulateGrid()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
        ' txtDate.TextMode = TextBoxMode.Date
    End Sub
    Private Sub getDateShift()
        If Now.Hour = 0 OrElse Now.Hour = 1 OrElse Now.Hour = 2 OrElse Now.Hour = 3 OrElse Now.Hour = 4 OrElse Now.Hour = 5 Then
            txtDate.Text = Now.Date.AddDays(-1)
        Else
            txtDate.Text = Now.Date
        End If
        Dim dt As Date
        Dim Shift As String
        dt = Now
        Select Case dt.Hour
            Case 6 To 13
                Shift = "A"
            Case 14 To 21
                Shift = "B"
            Case Else
                Shift = "C"
        End Select
        Dim i As Integer = 0
        rblShift.ClearSelection()
        For i = 0 To rblShift.Items.Count - 1
            If rblShift.Items(i).Text = Shift Then
                rblShift.Items(i).Selected = True
                Exit For
            End If
        Next
        dt = Nothing
        i = Nothing
        Shift = Nothing
        'txtDate.TextMode = TextBoxMode.Date
    End Sub
    Private Sub setobj()
        If Not IsNothing(Session("Mld")) Then Session.Remove("Mld")
        Session.Remove("Mld")
        Dim oMld As New MouldMaster.Moulds()
        Session("Mld") = oMld
        CType(Session("Mld"), MouldMaster.Moulds).ForMouldAssembly = True
        CType(Session("Mld"), MouldMaster.Moulds).MouldDate = txtDate.Text
        PopulateGrid()
        oMld = Nothing
    End Sub
    Private Sub PopulateGrid()
        Dim Dt As DataTable
        grdMouldAssembly.HorizontalAlign = HorizontalAlign.Left
        grdMouldAssembly.Visible = True
        Try
            Dt = MouldMaster.tables.GetMouldAssemblyDetails(CDate(txtDate.Text), rblShift.SelectedItem.Text)
            If Dt.Rows.Count > 5 Then
                grdMouldAssembly.AllowPaging = True
                grdMouldAssembly.PageSize = 5
                grdMouldAssembly.PagerStyle.Mode = PagerMode.NumericPages
            End If

            grdMouldAssembly.DataSource = Dt.DefaultView
            grdMouldAssembly.DataBind()
            If grdMouldAssembly.Items.Count = 0 Then
                lblMessage.Text = "No data binded to the grid."
                grdMouldAssembly.Visible = False
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        Dt = Nothing
    End Sub

    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        lblMessage.Text = ""

        Try
            checkDate()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub checkDate()
        Dim dt As New Date()
        Try
            dt = txtDate.Text.Trim
            If dt > Now.Date Then
                txtDate.Text = ""
                lblMessage.Text = "Date cannot be greater than Current Date"
            Else
                txtDate.Text = dt
                grdMouldAssembly.CurrentPageIndex = 0
                PopulateGrid()
            End If
        Catch exp As Exception
            txtDate.Text = ""
            lblMessage.Text = exp.Message
        End Try
        dt = Nothing
    End Sub
    Private Sub Clear()
        lblMouldType.Text = ""
        lblMouldInit.Text = 0
        lblMouldFinal.Text = 0
        lblGrphiteRmvd.Text = ""
        txtCntIngate.Text = ""
    End Sub
    Private Sub txtMouldNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMouldNumber.TextChanged
        lblMessage.Text = ""
        Clear()
        Dim ds As DataSet
        Try
            setobj()
            CType(Session("Mld"), MouldMaster.Moulds).MouldNumber = txtMouldNumber.Text.Trim
            If CType(Session("Mld"), MouldMaster.Moulds).AllowMouldAssembly Then
                lblMouldType.Text = CType(Session("Mld"), MouldMaster.Moulds).MouldType
                lblMouldInit.Text = CType(Session("Mld"), MouldMaster.Moulds).Before
                lblMouldFinal.Text = CType(Session("Mld"), MouldMaster.Moulds).After
                lblGrphiteRmvd.Text = CType(Session("Mld"), MouldMaster.Moulds).Life
                txtCntIngate.Text = CType(Session("Mld"), MouldMaster.Moulds).IngCnt
            Else
                txtMouldNumber.Text = ""
            End If
            lblMessage.Text = CType(Session("Mld"), MouldMaster.Moulds).Message
        Catch exp As Exception
            lblMessage.Text &= exp.Message
            txtMouldNumber.Text = ""
        End Try
        ds = Nothing
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        If txtMouldNumber.Text.Trim.Length = 0 Then
            lblMessage.Text = "Please enter Mould Number"
            Exit Sub
        End If
        Try
            If CType(Session("Mld"), MouldMaster.Moulds).AllowMouldAssembly Then
                CType(Session("Mld"), MouldMaster.Moulds).MouldDate = CDate(txtDate.Text)
                CType(Session("Mld"), MouldMaster.Moulds).Shift = rblShift.SelectedItem.Text
                CType(Session("Mld"), MouldMaster.Moulds).Operator1 = txtOperator_id.Text
                CType(Session("Mld"), MouldMaster.Moulds).MouldType = lblMouldType.Text
                CType(Session("Mld"), MouldMaster.Moulds).Before = lblMouldInit.Text
                CType(Session("Mld"), MouldMaster.Moulds).After = lblMouldFinal.Text
                CType(Session("Mld"), MouldMaster.Moulds).Life = lblGrphiteRmvd.Text
                CType(Session("Mld"), MouldMaster.Moulds).IngCnt = txtCntIngate.Text
                CType(Session("Mld"), MouldMaster.Moulds).AssembleMould()
                lblMessage.Text = CType(Session("Mld"), MouldMaster.Moulds).Message
                Clear()
                txtMouldNumber.Text = ""
            Else
                lblMessage.Text = CType(Session("Mld"), MouldMaster.Moulds).Message
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            setobj()
        End Try
    End Sub

    Private Sub grdMouldAssembly_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdMouldAssembly.PageIndexChanged
        grdMouldAssembly.CurrentPageIndex = e.NewPageIndex
        grdMouldAssembly.EditItemIndex = -1
        Try
            PopulateGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        lblMouldType.Text = ""
        lblMouldInit.Text = ""
        lblMouldFinal.Text = ""
        lblGrphiteRmvd.Text = ""
        txtCntIngate.Text = ""
    End Sub

    Private Sub rblShift_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblShift.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            checkDate()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub


End Class
