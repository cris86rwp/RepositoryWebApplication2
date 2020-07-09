Namespace MouldMaster
    <Serializable()> Public Class MRSMRS
        Public Shared Function MouldPerformance(ByVal FromDate As String, ByVal ToDate As String, ByVal QryNo As Integer) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = "mm_sp_MouldPerformance"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.Add("@FrDt", SqlDbType.SmallDateTime, 4).Value = FromDate
                da.SelectCommand.Parameters.Add("@ToDt", SqlDbType.SmallDateTime, 4).Value = ToDate
                da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = QryNo
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
        Public Shared Function TopReceipt(ByVal MldNo As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "Select top 1 " &
                    " Convert(Varchar(10),a.receipt_date,103)  ReceiptDt ,  a.shift_code Sh , " &
                    " a.mould_number MldNo , mould_type Type , graphite_height GrHt ,  " &
                    " Wheels_cast WhlsCst , mould_status Sts , remarks ,  MouldLife MldL, IngateLife IngL" &
                    " From mm_mould_receipt a left outer join mm_MouldReceipt b" &
                    " on a.mould_number = b.mould_number and a.receipt_date = b.receipt_date " &
                    " and a.shift_code = b.shift_code where a.mould_number = @MldNo " &
                    " order by a.receipt_date desc , a.shift_code desc "
                da.SelectCommand.Parameters.Add("@MldNo", SqlDbType.VarChar, 50).Value = MldNo
                da.Fill(ds)
                TopReceipt = ds.Tables(0).Copy
            Catch exp As Exception
                TopReceipt = Nothing
                Throw New Exception(" Retrival error" & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function MRReasons(ByVal MldNo As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "select top 1 convert(varchar(10),TransDate,103) TransDt ," &
                    " Shift Sh  , rtrim(CodeDesc) MRReasons " &
                    " from mm_MouldTransaction a inner join mm_MouldTransactionType b  on a.TransType = b.TransNo  " &
                    " left outer join mm_MouldTransactionTypeList on Defect = code " &
                    " where MouldNo = @MldNo order by TransDate desc , Shift desc "
                da.SelectCommand.Parameters.Add("@MldNo", SqlDbType.VarChar, 50).Value = MldNo
                da.Fill(ds)
                MRReasons = ds.Tables(0).Copy
            Catch exp As Exception
                MRReasons = Nothing
                Throw New Exception(" Retrival error" & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function CheckMldNumber(ByVal MldNumber As String) As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            Try
                cmd.Connection.Open()
                cmd.CommandText = "select @cnt = count(mould_number) from mm_mould_master where mould_number = '" & MldNumber.Trim & " '"
                cmd.ExecuteScalar()
                CheckMldNumber = IIf(IsDBNull(cmd.Parameters("@cnt").Value), 0, cmd.Parameters("@cnt").Value)
            Catch exp As Exception
                CheckMldNumber = ""
                Throw New Exception(exp.Message)
            Finally
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function MouldOldDetails(ByVal Mld As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()

            Try
                da.SelectCommand.Parameters.Add("@Mld", SqlDbType.VarChar, 50).Value = Mld
                da.SelectCommand.CommandText = "select blank_number Blank , " &
                    " type , convert(varchar(10),created_date,103) IntroducedDt ," &
                    " rtrim(wap_drawing_number) Drg , engraved_number EngNo , standard_height IniHt ," &
                    " initial_height FiHt , no_whl_cas WlsCast , mould_status Sts , supplier_code Firm ," &
                    " convert(varchar(10),condemned_date,103) CondDt , ConvertedNumber NewMldNo , " &
                    " convert(varchar(10),ConvertedDate,103) ConvertedDate  " &
                    " from mm_mould_master a inner join mm_mmmdmt_dump b" &
                    " on mld_no =  mould_number " &
                    " where mould_number = @Mld "
                da.Fill(ds)
                MouldOldDetails = ds.Tables(0).Copy
            Catch exp As Exception
                MouldOldDetails = Nothing
                Throw New Exception(" Retrival error" & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function CondemnedMould() As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "select distinct mould_number " &
                    " from mm_mould_master where mould_status = 'c' order by mould_number "
                da.Fill(ds)
                CondemnedMould = ds.Tables(0).Copy
            Catch exp As Exception
                CondemnedMould = Nothing
                Throw New Exception(" Retrival error" & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function MouldPCDO(ByVal FrDt As Date, ByVal ToDt As Date, ByVal Product As String, ByVal MouldType As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                If MouldType = "I" Then
                    da.SelectCommand.CommandText = "select * from mm_fn_MRS_PCDOIngateItemsValuesNew(@fr,@to,@Prod) "
                Else
                    da.SelectCommand.CommandText = "select * from mm_fn_MRS_PCDOItemsValuesNew(@fr,@to,@Prod,@MouldType) "
                End If
                da.SelectCommand.Parameters.Add("@Fr", SqlDbType.SmallDateTime, 4).Value = FrDt
                da.SelectCommand.Parameters.Add("@To", SqlDbType.SmallDateTime, 4).Value = ToDt
                da.SelectCommand.Parameters.Add("@Prod", SqlDbType.VarChar, 50).Value = Product
                da.SelectCommand.Parameters.Add("@MouldType", SqlDbType.VarChar, 50).Value = MouldType
                da.Fill(ds)
                MouldPCDO = ds.Tables(0).Copy
            Catch exp As Exception
                MouldPCDO = Nothing
                Throw New Exception(" Retrival error" & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function MouldPCDOMouldTypes(ByVal FrDt As Date, ByVal ToDt As Date) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "select distinct description , c.product_code  " &
                    " from mm_mould_machining_details a inner join mm_mould_master b " &
                    " on a.mould_number = b.mould_number and type = mould_type inner join mm_product_master c " &
                    " on c.product_code = b.product_code  " &
                    " where machining_date between @fr and @to "
                da.SelectCommand.Parameters.Add("@Fr", SqlDbType.SmallDateTime, 4).Value = FrDt
                da.SelectCommand.Parameters.Add("@To", SqlDbType.SmallDateTime, 4).Value = ToDt

                da.Fill(ds)
                MouldPCDOMouldTypes = ds.Tables(0).Copy
            Catch exp As Exception
                MouldPCDOMouldTypes = Nothing
                Throw New Exception(" Retrival error" & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function MouldPODetails(ByVal FrDt As Date, ByVal ToDt As Date) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = " select a.supplier_code , PONumber , count(*) Total , " &
                    " sum(case when c.mould_status <> 'c' then 1 else 0 end) ActiveMlds, " &
                    " sum(case when c.mould_status = 'c' then 1 else 0 end) ConMlds " &
                    " from mm_new_mould_introduction a inner join mm_mouldsize_master b " &
                    " on b.mould_number = cope_drag_number inner join mm_mould_master c " &
                    " on b.mould_number = c.mould_number " &
                    " where a.created_date between @Fr and @To " &
                    " group by a.supplier_code , PONumber " &
                    " order by a.supplier_code , PONumber "
                da.SelectCommand.Parameters.Add("@Fr", SqlDbType.SmallDateTime, 4).Value = FrDt
                da.SelectCommand.Parameters.Add("@To", SqlDbType.SmallDateTime, 4).Value = ToDt

                da.Fill(ds)
                MouldPODetails = ds.Tables(0).Copy
            Catch exp As Exception
                MouldPODetails = Nothing
                Throw New Exception(" Retrival error" & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function MouldReceiptDetails(ByVal FrDt As Date, ByVal ToDt As Date, ByVal mould_number As String) As DataSet
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = " select mould_number MldNo , convert(varchar(10),receipt_date,103) ReceiptDt  , b.shift_code Sh , b.remarks " &
                    " from mm_new_mould_introduction a inner join mm_mould_receipt b" &
                    " on cope_drag_number = mould_number" &
                    " where cope_drag_number = @mould_number and receipt_date between @fr and @to ;" &
                    " select mould_number MldNo , convert(varchar(10),machining_date,103) McnDt , b.shift_code Sh , b.wheels_cast WhlCast , b.remarks " &
                    " from mm_new_mould_introduction a inner join mm_mould_machining_details b " &
                    " on cope_drag_number = mould_number" &
                    " where cope_drag_number = @mould_number  and machining_date between @fr and @to ;" &
                    " select drag_number DrgNo  , past_ingate PastIng , present_ingate PresentIng , convert(varchar(10),ingate_date,103) IngDt , reason_for_removal" &
                    " from mm_new_mould_introduction a inner join mm_ingate_assembly b " &
                    " on cope_drag_number = drag_number " &
                    " where cope_drag_number = @mould_number  and ingate_date between @fr and @to "
                da.SelectCommand.Parameters.Add("@Fr", SqlDbType.SmallDateTime, 4).Value = FrDt
                da.SelectCommand.Parameters.Add("@To", SqlDbType.SmallDateTime, 4).Value = ToDt
                da.SelectCommand.Parameters.Add("@mould_number", SqlDbType.VarChar, 50).Value = mould_number
                da.Fill(ds)
                MouldReceiptDetails = ds.Copy
            Catch exp As Exception
                MouldReceiptDetails = Nothing
                Throw New Exception(" Retrival error" & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function MouldsReceipt(ByVal FrDt As Date) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "SELECT convert(varchar(10),a.receipt_date,103) ReceiptDt  , a.shift_code Sh , b.type , " &
                    " a.mould_number MouldNo, a.remarks " &
                    " FROM wap.dbo.mm_mould_receipt a inner join wap.dbo.mm_mould_master b" &
                    " on a.mould_number = b.mould_number" &
                    " WHERE a.receipt_date = @FrDt" &
                    " order by a.receipt_date, a.shift_code, b.type, a.mould_number"
                da.SelectCommand.Parameters.Add("@FrDt", SqlDbType.SmallDateTime, 4).Value = FrDt
                da.Fill(ds)
                MouldsReceipt = ds.Tables(0)
            Catch exp As Exception
                MouldsReceipt = Nothing
                Throw New Exception(" Retrival error" & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function MouldTypeList() As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "SELECT distinct rtrim(description) MouldDescription " &
                    " FROM wap.dbo.mm_mmmdmt_dump a inner join wap.dbo.mm_mould_master b" &
                    " on a.mld_no = b.mould_number left outer join " &
                    " wap.dbo.mm_vw_mould_machining_details_Remarks c " &
                    " on b.mould_number = c.mould_number inner join mm_product_master d " &
                    " on d.product_code = b.product_code" &
                    " ORDER BY rtrim(description)"
                da.Fill(ds)
                MouldTypeList = ds.Tables(0)
            Catch exp As Exception
                MouldTypeList = Nothing
                Throw New Exception(" Retrival Error " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function MouldDetails(ByVal Qry As Integer, ByVal MouldType As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "mm_sp_MouldList"
                da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = Qry
                da.SelectCommand.Parameters.Add("@MouldType", SqlDbType.VarChar, 50).Value = MouldType
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.Fill(ds)
                MouldDetails = ds.Tables(0)
            Catch exp As Exception
                MouldDetails = Nothing
                Throw New Exception(" Retrival Error " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function MouldsBlank(ByVal BlankNo As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "select  a.type , a.blank_number Blank , a.cope_drag_number MouldNo , " &
                    " a.initial_height IniHt , c.mld_fin_ht FinalHt ,  " &
                    " b.mould_status Sts , c.no_whl_cas WhlsCast , a.supplier_code ,  " &
                    " convert(varchar(11),a.created_date,103) CreatedDt  , a.wap_drawing_number  DrgNo " &
                    " from mm_new_mould_introduction a inner join mm_mould_master b " &
                    " on a.cope_drag_number = b.mould_number inner join mm_mmmdmt_dump c on c.mld_no = b.mould_number " &
                    " where a.blank_number like @Blank "
                da.SelectCommand.Parameters.Add("@Blank", SqlDbType.VarChar, 50).Value = "%" & BlankNo.Trim & "%"
                da.Fill(ds)
                MouldsBlank = ds.Tables(0)
            Catch exp As Exception
                MouldsBlank = Nothing
                Throw New Exception(" Retrival of Ingate Details List " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function MouldsPO(ByVal PONumber As String, ByVal Type As Integer) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()

            Try
                da.SelectCommand.CommandText = "mm_sp_MouldsPOList"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.CommandTimeout = 3600
                da.SelectCommand.Parameters.Add("@PONumber", SqlDbType.VarChar, 50).Value = PONumber.Trim
                da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = Type
                da.Fill(ds)
                MouldsPO = ds.Tables(0).Copy
            Catch exp As Exception
                Throw New Exception(" Retrival of Ingate Details List " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function MouldsRejectedWhlsList(ByVal MldNo As String, ByVal Type As Integer) As DataSet
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()

            Try
                da.SelectCommand.CommandText = "mm_sp_MouldsRejectedWhlsList"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.Add("@Mld", SqlDbType.VarChar, 50).Value = MldNo.Trim
                da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = Type
                da.Fill(ds)
                MouldsRejectedWhlsList = ds.Copy
            Catch exp As Exception
                Throw New Exception(" Retrival of Ingate Details List " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function MouldsHistory(ByVal MldNo As String) As DataSet
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "mm_sp_MouldHistory"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.Add("@MldNo", SqlDbType.VarChar, 50).Value = MldNo.Trim
                da.Fill(ds)
                MouldsHistory = ds.Copy
            Catch exp As Exception
                MouldsHistory = Nothing
                Throw New Exception(" Retrival of Ingate Details List " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function MouldsRemarks() As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "select * from mm_vw_MouldRemarks"
                da.Fill(ds)
                MouldsRemarks = ds.Tables(0)
            Catch exp As Exception
                MouldsRemarks = Nothing
                Throw New Exception(" Retrival of Ingate Details List " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function MRTransMlds(ByVal TransDate As Date, ByVal Sh As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@TransDate", SqlDbType.SmallDateTime, 4).Value = TransDate
                da.SelectCommand.Parameters.Add("@Sh", SqlDbType.VarChar, 1).Value = Sh.Trim
                da.SelectCommand.CommandText = " select row_number() over ( order by MouldNo ) Sl , " &
                    " convert(varchar(11), TransDate,103) TransDate , Shift , MouldNo ," &
                    " case when TransNo = 2 or TransNo = 4 then rtrim(ltrim(CodeDesc)) else '' end Defect " &
                    " , RemarksByMRS from mm_MouldTransaction a inner join mm_MouldTransactionType b " &
                    " on a.TransType = b.TransNo  left outer join mm_MouldTransactionTypeList " &
                    " on Defect = code " &
                    " where TransDate = @TransDate and Shift = @Sh " &
                    " and TransName = 'REMOVED from Line'" &
                    " order by MouldNo "
                da.Fill(ds)
                MRTransMlds = ds.Tables(0)
            Catch exp As Exception
                MRTransMlds = Nothing
                Throw New Exception(" Retrival of Ingate Details List " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function NewAndConMoulds(ByVal FromDate As Date, ByVal ToDate As Date, ByVal Grid As String, ByVal Report As String) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            If Grid.StartsWith("D") Then
                If Report.StartsWith("C") Then
                    da.SelectCommand.CommandText = " SELECT  row_number() over ( order by supp_code , a.Mould_number ) SlNo , " &
                    " a.Mould_number MouldNo ,  EngNo , mould_size MldSize , PONumber , bln_no BlankNo , permeab , " &
                    " ash_content Ash , [Mould Height] MouldHt , CnHt ConHt , " &
                    " Ero , Dam , NosMach , NosD , NosE , supp_code Firm , no_whl_cas WhlsCast , " &
                    " convert(varchar(10),created_date,103) IntroDate , convert(varchar(10),Condemned_date,103) CondDt  , remarks " &
                    " FROM  mm_vw_Condemned_mould_details a left outer join mm_mouldsize_master b " &
                    " on b.mould_number = a.mould_number WHERE Condemned_date between @fr and @to ORDER BY supp_code , a.Mould_number "
                Else
                    da.SelectCommand.CommandText = " SELECT row_number() over ( order by description , a.Mould_number  ,  b.type) SlNo , " &
                    " a.product_code PCode ,  mould_size MldSize , b.type ,  description Descr , bln_no BlankNo , " &
                    " convert(numeric(9,2),b.permeability) Permeab ,  convert(numeric(9,2),b.ash_content) Ash , std_ht MouldHt,   " &
                    " a.mould_number MouldNo , ltrim(rtrim(a.engraved_number)) EngNo , " &
                    " supp_code Firm , convert(varchar(10),a.created_date,103) CreatedDt , Remarks, PONumber " &
                    " from mm_new_mould_introduction  b inner join mm_mould_master a " &
                    " on b.cope_drag_number = a.mould_number inner join mm_mmmdmt_dump c  " &
                    " on c.mld_no = a.mould_number inner join mm_product_master d " &
                    " on a.product_code = d.product_code left outer join mm_mouldsize_master e   " &
                    " on e.mould_number = a.mould_number " &
                    " where b.created_date between @fr and @to " &
                    " order by description , a.Mould_number ,  b.type "
                End If
            ElseIf Grid.StartsWith("S") Then
                If Report.StartsWith("C") Then
                    da.SelectCommand.CommandText = " SELECT  Descr ,  mould_size MldSize , PONumber , " &
                    " sum(case when type = 'C' then 1 else 0 end) Copes , " &
                     " sum(case when type = 'D' then 1 else 0 end) Drags " &
                     " FROM mm_vw_Condemned_mould_details a left outer join mm_mouldsize_master b on b.mould_number = a.mould_number " &
                     " WHERE Condemned_date between @fr and @to " &
                     " group BY Descr ,  mould_size , PONumber ORDER BY Descr ,  mould_size , PONumber "
                Else
                    da.SelectCommand.CommandText = " SELECT description Descr , mould_size MldSize , PONumber , " &
                    " sum(case when  b.type  = 'C' then 1 else 0 end) Copes , " &
                    " sum(case when  b.type  = 'D' then 1 else 0 end) Drags " &
                    " from mm_new_mould_introduction  b inner join mm_mould_master a " &
                    " on b.cope_drag_number = a.mould_number inner join mm_mmmdmt_dump c  " &
                    " on c.mld_no = a.mould_number inner join mm_product_master d " &
                    " on a.product_code = d.product_code left outer join mm_mouldsize_master e   " &
                    " on e.mould_number = a.mould_number " &
                    " where b.created_date between @fr and @to" &
                    " group by description , mould_size , PONumber order by description , mould_size , PONumber  "
                End If
            ElseIf Grid.StartsWith("F") Then
                If Report.StartsWith("C") Then
                    da.SelectCommand.CommandText = "mm_sp_FormWiseMouldPerformance"
                    da.SelectCommand.CommandType = CommandType.StoredProcedure
                Else
                    Throw New Exception("Querry not developed for this selection")
                End If
            ElseIf Grid.StartsWith("P") Then
                If Report.StartsWith("C") Then
                    da.SelectCommand.CommandText = "mm_sp_ProductWiseMouldPerformance"
                    da.SelectCommand.CommandType = CommandType.StoredProcedure
                Else
                    Throw New Exception("Querry not developed for this selection")
                End If
            End If
            Try
                da.SelectCommand.Parameters.Add("@fr", SqlDbType.SmallDateTime, 4).Value = FromDate
                da.SelectCommand.Parameters.Add("@to", SqlDbType.SmallDateTime, 4).Value = ToDate
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
        Public Shared Function Moulds(ByVal FromDate As String, ByVal ToDate As String, ByVal QryNo As Integer) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Select Case QryNo
                Case 1
                    da.SelectCommand.CommandText = "mm_sp_MouldMachiningDetailsMisMatch"
                Case 4
                    da.SelectCommand.CommandText = "mm_sp_MouldConsumptionSummary"
                Case 5
                    da.SelectCommand.CommandText = "mm_sp_SupplierWiseGraphiteConsumption"
                Case 6
                    da.SelectCommand.CommandText = "mm_sp_MouldConsumptionSummaryDatewise"
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 0
                Case 7
                    da.SelectCommand.CommandText = "mm_sp_MouldConsumptionSummaryDatewise"
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 1
                Case 2, 3, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24
                    da.SelectCommand.CommandText = "mm_sp_MRSQuerries"
                    da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = QryNo
            End Select
            Try
                da.SelectCommand.CommandTimeout = 60 * 60
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                Select Case QryNo
                    Case 2, 3, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24
                        da.SelectCommand.Parameters.Add("@Frdt", SqlDbType.SmallDateTime, 4).Value = FromDate
                        da.SelectCommand.Parameters.Add("@ToDt", SqlDbType.SmallDateTime, 4).Value = ToDate
                    Case Else
                        da.SelectCommand.Parameters.Add("@fr", SqlDbType.SmallDateTime, 4).Value = FromDate
                        da.SelectCommand.Parameters.Add("@to", SqlDbType.SmallDateTime, 4).Value = ToDate
                End Select
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
        Public Function SaveData(ByVal McnDate As Date, ByVal McnList As String, ByVal MouldNumber As String, ByVal EmpCode As String) As Boolean
            Dim blnDonotSave, blnSaved As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.CommandText = "select count(*) from mm_mould_machining_details where machining_date = @machining_date and operation_type <> '" & McnList.Trim & "' and mould_number = '" & MouldNumber & "'"
                cmd.Parameters.Add("@shift_code", SqlDbType.VarChar, 50).Direction = ParameterDirection.InputOutput
                cmd.Parameters.Add("@operation_type", SqlDbType.VarChar, 50).Direction = ParameterDirection.InputOutput
                cmd.Parameters.Add("@machining_date", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.InputOutput
                cmd.Parameters("@machining_date").Value = CDate(McnDate)
                cmd.Parameters("@shift_code").Value = ""
                cmd.Parameters("@operation_type").Value = ""
                cmd.Connection.Open()
                If cmd.ExecuteScalar = 0 Then
                    Throw New Exception("No Records to edit")
                Else
                    cmd.CommandText = "select  @shift_code = Shift_code, @operation_type = Operation_type " &
                        " from mm_mould_machining_details where machining_date = @machining_date " &
                        " and mould_number = '" & MouldNumber & "'"
                    cmd.ExecuteScalar()
                End If
                If blnDonotSave = False Then
                    cmd.Parameters("@operation_type").Direction = ParameterDirection.Input
                    cmd.Transaction = cmd.Connection.BeginTransaction
                    cmd.CommandText = "insert into mm_mould_machining_details_audit " &
                        " (Mould_number, machining_date, shift_code, operation_type, ChangedBy, ChangedTime) " &
                        " values ('" & MouldNumber & "', @machining_date, @shift_code, @Operation_type, '" & EmpCode.Trim & "', getdate())"
                    If cmd.ExecuteNonQuery = 1 Then
                        cmd.CommandText = "update mm_mould_machining_details set operation_type = '" & McnList & "' " &
                            " where machining_date = @machining_date and operation_type = @operation_type " &
                            " and mould_number = '" & MouldNumber & "' and shift_code = @Shift_Code"
                        If cmd.ExecuteNonQuery = 1 Then
                            blnSaved = True
                        End If
                    End If
                End If
            Catch exp As Exception
                blnSaved = False
                blnDonotSave = True
                Throw New Exception(exp.Message)
            Finally
                If IsNothing(cmd) = False Then
                    If IsNothing(cmd.Transaction) = False Then
                        If blnSaved Then
                            cmd.Transaction.Commit()
                        Else
                            cmd.Transaction.Rollback()
                        End If
                    End If
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                End If
            End Try
            blnDonotSave = Nothing
            blnSaved = Nothing
            Return blnSaved
        End Function
        Public Function AddMRS(ByVal CampaignDate As Date, ByVal UsableCopes1 As Integer, ByVal UsableDrags1 As Integer, ByVal ShortfallCopes1 As Integer, ByVal ShortfallDrags1 As Integer, ByVal Remarks1 As String, ByVal UsableCopes2 As Integer, ByVal UsableDrags2 As Integer, ByVal ShortfallCopes2 As Integer, ByVal ShortfallDrags2 As Integer, ByVal Remarks2 As String) As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim strInsert, strUpdate As String
            Dim Done As Boolean
            Try
                oCmd.Parameters.Add("@CampaignDate", SqlDbType.SmallDateTime, 4).Value = CDate(CampaignDate)
                oCmd.Parameters.Add("@Product", SqlDbType.VarChar, 6).Value = "BoxN"
                oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output

                strInsert = " insert into mm_MRSMouldCampaign ( CampaignDate , Product , UsableCopes , UsableDrags , ShortfallCopes , ShortfallDrags , Remarks )" &
                 " values ( @CampaignDate , @Product , @UsableCopes , @UsableDrags , @ShortfallCopes , @ShortfallDrags , @Remarks )"


                strUpdate = " update mm_MRSMouldCampaign set UsableCopes = @UsableCopes , UsableDrags = @UsableDrags , ShortfallCopes = @ShortfallCopes , ShortfallDrags = @ShortfallDrags , Remarks = @Remarks " &
                            " where CampaignDate = @CampaignDate and Product = 'BoxN'  "

                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                oCmd.CommandText = " select @cnt = count(*) from mm_MRSMouldCampaign where CampaignDate = @CampaignDate and Product = @Product "
                oCmd.ExecuteScalar()
                Done = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)
                If Done Then
                    oCmd.CommandText = strUpdate
                Else
                    oCmd.CommandText = strInsert
                End If
                Done = False
                oCmd.Parameters.Add("@UsableCopes", SqlDbType.Int, 4).Value = Val(UsableCopes1)
                oCmd.Parameters.Add("@UsableDrags", SqlDbType.Int, 4).Value = Val(UsableDrags1)
                oCmd.Parameters.Add("@ShortfallCopes", SqlDbType.Int, 4).Value = Val(ShortfallCopes1)
                oCmd.Parameters.Add("@ShortfallDrags", SqlDbType.Int, 4).Value = Val(ShortfallDrags1)
                oCmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = Remarks1.Trim & ""
                If oCmd.ExecuteNonQuery = 1 Then
                    oCmd.Parameters("@Product").Value = "BGC"
                    oCmd.CommandText = " select @cnt = count(*) from mm_MRSMouldCampaign where CampaignDate = @CampaignDate and Product = @Product "
                    oCmd.ExecuteScalar()
                    Done = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)

                    strUpdate = " update mm_MRSMouldCampaign set UsableCopes = @UsableCopes , UsableDrags = @UsableDrags , ShortfallCopes = @ShortfallCopes , ShortfallDrags = @ShortfallDrags , Remarks = @Remarks " &
                            " where CampaignDate = @CampaignDate and Product = 'BGC'  "
                    If Done Then
                        oCmd.CommandText = strUpdate
                    Else
                        oCmd.CommandText = strInsert
                    End If

                    Done = False
                    oCmd.Parameters("@UsableCopes").Value = Val(UsableCopes2)
                    oCmd.Parameters("@UsableDrags").Value = Val(UsableDrags2)
                    oCmd.Parameters("@ShortfallCopes").Value = Val(ShortfallCopes2)
                    oCmd.Parameters("@ShortfallDrags").Value = Val(ShortfallDrags2)
                    oCmd.Parameters("@Remarks").Value = Remarks2.Trim & ""
                    If oCmd.ExecuteNonQuery = 1 Then
                        Done = True
                    End If
                End If
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
            strInsert = Nothing
            strUpdate = Nothing
            Return Done
        End Function
        Public Function UpdateMouldSts(ByVal MldNo As String, ByVal Sts As String, ByVal UserID As String, ByVal McnDt As Date) As Boolean
            Dim auditStr, str1, str2, str3 As String
            Dim blnDone As New Boolean()
            Dim Cmd As System.Data.SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                Cmd.Parameters.Add("@MldNo", SqlDbType.VarChar, 50).Value = MldNo.Trim
                Cmd.Parameters.Add("@Sts", SqlDbType.VarChar, 2).Value = Sts.Trim
                Cmd.Parameters.Add("@ModifiedOn", SqlDbType.DateTime, 8).Value = Now
                Cmd.Parameters.Add("@UserID", SqlDbType.VarChar, 6).Value = UserID
                If Sts.Trim.ToLower = "c" Then
                    Cmd.Parameters.Add("@ConDt", SqlDbType.SmallDateTime, 4).Value = CDate(McnDt)
                    str1 = " Update mm_mmmdmt_dump set mld_sts = @Sts , dat_con = @ConDt WHERE mld_no = @MldNo "
                    str2 = " update mm_mould_master set mould_status = @Sts , condemned_date = @ConDt where mould_number = @MldNo "
                    str3 = " update a set mould_status = 'C' from mm_Mould_machining_details a " &
                           " inner join ( select mould_number , max(SlNo) SlNo from mm_Mould_machining_details " &
                           " group by mould_number ) b on  a.mould_number = b.mould_number and a.SlNo = b.SlNo " &
                           " where a.mould_number in  ( @MldNo ) "
                Else
                    str1 = " Update mm_mmmdmt_dump set mld_sts = @Sts , dat_con = '1900-01-01' WHERE mld_no = @MldNo "
                    str2 = " update mm_mould_master set mould_status = @Sts , condemned_date = '1900-01-01' where mould_number = @MldNo "
                    If Sts.Trim.ToLower = "m" Then
                        str3 = " update mm_mould_machining_details set mould_status = 'M' where mould_number = @MldNo and " &
                            " SlNo = ( select top 1 SlNo from mm_mould_machining_details  where mould_number = @MldNo " &
                            " order by SlNo desc )"
                    End If
                End If
                auditStr = " insert into mm_mould_master_status_change select rtrim(a.mould_number) mould_number , rtrim(type) type , rtrim(a.mould_status) MasterSts  ,  " &
                    " rtrim(mld_sts) mld_sts , rtrim(isnull(b.mould_status,'')) MachinigSts , MachinigDt  " &
                    " , @ModifiedOn , @UserID from mm_vw_mould_master a left outer join  " &
                    " ( select a.mould_number , mould_type , mould_status , machining_date MachinigDt from mm_Mould_machining_details a " &
                    " inner join ( select mould_number , max(SlNo) SlNo from mm_Mould_machining_details " &
                    " group by mould_number ) b on  a.mould_number = b.mould_number and a.SlNo = b.SlNo " &
                    " ) b on a.mould_number = b.mould_number where a.mould_number = @MldNo "

                If Cmd.Connection.State = ConnectionState.Closed Then Cmd.Connection.Open()
                Cmd.Transaction = Cmd.Connection.BeginTransaction
                If UserID = "085905" OrElse UserID = "074069" OrElse UserID = "081488" Then
                    Cmd.CommandText = "alter table dbo.mm_mould_master disable TRIGGER mm_tr_mould_master_UpdateStatusCheck"
                    Cmd.ExecuteNonQuery()
                End If
                Cmd.CommandText = auditStr
                If Cmd.ExecuteNonQuery = 1 Then
                    Cmd.CommandText = str1
                    If Cmd.ExecuteNonQuery = 1 Then
                        Cmd.CommandText = str2
                        If Cmd.ExecuteNonQuery = 1 Then
                            If Sts.Trim.ToLower = "m" Then
                                Cmd.CommandText = str3
                                If Cmd.ExecuteNonQuery > 0 Then
                                    blnDone = True
                                End If
                            Else
                                blnDone = True
                            End If
                        End If
                    End If
                End If
                If UserID = "085905" OrElse UserID = "074069" OrElse UserID = "081488" Then
                    Cmd.CommandText = "alter table dbo.mm_mould_master enable TRIGGER mm_tr_mould_master_UpdateStatusCheck"
                    Cmd.ExecuteNonQuery()
                End If
            Catch exp As Exception
                blnDone = False
                Throw New Exception(exp.Message)
            Finally
                If blnDone Then
                    Cmd.Transaction.Commit()
                Else
                    Cmd.Transaction.Rollback()
                End If
                If Cmd.Connection.State = ConnectionState.Open Then Cmd.Connection.Close()
                Cmd.Dispose()
                Cmd = Nothing
            End Try
            auditStr = Nothing
            str1 = Nothing
            str2 = Nothing
            str3 = Nothing
            Return blnDone
        End Function
        Public Function UpdateRemarks(ByVal MldNo As String, ByVal Sts As String, ByVal Sh As String, ByVal McnDt As Date) As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim Done As Boolean
            Try
                oCmd.Parameters.Add("@TransDate", SqlDbType.SmallDateTime, 4).Value = CDate(McnDt)
                oCmd.Parameters.Add("@Shift", SqlDbType.VarChar, 1).Value = Sh
                oCmd.Parameters.Add("@MouldNo", SqlDbType.VarChar, 50).Value = MldNo
                oCmd.Parameters.Add("@RemarksByMRS", SqlDbType.VarChar, 50).Value = Sts

                oCmd.CommandText = " update mm_MouldTransaction set RemarksByMRS = @RemarksByMRS " &
                           " where TransDate = @TransDate and Shift = @Shift and MouldNo = @MouldNo and TransType = 2 "
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                If oCmd.ExecuteNonQuery = 1 Then Done = True
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
        Public Function UpdateNewMouldNumber(ByVal OldNo As String, ByVal NewNo As String, ByVal NewDate As Date) As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim Done As Boolean
            Try
                oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                oCmd.Parameters.Add("@NewNo", SqlDbType.VarChar, 50).Value = NewNo
                oCmd.Parameters.Add("@MouldNo", SqlDbType.VarChar, 50).Value = OldNo
                oCmd.Parameters.Add("@NewDate", SqlDbType.SmallDateTime, 4).Value = NewDate
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                If MRSMRS.CheckMldNumber(OldNo) Then
                    oCmd.CommandText = " update mm_mould_master set ConvertedNumber = @NewNo , " &
                           " ConvertedDate = @NewDate where mould_number = @MouldNo "
                Else
                    Throw New Exception("InValid Mould Number !")
                End If
                If oCmd.ExecuteNonQuery = 1 Then Done = True
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
        Public Function UpdateFirm(ByVal Mould As String, ByVal Firm As String) As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim Done As Boolean
            Try
                oCmd.Parameters.Add("@Mould", SqlDbType.VarChar, 50).Value = Mould
                oCmd.Parameters.Add("@Firm", SqlDbType.VarChar, 50).Value = Firm

                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                oCmd.CommandText = "update mm_mould_master set supplier_code = @Firm where mould_number = @Mould "
                If oCmd.ExecuteNonQuery = 1 Then
                    oCmd.CommandText = " update mm_mmmdmt_dump set supp_code = @Firm where mld_no = @Mould "
                    If oCmd.ExecuteNonQuery = 1 Then Done = True
                Else
                    Throw New Exception("InValid Data !")
                End If
                If oCmd.ExecuteNonQuery = 1 Then Done = True
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
    <Serializable()> Public Class tables
        Public Shared Function FillMouldSts(ByVal Mould As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@mld", SqlDbType.VarChar, 50).Value = Mould.Trim
                da.SelectCommand.CommandText = " select rtrim(a.mould_number) MouldNo , rtrim(type) type , rtrim(a.mould_status) MasterSts  , rtrim(mld_sts) mld_sts , " &
                    " case when MachinigDt is null then rtrim(a.mould_status) else rtrim(isnull(b.mould_status,'')) end MachinigSts , " &
                    " case when MachinigDt is null then Convert(Varchar(10),ls_mac_dt,103)  else Convert(Varchar(10),MachinigDt,103)  end MachinigDt  " &
                    " from mm_vw_mould_master a left outer join  " &
                    " ( select a.mould_number , mould_type , mould_status , machining_date MachinigDt from mm_Mould_machining_details a " &
                    " inner join ( select mould_number , max(SlNo) SlNo from mm_Mould_machining_details " &
                    " group by mould_number ) b on  a.mould_number = b.mould_number and a.SlNo = b.SlNo " &
                    " ) b on a.mould_number = b.mould_number where a.mould_number = @mld "
                da.Fill(ds)
                FillMouldSts = ds.Tables(0)
            Catch exp As Exception
                FillMouldSts = Nothing
                Throw New Exception(" Retrival of Ingate Details List " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function FillSts() As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = " select distinct ltrim(rtrim(mould_status)) mould_status from mm_mould_master where isnull(mould_status,'') <> '' and mould_status <> 'C' "
                da.Fill(ds)
                FillSts = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(" Retrival of Ingate Details List " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function getMouldsMachined(ByVal machining_date As Date) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "Select a.mould_number, a.machining_date, a.Shift_code, " &
                    " a.Operation_type Original_McnCode, b.Operation_type Modified_McnCode  " &
                    " from mm_mould_machining_details_audit a inner join mm_mould_machining_details b " &
                    " on a.mould_number = b.mould_number and a.machining_date = b.machining_date  " &
                    " where a.Machining_date = @machining_date order by a.sl_no desc "
                da.SelectCommand.Parameters.Add("@machining_date", SqlDbType.SmallDateTime, 4).Value = machining_date
                da.Fill(ds)
                getMouldsMachined = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(" Retrival of Ingate Details List " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function getMRSMachines() As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "select rtrim(machine_code) machine_code from ms_machinery_master where machine_code like 'MSVTL%'"
                da.Fill(ds)
                getMRSMachines = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(" Retrival of Ingate Details List " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function getMROutTurnMRS() As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "select * from wap.dbo.mm_fn_MROutTurnMRS() "
                da.Fill(ds)
                getMROutTurnMRS = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(" Retrival of Ingate Details List " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function getMRSMouldCampaign(ByVal CampaignDate As Date) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "select  CampaignDate , Product , UsableCopes , UsableDrags , " &
                    " ShortfallCopes , ShortfallDrags , Remarks  from mm_MRSMouldCampaign " &
                    " where CampaignDate  = @CampaignDate "
                da.SelectCommand.Parameters.Add("@CampaignDate", SqlDbType.SmallDateTime, 4).Value = CampaignDate
                da.Fill(ds)
                getMRSMouldCampaign = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(" Retrival of Ingate Details List " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function GetDrawingNumber(ByVal PCode As String) As String
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@Drg", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output
            Try
                cmd.Connection.Open()
                cmd.CommandText = "select @Drg = ltrim(rtrim(drawing_number))  from mm_product_master where product_code = '" & PCode.Trim & " '"
                cmd.ExecuteScalar()
                If Trim(IIf(IsDBNull(cmd.Parameters("@Drg").Value), "", cmd.Parameters("@Drg").Value)).Length = 0 Then
                    Throw New Exception("InValid Drawing Number !")
                Else
                    GetDrawingNumber = cmd.Parameters("@Drg").Value
                End If
            Catch exp As Exception
                GetDrawingNumber = ""
                Throw New Exception(exp.Message)
            Finally
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function GetTransferedMouldsSavedData(ByVal SavedDate As Date) As DataSet
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@SavedDate", SqlDbType.SmallDateTime, 4).Value = CDate(SavedDate)
                da.SelectCommand.CommandText = " select row_number() over ( order by shift_code , a.mould_number ) SlNo , " &
                        " convert(varchar(11),transfer_date, 103) TransferDt , shift_code Shift , " &
                        " description , a.mould_number MouldNo , mould_type Type , remarks " &
                        " from mm_mould_transfer a inner join mm_mouldsize_master b  on a.mould_number =  b.mould_number  " &
                        " inner join mm_product_master c  on b.product_code = c.product_code " &
                        " where  transfer_date = @SavedDate  order by shift_code , a.mould_number ;" &
                        " select row_number() over ( order by shift_code , a.mould_number ) SlNo , convert(varchar(11),transfer_date, 103) TransferDt ,  " &
                        " shift_code Shift , a.mould_number MouldNo , mould_type Type , remarks  " &
                        " from mm_mould_transfer a left outer join mm_mouldsize_master b  on a.mould_number =  b.mould_number   " &
                        " left outer join mm_product_master c  on b.product_code = c.product_code  " &
                        " where  transfer_date = @SavedDate  and description is null " &
                        " order by shift_code , a.mould_number "
                da.Fill(ds)
                GetTransferedMouldsSavedData = ds.Copy
            Catch exp As Exception
                Throw New Exception(" Retrival of Transfer Moulds List error " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function getMouldReceiptDetails(ByVal receipt_date As Date, ByVal Shift As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "Select row_number() over ( order by a.receipt_date , a.mould_number ) Sl ,  " &
                    " Convert(Varchar(10),a.receipt_date,103)  Dt ,  a.shift_code Sh , " &
                    " a.mould_number MldNo , engraved_number EngNo , mould_type Type , graphite_height GrHt ,  " &
                    " Wheels_cast WhlsCst , a.mould_status Sts , remarks ,  MouldLife , IngateLife" &
                    " From mm_mould_receipt a left outer join mm_MouldReceipt b" &
                    " on a.mould_number = b.mould_number and a.receipt_date = b.receipt_date " &
                    " and a.shift_code = b.shift_code inner join mm_mould_master c on a.mould_number = c.mould_number " &
                    " where a.receipt_date = @receipt_date and a.shift_code = @Shift " &
                    " order by a.receipt_date , a.shift_code , a.mould_number "
                da.SelectCommand.Parameters.Add("@receipt_date", SqlDbType.SmallDateTime, 4).Value = receipt_date
                da.SelectCommand.Parameters.Add("@Shift", SqlDbType.VarChar, 1).Value = Shift
                da.Fill(ds, "MouldReceiptSavedData")
                getMouldReceiptDetails = ds.Tables("MouldReceiptSavedData")
            Catch exp As Exception
                Throw New Exception(" Retrival of Mould Receipt Details List " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function getIngateAssemblyDetails(ByVal ingate_date As Date, ByVal fitted_shift_code As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "Select Convert(Varchar(10),removed_date,103) as DateRemoved , " &
                    " fitted_shift_code Shift , drag_number DragNo , engraved_number EngNo , present_ingate PresentIG , " &
                    " a.supplier_code Supplier , past_ingate PastIG , " &
                    " Convert(Varchar(10),fitted_date,103) as DateFitted , wheels_cast WC " &
                    " From mm_ingate_assembly a inner join mm_mould_master b on a.drag_number = b.mould_number " &
                    " where ingate_date = @ingate_date and fitted_shift_code = @fitted_shift_code " &
                    " order by ingate_date, fitted_shift_code , drag_number "
                da.SelectCommand.Parameters.Add("@ingate_date", SqlDbType.SmallDateTime, 4).Value = ingate_date
                da.SelectCommand.Parameters.Add("@fitted_shift_code", SqlDbType.VarChar, 1).Value = fitted_shift_code
                da.Fill(ds, "IngateSavedData")
                getIngateAssemblyDetails = ds.Tables("IngateSavedData")
            Catch exp As Exception
                Throw New Exception(" Retrival of Ingate Details List " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function GetMouldAssemblyDetails(ByVal assembly_date As Date, ByVal shift_code As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "Select Convert(Varchar(10),assembly_date,103)  Dt , " &
                    " a.shift_code Shift , a.mould_number MldNo , engraved_number EngNo , a.type, intial_height IniHt , " &
                    " final_height FinalHt , graphite_removed GrLoss , ingates  " &
                    " From mm_mould_assembly a inner join mm_mould_master b on a.mould_number = b.mould_number " &
                    " where assembly_date = @assembly_date and a.shift_code = @shift_code " &
                    " order by assembly_date , a.shift_code ,  a.mould_number "
                da.SelectCommand.Parameters.Add("@assembly_date", SqlDbType.SmallDateTime, 4).Value = assembly_date
                da.SelectCommand.Parameters.Add("@shift_code", SqlDbType.VarChar, 1).Value = shift_code
                da.Fill(ds, "MouldSavedData")
                GetMouldAssemblyDetails = ds.Tables("MouldSavedData")
            Catch exp As Exception
                Throw New Exception(" Retrival of Mould Assembly Details List " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function getIngateDetails(ByVal ingate_date As Date, ByVal fitted_shift_code As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "Select Convert(Varchar(10),ingate_date,103) as IgDate , " &
                    " fitted_shift_code Shift , drag_number DragNo , engraved_number EngNo , present_ingate PresentIG , " &
                    " a.supplier_code Supplier , past_ingate PastIG , wheels_cast WC , " &
                    " Convert(Varchar(10),fitted_date,103) as DateFitted , " &
                    " Convert(Varchar(10),removed_date,103) as DateRemoved , reason_for_removal Reason " &
                    " From mm_ingate_assembly a inner join mm_mould_master b on a.drag_number = b.mould_number " &
                    " where ingate_date = @ingate_date and fitted_shift_code = @fitted_shift_code " &
                    " order by ingate_date, fitted_shift_code , drag_number "
                da.SelectCommand.Parameters.Add("@ingate_date", SqlDbType.SmallDateTime, 4).Value = ingate_date
                da.SelectCommand.Parameters.Add("@fitted_shift_code", SqlDbType.VarChar, 1).Value = fitted_shift_code
                da.Fill(ds, "IngateSavedData")
                getIngateDetails = ds.Tables("IngateSavedData")
            Catch exp As Exception
                Throw New Exception(" Retrival of Ingate Details List " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function GetMRSMachineRemarks() As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select Remarks , SlNo from mm_mould_machining_details_Remarks order by Remarks  "
            Try
                da.Fill(ds)
                GetMRSMachineRemarks = ds.Tables(0).Copy
            Catch exp As Exception
                Throw New Exception("Unable to Get MRS Machine Details Table")
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function CheckDrag(ByVal mould_number As String) As String
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                If da.SelectCommand.Connection.State = ConnectionState.Closed Then da.SelectCommand.Connection.Open()
                da.SelectCommand.CommandText = "select @mld_sts = mld_sts from mm_mmmdmt_dump where mld_no = '" & (mould_number.Trim) & "' and mld_typ = '" & "D" & "'"
                da.SelectCommand.Parameters.Add("@mld_sts", SqlDbType.VarChar, 10).Direction = ParameterDirection.Output
                da.SelectCommand.ExecuteScalar()
                If Not IsDBNull(da.SelectCommand.Parameters("@mld_sts").Value) Then
                    Select Case Trim(da.SelectCommand.Parameters("@mld_sts").Value)
                        Case "A"
                            CheckDrag = ""
                        Case "P"
                            CheckDrag = "The Mould is not received at assembly."
                        Case "I"
                            CheckDrag = ""
                        Case "C"
                            CheckDrag = "The mould is condemned !"
                        Case Else
                            CheckDrag = "The Mould is not Specified For any operation."
                    End Select
                Else
                    CheckDrag = "Either  The Mould is not existing or it's not a Drag "
                End If
            Catch exp As Exception
                Throw New Exception(" Checking of Drag inValid ! " & exp.Message)
            Finally
                If da.SelectCommand.Connection.State = ConnectionState.Open Then da.SelectCommand.Connection.Close()
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function getIngateReasons() As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "SELECT cast(code as varchar(50)) + ' - ' + [desc] as Code, [desc] as description FROM mm_mldrsn_dump where [desc] like '%Ingate%' order by convert(int,left(code,2)) desc"
                da.Fill(ds, "IngateReasons")
                getIngateReasons = ds.Tables("IngateReasons")
            Catch exp As Exception
                Throw New Exception(" Retrival of Mould Details List " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function getMouldDetails(ByVal MouldNo As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = " select * from mm_vw_MouldSizeMaster where mould_number = '" & MouldNo.Trim & "'"
                da.Fill(ds, "MouldDetails")
                getMouldDetails = ds.Tables("MouldDetails")
            Catch exp As Exception
                Throw New Exception(" Retrival of Mould Details List " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function getMouldSts(ByVal MouldNo As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@MouldNo", SqlDbType.VarChar, 10).Value = MouldNo
                da.SelectCommand.CommandText = " select rtrim(a.type) Type ,  " &
                    " rtrim(mould_status) Sts , convert(varchar(10),created_date,103) IntroDt , " &
                    " description WhlType , convert(varchar(10),condemned_date,103) ConDt , rtrim(supplier_code) Firm" &
                    " from mm_mould_master a left outer join mm_product_master b" &
                    " on a.product_code = b.product_code" &
                    " where mould_number = @MouldNo "
                da.Fill(ds)
                getMouldSts = ds.Tables(0).Copy
            Catch exp As Exception
                Throw New Exception(" Retrival of Mould Details List " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function CheckPO(ByVal PO As String, ByVal SupCode As String, ByVal PLNumber As String) As Boolean
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                If da.SelectCommand.Connection.State = ConnectionState.Closed Then da.SelectCommand.Connection.Open()
                da.SelectCommand.CommandText = " select @cnt = count(*) from pm_po_details a inner join pm_po_header b on a.po_number = b.po_number " &
                " where a.pl_number = '" & PLNumber.Trim & "' and a.po_number = '" & PO.Trim & "' and supplier_code = '" & SupCode.Trim & "' "
                da.SelectCommand.Parameters.Add("@cnt", SqlDbType.Bit, 1).Direction = ParameterDirection.Output
                da.SelectCommand.ExecuteScalar()
                CheckPO = da.SelectCommand.Parameters("@cnt").Value
            Catch exp As Exception
                Throw New Exception(" Checking of PO with SupplierCode inValid ! " & exp.Message)
            Finally
                If da.SelectCommand.Connection.State = ConnectionState.Open Then da.SelectCommand.Connection.Close()
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function getSupplier_codes() As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = " select * from mm_vw_si_mouldSupplierCodes "
                da.Fill(ds, "Suppliers")
                getSupplier_codes = ds.Tables("Suppliers")
            Catch exp As Exception
                Throw New Exception(" Retrival of Mould Supplier List " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function ProductCodesInMouldMasterTable(ByVal Yes As Boolean) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                If Yes Then
                    da.SelectCommand.CommandText = " select product_code , description from  mm_product_master " &
                                                   " where product_code in ( select distinct product_code from mm_mould_master where isnull(product_code,'') <> ''  ) order by description ; "
                Else
                    da.SelectCommand.CommandText = " select product_code , description from  mm_product_master " &
                                                                   " where product_code like '[1,2]%' order by description ; "
                End If
                da.Fill(ds, "ProductCodes")
                ProductCodesInMouldMasterTable = ds.Tables("ProductCodes")
            Catch exp As Exception
                Throw New Exception(" Retrival of Mould Product Codes " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function fillDrawing_number(ByVal product_code As String) As String
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = " select Drawing_number from  mm_product_master " &
                                " where product_code = '" & product_code.Trim & "'"
                da.Fill(ds, "ProductCodes")
                fillDrawing_number = ds.Tables("ProductCodes").Rows(0)(0) & ""
            Catch exp As Exception
                Throw New Exception(" Retrival of Product Code drawing number inValid ! " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
    End Class
    <Serializable()> Public NotInheritable Class Moulds
        Private Event MouldAssembly()
        Private Event IngateAssembly()
        Private Event IngateAssemblyEdit()
        Private Event Condemnation()
        Private Event TransferToMR()
        Private Event MouldIntroduction()
        Private Event MouldIntroductionEdit()
        Private Event MouldMachiningAdd()
        Private Event MouldReceipt()
#Region " Fields"
        Private sMessage, sIngSupplier, sMouldNumber, sShift, sMouldType, sMouldStatus, sRemarks, sOperator As String
        Private sPONumber, sSupplierCode, sBlankNumber, sProductCode, swap_drawing_number, sengraved_number, singate_number As String
        Private dmould_size, dMould_intial_height, dMould_final_height, dAsh_content, dPermiability, dStandard_height As Double
        Private dateDtRemoved, dateDtFitted, dateDate, dateMachining_date, dateReceipt_date, datereleased_date As Date
        Private blnForIngateAssembly, blnNewMouldIntroductionEdit, blnAllowMouldIntroductionEdit, blnInsert, blnUpdate As Boolean
        Private blnNewMouldIntroductionDelete As Boolean
        Private blnAllowMouldIntroduction, blnNewMouldIntroduction, blnAllowTransferToMR, blnForTransferToMR As Boolean
        Private blnForCondemnation, blnAllowCondemnation, blnIsValidCondemnationDate, blnMouldSizeExists As Boolean
        Private blnIngateAssemblyEdit, blnAllowIngateAssemblyEdit, blnAllowMouldMachiningAdd, blnAllowIngateAssembly, blnForMouldMachiningAdd As Boolean
        Private tblTransferMouldsWithoutPOSavedData, tblDragsPastDetails, tblIngateAssemblySavedData, tblSavedData As DataTable
        Private tblMouldMachinigData, tblTransferMouldsSavedData, tblMouldReceiptSavedData, tblCondemnedMouldsSavedData As DataTable
        Private sMachineCode, sDefect, sReason, sPastIngate, sPresentIngate, sSupplier As String
        Private intIngCnt, intWheelsCast, intLife, intAfter, intBefore, intMouldLife, intIngateLife, intWhlsCast As Integer
        Private blnAllowMouldAssembly, blnForMouldAssembly, blnForMouldReceipt, blnAllowMouldReceiptAdd As Boolean
#End Region
#Region " Property"
        ReadOnly Property CondemnedMouldsSavedData() As DataTable
            Get
                Return tblCondemnedMouldsSavedData
            End Get
        End Property
        Property WhlsCast() As Integer
            Get
                Return intWhlsCast
            End Get
            Set(ByVal Value As Integer)
                intWhlsCast = Value
            End Set
        End Property
        Property ForIngateAssemblyEdit() As Boolean
            Get
                Return blnIngateAssemblyEdit
            End Get
            Set(ByVal Value As Boolean)
                blnIngateAssemblyEdit = Value
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
        Property Defect() As String
            Get
                Return sDefect
            End Get
            Set(ByVal Value As String)
                sDefect = Value
            End Set
        End Property
        ReadOnly Property DragsPastDetails() As DataTable
            Get
                Return tblDragsPastDetails
            End Get
        End Property
        WriteOnly Property MouldSizeExists() As Boolean
            Set(ByVal Value As Boolean)
                blnMouldSizeExists = Value
            End Set
        End Property
        ReadOnly Property MouldMachinigData() As DataTable
            Get
                Return tblMouldMachinigData
            End Get
        End Property

        ReadOnly Property MouldReceiptSavedData() As DataTable
            Get
                Return tblMouldReceiptSavedData
            End Get
        End Property
        ReadOnly Property IngateAssemblySavedData() As DataTable
            Get
                Return tblIngateAssemblySavedData
            End Get
        End Property
        ReadOnly Property TransferMouldsWithoutPOSavedData() As DataTable
            Get
                Return tblTransferMouldsWithoutPOSavedData
            End Get
        End Property
        ReadOnly Property TransferMouldsSavedData() As DataTable
            Get
                Return tblTransferMouldsSavedData
            End Get
        End Property
        ReadOnly Property SavedData() As DataTable
            Get
                Return tblSavedData
            End Get
        End Property
        Property Reason() As String
            Get
                Return sReason
            End Get
            Set(ByVal Value As String)
                sReason = Value
            End Set
        End Property
        Property Supplier() As String
            Get
                Return sSupplier
            End Get
            Set(ByVal Value As String)
                sSupplier = Value
            End Set
        End Property
        Property WheelsCast() As Integer
            Get
                Return intWheelsCast
            End Get
            Set(ByVal Value As Integer)
                intWheelsCast = Value
            End Set
        End Property
        Property DtRemoved() As Date
            Get
                Return dateDtRemoved
            End Get
            Set(ByVal Value As Date)
                dateDtRemoved = Value
            End Set
        End Property
        Property DtFitted() As Date
            Get
                Return dateDtFitted
            End Get
            Set(ByVal Value As Date)
                dateDtFitted = Value
            End Set
        End Property
        Property mould_size() As Decimal
            Get
                Return dmould_size
            End Get
            Set(ByVal Value As Decimal)
                dmould_size = Value
            End Set
        End Property
        Property PONumber() As String
            Get
                Return sPONumber
            End Get
            Set(ByVal Value As String)
                sPONumber = Value
            End Set
        End Property
        Property Standard_height() As Double
            Get
                Return dStandard_height
            End Get
            Set(ByVal Value As Double)
                dStandard_height = Value
            End Set
        End Property
        Property released_date() As Date
            Get
                Return datereleased_date
            End Get
            Set(ByVal Value As Date)
                datereleased_date = Value
            End Set
        End Property
        Property ingate_number() As String
            Get
                Return singate_number
            End Get
            Set(ByVal Value As String)
                singate_number = Value
            End Set
        End Property
        Property engraved_number() As String
            Get
                Return sengraved_number
            End Get
            Set(ByVal Value As String)
                sengraved_number = Value
            End Set
        End Property
        Property wap_drawing_number() As String
            Get
                Return swap_drawing_number
            End Get
            Set(ByVal Value As String)
                swap_drawing_number = Value
            End Set
        End Property
        Property ProductCode() As String
            Get
                Return sProductCode
            End Get
            Set(ByVal Value As String)
                sProductCode = Value
            End Set
        End Property
        Property SupplierCode() As String
            Get
                Return sSupplierCode
            End Get
            Set(ByVal Value As String)
                sSupplierCode = Value
            End Set
        End Property
        Property IngSupplier() As String
            Get
                Return sIngSupplier
            End Get
            Set(ByVal Value As String)
                sIngSupplier = Value
            End Set
        End Property
        Property BlankNumber() As String
            Get
                Return sBlankNumber
            End Get
            Set(ByVal Value As String)
                sBlankNumber = Value
            End Set
        End Property
        Property AllowMouldIntroductionEdit() As Boolean
            Get
                Return blnAllowMouldIntroductionEdit
            End Get
            Set(ByVal Value As Boolean)
                blnAllowMouldIntroductionEdit = Value
            End Set
        End Property
        WriteOnly Property AllowMouldIntroduction()
            Set(ByVal Value)
                blnAllowMouldIntroduction = Value
            End Set
        End Property
        WriteOnly Property NewMouldIntroduction() As Boolean
            Set(ByVal Value As Boolean)
                blnNewMouldIntroduction = Value
            End Set
        End Property
        WriteOnly Property NewMouldIntroductionEdit() As Boolean
            Set(ByVal Value As Boolean)
                blnNewMouldIntroductionEdit = Value
            End Set
        End Property
        WriteOnly Property NewMouldIntroductionDelete() As Boolean
            Set(ByVal Value As Boolean)
                blnNewMouldIntroductionDelete = Value
            End Set
        End Property
        WriteOnly Property Operator1() As String
            Set(ByVal Value As String)
                sOperator = Value
            End Set
        End Property
        Property Receipt_date() As Date
            Get
                Return dateReceipt_date
            End Get
            Set(ByVal Value As Date)
                dateReceipt_date = Value
            End Set
        End Property
        Property AllowMouldReceiptAdd() As Boolean
            Get
                Return blnAllowMouldReceiptAdd
            End Get
            Set(ByVal Value As Boolean)
                blnAllowMouldReceiptAdd = Value
            End Set
        End Property
        Property AllowMouldMachiningAdd() As Boolean
            Get
                Return blnAllowMouldMachiningAdd
            End Get
            Set(ByVal Value As Boolean)
                blnAllowMouldMachiningAdd = Value
            End Set
        End Property
        Property AllowMouldAssembly() As Boolean
            Get
                Return blnAllowMouldAssembly
            End Get
            Set(ByVal Value As Boolean)
                blnAllowMouldAssembly = Value
            End Set
        End Property
        Property AllowIngateAssemblyEdit() As Boolean
            Get
                Return blnAllowIngateAssemblyEdit
            End Get
            Set(ByVal Value As Boolean)
                blnAllowIngateAssemblyEdit = Value
            End Set
        End Property
        Property AllowIngateAssembly() As Boolean
            Get
                Return blnAllowIngateAssembly
            End Get
            Set(ByVal Value As Boolean)
                blnAllowIngateAssembly = Value
            End Set
        End Property
        Property AllowTransferToMR() As Boolean
            Get
                Return blnAllowTransferToMR
            End Get
            Set(ByVal Value As Boolean)
                blnAllowTransferToMR = Value
            End Set
        End Property
        ReadOnly Property ValidCondemnationDate() As Boolean
            Get
                Return Not CheckConDt()
            End Get
        End Property
        Property Remarks() As String
            Get
                Return sRemarks
            End Get
            Set(ByVal Value As String)
                sRemarks = Value
            End Set
        End Property
        Property ForMouldReceipt() As Boolean
            Get
                Return blnForMouldReceipt
            End Get
            Set(ByVal Value As Boolean)
                blnForMouldReceipt = Value
            End Set
        End Property
        Property ForMouldAssembly() As Boolean
            Get
                Return blnForMouldAssembly
            End Get
            Set(ByVal Value As Boolean)
                blnForMouldAssembly = Value
            End Set
        End Property
        Property ForIngateAssembly() As Boolean
            Get
                Return blnForIngateAssembly
            End Get
            Set(ByVal Value As Boolean)
                blnForIngateAssembly = Value
            End Set
        End Property
        Property ForMouldMachiningAdd() As Boolean
            Get
                Return blnForMouldMachiningAdd
            End Get
            Set(ByVal Value As Boolean)
                blnForMouldMachiningAdd = Value
            End Set
        End Property
        Property ForTransferToMR() As Boolean
            Get
                Return blnForTransferToMR
            End Get
            Set(ByVal Value As Boolean)
                blnForTransferToMR = Value
            End Set
        End Property
        Property Mould_final_height() As Double
            Get
                Return dMould_final_height
            End Get
            Set(ByVal Value As Double)
                dMould_final_height = Value
            End Set
        End Property
        Property Mould_intial_height() As Double
            Get
                Return dMould_intial_height
            End Get
            Set(ByVal Value As Double)
                dMould_intial_height = Value
            End Set
        End Property
        Property Machining_date() As Date
            Get
                Return dateMachining_date
            End Get
            Set(ByVal Value As Date)
                dateMachining_date = Value
            End Set
        End Property
        Property ForCondemnation() As Boolean
            Get
                Return blnForCondemnation
            End Get
            Set(ByVal Value As Boolean)
                blnForCondemnation = Value
            End Set
        End Property
        Property MouldStatus() As String
            Get
                Return sMouldStatus
            End Get
            Set(ByVal Value As String)
                sMouldStatus = Value
            End Set
        End Property
        Property MouldType() As String
            Get
                Return sMouldType
            End Get
            Set(ByVal Value As String)
                sMouldType = Value
            End Set
        End Property
        Property Shift() As String
            Get
                Return sShift
            End Get
            Set(ByVal Value As String)
                sShift = Value
                If blnForMouldMachiningAdd Then
                    MouldMachiningSavedData(dateDate, sShift)
                End If
                If blnForTransferToMR Then
                    GetTransferMouldsSavedData(dateDate, sShift)
                End If
            End Set
        End Property
        Property MouldNumber() As String
            Get
                Return sMouldNumber
            End Get
            Set(ByVal Value As String)
                sMessage = ""
                sMouldNumber = Value
                If blnForMouldReceipt Then
                    RaiseEvent MouldReceipt()
                    If Not blnAllowMouldReceiptAdd Then
                        sMouldNumber = ""
                        Throw New Exception(sMessage & " ; Receipt of mould not allowed ")
                    End If
                End If
                If blnForMouldMachiningAdd Then
                    RaiseEvent MouldMachiningAdd()
                    If Not blnAllowMouldMachiningAdd Then
                        sMouldNumber = ""
                        Throw New Exception(sMessage & " ; Machining of mould in Add mode not allowed ")
                    End If
                End If
                If blnForIngateAssembly Then
                    RaiseEvent IngateAssembly()
                    If Not blnAllowIngateAssembly Then
                        sMouldNumber = ""
                        Throw New Exception(sMessage & " ; Ingate Assembly of mould not allowed ")
                    End If
                End If
                If blnForMouldAssembly Then
                    RaiseEvent MouldAssembly()
                    If Not blnAllowMouldAssembly Then
                        sMouldNumber = ""
                        Throw New Exception(sMessage & " ; Assembly of mould not allowed ")
                    End If
                End If
                If blnForCondemnation Then
                    RaiseEvent Condemnation()
                    If Not blnAllowCondemnation Then
                        sMouldNumber = ""
                        Throw New Exception(sMessage & " ; Condemnation of mould not allowed ")
                    End If
                End If
                If blnForTransferToMR Then
                    RaiseEvent TransferToMR()
                    If Not blnAllowTransferToMR Then
                        Throw New Exception(sMessage & " ; Mould Transfer To MR not allowed ")
                        sMouldNumber = ""
                    End If
                End If
                If blnNewMouldIntroduction Then
                    RaiseEvent MouldIntroduction()
                    If Not blnAllowMouldIntroduction Then
                        sMouldNumber = ""
                        Throw New Exception(sMessage & " ; New Mould Introduction of mould not allowed ")
                    End If
                End If
                If blnNewMouldIntroductionEdit Then
                    RaiseEvent MouldIntroductionEdit()
                    If Not blnAllowMouldIntroductionEdit Then
                        sMouldNumber = ""
                        Throw New Exception(sMessage & " ; New Mould Introduction of mould not allowed ")
                    End If
                End If
                If blnNewMouldIntroductionDelete Then
                    'RaiseEvent MouldIntroductionEdit()
                    If Not blnNewMouldIntroductionDelete Then
                        sMouldNumber = ""
                        Throw New Exception(sMessage & " ; New Mould Introduction of mould not allowed ")
                    End If
                End If
            End Set
        End Property
        Property MouldDate() As String
            Get
                Return dateDate
            End Get
            Set(ByVal Value As String)
                dateDate = Value
                Dim dt As New Date()
                dt = dateDate
                If dt > Now.Date Then
                    dateDate = "1900-01-01"
                    Throw New Exception("Date cannot be greater than Current Date")
                Else
                    If blnNewMouldIntroduction Or blnNewMouldIntroductionEdit Then
                        GetSavedData(dateDate)
                    ElseIf blnForMouldMachiningAdd Then
                        MouldMachiningSavedData(dateDate, sShift)
                    ElseIf blnForTransferToMR Then
                        GetTransferMouldsSavedData(dateDate, sShift)
                    ElseIf blnForCondemnation Then
                        GetCondemnedMouldsSavedData(dateDate)
                    End If
                End If
                dt = Nothing
            End Set
        End Property
        ReadOnly Property Message() As String
            Get
                Return sMessage
            End Get
        End Property
        Property Ash_content() As Double
            Get
                Return dAsh_content
            End Get
            Set(ByVal Value As Double)
                dAsh_content = Value
                If Val(dAsh_content) > 1 Then Throw New Exception("InValid ASH Content")
            End Set
        End Property
        Property Permiability() As Double
            Get
                Return dPermiability
            End Get
            Set(ByVal Value As Double)
                dPermiability = Value
                If Val(dPermiability) > 1 Then Throw New Exception("InValid Permiability")
            End Set
        End Property
        Property PastIngate() As String
            Get
                Return sPastIngate
            End Get
            Set(ByVal Value As String)
                sPastIngate = Value
            End Set
        End Property
        Property PresentIngate() As String
            Get
                Return sPresentIngate
            End Get
            Set(ByVal Value As String)
                sPresentIngate = Value
            End Set
        End Property
        Property Before() As Integer
            Get
                Return intBefore
            End Get
            Set(ByVal Value As Integer)
                intBefore = Value
            End Set
        End Property
        Property After() As Integer
            Get
                Return intAfter
            End Get
            Set(ByVal Value As Integer)
                intAfter = Value
            End Set
        End Property
        Property Life() As Integer
            Get
                Return intLife
            End Get
            Set(ByVal Value As Integer)
                intLife = Value
            End Set
        End Property
        Property IngCnt() As Integer
            Get
                Return intIngCnt
            End Get
            Set(ByVal Value As Integer)
                intIngCnt = Value
            End Set
        End Property
        Property MouldLife() As Integer
            Get
                Return intMouldLife
            End Get
            Set(ByVal Value As Integer)
                intMouldLife = Value
            End Set
        End Property
        Property IngateLife() As Integer
            Get
                Return intIngateLife
            End Get
            Set(ByVal Value As Integer)
                intIngateLife = Value
            End Set
        End Property
#End Region
#Region " Methods"
        Private Sub iniVal()
            sIngSupplier = ""
            intMouldLife = 0
            intIngateLife = 0
            blnAllowMouldReceiptAdd = False
            blnForMouldReceipt = False
            blnAllowMouldAssembly = False
            intIngCnt = 0
            intWhlsCast = 0
            blnForMouldAssembly = False
            blnIngateAssemblyEdit = False
            blnAllowIngateAssemblyEdit = False
            sMachineCode = ""
            sDefect = ""
            intBefore = 0
            intAfter = 0
            intLife = 0
            sReason = ""
            dateDtRemoved = "1900-01-01"
            sSupplier = ""
            intWheelsCast = 0
            dateDtFitted = "1900-01-01"
            sPastIngate = ""
            sPresentIngate = ""
            blnForIngateAssembly = False
            blnMouldSizeExists = False
            blnNewMouldIntroductionEdit = False
            blnAllowMouldIntroductionEdit = False
            blnNewMouldIntroductionDelete = False
            dmould_size = 0.0
            sPONumber = ""
            dStandard_height = 0.0
            dAsh_content = 0.0
            dPermiability = 0.0
            datereleased_date = "1900-1-1"
            singate_number = ""
            sengraved_number = ""
            swap_drawing_number = ""
            sProductCode = ""
            sBlankNumber = ""
            sSupplierCode = ""
            blnAllowMouldIntroduction = False
            blnNewMouldIntroduction = False
            dateReceipt_date = "1900-1-1"
            blnForTransferToMR = False
            blnAllowMouldMachiningAdd = False
            blnAllowIngateAssembly = False
            blnAllowTransferToMR = False
            blnAllowCondemnation = False
            dMould_intial_height = 0.0
            dMould_final_height = 0.0
            blnForCondemnation = False
            sMouldStatus = ""
            sMouldType = ""
            sMouldNumber = ""
            sShift = ""
            sMessage = ""
            dateDate = "1900-1-1"
            dateMachining_date = "1900-1-1"
            sRemarks = ""
            blnIsValidCondemnationDate = False
            blnUpdate = False
            blnInsert = False
            sOperator = ""
        End Sub
        Public Sub New()
            iniVal()
            AddHandler Me.IngateAssembly, AddressOf CheckForIGAssembly
            AddHandler Me.Condemnation, AddressOf GetMouldDetails
            AddHandler Me.TransferToMR, AddressOf CheckForTransferToMR
            AddHandler Me.MouldIntroduction, AddressOf CheckForNewMould
            AddHandler Me.MouldMachiningAdd, AddressOf CheckMouldStatusForMachining
            AddHandler Me.MouldReceipt, AddressOf CheckMouldStatusForReceipt
            AddHandler Me.MouldAssembly, AddressOf CheckForMouldAssembly
        End Sub
        Public Sub New(ByVal mldno As String, ByVal MouldDate As Date, Optional ByVal Stage As String = "")
            iniVal()
            AddHandler Me.IngateAssembly, AddressOf CheckForIGAssembly
            AddHandler Me.Condemnation, AddressOf GetMouldDetails
            AddHandler Me.TransferToMR, AddressOf CheckForTransferToMR
            AddHandler Me.MouldIntroductionEdit, AddressOf GetNewMouldDetails
            AddHandler Me.MouldMachiningAdd, AddressOf CheckMouldStatusForMachining
            AddHandler Me.IngateAssemblyEdit, AddressOf getIngateDetails
            Try
                sMouldNumber = mldno
                If blnForMouldMachiningAdd Then
                    RaiseEvent MouldMachiningAdd()
                    If Not blnAllowMouldMachiningAdd Then
                        Throw New Exception(sMessage & " ; Machining of mould not allowed ")
                        sMouldNumber = ""
                    End If
                End If
                If blnForCondemnation Then
                    RaiseEvent Condemnation()
                    If Not blnAllowCondemnation Then
                        Throw New Exception(sMessage & " ; Condemnation of mould not allowed ")
                        sMouldNumber = ""
                    End If
                End If
                If blnForTransferToMR Then
                    RaiseEvent TransferToMR()
                    If Not blnAllowTransferToMR Then
                        Throw New Exception(sMessage & " ; Condemnation of mould not allowed ")
                        sMouldNumber = ""
                    End If
                End If
                If Stage = "NewMouldEdit" Then
                    blnNewMouldIntroductionEdit = True
                    RaiseEvent MouldIntroductionEdit()
                    If Not blnAllowMouldIntroductionEdit Then
                        Throw New Exception(sMessage & " ; MouldIntroduction of mould not allowed ")
                        sMouldNumber = ""
                    End If
                End If
                If Stage = "IngateAssemblyEdit" Then
                    blnIngateAssemblyEdit = True
                    dateDate = MouldDate
                    RaiseEvent IngateAssemblyEdit()
                    If Not blnAllowIngateAssemblyEdit Then
                        sMouldNumber = ""
                        Throw New Exception(sMessage & " ; Ingate Assembly Edit of mould not allowed ")
                    End If
                End If
                Me.MouldNumber = mldno
            Catch exp As Exception
                Throw New Exception(exp.Message)
            End Try
        End Sub
        Public Sub New(ByVal mldno As String, ByVal mode As Boolean)
            iniVal()
            sMouldNumber = mldno
        End Sub
        Private Sub getIngateDetails()
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@MldNo", SqlDbType.VarChar, 50).Value = sMouldNumber.Trim
            oCmd.Parameters.Add("@ingate_date", SqlDbType.SmallDateTime, 4).Value = dateDate
            oCmd.Parameters.Add("@Cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            oCmd.CommandText = "Select  @Cnt = count(*) From mm_ingate_assembly where ingate_date = @ingate_date and drag_number = @MldNo ; "
            Try
                sMessage = ""
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.ExecuteScalar()
                If IIf(IsDBNull(oCmd.Parameters("@Cnt").Value), 0, oCmd.Parameters("@Cnt").Value) = 0 Then
                    sMessage = "Drag Number InValid !"
                End If
            Catch exp As Exception
                sMessage = exp.Message
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                If Not IsNothing(sMessage) Then
                    If sMessage.Trim.Length = 0 Then blnAllowIngateAssemblyEdit = True
                End If
                oCmd = Nothing
            End Try
        End Sub
        Private Sub GetCondemnedMouldsSavedData(ByVal machining_date As Date)
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " SELECT  row_number() over ( order by supp_code , a.Mould_number ) SlNo , " &
                    " a.Mould_number MouldNo ,  EngNo , mould_size MldSize , PONumber , bln_no , permeab ,  " &
                    " ash_content Ash , [Mould Height] MouldHt , CnHt ConHt ,  " &
                    " Ero , Dam , NosMach , NosD , NosE , supp_code Firm , no_whl_cas WhlsCast ,  " &
                    " convert(varchar(10),created_date,103) IntroDate , convert(varchar(10),Condemned_date,103) CondDt  , remarks " &
                    " FROM  mm_vw_Condemned_mould_details a left outer join mm_mouldsize_master b " &
                    " on b.mould_number = a.mould_number  " &
                    " WHERE Condemned_date  = @dt ORDER BY supp_code , a.Mould_number "
            da.SelectCommand.Parameters.Add("@dt", SqlDbType.SmallDateTime, 4).Value = CDate(machining_date)

            Try
                da.Fill(ds)
                tblCondemnedMouldsSavedData = ds.Tables(0).Copy
            Catch exp As Exception
                Throw New Exception("Unable to show Mould Consumption Details Table")
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Sub
        Private Sub GetTransferMouldsSavedData(ByVal machining_date As Date, ByVal shift_code As String)
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select row_number() over ( order by transfer_date , a.shift_code , a.mould_number ) SNo , " &
                    " convert(varchar(11),transfer_date , 103) TransferDt , a.shift_code Sh , a.mould_number MldNo , " &
                    " engraved_number EngNo , a.mould_type Type ,  a.operator_code Operator  , rtrim(remarks) Remarks " &
                    " from mm_mould_transfer a inner join mm_mould_master b on a.mould_number = b.mould_number " &
                    " where transfer_date = @dt and a.shift_code = @shift_code " &
                    " order by transfer_date , a.shift_code , a.mould_number ; " &
                    " select row_number() over ( order by a.mould_number ) SlNo , a.mould_number , " &
                    " convert(varchar(11), d.created_date , 103) IntroducedDt  from mm_mould_transfer a inner join mm_mould_master b  " &
                    " on a.mould_number = b.mould_number and b.type = a.mould_type  " &
                    " inner join mm_product_master c on c.Product_code = b.Product_code " &
                    " inner join mm_new_mould_introduction d on cope_drag_number = a.mould_number " &
                    " left join mm_mouldsize_master e on e.mould_number = a.mould_number " &
                    " where transfer_date = @dt and PONumber is null "
            da.SelectCommand.Parameters.Add("@dt", SqlDbType.SmallDateTime, 4).Value = CDate(machining_date)
            da.SelectCommand.Parameters.Add("@shift_code", SqlDbType.VarChar, 1).Value = shift_code
            Try
                da.Fill(ds)
                tblTransferMouldsSavedData = ds.Tables(0).Copy
                tblTransferMouldsWithoutPOSavedData = ds.Tables(1).Copy
            Catch exp As Exception
                Throw New Exception("Unable to show Mould Consumption Details Table")
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Sub
        Private Sub MouldMachiningSavedData(ByVal machining_date As Date, ByVal shift_code As String)
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select row_number() over ( order by machining_date ,a.shift_code, a.mould_number ) SNo , " &
                    " convert(varchar(11),machining_date , 103) MacDt , a.shift_code Sh , a.mould_number MldNo , " &
                    " engraved_number EngNo , a.mould_type Type ,  a.operator_code Operator , defect , operation_type MachineCode , " &
                    "  mould_intial_height IniHt , mould_final_height FinalHt ,  " &
                    " ( mould_intial_height  - mould_final_height ) GrLoss , a.mould_status Status , rtrim(remarks) Remarks , SlNo  " &
                    " from mm_mould_machining_details a inner join mm_mould_master b on a.mould_number = b.mould_number and b.type = a.mould_type " &
                    " inner join mm_product_master c on c.Product_code = b.Product_code " &
                    " where machining_date = @dt and a.shift_code = @shift_code " &
                    " order by machining_date ,a.shift_code, a.mould_number "
            da.SelectCommand.Parameters.Add("@dt", SqlDbType.SmallDateTime, 4).Value = CDate(machining_date)
            da.SelectCommand.Parameters.Add("@shift_code", SqlDbType.VarChar, 1).Value = shift_code
            Try
                da.Fill(ds)
                tblMouldMachinigData = ds.Tables(0).Copy
            Catch exp As Exception
                Throw New Exception("Unable to show Mould Consumption Details Table")
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Sub
        Private Sub GetSavedData(ByVal SavedDate As Date)
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@SavedDate", SqlDbType.SmallDateTime, 4).Value = CDate(SavedDate)
                da.SelectCommand.CommandText = " SELECT a.cope_drag_number MouldNo , a.type , " &
                    " convert(varchar(10), created_date,103) IntroDate , shift_code Sh , wap_drawing_number Drawing , " &
                    " description product_id , engraved_number EngNo ,  " &
                    " ingate_number IngType , ingate_supplier IngSup , convert(varchar(10), released_date,103) ReleasedDt , " &
                    " initial_height IniHt , permeability Per , ash_content Ash , mould_status MldSts , " &
                    " supplier_code , blank_number Blank , operator_code Op , Standard_height Ht , Remarks , mould_size , PONumber  " &
                    " FROM mm_new_mould_introduction a left outer join mm_mouldsize_master b " &
                    " on a.cope_drag_number =  b.mould_number inner join mm_product_master c " &
                    " on a.product_id = c.product_code where created_date = @SavedDate " &
                    " and b.mould_number not in ( select mould_number from mm_mould_receipt ) "
                da.Fill(ds, "NewMoulds")
                tblSavedData = ds.Tables("NewMoulds")
            Catch exp As Exception
                Throw New Exception(" Retrival of New Moulds List error " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Sub
        Private Sub GetMouldDetails()
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@MldNo", SqlDbType.VarChar, 50).Value = sMouldNumber.Trim
            oCmd.Parameters.Add("@type", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@mld_sts", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@mould_status", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@MldSts", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@machining_date", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@Mould_final_height", SqlDbType.Decimal, 8).Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@Mould_intial_height", SqlDbType.Float, 8).Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@remarks", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            oCmd.CommandText = " Select @type = type , @mould_status = mould_status From mm_mould_master where mould_number = @MldNo ; " &
                            " select @mld_sts = mld_sts from mm_mmmdmt_dump where mld_no = @MldNo ; " &
                            " select top 1  @machining_date = machining_date , @Mould_intial_height =  mould_intial_height , @Mould_final_height =  mould_final_height , @MldSts = mould_status " &
                            " , @remarks = remarks from  mm_mould_machining_details  where mould_number = @MldNo order by SlNo desc ; "
            Try
                sMessage = ""
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.ExecuteScalar()
                If IIf(IsDBNull(oCmd.Parameters("@type").Value), "", oCmd.Parameters("@type").Value) = "" Then
                    sMessage = "Mould Type Error !"
                ElseIf Trim(IIf(IsDBNull(oCmd.Parameters("@mould_status").Value), "", oCmd.Parameters("@mould_status").Value)).ToUpper = "C" Then
                    sMessage = "Mould Already Condemned in Mould Master!"
                ElseIf Trim(IIf(IsDBNull(oCmd.Parameters("@mld_sts").Value), "", oCmd.Parameters("@mld_sts").Value)).ToUpper = "C" Then
                    sMessage = "Mould Already Condemned in Mould Dump!"
                    'ElseIf Trim(IIf(IsDBNull(oCmd.Parameters("@MldSts").Value), "", oCmd.Parameters("@MldSts").Value)).ToUpper = "C" Then
                    '    sMessage = "Mould Already Condemned during Machining!"
                ElseIf dateDate < oCmd.Parameters("@machining_date").Value Then
                    sMessage = "Mould Condemnation Date is lesser than Machining Date !"
                Else
                    sMouldType = oCmd.Parameters("@type").Value
                    sMouldStatus = oCmd.Parameters("@mld_sts").Value
                    dateMachining_date = oCmd.Parameters("@machining_date").Value
                    dMould_intial_height = oCmd.Parameters("@Mould_intial_height").Value
                    dMould_final_height = oCmd.Parameters("@Mould_final_height").Value
                    sRemarks = Trim(oCmd.Parameters("@remarks").Value) & ""
                    If Not IsNothing(sMessage) Then
                        If sMessage.Trim.Length = 0 Then blnAllowCondemnation = True
                    End If
                End If
            Catch exp As Exception
                sMessage = exp.Message
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Sub
        Private Sub CheckMcnDt()
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@MldNo", SqlDbType.VarChar, 50).Value = sMouldNumber.Trim
            oCmd.Parameters.Add("@McnDate", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output

            oCmd.CommandText = "  select top 1 @McnDate = machining_date from  mm_mould_machining_details " &
                        " where mould_number = @MldNo order by SlNo desc  "

            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.ExecuteScalar()
                If dateDate = IIf(IsDBNull(oCmd.Parameters("@McnDate").Value), "1900-01-01", oCmd.Parameters("@McnDate").Value) Then
                    blnUpdate = True
                ElseIf dateDate < IIf(IsDBNull(oCmd.Parameters("@McnDate").Value), "1900-01-01", oCmd.Parameters("@McnDate").Value) Then
                    Throw New Exception("Mould Condemnation Date is lesser than Machining Date !")
                ElseIf dateDate > IIf(IsDBNull(oCmd.Parameters("@McnDate").Value), "1900-01-01", oCmd.Parameters("@McnDate").Value) Then
                    blnInsert = True
                End If
            Catch exp As Exception
                sMessage = exp.Message
            Finally
                oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Sub
        Public Sub CondemnMould()
            If blnAllowCondemnation Then
                Dim Done As Boolean
                Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
                oCmd.Parameters.Add("@MldNo", SqlDbType.VarChar, 50).Value = sMouldNumber.Trim
                oCmd.Parameters.Add("@mould_status", SqlDbType.VarChar, 50).Value = sMouldStatus
                oCmd.Parameters.Add("@machining_date", SqlDbType.SmallDateTime, 4).Value = dateMachining_date
                oCmd.Parameters.Add("@MouldDate", SqlDbType.SmallDateTime, 4).Value = dateDate
                oCmd.Parameters.Add("@type", SqlDbType.VarChar, 50).Value = sMouldType
                oCmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 50).Value = sRemarks
                CheckMcnDt()
                Dim MachiningStr1 As String
                If blnUpdate Then
                    MachiningStr1 = "update mm_mould_machining_details set mould_status = 'C' , machining_date = @MouldDate , remarks = @remarks where mould_number = @MldNo and machining_date = @machining_date " &
                                               " and SlNo = ( select top 1 SlNo from  mm_mould_machining_details " &
                                               " where mould_number = @MldNo and machining_date = @MouldDate order by SlNo desc ) "
                ElseIf blnInsert Then
                    MachiningStr1 = "insert into mm_mould_machining_details " &
                        " select top 1  mould_number , mould_type , @MouldDate , shift_code , operator_code ," &
                        " transfer_note , defect , operation_type , mould_ingate_status , mould_final_height , " &
                        " mould_release_height , mould_final_height , 'C' , assembly_status , 0 , @remarks from  mm_mould_machining_details " &
                        " where mould_number = @MldNo  order by SlNo desc  "
                Else
                    sMessage = " InValid Date !"
                    Exit Sub
                End If
                Dim updateStr2 As String = "update mm_mould_master set mould_status = 'C', condemned_date = @MouldDate where mould_number = @MldNo and type = @type "
                Dim updateStr3 As String = "Update mm_mmmdmt_dump SET mld_sts = 'C' , dat_con = @MouldDate WHERE mld_no = @MldNo and mld_typ = @type "
                Try
                    If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                    oCmd.Transaction = oCmd.Connection.BeginTransaction
                    oCmd.CommandText = MachiningStr1
                    If oCmd.ExecuteNonQuery = 1 Then
                        oCmd.CommandText = updateStr2
                        If oCmd.ExecuteNonQuery = 1 Then
                            oCmd.CommandText = updateStr3
                            If oCmd.ExecuteNonQuery = 1 Then
                                Done = True
                            Else
                                Throw New Exception(" updation of mm_mmmdmt_dump failed !")
                            End If
                        Else
                            Throw New Exception(" updation of mm_mould_master failed !")
                        End If
                    Else
                        Throw New Exception(" updation of mm_mould_machining_details failed !")
                    End If

                Catch exp As Exception
                    Throw New Exception(exp.Message)
                Finally
                    If Not IsNothing(oCmd) Then
                        If Done Then
                            oCmd.Transaction.Commit()
                            sMessage = " Updation Successful !"
                        Else
                            oCmd.Transaction.Rollback()
                        End If
                        If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                        oCmd.Dispose()
                        oCmd = Nothing
                    End If
                    MachiningStr1 = Nothing
                    updateStr2 = Nothing
                    updateStr3 = Nothing
                    Done = Nothing
                End Try
            End If
        End Sub
        Public Sub AssembleIngateEdit()
            If blnAllowIngateAssemblyEdit Then
                Dim Done As Boolean
                Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
                oCmd.Parameters.Add("@MldNo", SqlDbType.VarChar, 50).Value = sMouldNumber.Trim
                oCmd.Parameters.Add("@MouldDate", SqlDbType.SmallDateTime, 4).Value = dateDate
                oCmd.Parameters.Add("@shift_code", SqlDbType.VarChar, 1).Value = sShift
                oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                oCmd.Parameters.Add("@supplier", SqlDbType.VarChar, 50).Value = sSupplier
                oCmd.Parameters.Add("@PastIngate", SqlDbType.VarChar, 50).Value = sPastIngate
                oCmd.Parameters.Add("@PresentIngate", SqlDbType.VarChar, 50).Value = sPresentIngate
                oCmd.Parameters.Add("@DtFitted", SqlDbType.SmallDateTime, 4).Value = dateDtFitted
                oCmd.Parameters.Add("@DtRemoved", SqlDbType.SmallDateTime, 4).Value = dateDtRemoved
                oCmd.Parameters.Add("@WheelsCast", SqlDbType.Int, 4).Value = intWheelsCast
                oCmd.Parameters.Add("@Reason", SqlDbType.VarChar, 50).Value = sReason

                Dim updateStr As String = "update mm_ingate_assembly set supplier_code = @supplier , past_ingate = @PastIngate , present_ingate = @PresentIngate , fitted_date = @DtFitted , removed_date = @DtRemoved ,wheels_cast = @WheelsCast where ingate_date = @MouldDate and fitted_shift_code = @shift_code and drag_number = @MldNo "
                Dim updateStrMaster As String = "Update mm_mould_master SET ingate_number = @PresentIngate WHERE mould_number = @MldNo "
                Try
                    If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                    oCmd.Transaction = oCmd.Connection.BeginTransaction
                    oCmd.CommandText = updateStr
                    If oCmd.ExecuteNonQuery = 1 Then
                        oCmd.CommandText = updateStrMaster
                        If oCmd.ExecuteNonQuery = 1 Then
                            Done = True
                        Else
                            Throw New Exception(" updation of mm_mould_master failed !")
                        End If
                    Else
                        Throw New Exception(" updatation of  mm_ingate_assembly failed !")
                    End If
                Catch exp As Exception
                    Throw New Exception(exp.Message)
                Finally
                    If Not IsNothing(oCmd) Then
                        If Done Then
                            oCmd.Transaction.Commit()
                            sMessage = " Updation Successful !"
                        Else
                            oCmd.Transaction.Rollback()
                        End If
                        If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                        oCmd.Dispose()
                        oCmd = Nothing
                    End If
                End Try
                Done = Nothing
                updateStrMaster = Nothing
                updateStr = Nothing
            End If
        End Sub
        Public Sub AssembleIngate()
            If blnAllowIngateAssembly Then
                Dim Done As Boolean
                Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
                oCmd.Parameters.Add("@MldNo", SqlDbType.VarChar, 50).Value = sMouldNumber.Trim
                oCmd.Parameters.Add("@MouldDate", SqlDbType.SmallDateTime, 4).Value = dateDate
                oCmd.Parameters.Add("@shift_code", SqlDbType.VarChar, 1).Value = sShift
                oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                oCmd.Parameters.Add("@supplier", SqlDbType.VarChar, 50).Value = sSupplier
                oCmd.Parameters.Add("@PastIngate", SqlDbType.VarChar, 50).Value = sPastIngate
                oCmd.Parameters.Add("@PresentIngate", SqlDbType.VarChar, 50).Value = sPresentIngate
                oCmd.Parameters.Add("@DtFitted", SqlDbType.SmallDateTime, 4).Value = dateDtFitted
                oCmd.Parameters.Add("@DtRemoved", SqlDbType.SmallDateTime, 4).Value = dateDtRemoved
                oCmd.Parameters.Add("@WheelsCast", SqlDbType.Int, 4).Value = intWheelsCast
                oCmd.Parameters.Add("@Reason", SqlDbType.VarChar, 50).Value = sReason

                Dim strCheck As String = "select @cnt = count(*) from mm_ingate_assembly where ingate_date = @MouldDate and  fitted_shift_code = @shift_code and drag_number = @MldNo "
                Dim insertStr As String = "insert into mm_ingate_assembly (ingate_date,supplier_code,past_ingate,present_ingate," &
                        " ingate_number,fitted_date,removed_date,wheels_cast,drag_number,reason_for_removal,fitted_shift_code) " &
                        " values (@MouldDate , @supplier , @PastIngate , @PresentIngate , @PresentIngate , @DtFitted , @DtRemoved , " &
                        " @WheelsCast , @MldNo , @Reason , @shift_code )"
                Dim updateStr1 As String = "Update mm_mmmdmt_dump SET mld_sts = 'G', inglif = 0 WHERE mld_no = @MldNo "
                Dim updateStrMaster As String = "Update mm_mould_master SET mould_status = 'G', ingate_number = @PresentIngate WHERE mould_number = @MldNo "
                Try
                    If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                    oCmd.Transaction = oCmd.Connection.BeginTransaction
                    oCmd.CommandText = strCheck
                    oCmd.ExecuteScalar()
                    If IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value) > 1 Then
                        Throw New Exception("Entry for Given Mould Number Date and Shift already exist.")
                    Else
                        oCmd.CommandText = insertStr
                        If oCmd.ExecuteNonQuery = 1 Then
                            oCmd.CommandText = updateStrMaster
                            If oCmd.ExecuteNonQuery = 1 Then
                                oCmd.CommandText = updateStr1
                                If oCmd.ExecuteNonQuery = 1 Then
                                    Done = True
                                Else
                                    Throw New Exception(" updation of mm_mmmdmt_dump failed !")
                                End If
                            Else
                                Throw New Exception(" updation of mm_mould_master failed !")
                            End If
                        Else
                            Throw New Exception(" insert into  mm_ingate_assembly failed !")
                        End If
                    End If
                Catch exp As Exception
                    Throw New Exception(exp.Message)
                Finally
                    If Not IsNothing(oCmd) Then
                        If Done Then
                            oCmd.Transaction.Commit()
                            sMessage = " Updation Successful !"
                        Else
                            oCmd.Transaction.Rollback()
                        End If
                        If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                        oCmd.Dispose()
                        oCmd = Nothing
                    End If
                End Try
                strCheck = Nothing
                insertStr = Nothing
                updateStr1 = Nothing
                updateStrMaster = Nothing
                Done = Nothing
            End If
        End Sub
        Public Sub MouldMachining()
            If blnAllowMouldMachiningAdd Then
                Dim done As Boolean
                Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
                cmd.Connection.Open()
                cmd.Parameters.Add("@MouldNumber", SqlDbType.VarChar, 50).Value = sMouldNumber
                If sMouldType = "C" Then
                    cmd.Parameters.Add("@TappedDate", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output
                    cmd.Parameters.Add("@TappedShift", SqlDbType.VarChar, 1).Direction = ParameterDirection.Output
                    cmd.Parameters.Add("@FirstHeat", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
                    cmd.Parameters.Add("@MinHeat", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
                    cmd.Parameters.Add("@MaxHeat", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output

                    cmd.CommandText = " select top 1 @TappedDate = machining_date , @TappedShift = shift_code" &
                            " from mm_mould_machining_details " &
                            " where mould_number = @MouldNumber order by SlNo desc "
                    cmd.ExecuteScalar()

                    If IsDBNull(cmd.Parameters("@TappedDate").Value) AndAlso IsDBNull(cmd.Parameters("@TappedShift").Value) Then
                        cmd.CommandText = "select @TappedDate = case when ls_mac_dt is null then mld_rel_dt else ls_mac_dt end " &
                            " from mm_mmmdmt_dump where mld_no = @MouldNumber "
                        cmd.ExecuteScalar()
                        cmd.Parameters("@TappedShift").Value = "A"
                    End If
                    cmd.Parameters("@TappedDate").Direction = ParameterDirection.Input
                    cmd.Parameters("@TappedShift").Direction = ParameterDirection.Input

                    cmd.CommandText = " select @FirstHeat = min(a.heat_number) " &
                            " from mm_vw_HeatTapped a inner join mm_pouring b on a.heat_number = b.heat_number " &
                            " where TappedDate = @TappedDate and TappedShift = @TappedShift ; "
                    cmd.ExecuteScalar()

                    cmd.Parameters("@FirstHeat").Direction = ParameterDirection.Input

                    cmd.CommandText = " select @MinHeat = min(a.heat_number)  , @MaxHeat = max(a.heat_number)  " &
                            " from mm_vw_HeatTapped a inner join mm_pouring b on a.heat_number = b.heat_number " &
                            " where a.heat_number >=  @FirstHeat and cope_number =  @MouldNumber "
                    cmd.ExecuteScalar()
                    cmd.Parameters("@MinHeat").Direction = ParameterDirection.Input
                    cmd.Parameters("@MaxHeat").Direction = ParameterDirection.Input '

                End If

                cmd.CommandText = " insert into mm_mould_machining_details " &
                    "  ( mould_number , mould_type , machining_date , shift_code , operator_code , defect , operation_type , mould_intial_height , mould_final_height , mould_status , wheels_cast , remarks  )" &
                    " values ( @MouldNumber , @MouldType , @ConsumptionDate , @Shift , @Operator , @Defect , @Machine , @BeforeHt , @AfterHt , 'M' , @WheelsCast , @Remarks )"
                Try

                    cmd.Parameters.Add("@MouldType", SqlDbType.VarChar, 50).Value = sMouldType
                    cmd.Parameters.Add("@ConsumptionDate", SqlDbType.SmallDateTime, 4).Value = dateDate
                    cmd.Parameters.Add("@Shift", SqlDbType.VarChar, 1).Value = sShift
                    cmd.Parameters.Add("@Defect", SqlDbType.VarChar, 1).Value = sDefect
                    cmd.Parameters.Add("@Operator", SqlDbType.VarChar, 6).Value = sOperator
                    cmd.Parameters.Add("@Machine", SqlDbType.VarChar, 50).Value = sMachineCode
                    cmd.Parameters.Add("@BeforeHt", SqlDbType.Float, 8).Value = intBefore
                    cmd.Parameters.Add("@AfterHt", SqlDbType.Float, 8).Value = intAfter
                    cmd.Parameters.Add("@WheelsCast", SqlDbType.Float, 8).Value = intLife
                    cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = sRemarks

                    cmd.Transaction = cmd.Connection.BeginTransaction
                    If cmd.ExecuteNonQuery = 1 Then
                        cmd.CommandText = " Update mm_mmmdmt_dump SET no_whl_cas = no_whl_cas + cpdglf WHERE mld_no = @MouldNumber and mld_typ = @MouldType "
                        If cmd.ExecuteNonQuery = 1 Then
                            cmd.CommandText = "Update mm_mmmdmt_dump SET mld_sts = 'M', cpdglf = 0 , mld_fin_ht = @AfterHt , ls_mac_dt = @ConsumptionDate WHERE mld_no = @MouldNumber and mld_typ = @MouldType "
                            If cmd.ExecuteNonQuery = 1 Then
                                cmd.CommandText = " update mm_mould_master set mould_status = 'M', ingate_life = 0 , initial_height = @AfterHt where mould_number = @MouldNumber and type = @MouldType "
                                If cmd.ExecuteNonQuery = 1 Then
                                    done = True
                                    If sMouldType = "C" Then
                                        If IsDBNull(cmd.Parameters("@MinHeat").Value) AndAlso IsDBNull(cmd.Parameters("@MinHeat").Value) Then
                                        Else
                                            cmd.Parameters("@MaxHeat").Direction = ParameterDirection.Input
                                            cmd.CommandText = " insert into mm_MouldMachiningUsage " &
                                                 "  ( mould_number , machining_date , shift_code , FirstHeat , LastHeat , PreMachDate , PreMachSh  )" &
                                                 " values ( @MouldNumber , @ConsumptionDate , @Shift , @MinHeat , @MaxHeat , @TappedDate , @TappedShift  )"
                                            cmd.ExecuteNonQuery()
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                Catch exp As Exception
                    sMessage = exp.Message
                Finally
                    If done Then
                        cmd.Transaction.Commit()
                        sMessage = "Records added successfully !"
                    Else
                        cmd.Transaction.Rollback()
                        sMessage = "Records addtion failed !" & sMessage
                    End If
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                End Try
                done = Nothing
            End If
        End Sub
        Public Sub ReceiveMould()
            If blnAllowMouldReceiptAdd Then
                Dim Done As Boolean
                Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
                oCmd.Parameters.Add("@MldNo", SqlDbType.VarChar, 50).Value = sMouldNumber.Trim
                oCmd.Parameters.Add("@MouldDate", SqlDbType.SmallDateTime, 4).Value = dateDate
                oCmd.Parameters.Add("@shift_code", SqlDbType.VarChar, 1).Value = sShift
                oCmd.Parameters.Add("@Operator", SqlDbType.VarChar, 6).Value = sOperator
                oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                oCmd.Parameters.Add("@MldSts", SqlDbType.VarChar, 50).Value = sMouldStatus.Trim
                oCmd.Parameters.Add("@MouldType", SqlDbType.VarChar, 50).Value = sMouldType
                oCmd.Parameters.Add("@Life", SqlDbType.Int, 4).Value = intLife
                oCmd.Parameters.Add("@WhlsCast", SqlDbType.Int, 4).Value = intWhlsCast
                oCmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 100).Value = sRemarks.Trim
                oCmd.Parameters.Add("@MouldLife", SqlDbType.Int, 4).Value = intMouldLife
                oCmd.Parameters.Add("@IngateLife", SqlDbType.Int, 4).Value = intIngateLife
                Dim strCheck As String = "select @cnt = count(*) from mm_mould_receipt where receipt_date = @MouldDate and shift_code = @shift_code and mould_number = @MldNo "
                Dim insertStr As String = "insert into mm_mould_receipt (receipt_date , shift_code , operator_code , mould_number , mould_type , graphite_height , wheels_cast , mould_status , remarks ) " &
                                    " values ( @MouldDate , @shift_code , @Operator , @MldNo , @MouldType , @Life , @WhlsCast , @MldSts , @Remarks  )"
                Dim updateStr2 As String = "Update mm_mmmdmt_dump SET mld_sts = @MldSts , gra_ls_whl = @Life , ls_mac_dt = @MouldDate WHERE mld_no = @MldNo"
                Dim updateStr1 As String = "update mm_mould_master set mould_status = @MldSts where mould_number = @MldNo "
                Dim insertNewStr As String = "insert into mm_MouldReceipt ( receipt_date, shift_code, mould_number, MouldLife , IngateLife ) values ( @MouldDate , @shift_code, @MldNo , @MouldLife , @IngateLife )"
                Try
                    If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                    oCmd.Transaction = oCmd.Connection.BeginTransaction
                    oCmd.CommandText = strCheck
                    oCmd.ExecuteScalar()
                    If IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value) > 1 Then
                        Throw New Exception("Entry for Given Mould Number Date and Shift already exist.")
                    Else
                        oCmd.CommandText = insertStr
                        If oCmd.ExecuteNonQuery = 1 Then
                            oCmd.CommandText = updateStr1
                            If oCmd.ExecuteNonQuery = 1 Then
                                oCmd.CommandText = updateStr2
                                If oCmd.ExecuteNonQuery = 1 Then
                                    oCmd.CommandText = insertNewStr
                                    If oCmd.ExecuteNonQuery = 1 Then
                                        Done = True
                                    Else
                                        Throw New Exception(" updation of mm_MouldReceipt failed !")
                                    End If
                                Else
                                    Throw New Exception(" updation of mm_mmmdmt_dump failed !")
                                End If
                            Else
                                Throw New Exception(" updation of mm_mould_master failed !")
                            End If
                        Else
                            Throw New Exception(" insert into  mm_mould_transfer failed !")
                        End If
                    End If
                Catch exp As Exception
                    sMessage = exp.Message
                Finally
                    If Not IsNothing(oCmd) Then
                        If Done Then
                            oCmd.Transaction.Commit()
                            sMessage = " Updation Successful !"
                        Else
                            oCmd.Transaction.Rollback()
                        End If
                        If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                        oCmd.Dispose()
                        oCmd = Nothing
                    End If
                End Try
                Done = Nothing
                strCheck = Nothing
                insertStr = Nothing
                updateStr2 = Nothing
                updateStr1 = Nothing
                insertNewStr = Nothing
            End If
        End Sub
        Public Sub AssembleMould()
            If blnAllowMouldAssembly Then
                Dim Done As Boolean
                Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
                oCmd.Parameters.Add("@MldNo", SqlDbType.VarChar, 50).Value = sMouldNumber.Trim
                oCmd.Parameters.Add("@MouldDate", SqlDbType.SmallDateTime, 4).Value = dateDate
                oCmd.Parameters.Add("@shift_code", SqlDbType.VarChar, 1).Value = sShift
                oCmd.Parameters.Add("@Operator", SqlDbType.VarChar, 1).Value = sOperator
                oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                oCmd.Parameters.Add("@MouldType", SqlDbType.VarChar, 50).Value = sMouldType
                oCmd.Parameters.Add("@Before", SqlDbType.Int, 4).Value = intBefore
                oCmd.Parameters.Add("@After", SqlDbType.Int, 4).Value = intAfter
                oCmd.Parameters.Add("@Life", SqlDbType.Int, 4).Value = intLife
                If sMouldType.StartsWith("D") Then intIngCnt = intIngCnt Else intIngCnt = 0
                oCmd.Parameters.Add("@IngCnt", SqlDbType.Int, 4).Value = intIngCnt

                Dim strCheck As String = "select @cnt = count(*) from mm_mould_assembly where assembly_date = @MouldDate and shift_code = @shift_code and mould_number = @MldNo "
                Dim insertStr As String = "insert into mm_mould_assembly ( assembly_date, shift_code, operator_code , mould_number, type , intial_height , final_height , graphite_removed , ingates ) " &
                                    " values ( @MouldDate , @shift_code , @Operator , @MldNo , @MouldType , @Before , @After , @Life , @IngCnt )"
                Dim updateStr1 As String = "Update mm_mmmdmt_dump SET mld_sts = 'A' WHERE mld_no = @MldNo "
                Try
                    If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                    oCmd.Transaction = oCmd.Connection.BeginTransaction
                    oCmd.CommandText = strCheck
                    oCmd.ExecuteScalar()
                    If IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value) > 1 Then
                        Throw New Exception("Entry for Given Mould Number Date and Shift already exist.")
                    Else
                        oCmd.CommandText = insertStr
                        If oCmd.ExecuteNonQuery = 1 Then
                            oCmd.CommandText = updateStr1
                            If oCmd.ExecuteNonQuery = 1 Then
                                Done = True
                            Else
                                Throw New Exception(" updation of mm_mmmdmt_dump failed !")
                            End If
                        Else
                            Throw New Exception(" insert into  mm_ingate_assembly failed !")
                        End If
                    End If
                Catch exp As Exception
                    Throw New Exception(exp.Message)
                Finally
                    If Not IsNothing(oCmd) Then
                        If Done Then
                            oCmd.Transaction.Commit()
                            sMessage = " Updation Successful !"
                        Else
                            oCmd.Transaction.Rollback()
                        End If
                        If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                        oCmd.Dispose()
                        oCmd = Nothing
                    End If
                End Try
                Done = Nothing
                strCheck = Nothing
                insertStr = Nothing
                updateStr1 = Nothing
            End If
        End Sub
        Public Sub TransferMouldToMR()
            If blnAllowTransferToMR Then
                Dim Done As Boolean
                Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
                oCmd.Parameters.Add("@MldNo", SqlDbType.VarChar, 50).Value = sMouldNumber.Trim
                oCmd.Parameters.Add("@MouldDate", SqlDbType.SmallDateTime, 4).Value = dateDate
                oCmd.Parameters.Add("@shift_code", SqlDbType.VarChar, 1).Value = sShift
                oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                oCmd.Parameters.Add("@Operator", SqlDbType.VarChar, 6).Value = sOperator
                oCmd.Parameters.Add("@type", SqlDbType.VarChar, 50).Value = sMouldType
                oCmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 50).Value = sRemarks
                Dim strCheck As String = "select @cnt = count(*) from mm_mould_transfer where transfer_date = @MouldDate and  shift_code = @shift_code and mould_number = @MldNo "
                Dim insertStr As String = " insert into mm_mould_transfer (transfer_date , shift_code , operator_code ,  mould_number , mould_type , remarks ) values (@MouldDate , @shift_code , @Operator , @MldNo , @type , @Remarks )"
                Dim updateStr As String = " update mm_mould_master set mould_status = '" & "P" & "' where mould_number = @MldNo "
                Dim updateStr1 As String = " Update mm_mmmdmt_dump SET mld_sts = 'P' WHERE mld_no = @MldNo "

                Try
                    If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                    oCmd.Transaction = oCmd.Connection.BeginTransaction
                    oCmd.CommandText = strCheck
                    oCmd.ExecuteScalar()
                    If IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value) > 1 Then
                        Throw New Exception("Entry for Given Mould Number Date and Shift already exist.")
                    Else
                        oCmd.CommandText = insertStr
                        If oCmd.ExecuteNonQuery = 1 Then
                            oCmd.CommandText = updateStr
                            If oCmd.ExecuteNonQuery = 1 Then
                                oCmd.CommandText = updateStr1
                                If oCmd.ExecuteNonQuery = 1 Then
                                    Done = True
                                Else
                                    Throw New Exception(" updation of mm_mmmdmt_dump failed !")
                                End If
                            Else
                                Throw New Exception(" updation of mm_mould_master failed !")
                            End If
                        Else
                            Throw New Exception(" insert into  mm_mould_transfer failed !")
                        End If
                    End If
                Catch exp As Exception
                    Throw New Exception(exp.Message)
                Finally
                    If Not IsNothing(oCmd) Then
                        If Done Then
                            oCmd.Transaction.Commit()
                            sMessage = " Updation Successful !"
                        Else
                            oCmd.Transaction.Rollback()
                        End If
                        If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                        oCmd.Dispose()
                        oCmd = Nothing
                    End If
                End Try
                Done = Nothing
                strCheck = Nothing
                insertStr = Nothing
                updateStr = Nothing
                updateStr1 = Nothing
            End If
        End Sub
        Private Sub CheckForMouldAssembly()
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@MldNo", SqlDbType.VarChar, 50).Value = sMouldNumber.Trim
            oCmd.Parameters.Add("@MldSts", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@mould_type", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@mould_final_height", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@mould_intial_height", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@no_ingates_used", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            Dim CheckMould As Boolean
            Try
                oCmd.CommandText = "select @MldSts = mld_sts from mm_mmmdmt_dump where mld_no = @MldNo ;" &
                        " select top 1 @mould_type = mould_type , @mould_intial_height = mould_intial_height , @mould_final_height = mould_final_height from mm_mould_machining_details  where mould_number = @MldNo order by SlNo desc ; " &
                        " select @no_ingates_used = count(*)  from mm_ingate_assembly where drag_number = @MldNo ; "

                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.ExecuteScalar()

                If Not IsDBNull(oCmd.Parameters("@MldSts").Value) Then
                    Select Case Trim(oCmd.Parameters("@MldSts").Value)
                        Case "M"
                            sMessage = "The Mould Received for Machining and Done."
                            CheckMould = True
                        Case "G"
                            sMessage = "The Mould Received for Machining and Done. Ingate Press Done"
                            CheckMould = True
                        Case "I"
                            CheckMould = False
                            Throw New Exception("The Mould Received for Machining and Done. Ingate Press Not Done")
                        Case "C"
                            CheckMould = False
                            Throw New Exception("The Mould is already Condemned.")
                        Case Else
                            CheckMould = False
                            Throw New Exception("The Mould " & sMouldNumber.Trim & " is not Specified For any operation.")
                    End Select
                    If CheckMould Then
                        sMouldStatus = Trim(oCmd.Parameters("@MldSts").Value)
                        sMouldType = oCmd.Parameters("@mould_type").Value
                        intBefore = oCmd.Parameters("@mould_intial_height").Value
                        intAfter = oCmd.Parameters("@mould_final_height").Value
                        intLife = intBefore - intAfter
                        If sMouldType = "C" Then
                            intIngCnt = 0
                        Else
                            If IIf(IsDBNull(oCmd.Parameters("@no_ingates_used").Value), 0, oCmd.Parameters("@no_ingates_used").Value) > 0 Then
                                intIngCnt = oCmd.Parameters("@no_ingates_used").Value
                            Else
                                intIngCnt = 1
                            End If
                        End If
                    End If
                Else
                    Throw New Exception("Either the Mould " & sMouldNumber.Trim & "  is not existing or it's not a Drag ")
                    sMouldNumber = ""
                    Exit Try
                End If
            Catch exp As Exception
                sMessage = exp.Message
                sMouldNumber = ""
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
                If CheckMould Then blnAllowMouldAssembly = True
            End Try
        End Sub
        Private Sub CheckForIGAssembly()
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@MldNo", SqlDbType.VarChar, 50).Value = sMouldNumber.Trim
            oCmd.Parameters.Add("@MldSts", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@ingate_number", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@released_date", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@present_ingate", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@fitted_date", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@WheelsCast", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            Try
                oCmd.CommandText = "select @MldSts = mld_sts , @WheelsCast = inglif from mm_mmmdmt_dump where mld_no = @MldNo and mld_typ = 'D' ;" &
                        " select @ingate_number = ingate_number , @released_date = released_date from mm_mould_master where mould_number = @MldNo ; " &
                        " Select @present_ingate = present_ingate , @fitted_date = ingate_date  " &
                        " From mm_ingate_assembly " &
                        " where ingate_date = (select max(ingate_date) from mm_ingate_assembly where drag_number = @MldNo) " &
                        " and drag_number = @MldNo ; "

                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.ExecuteScalar()
                If Not IsDBNull(oCmd.Parameters("@MldSts").Value) Then
                    Select Case Trim(oCmd.Parameters("@MldSts").Value)
                        Case "A"
                            sMessage = ""
                        Case "P"
                            Throw New Exception("The Mould " & sMouldNumber.Trim & " is not received at assembly.")
                        Case "I"
                            sMessage = ""
                        Case "C"
                            Throw New Exception("The Mould " & sMouldNumber.Trim & " is condemned !")
                        Case Else
                            Throw New Exception("The Mould " & sMouldNumber.Trim & " is not Specified For any operation.")
                    End Select
                    sMouldStatus = Trim(oCmd.Parameters("@MldSts").Value)
                    If IsDBNull(oCmd.Parameters("@present_ingate").Value) Then
                        If Trim(oCmd.Parameters("@ingate_number").Value) = "" Then
                            sPastIngate = ""
                            dateDtFitted = CDate("1900-01-01")
                            intWheelsCast = "0"
                        Else
                            sPastIngate = Trim(oCmd.Parameters("@ingate_number").Value)
                            dateDtFitted = CDate(oCmd.Parameters("@released_date").Value)
                            intWheelsCast = oCmd.Parameters("@WheelsCast").Value
                        End If
                    Else
                        sPastIngate = Trim(oCmd.Parameters("@present_ingate").Value)
                        dateDtFitted = CDate(oCmd.Parameters("@fitted_date").Value)
                        intWheelsCast = oCmd.Parameters("@WheelsCast").Value
                    End If
                Else
                    Throw New Exception("Either the Mould " & sMouldNumber.Trim & "  is not existing or it's not a Drag ")
                    sMouldNumber = ""
                    Exit Try
                End If
            Catch exp As Exception
                sMessage = exp.Message
                sMouldNumber = ""
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                If Not IsNothing(sMessage) Then
                    If sMessage.Trim.Length = 0 Then blnAllowIngateAssembly = True
                End If
                oCmd = Nothing
            End Try
            If blnAllowIngateAssembly Then
                Dim da As SqlClient.SqlDataAdapter
                Dim ds As New DataSet()
                da = rwfGen.Connection.Adapter
                Try
                    da.SelectCommand.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
                    da.SelectCommand.CommandText = " select top 5 convert(varchar(10),ingate_date,103) IngateDt , supplier_code Supplier , past_ingate PrevIG, present_ingate PresIG, convert(varchar,fitted_date,103) fitted_date , wheels_cast WC from mm_ingate_assembly where drag_number = @mould_number order by ingate_date desc"
                    da.SelectCommand.Parameters.Add("@mould_number", SqlDbType.VarChar, 50).Value = sMouldNumber.Trim
                    da.Fill(ds)
                    tblDragsPastDetails = ds.Tables(0)
                Catch exp As Exception
                    Throw New Exception(" Retrival of Drag Details error " & exp.Message)
                Finally
                    da.Dispose()
                    ds.Dispose()
                    da = Nothing
                    ds = Nothing
                End Try
            End If
        End Sub
        Private Sub CheckMouldStatusForReceipt()
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Parameters.Add("@mld", SqlDbType.VarChar, 50).Value = sMouldNumber
                cmd.Parameters.Add("@type", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                cmd.Parameters.Add("@graphite_height", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                cmd.Parameters.Add("@mld_sts", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                cmd.Parameters.Add("@Before", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                cmd.Parameters.Add("@After", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                cmd.Parameters.Add("@Life", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                cmd.Parameters.Add("@WhlsCast", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                cmd.CommandText = " select @mld_sts = mld_sts , @Before = cpdglf , @After = inglif , @type = mld_typ , @Life = mld_fin_ht  , " &
                     " @WhlsCast = no_whl_cas from mm_mmmdmt_dump where mld_no = @mld "
                cmd.Connection.Open()
                cmd.ExecuteScalar()
                sMouldStatus = Trim(IIf(IsDBNull(cmd.Parameters("@mld_sts").Value), "", cmd.Parameters("@mld_sts").Value))
                Select Case Left(sMouldStatus.ToUpper.Trim, 1)
                    Case "P"
                        sMessage = ""
                    Case "C"
                        sMessage = "The Mould is Condemned !. Hence Can't be received."
                        sMouldNumber = ""
                    Case Else
                        sMessage = "The Mould is not transfered to mould room.Hence Can't be received."
                        sMouldNumber = ""
                End Select
            Catch exp As Exception
                sMessage = exp.Message
            Finally
                If Not sMouldNumber.Trim = "" Then
                    blnAllowMouldReceiptAdd = True
                    sMouldType = IIf(IsDBNull(cmd.Parameters("@type").Value), "", cmd.Parameters("@type").Value)
                    intBefore = IIf(IsDBNull(cmd.Parameters("@Before").Value), "0", cmd.Parameters("@Before").Value)
                    intAfter = IIf(IsDBNull(cmd.Parameters("@After").Value), "0", cmd.Parameters("@After").Value)
                    intLife = IIf(IsDBNull(cmd.Parameters("@Life").Value), "0", cmd.Parameters("@Life").Value)
                    intWhlsCast = IIf(IsDBNull(cmd.Parameters("@WhlsCast").Value), 0, cmd.Parameters("@WhlsCast").Value)
                End If
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Sub
        Private Sub CheckMouldStatusForMachining()
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Parameters.Add("@mld", SqlDbType.VarChar, 50).Value = sMouldNumber
                cmd.Parameters.Add("@product_code", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                cmd.Parameters.Add("@type", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                cmd.Parameters.Add("@receipt_date", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output
                cmd.Parameters.Add("@shift_code", SqlDbType.VarChar, 1).Direction = ParameterDirection.Output
                cmd.Parameters.Add("@graphite_height", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                cmd.Parameters.Add("@mld_sts", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                cmd.Parameters.Add("@engraved_number", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                cmd.Parameters.Add("@cpdglf", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                cmd.Parameters.Add("@mould_size", SqlDbType.Float, 8).Direction = ParameterDirection.Output
                cmd.Parameters.Add("@PONumber", SqlDbType.VarChar, 9).Direction = ParameterDirection.Output
                cmd.CommandText = "select top 1 @receipt_date = receipt_date , @shift_code = shift_code from mm_mould_receipt where mould_number = @mld order by receipt_date desc ; " &
                     " select @type = type , @product_code = product_code , @engraved_number = engraved_number from mm_mould_master where mould_number = @mld ; " &
                     " select @mld_sts = mld_sts , @cpdglf = cpdglf , @graphite_height = mld_fin_ht from mm_mmmdmt_dump where mld_no = @mld " &
                     " select @mould_size = mould_size , @PONumber = PONumber from mm_mouldsize_master where mould_number = @mld "
                cmd.Connection.Open()
                cmd.ExecuteScalar()
                Dim strMouldStatus As String = Trim(IIf(IsDBNull(cmd.Parameters("@mld_sts").Value), "", cmd.Parameters("@mld_sts").Value))
                If IIf(IsDBNull(cmd.Parameters("@receipt_date").Value), "1900-01-01", cmd.Parameters("@receipt_date").Value) <= CDate(dateDate) Then
                    If IIf(IsDBNull(cmd.Parameters("@receipt_date").Value), "1900-01-01", cmd.Parameters("@receipt_date").Value) <> "1900-01-01" Then
                        sMouldType = Trim(cmd.Parameters("@type").Value)
                        sMouldStatus = Trim(cmd.Parameters("@mld_sts").Value)
                        If sMouldStatus.Trim.ToLower <> Trim("RE").ToLower Then
                            sMouldNumber = ""
                            Throw New Exception("The Mould Status is : " & strMouldStatus & " . So Mould " & sMouldNumber.Trim & " not Meant for Machining")
                            Exit Try
                        End If
                    Else
                        sMouldNumber = ""
                        Throw New Exception("Received Date at MRS is greater than Machining Date : '" & CDate(dateDate) & "'")
                        Exit Try
                    End If
                Else
                    sMouldNumber = ""
                    Throw New Exception("Mould : " & sMouldNumber.Trim & "is Not Received at MRS")
                    Exit Try
                End If
                strMouldStatus = Nothing
            Catch exp As Exception
                sMessage = exp.Message
            Finally
                If Not sMouldNumber.Trim = "" Then
                    blnAllowMouldMachiningAdd = True
                    If Trim(sMouldType).ToUpper = "D" Then
                        sengraved_number = IIf(IsDBNull(cmd.Parameters("@engraved_number").Value), "", cmd.Parameters("@engraved_number").Value)
                    End If
                    intBefore = IIf(IsDBNull(cmd.Parameters("@graphite_height").Value), "0", cmd.Parameters("@graphite_height").Value)
                    intLife = IIf(IsDBNull(cmd.Parameters("@cpdglf").Value), "0", cmd.Parameters("@cpdglf").Value)
                End If
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Sub
        Private Sub CheckForTransferToMR()
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@MldNo", SqlDbType.VarChar, 50).Value = sMouldNumber.Trim
            oCmd.Parameters.Add("@MldSts", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@type", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@Receipt_date", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output
            Try
                oCmd.CommandText = "SELECT @MldSts = mld_sts FROM mm_mmmdmt_dump WHERE mld_no = @MldNo ; " &
                    " Select @type = type From mm_mould_master where mould_number = @MldNo ;" &
                    " SELECT @Receipt_date = isnull(MAX(receipt_date),convert(smalldatetime,'1900-1-1')) FROM mm_mould_receipt WHERE mould_number =  @MldNo ; "
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.ExecuteScalar()
                If Not IsDBNull(oCmd.Parameters("@MldSts").Value) Then
                    sMouldStatus = Trim(oCmd.Parameters("@MldSts").Value)
                    sMouldType = Trim(oCmd.Parameters("@type").Value)
                    dateReceipt_date = oCmd.Parameters("@Receipt_date").Value
                Else
                    sMouldNumber = ""
                    Throw New Exception("Mould " & sMouldNumber.Trim & " is not valid mould number")
                    Exit Try
                End If
                If dateReceipt_date > dateDate Then
                    dateDate = ""
                    sMouldNumber = ""
                    Throw New Exception("Transfer date cannot be lesser then last receipt date " & dateReceipt_date.Date & "")
                    Exit Try
                End If
                Select Case Left(sMouldStatus.ToUpper.Trim, 1)
                    Case "P"
                        Throw New Exception("Mould " & sMouldNumber.Trim & " already sent to Mould Room")
                    Case "R"
                        Throw New Exception("Mould " & sMouldNumber.Trim & " Receieved ;to be Machined")
                    Case "I"
                        Throw New Exception("Mould " & sMouldNumber.Trim & " Machined ;to be Ingate Fitted")
                    Case "M"
                        Throw New Exception("Mould " & sMouldNumber.Trim & " Machined ;to be Assembled")
                    Case "G"
                        If sMouldType.Trim.ToLower = "c" Then
                            Throw New Exception("Mould " & sMouldNumber.Trim & " Ingate Fitted to be Assembled")
                        End If
                End Select
            Catch exp As Exception
                sMessage = exp.Message
                sMouldNumber = ""
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                If Not IsNothing(sMessage) Then
                    If sMessage.Trim.Length = 0 Then blnAllowTransferToMR = True
                End If
                oCmd = Nothing
            End Try
        End Sub
        Private Sub CheckForNewMould()
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@MldNo", SqlDbType.VarChar, 50).Value = sMouldNumber.Trim
            oCmd.Parameters.Add("@InDump", SqlDbType.Bit, 1).Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@InMaster", SqlDbType.Bit, 1).Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@InMouldIntroduction", SqlDbType.Bit, 1).Direction = ParameterDirection.Output
            Try
                oCmd.CommandText = "SELECT @InDump = count(*) FROM mm_mmmdmt_dump WHERE mld_no = @MldNo ; " &
                    " Select @InMaster = count(*) From mm_mould_master where mould_number = @MldNo ;" &
                    " SELECT @InMouldIntroduction = count(*) FROM mm_new_mould_introduction  WHERE cope_drag_number =  @MldNo ; "
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.ExecuteScalar()
                If oCmd.Parameters("@InDump").Value Then
                    Throw New Exception("Cope/Drag Number : " & sMouldNumber.Trim & " is in mmmdmt_dump !")
                    sMouldNumber = ""
                    Exit Try
                ElseIf oCmd.Parameters("@InMaster").Value Then
                    Throw New Exception("Cope/Drag Number : " & sMouldNumber.Trim & " is in mould_master !")
                    sMouldNumber = ""
                    Exit Try
                ElseIf oCmd.Parameters("@InMouldIntroduction").Value Then
                    Throw New Exception("Cope/Drag Number : " & sMouldNumber.Trim & " is in Mould Introduction !")
                    sMouldNumber = ""
                    Exit Try
                End If
            Catch exp As Exception
                sMessage = exp.Message
                sMouldNumber = ""
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                If Not IsNothing(sMessage) Then
                    If sMessage.Trim.Length = 0 Then blnAllowMouldIntroduction = True
                End If
                oCmd = Nothing
            End Try
        End Sub
        Public Sub GetNewMouldDetails()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
                da.SelectCommand.CommandText = " select type,created_date,shift_code,wap_drawing_number,product_id,engraved_number,ingate_number,released_date,initial_height,permeability,ash_content,mould_status,supplier_code,blank_number,operator_code,standard_height,Remarks from mm_new_mould_introduction  " &
                    " where cope_drag_number = '" & sMouldNumber.Trim & "' ; " &
                    " select  mould_size , PONumber from mm_mouldsize_master " &
                    " where mould_number = '" & sMouldNumber.Trim & "'  "
                da.Fill(ds, "NewMould")
                If ds.Tables(0).Rows.Count > 0 Then
                    blnAllowMouldIntroductionEdit = True
                    sMouldType = Trim(ds.Tables(0).Rows(0)("type"))
                    dateDate = CDate(ds.Tables(0).Rows(0)("created_date"))
                    sShift = Trim(ds.Tables(0).Rows(0)("shift_code"))
                    swap_drawing_number = Trim(ds.Tables(0).Rows(0)("wap_drawing_number"))
                    sProductCode = Trim(ds.Tables(0).Rows(0)("product_id"))
                    sengraved_number = Trim(ds.Tables(0).Rows(0)("engraved_number"))
                    singate_number = Trim(ds.Tables(0).Rows(0)("ingate_number"))
                    datereleased_date = CDate(Trim(ds.Tables(0).Rows(0)("released_date")))
                    dMould_intial_height = Val(ds.Tables(0).Rows(0)("initial_height"))
                    dPermiability = Val(ds.Tables(0).Rows(0)("permeability"))
                    dAsh_content = Val(ds.Tables(0).Rows(0)("ash_content"))
                    sMouldStatus = Trim(ds.Tables(0).Rows(0)("mould_status"))
                    sSupplierCode = Trim(ds.Tables(0).Rows(0)("supplier_code"))
                    sBlankNumber = Trim(ds.Tables(0).Rows(0)("blank_number"))
                    dStandard_height = Val(ds.Tables(0).Rows(0)("standard_height"))
                    sRemarks = IIf(IsDBNull(ds.Tables(0).Rows(0)("Remarks")), "", ds.Tables(0).Rows(0)("Remarks"))
                    If ds.Tables(1).Rows.Count > 0 Then
                        blnMouldSizeExists = True
                        dmould_size = IIf(IsDBNull(ds.Tables(1).Rows(0)("mould_size")), "52.5", ds.Tables(1).Rows(0)("mould_size"))
                        sPONumber = IIf(IsDBNull(Trim(ds.Tables(1).Rows(0)("PONumber"))), "", Trim(ds.Tables(1).Rows(0)("PONumber")))
                    Else
                        blnMouldSizeExists = False
                        dmould_size = "52.5"
                        sPONumber = ""
                    End If
                End If
            Catch exp As Exception
                Throw New Exception(" Retrival of New Mould Mould  List " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Sub
        Public Sub NewMouldValues(ByVal mode As String)
            Dim Done As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                oCmd.Parameters.Add("@MldNo", SqlDbType.VarChar, 50).Value = sMouldNumber.Trim
                oCmd.Parameters.Add("@type", SqlDbType.VarChar, 50).Value = sMouldType
                oCmd.Parameters.Add("@MouldDate", SqlDbType.SmallDateTime, 4).Value = dateDate
                oCmd.Parameters.Add("@shift_code", SqlDbType.VarChar, 1).Value = sShift
                oCmd.Parameters.Add("@wap_drawing_number", SqlDbType.VarChar, 30).Value = swap_drawing_number.Trim
                oCmd.Parameters.Add("@ProductCode", SqlDbType.VarChar, 20).Value = sProductCode
                oCmd.Parameters.Add("@engraved_number", SqlDbType.VarChar, 50).Value = sengraved_number
                oCmd.Parameters.Add("@ingate_number", SqlDbType.VarChar, 5).Value = singate_number
                oCmd.Parameters.Add("@released_date", SqlDbType.SmallDateTime, 4).Value = datereleased_date
                oCmd.Parameters.Add("@initial_height", SqlDbType.Float, 8).Value = dMould_intial_height
                oCmd.Parameters.Add("@Permiability", SqlDbType.Float, 8).Value = dPermiability
                oCmd.Parameters.Add("@Ash_content", SqlDbType.Float, 8).Value = dAsh_content
                oCmd.Parameters.Add("@mould_status", SqlDbType.VarChar, 50).Value = sMouldStatus
                oCmd.Parameters.Add("@SupplierCode", SqlDbType.VarChar, 50).Value = sSupplierCode
                oCmd.Parameters.Add("@BlankNumber", SqlDbType.VarChar, 50).Value = sBlankNumber
                oCmd.Parameters.Add("@Standard_height", SqlDbType.Float, 4).Value = dStandard_height
                oCmd.Parameters.Add("@Operator", SqlDbType.VarChar, 6).Value = sOperator
                oCmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = sRemarks
                oCmd.Parameters.Add("@mould_size", SqlDbType.Float, 8).Value = dmould_size
                oCmd.Parameters.Add("@PONumber", SqlDbType.VarChar, 9).Value = sPONumber
                oCmd.Parameters.Add("@ingate_supplier", SqlDbType.VarChar, 50).Value = sIngSupplier
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                If blnAllowMouldIntroduction Then
                    Select Case mode.ToLower
                        Case "add"
                            Done = NewMouldValuesAdd(oCmd)
                        Case "edit"
                            Done = NewMouldValuesEdit(oCmd)
                    End Select
                ElseIf blnNewMouldIntroductionDelete Then
                    Done = NewMouldValuesDelete(oCmd)
                End If
            Catch exp As Exception
                sMessage = exp.Message
            Finally
                If Not IsNothing(oCmd) Then
                    If Done Then
                        oCmd.Transaction.Commit()
                        sMessage = " Updation Successful !"
                    Else
                        oCmd.Transaction.Rollback()
                        sMessage = " Updation Failed !"
                    End If
                    If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                    oCmd.Dispose()
                    oCmd = Nothing
                End If
            End Try
        End Sub
        Private Function CheckConDt() As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@MldNo", SqlDbType.VarChar, 50).Value = sMouldNumber.Trim
            Select Case sShift.ToUpper
                Case "A"
                    oCmd.Parameters.Add("@MouldDate", SqlDbType.SmallDateTime, 4).Value = dateDate + " 06:00:00"
                Case "B"
                    oCmd.Parameters.Add("@MouldDate", SqlDbType.SmallDateTime, 4).Value = dateDate + " 14:00:00"
                Case "C"
                    oCmd.Parameters.Add("@MouldDate", SqlDbType.SmallDateTime, 4).Value = dateDate + " 22:00:00"
            End Select
            oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            If sMouldType.Trim.ToUpper = "C" Then
                oCmd.CommandText = "  select @cnt = count(*) from  mm_pouring " &
                                " where cope_number = @MldNo and pour_time >= @MouldDate  "
            Else
                oCmd.CommandText = "  select @cnt = count(*) from  mm_pouring " &
                                " where drag_number = @MldNo and pour_time >= @MouldDate  "
            End If
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.ExecuteScalar()
                If IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value) > 0 Then
                    CheckConDt = True
                    sMessage = "Wheels are poured even after condemnation date !"
                Else
                    CheckConDt = False
                End If
            Catch exp As Exception
                sMessage = exp.Message
                CheckConDt = False
            Finally
                oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function
        Private Function NewMouldValuesAdd(ByRef oCmd As SqlClient.SqlCommand) As Boolean
            Dim sqlstr As String = "insert into mm_new_mould_introduction(type,created_date,shift_code,wap_drawing_number,product_id," &
                " cope_drag_number,engraved_number,ingate_number,released_date,initial_height,permeability,ash_content,mould_status," &
                " supplier_code,blank_number,operator_code,standard_height,Remarks,ingate_supplier )" &
                "  values(@type,@MouldDate,@shift_code,@wap_drawing_number,@ProductCode," &
                " @MldNo,@engraved_number,@ingate_number,@released_date,@initial_height,@Permiability,@Ash_content,@mould_status," &
                " @SupplierCode,@BlankNumber,@Operator,@Standard_height,@Remarks,@ingate_supplier)"

            Dim sqlstr1 As String = "insert into mm_mould_master(type,created_date,shift_code,mould_number,wap_drawing_number,product_code,engraved_number,ingate_number,released_date,initial_height,permeability,ash_content,mould_status,supplier_code,blank_number,operator_code,ingate_life,standard_height) values("
            sqlstr1 &= "@type,@MouldDate,@shift_code,@MldNo,@wap_drawing_number,@ProductCode,@engraved_number,@ingate_number,@released_date,@initial_height,@Permiability,@Ash_content,@mould_status,@SupplierCode,@BlankNumber,@Operator,0,@Standard_height)"

            Dim sqlstr2 As String = "INSERT INTO mm_mmmdmt_dump (mld_typ,mld_no,mld_rel_dt,mld_sts,no_whl_cas,no_tim_rem,dat_ent,std_ht,gra_ls_whl,bln_no,mld_fin_ht,whls_mach,supp_code,inglif,cpdglf) Values ("
            sqlstr2 &= "@type,@MldNo,@released_date,@mould_status,0,0,@MouldDate,@Standard_height,0,@BlankNumber,@initial_height,0,@SupplierCode,0,0)"

            Dim sqlstr3 As String = " insert into mm_mouldsize_master ( mouldsize_date , mould_number , product_code , IsLatest , mould_size , PONumber ) " &
                        " values ( @MouldDate , @MldNo , @ProductCode , '1' , @mould_size , @PONumber  )"
            oCmd.CommandText = sqlstr
            If oCmd.ExecuteNonQuery = 1 Then
                oCmd.CommandText = sqlstr1
                If oCmd.ExecuteNonQuery = 1 Then
                    oCmd.CommandText = sqlstr2
                    If oCmd.ExecuteNonQuery = 1 Then
                        oCmd.CommandText = sqlstr3
                        If oCmd.ExecuteNonQuery = 1 Then
                            NewMouldValuesAdd = True
                        Else
                            Throw New Exception(" insert into mm_mouldsize_master failed !")
                        End If
                    Else
                        Throw New Exception(" insert into mm_mmmdmt_dump failed !")
                    End If
                Else
                    Throw New Exception(" insert into mm_mould_master failed !")
                End If
            Else
                Throw New Exception(" insert into  mm_new_mould_introduction failed !")
            End If
            sqlstr = Nothing
            sqlstr1 = Nothing
            sqlstr2 = Nothing
            sqlstr3 = Nothing
        End Function
        Private Function NewMouldValuesDelete(ByRef oCmd As SqlClient.SqlCommand) As Boolean
            Dim sqlstr As String = "delete mm_new_mould_introduction  where cope_drag_number = @MldNo "
            Dim sqlstr1 As String = " delete mm_mould_master where mould_number = @MldNo "
            Dim sqlstr2 As String = " delete mm_mmmdmt_dump where mld_no = @MldNo "
            Dim sqlstr3 As String = " delete mm_mouldsize_master where mould_number =  @MldNo   "


            oCmd.Parameters.Add("@ChangeDt", SqlDbType.DateTime, 8).Value = Now
            Dim auditstr As String = "insert into  mm_mould_master_audit  select type , created_date , shift_code , mould_number , product_code , " &
                        " wap_drawing_number , engraved_number , ingate_number , initial_height ," &
                        " released_date , condemned_date , permeability , ash_content , mould_status ," &
                        " supplier_code , blank_number , operator_code , cumulative_gra_removed , drag_to_cope_no ," &
                        " ingate_life , standard_height , no_times_used , " &
                        " @Operator , @ChangeDt , ConvertedNumber , ConvertedDate " &
                        " from mm_mould_master where mould_number = @MldNo "


            oCmd.CommandText = auditstr
            If oCmd.ExecuteNonQuery = 1 Then
                oCmd.CommandText = sqlstr1
                If oCmd.ExecuteNonQuery = 1 Then
                    oCmd.CommandText = sqlstr2
                    If oCmd.ExecuteNonQuery = 1 Then
                        oCmd.CommandText = sqlstr3
                        If oCmd.ExecuteNonQuery = 1 Then
                            oCmd.CommandText = sqlstr
                            If oCmd.ExecuteNonQuery = 1 Then
                                NewMouldValuesDelete = True
                            Else
                                Throw New Exception(" updation of master audit failed !")
                            End If
                        Else
                            Throw New Exception(" updation of mm_mouldsize_master failed !")
                        End If
                    Else
                        Throw New Exception(" updation of mm_mmmdmt_dump failed !")
                    End If
                Else
                    Throw New Exception(" updation of mm_mould_master failed !")
                End If
            Else
                Throw New Exception(" updation of  mm_new_mould_introduction failed !")
            End If
            sqlstr = Nothing
            sqlstr1 = Nothing
            sqlstr2 = Nothing
            sqlstr3 = Nothing
            auditstr = Nothing
        End Function
        Private Function NewMouldValuesEdit(ByRef oCmd As SqlClient.SqlCommand) As Boolean
            Dim sqlstr As String = "update mm_new_mould_introduction set type = @type ,created_date = @MouldDate ," &
                         " shift_code = @shift_code ,wap_drawing_number = @wap_drawing_number ,product_id = @ProductCode , " &
                         " engraved_number = @engraved_number, ingate_number = @ingate_number, " &
                         " released_date = @released_date, initial_height = @initial_height, permeability = @Permiability , " &
                         " ash_content = @Ash_content ,mould_status = @mould_status ,supplier_code = @SupplierCode , " &
                         " blank_number = @BlankNumber,  operator_code = @Operator, standard_height =  @Standard_height, Remarks = @Remarks " &
                         " ,ingate_supplier = @ingate_supplier where cope_drag_number = @MldNo "
            Dim sqlstr1 As String = " update mm_mould_master set type = @type, created_date = @MouldDate, shift_code = @shift_code , " &
                         " wap_drawing_number = @wap_drawing_number, product_code = @ProductCode, engraved_number = @engraved_number , " &
                         " @ingate_number = ingate_number,released_date = @released_date , " &
                         " permeability = @Permiability ,ash_content = @Ash_content ,mould_status = @mould_status , " &
                         " supplier_code = @SupplierCode , blank_number = @BlankNumber , operator_code = @Operator , " &
                         " standard_height = @Standard_height " &
                         " where mould_number = @MldNo "
            Dim sqlstr2 As String = " update mm_mmmdmt_dump set mld_typ = @type , mld_rel_dt = @released_date , " &
                         " mld_sts = @mould_status , dat_ent = @MouldDate , std_ht = @Standard_height , bln_no = @BlankNumber , " &
                         " supp_code = @SupplierCode where mld_no = @MldNo "
            Dim sqlstr3 As String
            If blnMouldSizeExists Then
                sqlstr3 = " update mm_mouldsize_master set mouldsize_date = @MouldDate  , product_code = @ProductCode , PONumber = @PONumber , " &
                                        " mould_size = @mould_size where mould_number =  @MldNo   "
            Else
                sqlstr3 = " insert into mm_mouldsize_master ( mouldsize_date , mould_number , product_code , IsLatest , mould_size , PONumber ) " &
                                        " values ( @MouldDate , @MldNo , @ProductCode , '1' , @mould_size , @PONumber  )"
            End If
            oCmd.Parameters.Add("@ChangeDt", SqlDbType.DateTime, 8).Value = Now
            Dim auditstr As String = "insert into  mm_mould_master_audit  select type , created_date , shift_code , mould_number , product_code , " &
                        " wap_drawing_number , engraved_number , ingate_number , initial_height ," &
                        " released_date , condemned_date , permeability , ash_content , mould_status ," &
                        " supplier_code , blank_number , operator_code , cumulative_gra_removed , drag_to_cope_no ," &
                        " ingate_life , standard_height , no_times_used , " &
                        " @Operator , @ChangeDt , ConvertedNumber , ConvertedDate " &
                        " from mm_mould_master where mould_number = @MldNo "


            oCmd.CommandText = sqlstr
            If oCmd.ExecuteNonQuery = 1 Then
                oCmd.CommandText = sqlstr1
                If oCmd.ExecuteNonQuery = 1 Then
                    oCmd.CommandText = sqlstr2
                    If oCmd.ExecuteNonQuery = 1 Then
                        oCmd.CommandText = sqlstr3
                        If oCmd.ExecuteNonQuery = 1 Then
                            oCmd.CommandText = auditstr
                            If oCmd.ExecuteNonQuery = 1 Then
                                NewMouldValuesEdit = True
                            Else
                                Throw New Exception(" updation of master audit failed !")
                            End If
                        Else
                            Throw New Exception(" updation of mm_mouldsize_master failed !")
                        End If
                    Else
                        Throw New Exception(" updation of mm_mmmdmt_dump failed !")
                    End If
                Else
                    Throw New Exception(" updation of mm_mould_master failed !")
                End If
            Else
                Throw New Exception(" updation of  mm_new_mould_introduction failed !")
            End If
            sqlstr = Nothing
            sqlstr1 = Nothing
            sqlstr2 = Nothing
            sqlstr3 = Nothing
            auditstr = Nothing
        End Function
        Public Function UpdateMouldPO() As Boolean
            Dim Done As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                oCmd.Parameters.Add("@MldNo", SqlDbType.VarChar, 50).Value = sMouldNumber.Trim
                oCmd.Parameters.Add("@mould_size", SqlDbType.Float, 8).Value = dmould_size
                oCmd.Parameters.Add("@PONumber", SqlDbType.VarChar, 9).Value = sPONumber
                oCmd.Parameters.Add("@ProductCode", SqlDbType.VarChar, 20).Value = sProductCode
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction

                Select Case blnMouldSizeExists
                    Case False
                        oCmd.CommandText = " insert into mm_mouldsize_master ( mouldsize_date , mould_number , product_code , IsLatest , mould_size , PONumber ) " &
                                 " values ( getdate() , @MldNo , @ProductCode , '1' , @mould_size , @PONumber  )"

                        Done = oCmd.ExecuteNonQuery
                    Case True
                        oCmd.CommandText = " update mm_mouldsize_master set mouldsize_date = getdate() , product_code = @ProductCode , IsLatest = '1' , mould_size = @mould_size  , PONumber = @PONumber  " &
                                "  where mould_number = @MldNo "
                        Done = oCmd.ExecuteNonQuery
                End Select
            Catch exp As Exception
                sMessage = exp.Message
            Finally
                If Not IsNothing(oCmd) Then
                    If Done Then
                        oCmd.Transaction.Commit()
                        sMessage = " Updation Successful !"
                    Else
                        oCmd.Transaction.Rollback()
                    End If
                    If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                    oCmd.Dispose()
                    oCmd = Nothing
                End If
                Done = Nothing
            End Try
        End Function
#End Region
    End Class
End Namespace