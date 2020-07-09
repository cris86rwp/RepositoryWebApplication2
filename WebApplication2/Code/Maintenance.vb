Namespace Maintenance
    Public Enum Types
        B
        U
        M
        P
    End Enum
    Public Class NewBDMemo
        Public Shared Function GetBDShops(ByVal BDDate As Date, ByVal group_code As String) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = " select distinct a.ShopCode , Shop_Code" & _
                    " from (" & _
                    " select distinct ShopCode , Shop_Code " & _
                    " from ms_vw_breakdown_memo" & _
                    " where breakdown_date = @BDDate " & _
                    " and machine_code in ( select machine_code from dbo.ms_fn_MachineryMaster(@shop_code,'all'))) a inner join " & _
                    " ( select distinct group_code GroupCode , location ShopCode , (description) ShopName  " & _
                    " from ms_group_location " & _
                    " where purpose = 'MSSBreakdowns' " & _
                    " and group_code = @group_code " & _
                    " ) b" & _
                    " on a.Shop_Code = b.ShopCode " & _
                    " order by a.ShopCode "
                da.SelectCommand.Parameters.Add("@BDDate", SqlDbType.SmallDateTime, 4).Value = BDDate
                da.SelectCommand.Parameters.Add("@shop_code", SqlDbType.VarChar, 10).Value = group_code
                da.SelectCommand.Parameters.Add("@group_code", SqlDbType.VarChar, 2).Value = group_code.Substring(1)
                da.Fill(ds)
                GetBDShops = ds.Tables(0).Copy
            Catch exp As Exception
                GetBDShops = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function GetBDCodeType(ByVal BDDate As Date, ByVal group_code As String, ByVal Shop_Code As String) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = " select distinct CodeType , BDCode from ms_vw_breakdown_memo " & _
                    " where breakdown_date = @BDDate " & _
                    " and machine_code in ( select machine_code from dbo.ms_fn_MachineryMaster(@group_code,@Shop_Code)) "
                da.SelectCommand.Parameters.Add("@BDDate", SqlDbType.SmallDateTime, 4).Value = BDDate
                da.SelectCommand.Parameters.Add("@group_code", SqlDbType.VarChar, 10).Value = group_code
                da.SelectCommand.Parameters.Add("@Shop_Code", SqlDbType.VarChar, 2).Value = Shop_Code
                da.Fill(ds)
                GetBDCodeType = ds.Tables(0).Copy
            Catch exp As Exception
                GetBDCodeType = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function GetBDMemoSlipNos(ByVal BDDate As Date, ByVal group_code As String, ByVal Shop_Code As String, ByVal BDCode As String) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = " select distinct memo_number MemoNo , " & _
                    " ltrim(rtrim(CONVERT(varchar(10),memo_number))) + ' - ' + CONVERT(char(10),memo_slip_number) MempSlipNo " & _
                    " from ms_vw_breakdown_memo  " & _
                    " where  shop_code  = @Shop_Code and breakdown_date = @BDDate " & _
                    " and BDCode = @BDCode " & _
                    " and machine_code in ( select machine_code from dbo.ms_fn_MachineryMaster(@group_code,@Shop_Code)) "
                da.SelectCommand.Parameters.Add("@BDDate", SqlDbType.SmallDateTime, 4).Value = BDDate
                da.SelectCommand.Parameters.Add("@Shop_Code", SqlDbType.VarChar, 2).Value = Shop_Code
                da.SelectCommand.Parameters.Add("@group_code", SqlDbType.VarChar, 10).Value = group_code
                da.SelectCommand.Parameters.Add("@BDCode", SqlDbType.VarChar, 10).Value = BDCode
                da.Fill(ds)
                GetBDMemoSlipNos = ds.Tables(0).Copy
            Catch exp As Exception
                GetBDMemoSlipNos = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function GetBDMemoSlipDetails(ByVal BDDate As Date, ByVal Shop_Code As String, ByVal memo_number As Integer) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = " select breakdown_from_time , breakdown_to_time , " & _
                    " machine_code , (c.code+'-'+rtrim(c.description)) BreakdownCode ," & _
                    " failure_nature , remarks , SubAssemblyName ,  a.maintenance_group , " & _
                    " case when production_affected = 0 then 'No' else 'Yes' end Aff ,  staff ,  work_done " & _
                    " from ms_vw_breakdown_memo a inner join ms_breakdown_details b " & _
                    " on  a.maintenance_group = b.maintenance_group and a.memo_number = b.memo_number  " & _
                    " inner join code c on c.code = b.breakdown_code  " & _
                    " inner join code_type d on d.code_type = c.code_type  and d.application = c.application  " & _
                    " where  shop_code  = @Shop_Code and breakdown_date = @BDDate " & _
                    " and a.memo_number = @memo_number "
                da.SelectCommand.Parameters.Add("@BDDate", SqlDbType.SmallDateTime, 4).Value = BDDate
                da.SelectCommand.Parameters.Add("@Shop_Code", SqlDbType.VarChar, 2).Value = Shop_Code
                da.SelectCommand.Parameters.Add("@memo_number", SqlDbType.Int, 4).Value = memo_number
                da.Fill(ds)
                GetBDMemoSlipDetails = ds.Tables(0).Copy
            Catch exp As Exception
                GetBDMemoSlipDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function GetBDMemoSlipDetails1(ByVal BDDate As Date, ByVal Shop_Code As String, ByVal memo_number As Integer) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "ms_sp_BreakDownMemoDetails"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.Add("@BDDate", SqlDbType.SmallDateTime, 4).Value = BDDate
                da.SelectCommand.Parameters.Add("@Shop_Code", SqlDbType.VarChar, 2).Value = Shop_Code
                da.SelectCommand.Parameters.Add("@memo_number", SqlDbType.Int, 4).Value = memo_number
                da.Fill(ds)
                GetBDMemoSlipDetails1 = ds.Tables(0).Copy
            Catch exp As Exception
                GetBDMemoSlipDetails1 = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function GetBDMemoSlipSparesDetails(ByVal machine_code As String, ByVal maintenance_group As String, ByVal memo_number As Integer) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "select  a.pl_number PLNumber , " & _
                    " rtrim(b.short_description) PLDescription , rtrim(UnitName) Unit , quantity Qty " & _
                    " from ms_workorder_spares a inner join pm_ItemMaster b" & _
                    " on a.pl_number = b.pl_number  " & _
                    " where workorder_number = @memo_number and  maintenance_group = @maintenance_group and  a.machine_code = @machine_code "
                da.SelectCommand.Parameters.Add("@machine_code", SqlDbType.VarChar, 50).Value = machine_code
                da.SelectCommand.Parameters.Add("@maintenance_group", SqlDbType.VarChar, 2).Value = maintenance_group
                da.SelectCommand.Parameters.Add("@memo_number", SqlDbType.Int, 4).Value = memo_number
                da.Fill(ds)
                GetBDMemoSlipSparesDetails = ds.Tables(0).Copy
            Catch exp As Exception
                GetBDMemoSlipSparesDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
    End Class
    <Serializable()> Public Class tables
        Public Shared Function Consumption(ByVal Consignee As String, ByVal Year As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = " declare @Consignee varchar(4) , @StockType varchar(20)  , @Year varchar(10) " & _
                " select @Consignee = '" & Consignee.Trim & "' , @StockType = 'Stock' , @Year = '" & Year.Trim & "'  " & _
                " select PLNumber , dbo.ms_fn_PlShortName(PLNumber) PLDesc , dbo.ms_fn_PlUnitName(PLNumber) UnitName , QtyReq  ,        " & _
                " [EAR/ES] = ( select top 1 CASE dm_item_recoupment.recoupment_type    WHEN '1' THEN 'EAR' ELSE 'ES' END + ' - ' +        " & _
                " CASE dm_item_recoupment.recoupment_type   WHEN '1' THEN convert(varchar,convert(bigint,dm_item_recoupment.ear_quantity))   ELSE convert(varchar,convert(bigint,dm_item_recoupment.emergency_stock))   END AS RecoupQty        " & _
                " FROM   wap.dbo.pm_item_master pm_item_master LEFT OUTER JOIN wap.dbo.dm_item_recoupment dm_item_recoupment        " & _
                " ON   pm_item_master.pl_number = dm_item_recoupment.pl_number AND   pm_item_master.ward = dm_item_recoupment.ward        " & _
                " AND   pm_item_master.category = dm_item_recoupment.category        " & _
                " WHERE   dm_item_recoupment.pl_number = a.PLNumber AND  pm_item_master.delete_flag = '0' ) ,  " & _
                " InStore = ( select isnull(sum(stock_quantity),0) from  dm_stock_master where PL_Number = PLNumber ) , " & _
                " [2008-09] = ( select top 1 total_issues from dm_item_master_year  b LEFT OUTER JOIN dm_item_history_merged c   " & _
                " on b.pl_number = c.pl_number AND c.ward = b.ward AND c.category = b.category AND b.pyear3 = c.year   " & _
                " where b.pl_number = a.PLNumber )   " & _
                " , [2009-10] = ( select top 1 total_issues from dm_item_master_year  b LEFT OUTER JOIN dm_item_history_merged c   " & _
                " on b.pl_number = c.pl_number AND c.ward = b.ward AND c.category = b.category AND b.pyear2 = c.year   " & _
                " where b.pl_number = a.PLNumber )   " & _
                " , [2010-11]  = ( select top 1 total_issues from dm_item_master_year  b LEFT OUTER JOIN dm_item_history_merged c   " & _
                " on b.pl_number = c.pl_number AND c.ward = b.ward AND c.category = b.category AND b.pyear1 = c.year   " & _
                " where b.pl_number = a.PLNumber )  " & _
                " , [2011-12] = ( select top 1 (ytm_issues + mtd_issues) from dm_stock_master where pl_number = a.PLNumber )    " & _
                " from ms_MaterialRequirement  a  inner join  ms_vw_PLConsumption b    " & _
                " on b.pl_number = a.PLNumber  where Consignee = @Consignee " & _
                " and  dbo.ms_fn_PlType(plnumber) = substring(ltrim(rtrim(@StockType)),1,1) " & _
                " and isnull(DeleteStatus,'') = 0   and Year = @Year "
                da.Fill(ds)
                Consumption = ds.Tables(0).Copy
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function POItemList(ByVal Consignee As String, ByVal Year As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "ms_sp_MaterialRequirementPOItemList"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = Consignee
                da.SelectCommand.Parameters.Add("@StockType", SqlDbType.VarChar, 12).Value = "Non-Stock"
                da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar, 10).Value = Year
                da.Fill(ds)
                POItemList = ds.Tables(0).Copy
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function ItemListStatus(ByVal Consignee As String, ByVal Year As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "ms_sp_MaterialRequirementItemListStatus"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = Consignee
                da.SelectCommand.Parameters.Add("@StockType", SqlDbType.VarChar, 12).Value = "Non-Stock"
                da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar, 10).Value = Year
                da.Fill(ds)
                ItemListStatus = ds.Tables(0).Copy
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function StockItemsLatestStage(ByVal Consignee As String, ByVal Year As String, ByVal Type As Integer) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "ms_sp_MaterialRequirementStockItemsLatestStage"
                da.SelectCommand.CommandType = CommandType.StoredProcedure

                da.SelectCommand.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = Consignee
                da.SelectCommand.Parameters.Add("@StockType", SqlDbType.VarChar, 12).Value = "Stock"
                da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar, 10).Value = Year
                da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = Type

                da.Fill(ds)
                StockItemsLatestStage = ds.Tables(0).Copy
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function GetPLDetails(ByVal PLNumber As String) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                If PLNumber = "ALL" Then
                    da.SelectCommand.CommandText = " select pl_number , PlDesc , ReCoupDate , RecoupType , RecoupQty , " & _
                        " UnitName , ExistingQty , QtyDesc , QtyReq , Remarks  from ms_vw_PLRecoupmentDetails " & _
                        " order by pl_number , ReqDate desc "
                Else
                    da.SelectCommand.CommandText = " select pl_number , PlDesc , ReCoupDate , RecoupType , RecoupQty , " & _
                        " UnitName , ExistingQty , QtyDesc , QtyReq , Remarks  from ms_vw_PLRecoupmentDetails " & _
                        " where pl_number = '" & PLNumber.Trim & "' order by pl_number , ReqDate desc "
                End If
                da.Fill(ds)
                GetPLDetails = ds.Tables(0).Copy
            Catch exp As Exception
                GetPLDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function GetPLList() As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = " select distinct pl_number from ms_vw_PLRecoupmentDetails order by pl_number "
                da.Fill(ds)
                GetPLList = ds.Tables(0).Copy
            Catch exp As Exception
                GetPLList = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function GetMachineData(ByVal FrDt As Date, ByVal ToDt As Date, Optional ByVal Machine As String = "") As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@FrDt", SqlDbType.SmallDateTime, 4).Value = FrDt
                da.SelectCommand.Parameters.Add("@ToDt", SqlDbType.SmallDateTime, 4).Value = ToDt
                If Machine.Trim.Length > 0 Then
                    da.SelectCommand.CommandText = " select * from dbo.ms_fn_BreakdownAnalysisMachineWise(@FrDt,@ToDt ) " & _
                        " where machine_code like @Machine "
                    da.SelectCommand.Parameters.Add("@Machine", SqlDbType.VarChar, 50).Value = Machine + "%"
                Else
                    da.SelectCommand.CommandText = " select * from dbo.ms_fn_BreakdownAnalysisMachineWise(@FrDt,@ToDt ) "
                End If

                da.Fill(ds)
                GetMachineData = ds.Tables(0).Copy
            Catch exp As Exception
                GetMachineData = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function PopulateMachine(ByVal grp As String, ByVal shop As String) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = " select distinct rtrim(dbo.ms_fn_MachineShortName(a.machine_code))+' - '+ ltrim(rtrim(a.machine_code)) MachineDesc  , a.machine_code MachineCode  " & _
                        " from (select machine_code from dbo.ms_fn_MachineryMaster('" & grp & "','" & shop & "')) a inner join ms_breakdown_memo b  " & _
                        " on a.machine_code = b.machine_code " & _
                        " order by rtrim(dbo.ms_fn_MachineShortName(a.machine_code))+' - '+ ltrim(rtrim(a.machine_code))  , a.machine_code "
                da.Fill(ds)
                PopulateMachine = ds.Tables(0).Copy
            Catch exp As Exception
                PopulateMachine = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function PopulateLocationType(ByVal Maintenance_group As String) As DataSet
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = " select distinct location , description  from ms_group_location  " & _
                    " where group_code = '" & Maintenance_group & "' and purpose = 'MSSMaintenance' ;  " & _
                    " select distinct b.description from code a inner join code_type b on a.application = b.application and a.code_type = b.code_type  " & _
                    " where a.application = rtrim('MS')  and  b.code_type like 'BD%' "
                da.Fill(ds)
                PopulateLocationType = ds.Copy
            Catch exp As Exception
                PopulateLocationType = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function BreakDownMaintenaceSummary(ByVal grp As String, ByVal FrDt As Date, ByVal ToDt As Date, ByVal Location As String, ByVal MachineCode As String, ByVal ddlType As String, ByVal Production As String, ByVal Time As Integer) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@GroupCode", SqlDbType.VarChar, 50).Value = grp
                da.SelectCommand.Parameters.Add("@frdt", SqlDbType.SmallDateTime, 4).Value = FrDt
                da.SelectCommand.Parameters.Add("@todt", SqlDbType.SmallDateTime, 4).Value = ToDt
                da.SelectCommand.Parameters.Add("@location", SqlDbType.VarChar, 10).Value = Location
                da.SelectCommand.Parameters.Add("@Machine", SqlDbType.VarChar, 10).Value = MachineCode
                da.SelectCommand.Parameters.Add("@sub_assembly", SqlDbType.VarChar, 10).Value = "ALL"
                da.SelectCommand.Parameters.Add("@maintenance_type", SqlDbType.VarChar, 10).Value = ddlType
                da.SelectCommand.Parameters.Add("@production_affected", SqlDbType.VarChar, 1).Value = Production
                da.SelectCommand.Parameters.Add("@TimeLoss", SqlDbType.Int, 4).Value = Time
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.CommandText = "ms_sp_BreakDownMaintenaceSummary"
                da.Fill(ds)
                BreakDownMaintenaceSummary = ds.Tables(0).Copy
            Catch exp As Exception
                BreakDownMaintenaceSummary = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function MachineDetails(ByVal Machine As String) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Dim dt As DataTable
            da.SelectCommand.Parameters.Add("@machine_code", SqlDbType.VarChar, 50).Value = Machine
            da.SelectCommand.CommandText = " select  location_code , equipment_code ,  " &
                        " description , machine_group , am_basedate , manufacturer , " &
                        " model_name ,  supplier_code , po_number , po_date , original_cost , " &
                        " inservice_date , warranty_from , warranty_to , user_id  " &
                        " from ms_machinery_master where machine_code = @machine_code "
            Try
                da.Fill(ds)
                dt = ds.Tables(0).Copy
            Catch exp As Exception
                dt = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dt
        End Function


        Public Shared Function MachineCodeName(ByVal Machine As String) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Dim dt As DataTable
            da.SelectCommand.Parameters.Add("@machine_code", SqlDbType.VarChar, 50).Value = Machine
            da.SelectCommand.CommandText = " select   description , serial_number  from ms_machinery_master where machine_code = @machine_code "

            Try
                da.Fill(ds)
                dt = ds.Tables(0).Copy
            Catch exp As Exception
                dt = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dt
        End Function
        Public Shared Function SparesInStore(ByVal InStore As Int16, ByVal lblGrp As String) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            If InStore = 0 Then
                da.SelectCommand.CommandText = " select *  from ms_vw_SparesInStore where InStore = 0 and machine_group = @Group  order by pl_number "
            Else
                da.SelectCommand.CommandText = " select *  from ms_vw_SparesInStore where InStore > 0 and machine_group = @Group  order by pl_number "
            End If
            Try
                da.SelectCommand.Parameters.Add("@Group", SqlDbType.VarChar, 10).Value = lblGrp.Trim
                da.Fill(ds)
                SparesInStore = ds.Tables(0)
            Catch exp As Exception
                SparesInStore = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function BreakDownMaintenaceElecCranes(ByVal FromDate As Date, ByVal ToDate As Date) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.CommandText = "ms_sp_BreakDownMaintenaceElecCranes"
                da.SelectCommand.Parameters.Add("@GroupCode", SqlDbType.VarChar, 50).Value = "EAC"
                da.SelectCommand.Parameters.Add("@frdt", SqlDbType.SmallDateTime, 4).Value = FromDate
                da.SelectCommand.Parameters.Add("@todt", SqlDbType.SmallDateTime, 4).Value = ToDate
                da.SelectCommand.Parameters.Add("@location", SqlDbType.VarChar, 10).Value = "ALL"
                da.SelectCommand.Parameters.Add("@Machine", SqlDbType.VarChar, 10).Value = "ALL"
                da.SelectCommand.Parameters.Add("@maintenance_type", SqlDbType.VarChar, 10).Value = "ALL"
                da.Fill(ds)
                BreakDownMaintenaceElecCranes = ds.Tables(0)
            Catch exp As Exception
                BreakDownMaintenaceElecCranes = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function BreakDownMaintenaceDetailsWithPercent(ByVal Grp As String, ByVal FromDate As Date, ByVal ToDate As Date, ByVal Location As String, ByVal sub_assembly As String, ByVal maintenance_type As String, ByVal production_affected As String, ByVal TimeLoss As Integer, ByVal WorkingDays As Integer) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.CommandText = "ms_sp_BreakDownMaintenaceDetailsWithPercent"
                da.SelectCommand.Parameters.Add("@GroupCode", SqlDbType.VarChar, 50).Value = Grp
                da.SelectCommand.Parameters.Add("@frdt", SqlDbType.SmallDateTime, 4).Value = FromDate
                da.SelectCommand.Parameters.Add("@todt", SqlDbType.SmallDateTime, 4).Value = ToDate
                da.SelectCommand.Parameters.Add("@location", SqlDbType.VarChar, 10).Value = Location
                da.SelectCommand.Parameters.Add("@Machine", SqlDbType.VarChar, 10).Value = sub_assembly
                da.SelectCommand.Parameters.Add("@sub_assembly ", SqlDbType.VarChar, 50).Value = CStr("ALL")
                da.SelectCommand.Parameters.Add("@maintenance_type", SqlDbType.VarChar, 10).Value = maintenance_type
                da.SelectCommand.Parameters.Add("@production_affected", SqlDbType.VarChar, 1).Value = production_affected
                da.SelectCommand.Parameters.Add("@TimeLoss", SqlDbType.Int, 4).Value = TimeLoss
                da.SelectCommand.Parameters.Add("@WorkingDays", SqlDbType.Float, 8).Value = WorkingDays
                da.Fill(ds)
                BreakDownMaintenaceDetailsWithPercent = ds.Tables(0)
            Catch exp As Exception
                BreakDownMaintenaceDetailsWithPercent = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function PopulateReportLocation(ByVal Maintenance_group As String)
            Dim strsql As String
            strsql = " select distinct location , description  from ms_group_location  "
            strsql &= " where group_code = '" & Maintenance_group.Trim & "' and purpose = 'MSSMaintenance' "
            'strsql = "select code,(code+'-'+description) as Location from code where application='MS' and code_type='LC' "
            'strsql = "  select distinct  user_id , location_code  from ms_machinery_master "
            'strsql &= " where isnull(user_id,'') <> '' and user_id =  '" & grp.Trim & "' "
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = strsql
            Try
                da.Fill(ds)
                PopulateReportLocation = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetTop3BkDMachineList(Optional ByVal Search As String = "") As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                If Search.StartsWith("M") Then
                    da.SelectCommand.CommandText = " select a.machine_code, b.description from ms_MachinesForTop3BdQry a inner join ms_machinery_master b on a.machine_code = b.machine_code where a.selected = 1 order by b.description "
                Else
                    da.SelectCommand.CommandText = " select a.machine_code, b.description from ms_MachinesForTop3BdQry a inner join ms_machinery_master b on a.machine_code = b.machine_code where a.selected = 1 order by b.description "
                End If
                da.Fill(ds)
                GetTop3BkDMachineList = ds.Tables(0)
            Catch exp As Exception
                GetTop3BkDMachineList = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetPLListValues(ByVal pl_number As String, ByVal Group As String, ByVal Type As String, ByVal Machine As String, Optional ByVal SubAssembly As String = "") As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                If Type.StartsWith("M") Then
                    da.SelectCommand.CommandText = " select * , dbo.ms_fn_PlUnitName(a.pl_number) Unit from ms_machine_spares a inner join pm_item_master b on a.pl_number = b.pl_number  and b.ward <> '26' where  a.pl_number = '" & pl_number & "' and a.machine_code = '" & Machine & "' and a.machine_group = '" & Group.Trim & "' "
                Else
                    da.SelectCommand.CommandText = " select * , dbo.ms_fn_PlUnitName(a.pl_number) Unit from ms_SubAssembly_spares a inner join pm_item_master b on a.pl_number = b.pl_number  and b.ward <> '26' where a.pl_number = '" & pl_number & "' and  a.ParentMachineCode = '" & Machine & "' and a.SubAssemblyCode = '" & SubAssembly.Trim & "' and a.machine_group = '" & Group.Trim & "' "
                End If
                da.Fill(ds)
                GetPLListValues = ds.Tables(0)
            Catch exp As Exception
                GetPLListValues = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetPLList(ByVal Group As String, ByVal Type As String, ByVal Machine As String, Optional ByVal SubAssembly As String = "") As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                If Type.StartsWith("M") Then
                    da.SelectCommand.CommandText = " select distinct rtrim(a.pl_number)+'--'+ rtrim(ltrim(short_description)) , a.pl_number from ms_machine_spares a inner join pm_item_master b on a.pl_number = b.pl_number  and b.ward <> '26' where  a.machine_code = '" & Machine & "' and a.machine_group = '" & Group.Trim & "' "
                Else
                    da.SelectCommand.CommandText = " select distinct rtrim(a.pl_number)+'--'+ rtrim(ltrim(short_description)) , a.pl_number from ms_SubAssembly_spares a inner join pm_item_master b on a.pl_number = b.pl_number  and b.ward <> '26' where  a.ParentMachineCode = '" & Machine & "' and a.SubAssemblyCode = '" & SubAssembly.Trim & "' and a.machine_group = '" & Group.Trim & "' "
                End If
                da.Fill(ds)
                GetPLList = ds.Tables(0)
            Catch exp As Exception
                GetPLList = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetRTShopMachineList() As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = " select distinct rtrim(a.machine_code) + '--'+ ltrim(rtrim(description)) ,  a.machine_code from ms_machinery_master a where a.user_id = 'mrt' "
                da.Fill(ds)
                GetRTShopMachineList = ds.Tables(0)
            Catch exp As Exception
                GetRTShopMachineList = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetMachineList(ByVal Group As String, ByVal Type As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                If Type.StartsWith("M") Then
                    da.SelectCommand.CommandText = " select distinct rtrim(a.machine_code) + '--'+ ltrim(rtrim(description)) ,  a.machine_code from ms_machine_spares a inner join ms_machinery_master b on b.machine_code = a.machine_code where a.machine_group = '" & Group.Trim & "' "
                Else
                    da.SelectCommand.CommandText = " select distinct ParentMachineCode +'-'+ ltrim(rtrim(SubAssemblyCode)) + '--' + ltrim(rtrim(b.description)) , ParentMachineCode +'-'+ ltrim(rtrim(SubAssemblyCode)) from ms_SubAssembly_spares a inner join ms_subassembly b " & _
                            " on b.code = a.SubAssemblyCode and b.parent_equipment_code = a.ParentMachineCode and b.employee_code = a.machine_group " & _
                            " inner join ms_machinery_master c on c.machine_code = a.ParentMachineCode   where a.machine_group = '" & Group.Trim & "' "
                End If
                da.Fill(ds)
                GetMachineList = ds.Tables(0)
            Catch exp As Exception
                GetMachineList = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function

        Public Shared Function GetUnScheduledEntryMachines(ByVal Group As String, ByVal Location As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select distinct a.machine_code,(rtrim(a.machine_code) + ' - ' + dbo.ms_fn_MachineShortName(a.machine_code)) as desc1 " & _
                            " from ms_unscheduled_entry a inner join dbo.ms_fn_MachineryMaster('" & Group.Trim & "','" & Trim(Location) & "') b " & _
                            " on a.machine_code = b.machine_code order by a.machine_code "
            Try
                da.Fill(ds)
                GetUnScheduledEntryMachines = ds.Tables(0)
            Catch exp As Exception
                GetUnScheduledEntryMachines = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function PopulateSubAssembly(ByVal MachineCode As String) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select code , (ltrim(rtrim(code))+'-'+description) as description , parent_equipment_code , employee_code from ms_subassembly where parent_equipment_code like '" & Trim(MachineCode) & "'  ORDER BY substring(parent_equipment_code,2,8) "
            Try
                da.Fill(ds)
                PopulateSubAssembly = ds.Tables(0).Copy
            Catch exp As Exception
                PopulateSubAssembly = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function PopulateMachineCode(ByVal Location As String) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            If Location.Trim <> "ALL" Then
                da.SelectCommand.CommandText = "select machine_code,(rtrim(machine_code) + ' - ' + description) as desc1 from ms_machinery_master where machine_code LIKE '" & Left(Location.Trim, 2) & "%'"
            Else
                da.SelectCommand.CommandText = "select machine_code,(rtrim(machine_code) + ' - ' + description) as desc1 from ms_machinery_master"
            End If

            Try
                da.Fill(ds)
                PopulateMachineCode = ds.Tables(0).Copy
            Catch exp As Exception
                PopulateMachineCode = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function PopulateLocation() As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " exec ms_GetMsCode'LC' "
            Try
                da.Fill(ds)
                PopulateLocation = ds.Tables(0).Copy
            Catch exp As Exception
                PopulateLocation = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function GetMachinePLs(ByVal Group As String, ByVal Location As String) As DataTable
            Dim strsql As String
            strsql = " select distinct pl_number , ltrim(rtrim(pl_number))+'--'+rtrim(dbo.ms_fn_PlShortName(pl_number)) Des from ms_vw_MachineSubAssembly_spares_details  "
            strsql &= " where machine_group = '" & Group.Trim & "' "
            If Location = "ALL" Then
            Else
                strsql &= " and  MachineCode like '" & Trim(Location) & "%' ORDER BY pl_number  "
            End If
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = strsql
            Try
                da.Fill(ds)
                GetMachinePLs = ds.Tables(0)
            Catch exp As Exception
                GetMachinePLs = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetMachineCodes(ByVal Group As String, ByVal Location As String) As DataTable
            Dim strsql As String
            strsql = " select distinct machinecode , ltrim(rtrim(machinecode))+'-'+ dbo.ms_fn_MachineShortName(machinecode) from ms_vw_MachineSubAssembly_spares_details "
            strsql &= " where machine_group = '" & Group.Trim & "' "
            If Location = "ALL" Then
            Else
                strsql &= " and  MachineCode like '" & Trim(Location) & "%' ORDER BY MachineCode  "
            End If
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = strsql
            Try
                da.Fill(ds)
                GetMachineCodes = ds.Tables(0)
            Catch exp As Exception
                GetMachineCodes = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetLocation(ByVal Group As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select distinct location , description  from ms_group_location  " & _
                        " where group_code = @Group and purpose = 'MSSMaintenance' "
            Try
                da.SelectCommand.Parameters.Add("@Group", SqlDbType.VarChar, 8).Value = Group.Trim
                da.Fill(ds)
                GetLocation = ds.Tables(0)
            Catch exp As Exception
                GetLocation = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function CheckSubAssemblySpare(ByVal Group As String, ByVal MachineCode As String) As Integer
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@Cnt", SqlDbType.Int, 4)
            cmd.Parameters("@Cnt").Direction = ParameterDirection.Output
            cmd.CommandText = "select @Cnt = count(*)  from ms_subassembly where parent_equipment_code = @MachineCode and employee_code = @Group "
            Try
                cmd.Parameters.Add("@Group", SqlDbType.VarChar, 50).Value = Group.Trim
                cmd.Parameters.Add("@MachineCode", SqlDbType.VarChar, 50).Value = MachineCode.Trim
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.ExecuteScalar()
                CheckSubAssemblySpare = IIf(IsDBNull(cmd.Parameters("@Cnt").Value), 0, cmd.Parameters("@Cnt").Value)
            Catch exp As Exception
                CheckSubAssemblySpare = False
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
            End Try
        End Function
        Public Shared Function GetPlDesc(ByVal PlNumber As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select  a.short_description PlDesc ,   b.description PlUnit from pm_item_Master  a , code b " & _
                        " where a.ward <> '26' and a.pl_number = @PlNumber  and b.code_type = 'UT' " & _
                        " and b.application = 'PM' and b.code = a.uom "

            Try
                da.SelectCommand.Parameters.Add("@PlNumber", SqlDbType.VarChar, 8).Value = PlNumber.Trim
                da.Fill(ds)
                GetPlDesc = ds.Tables(0)
            Catch exp As Exception
                GetPlDesc = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function CheckPls(ByVal TableName As String, ByVal Group As String, ByVal PlNumber As String, ByVal ParentMachineCode As String, ByVal SubAssemblyCode As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@machine_group", SqlDbType.VarChar, 20)
            da.SelectCommand.Parameters("@machine_group").Direction = ParameterDirection.Input
            da.SelectCommand.Parameters.Add("@pl", SqlDbType.VarChar, 8)
            da.SelectCommand.Parameters("@pl").Direction = ParameterDirection.Input
            da.SelectCommand.Parameters.Add("@ParentMachineCode", SqlDbType.VarChar, 8)
            da.SelectCommand.Parameters("@ParentMachineCode").Direction = ParameterDirection.Input
            da.SelectCommand.Parameters.Add("@SubAssemblyCode", SqlDbType.VarChar, 50)
            da.SelectCommand.Parameters("@SubAssemblyCode").Direction = ParameterDirection.Input
            da.SelectCommand.Parameters.Add("@Cnt", SqlDbType.Int, 4)
            da.SelectCommand.Parameters("@Cnt").Direction = ParameterDirection.Output
            Try
                da.SelectCommand.Parameters("@machine_group").Value = Trim(Group.ToUpper)
                da.SelectCommand.Parameters("@pl").Value = Trim(PlNumber.Trim)
                da.SelectCommand.Parameters("@ParentMachineCode").Value = ParentMachineCode.Trim
                da.SelectCommand.Parameters("@SubAssemblyCode").Value = SubAssemblyCode.Trim
                If TableName.Trim = "SaveSubAssemblyPLs" Then
                    da.SelectCommand.CommandText = " select dbo.ms_fn_PlShortName(pl_number) PlShortName , dbo.ms_fn_PlUnitName(pl_number) PlUnitName   ,  count(*) Cnt from  ms_SubAssembly_spares  " & _
                            " where pl_number = @pl  and ParentMachineCode = @ParentMachineCode  and SubAssemblyCode = @SubAssemblyCode  and machine_group = @machine_group group by pl_number "
                Else
                    da.SelectCommand.CommandText = " select dbo.ms_fn_PlShortName(pl_number) PlShortName , dbo.ms_fn_PlUnitName(pl_number) PlUnitName   ,  count(*) Cnt from  ms_machine_spares " & _
                           " where pl_number = @pl  and Machine_Code = @ParentMachineCode  and  machine_group = @machine_group group by pl_number "
                End If
                da.Fill(ds)
                CheckPls = ds.Tables(0)
            Catch exp As Exception
                CheckPls = Nothing
                Throw New Exception(exp.Message)
            End Try
        End Function
        Public Shared Function PopulateSubAssembly(ByVal Group As String, ByVal MachineCode As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select code,(code+'-'+description) as description from ms_subassembly where parent_equipment_code = '" & Trim(MachineCode) & "' and  employee_code = '" & Group.ToUpper.Trim & "' "
            'strsql = " select machine_code , (machine_code+'-'+description) as Description from ms_machinery_master where machine_code like '" & Trim(cboLocation.SelectedItem.Text) & "%' ORDER BY substring(machine_code,2,8) "
            'strsql &= "(select distinct(machine_code) from ms_breakdown_memo where shop_code='" & Trim(cboLocation.SelectedItem.Value) & "')"
            Try
                da.Fill(ds)
                PopulateSubAssembly = ds.Tables(0).Copy
            Catch exp As Exception
                PopulateSubAssembly = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function PopulateSparesGrid(ByVal blnIsSubAssembly As Boolean, ByVal Group As String, ByVal MachineCode As String) As DataSet
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Dim strGrid As String
            If blnIsSubAssembly Then
                strGrid = " select  ParentMachineCode MachineCode , SubAssemblyCode , pl_number PLNumber , dbo.ms_fn_PlShortName(pl_number) PLDesc , qtyreqd ReqQty , purpose Purpose , dbo.ms_fn_PlUnitName(pl_number) PlUnitName  from ms_SubAssembly_spares "
                strGrid &= " where ParentMachineCode = '" & MachineCode.Trim & "' and machine_group = '" & Group.Trim & "' order by ParentMachineCode , pl_number "
            Else
                strGrid = " select  MachineCode , SubAssemblyCode , pl_number PLNumber , dbo.ms_fn_PlShortName(pl_number) PLDesc , qtyreqd ReqQty , purpose Purpose , dbo.ms_fn_PlUnitName(pl_number) PlUnitName  from ms_vw_MachineSubAssembly_spares_details "
                strGrid &= " where MachineCode = '" & MachineCode.Trim & "' and  machine_group = '" & Group.Trim & "'  and SubAssemblyCode = '0' order by MachineCode , pl_number "
            End If
            da.SelectCommand.CommandText = strGrid
            Try
                da.Fill(ds)
                PopulateSparesGrid = ds.Copy
            Catch exp As Exception
                PopulateSparesGrid = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function PopulateSparesGrid2(ByVal Location As String, ByVal MachineGroup As String, ByVal Group As String, ByVal index As Int16) As DataSet
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Dim strGrid As String
            If index = 0 Then
                strGrid = " select MachineCode , SubAssemblyCode , pl_number PLNumber , dbo.ms_fn_PlShortName(pl_number) PLDesc  , qtyreqd ReqQty , purpose Purpose , dbo.ms_fn_PlUnitName(pl_number) PlUnitName from ms_vw_MachineSubAssembly_spares_details "
                strGrid &= " where SubAssemblyCode = '0' and MachineCode like '" & Location.Trim & "" & MachineGroup.Trim & "%' and  machine_group = '" & Group.Trim & "' order by MachineCode , SubAssemblyCode , pl_number  "
            Else
                strGrid = " select MachineCode , SubAssemblyCode , pl_number PLNumber , dbo.ms_fn_PlShortName(pl_number) PLDesc  , qtyreqd ReqQty , purpose Purpose , dbo.ms_fn_PlUnitName(pl_number) PlUnitName from ms_vw_MachineSubAssembly_spares_details "
                strGrid &= " where SubAssemblyCode <> '0' and MachineCode like '" & Location.Trim & "" & MachineGroup.Trim & "%' and  machine_group = '" & Group.Trim & "' order by MachineCode , SubAssemblyCode , pl_number  "
            End If
            da.SelectCommand.CommandText = strGrid
            Try
                da.Fill(ds)
                PopulateSparesGrid2 = ds.Copy
            Catch exp As Exception
                PopulateSparesGrid2 = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function PopulateGrid(ByVal radParent As Int16, ByVal Group As String, ByVal MachineGroup As String, ByVal Location As String, ByVal MachineCode As String) As DataSet
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            If radParent = 0 Then
                da.SelectCommand.CommandText = " select parent_equipment_code , code SubAssemblyCode , description , parent_flag , employee_code from ms_subassembly where isnull(parent_flag,'') <> '' and isnull(employee_code,'') <> ''  " & _
                            " and parent_equipment_code = '" & MachineCode.Trim & "' and  employee_code = '" & Group.Trim & "' order by parent_equipment_code , code"
            ElseIf radParent = 1 Then
                da.SelectCommand.CommandText = " select parent_equipment_code , code SubAssemblyCode , description , parent_flag , employee_code from ms_subassembly where isnull(parent_flag,'') <> '' and isnull(employee_code,'') <> ''  " & _
                            " and parent_equipment_code like '" & Location.Trim & "" & MachineGroup.Trim & "%' and  employee_code = '" & Group.Trim & "' order by parent_equipment_code , code"
            End If
            Try
                da.Fill(ds)
                PopulateGrid = ds.Copy
            Catch exp As Exception
                PopulateGrid = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function PopulateSubAssemblyList(ByVal Location As String, ByVal MachineGroup As String, Optional ByVal Group As String = "") As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            If Group.Trim.Length > 0 Then
                da.SelectCommand.CommandText = " select code , (ltrim(rtrim(code))+'-'+description) as description , parent_equipment_code , employee_code from ms_subassembly where parent_equipment_code like '" & Trim(Location) & "" & MachineGroup.Trim & "%'  and employee_code = '" & Group.Trim & "'  ORDER BY substring(parent_equipment_code,2,8) "
            Else
                da.SelectCommand.CommandText = " select code , (ltrim(rtrim(code))+'-'+description) as description , parent_equipment_code , employee_code from ms_subassembly where parent_equipment_code like '" & Trim(Location) & "" & MachineGroup.Trim & "%'  ORDER BY substring(parent_equipment_code,2,8) "
            End If

            'strsql = " select machine_code , (machine_code+'-'+description) as Description from ms_machinery_master where machine_code like '" & Trim(cboLocation.SelectedItem.Text) & "%' ORDER BY substring(machine_code,2,8) "
            'strsql &= "(select distinct(machine_code) from ms_breakdown_memo where shop_code='" & Trim(cboLocation.SelectedItem.Value) & "')"
            Try
                da.Fill(ds)
                PopulateSubAssemblyList = ds.Tables(0).Copy
            Catch exp As Exception
                PopulateSubAssemblyList = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function PopulateMachineCode(ByVal Location As String, ByVal MachineGroup As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select machine_code , (machine_code+'-'+description) as Description from ms_machinery_master where machine_code like '" & Trim(Location) & "%'  ORDER BY substring(machine_code,2,8) "
            'da.SelectCommand.CommandText = " select machine_code , (machine_code+'-'+description) as Description from ms_machinery_master where machine_code like '" & Trim(Location) & "" & MachineGroup.Trim & "%'  ORDER BY substring(machine_code,2,8) "
            ''strsql = " select machine_code , (machine_code+'-'+description) as Description from ms_machinery_master where machine_code like '" & Trim(cboLocation.SelectedItem.Text) & "%' ORDER BY substring(machine_code,2,8) "
            'strsql &= "(select distinct(machine_code) from ms_breakdown_memo where shop_code='" & Trim(cboLocation.SelectedItem.Value) & "')"
            Try
                da.Fill(ds)
                PopulateMachineCode = ds.Tables(0).Copy
            Catch exp As Exception
                PopulateMachineCode = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function PopulateMachineGroup(ByVal Location As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select code , ltrim(rtrim(code))+'---'+description CodeDesc  from dbo.ms_fn_getMsCodes('ms','mt') " & _
                     " where  code in ( select distinct equipment_code from ms_machinery_master " & _
                     " where machine_code like '" & Trim(Location) & "%' ) order by code "
            Try
                da.Fill(ds)
                PopulateMachineGroup = ds.Tables(0).Copy
            Catch exp As Exception
                PopulateMachineGroup = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function PopulateLocation(ByVal UserId As String) As DataSet
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select distinct location , description  from ms_group_location where purpose = 'MSSMaintenance'  " &
                        " and group_code = (select  case when group_code = 'RTSHOP' then 'RT' else substring(group_code,2,2) end " &
                        " from wap.dbo.menu_your_password_new where employee_code = '" & UserId.Trim & "' and application = 'MSS' and group_code not in ('MWSSE','SUBSTO') )" &
                        " ; select case when group_code = 'RTSHOP' then 'MRT' else group_code  end " &
                        " from wap.dbo.menu_your_password_new where employee_code = '" & UserId.Trim & "' and application = 'MSS' and group_code not in ('MWSSE','SUBSTO')  "
            Try
                da.Fill(ds)
                PopulateLocation = ds.Copy
            Catch exp As Exception
                PopulateLocation = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function populateMachineCodeDetails(ByVal MachineCode As String) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select * from ms_machinery_master where machine_code = '" & MachineCode.Trim & "' "
            Try
                da.Fill(ds, "MachineCodeDetails")
                populateMachineCodeDetails = ds.Tables("MachineCodeDetails")
            Catch exp As Exception
                populateMachineCodeDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function populateSublocations(ByVal LocationCode As String) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select code from code where code_type = '" & LocationCode.Trim & "' and application = 'MS' "
            Try
                da.Fill(ds, "populateSublocations")
                populateSublocations = ds.Tables("populateSublocations")
            Catch exp As Exception
                populateSublocations = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function CheckMachineCode(ByVal mcode As String) As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@Cnt", SqlDbType.Int, 4)
            cmd.Parameters("@Cnt").Direction = ParameterDirection.Output
            cmd.CommandText = " select count(machine_code) from ms_machinery_master where machine_code = @mcode  "
            Try
                cmd.Parameters.Add("@mcode", SqlDbType.VarChar, 50).Value = mcode.Trim
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.ExecuteScalar()
                CheckMachineCode = IIf(IsDBNull(cmd.Parameters("@Cnt").Value), 0, cmd.Parameters("@Cnt").Value)
            Catch exp As Exception
                CheckMachineCode = False
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
            End Try
        End Function
        Public Shared Function PopulateListBoxes() As DataSet
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " exec ms_GetMsCode'LC' ; exec ms_GetMsCode'MT' ; exec ms_GetMsCode'MG' ; exec sp_GetApplicationGroups'MSS' ; exec sp_GetMachineCode"
            Try
                da.Fill(ds)
                PopulateListBoxes = ds.Copy
            Catch exp As Exception
                PopulateListBoxes = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function GetMachineModifiedSubAssemblyList(ByVal Mode As String, ByVal Machine As String, Optional ByVal grp As String = "", Optional ByVal ShopCode As String = "") As DataTable
            Dim dtMachineModifiedSubAssembly As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            If Mode = "add" Then
                da.SelectCommand.CommandText = " select code,(code+'-'+description) as description from ms_subassembly " & _
                        " where parent_equipment_code = '" & Trim(Machine) & "' and  employee_code = '" & grp.Trim & "' "
            Else
                da.SelectCommand.CommandText = " select ms_subassembly.code as code , (ms_subassembly.code+'-'+ms_subassembly.description) as description " & _
                        " from ms_subassembly, ms_machine_modifications where machine_code = parent_equipment_code and code = sub_assembly " & _
                        " and location = '" & Trim(ShopCode) & "' and machine_code = '" & Trim(Machine) & "' "
            End If

            Try
                da.Fill(ds, "MachineModifiedSubAssembly")
                dtMachineModifiedSubAssembly = ds.Tables("MachineModifiedSubAssembly")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtMachineModifiedSubAssembly
        End Function
        Public Shared Function GetUnSchSubAssemblyList(ByVal Mode As String, ByVal Machine As String, Optional ByVal grp As String = "", Optional ByVal ShopCode As String = "") As DataTable
            Dim dtUnSchSubAssembly As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            'If Mode = "add" Then
            '    da.SelectCommand.CommandText = " select code,(code+'-'+description) as description from ms_subassembly " & _
            '            " where parent_equipment_code = '" & Trim(Machine) & "' and  employee_code = '" & grp.Trim & "' "
            'Else
            '    da.SelectCommand.CommandText = " select ms_subassembly.code as code , (ms_subassembly.code+'-'+ms_subassembly.description) as description " & _
            '            " from ms_subassembly, ms_unscheduled_entry where machine_code = parent_equipment_code and code = sub_assembly " & _
            '            " and location = '" & Trim(ShopCode) & "' and machine_code = '" & Trim(Machine) & "' "
            'End If
            da.SelectCommand.CommandText = " select code,(code+'-'+description) as description from ms_subassembly " &
                                    " where parent_equipment_code = '" & Trim(Machine) & "' and  employee_code = '" & grp.Trim & "' "
            Try
                da.Fill(ds, "UnSchSubAssembly")
                dtUnSchSubAssembly = ds.Tables("UnSchSubAssembly")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtUnSchSubAssembly
        End Function

        Public Shared Function GetPMSchSubAssemblyList(ByVal Mode As String, ByVal Machine As String, Optional ByVal grp As String = "", Optional ByVal ShopCode As String = "") As DataTable
            Dim dtUnSchSubAssembly As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            If Mode = "add" Then
                da.SelectCommand.CommandText = " select code,(code+'-'+description) as description from ms_subassembly " &
                        " where parent_equipment_code = '" & Trim(Machine) & "' and  employee_code = '" & grp.Trim & "' "
            Else
                da.SelectCommand.CommandText = " select ms_subassembly.code as code , (ms_subassembly.code+'-'+ms_subassembly.description) as description " &
                        " from ms_subassembly, ms_preventiveMaintenance where machine_code = parent_equipment_code and code = sub_assembly " &
                        " and location = '" & Trim(ShopCode) & "' and machine_code = '" & Trim(Machine) & "' "
            End If
            'da.SelectCommand.CommandText = " select code,(code+'-'+description) as description from ms_subassembly " & _
            '                        " where parent_equipment_code = '" & Trim(Machine) & "' and  employee_code = '" & grp.Trim & "' "
            Try
                da.Fill(ds, "PMSchSubAssembly")
                dtUnSchSubAssembly = ds.Tables("PMSchSubAssembly")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtUnSchSubAssembly
        End Function
        Public Shared Function GetUnSchDetails(ByVal maintenance_group As String, ByVal WONumber As Integer, ByVal WODate As Date) As DataTable
            Dim dtUnSchDetails As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@maintenance_group", SqlDbType.VarChar, 10)
            da.SelectCommand.Parameters("@maintenance_group").Direction = ParameterDirection.Input
            da.SelectCommand.Parameters.Add("@workorder_number", SqlDbType.Int, 4)
            da.SelectCommand.Parameters("@workorder_number").Direction = ParameterDirection.Input
            da.SelectCommand.Parameters.Add("@wo_date", SqlDbType.DateTime, 8)
            da.SelectCommand.Parameters("@wo_date").Direction = ParameterDirection.Input
            Try
                da.SelectCommand.Parameters("@maintenance_group").Value = maintenance_group.Trim
                da.SelectCommand.Parameters("@workorder_number").Value = WONumber
                da.SelectCommand.Parameters("@wo_date").Value = WODate
                da.SelectCommand.CommandText = " select * FROM ms_unscheduled_entry WHERE maintenance_group = @maintenance_group and workorder_number = @workorder_number and wo_date = @wo_date "
                da.Fill(ds)
                dtUnSchDetails = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
            Return dtUnSchDetails
        End Function

        Public Shared Function GetPMSchDetails(ByVal maintenance_group As String, ByVal WONumber As Integer, ByVal WODate As Date) As DataTable
            Dim dtUnSchDetails As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@maintenance_group", SqlDbType.VarChar, 10)
            da.SelectCommand.Parameters("@maintenance_group").Direction = ParameterDirection.Input
            da.SelectCommand.Parameters.Add("@workorder_number", SqlDbType.Int, 4)
            da.SelectCommand.Parameters("@workorder_number").Direction = ParameterDirection.Input
            da.SelectCommand.Parameters.Add("@wo_date", SqlDbType.DateTime, 8)
            da.SelectCommand.Parameters("@wo_date").Direction = ParameterDirection.Input
            Try
                da.SelectCommand.Parameters("@maintenance_group").Value = maintenance_group.Trim
                da.SelectCommand.Parameters("@workorder_number").Value = WONumber
                da.SelectCommand.Parameters("@wo_date").Value = WODate
                da.SelectCommand.CommandText = " select * FROM ms_preventiveMaintenance WHERE maintenance_group = @maintenance_group and workorder_number = @workorder_number and wo_date = @wo_date "
                da.Fill(ds)
                dtUnSchDetails = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
            Return dtUnSchDetails
        End Function


        Public Shared Function GetMachineModificationDetails(ByVal maintenance_group As String, ByVal WONumber As Integer, ByVal WODate As Date) As DataTable
            Dim dtUnSchDetails As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@maintenance_group", SqlDbType.VarChar, 10)
            da.SelectCommand.Parameters("@maintenance_group").Direction = ParameterDirection.Input
            da.SelectCommand.Parameters.Add("@workorder_number", SqlDbType.Int, 4)
            da.SelectCommand.Parameters("@workorder_number").Direction = ParameterDirection.Input
            da.SelectCommand.Parameters.Add("@wo_date", SqlDbType.DateTime, 8)
            da.SelectCommand.Parameters("@wo_date").Direction = ParameterDirection.Input
            Try
                da.SelectCommand.Parameters("@maintenance_group").Value = maintenance_group.Trim
                da.SelectCommand.Parameters("@workorder_number").Value = WONumber
                da.SelectCommand.Parameters("@wo_date").Value = WODate
                da.SelectCommand.CommandText = " select * FROM ms_machine_modifications WHERE maintenance_group = @maintenance_group and workorder_number = @workorder_number and wo_date = @wo_date "
                da.Fill(ds)
                dtUnSchDetails = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
            Return dtUnSchDetails
        End Function
        Public Shared Function MachineModifiedWorkorders(ByVal ShopCode As String, ByVal MachineModiDate As String, ByVal Location As String) As DataTable
            Dim dtMachineModified As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = "  SELECT DISTINCT workorder_number FROM ms_machine_modifications  " & _
                                " WHERE wo_date = '" & Format(CDate(MachineModiDate.Trim), "yyyy-MM-dd") & "' AND maintenance_group =  '" & Trim(ShopCode.Trim) & "' and location = '" & Location.Trim & "' "
            Try
                da.Fill(ds, "MachineModified")
                dtMachineModified = ds.Tables("MachineModified")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtMachineModified
        End Function
        Public Shared Function UnSchWorkorders(ByVal ShopCode As String, ByVal UnSchDate As String, ByVal Location As String) As DataTable
            Dim dtUnSchMachineCode As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = "  SELECT DISTINCT workorder_number FROM ms_unscheduled_entry  " &
                                " WHERE wo_date = '" & Format(CDate(UnSchDate.Trim), "yyyy-MM-dd") & "' AND maintenance_group =  '" & Trim(ShopCode.Trim) & "' and location = '" & Location.Trim & "' "
            Try
                da.Fill(ds, "UnSchMachineCode")
                dtUnSchMachineCode = ds.Tables("UnSchMachineCode")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtUnSchMachineCode
        End Function
        Public Shared Function PMSchWorkorders(ByVal ShopCode As String, ByVal UnSchDate As String, ByVal Location As String) As DataTable
            Dim dtUnSchMachineCode As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = "  SELECT DISTINCT workorder_number FROM ms_preventiveMaintenance  " &
                                " WHERE wo_date = '" & Format(CDate(UnSchDate.Trim), "yyyy-MM-dd") & "' AND maintenance_group =  '" & Trim(ShopCode.Trim) & "' and location = '" & Location.Trim & "' "
            Try
                da.Fill(ds, "UnSchMachineCode")
                dtUnSchMachineCode = ds.Tables("UnSchMachineCode")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtUnSchMachineCode
        End Function
        Public Shared Function MachineModification(ByVal mode As String, ByVal ShopCode As String, Optional ByVal UnSchDate As String = "1900-01-01", Optional ByVal Group As String = "") As DataTable
            Dim dtMachineModification As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            If mode = "add" Then
                da.SelectCommand.CommandText = " select machine_code,(description +'-'+ machine_code) as Description from ms_MachineryMaster where machine_code like '" & Trim(ShopCode.Trim) & "%' and GroupCode = '" & Trim(Group.Trim) & "' ORDER BY description  "
            Else
                da.SelectCommand.CommandText = "  SELECT DISTINCT ms_machine_modifications.machine_code , " & _
                    "(ms_machine_modifications.machine_code+'-'+description) as Description " & _
                    " FROM ms_machinery_master , ms_machine_modifications WHERE " & _
                    " ms_machinery_master.machine_code = ms_machine_modifications.machine_code " & _
                    " AND ms_machine_modifications.machine_code like '" & Trim(ShopCode.Trim) & "%' and ms_machine_modifications.wo_date = '" & Format(CDate(UnSchDate.Trim), "yyyy-MM-dd") & "' and ms_machinery_master.user_id = '" & Trim(Group.Trim) & "'"
            End If

            Try
                da.Fill(ds, "MachineModification")
                dtMachineModification = ds.Tables("MachineModification")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtMachineModification
        End Function
        Public Shared Function UnSchMachineCode(ByVal mode As String, ByVal ShopCode As String, Optional ByVal UnSchDate As String = "1900-01-01", Optional ByVal Group As String = "") As DataTable
            Dim dtUnSchMachineCode As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            'If mode = "add" Then
            '    da.SelectCommand.CommandText = " select machine_code,(description +'-'+ machine_code) as Description from ms_MachineryMaster where machine_code like '" & Trim(ShopCode.Trim) & "%' and GroupCode = '" & Trim(Group.Trim) & "' ORDER BY description  "
            'Else
            '    da.SelectCommand.CommandText = "  SELECT DISTINCT ms_unscheduled_entry.machine_code , " & _
            '        "(ms_unscheduled_entry.machine_code+'-'+description) as Description " & _
            '        " FROM ms_machineryMaster , ms_unscheduled_entry WHERE " & _
            '        " ms_machineryMaster.machine_code = ms_unscheduled_entry.machine_code " & _
            '        " AND ms_unscheduled_entry.machine_code like '" & Trim(ShopCode.Trim) & "%' and ms_unscheduled_entry.wo_date = '" & Format(CDate(UnSchDate.Trim), "yyyy-MM-dd") & "' and ms_machineryMaster.GroupCode = '" & Trim(Group.Trim) & "' "
            'End If
            da.SelectCommand.CommandText = " select machine_code,(description +'-'+ machine_code) as Description from ms_MachineryMaster where machine_code like '" & Trim(ShopCode.Trim) & "%' and GroupCode = '" & Trim(Group.Trim) & "' ORDER BY description  "
            Try
                da.Fill(ds, "UnSchMachineCode")
                dtUnSchMachineCode = ds.Tables("UnSchMachineCode")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtUnSchMachineCode
        End Function

        Public Shared Function PMSchMachineCode(ByVal mode As String, ByVal ShopCode As String, Optional ByVal UnSchDate As String = "1900-01-01", Optional ByVal Group As String = "") As DataTable
            Dim dtUnSchMachineCode As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            If mode = "add" Then
                da.SelectCommand.CommandText = " select machine_code,(description +'-'+ machine_code) as Description from ms_MachineryMaster where machine_code like '" & Trim(ShopCode.Trim) & "%' and GroupCode = '" & Trim(Group.Trim) & "' ORDER BY description  "
            Else
                da.SelectCommand.CommandText = "  SELECT DISTINCT ms_preventiveMaintenance.machine_code , " &
                    "(ms_preventiveMaintenance.machine_code+'-'+description) as Description " &
                    " FROM ms_machineryMaster , ms_preventiveMaintenance WHERE " &
                    " ms_machineryMaster.machine_code = ms_preventiveMaintenance.machine_code " &
                    " AND ms_preventiveMaintenance.machine_code like '" & Trim(ShopCode.Trim) & "%' and ms_preventiveMaintenance.wo_date = '" & Format(CDate(UnSchDate.Trim), "yyyy-MM-dd") & "' and ms_machineryMaster.GroupCode = '" & Trim(Group.Trim) & "' "
            End If

            Try
                da.Fill(ds, "PMSchMachineCode")
                dtUnSchMachineCode = ds.Tables("PMSchMachineCode")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtUnSchMachineCode
        End Function

        Public Shared Function PMSMachineCode(ByVal mode As String, ByVal ShopCode As String, Optional ByVal UnSchDate As String = "1900-01-01", Optional ByVal Group As String = "") As DataTable
            Dim dtUnSchMachineCode As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            If mode = "add" Then
                da.SelectCommand.CommandText = " select machine_code,(description +'-'+ machine_code) as Description from ms_MachineryMaster where machine_code like '" & Trim(ShopCode.Trim) & "%' and GroupCode = '" & Trim(Group.Trim) & "' ORDER BY description  "
                'Else
                '    da.SelectCommand.CommandText = "  SELECT DISTINCT ms_unscheduled_entry.machine_code , " &
                '        "(ms_unscheduled_entry.machine_code+'-'+description) as Description " &
                '        " FROM ms_machineryMaster , ms_unscheduled_entry WHERE " &
                '        " ms_machineryMaster.machine_code = ms_unscheduled_entry.machine_code " &
                '        " AND ms_unscheduled_entry.machine_code like '" & Trim(ShopCode.Trim) & "%' and ms_unscheduled_entry.wo_date = '" & Format(CDate(UnSchDate.Trim), "yyyy-MM-dd") & "' and ms_machineryMaster.GroupCode = '" & Trim(Group.Trim) & "' "
            End If
            'da.SelectCommand.CommandText = " select machine_code,(description +'-'+ machine_code) as Description from ms_MachineryMaster where machine_code like '" & Trim(ShopCode.Trim) & "%' and GroupCode = '" & Trim(Group.Trim) & "' ORDER BY description  "
            Try
                da.Fill(ds, "PMSMachineCode")
                dtUnSchMachineCode = ds.Tables("PMSMachineCode")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtUnSchMachineCode
        End Function

        Public Shared Function GetPMSSubAssemblyList(ByVal Mode As String, ByVal Machine As String, Optional ByVal grp As String = "", Optional ByVal ShopCode As String = "") As DataTable
            Dim dtUnSchSubAssembly As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            If Mode = "add" Then
                da.SelectCommand.CommandText = " select code,(code+'-'+description) as description from ms_subassembly " &
                        " where parent_equipment_code = '" & Trim(Machine) & "' and  employee_code = '" & grp.Trim & "' "
                'Else
                '    da.SelectCommand.CommandText = " select ms_subassembly.code as code , (ms_subassembly.code+'-'+ms_subassembly.description) as description " &
                '            " from ms_subassembly, ms_unscheduled_entry where machine_code = parent_equipment_code and code = sub_assembly " &
                '            " and location = '" & Trim(ShopCode) & "' and machine_code = '" & Trim(Machine) & "' "
            End If
            'da.SelectCommand.CommandText = " select code,(code+'-'+description) as description from ms_subassembly " & _
            '                        " where parent_equipment_code = '" & Trim(Machine) & "' and  employee_code = '" & grp.Trim & "' "
            Try
                da.Fill(ds, "PMSSubAssembly")
                dtUnSchSubAssembly = ds.Tables("PMSSubAssembly")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtUnSchSubAssembly
        End Function

        Public Shared Function Location(ByVal mode As String, ByVal group As String, ByVal Type As String) As DataSet
            Dim dsMemoNumber As New DataSet()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            If mode = "add" Then
                da.SelectCommand.CommandText = "  select distinct a.location code , (a.location +' - '+ a.description) Location  from ms_group_location a   where a.purpose = 'MSSBreakdowns' and a.group_code = '" & group.Trim & "'  ; "
                If Type = "U" Then
                    da.SelectCommand.CommandText &= " select max(workorder_number) from ms_unscheduled_entry where maintenance_group = '" & Trim(group.Trim) & "' "
                Else
                    da.SelectCommand.CommandText &= " select max(workorder_number) from ms_machine_modifications where maintenance_group = '" & Trim(group.Trim) & "' "
                End If

            Else
                If Type = "U" Then
                    da.SelectCommand.CommandText = " select distinct location code , (code+'-'+description) as Location " _
                                                & " from code , ms_unscheduled_entry where ms_unscheduled_entry.location = code.code  " _
                                                & " and code.application = 'MS' and code.code_type = 'LC' and maintenance_group = '" & Trim(group.Trim) & "' "
                ElseIf Type = "M" Then
                    da.SelectCommand.CommandText = " select distinct location code , (code+'-'+description) as Location " _
                                                 & " from code , ms_machine_modifications where ms_machine_modifications.location = code.code  " _
                                                 & " and code.application = 'MS' and code.code_type = 'LC' and maintenance_group = '" & Trim(group.Trim) & "' "
                End If

            End If
            Try
                da.Fill(dsMemoNumber)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dsMemoNumber
        End Function
        Public Shared Function PMLocation(ByVal mode As String, ByVal group As String, ByVal Type As String) As DataSet
            Dim dsMemoNumber As New DataSet()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            If mode = "add" Then
                da.SelectCommand.CommandText = "  select distinct a.location code , (a.location +' - '+ a.description) Location  from ms_group_location a   where a.purpose = 'MSSBreakdowns' and a.group_code = '" & group.Trim & "'  ; "
                If Type = "P" Then
                    da.SelectCommand.CommandText &= " select max(workorder_number) from ms_preventiveMaintenance where maintenance_group = '" & Trim(group.Trim) & "' "
                Else
                    da.SelectCommand.CommandText &= " select max(workorder_number) from ms_machine_modifications where maintenance_group = '" & Trim(group.Trim) & "' "
                End If

            Else
                If Type = "P" Then
                    da.SelectCommand.CommandText = " select distinct location code , (code+'-'+description) as Location " _
                                                & " from code , ms_preventiveMaintenance where ms_preventiveMaintenance.location = code.code  " _
                                                & " and code.application = 'MS' and code.code_type = 'LC' and maintenance_group = '" & Trim(group.Trim) & "' "
                ElseIf Type = "M" Then
                    da.SelectCommand.CommandText = " select distinct location code , (code+'-'+description) as Location " _
                                                 & " from code , ms_machine_modifications where ms_machine_modifications.location = code.code  " _
                                                 & " and code.application = 'MS' and code.code_type = 'LC' and maintenance_group = '" & Trim(group.Trim) & "' "
                End If

            End If
            Try
                da.Fill(dsMemoNumber)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dsMemoNumber
        End Function

        Public Shared Function PLDetails(ByVal PLNumber As String) As DataTable
            Dim dtPLDetails As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select pl_number , dbo.ms_fn_PlShortName(pl_number) PlShortName , dbo.ms_fn_PlUnitName(pl_number) PlUnitName from pm_item_master where pl_number = '" & PLNumber.Trim & "' "
            Try
                da.Fill(ds, "PLDetails")
                dtPLDetails = ds.Tables("PLDetails")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtPLDetails
        End Function
        Public Shared Function SubAssembly(ByVal MachineCode As String, ByVal Group As String) As DataTable
            Dim dtSubAssembly As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@MachineCode", SqlDbType.VarChar, 50)
            da.SelectCommand.Parameters("@MachineCode").Direction = ParameterDirection.Input
            da.SelectCommand.Parameters.Add("@Group", SqlDbType.VarChar, 50)
            da.SelectCommand.Parameters("@Group").Direction = ParameterDirection.Input
            da.SelectCommand.CommandText = " select code , description from ms_subassembly where parent_equipment_code = @MachineCode and employee_code = @Group "
            Try
                da.SelectCommand.Parameters("@MachineCode").Value = MachineCode.Trim
                da.SelectCommand.Parameters("@Group").Value = Group.Trim
                da.Fill(ds, "SubAssembly")
                dtSubAssembly = ds.Tables("SubAssembly")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtSubAssembly
        End Function
        Public Shared Function MemoNumberDetails(ByVal shop_code As String, ByVal breakdown_date As Date, ByVal memo_number As Integer, ByVal BDtype As String) As DataSet
            Dim dsMemoNumber As New DataSet()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@shop_code", SqlDbType.VarChar, 50)
            da.SelectCommand.Parameters("@shop_code").Direction = ParameterDirection.Input
            da.SelectCommand.Parameters.Add("@memo_number", SqlDbType.Int, 4)
            da.SelectCommand.Parameters("@memo_number").Direction = ParameterDirection.Input
            da.SelectCommand.Parameters.Add("@MemoDate", SqlDbType.DateTime, 8)
            da.SelectCommand.Parameters("@MemoDate").Direction = ParameterDirection.Input
            da.SelectCommand.Parameters.Add("@BDtype", SqlDbType.VarChar, 4)
            da.SelectCommand.Parameters("@BDtype").Direction = ParameterDirection.Input
            da.SelectCommand.CommandText = " select breakdown_from_time , breakdown_to_time , observation_from_time , observation_to_time , remarks , " & _
                    " machine_code , parent_machine_code , operator , maintenance_group from ms_breakdown_memo  " & _
                    " where  memo_number = @memo_number and shop_code = @shop_code and breakdown_date = @MemoDate ; " & _
                    " select (c.code+'-'+c.description) BreakDownDetail " & _
                    " from ms_breakdown_memo a inner join ms_breakdown_details b on  a.maintenance_group = b.maintenance_group and a.memo_number = b.memo_number  " & _
                    " inner join code c on c.code = b.breakdown_code  inner join code_type d on d.code_type = c.code_type  and d.application = c.application  " & _
                    " where  a.shop_code = @shop_code and breakdown_date = @MemoDate " & _
                    " and c.code_type = @BDtype and a.memo_number = @memo_number ; " & _
                    " select staff, failure_nature , sub_assembly , work_done  from ms_breakbown_maintenance where  memo_number = @memo_number and shop_code = @shop_code "

            Try
                da.SelectCommand.Parameters("@shop_code").Value = shop_code.Trim
                da.SelectCommand.Parameters("@memo_number").Value = memo_number
                da.SelectCommand.Parameters("@MemoDate").Value = breakdown_date
                da.SelectCommand.Parameters("@BDtype").Value = BDtype.Trim
                da.Fill(dsMemoNumber)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dsMemoNumber
        End Function
        Public Shared Function CheckMemo(ByVal shop_code As String, ByVal memo_number As String) As Integer
            Dim Cnt As Integer
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@shop_code", SqlDbType.VarChar, 50)
            cmd.Parameters("@shop_code").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@memo_number", SqlDbType.Int, 4)
            cmd.Parameters("@memo_number").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@Cnt", SqlDbType.Int, 4)
            cmd.Parameters("@Cnt").Direction = ParameterDirection.Output
            cmd.CommandText = " select @Cnt = count(*) from ms_breakbown_maintenance where shop_code = @shop_code and memo_number = @memo_number "
            Try
                cmd.Parameters("@shop_code").Value = shop_code.Trim
                cmd.Parameters("@memo_number").Value = memo_number
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.ExecuteScalar()
                Cnt = IIf(IsDBNull(cmd.Parameters("@Cnt").Value), 0, cmd.Parameters("@Cnt").Value)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
            End Try
            Return Cnt
        End Function
        Public Shared Function MemoNumber(ByVal ShopCode As String, ByVal breakdown_date As Date, ByVal BDtype As String, ByVal Group As String) As DataTable
            Dim dtMemoNumber As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@MemoDate", SqlDbType.DateTime, 8)
            da.SelectCommand.Parameters("@MemoDate").Value = breakdown_date
            da.SelectCommand.CommandText = "select distinct a.memo_number , ltrim(rtrim(CONVERT(varchar(10),a.memo_number))) + ' - ' + CONVERT(char(10),a.memo_slip_number) as slip_number "
            da.SelectCommand.CommandText &= " from ms_vw_breakdown_memo a " 'inner join ms_breakdown_details b on  a.maintenance_group = b.maintenance_group and a.memo_number = b.memo_number  inner join code c on c.code = b.breakdown_code  "
            da.SelectCommand.CommandText &= " where  a.shop_code  = '" & Trim(ShopCode) & "' and breakdown_date = @MemoDate " 'and isnull(a.breakdown_code, '" & BDtype.Trim & "' )  = '" & BDtype.Trim & "' 
            da.SelectCommand.CommandText &= " and a.machine_code in ( select machine_code from dbo.ms_fn_MachineryMaster('" & Group.Trim & "','" & Trim(ShopCode) & "'))"
            Try
                da.Fill(ds, "GetMemoNumber")
                dtMemoNumber = ds.Tables("GetMemoNumber")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtMemoNumber
        End Function
        Public Shared Function CheckSpares(ByVal sl_no As String, ByVal PLNumber As String, ByVal WONumber As String, ByVal Group As String, ByVal MachineCode As String, Optional ByVal ISOTaskCode As String = "") As Integer
            Dim Cnt As Integer
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@sl_no", SqlDbType.VarChar, 2)
            cmd.Parameters("@sl_no").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@PLNumber", SqlDbType.VarChar, 8)
            cmd.Parameters("@PLNumber").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@WONumber", SqlDbType.VarChar, 10)
            cmd.Parameters("@WONumber").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@Group", SqlDbType.VarChar, 10)
            cmd.Parameters("@Group").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@MachineCode", SqlDbType.VarChar, 10)
            cmd.Parameters("@MachineCode").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@Cnt", SqlDbType.Int, 4)
            cmd.Parameters("@Cnt").Direction = ParameterDirection.Output
            cmd.CommandText = " select @Cnt = count(*) from ms_workorder_spares where sl_no = @sl_no and pl_number = @PLNumber and workorder_number = @WONumber and maintenance_group = @Group and machine_code = @MachineCode "
            Try
                cmd.Parameters("@sl_no").Value = sl_no.Trim
                cmd.Parameters("@PLNumber").Value = PLNumber
                cmd.Parameters("@WONumber").Value = WONumber.Trim
                cmd.Parameters("@Group").Value = sl_no.Trim
                cmd.Parameters("@MachineCode").Value = PLNumber
                If ISOTaskCode.Trim.Length > 0 Then
                    cmd.Parameters.Add("@ISOTaskCode", SqlDbType.VarChar, 50)
                    cmd.Parameters("@ISOTaskCode").Direction = ParameterDirection.Input
                    cmd.Parameters("@ISOTaskCode").Value = PLNumber
                    cmd.CommandText &= " and isotask_code = @ISOTaskCode "
                End If
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.ExecuteScalar()
                Cnt = IIf(IsDBNull(cmd.Parameters("@Cnt").Value), 0, cmd.Parameters("@Cnt").Value)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
            End Try
            Return Cnt
        End Function
        Public Shared Function WOSpares(ByVal sl_no As String, ByVal WONumber As String, ByVal Group As String, Optional ByVal PLNumber As String = "") As DataTable
            Dim dtWOSpares As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@sl_no", SqlDbType.VarChar, 2)
            da.SelectCommand.Parameters("@sl_no").Direction = ParameterDirection.Input
            da.SelectCommand.Parameters.Add("@WONumber", SqlDbType.VarChar, 10)
            da.SelectCommand.Parameters("@WONumber").Direction = ParameterDirection.Input
            da.SelectCommand.Parameters.Add("@Group", SqlDbType.VarChar, 10)
            da.SelectCommand.Parameters("@Group").Direction = ParameterDirection.Input
            If sl_no = "M" Then
                da.SelectCommand.CommandText = " SELECT a.pl_number , rtrim(short_description) pl_desc , replaced_quantity Quantity " & _
                                " FROM ms_workorder_spares a inner join pm_ItemMaster b on a.pl_number = b.pl_number " & _
                                " WHERE  sl_no = @sl_no and workorder_number = @WONumber and maintenance_group = @Group  "
            Else
                da.SelectCommand.CommandText = " SELECT pl_number , dbo.ms_fn_PlShortName(pl_number) pl_desc , replaced_quantity , SpareType , SpareCost  " & _
                                " FROM ms_workorder_spares a WHERE  sl_no = @sl_no and workorder_number = @WONumber and maintenance_group = @Group  "
            End If

            Try
                da.SelectCommand.Parameters("@sl_no").Value = sl_no.Trim
                da.SelectCommand.Parameters("@WONumber").Value = WONumber.Trim
                da.SelectCommand.Parameters("@Group").Value = Group.Trim
                If PLNumber.Trim.Length > 0 Then
                    da.SelectCommand.Parameters.Add("@PLNumber", SqlDbType.VarChar, 8)
                    da.SelectCommand.Parameters("@PLNumber").Direction = ParameterDirection.Input
                    da.SelectCommand.Parameters("@PLNumber").Value = PLNumber.Trim
                    da.SelectCommand.CommandText &= " and a.pl_number = @PLNumber "
                End If
                da.Fill(ds, "WOSpares")
                dtWOSpares = ds.Tables("WOSpares")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtWOSpares
        End Function
        Public Shared Function Spares(ByVal Group As String, Optional ByVal MachineCode As String = "", Optional ByVal SubAssembly As String = "", Optional ByVal PlNumber As String = "") As DataTable
            Dim dtGetShopCode As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select pl_number , (rtrim(pl_number) + '-' + convert(varchar(100),pl_desc)) pl_desc , qtyreqd from ms_vw_MachineSubAssembly_spares_details  " & _
                                   " where machine_group = '" & Group.Trim & "' "
            If MachineCode.Trim.Length > 0 Then
                da.SelectCommand.CommandText &= " and machinecode = '" & Trim(MachineCode.Trim) & "' "
                If SubAssembly.Trim.Length > 0 Then
                    da.SelectCommand.CommandText &= " and SubAssemblyCode = '" & Trim(SubAssembly.Trim) & "' "
                End If
            End If
            If PlNumber.Trim.Length > 0 Then
                da.SelectCommand.CommandText &= " and pl_number = '" & Trim(PlNumber.Trim) & "' "
            End If
            da.SelectCommand.CommandText &= " order by pl_number "
            Try
                da.Fill(ds, "GetShopCode")
                dtGetShopCode = ds.Tables("GetShopCode")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtGetShopCode
        End Function
        Public Shared Function ShopCode(ByVal Group As String) As DataTable
            Dim dtGetShopCode As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            If Group = "RTSHOP" Then
                da.SelectCommand.CommandText = " select distinct a.location code , (a.location +' - '+ a.description) grp  from ms_group_location a   " & _
                                                   " where a.purpose = 'MSSBreakdowns' and a.group_code like '" & Left(Group, 2).Trim & "%' "
            Else
                da.SelectCommand.CommandText = " select distinct a.location code , (a.location +' - '+ a.description) grp  from ms_group_location a   " & _
                                                   " where a.purpose = 'MSSBreakdowns' and a.group_code = '" & Group.Trim & "' "
            End If

            Try
                da.Fill(ds, "GetShopCode")
                dtGetShopCode = ds.Tables("GetShopCode")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtGetShopCode
        End Function

        Public Shared Function SparesMachine(ByVal Group As String, ByVal Type As String) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select distinct a.MachineCode   , b.description from ms_vw_MachineSubAssembly_spares_details a inner join ms_machinery_master b on a.MachineCode = b.Machine_Code    where a.machine_group = '" & Group.Trim & "' "
            If Type.Trim.ToUpper <> "ALL" Then
                da.SelectCommand.CommandText &= " and   a.MachineCode like  '" & Type.Trim & "%'"
            End If

            Try
                da.Fill(ds, "GetSparesMachine")
                SparesMachine = ds.Tables("GetSparesMachine")
            Catch exp As Exception
                SparesMachine = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function

        Public Shared Function Failure() As DataTable
            Dim dtFailure As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select description , description from code where application = 'MS' and code_type = 'COF' order by description "
            Try
                da.Fill(ds, "Failure")
                dtFailure = ds.Tables("Failure")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtFailure
        End Function
        Public Shared Function CodeType() As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select code_type , description from code_type where application = 'MS' and code_type like 'BD%' "
            Try
                da.Fill(ds, "CodeType")
                CodeType = ds.Tables("CodeType").Copy
            Catch exp As Exception
                CodeType = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
    End Class
    <Serializable()> Public Class Machinery
#Region "   Fields "
        Private sMessage, sPurpose, sGroupCode, sLocation, sEquipmentId, sDescription As String
        Private decQtyS, decQty As Decimal
#End Region
#Region "   Property "
        ReadOnly Property Message() As String
            Get
                Return sMessage
            End Get
        End Property
        Property Qty() As Decimal
            Get
                Return decQty
            End Get
            Set(ByVal Value As Decimal)
                decQty = Value
            End Set
        End Property
        Property QtyS() As Decimal
            Get
                Return decQtyS
            End Get
            Set(ByVal Value As Decimal)
                decQtyS = Value
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
        Property Location() As String
            Get
                Return sLocation
            End Get
            Set(ByVal Value As String)
                sLocation = Value
            End Set
        End Property
        Property EquipmentId() As String
            Get
                Return sEquipmentId
            End Get
            Set(ByVal Value As String)
                sEquipmentId = Value
            End Set
        End Property
        Property Description() As String
            Get
                Return sDescription
            End Get
            Set(ByVal Value As String)
                sDescription = Value
            End Set
        End Property
        Property Purpose() As String
            Get
                Return sPurpose
            End Get
            Set(ByVal Value As String)
                sPurpose = Value
            End Set
        End Property
#End Region
#Region "   Methods "
        Private Sub iniVals()
            sMessage = ""
            sPurpose = ""
            sGroupCode = ""
            sLocation = ""
            sEquipmentId = ""
            sDescription = ""
            decQtyS = 0.0
            decQty = 0.0
        End Sub
        Public Sub New()
            iniVals()
        End Sub
        Public Function SaveSubAssembly(ByVal mode As String) As Boolean
            Dim strcmd As String
            Dim blnDone As Boolean
            If mode = "add" Then
                strcmd = "INSERT into ms_subassembly (  parent_equipment_code ,  code , description , employee_code , parent_flag ) "
                strcmd &= "  values (  @parent_equipment_code ,  @code , @description , @employee_code , @parent_flag ) "
            ElseIf mode = "edit" Then
                strcmd = "UPDATE ms_subassembly set  description = @description  "
                strcmd &= " where parent_equipment_code = @parent_equipment_code and  code = @code  and employee_code = @employee_code AND parent_flag = @parent_flag "
            ElseIf mode = "delete" Then
                strcmd = "DELETE ms_subassembly where parent_equipment_code = @parent_equipment_code and   code = @code    "
                strcmd &= " and description =  @description  and  employee_code  = @employee_code and  parent_flag =  @parent_flag "
            End If
            Dim ocmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            ocmd.CommandText = strcmd
            Try
                ocmd.Parameters.Add("@parent_equipment_code", SqlDbType.VarChar, 50).Value = sEquipmentId.Trim
                ocmd.Parameters.Add("@code", SqlDbType.VarChar, 50).Value = sLocation
                ocmd.Parameters.Add("@description", SqlDbType.VarChar, 1000).Value = sDescription.Trim
                ocmd.Parameters.Add("@employee_code", SqlDbType.VarChar, 50).Value = sGroupCode
                ocmd.Parameters.Add("@parent_flag", SqlDbType.VarChar, 2).Value = sPurpose
                blnDone = True
            Catch exp As Exception
                blnDone = False
                sMessage = exp.Message
            End Try
            If blnDone = True Then
                blnDone = False
            Else
                If ocmd.Connection.State = ConnectionState.Open Then ocmd.Connection.Close()
                ocmd.Dispose()
                Exit Function
            End If
            If ocmd.Connection.State = ConnectionState.Closed Then ocmd.Connection.Open()
            ocmd.Transaction = ocmd.Connection.BeginTransaction()
            Try
                If ocmd.ExecuteNonQuery() > 0 Then blnDone = True
            Catch exp As Exception
                blnDone = False
                sMessage = exp.Message
            Finally
                If blnDone Then
                    ocmd.Transaction.Commit()
                    sMessage = " Records Updated"
                Else
                    ocmd.Transaction.Rollback()
                    sMessage = " Records Not Updated"
                End If
                If ocmd.Connection.State = ConnectionState.Open Then ocmd.Connection.Close()
                ocmd.Dispose()
            End Try
            Return blnDone
        End Function
        Public Function SaveSubAssemblySpares(ByVal PLCount As Integer) As Boolean
            Dim blnDone As Boolean
            Dim strcmd As String
            If PLCount = 0 Then
                strcmd = "INSERT into ms_SubAssembly_spares (machine_group , pl_number , qtyreqd , ParentMachineCode , purpose , SubAssemblyCode ) "
                strcmd &= " values ( @machine_group , @pl, @qty, @ParentMachineCode , @purp , @SubAssemblyCode )"
            Else
                strcmd = "UPDATE ms_SubAssembly_spares set  qtyreqd = @qty , purpose = @purp "
                strcmd &= " where pl_number = @pl  and ParentMachineCode = @ParentMachineCode  and SubAssemblyCode = @SubAssemblyCode "
            End If

            Dim ocmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            ocmd.CommandText = strcmd
            Try
                ocmd.Parameters.Add("@machine_group", SqlDbType.VarChar, 20).Value = Trim(sGroupCode)
                ocmd.Parameters.Add("@pl", SqlDbType.VarChar, 8).Value = Trim(sLocation.Trim)
                ocmd.Parameters.Add("@qty", SqlDbType.Float, 9, 3).Value = IIf(IsDBNull(Val(decQtyS)), 0, Val(decQtyS))
                ocmd.Parameters.Add("@purp", SqlDbType.VarChar, 50).Value = IIf(IsDBNull(Trim(sPurpose.Trim)), " ", Trim(sPurpose.Trim))
                ocmd.Parameters.Add("@ParentMachineCode", SqlDbType.VarChar, 8).Value = sEquipmentId.Trim
                ocmd.Parameters.Add("@SubAssemblyCode", SqlDbType.VarChar, 50).Value = sDescription.Trim
                blnDone = True
            Catch exp As Exception
                sMessage = exp.Message
            End Try
            If blnDone Then
                blnDone = False
            Else
                If ocmd.Connection.State = ConnectionState.Open Then ocmd.Connection.Close()
                ocmd.Dispose()
                Exit Function
            End If
            If blnDone = False Then
                If ocmd.Connection.State = ConnectionState.Closed Then ocmd.Connection.Open()
                ocmd.Transaction = ocmd.Connection.BeginTransaction()
                Try
                    If ocmd.ExecuteNonQuery() > 0 Then blnDone = True
                Catch exp As Exception
                    blnDone = False
                    sMessage = exp.Message
                Finally
                    If blnDone Then
                        ocmd.Transaction.Commit()
                        sMessage = " Records Updated"
                    Else
                        ocmd.Transaction.Rollback()
                        sMessage = " Records Not Updated"
                    End If
                    If ocmd.Connection.State = ConnectionState.Open Then ocmd.Connection.Close()
                    ocmd.Dispose()
                End Try
            End If
            Return blnDone
        End Function
        Public Function SaveMachineSpares(ByVal PLCount As Integer) As Boolean
            Dim blnDone As Boolean
            Dim strcmd As String
            If PLCount = 0 Then
                strcmd = "INSERT into ms_machine_spares ( machine_group , pl_number , qtyreqd , machine_code , purpose ) "
                strcmd &= " values ( @machine_group , @pl, @qty, @code, @purp )"
            Else
                strcmd = "UPDATE ms_machine_spares set  qtyreqd = @qty , purpose = @purp "
                strcmd &= " where pl_number = @pl  and machine_code = @code "
            End If
            Dim ocmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            ocmd.CommandText = strcmd
            Try
                ocmd.Parameters.Add("@machine_group", SqlDbType.VarChar, 10).Value = Trim(sGroupCode.ToUpper)
                ocmd.Parameters.Add("@pl", SqlDbType.VarChar, 8).Value = Trim(sLocation)
                ocmd.Parameters.Add("@qty", SqlDbType.Float, 9, 3).Value = IIf(IsDBNull(Val(decQty)), 0, Val(decQty))
                ocmd.Parameters.Add("@code", SqlDbType.VarChar, 50).Value = sEquipmentId.Trim
                ocmd.Parameters.Add("@purp", SqlDbType.VarChar, 50).Value = IIf(IsDBNull(Trim(sPurpose.Trim)), " ", Trim(sPurpose.Trim))
                blnDone = True
            Catch exp As Exception
                sMessage = exp.Message
            End Try
            If blnDone Then
                blnDone = False
            Else
                If ocmd.Connection.State = ConnectionState.Open Then ocmd.Connection.Close()
                ocmd.Dispose()
            End If
            If blnDone = False Then
                If ocmd.Connection.State = ConnectionState.Closed Then ocmd.Connection.Open()
                ocmd.Transaction = ocmd.Connection.BeginTransaction()
                Try
                    If ocmd.ExecuteNonQuery() > 0 Then blnDone = True
                Catch exp As Exception
                    blnDone = False
                    sMessage = exp.Message
                Finally
                    If blnDone Then
                        ocmd.Transaction.Commit()
                        sMessage = " Records Updated"
                    Else
                        ocmd.Transaction.Rollback()
                        sMessage = " Records Not Updated"
                    End If
                    If ocmd.Connection.State = ConnectionState.Open Then ocmd.Connection.Close()
                    ocmd.Dispose()
                End Try
                Return blnDone
            End If
        End Function
        Public Function SaveSpares(ByVal strTable As String, ByVal SaveMode As String) As Boolean
            Dim blnDone As Boolean
            Dim strsql As String
            If strTable.Equals("ms_machine_spares") Then
                If SaveMode = LCase("ADD") Then
                    strsql = "INSERT into ms_machine_spares ( machine_group , pl_number , qtyreqd , machine_code , purpose ) "
                    strsql &= " values ( @machine_group , @pl, @qty, @code, @purp )"
                ElseIf SaveMode = LCase("EDIT") Then
                    strsql = "UPDATE ms_machine_spares set  qtyreqd = @qty , purpose = @purp "
                    strsql &= " where pl_number = @pl  and machine_code = @code "
                ElseIf SaveMode = LCase("DELETE") Then
                    strsql = "DELETE from ms_machine_spares where pl_number = @pl  and machine_code = @code "
                End If
            Else
                If SaveMode = LCase("ADD") Then
                    strsql = "INSERT into ms_SubAssembly_spares (machine_group , pl_number , qtyreqd , ParentMachineCode , purpose , SubAssemblyCode ) "
                    strsql &= " values ( @machine_group , @pl, @qty, @ParentMachineCode , @purp , @SubAssemblyCode )"
                ElseIf SaveMode = LCase("EDIT") Then
                    strsql = "UPDATE ms_SubAssembly_spares set  qtyreqd = @qty , purpose = @purp "
                    strsql &= " where pl_number = @pl  and ParentMachineCode = @ParentMachineCode  and SubAssemblyCode = @SubAssemblyCode "
                ElseIf SaveMode = LCase("DELETE") Then
                    strsql = "DELETE from ms_SubAssembly_spares where pl_number = @pl  and SubAssemblyCode = @SubAssemblyCode and ParentMachineCode = @ParentMachineCode  "
                End If
            End If
            Dim ocmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            ocmd.CommandText = strsql
            Try
                ocmd.Parameters.Add("@machine_group", SqlDbType.VarChar, 20).Value = sGroupCode.Trim
                ocmd.Parameters.Add("@pl", SqlDbType.VarChar, 10).Value = Trim(sLocation)
                ocmd.Parameters.Add("@qty", SqlDbType.Float, 9, 3).Value = IIf(IsDBNull(Val(decQty)), 0, Val(decQty))
                ocmd.Parameters.Add("@code", SqlDbType.VarChar, 8).Value = sEquipmentId.Trim
                ocmd.Parameters.Add("@purp", SqlDbType.VarChar, 50).Value = IIf(IsDBNull(Trim(sPurpose.Trim)), " ", Trim(sPurpose.Trim))
                ocmd.Parameters.Add("@ParentMachineCode", SqlDbType.VarChar, 10).Value = sEquipmentId.Trim
                ocmd.Parameters.Add("@SubAssemblyCode", SqlDbType.VarChar, 50).Value = sDescription.Trim
                blnDone = True
            Catch exp As Exception
                sMessage = exp.Message
            End Try
            If blnDone Then
                blnDone = False
            Else
                If ocmd.Connection.State = ConnectionState.Open Then ocmd.Connection.Close()
                ocmd.Dispose()
                Exit Function
            End If
            If blnDone = False Then
                If ocmd.Connection.State = ConnectionState.Closed Then ocmd.Connection.Open()
                ocmd.Transaction = ocmd.Connection.BeginTransaction()
                Try
                    If ocmd.ExecuteNonQuery() > 0 Then blnDone = True
                Catch exp As Exception
                    blnDone = False
                    sMessage = exp.Message
                Finally
                    If blnDone Then
                        ocmd.Transaction.Commit()
                        sMessage = " Records Updated"
                    Else
                        ocmd.Transaction.Rollback()
                        sMessage &= " Records Not Updated"
                    End If
                    If ocmd.Connection.State = ConnectionState.Open Then ocmd.Connection.Close()
                    ocmd.Dispose()
                End Try
            End If
            Return blnDone
        End Function
        Public Function MachineMaster(ByVal Location As String, ByVal EqpCode As String, ByVal MachineCode As String, ByVal MachineDescr As String, ByVal AMBasedate As Date, ByVal Manufacturer As String, ByVal Model As String, ByVal Vendor As String, ByVal PO As String, ByVal PODt As Date, ByVal Cost As Decimal, ByVal DtInService As Date, ByVal WarrantyFrom As Date, ByVal WarrantyTo As Date, ByVal MechUser As String, ByVal GroupCode As String, ByVal GroupName As String, ByVal MechUserSelected As Boolean, ByVal ElecUser As String) As Boolean
            Dim done As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim InsertCmd As String = "insert into ms_machinery_master( location_code , equipment_code , machine_code , " & _
                     " description , machine_group , am_basedate , manufacturer , model_name ,  supplier_code, " & _
                     " po_number , po_date , original_cost , inservice_date , warranty_from , warranty_to , user_id ) " & _
                     " values ( @location_code , @equipment_code , @machine_code , @description , @machine_group , @am_basedate , " & _
                     " @manufacturer , @model , @vendor , @po_number , @po_date , @original_cost , @inservice_date , @warranty_from , @warranty_to , @user_id ) "
            Dim SelectQry As String = " select @SlNo = serial_number from ms_machinery_master where machine_code = @machine_code "
            Try
                cmd.Parameters.Add("@location_code", SqlDbType.VarChar, 50).Value = Location
                cmd.Parameters.Add("@equipment_code", SqlDbType.VarChar, 50).Value = EqpCode
                cmd.Parameters.Add("@machine_code", SqlDbType.VarChar, 50).Value = MachineCode
                cmd.Parameters.Add("@description", SqlDbType.VarChar, 1000).Value = MachineDescr
                cmd.Parameters.Add("@machine_group", SqlDbType.VarChar, 50).Value = EqpCode
                cmd.Parameters.Add("@am_basedate", SqlDbType.SmallDateTime, 4).Value = AMBasedate
                cmd.Parameters.Add("@manufacturer", SqlDbType.VarChar, 200).Value = Manufacturer
                cmd.Parameters.Add("@model", SqlDbType.VarChar, 50).Value = Model
                cmd.Parameters.Add("@vendor", SqlDbType.VarChar, 50).Value = Vendor
                cmd.Parameters.Add("@po_number", SqlDbType.VarChar, 9).Value = PO
                cmd.Parameters.Add("@po_date", SqlDbType.SmallDateTime, 4).Value = PODt
                cmd.Parameters.Add("@original_cost", SqlDbType.BigInt, 8).Value = Cost
                cmd.Parameters.Add("@inservice_date", SqlDbType.SmallDateTime, 4).Value = DtInService
                cmd.Parameters.Add("@warranty_from", SqlDbType.SmallDateTime, 4).Value = WarrantyFrom
                cmd.Parameters.Add("@warranty_to", SqlDbType.SmallDateTime, 4).Value = WarrantyTo
                cmd.Parameters.Add("@user_id", SqlDbType.VarChar, 10).Value = MechUser
                cmd.Parameters.Add("@group_code", SqlDbType.VarChar, 50).Value = GroupCode
                cmd.Parameters.Add("@GroupName", SqlDbType.VarChar, 50).Value = GroupName
                cmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                done = True
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If done = False Then
                    cmd.Dispose()
                End If
            End Try
            If done Then
                done = False
            End If
            Try
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                cmd.CommandText = InsertCmd
                If cmd.ExecuteNonQuery = 1 Then
                    cmd.Parameters.Add("@SlNo", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
                    cmd.CommandText = SelectQry
                    cmd.ExecuteScalar()
                    If cmd.Parameters("@SlNo").Value > 0 Then
                        If MechUserSelected = False Then
                            cmd.Parameters.Add("@user_id", SqlDbType.VarChar, 10).Value = ElecUser.Trim
                            cmd.Parameters("@SlNo").Direction = ParameterDirection.Input
                            cmd.CommandText = " insert into ms_machinery_master_group ( serial_number ,  GroupCode ) " & _
                                    " values ( @SlNo , @user_id ) "
                            If cmd.ExecuteNonQuery = 1 Then
                                done = True
                            End If
                        Else
                            cmd.Parameters("@user_id").Value = MechUser.Trim
                            cmd.Parameters("@SlNo").Direction = ParameterDirection.Input
                            cmd.CommandText = " insert into ms_machinery_master_group ( serial_number ,  GroupCode ) " & _
                                    " values ( @SlNo , @user_id ) "
                            If cmd.ExecuteNonQuery = 1 Then
                                cmd.Parameters("@user_id").Value = ElecUser.Trim
                                cmd.Parameters("@SlNo").Direction = ParameterDirection.Input
                                cmd.CommandText = " insert into ms_machinery_master_group ( serial_number ,  GroupCode ) " & _
                                    " values ( @SlNo , @user_id ) "
                                If cmd.ExecuteNonQuery = 1 Then
                                    If GroupCode = "" OrElse GroupName = "" Then
                                        done = True
                                    Else
                                        cmd.CommandText = " select @cnt = count(equipment_id) from ms_group_location " & _
                                            " where purpose = 'MMSBreakdowns' and equipment_id = @equipment_code " & _
                                            " and group_code = @group_code and location = @location_code and description = @GroupName "
                                        cmd.ExecuteScalar()
                                        If IIf(IsDBNull(cmd.Parameters("@cnt").Value), 0, cmd.Parameters("@cnt").Value) = 0 Then
                                            cmd.CommandText = " insert into ms_group_location ( group_code , location , equipment_id , description , purpose ) " & _
                                                " values ( @group_code , @location_code , @equipment_code , @description , 'MMSBreakdowns' )"
                                            If cmd.ExecuteNonQuery = 1 Then done = True
                                        Else
                                            done = True
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            Catch exp As Exception
                done = False
                Throw New Exception(exp.Message)
            Finally
                If done Then
                    cmd.Transaction.Commit()
                Else
                    cmd.Transaction.Rollback()
                End If
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
            End Try
            Return done
        End Function
        Public Function MachineDelete(ByVal Machine As String, ByVal MachineName As String, ByVal Authority As String, ByVal Remarks As String, ByVal SerialNumber As Long) As Boolean
            Dim done As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim InsertCmd As String = "insert into ms_machinery_master_deleted " & _
                     " ( machine_code , location_code , sublocation_code , equipment_code , pl_number , description ,  " & _
                     " machine_group , am_basedate , active_status , status_changedate , label_number , manufacturer , " & _
                     " model_number , model_name , acquired_date , inservice_date , workorder , supplier_code ,  " & _
                     " capacity , maintenance_frequency , daylight , hpforce , po_number , po_date , original_cost , " & _
                     " warranty_period , spares_supplied , span , warranty_from , warranty_to , serial_number , " & _
                     " base_week , base_date, change_date, total_wo, user_id, DelDatetime, DelAuthority, delRemarks ) " & _
                     " select machine_code , location_code , sublocation_code , equipment_code , pl_number , description ,  " & _
                     " machine_group , am_basedate , active_status , status_changedate , label_number , manufacturer , " & _
                     " model_number , model_name , acquired_date , inservice_date , workorder , supplier_code ,  " & _
                     " capacity , maintenance_frequency , daylight , hpforce , po_number , po_date , original_cost ,  " & _
                     " warranty_period , spares_supplied , span , warranty_from , warranty_to , serial_number , " & _
                     " base_week , base_date , change_date , total_wo , user_id , @DelDatetime , @DelAuthority , @delRemarks   " & _
                     " from ms_machinery_master where machine_code = @machine_code and serial_number = @SlNo "

            Try
                cmd.Parameters.Add("@machine_code", SqlDbType.VarChar, 50).Value = Machine
                cmd.Parameters.Add("@description", SqlDbType.VarChar, 1000).Value = MachineName
                cmd.Parameters.Add("@DelAuthority", SqlDbType.VarChar, 1000).Value = Authority
                cmd.Parameters.Add("@delRemarks", SqlDbType.VarChar, 1000).Value = Remarks
                cmd.Parameters.Add("@DelDatetime", SqlDbType.DateTime, 8).Value = Now
                cmd.Parameters.Add("@SlNo", SqlDbType.BigInt, 8).Value = SerialNumber
                done = True
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If done = False Then
                    cmd.Dispose()
                End If
            End Try
            If done Then
                done = False
            End If
            Try
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                cmd.CommandText = InsertCmd
                If cmd.ExecuteNonQuery = 1 Then
                    cmd.CommandText = " delete ms_machinery_master where  serial_number =  @SlNo "
                    If cmd.ExecuteNonQuery = 1 Then
                        cmd.CommandText = " delete ms_machinery_master_group where  serial_number =  @SlNo "
                        If cmd.ExecuteNonQuery > 0 Then
                            done = True
                        End If
                    End If
                End If
            Catch exp As Exception
                done = False
                Throw New Exception(exp.Message)
            Finally
                If done Then
                    cmd.Transaction.Commit()
                Else
                    cmd.Transaction.Rollback()
                End If
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
            End Try
            Return done
        End Function
        Public Function MachineEdit(ByVal Machine As String, ByVal MachineName As String, ByVal AMBasedate As Date, ByVal Manufacturer As String, ByVal Model As String, ByVal Vendor As String, ByVal PO As String, ByVal PODt As Date, ByVal Cost As Decimal, ByVal DtInService As Date, ByVal WarrantyFrom As Date, ByVal WarrantyTo As Date) As Boolean
            Dim done As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim UpdateCmd As String = "update ms_machinery_master set description = @description , am_basedate = @am_basedate ," & _
                     " manufacturer = @manufacturer , model_name = @model_number ,  supplier_code = @vendor  , " & _
                     " po_number = @po_number , po_date = @po_date , original_cost = @original_cost , inservice_date = @inservice_date ," & _
                     "  warranty_from  = @warranty_from , warranty_to = @warranty_to where machine_code = @machine_code "

            Try
                cmd.Parameters.Add("@machine_code", SqlDbType.VarChar, 50).Value = Machine
                cmd.Parameters.Add("@description", SqlDbType.VarChar, 1000).Value = MachineName
                cmd.Parameters.Add("@manufacturer", SqlDbType.VarChar, 200).Value = Manufacturer
                cmd.Parameters.Add("@model_number", SqlDbType.VarChar, 50).Value = Model
                cmd.Parameters.Add("@vendor", SqlDbType.VarChar, 50).Value = Vendor
                cmd.Parameters.Add("@am_basedate", SqlDbType.SmallDateTime, 4).Value = AMBasedate
                cmd.Parameters.Add("@po_date", SqlDbType.SmallDateTime, 4).Value = PODt
                cmd.Parameters.Add("@po_number", SqlDbType.VarChar, 50).Value = PO
                cmd.Parameters.Add("@original_cost", SqlDbType.BigInt, 8).Value = Cost
                cmd.Parameters.Add("@inservice_date", SqlDbType.SmallDateTime, 4).Value = DtInService
                cmd.Parameters.Add("@warranty_from", SqlDbType.SmallDateTime, 4).Value = WarrantyFrom
                cmd.Parameters.Add("@warranty_to", SqlDbType.SmallDateTime, 4).Value = WarrantyTo
                done = True
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If done = False Then
                    cmd.Dispose()
                End If
            End Try
            If done Then
                done = False
                Try
                    If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                    cmd.Transaction = cmd.Connection.BeginTransaction
                    cmd.CommandText = UpdateCmd
                    If cmd.ExecuteNonQuery = 1 Then done = True
                Catch exp As Exception
                    done = False
                    Throw New Exception(exp.Message)
                Finally
                    If done Then
                        cmd.Transaction.Commit()
                    Else
                        cmd.Transaction.Rollback()
                    End If
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                End Try
            End If
            Return done
        End Function
#End Region
    End Class
    <Serializable()> Public Class Breakdown
#Region "   Fields "
        Inherits Workorder
        Private oMachinery As Machinery
        Private intMemoNumber As Integer
        Private sFailureType, sMemoSlipNumber, sProductionAffected, sParentMachineCode, sStatus, sOperator, sBreakdownType, sStaff, sFailureNature, sWorkDone As String
#End Region
#Region "   Property "
        Property FailureType() As String
            Get
                Return sFailureType
            End Get
            Set(ByVal Value As String)
                sFailureType = Value
            End Set
        End Property
        Property WorkDone() As String
            Get
                Return sWorkDone
            End Get
            Set(ByVal Value As String)
                sWorkDone = Value
            End Set
        End Property
        Property FailureNature() As String
            Get
                Return sFailureNature
            End Get
            Set(ByVal Value As String)
                sFailureNature = Value
            End Set
        End Property
        Property Staff() As String
            Get
                Return sStaff
            End Get
            Set(ByVal Value As String)
                sStaff = Value
            End Set
        End Property
        Property BreakdownType() As String
            Get
                Return sBreakdownType
            End Get
            Set(ByVal Value As String)
                sBreakdownType = Value
            End Set
        End Property
        Property Operator1() As String
            Get
                Return sOperator
            End Get
            Set(ByVal Value As String)
                sOperator = Value
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
        Property ParentMachineCode() As String
            Get
                Return sParentMachineCode
            End Get
            Set(ByVal Value As String)
                sParentMachineCode = Value
            End Set
        End Property
        Property MemoSlipNumber() As String
            Get
                Return sMemoSlipNumber
            End Get
            Set(ByVal Value As String)
                sMemoSlipNumber = Value
            End Set
        End Property
        Property MemoNumber() As Integer
            Get
                Return intMemoNumber
            End Get
            Set(ByVal Value As Integer)
                intMemoNumber = Value
            End Set
        End Property
        Property Machinery() As Machinery
            Get
                Return oMachinery
            End Get
            Set(ByVal Value As Machinery)
                oMachinery = Value
            End Set
        End Property
        Property ProductionAffected() As String
            Get
                Return sProductionAffected
            End Get
            Set(ByVal Value As String)
                sProductionAffected = Value
            End Set
        End Property
#End Region
#Region "   Methods "
        Private Sub iniVals()
            oMachinery = Nothing
            intMemoNumber = 0
            sMemoSlipNumber = ""
            sProductionAffected = ""
            sFailureType = ""
        End Sub
        Public Sub New()
            iniVals()
            oMachinery = New Maintenance.Machinery()
        End Sub
        Public Function SaveWorkDoneDetails(ByVal MemoNumber As Integer) As Boolean
            Dim blnDone As Boolean
            Dim CMD As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            CMD.Parameters.Add("@Cnt", SqlDbType.Int, 4)
            CMD.Parameters("@Cnt").Direction = ParameterDirection.Output
            Try
                CMD.Parameters.Add("@GroupCode", SqlDbType.VarChar, 10).Value = Me.Machinery.GroupCode
                CMD.Parameters.Add("@MemoNumber", SqlDbType.Int, 4).Value = Me.MemoNumber
                CMD.Parameters.Add("@MachineCode", SqlDbType.VarChar, 50).Value = Me.MachineCode
                CMD.Parameters.Add("@ShopCode", SqlDbType.VarChar, 50).Value = Me.ShopCode
                CMD.Parameters.Add("@Staff", SqlDbType.VarChar, 50).Value = Me.Staff
                CMD.Parameters.Add("@FailureNature", SqlDbType.VarChar, 50).Value = Me.FailureNature
                CMD.Parameters.Add("@SubAssembly", SqlDbType.VarChar, 50).Value = Me.SubAssembly
                CMD.Parameters.Add("@WorkDone", SqlDbType.VarChar, 5000).Value = Me.WorkDone
                CMD.Parameters.Add("@Operator", SqlDbType.VarChar, 10).Value = Me.Operator1
                CMD.Parameters.Add("@FailureType", SqlDbType.VarChar, 1).Value = Me.FailureType
                CMD.Parameters.Add("@breakdown_type", SqlDbType.VarChar, 50).Value = Me.BreakdownType
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
                CMD.CommandText = " select @Cnt = count(*) from ms_breakbown_maintenance where maintenance_group = @GroupCode and memo_number = @MemoNumber and shop_code = @ShopCode "
                CMD.ExecuteScalar()
                If IIf(IsDBNull(CMD.Parameters("@Cnt").Value), 0, CMD.Parameters("@Cnt").Value) > 0 Then
                    WorkDoneDetailsEdit(CMD, MemoNumber)
                    blnDone = True
                Else
                    WorkDoneDetailsAdd(CMD, MemoNumber)
                    blnDone = True
                End If
                If blnDone = True Then
                    blnDone = False
                    BreakdownTypeUpdate(CMD, Me.BreakdownType)
                    blnDone = True
                End If
            Catch exp As Exception
                Throw New Exception("Saving to ms_breakbown_maintenance Tables error : " & exp.Message)
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
        Private Sub BreakdownTypeUpdate(ByRef CMD As SqlClient.SqlCommand, ByVal BreakdownType As String)
            CMD.CommandText = " update ms_breakdown_memo set breakdown_type = @breakdown_type " & _
                            " where maintenance_group = @GroupCode and memo_number = @MemoNumber and machine_code = @MachineCode "
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" CheckList Saving error")
            Catch exp As Exception
                Throw New Exception(" updation of ms_breakdown_memo error " & exp.Message)
            End Try
        End Sub
        Private Sub WorkDoneDetailsAdd(ByRef CMD As SqlClient.SqlCommand, ByVal MemoNumber As Integer)
            CMD.CommandText = " insert into ms_breakbown_maintenance ( maintenance_group , memo_number , shop_code , staff , failure_nature , sub_assembly , work_done ) " & _
                        " values ( @GroupCode , @MemoNumber , @ShopCode , @Staff , @FailureNature , @SubAssembly , @WorkDone ) "
            Try
                If CMD.ExecuteNonQuery = 0 Then
                    Throw New Exception(" CheckList Saving error")
                Else
                    If IsNothing(Me.SparesList) = False Then
                        If Me.SparesList.Rows.Count > 0 Then
                            If Me.SaveSparesList(CMD, Me.SparesNumber, Me.SparesList, Me.Type) = False Then Throw New Exception(" SparesList Items Saving error")
                        End If
                    End If
                    If Trim(CMD.Parameters("@FailureType").Value).ToUpper = "O" Then
                        CMD.CommandText = " insert into ms_breakdown_FailureType ( maintenance_group , memo_number , machine_code  ) " & _
                                                " values ( @GroupCode , @MemoNumber , @MachineCode ) "
                        If CMD.ExecuteNonQuery() = 0 Then Throw New Exception(" FailureType Saving error")
                    Else
                        CMD.CommandText = " delete ms_breakdown_FailureType where  maintenance_group = @GroupCode and  memo_number = @MemoNumber  " & _
                                                " and machine_code =  @MachineCode "
                        CMD.ExecuteNonQuery()
                    End If
                End If
            Catch exp As Exception
                Throw New Exception(" Insert into ms_workorder_spares error " & exp.Message)
            End Try
        End Sub
        Private Sub WorkDoneDetailsEdit(ByRef CMD As SqlClient.SqlCommand, ByVal MemoNumber As Integer)
            CMD.CommandText = " update ms_breakbown_maintenance set staff = @Staff , failure_nature = @FailureNature ,  " & _
                    " sub_assembly = @SubAssembly , work_done = @WorkDone " & _
                    " where maintenance_group = @GroupCode  and memo_number = @MemoNumber and shop_code = @ShopCode  "
            Try
                If CMD.ExecuteNonQuery = 0 Then
                    Throw New Exception(" Unable to update CheckList details ")
                Else
                    If IsNothing(Me.SparesList) = False Then
                        If Me.SparesList.Rows.Count > 0 Then
                            If SaveSparesList(CMD, Me.SparesNumber, Me.SparesList, Me.Type) = False Then Throw New Exception(" Spares List Saving error")
                        End If
                    End If
                    If Trim(CMD.Parameters("@FailureType").Value).ToUpper = "O" Then
                        CMD.CommandText = " insert into ms_breakdown_FailureType ( maintenance_group , memo_number , machine_code  ) " & _
                                                " values ( @GroupCode , @MemoNumber , @MachineCode ) "
                        If CMD.ExecuteNonQuery() = 0 Then Throw New Exception(" FailureType Saving error")
                    Else
                        CMD.CommandText = " delete ms_breakdown_FailureType where  maintenance_group = @GroupCode and  memo_number = @MemoNumber  " & _
                                                " and machine_code =  @MachineCode "
                        CMD.ExecuteNonQuery()
                    End If
                End If
            Catch exp As Exception
                Throw New Exception(" update of ms_workorder_spares error :  " & exp.Message)
            End Try
        End Sub
#End Region
    End Class
    <Serializable()> Public Class UnScheduled
#Region "   Fields "
        Inherits Workorder
        Private oMachinery As Machinery
        Private ssupervisor, sWorkDone, sAttendent, sOperator, sMaintenanceType As String
#End Region
#Region "   Property "
        Property Supervisor() As String
            Get
                Return ssupervisor
            End Get
            Set(ByVal Value As String)
                ssupervisor = Value
            End Set
        End Property
        Property Operator1() As String
            Get
                Return sOperator
            End Get
            Set(ByVal Value As String)
                sOperator = Value
            End Set
        End Property
        Property MaintenanceType() As String
            Get
                Return sMaintenanceType
            End Get
            Set(ByVal Value As String)
                sMaintenanceType = Value
            End Set
        End Property
        Property Attendent() As String
            Get
                Return sAttendent
            End Get
            Set(ByVal Value As String)
                sAttendent = Value
            End Set
        End Property
        Property WorkDone() As String
            Get
                Return sWorkDone
            End Get
            Set(ByVal Value As String)
                sWorkDone = Value
            End Set
        End Property
        Property Machinery() As Machinery
            Get
                Return oMachinery
            End Get
            Set(ByVal Value As Machinery)
                oMachinery = Value
            End Set
        End Property
#End Region
#Region "   Methods "
        Private Sub iniVals()
            sOperator = ""
            sWorkDone = ""
            sAttendent = ""
            sMaintenanceType = ""
            oMachinery = Nothing
            ssupervisor = ""
        End Sub
        Public Sub New()
            iniVals()
            oMachinery = New Maintenance.Machinery()
        End Sub
        Public Function SaveWorkDoneDetails(ByVal WONumber As Integer, Optional ByVal Delete As Boolean = False) As Boolean
            Dim blnDone As Boolean
            Dim CMD As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            CMD.Parameters.Add("@Cnt", SqlDbType.Int, 4)
            CMD.Parameters("@Cnt").Direction = ParameterDirection.Output
            Try
                CMD.Parameters.Add("@GroupCode", SqlDbType.VarChar, 10).Value = Me.Machinery.GroupCode
                CMD.Parameters.Add("@Number", SqlDbType.Int, 4).Value = Me.Number
                CMD.Parameters.Add("@MachineCode", SqlDbType.VarChar, 50).Value = Me.MachineCode
                CMD.Parameters.Add("@Location", SqlDbType.VarChar, 50).Value = Me.Machinery.Location
                CMD.Parameters.Add("@SubAssembly", SqlDbType.VarChar, 50).Value = Me.SubAssembly
                CMD.Parameters.Add("@FromDate", SqlDbType.DateTime, 8).Value = Me.FromDate
                CMD.Parameters.Add("@ToDate", SqlDbType.DateTime, 8).Value = Me.ToDate
                CMD.Parameters.Add("@WorkDone", SqlDbType.VarChar, 5000).Value = Me.WorkDone
                CMD.Parameters.Add("@Attendent", SqlDbType.VarChar, 80).Value = Me.Attendent
                CMD.Parameters.Add("@Remarks", SqlDbType.VarChar, 2000).Value = Me.Remarks
                CMD.Parameters.Add("@MaintenanceType", SqlDbType.VarChar, 10).Value = Me.MaintenanceType
                CMD.Parameters.Add("@WODate", SqlDbType.DateTime, 8).Value = Me.WODate
                CMD.Parameters.Add("@Operator", SqlDbType.VarChar, 10).Value = Me.Operator1
                CMD.Parameters.Add("@supervisor", SqlDbType.VarChar, 50).Value = Me.Supervisor
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
                CMD.CommandText = " select @Cnt = count(*) from ms_unscheduled_entry where maintenance_group = @GroupCode and workorder_number = @Number and wo_date = @WODate "
                CMD.ExecuteScalar()
                If IIf(IsDBNull(CMD.Parameters("@Cnt").Value), 0, CMD.Parameters("@Cnt").Value) > 0 Then
                    If Delete Then
                        WorkDoneDetailsDelete(CMD, WONumber)
                        blnDone = True
                    Else
                        WorkDoneDetailsEdit(CMD, WONumber)
                        blnDone = True
                    End If
                Else
                    WorkDoneDetailsAdd(CMD, WONumber)
                    blnDone = True
                End If
            Catch exp As Exception
                Throw New Exception("Saving to ms_unscheduled_entry Tables error : " & exp.Message)
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
        Private Sub WorkDoneDetailsAdd(ByRef CMD As SqlClient.SqlCommand, ByVal MemoNumber As Integer)
            CMD.CommandText = " insert into ms_unscheduled_entry ( workorder_number , maintenance_group , location , machine_code , " &
                    " sub_assembly , date_from , date_to , work_done , attendent , remarks , maintenance_type , wo_date , supervisor )" &
                    " values (  @Number , @GroupCode , @Location ,  @MachineCode , @SubAssembly , @FromDate , @ToDate ,  " &
                    " @WorkDone , @Attendent , @Remarks , @MaintenanceType ,  @WODate , @supervisor ) "
            Try
                If CMD.ExecuteNonQuery = 0 Then
                    Throw New Exception(" CheckList Saving error")
                Else
                    If IsNothing(Me.SparesList) = False Then
                        If Me.SparesList.Rows.Count > 0 Then
                            If Me.SaveNewSparesList(CMD, Me.SparesNumber, Me.SparesList, Me.Type) = False Then Throw New Exception(" SparesList Items Saving error")
                        End If
                    End If
                End If
            Catch exp As Exception
                Throw New Exception(" Insert into ms_workorder_spares error " & exp.Message)
            End Try
        End Sub
        Private Sub WorkDoneDetailsEdit(ByRef CMD As SqlClient.SqlCommand, ByVal MemoNumber As Integer)
            CMD.CommandText = " update ms_unscheduled_entry set maintenance_type = @MaintenanceType , machine_code = @MachineCode , " &
                    " sub_assembly = @SubAssembly , date_from = @FromDate , date_to = @ToDate , work_done = @WorkDone , " &
                    " attendent = @Attendent , remarks = @Remarks , wo_date = @WODate , supervisor = @supervisor " &
                    " where maintenance_group = @GroupCode  and workorder_number = @Number and location = @Location  "
            Try
                If CMD.ExecuteNonQuery = 0 Then
                    Throw New Exception(" Unable to update UnScheduled Entry details ")
                Else
                    If IsNothing(Me.SparesList) = False Then
                        If Me.SparesList.Rows.Count > 0 Then
                            If SaveNewSparesList(CMD, Me.SparesNumber, Me.SparesList, Me.Type) = False Then Throw New Exception(" Spares List Saving error")
                        End If
                    End If
                End If
            Catch exp As Exception
                Throw New Exception(" update of ms_unscheduled_entry error :  " & exp.Message)
            End Try
        End Sub
        Private Sub WorkDoneDetailsDelete(ByRef CMD As SqlClient.SqlCommand, ByVal MemoNumber As Integer)
            CMD.CommandText = " delete ms_unscheduled_entry  where maintenance_group = @GroupCode  and workorder_number = @Number and location = @Location  "
            Try
                If CMD.ExecuteNonQuery = 0 Then
                    Throw New Exception(" Unable to delete UnScheduled Entry details ")
                Else
                    If DeletePl(CMD, True) = False Then Throw New Exception(" Unable to delete UnScheduled PL Details Entry ")
                End If
            Catch exp As Exception
                Throw New Exception(" Deletion of ms_unscheduled_entry error :  " & exp.Message)
            End Try
        End Sub
#End Region

        Public Function SavePMDoneDetails(ByVal WONumber As Integer, Optional ByVal Delete As Boolean = False) As Boolean
            Dim blnDone As Boolean
            Dim CMD As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            CMD.Parameters.Add("@Cnt", SqlDbType.Int, 4)
            CMD.Parameters("@Cnt").Direction = ParameterDirection.Output
            Try
                CMD.Parameters.Add("@GroupCode", SqlDbType.VarChar, 10).Value = Me.Machinery.GroupCode
                CMD.Parameters.Add("@Number", SqlDbType.Int, 4).Value = Me.Number
                CMD.Parameters.Add("@MachineCode", SqlDbType.VarChar, 50).Value = Me.MachineCode
                CMD.Parameters.Add("@Location", SqlDbType.VarChar, 50).Value = Me.Machinery.Location
                CMD.Parameters.Add("@SubAssembly", SqlDbType.VarChar, 50).Value = Me.SubAssembly
                CMD.Parameters.Add("@FromDate", SqlDbType.DateTime, 8).Value = Me.FromDate
                CMD.Parameters.Add("@ToDate", SqlDbType.DateTime, 8).Value = Me.ToDate
                CMD.Parameters.Add("@WorkDone", SqlDbType.VarChar, 5000).Value = Me.WorkDone
                CMD.Parameters.Add("@Attendent", SqlDbType.VarChar, 80).Value = Me.Attendent
                CMD.Parameters.Add("@Remarks", SqlDbType.VarChar, 2000).Value = Me.Remarks
                CMD.Parameters.Add("@MaintenanceType", SqlDbType.VarChar, 10).Value = Me.MaintenanceType
                CMD.Parameters.Add("@WODate", SqlDbType.DateTime, 8).Value = Me.WODate
                CMD.Parameters.Add("@Operator", SqlDbType.VarChar, 10).Value = Me.Operator1
                CMD.Parameters.Add("@supervisor", SqlDbType.VarChar, 50).Value = Me.Supervisor
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
                CMD.CommandText = " select @Cnt = count(*) from ms_preventiveMaintenance where maintenance_group = @GroupCode and workorder_number = @Number and wo_date = @WODate "
                CMD.ExecuteScalar()
                If IIf(IsDBNull(CMD.Parameters("@Cnt").Value), 0, CMD.Parameters("@Cnt").Value) > 0 Then
                    If Delete Then
                        WorkPMDetailsDelete(CMD, WONumber)
                        blnDone = True
                    Else
                        WorkPMDetailsEdit(CMD, WONumber)
                        blnDone = True
                    End If
                Else
                    WorkPMDetailsAdd(CMD, WONumber)
                    blnDone = True
                End If
            Catch exp As Exception
                Throw New Exception("Saving to ms_preventiveMaintenance Tables error : " & exp.Message)
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

        Private Sub WorkPMDetailsAdd(ByRef CMD As SqlClient.SqlCommand, ByVal MemoNumber As Integer)
            CMD.CommandText = " insert into ms_preventiveMaintenance ( workorder_number , maintenance_group , location , machine_code , " &
                    " sub_assembly , date_from , date_to , work_done , attendent , remarks , maintenance_type , wo_date , supervisor )" &
                    " values (  @Number , @GroupCode , @Location ,  @MachineCode , @SubAssembly , @FromDate , @ToDate ,  " &
                    " @WorkDone , @Attendent , @Remarks , @MaintenanceType ,  @WODate , @supervisor ) "
            Try
                If CMD.ExecuteNonQuery = 0 Then
                    Throw New Exception(" CheckList Saving error")
                Else
                    If IsNothing(Me.SparesList) = False Then
                        If Me.SparesList.Rows.Count > 0 Then
                            If Me.SaveNewSparesList(CMD, Me.SparesNumber, Me.SparesList, Me.Type) = False Then Throw New Exception(" SparesList Items Saving error")
                        End If
                    End If
                End If
            Catch exp As Exception
                Throw New Exception(" Insert into ms_workorder_spares error " & exp.Message)
            End Try
        End Sub

        Private Sub WorkPMDetailsEdit(ByRef CMD As SqlClient.SqlCommand, ByVal MemoNumber As Integer)
            CMD.CommandText = " update ms_preventiveMaintenance set maintenance_type = @MaintenanceType , machine_code = @MachineCode , " &
                    " sub_assembly = @SubAssembly , date_from = @FromDate , date_to = @ToDate , work_done = @WorkDone , " &
                    " attendent = @Attendent , remarks = @Remarks , wo_date = @WODate , supervisor = @supervisor " &
                    " where maintenance_group = @GroupCode  and workorder_number = @Number and location = @Location  "
            Try
                If CMD.ExecuteNonQuery = 0 Then
                    Throw New Exception(" Unable to update UnScheduled Entry details ")
                Else
                    If IsNothing(Me.SparesList) = False Then
                        If Me.SparesList.Rows.Count > 0 Then
                            If SaveNewSparesList(CMD, Me.SparesNumber, Me.SparesList, Me.Type) = False Then Throw New Exception(" Spares List Saving error")
                        End If
                    End If
                End If
            Catch exp As Exception
                Throw New Exception(" update of ms_preventiveMaintenance error :  " & exp.Message)
            End Try
        End Sub

        Private Sub WorkPMDetailsDelete(ByRef CMD As SqlClient.SqlCommand, ByVal MemoNumber As Integer)
            CMD.CommandText = " delete ms_preventiveMaintenance  where maintenance_group = @GroupCode  and workorder_number = @Number and location = @Location  "
            Try
                If CMD.ExecuteNonQuery = 0 Then
                    Throw New Exception(" Unable to delete UnScheduled Entry details ")
                Else
                    If DeletePl(CMD, True) = False Then Throw New Exception(" Unable to delete UnScheduled PL Details Entry ")
                End If
            Catch exp As Exception
                Throw New Exception(" Deletion of ms_preventiveMaintenance error :  " & exp.Message)
            End Try
        End Sub



    End Class
    <Serializable()> Public Class Modification
#Region "   Fields "
        Inherits Workorder
        Private oMachinery As Machinery
        Private sDetails, sReason, sInitiatedBy, sApprovedBy, sBenifits, sRemarks, sOperator As String
#End Region
#Region "   Property "
        Property Operator1() As String
            Get
                Return sOperator
            End Get
            Set(ByVal Value As String)
                sOperator = Value.Trim
            End Set
        End Property
        Property Benifits() As String
            Get
                Return sBenifits
            End Get
            Set(ByVal Value As String)
                sBenifits = Value.Trim
            End Set
        End Property
        Property MachineRemarks() As String
            Get
                Return sRemarks
            End Get
            Set(ByVal Value As String)
                sRemarks = Value.Trim
            End Set
        End Property
        Property Details() As String
            Get
                Return sDetails
            End Get
            Set(ByVal Value As String)
                sDetails = Value.Trim
            End Set
        End Property
        Property Reason() As String
            Get
                Return sReason
            End Get
            Set(ByVal Value As String)
                sReason = Value.Trim
            End Set
        End Property
        Property InitiatedBy() As String
            Get
                Return sInitiatedBy
            End Get
            Set(ByVal Value As String)
                sInitiatedBy = Value.Trim
            End Set
        End Property
        Property ApprovedBy() As String
            Get
                Return sApprovedBy
            End Get
            Set(ByVal Value As String)
                sApprovedBy = Value.Trim
            End Set
        End Property
        Property Machinery() As Machinery
            Get
                Return oMachinery
            End Get
            Set(ByVal Value As Machinery)
                oMachinery = Value
            End Set
        End Property
#End Region
#Region "   Methods "
        Private Sub iniVals()
            oMachinery = Nothing
            sDetails = ""
            sReason = ""
            sInitiatedBy = ""
            sApprovedBy = ""
            sBenifits = ""
            sRemarks = ""
        End Sub
        Public Sub New()
            iniVals()
            oMachinery = New Maintenance.Machinery()
        End Sub
        Public Function SaveWorkDoneDetails(ByVal WONumber As Integer) As Boolean
            Dim blnDone As Boolean
            Dim CMD As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            CMD.Parameters.Add("@Cnt", SqlDbType.Int, 4)
            CMD.Parameters("@Cnt").Direction = ParameterDirection.Output
            Try
                CMD.Parameters.Add("@GroupCode", SqlDbType.VarChar, 10).Value = Me.Machinery.GroupCode
                CMD.Parameters.Add("@Number", SqlDbType.Int, 4).Value = Me.Number
                CMD.Parameters.Add("@MachineCode", SqlDbType.VarChar, 50).Value = Me.MachineCode
                CMD.Parameters.Add("@Location", SqlDbType.VarChar, 50).Value = Me.Machinery.Location
                CMD.Parameters.Add("@SubAssembly", SqlDbType.VarChar, 50).Value = Me.SubAssembly
                CMD.Parameters.Add("@FromDate", SqlDbType.SmallDateTime, 4).Value = Me.FromDate
                CMD.Parameters.Add("@ToDate", SqlDbType.SmallDateTime, 4).Value = Me.ToDate
                CMD.Parameters.Add("@details", SqlDbType.VarChar, 2000).Value = Me.Details
                CMD.Parameters.Add("@reason", SqlDbType.VarChar, 1000).Value = Me.Reason
                CMD.Parameters.Add("@initiated_by", SqlDbType.VarChar, 50).Value = Me.InitiatedBy
                CMD.Parameters.Add("@approved_by", SqlDbType.VarChar, 50).Value = Me.ApprovedBy
                CMD.Parameters.Add("@WODate", SqlDbType.DateTime, 8).Value = Me.WODate
                CMD.Parameters.Add("@benifits", SqlDbType.VarChar, 1000).Value = Me.Benifits
                CMD.Parameters.Add("@remarks", SqlDbType.VarChar, 1000).Value = Me.Remarks
                CMD.Parameters.Add("@Operator", SqlDbType.VarChar, 10).Value = Me.Operator1
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
                CMD.CommandText = " select @Cnt = count(*) from ms_machine_modifications where maintenance_group = @GroupCode and workorder_number = @Number and wo_date = @WODate "
                CMD.ExecuteScalar()
                If IIf(IsDBNull(CMD.Parameters("@Cnt").Value), 0, CMD.Parameters("@Cnt").Value) > 0 Then
                    WorkDoneDetailsEdit(CMD, WONumber)
                    blnDone = True
                Else
                    WorkDoneDetailsAdd(CMD, WONumber)
                    blnDone = True
                End If
            Catch exp As Exception
                Throw New Exception("Saving to ms_machine_modifications Tables error : " & exp.Message)
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
        Private Sub WorkDoneDetailsAdd(ByRef CMD As SqlClient.SqlCommand, ByVal MemoNumber As Integer)
            CMD.CommandText = " insert into ms_machine_modifications ( workorder_number , maintenance_group , location , machine_code , " & _
                    " sub_assembly , date_from , date_to , details , reason , initiated_by , approved_by , benifits ,  remarks , wo_date )" & _
                    " values (  @Number , @GroupCode , @Location ,  @MachineCode , @SubAssembly , @FromDate , @ToDate ,  " & _
                    " @details , @reason , @initiated_by , @approved_by , @benifits , @remarks ,  @WODate  ) "
            Try
                If CMD.ExecuteNonQuery = 0 Then
                    Throw New Exception(" CheckList Saving error")
                Else
                    If IsNothing(Me.SparesList) = False Then
                        If Me.SparesList.Rows.Count > 0 Then
                            If Me.SaveSparesList(CMD, Me.SparesNumber, Me.SparesList, Me.Type) = False Then Throw New Exception(" SparesList Items Saving error")
                        End If
                    End If
                End If
            Catch exp As Exception
                Throw New Exception(" Insert into ms_machine_modifications error " & exp.Message)
            End Try
        End Sub
        Private Sub WorkDoneDetailsEdit(ByRef CMD As SqlClient.SqlCommand, ByVal MemoNumber As Integer)
            CMD.CommandText = " update ms_machine_modifications set machine_code = @MachineCode , " & _
                    " sub_assembly = @SubAssembly , date_from = @FromDate , date_to = @ToDate , details = @details , " & _
                    " reason = @reason , initiated_by = @initiated_by , approved_by = @approved_by , benifits = @benifits , remarks = @remarks , wo_date = @WODate " & _
                    " where maintenance_group = @GroupCode  and workorder_number = @Number and location = @Location  "
            Try
                If CMD.ExecuteNonQuery = 0 Then
                    Throw New Exception(" Unable to update machine modifications details ")
                Else
                    If IsNothing(Me.SparesList) = False Then
                        If Me.SparesList.Rows.Count > 0 Then
                            If SaveSparesList(CMD, Me.SparesNumber, Me.SparesList, Me.Type) = False Then Throw New Exception(" Spares List Saving error")
                        End If
                    End If
                End If
            Catch exp As Exception
                Throw New Exception(" update of ms_machine_modifications error :  " & exp.Message)
            End Try
        End Sub
#End Region
    End Class
    Public MustInherit Class Workorder
#Region "   Fields "
        Private intNumber As Integer
        Private sSparesNumber, sGroup, sShiftCode, sShopCode, sMachineCode, sSubAssembly, sRemarks, sType As String
        Private dateDate As Date
        Private dateToDt, dateFromDt As DateTime
        Private tblSparesList As DataTable
#End Region
#Region "   Property "
        Property Type() As String
            Get
                Return sType
            End Get
            Set(ByVal Value As String)
                sType = Value
            End Set
        End Property
        Property SparesList() As DataTable
            Get
                Return tblSparesList
            End Get
            Set(ByVal Value As DataTable)
                tblSparesList = Value
            End Set
        End Property
        Property SparesNumber() As String
            Get
                Return sSparesNumber
            End Get
            Set(ByVal Value As String)
                sSparesNumber = Value
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
        Property SubAssembly() As String
            Get
                Return sSubAssembly
            End Get
            Set(ByVal Value As String)
                sSubAssembly = Value
            End Set
        End Property
        Property MachineCode() As String
            Get
                Return sMachineCode
            End Get
            Set(ByVal Value As String)
                sMachineCode = Value
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
        Property ShiftCode() As String
            Get
                Return sShiftCode
            End Get
            Set(ByVal Value As String)
                sShiftCode = Value
            End Set
        End Property
        Property WODate() As Date
            Get
                Return dateDate
            End Get
            Set(ByVal Value As Date)
                dateDate = Value
            End Set
        End Property
        Property ToDate() As DateTime
            Get
                Return dateToDt
            End Get
            Set(ByVal Value As Date)
                dateToDt = Value
            End Set
        End Property
        Property FromDate() As DateTime
            Get
                Return dateFromDt
            End Get
            Set(ByVal Value As Date)
                dateFromDt = Value
            End Set
        End Property
        Property Group() As String
            Get
                Return sGroup
            End Get
            Set(ByVal Value As String)
                sGroup = Value
            End Set
        End Property
        Property Number() As Integer
            Get
                Return intNumber
            End Get
            Set(ByVal Value As Integer)
                intNumber = Value
            End Set
        End Property
#End Region
#Region "   Methods "
        Private Sub iniVals()
            intNumber = 0
            sSparesNumber = ""
            sGroup = ""
            sShiftCode = ""
            sShopCode = ""
            sMachineCode = ""
            sSubAssembly = ""
            sRemarks = ""
            dateDate = "1900-01-01"
            dateToDt = "1900-01-01"
            dateFromDt = "1900-01-01"
            tblSparesList = Nothing
        End Sub
        Public Sub New()
            iniVals()
        End Sub
        Public Function SaveSparesList(ByRef CMD As SqlClient.SqlCommand, ByVal SparesWONumber As String, ByVal dtCheckListItems As DataTable, ByVal Type As String) As Boolean
            Dim blnDone As Boolean
            Dim cnt As Int16
            Try
                If Me.SparesList.Rows.Count > 0 Then
                    CMD.Parameters.Add("@SparesWONumber", SqlDbType.VarChar, 10).Direction = ParameterDirection.Input
                    CMD.Parameters.Add("@Group", SqlDbType.VarChar, 10).Direction = ParameterDirection.Input
                    CMD.Parameters.Add("@PLNumber", SqlDbType.VarChar, 8).Direction = ParameterDirection.Input
                    CMD.Parameters.Add("@Qty", SqlDbType.Float, 8).Direction = ParameterDirection.Input
                    CMD.Parameters.Add("@ReplacedQty", SqlDbType.Float, 8).Direction = ParameterDirection.Input
                    CMD.Parameters.Add("@Dt", SqlDbType.DateTime, 8).Direction = ParameterDirection.Input
                    CMD.Parameters.Add("@Type", SqlDbType.VarChar, 2).Direction = ParameterDirection.Input

                    For cnt = 0 To Me.SparesList.Rows.Count - 1
                        If Me.SparesNumber.Trim.Length = 0 Then
                            Throw New Exception("InValid Spares entry !")
                        End If
                        If Me.Group.Trim.Length = 0 Then
                            Throw New Exception("InValid Spares entry !")
                        End If
                        CMD.Parameters("@SparesWONumber").Value = Me.SparesNumber
                        CMD.Parameters("@Group").Value = Me.Group
                        CMD.Parameters("@PLNumber").Value = dtCheckListItems.Rows(cnt)(0)
                        CMD.Parameters("@Qty").Value = dtCheckListItems.Rows(cnt)(1)
                        CMD.Parameters("@ReplacedQty").Value = dtCheckListItems.Rows(cnt)(2)
                        CMD.Parameters("@Dt").Value = Date.Now
                        CMD.Parameters("@Type").Value = Type.Trim
                        CMD.CommandText = " select @Cnt = count(*) from ms_workorder_spares where maintenance_group = @Group and workorder_number = @SparesWONumber and machine_code = @MachineCode and pl_number = @PLNumber and sl_no = @Type "
                        CMD.ExecuteScalar()
                        If IIf(IsDBNull(CMD.Parameters("@Cnt").Value), 0, CMD.Parameters("@Cnt").Value) = 0 Then
                            CMD.CommandText = " insert into ms_workorder_spares ( workorder_number , maintenance_group , machine_code , pl_number , quantity , replaced_quantity , done , sl_no , user_id , change_date	 )" &
                                                    " values ( @SparesWONumber , @Group , @MachineCode ,  @PLNumber , @Qty , @ReplacedQty , 1 , @Type , @Operator ,  @Dt )"
                        Else
                            CMD.CommandText = " update ms_workorder_spares set quantity = @Qty  , replaced_quantity = @ReplacedQty , change_date = @Dt , user_id = @Operator " &
                                " where  workorder_number = @SparesWONumber  and  maintenance_group = @Group and  machine_code = @MachineCode and  pl_number = @PLNumber and sl_no = @Type"
                        End If
                        If CMD.ExecuteNonQuery() > 0 Then
                            blnDone = True
                        Else
                            Exit For
                        End If
                    Next
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
                blnDone = False
            End Try
            Return blnDone
        End Function
        Public Function SaveNewSparesList(ByRef CMD As SqlClient.SqlCommand, ByVal SparesWONumber As String, ByVal dtCheckListItems As DataTable, ByVal Type As String) As Boolean
            Dim blnDone As Boolean
            Dim cnt As Int16
            Try
                If Me.SparesList.Rows.Count > 0 Then
                    CMD.Parameters.Add("@SparesWONumber", SqlDbType.VarChar, 10).Direction = ParameterDirection.Input
                    CMD.Parameters.Add("@Group", SqlDbType.VarChar, 10).Direction = ParameterDirection.Input
                    CMD.Parameters.Add("@PLNumber", SqlDbType.VarChar, 8).Direction = ParameterDirection.Input
                    CMD.Parameters.Add("@Qty", SqlDbType.Float, 8).Direction = ParameterDirection.Input
                    CMD.Parameters.Add("@ReplacedQty", SqlDbType.Float, 8).Direction = ParameterDirection.Input
                    CMD.Parameters.Add("@Dt", SqlDbType.DateTime, 8).Direction = ParameterDirection.Input
                    CMD.Parameters.Add("@Type", SqlDbType.VarChar, 2).Direction = ParameterDirection.Input
                    CMD.Parameters.Add("@SpareType", SqlDbType.VarChar, 50).Direction = ParameterDirection.Input
                    CMD.Parameters.Add("@SpareCost", SqlDbType.Float, 8).Direction = ParameterDirection.Input
                    For cnt = 0 To Me.SparesList.Rows.Count - 1
                        CMD.Parameters("@SparesWONumber").Value = Me.SparesNumber
                        CMD.Parameters("@Group").Value = Me.Group
                        CMD.Parameters("@PLNumber").Value = dtCheckListItems.Rows(cnt)(0)
                        CMD.Parameters("@Qty").Value = dtCheckListItems.Rows(cnt)(1)
                        CMD.Parameters("@ReplacedQty").Value = dtCheckListItems.Rows(cnt)(2)
                        CMD.Parameters("@SpareType").Value = dtCheckListItems.Rows(cnt)(3)
                        CMD.Parameters("@SpareCost").Value = dtCheckListItems.Rows(cnt)(4)
                        CMD.Parameters("@Dt").Value = Me.WODate
                        CMD.Parameters("@Type").Value = Type.Trim
                        CMD.CommandText = " select @Cnt = count(*) from ms_workorder_spares where maintenance_group = @Group and workorder_number = @SparesWONumber and machine_code = @MachineCode and pl_number = @PLNumber and sl_no = @Type "
                        CMD.ExecuteScalar()
                        If IIf(IsDBNull(CMD.Parameters("@Cnt").Value), 0, CMD.Parameters("@Cnt").Value) = 0 Then
                            CMD.CommandText = " insert into ms_workorder_spares ( workorder_number , maintenance_group , machine_code , pl_number , quantity , replaced_quantity , done , sl_no , user_id , change_date	, SpareType , SpareCost )" &
                                                    " values ( @SparesWONumber , @Group , @MachineCode ,  @PLNumber , @Qty , @ReplacedQty , 1 , @Type , @Operator ,  @Dt , @SpareType , @SpareCost )"
                        Else
                            CMD.CommandText = " update ms_workorder_spares set quantity = @Qty  , replaced_quantity = @ReplacedQty , change_date = @Dt , user_id = @Operator , SpareType = @SpareType , SpareCost = @SpareCost " &
                                " where  workorder_number = @SparesWONumber  and  maintenance_group = @Group and  machine_code = @MachineCode and  pl_number = @PLNumber and sl_no = @Type"
                        End If
                        If CMD.ExecuteNonQuery() > 0 Then
                            blnDone = True
                        Else
                            Exit For
                        End If
                    Next
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
                blnDone = False
            End Try
            Return blnDone
        End Function
        Public Function DeletePl(ByRef CMD As SqlClient.SqlCommand, Optional ByVal Delete As Boolean = False) As Boolean
            Dim blnDone As Boolean
            Try
                If Delete Then
                    'CMD.Parameters.Add("@cnt", SqlDbType.Int = SqlDbType.BigInt).Direction = ParameterDirection.Output
                    CMD.CommandText = " select @cnt = count(*) from ms_workorder_spares where  workorder_number = @Number  and  maintenance_group = @GroupCode and sl_no = 'U' "
                    CMD.ExecuteScalar()
                    If IIf(IsDBNull(CMD.Parameters("@cnt").Value), "0", CMD.Parameters("@cnt").Value) > 0 Then
                        CMD.CommandText = " delete ms_workorder_spares where  workorder_number = @Number  and  maintenance_group = @GroupCode and sl_no = 'U' "
                        If CMD.ExecuteNonQuery() = 1 Then blnDone = True
                    Else
                        blnDone = True
                    End If
                Else
                    CMD.CommandText = " delete ms_workorder_spares where  workorder_number = @Number  and  maintenance_group = @GroupCode and  pl_number = @PLNumber and sl_no = 'U' "
                    If CMD.ExecuteNonQuery() = 1 Then blnDone = True
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
            End Try
            Return blnDone
        End Function
#End Region
    End Class
End Namespace

