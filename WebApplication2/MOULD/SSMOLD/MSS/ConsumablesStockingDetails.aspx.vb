Public Class ConsumablesStockingDetails
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtPlNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtReqQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents lblPlDesc As System.Web.UI.WebControls.Label
    Protected WithEvents lblRecoupType As System.Web.UI.WebControls.Label
    Protected WithEvents lblRecoupQty As System.Web.UI.WebControls.Label
    Protected WithEvents lblUnitName As System.Web.UI.WebControls.Label
    Protected WithEvents lblConsignee As System.Web.UI.WebControls.Label
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents dgRecoup As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblSlNo As System.Web.UI.WebControls.Label
    Protected WithEvents txtQtyDesc As System.Web.UI.WebControls.TextBox
    Protected WithEvents dgAll As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtExistingQty As System.Web.UI.WebControls.TextBox

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
        lblSlNo.Visible = False
        If Page.IsPostBack = False Then
            Try
                txtDate.Text = Now.Date
                Dim Group As String = Session("Group")
                Dim strMode As String = Request.QueryString("mode")
                Dim UserId As String = Session("UserID")
                Dim InValid As Boolean = False
                ''''''''''''''''
                Group = "SSMOLD"
                UserId = "073533"
                ''''''''''''''''
                Try
                    lblConsignee.Text = CriticalItems.ItemTables.GetConsignee(Group, UserId)
                    If lblConsignee.Text.Trim.Length = 4 Then InValid = True
                    GetPlDetails()
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                End Try
                If Not InValid Then
                    Response.Redirect("/wap/logon.aspx")
                End If
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
    Private Sub Clear()
        lblSlNo.Text = ""
        lblPlDesc.Text = ""
        lblRecoupType.Text = ""
        lblRecoupQty.Text = ""
        lblUnitName.Text = ""
        txtExistingQty.Text = ""
        txtQtyDesc.Text = ""
    End Sub
    Private Sub txtPlNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPlNumber.TextChanged
        lblMessage.Text = ""
        Try
            GetPlDetails()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub GetPlDetails()
        dgRecoup.DataSource = Nothing
        dgRecoup.DataBind()
        dgAll.DataSource = Nothing
        dgAll.DataBind()
        Dim ds As New DataSet()
        Try
            ds = CriticalItems.ItemTables.PLRecoupDetails(IIf((txtPlNumber.Text.Trim.Length = 0), "", txtPlNumber.Text.Trim), lblConsignee.Text)
            If ds.Tables(0).Rows.Count > 0 Then
                lblPlDesc.Text = ds.Tables(0).Rows(0)("PlDesc")
                lblRecoupType.Text = ds.Tables(0).Rows(0)("RecoupType")
                lblRecoupQty.Text = ds.Tables(0).Rows(0)("RecoupQty")
                lblUnitName.Text = ds.Tables(0).Rows(0)("UnitName")
                txtExistingQty.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("ExistingQty")), "0.0", ds.Tables(0).Rows(0)("ExistingQty"))
                txtQtyDesc.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("QtyDesc")), "", ds.Tables(0).Rows(0)("QtyDesc"))
                dgRecoup.DataSource = ds.Tables(1)
                dgRecoup.DataBind()
            End If
            If IsNothing(dgAll.CurrentPageIndex) Then dgAll.CurrentPageIndex = 0
            'If ds.Tables(0).Rows.Count > 5 Then
            '    dgAll.AllowPaging = True
            '    dgAll.PageSize = 3
            '    dgAll.PagerStyle.Mode = PagerMode.NumericPages
            'End If
            dgAll.DataSource = ds.Tables(2)
            dgAll.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub txtReqQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReqQty.TextChanged
        lblMessage.Text = ""
        Try
            If Val(txtReqQty.Text) <= 0 Then
                txtReqQty.Text = ""
                lblMessage.Text = "Required Value cannot be less than or equal to Zero"
            End If
        Catch exp As Exception
            txtReqQty.Text = ""
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        Dim blnSave As Boolean = False
        Try
            Dim SaveRecoupDetails As New CriticalItems.Listing(lblConsignee.Text.Trim)
            Try
                SaveRecoupDetails.PLNumber = txtPlNumber.Text.Trim
                SaveRecoupDetails.Consignee = lblConsignee.Text
                SaveRecoupDetails.ReqDate = CDate(txtDate.Text)
                SaveRecoupDetails.RecoupType = lblRecoupType.Text.Trim
                SaveRecoupDetails.RecoupQty = Val(lblRecoupQty.Text)
                SaveRecoupDetails.UnitName = lblUnitName.Text.Trim
                SaveRecoupDetails.ExistingQty = Val(txtExistingQty.Text)
                SaveRecoupDetails.QtyDesc = txtQtyDesc.Text.Trim
                SaveRecoupDetails.QtyReq = Val(txtReqQty.Text)
                SaveRecoupDetails.Remarks = txtRemarks.Text.Trim & ""
                If SaveRecoupDetails.SavePLRecoupDetails(lblConsignee.Text, txtPlNumber.Text, Val(lblSlNo.Text)) Then
                    blnSave = True
                    If Val(lblSlNo.Text) = 0 Then
                        GetPlDetails()
                        txtPlNumber.Text = ""
                        txtRemarks.Text = ""
                    Else
                        txtPlNumber.Text = ""
                        txtRemarks.Text = ""
                        txtReqQty.Text = ""
                        dgAll.SelectedIndex = -1
                        GetPlDetails()
                        lblSlNo.Text = 0
                    End If
                    Clear()
                End If
            Catch exp As Exception
                lblMessage.Text = SaveRecoupDetails.Message & exp.Message
            Finally
                SaveRecoupDetails = Nothing
            End Try
            If blnSave Then
                lblMessage.Text = " DATA Saved !"
            Else
                lblMessage.Text &= " ; Data not saved !"
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub dgRecoup_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgRecoup.ItemCommand
        lblMessage.Text = ""
        lblSlNo.Text = ""
        Try
            Select Case e.CommandName
                Case "Delete"
                    lblSlNo.Text = e.Item.Cells(11).Text.Trim
                    Dim blnSave As Boolean = False
                    Dim SaveRecoupDetails As New CriticalItems.Listing(lblConsignee.Text.Trim)
                    Try
                        SaveRecoupDetails.PLNumber = txtPlNumber.Text.Trim
                        SaveRecoupDetails.Consignee = lblConsignee.Text
                        If SaveRecoupDetails.SavePLRecoupDetails(lblConsignee.Text, txtPlNumber.Text, lblSlNo.Text, True) Then
                            blnSave = True
                            GetPlDetails()
                            txtPlNumber.Text = ""
                            txtRemarks.Text = ""
                            Clear()
                        End If
                    Catch exp As Exception
                        lblMessage.Text = SaveRecoupDetails.Message & exp.Message
                    Finally
                        SaveRecoupDetails = Nothing
                    End Try
                    If blnSave Then
                        lblMessage.Text = " DATA Saved !"
                    Else
                        lblMessage.Text &= " ; Data not saved !"
                    End If
            End Select
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        lblMessage.Text = ""
        Dim dt As Date
        Try
            dt = CDate(txtDate.Text)
        Catch exp As Exception
            txtDate.Text = ""
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub dgAll_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgAll.ItemCommand
        lblMessage.Text = ""
        lblSlNo.Text = ""
        Try
            Select Case e.CommandName
                Case "Select"
                    txtDate.Text = e.Item.Cells(1).Text.Trim
                    txtPlNumber.Text = e.Item.Cells(2).Text.Trim
                    lblPlDesc.Text = e.Item.Cells(3).Text.Trim
                    lblRecoupType.Text = e.Item.Cells(4).Text.Trim
                    lblRecoupQty.Text = e.Item.Cells(5).Text.Trim
                    lblUnitName.Text = e.Item.Cells(6).Text.Trim
                    txtExistingQty.Text = e.Item.Cells(7).Text.Trim
                    txtQtyDesc.Text = e.Item.Cells(8).Text.Trim.Replace("&nbsp;", "")
                    txtReqQty.Text = e.Item.Cells(9).Text.Trim
                    txtRemarks.Text = e.Item.Cells(10).Text.Trim.Replace("&nbsp;", "")
                    lblSlNo.Text = e.Item.Cells(11).Text.Trim
            End Select
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub


    'Private Sub dgAll_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgAll.PageIndexChanged
    '    lblMessage.Text = ""
    '    Try
    '        dgAll.CurrentPageIndex = e.NewPageIndex
    '        dgAll.EditItemIndex = -1
    '        GetPlDetails()
    '    Catch exp As Exception
    '        lblMessage.Text = exp.Message
    '    End Try
    'End Sub
End Class
