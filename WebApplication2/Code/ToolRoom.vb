Namespace ToolRoom
    <Serializable()> Public Class Tables
        Public Shared Function InHouseCalibrationCheck(ByVal instrument_number As String) As Boolean
            Dim cmd As System.Data.SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            cmd.Parameters.Add("@instrument_number", SqlDbType.VarChar, 50).Value = instrument_number
            cmd.Parameters.Add("@CalibrationCode", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            Try
                cmd.CommandText = "select @cnt = isnull(count(*),0) from ms_tools_group a inner join ms_tools_master b  " & _
                   " on a.group_name = b.group_name  " & _
                   " where a.work_instruction_number = 'OUTSIDE AGENCY'  " & _
                   " and history_card_number = @instrument_number "
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.ExecuteScalar()
                If IIf(IsDBNull(cmd.Parameters("@cnt").Value), 0, cmd.Parameters("@cnt").Value) = 0 Then
                    cmd.CommandText = "select top 1 @CalibrationCode =  calibration_code FROM ms_tools_calibration " & _
                                           " WHERE instrument_number = @instrument_number order by calibration_code desc"

                    cmd.Parameters("@CalibrationCode").Direction = ParameterDirection.Input
                    cmd.CommandText = "select @cnt = count(*) FROM ms_tools_InHouseData " & _
                        " WHERE CalibrationCode = @CalibrationCode "
                    cmd.ExecuteScalar()
                    InHouseCalibrationCheck = IIf(IsDBNull(cmd.Parameters("@cnt").Value), False, cmd.Parameters("@cnt").Value)
                Else
                    InHouseCalibrationCheck = True
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
            End Try
        End Function
        Public Shared Function InHouseCalibratedPreData(ByVal CalibrationCode As Integer) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@CalibrationCode", SqlDbType.Int, 4).Value = CalibrationCode
                da.SelectCommand.CommandText = " select SlNo , " & _
                    " convert(varchar,convert(decimal(18,3),SizeOfValue)) SizeOfValue , " & _
                    " convert(varchar,convert(decimal(18,3),Reading)) Reading , " & _
                    " convert(varchar,convert(decimal(18,3),Error)) Error " & _
                    " from ms_tools_InHouseData  where CalibrationCode in (" & _
                    " select top 1 Calibration_Code from ms_tools_calibration" & _
                    " where Calibration_Code < @CalibrationCode" & _
                    " and instrument_number in (" & _
                    " select instrument_number from ms_tools_calibration" & _
                    " where Calibration_Code = @CalibrationCode )" & _
                    " order by Calibration_Code desc )" & _
                    " order by SlNo"
                da.Fill(ds)
                InHouseCalibratedPreData = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function InHouseCalibratedData(ByVal CalibrationCode As Integer) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@CalibrationCode", SqlDbType.Int, 4).Value = CalibrationCode
                da.SelectCommand.CommandText = "select SlNo , convert(varchar,convert(decimal(18,3),SizeOfValue)) SizeOfValue , " & _
                    " convert(varchar,convert(decimal(18,3),Reading)) Reading , convert(varchar,convert(decimal(18,3),Error)) Error  " & _
                    " , InHouseID from ms_tools_InHouseData  where CalibrationCode = @CalibrationCode "
                da.Fill(ds)
                InHouseCalibratedData = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function CalibrationCode(ByVal Type As Date, ByVal instrument_number As String) As Integer
            Dim cmd As System.Data.SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@Type", SqlDbType.SmallDateTime, 4).Value = Type
            cmd.Parameters.Add("@instrument_number", SqlDbType.VarChar, 50).Value = instrument_number
            cmd.Parameters.Add("@calibration_code", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            cmd.CommandText = "select @calibration_code =  calibration_code FROM ms_tools_calibration " & _
                " WHERE calibration_date = @Type and instrument_number = @instrument_number "
            Try
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.ExecuteScalar()
                CalibrationCode = IIf(IsDBNull(cmd.Parameters("@calibration_code").Value), 0, cmd.Parameters("@calibration_code").Value)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
            End Try
        End Function
        Public Shared Function CalibratedInstruments(ByVal Type As Date, ByVal Shop As String) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@Type", SqlDbType.SmallDateTime, 4).Value = Type
                da.SelectCommand.Parameters.Add("@Shop", SqlDbType.VarChar, 50).Value = Shop
                da.SelectCommand.CommandText = "SELECT ltrim(rtrim(history_card_number))  history_card_number , " & _
                    " ltrim(rtrim(history_card_number)) + ' - - ' +  ltrim(rtrim(type_ins)) InstrumentType " & _
                    " FROM ms_tools_master M inner join ms_tools_group b " & _
                    " on b.group_name = M.group_name inner join ms_tools_calibration c" & _
                    " on M.history_card_number = c.instrument_number " & _
                    " WHERE M.shop_code = @Shop  and calibration_date = @Type "
                da.Fill(ds)
                CalibratedInstruments = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function CalibratedShops(ByVal Type As Date) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@Type", SqlDbType.SmallDateTime, 4).Value = Type
                da.SelectCommand.CommandText = "SELECT distinct ltrim(rtrim(shop_code))  ShopCode , ShopName" & _
                    " FROM ms_tools_master M inner join ms_tools_Shops b on ShopCode = Shop_Code " & _
                    " WHERE last_cal_date = @Type "
                da.Fill(ds)
                CalibratedShops = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function GetTopCalibrationDate() As Date
            Dim cmd As System.Data.SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@last_cal_date", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output
            cmd.CommandText = "select @last_cal_date =  max(last_cal_date)  from ms_tools_master"
            Try
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.ExecuteScalar()
                GetTopCalibrationDate = IIf(IsDBNull(cmd.Parameters("@last_cal_date").Value), Now.Date, cmd.Parameters("@last_cal_date").Value)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
            End Try
        End Function
        Public Shared Function GetGroupDetails(ByVal GroupName As String) As DataSet
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.Parameters.Add("@GroupName", SqlDbType.VarChar, 50).Value = GroupName
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = "select Range , unit_of_measure Unit , accuracy_criteria Accuracy ," & _
                " description Frequency , calibration_link Link , process_tolerance Tolerance , " & _
                " work_instruction_number WorkInstruction , plus_error PlusErr , minus_error MinusErr , " & _
                " calibration_prodedure CalibrationProcedure ,  type_ins InstrumentType " & _
                " from ms_tools_group  a inner join " & _
                " ( select description , code from code where application = 'MS' and code_type = 'FQ' ) b on code = calibration_frequency " & _
                " where group_name = @GroupName ; " & _
                " select shop_code Shop , rtrim(history_card_number) InstrumentNo , " & _
                " rtrim(make) Make ,  rtrim(model) Model , rtrim(standard) Standard , " & _
                " convert(varchar(10),introduced_date,103) IntroducedDt , convert(varchar(10),last_iss_date,103) LastIssDt , " & _
                " convert(varchar(10),last_cal_date,103) LastCaliDt , convert(varchar(10),last_rec_date,103) LastRecDt , " & _
                " convert(varchar(10),calibration_due_date,103) DueDt , 'Active' Status " & _
                " from ms_tools_master where group_name = @GroupName " & _
                " union " & _
                " select shop_code Shop , rtrim(history_card_number) InstrumentNo , " & _
                " rtrim(make) Make ,  rtrim(model) Model , rtrim(standard) Standard , " & _
                " convert(varchar(10),introduced_date,103) IntroducedDt , convert(varchar(10),last_iss_date,103) LastIssDt , " & _
                " convert(varchar(10),last_cal_date,103) LastCaliDt , convert(varchar(10),last_rec_date,103) LastRecDt , " & _
                " convert(varchar(10),calibration_due_date,103) DueDt , 'Deleted' Status " & _
                " from ms_tools_master_deleted where group_name = @GroupName " & _
                " order by InstrumentNo desc "
            Try
                da.Fill(ds)
                GetGroupDetails = ds.Copy
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function ToolRoomQry(ByVal FromDt As Date, ByVal ToDt As Date, ByVal Type As Integer) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.Parameters.Add("@FromDt", SqlDbType.SmallDateTime, 4).Value = FromDt '
            da.SelectCommand.Parameters.Add("@ToDt", SqlDbType.SmallDateTime, 4).Value = ToDt
            da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = Type
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = "ms_sp_ToolRoomQry"
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            Try
                da.Fill(ds)
                ToolRoomQry = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function GroupDetails(ByVal GroupName As String) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.Parameters.Add("@GroupName", SqlDbType.VarChar, 50).Value = GroupName
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = "select range , unit_of_measure , accuracy_criteria , " & _
                " calibration_frequency , calibration_link , process_tolerance , work_instruction_number , " & _
                " plus_error , minus_error , calibration_prodedure , type_ins from ms_tools_group " & _
                " where group_name = @GroupName "

            Try
                da.Fill(ds)
                GroupDetails = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function ToolsForFQChange() As DataSet
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "select distinct rtrim(a.instrument_number) InstrumentNumber , " & _
                    " ltrim(rtrim(a.instrument_number)) + ' - - ' +  ltrim(rtrim(f.type_ins)) InstrumentType " & _
                    " from ms_tools_issue a inner join ms_tools_master b" & _
                    " on a.instrument_number = history_card_number " & _
                    " inner join ms_tools_receipt c on a.instrument_number = c.instrument_number" & _
                    " and a.receipt_code = c.receipt_code " & _
                    " inner join ms_tools_Shops e on ShopCode = c.Shop_Code " & _
                    " inner join ms_tools_group f on f.group_name = b.group_name " & _
                    " order by InstrumentNumber ; select Frequency , FrequencyCode from ms_tools_Frequency " & _
                    " order by FrequencyCode "
                da.Fill(ds)
                ToolsForFQChange = ds.Copy
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function InstrumentsDetails(ByVal shop_code As String, ByVal InstrumentNo As String) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@shop_code", SqlDbType.VarChar, 10).Value = shop_code
                da.SelectCommand.Parameters.Add("@InstrumentNo", SqlDbType.VarChar, 50).Value = InstrumentNo
                da.SelectCommand.CommandText = "select Frequency , " & _
                    " convert(varchar(10),last_rec_date,103) LastRectDt , " & _
                    " convert(varchar(10),last_cal_date,103) LastCaliDt  , " & _
                    " convert(varchar(10),last_iss_date,103) LastIssDt  , " & _
                    " convert(varchar(10),calibration_due_date,103) DueDate , " & _
                    " c.Range , rtrim(c.accuracy_criteria) Criteria  , convert(decimal(9,5),a.plus_error) PlusErr , " & _
                    " convert(decimal(9,5),a.minus_error) MinusErr , c.calibration_prodedure CalibrationProcedure " & _
                    " FROM ms_tools_master a inner join ms_tools_Frequency b" & _
                    " on calibration_frequency = FrequencyCode inner join ms_tools_group c " & _
                    " on c.group_name = a.group_name" & _
                    " where history_card_number = @InstrumentNo and shop_code = @shop_code "
                da.Fill(ds)
                InstrumentsDetails = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function ToolsListing(ByVal Type As String, Optional ByVal shop_code As String = "") As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@Type", SqlDbType.VarChar, 10).Value = Type
                da.SelectCommand.Parameters.Add("@Shop", SqlDbType.VarChar, 10).Value = shop_code
                da.SelectCommand.CommandText = "ms_sp_ToolsListing"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.Fill(ds)
                ToolsListing = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function InterShopJobsAtTR(ByVal FrDate As Date, ByVal ToDate As Date, ByVal Shop As Integer) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@FrDate", SqlDbType.SmallDateTime, 4).Value = FrDate
                da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.SmallDateTime, 4).Value = ToDate
                da.SelectCommand.Parameters.Add("@Shop", SqlDbType.Int, 4).Value = Shop
                If Shop = 0 Then
                    da.SelectCommand.CommandText = "select WONo , WODate , ReceivedDate RecdDt , " & _
                        " ShopName Shop , WODesc , WOQty Qty , AttendedBy , HourTaken Hrs ," & _
                        " Status, HandedOverTo GivenTo , Remarks " & _
                        " from ms_vw_JobsDoneAtTR " & _
                        " where WorkOrderDate between @FrDate and @ToDate " & _
                        " order by WorkOrderDate , ShopName "
                Else
                    da.SelectCommand.CommandText = "select WONo , WODate , ReceivedDate RecdDt , " & _
                        " ShopName Shop , WODesc , WOQty Qty , AttendedBy , HourTaken Hrs ," & _
                        " Status, HandedOverTo GivenTo , Remarks" & _
                        " from ms_vw_JobsDoneAtTR " & _
                        " where Shop = @Shop and " & _
                        " WorkOrderDate between @FrDate and @ToDate " & _
                        " order by WorkOrderDate , ShopName "
                End If
                da.Fill(ds)
                InterShopJobsAtTR = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function JobsDoneAtTR(ByVal ReceivedDate As Date) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@ReceivedDate", SqlDbType.SmallDateTime, 4).Value = ReceivedDate
                da.SelectCommand.CommandText = "select convert(varchar(10),ReceivedDate,103) RecdDt ," & _
                        " WONo , convert(varchar(10),WODate,103) WODate , ShopName , " & _
                        " WODesc , WOQty, AttendedBy, HourTaken, Status, HandedOverTo, Remarks" & _
                        " from ms_JobsDoneAtTR a inner join ms_ShopListForTRJobs b on a.Shop = b.Shop" & _
                        " where ReceivedDate = @ReceivedDate order by ShopName"
                da.Fill(ds)
                JobsDoneAtTR = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function CheckWO(ByVal WONo As String, ByVal Shop As Int16) As Boolean
            Dim cmd As System.Data.SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@Cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            cmd.CommandText = "select @Cnt = count(*) from ms_JobsDoneAtTR a " & _
                    " inner join ms_ShopListForTRJobs b " & _
                    " on a.Shop = b.Shop " & _
                    " where WONo = @WONo and a.Shop = @Shop "
            Try
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.Parameters.Add("@WONo", SqlDbType.VarChar, 50).Value = WONo.Trim
                cmd.Parameters.Add("@Shop", SqlDbType.Int, 4).Value = Shop
                cmd.ExecuteScalar()
                CheckWO = IIf(IsDBNull(cmd.Parameters("@Cnt").Value), 0, cmd.Parameters("@Cnt").Value)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
            End Try
        End Function
        Public Shared Function ShopListForTRJobs() As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "select Shop , ShopName from ms_ShopListForTRJobs "
                da.Fill(ds)
                ShopListForTRJobs = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function ToolHistory(ByVal instrument_number As String) As DataSet
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@instrument_number", SqlDbType.VarChar, 13).Value = instrument_number
                da.SelectCommand.CommandText = "ms_sp_ToolHistory"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.Fill(ds)
                ToolHistory = ds.Copy
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function ToolHistoryDeleted(ByVal instrument_number As String) As DataSet
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@instrument_number", SqlDbType.VarChar, 13).Value = instrument_number
                da.SelectCommand.CommandText = "ms_sp_ToolHistoryDeleted"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.Fill(ds)
                ToolHistoryDeleted = ds.Copy
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function GetHistoryCards() As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = "select distinct rtrim(history_card_number) history_card_number from ms_tools_master"
            Try
                da.Fill(ds)
                GetHistoryCards = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function GetHistoryCardsDeleted() As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = "select distinct rtrim(history_card_number) history_card_number from ms_tools_master_deleted"
            Try
                da.Fill(ds)
                GetHistoryCardsDeleted = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function GetDeletedCardsDetails(ByVal InstrumentNumber As String) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = "select *  from ms_tools_DeletedDetails where InstrumentNumber = @InstrumentNumber "
            da.SelectCommand.Parameters.Add("@InstrumentNumber", SqlDbType.VarChar, 50).Value = InstrumentNumber.Trim
            Try
                da.Fill(ds)
                GetDeletedCardsDetails = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function GetDeletedCardsDetail() As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = "select distinct rtrim(history_card_number) history_card_number from ms_tools_master " & _
                " order by history_card_number "
            Try
                da.Fill(ds)
                GetDeletedCardsDetail = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function GetToolsIssueDetails(ByVal IssueCode As Long) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.Parameters.Add("@IssueCode", SqlDbType.BigInt, 8)
            da.SelectCommand.Parameters("@IssueCode").Direction = ParameterDirection.Input
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select issued_date , issued_to , issued_by  from ms_tools_issue where issue_code = @IssueCode "
            Try
                da.SelectCommand.Parameters("@IssueCode").Value = IssueCode
                da.Fill(ds)
                GetToolsIssueDetails = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function GetToolsIssued(ByVal issued_date As Date) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.Parameters.Add("@issued_date", SqlDbType.SmallDateTime, 4).Value = issued_date
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select row_number() over ( order by instrument_number ) Sl , " & _
                " instrument_number InstrumentNo , shop_code Shop , issued_to IssuedTo , " & _
                " issued_by IssuedBy , issue_code IssId , receipt_code ReiptId , " & _
                " wap.dbo.ms_fn_InstrumentNoIssueSts(instrument_number , shop_code , receipt_code ) Sts " & _
                " FROM ms_tools_issue where issued_date = @issued_date order by instrument_number "
            Try
                da.Fill(ds)
                GetToolsIssued = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function GetToolsCalibrated(ByVal calibration_date As Date) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.Parameters.Add("@calibration_date", SqlDbType.SmallDateTime, 4).Value = calibration_date
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select row_number() over ( order by a.instrument_number ) Sl , " & _
                " rtrim(a.instrument_number) InstrumentNo , rtrim(c.shop_code) Shop , " & _
                " rtrim(standrad_reading) StdReads , a.plus_error PlusErr , a.minus_error MinusErr , " & _
                " rtrim(a.accuracy_calibrated) AccCali  , " & _
                " ambient_temp AmbTemp , rtrim(calibrating_person) CaliBy , rtrim(verified_by) VerifiedBy ,  " & _
                " rtrim(a.Remarks) Remarks , calibration_code ClaiCode , d.receipt_code RecptCode " & _
                " from ms_tools_calibration a inner join ms_tools_receipt b" & _
                " on a.receipt_code = b.receipt_code inner join ms_tools_master c" & _
                " on a.instrument_number = history_card_number" & _
                " left outer join ms_tools_issue d on a.instrument_number = d.instrument_number " & _
                " and b.receipt_code = d.receipt_code" & _
                " where a.calibration_date = @calibration_date " & _
                " order by a.calibration_date desc "
            Try
                da.Fill(ds)
                GetToolsCalibrated = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function GetIssueInstrumentNumber(ByVal Mode As String, ByVal ShopCode As String) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.Parameters.Add("@ShopCode", SqlDbType.VarChar, 50)
            da.SelectCommand.Parameters("@ShopCode").Direction = ParameterDirection.Input
            Dim ds As New DataSet()
            If Mode.Equals("add") Then
                da.SelectCommand.CommandText = " SELECT history_card_number , history_card_number FROM ms_tools_master as M WHERE left(shop_code," & ShopCode.Trim.Length & ") = @ShopCode and  ((SELECT MAX(calibration_date) FROM ms_tools_calibration WHERE instrument_number = M.history_card_number) >= (SELECT MAX(receipt_date) FROM ms_tools_receipt  WHERE instrument_number = M.history_card_number)) and ((SELECT MAX(receipt_date) FROM ms_tools_receipt WHERE  instrument_number = M.history_card_number) >=  (SELECT isnull(MAX(issued_date),'1900-01-01') FROM ms_tools_issue WHERE instrument_number = M.history_card_number)) ORDER BY     history_card_number  "
            Else
                da.SelectCommand.CommandText = " select instrument_number , issue_code  FROM ms_tools_issue  as TC WHERE shop_code = @ShopCode and issue_code = (SELECT MAX(issue_code) FROM ms_tools_issue  " & _
                         " WHERE instrument_number = TC.instrument_number) ORDER BY instrument_number "
            End If
            Try
                da.SelectCommand.Parameters("@ShopCode").Value = ShopCode.Trim
                da.Fill(ds)
                GetIssueInstrumentNumber = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function GetInstrumentCalibrationDate(ByVal InstrumentNumber As String, ByVal cal_date As Date, Optional ByVal Change As String = "") As Date
            Dim CalibrationDate As Date
            Dim tool_frequency As String
            Dim ds As New DataSet()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.Parameters.Add("@InstrumentNumber", SqlDbType.VarChar, 50)
            da.SelectCommand.Parameters("@InstrumentNumber").Direction = ParameterDirection.Input
            da.SelectCommand.CommandText = " SELECT TG.calibration_frequency FROM ms_tools_group TG inner join ms_tools_master TM " & _
                " on TM.group_name = TG.group_name WHERE TM.history_card_number = @InstrumentNumber "
            Try
                da.SelectCommand.Parameters("@InstrumentNumber").Value = InstrumentNumber.Trim
                da.Fill(ds)
                If Change.Trim.Length = 0 Then
                    tool_frequency = Trim(IIf(IsDBNull(ds.Tables(0).Rows(0)(0)), "", ds.Tables(0).Rows(0)(0)))
                Else
                    tool_frequency = Change.Trim
                End If
                Select Case tool_frequency
                    Case Is = "01"
                        cal_date = DateAdd(DateInterval.Year, 1, cal_date)
                    Case Is = "02"
                        cal_date = DateAdd(DateInterval.Month, 6, cal_date)
                    Case Is = "03"
                        cal_date = DateAdd(DateInterval.Month, 3, cal_date)
                    Case Is = "04"
                        cal_date = DateAdd(DateInterval.Month, 3, cal_date)
                    Case Is = "06"
                        cal_date = DateAdd(DateInterval.Month, 2, cal_date)
                    Case Is = "12"
                        cal_date = DateAdd(DateInterval.Month, 1, cal_date)
                    Case Is = "26"
                        cal_date = DateAdd(DateInterval.Day, 14, cal_date)
                    Case Is = "52"
                        cal_date = DateAdd(DateInterval.Day, 7, cal_date)
                    Case Is = "62"
                        cal_date = DateAdd(DateInterval.Year, 2, cal_date)
                    Case Is = "63"
                        cal_date = DateAdd(DateInterval.Year, 3, cal_date)
                    Case Is = "66"
                        cal_date = DateAdd(DateInterval.Year, 6, cal_date)
                    Case Is = "99"
                        cal_date = DateAdd(DateInterval.Day, 1, cal_date)
                    Case Is = "Y2"
                        cal_date = DateAdd(DateInterval.Year, 2, cal_date)
                    Case Is = "Y3"
                        cal_date = DateAdd(DateInterval.Year, 3, cal_date)
                    Case Is = "Y5"
                        cal_date = DateAdd(DateInterval.Year, 5, cal_date)
                    Case Is = "Y10"
                        cal_date = DateAdd(DateInterval.Year, 10, cal_date)
                End Select
                CalibrationDate = cal_date
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
            Return CalibrationDate
        End Function
        Public Shared Function GetToolsCalibrationDetails(ByVal CalibrarionCode As Long) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.Parameters.Add("@CalibrarionCode", SqlDbType.BigInt, 8)
            da.SelectCommand.Parameters("@CalibrarionCode").Direction = ParameterDirection.Input

            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select calibration_date , accuracy_calibrated , calibrating_person , verified_by , remarks , ambient_temp , " & _
                            " plus_error , minus_error , standrad_reading  from ms_tools_calibration where calibration_code = @CalibrarionCode "
            Try
                da.SelectCommand.Parameters("@CalibrarionCode").Value = CalibrarionCode
                da.Fill(ds)
                GetToolsCalibrationDetails = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function GetCalibrationInstrumentNumber(ByVal Mode As String, ByVal ShopCode As String) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.Parameters.Add("@ShopCode", SqlDbType.VarChar, 50)
            da.SelectCommand.Parameters("@ShopCode").Direction = ParameterDirection.Input

            Dim ds As New DataSet()
            If Mode.Equals("add") Then
                da.SelectCommand.CommandText = " SELECT history_card_number , history_card_number FROM ms_tools_master as M WHERE shop_code = @ShopCode and " & _
                        " ((SELECT isnull(MAX(receipt_date),'1900-01-01') FROM ms_tools_receipt WHERE instrument_number = M.history_card_number) > " & _
                        " (SELECT isnull(MAX(issued_date),'1900-01-01') FROM ms_tools_issue WHERE  instrument_number = M.history_card_number)) and " & _
                        " ((SELECT isnull(MAX(calibration_date),'1900-01-01') FROM ms_tools_calibration WHERE instrument_number = M.history_card_number) < " & _
                        " (SELECT isnull(MAX(receipt_date),'1900-01-01') FROM ms_tools_receipt WHERE instrument_number = M.history_card_number)) ORDER BY     history_card_number  "
            Else
                da.SelectCommand.CommandText = " select instrument_number , calibration_code FROM ms_tools_calibration as TC " & _
                    " WHERE shop_code = @ShopCode and calibration_code = (SELECT MAX(calibration_code) FROM ms_tools_calibration " & _
                    " WHERE instrument_number = TC.instrument_number) ORDER BY instrument_number "
            End If

            Try
                da.SelectCommand.Parameters("@ShopCode").Value = ShopCode.Trim
                da.Fill(ds)
                GetCalibrationInstrumentNumber = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function GetInstrumentNumberDetails(ByVal InstrumentNumber As String, Optional ByVal shop_code As String = "") As DataSet
            Dim ds As New DataSet()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.Parameters.Add("@InstrumentNumber", SqlDbType.VarChar, 50)
            da.SelectCommand.Parameters("@InstrumentNumber").Direction = ParameterDirection.Input
            da.SelectCommand.CommandText = " SELECT isnull(MAX(receipt_date),'1/1/1900') receipt_date FROM ms_tools_receipt WHERE instrument_number = @InstrumentNumber ; " & _
                    " SELECT isnull(MAX(issued_date),'1/1/1900') issued_date FROM ms_tools_issue WHERE instrument_number = @InstrumentNumber ;  " & _
                    " SELECT isnull(MAX(calibration_date),'1/1/1900') calibration_date FROM ms_tools_calibration WHERE instrument_number =  @InstrumentNumber ; " & _
                    " SELECT TOP 1 isnull(code + ' : ' + description,'') Shop FROM code WHERE code_type = 'LC' and application = 'MS' and code IN (SELECT shop_code FROM ms_tools_master WHERE history_card_number = @InstrumentNumber ) ; " & _
                    " SELECT MAX(receipt_code) receipt_code FROM ms_tools_receipt WHERE instrument_number = @InstrumentNumber ; " & _
                    " SELECT isnull(MAX(receipt_date),'1/1/1900') FROM ms_tools_receipt WHERE instrument_number = @InstrumentNumber and receipt_date < ( SELECT isnull(MAX(receipt_date),'1/1/1900') receipt_date FROM ms_tools_receipt WHERE instrument_number = @InstrumentNumber )  ; " & _
                    " select MAX(calibration_code) calibration_code from ms_tools_calibration where shop_code = '" & shop_code.Trim & "' and instrument_number = @InstrumentNumber ; " & _
                    " select isnull(max(issue_code),'1') from ms_tools_issue where instrument_number = @InstrumentNumber ; "
            Try
                da.SelectCommand.Parameters("@InstrumentNumber").Value = InstrumentNumber.Trim
                da.Fill(ds)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
            End Try
            Return ds
        End Function
        Public Shared Function GetToolsReceiptDetails(ByVal ReceiptCode As Long) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.Parameters.Add("@ReceiptCode", SqlDbType.BigInt, 8)
            da.SelectCommand.Parameters("@ReceiptCode").Direction = ParameterDirection.Input

            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select receipt_date , rec_chd_by , plus_error , minus_error , accuracy_received , accuracy_calibrated , calibration_date , remarks , discripency " & _
                    " from ms_tools_receipt where receipt_code = @ReceiptCode "
            Try
                da.SelectCommand.Parameters("@ReceiptCode").Value = ReceiptCode

                da.Fill(ds)
                GetToolsReceiptDetails = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function GetToolsReceipt(ByVal ReceiptDate As Date) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.Parameters.Add("@ReceiptDate", SqlDbType.SmallDateTime, 4).Value = ReceiptDate
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select row_number() over ( order by instrument_number ) Sl , " & _
                    " instrument_number InstrumentNo , shop_code Shop , recived_by RecdBy ,  " & _
                    " plus_error PlusErr , minus_error MinusErr , accuracy_received AccRecd , Discripency , Remarks , " & _
                    " convert(varchar(10),calibration_date,103) CalibratedDt  , receipt_code RecptID " & _
                    " from ms_tools_receipt where receipt_date = @ReceiptDate  order by instrument_number "
            Try
                da.Fill(ds)
                GetToolsReceipt = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function GetReceiptInstrumentNumber(ByVal Mode As String, ByVal ShopCode As String) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.Parameters.Add("@ShopCode", SqlDbType.VarChar, 50)
            da.SelectCommand.Parameters("@ShopCode").Direction = ParameterDirection.Input

            Dim ds As New DataSet()
            If Mode.Equals("add") Then
                da.SelectCommand.CommandText = " SELECT ltrim(rtrim(history_card_number))  history_card_number , ltrim(rtrim(history_card_number))  history_card_number FROM ms_tools_master as M " & _
                        " WHERE (shop_code = @ShopCode ) and " & _
                        " ((history_card_number NOT IN (SELECT instrument_number FROM ms_tools_receipt)) " & _
                        " OR ( NOT ((SELECT MAX(receipt_date) FROM ms_tools_receipt WHERE instrument_number = M.history_card_number) > " & _
                        " isnull((SELECT MAX(issued_date) FROM ms_tools_issue WHERE  instrument_number = M.history_card_number),getdate())))) ORDER BY     history_card_number  "
            Else
                da.SelectCommand.CommandText = " select instrument_number , receipt_code FROM ms_tools_receipt as TR WHERE " & _
                        " shop_code = @ShopCode and status = 'n' and  " & _
                        " receipt_code = (SELECT MAX(receipt_code) FROM ms_tools_receipt WHERE instrument_number = TR.instrument_number) ORDER BY instrument_number"
            End If

            Try
                da.SelectCommand.Parameters("@ShopCode").Value = ShopCode.Trim
                da.Fill(ds)
                GetReceiptInstrumentNumber = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function GetIssueFRQs(ByVal instrument_number As String) As DataSet
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@instrument_number", SqlDbType.VarChar, 50).Value = instrument_number.Trim
            da.SelectCommand.CommandText = " select Frequency , FrequencyCode from ms_tools_Frequency ; " & _
                " select Calibration_Frequency from ms_tools_master where history_card_number = @instrument_number ; " & _
                " select case when isnull(a.CalibrationFrequency,'') = '' then b.Calibration_Frequency else a.CalibrationFrequency end FRQ " & _
                " from (  select top 1 CalibrationFrequency , instrument_number" & _
                " from ms_tools_issue where instrument_number = @instrument_number" & _
                " order by issued_date desc ) a inner join ms_tools_master b" & _
                " on a.instrument_number = history_card_number"
            Try
                da.Fill(ds)
                GetIssueFRQs = ds.Copy
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function getTables() As DataSet
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " SELECT distinct group_name , group_name from ms_tools_group ; " & _
                " select rtrim(location) + '-' + ltrim(description) description , location code " & _
                " from ms_group_location where Purpose = 'ToolsHistory' and " & _
                " location in ( select distinct rtrim(shop_code) FROM ms_tools_issue )" & _
                " order by location ; " & _
                " select  ltrim(description)  description , code from code where code_type = 'LT' and application = 'MS'  ; " & _
                " select Frequency , FrequencyCode from ms_tools_Frequency ; " & _
                " select history_card_number , history_card_number from ms_tools_master ;"
            Try
                da.Fill(ds)
                getTables = ds.Copy
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetToolsGroupDetails(ByVal GroupName As String) As DataSet
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.Parameters.Add("@GroupName", SqlDbType.VarChar, 50)
            da.SelectCommand.Parameters("@GroupName").Direction = ParameterDirection.Input
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select group_name , maintenance_group , range , " & _
                    " unit_of_measure , accuracy_criteria , calibration_frequency ,  calibration_link , " & _
                    " process_tolerance , work_instruction_number, plus_error, minus_error, calibration_prodedure, " & _
                    " type_ins , change_date , user_id  from ms_tools_group where group_name =  @GroupName ; " & _
                    " select history_card_number HistoryCardNo , " & _
                    " shop_code Shop , instrument_number InstrumentNo , Make , Model , Standard" & _
                    " from ms_tools_master where group_name =  @GroupName order by instrument_number desc"
            Try
                da.SelectCommand.Parameters("@GroupName").Value = GroupName.Trim
                da.Fill(ds)
                GetToolsGroupDetails = ds.Copy
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function GetToolsHistoryCardDetails(ByVal HistoryCardNumber As String) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.Parameters.Add("@HistoryCardNumber", SqlDbType.VarChar, 50)
            da.SelectCommand.Parameters("@HistoryCardNumber").Direction = ParameterDirection.Input

            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select history_card_number , shop_code , maintenance_group , instrument_number , make , model , standard , tool_code , " & _
                    " group_name , range , unit_of_measure , accuracy_criteria , calibration_frequency , calibration_link , process_tolerance , " & _
                    " work_instruction_number , plus_error , minus_error , calibration_due_date , calibration_prodedure , introduced_date " & _
                    " from ms_tools_master where history_card_number =  @HistoryCardNumber "
            Try
                da.SelectCommand.Parameters("@HistoryCardNumber").Value = HistoryCardNumber.Trim

                da.Fill(ds)
                GetToolsHistoryCardDetails = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
    End Class
    Public Class Tool
        Private sGroupName, sRange, sUnitOfMeasure, sAccuracyCriteria, sCalibrationFrequency, sCalibrationLink As String
        Private sProcessTolerance, sWorkInstructionNumber, sCalibrationProdedure, sType, sTypeIns, sMessage As String
        Private decMinusError, decPlusError, decAmbientTemp As Decimal
        Private sPlus_error, sMinus_error As String
        Private dateCalibrationDueDate, dateReceiptDate, dateChangeDate, dateCalibrationDate, dateIssuedDate, dateIntroduced_date As Date
        Private sHistoryCardNumber, sMaintenanceGroup, sInstrumentNumber, sMake, sModel, sStandard, sShopCode As String
        Private sReceivedBy, sDiscripency, sAccuracyReceived, sUserID, sRemarks As String
        Private longReceiptCode, longCalibrationCode, longIssueCode As Long
        Private sCalibratingPerson, sAccuracyCalibrated, sVerifiedBy, sStandradReading As String
        Private sIssuedTo, sIssuedBy As String
        Private intSlNo, intInHouseID As Integer
        Private decSizeOfValue, decReading, decErrorValue As Decimal
#Region " Tool Property "
        Property Reading() As Decimal
            Get
                Return decReading
            End Get
            Set(ByVal Value As Decimal)
                decReading = Value
            End Set
        End Property
        Property ErrorValue() As Decimal
            Get
                Return decErrorValue
            End Get
            Set(ByVal Value As Decimal)
                decErrorValue = Value
            End Set
        End Property
        Property SizeOfValue() As Decimal
            Get
                Return decSizeOfValue
            End Get
            Set(ByVal Value As Decimal)
                decSizeOfValue = Value
            End Set
        End Property
        Property InHouseID() As Integer
            Get
                Return intInHouseID
            End Get
            Set(ByVal Value As Integer)
                intInHouseID = Value
            End Set
        End Property
        Property SlNo() As Integer
            Get
                Return intSlNo
            End Get
            Set(ByVal Value As Integer)
                intSlNo = Value
            End Set
        End Property
        Property Minus_error() As String
            Get
                Return sMinus_error
            End Get
            Set(ByVal Value As String)
                sMinus_error = Value
            End Set
        End Property
        Property Plus_error() As String
            Get
                Return sPlus_error
            End Get
            Set(ByVal Value As String)
                sPlus_error = Value
            End Set
        End Property
        Property Introduced_date() As Date
            Get
                Return dateIntroduced_date
            End Get
            Set(ByVal Value As Date)
                dateIntroduced_date = Value
            End Set
        End Property
        Property IssueCode() As Long
            Get
                Return longIssueCode
            End Get
            Set(ByVal Value As Long)
                longIssueCode = Value
            End Set
        End Property
        Property IssuedTo() As String
            Get
                Return sIssuedTo
            End Get
            Set(ByVal Value As String)
                sIssuedTo = Value
            End Set
        End Property
        Property IssuedBy() As String
            Get
                Return sIssuedBy
            End Get
            Set(ByVal Value As String)
                sIssuedBy = Value
            End Set
        End Property
        Property IssuedDate() As Date
            Get
                Return dateIssuedDate
            End Get
            Set(ByVal Value As Date)
                dateIssuedDate = Value
            End Set
        End Property
        Property CalibrationCode() As Long
            Get
                Return longCalibrationCode
            End Get
            Set(ByVal Value As Long)
                longCalibrationCode = Value
            End Set
        End Property
        Property StandradReading() As String
            Get
                Return sStandradReading
            End Get
            Set(ByVal Value As String)
                sStandradReading = Value
            End Set
        End Property
        Property AmbientTemp() As Decimal
            Get
                Return decAmbientTemp
            End Get
            Set(ByVal Value As Decimal)
                decAmbientTemp = Value
            End Set
        End Property
        Property VerifiedBy() As String
            Get
                Return sVerifiedBy
            End Get
            Set(ByVal Value As String)
                sVerifiedBy = Value
            End Set
        End Property
        Property AccuracyCalibrated() As String
            Get
                Return sAccuracyCalibrated
            End Get
            Set(ByVal Value As String)
                sAccuracyCalibrated = Value
            End Set
        End Property
        Property CalibratingPerson() As String
            Get
                Return sCalibratingPerson
            End Get
            Set(ByVal Value As String)
                sCalibratingPerson = Value
            End Set
        End Property
        Property CalibrationDate() As Date
            Get
                Return dateCalibrationDate
            End Get
            Set(ByVal Value As Date)
                dateCalibrationDate = Value
            End Set
        End Property
        Property ReceiptCode() As Long
            Get
                Return longReceiptCode
            End Get
            Set(ByVal Value As Long)
                longReceiptCode = Value
            End Set
        End Property
        Property Discripency() As String
            Get
                Return sDiscripency
            End Get
            Set(ByVal Value As String)
                sDiscripency = Value
            End Set
        End Property
        Property Remarks() As String
            Get
                Return sRemarks
            End Get
            Set(ByVal Value As String)
                sRemarks = Value
            End Set
        End Property
        Property ChangeDate() As Date
            Get
                Return dateChangeDate
            End Get
            Set(ByVal Value As Date)
                dateChangeDate = Value
            End Set
        End Property
        Property UserID() As String
            Get
                Return sUserID
            End Get
            Set(ByVal Value As String)
                sUserID = Value
            End Set
        End Property
        Property AccuracyReceived() As String
            Get
                Return sAccuracyReceived
            End Get
            Set(ByVal Value As String)
                sAccuracyReceived = Value
            End Set
        End Property
        Property ReceivedBy() As String
            Get
                Return sReceivedBy
            End Get
            Set(ByVal Value As String)
                sReceivedBy = Value
            End Set
        End Property
        Property ReceiptDate() As Date
            Get
                Return dateReceiptDate
            End Get
            Set(ByVal Value As Date)
                dateReceiptDate = Value
            End Set
        End Property
        Property Message() As String
            Get
                Return sMessage
            End Get
            Set(ByVal Value As String)
                sMessage = Value
            End Set
        End Property
        Property TypeIns() As String
            Get
                Return sTypeIns
            End Get
            Set(ByVal Value As String)
                sTypeIns = Value
            End Set
        End Property
        Property Type() As String
            Get
                Return sType
            End Get
            Set(ByVal Value As String)
                sType = Value
            End Set
        End Property
        Property ShopCode() As String
            Get
                Return sShopCode
            End Get
            Set(ByVal Value As String)
                sShopCode = Value
            End Set
        End Property
        Property Standard() As String
            Get
                Return sStandard
            End Get
            Set(ByVal Value As String)
                sStandard = Value
            End Set
        End Property
        Property Model() As String
            Get
                Return sModel
            End Get
            Set(ByVal Value As String)
                sModel = Value
            End Set
        End Property
        Property Make() As String
            Get
                Return sMake
            End Get
            Set(ByVal Value As String)
                sMake = Value
            End Set
        End Property
        Property InstrumentNumber() As String
            Get
                Return sInstrumentNumber
            End Get
            Set(ByVal Value As String)
                sInstrumentNumber = Value
            End Set
        End Property
        Property HistoryCardNumber() As String
            Get
                Return sHistoryCardNumber
            End Get
            Set(ByVal Value As String)
                sHistoryCardNumber = Value
            End Set
        End Property
        Property MaintenanceGroup() As String
            Get
                Return sMaintenanceGroup
            End Get
            Set(ByVal Value As String)
                sMaintenanceGroup = Value
            End Set
        End Property
        Property CalibrationProdedure() As String
            Get
                Return sCalibrationProdedure
            End Get
            Set(ByVal Value As String)
                sCalibrationProdedure = Value
            End Set
        End Property
        Property CalibrationDueDate() As Date
            Get
                Return dateCalibrationDueDate
            End Get
            Set(ByVal Value As Date)
                dateCalibrationDueDate = Value
            End Set
        End Property
        Property MinusError() As Decimal
            Get
                Return decMinusError
            End Get
            Set(ByVal Value As Decimal)
                decMinusError = Value
            End Set
        End Property
        Property PlusError() As Decimal
            Get
                Return decPlusError
            End Get
            Set(ByVal Value As Decimal)
                decPlusError = Value
            End Set
        End Property
        Property WorkInstructionNumber() As String
            Get
                Return sWorkInstructionNumber
            End Get
            Set(ByVal Value As String)
                sWorkInstructionNumber = Value
            End Set
        End Property
        Property ProcessTolerance() As String
            Get
                Return sProcessTolerance
            End Get
            Set(ByVal Value As String)
                sProcessTolerance = Value
            End Set
        End Property
        Property CalibrationLink() As String
            Get
                Return sCalibrationLink
            End Get
            Set(ByVal Value As String)
                sCalibrationLink = Value
            End Set
        End Property
        Property CalibrationFrequency() As String
            Get
                Return sCalibrationFrequency
            End Get
            Set(ByVal Value As String)
                sCalibrationFrequency = Value
            End Set
        End Property
        Property AccuracyCriteria() As String
            Get
                Return sAccuracyCriteria
            End Get
            Set(ByVal Value As String)
                sAccuracyCriteria = Value
            End Set
        End Property
        Property UnitOfMeasure() As String
            Get
                Return sUnitOfMeasure
            End Get
            Set(ByVal Value As String)
                sUnitOfMeasure = Value
            End Set
        End Property
        Property Range() As String
            Get
                Return sRange
            End Get
            Set(ByVal Value As String)
                sRange = Value
            End Set
        End Property
        Property GroupName() As String
            Get
                Return sGroupName
            End Get
            Set(ByVal Value As String)
                sGroupName = Value
            End Set
        End Property
#End Region
#Region " Tool Methods "
        Public Sub New(ByVal Type As String)
            iniVals()
        End Sub
        Private Sub iniVals()
            decSizeOfValue = 0
            decReading = 0
            decErrorValue = 0
            intSlNo = 0
            intInHouseID = 0
            sMinus_error = ""
            sPlus_error = ""
            dateIntroduced_date = "1900-01-01"
            sGroupName = ""
            sRange = ""
            sUnitOfMeasure = ""
            sAccuracyCriteria = ""
            sCalibrationFrequency = ""
            sCalibrationLink = ""
            sProcessTolerance = ""
            sWorkInstructionNumber = ""
            sCalibrationProdedure = ""
            sType = ""
            sTypeIns = ""
            sMessage = ""
            decMinusError = 0.0
            decPlusError = 0.0
            dateCalibrationDueDate = "1900-01-01"
            sHistoryCardNumber = ""
            sMaintenanceGroup = ""
            sInstrumentNumber = ""
            sMake = ""
            sModel = ""
            sStandard = ""
            sShopCode = ""
            dateReceiptDate = "1900-01-01"
            sReceivedBy = ""
            sAccuracyReceived = ""
            sUserID = ""
            dateChangeDate = "1900-01-01"
            sRemarks = ""
            sDiscripency = ""
            longReceiptCode = 0
            sCalibratingPerson = ""
            dateCalibrationDate = "1900-01-01"
            sAccuracyCalibrated = ""
            sVerifiedBy = ""
            decAmbientTemp = 0.0
            sStandradReading = ""
            longCalibrationCode = 0
            dateIssuedDate = "1900-01-01"
            sIssuedTo = ""
            sIssuedBy = ""
            longIssueCode = 0
        End Sub
        Public Shared Function CheckIssue(ByVal InstrumentNumber As String, ByVal issued_date As Date, ByVal Shop_code As String, ByVal Maintenance_group As String) As Boolean
            Dim Exist As Boolean
            Dim cmd As System.Data.SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@Cnt", SqlDbType.Int, 4)
            cmd.Parameters("@Cnt").Direction = ParameterDirection.Output
            cmd.CommandText = " select @Cnt = isnull(count(*),0) from ms_tools_issue where instrument_number = @InstrumentNumber and issued_date = @issued_date " & _
                        " and receipt_code = (select max(receipt_code) from ms_tools_receipt where instrument_number = @InstrumentNumber and shop_code = @Shop_code and maintenance_group = @Maintenance_group )"
            Try
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.Parameters.Add("@InstrumentNumber", SqlDbType.VarChar, 50).Value = InstrumentNumber.Trim
                cmd.Parameters.Add("@issued_date", SqlDbType.SmallDateTime, 4).Value = issued_date
                cmd.Parameters.Add("@Shop_code", SqlDbType.VarChar, 50).Value = Shop_code.Trim
                cmd.Parameters.Add("@Maintenance_group", SqlDbType.VarChar, 50).Value = Maintenance_group.Trim
                cmd.ExecuteScalar()
                Exist = IIf(IsDBNull(cmd.Parameters("@Cnt").Value), 0, cmd.Parameters("@Cnt").Value)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
            End Try
            Return Exist
        End Function
        Public Shared Function CheckHistoryCard(ByVal HistoryCardNumber As String) As Boolean
            Dim Exist As Boolean
            Dim cmd As System.Data.SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@HistoryCardNumber", SqlDbType.VarChar, 50)
            cmd.Parameters("@HistoryCardNumber").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@Cnt", SqlDbType.Int, 4)
            cmd.Parameters("@Cnt").Direction = ParameterDirection.Output
            cmd.CommandText = " select @Cnt = isnull(count(*),0) from ms_tools_master where history_card_number = @HistoryCardNumber "
            Try
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.Parameters("@HistoryCardNumber").Value = HistoryCardNumber.Trim
                cmd.ExecuteScalar()
                Exist = IIf(IsDBNull(cmd.Parameters("@Cnt").Value), 0, cmd.Parameters("@Cnt").Value)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
            End Try
            Return Exist
        End Function
        Public Function SaveTools(ByVal Type As String, Optional ByVal HistoryCardNumber As String = "", Optional ByVal MODE As String = "add") As Boolean
            Dim blnDone As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            'cmd.Parameters.Add("@Type", SqlDbType.VarChar, 1)
            'cmd.Parameters("@Type").Direction = ParameterDirection.Input
            Try
                cmd.Parameters.Add("@history_card_number", SqlDbType.VarChar, 50).Value = sHistoryCardNumber
                cmd.Parameters.Add("@maintenance_group", SqlDbType.VarChar, 50).Value = sMaintenanceGroup
                cmd.Parameters.Add("@instrument_number", SqlDbType.VarChar, 50).Value = sInstrumentNumber
                cmd.Parameters.Add("@make", SqlDbType.VarChar, 50).Value = sMake
                cmd.Parameters.Add("@model", SqlDbType.VarChar, 50).Value = sModel
                cmd.Parameters.Add("@standard", SqlDbType.VarChar, 50).Value = sStandard
                cmd.Parameters.Add("@shop_code", SqlDbType.VarChar, 50).Value = sShopCode
                cmd.Parameters.Add("@group_name", SqlDbType.VarChar, 50).Value = sGroupName
                cmd.Parameters.Add("@range", SqlDbType.VarChar, 50).Value = sRange
                cmd.Parameters.Add("@unit_of_measure", SqlDbType.VarChar, 50).Value = sUnitOfMeasure
                cmd.Parameters.Add("@accuracy_criteria", SqlDbType.VarChar, 50).Value = sAccuracyCriteria
                cmd.Parameters.Add("@calibration_frequency", SqlDbType.VarChar, 50).Value = sCalibrationFrequency
                cmd.Parameters.Add("@calibration_link", SqlDbType.VarChar, 50).Value = sCalibrationLink
                cmd.Parameters.Add("@process_tolerance", SqlDbType.VarChar, 50).Value = sProcessTolerance
                cmd.Parameters.Add("@work_instruction_number", SqlDbType.VarChar, 50).Value = sWorkInstructionNumber
                If Type = "G" Then
                    cmd.Parameters.Add("@plus_error", SqlDbType.VarChar, 50).Value = sPlus_error
                    cmd.Parameters.Add("@minus_error", SqlDbType.VarChar, 50).Value = sMinus_error
                Else
                    cmd.Parameters.Add("@plus_error", SqlDbType.Decimal, 10, 3).Value = decPlusError
                    cmd.Parameters.Add("@minus_error", SqlDbType.Decimal, 10, 3).Value = decMinusError
                End If
                cmd.Parameters.Add("@calibration_prodedure", SqlDbType.VarChar, 1000).Value = sCalibrationProdedure
                cmd.Parameters.Add("@type_ins", SqlDbType.VarChar, 50).Value = sTypeIns
                cmd.Parameters.Add("@introduced_date", SqlDbType.SmallDateTime, 4).Value = dateIntroduced_date
                blnDone = True
            Catch exp As Exception
                blnDone = False
            End Try
            If blnDone = True Then
                blnDone = False
            Else
                cmd.Dispose()
                Throw New Exception("Value assingement error !")
                Exit Function
            End If
            Try
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                Dim i As Integer
                If Type = "G" Then
                    i = sGroupName.Trim.Length
                Else
                    i = HistoryCardNumber.Trim.Length
                End If
                If MODE = "edit" Then
                    cmd.Parameters("@history_card_number").Direction = ParameterDirection.Input
                    ToolsEdit(Type, cmd)
                    blnDone = True
                ElseIf MODE = "add" Then
                    ToolsAdd(Type, cmd)
                    blnDone = True
                Else
                    ToolsDelete(Type, cmd)
                    blnDone = True
                End If
            Catch exp As Exception
                sMessage = exp.Message
                Throw New Exception(exp.Message)
            Finally
                If blnDone = True Then
                    cmd.Transaction.Commit()
                Else
                    cmd.Transaction.Rollback()
                End If
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
            End Try
            Return blnDone
        End Function
        Private Sub ToolsAdd(ByVal Type As String, ByRef CMD As SqlClient.SqlCommand)
            If Type = "G" Then
                CMD.CommandText = " insert into ms_tools_group ( group_name , range , unit_of_measure , accuracy_criteria , " & _
                                " calibration_frequency , calibration_link , process_tolerance , work_instruction_number , " & _
                                " plus_error , minus_error , maintenance_group , calibration_prodedure , type_ins ) " & _
                                " values ( @group_name , @range , @unit_of_measure , @accuracy_criteria , " & _
                                " @calibration_frequency , @calibration_link , @process_tolerance , @work_instruction_number , " & _
                                " @plus_error , @minus_error , @maintenance_group , @calibration_prodedure , @type_ins )"
            Else
                CMD.CommandText = " select count(*) from ms_tools_master_deleted where history_card_number = @history_card_number "
                If CMD.ExecuteScalar = 0 Then
                    CMD.CommandText = " insert into ms_tools_master ( history_card_number , maintenance_group , instrument_number , " & _
                                      " make , model , standard , shop_code , introduced_date , tool_code , " & _
                                      " group_name , range , unit_of_measure , accuracy_criteria , " & _
                                      " calibration_frequency , calibration_link , process_tolerance , work_instruction_number , " & _
                                      " plus_error , minus_error , calibration_prodedure ) " & _
                                      " values ( @history_card_number , @maintenance_group , @instrument_number , " & _
                                      " @make , @model , @standard , @shop_code , @introduced_date , 'I' , " & _
                                      " @group_name , @range , @unit_of_measure , @accuracy_criteria , " & _
                                      " @calibration_frequency , @calibration_link , @process_tolerance , @work_instruction_number , " & _
                                      " @plus_error , @minus_error , @calibration_prodedure ) "
                Else
                    Throw New Exception("This InstrumentNumber already exists in Deleted Tool Master ! Hence Dulplicate !")
                End If
            End If
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" tools master error")
            Catch exp As Exception
                Throw New Exception(" Insert into ms_tools_master error " & exp.Message)
            End Try
        End Sub
        Private Sub ToolsEdit(ByVal Type As String, ByRef CMD As SqlClient.SqlCommand)
            If Type = "G" Then
                CMD.CommandText = " update ms_tools_group set range = @range , unit_of_measure = @unit_of_measure , " & _
                                " accuracy_criteria = @accuracy_criteria , calibration_frequency = @calibration_frequency , " & _
                                " calibration_link = @calibration_link , process_tolerance = @process_tolerance , " & _
                                " work_instruction_number = @work_instruction_number , plus_error = @plus_error , minus_error = @minus_error , calibration_prodedure = @calibration_prodedure , type_ins = @type_ins " & _
                                " where group_name = @group_name "
            Else
                CMD.CommandText = "update ms_tools_master set instrument_number = @instrument_number , " & _
                                " make = @make , model = @model , standard = @standard , introduced_date = @introduced_date , " & _
                                " group_name = @group_name , range = @range , unit_of_measure = @unit_of_measure , accuracy_criteria = @accuracy_criteria , " & _
                                " calibration_frequency = @calibration_frequency , calibration_link = @calibration_link , process_tolerance = @process_tolerance , work_instruction_number = @work_instruction_number , " & _
                                " plus_error = @plus_error , minus_error = @minus_error , calibration_prodedure = @calibration_prodedure where history_card_number = @history_card_number " & _
                                " and shop_code = @shop_code and maintenance_group = @maintenance_group "
            End If

            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to update tools details ")
            Catch exp As Exception
                Throw New Exception(" update of tools details error :  " & exp.Message)
            End Try
        End Sub
        Private Sub ToolsDelete(ByVal Type As String, ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " insert into wap.dbo.ms_tools_master_deleted select * from wap.dbo.ms_tools_master where history_card_number = @history_card_number "
            Try
                If CMD.ExecuteNonQuery = 0 Then
                    Throw New Exception(" Unable to delete history_card_number details ")
                Else
                    CMD.CommandText = " insert into wap.dbo.ms_tools_DeletedDetails ( InstrumentNumber ) values ( @history_card_number ) "
                    If CMD.ExecuteNonQuery = 1 Then
                        CMD.CommandText = " delete from ms_tools_master where history_card_number = @history_card_number "
                        If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to delete history_card_number details ")
                    Else
                        Throw New Exception(" Unable to delete history_card_number details ")
                    End If
                End If
            Catch exp As Exception
                Throw New Exception(" delete of ms_tools_master error :  " & exp.Message)
            End Try
        End Sub
        Public Function SaveToolsReceipt(Optional ByVal HistoryCardNumber As String = "", Optional ByVal Delete As Boolean = False) As Boolean
            Dim blnDone As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Parameters.Add("@maintenance_group", SqlDbType.VarChar, 50).Value = sMaintenanceGroup
                cmd.Parameters.Add("@instrument_number", SqlDbType.VarChar, 50).Value = sInstrumentNumber.Trim
                cmd.Parameters.Add("@shop_code", SqlDbType.VarChar, 50).Value = sShopCode.Trim
                cmd.Parameters.Add("@receipt_date", SqlDbType.SmallDateTime, 4).Value = dateReceiptDate
                cmd.Parameters.Add("@recived_by", SqlDbType.VarChar, 50).Value = sReceivedBy
                cmd.Parameters.Add("@plus_error", SqlDbType.Decimal, 10, 3).Value = decPlusError
                cmd.Parameters.Add("@minus_error", SqlDbType.Decimal, 10, 3).Value = decMinusError
                cmd.Parameters.Add("@accuracy_received", SqlDbType.VarChar, 50).Value = sAccuracyReceived
                cmd.Parameters.Add("@user_id", SqlDbType.VarChar, 10).Value = sUserID
                cmd.Parameters.Add("@change_date", SqlDbType.SmallDateTime, 4).Value = dateChangeDate
                cmd.Parameters.Add("@remarks", SqlDbType.VarChar, 500).Value = sRemarks
                cmd.Parameters.Add("@Discripency", SqlDbType.VarChar, 10).Value = sDiscripency
                cmd.Parameters.Add("@receipt_code", SqlDbType.BigInt, 8).Value = longReceiptCode
                blnDone = True
            Catch exp As Exception
                blnDone = False
            End Try
            If blnDone = True Then
                blnDone = False
            Else
                cmd.Dispose()
                Throw New Exception("Value assingement error !")
                Exit Function
            End If


            Try
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction

                If HistoryCardNumber.Trim.Length > 0 Then
                    cmd.Parameters("@instrument_number").Direction = ParameterDirection.Input
                    If Delete = False Then
                        ReceiptEdit(Type, cmd)
                        blnDone = True
                    Else
                        ReceiptDelete(Type, cmd)
                        blnDone = True
                    End If
                Else
                    If Delete = False Then ReceiptAdd(cmd)
                    blnDone = True
                End If
            Catch exp As Exception
                sMessage = exp.Message
                Throw New Exception(exp.Message)
            Finally
                If blnDone = True Then
                    cmd.Transaction.Commit()
                Else
                    cmd.Transaction.Rollback()
                End If
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
            End Try
            Return blnDone
        End Function
        Private Sub ReceiptAdd(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " insert into ms_tools_receipt " & _
                    " ( maintenance_group , shop_code , instrument_number , receipt_date , recived_by , rec_chd_by , " & _
                    " plus_error , minus_error , accuracy_received , user_id , change_date , remarks , discripency  ) values " & _
                    " ( @maintenance_group , @shop_code , @instrument_number , @receipt_date , @recived_by ,  @recived_by , " & _
                    " @plus_error , @minus_error , @accuracy_received , @user_id , @change_date , @remarks , @Discripency  ) "
            Try
                If CMD.ExecuteNonQuery = 0 Then
                    Throw New Exception(" tools master error")
                Else
                    CMD.CommandText = "update ms_tools_master set last_rec_date = @receipt_date  , shop_code = @shop_code , " & _
                    " tool_code = 'R' where  history_card_number = @instrument_number "
                    If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" tools master error")
                End If
            Catch exp As Exception
                Throw New Exception(" Insert into ms_tools_master error " & exp.Message)
            End Try
        End Sub
        Private Sub ReceiptEdit(ByVal Type As String, ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " update ms_tools_receipt set shop_code = @shop_code , " & _
                " receipt_date = @receipt_date , recived_by = @recived_by , rec_chd_by = @recived_by , plus_error = @plus_error , minus_error = @minus_error , discripency = @Discripency , " & _
                " accuracy_received = @accuracy_received , user_id = @user_id , change_date = @change_date , remarks = @remarks where  receipt_code = @receipt_code "
            Try
                If CMD.ExecuteNonQuery = 0 Then
                    Throw New Exception(" Unable to update tools details ")
                Else
                    CMD.CommandText = " update ms_tools_master set last_rec_date = @receipt_date where shop_code = @shop_code and  history_card_number = @instrument_number "
                    If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" tools master error")
                End If
            Catch exp As Exception
                Throw New Exception(" update of tools details error :  " & exp.Message)
            End Try
        End Sub
        Private Sub ReceiptDelete(ByVal Type As String, ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " delete from ms_tools_receipt where receipt_code = @receipt_code "
            Try
                If CMD.ExecuteNonQuery = 0 Then
                    Throw New Exception(" Unable to delete tools details ")
                Else
                    CMD.CommandText = " update ms_tools_master set last_rec_date = null where shop_code = @shop_code and  history_card_number = @instrument_number "
                    If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" tools master error")
                End If
            Catch exp As Exception
                Throw New Exception(" delete of ms_tools_receipt error :  " & exp.Message)
            End Try
        End Sub
        Public Function SaveToolsCalibration(Optional ByVal HistoryCardNumber As String = "", Optional ByVal Delete As Boolean = False) As Boolean
            Dim blnDone As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Parameters.Add("@maintenance_group", SqlDbType.VarChar, 50).Value = sMaintenanceGroup
                cmd.Parameters.Add("@instrument_number", SqlDbType.VarChar, 50).Value = sInstrumentNumber
                cmd.Parameters.Add("@shop_code", SqlDbType.VarChar, 50).Value = sShopCode
                cmd.Parameters.Add("@calibration_date", SqlDbType.SmallDateTime, 4).Value = dateCalibrationDate
                cmd.Parameters.Add("@accuracy_calibrated", SqlDbType.VarChar, 50).Value = sAccuracyCalibrated
                cmd.Parameters.Add("@calibrating_person", SqlDbType.VarChar, 50).Value = sCalibratingPerson
                cmd.Parameters.Add("@verified_by", SqlDbType.VarChar, 50).Value = sVerifiedBy
                cmd.Parameters.Add("@remarks", SqlDbType.VarChar, 200).Value = sRemarks
                cmd.Parameters.Add("@ambient_temp", SqlDbType.Decimal, 10, 3).Value = decAmbientTemp
                cmd.Parameters.Add("@plus_error", SqlDbType.Decimal, 10, 3).Value = decPlusError
                cmd.Parameters.Add("@minus_error", SqlDbType.Decimal, 10, 3).Value = decMinusError
                cmd.Parameters.Add("@standrad_reading", SqlDbType.VarChar, 50).Value = sStandradReading
                cmd.Parameters.Add("@calibration_due_date", SqlDbType.SmallDateTime, 4).Value = ToolRoom.Tables.GetInstrumentCalibrationDate(sInstrumentNumber, dateCalibrationDate)
                cmd.Parameters.Add("@receipt_code", SqlDbType.BigInt, 8).Value = longReceiptCode
                cmd.Parameters.Add("@calibration_code", SqlDbType.BigInt, 8).Value = longCalibrationCode
                cmd.Parameters.Add("@cnt", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
                blnDone = True
            Catch exp As Exception
                blnDone = False
            End Try
            If blnDone = True Then
                blnDone = False
            Else
                cmd.Dispose()
                Throw New Exception("Value assingement error !")
                Exit Function
            End If


            Try
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction

                If HistoryCardNumber.Trim.Length > 0 Then
                    cmd.Parameters("@instrument_number").Direction = ParameterDirection.Input
                    If Delete = False Then
                        CalibrationEdit(Type, cmd)
                        blnDone = True
                    Else
                        CalibrationDelete(Type, cmd)
                        blnDone = True
                    End If
                Else
                    If Delete = False Then CalibrationAdd(cmd)
                    blnDone = True
                End If
            Catch exp As Exception
                sMessage = exp.Message
                Throw New Exception(exp.Message)
            Finally
                If blnDone = True Then
                    cmd.Transaction.Commit()
                Else
                    cmd.Transaction.Rollback()
                End If
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
            End Try
            Return blnDone
        End Function
        Private Sub CalibrationAdd(ByRef CMD As SqlClient.SqlCommand)

            CMD.CommandText = " select @cnt = calibration_code from ms_tools_calibration " & _
                    " where calibration_date = @calibration_date and receipt_code = @receipt_code and instrument_number = @instrument_number "
            CMD.ExecuteScalar()

            If IIf(IsDBNull(CMD.Parameters("@cnt").Value), 0, CMD.Parameters("@cnt").Value) = 0 Then
                CMD.CommandText = " insert into ms_tools_calibration ( maintenance_group , shop_code , instrument_number , " & _
                        " calibration_date , accuracy_calibrated , calibrating_person , verified_by , remarks , ambient_temp , " & _
                        " plus_error , minus_error , standrad_reading , receipt_code ) " & _
                        " values ( @maintenance_group , @shop_code , @instrument_number ,  @calibration_date , " & _
                        " @accuracy_calibrated , @calibrating_person , " & _
                        " @verified_by , @remarks , @ambient_temp , @plus_error , @minus_error , @standrad_reading , @receipt_code ) "
            Else
                CMD.Parameters("@cnt").Direction = ParameterDirection.Input
                CMD.CommandText = " update ms_tools_calibration set accuracy_calibrated = @accuracy_calibrated , " & _
                        " calibrating_person = @calibrating_person ,  verified_by = @verified_by , standrad_reading = @standrad_reading , " & _
                        " remarks = @remarks , ambient_temp = @ambient_temp , plus_error = @plus_error , minus_error = @minus_error  " & _
                        " where instrument_number = @instrument_number and receipt_code = @receipt_code and calibration_date = @calibration_date " & _
                        " and calibration_code = @cnt "
            End If

            Try
                If CMD.ExecuteNonQuery = 0 Then
                    Throw New Exception(" tools calibration error")
                Else
                    CMD.CommandText = " update ms_tools_master set calibration_due_date = @calibration_due_date , " & _
                        " last_cal_date = @calibration_date , tool_code = 'C' " & _
                        " where  shop_code = @shop_code and  history_card_number = @instrument_number "
                    If CMD.ExecuteNonQuery = 0 Then
                        Throw New Exception(" tools master error")
                    Else
                        CMD.CommandText = " update ms_tools_receipt set status = 'U' , accuracy_calibrated = @accuracy_calibrated , " & _
                            " calibration_date = @calibration_date where receipt_code = @receipt_code "
                        If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" tools receipt error")
                    End If
                End If
            Catch exp As Exception
                Throw New Exception(" Insert into ms_tools_calibration error " & exp.Message)
            End Try
        End Sub
        Private Sub CalibrationEdit(ByVal Type As String, ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " update ms_tools_calibration set calibration_date = @calibration_date , accuracy_calibrated = @accuracy_calibrated , " & _
                    " calibrating_person = @calibrating_person , receipt_code = @receipt_code , verified_by = @verified_by , " & _
                    " remarks = @remarks , ambient_temp = @ambient_temp , plus_error = @plus_error , minus_error = @minus_error , " & _
                    " standrad_reading = @standrad_reading where calibration_code = @calibration_code "
            Try
                If CMD.ExecuteNonQuery = 0 Then
                    Throw New Exception(" Unable to update Calbration details ")
                Else
                    CMD.CommandText = " update ms_tools_master set calibration_due_date = @calibration_due_date , last_cal_date = @calibration_date  where  shop_code = @shop_code and  history_card_number = @instrument_number "
                    If CMD.ExecuteNonQuery = 0 Then
                        Throw New Exception(" tools master error")
                    Else
                        CMD.CommandText = " update ms_tools_receipt set status = 'U' , accuracy_calibrated = @accuracy_calibrated , " & _
                                " calibration_date = @calibration_date  where receipt_code = @receipt_code "
                        If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" tools receipt error")
                    End If
                End If
            Catch exp As Exception
                Throw New Exception(" update of Calbration details error :  " & exp.Message)
            End Try
        End Sub
        Private Sub CalibrationDelete(ByVal Type As String, ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " delete from ms_tools_calibration where calibration_code = @calibration_code "
            Try
                If CMD.ExecuteNonQuery = 0 Then
                    Throw New Exception(" Unable to update Calbration details ")
                Else
                    CMD.CommandText = " update ms_tools_master set calibration_due_date = null , last_cal_date = null  where  shop_code = @shop_code and  history_card_number = @instrument_number "
                    If CMD.ExecuteNonQuery = 0 Then
                        Throw New Exception(" tools master error")
                    Else
                        CMD.CommandText = " update ms_tools_receipt set status = 'N' ,  " & _
                                " calibration_date = null where receipt_code = @receipt_code "
                        If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" tools receipt error")
                    End If
                End If
            Catch exp As Exception
                Throw New Exception(" delete of ms_tools_receipt error :  " & exp.Message)
            End Try
        End Sub
        Public Function SaveToolsIssue(Optional ByVal HistoryCardNumber As String = "", Optional ByVal Delete As Boolean = False, Optional ByVal Change As String = "") As Boolean
            Dim blnDone As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Parameters.Add("@instrument_number", SqlDbType.VarChar, 50).Value = sInstrumentNumber
                cmd.Parameters.Add("@shop_code", SqlDbType.VarChar, 50).Value = sShopCode
                cmd.Parameters.Add("@issued_date", SqlDbType.SmallDateTime, 4).Value = dateIssuedDate
                cmd.Parameters.Add("@issued_to", SqlDbType.VarChar, 50).Value = sIssuedTo
                cmd.Parameters.Add("@issued_by", SqlDbType.VarChar, 50).Value = sIssuedBy
                cmd.Parameters.Add("@receipt_code", SqlDbType.BigInt, 8).Value = longReceiptCode
                cmd.Parameters.Add("@maintenance_group", SqlDbType.VarChar, 50).Value = sMaintenanceGroup
                cmd.Parameters.Add("@user_id", SqlDbType.VarChar, 10).Value = sUserID
                cmd.Parameters.Add("@issue_code", SqlDbType.BigInt, 8).Value = longIssueCode
                If Change.Trim.Length > 0 Then
                    cmd.Parameters.Add("@CalibrationFrequency", SqlDbType.VarChar, 50).Value = Change.Trim
                Else
                    cmd.Parameters.Add("@CalibrationFrequency", SqlDbType.VarChar, 50).Value = sCalibrationFrequency.Trim
                End If
                cmd.Parameters.Add("@cnt", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
                blnDone = True
            Catch exp As Exception
                blnDone = False
            End Try
            If blnDone = True Then
                blnDone = False
            Else
                cmd.Dispose()
                Throw New Exception("Value assingement error !")
                Exit Function
            End If
            Try
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                If Change.Trim.Length > 0 Then
                    cmd.CommandText = " update ms_tools_master set  calibration_frequency = @CalibrationFrequency " & _
                        " where history_card_number = @instrument_number "
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = " update TG set TG.calibration_frequency = @CalibrationFrequency " & _
                        " FROM ms_tools_group TG inner join ms_tools_master TM " & _
                        " on TM.group_name = TG.group_name WHERE TM.history_card_number = @instrument_number "
                    cmd.ExecuteNonQuery()
                End If

                cmd.Parameters.Add("@calibration_due_date", SqlDbType.SmallDateTime, 4).Value = ToolRoom.Tables.GetInstrumentCalibrationDate(sInstrumentNumber, dateIssuedDate, Change)
                cmd.Parameters.Add("@CalibrationDueDate", SqlDbType.SmallDateTime, 4).Value = ToolRoom.Tables.GetInstrumentCalibrationDate(sInstrumentNumber, dateIssuedDate, Change)

                If HistoryCardNumber.Trim.Length > 0 Then
                    cmd.Parameters("@instrument_number").Direction = ParameterDirection.Input
                    If Delete = False Then
                        IssueEdit(Type, cmd)
                        blnDone = True
                    Else
                        IssueDelete(Type, cmd)
                        blnDone = True
                    End If
                Else
                    If Delete = False Then IssueAdd(cmd)
                    blnDone = True
                End If
            Catch exp As Exception
                sMessage = exp.Message
            Finally
                If blnDone = True Then
                    cmd.Transaction.Commit()
                Else
                    If Not sMessage.EndsWith("The transaction ended in the trigger. The batch has been aborted.") Then
                        cmd.Transaction.Rollback()
                    End If
                End If
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
            End Try
            Return blnDone
        End Function
        Private Sub IssueAdd(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " select @cnt = issue_code from ms_tools_issue where instrument_number = @instrument_number " & _
                    " and receipt_code = @receipt_code  and issued_date = @issued_date "
            CMD.ExecuteScalar()

            If IIf(IsDBNull(CMD.Parameters("@cnt").Value), 0, CMD.Parameters("@cnt").Value) = 0 Then
                CMD.CommandText = " insert into ms_tools_issue ( instrument_number , shop_code , issued_date , issued_to , issued_by , " & _
                    " receipt_code , maintenance_group , user_id , CalibrationFrequency , CalibrationDueDate ) values " & _
                    " ( @instrument_number , @shop_code , @issued_date , @issued_to , @issued_by , @receipt_code , " & _
                    " @maintenance_group , @user_id , @CalibrationFrequency , @calibration_due_date ) "
            Else
                CMD.Parameters("@cnt").Direction = ParameterDirection.Input
                CMD.CommandText = " update ms_tools_issue set shop_code = @shop_code , CalibrationDueDate = @CalibrationDueDate , " & _
                    " user_id = @user_id , issued_to = @issued_to , issued_by = @issued_by  " & _
                    " where instrument_number = @instrument_number and issued_date = @issued_date and issue_code = @cnt and receipt_code = @receipt_code "
            End If

            Try
                If CMD.ExecuteNonQuery = 0 Then
                    Throw New Exception(" tools issue error")
                Else
                    CMD.CommandText = " update ms_tools_master set  calibration_due_date = @calibration_due_date , " & _
                        " last_iss_date = @issued_date , shop_code = @shop_code  , tool_code = 'I'  " & _
                        " where history_card_number = @instrument_number "
                    If CMD.ExecuteNonQuery = 0 Then
                        Throw New Exception(" tools master error")
                    Else
                        CMD.CommandText = " update ms_tools_receipt set status = 'I' where receipt_code = @receipt_code and instrument_number = @instrument_number"
                        If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" tools receipt error")
                    End If
                End If
            Catch exp As Exception
                Throw New Exception(" Insert into ms_tools_issue error " & exp.Message)
            End Try
        End Sub
        Private Sub IssueEdit(ByVal Type As String, ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " update ms_tools_issue set shop_code = @shop_code , CalibrationDueDate = @CalibrationDueDate , user_id = @user_id , issued_date = @issued_date , " & _
                    " issued_to = @issued_to , issued_by = @issued_by  where issue_code = @issue_code "
            Try
                If CMD.ExecuteNonQuery = 0 Then
                    Throw New Exception(" Unable to update Issue details ")
                Else
                    CMD.CommandText = " update ms_tools_master set calibration_due_date = @calibration_due_date , last_iss_date = @issued_date , shop_code = @shop_code where  history_card_number = @instrument_number "
                    If CMD.ExecuteNonQuery = 0 Then
                        Throw New Exception(" tools master error")
                    Else
                        CMD.CommandText = " update ms_tools_receipt set status = 'I' where receipt_code = @receipt_code "
                        If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" tools receipt error")
                    End If
                End If
            Catch exp As Exception
                Throw New Exception(" update of Issue details error :  " & exp.Message)
            End Try
        End Sub
        Private Sub IssueDelete(ByVal Type As String, ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " delete from ms_tools_Issue where issue_code = @issue_code "
            Try
                If CMD.ExecuteNonQuery = 0 Then
                    Throw New Exception(" Unable to update Issue details ")
                Else
                    CMD.CommandText = " update ms_tools_master set calibration_due_date = null , last_iss_date = null  where  history_card_number = @instrument_number and  shop_code = @shop_code "
                    If CMD.ExecuteNonQuery = 0 Then
                        Throw New Exception(" tools master error")
                    Else
                        CMD.CommandText = " update ms_tools_receipt set status = 'U' where receipt_code = @receipt_code "
                        If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" tools receipt error")
                    End If
                End If
            Catch exp As Exception
                Throw New Exception(" delete of ms_tools_Issue error :  " & exp.Message)
            End Try
        End Sub
        Public Function InHouseData(Optional ByVal Delete As Boolean = False) As Boolean
            Dim blnDone As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Parameters.Add("@SlNo", SqlDbType.Int, 4).Value = intSlNo
                cmd.Parameters.Add("@SizeOfValue", SqlDbType.Decimal, 18, 3).Value = decSizeOfValue
                cmd.Parameters.Add("@Reading", SqlDbType.Decimal, 18, 3).Value = decReading
                cmd.Parameters.Add("@Error", SqlDbType.Decimal, 18, 3).Value = decErrorValue
                cmd.Parameters.Add("@CalibrationCode", SqlDbType.Int, 4).Value = longCalibrationCode
                cmd.Parameters.Add("@InHouseID", SqlDbType.Int, 4).Value = intInHouseID

                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                If Delete Then
                    cmd.CommandText = " delete ms_tools_InHouseData " & _
                           " where InHouseID  = @InHouseID"
                Else
                    If Val(InHouseID) = 0 Then
                        cmd.CommandText = " insert into ms_tools_InHouseData " & _
                            " ( SlNo , SizeOfValue , Reading , Error , CalibrationCode  ) " & _
                            " values ( @SlNo , @SizeOfValue , @Reading , @Error , @CalibrationCode  ) "
                    Else
                        cmd.CommandText = " update ms_tools_InHouseData " & _
                            " set SlNo = @SlNo , SizeOfValue = @SizeOfValue , Reading = @Reading , Error = @Error " & _
                            " where CalibrationCode = @CalibrationCode and InHouseID  = @InHouseID"
                    End If
                End If
                If cmd.ExecuteNonQuery > 0 Then blnDone = True
            Catch exp As Exception
                sMessage = exp.Message
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
            End Try
            Return blnDone
        End Function
        Public Function SaveJobs(ByVal WONo As String, ByVal WODate As Date, ByVal ReceivedDate As Date, ByVal Shop As String, ByVal WODesc As String, ByVal WOQty As String, ByVal AttendedBy As String, ByVal HourTaken As String, ByVal Status As String, ByVal HandedOverTo As String, ByVal Remarks As String) As Boolean
            Dim blnDone As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@WONo", SqlDbType.VarChar, 50).Value = WONo.Trim
            cmd.Parameters.Add("@WODate", SqlDbType.SmallDateTime, 4).Value = WODate
            cmd.Parameters.Add("@ReceivedDate", SqlDbType.SmallDateTime, 4).Value = ReceivedDate
            cmd.Parameters.Add("@Shop", SqlDbType.Int, 4).Value = Shop
            cmd.Parameters.Add("@WOQty", SqlDbType.VarChar, 50).Value = WOQty.Trim
            cmd.Parameters.Add("@WODesc", SqlDbType.VarChar, 500).Value = WODesc.Trim
            cmd.Parameters.Add("@AttendedBy", SqlDbType.VarChar, 50).Value = AttendedBy.Trim
            cmd.Parameters.Add("@HourTaken", SqlDbType.VarChar, 50).Value = HourTaken.Trim
            cmd.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = Status.Trim
            cmd.Parameters.Add("@HandedOverTo", SqlDbType.VarChar, 50).Value = HandedOverTo.Trim
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 50).Value = Remarks.Trim
            cmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            Try
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                cmd.CommandText = " select @cnt = count(*) from ms_JobsDoneAtTR " & _
                        " where  WONo = @WONo and Shop = @Shop "
                cmd.ExecuteScalar()
                If IIf(IsDBNull(cmd.Parameters("@Cnt").Value), 0, cmd.Parameters("@Cnt").Value) = 0 Then
                    cmd.CommandText = "insert into ms_JobsDoneAtTR " & _
                            " ( WONo , WODate , ReceivedDate , Shop , WODesc , WOQty , AttendedBy  ," & _
                            " HourTaken , Status , HandedOverTo , Remarks ) values " & _
                            " ( @WONo , @WODate , @ReceivedDate , @Shop , @WODesc , @WOQty , " & _
                            " @AttendedBy , @HourTaken , @Status , @HandedOverTo , @Remarks ) "
                Else
                    cmd.CommandText = " update ms_JobsDoneAtTR " & _
                            " set WODate = @WODate , ReceivedDate = @ReceivedDate ,  WODesc = @WODesc , " & _
                            " WOQty = @WOQty , AttendedBy = @AttendedBy , HourTaken = @HourTaken , " & _
                            " Status = @Status , HandedOverTo = @HandedOverTo , Remarks = @Remarks" & _
                            " where  WONo = @WONo and Shop = @Shop "
                End If
                If cmd.ExecuteNonQuery = 1 Then blnDone = True
            Catch exp As Exception
                sMessage = exp.Message
                Throw New Exception(exp.Message)
            Finally
                If blnDone = True Then
                    cmd.Transaction.Commit()
                Else
                    cmd.Transaction.Rollback()
                End If
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
            End Try
            Return blnDone
        End Function
        Public Function UpdateFQ(ByVal InstrumentNumber As String, ByVal StartID As Long, ByVal EndID As Long, ByVal FQ As String) As Boolean
            Dim blnDone As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Parameters.Add("@instrument_number", SqlDbType.VarChar, 50).Value = InstrumentNumber
                cmd.Parameters.Add("@StartID", SqlDbType.BigInt, 8).Value = StartID
                cmd.Parameters.Add("@EndID", SqlDbType.BigInt, 8).Value = EndID
                cmd.Parameters.Add("@CalibrationFrequency", SqlDbType.VarChar, 50).Value = FQ.Trim

                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                cmd.CommandText = " update ms_tools_issue " & _
                            " set CalibrationDueDate = wap.dbo.ms_fn_ToolsDueDate(@CalibrationFrequency , issued_date) , " & _
                            " CalibrationFrequency = @CalibrationFrequency " & _
                            " where issue_code between @StartID and @EndID "
                If cmd.ExecuteNonQuery > 0 Then blnDone = True
            Catch exp As Exception
                sMessage = exp.Message
                Throw New Exception(exp.Message)
            Finally
                If blnDone = True Then
                    cmd.Transaction.Commit()
                Else
                    cmd.Transaction.Rollback()
                End If
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
            End Try
            Return blnDone
        End Function
        Public Function DeleteTool(ByVal history_card_number As String, ByVal DeletedDate As Date, ByVal DeletedBy As String, ByVal Reasons As String, ByVal LetterNo As String, ByVal Remarks As String) As Boolean
            Dim blnDone As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@history_card_number", SqlDbType.VarChar, 50).Value = history_card_number
            cmd.Parameters.Add("@DeletedDate", SqlDbType.SmallDateTime, 4).Value = DeletedDate
            cmd.Parameters.Add("@DeletedBy", SqlDbType.VarChar, 50).Value = DeletedBy
            cmd.Parameters.Add("@Reasons", SqlDbType.VarChar, 250).Value = Reasons
            cmd.Parameters.Add("@LetterNo", SqlDbType.VarChar, 250).Value = LetterNo
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 50).Value = Remarks

            If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
            cmd.Transaction = cmd.Connection.BeginTransaction
            cmd.CommandText = "select count(*) from ms_tools_master_deleted where history_card_number = @history_card_number"
            If cmd.ExecuteScalar() = 0 Then
                cmd.CommandText = " insert into wap.dbo.ms_tools_master_deleted select * from wap.dbo.ms_tools_master where history_card_number = @history_card_number "
            End If
            Try
                If cmd.ExecuteNonQuery = 0 Then
                    Throw New Exception(" Unable to delete history_card_number details ")
                Else
                    cmd.CommandText = " delete from ms_tools_master where history_card_number = @history_card_number "
                    If cmd.ExecuteNonQuery = 1 Then
                        cmd.CommandText = "select count(*) from ms_tools_DeletedDetails where InstrumentNumber = @history_card_number"
                        If cmd.ExecuteScalar() = 0 Then
                            cmd.CommandText = " insert into wap.dbo.ms_tools_DeletedDetails ( InstrumentNumber , DeletedDate , DeletedBy , Reasons , LetterNo , Remarks ) " & _
                                " values ( @history_card_number , @DeletedDate , @DeletedBy , @Reasons , @LetterNo , @Remarks ) "
                        Else
                            cmd.CommandText = " update wap.dbo.ms_tools_DeletedDetails set DeletedDate = @DeletedDate , " & _
                                " DeletedBy = @DeletedBy , Reasons = @Reasons , LetterNo = @LetterNo , Remarks = @Remarks " & _
                                " where InstrumentNumber =  @history_card_number "
                        End If
                        If cmd.ExecuteNonQuery = 1 Then
                            blnDone = True
                        Else
                            Throw New Exception(" Unable to update history_card_number Deleted Details ")
                        End If
                    Else
                        Throw New Exception(" Unable to delete history_card_number Details ")
                    End If
                End If
            Catch exp As Exception
                Throw New Exception(" delete of ms_tools_master error :  " & exp.Message)
            Finally
                If blnDone = True Then
                    cmd.Transaction.Commit()
                Else
                    cmd.Transaction.Rollback()
                End If
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
            End Try
            Return blnDone
        End Function
        Public Function UpdateShop(ByVal InstrumentNumber As String, ByVal shop_code As String) As Boolean
            Dim blnDone As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Parameters.Add("@instrument_number", SqlDbType.VarChar, 50).Value = InstrumentNumber
                cmd.Parameters.Add("@shop_code", SqlDbType.VarChar, 50).Value = shop_code.Trim

                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                cmd.CommandText = " update ms_tools_master " & _
                            " set shop_code = @shop_code " & _
                            " where history_card_number = @instrument_number "
                If cmd.ExecuteNonQuery > 0 Then blnDone = True
            Catch exp As Exception
                sMessage = exp.Message
                Throw New Exception(exp.Message)
            Finally
                If blnDone = True Then
                    cmd.Transaction.Commit()
                Else
                    cmd.Transaction.Rollback()
                End If
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
            End Try
            Return blnDone
        End Function
#End Region
    End Class
End Namespace
