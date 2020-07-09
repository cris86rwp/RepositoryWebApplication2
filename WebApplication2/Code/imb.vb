<Serializable()> Public Class imb
#Region " tables "
    Public Shared Function StockBalance(ByVal PLNumber As String, ByVal FrDate As Date, ByVal ToDate As Date, ByVal Consignee As String) As DataTable
        Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        If PLNumber = "ALL" Then
            da.SelectCommand.CommandText = " select row_number() over ( order by a.PLNumber) Sl , a.PLNumber , short_description , " & _
                    " UnitName , Balance Qty , unit_rate , Balance*unit_rate Value  " & _
                    " from ( select PLNumber , max(case when SaveDateTime is null then IdnLpIssDate else SaveDateTime end) SlNo " & _
                    " from ms_IMBStockTransaction where wap.dbo.ms_fn_PlType(PLNumber) = 'N' " & _
                    " and TransactionDate <= @ToDate  " & _
                    " group by PLNumber ) a inner join ms_IMBStockTransaction b on a.PLNumber = b.PLNumber " & _
                    " and a.SlNo = case when b.SaveDateTime is null then b.IdnLpIssDate else b.SaveDateTime end " & _
                    " inner join pm_ItemMaster c on a.PLNumber = c.pl_number" & _
                    " inner join ms_vw_PlRate d on a.PLNumber = d.pl_number where ConsigneeName = @Consignee order by a.PLNumber"
        Else
            da.SelectCommand.CommandText = " select row_number() over ( order by a.PLNumber) Sl , a.PLNumber , short_description , " & _
            " UnitName , Balance Qty , unit_rate , Balance*unit_rate Value  " & _
            " from ( select PLNumber , max(case when SaveDateTime is null then IdnLpIssDate else SaveDateTime end) SlNo " & _
            " from ms_IMBStockTransaction where wap.dbo.ms_fn_PlType(PLNumber) = 'N' " & _
            " and TransactionDate <= @ToDate and ConsigneeName = @Consignee and PLNumber = @PLNumber " & _
            " group by PLNumber ) a inner join ms_IMBStockTransaction b on a.PLNumber = b.PLNumber " & _
            " and a.SlNo = case when b.SaveDateTime is null then b.IdnLpIssDate else b.SaveDateTime end " & _
            " inner join pm_ItemMaster c on a.PLNumber = c.pl_number" & _
            " inner join ms_vw_PlRate d on a.PLNumber = d.pl_number where ConsigneeName = @Consignee order by a.PLNumber"
        End If



        Try
            da.SelectCommand.Parameters.Add("@PLNumber", SqlDbType.VarChar, 50).Value = PLNumber
            da.SelectCommand.Parameters.Add("@Consignee", SqlDbType.VarChar, 50).Value = Consignee
            da.SelectCommand.Parameters.Add("@FrDate", SqlDbType.SmallDateTime, 4).Value = FrDate
            da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.SmallDateTime, 4).Value = ToDate
            da.Fill(ds)
            StockBalance = ds.Tables(0).Copy
        Catch exp As Exception
            StockBalance = Nothing
            Throw New Exception(exp.Message)
        Finally
            ds.Dispose()
            da.Dispose()
        End Try
    End Function
    Public Shared Function CheckRec(ByVal PLNumber As String, ByVal FrDate As Date, ByVal ToDate As Date, ByVal Consignee As String) As Boolean
        Dim oCmd As New SqlClient.SqlCommand()
        Dim blnRec As Boolean
        blnRec = False
        oCmd.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
        oCmd.CommandText = " SELECT count(*) FROM ms_IMBStockMaster a inner join ms_IMBStockTransaction  b " & _
            " on a.PLNumber = b.PLNumber WHERE "
        If PLNumber = "ALL" Then
            oCmd.CommandText &= " b.TransactionDate  between @FrDate and  @ToDate "
        Else
            oCmd.CommandText &= " b.PLNumber = @PLNumber  and b.TransactionDate  between @FrDate and  @ToDate  "
        End If
        If Consignee = "ALL" Then

        Else
            oCmd.CommandText &= " and b.ConsigneeName = @Consignee  "
        End If
        Try
            oCmd.Parameters.Add("@PLNumber", SqlDbType.VarChar, 50).Value = PLNumber
            oCmd.Parameters.Add("@Consignee", SqlDbType.VarChar, 50).Value = Consignee
            oCmd.Parameters.Add("@FrDate", SqlDbType.SmallDateTime, 4).Value = FrDate
            oCmd.Parameters.Add("@ToDate", SqlDbType.SmallDateTime, 4).Value = ToDate
            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            If oCmd.ExecuteScalar() > 0 Then blnRec = True
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
            oCmd.Dispose()
        End Try
        Return blnRec
    End Function
    Public Shared Function getPLNumbers() As DataSet
        Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        da.SelectCommand.CommandText = " SELECT distinct a.PLNumber FROM wap.dbo.ms_IMBStockMaster a " & _
            " inner join wap.dbo.ms_IMBStockTransaction b on a.PLNumber = b.PLNumber" & _
            " ORDER BY a.PLNumber ASC ;" & _
            " SELECT distinct b.ConsigneeName FROM wap.dbo.ms_IMBStockMaster a " & _
            " inner join wap.dbo.ms_IMBStockTransaction b " & _
            " on a.PLNumber = b.PLNumber  " & _
            " ORDER BY b.ConsigneeName ASC "
        Try
            da.Fill(ds)
            getPLNumbers = ds.Copy
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            ds.Dispose()
            da.Dispose()
        End Try
    End Function
    Public Shared Function GetLedgerNumberDetails(ByVal LedgerNumber As String) As DataTable
        Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        da.SelectCommand.CommandText = " select * from ms_vw_IMBStockBalance " & _
            " where LedgerNumber = '" & LedgerNumber.Trim & "' "
        Try
            da.Fill(ds)
            GetLedgerNumberDetails = ds.Tables(0).Copy
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            ds.Dispose()
            da.Dispose()
        End Try
    End Function
    Public Shared Function GetLedgerNumber() As DataTable
        Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        da.SelectCommand.CommandText = " select distinct LedgerNumber from  ms_IMBStockMaster order by LedgerNumber ; "
        Try
            da.Fill(ds)
            GetLedgerNumber = ds.Tables(0).Copy
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            ds.Dispose()
            da.Dispose()
        End Try
    End Function
    Public Shared Function GetPLNumbers(ByVal SearchPLNumber As String) As DataTable
        Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        da.SelectCommand.CommandText = " select *  from ms_vw_IMBStockBalance " & _
                        " where dbo.ms_fn_PlLongName(PLNumber) like '%" & SearchPLNumber.Trim & "%' "
        Try
            da.Fill(ds)
            GetPLNumbers = ds.Tables(0).Copy
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            ds.Dispose()
            da.Dispose()
        End Try
    End Function
    Public Shared Function NilBalance(ByVal Consignee As String) As DataTable
        Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        da.SelectCommand.CommandText = " select a.PLNumber , short_description PlDesc , LedgerNumber , PageNumber , Location , Balance ,  " & _
            " ltrim(rtrim(UnitName)) Unit from ms_IMBStockMaster a inner join  " & _
            " ( select a.PLNumber , ConsigneeName , Balance  " & _
            " from ms_IMBStockTransaction a inner join  " & _
            " ( select PLNumber , max(slno) slno from ms_IMBStockTransaction   " & _
            " group by PLNumber ) b on a.slno = b.slno ) b on a.PLNumber = b.PLNumber " & _
            " inner join pm_itemmaster c on a.PLNumber = c.PL_Number " & _
            " where ConsigneeName = @Group and Balance = 0 "


        Try
            da.SelectCommand.Parameters.Add("@Group", SqlDbType.VarChar, 10).Value = Consignee
            da.Fill(ds)
            NilBalance = ds.Tables(0).Copy
        Catch exp As Exception
            NilBalance = Nothing
            Throw New Exception(exp.Message)
        Finally
            ds.Dispose()
            da.Dispose()
        End Try
    End Function
    Public Shared Function PopulateIMBConsignee() As DataTable
        Dim strIMSCons As String
        strIMSCons = " select distinct ConsigneeName from ms_IMBStockTransaction "
        Dim daIMSCons As New SqlClient.SqlDataAdapter()
        Dim dsIMSCons As New DataSet()
        daIMSCons.SelectCommand = New SqlClient.SqlCommand()
        daIMSCons.SelectCommand.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
        daIMSCons.SelectCommand.CommandText = strIMSCons
        Try
            daIMSCons.Fill(dsIMSCons)
            PopulateIMBConsignee = dsIMSCons.Tables(0).Copy
        Catch exp As Exception
            PopulateIMBConsignee = Nothing
            Throw New Exception(exp.Message)
        Finally
            daIMSCons.Dispose()
        End Try
    End Function
    Public Shared Function PopulatePLNumbers(ByVal IMBConsignee As String) As DataTable
        Dim strPlNum As String
        strPlNum = " select PlNumber , PlNumber + '-' + Pldescription from ms_vw_IMBStockBalance"
        If IMBConsignee = "ALL" Then
            strPlNum &= " order by PlNumber  "
        Else
            strPlNum &= " where ConsigneeName = '" & IMBConsignee.Trim & "'   order by PlNumber "
        End If
        Dim daPL As New SqlClient.SqlDataAdapter()
        Dim dsPL As New DataSet()
        daPL.SelectCommand = New SqlClient.SqlCommand()
        daPL.SelectCommand.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
        daPL.SelectCommand.CommandText = strPlNum
        Try
            daPL.Fill(dsPL)
            PopulatePLNumbers = dsPL.Tables(0)
        Catch exp As Exception
            PopulatePLNumbers = Nothing
            Throw New Exception(exp.Message)
        Finally
            daPL.Dispose()
        End Try
    End Function
    Public Shared Function PLDetails(ByVal PLNumber As String, ByVal FrDt As Date, ByVal ToDt As Date) As DataSet
        Dim strGetDetails As String

        Dim da As New SqlClient.SqlDataAdapter()
        Dim ds As New DataSet()
        da.SelectCommand = New SqlClient.SqlCommand()
        da.SelectCommand.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
        da.SelectCommand.CommandText = " select a.PL_Number PLNumber, LedgerNumber , Location , LocationDesc , UnitName PLUnitName ," & _
                        " dbo.ms_fn_BOMListInStore(a.PL_Number) InStore , dbo.ms_fn_IMBPLBalance(a.PL_Number) InIMB ,  convert(decimal(18,2),unit_rate) UnitRate " & _
                        " from  pm_ItemMaster a left outer join ( " & _
                        " select a.PLNumber, LedgerNumber, Location , dbo.ms_fn_IMBStoreLocation(Location) LocationDesc ," & _
                        " dbo.ms_fn_PlUnitName(a.PLNumber) PLUnitName " & _
                        " from ( select PLNumber, max(PlID) PlID from  ms_IMBStockMaster  where PLNumber = '" & PLNumber & "'  group by PLNumber ) a " & _
                        " inner join ms_IMBStockMaster b on a.PlID = b.PlID ) b on a.PL_Number = b.PLNumber " & _
                        " inner join ms_vw_PlRate c on a.PL_Number = c.PL_Number where a.PL_Number = '" & PLNumber & "' ;" & _
                        " select convert(varchar(10),wo_date,103) WODate , machine_code MachineCode, MachineShortName , sub_assembly SubAssmCode , " & _
                        " SubAssemblyName , replaced_quantity RepQty , convert(decimal(18,2),Amount) Amount from ( " & _
                        " select wo_date , machine_code , MachineShortName , sub_assembly , " & _
                        " SubAssemblyName , replaced_quantity ,  Amount " & _
                        " from ms_vw_unscheduled_entry_spares_rate where pl_number = '" & PLNumber & "' and replaced_quantity > 0 " & _
                        " union select breakdown_date , a.machine_code , MachineShortName , sub_assembly ,SubAssemblyName , " & _
                        " replaced_quantity , replaced_quantity*unit_rate Amount  " & _
                        " from ms_vw_workorder_spares_rate  a  inner join ms_vw_breakdown_memo b on memo_number = workorder_number and a.machine_code = b.machine_code " & _
                        " where pl_number = '" & PLNumber & "' and sl_no = 'b' and replaced_quantity > 0 " & _
                        " ) a where wo_date between @FrDt and @ToDt order by wo_date "
        da.SelectCommand.Parameters.Add("@FrDt", SqlDbType.SmallDateTime, 4).Value = FrDt
        da.SelectCommand.Parameters.Add("@ToDt", SqlDbType.SmallDateTime, 4).Value = ToDt
        Try
            da.Fill(ds)
            PLDetails = ds.Copy
        Catch exp As Exception
            PLDetails = Nothing
            Throw New Exception(exp.Message)
        Finally
            da.Dispose()
        End Try
    End Function
    Public Shared Function GetPls() As DataTable
        Dim strPLNum As String

        Dim da As New SqlClient.SqlDataAdapter()
        Dim ds As New DataSet()
        da.SelectCommand = New SqlClient.SqlCommand()
        da.SelectCommand.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
        da.SelectCommand.CommandText = " select distinct a.pl_number PLNumber , " & _
            " a.pl_number + '-' + convert(varchar(250),short_description) PlLongName  from (" & _
            " select distinct pl_number from ms_vw_MachineSubAssembly_spares_details " & _
            " where machine_group like 'mw%' union" & _
            " select distinct PLNumber from  ms_IMBStockMaster" & _
            " ) a inner join pm_ItemMaster b on a.pl_number  = b.pl_number "
        Try
            da.Fill(ds)
            GetPls = ds.Tables(0).Copy
        Catch exp As Exception
            GetPls = Nothing
            Throw New Exception(exp.Message)
        Finally
            ds.Dispose()
            da.Dispose()
        End Try
    End Function
    Public Shared Function GetLocation(ByVal PLNumber As String) As DataTable
        Dim dt As New DataTable()
        Dim strGetDetails As String
        strGetDetails = " select PLNumber, LedgerNumber, Location , dbo.ms_fn_IMBStoreLocation(Location) LocationDesc , dbo.ms_fn_IMBPreviousSaveDateTime(plnumber) PreviousDateTime " & _
                        " from  ms_IMBStockMaster where plnumber = '" & PLNumber.Trim & "' "
        Dim da As New SqlClient.SqlDataAdapter()
        Dim ds As New DataSet()
        da.SelectCommand = New SqlClient.SqlCommand()
        da.SelectCommand.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
        da.SelectCommand.CommandText = strGetDetails
        Try
            da.Fill(ds)
            dt = ds.Tables(0)
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            da.Dispose()
            ds.Dispose()
        End Try
        Return dt
    End Function
    Public Shared Function GetPlDetails(ByVal PLNumber As String) As DataSet
        Dim dsGetPlNumberDetails As New DataSet()
        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        da.SelectCommand = New SqlClient.SqlCommand()
        da.SelectCommand.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
        da.SelectCommand.CommandText = " select PLNumber, LedgerNumber, Location , dbo.ms_fn_IMBStoreLocation(Location) LocationDesc ,  dbo.ms_fn_PlUnitName(PLNumber) PLUnitName " & _
                        " from  ms_IMBStockMaster where PLNumber = '" & PLNumber.Trim & "'; " & _
                        " select ms_IMBStockTransaction.TypeOfTransaction , convert(varchar,ms_IMBStockTransaction.TransactionDate, 103) TransactionDate , ms_IMBStockTransaction.IdnLpIssNumber,  " & _
                        " convert(varchar,ms_IMBStockTransaction.IdnLpIssDate,103) IdnLpIssDate, ms_IMBStockTransaction.PoChalNumber, convert(varchar , ms_IMBStockTransaction.PoChalDate,103) PoChalDate , " & _
                        " ms_IMBStockTransaction.ConsigneeName, ms_IMBStockTransaction.Receipt, ms_IMBStockTransaction.Issue,  " & _
                        " ms_IMBStockTransaction.Balance, ms_IMBStockTransaction.Remarks, ms_IMBStockTransaction.SlNo  " & _
                        " from wap.dbo.ms_IMBStockTransaction ms_IMBStockTransaction  " & _
                        " where ms_IMBStockTransaction.PLNumber = '" & PLNumber.Trim & "' " & _
                        " ORDER BY ms_IMBStockTransaction.PLNumber ASC,  ms_IMBStockTransaction.SaveDateTime ASC ; " & _
                        " SELECT  Consigneename from ms_sparecell_consignee where Consigneename in ('MWCR','MWMR','MWMS')  order by Consigneename "
        Try
            da.Fill(ds)
            dsGetPlNumberDetails = ds.Copy
        Catch exp As Exception
            Throw New Exception("Get PLNumber Details error")
        Finally
            da.Dispose()
            ds.Dispose()
        End Try
        Return dsGetPlNumberDetails
    End Function
    Public Shared Function GetPlNumber() As DataTable
        Dim dt As New DataTable()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim ds As New DataSet()
        da.SelectCommand = New SqlClient.SqlCommand()
        da.SelectCommand.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
        da.SelectCommand.CommandText = " select distinct plnumber PLNumber , plnumber + '-' + dbo.ms_fn_PlLongName(plnumber) PlLongName " & _
                   " from  ms_IMBStockMaster order by plnumber; "
        Try
            da.Fill(ds)
            dt = ds.Tables(0)
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            ds.Dispose()
            da.Dispose()
        End Try
        Return dt
    End Function
    Public Shared Function GetIMBCriticalItemList(ByVal PONumber As String, ByVal PLNumber As String) As DataTable
        Dim dt As New DataTable()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim ds As New DataSet()
        da.SelectCommand.CommandText = " select * from ms_IMBCriticalItemList where po_number = '" & PONumber.Trim & "' and pl_number = '" & PLNumber.Trim & "' "
        da.SelectCommand = New SqlClient.SqlCommand()
        da.SelectCommand.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
        Try
            da.Fill(ds)
            dt = ds.Tables(0)
        Catch exp As Exception
            Throw New Exception("Population Consigneename error")
        Finally
            da.Dispose()
            ds.Dispose()
        End Try
        Return dt
    End Function
    Public Shared Function GetPONumberDetails(ByVal PONumber As String) As DataSet
        Dim dsGetPONumberDetails As New DataSet()
        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        da.SelectCommand = New SqlClient.SqlCommand()
        da.SelectCommand.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
        Dim strPODetails As String

        strPODetails = " select  a.po_number , a.po_date , a.po_value ,a.order_completion_date PODueDate , c.name ,  c.phone_number , c.contact_person " & _
                                    " from pm_po_header a inner join  pm_supplier_master c " & _
                                    "  on  c.supplier_code = a.supplier_code where a.po_number = '" & PONumber.Trim & "' ;"
        strPODetails &= " select a.po_number, a.pl_number, substring(b.short_description,1,60) pl_desc , a.order_quantity , a.unit_rate , dbo.ms_fn_PlUnitName(a.pl_number) UnitName  " & _
                " from pm_po_details a  left outer join pm_itemMasterOnly b on b.pl_number = a.pl_number     " & _
                " where a.po_number = '" & PONumber.Trim & "' ; "
        strPODetails &= " select distinct b.po_number , b.pl_number , b.order_quantity OrderQty , c.consignee " & _
                " from pm_indent_detail  a inner join pm_po_details b  " & _
                " on b.pl_number = a.pl_number inner join pm_indent_header c  " & _
                " on c.indent_number = a.indent_number where b.po_number = '" & PONumber.Trim & "' ;"
        da.SelectCommand.CommandText = strPODetails
        Try
            da.Fill(ds)
            dsGetPONumberDetails = ds.Copy
        Catch exp As Exception
            Throw New Exception("Get PONumber Details error")
        Finally
            da.Dispose()
            ds.Dispose()
        End Try
        Return dsGetPONumberDetails
    End Function
    Public Shared Function GetINDENTDetails(ByVal Indent As String) As DataSet
        Dim dsGetINDENTDetails As New DataSet()
        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        da.SelectCommand = New SqlClient.SqlCommand()
        da.SelectCommand.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
        da.SelectCommand.CommandText = " select count(*)  from ms_vw_IndentDetails where indent_number = '" & Indent.Trim & "' ; " & _
                " select  indent_number , convert(varchar(11) , indent_date , 103) indent_date ,  " & _
                " consignee , pl_number , long_description ,  PlUnit  , lpdbr_number , bill_date , rate  from ms_vw_LPDetails where indent_number = '" & Indent.Trim & "' ; "
        Try
            da.Fill(ds)
            dsGetINDENTDetails = ds.Copy
        Catch exp As Exception
            Throw New Exception("Population Consigneename error")
        Finally
            da.Dispose()
            ds.Dispose()
        End Try
        Return dsGetINDENTDetails
    End Function
    Public Shared Function GetNSIDNDetails(ByVal IDNLPNo As String, Optional ByVal PLNo As String = "", Optional ByVal Type As Int16 = 0) As DataSet
        Dim dsGetNSIDNDetails As New DataSet()
        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        da.SelectCommand = New SqlClient.SqlCommand()
        da.SelectCommand.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
        If Type > 0 Then
            da.SelectCommand.CommandText = " select count(*)  from ms_IMBRegister where NsIDnId = " & IDNLPNo.Trim & "  ; " & _
                       " select ConsigneeName , NsIDnId NSIDNno  , convert(varchar,NsIDndate,103) NSIDNDate , " & _
                       " PO_No PONumber  , convert(varchar,po_date,103) PODate , Firm ,  " & _
                       " pl_number PLNumber , long_description PLDesc , Unit ,  " & _
                       " PO_QTY POQty , PLRecdQty , unit_rate UnitRate  " & _
                       " from ms_vw_NsIdnsDetails where  nsidnid = " & IDNLPNo.Trim & "  ; " & _
                       " select count(*)  from ms_sparecell_nsidnno where NSIDNid = '" & IDNLPNo.Trim & "' "
        Else
            If PLNo.Trim.Length = 0 Then
                da.SelectCommand.CommandText = " select count(*)  from pm_nonstock_dbr where idn_number = '" & IDNLPNo.Trim & "'  ; " & _
                           " select a.consignee ConsigneeName , idn_number NSIDNno  , convert(varchar,idn_date,103) NSIDNDate ,  " & _
                           " a.PO_Number PONumber , convert(varchar,po_date,103) PODate ,  rtrim(name) Firm ,  " & _
                           " c.pl_number PLNumber , e.long_description PLDesc , UnitName Unit , order_quantity POQty , " & _
                           " a.received_quantity PLRecdQty , unit_rate UnitRate " & _
                           " from pm_nonstock_dbr a inner join pm_po_header b " & _
                           " on a.PO_Number = b.PO_Number inner join pm_po_details c" & _
                           " on a.PO_Number = c.PO_Number inner join pm_supplier_master d" & _
                           " ON b.supplier_code = d.supplier_code inner join pm_ItemMaster e " & _
                           " on c.pl_number = e.pl_number  where  idn_number = '" & IDNLPNo.Trim & "'  ; "
            Else
                da.SelectCommand.CommandText = " select count(*)  from pm_nonstock_dbr where idn_number = '" & IDNLPNo.Trim & "'  ; " & _
                           " select a.consignee ConsigneeName , idn_number NSIDNno  , convert(varchar,idn_date,103) NSIDNDate ,  " & _
                           " a.PO_Number PONumber , convert(varchar,po_date,103) PODate ,  rtrim(name) Firm ,  " & _
                           " c.pl_number PLNumber , e.long_description PLDesc , UnitName Unit , order_quantity POQty , " & _
                           " a.received_quantity PLRecdQty , unit_rate UnitRate " & _
                           " from pm_nonstock_dbr a inner join pm_po_header b " & _
                           " on a.PO_Number = b.PO_Number inner join pm_po_details c" & _
                           " on a.PO_Number = c.PO_Number inner join pm_supplier_master d" & _
                           " ON b.supplier_code = d.supplier_code inner join pm_ItemMaster e " & _
                           " on c.pl_number = e.pl_number  where  idn_number = '" & IDNLPNo.Trim & "'  and c.pl_number =  '" & PLNo.Trim & "'; "
            End If

        End If
        Try
            da.Fill(ds)
            dsGetNSIDNDetails = ds.Copy
        Catch exp As Exception
            Throw New Exception("Population Consigneename error")
        Finally
            da.Dispose()
            ds.Dispose()
        End Try
        Return dsGetNSIDNDetails
    End Function
    Public Shared Function GetPreviousTrans(ByVal PlNumber As String, Optional ByVal Type As String = "") As DataSet
        Dim dsGetPreviousTrans As New DataSet()
        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        da.SelectCommand = New SqlClient.SqlCommand()
        da.SelectCommand.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
        da.SelectCommand.CommandText = " select count(pl_number) cnt , dbo.ms_fn_PlLongName(pl_number) PlLongName , " & _
             " dbo.ms_fn_PlUnitName(pl_number) PlUnitName from pm_item_master where pl_number = '" & PlNumber.Trim & "' GROUP BY pl_number ; " & _
             " select count(*)  from ms_IMBStockTransaction where PlNumber = '" & PlNumber.Trim & "' ; " & _
             " select top 1 TransactionDate , TypeOfTransaction , Receipt , Issue , Balance " & _
             " from ms_IMBStockTransaction where PLNumber = '" & PlNumber.Trim & "'  order by  SaveDateTime desc ; " & _
             " select top 1 LedgerNumber , PageNumber , Location  from ms_IMBStockMaster " & _
             " where PLNumber = '" & PlNumber.Trim & "'  order by  PlID desc ; "
        Try
            If Type.Trim = "" Then
                da.SelectCommand.CommandText &= " select top 5 convert(varchar(10),TransactionDate,103) TransDate , " & _
                    " TypeOfTransaction Type , PLNumber , IdnLpIssNumber  IDNorLPNo , Receipt , Issue , Balance " & _
                    " from ms_IMBStockTransaction where PLNumber = '" & PlNumber.Trim & "'" & _
                    " and TypeOfTransaction <> 'Issue' order by  SaveDateTime desc ; "
            Else
                da.SelectCommand.CommandText &= " select top 5 convert(varchar(10),TransactionDate,103) TransDate , " & _
                    " TypeOfTransaction Type , PLNumber , IdnLpIssNumber  ISSNo , Receipt , Issue , Balance " & _
                    " from ms_IMBStockTransaction where PLNumber = '" & PlNumber.Trim & "'" & _
                    " and TypeOfTransaction = 'Issue' order by  SaveDateTime desc ; "
            End If
            da.Fill(ds)
            dsGetPreviousTrans = ds.Copy
        Catch exp As Exception
            Throw New Exception("Population Consigneename error")
        Finally
            da.Dispose()
            ds.Dispose()
        End Try
        Return dsGetPreviousTrans
    End Function
    Public Shared Function PopulateConsignee() As DataTable
        Dim dt As New DataTable()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim ds As New DataSet()
        da.SelectCommand.CommandText = " SELECT  Consigneename from ms_sparecell_consignee where Consigneename in ('MWCR','MWMR','MWMS')  order by Consigneename "
        da.SelectCommand = New SqlClient.SqlCommand()
        da.SelectCommand.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
        Try
            da.Fill(ds)
            dt = ds.Tables(0)
        Catch exp As Exception
            Throw New Exception("Population Consigneename error")
        Finally
            da.Dispose()
            ds.Dispose()
        End Try
        Return dt
    End Function
    Public Shared Function PopulateLocation() As DataTable
        Dim dt As New DataTable()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim ds As New DataSet()
        da.SelectCommand = New SqlClient.SqlCommand()
        da.SelectCommand.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
        da.SelectCommand.CommandText = " SELECT  LocationID , Location  from ms_imb_store  order by locationID "
        Try
            da.Fill(ds)
            dt = ds.Tables(0)
        Catch exp As Exception
            Throw New Exception("Filling Population Location error")
        Finally
            da.Dispose()
            ds.Dispose()
        End Try
        Return dt
    End Function
#End Region
#Region " fields "
    Private sExistingLocation, sExistingLedgerNumber, sUserID, sPLNumber, sLedgerNumber, sPageNumber, sLocation, sTypeOfTransaction, sIdnLpIssNumber, sConsigneeName, sRemarks, sPoChalNumber As String
    Private dateTransactionDate, dateIdnLpIssDate, datePoChalDate, dateSaveDateTime, dateExistedUptoDate As Date
    Private decReceipt, decIssue, decBalance As Decimal
    Private longPlID, longSlNo As Long
    Private intTransType As Integer
    Private objItemsList As CriticalItems.Listing
#End Region
#Region " properties  "
    WriteOnly Property ExistedUptoDate() As Date
        Set(ByVal Value As Date)
            dateExistedUptoDate = Value
        End Set
    End Property
    WriteOnly Property ExistingLocation() As String
        Set(ByVal Value As String)
            sExistingLocation = Value
        End Set
    End Property
    WriteOnly Property ExistingLedgerNumber() As String
        Set(ByVal Value As String)
            sExistingLedgerNumber = Value
        End Set
    End Property
    Property UserID() As String
        Get
            Return sUserID
        End Get
        Set(ByVal Value As String)
            sUserID = Value
        End Set
    End Property
    Property SlNo() As Long
        Get
            Return longSlNo
        End Get
        Set(ByVal Value As Long)
            longSlNo = Value
        End Set
    End Property
    ReadOnly Property ItemsList() As CriticalItems.Listing
        Get
            Return objItemsList
        End Get
    End Property
    Property TransType() As Integer
        Get
            Return intTransType
        End Get
        Set(ByVal Value As Integer)
            intTransType = Value
        End Set
    End Property
    Property SaveDateTime() As Date
        Get
            Return dateSaveDateTime
        End Get
        Set(ByVal Value As Date)
            dateSaveDateTime = Value
        End Set
    End Property
    Property PlID() As Long
        Get
            Return longPlID
        End Get
        Set(ByVal Value As Long)
            longPlID = Value
        End Set
    End Property
    Property PoChalDate() As Date
        Get
            Return datePoChalDate
        End Get
        Set(ByVal Value As Date)
            datePoChalDate = Value
        End Set
    End Property
    Property PoChalNumber() As String
        Get
            Return sPoChalNumber
        End Get
        Set(ByVal Value As String)
            sPoChalNumber = Value
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

    Property Balance() As Decimal
        Get
            Return decBalance
        End Get
        Set(ByVal Value As Decimal)
            decBalance = Value
        End Set
    End Property
    Property Issue() As Decimal
        Get
            Return decIssue
        End Get
        Set(ByVal Value As Decimal)
            decIssue = Value
        End Set
    End Property
    Property Receipt() As Decimal
        Get
            Return decReceipt
        End Get
        Set(ByVal Value As Decimal)
            decReceipt = Value
        End Set
    End Property
    Property ConsigneeName() As String
        Get
            Return sConsigneeName
        End Get
        Set(ByVal Value As String)
            sConsigneeName = Value
        End Set
    End Property
    Property IdnLpIssDate() As Date
        Get
            Return dateIdnLpIssDate
        End Get
        Set(ByVal Value As Date)
            dateIdnLpIssDate = Value
        End Set
    End Property
    Property IdnLpIssNumber() As String
        Get
            Return sIdnLpIssNumber
        End Get
        Set(ByVal Value As String)
            sIdnLpIssNumber = Value
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
    Property TypeOfTransaction() As String
        Get
            Return sTypeOfTransaction
        End Get
        Set(ByVal Value As String)
            sTypeOfTransaction = Value
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
    Property PageNumber() As String
        Get
            Return sPageNumber
        End Get
        Set(ByVal Value As String)
            sPageNumber = Value
        End Set
    End Property
    Property LedgerNumber() As String
        Get
            Return sLedgerNumber
        End Get
        Set(ByVal Value As String)
            sLedgerNumber = Value
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
#End Region
#Region " methods "
    Private Sub iniVals()
        dateExistedUptoDate = CDate("1900-01-01")
        sExistingLocation = ""
        sExistingLedgerNumber = ""
        sUserID = ""
        longSlNo = 0
        sPLNumber = ""
        sLedgerNumber = ""
        sPageNumber = ""
        sLocation = ""
        sTypeOfTransaction = ""
        dateTransactionDate = CDate("1900-01-01")
        sIdnLpIssNumber = ""
        dateIdnLpIssDate = CDate("1900-01-01")
        sConsigneeName = ""
        decReceipt = 0.0
        decIssue = 0.0
        decBalance = 0.0
        sRemarks = ""
        sPoChalNumber = ""
        datePoChalDate = CDate("1900-01-01")
        longPlID = 0
        dateSaveDateTime = CDate("1900-01-01")
    End Sub
    Public Sub New()
        iniVals()
        objItemsList = New CriticalItems.Listing()
    End Sub
    Public Function IMBStock(Optional ByVal PlID As Long = 0, Optional ByVal Delete As Boolean = False) As Boolean
        Dim blnDone As Boolean
        Dim oCmd As New SqlClient.SqlCommand()
        oCmd.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
        Try
            oCmd.Parameters.Add("@PLNumber", SqlDbType.VarChar, 8).Value = sPLNumber
            oCmd.Parameters.Add("@LedgerNumber", SqlDbType.VarChar, 50).Value = sLedgerNumber
            oCmd.Parameters.Add("@PageNumber", SqlDbType.VarChar, 20).Value = sPageNumber
            oCmd.Parameters.Add("@Location", SqlDbType.VarChar, 20).Value = sLocation

            oCmd.Parameters.Add("@TypeOfTransaction", SqlDbType.VarChar, 50).Value = sTypeOfTransaction
            oCmd.Parameters.Add("@TransactionDate", SqlDbType.SmallDateTime, 4).Value = dateTransactionDate
            oCmd.Parameters.Add("@IdnLpIssNumber", SqlDbType.VarChar, 50).Value = sIdnLpIssNumber
            oCmd.Parameters.Add("@IdnLpIssDate", SqlDbType.SmallDateTime, 4).Value = dateIdnLpIssDate
            oCmd.Parameters.Add("@ConsigneeName", SqlDbType.VarChar, 4).Value = sConsigneeName
            oCmd.Parameters.Add("@Receipt", SqlDbType.Decimal, 9, 3).Value = decReceipt
            oCmd.Parameters.Add("@Issue", SqlDbType.Decimal, 9, 3).Value = decIssue
            oCmd.Parameters.Add("@Balance", SqlDbType.Decimal, 9, 3).Value = decBalance
            oCmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 1000).Value = sRemarks
            oCmd.Parameters.Add("@PlID", SqlDbType.BigInt, 9).Value = longPlID
            oCmd.Parameters.Add("@PoChalNumber", SqlDbType.VarChar, 50).Value = sPoChalNumber
            oCmd.Parameters.Add("@PoChalDate", SqlDbType.SmallDateTime, 4).Value = datePoChalDate
            oCmd.Parameters.Add("@SaveDateTime", SqlDbType.DateTime, 8).Value = dateSaveDateTime
            oCmd.Parameters.Add("@TransType", SqlDbType.Int, 4).Value = intTransType
            blnDone = True
        Catch exp As Exception
            blnDone = False
        End Try
        If blnDone = True Then
            blnDone = False
        Else
            oCmd.Dispose()
            Throw New Exception("Value assingement error !")
            Exit Function
        End If

        Try
            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            oCmd.Transaction = oCmd.Connection.BeginTransaction

            If PlID > 0 Then
                If Delete = False Then
                    IMBStockEdit(oCmd, PlID)
                    blnDone = True
                End If
            Else
                If Delete = False Then IMBStockAdd(oCmd)
                blnDone = True
            End If
        Catch exp As Exception
            Throw New Exception("IMBStock saving to ms_IMBStockTransaction Tables error : " & exp.Message)
        Finally
            If blnDone = True Then
                oCmd.Transaction.Commit()
            Else
                oCmd.Transaction.Rollback()
            End If
            If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
            oCmd.Dispose()
        End Try
        Return blnDone
    End Function
    Private Sub IMBStockAdd(ByRef oCmd As SqlClient.SqlCommand)
        Dim blnDone As Boolean
        Dim strStockMasterInsert, strStockTranInsert, strStockMasterCheck, strStockTranCheck As String
        Dim I As Integer
        strStockMasterInsert = " insert into ms_IMBStockMaster " & _
                                " ( PLNumber , LedgerNumber , PageNumber , Location ) values " & _
                                " ( @PLNumber , @LedgerNumber , @PageNumber , @Location ) "
        strStockMasterCheck = " select @PlID = PlID from  ms_IMBStockMaster " & _
                                " where PLNumber = @PLNumber and  LedgerNumber = @LedgerNumber " & _
                                " and  PageNumber = @PageNumber and Location = @Location "
        strStockTranCheck = "  select count(*) from ms_IMBStockTransaction where " & _
                            "  TypeOfTransaction = @TypeOfTransaction and  TransactionDate =  @TransactionDate and  " & _
                            "  IdnLpIssNumber = @IdnLpIssNumber and  IdnLpIssDate = @IdnLpIssDate and   " & _
                            "  ConsigneeName = @ConsigneeName and  Receipt = @Receipt and  Issue = @Issue and " & _
                            "  Balance = @Balance and PoChalNumber = @PoChalNumber and  PoChalDate = @PoChalDate and PLNumber = @PLNumber "

        strStockTranInsert = " insert into ms_IMBStockTransaction " & _
                            " ( TypeOfTransaction , TransactionDate , IdnLpIssNumber , IdnLpIssDate ,  " & _
                            "  ConsigneeName , Receipt , Issue , Balance , Remarks , PoChalNumber , PoChalDate , PLNumber , SaveDateTime ) " & _
                            "  values ( @TypeOfTransaction , @TransactionDate , @IdnLpIssNumber , @IdnLpIssDate , " & _
                            "  @ConsigneeName , @Receipt , @Issue , @Balance , @Remarks , @PoChalNumber ,  @PoChalDate , @PLNumber , @SaveDateTime ) "

        Try
            oCmd.Parameters("@PlID").Direction = ParameterDirection.Output
            oCmd.CommandText = strStockMasterCheck
            oCmd.ExecuteScalar()
            longPlID = IIf(IsDBNull(oCmd.Parameters("@PlID").Value), 0, oCmd.Parameters("@PlID").Value)
            If intTransType > 1 Then
                If longPlID = 0 Then
                    oCmd.CommandText = strStockMasterInsert
                    If oCmd.ExecuteNonQuery() > 0 Then
                        oCmd.CommandText = strStockMasterCheck
                        oCmd.ExecuteScalar()
                        longPlID = oCmd.Parameters("@PlID").Value
                    Else
                        Throw New Exception("Error inerting ms_IMBStockMaster ")
                    End If
                End If
            End If
            oCmd.CommandText = strStockTranCheck
            I = oCmd.ExecuteScalar()
            If I = 0 Then
                oCmd.Parameters("@PlID").Direction = ParameterDirection.Input
                oCmd.Parameters("@PlID").Value = longPlID
                oCmd.CommandText = strStockTranInsert
                If oCmd.ExecuteNonQuery() = 0 Then Throw New Exception("Error inerting ms_IMBStockTransaction ")
            End If
        Catch exp As Exception
            Throw New Exception(" Saving IMB Stock error ! " & exp.Message)
        End Try
    End Sub
    Private Sub IMBStockEdit(ByRef oCmd As SqlClient.SqlCommand, ByVal CheckListID As Long)
        'oCmd.CommandText = " update ms_sparecell_BillsCheckList set TotalValue = @TotalValue ,  DueDate = @DueDate ,  Delivery = @Delivery ," & _
        '        " Quantity = @Quantity ,  Others = @Others ,  OtherPayment = @OtherPayment , " & _
        '        " SpecialConditions = @SpecialConditions ,  Erection = @Erection , DateOfReceipt = @DateOfReceipt ," & _
        '        " DateOfSending = @DateOfSending ,  AnyOtherEnclosures = @AnyOtherEnclosures " & _
        '        " where CheckListID = @CheckListID and PONumber = @PONumber "
        'Try
        '    If oCmd.ExecuteNonQuery = 0 Then
        '        Throw New Exception(" Unable to update CheckList details ")
        '    Else
        '        'If IsNothing(dtCheckListItems) = False Then
        '        '    If dtCheckListItems.Rows.Count > 0 Then
        '        '        If SaveCheckListItemsEdit(oCmd, CheckListID, dtCheckListItems) = False Then Throw New Exception(" Check List Saving error")
        '        '    End If
        '        'End If
        '    End If
        'Catch exp As Exception
        '    Throw New Exception(" update of ms_sparecell_BillsCheckList error :  " & exp.Message)
        'End Try
    End Sub
    Public Function SaveIMBCriticalItemList(Optional ByVal Edit As Boolean = False, Optional ByVal Delete As Boolean = False) As Boolean
        Dim blnDone As Boolean
        Dim CMD As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            ' Assingned unreleated text items to objects property just to test !
            CMD.Parameters.Add("@PONumber", SqlDbType.VarChar, 9).Value = objItemsList.PO
            CMD.Parameters.Add("@PODate", SqlDbType.SmallDateTime, 4).Value = ItemsList.PODt
            CMD.Parameters.Add("@POValue", SqlDbType.Float, 8).Value = objItemsList.BOMQty
            CMD.Parameters.Add("@PODueDate", SqlDbType.SmallDateTime, 4).Value = objItemsList.LastIssueDate
            CMD.Parameters.Add("@Firm", SqlDbType.VarChar, 100).Value = objItemsList.POSup
            CMD.Parameters.Add("@PhoneNumber", SqlDbType.VarChar, 50).Value = objItemsList.PhoneNumber
            CMD.Parameters.Add("@ContactPerson", SqlDbType.VarChar, 50).Value = objItemsList.ContactPerson
            CMD.Parameters.Add("@PLNumber", SqlDbType.VarChar, 8).Value = objItemsList.PLNumber
            CMD.Parameters.Add("@PLDesc", SqlDbType.VarChar, 100).Value = objItemsList.Equip
            CMD.Parameters.Add("@POQty", SqlDbType.Float, 8).Value = objItemsList.InStore
            CMD.Parameters.Add("@UnitName", SqlDbType.VarChar, 10).Value = ItemsList.Type
            CMD.Parameters.Add("@Remarks", SqlDbType.VarChar, 200).Value = ItemsList.Remarks
            CMD.Parameters.Add("@CheckListID", SqlDbType.Int, 4).Value = ItemsList.PLID
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
            If Edit Then
                IMBListEdit(CMD)
                blnDone = True
            Else
                If Delete = False Then
                    IMBListAdd(CMD)
                    blnDone = True
                Else
                    IMBListDelete(CMD)
                    blnDone = True
                End If
            End If
        Catch exp As Exception
            Throw New Exception("IMB CheckList saving to ms_IMBCriticalItemList Tables error : " & exp.Message)
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
    Private Sub IMBListAdd(ByRef CMD As SqlClient.SqlCommand)
        CMD.CommandText = " insert into ms_IMBCriticalItemList " & _
            " ( CriticalItemNo , po_number , po_date , po_value , order_completion_date , FirmName , phone_number , contact_person , pl_number , pl_desc , order_quantity ,  UnitName , Remarks ) values " & _
            " ( @CheckListID , @PONumber , @PODate , @POValue , @PODueDate , @Firm , @PhoneNumber , @ContactPerson , @PLNumber , @PLDesc , @POQty ,  @UnitName , @Remarks   )  "
        Try
            If CMD.ExecuteNonQuery = 0 Then Throw New Exception("IMBCriticalItemList Saving error")
        Catch exp As Exception
            Throw New Exception(" Insert into ms_IMBCriticalItemList error " & exp.Message)
        End Try
    End Sub
    Private Sub IMBListEdit(ByRef CMD As SqlClient.SqlCommand)
        CMD.CommandText = " update  ms_IMBCriticalItemList set CriticalItemNo = @CheckListID  , phone_number = @PhoneNumber , contact_person = @ContactPerson , Remarks  = @Remarks where po_number =  @PONumber and  pl_number = @PLNumber  "
        Try
            If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to update IMBCriticalItemList details ")
        Catch exp As Exception
            Throw New Exception(" update of ms_IMBCriticalItemList error :  " & exp.Message)
        End Try
    End Sub
    Private Sub IMBListDelete(ByRef CMD As SqlClient.SqlCommand)
        CMD.CommandText = " delete from ms_IMBCriticalItemList where po_number =  @PONumber and  pl_number = @PLNumber "
        Try
            If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to delete IMBCriticalItemList details ")
        Catch exp As Exception
            Throw New Exception(" delete of ms_sparecell_BillsCheckList error :  " & exp.Message)
        End Try
    End Sub
    Public Function ChangeConsignee(ByVal SlNo As Long) As Boolean
        Dim strUpdateTran, strUpdateAudit, strGetData As String
        Dim oCmd As New SqlClient.SqlCommand()
        Dim blnSaveOK As Boolean
        strUpdateTran = " update ms_IMBStockTransaction set ConsigneeName = @ConsigneeName  where SlNo = @SlNo "
        strUpdateAudit = " insert into ms_IMBStockTransaction_audit " & _
                        " select  * , @ChangedOnDate  , @UserID " & _
                        " from ms_IMBStockTransaction where SlNo = @SlNo "
        oCmd.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
        oCmd.CommandText = strUpdateTran
        If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
        Try
            oCmd.Parameters.Add("@SlNo", SqlDbType.BigInt, 8).Value = longSlNo
            oCmd.Parameters.Add("@ConsigneeName", SqlDbType.VarChar, 4).Value = ConsigneeName.Trim
            oCmd.Parameters.Add("@ChangedOnDate", SqlDbType.DateTime, 8).Value = Date.Now
            oCmd.Parameters.Add("@UserID", SqlDbType.VarChar, 6).Value = sUserID
            oCmd.Transaction = oCmd.Connection.BeginTransaction
            oCmd.CommandText = strUpdateAudit
            oCmd.Transaction = oCmd.Connection.BeginTransaction
            If oCmd.ExecuteNonQuery() > 0 Then
                oCmd.CommandText = strUpdateTran
                If oCmd.ExecuteNonQuery() > 0 Then
                    blnSaveOK = True
                End If
            End If
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            If blnSaveOK Then
                oCmd.Transaction.Commit()
            Else
                oCmd.Transaction.Rollback()
            End If
            If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
            oCmd.Dispose()
        End Try
        Return blnSaveOK
    End Function
    Public Function ChangeLocation(ByVal PLNumber As String) As Boolean
        Dim strNSIDNRegister, strChangeLocAndLedg As String
        Dim oCmd As New SqlClient.SqlCommand()
        Dim blnSaveOK As Boolean
        strNSIDNRegister = " update ms_IMBStockMaster set LedgerNumber = @LedgerNumber , Location = @Location where PLNumber = @PLNumber "
        strChangeLocAndLedg = " insert into ms_IMBChangeLocAndLedg ( PLNumber , ExistingLedgerNumber , ExistingLocation , ExistedUptoDate , NewLedgerNumber , NewLocation , ChangedOnDate ) " & _
                              " values ( @PLNumber , @ExistingLedgerNumber , @ExistingLocation , @ExistedUptoDate , @NewLedgerNumber , @NewLocation , @ChangedOnDate ) "
        oCmd.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
        oCmd.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
        oCmd.CommandText = strNSIDNRegister
        If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
        Try
            oCmd.Parameters.Add("@PLNumber", SqlDbType.VarChar, 8).Value = sPLNumber
            oCmd.Parameters.Add("@LedgerNumber", SqlDbType.VarChar, 50).Value = sLedgerNumber
            oCmd.Parameters.Add("@Location", SqlDbType.VarChar, 20).Value = sLocation
            oCmd.Parameters.Add("@ExistingLedgerNumber", SqlDbType.VarChar, 50).Value = sExistingLedgerNumber
            oCmd.Parameters.Add("@ExistingLocation", SqlDbType.VarChar, 20).Value = sExistingLocation
            oCmd.Parameters.Add("@ExistedUptoDate", SqlDbType.SmallDateTime, 4).Value = dateExistedUptoDate
            oCmd.Parameters.Add("@NewLedgerNumber", SqlDbType.VarChar, 50).Value = sLedgerNumber
            oCmd.Parameters.Add("@NewLocation", SqlDbType.VarChar, 20).Value = sLocation
            oCmd.Parameters.Add("@ChangedOnDate", SqlDbType.SmallDateTime, 4).Value = Date.Now
            oCmd.Transaction = oCmd.Connection.BeginTransaction
            oCmd.CommandText = strNSIDNRegister
            If oCmd.ExecuteNonQuery() > 0 Then
                oCmd.CommandText = strChangeLocAndLedg
                If oCmd.ExecuteNonQuery() > 0 Then
                    blnSaveOK = True
                End If
            End If
        Catch exp As Exception
            If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
            oCmd.Dispose()
        Finally
            If blnSaveOK Then
                oCmd.Transaction.Commit()
            Else
                oCmd.Transaction.Rollback()
            End If
            If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
            oCmd.Dispose()
        End Try
        Return blnSaveOK
    End Function
#End Region
End Class
