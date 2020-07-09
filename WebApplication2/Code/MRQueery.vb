Namespace RWF
    Public Class MRQuerry
        Public Shared Function MRDataCorrection(ByVal Dt As Date) As Integer
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.CommandText = "mm_sp_MRDataCorrection"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@MrDt", SqlDbType.SmallDateTime, 4).Value = Dt
            Try
                cmd.Connection.Open()
                MRDataCorrection = cmd.ExecuteNonQuery
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If IsNothing(cmd) = False Then
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                End If
            End Try
        End Function
        Public Shared Function DateRangeData(ByVal FromDate As Date, ByVal ToDate As Date, ByVal Type As Integer) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "mm_sp_MRDateRangeData"
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.Add("@FrDt", SqlDbType.SmallDateTime, 4).Value = FromDate
            da.SelectCommand.Parameters.Add("@ToDt", SqlDbType.SmallDateTime, 4).Value = ToDate
            da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = Type
            Try
                da.Fill(ds)
                Return ds.Tables(0).Copy
            Catch exp As Exception
                Throw New Exception("Data Retrieval Error : " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function RejectionCodewiseDetails(ByVal XC As Integer, ByVal FrHt As Long, ByVal ToHt As Long, ByVal Type As Integer) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                If Type = 8 Then
                    Type = 0
                Else
                    Type = 1
                End If
                da.SelectCommand.CommandText = "mm_sp_RejectionCodewiseDetails"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.Add("@XC", SqlDbType.VarChar, 50).Value = XC
                da.SelectCommand.Parameters.Add("@frHeat", SqlDbType.BigInt, 8).Value = FrHt
                da.SelectCommand.Parameters.Add("@toHeat", SqlDbType.BigInt, 8).Value = ToHt
                da.SelectCommand.Parameters.Add("@Type", SqlDbType.BigInt, 8).Value = Type
                da.Fill(ds)
                Return ds.Tables(0).Copy
            Catch exp As Exception
                Throw New Exception("Data Retrieval Error : " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function RejectionProducingCopes(ByVal FrHt As Long, ByVal ToHt As Long) As DataSet
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = "mm_sp_RejectionProducingCopes"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.Add("@FrHt", SqlDbType.BigInt, 8).Value = FrHt
                da.SelectCommand.Parameters.Add("@ToHt", SqlDbType.BigInt, 8).Value = ToHt
                da.SelectCommand.CommandTimeout = 3600
                da.Fill(ds)
                Return ds.Copy
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function HeatRangeData(ByVal Type As Integer, ByVal FrHt As Long, ByVal ToHt As Long) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = "mm_sp_MRHeatRangeData"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = Type
                da.SelectCommand.Parameters.Add("@FrHt", SqlDbType.BigInt, 8).Value = FrHt
                da.SelectCommand.Parameters.Add("@ToHt", SqlDbType.BigInt, 8).Value = ToHt
                da.SelectCommand.CommandTimeout = 3600
                da.Fill(ds)
                Return ds.Tables(0).Copy
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function MRBreak(ByVal FromDate As String, ByVal ToDate As String, ByVal FiledName As String) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = " SELECT row_number() over ( order by ms_breakdown_memo." & FiledName.Trim & ") Sl, " & _
                " ms_breakdown_memo.memo_number MemoNo, ms_breakdown_memo.memo_slip_number SlipNo, ms_breakdown_memo.operator , " & _
                " ms_breakdown_memo.shift_code Shf, ms_breakdown_memo.machine_code Machine , ms_machinery_master.description Descr , " & _
                " ms_breakdown_memo.breakdown_from_time FrTime, ms_breakdown_memo.breakdown_to_time ToTime, ms_breakdown_memo.remarks Remarks, " & _
                " ms_breakdown_memo.production_affected Affd  " & _
                " FROM wap.dbo.ms_breakdown_memo ms_breakdown_memo inner join wap.dbo.ms_machinery_master ms_machinery_master " & _
                " on ms_breakdown_memo.machine_code = ms_machinery_master.machine_code " & _
                " WHERE ms_breakdown_memo.breakdown_from_time >= @frdt AND " & _
                " ms_breakdown_memo.breakdown_from_time < @todt AND " & _
                " (ms_breakdown_memo.machine_code LIKE 'MO%' OR  ms_breakdown_memo.machine_code LIKE 'RT%' AND " & _
                " ms_breakdown_memo.maintenance_group = 'MLDING') ORDER BY ms_breakdown_memo." & FiledName.Trim & "  ASC "
            da.SelectCommand.Parameters.Add("@frdt", SqlDbType.SmallDateTime, 4).Value = CDate(FromDate & " " & "06:00:00")
            da.SelectCommand.Parameters.Add("@todt", SqlDbType.SmallDateTime, 4).Value = CDate(ToDate & " " & "06:00:00")

            Try
                da.Fill(ds)
                Return ds.Tables(0).Copy
            Catch exp As Exception
                Throw New Exception("Data Retrieval Error : " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function ReportData(ByVal Type As Integer, ByVal Dt As Date) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                Select Case Type
                    Case 1
                        da.SelectCommand.CommandText = "mm_sp_UnqOffloads"
                    Case 2
                        da.SelectCommand.CommandText = "mm_sp_OffloadsCounts"
                    Case 3
                        da.SelectCommand.CommandText = "mm_sp_UnqOffloadCount"
                    Case 4
                        da.SelectCommand.CommandText = "mm_sp_CRXCDetails"
                    Case 5
                        da.SelectCommand.CommandTimeout = 60 * 60
                        da.SelectCommand.CommandText = "mm_sp_WFPSOutTurn"
                    Case 6
                        da.SelectCommand.CommandText = "mm_sp_SprueGrindingOutTurn"
                    Case 7
                        da.SelectCommand.CommandText = "mm_sp_CRXCSummary"
                    Case 8
                        da.SelectCommand.CommandText = "mm_sp_HeatSummary"
                    Case 9
                        da.SelectCommand.CommandTimeout = 60 * 60
                        da.SelectCommand.CommandText = "mm_sp_PouringDetails"
                    Case 10
                        da.SelectCommand.CommandText = "mm_sp_GrindingDetails"
                    Case 11
                        da.SelectCommand.CommandText = "mm_sp_Top30IngMldLife"
                    Case 12
                        da.SelectCommand.CommandText = "mm_sp_HeatDetails"
                    Case 13
                        da.SelectCommand.CommandText = "mm_sp_MRXCDetails"
                    Case 14
                        da.SelectCommand.CommandText = "mm_sp_MRBreakDown"
                    Case 15
                        da.SelectCommand.CommandText = "mm_sp_CRXCSummaryShiftWise" '
                    Case 16
                        da.SelectCommand.CommandText = "mm_sp_UnqOffloadsSICwise"
                    Case 17
                        da.SelectCommand.CommandText = "mm_sp_PourStartTimeEdit"
                End Select
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.Add("@MrDt", SqlDbType.SmallDateTime, 4).Value = Dt
                da.Fill(ds)
                Return ds.Tables(0).Copy
            Catch exp As Exception
                Throw New Exception("Data Retrieval Error : " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
    End Class
End Namespace
