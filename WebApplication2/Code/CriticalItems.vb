Namespace CriticalItems
    <Serializable()> Public Class ItemTables
        Public Shared Function ProdConsumableList(ByVal Group As String) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = "ms_sp_ProdConsumableList"
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            Try
                da.SelectCommand.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = Group.Trim
                da.Fill(ds)
                ProdConsumableList = ds.Tables(0).Copy
            Catch exp As Exception
                Return Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function PLRecoupDetails(ByVal PlNumber As String, ByVal Consignee As String) As DataSet
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select * from ms_vw_PLRecoupDetails where pl_number = '" & PlNumber.Trim & "' ;  " & _
                " select convert(varchar(11),ReqDate,103) RqDate , pl_number , " & _
                " rtrim(ltrim(dbo.ms_fn_PlShortName(pl_number))) PlDesc , RecoupType , RecoupQty , " & _
                " UnitName , ExistingQty , QtyDesc , QtyReq , Remarks , SlNo , Consignee " & _
                " from  ms_PLRecoupDetails where pl_number = '" & PlNumber.Trim & "'  " & _
                " and Consignee = '" & Consignee.Trim & "' order by ReqDate desc; " & _
                " select convert(varchar(11),ReqDate,103) RqDate , pl_number , " & _
                " rtrim(ltrim(dbo.ms_fn_PlShortName(pl_number))) PlDesc , RecoupType , RecoupQty , " & _
                " UnitName , ExistingQty , QtyDesc , QtyReq , Remarks , SlNo , Consignee " & _
                " from  ms_PLRecoupDetails where Consignee = '" & Consignee.Trim & "' " & _
                " order by ReqDate desc;"
            Try
                da.Fill(ds)
                PLRecoupDetails = ds
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function GetSavedIDNsUsage(ByVal Group As String) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select distinct pl_number  from ms_vw_StockIDNStatusListItemsUsage where Consignee = @Group  order by pl_number "
            Try
                da.SelectCommand.Parameters.Add("@Group", SqlDbType.VarChar, 4).Value = Group.Trim
                da.Fill(ds)
                GetSavedIDNsUsage = ds.Tables(0).Copy
            Catch exp As Exception
                Return Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function GetSavedIDNItems(ByVal IDNid As Long) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select IDNid , convert(varchar(11) , UsedDate , 103 ) UsedFrDt , " & _
                    " convert(varchar(11) , UsedToDate , 103 ) UsedToDt , FromHeat , ToHeat , QtyTested , Remarks , ItemsID from ms_StockIDNStatusListItems " & _
                    " where IDNid = @IDNid order by UsedDate asc "
            Try
                da.SelectCommand.Parameters.Add("@IDNid", SqlDbType.BigInt, 8).Value = IDNid
                da.Fill(ds)
                GetSavedIDNItems = ds.Tables(0).Copy
            Catch exp As Exception
                Return Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function GetSavedPOItems(ByVal PO As String) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select FromHeat , ToHeat , Remarks , ItemsID " & _
                " from ms_SandUsage where PONo = @PO "
            Try
                da.SelectCommand.Parameters.Add("@PO", SqlDbType.VarChar, 50).Value = PO
                da.Fill(ds)
                GetSavedPOItems = ds.Tables(0).Copy
            Catch exp As Exception
                Return Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function SandDBRDetails(ByVal PO As String) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select  b.pl_number PlNo , a.po_number PONo , " & _
                " convert(varchar(10),po_date,103) PODt , rtrim(name) Supplier , " & _
                " sum(b.received_quantity) RecQty , sum(accepted_quantity) AccQty , sum(rejected_quantity) RejQty " & _
                " from dm_dbr_header a inner join dm_dbr_detail b " & _
                " on a.dbr_number = b.dbr_number inner join pm_po_details c " & _
                " on a.po_number = c.po_number inner join pm_po_header d   " & _
                " on a.po_number = d.po_number and b.pl_number = c.pl_number " & _
                " inner join pm_SupplierMaster e on d.supplier_code = e.supplier_code  " & _
                " where a.po_number  = @PO " & _
                " and b.pl_number in ( '81908106' , '81981879' ) " & _
                " group by b.pl_number , a.po_number , po_date , name "
            Try
                da.SelectCommand.Parameters.Add("@PO", SqlDbType.VarChar, 50).Value = PO
                da.Fill(ds)
                SandDBRDetails = ds.Tables(0).Copy
            Catch exp As Exception
                Return Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function GetSavedIDNs(ByVal Group As String) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select distinct idn_number , IDNid from ms_StockIDNStatusList where Consignee = @Group and isnull(DeleteStatus,0) = 0 order by idn_number DESC "
            Try
                da.SelectCommand.Parameters.Add("@Group", SqlDbType.VarChar, 4).Value = Group.Trim
                da.Fill(ds)
                GetSavedIDNs = ds.Tables(0).Copy
            Catch exp As Exception
                Return Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function GetS1313Pls(ByVal Group As String) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select distinct pl_number , item_description from dm_issue_requisition where consignee =  @Group order by item_description "
            Try
                da.SelectCommand.Parameters.Add("@Group", SqlDbType.VarChar, 4).Value = Group.Trim
                da.Fill(ds)
                GetS1313Pls = ds.Tables(0).Copy
            Catch exp As Exception
                Return Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function GetShops() As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select distinct dbo.ms_fn_GetShopForConsigneeName(Consignee) Shop  from ms_CriticalItemListStock "
            Try
                da.Fill(ds, "Consignee")
                GetShops = ds.Tables(0).Copy
            Catch exp As Exception
                GetShops = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function GetConsignee(ByVal Group As String, ByVal UserId As String) As String
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()

            da.SelectCommand.CommandText = " select description from ms_group_location where purpose = 'Sub-Stores' " &
                    " and group_code = (select group_code from wap.dbo.menu_your_password_new " &
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
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function CheckPlStatus(ByVal PlNumber As String, ByVal Consignee As String) As Long
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@PlNumber", SqlDbType.VarChar, 8).Value = PlNumber.Trim
                da.SelectCommand.Parameters.Add("@Consignee", SqlDbType.VarChar, 50).Value = Consignee.Trim
                da.SelectCommand.CommandText = " select RecID  from  ms_MaterialRequirement  where PLNumber = @PlNumber and Consignee = @Consignee "
                da.Fill(ds, "PL")
                If ds.Tables("PL").Rows.Count > 0 Then
                    CheckPlStatus = IIf(IsNothing(ds.Tables("PL").Rows(0)(0)), 0, ds.Tables("PL").Rows(0)(0))
                Else
                    CheckPlStatus = 0
                End If
            Catch exp As Exception
                CheckPlStatus = 0
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function CheckPl(ByVal PlNumber As String, ByVal Consignee As String, ByVal PO As String) As Boolean
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@PlNumber", SqlDbType.VarChar, 8).Value = PlNumber.Trim
                da.SelectCommand.Parameters.Add("@Consignee", SqlDbType.VarChar, 50).Value = Consignee
                da.SelectCommand.Parameters.Add("@PO", SqlDbType.VarChar, 20).Value = PO.Trim
                da.SelectCommand.CommandText = " select count(*)  from  ms_CriticalItemListStock  where PLNumber = @PlNumber and Consignee = @Consignee and PO = @PO "
                da.Fill(ds, "PL")
                If IIf(IsNothing(ds.Tables("PL").Rows(0)(0)), 0, ds.Tables("PL").Rows(0)(0)) > 0 Then CheckPl = True
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function GetIDNs(ByVal Consignee As String, Optional ByVal UndoDelete As Boolean = False) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            If UndoDelete Then
                da.SelectCommand.CommandText = " select distinct idn_number from ms_StockIDNStatusList where Consignee = '" & Consignee.Trim & "' and isnull(DeleteStatus,0) = 1 ORDER BY idn_number DESC "
            Else
                da.SelectCommand.CommandText = " select distinct idn_number from ms_StockIDNStatusList where Consignee = '" & Consignee.Trim & "' and isnull(DeleteStatus,0) = 0 ORDER BY idn_number DESC "
            End If

            Try
                da.Fill(ds, "IDNs")
                GetIDNs = ds.Tables("IDNs")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function SavedIDNUsage(ByVal IDNNumber As String) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@IDNNumber", SqlDbType.VarChar, 9).Value = IDNNumber.Trim
                da.SelectCommand.CommandText = " select FromHeat , ToHeat , Remarks  from ms_StockIDNUsage " & _
                    " where idn_number = @IDNNumber "
                da.Fill(ds)
                SavedIDNUsage = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function SavedIDNDetails(ByVal IDNNumber As String, ByVal Consignee As String, Optional ByVal Delete As Boolean = False) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@IDNNumber", SqlDbType.VarChar, 9).Value = IDNNumber.Trim
                da.SelectCommand.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = Consignee.Trim
                da.SelectCommand.Parameters("@Consignee").Direction = ParameterDirection.Input
                da.SelectCommand.CommandText = " select idn_number IDNNo , convert(varchar(10),idn_date,103) IDNDate  , pl_number , " & _
                    " dbo.ms_fn_PlShortName(pl_number) PLDescription , po_number ,   " & _
                    " dbo.ms_fn_SupplierName(supplier_code) SupplierName ,  IDNid , " & _
                    " convert(varchar(10),ReceivedDate,103) ReceivedDt , convert(varchar(10),ClearedDate,103) ClearedDt , " & _
                    " Remarks from ms_StockIDNStatusList " & _
                    " where idn_number = @IDNNumber and Consignee = @Consignee and isnull(DeleteStatus,0) = 0"
                da.Fill(ds, "SavedIDNDetails")
                SavedIDNDetails = ds.Tables("SavedIDNDetails")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function GetIDNDetails(ByVal IDNNumber As String) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select a.idn_number , a.idn_date , a.pl_number , dbo.ms_fn_PlShortName(a.pl_number) PlDesc , " & _
                        " c.po_number , dbo.ms_fn_SupplierName(c.supplier_code) SupplierName ,  c.supplier_code , a.dump_location , a.idn_quantity , d.order_quantity , " & _
                        " dbo.ms_fn_PlUnitName(a.pl_number) UnitName , c.po_date from dm_dbr_detail a inner join  dm_dbr_header b   " & _
                        " on a.dbr_number = b.dbr_number inner join pm_po_header c  " & _
                        " on b.po_number = c.po_number inner join pm_po_details d on d.po_number = c.po_number where a.idn_number = '" & IDNNumber.Trim & "' "
            Try
                da.Fill(ds, "IDNDetails")
                GetIDNDetails = ds.Tables("IDNDetails")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function ProdCriticalSelectionList(ByVal PLNumber As String, ByVal Consignee As String, ByVal PLID As Long, Optional ByVal Delete As Boolean = False) As DataSet
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@PlNumber", SqlDbType.VarChar, 8).Value = PLNumber.Trim
                da.SelectCommand.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = Consignee.Trim

                da.SelectCommand.CommandText = "  select CASE Selected WHEN 1 THEN 'YES' ELSE 'NO' END Critical , " & _
                        " BOMSource Source , BOMType , PerDay , PerMonth , InShop , InStore , Remarks  " & _
                        " from ms_ProdConsumableList a inner join dbo.ms_fn_BOMList(@PLNumber,@Consignee) b  " & _
                        " on a.PLNumber = b.pl_number and a.Consignee = b.Consignee and a.BOMSource = b.Source where a.PLNumber = '" & PLNumber.Trim & "' and  a.Consignee = '" & Consignee.Trim & "' "
                da.SelectCommand.CommandText &= " exec dbo.ms_sp_PlOutstandingDetailsNonStock'" & PLNumber.Trim & "'  ; "
                If Delete = False Then
                    da.SelectCommand.CommandText &= " select Type , PO Number , PODt Dt , POQty Qty , PODD DueDt , POSup Supplier , " & _
                                                    " RecdQty , QtyUT , QtyDue , Remarks , RecID from  ms_ProdCriticalItemList where PLID = " & PLID & "  and isnull(DeleteStatus,'0') = 0 "
                Else
                    da.SelectCommand.CommandText &= " select Type , PO Number , PODt Dt , POQty Qty , PODD DueDt , POSup Supplier , " & _
                                                    " RecdQty , QtyUT , QtyDue , Remarks , RecID from  ms_ProdCriticalItemList where PLID = " & PLID & "  and isnull(DeleteStatus,'0') = 1 "
                End If
                da.Fill(ds)
                ProdCriticalSelectionList = ds
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function ProdConsumablesDetails(ByVal PlNumber As String, Optional ByVal Consignee As String = "", Optional ByVal Delete As Boolean = False) As DataSet
            Dim ds As New DataSet()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.Parameters.Add("@PlNumber", SqlDbType.VarChar, 8).Value = PlNumber.Trim
                da.SelectCommand.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = Consignee.Trim
                da.SelectCommand.CommandText = " select short_description , Source , Type , Qty , UnitName from dbo.ms_fn_BOMList(@PlNumber,@Consignee) ; "
                If Delete = False Then
                    da.SelectCommand.CommandText &= " select BOMSource , BOMType , PerDay , PerMonth , InShop , InStore , Remarks , BOMQty from  ms_ProdConsumableList where PLNumber = '" & PlNumber.Trim & "' and  Consignee = '" & Consignee.Trim & "'  and isnull(DeleteStatus,'0') = 0 ;"
                Else
                    da.SelectCommand.CommandText &= " select BOMSource , BOMType , PerDay , PerMonth , InShop , InStore , Remarks , BOMQty from  ms_ProdConsumableList where PLNumber = '" & PlNumber.Trim & "' and  Consignee = '" & Consignee.Trim & "'  and isnull(DeleteStatus,'0') = 1 ;"
                End If
                da.SelectCommand.CommandText &= " select sum(stock_quantity) from  dm_stock_master where PL_Number = '" & PlNumber.Trim & "'  "
                da.Fill(ds)
                ProdConsumablesDetails = ds
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function GetProdConsumablesPls(ByVal Consignee As String, Optional ByVal Delete As Boolean = False, Optional ByVal Critical As Boolean = False, Optional ByVal Undo As Boolean = False) As DataTable
            Dim ds As New DataSet()
            Dim da As New SqlClient.SqlDataAdapter()
            da.SelectCommand = New SqlClient.SqlCommand()
            da.SelectCommand.Connection = rwfGen.Connection.ConObj
            If Critical = False Then
                If Delete = False Then
                    da.SelectCommand.CommandText = " select PLNumber , PLID from ms_ProdConsumableList a " & _
                        " inner join pm_ItemMaster b on PLNumber = PL_Number" & _
                        " where a.Consignee = '" & Consignee.Trim & "' and DeleteStatus = '0'  " & _
                        " order by PLNumber "
                Else
                    da.SelectCommand.CommandText = " select PLNumber , PLID from ms_ProdConsumableList a " & _
                        " inner join pm_ItemMaster b on PLNumber = PL_Number" & _
                        " where a.Consignee = '" & Consignee.Trim & "' and DeleteStatus = '1' " & _
                        " order by PLNumber "
                End If

            Else
                If Undo = False Then
                    da.SelectCommand.CommandText = " select distinct  PLNumber , a.PLID from ms_ProdConsumableList a inner join ms_ProdCriticalItemList b " & _
                                " on a.PLID = b.PLID where Consignee = '" & Consignee.Trim & "' and  isnull(a.DeleteStatus,'0') = '0' and isnull(b.DeleteStatus,'0') = '0' "
                Else
                    da.SelectCommand.CommandText = " select distinct  PLNumber , a.PLID from ms_ProdConsumableList a inner join ms_ProdCriticalItemList b " & _
                                " on a.PLID = b.PLID  where Consignee = '" & Consignee.Trim & "' and  isnull(a.DeleteStatus,'0') = '0' and isnull(b.DeleteStatus,'0') = '1' "
                End If
            End If

            Try
                da.Fill(ds)
                GetProdConsumablesPls = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function GetConsigneeMaterialPlYears(ByVal Consignee As String, Optional ByVal Delete As Boolean = False, Optional ByVal Stock As Boolean = False) As DataTable
            Dim ds As New DataSet()
            Dim da As New SqlClient.SqlDataAdapter()
            da.SelectCommand = New SqlClient.SqlCommand()
            da.SelectCommand.Connection = rwfGen.Connection.ConObj
            If Delete = False Then
                da.SelectCommand.CommandText = " select distinct Year from ms_MaterialRequirement where Consignee = '" & Consignee.Trim & "'  and isnull(DeleteStatus,'0') = '0' and year not in ( '2009-10' , '2010-11' ) "
            Else
                da.SelectCommand.CommandText = " select distinct Year from ms_MaterialRequirement where Consignee = '" & Consignee.Trim & "'  and isnull(DeleteStatus,'0') = '1' and year not in ( '2009-10' , '2010-11' )"
            End If

            Try
                da.Fill(ds)
                GetConsigneeMaterialPlYears = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function GetConsigneeMaterialPls(ByVal Consignee As String, Optional ByVal Delete As Boolean = False, Optional ByVal Stock As Boolean = False) As DataTable
            Dim ds As New DataSet()
            Dim da As New SqlClient.SqlDataAdapter()
            da.SelectCommand = New SqlClient.SqlCommand()
            da.SelectCommand.Connection = rwfGen.Connection.ConObj
            If Delete = False Then
                da.SelectCommand.CommandText = " select distinct PLNumber from ms_MaterialRequirement a " & _
                    " inner join pm_item_master b on PLNumber = PL_Number  AND  delete_flag = '0' " & _
                    " where a.Consignee = '" & Consignee.Trim & "'  and isnull(DeleteStatus,'0') = '0'"
            Else
                da.SelectCommand.CommandText = " select distinct PLNumber from ms_MaterialRequirement a " & _
                    " inner join pm_item_master b on PLNumber = PL_Number  AND  delete_flag = '0' " & _
                    " where a.Consignee = '" & Consignee.Trim & "'  and isnull(DeleteStatus,'0') = '1'"
            End If

            Try
                da.Fill(ds)
                GetConsigneeMaterialPls = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function GetConsigneePls(ByVal Consignee As String, Optional ByVal Delete As Boolean = False, Optional ByVal Stock As Boolean = False) As DataTable
            Dim ds As New DataSet()
            Dim da As New SqlClient.SqlDataAdapter()
            da.SelectCommand = New SqlClient.SqlCommand()
            da.SelectCommand.Connection = rwfGen.Connection.ConObj
            If Stock = False Then
                If Delete = False Then
                    da.SelectCommand.CommandText = " select distinct PLNumber from ms_CriticalItemListStock where Consignee = '" & Consignee.Trim & "' and dbo.ms_fn_PlType(PLNumber) = 'N' and isnull(DeleteStatus,'0') = '0'"
                Else
                    da.SelectCommand.CommandText = " select distinct PLNumber from ms_CriticalItemListStock where Consignee = '" & Consignee.Trim & "' and dbo.ms_fn_PlType(PLNumber) = 'N' and isnull(DeleteStatus,'0') = '1'"
                End If
            Else
                If Delete = False Then
                    da.SelectCommand.CommandText = " select distinct PLNumber from ms_CriticalItemListStock where Consignee = '" & Consignee.Trim & "' and dbo.ms_fn_PlType(PLNumber) <> 'N' and isnull(DeleteStatus,'0') = '0'"
                Else
                    da.SelectCommand.CommandText = " select distinct PLNumber from ms_CriticalItemListStock where Consignee = '" & Consignee.Trim & "' and dbo.ms_fn_PlType(PLNumber) <> 'N' and isnull(DeleteStatus,'0') = '1'"
                End If
            End If

            Try
                da.Fill(ds)
                GetConsigneePls = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function SavedProdConsumableList(ByVal PLNumber As String, ByVal Consignee As String, Optional ByVal Delete As Boolean = False) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            If Delete = False Then
                da.SelectCommand.CommandText = " select  " & _
                                   " BOMType Type , PerDay , PerMonth , InShop , InStore , Remarks " & _
                                   " from  ms_ProdConsumableList  where PLNumber = '" & PLNumber.Trim & "' and Consignee = '" & Consignee.Trim & "' and isnull(DeleteStatus,'0') = '0' "
            Else
                da.SelectCommand.CommandText = " select  " & _
                                   " BOMType Type , PerDay , PerMonth , InShop , InStore , Remarks " & _
                                   " from  ms_ProdConsumableList  where PLNumber = '" & PLNumber.Trim & "' and Consignee = '" & Consignee.Trim & "' and isnull(DeleteStatus,'0') = '1' "
            End If

            Try
                da.Fill(ds, "SavedList")
                SavedProdConsumableList = ds.Tables("SavedList")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function SavedMaterialList(ByVal PLNumber As String, ByVal Consignee As String, Optional ByVal Delete As Boolean = False) As DataSet
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            If Delete = False Then 'convert(varchar(11), b.NSIDNDate,103) NSIDNDate
                da.SelectCommand.CommandText = " select  PLNumber , QtyReq , [EAR/ES] , Equip , Year , Type , PO , PODt , POQty , " & _
                                   " PODD , POSup , RecdQty , QtyUT , Remarks , RecID , Consignee , DeleteStatus , convert(varchar(11), ItemDate,103) ItemDate  " & _
                                   " from  ms_MaterialRequirement  where PLNumber = '" & PLNumber.Trim & "' and Consignee = '" & Consignee.Trim & "' and isnull(DeleteStatus,'0') = '0' "
            Else
                da.SelectCommand.CommandText = " select  PLNumber , QtyReq , [EAR/ES] , Equip , Year , Type , PO , PODt , POQty , " & _
                                   " PODD , POSup , RecdQty , QtyUT , Remarks , RecID , Consignee , DeleteStatus , convert(varchar(11), ItemDate,103) ItemDate  " & _
                                   " from  ms_MaterialRequirement  where PLNumber = '" & PLNumber.Trim & "' and Consignee = '" & Consignee.Trim & "' and isnull(DeleteStatus,'0') = '1' "
            End If
            If Delete = False Then
                da.SelectCommand.CommandText &= " ; select count(*)  from  ms_MaterialRequirement  where PLNumber = '" & PLNumber.Trim & "' and Consignee = '" & Consignee.Trim & "' and isnull(DeleteStatus,'0') = '1' "
            End If
            Try
                da.Fill(ds)
                SavedMaterialList = ds.Copy
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function SavedCriticalList(ByVal PLNumber As String, ByVal Consignee As String, Optional ByVal Delete As Boolean = False) As DataSet
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            If Delete = False Then
                da.SelectCommand.CommandText = " select PLNumber , SlNo ,  Equip , Type , " & _
                                   " PO Number , PODt Dt , POQty Qty , PODD DueDt , POSup Supplier , " & _
                                   " RecdQty , QtyUT , QtyDue , Remarks , RecID   from  ms_CriticalItemListStock  where PLNumber = '" & PLNumber.Trim & "' and Consignee = '" & Consignee.Trim & "' and isnull(DeleteStatus,'0') = '0' "
            Else
                da.SelectCommand.CommandText = " select PLNumber , SlNo ,  Equip , Type , " & _
                                   " PO Number , PODt Dt , POQty Qty , PODD DueDt , POSup Supplier , " & _
                                   " RecdQty , QtyUT , QtyDue , Remarks , RecID   from  ms_CriticalItemListStock  where PLNumber = '" & PLNumber.Trim & "' and Consignee = '" & Consignee.Trim & "' and isnull(DeleteStatus,'0') = '1' "
            End If
            If Delete = False Then
                da.SelectCommand.CommandText &= " ; select count(*)  from  ms_CriticalItemListStock  where PLNumber = '" & PLNumber.Trim & "' and Consignee = '" & Consignee.Trim & "' and isnull(DeleteStatus,'0') = '1' "
            End If
            Try
                da.Fill(ds)
                SavedCriticalList = ds.Copy
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function Consignee() As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select consignee , consigneename  from ms_sparecell_consignee  order by consignee "
            Try
                da.Fill(ds, "Consignee")
                Consignee = ds.Tables("Consignee")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function SavedList(ByVal PLNumber As String, Optional ByVal Consignee As String = "") As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = "  select PLNumber , SlNo ,  Equip , Type , " & _
                    " PO Number , PODt Dt , POQty Qty , PODD DueDt , POSup Supplier , " & _
                    " RecdQty , QtyUT , QtyDue , Remarks , RecID , PhoneNumber , ContactPerson , Consignee , Status  from  ms_CriticalItemList where PLNumber = '" & PLNumber.Trim & "' and DeleteStatus = '0' "
            Try
                da.Fill(ds, "SavedList")
                SavedList = ds.Tables("SavedList")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function CheckBOMSource(ByVal PlNumber As String, ByVal Consignee As String) As String
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@PlNumber", SqlDbType.VarChar, 8).Value = PlNumber.Trim
                da.SelectCommand.Parameters.Add("@Consignee", SqlDbType.VarChar, 50).Value = Consignee.Trim
                da.SelectCommand.CommandText = " select * from dbo.ms_fn_BOMList(@PlNumber,@Consignee) ; "
                da.Fill(ds, "BOMSource")
                CheckBOMSource = ds.Tables("BOMSource").Rows(0)(2)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function BOMList(ByVal PlNumber As String, Optional ByVal Consignee As String = "") As DataSet
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select short_description , Source , Type , Qty ,  UnitName from dbo.ms_fn_BOMList('" & PlNumber.Trim & "','" & Consignee.Trim & "') ; " & _
                                         " select count(*) from  ms_ProdConsumableList where PLNumber = '" & PlNumber.Trim & "'  and Consignee = '" & Consignee.Trim & "' ; " & _
                                         " select sum(stock_quantity) from  dm_stock_master where PL_Number = '" & PlNumber.Trim & "'  "
            Try
                da.Fill(ds)
                BOMList = ds
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function CheckPlType(ByVal PlNumber As String) As String
            Dim Cmd As System.Data.SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                Cmd.Parameters.Add("@Type", SqlDbType.VarChar, 1).Direction = ParameterDirection.Output
                Cmd.Parameters.Add("@PlNumber", SqlDbType.VarChar, 8).Value = PlNumber.Trim
                Cmd.CommandText = " select @Type = dbo.ms_fn_PlType(@PlNumber) ; "
                If Cmd.Connection.State = ConnectionState.Closed Then Cmd.Connection.Open()
                Cmd.ExecuteScalar()
                CheckPlType = Cmd.Parameters("@Type").Value
            Catch exp As Exception
                CheckPlType = ""
                Throw New Exception(exp.Message)
            Finally
                If Cmd.Connection.State = ConnectionState.Open Then Cmd.Connection.Close()
                Cmd.Dispose()
                Cmd = Nothing
            End Try
        End Function
        Public Shared Function PLDetails(ByVal PlNumber As String, Optional ByVal Consignee As String = "", Optional ByVal Delete As Boolean = False) As DataSet
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            If CheckPlType(PlNumber).ToUpper = "S" Then
                da.SelectCommand.CommandText = " SELECT   pm_item_master.pl_number,  " & _
                                " pm_item_master.short_description ,  " & _
                                " CASE dm_item_recoupment.recoupment_type   " & _
                                " WHEN '1' THEN 'EAR' ELSE 'ES'  " & _
                                "      END AS RecoupType , " & _
                                " CASE dm_item_recoupment.recoupment_type  " & _
                                " WHEN '1' THEN convert(varchar,convert(bigint,dm_item_recoupment.ear_quantity))  " & _
                                " ELSE convert(varchar,convert(bigint,dm_item_recoupment.emergency_stock))  " & _
                                " END AS RecoupQty ,  " & _
                                " pm_UnitMaster.UnitName,  " & _
                                " dm_stock_master.last_issue_date ,  " & _
                                " dbo.ms_fn_PLGroupEQUIPMENT(left(ltrim(pm_item_master.pl_number),4)) Equip " & _
                                " FROM  " & _
                                " wap.dbo.pm_item_master pm_item_master LEFT OUTER JOIN wap.dbo.dm_item_recoupment dm_item_recoupment ON  " & _
                                " pm_item_master.pl_number = dm_item_recoupment.pl_number AND  " & _
                                " pm_item_master.ward = dm_item_recoupment.ward AND  " & _
                                " pm_item_master.category = dm_item_recoupment.category  " & _
                                " LEFT OUTER JOIN wap.dbo.pm_UnitMaster pm_UnitMaster ON  " & _
                                " pm_item_master.uom = pm_UnitMaster.uom  " & _
                                " LEFT OUTER JOIN wap.dbo.dm_stock_master dm_stock_master ON  " & _
                                " pm_item_master.pl_number = dm_stock_master.pl_number AND  " & _
                                " pm_item_master.ward = dm_stock_master.ward AND  " & _
                                " pm_item_master.category = dm_stock_master.category  " & _
                                " LEFT OUTER JOIN wap.dbo.pm_po_details pm_po_details ON  " & _
                                " pm_item_master.last_po_number = pm_po_details.po_number AND  " & _
                                " pm_item_master.pl_number = pm_po_details.pl_number  " & _
                                " LEFT OUTER JOIN wap.dbo.pm_POMaster pm_POMaster ON  " & _
                                " pm_po_details.po_number = pm_POMaster.po_number  " & _
                                " WHERE  " & _
                                " pm_item_master.pl_number = '" & PlNumber.Trim & "' AND " & _
                                " pm_item_master.delete_flag = '0' ; "
            Else
                da.SelectCommand.CommandText = " SELECT   pm_item_master.pl_number,  " & _
                                       " pm_item_master.short_description , '' , '' , " & _
                                       " pm_UnitMaster.UnitName , '' , '' " & _
                                       " FROM  " & _
                                       " wap.dbo.pm_item_master pm_item_master   " & _
                                       " LEFT OUTER JOIN wap.dbo.pm_UnitMaster pm_UnitMaster ON  pm_item_master.uom = pm_UnitMaster.uom WHERE  " & _
                                       " pm_item_master.pl_number = '" & PlNumber.Trim & "' AND " & _
                                       " pm_item_master.delete_flag = '0' ; "
            End If
            da.SelectCommand.CommandText &= " exec dbo.ms_sp_PlOutstandingDetailsNonStock'" & PlNumber.Trim & "'  ; "

            If Delete = False Then
                da.SelectCommand.CommandText &= " select * from  ms_MaterialRequirement where PLNumber = '" & PlNumber.Trim & "' and Consignee = '" & Consignee.Trim & "'"
            Else
                da.SelectCommand.CommandText &= " select * from  ms_MaterialRequirement where PLNumber = '" & PlNumber.Trim & "' and Consignee = '" & Consignee.Trim & "'  and isnull(DeleteStatus,'0') = 1 "
            End If
            da.SelectCommand.CommandText &= " ; select isnull(sum(stock_quantity),0) from  dm_stock_master where PL_Number = '" & PlNumber.Trim & "' ; "
            Try
                da.Fill(ds)
                PLDetails = ds.Copy
            Catch exp As Exception
                PLDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function StockDetails(ByVal PlNumber As String, Optional ByVal Consignee As String = "", Optional ByVal Delete As Boolean = False) As DataSet
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            If Consignee = "MWMS" Then
                da.SelectCommand.CommandText = " SELECT   pm_item_master.pl_number,  " & _
                " pm_item_master.short_description ,  " & _
                " CASE dm_item_recoupment.recoupment_type   " & _
                " WHEN '1' THEN 'EAR' ELSE 'ES'  " & _
                "      END AS RecoupType , " & _
                " CASE dm_item_recoupment.recoupment_type  " & _
                " WHEN '1' THEN convert(varchar,convert(bigint,dm_item_recoupment.ear_quantity))  " & _
                " ELSE convert(varchar,convert(bigint,dm_item_recoupment.emergency_stock))  " & _
                " END AS RecoupQty ,  " & _
                " pm_UnitMaster.UnitName,  " & _
                " dm_stock_master.last_issue_date ,  " & _
                " CASE left(ltrim(pm_item_master.pl_number),4) " & _
                " WHEN '6300' THEN 'EAFs' " & _
                " WHEN '6301' THEN 'LPH' " & _
                " WHEN '6302' THEN 'EOT Cranes' " & _
                " WHEN '6303' THEN 'FES' " & _
                " WHEN '6304' THEN 'SAND PLANT' " & _
                " ELSE '' END AS Equip " & _
                " FROM  " & _
                " wap.dbo.pm_item_master pm_item_master LEFT OUTER JOIN wap.dbo.dm_item_recoupment dm_item_recoupment ON  " & _
                " pm_item_master.pl_number = dm_item_recoupment.pl_number AND  " & _
                " pm_item_master.ward = dm_item_recoupment.ward AND  " & _
                " pm_item_master.category = dm_item_recoupment.category  " & _
                " LEFT OUTER JOIN wap.dbo.pm_UnitMaster pm_UnitMaster ON  " & _
                " pm_item_master.uom = pm_UnitMaster.uom  " & _
                " LEFT OUTER JOIN wap.dbo.dm_stock_master dm_stock_master ON  " & _
                " pm_item_master.pl_number = dm_stock_master.pl_number AND  " & _
                " pm_item_master.ward = dm_stock_master.ward AND  " & _
                " pm_item_master.category = dm_stock_master.category  " & _
                " LEFT OUTER JOIN wap.dbo.pm_po_details pm_po_details ON  " & _
                " pm_item_master.last_po_number = pm_po_details.po_number AND  " & _
                " pm_item_master.pl_number = pm_po_details.pl_number  " & _
                " LEFT OUTER JOIN wap.dbo.pm_POMaster pm_POMaster ON  " & _
                " pm_po_details.po_number = pm_POMaster.po_number  " & _
                " WHERE  " & _
                " pm_item_master.pl_number = '" & PlNumber.Trim & "' AND " & _
                " pm_item_master.delete_flag = '0' ; "
            Else
                da.SelectCommand.CommandText = " SELECT   pm_item_master.pl_number,  " & _
                " pm_item_master.short_description ,  " & _
                " CASE dm_item_recoupment.recoupment_type   " & _
                " WHEN '1' THEN 'EAR' ELSE 'ES'  " & _
                "      END AS RecoupType , " & _
                " CASE dm_item_recoupment.recoupment_type  " & _
                " WHEN '1' THEN convert(varchar,convert(bigint,dm_item_recoupment.ear_quantity))  " & _
                " ELSE convert(varchar,convert(bigint,dm_item_recoupment.emergency_stock))  " & _
                " END AS RecoupQty ,  " & _
                " pm_UnitMaster.UnitName,  " & _
                " dm_stock_master.last_issue_date ,  " & _
                " dbo.ms_fn_PLGroupEQUIPMENT(left(ltrim(pm_item_master.pl_number),4)) Equip " & _
                " FROM  " & _
                " wap.dbo.pm_item_master pm_item_master LEFT OUTER JOIN wap.dbo.dm_item_recoupment dm_item_recoupment ON  " & _
                " pm_item_master.pl_number = dm_item_recoupment.pl_number AND  " & _
                " pm_item_master.ward = dm_item_recoupment.ward AND  " & _
                " pm_item_master.category = dm_item_recoupment.category  " & _
                " LEFT OUTER JOIN wap.dbo.pm_UnitMaster pm_UnitMaster ON  " & _
                " pm_item_master.uom = pm_UnitMaster.uom  " & _
                " LEFT OUTER JOIN wap.dbo.dm_stock_master dm_stock_master ON  " & _
                " pm_item_master.pl_number = dm_stock_master.pl_number AND  " & _
                " pm_item_master.ward = dm_stock_master.ward AND  " & _
                " pm_item_master.category = dm_stock_master.category  " & _
                " LEFT OUTER JOIN wap.dbo.pm_po_details pm_po_details ON  " & _
                " pm_item_master.last_po_number = pm_po_details.po_number AND  " & _
                " pm_item_master.pl_number = pm_po_details.pl_number  " & _
                " LEFT OUTER JOIN wap.dbo.pm_POMaster pm_POMaster ON  " & _
                " pm_po_details.po_number = pm_POMaster.po_number  " & _
                " WHERE  " & _
                " pm_item_master.pl_number = '" & PlNumber.Trim & "' AND " & _
                " pm_item_master.delete_flag = '0' ; "
            End If
            da.SelectCommand.CommandText &= " exec dbo.ms_sp_PlOutstandingDetailsNonStock'" & PlNumber.Trim & "'  ; "
            If Delete = False Then
                da.SelectCommand.CommandText &= " select * from  ms_CriticalItemListStock where PLNumber = '" & PlNumber.Trim & "' and [EAR/ES] <> 'Non-Stock' and Consignee = '" & Consignee.Trim & "'"
            Else
                da.SelectCommand.CommandText &= " select * from  ms_CriticalItemListStock where PLNumber = '" & PlNumber.Trim & "' and [EAR/ES] <> 'Non-Stock' and Consignee = '" & Consignee.Trim & "'  and isnull(DeleteStatus,'0') = 1 "
            End If

            Try
                da.Fill(ds)
                StockDetails = ds
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function NonStockDetails(ByVal PlNumber As String, Optional ByVal Consignee As String = "", Optional ByVal Delete As Boolean = False) As DataSet
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " SELECT   pm_item_master.pl_number,  " & _
                        " pm_item_master.short_description ,  " & _
                        " pm_UnitMaster.UnitName  " & _
                        " FROM  " & _
                        " wap.dbo.pm_item_master pm_item_master   " & _
                        " LEFT OUTER JOIN wap.dbo.pm_UnitMaster pm_UnitMaster ON  pm_item_master.uom = pm_UnitMaster.uom WHERE  " & _
                        " pm_item_master.pl_number = '" & PlNumber.Trim & "' AND " & _
                        " pm_item_master.delete_flag = '0' ; " & _
                        " exec dbo.ms_sp_PlOutstandingDetailsNonStock'" & PlNumber.Trim & "'  ; "
            If Delete = False Then
                da.SelectCommand.CommandText &= " select * from  ms_CriticalItemListStock where PLNumber = '" & PlNumber.Trim & "' and [EAR/ES] = 'Non-Stock' and Consignee = '" & Consignee.Trim & "';"
            Else
                da.SelectCommand.CommandText &= " select * from  ms_CriticalItemListStock where PLNumber = '" & PlNumber.Trim & "' and [EAR/ES] = 'Non-Stock' and Consignee = '" & Consignee.Trim & "'  and isnull(DeleteStatus,'0') = 1 ;"
            End If
            If Delete = False Then
                da.SelectCommand.CommandText &= " select * from  ms_CriticalItemList where PLNumber = '" & PlNumber.Trim & "' and Consignee = '" & Consignee.Trim & "' and isnull(DeleteStatus,'0') = 0 "
            Else
                da.SelectCommand.CommandText &= " select * from  ms_CriticalItemList where PLNumber = '" & PlNumber.Trim & "' and Consignee = '" & Consignee.Trim & "'  and isnull(DeleteStatus,'0') = 1 "
            End If
            Try
                da.Fill(ds)
                NonStockDetails = ds
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function GetReceivedQty(ByVal PlNumber As String, Optional ByVal PONumber As String = " ") As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@PlNumber", SqlDbType.VarChar, 50)
            da.SelectCommand.Parameters("@PlNumber").Direction = ParameterDirection.Input
            da.SelectCommand.CommandText = " select b.NsIDnId NSIDNId, convert(varchar(11), b.NSIDNDate,103) NSIDNDate , a.PONumber, a.PLNumber , d.consigneename Consi , isnull(b.PLRecdQty,0) RecdQty ,  isnull(c.PLAcceptedQty,0) AccpQty , isnull(c.PLRejQty,0) RejQty , isnull(c.Status,'') Status   " & _
                              " from ms_sparecell_po a inner join ms_sparecell_nsidnno b on b.poid = a.poid  " & _
                              " left outer join ms_IMBRegister c on c.NsIdnId = b.NsIdnId " & _
                              " inner join ms_sparecell_consignee d on d.Consignee = b.POConsignee " & _
                              " where a.PLNumber = @PlNumber"
            Try
                da.SelectCommand.Parameters("@PlNumber").Value = PlNumber.Trim
                da.Fill(ds, "Qty")
                GetReceivedQty = ds.Tables("Qty")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function GetPls(Optional ByVal Consignee As String = "MWMR") As DataTable
            Dim ds As New DataSet()
            Dim da As New SqlClient.SqlDataAdapter()
            da.SelectCommand = New SqlClient.SqlCommand()
            da.SelectCommand.Connection = rwfGen.Connection.ConObj
            If Consignee.Trim.Length = 0 Then
                da.SelectCommand.CommandText = " select distinct PLNumber from ms_CriticalItemList where DeleteStatus = '0'"
            Else
                da.SelectCommand.CommandText = " select EARES StockType , PLNumber ,  Type , PO , Remarks , RecID from ms_CriticalItemList where DeleteStatus = '0' and  consignee = '" & Consignee.Trim & "' order by EARES , PLNumber  "
            End If

            Try
                da.Fill(ds)
                GetPls = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function NewGetPls() As DataTable
            Dim ds As New DataSet()
            Dim da As New SqlClient.SqlDataAdapter()
            da.SelectCommand = New SqlClient.SqlCommand()
            da.SelectCommand.Connection = rwfGen.Connection.ConObj
            da.SelectCommand.CommandText = " select distinct PLNumber from ms_CriticalItemList where DeleteStatus = '0'"
            Try
                da.Fill(ds)
                NewGetPls = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function SelectionList(ByVal PLNumber As String, Optional ByVal Consignee As String = "") As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = "  select CASE Selected WHEN 1 THEN 'YES' ELSE 'NO' END Selected , SlNo ,  Equip , Type , " & _
                    " PO Number , PODt Dt , POQty Qty , PODD DueDt , POSup Supplier , " & _
                    " RecdQty , QtyUT , QtyDue , Remarks , RecID , PhoneNumber , ContactPerson , Consignee , Status  from  ms_CriticalItemList where PLNumber = '" & PLNumber.Trim & "' and DeleteStatus = '0' "
            Try
                da.Fill(ds, "Selection")
                SelectionList = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
    End Class
    <Serializable()> Public Class Listing
        Private sPLNumber, sSlNo, sEARES, sEquip, sType, sPO, sPOdate, sPOQt, sPODD, sPOSup, sRemarks, sPhoneNumber, sContactPerson, sConsignee, sStatus, sMessage As String
        Private blnDeleteStatus, blnSelected As Boolean
        Private datePODt, dateLastIssueDate, dateStatusDate, dateReqDate As Date
        Private intPOQty, intRecdQty, intQtyUT, intQtyDue, intStage As Integer
        Private lRecID, lPLID As Long
        Private sBOMSource, sBOMType, sRecoupType, sUnitName, sQtyDesc As String
        Private dBOMQty, dPerDay, dPerMonth, dInShop, dInStore, dRecoupQty, dExistingQty, dQtyReq As Double
#Region "Property "
        WriteOnly Property QtyReq() As Double
            Set(ByVal Value As Double)
                dQtyReq = Value
            End Set
        End Property
        WriteOnly Property QtyDesc() As String
            Set(ByVal Value As String)
                sQtyDesc = ""
            End Set
        End Property
        WriteOnly Property ExistingQty() As Double
            Set(ByVal Value As Double)
                dExistingQty = Value
            End Set
        End Property
        WriteOnly Property UnitName() As String
            Set(ByVal Value As String)
                sUnitName = Value
            End Set
        End Property
        WriteOnly Property RecoupQty() As Double
            Set(ByVal Value As Double)
                dRecoupQty = Value
            End Set
        End Property
        WriteOnly Property RecoupType() As String
            Set(ByVal Value As String)
                sRecoupType = Value
            End Set
        End Property
        WriteOnly Property ReqDate() As Date
            Set(ByVal Value As Date)
                dateReqDate = Value
            End Set
        End Property
        Property POQt() As String
            Get
                Return sPOQt
            End Get
            Set(ByVal Value As String)
                sPOQt = Value
            End Set
        End Property
        Property POdate() As String
            Get
                Return sPOdate
            End Get
            Set(ByVal Value As String)
                sPOdate = Value
            End Set
        End Property
        Property InStore() As Double
            Get
                Return dInStore
            End Get
            Set(ByVal Value As Double)
                dInStore = Value
            End Set
        End Property
        Property InShop() As Double
            Get
                Return dInShop
            End Get
            Set(ByVal Value As Double)
                dInShop = Value
            End Set
        End Property
        Property PerMonth() As Double
            Get
                Return dPerMonth
            End Get
            Set(ByVal Value As Double)
                dPerMonth = Value
            End Set
        End Property
        Property PerDay() As Double
            Get
                Return dPerDay
            End Get
            Set(ByVal Value As Double)
                dPerDay = Value
            End Set
        End Property
        Property BOMQty() As Double
            Get
                Return dBOMQty
            End Get
            Set(ByVal Value As Double)
                dBOMQty = Value
            End Set
        End Property
        Property BOMType() As String
            Get
                Return sBOMType
            End Get
            Set(ByVal Value As String)
                sBOMType = Value
            End Set
        End Property
        Property BOMSource() As String
            Get
                Return sBOMSource
            End Get
            Set(ByVal Value As String)
                sBOMSource = Value
            End Set
        End Property
        Property PLID() As Long
            Get
                Return lPLID
            End Get
            Set(ByVal Value As Long)
                lPLID = Value
            End Set
        End Property
        Property StatusDate() As Date
            Get
                Return dateStatusDate
            End Get
            Set(ByVal Value As Date)
                dateStatusDate = Value
            End Set
        End Property
        Property LastIssueDate() As Date
            Get
                Return dateLastIssueDate
            End Get
            Set(ByVal Value As Date)
                dateLastIssueDate = Value
            End Set
        End Property
        ReadOnly Property Message() As String
            Get
                Return sMessage
            End Get
        End Property
        Property RecID() As Long
            Get
                Return lRecID
            End Get
            Set(ByVal Value As Long)
                lRecID = Value
            End Set
        End Property
        Property Status() As String
            Get
                Return sStatus
            End Get
            Set(ByVal Value As String)
                sStatus = Value.Trim.ToUpper
            End Set
        End Property
        Property Stage() As Integer
            Get
                Return intStage
            End Get
            Set(ByVal Value As Integer)
                intStage = Value
            End Set
        End Property
        Property QtyUT() As Integer
            Get
                Return intQtyUT
            End Get
            Set(ByVal Value As Integer)
                Try
                    If Value < 0 Then
                        Throw New Exception(" Qty UT invalid !")
                    Else
                        intQtyUT = Value
                    End If
                Catch exp As Exception
                    Throw New Exception(exp.Message)
                End Try
            End Set
        End Property
        Property QtyDue() As Integer
            Get
                Return intQtyDue
            End Get
            Set(ByVal Value As Integer)
                Try
                    If Value < 0 Then
                        Throw New Exception(" Qty Due invalid !")
                    Else
                        intQtyDue = Value
                    End If
                Catch exp As Exception
                    Throw New Exception(exp.Message)
                End Try
            End Set
        End Property
        Property RecdQty() As Integer
            Get
                Return intRecdQty
            End Get
            Set(ByVal Value As Integer)

                Try
                    If Value < 0 Then
                        Throw New Exception(" Recd Qty invalid !")
                    Else
                        intRecdQty = Value
                    End If
                Catch exp As Exception
                    Throw New Exception(exp.Message)
                End Try
            End Set
        End Property
        Property POQty() As Integer
            Get
                Return intPOQty
            End Get
            Set(ByVal Value As Integer)
                intPOQty = Value
            End Set
        End Property
        Property PODt() As Date
            Get
                Return datePODt
            End Get
            Set(ByVal Value As Date)
                datePODt = Value
            End Set
        End Property
        Property Selected() As Boolean
            Get
                Return blnSelected
            End Get
            Set(ByVal Value As Boolean)
                blnSelected = Value
            End Set
        End Property
        Property DeleteStatus() As Boolean
            Get
                Return blnDeleteStatus
            End Get
            Set(ByVal Value As Boolean)
                blnDeleteStatus = Value
            End Set
        End Property
        Property Remarks() As String
            Get
                Return sRemarks
            End Get
            Set(ByVal Value As String)
                sRemarks = Value.Trim
            End Set
        End Property
        Property PhoneNumber() As String
            Get
                Return sPhoneNumber
            End Get
            Set(ByVal Value As String)
                sPhoneNumber = Value.Trim
            End Set
        End Property
        Property ContactPerson() As String
            Get
                Return sContactPerson
            End Get
            Set(ByVal Value As String)
                sContactPerson = Value.Trim
            End Set
        End Property
        Property Consignee() As String
            Get
                Return sConsignee
            End Get
            Set(ByVal Value As String)
                sConsignee = Value.Trim
            End Set
        End Property
        Property Type() As String
            Get
                Return sType
            End Get
            Set(ByVal Value As String)
                sType = Value.Trim
                Select Case sType
                    Case "Indent"
                        intStage = 1
                    Case "Demand"
                        intStage = 2
                    Case "Enquiry"
                        intStage = 3
                    Case "PO"
                        intStage = 4
                    Case "LastPO"
                        intStage = 4
                    Case "RN"
                        intStage = 5
                    Case Else
                        intStage = 0
                End Select
            End Set
        End Property
        Property PO() As String
            Get
                Return sPO
            End Get
            Set(ByVal Value As String)
                sPO = Value.Trim
            End Set
        End Property
        Property PODD() As String
            Get
                Return sPODD
            End Get
            Set(ByVal Value As String)
                sPODD = Value.Trim
            End Set
        End Property
        Property POSup() As String
            Get
                Return sPOSup
            End Get
            Set(ByVal Value As String)
                sPOSup = Value.Trim
            End Set
        End Property
        Property EARES() As String
            Get
                Return sEARES
            End Get
            Set(ByVal Value As String)
                sEARES = Value.Trim
            End Set
        End Property
        Property Equip() As String
            Get
                Return sEquip
            End Get
            Set(ByVal Value As String)
                sEquip = Value.Trim
            End Set
        End Property
        Property SlNo() As String
            Get
                Return sSlNo.Trim
            End Get
            Set(ByVal Value As String)
                sSlNo = Value
            End Set
        End Property
        Property PLNumber() As String
            Get
                Return sPLNumber
            End Get
            Set(ByVal Value As String)
                If Value.Trim.Length <> 8 Then
                    Throw New Exception("InValid PL Number ! ")
                Else
                    sPLNumber = Value
                End If
            End Set
        End Property
#End Region
#Region "Methods "
        Private Sub iniVals()
            dQtyReq = 0
            sQtyDesc = ""
            dExistingQty = 0
            sUnitName = ""
            dRecoupQty = 0
            sRecoupType = ""
            dateReqDate = "1900-01-01"
            lRecID = 0
            sMessage = ""
            sPLNumber = ""
            sSlNo = ""
            sEARES = ""
            sEquip = ""
            sType = ""
            sPO = ""
            sPODD = ""
            sPOSup = ""
            sRemarks = ""
            sPhoneNumber = ""
            sContactPerson = ""
            sConsignee = ""
            sStatus = ""
            blnDeleteStatus = False
            blnSelected = False
            datePODt = "1900-01-01"
            dateLastIssueDate = "1900-01-01"
            dateStatusDate = "1900-01-01"
            intPOQty = "0"
            intRecdQty = "0"
            intQtyUT = "0"
            intQtyDue = "0"
            intStage = "0"
        End Sub
        Private Sub iniProdVals()
            lPLID = 0
            sBOMSource = ""
            sBOMType = ""
            dBOMQty = 0
            dPerDay = 0
            dPerMonth = 0
            dInShop = 0
            dInStore = 0
        End Sub
        Public Sub New()
            iniVals()
        End Sub
        Public Sub New(ByVal Consignee As String)
            If Consignee.Trim.Length <> 4 Then
                Throw New Exception("Invalid Consignee !")
            Else
                iniVals()
                sConsignee = Consignee.Trim
            End If
        End Sub
        Public Sub New(ByVal PL As String, ByVal Consignee As String)
            If PL.Trim.Length <> 8 Then
                Throw New Exception("Invalid PL Number !")
            ElseIf CheckConsignee(Consignee) = 0 Then
                Throw New Exception("Invalid Consignee !")
            Else
                iniVals()
                iniProdVals()
                sConsignee = Consignee.Trim
            End If
        End Sub
        Public Shared Function CheckConsignee(ByVal Consignee As String) As Integer
            Dim Cmd As System.Data.SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                Cmd.Parameters.Add("@Cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                Cmd.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = Consignee.Trim
                Cmd.CommandText = " select @Cnt = count(*) from code where rtrim(application) = 'PM' and rtrim(code_type) = 'CC' and  rtrim(code) = @Consignee ; "
                If Cmd.Connection.State = ConnectionState.Closed Then Cmd.Connection.Open()
                Cmd.ExecuteScalar()
                CheckConsignee = Cmd.Parameters("@Cnt").Value
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If Cmd.Connection.State = ConnectionState.Open Then Cmd.Connection.Close()
                Cmd.Dispose()
                Cmd = Nothing
            End Try
        End Function
        Public Function Save(Optional ByVal RecID As Long = 0, Optional ByVal Delete As Boolean = False) As Boolean
            Dim blnDone As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Parameters.Add("@PlNumber", SqlDbType.VarChar, 8).Value = sPLNumber
                cmd.Parameters.Add("@SlNo", SqlDbType.VarChar, 10).Value = sSlNo
                cmd.Parameters.Add("@EARES", SqlDbType.VarChar, 20).Value = sEARES
                cmd.Parameters.Add("@Equip", SqlDbType.VarChar, 100).Value = sEquip
                cmd.Parameters.Add("@Type", SqlDbType.VarChar, 20).Value = sType
                cmd.Parameters.Add("@PO", SqlDbType.VarChar, 20).Value = sPO
                cmd.Parameters.Add("@PODt", SqlDbType.SmallDateTime, 4).Value = datePODt
                cmd.Parameters.Add("@POQty", SqlDbType.Int, 4).Value = intPOQty
                cmd.Parameters.Add("@PODD", SqlDbType.VarChar, 20).Value = sPODD
                cmd.Parameters.Add("@Sup", SqlDbType.VarChar, 60).Value = sPOSup
                cmd.Parameters.Add("@RecdQty", SqlDbType.Int, 4).Value = intRecdQty
                cmd.Parameters.Add("@QtyUT", SqlDbType.Int, 4).Value = intQtyUT
                cmd.Parameters.Add("@QtyDue", SqlDbType.Int, 4).Value = intQtyDue
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 1000).Value = sRemarks
                cmd.Parameters.Add("@Status", SqlDbType.VarChar, 20).Value = sStatus
                cmd.Parameters.Add("@DeleteStatus", SqlDbType.Bit, 1).Value = blnDeleteStatus
                cmd.Parameters.Add("@Selected", SqlDbType.Bit, 1).Value = blnSelected
                cmd.Parameters.Add("@PhoneNumber", SqlDbType.VarChar, 50).Value = sPhoneNumber
                cmd.Parameters.Add("@ContactPerson", SqlDbType.VarChar, 50).Value = sContactPerson
                cmd.Parameters.Add("@Stage", SqlDbType.Int, 4).Value = intStage
                cmd.Parameters.Add("@StatusDate", SqlDbType.SmallDateTime, 4).Value = dateStatusDate
                cmd.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = sConsignee
                cmd.Parameters.Add("@RecID", SqlDbType.BigInt, 8).Value = RecID
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                If RecID > 0 Then
                    cmd.Parameters("@SlNo").Direction = ParameterDirection.Input
                    If Delete = False Then
                        CIEdit(cmd)
                    Else
                        CIDelete(cmd)
                    End If
                Else
                    If Delete = False Then CIAdd(cmd)
                End If
                blnDone = True
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
        Private Sub CIAdd(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " insert into dbo.ms_CriticalItemList" & _
                            " ( PLNumber , SlNo , EARES ,  Equip , Type , PO , PODt ,  " & _
                            " POQty , PODD , POSup , RecdQty , QtyUT , QtyDue , Remarks , DeleteStatus , " & _
                            " Selected , PhoneNumber , ContactPerson , Stage , Consignee , Status , LastIssueDate ) " & _
                            " values  ( @PlNumber ,  @SlNo ,  @EARES , " & _
                            " @Equip , @Type ,  @PO , @PODt , @POQty , @PODD ,  " & _
                            " @Sup ,  @RecdQty ,  @QtyUT , @QtyDue ,  " & _
                            " @Remarks , @DeleteStatus , @Selected , @PhoneNumber , @ContactPerson , @Stage , @Consignee , @Status , @StatusDate )"
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Critical Item List error")
            Catch exp As Exception
                Throw New Exception(" Insert into ms_CriticalItemList error " & exp.Message)
            End Try
        End Sub
        Private Sub CIEdit(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " update ms_CriticalItemList set SlNo = @SlNo , EARES = @EARES , Equip = @Equip , " & _
                        " PO = @PO , PODt = @PODt , POQty = @POQty  , PODD = @PODD , POSup = @Sup  ,  " & _
                        " RecdQty = @RecdQty , QtyUT = @QtyUT , QtyDue = @QtyDue , Remarks = @Remarks , " & _
                        " PhoneNumber = @PhoneNumber , ContactPerson = @ContactPerson , Consignee  = @Consignee , Status = @Status , LastIssueDate =  @StatusDate where RecID = @RecID "
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to update Critical Item List details ")
            Catch exp As Exception
                Throw New Exception(" update of ms_CriticalItemList error :  " & exp.Message)
            End Try
        End Sub
        Private Sub CIDelete(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " update  ms_CriticalItemList set DeleteStatus = @DeleteStatus where RecID = @RecID"
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to delete Critical Item List details ")
            Catch exp As Exception
                Throw New Exception(" delete of ms_CriticalItemList error :  " & exp.Message)
            End Try
        End Sub
        Public Function UpdateSelection(ByVal RecID As Long) As Boolean
            Dim Done As Boolean = False
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Parameters.Add("@Selected", SqlDbType.Bit, 1).Value = blnSelected
                cmd.Parameters.Add("@RecID", SqlDbType.BigInt, 8).Value = RecID
                cmd.CommandText = " update  ms_CriticalItemList set Selected = @Selected where RecID = @RecID"
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                If cmd.ExecuteNonQuery > 0 Then Done = True
            Catch exp As Exception
                Throw New Exception(" delete of ms_CriticalItemList error :  " & exp.Message)
            Finally
                If Done = True Then
                    cmd.Transaction.Commit()
                Else
                    cmd.Transaction.Rollback()
                End If
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
            Return Done
        End Function
        Public Function UpdateBulkSelection(ByVal Consignee As String, ByVal RecIDString As String) As Boolean
            Dim Done As Boolean = False
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Parameters.Add("@Selected", SqlDbType.Bit, 1).Value = True
                cmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                cmd.CommandText = " update  ms_CriticalItemList set Selected = @Selected where Consignee = '" & Consignee.Trim & "'  and  RecID in " & "(" & RecIDString.Trim & ")"
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                If cmd.ExecuteNonQuery > 0 Then
                    cmd.CommandText = " select @cnt = count(*) from  ms_CriticalItemList where Consignee = '" & Consignee.Trim & "'  and  RecID not in " & "(" & RecIDString.Trim & ")"
                    cmd.ExecuteScalar()
                    If IIf(IsDBNull(cmd.Parameters("@cnt").Value), 0, cmd.Parameters("@cnt").Value) > 0 Then
                        cmd.CommandText = " update  ms_CriticalItemList set Selected = @Selected where Consignee = '" & Consignee.Trim & "'  and  RecID not in " & "(" & RecIDString.Trim & ")"
                        cmd.Parameters("@Selected").Value = False
                        If cmd.ExecuteNonQuery > 0 Then Done = True
                    Else
                        Done = True
                    End If
                End If
            Catch exp As Exception
                Throw New Exception(" delete of ms_CriticalItemList error :  " & exp.Message)
            Finally
                If Done = True Then
                    cmd.Transaction.Commit()
                Else
                    cmd.Transaction.Rollback()
                End If
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
            Return Done
        End Function
        Public Function UpdateBulkDeletion(ByVal Consignee As String, ByVal RecIDString As String) As Boolean
            Dim Done As Boolean = False
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.CommandText = " delete  ms_CriticalItemList where Consignee = '" & Consignee.Trim & "'  and  RecID in " & "(" & RecIDString.Trim & ")"
            Try
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                If cmd.ExecuteNonQuery > 0 Then Done = True
            Catch exp As Exception
                Throw New Exception(" delete of ms_CriticalItemList error :  " & exp.Message)
            Finally
                If Done = True Then
                    cmd.Transaction.Commit()
                Else
                    cmd.Transaction.Rollback()
                End If
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
            Return Done
        End Function
        Public Function SaveConsignee(ByVal Consignee As String, Optional ByVal lRecID As Long = 0, Optional ByVal Delete As Boolean = False, Optional ByVal UndoDelete As Boolean = False) As Boolean
            Dim blnDone As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Parameters.Add("@PlNumber", SqlDbType.VarChar, 8).Value = sPLNumber
                cmd.Parameters.Add("@SlNo", SqlDbType.VarChar, 10).Value = sSlNo
                cmd.Parameters.Add("@EARES", SqlDbType.VarChar, 20).Value = sEARES
                cmd.Parameters.Add("@Equip", SqlDbType.VarChar, 50).Value = sEquip
                cmd.Parameters.Add("@Type", SqlDbType.VarChar, 20).Value = sType
                cmd.Parameters.Add("@PO", SqlDbType.VarChar, 20).Value = sPO
                cmd.Parameters.Add("@PODt", SqlDbType.SmallDateTime, 4).Value = datePODt
                cmd.Parameters.Add("@POQty", SqlDbType.Int, 4).Value = intPOQty
                cmd.Parameters.Add("@PODD", SqlDbType.VarChar, 20).Value = sPODD
                cmd.Parameters.Add("@Sup", SqlDbType.VarChar, 60).Value = sPOSup
                cmd.Parameters.Add("@RecdQty", SqlDbType.Int, 4).Value = intRecdQty
                cmd.Parameters.Add("@QtyUT", SqlDbType.Int, 4).Value = intQtyUT
                cmd.Parameters.Add("@QtyDue", SqlDbType.Int, 4).Value = intQtyDue
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 100).Value = sRemarks
                cmd.Parameters.Add("@DeleteStatus", SqlDbType.Bit, 1).Value = blnDeleteStatus
                cmd.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = sConsignee
                cmd.Parameters.Add("@RecID", SqlDbType.BigInt, 8).Value = lRecID
                cmd.Parameters("@RecID").Direction = ParameterDirection.Output
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                If lRecID > 0 Then
                    cmd.Parameters("@RecID").Direction = ParameterDirection.Input
                    If UndoDelete = False Then
                        If Delete = False Then
                            ConsigneeEdit(cmd)
                        Else
                            ConsigneeDelete(cmd)
                        End If
                    Else
                        ConsigneeUndoDelete(cmd)
                    End If
                Else
                    If Delete = False Then ConsigneeAdd(cmd)
                End If
                blnDone = True
            Catch exp As Exception
                sMessage = exp.Message
                Throw New Exception(exp.Message)
            Finally
                If blnDone = True Then
                    cmd.Transaction.Commit()
                Else
                    cmd.Transaction.Rollback()
                End If
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
            Return blnDone
        End Function
        Private Sub ConsigneeAdd(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " insert into ms_CriticalItemListStock  " & _
                        " ( PLNumber , SlNo , [EAR/ES] , LastIssueDate , Equip , Type , PO , PODt ,  " & _
                        " POQty , PODD , POSup , RecdQty , QtyUT , QtyDue , Remarks , DeleteStatus , Consignee) " & _
                        " values  ( @PlNumber ,  @SlNo ,  @EARES , '1900-01-01'," & _
                        " @Equip , @Type ,  @PO , @PODt , @POQty , @PODD ,  " & _
                        " @Sup ,  @RecdQty ,  @QtyUT , @QtyDue ,  " & _
                        " @Remarks , @DeleteStatus , @Consignee )"
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Critical Item List error")
            Catch exp As Exception
                Throw New Exception(" Insert into ms_CriticalItemListStock error " & exp.Message)
            End Try
        End Sub
        Private Sub ConsigneeEdit(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " update ms_CriticalItemListStock set SlNo = @SlNo ,  Equip = @Equip , " & _
                        " PO = @PO , PODt = @PODt , POQty = @POQty  , PODD = @PODD , POSup = @Sup  ,  " & _
                        " RecdQty = @RecdQty , QtyUT = @QtyUT , QtyDue = @QtyDue , Remarks = @Remarks  " & _
                        " where RecID = @RecID "
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to update Critical Item List details ")
            Catch exp As Exception
                Throw New Exception(" update of ms_CriticalItemListStock error :  " & exp.Message)
            End Try
        End Sub
        Private Sub ConsigneeDelete(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " delete  ms_CriticalItemListStock  where RecID = @RecID"
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to delete Critical Item List details ")
            Catch exp As Exception
                Throw New Exception(" delete of ms_CriticalItemListStock error :  " & exp.Message)
            End Try
        End Sub
        Private Sub ConsigneeUndoDelete(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " update  ms_CriticalItemListStock set DeleteStatus = @DeleteStatus where RecID = @RecID"
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to Undo Delete Critical Item List details ")
            Catch exp As Exception
                Throw New Exception(" Undo Delete of ms_CriticalItemListStock error :  " & exp.Message)
            End Try
        End Sub
        Public Function SaveProdConsumableList(ByVal PL As String, ByVal Consignee As String, Optional ByVal lPLID As Long = 0, Optional ByVal Delete As Boolean = False, Optional ByVal UndoDelete As Boolean = False) As Boolean
            Dim blnDone As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Parameters.Add("@PlNumber", SqlDbType.VarChar, 8).Value = sPLNumber
                cmd.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = sConsignee
                cmd.Parameters.Add("@BOMSource", SqlDbType.VarChar, 10).Value = sBOMSource
                cmd.Parameters.Add("@BOMQty", SqlDbType.Float, 8).Value = dBOMQty
                cmd.Parameters.Add("@BOMType", SqlDbType.VarChar, 10).Value = sBOMType
                cmd.Parameters.Add("@PerDay", SqlDbType.Float, 8).Value = dPerDay
                cmd.Parameters.Add("@PerMonth", SqlDbType.Float, 8).Value = dPerMonth
                cmd.Parameters.Add("@InShop", SqlDbType.Float, 8).Value = dInShop
                cmd.Parameters.Add("@InStore", SqlDbType.Float, 8).Value = dInStore
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = sRemarks
                cmd.Parameters.Add("@DeleteStatus", SqlDbType.Bit, 1).Value = blnDeleteStatus
                cmd.Parameters.Add("@Selected", SqlDbType.Bit, 1).Value = blnSelected
                cmd.Parameters.Add("@PLID", SqlDbType.BigInt, 8).Value = lPLID
                cmd.Parameters("@PLID").Direction = ParameterDirection.Output
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                If lPLID > 0 Then
                    cmd.Parameters("@PLID").Direction = ParameterDirection.Input
                    If UndoDelete = False Then
                        If Delete = False Then
                            ProdConsumableListEdit(cmd)
                        Else
                            ProdConsumableListDelete(cmd)
                        End If
                    Else
                        ProdConsumableListUndoDelete(cmd)
                    End If
                Else
                    If Delete = False Then ProdConsumableListAdd(cmd)
                End If
                blnDone = True
            Catch exp As Exception
                sMessage = exp.Message
                Throw New Exception(exp.Message)
            Finally
                If blnDone = True Then
                    cmd.Transaction.Commit()
                Else
                    cmd.Transaction.Rollback()
                End If
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
            Return blnDone
        End Function
        Private Sub ProdConsumableListAdd(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " insert into ms_ProdConsumableList  " & _
                        " ( PLNumber , Consignee , BOMSource , BOMQty , BOMType , PerDay ,  " & _
                        " PerMonth , InShop , InStore , Remarks , DeleteStatus , Selected ) " & _
                        " values  ( @PLNumber , @Consignee , @BOMSource , @BOMQty , @BOMType , @PerDay ," & _
                        " @PerMonth , @InShop , @InStore , @Remarks , @DeleteStatus , @Selected )"
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Consumable List error")
            Catch exp As Exception
                Throw New Exception(" Insert into ms_ProdConsumableList error " & exp.Message)
            End Try
        End Sub
        Private Sub ProdConsumableListEdit(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " update ms_ProdConsumableList set PerDay = @PerDay , BOMQty = @BOMQty , " & _
                        " PerMonth = @PerMonth , InShop = @InShop , InStore = @InStore , Remarks = @Remarks  " & _
                        " , BOMSource = @BOMSource , BOMType = @BOMType  " & _
                        " where PLNumber = @PLNumber and Consignee = @Consignee and PLID = @PLID "
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to update Consumable List details ")
            Catch exp As Exception
                Throw New Exception(" update of ms_ProdConsumableList error :  " & exp.Message)
            End Try
        End Sub
        Private Sub ProdConsumableListDelete(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " update  ms_ProdConsumableList set DeleteStatus = @DeleteStatus where PLID = @PLID"
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to delete Consumable List details ")
            Catch exp As Exception
                Throw New Exception(" delete of ms_ProdConsumableList error :  " & exp.Message)
            End Try
        End Sub
        Private Sub ProdConsumableListUndoDelete(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " update  ms_ProdConsumableList set DeleteStatus = @DeleteStatus where PLID = @PLID"
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to Undo Delete Critical Item List details ")
            Catch exp As Exception
                Throw New Exception(" Undo Delete of ms_ProdConsumableList error :  " & exp.Message)
            End Try
        End Sub
        Public Function ProdConsumableListUpdateSelection(ByVal lPLID As Long) As Boolean
            Dim Done As Boolean = False
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Parameters.Add("@Selected", SqlDbType.Bit, 1).Value = blnSelected
                cmd.Parameters.Add("@PLID", SqlDbType.BigInt, 8).Value = lPLID
                cmd.CommandText = " update  ms_ProdConsumableList set Selected = @Selected where PLID = @PLID"
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                If cmd.ExecuteNonQuery > 0 Then Done = True
            Catch exp As Exception
                Throw New Exception(" delete of ms_ProdConsumableList error :  " & exp.Message)
            Finally
                If Done = True Then
                    cmd.Transaction.Commit()
                Else
                    cmd.Transaction.Rollback()
                End If
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
            Return Done
        End Function
        Public Function SaveProdCriticalList(Optional ByVal lRecID As Long = 0, Optional ByVal Delete As Boolean = False, Optional ByVal UndoDelete As Boolean = False) As Boolean
            Dim blnDone As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Parameters.Add("@PLId", SqlDbType.BigInt, 8).Value = lPLID
                cmd.Parameters.Add("@Type", SqlDbType.VarChar, 20).Value = sType
                cmd.Parameters.Add("@PO", SqlDbType.VarChar, 20).Value = sPO
                cmd.Parameters.Add("@PODt", SqlDbType.SmallDateTime, 4).Value = datePODt
                cmd.Parameters.Add("@POQty", SqlDbType.Int, 4).Value = intPOQty
                cmd.Parameters.Add("@PODD", SqlDbType.VarChar, 20).Value = sPODD
                cmd.Parameters.Add("@Sup", SqlDbType.VarChar, 60).Value = sPOSup
                cmd.Parameters.Add("@RecdQty", SqlDbType.Int, 4).Value = intRecdQty
                cmd.Parameters.Add("@QtyUT", SqlDbType.Int, 4).Value = intQtyUT
                cmd.Parameters.Add("@QtyDue", SqlDbType.Int, 4).Value = intQtyDue
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 100).Value = sRemarks
                cmd.Parameters.Add("@DeleteStatus", SqlDbType.Bit, 1).Value = blnDeleteStatus
                cmd.Parameters.Add("@Selected", SqlDbType.Bit, 1).Value = blnSelected
                cmd.Parameters.Add("@RecID", SqlDbType.BigInt, 8).Value = lRecID
                cmd.Parameters("@RecID").Direction = ParameterDirection.Output
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                If lRecID > 0 Then
                    cmd.Parameters("@RecID").Direction = ParameterDirection.Input
                    If UndoDelete = False Then
                        If Delete = False Then
                            ProdCriticalListEdit(cmd)
                            blnDone = True
                        Else
                            ProdCriticalListDelete(cmd)
                            blnDone = True
                        End If
                    Else
                        ProdCriticalListUndoDelete(cmd)
                        blnDone = True
                    End If
                Else
                    If Delete = False Then
                        ProdCriticalListAdd(cmd)
                        blnDone = True
                    End If
                End If
            Catch exp As Exception
                sMessage = exp.Message
                Throw New Exception(exp.Message)
            Finally
                If blnDone = True Then
                    cmd.Transaction.Commit()
                Else
                    cmd.Transaction.Rollback()
                End If
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
            Return blnDone
        End Function
        Private Sub ProdCriticalListAdd(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " insert into ms_ProdCriticalItemList  " & _
                        " ( PLId , Type , PO , PODt ,  " & _
                        " POQty , PODD , POSup , RecdQty , QtyUT , QtyDue , Remarks , DeleteStatus , Selected) " & _
                        " values  ( @PLId , @Type ,  @PO , @PODt , @POQty , @PODD ,  " & _
                        " @Sup ,  @RecdQty ,  @QtyUT , @QtyDue ,  " & _
                        " @Remarks , @DeleteStatus , @Selected )"
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Consumable List error")
            Catch exp As Exception
                Throw New Exception(" Insert into ms_ProdConsumableList error " & exp.Message)
            End Try
        End Sub
        Private Sub ProdCriticalListEdit(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " update ms_ProdCriticalItemList  " & _
                        " set PO = @PO , PODt = @PODt , POQty = @POQty , PODD = @PODD ,  " & _
                        " POSup = @Sup , RecdQty = @RecdQty , QtyUT = @QtyUT , QtyDue = @QtyDue , Remarks = @Remarks  " & _
                        " where PLId = @PLId and RecID = @RecID "
            Try
                If CMD.ExecuteNonQuery() = 0 Then Throw New Exception(" Unable to update Consumable List details ")
            Catch exp As Exception
                Throw New Exception(" update of ms_ProdCriticalItemList error :  " & exp.Message)
            End Try
        End Sub
        Private Sub ProdCriticalListDelete(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " update  ms_ProdCriticalItemList set DeleteStatus = @DeleteStatus where RecID = @RecID"
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to delete Consumable List details ")
            Catch exp As Exception
                Throw New Exception(" delete of ms_ProdCriticalItemList error :  " & exp.Message)
            End Try
        End Sub
        Private Sub ProdCriticalListUndoDelete(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " update  ms_ProdCriticalItemList set DeleteStatus = @DeleteStatus where RecID = @RecID"
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to Undo Delete Critical Item List details ")
            Catch exp As Exception
                Throw New Exception(" Undo Delete of ms_ProdCriticalItemList error :  " & exp.Message)
            End Try
        End Sub
        Public Function ProdCriticalListUpdateSelection(ByVal lRecID As Long) As Boolean
            Dim Done As Boolean = False
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Parameters.Add("@Selected", SqlDbType.Bit, 1).Value = blnSelected
                cmd.Parameters.Add("@RecID", SqlDbType.BigInt, 8).Value = lRecID
                cmd.CommandText = " update  ms_ProdCriticalItemList set Selected = @Selected where RecID = @RecID"
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                If cmd.ExecuteNonQuery > 0 Then Done = True
            Catch exp As Exception
                Throw New Exception(" delete of ms_ProdConsumableList error :  " & exp.Message)
            Finally
                If Done = True Then
                    cmd.Transaction.Commit()
                Else
                    cmd.Transaction.Rollback()
                End If
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
            Return Done
        End Function
        Public Function SavePLConsignee(ByVal Consignee As String, Optional ByVal lRecID As Long = 0, Optional ByVal Delete As Boolean = False) As Boolean
            Dim blnDone As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@RecID", SqlDbType.BigInt, 8)
            cmd.Parameters("@RecID").Direction = ParameterDirection.Output
            Try
                cmd.Parameters.Add("@PlNumber", SqlDbType.VarChar, 8).Value = sPLNumber
                cmd.Parameters.Add("@SlNo", SqlDbType.Decimal, 10, 3).Value = IIf((sSlNo.Trim = ""), 0.0, sSlNo)
                cmd.Parameters.Add("@EARES", SqlDbType.VarChar, 20).Value = sEARES
                cmd.Parameters.Add("@Equip", SqlDbType.VarChar, 50).Value = sEquip
                cmd.Parameters.Add("@Year", SqlDbType.VarChar, 10).Value = sStatus
                cmd.Parameters.Add("@Type", SqlDbType.VarChar, 20).Value = sType
                cmd.Parameters.Add("@PO", SqlDbType.VarChar, 20).Value = sPO
                cmd.Parameters.Add("@PODt", SqlDbType.VarChar, 15).Value = sPOdate
                cmd.Parameters.Add("@POQty", SqlDbType.Int, 4).Value = IIf((intPOQty.ToString.Trim = ""), 0, intPOQty)
                cmd.Parameters.Add("@PODD", SqlDbType.VarChar, 20).Value = sPODD
                cmd.Parameters.Add("@Sup", SqlDbType.VarChar, 60).Value = sPOSup
                cmd.Parameters.Add("@RecdQty", SqlDbType.Int, 4).Value = IIf((intRecdQty.ToString.Trim = ""), 0, intRecdQty)
                cmd.Parameters.Add("@QtyUT", SqlDbType.Int, 4).Value = IIf((intQtyUT.ToString.Trim = ""), 0, intQtyUT)
                cmd.Parameters.Add("@QtyDue", SqlDbType.Int, 4).Value = IIf((intQtyDue.ToString.Trim = ""), 0, intQtyDue)
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 100).Value = sRemarks
                cmd.Parameters.Add("@DeleteStatus", SqlDbType.Bit, 1).Value = blnDeleteStatus
                cmd.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = sConsignee
                cmd.Parameters("@RecID").Value = lRecID
                cmd.Parameters.Add("@ItemDate", SqlDbType.SmallDateTime, 4).Value = dateLastIssueDate
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
                If lRecID > 0 Then
                    cmd.Parameters("@RecID").Direction = ParameterDirection.Input
                    If Delete = False Then
                        PlConsigneeEdit(cmd)
                    Else
                        PlConsigneeDelete(cmd)
                    End If
                Else
                    If Delete = False Then PlConsigneeAdd(cmd)
                End If
                blnDone = True
            Catch exp As Exception
                sMessage = exp.Message
                Throw New Exception(exp.Message)
            Finally
                If blnDone = True Then
                    cmd.Transaction.Commit()
                Else
                    cmd.Transaction.Rollback()
                End If
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
            Return blnDone
        End Function
        Private Sub PlConsigneeAdd(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " insert into ms_MaterialRequirement  " & _
                        " ( PLNumber , QtyReq , [EAR/ES] , Equip , Year , Type , PO , PODt , POQty ,  " & _
                        " PODD , POSup , RecdQty , QtyUT , Remarks ,  Consignee , DeleteStatus , ItemDate ) " & _
                        " values  ( @PlNumber ,  @SlNo ,  @EARES , " & _
                        " @Equip , @Year ,  @Type ,  @PO , @PODt , @POQty , @PODD ,  " & _
                        " @Sup ,  @RecdQty ,  @QtyUT ,   " & _
                        " @Remarks , @Consignee , @DeleteStatus , @ItemDate )"
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Material Requirement Item List error")
            Catch exp As Exception
                Throw New Exception(" Insert into ms_CriticalItemListStock error " & exp.Message)
            End Try
        End Sub
        Private Sub PlConsigneeEdit(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " update ms_MaterialRequirement set QtyReq = @SlNo ,  Equip = @Equip , Year = @Year , Type = @Type , " & _
                        " PO = @PO , PODt = @PODt , POQty = @POQty  , PODD = @PODD , POSup = @Sup  ,  " & _
                        " RecdQty = @RecdQty , QtyUT = @QtyUT , Remarks = @Remarks , ItemDate = @ItemDate " & _
                        " where RecID = @RecID "
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to update Material Requirement Item List details ")
            Catch exp As Exception
                Throw New Exception(" update of ms_MaterialRequirement error :  " & exp.Message)
            End Try
        End Sub
        Private Sub PlConsigneeDelete(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " delete  ms_MaterialRequirement where RecID = @RecID"
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to delete Material Requirement Item List details ")
            Catch exp As Exception
                Throw New Exception(" delete of ms_MaterialRequirement error :  " & exp.Message)
            End Try
        End Sub
        Public Function SavePLRecoupDetails(ByVal Consignee As String, ByVal PL As String, Optional ByVal lRecID As Long = 0, Optional ByVal Delete As Boolean = False) As Boolean
            Dim blnDone As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@RecID", SqlDbType.BigInt, 8)
            cmd.Parameters("@RecID").Direction = ParameterDirection.Output
            Try
                cmd.Parameters.Add("@PlNumber", SqlDbType.VarChar, 8).Value = sPLNumber
                cmd.Parameters.Add("@ReqDate", SqlDbType.SmallDateTime, 4).Value = dateReqDate
                cmd.Parameters.Add("@RecoupType", SqlDbType.VarChar, 3).Value = sRecoupType
                cmd.Parameters.Add("@RecoupQty", SqlDbType.Float, 8).Value = dRecoupQty
                cmd.Parameters.Add("@UnitName", SqlDbType.VarChar, 10).Value = sUnitName
                cmd.Parameters.Add("@ExistingQty", SqlDbType.Float, 8).Value = dExistingQty
                cmd.Parameters.Add("@QtyDesc", SqlDbType.VarChar, 200).Value = sQtyDesc
                cmd.Parameters.Add("@QtyReq", SqlDbType.Float, 8).Value = dQtyReq
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 100).Value = sRemarks
                cmd.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = sConsignee
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
                If lRecID > 0 Then
                    cmd.Parameters("@RecID").Direction = ParameterDirection.Input
                    cmd.Parameters("@RecID").Value = lRecID
                    If Delete = False Then
                        PLRecoupDetailsUpdate(cmd)
                    Else
                        PLRecoupDetailsDelete(cmd)
                    End If
                Else
                    If Delete = False Then PLRecoupDetailsAdd(cmd)
                End If
                blnDone = True
            Catch exp As Exception
                sMessage = exp.Message
                Throw New Exception(exp.Message)
            Finally
                If blnDone = True Then
                    cmd.Transaction.Commit()
                Else
                    cmd.Transaction.Rollback()
                End If
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
            Return blnDone
        End Function
        Private Sub PLRecoupDetailsAdd(ByVal cmd As SqlClient.SqlCommand)
            cmd.CommandText = " insert into ms_PLRecoupDetails  " & _
                                    " ( ReqDate , pl_number , RecoupType , RecoupQty , UnitName ,  " & _
                                    "   ExistingQty , QtyDesc , QtyReq , Remarks , Consignee ) " & _
                                    " values  ( @ReqDate , @PlNumber ,  @RecoupType ,  @RecoupQty , " & _
                                    " @UnitName , @ExistingQty ,  @QtyDesc ,  @QtyReq , @Remarks , @Consignee )"
            Try
                If cmd.ExecuteNonQuery = 0 Then Throw New Exception(" PL Recoup Detailst adding error")
            Catch exp As Exception
                Throw New Exception(" Insert into PLRecoupDetails error " & exp.Message)
            End Try
        End Sub
        Private Sub PLRecoupDetailsDelete(ByVal cmd As SqlClient.SqlCommand)
            cmd.CommandText = " delete ms_PLRecoupDetails  " & _
                                    " where pl_number =  @PlNumber and SlNo = @RecID " & _
                                    " and Consignee =  @Consignee "
            Try
                If cmd.ExecuteNonQuery = 0 Then Throw New Exception(" PL Recoup Detailst adding error")
            Catch exp As Exception
                Throw New Exception(" Insert into PLRecoupDetails error " & exp.Message)
            End Try
        End Sub
        Private Sub PLRecoupDetailsUpdate(ByVal cmd As SqlClient.SqlCommand)
            cmd.CommandText = " update ms_PLRecoupDetails  " & _
                    " set ReqDate = @ReqDate , ExistingQty = @ExistingQty , QtyReq = @QtyReq , Remarks = @Remarks " & _
                    " where pl_number =  @PlNumber and SlNo = @RecID " & _
                    " and Consignee =  @Consignee "
            Try
                If cmd.ExecuteNonQuery = 0 Then Throw New Exception(" PL Recoup Detailst adding error")
            Catch exp As Exception
                Throw New Exception(" Insert into PLRecoupDetails error " & exp.Message)
            End Try
        End Sub
#End Region
    End Class
    Public Class StockIDNS
        Private sIDNNumber, sPLNumber, sPONumber, sSupplierCode, sRemarks, sConsignee, sMessage As String
        Private dateIdnDate, dateReceivedDate, dateClearedDate As Date
        Private lIDNid As Long
        Private blnDeleteStatus As Boolean
#Region "Property "
        Property DeleteStatus() As Boolean
            Get
                Return blnDeleteStatus
            End Get
            Set(ByVal Value As Boolean)
                blnDeleteStatus = Value
            End Set
        End Property
        Property IDNid() As Long
            Get
                Return lIDNid
            End Get
            Set(ByVal Value As Long)
                lIDNid = Value
            End Set
        End Property
        Property ClearedDate() As Date
            Get
                Return dateClearedDate
            End Get
            Set(ByVal Value As Date)
                dateClearedDate = Value
            End Set
        End Property
        Property ReceivedDate() As Date
            Get
                Return dateReceivedDate
            End Get
            Set(ByVal Value As Date)
                dateReceivedDate = Value
            End Set
        End Property
        Property IdnDate() As Date
            Get
                Return dateIdnDate
            End Get
            Set(ByVal Value As Date)
                dateIdnDate = Value
            End Set
        End Property
        Property Message() As String
            Get
                Return sMessage
            End Get
            Set(ByVal Value As String)
                sMessage = Value
            End Set
        End Property
        Property Consignee() As String
            Get
                Return sConsignee
            End Get
            Set(ByVal Value As String)
                sConsignee = Value
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
        Property SupplierCode() As String
            Get
                Return sSupplierCode
            End Get
            Set(ByVal Value As String)
                If Value.Trim.Length <> 8 Then
                    Throw New Exception("InValid SupplierCode !")
                Else
                    sSupplierCode = Value
                End If
            End Set
        End Property
        Property PONumber() As String
            Get
                Return sPONumber
            End Get
            Set(ByVal Value As String)
                If Value.Trim.Length <> 9 Then
                    Throw New Exception("InValid PONumber !")
                Else
                    sPONumber = Value
                End If
            End Set
        End Property
        Property PLNumber() As String
            Get
                Return sPLNumber
            End Get
            Set(ByVal Value As String)
                If Value.Trim.Length <> 8 Then
                    Throw New Exception("InValid PLNumber !")
                Else
                    sPLNumber = Value
                End If
            End Set
        End Property
        Property IDNNumber() As String
            Get
                Return sIDNNumber
            End Get
            Set(ByVal Value As String)
                If Value.Trim.Length <> 9 Then
                    Throw New Exception("InValid IDNNumber !")
                Else
                    sIDNNumber = Value
                End If
            End Set
        End Property
#End Region
#Region "Methods "
        Private Sub iniVals()
            sIDNNumber = ""
            sPLNumber = ""
            sPONumber = ""
            sSupplierCode = ""
            sRemarks = ""
            sConsignee = ""
            sMessage = ""
            dateIdnDate = "1900-01-01"
            dateReceivedDate = "1900-01-01"
            dateClearedDate = "1900-01-01"
            lIDNid = 0

        End Sub
        Public Sub New(ByVal Consignee As String)
            If CheckConsignee(Consignee) = 0 Then
                Throw New Exception("Invalid Consignee !")
            Else
                iniVals()
                sConsignee = Consignee.Trim
            End If
        End Sub
        Public Shared Function CheckConsignee(ByVal Consignee As String) As Integer
            Dim Cmd As System.Data.SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                Cmd.Parameters.Add("@Cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                Cmd.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = Consignee.Trim
                Cmd.CommandText = " select @Cnt = count(*) from code where rtrim(application) = 'PM' and rtrim(code_type) = 'CC' and  rtrim(code) = @Consignee ; "
                If Cmd.Connection.State = ConnectionState.Closed Then Cmd.Connection.Open()
                Cmd.ExecuteScalar()
                CheckConsignee = Cmd.Parameters("@Cnt").Value
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If Cmd.Connection.State = ConnectionState.Open Then Cmd.Connection.Close()
                Cmd.Dispose()
                Cmd = Nothing
            End Try
        End Function
        Public Function SaveIDNs(Optional ByVal lIDNid As Long = 0, Optional ByVal Delete As Boolean = False, Optional ByVal UndoDelete As Boolean = False) As Boolean
            Dim blnDone As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Parameters.Add("@IDNNumber", SqlDbType.VarChar, 9).Value = sIDNNumber
                cmd.Parameters.Add("@IdnDate", SqlDbType.SmallDateTime, 4).Value = dateIdnDate
                cmd.Parameters.Add("@PlNumber", SqlDbType.VarChar, 8).Value = sPLNumber
                cmd.Parameters.Add("@PONumber", SqlDbType.VarChar, 9).Value = sPONumber
                cmd.Parameters.Add("@SupplierCode", SqlDbType.VarChar, 8).Value = sSupplierCode
                cmd.Parameters.Add("@ReceivedDate", SqlDbType.SmallDateTime, 4).Value = dateReceivedDate
                cmd.Parameters.Add("@ClearedDate", SqlDbType.SmallDateTime, 4).Value = dateClearedDate
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 100).Value = sRemarks
                cmd.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = sConsignee
                cmd.Parameters.Add("@DeleteStatus", SqlDbType.Bit, 1).Value = blnDeleteStatus
                cmd.Parameters.Add("@IDNid", SqlDbType.BigInt, 8).Value = lIDNid
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                If lIDNid > 0 Then
                    cmd.Parameters("@IDNid").Direction = ParameterDirection.Input
                    If UndoDelete = False Then
                        If Delete = False Then
                            IDNsEdit(cmd)
                            blnDone = True
                        Else
                            IDNsDelete(cmd)
                            blnDone = True
                        End If
                    Else
                        IDNsUndoDelete(cmd)
                        blnDone = True
                    End If
                Else
                    If Delete = False Then IDNsAdd(cmd)
                    blnDone = True
                End If
            Catch exp As Exception
                sMessage = exp.Message
                Throw New Exception(exp.Message)
            Finally
                If blnDone = True Then
                    cmd.Transaction.Commit()
                Else
                    cmd.Transaction.Rollback()
                End If
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
            Return blnDone
        End Function
        Private Sub IDNsAdd(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " insert into dbo.ms_StockIDNStatusList" & _
                            " ( idn_number , idn_date , pl_number , po_number , supplier_code , ReceivedDate ,   " & _
                            " ClearedDate , Remarks , Consignee , DeleteStatus ) " & _
                            " values  ( @IDNNumber , @IdnDate , @PlNumber ,  @PONumber ,  @SupplierCode , @ReceivedDate , " & _
                            " @ClearedDate , @Remarks , @Consignee , @DeleteStatus )"
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Stock IDNs List error")
            Catch exp As Exception
                Throw New Exception(" Insert into ms_StockIDNStatusList error " & exp.Message)
            End Try
        End Sub
        Private Sub IDNsEdit(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " update ms_StockIDNStatusList set ReceivedDate = @ReceivedDate , " & _
                              " ClearedDate = @ClearedDate , Remarks = @Remarks  where IDNid = @IDNid "
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to update Stock IDNs List details ")
            Catch exp As Exception
                Throw New Exception(" update of ms_StockIDNStatusList error :  " & exp.Message)
            End Try
        End Sub
        Private Sub IDNsDelete(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " update  ms_StockIDNStatusList set DeleteStatus = @DeleteStatus where IDNid = @IDNid"
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to delete IDNs List details ")
            Catch exp As Exception
                Throw New Exception(" delete of ms_StockIDNStatusList error :  " & exp.Message)
            End Try
        End Sub
        Private Sub IDNsUndoDelete(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " update  ms_StockIDNStatusList set DeleteStatus = @DeleteStatus where IDNid = @IDNid"
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to Undo Delete Critical Item List details ")
            Catch exp As Exception
                Throw New Exception(" Undo Delete of ms_CriticalItemListStock error :  " & exp.Message)
            End Try
        End Sub
        Public Function DeleteStockIDNStatusListItems(ByVal ItemsID As Double, ByVal IDNid As Double) As Boolean
            Dim oCmd As New SqlClient.SqlCommand()
            oCmd.Connection = rwfGen.Connection.ConObj
            Dim done As New Boolean()
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                oCmd.CommandText = " delete ms_StockIDNStatusListItems " & _
                            " where ItemsID =  @ItemsID and IDNid = @IDNid "
                oCmd.Parameters.Add("@ItemsID", SqlDbType.BigInt, 8).Value = ItemsID
                oCmd.Parameters.Add("@IDNid", SqlDbType.BigInt, 8).Value = IDNid
                If oCmd.ExecuteNonQuery > 0 Then done = True
            Catch exp As Exception
                done = False
                Throw New Exception(exp.Message)
            Finally
                If done Then
                    oCmd.Transaction.Commit()
                Else
                    oCmd.Transaction.Rollback()
                End If
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
            Return done
        End Function
        Public Function StockIDNStatusListItems(ByVal IDNs As Double, ByVal UsedDate As Date, ByVal FromHeat As Double, ByVal ToHeat As Double, ByVal QtyTested As Decimal, ByVal Remarks As String, ByVal UsedToDate As Date, Optional ByVal ItemsID As Double = 0) As Double
            Dim oCmd As New SqlClient.SqlCommand()
            oCmd.Connection = rwfGen.Connection.ConObj
            Dim done As New Boolean()
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                oCmd.CommandText = "insert into ms_StockIDNStatusListItems " & _
                            " ( IDNid , UsedDate , FromHeat , ToHeat , QtyTested , Remarks , UsedToDate ) " & _
                            " values ( @IDNid , @UsedDate , @FromHeat , @ToHeat , @QtyTested , @Remarks , @UsedToDate ) "
                oCmd.Parameters.Add("@ItemsID", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
                oCmd.Parameters.Add("@IDNid", SqlDbType.BigInt, 8).Value = IDNs
                oCmd.Parameters.Add("@UsedDate", SqlDbType.SmallDateTime, 4).Value = UsedDate
                oCmd.Parameters.Add("@UsedToDate", SqlDbType.SmallDateTime, 4).Value = UsedToDate
                oCmd.Parameters.Add("@FromHeat", SqlDbType.Float, 8).Value = FromHeat
                oCmd.Parameters.Add("@ToHeat", SqlDbType.Float, 8).Value = ToHeat
                oCmd.Parameters.Add("@QtyTested", SqlDbType.Float, 8).Value = QtyTested
                oCmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = Remarks '
                If ItemsID = 0 Then
                    If oCmd.ExecuteNonQuery > 0 Then
                        oCmd.CommandText = " select @ItemsID = ItemsID from ms_StockIDNStatusListItems " & _
                                        " where  IDNid = @IDNid and UsedDate = @UsedDate and  " & _
                                        " FromHeat = @FromHeat and  ToHeat = @ToHeat and  QtyTested = @QtyTested and  Remarks =  @Remarks "
                        oCmd.ExecuteScalar()
                        ItemsID = IIf(IsDBNull(oCmd.Parameters("@ItemsID").Value), 0, oCmd.Parameters("@ItemsID").Value)
                        done = True
                    End If
                Else
                    oCmd.CommandText = "update ms_StockIDNStatusListItems " & _
                       " set UsedDate = @UsedDate , FromHeat = @FromHeat , ToHeat = @ToHeat , UsedToDate = @UsedToDate , " & _
                       " QtyTested = @QtyTested , Remarks = @Remarks where ItemsID =  @ItemsID and IDNid = @IDNid "
                    oCmd.Parameters("@ItemsID").Direction = ParameterDirection.Input
                    oCmd.Parameters("@ItemsID").Value = ItemsID
                    If oCmd.ExecuteNonQuery = 1 Then done = True
                End If
            Catch exp As Exception
                done = False
                Throw New Exception("Adding of StockIDNStatusListItems values failed ; " & exp.Message)
            Finally
                If done Then
                    oCmd.Transaction.Commit()
                Else
                    oCmd.Transaction.Rollback()
                End If
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
            Return ItemsID
        End Function
        Public Function SandUsage(ByVal PONo As String, ByVal FromHeat As Double, ByVal ToHeat As Double, ByVal Remarks As String, Optional ByVal ItemsID As Double = 0, Optional ByVal Delete As Boolean = False) As Boolean
            Dim oCmd As New SqlClient.SqlCommand()
            oCmd.Connection = rwfGen.Connection.ConObj
            Dim done As New Boolean()
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                If Delete = False Then
                    oCmd.Parameters.Add("@FromHeat", SqlDbType.BigInt, 8).Value = FromHeat
                    oCmd.Parameters.Add("@ToHeat", SqlDbType.BigInt, 8).Value = ToHeat
                    oCmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = Remarks
                    oCmd.Parameters.Add("@PONo", SqlDbType.VarChar, 50).Value = PONo
                End If
                If ItemsID > 0 Then
                    oCmd.Parameters.Add("@ItemsID", SqlDbType.BigInt, 8).Value = ItemsID
                    If Delete Then
                        oCmd.CommandText = " delete ms_SandUsage where ItemsID = @ItemsID "
                    Else
                        oCmd.CommandText = " update ms_SandUsage " & _
                            " set FromHeat = @FromHeat , ToHeat = @ToHeat , " & _
                            " Remarks = @Remarks where ItemsID = @ItemsID and PONo = @PONo "
                    End If
                Else
                    oCmd.CommandText = " insert into ms_SandUsage " & _
                                " ( FromHeat , ToHeat , Remarks , PONo ) values " & _
                                " ( @FromHeat , @ToHeat , @Remarks , @PONo ) "
                End If
                If oCmd.ExecuteNonQuery > 0 Then done = True
            Catch exp As Exception
                done = False
                Throw New Exception(exp.Message)
            Finally
                If done Then
                    oCmd.Transaction.Commit()
                Else
                    oCmd.Transaction.Rollback()
                End If
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
            Return done
        End Function
#End Region
    End Class
End Namespace