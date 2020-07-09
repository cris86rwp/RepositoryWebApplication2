Public Class WaterHardnessData
    Inherits System.Web.UI.Page
    Protected WithEvents txtSoftHours As System.Web.UI.WebControls.TextBox
    Protected WithEvents RangeValidator1 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents txtTotSoftQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents RangeValidator2 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents RangeValidator3 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents txtTotByPassQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRawQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents RangeValidator4 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents lblTotQty As System.Web.UI.WebControls.Label
    Protected WithEvents txtColdQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents RangeValidator6 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents btnDelete As System.Web.UI.WebControls.Button
    Protected WithEvents dgData As System.Web.UI.WebControls.DataGrid
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator3 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator4 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator5 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator6 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator8 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtShiftDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnClearScreen As System.Web.UI.WebControls.Button
    Protected WithEvents lblTotwater As System.Web.UI.WebControls.Label
    Protected WithEvents RangeValidator5 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents RequiredFieldValidator7 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtSoftQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents CustomValidator1 As System.Web.UI.WebControls.CustomValidator
    Protected WithEvents txtDataDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblHelp As System.Web.UI.WebControls.Label
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Page.IsPostBack = False Then
            clearScreen()
            fillHelp()
        End If
    End Sub
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
    Private Sub fillHelp()
        Dim help As New System.Text.StringBuilder()
        help.Append("<CENTER>H E L P</CENTER><br>1. Shift date is date of 'A' Shift of that day in dd/mm/yyyy format<br>")
        help.Append("2. After delete/Save/Update on screen data is retained to modify/re-append<br>")
        help.Append("3. Data Date Time is the time <B>with Date</B> for which readings are inputin dd/mm/yyyy hh:mm:ss<br>")
        help.Append("4. Data Date Time should be within 06:00:00 of shift date to 05:59:59 of next date of the Shift Date<br>")
        help.Append("5. After input of Shift date, select Data date from grid below, if any<br>")
        help.Append("6. If all data date entries are deleted, all data for the shift date will be automatically deleted<br>")
        help.Append("7. Update any field any number of times after selecting it from grid as you require")
        lblHelp.Text = help.ToString
    End Sub
    Private Sub clearScreen()
        lblMessage.Text = ""
        txtColdQty.Text = ""
        txtDataDate.Text = ""
        txtRawQty.Text = ""
        txtShiftDate.Text = ""
        txtSoftHours.Text = ""
        txtSoftQty.Text = ""
        txtTotByPassQty.Text = ""
        txtTotSoftQty.Text = ""
        lblTotQty.Text = ""
        dgData.DataSource = Nothing
        dgData.DataBind()
    End Sub
    Private Sub PrepareParams(ByRef Da As SqlClient.SqlDataAdapter, ByVal CmdType As String)
        Select Case CmdType.ToLower.Trim
            Case "insert"
                Da.InsertCommand.Parameters.Add("@ShiftDate", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Input

                Da.InsertCommand.Parameters.Add("@DataDateTime", SqlDbType.DateTime, 8).Direction = ParameterDirection.Input
                Da.InsertCommand.Parameters.Add("@Raw_ppm", SqlDbType.Int, 4).Direction = ParameterDirection.Input
                Da.InsertCommand.Parameters.Add("@Soft_ppm", SqlDbType.Int, 4).Direction = ParameterDirection.Input
                Da.InsertCommand.Parameters.Add("@Cold_ppm", SqlDbType.Int, 4).Direction = ParameterDirection.Input
                Da.InsertCommand.Parameters.Add("@SofteningHrs", SqlDbType.Int, 4).Direction = ParameterDirection.Input
                Da.InsertCommand.Parameters.Add("@Soft_Qty", SqlDbType.Int, 4).Direction = ParameterDirection.Input
                Da.InsertCommand.Parameters.Add("@ByPass_Qty", SqlDbType.Int, 4).Direction = ParameterDirection.Input
                Da.InsertCommand.Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Direction = ParameterDirection.Input
            Case "update"
                Da.UpdateCommand.Parameters.Add("@ShiftDate", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Input

                Da.UpdateCommand.Parameters.Add("@Raw_ppm", SqlDbType.Int, 4).Direction = ParameterDirection.Input
                Da.UpdateCommand.Parameters.Add("@Soft_ppm", SqlDbType.Int, 4).Direction = ParameterDirection.Input
                Da.UpdateCommand.Parameters.Add("@Cold_ppm", SqlDbType.Int, 4).Direction = ParameterDirection.Input
                Da.UpdateCommand.Parameters.Add("@SofteningHrs", SqlDbType.Int, 4).Direction = ParameterDirection.Input
                Da.UpdateCommand.Parameters.Add("@Soft_Qty", SqlDbType.Int, 4).Direction = ParameterDirection.Input
                Da.UpdateCommand.Parameters.Add("@DataDateTime", SqlDbType.DateTime, 8).Direction = ParameterDirection.Input
                Da.UpdateCommand.Parameters.Add("@ByPass_Qty", SqlDbType.Int, 4).Direction = ParameterDirection.Input
                Da.UpdateCommand.Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Direction = ParameterDirection.Input
            Case "select"
                Da.SelectCommand.Parameters.Add("@ShiftDate", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Input
                Da.SelectCommand.Parameters.Add("@DataDateTime", SqlDbType.DateTime, 8).Direction = ParameterDirection.Input
            Case "delete"
                Da.DeleteCommand.Parameters.Add("@ShiftDate", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Input
                Da.DeleteCommand.Parameters.Add("@DataDateTime", SqlDbType.DateTime, 8).Direction = ParameterDirection.Input
        End Select
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim da As New SqlClient.SqlDataAdapter()
        da = rwfGen.Connection.Adapter
        Dim sHeaderQrySelect, sDetailsQrySelect, sCheckChildRecs, sDetailsQryInsert, sHeaderQryInsert As String
        Dim sDetailsQryUpdate, sHeaderQryUpdate, sHeaderQryDelete, sDetailsQryDelete As String
        If lblMessage.Text = "Saved" OrElse lblMessage.Text = "Deleted" OrElse lblMessage.Text = "" Then
        Else
            Exit Sub
        End If
        sHeaderQrySelect = "select count(*) from  ms_WaterHardness_Header where ShiftDate = @ShiftDate"
        sDetailsQrySelect = "select count(*) from  ms_WaterHardness_Details where DataDateTime = @DataDateTime"
        sCheckChildRecs = "select count(*) from  ms_WaterHardness_Details where ShiftDate = @ShiftDate"

        sDetailsQryInsert = "Insert into ms_WaterHardness_Details (ShiftDate, DataDateTime, Raw_ppm, Soft_ppm, Cold_ppm , Remarks ) values (@ShiftDate, @DataDateTime, @Raw_ppm, @Soft_ppm, @Cold_ppm , @Remarks )"
        sHeaderQryInsert = "Insert into ms_WaterHardness_Header (ShiftDate, SofteningHrs, Soft_Qty, ByPass_Qty ) values (@ShiftDate, @SofteningHrs, @Soft_Qty, @ByPass_Qty)"

        sDetailsQryUpdate = "Update ms_WaterHardness_Details set ShiftDate = @ShiftDate, Raw_ppm = @Raw_ppm, Soft_ppm = @Soft_ppm, Cold_ppm = @Cold_ppm , Remarks = @Remarks where DataDateTime = @DataDateTime"
        sHeaderQryUpdate = "Update ms_WaterHardness_Header set SofteningHrs = @SofteningHrs, Soft_Qty = @Soft_Qty, ByPass_Qty = @ByPass_Qty where ShiftDate = @ShiftDate"

        sHeaderQryDelete = "delete from  ms_WaterHardness_Header where ShiftDate = @ShiftDate"
        sDetailsQryDelete = "delete from  ms_WaterHardness_Details where DataDateTime = @DataDateTime"
        PrepareParams(da, "select")
        PrepareParams(da, "Insert")
        PrepareParams(da, "Update")
        PrepareParams(da, "Delete")
        da.SelectCommand.Parameters("@ShiftDate").Value = CDate(txtShiftDate.Text)
        da.SelectCommand.Parameters("@DataDateTime").Value = CDate(txtDataDate.Text)
        Dim iHeaderRecs, iDetailRecs As Integer
        Dim blnHeader, blnDetails As Boolean

        Try
            da.InsertCommand.Parameters("@ShiftDate").Value = CDate(txtShiftDate.Text)
            da.InsertCommand.Parameters("@DataDateTime").Value = CDate(txtDataDate.Text)
            da.InsertCommand.Parameters("@SofteningHrs").Value = txtSoftHours.Text
            da.InsertCommand.Parameters("@Soft_Qty").Value = txtTotSoftQty.Text
            da.InsertCommand.Parameters("@ByPass_Qty").Value = txtTotByPassQty.Text
            da.InsertCommand.Parameters("@Raw_ppm").Value = CInt(txtRawQty.Text)
            da.InsertCommand.Parameters("@Soft_ppm").Value = CInt(txtSoftQty.Text)
            da.InsertCommand.Parameters("@Cold_ppm").Value = CInt(txtColdQty.Text)
            da.InsertCommand.Parameters("@Remarks").Value = txtRemarks.Text.Trim
            '
            da.UpdateCommand.Parameters("@ShiftDate").Value = CDate(txtShiftDate.Text)
            da.UpdateCommand.Parameters("@DataDateTime").Value = CDate(txtDataDate.Text)

            da.UpdateCommand.Parameters("@SofteningHrs").Value = txtSoftHours.Text
            da.UpdateCommand.Parameters("@Soft_Qty").Value = txtTotSoftQty.Text
            da.UpdateCommand.Parameters("@ByPass_Qty").Value = txtTotByPassQty.Text
            da.UpdateCommand.Parameters("@Raw_ppm").Value = CInt(txtRawQty.Text)
            da.UpdateCommand.Parameters("@Soft_ppm").Value = CInt(txtSoftQty.Text)
            da.UpdateCommand.Parameters("@Cold_ppm").Value = CInt(txtColdQty.Text)
            da.UpdateCommand.Parameters("@Remarks").Value = txtRemarks.Text.Trim

            da.SelectCommand.Connection.Open()
            da.SelectCommand.CommandText = sHeaderQrySelect
            iHeaderRecs = da.SelectCommand.ExecuteScalar
            da.InsertCommand.Connection.Open()
            da.InsertCommand.Transaction = da.InsertCommand.Connection.BeginTransaction()
            If iHeaderRecs = 0 Then
                da.InsertCommand.CommandText = sHeaderQryInsert
            Else
                da.InsertCommand.CommandText = sHeaderQryUpdate
            End If
            If da.InsertCommand.ExecuteNonQuery = 1 Then
                blnHeader = True
            End If
            da.SelectCommand.CommandText = sDetailsQrySelect
            If da.SelectCommand.Connection.State = ConnectionState.Closed Then da.SelectCommand.Connection.Open()
            iDetailRecs = da.SelectCommand.ExecuteScalar
            If iDetailRecs = 0 Then
                da.InsertCommand.CommandText = sDetailsQryInsert
            Else
                da.InsertCommand.CommandText = sDetailsQryUpdate
            End If
            If da.InsertCommand.ExecuteNonQuery = 1 Then
                blnDetails = True
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            If IsNothing(da) = False Then
                If IsNothing(da.InsertCommand.Transaction) = False Then
                    If blnHeader And blnDetails Then
                        da.InsertCommand.Transaction.Commit()
                        lblMessage.Text = "Saved"
                    Else
                        da.InsertCommand.Transaction.Rollback()
                    End If
                End If
                If da.SelectCommand.Connection.State = ConnectionState.Open Then da.SelectCommand.Connection.Close()
                If da.InsertCommand.Connection.State = ConnectionState.Open Then da.SelectCommand.Connection.Close()
                If da.UpdateCommand.Connection.State = ConnectionState.Open Then da.SelectCommand.Connection.Close()
                If da.DeleteCommand.Connection.State = ConnectionState.Open Then da.SelectCommand.Connection.Close()
                da.Dispose()
            End If
        End Try
        Try
            PopulateGrid()
            PopulateHeaderData()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub CustomValidator1_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CustomValidator1.ServerValidate
        If txtShiftDate.Text = "" OrElse txtDataDate.Text = "" Then
            Exit Sub
        End If
        Dim dDataDate, dShiftDate As Date
        Dim rdt, sdt As String

        Try
            rdt = txtShiftDate.Text
            txtShiftDate.Text = ""
            dShiftDate = CDate(rdt).Date
            If dShiftDate > CDate(Now()) Then
                txtShiftDate.Text = ""
                Throw New Exception("Future Report Date " & dShiftDate)
            End If
            txtShiftDate.Text = dShiftDate.Date
            sdt = txtDataDate.Text
            txtDataDate.Text = ""
            dDataDate = CDate(sdt)
            If dDataDate > CDate(Now()) Then
                txtDataDate.Text = ""
                Throw New Exception("Future Date " & dDataDate)
            End If
            txtDataDate.Text = sdt
            Dim dFromDt, dToDt As Date
            dFromDt = dShiftDate.Date.AddHours(6)
            dToDt = dShiftDate.AddDays(1).AddHours(5).AddMinutes(59).AddSeconds(59)
            If dDataDate < dFromDt OrElse dDataDate > dToDt Then
                txtDataDate.Text = ""
                Throw New Exception("Data Date " & dDataDate & " Out of Range of Shift Date: " & dShiftDate)
            End If
            lblMessage.Text = ""
        Catch exp As Exception
            CustomValidator1.IsValid = False
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub txtDataDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDataDate.TextChanged
        Dim dt As Date
        Try
            dt = CDate(txtDataDate.Text)
            If dt > CDate(Now()) Then
                Throw New Exception("Future Date " & CDate(txtDataDate.Text))
            End If
            lblMessage.Text = ""
        Catch exp As Exception
            lblMessage.Text = exp.Message
            txtDataDate.Text = ""
        End Try
    End Sub
    Private Sub txtShiftDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShiftDate.TextChanged
        lblMessage.Text = ""
        Dim dt As Date
        Try
            Dim rDt As String = txtShiftDate.Text
            txtShiftDate.Text = ""
            dt = CDate(rDt).Date
            If dt > Today Then
                txtShiftDate.Text = ""
                Throw New Exception("Future Date " & dt)
            End If
            txtShiftDate.Text = dt.Date
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        Try
            PopulateHeaderData()
            PopulateGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub PopulateGrid()
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        da.SelectCommand.CommandText = "select * from  ms_WaterHardness_Details where shiftDate = @ShiftDate order by DataDateTime "
        da.SelectCommand.Parameters.Add(New SqlClient.SqlParameter("@ShiftDate", SqlDbType.SmallDateTime, 4)).Value = CDate(txtShiftDate.Text)
        da.Fill(ds)
        dgData.DataSource = ds.Tables(0)
        dgData.DataBind()
        ds.Dispose()
        da.Dispose()
    End Sub
    Private Sub PopulateHeaderData()
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter

        da.SelectCommand.CommandText = "select * from  ms_WaterHardness_Header where shiftDate = @ShiftDate"
        da.SelectCommand.Parameters.Add(New SqlClient.SqlParameter("@ShiftDate", SqlDbType.SmallDateTime, 4)).Value = CDate(txtShiftDate.Text)
        Dim rdr As SqlClient.SqlDataReader
        da.SelectCommand.Connection.Open()
        rdr = da.SelectCommand.ExecuteReader
        If rdr.Read Then
            txtTotByPassQty.Text = rdr("ByPass_Qty")
            txtTotSoftQty.Text = rdr("Soft_Qty")
            txtSoftHours.Text = rdr("SofteningHrs")
            lblTotQty.Text = rdr("Total_Qty")
        End If
        rdr.Close()
        If da.SelectCommand.Connection.State = ConnectionState.Open Then da.SelectCommand.Connection.Close()
        da.Dispose()
    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If lblMessage.Text = "Saved" OrElse lblMessage.Text = "Deleted" OrElse lblMessage.Text = "" Then
        Else
            Exit Sub
        End If
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim sHeaderQrySelect, sDetailsQrySelect, sCheckChildRecs, sDetailsQryDelete, sHeaderQryDelete As String
        sHeaderQrySelect = "select count(*) from  ms_WaterHardness_Header where ShiftDate = @ShiftDate"
        sDetailsQrySelect = "select count(*) from  ms_WaterHardness_Details where DataDateTime = @DataDateTime"
        sCheckChildRecs = "select count(*) from  ms_WaterHardness_Details where ShiftDate = @ShiftDate"
        sDetailsQryDelete = "Delete from ms_WaterHardness_Details where DataDateTime = @DataDateTime"
        sHeaderQryDelete = "delete from  ms_WaterHardness_Header where ShiftDate = @ShiftDate"

        PrepareParams(da, "select")
        PrepareParams(da, "Delete")
        da.SelectCommand.Parameters("@ShiftDate").Value = CDate(txtShiftDate.Text)
        da.SelectCommand.Parameters("@DataDateTime").Value = CDate(txtDataDate.Text)
        da.DeleteCommand.Parameters("@ShiftDate").Value = CDate(txtShiftDate.Text)
        da.DeleteCommand.Parameters("@DataDateTime").Value = CDate(txtDataDate.Text)
        Dim blnDelDetails, blnDelHeader, blnDelAllHeader As Boolean

        Dim iheaderRecs, iDetailRecs As Integer
        Try
            da.SelectCommand.Connection.Open()
            da.SelectCommand.CommandText = sDetailsQrySelect
            iDetailRecs = da.SelectCommand.ExecuteScalar
            If iDetailRecs = 1 Then
                da.DeleteCommand.Connection.Open()
                da.DeleteCommand.CommandText = sDetailsQryDelete
                da.DeleteCommand.Transaction = da.DeleteCommand.Connection.BeginTransaction
                If da.DeleteCommand.ExecuteNonQuery = 1 Then
                    blnDelDetails = True
                End If
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            If IsNothing(da.DeleteCommand.Transaction) = False Then
                If blnDelDetails Then
                    da.DeleteCommand.Transaction.Commit()
                Else
                    da.DeleteCommand.Transaction.Rollback()
                End If
            End If
            If da.SelectCommand.Connection.State = ConnectionState.Open Then da.SelectCommand.Connection.Close()
            If da.DeleteCommand.Connection.State = ConnectionState.Open Then da.DeleteCommand.Connection.Close()
        End Try
        Try
            da.SelectCommand.CommandText = sCheckChildRecs
            da.SelectCommand.Connection.Open()
            iDetailRecs = da.SelectCommand.ExecuteScalar
            If iDetailRecs = 0 Then
                da.DeleteCommand.CommandText = sHeaderQryDelete
                da.DeleteCommand.Connection.Open()
                da.DeleteCommand.Transaction = da.DeleteCommand.Connection.BeginTransaction
                If da.DeleteCommand.ExecuteNonQuery = 1 Then
                    blnDelAllHeader = True
                    blnDelHeader = True
                End If
            Else
                blnDelHeader = blnDelDetails
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            If IsNothing(da.DeleteCommand.Transaction) = False Then
                If blnDelDetails And blnDelHeader Then
                    da.DeleteCommand.Transaction.Commit()
                Else
                    da.DeleteCommand.Transaction.Rollback()
                End If
            End If
            If da.DeleteCommand.Connection.State = ConnectionState.Open Then da.DeleteCommand.Connection.Close()
            If da.SelectCommand.Connection.State = ConnectionState.Open Then da.SelectCommand.Connection.Close()
            da.Dispose()
        End Try
        If blnDelDetails And blnDelHeader Then
            lblMessage.Text = "Deleted"
            Try
                PopulateGrid()
                If blnDelAllHeader Then
                    PopulateHeaderData()
                End If
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
    Private Sub dgData_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgData.ItemCommand
        If e.CommandName = "Select" Then
            Dim dDataDateTime As Date
            dDataDateTime = CDate(e.Item.Cells(2).Text)
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = "select * from  ms_WaterHardness_Details where DataDateTime = @DataDateTime"
                da.SelectCommand.Parameters.Add(New SqlClient.SqlParameter("@DataDateTime", SqlDbType.DateTime, 8)).Value = dDataDateTime
                Dim rdr As SqlClient.SqlDataReader
                da.SelectCommand.Connection.Open()
                rdr = da.SelectCommand.ExecuteReader
                If rdr.Read Then
                    txtColdQty.Text = rdr("cold_ppm")
                    txtDataDate.Text = CDate(rdr("dataDateTime"))
                    txtRawQty.Text = rdr("Raw_ppm")
                    txtSoftQty.Text = rdr("soft_ppm")
                End If
                rdr.Close()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            Finally
                If da.SelectCommand.Connection.State = ConnectionState.Open Then da.SelectCommand.Connection.Close()
                da.Dispose()
            End Try
        End If
    End Sub
    Private Sub btnClearScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearScreen.Click
        clearScreen()
    End Sub
End Class
