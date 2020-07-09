Public Class MouldPosition
    Inherits System.Web.UI.Page
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblShift As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblMould As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents ddlWhlType As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtValue As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblSlNo As System.Web.UI.WebControls.Label
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Panel2 As System.Web.UI.WebControls.Panel
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents txtFromDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtToDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblTranType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid3 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtMouldNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Shared themeValue As String


    Private Sub Page_PreInit(ByVal sender As Object, ByVal e As EventArgs)

        Page.Theme = themeValue
    End Sub

    Protected Sub dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        Session("UserID") = "016002"
        lblSlNo.Visible = False
        If Page.IsPostBack = False Then
            Try
                txtDate.Text = Now.Date
                txtFromDate.Text = Now.Date
                txtToDate.Text = Now.Date
                PopulateDdl()
                FillGrid()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            SetFocus(txtDate)
        End If
    End Sub
    'Private Sub SetFocus(ByVal ctrl As Control)
    '    Dim focusScript As String = "<script language=" & "javascript" & " > " & _
    '    "document.getElementById('" + ctrl.ClientID.ToString.Trim & _
    '    "').focus();</script>"
    '    Page.RegisterStartupScript("FocusScript", focusScript)
    'End Sub
    Private Sub PopulateDdl()
        Dim ds As New DataSet()
        Try
            ds = RWF.MLDING.MouldPositionData
            ddlWhlType.DataSource = ds.Tables(0).DefaultView
            ddlWhlType.DataTextField = ds.Tables(0).Columns("WhlType").ColumnName
            ddlWhlType.DataValueField = ds.Tables(0).Columns("WhlType").ColumnName
            ddlWhlType.DataBind()

            rblTranType.DataSource = ds.Tables(1).DefaultView
            rblTranType.DataTextField = ds.Tables(1).Columns("TransName").ColumnName
            rblTranType.DataValueField = ds.Tables(1).Columns("TransNo").ColumnName
            rblTranType.DataBind()
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            ds.Dispose()
            ds = Nothing
        End Try
    End Sub
    Private Sub FillGrid()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        lblSlNo.Text = ""
        txtValue.Text = ""
        Dim ds As New DataSet()
        Try
            ds = RWF.MLDING.MouldPosition(CDate(txtDate.Text), rblShift.SelectedItem.Text, rblType.SelectedItem.Text, rblMould.SelectedItem.Text, ddlWhlType.SelectedItem.Text)
            If ds.Tables(0).Rows.Count > 0 Then
                DataGrid1.DataSource = ds.Tables(0)
                DataGrid1.DataBind()
            End If
            If ds.Tables(1).Rows.Count > 0 Then
                txtValue.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)("Value")), 0, ds.Tables(1).Rows(0)("Value"))
                lblSlNo.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)("SlNo")), 0, ds.Tables(1).Rows(0)("SlNo"))
            End If
            If ds.Tables(2).Rows.Count > 0 Then
                DataGrid2.DataSource = ds.Tables(2)
                DataGrid2.DataBind()
            End If
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            ds.Dispose()
            ds = Nothing
        End Try
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim done As New Boolean()
        Try
            done = New RWF.MLDING().MouldPositionAdd(CDate(txtDate.Text), rblShift.SelectedItem.Value, rblType.SelectedItem.Value, rblMould.SelectedItem.Value, ddlWhlType.SelectedItem.Value.Trim, Val(txtValue.Text))
        Catch exp As Exception
            done = False
            lblMessage.Text = "Adding of Mould Position values failed ; " & exp.Message
        End Try
        If done Then
            lblMessage.Text = "Mould Position Saved ! "
            Try
                FillGrid()
            Catch exp As Exception
                lblMessage.Text &= exp.Message
            End Try
            done = Nothing
        Else
            lblMessage.Text = "Mould Position Saving failed ! "
        End If
        SetFocus(rblType)
        done = Nothing
    End Sub

    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        lblMessage.Text = ""
        Try
            If CDate(txtDate.Text) > Now.Date Then
                lblMessage.Text = "Future Date not allowed !"
                txtDate.Text = ""
            Else
                txtDate.Text = CDate(txtDate.Text)
                FillGrid()
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        SetFocus(rblShift)
    End Sub

    Private Sub rblShift_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblShift.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            FillGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        SetFocus(rblType)
    End Sub

    Private Sub rblType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblType.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            FillGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        SetFocus(rblMould)
    End Sub

    Private Sub rblMould_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblMould.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            FillGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        SetFocus(ddlWhlType)
    End Sub

    Private Sub ddlWhlType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlWhlType.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            FillGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        SetFocus(txtValue)
    End Sub

    Private Sub txtValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtValue.TextChanged
        lblMessage.Text = ""
        Try
            txtValue.Text = Val(txtValue.Text)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        SetFocus(btnSave)
    End Sub

    Private Sub DataGrid1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.ItemCommand
        lblMessage.Text = ""
        Select Case e.CommandName
            Case "Delete"
                Dim Done As Boolean
                Try
                    Done = New RWF.MLDING().DeleteMouldPosition(e.Item.Cells(5).Text)
                Catch exp As Exception
                    lblMessage.Text = " InValid Data !"
                    Exit Sub
                End Try
                If Done Then
                    lblMessage.Text = " Deletion Successful !"
                    Try
                        DataGrid1.CurrentPageIndex = 0
                        FillGrid()
                    Catch exp As Exception
                        lblMessage.Text = exp.Message
                    End Try
                End If
                Done = Nothing
        End Select
        SetFocus(txtValue)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        lblMessage.Text = ""
        DataGrid3.DataSource = Nothing
        DataGrid3.DataBind()
        Dim dt As New DataTable()
        Try
            DataGrid3.DataSource = RWF.MLDING.MouldTrans(CDate(txtFromDate.Text), CDate(txtToDate.Text), rblTranType.SelectedItem.Value, "")
            DataGrid3.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
            dt = Nothing
        End Try
    End Sub

    Private Sub rblTranType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblTranType.SelectedIndexChanged
        lblMessage.Text = ""
        DataGrid3.DataSource = Nothing
        DataGrid3.DataBind()
    End Sub

    Private Sub txtMouldNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMouldNo.TextChanged
        lblMessage.Text = ""
        DataGrid3.DataSource = Nothing
        DataGrid3.DataBind()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        lblMessage.Text = ""
        DataGrid3.DataSource = Nothing
        DataGrid3.DataBind()
        Dim dt As New DataTable()
        Try
            DataGrid3.DataSource = RWF.MLDING.MouldTrans(CDate(txtFromDate.Text), CDate(txtToDate.Text), 0, txtMouldNo.Text.Trim)
            DataGrid3.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
            dt = Nothing
        End Try
    End Sub
End Class