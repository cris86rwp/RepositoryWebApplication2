Public Class LocateWheels
    Inherits System.Web.UI.Page
    Protected WithEvents dgData As System.Web.UI.WebControls.DataGrid
    Protected WithEvents rdoShow As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnExportDetails As System.Web.UI.WebControls.Button
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblInputCount As System.Web.UI.WebControls.Label
    Protected WithEvents lblSegregatedCount As System.Web.UI.WebControls.Label
    Protected WithEvents txtEngNo As System.Web.UI.WebControls.TextBox
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
            CreateDS()
            btnExportDetails.Enabled = False
        End If
    End Sub
    Private Sub CreateDS()
        If IsNothing(viewState("vDs")) = False Then
            CType(viewState("vDs"), DataSet).Dispose()
            viewState("vDs") = Nothing
        End If
        Dim ds As New DataSet()
        ds.Tables.Add(New DataTable())
        ds.Tables(0).Columns.Add(New DataColumn("SlNo"))
        ds.Tables(0).Columns("SlNo").AutoIncrement = True
        ds.Tables(0).Columns("SlNo").AutoIncrementSeed = 1
        ds.Tables(0).Columns("SlNo").AutoIncrementStep = 1
        ds.Tables(0).Columns.Add(New DataColumn("WhlNo", System.Type.GetType("System.String")))
        ds.Tables(0).Columns("WhlNo").MaxLength = 50
        ds.Tables(0).Columns("WhlNo").Unique = True
        ds.Tables(0).Columns.Add(New DataColumn("WhlType", System.Type.GetType("System.String")))
        ds.Tables(0).Columns("WhlType").MaxLength = 50
        ds.Tables(0).Columns.Add(New DataColumn("Status", System.Type.GetType("System.String")))
        ds.Tables(0).Columns("Status").MaxLength = 150
        ds.EnforceConstraints = True

        Dim MgTbl As DataTable = ds.Tables(0).Clone
        Dim FiTbl As DataTable = ds.Tables(0).Clone
        Dim YdTbl As DataTable = ds.Tables(0).Clone
        Dim LdTbl As DataTable = ds.Tables(0).Clone
        Dim PressTbl As DataTable = ds.Tables(0).Clone
        Dim DespTbl As DataTable = ds.Tables(0).Clone
        Dim UnBTbl As DataTable = ds.Tables(0).Clone
        Dim ReadyTbl As DataTable = ds.Tables(0).Clone
        Dim Duplicate As DataTable = ds.Tables(0).Clone
        Dim NotInMaster As DataTable = ds.Tables(0).Clone
        Dim ClosureTbl As DataTable = ds.Tables(0).Clone
        ds.Tables(0).TableName = "Master"
        ReadyTbl.TableName = "ReadyTbl"
        MgTbl.TableName = "MagTbl"
        FiTbl.TableName = "FiTbl"
        YdTbl.TableName = "YdTbl"
        LdTbl.TableName = "LdTbl"
        PressTbl.TableName = "PressTbl"
        DespTbl.TableName = "DespTbl"
        UnBTbl.TableName = "UnBore"
        Duplicate.TableName = "Duplicate"
        NotInMaster.TableName = "NotInMaster"
        ClosureTbl.TableName = "ClosureTbl"
        ds.Tables.Add(ReadyTbl)
        ds.Tables.Add(MgTbl)
        ds.Tables.Add(FiTbl)
        ds.Tables.Add(YdTbl)
        ds.Tables.Add(LdTbl)
        ds.Tables.Add(PressTbl)
        ds.Tables.Add(DespTbl)
        ds.Tables.Add(UnBTbl)
        ds.Tables.Add(ClosureTbl)
        'ds.Tables.Add(Duplicate) is avoided since it is done in Fill()
        ds.Tables.Add(NotInMaster)
        viewState("vDs") = ds
        ds = Nothing
        MgTbl = Nothing
        FiTbl = Nothing
        YdTbl = Nothing
        LdTbl = Nothing
        PressTbl = Nothing
        DespTbl = Nothing
        UnBTbl = Nothing
        ReadyTbl = Nothing
        Duplicate = Nothing
        NotInMaster = Nothing
        ClosureTbl = Nothing
    End Sub
    Private Sub txtEngNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEngNo.TextChanged
        lblInputCount.Text = ""
        lblSegregatedCount.Text = ""
        lblMessage.Text = ""
        rdoShow.ClearSelection()
        dgData.DataSource = Nothing
        dgData.DataBind()
        If txtEngNo.Text.Trim.Length > 0 Then
            Dim WhlArr() As String = txtEngNo.Text.Split(",")
            Dim i As Integer
            CreateDS()
            lblInputCount.Text = "Input Wheel Count : " + WhlArr.GetLength(0).ToString
            btnExportDetails.Enabled = False
            Try
                For i = WhlArr.GetLowerBound(0) To WhlArr.GetUpperBound(0)
                    GetMasterData(WhlArr(i))
                    If lblMessage.Text = "Blocked Heats for MoV !" Then
                        lblInputCount.Text = "Blocked Heats for MoV are entered !. Please check wheels"
                        lblMessage.Text = "Blocked Heats for MoV !"
                        txtEngNo.Text = ""
                        Exit For
                    End If
                    GetMagData(WhlArr(i))
                    GetFiData(WhlArr(i))
                    GetYdData(WhlArr(i))
                    GetLoadToAASData(WhlArr(i))
                    GetUnBoreData(WhlArr(i))
                    GetMountedData(WhlArr(i))
                    GetDespatchedData(WhlArr(i))
                    GetReadyToDesp(WhlArr(i))
                    GetClosureData(WhlArr(i))
                Next
                Fill()
                WhlArr = Nothing
                i = Nothing
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
    Private Sub Fill()
        Dim Duplicate As New DataTable()
        Dim NewDup As New DataTable()
        Try
            Dim dr As DataRow
            Dim cnt As Integer
            NewDup.TableName = "Duplicate"
            NewDup.Columns.Add("WhlNo")
            NewDup.Columns.Add("WhlType")
            NewDup.Columns.Add("Status")

            Duplicate.TableName = "Duplicate"
            Duplicate.Columns.Add("WhlNo")
            Duplicate.Columns.Add("WhlType")
            Duplicate.Columns.Add("Status")
            Dim dv As DataView = CType(viewState("vDs"), DataSet).Tables("Master").DefaultView
            Dim str As String
            If dv.Table.Rows.Count > 0 Then
                For cnt = 0 To dv.Table.Rows.Count - 1
                    Dim i, j As Integer
                    j = 0
                    i = 0
                    Str = dv.Table.Rows(cnt)(1)
                    NewDup.DefaultView.RowFilter = "WhlType = '" & str.Trim & "'"
                    If NewDup.DefaultView.Count = 0 Then
                        dr = NewDup.NewRow
                        dr("WhlNo") = dv.Table.Rows(cnt)(0)
                        dr("WhlType") = dv.Table.Rows(cnt)(1)
                        dr("Status") = dv.Table.Rows(cnt)(2)
                        NewDup.Rows.Add(dr)
                    Else
                        dr = Duplicate.NewRow
                        dr("WhlNo") = dv.Table.Rows(cnt)(0)
                        dr("WhlType") = dv.Table.Rows(cnt)(1)
                        dr("Status") = dv.Table.Rows(cnt)(2)
                        Duplicate.Rows.Add(dr)
                    End If
                    i = Nothing
                    j = Nothing
                Next
            End If
            cnt = Nothing
            dr = Nothing
            dv = Nothing
            str = Nothing
            CType(viewState("vDs"), DataSet).Tables.Add(Duplicate)
        Catch exp As Exception
            Throw New Exception(exp.Message)
        End Try
        Duplicate = Nothing
        NewDup = Nothing
    End Sub
    Private Function ReturnWheel(ByVal mystr As String) As String
        Dim myarray As Array
        Dim mywheel, myheat As String
        If mystr <> "" Then
            myarray = Split(mystr, "/")
            mywheel = myarray(0)
            myheat = myarray(1)
            Return mywheel
        End If
        myarray = Nothing
        myheat = Nothing
    End Function
    Private Function ReturnHeat(ByVal mystr As String) As String
        Dim myarray As Array
        Dim mywheel, myheat As String
        If mystr <> "" Then
            myarray = Split(mystr, "/")
            mywheel = myarray(0)
            myheat = myarray(1)
            Return myheat
        End If
        myarray = Nothing
        mywheel = Nothing
    End Function
    Private Sub GetReadyToDesp(ByVal WhlStr As String)
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Try
            Dim whl As String = ReturnWheel(WhlStr.Trim)
            Dim ht As String = ReturnHeat(WhlStr.Trim)
            If whl > 0 Then
                da.SelectCommand.CommandText = "select * from wap.dbo.mm_fn_WheelDespatchCheck(" & whl & "," & ht & ")"
                da.Fill(viewState("vDs"), "ReadyTbl")
            End If
            whl = Nothing
            ht = Nothing
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            If da.SelectCommand.Connection.State = ConnectionState.Open Then da.SelectCommand.Connection.Close()
            da.Dispose()
            da = Nothing
        End Try
    End Sub
    Private Sub GetLoadToAASData(ByVal WhlStr As String)
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        da.SelectCommand.CommandText = "Select count(*) from mm_fn_WheelInLoadingToAASArea('" & WhlStr & "')"
        Try
            da.SelectCommand.Connection.Open()
            If da.SelectCommand.ExecuteScalar > 0 Then
                da.SelectCommand.CommandText = "select * from mm_fn_WheelInLoadingToAASArea('" & WhlStr & "')"
                da.Fill(viewState("vDs"), "LdTbl")
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            If da.SelectCommand.Connection.State = ConnectionState.Open Then da.SelectCommand.Connection.Close()
            da.Dispose()
            da = Nothing
        End Try
    End Sub
    Private Sub GetYdData(ByVal WhlStr As String)
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        da.SelectCommand.CommandText = "Select count(*) from mm_yard_Inspection a inner join mm_wheel b on a.wheel_number = b.wheel_number and a.heat_number = b.heat_number where a.wheel_number = wap.dbo.mm_si_fn_WhlStrPart('" & WhlStr & "', 'w') and a.heat_number = wap.dbo.mm_si_fn_WhlStrPart('" & WhlStr & "', 'h') and b.location = 'CLQC' and '" & WhlStr & "' not in (Select whlno from mm_fn_WheelInLoadingToAASArea('" & WhlStr & "'))"

        Try
            da.SelectCommand.Connection.Open()
            If da.SelectCommand.ExecuteScalar > 0 Then
                da.SelectCommand.CommandText = "Select top 1 '" & WhlStr & "' WhlNo, rtrim(B.Description) WhlType, a.Wheel_disposition Status from mm_yard_inspection a inner join mm_wheel b on  a.wheel_number = b.wheel_number and a.heat_number = b.heat_number where a.wheel_number = wap.dbo.mm_si_fn_WhlStrPart('" & WhlStr & "', 'w') and a.heat_number = wap.dbo.mm_si_fn_WhlStrPart('" & WhlStr & "', 'h') and b.location = 'CLQC' order by a.sl_no desc "
                da.Fill(viewState("vDs"), "YdTbl")
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            If da.SelectCommand.Connection.State = ConnectionState.Open Then da.SelectCommand.Connection.Close()
            da.Dispose()
            da = Nothing
        End Try
    End Sub
    Private Sub GetFiData(ByVal WhlStr As String)
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        da.SelectCommand.CommandText = "Select count(*) from mm_final_inspection a inner join mm_wheel b on  a.wheel_number = b.wheel_number and a.heat_number = b.heat_number where a.wheel_number = wap.dbo.mm_si_fn_WhlStrPart('" & WhlStr & "', 'w') and a.heat_number = wap.dbo.mm_si_fn_WhlStrPart('" & WhlStr & "', 'h') and b.location = 'clfi' and '" & WhlStr & "' not in (Select whlno from mm_fn_WheelInLoadingToAASArea('" & WhlStr & "'))"

        Try
            da.SelectCommand.Connection.Open()
            If da.SelectCommand.ExecuteScalar > 0 Then
                da.SelectCommand.CommandText = "Select top 1 '" & WhlStr & "' WhlNo, b.description WhlType , rtrim(a.Wheel_status)+':'+rtrim(a.remarks) status from mm_final_inspection a inner join mm_wheel b on  a.wheel_number = b.wheel_number and a.heat_number = b.heat_number where a.wheel_number = wap.dbo.mm_si_fn_WhlStrPart('" & WhlStr & "', 'w') and a.heat_number = wap.dbo.mm_si_fn_WhlStrPart('" & WhlStr & "', 'h') and b.location = 'clfi' order by a.sl_no desc "
                da.Fill(viewState("vDs"), "FiTbl")
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            If da.SelectCommand.Connection.State = ConnectionState.Open Then da.SelectCommand.Connection.Close()
            da.Dispose()
            da = Nothing
        End Try
    End Sub
    Private Sub GetMagData(ByVal WhlStr As String)
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        da.SelectCommand.CommandText = "Select count(*) from mm_magnaglow_results a inner join mm_wheel b on  a.wheel_number = b.wheel_number and a.heat_number = b.heat_number where a.wheel_number = wap.dbo.mm_si_fn_WhlStrPart('" & WhlStr & "', 'w') and a.heat_number = wap.dbo.mm_si_fn_WhlStrPart('" & WhlStr & "', 'h')  and b.location = 'CLMT'"
        Try
            da.SelectCommand.Connection.Open()
            If da.SelectCommand.ExecuteScalar > 0 Then
                da.SelectCommand.CommandText = "Select top 1 '" & WhlStr & "' WhlNo, B.DESCRIPTION WhlType, rtrim(a.mcn_operation)+':'+rtrim(a.grind_status)+':'+rtrim(a.Wheel_status) Status from mm_magnaglow_results a inner join mm_wheel b on  a.wheel_number = b.wheel_number and a.heat_number = b.heat_number  where a.wheel_number = wap.dbo.mm_si_fn_WhlStrPart('" & WhlStr & "', 'w') and a.heat_number = wap.dbo.mm_si_fn_WhlStrPart('" & WhlStr & "', 'h') and b.location = 'clmt' order by a.sl_no desc "
                da.Fill(viewState("vDs"), "MagTbl")
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            If da.SelectCommand.Connection.State = ConnectionState.Open Then da.SelectCommand.Connection.Close()
            da.Dispose()
            da = Nothing
        End Try
    End Sub
    Private Sub GetMasterData(ByVal WhlStr As String)
        If lblMessage.Text = "Blocked Heats for MoV !" Then
            Exit Sub
        Else
            lblMessage.Text = ""
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            If checkWh(WhlStr) Then
                da.SelectCommand.CommandText = "Select count(*) from mm_wheel where wheel_number = wap.dbo.mm_si_fn_WhlStrPart('" & WhlStr & "', 'w') and heat_number = wap.dbo.mm_si_fn_WhlStrPart('" & WhlStr & "', 'h')"
                Try
                    da.SelectCommand.Connection.Open()
                    If da.SelectCommand.ExecuteScalar > 0 Then
                        da.SelectCommand.CommandText = "Select '" & WhlStr & "' WhlNo, description WhlType, rtrim(location)+':'+rtrim(status) Status from mm_wheel where wheel_number = wap.dbo.mm_si_fn_WhlStrPart('" & WhlStr & "', 'w') and heat_number = wap.dbo.mm_si_fn_WhlStrPart('" & WhlStr & "', 'h')"
                        da.Fill(viewState("vDs"), "Master")
                    Else
                        Dim NotInMaster As New DataTable()
                        Try
                            Dim dr As DataRow
                            Dim cnt As Integer
                            NotInMaster.TableName = "NotInMaster"
                            NotInMaster.Columns.Add("WhlNo")
                            NotInMaster.Columns.Add("WhlType")
                            NotInMaster.Columns.Add("Status")
                            dr = NotInMaster.NewRow
                            dr("WhlNo") = WhlStr.Trim
                            dr("WhlType") = "Not"
                            dr("Status") = "In Master"
                            NotInMaster.Rows.Add(dr)
                            CType(viewState("vDs"), DataSet).Tables("NotInMaster").ImportRow(dr)
                            dr = Nothing
                            cnt = Nothing
                        Catch exp As Exception
                            Throw New Exception(exp.Message)
                        End Try
                    End If
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                Finally
                    If da.SelectCommand.Connection.State = ConnectionState.Open Then da.SelectCommand.Connection.Close()
                    da.Dispose()
                    da = Nothing
                End Try
            Else
                lblMessage.Text = "Blocked Heats for MoV !"
            End If
        End If
    End Sub
    Private Sub GetUnBoreData(ByVal WhlStr As String)
        If lblMessage.Text = "Blocked Heats for MoV !" Then
            Exit Sub
        Else
            lblMessage.Text = ""
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            If checkWh(WhlStr) Then
                da.SelectCommand.CommandText = "Select count(*) from mm_wheel where wheel_number = wap.dbo.mm_si_fn_WhlStrPart('" & WhlStr & "', 'w') and heat_number = wap.dbo.mm_si_fn_WhlStrPart('" & WhlStr & "', 'h')"
                Try
                    da.SelectCommand.Connection.Open()
                    If da.SelectCommand.ExecuteScalar > 0 Then
                        da.SelectCommand.CommandText = "Select '" & WhlStr & "' WhlNo, description WhlType, rtrim(location)+':'+ltrim(rtrim(bore_status))+rtrim(status) Status from mm_wheel where wheel_number = wap.dbo.mm_si_fn_WhlStrPart('" & WhlStr & "', 'w') and heat_number = wap.dbo.mm_si_fn_WhlStrPart('" & WhlStr & "', 'h') and bore_status = 'Un-Bore'"
                        da.Fill(viewState("vDs"), "UnBTbl")
                    End If
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                Finally
                    If da.SelectCommand.Connection.State = ConnectionState.Open Then da.SelectCommand.Connection.Close()
                    da.Dispose()
                    da = Nothing
                End Try
            Else
                lblMessage.Text = "Blocked Heats for MoV !"
            End If
        End If
    End Sub
    Private Sub GetMountedData(ByVal WhlStr As String)
        If lblMessage.Text = "Blocked Heats for MoV !" Then
            Exit Sub
        Else
            lblMessage.Text = ""
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            If checkWh(WhlStr) Then
                da.SelectCommand.CommandText = "Select count(*) from mm_wheel where wheel_number = wap.dbo.mm_si_fn_WhlStrPart('" & WhlStr & "', 'w') and heat_number = wap.dbo.mm_si_fn_WhlStrPart('" & WhlStr & "', 'h')"
                Try
                    da.SelectCommand.Connection.Open()
                    If da.SelectCommand.ExecuteScalar > 0 Then
                        da.SelectCommand.CommandText = "Select '" & WhlStr & "' WhlNo, description WhlType, 'Mounted' Status from mm_wheel where wheel_number = wap.dbo.mm_si_fn_WhlStrPart('" & WhlStr & "', 'w') and heat_number = wap.dbo.mm_si_fn_WhlStrPart('" & WhlStr & "', 'h') and press_status is not null and despatch_note_number is null"
                        da.Fill(viewState("vDs"), "PressTbl")
                    End If
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                Finally
                    If da.SelectCommand.Connection.State = ConnectionState.Open Then da.SelectCommand.Connection.Close()
                    da.Dispose()
                    da = Nothing
                End Try
            Else
                lblMessage.Text = "Blocked Heats for MoV !"
            End If
        End If
    End Sub
    Private Sub GetClosureData(ByVal WhlStr As String)
        If lblMessage.Text = "Blocked Heats for MoV !" Then
            Exit Sub
        Else
            lblMessage.Text = ""
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            If checkWh(WhlStr) Then
                da.SelectCommand.CommandText = "Select wap.dbo.ms_fn_ClosureResults(wap.dbo.mm_si_fn_WhlStrPart('" & WhlStr & "', 'h'),wap.dbo.mm_si_fn_WhlStrPart('" & WhlStr & "', 'w'))"
                Try
                    da.SelectCommand.Connection.Open()
                    If da.SelectCommand.ExecuteScalar = 0 Then
                        da.SelectCommand.CommandText = "Select '" & WhlStr & "' WhlNo, description WhlType, 'Closure Values Not Available' Status from mm_wheel where wheel_number = wap.dbo.mm_si_fn_WhlStrPart('" & WhlStr & "', 'w') and heat_number = wap.dbo.mm_si_fn_WhlStrPart('" & WhlStr & "', 'h') "
                        da.Fill(viewState("vDs"), "ClosureTbl")
                    End If
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                Finally
                    If da.SelectCommand.Connection.State = ConnectionState.Open Then da.SelectCommand.Connection.Close()
                    da.Dispose()
                    da = Nothing
                End Try
            Else
                lblMessage.Text = "Blocked Heats for MoV !"
            End If
        End If
    End Sub
    Private Sub GetDespatchedData(ByVal WhlStr As String)
        If lblMessage.Text = "Blocked Heats for MoV !" Then
            Exit Sub
        Else
            lblMessage.Text = ""
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            If checkWh(WhlStr) Then
                da.SelectCommand.CommandText = "Select count(*) from mm_wheel where heat_number = wap.dbo.mm_si_fn_WhlStrPart('" & WhlStr & "', 'h')"
                Try
                    da.SelectCommand.Connection.Open()
                    If da.SelectCommand.ExecuteScalar > 0 Then
                        da.SelectCommand.CommandText = "Select '" & WhlStr & "' WhlNo, description WhlType, rtrim(location)+':'+rtrim(status)+';DcNo:'+ltrim(rtrim(despatch_note_number)) Status from mm_wheel where wheel_number = wap.dbo.mm_si_fn_WhlStrPart('" & WhlStr & "', 'w') and heat_number = wap.dbo.mm_si_fn_WhlStrPart('" & WhlStr & "', 'h') and despatch_note_number is not null"
                        da.Fill(viewState("vDs"), "DespTbl")
                    End If
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                Finally
                    If da.SelectCommand.Connection.State = ConnectionState.Open Then da.SelectCommand.Connection.Close()
                    da.Dispose()
                    da = Nothing
                End Try
            Else
                lblMessage.Text = "Blocked Heats for MoV !"
            End If
        End If
    End Sub
    Private Function checkWh(ByVal WhlStr As String) As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
        Try
            'If WhlStr.StartsWith("'") Then Throw New Exception("InValid Wheel Number !")
            'cmd.CommandText = "Select @cnt = wap.dbo.mm_si_fn_WhlStrPart('" & WhlStr & "', 'h') "
            'cmd.Connection.Open()
            'cmd.ExecuteScalar()
            If WhlStr.StartsWith("'") Then
                checkWh = False
                Throw New Exception("InValid Heat Number !")
            Else
                checkWh = True
            End If
        Catch exp As Exception
            checkWh = False
        Finally
            If IsNothing(cmd) = False Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End If
        End Try
    End Function
    Private Sub rdoShow_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoShow.SelectedIndexChanged
        dgData.DataSource = Nothing
        dgData.DataBind()
        Try
            dgData.DataSource = CType(viewstate("vDs"), DataSet).Tables(rdoShow.SelectedItem.Value).DefaultView
            dgData.DataBind()
            btnExportDetails.Enabled = dgData.Items.Count > 0
            lblSegregatedCount.Text = "Wheel Count at " & rdoShow.SelectedItem.Text & " : " + dgData.Items.Count.ToString
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub btnExportDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportDetails.Click
        If dgData.Items.Count > 0 Then
            Dim prevstate As Boolean = Me.EnableViewState
            Dim tw As New System.IO.StringWriter()
            Dim hw As New System.Web.UI.HtmlTextWriter(tw)
            Try
                Response.ContentType = "application/vnd.ms_excel"
                Response.Charset = ""
                Me.EnableViewState = False
                dgData.RenderControl(hw)
                Response.Write(tw.ToString)
                Response.End()
                Me.EnableViewState = prevstate
            Catch exp As Exception
                lblMessage.Text = exp.Message
            Finally
                prevstate = Nothing
                tw = Nothing
                hw = Nothing
            End Try
        Else
            lblMessage.Text = "No Data in Grid to export !"
        End If
    End Sub
End Class
