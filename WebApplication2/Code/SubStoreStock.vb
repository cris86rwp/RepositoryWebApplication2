Namespace SubStoreStock
#Region "  tables "
    Public Class Tables
        Public Shared Function plDesc(ByVal pl_number As String) As String
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@pl_number", SqlDbType.VarChar, 50).Value = pl_number.Trim
            cmd.Parameters.Add("@plDesc", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            cmd.CommandText = " select @plDesc = rtrim(short_description) + ' Unit : ' + rtrim(UnitName) " & _
                " from  pm_itemmaster where pl_number = @pl_number "
            Try
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.ExecuteScalar()
                plDesc = IIf(IsDBNull(cmd.Parameters("@plDesc").Value), "", cmd.Parameters("@plDesc").Value)
            Catch exp As Exception
                plDesc = ""
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
            End Try
        End Function
        Public Shared Function plIssues(ByVal Consignee As String, ByVal PLnumber As String, ByVal FromDate As Date, ByVal ToDate As Date) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@Consignee", SqlDbType.VarChar, 10).Value = Consignee.Trim
            da.SelectCommand.Parameters.Add("@PLnumber", SqlDbType.VarChar, 10).Value = PLnumber.Trim
            da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.SmallDateTime, 4).Value = FromDate
            da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.SmallDateTime, 4).Value = ToDate
            da.SelectCommand.CommandText = "select * from wap.dbo.ms_fn_plIssue(@PLnumber,@Consignee, @FromDate , @ToDate)"
            Try
                da.Fill(ds)
                plIssues = ds.Tables(0)
            Catch exp As Exception
                plIssues = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function plReceipt(ByVal Consignee As String, ByVal PLnumber As String, ByVal FromDate As Date, ByVal ToDate As Date) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@Consignee", SqlDbType.VarChar, 10).Value = Consignee.Trim
            da.SelectCommand.Parameters.Add("@PLnumber", SqlDbType.VarChar, 10).Value = PLnumber.Trim
            da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.SmallDateTime, 4).Value = FromDate
            da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.SmallDateTime, 4).Value = ToDate
            da.SelectCommand.CommandText = "select * from wap.dbo.ms_fn_plReceipt(@PLnumber,@Consignee, @FromDate , @ToDate)"
            Try
                da.Fill(ds)
                plReceipt = ds.Tables(0)
            Catch exp As Exception
                plReceipt = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function ShopStock(ByVal Consignee As String, ByVal PLnumber As String) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@PLnumber", SqlDbType.VarChar, 10).Value = PLnumber.Trim
            da.SelectCommand.Parameters.Add("@Consignee", SqlDbType.VarChar, 10).Value = Consignee.Trim
            da.SelectCommand.CommandText = " select  a.consignee_code Cons , a.pl_no , b.short_description ItemDesc , " & _
                " a.type_of_store StoreType , a.location ,  a.opening_balance stock , b.Unitname " & _
                " from ms_stock_master a inner join pm_itemmaster b on b.pl_number = a.pl_no " & _
                " where  a.pl_no = @PLnumber  and a.consignee_code = @Consignee "
            Try
                da.Fill(ds)
                ShopStock = ds.Tables(0)
            Catch exp As Exception
                ShopStock = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function countPl(ByVal Consignee As String, ByVal PLnumber As String, Optional ByVal FromDate As Date = #1/1/1900#, Optional ByVal ToDate As Date = #1/1/1900#, Optional ByVal Master As Int16 = 0) As Integer
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@Consignee", SqlDbType.VarChar, 8).Value = Consignee.Trim
            cmd.Parameters.Add("@PLnumber", SqlDbType.VarChar, 9).Value = PLnumber.Trim
            cmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            Try
                If FromDate = #1/1/1900# Then
                    cmd.CommandText = " select @cnt = count(*) from ms_stock_trans " & _
                        " where consignee_code = @Consignee and pl_no = @PLnumber "
                Else
                    If Master = 0 Then
                        cmd.CommandText = " select @cnt = count(*) from ms_stock_trans " & _
                            " where consignee_code = @Consignee and pl_no = @PLnumber " & _
                            " AND transcation_date between @FromDate and @ToDate "
                        cmd.Parameters.Add("@FromDate", SqlDbType.SmallDateTime, 4).Value = FromDate
                        cmd.Parameters.Add("@ToDate", SqlDbType.SmallDateTime, 4).Value = ToDate
                    Else
                        cmd.CommandText = " select @cnt = count(*) from pm_itemmaster where pl_number = @PLnumber "
                    End If
                End If
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.ExecuteScalar()
                countPl = IIf(IsDBNull(cmd.Parameters("@cnt").Value), 0, cmd.Parameters("@cnt").Value)
            Catch exp As Exception
                countPl = ""
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
            End Try
        End Function
        Public Shared Function ShopStock(ByVal PLnumber As String) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@PLnumber", SqlDbType.VarChar, 10).Value = PLnumber.Trim
            da.SelectCommand.CommandText = "select * from wap.dbo.ms_fn_AllShopStock(@PLnumber)"
            Try
                da.Fill(ds)
                ShopStock = ds.Tables(0)
            Catch exp As Exception
                ShopStock = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function ConCode(ByVal UserID As String) As String
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@UserID", SqlDbType.VarChar, 8).Value = UserID.Trim
            cmd.Parameters.Add("@ConCode", SqlDbType.VarChar, 11).Direction = ParameterDirection.Output
            cmd.CommandText = " select @ConCode = description from ms_group_location " & _
                " where purpose = 'Sub-Stores' and group_code = (select group_code " & _
                " from mis.dbo.menu_your_password where employee_code = @UserID and application = 'MSS' " & _
                " and group_code <> 'SUBSTO' ) "
            Try
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.ExecuteScalar()
                ConCode = IIf(IsDBNull(cmd.Parameters("@ConCode").Value), "", cmd.Parameters("@ConCode").Value)
            Catch exp As Exception
                ConCode = ""
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
            End Try
        End Function
        Public Shared Function GetTop1Dt(ByVal Group As String) As String
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@Group", SqlDbType.VarChar, 8).Value = Group.Trim
            cmd.Parameters.Add("@Dt", SqlDbType.VarChar, 11)
            cmd.Parameters("@Dt").Direction = ParameterDirection.Output
            cmd.CommandText = "select  @Dt = convert(varchar(11),max(Dt),103) from ms_Top1OutstandingPlDetails where MachineGroup = @Group "
            Try
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.ExecuteScalar()
                GetTop1Dt = IIf(IsDBNull(cmd.Parameters("@Dt").Value), "", cmd.Parameters("@Dt").Value)
            Catch exp As Exception
                GetTop1Dt = ""
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
            End Try
        End Function
        Public Shared Function GetPLsAndMachDetails(ByVal machine_group As String, ByVal Fr As Date, ByVal ToDt As Date) As DataSet
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@machine_group", SqlDbType.VarChar, 6).Value = machine_group.Trim
            da.SelectCommand.Parameters.Add("@Fr", SqlDbType.SmallDateTime, 4).Value = CDate(Fr)
            da.SelectCommand.Parameters.Add("@To", SqlDbType.SmallDateTime, 4).Value = CDate(ToDt)
            da.SelectCommand.CommandText = " select distinct a.MachineCode from ms_Top1OutstandingPlDetails a inner join ms_MachineryMaster b " & _
                        " on a.MachineGroup = b.GroupCode and ltrim(rtrim(a.MachineCode)) = ltrim(rtrim(b.Machine_Code))  " & _
                        " where MachineGroup = @machine_group and Dt between @Fr and @To  and len(ind) > 0 and isnull(Remarks,'') <> ''  order by  a.MachineCode ; " & _
                        " select distinct a.pl_number , a.pl_number+'--'+dbo.ms_fn_PlShortName(a.pl_number) ShName from ms_Top1OutstandingPlDetails a " & _
                        " inner join ms_MachineryMaster b on a.MachineGroup = b.GroupCode and ltrim(rtrim(a.MachineCode)) = ltrim(rtrim(b.Machine_Code))  " & _
                        " where MachineGroup = @machine_group and Dt between @Fr and @To  and len(ind) > 0  and isnull(Remarks,'') <> '' order by a.pl_number  "
            Try
                da.Fill(ds)
                GetPLsAndMachDetails = ds.Copy
            Catch exp As Exception
                GetPLsAndMachDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function GetOilDetails(ByVal Consignee As String) As DataSet
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = Consignee.Trim
            da.SelectCommand.CommandText = " SELECT distinct ms_vw_StoreOilStock.PLNumber , ms_vw_StoreOilStock.PLNumber +'--'+ dbo.ms_fn_PlShortName(ms_vw_StoreOilStock.PLNumber)" & _
                        " FROM wap.dbo.ms_vw_StoreOilStock ms_vw_StoreOilStock WHERE ms_vw_StoreOilStock.Consignee = @Consignee " & _
                        " ORDER BY  ms_vw_StoreOilStock.PLNumber ASC ; " & _
                        " SELECT distinct ms_vw_StoreOilStock.MachineCode , ms_vw_StoreOilStock.MachineCode +'--'+ dbo.ms_fn_MachineShortName(ms_vw_StoreOilStock.MachineCode)" & _
                        " FROM wap.dbo.ms_vw_StoreOilStock ms_vw_StoreOilStock WHERE ms_vw_StoreOilStock.Consignee = @Consignee " & _
                        " ORDER BY  ms_vw_StoreOilStock.MachineCode ASC "
            Try
                da.Fill(ds)
                GetOilDetails = ds.Copy
            Catch exp As Exception
                GetOilDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function TransMachines(ByVal Consignee As String) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = Consignee.Trim
            da.SelectCommand.CommandText = "select distinct MachineCode , description from  ms_vw_StoreStock " & _
                " where Consignee = @Consignee and description is not null ORDER BY description  "
            Try
                da.Fill(ds, "Location")
                TransMachines = ds.Tables("Location")
            Catch exp As Exception
                TransMachines = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function TransPLs(ByVal Consignee As String) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = Consignee.Trim
            da.SelectCommand.CommandText = "select distinct PLNumber, (PLNumber+'--'+ltrim(rtrim(PLDesc))) Descr from  ms_vw_StoreStock where Consignee = @Consignee ORDER BY Descr  "
            Try
                da.Fill(ds, "Location")
                TransPLs = ds.Tables("Location")
            Catch exp As Exception
                TransPLs = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function GetPLDetailsForEdit(ByVal PLNumber As String, ByVal Type As Int16, ByVal GroupCode As String, ByVal Consignee As String) As DataSet
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@PLNumber", SqlDbType.VarChar, 8).Value = PLNumber.Trim
            da.SelectCommand.Parameters.Add("@GroupCode", SqlDbType.VarChar, 10).Value = GroupCode.Trim
            da.SelectCommand.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = Consignee.Trim
            da.SelectCommand.Parameters.Add("@Type", SqlDbType.VarChar, 8).Value = Type
            If Type = 6 Then
                da.SelectCommand.CommandText = " select MlistNumber , Sentence , Unit  from  ms_vw_MListNumber where GroupCode = @GroupCode and Application = 'MSS' ;"
            Else
                da.SelectCommand.CommandText = " select count(pl_number) cnt , dbo.ms_fn_PlLongName(pl_number) PlLongName , dbo.ms_fn_PlUnitName(pl_number) PlUnitName " & _
                                        " from pm_item_master where pl_number = @PLNumber GROUP BY pl_number ;"
            End If
            If Type = 0 Then
                da.SelectCommand.CommandText &= " select convert(varchar(11),TransactionDate , 103 ) RecdDt , c.TypeID  , LedgerNo BinCardNo , PageNo , a.RackID , OrderQty MinBal , " & _
                            " MachineCode , TransactionName TransName ,  TransactionNumber TransNo ,  convert(varchar(11),Dated , 103 ) Dated , " & _
                            " LinkName , TransactionLink LinkNo , convert(varchar(11), LinkDate , 103 ) LinkDate , Remarks , Qty RecQty , Balance , a.PLID , TransID  , PLNumber , b.Rate " & _
                            " from  ms_StoreStock a inner join ms_StoreMaster b on a.PLID = b.PLID " & _
                            " inner join ms_StoreTransactionType c on c.TypeID = a.TypeID " & _
                            " inner join ms_StoreLocation d on d.RackID = a.RackID " & _
                            " where a.PLID = ( select PLID from ms_StoreMaster where PlNumber = @PlNumber and Consignee = @Consignee ) " & _
                            " order by TransactionDate desc ;"
            Else
                da.SelectCommand.CommandText &= " select convert(varchar(11),TransactionDate , 103 ) RecdDt , c.TypeID  , LedgerNo BinCardNo , PageNo , a.RackID , OrderQty MinBal , " & _
                            " MachineCode , TransactionName TransName ,  TransactionNumber TransNo ,  convert(varchar(11),Dated , 103 ) Dated , " & _
                            " LinkName , TransactionLink LinkNo , convert(varchar(11), LinkDate , 103 ) LinkDate , Remarks , Qty RecQty , Balance , a.PLID , TransID  , PLNumber , b.Rate " & _
                            " from  ms_StoreStock a inner join ms_StoreMaster b on a.PLID = b.PLID " & _
                            " inner join ms_StoreTransactionType c on c.TypeID = a.TypeID " & _
                            " inner join ms_StoreLocation d on d.RackID = a.RackID " & _
                            " where a.PLID = ( select PLID from ms_StoreMaster where PlNumber = @PlNumber and Consignee = @Consignee ) " & _
                            " and a.TypeID = @Type order by TransactionDate desc ;"
            End If
            Try
                da.Fill(ds, "MachineIDs")
                GetPLDetailsForEdit = ds.Copy
            Catch exp As Exception
                GetPLDetailsForEdit = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function PODetails(ByVal Consignee As String, ByVal PLNumber As String, ByVal po_number As String) As DataSet
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = Consignee.Trim
            da.SelectCommand.Parameters.Add("@PLNumber", SqlDbType.VarChar, 8).Value = PLNumber.Trim
            da.SelectCommand.Parameters.Add("@po_number", SqlDbType.VarChar, 9).Value = po_number.Trim
            da.SelectCommand.CommandText = "select po_number , convert(varchar(11),po_date , 103) po_date,  convert(varchar(11),order_completion_date , 103) order_completion_date , " & _
                        " po_value , Supplier , pl_number , short_description , po_quantity , UnitName , unit_rate  from ms_vw_NsPoDetails " & _
                        " where po_number = @po_number and consignee = @Consignee and pl_number = @PLNumber  "
            Try
                da.Fill(ds)
                PODetails = ds.Copy
            Catch exp As Exception
                PODetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function S1313Details(ByVal Consignee As String, ByVal PLNumber As String, ByVal ir_number As String) As DataSet
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = Consignee.Trim
            da.SelectCommand.Parameters.Add("@PLNumber", SqlDbType.VarChar, 8).Value = PLNumber.Trim
            da.SelectCommand.Parameters.Add("@ir_number", SqlDbType.VarChar, 12).Value = ir_number.Trim
            da.SelectCommand.CommandText = "select ir_number , CONVERT(VARCHAR(11),ir_date , 103) ir_date , pl_number , item_description , dbo.ms_fn_PlUnitName(pl_number) PlUnit ,    " & _
                        " ward , indentor , requisition_quantity , voucher_number , voucher_date , issued_quantity  " & _
                        " from dm_issue_requisition  where ir_number = @ir_number and consignee = @Consignee and pl_number = @PLNumber  "
            Try
                da.Fill(ds, "TransactionName")
                S1313Details = ds.Copy
            Catch exp As Exception
                S1313Details = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function TransactionName(ByVal TypeID As Integer) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@TypeID", SqlDbType.Int, 4).Value = TypeID
            da.SelectCommand.CommandText = "select TransactionName , LinkName  from  ms_StoreTransactionType where TypeID = @TypeID "
            Try
                da.Fill(ds, "TransactionName")
                TransactionName = ds.Tables("TransactionName")
            Catch exp As Exception
                TransactionName = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function LocationValue(ByVal Consignee As String, ByVal RackName As String) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = Consignee.Trim
            da.SelectCommand.Parameters.Add("@RackName", SqlDbType.VarChar, 50).Value = RackName.Trim
            da.SelectCommand.CommandText = "select * from  ms_StoreLocation where Consignee = @Consignee and RackName = @RackName "
            Try
                da.Fill(ds, "Location")
                LocationValue = ds.Tables("Location")
            Catch exp As Exception
                LocationValue = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function Location(ByVal Consignee As String) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = Consignee.Trim
            da.SelectCommand.CommandText = "select * from  ms_StoreLocation where Consignee = @Consignee ORDER BY RackName  "
            Try
                da.Fill(ds, "Location")
                Location = ds.Tables("Location")
            Catch exp As Exception
                Location = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function GetPLDetails(ByVal PLNumber As String, ByVal Type As Int16, ByVal GroupCode As String, ByVal Consignee As String) As DataSet
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@PLNumber", SqlDbType.VarChar, 8).Value = PLNumber.Trim
            da.SelectCommand.Parameters.Add("@GroupCode", SqlDbType.VarChar, 10).Value = GroupCode.Trim
            da.SelectCommand.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = Consignee.Trim
            If Type = 6 Then
                da.SelectCommand.CommandText = " select MlistNumber , Sentence , Unit  from  ms_vw_MListNumber where GroupCode = @Consignee and Application = 'MSS' ;"
            Else
                da.SelectCommand.CommandText = " select count(pl_number) cnt , dbo.ms_fn_PlLongName(pl_number) PlLongName , dbo.ms_fn_PlUnitName(pl_number) PlUnitName " & _
                                        " from pm_item_master where pl_number = @PLNumber GROUP BY pl_number ;"
            End If
            da.SelectCommand.CommandText &= " select isnull(PLID,0) PLID , isnull(OrderQty, 0) OrderQty , isnull(LedgerNo,'') LedgerNo , isnull(PageNo,'') PageNo , Rate from  ms_StoreMaster where PLNumber = @PLNumber and Consignee = @Consignee ;" & _
                        " select top 1 TransactionDate , TransactionType , Qty , Balance , a.RackID , " & _
                        " IssueNo = isnull(( select top 1 TransactionNumber from ms_StoreStock z where z.TypeID = 1 order by TransactionDate desc ),'') " & _
                        " from  ms_StoreStock a inner join ms_StoreMaster b on a.PLID = b.PLID " & _
                        " inner join ms_StoreTransactionType c on c.TypeID = a.TypeID " & _
                        " inner join ms_StoreLocation d on d.RackID = a.RackID " & _
                        " where a.PLID = ( select PLID from ms_StoreMaster where PlNumber = @PlNumber and Consignee = @Consignee ) " & _
                        " order by TransactionDate desc ;"
            Try
                da.Fill(ds, "MachineIDs")
                GetPLDetails = ds.Copy
            Catch exp As Exception
                GetPLDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function MachineIDs(ByVal GroupCode As String) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            If GroupCode = "RTSHOP" Then
                GroupCode = "MRT"
            End If
            da.SelectCommand.Parameters.Add("@GroupCode", SqlDbType.VarChar, 6).Value = GroupCode.Trim
            da.SelectCommand.CommandText = "select machine_code,(description +'-'+ machine_code) as Description from ms_MachineryMaster where GroupCode = @GroupCode ORDER BY description  "
            Try
                da.Fill(ds, "MachineIDs")
                MachineIDs = ds.Tables("MachineIDs")
            Catch exp As Exception
                MachineIDs = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function TransType() As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = "select TransactionType , TypeID  from ms_StoreTransactionType order by TypeID  "
            Try
                da.Fill(ds, "TransactionType")
                TransType = ds.Tables("TransactionType")
            Catch exp As Exception
                TransType = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function PLList(ByVal Consignee As String, ByVal Machine As String) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@machine_group", SqlDbType.VarChar, 6).Value = Consignee.Trim
            da.SelectCommand.Parameters.Add("@Machine", SqlDbType.VarChar, 8).Value = Machine.Trim
            da.SelectCommand.CommandText = "select distinct a.pl_number  , (rtrim(a.pl_number)+'--'+dbo.ms_fn_PlShortName(a.pl_number)) pl_desc , dbo.ms_fn_PlType(a.pl_number) PlType ,  ind , f1 [Number] , f2 [Date] , f3 [Consignee/OpenDate/Supplier] , " & _
                        " f4 Quantity , f5 [EstRate/IndDate/DueDate] , f6 [RecdQty] , f7 [QtyUT] , f8 [QtyDue] , Remarks , ReqQty from ms_Top1OutstandingPlDetails a inner join ms_vw_MachineSubAssembly_spares_details b " & _
                        " on a.pl_number = b.pl_number where b.MachineCode = @Machine and machine_group = @machine_group order by a.pl_number  "
            Try
                da.Fill(ds, "Selection")
                PLList = ds.Tables("Selection")
            Catch exp As Exception
                PLList = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function GetRemarks(ByVal pl_number As String, ByVal Group As String) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = "select Remarks , isnull(ReqQty,0) from ms_Top1OutstandingPlDetails where pl_number =  @pl_number and MachineGroup = @Group"
            Try
                da.SelectCommand.Parameters.Add("@pl_number", SqlDbType.VarChar, 8).Value = pl_number.Trim
                da.SelectCommand.Parameters.Add("@Group", SqlDbType.VarChar, 4).Value = Group.Trim
                da.Fill(ds)
                GetRemarks = ds.Tables(0).Copy
            Catch exp As Exception
                GetRemarks = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetMListNumber(ByVal ID As Long, ByVal Group As String) As String
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@ID", SqlDbType.BigInt, 8).Value = ID
            cmd.Parameters.Add("@Group", SqlDbType.VarChar, 8).Value = Group.Trim
            cmd.Parameters.Add("@MListNumber", SqlDbType.VarChar, 8)
            cmd.Parameters("@MListNumber").Direction = ParameterDirection.Output
            cmd.CommandText = "select @MlistNumber = MlistNumber from ms_vw_MListNumber where sentenceId =  @ID and Application = 'MSS'  and GroupCode = @Group"
            Try

                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.ExecuteScalar()
                GetMListNumber = IIf(IsDBNull(cmd.Parameters("@MListNumber").Value), "", cmd.Parameters("@MListNumber").Value)
            Catch exp As Exception
                GetMListNumber = ""
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
            End Try
        End Function
    End Class
#End Region
    Public Class StockMaster
#Region "  fields "
        Inherits Maintenance.Electrical
        Private dtPlList As DataTable
        Private spl_number, sRemarks, sUnit, sMachineCode As String
        Private dDt, dateTransactionDate, dateDated, dateLinkDate As Date
        Private lPLID, lRackID, lRate As Long
        Private sPLNumber, sConsignee, sLedgerNo, sPageNo, sTransactionNumber, sTransactionLink, sMessage As String
        Private decOrderQty, decQty, decBalance, fReqQty As Decimal
        Private intTypeID As Integer
#End Region
#Region "  property "
        Property ReqQty() As Decimal
            Get
                Return fReqQty
            End Get
            Set(ByVal Value As Decimal)
                fReqQty = Value
            End Set
        End Property
        Property Rate() As Long
            Get
                Return lRate
            End Get
            Set(ByVal Value As Long)
                lRate = Value
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
        Property LinkDate() As Date
            Get
                Return dateLinkDate
            End Get
            Set(ByVal Value As Date)
                dateLinkDate = Value
            End Set
        End Property
        Property TransactionLink() As String
            Get
                Return sTransactionLink
            End Get
            Set(ByVal Value As String)
                sTransactionLink = Value
            End Set
        End Property
        Property Balance() As Decimal
            Get
                Return decBalance
            End Get
            Set(ByVal Value As Decimal)
                decBalance = Value
            End Set
        End Property
        Property Qty() As Decimal
            Get
                Return decQty
            End Get
            Set(ByVal Value As Decimal)
                decQty = Value
            End Set
        End Property
        Property Dated() As Date
            Get
                Return dateDated
            End Get
            Set(ByVal Value As Date)
                dateDated = Value
            End Set
        End Property
        Property RackID() As Long
            Get
                Return lRackID
            End Get
            Set(ByVal Value As Long)
                lRackID = Value
            End Set
        End Property
        Property TransactionNumber() As String
            Get
                Return sTransactionNumber
            End Get
            Set(ByVal Value As String)
                sTransactionNumber = Value
            End Set
        End Property
        Property TypeID() As Integer
            Get
                Return intTypeID
            End Get
            Set(ByVal Value As Integer)
                intTypeID = Value
            End Set
        End Property
        Property TransactionDate() As Date
            Get
                Return dateTransactionDate
            End Get
            Set(ByVal Value As Date)
                dateTransactionDate = Value
            End Set
        End Property
        Property PageNo() As String
            Get
                Return sPageNo
            End Get
            Set(ByVal Value As String)
                sPageNo = Value
            End Set
        End Property
        Property LedgerNo() As String
            Get
                Return sLedgerNo
            End Get
            Set(ByVal Value As String)
                sLedgerNo = Value
            End Set
        End Property
        Property OrderQty() As Decimal
            Get
                Return decOrderQty
            End Get
            Set(ByVal Value As Decimal)
                decOrderQty = Value
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
        Property PLNumber() As String
            Get
                Return sPLNumber
            End Get
            Set(ByVal Value As String)
                sPLNumber = Value
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
        Property MachineCode() As String
            Get
                Return sMachineCode
            End Get
            Set(ByVal Value As String)
                sMachineCode = Value
            End Set
        End Property
        Property Dt() As Date
            Get
                Return dDt
            End Get
            Set(ByVal Value As Date)
                dDt = Value
            End Set
        End Property
        Property pl_number() As String
            Get
                Return spl_number
            End Get
            Set(ByVal Value As String)
                spl_number = Value
            End Set
        End Property
        Shadows Property Remarks() As String
            Get
                Return sRemarks
            End Get
            Set(ByVal Value As String)
                sRemarks = Value
            End Set
        End Property
        Property PlList() As DataTable
            Get
                Return dtPlList
            End Get
            Set(ByVal Value As DataTable)
                dtPlList = Value
            End Set
        End Property
        Property Unit() As String
            Get
                Return sUnit
            End Get
            Set(ByVal Value As String)
                sUnit = Value
            End Set
        End Property
#End Region
#Region "  methods "
        Private Sub iniVal()
            sMessage = ""
            dateLinkDate = "1900-01-01"
            sTransactionLink = ""
            decBalance = 0
            decQty = 0
            dateDated = "1900-01-01"
            lRackID = 0
            sTransactionNumber = ""
            intTypeID = 0
            dateTransactionDate = "1900-01-01"
            sPageNo = ""
            sLedgerNo = ""
            decOrderQty = 0
            lRate = 0
            sConsignee = ""
            sPLNumber = ""
            lPLID = 0
            sMachineCode = ""
            dtPlList = Nothing
            spl_number = ""
            sRemarks = ""
            dDt = "1900-01-01"
            sUnit = ""
            fReqQty = 0.0
        End Sub
        Public Sub New()
            iniVal()
        End Sub
        Public Sub New(ByVal Con As String)
            iniVal()
            dtPlList = SelectionList(Con)
        End Sub
        Public Function SelectionList(ByVal Consignee As String) As DataTable
            Dim dtSelectionList As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@machine_group", SqlDbType.VarChar, 6).Value = Consignee.Trim
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.CommandText = "ms_sp_Top1OutstandingPlDetails"
            Try
                da.Fill(ds, "Selection")
                dtSelectionList = ds.Tables("Selection")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtSelectionList
        End Function
        Public Function SavePLRemarks(ByVal Consignee As String) As Boolean
            Dim blnDone As Boolean
            Dim CMD As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                CMD.Parameters.Add("@Group", SqlDbType.VarChar, 4).Value = Consignee.Trim
                CMD.Parameters.Add("@pl_number", SqlDbType.VarChar, 8).Value = spl_number
                CMD.Parameters.Add("@Dt", SqlDbType.SmallDateTime, 4).Value = dDt
                CMD.Parameters.Add("@Remarks", SqlDbType.VarChar, 2000).Value = sRemarks.Trim
                CMD.Parameters.Add("@MachineCode", SqlDbType.VarChar, 50).Value = sMachineCode.Trim
                CMD.Parameters.Add("@ReqQty", SqlDbType.Float, 8).Value = fReqQty
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
                CMD.CommandText = " update  ms_Top1OutstandingPlDetails set ReqQty = @ReqQty , MachineCode = @MachineCode , Remarks = @Remarks , Dt = @Dt where pl_number = @pl_number and MachineGroup = @Group "
                If CMD.ExecuteNonQuery > 0 Then blnDone = True
            Catch exp As Exception
                Throw New Exception("Saving to ms_Top1OutstandingPlDetails Tables error : " & exp.Message)
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
        Public Function SaveMaterialList() As Boolean
            Dim blnDone As Boolean
            Dim CMD As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                If CMD.Connection.State = ConnectionState.Closed Then CMD.Connection.Open()
                CMD.Transaction = CMD.Connection.BeginTransaction
                If Me.EquipmentList.Rows.Count > 0 Then
                    If Me.Unit.Trim.Length > 0 Then
                        Me.FailureID = Me.SaveEquipmentList(CMD, Me.EquipmentList, Me.Unit)
                        If Me.FailureID = 0 Then Throw New Exception(" Material List Saving error")
                        blnDone = True
                    Else
                        Me.FailureID = Me.SaveEquipmentList(CMD, Me.EquipmentList)
                        If Me.FailureID = 0 Then Throw New Exception(" Material List Saving error")
                        blnDone = True
                    End If
                End If
            Catch exp As Exception
                sMessage = exp.Message
            Finally
                If blnDone Then
                    CMD.Transaction.Commit()
                Else
                    CMD.Transaction.Rollback()
                End If
                If CMD.Connection.State = ConnectionState.Open Then CMD.Connection.Close()
                CMD.Dispose()
            End Try
            spl_number = SubStoreStock.Tables.GetMListNumber(Me.FailureID, Me.GroupCode)
            If spl_number.Trim.Length > 0 Then
                blnDone = True
            End If
            Return blnDone
        End Function
        Public Function SaveStore(Optional ByVal PLID As Long = 0, Optional ByVal TransID As Long = 0, Optional ByVal Delete As Boolean = False) As Boolean
            Dim blnDone As New Boolean()
            Dim Cmd As System.Data.SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Cmd.Parameters.Add("@PLID", SqlDbType.BigInt, 8)
            Cmd.Parameters.Add("@TransID", SqlDbType.BigInt, 8)
            If PLID = 0 Then
                Cmd.Parameters("@PLID").Direction = ParameterDirection.Output
            Else
                Cmd.Parameters("@PLID").Direction = ParameterDirection.Input
                Cmd.Parameters("@PLID").Value = PLID
            End If
            If TransID = 0 Then
                Cmd.Parameters("@TransID").Direction = ParameterDirection.Output
            Else
                Cmd.Parameters("@TransID").Direction = ParameterDirection.Input
                Cmd.Parameters("@TransID").Value = TransID
            End If
            Try
                Cmd.Parameters.Add("@PLNumber", SqlDbType.VarChar, 8).Value = sPLNumber
                Cmd.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = sConsignee
                Cmd.Parameters.Add("@OrderQty", SqlDbType.Float, 8).Value = decOrderQty
                Cmd.Parameters.Add("@LedgerNo", SqlDbType.VarChar, 50).Value = sLedgerNo
                Cmd.Parameters.Add("@PageNo", SqlDbType.VarChar, 10).Value = sPageNo
                Cmd.Parameters.Add("@Rate", SqlDbType.BigInt, 8).Value = lRate
                Cmd.Parameters.Add("@TransactionDate", SqlDbType.DateTime, 8).Value = dateTransactionDate
                Cmd.Parameters.Add("@RackID", SqlDbType.BigInt, 8).Value = lRackID
                Cmd.Parameters.Add("@TypeID", SqlDbType.Int, 4).Value = intTypeID
                Cmd.Parameters.Add("@TransactionNumber", SqlDbType.VarChar, 50).Value = sTransactionNumber
                Cmd.Parameters.Add("@Dated", SqlDbType.SmallDateTime, 4).Value = dateDated
                Cmd.Parameters.Add("@Qty", SqlDbType.Float, 8).Value = decQty
                Cmd.Parameters.Add("@Balance", SqlDbType.Float, 8).Value = decBalance
                Cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 200).Value = sRemarks
                Cmd.Parameters.Add("@TransactionLink", SqlDbType.VarChar, 50).Value = sTransactionLink
                Cmd.Parameters.Add("@LinkDate", SqlDbType.SmallDateTime, 4).Value = dateLinkDate
                Cmd.Parameters.Add("@MachineCode", SqlDbType.VarChar, 50).Value = sMachineCode
                blnDone = True
            Catch exp As Exception
                blnDone = False
            End Try
            If blnDone = True Then
                blnDone = False
            Else
                Cmd.Dispose()
                Throw New Exception("Value assingement error !")
                Exit Function
            End If
            Try
                If Cmd.Connection.State = ConnectionState.Closed Then Cmd.Connection.Open()
                Cmd.Transaction = Cmd.Connection.BeginTransaction
                If PLID > 0 Then
                    If Delete = False Then
                        If TransID > 0 Then
                            StoreEdit(Cmd)
                            blnDone = True
                        Else
                            StoreTransAdd(Cmd)
                            blnDone = True
                        End If
                    Else
                        StoreDelete(Cmd)
                        blnDone = True
                    End If
                Else
                    If Delete = False Then StoreAdd(Cmd)
                    blnDone = True
                End If
            Catch exp As Exception
                sMessage = exp.Message
                Throw New Exception(exp.Message)
            Finally
                If blnDone = True Then
                    Cmd.Transaction.Commit()
                    sMessage = "Records updated "
                Else
                    Cmd.Transaction.Rollback()
                    sMessage = "Records Not Updated !"
                End If
                If Cmd.Connection.State = ConnectionState.Open Then Cmd.Connection.Close()
                Cmd.Dispose()
            End Try
            Return blnDone
        End Function
        Private Sub StoreAdd(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " insert into ms_StoreMaster  " & _
                        " ( PLNumber , Consignee , OrderQty , LedgerNo , PageNo , Rate ) " & _
                        " values  ( @PLNumber , @Consignee , @OrderQty , @LedgerNo , @PageNo , @Rate ) "
            Try
                If CMD.ExecuteNonQuery <= 0 Then
                    Throw New Exception(" Store Master error")
                Else
                    CMD.CommandText = " select @PLID = PLID from ms_StoreMaster  " & _
                        " where PLNumber = @PLNumber and Consignee = @Consignee and OrderQty = @OrderQty and LedgerNo = @LedgerNo and PageNo = @PageNo "
                    CMD.ExecuteScalar()
                    If IIf(IsDBNull(CMD.Parameters("@PLID").Value), 0, CMD.Parameters("@PLID").Value) = 0 Then
                        Throw New Exception(" Store Master saving error")
                    Else
                        CMD.Parameters("@PLID").Direction = ParameterDirection.Input
                        CMD.CommandText = " insert into ms_StoreStock  " & _
                                                " ( TransactionDate , PLID , RackID , TypeID ,  TransactionNumber , Dated , Qty , Balance , Remarks , TransactionLink , LinkDate , MachineCode  )" & _
                                                " values  ( @TransactionDate , @PLID , @RackID , @TypeID ,  @TransactionNumber , @Dated , @Qty , @Balance , @Remarks , @TransactionLink , @LinkDate , @MachineCode  ) "
                        If CMD.ExecuteNonQuery <= 0 Then Throw New Exception(" Store Transaction Saving error")
                    End If
                End If
            Catch exp As Exception
                Throw New Exception(" Insert into ms_StoreMaster error " & exp.Message)
            End Try
        End Sub
        Private Sub StoreTransAdd(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " update ms_StoreMaster set OrderQty = @OrderQty , LedgerNo = @LedgerNo , PageNo = @PageNo , Rate = @Rate " & _
                        " where PLID = @PLID "
            Try
                If CMD.ExecuteNonQuery <= 0 Then
                    Throw New Exception(" Unable to update Bills Pending  List details ")
                Else
                    CMD.CommandText = " insert into ms_StoreStock  " & _
                                                " ( TransactionDate , PLID , RackID , TypeID ,  TransactionNumber , Dated , Qty , Balance , Remarks , TransactionLink , LinkDate , MachineCode  )" & _
                                                " values  ( @TransactionDate , @PLID , @RackID , @TypeID ,  @TransactionNumber , @Dated , @Qty , @Balance , @Remarks , @TransactionLink , @LinkDate , @MachineCode  ) "
                    If CMD.ExecuteNonQuery <= 0 Then Throw New Exception(" Store Transaction Saving error")
                End If
            Catch exp As Exception
                Throw New Exception(" update of ms_sparecell_BillsPending error :  " & exp.Message)
            End Try
        End Sub
        Private Sub StoreEdit(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " update ms_StoreMaster set OrderQty = @OrderQty , LedgerNo = @LedgerNo , PageNo = @PageNo , Rate = @Rate " & _
                        " where PLID = @PLID "
            Try
                If CMD.ExecuteNonQuery <= 0 Then
                    Throw New Exception(" Unable to update Bills Pending  List details ")
                Else
                    CMD.CommandText = " update ms_StoreStock  " & _
                                                    " set TransactionDate = @TransactionDate  , RackID =  @RackID , TypeID = @TypeID ,  TransactionNumber = @TransactionNumber , Dated = @Dated ,  " & _
                                                    " Qty = @Qty , Balance =  @Balance , Remarks = @Remarks , TransactionLink =  @TransactionLink , LinkDate = @LinkDate , MachineCode = @MachineCode where PLID = @PLID and TransID = @TransID "
                    If CMD.ExecuteNonQuery <= 0 Then Throw New Exception(" Store Transaction Saving error")
                End If
            Catch exp As Exception
                Throw New Exception(" update of ms_sparecell_BillsPending error :  " & exp.Message)
            End Try
        End Sub
        Private Sub StoreDelete(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " "
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to delete details ")
            Catch exp As Exception
                Throw New Exception(" delete of  error :  " & exp.Message)
            End Try
        End Sub
#End Region
    End Class
End Namespace