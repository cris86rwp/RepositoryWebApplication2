Namespace RWF
    Public Class FIQuerryDetails
        Public Shared Function DespatchList(ByVal FromDate As Date, ByVal ToDate As Date, ByVal Type As Integer) As DataTable
            Select Case Type
                Case 17
                    Type = 0
                Case 18
                    Type = 1
                Case 19
                    Type = 2
                Case 20
                    Type = 3
                Case 21
                    Type = 4
                Case 22
                    Type = 5
                Case 27
                    Type = 6
                Case 28
                    Type = 7
            End Select
            Dim da As SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            da = rwfGen.Connection.Adapter
            da = rwfGen.Connection.Adapter
            da.SelectCommand.Parameters.Add("@FrDt", SqlDbType.SmallDateTime, 4).Value = FromDate
            da.SelectCommand.Parameters.Add("@ToDt", SqlDbType.SmallDateTime, 4).Value = ToDate
            da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = Type
            da.SelectCommand.CommandText = "mm_sp_DespatchList"
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            Try
                da.Fill(ds)
                DespatchList = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function SieveAnalysis(ByVal FromDate As Date, ByVal ToDate As Date) As DataTable
            Dim da As SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            da = rwfGen.Connection.Adapter
            da = rwfGen.Connection.Adapter
            da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.SmallDateTime, 4).Value = FromDate
            da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.SmallDateTime, 4).Value = ToDate
            da.SelectCommand.CommandText = "mm_sp_SieveAnalysis"
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            Try
                da.Fill(ds)
                SieveAnalysis = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function ClosureValues(ByVal FromDate As Date, ByVal ToDate As Date) As DataTable
            Dim da As SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            da = rwfGen.Connection.Adapter
            da.SelectCommand.Parameters.Add("@frDate", SqlDbType.SmallDateTime, 4).Value = FromDate
            da.SelectCommand.Parameters.Add("@toDate", SqlDbType.SmallDateTime, 4).Value = ToDate
            da.SelectCommand.CommandText = "mm_sp_ClosureValues"
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            Try
                da.Fill(ds)
                ClosureValues = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function QCIReClaimedWheels(ByVal FromDate As Date, ByVal ToDate As Date) As DataTable
            Dim da As SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            da = rwfGen.Connection.Adapter
            da.SelectCommand.Parameters.Add("@fr", SqlDbType.SmallDateTime, 4).Value = FromDate
            da.SelectCommand.Parameters.Add("@to", SqlDbType.SmallDateTime, 4).Value = ToDate
            da.SelectCommand.CommandText = "select row_number() over ( order by  heat_number , wheel_number ) SlNo , " & _
                " convert(varchar(11),inspection_date,103) InspDate , shift_code Sh , " & _
                " wheel_number Whl , heat_number Ht , pre_status PreSts , wheel_disposition Sts " & _
                " from mm_qci_inspection where inspection_date between @fr and @to and remarks_qci <> 'WheelForReMelt' " & _
                " order by  heat_number , wheel_number "
            Try
                da.Fill(ds)
                QCIReClaimedWheels = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function StockedNotTestedInFI(ByVal FromDate As Date, ByVal ToDate As Date) As DataTable
            Dim da As SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            da = rwfGen.Connection.Adapter
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.CommandText = "mm_sp_StockedNotTestedInFinal"
            da.SelectCommand.Parameters.Add("@frdate", SqlDbType.SmallDateTime, 4).Value = FromDate
            da.SelectCommand.Parameters.Add("@todate", SqlDbType.SmallDateTime, 4).Value = ToDate
            Try
                da.Fill(ds)
                StockedNotTestedInFI = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function WheelSetQuerry(ByVal QuerryID As Int16, ByVal frdate As Date, ByVal todate As Date) As DataTable
            Dim da As SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            da = rwfGen.Connection.Adapter
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.CommandText = "mm_sp_WheelSetInspectionQuerry"
            da.SelectCommand.Parameters.Add("@frdt", SqlDbType.SmallDateTime, 4).Value = frdate
            da.SelectCommand.Parameters.Add("@todt", SqlDbType.SmallDateTime, 4).Value = todate
            Select Case QuerryID
                Case 8
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 0
                Case 9
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 1
                Case 10
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 2
                Case 11
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 3
                Case 12
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 4
                Case 13
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 5
                Case 14
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 6
                Case 24
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 7
            End Select

            Try
                da.Fill(ds)
                WheelSetQuerry = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function FIQuerry(ByVal QuerryID As Int16, ByVal frdate As Date, ByVal todate As Date, ByVal Shift As String, ByVal Type As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            da = rwfGen.Connection.Adapter
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.CommandText = "mm_sp_FIQuerry"
            da.SelectCommand.Parameters.Add("@frdate", SqlDbType.SmallDateTime, 4).Value = frdate
            da.SelectCommand.Parameters.Add("@todate", SqlDbType.SmallDateTime, 4).Value = todate
            da.SelectCommand.Parameters.Add("@Shift", SqlDbType.VarChar, 3).Value = Shift
            Select Case QuerryID
                Case 2
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.VarChar, 50).Value = "Passed"
                Case 3
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.VarChar, 50).Value = "Rejected"
                Case 4
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.VarChar, 50).Value = "Rework"
                Case 5
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.VarChar, 50).Value = "UnboreDetail"
                Case 6
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.VarChar, 50).Value = "UnboreSummary"
                Case 23
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.VarChar, 50).Value = "Yard Wheels"
                Case 25
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.VarChar, 50).Value = "MCN Wheels Details"
                Case 26
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.VarChar, 50).Value = "MCN Wheels Summary"
            End Select

            Try
                da.Fill(ds)
                FIQuerry = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
    End Class
End Namespace
