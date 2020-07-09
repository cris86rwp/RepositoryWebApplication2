Namespace RWF
    Public Class WFPSQuerry
        Public Shared Function WheelSetParamData(ByVal SetProduct As String, ByVal Type As String, Optional ByVal All As Boolean = False) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                If Type.StartsWith("M") Then
                    If All Then
                        da.SelectCommand.CommandText = "select b.description , min_pressure MinPres , max_pressure MaxPres" & _
                            " from mm_wheelset_mountPressures a inner join mm_product_details b " & _
                            " on a.product_code = b.Product_code order by b.description  "
                    Else
                        da.SelectCommand.CommandText = "select b.description , min_pressure MinPres , max_pressure MaxPres " & _
                            " from mm_wheelset_mountPressures a inner join mm_product_details b " & _
                            " on a.product_code = b.Product_code and a.product_code = @SetProduct "
                    End If
                Else
                    If All Then
                        da.SelectCommand.CommandText = "select b.description , Min_Guage MinGuage, max_Guage MaxGuage " & _
                            " from mm_wheelset_Trackguages a inner join mm_product_details b " & _
                            " on a.product_code = b.Product_code  order by b.description "
                    Else
                        da.SelectCommand.CommandText = "select b.description , Min_Guage MinGuage , max_Guage MaxGuage " & _
                            " from mm_wheelset_Trackguages a inner join mm_product_details b " & _
                            " on a.product_code = b.Product_code  and a.product_code = @SetProduct"
                    End If
                End If
                da.SelectCommand.Parameters.Add("@SetProduct", SqlDbType.VarChar, 50).Value = SetProduct
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
        Public Shared Function FIWheelsParamData(Optional ByVal WhlType As String = "") As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                If WhlType = "" Then
                    da.SelectCommand.CommandText = "select b.description WhlType , MinTreadDia MinTD, MaxTreadDia MaxTD , " & _
                        " minBoreDia MinBore , MaxBoreDia MaxBore ," & _
                        " minHubLen , maxHubLen , minRimTh , maxRimTh , minHubProj , maxHubProj , MinWhlNo , MaxWhlNo ," & _
                        " MinPlateThickness MinPT , MaxPlateThickness MaxPT , McnMinDia , OverSizeMin , OverSizeMax " & _
                        " from mm_ProductwiseTreadAndBoreSizes a inner join mm_product_details b " & _
                        " on a.productcode = b.Product_code order by b.description "
                Else
                    da.SelectCommand.CommandText = "select MinTreadDia MinTD, MaxTreadDia MaxTD , " & _
                        " minBoreDia MinBore , MaxBoreDia MaxBore ," & _
                        " minHubLen , maxHubLen , minRimTh , maxRimTh , minHubProj , maxHubProj , MinWhlNo , MaxWhlNo ," & _
                        " MinPlateThickness MinPT , MaxPlateThickness MaxPT , McnMinDia , OverSizeMin , OverSizeMax " & _
                        " from mm_ProductwiseTreadAndBoreSizes a inner join mm_product_details b " & _
                        " on a.productcode = b.Product_code " & _
                        " where a.productcode = @WhlType "
                    da.SelectCommand.Parameters.Add("@WhlType", SqlDbType.VarChar, 50).Value = WhlType
                End If
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
        Public Shared Function FIWheelsParam() As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = "select distinct rtrim(b.description) WhlType , a.productcode WhlProduct" & _
                    " from mm_ProductwiseTreadAndBoreSizes a inner join mm_product_master b " & _
                    " on a.productcode = b.Product_code order by WhlType "
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
        Public Shared Function WheelSetParam(ByVal Type As String) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                If Type.StartsWith("M") Then
                    da.SelectCommand.CommandText = "select distinct rtrim(b.description) WhlType , a.product_code SetProduct" & _
                        " from mm_wheelset_mountPressures a inner join mm_product_master b " & _
                        " on a.product_code = b.Product_code order by WhlType "
                Else
                    da.SelectCommand.CommandText = "select distinct rtrim(b.description) WhlType , a.product_code SetProduct" & _
                        " from mm_wheelset_Trackguages a inner join mm_product_master b " & _
                        " on a.product_code = b.Product_code order by WhlType "
                End If

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
        Public Shared Function OutSideMachining(ByVal Type As Integer, ByVal FrDt As Date, ByVal ToDt As Date, Optional ByVal McnAgency As String = "") As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Select Case Type
                Case 1
                    da.SelectCommand.CommandText = " SELECT mm_wheel_machining_details.McnAgency,  McnCode , " & _
                        " sum(case when mm_product_master.description = 'BOXN WHL' then 1 else 0 end) [BOXN WHL],  " & _
                        " sum(case when mm_product_master.description = 'ICF WHL' then 1 else 0 end) [ICF WHL], " & _
                        " sum(case when mm_product_master.description = '840 WHL' then 1 else 0 end) [840 WHL], " & _
                        " sum(case when mm_product_master.description = 'MGC WHL' then 1 else 0 end) [MGC WHL], " & _
                        " sum(case when mm_product_master.description = 'DSL LOCO' then 1 else 0 end) [DSL LOCO], " & _
                        " sum(case when mm_product_master.description = '915DEF/WHL' then 1 else 0 end) [915DEF/WHL], " & _
                        " sum(case when mm_product_master.description = 'EMU WHEEL(ROUGH)' then 1 else 0 end) [EMU WHEEL(ROUGH)], " & _
                        " sum(case when mm_product_master.description = 'EMUBG' then 1 else 0 end) [EMUBG], " & _
                        " count(*) Total " & _
                        " FROM wap.dbo.mm_wheel_machining_details mm_wheel_machining_details, wap.dbo.mm_product_master mm_product_master   " & _
                        " WHERE mm_wheel_machining_details.product_code = mm_product_master.product_code  " & _
                        " AND  mm_wheel_machining_details.Status = 'SENT' and McnAgency = @McnAgency " & _
                        " and mm_wheel_machining_details.McnDate between @FrDt and @ToDt " & _
                        " group by mm_wheel_machining_details.McnAgency , McnCode  " & _
                        " order by mm_wheel_machining_details.McnAgency , McnCode "
                Case 2
                    da.SelectCommand.CommandText = " SELECT a.McnAgency, a.GatePass, convert(varchar(10),a.McnDate,103) SentDate, " & _
                        " a.Wheel, a.McnCode, a.Status,  a.Remarks, b.description, " & _
                        " convert(varchar(10),wap.dbo.mm_fn_ReceivedDateForWheelMachined(a.GatePass, a.Wheel),103) RecdDate " & _
                        " FROM wap.dbo.mm_wheel_machining_details a inner join wap.dbo.mm_product_master b " & _
                        " on a.product_code = b.product_code " & _
                        " WHERE a.Status = 'SENT' and a.McnDate between @FrDt and @ToDt "
                Case 3
                    da.SelectCommand.CommandText = "SELECT convert(varchar(10),wap.dbo.mm_fn_ReceivedDateForWheelMachined(a.GatePass, a.Wheel),103) RecdDate , " & _
                        " a.McnAgency, a.GatePass, convert(varchar(10),a.McnDate,103) SentDate,  " & _
                        " a.Wheel, a.McnCode, a.Status, a.Remarks, b.description  WhlType" & _
                        " FROM wap.dbo.mm_wheel_machining_details a inner join wap.dbo.mm_product_master b " & _
                        " on a.product_code = b.product_code" & _
                        " WHERE a.Status = 'SENT' and  " & _
                        " wap.dbo.mm_fn_ReceivedDateForWheelMachined(a.GatePass,a.Wheel) between @FrDt and @ToDt " & _
                        " order by wap.dbo.mm_fn_ReceivedDateForWheelMachined(a.GatePass,a.Wheel) , a.McnAgency, a.GatePass, a.McnDate "
                Case 4
                    da.SelectCommand.CommandText = " SELECT a.McnAgency,    " & _
                        " sum(case when b.description = 'BOXN WHL' then 1 else 0 end) [BOXN WHL],  " & _
                        " sum(case when b.description = 'ICF WHL' then 1 else 0 end) [ICF WHL], " & _
                        " sum(case when b.description = '840 WHL' then 1 else 0 end) [840 WHL], " & _
                        " sum(case when b.description = 'MGC WHL' then 1 else 0 end) [MGC WHL], " & _
                        " sum(case when b.description = 'DSL LOCO' then 1 else 0 end) [DSL LOCO], " & _
                        " sum(case when b.description = '915DEF/WHL' then 1 else 0 end) [915DEF/WHL], " & _
                        " sum(case when b.description = 'EMU WHEEL(ROUGH)' then 1 else 0 end) [EMU WHEEL(ROUGH)], " & _
                        " sum(case when b.description = 'EMUBG' then 1 else 0 end) [EMUBG], " & _
                        " count(*) Total " & _
                        " FROM wap.dbo.mm_wheel_machining_details a inner join wap.dbo.mm_product_master b   " & _
                        " on  a.product_code = b.product_code " & _
                        " WHERE a.Status = 'SENT' and a.McnDate between @FrDt and @ToDt " & _
                        " group by a.McnAgency order by a.McnAgency "

            End Select
            Try
                da.SelectCommand.Parameters.Add("@FrDt", SqlDbType.SmallDateTime, 4).Value = FrDt
                da.SelectCommand.Parameters.Add("@ToDt", SqlDbType.SmallDateTime, 4).Value = ToDt
                da.SelectCommand.Parameters.Add("@McnAgency", SqlDbType.VarChar, 50).Value = McnAgency.Trim
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
        Public Shared Function MachinedInRWF(ByVal Type As Integer, ByVal FrDt As Date, ByVal ToDt As Date) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = "mm_sp_MachinedWheels"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.Add("@FrDt", SqlDbType.SmallDateTime, 4).Value = FrDt
                da.SelectCommand.Parameters.Add("@ToDt", SqlDbType.SmallDateTime, 4).Value = ToDt
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
        Public Shared Function WFPSData(ByVal Type As Integer, ByVal Dt As Date) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                Select Case Type
                    Case 1
                        'If Not CheckDate(Dt) Then Exit Try
                        da.SelectCommand.CommandText = "mm_sp_WFPSData"
                        da.SelectCommand.CommandType = CommandType.StoredProcedure
                    Case 2
                        da.SelectCommand.CommandText = "mm_sp_WFPSCummulativeWhls"
                        da.SelectCommand.CommandType = CommandType.StoredProcedure
                        da.SelectCommand.CommandTimeout = 3600
                    Case 3
                        da.SelectCommand.CommandText = "mm_sp_WFPSTargets"
                        da.SelectCommand.CommandType = CommandType.StoredProcedure
                        da.SelectCommand.CommandTimeout = 3600
                    Case 4
                        da.SelectCommand.CommandText = ""

                End Select
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
        Public Shared Function IsWFPSDateLess(ByVal WFPSDate As Date) As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.CommandText = "select top 1 @PreDt = WFPSDate FROM mm_WFPSData order by WFPSDate desc "
            cmd.Parameters.Add("@PreDt", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output

            Try
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.ExecuteScalar()
                If WFPSDate < IIf(IsDBNull(cmd.Parameters("@PreDt").Value), CDate("1900-01-01"), cmd.Parameters("@PreDt").Value) Then Return True
            Catch exp As Exception
                IsWFPSDateLess = False
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function WFPSDate() As Date
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.CommandText = "select top 1 @PreDt = WFPSDate FROM mm_WFPSData order by WFPSDate desc "
            cmd.Parameters.Add("@PreDt", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output

            Try
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.ExecuteScalar()
                WFPSDate = IIf(IsDBNull(cmd.Parameters("@PreDt").Value), CDate("1900-01-01"), cmd.Parameters("@PreDt").Value)
            Catch exp As Exception
                WFPSDate = CDate("1900-01-01")
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function LatestWFPSData(ByVal dt As Date) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = "select SlNo , convert(varchar(10),WFPSDate,103) WFPSDate , " & _
                    " WhlType , OB , Total , Bored , UBs , BOSs  " & _
                    " FROM mm_WFPSData where WFPSDate = @dt"
                da.SelectCommand.Parameters.Add("@dt", SqlDbType.SmallDateTime, 4).Value = dt
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
        Public Shared Function WFPSSummary(ByVal dt As Date) As DataSet
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandTimeout = 3600
                da.SelectCommand.CommandText = "mm_sp_WFPSSummary"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.Add("@frDate", SqlDbType.SmallDateTime, 4).Value = dt
                da.Fill(ds)
                Return ds.Copy
            Catch exp As Exception
                Throw New Exception("Data Retrieval Error : " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Private Shared Function CheckDate(ByVal Dt As Date) As Boolean
            If Dt = Now.Date Then
                Throw New Exception("Cannot be generated for current Date !")
            ElseIf Dt > Now.Date Then
                Throw New Exception("Cannot be generated for Future Date !")
            Else
                Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
                cmd.CommandText = "select top 1 @PreDt = WFPSDate FROM mm_WFPSData order by WFPSDate desc "
                cmd.Parameters.Add("@PreDt", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output

                Try
                    If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                    cmd.ExecuteScalar()
                    Dim PreDt As Date = IIf(IsDBNull(cmd.Parameters("@PreDt").Value), CDate("1900-01-01"), cmd.Parameters("@PreDt").Value)
                    If PreDt = Dt OrElse PreDt.AddDays(1) = Dt Then
                        Return True
                    Else
                        Throw New Exception("Cannot be generated for Earlier Date !")
                    End If
                Catch exp As Exception
                    Throw New Exception(exp.Message)
                Finally
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                End Try
            End If
        End Function
        Public Shared Function WheelTally(ByVal QryName As String, ByVal FrHt As Long, ByVal ToHt As Long, Optional ByVal Type As Integer = 0) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.Parameters.Add("@FrHt", SqlDbType.BigInt, 8).Value = FrHt
            da.SelectCommand.Parameters.Add("@ToHt", SqlDbType.BigInt, 8).Value = ToHt
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            Select Case QryName
                Case "CastWheelTally"
                    da.SelectCommand.CommandText = "mm_sp_CastWheelTally"
            End Select
            Try
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
        Public Shared Function WheelDetails(ByVal QryName As String, ByVal FromDate As Date, ByVal ToDate As Date, Optional ByVal Type As Integer = 0) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.Parameters.Add("@frdate", SqlDbType.SmallDateTime, 4).Value = FromDate
            da.SelectCommand.Parameters.Add("@todate", SqlDbType.SmallDateTime, 4).Value = ToDate
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            Select Case QryName
                Case "ArrisalDefectwiseWheelOffloads"
                    da.SelectCommand.CommandText = "mm_sp_OffloadWheelsFor_a_Period"
                    'Case "UniqueWheels"
                    '    da.SelectCommand.CommandText = "mm_sp_UniqueWheelsForaPeriod"
                    'Case "StockedNotTestedInFinal"
                    '    da.SelectCommand.CommandText = "mm_sp_StockedNotTestedInFinal"
                    'Case "ProcessedNotStocked"
                    '    da.SelectCommand.CommandText = "mm_sp_ProcessedNotStocked"
                Case "ProcessedForThePeriodOnLineOne"
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 0
                    da.SelectCommand.CommandText = "mm_sp_ProcessedForTheDay"
                Case "UniqueProcessedForTheDayAllLines"
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 1
                    da.SelectCommand.CommandText = "mm_sp_ProcessedForTheDay"
                Case "MOPOWheels"
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 2
                    da.SelectCommand.CommandText = "mm_sp_ProcessedForTheDay"
                Case "CRXCWheels"
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 3
                    da.SelectCommand.CommandText = "mm_sp_ProcessedForTheDay"
                Case "InspWiseProcessedForThePeriodOnLineOne"
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 4
                    da.SelectCommand.CommandText = "mm_sp_ProcessedForTheDay"
                Case "OffLoadedAndReprocessededForTheDay"
                    da.SelectCommand.CommandText = "mm_sp_OffLoadedAndReprocessededForTheDay"
                Case "FINotPassed"
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 0
                    da.SelectCommand.CommandText = "mm_sp_FINotPassed"
                Case "FIWheelsWithStockTime"
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 1
                    da.SelectCommand.CommandText = "mm_sp_FINotPassed"
                Case "NotDespatchedWhls"
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 2
                    da.SelectCommand.CommandText = "mm_sp_FINotPassed"
                Case "DistinctStockedNotTestedInFinal"
                    da.SelectCommand.CommandText = "mm_sp_DistinctStockedNotTestedInFinal"
                Case "DistinctStocked"
                    da.SelectCommand.CommandText = "mm_sp_DistinctStocked"
                Case "XCWheelsInYard"
                    da.SelectCommand.CommandText = "mm_sp_XCWheelsInYard"
                Case "MagReLoadProcessDetails"
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 0
                    da.SelectCommand.CommandText = "mm_sp_MagReLoadProcess"
                Case "MagReLoadProcessSummary"
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 1
                    da.SelectCommand.CommandText = "mm_sp_MagReLoadProcess"
                Case "MagReLoadList"
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 2
                    da.SelectCommand.CommandText = "mm_sp_MagReLoadProcess"
                Case "MagReLoadProcessMoreThanOnce"
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 3
                    da.SelectCommand.CommandText = "mm_sp_MagReLoadProcess"
                Case "MagnaXCs" '
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = Type
                    da.SelectCommand.CommandText = "mm_sp_MagnaWheels"
                Case "PendingMagnaMCNRework"
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = Type
                    da.SelectCommand.CommandText = "mm_sp_MagnaWheels"
                Case "MagnaLatesMCNRework"
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = Type
                    da.SelectCommand.CommandText = "mm_sp_MagnaWheels"
                Case "PendingMagnaGRRework"
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = Type
                    da.SelectCommand.CommandText = "mm_sp_MagnaWheels"
                Case "MagnaSeriesWhls"
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = Type
                    da.SelectCommand.CommandText = "mm_sp_MagnaWheels"
                Case "ArrisalMagnaOffLoadSummary"
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = Type
                    da.SelectCommand.CommandText = "mm_sp_MagnaWheels"
                Case "MagnaXCSummary"
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = Type
                    da.SelectCommand.CommandText = "mm_sp_MagnaWheels"
                Case "MagnaOffLoadEndDetails"
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = Type
                    da.SelectCommand.CommandText = "mm_sp_MagnaWheels"
                Case "MagnaMCNReworkGroupWiseArisalaSummary"
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = Type
                    da.SelectCommand.CommandText = "mm_sp_MagnaWheels"
                Case "MagnaXCGroupWiseArisalaSummary"
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = Type
                    da.SelectCommand.CommandText = "mm_sp_MagnaWheels"
                Case "XCWheelsInMR"
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 0
                    da.SelectCommand.CommandText = "mm_sp_RejectionInMRandFI"
                Case "XCWheelsInFI"
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 1
                    da.SelectCommand.CommandText = "mm_sp_RejectionInMRandFI"
                Case "UBWheelList"
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 0
                    da.SelectCommand.CommandText = "mm_sp_UBWheels"
                Case "UBWheelsSummary"
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 1
                    da.SelectCommand.CommandText = "mm_sp_UBWheels"
                Case "UBWheelsDatewise"
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 2
                    da.SelectCommand.CommandText = "mm_sp_UBWheels"
                Case "Conv Of UnBore to Bore"
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 3
                    da.SelectCommand.CommandText = "mm_sp_UBWheels"
                Case "QCIWheels"
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 1
                    da.SelectCommand.CommandText = "mm_sp_QCInYardWheels"
                Case "YardWheels"
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 2
                    da.SelectCommand.CommandText = "mm_sp_QCInYardWheels"
                Case "GoodWheelsList"
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 0
                    da.SelectCommand.CommandText = "mm_sp_GoodWheelsList"
                Case "FIPassedWithPreviousSts"
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 1
                    da.SelectCommand.CommandText = "mm_sp_GoodWheelsList"
                Case "WFPSOffLoadsList"
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 1
                    da.SelectCommand.CommandText = "mm_sp_WFPSOffLoads"
                Case "ArrisalFIReWorkSummary"
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 2
                    da.SelectCommand.CommandText = "mm_sp_WFPSOffLoads"
                Case "OffLoadMagnaQuerry106"
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 3
                    da.SelectCommand.CommandText = "mm_sp_WFPSOffLoads"
                Case "OffLoadFIQuerry105"
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 4
                    da.SelectCommand.CommandText = "mm_sp_WFPSOffLoads"
                Case "Inventory"
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 5
                    da.SelectCommand.CommandText = "mm_sp_WFPSOffLoads"
                Case "DoubleOperationWheels"
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 6
                    da.SelectCommand.CommandText = "mm_sp_WFPSOffLoads"
                Case "StockTally"
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 7
                    da.SelectCommand.CommandText = "mm_sp_WFPSOffLoads"
                Case "MonthWiseCastWheelTally"
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 8
                    da.SelectCommand.CommandText = "mm_sp_WFPSOffLoads"
                Case "DateWiseProcessTally"
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 9
                    da.SelectCommand.CommandText = "mm_sp_WFPSOffLoads"
                Case "MultiOperationCount"
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 10
                    da.SelectCommand.CommandText = "mm_sp_WFPSOffLoads"
                Case "WheelNotFoundInMaster"
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 11
                    da.SelectCommand.CommandText = "mm_sp_WFPSOffLoads"
            End Select
            Try
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
        Public Function Update(ByVal WFPSDate As Date, ByVal WFPS As DataTable) As Boolean
            Dim Done As Boolean = False
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                oCmd.Parameters.Add("@WFPSDate", SqlDbType.SmallDateTime, 4).Value = CDate(WFPSDate)
                oCmd.Parameters.Add("@Total", SqlDbType.Int, 4).Direction = ParameterDirection.Input
                oCmd.Parameters.Add("@SlNo", SqlDbType.Int, 4).Direction = ParameterDirection.Input
                oCmd.Parameters.Add("@Bored", SqlDbType.Int, 4).Direction = ParameterDirection.Input
                oCmd.Parameters.Add("@UBs", SqlDbType.Int, 4).Direction = ParameterDirection.Input
                oCmd.Parameters.Add("@BOSs", SqlDbType.Int, 4).Direction = ParameterDirection.Input
                oCmd.Parameters.Add("@PreWFPSDate", SqlDbType.SmallDateTime, 4).Value = RWF.WFPSQuerry.WFPSDate

                Try
                    oCmd.Connection.Open()
                    oCmd.Transaction = oCmd.Connection.BeginTransaction
                    Dim i As Integer = 0
                    For i = 0 To WFPS.Rows.Count - 1
                        If Done Then Done = False
                        oCmd.CommandText = " update mm_WFPSData set Total = @Total , WFPSDate = @WFPSDate , " & _
                            " Bored = @Bored , UBs = @UBs , BOSs = @BOSs where WFPSDate = @PreWFPSDate and SlNo = @SlNo "
                        oCmd.Parameters("@SlNo").Value = WFPS.Rows(i)("SlNo")
                        oCmd.Parameters("@Total").Value = WFPS.Rows(i)("Total")
                        oCmd.Parameters("@Bored").Value = WFPS.Rows(i)("Bored")
                        oCmd.Parameters("@UBs").Value = WFPS.Rows(i)("UBs")
                        oCmd.Parameters("@BOSs").Value = WFPS.Rows(i)("BOSs")
                        If oCmd.ExecuteNonQuery = 1 Then
                            Done = True
                        Else
                            Throw New Exception("Updation Failed !")
                        End If
                    Next
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
                End If
            End Try
            Return Done
            oCmd = Nothing
        End Function
    End Class
End Namespace
