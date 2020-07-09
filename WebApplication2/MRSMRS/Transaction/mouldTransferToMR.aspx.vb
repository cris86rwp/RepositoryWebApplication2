Public Class mouldTransferToMR
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblShift As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtMouldNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblOperator As System.Web.UI.WebControls.Label
    Protected WithEvents lblMouldType As System.Web.UI.WebControls.Label
    Protected WithEvents lblMouldStatus As System.Web.UI.WebControls.Label
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblReceipt_date As System.Web.UI.WebControls.Label
    Protected WithEvents lblRetainerHt As System.Web.UI.WebControls.Label
    Protected WithEvents txtMouldRetainerHt As System.Web.UI.WebControls.TextBox
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents btnClear As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid3 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgTransfer As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgPO As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
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
        txtMouldRetainerHt.Visible = False
        lblRetainerHt.Visible = False
        If Page.IsPostBack = False Then
            'Session("UserID") = "072557"
            'Try
            '    Dim oChkEmp As New rwfGen.Employee()
            '    If oChkEmp.Check(Session("UserID"), "MRSMRS") = False Then
            '        'Response.Redirect("../../InvalidSession.aspx")
            '        Response.Redirect("InvalidSession.aspx")
            '    End If
            lblOperator.Text = Session("UserID")
            '    oChkEmp = Nothing
            'Catch exp As Exception
            '    'Response.Redirect("../../InvalidSession.aspx")
            '    Response.Redirect("InvalidSession.aspx")
            'End Try
            Try
                getDateShift()
                setobj()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
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
        Shift = Nothing
    End Sub
    Private Sub setobj()
        If Not IsNothing(Session("Mld")) Then Session.Remove("Mld")
        Session.Remove("Mld")
        Dim oMld As New MouldMaster.Moulds()
        Session("Mld") = oMld
        CType(Session("Mld"), MouldMaster.Moulds).ForTransferToMR = True
        CType(Session("Mld"), MouldMaster.Moulds).MouldDate = txtDate.Text
        fillgrid()
        oMld = Nothing
    End Sub
    Private Sub fillgrid()
        dgTransfer.DataSource = Nothing
        dgTransfer.DataBind()
        dgPO.DataSource = Nothing
        dgPO.DataBind()
        Dim dt As New DataTable()
        Dim dt1 As New DataTable()
        Try
            dt = CType(Session("Mld"), MouldMaster.Moulds).TransferMouldsSavedData
            dt1 = CType(Session("Mld"), MouldMaster.Moulds).TransferMouldsWithoutPOSavedData
            dgTransfer.DataSource = dt
            dgTransfer.DataBind()
            dgPO.DataSource = dt1
            dgPO.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
            dt1.Dispose()
            dt = Nothing
            dt1 = Nothing
        End Try
    End Sub
    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        lblMessage.Text = ""
        Dim dt As New Date()
        Try
            dt = txtDate.Text.Trim
            If dt > Now.Date Then
                txtDate.Text = ""
                lblMessage.Text = "Date cannot be greater than Current Date"
            Else
                CType(Session("Mld"), MouldMaster.Moulds).MouldDate = dt
                txtDate.Text = dt
                fillgrid()
            End If
        Catch exp As Exception
            txtDate.Text = ""
            lblMessage.Text = exp.Message
        End Try
        dt = Nothing
    End Sub
    Private Sub Clear()
        lblMouldType.Text = ""
        lblMouldStatus.Text = ""
        lblReceipt_date.Text = ""
        txtMouldRetainerHt.Text = ""
        txtRemarks.Text = "OK"
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        DataGrid3.DataSource = Nothing
        DataGrid3.DataBind()
    End Sub

    Private Sub GetHistory()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        DataGrid3.DataSource = Nothing
        DataGrid3.DataBind()
        Dim ds As New DataSet()
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Try
            da.SelectCommand.CommandText = "mm_sp_MouldHistory"
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.Add("@MldNo", SqlDbType.VarChar, 50).Value = txtMouldNumber.Text.Trim
            da.Fill(ds)
            DataGrid3.DataSource = ds.Tables(1)
            DataGrid3.DataBind()
            DataGrid2.DataSource = ds.Tables(2)
            DataGrid2.DataBind()
            DataGrid1.DataSource = ds.Tables(3)
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            da.Dispose()
            ds.Dispose()
            ds = Nothing
            da = Nothing
        End Try
    End Sub

    Private Sub txtMouldNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMouldNumber.TextChanged
        lblMessage.Text = ""
        Try
            Clear()
            GetHistory()
            CType(Session("Mld"), MouldMaster.Moulds).MouldDate = CDate(txtDate.Text.Trim)
            CType(Session("Mld"), MouldMaster.Moulds).MouldNumber = txtMouldNumber.Text.Trim
            lblMouldType.Text = CType(Session("Mld"), MouldMaster.Moulds).MouldType
            lblMouldStatus.Text = CType(Session("Mld"), MouldMaster.Moulds).MouldStatus
            txtRemarks.Text = IIf(CType(Session("Mld"), MouldMaster.Moulds).Remarks.Trim = "", "OK", CType(Session("Mld"), MouldMaster.Moulds).Remarks)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        If txtMouldNumber.Text.Trim.Length = 0 Then
            lblMessage.Text = "Please enter Mould Number"
            Exit Sub
        End If
        Try
            CType(Session("Mld"), MouldMaster.Moulds).Shift = rblShift.SelectedItem.Text
            CType(Session("Mld"), MouldMaster.Moulds).Operator1 = lblOperator.Text
            If CType(Session("Mld"), MouldMaster.Moulds).AllowTransferToMR Then
                CType(Session("Mld"), MouldMaster.Moulds).Remarks = txtRemarks.Text.Trim
                CType(Session("Mld"), MouldMaster.Moulds).TransferMouldToMR()
                lblMessage.Text = CType(Session("Mld"), MouldMaster.Moulds).Message
                Clear()
            Else
                lblMessage.Text = CType(Session("Mld"), MouldMaster.Moulds).Message
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            setobj()
        End Try
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtMouldNumber.Text = ""
        Clear()
    End Sub

    Private Sub rblShift_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblShift.SelectedIndexChanged
        lblMessage.Text = ""
        Dim dt As New Date()
        Try
            dt = txtDate.Text.Trim
            If dt > Now.Date Then
                txtDate.Text = ""
                lblMessage.Text = "Date cannot be greater than Current Date"
            Else
                CType(Session("Mld"), MouldMaster.Moulds).MouldDate = dt
                txtDate.Text = dt
                CType(Session("Mld"), MouldMaster.Moulds).Shift = rblShift.SelectedItem.Text
                fillgrid()
            End If
        Catch exp As Exception
            txtDate.Text = ""
            lblMessage.Text = exp.Message
        End Try
        dt = Nothing
    End Sub
End Class
