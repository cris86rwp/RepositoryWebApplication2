Public Class MRRejections
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtTappedDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents pnlReasons As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlData As System.Web.UI.WebControls.Panel
    Protected WithEvents rblType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnReason As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtMRXC As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtReason As System.Web.UI.WebControls.TextBox
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblWheelNo As System.Web.UI.WebControls.Label
    Protected WithEvents lblHeatNo As System.Web.UI.WebControls.Label
    Protected WithEvents txtMRRej As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlReasons As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnRemarks As System.Web.UI.WebControls.Button
    Protected WithEvents RadioButtonList1 As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtLIC As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSIC As System.Web.UI.WebControls.TextBox
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList



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
        Session("UserID") = "111111"
        Session("Group") = "MLDING"
        If IsPostBack = False Then
            txtTappedDate.Text = Now.Date
            If IsNothing(Session("UserID")) = True Then
                Response.Redirect("InvalidSession.aspx")
                Exit Sub
            Else
                If Session("UserID") = "111111" Then
                    rblType.Visible = True
                Else
                    rblType.Visible = False
                End If
                SetPanel()
            End If
        End If
    End Sub

    Private Sub SetPanel()
        pnlData.Visible = False
        pnlReasons.Visible = False
        If rblType.SelectedIndex = 0 Then
            pnlData.Visible = True
            GetData()
            txtMRRej.Text = ""
            lblWheelNo.Text = ""
            lblHeatNo.Text = ""
            txtRemarks.Text = ""
            txtLIC.Text = ""
            txtSIC.Text = ""
        Else
            pnlReasons.Visible = True
            txtMRXC.Text = ""
            txtReason.Text = ""
        End If
    End Sub

    Private Sub rblType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblType.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            SetPanel()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub GetData()
        Dim dt As New DataTable()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            dt = RWF.MLDING.GetMRXCWheelDetails(CDate(txtTappedDate.Text))
            DataGrid1.DataSource = dt
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
            dt = Nothing
        End Try
    End Sub

    Private Sub txtTappedDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTappedDate.TextChanged
        lblMessage.Text = ""
        Try
            GetData()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnReason_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReason.Click
        lblMessage.Text = ""
        Dim done As Boolean
        Try
            done = New RWF.MLDING().MRRejectionCodes(txtMRXC.Text.ToUpper.Trim, txtReason.Text.Trim)
            GetMRXCReasons(0)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub GetMRXCReasons(ByVal Type As Integer)
        Dim dt As New DataTable()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        ddlReasons.Items.Clear()
        Try
            If Type = 0 Then
                dt = RWF.MLDING.GetMRXCReasons(txtMRXC.Text.Trim)
                DataGrid2.DataSource = dt
                DataGrid2.DataBind()
            Else
                dt = RWF.MLDING.GetMRXCReasons(txtMRRej.Text.Trim)
                ddlReasons.DataSource = dt
                ddlReasons.DataTextField = dt.Columns(1).ColumnName
                ddlReasons.DataValueField = dt.Columns(2).ColumnName
                ddlReasons.DataBind()
                If dt.Rows.Count = 0 Then
                    Throw New Exception("No XC Reasons data available for the XC type selected!")
                End If
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
            dt = Nothing
        End Try
    End Sub

    Private Sub txtMRXC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMRXC.TextChanged
        lblMessage.Text = ""
        Dim done As Boolean
        Try
            txtMRXC.Text = txtMRXC.Text.ToUpper
            GetMRXCReasons(0)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub DataGrid1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.ItemCommand
        lblMessage.Text = ""
        Select Case e.CommandName
            Case "Select"
                Try
                    txtMRRej.Text = e.Item.Cells(1).Text
                    GetMRXCReasons(1)
                    lblWheelNo.Text = e.Item.Cells(2).Text
                    lblHeatNo.Text = e.Item.Cells(3).Text
                    If ddlReasons.Items.Count = 0 Then
                        lblMessage.Text = "No reasons available for selected XC !"
                        Exit Sub
                    Else
                        Dim i As Integer = 0
                        ddlReasons.ClearSelection()
                        For i = 0 To ddlReasons.Items.Count - 1
                            If e.Item.Cells(6).Text.Trim = ddlReasons.Items(i).Text Then
                                ddlReasons.Items(i).Selected = True
                            End If
                        Next
                    End If
                    txtRemarks.Text = e.Item.Cells(7).Text.Replace("&nbsp;", "")
                    txtLIC.Text = e.Item.Cells(8).Text.Replace("&nbsp;", "")
                    txtSIC.Text = e.Item.Cells(9).Text.Replace("&nbsp;", "")
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                End Try
        End Select

    End Sub

    Private Sub txtMRRej_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMRRej.TextChanged
        lblMessage.Text = ""
        Dim done As Boolean
        Try
            txtMRRej.Text = txtMRRej.Text.ToUpper
            GetMRXCReasons(1)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnRemarks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemarks.Click
        lblMessage.Text = ""
        Dim done As Boolean
        Try
            done = New RWF.MLDING().MRRejRemarks(Val(lblWheelNo.Text), Val(lblHeatNo.Text), ddlReasons.SelectedItem.Value, txtRemarks.Text.Trim, txtLIC.Text.Trim, txtSIC.Text.Trim)
            GetData()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

End Class
