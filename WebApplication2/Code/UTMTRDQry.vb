Namespace AxleProcessing
    <Serializable()> Public Class UTMTRDQry
        Public Shared Function GetUTScoreAndData(ByVal UTDate As Date, ByVal UTShift As String, ByVal Type As String) As DataSet
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.Parameters.Add("@dt", SqlDbType.SmallDateTime, 4).Value = UTDate
            da.SelectCommand.Parameters.Add("@sh", SqlDbType.VarChar, 1).Value = UTShift
            Try
                If Type = "UT" Then
                    da.SelectCommand.CommandText = "select row_number() over ( order by sl_no ) Sl , " & _
                        " convert(varchar(10),test_date,103) TestDt , " & _
                        " shift_code Sh , axle_number AxleNo , drawing_number DrawingNumber , cast_number CastNo , " & _
                        " Cast_status CastSts , Ut_Status UtSts , operator_east EastOp , OPerator_west WestOp , " & _
                        " supplier,  Ut_remarks UTRemarks , Specification_group SpnGrp ,  RHT_Remarks  RHTRemarks " & _
                        " from mm_axle_test_results_ut where test_date = @dt and shift_code = @sh order by sl_no ; " & _
                        " select sum(1) Tested, sum(case when ut_status like 'p%' then 1 else 0 end ) Passed , " & _
                        " sum(case when ut_status like 'r%' then 1 else 0 end ) Rejected, sum(case when ut_status like 'w%' then 1 else 0 end ) RHT, " & _
                        " sum(case when ut_status like 'd%' then 1 else 0 end ) SourceRej , " & _
                        " sum(case when ut_status like 's%' then 1 else 0 end ) NonSourceRej , " & _
                        " sum(case when ut_status like 'o%' then 1 else 0 end ) Others  " & _
                        " from mm_axle_test_results_ut where test_date = @dt and shift_code = @sh   "
                Else
                    da.SelectCommand.CommandText = "select row_number() over ( order by sl_no ) Sl , " & _
                        " convert(varchar(10),mpt_test_date,103) TestDt  , " & _
                        " shift_code Sh , axle_number AxleNo , drawing_number DrawingNumber , cast_number CastNo , " & _
                        " mpt_status MPTSts , Ut_Status UtSts , operator_code Operator " & _
                        " from mm_axle_mpt_test_results where mpt_test_date = @dt and shift_code = @sh order by sl_no ; " & _
                        " select sum(1) Tested, sum(case when mpt_status like 'p%' then 1 else 0 end ) Passed , " & _
                        " sum(case when mpt_status like 'r%' then 1 else 0 end ) Rejected, " & _
                        " sum(case when mpt_status like 'w%' then 1 else 0 end ) Hold " & _
                        " from mm_axle_mpt_test_results where mpt_test_date = @dt and shift_code = @sh   "
                End If

                da.Fill(ds)
                Return ds
            Catch exp As Exception
                Return Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function RadData(ByVal FromDt As Date, ByVal ToDt As Date, ByVal group As Int16) As DataTable
            Dim da1 As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds1 As New DataSet()
            da1.SelectCommand.Parameters.Add("@RadFromDate", SqlDbType.SmallDateTime, 4)
            da1.SelectCommand.Parameters("@RadFromDate").Value = FromDt
            da1.SelectCommand.Parameters.Add("@RadToDate", SqlDbType.SmallDateTime, 4)
            da1.SelectCommand.Parameters("@RadToDate").Value = ToDt
            da1.SelectCommand.Parameters.Add("@group", SqlDbType.Int, 4)
            da1.SelectCommand.Parameters("@group").Value = group
            da1.SelectCommand.CommandType = CommandType.StoredProcedure
            da1.SelectCommand.CommandText = "mm_sp_RadTestResults"
            Try
                da1.Fill(ds1, "SavedData")
                Return ds1.Tables(0)
            Catch exp As Exception
                Return Nothing
                Throw New Exception("Data Save Grid Error: " & exp.Message)
            Finally
                da1.Dispose()
                ds1.Dispose()
                da1 = Nothing
                ds1 = Nothing
            End Try
        End Function
        Public Shared Function GetUTMPTScoreAndData(ByVal UTDate As Date, ByVal UTShift As String, ByVal Type As Integer, ByVal Machine As String) As DataSet
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.Parameters.Add("@dt", SqlDbType.SmallDateTime, 4).Value = UTDate
            da.SelectCommand.Parameters.Add("@sh", SqlDbType.VarChar, 1).Value = UTShift
            da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = Type
            da.SelectCommand.Parameters.Add("@Machine", SqlDbType.VarChar, 10).Value = Machine
            Try
                da.SelectCommand.CommandText = "mm_sp_UTMPTScoreAndData"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.Fill(ds)
                Return ds
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
        Public Shared Function UTMTRDQryList(ByVal FrDt As Date, ByVal ToDt As Date, ByVal QrType As Integer) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = "mm_sp_UTMTRDQry"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.SmallDateTime, 4).Value = FrDt
                da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.SmallDateTime, 4).Value = ToDt
                da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = QrType
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
        Public Shared Function UTMPTAxles(ByVal FrDt As Date, ByVal ToDt As Date, ByVal QrType As Integer) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                Select Case QrType
                    Case 100
                        da.SelectCommand.CommandText = "mm_sp_ExcludedAxlesFromUTTest"
                    Case Else
                        QrType = 1
                End Select
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.Add("@frDt", SqlDbType.SmallDateTime, 4).Value = FrDt
                da.SelectCommand.Parameters.Add("@toDt", SqlDbType.SmallDateTime, 4).Value = ToDt
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
        Public Shared Function AxleRejection(ByVal TestType As String, ByVal FrDt As Date, ByVal ToDt As Date, ByVal QrType As Integer, ByVal Operator1 As String) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                Select Case QrType
                    Case 1, 2, 3
                        QrType = 0
                    Case Else
                        QrType = 1
                End Select
                da.SelectCommand.CommandText = "mm_sp_OperatorWiseUTMTRDRejections"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.Add("@frDt", SqlDbType.SmallDateTime, 4).Value = FrDt
                da.SelectCommand.Parameters.Add("@toDt", SqlDbType.SmallDateTime, 4).Value = ToDt
                da.SelectCommand.Parameters.Add("@TestType", SqlDbType.VarChar, 1).Value = TestType
                da.SelectCommand.Parameters.Add("@QrType", SqlDbType.Int, 4).Value = QrType
                da.SelectCommand.Parameters.Add("@Operator", SqlDbType.VarChar, 6).Value = Operator1
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
        Public Shared Function GetBatchNumbers(ByVal OfferedDate As Date) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "select distinct left(batch_number_loose_axles, CHARINDEX('/',batch_number_loose_axles)-1) Batch" & _
                " from mm_rdso_offered_axles where offered_date  = @Dt "
            da.SelectCommand.Parameters.Add("@Dt", SqlDbType.SmallDateTime, 4).Value = OfferedDate
            Try
                da.Fill(ds)
                GetBatchNumbers = ds.Tables(0)
            Catch exp As Exception
                GetBatchNumbers = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function AxleUT(ByVal Type As Integer, ByVal FrDt As Date, ByVal ToDt As Date) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                Select Case Type
                    Case 1
                        da.SelectCommand.Parameters.Add("@UtOrRad", SqlDbType.VarChar, 1).Value = "0"
                    Case 2
                        da.SelectCommand.Parameters.Add("@UtOrRad", SqlDbType.VarChar, 1).Value = "1"
                    Case 3
                        da.SelectCommand.Parameters.Add("@UtOrRad", SqlDbType.VarChar, 1).Value = "2"
                End Select
                da.SelectCommand.CommandText = "mm_sp_UTorRADNotPassedAxlesList"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.Add("@frDt", SqlDbType.SmallDateTime, 4).Value = FrDt
                da.SelectCommand.Parameters.Add("@toDt", SqlDbType.SmallDateTime, 4).Value = ToDt
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
        Public Shared Function UTandRADSummaryReportData(ByVal Type As Integer, ByVal FrDt As Date, ByVal ToDt As Date) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = "mm_sp_UTnRADProductSizeSummary"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.Add("@fromdate", SqlDbType.SmallDateTime, 4).Value = FrDt
                da.SelectCommand.Parameters.Add("@todate", SqlDbType.SmallDateTime, 4).Value = ToDt
                da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = Type
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
