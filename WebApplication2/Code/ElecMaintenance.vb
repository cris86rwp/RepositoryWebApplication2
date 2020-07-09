Namespace Maintenance
    <Serializable()> Public Class ElecTables
        Public Shared Function RWFEnergyItems(ByVal frdt As Date, ByVal todt As Date, ByVal Type As Integer) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@frdt", SqlDbType.SmallDateTime, 4).Value = frdt
                da.SelectCommand.Parameters.Add("@todt", SqlDbType.SmallDateTime, 4).Value = todt
                da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = Type
                da.SelectCommand.CommandText = "mm_sp_RWFEnergyItems"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.Fill(ds)
                RWFEnergyItems = ds.Tables(0).Copy
            Catch exp As Exception
                RWFEnergyItems = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function LatestConsumptionDate() As Date
            Dim Cmd As System.Data.SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Cmd.Parameters.Add("@ConsDate", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output
            Cmd.CommandText = "select top 1 @ConsDate = a.ConsumptionDate  " &
                " FROM ms_DailyVoltage a inner join ms_DailyCurrent b " &
                " on a.ConsumptionDate = b.ConsumptionDate inner join ms_DailyPower c " &
                " on a.ConsumptionDate = c.ConsumptionDate" &
                " order by a.ConsumptionDate desc"
            Try
                If Cmd.Connection.State = ConnectionState.Closed Then Cmd.Connection.Open()
                Cmd.ExecuteScalar()
                LatestConsumptionDate = IIf(IsDBNull(Cmd.Parameters("@ConsDate").Value), CDate("1900-01-01"), Cmd.Parameters("@ConsDate").Value)
            Catch exp As Exception
                LatestConsumptionDate = CDate("1900-01-01")
                Throw New Exception(exp.Message)
            Finally
                If Cmd.Connection.State = ConnectionState.Open Then Cmd.Connection.Close()
                Cmd.Dispose()
            End Try
        End Function
        Public Shared Function NewEnergyItems() As DataTable
            Dim oDs As New DataSet()
            Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            oDa.SelectCommand.CommandText = "select Sl , Item from mm_vw_RWFEnergyItems order by Sl"
            Try
                oDa.Fill(oDs)
                NewEnergyItems = oDs.Tables(0)
            Catch exp As Exception
                NewEnergyItems = Nothing
                Throw New Exception(exp.Message)
            Finally
                oDa.Dispose()
                oDs.Dispose()
            End Try
        End Function
        Public Shared Function NewEnergyItemsData(ByVal FromDate As Date, ByVal ToDate As Date, ByVal Type As Integer) As DataTable
            Dim oDs As New DataSet()
            Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            oDa.SelectCommand.Parameters.Add("@FrDt", SqlDbType.SmallDateTime, 4).Value = FromDate
            oDa.SelectCommand.Parameters.Add("@ToDt", SqlDbType.SmallDateTime, 4).Value = ToDate
            oDa.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = Type
            If Type = 102 OrElse Type = 103 Then
                oDa.SelectCommand.CommandText = "select * from mm_fn_RWFEnergyProductDetails(@FrDt,@ToDt,@Type)"
            Else
                oDa.SelectCommand.CommandText = "mm_sp_RWFEnergyItems"
                oDa.SelectCommand.CommandType = CommandType.StoredProcedure
            End If

            Try
                oDa.Fill(oDs)
                NewEnergyItemsData = oDs.Tables(0)
            Catch exp As Exception
                NewEnergyItemsData = Nothing
                Throw New Exception(exp.Message)
            Finally
                oDa.Dispose()
                oDs.Dispose()
            End Try
        End Function
        Public Shared Function RWFEnergyTargetData(ByVal PhlDate As Date) As DataTable
            Dim oDs As New DataSet()
            Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            oDa.SelectCommand.Parameters.Add("@PhlDate", SqlDbType.SmallDateTime, 4).Value = PhlDate
            oDa.SelectCommand.CommandText = "mm_sp_RWFEnergyTargetData"
            oDa.SelectCommand.CommandType = CommandType.StoredProcedure
            Try
                oDa.Fill(oDs)
                RWFEnergyTargetData = oDs.Tables(0)
            Catch exp As Exception
                RWFEnergyTargetData = Nothing
                Throw New Exception(exp.Message)
            Finally
                oDa.Dispose()
                oDs.Dispose()
            End Try
        End Function
        Public Shared Function NewEnergyData(ByVal FromDate As Date, ByVal ToDate As Date, ByVal Type As Int16) As DataTable
            Dim oDs As New DataSet()
            Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            oDa.SelectCommand.Parameters.Add("@FrDt", SqlDbType.SmallDateTime, 4).Value = FromDate
            oDa.SelectCommand.Parameters.Add("@ToDt", SqlDbType.SmallDateTime, 4).Value = ToDate
            oDa.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = Type
            oDa.SelectCommand.CommandText = "ms_sp_electrical_econs"
            oDa.SelectCommand.CommandType = CommandType.StoredProcedure
            Try
                oDa.Fill(oDs)
                NewEnergyData = oDs.Tables(0)
            Catch exp As Exception
                NewEnergyData = Nothing
                Throw New Exception(exp.Message)
            Finally
                oDa.Dispose()
                oDs.Dispose()
            End Try
        End Function
        Public Shared Function GetTopSummaryReportDate() As Date
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.CommandText = "select top 1 @PhlDate =  PhlDate from mm_RWFEnergySummary order by PhlDate desc "
            cmd.Parameters.Add("@PhlDate", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output
            Try
                cmd.Connection.Open()
                cmd.ExecuteScalar()
                GetTopSummaryReportDate = IIf(IsDBNull(cmd.Parameters("@PhlDate").Value), "01-01-1900", cmd.Parameters("@PhlDate").Value)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function GetTopPHLDate() As Date
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.CommandText = "select top 1 @phl_date =  phl_date from mm_phl_generation order by phl_date desc "
            cmd.Parameters.Add("@phl_date", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output
            Try
                cmd.Connection.Open()
                cmd.ExecuteScalar()
                GetTopPHLDate = IIf(IsDBNull(cmd.Parameters("@phl_date").Value), "01-01-1900", cmd.Parameters("@phl_date").Value)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function CheckReportDate(ByVal TableName As String, ByVal TableField As String, Optional ByVal c_date As Date = #1/1/1900#) As Date
            Dim Cmd As System.Data.SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Cmd.Parameters.Add("@FurDt", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output
            Cmd.Parameters.Add("@c_date", SqlDbType.SmallDateTime, 4).Value = c_date
            If c_date = #1/1/1900# Then
                Cmd.CommandText = "select top 1 @FurDt = " & TableField & " " &
                    " from " & TableName.Trim & " " &
                    " order by " & TableField & " desc "
            Else
                Cmd.CommandText = "select @FurDt = " & TableField & " " &
                    " from " & TableName.Trim & " " &
                    " where " & TableField & " =  @c_date "
            End If
            Try
                If Cmd.Connection.State = ConnectionState.Closed Then Cmd.Connection.Open()
                Cmd.ExecuteScalar()
                CheckReportDate = IIf(IsDBNull(Cmd.Parameters("@FurDt").Value), #1/1/1900#, Cmd.Parameters("@FurDt").Value)
            Catch exp As Exception
                CheckReportDate = #1/1/1900#
                Throw New Exception(exp.Message)
            Finally
                If Cmd.Connection.State = ConnectionState.Open Then Cmd.Connection.Close()
                Cmd.Dispose()
            End Try
        End Function
        Public Shared Function FurnaceCounts(ByVal FurMonth As Integer, ByVal FurYear As Integer, ByVal Fur As String) As Integer
            Dim Cmd As System.Data.SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Cmd.Parameters.Add("@Cons", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            Cmd.Parameters.Add("@FurMonth", SqlDbType.Int, 4).Value = FurMonth
            Cmd.Parameters.Add("@FurYear", SqlDbType.Int, 4).Value = FurYear
            Cmd.Parameters.Add("@Fur", SqlDbType.VarChar, 4).Value = Fur
            Cmd.CommandText = "select @Cons = count(*) from ms_furnace_melting_statistics " &
                " where month(consumption_date) = @FurMonth and " &
                " year(consumption_date) = @FurYear and furnace_number = @Fur "
            Try
                If Cmd.Connection.State = ConnectionState.Closed Then Cmd.Connection.Open()
                Cmd.ExecuteScalar()
                FurnaceCounts = IIf(IsDBNull(Cmd.Parameters("@Cons").Value), 0, Cmd.Parameters("@Cons").Value)
            Catch exp As Exception
                FurnaceCounts = 0
                Throw New Exception(exp.Message)
            Finally
                If Cmd.Connection.State = ConnectionState.Open Then Cmd.Connection.Close()
                Cmd.Dispose()
            End Try
        End Function
        Public Shared Function FurnaceStats(ByVal FurMonth As Integer, ByVal FurYear As Integer, ByVal Fur As String) As Integer
            Dim Cmd As System.Data.SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Cmd.Parameters.Add("@Cons", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            Cmd.Parameters.Add("@FurMonth", SqlDbType.Int, 4).Value = FurMonth
            Cmd.Parameters.Add("@FurYear", SqlDbType.Int, 4).Value = FurYear
            Cmd.Parameters.Add("@Fur", SqlDbType.VarChar, 4).Value = Fur
            Cmd.CommandText = "select @Cons = sum(consumption) from ms_furnace_melting_statistics " &
                " where month(consumption_date) = @FurMonth and " &
                " year(consumption_date) = @FurYear and furnace_number = @Fur "
            Try
                If Cmd.Connection.State = ConnectionState.Closed Then Cmd.Connection.Open()
                Cmd.ExecuteScalar()
                FurnaceStats = IIf(IsDBNull(Cmd.Parameters("@Cons").Value), 0, Cmd.Parameters("@Cons").Value)
            Catch exp As Exception
                FurnaceStats = 0
                Throw New Exception(exp.Message)
            Finally
                If Cmd.Connection.State = ConnectionState.Open Then Cmd.Connection.Close()
                Cmd.Dispose()
            End Try
        End Function
        Public Shared Function getMonthYear(ByVal TableName As String, ByVal TableField As String) As DataSet
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "SELECT distinct month(" & TableField & ") M ,  " &
                    " datename(mm," & TableField & ") Mn  " &
                    " FROM " & TableName & "" &
                    " order by month(" & TableField & ") ;" &
                    " SELECT distinct  year(" & TableField & ") Y " &
                    " FROM " & TableName & " " &
                    " order by year(" & TableField & ") desc "
                da.Fill(ds)
                getMonthYear = ds.Copy
            Catch exp As Exception
                getMonthYear = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function ElectricalEnergyCorrection(ByVal FrDate As Date, ByVal ToDate As Date) As Boolean
            Dim Cmd As System.Data.SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Cmd.Parameters.Add("@FrDt", SqlDbType.SmallDateTime, 4).Value = FrDate
            Cmd.Parameters.Add("@ToDt", SqlDbType.SmallDateTime, 4).Value = ToDate
            Cmd.CommandText = "ms_sp_ElectricalEnergyCorrection"
            Cmd.CommandType = CommandType.StoredProcedure

            Try
                If Cmd.Connection.State = ConnectionState.Closed Then Cmd.Connection.Open()
                Cmd.ExecuteNonQuery()
                Return True
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If Cmd.Connection.State = ConnectionState.Open Then Cmd.Connection.Close()
                Cmd.Dispose()
            End Try
        End Function
        Public Shared Function no_of_heats(ByVal FrDate As Date, ByVal ToDate As Date) As Integer
            Dim Cmd As System.Data.SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Cmd.Parameters.Add("@FrDt", SqlDbType.SmallDateTime, 4).Value = FrDate
            Cmd.Parameters.Add("@ToDt", SqlDbType.SmallDateTime, 4).Value = ToDate
            Cmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            Cmd.CommandText = "select @cnt = count(*) from mm_vw_HeatTapped " &
                    " where TappedDate between @FrDt and @ToDt "
            Try
                If Cmd.Connection.State = ConnectionState.Closed Then Cmd.Connection.Open()
                Cmd.ExecuteNonQuery()
                Return IIf(IsDBNull(Cmd.Parameters("@cnt").Value), 0, Cmd.Parameters("@cnt").Value)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If Cmd.Connection.State = ConnectionState.Open Then Cmd.Connection.Close()
                Cmd.Dispose()
            End Try
        End Function
        Public Shared Function getData(ByVal FrDate As Date, ByVal ToDate As Date) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@FrDate", SqlDbType.SmallDateTime, 4).Value = FrDate
                da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.SmallDateTime, 4).Value = ToDate
                da.SelectCommand.CommandText = "select * from ms_electrical_econs " &
                    " where c_date between @FrDate and @ToDate "
                da.Fill(ds)
                getData = ds.Tables(0)
            Catch exp As Exception
                getData = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function

        Public Shared Function CheckCDate(ByVal c_date As Date) As Boolean
            Dim Cmd As System.Data.SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Cmd.Parameters.Add("@Sl", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            Cmd.Parameters.Add("@c_date", SqlDbType.SmallDateTime, 4).Value = c_date
            Cmd.CommandText = "select @Sl = count(*) from ms_electrical_econs where c_date = @c_date "
            Try
                If Cmd.Connection.State = ConnectionState.Closed Then Cmd.Connection.Open()
                Cmd.ExecuteScalar()
                CheckCDate = IIf(IsDBNull(Cmd.Parameters("@Sl").Value), 0, Cmd.Parameters("@Sl").Value)
            Catch exp As Exception
                CheckCDate = 0
                Throw New Exception(exp.Message)
            Finally
                If Cmd.Connection.State = ConnectionState.Open Then Cmd.Connection.Close()
                Cmd.Dispose()
            End Try
        End Function
        Public Shared Function newVoltageCurrent(ByVal ConsumptionDate As Date) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@ConsumptionDate", SqlDbType.SmallDateTime, 4).Value = ConsumptionDate
                da.SelectCommand.CommandText = "ms_sp_newVoltageCurrent"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.Fill(ds)
                newVoltageCurrent = ds.Tables(0)
            Catch exp As Exception
                newVoltageCurrent = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function getSerailNumber(ByVal failure_date As Date) As Integer
            Dim Cmd As System.Data.SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Cmd.Parameters.Add("@Sl", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            Cmd.CommandText = "select @Sl = max(serial_number) from ms_power_failure "
            Try
                If Cmd.Connection.State = ConnectionState.Closed Then Cmd.Connection.Open()
                Cmd.ExecuteScalar()
                getSerailNumber = IIf(IsDBNull(Cmd.Parameters("@Sl").Value), 1, Cmd.Parameters("@Sl").Value + 1)
            Catch exp As Exception
                getSerailNumber = 1
                Throw New Exception(exp.Message)
            Finally
                If Cmd.Connection.State = ConnectionState.Open Then Cmd.Connection.Close()
                Cmd.Dispose()
            End Try
        End Function
        Public Shared Function PowerFailureValues(ByVal failure_date As Date, ByVal serial_number As Integer, Optional ByVal Grid As Boolean = False) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                If Grid Then
                    da.SelectCommand.CommandText = "select serial_number , " &
                    " convert(varchar,failure_date,103) failure_date, from_time, to_time,  " &
                    " failure_duration,  sf_restriction_from ,  sf_restriction_to, sf_duration, " &
                    " df_restriction_from , df_restriction_to, df_duration, total_restriction, Remarks " &
                    " from ms_power_failure where failure_date = @failure_date "
                Else
                    da.SelectCommand.CommandText = "select serial_number , " &
                        " convert(varchar,failure_date,103) failure_date, from_time, to_time,  " &
                        " failure_duration,  sf_restriction_from ,  sf_restriction_to, sf_duration, " &
                        " df_restriction_from , df_restriction_to, df_duration, total_restriction, Remarks " &
                        " from ms_power_failure where failure_date = @failure_date " &
                        " and serial_number = @serial_number "
                End If
                da.SelectCommand.Parameters.Add("@failure_date", SqlDbType.SmallDateTime, 4).Value = failure_date
                da.SelectCommand.Parameters.Add("@serial_number", SqlDbType.Int, 4).Value = serial_number
                da.Fill(ds)
                PowerFailureValues = ds.Tables(0)
            Catch exp As Exception
                PowerFailureValues = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function DailyMDPF(ByVal ConsumptionDate As Date) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = " select RecordedMD , PowerFactor , MDTrippings  , TotalTime from  ms_DailyMDPF " &
                    " where ConsumptionDate = @ConsumptionDate "
                da.SelectCommand.Parameters.Add("@ConsumptionDate", SqlDbType.SmallDateTime, 4).Value = ConsumptionDate
                da.Fill(ds)
                DailyMDPF = ds.Tables(0)
            Catch exp As Exception
                DailyMDPF = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function ShootUpMD(ByVal ConsumptionDate As Date) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = " select convert(varchar(10),ConsumptionDate,103) ShiftDt ," &
                    " convert(varchar(10),ShootUpDateTime,103) ShootUpDate , ShootUpDateTime , MVA , Sl from  ms_ShootUpMD " &
                    " where ConsumptionDate = @ConsumptionDate "
                da.SelectCommand.Parameters.Add("@ConsumptionDate", SqlDbType.SmallDateTime, 4).Value = ConsumptionDate
                da.Fill(ds)
                ShootUpMD = ds.Tables(0)
            Catch exp As Exception
                ShootUpMD = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function getEditDetails(ByVal MeltNo As Double) As DataSet
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = " select * from ms_furnace_melting_statistics_trreadings " &
                    " where melt_no = @MeltNo ; " &
                    " select * from ms_furnace_melting_statistics " &
                    " where melt_no = @MeltNo ;  "
                da.SelectCommand.Parameters.Add("@MeltNo", SqlDbType.BigInt, 8).Value = MeltNo
                da.Fill(ds)
                getEditDetails = ds.Copy
            Catch exp As Exception
                getEditDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function strCode(ByVal Umt As Decimal) As String
            Dim Cmd As System.Data.SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Cmd.Parameters.Add("@Code", SqlDbType.VarChar, 1).Direction = ParameterDirection.Output
            Cmd.CommandText = "select @Code = wap.dbo.ms_fn_EnergyCode(" & Umt & ") "
            Try
                If Cmd.Connection.State = ConnectionState.Closed Then Cmd.Connection.Open()
                Cmd.ExecuteScalar()
                strCode = IIf(IsDBNull(Cmd.Parameters("@Code").Value), "", Cmd.Parameters("@Code").Value)
            Catch exp As Exception
                strCode = ""
                Throw New Exception(exp.Message)
            Finally
                If Cmd.Connection.State = ConnectionState.Open Then Cmd.Connection.Close()
                Cmd.Dispose()
            End Try
        End Function
        Public Shared Function TtoTsame(ByVal MeltNo As Double, ByVal ArcFur As String) As DateTime
            Dim Cmd As System.Data.SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Cmd.Parameters.Add("@TtoTsame", SqlDbType.DateTime, 8).Direction = ParameterDirection.Output
            Try
                Cmd.CommandText = " select @TtoTsame =  max(Melt_to) from  ms_furnace_melting_statistics_trreadings " &
                    " where Melt_no in ( select top 1 Melt_no  from  ms_furnace_melting_statistics where  furnace_number = '" & ArcFur.Trim & "' " &
                    " and  Melt_no < '" & MeltNo & "' order by Melt_no desc ) "
                If Cmd.Connection.State = ConnectionState.Closed Then Cmd.Connection.Open()
                Cmd.ExecuteScalar()
                TtoTsame = IIf(IsDBNull(Cmd.Parameters("@TtoTsame").Value), Now, Cmd.Parameters("@TtoTsame").Value)
            Catch exp As Exception
                TtoTsame = Now
                Throw New Exception(exp.Message)
            Finally
                If Cmd.Connection.State = ConnectionState.Open Then Cmd.Connection.Close()
                Cmd.Dispose()
            End Try
        End Function
        Public Shared Function TtoTany(ByVal MeltNo As Double) As DateTime
            Dim Cmd As System.Data.SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Cmd.Parameters.Add("@TtoTany", SqlDbType.DateTime, 8).Direction = ParameterDirection.Output
            Try
                Cmd.CommandText = " select @TtoTany =  max(Melt_to) from  ms_furnace_melting_statistics_trreadings " &
                    " where Melt_no in ( select top 1 melt_no from  ms_furnace_melting_statistics  " &
                    " where  Melt_no < '" & MeltNo & "' order by Melt_no desc ) "
                If Cmd.Connection.State = ConnectionState.Closed Then Cmd.Connection.Open()
                Cmd.ExecuteScalar()
                TtoTany = IIf(IsDBNull(Cmd.Parameters("@TtoTany").Value), Now, Cmd.Parameters("@TtoTany").Value)
            Catch exp As Exception
                TtoTany = Now
                Throw New Exception(exp.Message)
            Finally
                If Cmd.Connection.State = ConnectionState.Open Then Cmd.Connection.Close()
                Cmd.Dispose()
            End Try
        End Function
        Public Shared Function ConvertTimeInNumberToHour(ByVal meltingtime As Integer) As String
            Dim Cmd As System.Data.SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Cmd.Parameters.Add("@Timeloss", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output
            Cmd.CommandText = "select @Timeloss = wap.dbo.ms_fn_ConvertTimeInNumberToHour(" & meltingtime & " )"
            Try
                If Cmd.Connection.State = ConnectionState.Closed Then Cmd.Connection.Open()
                Cmd.ExecuteScalar()
                ConvertTimeInNumberToHour = IIf(IsDBNull(Cmd.Parameters("@Timeloss").Value), "", Cmd.Parameters("@Timeloss").Value)
            Catch exp As Exception
                ConvertTimeInNumberToHour = ""
                Throw New Exception(exp.Message)
            Finally
                If Cmd.Connection.State = ConnectionState.Open Then Cmd.Connection.Close()
                Cmd.Dispose()
            End Try
        End Function
        Public Shared Function getFurnaceData(ByVal consumption_date As Date) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                'da.SelectCommand.CommandText = "select row_number() over ( order by a.Melt_no asc ) Sl ," & _
                '    " convert(varchar,a.Consumption_date,103) ConspDate , a.Melt_no , a.Melt_month ,  " & _
                '    " b.TRno , b.Melt_from , b.Melt_to , b.Energy_final , b.Energy_initial , " & _
                '    " a.Consumption , a.ScrapInMT , a.UnitsPerMT , a.Code , " & _
                '    " a.Maximum_Demand MaxDemand , a.Furnace_Number FurNumber, " & _
                '    " a.vcb_number VCB , a.melting_time MeltTime , " & _
                '    " a.TtoTsameAF , a.TtoPsameAF, a.TtoTanyAF, a.remarks" & _
                '    " from ms_furnace_melting_statistics a " & _
                '    " inner join ms_furnace_melting_statistics_trreadings b  " & _
                '    " on b.Melt_no = a.Melt_no " & _
                '    " where a.consumption_date = @consumptionDate " & _
                '    " order by a.Melt_no asc "
                da.SelectCommand.CommandText = "select row_number() over ( order by a.Melt_no asc ) Sl ," &
                    " convert(varchar,a.Consumption_date,103) ConspDate , a.Melt_no , a.Melt_month ,  " &
                    " b.Melt_from , b.Melt_to , b.Energy_final , b.Energy_initial , " &
                    " a.Consumption , a.ScrapInMT , a.UnitsPerMT , a.Code , " &
                    " a.Maximum_Demand MaxDemand , a.Furnace_Number FurNumber, " &
                    " a.vcb_number VCB , a.melting_time MeltTime " &
                    " from ms_furnace_melting_statistics a " &
                    " inner join ms_furnace_melting_statistics_trreadings b  " &
                    " on b.Melt_no = a.Melt_no " &
                    " where a.consumption_date = @consumptionDate " &
                    " order by a.Melt_no asc "

                da.SelectCommand.Parameters.Add("@consumptionDate", SqlDbType.SmallDateTime, 4).Value = consumption_date
                da.Fill(ds)
                getFurnaceData = ds.Tables(0)
            Catch exp As Exception
                getFurnaceData = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function getMeltNoMonth() As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "select top 1 melt_no , melt_month from ms_furnace_melting_statistics order by melt_no desc "
                da.Fill(ds)
                getMeltNoMonth = ds.Tables(0)
            Catch exp As Exception
                getMeltNoMonth = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function getArcFurnaceDetails(ByVal consumptionDate As Date) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "ms_sp_ArcFurnaceMeltingStats"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.Add("@consumptionDate", SqlDbType.SmallDateTime, 4).Value = consumptionDate
                da.Fill(ds)
                getArcFurnaceDetails = ds.Tables(0)
            Catch exp As Exception
                getArcFurnaceDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function getArcfurnaceValues(ByVal consumption_date As Date) As DataSet
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "  select consumption_date , " &
                    " arc1_final , arc2_final , arc3_final  , radarc1 , radarc2 , radarc3 , " &
                    " arc1_initial , arc2_initial , arc3_initial , remarks_arc1 , remarks_arc2 , remarks_arc3 " &
                    " from ms_arcfurnace_energy_consumption where consumption_date = @consumptionDate order by  consumption_date desc ; " &
                    " select count(*) cnt from ms_arcfurnace_energy_consumption where consumption_date = @consumptionDate "
                da.SelectCommand.Parameters.Add("@consumptionDate", SqlDbType.SmallDateTime, 4).Value = consumption_date
                da.Fill(ds)
                getArcfurnaceValues = ds.Copy
            Catch exp As Exception
                getArcfurnaceValues = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function getMFvaluesLimited() As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = " select MF from ms_energy_mf where MF in (1,18000) order by MF "
                da.Fill(ds)
                getMFvaluesLimited = ds.Tables(0)
            Catch exp As Exception
                getMFvaluesLimited = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function getinitialvalues() As DataSet
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "  select top 1 consumption_date , " &
                    " arc1_final , arc2_final , arc3_final  , radarc1 , radarc2 , radarc3 " &
                    " from ms_arcfurnace_energy_consumption order by  consumption_date desc "
                da.Fill(ds)
                getinitialvalues = ds.Copy
            Catch exp As Exception
                getinitialvalues = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function getRemarks(ByVal consumption_date As Date) As DataSet
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                'da.SelectCommand.CommandText = " select remarks_kptcl,remarks_generated,remarks_arc1,remarks_arc2," & _
                '    " remarks_arc3,remarks_pumphouse,remarks_colony,remarks_adminbldg," & _
                '    " remarks_emms,remarks_rwfgen,remarks_CheckMeter from ms_admin_energy_consumption " & _
                '    " where consumption_date= @consumptionDate ;" & _
                '    " select remarks_essential,remarks_nonessential,remarks_gfm," & _
                '    " remarks_assembly,remarks_canteen,remarks_lop from ms_axle_energy_consumption " & _
                '    " where consumption_date= @consumptionDate ; " & _
                '    " select remarks_essential,remarks_nonessential,remarks_tube," & _
                '    " remarks_mould,remarks_compressor,remarks_fumex from ms_wheel_energy_consumption " & _
                '    " where consumption_date = @consumptionDate "
                da.SelectCommand.CommandText = " select remarks_kptcl,remarks_generated,remarks_arc1,remarks_arc2," &
                    " remarks_arc3,remarks_pumphouse,remarks_colony,remarks_colony1, remarks_adminbldg," &
                    " remarks_rwfgen,remarks_pcs from ms_admin_energy_consumption " &
                    " where consumption_date= @consumptionDate ;" &
                    " select remarks_essential,remarks_tube," &
                    " remarks_mould,remarks_compressor,remarks_fumex from ms_wheel_energy_consumption " &
                    " where consumption_date = @consumptionDate "

                da.SelectCommand.Parameters.Add("@consumptionDate", SqlDbType.SmallDateTime, 4).Value = consumption_date

                da.Fill(ds)
                getRemarks = ds.Copy
            Catch exp As Exception
                getRemarks = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function getUnitsforMonth(ByVal consumption_date As Date) As DataSet
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = " SELECT sum((wsesstr1_final - wsesstr1_initial )*radess ) + sum((wsesstr2_final - wsesstr2_initial )*radess1 ) , " &
                    "  " &
                    " sum((tubepretr1_final - tubepretr1_initial )*radTube ) +  sum((tubepretr2_final - tubepretr2_initial )*radTube1 ) , " &
                    " sum((mouldpretr1_final - mouldpretr1_initial )*radMld ) + sum((mouldpretr2_final - mouldpretr2_initial )*radMld1)+ sum((mouldpretr3_final - mouldpretr3_initial )*radMld2) , " &
                    " sum((comptr1_final - comptr1_initial )*radCmp ) + sum((comptr2_final - comptr2_initial )*radCmp1) , " &
                    " sum((fumetr1_final - fumetr1_initial )*radFm ) + sum((fumetr2_final - fumetr2_initial )*radFm1 )  " &
                    " FROM ms_wheel_energy_consumption " &
                    " where consumption_date = @consumptionDate ; " &
                    " SELECT sum((essential_final-essential_initial)*radaxl) + sum((essential_final1 - essential_initial1 )*radaxl1 ) , " &
                    " sum((nonessential_final-nonessential_initial)*radaxlN ) + sum((nonessential_final1-nonessential_initial1)*radaxlN1) , " &
                    " sum((gm_final-gfm_initial)* radgm ) + sum((gm_final1-gfm_initial1)* radgm1 ) ," &
                    " sum((assembly_final-assembly_initial)*radass) + sum((assembly_final1-assembly_initial1)*radass1)  , " &
                    " sum((canteen_final-canteen_initial)*radcan ) + sum((canteen_final1-canteen_initial1)*radcan1 ) , " &
                    " sum((lop_final-lop_initial)*radlop )   " &
                    " FROM ms_axle_energy_consumption " &
                    " where consumption_date = @consumptionDate ; " &
                    " SELECT sum((kptcl_final - kptcl_initial)*radkptcl ) , (sum((dg_gen1_final - dg_gen1_initial)*raddgI ) + " &
                    " sum((dg_gen2_final - dg_gen2_initial)*raddgII ) + sum((dg_gen3_final - dg_gen3_initial)*raddgIII ) ) , " &
                    " sum((arc1_final-arc1_initial)*radarc1 ), sum((arc2_final-arc2_initial)*radarc2 ), sum((arc3_final-arc3_initial)*radarc3 ), " &
                    " sum((pumphouse_final-pumphouse_initial )*radpump) , sum((colony_final-colony_initial)*radcolony) ,sum((colony_final1-colony_initial1)*radcolony1), " &
                    " sum((adminbldg_final-adminbldg_initial)*radadmn), sum((stnaux_final-stnaux_initial)*radaux) , " &
                    "  " &
                    " sum((rwfgen_final-rwfgen_initial)*radrwfgen) ,sum((pcs_final-pcs_initial)*radpcs) " &
                    " FROM ms_admin_energy_consumption " &
                    " where consumption_date = @consumptionDate ; " &
                    " exec wap.dbo.ms_sp_ArcFurnaceMeltingStats @consumptionDate "
                da.SelectCommand.Parameters.Add("@consumptionDate", SqlDbType.SmallDateTime, 4).Value = consumption_date
                da.Fill(ds)
                getUnitsforMonth = ds.Copy
            Catch exp As Exception
                getUnitsforMonth = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function GetPFDetails(ByVal PFDate As Date)
            Dim dtFailureDetails As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@PFDate", SqlDbType.SmallDateTime, 4)
            da.SelectCommand.Parameters("@PFDate").Direction = ParameterDirection.Input
            da.SelectCommand.CommandText = " select * from ms_vw_ElecPFReadings where ReadingDate = @PFDate order by SlNo "

            Try
                da.SelectCommand.Parameters("@PFDate").Value = PFDate
                da.Fill(ds, "PFDate")
                dtFailureDetails = ds.Tables("PFDate")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtFailureDetails
        End Function
        Public Shared Function getTODUnitsforMonth(ByVal consumption_date As Date) As DataTable
            Dim dtUnitsforMonth As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@from_date", SqlDbType.SmallDateTime, 4)
            da.SelectCommand.Parameters("@from_date").Direction = ParameterDirection.Input
            da.SelectCommand.Parameters.Add("@consumption_date", SqlDbType.SmallDateTime, 4)
            da.SelectCommand.Parameters("@consumption_date").Direction = ParameterDirection.Input
            da.SelectCommand.CommandText = " SELECT sum((C0_final - C0_initial)*180000 ) C0 , " &
                " sum((C1_final - C1_initial)*180000) C1 ," &
                " sum((C2_final - C2_initial)*180000) C2   " &
                " FROM ms_TODReadings " &
                " where consumption_date between @from_date and @consumption_date "
            Try
                da.SelectCommand.Parameters("@consumption_date").Value = consumption_date
                da.SelectCommand.Parameters("@from_date").Value = consumption_date.AddDays(-(consumption_date.Day) + 1)
                da.Fill(ds, "UnitsforMonth")
                dtUnitsforMonth = ds.Tables("UnitsforMonth")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtUnitsforMonth
        End Function
        Public Shared Function getTODUnitsforDay(ByVal consumption_date As Date) As DataTable
            Dim dtUnitsforDay As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@consumption_date", SqlDbType.SmallDateTime, 4)
            da.SelectCommand.Parameters("@consumption_date").Direction = ParameterDirection.Input

            da.SelectCommand.CommandText = " select consumption_date , C0_initial , C0_final , C1_initial , C1_final , " &
                    " C2_initial , C2_final , remarks_C0 , remarks_C1 , remarks_C2 from  ms_TODReadings where consumption_date = @consumption_date "
            Try
                da.SelectCommand.Parameters("@consumption_date").Value = consumption_date
                da.Fill(ds, "UnitsforDay")
                dtUnitsforDay = ds.Tables("UnitsforDay")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtUnitsforDay
        End Function
        Public Shared Function getTOP5InitialValues() As DataTable
            Dim dtInitialValues As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()

            da.SelectCommand.CommandText = " select top 5 convert(varchar(10),consumption_date,103) TODDate , " &
                " C0_initial , C0_final , C1_initial , C1_final , C2_initial , C2_final from  ms_TODReadings order by  consumption_date  desc "
            Try
                da.Fill(ds, "InitialValues")
                dtInitialValues = ds.Tables("InitialValues")
            Catch exp As Exception
                dtInitialValues = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtInitialValues
        End Function
        Public Shared Function getTODInitialValues(ByVal consumption_date As Date) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()

            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@TopDate", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output
            Try
                cmd.CommandText = " select top 1 @TopDate = consumption_date " &
                " from  ms_TODReadings order by consumption_date  desc "
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.ExecuteScalar()
                If cmd.Parameters("@TopDate").Value = consumption_date Then
                    da.SelectCommand.CommandText = " select top 1 'Yes' TopDate , C0_final , C1_final , C2_final " &
                        " from  ms_TODReadings order by consumption_date  desc  "
                Else
                    da.SelectCommand.CommandText = " select top 1 'No' TopDate , C0_initial , " &
                        " C0_final , C1_initial , C1_final , C2_initial , C2_final , " &
                        " radC0 , radC1 , radC2 , remarks_C0 , remarks_C1 , remarks_C2 " &
                        " from  ms_TODReadings where consumption_date  = @consumption_date "
                End If
                da.SelectCommand.Parameters.Add("@consumption_date", SqlDbType.SmallDateTime, 4).Value = consumption_date
                da.Fill(ds)
                getTODInitialValues = ds.Tables(0)
            Catch exp As Exception
                getTODInitialValues = Nothing
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function CheckTopTODData(ByVal consumption_date As Date) As Long
            Dim RecID As Long
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@consumption_date", SqlDbType.SmallDateTime, 4)
            cmd.Parameters("@consumption_date").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@TopDate", SqlDbType.SmallDateTime, 4)
            cmd.Parameters("@TopDate").Direction = ParameterDirection.Output
            cmd.CommandText = " select @TopDate = isnull(( select top 1 consumption_date from  ms_TODReadings order by  consumption_date  desc ),'1900-01-01') "
            Try
                cmd.Parameters("@consumption_date").Value = consumption_date
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.ExecuteScalar()
                RecID = IIf((cmd.Parameters("@TopDate").Value = cmd.Parameters("@consumption_date").Value), 1, 0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
            End Try
            Return RecID
        End Function
        Public Shared Function CheckTopShopWiseData(ByVal consumption_date As Date) As Long
            Dim RecID As Long
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@consumption_date", SqlDbType.SmallDateTime, 4)
            cmd.Parameters("@consumption_date").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@TopDate", SqlDbType.SmallDateTime, 4)
            cmd.Parameters("@TopDate").Direction = ParameterDirection.Output
            cmd.CommandText = " select @TopDate = ( select top 1 c_date from  ms_electrical_econs order by c_date desc )"
            Try
                cmd.Parameters("@consumption_date").Value = consumption_date
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.ExecuteScalar()
                RecID = IIf((cmd.Parameters("@TopDate").Value = cmd.Parameters("@consumption_date").Value), 0, 1)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
            End Try
            Return RecID
        End Function
        Public Shared Function CheckTopAdminData(ByVal consumption_date As Date) As Long
            Dim RecID As Long
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@consumption_date", SqlDbType.SmallDateTime, 4)
            cmd.Parameters("@consumption_date").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@TopDate", SqlDbType.SmallDateTime, 4)
            cmd.Parameters("@TopDate").Direction = ParameterDirection.Output
            cmd.CommandText = " select @TopDate = ( select top 1 consumption_date from  ms_admin_energy_consumption order by  consumption_date  desc ) "
            Try
                cmd.Parameters("@consumption_date").Value = consumption_date
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.ExecuteScalar()
                RecID = IIf((cmd.Parameters("@TopDate").Value = cmd.Parameters("@consumption_date").Value), 0, 1)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
            End Try
            Return RecID
        End Function
        Public Shared Function CheckAdminData(ByVal consumption_date As Date) As Long
            Dim RecID As Long
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@consumption_date", SqlDbType.SmallDateTime, 4)
            cmd.Parameters("@consumption_date").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@RecID", SqlDbType.BigInt, 8)
            cmd.Parameters("@RecID").Direction = ParameterDirection.Output
            cmd.CommandText = " select @RecID = count(*) from  ms_admin_energy_consumption where  consumption_date  =  @consumption_date "
            Try
                cmd.Parameters("@consumption_date").Value = consumption_date
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.ExecuteScalar()
                RecID = IIf(IsDBNull(cmd.Parameters("@RecID").Value), 0, cmd.Parameters("@RecID").Value)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
            End Try
            Return RecID
        End Function
        Public Shared Function getAdminInitialValues(ByVal consumption_date As Date) As DataTable
            Dim dtInitialValues As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@consumption_date", SqlDbType.SmallDateTime, 4)
            da.SelectCommand.Parameters("@consumption_date").Direction = ParameterDirection.Input

            da.SelectCommand.CommandText = " select top 1 consumption_date , kptcl_final ,  dg_gen1_final , arc1_final ,  arc2_final ,  arc3_final ,pumphouse_final , Melt_final1, " &
                    " Tube_final1,Mould_final1,Fume_final1, emms_final, colony_final ,colony_final1 ,adminbldg_final ,stnaux_final, rwfgen_final ,pcs_final1,  " &
                    " radkptcl , raddgI , radarc1 , radarc2 , radarc3 ,radpump,radMelt,radTube, radMould, radFume,rademms, radcolony,radcolony1,radadmin,radaux,radrwfgen, radpcs, " &
                    " from ms_admin_energy_consumption order by consumption_date desc "
            Try
                da.SelectCommand.Parameters("@consumption_date").Value = consumption_date
                da.Fill(ds, "InitialValues")
                dtInitialValues = ds.Tables("InitialValues")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtInitialValues
        End Function
        Public Shared Function getAdminUnitsforDay(ByVal consumption_date As Date) As DataTable
            Dim dtUnitsforDay As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@consumption_date", SqlDbType.SmallDateTime, 4)
            da.SelectCommand.Parameters("@consumption_date").Direction = ParameterDirection.Input

            'da.SelectCommand.CommandText = " select consumption_date , kptcl_initial , kptcl_final , dg_gen1_initial , dg_gen1_final , dg_gen2_initial , dg_gen2_final ," & _
            '        " arc1_initial , arc1_final , arc2_initial , arc2_final , arc3_initial , arc3_final , pumphouse_initial , " & _
            '        " pumphouse_final , colony_initial , colony_final , adminbldg_initial , adminbldg_final , " & _
            '        " stnaux_initial , stnaux_final, emms_initial, emms_final, dcos_initial, dcos_final ,  " & _
            '        " radkptcl , raddgI , raddgII , radarc1 , radarc2 , radarc3 , " & _
            '        " radpump , radcolony , radadmn , radaux , rademms , raddcos ,  rwfgen_initial , rwfgen_final , radrwfgen " & _
            '        " , dg_gen3_initial , dg_gen3_final , raddgIII , CheckMeter_initial , CheckMeter_final , radCheckMeter " & _
            '        " from ms_admin_energy_consumption where consumption_date =  @consumption_date "

            da.SelectCommand.CommandText = " select consumption_date , kptcl_initial, kptcl_final ,dg_gen1_initial , dg_gen1_final ,arc1_initial , arc1_final ,arc2_initial ,  arc2_final , arc3_initial , arc3_final  , " &
                    " pumphouse_initial ,pumphouse_final, Melt_initial, Melt_final1, Tube_initial, Tube_final1,Mould_initial, Mould_final1,Fume_initial, Fume_final1, emms_initial, emms_final, colony_initial ,colony_final ," &
                    " colony_initial1 ,colony_final1 ,adminbldg_initial ,adminbldg_final ,stnaux_initial ,stnaux_final, rwfgen_initial ,rwfgen_final ,pcs_initial1, pcs_final1, " &
            " radkptcl , raddgI , radarc1 , radarc2 , radarc3 ,radpump,radMelt,radTube, radMould, radFume,rademms, radcolony,radcolony1,radadmin,radaux,radrwfgen, radpcs,CheckMeter_initial , CheckMeter_final , radCheckMeter " &
                    " from ms_admin_energy_consumption where consumption_date =  @consumption_date "
            Try
                da.SelectCommand.Parameters("@consumption_date").Value = consumption_date
                da.Fill(ds, "UnitsforDay")
                dtUnitsforDay = ds.Tables("UnitsforDay")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtUnitsforDay
        End Function
        Public Shared Function getAdminUnitsforMonth(ByVal consumption_date As Date) As DataTable
            Dim dtUnitsforMonth As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@from_date", SqlDbType.SmallDateTime, 4)
            da.SelectCommand.Parameters("@from_date").Direction = ParameterDirection.Input
            da.SelectCommand.Parameters.Add("@consumption_date", SqlDbType.SmallDateTime, 4)
            da.SelectCommand.Parameters("@consumption_date").Direction = ParameterDirection.Input
            da.SelectCommand.CommandText = " SELECT sum((kptcl_final - kptcl_initial)*radkptcl ) kptcl , sum((dg_gen1_final - dg_gen1_initial)*raddgI ) dg1 ," &
                 " sum((arc1_final-arc1_initial)*radarc1 ) arc1 , sum((arc2_final-arc2_initial)*radarc2 ) arc2 , sum((arc3_final-arc3_initial)*radarc3 ) arc3 , " &
                " sum((pumphouse_final-pumphouse_initial )*radpump) pumphouse ,sum((Melt_final1-Melt_initial )*radMelt) Melt , sum((Tube_final1-Tube_initial )*radTube) Tube , " &
        " sum((Mould_final1-Mould_initial )*radMould) Mould , sum((Fume_final1-Fume_initial )*radFume) Fume , sum((emms_final-emms_initial)*rademms) emms , " &
        " sum((colony_final-colony_initial)*radcolony) colony12 , sum((colony_final1-colony_initial1)*radcolony) colony34 , sum((adminbldg_final-adminbldg_initial)*radadmn) admn , " &
                " sum((adminbldg_final-adminbldg_initial)*radadmn) admn , sum((stnaux_final-stnaux_initial)*radaux) aux , " &
                " sum((stnaux_final-stnaux_initial)*radaux) aux , sum((rwfgen_final-rwfgen_initial)*radrwfgen) rwfgen , " &
                " sum((pcs_final1-pcs_initial1)*radpcs) pcs, sum((CheckMeter_final-CheckMeter_initial)*radCheckMeter) CheckMeter   " &
                " FROM ms_admin_energy_consumption where consumption_date between @from_date and @consumption_date "

            'da.SelectCommand.CommandText = " SELECT sum((kptcl_final - kptcl_initial)*radkptcl ) kptcl , sum((dg_gen1_final - dg_gen1_initial)*raddgI ) dg1 ," & _
            '    " sum((dg_gen2_final - dg_gen2_initial)*raddgII )  dg2 , sum((dg_gen3_final - dg_gen3_initial)*raddgIII )  dg3 ," & _
            '    " sum((arc1_final-arc1_initial)*radarc1 ) arc1 , sum((arc2_final-arc2_initial)*radarc2 ) arc2 , sum((arc3_final-arc3_initial)*radarc3 ) arc3 , " & _
            '    " sum((pumphouse_final-pumphouse_initial )*radpump) pumphouse , sum((colony_final-colony_initial)*radcolony) colony , " & _
            '    " sum((adminbldg_final-adminbldg_initial)*radadmn) admn , sum((stnaux_final-stnaux_initial)*radaux) aux , " & _
            '    " sum((emms_final-emms_initial)*rademms) emms , sum((dcos_final-dcos_initial)*raddcos) cos " & _
            '    " , sum((rwfgen_final-rwfgen_initial)*radrwfgen) rwfgen   " & _
            '    " , sum((CheckMeter_final-CheckMeter_initial)*radCheckMeter) CheckMeter   " & _
            '    " FROM ms_admin_energy_consumption " & _
            '    " where consumption_date between @from_date and @consumption_date "
            Try
                da.SelectCommand.Parameters("@consumption_date").Value = consumption_date
                da.SelectCommand.Parameters("@from_date").Value = consumption_date.AddDays(-(consumption_date.Day) + 1)
                da.Fill(ds, "UnitsforMonth")
                dtUnitsforMonth = ds.Tables("UnitsforMonth")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtUnitsforMonth
        End Function
        Public Shared Function CheckTopAxleData(ByVal consumption_date As Date) As Long
            Dim RecID As Long
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@consumption_date", SqlDbType.SmallDateTime, 4)
            cmd.Parameters("@consumption_date").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@TopDate", SqlDbType.SmallDateTime, 4)
            cmd.Parameters("@TopDate").Direction = ParameterDirection.Output
            cmd.CommandText = " select @TopDate = ( select top 1 consumption_date from  ms_axle_energy_consumption order by consumption_date desc )"
            Try
                cmd.Parameters("@consumption_date").Value = consumption_date
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.ExecuteScalar()
                RecID = IIf((cmd.Parameters("@TopDate").Value = cmd.Parameters("@consumption_date").Value), 0, 1)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
            End Try
            Return RecID
        End Function
        Public Shared Function CheckAxleData(ByVal consumption_date As Date) As Long
            Dim RecID As Long
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@consumption_date", SqlDbType.SmallDateTime, 4)
            cmd.Parameters("@consumption_date").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@RecID", SqlDbType.BigInt, 8)
            cmd.Parameters("@RecID").Direction = ParameterDirection.Output
            cmd.CommandText = " select @RecID = count(*) from  ms_axle_energy_consumption where  consumption_date  =  @consumption_date "
            Try
                cmd.Parameters("@consumption_date").Value = consumption_date
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.ExecuteScalar()
                RecID = IIf(IsDBNull(cmd.Parameters("@RecID").Value), 0, cmd.Parameters("@RecID").Value)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
            End Try
            Return RecID
        End Function
        Public Shared Function getAxleUnitsforDay(ByVal consumption_date As Date) As DataTable
            Dim dtUnitsforDay As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@consumption_date", SqlDbType.SmallDateTime, 4)
            da.SelectCommand.Parameters("@consumption_date").Direction = ParameterDirection.Input
            da.SelectCommand.CommandText = " select consumption_date , essential_initial , essential_final , essential_initial1 , essential_final1 ,   " &
                " nonessential_initial , nonessential_final , nonessential_initial1 , nonessential_final1 ,  " &
                " gfm_initial ,  gm_final , gfm_initial1 , gm_final1 , assembly_initial , assembly_final , " &
                " assembly_initial1 , assembly_final1 , canteen_initial , canteen_final , canteen_initial1 , canteen_final1 ,  " &
                " radaxl , radaxl1 , radaxlN , radaxlN1 , radgm , radgm1 ,  radass , radass1 , radcan ,  radcan1 , lop_initial , lop_final , radlop " &
                " from ms_axle_energy_consumption  where consumption_date =  @consumption_date "
            Try
                da.SelectCommand.Parameters("@consumption_date").Value = consumption_date
                da.Fill(ds, "UnitsforDay")
                dtUnitsforDay = ds.Tables("UnitsforDay")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtUnitsforDay
        End Function
        Public Shared Function getAxleUnitsforMonth(ByVal consumption_date As Date) As DataTable
            Dim dtUnitsforMonth As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@from_date", SqlDbType.SmallDateTime, 4)
            da.SelectCommand.Parameters("@from_date").Direction = ParameterDirection.Input
            da.SelectCommand.Parameters.Add("@consumption_date", SqlDbType.SmallDateTime, 4)
            da.SelectCommand.Parameters("@consumption_date").Direction = ParameterDirection.Input

            da.SelectCommand.CommandText = " SELECT sum((essential_final-essential_initial)*radaxl) + sum((essential_final1 - essential_initial1 )*radaxl1 ) Total_essential , " &
                " sum((nonessential_final-nonessential_initial)*radaxlN ) + sum((nonessential_final1-nonessential_initial1)*radaxlN1) Total_nonessential , " &
                " sum((gm_final-gfm_initial)* radgm ) + sum((gm_final1-gfm_initial1)* radgm1 ) Total_gfm ," &
                " sum((assembly_final-assembly_initial)*radass) + sum((assembly_final1-assembly_initial1)*radass1) Total_assembly , " &
                " sum((canteen_final-canteen_initial)*radcan ) + sum((canteen_final1-canteen_initial1)*radcan1 ) Total_canteen ," &
                " sum((lop_final-lop_initial)*radlop )  Total_lop " &
                " FROM ms_axle_energy_consumption " &
                " where consumption_date  between @from_date and @consumption_date "
            Try
                da.SelectCommand.Parameters("@consumption_date").Value = consumption_date
                da.SelectCommand.Parameters("@from_date").Value = consumption_date.AddDays(-(consumption_date.Day) + 1)
                da.Fill(ds, "UnitsforMonth")
                dtUnitsforMonth = ds.Tables("UnitsforMonth")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtUnitsforMonth
        End Function
        Public Shared Function getAxleInitialValues() As DataTable
            Dim dtInitialValues As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()

            da.SelectCommand.CommandText = " select top 1 consumption_date , essential_final , essential_final1 ,  " &
                 " nonessential_final , nonessential_final1 , gm_final , gm_final1 ,  " &
                 " assembly_final , assembly_final1 , canteen_final , canteen_final1 ," &
                 " radaxl , radaxl1 , radaxlN , radaxlN1 ,  " &
                 " radgm , radgm1 , radass , radass1 , radcan , radcan1 , lop_final ,  radlop  " &
                 " from ms_axle_energy_consumption order by  consumption_date desc "
            Try
                da.Fill(ds, "InitialValues")
                dtInitialValues = ds.Tables("InitialValues")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtInitialValues
        End Function
        Public Shared Function CheckTopWheelData(ByVal consumption_date As Date) As Long
            Dim RecID As Long
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@consumption_date", SqlDbType.SmallDateTime, 4)
            cmd.Parameters("@consumption_date").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@TopDate", SqlDbType.SmallDateTime, 4)
            cmd.Parameters("@TopDate").Direction = ParameterDirection.Output
            cmd.CommandText = " select @TopDate = ( select top 1 consumption_date from  ms_wheel_energy_consumption order by  consumption_date  desc ) "
            Try
                cmd.Parameters("@consumption_date").Value = consumption_date
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.ExecuteScalar()
                RecID = IIf((cmd.Parameters("@TopDate").Value = cmd.Parameters("@consumption_date").Value), 0, 1)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
            End Try
            Return RecID
        End Function
        Public Shared Function CheckWheelData(ByVal consumption_date As Date) As Long
            Dim RecID As Long
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@consumption_date", SqlDbType.SmallDateTime, 4)
            cmd.Parameters("@consumption_date").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@RecID", SqlDbType.BigInt, 8)
            cmd.Parameters("@RecID").Direction = ParameterDirection.Output
            cmd.CommandText = " select @RecID = count(*) from  ms_wheel_energy_consumption where  consumption_date  =  @consumption_date "
            Try
                cmd.Parameters("@consumption_date").Value = consumption_date
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.ExecuteScalar()
                RecID = IIf(IsDBNull(cmd.Parameters("@RecID").Value), 0, cmd.Parameters("@RecID").Value)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
            End Try
            Return RecID
        End Function
        Public Shared Function getWheelInitialValues() As DataTable
            Dim dtInitialValues As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()

            da.SelectCommand.CommandText = " select top 1 consumption_date , wsesstr1_final , wsesstr2_final ,  " &
                 " wsnonesstr3_final , wsnonesstr4_final , tubepretr1_final , tubepretr2_final , " &
                 " mouldpretr1_final , mouldpretr2_final , comptr1_final , comptr2_final , " &
                 " fumetr1_final , fumetr2_final , wsesstr5_final, pumpesstr1_final, pumpesstr2_final, pcsesstr1_final, pcsesstr2_final  " &
                 " radess , radess1 , radNess , radNess1 , radTube , radTube1 , " &
                 " radMld , radMld1 , radCmp , radCmp1 , radFm , radFm1 ,  mouldpretr3_final ,  radMld2, radess2, radpump, radpump1, radpcs, radpcs1 " &
                 " from ms_wheel_energy_consumption order by  consumption_date desc "
            Try
                da.Fill(ds, "InitialValues")
                dtInitialValues = ds.Tables("InitialValues")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtInitialValues
        End Function
        Public Shared Function getWheelUnitsforDay(ByVal consumption_date As Date) As DataTable
            Dim dtUnitsforDay As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@consumption_date", SqlDbType.SmallDateTime, 4)
            da.SelectCommand.Parameters("@consumption_date").Direction = ParameterDirection.Input
            'da.SelectCommand.CommandText = " select consumption_date , wsesstr1_initial , wsesstr1_final , wsesstr2_initial , wsesstr2_final , wsnonesstr3_initial , wsnonesstr3_final , wsnonesstr4_initial ,  " &
            '    " wsnonesstr4_final , tubepretr1_initial , tubepretr1_final , tubepretr2_initial , tubepretr2_final , mouldpretr1_initial , mouldpretr1_final , mouldpretr2_initial , mouldpretr2_final , comptr1_initial , comptr1_final , comptr2_initial , comptr2_final , " &
            '    " fumetr1_initial , fumetr1_final , fumetr2_initial , fumetr2_final , essential_initial , essential_final , nonessential_initial , nonessential_final ,tube_preheat_initial , tube_preheat_final , mould_preheat_initial , mould_preheat_final ,  " &
            '    " compressor_initial , compressor_final , fumex_initial , fumex_final , radess , radess1 , radNess , radNess1 , radTube , radTube1 ,  " &
            '    " radMld , radMld1 , radCmp , radCmp1 , radFm , radFm1,, mouldpretr3_initial , mouldpretr3_final , radMld2,wsesstr5_final , wsesstr5_initial,pcsesstr1_initial,pcsesstr1_final,pcsesstr2_initial,pcsesstr2_final,pumpesstr1_initial,pumpesstr1_final,pumpesstr2_initial,pumpesstr2_final,radess2 ,radpump,radpump1,radpcs,radpcs1  " &
            '    " from ms_wheel_energy_consumption  where consumption_date =  @consumption_date "
            da.SelectCommand.CommandText = " select consumption_date , wsesstr1_initial , wsesstr1_final , wsesstr2_initial , wsesstr2_final , wsnonesstr3_initial , wsnonesstr3_final , wsnonesstr4_initial ,  " &
                " wsnonesstr4_final , tubepretr1_initial , tubepretr1_final , tubepretr2_initial , tubepretr2_final , mouldpretr1_initial , mouldpretr1_final , mouldpretr2_initial , mouldpretr2_final , comptr1_initial , comptr1_final , comptr2_initial , comptr2_final , " &
                " fumetr1_initial , fumetr1_final , fumetr2_initial , fumetr2_final ,  " &
                " radess , radess1 , radNess , radNess1 , radTube , radTube1 ,  " &
                " radMld , radMld1 , radCmp , radCmp1 , radFm , radFm1, mouldpretr3_initial , mouldpretr3_final , radMld2,wsesstr5_initial , wsesstr5_final,pumpesstr1_initial,pumpesstr1_final,pumpesstr2_initial,pumpesstr2_final,pcsesstr1_initial,pcsesstr1_final,pcsesstr2_initial,pcsesstr2_final,radess2 ,radpump,radpump1,radpcs,radpcs1  " &
                " from ms_wheel_energy_consumption  where consumption_date =  @consumption_date "

            Try
                da.SelectCommand.Parameters("@consumption_date").Value = consumption_date
                da.Fill(ds, "UnitsforDay")
                dtUnitsforDay = ds.Tables("UnitsforDay")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtUnitsforDay
        End Function
        Public Shared Function getWheelUnitsforMonth(ByVal consumption_date As Date) As DataTable
            Dim dtUnitsforMonth As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@from_date", SqlDbType.SmallDateTime, 4)
            da.SelectCommand.Parameters("@from_date").Direction = ParameterDirection.Input
            da.SelectCommand.Parameters.Add("@consumption_date", SqlDbType.SmallDateTime, 4)
            da.SelectCommand.Parameters("@consumption_date").Direction = ParameterDirection.Input
            da.SelectCommand.CommandText = " SELECT sum((wsesstr1_final - wsesstr1_initial )*radess ) + sum((wsesstr2_final - wsesstr2_initial )*radess1 ) + sum((wsesstr5_final - wsesstr5_initial )*radess2 ) Total_essential , " &
                " sum((wsnonesstr3_final - wsnonesstr3_initial )*radNess ) + sum((wsnonesstr4_final - wsnonesstr4_initial )*radNess1) Total_nonessential , " &
                " sum((tubepretr1_final - tubepretr1_initial )*radTube ) +  sum((tubepretr2_final - tubepretr2_initial )*radTube1 ) Total_tube , " &
                " sum((mouldpretr1_final - mouldpretr1_initial )*radMld ) + sum((mouldpretr2_final - mouldpretr2_initial )*radMld1)+ sum((mouldpretr3_final - mouldpretr3_initial )*radMld2) Total_mould , " &
                " sum((comptr1_final - comptr1_initial )*radCmp ) + sum((comptr2_final - comptr2_initial )*radCmp1) Total_compressor , " &
                " sum((fumetr1_final - fumetr1_initial )*radFm ) + sum((fumetr2_final - fumetr2_initial )*radFm1 ) Total_fume " &
                " from ms_wheel_energy_consumption  where consumption_date between @from_date and @consumption_date "
            Try
                da.SelectCommand.Parameters("@consumption_date").Value = consumption_date
                da.SelectCommand.Parameters("@from_date").Value = consumption_date.AddDays(-(consumption_date.Day) + 1)
                da.Fill(ds, "UnitsforMonth")
                dtUnitsforMonth = ds.Tables("UnitsforMonth")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtUnitsforMonth
        End Function
        Public Shared Function GetMFValues() As DataTable
            Dim dtMF As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select MF from ms_energy_mf order by MF ; "
            Try
                da.Fill(ds, "MF")
                dtMF = ds.Tables("MF")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtMF
        End Function
        Public Shared Function PowerSupplyType() As DataTable
            Dim dtType As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select RecType , RecName  from ms_PowerSupplyType   "
            Try
                da.Fill(ds, "Type")
                dtType = ds.Tables("Type")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtType
        End Function
        Public Shared Function MaxSentenceID(ByVal App As String, ByVal Group As String) As Long
            Dim SentenceID As Long
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@SentenceID", SqlDbType.BigInt, 8)
            cmd.Parameters("@SentenceID").Direction = ParameterDirection.Output
            cmd.CommandText = " select @SentenceID = max(sentenceId) from ms_vw_Sentence " ' a where a.Application = @App and a.GroupCode = @Group "
            Try
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.ExecuteScalar()
                SentenceID = IIf(IsDBNull(cmd.Parameters("@SentenceID").Value), 0, cmd.Parameters("@SentenceID").Value)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
            End Try
            Return SentenceID
        End Function
        Public Shared Function GetSentenceIDs(ByVal App As String, ByVal Group As String, Optional ByVal sentence As String = "") As DataTable
            Dim dtEquip As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@App", SqlDbType.VarChar, 10)
            da.SelectCommand.Parameters("@App").Direction = ParameterDirection.Input
            da.SelectCommand.Parameters.Add("@Group", SqlDbType.VarChar, 10)
            da.SelectCommand.Parameters("@Group").Direction = ParameterDirection.Input
            If sentence.Trim.Length > 0 Then
                da.SelectCommand.CommandText = " select a.sentenceId , Sentence from ms_vw_Sentence a inner join ( " &
                                " select distinct sentenceid from ms_EquipmentList " &
                                " where  " & sentence.Trim & " ) b on a.sentenceid = b.sentenceid where a.Application = @App and a.GroupCode = @Group order by Sentence"
            Else
                If Group = "ELECTRI" Then
                    da.SelectCommand.CommandText = " select sentenceId , Sentence from ms_vw_Sentence a where a.Application = @App and a.GroupCode in ('EWP','EDG')  order by sentenceId"
                Else
                    da.SelectCommand.CommandText = " select sentenceId , Sentence from ms_vw_Sentence a where a.Application = @App and a.GroupCode = @Group  order by sentenceId"
                End If
            End If

            Try
                da.SelectCommand.Parameters("@App").Value = App.Trim
                da.SelectCommand.Parameters("@Group").Value = Group.Trim
                da.Fill(ds, "Equip")
                dtEquip = ds.Tables("Equip")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtEquip
        End Function
        Public Shared Function GetRestrictionDetails(ByVal RecDate As Date)
            Dim dtFailureDetails As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.SmallDateTime, 4)
            da.SelectCommand.Parameters("@FromDate").Direction = ParameterDirection.Input
            da.SelectCommand.CommandText = " select a.* , b.RecName from  ms_PowerSupplyRestriction a inner join ms_PowerSupplyType b on a.RecType = b.RecType   " &
                " where RecDate = @FromDate "

            Try
                da.SelectCommand.Parameters("@FromDate").Value = RecDate
                da.Fill(ds, "FailureDetails")
                dtFailureDetails = ds.Tables("FailureDetails")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtFailureDetails
        End Function
        Public Shared Function GetSupplyDetails(ByVal FailureDate As Date)
            Dim dtFailureDetails As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.SmallDateTime, 4)
            da.SelectCommand.Parameters("@FromDate").Direction = ParameterDirection.Input
            da.SelectCommand.CommandText = " select SupplyDate , Grid , Bus , FeederNo , FedFrom , RunningDGs , Remarks , SupplyID     from ms_PowerSupplyToRWF   " &
                " where SupplyDate = @FromDate "

            Try
                da.SelectCommand.Parameters("@FromDate").Value = FailureDate
                da.Fill(ds, "FailureDetails")
                dtFailureDetails = ds.Tables("FailureDetails")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtFailureDetails
        End Function
        Public Shared Function GetControlDetails(ByVal FailureDate As Date)
            Dim dtFailureDetails As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.SmallDateTime, 4)
            da.SelectCommand.Parameters("@FromDate").Direction = ParameterDirection.Input
            da.SelectCommand.CommandText = " select ControlDate , TimeOff , TimeOn , RaisingMD , InstantaneousMD , BescomMaxMD , Furnace , CautionedMDAlarm , MDCrossLimit , ControlID    from ms_MaxDemandControlDetails   " &
                " where ControlDate = @FromDate "

            Try
                da.SelectCommand.Parameters("@FromDate").Value = FailureDate
                da.Fill(ds, "FailureDetails")
                dtFailureDetails = ds.Tables("FailureDetails")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtFailureDetails
        End Function
        Public Shared Function GetShopDetails(ByVal FailureDate As Date)
            Dim dtFailureDetails As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.SmallDateTime, 4)
            da.SelectCommand.Parameters("@FromDate").Direction = ParameterDirection.Input
            da.SelectCommand.CommandText = " select RecDate  , Shop , Preventive , BreakDowns , RecID    from ms_ShopStatus   " &
                            " where RecDate = @FromDate "

            Try
                da.SelectCommand.Parameters("@FromDate").Value = FailureDate
                da.Fill(ds, "FailureDetails")
                dtFailureDetails = ds.Tables("FailureDetails")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtFailureDetails
        End Function
        Public Shared Function GetDrierDetails(ByVal FailureDate As Date, ByVal GroupCode As String)
            Dim dtFailureDetails As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.SmallDateTime, 4)
            da.SelectCommand.Parameters("@FromDate").Direction = ParameterDirection.Input
            da.SelectCommand.Parameters.Add("@GroupCode", SqlDbType.VarChar, 10)
            da.SelectCommand.Parameters("@GroupCode").Direction = ParameterDirection.Input
            If GroupCode = "ELECTRI" Then
                da.SelectCommand.CommandText = " select RecDate Date , dbo.ms_fn_EquipmentName(EquipmentID) DrierName , EquipmentID , Status , Remarks , RecID    from ms_CompressorAirDrierStatus   " &
                                                            " a inner join ms_vw_Sentence b on sentenceId = EquipmentID  where RecDate = @FromDate and  b.Application = 'MSS' "
            Else
                da.SelectCommand.CommandText = " select RecDate Date , dbo.ms_fn_EquipmentName(EquipmentID) DrierName , EquipmentID , Status , Remarks , RecID    from ms_CompressorAirDrierStatus   " &
                                            " a inner join ms_vw_Sentence b on sentenceId = EquipmentID  where RecDate = @FromDate and  b.Application = 'MSS' and b.GroupCode = @GroupCode "
            End If
            Try
                da.SelectCommand.Parameters("@FromDate").Value = FailureDate
                da.SelectCommand.Parameters("@GroupCode").Value = GroupCode.Trim
                da.Fill(ds, "FailureDetails")
                dtFailureDetails = ds.Tables("FailureDetails")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtFailureDetails
        End Function
        Public Shared Function GetFailureDetails(ByVal FailureDate As Date)
            Dim dtFailureDetails As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.SmallDateTime, 4)
            da.SelectCommand.Parameters("@FromDate").Direction = ParameterDirection.Input
            da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.SmallDateTime, 4)
            da.SelectCommand.Parameters("@ToDate").Direction = ParameterDirection.Input
            da.SelectCommand.CommandText = " select FromDate , dbo.ms_fn_EquipmentName(EquipmentID) EquipmentName , EquipmentID , Reasons , ActionTaken , Incharge , Remarks , ToDate , FailureID   from ms_EquipmentFailure   " &
                    " where FromDate between @FromDate and @ToDate "

            Try
                da.SelectCommand.Parameters("@FromDate").Value = FailureDate + " 00:00:01"
                da.SelectCommand.Parameters("@ToDate").Value = FailureDate + " 23:59:59"
                da.Fill(ds, "FailureDetails")
                dtFailureDetails = ds.Tables("FailureDetails")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtFailureDetails
        End Function
    End Class
    <Serializable()> Public Class Electrical
#Region "   Fields "
        Private tblPFDetails As DataTable
        Private sBreakDowns, sPreventive, sShop, sStatus, sRunningDGs, sFedFrom, sFeederNo, sBus, sReasons, sActionTaken, sIncharge, sRemarks, sApplication, sGroupCode, sFurnace, sMDCrossLimit, sGrid As String
        Private dateToTime, dateFromTime, dateFromDate, dateToDate, dateRecDate, dateControlDate, dateTimeOff, dateTimeOn, dateSupplyDate As Date
        Private lEquipmentID, lFailureID, lLinkID, lRecID, lControlID, lSupplyID As Long
        Private dtEquipmentList As DataTable
        Private intRecType, intRefInlet, intRefOutlet, intCautionedMDAlarm As Integer
        Private decAirInletTemp, decAirOutletTemp, decDewPoint, decEfficiency, decSuctionPressure, decDeliveryPressure, decRaisingMD, decInstantaneousMD, decBescomMaxMD As Decimal
#End Region
#Region "   Property "
        Property PFDetails() As DataTable
            Get
                Return tblPFDetails
            End Get
            Set(ByVal Value As DataTable)
                tblPFDetails = Value
            End Set
        End Property
        Property BreakDowns() As String
            Get
                Return sBreakDowns
            End Get
            Set(ByVal Value As String)
                sBreakDowns = Value
            End Set
        End Property
        Property Preventive() As String
            Get
                Return sPreventive
            End Get
            Set(ByVal Value As String)
                sPreventive = Value
            End Set
        End Property
        Property Shop() As String
            Get
                Return sShop
            End Get
            Set(ByVal Value As String)
                sShop = Value
            End Set
        End Property
        Property Status() As String
            Get
                Return sStatus
            End Get
            Set(ByVal Value As String)
                sStatus = Value
            End Set
        End Property
        Property RecType() As Integer
            Get
                Return intRecType
            End Get
            Set(ByVal Value As Integer)
                intRecType = Value
            End Set
        End Property
        Property ToTime() As Date
            Get
                Return dateToTime
            End Get
            Set(ByVal Value As Date)
                dateToTime = Value
            End Set
        End Property
        Property FromTime() As Date
            Get
                Return dateFromTime
            End Get
            Set(ByVal Value As Date)
                dateFromTime = Value
            End Set
        End Property
        Property SupplyID() As Long
            Get
                Return lSupplyID
            End Get
            Set(ByVal Value As Long)
                lSupplyID = Value
            End Set
        End Property
        Property RunningDGs() As String
            Get
                Return sRunningDGs
            End Get
            Set(ByVal Value As String)
                sRunningDGs = Value
            End Set
        End Property
        Property FedFrom() As String
            Get
                Return sFedFrom
            End Get
            Set(ByVal Value As String)
                sFedFrom = Value
            End Set
        End Property
        Property FeederNo() As String
            Get
                Return sFeederNo
            End Get
            Set(ByVal Value As String)
                sFeederNo = Value
            End Set
        End Property
        Property Bus() As String
            Get
                Return sBus
            End Get
            Set(ByVal Value As String)
                sBus = Value
            End Set
        End Property
        Property Grid() As String
            Get
                Return sGrid
            End Get
            Set(ByVal Value As String)
                sGrid = Value
            End Set
        End Property
        Property SupplyDate() As Date
            Get
                Return dateSupplyDate
            End Get
            Set(ByVal Value As Date)
                dateSupplyDate = Value
            End Set
        End Property
        Property ControlID() As Long
            Get
                Return lControlID
            End Get
            Set(ByVal Value As Long)
                lControlID = Value
            End Set
        End Property
        Property MDCrossLimit() As String
            Get
                Return sMDCrossLimit
            End Get
            Set(ByVal Value As String)
                sMDCrossLimit = Value
            End Set
        End Property
        Property CautionedMDAlarm() As Integer
            Get
                Return intCautionedMDAlarm
            End Get
            Set(ByVal Value As Integer)
                intCautionedMDAlarm = Value
            End Set
        End Property
        Property Furnace() As String
            Get
                Return sFurnace
            End Get
            Set(ByVal Value As String)
                sFurnace = Value
            End Set
        End Property
        Property BescomMaxMD() As Decimal
            Get
                Return decBescomMaxMD
            End Get
            Set(ByVal Value As Decimal)
                decBescomMaxMD = Value
            End Set
        End Property
        Property InstantaneousMD() As Decimal
            Get
                Return decInstantaneousMD
            End Get
            Set(ByVal Value As Decimal)
                decInstantaneousMD = Value
            End Set
        End Property
        Property RaisingMD() As Decimal
            Get
                Return decRaisingMD
            End Get
            Set(ByVal Value As Decimal)
                decRaisingMD = Value
            End Set
        End Property
        Property TimeOn() As Date
            Get
                Return dateTimeOn
            End Get
            Set(ByVal Value As Date)
                dateTimeOn = Value
            End Set
        End Property
        Property TimeOff() As Date
            Get
                Return dateTimeOff
            End Get
            Set(ByVal Value As Date)
                dateTimeOff = Value
            End Set
        End Property
        Property ControlDate() As Date
            Get
                Return dateControlDate
            End Get
            Set(ByVal Value As Date)
                dateControlDate = Value
            End Set
        End Property
        Property DeliveryPressure() As Decimal
            Get
                Return decDeliveryPressure
            End Get
            Set(ByVal Value As Decimal)
                decDeliveryPressure = Value
            End Set
        End Property
        Property SuctionPressure() As Decimal
            Get
                Return decSuctionPressure
            End Get
            Set(ByVal Value As Decimal)
                decSuctionPressure = Value
            End Set
        End Property
        Property Efficiency() As Decimal
            Get
                Return decEfficiency
            End Get
            Set(ByVal Value As Decimal)
                decEfficiency = Value
            End Set
        End Property
        Property DewPoint() As Decimal
            Get
                Return decDewPoint
            End Get
            Set(ByVal Value As Decimal)
                decDewPoint = Value
            End Set
        End Property
        Property AirOutletTemp() As Decimal
            Get
                Return decAirOutletTemp
            End Get
            Set(ByVal Value As Decimal)
                decAirOutletTemp = Value
            End Set
        End Property
        Property AirInletTemp() As Decimal
            Get
                Return decAirInletTemp
            End Get
            Set(ByVal Value As Decimal)
                decAirInletTemp = Value
            End Set
        End Property
        Property RefOutlet() As Integer
            Get
                Return intRefOutlet
            End Get
            Set(ByVal Value As Integer)
                intRefOutlet = Value
            End Set
        End Property
        Property RefInlet() As Integer
            Get
                Return intRefInlet
            End Get
            Set(ByVal Value As Integer)
                intRefInlet = Value
            End Set
        End Property
        Property RecDate() As Date
            Get
                Return dateRecDate
            End Get
            Set(ByVal Value As Date)
                dateRecDate = Value
            End Set
        End Property
        Property RecID() As Long
            Get
                Return lRecID
            End Get
            Set(ByVal Value As Long)
                lRecID = Value
            End Set
        End Property
        Property LinkID() As Long
            Get
                Return lLinkID
            End Get
            Set(ByVal Value As Long)
                lLinkID = Value
            End Set
        End Property
        Property GroupCode() As String
            Get
                Return sGroupCode
            End Get
            Set(ByVal Value As String)
                sGroupCode = Value
            End Set
        End Property
        Property Application() As String
            Get
                Return sApplication
            End Get
            Set(ByVal Value As String)
                sApplication = Value
            End Set
        End Property
        Property EquipmentList() As DataTable
            Get
                Return dtEquipmentList
            End Get
            Set(ByVal Value As DataTable)
                dtEquipmentList = Value
            End Set
        End Property
        Property FailureID() As Long
            Get
                Return lFailureID
            End Get
            Set(ByVal Value As Long)
                lFailureID = Value
            End Set
        End Property
        Property ToDate() As Date
            Get
                Return dateToDate
            End Get
            Set(ByVal Value As Date)
                dateToDate = Value
            End Set
        End Property
        Property FromDate() As Date
            Get
                Return dateFromDate
            End Get
            Set(ByVal Value As Date)
                dateFromDate = Value
            End Set
        End Property
        Property EquipmentID() As Long
            Get
                Return lEquipmentID
            End Get
            Set(ByVal Value As Long)
                lEquipmentID = Value
            End Set
        End Property
        Property Reasons() As String
            Get
                Return sReasons
            End Get
            Set(ByVal Value As String)
                sReasons = Value
            End Set
        End Property
        Property ActionTaken() As String
            Get
                Return sActionTaken
            End Get
            Set(ByVal Value As String)
                sActionTaken = Value
            End Set
        End Property
        Property Incharge() As String
            Get
                Return sIncharge
            End Get
            Set(ByVal Value As String)
                sIncharge = Value
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
#End Region
#Region "   Methods "
        Private Sub iniVals()
            sBreakDowns = ""
            sPreventive = ""
            sShop = ""
            lSupplyID = 0
            sGrid = ""
            sRunningDGs = ""
            sFedFrom = ""
            sFeederNo = ""
            sBus = ""
            intRefInlet = 0
            intRefOutlet = 0
            decAirOutletTemp = 0.0
            decDewPoint = 0.0
            decEfficiency = 0.0
            decSuctionPressure = 0.0
            decDeliveryPressure = 0.0
            decAirInletTemp = 0.0
            lRecID = 0
            lLinkID = 0
            sGroupCode = ""
            sApplication = ""
            lEquipmentID = 0
            sReasons = ""
            sActionTaken = ""
            sIncharge = ""
            sRemarks = ""
            dateFromDate = "1900-01-01"
            dateToDate = "1900-01-01"
            dateRecDate = "1900-01-01"
            dateSupplyDate = "1900-01-01"
            lFailureID = 0
            dtEquipmentList = Nothing
            sStatus = ""
        End Sub
        Public Sub New()
            iniVals()
        End Sub
        Public Function SavePFDetails() As Boolean
            Dim blnDone As Boolean
            Dim cnt As Int16
            Dim CMD As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                If Me.PFDetails.Rows.Count > 0 Then
                    CMD.Parameters.Add("@ReadingDate", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Input
                    CMD.Parameters.Add("@SlNo", SqlDbType.Int, 4).Direction = ParameterDirection.Input
                    CMD.Parameters.Add("@FirstPF", SqlDbType.Decimal, 5, 2).Direction = ParameterDirection.Input
                    CMD.Parameters.Add("@FirstLoad", SqlDbType.Int, 4).Direction = ParameterDirection.Input
                    CMD.Parameters.Add("@SecondPF", SqlDbType.Decimal, 5, 2).Direction = ParameterDirection.Input
                    CMD.Parameters.Add("@SecondLoad", SqlDbType.Int, 4).Direction = ParameterDirection.Input
                    CMD.Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Direction = ParameterDirection.Input
                    CMD.Parameters.Add("@Cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output

                    For cnt = 0 To Me.PFDetails.Rows.Count - 1
                        CMD.Parameters("@ReadingDate").Value = tblPFDetails.Rows(cnt)(0)
                        CMD.Parameters("@SlNo").Value = CInt(tblPFDetails.Rows(cnt)(1))
                        CMD.Parameters("@FirstPF").Value = IIf(CStr(tblPFDetails.Rows(cnt)(2)).Trim.Length = 0, 0.0, CDec(tblPFDetails.Rows(cnt)(2)))
                        CMD.Parameters("@FirstLoad").Value = IIf(CStr(tblPFDetails.Rows(cnt)(3)).Trim.Length = 0, 0, CInt(tblPFDetails.Rows(cnt)(3)))
                        CMD.Parameters("@SecondPF").Value = IIf(CStr(tblPFDetails.Rows(cnt)(4)).Trim.Length = 0, 0.0, CDec(tblPFDetails.Rows(cnt)(4)))
                        CMD.Parameters("@SecondLoad").Value = IIf(CStr(tblPFDetails.Rows(cnt)(5)).Trim.Length = 0, 0, CInt(tblPFDetails.Rows(cnt)(5)))
                        CMD.Parameters("@Remarks").Value = tblPFDetails.Rows(cnt)(6)

                        CMD.CommandText = " select @Cnt = count(*) from ms_ElecPFReadings where ReadingDate = @ReadingDate and SlNo = @SlNo"

                        If CMD.Connection.State = ConnectionState.Closed Then CMD.Connection.Open()
                        CMD.ExecuteScalar()
                        If IIf(IsDBNull(CMD.Parameters("@Cnt").Value), 0, CMD.Parameters("@Cnt").Value) = 0 Then
                            CMD.CommandText = "insert into ms_ElecPFReadings ( ReadingDate , SlNo ,  FirstPF , FirstLoad ,  SecondPF ,  SecondLoad , Remarks ) " &
                                " values ( @ReadingDate , @SlNo , @FirstPF , @FirstLoad ,  @SecondPF ,  @SecondLoad , @Remarks ) "
                        Else
                            CMD.CommandText = " update ms_ElecPFReadings set FirstPF = @FirstPF , FirstLoad = @FirstLoad ,  " &
                                " SecondPF = @SecondPF ,  SecondLoad = @SecondLoad , Remarks = @Remarks " &
                                " where ReadingDate = @ReadingDate and SlNo = @SlNo  "
                        End If
                        If CMD.ExecuteNonQuery() > 0 Then
                            blnDone = True
                        Else
                            Exit For
                        End If
                    Next
                End If
            Catch exp As Exception
                blnDone = False
                Throw New Exception(exp.Message)
            Finally
                If CMD.Connection.State = ConnectionState.Open Then CMD.Connection.Close()
                CMD.Dispose()
            End Try
            Return blnDone
        End Function
        Public Function SaveEquipmentFailure(Optional ByVal FailureID As Long = 0, Optional ByVal Delete As Boolean = False) As Boolean
            Dim blnDone As Boolean
            Dim CMD As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            CMD.Parameters.Add("@FromDate", SqlDbType.SmallDateTime, 4)
            CMD.Parameters("@FromDate").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@Reasons", SqlDbType.VarChar, 500)
            CMD.Parameters("@Reasons").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@ActionTaken", SqlDbType.VarChar, 500)
            CMD.Parameters("@ActionTaken").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@Incharge", SqlDbType.VarChar, 50)
            CMD.Parameters("@Incharge").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@Remarks", SqlDbType.VarChar, 500)
            CMD.Parameters("@Remarks").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@ToDate", SqlDbType.SmallDateTime, 4)
            CMD.Parameters("@ToDate").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@EquipmentID", SqlDbType.BigInt, 8)
            CMD.Parameters("@EquipmentID").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@FailureID", SqlDbType.BigInt, 8)
            CMD.Parameters("@FailureID").Direction = ParameterDirection.Output

            Try
                CMD.Parameters("@FromDate").Value = Me.FromDate
                CMD.Parameters("@Reasons").Value = Me.Reasons
                CMD.Parameters("@ActionTaken").Value = Me.ActionTaken
                CMD.Parameters("@Incharge").Value = Me.Incharge
                CMD.Parameters("@Remarks").Value = Me.Remarks
                CMD.Parameters("@ToDate").Value = Me.ToDate
                CMD.Parameters("@EquipmentID").Value = Me.EquipmentID
                CMD.Parameters("@FailureID").Value = Me.FailureID
                blnDone = True
            Catch exp As Exception
                blnDone = False
            End Try
            If blnDone = True Then
                blnDone = False
            Else
                CMD.Dispose()
                Throw New Exception("Value assingement error !")
                Exit Function
            End If
            Try
                If CMD.Connection.State = ConnectionState.Closed Then CMD.Connection.Open()
                CMD.Transaction = CMD.Connection.BeginTransaction
                If Delete Then
                    CMD.Parameters("@FailureID").Direction = ParameterDirection.Input
                    EquipmentFailureDelete(CMD, Me.FailureID)
                    blnDone = True
                Else
                    If IIf(IsDBNull(CMD.Parameters("@FailureID").Value), 0, CMD.Parameters("@FailureID").Value) > 0 Then
                        CMD.Parameters("@FailureID").Direction = ParameterDirection.Input
                        EquipmentFailureEdit(CMD, Me.FailureID)
                        blnDone = True
                    Else
                        If IsNothing(Me.EquipmentList) = False Then
                            If Me.EquipmentList.Rows.Count > 0 Then
                                If Me.SaveEquipmentList(CMD, Me.EquipmentList) = False Then Throw New Exception(" Equipment List Saving error")
                            End If
                        End If
                        EquipmentFailureAdd(CMD, Me.FailureID)
                        blnDone = True
                    End If
                End If
            Catch exp As Exception
                Throw New Exception("Saving to ms_EquipmentFailure Tables error : " & exp.Message)
            Finally
                If blnDone = True Then
                    CMD.Transaction.Commit()
                Else
                    CMD.Transaction.Rollback()
                End If
                If CMD.Connection.State = ConnectionState.Open Then CMD.Connection.Close()
                CMD.Dispose()
            End Try
            Return blnDone
        End Function
        Private Sub EquipmentFailureAdd(ByRef CMD As SqlClient.SqlCommand, ByVal FailureID As Long)
            CMD.CommandText = " insert into ms_EquipmentFailure ( FromDate , Reasons , ActionTaken , " &
                    " Incharge , Remarks , ToDate ,  EquipmentID )" &
                    " values (  @FromDate , @Reasons , @ActionTaken ,   " &
                    " @Incharge , @Remarks , @ToDate ,  @EquipmentID  ) "
            Try
                If CMD.ExecuteNonQuery = 0 Then
                    Throw New Exception(" Equipment Failure Saving error")
                Else
                    CMD.CommandText = " select @FailureID = FailureID from ms_EquipmentFailure " &
                        " where FromDate = @FromDate and  Reasons = @Reasons and  ActionTaken = @ActionTaken and " &
                        " Incharge = @Incharge and  Remarks = @Remarks and  ToDate = @ToDate and EquipmentID = @EquipmentID "
                    CMD.ExecuteScalar()
                    Me.FailureID = IIf(IsNothing(CMD.Parameters("@FailureID").Value), 0, CMD.Parameters("@FailureID").Value)
                End If
            Catch exp As Exception
                Throw New Exception(" Insert into ms_EquipmentFailure error " & exp.Message)
            End Try
        End Sub
        Private Sub EquipmentFailureEdit(ByRef CMD As SqlClient.SqlCommand, ByVal FailureID As Long)
            CMD.CommandText = " update ms_EquipmentFailure set FromDate = @FromDate , Reasons = @Reasons , " &
                    " ActionTaken = @ActionTaken , Incharge = @Incharge , Remarks = @Remarks, ToDate = @ToDate  " &
                    " where EquipmentID = @EquipmentID  and FailureID = @FailureID "
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to update Equipment Failure Entry details ")
            Catch exp As Exception
                Throw New Exception(" update of ms_EquipmentFailure error :  " & exp.Message)
            End Try
        End Sub
        Private Sub EquipmentFailureDelete(ByRef CMD As SqlClient.SqlCommand, ByVal FailureID As Long)
            CMD.CommandText = " delete ms_EquipmentFailure  " &
                   " where EquipmentID = @EquipmentID  and FailureID = @FailureID "
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to delete Equipment Failure Entry details ")
            Catch exp As Exception
                Throw New Exception(" delete of ms_EquipmentFailure error :  " & exp.Message)
            End Try
        End Sub

        Public Function ShopStatus(Optional ByVal FailureID As Long = 0, Optional ByVal Delete As Boolean = False) As Boolean
            Dim blnDone As Boolean
            Dim CMD As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            CMD.Parameters.Add("@RecDate", SqlDbType.SmallDateTime, 4)
            CMD.Parameters("@RecDate").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@Shop", SqlDbType.VarChar, 50)
            CMD.Parameters("@Shop").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@Preventive", SqlDbType.VarChar, 250)
            CMD.Parameters("@Preventive").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@BreakDowns", SqlDbType.VarChar, 250)
            CMD.Parameters("@BreakDowns").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@RecID", SqlDbType.BigInt, 8)
            CMD.Parameters("@RecID").Direction = ParameterDirection.Output

            Try
                CMD.Parameters("@RecDate").Value = Me.RecDate
                CMD.Parameters("@Shop").Value = Me.Shop
                CMD.Parameters("@Preventive").Value = Me.Preventive
                CMD.Parameters("@BreakDowns").Value = Me.BreakDowns
                CMD.Parameters("@RecID").Value = Me.RecID
                blnDone = True
            Catch exp As Exception
                blnDone = False
            End Try
            If blnDone = True Then
                blnDone = False
            Else
                CMD.Dispose()
                Throw New Exception("Value assingement error !")
                Exit Function
            End If
            Try
                If CMD.Connection.State = ConnectionState.Closed Then CMD.Connection.Open()
                CMD.Transaction = CMD.Connection.BeginTransaction
                If Delete Then
                    CMD.Parameters("@RecID").Direction = ParameterDirection.Input
                    ShopStatusDelete(CMD, Me.RecID)
                    blnDone = True
                Else
                    If IIf(IsDBNull(CMD.Parameters("@RecID").Value), 0, CMD.Parameters("@RecID").Value) > 0 Then
                        CMD.Parameters("@RecID").Direction = ParameterDirection.Input
                        ShopStatusEdit(CMD, Me.RecID)
                        blnDone = True
                    Else
                        ShopStatusAdd(CMD, Me.FailureID)
                        blnDone = True
                    End If
                End If
            Catch exp As Exception
                Throw New Exception("Saving to ms_CompressorAirDrierStatus Tables error : " & exp.Message)
            Finally
                If blnDone = True Then
                    CMD.Transaction.Commit()
                Else
                    CMD.Transaction.Rollback()
                End If
                If CMD.Connection.State = ConnectionState.Open Then CMD.Connection.Close()
                CMD.Dispose()
            End Try
            Return blnDone
        End Function
        Private Sub ShopStatusAdd(ByRef CMD As SqlClient.SqlCommand, ByVal FailureID As Long)
            CMD.CommandText = " insert into ms_ShopStatus ( RecDate , Shop , Preventive ,  BreakDowns )" &
                    " values (  @RecDate ,  @Shop , @Preventive , @BreakDowns  ) "
            Try
                If CMD.ExecuteNonQuery = 0 Then
                    Throw New Exception(" Shop Status Saving error")
                Else
                    CMD.CommandText = " select @RecID = RecID from ms_ShopStatus " &
                        " where  Shop = @Shop and  Preventive = @Preventive  and BreakDowns = @BreakDowns and RecDate = @RecDate "
                    CMD.ExecuteScalar()
                    Me.RecID = IIf(IsNothing(CMD.Parameters("@RecID").Value), 0, CMD.Parameters("@RecID").Value)
                End If
            Catch exp As Exception
                Throw New Exception(" Insert into ms_ShopStatus error " & exp.Message)
            End Try
        End Sub
        Private Sub ShopStatusEdit(ByRef CMD As SqlClient.SqlCommand, ByVal FailureID As Long)
            CMD.CommandText = " update ms_ShopStatus set  Preventive = @Preventive , BreakDowns = @BreakDowns " &
                    " where Shop = @Shop  and RecID = @RecID and RecDate = @RecDate "
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to update Shop Status Entry  ")
            Catch exp As Exception
                Throw New Exception(" update of ms_ShopStatus error :  " & exp.Message)
            End Try
        End Sub
        Private Sub ShopStatusDelete(ByRef CMD As SqlClient.SqlCommand, ByVal RecID As Long)
            CMD.CommandText = " delete ms_ShopStatus  " &
                   " where Shop = @Shop  and RecID = @RecID and RecDate = @RecDate "
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to delete Shop Status Entry details ")
            Catch exp As Exception
                Throw New Exception(" delete of ms_ShopStatus error :  " & exp.Message)
            End Try
        End Sub
        Public Function SaveCompressorAirDrierStatus(Optional ByVal FailureID As Long = 0, Optional ByVal Delete As Boolean = False) As Boolean
            Dim blnDone As Boolean
            Dim CMD As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            CMD.Parameters.Add("@RecDate", SqlDbType.SmallDateTime, 4)
            CMD.Parameters("@RecDate").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@EquipmentID", SqlDbType.BigInt, 8)
            CMD.Parameters("@EquipmentID").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@Status", SqlDbType.VarChar, 50)
            CMD.Parameters("@Status").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@Remarks", SqlDbType.VarChar, 250)
            CMD.Parameters("@Remarks").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@RecID", SqlDbType.BigInt, 8)
            CMD.Parameters("@RecID").Direction = ParameterDirection.Output

            Try
                CMD.Parameters("@RecDate").Value = Me.RecDate
                CMD.Parameters("@EquipmentID").Value = Me.EquipmentID
                CMD.Parameters("@Status").Value = Me.Status
                CMD.Parameters("@Remarks").Value = Me.Remarks
                CMD.Parameters("@RecID").Value = Me.RecID
                blnDone = True
            Catch exp As Exception
                blnDone = False
            End Try
            If blnDone = True Then
                blnDone = False
            Else
                CMD.Dispose()
                Throw New Exception("Value assingement error !")
                Exit Function
            End If
            Try
                If CMD.Connection.State = ConnectionState.Closed Then CMD.Connection.Open()
                CMD.Transaction = CMD.Connection.BeginTransaction
                If Delete Then
                    CMD.Parameters("@RecID").Direction = ParameterDirection.Input
                    CompressorAirDrierStatusDelete(CMD, Me.RecID)
                    blnDone = True
                Else
                    If IIf(IsDBNull(CMD.Parameters("@RecID").Value), 0, CMD.Parameters("@RecID").Value) > 0 Then
                        CMD.Parameters("@RecID").Direction = ParameterDirection.Input
                        CompressorAirDrierStatusEdit(CMD, Me.RecID)
                        blnDone = True
                    Else
                        CompressorAirDrierStatusAdd(CMD, Me.FailureID)
                        blnDone = True
                    End If
                End If
            Catch exp As Exception
                Throw New Exception("Saving to ms_CompressorAirDrierStatus Tables error : " & exp.Message)
            Finally
                If blnDone = True Then
                    CMD.Transaction.Commit()
                Else
                    CMD.Transaction.Rollback()
                End If
                If CMD.Connection.State = ConnectionState.Open Then CMD.Connection.Close()
                CMD.Dispose()
            End Try
            Return blnDone
        End Function
        Private Sub CompressorAirDrierStatusAdd(ByRef CMD As SqlClient.SqlCommand, ByVal FailureID As Long)
            CMD.CommandText = " insert into ms_CompressorAirDrierStatus ( RecDate , Status , Remarks ,  EquipmentID )" &
                    " values (  @RecDate ,  @Status , @Remarks , @EquipmentID  ) "
            Try
                If CMD.ExecuteNonQuery = 0 Then
                    Throw New Exception(" Compressor AirDrier Details Saving error")
                Else
                    CMD.CommandText = " select @RecID = RecID from ms_CompressorAirDrierStatus " &
                        " where  Status = @Status and  Remarks = @Remarks  and EquipmentID = @EquipmentID and RecDate = @RecDate "
                    CMD.ExecuteScalar()
                    Me.RecID = IIf(IsNothing(CMD.Parameters("@RecID").Value), 0, CMD.Parameters("@RecID").Value)
                End If
            Catch exp As Exception
                Throw New Exception(" Insert into ms_CompressorAirDrierStatus error " & exp.Message)
            End Try
        End Sub
        Private Sub CompressorAirDrierStatusEdit(ByRef CMD As SqlClient.SqlCommand, ByVal FailureID As Long)
            CMD.CommandText = " update ms_CompressorAirDrierStatus set  Status = @Status , Remarks = @Remarks " &
                    " where EquipmentID = @EquipmentID  and RecID = @RecID and RecDate = @RecDate "
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to update Compressor AirDrier Status Entry  ")
            Catch exp As Exception
                Throw New Exception(" update of ms_CompressorAirDrierStatus error :  " & exp.Message)
            End Try
        End Sub
        Private Sub CompressorAirDrierStatusDelete(ByRef CMD As SqlClient.SqlCommand, ByVal RecID As Long)
            CMD.CommandText = " delete ms_CompressorAirDrierStatus  " &
                   " where EquipmentID = @EquipmentID  and RecID = @RecID "
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to delete Compressor AirDrier Status Entry details ")
            Catch exp As Exception
                Throw New Exception(" delete of ms_CompressorAirDrierStatus error :  " & exp.Message)
            End Try
        End Sub
        Public Function SaveCompressorAirDrierDetails(Optional ByVal FailureID As Long = 0, Optional ByVal Delete As Boolean = False) As Boolean
            Dim blnDone As Boolean
            Dim CMD As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            CMD.Parameters.Add("@RecDate", SqlDbType.SmallDateTime, 4)
            CMD.Parameters("@RecDate").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@EquipmentID", SqlDbType.BigInt, 8)
            CMD.Parameters("@EquipmentID").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@AirInletTemp", SqlDbType.Decimal, 10, 2)
            CMD.Parameters("@AirInletTemp").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@AirOutletTemp", SqlDbType.Decimal, 10, 2)
            CMD.Parameters("@AirOutletTemp").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@RefInlet", SqlDbType.Int, 4)
            CMD.Parameters("@RefInlet").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@RefOutlet", SqlDbType.Int, 4)
            CMD.Parameters("@RefOutlet").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@DewPoint", SqlDbType.Decimal, 10, 2)
            CMD.Parameters("@DewPoint").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@Efficiency", SqlDbType.Decimal, 10, 2)
            CMD.Parameters("@Efficiency").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@SuctionPressure", SqlDbType.Decimal, 10, 2)
            CMD.Parameters("@SuctionPressure").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@DeliveryPressure", SqlDbType.Decimal, 10, 2)
            CMD.Parameters("@DeliveryPressure").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@Remarks", SqlDbType.VarChar, 500)
            CMD.Parameters("@Remarks").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@RecID", SqlDbType.BigInt, 8)
            CMD.Parameters("@RecID").Direction = ParameterDirection.Output

            Try
                CMD.Parameters("@RecDate").Value = Me.RecDate
                CMD.Parameters("@EquipmentID").Value = Me.EquipmentID
                CMD.Parameters("@AirInletTemp").Value = Me.AirInletTemp
                CMD.Parameters("@AirOutletTemp").Value = Me.AirOutletTemp
                CMD.Parameters("@RefInlet").Value = Me.RefInlet
                CMD.Parameters("@RefOutlet").Value = Me.RefOutlet
                CMD.Parameters("@DewPoint").Value = Me.DewPoint
                CMD.Parameters("@Efficiency").Value = Me.Efficiency
                CMD.Parameters("@SuctionPressure").Value = Me.SuctionPressure
                CMD.Parameters("@DeliveryPressure").Value = Me.DeliveryPressure
                CMD.Parameters("@Remarks").Value = Me.Remarks
                CMD.Parameters("@RecID").Value = Me.RecID
                blnDone = True
            Catch exp As Exception
                blnDone = False
            End Try
            If blnDone = True Then
                blnDone = False
            Else
                CMD.Dispose()
                Throw New Exception("Value assingement error !")
                Exit Function
            End If
            Try
                If CMD.Connection.State = ConnectionState.Closed Then CMD.Connection.Open()
                CMD.Transaction = CMD.Connection.BeginTransaction
                If Delete Then
                    CMD.Parameters("@RecID").Direction = ParameterDirection.Input
                    CompressorAirDrierDetailsDelete(CMD, Me.RecID)
                    blnDone = True
                Else
                    If IIf(IsDBNull(CMD.Parameters("@RecID").Value), 0, CMD.Parameters("@RecID").Value) > 0 Then
                        CMD.Parameters("@RecID").Direction = ParameterDirection.Input
                        CompressorAirDrierDetailsEdit(CMD, Me.RecID)
                        blnDone = True
                    Else
                        If IsNothing(Me.EquipmentList) = False Then
                            If Me.EquipmentList.Rows.Count > 0 Then
                                If Me.SaveEquipmentList(CMD, Me.EquipmentList) = False Then Throw New Exception(" Equipment List Saving error")
                            End If
                        End If
                        CompressorAirDrierDetailsAdd(CMD, Me.FailureID)
                        blnDone = True
                    End If
                End If
            Catch exp As Exception
                Throw New Exception("Saving to ms_CompressorAirDrierDetails Tables error : " & exp.Message)
            Finally
                If blnDone = True Then
                    CMD.Transaction.Commit()
                Else
                    CMD.Transaction.Rollback()
                End If
                If CMD.Connection.State = ConnectionState.Open Then CMD.Connection.Close()
                CMD.Dispose()
            End Try
            Return blnDone
        End Function
        Private Sub CompressorAirDrierDetailsAdd(ByRef CMD As SqlClient.SqlCommand, ByVal FailureID As Long)
            CMD.CommandText = " insert into ms_CompressorAirDrierDetails ( RecDate , AirInletTemp , AirOutletTemp , RefInlet , " &
                    " RefOutlet , DewPoint , Efficiency , SuctionPressure ,  DeliveryPressure , Remarks ,  EquipmentID )" &
                    " values (  @RecDate , @AirInletTemp , @AirOutletTemp , @RefInlet ,   " &
                    " @RefOutlet , @DewPoint , @Efficiency , @SuctionPressure ,  @DeliveryPressure , @Remarks , @EquipmentID  ) "
            Try
                If CMD.ExecuteNonQuery = 0 Then
                    Throw New Exception(" Compressor AirDrier Details Saving error")
                Else
                    CMD.CommandText = " select @RecID = RecID from ms_CompressorAirDrierDetails " &
                        " where AirInletTemp = @AirInletTemp and AirOutletTemp = @AirOutletTemp and RefInlet = @RefInlet and  RefOutlet = @RefOutlet and " &
                        " DewPoint = @DewPoint and  Efficiency = @Efficiency and SuctionPressure = @SuctionPressure and  DeliveryPressure = @DeliveryPressure and  Remarks = @Remarks  and EquipmentID = @EquipmentID "
                    CMD.ExecuteScalar()
                    Me.RecID = IIf(IsNothing(CMD.Parameters("@RecID").Value), 0, CMD.Parameters("@RecID").Value)
                End If
            Catch exp As Exception
                Throw New Exception(" Insert into ms_CompressorAirDrierDetails error " & exp.Message)
            End Try
        End Sub
        Private Sub CompressorAirDrierDetailsEdit(ByRef CMD As SqlClient.SqlCommand, ByVal FailureID As Long)
            CMD.CommandText = " update ms_CompressorAirDrierDetails set  AirInletTemp = @AirInletTemp , AirOutletTemp = @AirOutletTemp , RefInlet = @RefInlet , RefOutlet = @RefOutlet , " &
                    " DewPoint = @DewPoint ,  Efficiency = @Efficiency , SuctionPressure = @SuctionPressure , DeliveryPressure = @DeliveryPressure , Remarks = @Remarks " &
                    " where EquipmentID = @EquipmentID  and RecID = @RecID and RecDate = @RecDate "
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to update Compressor AirDrier Details Entry  ")
            Catch exp As Exception
                Throw New Exception(" update of ms_CompressorAirDrierDetails error :  " & exp.Message)
            End Try
        End Sub
        Private Sub CompressorAirDrierDetailsDelete(ByRef CMD As SqlClient.SqlCommand, ByVal RecID As Long)
            CMD.CommandText = " delete ms_CompressorAirDrierDetails  " &
                   " where EquipmentID = @EquipmentID  and RecID = @RecID "
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to delete Compressor AirDrier Details Entry details ")
            Catch exp As Exception
                Throw New Exception(" delete of ms_CompressorAirDrierDetails error :  " & exp.Message)
            End Try
        End Sub
        Public Function SaveEquipmentList(ByRef CMD As SqlClient.SqlCommand, ByVal dtEquipmentList As DataTable, Optional ByVal Unit As String = "") As Long
            Dim blnDone As Boolean
            Dim cnt As Int16
            CMD.Parameters.Add("@Application", SqlDbType.VarChar, 10)
            CMD.Parameters("@Application").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@GroupCode", SqlDbType.VarChar, 10)
            CMD.Parameters("@GroupCode").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@sentenceId", SqlDbType.BigInt, 8)
            CMD.Parameters("@sentenceId").Direction = ParameterDirection.Input
            Try
                CMD.Parameters("@Application").Value = Me.Application
                CMD.Parameters("@GroupCode").Value = Me.GroupCode
                CMD.Parameters("@sentenceId").Value = dtEquipmentList.Rows(0)(2)
                If Unit.Trim.Length > 0 Then
                    CMD.Parameters.Add("@Unit", SqlDbType.VarChar, 50).Value = Unit.Trim
                    CMD.CommandText = " insert into ms_EquipmentLink ( sentenceID , Application	, GroupCode , Unit ) values ( @sentenceID , @Application , @GroupCode , @Unit ) "
                Else
                    CMD.CommandText = " insert into ms_EquipmentLink ( sentenceID , Application	, GroupCode ) values ( @sentenceID , @Application , @GroupCode  ) "
                End If

                If CMD.ExecuteNonQuery > 0 Then
                    CMD.Parameters.Add("@Word", SqlDbType.VarChar, 50)
                    CMD.Parameters("@Word").Direction = ParameterDirection.Input
                    CMD.Parameters.Add("@WordSeqID", SqlDbType.Int, 4)
                    CMD.Parameters("@WordSeqID").Direction = ParameterDirection.Input
                    If Me.EquipmentList.Rows.Count > 0 Then
                        For cnt = 0 To Me.EquipmentList.Rows.Count - 1
                            blnDone = False
                            CMD.Parameters("@Word").Value = dtEquipmentList.Rows(cnt)(0)
                            CMD.Parameters("@WordSeqID").Value = dtEquipmentList.Rows(cnt)(1)
                            CMD.Parameters("@sentenceId").Value = dtEquipmentList.Rows(cnt)(2)
                            CMD.CommandText = " insert into ms_EquipmentList (  Word , WordSeqID , sentenceId )" &
                            " values (  @Word , @WordSeqID , @sentenceId )"
                            If CMD.ExecuteNonQuery() > 0 Then
                                blnDone = True
                            Else
                                Exit For
                            End If
                        Next
                    End If
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
                blnDone = False
            End Try
            Return IIf(IsDBNull(CMD.Parameters("@sentenceId").Value), 0, CMD.Parameters("@sentenceId").Value)
        End Function
        Public Function SaveMaxDemandControlDetails(Optional ByVal ControlID As Long = 0, Optional ByVal Delete As Boolean = False) As Boolean
            Dim blnDone As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@ControlDate", SqlDbType.SmallDateTime, 4)
            cmd.Parameters("@ControlDate").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@TimeOff", SqlDbType.SmallDateTime, 4)
            cmd.Parameters("@TimeOff").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@TimeOn", SqlDbType.SmallDateTime, 4)
            cmd.Parameters("@TimeOn").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@RaisingMD", SqlDbType.Decimal, 10, 3)
            cmd.Parameters("@RaisingMD").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@InstantaneousMD", SqlDbType.Decimal, 10, 3)
            cmd.Parameters("@InstantaneousMD").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@BescomMaxMD", SqlDbType.Decimal, 10, 4)
            cmd.Parameters("@BescomMaxMD").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@Furnace", SqlDbType.VarChar, 50)
            cmd.Parameters("@Furnace").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@CautionedMDAlarm", SqlDbType.Int, 4)
            cmd.Parameters("@CautionedMDAlarm").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@ControlID", SqlDbType.BigInt, 8)
            cmd.Parameters("@ControlID").Direction = ParameterDirection.Output
            Try
                cmd.Parameters("@ControlDate").Value = Me.ControlDate
                cmd.Parameters("@TimeOff").Value = Me.TimeOff
                cmd.Parameters("@TimeOn").Value = Me.TimeOn
                cmd.Parameters("@RaisingMD").Value = Me.RaisingMD
                cmd.Parameters("@InstantaneousMD").Value = Me.InstantaneousMD
                cmd.Parameters("@BescomMaxMD").Value = Me.BescomMaxMD
                cmd.Parameters("@Furnace").Value = Me.Furnace
                cmd.Parameters("@CautionedMDAlarm").Value = Me.CautionedMDAlarm
                cmd.Parameters("@ControlID").Value = Me.ControlID
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
                If ControlID > 0 Then
                    cmd.Parameters("@ControlID").Direction = ParameterDirection.Input
                    If Delete = False Then
                        MaxDemandControlDetailsEdit(cmd)
                        blnDone = True
                    Else
                        MaxDemandControlDetailsDelete(cmd)
                        blnDone = True
                    End If
                Else
                    If Delete = False Then MaxDemandControlDetailsAdd(cmd)
                    blnDone = True
                End If
            Catch exp As Exception
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
        Private Sub MaxDemandControlDetailsAdd(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " insert into dbo.ms_MaxDemandControlDetails " &
                            " ( ControlDate , TimeOff , TimeOn , RaisingMD , InstantaneousMD , BescomMaxMD ,   " &
                            " Furnace , CautionedMDAlarm  ) " &
                            " values  ( @ControlDate , @TimeOff , @TimeOn , @RaisingMD , @InstantaneousMD , @BescomMaxMD , " &
                            " @Furnace , @CautionedMDAlarm )"
            Try
                If CMD.ExecuteNonQuery = 0 Then
                    Throw New Exception(" MaxDemand ControlDetails error")
                Else
                    CMD.CommandText = " select  @ControlID = ControlID from ms_MaxDemandControlDetails " &
                        " where ControlDate = @ControlDate and TimeOff = @TimeOff and  TimeOn = @TimeOn and  RaisingMD = @RaisingMD and InstantaneousMD = @InstantaneousMD  " &
                        " and  BescomMaxMD = @BescomMaxMD and Furnace = @Furnace and CautionedMDAlarm = @CautionedMDAlarm  "
                    CMD.ExecuteScalar()
                    Me.ControlID = IIf(IsNothing(CMD.Parameters("@ControlID").Value), 0, CMD.Parameters("@ControlID").Value)
                End If
            Catch exp As Exception
                Throw New Exception(" Insert into ms_MaxDemandControlDetails error " & exp.Message)
            End Try
        End Sub
        Private Sub MaxDemandControlDetailsEdit(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " update ms_MaxDemandControlDetails set  TimeOff = @TimeOff ,  TimeOn = @TimeOn ,  RaisingMD = @RaisingMD , InstantaneousMD = @InstantaneousMD , " &
                              "  BescomMaxMD = @BescomMaxMD , Furnace = @Furnace , CautionedMDAlarm = @CautionedMDAlarm   where ControlDate = @ControlDate and  ControlID = @ControlID "
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to update MaxDemand Control Details ")
            Catch exp As Exception
                Throw New Exception(" update of ms_MaxDemandControlDetails error :  " & exp.Message)
            End Try
        End Sub
        Private Sub MaxDemandControlDetailsDelete(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " delete  ms_MaxDemandControlDetails  where ControlID = @ControlID"
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to delete MaxDemand Control Details ")
            Catch exp As Exception
                Throw New Exception(" delete of ms_MaxDemandControlDetails error :  " & exp.Message)
            End Try
        End Sub
        Public Function SavePowerSupplyToRWF(Optional ByVal SupplyID As Long = 0, Optional ByVal Delete As Boolean = False) As Boolean
            Dim blnDone As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@SupplyDate", SqlDbType.SmallDateTime, 4)
            cmd.Parameters("@SupplyDate").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@Grid", SqlDbType.VarChar, 250)
            cmd.Parameters("@Grid").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@Bus", SqlDbType.VarChar, 250)
            cmd.Parameters("@Bus").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@FeederNo", SqlDbType.VarChar, 250)
            cmd.Parameters("@FeederNo").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@FedFrom", SqlDbType.VarChar, 250)
            cmd.Parameters("@FedFrom").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@RunningDGs", SqlDbType.VarChar, 250)
            cmd.Parameters("@RunningDGs").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 250)
            cmd.Parameters("@Remarks").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@SupplyID", SqlDbType.BigInt, 8)
            cmd.Parameters("@SupplyID").Direction = ParameterDirection.Output
            Try
                cmd.Parameters("@SupplyDate").Value = Me.SupplyDate
                cmd.Parameters("@Grid").Value = Me.Grid
                cmd.Parameters("@Bus").Value = Me.Bus
                cmd.Parameters("@FeederNo").Value = Me.FeederNo
                cmd.Parameters("@FedFrom").Value = Me.FedFrom
                cmd.Parameters("@RunningDGs").Value = Me.RunningDGs
                cmd.Parameters("@Remarks").Value = Me.Remarks
                cmd.Parameters("@SupplyID").Value = Me.SupplyID
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
                'cmd.CommandText = " select @YWid = YWid from mm_YardWheelAccount where AreaNo = @AreaNo and WheelCategory = @WheelCategory and  LineNumber = @LineNumber and  WheelStatus  = @WheelStatus "
                If SupplyID > 0 Then
                    cmd.Parameters("@SupplyID").Direction = ParameterDirection.Input
                    If Delete = False Then
                        PowerSupplyToRWFEdit(cmd)
                        blnDone = True
                    Else
                        PowerSupplyToRWFDelete(cmd)
                        blnDone = True
                    End If
                Else
                    If Delete = False Then PowerSupplyToRWFAdd(cmd)
                    blnDone = True
                End If
            Catch exp As Exception
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
        Private Sub PowerSupplyToRWFAdd(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " insert into dbo.ms_PowerSupplyToRWF " &
                            " ( SupplyDate ,  Grid , Bus , FeederNo , FedFrom ,   " &
                            " RunningDGs , Remarks  ) " &
                            " values  ( @SupplyDate , @Grid , @Bus , @FeederNo , @FedFrom  , " &
                            " @RunningDGs , @Remarks  )"
            Try
                If CMD.ExecuteNonQuery = 0 Then
                    Throw New Exception(" PowerSupply To RWF error")
                Else
                    CMD.CommandText = " select  @SupplyID = SupplyID from ms_PowerSupplyToRWF " &
                        " where SupplyDate = @SupplyDate and Grid = @Grid and  Bus = @Bus and  FeederNo = @FeederNo and FedFrom = @FedFrom  " &
                        " and  RunningDGs = @RunningDGs and Remarks = @Remarks "
                    CMD.ExecuteScalar()
                    Me.SupplyID = IIf(IsNothing(CMD.Parameters("@SupplyID").Value), 0, CMD.Parameters("@SupplyID").Value)
                End If
            Catch exp As Exception
                Throw New Exception(" Insert into ms_PowerSupplyToRWF error " & exp.Message)
            End Try
        End Sub
        Private Sub PowerSupplyToRWFEdit(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " update ms_PowerSupplyToRWF set   Grid = @Grid , Bus = @Bus ,  FeederNo = @FeederNo , FedFrom = @FedFrom , " &
                              "  RunningDGs = @RunningDGs , Remarks = @Remarks where SupplyDate = @SupplyDate and  SupplyID = @SupplyID "
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to update PowerSupply To RWF Details ")
            Catch exp As Exception
                Throw New Exception(" update of ms_PowerSupplyToRWF error :  " & exp.Message)
            End Try
        End Sub
        Private Sub PowerSupplyToRWFDelete(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " delete  ms_PowerSupplyToRWF  where SupplyID = @SupplyID"
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to delete PowerSupply To RWF Details ")
            Catch exp As Exception
                Throw New Exception(" delete of ms_PowerSupplyToRWF error :  " & exp.Message)
            End Try
        End Sub
        Public Function SavePowerSupplyRestriction(Optional ByVal SupplyID As Long = 0, Optional ByVal Delete As Boolean = False) As Boolean
            Dim blnDone As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@RecDate", SqlDbType.SmallDateTime, 4)
            cmd.Parameters("@RecDate").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@FromTime", SqlDbType.SmallDateTime, 4)
            cmd.Parameters("@FromTime").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@ToTime", SqlDbType.SmallDateTime, 4)
            cmd.Parameters("@ToTime").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@RecType", SqlDbType.Int, 4)
            cmd.Parameters("@RecType").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 250)
            cmd.Parameters("@Remarks").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@RecID", SqlDbType.BigInt, 8)
            cmd.Parameters("@RecID").Direction = ParameterDirection.Output
            Try
                cmd.Parameters("@RecDate").Value = Me.RecDate
                cmd.Parameters("@FromTime").Value = Me.FromTime
                cmd.Parameters("@ToTime").Value = Me.ToTime
                cmd.Parameters("@RecType").Value = Me.RecType
                cmd.Parameters("@Remarks").Value = Me.Remarks
                cmd.Parameters("@RecID").Value = Me.RecID
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
                'cmd.CommandText = " select @YWid = YWid from mm_YardWheelAccount where AreaNo = @AreaNo and WheelCategory = @WheelCategory and  LineNumber = @LineNumber and  WheelStatus  = @WheelStatus "
                If SupplyID > 0 Then
                    cmd.Parameters("@RecID").Direction = ParameterDirection.Input
                    If Delete = False Then
                        PowerSupplyRestrictionEdit(cmd)
                        blnDone = True
                    Else
                        PowerSupplyRestrictionDelete(cmd)
                        blnDone = True
                    End If
                Else
                    If Delete = False Then PowerSupplyRestrictionAdd(cmd)
                    blnDone = True
                End If
            Catch exp As Exception
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
        Private Sub PowerSupplyRestrictionAdd(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " insert into dbo.ms_PowerSupplyRestriction " &
                            " ( FromTime , ToTime , Remarks ,   " &
                            " RecDate ,  RecType  ) " &
                            " values  ( @FromTime , @ToTime , @Remarks , " &
                            " @RecDate ,  @RecType  )"
            Try
                If CMD.ExecuteNonQuery = 0 Then
                    Throw New Exception(" PowerSupply To RWF error")
                Else
                    CMD.CommandText = " select  @RecID = RecID from ms_PowerSupplyRestriction " &
                        " where FromTime = @FromTime and ToTime = @ToTime and Remarks = @Remarks and   RecDate = @RecDate  " &
                        " and  RecType = @RecType "
                    CMD.ExecuteScalar()
                    Me.RecID = IIf(IsNothing(CMD.Parameters("@RecID").Value), 0, CMD.Parameters("@RecID").Value)
                End If
            Catch exp As Exception
                Throw New Exception(" Insert into ms_PowerSupplyRestriction error " & exp.Message)
            End Try
        End Sub
        Private Sub PowerSupplyRestrictionEdit(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " update ms_PowerSupplyRestriction set   FromTime = @FromTime , ToTime = @ToTime , Remarks = @Remarks  " &
                              "   where RecDate = @RecDate and RecType = @RecType and  RecID = @RecID "
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to update PowerSupply Restriction Details ")
            Catch exp As Exception
                Throw New Exception(" update of ms_PowerSupplyRestriction error :  " & exp.Message)
            End Try
        End Sub
        Private Sub PowerSupplyRestrictionDelete(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " delete  ms_PowerSupplyRestriction  where RecID = @RecID"
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to delete PowerSupply Restriction Details ")
            Catch exp As Exception
                Throw New Exception(" delete of ms_PowerSupplyRestriction error :  " & exp.Message)
            End Try
        End Sub
        'Public Function saveShopWise(ByVal consumption_date As Date, ByVal KPTCL As String, ByVal Generated As String, ByVal Arc1 As String, ByVal Arc2 As String, ByVal Arc3 As String, ByVal Pump As String, ByVal Colony As String, ByVal Admin As String, ByVal Aux As String, ByVal Emms As String, ByVal Dcos As String, ByVal RwfgenTxt As String, ByVal AxelEssential As String, ByVal AxelNonEssential As String, ByVal GFM As String, ByVal AssemblyText As String, ByVal Canteen As String, ByVal Lop As String, ByVal WheelEssential As String, ByVal WheelNonEssential As String, ByVal Tube As String, ByVal Mould As String, ByVal Compressor As String, ByVal Fume As String, ByVal lblMode As String, ByVal KPTCLValue As Decimal, ByVal GeneratedValue As Decimal, ByVal Arc1Value As Decimal, ByVal Arc2Value As Decimal, ByVal Arc3Value As Decimal, ByVal PumpValue As Decimal, ByVal WheelEssentialValue As Decimal, ByVal WheelNonEssentialValue As Decimal, ByVal TubeValue As Decimal, ByVal MouldValue As Decimal, ByVal FumeValue As Decimal, ByVal CompressorValue As String, ByVal AssemblyValue As Decimal, ByVal AxelEssentialValue As Decimal, ByVal AxelNonEssentialValue As Decimal, ByVal GFMValue As Decimal, ByVal ColonyValue As Decimal, ByVal AdminAux As Decimal, ByVal EmmsDCOS As Decimal, ByVal CanteenValue As Decimal, ByVal TotalTonnageforDay As Decimal, ByVal aa As Int16, ByVal ab As Int16, ByVal ac As Int16, ByVal ba As Int16, ByVal bb As Int16, ByVal bc As Int16, ByVal ca As Int16, ByVal cb As Int16, ByVal cc As Int16, ByVal da As Int16, ByVal db As Int16, ByVal dc As Int16, ByVal ea As Int16, ByVal eb As Int16, ByVal ec As Int16, ByVal ha As Int16, ByVal hb As Int16, ByVal hc As Int16, ByVal LopValue As Decimal, ByVal rwfgenvalue As Decimal, ByVal CheckMeterValue As Decimal, ByVal CheckMeter As String) As Boolean
        Public Function saveShopWise(ByVal consumption_date As Date, ByVal KPTCL As String, ByVal Generated As String, ByVal Arc1 As String, ByVal Arc2 As String, ByVal Arc3 As String, ByVal Pump As String, ByVal Colony As String, ByVal Colony1 As String, ByVal Admin As String, ByVal Aux As String, ByVal RwfgenTxt As String, ByVal pcstxt As String, ByVal WheelEssential As String, ByVal Tube As String, ByVal Mould As String, ByVal Compressor As String, ByVal Fume As String, ByVal lblMode As String, ByVal KPTCLValue As Decimal, ByVal GeneratedValue As Decimal, ByVal Arc1Value As Decimal, ByVal Arc2Value As Decimal, ByVal Arc3Value As Decimal, ByVal PumpValue As Decimal, ByVal WheelEssentialValue As Decimal, ByVal TubeValue As Decimal, ByVal MouldValue As Decimal, ByVal FumeValue As Decimal, ByVal CompressorValue As String, ByVal ColonyValue As Decimal, ByVal ColonyValue1 As Decimal, ByVal AdminAux As Decimal, ByVal TotalTonnageforDay As Decimal, ByVal aa As Int16, ByVal ab As Int16, ByVal ac As Int16, ByVal ba As Int16, ByVal bb As Int16, ByVal bc As Int16, ByVal ca As Int16, ByVal cb As Int16, ByVal cc As Int16, ByVal da As Int16, ByVal db As Int16, ByVal dc As Int16, ByVal ea As Int16, ByVal eb As Int16, ByVal ec As Int16, ByVal ha As Int16, ByVal hb As Int16, ByVal hc As Int16, ByVal rwfgenvalue As Decimal, ByVal pcsvalue As Decimal) As Boolean

            Dim blnDone As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Parameters.Add("@consumption_date", SqlDbType.SmallDateTime, 4).Value = consumption_date
                cmd.Parameters.Add("@remarks_kptcl", SqlDbType.VarChar, 500).Value = KPTCL
                cmd.Parameters.Add("@remarks_generated", SqlDbType.VarChar, 500).Value = Generated
                cmd.Parameters.Add("@remarks_arc1", SqlDbType.VarChar, 500).Value = Arc1
                cmd.Parameters.Add("@remarks_arc2", SqlDbType.VarChar, 500).Value = Arc2
                cmd.Parameters.Add("@remarks_arc3", SqlDbType.VarChar, 500).Value = Arc3
                cmd.Parameters.Add("@remarks_pumphouse", SqlDbType.VarChar, 500).Value = Pump
                cmd.Parameters.Add("@remarks_colony", SqlDbType.VarChar, 500).Value = Colony
                cmd.Parameters.Add("@remarks_colony1", SqlDbType.VarChar, 500).Value = Colony1

                cmd.Parameters.Add("@remarks_adminbldg", SqlDbType.VarChar, 500).Value = Admin
                cmd.Parameters.Add("@remarks_aux", SqlDbType.VarChar, 500).Value = Aux
                'cmd.Parameters.Add("@remarks_emms", SqlDbType.VarChar, 500).Value = Emms
                'cmd.Parameters.Add("@remarks_dcos", SqlDbType.VarChar, 500).Value = Dcos
                cmd.Parameters.Add("@remarks_rwfgen", SqlDbType.VarChar, 500).Value = RwfgenTxt
                cmd.Parameters.Add("@remarks_pcs", SqlDbType.VarChar, 500).Value = pcstxt

                'cmd.Parameters.Add("@remarks_CheckMeter", SqlDbType.VarChar, 500).Value = CheckMeter.Trim
                cmd.CommandText = "update ms_admin_energy_consumption set remarks_kptcl=@remarks_kptcl," &
                    "remarks_generated=@remarks_generated,remarks_arc1=@remarks_arc1," &
                    "remarks_arc2=@remarks_arc2,remarks_arc3=@remarks_arc3,remarks_pumphouse=@remarks_pumphouse," &
                    "remarks_colony=@remarks_colony,remarks_colony1=@remarks_colony1,remarks_adminbldg=@remarks_adminbldg,remarks_aux=@remarks_aux," &
                    " " &
                    "remarks_rwfgen = @remarks_rwfgen ,remarks_pcs = @remarks_pcs " &
                    "where consumption_date = @consumption_date "
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                If cmd.ExecuteNonQuery > 0 Then
                    'cmd.Parameters.Add("@remarks_essential_axle", SqlDbType.VarChar, 500).Value = AxelEssential
                    'cmd.Parameters.Add("@remarks_nonessential_axle", SqlDbType.VarChar, 500).Value = AxelNonEssential
                    'cmd.Parameters.Add("@remarks_gfm", SqlDbType.VarChar, 500).Value = GFM
                    'cmd.Parameters.Add("@remarks_assembly", SqlDbType.VarChar, 500).Value = AssemblyText
                    'cmd.Parameters.Add("@remarks_canteen", SqlDbType.VarChar, 500).Value = Canteen
                    'cmd.Parameters.Add("@remarks_lop", SqlDbType.VarChar, 500).Value = Lop
                    'cmd.CommandText = "update ms_axle_energy_consumption set remarks_essential=@remarks_essential_axle," &
                    '    "remarks_nonessential=@remarks_nonessential_axle,remarks_gfm=@remarks_gfm," &
                    '    "remarks_assembly=@remarks_assembly,remarks_canteen=@remarks_canteen,remarks_lop=@remarks_lop " &
                    '    " where consumption_date=@consumption_date "
                    If cmd.ExecuteNonQuery > 0 Then
                        cmd.Parameters.Add("@remarks_essential_wheel", SqlDbType.VarChar, 500).Value = WheelEssential
                        ' cmd.Parameters.Add("@remarks_nonessential_wheel", SqlDbType.VarChar, 500).Value = WheelNonEssential
                        cmd.Parameters.Add("@remarks_tube", SqlDbType.VarChar, 500).Value = Tube
                        cmd.Parameters.Add("@remarks_mould", SqlDbType.VarChar, 500).Value = Mould
                        cmd.Parameters.Add("@remarks_compressor", SqlDbType.VarChar, 500).Value = Compressor
                        cmd.Parameters.Add("@remarks_fumex", SqlDbType.VarChar, 500).Value = Fume
                        cmd.CommandText = "update ms_wheel_energy_consumption set remarks_essential=@remarks_essential_wheel," &
                        "remarks_tube=@remarks_tube," &
                        "remarks_mould=@remarks_mould,remarks_compressor=@remarks_compressor,remarks_fumex=@remarks_fumex " &
                        " where consumption_date=@consumption_date"
                        If cmd.ExecuteNonQuery > 0 Then
                            blnDone = True
                        End If
                    End If
                End If
                If blnDone Then
                    blnDone = False
                Else
                    Exit Try
                End If
                Dim i As Int16
                cmd.CommandText = "select count(*) from ms_electrical_econs " &
                    " where c_date = @consumption_date "
                i = cmd.ExecuteScalar()
                If i = 0 Then
                    'cmd.CommandText = "insert into ms_electrical_econs " &
                    '          "(c_date,kebrdng,dgenergy,furnace_a,furnace_b,furnace_c," &
                    '          "cooling,w_essen,w_nessen,holding,preheat,fume_ex,comprsr," &
                    '          "assembly,a_essen,a_nessen,forging,canteen,colony,admin,emms,totalsteel," &
                    '          "slaba_a,slaba_b,slaba_c,slabb_a,slabb_b,slabb_c,slabc_a,slabc_b,slabc_c," &
                    '          "slabd_a,slabd_b,slabd_c,slabe_a,slabe_b,slabe_c,heat_a,heat_b,heat_c,delete_flag,lop,rwfgen,CheckMeter)" &
                    '          " values (@consumption_date,@kerb,@dg,@fura,@furb,@furc,@cool,@wess,@wness,@hold," &
                    '          "@pre,@fume,@comp,@assm,@aess,@aness,@forge,@cant,@col,@admin,@emms,@totalsteel," &
                    '          "@aa,@ab,@ac,@ba,@bb,@bc,@ca,@cb,@cc,@da,@db,@dc,@ea,@eb,@ec,@ha,@hb,@hc,'0',@lop,@rwfgen,@CheckMeter)"

                    cmd.CommandText = "insert into ms_electrical_econs " &
                              "(c_date,kebrdng,dgenergy,furnace_a,furnace_b,furnace_c," &
                              "cooling,w_essen,holding,preheat,fume_ex,comprsr," &
                              "colony,admin,totalsteel," &
                              "slaba_a,slaba_b,slaba_c,slabb_a,slabb_b,slabb_c,slabc_a,slabc_b,slabc_c," &
                              "slabd_a,slabd_b,slabd_c,slabe_a,slabe_b,slabe_c,heat_a,heat_b,heat_c,delete_flag,rwfgen)" &
                              " values (@consumption_date,@kerb,@dg,@fura,@furb,@furc,@cool,@wess@hold," &
                              "@pre,@fume,@comp,@col,@admin@totalsteel," &
                              "@aa,@ab,@ac,@ba,@bb,@bc,@ca,@cb,@cc,@da,@db,@dc,@ea,@eb,@ec,@ha,@hb,@hc,'0',@rwfgen)"

                Else
                    'cmd.CommandText = "UPDATE ms_electrical_econs SET " &
                    '          "kebrdng=@kerb, dgenergy=@dg, furnace_a=@fura, furnace_b=@furb, furnace_c=@furc," &
                    '          "cooling=@cool,w_essen=@wess,w_nessen=@wness,holding=@hold,preheat=@pre,fume_ex=@fume,comprsr=@comp," &
                    '          "assembly=@assm,a_essen=@aess,a_nessen=@aness,forging=@forge,canteen=@cant,colony=@col,admin=@admin,emms=@emms,totalsteel=@totalsteel," &
                    '          "slaba_a=@aa,slaba_b=@ab,slaba_c=@ac,slabb_a=@ba,slabb_b=@bb,slabb_c=@bc,slabc_a=@ca,slabc_b=@cb,slabc_c=@cc," &
                    '          "slabd_a=@da,slabd_b=@db,slabd_c=@dc,slabe_a=@ea,slabe_b=@eb,slabe_c=@ec,heat_a=@ha,heat_b=@hb,heat_c=@hc,delete_flag='0'," &
                    '          "lop=@lop, rwfgen=@rwfgen , CheckMeter = @CheckMeter where c_date=@consumption_date"
                    cmd.CommandText = "UPDATE ms_electrical_econs SET " &
                              "kebrdng=@kerb, dgenergy=@dg, furnace_a=@fura, furnace_b=@furb, furnace_c=@furc," &
                              "cooling=@cool,w_essen=@wess,holding=@hold,preheat=@pre,fume_ex=@fume,comprsr=@comp," &
                              "colony=@col,admin=@admin,totalsteel=@totalsteel," &
                              "slaba_a=@aa,slaba_b=@ab,slaba_c=@ac,slabb_a=@ba,slabb_b=@bb,slabb_c=@bc,slabc_a=@ca,slabc_b=@cb,slabc_c=@cc," &
                              "slabd_a=@da,slabd_b=@db,slabd_c=@dc,slabe_a=@ea,slabe_b=@eb,slabe_c=@ec,heat_a=@ha,heat_b=@hb,heat_c=@hc,delete_flag='0'," &
                              "rwfgen=@rwfgen ,pcs=@pcs,colony1=@col1 where c_date=@consumption_date"
                End If
                cmd.Parameters.Add("@kerb", SqlDbType.Float, 8).Value = KPTCLValue
                cmd.Parameters.Add("@dg", SqlDbType.Float, 8).Value = GeneratedValue
                cmd.Parameters.Add("@fura", SqlDbType.Float, 8).Value = Arc1Value
                cmd.Parameters.Add("@furb", SqlDbType.Float, 8).Value = Arc2Value
                cmd.Parameters.Add("@furc", SqlDbType.Float, 8).Value = Arc3Value
                cmd.Parameters.Add("@cool", SqlDbType.Float, 8).Value = PumpValue
                cmd.Parameters.Add("@wess", SqlDbType.Float, 8).Value = WheelEssentialValue
                'cmd.Parameters.Add("@wness", SqlDbType.Float, 8).Value = WheelNonEssentialValue
                cmd.Parameters.Add("@hold", SqlDbType.Float, 8).Value = TubeValue
                cmd.Parameters.Add("@pre", SqlDbType.Float, 8).Value = MouldValue
                cmd.Parameters.Add("@fume", SqlDbType.Float, 8).Value = FumeValue
                cmd.Parameters.Add("@comp", SqlDbType.Float, 8).Value = CompressorValue
                'cmd.Parameters.Add("@assm", SqlDbType.Float, 8).Value = AssemblyValue
                'cmd.Parameters.Add("@aess", SqlDbType.Float, 8).Value = AxelEssentialValue
                'cmd.Parameters.Add("@aness", SqlDbType.Float, 8).Value = AxelNonEssentialValue
                'cmd.Parameters.Add("@forge", SqlDbType.Float, 8).Value = GFMValue
                cmd.Parameters.Add("@col", SqlDbType.Float, 8).Value = ColonyValue
                cmd.Parameters.Add("@col1", SqlDbType.Float, 8).Value = ColonyValue1
                cmd.Parameters.Add("@admin", SqlDbType.Float, 8).Value = AdminAux
                'cmd.Parameters.Add("@emms", SqlDbType.Float, 8).Value = EmmsDCOS
                'cmd.Parameters.Add("@cant", SqlDbType.Float, 8).Value = CanteenValue
                cmd.Parameters.Add("@totalsteel", SqlDbType.Float, 8).Value = TotalTonnageforDay
                cmd.Parameters.Add("@aa", SqlDbType.Float, 8).Value = aa
                cmd.Parameters.Add("@ab", SqlDbType.Float, 8).Value = ab
                cmd.Parameters.Add("@ac", SqlDbType.Float, 8).Value = ac
                cmd.Parameters.Add("@ba", SqlDbType.Float, 8).Value = ba
                cmd.Parameters.Add("@bb", SqlDbType.Float, 8).Value = bb
                cmd.Parameters.Add("@bc", SqlDbType.Float, 8).Value = bc
                cmd.Parameters.Add("@ca", SqlDbType.Float, 8).Value = ca
                cmd.Parameters.Add("@cb", SqlDbType.Float, 8).Value = cb
                cmd.Parameters.Add("@cc", SqlDbType.Float, 8).Value = cc
                cmd.Parameters.Add("@da", SqlDbType.Float, 8).Value = da
                cmd.Parameters.Add("@db", SqlDbType.Float, 8).Value = db
                cmd.Parameters.Add("@dc", SqlDbType.Float, 8).Value = dc
                cmd.Parameters.Add("@ea", SqlDbType.Float, 8).Value = ea
                cmd.Parameters.Add("@eb", SqlDbType.Float, 8).Value = eb
                cmd.Parameters.Add("@ec", SqlDbType.Float, 8).Value = ec
                cmd.Parameters.Add("@ha", SqlDbType.Float, 8).Value = ha
                cmd.Parameters.Add("@hb", SqlDbType.Float, 8).Value = hb
                cmd.Parameters.Add("@hc", SqlDbType.Float, 8).Value = hc
                'cmd.Parameters.Add("@lop", SqlDbType.Float, 8).Value = LopValue
                cmd.Parameters.Add("@rwfgen", SqlDbType.Float, 8).Value = rwfgenvalue
                cmd.Parameters.Add("@pcs", SqlDbType.Float, 8).Value = pcsvalue
                'cmd.Parameters.Add("@CheckMeter", SqlDbType.Float, 8).Value = CheckMeterValue
                If cmd.ExecuteNonQuery > 0 Then blnDone = True
            Catch exp As Exception
                blnDone = False
                Throw New Exception(exp.Message)
            Finally
                If blnDone = False Then
                    cmd.Transaction.Rollback()
                Else
                    cmd.Transaction.Commit()
                End If
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
            End Try
            Return blnDone
        End Function
        Public Function saveArcFurnaceData(ByVal consumption_date As Date, ByVal FurAInitial As Decimal, ByVal FurAFinal As Decimal, ByVal FurBInitial As Decimal, ByVal FurBFinal As Decimal, ByVal FurCInitial As Decimal, ByVal FurCFinal As Decimal, ByVal arcARemark As String, ByVal arcBRemark As String, ByVal arcCRemark As String, ByVal MFarcA As Decimal, ByVal MFarcB As Decimal, ByVal MFarcC As Decimal, ByVal ArcAUnits As Decimal, ByVal ArcBUnits As Decimal, ByVal ArcCUnits As String) As Boolean
            Dim Done As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim blnIsValid As Boolean = False

            oCmd.CommandText = " select @cnt = count(*)  from ms_arcfurnace_energy_consumption where consumption_date = @CDate "
            oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            Try
                oCmd.Parameters.Add("@CDate", SqlDbType.SmallDateTime, 4).Value = consumption_date
                oCmd.ExecuteScalar()
                If oCmd.Parameters("@cnt").Value = 0 Then
                    blnIsValid = True
                Else
                    blnIsValid = False
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End Try
            Dim strCmd, strSave As String
            If blnIsValid = True Then
                strCmd = "  insert into ms_arcfurnace_energy_consumption " _
                       & " ( consumption_date , arc1_initial , arc1_final , arc2_initial , arc2_final , " _
                       & " arc3_initial , arc3_final , remarks_arc1 , remarks_arc2 , remarks_arc3 ,  " _
                       & " radarc1 , radarc2 , radarc3 ) values " _
                       & " ( @consumption_date , @arc1_initial , @arc1_final , @arc2_initial , @arc2_final , " _
                       & " @arc3_initial , @arc3_final , @remarks_arc1 , @remarks_arc2 , @remarks_arc3 ,  " _
                       & " @radarc1 , @radarc2 , @radarc3 )"

                strSave = " insert into ms_furnace_econs " _
                        & " ( c_date , furnace_a , furnace_b , furnace_c ) " _
                        & " values ( @c_date , @furnace_a , @furnace_b , @furnace_c ) "
            Else
                strCmd = "  update ms_arcfurnace_energy_consumption set  " _
                        & " arc1_initial = @arc1_initial , arc1_final = @arc1_final ,  " _
                        & " arc2_initial = @arc2_initial , arc2_final = @arc2_final ,  " _
                        & " arc3_initial = @arc3_initial , arc3_final = @arc3_final ,  " _
                        & " remarks_arc1 = @remarks_arc1 , remarks_arc2 = @remarks_arc2 , " _
                        & " remarks_arc3 = @remarks_arc3 , radarc1 = @radarc1 , radarc2 = @radarc2 ,  " _
                        & " radarc3 = @radarc3 where consumption_date = @consumption_date "

                strSave = " update ms_furnace_econs set  " _
                        & " furnace_a = @furnace_a , furnace_b = @furnace_b ,  " _
                        & " furnace_c = @furnace_c where c_date = @c_date "
            End If

            Dim sqlCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            sqlCmd.CommandText = strCmd
            Try
                sqlCmd.Parameters.Add("@consumption_date", SqlDbType.SmallDateTime, 4).Value = consumption_date
                sqlCmd.Parameters.Add("@arc1_initial", SqlDbType.Decimal, 9).Value = FurAInitial
                sqlCmd.Parameters.Add("@arc1_final", SqlDbType.Decimal, 9).Value = FurAFinal
                sqlCmd.Parameters.Add("@arc2_initial", SqlDbType.Decimal, 9).Value = FurBInitial
                sqlCmd.Parameters.Add("@arc2_final", SqlDbType.Decimal, 9).Value = FurBFinal
                sqlCmd.Parameters.Add("@arc3_initial", SqlDbType.Decimal, 9).Value = FurCInitial
                sqlCmd.Parameters.Add("@arc3_final", SqlDbType.Decimal, 9).Value = FurCFinal
                sqlCmd.Parameters.Add("@remarks_arc1", SqlDbType.VarChar, 500).Value = arcARemark
                sqlCmd.Parameters.Add("@remarks_arc2", SqlDbType.VarChar, 500).Value = arcBRemark
                sqlCmd.Parameters.Add("@remarks_arc3", SqlDbType.VarChar, 500).Value = arcCRemark
                sqlCmd.Parameters.Add("@radarc1", SqlDbType.Decimal, 9).Value = MFarcA
                sqlCmd.Parameters.Add("@radarc2", SqlDbType.Decimal, 9).Value = MFarcB
                sqlCmd.Parameters.Add("@radarc3", SqlDbType.Decimal, 9).Value = MFarcC
            Catch exp As Exception
                Throw New Exception(exp.Message)
            End Try
            Dim sqlstr As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            sqlstr.CommandText = strSave
            Try
                sqlstr.Parameters.Add("@c_date", SqlDbType.SmallDateTime, 4).Value = consumption_date
                sqlstr.Parameters.Add("@furnace_a", SqlDbType.Decimal, 9).Value = ArcAUnits
                sqlstr.Parameters.Add("@furnace_b", SqlDbType.Decimal, 9).Value = ArcBUnits
                sqlstr.Parameters.Add("@furnace_c", SqlDbType.Decimal, 9).Value = ArcCUnits
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally

            End Try
            If sqlCmd.Connection.State = ConnectionState.Closed Then sqlCmd.Connection.Open()
            If sqlstr.Connection.State = ConnectionState.Closed Then sqlstr.Connection.Open()
            Try
                If sqlCmd.ExecuteNonQuery() = 1 Then
                    If sqlstr.ExecuteNonQuery() = 1 Then
                        Done = True
                    End If
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If sqlCmd.Connection.State = ConnectionState.Open Then sqlCmd.Connection.Close()
                If sqlstr.Connection.State = ConnectionState.Open Then sqlstr.Connection.Close()
                sqlCmd.Dispose()
                sqlstr.Dispose()
            End Try
            Return Done
        End Function
        Public Shared Function SaveFurnaceData(ByVal Mode As String, ByVal Consumption_date As Date, ByVal Melt_no As Double, ByVal Melt_month As Double, ByVal consumption As Decimal, ByVal Maximum_Demand As Decimal, ByVal furnace_number As String, ByVal vcb_number As String, ByVal melting_time As String, ByVal TtoTsameAF As String, ByVal TtoPsameAF As String, ByVal TtoTanyAF As String, ByVal remarks As String, ByVal TRno1 As Integer, ByVal Melt_from1 As Date, ByVal Melt_to1 As Date, ByVal Energy_final1 As Decimal, ByVal Energy_initial1 As Decimal, ByVal TRno2 As Integer, ByVal Melt_from2 As Date, ByVal Melt_to2 As Date, ByVal Energy_final2 As Decimal, ByVal Energy_initial2 As Decimal, ByVal TRno3 As Integer, ByVal Melt_from3 As Date, ByVal Melt_to3 As Date, ByVal Energy_final3 As Decimal, ByVal Energy_initial3 As Decimal) As Boolean

            Dim Done As Boolean
            Dim sqlCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            sqlCmd.CommandText = " select @cnt = count(*) from ms_furnace_melting_statistics where  Melt_no = @Melt_no and Consumption_date=@consumption_date "
            sqlCmd.Parameters.Add("@cnt", SqlDbType.SmallInt, 2).Direction = ParameterDirection.Output

            If sqlCmd.Connection.State = ConnectionState.Closed Then sqlCmd.Connection.Open()
            Try
                sqlCmd.Parameters.Add("@consumption_date", SqlDbType.SmallDateTime, 4).Value = Consumption_date
                sqlCmd.Parameters.Add("@Melt_no", SqlDbType.BigInt, 8).Value = Melt_no
                sqlCmd.Parameters.Add("@Melt_month", SqlDbType.BigInt, 8).Value = Melt_month
                sqlCmd.Parameters.Add("@consumption", SqlDbType.Decimal, 9).Value = consumption
                sqlCmd.Parameters.Add("@Maximum_Demand", SqlDbType.Decimal, 9).Value = Maximum_Demand
                sqlCmd.Parameters.Add("@furnace_number", SqlDbType.VarChar, 10).Value = furnace_number
                sqlCmd.Parameters.Add("@vcb_number", SqlDbType.VarChar, 10).Value = vcb_number
                sqlCmd.Parameters.Add("@melting_time", SqlDbType.VarChar, 10).Value = melting_time
                sqlCmd.Parameters.Add("@TtoTsameAF", SqlDbType.VarChar, 10).Value = TtoTsameAF
                sqlCmd.Parameters.Add("@TtoPsameAF", SqlDbType.VarChar, 10).Value = TtoPsameAF
                sqlCmd.Parameters.Add("@TtoTanyAF", SqlDbType.VarChar, 10).Value = TtoTanyAF
                sqlCmd.Parameters.Add("@remarks", SqlDbType.VarChar, 2000).Value = remarks

                If Mode.ToLower = "delete" Then
                    sqlCmd.CommandText = "delete ms_furnace_melting_statistics where Melt_no = @Melt_no"
                    sqlCmd.ExecuteNonQuery()
                    sqlCmd.CommandText = "delete ms_furnace_melting_statistics_trreadings  " &
                            " where Melt_no = @Melt_no "
                    sqlCmd.ExecuteNonQuery()
                    Done = True
                Else
                    sqlCmd.ExecuteScalar()
                    'If IIf(IsDBNull(sqlCmd.Parameters("@cnt").Value), 0, sqlCmd.Parameters("@cnt").Value) = 0 Then
                    If (Mode.ToLower = "add") Or IIf(IsDBNull(sqlCmd.Parameters("@cnt").Value), 0, sqlCmd.Parameters("@cnt").Value) = 0 Then
                        sqlCmd.CommandText = "insert into ms_furnace_melting_statistics " &
                            "  ( Consumption_date , Melt_no , Melt_month ,  consumption ,  Maximum_Demand , furnace_number ," &
                            " vcb_number , melting_time , TtoTsameAF , TtoPsameAF , TtoTanyAF , remarks ) " &
                            " values ( @consumption_date , @Melt_no , @Melt_month , @consumption , @Maximum_Demand , @furnace_number ," &
                            " @vcb_number , @melting_time , @TtoTsameAF , @TtoPsameAF , @TtoTanyAF , @remarks ) "

                    ElseIf (Mode.ToLower = "edit") Or IIf(IsDBNull(sqlCmd.Parameters("@cnt").Value), 0, sqlCmd.Parameters("@cnt").Value) > 0 Then
                        sqlCmd.CommandText = "update ms_furnace_melting_statistics set Consumption_date = @consumption_date , " &
                                " Melt_month = @Melt_month , consumption = @consumption  ,  Maximum_Demand =  @Maximum_Demand  , " &
                                " furnace_number = @furnace_number ,  vcb_number = @vcb_number , melting_time = @melting_time , " &
                                " TtoTsameAF = @TtoTsameAF , TtoPsameAF = @TtoPsameAF , TtoTanyAF =  @TtoTanyAF , remarks = @remarks  " &
                                " where  Melt_no = @Melt_no and Consumption_date=@consumption_date "
                        sqlCmd.ExecuteNonQuery()
                        Done = True
                    End If

                    If sqlCmd.ExecuteNonQuery > 0 Then
                        'If sqlCmd.ExecuteNonQuery = 1 Then
                        Done = True
                        If TRno1 > 0 Then Done = False
                        sqlCmd.Parameters.Add("@TRno1", SqlDbType.Int, 4).Value = TRno1
                        sqlCmd.Parameters.Add("@Melt_from1", SqlDbType.SmallDateTime, 4).Value = Melt_from1
                        sqlCmd.Parameters.Add("@Melt_to1", SqlDbType.SmallDateTime, 4).Value = Melt_to1
                        sqlCmd.Parameters.Add("@Energy_final1", SqlDbType.Decimal, 9).Value = Energy_final1
                        sqlCmd.Parameters.Add("@Energy_initial1", SqlDbType.Decimal, 9).Value = Energy_initial1
                        sqlCmd.CommandText = " select @cnt1 = count(*) from ms_furnace_melting_statistics_trreadings " &
                            " where  Melt_no = @Melt_no and TRno  = @TRno1 "
                        sqlCmd.Parameters.Add("@cnt1", SqlDbType.SmallInt, 2).Direction = ParameterDirection.Output
                        sqlCmd.ExecuteScalar()

                        If (Mode.ToLower = "add") Or IIf(IsDBNull(sqlCmd.Parameters("@cnt1").Value), 0, sqlCmd.Parameters("@cnt1").Value) = 0 Then
                            sqlCmd.CommandText = " insert into ms_furnace_melting_statistics_trreadings  " &
                                " ( Melt_no , TRno , Melt_from , Melt_to , Energy_final , Energy_initial ) " &
                                " values (  @Melt_no , @TRno1 , @Melt_from1 , @Melt_to1 , @Energy_final1 , @Energy_initial1 ) "
                            'Else
                        ElseIf (Mode.ToLower = "edit") Or IIf(IsDBNull(sqlCmd.Parameters("@cnt1").Value), 0, sqlCmd.Parameters("@cnt1").Value) > 0 Then
                            sqlCmd.CommandText = " update ms_furnace_melting_statistics_trreadings  " &
                                " set Melt_from = @Melt_from1 , Melt_to = @Melt_to1 , " &
                                " Energy_final = @Energy_final1 , Energy_initial = @Energy_initial1 " &
                                " where Melt_no = @Melt_no and TRno = @TRno1 "
                        End If
                        If sqlCmd.ExecuteNonQuery = 1 Then
                            Done = True
                            If TRno2 > 0 Then
                                Done = False
                                sqlCmd.Parameters.Add("@TRno2", SqlDbType.Int, 4).Value = TRno2
                                sqlCmd.Parameters.Add("@Melt_from2", SqlDbType.SmallDateTime, 4).Value = Melt_from2
                                sqlCmd.Parameters.Add("@Melt_to2", SqlDbType.SmallDateTime, 4).Value = Melt_to2
                                sqlCmd.Parameters.Add("@Energy_final2", SqlDbType.Decimal, 9).Value = Energy_final2
                                sqlCmd.Parameters.Add("@Energy_initial2", SqlDbType.Decimal, 9).Value = Energy_initial2
                                sqlCmd.CommandText = " select @cnt2 = count(*) from ms_furnace_melting_statistics_trreadings " &
                                                        " where  Melt_no = @Melt_no and TRno  = @TRno2 "
                                'sqlCmd.ExecuteScalar()
                                'If IIf(IsDBNull(sqlCmd.Parameters("@cnt2").Value), 0, sqlCmd.Parameters("@cnt2").Value) = 0 Then
                                sqlCmd.Parameters.Add("@cnt2", SqlDbType.SmallInt, 2).Direction = ParameterDirection.Output
                                sqlCmd.ExecuteScalar()

                                If (Mode.ToLower = "add") Or IIf(IsDBNull(sqlCmd.Parameters("@cnt2").Value), 0, sqlCmd.Parameters("@cnt2").Value) = 0 Then
                                    sqlCmd.CommandText = " insert into ms_furnace_melting_statistics_trreadings  " &
                                        " ( Melt_no , TRno , Melt_from , Melt_to , Energy_final , Energy_initial ) " &
                                        " values (  @Melt_no , @TRno2 , @Melt_from2 , @Melt_to2 , @Energy_final2 , @Energy_initial2 ) "
                                    ' Else
                                ElseIf (Mode.ToLower = "edit") Or IIf(IsDBNull(sqlCmd.Parameters("@cnt2").Value), 0, sqlCmd.Parameters("@cnt2").Value) > 0 Then
                                    sqlCmd.CommandText = " update ms_furnace_melting_statistics_trreadings  " &
                                        " set Melt_from = @Melt_from2 , Melt_to = @Melt_to2 , " &
                                        " Energy_final= @Energy_final2 , Energy_initial = @Energy_initial2 " &
                                        " where Melt_no = @Melt_no and TRno = @TRno2 "
                                End If
                                If sqlCmd.ExecuteNonQuery = 1 Then
                                    Done = True
                                    If TRno3 > 0 Then
                                        Done = False
                                        sqlCmd.Parameters.Add("@TRno3", SqlDbType.Int, 4).Value = TRno3
                                        sqlCmd.Parameters.Add("@Melt_from3", SqlDbType.SmallDateTime, 4).Value = Melt_from3
                                        sqlCmd.Parameters.Add("@Melt_to3", SqlDbType.SmallDateTime, 4).Value = Melt_to3
                                        sqlCmd.Parameters.Add("@Energy_final3", SqlDbType.Decimal, 9).Value = Energy_final3
                                        sqlCmd.Parameters.Add("@Energy_initial3", SqlDbType.Decimal, 9).Value = Energy_initial3
                                        sqlCmd.CommandText = " select @cnt3 = count(*) from ms_furnace_melting_statistics_trreadings " &
                                                                " where  Melt_no = @Melt_no and TRno  = @TRno3 "
                                        sqlCmd.Parameters.Add("@cnt3", SqlDbType.SmallInt, 2).Direction = ParameterDirection.Output
                                        sqlCmd.ExecuteScalar()

                                        If (Mode.ToLower = "add") Or IIf(IsDBNull(sqlCmd.Parameters("@cnt3").Value), 0, sqlCmd.Parameters("@cnt3").Value) = 0 Then
                                            sqlCmd.CommandText = " insert into ms_furnace_melting_statistics_trreadings  " &
                                                " ( Melt_no , TRno , Melt_from , Melt_to , Energy_final , Energy_initial ) " &
                                                " values (  @Melt_no , @TRno3 , @Melt_from3 , @Melt_to3 , @Energy_final3 , @Energy_initial3 ) "
                                            ' Else
                                        ElseIf (Mode.ToLower = "edit") Or IIf(IsDBNull(sqlCmd.Parameters("@cnt3").Value), 0, sqlCmd.Parameters("@cnt3").Value) > 0 Then
                                            sqlCmd.CommandText = " update ms_furnace_melting_statistics_trreadings  " &
                                                " set Melt_from = @Melt_from3 , Melt_to = @Melt_to3 , " &
                                                " Energy_final = @Energy_final3 , Energy_initial = @Energy_initial3 " &
                                                " where Melt_no = @Melt_no and TRno = @TRno3 "
                                        End If
                                        If sqlCmd.ExecuteNonQuery = 1 Then Done = True
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If

            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If sqlCmd.Connection.State = ConnectionState.Open Then sqlCmd.Connection.Close()
                sqlCmd.Dispose()
                sqlCmd = Nothing
            End Try
            Return Done
        End Function


        Public Function DailyMDPF(ByVal ConsumptionDate As Date, ByVal MD As Decimal, ByVal PowerFactor As Decimal, ByVal MDTrippings As Integer, ByVal TotalTime As Integer) As Boolean
            Dim Done As Boolean
            Dim oCmd As SqlClient.SqlCommand
            oCmd = rwfGen.Connection.CmdObj
            Dim slno As Integer
            Try
                oCmd.Parameters.Add("@ConsumptionDate", SqlDbType.SmallDateTime, 4).Value = ConsumptionDate
                oCmd.Parameters.Add("@RecordedMD", SqlDbType.Decimal, 9, 3).Value = MD
                oCmd.Parameters.Add("@PowerFactor", SqlDbType.Float, 8).Value = PowerFactor
                oCmd.Parameters.Add("@MDTrippings", SqlDbType.Int, 4).Value = MDTrippings
                oCmd.Parameters.Add("@TotalTime", SqlDbType.Int, 4).Value = TotalTime

                oCmd.Parameters.Add("@SlNo", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
            Catch exp As Exception
                Throw New Exception(exp.Message)
                Exit Function
            End Try
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                oCmd.CommandText = "select @SlNo = slno from  ms_DailyMDPF where ConsumptionDate = @ConsumptionDate"
                oCmd.ExecuteScalar()
                slno = IIf(IsDBNull(oCmd.Parameters("@SlNo").Value), 0, oCmd.Parameters("@SlNo").Value)
                If slno = 0 Then
                    oCmd.CommandText = "insert into ms_DailyMDPF " &
                       " ( RecordedMD , PowerFactor , ConsumptionDate , MDTrippings  , TotalTime ) " &
                       " values ( @RecordedMD , @PowerFactor , @ConsumptionDate  , @MDTrippings  , @TotalTime ) "
                Else
                    oCmd.CommandText = " Update ms_DailyMDPF " &
                       " set RecordedMD = @RecordedMD , PowerFactor = @PowerFactor , " &
                       " MDTrippings = @MDTrippings  , TotalTime = @TotalTime " &
                       " where ConsumptionDate = @ConsumptionDate and  SlNo = " & slno & " "
                End If
                If oCmd.ExecuteNonQuery = 1 Then
                    Done = True
                Else
                    Throw New Exception(" updation of Daily MD & PF data failed !")
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If Not IsNothing(oCmd) Then
                    If Done Then
                        oCmd.Transaction.Commit()
                    Else
                        oCmd.Transaction.Rollback()
                    End If
                    If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                    oCmd.Dispose()
                End If
            End Try
            Return Done
        End Function
        Public Function PowerFailure(ByVal Mode As String, ByVal txtfailure_date As Date, ByVal txtfrom_time As DateTime, ByVal txtto_time As DateTime, ByVal txtsf_restriction_from As DateTime, ByVal txtsf_restriction_to As DateTime, ByVal txtsf_duration As String, ByVal txtdf_restriction_from As DateTime, ByVal txtdf_restriction_to As DateTime, ByVal txtdf_duration As String, ByVal txttotal_restriction As String, ByVal Remarks As String, ByVal failure_duration As String, ByVal serial_number As Integer) As Boolean
            Dim Done As Boolean
            Dim oCmd As SqlClient.SqlCommand
            oCmd = rwfGen.Connection.CmdObj
            If Mode.Equals("add") Then
                oCmd.CommandText = "insert into ms_power_failure(failure_date,from_time,to_time,failure_duration," &
                "sf_restriction_from,sf_restriction_to,sf_duration," &
                "df_restriction_from,df_restriction_to,df_duration," &
                "total_restriction,Remarks,serial_number) values(@txtfailure_date,@txtfrom_time," &
                "@txtto_time,@failure_duration,@txtsf_restriction_from,@txtsf_restriction_to," &
                "@txtsf_duration,@txtdf_restriction_from,@txtdf_restriction_to," &
                "@txtdf_duration,@txttotal_restriction,@Remarks,@serial_number)"
            Else
                oCmd.CommandText = "update ms_power_failure set failure_date=@txtfailure_date," &
                "from_time=@txtfrom_time,to_time=@txtto_time," &
                "sf_restriction_from=@txtsf_restriction_from," &
                "sf_restriction_to=@txtsf_restriction_to," &
                "sf_duration=@txtsf_duration,df_restriction_from=@txtdf_restriction_from," &
                "df_restriction_to=@txtdf_restriction_to," &
                "df_duration=@txtdf_duration,total_restriction=@txttotal_restriction,Remarks=@Remarks,failure_duration=@failure_duration where " &
                "failure_date=@txtfailure_date and serial_number=@serial_number"
            End If
            oCmd.Parameters.Add("@txtfailure_date", SqlDbType.SmallDateTime, 4).Value = txtfailure_date
            oCmd.Parameters.Add("@txtfrom_time", SqlDbType.DateTime, 8).Value = txtfrom_time
            oCmd.Parameters.Add("@txtto_time", SqlDbType.DateTime, 8).Value = txtto_time
            oCmd.Parameters.Add("@txtsf_restriction_from", SqlDbType.DateTime, 8).Value = txtsf_restriction_from
            oCmd.Parameters.Add("@txtsf_restriction_to", SqlDbType.DateTime, 8).Value = txtsf_restriction_to
            oCmd.Parameters.Add("@txtsf_duration", SqlDbType.VarChar, 50).Value = txtsf_duration
            oCmd.Parameters.Add("@txtdf_restriction_from", SqlDbType.DateTime, 8).Value = txtdf_restriction_from
            oCmd.Parameters.Add("@txtdf_restriction_to", SqlDbType.DateTime, 8).Value = txtdf_restriction_to
            oCmd.Parameters.Add("@txtdf_duration", SqlDbType.VarChar, 50).Value = txtdf_duration
            oCmd.Parameters.Add("@txttotal_restriction", SqlDbType.VarChar, 50).Value = txttotal_restriction
            oCmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 500).Value = Remarks
            oCmd.Parameters.Add("@failure_duration", SqlDbType.VarChar, 50).Value = failure_duration
            oCmd.Parameters.Add("@serial_number", SqlDbType.Int, 4).Value = serial_number
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                If oCmd.ExecuteNonQuery = 1 Then
                    Done = True
                Else
                    Throw New Exception(" updation of Power Failure data failed !")
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If Not IsNothing(oCmd) Then
                    If Done Then
                        oCmd.Transaction.Commit()
                    Else
                        oCmd.Transaction.Rollback()
                    End If
                    If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                    oCmd.Dispose()
                End If
            End Try
            Return Done
        End Function
        Public Function LatestVoltageDateDelete(ByVal VoltageDate As Date) As Boolean
            Dim Done As Boolean
            Dim oCmd As SqlClient.SqlCommand
            oCmd = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@c_date", SqlDbType.SmallDateTime, 4).Value = VoltageDate
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                oCmd.CommandText = "delete FROM ms_DailyVoltage WHERE ConsumptionDate = @c_date "
                If oCmd.ExecuteNonQuery = 1 Then
                    oCmd.CommandText = "delete FROM ms_DailyCurrent WHERE ConsumptionDate = @c_date "
                    If oCmd.ExecuteNonQuery = 1 Then
                        oCmd.CommandText = "delete FROM ms_DailyPower WHERE ConsumptionDate = @c_date "
                        If oCmd.ExecuteNonQuery = 1 Then
                            Done = True
                        Else
                            Throw New Exception(" deletion of Daily Power data failed !")
                        End If
                    Else
                        Throw New Exception(" deletion of Daily Curren data failed !")
                    End If
                Else
                    Throw New Exception(" deletion of Daily Voltage data failed !")
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If Not IsNothing(oCmd) Then
                    If Done Then
                        oCmd.Transaction.Commit()
                    Else
                        oCmd.Transaction.Rollback()
                    End If
                    If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                    oCmd.Dispose()
                End If
            End Try
            Return Done
        End Function
        Public Function DailyVoltageCurrent(ByVal ConsumptionDate As Date, ByVal txt66 As String, ByVal txtPower As String, ByVal ddlMinutes As String, ByVal txtCurrent As Double) As Boolean
            Dim strVol, strCur, strPow As String
            Dim sqlVol, sqlCur, sqlPow, sqlMDPF As String
            Dim blnVol, blnCur, blnPow, blnMDPF As Boolean
            '---- Checking for date values
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select count(*) Volcnt , MinVol , MaxVol  from  ms_DailyVoltage where ConsumptionDate = @ConsumptionDate group by MinVol , MaxVol  ; " _
                 & " select count(*) Curcnt from  ms_DailyCurrent where ConsumptionDate = @ConsumptionDate ; " _
                 & " select count(*) Powcnt , MinPow , MaxPow  from  ms_DailyPower where ConsumptionDate = @ConsumptionDate group by MinPow , MaxPow  ; " _
                 & " select count(*) MDPFcnt from  ms_DailyMDPF where ConsumptionDate = @ConsumptionDate "
            Try
                da.SelectCommand.Parameters.Add("@ConsumptionDate", SqlDbType.SmallDateTime, 4).Value = ConsumptionDate
                da.Fill(ds)
                If ds.Tables(0).Rows.Count = 0 Then
                    '            If IIf(IsDBNull(ds.Tables(0).Rows(0).Item(0)), 0, ds.Tables(0).Rows(0).Item(0)) = 0 Then
                    sqlVol = " insert into ms_DailyVoltage (ConsumptionDate , MinVol , MaxVol  ) values ( @ConsumptionDate , '" & Val(txt66) & "' , '" & Val(txt66) & "' ) "
                    blnVol = False
                Else
                    If Val(txt66) > 0 Then
                        If Val(txt66) > IIf(IsDBNull(ds.Tables(0).Rows(0).Item(2)), 0, ds.Tables(0).Rows(0).Item(2)) Then
                            sqlVol = " update ms_DailyVoltage set MinVol =  " & ds.Tables(0).Rows(0).Item(1) & " , MaxVol = " & Val(txt66) & "  where ConsumptionDate = @ConsumptionDate  "
                        ElseIf Val(txt66) < IIf(IsDBNull(ds.Tables(0).Rows(0).Item(1)), 0, ds.Tables(0).Rows(0).Item(1)) Then
                            sqlVol = " update ms_DailyVoltage set MinVol =  " & Val(txt66) & "  , MaxVol = " & ds.Tables(0).Rows(0).Item(2) & " where ConsumptionDate = @ConsumptionDate  "
                        End If
                    End If
                    blnVol = True
                End If
                'If ds.Tables(1).Rows.Count = 0 Then
                If IIf(IsDBNull(ds.Tables(1).Rows(0).Item(0)), 0, ds.Tables(1).Rows(0).Item(0)) = 0 Then
                    sqlCur = " insert into ms_DailyCurrent (ConsumptionDate ) values (  @ConsumptionDate  ) "
                    blnCur = False
                Else
                    blnCur = True
                End If
                If ds.Tables(2).Rows.Count = 0 Then
                    sqlPow = " insert into ms_DailyPower (ConsumptionDate ,  MinPow , MaxPow  ) values ( @ConsumptionDate , " & Val(txtPower) & " , " & Val(txtPower) & " ) "
                    blnPow = False
                Else
                    If Val(txtPower) > 0 Then
                        If Val(txtPower) > IIf(IsDBNull(ds.Tables(2).Rows(0).Item(2)), 0, ds.Tables(2).Rows(0).Item(2)) Then
                            sqlPow = " update ms_DailyPower set MinPow =  " & ds.Tables(2).Rows(0).Item(1) & " , MaxPow = " & Val(txtPower) & "  where ConsumptionDate = @ConsumptionDate "
                        ElseIf Val(txtPower) < IIf(IsDBNull(ds.Tables(2).Rows(0).Item(1)), 0, ds.Tables(2).Rows(0).Item(1)) Then
                            sqlPow = " update ms_DailyPower set MinPow =  " & Val(txtPower) & "  , MaxPow = " & ds.Tables(2).Rows(0).Item(2) & "  where ConsumptionDate = @ConsumptionDate  "
                        End If
                    End If
                    blnPow = True
                End If
                ' Blocked on 13Aug2013 as new DailyMDPF.aspx was developed
                'If ddlMinutes.SelectedItem.Text = "23:30" Then
                '    sqlMDPF = " insert into ms_DailyMDPF (ConsumptionDate , RecordedMD , PowerFactor ) values (  '" & Format(CDate(txtDate.Text.Trim), "yyyy-MM-dd") & "' , " & Val(txtMD.Text.Trim) & " , " & Val("-0" + txtPF.Text.Trim) & " ) "
                'blnMDPF = False
                'Else
                blnMDPF = True
                'End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds = Nothing
            End Try
            '----End of Checking for date values
            '--- Inserting date values if not present
            If (blnVol = True AndAlso sqlVol = Nothing) AndAlso blnCur = True AndAlso (blnPow = True AndAlso sqlPow = Nothing) AndAlso blnMDPF = True Then
            Else
                Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
                Dim a As Integer = 0
                Try
                    If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                    oCmd.Parameters.Add("@ConsumptionDate", SqlDbType.SmallDateTime, 4).Value = ConsumptionDate
                    oCmd.Transaction = oCmd.Connection.BeginTransaction
                    If blnVol = True AndAlso sqlVol = Nothing Then
                    Else
                        oCmd.CommandText = sqlVol
                        a = oCmd.ExecuteNonQuery
                    End If
                    If blnCur = False Then
                        a = 0
                        oCmd.CommandText = sqlCur
                        a = oCmd.ExecuteNonQuery
                    End If
                    If blnPow = True AndAlso sqlPow = Nothing Then
                    Else
                        a = 0
                        oCmd.CommandText = sqlPow
                        a = oCmd.ExecuteNonQuery
                    End If
                    'If blnMDPF = False Then
                    '    a = 0
                    '    oCmd.CommandText = sqlMDPF
                    '    a = oCmd.ExecuteNonQuery
                    'End If
                Catch exp As Exception
                    Throw New Exception(exp.Message)
                Finally
                    If a <> 0 Then
                        oCmd.Transaction.Commit()
                        oCmd.Dispose()
                    Else
                        oCmd.Transaction.Rollback()
                        oCmd.Dispose()
                    End If
                    If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                    oCmd.Dispose()
                End Try
                If a = 0 Then
                    Exit Function
                End If
            End If
            '--- End of Inserting date values if not present
            strVol = " update ms_DailyVoltage set " & ddlMinutes & " = " & Val(txt66) & " where ConsumptionDate = @ConsumptionDate "
            strCur = " update ms_DailyCurrent set " & ddlMinutes & "  = " & Val(txtCurrent) & " where ConsumptionDate = @ConsumptionDate "
            strPow = " update ms_DailyPower set " & ddlMinutes & "  = " & Val(txtPower) & " where ConsumptionDate = @ConsumptionDate "
            Dim strCmd As New SqlClient.SqlCommand()
            Dim i As Integer = 0
            Try
                strCmd.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
                If strCmd.Connection.State = ConnectionState.Closed Then strCmd.Connection.Open()
                strCmd.Parameters.Add("@ConsumptionDate", SqlDbType.SmallDateTime, 4).Value = ConsumptionDate
                strCmd.Transaction = strCmd.Connection.BeginTransaction
                strCmd.CommandText = strVol
                i = strCmd.ExecuteNonQuery
                i = 0
                strCmd.CommandText = strCur
                i = strCmd.ExecuteNonQuery
                i = 0
                strCmd.CommandText = strPow
                i = strCmd.ExecuteNonQuery
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If i <> 0 Then
                    strCmd.Transaction.Commit()
                    strCmd.Dispose()
                Else
                    strCmd.Transaction.Rollback()
                    strCmd.Dispose()
                End If
                If strCmd.Connection.State = ConnectionState.Open Then strCmd.Connection.Close()
                strCmd.Dispose()
            End Try
            Return i
        End Function

        Public Function ECons(ByVal c_date As Date, ByVal kerb As Double, ByVal dg As Double, ByVal fura As Double, ByVal furb As Double, ByVal furc As Double, ByVal wess As Double, ByVal wness As Double, ByVal hold As Double, ByVal pre As Double, ByVal fume As Double, ByVal comp As Double, ByVal aness As Double, ByVal col As Double, ByVal admin As Double, ByVal totalsteel As Double, ByVal aa As Double, ByVal ab As Double, ByVal ac As Double, ByVal ba As Double, ByVal bb As Double, ByVal bc As Double, ByVal ca As Double, ByVal cb As Double, ByVal cc As Double, ByVal da As Double, ByVal db As Double, ByVal dc As Double, ByVal ea As Double, ByVal eb As Double, ByVal ec As Double, ByVal ha As Double, ByVal hb As Double, ByVal hc As Double, ByVal pcs As Double, ByVal pump As Double, ByVal stn As Double, ByVal col1 As Double) As Boolean
            Dim Done As Boolean
            Dim oCmd As SqlClient.SqlCommand
            oCmd = rwfGen.Connection.CmdObj

            oCmd.Parameters.Add("@c_date", SqlDbType.SmallDateTime, 4).Value = c_date
            oCmd.Parameters.Add("@kerb", SqlDbType.Float, 9).Value = kerb
            oCmd.Parameters.Add("@dg", SqlDbType.Float, 9).Value = dg
            oCmd.Parameters.Add("@fura", SqlDbType.Float, 9).Value = fura
            oCmd.Parameters.Add("@furb", SqlDbType.Float, 9).Value = furb
            oCmd.Parameters.Add("@furc", SqlDbType.Float, 9).Value = furc
            '  oCmd.Parameters.Add("@cool", SqlDbType.Float, 9).Value = cool
            oCmd.Parameters.Add("@wess", SqlDbType.Float, 9).Value = wess
            oCmd.Parameters.Add("@wness", SqlDbType.Float, 9).Value = wness
            oCmd.Parameters.Add("@hold", SqlDbType.Float, 9).Value = hold
            oCmd.Parameters.Add("@pre", SqlDbType.Float, 9).Value = pre
            oCmd.Parameters.Add("@fume", SqlDbType.Float, 9).Value = fume
            oCmd.Parameters.Add("@comp", SqlDbType.Float, 9).Value = comp
            'oCmd.Parameters.Add("@assm", SqlDbType.Float, 9).Value = assm
            ' oCmd.Parameters.Add("@aess", SqlDbType.Float, 9).Value = aess
            oCmd.Parameters.Add("@aness", SqlDbType.Float, 9).Value = aness
            'oCmd.Parameters.Add("@forge", SqlDbType.Float, 9).Value = forge
            'oCmd.Parameters.Add("@cant", SqlDbType.Float, 9).Value = cant
            oCmd.Parameters.Add("@col", SqlDbType.Float, 9).Value = col
            'oCmd.Parameters.Add("@lop", SqlDbType.Float, 9).Value = lop
            oCmd.Parameters.Add("@admin", SqlDbType.Float, 9).Value = admin
            'oCmd.Parameters.Add("@emms", SqlDbType.Float, 9).Value = emms
            oCmd.Parameters.Add("@totalsteel", SqlDbType.Float, 9).Value = totalsteel
            oCmd.Parameters.Add("@aa", SqlDbType.Float, 9).Value = aa
            oCmd.Parameters.Add("@ab", SqlDbType.Float, 9).Value = ab
            oCmd.Parameters.Add("@ac", SqlDbType.Float, 9).Value = ac
            oCmd.Parameters.Add("@ba", SqlDbType.Float, 9).Value = ba
            oCmd.Parameters.Add("@bb", SqlDbType.Float, 9).Value = bb
            oCmd.Parameters.Add("@bc", SqlDbType.Float, 9).Value = bc
            oCmd.Parameters.Add("@ca", SqlDbType.Float, 9).Value = ca
            oCmd.Parameters.Add("@cb", SqlDbType.Float, 9).Value = cb
            oCmd.Parameters.Add("@cc", SqlDbType.Float, 9).Value = cc
            oCmd.Parameters.Add("@da", SqlDbType.Float, 9).Value = da
            oCmd.Parameters.Add("@db", SqlDbType.Float, 9).Value = db
            oCmd.Parameters.Add("@dc", SqlDbType.Float, 9).Value = dc
            oCmd.Parameters.Add("@ea", SqlDbType.Float, 9).Value = ea
            oCmd.Parameters.Add("@eb", SqlDbType.Float, 9).Value = eb
            oCmd.Parameters.Add("@ec", SqlDbType.Float, 9).Value = ec
            oCmd.Parameters.Add("@ha", SqlDbType.Float, 9).Value = ha
            oCmd.Parameters.Add("@hb", SqlDbType.Float, 9).Value = hb
            oCmd.Parameters.Add("@hc", SqlDbType.Float, 9).Value = hc
            'oCmd.Parameters.Add("@rwfgen", SqlDbType.Float, 9).Value = rwfMeter
            oCmd.Parameters.Add("@pcs", SqlDbType.Float, 9).Value = pcs
            oCmd.Parameters.Add("@pump", SqlDbType.Float, 9).Value = pump
            oCmd.Parameters.Add("@stn", SqlDbType.Float, 9).Value = stn
            oCmd.Parameters.Add("@col1", SqlDbType.Float, 9).Value = col1
            Try
                'oCmd.CommandText = "UPDATE ms_electrical_econs SET " &
                '" kebrdng=@kerb, dgenergy=@dg, furnace_a=@fura, furnace_b=@furb, furnace_c=@furc," &
                '" cooling=@cool,w_essen=@wess,w_nessen=@wness,holding=@hold,preheat=@pre,fume_ex=@fume,comprsr=@comp," &
                '" assembly=@assm,a_essen=@aess,a_nessen=@aness,forging=@forge,canteen=@cant,colony=@col,admin=@admin,emms=@emms,totalsteel=@totalsteel," &
                '" slaba_a=@aa,slaba_b=@ab,slaba_c=@ac,slabb_a=@ba,slabb_b=@bb,slabb_c=@bc,slabc_a=@ca,slabc_b=@cb,slabc_c=@cc," &
                '" slabd_a=@da,slabd_b=@db,slabd_c=@dc,slabe_a=@ea,slabe_b=@eb,slabe_c=@ec,heat_a=@ha,heat_b=@hb,heat_c=@hc,delete_flag='0' " &
                '" ,lop=@lop , rwfgen = @rwfgen, pcs=@pcs, pump=@pump, stn_aux=@stn, colony1=@col1 where c_date = @c_date "

                oCmd.CommandText = "UPDATE ms_electrical_econs SET " &
                " kebrdng=@kerb, dgenergy=@dg, furnace_a=@fura, furnace_b=@furb, furnace_c=@furc," &
                "w_essen=@wess,w_nessen=@wness,holding=@hold,preheat=@pre,fume_ex=@fume,comprsr=@comp," &
                "a_nessen=@aness,colony=@col,admin=@admin,totalsteel=@totalsteel," &
                " slaba_a=@aa,slaba_b=@ab,slaba_c=@ac,slabb_a=@ba,slabb_b=@bb,slabb_c=@bc,slabc_a=@ca,slabc_b=@cb,slabc_c=@cc," &
                " slabd_a=@da,slabd_b=@db,slabd_c=@dc,slabe_a=@ea,slabe_b=@eb,slabe_c=@ec,heat_a=@ha,heat_b=@hb,heat_c=@hc,delete_flag='0' " &
                ", pcs=@pcs, pump=@pump, stn_aux=@stn, colony1=@col1 where c_date = @c_date "

                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                If oCmd.ExecuteNonQuery = 1 Then
                    Done = True
                Else
                    Throw New Exception(" updation of Power Failure data failed !")
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If Not IsNothing(oCmd) Then
                    If Done Then
                        oCmd.Transaction.Commit()
                    Else
                        oCmd.Transaction.Rollback()
                    End If
                    If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                    oCmd.Dispose()
                End If
            End Try
            Return Done
        End Function

        Public Function Update_Energy_DataBase(ByVal txtFromDate As Date, ByVal txtToDate As Date, ByVal txtWheelsCast As Integer, ByVal txtWheelsMonth As Integer, ByVal txtAxlesForged As Integer, ByVal txtWheelsYear As Integer) As Boolean
            Dim Done As Boolean
            Dim oCmd As SqlClient.SqlCommand
            oCmd = rwfGen.Connection.CmdObj
            Dim yr_from, yr_to, mth As Integer
            Dim yearbegin As Date = CDate("01/04/" & yr_from)
            If Maintenance.ElecTables.ElectricalEnergyCorrection(CDate(txtFromDate), CDate(txtToDate)) Then
                yr_to = Year(CDate(txtFromDate))
                yr_from = Year(CDate(txtToDate))
                mth = Month(CDate(txtFromDate))
                Dim cur_dt, cur_to_dt As Date
                If mth < "04" Then
                    cur_dt = CDate("01/" & mth & "/" & yr_to)
                Else
                    cur_dt = CDate("01/" & mth & "/" & yr_from)

                End If
                cur_to_dt = cur_dt.AddMonths(1)
                cur_to_dt = cur_to_dt.AddDays(-1)

                Dim fdt, tdt, yearend As Date

                fdt = cur_dt
                tdt = cur_to_dt
                yearend = tdt

                Dim wcast, wset, axl, twset As Integer
                wcast = Val(txtWheelsCast)
                wset = Val(txtWheelsMonth)
                axl = Val(txtAxlesForged)
                twset = Val(txtWheelsYear)

                Dim keb, dg, fa, fb, fc, clg, wess, wness, hdg,
                    pht, fex, cp, assy, aess, aness, frg,
                    cnt, cly, adm, em, slaa, slba, slca, slda,
                    slab, slbb, slcb, sldb, slac, slbc, slcc,
                    sldc, slea, sleb, slec As Integer
                Dim per_ton As Decimal
                Dim dtEcons As DataTable
                dtEcons = Maintenance.ElecTables.getData(CDate(txtFromDate), CDate(txtToDate))
                Dim i As Integer
                If dtEcons.Rows.Count > 0 Then
                    For i = 0 To dtEcons.Rows.Count - 1
                        keb = keb + dtEcons.Rows(i)("kebrdng")
                        dg = dg + dtEcons.Rows(i)("dgenergy")
                        fa = fa + dtEcons.Rows(i)("furnace_a")
                        fb = fb + dtEcons.Rows(i)("furnace_b")
                        fc = fc + dtEcons.Rows(i)("furnace_c")
                        clg = clg + dtEcons.Rows(i)("cooling")
                        wess = wess + dtEcons.Rows(i)("w_essen")
                        wness = wness + dtEcons.Rows(i)("w_nessen")
                        hdg = hdg + dtEcons.Rows(i)("holding")
                        pht = pht + dtEcons.Rows(i)("preheat")
                        fex = fex + dtEcons.Rows(i)("fume_ex")
                        cp = cp + dtEcons.Rows(i)("comprsr")
                        assy = assy + dtEcons.Rows(i)("assembly")
                        aess = aess + dtEcons.Rows(i)("a_essen")
                        aness = aness + dtEcons.Rows(i)("a_nessen")
                        frg = frg + dtEcons.Rows(i)("forging")
                        cnt = cnt + dtEcons.Rows(i)("canteen")
                        cly = cly + dtEcons.Rows(i)("colony")
                        adm = adm + dtEcons.Rows(i)("admin")
                        em = em + dtEcons.Rows(i)("emms")
                        slaa = slaa + dtEcons.Rows(i)("slaba_a")
                        slba = slba + dtEcons.Rows(i)("slabb_a")
                        slca = slca + dtEcons.Rows(i)("slabc_a")
                        slda = slda + dtEcons.Rows(i)("slabd_a")
                        slab = slab + dtEcons.Rows(i)("slaba_b")
                        slbb = slbb + dtEcons.Rows(i)("slabb_b")
                        slcb = slcb + dtEcons.Rows(i)("slabc_b")
                        sldb = sldb + dtEcons.Rows(i)("slabd_b")
                        slac = slac + dtEcons.Rows(i)("slaba_c")
                        slbc = slbc + dtEcons.Rows(i)("slabb_c")
                        slcc = slcc + dtEcons.Rows(i)("slabc_c")
                        sldc = sldc + dtEcons.Rows(i)("slabd_c")
                        slea = slea + dtEcons.Rows(i)("slabe_a")
                        sleb = sleb + dtEcons.Rows(i)("slabe_b")
                        slec = slec + dtEcons.Rows(i)("slabe_c")
                        per_ton = per_ton + dtEcons.Rows(i)("totalsteel")
                    Next
                End If

                Dim sla, slb, slc, sld, sle, hta, htb, htc, heatno,
                    first, second, third, fourth, prdg, wenergy, aenergy,
                    mltrgy, epw, epws, epa, eph, af1, af2, af3, pmp,
                    w, a, cpr, tub, mpo, f, axle, net, misc, ws As Double

                sla = slaa + slab + slac
                slb = slba + slbb + slbc
                slc = slca + slcb + slcc
                sld = slda + sldb + sldc
                sle = slea + sleb + slec
                hta = slaa + slba + slca + slda + slea
                htb = slab + slbb + slcb + sldb + sleb
                htc = slac + slbc + slcc + sldc + slec
                ' following lines added to get actual heats at melting shop
                'heatno = Maintenance.ElecTables.no_of_heats(CDate(txtFromDate), CDate(txtToDate))
                heatno = hta + htb + htc
                first = (sla * 100) / heatno
                second = (slb * 100) / heatno
                third = (slc * 100) / heatno
                fourth = (sld * 100) / heatno

                prdg = fa + fb + fc + wess + wness + hdg + pht + fex + aess + assy + aness + frg + clg + cp + em + cnt + dg
                wenergy = wess + wness + hdg + pht + fex
                aenergy = assy + aess + aness + frg
                mltrgy = fa + fb + fc
                epw = IIf(wcast > 0, (wenergy + mltrgy) / wcast, 0)
                epws = IIf(wset > 0, keb / wset, 0)
                epa = IIf(axl > 0, aenergy / axl, 0)
                eph = IIf(heatno > 0, mltrgy / heatno, 0)
                ws = wenergy + mltrgy ' -3000 3000 units reduced for lighting as per CME/G'S Oreders.
                If per_ton = 0 Then  ' added on 2/2/05 svi to avoid divide by zero error
                    per_ton = 1
                End If

                per_ton = mltrgy / per_ton
                Dim myear As String
                Dim myearto As String
                Dim mmnth As String
                If Month(tdt) > 3 Then
                    myear = CStr(Year(tdt))
                Else
                    myear = CStr(Year(tdt) - 1)
                End If

                Dim str As String = CStr(Month(tdt))
                Dim strsql As String
                myearto = CStr(CInt(Right(myear, 4)) + 1)
                mmnth = str.PadLeft(2, "0")
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction

                strsql = "select count(*) from ms_electrical_energy where "
                strsql &= " year_from = '" & myear & "' and year_to = '" & myearto & "' and mth = '" & mmnth & "' "
                oCmd.CommandText = strsql
                Dim No_of_record As Integer = oCmd.ExecuteScalar

                Try
                    If No_of_record = 0 Then
                        strsql = "insert into ms_electrical_energy (year_from,year_to,mth,wap,plant,wheel,"
                        strsql &= "per_heat,per_wheel,axle,per_axle,per_wheelset,compressor,no_of_wheels,no_of_axles,"
                        strsql &= "no_of_wheelsets,no_of_heats,total_wheelset,melt_energy,per_ton)"
                        strsql &= " values('" & myear & "','" & myearto & "','" & mmnth & "',"
                        strsql &= (keb + dg) & "," & prdg & "," & ws & "," & eph & ","
                        strsql &= epw & "," & aenergy & "," & epa & "," & epws & ","
                        strsql &= cp & "," & wcast & "," & axl & "," & wset & "," & heatno & ","
                        strsql &= twset & "," & mltrgy & "," & per_ton & ")"
                    Else
                        strsql = "update ms_electrical_energy set wap=" & (keb + dg) & ",plant=" & prdg & ",wheel=" & ws & ","
                        strsql &= "per_heat='" & eph & "',per_wheel=" & epw & ",axle=" & aenergy & ",per_axle=" & epa & ",per_wheelset=" & epws & ",compressor=" & cp & ",no_of_wheels=" & wcast & ",no_of_axles=" & axl & ","
                        strsql &= "no_of_wheelsets=" & wset & ",no_of_heats=" & heatno & ",total_wheelset=" & twset & ",melt_energy=" & mltrgy & ",per_ton=" & per_ton & " where "
                        strsql &= "year_from='" & myear & "' and year_to='" & myearto & "' and mth='" & mmnth & "'"
                    End If
                    oCmd.CommandText = strsql

                    If oCmd.ExecuteNonQuery = 1 Then
                        Done = True
                    Else
                        Throw New Exception(" updation of Power Failure data failed !")
                    End If
                Catch exp As Exception
                    Throw New Exception(exp.Message)
                Finally
                    If Not IsNothing(oCmd) Then
                        If Done Then
                            oCmd.Transaction.Commit()
                        Else
                            oCmd.Transaction.Rollback()
                        End If
                        If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                        oCmd.Dispose()
                    End If
                End Try
                Return Done
            Else
                Return False
            End If
        End Function
        Public Function SaveShootUpMD(ByVal ConsumptionDate As Date, ByVal ShootUpDateTime As DateTime, ByVal MVA As Decimal, ByVal Sl As Integer) As String
            Dim oCmd As New SqlClient.SqlCommand()
            oCmd.Connection = rwfGen.Connection.ConObj
            Dim done As New Boolean()
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()

                oCmd.Parameters.Add("@ConsumptionDate", SqlDbType.SmallDateTime, 4).Value = ConsumptionDate
                oCmd.Parameters.Add("@ShootUpDateTime", SqlDbType.SmallDateTime, 4).Value = ShootUpDateTime
                oCmd.Parameters.Add("@MVA", SqlDbType.Float, 8).Value = MVA
                oCmd.Parameters.Add("@Sl", SqlDbType.Int, 4).Value = Sl

                If Val(Sl) = 0 Then
                    oCmd.CommandText = "insert into ms_ShootUpMD " &
                                " ( ConsumptionDate , ShootUpDateTime , MVA  ) " &
                                " values ( @ConsumptionDate , @ShootUpDateTime , @MVA  )"
                Else
                    oCmd.CommandText = " update ms_ShootUpMD set ConsumptionDate = @ConsumptionDate , " &
                                " ShootUpDateTime = @ShootUpDateTime , MVA = @MVA " &
                                " where  Sl = @Sl  "
                End If
                If oCmd.ExecuteNonQuery > 0 Then done = True
            Catch exp As Exception
                done = False
            Finally
                If done Then
                    oCmd.Transaction.Commit()
                Else
                    oCmd.Transaction.Rollback()
                End If
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End Try
            Return done
        End Function
        <Serializable()> Public Class Energy
#Region "   Fields "
            Private oCollection As IList
            Private dateConsumptionDate As Date
            Private sMessage As String
#End Region
#Region "   Property "
            ReadOnly Property Message() As String
                Get
                    Return sMessage
                End Get
            End Property
            Property ConsumptionDate() As Date
                Get
                    Return dateConsumptionDate
                End Get
                Set(ByVal Value As Date)
                    dateConsumptionDate = Value
                End Set
            End Property
            ReadOnly Property TR(ByVal index As Integer) As Transformer
                Get
                    Return oCollection(index)
                End Get
            End Property
            ReadOnly Property count() As Integer
                Get
                    Return oCollection.Count
                End Get
            End Property
#End Region
#Region "   Methods "
            Private Sub iniVals()
                dateConsumptionDate = "01-01-1900"
                sMessage = ""
            End Sub
            Public Sub New()
                oCollection = New Collection()
                oCollection.Add(New Transformer("essential"))
                oCollection.Add(New Transformer("essential1"))
                oCollection.Add(New Transformer("NonEssential"))
                oCollection.Add(New Transformer("NonEssential1"))
                oCollection.Add(New Transformer("gfm"))
                oCollection.Add(New Transformer("gfm1"))
                oCollection.Add(New Transformer("assembly"))
                oCollection.Add(New Transformer("assembly1"))
                oCollection.Add(New Transformer("canteen"))
                oCollection.Add(New Transformer("canteen1"))


                oCollection.Add(New Transformer("tubepretr1"))
                oCollection.Add(New Transformer("tubepretr2"))
                oCollection.Add(New Transformer("mouldpretr1"))
                oCollection.Add(New Transformer("mouldpretr2"))
                oCollection.Add(New Transformer("comptr1"))
                oCollection.Add(New Transformer("comptr2"))
                oCollection.Add(New Transformer("fumetr1"))
                oCollection.Add(New Transformer("fumetr2"))
                oCollection.Add(New Transformer("mouldpretr3"))

                oCollection.Add(New Transformer("kptcl"))
                oCollection.Add(New Transformer("dggen1"))
                oCollection.Add(New Transformer("arc1"))
                oCollection.Add(New Transformer("arc2"))
                oCollection.Add(New Transformer("arc3"))
                oCollection.Add(New Transformer("pump"))
                oCollection.Add(New Transformer("Melt"))
                oCollection.Add(New Transformer("Tube"))
                oCollection.Add(New Transformer("Mould"))
                oCollection.Add(New Transformer("Fume"))
                oCollection.Add(New Transformer("emms"))
                oCollection.Add(New Transformer("colony12"))
                oCollection.Add(New Transformer("colony34"))
                oCollection.Add(New Transformer("adminbldg"))
                oCollection.Add(New Transformer("stnaux"))
                oCollection.Add(New Transformer("rwfGen"))
                oCollection.Add(New Transformer("pcs"))
                oCollection.Add(New Transformer("lop"))

                'oCollection.Add(New Transformer("kptcl"))
                'oCollection.Add(New Transformer("dggen1"))
                'oCollection.Add(New Transformer("dggen2"))
                'oCollection.Add(New Transformer("arc1"))
                'oCollection.Add(New Transformer("arc2"))
                'oCollection.Add(New Transformer("arc3"))
                'oCollection.Add(New Transformer("pump"))
                'oCollection.Add(New Transformer("colony"))
                'oCollection.Add(New Transformer("adminbldg"))
                'oCollection.Add(New Transformer("stnaux"))
                'oCollection.Add(New Transformer("emms"))
                'oCollection.Add(New Transformer("dcos"))
                'oCollection.Add(New Transformer("lop"))
                'oCollection.Add(New Transformer("rwfGen"))
                'oCollection.Add(New Transformer("dggen3"))

                oCollection.Add(New Transformer("C0"))
                oCollection.Add(New Transformer("C1"))
                oCollection.Add(New Transformer("C2"))
                iniVals()
            End Sub
            Public Function SaveWheelEnergyConsumption(ByVal ConsumptionDate As Date, Optional ByVal Delete As Boolean = False) As Boolean
                Dim blnDone As Boolean

                Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj

                cmd.Parameters.Add("@consumption_date", SqlDbType.SmallDateTime, 4)
                cmd.Parameters("@consumption_date").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@essential_initial", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@essential_initial").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@essential_final", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@essential_final").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@essential_initial1", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@essential_initial1").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@essential_final1", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@essential_final1").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@nonessential_initial", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@nonessential_initial").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@nonessential_final", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@nonessential_final").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@nonessential_initial1", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@nonessential_initial1").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@nonessential_final1", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@nonessential_final1").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@tube_preheat_initial", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@tube_preheat_initial").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@tube_preheat_final", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@tube_preheat_final").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@tube_preheat_initial1", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@tube_preheat_initial1").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@tube_preheat_final1", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@tube_preheat_final1").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@mould_preheat_initial", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@mould_preheat_initial").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@mould_preheat_final", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@mould_preheat_final").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@mould_preheat_initial1", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@mould_preheat_initial1").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@mould_preheat_final1", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@mould_preheat_final1").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@compressor_initial", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@compressor_initial").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@compressor_final", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@compressor_final").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@compressor_initial1", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@compressor_initial1").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@compressor_final1", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@compressor_final1").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@fume_initial", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@fume_initial").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@fume_final", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@fume_final").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@fume_initial1", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@fume_initial1").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@fume_final1", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@fume_final1").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@mould_preheat_initial2", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@mould_preheat_initial2").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@mould_preheat_final2", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@mould_preheat_final2").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@radess", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@radess").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@radess1", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@radess1").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@radNess", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@radNess").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@radNess1", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@radNess1").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@radTube", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@radTube").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@radTube1", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@radTube1").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@radMld", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@radMld").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@radMld1", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@radMld1").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@radCmp", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@radCmp").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@radCmp1", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@radCmp1").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@radFm", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@radFm").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@radFm1", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@radFm1").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@radMld2", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@radMld2").Direction = ParameterDirection.Input
                Try
                    cmd.Parameters("@consumption_date").Value = Me.ConsumptionDate
                    cmd.Parameters("@essential_initial").Value = Me.TR(0).Reading.initial
                    cmd.Parameters("@essential_final").Value = Me.TR(0).Reading.final
                    cmd.Parameters("@essential_initial1").Value = Me.TR(1).Reading.initial
                    cmd.Parameters("@essential_final1").Value = Me.TR(1).Reading.final
                    cmd.Parameters("@nonessential_initial").Value = Me.TR(2).Reading.initial
                    cmd.Parameters("@nonessential_final").Value = Me.TR(2).Reading.final
                    cmd.Parameters("@nonessential_initial1").Value = Me.TR(3).Reading.initial
                    cmd.Parameters("@nonessential_final1").Value = Me.TR(3).Reading.final
                    cmd.Parameters("@tube_preheat_initial").Value = Me.TR(10).Reading.initial
                    cmd.Parameters("@tube_preheat_final").Value = Me.TR(10).Reading.final
                    cmd.Parameters("@tube_preheat_initial1").Value = Me.TR(11).Reading.initial
                    cmd.Parameters("@tube_preheat_final1").Value = Me.TR(11).Reading.final
                    cmd.Parameters("@mould_preheat_initial").Value = Me.TR(12).Reading.initial
                    cmd.Parameters("@mould_preheat_final").Value = Me.TR(12).Reading.final
                    cmd.Parameters("@mould_preheat_initial1").Value = Me.TR(13).Reading.initial
                    cmd.Parameters("@mould_preheat_final1").Value = Me.TR(13).Reading.final
                    cmd.Parameters("@compressor_initial").Value = Me.TR(14).Reading.initial
                    cmd.Parameters("@compressor_final").Value = Me.TR(14).Reading.final
                    cmd.Parameters("@compressor_initial1").Value = Me.TR(15).Reading.initial
                    cmd.Parameters("@compressor_final1").Value = Me.TR(15).Reading.final
                    cmd.Parameters("@fume_initial").Value = Me.TR(16).Reading.initial
                    cmd.Parameters("@fume_final").Value = Me.TR(16).Reading.final
                    cmd.Parameters("@fume_initial1").Value = Me.TR(17).Reading.initial
                    cmd.Parameters("@fume_final1").Value = Me.TR(17).Reading.final
                    cmd.Parameters("@mould_preheat_initial2").Value = Me.TR(18).Reading.initial
                    cmd.Parameters("@mould_preheat_final2").Value = Me.TR(18).Reading.final

                    cmd.Parameters("@radess").Value = Me.TR(0).Reading.rad
                    cmd.Parameters("@radess1").Value = Me.TR(1).Reading.rad
                    cmd.Parameters("@radNess").Value = Me.TR(2).Reading.rad
                    cmd.Parameters("@radNess1").Value = Me.TR(3).Reading.rad
                    cmd.Parameters("@radTube").Value = Me.TR(10).Reading.rad
                    cmd.Parameters("@radTube1").Value = Me.TR(11).Reading.rad
                    cmd.Parameters("@radMld").Value = Me.TR(12).Reading.rad
                    cmd.Parameters("@radMld1").Value = Me.TR(13).Reading.rad
                    cmd.Parameters("@radCmp").Value = Me.TR(14).Reading.rad
                    cmd.Parameters("@radCmp1").Value = Me.TR(15).Reading.rad

                    cmd.Parameters("@radFm").Value = Me.TR(16).Reading.rad
                    cmd.Parameters("@radFm1").Value = Me.TR(17).Reading.rad
                    cmd.Parameters("@radMld2").Value = Me.TR(18).Reading.rad

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
                    If ConsumptionDate > CDate("1900-01-01") Then
                        cmd.Parameters("@consumption_date").Direction = ParameterDirection.Input
                        If Delete = False Then
                            WheelEnergyConsumptionEdit(cmd)
                            blnDone = True
                        Else
                            WheelEnergyConsumptionDelete(cmd)
                            blnDone = True
                        End If
                    Else
                        If Delete = False Then WheelEnergyConsumptionAdd(cmd)
                        blnDone = True
                    End If
                Catch exp As Exception
                    Throw New Exception(exp.Message)
                    sMessage = exp.Message
                Finally
                    If blnDone = True Then
                        cmd.Transaction.Commit()
                        sMessage = "Record Saved !"
                    Else
                        cmd.Transaction.Rollback()
                        sMessage = "Record Not Saved !"
                    End If
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                End Try
                Return blnDone
            End Function
            Private Sub WheelEnergyConsumptionAdd(ByRef CMD As SqlClient.SqlCommand)
                CMD.CommandText = "insert into ms_wheel_energy_consumption(consumption_date , " &
                        " wsesstr1_initial , wsesstr1_final , wsesstr2_initial , wsesstr2_final , " &
                        " wsnonesstr3_initial , wsnonesstr3_final , wsnonesstr4_initial , wsnonesstr4_final , " &
                        " tubepretr1_initial , tubepretr1_final , tubepretr2_initial , tubepretr2_final , " &
                        " mouldpretr1_initial , mouldpretr1_final , mouldpretr2_initial , mouldpretr2_final , " &
                        " comptr1_initial , comptr1_final , comptr2_initial , comptr2_final , " &
                        " fumetr1_initial , fumetr1_final , fumetr2_initial , fumetr2_final ,  " &
                        " radess , radess1 , radNess , radNess1 , radTube , radTube1 , " &
                        " radMld , radMld1 , radCmp ,  radCmp1 , radFm , radFm1 , mouldpretr3_initial , mouldpretr3_final , radMld2 ) " &
                        " values ( @consumption_date , @essential_initial , @essential_final, " &
                        " @essential_initial1 , @essential_final1 , @nonessential_initial , @nonessential_final," &
                        " @nonessential_initial1 , @nonessential_final1 ,  " &
                        " @tube_preheat_initial, @tube_preheat_final, @tube_preheat_initial1 , @tube_preheat_final1 , " &
                        " @mould_preheat_initial , @mould_preheat_final , @mould_preheat_initial1 , @mould_preheat_final1 , " &
                        " @compressor_initial , @compressor_final , @compressor_initial1 , @compressor_final1 , " &
                        " @fume_initial , @fume_final ,  @fume_initial1 , @fume_final1 , " &
                        " @radess , @radess1 , @radNess , @radNess1 , @radTube , @radTube1 , " &
                        " @radMld , @radMld1 , " &
                        " @radCmp , @radCmp1 , @radFm , @radFm1 , @mould_preheat_initial2 , @mould_preheat_final2 , @radMld2 ) "

                Try
                    If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" insert into ms_wheel_energy_consumption failed ")
                Catch exp As Exception
                    Throw New Exception(" Insert into ms_wheel_energy_consumption error " & exp.Message)
                End Try
            End Sub
            Private Sub WheelEnergyConsumptionEdit(ByRef CMD As SqlClient.SqlCommand)
                CMD.CommandText = " update ms_wheel_energy_consumption set wsesstr1_initial= @essential_initial , " &
                    " wsesstr1_final = @essential_final , wsesstr2_initial = @essential_initial1 , wsesstr2_final = @essential_final1 , " &
                    " wsnonesstr3_initial = @nonessential_initial, wsnonesstr3_final = @nonessential_final , " &
                    " wsnonesstr4_initial = @nonessential_initial1 , wsnonesstr4_final = @nonessential_final1 ,  " &
                    " tubepretr1_initial = @tube_preheat_initial , tubepretr1_final = @tube_preheat_final, " &
                    " tubepretr2_initial = @tube_preheat_initial1 , tubepretr2_final = @tube_preheat_final1 ," &
                    " mouldpretr1_initial = @mould_preheat_initial ,  mouldpretr1_final = @mould_preheat_final, " &
                    " mouldpretr2_initial = @mould_preheat_initial1, mouldpretr2_final = @mould_preheat_final1 , " &
                    " comptr1_initial = @compressor_initial , comptr1_final = @compressor_final , comptr2_initial = @compressor_initial1 , comptr2_final =  @compressor_final1 , " &
                    " fumetr1_initial =  @fume_initial , fumetr1_final = @fume_final  , fumetr2_initial =  @fume_initial1 , fumetr2_final = @fume_final1 , " &
                    " radess = @radess , radess1 = @radess1 , radNess = @radNess ,  " &
                    " radNess1 = @radNess1 , radTube = @radTube , radTube1 = @radTube1 , " &
                    " radMld = @radMld , radMld1 = @radMld1 , radCmp = @radCmp , " &
                    " radCmp1 = @radCmp1 , radFm = @radFm , radFm1 = @radFm1 , mouldpretr3_initial = @mould_preheat_initial2, mouldpretr3_final = @mould_preheat_final2 , radMld2 = @radMld2 " &
                    " where consumption_date = @consumption_date "

                Try
                    If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to update ms_wheel_energy_consumption Details ")
                Catch exp As Exception
                    Throw New Exception(" update of ms_wheel_energy_consumption error :  " & exp.Message)
                End Try
            End Sub
            Private Sub WheelEnergyConsumptionDelete(ByRef CMD As SqlClient.SqlCommand)
                CMD.CommandText = " delete from ms_wheel_energy_consumption  where consumption_date = @consumption_date "
                Try
                    If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to delete wheel_energy_consumption Details ")
                Catch exp As Exception
                    Throw New Exception(" delete of ms_wheel_energy_consumption error :  " & exp.Message)
                End Try
            End Sub
            Public Function SaveAxleEnergyConsumption(ByVal ConsumptionDate As Date, Optional ByVal Delete As Boolean = False) As Boolean
                Dim blnDone As Boolean

                Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj

                cmd.Parameters.Add("@consumption_date", SqlDbType.SmallDateTime, 4)
                cmd.Parameters("@consumption_date").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@essential_initial", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@essential_initial").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@essential_final", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@essential_final").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@essential_initial1", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@essential_initial1").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@essential_final1", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@essential_final1").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@nonessential_initial", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@nonessential_initial").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@nonessential_final", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@nonessential_final").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@nonessential_initial1", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@nonessential_initial1").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@nonessential_final1", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@nonessential_final1").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@gfm_initial", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@gfm_initial").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@gm_final", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@gm_final").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@gfm_initial1", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@gfm_initial1").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@gm_final1", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@gm_final1").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@assembly_initial", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@assembly_initial").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@assembly_final", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@assembly_final").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@assembly_initial1", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@assembly_initial1").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@assembly_final1", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@assembly_final1").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@canteen_initial", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@canteen_initial").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@canteen_final", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@canteen_final").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@canteen_initial1", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@canteen_initial1").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@canteen_final1", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@canteen_final1").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@lop_initial", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@lop_initial").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@lop_final", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@lop_final").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@radaxl", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@radaxl").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@radaxl1", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@radaxl1").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@radaxlN", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@radaxlN").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@radaxlN1", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@radaxlN1").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@radgm", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@radgm").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@radgm1", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@radgm1").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@radass", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@radass").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@radass1", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@radass1").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@radcan", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@radcan").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@radcan1", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@radcan1").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@radlop", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@radlop").Direction = ParameterDirection.Input

                Try
                    cmd.Parameters("@consumption_date").Value = Me.ConsumptionDate
                    cmd.Parameters("@essential_initial").Value = Me.TR(0).Reading.initial
                    cmd.Parameters("@essential_final").Value = Me.TR(0).Reading.final
                    cmd.Parameters("@essential_initial1").Value = Me.TR(1).Reading.initial
                    cmd.Parameters("@essential_final1").Value = Me.TR(1).Reading.final
                    cmd.Parameters("@nonessential_initial").Value = Me.TR(2).Reading.initial
                    cmd.Parameters("@nonessential_final").Value = Me.TR(2).Reading.final
                    cmd.Parameters("@nonessential_initial1").Value = Me.TR(3).Reading.initial
                    cmd.Parameters("@nonessential_final1").Value = Me.TR(3).Reading.final
                    cmd.Parameters("@gfm_initial").Value = Me.TR(4).Reading.initial
                    cmd.Parameters("@gm_final").Value = Me.TR(4).Reading.final
                    cmd.Parameters("@gfm_initial1").Value = Me.TR(5).Reading.initial
                    cmd.Parameters("@gm_final1").Value = Me.TR(5).Reading.final
                    cmd.Parameters("@assembly_initial").Value = Me.TR(6).Reading.initial
                    cmd.Parameters("@assembly_final").Value = Me.TR(6).Reading.final
                    cmd.Parameters("@assembly_initial1").Value = Me.TR(7).Reading.initial
                    cmd.Parameters("@assembly_final1").Value = Me.TR(7).Reading.final
                    cmd.Parameters("@canteen_initial").Value = Me.TR(8).Reading.initial
                    cmd.Parameters("@canteen_final").Value = Me.TR(8).Reading.final
                    cmd.Parameters("@canteen_initial1").Value = Me.TR(9).Reading.initial
                    cmd.Parameters("@canteen_final1").Value = Me.TR(9).Reading.final
                    cmd.Parameters("@lop_initial").Value = Me.TR(31).Reading.initial
                    cmd.Parameters("@lop_final").Value = Me.TR(31).Reading.final

                    cmd.Parameters("@radaxl").Value = Me.TR(0).Reading.rad
                    cmd.Parameters("@radaxl1").Value = Me.TR(1).Reading.rad
                    cmd.Parameters("@radaxlN").Value = Me.TR(2).Reading.rad
                    cmd.Parameters("@radaxlN1").Value = Me.TR(3).Reading.rad
                    cmd.Parameters("@radgm").Value = Me.TR(4).Reading.rad
                    cmd.Parameters("@radgm1").Value = Me.TR(5).Reading.rad
                    cmd.Parameters("@radass").Value = Me.TR(6).Reading.rad
                    cmd.Parameters("@radass1").Value = Me.TR(7).Reading.rad
                    cmd.Parameters("@radcan").Value = Me.TR(8).Reading.rad
                    cmd.Parameters("@radcan1").Value = Me.TR(9).Reading.rad
                    cmd.Parameters("@radlop").Value = Me.TR(31).Reading.rad
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
                    If ConsumptionDate > CDate("1900-01-01") Then
                        cmd.Parameters("@consumption_date").Direction = ParameterDirection.Input
                        If Delete = False Then
                            AxleEnergyConsumptionEdit(cmd)
                            blnDone = True
                        Else
                            AxleEnergyConsumptionDelete(cmd)
                            blnDone = True
                        End If
                    Else
                        If Delete = False Then AxleEnergyConsumptionAdd(cmd)
                        blnDone = True
                    End If
                Catch exp As Exception
                    Throw New Exception(exp.Message)
                    sMessage = exp.Message
                Finally
                    If blnDone = True Then
                        cmd.Transaction.Commit()
                        sMessage = "Record Saved !"
                    Else
                        cmd.Transaction.Rollback()
                        sMessage = "Record Not Saved !"
                    End If
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                End Try
                Return blnDone
            End Function
            Private Sub AxleEnergyConsumptionAdd(ByRef CMD As SqlClient.SqlCommand)
                CMD.CommandText = " insert into ms_axle_energy_consumption(consumption_date,essential_initial , " &
                              " essential_final,essential_initial1,essential_final1, " &
                              " nonessential_initial, nonessential_final, nonessential_initial1,nonessential_final1, " &
                              " gfm_initial, gm_final,gfm_initial1, gm_final1," &
                              " assembly_initial,assembly_final,assembly_initial1,assembly_final1, " &
                              " canteen_initial,canteen_final, canteen_initial1,canteen_final1 , lop_initial , lop_final ," &
                              " radaxl,radaxl1,radaxlN,radaxlN1,radgm, " &
                              " radgm1,radass,radass1,radcan,radcan1,radlop) " &
                              " values(@consumption_date," &
                              " @essential_initial,@essential_final,@essential_initial1,@essential_final1," &
                              " @nonessential_initial,@nonessential_final, @nonessential_initial1,@nonessential_final1," &
                              " @gfm_initial,@gm_final,@gfm_initial1,@gm_final1," &
                              " @assembly_initial,@assembly_final,@assembly_initial1,@assembly_final1," &
                              " @canteen_initial,@canteen_final, @canteen_initial1,@canteen_final1,@lop_initial,@lop_final," &
                              " @radaxl,@radaxl1,@radaxlN,@radaxlN1,@radgm, " &
                              " @radgm1,@radass,@radass1,@radcan,@radcan1,@radlop )"

                Try
                    If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" insert into ms_axle_energy_consumption failed ")
                Catch exp As Exception
                    Throw New Exception(" Insert into ms_axle_energy_consumption error " & exp.Message)
                End Try
            End Sub
            Private Sub AxleEnergyConsumptionEdit(ByRef CMD As SqlClient.SqlCommand)
                CMD.CommandText = "update ms_axle_energy_consumption set essential_initial=@essential_initial," &
                         " essential_final=@essential_final,essential_initial1=@essential_initial1,essential_final1=@essential_final1,nonessential_initial=@nonessential_initial," &
                         " nonessential_final=@nonessential_final,nonessential_initial1=@nonessential_initial1,nonessential_final1=@nonessential_final1,gfm_initial=@gfm_initial,gm_final=@gm_final," &
                         " gfm_initial1=@gfm_initial1,gm_final1=@gm_final1,assembly_initial=@assembly_initial,assembly_final=@assembly_final,assembly_initial1=@assembly_initial1,assembly_final1=@assembly_final1," &
                         " canteen_initial=@canteen_initial,canteen_final=@canteen_final,canteen_initial1=@canteen_initial1,canteen_final1=@canteen_final1,lop_initial=@lop_initial,lop_final=@lop_final," &
                         " radaxl=@radaxl,radaxl1=@radaxl1,radaxlN=@radaxlN,radaxlN1=@radaxlN1,radgm=@radgm, " &
                         " radgm1=@radgm1,radass=@radass,radass1=@radass1,radcan=@radcan,radcan1=@radcan1,radlop=@radlop  " &
                         " where consumption_date=@consumption_date"

                Try
                    If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to update ms_axle_energy_consumption Details ")
                Catch exp As Exception
                    Throw New Exception(" update of ms_axle_energy_consumption error :  " & exp.Message)
                End Try
            End Sub
            Private Sub AxleEnergyConsumptionDelete(ByRef CMD As SqlClient.SqlCommand)
                CMD.CommandText = " delete from ms_axle_energy_consumption  where consumption_date = @consumption_date "
                Try
                    If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to delete xle_energy_consumption Details ")
                Catch exp As Exception
                    Throw New Exception(" delete of ms_axle_energy_consumption error :  " & exp.Message)
                End Try
            End Sub
            Public Function SaveAdminEnergyConsumption(ByVal ConsumptionDate As Date, Optional ByVal Delete As Boolean = False) As Boolean
                Dim blnDone As Boolean

                Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj

                cmd.Parameters.Add("@consumption_date", SqlDbType.SmallDateTime, 4)
                cmd.Parameters("@consumption_date").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@kptcl_initial", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@kptcl_initial").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@kptcl_final", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@kptcl_final").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@dg_gen1_initial", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@dg_gen1_initial").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@dg_gen1_final", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@dg_gen1_final").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@arc1_initial", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@arc1_initial").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@arc1_final", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@arc1_final").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@arc2_initial", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@arc2_initial").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@arc2_final", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@arc2_final").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@arc3_initial", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@arc3_initial").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@arc3_final", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@arc3_final").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@pumphouse_initial", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@pumphouse_initial").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@pumphouse_final", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@pumphouse_final").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@Melt_initial", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@Melt_initial").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@Melt_final", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@Melt_final").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@Tube_initial", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@Tube_initial").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@Tube_final", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@Tube_final").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@Mould_initial", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@Mould_initial").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@Mould_final", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@Mould_final").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@Fume_initial", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@Fume_initial").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@Fume_final", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@Fume_final").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@emms_initial", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@emms_initial").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@emms_final", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@emms_final").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@colony12_initial", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@colony12_initial").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@colony12_final", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@colony12_final").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@colony34_initial", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@colony34_initial").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@colony34_final", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@colony34_final").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@adminbldg_initial", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@adminbldg_initial").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@adminbldg_final", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@adminbldg_final").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@stnaux_initial", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@stnaux_initial").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@stnaux_final", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@stnaux_final").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@rwfgen_initial", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@rwfgen_initial").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@rwfgen_final", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@rwfgen_final").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@pcs_initial", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@pcs_initial").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@pcs_final", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@pcs_final").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@CheckMeter_initial", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@CheckMeter_initial").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@CheckMeter_final", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@CheckMeter_final").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@radkptcl", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@radkptcl").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@raddgI", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@raddgI").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@radarc1", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@radarc1").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@radarc2", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@radarc2").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@radarc3", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@radarc3").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@radpump", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@radpump").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@radMelt", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@radMelt").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@radTube", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@radTube").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@radMould", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@radMould").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@radFume", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@radFume").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@rademms", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@rademms").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@radcolony12", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@radcolony12").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@radcolony34", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@radcolony34").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@radadmn", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@radadmn").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@radaux", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@radaux").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@radrwfgen", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@radrwfgen").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@radpcs", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@radpcs").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@radCheckMeter", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@radCheckMeter").Direction = ParameterDirection.Input
                Try
                    cmd.Parameters("@consumption_date").Value = Me.ConsumptionDate
                    cmd.Parameters("@kptcl_initial").Value = Me.TR(20).Reading.initial
                    cmd.Parameters("@kptcl_final").Value = Me.TR(20).Reading.final
                    cmd.Parameters("@dg_gen1_initial").Value = Me.TR(21).Reading.initial
                    cmd.Parameters("@dg_gen1_final").Value = Me.TR(21).Reading.final
                    cmd.Parameters("@arc1_initial").Value = Me.TR(22).Reading.initial
                    cmd.Parameters("@arc1_final").Value = Me.TR(22).Reading.final
                    cmd.Parameters("@arc2_initial").Value = Me.TR(23).Reading.initial
                    cmd.Parameters("@arc2_final").Value = Me.TR(23).Reading.final
                    cmd.Parameters("@arc3_initial").Value = Me.TR(24).Reading.initial
                    cmd.Parameters("@arc3_final").Value = Me.TR(24).Reading.final
                    cmd.Parameters("@pumphouse_initial").Value = Me.TR(25).Reading.initial
                    cmd.Parameters("@pumphouse_final").Value = Me.TR(25).Reading.final
                    cmd.Parameters("@Melt_initial").Value = Me.TR(26).Reading.initial
                    cmd.Parameters("@Melt_final").Value = Me.TR(26).Reading.final
                    cmd.Parameters("@Tube_initial").Value = Me.TR(27).Reading.initial
                    cmd.Parameters("@Tube_final").Value = Me.TR(27).Reading.final
                    cmd.Parameters("@Mould_initial").Value = Me.TR(28).Reading.initial
                    cmd.Parameters("@Mould_final").Value = Me.TR(28).Reading.final
                    cmd.Parameters("@Fume_initial").Value = Me.TR(29).Reading.initial
                    cmd.Parameters("@Fume_final").Value = Me.TR(29).Reading.final
                    cmd.Parameters("@emms_initial").Value = Me.TR(30).Reading.initial
                    cmd.Parameters("@emms_final").Value = Me.TR(30).Reading.final
                    cmd.Parameters("@colony12_initial").Value = Me.TR(31).Reading.initial
                    cmd.Parameters("@colony12_final").Value = Me.TR(31).Reading.final
                    cmd.Parameters("@colony34_initial").Value = Me.TR(32).Reading.initial
                    cmd.Parameters("@colony34_final").Value = Me.TR(32).Reading.final
                    cmd.Parameters("@adminbldg_initial").Value = Me.TR(33).Reading.initial
                    cmd.Parameters("@adminbldg_final").Value = Me.TR(33).Reading.final
                    cmd.Parameters("@stnaux_initial").Value = Me.TR(34).Reading.initial
                    cmd.Parameters("@stnaux_final").Value = Me.TR(34).Reading.final
                    cmd.Parameters("@rwfgen_initial").Value = Me.TR(35).Reading.initial
                    cmd.Parameters("@rwfgen_final").Value = Me.TR(35).Reading.final
                    cmd.Parameters("@pcs_initial").Value = Me.TR(36).Reading.initial
                    cmd.Parameters("@pcs_final").Value = Me.TR(36).Reading.final

                    cmd.Parameters("@CheckMeter_initial").Value = Me.TR(38).Reading.initial
                    cmd.Parameters("@CheckMeter_final").Value = Me.TR(38).Reading.final

                    cmd.Parameters("@radkptcl").Value = Me.TR(20).Reading.rad
                    cmd.Parameters("@raddgI").Value = Me.TR(21).Reading.rad
                    cmd.Parameters("@radarc1").Value = Me.TR(22).Reading.rad
                    cmd.Parameters("@radarc2").Value = Me.TR(23).Reading.rad
                    cmd.Parameters("@radarc3").Value = Me.TR(24).Reading.rad
                    cmd.Parameters("@radpump").Value = Me.TR(25).Reading.rad
                    cmd.Parameters("@radMelt").Value = Me.TR(26).Reading.rad
                    cmd.Parameters("@radTube").Value = Me.TR(27).Reading.rad
                    cmd.Parameters("@radMould").Value = Me.TR(28).Reading.rad
                    cmd.Parameters("@radFume").Value = Me.TR(29).Reading.rad
                    cmd.Parameters("@rademms").Value = Me.TR(30).Reading.rad
                    cmd.Parameters("@radcolony12").Value = Me.TR(31).Reading.rad
                    cmd.Parameters("@radcolony34").Value = Me.TR(32).Reading.rad
                    cmd.Parameters("@radadmn").Value = Me.TR(33).Reading.rad
                    cmd.Parameters("@radaux").Value = Me.TR(34).Reading.rad
                    cmd.Parameters("@radrwfgen").Value = Me.TR(35).Reading.rad
                    cmd.Parameters("@radpcs").Value = Me.TR(36).Reading.rad
                    cmd.Parameters("@radCheckMeter").Value = Me.TR(38).Reading.rad
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
                    If ConsumptionDate > CDate("1900-01-01") Then
                        cmd.Parameters("@consumption_date").Direction = ParameterDirection.Input
                        If Delete = True Then
                            AdminEnergyConsumptionEdit(cmd)
                            blnDone = True
                        Else
                            AdminEnergyConsumptionDelete(cmd)
                            blnDone = True
                        End If
                    Else
                        If Delete = False Then
                            AdminEnergyConsumptionAdd(cmd)
                        End If
                        blnDone = True
                    End If
                Catch exp As Exception
                    Throw New Exception(exp.Message)
                    sMessage = exp.Message
                Finally
                    If blnDone = True Then
                        cmd.Transaction.Commit()
                        sMessage = "Record Saved !"
                    Else
                        cmd.Transaction.Rollback()
                        sMessage = "Record Not Saved !"
                    End If
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                End Try
                Return blnDone
            End Function

            Private Sub AdminEnergyConsumptionAdd(ByRef CMD As SqlClient.SqlCommand)
                CMD.CommandText = "insert into ms_admin_energy_consumption( consumption_date , kptcl_initial, kptcl_final ,dg_gen1_initial , dg_gen1_final ,arc1_initial , arc1_final ,arc2_initial ,  arc2_final , arc3_initial , arc3_final ," &
" pumphouse_initial ,pumphouse_final, Melt_initial1, Melt_final1, Tube_initial1, Tube_final1,Mould_initial1, Mould_final1,Fume_initial1, Fume_final1, emms_initial, emms_final, colony_initial ,colony_final ,colony_initial1,colony_final1," &
" adminbldg_initial ,adminbldg_final ,stnaux_initial ,stnaux_final, rwfgen_initial ,rwfgen_final ,pcs_initial, pcs_final, radkptcl , raddgI , radarc1 , radarc2 , radarc3 ,radpump,radMelt,radTube, radMould, radFume,rademms, " &
" radcolony,radcolony1,radadmn,radaux,radrwfgen, radpcs,CheckMeter_initial , CheckMeter_final , radCheckMeter) " &
" VALUES ( @consumption_date , @kptcl_initial , @kptcl_final , @dg_gen1_initial , @dg_gen1_final ,@arc1_initial,@arc1_final,@arc2_initial,@arc2_final,@arc3_initial,@arc3_final,@pumphouse_initial,@pumphouse_final,@Melt_initial,@Melt_final," &
" @Tube_initial,@Tube_final,@Mould_initial,@Mould_final,@Fume_initial,@Fume_final,@emms_initial, @emms_final,@colony12_initial , @colony12_final ,@colony34_initial , @colony34_final ,@adminbldg_initial , @adminbldg_final , " &
" @stnaux_initial , @stnaux_final ,@rwfgen_initial , @rwfgen_final ,@pcs_initial, @pcs_final,@radkptcl , @raddgI,@radarc1 , @radarc2 , @radarc3 ,@radpump, @radMelt,@radTube,@radMould,@radFume, @rademms ,@radcolony12 ," &
" @radcolony34 ,@radadmn , @radaux ,@radrwfgen ,@radpcs, @CheckMeter_initial , @CheckMeter_final , @radCheckMeter ) "

                Try
                    If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" insert into ms_Admin_energy_consumption failed ")
                Catch exp As Exception
                    Throw New Exception(" Insert into ms_admin_energy_consumption error " & exp.Message)
                End Try
            End Sub

            Private Sub AdminEnergyConsumptionEdit(ByRef CMD As SqlClient.SqlCommand)
                CMD.CommandText = " update ms_admin_energy_consumption set kptcl_initial=@kptcl_initial,kptcl_final=@kptcl_final," &
                            " dg_gen1_initial = @dggen1_initial, dg_gen1_final = @dggen1_final , arc1_initial=@arc1_initial," &
                            " arc1_final=@arc1_final,arc2_initial=@arc2_initial,arc2_final=@arc2_final,arc3_initial=@arc3_initial," &
                            " arc3_final=@arc3_final,pumphouse_initial=@pumphouse_initial,pumphouse_final=@pumphouse_final," &
                " Melt_initial=@Melt_initial, Melt_final1=@Melt_final,Tube_initial=@Tube_initial, Tube_final1=@Tube_final," &
                " Mould_initial=@Mould_initial, Mould_final1=@Mould_final,Fume_initial=@Fume_initial, Fume_final1=@Fume_final," &
                " emms_initial=@emms_initial,emms_final=@emms_final,colony_initial=@colony12_initial,colony_final=@colony12_final," &
                            " colony_initial1=@colony34_initial,colony_final1=@colony34_final,adminbldg_initial=@adminbldg_initial,adminbldg_final=@adminbldg_final," &
                            " stnaux_initial=@stnaux_initial,stnaux_final=@stnaux_final,rwfgen_initial = @rwfgen_initial , rwfgen_final = @rwfgen_final,pcs_initial=@pcs_initial , pcs_final= @pcs_final , " &
                            " radkptcl =  @radkptcl , raddgI = @raddgI, radarc1 = @radarc1 ,radarc2  = @radarc2 , radarc3  = @radarc3 ," &
                            " radpump = @radpump, radMelt=@radMelt,@radMould=radMould,@radFume=radFume,radTube=@radTube,rademms =  @rademms , " &
                            " radcolony = @radcolony12 , radcolony1 = @radcolony34 ,radadmn  = @radadmn, radaux = @radaux ,radrwfgen = @radrwfgen , " &
                            " radpcs = @radpcs , CheckMeter_initial = @CheckMeter_initial , CheckMeter_final = @CheckMeter_final , radCheckMeter = @radCheckMeter " &
                            " where consumption_date= @consumption_date "
                Try
                    If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to update ms_Admin_energy_consumption Details ")
                Catch exp As Exception
                    Throw New Exception(" update of ms_Admin_energy_consumption error :  " & exp.Message)
                End Try
            End Sub

            'Private Sub AdminEnergyConsumptionEdit(ByRef CMD As SqlClient.SqlCommand)
            '    CMD.CommandText = " update ms_admin_energy_consumption set kptcl_initial=@kptcl_initial,kptcl_final=@kptcl_final," &
            '                " dg_gen1_initial = @dggen1_initial, dg_gen1_final = @dggen1_final , arc1_initial=@arc1_initial," &
            '                " arc1_final=@arc1_final,arc2_initial=@arc2_initial,arc2_final=@arc2_final,arc3_initial=@arc3_initial," &
            '                " arc3_final=@arc3_final,pumphouse_initial=@pumphouse_initial,pumphouse_final=@pumphouse_final," &
            '    " Melt_initial=@Melt_initial, Melt_final1=@Melt_final,Tube_initial=@Tube_initial, Tube_final1=@Tube_final," &
            '    " Mould_initial=@Mould_initial, Mould_final1=@Mould_final,Fume_initial=@Fume_initial, Fume_final1=@Fume_final," &
            '    " emms_initial=@emms_initial,emms_final=@emms_final,colony_initial=@colony12_initial,colony_final=@colony12_final," &
            '                " colony_initial1=@colony34_initial,colony_final1=@colony34_final,adminbldg_initial=@adminbldg_initial,adminbldg_final=@adminbldg_final," &
            '                " stnaux_initial=@stnaux_initial,stnaux_final=@stnaux_final,rwfgen_initial = @rwfgen_initial , rwfgen_final = @rwfgen_final,pcs_initial=@pcs_initial , pcs_final= @pcs_final , " &
            '                " radkptcl =  @radkptcl , raddgI = @raddgI, radarc1 = @radarc1 ,radarc2  = @radarc2 , radarc3  = @radarc3 ," &
            '                " radpump = @radpump, radMelt=@radMelt,@radMould=radMould,@radFume=radFume,radTube=@radTube,rademms =  @rademms , " &
            '                " radcolony = @radcolony12 , radcolony1 = @radcolony34 ,radadmn  = @radadmn, radaux = @radaux ,radrwfgen = @radrwfgen , " &
            '                " radpcs = @radpcs , CheckMeter_initial = @CheckMeter_initial , CheckMeter_final = @CheckMeter_final , radCheckMeter = @radCheckMeter " &
            '                " where consumption_date= @consumption_date "
            '    Try
            '        If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to update ms_Admin_energy_consumption Details ")
            '    Catch exp As Exception
            '        Throw New Exception(" update of ms_Admin_energy_consumption error :  " & exp.Message)
            '    End Try
            'End Sub
            Private Sub AdminEnergyConsumptionDelete(ByRef CMD As SqlClient.SqlCommand)
                CMD.CommandText = " delete from ms_Admin_energy_consumption  where consumption_date = @consumption_date "
                Try
                    If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to delete Admin_energy_consumption Details ")
                Catch exp As Exception
                    Throw New Exception(" delete of ms_Admin_energy_consumption error :  " & exp.Message)
                End Try
            End Sub
            Public Function SaveTODEnergyConsumption(ByVal ConsumptionDate As Date, Optional ByVal Delete As Boolean = False) As Boolean
                Dim blnDone As Boolean

                Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj

                cmd.Parameters.Add("@consumption_date", SqlDbType.SmallDateTime, 4)
                cmd.Parameters("@consumption_date").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@C0_initial", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@C0_initial").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@C0_final", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@C0_final").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@C1_initial", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@C1_initial").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@C1_final", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@C1_final").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@C2_initial", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@C2_initial").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@C2_final", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@C2_final").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@radC0", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@radC0").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@radC1", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@radC1").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@radC2", SqlDbType.Decimal, 10, 2)
                cmd.Parameters("@radC2").Direction = ParameterDirection.Input

                cmd.Parameters.Add("@remarks_C0", SqlDbType.VarChar, 500)
                cmd.Parameters("@remarks_C0").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@remarks_C1", SqlDbType.VarChar, 500)
                cmd.Parameters("@remarks_C1").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@remarks_C2", SqlDbType.VarChar, 500)
                cmd.Parameters("@remarks_C2").Direction = ParameterDirection.Input
                Try
                    cmd.Parameters("@consumption_date").Value = Me.ConsumptionDate

                    cmd.Parameters("@C0_initial").Value = Me.TR(34).Reading.initial
                    cmd.Parameters("@C0_final").Value = Me.TR(34).Reading.final
                    cmd.Parameters("@C1_initial").Value = Me.TR(35).Reading.initial
                    cmd.Parameters("@C1_final").Value = Me.TR(35).Reading.final
                    cmd.Parameters("@C2_initial").Value = Me.TR(36).Reading.initial
                    cmd.Parameters("@C2_final").Value = Me.TR(36).Reading.final

                    cmd.Parameters("@radC0").Value = Me.TR(34).Reading.rad
                    cmd.Parameters("@radC1").Value = Me.TR(35).Reading.rad
                    cmd.Parameters("@radC2").Value = Me.TR(36).Reading.rad

                    cmd.Parameters("@remarks_C0").Value = Me.TR(34).Reading.Remarks
                    cmd.Parameters("@remarks_C1").Value = Me.TR(35).Reading.Remarks
                    cmd.Parameters("@remarks_C2").Value = Me.TR(36).Reading.Remarks

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
                    Dim RecID As Long

                    cmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                    cmd.CommandText = " select @cnt = count(*) from ms_TODReadings where consumption_date = @consumption_date"
                    Try
                        cmd.ExecuteScalar()
                        RecID = IIf(IsDBNull(cmd.Parameters("@cnt").Value), 0, cmd.Parameters("@cnt").Value)
                    Catch exp As Exception
                        Throw New Exception(exp.Message)
                    End Try

                    If RecID > 0 Then
                        cmd.Parameters("@consumption_date").Direction = ParameterDirection.Input
                        If Delete = False Then
                            TODEnergyConsumptionEdit(cmd)
                            blnDone = True
                        Else
                            TODEnergyConsumptionDelete(cmd)
                            blnDone = True
                        End If
                    Else
                        If Delete = False Then TODEnergyConsumptionAdd(cmd)
                        blnDone = True
                    End If
                Catch exp As Exception
                    Throw New Exception(exp.Message)
                    sMessage = exp.Message
                Finally
                    If blnDone = True Then
                        cmd.Transaction.Commit()
                        sMessage = "Record Saved !"
                    Else
                        cmd.Transaction.Rollback()
                        sMessage = "Record Not Saved !"
                    End If
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                End Try
                Return blnDone
            End Function
            Private Sub TODEnergyConsumptionAdd(ByRef CMD As SqlClient.SqlCommand)
                CMD.CommandText = "insert into ms_TODReadings ( consumption_date ,  C0_initial , C0_final , " &
                           " C1_initial , C1_final , C2_initial , C2_final , radC0 , radC1 , radC2 , " &
                           " remarks_C0 , remarks_C1 , remarks_C2 ) " &
                           " VALUES ( @consumption_date , @C0_initial , @C0_final , " &
                           " @C1_initial , @C1_final , @C2_initial , @C2_final , @radC0 , @radC1 , @radC2 , " &
                           " @remarks_C0 , @remarks_C1 , @remarks_C2 ) "
                Try
                    If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" insert into ms_TODReadings failed ")
                Catch exp As Exception
                    Throw New Exception(" Insert into ms_Admin_energy_consumption error " & exp.Message)
                End Try
            End Sub
            Private Sub TODEnergyConsumptionEdit(ByRef CMD As SqlClient.SqlCommand)
                CMD.CommandText = " update ms_TODReadings set C0_initial = @C0_initial , C0_final = @C0_final ," &
                            " C1_initial = @C1_initial ,  C1_final = @C1_final , C2_initial = @C2_initial ,  C2_final = @C2_final ," &
                            " radC0 = @radC0 , radC1 = @radC1 , radC2 = @radC2 , " &
                            " remarks_C0 = @remarks_C0 , remarks_C1 = @remarks_C1 , remarks_C2 = @remarks_C2 " &
                            " where consumption_date = @consumption_date "
                Try
                    If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to update ms_TODReadings ")
                Catch exp As Exception
                    Throw New Exception(" update of ms_TODReadings error :  " & exp.Message)
                End Try
            End Sub
            Private Sub TODEnergyConsumptionDelete(ByRef CMD As SqlClient.SqlCommand)
                CMD.CommandText = " delete from ms_TODReadings  where consumption_date = @consumption_date "
                Try
                    If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to delete ms_TODReadings Details ")
                Catch exp As Exception
                    Throw New Exception(" delete of ms_TODReadings error :  " & exp.Message)
                End Try
            End Sub
            <Serializable()> Public Class Transformer
                Private sTransformerName As String
                Private oReadings As Readings
                Public Sub New(ByVal TransformerName As String)
                    sTransformerName = TransformerName
                    oReadings = New Readings()
                End Sub
                ReadOnly Property Name() As String
                    Get
                        Return sTransformerName
                    End Get
                End Property
                ReadOnly Property Reading() As Readings
                    Get
                        Return oReadings
                    End Get
                End Property
                <Serializable()> Public Class Readings
                    Private deciRad, deciInitial, deciFinal As Decimal
                    Private sRemarks As String
                    Public Sub New()
                        InitVars()
                    End Sub
                    Private Sub InitVars()
                        deciRad = 0.0
                        deciInitial = 0.0
                        deciFinal = 0.0
                        sRemarks = ""
                    End Sub
                    Property Remarks() As String
                        Get
                            Return sRemarks
                        End Get
                        Set(ByVal Value As String)
                            sRemarks = Value
                        End Set
                    End Property
                    Property rad() As Decimal
                        Get
                            Return deciRad
                        End Get
                        Set(ByVal Value As Decimal)
                            deciRad = Value
                        End Set
                    End Property
                    Property initial() As Decimal
                        Get
                            Return deciInitial
                        End Get
                        Set(ByVal Value As Decimal)
                            deciInitial = Value
                        End Set
                    End Property
                    Property final() As Decimal
                        Get
                            Return deciFinal
                        End Get
                        Set(ByVal Value As Decimal)
                            deciFinal = Value
                        End Set
                    End Property
                    ReadOnly Property units() As Decimal
                        Get
                            Return ((deciFinal - deciInitial) * deciRad)
                        End Get
                    End Property
                    ReadOnly Property diff() As Decimal
                        Get
                            Return (deciFinal - deciInitial)
                        End Get
                    End Property
                End Class
            End Class
#End Region
        End Class
#End Region
    End Class
End Namespace