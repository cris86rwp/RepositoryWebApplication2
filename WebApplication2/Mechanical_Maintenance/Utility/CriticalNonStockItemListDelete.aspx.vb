Public Class CriticalNonStockItemListDelete
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtSlNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblPlDesc As System.Web.UI.WebControls.Label
    Protected WithEvents txtEquip As System.Web.UI.WebControls.TextBox
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
    Protected WithEvents lblRecID As System.Web.UI.WebControls.Label
    Protected WithEvents lblUnitName As System.Web.UI.WebControls.Label
    Protected WithEvents ddlPLNumber As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents dgSavedData As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblConsignee As System.Web.UI.WebControls.Label

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
        'Session("UserId") = "271080"
        If Page.IsPostBack = False Then

            lblMessage.Text = ""
            lblRecID.Visible = False
            Dim Group As String = Session("Group")
            Dim strMode As String = Request.QueryString("mode")
            Dim UserId As String = Session("UserID")

            Dim InValid As Boolean = False
            Try
                lblConsignee.Text = CriticalItems.ItemTables.GetConsignee(Group, UserId)
                If lblConsignee.Text.Trim.Length = 4 Then InValid = True
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try

            If Not InValid Then
                'Response.Redirect("/wap/logon.aspx")
            End If
            ClearPLVal()
            ClearVal()
            PopulateDDL(lblConsignee.Text)

            dgSavedData.DataSource = Nothing
            dgSavedData.DataBind()
            'Literal1.Text = "<marquee id=" & "MyMarquee" & "behavior=" & "scroll" & " direction=" & "right" & ">" & sname & " </marquee>"
            'Label1.Text = "<marquee id=" & "MyMarquee" & "behavior=" & "scroll" & " direction=" & "right" & ">" & sname & " </marquee>"
        End If
    End Sub
    Private Sub PopulateDDL(ByVal Consignee As String)
        lblMessage.Text = ""
        ddlPLNumber.DataSource = Nothing
        ddlPLNumber.DataBind()
        Dim dvPLNumber As New DataView()
        Try
            dvPLNumber.Table = CriticalItems.ItemTables.GetConsigneePls(lblConsignee.Text)
            ddlPLNumber.DataSource = dvPLNumber
            ddlPLNumber.DataTextField = dvPLNumber.Table.Columns(0).ColumnName
            ddlPLNumber.DataValueField = dvPLNumber.Table.Columns(0).ColumnName
            ddlPLNumber.DataBind()
            ddlPLNumber.Items.Insert(0, "Select")
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
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim blnSave As Boolean = False
        Dim SaveList As New CriticalItems.Listing(lblConsignee.Text.Trim)
        Try
            SaveList.PLNumber = ddlPLNumber.SelectedItem.Text.Trim
            SaveList.SlNo = IIf(IsDBNull(txtSlNo.Text.Trim), 0, txtSlNo.Text.Trim)
            SaveList.EARES = "Non-Stock"
            SaveList.Equip = txtEquip.Text.Trim & ""
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
            SaveList.DeleteStatus = True
            If SaveList.SaveConsignee(SaveList.Consignee, lblRecID.Text, True) Then
                blnSave = True
                ClearVal()
                ClearPLVal()
                dgSavedData.SelectedIndex = -1
            End If
            PopulateSavedData(ddlPLNumber.SelectedItem.Text.Trim, lblConsignee.Text)
            PopulateDDL(lblConsignee.Text)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            SaveList = Nothing
        End Try
        If blnSave Then
            lblMessage.Text = " DATA Deleted !"
        Else
            lblMessage.Text = " Data not Deleted !" & SaveList.Message
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
    Private Sub ddlPLNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlPLNumber.SelectedIndexChanged
        lblMessage.Text = ""
        ClearVal()
        ClearPLVal()
        dgSavedData.DataSource = Nothing
        dgSavedData.DataBind()
        dgSavedData.SelectedIndex = -1
        If ddlPLNumber.SelectedItem.Text.ToLower = "select" Then
            lblMessage.Text = "Please select PL Number !"
            Exit Sub
        End If
        Dim ds As New DataSet()
        Try
            ds = CriticalItems.ItemTables.NonStockDetails(ddlPLNumber.SelectedItem.Text.Trim, lblConsignee.Text)
            lblPlDesc.Text = ds.Tables(0).Rows(0).Item(1)
            lblUnitName.Text = ds.Tables(0).Rows(0).Item(2)
            dgSavedData.DataSource = ds.Tables(2).DefaultView
            dgSavedData.DataBind()
            PopulateSavedData(ddlPLNumber.SelectedItem.Text.Trim, lblConsignee.Text)
        Catch exp As Exception
            lblMessage.Text = exp.Message
            ds = Nothing
        Finally
            ds.Dispose()
        End Try


        'lblMessage.Text = ""
        'ClearVal()
        'dgDataGrid.DataSource = Nothing
        'dgDataGrid.DataBind()
        'Dim strPODetails As String
        'strPODetails = " SELECT   pm_item_master.pl_number,  " & _
        '                " pm_item_master.short_description ,  " & _
        '                " pm_UnitMaster.UnitName  " & _
        '                " FROM  " & _
        '                " wap.dbo.pm_item_master pm_item_master   " & _
        '                " LEFT OUTER JOIN wap.dbo.pm_UnitMaster pm_UnitMaster ON  pm_item_master.uom = pm_UnitMaster.uom WHERE  " & _
        '                " pm_item_master.pl_number = '" & ddlPLNumber.SelectedItem.Text.Trim & "' AND " & _
        '                " pm_item_master.delete_flag = '0' ; " & _
        '                " select PLNumber , SlNo , [EAR/ES] , LastIssueDate , Equip , Type ," & _
        '                " PO Number ,  PODt Dt , POQty Qty , PODD DueDt , POSup Supplier , " & _
        '                " RecdQty , QtyUT , QtyDue , Remarks , RecID from  ms_CriticalItemListStock where PLNumber = '" & ddlPLNumber.SelectedItem.Text.Trim & "' and [EAR/ES] = 'Non-Stock' "
        'Dim da As New SqlClient.SqlDataAdapter()
        'da.SelectCommand = New SqlClient.SqlCommand()
        'da.SelectCommand.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
        'da.SelectCommand.CommandText = strPODetails
        'Dim ds As New DataSet()
        'Try
        '    da.Fill(ds, "PmsDetails")
        '    lblPlDesc.Text = ds.Tables(0).Rows(0).Item(1)
        '    lblUnitName.Text = ds.Tables(0).Rows(0).Item(2)
        '    'txtEquip.Text = ds.Tables(0).Rows(0).Item(6)
        '    dgDataGrid.DataSource = ds.Tables(1).DefaultView
        '    dgDataGrid.DataBind()
        '    PopulateSavedData(ddlPLNumber.SelectedItem.Text.Trim)
        'Catch exp As Exception
        '    lblMessage.Text = exp.Message
        '    ds = Nothing
        'Finally
        '    da.Dispose()
        '    ds.Dispose()
        'End Try
    End Sub

    Private Sub dgSavedData_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgSavedData.ItemCommand
        lblMessage.Text = ""
        ClearVal()
        Try
            Select Case e.CommandName
                Case "Delete"
                    txtSlNo.Text = e.Item.Cells(2).Text.Trim
                    txtEquip.Text = e.Item.Cells(3).Text.Trim.Replace("&nbsp;", "")
                    txtNum.Text = e.Item.Cells(5).Text.Trim
                    txtDt.Text = e.Item.Cells(6).Text.Trim
                    txtQty.Text = e.Item.Cells(7).Text.Trim
                    txtDD.Text = IIf(IsDBNull(e.Item.Cells(8).Text.Trim), "", e.Item.Cells(8).Text.Trim).Replace("&nbsp;", "0")
                    txtSup.Text = e.Item.Cells(9).Text.Trim.Replace("&nbsp;", "")
                    txtRecdQty.Text = IIf(IsDBNull(e.Item.Cells(10).Text.Trim), "0.000", e.Item.Cells(10).Text.Trim).Replace("&nbsp;", "0")
                    txtQtyUT.Text = IIf(IsDBNull(e.Item.Cells(11).Text.Trim), "0.000", e.Item.Cells(11).Text.Trim).Replace("&nbsp;", "0")
                    txtQtyDue.Text = IIf(IsDBNull(e.Item.Cells(12).Text.Trim), "0.000", e.Item.Cells(12).Text.Trim).Replace("&nbsp;", "0")
                    txtRemarks.Text = e.Item.Cells(13).Text.Trim.Replace("&nbsp;", "")
                    lblRecID.Text = e.Item.Cells(14).Text.Trim
            End Select
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
End Class
