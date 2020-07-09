Public Class unScheduleEntryDelete
    Inherits System.Web.UI.Page
    Protected WithEvents lblDept As System.Web.UI.WebControls.Label
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboWorkOrderNo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblGroup As System.Web.UI.WebControls.Label
    Protected WithEvents lblUserID As System.Web.UI.WebControls.Label

    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblMaintenance_group As System.Web.UI.WebControls.Label
    Protected WithEvents btnDeleteWO As System.Web.UI.WebControls.Button
    Protected WithEvents btnSpares As System.Web.UI.WebControls.Button
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents ddlShopCode As System.Web.UI.WebControls.DropDownList
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
        Dim grp As String
        lblUserID.Visible = False
        lblGroup.Visible = False
        lblUserID.Text = Session("UserID")
        'strmode = "Delete"
        'strmode = "edit"
        'strmode = "add"
        'Session("group") = "MW1"
        'lblUserID.Text = "077243"
        grp = Session("group")
        lblDept.Text = grp.Substring(0, 1)
        lblDept.Visible = False
        lblMaintenance_group.Text = grp.Substring(1)
        lblUserID.Text = Session("UserID")
        lblGroup.Text = Session("group")
        If Page.IsPostBack = False Then
            txtDate.Text = Date.Today
            Try
                PopulateLocation("add", lblMaintenance_group.Text)
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub PopulateLocation(ByVal mode As String, ByVal group As String)
        lblMessage.Text = ""
        Dim ds As DataSet
        Try
            ds = Maintenance.tables.Location(mode, group, "U")
            ddlShopCode.DataSource = ds.Tables(0).DefaultView
            ddlShopCode.DataTextField = ds.Tables(0).Columns("Location").ColumnName
            ddlShopCode.DataValueField = ds.Tables(0).Columns("code").ColumnName
            ddlShopCode.DataBind()
            ddlShopCode.Items.Insert(0, "Select")
            Dim memo As Int16
            If mode = "add" Then
                If Not IsDBNull(ds.Tables(1).Rows(0)(0)) Then
                    memo = ds.Tables(1).Rows(0)(0) + 1
                Else
                    memo = 1
                End If
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Public Sub PopulateWorkOrders()
        Dim dt As DataTable
        Dim count As Integer
        cboWorkOrderNo.Items.Clear()
        dt = Maintenance.tables.UnSchWorkorders(lblMaintenance_group.Text.Trim, CDate(txtDate.Text), ddlShopCode.SelectedItem.Value.Trim)
        cboWorkOrderNo.DataSource = dt.DefaultView
        cboWorkOrderNo.DataTextField = dt.Columns("workorder_number").ColumnName
        cboWorkOrderNo.DataValueField = dt.Columns("workorder_number").ColumnName
        cboWorkOrderNo.DataBind()
        count = cboWorkOrderNo.Items.Count
        cboWorkOrderNo.Items.Insert(0, "Select")
        If count = 0 Then
            lblMessage.Text = "No WorkOrders Exist For The Given Date..."
        End If
        dt.Dispose()
    End Sub

    Private Sub ddlShopCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlShopCode.SelectedIndexChanged
        lblMessage.Text = ""
        If ddlShopCode.SelectedItem.Text.ToLower = "select" Then
            lblMessage.Text = "Please select Machine ID to save data !"
        Else
            If txtDate.Text.Trim.Length = 0 Then
                lblMessage.Text = "Please fill date !"
                ddlShopCode.SelectedIndex = 0
                Exit Sub
            Else
                PopulateWorkOrders()
            End If
        End If
    End Sub

    Private Sub btnDeleteWO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteWO.Click
        lblMessage.Text = ""
        If ddlShopCode.SelectedItem.Value.ToLower = "select" Then
            lblMessage.Text = "Please select SHOP CODE to save data !"
        Else
            Dim Done As Boolean
            Dim cnt As Int16
            Dim dt As New DataTable()
            Dim dr As DataRow
            Dim oUnSch As New Maintenance.UnScheduled()
            Try
                oUnSch.Number = IIf(IsNothing(cboWorkOrderNo.SelectedItem.Value), "", cboWorkOrderNo.SelectedItem.Value)
                oUnSch.WODate = txtDate.Text.Trim
                oUnSch.Machinery.GroupCode = lblMaintenance_group.Text.Trim
                oUnSch.Machinery.Location = ddlShopCode.SelectedItem.Value
                If oUnSch.SaveWorkDoneDetails(oUnSch.Number, True) Then Done = True
            Catch exp As Exception
                lblMessage.Text = exp.Message
            Finally
                oUnSch = Nothing
            End Try
            If Done Then
                lblMessage.Text = " Data Deleted Successfully "
            Else
                lblMessage.Text &= " Data Not Deleted !"
            End If
        End If
    End Sub

    Private Sub btnSpares_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSpares.Click
        lblMessage.Text = ""
        Try
            FillGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub FillGrid()
        Dim dtSpares As New DataTable()
        Dim i As Int16
        Try
            dtSpares = Maintenance.tables.WOSpares("U", cboWorkOrderNo.SelectedItem.Text.Trim, lblMaintenance_group.Text.Trim)
            DataGrid1.DataSource = dtSpares
            DataGrid1.DataBind()
            i = DataGrid1.Items.Count
            If i = 0 Then
                lblMessage.Text = "No Spares Exist For The Given Date..."
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dtSpares.Dispose()
        End Try
    End Sub
    Private Sub DataGrid1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.ItemCommand
        lblMessage.Text = ""
        Dim blnDone As Boolean
        Dim CMD As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Dim oUnSch As New Maintenance.UnScheduled()
        Try
            Select Case e.CommandName
                Case "Delete"
                    CMD.Parameters.Add("@SparesWONumber", SqlDbType.VarChar, 10).Value = cboWorkOrderNo.SelectedItem.Value
                    CMD.Parameters.Add("@Group", SqlDbType.VarChar, 10).Value = lblMaintenance_group.Text.Trim
                    CMD.Parameters.Add("@PLNumber", SqlDbType.VarChar, 8).Value = e.Item.Cells(1).Text
                    If CMD.Connection.State = ConnectionState.Closed Then CMD.Connection.Open()
                    CMD.Transaction = CMD.Connection.BeginTransaction
                    If oUnSch.DeletePl(CMD) Then
                        lblMessage.Text = "Deleted '" & e.Item.Cells(1).Text.Trim & "' "
                        CMD.Transaction.Commit()
                    Else
                        lblMessage.Text = "Deletion UnSuccessful !"
                        CMD.Transaction.Rollback()
                    End If
            End Select
        Catch exp As Exception
            lblMessage.Text = ""
        Finally
            If CMD.Connection.State = ConnectionState.Open Then CMD.Connection.Close()
            CMD.Dispose()
        End Try
        Try
            FillGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
End Class
