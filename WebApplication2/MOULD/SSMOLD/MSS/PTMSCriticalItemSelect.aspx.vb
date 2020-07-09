Public Class PTMSCriticalItemSelect
    Inherits System.Web.UI.Page
    Protected WithEvents lblConsignee As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents chkSelection As System.Web.UI.WebControls.CheckBox
    Protected WithEvents ddlPlNumber As System.Web.UI.WebControls.DropDownList
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
        Dim ds As New DataSet()
        Try
            ds = CriticalItems.ItemTables.ProdCriticalSelectionList(PLNumber, lblConsignee.Text.Trim, ddlPlNumber.SelectedItem.Value)
            dgSavedData.DataSource = ds.Tables(0).DefaultView
            dgSavedData.DataBind()
            If ds.Tables(0).Rows.Count > 0 Then dgSavedData.Visible = True
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            ds.Dispose()
        End Try
    End Sub
    Private Sub ddlPlNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlPlNumber.SelectedIndexChanged
        Dim ds As New DataSet()
        Try
            ds = CriticalItems.ItemTables.ProdCriticalSelectionList(ddlPlNumber.SelectedItem.Text, lblConsignee.Text.Trim, ddlPlNumber.SelectedItem.Value)
            dgSavedData.DataSource = ds.Tables(0).DefaultView
            dgSavedData.DataBind()
            If ds.Tables(0).Rows.Count > 0 Then dgSavedData.Visible = True
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            ds.Dispose()
        End Try
    End Sub

    Private Sub dgSavedData_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgSavedData.ItemCommand
        lblMessage.Text = ""
        chkSelection.Checked = False
        Try
            Select Case e.CommandName
                Case "Select"
                    If e.Item.Cells(1).Text.Trim = "YES" Then chkSelection.Checked = True
            End Select
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim blnSave As Boolean = False
        Dim SaveProdList As New CriticalItems.Listing(ddlPlNumber.SelectedItem.Text.Trim, lblConsignee.Text.Trim)
        Try
            SaveProdList.PLNumber = ddlPlNumber.SelectedItem.Text.Trim
            SaveProdList.PLID = ddlPlNumber.SelectedItem.Value
            SaveProdList.Selected = chkSelection.Checked
            If SaveProdList.ProdConsumableListUpdateSelection(SaveProdList.PLID) Then
                blnSave = True
            End If
            PopulateSavedData(ddlPlNumber.SelectedItem.Text.Trim, lblConsignee.Text)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            SaveProdList = Nothing
        End Try
        If blnSave Then
            lblMessage.Text = " DATA Saved !"
            chkSelection.Checked = False
        Else
            lblMessage.Text = " data not Saved !"
        End If
    End Sub
End Class
