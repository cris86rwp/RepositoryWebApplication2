Public Class PTMSConsumableListEdit
    Inherits System.Web.UI.Page
    Protected WithEvents lblConsignee As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtperDay As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtperMonth As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtInShop As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblInStore As System.Web.UI.WebControls.Label
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents ddlPlNumber As System.Web.UI.WebControls.DropDownList
    Protected WithEvents dgBOM As System.Web.UI.WebControls.DataGrid
    Protected WithEvents rblBOMType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblBOMSource As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtBOMqty As System.Web.UI.WebControls.TextBox
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


    Protected Sub dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        If Page.IsPostBack = False Then
            Try
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
    Private Sub ClearVal()
        txtBOMqty.Text = 0
        txtInShop.Text = ""
        lblInStore.Text = ""
        txtperDay.Text = ""
        txtperMonth.Text = ""
        txtRemarks.Text = ""
        dgBOM.DataSource = Nothing
        dgBOM.DataBind()
    End Sub
    Private Sub PopulateDDL(ByVal Consignee As String)
        lblMessage.Text = ""
        ddlPlNumber.DataSource = Nothing
        ddlPlNumber.DataBind()
        Dim dvPLNumber As New DataView()
        Try
            dvPLNumber.Table = CriticalItems.ItemTables.GetProdConsumablesPls(lblConsignee.Text)
            ddlPlNumber.DataSource = dvPLNumber
            ddlPlNumber.DataTextField = dvPLNumber.Table.Columns(0).ColumnName
            ddlPlNumber.DataValueField = dvPLNumber.Table.Columns(1).ColumnName
            ddlPlNumber.DataBind()
            ddlPlNumber.Items.Insert(0, "Select")
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub PopulateSavedData(ByVal PLNumber As String, ByVal Consignee As String)
        dgSavedData.Visible = False
        dgSavedData.DataSource = Nothing
        dgSavedData.DataBind()
        Dim dv As New DataView()
        Try
            dv = CriticalItems.ItemTables.SavedProdConsumableList(PLNumber, lblConsignee.Text.Trim).DefaultView
            dgSavedData.DataSource = dv
            dgSavedData.DataBind()
            If dv.Table.Rows.Count > 0 Then dgSavedData.Visible = True
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            dv.Dispose()
        End Try
    End Sub
    Private Sub ddlPlNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlPlNumber.SelectedIndexChanged
        lblMessage.Text = ""
        ClearVal()
        If ddlPlNumber.SelectedItem.Text.ToLower = "select" Then
            lblMessage.Text = "Please select PL Number !"
            Exit Sub
        End If
        Dim ds As New DataSet()
        Dim dv As New DataView()
        Dim i As New Integer()
        Try
            ds = CriticalItems.ItemTables.ProdConsumablesDetails(ddlPlNumber.SelectedItem.Text.Trim, lblConsignee.Text)
            i = 0
            For i = 0 To rblBOMSource.Items.Count - 1
                If rblBOMSource.Items(i).Text.Trim = Trim(ds.Tables(1).Rows(0)("BOMSource")) Then
                    rblBOMSource.Items(i).Selected = True
                    Exit For
                End If
            Next
            txtBOMqty.Text = Trim(ds.Tables(1).Rows(0)("BOMQty"))
            i = 0
            For i = 0 To rblBOMType.Items.Count - 1
                If rblBOMType.Items(i).Text.Trim = Trim(ds.Tables(1).Rows(0)("BOMType")) Then
                    rblBOMType.Items(i).Selected = True
                    Exit For
                End If
            Next
            txtperDay.Text = ds.Tables(1).Rows(0)("PerDay")
            txtperMonth.Text = ds.Tables(1).Rows(0)("PerMonth")
            txtInShop.Text = ds.Tables(1).Rows(0)("InShop")
            txtRemarks.Text = ds.Tables(1).Rows(0)("Remarks")
            dv = ds.Tables(0).DefaultView
            'dv.RowFilter = "Source = '" & rblBOMSource.SelectedItem.Text & "'"
            dgBOM.DataSource = dv
            dgBOM.DataBind()
            lblInStore.Text = IIf(IsDBNull(ds.Tables(2).Rows(0)(0)), "", ds.Tables(2).Rows(0)(0))
            PopulateSavedData(ddlPlNumber.SelectedItem.Text.Trim, lblConsignee.Text)
        Catch exp As Exception
            lblMessage.Text = exp.Message
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
                SaveProdList.PLNumber = ddlPlNumber.SelectedItem.Text.Trim
                SaveProdList.PLID = ddlPlNumber.SelectedItem.Value
                SaveProdList.Consignee = lblConsignee.Text
                SaveProdList.PerDay = Val(txtperDay.Text.Trim)
                SaveProdList.PerMonth = Val(txtperMonth.Text.Trim)
                SaveProdList.InShop = Val(txtInShop.Text.Trim)
                SaveProdList.BOMSource = rblBOMSource.SelectedItem.Text
                SaveProdList.BOMType = rblBOMType.SelectedItem.Text
                SaveProdList.BOMQty = Val(txtBOMqty.Text.Trim)
                SaveProdList.Remarks = txtRemarks.Text.Trim.ToUpper & ""
                SaveProdList.DeleteStatus = False
                SaveProdList.Selected = False
                If SaveProdList.SaveProdConsumableList(SaveProdList.PLNumber, SaveProdList.Consignee, SaveProdList.PLID) Then
                    blnSave = True
                    ClearVal()
                End If
                PopulateSavedData(ddlPlNumber.SelectedItem.Text.Trim, lblConsignee.Text)
                ddlPlNumber.SelectedIndex = 0
                blnSave = True
            Catch exp As Exception
                lblMessage.Text = SaveProdList.Message & exp.Message
            Finally
                SaveProdList = Nothing
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
End Class
