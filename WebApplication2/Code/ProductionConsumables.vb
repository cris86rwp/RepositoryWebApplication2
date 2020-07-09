Public Class ProductionConsumables
    Public Shared Function IDNStatus() As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = " select StsID , PresentStatus from ms_vw_IDNPresentStatus union " & _
            " select 100 , 'Pending ( All other than Accepted , Rejected , Returned )' union " & _
            " select 0 , 'All' " & _
            " order by StsID "
        Try
            oDa.Fill(oDs)
            IDNStatus = oDs.Tables(0).Copy
        Catch exp As Exception
            IDNStatus = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
            oDa = Nothing
            oDs = Nothing
        End Try
    End Function
    Public Shared Function IDNPresentStatus() As DataSet
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "select StsID , PresentStatus from ms_vw_IDNPresentStatus order by StsID ; " & _
            " select CriID , Criteria from ms_vw_IDNCriteria order by CriID"
        Try
            oDa.Fill(oDs)
            IDNPresentStatus = oDs.Copy
        Catch exp As Exception
            IDNPresentStatus = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
            oDa = Nothing
            oDs = Nothing
        End Try
    End Function
    Public Shared Function IDNDetails(ByVal IDNNo As String) As DataSet
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.Parameters.Add("@IDNNo", SqlDbType.VarChar, 50).Value = IDNNo
        oDa.SelectCommand.CommandText = "select IDNDate , IDNQty , Rate , IDNValue , POValue , DumpNo , " & _
            "  PLNumber , PLDescription , UnitName , Location , PONumber , PODate , SupplierName " & _
            " from ms_vw_IDNDetails where IDNNo = @IDNNo ; " & _
            " select convert(varchar(10),ReceivedDate,103) ReceivedDate , b.PresentStatus , AccQty , RejQty , " & _
            " case when convert(varchar(10),ClearedDate,103) = '01/01/1900' then '' else convert(varchar(10),ClearedDate,103) end ClearedDate , " & _
            " LabNo , FileNo , c.Criteria , ClearedBy from ms_IDNDetails a inner join ms_vw_IDNPresentStatus b on a.PresentStatus = StsID " & _
            " inner join ms_vw_IDNCriteria c on a.Criteria = CriID where IDNNo = @IDNNo "
        Try
            oDa.Fill(oDs)
            IDNDetails = oDs.Copy
        Catch exp As Exception
            IDNDetails = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
            oDa = Nothing
            oDs = Nothing
        End Try
    End Function
    Public Shared Function GetOffHeatRemarks(ByVal heat_number As Double) As String
        Dim Done As Boolean = False
        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        oCmd.Parameters.Add("@heat_number", SqlDbType.BigInt, 8).Value = heat_number
        oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
        oCmd.Parameters.Add("@HeatRemarks", SqlDbType.VarChar, 5000).Direction = ParameterDirection.Output
        oCmd.Connection.Open()
        Try
            oCmd.CommandText = " select @cnt = count(*) from mm_offheat_post_melt " & _
                " where heat_number = @heat_number "
            oCmd.ExecuteScalar()
            If IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value) = 0 Then
                Throw New Exception("InValid Off Heat No !")
            Else
                oCmd.CommandText = " select @HeatRemarks = hea_rem from mm_offheat_post_melt " & _
                               " where heat_number = @heat_number  "
                oCmd.ExecuteScalar()
                Return IIf(IsDBNull(oCmd.Parameters("@HeatRemarks").Value), "", oCmd.Parameters("@HeatRemarks").Value)
            End If
        Catch exp As Exception
            Throw New Exception("InValid Heat No !" & exp.Message)
        End Try
    End Function
    Public Shared Function GetTopOffHeat() As Double
        Dim Done As Boolean = False
        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        oCmd.Parameters.Add("@heat_number", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
        oCmd.Connection.Open()
        Try
            oCmd.CommandText = " select top 1 @heat_number = heat_number from mm_offheat_post_melt " & _
                " order by heat_number desc  "
            oCmd.ExecuteScalar()
            Return IIf(IsDBNull(oCmd.Parameters("@heat_number").Value), 0, oCmd.Parameters("@heat_number").Value)
        Catch exp As Exception
            Throw New Exception("InValid Heat No !" & exp.Message)
        End Try
    End Function
    Public Shared Function BrDownMemoEdit(ByVal BrDate As Date) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.Parameters.Add("@BrDate", SqlDbType.SmallDateTime, 4).Value = BrDate
        oDa.SelectCommand.CommandText = " select row_number() over (order by breakdown_from_time ) Sl , " & _
            " convert(varchar,breakdown_date,106) BreakDownDt , shift_code Sh , " & _
            " memo_number MemoNo , memo_slip_number MemoSlipNo , " & _
            " convert(varchar,breakdown_from_time,106) BreakDFrDate  , convert(varchar(5),breakdown_from_time,108) FrTime  ,   " & _
            " convert(varchar,breakdown_to_time,106) BreakDToDate  , convert(varchar(5),breakdown_to_time,108) ToTime  , " & _
            " TimeLoss , TimeLossInMin InMin , time_loss ForPCDO , case when production_affected = 1 then 'Yes' else 'No' end  Aff , " & _
            " BDCodeDesc BreakDownCodeDescription, CodeType CodeDescription , Operator " & _
            " from ms_vw_breakdown_memo_whlmlt " & _
            " where breakdown_date = @BrDate " & _
            " order by breakdown_from_time  desc "
        Try
            oDa.Fill(oDs)
            BrDownMemoEdit = oDs.Tables(0).Copy
        Catch exp As Exception
            BrDownMemoEdit = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
            oDa = Nothing
            oDs = Nothing
        End Try
    End Function
    Public Shared Function GetTopBrDate() As Date
        Dim Done As Boolean = False
        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        oCmd.Parameters.Add("@BrDate", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
        oCmd.Connection.Open()
        Try
            oCmd.CommandText = " select top 1 @BrDate = breakdown_date from ms_breakdown_memo " & _
                " where  maintenance_group = 'whlmlt' order by breakdown_date desc  "
            oCmd.ExecuteScalar()
            Return IIf(IsDBNull(oCmd.Parameters("@BrDate").Value), "", oCmd.Parameters("@BrDate").Value)
        Catch exp As Exception
            Throw New Exception("InValid Momo No !" & exp.Message)
        End Try
    End Function
    Public Shared Function CalcinedLimeRejectedLabDetails(ByVal dbr_number As String, ByVal lab_number As String) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.Parameters.Add("@dbr_number", SqlDbType.VarChar, 50).Value = "%" & dbr_number & "%"
        oDa.SelectCommand.Parameters.Add("@lab_number", SqlDbType.VarChar, 50).Value = lab_number
        oDa.SelectCommand.CommandText = "select CharName , Unit , Results , MinValue , MaxValue" & _
            " from ms_vw_CalcinedLimeRejectedLabDetails where lab_number = @lab_number and dbr_number like @dbr_number "
        Try
            oDa.Fill(oDs)
            CalcinedLimeRejectedLabDetails = oDs.Tables(0).Copy
        Catch exp As Exception
            CalcinedLimeRejectedLabDetails = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
            oDa = Nothing
            oDs = Nothing
        End Try
    End Function
    Public Shared Function RejectedCalcinedLimeDetails(ByVal DCNo As String) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.Parameters.Add("@DCNo", SqlDbType.VarChar, 50).Value = "%" & DCNo & "%"
        oDa.SelectCommand.CommandText = "select dbr_number DBRNo , convert(varchar(10),dbr_date,103) DBRDt , " & _
            " po_number PONo , convert(varchar(10),po_date,103) PODate ," & _
            " DCNo , convert(varchar(10),DCDate,103) DCDate , RecQty , DumpNo , VehicleNumber , SupplierName " & _
            " from ms_vw_CalcinedLimeReceipts where DCNo like @DCNo order by dbr_number desc"
        Try
            oDa.Fill(oDs)
            RejectedCalcinedLimeDetails = oDs.Tables(0).Copy
        Catch exp As Exception
            RejectedCalcinedLimeDetails = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
            oDa = Nothing
            oDs = Nothing
        End Try
    End Function
    Public Shared Function ProdConsumableRegisterDataForReport(ByVal FrDate As Date, ByVal ToDate As Date) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "ms_sp_ProdConsumableRegisterDataForReport"
        oDa.SelectCommand.CommandType = CommandType.StoredProcedure
        oDa.SelectCommand.Parameters.Add("@FrDate", SqlDbType.SmallDateTime, 4).Value = FrDate
        oDa.SelectCommand.Parameters.Add("@ToDate", SqlDbType.SmallDateTime, 4).Value = ToDate
        Try
            oDa.Fill(oDs)
            ProdConsumableRegisterDataForReport = oDs.Tables(0).Copy
        Catch exp As Exception
            ProdConsumableRegisterDataForReport = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetReportList() As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "select distinct Sl , Heading from ms_vw_ProdConsumableDetailsReportList " & _
            " order by Sl "
        Try
            oDa.Fill(oDs)
            GetReportList = oDs.Tables(0).Copy
        Catch exp As Exception
            GetReportList = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetReportItems(ByVal ItemSls As String) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "select distinct Details , TypeValue from ms_vw_ProdConsumableDetailsReportList" & _
            " where Sl = @Sl "
        oDa.SelectCommand.Parameters.Add("@Sl", SqlDbType.Int, 4).Value = ItemSls
        Try
            oDa.Fill(oDs)
            GetReportItems = oDs.Tables(0).Copy
        Catch exp As Exception
            GetReportItems = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetItems(ByVal ItemValue As Int16, ByVal Type As Int16) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        If Type = 1 Then
            oDa.SelectCommand.CommandText = "select LiningNo from ms_FurnaceLining" & _
                " where isnull(LastHeatNo,0) = 0 and LiningNo <> 'First time' " & _
                " and lt = @ItemValue order by LiningNo"
        ElseIf Type = 2 Then
            oDa.SelectCommand.CommandText = "select LiningItemNo from ms_FurnaceLining" & _
                " where isnull(LastHeatNo,0) = 0 and LiningNo <> 'First time'" & _
                " and lt = @ItemValue and LiningItemNo not in " & _
                " ( select ItemNo from ms_LiningItemsNotInUse where ItemName = @ItemName )" & _
                " order by LiningItemNo "
        ElseIf Type = 3 Then
            oDa.SelectCommand.CommandText = "select top 1 LiningNo from ms_FurnaceLining " & _
                " where lt = @ItemValue and left(LiningNo,1) in ( '2' , '3' )" & _
                " order by LiningNo desc"
        ElseIf Type = 4 Then
            oDa.SelectCommand.CommandText = "select LiningNo from ms_FurnaceLining" & _
                " where isnull(FirstHeatNo,0) = 0 and LiningNo <> 'First time' " & _
                " and lt = @ItemValue order by LiningNo"
        End If
        If ItemValue = 3 Then
            oDa.SelectCommand.Parameters.Add("@ItemName", SqlDbType.VarChar, 10).Value = "LadleNo"
        Else
            oDa.SelectCommand.Parameters.Add("@ItemName", SqlDbType.VarChar, 10).Value = "RoofNo"
        End If
        oDa.SelectCommand.Parameters.Add("@ItemValue", SqlDbType.Int, 4).Value = ItemValue
        Try
            oDa.Fill(oDs)
            GetItems = oDs.Tables(0).Copy
        Catch exp As Exception
            GetItems = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetLOADetails(ByVal LOANo As String, ByVal LT As Integer) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "select LiningNo , LiningItemNo Fur , LOANo ,  " & _
            " convert(varchar(10),LOADate,103) LOADate , ScheduledQty , CompletedQty  " & _
            " from ms_FurnaceLining where LOANo = @LOANo and LT = @LT " & _
            " order by LiningNo desc "

        oDa.SelectCommand.Parameters.Add("@LOANo", SqlDbType.VarChar, 50).Value = LOANo
        oDa.SelectCommand.Parameters.Add("@LT", SqlDbType.Int, 4).Value = LT
        Try
            oDa.Fill(oDs)
            GetLOADetails = oDs.Tables(0).Copy
        Catch exp As Exception
            GetLOADetails = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetLOADetails(ByVal LOANo As String) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "select sum(CompletedQty) CompQty , max(ScheduledQty) SchQty , max(LOADate) LOADate" & _
            " from ms_FurnaceLining a inner join ( select distinct LT , LiningType from ms_vw_LiningType ) b on a.LT = b.LT " & _
            " inner join ms_vw_LinedBy c on a.LB = c.LB" & _
            " where LOANo = @LOANo "
        oDa.SelectCommand.Parameters.Add("@LOANo", SqlDbType.VarChar, 50).Value = LOANo
        Try
            oDa.Fill(oDs)
            GetLOADetails = oDs.Tables(0).Copy
        Catch exp As Exception
            GetLOADetails = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetTopDetails(ByVal LiningItemNo As String, ByVal LT As Integer) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "select top 1 LiningNo , " & _
            " convert(varchar(10),HandedOverOn,103) HODt , convert(varchar(5),HandedOverOn,114) HOTime ," & _
            " convert(varchar(10),WorkStartedOn,103) WSDt , convert(varchar(5),WorkStartedOn,114) WSTime ," & _
            " convert(varchar(10),WorkCompletedOn,103) WCDt , convert(varchar(5),WorkCompletedOn,114) WCTime , " & _
            " InspectionNote , LOANo, convert(varchar(10),LOADate,103) LOADt , " & _
            " ScheduledQty SchQty , CompletedQty UsedQty , SlNo " & _
            " from ms_FurnaceLining a inner join ( select distinct LT , LiningType from ms_vw_LiningType ) b on a.LT = b.LT " & _
            " inner join ms_vw_LinedBy c on a.LB = c.LB" & _
            " where LiningItemNo = @LiningItemNo and a.LT = @LT " & _
            " order by WorkCompletedOn desc , LiningNo desc "

        oDa.SelectCommand.Parameters.Add("@LiningItemNo", SqlDbType.VarChar, 50).Value = LiningItemNo
        oDa.SelectCommand.Parameters.Add("@LT", SqlDbType.Int, 4).Value = LT
        Try
            oDa.Fill(oDs)
            GetTopDetails = oDs.Tables(0).Copy
        Catch exp As Exception
            GetTopDetails = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetTopFFL(ByVal LiningItemNo As String) As String
        Dim Done As Boolean = False
        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj

        oCmd.Parameters.Add("@LiningItemNo", SqlDbType.VarChar, 50).Value = LiningItemNo
        oCmd.Parameters.Add("@LiningNo", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
        oCmd.Connection.Open()
        Try
            oCmd.CommandText = " select top 1 @LiningNo = LiningNo from ms_FurnaceLining " & _
                " where  LT = 2 and LiningItemNo = @LiningItemNo order by WorkCompletedOn desc  "
            oCmd.ExecuteScalar()
            Return IIf(IsDBNull(oCmd.Parameters("@LiningNo").Value), "", oCmd.Parameters("@LiningNo").Value)
        Catch exp As Exception
            Throw New Exception("InValid Lining No !" & exp.Message)
        End Try
    End Function
    Public Shared Function GetWorkCompletedOn(ByVal LT As Integer, ByVal LiningItemNo As String, ByVal LiningNo As String) As Date
        Dim Done As Boolean = False
        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        oCmd.Parameters.Add("@LT", SqlDbType.Int, 4).Value = LT
        oCmd.Parameters.Add("@LiningItemNo", SqlDbType.VarChar, 50).Value = LiningItemNo
        oCmd.Parameters.Add("@LiningNo", SqlDbType.VarChar, 50).Value = LiningNo

        oCmd.Parameters.Add("@WorkCompletedOn", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output
        oCmd.Connection.Open()
        Try
            oCmd.CommandText = " select @WorkCompletedOn = WorkCompletedOn from ms_FurnaceLining " & _
                " where  LT = @LT and LiningNo = @LiningNo and LiningItemNo = @LiningItemNo "
            oCmd.ExecuteScalar()
            Return IIf(IsDBNull(oCmd.Parameters("@WorkCompletedOn").Value), "1900-01-01", oCmd.Parameters("@WorkCompletedOn").Value)
        Catch exp As Exception
            Throw New Exception("InValid Usage Date !" & exp.Message)
        Finally
            oCmd = Nothing
        End Try
    End Function
    Public Shared Function GetFirstHeatNo(ByVal LT As Integer, ByVal LiningItemNo As String, ByVal WorkCompletedOn As Date, ByVal LastHeatNo As Long) As Long
        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        If LT = 1 OrElse LT = 2 Then
            oCmd.CommandText = "select top 1 @FirstHeatNo = a.heat_number   " & _
                " from mm_vw_HeatTapped a inner join mm_heatsheet_header b on a.heat_number  = b.heat_number  " & _
                " where Heat_Tapped >= @WorkCompletedOn  and b.furnace_code = @LiningItemNo " & _
                " and a.heat_number < @LastHeatNo order by a.heat_number "
        ElseIf LT = 3 Then
            oCmd.CommandText = "select top 1 @FirstHeatNo = a.heat_number   " & _
                " from mm_vw_HeatTapped a inner join mm_ladle_details b on a.heat_number  = b.heat_number  " & _
                " where Heat_Tapped >= @WorkCompletedOn  and b.ladle_number = @LiningItemNo " & _
                " and a.heat_number < @LastHeatNo order by a.heat_number "
        Else
            oCmd.CommandText = "select top 1 @FirstHeatNo = a.heat_number   " & _
                " from mm_vw_HeatTapped a inner join mm_roof_details b on a.heat_number  = b.heat_number  " & _
                " where Heat_Tapped >= @WorkCompletedOn  and substring(ltrim(rtrim(roof_number)),3,2) = @LiningItemNo  " & _
                " and a.heat_number < @LastHeatNo order by a.heat_number "
        End If
        oCmd.Parameters.Add("@LiningItemNo", SqlDbType.VarChar, 50).Value = LiningItemNo
        oCmd.Parameters.Add("@WorkCompletedOn", SqlDbType.SmallDateTime, 4).Value = WorkCompletedOn
        oCmd.Parameters.Add("@LastHeatNo", SqlDbType.BigInt, 8).Value = LastHeatNo

        oCmd.Parameters.Add("@FirstHeatNo", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
        Try
            oCmd.Connection.Open()
            oCmd.ExecuteScalar()
            Return IIf(IsDBNull(oCmd.Parameters("@FirstHeatNo").Value), 0, oCmd.Parameters("@FirstHeatNo").Value)
        Catch exp As Exception
            Throw New Exception("InValid WorkCompletedOn Date !" & exp.Message)
        Finally
            oCmd = Nothing
        End Try
    End Function
    Public Shared Function GetLiningItems(ByVal ItemName As String) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        If ItemName = "LOA" Then
            oDa.SelectCommand.CommandText = "select distinct LOANo from ms_FurnaceLining " & _
                " where isnull(LOANo,'') <> '' order by LOANo desc "
        Else
            oDa.SelectCommand.CommandText = "select ItemNo from ms_vw_LiningItems where ItemName = @ItemName " & _
                " order by ItemNo "
            oDa.SelectCommand.Parameters.Add("@ItemName", SqlDbType.VarChar, 50).Value = ItemName
        End If

        Try
            oDa.Fill(oDs)
            GetLiningItems = oDs.Tables(0).Copy
        Catch exp As Exception
            GetLiningItems = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetSavedRemarks(ByVal LiningNo As String, ByVal LT As Integer) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = " select MaxErosion , ErosionLoc , MaxPenitration ," & _
                " PenitrationLoc , LiningCondition , AreaCon , " & _
                " case when Spalling = 0 and LT = 3 then 'No Spalling' " & _
                " when Spalling = 1 and LT = 3 then 'Spalling' else '' end Spalling , " & _
                " SpallingDepth , SpallingArea , Remarks , RefCondemned RefCondDueTo " & _
                " from ms_FurnaceLiningRemarks a inner join ms_vw_RefCondemned b " & _
                " on DueTo = Sl where LiningNo = @LiningNo and LT = @LT "

        oDa.SelectCommand.Parameters.Add("@LiningNo", SqlDbType.VarChar, 50).Value = LiningNo
        oDa.SelectCommand.Parameters.Add("@LT", SqlDbType.Int, 4).Value = LT
        Try
            oDa.Fill(oDs)
            GetSavedRemarks = oDs.Tables(0).Copy
        Catch exp As Exception
            GetSavedRemarks = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetSavedPLs(ByVal LiningNo As String, ByVal LT As Integer) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = " select PLNumber , PODBRNo , Qty , SetNo from ms_FurnaceLiningPLs" & _
                " where LiningNo = @LiningNo and LT = @LT "

        oDa.SelectCommand.Parameters.Add("@LiningNo", SqlDbType.VarChar, 50).Value = LiningNo
        oDa.SelectCommand.Parameters.Add("@LT", SqlDbType.Int, 4).Value = LT
        Try
            oDa.Fill(oDs)
            GetSavedPLs = oDs.Tables(0).Copy
        Catch exp As Exception
            GetSavedPLs = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetFurnaceLiningPLs(ByVal pl_number As String) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        If pl_number = "81970791" Then
            oDa.SelectCommand.CommandText = "select top 5 lpdbr_number , lpdbr_number+'--'+ltrim(Supplier)  Supplier from ms_vw_LPDetails" & _
                " where pl_number = @pl_number order by lpdbr_number desc"
        Else
            oDa.SelectCommand.CommandText = "select top 10 a.po_number , a.po_number+'--'+ltrim(rtrim(c.name)) Supplier" & _
                " FROM dbo.pm_po_header a INNER JOIN dbo.pm_po_details b ON a.po_number = b.po_number " & _
                " INNER JOIN dbo.pm_supplier_master c ON a.supplier_code = c.supplier_code " & _
                " where b.pl_number = @pl_number order by po_date desc "
        End If

        oDa.SelectCommand.Parameters.Add("@pl_number", SqlDbType.VarChar, 50).Value = pl_number
        Try
            oDa.Fill(oDs)
            GetFurnaceLiningPLs = oDs.Tables(0).Copy
        Catch exp As Exception
            GetFurnaceLiningPLs = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetFurnaceLiningDetails(ByVal LT As Integer, ByVal LiningNo As String) As DataSet
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        If LT = 3 OrElse LT = 4 Then
            oDa.SelectCommand.CommandText = "select LiningItemNo No , FirstHeatNo , LastHeatNo , " & _
                " convert(varchar(10),HandedOverOn,103) HODt , convert(varchar(5),HandedOverOn,114) HOTime ," & _
                " convert(varchar(10),WorkStartedOn,103) WSDt , convert(varchar(5),WorkStartedOn,114) WSTime ," & _
                " convert(varchar(10),WorkCompletedOn,103) WCDt , convert(varchar(5),WorkCompletedOn,114) WCTime , " & _
                " InspectionNote , LOANo, convert(varchar(10),LOADate,103) LOADt , ScheduledQty, CompletedQty, SlNo " & _
                " from ms_FurnaceLining a inner join ( select distinct LT , LiningType from ms_vw_LiningType ) b on a.LT = b.LT " & _
                " inner join ms_vw_LinedBy c on a.LB = c.LB" & _
                " where LiningNo = @LiningNo and a.LT = @LT ; " & _
                " select distinct PLNumber , rtrim(short_description) PLDescription , UnitName" & _
                " from ms_FurnaceLining a inner join ms_vw_LiningType b on a.LT = b.LT " & _
                " inner join ms_vw_LinedBy c on a.LB = c.LB inner join pm_ItemMaster d " & _
                " on PLNumber = PL_Number" & _
                " where LiningNo = @LiningNo and a.LT = @LT " & _
                " and PLNumber not in ('84982196','84029584','84982378','84982860','84028889')  " & _
                " union " & _
                " select distinct PLNumber , rtrim(short_description) PLDescription , wap.dbo.ms_fn_PlUnitName(PLNumber) " & _
                " from ms_FurnaceLining a inner join ms_vw_LiningType b on a.LT = b.LT " & _
                " inner join ms_vw_LinedBy c on a.LB = c.LB inner join pm_Item_Master d " & _
                " on PLNumber = PL_Number where LiningNo = @LiningNo and a.LT = @LT " & _
                " and PLNumber not in  ('84982196','84029584','84982378','84982860','84028889')  " & _
                " order by PLDescription"
        Else
            oDa.SelectCommand.CommandText = "select LiningItemNo No , FirstHeatNo , LastHeatNo , " & _
                " convert(varchar(10),HandedOverOn,103) HODt , convert(varchar(5),HandedOverOn,114) HOTime ," & _
                " convert(varchar(10),WorkStartedOn,103) WSDt , convert(varchar(5),WorkStartedOn,114) WSTime ," & _
                " convert(varchar(10),WorkCompletedOn,103) WCDt , convert(varchar(5),WorkCompletedOn,114) WCTime , " & _
                " InspectionNote , LOANo, convert(varchar(10),LOADate,103) LOADt , ScheduledQty, CompletedQty, SlNo " & _
                " from ms_FurnaceLining a inner join ( select distinct LT , LiningType from ms_vw_LiningType ) b on a.LT = b.LT " & _
                " inner join ms_vw_LinedBy c on a.LB = c.LB" & _
                " where LiningNo = @LiningNo and a.LT = @LT ; " & _
                " select distinct PLNumber , rtrim(short_description) PLDescription , UnitName" & _
                " from ms_FurnaceLining a inner join ms_vw_LiningType b on a.LT = b.LT " & _
                " inner join ms_vw_LinedBy c on a.LB = c.LB inner join pm_ItemMaster d " & _
                " on PLNumber = PL_Number" & _
                " where LiningNo = @LiningNo and a.LT = @LT " & _
                " and PLNumber not in ('84982196','84982378','84982860','84028889')  " & _
                " union " & _
                " select distinct PLNumber , rtrim(short_description) PLDescription , wap.dbo.ms_fn_PlUnitName(PLNumber) " & _
                " from ms_FurnaceLining a inner join ms_vw_LiningType b on a.LT = b.LT " & _
                " inner join ms_vw_LinedBy c on a.LB = c.LB inner join pm_Item_Master d " & _
                " on PLNumber = PL_Number where LiningNo = @LiningNo and a.LT = @LT " & _
                " and PLNumber not in  ('84982196','84982378','84982860','84028889')  " & _
                " order by PLDescription"
        End If


        oDa.SelectCommand.Parameters.Add("@LiningNo", SqlDbType.VarChar, 50).Value = LiningNo
        oDa.SelectCommand.Parameters.Add("@LT", SqlDbType.Int, 4).Value = LT
        Try
            oDa.Fill(oDs)
            GetFurnaceLiningDetails = oDs.Copy
        Catch exp As Exception
            GetFurnaceLiningDetails = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetFurnaceLiningNos(ByVal LT As Long, ByVal LB As Long) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "select distinct LiningNo " & _
            " from ms_FurnaceLining a inner join ( select distinct LT , LiningType from ms_vw_LiningType ) b on a.LT = b.LT  " & _
            " inner join ms_vw_LinedBy c on a.LB = c.LB " & _
            " where a.LT = @LT  and a.LB = @LB order by LiningNo desc "
        oDa.SelectCommand.Parameters.Add("@LT", SqlDbType.Int, 4).Value = LT
        oDa.SelectCommand.Parameters.Add("@LB", SqlDbType.Int, 4).Value = LB
        Try
            oDa.Fill(oDs)
            GetFurnaceLiningNos = oDs.Tables(0).Copy
        Catch exp As Exception
            GetFurnaceLiningNos = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetLiningHeatData(ByVal HeatNo As Long, ByVal Type As Int16) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        If Type = 1 OrElse Type = 2 Then
            oDa.SelectCommand.CommandText = "select ltrim(rtrim(furnace_code)) No ,  " & _
                " convert(varchar(10),TappedDate,103) TappedDt  , TappedShift Sh , " & _
                " convert(varchar(5),Heat_Tapped,114) TapTime " & _
                " from mm_vw_HeatTapped a inner join mm_heatsheet_header b" & _
                " on a.heat_number = b.heat_number" & _
                " where a.heat_number = @HeatNo "
        ElseIf Type = 3 Then
            oDa.SelectCommand.CommandText = "select ltrim(rtrim(ladle_number)) No ,   " & _
                " convert(varchar(10),TappedDate,103) TappedDt  , TappedShift Sh , " & _
                " convert(varchar(5),Heat_Tapped,114) TapTime " & _
                " from mm_vw_HeatTapped a inner join mm_ladle_details b" & _
                " on a.heat_number = b.heat_number" & _
                " where a.heat_number = @HeatNo "
        Else
            oDa.SelectCommand.CommandText = "select substring(ltrim(rtrim(roof_number)),3,2) No ,  " & _
                " convert(varchar(10),TappedDate,103) TappedDt  , TappedShift Sh , " & _
                " convert(varchar(5),Heat_Tapped,114) TapTime " & _
                " from mm_vw_HeatTapped a inner join mm_roof_details b" & _
                " on a.heat_number = b.heat_number" & _
                " where a.heat_number = @HeatNo "
        End If
        oDa.SelectCommand.Parameters.Add("@HeatNo", SqlDbType.BigInt, 8).Value = HeatNo
        Try
            oDa.Fill(oDs)
            GetLiningHeatData = oDs.Tables(0).Copy
        Catch exp As Exception
            GetLiningHeatData = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetLiningSavedData(ByVal LT As Integer, ByVal LB As Integer) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "select top 6 LiningNo , " & _
            " case when a.LT = 1 then 'FWP' when a.LT = 2 then 'FFL' when a.LT = 3 then 'LRL' else 'RRL' end LingType , " & _
            " LinedBy , LiningItemNo , FirstHeatNo , LastHeatNo , " & _
            " convert(varchar(10),HandedOverOn,103) HODt , convert(varchar(5),HandedOverOn,114) HOTime ," & _
            " convert(varchar(10),WorkStartedOn,103) WSDt , convert(varchar(5),WorkStartedOn,114) WSTime ," & _
            " convert(varchar(10),WorkCompletedOn,103) WCDt , convert(varchar(5),WorkCompletedOn,114) WCTime , " & _
            " InspectionNote , LOANo, convert(varchar(10),LOADate,103) LOADt , ScheduledQty SchQty , CompletedQty UsedQty , " & _
            " BTT , BMOM , TTT , TMOM , Depth ,  SlNo " & _
            " from ms_FurnaceLining a inner join ( select distinct LT , LiningType from ms_vw_LiningType ) b on a.LT = b.LT " & _
            " inner join ms_vw_LinedBy c on a.LB = c.LB" & _
            " where a.LT = @LT and a.LB = @LB  order by WorkCompletedOn desc , LiningNo desc"
        oDa.SelectCommand.Parameters.Add("@LT", SqlDbType.Int, 4).Value = LT
        oDa.SelectCommand.Parameters.Add("@LB", SqlDbType.Int, 4).Value = LB
        Try
            oDa.Fill(oDs)
            GetLiningSavedData = oDs.Tables(0).Copy
        Catch exp As Exception
            GetLiningSavedData = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetLiningData(ByVal LiningNo As String, ByVal LT As Int16) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "select a.LiningNo , " & _
            " case when a.LT = 1 then 'FWP' when a.LT = 2 then 'FFL' when a.LT = 3 then 'LRL' else 'RRL' end LingType , " & _
            " LinedBy , a.LiningItemNo , d.LastHeatNo , a.PreLiningNo ,  " & _
            " convert(varchar(10),a.HandedOverOn,103) HODt , convert(varchar(5),a.HandedOverOn,114) HOTime ," & _
            " convert(varchar(10),a.WorkStartedOn,103) WSDt , convert(varchar(5),a.WorkStartedOn,114) WSTime ," & _
            " convert(varchar(10),a.WorkCompletedOn,103) WCDt , convert(varchar(5),a.WorkCompletedOn,114) WCTime , " & _
            " a.InspectionNote , a.LOANo, convert(varchar(10),a.LOADate,103) LOADt , a.ScheduledQty, a.CompletedQty,  " & _
            " a.BTT , a.BMOM , a.TTT , a.TMOM , a.Depth ,  a.SlNo , a.GroupLeader1 , a.GroupLeader2 , a.LOARemarks " & _
            " from ms_FurnaceLining a inner join ( select distinct LT , LiningType from ms_vw_LiningType ) b on a.LT = b.LT " & _
            " inner join ms_vw_LinedBy c on a.LB = c.LB left outer join ms_FurnaceLining d " & _
            " on a.PreLiningNo = d.LiningNo and a.LT = d.LT  where a.LiningNo = @LiningNo and a.LT = @LT "
        oDa.SelectCommand.Parameters.Add("@LiningNo", SqlDbType.VarChar, 50).Value = LiningNo
        oDa.SelectCommand.Parameters.Add("@LT", SqlDbType.VarChar, 50).Value = LT
        Try
            oDa.Fill(oDs)
            GetLiningData = oDs.Tables(0).Copy
        Catch exp As Exception
            GetLiningData = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetStockIDNStatusListDetails(ByVal FromDt As Date, ByVal ToDt As Date, ByVal Type As String, ByVal ID As Integer) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandType = CommandType.StoredProcedure
        oDa.SelectCommand.CommandText = "ms_sp_StockIDNStatusListDetails"
        oDa.SelectCommand.Parameters.Add("@FromDt", SqlDbType.SmallDateTime, 4).Value = FromDt
        oDa.SelectCommand.Parameters.Add("@ToDt", SqlDbType.SmallDateTime, 4).Value = ToDt
        oDa.SelectCommand.Parameters.Add("@Type", SqlDbType.VarChar, 50).Value = Type
        oDa.SelectCommand.Parameters.Add("@ID", SqlDbType.Int, 4).Value = ID
        Try
            oDa.Fill(oDs)
            GetStockIDNStatusListDetails = oDs.Tables(0).Copy
        Catch exp As Exception
            GetStockIDNStatusListDetails = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetCALCINEDLIMERejPOs() As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "select distinct a.po_number , a.po_number+' - - '+ltrim(rtrim(d.name)) SupplierName" & _
            " from dm_dbr_header a inner join dm_dbr_detail b " & _
            " on a.dbr_number = b.dbr_number and b.pl_number = '81908167'" & _
            " inner join pm_po_header c on a.po_number = c.po_number" & _
            " inner join pm_supplier_master d on  d.supplier_code = c.supplier_code  "
        Try
            oDa.Fill(oDs)
            GetCALCINEDLIMERejPOs = oDs.Tables(0).Copy
        Catch exp As Exception
            GetCALCINEDLIMERejPOs = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetProdConsumableDumpRegisterPOs(ByVal pl_number As String) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "select distinct po_number" & _
            " from ms_MaterialDumpRegister a inner join ms_vw_MaterialDumpRegister b" & _
            " on a.dbr_number = b.dbr_number where isnull(FromHeat,0) <> 0" & _
            " and b.pl_number = @pl_number " & _
            " order by po_number desc "
        oDa.SelectCommand.Parameters.Add("@pl_number", SqlDbType.VarChar, 8).Value = pl_number
        Try
            oDa.Fill(oDs)
            GetProdConsumableDumpRegisterPOs = oDs.Tables(0).Copy
        Catch exp As Exception
            GetProdConsumableDumpRegisterPOs = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetProdConsumableDumpRegisterPLs() As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "select b.ward , a.pl_number , rtrim(short_description) PLDescr " & _
            " from ( select distinct pl_number " & _
            " from ms_MaterialDumpRegister a inner join ms_vw_MaterialDumpRegister b" & _
            " on a.dbr_number = b.dbr_number where isnull(FromHeat,0) <> 0 and ToHeat > 0 ) a" & _
            " inner join pm_ItemMaster b" & _
            " on b.pl_number = a.PL_number" & _
            " order by b.ward , a.PL_number "
        Try
            oDa.Fill(oDs)
            GetProdConsumableDumpRegisterPLs = oDs.Tables(0).Copy
        Catch exp As Exception
            GetProdConsumableDumpRegisterPLs = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetProdConsumableRegisterPL(ByVal Consignee As String) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "select distinct b.ward , a.PLNO , a.PLNO+'--'+rtrim(short_description) PLDescr" & _
            " from ms_vw_ProdConsumableDetails a " & _
            " inner join ms_vw_ProdConsumables b" & _
            " on b.PLNO = a.PLNO inner join pm_ItemMaster c" & _
            " on b.PLNO = c.PL_number where b.Consignee  = @Consignee " & _
            " order by b.ward , a.PLNO "
        oDa.SelectCommand.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = Consignee
        Try
            oDa.Fill(oDs)
            GetProdConsumableRegisterPL = oDs.Tables(0).Copy
        Catch exp As Exception
            GetProdConsumableRegisterPL = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetProdConsumableRegisterPLs(ByVal Consignee As String) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "select distinct c.ward , a.PLNO , rtrim(short_description) PLDescr" & _
            " from ms_vw_ProdConsumableDetails a " & _
            " inner join ms_vw_ProdConsumables b" & _
            " on b.PLNO = a.PLNO inner join pm_ItemMaster c" & _
            " on b.PLNO = c.PL_number where b.Consignee  = @Consignee " & _
            " order by c.ward , a.PLNO "
        oDa.SelectCommand.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = Consignee
        Try
            oDa.Fill(oDs)
            GetProdConsumableRegisterPLs = oDs.Tables(0).Copy
        Catch exp As Exception
            GetProdConsumableRegisterPLs = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetTopAccontalDate() As Date
        Dim Done As Boolean = False
        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj

        oCmd.Parameters.Add("@UsageDate", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output
        oCmd.Connection.Open()
        Try
            oCmd.CommandText = " select top 1 @UsageDate = UsageDate from ms_ScrapAccontal order by UsageDate desc "
            oCmd.ExecuteScalar()
            Return IIf(IsDBNull(oCmd.Parameters("@UsageDate").Value), Now.Date, oCmd.Parameters("@UsageDate").Value)
        Catch exp As Exception
            Throw New Exception("InValid Usage Date !" & exp.Message)
        End Try
    End Function
    Public Shared Function GetProdConsumablesDataForReport(ByVal FrDate As Date, ByVal ToDate As Date) As Boolean
        Dim Done As Boolean = False
        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        oCmd.Parameters.Add("@FrDate", SqlDbType.SmallDateTime, 4).Value = FrDate
        oCmd.Parameters.Add("@ToDate", SqlDbType.SmallDateTime, 4).Value = ToDate
        oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
        oCmd.Connection.Open()
        Try
            oCmd.CommandText = " select @cnt = count(*) from ms_ProdConsumablesDataForReport " & _
                " where FrDate >= @FrDate and ToDate <= @ToDate "
            oCmd.ExecuteScalar()
            Return IIf(IsDBNull(oCmd.Parameters("@cnt").Value), Now.Date, oCmd.Parameters("@cnt").Value)
        Catch exp As Exception
            Throw New Exception("InValid Usage Date !" & exp.Message)
        End Try
    End Function
    Public Shared Function PLConsumptionDetails(ByVal Consignee As String, ByVal ConsumDate As Date, ByVal PLNumber As String) As DataSet
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "mm_sp_RMRConsumption"
        oDa.SelectCommand.CommandType = CommandType.StoredProcedure
        oDa.SelectCommand.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = Consignee
        oDa.SelectCommand.Parameters.Add("@ConsumDate", SqlDbType.SmallDateTime, 4).Value = ConsumDate
        oDa.SelectCommand.Parameters.Add("@PLNumber", SqlDbType.VarChar, 8).Value = PLNumber
        oDa.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 0
        Try
            oDa.Fill(oDs)
            PLConsumptionDetails = oDs.Copy
        Catch exp As Exception
            PLConsumptionDetails = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function PLConsumptionMonthDetails(ByVal Consignee As String, ByVal ConsumDate As Date, ByVal PLNumber As String) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "mm_sp_RMRConsumption"
        oDa.SelectCommand.CommandType = CommandType.StoredProcedure
        oDa.SelectCommand.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = Consignee
        oDa.SelectCommand.Parameters.Add("@ConsumDate", SqlDbType.SmallDateTime, 4).Value = ConsumDate
        oDa.SelectCommand.Parameters.Add("@PLNumber", SqlDbType.VarChar, 8).Value = "ALL"
        oDa.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 1
        Try
            oDa.Fill(oDs)
            PLConsumptionMonthDetails = oDs.Tables(0).Copy
        Catch exp As Exception
            PLConsumptionMonthDetails = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetProdConsumablePLs(ByVal Consignee As String) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "select PLNumber from ms_ProdConsumableList" & _
            " where Consignee = @Consignee order by PLNumber "
        oDa.SelectCommand.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = Consignee
        Try
            oDa.Fill(oDs)
            GetProdConsumablePLs = oDs.Tables(0).Copy
        Catch exp As Exception
            GetProdConsumablePLs = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function ScrapAccontalData(ByVal UsageDate As Date) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "ms_sp_ScrapAccontal"
        oDa.SelectCommand.CommandType = CommandType.StoredProcedure
        oDa.SelectCommand.Parameters.Add("@FrDate", SqlDbType.SmallDateTime, 4).Value = UsageDate
        oDa.SelectCommand.Parameters.Add("@ToDate", SqlDbType.SmallDateTime, 4).Value = UsageDate
        oDa.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 2
        Try
            oDa.Fill(oDs)
            ScrapAccontalData = oDs.Tables(0).Copy
        Catch exp As Exception
            ScrapAccontalData = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function ScrapAccontal(ByVal UsageDate As Date) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "ms_sp_ScrapAccontal_test"
        oDa.SelectCommand.CommandType = CommandType.StoredProcedure
        oDa.SelectCommand.Parameters.Add("@FrDate", SqlDbType.SmallDateTime, 4).Value = UsageDate
        oDa.SelectCommand.Parameters.Add("@ToDate", SqlDbType.SmallDateTime, 4).Value = UsageDate
        oDa.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 1
        Try
            oDa.Fill(oDs)
            ScrapAccontal = oDs.Tables(0).Copy
        Catch exp As Exception
            ScrapAccontal = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function ScrapAccontalReceipt(ByVal UsageDate As Date) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "ms_sp_ScrapAccontal"
        oDa.SelectCommand.CommandType = CommandType.StoredProcedure
        oDa.SelectCommand.Parameters.Add("@FrDate", SqlDbType.SmallDateTime, 4).Value = UsageDate
        oDa.SelectCommand.Parameters.Add("@ToDate", SqlDbType.SmallDateTime, 4).Value = UsageDate
        oDa.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 0
        Try
            oDa.Fill(oDs)
            ScrapAccontalReceipt = oDs.Tables(0).Copy
        Catch exp As Exception
            ScrapAccontalReceipt = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function MaterialDumpRegisterData(ByVal po_number As String) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "ms_sp_MaterialDumpRegisterData"
        oDa.SelectCommand.CommandType = CommandType.StoredProcedure
        oDa.SelectCommand.Parameters.Add("@po_number", SqlDbType.VarChar, 9).Value = po_number
        Try
            oDa.Fill(oDs)
            MaterialDumpRegisterData = oDs.Tables(0).Copy
        Catch exp As Exception
            MaterialDumpRegisterData = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function ScrapReceipt(ByVal ReceiptDate As Date) As Boolean
        Dim Done As Boolean = False
        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        oCmd.Parameters.Add("@ReceiptDate", SqlDbType.SmallDateTime, 4).Value = ReceiptDate
        oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
        oCmd.Connection.Open()
        Try
            oCmd.CommandText = " select @cnt = count(*) from ms_vw_ScrapReceipt " & _
                " where ReceiptDate = @ReceiptDate "
            oCmd.ExecuteScalar()
            Return IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)
        Catch exp As Exception
            Throw New Exception("InValid Receipt Date !" & exp.Message)
        End Try
    End Function
    Public Shared Function ScrapAccontalCB(ByVal UsageDate As Date) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "select convert(varchar(10),AsOn,103) CBDate , " & _
            " WheelCut , RailCut , AxleEndCut , ProScrap , RisersHub , LMS , ChipsAMSCR , MRXCWheel , MRRisersHub " & _
            " from ms_ScrapAccontalCB " & _
            " where month(AsOn) = month(@UsageDate) and year(AsOn) = year(@UsageDate) "
        oDa.SelectCommand.Parameters.Add("@UsageDate", SqlDbType.SmallDateTime, 4).Value = UsageDate
        Try
            oDa.Fill(oDs)
            ScrapAccontalCB = oDs.Tables(0).Copy
        Catch exp As Exception
            ScrapAccontalCB = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function MaterialDumpRegisterPLDetails(ByVal Consignee As String, ByVal PLNO As String) As DataSet
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "select top 30 a.* " & _
            " from ms_MaterialDumpRegister a inner join ms_ProdConsumables b " & _
            " on a.PLNO = b.PLNO where b.Consignee = @Consignee and a.PLNO = @PLNO order by FromHeat  desc ; " & _
            " select distinct po_number , SupplierName " & _
            " from ms_vw_MaterialDumpRegister a inner join ms_ProdConsumables b " & _
            " on a.PLNO = b.PLNO inner join ms_MaterialDumpRegister c on a.dbr_number = c.dbr_number " & _
            " where b.Consignee = @Consignee and a.PLNO = @PLNO "
        oDa.SelectCommand.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = Consignee
        oDa.SelectCommand.Parameters.Add("@PLNO", SqlDbType.VarChar, 9).Value = PLNO
        Try
            oDa.Fill(oDs)
            MaterialDumpRegisterPLDetails = oDs.Copy
        Catch exp As Exception
            MaterialDumpRegisterPLDetails = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function MaterialDumpRegisterPLs(ByVal Consignee As String) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "select PLNO , short_description " & _
            " from ( select distinct Consignee , PLNO from ms_vw_MaterialDumpRegister )  a inner join pm_ItemMaster b" & _
            " on PLNO = pl_number where a.Consignee = @Consignee order by ward , pl_number "
        oDa.SelectCommand.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = Consignee
        Try
            oDa.Fill(oDs)
            MaterialDumpRegisterPLs = oDs.Tables(0).Copy
        Catch exp As Exception
            MaterialDumpRegisterPLs = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function MaterialDumpRegister(ByVal Consignee As String, ByVal PLNo As String, ByVal Frdt As Date, ByVal ToDt As Date) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = " select DumpNo , " & _
            " dbr_number , convert(varchar(10),dbr_date,103) dbr_date ,  " & _
            " SupplierName , po_number , PODate , AccQty , RejQty , RejReasons ," & _
            " idn_number , idn_date , idn_quantity IDNQty , receipt_note_remarks " & _
            " from ms_vw_MaterialDumpRegister " & _
            " where Consignee = @Consignee and PLNO = @PLNO and dbr_date between @FrDt and @ToDt " & _
            " order by dbr_number desc"
        oDa.SelectCommand.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = Consignee
        oDa.SelectCommand.Parameters.Add("@PLNo", SqlDbType.VarChar, 9).Value = PLNo
        oDa.SelectCommand.Parameters.Add("@FrDt", SqlDbType.SmallDateTime, 4).Value = Frdt
        oDa.SelectCommand.Parameters.Add("@ToDt", SqlDbType.SmallDateTime, 4).Value = ToDt
        Try
            oDa.Fill(oDs)
            MaterialDumpRegister = oDs.Tables(0).Copy
        Catch exp As Exception
            MaterialDumpRegister = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function MaterialDumpInspectedBy(ByVal dbr_number As String) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = " select receipt_note_remarks " & _
            " from ms_vw_MaterialDumpRegister " & _
            " where dbr_number = @dbr_number "
        oDa.SelectCommand.Parameters.Add("@dbr_number", SqlDbType.VarChar, 50).Value = dbr_number
        Try
            oDa.Fill(oDs)
            MaterialDumpInspectedBy = oDs.Tables(0).Copy
        Catch exp As Exception
            MaterialDumpInspectedBy = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function ProdConsumableDetailsData(ByVal FromDate As Date, ByVal ToDate As Date, ByVal FrHt As Long, ByVal ToHt As Long, ByVal PL As String, ByVal Type As Integer) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "ms_sp_ProdConsumableData"
        oDa.SelectCommand.CommandType = CommandType.StoredProcedure
        oDa.SelectCommand.CommandTimeout = 3600
        oDa.SelectCommand.Parameters.Add("@FrDate", SqlDbType.SmallDateTime, 4).Value = FromDate
        oDa.SelectCommand.Parameters.Add("@ToDate", SqlDbType.SmallDateTime, 4).Value = ToDate
        oDa.SelectCommand.Parameters.Add("@FrHt", SqlDbType.BigInt, 8).Value = FrHt
        oDa.SelectCommand.Parameters.Add("@ToHt", SqlDbType.BigInt, 8).Value = ToHt
        oDa.SelectCommand.Parameters.Add("@PLorFur", SqlDbType.VarChar, 10).Value = PL.Trim
        oDa.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = Type

        Try
            oDa.Fill(oDs)
            ProdConsumableDetailsData = oDs.Tables(0).Copy
        Catch exp As Exception
            ProdConsumableDetailsData = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetTappedDate(ByVal FromHeat As Long) As Date
        Dim Done As Boolean = False
        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj

        oCmd.Parameters.Add("@TappedDate", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output
        oCmd.Parameters.Add("@FromHeat", SqlDbType.BigInt, 9).Value = FromHeat
        oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
        oCmd.Connection.Open()
        Try
            oCmd.CommandText = " select @TappedDate = TappedDate from mm_vw_HeatTapped " & _
                " where Heat_number = @FromHeat  "
            oCmd.ExecuteScalar()
            Return IIf(IsDBNull(oCmd.Parameters("@TappedDate").Value), Now.Date, oCmd.Parameters("@TappedDate").Value)
        Catch exp As Exception
            Throw New Exception("InValid From Heat !" & exp.Message)
        End Try
    End Function
    Public Shared Function CalcinedLimeDetails(ByVal DCNo As String) As DataSet
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "select top 3 * from ms_vw_CalcinedLimeReceipts " & _
            " where DCNo like @DCNo order by dbr_number desc ; " & _
            " select top 3 * from ms_vw_CalcinedLimeResults " & _
            " where SampleBatchNumber like @SampleNo  and right(TestDate,4) >= '2015' order by LabNo desc ; " & _
            " select isnull(count(*),0) cnt  from ms_CalcinedLimeDetails " & _
            " where DCNo like @DCNo "
        oDa.SelectCommand.Parameters.Add("@DCNo", SqlDbType.VarChar, 10).Value = "%" + DCNo.Trim + "%"
        oDa.SelectCommand.Parameters.Add("@SampleNo", SqlDbType.VarChar, 10).Value = "%" + DCNo.Trim + " %"
        Try
            oDa.Fill(oDs)
            CalcinedLimeDetails = oDs.Copy
        Catch exp As Exception
            CalcinedLimeDetails = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
            oDa = Nothing
            oDs = Nothing
        End Try
    End Function
    Public Shared Function PreHeatedLadleDetails(ByVal PreHeatdate As Date, ByVal LadleNo As String) As DataSet
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "select convert(varchar(10),PreHeatdate,103) PreHeatdate " & _
            " from ms_PreHeatedLadleDetails " & _
            " where LadleNo = @LadleNo " & _
            " and month(PreHeatdate) = month(@PreHeatdate) and year(PreHeatdate) = year(@PreHeatdate) " & _
            " order by PreHeatdate ; " & _
            " select LadleNo , count(*) NoOfTimes " & _
            " from ms_PreHeatedLadleDetails " & _
            " where month(PreHeatdate) = month(@PreHeatdate) and year(PreHeatdate) = year(@PreHeatdate) " & _
            " group by LadleNo order by LadleNo ; " & _
            " select convert(varchar(10),PreHeatdate,103) PreHeatdate , LadleNo , Sl" & _
            " from ms_PreHeatedLadleDetails " & _
            " where PreHeatdate = @PreHeatdate" & _
            " order by LadleNo "
        oDa.SelectCommand.Parameters.Add("@PreHeatdate", SqlDbType.SmallDateTime, 4).Value = PreHeatdate
        oDa.SelectCommand.Parameters.Add("@LadleNo", SqlDbType.VarChar, 5).Value = LadleNo
        Try
            oDa.Fill(oDs)
            PreHeatedLadleDetails = oDs.Copy
        Catch exp As Exception
            PreHeatedLadleDetails = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function CalcinedLimeDetails(ByVal ReceiptDate As Date) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "select row_number() over ( order by FromHeat , YearSl , a.DCNo , Sl ) SlNo , YearSl , " & _
            " a.DCNo  , convert(varchar(10),ReceiptDate,103) ReceiptDt , " & _
            " a.dbr_number , a.LabNo , a.RecQty , " & _
            " FromHeat , ToHeat, NoOfBags Bags , " & _
            " case when Result = 0 then 'Passed'" & _
            "      when Result = 1 then 'Failed' else '' end Result , " & _
            " Remarks, DumpNo, b.SupplierName , Sl " & _
            " from ms_CalcinedLimeDetails a inner join ms_vw_CalcinedLimeReceipts b" & _
            " on a.dbr_number = b.dbr_number left outer join ms_vw_CalcinedLimeResults c" & _
            " on a.LabNo = c.LabNo" & _
            " where month(ReceiptDate) = month(@ReceiptDate) " & _
            " and year(ReceiptDate) = year(@ReceiptDate)" & _
            " order by FromHeat desc , YearSl desc , a.DCNo desc , Sl desc "
        oDa.SelectCommand.Parameters.Add("@ReceiptDate", SqlDbType.SmallDateTime, 4).Value = ReceiptDate
        Try
            oDa.Fill(oDs)
            CalcinedLimeDetails = oDs.Tables(0).Copy
        Catch exp As Exception
            CalcinedLimeDetails = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function ScrapDetails(ByVal ReceiptDate As Date, ByVal SlNo As Integer) As DataSet
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "select a.pl_number , " & _
            " convert(varchar(10),ReceiptDate,103) ReceiptDt , " & _
            " WagonNo , a.ScrapName , ReceiptQty , Remarks , " & _
            " WheelCut , RailCut , AxleEndCut , " & _
            " LMS , AMSChips , ChipsWFPS , ProScrap , Sl   from ms_vw_ScrapDetails  a " & _
            " inner join ms_vw_ScrapList b on a.ScrapName  = b.ScrapName " & _
            " where ReceiptDate = @ReceiptDate and  ScrapType = 'Receipts' and SlNo = @SlNo order by ReceiptDate ; " & _
            " select convert(varchar(7),@ReceiptDate,111) Month , a.PLNO , PLDescription , TransQty DrawnQty " & _
            " from ms_vw_ProdConsumables a " & _
            " inner join (  select distinct pl_number from ms_vw_ScrapList" & _
            " where ScrapType = 'Receipts' ) b on a.PLNO = pl_number" & _
            " left outer join ms_vw_ProdConsumableSummary c" & _
            " on c.PLNO = a.PLNO " & _
            " where TransMonth  =  convert(varchar(6),@ReceiptDate,112)  "
        oDa.SelectCommand.Parameters.Add("@ReceiptDate", SqlDbType.SmallDateTime, 4).Value = ReceiptDate
        oDa.SelectCommand.Parameters.Add("@SlNo", SqlDbType.Int, 4).Value = SlNo
        Try
            oDa.Fill(oDs)
            ScrapDetails = oDs.Copy
        Catch exp As Exception
            ScrapDetails = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function ReturnedStoresDetails(ByVal ReturnedDt As Date) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "select  pl_number , convert(varchar(10),ReturnedDt,103) ReturnedDt , " & _
            " WeigtSlipNo , MatrName , ReturnedQty , Remarks , " & _
            " Skull , Slag, CondGrEld, CondSlagPot, Sl" & _
            " from ms_vw_ReturnedStoresDetails " & _
            " where ReturnedDt = @ReturnedDt order by ReturnedDt ; "
        oDa.SelectCommand.Parameters.Add("@ReturnedDt", SqlDbType.SmallDateTime, 4).Value = ReturnedDt
        Try
            oDa.Fill(oDs)
            ReturnedStoresDetails = oDs.Tables(0).Copy
        Catch exp As Exception
            ReturnedStoresDetails = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetLadleNo() As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "select LadleNo from ms_vw_LadleNo  " & _
            " order by Ladle "
        Try
            oDa.Fill(oDs)
            GetLadleNo = oDs.Tables(0).Copy
        Catch exp As Exception
            GetLadleNo = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetLiningNos() As DataSet
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "select distinct LiningNo from ms_FurnaceLining where LT = 1 order by LiningNo desc ; " & _
            " select distinct LiningNo from ms_FurnaceLining where LT = 3 order by LiningNo desc ; "
        Try
            oDa.Fill(oDs)
            GetLiningNos = oDs.Copy
        Catch exp As Exception
            GetLiningNos = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetLiningPOs(ByVal LT As Int16) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        If LT = 1 OrElse LT = 2 Then
            oDa.SelectCommand.CommandText = " select distinct a.PLNumber + '--' + PODBRNo + '--' + rtrim(short_description) PLNumber , PODBRNo  " & _
                " from ms_FurnaceLiningPLs a inner join ms_vw_LiningPLsForPO b on a.PLNumber = b.PLNumber" & _
                " inner join pm_item_master c on  a.PLNumber = c.PL_Number " & _
                " and a.PLNumber in ( '84983486' , '84018768' , '84027125' ) " & _
                " where LT in ( 1 , 2) and len(PODBRNo) = 9 order by PLNumber desc  "
        ElseIf LT = 3 Then
            oDa.SelectCommand.CommandText = " select distinct a.PLNumber + '--' + PODBRNo + '--' + rtrim(short_description)  PLNumber , PODBRNo " & _
                " from ms_FurnaceLiningPLs a inner join ms_vw_LiningPLsForPO b on a.PLNumber = b.PLNumber" & _
                " inner join pm_item_master c on  a.PLNumber = c.PL_Number " & _
                " and a.PLNumber in ( '84018756','84029584','84983450' ) " & _
                " where LT = @LT order by PLNumber desc  "
        ElseIf LT = 4 Then
            oDa.SelectCommand.CommandText = " select distinct a.PLNumber + '--' + PODBRNo + '--' + rtrim(short_description) PLNumber , PODBRNo " & _
                " from ms_FurnaceLiningPLs a inner join ms_vw_LiningPLsForPO b on a.PLNumber = b.PLNumber" & _
                " inner join pm_item_master c on  a.PLNumber = c.PL_Number " & _
                " where LT = @LT order by PLNumber desc  "
        End If
        oDa.SelectCommand.Parameters.Add("@LT", SqlDbType.Int, 4).Value = LT
        Try
            oDa.Fill(oDs)
            GetLiningPOs = oDs.Tables(0).Copy
        Catch exp As Exception
            GetLiningPOs = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function CheckFurnacePODetailsData(ByVal LT As Integer, ByVal PONumber As String) As Boolean
        Dim Done As Boolean = False
        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        oCmd.Parameters.Add("@LT", SqlDbType.Int, 4).Value = LT
        oCmd.Parameters.Add("@PONumber", SqlDbType.VarChar, 50).Value = PONumber
        oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
        oCmd.Connection.Open()
        Try
            oCmd.CommandText = " select @cnt = count(*) from ms_FurnacePO1 a    " & _
                " where a.LT = @LT and  a.PODBRNo =  @PONumber  "
            oCmd.ExecuteScalar()
            Return IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)
        Catch exp As Exception
            Throw New Exception("InValid From Heat !" & exp.Message)
        End Try
    End Function
    Public Shared Function FurnacePODetailsData(ByVal LT As Integer, ByVal PONumber As String) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "ms_sp_FurnacePODetailsData"
        oDa.SelectCommand.CommandType = CommandType.StoredProcedure
        oDa.SelectCommand.Parameters.Add("@LT", SqlDbType.Int, 4).Value = LT
        oDa.SelectCommand.Parameters.Add("@PONumber", SqlDbType.VarChar, 50).Value = PONumber
        Try
            oDa.Fill(oDs)
            FurnacePODetailsData = oDs.Tables(0).Copy
        Catch exp As Exception
            FurnacePODetailsData = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetLiningType(Optional ByVal Type As Boolean = False) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        If Type Then
            oDa.SelectCommand.CommandText = "select distinct LT , LiningType from ms_vw_LiningType where LT in ( 3 , 4 ) order by LT  "
        Else
            oDa.SelectCommand.CommandText = "select distinct LT , LiningType from ms_vw_LiningType order by LT  "
        End If
        Try
            oDa.Fill(oDs)
            GetLiningType = oDs.Tables(0).Copy
        Catch exp As Exception
            GetLiningType = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetLiningBy() As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "select distinct LB , LinedBy from ms_vw_LinedBy order by LB  "
        Try
            oDa.Fill(oDs)
            GetLiningBy = oDs.Tables(0).Copy
        Catch exp As Exception
            GetLiningBy = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetRefCondemned() As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "select Sl , RefCondemned from ms_vw_RefCondemned order by Sl  "
        Try
            oDa.Fill(oDs)
            GetRefCondemned = oDs.Tables(0).Copy
        Catch exp As Exception
            GetRefCondemned = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetScrapType(ByVal ScrapType As String) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "select SlNo , ScrapName  from ms_vw_ScrapList " & _
            " where ScrapType = @ScrapType and SlNo not in ( 5,6 ) order by SlNo "
        Try
            oDa.SelectCommand.Parameters.Add("@ScrapType", SqlDbType.VarChar, 20).Value = ScrapType
            oDa.Fill(oDs)
            GetScrapType = oDs.Tables(0).Copy
        Catch exp As Exception
            GetScrapType = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetProdConsumableDetails(ByVal Number As String, ByVal Consignee As String, ByVal TypeID As Integer) As DataSet
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim Message As String
        oDa.SelectCommand.CommandText = "ms_sp_GetProdConsumableDetails"
        oDa.SelectCommand.CommandType = CommandType.StoredProcedure
        oDa.SelectCommand.Parameters.Add("@Number", SqlDbType.VarChar, 50).Value = Number.Trim
        oDa.SelectCommand.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = Consignee.Trim
        oDa.SelectCommand.Parameters.Add("@TypeID", SqlDbType.Int, 4).Value = TypeID
        oDa.SelectCommand.Parameters.Add("@Message", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output
        Try
            oDa.Fill(oDs)
            GetProdConsumableDetails = oDs.Copy
            If oDa.SelectCommand.Parameters("@Message").Value.GetType.ToString.StartsWith("InValid").ToString Then
                Throw New Exception(oDa.SelectCommand.Parameters("@Message").Value.GetType.ToString)
            End If
        Catch exp As Exception
            GetProdConsumableDetails = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetConsumablePLCB(ByVal Consignee As String, ByVal PLNo As String) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = " select top 1 PLNO , CBasOn , CBQty , Remarks " & _
            " from ms_ProdConsumables a left outer join ms_ProdConsumableCB b " & _
            " on a.PLId = b.PLId inner join pm_ItemMaster c " & _
            " on a.PLNO = c.PL_number " & _
            " where a.Consignee = @Consignee " & _
            " and PLNO = @PLNo " & _
            " order by CBasOn desc "
        oDa.SelectCommand.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = Consignee
        oDa.SelectCommand.Parameters.Add("@PLNo", SqlDbType.VarChar, 9).Value = PLNo
        Try
            oDa.Fill(oDs)
            GetConsumablePLCB = oDs.Tables(0).Copy
        Catch exp As Exception
            GetConsumablePLCB = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetPLCB(ByVal Consignee As String, ByVal CBasOn As Date, ByVal PLNo As String, ByVal CB As Double) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "ms_sp_ProdConsumablePLCB"
        oDa.SelectCommand.CommandType = CommandType.StoredProcedure
        oDa.SelectCommand.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = Consignee
        oDa.SelectCommand.Parameters.Add("@CBasOn", SqlDbType.SmallDateTime, 4).Value = CBasOn
        oDa.SelectCommand.Parameters.Add("@PLNo", SqlDbType.VarChar, 8).Value = PLNo
        oDa.SelectCommand.Parameters.Add("@CB", SqlDbType.Float, 8).Value = CB
        Try
            oDa.Fill(oDs)
            GetPLCB = oDs.Tables(0).Copy
        Catch exp As Exception
            GetPLCB = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetConsumablePLsCB(ByVal Consignee As String, ByVal CBasOn As Date) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = " select a.PLNO , CBasOn , CBQty , Remarks " & _
            " from ms_ProdConsumables a left outer join ms_ProdConsumableCB b " & _
            " on a.PLId = b.PLId inner join pm_ItemMaster c " & _
            " on a.PLNO = c.PL_number left outer join ms_vw_ProdConsumables d on d.PLNO = a.PLNO" & _
            " where a.Consignee = @Consignee " & _
            " and month(CBasOn) = month(@CBasOn) and year(CBasOn) = year(@CBasOn) " & _
            " order by d.ward , a.PLNO "
        oDa.SelectCommand.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = Consignee
        oDa.SelectCommand.Parameters.Add("@CBasOn", SqlDbType.SmallDateTime, 4).Value = CBasOn
        Try
            oDa.Fill(oDs)
            GetConsumablePLsCB = oDs.Tables(0).Copy
        Catch exp As Exception
            GetConsumablePLsCB = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetTransDateDetails(ByVal Consignee As String, ByVal TransDate As Date) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        If Consignee = "PTMS" Then
            oDa.SelectCommand.CommandText = "select PLNo , Type , " & _
                " CONVERT(VARCHAR(10),TransDate,103) TransDate , TransNumber ,  TransQty , Supplier, Remarks " & _
                " from ms_ProdConsumables a inner join ms_ProdConsumableDetails b " & _
                " on a.plid = b.plid " & _
                " inner join ms_ProdConsumableType c on c.TypeID = b.TypeID  " & _
                " where TransDate = @TransDate "
        Else
            oDa.SelectCommand.CommandText = "select PLNumber , Type , " & _
                " CONVERT(VARCHAR(10),TransDate,103) TransDate , TransNumber ,  TransQty , Supplier, b.Remarks " & _
                " from ms_ProdConsumableList a inner join ms_POMOConsumableDetails b " & _
                " on a.plid = b.plid " & _
                " inner join ms_ProdConsumableType c on c.TypeID = b.TypeID  " & _
                " where TransDate = @TransDate "
        End If
        oDa.SelectCommand.Parameters.Add("@TransDate", SqlDbType.SmallDateTime, 4).Value = TransDate
        Try
            oDa.Fill(oDs)
            GetTransDateDetails = oDs.Tables(0).Copy
        Catch exp As Exception
            GetTransDateDetails = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetCBPLDetails(ByVal PLNumber As String, ByVal AsOn As Date) As DataSet
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "select convert(varchar(10),TransDate,103) TranDate , c.Type ,  " & _
            " TransNumber , TransQty , b.Remarks , Supplier from ms_ProdConsumableList a " & _
            " inner join ms_POMOConsumableDetails b on a.PLId = b.PLId" & _
            " and Consignee = 'POMO' inner join ms_ProdConsumableType c " & _
            " on c.TypeID = b.TypeID inner join pm_ItemMaster d on PLNumber = PL_Number" & _
            " where PLNumber = @PLNumber and convert(varchar(6),TransDate,112) = convert(varchar(6),@AsOn,112) " & _
            " order by TransDate , TransNumber ; " & _
            " select CBQty , a.Remarks " & _
            " from ms_POMOConsumableCB  a inner join ms_ProdConsumableList b" & _
            " on a.PLId = b.PLId where CBasOn = @AsOn and PLNumber = @PLNumber ; " & _
            " select PLNumber , CBQty , a.Remarks " & _
            " from ms_POMOConsumableCB  a inner join ms_ProdConsumableList b" & _
            " on a.PLId = b.PLId where CBasOn = @AsOn and PLNumber = @PLNumber "
        oDa.SelectCommand.Parameters.Add("@PLNumber", SqlDbType.VarChar, 10).Value = PLNumber
        oDa.SelectCommand.Parameters.Add("@AsOn", SqlDbType.SmallDateTime, 4).Value = AsOn
        Try
            oDa.Fill(oDs)
            GetCBPLDetails = oDs.Copy
        Catch exp As Exception
            GetCBPLDetails = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetWODetails(ByVal WONo As String, ByVal WODate As Date) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "select TransQty ,  Remarks , TransID" & _
            " from ms_POMOConsumableDetails" & _
            " where TypeID = 7 and month(TransDate) = month(@WODate) " & _
            " and year(TransDate) = year(@WODate) and TransNumber = @WONo ;"
        oDa.SelectCommand.Parameters.Add("@WONo", SqlDbType.VarChar, 10).Value = WONo
        oDa.SelectCommand.Parameters.Add("@WODate", SqlDbType.SmallDateTime, 4).Value = WODate
        Try
            oDa.Fill(oDs)
            GetWODetails = oDs.Tables(0).Copy
        Catch exp As Exception
            GetWODetails = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetWOList(ByVal WODate As Date) As DataSet
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "Select number from mm_workorder " & _
            " where product_code like '[1,2]%' and " & _
            " @WODate between start_date  and end_date and shop_code = 'e1' " & _
            " order by number ; " & _
            " select a.WO , WOType , WOQty , TransQty ProdQty ,  Remarks from ( " & _
            " Select number WO , description WOType , workorder_quantity WOQty " & _
            " from mm_workorder " & _
            " where product_code like '[1,2]%' and " & _
            " @WODate between start_date  and end_date and shop_code = 'e1' " & _
            " ) a left outer join ( " & _
            " select TransNumber WO , TransQty ,  Remarks " & _
            " from ms_POMOConsumableDetails" & _
            " where TypeID = 7 and month(TransDate) = month(@WODate) " & _
            " and year(TransDate) = year(@WODate) ) b  " & _
            " on a.WO = b.WO "
        oDa.SelectCommand.Parameters.Add("@WODate", SqlDbType.SmallDateTime, 4).Value = WODate
        Try
            oDa.Fill(oDs)
            GetWOList = oDs.Copy
        Catch exp As Exception
            GetWOList = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetCBPLList() As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "select distinct PLNumber , rtrim(short_description) PLDescr" & _
            " from ms_ProdConsumableList a " & _
            " inner join ms_POMOConsumableDetails b on a.PLId = b.PLId" & _
            " and Consignee = 'POMO' inner join ms_ProdConsumableType c " & _
            " on c.TypeID = b.TypeID inner join pm_ItemMaster d on PLNumber = PL_Number" & _
            " order by PLNumber "
        Try
            oDa.Fill(oDs)
            GetCBPLList = oDs.Tables(0).Copy
        Catch exp As Exception
            GetCBPLList = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetPOMOPLs() As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "select distinct PLNumber , PLDescription " & _
           " from ms_vw_POMOConsumableDetails order by PLNumber "
        Try
            oDa.Fill(oDs)
            GetPOMOPLs = oDs.Tables(0).Copy
        Catch exp As Exception
            GetPOMOPLs = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetScrapName(ByVal PLNo As String) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "select ScrapName from ms_vw_ScrapList" & _
            " where pl_number = @PLNo order by ScrapName"
        oDa.SelectCommand.Parameters.Add("@PLNo", SqlDbType.VarChar, 9).Value = PLNo
        Try
            oDa.Fill(oDs)
            GetScrapName = oDs.Tables(0).Copy
        Catch exp As Exception
            GetScrapName = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetPLType() As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "select Type , TypeID  from ms_ProdConsumableType " & _
            " where TypeID in ( 1 , 2 , 6 , 7 )  order by TypeID"
        Try
            oDa.Fill(oDs)
            GetPLType = oDs.Tables(0).Copy
        Catch exp As Exception
            GetPLType = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetConsumablePLsDetails(ByVal Consignee As String, ByVal PLNO As String) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "select * from ms_ProdConsumables " & _
                " where PLNO = @PLNO  " 'and Consignee = @Consignee
        oDa.SelectCommand.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = Consignee
        oDa.SelectCommand.Parameters.Add("@PLNO", SqlDbType.VarChar, 8).Value = PLNO
        Try
            oDa.Fill(oDs)
            GetConsumablePLsDetails = oDs.Tables(0).Copy
        Catch exp As Exception
            GetConsumablePLsDetails = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetConsumablePLs(ByVal Consignee As String) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "select a.PLNO , short_description , a.Advised , a.PerUnit , " & _
            " ShelfLife , LifeUnit from ms_ProdConsumables a inner join pm_ItemMaster b" & _
            " on a.PLNO = pl_number left outer join ms_vw_ProdConsumables d on d.PLNO = a.PLNO order by d.ward , pl_number "
        oDa.SelectCommand.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = Consignee
        Try
            oDa.Fill(oDs)
            GetConsumablePLs = oDs.Tables(0).Copy
        Catch exp As Exception
            GetConsumablePLs = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetRMRMonth() As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = " select distinct  month(rmr_date) m ,  DATENAME(month, rmr_date) vv " & _
                " from mm_rmr a left outer join  mm_RMRConsumption b       " & _
                " on number = RMRNumber left outer join mm_bill_of_material c " & _
                " on a.pl_number = c.pl_number  " & _
                " where consignee_code = 'pomo' " & _
                " and RMRConsumptionDate >= rmr_date" & _
                " order by month(rmr_date) "
        Try
            oDa.Fill(oDs)
            GetRMRMonth = oDs.Tables(0).Copy
        Catch exp As Exception
            GetRMRMonth = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetRMRYear() As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = " select distinct top 5 year(rmr_date) v" & _
                " from mm_rmr a left outer join  mm_RMRConsumption b       " & _
                " on number = RMRNumber left outer join mm_bill_of_material c " & _
                " on a.pl_number = c.pl_number  " & _
                " where consignee_code = 'pomo' " & _
                " order by year(rmr_date) desc" '" and RMRConsumptionDate >= rmr_date" & _
        Try
            oDa.Fill(oDs)
            GetRMRYear = oDs.Tables(0).Copy
        Catch exp As Exception
            GetRMRYear = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function RMRConsumptionStatement(ByVal Consignee As String, ByVal Month As Integer, ByVal WOYear As Integer) As DataTable
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
        End Try
    End Function
    Public Shared Function StockNonStockItems(ByVal Item As String) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        If Item = "NonStockItems" Then
            oDa.SelectCommand.CommandText = "select pl_number PLNumber , UnitName , " & _
                " short_description ShortDescription , long_description LongDescription , " & _
                " last_po_number LastPODBR, TradeGroupName " & _
                " from pm_ItemMaster where consignee = 'pomo'" & _
                " order by pl_number"
        Else
            oDa.SelectCommand.CommandText = "select * from ms_vw_POMOStockItemList " & _
                " where PLNumber = NewPLNumber order by PLNumber"
        End If
        Try
            oDa.Fill(oDs)
            StockNonStockItems = oDs.Tables(0).Copy
        Catch exp As Exception
            StockNonStockItems = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function RMRConsumptionNewStatement(ByVal ConsumDate As Date) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "mm_sp_PLConsumption"
        oDa.SelectCommand.CommandType = CommandType.StoredProcedure
        oDa.SelectCommand.Parameters.Add("@ConsumDate", SqlDbType.SmallDateTime, 4).Value = ConsumDate
        Try
            oDa.Fill(oDs)
            RMRConsumptionNewStatement = oDs.Tables(0).Copy
        Catch exp As Exception
            RMRConsumptionNewStatement = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function RMRUnUsed(ByVal Consignee As String, ByVal Month As Integer, ByVal WOYear As Integer, ByVal PLNumber As String) As DataTable
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
        End Try
    End Function
    Public Shared Function RMRConsumptionEntry(ByVal Consignee As String, ByVal Month As Integer, ByVal WOYear As Integer, ByVal PLNumber As String) As DataTable
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
        End Try
    End Function
    Public Shared Function S1313Consumption(ByVal Consignee As String, ByVal ConsMonth As Date, ByVal PLNumber As String) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "ms_sp_S1313Qry"
        oDa.SelectCommand.CommandType = CommandType.StoredProcedure
        oDa.SelectCommand.Parameters.Add("@ConsMonth", SqlDbType.SmallDateTime, 4).Value = ConsMonth
        oDa.SelectCommand.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = Consignee
        oDa.SelectCommand.Parameters.Add("@PL_Number", SqlDbType.VarChar, 10).Value = PLNumber
        Try
            oDa.Fill(oDs)
            S1313Consumption = oDs.Tables(0).Copy
        Catch exp As Exception
            S1313Consumption = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetRMRNumberDetails(ByVal RMR As Long, ByVal PL As String, ByVal WO As String, ByVal Month As Integer, ByVal WOYear As Integer, ByVal Consignee As String) As DataTable
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
        End Try
    End Function
    Public Shared Function GetRMRPLsConsumption(ByVal PL As String, ByVal WO As String, ByVal Month As Integer, ByVal WOYear As Integer, ByVal Consignee As String) As DataTable
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
        End Try
    End Function
    Public Shared Function GetRMRPLsRMRNumber(ByVal PL As String, ByVal WO As String, ByVal Month As Integer, ByVal WOYear As Integer, ByVal Consignee As String) As DataTable
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
        End Try
    End Function
    Public Shared Function RMRPLs(ByVal Consignee As String, ByVal Month As Integer, ByVal WOYear As Integer) As DataTable
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
        End Try
    End Function
    Public Shared Function S1313PLs(ByVal Consignee As String, ByVal ConsMonth As Date) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "select distinct rtrim(a.PL_Number) PLNumber , " & _
            " rtrim(short_description) PLDescr  " & _
            " from dm_issue_requisition a inner join pm_ItemMaster b" & _
            " on a.PL_Number = b.PL_Number  " & _
            " where a.consignee = 'pomo'" & _
            " and convert(varchar(6),ir_date,112) =  convert(varchar(6),@ConsMonth,112)" & _
            " order by rtrim(a.PL_Number) , rtrim(short_description)"
        oDa.SelectCommand.Parameters.Add("@ConsMonth", SqlDbType.SmallDateTime, 4).Value = ConsMonth
        oDa.SelectCommand.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = Consignee
        Try
            oDa.Fill(oDs)
            S1313PLs = oDs.Tables(0).Copy
        Catch exp As Exception
            S1313PLs = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
        End Try
    End Function
    Public Shared Function GetRMRWOPLs(ByVal Consignee As String, ByVal WO As String, ByVal Month As Integer, ByVal WOYear As Integer) As DataTable
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
        End Try
    End Function
    Public Shared Function GetRMRMonthYearWO(ByVal Month As Integer, ByVal WOYear As Integer) As DataTable
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
        End Try
    End Function
    Public Shared Function GetConsignee(ByVal Group As String, ByVal UserId As String) As String
        Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()

        da.SelectCommand.CommandText = " select description from ms_group_location where purpose = 'Sub-Stores' " &
                " and group_code = (select group_code from wap.dbo.menu_your_password_new " &
                " where employee_code = @UserId and application = 'MSS'	and group_code = @Group ) "
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
        End Try
    End Function
    Public Shared Function GetYearMonth(ByVal Type As Integer) As DataTable
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
            End If
        End Try
        Return Done
    End Function
    Public Function UpdateBreakDown(ByVal memono As Integer, ByVal memoslipno As String, ByVal Loss As Integer, ByVal SlipNo As String, ByVal Aff As Boolean) As Boolean
        Dim Done As Boolean = False
        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            oCmd.Parameters.Add("@memono", SqlDbType.Int, 4).Value = memono
            oCmd.Parameters.Add("@memoslipno", SqlDbType.VarChar, 50).Value = memoslipno
            oCmd.Parameters.Add("@Loss", SqlDbType.Int, 4).Value = Loss
            oCmd.Parameters.Add("@SlipNo", SqlDbType.VarChar, 50).Value = SlipNo
            oCmd.Parameters.Add("@production_affected", SqlDbType.Int, 4).Value = Aff
            Try
                oCmd.Connection.Open()
                oCmd.CommandText = " update ms_breakdown_memo " & _
                    " set  memo_slip_number = @memoslipno , time_loss = @Loss , production_affected = @production_affected " & _
                    " where maintenance_group = 'whlmlt' and memo_number = @memono and memo_slip_number = @SlipNo "
                If oCmd.ExecuteNonQuery = 1 Then Done = True
            Catch exp As Exception
                Throw New Exception(" ms_breakdown_memo Updation failed !" & exp.Message)
            End Try
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            If Not IsNothing(oCmd) Then
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End If
        End Try
        Return Done
    End Function
    Public Function UpdateOffheatRemarks(ByVal heat_number As Double, ByVal Remarks As String) As Boolean
        Dim Done As Boolean = False
        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            oCmd.Parameters.Add("@heat_number", SqlDbType.BigInt, 4).Value = heat_number
            oCmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 5000).Value = Remarks
            Try
                oCmd.Connection.Open()
                oCmd.CommandText = " update mm_offheat_post_melt " & _
                    " set  hea_rem = @Remarks  " & _
                    " where heat_number = @heat_number "
                If oCmd.ExecuteNonQuery = 1 Then Done = True
            Catch exp As Exception
                Throw New Exception(" mm_offheat_post_melt Updation failed !" & exp.Message)
            End Try
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            If Not IsNothing(oCmd) Then
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End If
        End Try
        Return Done
    End Function
    Public Function SavePLDetails(ByVal Consignee As String, ByVal PLNO As String, ByVal Advised As Decimal, ByVal PerUnit As String, ByVal PerDay As Decimal, ByVal ShelfLife As Decimal, ByVal LifeUnit As String) As Boolean
        Dim Done As Boolean = False
        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            oCmd.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = Consignee
            oCmd.Parameters.Add("@PLNO", SqlDbType.VarChar, 8).Value = PLNO
            oCmd.Parameters.Add("@Advised", SqlDbType.Decimal, 18, 8).Value = Advised
            oCmd.Parameters.Add("@PerDay", SqlDbType.Decimal, 18, 8).Value = PerDay
            oCmd.Parameters.Add("@PerUnit", SqlDbType.VarChar, 50).Value = PerUnit
            oCmd.Parameters.Add("@ShelfLife", SqlDbType.Decimal, 18, 2).Value = ShelfLife
            oCmd.Parameters.Add("@LifeUnit", SqlDbType.VarChar, 50).Value = LifeUnit
            oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            oCmd.CommandText = " select @cnt = count(*) from ms_ProdConsumables where PLNO = @PLNO "
            Try
                oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                oCmd.ExecuteScalar()
                If IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value) = 0 Then
                    oCmd.CommandText = " insert into ms_ProdConsumables ( Consignee , PLNO , Advised , PerUnit , PerDay , ShelfLife , LifeUnit ) " & _
                        " values ( @Consignee , @PLNO , @Advised , @PerUnit , @PerDay , @ShelfLife , @LifeUnit ) "
                Else
                    oCmd.CommandText = " update ms_ProdConsumables " & _
                        " set  Consignee = @Consignee , Advised = @Advised , PerUnit = @PerUnit , PerDay = @PerDay , " & _
                        " ShelfLife = @ShelfLife , LifeUnit = @LifeUnit where PLNO =  @PLNO "
                End If
                If oCmd.ExecuteNonQuery = 1 Then Done = True
            Catch exp As Exception
                Throw New Exception(" Production Consumable Advise Norms Updation failed !" & exp.Message)
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
    End Function
    Public Function SavePLCB(ByVal Consignee As String, ByVal PLNO As String, ByVal CBasOn As Date, ByVal CBQty As Double, ByVal Remarks As String, ByVal Cum As Boolean) As Boolean
        Dim Done As Boolean = False
        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            oCmd.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = Consignee
            oCmd.Parameters.Add("@PLNO", SqlDbType.VarChar, 8).Value = PLNO
            oCmd.Parameters.Add("@CBasOn", SqlDbType.SmallDateTime, 4).Value = CBasOn
            oCmd.Parameters.Add("@CBQty", SqlDbType.Float, 9).Value = CBQty
            oCmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = Remarks
            oCmd.Parameters.Add("@PLId", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            oCmd.Connection.Open()
            Try
                If Consignee = "PTMS" Then
                    oCmd.CommandText = " select @PLId = PLId from ms_ProdConsumables where Consignee = @Consignee and PLNO = @PLNO "
                Else
                    oCmd.CommandText = " select @PLId = PLId from ms_ProdConsumableList where Consignee = @Consignee and PLNumber = @PLNO "
                End If
                oCmd.ExecuteScalar()
                oCmd.Parameters("@PLId").Direction = ParameterDirection.Input
                If Consignee = "PTMS" Then
                    oCmd.CommandText = " select @cnt = count(*) from ms_ProdConsumableCB where PLId = @PLId " & _
                        " and month(CBasOn) = month(@CBasOn) and year(CBasOn) = year(@CBasOn) "
                    oCmd.ExecuteScalar()
                    If IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value) = 0 Then
                        oCmd.CommandText = " insert into ms_ProdConsumableCB ( PLid , CBasOn , CBQty , Remarks ) " & _
                            " values ( @PLid , @CBasOn , @CBQty , @Remarks ) "
                    Else
                        oCmd.CommandText = " update ms_ProdConsumableCB " & _
                            " set  CBasOn = @CBasOn , CBQty = @CBQty , Remarks = @Remarks  " & _
                            " where PLid =  @PLid and month(CBasOn) = month(@CBasOn) and year(CBasOn) = year(@CBasOn) "
                    End If
                    If oCmd.ExecuteNonQuery = 1 Then
                        If Cum Then
                            Done = SaveCummulative(CBasOn, PLNO)
                        Else
                            Done = True
                        End If
                    End If
                Else
                    oCmd.CommandText = " select @cnt = count(*) from ms_POMOConsumableCB where PLId = @PLId " & _
                        " and month(CBasOn) = month(@CBasOn) and year(CBasOn) = year(@CBasOn) "
                    oCmd.ExecuteScalar()
                    If IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value) = 0 Then
                        oCmd.CommandText = " insert into ms_POMOConsumableCB ( PLid , CBasOn , CBQty , Remarks ) " & _
                            " values ( @PLid , @CBasOn , @CBQty , @Remarks ) "
                    Else
                        oCmd.CommandText = " update ms_POMOConsumableCB " & _
                            " set  CBasOn = @CBasOn , CBQty = @CBQty , Remarks = @Remarks  " & _
                            " where PLid =  @PLid and month(CBasOn) = month(@CBasOn) and year(CBasOn) = year(@CBasOn) "
                    End If
                    If oCmd.ExecuteNonQuery = 1 Then Done = True
                End If
            Catch exp As Exception
                Throw New Exception("Production Consumable CB Updation failed !" & exp.Message)
            End Try
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            If Not IsNothing(oCmd) Then
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End If
        End Try
        Return Done
    End Function
    Public Function SaveCummulative(ByVal CBasOn As Date, ByVal PLNO As String) As Boolean
        Dim Done As Boolean
        Dim oCmd1 As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        oCmd1.Parameters.Add("@CBDate", SqlDbType.SmallDateTime, 4).Value = CBasOn
        oCmd1.Parameters.Add("@PLNO", SqlDbType.VarChar, 8).Value = PLNO

        oCmd1.Parameters.Add("@FrDt", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output
        oCmd1.Parameters.Add("@StartDate", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output
        oCmd1.Parameters.Add("@FinYear", SqlDbType.VarChar, 7).Direction = ParameterDirection.Output
        oCmd1.Parameters.Add("@CumHeats", SqlDbType.Float, 9).Direction = ParameterDirection.Output
        oCmd1.Parameters.Add("@CumMetal", SqlDbType.Float, 9).Direction = ParameterDirection.Output
        oCmd1.Parameters.Add("@Heats", SqlDbType.Float, 9).Direction = ParameterDirection.Output
        oCmd1.Parameters.Add("@Metal", SqlDbType.Float, 9).Direction = ParameterDirection.Output
        oCmd1.Parameters.Add("@CumConMetal", SqlDbType.Float, 9).Direction = ParameterDirection.Output
        oCmd1.Parameters.Add("@CumConMT", SqlDbType.Float, 9).Direction = ParameterDirection.Output
        oCmd1.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
        oCmd1.Parameters.Add("@con", SqlDbType.Float, 9).Direction = ParameterDirection.Output

        oCmd1.CommandText = " select @FrDt = wap.dbo.mm_fn_si_GetFinYearDate(@CBDate,1) ;" & _
            " select @StartDate = dateadd(d,1-day(@CBDate),@CBDate); " & _
            " select @FinYear = wap.dbo.mm_fn_si_GetFinYear(@CBDate) ; "
        oCmd1.Connection.Open()
        Try
            oCmd1.Transaction = oCmd1.Connection.BeginTransaction
            oCmd1.ExecuteScalar()
            oCmd1.Parameters("@FrDt").Direction = ParameterDirection.Input
            oCmd1.Parameters("@StartDate").Direction = ParameterDirection.Input
            oCmd1.Parameters("@FinYear").Direction = ParameterDirection.Input
            oCmd1.CommandText = " select @CumMetal = sum( skull + riser_hub + cut_scrap + hbi + pygmy_pot + " & _
                " wheel_cut + lms + slpr_cut + hot_heal + axle_cut + tuning_boring + " & _
                " wheel + axle_end + shredded_scrap + Rail_cut ) , @CumHeats = count(*) " & _
                " from mm_vw_HeatTapped a inner join mm_heat_sheet_charge b  " & _
                " on a.heat_number = b.heat_number inner join mm_post_melt c " & _
                " on a.heat_number = c.heat_number inner join mm_heatsheet_header d " & _
                " on a.heat_number = d.heat_number " & _
                " where TappedDate between @FrDt and @CBDate ;"
            oCmd1.ExecuteScalar()
            oCmd1.Parameters("@CumHeats").Direction = ParameterDirection.Input
            oCmd1.Parameters("@CumMetal").Direction = ParameterDirection.Input

            oCmd1.CommandText = " select @Metal = sum( skull + riser_hub + cut_scrap + hbi + pygmy_pot + " & _
                " wheel_cut + lms + slpr_cut + hot_heal + axle_cut + tuning_boring + " & _
                " wheel + axle_end + shredded_scrap + Rail_cut ) , @Heats = count(*) " & _
                " from mm_vw_HeatTapped a inner join mm_heat_sheet_charge b " & _
                " on a.heat_number = b.heat_number inner join mm_post_melt c " & _
                " on a.heat_number = c.heat_number inner join mm_heatsheet_header d " & _
                " on a.heat_number = d.heat_number " & _
                " where TappedDate between @StartDate and @CBDate  ;"
            oCmd1.ExecuteScalar()
            oCmd1.Parameters("@Heats").Direction = ParameterDirection.Input
            oCmd1.Parameters("@Metal").Direction = ParameterDirection.Input

            oCmd1.CommandText = " select @CumConMetal = sum(a.OBQty + isnull(TransQty,0) - b.CBQty)" & _
                " from ms_vw_ProdConsumableCB a   " & _
                " inner join ms_vw_ProdConsumableCB b " & _
                " on b.CBasOn = a.CBasOn and a.PLNo = b.PLNo  " & _
                " left outer join ms_vw_ProdConsumableSummary c " & _
                " on a.PLNo = c.PLNo and convert(varchar(6),a.CBasOn,112) = TransMonth " & _
                " left outer join ms_vw_ProdConsumables d   " & _
                " on d.PLNO = a.PLNO " & _
                " where a.CBasOn between @FrDt and @CBDate  " & _
                " and a.PLNo = @PLNO "
            oCmd1.ExecuteScalar()

            oCmd1.CommandText = " select @CumConMT = sum(a.OBQty + isnull(TransQty,0) - b.CBQty)/@CumMetal " & _
               " from ms_vw_ProdConsumableCB a  " & _
               " inner join ms_vw_ProdConsumableCB b " & _
               " on b.CBasOn = a.CBasOn and a.PLNo = b.PLNo " & _
               " left outer join ms_vw_ProdConsumableSummary c " & _
               " on a.PLNo = c.PLNo and convert(varchar(6),a.CBasOn,112) = TransMonth " & _
               " left outer join ms_vw_ProdConsumables d " & _
               " on d.PLNO = a.PLNO " & _
               " where a.CBasOn between @FrDt and @CBDate and a.PLNo = @PLNO " & _
               " and a.PLNo = @PLNO " & _
               " group by a.PLNo ; "
            oCmd1.ExecuteScalar()

            oCmd1.Parameters("@CumConMetal").Direction = ParameterDirection.Input
            oCmd1.Parameters("@CumConMT").Direction = ParameterDirection.Input

            oCmd1.CommandText = " select @cnt = count(*) from ms_Prod " & _
                 " where plno = @PLNO and MonthYear = ' CumCon'  and FinYear = @FinYear and SlNa = 'a' "

            If IIf(IsDBNull(oCmd1.Parameters("@cnt").Value), 0, oCmd1.Parameters("@cnt").Value) = 0 Then
                oCmd1.CommandText = " insert into ms_Prod ( SlNo , SlNa , ward , PLNO , PLDescription , Unit , MonthYear , Con , FinYear )" & _
                    " select WardSl , 'a' SlNa , d.ward , d.PLNO  , PLDescription  , Unit , " & _
                    " space(1)+'CumCon' MonthYear , @CumConMetal  , wap.dbo.mm_fn_si_GetFinYear(@FrDt) " & _
                    " from ms_vw_ProdConsumableCB a " & _
                    " inner join ms_vw_ProdConsumables d " & _
                    " on d.PLNO = a.PLNO " & _
                    " where a.CBasOn between @StartDate and @CBDate " & _
                    " and a.PLNo = @PLNO "
            Else
                oCmd1.CommandText = " update ms_Prod " & _
                    " set Con = @CumConMetal " & _
                    " where plno = @PLNO and MonthYear = ' CumCon'  and FinYear = @FinYear and SlNa = 'a' "
            End If
            If oCmd1.ExecuteNonQuery() = 1 Then
                oCmd1.CommandText = " select @cnt = count(*) from ms_Prod " & _
                            " where plno = @PLNO and MonthYear = ' CumCon'  and FinYear = @FinYear and SlNa = 'b' "
                If IIf(IsDBNull(oCmd1.Parameters("@cnt").Value), 0, oCmd1.Parameters("@cnt").Value) = 0 Then
                    oCmd1.CommandText = " insert into ms_Prod ( SlNo , SlNa , ward , PLNO , PLDescription , Unit , MonthYear , Con , FinYear )" & _
                        " select WardSl , 'b' SlNa , d.ward , d.PLNO  , " & _
                        " 'zAdvised Norms : '+convert(varchar,convert(decimal(18,6),Advised))+' Per'+PerUnit PLDescription  , Unit , " & _
                        " space(1)+'CumCon' MonthYear , @CumConMT  , wap.dbo.mm_fn_si_GetFinYear(@FrDt) " & _
                        " from ms_vw_ProdConsumableCB a  " & _
                        " inner join ms_vw_ProdConsumables d" & _
                        " on d.PLNO = a.PLNO " & _
                        " where a.CBasOn between @StartDate and @CBDate " & _
                        " and a.PLNo = @PLNO " & _
                        " order by d.ward , d.PLNO "
                Else
                    oCmd1.CommandText = " update ms_Prod " & _
                        " set Con = @CumConMT " & _
                        " where plno = @PLNO and MonthYear = ' CumCon'  and FinYear = @FinYear and SlNa = 'b' "
                End If
                If oCmd1.ExecuteNonQuery() = 1 Then
                    oCmd1.CommandText = " insert into ms_Prod ( SlNo , SlNa , ward , PLNO , PLDescription , Unit , MonthYear , Con , FinYear )" & _
                            " select a.* , MonthYear , b.Con  , wap.dbo.mm_fn_si_GetFinYear(@CBDate)  FinYear " & _
                            " from ( select WardSl , 'a' SlNa , d.ward , d.PLNO  , PLDescription  , Unit " & _
                            " from ms_vw_ProdConsumableCB a " & _
                            " inner join ms_vw_ProdConsumables d " & _
                            " on d.PLNO = a.PLNO " & _
                            " where a.CBasOn between @StartDate and @CBDate  " & _
                            " and a.PLNo = @PLNO ) a inner join (  " & _
                            " select convert(varchar(6),a.CBasOn,112) MonthYear , a.PLNo ," & _
                            " sum(a.OBQty + isnull(TransQty,0) - b.CBQty) Con  " & _
                            " from ms_vw_ProdConsumableCB a  " & _
                            " inner join ms_vw_ProdConsumableCB b   " & _
                            " on b.CBasOn = a.CBasOn and a.PLNo = b.PLNo " & _
                            " left outer join ms_vw_ProdConsumableSummary c " & _
                            " on a.PLNo = c.PLNo and convert(varchar(6),a.CBasOn,112) = TransMonth " & _
                            " left outer join ms_vw_ProdConsumables d " & _
                            " on d.PLNO = a.PLNO " & _
                            " where a.CBasOn between @StartDate and @CBDate  " & _
                            " and a.PLNo = @PLNO   " & _
                            " group by convert(varchar(6),a.CBasOn,112)  , a.PLNo   " & _
                            " ) b on a.PLNO = b.PLNO "
                    If oCmd1.ExecuteNonQuery() = 1 Then
                        oCmd1.CommandText = "  insert into ms_Prod ( SlNo , SlNa , ward , PLNO , PLDescription , Unit , MonthYear , Con , FinYear )  " & _
                            " select a.* , MonthYear , b.Con/@Metal ConMT , wap.dbo.mm_fn_si_GetFinYear(@FrDt) FinYear" & _
                            " from (     select WardSl , 'b' SlNa , d.ward , d.PLNO  ," & _
                            " 'zAdvised Norms : '+convert(varchar,convert(decimal(18,6),Advised))+' Per'+PerUnit PLDescription  , Unit " & _
                            " from ms_vw_ProdConsumableCB a  " & _
                            " inner join ms_vw_ProdConsumables d " & _
                            " on d.PLNO = a.PLNO " & _
                            " where a.CBasOn between @StartDate and @CBDate " & _
                            " and a.PLNo = @PLNO )  a inner join (   " & _
                            " select convert(varchar(6),a.CBasOn,112) MonthYear , a.PLNo , " & _
                            " sum(a.OBQty + isnull(TransQty,0) - b.CBQty) Con " & _
                            " from ms_vw_ProdConsumableCB a " & _
                            " inner join ms_vw_ProdConsumableCB b  " & _
                            " on b.CBasOn = a.CBasOn and a.PLNo = b.PLNo  " & _
                            " left outer join ms_vw_ProdConsumableSummary c " & _
                            " on a.PLNo = c.PLNo and convert(varchar(6),a.CBasOn,112) = TransMonth " & _
                            " left outer join ms_vw_ProdConsumables d  " & _
                            " on d.PLNO = a.PLNO   " & _
                            " where a.CBasOn between @StartDate and @CBDate  " & _
                            " and a.PLNo = @PLNO  " & _
                            " group by convert(varchar(6),a.CBasOn,112)  , a.PLNo  " & _
                            " ) b on a.PLNO = b.PLNO  "
                        If oCmd1.ExecuteNonQuery() = 1 Then
                            oCmd1.CommandText = " select @cnt = count(*) from ms_Prod " & _
                                " where SlNo = '0' and SlNa = 'a' and MonthYear = ' CumCon' and FinYear = @FinYear"
                            oCmd1.ExecuteScalar()
                            If IIf(IsDBNull(oCmd1.Parameters("@cnt").Value), 0, oCmd1.Parameters("@cnt").Value) > 0 Then
                                oCmd1.CommandText = "  update ms_Prod  " & _
                                    " set Con = @CumMetal " & _
                                    " where SlNo = '0' and SlNa = 'a' and MonthYear = ' CumCon' and FinYear = @FinYear "
                            Else
                                oCmd1.CommandText = "  insert into ms_Prod ( SlNo , SlNa , ward , PLNO , PLDescription , Unit , MonthYear , Con , FinYear )    " & _
                                    " select '0' ward , '0' PLNO , '      Description' PLDescription , 'Molten Metal' Unit ,     " & _
                                    " ' CumCon' MonthYear , @CumMetal Con , @FinYear FinYear , '0' SlNo , 'a' SlNa "
                            End If
                            If oCmd1.ExecuteNonQuery() = 1 Then
                                oCmd1.CommandText = " select @cnt = count(*) from ms_Prod " & _
                                                                " where SlNo = '0' and SlNa = 'a' and PLDescription = '      Description' and MonthYear = ' CumCon' and FinYear = @FinYear"
                                oCmd1.ExecuteScalar()
                                If IIf(IsDBNull(oCmd1.Parameters("@cnt").Value), 0, oCmd1.Parameters("@cnt").Value) > 0 Then
                                    oCmd1.CommandText = "  update ms_Prod  " & _
                                        " set Con = @CumHeats " & _
                                        " where SlNo = '0' and SlNa = 'a' and PLDescription = '      Description' and MonthYear = ' CumCon' and FinYear = @FinYear "
                                Else
                                    oCmd1.CommandText = "  insert into ms_Prod ( SlNo , SlNa , ward , PLNO , PLDescription , Unit , MonthYear , Con , FinYear )    " & _
                                        " select '0' ward , '0' PLNO , '      Description' PLDescription , 'Molten Metal' Unit ,     " & _
                                        " ' CumCon' MonthYear , @CumHeats Con , @FinYear FinYear , '0' SlNo , 'a' SlNa "
                                End If
                                If oCmd1.ExecuteNonQuery() = 1 Then
                                    oCmd1.CommandText = " select @cnt = count(*) from ms_Prod     " & _
                                        " where SlNo = '0' and SlNa = 'a' and PLNO = '0' and PLNO = '      Description' and MonthYear = convert(varchar(6),@CBDate,112) and FinYear = @FinYear and Unit = 'Molten Metal' "
                                    oCmd1.ExecuteScalar()
                                    If IIf(IsDBNull(oCmd1.Parameters("@cnt").Value), 0, oCmd1.Parameters("@cnt").Value) > 0 Then
                                        oCmd1.CommandText = "  update ms_Prod " & _
                                            " set Con = @Metal    " & _
                                            " where SlNo = '0' and SlNa = 'a' and PLNO = '0' and MonthYear = convert(varchar(6),@CBDate,112) and FinYear = @FinYear"
                                    Else
                                        oCmd1.CommandText = "  insert into ms_Prod ( SlNo , SlNa , ward , PLNO , PLDescription , Unit , MonthYear , Con , FinYear )    " & _
                                            " select '0' SlNo , 'a' SlNa , '0' ward , '0' PLNO , '      Description' PLDescription , 'Molten Metal' Unit , convert(varchar(6),@CBDate,112) , @Metal Con ,  @FinYear "
                                    End If
                                    If oCmd1.ExecuteNonQuery() = 1 Then
                                        oCmd1.CommandText = " select @cnt = count(*) from ms_Prod     " & _
                                                    " where SlNo = '0' and SlNa = 'b' and PLNO = '0a' and MonthYear = convert(varchar(6),@CBDate,112) and FinYear = @FinYear and Unit = 'Heats' "
                                        oCmd1.ExecuteScalar()
                                        If IIf(IsDBNull(oCmd1.Parameters("@cnt").Value), 0, oCmd1.Parameters("@cnt").Value) > 0 Then
                                            oCmd1.CommandText = "  update ms_Prod " & _
                                                " set Con = @Heats    " & _
                                                " where SlNo = '0' and SlNa = 'b' and PLNO = '0a' and MonthYear = convert(varchar(6),@CBDate,112) and FinYear = @FinYear"
                                        Else
                                            oCmd1.CommandText = "  insert into ms_Prod ( SlNo , SlNa , ward , PLNO , PLDescription , Unit , MonthYear , Con , FinYear )    " & _
                                                " select '0' SlNo , 'b' SlNa , '0' ward , '0a' PLNO , '' PLDescription , 'Heats' Unit , convert(varchar(6),@CBDate,112) , @Heats Con ,  @FinYear "
                                        End If
                                        If oCmd1.ExecuteNonQuery() = 1 Then
                                            Done = True
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        Catch exp As Exception
            Throw New Exception("Yearly Consumable Updation failed !" & exp.Message)
        Finally
            If Done Then
                oCmd1.Transaction.Commit()
            Else
                oCmd1.Transaction.Rollback()
            End If
            If oCmd1.Connection.State = ConnectionState.Open Then oCmd1.Connection.Close()
            oCmd1.Dispose()
            oCmd1 = Nothing
        End Try
        Return Done
    End Function
    Public Function SaveTransDetails(ByVal Consignee As String, ByVal PLNO As String, ByVal TransNumber As String, ByVal TransDate As Date, ByVal TransQty As Double, ByVal Remarks As String, ByVal TypeID As Int16, ByVal Supplier As String, ByVal TransID As Long) As Boolean
        Dim Done As Boolean = False
        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            oCmd.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = Consignee
            oCmd.Parameters.Add("@PLNO", SqlDbType.VarChar, 8).Value = PLNO
            oCmd.Parameters.Add("@TransNumber", SqlDbType.VarChar, 50).Value = TransNumber
            oCmd.Parameters.Add("@TransDate", SqlDbType.SmallDateTime, 4).Value = TransDate
            oCmd.Parameters.Add("@TransQty", SqlDbType.Float, 9).Value = TransQty
            oCmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = Remarks
            oCmd.Parameters.Add("@Supplier", SqlDbType.VarChar, 50).Value = Supplier
            oCmd.Parameters.Add("@TypeID", SqlDbType.Int, 4).Value = TypeID
            oCmd.Parameters.Add("@TransID", SqlDbType.BigInt, 8).Value = TransID

            oCmd.Parameters.Add("@PLId", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            oCmd.CommandText = " select @PLId = PLId from ms_ProdConsumables where Consignee = @Consignee and PLNO = @PLNO "
            Try
                oCmd.Connection.Open()
                oCmd.ExecuteScalar()
                oCmd.Parameters("@PLId").Direction = ParameterDirection.Input
                oCmd.CommandText = " select @cnt = count(*) from ms_ProdConsumableDetails where PLId = @PLId " & _
                    " and TransNumber = @TransNumber and TransID = @TransID "
                oCmd.ExecuteScalar()
                If IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value) = 0 Then
                    oCmd.CommandText = " insert into ms_ProdConsumableDetails ( PLId , TransDate , TransNumber , TransQty , TypeID , Remarks , Supplier ) " & _
                        " values ( @PLId , @TransDate , @TransNumber , @TransQty , @TypeID , @Remarks , @Supplier ) "
                Else
                    oCmd.CommandText = " update ms_ProdConsumableDetails " & _
                        " set  TransDate = @TransDate , TransQty = @TransQty , Remarks = @Remarks  , Supplier = @Supplier " & _
                        " where PLid =  @PLid and TransNumber = @TransNumber and TransID = @TransID "
                End If
                If oCmd.ExecuteNonQuery = 1 Then Done = True
            Catch exp As Exception
                Throw New Exception("Production Consumable Details Updation failed !" & exp.Message)
            End Try
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            If Not IsNothing(oCmd) Then
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End If
        End Try
        Return Done
    End Function
    Public Function SaveScrapDetails(ByVal SlNo As Integer, ByVal ReceiptDate As Date, ByVal WagonNo As String, ByVal ReceiptQty As Decimal, ByVal Sl As Integer, ByVal Remarks As String) As Boolean
        Dim Done As Boolean = False
        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            oCmd.Parameters.Add("@SlNo", SqlDbType.Int, 4).Value = SlNo
            oCmd.Parameters.Add("@ReceiptDate", SqlDbType.SmallDateTime, 4).Value = ReceiptDate
            oCmd.Parameters.Add("@WagonNo", SqlDbType.VarChar, 50).Value = WagonNo
            oCmd.Parameters.Add("@ReceiptQty", SqlDbType.Decimal, 9, 2).Value = ReceiptQty
            oCmd.Parameters.Add("@Sl", SqlDbType.Int, 4).Value = Sl
            oCmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = Remarks
            oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            oCmd.Connection.Open()
            oCmd.Transaction = oCmd.Connection.BeginTransaction
            Try
                If Sl = 0 Then
                    oCmd.CommandText = " select @cnt = count(*) from ms_ScrapReceipt " & _
                                        "  where ReceiptDate = @ReceiptDate and WagonNo = @WagonNo  "
                    oCmd.ExecuteScalar()
                    If IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value) = 0 Then
                        oCmd.CommandText = " insert into ms_ScrapReceipt ( SlNo , ReceiptDate , WagonNo  , ReceiptQty , Remarks ) " & _
                            " values ( @SlNo , @ReceiptDate , @WagonNo , @ReceiptQty , @Remarks ) "
                    Else
                        Throw New Exception("Duplicate entry !")
                    End If
                Else
                    oCmd.CommandText = " update ms_ScrapReceipt " & _
                        " set  WagonNo = @WagonNo , ReceiptQty = @ReceiptQty , SlNo = @SlNo , Remarks = @Remarks" & _
                        " where ReceiptDate =  @ReceiptDate and Sl = @Sl "
                End If
                If oCmd.ExecuteNonQuery = 1 Then Done = True
            Catch exp As Exception
                Throw New Exception("Production Scrap Receipt Details Updation failed !" & exp.Message)
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
    End Function
    Public Function DeleteScrapDetails(ByVal SlNo As Integer) As Boolean
        Dim Done As Boolean = False
        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            oCmd.Parameters.Add("@Sl", SqlDbType.Int, 4).Value = SlNo
            Try
                oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                oCmd.CommandText = " delete ms_ScrapReceipt " & _
                    " where Sl = @Sl "
                If oCmd.ExecuteNonQuery = 1 Then Done = True
            Catch exp As Exception
                Throw New Exception(" Scrap Receipt deletion failed !" & exp.Message)
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
    End Function
    Public Function SavePreHeatedLadleDetails(ByVal LadleNo As String, ByVal PreHeatdate As Date) As Boolean
        Dim Done As Boolean = False
        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            oCmd.Parameters.Add("@PreHeatdate", SqlDbType.SmallDateTime, 4).Value = PreHeatdate
            oCmd.Parameters.Add("@LadleNo", SqlDbType.VarChar, 5).Value = LadleNo
            oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            oCmd.Connection.Open()
            oCmd.Transaction = oCmd.Connection.BeginTransaction
            Try
                'If Sl = 0 Then
                '    oCmd.CommandText = " select @cnt = count(*) from ms_PreHeatedLadleDetails "
                '    oCmd.ExecuteScalar()
                '    If IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value) = 0 Then
                oCmd.CommandText = " insert into ms_PreHeatedLadleDetails ( LadleNo , PreHeatdate ) " & _
                    " values ( @LadleNo , @PreHeatdate ) "
                '    Else
                '        Throw New Exception("Duplicate entry !")
                '    End If
                'Else
                '    oCmd.CommandText = " update ms_ScrapReceipt " & _
                '        " set  WagonNo = @WagonNo , ReceiptQty = @ReceiptQty , SlNo = @SlNo , Remarks = @Remarks" & _
                '        " where ReceiptDate =  @ReceiptDate and Sl = @Sl "
                'End If
                If oCmd.ExecuteNonQuery = 1 Then Done = True
            Catch exp As Exception
                Throw New Exception("Production Scrap Receipt Details Updation failed !" & exp.Message)
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
    End Function
    Public Function DeletePreHeatedLadleDetails(ByVal SlNo As Integer) As Boolean
        Dim Done As Boolean = False
        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            oCmd.Parameters.Add("@Sl", SqlDbType.Int, 4).Value = SlNo
            Try
                oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                oCmd.CommandText = " delete ms_PreHeatedLadleDetails " & _
                    " where Sl = @Sl "
                If oCmd.ExecuteNonQuery = 1 Then Done = True
            Catch exp As Exception
                Throw New Exception(" Scrap Receipt deletion failed !" & exp.Message)
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
    End Function
    Public Function DeleteCalcinedLimeDetails(ByVal Sl As Integer) As Boolean
        Dim Done As Boolean = False
        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            oCmd.Parameters.Add("@Sl", SqlDbType.Int, 4).Value = Sl
            Try
                oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                oCmd.CommandText = " delete ms_CalcinedLimeDetails " & _
                    " where Sl = @Sl "
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
            End If
        End Try
        Return Done
    End Function
    Public Function SaveCalcinedLimeDetails(ByVal ReceiptDate As Date, ByVal DCNo As String, ByVal dbr_number As String, ByVal LabNo As String, ByVal RecQty As Double, ByVal FromHeat As Long, ByVal ToHeat As Long, ByVal Remarks As String, ByVal UsedDate As Date, ByVal NoOfBags As Integer, ByVal Result As String, ByVal YearSl As String, Optional ByVal Sl As Integer = 0) As Boolean
        Dim Done As Boolean = False
        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            oCmd.Parameters.Add("@ReceiptDate", SqlDbType.SmallDateTime, 4).Value = ReceiptDate
            oCmd.Parameters.Add("@DCNo", SqlDbType.VarChar, 9).Value = DCNo
            oCmd.Parameters.Add("@dbr_number", SqlDbType.VarChar, 10).Value = dbr_number
            oCmd.Parameters.Add("@LabNo", SqlDbType.VarChar, 9).Value = LabNo
            oCmd.Parameters.Add("@RecQty", SqlDbType.Decimal, 9, 2).Value = RecQty
            oCmd.Parameters.Add("@FromHeat", SqlDbType.BigInt, 9).Value = FromHeat
            oCmd.Parameters.Add("@ToHeat", SqlDbType.BigInt, 9).Value = ToHeat
            oCmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 50).Value = Remarks
            oCmd.Parameters.Add("@UsedDate", SqlDbType.SmallDateTime, 4).Value = UsedDate ' 
            oCmd.Parameters.Add("@NoOfBags", SqlDbType.Int, 4).Value = NoOfBags '
            oCmd.Parameters.Add("@YearSl", SqlDbType.VarChar, 10).Value = YearSl
            If Result <> "" Then
                oCmd.Parameters.Add("@Result", SqlDbType.Bit, 1).Value = CInt(Result)
            End If
            'oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@Sl", SqlDbType.BigInt, 4).Value = Sl
            oCmd.Connection.Open()
            oCmd.Transaction = oCmd.Connection.BeginTransaction
            Try
                'oCmd.CommandText = " select @cnt = count(*) from ms_CalcinedLimeDetails " & _
                '    " where DCNo = @DCNo and dbr_number = @dbr_number and LabNo = @LabNo " & _
                '    " and FromHeat = @FromHeat and ToHeat = @ToHeat "
                'oCmd.ExecuteScalar()
                'If IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value) > 0 Then
                '    Throw New Exception("Duplicate entry !")
                'Else
                'oCmd.CommandText = " select @Sl = Sl from ms_CalcinedLimeDetails " & _
                '" where DCNo = @DCNo and dbr_number = @dbr_number and  FromHeat = @FromHeat and ToHeat = @ToHeat "
                'oCmd.ExecuteScalar()
                'If IsDBNull(oCmd.Parameters("@Sl").Value) Then oCmd.Parameters("@Sl").Value = Sl
                'If IIf(IsDBNull(oCmd.Parameters("@Sl").Value), 0, oCmd.Parameters("@Sl").Value) > 0 OrElse Sl > 0 Then
                'oCmd.Parameters("@Sl").Direction = ParameterDirection.Input
                If Sl > 0 Then
                    If Result <> "" Then
                        oCmd.CommandText = " update ms_CalcinedLimeDetails " & _
                            " set  LabNo = @LabNo , RecQty = @RecQty , FromHeat = @FromHeat , ToHeat = @ToHeat , Remarks = @Remarks , " & _
                            " UsedDate = @UsedDate , NoOfBags = @NoOfBags , Result = @Result , YearSl = @YearSl " & _
                            " where DCNo =  @DCNo and Sl = @Sl and dbr_number = @dbr_number "
                    Else
                        oCmd.CommandText = " update ms_CalcinedLimeDetails " & _
                            " set  LabNo = @LabNo , RecQty = @RecQty , FromHeat = @FromHeat , ToHeat = @ToHeat , Remarks = @Remarks , " & _
                            " UsedDate = @UsedDate , NoOfBags = @NoOfBags , YearSl = @YearSl" & _
                            " where DCNo =  @DCNo and Sl = @Sl and dbr_number = @dbr_number "
                    End If
                Else
                    If Result <> "" Then
                        oCmd.CommandText = " insert into ms_CalcinedLimeDetails ( ReceiptDate , DCNo , dbr_number , LabNo , RecQty , FromHeat , ToHeat , Remarks , UsedDate , NoOfBags , Result , YearSl ) " & _
                            " values ( @ReceiptDate , @DCNo , @dbr_number , @LabNo , @RecQty , @FromHeat , @ToHeat , @Remarks , @UsedDate , @NoOfBags , @Result , @YearSl ) "
                    Else
                        oCmd.CommandText = " insert into ms_CalcinedLimeDetails ( ReceiptDate , DCNo , dbr_number , LabNo , RecQty , FromHeat , ToHeat , Remarks , UsedDate , NoOfBags  , YearSl ) " & _
                            " values ( @ReceiptDate , @DCNo , @dbr_number , @LabNo , @RecQty , @FromHeat , @ToHeat , @Remarks , @UsedDate , @NoOfBags  , @YearSl ) "
                    End If
                End If
                'End If
                If oCmd.ExecuteNonQuery = 1 Then Done = True
            Catch exp As Exception
                Throw New Exception("Production Scrap Receipt Details Updation failed !" & exp.Message)
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
    End Function
    Public Function SaveMaterialDumpRegister(ByVal PLNO As String, ByVal dbr_number As String, ByVal FromHeat As Long, ByVal ToHeat As Long, ByVal UsedQty As Double, ByVal InspectedBy As String, ByVal Remarks As String, Optional ByVal Sl As Integer = 0) As Boolean
        Dim Done As Boolean = False
        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            oCmd.Parameters.Add("@PLNO", SqlDbType.VarChar, 9).Value = PLNO
            oCmd.Parameters.Add("@dbr_number", SqlDbType.VarChar, 10).Value = dbr_number
            oCmd.Parameters.Add("@FromHeat", SqlDbType.BigInt, 9).Value = FromHeat
            oCmd.Parameters.Add("@ToHeat", SqlDbType.BigInt, 9).Value = ToHeat
            oCmd.Parameters.Add("@UsedQty", SqlDbType.Float, 8).Value = UsedQty
            oCmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 50).Value = Remarks
            oCmd.Parameters.Add("@InspectedBy", SqlDbType.VarChar, 250).Value = InspectedBy
            oCmd.Parameters.Add("@Sl", SqlDbType.BigInt, 4).Value = Sl
            oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output

            oCmd.Connection.Open()
            oCmd.Transaction = oCmd.Connection.BeginTransaction
            Try
                If Sl = 0 Then
                    oCmd.CommandText = "Select @cnt = count(*) from ms_MaterialDumpRegister " & _
                        " where PLNO = @PLNO and  FromHeat =  @FromHeat  "
                    oCmd.ExecuteScalar()
                    If IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value) = 0 Then
                        oCmd.CommandText = " insert into ms_MaterialDumpRegister ( PLNO , dbr_number , UsedQty , FromHeat , ToHeat , Remarks , InspectedBy ) " & _
                                            " values ( @PLNO , @dbr_number , @UsedQty , @FromHeat , @ToHeat , @Remarks , @InspectedBy  ) "
                    Else
                        oCmd.CommandText = " update ms_MaterialDumpRegister  set UsedQty = @UsedQty , " & _
                            " Remarks = @Remarks , InspectedBy = @InspectedBy " & _
                            " where PLNO = @PLNO and dbr_number = @dbr_number and FromHeat = @FromHeat and ToHeat = @ToHeat"
                    End If
                Else
                    oCmd.CommandText = " update ms_MaterialDumpRegister  set dbr_number = @dbr_number , UsedQty = @UsedQty , " & _
                            " FromHeat = @FromHeat , ToHeat = @ToHeat , Remarks = @Remarks , InspectedBy = @InspectedBy " & _
                            " where PLNO = @PLNO and Sl = @Sl  "
                End If
                If oCmd.ExecuteNonQuery = 1 Then Done = True
            Catch exp As Exception
                Throw New Exception("Production Material Dump Register Updation failed !" & exp.Message)
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
    End Function
    'Public Function SaveScrapAccontalCB(ByVal AsOn As Date, ByVal WheelCut As Double, ByVal RailCut As Double, ByVal AxleEndCut As Double, ByVal RisersHub As Double, ByVal LMS As Double, ByVal ChipsAMSCR As Double, ByVal MRXCWheel As Double, ByVal MRRisersHub As Double, ByVal ProScrap As Double) As Boolean
    '    Dim Done As Boolean = False
    '    Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
    '    Try
    '        oCmd.Parameters.Add("@AsOn", SqlDbType.SmallDateTime, 4).Value = AsOn
    '        oCmd.Parameters.Add("@WheelCut", SqlDbType.Float, 8).Value = WheelCut
    '        oCmd.Parameters.Add("@RailCut", SqlDbType.Float, 8).Value = RailCut
    '        oCmd.Parameters.Add("@AxleEndCut", SqlDbType.Float, 8).Value = AxleEndCut
    '        oCmd.Parameters.Add("@RisersHub", SqlDbType.Float, 8).Value = RisersHub
    '        oCmd.Parameters.Add("@LMS", SqlDbType.Float, 8).Value = LMS
    '        oCmd.Parameters.Add("@ChipsAMSCR", SqlDbType.Float, 8).Value = ChipsAMSCR '
    '        oCmd.Parameters.Add("@MRXCWheel", SqlDbType.Float, 8).Value = MRXCWheel
    '        oCmd.Parameters.Add("@MRRisersHub", SqlDbType.Float, 8).Value = MRRisersHub
    '        oCmd.Parameters.Add("@ProScrap", SqlDbType.Float, 8).Value = ProScrap
    '        oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output

    '        oCmd.Connection.Open()
    '        oCmd.Transaction = oCmd.Connection.BeginTransaction
    '        Try
    '            oCmd.CommandText = " select @cnt = count(*) from ms_ScrapAccontalCB " & _
    '                " where month(AsOn) = month(@AsOn) and year(AsOn) = year(@AsOn) "
    '            oCmd.ExecuteScalar()
    '            If IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value) = 0 Then
    '                oCmd.CommandText = " insert into ms_ScrapAccontalCB ( AsOn , WheelCut , RailCut , AxleEndCut , RisersHub , LMS , ChipsAMSCR , MRXCWheel , MRRisersHub , ProScrap ) " & _
    '                    " values ( @AsOn , @WheelCut , @RailCut , @AxleEndCut , @RisersHub , @LMS , @ChipsAMSCR , @MRXCWheel , @MRRisersHub , @ProScrap ) "
    '            Else
    '                oCmd.CommandText = " update ms_ScrapAccontalCB " & _
    '                    " Set AsOn = @AsOn , WheelCut = @WheelCut ,  RailCut = @RailCut , AxleEndCut = @AxleEndCut , " & _
    '                    " RisersHub = @RisersHub , LMS = @LMS , ChipsAMSCR = @ChipsAMSCR , MRXCWheel = @MRXCWheel , MRRisersHub = @MRRisersHub " & _
    '                    " , ProScrap = @ProScrap where month(AsOn) = month(@AsOn) and year(AsOn) = year(@AsOn) "
    '            End If
    '            If oCmd.ExecuteNonQuery = 1 Then Done = True
    '        Catch exp As Exception
    '            Throw New Exception("Production Scrap Receipt Details Updation failed !" & exp.Message)
    '        End Try
    '    Catch exp As Exception
    '        Throw New Exception(exp.Message)
    '    Finally
    '        If Not IsNothing(oCmd) Then
    '            If Done Then
    '                oCmd.Transaction.Commit()
    '            Else
    '                oCmd.Transaction.Rollback()
    '            End If
    '            If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
    '            oCmd.Dispose()
    '        End If
    '    End Try
    '    Return Done
    'End Function
    Public Function SaveScrapAccontalCB(ByVal AsOn As Date, ByVal WheelCut As Double, ByVal RisersHub As Double, ByVal LMS As Double, ByVal ChipsAMSCR As Double, ByVal MRXCWheel As Double, ByVal MRRisersHub As Double) As Boolean
        Dim Done As Boolean = False
        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            oCmd.Parameters.Add("@AsOn", SqlDbType.SmallDateTime, 4).Value = AsOn
            oCmd.Parameters.Add("@WheelCut", SqlDbType.Float, 8).Value = WheelCut
            'oCmd.Parameters.Add("@RailCut", SqlDbType.Float, 8).Value = RailCut
            '.Parameters.Add("@AxleEndCut", SqlDbType.Float, 8).Value = AxleEndCut
            '.Parameters.Add("@RisersHub", SqlDbType.Float, 8).Value = RisersHub
            oCmd.Parameters.Add("@LMS", SqlDbType.Float, 8).Value = LMS
            oCmd.Parameters.Add("@ChipsAMSCR", SqlDbType.Float, 8).Value = ChipsAMSCR '
            oCmd.Parameters.Add("@MRXCWheel", SqlDbType.Float, 8).Value = MRXCWheel
            oCmd.Parameters.Add("@MRRisersHub", SqlDbType.Float, 8).Value = MRRisersHub
            'oCmd.Parameters.Add("@ProScrap", SqlDbType.Float, 8).Value = ProScrap
            oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output

            oCmd.Connection.Open()
            oCmd.Transaction = oCmd.Connection.BeginTransaction
            Try
                oCmd.CommandText = " select @cnt = count(*) from ms_ScrapAccontalCB " &
                    " where month(AsOn) = month(@AsOn) and year(AsOn) = year(@AsOn) "
                oCmd.ExecuteScalar()
                If IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value) = 0 Then
                    oCmd.CommandText = " insert into ms_ScrapAccontalCB ( AsOn , WheelCut , RailCut , AxleEndCut , RisersHub , LMS , ChipsAMSCR , MRXCWheel , MRRisersHub , ProScrap ) " &
                        " values ( @AsOn , @WheelCut , @RailCut , @AxleEndCut , @RisersHub , @LMS , @ChipsAMSCR , @MRXCWheel , @MRRisersHub , @ProScrap ) "
                Else
                    oCmd.CommandText = " update ms_ScrapAccontalCB " &
                        " Set AsOn = @AsOn , WheelCut = @WheelCut ,  RailCut = @RailCut , AxleEndCut = @AxleEndCut , " &
                        " RisersHub = @RisersHub , LMS = @LMS , ChipsAMSCR = @ChipsAMSCR , MRXCWheel = @MRXCWheel , MRRisersHub = @MRRisersHub " &
                        " , ProScrap = @ProScrap where month(AsOn) = month(@AsOn) and year(AsOn) = year(@AsOn) "
                End If
                If oCmd.ExecuteNonQuery = 1 Then Done = True
            Catch exp As Exception
                Throw New Exception("Production Scrap Receipt Details Updation failed !" & exp.Message)
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
    End Function
    Public Function SaveScrapAccontalReverseUpdate(ByVal AsOn As Date) As Boolean
        Dim Done As Boolean = False
        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            oCmd.Parameters.Add("@AsOn", SqlDbType.SmallDateTime, 4).Value = AsOn

            oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output

            oCmd.Connection.Open()
            oCmd.Transaction = oCmd.Connection.BeginTransaction
            Try
                oCmd.CommandText = " select @cnt = count(*) from ms_ScrapAccontal " & _
                    " where month(UsageDate) = month(@AsOn) and year(UsageDate) = year(@AsOn) "
                oCmd.ExecuteScalar()
                If IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value) = 0 Then
                    oCmd.CommandText = " insert into ms_ScrapAccontal ( UsageDate , RisersHub )" & _
                        " select  top 1 isnull(TappedDate,@AsOn) , isnull((MRRisersHub/MonthHeats)*Heats,0) RisersHub " & _
                        " from (" & _
                        " select convert(varchar(6),AsOn,112) AsOnMonth , * " & _
                        " from ms_ScrapAccontalCB ) a" & _
                        " left outer join ( " & _
                        " select convert(varchar(6),TappedDate,112) TappedMonth , count(*) MonthHeats" & _
                        " from mm_vw_HeatTapped " & _
                        " where month(TappedDate) =  month(@AsOn) and year(TappedDate) =  year(@AsOn)" & _
                        " group by convert(varchar(6),TappedDate,112)" & _
                        " ) b on AsOnMonth = b.TappedMonth" & _
                        " left outer join ( " & _
                        " select convert(varchar(6),TappedDate,112) TappedMonth , TappedDate , count(*) Heats" & _
                        " from mm_vw_HeatTapped " & _
                        " where month(TappedDate) =  month(@AsOn) and year(TappedDate) =  year(@AsOn)" & _
                        " group by TappedDate" & _
                        " ) c on AsOnMonth = c.TappedMonth " & _
                        " order by TappedDate "
                Else
                    oCmd.CommandText = " update a set a.RisersHub = b.RisersHub  " & _
                        " from ms_ScrapAccontal a inner join ( " & _
                        " select TappedDate , (MRRisersHub/MonthHeats)*Heats RisersHub , Heats  " & _
                        " from ( " & _
                        " select convert(varchar(6),AsOn,112) AsOnMonth , * " & _
                        " from ms_ScrapAccontalCB ) a" & _
                        " inner join ( " & _
                        " select convert(varchar(6),TappedDate,112) TappedMonth , count(*) MonthHeats" & _
                        " from mm_vw_HeatTapped " & _
                        " where month(TappedDate) =  month(@AsOn) and year(TappedDate) =  year(@AsOn)" & _
                        " group by convert(varchar(6),TappedDate,112)" & _
                        " ) b on AsOnMonth = b.TappedMonth" & _
                        " inner join ( " & _
                        " select convert(varchar(6),TappedDate,112) TappedMonth , TappedDate , count(*) Heats   " & _
                        " from mm_vw_HeatTapped     " & _
                        " where month(TappedDate) =  month(@AsOn) and year(TappedDate) =  year(@AsOn)" & _
                        " group by TappedDate " & _
                        " ) c on AsOnMonth = c.TappedMonth ) b" & _
                        " on TappedDate = UsageDate"
                End If
                If oCmd.ExecuteNonQuery > 0 Then Done = True
            Catch exp As Exception
                Throw New Exception("Production Scrap ccontal Details Updation failed !" & exp.Message)
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
    End Function
    'Public Function SaveScrapAccontal(ByVal UsageDate As Date, ByVal WheelCut As Double, ByVal RailCut As Double, ByVal AxleEndCut As Double, ByVal RisersHub As Double, ByVal LMS As Double, ByVal ChipsAMSCR As Double, ByVal ProScrap As Double) As Boolean
    '    Dim Done As Boolean = False
    '    Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
    '    Try
    '        oCmd.Parameters.Add("@UsageDate", SqlDbType.SmallDateTime, 4).Value = UsageDate
    '        oCmd.Parameters.Add("@WheelCut", SqlDbType.Float, 8).Value = WheelCut
    '        oCmd.Parameters.Add("@RailCut", SqlDbType.Float, 8).Value = RailCut
    '        oCmd.Parameters.Add("@AxleEndCut", SqlDbType.Float, 8).Value = AxleEndCut
    '        oCmd.Parameters.Add("@RisersHub", SqlDbType.Float, 8).Value = RisersHub
    '        oCmd.Parameters.Add("@LMS", SqlDbType.Float, 8).Value = LMS
    '        oCmd.Parameters.Add("@ChipsAMSCR", SqlDbType.Float, 8).Value = ChipsAMSCR
    '        oCmd.Parameters.Add("@ProScrap", SqlDbType.Float, 8).Value = ProScrap
    '        oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
    '        oCmd.Connection.Open()
    '        oCmd.Transaction = oCmd.Connection.BeginTransaction
    '        Try
    '            oCmd.CommandText = " select @cnt = count(*) from ms_ScrapAccontal " & _
    '                " where UsageDate = @UsageDate "
    '            oCmd.ExecuteScalar()
    '            If IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value) = 0 Then
    '                oCmd.CommandText = " insert into ms_ScrapAccontal ( UsageDate , WheelCut , RailCut , AxleEndCut , RisersHub , LMS , ChipsAMSCR , ProScrap ) " & _
    '                    " values ( @UsageDate , @WheelCut , @RailCut , @AxleEndCut , @RisersHub , @LMS , @ChipsAMSCR  , @ProScrap ) "
    '            Else
    '                oCmd.CommandText = " update ms_ScrapAccontal " & _
    '                    " Set WheelCut = @WheelCut ,  RailCut = @RailCut , AxleEndCut = @AxleEndCut , " & _
    '                    " RisersHub = @RisersHub , LMS = @LMS , ChipsAMSCR = @ChipsAMSCR  , ProScrap = @ProScrap " & _
    '                    " where UsageDate = @UsageDate  "
    '            End If
    '            If oCmd.ExecuteNonQuery = 1 Then Done = True
    '        Catch exp As Exception
    '            Throw New Exception("Production Scrap Receipt Details Updation failed !" & exp.Message)
    '        End Try
    '    Catch exp As Exception
    '        Throw New Exception(exp.Message)
    '    Finally
    '        If Not IsNothing(oCmd) Then
    '            If Done Then
    '                oCmd.Transaction.Commit()
    '            Else
    '                oCmd.Transaction.Rollback()
    '            End If
    '            If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
    '            oCmd.Dispose()
    '        End If
    '    End Try
    '    Return Done
    'End Function
    Public Function SaveScrapAccontal(ByVal UsageDate As Date, ByVal WheelCut As Double, ByVal RisersHub As Double, ByVal LMS As Double, ByVal ChipsAMSCR As Double) As Boolean
        Dim Done As Boolean = False
        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            oCmd.Parameters.Add("@UsageDate", SqlDbType.SmallDateTime, 4).Value = UsageDate
            oCmd.Parameters.Add("@WheelCut", SqlDbType.Float, 8).Value = WheelCut
            ' oCmd.Parameters.Add("@RailCut", SqlDbType.Float, 8).Value = RailCut
            ' oCmd.Parameters.Add("@AxleEndCut", SqlDbType.Float, 8).Value = AxleEndCut
            oCmd.Parameters.Add("@RisersHub", SqlDbType.Float, 8).Value = RisersHub
            oCmd.Parameters.Add("@LMS", SqlDbType.Float, 8).Value = LMS
            oCmd.Parameters.Add("@ChipsAMSCR", SqlDbType.Float, 8).Value = ChipsAMSCR
            'oCmd.Parameters.Add("@ProScrap", SqlDbType.Float, 8).Value = ProScrap
            oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            oCmd.Connection.Open()
            oCmd.Transaction = oCmd.Connection.BeginTransaction
            Try
                oCmd.CommandText = " select @cnt = count(*) from ms_ScrapAccontal " &
                    " where UsageDate = @UsageDate "
                oCmd.ExecuteScalar()
                'If IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value) = 0 Then
                '    oCmd.CommandText = " insert into ms_ScrapAccontal ( UsageDate , WheelCut , RailCut , AxleEndCut , RisersHub , LMS , ChipsAMSCR , ProScrap ) " &
                '        " values ( @UsageDate , @WheelCut , @RailCut , @AxleEndCut , @RisersHub , @LMS , @ChipsAMSCR  , @ProScrap ) "
                'Else
                '    oCmd.CommandText = " update ms_ScrapAccontal " &
                '        " Set WheelCut = @WheelCut ,  RailCut = @RailCut , AxleEndCut = @AxleEndCut , " &
                '        " RisersHub = @RisersHub , LMS = @LMS , ChipsAMSCR = @ChipsAMSCR  , ProScrap = @ProScrap " &
                '        " where UsageDate = @UsageDate  "

                If IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value) = 0 Then
                    oCmd.CommandText = " insert into ms_ScrapAccontal ( UsageDate , WheelCut , RailCut , AxleEndCut , RisersHub , LMS , ChipsAMSCR , ProScrap ) " &
                        " values ( @UsageDate , @WheelCut , 0 , 0 , @RisersHub , @LMS , @ChipsAMSCR  , 0 ) "
                Else
                    oCmd.CommandText = " update ms_ScrapAccontal " &
                        " Set WheelCut = @WheelCut , " &
                        " RisersHub = @RisersHub , LMS = @LMS , ChipsAMSCR = @ChipsAMSCR  " &
                        " where UsageDate = @UsageDate  "

                End If
                If oCmd.ExecuteNonQuery = 1 Then Done = True
            Catch exp As Exception
                Throw New Exception("Production Scrap Receipt Details Updation failed !" & exp.Message)
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
    End Function
    Public Function SavePLConsumption(ByVal ConsumDate As Date, ByVal PLNumber As String, ByVal OB As Decimal, ByVal Receipts As Decimal, ByVal Consumption As Decimal, ByVal CB As Decimal) As Boolean
        Dim Done As Boolean = False
        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            oCmd.Parameters.Add("@ConsumDate", SqlDbType.SmallDateTime, 4).Value = ConsumDate
            oCmd.Parameters.Add("@PLNumber", SqlDbType.VarChar, 8).Value = PLNumber
            oCmd.Parameters.Add("@OB", SqlDbType.Float, 8).Value = OB
            oCmd.Parameters.Add("@Receipts", SqlDbType.Float, 8).Value = Receipts
            oCmd.Parameters.Add("@Consumption", SqlDbType.Float, 8).Value = Consumption
            oCmd.Parameters.Add("@CB", SqlDbType.Float, 8).Value = CB

            oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            oCmd.CommandText = " select @cnt = count(*) from mm_PLConsumption where PLNumber = @PLNumber " & _
                " and ConsumDate = @ConsumDate "
            Try
                oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                oCmd.ExecuteScalar()
                If IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value) = 0 Then
                    oCmd.CommandText = " insert into mm_PLConsumption ( ConsumDate , PLNumber , OB , Receipts , Consumption , CB ) " & _
                        " values ( @ConsumDate , @PLNumber , @OB , @Receipts , @Consumption , @CB ) "
                Else
                    oCmd.CommandText = " update mm_PLConsumption set OB = @OB , " & _
                        " Receipts = @Receipts , Consumption = @Consumption , CB  = @CB " & _
                        " where PLNumber = @PLNumber and ConsumDate = @ConsumDate  "
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
            End If
        End Try
        Return Done
    End Function
    Public Function SavePOMOTransDetails(ByVal Consignee As String, ByVal PLNO As String, ByVal TransNumber As String, ByVal TransDate As Date, ByVal TransQty As Double, ByVal Remarks As String, ByVal TypeID As Int16, ByVal Supplier As String, ByVal TransID As Long) As Boolean
        Dim Done As Boolean = False
        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            oCmd.Connection.Open()
            oCmd.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = Consignee
            oCmd.Parameters.Add("@PLNO", SqlDbType.VarChar, 8).Value = PLNO
            oCmd.Parameters.Add("@TransNumber", SqlDbType.VarChar, 50).Value = TransNumber
            oCmd.Parameters.Add("@TransDate", SqlDbType.SmallDateTime, 4).Value = TransDate
            oCmd.Parameters.Add("@TransQty", SqlDbType.Float, 9).Value = TransQty
            oCmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = Remarks
            oCmd.Parameters.Add("@Supplier", SqlDbType.VarChar, 50).Value = Supplier
            oCmd.Parameters.Add("@TypeID", SqlDbType.Int, 4).Value = TypeID
            oCmd.Parameters.Add("@TransID", SqlDbType.BigInt, 8).Value = TransID
            oCmd.Parameters.Add("@PLId", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            Try
                If PLNO.Trim.Length = 0 Then
                    oCmd.Parameters("@TransID").Direction = ParameterDirection.Output
                    oCmd.CommandText = " select @TransID = TransID from ms_POMOConsumableDetails where TransNumber = @TransNumber " & _
                        " and month(TransDate) = month(@TransDate) and  year(TransDate) = year(@TransDate) "
                    oCmd.ExecuteScalar()
                    If IIf(IsDBNull(oCmd.Parameters("@TransID").Value), 0, oCmd.Parameters("@TransID").Value) = 0 Then
                        oCmd.CommandText = " insert into ms_POMOConsumableDetails ( TransDate , TransNumber , TransQty , TypeID , Remarks ) " & _
                            " values ( @TransDate , @TransNumber , @TransQty , @TypeID , @Remarks  ) "
                    Else
                        oCmd.CommandText = " update ms_POMOConsumableDetails " & _
                            " set  TransQty = @TransQty , Remarks = @Remarks " & _
                            " where month(TransDate) = month(@TransDate) and  year(TransDate) = year(@TransDate) " & _
                            " and TransNumber = @TransNumber and TransID = @TransID "
                    End If
                Else
                    oCmd.CommandText = " select @PLId = PLId from ms_ProdConsumableList where Consignee = @Consignee and PLNumber = @PLNO "
                    oCmd.ExecuteScalar()
                    oCmd.Parameters("@PLId").Direction = ParameterDirection.Input
                    oCmd.CommandText = " select @cnt = count(*) from ms_POMOConsumableDetails where PLId = @PLId " & _
                            " and TransNumber = @TransNumber and TransID = @TransID "
                    oCmd.ExecuteScalar()
                    If IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value) = 0 Then
                        oCmd.CommandText = " insert into ms_POMOConsumableDetails ( PLId , TransDate , TransNumber , TransQty , TypeID , Remarks , Supplier ) " & _
                            " values ( @PLId , @TransDate , @TransNumber , @TransQty , @TypeID , @Remarks , @Supplier ) "
                    Else
                        oCmd.CommandText = " update ms_POMOConsumableDetails " & _
                            " set  TransDate = @TransDate , TransQty = @TransQty , Remarks = @Remarks  , Supplier = @Supplier " & _
                            " where PLid =  @PLid and TransNumber = @TransNumber and TransID = @TransID "
                    End If
                End If
                If oCmd.ExecuteNonQuery = 1 Then Done = True
            Catch exp As Exception
                Throw New Exception("POMO Consumable Details Updation failed !" & exp.Message)
            End Try
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            If Not IsNothing(oCmd) Then
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End If
        End Try
        Return Done
    End Function
    Public Function SaveFurnaceLining(ByVal LiningNo As String, ByVal LT As Int16, ByVal LB As Int16, ByVal LiningItemNo As String, ByVal LastHeatNo As Long, ByVal HandedOverOn As DateTime, ByVal WorkStartedOn As DateTime, ByVal WorkCompletedOn As DateTime, ByVal LOANo As String, ByVal LOADate As Date, ByVal ScheduledQty As Integer, ByVal CompletedQty As Integer, ByVal InspectionNote As String, ByVal BTT As Integer, ByVal BMOM As Integer, ByVal TTT As Integer, ByVal TMOM As Integer, ByVal Depth As Integer, ByVal PreLiningNo As String, ByVal FFLNo As String, ByVal GroupLeader1 As String, ByVal GroupLeader2 As String, ByVal LOARemarks As String) As Boolean
        Dim Done As Boolean = False
        Dim roof As Boolean
        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            oCmd.Parameters.Add("@LiningNo", SqlDbType.VarChar, 50).Value = LiningNo
            oCmd.Parameters.Add("@LT", SqlDbType.Int, 4).Value = LT
            oCmd.Parameters.Add("@LB", SqlDbType.Int, 4).Value = LB
            oCmd.Parameters.Add("@LiningItemNo", SqlDbType.VarChar, 50).Value = LiningItemNo
            oCmd.Parameters.Add("@LastHeatNo", SqlDbType.BigInt, 8).Value = LastHeatNo
            oCmd.Parameters.Add("@HandedOverOn", SqlDbType.SmallDateTime, 4).Value = HandedOverOn
            oCmd.Parameters.Add("@WorkStartedOn", SqlDbType.SmallDateTime, 4).Value = WorkStartedOn
            oCmd.Parameters.Add("@WorkCompletedOn", SqlDbType.SmallDateTime, 4).Value = WorkCompletedOn
            oCmd.Parameters.Add("@LOANo", SqlDbType.VarChar, 50).Value = LOANo
            oCmd.Parameters.Add("@LOADate", SqlDbType.SmallDateTime, 4).Value = LOADate
            oCmd.Parameters.Add("@ScheduledQty", SqlDbType.Int, 4).Value = ScheduledQty
            oCmd.Parameters.Add("@CompletedQty", SqlDbType.Int, 4).Value = CompletedQty
            oCmd.Parameters.Add("@InspectionNote", SqlDbType.VarChar, 250).Value = InspectionNote
            oCmd.Parameters.Add("@PreLiningNo", SqlDbType.VarChar, 50).Value = PreLiningNo
            oCmd.Parameters.Add("@FFLNo", SqlDbType.VarChar, 50).Value = FFLNo '

            oCmd.Parameters.Add("@BTT", SqlDbType.Int, 4).Value = BTT
            oCmd.Parameters.Add("@BMOM", SqlDbType.Int, 4).Value = BMOM
            oCmd.Parameters.Add("@TTT", SqlDbType.Int, 4).Value = TTT
            oCmd.Parameters.Add("@TMOM", SqlDbType.Int, 4).Value = TMOM
            oCmd.Parameters.Add("@Depth", SqlDbType.Int, 4).Value = Depth
            oCmd.Parameters.Add("@GroupLeader1", SqlDbType.VarChar, 6).Value = GroupLeader1
            oCmd.Parameters.Add("@GroupLeader2", SqlDbType.VarChar, 6).Value = GroupLeader2
            oCmd.Parameters.Add("@LOARemarks", SqlDbType.VarChar, 50).Value = LOARemarks

            oCmd.Parameters.Add("@FirstHeatNo", SqlDbType.BigInt, 8).Direction = ParameterDirection.Input
            If LT = 4 Then
                If Not PreLiningNo.ToLower.StartsWith("new") Then
                    If New ProductionConsumables().RoofLifeUpdation(LT, LiningItemNo, PreLiningNo) Then Done = True
                    If Not Done Then
                        roof = True
                        Exit Function
                    Else
                        Done = False
                    End If
                End If
            End If
            oCmd.Parameters.Add("@PreWorkCompletedOn", SqlDbType.SmallDateTime, 4).Value = ProductionConsumables.GetWorkCompletedOn(LT, LiningItemNo, PreLiningNo)
            If oCmd.Parameters("@PreWorkCompletedOn").Value = "1900-01-01" Then
                oCmd.Parameters("@FirstHeatNo").Value = 0
            Else
                oCmd.Parameters("@FirstHeatNo").Value = ProductionConsumables.GetFirstHeatNo(LT, LiningItemNo, oCmd.Parameters("@PreWorkCompletedOn").Value, LastHeatNo)
            End If
            If oCmd.Parameters("@FirstHeatNo").Value > oCmd.Parameters("@LastHeatNo").Value Then
                Throw New Exception(" LastHeatNo and FirstHeatNo of PreLiningNo MisMatch ! Furnace Lining Updation failed !")
            End If
            oCmd.Parameters.Add("@SlNo", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            oCmd.CommandText = " select @SlNo = SlNo from ms_FurnaceLining where LiningNo = @LiningNo and LT = @LT "
            Try
                oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                oCmd.ExecuteScalar()
                If IIf(IsDBNull(oCmd.Parameters("@SlNo").Value), 0, oCmd.Parameters("@SlNo").Value) = 0 Then
                    oCmd.CommandText = " insert into ms_FurnaceLining ( LiningNo , LT , LB , " & _
                        " LiningItemNo , HandedOverOn , WorkStartedOn , LOARemarks , " & _
                        " WorkCompletedOn , LOANo , LOADate ,  ScheduledQty , CompletedQty , InspectionNote , " & _
                        " BTT , BMOM , TTT , TMOM , Depth , PreLiningNo , FFLNo , GroupLeader1 , GroupLeader2 ) " & _
                        " values ( @LiningNo , @LT , @LB , @LiningItemNo , @HandedOverOn , @WorkStartedOn , @LOARemarks , " & _
                        " @WorkCompletedOn , @LOANo , @LOADate ,  @ScheduledQty , @CompletedQty , @InspectionNote ," & _
                        " @BTT , @BMOM , @TTT , @TMOM , @Depth , @PreLiningNo , @FFLNo , @GroupLeader1 , @GroupLeader2) "
                Else
                    oCmd.Parameters("@SlNo").Direction = ParameterDirection.Input
                    oCmd.CommandText = " update ms_FurnaceLining set FFLNo = @FFLNo ,  LOARemarks = @LOARemarks , " & _
                        " LB = @LB , LiningItemNo = @LiningItemNo , PreLiningNo = @PreLiningNo ," & _
                        " HandedOverOn = @HandedOverOn , WorkStartedOn = @WorkStartedOn , WorkCompletedOn = @WorkCompletedOn , " & _
                        " LOANo = @LOANo , LOADate = @LOADate ,  ScheduledQty = @ScheduledQty , " & _
                        " CompletedQty = @CompletedQty , InspectionNote = @InspectionNote , " & _
                        " BTT = @BTT , BMOM = @BMOM , TTT = @TTT , TMOM = @TMOM , Depth = @Depth , " & _
                        " GroupLeader1 = @GroupLeader1 , GroupLeader2 = @GroupLeader2 " & _
                        " where LiningNo = @LiningNo  and SlNo = @SlNo and LT = @LT "
                End If
                If oCmd.ExecuteNonQuery = 1 Then Done = True
                oCmd.Parameters("@SlNo").Direction = ParameterDirection.Output
                oCmd.CommandText = " select @SlNo = SlNo from ms_FurnaceLining where LiningNo = @PreLiningNo and LT = @LT and LiningItemNo = @LiningItemNo "
                oCmd.ExecuteScalar()
                If IIf(IsDBNull(oCmd.Parameters("@SlNo").Value), 0, oCmd.Parameters("@SlNo").Value) = 0 Then
                    oCmd.CommandText = " insert into ms_FurnaceLining ( LiningNo , LT , LB , LastHeatNo , LiningItemNo , FirstHeatNo ) " & _
                        " values ( @PreLiningNo , @LT , @LB , @LastHeatNo , @LiningItemNo , @FirstHeatNo ) "
                Else
                    oCmd.Parameters("@SlNo").Direction = ParameterDirection.Input
                    oCmd.CommandText = " update ms_FurnaceLining set  FirstHeatNo = @FirstHeatNo , " & _
                        " LastHeatNo = @LastHeatNo where LiningNo = @PreLiningNo  and SlNo = @SlNo and LT = @LT and LiningItemNo = @LiningItemNo "
                End If
                oCmd.ExecuteNonQuery()
            Catch exp As Exception
                Throw New Exception(" Furnace Lining Updation failed !" & exp.Message)
            End Try
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            If Not roof Then
                If Not IsNothing(oCmd) Then
                    If Done Then
                        oCmd.Transaction.Commit()
                    Else
                        oCmd.Transaction.Rollback()
                    End If
                    If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                    oCmd.Dispose()
                End If
            End If
        End Try
        Return Done
    End Function
    Public Function SaveFurnaceLiningPLs(ByVal LT As Integer, ByVal LiningNo As String, ByVal PLNumber As String, ByVal Qty As Double, ByVal PODBRNo As String, ByVal SetNo As Integer, Optional ByVal Delete As Boolean = False) As Boolean
        Dim Done As Boolean = False
        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            oCmd.Parameters.Add("@LiningNo", SqlDbType.VarChar, 50).Value = LiningNo
            oCmd.Parameters.Add("@LT", SqlDbType.BigInt, 8).Value = LT
            oCmd.Parameters.Add("@PODBRNo", SqlDbType.VarChar, 50).Value = PODBRNo
            oCmd.Parameters.Add("@Qty", SqlDbType.Decimal, 9, 2).Value = Qty
            oCmd.Parameters.Add("@PLNumber", SqlDbType.VarChar, 50).Value = PLNumber
            oCmd.Parameters.Add("@SetNo", SqlDbType.Int, 4).Value = SetNo

            oCmd.Parameters.Add("@SlNo", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            oCmd.CommandText = " select @SlNo = count(*) from ms_FurnaceLiningPLs where LiningNo = @LiningNo " & _
                " and PODBRNo = @PODBRNo and PLNumber = @PLNumber and LT = @LT "
            Try
                oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                oCmd.ExecuteScalar()
                If Delete Then
                    oCmd.CommandText = " delete ms_FurnaceLiningPLs " & _
                            " where LiningNo = @LiningNo  and PLNumber = @PLNumber and LT = @LT and PODBRNo = @PODBRNo "
                Else
                    If IIf(IsDBNull(oCmd.Parameters("@SlNo").Value), 0, oCmd.Parameters("@SlNo").Value) = 0 Then
                        oCmd.CommandText = " insert into ms_FurnaceLiningPLs ( LiningNo , LT , PLNumber , Qty , PODBRNo , SetNo ) " & _
                            " values ( @LiningNo , @LT , @PLNumber , @Qty , @PODBRNo , @SetNo ) "
                    Else
                        oCmd.CommandText = " update ms_FurnaceLiningPLs " & _
                            "  set Qty = @Qty , SetNo = @SetNo " & _
                            " where LiningNo = @LiningNo  and PLNumber = @PLNumber and LT = @LT and PODBRNo = @PODBRNo "
                    End If
                End If
                If oCmd.ExecuteNonQuery = 1 Then Done = True
            Catch exp As Exception
                Throw New Exception(" Furnace Lining PLs Updation failed !" & exp.Message)
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
    End Function
    Public Function SaveLiningDetails(ByVal LT As Integer, ByVal Type As Int16, ByVal ItemNo As String, ByVal FromHeat As Long, ByVal ToHeat As Double, ByVal Bottom As String, ByVal SideWall As String, ByVal Remarks As String, Optional ByVal Delete As Boolean = False) As Boolean
        Dim Done As Boolean = False
        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            oCmd.Parameters.Add("@LT", SqlDbType.BigInt, 8).Value = LT
            oCmd.Parameters.Add("@ItemNo", SqlDbType.VarChar, 50).Value = ItemNo
            oCmd.Parameters.Add("@FromHeat", SqlDbType.BigInt, 8).Value = FromHeat
            oCmd.Parameters.Add("@ToHeat", SqlDbType.BigInt, 8).Value = ToHeat
            oCmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = Remarks
            oCmd.Parameters.Add("@Bottom", SqlDbType.VarChar, 250).Value = Bottom
            oCmd.Parameters.Add("@SideWall", SqlDbType.VarChar, 250).Value = SideWall
            If LT = 3 Then
                oCmd.Parameters.Add("@ItemName", SqlDbType.VarChar, 10).Value = "LadleNo"
            Else
                oCmd.Parameters.Add("@ItemName", SqlDbType.VarChar, 10).Value = "RoofNo"
            End If
            Try
                oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                If Delete = False Then
                    If Type = 1 OrElse Type = 4 Then
                        oCmd.CommandText = " update ms_FurnaceLining  set FirstHeatNo = @FromHeat , LastHeatNo = @ToHeat " & _
                            " where LiningNo = @ItemNo and LT = @LT "
                    Else
                        oCmd.CommandText = " insert into ms_LiningItemsNotInUse ( ItemName , ItemNo , Remarks , Bottom , SideWall ) " & _
                            " values ( @ItemName , @ItemNo , @Remarks , @Bottom , @SideWall ) "
                    End If
                Else
                    oCmd.CommandText = " delete from ms_FurnaceLining  " & _
                           " where LiningNo = @ItemNo and LT = @LT "
                End If
                If oCmd.ExecuteNonQuery = 1 Then Done = True
            Catch exp As Exception
                Throw New Exception("Lining  Updation failed !" & exp.Message)
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
    End Function
    Public Function SaveFurnaceLiningRemarks(ByVal LiningNo As String, ByVal LT As Integer, ByVal MaxErosion As String, ByVal ErosionLoc As String, ByVal MaxPenitration As String, ByVal PenitrationLoc As String, ByVal LiningCondition As String, ByVal AreaCon As String, ByVal Spalling As String, ByVal SpallingDepth As String, ByVal SpallingArea As String, ByVal Remarks As String, ByVal DueTo As Integer) As Boolean
        Dim Done As Boolean = False
        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            oCmd.Parameters.Add("@LT", SqlDbType.BigInt, 8).Value = LT
            oCmd.Parameters.Add("@LiningNo", SqlDbType.VarChar, 50).Value = LiningNo
            oCmd.Parameters.Add("@MaxErosion", SqlDbType.VarChar, 50).Value = MaxErosion
            oCmd.Parameters.Add("@ErosionLoc", SqlDbType.VarChar, 50).Value = ErosionLoc
            oCmd.Parameters.Add("@MaxPenitration", SqlDbType.VarChar, 50).Value = MaxPenitration
            oCmd.Parameters.Add("@PenitrationLoc", SqlDbType.VarChar, 50).Value = PenitrationLoc
            oCmd.Parameters.Add("@LiningCondition", SqlDbType.VarChar, 50).Value = LiningCondition
            oCmd.Parameters.Add("@AreaCon", SqlDbType.VarChar, 50).Value = AreaCon
            oCmd.Parameters.Add("@Spalling", SqlDbType.Bit, 1).Value = Val(Spalling)
            oCmd.Parameters.Add("@SpallingDepth", SqlDbType.VarChar, 50).Value = SpallingDepth
            oCmd.Parameters.Add("@SpallingArea", SqlDbType.VarChar, 50).Value = SpallingArea
            oCmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = Remarks
            oCmd.Parameters.Add("@DueTo", SqlDbType.Int, 4).Value = DueTo
            oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            '
            Try
                oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction

                oCmd.CommandText = " select @cnt = count(*) from ms_FurnaceLiningRemarks  " & _
                           " where LiningNo = @LiningNo and LT = @LT "
                oCmd.ExecuteScalar()
                If IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value) = 1 Then
                    oCmd.CommandText = " update ms_FurnaceLiningRemarks  set MaxErosion = @MaxErosion , ErosionLoc = @ErosionLoc , " & _
                        " MaxPenitration = @MaxPenitration , PenitrationLoc = @PenitrationLoc , " & _
                        " LiningCondition = @LiningCondition , AreaCon = @AreaCon , " & _
                        " Spalling = @Spalling , SpallingDepth = @SpallingDepth , " & _
                        " SpallingArea = @SpallingArea , Remarks = @Remarks , DueTo = @DueTo " & _
                        " where LiningNo = @LiningNo and LT = @LT "
                Else
                    oCmd.CommandText = " insert into ms_FurnaceLiningRemarks ( LiningNo , LT , MaxErosion , ErosionLoc , " & _
                        " MaxPenitration , PenitrationLoc , LiningCondition , AreaCon , Spalling , SpallingDepth ,  SpallingArea , Remarks , DueTo ) " & _
                        " values ( @LiningNo , @LT , @MaxErosion , @ErosionLoc , @MaxPenitration , @PenitrationLoc , @LiningCondition , " & _
                        " @AreaCon , @Spalling , @SpallingDepth ,  @SpallingArea , @Remarks , @DueTo ) "
                End If
                If oCmd.ExecuteNonQuery = 1 Then Done = True
            Catch exp As Exception
                Throw New Exception("Lining  Updation failed !" & exp.Message)
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
    End Function
    Public Function RoofLifeUpdation(ByVal LT As Integer, ByVal LiningItemNo As String, ByVal LiningNo As String) As Boolean
        Dim Done As Boolean = False
        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            oCmd.Parameters.Add("@LT", SqlDbType.BigInt, 8).Value = LT
            oCmd.Parameters.Add("@LiningItemNo", SqlDbType.VarChar, 50).Value = LiningItemNo
            oCmd.Parameters.Add("@LiningNo", SqlDbType.VarChar, 50).Value = LiningNo
            oCmd.CommandText = "ms_sp_RoofLiningUpdation"
            oCmd.CommandType = CommandType.StoredProcedure
            oCmd.Connection.Open()
            If oCmd.ExecuteNonQuery > 0 Then Done = True
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            If Not IsNothing(oCmd) Then
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End If
        End Try
        Return Done
    End Function
    Public Function IDNDataDetails(ByVal IDNNo As String, ByVal ReceivedDate As Date, ByVal PresentStatus As Integer, ByVal AccQty As Decimal, ByVal RejQty As Decimal, ByVal ClearedDate As Date, ByVal LabNo As String, ByVal FileNo As String, ByVal Criteria As Integer, ByVal ClearedBy As String) As Boolean
        Dim Done As Boolean = False
        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            oCmd.Parameters.Add("@IDNNo", SqlDbType.VarChar, 50).Value = IDNNo
            oCmd.Parameters.Add("@ReceivedDate", SqlDbType.SmallDateTime, 4).Value = ReceivedDate
            oCmd.Parameters.Add("@PresentStatus", SqlDbType.Int, 4).Value = PresentStatus
            oCmd.Parameters.Add("@AccQty", SqlDbType.Decimal, 18, 3).Value = AccQty
            oCmd.Parameters.Add("@RejQty", SqlDbType.Decimal, 18, 3).Value = RejQty
            oCmd.Parameters.Add("@ClearedDate", SqlDbType.SmallDateTime, 4).Value = ClearedDate
            oCmd.Parameters.Add("@LabNo", SqlDbType.VarChar, 50).Value = LabNo
            oCmd.Parameters.Add("@FileNo", SqlDbType.VarChar, 50).Value = FileNo
            oCmd.Parameters.Add("@Criteria", SqlDbType.Int, 4).Value = Criteria
            oCmd.Parameters.Add("@ClearedBy", SqlDbType.VarChar, 50).Value = ClearedBy
            oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            oCmd.CommandText = "select @cnt = count(*) from ms_IDNDetails where IDNNo = @IDNNo and ReceivedDate = @ReceivedDate"
            oCmd.Connection.Open()
            oCmd.ExecuteScalar()
            If IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value) > 0 Then
                oCmd.CommandText = "update ms_IDNDetails set PresentStatus = @PresentStatus , AccQty = @AccQty , " & _
                    " RejQty = @RejQty , ReceivedDate = @ReceivedDate , LabNo = @LabNo , FileNo = @FileNo , " & _
                    " Criteria = @Criteria , ClearedBy = @ClearedBy where IDNNo = @IDNNo and ReceivedDate = @ReceivedDate"
            Else
                oCmd.CommandText = "insert into ms_IDNDetails ( IDNNo , ReceivedDate , PresentStatus  , AccQty  , " & _
                                    " RejQty  , ClearedDate , LabNo  , FileNo  , Criteria , ClearedBy ) values " & _
                                    " ( @IDNNo , @ReceivedDate , @PresentStatus , @AccQty , @RejQty , @ClearedDate , " & _
                                    " @LabNo ,  @FileNo , @Criteria  , @ClearedBy ) "
            End If
            If oCmd.ExecuteNonQuery > 0 Then Done = True
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            If Not IsNothing(oCmd) Then
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End If
        End Try
        Return Done
    End Function
End Class
