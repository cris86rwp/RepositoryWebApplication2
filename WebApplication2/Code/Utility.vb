Namespace UtilityShop
    <Serializable()> Public Class DataTables
#Region "  Tables"
        Public Shared Function NewHSD(ByVal ConDate As Date) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@ConDate", SqlDbType.SmallDateTime, 4).Value = ConDate
            da.SelectCommand.CommandText = " select LPH , NF , DF , SP , AxleShop , RTShop , DG , Remarks ," &
                    " Wheel , HubCut , BilletCut , AxleEndCut , PCBay " &
                    " from ms_HSD where ConsumptionDate = @ConDate"
            Try
                da.Fill(ds)
                Return ds.Tables(0).Copy
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function LOValues(ByVal FromDate As Date, ByVal Item As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@dt", SqlDbType.SmallDateTime, 4).Value = FromDate
            da.SelectCommand.Parameters.Add("@Item", SqlDbType.VarChar, 50).Value = Item
            da.SelectCommand.CommandText = " select ItemValue , Remarks , Reset , PreMaxValue , NextIniValue" & _
                " from ms_LiquidOxygenValues a left outer join ms_LiquidOxygenResetValues b" & _
                " on a.OxyDate = b.OxyDate and a.Item = b.Item where  a.OxyDate = @dt  and a.Item = @Item ;"
            Try
                da.Fill(ds)
                Return ds.Tables(0).Copy
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function LiquidOxygenValues(ByVal FromDate As Date, ByVal ToDate As Date) As DataSet
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@dt", SqlDbType.SmallDateTime, 4).Value = FromDate.AddDays(-1)
            da.SelectCommand.Parameters.Add("@dto", SqlDbType.SmallDateTime, 4).Value = ToDate
            da.SelectCommand.CommandText = " select OxyDate , Production ,  LO2 ,BulletPr , Melt , Hub , Axle , " & _
                " Scrap , Total , Remarks from ms_vw_LiquidOxygenValuesNew " & _
                " where  LiqOxyDate between  @dt and @dto order by OxyDate desc ;" & _
                " select OxyDate , Production ,  LO2 ,BulletPr , Melt , Hub , Axle , " & _
                " Scrap , Remarks from ms_vw_LiquidOxygenValues " & _
                " where  LiqOxyDate between  @dt and @dto order by OxyDate desc ;"
            Try
                da.Fill(ds)
                Return ds.Copy
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function LOConsumptionSSFORG(ByVal FromDate As Date, ByVal ToDate As Date) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@frdt", SqlDbType.SmallDateTime, 4).Value = FromDate
                da.SelectCommand.Parameters.Add("@todt", SqlDbType.SmallDateTime, 4).Value = ToDate
                da.SelectCommand.CommandText = "select convert(varchar(10),DataDate,103) LODate , " & _
                    " BC , EC ,  Total , Remarks  from ms_vw_LOConsumptionAxleForgeShop" & _
                    " where DataDate between @frdt and @todt " & _
                    " order by DataDate "
                da.Fill(ds)
                LOConsumptionSSFORG = ds.Tables(0).Copy
            Catch exp As Exception
                LOConsumptionSSFORG = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function FlowMeterReadings(ByVal FromDate As Date, ByVal ToDate As Date) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@frdt", SqlDbType.SmallDateTime, 4).Value = FromDate
                da.SelectCommand.Parameters.Add("@todt", SqlDbType.SmallDateTime, 4).Value = ToDate
                da.SelectCommand.CommandText = "ms_sp_HSDFlowMeterReadings"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.Fill(ds)
                FlowMeterReadings = ds.Tables(0).Copy
            Catch exp As Exception
                FlowMeterReadings = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function WaterHardnessDetails(ByVal FromDate As Date, ByVal ToDate As Date) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "ms_sp_WaterHardnessDetails"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.Add("@FrDt", SqlDbType.SmallDateTime, 4).Value = FromDate
                da.SelectCommand.Parameters.Add("@ToDt", SqlDbType.SmallDateTime, 4).Value = ToDate
                da.Fill(ds)
                WaterHardnessDetails = ds.Tables(0).Copy
            Catch exp As Exception
                WaterHardnessDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function WaterHardness(ByVal ShiftDate As Date) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@ShiftDate", SqlDbType.SmallDateTime, 4).Value = ShiftDate
                da.SelectCommand.CommandText = "ms_sp_WaterHardness"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.Fill(ds)
                WaterHardness = ds.Tables(0).Copy
            Catch exp As Exception
                WaterHardness = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function HSDConsumption(ByVal LoginName As String, ByVal DataDate As Date) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Dim a, b As String
            da.SelectCommand.Parameters.Add("@DataDate", SqlDbType.SmallDateTime, 4).Value = CDate(DataDate)

            'da.SelectCommand.Parameters.Add("@Item", SqlDbType.VarChar, 10).Value = Item
            'da.SelectCommand.Parameters.Add("@ItemType", SqlDbType.SmallDateTime, 4).Value = ItemType

            If LoginName = "RTSHOP" Then
                da.SelectCommand.CommandText = "select * from ms_vw_HSDConsumptionMRTShop where DataDate = @DataDate"
            ElseIf LoginName = "UTILIT" Then
                da.SelectCommand.CommandText = "select * from ms_vw_HSDConsumptionUtilityShop where DataDate = @DataDate"
            End If

            'If LoginName = "SSFORG" Then
            '    da.SelectCommand.CommandText = "select * from ms_vw_HSDConsumptionAxleForgeShop where DataDate = @DataDate"
            'ElseIf LoginName = "SSMELT" Then
            '    da.SelectCommand.CommandText = "select * from ms_vw_HSDConsumptionMeltShop where DataDate = @DataDate"
            'ElseIf LoginName = "SSMOLD" Then
            '    da.SelectCommand.CommandText = "select * from ms_vw_HSDConsumptionMouldRoom where DataDate = @DataDate"
            'ElseIf LoginName = "RTSHOP" Then
            '    da.SelectCommand.CommandText = "select * from ms_vw_HSDConsumptionMRTShop where DataDate = @DataDate"
            'ElseIf LoginName = "EDG" Then
            '    da.SelectCommand.CommandText = "select * from ms_vw_HSDConsumptionMRSDG where DataDate = @DataDate"
            'ElseIf LoginName = "UTILIT" Then
            '    da.SelectCommand.CommandText = "select * from ms_vw_HSDConsumptionUtilityShop where DataDate = @DataDate"
            'End If
            Try
                da.Fill(ds)
                HSDConsumption = ds.Tables(0).Copy
            Catch exp As Exception
                HSDConsumption = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function LOConsumption(ByVal LoginName As String, ByVal DataDate As Date) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Dim a, b As String
            da.SelectCommand.Parameters.Add("@DataDate", SqlDbType.SmallDateTime, 4).Value = CDate(DataDate)

            If LoginName = "SSFORG" Then
                da.SelectCommand.CommandText = "select * from ms_vw_LOConsumptionAxleForgeShop where DataDate = @DataDate"
            End If
            Try
                da.Fill(ds)
                LOConsumption = ds.Tables(0).Copy
            Catch exp As Exception
                LOConsumption = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function DataPointsList(ByVal LoginName As String, ByVal Application As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@LoginName", SqlDbType.VarChar, 10).Value = LoginName
                da.SelectCommand.Parameters.Add("@Application", SqlDbType.VarChar, 10).Value = Application
                da.SelectCommand.CommandText = " select DataPoint  , Shop from ms_HSDPoints where LoginName = @LoginName  " & _
                    " and Application = @Application order by OrderBy "
                da.Fill(ds)
                DataPointsList = ds.Tables(0).Copy
            Catch exp As Exception
                DataPointsList = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function LODataPointsList(ByVal LoginName As String, ByVal Application As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@LoginName", SqlDbType.VarChar, 10).Value = LoginName
                da.SelectCommand.Parameters.Add("@Application", SqlDbType.VarChar, 10).Value = Application
                da.SelectCommand.CommandText = " select DataPoint  , Shop from ms_LOPoints where LoginName = @LoginName  " & _
                    " and Application = @Application order by OrderBy "
                da.Fill(ds)
                LODataPointsList = ds.Tables(0).Copy
            Catch exp As Exception
                LODataPointsList = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function PointValue(ByVal DataDate As Date, ByVal DataPoint As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@DataPoint", SqlDbType.VarChar, 10).Value = DataPoint
                da.SelectCommand.Parameters.Add("@DataDate", SqlDbType.SmallDateTime, 4).Value = DataDate
                da.SelectCommand.CommandText = " select DataDate , MeterReading , Consumption , Remarks from ms_HSDConsumption  " &
                    " where DataPoint = @DataPoint and DataDate = @DataDate"
                da.Fill(ds)
                PointValue = ds.Tables(0).Copy
            Catch exp As Exception
                PointValue = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function LOPointValue(ByVal DataDate As Date, ByVal DataPoint As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@DataPoint", SqlDbType.VarChar, 50).Value = DataPoint
                da.SelectCommand.Parameters.Add("@DataDate", SqlDbType.SmallDateTime, 4).Value = DataDate
                da.SelectCommand.CommandText = " select DataDate , MeterReading , Consumption , Remarks from ms_LOConsumption  " & _
                    " where DataPoint = @DataPoint and DataDate = @DataDate"
                da.Fill(ds)
                LOPointValue = ds.Tables(0).Copy
            Catch exp As Exception
                LOPointValue = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function PreDatePointValue(ByVal DataPoint As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@DataPoint", SqlDbType.VarChar, 10).Value = DataPoint
                da.SelectCommand.CommandText = " select top 1 DataDate , isnull(MeterReading,0) MeterReading ," &
                " isnull(Consumption,0) Consumption , Remarks from ms_HSDConsumption  " &
                " where DataPoint = @DataPoint order by DataDate desc"
                da.Fill(ds)
                PreDatePointValue = ds.Tables(0).Copy
            Catch exp As Exception
                PreDatePointValue = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function LOPreDatePointValue(ByVal DataPoint As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@DataPoint", SqlDbType.VarChar, 50).Value = DataPoint
                da.SelectCommand.CommandText = " select top 1 DataDate , isnull(MeterReading,0) MeterReading ," & _
                " isnull(Consumption,0) Consumption , Remarks from ms_LOConsumption  " & _
                " where DataPoint = @DataPoint order by DataDate desc"
                da.Fill(ds)
                LOPreDatePointValue = ds.Tables(0).Copy
            Catch exp As Exception
                LOPreDatePointValue = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function NextPointValue(ByVal DataDate As Date, ByVal DataPoint As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@DataPoint", SqlDbType.VarChar, 10).Value = DataPoint
                da.SelectCommand.Parameters.Add("@DataDate", SqlDbType.SmallDateTime, 4).Value = DataDate
                da.SelectCommand.CommandText = " select top 1 DataDate , MeterReading , Consumption , Remarks from ms_HSDConsumption  " &
                    " where DataPoint = @DataPoint and DataDate > @DataDate order by DataDate "
                da.Fill(ds)
                NextPointValue = ds.Tables(0).Copy
            Catch exp As Exception
                NextPointValue = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function NextLOPointValue(ByVal DataDate As Date, ByVal DataPoint As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@DataPoint", SqlDbType.VarChar, 10).Value = DataPoint
                da.SelectCommand.Parameters.Add("@DataDate", SqlDbType.SmallDateTime, 4).Value = DataDate
                da.SelectCommand.CommandText = " select top 1 DataDate , MeterReading , Consumption , Remarks from ms_LOConsumption  " & _
                    " where DataPoint = @DataPoint and DataDate > @DataDate order by DataDate "
                da.Fill(ds)
                NextLOPointValue = ds.Tables(0).Copy
            Catch exp As Exception
                NextLOPointValue = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
#End Region
    End Class
    Public Class FlowMeter
        Private sMessage As String
        Public Function Save(ByVal DataPoint As String, ByVal PreDataDate As Date, ByVal PreMeterReading As Integer, ByVal Consumption As Integer, ByVal Remarks As String, ByVal DataDate As Date, ByVal MeterReading As Integer, ByVal LoginID As String) As String
            Dim oCmd As New SqlClient.SqlCommand()
            oCmd.Connection = rwfGen.Connection.ConObj
            Dim done As New Boolean()
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Parameters.Add("@DataPoint", SqlDbType.VarChar, 10).Value = DataPoint
                oCmd.Parameters.Add("@PreDataDate", SqlDbType.SmallDateTime, 4).Value = PreDataDate
                oCmd.Parameters.Add("@PreMeterReading", SqlDbType.Int, 4).Value = PreMeterReading
                oCmd.Parameters.Add("@Consumption", SqlDbType.Int, 4).Value = Consumption
                oCmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = Remarks

                oCmd.Parameters.Add("@DataDate", SqlDbType.SmallDateTime, 4).Value = DataDate
                oCmd.Parameters.Add("@MeterReading", SqlDbType.BigInt, 8).Value = MeterReading
                oCmd.Parameters.Add("@LoginID", SqlDbType.VarChar, 10).Value = LoginID
                oCmd.Parameters.Add("@SavedDateTime", SqlDbType.DateTime, 8).Value = Now

                oCmd.Parameters.Add("@SlNo", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                oCmd.CommandText = " select @SlNo = count(*) from ms_HSDConsumption where DataPoint = @DataPoint and DataDate = @PreDataDate"
                oCmd.ExecuteScalar()
                If IIf(IsDBNull(oCmd.Parameters("@SlNo").Value), 0, oCmd.Parameters("@SlNo").Value) = 0 Then
                    oCmd.CommandText = "insert into ms_HSDConsumption " &
                                " ( DataDate , DataPoint , MeterReading , Consumption , LoginID , SavedDateTime , Remarks ) " &
                                " values ( @PreDataDate , @DataPoint , @PreMeterReading , @Consumption , @LoginID , @SavedDateTime , @Remarks )"
                Else
                    oCmd.CommandText = " update ms_HSDConsumption set Consumption = @Consumption , " &
                                " LoginID = @LoginID , SavedDateTime = @SavedDateTime , Remarks = @Remarks , " &
                                " MeterReading = @PreMeterReading where  DataPoint = @DataPoint and DataDate = @PreDataDate "
                End If
                If oCmd.ExecuteNonQuery > 0 Then
                    oCmd.CommandText = " select @SlNo = count(*) from ms_HSDConsumption where DataPoint = @DataPoint and DataDate = @DataDate"
                    oCmd.ExecuteScalar()
                    If IIf(IsDBNull(oCmd.Parameters("@SlNo").Value), 0, oCmd.Parameters("@SlNo").Value) = 0 Then
                        oCmd.CommandText = "insert into ms_HSDConsumption " &
                                    " ( DataDate , DataPoint , MeterReading , LoginID , SavedDateTime ) " &
                                    " values ( @DataDate , @DataPoint , @MeterReading ,  @LoginID , @SavedDateTime )"
                    Else
                        oCmd.CommandText = " update ms_HSDConsumption set MeterReading = @MeterReading , " &
                                    " LoginID = @LoginID , SavedDateTime = @SavedDateTime " &
                                    " where  DataPoint = @DataPoint and DataDate = @DataDate "
                    End If
                    If oCmd.ExecuteNonQuery > 0 Then
                        done = True
                    End If
                End If
            Catch exp As Exception
                done = False
                sMessage = "Adding of HSD Values failed !" & exp.Message
            Finally
                If done Then
                    oCmd.Transaction.Commit()
                    sMessage = "Records Updated"
                Else
                    oCmd.Transaction.Rollback()
                    sMessage = "Updation failed"
                End If
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End Try
            Return sMessage
        End Function
        Public Function a(ByVal ShiftDate As Date, ByVal DataDateTime As Date, ByVal SoftHours As Integer, ByVal TotSoftQty As Integer, ByVal TotByPassQty As Integer, ByVal RawQty As Integer, ByVal SoftQty As Integer, ByVal ColdQty As Integer, ByVal Remarks As String) As Boolean
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim sHeaderQrySelect, sDetailsQrySelect, sCheckChildRecs As String
            Dim sDetailsQryInsert, sHeaderQryInsert, sDetailsQryUpdate As String
            Dim sHeaderQryUpdate, sHeaderQryDelete, sDetailsQryDelete As String
            sHeaderQrySelect = "select count(*) from  ms_WaterHardness_Header where ShiftDate = @ShiftDate"
            sDetailsQrySelect = "select count(*) from  ms_WaterHardness_Details where DataDateTime = @DataDateTime"
            sCheckChildRecs = "select count(*) from  ms_WaterHardness_Details where ShiftDate = @ShiftDate"

            sDetailsQryInsert = "Insert into ms_WaterHardness_Details (ShiftDate, DataDateTime, Raw_ppm, Soft_ppm, Cold_ppm , Remarks ) " & _
                    " values (@ShiftDate, @DataDateTime, @Raw_ppm, @Soft_ppm, @Cold_ppm , @Remarks )"
            sHeaderQryInsert = "Insert into ms_WaterHardness_Header (ShiftDate, SofteningHrs, Soft_Qty, ByPass_Qty ) " & _
                    " values (@ShiftDate, @SofteningHrs, @Soft_Qty, @ByPass_Qty)"

            sDetailsQryUpdate = "Update ms_WaterHardness_Details set ShiftDate = @ShiftDate, Raw_ppm = @Raw_ppm, " & _
                    " Soft_ppm = @Soft_ppm, Cold_ppm = @Cold_ppm , Remarks = @Remarks where DataDateTime = @DataDateTime"
            sHeaderQryUpdate = "Update ms_WaterHardness_Header set SofteningHrs = @SofteningHrs, Soft_Qty = @Soft_Qty, " & _
                    " ByPass_Qty = @ByPass_Qty where ShiftDate = @ShiftDate"

            sHeaderQryDelete = "delete from  ms_WaterHardness_Header where ShiftDate = @ShiftDate"
            sDetailsQryDelete = "delete from  ms_WaterHardness_Details where DataDateTime = @DataDateTime"
            PrepareParams(da, "select")
            PrepareParams(da, "Insert")
            PrepareParams(da, "Update")
            PrepareParams(da, "Delete")
            da.SelectCommand.Parameters("@ShiftDate").Value = ShiftDate
            da.SelectCommand.Parameters("@DataDateTime").Value = DataDateTime
            Dim iHeaderRecs, iDetailRecs As Integer
            Dim blnHeader, blnDetails As Boolean

            Try
                da.InsertCommand.Parameters("@ShiftDate").Value = ShiftDate
                da.InsertCommand.Parameters("@DataDateTime").Value = DataDateTime
                da.InsertCommand.Parameters("@SofteningHrs").Value = SoftHours
                da.InsertCommand.Parameters("@Soft_Qty").Value = TotSoftQty
                da.InsertCommand.Parameters("@ByPass_Qty").Value = TotByPassQty
                da.InsertCommand.Parameters("@Raw_ppm").Value = RawQty
                da.InsertCommand.Parameters("@Soft_ppm").Value = SoftQty
                da.InsertCommand.Parameters("@Cold_ppm").Value = ColdQty
                da.InsertCommand.Parameters("@Remarks").Value = Remarks
                '
                da.UpdateCommand.Parameters("@ShiftDate").Value = ShiftDate
                da.UpdateCommand.Parameters("@DataDateTime").Value = DataDateTime

                da.UpdateCommand.Parameters("@SofteningHrs").Value = SoftHours
                da.UpdateCommand.Parameters("@Soft_Qty").Value = TotSoftQty
                da.UpdateCommand.Parameters("@ByPass_Qty").Value = TotByPassQty
                da.UpdateCommand.Parameters("@Raw_ppm").Value = RawQty
                da.UpdateCommand.Parameters("@Soft_ppm").Value = SoftQty
                da.UpdateCommand.Parameters("@Cold_ppm").Value = ColdQty
                da.UpdateCommand.Parameters("@Remarks").Value = Remarks

                da.SelectCommand.Connection.Open()
                da.SelectCommand.CommandText = sHeaderQrySelect
                iHeaderRecs = da.SelectCommand.ExecuteScalar
                da.InsertCommand.Connection.Open()
                da.InsertCommand.Transaction = da.InsertCommand.Connection.BeginTransaction()
                If iHeaderRecs = 0 Then
                    da.InsertCommand.CommandText = sHeaderQryInsert
                Else
                    da.InsertCommand.CommandText = sHeaderQryUpdate
                End If
                If da.InsertCommand.ExecuteNonQuery = 1 Then
                    blnHeader = True
                End If
                da.SelectCommand.CommandText = sDetailsQrySelect
                If da.SelectCommand.Connection.State = ConnectionState.Closed Then da.SelectCommand.Connection.Open()
                iDetailRecs = da.SelectCommand.ExecuteScalar
                If iDetailRecs = 0 Then
                    da.InsertCommand.CommandText = sDetailsQryInsert
                Else
                    da.InsertCommand.CommandText = sDetailsQryUpdate
                End If
                If da.InsertCommand.ExecuteNonQuery = 1 Then
                    blnDetails = True
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If IsNothing(da) = False Then
                    If IsNothing(da.InsertCommand.Transaction) = False Then
                        If blnHeader And blnDetails Then
                            da.InsertCommand.Transaction.Commit()
                        Else
                            da.InsertCommand.Transaction.Rollback()
                        End If
                    End If
                    If da.SelectCommand.Connection.State = ConnectionState.Open Then da.SelectCommand.Connection.Close()
                    If da.InsertCommand.Connection.State = ConnectionState.Open Then da.SelectCommand.Connection.Close()
                    If da.UpdateCommand.Connection.State = ConnectionState.Open Then da.SelectCommand.Connection.Close()
                    If da.DeleteCommand.Connection.State = ConnectionState.Open Then da.SelectCommand.Connection.Close()
                    da.Dispose()
                End If
            End Try
            Return blnDetails
        End Function
        Private Sub PrepareParams(ByRef Da As SqlClient.SqlDataAdapter, ByVal CmdType As String)
            Select Case CmdType.ToLower.Trim
                Case "insert"
                    Da.InsertCommand.Parameters.Add("@ShiftDate", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Input

                    Da.InsertCommand.Parameters.Add("@DataDateTime", SqlDbType.DateTime, 8).Direction = ParameterDirection.Input
                    Da.InsertCommand.Parameters.Add("@Raw_ppm", SqlDbType.Int, 4).Direction = ParameterDirection.Input
                    Da.InsertCommand.Parameters.Add("@Soft_ppm", SqlDbType.Int, 4).Direction = ParameterDirection.Input
                    Da.InsertCommand.Parameters.Add("@Cold_ppm", SqlDbType.Int, 4).Direction = ParameterDirection.Input
                    Da.InsertCommand.Parameters.Add("@SofteningHrs", SqlDbType.Int, 4).Direction = ParameterDirection.Input
                    Da.InsertCommand.Parameters.Add("@Soft_Qty", SqlDbType.Int, 4).Direction = ParameterDirection.Input
                    Da.InsertCommand.Parameters.Add("@ByPass_Qty", SqlDbType.Int, 4).Direction = ParameterDirection.Input
                    Da.InsertCommand.Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Direction = ParameterDirection.Input
                Case "update"
                    Da.UpdateCommand.Parameters.Add("@ShiftDate", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Input

                    Da.UpdateCommand.Parameters.Add("@Raw_ppm", SqlDbType.Int, 4).Direction = ParameterDirection.Input
                    Da.UpdateCommand.Parameters.Add("@Soft_ppm", SqlDbType.Int, 4).Direction = ParameterDirection.Input
                    Da.UpdateCommand.Parameters.Add("@Cold_ppm", SqlDbType.Int, 4).Direction = ParameterDirection.Input
                    Da.UpdateCommand.Parameters.Add("@SofteningHrs", SqlDbType.Int, 4).Direction = ParameterDirection.Input
                    Da.UpdateCommand.Parameters.Add("@Soft_Qty", SqlDbType.Int, 4).Direction = ParameterDirection.Input
                    Da.UpdateCommand.Parameters.Add("@DataDateTime", SqlDbType.DateTime, 8).Direction = ParameterDirection.Input
                    Da.UpdateCommand.Parameters.Add("@ByPass_Qty", SqlDbType.Int, 4).Direction = ParameterDirection.Input
                    Da.UpdateCommand.Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Direction = ParameterDirection.Input
                Case "select"
                    Da.SelectCommand.Parameters.Add("@ShiftDate", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Input
                    Da.SelectCommand.Parameters.Add("@DataDateTime", SqlDbType.DateTime, 8).Direction = ParameterDirection.Input
                Case "delete"
                    Da.DeleteCommand.Parameters.Add("@ShiftDate", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Input
                    Da.DeleteCommand.Parameters.Add("@DataDateTime", SqlDbType.DateTime, 8).Direction = ParameterDirection.Input
            End Select
        End Sub
        Public Function SaveLO(ByVal DataPoint As String, ByVal PreDataDate As Date, ByVal PreMeterReading As Integer, ByVal Consumption As Integer, ByVal Remarks As String, ByVal DataDate As Date, ByVal MeterReading As Integer, ByVal LoginID As String) As String
            Dim oCmd As New SqlClient.SqlCommand()
            oCmd.Connection = rwfGen.Connection.ConObj
            Dim done As New Boolean()
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Parameters.Add("@DataPoint", SqlDbType.VarChar, 50).Value = DataPoint
                oCmd.Parameters.Add("@PreDataDate", SqlDbType.SmallDateTime, 4).Value = PreDataDate
                oCmd.Parameters.Add("@PreMeterReading", SqlDbType.Int, 4).Value = PreMeterReading
                oCmd.Parameters.Add("@Consumption", SqlDbType.Int, 4).Value = Consumption
                oCmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = Remarks

                oCmd.Parameters.Add("@DataDate", SqlDbType.SmallDateTime, 4).Value = DataDate
                oCmd.Parameters.Add("@MeterReading", SqlDbType.BigInt, 8).Value = MeterReading
                oCmd.Parameters.Add("@LoginID", SqlDbType.VarChar, 10).Value = LoginID
                oCmd.Parameters.Add("@SavedDateTime", SqlDbType.DateTime, 8).Value = Now

                oCmd.Parameters.Add("@SlNo", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                oCmd.CommandText = " select @SlNo = count(*) from ms_LOConsumption where DataPoint = @DataPoint and DataDate = @PreDataDate"
                oCmd.ExecuteScalar()
                If IIf(IsDBNull(oCmd.Parameters("@SlNo").Value), 0, oCmd.Parameters("@SlNo").Value) = 0 Then
                    oCmd.CommandText = "insert into ms_LOConsumption " & _
                                " ( DataDate , DataPoint , MeterReading , Consumption , LoginID , SavedDateTime , Remarks ) " & _
                                " values ( @PreDataDate , @DataPoint , @PreMeterReading , @Consumption , @LoginID , @SavedDateTime , @Remarks )"
                Else
                    oCmd.CommandText = " update ms_LOConsumption set Consumption = @Consumption , " & _
                                " LoginID = @LoginID , SavedDateTime = @SavedDateTime , Remarks = @Remarks , " & _
                                " MeterReading = @PreMeterReading where  DataPoint = @DataPoint and DataDate = @PreDataDate "
                End If
                If oCmd.ExecuteNonQuery > 0 Then
                    oCmd.CommandText = " select @SlNo = count(*) from ms_LOConsumption where DataPoint = @DataPoint and DataDate = @DataDate"
                    oCmd.ExecuteScalar()
                    If IIf(IsDBNull(oCmd.Parameters("@SlNo").Value), 0, oCmd.Parameters("@SlNo").Value) = 0 Then
                        oCmd.CommandText = "insert into ms_LOConsumption " & _
                                    " ( DataDate , DataPoint , MeterReading , LoginID , SavedDateTime , Consumption ) " & _
                                    " values ( @DataDate , @DataPoint , @MeterReading ,  @LoginID , @SavedDateTime , 0 )"
                    Else
                        oCmd.CommandText = " update ms_LOConsumption set MeterReading = @MeterReading , " & _
                                    " LoginID = @LoginID , SavedDateTime = @SavedDateTime " & _
                                    " where  DataPoint = @DataPoint and DataDate = @DataDate "
                    End If
                    If oCmd.ExecuteNonQuery > 0 Then done = True
                End If
            Catch exp As Exception
                done = False
                sMessage = "Adding of Liquid Qxygen Values failed !" & exp.Message
            Finally
                If done Then
                    oCmd.Transaction.Commit()
                    sMessage = "Records Updated"
                Else
                    oCmd.Transaction.Rollback()
                    sMessage = sMessage & " Updation failed"
                End If
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End Try
            Return sMessage
        End Function
        Public Function SaveLiqOxy(ByVal OxyDate As Date, ByVal Item1 As String, ByVal Item As String, ByVal Item2 As String, ByVal ItemValue As Decimal, ByVal Remarks As String, ByVal ChallanNumber As String, ByVal ChallanDate As String, ByVal CheckBox1 As Boolean, ByVal MaxVal As Integer, ByVal ValueVal As Integer, ByVal InitialVal As Integer) As Boolean
            Dim oCmd As New SqlClient.SqlCommand()
            oCmd.Connection = rwfGen.Connection.ConObj
            Dim done As New Boolean()
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Parameters.Add("@OxyDate", SqlDbType.SmallDateTime, 4).Value = OxyDate
                oCmd.Parameters.Add("@Item", SqlDbType.VarChar, 50).Value = Item
                oCmd.Parameters.Add("@Item1", SqlDbType.VarChar, 50).Value = Item1
                oCmd.Parameters.Add("@Item2", SqlDbType.VarChar, 50).Value = Item2

                oCmd.Parameters.Add("@ItemValue", SqlDbType.Float, 8).Value = ItemValue
                oCmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 50).Value = Remarks
                oCmd.Parameters.Add("@ChallanNumber", SqlDbType.Float, 20).Value = ChallanNumber
                oCmd.Parameters.Add("@ChallanDate", SqlDbType.SmallDateTime, 8).Value = ChallanDate

                oCmd.Parameters.Add("@SlNo", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                If CheckBox1 = True Then
                    oCmd.CommandText = " select @SlNo = SlNo from ms_LiquidOxygenValues where OxyDate = @OxyDate and  Item = @Item "
                    oCmd.ExecuteScalar()
                    If IIf(IsDBNull(oCmd.Parameters("@SlNo").Value), 0, oCmd.Parameters("@SlNo").Value) = 0 Then
                        oCmd.CommandText = "insert into ms_LiquidOxygenValues " &
                                    " ( OxyDate , Item,Item1,Item2 , ItemValue ,ChallanNumber,ChallanDate, Remarks , Reset  ) " &
                                    " values ( @OxyDate , @Item,@Item1,@Item2 , @ItemValue ,@ChallanNumber,@ChallanDate, @Remarks  , " & 1 & " )"
                    Else
                        oCmd.CommandText = " update ms_LiquidOxygenValues set ItemValue = @ItemValue , " &
                                    " Remarks = @Remarks , Reset = " & 1 & " where  OxyDate = @OxyDate and  Item = @Item  "
                    End If
                    If oCmd.ExecuteNonQuery > 0 Then
                        done = False
                        oCmd.CommandText = " select @SlNo = SlNo from ms_LiquidOxygenValues where OxyDate = @OxyDate and  Item = @Item "
                        oCmd.ExecuteScalar()
                        If IIf(IsDBNull(oCmd.Parameters("@SlNo").Value), 0, oCmd.Parameters("@SlNo").Value) > 0 Then
                            If Val(MaxVal) < Val(ValueVal) OrElse Val(InitialVal) < 0 Then
                                Throw New Exception("InValid Reset Values !")
                            Else
                                oCmd.Parameters.Add("@PreMaxValue", SqlDbType.Float, 8).Value = Val(MaxVal)
                                oCmd.Parameters.Add("@NextIniValue", SqlDbType.Float, 8).Value = Val(InitialVal)
                                oCmd.Parameters("@SlNo").Direction = ParameterDirection.Input
                                oCmd.CommandText = "insert into ms_LiquidOxygenResetValues " &
                                       " ( OxyDate , Item,Item1,Item2 , ItemValue ,ChallanNumber,ChallanDate, Remarks , Reset  ) " &
                                    " values ( @OxyDate , @Item,@Item1,@Item2 , @ItemValue ,@ChallanNumber,@ChallanDate, @Remarks  , " & 1 & " )"

                                If oCmd.ExecuteNonQuery > 0 Then
                                    done = True
                                End If
                            End If
                        End If
                    End If
                Else
                    oCmd.CommandText = " select @SlNo = SlNo from ms_LiquidOxygenValues where OxyDate = @OxyDate and  Item = @Item "
                    oCmd.ExecuteScalar()
                    If IIf(IsDBNull(oCmd.Parameters("@SlNo").Value), 0, oCmd.Parameters("@SlNo").Value) = 0 Then
                        oCmd.CommandText = "insert into ms_LiquidOxygenValues " &
                                     " ( OxyDate , Item,Item1,Item2 , ItemValue ,ChallanNumber,ChallanDate, Remarks , Reset  ) " &
                                    " values ( @OxyDate , @Item,@Item1,@Item2 , @ItemValue ,@ChallanNumber,@ChallanDate, @Remarks  , " & 1 & " )"

                    Else
                        oCmd.CommandText = " update ms_LiquidOxygenValues set ItemValue = @ItemValue , " &
                                    " Remarks = @Remarks where  OxyDate = @OxyDate and  Item = @Item  "
                    End If
                    If oCmd.ExecuteNonQuery > 0 Then
                        done = True
                    End If
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
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
        Public Function SaveNewHSD(ByVal ConsumptionDate As Date, ByVal LPH As Integer, ByVal NF As Integer, ByVal DF As Integer, ByVal SP As Integer, ByVal AxleShop As Integer, ByVal RTShop As Integer, ByVal DG As Integer, ByVal Remarks As String, ByVal Wheel As Integer, ByVal HubCut As Integer, ByVal BilletCut As Integer, ByVal AxleEndCut As Integer, ByVal PCBay As Integer) As String
            Dim oCmd As New SqlClient.SqlCommand()
            oCmd.Connection = rwfGen.Connection.ConObj
            Dim done As New Boolean()
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Parameters.Add("@ConsumptionDate", SqlDbType.SmallDateTime, 4).Value = ConsumptionDate
                oCmd.Parameters.Add("@LPH", SqlDbType.Int, 4).Value = LPH
                oCmd.Parameters.Add("@NF", SqlDbType.Int, 4).Value = NF
                oCmd.Parameters.Add("@DF", SqlDbType.Int, 4).Value = DF
                oCmd.Parameters.Add("@SP", SqlDbType.Int, 4).Value = SP
                oCmd.Parameters.Add("@AxleShop", SqlDbType.Int, 4).Value = AxleShop
                oCmd.Parameters.Add("@RTShop", SqlDbType.Int, 4).Value = RTShop
                oCmd.Parameters.Add("@DG", SqlDbType.Int, 4).Value = DG
                oCmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 50).Value = Remarks
                oCmd.Parameters.Add("@Wheel", SqlDbType.Int, 4).Value = Wheel
                oCmd.Parameters.Add("@HubCut", SqlDbType.Int, 4).Value = HubCut
                oCmd.Parameters.Add("@BilletCut", SqlDbType.Int, 4).Value = BilletCut
                oCmd.Parameters.Add("@AxleEndCut", SqlDbType.Int, 4).Value = AxleEndCut
                oCmd.Parameters.Add("@PCBay", SqlDbType.Int, 4).Value = PCBay



                oCmd.Parameters.Add("@SlNo", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                oCmd.CommandText = " select @SlNo = count(*) from ms_HSD where ConsumptionDate = @ConsumptionDate"
                oCmd.ExecuteScalar()
                If IIf(IsDBNull(oCmd.Parameters("@SlNo").Value), 0, oCmd.Parameters("@SlNo").Value) = 0 Then
                    oCmd.CommandText = "insert into ms_HSD " & _
                                " ( ConsumptionDate , LPH , NF , DF , SP , AxleShop , RTShop , DG , Remarks  , " & _
                                " Wheel , HubCut , BilletCut , AxleEndCut , PCBay ) " & _
                                " values ( @ConsumptionDate , @LPH , @NF , @DF , @SP , @AxleShop , @RTShop , @DG ,  @Remarks ," & _
                                " @Wheel , @HubCut , @BilletCut , @AxleEndCut , @PCBay )"
                Else
                    oCmd.CommandText = " update ms_HSD set LPH = @LPH , NF = @NF , DF = @DF ,  " & _
                                " SP = @SP , AxleShop = @AxleShop , RTShop = @RTShop , DG = @DG , Remarks = @Remarks , " & _
                                " Wheel = @Wheel , HubCut = @HubCut , BilletCut = @BilletCut , " & _
                                " AxleEndCut = @AxleEndCut , PCBay = @PCBay " & _
                                " where  ConsumptionDate = @ConsumptionDate "
                End If
                If oCmd.ExecuteNonQuery > 0 Then done = True
            Catch exp As Exception
                done = False
                sMessage = "Adding of Liquid Qxygen Values failed !" & exp.Message
            Finally
                If done Then
                    oCmd.Transaction.Commit()
                    sMessage = "Records Updated"
                Else
                    oCmd.Transaction.Rollback()
                    sMessage = sMessage & " Updation failed"
                End If
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End Try
            Return sMessage
        End Function
    End Class
End Namespace