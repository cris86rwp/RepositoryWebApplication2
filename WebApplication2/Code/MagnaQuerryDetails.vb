Namespace RWF
    Public Class MagnaQuerryDetails
        Public Shared Function MagnaDailyPosition(ByVal FromDate As Date, ByVal ToDate As Date, ByVal Shift As String) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "mm_sp_MagnaDailyPosition"
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.SmallDateTime, 4).Value = FromDate
            da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.SmallDateTime, 4).Value = ToDate
            da.SelectCommand.Parameters.Add("@Shift", SqlDbType.VarChar, 3).Value = Shift
            Try
                da.Fill(ds)
                MagnaDailyPosition = ds.Tables(0).Copy
            Catch exp As Exception
                MagnaDailyPosition = Nothing
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function WheelsNotPostedAtMagna(ByVal FromDate As Date, ByVal ToDate As Date, ByVal WithRM As Int16) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "mm_sp_WheelsPostedAtMagnaAsMRXC"
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.SmallDateTime, 4).Value = FromDate
            da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.SmallDateTime, 4).Value = ToDate
            da.SelectCommand.Parameters.Add("@WithRM", SqlDbType.Int, 4).Value = WithRM
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
        Public Shared Function MagnaDailyAnalysis(ByVal Type As Int16, ByVal MagDate As Date, ByVal Shift As String, ByVal Line As String) As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            da.SelectCommand = New SqlClient.SqlCommand()
            da.SelectCommand.Connection = rwfGen.Connection.ConObj
            da.SelectCommand.CommandTimeout = 60 * 60
            Dim ds As New DataSet()
            If Type = 1 Then
                da.SelectCommand.CommandText = "mm_sp_magnaAnalysis"
            ElseIf Type = 2 Then
                da.SelectCommand.CommandText = "mm_sp_magnascoreNew"
            ElseIf Type = 3 Then
                da.SelectCommand.CommandText = "mm_sp_magnaSummary"
            ElseIf Type = 4 Then
                da.SelectCommand.CommandText = "mm_sp_magnaOffload"
            ElseIf Type = 5 Then
                da.SelectCommand.CommandText = "mm_sp_magnaDetails"
            ElseIf Type = 6 Then
                da.SelectCommand.CommandText = "mm_sp_magnaMagCalibration"
            ElseIf Type = 7 Then
                da.SelectCommand.CommandText = "mm_sp_magnaUTCalibration"
            ElseIf Type = 8 Then
                da.SelectCommand.CommandText = "mm_sp_magnaBHNCalibration"
            ElseIf Type = 9 Then
                da.SelectCommand.CommandText = "mm_sp_magnaUVCalibration"
            End If

            da.SelectCommand.CommandType = CommandType.StoredProcedure
            Try
                da.SelectCommand.Parameters.Add("@Date", SqlDbType.SmallDateTime, 4).Value = CDate(MagDate)
                da.SelectCommand.Parameters.Add("@Shift", SqlDbType.VarChar, 3).Value = Shift
                da.SelectCommand.Parameters.Add("@linenumber", SqlDbType.VarChar, 3).Value = Line
                da.Fill(ds)
                MagnaDailyAnalysis = ds.Tables(0).Copy
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function MagnaWhlTypeSummary(ByVal FromDate As Date, ByVal ToDate As Date, ByVal FrHt As Long, ByVal ToHt As Long, ByVal Shift As String, ByVal Line As String, ByVal Type As Int16) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.SmallDateTime, 4).Value = FromDate
            da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.SmallDateTime, 4).Value = ToDate
            da.SelectCommand.Parameters.Add("@frht", SqlDbType.BigInt, 8).Value = FrHt
            da.SelectCommand.Parameters.Add("@toht", SqlDbType.BigInt, 8).Value = ToHt
            da.SelectCommand.Parameters.Add("@Shift", SqlDbType.VarChar, 3).Value = Shift
            da.SelectCommand.Parameters.Add("@Line", SqlDbType.VarChar, 3).Value = Line
            da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = Type
            Try
                da.SelectCommand.CommandText = "mm_sp_MagnaWhlTypeSummary"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
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
        Public Shared Function GetProductType(ByVal Dt As Date) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = "SELECT DISTINCT ltrim(rtrim(productType)) productType  FROM mm_pink_sheet_rej WHERE rpt_date = @dt and producttype <> ''"
                da.SelectCommand.Parameters.Add("@dt", SqlDbType.SmallDateTime, 4).Value = Dt
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
        Public Shared Function MagnaPinkXC(ByVal Type As Integer, ByVal FromDate As Date, ByVal ToDate As Date, ByVal FrHt As Long, ByVal ToHt As Long) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.Parameters.Add("@frdt", SqlDbType.SmallDateTime, 4).Value = FromDate
            da.SelectCommand.Parameters.Add("@todt", SqlDbType.SmallDateTime, 4).Value = ToDate
            da.SelectCommand.Parameters.Add("@frht", SqlDbType.BigInt, 8).Value = FrHt
            da.SelectCommand.Parameters.Add("@toht", SqlDbType.BigInt, 8).Value = ToHt
            da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = Type
            Try
                da.SelectCommand.CommandText = "mm_sp_MagnaPinkXC"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
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
        Public Shared Function MagnaMCNOffloads(ByVal Type As Integer, ByVal FromDate As Date, ByVal ToDate As Date, ByVal FrHt As Long, ByVal ToHt As Long) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.Parameters.Add("@frdt", SqlDbType.SmallDateTime, 4).Value = FromDate
            da.SelectCommand.Parameters.Add("@todt", SqlDbType.SmallDateTime, 4).Value = ToDate
            da.SelectCommand.Parameters.Add("@frht", SqlDbType.BigInt, 8).Value = FrHt
            da.SelectCommand.Parameters.Add("@toht", SqlDbType.BigInt, 8).Value = ToHt
            da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = Type
            Try
                da.SelectCommand.CommandText = "mm_sp_MagnaMCNOffloads"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.CommandTimeout = 60 * 60
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
        Public Shared Function MagnaOffloads(ByVal Querry As Integer, ByVal FromDate As Date, ByVal ToDate As Date) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim Type As Integer
            Select Case Querry
                Case 4
                    Type = 0
                Case 5
                    Type = 1
                Case 6
                    Type = 2
                Case 7
                    Type = 3
            End Select
            da.SelectCommand.Parameters.Add("@frdt", SqlDbType.SmallDateTime, 4).Value = FromDate
            da.SelectCommand.Parameters.Add("@todt", SqlDbType.SmallDateTime, 4).Value = ToDate
            da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = Type
            Try
                da.SelectCommand.CommandText = "mm_sp_MagnaOffLoadDetails"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.CommandTimeout = 60 * 60
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
