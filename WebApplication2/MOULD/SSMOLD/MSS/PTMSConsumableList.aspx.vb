Public Class PTMSConsumableList
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents rblBOMType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblBOMSource As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents lblConsignee As System.Web.UI.WebControls.Label
    Protected WithEvents txtPlNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtperDay As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtperMonth As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents lblInStore As System.Web.UI.WebControls.Label
    Protected WithEvents txtInShop As System.Web.UI.WebControls.TextBox
    Protected WithEvents dgSavedData As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtBOMqty As System.Web.UI.WebControls.TextBox
    Protected WithEvents dgBOM As System.Web.UI.WebControls.DataGrid
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
                '''''''''''''''
                Group = "SSMOLD"
                UserId = "073533"
                '''''''''''''''
                Try
                    lblConsignee.Text = CriticalItems.ItemTables.GetConsignee(Group, UserId)
                    If lblConsignee.Text.Trim.Length = 4 Then InValid = True
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
    Private Sub txtPlNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPlNumber.TextChanged
        lblMessage.Text = ""
        ClearVal()
        dgBOM.DataSource = Nothing
        dgBOM.DataBind()
        Dim Done As Boolean
        Dim ds As New DataSet()
        Try
            ds = CriticalItems.ItemTables.BOMList(txtPlNumber.Text, lblConsignee.Text)
            If ds.Tables(1).Rows(0)(0) > 0 Then
                lblMessage.Text = "PL Number : '" & txtPlNumber.Text & "' already exists ! "
                PopulateSavedData(txtPlNumber.Text.Trim, lblConsignee.Text)
                txtPlNumber.Text = ""
            Else
                If ds.Tables(0).Rows.Count > 0 Then
                    dgBOM.DataSource = ds.Tables(0).DefaultView
                    dgBOM.DataBind()
                    CheckSource(txtPlNumber.Text, lblConsignee.Text)
                    lblInStore.Text = IIf(IsDBNull(ds.Tables(2).Rows(0)(0)), 0, ds.Tables(2).Rows(0)(0))
                Else
                    lblMessage.Text = "BOM List does not exists ! "
                End If
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub CheckSource(ByVal PL As String, ByVal Consignee As String)
        Dim ds As New DataSet()
        Dim Source As String
        Try
            If PL.Trim.Length <> 8 Then
                Throw New Exception("InValid PL Number !")
            End If
            ds = CriticalItems.ItemTables.BOMList(txtPlNumber.Text, lblConsignee.Text)
            If ds.Tables(0).Rows.Count = 1 Then
                Source = ds.Tables(0).Rows(0)(1)
                Dim i As Int16
                rblBOMSource.ClearSelection()
                For i = 0 To rblBOMSource.Items.Count - 1
                    If rblBOMSource.Items(i).Text = Source Then
                        rblBOMSource.Items(i).Selected = True
                        Exit For
                    End If
                Next
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub rblBOMSource_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblBOMSource.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            CheckSource(txtPlNumber.Text, lblConsignee.Text)
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
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        Dim blnSave As Boolean = False
        Try
            Dim SaveProdList As New CriticalItems.Listing(txtPlNumber.Text.Trim, lblConsignee.Text.Trim)

            Try
                SaveProdList.PLNumber = txtPlNumber.Text.Trim
                SaveProdList.Consignee = lblConsignee.Text
                SaveProdList.BOMSource = rblBOMSource.SelectedItem.Text
                SaveProdList.BOMType = rblBOMType.SelectedItem.Text
                SaveProdList.PerDay = Val(txtperDay.Text.Trim)
                SaveProdList.PerMonth = Val(txtperMonth.Text.Trim)
                SaveProdList.InShop = Val(txtInShop.Text.Trim)
                SaveProdList.BOMQty = Val(txtBOMqty.Text)
                SaveProdList.Remarks = txtRemarks.Text.Trim.ToUpper & ""
                SaveProdList.DeleteStatus = False
                SaveProdList.Selected = False
                If SaveProdList.SaveProdConsumableList(SaveProdList.PLNumber, SaveProdList.Consignee) Then
                    blnSave = True
                    txtPlNumber.Text = ""
                    ClearVal()
                End If
                PopulateSavedData(txtPlNumber.Text.Trim, lblConsignee.Text)
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
