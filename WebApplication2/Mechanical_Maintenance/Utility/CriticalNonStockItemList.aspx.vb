Public Class CriticalNonStockItemList
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtPlNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSlNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblPlDesc As System.Web.UI.WebControls.Label
    Protected WithEvents txtEquip As System.Web.UI.WebControls.TextBox
    Protected WithEvents dgPLOutstanding As System.Web.UI.WebControls.DataGrid
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
    Protected WithEvents lblUnitName As System.Web.UI.WebControls.Label
    Protected WithEvents lblType As System.Web.UI.WebControls.Label
    Protected WithEvents lblConsignee As System.Web.UI.WebControls.Label
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
        'Session("Group") = "MW2"
        'Session("UserId") = "078844"
        If Page.IsPostBack = False Then
            lblMessage.Text = ""
            Dim Group As String = Session("Group")
            '' Dim strMode As String = Request.QueryString("mode")
            Dim strMode As String = "add"
            Dim UserId As String = Session("UserID")
            Dim InValid As Boolean = False
            Try
                lblConsignee.Text = CriticalItems.ItemTables.GetConsignee(Group, UserId)
                If lblConsignee.Text.Trim.Length = 4 Then InValid = True
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            If Not InValid Then
                ' Response.Redirect("/wap/logon.aspx")
            End If
            ClearPLVal()
            ClearVal()
            dgPLOutstanding.DataSource = Nothing
            dgPLOutstanding.DataBind()
            'Literal1.Text = "<marquee id=" & "MyMarquee" & "behavior=" & "scroll" & " direction=" & "right" & ">" & sname & " </marquee>"
            'Label1.Text = "<marquee id=" & "MyMarquee" & "behavior=" & "scroll" & " direction=" & "right" & ">" & sname & " </marquee>"
        End If
    End Sub
    Private Sub PopulateSavedData(ByVal PLNumber As String, ByVal Consignee As String)
        dgSavedData.Visible = False
        dgSavedData.DataSource = Nothing
        dgSavedData.DataBind()
        Dim ds As New DataSet()
        Dim dv As New DataView()
        Try
            ds = CriticalItems.ItemTables.SavedCriticalList(PLNumber, lblConsignee.Text.Trim)
            dgSavedData.DataSource = ds.Tables(0).DefaultView
            dgSavedData.DataBind()
            If ds.Tables(0).Rows.Count > 0 Then dgSavedData.Visible = True
            If ds.Tables(1).Rows(0)(0) > 0 Then
                lblMessage.Text = " There are " & ds.Tables(1).Rows(0)(0) & " item(s) in deleted list. "
            End If
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            dv.Dispose()
        End Try
    End Sub

    Private Sub txtPlNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPlNumber.TextChanged
        lblMessage.Text = ""
        ClearVal()
        dgPLOutstanding.DataSource = Nothing
        dgPLOutstanding.DataBind()
        dgPLOutstanding.SelectedIndex = -1
        Dim ds As New DataSet()
        If txtPlNumber.Text.Trim.Length <> 8 Then
            lblMessage.Text = "Invalid PL Number : '" & txtPlNumber.Text.Trim & "' !"
            Exit Sub
        End If
        Try
            ds = CriticalItems.ItemTables.NonStockDetails(txtPlNumber.Text.Trim)
            If ds.Tables(0).Rows.Count <= 0 Then
                lblMessage.Text = " PL Number : '" & txtPlNumber.Text.Trim & "' does not exists in ItemMaster !"
                txtPlNumber.Text = ""
                ds.Dispose()
                Exit Try
            End If
            lblPlDesc.Text = ds.Tables(0).Rows(0).Item(1)
            lblUnitName.Text = ds.Tables(0).Rows(0).Item(2)
            dgPLOutstanding.DataSource = ds.Tables(1).DefaultView
            dgPLOutstanding.DataBind()
            PopulateSavedData(txtPlNumber.Text.Trim, lblConsignee.Text.Trim)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            ds.Dispose()
        End Try
    End Sub

    Private Sub dgPLOutstanding_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgPLOutstanding.ItemCommand
        lblMessage.Text = ""
        ClearVal()
        Try
            Select Case e.CommandName
                Case "Select"
                    lblType.Text = e.Item.Cells(2).Text.Trim
                    txtNum.Text = e.Item.Cells(4).Text.Trim
                    txtDt.Text = e.Item.Cells(5).Text.Trim
                    txtQty.Text = e.Item.Cells(7).Text.Trim
                    txtSup.Text = e.Item.Cells(6).Text.Trim
                    txtRecdQty.Text = IIf(IsDBNull(e.Item.Cells(9).Text.Trim), "0.000", e.Item.Cells(9).Text.Trim).Replace("&nbsp;", "0")
                    txtQtyUT.Text = IIf(IsDBNull(e.Item.Cells(10).Text.Trim), "0.000", e.Item.Cells(10).Text.Trim).Replace("&nbsp;", "0")
                    txtQtyDue.Text = IIf(IsDBNull(e.Item.Cells(11).Text.Trim), "0.000", e.Item.Cells(11).Text.Trim).Replace("&nbsp;", "0")
                    txtDD.Text = IIf(IsDBNull(e.Item.Cells(8).Text.Trim), "", e.Item.Cells(8).Text.Trim).Replace("&nbsp;", "")
            End Select
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub ClearPLVal()
        lblPlDesc.Text = ""
        txtSlNo.Text = ""
        lblUnitName.Text = ""
        txtEquip.Text = ""
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
    End Sub
    Private Function CheckPl(ByVal PLNumber As String, ByVal Consignee As String, ByVal PO As String) As Boolean
        Dim Pl As Boolean
        Try
            Pl = CriticalItems.ItemTables.CheckPl(PLNumber, lblConsignee.Text.Trim, txtNum.Text)
        Catch exp As Exception
            Throw New Exception(exp.Message)
        End Try
        Return Pl
    End Function
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        Dim blnSave As Boolean
        If CheckPl(txtPlNumber.Text.Trim, lblConsignee.Text.Trim, txtNum.Text) Then
            lblMessage.Text = " Pl number : '" & txtPlNumber.Text.Trim & "' and with Number : '" & txtNum.Text.Trim & "' already exists !"
        Else
            Dim SaveList As New CriticalItems.Listing(lblConsignee.Text.Trim)
            Try
                SaveList.PLNumber = txtPlNumber.Text.Trim
                SaveList.SlNo = IIf(IsDBNull(txtSlNo.Text.Trim), 0, txtSlNo.Text.Trim)
                SaveList.EARES = "Non-Stock"
                SaveList.Equip = txtEquip.Text.Trim & ""
                SaveList.Type = lblType.Text.Trim
                SaveList.PO = txtNum.Text
                SaveList.PODt = IIf(IsDBNull(txtDt.Text.Trim), "1900-01-01", Format(CDate(txtDt.Text.Trim), "yyyy-MM-dd"))
                SaveList.POQty = IIf(IsDBNull(txtQty.Text), 0, txtQty.Text)
                SaveList.PODD = IIf(IsDBNull(txtDD.Text.Trim), "", txtDD.Text.Trim)
                SaveList.POSup = txtSup.Text.Trim
                SaveList.RecdQty = IIf(IsDBNull(txtRecdQty.Text), 0, txtRecdQty.Text)
                SaveList.QtyUT = IIf(IsDBNull(txtQtyUT.Text), 0, txtQtyUT.Text)
                SaveList.QtyDue = IIf(IsDBNull(txtQtyDue.Text), 0, txtQtyDue.Text)
                SaveList.Remarks = txtRemarks.Text.Trim.ToUpper & ""
                SaveList.Consignee = lblConsignee.Text
                SaveList.DeleteStatus = False
                If SaveList.SaveConsignee(SaveList.Consignee) Then
                    blnSave = True
                    ClearVal()
                End If
                PopulateSavedData(txtPlNumber.Text.Trim, lblConsignee.Text)
            Catch exp As Exception
                lblMessage.Text = exp.Message
            Finally
                SaveList = Nothing
            End Try
            If blnSave Then
                lblMessage.Text = " DATA Saved !"
            Else
                lblMessage.Text = " Data not saved !" & SaveList.Message
            End If
        End If
    End Sub

End Class
