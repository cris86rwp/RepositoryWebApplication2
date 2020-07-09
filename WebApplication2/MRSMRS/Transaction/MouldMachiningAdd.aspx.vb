Public Class MouldMachiningAdd
    Inherits System.Web.UI.Page
    Protected WithEvents lblSlNo As System.Web.UI.WebControls.Label
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents Loss As System.Web.UI.WebControls.Label
    Protected WithEvents txtAfter As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBefore As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblDefect As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtMould As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblMould As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblShift As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblOperator As System.Web.UI.WebControls.Label
    Protected WithEvents ddlRemarks As System.Web.UI.WebControls.DropDownList
    Protected WithEvents rblMachine As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents Eng As System.Web.UI.WebControls.Label
    Protected WithEvents lblLife As System.Web.UI.WebControls.Label
    Protected WithEvents dgMachining As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid3 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
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
        txtBefore.ReadOnly = True
        If Page.IsPostBack = False Then
            rblMould.Enabled = False
            lblLife.Visible = False
            'Session("UserID") = "072557"
            lblOperator.Visible = False
            lblOperator.Text = Session("UserID")
            'Try
            '    Dim oChkEmp As New rwfGen.Employee()
            '    If oChkEmp.Check(Session("UserID"), "MRSMRS") = False Then
            '        ' Response.Redirect("../../InvalidSession.aspx")
            '    End If
            '    lblOperator.Text = Session("UserID")
            '    oChkEmp = Nothing
            'Catch exp As Exception
            '    'Response.Redirect("../../InvalidSession.aspx")
            'End Try
            Try
                getDateShift()
                setobj()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            Try
                fillGrid()
                getRemarks()
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
        i = Nothing
    End Sub
    Private Sub ClearAll()
        txtMould.Text = ""
        txtBefore.Text = ""
        txtAfter.Text = ""
        txtRemarks.Text = ""
        Loss.Text = ""
        lblSlNo.Text = ""
        Eng.Text = ""
        txtBefore.Text = ""
        Eng.Text = ""
        lblLife.Text = ""
    End Sub

    Private Sub setobj()
        ClearAll()
        If Not IsNothing(Session("Mld")) Then Session.Remove("Mld")
        Session.Remove("Mld")
        Dim oMld As New MouldMaster.Moulds()
        Session("Mld") = oMld
        CType(Session("Mld"), MouldMaster.Moulds).ForMouldMachiningAdd = True
        CType(Session("Mld"), MouldMaster.Moulds).MouldDate = txtDate.Text
        CType(Session("Mld"), MouldMaster.Moulds).Shift = rblShift.SelectedItem.Text
        fillGrid()
        oMld = Nothing
    End Sub
    Private Sub getRemarks()
        Dim dt As New DataTable()
        Try
            dt = MouldMaster.tables.GetMRSMachineRemarks
            ddlRemarks.DataSource = dt
            ddlRemarks.DataTextField = "Remarks"
            ddlRemarks.DataValueField = "Remarks"
            ddlRemarks.DataBind()
        Catch exp As Exception
            Throw New Exception("Unable to Machining Remarks Table")
        Finally
            dt.Dispose()
            dt = Nothing
        End Try
    End Sub
    Private Sub fillGrid()
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        dgMachining.DataSource = Nothing
        dgMachining.DataBind()
        Try
            CType(Session("Mld"), MouldMaster.Moulds).Shift = rblShift.SelectedItem.Text
            dgMachining.DataSource = CType(Session("Mld"), MouldMaster.Moulds).MouldMachinigData
            dgMachining.DataBind()
        Catch exp As Exception
            Throw New Exception("Unable to show Mould Machining Details Table")
        Finally
            da.Dispose()
            ds.Dispose()
            ds = Nothing
            da = Nothing
        End Try
    End Sub
    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        lblMessage.Text = ""
        Dim dt As Date
        Try
            dt = CDate(txtDate.Text)
            If dt > Now.Date Then
                lblMessage.Text = "Future date not allowed "
                txtDate.Text = ""
            Else
                CType(Session("Mld"), MouldMaster.Moulds).MouldDate = dt
                txtDate.Text = dt
                fillGrid()
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt = Nothing
        End Try
    End Sub
    Private Sub Clear()
        txtBefore.Text = ""
        Eng.Text = ""
        lblLife.Text = ""
    End Sub
    Private Sub txtMould_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMould.TextChanged
        lblMessage.Text = ""
        Try
            GetHistory()
            Clear()
            CType(Session("Mld"), MouldMaster.Moulds).MouldDate = CDate(txtDate.Text.Trim)
            CType(Session("Mld"), MouldMaster.Moulds).MouldNumber = txtMould.Text.Trim
            lblMessage.Text = "Mould Status : " & CType(Session("Mld"), MouldMaster.Moulds).MouldStatus
            If CType(Session("Mld"), MouldMaster.Moulds).AllowMouldMachiningAdd Then
                Dim i As Integer
                For i = 0 To rblMould.Items.Count - 1
                    If Trim(rblMould.Items(i).Value).ToLower = CType(Session("Mld"), MouldMaster.Moulds).MouldType.ToLower Then
                        rblMould.ClearSelection()
                        rblMould.Items(i).Selected = True
                        Exit For
                    End If
                Next
                If CType(Session("Mld"), MouldMaster.Moulds).engraved_number.Trim.Length > 0 Then
                    Eng.Text = "EngNo : " + CType(Session("Mld"), MouldMaster.Moulds).engraved_number
                End If
                txtBefore.Text = CType(Session("Mld"), MouldMaster.Moulds).Before
                lblLife.Text = CType(Session("Mld"), MouldMaster.Moulds).Life
                lblMessage.Text &= CType(Session("Mld"), MouldMaster.Moulds).Message
                i = Nothing
            End If
        Catch exp As Exception
            lblMessage.Text &= exp.Message
            txtMould.Text = ""
        End Try
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
            da.SelectCommand.Parameters.Add("@MldNo", SqlDbType.VarChar, 50).Value = txtMould.Text.Trim
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
    Private Sub txtBefore_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBefore.TextChanged
        lblMessage.Text = ""
        Loss.Text = ""
        If Val(txtBefore.Text) = 0 Then
            lblMessage.Text = "Please enter mould before height !"
        ElseIf Val(txtAfter.Text) = 0 Then
            lblMessage.Text = "Please enter mould After height !"
        ElseIf Val(txtAfter.Text) > Val(txtBefore.Text) Then
            lblMessage.Text = "Mould after height cannot be greater than before height!"
        Else
            Try
                Loss.Text = Val(txtBefore.Text) - Val(txtAfter.Text)
                CType(Session("Mld"), MouldMaster.Moulds).Before = txtBefore.Text
                CType(Session("Mld"), MouldMaster.Moulds).After = txtAfter.Text
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
    Private Sub txtAfter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAfter.TextChanged
        lblMessage.Text = ""
        Loss.Text = ""
        If Val(txtBefore.Text) <= 0 Then
            lblMessage.Text = "Please enter mould before height !"
        ElseIf Val(txtAfter.Text) <= 0 Then
            lblMessage.Text = "Please enter mould After height !"
        ElseIf Val(txtAfter.Text) > Val(txtBefore.Text) Then
            lblMessage.Text = "Mould after height cannot be greater than before height!"
        Else
            Try
                Loss.BackColor = System.Drawing.Color.Transparent
                txtAfter.BackColor = System.Drawing.Color.Transparent
                Loss.Text = Val(txtBefore.Text) - Val(txtAfter.Text)
                If Val(Loss.Text) > 30 Then
                    Loss.BackColor = System.Drawing.Color.Pink
                    txtAfter.BackColor = System.Drawing.Color.Red
                    lblMessage.Text = "Mould height difference more than 30mm !"
                End If
                CType(Session("Mld"), MouldMaster.Moulds).Before = txtBefore.Text
                CType(Session("Mld"), MouldMaster.Moulds).After = txtAfter.Text
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        Dim i As Integer
        Dim done As Boolean
        For i = 0 To rblDefect.Items.Count - 1
            If rblDefect.Items(i).Selected = True Then
                done = True
                Exit For
            End If
        Next
        If done Then
            i = 0
            done = False
            For i = 0 To rblMachine.Items.Count - 1
                If rblMachine.Items(i).Selected = True Then
                    done = True
                    Exit For
                End If
            Next
            If done = False Then
                lblMessage.Text = "Please select machine code !"
                Exit Sub
            End If
        Else
            lblMessage.Text = "Please select Defect Type !"
            Exit Sub
        End If
        If txtMould.Text.Trim.Length = 0 Then
            lblMessage.Text = "Please enter Mould Number"
            Exit Sub
        ElseIf Val(txtAfter.Text) <= 0 Then
            lblMessage.Text = "Please enter After Ht Value "
            Exit Sub
        ElseIf CType(Session("Mld"), MouldMaster.Moulds).AllowMouldMachiningAdd Then
            CType(Session("Mld"), MouldMaster.Moulds).Operator1 = lblOperator.Text
            CType(Session("Mld"), MouldMaster.Moulds).Shift = rblShift.SelectedItem.Text
            CType(Session("Mld"), MouldMaster.Moulds).Before = txtBefore.Text
            CType(Session("Mld"), MouldMaster.Moulds).After = txtAfter.Text
            CType(Session("Mld"), MouldMaster.Moulds).MachineCode = rblMachine.SelectedItem.Text
            CType(Session("Mld"), MouldMaster.Moulds).Defect = rblDefect.SelectedItem.Text
            If Trim(txtRemarks.Text).Length = 0 Then
                CType(Session("Mld"), MouldMaster.Moulds).Remarks = ddlRemarks.SelectedItem.Text.Trim
            Else
                CType(Session("Mld"), MouldMaster.Moulds).Remarks = ddlRemarks.SelectedItem.Text & "; " & Trim(txtRemarks.Text)
            End If
            CType(Session("Mld"), MouldMaster.Moulds).MouldMachining()
            lblMessage.Text = CType(Session("Mld"), MouldMaster.Moulds).Message
            DataGrid1.DataSource = Nothing
            DataGrid1.DataBind()
            DataGrid2.DataSource = Nothing
            DataGrid2.DataBind()
            DataGrid3.DataSource = Nothing
            DataGrid3.DataBind()
            Try
                setobj()
            Catch exp As Exception
                lblMessage.Text &= exp.Message
            End Try
        Else
            lblMessage.Text = CType(Session("Mld"), MouldMaster.Moulds).Message
        End If
        i = Nothing
        done = Nothing
    End Sub
    Private Sub rblMould_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblMould.SelectedIndexChanged
        lblMessage.Text = ""
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ClearAll()
    End Sub

    Private Sub rblShift_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblShift.SelectedIndexChanged
        lblMessage.Text = ""
        Dim dt As Date
        Try
            dt = CDate(txtDate.Text)
            If dt > Now.Date Then
                lblMessage.Text = "Future date not allowed "
                txtDate.Text = ""
            Else
                CType(Session("Mld"), MouldMaster.Moulds).MouldDate = dt
                txtDate.Text = dt
                fillGrid()
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt = Nothing
        End Try
    End Sub
End Class


