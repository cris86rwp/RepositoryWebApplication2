Public Class mouldReceiptAdd
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents rblShift As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtMouldNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMouldType As System.Web.UI.WebControls.Label
    Protected WithEvents txtOperator_id As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMldLife As System.Web.UI.WebControls.Label
    Protected WithEvents lblIngLife As System.Web.UI.WebControls.Label
    Protected WithEvents txtGrPhiteHt As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblStatus As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents grdMouldReceipt As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid3 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnClear As System.Web.UI.WebControls.Button
    Protected WithEvents txtWhlsCast As System.Web.UI.WebControls.TextBox
    Protected WithEvents Panel2 As System.Web.UI.WebControls.Panel
    Protected WithEvents DataGrid4 As System.Web.UI.WebControls.DataGrid
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
        themeValue = dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        Panel2.Visible = False
        txtOperator_id.Visible = False
        If Page.IsPostBack = False Then
            'Session("UserID") = "072557"
            txtOperator_id.Text = Session("UserID")
            'Try
            '    Dim oChkEmp As New rwfGen.Employee()
            '    If oChkEmp.Check(Session("UserID"), "MRSMRS") = False Then
            '        'Response.Redirect("../../InvalidSession.aspx")
            '    End If
            '    oChkEmp = Nothing
            'Catch exp As Exception
            '    'Response.Redirect("../../InvalidSession.aspx")
            'End Try
            Try
                getDateShift()
                PopulateGrid()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
    Private Sub getDateShift()
        If Now.Hour = 0 OrElse Now.Hour = 1 OrElse Now.Hour = 2 OrElse Now.Hour = 3 OrElse Now.Hour = 4 OrElse Now.Hour = 5 Then
            txtDate.Text = CDate(Now.Date.AddDays(-1))
        Else
            txtDate.Text = CDate(Now.Date)
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
        Shift = Nothing
        i = Nothing
    End Sub
    Private Sub setobj()
        If Not IsNothing(Session("Mld")) Then Session.Remove("Mld")
        Session.Remove("Mld")
        Dim oMld As New MouldMaster.Moulds()
        Session("Mld") = oMld
        CType(Session("Mld"), MouldMaster.Moulds).ForMouldReceipt = True
        CType(Session("Mld"), MouldMaster.Moulds).MouldDate = txtDate.Text
        PopulateGrid()
        oMld = Nothing
    End Sub
    Sub PopulateGrid()
        Dim Dt As DataTable
        grdMouldReceipt.HorizontalAlign = HorizontalAlign.Left
        grdMouldReceipt.Visible = True
        Try
            Dt = MouldMaster.tables.getMouldReceiptDetails(CDate(txtDate.Text), rblShift.SelectedItem.Text)
            grdMouldReceipt.DataSource = Dt.DefaultView
            grdMouldReceipt.DataBind()
            If grdMouldReceipt.Items.Count = 0 Then
                lblMessage.Text = "No data for the given date and shift !"
                grdMouldReceipt.Visible = False
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
        lblMldLife.Text = 0
        lblIngLife.Text = 0
        txtGrPhiteHt.Text = ""
        txtWhlsCast.Text = ""
        txtRemarks.Text = ""
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        DataGrid3.DataSource = Nothing
        DataGrid3.DataBind()
    End Sub

    Private Sub txtMouldNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMouldNumber.TextChanged
        lblMessage.Text = ""
        Clear()
        Dim ds As DataSet
        Try
            setobj()
            GetHistory()
            CType(Session("Mld"), MouldMaster.Moulds).MouldNumber = txtMouldNumber.Text.Trim
            If CType(Session("Mld"), MouldMaster.Moulds).AllowMouldReceiptAdd Then
                lblMouldType.Text = CType(Session("Mld"), MouldMaster.Moulds).MouldType
                lblMldLife.Text = CType(Session("Mld"), MouldMaster.Moulds).Before
                lblIngLife.Text = CType(Session("Mld"), MouldMaster.Moulds).After
                txtGrPhiteHt.Text = CType(Session("Mld"), MouldMaster.Moulds).Life
                txtWhlsCast.Text = CType(Session("Mld"), MouldMaster.Moulds).WheelsCast

            Else
                txtMouldNumber.Text = ""
            End If
            lblMessage.Text = CType(Session("Mld"), MouldMaster.Moulds).Message
            GetMRReasons()
        Catch exp As Exception
            GetMRreasons(True)
            lblMessage.Text &= exp.Message
            txtMouldNumber.Text = ""
        End Try
        ds = Nothing
    End Sub

    Private Sub GetMRreasons(Optional ByVal Err As Boolean = False)
        DataGrid4.DataSource = Nothing
        DataGrid4.DataBind()
        Dim Dt As DataTable
        Try
            If Err Then
                Dt = MouldMaster.MRSMRS.TopReceipt(txtMouldNumber.Text.Trim)
            Else
                Dt = MouldMaster.MRSMRS.MRReasons(CType(Session("Mld"), MouldMaster.Moulds).MouldNumber)
            End If
            DataGrid4.DataSource = Dt.DefaultView
            DataGrid4.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        Dt = Nothing
    End Sub

    Private Sub GetHistory()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        DataGrid3.DataSource = Nothing
        DataGrid3.DataBind()
        DataGrid4.DataSource = Nothing
        DataGrid4.DataBind()
        Dim ds As New DataSet()
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Try
            da.SelectCommand.CommandText = "mm_sp_MouldHistory"
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.Add("@MldNo", SqlDbType.VarChar, 50).Value = txtMouldNumber.Text.Trim
            da.Fill(ds)
            DataGrid1.DataSource = ds.Tables(1)
            DataGrid1.DataBind()
            DataGrid2.DataSource = ds.Tables(2)
            DataGrid2.DataBind()
            DataGrid3.DataSource = ds.Tables(3)
            DataGrid3.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            da.Dispose()
            ds.Dispose()
            ds = Nothing
            da = Nothing
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        If txtMouldNumber.Text.Trim.Length = 0 Then
            lblMessage.Text = "Please enter Mould Number"
            Exit Sub
        End If
        Try
            If CType(Session("Mld"), MouldMaster.Moulds).AllowMouldReceiptAdd Then
                CType(Session("Mld"), MouldMaster.Moulds).MouldDate = CDate(txtDate.Text)
                CType(Session("Mld"), MouldMaster.Moulds).Shift = rblShift.SelectedItem.Text
                CType(Session("Mld"), MouldMaster.Moulds).Operator1 = txtOperator_id.Text
                CType(Session("Mld"), MouldMaster.Moulds).MouldType = lblMouldType.Text
                CType(Session("Mld"), MouldMaster.Moulds).MouldStatus = rblStatus.SelectedItem.Value
                CType(Session("Mld"), MouldMaster.Moulds).Life = txtGrPhiteHt.Text
                CType(Session("Mld"), MouldMaster.Moulds).WheelsCast = txtWhlsCast.Text
                CType(Session("Mld"), MouldMaster.Moulds).Remarks = txtRemarks.Text.Trim
                CType(Session("Mld"), MouldMaster.Moulds).MouldLife = lblMldLife.Text
                CType(Session("Mld"), MouldMaster.Moulds).IngateLife = lblIngLife.Text
                CType(Session("Mld"), MouldMaster.Moulds).ReceiveMould()
                lblMessage.Text = CType(Session("Mld"), MouldMaster.Moulds).Message
                Clear()
            Else
                lblMessage.Text = CType(Session("Mld"), MouldMaster.Moulds).Message
            End If
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        Finally
            setobj()
        End Try
    End Sub

    Private Sub rblShift_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblShift.SelectedIndexChanged
        lblMessage.Text = ""
        PopulateGrid()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtMouldNumber.Text = ""
        Clear()
    End Sub

    Protected Sub txtdate_TextChanged1(sender As Object, e As EventArgs) Handles txtDate.TextChanged

    End Sub
End Class
