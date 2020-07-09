Public Class HotWheelLine1
    Public Shared Function PopulateDgData(ByVal heat_number As Long) As DataTable
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        da.SelectCommand.CommandText = "select a.sl_no, a.heat_number HtNo, pouring_order PO , " & _
            " wheel_number Whl , WhlTemp , TopDia TopD , BottomDia BotD ," & _
            " McnCode Mcn ,  OffLdCode OffCode , a.Remarks from mm_MouldRoom_Offloads a " & _
            " inner join mm_pouring b on a.heat_number = b.heat_number and wheel_number = engraved_number " & _
            " where a.heat_number = @heat_number  order by pouring_order "
        Try
            da.SelectCommand.Parameters.Add("@heat_number", SqlDbType.BigInt, 9).Value = heat_number
            da.Fill(ds)
            PopulateDgData = ds.Tables(0)
        Catch exp As Exception
            PopulateDgData = Nothing
            Throw New Exception(exp.Message)
        Finally
            da.Dispose()
            ds.Dispose()
            da = Nothing
            ds = Nothing
        End Try
    End Function
    Public Shared Function PopulateWheelsGrid(ByVal HeatNumber As Double) As DataSet
        Dim ds As New DataSet()
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim strHeatCheck, strWheels As String
        da.SelectCommand.CommandText = "select a.heat_number Heat , engraved_number Whl , " & _
                " pouring_order PO , rtrim(rejection_code) Sts from mm_pouring a" & _
                " left outer join ( select heat_number, wheel_number, max(sl_no) Sl_No " & _
                " from mm_MouldRoom_Offloads group by heat_number, wheel_number " & _
                " ) b on b.heat_number = a.heat_number and b.wheel_number = engraved_number" & _
                " where a.heat_number = @HeatNumber and b.heat_number is null" & _
                " and rejection_code not in ( '6' , '6&7' , 'x%' ) order by pouring_order ; " & _
                " select heat_number Heat , engraved_number Whl , " & _
                " pouring_order PO , rtrim(rejection_code) Sts from mm_pouring " & _
                " where heat_number = @HeatNumber and rejection_code in ( '6' , '6&7' , 'x%' )" & _
                " order by pouring_order ; "
        da.SelectCommand.Parameters.Add("@HeatNumber", SqlDbType.BigInt, 9).Value = HeatNumber
        Try
            da.Fill(ds)
            PopulateWheelsGrid = ds.Copy
        Catch exp As Exception
            PopulateWheelsGrid = Nothing
            Throw New Exception("Data Retrieval Error : " & exp.Message)
        Finally
            da.Dispose()
            ds.Dispose()
            da = Nothing
            ds = Nothing
        End Try
    End Function
    Public Shared Function PopulateDdls(Optional ByVal Type As Integer = 0) As DataSet
        Dim ds As New DataSet()
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        If Type = 1 Then
            da.SelectCommand.CommandText = "Select rtrim(machine_code) machine_code from ms_machinery_master " & _
                " where machine_code like 'moq%'  order by rtrim(machine_code) ; " & _
                " select 'OK' code union " & _
                " select code from mm_mmofrej_dump  where code not like '[0,1,2,3,4,5,6,7,8,9,x]%' and code <> 'ok' "
        ElseIf Type = 2 Then
            da.SelectCommand.CommandText = "select OffLoadType , TypeID from mm_MROffloadType ; " & _
                " select 'OK' code union " & _
                " select code from mm_mmofrej_dump  where code not like '[0,1,2,3,4,5,6,7,8,9,x]%' and code not in ( 'mrx' , 'ok' )"
        ElseIf Type = 0 Then
            da.SelectCommand.CommandText = "Select rtrim(machine_code) machine_code from ms_machinery_master " & _
                " where machine_code like 'mohub%' and machine_code <> 'MOHUB5' order by rtrim(machine_code) ; " & _
                " select 'OK' code union " & _
                " select code from mm_mmofrej_dump  where code not like '[0,1,2,3,4,5,6,7,8,9,x]%' and code <> 'ok' "
        End If
        Try
            da.Fill(ds)
            PopulateDdls = ds.Copy
        Catch exp As Exception
            PopulateDdls = Nothing
            Throw New Exception("Data Retrieval Error : " & exp.Message)
        Finally
            da.Dispose()
            ds.Dispose()
            da = Nothing
            ds = Nothing
        End Try
    End Function
    Public Shared Function MRHeatsTapped(ByVal DefectDate As Date, ByVal Shift As String) As DataTable
        Dim ds As New DataSet()
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Try
            da.SelectCommand.Parameters.Add("@TappedDate", SqlDbType.SmallDateTime, 4).Value = CDate(DefectDate)
            da.SelectCommand.Parameters.Add("@TappedShift", SqlDbType.VarChar, 1).Value = Shift
            da.SelectCommand.CommandText = "select a.heat_number from mm_vw_HeatTapped a " & _
                " inner join mm_pre_pouring b on b.heat_number = a.heat_number " & _
                " where TappedDate = @TappedDate and TappedShift =  @TappedShift " & _
                " ORDER BY a.heat_number "
            da.Fill(ds)
            Return ds.Tables(0)
        Catch exp As Exception
            Throw New Exception("Data Retrieval Error : " & exp.Message)
        Finally
            da.Dispose()
            ds.Dispose()
            da = Nothing
            ds = Nothing
        End Try
    End Function
    Public Function DeleteHubCutRec(ByVal sl_no As Long) As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.Parameters.Add("@sl_no", SqlDbType.BigInt, 8).Value = sl_no
        Try
            cmd.CommandText = "delete mm_MouldRoom_Offloads where sl_no = @sl_no"
            If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
            If cmd.ExecuteNonQuery() Then DeleteHubCutRec = True
        Catch exp As Exception
            DeleteHubCutRec = False
            Throw New Exception(exp.Message)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
        End Try
    End Function
    Public Function AddHubCutRec(ByVal Heat_Number As Long, ByVal WheelList As String, ByVal OffLdCode As String, ByVal OffLdDate As Date, ByVal OffLdShift As String, ByVal EnteredBy As String, ByVal ShiftIc As String, ByVal LineIc As String, ByVal Operators As String, ByVal Remarks As String, ByVal McnCode As String, ByVal dtStart As DateTime, ByVal dtEnd As DateTime, ByVal WhlTemp As Integer, ByVal TopDia As String, ByVal BottomDia As String) As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.Parameters.Add("@Heat_Number", SqlDbType.BigInt, 8).Value = Heat_Number
        cmd.Parameters.Add("@OffLdCode", SqlDbType.VarChar, 50).Value = OffLdCode
        cmd.Parameters.Add("@OffLdDate", SqlDbType.SmallDateTime, 4).Value = OffLdDate
        cmd.Parameters.Add("@OffLdShift", SqlDbType.VarChar, 1).Value = OffLdShift
        cmd.Parameters.Add("@EnteredBy", SqlDbType.VarChar, 6).Value = EnteredBy
        cmd.Parameters.Add("@ShiftIc", SqlDbType.VarChar, 6).Value = ShiftIc
        cmd.Parameters.Add("@LineIc", SqlDbType.VarChar, 6).Value = LineIc
        cmd.Parameters.Add("@Operators", SqlDbType.VarChar, 50).Value = Operators
        cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 1000).Value = Remarks
        cmd.Parameters.Add("@McnCode", SqlDbType.VarChar, 50).Value = McnCode
        cmd.Parameters.Add("@SaveDateTime", SqlDbType.DateTime, 8).Value = Now
        cmd.Parameters.Add("@WhlTemp", SqlDbType.Int, 4).Value = WhlTemp
        cmd.Parameters.Add("@hub_cut_sttime", SqlDbType.DateTime, 8).Value = dtStart
        cmd.Parameters.Add("@hub_cut_endtime", SqlDbType.DateTime, 8).Value = dtEnd
        cmd.Parameters.Add("@TopDia", SqlDbType.VarChar, 10).Value = TopDia
        cmd.Parameters.Add("@BottomDia", SqlDbType.VarChar, 10).Value = BottomDia
        Try
            cmd.CommandText = "insert into mm_MouldRoom_Offloads ( Heat_Number, wheel_number, " &
                " OffLdCode, OffLdDate, OffLdShift, EnteredBy, ShiftIc , " &
                " LineIc, Operators,  Remarks, McnCode, SaveDateTime , WhlTemp , TopDia  , BottomDia ) " &
                " select @Heat_Number, engraved_number wheel_number , @OffLdCode, @OffLdDate, @OffLdShift, @EnteredBy, @ShiftIc, " &
                " @LineIc, @Operators, @Remarks, @McnCode, @SaveDateTime , @WhlTemp , @TopDia , @BottomDia " &
                " from mm_pouring  where heat_number = @Heat_Number and engraved_number in " & "(" & WheelList.Trim & ")"
            If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
            If cmd.ExecuteNonQuery() > 0 Then
                If dtStart.Hour = 0 AndAlso dtStart.Minute = 0 AndAlso dtEnd.Hour = 0 AndAlso dtEnd.Minute = 0 Then
                    AddHubCutRec = True
                Else
                    cmd.CommandText = "update mm_post_pouring" &
                            " set hub_cut_sttime  = @hub_cut_sttime , hub_cut_endtime = @hub_cut_endtime" &
                            " where heat_number = @heat_number"
                    If cmd.ExecuteNonQuery = 1 Then AddHubCutRec = True
                End If
            End If
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
        End Try
        Return AddHubCutRec
    End Function
End Class
