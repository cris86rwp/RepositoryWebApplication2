Public Class MaterialRequirementDelete
    Inherits System.Web.UI.Page
    Protected WithEvents lblConsignee As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents ddlPlNumber As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblUnitName As System.Web.UI.WebControls.Label
    Protected WithEvents lblPlDesc As System.Web.UI.WebControls.Label
    Protected WithEvents lblRecoupType As System.Web.UI.WebControls.Label
    Protected WithEvents lblRecoupQty As System.Web.UI.WebControls.Label
    Protected WithEvents txtYear As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEquip As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents lblDate As System.Web.UI.WebControls.Label
    Protected WithEvents dgSavedData As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    Shared themeValue As String

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
    Private Sub Page_PreInit(ByVal sender As Object, ByVal e As EventArgs)

        Page.Theme = themeValue
    End Sub
    Public Sub New()

        AddHandler PreInit, New EventHandler(AddressOf Page_PreInit)
    End Sub
    Protected Sub dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        'Session("Group") = "MW2"
        'Session("UserId") = "077585"
        If Page.IsPostBack = False Then
            lblMessage.Text = ""
            txtYear.Text = "2009-10"
            Dim Group As String = Session("Group")
            Dim UserId As String = Session("UserID")
            Dim InValid As Boolean = False
            'Group = "MW2"
            'UserId = "077585"
            Try
                lblConsignee.Text = CriticalItems.ItemTables.GetConsignee(Group, UserId)
                If lblConsignee.Text.Trim.Length = 4 Then InValid = True
                PopulateDDL()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            If Not InValid Then
                'Response.Redirect("/wap/logon.aspx")
            Else
                ClearPLVal()
            End If
        End If
    End Sub
    Private Sub ClearPLVal()
        lblPlDesc.Text = ""
        txtQty.Text = ""
        lblUnitName.Text = ""
        lblRecoupType.Text = ""
        lblRecoupQty.Text = ""
        txtYear.Text = "2009-10"
        txtEquip.Text = ""
    End Sub

    Private Sub PopulateDDL()
        lblMessage.Text = ""
        ddlPlNumber.DataSource = Nothing
        ddlPlNumber.DataBind()
        Dim dvPLNumber As New DataView()
        Try
            dvPLNumber.Table = CriticalItems.ItemTables.GetConsigneeMaterialPls(lblConsignee.Text)
            ddlPlNumber.DataSource = dvPLNumber
            ddlPlNumber.DataTextField = dvPLNumber.Table.Columns(0).ColumnName
            ddlPlNumber.DataValueField = dvPLNumber.Table.Columns(0).ColumnName
            ddlPlNumber.DataBind()
            ddlPlNumber.Items.Insert(0, "Select")
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub ddlPlNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlPlNumber.SelectedIndexChanged
        lblMessage.Text = ""
        ClearPLVal()
        dgSavedData.DataSource = Nothing
        dgSavedData.DataBind()
        dgSavedData.SelectedIndex = -1
        If ddlPlNumber.SelectedItem.Text.ToLower = "select" Then
            lblMessage.Text = "Please select PL Number !"
            Exit Sub
        End If
        Dim ds As New DataSet()
        Try
            ds = CriticalItems.ItemTables.PLDetails(ddlPlNumber.SelectedItem.Text, lblConsignee.Text)
            If ds.Tables(0).Rows.Count > 0 Then
                lblPlDesc.Text = ds.Tables(0).Rows(0).Item(1)
                lblRecoupType.Text = ds.Tables(0).Rows(0).Item(2)
                lblRecoupQty.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item(3)), "0", ds.Tables(0).Rows(0).Item(3))
                lblUnitName.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item(4)), "", ds.Tables(0).Rows(0).Item(4))
                txtQty.Text = IIf(IsDBNull(ds.Tables(2).Rows(0).Item(1)), "", ds.Tables(2).Rows(0).Item(1))
                txtEquip.Text = IIf(IsDBNull(ds.Tables(2).Rows(0).Item(3)), "", ds.Tables(2).Rows(0).Item(3))
                txtYear.Text = IIf(IsDBNull(ds.Tables(2).Rows(0).Item(4)), "", ds.Tables(2).Rows(0).Item(4))
            End If
            PopulateSavedData(ddlPlNumber.SelectedItem.Text.Trim, lblConsignee.Text)
        Catch exp As Exception
            lblMessage.Text = exp.Message
            ds = Nothing
        Finally
            ds.Dispose()
        End Try
    End Sub

    Private Sub PopulateSavedData(ByVal PLNumber As String, ByVal Consignee As String)
        dgSavedData.Visible = False
        dgSavedData.DataSource = Nothing
        dgSavedData.DataBind()
        Dim ds As New DataSet()
        Dim dv As New DataView()
        Try
            ds = CriticalItems.ItemTables.SavedMaterialList(PLNumber, lblConsignee.Text.Trim)
            dgSavedData.DataSource = ds.Tables(0).DefaultView
            dgSavedData.DataBind()
            If ds.Tables(0).Rows.Count > 0 Then
                dgSavedData.Visible = True
            End If
            If ds.Tables(1).Rows(0)(0) > 0 Then
                lblMessage.Text = " There are " & ds.Tables(1).Rows(0)(0) & " item(s) in deleted list. "
            End If
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            dv.Dispose()
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        Dim blnSave As Boolean
        lblMessage.Text = "'" & lblRecoupType.Text & " - " & lblRecoupQty.Text & "'"
        Dim SaveList As New CriticalItems.Listing(lblConsignee.Text.Trim)
        Try
            SaveList.PLNumber = ddlPlNumber.SelectedItem.Text.Trim
            SaveList.SlNo = IIf(IsDBNull(txtQty.Text.Trim), 0, txtQty.Text.Trim)
            SaveList.EARES = lblRecoupType.Text & " - " & lblRecoupQty.Text
            SaveList.Equip = txtEquip.Text.Trim & ""
            SaveList.Status = txtYear.Text.Trim
            SaveList.Type = ""
            SaveList.PO = ""
            SaveList.POdate = ""
            SaveList.POSup = ""
            SaveList.POQty = "0"
            SaveList.PODD = ""
            SaveList.RecdQty = "0"
            SaveList.QtyUT = "0"
            SaveList.Remarks = ""
            SaveList.LastIssueDate = Now.Date
            SaveList.Consignee = lblConsignee.Text
            SaveList.DeleteStatus = False
            SaveList.RecID = CheckPl(ddlPlNumber.SelectedItem.Text.Trim, lblConsignee.Text.Trim)
            If SaveList.RecID > 0 Then
                If SaveList.SavePLConsignee(SaveList.Consignee, SaveList.RecID, True) Then
                    blnSave = True
                    ClearPLVal()
                End If
            End If
            PopulateSavedData(ddlPlNumber.SelectedItem.Text.Trim, lblConsignee.Text)
            PopulateDDL()
        Catch exp As Exception
            lblMessage.Text = exp.Message & " ;" & SaveList.Message
        Finally
            SaveList = Nothing
            If blnSave Then
                lblMessage.Text = " DATA Saved !"
                ddlPlNumber.SelectedIndex = 0
            Else
                lblMessage.Text = " Data not saved !"
            End If
        End Try
    End Sub
    Private Function CheckPl(ByVal PLNumber As String, ByVal Consignee As String) As Long
        Try
            CheckPl = CriticalItems.ItemTables.CheckPlStatus(PLNumber, lblConsignee.Text.Trim)
        Catch exp As Exception
            CheckPl = 0
            Throw New Exception(exp.Message)
        End Try
    End Function
End Class
