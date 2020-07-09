Public Class NewMachineSparesAdd
    Inherits System.Web.UI.Page
    Protected WithEvents lblGrp As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents ddlMachines As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtPLNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblUnit As System.Web.UI.WebControls.Label
    Protected WithEvents txtPurpose As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtDesc As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblUserID As System.Web.UI.WebControls.Label
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
        txtDesc.ReadOnly = True
        If Not IsPostBack Then
            'Session("UserID") = "078246"
            'Session("group") = "RTSHOP"
            If Session("group") = "RTSHOP" Then
                Session("group") = "MRT"
            End If
            Try
                lblUserID.Text = Trim(Session("UserID"))
                lblGrp.Text = Session("group")
                FillDDLs()
                FillGrid()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
    Private Sub FillDDLs()
        lblMessage.Text = ""
        Dim dt As New DataTable()
        Try
            If lblGrp.Text = "MRT" Then
                dt = Maintenance.tables.GetRTShopMachineList()
            Else
                dt = Maintenance.tables.GetMachineList(lblGrp.Text, "M")
            End If
            ddlMachines.DataSource = dt
            ddlMachines.DataTextField = dt.Columns(0).ColumnName
            ddlMachines.DataValueField = dt.Columns(1).ColumnName
            ddlMachines.DataBind()
            ddlMachines.SelectedIndex = 0
        Catch exp As Exception
            Throw New Exception("Data retrival error !")
        End Try
    End Sub
    Private Sub FillGrid()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Dim da As SqlClient.SqlDataAdapter
        Dim ds As New DataSet()
        da = rwfGen.Connection.Adapter
        da.SelectCommand.CommandText = " select machine_code , pl_number , qtyreqd ,  purpose " &
            " from ms_machine_spares where machine_code = @machine_code order by pl_number ; "

        da.SelectCommand.Parameters.Add("@machine_code", SqlDbType.VarChar, 50).Value = ddlMachines.SelectedItem.Value.Trim

        Try
            da.Fill(ds)
            DataGrid1.DataSource = ds.Tables(0).DefaultView
            DataGrid1.DataBind()
            If IsNothing(DataGrid1.CurrentPageIndex) Then DataGrid1.CurrentPageIndex = 0
            If ds.Tables(0).Rows.Count > 10 Then
                DataGrid1.AllowPaging = True
                DataGrid1.PageSize = 10
                DataGrid1.PagerStyle.Mode = PagerMode.NumericPages
            End If
            DataGrid1.DataSource = ds.Tables(0)
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = "Data Grid Filling Failed : " & exp.Message
        Finally
            ds.Dispose()
            da.Dispose()
        End Try
    End Sub

    Private Sub DataGrid1_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid1.PageIndexChanged
        lblMessage.Text = ""
        Try
            DataGrid1.CurrentPageIndex = e.NewPageIndex
            DataGrid1.EditItemIndex = -1
            FillGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtPLNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPLNumber.TextChanged
        lblMessage.Text = ""
        txtDesc.Text = ""
        lblUnit.Text = ""
        txtQty.Text = ""
        txtPurpose.Text = ""
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.Parameters.Add("@Cnt", SqlDbType.Int, 4)
        cmd.Parameters("@Cnt").Direction = ParameterDirection.Output
        cmd.CommandText = " select  @PlDesc = a.short_description  ,  @PlUnit =  b.description  from pm_item_Master  a , code b " &
                        " where a.ward <> '26' and a.pl_number = @PlNumber  and b.code_type = 'UT' " &
                        " and b.application = 'PM' and b.code = a.uom ; " &
                        " select @qtyreqd = qtyreqd , @purpose =  purpose from ms_machine_spares where machine_code = @machine_code and pl_number = @PlNumber "
        Try
            cmd.Parameters.Add("@PlNumber", SqlDbType.VarChar, 50).Value = txtPLNumber.Text.Trim
            cmd.Parameters.Add("@machine_code", SqlDbType.VarChar, 50).Value = ddlMachines.SelectedItem.Value.Trim
            cmd.Parameters.Add("@PlDesc", SqlDbType.VarChar, 1000).Direction = ParameterDirection.Output
            cmd.Parameters.Add("@PlUnit", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            cmd.Parameters.Add("@qtyreqd", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            cmd.Parameters.Add("@purpose", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
            cmd.ExecuteScalar()
            txtDesc.Text = IIf(IsDBNull(cmd.Parameters("@PlDesc").Value), "", cmd.Parameters("@PlDesc").Value)
            lblUnit.Text = IIf(IsDBNull(cmd.Parameters("@PlUnit").Value), "", cmd.Parameters("@PlUnit").Value)
            If IIf(IsDBNull(cmd.Parameters("@qtyreqd").Value), 0, cmd.Parameters("@qtyreqd").Value) > 0 Then
                txtQty.Text = IIf(IsDBNull(cmd.Parameters("@qtyreqd").Value), 0, cmd.Parameters("@qtyreqd").Value)
                txtPurpose.Text = IIf(IsDBNull(cmd.Parameters("@purpose").Value), "", cmd.Parameters("@purpose").Value)
                lblMessage.Text = "PL Number already exists ! "
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim Done As Boolean
        Dim blnInsert As Boolean
        Dim da As SqlClient.SqlDataAdapter
        Dim ds As New DataSet()
        da = rwfGen.Connection.Adapter
        da.SelectCommand.CommandText = "select *  from ms_machine_spares where machine_code = @machine_code and pl_number = @PlNumber "
        da.SelectCommand.Parameters.Add("@PlNumber", SqlDbType.VarChar, 50).Value = txtPLNumber.Text.Trim
        da.SelectCommand.Parameters.Add("@machine_code", SqlDbType.VarChar, 50).Value = ddlMachines.SelectedItem.Value.Trim
        Try
            da.Fill(ds)
            If ds.Tables(0).Rows.Count = 0 Then
                blnInsert = True
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            ds.Dispose()
            da.Dispose()
        End Try

        Dim oCmd As New SqlClient.SqlCommand()
        oCmd = rwfGen.Connection.CmdObj
        Dim strInsert, strUpdate As String

        Try
            oCmd.Parameters.Add("@machine_group", SqlDbType.VarChar, 10).Value = lblGrp.Text
            oCmd.Parameters.Add("@pl_number", SqlDbType.VarChar, 10).Value = txtPLNumber.Text.Trim
            oCmd.Parameters.Add("@machine_code", SqlDbType.VarChar, 10).Value = ddlMachines.SelectedItem.Value.Trim
            oCmd.Parameters.Add("@qtyreqd", SqlDbType.Int, 4).Value = Val(txtQty.Text)
            oCmd.Parameters.Add("@purpose", SqlDbType.VarChar, 50).Value = txtPurpose.Text.Trim

            strInsert = " insert into ms_machine_spares ( machine_group , pl_number , qtyreqd , machine_code , purpose  ) values ( @machine_group , @pl_number , @qtyreqd , @machine_code , @purpose  )  "

            strUpdate = " update ms_machine_spares set qtyreqd = @qtyreqd , purpose = @purpose  where machine_code = @machine_code and pl_number = @pl_number  "

            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            oCmd.Transaction = oCmd.Connection.BeginTransaction
            If blnInsert Then
                oCmd.CommandText = strInsert
            Else
                oCmd.CommandText = strUpdate
            End If
            If oCmd.ExecuteNonQuery = 1 Then
                Done = True
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            If Not IsNothing(oCmd) Then
                If Done Then
                    oCmd.Transaction.Commit()
                    lblMessage.Text = " Updation Successful !"
                Else
                    lblMessage.Text &= " Updation Failed ! "
                    oCmd.Transaction.Rollback()
                End If
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End If
        End Try
        If Done Then
            Try
                FillGrid()
                txtQty.Text = 0
                txtPurpose.Text = ""
                txtPLNumber.Text = ""
                txtDesc.Text = ""
            Catch exp As Exception
                lblMessage.Text &= exp.Message
            End Try
        End If
    End Sub

    Private Sub ddlMachines_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMachines.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            FillGrid()
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
    End Sub
End Class
