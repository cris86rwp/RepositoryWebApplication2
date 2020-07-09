Namespace RWF
    <Serializable()> Public Class Magna
        Public Shared Function GetProcessedValues(ByVal TestedDate As Date) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.Parameters.Add("@TestedDate", SqlDbType.SmallDateTime, 4).Value = TestedDate
                da.SelectCommand.CommandText = "select convert(varchar(10),test_date,103) TestDt , shift_code Sh , " &
                        " sum(case when wheel_status like 'S%' then 1 else 0 end) Stock , " &
                        " sum(case when wheel_status like 're%' then 1 else 0 end) ReW , " &
                        " sum(case when wheel_status like 'XC%' then 1 else 0 end) XC , " &
                        " count(*) Total " &
                        " from mm_magnaglow_results" &
                        " where test_date >= @TestedDate " &
                        " group by convert(varchar(10),test_date,103) , shift_code" &
                        " union" &
                        " select convert(varchar(10),test_date,103) TestDt , 'Total' Sh , " &
                        " sum(case when wheel_status like 'S%' then 1 else 0 end) Stock , " &
                        " sum(case when wheel_status like 're%' then 1 else 0 end) ReW ," &
                        " sum(case when wheel_status like 'XC%' then 1 else 0 end) XC , " &
                        " count(*) Total " &
                        " from mm_magnaglow_results" &
                        " where test_date >= @TestedDate " &
                        " group by convert(varchar(10),test_date,103)" &
                        " order by convert(varchar(10),test_date,103) , shift_code "
                da.Fill(ds)
                Return ds.Tables(0).Copy
            Catch exp As Exception
                Return Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function CheckNewDate(ByVal NewDate As Date) As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.CommandText = "SELECT top 1 @PinkDate = pink_date from mm_pink_sheet " &
                " order by pink_date desc "
            cmd.Parameters.Add("@PinkDate", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output
            Try
                cmd.Connection.Open()
                cmd.ExecuteScalar()
                If NewDate > IIf(IsDBNull(cmd.Parameters("@PinkDate").Value), Now.Date, cmd.Parameters("@PinkDate").Value) Then Return True
            Catch exp As Exception
                Return False
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
            End Try
            If IsNothing(cmd) = False Then
                cmd.Dispose()
                cmd = Nothing
            End If
        End Function
        Public Shared Function GetLatestDateProcessedWheels() As DataSet
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = " select top 1 test_date from mm_magnaglow_results " &
                " order by test_date desc "
            da.SelectCommand.Parameters.Add("@TestedDate", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output
            Try
                da.Fill(ds)
                da.SelectCommand.Parameters("@TestedDate").Value = IIf(IsDBNull(ds.Tables(0).Rows(0)(0)), "", ds.Tables(0).Rows(0)(0))
                ds.Reset()
                da.SelectCommand.Parameters("@TestedDate").Direction = ParameterDirection.Input
                da.SelectCommand.CommandText = "select row_number() over ( order by a.sl_no  ) Sl ," &
                    " convert(varchar(10),test_date,103) TestedDt , shift_code Sh , " &
                    " wheel_number Wheel , heat_number Heat , grind_status GrindSts , " &
                    " mcn_operation MCNSts , line_number Line , wheel_status WhlSts ," &
                    " SaveDatetime , a.sl_no Mag1 , b.sl_no Mag2" &
                    " from mm_magnaglow_results a " &
                    " inner join mm_magnaglow_shiftwiserecords b" &
                    " on wheel_number = wheelnumber and heat_number = heatnumber " &
                    " and LineNumber = Line_Number and TestDate = Test_Date" &
                    " and ShiftCode = Shift_Code and WheelStatus = Wheel_Status" &
                    " and GrindStatus = Grind_Status and McnOperation = Mcn_Operation" &
                    " where test_date = @TestedDate order by a.sl_no  ; " &
                    " select top 1 test_date from mm_magnaglow_results " &
                    " order by test_date desc "
                da.Fill(ds)
                Return ds.Copy
            Catch exp As Exception
                Return Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function WheelsNotPostedAtMagna(ByVal TestedDate As Date) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = " select row_number() over ( order by Heat desc , Whl desc) Sl ," &
                " convert(varchar(10),TestedDate,103) TestedDt , " &
                " Wheel , Status, Inspector, PreSts , PreLoc , Remarks" &
                " from mm_WheelsNotPostedAtMagna" &
                " where TestedDate = @TestedDate order by Heat , Whl "
            da.SelectCommand.Parameters.Add("@TestedDate", SqlDbType.SmallDateTime, 4).Value = TestedDate
            Try
                da.Fill(ds)
                WheelsNotPostedAtMagna = ds.Tables(0).Copy
            Catch exp As Exception
                WheelsNotPostedAtMagna = Nothing
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function IsWheelPosted(ByVal Wheel As Long, ByVal Heat As Long) As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.CommandText = "SELECT @cnt = COUNT(*) FROM mm_WheelsNotPostedAtMagna " &
                " WHERE whl = '" & CLng(Wheel) & "' and heat = '" & CLng(Heat) & "'"
            cmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            Try
                cmd.Connection.Open()
                cmd.ExecuteScalar()
                IsWheelPosted = IIf(IsDBNull(cmd.Parameters("@cnt").Value), 0, cmd.Parameters("@cnt").Value)
            Catch exp As Exception
                IsWheelPosted = False
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
            End Try
            If IsNothing(cmd) = False Then
                cmd.Dispose()
                cmd = Nothing
            End If
        End Function
        Public Shared Function checkWheel(ByVal Wheel As Long, ByVal Heat As Long) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = " select RTRIM(status) status , RTRIM(location) location , RTRIM(description) WhlType " &
                " from mm_wheel where wheel_number = '" & CLng(Wheel) & "' and heat_number = '" & CLng(Heat) & "' " &
                " and (  isnull(press_status,'') <> 'm' and  isnull(despatch_note_number,'') = '' and isnull(wagon_number,'') = '' ) "
            Try
                da.Fill(ds)
                checkWheel = ds.Tables(0).Copy
            Catch exp As Exception
                checkWheel = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function OldWheelDetails(ByVal txtwhl As String, ByVal txtWheelNo As String, ByVal txtHeatNo As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim sqlstr As String
            If txtwhl <> "" Then
                sqlstr = "select wheel_number, heat_number,location, wheel_sts Status , mag_sts magnaglow_status, bhn_rate, " &
                    " ut_sts ut_status, desp_nt_no  despatch_note_number " &
                    " from mms_not_regularly_used.dbo.mm_mmwhlpre where wheel_no = '" & txtwhl & "'"
            ElseIf txtWheelNo <> "" And txtHeatNo <> "" Then
                sqlstr = "select  wheel_number, heat_number,location, wheel_sts Status , mag_sts magnaglow_status, bhn_rate, " &
                    " ut_sts ut_status, desp_nt_no  despatch_note_number " &
                    " from mms_not_regularly_used.dbo.mm_mmwhlpre where wheel_number = " & txtWheelNo & " and heat_number = " & txtHeatNo
            ElseIf txtWheelNo = "" And txtHeatNo <> "" Then
                sqlstr = "select wheel_number, heat_number,location, wheel_sts Status , mag_sts magnaglow_status, bhn_rate, " &
                    " ut_sts ut_status, desp_nt_no  despatch_note_number " &
                    " from mms_not_regularly_used.dbo.mm_mmwhlpre where heat_number = " & txtHeatNo & " order by wheel_number "
            ElseIf txtWheelNo <> "" And txtHeatNo = "" Then
                sqlstr = "select wheel_number, heat_number,location, wheel_sts Status , mag_sts magnaglow_status, bhn_rate, " &
                    " ut_sts ut_status, desp_nt_no  despatch_note_number " &
                    " from mms_not_regularly_used.dbo.mm_mmwhlpre where wheel_number = " & txtWheelNo & " order by heat_number "
            Else
                sqlstr = ""
            End If
            da.SelectCommand.CommandText = sqlstr
            Dim ds As New DataSet()
            Try
                da.Fill(ds)
                OldWheelDetails = ds.Tables(0)
            Catch exp As Exception
                OldWheelDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
                sqlstr = Nothing
            End Try
        End Function
        Public Shared Function PinkSheetCount(ByVal PinkDate As Date, ByVal Type As String) As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.CommandText = "SELECT @cnt = COUNT(*) FROM mm_pink_sheet_heatno WHERE test_date = @Date and Type = @Type "
            cmd.Parameters.Add("@Date", SqlDbType.SmallDateTime, 4).Value = PinkDate
            cmd.Parameters.Add("@Type", SqlDbType.VarChar, 10).Value = Type
            cmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            Try
                cmd.Connection.Open()
                cmd.ExecuteScalar()
                PinkSheetCount = IIf(IsDBNull(cmd.Parameters("@cnt").Value), "1900-01-01", cmd.Parameters("@cnt").Value)
            Catch exp As Exception
                PinkSheetCount = False
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
            End Try
            If IsNothing(cmd) = False Then
                cmd.Dispose()
                cmd = Nothing
            End If
        End Function
        Public Shared Function NoBHNHeats(ByVal Heat As Long) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "select pour_order PO , Wheel_number Whl , bhn_rate BHN ,  " &
                    " rtrim(location) Loc , rtrim(status) WhlSts, " &
                    " rtrim(despatch_note_number) dcNo, rtrim(Press_status) PrSts " &
                    " from mm_wheel where heat_number = @ht and location <> 'MOPO' order by wheel_number "
            da.SelectCommand.Parameters.Add("@ht", SqlDbType.BigInt, 8).Value = Heat
            Dim ds As New DataSet()
            Try
                da.Fill(ds)
                NoBHNHeats = ds.Tables(0)
            Catch exp As Exception
                NoBHNHeats = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function NoBHNWhls(ByVal TestDt As Date) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "select b.sl_no , convert(varchar(11),b.test_date,103) TestDt  , b.shift_code Sh , " &
                " a.wheel_number Whl , a.heat_number Ht , a.bhn_rate BHN " &
                " from mm_wheel a inner join mm_magnaglow_results b " &
                " on a.wheel_number = b.wheel_number and a.heat_number = b.heat_number " &
                " where  isnull(a.bhn_rate,0) = 0  and b.test_date between @dt and dateadd(d,-1,convert(smalldatetime,convert(varchar(11), getdate()))) " &
                " order by b.heat_number, b.wheel_number"
            da.SelectCommand.Parameters.Add("@Dt", SqlDbType.SmallDateTime, 4).Value = TestDt
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters("@dt").Value = TestDt
                da.Fill(ds)
                NoBHNWhls = ds.Tables(0)
            Catch exp As Exception
                NoBHNWhls = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                If IsNothing(ds) = False Then
                    ds.Dispose()
                End If
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function PilotSl(ByVal lHeatNumber As Long, ByVal lWheelNumber As Long) As Double
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Connection.Open()
                cmd.Parameters.Add("@Cnt", SqlDbType.Float, 8).Direction = ParameterDirection.Output
                cmd.CommandText = "select @Cnt = max(sl_no)  from mm_magnaglow_shiftwiserecords " &
                                   " where wheelnumber = " & lWheelNumber & " and heatnumber = " & lHeatNumber
                cmd.ExecuteScalar()
                PilotSl = IIf(IsDBNull(cmd.Parameters("@Cnt").Value), 0, cmd.Parameters("@Cnt").Value)
            Catch exp As Exception
                PilotSl = False
                Throw New Exception(exp.Message)
            Finally
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function MagSl(ByVal lHeatNumber As Long, ByVal lWheelNumber As Long) As Double
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Connection.Open()
                cmd.Parameters.Add("@Cnt", SqlDbType.Float, 8).Direction = ParameterDirection.Output
                cmd.CommandText = "select @Cnt = max(sl_no) from mm_magnaglow_results " &
                    " where wheel_number = " & lWheelNumber & " and heat_number = " & lHeatNumber
                cmd.ExecuteScalar()
                MagSl = IIf(IsDBNull(cmd.Parameters("@Cnt").Value), 0, cmd.Parameters("@Cnt").Value)
            Catch exp As Exception
                MagSl = False
                Throw New Exception(exp.Message)
            Finally
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function TimeInFloat() As Double
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Connection.Open()
                cmd.Parameters.Add("@Cnt", SqlDbType.Float, 9).Direction = ParameterDirection.Output
                cmd.CommandText = "select @Cnt =  convert(float, getdate())"
                cmd.ExecuteScalar()
                TimeInFloat = IIf(IsDBNull(cmd.Parameters("@Cnt").Value), 0, cmd.Parameters("@Cnt").Value)
            Catch exp As Exception
                TimeInFloat = False
                Throw New Exception(exp.Message)
            Finally
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function TimeEntered() As String
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Connection.Open()
                cmd.Parameters.Add("@TimeEntered", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                cmd.CommandText = "select @TimeEntered = convert(varchar,getdate(),108) "
                cmd.ExecuteScalar()
                TimeEntered = IIf(IsDBNull(cmd.Parameters("@TimeEntered").Value), "", cmd.Parameters("@TimeEntered").Value)
            Catch exp As Exception
                TimeEntered = ""
                Throw New Exception(exp.Message)
            Finally
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function CheckDt(ByVal lHeatNumber As Long, ByVal lWheelNumber As Long) As Integer
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Connection.Open()
                cmd.Parameters.Add("@Cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                cmd.CommandText = "select @Cnt = count(*) from mm_magnaglow_results " &
                    " where wheel_number = " & lWheelNumber & " and heat_number = " & lHeatNumber & " " &
                    " and test_date> ( select max(pink_date) from mm_pink_sheet)"

                cmd.ExecuteScalar()
                CheckDt = IIf(IsDBNull(cmd.Parameters("@Cnt").Value), 0, cmd.Parameters("@Cnt").Value)
            Catch exp As Exception
                CheckDt = False
                Throw New Exception(exp.Message)
            Finally
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function WhlDetails(ByVal lWheelNumber As Long, ByVal lHeatNumber As Long) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = " select convert(varchar(10),test_date,103) TestDt , shift_code Sh , line_number Line , " &
                    " grind_status GrSts , mcn_operation McnOp , wheel_status WhlSts , ut_result UT , bhn_rate BHN , remarks " &
                    " , time_entered TimeEn , wheel_transfer_status WhlType from mm_magnaglow_results a inner join mm_wheel b " &
                    " on a.wheel_number=b.wheel_number and a.heat_number = b.heat_number " &
                    " where a.wheel_number = " & lWheelNumber & " And a.heat_number = " & lHeatNumber & "" &
                    " order by sl_no desc"
                da.Fill(ds)
                WhlDetails = ds.Tables(0)
            Catch exp As Exception
                WhlDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function whllocation(ByVal lHeatNumber As Long, ByVal lWheelNumber As Long) As String
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Connection.Open()
                cmd.Parameters.Add("@whllocation", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                cmd.CommandText = "select @whllocation = isnull(rtrim(location),'') from  mm_wheel where wheel_number = " & lWheelNumber & " and heat_number = " & lHeatNumber
                cmd.ExecuteScalar()
                whllocation = IIf(IsDBNull(cmd.Parameters("@whllocation").Value), "", cmd.Parameters("@whllocation").Value)
            Catch exp As Exception
                whllocation = ""
                Throw New Exception(exp.Message)
            Finally
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function DespMounted(ByVal lHeatNumber As Long, ByVal lWheelNumber As Long) As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Connection.Open()
                cmd.Parameters.Add("@Cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                cmd.CommandText = "select @Cnt = count(*) from mm_wheel where wheel_number = " & lWheelNumber & " " &
                    " and heat_number = " & lHeatNumber & " and  isnull(press_status,'') = '' and isnull(despatch_note_number,'') = '' "
                cmd.ExecuteScalar()
                DespMounted = IIf(IsDBNull(cmd.Parameters("@Cnt").Value), 0, cmd.Parameters("@Cnt").Value)
            Catch exp As Exception
                DespMounted = False
                Throw New Exception(exp.Message)
            Finally
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function RegHeat(ByVal lHeatNumber As Long) As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Connection.Open()
                cmd.Parameters.Add("@Cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                cmd.CommandText = "select @Cnt = heat_number from mm_mgc_wheels where alternate_number = '" & lHeatNumber.ToString.Trim & "'"
                cmd.ExecuteScalar()
                RegHeat = IIf(IsDBNull(cmd.Parameters("@Cnt").Value), 0, cmd.Parameters("@Cnt").Value)
            Catch exp As Exception
                RegHeat = False
                Throw New Exception(exp.Message)
            Finally
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function GetPinkReportDateTypes(ByVal PinkDate As Date) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Connection = rwfGen.Connection.ConObj
                da.SelectCommand.CommandText = "select distinct Type  FROM mm_vw_PinkSheet_ReportDates " &
                    " where test_date = @PinkDate order by Type desc"
                da.SelectCommand.Parameters.Add("@PinkDate", SqlDbType.SmallDateTime, 4).Value = PinkDate
                da.Fill(ds)
                GetPinkReportDateTypes = ds.Tables(0)
            Catch exp As Exception
                GetPinkReportDateTypes = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function GetPinkReportDates() As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Connection = rwfGen.Connection.ConObj
                da.SelectCommand.CommandText = "select distinct convert(varchar(11),test_date,103) test_date , test_date " &
                    " FROM mm_vw_PinkSheet_ReportDates " &
                    " where test_date > ( select distinct top 1 PinkDate from mm_PinkSheet_TOP10 " &
                    " order by PinkDate ) order by test_date desc "
                da.Fill(ds)
                GetPinkReportDates = ds.Tables(0)
            Catch exp As Exception
                GetPinkReportDates = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function PinkGridDetails(ByVal PinkDate As Date) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Connection = rwfGen.Connection.ConObj
                da.SelectCommand.CommandText = "Select  convert(varchar(10),test_date,103) TestDate  , " &
                    " rtrim(ltrim(Type)) Type ,CummProcessed PCumm, " &
                    " mm_pink_sheet_misc.SCummLine1+mm_pink_sheet_misc.SCummLine1A + mm_pink_sheet_misc.SCummLine2 " &
                    " +mm_pink_sheet_misc.SCummLine2A+mm_pink_sheet_misc.SCummYard+ mm_pink_sheet_misc.SCummLine1B SCumm ," &
                    " YardStock, FiStock , CummNew , CummGoodWH , " &
                    " mm_pink_sheet_misc.XCummNew+mm_pink_sheet_misc.XCummReload + mm_pink_sheet_misc.XCummYard" &
                    " +mm_pink_sheet_misc.XCummFI XCumm " &
                    " from mm_pink_sheet_misc where test_date = @PinkDate "
                da.SelectCommand.Parameters.Add("@PinkDate", SqlDbType.SmallDateTime, 4).Value = PinkDate
                da.Fill(ds)
                PinkGridDetails = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function CheckPinkDate(ByVal PinkDate As Date, ByVal chkReGenerateVisible As Boolean, ByVal chkReGenerateChecked As Boolean) As String
            Dim DLastPinkDate As Date
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@PinkDate", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = "select top 1 @Pink_Date = pink_date from mm_pink_sheet order by pink_date desc "
                oCmd.Parameters.Add("@Pink_Date", SqlDbType.DateTime, 8).Direction = ParameterDirection.Output
                oCmd.ExecuteScalar()
                DLastPinkDate = oCmd.Parameters("@Pink_Date").Value
                If PinkDate >= Today Then
                    CheckPinkDate = "You cannot Generate pink sheet for : " & PinkDate
                ElseIf PinkDate < DLastPinkDate Then
                    CheckPinkDate = "You cannot Re-Generate previous pink sheets. Input Date : " & PinkDate & " is rejected."
                ElseIf PinkDate = DLastPinkDate Then
                    If chkReGenerateVisible = True Then
                        If chkReGenerateChecked = False Then
                            CheckPinkDate = "You have not authorised Re-Generation for : " & PinkDate
                        End If
                    Else
                        CheckPinkDate = "Authorise Re-Generation by Ticking Re-Generate check box."
                    End If
                End If
            Catch exp As Exception
                CheckPinkDate = exp.Message
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
            DLastPinkDate = Nothing
        End Function
        Public Shared Function GetTop1MagnaDate() As Date
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@PinkDate", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = "select  distinct top 1 @PinkDate = test_date from mm_magnaglow_results " &
                    " where test_Date < Convert(smalldatetime, Convert(varchar(11), getdate())) " &
                    " order by test_date desc "
                oCmd.ExecuteScalar()
                GetTop1MagnaDate = IIf(IsDBNull(oCmd.Parameters("@PinkDate").Value), "1900-01-01", oCmd.Parameters("@PinkDate").Value)
            Catch exp As Exception
                GetTop1MagnaDate = "1900-01-01"
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function
        Public Function GeneratePinkSheet(ByVal PinkDate As Date) As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "mm_sp_pink_sheet_generate_All"
            cmd.CommandTimeout = (60 * 30)
            cmd.Parameters.Add("@Date", SqlDbType.SmallDateTime, 4).Value = PinkDate
            Try
                cmd.Connection.Open()
                If cmd.ExecuteNonQuery() > 0 Then GeneratePinkSheet = True
            Catch exp As Exception
                GeneratePinkSheet = False
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End Try
            cmd.Dispose()
            cmd = Nothing
        End Function
        Public Function GeneratePinkSheetreportData(ByVal PinkDate As Date, ByVal Type As String) As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "mm_sp_PinkSheet_TOP10"
            cmd.CommandTimeout = (60 * 30)
            cmd.Parameters.Add("@PinkDt", SqlDbType.SmallDateTime, 4).Value = PinkDate
            cmd.Parameters.Add("@Type", SqlDbType.VarChar, 10).Value = Type
            Try
                cmd.Connection.Open()
                If cmd.ExecuteNonQuery() > 0 Then
                    cmd.CommandText = "mm_sp_PinkSheet_LeftOver"
                    If cmd.ExecuteNonQuery() > 0 Then
                        cmd.CommandText = "mm_sp_PinkSheet_TotalNewReLoad"
                        If cmd.ExecuteNonQuery() > 0 Then
                            cmd.CommandText = "mm_sp_PinkSheet_LocationWiseRej"
                            If cmd.ExecuteNonQuery() > 0 Then
                                GeneratePinkSheetreportData = True
                            End If
                        End If
                    End If
                End If
            Catch exp As Exception
                GeneratePinkSheetreportData = False
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End Try
            If IsNothing(cmd) = False Then
                cmd.Dispose()
                cmd = Nothing
            End If
        End Function
        Public Function GenerateRWFNormsData(ByVal NormsDate As Date, ByVal WhlType As String) As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = (60 * 30)
            cmd.Parameters.Add("@Date", SqlDbType.SmallDateTime, 4).Value = NormsDate
            cmd.Parameters.Add("@WhlType", SqlDbType.VarChar, 50).Value = WhlType
            Try
                cmd.Connection.Open()
                cmd.CommandType = CommandType.StoredProcedure
                If WhlType = "Total" Then
                    cmd.CommandText = "mm_sp_RWFNormsXCCountTotal"
                Else
                    cmd.CommandText = "mm_sp_RWFNormsXCCount"
                End If
                If cmd.ExecuteNonQuery() > 0 Then
                    GenerateRWFNormsData = True
                End If
            Catch exp As Exception
                GenerateRWFNormsData = False
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            End Try
            If IsNothing(cmd) = False Then
                cmd.Dispose()
                cmd = Nothing
            End If
        End Function
        Public Function Update(ByVal Iwheel As Long, ByVal IHeat As Long, ByVal userid As String, ByVal McnOperation As String, ByVal GrindStatus As String, ByVal WheelStatusText As String, ByVal UTStatus As String, ByVal Remarks As String, ByVal WO As String, ByVal CurrentWheelType As String, ByVal MagWheelNumber As Integer, ByVal MagHeatNumber As Integer, ByVal cMagSts As String, ByVal BHN0Value As Integer) As Boolean
            Dim GetMagTableSlno, GetPilotTableSlno, updtMagTable, updtPilotTable, updtMaster, PreModifiedRecord As String
            Dim magTableSlno, PilotTableSlno As Long
            Dim TimeEntered As String = RWF.Magna.TimeEntered
            Dim TimeInFloat As Double = RWF.Magna.TimeInFloat
            GetMagTableSlno = RWF.Magna.MagSl(IHeat, Iwheel)
            GetPilotTableSlno = RWF.Magna.PilotSl(IHeat, Iwheel)

            PreModifiedRecord = "insert into mm_magnaglow_results_Audit select *, '"
            PreModifiedRecord &= userid & "', getdate() from mm_magnaglow_results where sl_no = "
            PreModifiedRecord &= GetMagTableSlno

            updtMagTable = "Update mm_magnaglow_results set grind_status = '" & GrindStatus &
                        "', mcn_operation = '" & McnOperation & "', wheel_status = '" &
                        WheelStatusText & "', ut_result = '" & UTStatus &
                        "', remarks = '" & Remarks & "', time_entered = '" & TimeEntered & "', " &
                        " workorder_number = '" & WO & "', wheel_transfer_status = '" &
                        CurrentWheelType & "' " &
                        " where wheel_number = " & MagWheelNumber & " and heat_number = " &
                        MagHeatNumber & " and sl_no = " &
                        GetMagTableSlno

            updtPilotTable = "Update mm_magnaglow_shiftwiserecords set grindstatus = '" & GrindStatus &
                        "', mcnoperation = '" & McnOperation & "', wheelstatus = '" &
                        WheelStatusText & "', utstatus = '" & UTStatus &
                        "', remarks = '" & Remarks & "', SaveDatetime = '" & Format(Now(), "yyyy/MM/dd HH:mm:ss").ToString

            If (Left(WheelStatusText.ToLower, 1) = "x" Or Left(WheelStatusText.ToLower, 1) = "s") = True Then
                If WheelStatusText.ToLower = "xc8rht" Then
                    ' following login added on 28/7/06 svi
                    updtPilotTable &= "' , xcorStock = " & TimeInFloat
                Else
                    updtPilotTable &= "' , xcorStock = 0.0"
                End If
            Else
                updtPilotTable &= "', xcorstock = " & TimeInFloat
            End If
            Dim lmagPilotSlno As Long
            Try
                lmagPilotSlno = GetPilotTableSlno
            Catch exp1 As Exception
                lmagPilotSlno = 0
            End Try

            If lmagPilotSlno > 0 Then
                updtPilotTable &= ", description = '" & CurrentWheelType & "' " &
                            " where wheelnumber = " & MagWheelNumber & " and heatnumber = " &
                            MagHeatNumber & " and sl_no = " &
                            lmagPilotSlno
            Else
                updtPilotTable = ""
            End If

            updtMaster = "update mm_wheel set status = '" & WheelStatusText &
                          "', magnaglow_status = '" & cMagSts & "', bhn_rate = " & Val(BHN0Value) &
                          ", workorder_cleaning_room = '" & WO & "', description = '" &
                          CurrentWheelType & "' " &
                          " where wheel_number = " & MagWheelNumber &
                          " and heat_number = " & MagHeatNumber
            Dim Done As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                cmd.CommandText = PreModifiedRecord
                If cmd.ExecuteNonQuery() = 1 Then
                    If lmagPilotSlno > 0 Then
                        cmd.CommandText = updtPilotTable
                        cmd.ExecuteNonQuery()
                    End If
                    cmd.CommandText = updtMaster
                    If cmd.ExecuteNonQuery() > 0 Then
                        cmd.CommandText = updtMagTable
                        If cmd.ExecuteNonQuery() = 1 Then Done = True
                    End If
                End If
            Catch exp As Exception
                Done = False
            Finally
                If Done Then
                    cmd.Transaction.Commit()
                Else
                    cmd.Transaction.Rollback()
                End If
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                If IsNothing(cmd) = False Then
                    cmd.Dispose()
                    cmd = Nothing
                End If
            End Try
            GetMagTableSlno = Nothing
            GetPilotTableSlno = Nothing
            updtMagTable = Nothing
            updtPilotTable = Nothing
            updtMaster = Nothing
            PreModifiedRecord = Nothing
            magTableSlno = Nothing
            PilotTableSlno = Nothing
            TimeEntered = Nothing
            TimeInFloat = Nothing
            Return Done
        End Function

        Public Shared Function GetHTbatchNo(ByVal Wheel_Number As Long, ByVal heat_No As Long) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@WHNo", SqlDbType.VarChar, 5).Value = Wheel_Number
                da.SelectCommand.Parameters.Add("@HNo", SqlDbType.VarChar, 5).Value = heat_No
                da.SelectCommand.CommandText = "select Batch_No BNo FROM mm_wheel_heat_batch_details where Wheel_Number=@WHNo and heat_No=@HNo "
                da.Fill(ds)
                GetHTbatchNo = ds.Tables(0)
            Catch exp As Exception
                GetHTbatchNo = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function

        Public Shared Function GetLine3data(ByVal Wheel_Number As Long, ByVal heat_No As Long) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@WHNo", SqlDbType.VarChar, 5).Value = Wheel_Number
                da.SelectCommand.Parameters.Add("@HNo", SqlDbType.VarChar, 5).Value = heat_No
                da.SelectCommand.CommandText = "SELECT TOP 1 bhn BHN, bcf BCF, utbatch UTBTNo,utstatus UTSTS,utwheelno UTWNo FROM mm_magnaglow_shiftwiserecords_new where heatno=@HNo and wheelno=@WHNo order by Magid desc"
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
        Public Shared Function GetLine3newdata(ByVal Wheel_Number As Long, ByVal heat_No As Long) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@WHNo", SqlDbType.VarChar, 5).Value = Wheel_Number
                da.SelectCommand.Parameters.Add("@HNo", SqlDbType.VarChar, 5).Value = heat_No
                da.SelectCommand.CommandText = "SELECT TOP 1 BHN, WheelType WHLTYPE, BCF, UtBatch UTBTNo,UtStatus UTSTS,UtWheelNo UTWNo from mm_magnaglow_new_shiftwiserecords where HeatNo=@HNo and WheelNo=@WHNo order by Magid desc"
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

        Public Function UpdateBHN(ByVal HeatNumber As Long, ByVal WheelNumber As Long, ByVal BHN As Integer) As Boolean
            Dim blnSaved As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.CommandText = "Update mm_wheel set bhn_rate = @BhnRate where wheel_number = @wh and heat_number = @ht"
                cmd.Parameters.Add("@Wh", SqlDbType.BigInt, 8).Value = CLng(WheelNumber)
                cmd.Parameters.Add("@ht", SqlDbType.BigInt, 8).Value = CLng(HeatNumber)
                cmd.Parameters.Add("@BhnRate", SqlDbType.Int, 4).Value = CInt(BHN)
                cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                If cmd.ExecuteNonQuery() > 0 Then blnSaved = True
            Catch exp As Exception
                Throw New Exception("Update Error : " & WheelNumber & "/" & HeatNumber & ":" & exp.Message)
            Finally
                If IsNothing(cmd) = False Then
                    If blnSaved Then
                        cmd.Transaction.Commit()
                    Else
                        cmd.Transaction.Rollback()
                    End If
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                End If
            End Try
            Return blnSaved
        End Function
        Public Function SaveWheelsNotPostedAtMagna(ByVal TestedDate As Date, ByVal Wheel As String, ByVal Status As String, ByVal Inspector As String, ByVal Remarks As String, ByVal PreSts As String, ByVal PreLoc As String, Optional ByVal Delete As Boolean = False) As Boolean
            Dim blnSaved As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            If Delete Then
                cmd.CommandText = "delete mm_WheelsNotPostedAtMagna " &
                    " where Whl = @Whl and Heat =  @Heat "
            Else
                cmd.CommandText = "insert into mm_WheelsNotPostedAtMagna " &
                    " ( TestedDate , Wheel , Whl , Heat , Status , Inspector , Remarks , PreSts , PreLoc ) values " &
                    " ( @TestedDate , @Wheel , @Whl , @Heat , @Status , @Inspector , @Remarks , @PreSts , @PreLoc) "
            End If

            Dim a As Array = Wheel.Split("/")
            Try
                cmd.Parameters.Add("@TestedDate", SqlDbType.SmallDateTime, 4).Value = TestedDate
                cmd.Parameters.Add("@Whl", SqlDbType.BigInt, 8).Value = CLng(a(0))
                cmd.Parameters.Add("@Heat", SqlDbType.BigInt, 8).Value = CLng(a(1))
                cmd.Parameters.Add("@Wheel", SqlDbType.VarChar, 50).Value = Wheel
                cmd.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = Status
                cmd.Parameters.Add("@Inspector", SqlDbType.VarChar, 50).Value = Inspector
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 50).Value = Remarks
                cmd.Parameters.Add("@PreSts", SqlDbType.VarChar, 50).Value = PreSts
                cmd.Parameters.Add("@PreLoc", SqlDbType.VarChar, 50).Value = PreLoc
                cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                If cmd.ExecuteNonQuery() > 0 Then blnSaved = True
            Catch exp As Exception
                Throw New Exception("Data Saving Error : " & CLng(a(0)) & "/" & CLng(a(1)) & ":" & exp.Message)
            Finally
                If IsNothing(cmd) = False Then
                    If blnSaved Then
                        cmd.Transaction.Commit()
                    Else
                        cmd.Transaction.Rollback()
                    End If
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                End If
            End Try
            a = Nothing
            Return blnSaved
        End Function
        Public Function UpdateMagDate(ByVal test_date As Date, ByVal new_test_date As Date, ByVal shift_code As String, ByVal UpDatedBy As String, ByVal Mag1Start As Long, ByVal Mag2Start As Long, ByVal Mag1End As Long, ByVal Mag2End As Long) As Boolean
            Dim blnSaved As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@test_date", SqlDbType.SmallDateTime, 4).Value = test_date
            cmd.Parameters.Add("@new_test_date", SqlDbType.SmallDateTime, 4).Value = new_test_date
            cmd.Parameters.Add("@shift_code", SqlDbType.VarChar, 1).Value = shift_code
            cmd.Parameters.Add("@UpDatedBy", SqlDbType.VarChar, 6).Value = UpDatedBy
            cmd.Parameters.Add("@Mag1Start", SqlDbType.BigInt, 8).Value = Mag1Start
            cmd.Parameters.Add("@Mag1End", SqlDbType.BigInt, 8).Value = Mag1End
            cmd.Parameters.Add("@Mag2Start", SqlDbType.BigInt, 8).Value = Mag2Start
            cmd.Parameters.Add("@Mag2End", SqlDbType.BigInt, 8).Value = Mag2End
            cmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            Try
                cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                cmd.CommandText = " select @cnt = count(*) from mm_magnaglow_ShiftwiseRecords " &
                   " where testdate = @test_date and sl_no  between @Mag2Start and @Mag2End "
                cmd.ExecuteScalar()
                cmd.Parameters("@cnt").Value = IIf(IsDBNull(cmd.Parameters("@cnt").Value), 0, cmd.Parameters("@cnt").Value)
                cmd.Parameters("@cnt").Direction = ParameterDirection.Input

                cmd.CommandText = " update mm_magnaglow_ShiftwiseRecords " &
                    " set testdate = @new_test_date , shiftcode = @shift_code " &
                    " where testdate = @test_date and sl_no  between @Mag2Start and @Mag2End"
                If cmd.ExecuteNonQuery() > 0 Then
                    cmd.CommandText = " update mm_magnaglow_results" &
                        " set  test_date = @new_test_date , shift_code = @shift_code " &
                        " where test_date = @test_date  and sl_no between @Mag1Start and @Mag1End "
                    If cmd.ExecuteNonQuery() > 0 Then
                        cmd.CommandText = " insert into mm_magnaglow_results_DateChanged " &
                                " ( test_date , new_test_date , new_shift_code , NoOfRecords , UpDatedBy , UpDatedTime) values  " &
                                " ( @test_date , @new_test_date , @shift_code , @cnt , @UpDatedBy , getdate() )"
                        If cmd.ExecuteNonQuery() > 0 Then blnSaved = True
                    End If
                End If
            Catch exp As Exception
                Throw New Exception("Updatation of Mag Table error ! " & exp.Message)
            Finally
                If IsNothing(cmd) = False Then
                    If blnSaved Then
                        cmd.Transaction.Commit()
                    Else
                        cmd.Transaction.Rollback()
                    End If
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                End If
            End Try
            Return blnSaved
        End Function
    End Class
End Namespace
