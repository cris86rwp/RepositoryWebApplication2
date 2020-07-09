Public Class MouldMachiningEdit
    Inherits System.Web.UI.Page
    Protected WithEvents txtMouldNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnUpdate As System.Web.UI.WebControls.Button
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblMacDt As System.Web.UI.WebControls.Label
    Protected WithEvents lblMacSh As System.Web.UI.WebControls.Label
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtShift As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtIni As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFinal As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMldType As System.Web.UI.WebControls.Label
    Protected WithEvents txtDefect As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtOperation_type As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
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
        'Try
        '    If Session("Group") <> "MRSMRS" AndAlso Session("UserID") <> "078916" Then
        '        ' Response.Redirect("/mms/InvalidSession.aspx")
        '        Exit Sub
        '    End If
        'Catch exp As Exception
        '    '  Response.Redirect("/mms/InvalidSession.aspx")
        '    Exit Sub
        'End Try
        If Page.IsPostBack = False Then
            lblMacDt.Visible = False
            lblMacSh.Visible = False
            lblMldType.Visible = False
        End If
    End Sub

    Private Sub txtMouldNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMouldNumber.TextChanged
        DataGrid1.SelectedIndex = -1
        lblMessage.Text = ""
        clear()
        Try
            FillGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub FillGrid()
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        da.SelectCommand.Parameters.Add("@mld", SqlDbType.VarChar, 50).Value = txtMouldNumber.Text.Trim
        da.SelectCommand.CommandText = " select convert(varchar(11), machining_date, 103) McnDate , Shift_code Sh , " & _
        " mould_intial_height Initial , mould_final_height Final , " & _
        " ( mould_intial_height - mould_final_height ) Diff ,  Remarks , mould_type Type , defect  , " & _
        " operation_type Machine from mm_mould_machining_details where mould_number = @mld " & _
        " order by machining_date , shift_code "
        Try
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                DataGrid1.DataSource = ds.Tables(0).Copy
                DataGrid1.DataBind()
            Else
                lblMessage.Text = " InValid Mould Number "
            End If
        Catch exp As Exception
            lblMessage.Text = "Unable to retrieve data " & exp.Message
        Finally
            da.Dispose()
            ds.Dispose()
            ds = Nothing
            da = Nothing
        End Try
    End Sub

    Private Sub DataGrid1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.ItemCommand
        DataGrid1.SelectedIndex = -1
        lblMessage.Text = ""
        clear()
        If e.CommandName = "Select" Then
            Try
                txtDate.Text = e.Item.Cells(1).Text
                lblMacDt.Text = e.Item.Cells(1).Text
                txtShift.Text = e.Item.Cells(2).Text
                lblMacSh.Text = e.Item.Cells(2).Text
                txtIni.Text = e.Item.Cells(3).Text
                txtFinal.Text = e.Item.Cells(4).Text
                txtRemarks.Text = e.Item.Cells(6).Text
                lblMldType.Text = e.Item.Cells(7).Text
                txtDefect.Text = e.Item.Cells(8).Text
                txtOperation_type.text = e.Item.Cells(9).Text
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        Else
            lblMessage.Text = "InValid Selection !"
        End If
    End Sub

    Private Sub clear()
        txtDate.Text = ""
        lblMacDt.Text = ""
        txtShift.Text = ""
        lblMacSh.Text = ""
        txtIni.Text = ""
        txtFinal.Text = ""
        txtRemarks.Text = ""
        lblMldType.Text = ""
        txtShift.Text = ""
        txtDefect.Text = ""
        txtOperation_type.text = ""
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim Done As Boolean
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        da.SelectCommand.Parameters.Add("@MldNo", SqlDbType.VarChar, 50).Value = txtMouldNumber.Text.Trim
        da.SelectCommand.Parameters.Add("@machining_date", SqlDbType.SmallDateTime, 4).Value = CDate(txtDate.Text)
        da.SelectCommand.Parameters.Add("@Shift", SqlDbType.VarChar, 1).Value = lblMacSh.Text.Trim
        da.SelectCommand.Parameters.Add("@shift_code", SqlDbType.VarChar, 1).Value = txtShift.Text.Trim
        da.SelectCommand.Parameters.Add("@defect", SqlDbType.VarChar, 1).Value = txtDefect.Text.Trim
        da.SelectCommand.Parameters.Add("@type", SqlDbType.VarChar, 50).Value = lblMldType.Text.Trim
        da.SelectCommand.Parameters.Add("@Ini", SqlDbType.Float, 8).Value = Val(txtIni.Text)
        da.SelectCommand.Parameters.Add("@Final", SqlDbType.Float, 8).Value = Val(txtFinal.Text)
        da.SelectCommand.Parameters.Add("@remarks", SqlDbType.VarChar, 50).Value = txtRemarks.Text.Trim
        da.SelectCommand.Parameters.Add("@Operation_type", SqlDbType.VarChar, 50).Value = txtOperation_type.Text.Trim

        Dim SelectStr As String = " select top 1 * from mm_mould_machining_details where mould_number = @MldNo and ( (machining_date > @machining_date ) or ( machining_date = @machining_date and Shift_code > @Shift )) order by  mould_number, machining_date, shift_code ;" & _
             " select top 1 * from mm_mould_machining_details where mould_number = @MldNo and ( (machining_date < @machining_date ) or ( machining_date = @machining_date and Shift_code < @Shift ) ) order by  mould_number, machining_date desc , shift_code desc "
        Dim UpdateStr1 As String = " update mm_mould_machining_details set mould_intial_height = @Ini , mould_final_height = @Final , remarks = @remarks  , shift_code = @shift_code , defect = @defect , operation_type = @Operation_type where mould_number = @MldNo and machining_date = @machining_date and Shift_code = @Shift  "
        Dim updateStr2 As String = " update mm_mould_master set initial_height = @Final where mould_number = @MldNo and type = @type "
        Dim updateStr3 As String = " Update mm_mmmdmt_dump set mld_fin_ht = @Final WHERE mld_no = @MldNo and mld_typ = @type "
        Dim UpdatePrev As String = " update mm_mould_machining_details set mould_final_height = @Ini where mould_number = @MldNo and machining_date = @machining_date and Shift_code = @Shift  "
        Dim UpdateNext As String = " update mm_mould_machining_details set mould_intial_height = @Final where mould_number = @MldNo and machining_date = @machining_date and Shift_code = @Shift "
        Try
            da.SelectCommand.CommandText = SelectStr
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                If da.SelectCommand.Connection.State = ConnectionState.Closed Then da.SelectCommand.Connection.Open()
                da.SelectCommand.Transaction = da.SelectCommand.Connection.BeginTransaction
                da.SelectCommand.CommandText = UpdateStr1
                If da.SelectCommand.ExecuteNonQuery = 1 Then
                    da.SelectCommand.CommandText = UpdateNext
                    da.SelectCommand.Parameters("@machining_date").Value = ds.Tables(0).Rows(0)(2)
                    da.SelectCommand.Parameters("@Shift").Value = ds.Tables(0).Rows(0)(3)
                    If da.SelectCommand.ExecuteNonQuery = 1 Then
                        If ds.Tables(1).Rows.Count > 0 Then
                            da.SelectCommand.CommandText = UpdatePrev
                            da.SelectCommand.Parameters("@machining_date").Value = ds.Tables(1).Rows(0)(2)
                            da.SelectCommand.Parameters("@Shift").Value = ds.Tables(1).Rows(0)(3)
                            If da.SelectCommand.ExecuteNonQuery = 1 Then
                                Done = True
                            Else
                                Throw New Exception(" updation of Previous Date mm_mould_machining_details failed !")
                            End If
                        Else
                            Done = True
                        End If
                    Else
                        Throw New Exception(" updation of Next Date mm_mould_machining_details failed  !")
                    End If
                Else
                    Throw New Exception(" updation of mm_mould_machining_details failed !")
                End If
            Else
                If da.SelectCommand.Connection.State = ConnectionState.Closed Then da.SelectCommand.Connection.Open()
                da.SelectCommand.Transaction = da.SelectCommand.Connection.BeginTransaction
                da.SelectCommand.CommandText = UpdateStr1
                If da.SelectCommand.ExecuteNonQuery = 1 Then
                    If ds.Tables(1).Rows.Count > 0 Then
                        da.SelectCommand.CommandText = UpdatePrev
                        da.SelectCommand.Parameters("@machining_date").Value = ds.Tables(1).Rows(0)(2)
                        da.SelectCommand.Parameters("@Shift").Value = ds.Tables(1).Rows(0)(3)
                        If da.SelectCommand.ExecuteNonQuery = 1 Then
                            da.SelectCommand.CommandText = updateStr2
                            If da.SelectCommand.ExecuteNonQuery = 1 Then
                                da.SelectCommand.CommandText = updateStr3
                                If da.SelectCommand.ExecuteNonQuery = 1 Then
                                    Done = True
                                Else
                                    Throw New Exception(" updation of mm_mmmdmt_dump failed !")
                                End If
                            Else
                                Throw New Exception(" updation of mm_mould_master failed !")
                            End If
                        Else
                            Throw New Exception(" updation of Previous Date mm_mould_machining_details failed !")
                        End If
                    Else
                        da.SelectCommand.CommandText = updateStr2
                        If da.SelectCommand.ExecuteNonQuery = 1 Then
                            da.SelectCommand.CommandText = updateStr3
                            If da.SelectCommand.ExecuteNonQuery = 1 Then
                                Done = True
                            Else
                                Throw New Exception(" updation of mm_mmmdmt_dump failed !")
                            End If
                        Else
                            Throw New Exception(" updation of mm_mould_master failed !")
                        End If
                    End If

                Else
                    Throw New Exception(" updation of mm_mould_machining_details failed  !")
                End If
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            If Not IsNothing(da.SelectCommand) Then
                If Done Then
                    da.SelectCommand.Transaction.Commit()
                    lblMessage.Text = " Updation Successful !"
                Else
                    da.SelectCommand.Transaction.Rollback()
                End If
                If da.SelectCommand.Connection.State = ConnectionState.Open Then da.SelectCommand.Connection.Close()
                da.Dispose()
                ds.Dispose()
                ds = Nothing
                da = Nothing
            End If
        End Try
        DataGrid1.SelectedIndex = -1
        clear()
        Try
            FillGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        Done = Nothing
        SelectStr = Nothing
        UpdateStr1 = Nothing
        updateStr2 = Nothing
        updateStr3 = Nothing
        UpdatePrev = Nothing
        UpdateNext = Nothing
    End Sub
End Class
