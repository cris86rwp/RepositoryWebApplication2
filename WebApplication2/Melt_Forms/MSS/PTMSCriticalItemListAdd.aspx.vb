Public Class PTMSCriticalItemListAdd
    Inherits System.Web.UI.Page
    Protected WithEvents lblConsignee As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents ddlPlNumber As System.Web.UI.WebControls.DropDownList
    Protected WithEvents dgBOM As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtNum As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDt As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSup As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDD As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRecdQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtQtyUT As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtQtyDue As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents lblType As System.Web.UI.WebControls.Label
    Protected WithEvents lblRecID As System.Web.UI.WebControls.Label
    Protected WithEvents dgSavedData As System.Web.UI.WebControls.DataGrid
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
        lblRecID.Visible = False
        lblType.Visible = False
        If Page.IsPostBack = False Then
            Try
                Dim Group As String = Session("Group")
                Dim strMode As String = Request.QueryString("mode")
                Dim UserId As String = Session("UserID")
                Dim InValid As Boolean = False
                Group = "SSMELT"
                UserId = "074510"
                Try
                    lblConsignee.Text = CriticalItems.ItemTables.GetConsignee(Group, UserId)
                    If lblConsignee.Text.Trim.Length = 4 Then InValid = True
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                End Try
                If Not InValid Then
                    Response.Redirect("/mss/logon.aspx")
                End If
                PopulateDDL(lblConsignee.Text)
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub PopulateDDL(ByVal Consignee As String)
        lblMessage.Text = ""
        ddlPlNumber.DataSource = Nothing
        ddlPlNumber.DataBind()
        Dim dvPLNumber As New DataView()
        Try
            dvPLNumber.Table = CriticalItems.ItemTables.GetProdConsumablesPls(lblConsignee.Text, False, True, False)
            ddlPlNumber.DataSource = dvPLNumber
            ddlPlNumber.DataTextField = dvPLNumber.Table.Columns(0).ColumnName
            ddlPlNumber.DataValueField = dvPLNumber.Table.Columns(1).ColumnName
            ddlPlNumber.DataBind()
            ddlPlNumber.Items.Insert(0, "Select")
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub ClearVal()
        lblType.Visible = False
        lblType.Text = ""
        txtNum.Text = ""
        txtDt.Text = "1900-01-01"
        txtQty.Text = "0"
        txtSup.Text = ""
        txtRecdQty.Text = "0"
        txtQtyUT.Text = "0"
        txtQtyDue.Text = "0"
        txtDD.Text = ""
        txtRemarks.Text = ""
        lblRecID.Text = "0"
    End Sub

    Private Sub ddlPlNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlPlNumber.SelectedIndexChanged
        lblMessage.Text = ""
        dgBOM.DataSource = Nothing
        dgBOM.DataBind()
        If ddlPlNumber.SelectedItem.Text.ToLower = "select" Then
            lblMessage.Text = "Please select PLNumber !"
            Exit Sub
        Else
            Dim ds As New DataSet()
            Try
                ds = CriticalItems.ItemTables.ProdCriticalSelectionList(ddlPlNumber.SelectedItem.Text, lblConsignee.Text.Trim, ddlPlNumber.SelectedItem.Value)
                dgBOM.DataSource = ds.Tables(0).DefaultView
                dgBOM.DataBind()
                PopulateSavedData(ddlPlNumber.SelectedItem.Text.Trim, lblConsignee.Text)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
            End Try
        End If
    End Sub
    Private Sub PopulateSavedData(ByVal PLNumber As String, ByVal Consignee As String)
        dgSavedData.Visible = False
        dgSavedData.DataSource = Nothing
        dgSavedData.DataBind()
        dgSavedData.SelectedIndex = -1
        Dim ds As New DataSet()
        Try
            ds = CriticalItems.ItemTables.ProdCriticalSelectionList(PLNumber, lblConsignee.Text.Trim, ddlPlNumber.SelectedItem.Value)
            dgSavedData.DataSource = ds.Tables(2).DefaultView
            dgSavedData.DataBind()
            If ds.Tables(2).Rows.Count > 0 Then dgSavedData.Visible = True
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            ds.Dispose()
        End Try
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        Dim blnSave As Boolean = False
        Try
            Dim SaveProdList As New CriticalItems.Listing(ddlPlNumber.SelectedItem.Text.Trim, lblConsignee.Text.Trim)
            Try
                SaveProdList.PLID = ddlPlNumber.SelectedItem.Value.Trim
                SaveProdList.Type = lblType.Text.Trim
                SaveProdList.PO = txtNum.Text
                SaveProdList.PODt = IIf(IsDBNull(txtDt.Text.Trim), "1900-01-01", Format(CDate(txtDt.Text.Trim), "yyyy-MM-dd"))
                SaveProdList.POQty = IIf(IsDBNull(txtQty.Text), 0, txtQty.Text)
                SaveProdList.PODD = IIf(IsDBNull(txtDD.Text.Trim), "", txtDD.Text.Trim)
                SaveProdList.POSup = txtSup.Text.Trim
                SaveProdList.RecdQty = IIf(IsDBNull(txtRecdQty.Text), 0, txtRecdQty.Text)
                SaveProdList.QtyUT = IIf(IsDBNull(txtQtyUT.Text), 0, txtQtyUT.Text)
                SaveProdList.QtyDue = IIf(IsDBNull(txtQtyDue.Text), 0, txtQtyDue.Text)
                SaveProdList.Remarks = txtRemarks.Text.Trim.ToUpper & ""
                SaveProdList.Selected = False
                SaveProdList.DeleteStatus = False
                SaveProdList.RecID = lblRecID.Text
                If SaveProdList.SaveProdCriticalList(SaveProdList.RecID) Then
                    blnSave = True
                    ClearVal()
                End If
                PopulateSavedData(ddlPlNumber.SelectedItem.Text.Trim, lblConsignee.Text)
            Catch exp As Exception
                lblMessage.Text = exp.Message
            Finally
                SaveProdList = Nothing
            End Try
            If blnSave Then
                lblMessage.Text = " DATA Saved !"
            Else
                lblMessage.Text = " Data not saved !" & SaveProdList.Message
            End If
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try

    End Sub

    Private Sub dgSavedData_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgSavedData.ItemCommand
        lblMessage.Text = ""
        ClearVal()
        Try
            Select Case e.CommandName
                Case "Select"
                    lblType.Text = e.Item.Cells(1).Text.Trim
                    txtNum.Text = e.Item.Cells(2).Text.Trim
                    txtDt.Text = e.Item.Cells(3).Text.Trim
                    txtQty.Text = e.Item.Cells(4).Text.Trim
                    txtSup.Text = e.Item.Cells(6).Text.Trim
                    txtDD.Text = IIf(IsDBNull(e.Item.Cells(5).Text.Trim), "", e.Item.Cells(5).Text.Trim).Replace("&nbsp;", "0")
                    txtRecdQty.Text = IIf(IsDBNull(e.Item.Cells(7).Text.Trim), "0.000", e.Item.Cells(7).Text.Trim).Replace("&nbsp;", "0")
                    txtQtyUT.Text = IIf(IsDBNull(e.Item.Cells(8).Text.Trim), "0.000", e.Item.Cells(8).Text.Trim).Replace("&nbsp;", "0")
                    txtQtyDue.Text = IIf(IsDBNull(e.Item.Cells(9).Text.Trim), "0.000", e.Item.Cells(9).Text.Trim).Replace("&nbsp;", "0")
                    txtRemarks.Text = e.Item.Cells(10).Text.Trim.Replace("&nbsp;", "")
                    lblRecID.Text = e.Item.Cells(11).Text
            End Select
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
End Class
