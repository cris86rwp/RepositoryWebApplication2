Public Class RMR
    Public Shared Function RMRConsumptionStatement(ByVal Consignee As String, ByVal Month As Integer, ByVal WOYear As Integer)
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "mm_sp_RMRConsumptionStatement"
        oDa.SelectCommand.CommandType = CommandType.StoredProcedure
        oDa.SelectCommand.Parameters.Add("@Month", SqlDbType.Int, 4).Value = Month
        oDa.SelectCommand.Parameters.Add("@Year", SqlDbType.Int, 4).Value = WOYear
        oDa.SelectCommand.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = Consignee
        Try
            oDa.Fill(oDs)
            RMRConsumptionStatement = oDs.Tables(0).Copy
        Catch exp As Exception
            RMRConsumptionStatement = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
            oDa = Nothing
            oDs = Nothing
        End Try
    End Function
    Public Shared Function RMRUnUsed(ByVal Consignee As String, ByVal Month As Integer, ByVal WOYear As Integer, ByVal PLNumber As String)
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "mm_sp_RMRUnUsed"
        oDa.SelectCommand.CommandType = CommandType.StoredProcedure
        oDa.SelectCommand.Parameters.Add("@Month", SqlDbType.Int, 4).Value = Month
        oDa.SelectCommand.Parameters.Add("@Year", SqlDbType.Int, 4).Value = WOYear
        oDa.SelectCommand.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = Consignee
        oDa.SelectCommand.Parameters.Add("@PLNumber", SqlDbType.VarChar, 10).Value = PLNumber
        Try
            oDa.Fill(oDs)
            RMRUnUsed = oDs.Tables(0).Copy
        Catch exp As Exception
            RMRUnUsed = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
            oDa = Nothing
            oDs = Nothing
        End Try
    End Function
    Public Shared Function RMRConsumptionEntry(ByVal Consignee As String, ByVal Month As Integer, ByVal WOYear As Integer, ByVal PLNumber As String)
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "mm_sp_RMRConsumptionEntry"
        oDa.SelectCommand.CommandType = CommandType.StoredProcedure
        oDa.SelectCommand.Parameters.Add("@Month", SqlDbType.Int, 4).Value = Month
        oDa.SelectCommand.Parameters.Add("@Year", SqlDbType.Int, 4).Value = WOYear
        oDa.SelectCommand.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = Consignee
        oDa.SelectCommand.Parameters.Add("@PLNumber", SqlDbType.VarChar, 10).Value = PLNumber
        Try
            oDa.Fill(oDs)
            RMRConsumptionEntry = oDs.Tables(0).Copy
        Catch exp As Exception
            RMRConsumptionEntry = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
            oDa = Nothing
            oDs = Nothing
        End Try
    End Function
    Public Shared Function GetRMRNumberDetails(ByVal RMR As Long, ByVal PL As String, ByVal WO As String, ByVal Month As Integer, ByVal WOYear As Integer, ByVal Consignee As String)
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "mm_sp_GetRMRNumberDetails"
        oDa.SelectCommand.CommandType = CommandType.StoredProcedure
        oDa.SelectCommand.Parameters.Add("@RMR", SqlDbType.BigInt, 8).Value = RMR
        oDa.SelectCommand.Parameters.Add("@PL", SqlDbType.VarChar, 8).Value = PL
        oDa.SelectCommand.Parameters.Add("@WO", SqlDbType.VarChar, 10).Value = WO
        oDa.SelectCommand.Parameters.Add("@Month", SqlDbType.Int, 4).Value = Month
        oDa.SelectCommand.Parameters.Add("@Year", SqlDbType.Int, 4).Value = WOYear
        oDa.SelectCommand.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = Consignee
        Try
            oDa.Fill(oDs)
            GetRMRNumberDetails = oDs.Tables(0).Copy
        Catch exp As Exception
            GetRMRNumberDetails = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
            oDa = Nothing
            oDs = Nothing
        End Try
    End Function
    Public Shared Function GetRMRPLsConsumption(ByVal PL As String, ByVal WO As String, ByVal Month As Integer, ByVal WOYear As Integer, ByVal Consignee As String)
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "mm_sp_GetRMRPLsConsumption"
        oDa.SelectCommand.CommandType = CommandType.StoredProcedure
        oDa.SelectCommand.Parameters.Add("@PL", SqlDbType.VarChar, 8).Value = PL
        oDa.SelectCommand.Parameters.Add("@WO", SqlDbType.VarChar, 10).Value = WO
        oDa.SelectCommand.Parameters.Add("@Month", SqlDbType.Int, 4).Value = Month
        oDa.SelectCommand.Parameters.Add("@Year", SqlDbType.Int, 4).Value = WOYear
        oDa.SelectCommand.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = Consignee
        Try
            oDa.Fill(oDs)
            GetRMRPLsConsumption = oDs.Tables(0).Copy
        Catch exp As Exception
            GetRMRPLsConsumption = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
            oDa = Nothing
            oDs = Nothing
        End Try
    End Function
    Public Shared Function GetRMRPLsRMRNumber(ByVal PL As String, ByVal WO As String, ByVal Month As Integer, ByVal WOYear As Integer, ByVal Consignee As String)
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "mm_sp_GetRMRPLsRMRNumber"
        oDa.SelectCommand.CommandType = CommandType.StoredProcedure
        oDa.SelectCommand.Parameters.Add("@PL", SqlDbType.VarChar, 8).Value = PL
        oDa.SelectCommand.Parameters.Add("@WO", SqlDbType.VarChar, 10).Value = WO
        oDa.SelectCommand.Parameters.Add("@Month", SqlDbType.Int, 4).Value = Month
        oDa.SelectCommand.Parameters.Add("@Year", SqlDbType.Int, 4).Value = WOYear
        oDa.SelectCommand.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = Consignee
        Try
            oDa.Fill(oDs)
            GetRMRPLsRMRNumber = oDs.Tables(0).Copy
        Catch exp As Exception
            GetRMRPLsRMRNumber = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
            oDa = Nothing
            oDs = Nothing
        End Try
    End Function
    Public Shared Function RMRPLs(ByVal Consignee As String, ByVal Month As Integer, ByVal WOYear As Integer)
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "mm_sp_RMRPLs"
        oDa.SelectCommand.CommandType = CommandType.StoredProcedure
        oDa.SelectCommand.Parameters.Add("@Month", SqlDbType.Int, 4).Value = Month
        oDa.SelectCommand.Parameters.Add("@Year", SqlDbType.Int, 4).Value = WOYear
        oDa.SelectCommand.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = Consignee
        Try
            oDa.Fill(oDs)
            RMRPLs = oDs.Tables(0).Copy
        Catch exp As Exception
            RMRPLs = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
            oDa = Nothing
            oDs = Nothing
        End Try
    End Function
    Public Shared Function GetRMRWOPLs(ByVal Consignee As String, ByVal WO As String, ByVal Month As Integer, ByVal WOYear As Integer)
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "mm_sp_GetRMRWOPLs"
        oDa.SelectCommand.CommandType = CommandType.StoredProcedure
        oDa.SelectCommand.Parameters.Add("@WO", SqlDbType.VarChar, 10).Value = WO
        oDa.SelectCommand.Parameters.Add("@Month", SqlDbType.Int, 4).Value = Month
        oDa.SelectCommand.Parameters.Add("@Year", SqlDbType.Int, 4).Value = WOYear
        oDa.SelectCommand.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = Consignee
        Try
            oDa.Fill(oDs)
            GetRMRWOPLs = oDs.Tables(0).Copy
        Catch exp As Exception
            GetRMRWOPLs = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
            oDa = Nothing
            oDs = Nothing
        End Try
    End Function
    Public Shared Function GetRMRMonthYearWO(ByVal Month As Integer, ByVal WOYear As Integer)
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "mm_sp_GetRMRMonthYearWO"
        oDa.SelectCommand.CommandType = CommandType.StoredProcedure
        oDa.SelectCommand.Parameters.Add("@Month", SqlDbType.Int, 4).Value = Month
        oDa.SelectCommand.Parameters.Add("@Year", SqlDbType.Int, 4).Value = WOYear
        Try
            oDa.Fill(oDs)
            GetRMRMonthYearWO = oDs.Tables(0).Copy
        Catch exp As Exception
            GetRMRMonthYearWO = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
            oDa = Nothing
            oDs = Nothing
        End Try
    End Function
    Public Shared Function GetGroupName(ByVal Group As String, ByVal UserId As String) As String
        Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        da.SelectCommand.CommandText = " select distinct description from ms_group_location where purpose = 'MMSBreakdowns' " & _
                " and group_code = (select group_code from mis.dbo.menu_your_password " & _
                " where employee_code = @UserId and application = 'MMS' 	and group_code = @Group ) "
        Try
            da.SelectCommand.Parameters.Add("@Group", SqlDbType.VarChar, 7).Value = Group.Trim
            da.SelectCommand.Parameters.Add("@UserId", SqlDbType.VarChar, 6).Value = UserId.Trim
            da.Fill(ds, "GroupName")
            If Trim(IIf(IsNothing(ds.Tables("GroupName").Rows(0)(0)), "", ds.Tables("GroupName").Rows(0)(0))).Length > 0 Then
                Return Trim(IIf(IsNothing(ds.Tables("GroupName").Rows(0)(0)), 0, ds.Tables("GroupName").Rows(0)(0)))
            Else
                Return ""
            End If
        Catch exp As Exception
            Return ""
            Throw New Exception(exp.Message)
        Finally
            ds.Dispose()
            da.Dispose()
            da = Nothing
            ds = Nothing
        End Try
    End Function
    Public Shared Function GetConsignee(ByVal Group As String, ByVal UserId As String) As String
        Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()

        da.SelectCommand.CommandText = " select description from ms_group_location where purpose = 'Sub-Stores' " & _
                " and group_code = (select group_code from mis.dbo.menu_your_password " & _
                " where employee_code = @UserId and application = 'MSS' 	and group_code = @Group ) "
        Try
            da.SelectCommand.Parameters.Add("@Group", SqlDbType.VarChar, 7).Value = Group.Trim
            da.SelectCommand.Parameters.Add("@UserId", SqlDbType.VarChar, 6).Value = UserId.Trim
            da.Fill(ds, "Consignee")
            If Trim(IIf(IsNothing(ds.Tables("Consignee").Rows(0)(0)), "", ds.Tables("Consignee").Rows(0)(0))).Length > 0 Then Return Trim(IIf(IsNothing(ds.Tables("Consignee").Rows(0)(0)), 0, ds.Tables("Consignee").Rows(0)(0)))
        Catch exp As Exception
            Return ""
            Throw New Exception(exp.Message)
        Finally
            ds.Dispose()
            da.Dispose()
            da = Nothing
            ds = Nothing
        End Try
    End Function
    Public Shared Function GetYearMonth(ByVal Type As Integer)
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "mm_sp_GetRMRMonthYear"
        oDa.SelectCommand.CommandType = CommandType.StoredProcedure
        If Type = 0 Then
            oDa.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 0
        Else
            oDa.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 1
        End If
        Try
            oDa.Fill(oDs)
            GetYearMonth = oDs.Tables(0).Copy
        Catch exp As Exception
            GetYearMonth = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
            oDa = Nothing
            oDs = Nothing
        End Try
    End Function
    Public Function SaveRMR(ByVal RMRNumber As Long, ByVal RMRConsumption As Decimal, ByVal RMRConsumptionDate As Date) As Boolean
        Dim Done As Boolean = False
        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            oCmd.Parameters.Add("@RMRNumber", SqlDbType.BigInt, 8).Value = RMRNumber
            oCmd.Parameters.Add("@RMRConsumption", SqlDbType.Decimal, 9, 2).Value = RMRConsumption
            oCmd.Parameters.Add("@RMRConsumptionDate", SqlDbType.SmallDateTime, 4).Value = RMRConsumptionDate
            oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            oCmd.CommandText = " select @cnt = count(*) from mm_RMRConsumption where RMRNumber = @RMRNumber "
            Try
                oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                oCmd.ExecuteScalar()
                If IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value) = 0 Then
                    oCmd.CommandText = " insert into mm_RMRConsumption ( RMRNumber , RMRConsumption , RMRConsumptionDate ) " & _
                        " values ( @RMRNumber , @RMRConsumption , @RMRConsumptionDate ) "
                Else
                    oCmd.CommandText = " update mm_RMRConsumption set RMRConsumption = @RMRConsumption , " & _
                        " RMRConsumptionDate = @RMRConsumptionDate " & _
                        " where RMRNumber =  @RMRNumber "
                End If
                If oCmd.ExecuteNonQuery = 1 Then Done = True
            Catch exp As Exception
                Throw New Exception(" RMR Consumption Updation failed !" & exp.Message)
            End Try
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
                oCmd = Nothing
            End If
        End Try
        Return Done
    End Function
End Class
