Namespace PCO
    Public Class tables
        Public Shared Function WorkorderCount(ByVal pattern As String) As Integer
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.CommandText = "select @cnt = wap.dbo.mm_fn_WorkorderCount(@pattern)"
            cmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            Try
                cmd.Parameters.Add("@pattern", SqlDbType.VarChar, 2).Value = pattern
                cmd.Connection.Open()
                cmd.ExecuteScalar()
                WorkorderCount = IIf(IsDBNull(cmd.Parameters("@cnt").Value), 0, cmd.Parameters("@cnt").Value)
            Catch exp As Exception
                WorkorderCount = False
                Throw New Exception(exp.Message)
            Finally
                If IsNothing(cmd) = False Then
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                End If
            End Try
        End Function
        Public Shared Function WorkorderParameters() As DataSet
            Try
                Dim ds As New DataSet()
                Dim da As SqlClient.SqlDataAdapter
                da = rwfGen.Connection.Adapter
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.CommandText = "mm_sp_WorkorderParameters"
                Try
                    da.Fill(ds)
                    WorkorderParameters = ds.Copy
                Catch exp As Exception
                    Throw New Exception(exp.Message)
                Finally
                    da.Dispose()
                    ds.Dispose()
                    da = Nothing
                    ds = Nothing
                End Try
            Catch exp As Exception
                Throw New Exception(exp.Message)
            End Try
        End Function
        Public Shared Function GetAxleDetails(ByVal product_code As String) As DataSet
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@product_code", SqlDbType.VarChar, 50).Value = product_code
            cmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            cmd.CommandText = "select @cnt = count(*) from mm_Product_Master " & _
                " where product_code = @product_code "
            Try
                cmd.Connection.Open()
                cmd.ExecuteScalar()
                If IIf(IsDBNull(cmd.Parameters("@cnt").Value), 0, cmd.Parameters("@cnt").Value) > 0 Then
                    Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
                    da.SelectCommand.Parameters.Add("@product_code", SqlDbType.VarChar, 50).Value = product_code
                    Dim ds As New DataSet()
                    da.SelectCommand.CommandText = " select drawing_number , " & _
                        " description , case when isnull(type,'') = '' then 'RWF' else ltrim(rtrim(type)) end Make " & _
                        " from mm_Product_master where Product_Code = @product_code ; " & _
                        " select * from mm_vw_si_AxleProductStages " & _
                        " where @product_code in ( Product_Code , NextStageProductCode  ) "
                    Try
                        da.Fill(ds)
                        GetAxleDetails = ds.Copy
                    Catch exp As Exception
                        GetAxleDetails = Nothing
                        Throw New Exception(exp.Message)
                    Finally
                        ds.Dispose()
                        da.Dispose()
                        da = Nothing
                        ds = Nothing
                    End Try
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If IsNothing(cmd) = False Then
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                End If
            End Try
        End Function
        Public Shared Function WorkOrderOutTurn(ByVal pattern As String, ByVal Shop As String) As DataSet
            Try
                Dim ds As New DataSet()
                Dim da As SqlClient.SqlDataAdapter
                da = rwfGen.Connection.Adapter
                da.SelectCommand.Parameters.Add("@pattern", SqlDbType.VarChar, 2).Value = pattern.Trim
                da.SelectCommand.Parameters.Add("@Shop", SqlDbType.VarChar, 50).Value = Shop.Trim
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.CommandText = "mm_sp_WorkOrderOutTurn"
                Try
                    da.Fill(ds)
                    WorkOrderOutTurn = ds.Copy
                Catch exp As Exception
                    Throw New Exception(exp.Message)
                Finally
                    da.Dispose()
                    ds.Dispose()
                    da = Nothing
                    ds = Nothing
                End Try
            Catch exp As Exception
                Throw New Exception(exp.Message)
            End Try
        End Function
        Public Shared Function GetWOShops() As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = "select distinct Shop from mm_vw_WorkorderShops_new"
            Try
                da.Fill(ds)
                GetWOShops = ds.Tables(0)
            Catch exp As Exception
                GetWOShops = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function GetPreMonthWO() As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = "mm_sp_EnhanceWorkOrder"
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            Try
                da.Fill(ds)
                GetPreMonthWO = ds.Tables(0)
            Catch exp As Exception
                GetPreMonthWO = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function WorkingDate() As Date
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.CommandText = "select EnchancedDt from mm_vw_WorkingDate "
            Try
                cmd.Connection.Open()
                WorkingDate = cmd.ExecuteScalar
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If IsNothing(cmd) = False Then
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                End If
            End Try
        End Function
        Public Shared Function SetInventory(ByVal FrDt As Date, ByVal ToDt As Date, Optional ByVal QuerryID As Integer = 0) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = "SELECT convert(varchar(10),phl_Date,103) PHLDt  , " & _
                " groupTitle WSType , CountFor , cnt Qty " & _
                " FROM wap.dbo.mm_PHLGEN_WheelsetInventory " & _
                " WHERE phl_Date between @FrDt and  @ToDt and cnt <> 0  " & _
                " and CountFor in ( 'Ready for Desp' , 'Under Packing' ) order by phl_Date , CountFor "
            da.SelectCommand.Parameters.Add("@FrDt", SqlDbType.SmallDateTime, 4).Value = FrDt
            da.SelectCommand.Parameters.Add("@ToDt", SqlDbType.SmallDateTime, 4).Value = ToDt
            Try
                da.Fill(ds)
                SetInventory = ds.Tables(0)
            Catch exp As Exception
                SetInventory = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function BOMList(ByVal Product As String, ByVal SourceCode As String) As DataSet
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            If Product <> "A1" Then
                da.SelectCommand.CommandText = "select row_number() over ( order by PLNumber ) Sl , PLNumber , " & _
                    " PLNumberShortDescription , Quantity , UnitName , MaxRMRQty " & _
                    " FROM mm_vw_AxleShopBOMList where product_code = @SourceCode and Shop <> 'A1' ; " & _
                    " select a.product_code ProdCode , " & _
                    " case when isnull(type,'') = '' then 'RWF' else rtrim(type) end Make ," & _
                    " rtrim(description) AxleDescription , a.drawing_number DrawingNumber , rtrim(cast_group) CastGr , R43R16 " & _
                    " FROM mm_product_master a " & _
                    " left outer join mm_AxleProductMaster_R43R16Specs b" & _
                    " on a.product_code = b.product_code" & _
                    " where a.product_code = @SourceCode " & _
                    " and ( a.product_code in ( select ProductCode from mm_StageWise_AxleProductMaster )" & _
                    " or  a.product_code in ( select NextStageProductCode from mm_StageWise_AxleProductMaster ) )" & _
                    " select * from ( select a.product_code , a.cast_group , R43R16 " & _
                    " FROM mm_product_master a left outer join mm_AxleProductMaster_R43R16Specs b" & _
                    " on a.product_code = b.product_code" & _
                    " where a.product_code = @SourceCode ) x" & _
                    " inner join ( select a.product_code , a.cast_group , R43R16" & _
                    " FROM mm_product_master a left outer join mm_AxleProductMaster_R43R16Specs b" & _
                    " on a.product_code = b.product_code" & _
                    " where a.product_code = @SourceCode) y " & _
                    " on x.cast_group = y.cast_group and x.R43R16 = y.R43R16"
            Else
                da.SelectCommand.CommandText = "select row_number() over ( order by PLNumber ) Sl , PLNumber , " & _
                    " PLNumberShortDescription , Quantity , UnitName , MaxRMRQty " & _
                    " FROM mm_vw_AxleShopBOMList where product_code = @SourceCode and Shop = 'A1' ; " & _
                    " select rtrim(a.product_code) ProdCode , rtrim(a.description) WheelSetDescription , " & _
                    " a.drawing_number DrawingNumber , " & _
                    " rtrim(prod_id1) Wheel , rtrim(prod_id2) Axle" & _
                    " FROM mm_product_master a inner join mm_product_details b" & _
                    " on a.product_code = b.product_code" & _
                    " where  a.product_code  = @SourceCode " & _
                    " and isnull(prod_id1,'')  <> ''  and isnull(prod_id2,'')  <> '' " & _
                    " select * from ( select a.product_code , a.cast_group " & _
                    " FROM mm_product_master a " & _
                    " where a.product_code = @SourceCode ) x" & _
                    " inner join ( select a.product_code , a.cast_group " & _
                    " FROM mm_product_master a " & _
                    " where a.product_code = @SourceCode ) y " & _
                    " on x.cast_group = y.cast_group "
            End If


            da.SelectCommand.Parameters.Add("@SourceCode", SqlDbType.VarChar, 6).Value = SourceCode
            Try
                da.Fill(ds)
                BOMList = ds.Copy
            Catch exp As Exception
                BOMList = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function SelectShop() As String
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.CommandText = "select top 1 AuthorisedActivity from mm_MMS_Authorisations " & _
                " where AuthorisedActivity like 'Bill of Material%' and compliedDateTime = '1900-1-1'" & _
                " order by sl_no desc"
            Try
                cmd.Connection.Open()
                SelectShop = cmd.ExecuteScalar
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If IsNothing(cmd) = False Then
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                End If
            End Try
        End Function
        Public Shared Function RWFProductUnifiedPLList(ByVal UnifiedPL As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = "select UnifiedPL , ItemDescription ,  " & _
                " SpecificationNo , DrawingNo , Category " & _
                " from mm_product_UnifiedPL_Details " & _
                " where UnifiedPL = @UnifiedPL "
            da.SelectCommand.Parameters.Add("@UnifiedPL", SqlDbType.VarChar, 50).Value = UnifiedPL
            Try
                da.Fill(ds)
                RWFProductUnifiedPLList = ds.Tables(0)
            Catch exp As Exception
                RWFProductUnifiedPLList = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function RWFProductList(ByVal Product As String) As DataSet
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Dim ProductCode As String
            Select Case Product
                Case "Wheel"
                    ProductCode = "[1,2]%"
                Case "Axle"
                    ProductCode = "[3,4]%"
                Case "WheelSet"
                    ProductCode = "[5,6]%"
            End Select
            da.SelectCommand.CommandText = "Select product_code ProdCode , " &
                " case when isnull(type,'') = '' then 'RWP' else rtrim(type) end Make ," &
                " rtrim(description) ProductCodeShortDescription , rtrim(drawing_number) ProductDrawingNumber" &
                " FROM mm_product_master " &
                " where product_code in ( " &
                " select distinct a.product_code" &
                " FROM mm_product_master a " &
                " inner join mm_workorder b" &
                " on a.product_code = b.product_code" &
                " where a.product_code like @ProductCode ) " &
                " and product_code not in ( select ProductCode from mm_product_UnifiedPL ) " &
                " order by product_code ; " &
                " select ProductCode ,  a.UnifiedPL , drawing_number , " &
                " ItemDescription , SpecificationNo, DrawingNo, Category" &
                " from mm_product_UnifiedPL a inner join mm_product_UnifiedPL_Details b" &
                " on a.UnifiedPL = b.UnifiedPL inner join mm_product_master c  " &
                " on a.ProductCode = c.Product_Code  " &
                " where c.product_code like @ProductCode   order by c.product_code  "
#Disable Warning BC42104 ' Variable is used before it has been assigned a value
            da.SelectCommand.Parameters.Add("@ProductCode", SqlDbType.VarChar, 6).Value = ProductCode
#Enable Warning BC42104 ' Variable is used before it has been assigned a value
            Try
                da.Fill(ds)
                RWFProductList = ds.Copy
            Catch exp As Exception
                RWFProductList = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function RMRMaterialList() As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = "SELECT distinct material_description " &
                        " FROM wap.dbo.mm_rmr where material_description is not null " &
                        " order by material_description"
            Try
                da.Fill(ds)
                RMRMaterialList = ds.Tables(0)
            Catch exp As Exception
                RMRMaterialList = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function RMRIssued(ByVal RMRFrDt As Date, ByVal RMRToDt As Date, ByVal Material As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = "mm_sp_PCORMRIssued"
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.Add("@RMRFrDt", SqlDbType.SmallDateTime, 4).Value = RMRFrDt
            da.SelectCommand.Parameters.Add("@RMRToDt", SqlDbType.SmallDateTime, 4).Value = RMRToDt
            da.SelectCommand.Parameters.Add("@Material", SqlDbType.VarChar, 250).Value = Material
            Try
                da.Fill(ds)
                RMRIssued = ds.Tables(0)
            Catch exp As Exception
                RMRIssued = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function PPCTergets(ByVal finYear As String, ByVal product As String, ByVal FigFor As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Select Case FigFor
                Case "01C"
                    product = "Wheels"
                    FigFor = "Cast"
                Case "01G"
                    product = "Wheels"
                    FigFor = "Good"
                Case "02"
                    product = "Axles"
                    FigFor = ""
                Case "03"
                    product = "WheelSet"
                    FigFor = ""
                Case "02E"
                    product = "Axles"
                    FigFor = "External"
                Case "03E"
                    product = "WheelSet"
                    FigFor = "External"
                Case "02L"
                    product = "Axles"
                    FigFor = "LooseAxles"
                Case "02M"
                    product = "Axles"
                    FigFor = "MPTAxles"
            End Select
            da.SelectCommand.CommandText = "mm_sp_PPCTargetFigures"
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.Add("@finYear", SqlDbType.VarChar, 7).Value = finYear
            da.SelectCommand.Parameters.Add("@product", SqlDbType.VarChar, 15).Value = product
            da.SelectCommand.Parameters.Add("@FigFor", SqlDbType.VarChar, 50).Value = FigFor
            Try
                da.Fill(ds)
                PPCTergets = ds.Tables(0)
            Catch exp As Exception
                PPCTergets = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function MonthNames() As DataTable
            Dim dt As New DataTable()
            Dim dr As DataRow
            dt.TableName = "MonthName"
            dt.Columns.Add("MonthName")
            dt.Columns.Add("MonthValue")

            dr = dt.NewRow
            dr("MonthName") = "04.April"
            dr("MonthValue") = 1
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("MonthName") = "05.May"
            dr("MonthValue") = 2
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("MonthName") = "06.June"
            dr("MonthValue") = 3
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("MonthName") = "07.July"
            dr("MonthValue") = 4
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("MonthName") = "08.August"
            dr("MonthValue") = 5
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("MonthName") = "09.September"
            dr("MonthValue") = 6
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("MonthName") = "10.October"
            dr("MonthValue") = 7
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("MonthName") = "11.November"
            dr("MonthValue") = 8
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("MonthName") = "12.December"
            dr("MonthValue") = 9
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("MonthName") = "01.January"
            dr("MonthValue") = 10
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("MonthName") = "02.February"
            dr("MonthValue") = 11
            dt.Rows.Add(dr)

            dr = dt.NewRow
            dr("MonthName") = "03.March"
            dr("MonthValue") = 12
            dt.Rows.Add(dr)
            Return dt
        End Function
        Public Shared Function PPCFinYear() As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = "mm_sp_PPCYears"
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            Try
                da.Fill(ds)
                PPCFinYear = ds.Tables(0)
            Catch exp As Exception
                PPCFinYear = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function RMRSummary(ByVal WorkOrder As String, ByVal Type As Integer) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = "mm_sp_RMRSummary"
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.Add("@workorder", SqlDbType.VarChar, 50).Value = WorkOrder
            da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = Type
            Try
                da.Fill(ds)
                RMRSummary = ds.Tables(0)
            Catch exp As Exception
                RMRSummary = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function ValidateProduct(ByVal WorkOrder As String, ByVal ProductCode As String) As Boolean
            ' check up logic
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.CommandText = "select wap.dbo.mm_fn_CheckLateWo('" & WorkOrder & "', '" & ProductCode & "')"
            Dim blnvalidWo As Boolean
            Try
                cmd.Connection.Open()
                blnvalidWo = cmd.ExecuteScalar = 0
            Catch exp As Exception

            Finally
                If IsNothing(cmd) = False Then
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                End If
            End Try
            Return blnvalidWo
        End Function
        Public Shared Function populateGrid(ByVal WorkOrder As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = "select b.GenDate LateGenDt, a.product_code, a.description, a.shop_code, " &
                " a.workorder_quantity, a.start_date, a.start_shift, a.end_date, a.end_shift , SlNo " &
                " from mm_workorder a left outer join mm_workorder_late b on a.number = b.number " &
                " where a.number = '" & WorkOrder & "'"
            Try
                da.Fill(ds)
                populateGrid = ds.Tables(0)
            Catch exp As Exception
                populateGrid = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function ValidateWo(ByVal WorkOrder As String) As Boolean
            Try
                If WorkOrder.Trim.Length <> 4 Then
                    Throw New Exception("Invalid Work Order")
                Else
                    If IsNumeric(Left(WorkOrder, 1)) = False Then
                        Throw New Exception("Invalid Work Order")
                    End If
                    If ("ABCDEFGHIJKL").IndexOf((Mid(WorkOrder, 2, 1))) < 0 Then
                        Throw New Exception("Invalid Work Order")
                    End If
                    If IsNumeric(Mid(WorkOrder, 3, 1)) = False Then
                        Throw New Exception("Invalid Work Order")
                    End If
                    If ("ABEFGLMNP").IndexOf(Right(WorkOrder, 1)) < 0 Then
                        Throw New Exception("Invalid Work Order")
                    End If
                End If
            Catch exp As Exception
                ValidateWo = True
            End Try
            If ValidateWo Then
                Exit Function
            End If
            Dim blnInvalidWo As Boolean
            Dim sWoStr() As Char = WorkOrder.ToCharArray

            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@prevMnthWoCnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            cmd.Parameters.Add("@WoExists", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            cmd.CommandText = "select @prevMnthWoCnt = case when getdate() between start_date and end_date then 1 else 0 end, @WoExists = 1  from mm_workorder where number = '" & WorkOrder & "' "
            Try
                cmd.Connection.Open()
                cmd.ExecuteScalar()
                If IIf(IsDBNull(cmd.Parameters("@prevMnthWoCnt").Value), 0, cmd.Parameters("@prevMnthWoCnt").Value) > 0 Then
                    Throw New Exception("Wo should not be of current month")
                ElseIf IIf(IsDBNull(cmd.Parameters("@WoExists").Value), 0, cmd.Parameters("@WoExists").Value) > 0 Then
                    Throw New Exception("Wo exists")
                End If
            Catch exp As Exception
                blnInvalidWo = True
                Throw New Exception(exp.Message)
            Finally
                If IsNothing(cmd) = False Then
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                End If
            End Try
            Return blnInvalidWo
        End Function
        Public Shared Function fillRmRData(ByVal rblType As String, ByVal RmrNo As Integer) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                If rblType = "suspend" Then
                    da.SelectCommand.CommandText = "select workorder_number WO , convert(varchar,rmr_date,103) RMRDate , rmr_quantity RMRQty , " &
                        " rtrim(a.pl_number) PLNumber  , rtrim(short_description) PLDescription, a.consignee , status " &
                        " from mm_rmr a inner join pm_itemMaster b on a.pl_number = b.pl_number " &
                        " where number = " & CInt(RmrNo) & " and status in ( 'N' , 'Open' ) and isnull(quantity_issued,'') = '' "
                Else
                    da.SelectCommand.CommandText = "select workorder_number WO , convert(varchar,rmr_date,103) RMRDate , rmr_quantity RMRQty , " &
                        " rtrim(a.pl_number) PLNumber  , rtrim(short_description) PLDescription, b.consignee , status " &
                        " from mm_rmr a inner join pm_itemMaster b on a.pl_number = b.pl_number " &
                        " where number = " & CInt(RmrNo) & " and status =  'Suspended' "
                End If
                da.Fill(ds)
                fillRmRData = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(" Retrival of WO  error " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function FillCancelledRmRs() As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "select a.number from mm_rmr a inner join mm_workorder b " &
                    " on workorder_number = b.number and rmr_date >= start_date where a.status = 'Suspended'  " &
                    " and convert(varchar(6),start_date,112) in ( convert(varchar(6),getdate(),112) ,  convert(varchar(6),dateadd(m,-1,getdate()) ,112) ) " &
                    " order by a.number desc"
                da.Fill(ds)
                FillCancelledRmRs = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(" Retrival of WO  error " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function populateProduct(ByVal strWOval As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "select product_code , workorder_quantity from mm_workorder where number = '" & strWOval & "'"
                da.Fill(ds)
                populateProduct = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(" Retrival of WO  error " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function populateCompletedWOList(ByVal strWOval As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "mm_sp_RMRSummaryList"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.Add("@workorder", SqlDbType.VarChar, 50).Value = strWOval.Trim
                da.Fill(ds)
                populateCompletedWOList = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(" Retrival of WO  error " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function populateCompletedWO() As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "select convert(varchar(10),workorder_date,103) WODate , " &
                    " number WO , workorder_quantity WOQty , rmr_generated_qty RMRQty from mm_workorder" &
                    " where number in ( select distinct a.workorder_number WO" &
                    " FROM wap.dbo.mm_rmr a inner join wap.dbo.mm_product_master b" &
                    " on a.product_code = b.product_code inner join wap.dbo.mm_workorder c   " &
                    " on a.workorder_number = c.number  and a.rmr_quantity > 0  " &
                    " and ( a.rmr_date between start_date and " &
                    " end_date or datediff(d, a.rmr_date ,start_date ) between 1 and 8 )" &
                    " WHERE a.status NOT IN ('Suspended','Cancel')" &
                    " and convert(varchar(6),start_date,112) >= convert(varchar(6),getdate(),112)" &
                    " and workorder_quantity <= rmr_generated_qty " &
                    " and a.workorder_number not in ( select a.number from mm_workorder a inner join mm_workorder_late b " &
                    " on a.number = b.number ) ) " &
                    " order by workorder_date desc , number "
                da.Fill(ds)
                populateCompletedWO = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(" Retrival of WO  error " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function populateWO(ByVal RMRDate As Date) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@RMRDate", SqlDbType.SmallDateTime, 4).Value = RMRDate
            Try
                da.SelectCommand.CommandText = "select number from mm_workorder" &
                    " where number in ( select distinct a.number WO " &
                    " from wap.dbo.mm_workorder a left outer join wap.dbo.mm_rmr b" &
                    " on b.workorder_number = a.number  " &
                    " and ( b.rmr_date between start_date and" &
                    " end_date or datediff(d, b.rmr_date ,start_date ) between 1 and 8 )" &
                    " and a.status NOT IN ('Suspended','Cancel')" &
                    " and b.rmr_quantity > 0 inner join wap.dbo.mm_product_master c" &
                    " on a.product_code = c.product_code" &
                    " where(Convert(varchar(6), start_date, 112) >= Convert(varchar(6), getdate(), 112))" &
                    " and workorder_quantity > rmr_generated_qty " &
                    " and a.number not in ( select a.number from mm_workorder a inner join mm_workorder_late b " &
                    " on a.number = b.number ) and a.product_code in ( " &
                    " SELECT distinct product_code FROM mm_bill_of_material where product_code not like '[1,2]%' " &
                    " union SELECT distinct product_code FROM mm_product_master where product_code like '[1,2]%' ) ) " &
                    " order by workorder_date desc "
                da.Fill(ds)
                populateWO = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(" Retrival of WO  error " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function GetRMRDate() As Date
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.CommandText = "select top 1 @rmr_date = rmr_date from mm_rmr order by rmr_date desc "
            Try
                oCmd.Parameters.Add("@rmr_date", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output
                oCmd.Connection.Open()
                oCmd.ExecuteScalar()
                GetRMRDate = IIf(IsDBNull(oCmd.Parameters("@rmr_date").Value), Today(), oCmd.Parameters("@rmr_date").Value)
            Catch exp As Exception
                GetRMRDate = Today()
            Finally
                If IsNothing(oCmd) = False Then
                    If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                    oCmd.Dispose()
                    oCmd = Nothing
                End If
            End Try
        End Function
        Public Shared Function GetPLDetails(ByVal Workorder As String, ByVal product_code As String, ByVal route_code As String, ByVal route_sequence As String, ByVal shop_code As String, ByVal pl_number As String, ByVal status As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@workorder", SqlDbType.VarChar, 10).Value = Workorder
            da.SelectCommand.Parameters.Add("@product_code", SqlDbType.VarChar, 10).Value = product_code
            da.SelectCommand.Parameters.Add("@route_code", SqlDbType.VarChar, 10).Value = route_code
            da.SelectCommand.Parameters.Add("@route_sequence", SqlDbType.VarChar, 10).Value = route_sequence
            da.SelectCommand.Parameters.Add("@Shop_code", SqlDbType.VarChar, 10).Value = shop_code
            da.SelectCommand.Parameters.Add("@pl_number", SqlDbType.VarChar, 10).Value = pl_number
            da.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar, 10).Value = status
            Try
                da.SelectCommand.CommandText = "mm_sp_manual_rmr_range"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.Fill(ds)
                GetPLDetails = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(" Retrival of WO  error " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function FillRouteSequence(ByVal Workorder As String, ByVal ShopCode As String, ByVal pl_number As String, ByVal RouteCode As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Dim strSql As String
            Try
                da.SelectCommand.CommandText = "SELECT DISTINCT(route_sequence)  as text FROM mm_bill_of_material " &
                    " WHERE product_code = (SELECT case WHEN Left(Ltrim(product_code),1) IN (1,2) THEN '120120' ELSE product_code END " &
                    " FROM mm_workorder WHERE number = '" & Workorder & "' ) " &
                    " and shop_code = '" & ShopCode & "' " &
                    " and pl_number = '" & pl_number.Trim & "' and route_code = '" & RouteCode & "'"
                da.Fill(ds)
                FillRouteSequence = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(" Retrival of WO  error " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function FillRouteCode(ByVal Workorder As String, ByVal ShopCode As String, ByVal pl_number As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Dim strSql As String
            Try
                da.SelectCommand.CommandText = "SELECT DISTINCT(route_code) as text FROM mm_bill_of_material WHERE product_code = (SELECT case WHEN Left(Ltrim(product_code),1) IN (1,2) THEN '120120' ELSE product_code END FROM mm_workorder WHERE number = '" & Workorder.Trim & "')  and shop_code = '" & ShopCode & "' and pl_number = '" & pl_number.Trim & "'"
                da.Fill(ds)
                FillRouteCode = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(" Retrival of WO  error " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function FillPlNumber(ByVal product_code As String, ByVal Shop_code As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Dim strSql As String
            Try
                da.SelectCommand.Parameters.Add("@product_code", SqlDbType.VarChar, 10).Value = product_code
                da.SelectCommand.Parameters.Add("@Shop_code", SqlDbType.VarChar, 10).Value = Shop_code
                da.SelectCommand.CommandText = "mm_sp_manual_rmr_pl"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.Fill(ds)
                FillPlNumber = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(" Retrival of WO  error " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function FillShopCode(ByVal WO As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Dim strSql As String
            Try
                strSql = "if Right(RTrim('" & WO.Trim & "'),1) IN ('E','N','F','M','A')  "
                strSql &= "SELECT DISTINCT(shop_code) + ' : ' + description as ShopText, shop_code as ShopValue FROM mm_bill_of_material as B, mm_shop as S WHERE B.shop_code = S.code and product_code = (SELECT case WHEN Left(Ltrim(product_code),1) IN (1,2) THEN '120120' ELSE product_code END FROM mm_workorder WHERE number = '" & WO.Trim & "')  and shop_code LIKE Right(RTrim('" & WO.Trim & "'),1) + '%' "
                strSql &= "ELSE "
                strSql &= "if Right(RTrim('" & WO.Trim & "'),1) = 'G' "
                strSql &= "SELECT DISTINCT(shop_code) + ' : ' + description as ShopText, shop_code as ShopValue FROM mm_bill_of_material as B, mm_shop as S WHERE B.shop_code = S.code and product_code = (SELECT case WHEN Left(Ltrim(product_code),1) IN (1,2) THEN '120120' ELSE product_code END FROM mm_workorder WHERE number = '" & WO.Trim & "')  and shop_code LIKE 'F%' "
                strSql &= "ELSE "
                strSql &= "if Right(RTrim('" & WO.Trim & "'),1) = 'P' "
                strSql &= "SELECT DISTINCT(shop_code) + ' : ' + description as ShopText, shop_code as ShopValue FROM mm_bill_of_material as B, mm_shop as S WHERE B.shop_code = S.code and product_code = (SELECT case WHEN Left(Ltrim(product_code),1) IN (1,2) THEN '120120' ELSE product_code END FROM mm_workorder WHERE number = '" & WO.Trim & "')  and shop_code LIKE 'M%' "
                da.SelectCommand.CommandText = strSql
                da.Fill(ds)
                FillShopCode = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(" Retrival of WO  error " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function FillWorkOrder() As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                Dim Day As Int16 = Now.Day
                Dim Month As String = Chr(Now.Month + 64)
                Dim Year As String = Right(CStr(Now.Year), 1)
                If Day <= 10 Then
                    Dim date1 As Date = DateAdd(DateInterval.Month, -1, Now.Date)
                    Dim Month1 As String = Chr(date1.Month + 64)
                    Dim Year1 As String = Right(CStr(date1.Year), 1)
                    da.SelectCommand.CommandText = "SELECT number + ' : ' + product_code + ' : ' + cast(description as char(15))+ ' : WQ:' + cast(workorder_quantity as varchar(10)) as WOtext, number as WOvalue FROM mm_workorder WHERE (number LIKE '" & Year.Trim + Month.Trim + "%' or number LIKE '" & Year1.Trim + Month1.Trim + "%') and workorder_quantity <> 0 "
                Else
                    da.SelectCommand.CommandText = "SELECT number + ' : ' + product_code + ' : ' + cast(description as char(15))+ ' : WQ:' + cast(workorder_quantity as varchar(10)) as WOtext, number as WOvalue FROM mm_workorder WHERE number LIKE '" & Year.Trim + Month.Trim + "%' and workorder_quantity <> 0"
                End If
                da.Fill(ds)
                FillWorkOrder = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(" Retrival of WO  error " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function AuthorisedUserIDPassword(ByVal User As String) As String
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.CommandText = "SELECT @password = password FROM wap.dbo.menu_your_password_new WHERE employee_code = @User and application = 'MMS' and group_code = 'PCOPCO' "
            cmd.Parameters.Add("@password", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            cmd.Parameters.Add("@User", SqlDbType.VarChar, 10).Value = User
            Try
                cmd.Connection.Open()
                cmd.ExecuteScalar()
                AuthorisedUserIDPassword = IIf(IsDBNull(cmd.Parameters("@password").Value), "", cmd.Parameters("@password").Value)
            Catch exp As Exception
                AuthorisedUserIDPassword = ""
                Throw New Exception("Authorised UserID password error : " & exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function AuthorisedUserID(ByVal User As String) As String
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.CommandText = "SELECT @UserID = employee_code FROM hr_employee_master a inner join mm_manual_RMR_Authorities b on a.designation_code = b.designation_code WHERE employee_status <= '10' and employee_code = @User "
            cmd.Parameters.Add("@UserID", SqlDbType.VarChar, 10).Direction = ParameterDirection.Output
            cmd.Parameters.Add("@User", SqlDbType.VarChar, 10).Value = User
            Try
                cmd.Connection.Open()
                cmd.ExecuteScalar()
                AuthorisedUserID = IIf(IsDBNull(cmd.Parameters("@UserID").Value), "", cmd.Parameters("@UserID").Value)
            Catch exp As Exception
                AuthorisedUserID = ""
                Throw New Exception("Authorised UserID seek error : " & exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function PHLPositionData(ByVal FrDt As Date, ByVal ToDt As Date) As DataTable
            Dim da As SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            da = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = "mm_sp_NonRWFAxlesReceipt"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.Add("@FrDate", SqlDbType.SmallDateTime, 4).Value = CDate(FrDt)
                da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.SmallDateTime, 4).Value = CDate(ToDt)
                da.Fill(ds)
                PHLPositionData = ds.Tables(0)
            Catch exp As Exception
                PHLPositionData = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function GetPHLPositionData(ByVal PositionFor As Date) As DataSet
            Dim blnCheck As Boolean
            Dim oCmd As SqlClient.SqlCommand
            oCmd = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@PositionFor", SqlDbType.SmallDateTime, 4).Value = CDate(PositionFor)
            oCmd.Parameters.Add("@Cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            oCmd.CommandText = "select *  from mm_PHL_Position where PositionFor  = @PositionFor "
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.ExecuteScalar()
                If IIf(IsDBNull(oCmd.Parameters("@Cnt").Value), 0, oCmd.Parameters("@Cnt").Value) Then
                    blnCheck = True
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
            Dim da As SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            da = rwfGen.Connection.Adapter
            If blnCheck Then
                da.SelectCommand.CommandText = "select *  from mm_PHL_Position where PositionFor  = @PositionFor ; "
            Else
                da.SelectCommand.CommandText = "select *  from wap.dbo.mm_fn_PHL_Position(@PositionFor); "
            End If
            da.SelectCommand.CommandText &= " DECLARE @Date as smalldatetime " &
                " SET @Date = @PositionFor " &
                " DECLARE @StartDate as datetime" &
                " DECLARE @EndDate as datetime " &
                " SET @StartDate = convert(datetime,@Date+' 06:00:00') " &
                " SET @EndDate = DateAdd(m,1,@StartDate)" &
                " SET @EndDate = DateAdd(d,1,convert(datetime,@Date+' 05:59:00'))" &
                " select  c.AxleProductCode , d.Description , d.drawing_number , count(*) cnt " &
                " from mm_nonrwf_axles a inner join mm_nonrwfAxles_PcoEntry b " &
                " on b.RWF_Axle_Number = a.Axle_Number and a.Customer_Axle_Number = b.CustomerAxleNumber " &
                " inner join mm_nonrwfAxles_PcoRef c on b.RitesReference = c.RitesReference" &
                " and a.Customer_Axle_Number = b.CustomerAxleNumber inner join mm_product_master d " &
                " on c.AxleProductCode = d.Product_Code" &
                " where DateTimePcoSaved between @StartDate and @EndDate " &
                " group by c.AxleProductCode , d.Description , d.drawing_number " &
                " order by c.AxleProductCode , d.Description , d.drawing_number "
            da.SelectCommand.Parameters.Add("@PositionFor", SqlDbType.SmallDateTime, 4).Value = CDate(PositionFor)
            Try
                da.Fill(ds)
                GetPHLPositionData = ds
            Catch exp As Exception
                GetPHLPositionData = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function PCOEdit(ByVal PHLDt As Date, ByVal DataHead As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            da = rwfGen.Connection.Adapter
            If DataHead.StartsWith("Exce") Then
                da.SelectCommand.CommandText = "Select a.heat_number, convert(varchar(5000),b.hea_rem) MeltRemarks, convert(varchar(5000),c.remarks) PouringRemarks from  mm_phlgen_heat_exception a inner join mm_post_melt b on a.heat_number = b.heat_number inner join mm_post_pouring c on c.heat_number = a.heat_number where a.phl_date = @Date "
                da.SelectCommand.Parameters.Add("@Date", SqlDbType.SmallDateTime, 4).Value = PHLDt
                Try
                    da.Fill(ds)
                    PCOEdit = ds.Tables(0)
                Catch exp As Exception
                    PCOEdit = Nothing
                    Throw New Exception(exp.Message)
                Finally
                    da.Dispose()
                    ds.Dispose()
                    da = Nothing
                    ds = Nothing
                End Try
            ElseIf DataHead.StartsWith("Break") Then
                da.SelectCommand.CommandText = "mm_sp_PHLGEN_Breakdowns"
                da.SelectCommand.Parameters.Add("@Date", SqlDbType.SmallDateTime, 4).Value = PHLDt
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                Dim tblBreakDowns As New DataTable()
                Try
                    da.Fill(ds, "BreakDowns")
                    tblBreakDowns.Columns.Add(New DataColumn("MemoNumber", System.Type.GetType("System.Int32")))
                    tblBreakDowns.Columns.Add(New DataColumn("FromTime", System.Type.GetType("System.DateTime")))
                    tblBreakDowns.Columns.Add(New DataColumn("Group", System.Type.GetType("System.String")))
                    tblBreakDowns.Columns("Group").MaxLength = 6
                    tblBreakDowns.Columns.Add(New DataColumn("Remarks", System.Type.GetType("System.String")))
                    tblBreakDowns.Columns("Remarks").MaxLength = 5000
                    tblBreakDowns.Columns.Add(New DataColumn("McnCode", System.Type.GetType("System.String")))
                    tblBreakDowns.Columns("McnCode").MaxLength = 8
                    tblBreakDowns.Columns.Add(New DataColumn("ProdAff", System.Type.GetType("System.String")))
                    tblBreakDowns.Columns("ProdAff").MaxLength = 3
                    Dim drSrc, drTgt As DataRow
                    For Each drSrc In ds.Tables("BreakDowns").Rows
                        drTgt = tblBreakDowns.NewRow
                        drTgt("MemoNumber") = tables.GetMemoNumber(drSrc("Maintenance_Group"), drSrc("BreakDown_from_time"), drSrc("Machine_Code"))
                        drTgt("FromTime") = drSrc("BreakDown_from_time")
                        drTgt("Group") = drSrc("Maintenance_Group")
                        drTgt("Remarks") = drSrc("Remarks")
                        drTgt("McnCode") = CStr(drSrc("Machine_Code")).Trim
                        If drSrc("production_affected") = 0 Then
                            drTgt("ProdAff") = "No"
                        Else
                            drTgt("ProdAff") = "Yes"
                        End If
                        tblBreakDowns.Rows.Add(drTgt)
                    Next
                    PCOEdit = tblBreakDowns
                Catch exp As Exception
                    PCOEdit = Nothing
                    Throw New Exception(exp.Message)
                Finally
                    da.Dispose()
                    ds.Dispose()
                    da = Nothing
                    ds = Nothing
                End Try
            End If
        End Function
        Private Shared Function GetMemoNumber(ByVal MaintGroup As String, ByVal FromTime As Date, ByVal MachineCode As String) As Integer
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.CommandText = "Select top 1 @memo_number = memo_number from ms_breakdown_memo where Maintenance_group = @MaintGroup and BreakDown_from_time = @FromTime and Machine_code = @MachineCode order by memo_number desc "
            cmd.Parameters.Add("@MaintGroup", MaintGroup)
            cmd.Parameters.Add("@FromTime", FromTime)
            cmd.Parameters.Add("@MachineCode", MachineCode)
            cmd.Parameters.Add("@memo_number", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            Try
                cmd.Connection.Open()
                cmd.ExecuteScalar()
                Dim sMemo As String = cmd.Parameters("@memo_number").Value & ""
                If IsNothing(sMemo) OrElse IsDBNull(sMemo) Then
                    sMemo = ""
                End If
                GetMemoNumber = sMemo
            Catch exp As Exception
                GetMemoNumber = ""
                Throw New Exception("Memo Number seek error : " & exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function NotDone(ByVal JobString As String, ByVal PHLDate As Date) As Boolean
            Dim sqlcmd As New SqlClient.SqlCommand()
            Dim message As String
            sqlcmd.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
            sqlcmd.CommandType = CommandType.Text
            sqlcmd.Parameters.Add("@Date", SqlDbType.SmallDateTime, 8)
            sqlcmd.Parameters("@Date").Direction = ParameterDirection.Input
            Try
                sqlcmd.Parameters("@Date").Value = CDate(PHLDate)
                message = ""
            Catch exp As Exception
                message = exp.Message
            End Try
            If message <> "" Then
                Return False
            End If
            Select Case JobString
                Case "Highlights"
                    sqlcmd.CommandText = "Select count(*) from mm_PHLGEN_ProdPlan where phl_date = @Date"
                Case "Heats of the Day"
                    sqlcmd.CommandText = "Select count(*) from mm_PHLGEN_pp_heat where phl_date = @Date"
                Case "Production Summary"
                    sqlcmd.CommandText = "Select count(*) from mm_PHLGen_PP_Sum where phl_date = @Date"
                Case "Heat Exceptions"
                    sqlcmd.CommandText = "Select count(*) from mm_PHLGEN_Heat_Exception where phl_date = @Date"
                Case "Despatched Wheelsets"
                    sqlcmd.CommandText = "Select count(*) from mm_PHLGEN_DespatchedWheelSets where phl_date = @Date"
                Case "Despatched Axles"
                    sqlcmd.CommandText = "Select count(*) from mm_PHLGEN_DespatchedAxles where phl_date = @Date"
                Case "Despatched Wheels"
                    sqlcmd.CommandText = "Select count(*) from mm_PHLGEN_DespatchedWheels where phl_date = @Date"
                Case "Shop Floor Balance (Wheels)"
                    sqlcmd.CommandText = "Select count(*) from mm_PHLGEN_WheelShop_FloorBalance where phl_date = @Date"
                Case "Axle Shop Production"
                    sqlcmd.CommandText = "Select count(*) from mm_PHLGEN_AxleShop_numbers_units where phl_date = @Date"
                Case "Loose Axles Available"
                    sqlcmd.CommandText = "Select count(*) from mm_PHLGEN_ams_loose_axles_available where phl_date = @Date"
                Case "WheelSets"
                    sqlcmd.CommandText = "Select count(*) from mm_PHLGEN_WheelSets where phl_date = @Date"
                Case "Wheelset Inventory"
                    sqlcmd.CommandText = "Select count(*) from mm_PHLGEN_WheelsetInventory where phl_date = @Date"
                Case Else
                    sqlcmd.CommandText = ""
            End Select
            If sqlcmd.CommandText = "" Then
                sqlcmd.Dispose()
                sqlcmd = Nothing
                Return False
            End If
            Dim i As Integer
            Try
                sqlcmd.Connection.Open()
                i = sqlcmd.ExecuteScalar
            Catch exp As Exception
                i = -1
                Throw New Exception(exp.Message)
            Finally
                If sqlcmd.Connection.State = ConnectionState.Open Then sqlcmd.Connection.Close()
                sqlcmd.Dispose()
                sqlcmd = Nothing
            End Try
            Return i <= 0
        End Function
        Public Shared Function PHLCheckDate(ByVal PHLDate As Date) As Boolean
            Dim dt As Date
            Dim sqlstr, sqlstr1 As String
#Disable Warning BC42104 ' Variable is used before it has been assigned a value
            Dim strCmd As New SqlClient.SqlCommand(sqlstr, New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con")))
#Enable Warning BC42104 ' Variable is used before it has been assigned a value
            Try
                dt = CDate(PHLDate)
                If dt >= Today.Date Then
                    Throw New Exception("Date Not acceptable : " & PHLDate & "")
                End If
                Try
                    sqlstr = "select count(*) from mm_phl_generation where phl_date = @Phldate"
                    strCmd.Parameters.Add("@phlDate", SqlDbType.SmallDateTime, 8)
                    strCmd.Parameters("@PhlDate").Direction = ParameterDirection.Input
                    strCmd.Parameters("@PhlDate").Value = dt
                    strCmd.Connection.Open()
                    strCmd.CommandText = sqlstr
                    If strCmd.ExecuteScalar = 0 Then
                        Throw New Exception("You have not generated Production Highlights for : " & PHLDate & " ")
                        If strCmd.Connection.State = ConnectionState.Open Then strCmd.Connection.Close()
                        Exit Function
                    End If
                    sqlstr1 = "select count(*) from mm_PHLGEN_ProdPlan where phl_date > @phldate"
                    strCmd.CommandText = sqlstr1
                    If strCmd.ExecuteScalar > 0 Then
                        Throw New Exception("Production Highlights already generated for date later than Given Date : " & PHLDate & " ")
                        If strCmd.Connection.State = ConnectionState.Open Then strCmd.Connection.Close()
                        Exit Function
                    End If
                    sqlstr1 = "select count(*) from mm_PHLGEN_RB_ProdPlan where phl_date = @phldate"
                    strCmd.CommandText = sqlstr1
                    If strCmd.ExecuteScalar > 0 Then
                        strCmd.CommandText = "select top 1 pink_date from mm_pink_sheet where pink_date >= @dt order by pink_date "
                        strCmd.Parameters.Add("@dt", SqlDbType.SmallDateTime, 4)
                        strCmd.Parameters("@dt").Direction = ParameterDirection.Input
                        strCmd.Parameters("@dt").Value = dt
                        Dim pinkdt As Date = strCmd.ExecuteScalar
                        If pinkdt = dt Then
                            PHLCheckDate = True
                        Else
                            ' If dt is holiday for CLCL donot flash this message
                            strCmd.CommandText = "Select count(*) from mm_calendar_dump where date = '" & Format(dt, "MM/dd/yyyy") & "' and shop = 'CLCL'"
                            Dim isHoliday As Boolean
                            isHoliday = strCmd.ExecuteScalar > 0
                            If isHoliday = False Then
                                Throw New Exception("Date Not Acceptable (earlier than latest pink sheet date) : " & PHLDate & " ")
                            End If
                        End If
                    Else
                        PHLCheckDate = False
                    End If
                Catch exp As Exception
                    Throw New Exception(exp.Message & ":" & PHLDate & "")
                End Try
            Catch exp As Exception
                Throw New Exception("exp.Message  : " & PHLDate & "")
            Finally
                If strCmd.Connection.State = ConnectionState.Open Then strCmd.Connection.Close()
                strCmd.Dispose()
                strCmd = Nothing
            End Try
        End Function
        Public Shared Function lastphldt() As Date
            Dim sqlcmd As New SqlClient.SqlCommand()
            sqlcmd.Connection = rwfGen.Connection.ConObj
            sqlcmd.CommandText = "select top 1 phl_date from mm_phl_generation order by phl_date desc"
            Try
                sqlcmd.Connection.Open()
                lastphldt = sqlcmd.ExecuteScalar
                If IsDBNull(lastphldt) OrElse IsNothing(lastphldt) Then
                    lastphldt = #1/1/1900#
                End If
            Catch exp As Exception
                lastphldt = #1/1/1900#
            Finally
                If sqlcmd.Connection.State = ConnectionState.Open Then sqlcmd.Connection.Close()
                sqlcmd.Dispose()
                sqlcmd = Nothing
            End Try
            Return lastphldt
        End Function
        Public Shared Function CheckDate(ByVal PHLDt As Date, ByVal WithPink As Boolean) As Integer
            Dim dt As Date, intDtCount As Integer
            Dim cmd As New SqlClient.SqlCommand()
            cmd = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@dt", SqlDbType.SmallDateTime, 4)
            cmd.Parameters.Add("@cnt", SqlDbType.Int, 4)
            cmd.Parameters("@cnt").Direction = ParameterDirection.Output
            Try
                dt = CDate(PHLDt)
                cmd.Parameters("@dt").Value = dt
                cmd.CommandText = "select @cnt = count(*) from mm_mmyrprdn_dump where ltrim(rtrim(item)) = 'DYACTWH' and upto > @dt"
                cmd.Connection.Open()
                cmd.ExecuteScalar()
                intDtCount = IIf(IsDBNull(cmd.Parameters("@cnt").Value), 1, cmd.Parameters("@cnt").Value)
                If intDtCount > 0 Then
                    Throw New Exception("You cannot generate for this date " & PHLDt)
                End If
                If Not WithPink Then
                    cmd.CommandText = "select @cnt = count(*) from mm_pink_sheet where pink_date = @dt"
                    cmd.ExecuteScalar()
                    intDtCount = IIf(IsDBNull(cmd.Parameters("@cnt").Value), 0, cmd.Parameters("@cnt").Value)
                    If intDtCount <= 0 Then
                        Dim strsql As String
                        cmd.CommandText = "Select @cnt = count(*) from mm_calendar_dump where date = @dt and shop = 'CLCL' "
                        cmd.ExecuteScalar()
                        intDtCount = IIf(IsDBNull(cmd.Parameters("@cnt").Value), 0, cmd.Parameters("@cnt").Value)
                        If intDtCount = 0 Then
                            Throw New Exception("PINK SHEET is not generated for this date " & PHLDt & ", Please Wait")
                        End If
                    End If
                Else
                    Dim strsql As String
                    cmd.CommandText = "Select @cnt = count(*) from mm_calendar_dump where date = @dt and shop = 'ama' "
                    cmd.ExecuteScalar()
                    intDtCount = IIf(IsDBNull(cmd.Parameters("@cnt").Value), 0, cmd.Parameters("@cnt").Value)
                    If intDtCount > 0 Then
                        Throw New Exception("This date " & PHLDt & " is declarted as holiday !")
                    End If
                End If
                '`````````````````````````````````````````````````````````````````````````````
                cmd.CommandText = "Select @cnt = count(*) from mm_phl_generation where phl_date = @dt"
                cmd.ExecuteScalar()
                intDtCount = IIf(IsDBNull(cmd.Parameters("@cnt").Value), 0, cmd.Parameters("@cnt").Value)
            Catch exp As Exception
                Throw New Exception(" Message : " + exp.Message)
            Finally
                If IsNothing(cmd) = False Then
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                End If
            End Try
            Return intDtCount
        End Function
        Public Shared Function YrDataExists(ByRef cmd As SqlClient.SqlCommand, ByVal Dt As Date) As Boolean
            'cmd.CommandText = "select count(*) from mm_mmyrprdn_dump where year(upto)=  Year(@dt) and month(upto)=month(@dt) and ltrim(rtrim(item)) in ('YRACTWH','YRACTAX','YRACTWS', 'HEATSYY')"
            ' modified on 9-5-2008 after yvp pointed out years figs of 2007-08 not saved 
            cmd.CommandText = "select count(*) from mm_mmyrprdn_dump where (( upto between wap.dbo.mm_fn_si_GetFinYearDate(@dt, 1) and  wap.dbo.mm_fn_si_GetFinYearDate(@dt, 0)) and ( item like 'yr%' or item like '%yy' ))"
            'cmd.Parameters.Add("@dt", SqlDbType.SmallDateTime, 4)
            cmd.Parameters("@dt").Direction = ParameterDirection.Input
            cmd.Parameters("@dt").Value = Dt
            Dim blnExists As Boolean
            Try
                If cmd.ExecuteScalar > 0 Then
                    blnExists = True
                Else
                    blnExists = False
                End If
            Catch exp As Exception
                blnExists = False
                Throw New Exception("Fin Year Start Error : " & exp.Message)
            Finally
                ' donot close connection or transaction here
            End Try
            Return blnExists
        End Function
        Public Shared Function showMmyrprdn(ByVal dt As Date, ByVal WithOutPink As Boolean) As DataSet
            Dim da As SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            da = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.Parameters.Add("@PHLDt", SqlDbType.SmallDateTime, 4).Value = dt
                'da.SelectCommand.CommandText = "select convert(varchar(11),a.upto,103) PhlFor, convert(varchar(11), b.phl_genDate, 103)+ ' ' +convert(varchar(11), b.phl_genDate, 108) GenTime, item, cumfig  from mm_mmyrprdn_dump a inner join mm_phl_generation b on a.upto = b.phl_date where upto = @dt "
                If WithOutPink Then
                    da.SelectCommand.CommandText = "mm_sp_WorkorderQtyWithOutPink"
                Else
                    da.SelectCommand.CommandText = "mm_sp_WorkorderQty"
                End If
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.Fill(ds)
                showMmyrprdn = ds.Copy
            Catch exp As Exception
                Throw New Exception(" Retrival of Axle DayMonth error " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function DataExists(ByVal Dt As Date) As Integer
            Dim cmd As New SqlClient.SqlCommand()
            cmd = rwfGen.Connection.CmdObj
            cmd.CommandText = "select count(*) from mm_mmyrprdn_dump where year(upto) = " & Year(Dt) &
                " and month(upto) = " & Month(Dt) & " and ltrim(rtrim(item)) in " &
                "('DYACTWH', 'DYACTAX', 'DYACTWS','MNACTWH', 'MNACTAX', 'MNACTWS', 'YRACTWH', 'YRACTAX', 'YRACTWS')"
            Try
                cmd.Connection.Open()
                If cmd.ExecuteScalar > 0 Then
                    DataExists = 1
                Else
                    DataExists = 0
                    ' Throw New Exception("Failed")
                End If
            Catch exp As Exception
                DataExists = 0
                Throw New Exception("Updt Determination Error : " & exp.Message)
            Finally
                If IsNothing(cmd) = False Then
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                End If
            End Try
        End Function
        Public Shared Function GetHeatsForTheYear(ByVal dt As Date) As Long
            Dim cmd As New SqlClient.SqlCommand()
            cmd = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@Dt", SqlDbType.SmallDateTime, 4)
            cmd.Parameters("@dt").Direction = ParameterDirection.Input
            cmd.CommandText = "select @HeatsYY = count(*) from mm_heatsheet_header where melt_date between wap.dbo.mm_fn_si_GetFinYearDate(@dt,1) and @dt "
            cmd.Parameters.Add("@HeatsYY", SqlDbType.BigInt, 8)
            cmd.Parameters("@HeatsYY").Direction = ParameterDirection.Output
            Try
                cmd.Parameters("@dt").Value = dt
                cmd.Connection.Open()
                cmd.ExecuteScalar()
                GetHeatsForTheYear = IIf(IsDBNull(cmd.Parameters("@HeatsYY").Value), 0, cmd.Parameters("@HeatsYY").Value)
            Catch exp As Exception
                GetHeatsForTheYear = 0
                Throw New Exception("Year Heats count error : " & exp.Message)
            Finally
                If IsNothing(cmd) = False Then
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                End If
            End Try
        End Function
        Public Shared Function GetHeatsForTheMonth(ByVal dt As Date) As Long
            Dim cmd As New SqlClient.SqlCommand()
            cmd = rwfGen.Connection.CmdObj
            cmd.CommandText = "select @HeatsMM = count(*) from mm_heatsheet_header where year(melt_date) = year(@dt) and month(melt_date) = month(@dt) and melt_date <= @dt "
            cmd.Parameters.Add("@Dt", SqlDbType.SmallDateTime, 4)
            cmd.Parameters("@dt").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@HeatsMM", SqlDbType.BigInt, 8)
            cmd.Parameters("@HeatsMM").Direction = ParameterDirection.Output
            Try
                cmd.Parameters("@dt").Value = dt
                cmd.Connection.Open()
                cmd.ExecuteScalar()
                GetHeatsForTheMonth = IIf(IsDBNull(cmd.Parameters("@HeatsMM").Value), 0, cmd.Parameters("@HeatsMM").Value)
            Catch exp As Exception
                GetHeatsForTheMonth = 0
                Throw New Exception("Month Heats count error : " & exp.Message)
            Finally
                If IsNothing(cmd) = False Then
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                End If
            End Try
        End Function
        Public Shared Function GetWsetDayMonth(ByVal dt As Date) As DataTable
            Dim da As SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            da = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.Parameters.Add("@dt", SqlDbType.SmallDateTime, 4).Value = dt
                da.SelectCommand.CommandText = "select DlySets = sum(case when ass_date = @dt then passed else 0 end), " &
                    " MnthSets =  sum(case when Year(ass_date) = Year(@dt) and Month(ass_date) = Month(@dt) and ass_date <= @dt then passed else 0 end ) " &
                    " from mm_mmassdly_dump a inner join mm_workorder b on prod_id = product_code and ass_date between start_date and end_date " &
                    " where Year(ass_date) = Year(@dt) and Month(ass_date) = Month(@dt) and ass_date <= @dt"
                da.Fill(ds)
                GetWsetDayMonth = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(" Retrival of Axle DayMonth error " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function GetDespatchCount(ByVal dt As Date) As DataTable
            Dim da As SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            da = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.Parameters.Add("@dt", SqlDbType.SmallDateTime, 4).Value = dt
                da.SelectCommand.CommandText = "select convert(varchar(10),dc_date,103) DCdate , " &
                    " c.description ProductDescription , a.dc_number DCNumber , count(*) DespCnt" &
                    " from dm_fg_despatch_rr a inner join dm_fg_despatch_products b" &
                    " on a.dc_number = b.dc_number inner join mm_product_master c" &
                    " on b.product_code = c.product_code inner join ( select distinct date from mm_calendar_dump ) d" &
                    " on d.date  = a.dc_date" &
                    " where month(dc_date) = month(@dt) and year(dc_date) = year(@dt) " &
                    " group by dc_date , c.description  , a.dc_number" &
                    " order by dc_date desc, c.description  , a.dc_number"
                da.Fill(ds)
                GetDespatchCount = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(" Retrival of Axle DayMonth error " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function GetAxleDayMonth(ByVal dt As Date, ByVal txtDate As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            da = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.Parameters.Add("@StartDate", SqlDbType.SmallDateTime, 4).Value = CDate("01/" + txtDate.Substring(2))
                da.SelectCommand.Parameters.Add("@Date", SqlDbType.SmallDateTime, 4).Value = dt
                da.SelectCommand.CommandText = "select AxleActualMonth =  wap.dbo.mm_fn_ActualAxlesProducedNew(@StartDate,@Date) , " &
                        " AxleActualDay =  wap.dbo.mm_si_fn_ActualAxlesProduced(@Date,@Date)"
                da.Fill(ds)
                GetAxleDayMonth = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(" Retrival of Axle DayMonth error " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function GetWheelDayMonth(ByVal dt As Date) As DataTable
            Dim da As SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            da = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.Parameters.Add("@dt", SqlDbType.SmallDateTime, 4).Value = dt
                da.SelectCommand.CommandText = "Select count(*) from mm_calendar_dump where date = @dt and shop = 'CLCL'"
                If da.SelectCommand.Connection.State = ConnectionState.Closed Then da.SelectCommand.Connection.Open()
                If da.SelectCommand.ExecuteScalar > 0 Then
                    da.SelectCommand.CommandText = "select GoodWheels, CummGoodWH from mm_pink_sheet_misc where " &
                                              "ltrim(rtrim(Type)) = 'Total' and test_date = @dt "
                Else
                    da.SelectCommand.CommandText = "select 0 GoodWheels, CummGoodWH from mm_pink_sheet_misc where " &
                                         "ltrim(rtrim(Type)) = 'Total' and test_date =  " &
                                      " (select max(test_date) from mm_pink_sheet_misc " &
                                      " where ltrim(rtrim(Type)) = 'Total' and month(test_date) = month(@dt) and year(test_date) = year(@dt))"
                End If
                da.Fill(ds)
                GetWheelDayMonth = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(" Retrival of WheelDayMonth error " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function getShopWiseHolidaysTillPhlDt(ByVal dt As Date) As DataTable
            Dim da As SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            da = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.Parameters.Add("@dt", SqlDbType.SmallDateTime, 4).Value = dt
                da.SelectCommand.CommandText = "SELECT  sum(case when shop = 'ama' and givendate <= @dt then 1 else 0 end) AMATillDt , " &
                    " sum(case when shop = 'meme' and givendate <= @dt then 1 else 0 end) MEMETillDt , " &
                    " sum(case when shop = 'ama'  then 1 else 0 end) AmaMnHolidays , " &
                    " sum(case when shop = 'meme' then 1 else 0 end) MemeMnHolidays" &
                    " from mm_vw_ProductionPlanHolidays" &
                    " where Year(givendate) = Year(@dt)  And Month(givendate) =  Month(@dt) and shop in ('ama','meme') "
                da.Fill(ds)
                getShopWiseHolidaysTillPhlDt = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(" Retrival of ShopWiseHolidays error " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function GetNextDayHoliday(ByVal dt As Date) As String
            Dim cmd As New SqlClient.SqlCommand()
            cmd = rwfGen.Connection.CmdObj
            cmd.CommandText = "select count(*) from mm_calendar_dump where left(Shop,4)='MEME' and date= @NextDt"
            cmd.Parameters.Add("@NextDt", SqlDbType.SmallDateTime, 4)
            cmd.Parameters("@NextDt").Direction = ParameterDirection.Input
            Try
                cmd.Parameters("@NextDt").Value = dt.AddDays(1)
                cmd.Connection.Open()
                GetNextDayHoliday = IIf(cmd.ExecuteScalar > 0, "Y", "N")
            Catch exp As Exception
                GetNextDayHoliday = ""
                Throw New Exception("Holiday Check Error : " & exp.Message)
            Finally
                If IsNothing(cmd) = False Then
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                End If
            End Try
        End Function
        Public Shared Function GetProductDetails(ByVal product_code As String, ByVal ProductType As String) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            da = rwfGen.Connection.Adapter
            da.SelectCommand.Parameters.Add("@product_code", SqlDbType.VarChar, 6).Value = product_code
            If ProductType = "Wheel" Then
                da.SelectCommand.CommandText = "select ProductNature , Product , a.product_code , rtrim(a.drawing_number) drawing_number ,  " &
                    " rtrim(a.description) descri ,  rtrim(long_description) long_description ," &
                    " max_quantity , product_weightage , scrap_percentage , loss_percentage , wheels_per_heat , " &
                    " rtrim(specification) specification , rtrim(class) class , transfer_price , sale_price , rough_weight , " &
                    " finished_weight ,  low_bhn  , high_bhn , WTAName , customer_drawing_number , " &
                    " wt_per_wheel , rej_percent , series_start , series_end , whl_per_MT , MR_Rej_Percent ," &
                    " MinTreadDia , MaxTreadDia , MinBoreDia , MaxBoreDia , MinPlateThickness , MaxPlateThickness ," &
                    " OverSizeMin , OverSizeMax, SplSizeMin, SplSizeMax, McnMinDia , axle_size " &
                    " from mm_product_master a left outer join mm_product_details b" &
                    " on a.product_code = b.product_code left outer join mm_vw_PCOProdType x " &
                    " on left(a.product_code,1) = ProdType left outer join mm_ProductwiseTreadAndBoreSizes c" &
                    " on a.product_code = c.ProductCode where a.product_code = @product_code "
            ElseIf ProductType = "Axle" Then
                da.SelectCommand.CommandText = " select ProductNature , Product , a.product_code , rtrim(a.drawing_number) drawing_number ,  rtrim(a.description) descri , " &
                    " rtrim(long_description) long_description ," &
                    " max_quantity , product_weightage , scrap_percentage , loss_percentage ," &
                    " rtrim(specification) specification , rtrim(class) class , transfer_price , " &
                    " sale_price , rough_weight , finished_weight ,  WTAName , customer_drawing_number , " &
                    " product_weightage_at_forge_shop , rtrim(cast_group) cast_group , " &
                    " R43R16 , Make , Source , StageCode , SourceCode , ProductCode , " &
                    " NextStageCode , NextStageProductCode , axle_size " &
                    " from mm_product_master a left outer join mm_product_details b" &
                    " on a.product_code = b.product_code left outer join mm_vw_PCOProdType x " &
                    " on left(a.product_code,1) = ProdType " &
                    " left outer join mm_vw_AxleProductsSpecSourceStage y on a.product_code = y.product_code " &
                    " where a.product_code = @product_code "
            ElseIf ProductType = "Wheel Set" Then
                da.SelectCommand.CommandText = " select ProductNature , Product , a.product_code , rtrim(a.drawing_number) drawing_number ,  rtrim(a.description) descri , " &
                    " rtrim(long_description) long_description ," &
                    " max_quantity , product_weightage , scrap_percentage , loss_percentage ," &
                    " rtrim(specification) specification , rtrim(class) class , transfer_price , " &
                    " sale_price , rough_weight , finished_weight ,  WTAName , customer_drawing_number , " &
                    " product_weightage_at_forge_shop , cast_group , type ," &
                    " min_pressure , max_pressure, Min_Guage, max_Guage , prod_id1 , prod_id2 , axle_size " &
                    " from mm_product_master a left outer join mm_product_details b" &
                    " on a.product_code = b.product_code left outer join mm_vw_PCOProdType x " &
                    " on left(a.product_code,1) = ProdType left outer join mm_wheelset_mountPressures c" &
                    " on a.product_code = c.Product_Code left outer join mm_wheelset_Trackguages d" &
                    " on a.product_code = d.Product_Code where a.product_code = @product_code  "
            ElseIf ProductType = "Others" Then
                da.SelectCommand.CommandText = " select ProductNature , Product , a.product_code , rtrim(a.drawing_number) drawing_number ,  rtrim(a.description) descri , " &
                    " rtrim(long_description) long_description ," &
                    " max_quantity , product_weightage , scrap_percentage , loss_percentage ," &
                    " rtrim(specification) specification , rtrim(class) class , transfer_price , " &
                    " sale_price , rough_weight , finished_weight ,  WTAName , customer_drawing_number , " &
                    " product_weightage_at_forge_shop , cast_group , type " &
                    " from mm_product_master a left outer join mm_product_details b " &
                    " on a.product_code = b.product_code left outer join mm_vw_PCOProdType x " &
                    " on left(a.product_code,1) = ProdType where a.product_code = @product_code  "
            End If
            Try
                da.Fill(ds)
                GetProductDetails = ds.Tables(0)
            Catch exp As Exception
                GetProductDetails = Nothing
                Throw New Exception("Error in retrival of AxleMake List " & exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function getConsigneeDetails() As DataTable
            Dim da As SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            da = rwfGen.Connection.Adapter
            Try
                'da.SelectCommand.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
                da.SelectCommand.CommandText = "SELECT code , name , address , city , pincode , passing_authority , customer_code , " &
                    " ShortName , consignee_gst FROM mm_customer_consignee where code like 'RWP%' "
                da.Fill(ds, "ConsigneeDetailsSavedData")
                getConsigneeDetails = ds.Tables("ConsigneeDetailsSavedData")
            Catch exp As Exception
                Throw New Exception(" Retrival of Calibration Details List " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function GetBomListWFPS() As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            Dim WTAProductList As New DataTable()
            da = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "select a.Pl_Number, b.short_description , convert(numeric(8,4),a.quantity) Qty , c.UnitName, a.accumulator " &
                                       " from mm_bill_of_material a inner join wap.dbo.pm_itemmaster b on b.pl_number = a.pl_number inner join  " &
                                       " wap.dbo.pm_unitmaster c on c.uom = b.uom where a.shop_code = 'N1' and isnull(a.status,'') <> 'D'"
            Try
                da.Fill(ds)
                GetBomListWFPS = ds.Tables(0)
            Catch exp As Exception
                GetBomListWFPS = Nothing
                Throw New Exception("Error in retrival")
            Finally
                ds.Dispose()
                da.Dispose()
                da = Nothing
                ds = Nothing
            End Try
            Return GetBomListWFPS
        End Function
        Public Shared Function GetBomListMoulding() As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            Dim WTAProductList As New DataTable()
            da = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "select a.Pl_Number, b.short_description , convert(numeric(5,4),a.quantity) Qty , c.UnitName, a.accumulator " &
                                       " from mm_bill_of_material a inner join wap.dbo.pm_itemmaster b on b.pl_number = a.pl_number inner join  " &
                                       " wap.dbo.pm_unitmaster c on c.uom = b.uom where a.shop_code = 'E2' and isnull(a.status,'') <> 'D'"
            Try
                da.Fill(ds)
                GetBomListMoulding = ds.Tables(0)
            Catch exp As Exception
                GetBomListMoulding = Nothing
                Throw New Exception("Error in retrival")
            Finally
                ds.Dispose()
                da.Dispose()
                da = Nothing
                ds = Nothing
            End Try
            Return GetBomListMoulding
        End Function
        Public Shared Function GetPLDesc(ByVal PLNo As String) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            Dim WTAProductList As New DataTable()
            da = rwfGen.Connection.Adapter
            da.SelectCommand.Parameters.Add("@Pl_Number", SqlDbType.VarChar, 50).Value = PLNo.Trim
            da.SelectCommand.CommandText = "Select  a.Short_Description, b.UnitName from pm_itemMaster a  inner join pm_UnitMaster b on a.uom = b.uom where a.pl_number = @Pl_Number"
            Try
                da.Fill(ds)
                GetPLDesc = ds.Tables(0)
            Catch exp As Exception
                GetPLDesc = Nothing
                Throw New Exception("Error in retrival")
            Finally
                ds.Dispose()
                da.Dispose()
                da = Nothing
                ds = Nothing
            End Try
            Return GetPLDesc
        End Function
        Public Shared Function GetBOMList(ByVal ShopName As String) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            da = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "select PLNumber , " &
                " ShortDescription , Quantity , UnitName , MaxRMRQty " &
                " from mm_vw_WheelShopBOMList where Shop = @Shop " &
                " order by PLNumber "
            Try
                da.SelectCommand.Parameters.Add("@Shop", SqlDbType.VarChar, 2).Value = ShopName.Trim
                da.Fill(ds)
                GetBOMList = ds.Tables(0)
            Catch exp As Exception
                GetBOMList = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function GetBOMPLDetails(ByVal PLNumber As String) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            da = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "select PLNumber , " &
                " ShortDescription , Quantity , UnitName , MaxRMRQty " &
                " from mm_vw_WheelShopBOMList where PLNumber = @PLNumber "
            Try
                da.SelectCommand.Parameters.Add("@PLNumber", SqlDbType.VarChar, 8).Value = PLNumber.Trim
                da.Fill(ds)
                GetBOMPLDetails = ds.Tables(0)
            Catch exp As Exception
                GetBOMPLDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function GetBomListMelting() As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            Dim WTAProductList As New DataTable()
            da = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "select a.Pl_Number, rtrim(b.short_description) short_description  , a.Quantity Qty , " &
                            " rtrim(c.UnitName) UnitName , a.accumulator , a.maximum_rmr_quantity MaxRMRQty " &
                            " from mm_bill_of_material a inner join wap.dbo.pm_itemmaster b on b.pl_number = a.pl_number inner join  " &
                            " wap.dbo.pm_unitmaster c on c.uom = b.uom where a.shop_code = 'e1' and isnull(a.status,'') <> 'D' " &
                            " order by a.Pl_Number"
            Try
                da.Fill(ds)
                GetBomListMelting = ds.Tables(0)
            Catch exp As Exception
                GetBomListMelting = Nothing
                Throw New Exception("Error in retrival")
            Finally
                ds.Dispose()
                da.Dispose()
                da = Nothing
                ds = Nothing
            End Try
            Return GetBomListMelting
        End Function
        Public Shared Function RBGetDayTargets(ByVal FromValue As String, ByVal ToValue As String, ByVal Product As String, ByVal finYear As String) As DataTable
            Dim sqlstr As New System.Text.StringBuilder()
            Dim i As Integer

            For i = CInt(FromValue) To CInt(ToValue)
                If i = 10 Then
                    sqlstr.Append(", DayTgtInJan")
                End If
                If i = 11 Then
                    sqlstr.Append(", DayTgtInFeb")
                End If
                If i = 12 Then
                    sqlstr.Append(", DayTgtInMar")
                End If
                If i = 1 Then
                    sqlstr.Append(", DayTgtInApr")
                End If
                If i = 2 Then
                    sqlstr.Append(", DayTgtInMay")
                End If
                If i = 3 Then
                    sqlstr.Append(", DayTgtInJun")
                End If
                If i = 4 Then
                    sqlstr.Append(", DayTgtInJul")
                End If
                If i = 5 Then
                    sqlstr.Append(", DayTgtInAug")
                End If
                If i = 6 Then
                    sqlstr.Append(", DayTgtInSep")
                End If
                If i = 7 Then
                    sqlstr.Append(", DayTgtInOct")
                End If
                If i = 8 Then
                    sqlstr.Append(", DayTgtInNov")
                End If
                If i = 9 Then
                    sqlstr.Append(", DayTgtInDec")
                End If
            Next
            sqlstr.Append(" from mm_AnnualAndDay_RB_Targets_for_PHL where finyear = '" & finYear & "'")
            If Product.ToLower = "01c" Or Product.ToLower = "01g" Then
                sqlstr.Append(" and WhlOrAxlOrSet = 'W'")
                If Product.EndsWith("C") = True Then
                    sqlstr.Append(" and nature = 'cast'")
                Else
                    sqlstr.Append(" and nature <> 'cast'")
                End If
            ElseIf Product.ToLower = "02" Then
                sqlstr.Append(" and WhlOrAxlOrSet = 'A'")
            Else
                sqlstr.Append(" and WhlOrAxlOrSet = 'S'")
            End If
            Dim sqlstring As String = "Select "
            Dim len As Integer = sqlstr.ToString.Length
            sqlstring &= sqlstr.ToString.Substring(2, len - 2)
            Dim da As System.Data.SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            da = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = sqlstring.ToString
            Try
                da.Fill(ds)
                RBGetDayTargets = ds.Tables(0)
            Catch exp As Exception
                RBGetDayTargets = Nothing
                Throw New Exception("Error in retrival of Month Targets")
            Finally
                ds.Dispose()
                da.Dispose()
                da = Nothing
                ds = Nothing
            End Try
            Return RBGetDayTargets
        End Function
        Public Shared Function RBGetMonthTargets(ByVal Product As String, ByVal finYear As String, ByVal ToValueName As String)
            Dim sqlstr As New System.Text.StringBuilder()
            sqlstr.Append("select month_number, working_days, wap_monthly_quantity " &
                " from mm_schedule_rwf_RB_plan where category = '" & Left(Product, 2) & "' " &
                " and wta_control_number like '" & Left(finYear, 4) & "%'")
            If Product.StartsWith("01") = True Then
                If Product.EndsWith("C") = True Then
                    sqlstr.Append(" and  remarks like 'cast%' ")
                Else
                    sqlstr.Append(" and  remarks not like 'cast%' ")
                End If
            End If
            sqlstr.Append(" " & ToValueName & " ")
            sqlstr.Append(" order by Quarter_number, Month_number ")
            Dim da As System.Data.SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            da = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = sqlstr.ToString
            Try
                da.Fill(ds)
                RBGetMonthTargets = ds.Tables(0)
            Catch exp As Exception
                RBGetMonthTargets = Nothing
                Throw New Exception("Error in retrival of Month Targets")
            Finally
                ds.Dispose()
                da.Dispose()
                da = Nothing
                ds = Nothing
            End Try
            Return RBGetMonthTargets
        End Function
        Public Shared Function RBGetYearTargets(ByVal Product As String, ByVal finYear As String)
            Dim sqlstr As New System.Text.StringBuilder()
            sqlstr.Append(" plannedWorkingDays, AnnualTarget from mm_AnnualAndDay_RB_Targets_for_PHL where finyear = '" & finYear & "'")
            If Product.ToLower = "01c" Or Product.ToLower = "01g" Then
                sqlstr.Append(" and WhlOrAxlOrSet = 'W'")
                If Product.EndsWith("C") = True Then
                    sqlstr.Append(" and nature = 'cast'")
                Else
                    sqlstr.Append(" and nature <> 'cast'")
                End If
            ElseIf Product.ToLower = "02" Then
                sqlstr.Append(" and WhlOrAxlOrSet = 'A'")
            Else
                sqlstr.Append(" and WhlOrAxlOrSet = 'S'")
            End If
            Dim sqlstring As String = "Select "
            sqlstring &= sqlstr.ToString
            Dim da As System.Data.SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            da = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = sqlstring
            Try
                da.Fill(ds)
                RBGetYearTargets = ds.Tables(0)
            Catch exp As Exception
                RBGetYearTargets = Nothing
                Throw New Exception("Error in retrival of Year Targets")
            Finally
                ds.Dispose()
                da.Dispose()
                da = Nothing
                ds = Nothing
            End Try
            Return RBGetYearTargets
        End Function
        Public Shared Function RBCntMonthTargets(ByVal finYear As String) As Integer
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@Cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            cmd.Parameters.Add("@finyear", SqlDbType.VarChar, 6).Value = finYear
            cmd.CommandText = "select @Cnt = count(*) from mm_schedule_rwf_RB_plan where left(wta_control_number,4) = left(@finyear,4)"
            cmd.Connection.Open()
            Try
                cmd.ExecuteScalar()
                RBCntMonthTargets = IIf(IsDBNull(cmd.Parameters("@Cnt").Value), 0, cmd.Parameters("@Cnt").Value)
            Catch exp As Exception
                RBCntMonthTargets = 0
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function RBCntRecords(ByVal finYear As String) As Integer
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@Cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            cmd.CommandText = "select @Cnt = count(*) from mm_AnnualAndDay_RB_Targets_for_PHL where finyear = '" & finYear & "'"
            cmd.Connection.Open()
            Try
                cmd.ExecuteScalar()
                RBCntRecords = IIf(IsDBNull(cmd.Parameters("@Cnt").Value), 0, cmd.Parameters("@Cnt").Value)
            Catch exp As Exception
                RBCntRecords = 0
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function CntMonthTargetsNew(ByVal finYear As String) As Integer
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@Cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            cmd.Parameters.Add("@finyear", SqlDbType.VarChar, 6).Value = finYear
            cmd.CommandText = "select @Cnt = count(*) from mm_schedule_rwf_plan where left(wta_control_number,4) = left(@finyear,4) "
            cmd.Connection.Open()
            Try
                cmd.ExecuteScalar()
                CntMonthTargetsNew = IIf(IsDBNull(cmd.Parameters("@Cnt").Value), 0, cmd.Parameters("@Cnt").Value)
            Catch exp As Exception
                CntMonthTargetsNew = 0
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function CntMonthTargets(ByVal finYear As String, ByVal category As String) As Integer
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@Cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            cmd.Parameters.Add("@finyear", SqlDbType.VarChar, 6).Value = finYear
            cmd.CommandText = "select @Cnt = count(*) from mm_schedule_rwf_plan where left(wta_control_number,4) = left(@finyear,4) and category = '" & category.Trim & "'"
            cmd.Connection.Open()
            Try
                cmd.ExecuteScalar()
                CntMonthTargets = IIf(IsDBNull(cmd.Parameters("@Cnt").Value), 0, cmd.Parameters("@Cnt").Value)
            Catch exp As Exception
                CntMonthTargets = 0
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function CntRecords(ByVal finYear As String) As Integer
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@Cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            cmd.CommandText = "select @Cnt = count(*) from mm_AnnualAndDay_Targets_for_PHL where finyear = '" & finYear & "'"
            cmd.Connection.Open()
            Try
                cmd.ExecuteScalar()
                CntRecords = IIf(IsDBNull(cmd.Parameters("@Cnt").Value), 0, cmd.Parameters("@Cnt").Value)
            Catch exp As Exception
                CntRecords = 0
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function GetDayTargets(ByVal FromValue As String, ByVal ToValue As String, ByVal finYear As String, ByVal Product As String) As DataTable
            Dim sqlstr As New System.Text.StringBuilder()
            Dim i As Integer
            For i = CInt(FromValue) To CInt(ToValue)
                If i = 10 Then
                    sqlstr.Append(", DayTgtInJan")
                End If
                If i = 11 Then
                    sqlstr.Append(", DayTgtInFeb")
                End If
                If i = 12 Then
                    sqlstr.Append(", DayTgtInMar")
                End If
                If i = 1 Then
                    sqlstr.Append(", DayTgtInApr")
                End If
                If i = 2 Then
                    sqlstr.Append(", DayTgtInMay")
                End If
                If i = 3 Then
                    sqlstr.Append(", DayTgtInJun")
                End If
                If i = 4 Then
                    sqlstr.Append(", DayTgtInJul")
                End If
                If i = 5 Then
                    sqlstr.Append(", DayTgtInAug")
                End If
                If i = 6 Then
                    sqlstr.Append(", DayTgtInSep")
                End If
                If i = 7 Then
                    sqlstr.Append(", DayTgtInOct")
                End If
                If i = 8 Then
                    sqlstr.Append(", DayTgtInNov")
                End If
                If i = 9 Then
                    sqlstr.Append(", DayTgtInDec")
                End If
            Next
            sqlstr.Append(" from mm_AnnualAndDay_Targets_for_PHL where finyear = '" & finYear & "'")
            If Product.ToLower = "01c" Or Product.ToLower = "01g" Then
                sqlstr.Append(" and WhlOrAxlOrSet = 'W'")
                If Product.EndsWith("C") = True Then
                    sqlstr.Append(" and nature = 'cast'")
                Else
                    sqlstr.Append(" and nature <> 'cast'")
                End If
            ElseIf Product.ToLower = "02e" Then
                sqlstr.Append(" and WhlOrAxlOrSet = 'A' and nature = 'External'")
            ElseIf Product.ToLower = "03e" Then
                sqlstr.Append(" and WhlOrAxlOrSet = 'S' and nature = 'External'")
            ElseIf Product.ToLower = "02i" Then
                sqlstr.Append(" and WhlOrAxlOrSet = 'A' and nature = 'InHouse'")
            ElseIf Product.ToLower = "03i" Then
                sqlstr.Append(" and WhlOrAxlOrSet = 'S' and nature = 'InHouse'")
            ElseIf Product.ToLower = "02" Then
                sqlstr.Append(" and WhlOrAxlOrSet = 'A' and nature = ''")
            ElseIf Product.ToLower = "03" Then
                sqlstr.Append(" and WhlOrAxlOrSet = 'S' and nature = ''")
            End If
            Dim sqlstring As String = "Select "
            Dim len As Integer = sqlstr.ToString.Length
            sqlstring &= sqlstr.ToString.Substring(2, len - 2)
            Dim da As System.Data.SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            da = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = sqlstring.ToString
            Try
                da.Fill(ds)
                GetDayTargets = ds.Tables(0)
            Catch exp As Exception
                GetDayTargets = Nothing
                Throw New Exception("Error in retrival of Month Targets")
            Finally
                ds.Dispose()
                da.Dispose()
                da = Nothing
                ds = Nothing
            End Try
            Return GetDayTargets
        End Function
        Public Shared Function GetMonthTargets(ByVal Product As String, ByVal finYear As String, ByVal FromValue As String, ByVal ToValue As String, ByVal ToValueName As String) As DataTable
            'Dim sqlstr As New System.Text.StringBuilder()
            'sqlstr.Append("select month_number, working_days, wap_monthly_quantity from mm_schedule_rwf_plan where category like '" & Left(Product, 2) & "%' and wta_control_number like '" & Left(finYear, 4) & "%'")
            'If Product.StartsWith("01") = True Then
            '    If Product.EndsWith("C") = True Then
            '        sqlstr.Append(" and  remarks like 'cast%' ")
            '    Else
            '        sqlstr.Append(" and  remarks not like 'cast%' ")
            '    End If
            'End If
            'If Product.StartsWith("02") = True OrElse Product.StartsWith("03") = True Then
            '    If Product.EndsWith("I") = True Then
            '        sqlstr.Append(" and  remarks like 'InHouse%' ")
            '    ElseIf Product.EndsWith("E") = True Then
            '        sqlstr.Append(" and  remarks like 'External%' ")
            '    Else
            '        sqlstr.Append(" and  remarks like '' ")
            '    End If
            'End If
            'If Product.StartsWith("03") = True OrElse Product.StartsWith("03") = True Then
            '    If Product.EndsWith("I") = True Then
            '        sqlstr.Append(" and  remarks like 'InHouse%' ")
            '    ElseIf Product.EndsWith("E") = True Then
            '        sqlstr.Append(" and  remarks like 'External%' ")
            '    Else
            '        sqlstr.Append(" and  remarks like '' ")
            '    End If
            'End If
            'sqlstr.Append(" '" & ToValueName & "' ")
            'sqlstr.Append(" order by Quarter_number, Month_number ")
            Dim da As System.Data.SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            da = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = ToValueName
            Try
                da.Fill(ds)
                GetMonthTargets = ds.Tables(0)
            Catch exp As Exception
                GetMonthTargets = Nothing
                Throw New Exception("Error in retrival of Month Targets")
            Finally
                ds.Dispose()
                da.Dispose()
                da = Nothing
                ds = Nothing
            End Try
            Return GetMonthTargets
        End Function
        Public Shared Function GetYearTargets(ByVal Product As String, ByVal finYear As String) As DataTable
            Dim sqlstr As New System.Text.StringBuilder()
            sqlstr.Append(" isnull(plannedWorkingDays,0) plannedWorkingDays, isnull(AnnualTarget,0) AnnualTarget from mm_AnnualAndDay_Targets_for_PHL where finyear = '" & finYear & "'")

            If Product.ToLower = "01c" Or Product.ToLower = "01g" Then
                sqlstr.Append(" and WhlOrAxlOrSet = 'W'")
                If Product.EndsWith("C") = True Then
                    sqlstr.Append(" and nature = 'cast'")
                Else
                    sqlstr.Append(" and nature <> 'cast'")
                End If
            ElseIf Product.ToLower.Substring(0, 2) = "02" Then
                If Product.EndsWith("I") = True Then
                    sqlstr.Append(" and WhlOrAxlOrSet = 'A' and nature = 'InHouse'")
                ElseIf Product.EndsWith("E") = True Then
                    sqlstr.Append(" and WhlOrAxlOrSet = 'A' and nature = 'External'")
                Else
                    sqlstr.Append(" and WhlOrAxlOrSet = 'A' and nature = ''")
                End If
            ElseIf Product.ToLower.Substring(0, 2) = "03" Then
                If Product.EndsWith("I") = True Then
                    sqlstr.Append(" and WhlOrAxlOrSet = 'S' and nature = 'InHouse'")
                ElseIf Product.EndsWith("E") = True Then
                    sqlstr.Append(" and WhlOrAxlOrSet = 'S' and nature = 'External'")
                Else
                    sqlstr.Append(" and WhlOrAxlOrSet = 'S' and nature = ''")
                End If
            End If
            Dim sqlstring As String = "Select "
            sqlstring &= sqlstr.ToString
            Dim da As System.Data.SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            da = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = sqlstring
            Try
                da.Fill(ds)
                GetYearTargets = ds.Tables(0)
            Catch exp As Exception
                GetYearTargets = Nothing
                Throw New Exception("Error in retrival of Year Targets")
            Finally
                ds.Dispose()
                da.Dispose()
                da = Nothing
                ds = Nothing
            End Try
            Return GetYearTargets
        End Function
        Public Shared Function CheckAuthority(ByVal Activity As String, ByVal AuthorisorLogin As String) As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@Activity", SqlDbType.VarChar, 50).Value = Activity
            cmd.Parameters.Add("@AuthorisorLogin", SqlDbType.VarChar, 50).Value = AuthorisorLogin
            cmd.Parameters.Add("@Cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output

            cmd.CommandText = "select @Cnt = count(*)  from  mm_MMS_Authorisations where AuthorisedActivity = @Activity" &
                                         " and AuthorisorLogin = @AuthorisorLogin  and compliedDateTime = '1900-01-01 00:00:00'"
            cmd.Connection.Open()
            Try
                cmd.ExecuteScalar()
                CheckAuthority = IIf(IsDBNull(cmd.Parameters("@Cnt").Value), 0, cmd.Parameters("@Cnt").Value)
            Catch exp As Exception
                CheckAuthority = False
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function WTA_ProductList() As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            Dim WTAProductList As New DataTable()
            da = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "select a.Product_Code , rtrim(a.Product_Code) +'--'+ b.Description Product_Desc , a.RWF_Drawing , a.CustomerDrawing from mm_pco_WTA_ProductList a " &
                                                " inner join mm_product_master b on a.product_code = b.product_code "
            Try
                da.Fill(ds)
                WTAProductList = ds.Tables(0)
                Return WTAProductList
            Catch exp As Exception
                Throw New Exception("Error in retrival of productList")
            Finally
                ds.Dispose()
                da.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function WTA_NumberList() As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            Dim WTANumberList As New DataTable()
            da = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "select WtaRef , rtrim(WtaNumber) +'--'+ convert(varchar(10),WtaDate,103) [WtaNumber--Date]  , Remarks , WtaNumber , WtaDate  from mm_pco_WTA_Meetings"
            Try
                da.Fill(ds)
                WTANumberList = ds.Tables(0)
                Return WTANumberList
            Catch exp As Exception
                Throw New Exception("Error in retrival of WTA Number")
            Finally
                ds.Dispose()
                da.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function WTA_SupplyOrdersList() As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            Dim WTASupplyOrdersList As New DataTable()
            da = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = " select OrderId , rtrim(OrderNumber) +'--'+ convert(varchar(10),OrderDate,103) [OrderNumber--Date] , OrderNumber , OrderDate , OrderedBy, OrderType , Remarks  from mm_pco_WTA_SupplyOrders "
            Try
                da.Fill(ds)
                WTASupplyOrdersList = ds.Tables(0)
                Return WTASupplyOrdersList
            Catch exp As Exception
                Throw New Exception("Error in retrival of WTA Supply Orders")
            Finally
                ds.Dispose()
                da.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function ConsigneeList() As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            Dim WTAConsigneeList As New DataTable()
            da = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = " select code , rtrim(code)+'--'+name [ConsigneeCode--Desc] from mm_customer_consignee where code not in ( select distinct ConsigneeCode from mm_pco_WTA_Supplies )  order by name "
            Try
                da.Fill(ds)
                WTAConsigneeList = ds.Tables(0)
                Return WTAConsigneeList
            Catch exp As Exception
                Throw New Exception("Error in retrival of WTA Consignee List ")
            Finally
                ds.Dispose()
                da.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function WTA_ConsigneeSupplyList(Optional ByVal planID As Long = 0) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            Dim WTAConsigneeSupplyList As New DataTable()
            da = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "select  a.SupplyID , a.planID, a.ConsigneeCode,  b.name, a.OrderedQty, a.PONumber , a.Remarks from mm_pco_WTA_Supplies a inner join mm_customer_consignee b on a.consigneeCode = b.code order by a.ConsigneeCode "
            Try
                da.Fill(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    WTAConsigneeSupplyList = ds.Tables(0)
                Else
                    WTAConsigneeSupplyList = Nothing
                End If
            Catch exp As Exception
                Throw New Exception("Error in retrival of WTA Consignee Supply List ")
            Finally
                ds.Dispose()
                da.Dispose()
                da = Nothing
                ds = Nothing
            End Try
            Return WTAConsigneeSupplyList
        End Function
        Public Shared Function WTA_PlannedQuantities() As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            Dim WTAPlannedQuantitiesList As New DataTable()
            da = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = " select distinct PlanId , ProductCode , Description , WtaNumber , WtaDate , OrderNumber , OrderDate , QtyDate , OrderQty , Remarks Remarks  ,  SupplyOrderId OrdId , WTA_Ref Ref " &
                                            " from mm_vw_pco_WTADetailView" ' where PlanId In ( Select PlanId  from mm_pco_WTA_PlannedQuantities ) "
            Try
                da.Fill(ds)
                WTAPlannedQuantitiesList = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception("Error In retrival Of WTA Consignee List ")
            Finally
                ds.Dispose()
                da.Dispose()
                da = Nothing
                ds = Nothing
            End Try
            Return WTAPlannedQuantitiesList
        End Function
        Public Shared Function WTA_SuppliesPlan() As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            Dim WTASupplyPlanList As New DataTable()
            da = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = " Select distinct PlanId , ProductCode , Description , WtaNumber , WtaDate , OrderNumber , OrderDate , QtyDate , OrderQty , Remarks ,  SupplyOrderId OrdId , WTA_Ref Ref " &
                                            " from mm_vw_pco_WTADetailView where PlanId in ( select PlanId  from mm_pco_WTA_PlannedQuantities ) "
            Try
                da.Fill(ds)
                WTA_SuppliesPlan = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception("Error in retrival of WTA Supply Plan List ")
            Finally
                ds.Dispose()
                da.Dispose()
                da = Nothing
                ds = Nothing
            End Try
            Return WTA_SuppliesPlan
        End Function
        Public Shared Function ProductMasterList() As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            Dim ProductList As New DataTable()
            da = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "select Product_Code , rtrim(Product_Code) + '--'+ Description Product_Desc , Drawing_number from mm_Product_master where product_code not in ( select Product_Code from mm_pco_WTA_ProductList  ) order by product_code "
            Try
                da.Fill(ds)
                ProductList = ds.Tables(0)
            Catch exp As Exception
                ProductList = Nothing
                Throw New Exception("Error in retrival of productList")
            Finally
                ds.Dispose()
                da.Dispose()
                da = Nothing
                ds = Nothing
            End Try
            Return ProductList
        End Function
        Public Shared Function GetHolidayList1(ByVal FromDate As String, ByVal chkMEME As Boolean, ByVal chkMOPO As Boolean, ByVal chkWFPS As Boolean, ByVal chkAMA As Boolean) As DataSet

            Dim da As System.Data.SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            Dim ProductList As New DataTable()
            da = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "mm_sp_HolidayList"
            da.SelectCommand.Parameters.Add("@Holiday", SqlDbType.SmallDateTime, 4).Value = CDate(FromDate)
            da.SelectCommand.Parameters.Add("@chkMEME", SqlDbType.Int, 4).Value = chkMEME
            da.SelectCommand.Parameters.Add("@chkMOPO", SqlDbType.Int, 4).Value = chkMOPO
            da.SelectCommand.Parameters.Add("@chkWFPS", SqlDbType.Int, 4).Value = chkWFPS
            da.SelectCommand.Parameters.Add("@chkAMA", SqlDbType.Int, 4).Value = chkAMA
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            Try
                da.Fill(ds)
                GetHolidayList1 = ds.Copy
            Catch exp As Exception
                ProductList = Nothing
                Throw New Exception("Error in retrival of HolidayList")
            Finally
                ds.Dispose()
                da.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function GetHolidayList(ByVal ToDate As String, ByVal FromDate As String, ByVal Reason As String, ByVal chkMEME As Boolean, ByVal chkMOPO As Boolean, ByVal chkWFPS As Boolean, ByVal chkAMA As Boolean) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                Dim strcmd As New System.Text.StringBuilder()
                strcmd.Append("Select convert(varchar(10),HolidayDate,103) HolidayDt , ShopName , " &
                                " rtrim(Reason) Reason , Shop from mm_vw_HolidayCalendar ")
                Dim blnWherePut As Boolean
                If ToDate <> "" Then
                    da.SelectCommand.Parameters.Add("@todate", SqlDbType.DateTime, 8)
                End If
                If FromDate <> "" Then
                    da.SelectCommand.Parameters.Add("@fromdate", SqlDbType.DateTime, 8)
                End If
                If ToDate <> "" Then
                    strcmd.Append(" where HolidayDate between @fromdate and @todate ")
                    blnWherePut = True
                    da.SelectCommand.Parameters("@fromdate").Value = CDate(FromDate)
                    da.SelectCommand.Parameters("@todate").Value = CDate(ToDate)
                ElseIf FromDate <> "" Then
                    strcmd.Append(" where HolidayDate = @fromdate ")
                    da.SelectCommand.Parameters("@fromDate").Value = CDate(FromDate)
                    blnWherePut = True
                Else
                    strcmd.Append(" where HolidayDate between wap.dbo.mm_fn_si_GetFinYearDate(getdate(),1) and wap.dbo.mm_fn_si_GetFinYearDate(getdate(),0) ")
                    blnWherePut = True
                End If

                Dim shopList As String
                If chkMEME Then shopList = "'MEME' "
#Disable Warning BC42104 ' Variable is used before it has been assigned a value
                If chkMOPO Then shopList &= "'MOPO' "
#Enable Warning BC42104 ' Variable is used before it has been assigned a value
                If chkWFPS Then shopList &= "'CLCL' "
                If chkAMA Then shopList &= "'AMA' "
                If shopList <> "" Then
                    shopList = shopList.Trim.Replace(" ", ",")
                    If blnWherePut = False Then
                        strcmd.Append("where")
                        blnWherePut = True
                    Else
                        strcmd.Append(" and ")
                    End If
                    strcmd.Append(" shop in (" & shopList & ") ")
                End If
                If Reason <> "" AndAlso Reason <> "Select" Then
                    If blnWherePut = False Then
                        strcmd.Append(" where Reason = '" & Reason.Trim & "' ")
                    Else
                        strcmd.Append(" and Reason = '" & Reason.Trim & "' ")
                    End If
                End If
                strcmd.Append(" order by HolidayDate desc , ShopName  ")
                da.SelectCommand.CommandText = strcmd.ToString
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
        Public Shared Function GetHolidayReason() As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = "Select distinct HolidayReason from mm_HolidayReasons"
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
        Public Shared Function CheckBOM(ByVal ProductCode As String) As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@ProductCode", SqlDbType.VarChar, 50).Value = ProductCode
            cmd.Parameters.Add("@Cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            cmd.CommandText = "Select @Cnt = count(*) from mm_bill_of_material where Product_Code = @ProductCode"
            cmd.Connection.Open()
            Try
                CheckBOM = IIf(IsDBNull(cmd.Parameters("@Cnt").Value), 0, cmd.Parameters("@Cnt").Value)
            Catch exp As Exception
                CheckBOM = 0
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function CheckPHLDate(ByVal PHL As Date) As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@phlDate", SqlDbType.SmallDateTime, 4).Value = PHL
            cmd.Parameters.Add("@Cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            cmd.CommandText = "Select @Cnt = count(*) from mm_phl_generation where phl_date = @phlDate"
            cmd.Connection.Open()
            Try
                CheckPHLDate = IIf(IsDBNull(cmd.Parameters("@Cnt").Value), 0, cmd.Parameters("@Cnt").Value)
            Catch exp As Exception
                CheckPHLDate = 0
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function GetTopPHLDate() As Date
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.CommandText = "select top 1 @phl_date =  phl_date from mm_phl_generation order by phl_date desc "
            cmd.Parameters.Add("@phl_date", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output
            Try
                cmd.Connection.Open()
                cmd.ExecuteScalar()
                GetTopPHLDate = IIf(IsDBNull(cmd.Parameters("@phl_date").Value), "01-01-1900", cmd.Parameters("@phl_date").Value)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function GetProductsDetails(ByVal Pcode As String) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.Parameters.Add("@type", SqlDbType.VarChar, 50).Value = Pcode.Trim
                da.SelectCommand.CommandText = "SELECT a.product_code Product , a.product_description Descri , rtrim(a.drawing_number) Drg , a.pl_number, " &
                    " b.short_description, convert(decimal(18,3),a.quantity) Qty , convert(varchar(11),a.effective_date,103) EffectiveDt , " &
                    " rtrim(a.uom_description) Unit , rtrim(a.shop_consignee) Consignee ,  rtrim(c.cast_group) CastGroup" &
                    " FROM wap.dbo.mm_bom_composite a inner join wap.dbo.pm_ItemMaster b" &
                    " on a.pl_number = b.pl_number inner join wap.dbo.mm_product_master c" &
                    " on a.product_code = c.product_code WHERE a.product_code = @type  ORDER BY a.pl_number "
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
        Public Shared Function GetProducts() As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = "SELECT product_code + ' : ' + description as text, product_code as value FROM mm_product_master where product_code in (110123,120120,110541) order by Product_code"
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
        Public Shared Function AxleShopRejData(ByVal RejDate As Date) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = "mm_sp_AxleShopRejData"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.Add("@PhlDate", SqlDbType.SmallDateTime, 4).Value = RejDate
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
        Public Shared Function NewProductionGlanceData(ByVal PhlDate As Date) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = "mm_sp_ProductionGlanceNew"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.Add("@PhlDate", SqlDbType.SmallDateTime, 4).Value = PhlDate
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
        Public Shared Function PHLDates() As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = " Select convert(varchar(11), phl_date, 103) PhlFor, phl_date from mm_PHLGEN_prodplan order by phl_date desc "
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
        Public Shared Function PCOFinYear() As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = " Select distinct finYear, finyear finyr from mm_AnnualAndDay_Targets_for_PHL order by finyear desc "
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
        Public Shared Function CheckWODate(ByVal WO As String) As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@WO", SqlDbType.VarChar, 4).Value = WO
            cmd.Parameters.Add("@Cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            Dim sMnStr As String = "ABCDEFGHIJKL"
            Dim dt As Date
            cmd.Connection.Open()
            'Dim dd As Date
            'dd = CDate("2013-09-10")
            'If dd.Day <= 15 Then
            If Today().Date.Day <= 15 Then
                cmd.CommandText = "select top 1 case when month(rmr_date) = month(drawing_date) then  rmr_date  " &
                    " else drawing_date end from mm_rmr where workorder_number = @WO order by rmr_date desc "
                Try
                    dt = IIf(IsDBNull(cmd.ExecuteScalar()), Today(), cmd.ExecuteScalar())
                Catch exp As Exception
                    dt = Today()
                End Try
            Else
                dt = Today()
            End If
            cmd.CommandText = "select case when (DATEADD(D,5,convert(smalldatetime,convert(varchar(11), GETDATE()))) between START_DATE AND DATEADD(D,15,END_DATE)) then 0 else 1 end from mm_workorder where number = @WO"
            cmd.Parameters.Add("@Dt", SqlDbType.SmallDateTime, 4).Value = dt
            If cmd.ExecuteScalar > 0 Then
                Throw New Exception("RMRs cannot be printed for Old Workorders (" & WO & ")")
                CheckWODate = False
            Else
                CheckWODate = True
            End If
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
        End Function
        Public Shared Function GetShopCodes(ByVal Consignee As String) As DataSet
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = " SELECT distinct (SD.stn_id +'--'+ SD.stn_desc)as stnid_desc,SD.stn_id  " &
                    " FROM mm_mmsdt_dump as SD inner join mm_ShopGround_ShopCode as SC  " &
                    " on SD.stn_id LIKE SC.Shop_Code + '%'" &
                    " WHERE stn_id = @Consignee ; " &
                    " SELECT distinct  top 2 year(consumed_date) ConsumedYear  " &
                    " FROM mm_daily_pl_consumption order by year(consumed_date) desc ; " &
                    " select right(ConsumedYear,2) MNo  , right(convert(varchar(6),MaxDt,113),3) MName" &
                    " from ( SELECT  top 12  convert(varchar(6),consumed_date,112) ConsumedYear  , max(consumed_date) MaxDt" &
                    " FROM mm_daily_pl_consumption" &
                    " group by convert(varchar(6),consumed_date,112)" &
                    " order by convert(varchar(6),consumed_date,112) ) a" &
                    " order by right(ConsumedYear,2) ; " &
                    " select right(convert(varchar(6),MaxDt,112),2) MNo from (" &
                    " SELECT  max(consumed_date) MaxDt" &
                    " FROM mm_daily_pl_consumption ) a "
                'in ( SELECT distinct shop_code FROM mm_daily_pl_consumption ) ;" & _
                da.SelectCommand.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = Consignee.Trim
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
        Public Shared Function WOQry(ByVal pattern As String) As DataTable
            Try
                Dim ds As New DataSet()
                Dim da As SqlClient.SqlDataAdapter
                da = rwfGen.Connection.Adapter
                da.SelectCommand.Parameters.Add("@pattern", SqlDbType.VarChar, 2).Value = pattern.Trim
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.CommandText = "mm_sp_pco_workorders"
                Try
                    da.Fill(ds)
                    WOQry = ds.Tables(0)
                Catch exp As Exception
                    Throw New Exception(exp.Message)
                Finally
                    da.Dispose()
                    ds.Dispose()
                    da = Nothing
                    ds = Nothing
                End Try
            Catch exp As Exception
                Throw New Exception(exp.Message)
            End Try
        End Function
        Public Shared Function PCOQry(ByVal type As String) As DataTable
            Try
                Dim ds As New DataSet()
                Dim da As SqlClient.SqlDataAdapter
                da = rwfGen.Connection.Adapter
                da.SelectCommand.Parameters.Add("@type", SqlDbType.VarChar, 1).Value = type.Trim
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.CommandText = "mm_sp_product_master_List"
                Try
                    da.Fill(ds)
                    PCOQry = ds.Tables(0)
                Catch exp As Exception
                    Throw New Exception(exp.Message)
                Finally
                    da.Dispose()
                    ds.Dispose()
                    da = Nothing
                    ds = Nothing
                End Try
            Catch exp As Exception
                Throw New Exception(exp.Message)
            End Try
        End Function
        Public Shared Function CheckWorkOrderQty(ByVal WO As String, ByVal Type As String, ByVal WOQty As Integer) As String
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim Qty As Integer
            If Type.ToUpper = "NEW" Then
                If WOQty < 0 Then CheckWorkOrderQty = "Cannot be less than 0 !"
                CheckWorkOrderQty = ""
                Exit Function
            Else
                If WO.EndsWith("E") Then
                    cmd.CommandText = "select top 1 @WOQty =  c.value  " &
                    " from  mm_workorder b inner join mm_product_master a      " &
                    " on a.product_code = b.product_code  inner join mm_PHLGen_PP_Sum c on " &
                    " c.description = b.description  and c.phl_date between b.start_date and b.end_date " &
                    " and c.period = 'Month' and c.description <> 'total' and c.type  in ('Net Wheels Cast' ) " &
                    " and b.number like '%e' where b.number = @WO order by phl_date desc "
                ElseIf WO.EndsWith("N") OrElse WO.EndsWith("L") Then
                    cmd.CommandText = "select top 1  @WOQty =  c.value " &
                    " from mm_workorder b  inner join mm_product_master a " &
                    " on a.product_code = b.product_code  inner join mm_PHLGen_PP_Sum c on " &
                    " c.description = b.description  and c.phl_date between b.start_date and b.end_date " &
                    " and  c.period = 'Month' and c.description <> 'total' " &
                    " and c.type  in ('Good Wheels' ) and b.number like '%[l,n]'" &
                    " where b.number = @WO order by phl_date desc "
                ElseIf WO.EndsWith("A") OrElse WO.EndsWith("S") OrElse WO.EndsWith("B") Then
                    cmd.CommandText = "select top 1  @WOQty =  c.count " &
                    " from mm_workorder b  inner join mm_product_master a " &
                    " on a.product_code = b.product_code  inner join mm_PHLGEN_WheelSets c " &
                    " on c.description = b.description   and c.phl_date between b.start_date and b.end_date " &
                    " where b.number like '%[a,s,b]' and c.type like '%assemled%' and c.period = 'Month' " &
                    " and b.number = @WO order by phl_date desc"
                ElseIf WO.EndsWith("M") OrElse WO.EndsWith("P") Then
                    cmd.CommandText = "select top 1  @WOQty =  value " &
                    " from  mm_PHLGEN_AxleShop_numbers_units a inner join mm_workorder b on a.product_code = b.product_code " &
                    " and phl_date between start_date and end_date where b.number like '%[m,p,q]' and period = 'month' and a.type = 'MPT Axle Numbers' " &
                    " and b.number = @WO  order by phl_date desc "
                ElseIf WO.EndsWith("F") Or WO.EndsWith("G") Then
                    cmd.CommandText = "select top 1 @WOQty = value " &
                    " from  mm_PHLGEN_AxleShop_numbers_units a inner join mm_workorder b on a.product_code = b.product_code " &
                    " where b.number like '%F' and period = 'month' and a.type = 'Forged' " &
                    " and b.number = @WO and phl_date between start_date and end_date order by phl_date desc"
                End If
            End If

            cmd.Parameters.Add("@WOQty", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            Try
                cmd.Parameters.Add("@WO", SqlDbType.VarChar, 4).Value = WO
                cmd.Connection.Open()
                cmd.ExecuteScalar()
                Qty = IIf(IsDBNull(cmd.Parameters("@WOQty").Value), 0, cmd.Parameters("@WOQty").Value)
                CheckWorkOrderQty = ""
                Select Case Type
                    Case "EnhanceQty"
                        If Qty > WOQty Then
                            CheckWorkOrderQty = "Enhanced Qty : " & WOQty & " cannot be less than " & WO.Trim & " Produced Qty : " & Qty & "  !"
                        End If
                End Select
            Catch exp As Exception
                CheckWorkOrderQty = ""
                Throw New Exception(exp.Message)
            Finally
                If IsNothing(cmd) = False Then
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                End If
            End Try
        End Function
        Public Shared Function CheckWorkOrder(ByVal WO As String, ByVal Type As String) As String
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim status As String
            cmd.CommandText = "select @status = status from mm_workorder where number = @WO "
            cmd.Parameters.Add("@status", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            Try
                cmd.Parameters.Add("@WO", SqlDbType.VarChar, 4).Value = WO
                cmd.Connection.Open()
                cmd.ExecuteScalar()
                status = IIf(IsDBNull(cmd.Parameters("@status").Value), "", cmd.Parameters("@status").Value)
                status = status.ToUpper
                CheckWorkOrder = ""
                Select Case Type
                    Case "EnhanceQty"
                        If status <> "OPEN" Then
                            CheckWorkOrder = "WO : " & WO.Trim & " Qty cannot be Enhanced as staus is not OPEN !"
                        End If
                    Case "Suspend"
                        If status = "SUSPENDED" Then
                            CheckWorkOrder = "WO : " & WO.Trim & " cannot be Suspended again !"
                        ElseIf status = "CLOSED" Then
                            CheckWorkOrder = "WO : " & WO.Trim & " cannot be Suspended as it is CLOSED !"
                        End If
                    Case "Delete"
                        CheckWorkOrder = "Under Developement !"
                    Case "Resume"
                        If status = "OPEN" Then
                            CheckWorkOrder = "WO : " & WO.Trim & " cannot be Resumed as it is not Suspended !"
                        ElseIf status = "CLOSED" Then
                            CheckWorkOrder = "WO : " & WO.Trim & " cannot be Resumed as it is CLOSED !"
                        End If
                    Case "Close"
                        If status = "CLOSED" Then
                            CheckWorkOrder = "WO : " & WO.Trim & " cannot be closed again !"
                        End If
                End Select
            Catch exp As Exception
                CheckWorkOrder = ""
                Throw New Exception(exp.Message)
            Finally
                If IsNothing(cmd) = False Then
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                End If
            End Try
        End Function
        Public Shared Function GenerateWorkOrder(ByVal MonthYear As String, ByVal ShopCode As String) As DataTable
            If ShopCode = "E2" Then
                ShopCode = "E1"
            End If
            Dim oDs As New DataSet()
            Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            oDa.SelectCommand.CommandText = "mm_sp_GenerateWorkOrder"
            oDa.SelectCommand.CommandType = CommandType.StoredProcedure
            oDa.SelectCommand.Parameters.Add("@MnYear", SqlDbType.VarChar, 7).Value = MonthYear
            oDa.SelectCommand.Parameters.Add("@ShopCode", SqlDbType.VarChar, 2).Value = ShopCode
            Try
                oDa.Fill(oDs)
                GenerateWorkOrder = oDs.Tables(0).Copy
            Catch exp As Exception
                GenerateWorkOrder = Nothing
                Throw New Exception(exp.Message)
            Finally
                oDa.Dispose()
                oDs.Dispose()
                oDa = Nothing
                oDs = Nothing
            End Try
        End Function
        Public Shared Function GetMnth(ByVal intval As Integer) As String
            Select Case intval
                Case 1
                    GetMnth = "January"
                Case 2
                    GetMnth = "February"
                Case 3
                    GetMnth = "March"
                Case 4
                    GetMnth = "April"
                Case 5
                    GetMnth = "May"
                Case 6
                    GetMnth = "June"
                Case 7
                    GetMnth = "July"
                Case 8
                    GetMnth = "August"
                Case 9
                    GetMnth = "September"
                Case 10
                    GetMnth = "October"
                Case 11
                    GetMnth = "November"
                Case 12
                    GetMnth = "December"
                Case Else
                    GetMnth = ""
            End Select
        End Function
        Public Shared Function FillProductCumbo(ByVal Month As String, ByVal Year As String, ByVal ShopCode As String, ByVal Type As String, ByVal Make As String) As DataTable
            Dim GetMnth As String
            Select Case CInt(Month)
                Case 1
                    GetMnth = "A"
                Case 2
                    GetMnth = "B"
                Case 3
                    GetMnth = "C"
                Case 4
                    GetMnth = "D"
                Case 5
                    GetMnth = "E"
                Case 6
                    GetMnth = "F"
                Case 7
                    GetMnth = "G"
                Case 8
                    GetMnth = "H"
                Case 9
                    GetMnth = "I"
                Case 10
                    GetMnth = "J"
                Case 11
                    GetMnth = "K"
                Case 12
                    GetMnth = "L"
                Case Else
                    GetMnth = ""
            End Select
            Dim strWO As String
            strWO = Right(Year, 1) + GetMnth

            Dim oDs As New DataSet()
            Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            If Type.ToUpper = "NEW" Then
                If Trim(ShopCode) = "A1" Then
                    If Make.StartsWith("N") Then
                        oDa.SelectCommand.CommandText = "select  ltrim(rtrim(a.Product_code)) Product_code , " &
                        " ltrim(rtrim(a.description)) Descr  from mm_product_master a inner join mm_product_master b " &
                        " on a.prod_id2 = b.product_code where a.product_code like '[5,6]%' and isnull(a.prod_id2,'') <> '' " &
                        " and b.type <> '' and a.product_code not in ( " &
                        " select product_code from mm_workorder " &
                        " where number like '" & strWO & "%' and shop_code = '" & Trim(ShopCode) & "' ) order by product_code"
                    Else
                        oDa.SelectCommand.CommandText = "select  ltrim(rtrim(a.Product_code)) Product_code , " &
                        " ltrim(rtrim(a.description)) Descr  from mm_product_master a inner join mm_product_master b " &
                        " on a.prod_id2 = b.product_code where a.product_code like '[5,6]%' and isnull(a.prod_id2,'') <> '' " &
                        " and isnull(b.type,'') = '' and a.product_code not in ( " &
                        " select product_code from mm_workorder " &
                        " where number like '" & strWO & "%' and shop_code = '" & Trim(ShopCode) & "' ) order by product_code"
                    End If
                ElseIf Trim(ShopCode) = "F1" Or Trim(ShopCode) = "M1" Then
                    If Make.StartsWith("N") Then
                        oDa.SelectCommand.CommandText = "select  ltrim(rtrim(Product_code)) Product_code , " &
                        " ltrim(rtrim(description)) Descr  from mm_product_master where product_code like '[3,4]%' " &
                        " and isnull(type,'') <> '' and product_code in ( " &
                        " select product_code from mm_workorder " &
                        " where number like '" & strWO & "%' and shop_code = '" & Trim(ShopCode) & "' ) order by product_code"
                    Else
                        oDa.SelectCommand.CommandText = "select  ltrim(rtrim(Product_code)) Product_code , " &
                        " ltrim(rtrim(description)) Descr  from mm_product_master where product_code like '[3,4]%' " &
                        " and isnull(type,'') = '' and product_code not in ( " &
                        " select product_code from mm_workorder " &
                        " where number like '" & strWO & "%' and shop_code = '" & Trim(ShopCode) & "' ) order by product_code"
                    End If
                ElseIf Trim(ShopCode) = "E1" Or Trim(ShopCode) = "E2" Or Trim(ShopCode) = "N1" Then
                    If Make.StartsWith("N") Then
                        oDa.SelectCommand.CommandText = "select  ltrim(rtrim(Product_code)) Product_code , " &
                        " ltrim(rtrim(description)) Descr  from mm_product_master where product_code like '[1,2]%' " &
                        " and isnull(type,'') <> '' and product_code not in ( " &
                        " select product_code from mm_workorder " &
                        " where number like '" & strWO & "%' and cost_center_code = '" & Left(Trim(ShopCode), 1) & "' ) order by product_code"
                    Else
                        oDa.SelectCommand.CommandText = "select  ltrim(rtrim(Product_code)) Product_code , " &
                        " ltrim(rtrim(description)) Descr  from mm_product_master where product_code like '[1,2]%' " &
                        " and isnull(type,'') = '' and product_code in ( " &
                        " select product_code from mm_workorder " &
                        " where number like '" & strWO & "%' and cost_center_code = '" & Left(Trim(ShopCode), 1) & "' ) order by product_code"
                    End If
                Else
                    oDa.SelectCommand.CommandText = "select distinct ltrim(rtrim(Product_code)) Product_code , ltrim(rtrim(description)) Descr from mm_workorder order by product_code"
                End If
            Else
                If Trim(ShopCode) = "A1" Then
                    If Make.StartsWith("N") Then
                        oDa.SelectCommand.CommandText = "select ltrim(rtrim(a.Product_code)) Product_code , ltrim(rtrim(b.description)) Descr " &
                        " from mm_workorder a  inner join mm_product_master b on a.product_code = b.product_code  " &
                        " inner join mm_product_master c on b.prod_id2 = c.product_code and isnull(c.type,'') <> '' " &
                        " where number like '" & strWO & "%' and shop_code = '" & Trim(ShopCode) & "'  order by a.product_code "
                    Else
                        oDa.SelectCommand.CommandText = "select ltrim(rtrim(a.Product_code)) Product_code , ltrim(rtrim(b.description)) Descr " &
                        " from mm_workorder a  inner join mm_product_master b on a.product_code = b.product_code  " &
                        " inner join mm_product_master c on b.prod_id2 = c.product_code and isnull(c.type,'') = '' " &
                        " where number like '" & strWO & "%' and shop_code = '" & Trim(ShopCode) & "'  order by a.product_code "
                    End If
                ElseIf Trim(ShopCode) = "F1" Or Trim(ShopCode) = "M1" Then
                    If Make.StartsWith("N") Then
                        oDa.SelectCommand.CommandText = "select  ltrim(rtrim(a.Product_code)) Product_code , ltrim(rtrim(a.description)) Descr   " &
                        " from mm_workorder a  inner join mm_product_master  b on a.product_code = b.product_code " &
                        " where b.product_code like '[3,4]%'  and isnull(type,'') <> ''  " &
                        " and number like '" & strWO & "%' and shop_code = '" & Trim(ShopCode) & "'  order by product_code"
                    Else
                        oDa.SelectCommand.CommandText = "select  ltrim(rtrim(a.Product_code)) Product_code , ltrim(rtrim(a.description)) Descr " &
                        " from mm_workorder a  inner join mm_product_master b on a.product_code = b.product_code " &
                        " where b.product_code like '[3,4]%'  and isnull(type,'') = '' " &
                        " and number like '" & strWO & "%' and shop_code = '" & Trim(ShopCode) & "'  order by product_code"
                    End If
                ElseIf Trim(ShopCode) = "E1" Or Trim(ShopCode) = "E2" Or Trim(ShopCode) = "N1" Then
                    If Make.StartsWith("N") Then
                        oDa.SelectCommand.CommandText = "select  ltrim(rtrim(a.Product_code)) Product_code , ltrim(rtrim(a.description)) Descr  " &
                        " from mm_workorder a  inner join mm_product_master b on a.product_code = b.product_code " &
                        " where b.product_code like '[1,2]%'  and isnull(type,'') <> ''  " &
                        " and number like '" & strWO & "%' and cost_center_code = '" & Left(Trim(ShopCode), 1) & "'  order by product_code"
                    Else
                        oDa.SelectCommand.CommandText = "select  ltrim(rtrim(a.Product_code)) Product_code , ltrim(rtrim(a.description)) Descr  " &
                        " from mm_workorder a  inner join mm_product_master b on a.product_code = b.product_code " &
                        " where b.product_code like '[1,2]%' and isnull(type,'') = ''  " &
                        " and number like '" & strWO & "%' and cost_center_code = '" & Left(Trim(ShopCode), 1) & "'  order by product_code"
                    End If
                End If
            End If

            Try
                oDa.Fill(oDs)
                FillProductCumbo = oDs.Tables(0).Copy
            Catch exp As Exception
                FillProductCumbo = Nothing
                Throw New Exception(exp.Message)
            Finally
                oDa.Dispose()
                oDs.Dispose()
                oDa = Nothing
                oDs = Nothing
            End Try
        End Function
        Public Shared Function MonthWorkOrders(ByVal Month As String, ByVal Year As String) As DataTable
            Dim GetMnth As String
            Select Case CInt(Month)
                Case 1
                    GetMnth = "A"
                Case 2
                    GetMnth = "B"
                Case 3
                    GetMnth = "C"
                Case 4
                    GetMnth = "D"
                Case 5
                    GetMnth = "E"
                Case 6
                    GetMnth = "F"
                Case 7
                    GetMnth = "G"
                Case 8
                    GetMnth = "H"
                Case 9
                    GetMnth = "I"
                Case 10
                    GetMnth = "J"
                Case 11
                    GetMnth = "K"
                Case 12
                    GetMnth = "L"
                Case Else
                    GetMnth = ""
            End Select
            Dim oDs As New DataSet()
            Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            oDa.SelectCommand.CommandText = "mm_sp_pco_workorders"
            oDa.SelectCommand.CommandType = CommandType.StoredProcedure
            oDa.SelectCommand.Parameters.Add("@pattern", SqlDbType.VarChar, 2).Value = Right(Year, 1) + GetMnth
            Try
                oDa.Fill(oDs)
                MonthWorkOrders = oDs.Tables(0).Copy
            Catch exp As Exception
                MonthWorkOrders = Nothing
                Throw New Exception(exp.Message)
            Finally
                oDa.Dispose()
                oDs.Dispose()
                oDa = Nothing
                oDs = Nothing
            End Try
        End Function
        Public Shared Function WorkOrderListSuspended(ByVal MonthYear As String, ByVal Shop As String, ByVal Make As String) As DataTable
            Dim oDs As New DataSet()
            Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            'If Shop = "E2" Then
            '    Shop = "E1"
            'End If
            oDa.SelectCommand.CommandText = "mm_sp_WorkOrderListSuspended"
            oDa.SelectCommand.CommandType = CommandType.StoredProcedure
            oDa.SelectCommand.Parameters.Add("@MnYear", SqlDbType.VarChar, 7).Value = MonthYear
            oDa.SelectCommand.Parameters.Add("@ShopCode", SqlDbType.VarChar, 2).Value = Shop
            If Make.StartsWith("N") Then
                oDa.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 1
            Else
                oDa.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 0
            End If

            Try
                oDa.Fill(oDs)
                WorkOrderListSuspended = oDs.Tables(0).Copy
            Catch exp As Exception
                WorkOrderListSuspended = Nothing
                Throw New Exception(exp.Message)
            Finally
                oDa.Dispose()
                oDs.Dispose()
                oDa = Nothing
                oDs = Nothing
            End Try
        End Function
        Public Shared Function WorkOrderList(ByVal MonthYear As String, ByVal Shop As String, ByVal Make As String) As DataTable
            Dim oDs As New DataSet()
            Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            'If Shop = "E2" Then
            '    Shop = "E1"
            'End If
            oDa.SelectCommand.CommandText = "mm_sp_WorkOrderList"
            oDa.SelectCommand.CommandType = CommandType.StoredProcedure
            oDa.SelectCommand.Parameters.Add("@MnYear", SqlDbType.VarChar, 7).Value = MonthYear
            oDa.SelectCommand.Parameters.Add("@ShopCode", SqlDbType.VarChar, 2).Value = Shop
            If Make.StartsWith("N") Then
                oDa.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 1
            Else
                oDa.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 0
            End If

            Try
                oDa.Fill(oDs)
                WorkOrderList = oDs.Tables(0).Copy
            Catch exp As Exception
                WorkOrderList = Nothing
                Throw New Exception(exp.Message)
            Finally
                oDa.Dispose()
                oDs.Dispose()
                oDa = Nothing
                oDs = Nothing
            End Try
        End Function
        Public Shared Function GetShopCode(ByVal Shop As String) As DataTable
            Dim oDs As New DataSet()
            Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            If Shop.ToUpper.StartsWith("A") Then
                oDa.SelectCommand.CommandText = "select (rtrim(code)+'-'+ltrim(description)) as ShopCode , " &
                  " ltrim(rtrim(code)) CostCentre  from mm_shop where description like 'a%'"
            Else
                oDa.SelectCommand.CommandText = "select (rtrim(code)+'-'+ltrim(description)) as ShopCode , " &
                    " ltrim(rtrim(code)) CostCentre  from mm_shop where description not like 'a%'"
            End If
            Try
                oDa.Fill(oDs)
                GetShopCode = oDs.Tables(0).Copy
            Catch exp As Exception
                GetShopCode = Nothing
                Throw New Exception(exp.Message)
            Finally
                oDa.Dispose()
                oDs.Dispose()
                oDa = Nothing
                oDs = Nothing
            End Try
        End Function
        Public Shared Function GetMonthYr(ByVal Type As Integer) As DataTable
            Dim txtMonthYr As String = Now.Month.ToString + "/" + Now.Year.ToString
            Dim strMnth, strYr As String
            strMnth = CStr(CDate("1/" & txtMonthYr).Month)
            strYr = CStr(CDate("1/" & txtMonthYr).Year)
            Dim curmnyr As Date
            Dim optedmnyr As Date
            optedmnyr = CDate("01/" & txtMonthYr)
            curmnyr = Today
            Dim diff As TimeSpan
            diff = optedmnyr.Subtract(curmnyr)
            If CType(diff.Days, Integer) < 5 And CType(diff.Days, Integer) < -31 Or CType(diff.Days, Integer) > 7 Then
                Throw New Exception("WO can't be generated for next to next month or later or for Next Year or For Previous Month.")
            End If
            Dim oDs As New DataSet()
            Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            oDa.SelectCommand.CommandText = "mm_sp_GetWOMonthYear"
            oDa.SelectCommand.CommandType = CommandType.StoredProcedure
            If Type = 0 Then
                oDa.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 0
            Else
                oDa.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 1
            End If
            Try
                oDa.Fill(oDs)
                GetMonthYr = oDs.Tables(0).Copy
            Catch exp As Exception
                GetMonthYr = Nothing
                Throw New Exception(exp.Message)
            Finally
                oDa.Dispose()
                oDs.Dispose()
                oDa = Nothing
                oDs = Nothing
            End Try
        End Function
        Public Shared Function isHolidayPosted(ByVal MonthYr As String) As Boolean ' added on 12/4/2006 svi
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.CommandText = "select @cnt = count(*) from mm_calendar_dump where month(date) = @month " &
               " and year(date) = @year"
            cmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            Try
                cmd.Parameters.Add("@month", SqlDbType.TinyInt, 1).Value = Val(Left(MonthYr, 2))
                cmd.Parameters.Add("@year", SqlDbType.SmallInt, 2).Value = Val(Right(MonthYr, 4))
                cmd.Connection.Open()
                cmd.ExecuteScalar()
                isHolidayPosted = IIf(IsDBNull(cmd.Parameters("@cnt").Value), 0, cmd.Parameters("@cnt").Value)
            Catch exp As Exception
                isHolidayPosted = False
                Throw New Exception(exp.Message)
            Finally
                If IsNothing(cmd) = False Then
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                End If
            End Try
        End Function
    End Class
    Public Class PCO
        Const sqlInsert As String = "Insert into mm_calendar_dump (date,shop,dueto) values(@Date, @shop , @reason)"
        Const sqlCheck As String = "Select @cnt  = count(*) from mm_calendar_dump where date = @date and shop =@shop "
        Const sqlDelete As String = "Delete mm_calendar_dump where date = @date and shop = @shop and dueto = @reason"
        Const InsertHolidayReason As String = "Insert into mm_HolidayReasons (HolidayReason) values (@reason)"
        Const sqlUpdtDueTo As String = "Update mm_calendar_dump set dueto = @reason where date = @date and shop = @shop "
        Public Function Holiday(ByVal dt1 As Date, ByVal dt2 As Date, ByVal Reason As String, ByVal chkMEME As Boolean, ByVal chkMOPO As Boolean, ByVal chkWFPS As Boolean, ByVal MEME As String, ByVal MOPO As String, ByVal WFPS As String, ByVal chkSundays As Boolean, ByVal del As Boolean) As Boolean
            'ByVal chkAMA As Boolean,
            Dim sqlcmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim status As String
            Dim Done As Boolean
            Dim iDone As Integer
            Try
                sqlcmd.Parameters.Add("@Date", SqlDbType.DateTime, 8).Direction = ParameterDirection.Input
                sqlcmd.Parameters.Add("@Shop", SqlDbType.VarChar, 50).Direction = ParameterDirection.Input
                sqlcmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                sqlcmd.Parameters.Add("@Reason", SqlDbType.VarChar, 50).Value = Reason.ToUpper.Trim
            Catch exp As Exception
                Throw New Exception(exp.Message)
            End Try
            While dt1 <= dt2
                sqlcmd.Parameters("@Date").Value = dt1
                'chkAMA, AMA, chkAMA, AMA,
                If dt1.DayOfWeek = DayOfWeek.Sunday AndAlso AddSunday(chkMEME, chkMOPO, chkWFPS, MEME, MOPO, WFPS, sqlcmd, del) = True Then iDone += 1
                If dt1.DayOfWeek <> DayOfWeek.Sunday AndAlso chkSundays = False AndAlso AddHoliday(chkMEME, chkMOPO, chkWFPS, MEME, MOPO, WFPS, sqlcmd, del) = True Then iDone += 1
                dt1 = dt1.AddDays(1)
            End While
            If iDone > 0 Then
                Done = True
            End If
            If sqlcmd.Connection.State = ConnectionState.Open Then
                sqlcmd.Connection.Close()
            End If
            sqlcmd.Dispose()
            sqlcmd = Nothing
            Return Done
        End Function
        Public Function AddSunday(ByVal chkMEME As Boolean, ByVal chkMOPO As Boolean, ByVal chkWFPS As Boolean, ByVal MEME As String, ByVal MOPO As String, ByVal WFPS As String, ByRef sqlcmd As SqlClient.SqlCommand, Optional ByVal del As Boolean = False) As Boolean
            'ByVal chkAMA As Boolean,
            If chkMEME AndAlso saving(sqlcmd, ShopCode(MEME), del) = True Then AddSunday = True
            If chkMOPO AndAlso saving(sqlcmd, ShopCode(MOPO), del) = True Then AddSunday = True
            If chkWFPS AndAlso saving(sqlcmd, ShopCode(WFPS), del) = True Then AddSunday = True
            'If chkAMA AndAlso saving(sqlcmd, ShopCode(AMA), del) = True Then AddSunday = True
            If sqlcmd.Connection.State = ConnectionState.Open Then
                sqlcmd.Connection.Close()
            End If

        End Function
        Private Function ShopCode(ByVal chk As String) As String
            Select Case chk
                Case "Melting"
                    ShopCode = "MEME"
                Case "Moulding"
                    ShopCode = "MOPO"
                Case "WFP Shop"
                    ShopCode = "CLCL"
                    'Case "Axle Shop"
                    '    ShopCode = "AMA"
                Case Else
                    Throw New Exception("Heavenly Shop found in RWF by you !  Please inform MIS Centre without fail.")
            End Select
        End Function
        Private Function saving(ByRef sqlcmd As SqlClient.SqlCommand, ByVal sShopName As String, Optional ByVal del As Boolean = False) As Boolean
            Dim blnSaved As Boolean
            Try
                sqlcmd.Connection = rwfGen.Connection.ConObj
                If sqlcmd.Connection.State = ConnectionState.Closed Then
                    sqlcmd.Connection.Open()
                End If
                blnSaved = True
                sqlcmd.Parameters("@Shop").Value = sShopName
                sqlcmd.CommandText = sqlCheck
                sqlcmd.ExecuteScalar()
                If sqlcmd.Parameters("@cnt").Value > 0 Then
                    If del = False Then
                        sqlcmd.CommandText = sqlUpdtDueTo
                    Else
                        Try
                            sqlcmd.Parameters.Add("@FinYear", SqlDbType.VarChar, 7).Direction = ParameterDirection.Output
                            sqlcmd.Parameters.Add("@month_number", SqlDbType.VarChar, 2).Direction = ParameterDirection.Output
                            sqlcmd.CommandText = "select @FinYear = wap.dbo.mm_fn_si_GetFinYear(@date) , @month_number = convert(varchar(2),@date,101) "
                            sqlcmd.ExecuteScalar()
                            If sqlcmd.Parameters("@shop").Value = "AMA" Then
                                sqlcmd.CommandText = "update mm_schedule_rwf_plan set working_days = working_days+1 " &
                                    " where left(wta_control_number,4) = left(@finYear,4) " &
                                    " and category <> '01' and month_number = @month_number "
                            Else
                                sqlcmd.CommandText = "update mm_schedule_rwf_plan set working_days = working_days+1 " &
                                    " where left(wta_control_number,4) = left(@finYear,4) " &
                                    " and category = '01' and month_number = @month_number "
                            End If
                            sqlcmd.ExecuteNonQuery()

                            If sqlcmd.Parameters("@shop").Value = "AMA" Then
                                sqlcmd.CommandText = "update mm_AnnualAndDay_Targets_for_PHL set plannedWorkingDays = plannedWorkingDays+1 " &
                                    " where whlorAxlorSet <> 'W' and finyear = @finYear "
                            Else
                                sqlcmd.CommandText = "update mm_AnnualAndDay_Targets_for_PHL set plannedWorkingDays = plannedWorkingDays+1 " &
                                    " where whlorAxlorSet = 'W' and finyear = @finYear "
                            End If
                            sqlcmd.ExecuteNonQuery()
                        Catch exp As Exception
                            Throw New Exception(exp.Message)
                        End Try
                        sqlcmd.CommandText = sqlDelete
                    End If
                ElseIf del = False Then
                    sqlcmd.CommandText = sqlInsert
                Else
                    blnSaved = False
                End If
                If blnSaved Then
                    sqlcmd.ExecuteNonQuery()
                    sqlcmd.CommandText = sqlCheck
                    sqlcmd.ExecuteScalar()
                    blnSaved = IIf(del = False, sqlcmd.Parameters("@cnt").Value > 0, sqlcmd.Parameters("@cnt").Value = 0)
                End If
            Catch exp As Exception
                blnSaved = False
                Throw New Exception(exp.Message)
            Finally
                If sqlcmd.Connection.State = ConnectionState.Open Then
                    sqlcmd.Connection.Close()
                End If
            End Try
            saving = blnSaved
        End Function
        Private Function AddHoliday(ByVal chkMEME As Boolean, ByVal chkMOPO As Boolean, ByVal chkWFPS As Boolean, ByVal MEME As String, ByVal MOPO As String, ByVal WFPS As String, ByRef sqlcmd As SqlClient.SqlCommand, Optional ByVal del As Boolean = False) As Boolean
            'ByVal chkAMA As Boolean,
            If chkMEME AndAlso saving(sqlcmd, ShopCode(MEME), del) = True Then AddHoliday = True
            If chkMOPO AndAlso saving(sqlcmd, ShopCode(MOPO), del) = True Then AddHoliday = True
            If chkWFPS AndAlso saving(sqlcmd, ShopCode(WFPS), del) = True Then AddHoliday = True
            'If chkAMA AndAlso saving(sqlcmd, ShopCode(AMA), del) = True Then AddHoliday = True
            If sqlcmd.Connection.State = ConnectionState.Open Then
                sqlcmd.Connection.Close()
            End If
        End Function
        Public Function AddReason(ByVal Reason As String) As Boolean
            Dim sqlcmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim status As String
            Dim Done As Boolean
            sqlcmd.CommandText = InsertHolidayReason
            sqlcmd.Parameters.Add("@reason", SqlDbType.VarChar, 50)
            sqlcmd.Parameters("@reason").Direction = ParameterDirection.Input
            sqlcmd.Parameters("@reason").Value = Reason.ToUpper.Trim
            Try
                sqlcmd.Connection.Open()
                If sqlcmd.ExecuteNonQuery() = 1 Then Done = True
            Catch sqlexp As SqlClient.SqlException
                If sqlexp.Number = 2627 Then
                Else
                    Throw New Exception(sqlexp.Message)
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If sqlcmd.Connection.State = ConnectionState.Open Then
                    sqlcmd.Connection.Close()
                End If
                sqlcmd.Dispose()
                sqlcmd = Nothing
            End Try
            Return Done
        End Function
        Public Function UpdateYearTargets(ByVal PlannedWDays As String, ByVal NewQty As String, ByVal Product As String, ByVal finYear As String) As Boolean
            Dim sqlcmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            sqlcmd.Parameters.Add("@PlannedWorkingDays", SqlDbType.SmallInt, 2).Value = CShort(PlannedWDays)
            sqlcmd.Parameters.Add("@AnnualTarget", SqlDbType.BigInt, 8).Value = CLng(NewQty)
            Dim sqlstr As New System.Text.StringBuilder()
            Dim i As Integer
            If PlannedWDays <> "" Then
                sqlstr.Append(", plannedWorkingDays = @plannedWorkingDays")
            End If
            sqlstr.Append(", AnnualTarget = @AnnualTarget")
            sqlstr.Append(" where finyear = '" & finYear & "'")
            If Product.ToLower.Substring(0, 2) = "01" Then
                sqlstr.Append(" and WhlOrAxlOrSet = 'W'")
                If Product.EndsWith("C") = True Then
                    sqlstr.Append(" and nature = 'cast'")
                Else
                    sqlstr.Append(" and nature <> 'cast'")
                End If
            ElseIf Product.ToLower.Substring(0, 2) = "02" Then
                If Product.EndsWith("E") = True Then
                    sqlstr.Append(" and WhlOrAxlOrSet = 'A' and nature = 'External'")
                ElseIf Product.EndsWith("L") = True Then
                    sqlstr.Append(" and WhlOrAxlOrSet = 'A' and nature = 'LooseAxles'")
                ElseIf Product.EndsWith("M") = True Then
                    sqlstr.Append(" and WhlOrAxlOrSet = 'A' and nature = 'MPTAxles'")
                Else
                    sqlstr.Append(" and WhlOrAxlOrSet = 'A' and nature = ''")
                End If
            ElseIf Product.ToLower.Substring(0, 2) = "03" Then
                If Product.EndsWith("E") = True Then
                    sqlstr.Append(" and WhlOrAxlOrSet = 'S' and nature = 'External'")
                Else
                    sqlstr.Append(" and WhlOrAxlOrSet = 'S' and nature = ''")
                End If
            End If

            Dim sqlstring As String = "update mm_AnnualAndDay_Targets_for_PHL set "
            Dim len As Integer = sqlstr.ToString.Length
            sqlstring &= sqlstr.ToString.Substring(2, len - 2)

            Dim Done As Boolean
            Try
                sqlcmd.Connection.Open()
                sqlcmd.CommandText = sqlstring
                If sqlcmd.ExecuteNonQuery() > 0 Then Done = True
            Catch sqlexp As SqlClient.SqlException
                If sqlexp.Number = 2627 Then
                Else
                    Throw New Exception(sqlexp.Message)
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If sqlcmd.Connection.State = ConnectionState.Open Then
                    sqlcmd.Connection.Close()
                End If
                sqlcmd.Dispose()
                sqlcmd = Nothing
            End Try
            Return Done
        End Function
        Public Function updateMonthTarget(ByVal Product As String, ByVal PlannedWDays As String, ByVal finYear As String, ByVal NewQty As String, ByVal FromValue As Integer, ByVal ToValue As Integer, ByVal MonthTable As DataTable) As Boolean
            Dim sqlstr, sqlstr1 As String
            If Left(Product, 2) = "01" Then
                If Product.ToUpper.EndsWith("C") = True Then
                    If PlannedWDays <> "" Then
                        sqlstr = "Update mm_schedule_rwf_plan set working_days = @working_days , " &
                            " wap_monthly_quantity = @wap_monthly_quantity where category = '" & Left(Product, 2) & "' " &
                            " and wta_control_number like '" & Left(finYear, 4) & "%' and remarks like 'cast%' " &
                            " and month_number = @Month_Number "
                    Else
                        sqlstr = "Update mm_schedule_rwf_plan set wap_monthly_quantity = @wap_monthly_quantity " &
                            " where category = '" & Left(Product, 2) & "' and wta_control_number like '" & Left(finYear, 4) & "%' " &
                            " and remarks like 'cast%' and month_number = @Month_Number "
                    End If
                Else
                    If PlannedWDays <> "" Then
                        sqlstr = "Update mm_schedule_rwf_plan set working_days = @working_days , " &
                            " wap_monthly_quantity = @wap_monthly_quantity where category = '" & Left(Product, 2) & "' " &
                            " and wta_control_number like '" & Left(finYear, 4) & "%'and remarks not like 'cast%' and month_number = @Month_Number "
                        sqlstr1 = "Update mm_schedule_plan set working_days = @working_days , " &
                            " wap_monthly_quantity = @wap_monthly_quantity where category = '" & Left(Product, 2) & "' " &
                            " and wta_control_number like '" & Left(finYear, 4) & "%' and month_number = @Month_Number "
                    Else
                        sqlstr = "Update mm_schedule_rwf_plan set wap_monthly_quantity = @wap_monthly_quantity " &
                            " where category = '" & Left(Product, 2) & "' and wta_control_number like '" & Left(finYear, 4) & "%'" &
                            " and remarks not like 'cast%' and month_number = @Month_Number "
                        sqlstr1 = "Update mm_schedule_plan set wap_monthly_quantity = @wap_monthly_quantity " &
                            " where category = '" & Left(Product, 2) & "' " &
                            " and wta_control_number like '" & Left(finYear, 4) & "%' and month_number = @Month_Number "
                    End If
                End If
            Else
                If PlannedWDays <> "" Then
                    sqlstr = "Update mm_schedule_rwf_plan set working_days = @working_days , " &
                        " wap_monthly_quantity = @wap_monthly_quantity where category = '" & Product & "' " &
                        " and wta_control_number like '" & Left(finYear, 4) & "%' and month_number = @Month_Number "
                    sqlstr1 = "Update mm_schedule_plan set working_days = @working_days ," &
                        " wap_monthly_quantity = @wap_monthly_quantity where category = '" & Product & "' " &
                        " and wta_control_number like '" & Left(finYear, 4) & "%' and month_number = @Month_Number "
                Else
                    sqlstr = "Update mm_schedule_rwf_plan set wap_monthly_quantity = @wap_monthly_quantity " &
                        " where category = '" & Product & "' and wta_control_number like '" & Left(finYear, 4) & "%' and month_number = @Month_Number "
                    sqlstr1 = "Update mm_schedule_plan set  wap_monthly_quantity = @wap_monthly_quantity " &
                        " where category = '" & Product & "' and wta_control_number like '" & Left(finYear, 4) & "%' and month_number = @Month_Number "
                End If
            End If
            Dim sqlcmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            sqlcmd.Parameters.Add("@working_days", SqlDbType.Int, 4).Direction = ParameterDirection.Input
            sqlcmd.Parameters.Add("@wap_monthly_quantity", SqlDbType.BigInt, 8).Direction = ParameterDirection.Input
            sqlcmd.Parameters.Add("@Month_number", SqlDbType.VarChar, 2).Direction = ParameterDirection.Input
            If PlannedWDays <> "" Then
                sqlcmd.Parameters("@working_days").Value = CInt(PlannedWDays)
            Else
                sqlcmd.Parameters("@working_days").Value = 0
            End If

            If NewQty <> "" Then
                sqlcmd.Parameters("@wap_monthly_quantity").Value = CLng(NewQty)
            Else
                sqlcmd.Parameters("@wap_monthly_quantity").Value = 0
            End If
            Dim Done As Boolean
            Dim i, j As Integer
            j = 0
            For i = FromValue - 1 To ToValue - 1
                Done = False
                sqlcmd.Parameters("@Month_number").Value = MonthTable.Rows(j)(1)
                Try
                    sqlcmd.Connection.Open()
#Disable Warning BC42104 ' Variable is used before it has been assigned a value
                    If sqlstr1 <> "" Then
#Enable Warning BC42104 ' Variable is used before it has been assigned a value
                        sqlcmd.CommandText = sqlstr1
                        If sqlcmd.ExecuteNonQuery() > 0 Then Done = True
                    Else
                        Done = True
                    End If
                    If Done Then Done = False
                    sqlcmd.CommandText = sqlstr
                    If sqlcmd.ExecuteNonQuery() = 1 Then Done = True
                Catch exp As Exception
                    Throw New Exception("InValid Saving")
                End Try
                If Done = False Then Exit Function
                j = j + 1
            Next
            Return Done
        End Function
        Public Function InsertMonthTargets(ByVal finYear As String) As Boolean
            Dim sqlcmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim Done As Boolean
            sqlcmd.CommandText = "declare @finyear varchar(7)  " &
              " set @finyear = '" & finYear & "'" &
              " declare @Quarter_number int,  @month_number int " &
              " set @month_Number = 1 " &
              " while @Month_number < 13 " &
              "   begin " &
              "     if  @month_number between 4 and 6 " &
              "                begin " &
              "            set @quarter_number = 1 " &
              "                End " &
              "      else if  @month_number between 7 and 9 " &
              "                 begin " &
              "             set @quarter_number = 2 " &
              "                End " &
              "       else if @month_number between 10 and 12 " &
              "                 begin " &
              "            set @quarter_number = 3 " &
              "                End " &
              "             Else " &
              "                 begin " &
              "            set @quarter_number = 4 " &
              "                 End " &
              "     insert into mm_schedule_rwf_plan " &
              "      (  " &
              "                Remarks, wap_monthly_quantity, working_days, wta_control_number, Category, Quarter_number, month_number " &
              "      ) values ( 'Cast Wheels Plan'  , 0  , 0  , left(@finYear,4) + ('0'+convert(varchar,@quarter_number)),'01', @Quarter_number, right('00'+convert(varchar,@month_number),2) )" &
              "     insert into mm_schedule_rwf_plan " &
              "      ( " &
              "                Remarks, wap_monthly_quantity, working_days, wta_control_number, Category, Quarter_number, month_number " &
              "      ) values ( 'Good Wheels Plan'  , 0  , 0  , left(@finYear,4) + ('0'+convert(varchar,@quarter_number)),'01', @Quarter_number, right('00'+convert(varchar,@month_number),2) )" &
              "     insert into mm_schedule_rwf_plan " &
              "      ( " &
              "                Remarks, wap_monthly_quantity, working_days, wta_control_number, Category, Quarter_number, month_number " &
              "      ) values ( 'InHouse'  , 0  , 0  , left(@finYear,4) + ('0'+convert(varchar,@quarter_number)),'02I', @Quarter_number, right('00'+convert(varchar,@month_number),2) )" &
              "     insert into mm_schedule_rwf_plan " &
              "      ( " &
              "                Remarks, wap_monthly_quantity, working_days, wta_control_number, Category, Quarter_number, month_number " &
              "       ) values ( 'External'  , 0  , 0  , left(@finYear,4) + ('0'+convert(varchar,@quarter_number)),'02E', @Quarter_number, right('00'+convert(varchar,@month_number),2) )" &
              "      insert into mm_schedule_rwf_plan " &
              "      ( " &
              "                Remarks, wap_monthly_quantity, working_days, wta_control_number, Category, Quarter_number, month_number " &
              "       ) values ( 'InHouse'  , 0  , 0  , left(@finYear,4) + ('0'+convert(varchar,@quarter_number)),'03I', @Quarter_number, right('00'+convert(varchar,@month_number),2) )" &
              "      insert into mm_schedule_rwf_plan " &
              "       ( " &
              "                Remarks, wap_monthly_quantity, working_days, wta_control_number, Category, Quarter_number, month_number " &
              "       ) values ( 'External'  , 0  , 0  , left(@finYear,4) + ('0'+convert(varchar,@quarter_number)),'03E', @Quarter_number, right('00'+convert(varchar,@month_number),2) )" &
              "      insert into mm_schedule_rwf_plan " &
              "       ( " &
              "                Remarks, wap_monthly_quantity, working_days, wta_control_number, Category, Quarter_number, month_number " &
              "        ) values ( ''  , 0  , 0  , left(@finYear,4) + ('0'+convert(varchar,@quarter_number)),'02', @Quarter_number, right('00'+convert(varchar,@month_number),2) )" &
              "      insert into mm_schedule_rwf_plan " &
              "       ( " &
              "                Remarks, wap_monthly_quantity, working_days, wta_control_number, Category, Quarter_number, month_number " &
              "       ) values ( ''  , 0  , 0  , left(@finYear,4) + ('0'+convert(varchar,@quarter_number)) ,'03', @Quarter_number, right('00'+convert(varchar,@month_number),2) )" &
              "       set @month_Number = @month_Number + 1  " &
              "   End"
            Try
                sqlcmd.Connection.Open()
                If sqlcmd.ExecuteNonQuery() > 0 Then
                    If SchedulePlan(finYear) Then Done = True
                End If
            Catch sqlexp As SqlClient.SqlException
                If sqlexp.Number = 2627 Then
                Else
                    Throw New Exception(sqlexp.Message)
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If sqlcmd.Connection.State = ConnectionState.Open Then
                    sqlcmd.Connection.Close()
                End If
                sqlcmd.Dispose()
                sqlcmd = Nothing
            End Try
            Return Done
        End Function
        Public Function InsertMonthTargetsNew(ByVal finYear As String, ByVal Category As String) As Boolean
            Dim sqlcmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim Done As Boolean
            sqlcmd.CommandText = "declare @finyear varchar(7)  " &
              " set @finyear = '" & finYear & "'" &
              " declare @Quarter_number int,  @month_number int " &
              " set @month_Number = 1 " &
              " while @Month_number < 13 " &
              "   begin " &
              "     if  @month_number between 4 and 6 " &
              "                begin " &
              "            set @quarter_number = 1 " &
              "                End " &
              "      else if  @month_number between 7 and 9 " &
              "                 begin " &
              "             set @quarter_number = 2 " &
              "                End " &
              "       else if @month_number between 10 and 12 " &
              "                 begin " &
              "            set @quarter_number = 3 " &
              "                End " &
              "             Else " &
              "                 begin " &
              "            set @quarter_number = 4 " &
              "                 End " &
              "     insert into mm_schedule_rwf_plan " &
              "      (  " &
              "                Remarks, wap_monthly_quantity, working_days, wta_control_number, Category, Quarter_number, month_number " &
              "      ) values ( 'Cast Wheels Plan'  , 0  , 0  , left(@finYear,4) + ('0'+convert(varchar,@quarter_number)),'01', @Quarter_number, right('00'+convert(varchar,@month_number),2) )" &
              "     insert into mm_schedule_rwf_plan " &
              "      ( " &
              "                Remarks, wap_monthly_quantity, working_days, wta_control_number, Category, Quarter_number, month_number " &
              "      ) values ( 'Good Wheels Plan'  , 0  , 0  , left(@finYear,4) + ('0'+convert(varchar,@quarter_number)),'01', @Quarter_number, right('00'+convert(varchar,@month_number),2) )" &
              "     insert into mm_schedule_rwf_plan " &
              "      ( " &
              "                Remarks, wap_monthly_quantity, working_days, wta_control_number, Category, Quarter_number, month_number " &
              "      ) values ( 'InHouse'  , 0  , 0  , left(@finYear,4) + ('0'+convert(varchar,@quarter_number)),'02I', @Quarter_number, right('00'+convert(varchar,@month_number),2) )" &
              "     insert into mm_schedule_rwf_plan " &
              "      ( " &
              "                Remarks, wap_monthly_quantity, working_days, wta_control_number, Category, Quarter_number, month_number " &
              "       ) values ( 'External'  , 0  , 0  , left(@finYear,4) + ('0'+convert(varchar,@quarter_number)),'02E', @Quarter_number, right('00'+convert(varchar,@month_number),2) )" &
              "      insert into mm_schedule_rwf_plan " &
              "      ( " &
              "                Remarks, wap_monthly_quantity, working_days, wta_control_number, Category, Quarter_number, month_number " &
              "       ) values ( 'InHouse'  , 0  , 0  , left(@finYear,4) + ('0'+convert(varchar,@quarter_number)),'03I', @Quarter_number, right('00'+convert(varchar,@month_number),2) )" &
              "      insert into mm_schedule_rwf_plan " &
              "       ( " &
              "                Remarks, wap_monthly_quantity, working_days, wta_control_number, Category, Quarter_number, month_number " &
              "       ) values ( 'External'  , 0  , 0  , left(@finYear,4) + ('0'+convert(varchar,@quarter_number)),'03E', @Quarter_number, right('00'+convert(varchar,@month_number),2) )" &
              "      insert into mm_schedule_rwf_plan " &
              "       ( " &
              "                Remarks, wap_monthly_quantity, working_days, wta_control_number, Category, Quarter_number, month_number " &
              "        ) values ( ''  , 0  , 0  , left(@finYear,4) + ('0'+convert(varchar,@quarter_number)),'02', @Quarter_number, right('00'+convert(varchar,@month_number),2) )" &
              "      insert into mm_schedule_rwf_plan " &
              "       ( " &
              "                Remarks, wap_monthly_quantity, working_days, wta_control_number, Category, Quarter_number, month_number " &
              "       ) values ( ''  , 0  , 0  , left(@finYear,4) + ('0'+convert(varchar,@quarter_number)) ,'03', @Quarter_number, right('00'+convert(varchar,@month_number),2) )" &
              "       set @month_Number = @month_Number + 1  " &
              "   End"
            Try
                sqlcmd.Connection.Open()
                If sqlcmd.ExecuteNonQuery() = 1 Then
                    If SchedulePlan(finYear) Then Done = True
                End If
            Catch sqlexp As SqlClient.SqlException
                If sqlexp.Number = 2627 Then
                Else
                    Throw New Exception(sqlexp.Message)
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If sqlcmd.Connection.State = ConnectionState.Open Then
                    sqlcmd.Connection.Close()
                End If
                sqlcmd.Dispose()
                sqlcmd = Nothing
            End Try
            Return Done
        End Function
        Public Shared Function GetWTAControlValues(ByVal finYear As String) As DataTable
            Dim oDs As New DataSet()
            Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            oDa.SelectCommand.Parameters.Add("@finYear", SqlDbType.VarChar, 4).Value = Left(finYear, 4)
            oDa.SelectCommand.Parameters.Add("@PreFinYear", SqlDbType.VarChar, 5).Value = CStr(CInt(Left(finYear, 4)) - 1) + "%"
            oDa.SelectCommand.CommandText = "select month_number , " &
                " quarter_number, category,  " &
                " replace(wta_control_number,left(wta_control_number,4),left(wta_control_number,4)+1) wta_control_number " &
                " from mm_schedule_plan " &
                " where wta_control_number like @PreFinYear"
            Try
                oDa.Fill(oDs)
                GetWTAControlValues = oDs.Tables(0).Copy
            Catch exp As Exception
                GetWTAControlValues = Nothing
                Throw New Exception(exp.Message)
            Finally
                oDa.Dispose()
                oDs.Dispose()
                oDa = Nothing
                oDs = Nothing
            End Try
        End Function
        Private Function SchedulePlan(ByVal finYear As String) As Boolean
            Dim sqlcmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim Done As Boolean
            Dim i As Integer
            Dim dt As DataTable = PCO.GetWTAControlValues(finYear)
            Try
                sqlcmd.Connection.Open()
                sqlcmd.Parameters.Add("@month_number", SqlDbType.VarChar, 4).Direction = ParameterDirection.Input
                sqlcmd.Parameters.Add("@quarter_number", SqlDbType.Int, 4).Direction = ParameterDirection.Input
                sqlcmd.Parameters.Add("@category", SqlDbType.VarChar, 4).Direction = ParameterDirection.Input
                sqlcmd.Parameters.Add("@wta_control_number", SqlDbType.VarChar, 6).Direction = ParameterDirection.Input
                For i = 0 To dt.Rows.Count - 1
                    Done = False
                    sqlcmd.Parameters("@month_number").Value = dt.Rows(i)("month_number")
                    sqlcmd.Parameters("@quarter_number").Value = dt.Rows(i)("quarter_number")
                    sqlcmd.Parameters("@category").Value = dt.Rows(i)("category")
                    sqlcmd.Parameters("@wta_control_number").Value = dt.Rows(i)("wta_control_number")
                    sqlcmd.CommandText = "select count(*) from mm_schedule_plan " &
                                       " where month_number = @month_number and Quarter_number = @quarter_number " &
                                       " and Category = @category and wta_control_number = @wta_control_number "
                    If sqlcmd.ExecuteScalar = 0 Then
                        sqlcmd.CommandText = "insert into mm_schedule_plan  " &
                        " ( month_number , Quarter_number , Category , wta_control_number , wap_monthly_quantity , working_days ) " &
                        " values ( @month_number , @Quarter_number , @Category , @wta_control_number , 0 , 0 ) "
                        If sqlcmd.ExecuteNonQuery() = 0 Then Done = True
                    Else
                        Done = True
                    End If
                Next
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If sqlcmd.Connection.State = ConnectionState.Open Then
                    sqlcmd.Connection.Close()
                End If
                sqlcmd.Dispose()
                sqlcmd = Nothing
            End Try
            Return Done
        End Function
        Public Function InsertDayAnnualTargets(ByVal finYear As String, ByVal LoggedInBy As String, ByVal Authority As String) As Boolean
            Dim sqlcmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim Done As Boolean
            sqlcmd.CommandText = "insert into mm_AnnualAndDay_Targets_for_PHL (finyear, whloraxlorset, nature, changedby, authority) " &
                             " values (@finyear, 'W', 'Cast', @loggedEmpCd, @Authority); " &
                             " insert into mm_AnnualAndDay_Targets_for_PHL (finyear, whloraxlorset, nature, changedby, authority) " &
                             " values (@finyear, 'W', 'Good', @loggedEmpCd, @Authority); " &
                             " insert into mm_AnnualAndDay_Targets_for_PHL (finyear, whloraxlorset, nature, changedby, authority) " &
                             " values (@finyear, 'A', '', @loggedEmpCd, @Authority); " &
                             " insert into mm_AnnualAndDay_Targets_for_PHL (finyear, whloraxlorset, nature, changedby, authority) " &
                             " values (@finyear, 'A', 'External', @loggedEmpCd, @Authority); " &
                             " insert into mm_AnnualAndDay_Targets_for_PHL (finyear, whloraxlorset, nature, changedby, authority) " &
                             " values (@finyear, 'S', '', @loggedEmpCd, @Authority); " &
                             " insert into mm_AnnualAndDay_Targets_for_PHL (finyear, whloraxlorset, nature, changedby, authority) " &
                             " values (@finyear, 'S', 'External', @loggedEmpCd, @Authority)"


            sqlcmd.Parameters.Add("@finYear", SqlDbType.VarChar, 7).Value = finYear
            sqlcmd.Parameters.Add("@loggedEmpCd", SqlDbType.VarChar, 6).Value = LoggedInBy
            sqlcmd.Parameters.Add("@authority", SqlDbType.VarChar, 6).Value = Authority.ToUpper
            Try
                sqlcmd.Connection.Open()
                If sqlcmd.ExecuteNonQuery() = 1 Then Done = True
            Catch sqlexp As SqlClient.SqlException
                If sqlexp.Number = 2627 Then
                Else
                    Throw New Exception(sqlexp.Message)
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If sqlcmd.Connection.State = ConnectionState.Open Then
                    sqlcmd.Connection.Close()
                End If
                sqlcmd.Dispose()
                sqlcmd = Nothing
            End Try
            Return Done
        End Function
        Public Function UpdateDayTargets(ByVal FromValue As String, ByVal ToValue As String, ByVal NewQty As String, ByVal finYear As String, ByVal Product As String) As Boolean
            Dim sqlcmd As New SqlClient.SqlCommand()
            sqlcmd.Connection = rwfGen.Connection.ConObj
            sqlcmd.Parameters.Add("@DayTgtInApr", SqlDbType.Int, 4).Value = CLng(NewQty)
            sqlcmd.Parameters.Add("@DayTgtInMay", SqlDbType.Int, 4).Value = CLng(NewQty)
            sqlcmd.Parameters.Add("@DayTgtInJun", SqlDbType.Int, 4).Value = CLng(NewQty)
            sqlcmd.Parameters.Add("@DayTgtInJul", SqlDbType.Int, 4).Value = CLng(NewQty)
            sqlcmd.Parameters.Add("@DayTgtInAug", SqlDbType.Int, 4).Value = CLng(NewQty)
            sqlcmd.Parameters.Add("@DayTgtInSep", SqlDbType.Int, 4).Value = CLng(NewQty)
            sqlcmd.Parameters.Add("@DayTgtInOct", SqlDbType.Int, 4).Value = CLng(NewQty)
            sqlcmd.Parameters.Add("@DayTgtInNov", SqlDbType.Int, 4).Value = CLng(NewQty)
            sqlcmd.Parameters.Add("@DayTgtInDec", SqlDbType.Int, 4).Value = CLng(NewQty)
            sqlcmd.Parameters.Add("@DayTgtInJan", SqlDbType.Int, 4).Value = CLng(NewQty)
            sqlcmd.Parameters.Add("@DayTgtInFeb", SqlDbType.Int, 4).Value = CLng(NewQty)
            sqlcmd.Parameters.Add("@DayTgtInMar", SqlDbType.Int, 4).Value = CLng(NewQty)

            Dim sqlstr As New System.Text.StringBuilder()
            Dim i As Integer
            For i = CInt(FromValue) To CInt(ToValue)
                If i = 1 Then
                    sqlstr.Append(", DayTgtInApr = @DayTgtInApr")
                End If
                If i = 2 Then
                    sqlstr.Append(", DayTgtInMay = @DayTgtInMay")
                End If
                If i = 3 Then
                    sqlstr.Append(", DayTgtInJun = @DayTgtInJun")
                End If
                If i = 4 Then
                    sqlstr.Append(", DayTgtInJul = @DayTgtInJul")
                End If
                If i = 5 Then
                    sqlstr.Append(", DayTgtInAug = @DayTgtInAug")
                End If
                If i = 6 Then
                    sqlstr.Append(", DayTgtInSep = @DayTgtInSep")
                End If
                If i = 7 Then
                    sqlstr.Append(", DayTgtInOct = @DayTgtInOct")
                End If
                If i = 8 Then
                    sqlstr.Append(", DayTgtInNov = @DayTgtInNov")
                End If
                If i = 9 Then
                    sqlstr.Append(", DayTgtInDec = @DayTgtInDec")
                End If
                If i = 10 Then
                    sqlstr.Append(", DayTgtInJan = @DayTgtInJan")
                End If
                If i = 11 Then
                    sqlstr.Append(", DayTgtInFeb = @DayTgtInFeb")
                End If
                If i = 12 Then
                    sqlstr.Append(", DayTgtInMar = @DayTgtInMar")
                End If
            Next
            sqlstr.Append(" where finyear = '" & finYear & "'")
            If Product.ToLower.Substring(0, 2) = "01" Then
                sqlstr.Append(" and WhlOrAxlOrSet = 'W'")
                If Product.EndsWith("C") = True Then
                    sqlstr.Append(" and nature = 'cast'")
                Else
                    sqlstr.Append(" and nature <> 'cast'")
                End If
            ElseIf Product.ToLower = "02e" Then
                sqlstr.Append(" and WhlOrAxlOrSet = 'A' and nature = 'External'")
            ElseIf Product.ToLower = "03e" Then
                sqlstr.Append(" and WhlOrAxlOrSet = 'S' and nature = 'External'")
            ElseIf Product.ToLower = "02" Then
                sqlstr.Append(" and WhlOrAxlOrSet = 'A' and nature = ''")
            ElseIf Product.ToLower = "03" Then
                sqlstr.Append(" and WhlOrAxlOrSet = 'S' and nature = ''")
            ElseIf Product.ToLower = "02l" Then
                sqlstr.Append(" and WhlOrAxlOrSet = 'A' and nature = 'LooseAxles'")
            ElseIf Product.ToLower = "02m" Then
                sqlstr.Append(" and WhlOrAxlOrSet = 'A' and nature = 'MPTAxles'")
            End If
            Dim sqlstring As String = "update mm_AnnualAndDay_Targets_for_PHL set "
            Dim len As Integer = sqlstr.ToString.Length
            sqlstring &= sqlstr.ToString.Substring(2, len - 2)
            sqlcmd.CommandText = sqlstring.ToString
            Dim Done As Boolean
            Try
                sqlcmd.Connection.Open()
                If sqlcmd.ExecuteNonQuery() = 1 Then Done = True
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If sqlcmd.Connection.State = ConnectionState.Open Then
                    sqlcmd.Connection.Close()
                End If
                sqlcmd.Dispose()
                sqlcmd = Nothing
            End Try
            Return Done
        End Function
        Public Function UpdateMMSAuthorisations(ByVal Group As String, ByVal UserID As String) As Boolean
            Dim sqlcmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            sqlcmd.CommandText = "update  mm_MMS_Authorisations set compliedByLogin = @compliedByLogin, CompliedByEmpCode = @CompliedByEmpCode, CompliedDateTime = @CompliedDateTime " &
                                   " where AuthorisedActivity = @Activity " &
                                   " and AuthorisorLogin =  @AuthorisorLogin  and compliedDateTime = '1900-1-1'"
            sqlcmd.Parameters.Add("@Activity", SqlDbType.VarChar, 50).Value = "RWF Production Targets" ' donot change value of this statement
            sqlcmd.Parameters.Add("@AuthorisorLogin", SqlDbType.VarChar, 50).Value = "SSPCO"
            sqlcmd.Parameters.Add("@compliedByLogin", SqlDbType.VarChar, 50).Value = Group
            sqlcmd.Parameters.Add("@CompliedByEmpCode", SqlDbType.VarChar, 6).Value = UserID
            sqlcmd.Parameters.Add("@CompliedDateTime", SqlDbType.DateTime, 8).Value = Now
            Dim Done As Boolean
            Try
                sqlcmd.Connection.Open()
                If sqlcmd.ExecuteNonQuery() = 1 Then Done = True
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If sqlcmd.Connection.State = ConnectionState.Open Then
                    sqlcmd.Connection.Close()
                End If
                sqlcmd.Dispose()
                sqlcmd = Nothing
            End Try
            Return Done
        End Function
        Public Function RBInsertDayAnnualTargets(ByVal finYear As String, ByVal LoggedInBy As String, ByVal Authority As String) As Boolean
            Dim sqlcmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            sqlcmd.CommandText = "insert into mm_AnnualAndDay_RB_Targets_for_PHL (finyear, whloraxlorset, nature, changedby, authority) " &
                             " values (@finyear, 'W', 'Cast', @loggedEmpCd, @Authority); " &
                             " insert into mm_AnnualAndDay_RB_Targets_for_PHL (finyear, whloraxlorset, nature, changedby, authority) " &
                             " values (@finyear, 'W', 'Good', @loggedEmpCd, @Authority); " &
                             " insert into mm_AnnualAndDay_RB_Targets_for_PHL (finyear, whloraxlorset, nature, changedby, authority) " &
                             " values (@finyear, 'A', '', @loggedEmpCd, @Authority) " &
                             " insert into mm_AnnualAndDay_RB_Targets_for_PHL (finyear, whloraxlorset, nature, changedby, authority) " &
                             " values (@finyear, 'S', '', @loggedEmpCd, @Authority)"
            sqlcmd.Parameters.Add("@finYear", SqlDbType.VarChar, 7).Value = finYear
            sqlcmd.Parameters.Add("@loggedEmpCd", SqlDbType.VarChar, 6).Value = LoggedInBy
            sqlcmd.Parameters.Add("@authority", SqlDbType.VarChar, 6).Value = Authority
            Dim Done As Boolean
            Try
                sqlcmd.Connection.Open()
                If sqlcmd.ExecuteNonQuery() = 1 Then Done = True
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If sqlcmd.Connection.State = ConnectionState.Open Then
                    sqlcmd.Connection.Close()
                End If
                sqlcmd.Dispose()
                sqlcmd = Nothing
            End Try
            Return Done
        End Function
        Public Function RBInsertMonthTargets(ByVal finYear As String) As Boolean
            Dim sqlcmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim Done As Boolean
            sqlcmd.CommandText = "declare @finyear varchar(7)  " &
              " set @finyear = '" & finYear & "'" &
              " declare @Quarter_number int,  @month_number int " &
              " set @month_Number = 1 " &
              " while @Month_number < 13 " &
              "            begin " &
              "     if  @month_number between 4 and 6 " &
              "                begin " &
              "            set @quarter_number = 1 " &
              "                End " &
              "      else if  @month_number between 7 and 9 " &
              "                 begin " &
              "             set @quarter_number = 2 " &
              "                End " &
              "       else if @month_number between 10 and 12 " &
              "                 begin " &
              "            set @quarter_number = 3 " &
              "                End " &
              "             Else " &
              "                 begin " &
              "            set @quarter_number = 4 " &
              "                 End " &
              " insert into mm_schedule_rwf_RB_plan " &
              " (  " &
              "                Remarks, wap_monthly_quantity, working_days, wta_control_number, Category, Quarter_number, month_number " &
              " ) values ( 'Cast Wheels Plan'  , 0  , 0  , left(@finYear,4) + ('0'+convert(varchar,@quarter_number)),'01', @Quarter_number, right('00'+convert(varchar,@month_number),2) )" &
              " insert into mm_schedule_rwf_RB_plan " &
              " ( " &
              "                Remarks, wap_monthly_quantity, working_days, wta_control_number, Category, Quarter_number, month_number " &
              " ) values ( 'Good Wheels Plan'  , 0  , 0  , left(@finYear,4) + ('0'+convert(varchar,@quarter_number)),'01', @Quarter_number, right('00'+convert(varchar,@month_number),2) )" &
              " insert into mm_schedule_rwf_RB_plan " &
              " ( " &
              "                Remarks, wap_monthly_quantity, working_days, wta_control_number, Category, Quarter_number, month_number " &
              " ) values ( ''  , 0  , 0  , left(@finYear,4) + ('0'+convert(varchar,@quarter_number)),'02', @Quarter_number, right('00'+convert(varchar,@month_number),2) )" &
              " insert into mm_schedule_rwf_RB_plan " &
              " ( " &
              "                Remarks, wap_monthly_quantity, working_days, wta_control_number, Category, Quarter_number, month_number " &
              " ) values ( ''  , 0  , 0  , left(@finYear,4) + ('0'+convert(varchar,@quarter_number)) ,'03', @Quarter_number, right('00'+convert(varchar,@month_number),2) )" &
              " set @month_Number = @month_Number + 1  " &
              " End"
            Try
                sqlcmd.Connection.Open()
                If sqlcmd.ExecuteNonQuery() = 1 Then Done = True
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If sqlcmd.Connection.State = ConnectionState.Open Then
                    sqlcmd.Connection.Close()
                End If
                sqlcmd.Dispose()
                sqlcmd = Nothing
            End Try
            Return Done
        End Function
        Public Function RBUpdateMMSAuthorisations(ByVal Group As String, ByVal UserID As String) As Boolean
            Dim sqlcmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            sqlcmd.CommandText = "update  mm_MMS_Authorisations set compliedByLogin = @compliedByLogin, CompliedByEmpCode = @CompliedByEmpCode, CompliedDateTime = @CompliedDateTime " &
                                   " where AuthorisedActivity = @Activity " &
                                   " and AuthorisorLogin =  @AuthorisorLogin  and compliedDateTime = '1900-1-1'"
            sqlcmd.Parameters.Add("@Activity", SqlDbType.VarChar, 50).Value = "Rly Board Targets"
            sqlcmd.Parameters.Add("@AuthorisorLogin", SqlDbType.VarChar, 50).Value = "SSPCO"
            sqlcmd.Parameters.Add("@compliedByLogin", SqlDbType.VarChar, 50).Value = Group
            sqlcmd.Parameters.Add("@CompliedByEmpCode", SqlDbType.VarChar, 6).Value = UserID
            sqlcmd.Parameters.Add("@CompliedDateTime", SqlDbType.DateTime, 8).Value = Now
            Dim Done As Boolean
            Try
                sqlcmd.Connection.Open()
                If sqlcmd.ExecuteNonQuery() = 1 Then Done = True
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If sqlcmd.Connection.State = ConnectionState.Open Then
                    sqlcmd.Connection.Close()
                End If
                sqlcmd.Dispose()
                sqlcmd = Nothing
            End Try
            Return Done
        End Function
        Public Function RBUpdateYearTargets(ByVal PlannedWDays As String, ByVal NewQty As String, ByVal finYear As String, ByVal Product As String) As Boolean
            Dim sqlcmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            sqlcmd.Parameters.Add("@PlannedWorkingDays", SqlDbType.SmallInt, 2).Value = CShort(PlannedWDays)
            sqlcmd.Parameters.Add("@AnnualTarget", SqlDbType.BigInt, 8).Value = CLng(NewQty)
            Dim sqlstr As New System.Text.StringBuilder()
            Dim i As Integer
            If PlannedWDays <> "" Then
                sqlstr.Append(", plannedWorkingDays = @plannedWorkingDays")
            End If
            sqlstr.Append(", AnnualTarget = @AnnualTarget")
            sqlstr.Append(" where finyear = '" & finYear & "'")
            If Product.ToLower.Substring(0, 2) = "01" Then
                sqlstr.Append(" and WhlOrAxlOrSet = 'W'")
                If Product.EndsWith("C") = True Then
                    sqlstr.Append(" and nature = 'cast'")
                Else
                    sqlstr.Append(" and nature <> 'cast'")
                End If
            ElseIf Product.ToLower = "02" Then
                sqlstr.Append(" and WhlOrAxlOrSet = 'A'")
            Else
                sqlstr.Append(" and WhlOrAxlOrSet = 'S'")
            End If
            Dim sqlstring As String = "update mm_AnnualAndDay_RB_Targets_for_PHL set "
            Dim len As Integer = sqlstr.ToString.Length
            sqlstring &= sqlstr.ToString.Substring(2, len - 2)
            sqlcmd.CommandText = sqlstring.ToString
            Dim Done As Boolean
            Try
                sqlcmd.Connection.Open()
                If sqlcmd.ExecuteNonQuery() = 1 Then Done = True
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If sqlcmd.Connection.State = ConnectionState.Open Then
                    sqlcmd.Connection.Close()
                End If
                sqlcmd.Dispose()
                sqlcmd = Nothing
            End Try
            Return Done
        End Function
        Public Function RBupdateMonthTarget(ByVal Product As String, ByVal finYear As String, ByVal PlannedWDays As String, ByVal NewQty As String, ByVal FromValue As String, ByVal ToValue As String, ByVal FromValueText As DataTable) As Boolean
            Dim sqlstr As String
            If Left(Product, 2) = "01" Then
                If Product.ToUpper.EndsWith("C") = True Then
                    If PlannedWDays <> "" Then
                        sqlstr = "Update mm_schedule_rwf_RB_plan set working_days = @working_days , " &
                            " wap_monthly_quantity = @wap_monthly_quantity where category = '" & Left(Product, 2) & "' " &
                            " and wta_control_number like '" & Left(finYear, 4) & "%' and remarks like 'cast%' and month_number = @Month_Number "
                    Else
                        sqlstr = "Update mm_schedule_rwf_RB_plan set wap_monthly_quantity = @wap_monthly_quantity " &
                            " where category = '" & Left(Product, 2) & "' and wta_control_number like '" & Left(finYear, 4) & "%' " &
                            " and remarks like 'cast%' and month_number = @Month_Number "
                    End If
                Else
                    If PlannedWDays <> "" Then
                        sqlstr = "Update mm_schedule_rwf_RB_plan set working_days = @working_days , wap_monthly_quantity = @wap_monthly_quantity " &
                        " where category = '" & Left(Product, 2) & "' and wta_control_number like '" & Left(finYear, 4) & "%'and remarks not like 'cast%' and month_number = @Month_Number "
                    Else
                        sqlstr = "Update mm_schedule_rwf_RB_plan set wap_monthly_quantity = @wap_monthly_quantity " &
                        " where category = '" & Left(Product, 2) & "' and wta_control_number like '" & Left(finYear, 4) & "%'and remarks not like 'cast%' and month_number = @Month_Number "
                    End If
                End If
            Else
                If PlannedWDays <> "" Then
                    sqlstr = "Update mm_schedule_rwf_RB_plan set working_days = @working_days , wap_monthly_quantity = @wap_monthly_quantity where category = '" & Left(Product, 2) & "' and wta_control_number like '" & Left(finYear, 4) & "%' and month_number = @Month_Number "
                Else
                    sqlstr = "Update mm_schedule_rwf_RB_plan set wap_monthly_quantity = @wap_monthly_quantity where category = '" & Left(Product, 2) & "' and wta_control_number like '" & Left(finYear, 4) & "%' and month_number = @Month_Number "
                End If
            End If
            Dim sqlcmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            sqlcmd.Parameters.Add("@working_days", SqlDbType.Int, 4).Direction = ParameterDirection.Input
            sqlcmd.Parameters.Add("@wap_monthly_quantity", SqlDbType.BigInt, 8).Direction = ParameterDirection.Input
            sqlcmd.Parameters.Add("@Month_number", SqlDbType.VarChar, 2).Direction = ParameterDirection.Input
            If PlannedWDays <> "" Then
                sqlcmd.Parameters("@working_days").Value = CInt(PlannedWDays)
            Else
                sqlcmd.Parameters("@working_days").Value = 0
            End If

            If NewQty <> "" Then
                sqlcmd.Parameters("@wap_monthly_quantity").Value = CLng(NewQty)
            Else
                sqlcmd.Parameters("@wap_monthly_quantity").Value = 0
            End If
            sqlcmd.Connection.Open()
            Dim Done As Boolean
            Dim i As Integer
            For i = Val(FromValue) - 1 To Val(ToValue) - 1
                Done = False
                sqlcmd.Parameters("@Month_number").Value = Left(FromValueText.Rows(i)(0), 2)
                Try
                    If sqlstr <> "" Then
                        sqlcmd.CommandText = sqlstr
                        If sqlcmd.ExecuteNonQuery() > 0 Then Done = True
                    End If
                    If Done Then
                        Done = False
                    Else
                        Throw New Exception("InValid Saving")
                    End If
                    sqlcmd.CommandText = sqlstr
                    If sqlcmd.ExecuteNonQuery() = 1 Then Done = True
                Catch exp As Exception
                    Throw New Exception("InValid Saving")
                End Try
                If Done = False Then Exit Function
            Next
            Return Done
        End Function
        Public Function RBUpdateDayTargets(ByVal FromValue As String, ByVal ToValue As String, ByVal NewQty As String, ByVal finYear As String, ByVal Product As String) As Boolean
            Dim sqlcmd As New SqlClient.SqlCommand()
            sqlcmd.Connection = rwfGen.Connection.ConObj
            sqlcmd.Parameters.Add("@DayTgtInApr", SqlDbType.Int, 4).Value = CLng(NewQty)
            sqlcmd.Parameters.Add("@DayTgtInMay", SqlDbType.Int, 4).Value = CLng(NewQty)
            sqlcmd.Parameters.Add("@DayTgtInJun", SqlDbType.Int, 4).Value = CLng(NewQty)
            sqlcmd.Parameters.Add("@DayTgtInJul", SqlDbType.Int, 4).Value = CLng(NewQty)
            sqlcmd.Parameters.Add("@DayTgtInAug", SqlDbType.Int, 4).Value = CLng(NewQty)
            sqlcmd.Parameters.Add("@DayTgtInSep", SqlDbType.Int, 4).Value = CLng(NewQty)
            sqlcmd.Parameters.Add("@DayTgtInOct", SqlDbType.Int, 4).Value = CLng(NewQty)
            sqlcmd.Parameters.Add("@DayTgtInNov", SqlDbType.Int, 4).Value = CLng(NewQty)
            sqlcmd.Parameters.Add("@DayTgtInDec", SqlDbType.Int, 4).Value = CLng(NewQty)
            sqlcmd.Parameters.Add("@DayTgtInJan", SqlDbType.Int, 4).Value = CLng(NewQty)
            sqlcmd.Parameters.Add("@DayTgtInFeb", SqlDbType.Int, 4).Value = CLng(NewQty)
            sqlcmd.Parameters.Add("@DayTgtInMar", SqlDbType.Int, 4).Value = CLng(NewQty)
            Dim sqlstr As New System.Text.StringBuilder()
            Dim i As Integer
            For i = CInt(FromValue) To CInt(ToValue)
                If i = 10 Then
                    sqlstr.Append(", DayTgtInJan = @DayTgtInJan")
                End If
                If i = 11 Then
                    sqlstr.Append(", DayTgtInFeb = @DayTgtInFeb")
                End If
                If i = 12 Then
                    sqlstr.Append(", DayTgtInMar = @DayTgtInMar")
                End If
                If i = 1 Then
                    sqlstr.Append(", DayTgtInApr = @DayTgtInApr")
                End If
                If i = 2 Then
                    sqlstr.Append(", DayTgtInMay = @DayTgtInMay")
                End If
                If i = 3 Then
                    sqlstr.Append(", DayTgtInJun = @DayTgtInJun")
                End If
                If i = 4 Then
                    sqlstr.Append(", DayTgtInJul = @DayTgtInJul")
                End If
                If i = 5 Then
                    sqlstr.Append(", DayTgtInAug = @DayTgtInAug")
                End If
                If i = 6 Then
                    sqlstr.Append(", DayTgtInSep = @DayTgtInSep")
                End If
                If i = 7 Then
                    sqlstr.Append(", DayTgtInOct = @DayTgtInOct")
                End If
                If i = 8 Then
                    sqlstr.Append(", DayTgtInNov = @DayTgtInNov")
                End If
                If i = 9 Then
                    sqlstr.Append(", DayTgtInDec = @DayTgtInDec")
                End If
            Next
            sqlstr.Append(" where finyear = '" & finYear & "'")
            If Product.ToLower.Substring(0, 2) = "01" Then
                sqlstr.Append(" and WhlOrAxlOrSet = 'W'")
                If Product.EndsWith("C") = True Then
                    sqlstr.Append(" and nature = 'cast'")
                Else
                    sqlstr.Append(" and nature <> 'cast'")
                End If
            ElseIf Product.ToLower = "02" Then
                sqlstr.Append(" and WhlOrAxlOrSet = 'A'")
            Else
                sqlstr.Append(" and WhlOrAxlOrSet = 'S'")
            End If
            Dim sqlstring As String = "update mm_AnnualAndDay_RB_Targets_for_PHL set "
            Dim len As Integer = sqlstr.ToString.Length
            sqlstring &= sqlstr.ToString.Substring(2, len - 2)
            sqlcmd.CommandText = sqlstring.ToString
            Dim Done As Boolean
            Try
                sqlcmd.Connection.Open()
                If sqlcmd.ExecuteNonQuery() = 1 Then Done = True
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If sqlcmd.Connection.State = ConnectionState.Open Then
                    sqlcmd.Connection.Close()
                End If
                sqlcmd.Dispose()
                sqlcmd = Nothing
            End Try
            Return Done
        End Function
        Public Function CopyBOM(ByVal SourceProduct As String, ByVal DestProduct As String) As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim blnDone As Boolean
            Try
                cmd.Connection.Open()
                cmd.CommandText = "mm_sp_CopyBOM"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@SourceProduct", SqlDbType.VarChar, 50).Value = SourceProduct
                cmd.Parameters.Add("@DestProduct", SqlDbType.VarChar, 50).Value = DestProduct
                If cmd.ExecuteNonQuery() > 0 Then blnDone = True
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
            Return blnDone
        End Function
        Public Function UpdateBOM(ByVal shop_code As String, ByVal pl_number As String, ByVal quantity As Double, ByVal maximum_rmr_quantity As Double, ByVal EmployeeCode As String, ByVal Shop As String) As Boolean
            Dim cmd As SqlClient.SqlCommand
            cmd = rwfGen.Connection.CmdObj
            cmd.CommandText = "SELECT @Cnt = count(*) FROM mm_customer_consignee where code = @Consignee"
            Dim blnDone As Boolean
            Try

                cmd.CommandText = "update  mm_MMS_Authorisations set compliedByLogin = @compliedByLogin , " &
                    " CompliedByEmpCode = @CompliedByEmpCode, CompliedDateTime = @CompliedDateTime " &
                    " where AuthorisedActivity = @Activity " &
                    " and AuthorisorLogin =  @AuthorisorLogin  and compliedDateTime = '1900-1-1'"

                cmd.Parameters.Add("@Activity", SqlDbType.VarChar, 50).Value = "Bill of Material - Wheel Shop - " & Shop.Trim
                cmd.Parameters.Add("@AuthorisorLogin", SqlDbType.VarChar, 50).Value = "SSPCO"
                cmd.Parameters.Add("@compliedByLogin", SqlDbType.VarChar, 50).Value = "PCOPCO"
                cmd.Parameters.Add("@CompliedByEmpCode", SqlDbType.VarChar, 6).Value = EmployeeCode.Trim
                cmd.Parameters.Add("@CompliedDateTime", SqlDbType.DateTime, 8).Value = Now

                cmd.Parameters.Add("@shop_code", SqlDbType.VarChar, 2).Value = shop_code
                cmd.Parameters.Add("@pl_number", SqlDbType.VarChar, 8).Value = pl_number
                cmd.Parameters.Add("@quantity", SqlDbType.Decimal, 18, 6).Value = quantity
                cmd.Parameters.Add("@maximum_rmr_quantity", SqlDbType.Decimal, 10, 3).Value = maximum_rmr_quantity
                cmd.Connection.Open()
                cmd.ExecuteNonQuery()
                cmd.CommandText = "insert into mm_bill_of_material_audit " &
                    " select * , @CompliedDateTime , @CompliedByEmpCode from mm_bill_of_material" &
                    " where shop_code = @shop_code and pl_number = @pl_number "
                If cmd.ExecuteNonQuery() = 1 Then
                    cmd.CommandText = "update mm_bill_of_material " &
                        " set quantity = @quantity , maximum_rmr_quantity = @maximum_rmr_quantity " &
                        " where shop_code = @shop_code and pl_number = @pl_number "
                    If cmd.ExecuteNonQuery() = 1 Then blnDone = True
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                cmd.Dispose()
                cmd = Nothing
            End Try
            Return blnDone
        End Function
        Public Function MeltingBOM(ByVal MeltBOM As DataTable, ByVal EmployeeCode As String, ByVal Group As String) As Boolean
            Dim sqlcmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim sGetLastNo, sGetRowsCountToInsert, sInsertAuditing, sDeleteFromLive, sInsertFreshBOM, sUpdateSaveDateTimeInAudit, sPostCompliance As String

            sGetLastNo = "select @LastSlNo = max(sl_no) from mm_bill_of_material_audit"

            sInsertAuditing = "insert into mm_bill_of_material_audit (" &
                                      " product_code, route_code, route_sequence, shop_code, pl_number, quantity, alternative_pl_number, " &
                                      " effective_date, status, product_tool_flag, product_stage, maximum_rmr_quantity," &
                                      " prod_pltype, pl_qty_per_heat, deviation, accumulator, min_issue_quantity) " &
                                      " select product_code, route_code, route_sequence, shop_code, pl_number, quantity, alternative_pl_number," &
                                      " effective_date, status, product_tool_flag, product_stage, maximum_rmr_quantity," &
                                      " prod_pltype, pl_qty_per_heat, deviation, accumulator, min_issue_quantity " &
                                      "  from mm_bill_of_material where shop_code = @Shop_Code "

            sDeleteFromLive = "delete mm_bill_of_material where shop_code = @Shop_code "


            sInsertFreshBOM = "insert into mm_bill_of_material ( product_code, route_code, route_sequence, shop_code, pl_number," &
                                          " quantity, effective_date, status, prod_pltype,  deviation, accumulator, min_issue_quantity)   values  ( " &
                                          " @product_code, @route_code, @route_sequence, @shop_code, " &
                                          " @pl_number, @quantity, @effective_date, @status, @prod_pltype,  @deviation,  @accumulator, @min_issue_quantity) "
            sUpdateSaveDateTimeInAudit = "update mm_bill_of_material_audit set savedDateTime = @SavedDateTime, SavedBy = @SavedBy where sl_no between @fromNo and @ToNo "

            sPostCompliance = "update  mm_MMS_Authorisations set compliedByLogin = @compliedByLogin, CompliedByEmpCode = @CompliedByEmpCode, CompliedDateTime = @CompliedDateTime " &
                                          " where AuthorisedActivity = @Activity " &
                                          " and AuthorisorLogin =  @AuthorisorLogin  and compliedDateTime = '1900-1-1'"


            sqlcmd.Parameters.Add("@Activity", SqlDbType.VarChar, 50).Value = "Bill of Material - Wheel Shop - Melting" ' donot change value of this statement

            sqlcmd.Parameters.Add("@AuthorisorLogin", SqlDbType.VarChar, 50).Value = "SSPCO"
            sqlcmd.Parameters.Add("@compliedByLogin", SqlDbType.VarChar, 50).Value = Group
            sqlcmd.Parameters.Add("@CompliedByEmpCode", SqlDbType.VarChar, 6).Value = Left(CStr(EmployeeCode), 6)
            sqlcmd.Parameters.Add("@CompliedDateTime", SqlDbType.DateTime, 8).Value = Now
            sqlcmd.Parameters.Add("@Shop_Code", SqlDbType.VarChar, 8).Value = "E1"
            sqlcmd.Parameters.Add("@SavedDateTime", SqlDbType.SmallDateTime, 8).Value = Now()
            sqlcmd.Parameters.Add("@SavedBy", SqlDbType.VarChar, 6).Value = EmployeeCode
            sqlcmd.Parameters.Add("@product_code", SqlDbType.VarChar, 6).Value = "120120"
            sqlcmd.Parameters.Add("@route_code ", SqlDbType.VarChar, 8).Value = "01"
            sqlcmd.Parameters.Add("@route_sequence ", SqlDbType.VarChar, 8).Value = "010"
            sqlcmd.Parameters.Add("@effective_date", SqlDbType.SmallDateTime, 8).Value = Today.Date
            sqlcmd.Parameters.Add("@status", SqlDbType.VarChar, 1).Value = "Y"
            sqlcmd.Parameters.Add("@prod_pltype", SqlDbType.VarChar, 1).Value = "H"
            sqlcmd.Parameters.Add("@deviation", SqlDbType.Int, 4).Value = 500
            sqlcmd.Parameters.Add("@min_issue_quantity", SqlDbType.Int, 4).Value = 1

            sqlcmd.Parameters.Add("@LastSlNo", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output

            Dim Done As Boolean
            Try
                sqlcmd.Connection.Open()
                sqlcmd.Transaction = sqlcmd.Connection.BeginTransaction
                ' Get last sl_no from audit file for BOM and assign it to input param of update command
                sqlcmd.CommandText = sGetLastNo
                sqlcmd.ExecuteScalar()
                sqlcmd.Parameters.Add("@FromNo", SqlDbType.BigInt, 8).Direction = ParameterDirection.Input
                sqlcmd.Parameters("@LastSlNo").Value = IIf(IsDBNull(sqlcmd.Parameters("@LastSlNo").Value), 0, sqlcmd.Parameters("@LastSlNo").Value)
                sqlcmd.Parameters("@LastSlNo").Value += 1
                sqlcmd.Parameters("@FromNo").Value = sqlcmd.Parameters("@LastSlNo").Value
                ' insert existing BOM to Audit file.
                sqlcmd.CommandText = sInsertAuditing
                If sqlcmd.ExecuteNonQuery() = 0 Then Throw New Exception("InValid TimeInAudit !")
                Done = True
                ' Get last sl_no from audit file for BOM added and assign it to input param of update command 
                sqlcmd.CommandText = sGetLastNo
                sqlcmd.ExecuteScalar()
                sqlcmd.Parameters.Add("@ToNo", SqlDbType.BigInt, 8).Direction = ParameterDirection.Input
                sqlcmd.Parameters("@LastSlNo").Value = IIf(IsDBNull(sqlcmd.Parameters("@LastSlNo").Value), 0, sqlcmd.Parameters("@LastSlNo").Value)
                sqlcmd.Parameters("@ToNo").Value = sqlcmd.Parameters("@LastSlNo").Value

                ' Update save date time and employee code to audit file
                sqlcmd.CommandText = sUpdateSaveDateTimeInAudit
                If Done Then Done = False
                If sqlcmd.ExecuteNonQuery() = 0 Then Throw New Exception("InValid TimeInAudit !")
                Done = True
                ' Delete from Existing BOM
                sqlcmd.CommandText = sDeleteFromLive
                If Done Then Done = False
                If sqlcmd.ExecuteNonQuery() = 0 Then Throw New Exception("InValid DeleteFromLive !")
                Done = True
                ' Add data from Memory table to BOM
                sqlcmd.Parameters.Add("@pl_number", SqlDbType.VarChar, 8).Direction = ParameterDirection.Input
                sqlcmd.Parameters.Add("@quantity", SqlDbType.Float, 8).Direction = ParameterDirection.Input
                sqlcmd.Parameters.Add("@accumulator", SqlDbType.Float, 8).Direction = ParameterDirection.Input
                Dim row As DataRow
                For Each row In MeltBOM.Rows
                    Done = False
                    sqlcmd.Parameters("@pl_number").Value = row("PL_Number")
                    sqlcmd.Parameters("@quantity").Value = row("Qty")
                    sqlcmd.Parameters("@accumulator").Value = GetAccumulatorMelt(row("PL_Number"), MeltBOM)
                    sqlcmd.CommandText = sInsertFreshBOM
                    If sqlcmd.ExecuteNonQuery() = 0 Then Throw New Exception("InValid Memory table !")
                    Done = True
                Next
                ' Compliance
                sqlcmd.CommandText = sPostCompliance
                If Done Then Done = False
                If sqlcmd.ExecuteNonQuery() = 0 Then Throw New Exception("InValid Compliance !")
                Done = True
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If Done Then
                    sqlcmd.Transaction.Commit()
                Else
                    sqlcmd.Transaction.Rollback()
                End If
                If sqlcmd.Connection.State = ConnectionState.Open Then
                    sqlcmd.Connection.Close()
                End If
                sqlcmd.Dispose()
                sqlcmd = Nothing
            End Try
            Return Done
        End Function
        Private Function GetAccumulatorMelt(ByVal sPLNumber As String, ByVal MyTable As DataTable) As Decimal
            Dim dv1 As New DataView()
            dv1 = MyTable.DefaultView
            dv1.RowFilter = "PL_Number = '" & sPLNumber & "'"
            Dim pl As String = dv1.Item(0)("PL_Number")
            Dim accum As Decimal = dv1.Item(0)("Accumulator")
            GetAccumulatorMelt = accum
        End Function
        Public Function MouldingBOM(ByVal MouldBOM As DataTable, ByVal Group As String, ByVal EmployeeCode As String) As Boolean
            Dim sqlcmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim sGetLastNo, sPostCompliance, sInsertAuditing, sDeleteFromLive, sInsertFreshBOM, sUpdateSaveDateTimeInAudit As String

            sGetLastNo = "select @LastSlNo = max(sl_no) from mm_bill_of_material_audit"
            sInsertAuditing = "insert into mm_bill_of_material_audit (" &
                           " product_code, route_code, route_sequence, shop_code, pl_number, quantity, alternative_pl_number, " &
                           " effective_date, status, product_tool_flag, product_stage, maximum_rmr_quantity," &
                           " prod_pltype, pl_qty_per_heat, deviation, accumulator, min_issue_quantity) " &
                           " select product_code, route_code, route_sequence, shop_code, pl_number, quantity, alternative_pl_number," &
                           " effective_date, status, product_tool_flag, product_stage, maximum_rmr_quantity," &
                           " prod_pltype, pl_qty_per_heat, deviation, accumulator, min_issue_quantity " &
                           "  from mm_bill_of_material where shop_code = @Shop_Code "
            sDeleteFromLive = "delete mm_bill_of_material where shop_code = @Shop_code "


            sInsertFreshBOM = "insert into mm_bill_of_material ( product_code, route_code, route_sequence, shop_code, pl_number," &
                                          " quantity, effective_date, status, prod_pltype,  deviation, accumulator, min_issue_quantity)   values  ( " &
                                          " @product_code, @route_code, @route_sequence, @shop_code, " &
                                          " @pl_number, @quantity, @effective_date, @status, @prod_pltype,  @deviation,  @accumulator, @min_issue_quantity) "
            sUpdateSaveDateTimeInAudit = "update mm_bill_of_material_audit set savedDateTime = @SavedDateTime, SavedBy = @SavedBy where sl_no between @fromNo and @ToNo "

            sPostCompliance = "update  mm_MMS_Authorisations set compliedByLogin = @compliedByLogin, CompliedByEmpCode = @CompliedByEmpCode, CompliedDateTime = @CompliedDateTime " &
                                                " where AuthorisedActivity = @Activity " &
                                                " and AuthorisorLogin =  @AuthorisorLogin  and compliedDateTime = '1900-1-1'"

            sqlcmd.Parameters.Add("@Activity", SqlDbType.VarChar, 50).Value = "Bill of Material - Wheel Shop - Moulding" ' donot change value of this statement
            sqlcmd.Parameters.Add("@AuthorisorLogin", SqlDbType.VarChar, 50).Value = "SSPCO"
            sqlcmd.Parameters.Add("@compliedByLogin", SqlDbType.VarChar, 50).Value = Group
            sqlcmd.Parameters.Add("@CompliedByEmpCode", SqlDbType.VarChar, 6).Value = Left(CStr(EmployeeCode), 6)
            sqlcmd.Parameters.Add("@CompliedDateTime", SqlDbType.DateTime, 8).Value = Now
            sqlcmd.Parameters.Add("@Shop_Code", SqlDbType.VarChar, 8).Value = "E2"
            sqlcmd.Parameters.Add("@SavedDateTime", SqlDbType.SmallDateTime, 8).Value = Now()
            sqlcmd.Parameters.Add("@SavedBy", SqlDbType.VarChar, 6).Value = EmployeeCode
            sqlcmd.Parameters.Add("@product_code", SqlDbType.VarChar, 6).Value = "120120"
            sqlcmd.Parameters.Add("@route_code ", SqlDbType.VarChar, 8).Value = "01"
            sqlcmd.Parameters.Add("@route_sequence ", SqlDbType.VarChar, 8).Value = "010"
            sqlcmd.Parameters.Add("@effective_date", SqlDbType.SmallDateTime, 4).Value = Today.Date
            sqlcmd.Parameters.Add("@status", SqlDbType.VarChar, 1).Value = "Y"
            sqlcmd.Parameters.Add("@prod_pltype", SqlDbType.VarChar, 1).Value = "H"
            sqlcmd.Parameters.Add("@deviation", SqlDbType.Int, 4).Value = 500
            sqlcmd.Parameters.Add("@min_issue_quantity", SqlDbType.Int, 4).Value = 1


            sqlcmd.Parameters.Add("@LastSlNo", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
            Dim Done As Boolean
            Try
                sqlcmd.Connection.Open()
                sqlcmd.Transaction = sqlcmd.Connection.BeginTransaction
                ' Get last sl_no from audit file for BOM and assign it to input param of update command
                sqlcmd.CommandText = sGetLastNo
                sqlcmd.ExecuteScalar()
                sqlcmd.Parameters("@LastSlNo").Value = IIf(IsDBNull(sqlcmd.Parameters("@LastSlNo").Value), 0, sqlcmd.Parameters("@LastSlNo").Value)
                sqlcmd.Parameters("@LastSlNo").Value += 1
                sqlcmd.Parameters.Add("@FromNo", SqlDbType.BigInt, 8).Value = sqlcmd.Parameters("@LastSlNo").Value

                ' insert existing BOM to Audit file.
                sqlcmd.CommandText = sInsertAuditing
                If sqlcmd.ExecuteNonQuery() = 0 Then Throw New Exception("InValid InsertAuditing !")
                Done = True
                ' Get last sl_no from audit file for BOM added and assign it to input param of update command 
                sqlcmd.CommandText = sGetLastNo
                sqlcmd.ExecuteScalar()
                sqlcmd.Parameters("@LastSlNo").Value = IIf(IsDBNull(sqlcmd.Parameters("@LastSlNo").Value), 0, sqlcmd.Parameters("@LastSlNo").Value)
                sqlcmd.Parameters.Add("@ToNo", SqlDbType.BigInt, 8).Value = sqlcmd.Parameters("@LastSlNo").Value

                ' Update save date time and employee code to audit file
                If Done Then Done = False
                sqlcmd.CommandText = sUpdateSaveDateTimeInAudit
                sqlcmd.ExecuteNonQuery()
                If sqlcmd.ExecuteNonQuery() = 0 Then Throw New Exception("InValid TimeInAudit !")
                Done = True
                ' Delete from Existing BOM
                If Done Then Done = False
                sqlcmd.CommandText = sDeleteFromLive
                If sqlcmd.ExecuteNonQuery() = 0 Then Throw New Exception("InValid DeleteFromLive !")
                Done = True

                ' Add data from Memory table to BOM
                sqlcmd.Parameters.Add("@pl_number", SqlDbType.VarChar, 8).Direction = ParameterDirection.Input
                sqlcmd.Parameters.Add("@quantity", SqlDbType.Float, 8).Direction = ParameterDirection.Input
                sqlcmd.Parameters.Add("@accumulator", SqlDbType.Float, 8).Direction = ParameterDirection.Input
                Dim row As DataRow
                For Each row In MouldBOM.Rows
                    Done = False
                    sqlcmd.Parameters("@pl_number").Value = row("PL_Number")
                    sqlcmd.Parameters("@quantity").Value = row("Qty")
                    sqlcmd.Parameters("@accumulator").Value = GetAccumulatorMould(row("PL_Number"), MouldBOM)
                    sqlcmd.CommandText = sInsertFreshBOM
                    If sqlcmd.ExecuteNonQuery() = 0 Then Throw New Exception("InValid Memory table !")
                    Done = True
                Next

                'Update Compliance
                If Done Then Done = False
                sqlcmd.CommandText = sPostCompliance
                If sqlcmd.ExecuteNonQuery() = 0 Then Throw New Exception("InValid MouldBOM !")
                Done = True
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If Done Then
                    sqlcmd.Transaction.Commit()
                Else
                    sqlcmd.Transaction.Rollback()
                End If
                If sqlcmd.Connection.State = ConnectionState.Open Then
                    sqlcmd.Connection.Close()
                End If
                sqlcmd.Dispose()
                sqlcmd = Nothing
            End Try
            Return Done
        End Function
        Private Function GetAccumulatorMould(ByVal sPLNumber As String, ByVal MouldBOM As DataTable) As Decimal
            Dim MyTable As New DataTable()
            MyTable = MouldBOM
            Dim dv1 As New DataView()
            dv1 = MyTable.DefaultView
            dv1.RowFilter = "PL_Number = '" & sPLNumber & "'"
            Dim pl As String = dv1.Item(0)("PL_Number")
            Dim accum As Decimal = dv1.Item(0)("Accumulator")
            GetAccumulatorMould = accum
        End Function
        Public Function WFPSBOM(ByVal CleaningBOM As DataTable, ByVal Group As String, ByVal UserID As String) As Boolean
            Dim Done As Boolean
            Dim sqlcmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim sGetLastNo, sPostCompliance, sInsertAuditing, sDeleteFromLive, sInsertFreshBOM, sUpdateSaveDateTimeInAudit As String

            sGetLastNo = "select @LastSlNo = max(sl_no) from mm_bill_of_material_audit"

            sInsertAuditing = "insert into mm_bill_of_material_audit (" &
                                      " product_code, route_code, route_sequence, shop_code, pl_number, quantity, alternative_pl_number, " &
                                      " effective_date, status, product_tool_flag, product_stage, maximum_rmr_quantity," &
                                      " prod_pltype, pl_qty_per_heat, deviation, accumulator, min_issue_quantity) " &
                                      " select product_code, route_code, route_sequence, shop_code, pl_number, quantity, alternative_pl_number," &
                                      " effective_date, status, product_tool_flag, product_stage, maximum_rmr_quantity," &
                                      " prod_pltype, pl_qty_per_heat, deviation, accumulator, min_issue_quantity " &
                                      "  from mm_bill_of_material where shop_code = @Shop_Code "

            sDeleteFromLive = "delete mm_bill_of_material where shop_code = @Shop_code "


            sInsertFreshBOM = "insert into mm_bill_of_material ( product_code, route_code, route_sequence, shop_code, pl_number," &
                                          " quantity, effective_date, status, prod_pltype,  deviation, accumulator, min_issue_quantity)   values  ( " &
                                          " @product_code, @route_code, @route_sequence, @shop_code, " &
                                          " @pl_number, @quantity, @effective_date, @status, @prod_pltype,  @deviation,  @accumulator, @min_issue_quantity) "
            sUpdateSaveDateTimeInAudit = "update mm_bill_of_material_audit set savedDateTime = @SavedDateTime, SavedBy = @SavedBy where sl_no between @fromNo and @ToNo "

            sPostCompliance = "update  mm_MMS_Authorisations set compliedByLogin = @compliedByLogin, CompliedByEmpCode = @CompliedByEmpCode, CompliedDateTime = @CompliedDateTime " &
                                               " where AuthorisedActivity = @Activity " &
                                               " and AuthorisorLogin =  @AuthorisorLogin  and compliedDateTime = '1900-1-1'"


            sqlcmd.Parameters.Add("@Activity", SqlDbType.VarChar, 50).Value = "Bill of Material - Wheel Shop - WFP Shop" ' donot change value of this statement
            sqlcmd.Parameters.Add("@AuthorisorLogin", SqlDbType.VarChar, 50).Value = "SSPCO"
            sqlcmd.Parameters.Add("@compliedByLogin", SqlDbType.VarChar, 50).Value = Group
            sqlcmd.Parameters.Add("@CompliedByEmpCode", SqlDbType.VarChar, 6).Value = Left(CStr(UserID), 6)
            sqlcmd.Parameters.Add("@CompliedDateTime", SqlDbType.DateTime, 8).Value = Now
            sqlcmd.Parameters.Add("@Shop_Code", SqlDbType.VarChar, 8).Value = "N1"
            sqlcmd.Parameters.Add("@SavedDateTime", SqlDbType.SmallDateTime, 8).Value = Now()
            sqlcmd.Parameters.Add("@SavedBy", SqlDbType.VarChar, 6).Value = UserID
            sqlcmd.Parameters.Add("@product_code", SqlDbType.VarChar, 6).Value = "120120"
            sqlcmd.Parameters.Add("@route_code ", SqlDbType.VarChar, 8).Value = "01"
            sqlcmd.Parameters.Add("@route_sequence ", SqlDbType.VarChar, 8).Value = "010"
            sqlcmd.Parameters.Add("@effective_date", SqlDbType.SmallDateTime, 8).Value = Today.Date
            sqlcmd.Parameters.Add("@status", SqlDbType.VarChar, 1).Value = "Y"
            sqlcmd.Parameters.Add("@prod_pltype", SqlDbType.VarChar, 1).Value = "H"
            sqlcmd.Parameters.Add("@deviation", SqlDbType.Int, 4).Value = 500
            sqlcmd.Parameters.Add("@min_issue_quantity", SqlDbType.Int, 4).Value = 1

            sqlcmd.Parameters.Add("@pl_number", SqlDbType.VarChar, 8).Direction = ParameterDirection.Input
            sqlcmd.Parameters.Add("@quantity", SqlDbType.Float, 8).Direction = ParameterDirection.Input
            sqlcmd.Parameters.Add("@accumulator", SqlDbType.Float, 8).Direction = ParameterDirection.Input
            sqlcmd.Parameters.Add("@FromNo", SqlDbType.BigInt, 8).Direction = ParameterDirection.Input
            sqlcmd.Parameters.Add("@ToNo", SqlDbType.BigInt, 8).Direction = ParameterDirection.Input
            sqlcmd.Parameters.Add("@LastSlNo", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
            Try
                sqlcmd.Connection.Open()
                sqlcmd.Transaction = sqlcmd.Connection.BeginTransaction
                ' Get last sl_no from audit file for BOM and assign it to input param of update command
                sqlcmd.CommandText = sGetLastNo
                sqlcmd.ExecuteScalar()
                sqlcmd.Parameters("@LastSlNo").Value = IIf(IsDBNull(sqlcmd.Parameters("@LastSlNo").Value), 0, sqlcmd.Parameters("@LastSlNo").Value)
                sqlcmd.Parameters("@LastSlNo").Value += 1
                sqlcmd.Parameters("@FromNo").Value = sqlcmd.Parameters("@LastSlNo").Value

                ' insert existing BOM to Audit file.
                sqlcmd.CommandText = sInsertAuditing
                If sqlcmd.ExecuteNonQuery() = 0 Then Throw New Exception("InValid InsertAuditing !")
                Done = True

                ' Get last sl_no from audit file for BOM added and assign it to input param of update command 
                sqlcmd.CommandText = sGetLastNo
                sqlcmd.ExecuteScalar()
                sqlcmd.Parameters("@LastSlNo").Value = IIf(IsDBNull(sqlcmd.Parameters("@LastSlNo").Value), 0, sqlcmd.Parameters("@LastSlNo").Value)
                sqlcmd.Parameters("@ToNo").Value = sqlcmd.Parameters("@LastSlNo").Value

                ' Update save date time and employee code to audit file
                If Done Then Done = False
                sqlcmd.CommandText = sUpdateSaveDateTimeInAudit
                sqlcmd.ExecuteNonQuery()
                If sqlcmd.ExecuteNonQuery() = 0 Then Throw New Exception("InValid TimeInAudit !")
                Done = True
                ' Delete from Existing BOM
                If Done Then Done = False
                sqlcmd.CommandText = sDeleteFromLive
                If sqlcmd.ExecuteNonQuery() = 0 Then Throw New Exception("InValid DeleteFromLive !")
                Done = True

                ' Add data from Memory table to BOM
                Dim row As DataRow
                For Each row In CleaningBOM.Rows
                    Done = False
                    sqlcmd.Parameters("@pl_number").Value = row("PL_Number")
                    sqlcmd.Parameters("@quantity").Value = row("Qty")
                    sqlcmd.Parameters("@accumulator").Value = GetAccumulatorWFPS(row("PL_Number"), CleaningBOM)
                    sqlcmd.CommandText = sInsertFreshBOM
                    If sqlcmd.ExecuteNonQuery() = 0 Then Throw New Exception("InValid Memory table !")
                    Done = True
                Next

                'Update Compliance
                If Done Then Done = False
                sqlcmd.CommandText = sPostCompliance
                sqlcmd.ExecuteNonQuery()
                If sqlcmd.ExecuteNonQuery() = 0 Then Throw New Exception("InValid CleaningBOM !")
                Done = True
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If Done Then
                    sqlcmd.Transaction.Commit()
                Else
                    sqlcmd.Transaction.Rollback()
                End If
                If sqlcmd.Connection.State = ConnectionState.Open Then
                    sqlcmd.Connection.Close()
                End If
                sqlcmd.Dispose()
                sqlcmd = Nothing
            End Try
            Return Done
        End Function
        Private Function GetAccumulatorWFPS(ByVal sPLNumber As String, ByVal CleaningBOM As DataTable) As Decimal
            Dim MyTable As New DataTable()
            MyTable = CleaningBOM
            Dim dv1 As New DataView()
            dv1 = MyTable.DefaultView
            dv1.RowFilter = "PL_Number = '" & sPLNumber & "'"
            Dim pl As String = dv1.Item(0)("PL_Number")
            Dim accum As Decimal = dv1.Item(0)("Accumulator")
            GetAccumulatorWFPS = accum
        End Function
        Public Function DeletePLFromBOM(ByVal UserID As String, ByVal LtrNo As String, ByVal PlNumber As String) As Boolean
            Dim cmd As SqlClient.SqlCommand
            cmd = rwfGen.Connection.CmdObj
            cmd.CommandText = "SELECT @Cnt = count(a.pl_number) FROM mm_bill_of_material a left outer join pm_itemmaster b on a.pl_number = b.pl_number  where b.short_description is null and a.pl_number = @DelPlNo"
            Dim blnDeleted As Boolean
            Try
                cmd.Parameters.Add("@DeletedDateTime", SqlDbType.DateTime, 8).Value = Now
                cmd.Parameters.Add("@DeletedBy", SqlDbType.VarChar, 6).Value = UserID
                cmd.Parameters.Add("@ltrNo", SqlDbType.VarChar, 25).Value = LtrNo
                cmd.Parameters.Add("@DelPlNo", SqlDbType.VarChar, 9).Value = PlNumber
                cmd.Parameters.Add("@Cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                cmd.CommandText = "select @Cnt = count(*) from mm_bill_of_material where pl_number = @DelPlNo "
                cmd.ExecuteScalar()
                If cmd.Parameters("@Cnt").Value > 0 Then
                    cmd.CommandText = "insert into mm_bill_of_material_deleted SELECT a.*, @DeletedDateTime, @DeletedBy , @ltrNo FROM mm_bill_of_material a left outer join pm_itemmaster b on a.pl_number = b.pl_number where a.pl_number = @DelPlNo "
                    If cmd.ExecuteNonQuery > 0 Then
                        cmd.CommandText = "delete b from mm_bill_of_material b where b.pl_number in ( select distinct c.pl_number from mm_bill_of_material_deleted c where c.pl_number = @DelPlNo )"
                        If cmd.ExecuteNonQuery > 0 Then
                            blnDeleted = True
                        Else
                            Throw New Exception("Delete Failed as no Record in Bill of Material for the PL Number")
                        End If
                    Else
                        Throw New Exception("Audit Record save error")
                    End If
                Else
                    Throw New Exception("Pl Number not found or not deleted by PMS")
                End If
            Catch exp As Exception
                Throw New Exception(" Delete Error : " & exp.Message)
            Finally
                If IsNothing(cmd) = False Then
                    If IsNothing(cmd.Transaction) = False Then
                        If blnDeleted Then
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
        End Function
        Public Function ConsigneeDetails(ByVal Consignee As String, ByVal ConsigneeName As String, ByVal address As String, ByVal city As String, ByVal pincode As String, ByVal passing_authority As String, ByVal customer_code As String, ByVal ShortName As String, ByVal consignee_gst As String) As Boolean
            Dim cmd As SqlClient.SqlCommand
            cmd = rwfGen.Connection.CmdObj
            cmd.CommandText = "SELECT @Cnt = count(*) FROM mm_customer_consignee where code = @Consignee"
            Dim blnDeleted As Boolean
            Try
                cmd.Parameters.Add("@Consignee", SqlDbType.VarChar, 10).Value = Consignee
                cmd.Parameters.Add("@ConsigneeName", SqlDbType.VarChar, 300).Value = ConsigneeName
                cmd.Parameters.Add("@address", SqlDbType.VarChar, 500).Value = address
                cmd.Parameters.Add("@city", SqlDbType.VarChar, 50).Value = city
                cmd.Parameters.Add("@pincode", SqlDbType.VarChar, 10).Value = pincode
                cmd.Parameters.Add("@passing_authority", SqlDbType.VarChar, 50).Value = passing_authority
                cmd.Parameters.Add("@customer_code", SqlDbType.VarChar, 10).Value = customer_code
                cmd.Parameters.Add("@ShortName", SqlDbType.VarChar, 50).Value = ShortName
                cmd.Parameters.Add("@consignee_gst", SqlDbType.VarChar, 50).Value = consignee_gst
                cmd.Parameters.Add("@Cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                cmd.ExecuteScalar()
                If cmd.Parameters("@Cnt").Value = 0 Then
                    cmd.CommandText = "insert into mm_customer_consignee ( code , name , address , city , pincode , passing_authority , customer_code , ShortName , consignee_gst ) " &
                        " values ( @Consignee , @ConsigneeName , @address , @city , @pincode , @passing_authority , @customer_code , @ShortName , @consignee_gst ) "
                Else
                    cmd.CommandText = "update mm_customer_consignee  set address = @address , city = @city , pincode = @pincode , " &
                       " passing_authority = @passing_authority , customer_code = @customer_code , ShortName =  @ShortName , consignee_gst = @consignee_gst " &
                       " where code = @Consignee and name = @ConsigneeName "
                End If
                If cmd.ExecuteNonQuery > 0 Then blnDeleted = True
            Catch exp As Exception
                Throw New Exception(" Delete Error : " & exp.Message)
            Finally
                If IsNothing(cmd) = False Then
                    If IsNothing(cmd.Transaction) = False Then
                        If blnDeleted Then
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
            Return blnDeleted
        End Function
        Public Function InsertPhlGenDate(ByRef cmd As SqlClient.SqlCommand, ByVal ReGen As Boolean, ByVal UserID As String, ByVal phlDate As Date) As Boolean
            Try
                cmd.Parameters.Add(New SqlClient.SqlParameter("@phl_date", SqlDbType.SmallDateTime, 8)).Value = CDate(phlDate)
                cmd.Parameters.Add(New SqlClient.SqlParameter("@phl_GenDate", SqlDbType.SmallDateTime, 8)).Value = Now
                cmd.Parameters.Add("@GenBy", SqlDbType.VarChar, 6).Value = UserID
                cmd.Parameters("@dt").Value = CDate(phlDate)
                cmd.Parameters("@upto").Value = CDate(phlDate)
                cmd.Parameters("@item").Value = ""
                cmd.Parameters("@cumfig").Value = 0
                If ReGen Then
                    cmd.CommandText = "delete mm_phl_generation where phl_date = @dt"
                    cmd.ExecuteNonQuery()
                End If
                cmd.CommandText = "Insert into mm_PHL_Generation (phl_date, phl_genDate, GenBy) values (@phl_date, @phl_GenDate, @GenBy)"
                If cmd.ExecuteNonQuery > 0 Then InsertPhlGenDate = True
            Catch exp As Exception
                InsertPhlGenDate = False
                Throw New Exception("Control Date Insertion Error : " & exp.Message)
            Finally
                ' donot close connection or transaction here
            End Try
        End Function
        Public Function SavePrdn(ByRef cmd As SqlClient.SqlCommand, ByVal dt As Date, ByVal Item As String, ByVal ItemVal As Integer, ByVal BlnInsert As Boolean, Optional ByVal YrlyFigs As Boolean = False) As Boolean
            If BlnInsert = False Then
                cmd.Parameters("@d").Value = 0
                If YrlyFigs Then
                    ' modified on 9-5-2008 after yvp pointed out years figs of 2007-08 not saved 
                    'cmd.CommandText = "update mm_mmyrprdn_dump set cumfig = @cumfig , upto = @upto where year(upto) = Year(@dt) and ltrim(rtrim(item)) = @item"
                    'cmd.CommandText = " select @d = count(*) from mm_mmyrprdn_dump where upto  between  wap.dbo.mm_fn_si_GetFinYearDate(@dt, 1) and  wap.dbo.mm_fn_si_GetFinYearDate(@dt, 0) and  item = @item "
                    'cmd.ExecuteScalar()
                    'If IIf(IsDBNull(cmd.Parameters("@d").Value), 0, cmd.Parameters("@d").Value) = 0 Then
                    '    cmd.CommandText = "insert into mm_mmyrprdn_dump (upto, cumfig, item) values(@upto, @cumfig, @Item)"
                    'Else
                    '    cmd.CommandText = "update mm_mmyrprdn_dump set cumfig = @cumfig , upto = @upto where upto  between  wap.dbo.mm_fn_si_GetFinYearDate(@dt, 1) and  wap.dbo.mm_fn_si_GetFinYearDate(@dt, 0) and  item = @item "
                    'End If
                    cmd.CommandText = "update mm_mmyrprdn_dump set cumfig = @cumfig , upto = @upto where  upto  between  wap.dbo.mm_fn_si_GetFinYearDate(@dt, 1) and  wap.dbo.mm_fn_si_GetFinYearDate(@dt, 0) and  item = @item "
                Else
                    'cmd.CommandText = " select @d = count(*) from mm_mmyrprdn_dump where year(upto) = Year(@dt) and month(upto) = Month(@dt) and ltrim(rtrim(item)) = @item"
                    'cmd.ExecuteScalar()
                    'If IIf(IsDBNull(cmd.Parameters("@d").Value), 0, cmd.Parameters("@d").Value) = 0 Then
                    '    cmd.CommandText = "insert into mm_mmyrprdn_dump (upto, cumfig, item) values(@upto, @cumfig, @Item)"
                    'Else
                    cmd.CommandText = "update mm_mmyrprdn_dump set cumfig = @cumfig , upto = @upto where year(upto) = Year(@dt) and month(upto) = Month(@dt) and ltrim(rtrim(item)) = @item"
                    'End If
                End If
            Else
                cmd.CommandText = "insert into mm_mmyrprdn_dump (upto, cumfig, item) values(@upto, @cumfig, @Item)"
            End If
            Try
                cmd.Parameters("@dt").Value = dt
                cmd.Parameters("@upto").Value = dt
                cmd.Parameters("@cumfig").Value = ItemVal
                cmd.Parameters("@Item").Value = Item
                If cmd.ExecuteNonQuery > 0 Then SavePrdn = True
            Catch exp As Exception
                SavePrdn = False
                Throw New Exception("Save Error : " & exp.Message)
            Finally
                ' donot close connection or transaction here
            End Try
        End Function
        Public Shared Function GetYearFigs(ByRef cmd As SqlClient.SqlCommand, ByVal dt As Date, ByRef intWheelYr As Integer, ByRef intAxleYr As Integer, ByRef intWheelSetYr As Integer)
            cmd.CommandText = "select @YrActWh = sum(case when ltrim(rtrim(item)) = 'MNACTWH' then cumfig else 0 end), @YrActws = sum(case when ltrim(rtrim(item)) = 'MNACTWS' then cumfig else 0 end), @YrActAx = sum(case when ltrim(rtrim(item)) = 'MNACTAX' then cumfig else 0 end) from mm_mmyrprdn_dump where upto between wap.dbo.mm_fn_si_GetFinYearDate(@dt, 1) and  @dt "
            cmd.CommandType = CommandType.Text
            cmd.Parameters("@dt").Value = dt
            cmd.Parameters.Add("@YrActWh", SqlDbType.Int, 4)
            cmd.Parameters.Add("@YrActAx", SqlDbType.Int, 4)
            cmd.Parameters.Add("@YrActWs", SqlDbType.Int, 4)
            cmd.Parameters("@YrActWh").Direction = ParameterDirection.Output
            cmd.Parameters("@YrActAx").Direction = ParameterDirection.Output
            cmd.Parameters("@YrActWs").Direction = ParameterDirection.Output
            Try
                cmd.ExecuteScalar()
                intWheelYr = IIf(IsDBNull(cmd.Parameters("@YrActWh").Value), 0, cmd.Parameters("@YrActWh").Value)
                intAxleYr = IIf(IsDBNull(cmd.Parameters("@YrActAx").Value), 0, cmd.Parameters("@YrActAx").Value)
                intWheelSetYr = IIf(IsDBNull(cmd.Parameters("@YrActWs").Value), 0, cmd.Parameters("@YrActWs").Value)
            Catch exp As Exception
                intWheelYr = 0
                intAxleYr = 0
                intWheelSetYr = 0
                Throw New Exception("Year Fig Save Error : " & exp.Message)
            Finally
                ' donot close connection or transaction here
            End Try
        End Function
        Public Shared Function MnHeatDataExists(ByRef cmd As SqlClient.SqlCommand, ByVal Dt As Date) As Boolean
            cmd.CommandText = "select count(*) from mm_mmyrprdn_dump where year(upto)=  Year(@dt) and month(upto)=month(@dt) and ltrim(rtrim(item)) in ('HEATSMM')"
            cmd.Parameters("@dt").Direction = ParameterDirection.Input
            cmd.Parameters("@dt").Value = Dt
            Dim blnExists As Boolean
            Try
                If cmd.ExecuteScalar > 0 Then
                    blnExists = True
                Else
                    blnExists = False
                End If
            Catch exp As Exception
                blnExists = False
                Throw New Exception("Fin Month Heats Exists Error : " & exp.Message)
            Finally
                ' donot close connection or transaction here
            End Try
            Return blnExists
        End Function
        Public Function GeneratePHLWithOutPink(ByVal dt As Date, ByVal txtDate As String, ByVal ReGen As Boolean, ByVal UserID As String) As Boolean
            Dim blnChecked As Boolean
            Dim MonthDays As Integer

            Dim intWheelMn, intAxleMn, intWheelSetMn As Integer
            Dim intWheelYr, intAxleYr, intWheelSetYr As Integer

            Dim intWheelDay, intAxleDay, intWheelSetDay As Integer
            Dim strHoliday As String
            Dim heatsmm, heatsyy As Long

            Dim AMonthHolidays, ATillDateHolidays As Integer
            Dim WMonthHolidays, WTillDateHolidays As Integer
            Dim AMonthWorkDays, ANextWorkDays As Integer
            Dim ATillDateWorkDays, WMonthWorkdays As Integer
            Dim WTillDateWorkDays, WNextWorkDays As Integer
            ATillDateHolidays = 0
            WTillDateHolidays = 0
            AMonthHolidays = 0
            WMonthHolidays = 0
            intWheelDay = 0
            intWheelMn = 0

            Try
                strHoliday = tables.GetNextDayHoliday(dt)
                MonthDays = dt.Date.DaysInMonth(Year(dt), Month(dt))
                Dim tblDt As DataTable
                Try
                    tblDt = tables.getShopWiseHolidaysTillPhlDt(dt)
                    If tblDt.Rows.Count > 0 Then
                        ATillDateHolidays = IIf(IsDBNull(tblDt.Rows(0)("AMATillDt")), 0, tblDt.Rows(0)("AMATillDt"))
                        WTillDateHolidays = IIf(IsDBNull(tblDt.Rows(0)("MEMETillDt")), 0, tblDt.Rows(0)("MEMETillDt"))
                        AMonthHolidays = IIf(IsDBNull(tblDt.Rows(0)("AmaMnHolidays")), 0, tblDt.Rows(0)("AmaMnHolidays"))
                        WMonthHolidays = IIf(IsDBNull(tblDt.Rows(0)("MemeMnHolidays")), 0, tblDt.Rows(0)("MemeMnHolidays"))
                    End If
                Catch exp As Exception
                    Throw New Exception("Holiday Count Error :" & exp.Message)
                    tblDt.Dispose()
                End Try

                AMonthWorkDays = MonthDays - AMonthHolidays ' total work days for axle
                ATillDateWorkDays = Day(dt) - ATillDateHolidays  ' completed work days for axle
                ANextWorkDays = AMonthWorkDays - ATillDateWorkDays ' remaining work days for axle

                WMonthWorkdays = MonthDays - WMonthHolidays
                WTillDateWorkDays = Day(dt) - WTillDateHolidays
                WNextWorkDays = WMonthWorkdays - WTillDateWorkDays

                tblDt = tables.GetWheelDayMonth(dt)
                If tblDt.Rows.Count > 0 Then
                    intWheelDay = tblDt.Rows(0)("GoodWheels")
                    intWheelMn = tblDt.Rows(0)("CummGoodWH")
                End If

                tblDt = tables.GetAxleDayMonth(dt, txtDate)
                If tblDt.Rows.Count > 0 Then
                    intAxleDay = tblDt.Rows(0)("AxleActualDay")
                    intAxleMn = tblDt.Rows(0)("AxleActualMonth")
                End If

                tblDt = tables.GetWsetDayMonth(dt)
                If tblDt.Rows.Count > 0 Then
                    intWheelSetDay = tblDt.Rows(0)("DlySets")
                    intWheelSetMn = tblDt.Rows(0)("MnthSets")
                End If
                heatsmm = tables.GetHeatsForTheMonth(dt)
                heatsyy = tables.GetHeatsForTheYear(dt)
                blnChecked = True
            Catch exp As Exception
                Throw New Exception(exp.Message)
            End Try
            If blnChecked = False Then
                Exit Function
            End If

            Dim cmd As New SqlClient.SqlCommand()
            cmd = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@dt", SqlDbType.SmallDateTime, 4)
            cmd.Parameters.Add("@upto", SqlDbType.SmallDateTime, 4)
            cmd.Parameters.Add("@cumfig", SqlDbType.Int, 4)
            cmd.Parameters.Add("@Item", SqlDbType.VarChar, 50)
            cmd.Parameters("@dt").Direction = ParameterDirection.Input
            cmd.Parameters("@cumfig").Direction = ParameterDirection.Input
            cmd.Parameters("@Item").Direction = ParameterDirection.Input

            Dim blnSaved As Boolean
            Try
                cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                blnSaved = InsertPhlGenDate(cmd, ReGen, UserID, dt)
                If blnSaved Then
                    blnSaved = False
                    If tables.DataExists(dt) > 0 Then
                        blnSaved = SavePrdn(cmd, dt, "MNACTWH", intWheelMn, False)
                        blnSaved = SavePrdn(cmd, dt, "MNACTAX", intAxleMn, False)
                        blnSaved = SavePrdn(cmd, dt, "MNACTWS", intWheelSetMn, False)
                        blnSaved = SavePrdn(cmd, dt, "DYACTWH", 0, False)
                        blnSaved = SavePrdn(cmd, dt, "DYACTAX", intAxleDay, False)
                        blnSaved = SavePrdn(cmd, dt, "DYACTWS", intWheelSetDay, False)

                        ''' new addition to added if external source axles are there 
                        'SavePrdn(cmd, dt, "MNACTAXI", intAxleMn, False)
                        'SavePrdn(cmd, dt, "MNACTWSI", intWheelSetMn, False)
                        'SavePrdn(cmd, dt, "MNACTAXE", intAxleMn, False)
                        'SavePrdn(cmd, dt, "MNACTWSE", intWheelSetMn, False)
                    Else
                        blnSaved = SavePrdn(cmd, dt, "MNACTWH", intWheelMn, True)
                        blnSaved = SavePrdn(cmd, dt, "MNACTAX", intAxleMn, True)
                        blnSaved = SavePrdn(cmd, dt, "MNACTWS", intWheelSetMn, True)
                        blnSaved = SavePrdn(cmd, dt, "DYACTWH", 0, True)
                        blnSaved = SavePrdn(cmd, dt, "DYACTAX", intAxleDay, True)
                        blnSaved = SavePrdn(cmd, dt, "DYACTWS", intWheelSetDay, True)

                        ''' new addition to added if external source axles are there 
                        'SavePrdn(cmd, dt, "DYACTAXI", intAxleDay, True)
                        'SavePrdn(cmd, dt, "DYACTWSI", intWheelSetDay, True)
                        'SavePrdn(cmd, dt, "DYACTAXE", intAxleDay, True)
                        'SavePrdn(cmd, dt, "DYACTWSE", intWheelSetDay, True)
                        '''new addition to added if external source axles are there 
                        'SavePrdn(cmd, dt, "MNACTAXI", intAxleMn, True)
                        'SavePrdn(cmd, dt, "MNACTWSI", intWheelSetMn, True)
                        'SavePrdn(cmd, dt, "MNACTAXE", intAxleMn, True)
                        'SavePrdn(cmd, dt, "MNACTWSE", intWheelSetMn, True)
                    End If
                    GetYearFigs(cmd, dt, intWheelYr, intAxleYr, intWheelSetYr)
                    If MnHeatDataExists(cmd, dt) = False Then
                        blnSaved = SavePrdn(cmd, dt, "HEATSMM", heatsmm, True, False)
                    Else
                        blnSaved = SavePrdn(cmd, dt, "HEATSMM", heatsmm, False, False)
                    End If
                    If dt.Month = 4 Then
                        If tables.YrDataExists(cmd, dt) = False Then
                            blnSaved = SavePrdn(cmd, dt, "HEATSYY", heatsyy, True, True)
                            blnSaved = SavePrdn(cmd, dt, "YRACTWH", intWheelYr, True, True)
                            blnSaved = SavePrdn(cmd, dt, "YRACTAX", intAxleYr, True, True)
                            blnSaved = SavePrdn(cmd, dt, "YRACTWS", intWheelSetYr, True, True)

                            '' new addition to added if external source axles are there 
                            ''blnSaved = SavePrdn(cmd, dt, "YRACTAXI", intAxleYr, True, True)
                            ''blnSaved = SavePrdn(cmd, dt, "YRACTAXE", intAxleYr, True, True)
                            ''blnSaved = SavePrdn(cmd, dt, "YRACTWSI", intWheelSetYr, True, True)
                            ''blnSaved = SavePrdn(cmd, dt, "YRACTWSE", intWheelSetYr, True, True)
                        Else
                            blnSaved = SavePrdn(cmd, dt, "HEATSYY", heatsyy, False, True)
                            blnSaved = SavePrdn(cmd, dt, "YRACTWH", intWheelYr, False, True)
                            blnSaved = SavePrdn(cmd, dt, "YRACTAX", intAxleYr, False, True)
                            blnSaved = SavePrdn(cmd, dt, "YRACTWS", intWheelSetYr, False, True)

                            '' new addition to added if external source axles are there 
                            ''blnSaved = SavePrdn(cmd, dt, "YRACTAXI", intAxleYr, False, True)
                            ''blnSaved = SavePrdn(cmd, dt, "YRACTAXE", intAxleYr, False, True)
                            ''blnSaved = SavePrdn(cmd, dt, "YRACTWSI", intWheelSetYr, False, True)
                            ''blnSaved = SavePrdn(cmd, dt, "YRACTWSE", intWheelSetYr, False, True)
                        End If
                    Else
                        blnSaved = SavePrdn(cmd, dt, "HEATSYY", heatsyy, False, True)
                        blnSaved = SavePrdn(cmd, dt, "YRACTWH", intWheelYr, False, True)
                        blnSaved = SavePrdn(cmd, dt, "YRACTAX", intAxleYr, False, True)
                        blnSaved = SavePrdn(cmd, dt, "YRACTWS", intWheelSetYr, False, True)

                        ''' new addition to added if external source axles are there 
                        'SavePrdn(cmd, dt, "YRACTAXI", intAxleYr, False, True)
                        'SavePrdn(cmd, dt, "YRACTAXE", intAxleYr, False, True)
                        'SavePrdn(cmd, dt, "YRACTWSI", intWheelSetYr, False, True)
                        'SavePrdn(cmd, dt, "YRACTWSE", intWheelSetYr, False, True)
                    End If
                    blnSaved = True
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If IsNothing(cmd) = False Then
                    If IsNothing(cmd.Transaction) = False Then
                        If blnSaved Then cmd.Transaction.Commit() Else cmd.Transaction.Rollback()
                        If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                        cmd.Dispose()
                        cmd = Nothing
                    End If
                End If
            End Try
            Return blnSaved
        End Function
        Public Function GeneratePHL(ByVal dt As Date, ByVal txtDate As String, ByVal ReGen As Boolean, ByVal UserID As String, ByVal WithOutPink As Boolean) As Boolean
            Dim blnChecked As Boolean
            Dim MonthDays As Integer

            Dim intWheelMn, intAxleMn, intWheelSetMn As Integer
            Dim intWheelYr, intAxleYr, intWheelSetYr As Integer

            Dim intWheelDay, intAxleDay, intWheelSetDay As Integer
            Dim strHoliday As String
            Dim heatsmm, heatsyy As Long

            Dim AMonthHolidays, ATillDateHolidays As Integer
            Dim WMonthHolidays, WTillDateHolidays As Integer
            Dim AMonthWorkDays, ANextWorkDays As Integer
            Dim ATillDateWorkDays, WMonthWorkdays As Integer
            Dim WTillDateWorkDays, WNextWorkDays As Integer
            ATillDateHolidays = 0
            WTillDateHolidays = 0
            AMonthHolidays = 0
            WMonthHolidays = 0
            intWheelDay = 0
            intWheelMn = 0

            Try
                strHoliday = tables.GetNextDayHoliday(dt)
                MonthDays = dt.Date.DaysInMonth(Year(dt), Month(dt))
                Dim tblDt As DataTable
                Try
                    tblDt = tables.getShopWiseHolidaysTillPhlDt(dt)
                    If tblDt.Rows.Count > 0 Then
                        ATillDateHolidays = IIf(IsDBNull(tblDt.Rows(0)("AMATillDt")), 0, tblDt.Rows(0)("AMATillDt"))
                        WTillDateHolidays = IIf(IsDBNull(tblDt.Rows(0)("MEMETillDt")), 0, tblDt.Rows(0)("MEMETillDt"))
                        AMonthHolidays = IIf(IsDBNull(tblDt.Rows(0)("AmaMnHolidays")), 0, tblDt.Rows(0)("AmaMnHolidays"))
                        WMonthHolidays = IIf(IsDBNull(tblDt.Rows(0)("MemeMnHolidays")), 0, tblDt.Rows(0)("MemeMnHolidays"))
                    End If
                Catch exp As Exception
                    Throw New Exception("Holiday Count Error :" & exp.Message)
                    tblDt.Dispose()
                End Try

                AMonthWorkDays = MonthDays - AMonthHolidays ' total work days for axle
                ATillDateWorkDays = Day(dt) - ATillDateHolidays  ' completed work days for axle
                ANextWorkDays = AMonthWorkDays - ATillDateWorkDays ' remaining work days for axle

                WMonthWorkdays = MonthDays - WMonthHolidays
                WTillDateWorkDays = Day(dt) - WTillDateHolidays
                WNextWorkDays = WMonthWorkdays - WTillDateWorkDays

                tblDt = tables.GetWheelDayMonth(dt)
                If tblDt.Rows.Count > 0 Then
                    intWheelDay = tblDt.Rows(0)("GoodWheels")
                    intWheelMn = tblDt.Rows(0)("CummGoodWH")
                End If

                tblDt = tables.GetAxleDayMonth(dt, txtDate)
                If tblDt.Rows.Count > 0 Then
                    intAxleDay = tblDt.Rows(0)("AxleActualDay")
                    intAxleMn = tblDt.Rows(0)("AxleActualMonth")
                End If

                tblDt = tables.GetWsetDayMonth(dt)
                If tblDt.Rows.Count > 0 Then
                    intWheelSetDay = tblDt.Rows(0)("DlySets")
                    intWheelSetMn = tblDt.Rows(0)("MnthSets")
                End If
                heatsmm = tables.GetHeatsForTheMonth(dt)
                heatsyy = tables.GetHeatsForTheYear(dt)
                blnChecked = True
            Catch exp As Exception
                Throw New Exception(exp.Message)
            End Try
            If blnChecked = False Then
                Exit Function
            End If

            Dim cmd As New SqlClient.SqlCommand()
            cmd = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@dt", SqlDbType.SmallDateTime, 4)
            cmd.Parameters.Add("@upto", SqlDbType.SmallDateTime, 4)
            cmd.Parameters.Add("@cumfig", SqlDbType.Int, 4)
            cmd.Parameters.Add("@Item", SqlDbType.VarChar, 50)
            cmd.Parameters("@dt").Direction = ParameterDirection.Input
            cmd.Parameters("@cumfig").Direction = ParameterDirection.Input
            cmd.Parameters("@Item").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@d", SqlDbType.Int, 4).Direction = ParameterDirection.Output

            Dim blnSaved As Boolean
            Try
                cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                blnSaved = InsertPhlGenDate(cmd, ReGen, UserID, dt)
                If blnSaved Then
                    blnSaved = False
                    If tables.DataExists(dt) > 0 Then
                        blnSaved = SavePrdn(cmd, dt, "MNACTWH", intWheelMn, False)
                        blnSaved = SavePrdn(cmd, dt, "MNACTAX", intAxleMn, False)
                        blnSaved = SavePrdn(cmd, dt, "MNACTWS", intWheelSetMn, False)
                        blnSaved = SavePrdn(cmd, dt, "DYACTWH", IIf(WithOutPink, 0, intWheelDay), False)
                        blnSaved = SavePrdn(cmd, dt, "DYACTAX", intAxleDay, False)
                        blnSaved = SavePrdn(cmd, dt, "DYACTWS", intWheelSetDay, False)

                        ''' new addition to added if external source axles are there 
                        'SavePrdn(cmd, dt, "MNACTAXI", intAxleMn, False)
                        'SavePrdn(cmd, dt, "MNACTWSI", intWheelSetMn, False)
                        'SavePrdn(cmd, dt, "MNACTAXE", intAxleMn, False)
                        'SavePrdn(cmd, dt, "MNACTWSE", intWheelSetMn, False)
                    Else
                        blnSaved = SavePrdn(cmd, dt, "MNACTWH", intWheelMn, True)
                        blnSaved = SavePrdn(cmd, dt, "MNACTAX", intAxleMn, True)
                        blnSaved = SavePrdn(cmd, dt, "MNACTWS", intWheelSetMn, True)
                        blnSaved = SavePrdn(cmd, dt, "DYACTWH", IIf(WithOutPink, 0, intWheelDay), True)
                        blnSaved = SavePrdn(cmd, dt, "DYACTAX", intAxleDay, True)
                        blnSaved = SavePrdn(cmd, dt, "DYACTWS", intWheelSetDay, True)

                        ''' new addition to added if external source axles are there 
                        'SavePrdn(cmd, dt, "DYACTAXI", intAxleDay, True)
                        'SavePrdn(cmd, dt, "DYACTWSI", intWheelSetDay, True)
                        'SavePrdn(cmd, dt, "DYACTAXE", intAxleDay, True)
                        'SavePrdn(cmd, dt, "DYACTWSE", intWheelSetDay, True)
                        '''new addition to added if external source axles are there 
                        'SavePrdn(cmd, dt, "MNACTAXI", intAxleMn, True)
                        'SavePrdn(cmd, dt, "MNACTWSI", intWheelSetMn, True)
                        'SavePrdn(cmd, dt, "MNACTAXE", intAxleMn, True)
                        'SavePrdn(cmd, dt, "MNACTWSE", intWheelSetMn, True)
                    End If
                    GetYearFigs(cmd, dt, intWheelYr, intAxleYr, intWheelSetYr)
                    If MnHeatDataExists(cmd, dt) = False Then
                        blnSaved = SavePrdn(cmd, dt, "HEATSMM", heatsmm, True, False)
                    Else
                        blnSaved = SavePrdn(cmd, dt, "HEATSMM", heatsmm, False, False)
                    End If
                    If dt.Month = 4 Then
                        If tables.YrDataExists(cmd, dt) = False Then
                            blnSaved = SavePrdn(cmd, dt, "HEATSYY", heatsyy, True, True)
                            blnSaved = SavePrdn(cmd, dt, "YRACTWH", intWheelYr, True, True)
                            blnSaved = SavePrdn(cmd, dt, "YRACTAX", intAxleYr, True, True)
                            blnSaved = SavePrdn(cmd, dt, "YRACTWS", intWheelSetYr, True, True)

                            '' new addition to added if external source axles are there 
                            ''blnSaved = SavePrdn(cmd, dt, "YRACTAXI", intAxleYr, True, True)
                            ''blnSaved = SavePrdn(cmd, dt, "YRACTAXE", intAxleYr, True, True)
                            ''blnSaved = SavePrdn(cmd, dt, "YRACTWSI", intWheelSetYr, True, True)
                            ''blnSaved = SavePrdn(cmd, dt, "YRACTWSE", intWheelSetYr, True, True)
                        Else
                            blnSaved = SavePrdn(cmd, dt, "HEATSYY", heatsyy, False, True)
                            blnSaved = SavePrdn(cmd, dt, "YRACTWH", intWheelYr, False, True)
                            blnSaved = SavePrdn(cmd, dt, "YRACTAX", intAxleYr, False, True)
                            blnSaved = SavePrdn(cmd, dt, "YRACTWS", intWheelSetYr, False, True)

                            '' new addition to added if external source axles are there 
                            ''blnSaved = SavePrdn(cmd, dt, "YRACTAXI", intAxleYr, False, True)
                            ''blnSaved = SavePrdn(cmd, dt, "YRACTAXE", intAxleYr, False, True)
                            ''blnSaved = SavePrdn(cmd, dt, "YRACTWSI", intWheelSetYr, False, True)
                            ''blnSaved = SavePrdn(cmd, dt, "YRACTWSE", intWheelSetYr, False, True)
                        End If
                    Else
                        blnSaved = SavePrdn(cmd, dt, "HEATSYY", heatsyy, False, True)
                        blnSaved = SavePrdn(cmd, dt, "YRACTWH", intWheelYr, False, True)
                        blnSaved = SavePrdn(cmd, dt, "YRACTAX", intAxleYr, False, True)
                        blnSaved = SavePrdn(cmd, dt, "YRACTWS", intWheelSetYr, False, True)

                        ''' new addition to added if external source axles are there 
                        'SavePrdn(cmd, dt, "YRACTAXI", intAxleYr, False, True)
                        'SavePrdn(cmd, dt, "YRACTAXE", intAxleYr, False, True)
                        'SavePrdn(cmd, dt, "YRACTWSI", intWheelSetYr, False, True)
                        'SavePrdn(cmd, dt, "YRACTWSE", intWheelSetYr, False, True)
                    End If
                    blnSaved = True
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If IsNothing(cmd) = False Then
                    If IsNothing(cmd.Transaction) = False Then
                        If blnSaved Then cmd.Transaction.Commit() Else cmd.Transaction.Rollback()
                        If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                        cmd.Dispose()
                        cmd = Nothing
                    End If
                End If
            End Try
            Return blnSaved
        End Function
        Public Function GenPHLReport(ByVal PHLDate As Date) As Boolean
            Dim strCmd As New SqlClient.SqlCommand("wap.dbo.mm_sp_PHLGEN_ProdPlan", New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con")))
            strCmd.CommandText = "delete from mm_PHLGEN_ProdPlan where phl_date = @Date"
            strCmd.CommandType = CommandType.Text
            strCmd.Parameters.Add("@Date", SqlDbType.SmallDateTime, 8)
            strCmd.Parameters("@Date").Direction = ParameterDirection.Input
            strCmd.CommandTimeout = 60 * 60 * 1
            Dim ds As New DataSet()
            Dim Message As String
            Dim da As New SqlClient.SqlDataAdapter(strCmd)
            Try
                strCmd.Parameters("@Date").Value = CDate(PHLDate)
                strCmd.Connection.Open()
                strCmd.ExecuteNonQuery()
                strCmd.Connection.Close()
                strCmd.CommandType = CommandType.StoredProcedure
                strCmd.CommandText = "wap.dbo.mm_sp_PHLGEN_ProdPlan"
                da.Fill(ds, "Highlights")
                If ds.Tables("Highlights").Rows.Count > 0 Then
                    Message = updtHighlights(ds.Tables("Highlights"), strCmd.Parameters("@Date").Value)
                End If
#Disable Warning BC42104 ' Variable is used before it has been assigned a value
                GenPHLReport = Message = "Generated"
#Enable Warning BC42104 ' Variable is used before it has been assigned a value
            Catch exp As Exception
                GenPHLReport = False
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                strCmd.Dispose()
                strCmd = Nothing
            End Try
            da = Nothing
            ds = Nothing
            strCmd = Nothing
        End Function
        Private Function updtHighlights(ByVal tblHighlights As DataTable, ByVal dDate As Date) As String
            Dim dr As DataRow
            Dim strcmd As New SqlClient.SqlCommand()
            strcmd.CommandText = "insert into mm_PHLGEN_ProdPlan ( phl_Date, AD, AM, AY, SD, SM, SY, WDG, WMG, WYG, ADT, WDTG, SDT, AMT, WMTC, SMT, AYT, WYTC, SYT, AxDays, AxlDaysComp, WHLDays, WHLDaysComp, Holiday, HM, HD, MD, MM, WDTC, WMTG, WYTG, WDC, WMC, WYC, ATGWHLS, ATCWHLS, ATAXLS, ATSETS, ATWRKDAYSA, ATWRKDAYSW, FY, PlannedTgtSets, PlannedTgtAxles, PlannedTgtWhlsCast, PlannedTgtWhlsGood, DayNrAxQty, MonthNrAxQty, YearNrAxQty, ataxlse, PlannedTgtAxlesE, DayTgtNrAxle, MnTgtNrAxle, YrTgtNrAxle  ) values ( @phl_Date, @AD, @AM, @AY, @SD, @SM, @SY, @WDG, @WMG, @WYG, @ADT, @WDTG, @SDT, @AMT, @WMTC, @SMT, @AYT, @WYTC, @SYT, @AxDays, @AxlDaysComp, @WHLDays, @WHLDaysComp, @Holiday, @HM, @HD, @MD, @MM, @WDTC, @WMTG, @WYTG, @WDC, @WMC, @WYC, @ATGWHLS, @ATCWHLS, @ATAXLS, @ATSETS, @ATWRKDAYSA, @ATWRKDAYSW, @FY, @PlannedTgtSets, @PlannedTgtAxles, @PlannedTgtWhlsCast, @PlannedTgtWhlsGood, @DayNrAxQty, @MonthNrAxQty, @YearNrAxQty, @ataxlse, @PlannedTgtAxlesE, @DayTgtNrAxle, @MnTgtNrAxle, @YrTgtNrAxle )"
            strcmd.Connection = rwfGen.Connection.ConObj
            strcmd.Parameters.Add("@phl_date", SqlDbType.SmallDateTime, 8)
            strcmd.Parameters.Add("@AD", SqlDbType.Float, 8)
            strcmd.Parameters.Add("@AM", SqlDbType.Float, 8)
            strcmd.Parameters.Add("@AY", SqlDbType.Float, 8)
            strcmd.Parameters.Add("@SD", SqlDbType.Float, 8)
            strcmd.Parameters.Add("@SM", SqlDbType.Float, 8)
            strcmd.Parameters.Add("@SY", SqlDbType.Float, 8)
            strcmd.Parameters.Add("@WDG", SqlDbType.Float, 8)
            strcmd.Parameters.Add("@WMG", SqlDbType.Float, 8)
            strcmd.Parameters.Add("@WYG", SqlDbType.Float, 8)
            strcmd.Parameters.Add("@ADT", SqlDbType.Int, 4)
            strcmd.Parameters.Add("@WDTG", SqlDbType.Int, 4)
            strcmd.Parameters.Add("@SDT", SqlDbType.Int, 4)
            strcmd.Parameters.Add("@AMT", SqlDbType.Int, 4)
            strcmd.Parameters.Add("@WMTC", SqlDbType.BigInt, 8)
            strcmd.Parameters.Add("@SMT", SqlDbType.Int, 4)
            strcmd.Parameters.Add("@AYT", SqlDbType.Int, 4)
            strcmd.Parameters.Add("@WYTC", SqlDbType.Int, 4)
            strcmd.Parameters.Add("@SYT", SqlDbType.BigInt, 8)
            strcmd.Parameters.Add("@AxDays", SqlDbType.Int, 4)
            strcmd.Parameters.Add("@AxlDaysComp", SqlDbType.Int, 4)
            strcmd.Parameters.Add("@WHLDays", SqlDbType.Int, 4)
            strcmd.Parameters.Add("@WHLDaysComp", SqlDbType.BigInt, 8)
            strcmd.Parameters.Add("@Holiday", SqlDbType.VarChar, 1)
            strcmd.Parameters.Add("@HM", SqlDbType.Int, 4)
            strcmd.Parameters.Add("@HD", SqlDbType.Int, 4)
            strcmd.Parameters.Add("@MD", SqlDbType.Int, 4)
            strcmd.Parameters.Add("@MM", SqlDbType.Int, 4)
            strcmd.Parameters.Add("@WDTC", SqlDbType.BigInt, 8)
            strcmd.Parameters.Add("@WMTG", SqlDbType.BigInt, 8)
            strcmd.Parameters.Add("@WYTG", SqlDbType.BigInt, 8)
            strcmd.Parameters.Add("@WDC", SqlDbType.Float, 8)
            strcmd.Parameters.Add("@WMC", SqlDbType.Float, 8)
            strcmd.Parameters.Add("@WYC", SqlDbType.Float, 8)
            strcmd.Parameters.Add("@ATGWHLS", SqlDbType.BigInt, 8)
            strcmd.Parameters.Add("@ATCWHLS", SqlDbType.BigInt, 8)
            strcmd.Parameters.Add("@ATAXLS", SqlDbType.BigInt, 8)
            strcmd.Parameters.Add("@ATSETS", SqlDbType.BigInt, 8)
            strcmd.Parameters.Add("@ATWRKDAYSA", SqlDbType.Int, 4)
            strcmd.Parameters.Add("@ATWRKDAYSW", SqlDbType.Int, 4)
            strcmd.Parameters.Add("@FY", SqlDbType.VarChar, 7)
            strcmd.Parameters.Add("@PlannedTgtSets", SqlDbType.BigInt, 8)
            strcmd.Parameters.Add("@PlannedTgtAxles", SqlDbType.BigInt, 8)
            strcmd.Parameters.Add("@PlannedTgtWhlsCast", SqlDbType.BigInt, 8)
            strcmd.Parameters.Add("@PlannedTgtWhlsGood", SqlDbType.BigInt, 8)

            strcmd.Parameters.Add("@DayNrAxQty", SqlDbType.Int, 4)
            strcmd.Parameters.Add("@MonthNrAxQty", SqlDbType.Int, 4)
            strcmd.Parameters.Add("@YearNrAxQty", SqlDbType.Int, 4)
            strcmd.Parameters.Add("@ataxlse", SqlDbType.Int, 4)
            strcmd.Parameters.Add("@PlannedTgtAxlesE", SqlDbType.Int, 4)

            strcmd.Parameters.Add("@DayTgtNrAxle", SqlDbType.Int, 4)
            strcmd.Parameters.Add("@MnTgtNrAxle", SqlDbType.Int, 4)
            strcmd.Parameters.Add("@YrTgtNrAxle", SqlDbType.Int, 4)


            strcmd.Parameters("@phl_date").Direction = ParameterDirection.Input
            strcmd.Parameters("@AD").Direction = ParameterDirection.Input
            strcmd.Parameters("@AM").Direction = ParameterDirection.Input
            strcmd.Parameters("@AY").Direction = ParameterDirection.Input
            strcmd.Parameters("@SD").Direction = ParameterDirection.Input
            strcmd.Parameters("@SM").Direction = ParameterDirection.Input
            strcmd.Parameters("@SY").Direction = ParameterDirection.Input
            strcmd.Parameters("@WDG").Direction = ParameterDirection.Input
            strcmd.Parameters("@WMG").Direction = ParameterDirection.Input
            strcmd.Parameters("@WYG").Direction = ParameterDirection.Input
            strcmd.Parameters("@ADT").Direction = ParameterDirection.Input
            strcmd.Parameters("@WDTG").Direction = ParameterDirection.Input
            strcmd.Parameters("@SDT").Direction = ParameterDirection.Input
            strcmd.Parameters("@AMT").Direction = ParameterDirection.Input
            strcmd.Parameters("@WMTC").Direction = ParameterDirection.Input
            strcmd.Parameters("@SMT").Direction = ParameterDirection.Input
            strcmd.Parameters("@AYT").Direction = ParameterDirection.Input
            strcmd.Parameters("@WYTC").Direction = ParameterDirection.Input
            strcmd.Parameters("@SYT").Direction = ParameterDirection.Input
            strcmd.Parameters("@AxDays").Direction = ParameterDirection.Input
            strcmd.Parameters("@AxlDaysComp").Direction = ParameterDirection.Input
            strcmd.Parameters("@WHLDays").Direction = ParameterDirection.Input
            strcmd.Parameters("@WHLDaysComp").Direction = ParameterDirection.Input
            strcmd.Parameters("@Holiday").Direction = ParameterDirection.Input
            strcmd.Parameters("@HM").Direction = ParameterDirection.Input
            strcmd.Parameters("@HD").Direction = ParameterDirection.Input
            strcmd.Parameters("@MD").Direction = ParameterDirection.Input
            strcmd.Parameters("@MM").Direction = ParameterDirection.Input
            strcmd.Parameters("@WDTC").Direction = ParameterDirection.Input
            strcmd.Parameters("@WMTG").Direction = ParameterDirection.Input
            strcmd.Parameters("@WYTG").Direction = ParameterDirection.Input
            strcmd.Parameters("@WDC").Direction = ParameterDirection.Input
            strcmd.Parameters("@WMC").Direction = ParameterDirection.Input
            strcmd.Parameters("@WYC").Direction = ParameterDirection.Input
            strcmd.Parameters("@ATGWHLS").Direction = ParameterDirection.Input
            strcmd.Parameters("@ATCWHLS").Direction = ParameterDirection.Input
            strcmd.Parameters("@ATAXLS").Direction = ParameterDirection.Input
            strcmd.Parameters("@ATSETS").Direction = ParameterDirection.Input
            strcmd.Parameters("@ATWRKDAYSA").Direction = ParameterDirection.Input
            strcmd.Parameters("@ATWRKDAYSW").Direction = ParameterDirection.Input
            strcmd.Parameters("@FY").Direction = ParameterDirection.Input
            strcmd.Parameters("@PlannedTgtSets").Direction = ParameterDirection.Input
            strcmd.Parameters("@PlannedTgtAxles").Direction = ParameterDirection.Input
            strcmd.Parameters("@PlannedTgtWhlsCast").Direction = ParameterDirection.Input
            strcmd.Parameters("@PlannedTgtWhlsGood").Direction = ParameterDirection.Input


            strcmd.Parameters("@DayNrAxQty").Direction = ParameterDirection.Input
            strcmd.Parameters("@MonthNrAxQty").Direction = ParameterDirection.Input
            strcmd.Parameters("@YearNrAxQty").Direction = ParameterDirection.Input
            strcmd.Parameters("@ataxlse").Direction = ParameterDirection.Input
            strcmd.Parameters("@PlannedTgtAxlesE").Direction = ParameterDirection.Input

            strcmd.Parameters("@DayTgtNrAxle").Direction = ParameterDirection.Input
            strcmd.Parameters("@MnTgtNrAxle").Direction = ParameterDirection.Input
            strcmd.Parameters("@YrTgtNrAxle").Direction = ParameterDirection.Input


            Dim blnRecordAdded As Boolean
            For Each dr In tblHighlights.Rows
                strcmd.Parameters("@phl_date").Value = dDate
                strcmd.Parameters("@AD").Value = dr("AD")
                strcmd.Parameters("@AM").Value = dr("AM")
                strcmd.Parameters("@AY").Value = dr("AY")
                strcmd.Parameters("@SD").Value = dr("SD")
                strcmd.Parameters("@SM").Value = dr("SM")
                strcmd.Parameters("@SY").Value = dr("SY")
                strcmd.Parameters("@WDG").Value = dr("WDG")
                strcmd.Parameters("@WMG").Value = dr("WMG")
                strcmd.Parameters("@WYG").Value = dr("WYG")
                strcmd.Parameters("@ADT").Value = dr("ADT")
                strcmd.Parameters("@WDTG").Value = dr("WDTG")
                strcmd.Parameters("@SDT").Value = dr("SDT")
                strcmd.Parameters("@AMT").Value = dr("AMT")
                strcmd.Parameters("@WMTC").Value = dr("WMTC")
                strcmd.Parameters("@SMT").Value = dr("SMT")
                strcmd.Parameters("@AYT").Value = dr("AYT")
                strcmd.Parameters("@WYTC").Value = dr("WYTC")
                strcmd.Parameters("@SYT").Value = dr("SYT")
                strcmd.Parameters("@AxDays").Value = dr("AxDays")
                strcmd.Parameters("@AxlDaysComp").Value = dr("AxlDaysComp")
                strcmd.Parameters("@WHLDays").Value = dr("WHLDays")
                strcmd.Parameters("@WHLDaysComp").Value = dr("WHLDaysComp")
                strcmd.Parameters("@Holiday").Value = dr("Holiday")
                strcmd.Parameters("@HM").Value = dr("HM")
                strcmd.Parameters("@HD").Value = dr("HD")
                strcmd.Parameters("@MD").Value = dr("MD")
                strcmd.Parameters("@MM").Value = dr("MM")
                strcmd.Parameters("@WDTC").Value = dr("WDTC")
                strcmd.Parameters("@WMTG").Value = dr("WMTG")
                strcmd.Parameters("@WYTG").Value = dr("WYTG")
                strcmd.Parameters("@WDC").Value = dr("WDC")
                strcmd.Parameters("@WMC").Value = dr("WMC")
                strcmd.Parameters("@WYC").Value = dr("WYC")
                strcmd.Parameters("@ATGWHLS").Value = dr("ATGWHLS")
                strcmd.Parameters("@ATCWHLS").Value = dr("ATCWHLS")
                strcmd.Parameters("@ATAXLS").Value = dr("ATAXLS")
                strcmd.Parameters("@ATSETS").Value = dr("ATSETS")
                strcmd.Parameters("@ATWRKDAYSA").Value = dr("ATWRKDAYSA")
                strcmd.Parameters("@ATWRKDAYSW").Value = dr("ATWRKDAYSW")
                strcmd.Parameters("@FY").Value = dr("FY")
                strcmd.Parameters("@PlannedTgtSets").Value = dr("PlannedTgtSets")
                strcmd.Parameters("@PlannedTgtAxles").Value = dr("PlannedTgtAxles")
                strcmd.Parameters("@PlannedTgtWhlsCast").Value = dr("PlannedTgtWhlsCast")
                strcmd.Parameters("@PlannedTgtWhlsGood").Value = dr("PlannedTgtWhlsGood")

                strcmd.Parameters("@DayNrAxQty").Value = IIf(IsDBNull(dr("DayNrAxQty")), 0, dr("DayNrAxQty"))
                strcmd.Parameters("@MonthNrAxQty").Value = IIf(IsDBNull(dr("MonthNrAxQty")), 0, dr("MonthNrAxQty"))
                strcmd.Parameters("@YearNrAxQty").Value = IIf(IsDBNull(dr("YearNrAxQty")), 0, dr("YearNrAxQty"))
                strcmd.Parameters("@ataxlse").Value = IIf(IsDBNull(dr("ataxlse")), 0, dr("ataxlse"))
                strcmd.Parameters("@PlannedTgtAxlesE").Value = IIf(IsDBNull(dr("PlannedTgtAxlesE")), 0, dr("PlannedTgtAxlesE"))

                strcmd.Parameters("@DayTgtNrAxle").Value = IIf(IsDBNull(dr("DayTgtNrAxle")), 0, dr("DayTgtNrAxle"))
                strcmd.Parameters("@MnTgtNrAxle").Value = IIf(IsDBNull(dr("MnTgtNrAxle")), 0, dr("MnTgtNrAxle"))
                strcmd.Parameters("@YrTgtNrAxle").Value = IIf(IsDBNull(dr("YrTgtNrAxle")), 0, dr("YrTgtNrAxle"))


                Try
                    If strcmd.Connection.State = ConnectionState.Closed Then strcmd.Connection.Open()
                    strcmd.ExecuteNonQuery()
                    blnRecordAdded = True
                Catch sqlExp As SqlClient.SqlException
                    If sqlExp.Number = 2627 Then
                        blnRecordAdded = False
                        updtHighlights = "Already Generated"
                    Else
                        updtHighlights = sqlExp.Message
                    End If
                Catch exp As Exception
                    updtHighlights = exp.Message
                    blnRecordAdded = False
                Finally
                    If strcmd.Connection.State = ConnectionState.Open Then strcmd.Connection.Close()
                End Try
                If blnRecordAdded = False Then
                    Exit For
                End If
            Next
            If strcmd.Connection.State = ConnectionState.Open Then strcmd.Connection.Close()
            strcmd.Dispose()
            If blnRecordAdded Then
                updtHighlights = "Generated"
            End If
            strcmd = Nothing
        End Function
        Public Function GenPHLRBReport(ByVal PHLDate As Date) As Boolean
            Dim strCmd As New SqlClient.SqlCommand("wap.dbo.mm_sp_PHLGEN_RB_ProdPlan", New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con")))
            strCmd.CommandText = "delete from mm_PHLGEN_RB_ProdPlan where phl_date = @RBDate"
            strCmd.CommandType = CommandType.Text
            strCmd.Parameters.Add("@RBDate", SqlDbType.SmallDateTime, 8)
            strCmd.Parameters("@RBDate").Direction = ParameterDirection.Input
            strCmd.CommandTimeout = 60 * 60 * 1
            Dim ds As New DataSet()
            Dim Message As String
            Dim da As New SqlClient.SqlDataAdapter(strCmd)
            Try
                strCmd.Parameters("@RBDate").Value = CDate(PHLDate)
                strCmd.Connection.Open()
                strCmd.ExecuteNonQuery()
                strCmd.Connection.Close()
                strCmd.CommandType = CommandType.StoredProcedure
                strCmd.CommandText = "wap.dbo.mm_sp_PHLGEN_RB_ProdPlan"
                da.Fill(ds, "RBHighlights")
                If ds.Tables("RBHighlights").Rows.Count > 0 Then
                    Message = updtRBHighlights(ds.Tables("RBHighlights"), strCmd.Parameters("@RBDate").Value)
                End If
#Disable Warning BC42104 ' Variable is used before it has been assigned a value
                GenPHLRBReport = Message = "Generated"
#Enable Warning BC42104 ' Variable is used before it has been assigned a value
            Catch exp As Exception
                GenPHLRBReport = False
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                strCmd.Dispose()
            End Try
            da = Nothing
            ds = Nothing
            strCmd = Nothing
        End Function
        Private Function updtRBHighlights(ByVal tblRBHighlights As DataTable, ByVal dDate As Date) As String
            Dim dr As DataRow
            Dim strcmd As New SqlClient.SqlCommand()
            strcmd.CommandText = "insert into mm_PHLGEN_RB_ProdPlan (Phl_Date, RBWheelsDlyQtyC, RBWheelsDlyQtyG, RBAxleDlyQty, RBWheelSetDlyQty, RBWheelsMthlyQtyC, RBWheelsMthlyQtyG, RBAxleMthlyQty, RBWheelSetMthlyQty, RBWheelsYrQtyC, RBWheelsYrQtyG, RBAxleYrQty, RBWheelSetYrQty, RBWrkWheelDaysComp, RBWheelDaysAva, RBAxleDaysComp, RBAxleDaysAva, RBWhlAnnualCTgt, RBWhlAnnualGTgt, RBAxlAnnualTgt, RBSetAnnualTgt, RBPlannedTgtWheelCast, RBPlannedTgtWheelGood, RBPlannedTgtAxles, RBPlannedTgtSets, RBPlannedWorkingDaysW, RBPlannedWorkingDaysA ) values ( @phl_date, @RBWheelsDlyQtyC, @RBWheelsDlyQtyG, @RBAxleDlyQty, @RBWheelSetDlyQty, @RBWheelsMthlyQtyC, @RBWheelsMthlyQtyG, @RBAxleMthlyQty, @RBWheelSetMthlyQty, @RBWheelsYrQtyC, @RBWheelsYrQtyG, @RBAxleYrQty, @RBWheelSetYrQty, @RBWrkWheelDaysComp, @RBWheelDaysAva, @RBAxleDaysComp, @RBAxleDaysAva, @RBWhlAnnualCTgt, @RBWhlAnnualGTgt, @RBAxlAnnualTgt, @RBSetAnnualTgt, @RBPlannedTgtWheelCast, @RBPlannedTgtWheelGood, @RBPlannedTgtAxles, @RBPlannedTgtSets, @RBPlannedWorkingDaysW, @RBPlannedWorkingDaysA) "
            strcmd.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
            strcmd.Parameters.Add("@phl_date", SqlDbType.SmallDateTime, 8)
            strcmd.Parameters.Add("@RBWheelsDlyQtyC", SqlDbType.BigInt, 8)
            strcmd.Parameters.Add("@RBWheelsMthlyQtyC", SqlDbType.BigInt, 8)
            strcmd.Parameters.Add("@RBWheelsMthlyQtyG", SqlDbType.BigInt, 8)
            strcmd.Parameters.Add("@RBWheelsYrQtyG", SqlDbType.BigInt, 8)
            strcmd.Parameters.Add("@RBWhlAnnualCTgt", SqlDbType.BigInt, 8)
            strcmd.Parameters.Add("@RBWhlAnnualGTgt", SqlDbType.BigInt, 8)
            strcmd.Parameters.Add("@RBAxlAnnualTgt", SqlDbType.BigInt, 8)
            strcmd.Parameters.Add("@RBSetAnnualTgt", SqlDbType.BigInt, 8)
            strcmd.Parameters.Add("@RBPlannedTgtWheelCast", SqlDbType.BigInt, 8)
            strcmd.Parameters.Add("@RBPlannedTgtWheelGood", SqlDbType.BigInt, 8)
            strcmd.Parameters.Add("@RBPlannedTgtAxles", SqlDbType.BigInt, 8)
            strcmd.Parameters.Add("@RBPlannedTgtSets", SqlDbType.BigInt, 8)
            strcmd.Parameters.Add("@RBWheelsDlyQtyG", SqlDbType.BigInt, 8)
            strcmd.Parameters.Add("@RBAxleDlyQty", SqlDbType.BigInt, 8)
            strcmd.Parameters.Add("@RBWheelSetDlyQty", SqlDbType.BigInt, 8)
            strcmd.Parameters.Add("@RBAxleMthlyQty", SqlDbType.BigInt, 8)
            strcmd.Parameters.Add("@RBWheelSetMthlyQty", SqlDbType.BigInt, 8)
            strcmd.Parameters.Add("@RBWheelsYrQtyC", SqlDbType.BigInt, 8)
            strcmd.Parameters.Add("@RBAxleYrQty", SqlDbType.BigInt, 8)
            strcmd.Parameters.Add("@RBWheelSetYrQty", SqlDbType.BigInt, 8)
            strcmd.Parameters.Add("@RBWrkWheelDaysComp", SqlDbType.BigInt, 8)
            strcmd.Parameters.Add("@RBWheelDaysAva", SqlDbType.BigInt, 8)
            strcmd.Parameters.Add("@RBAxleDaysComp", SqlDbType.BigInt, 8)
            strcmd.Parameters.Add("@RBAxleDaysAva", SqlDbType.BigInt, 8)
            strcmd.Parameters.Add("@RBPlannedWorkingDaysW", SqlDbType.BigInt, 8)
            strcmd.Parameters.Add("@RBPlannedWorkingDaysA", SqlDbType.BigInt, 8)

            strcmd.Parameters("@phl_date").Direction = ParameterDirection.Input
            strcmd.Parameters("@RBWheelsDlyQtyC").Direction = ParameterDirection.Input
            strcmd.Parameters("@RBWheelsMthlyQtyC").Direction = ParameterDirection.Input
            strcmd.Parameters("@RBWheelsMthlyQtyG").Direction = ParameterDirection.Input
            strcmd.Parameters("@RBWheelsYrQtyG").Direction = ParameterDirection.Input
            strcmd.Parameters("@RBWhlAnnualCTgt").Direction = ParameterDirection.Input
            strcmd.Parameters("@RBWhlAnnualGTgt").Direction = ParameterDirection.Input
            strcmd.Parameters("@RBAxlAnnualTgt").Direction = ParameterDirection.Input
            strcmd.Parameters("@RBSetAnnualTgt").Direction = ParameterDirection.Input
            strcmd.Parameters("@RBPlannedTgtWheelCast").Direction = ParameterDirection.Input
            strcmd.Parameters("@RBPlannedTgtWheelGood").Direction = ParameterDirection.Input
            strcmd.Parameters("@RBPlannedTgtAxles").Direction = ParameterDirection.Input
            strcmd.Parameters("@RBPlannedTgtSets").Direction = ParameterDirection.Input
            strcmd.Parameters("@RBWheelsDlyQtyG").Direction = ParameterDirection.Input
            strcmd.Parameters("@RBAxleDlyQty").Direction = ParameterDirection.Input
            strcmd.Parameters("@RBWheelSetDlyQty").Direction = ParameterDirection.Input
            strcmd.Parameters("@RBAxleMthlyQty").Direction = ParameterDirection.Input
            strcmd.Parameters("@RBWheelSetMthlyQty").Direction = ParameterDirection.Input
            strcmd.Parameters("@RBWheelsYrQtyC").Direction = ParameterDirection.Input
            strcmd.Parameters("@RBAxleYrQty").Direction = ParameterDirection.Input
            strcmd.Parameters("@RBWheelSetYrQty").Direction = ParameterDirection.Input
            strcmd.Parameters("@RBWrkWheelDaysComp").Direction = ParameterDirection.Input
            strcmd.Parameters("@RBWheelDaysAva").Direction = ParameterDirection.Input
            strcmd.Parameters("@RBAxleDaysComp").Direction = ParameterDirection.Input
            strcmd.Parameters("@RBAxleDaysAva").Direction = ParameterDirection.Input
            strcmd.Parameters("@RBPlannedWorkingDaysW").Direction = ParameterDirection.Input
            strcmd.Parameters("@RBPlannedWorkingDaysA").Direction = ParameterDirection.Input

            Dim blnRecordAdded As Boolean
            Dim blnAxleHoliday, blnWheelHoliday As Boolean
            Dim sqlcmd As New SqlClient.SqlCommand()
            Dim sqlcon As New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
            sqlcmd.Connection = sqlcon
            Try
                sqlcmd.Connection.Open()
                sqlcmd.CommandText = "Select count(*) from mm_calendar_dump where shop = 'AMA' and date = '" & CDate(dDate) & "'"
                blnAxleHoliday = sqlcmd.ExecuteScalar > 0
                sqlcmd.CommandText = "Select count(*) from mm_calendar_dump where shop = 'MEME' and date = '" & CDate(dDate) & "'"
                blnWheelHoliday = sqlcmd.ExecuteScalar > 0
            Catch
                blnAxleHoliday = False
                blnWheelHoliday = False
            Finally
                If sqlcmd.Connection.State = ConnectionState.Open Then sqlcmd.Connection.Close()
                sqlcmd.Dispose()
                sqlcmd = Nothing
            End Try

            For Each dr In tblRBHighlights.Rows
                strcmd.Parameters("@phl_date").Value = dDate
                strcmd.Parameters("@RBWheelsDlyQtyC").Value = IIf(blnWheelHoliday = False, dr("RBWheelsDlyQtyC"), 0)
                strcmd.Parameters("@RBWheelsMthlyQtyC").Value = dr("RBWheelsMthlyQtyC")
                strcmd.Parameters("@RBWheelsMthlyQtyG").Value = dr("RBWheelsMthlyQtyG")
                strcmd.Parameters("@RBWheelsYrQtyG").Value = dr("RBWheelsYrQtyG")
                strcmd.Parameters("@RBWhlAnnualCTgt").Value = dr("RBWhlAnnualCTgt")
                strcmd.Parameters("@RBWhlAnnualGTgt").Value = dr("RBWhlAnnualGTgt")
                strcmd.Parameters("@RBAxlAnnualTgt").Value = dr("RBAxlAnnualTgt")
                strcmd.Parameters("@RBSetAnnualTgt").Value = dr("RBSetAnnualTgt")
                strcmd.Parameters("@RBPlannedTgtWheelCast").Value = dr("RBPlannedTgtWheelCast")
                strcmd.Parameters("@RBPlannedTgtWheelGood").Value = dr("RBPlannedTgtWheelGood")
                strcmd.Parameters("@RBPlannedTgtAxles").Value = dr("RBPlannedTgtAxles")
                strcmd.Parameters("@RBPlannedTgtSets").Value = dr("RBPlannedTgtSets")
                strcmd.Parameters("@RBWheelsDlyQtyG").Value = dr("RBWheelsDlyQtyG")
                ' check if holiday then assign 0

                strcmd.Parameters("@RBAxleDlyQty").Value = IIf(blnAxleHoliday = False, dr("RBAxleDlyQty"), 0)
                strcmd.Parameters("@RBWheelSetDlyQty").Value = IIf(blnAxleHoliday = False, dr("RBWheelSetDlyQty"), 0)
                strcmd.Parameters("@RBAxleMthlyQty").Value = dr("RBAxleMthlyQty")
                strcmd.Parameters("@RBWheelSetMthlyQty").Value = dr("RBWheelSetMthlyQty")
                strcmd.Parameters("@RBWheelsYrQtyC").Value = dr("RBWheelsYrQtyC")
                strcmd.Parameters("@RBAxleYrQty").Value = dr("RBAxleYrQty")
                strcmd.Parameters("@RBWheelSetYrQty").Value = dr("RBWheelSetYrQty")
                strcmd.Parameters("@RBWrkWheelDaysComp").Value = dr("RBWrkWheelDaysComp")
                strcmd.Parameters("@RBWheelDaysAva").Value = dr("RBWheelDaysAva")
                strcmd.Parameters("@RBAxleDaysComp").Value = dr("RBAxleDaysComp")
                strcmd.Parameters("@RBAxleDaysAva").Value = dr("RBAxleDaysAva")
                strcmd.Parameters("@RBPlannedWorkingDaysW").Value = dr("RBPlannedWorkingDaysW")
                strcmd.Parameters("@RBPlannedWorkingDaysA").Value = dr("RBPlannedWorkingDaysA")
                Try
                    If strcmd.Connection.State = ConnectionState.Closed Then strcmd.Connection.Open()
                    strcmd.ExecuteNonQuery()
                    blnRecordAdded = True
                Catch sqlExp As SqlClient.SqlException
                    If sqlExp.Number = 2627 Then
                        blnRecordAdded = False
                        updtRBHighlights = "Already Generated"
                    Else
                        updtRBHighlights = sqlExp.Message
                    End If
                Catch exp As Exception
                    updtRBHighlights = exp.Message
                    blnRecordAdded = False
                Finally
                    If strcmd.Connection.State = ConnectionState.Open Then strcmd.Connection.Close()
                End Try
                If blnRecordAdded = False Then
                    Exit For
                End If
            Next
            If strcmd.Connection.State = ConnectionState.Open Then strcmd.Connection.Close()
            strcmd.Dispose()
            If blnRecordAdded Then
                updtRBHighlights = "Generated"
            End If
            strcmd = Nothing
        End Function
        Private Function updtHeats(ByVal tblHeats As DataTable, ByVal dDate As Date, ByVal HolidayInd As String) As String
            Dim dr As DataRow
            Dim strcmd As New SqlClient.SqlCommand()
            strcmd.CommandText = "Insert into mm_PHLGEN_pp_heat ( phl_date , Holiday, heat, FC, KWH, TBT, TT, TypeWHL ) values (@phl_date , @Holiday, @heat, @FC, @KWH, @TBT, @TT, @TypeWHL)"
            strcmd.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
            strcmd.Parameters.Add("@phl_date", SqlDbType.SmallDateTime, 8)
            strcmd.Parameters.Add("@Holiday", SqlDbType.VarChar, 10)
            strcmd.Parameters.Add("@heat", SqlDbType.VarChar, 50)
            strcmd.Parameters.Add("@FC", SqlDbType.VarChar, 1)
            strcmd.Parameters.Add("@KWH", SqlDbType.Decimal, 8)
            strcmd.Parameters.Add("@TBT", SqlDbType.Decimal, 8)
            strcmd.Parameters.Add("@TT", SqlDbType.Decimal, 8)
            strcmd.Parameters.Add("@TypeWHL", SqlDbType.VarChar, 100)

            strcmd.Parameters("@phl_date").Direction = ParameterDirection.Input
            strcmd.Parameters("@Holiday").Direction = ParameterDirection.Input
            strcmd.Parameters("@heat").Direction = ParameterDirection.Input
            strcmd.Parameters("@FC").Direction = ParameterDirection.Input
            strcmd.Parameters("@KWH").Direction = ParameterDirection.Input
            strcmd.Parameters("@TBT").Direction = ParameterDirection.Input
            strcmd.Parameters("@TT").Direction = ParameterDirection.Input
            strcmd.Parameters("@TypeWHL").Direction = ParameterDirection.Input
            Dim blnRecordAdded As Boolean
            For Each dr In tblHeats.Rows
                strcmd.Parameters("@phl_date").Value = dDate
                strcmd.Parameters("@Holiday").Value = HolidayInd
                strcmd.Parameters("@heat").Value = dr("Heat")
                strcmd.Parameters("@FC").Value = dr("FC")
                strcmd.Parameters("@KWH").Value = dr("KWH")
                strcmd.Parameters("@TBT").Value = dr("TBT")
                strcmd.Parameters("@TT").Value = dr("TT")
                strcmd.Parameters("@TypeWHL").Value = dr("TypeWHL")
                Try
                    If strcmd.Connection.State = ConnectionState.Closed Then strcmd.Connection.Open()
                    strcmd.ExecuteNonQuery()
                    blnRecordAdded = True
                Catch sqlExp As SqlClient.SqlException
                    If sqlExp.Number = 2627 Then
                        blnRecordAdded = False
                        updtHeats = "Already Generated"
                    End If
                Catch exp As Exception
                    updtHeats = exp.Message
                    blnRecordAdded = False
                Finally
                    If strcmd.Connection.State = ConnectionState.Open Then strcmd.Connection.Close()
                End Try
                If blnRecordAdded = False Then
                    Exit For
                End If
            Next
            If strcmd.Connection.State = ConnectionState.Open Then strcmd.Connection.Close()
            strcmd.Dispose()
            If blnRecordAdded Then
                updtHeats = "Generated"
            End If
            strcmd = Nothing
        End Function
        Private Function updtSummary(ByVal tblSummary As DataTable, ByVal dDate As Date) As String
            Dim dr As DataRow
            Dim strcmd As New SqlClient.SqlCommand()
            strcmd.CommandText = "Insert into mm_PHLGen_PP_Sum ( phl_date, Period, Description, value, Type ) values ( @phl_date, @Period, @Description, @value, @Type )"
            strcmd.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
            strcmd.Parameters.Add("@phl_date", SqlDbType.SmallDateTime, 8)
            strcmd.Parameters.Add("@Period", SqlDbType.VarChar, 10)
            strcmd.Parameters.Add("@Description", SqlDbType.VarChar, 50)
            strcmd.Parameters.Add("@value", SqlDbType.VarChar, 50)
            strcmd.Parameters.Add("@Type", SqlDbType.VarChar, 100)

            strcmd.Parameters("@phl_date").Direction = ParameterDirection.Input
            strcmd.Parameters("@Period").Direction = ParameterDirection.Input
            strcmd.Parameters("@Description").Direction = ParameterDirection.Input
            strcmd.Parameters("@value").Direction = ParameterDirection.Input
            strcmd.Parameters("@Type").Direction = ParameterDirection.Input

            Dim blnRecordAdded As Boolean
            For Each dr In tblSummary.Rows
                strcmd.Parameters("@phl_date").Value = dDate
                strcmd.Parameters("@Period").Value = dr("Period")
                strcmd.Parameters("@Description").Value = dr("Description")
                strcmd.Parameters("@value").Value = dr("value")
                strcmd.Parameters("@Type").Value = dr("Type")
                Try
                    If strcmd.Connection.State = ConnectionState.Closed Then strcmd.Connection.Open()
                    strcmd.ExecuteNonQuery()
                    blnRecordAdded = True
                Catch sqlExp As SqlClient.SqlException
                    If sqlExp.Number = 2627 Then
                        blnRecordAdded = False
                        updtSummary = "Already Generated"
                    End If
                Catch exp As Exception
                    updtSummary = exp.Message
                    blnRecordAdded = False
                Finally
                    If strcmd.Connection.State = ConnectionState.Open Then strcmd.Connection.Close()
                End Try
                If blnRecordAdded = False Then
                    Exit For
                End If
            Next
            If strcmd.Connection.State = ConnectionState.Open Then strcmd.Connection.Close()
            strcmd.Dispose()
            If blnRecordAdded Then
                updtSummary = "Generated"
            End If
            strcmd = Nothing
        End Function
        Private Function updtHeatException(ByVal tblHeatException As DataTable, ByVal dDate As Date) As String
            Dim dr As DataRow
            Dim strcmd As New SqlClient.SqlCommand()
            strcmd.CommandText = "Insert into mm_PHLGEN_Heat_Exception ( phl_date, heat_number, fc, Exception, duration, KWH, WheelsCast, Remarks ) values  ( @phl_date, @heat_number , @fc,  @Exception, @duration, @KWH, @WheelsCast, @Remarks ) "
            strcmd.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
            strcmd.Parameters.Add("@phl_date", SqlDbType.SmallDateTime, 8)
            strcmd.Parameters.Add("@heat_number", SqlDbType.VarChar, 50)
            strcmd.Parameters.Add("@fc", SqlDbType.VarChar, 1)
            strcmd.Parameters.Add("@Exception", SqlDbType.VarChar, 50)
            strcmd.Parameters.Add("@duration", SqlDbType.Decimal, 8)
            strcmd.Parameters.Add("@KWH", SqlDbType.Decimal, 8)
            strcmd.Parameters.Add("@WheelsCast", SqlDbType.BigInt, 8)
            strcmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 8000)

            strcmd.Parameters("@phl_date").Direction = ParameterDirection.Input
            strcmd.Parameters("@heat_number").Direction = ParameterDirection.Input
            strcmd.Parameters("@Exception").Direction = ParameterDirection.Input
            strcmd.Parameters("@duration").Direction = ParameterDirection.Input
            strcmd.Parameters("@KWH").Direction = ParameterDirection.Input
            strcmd.Parameters("@WheelsCast").Direction = ParameterDirection.Input
            strcmd.Parameters("@Remarks").Direction = ParameterDirection.Input
            strcmd.Parameters("@fc").Direction = ParameterDirection.Input


            Dim blnRecordAdded As Boolean
            For Each dr In tblHeatException.Rows
                strcmd.Parameters("@phl_date").Value = dDate
                strcmd.Parameters("@heat_number").Value = dr("heat_number")
                strcmd.Parameters("@fc").Value = IIf(IsDBNull(dr("fc")), "", dr("fc"))
                strcmd.Parameters("@Exception").Value = dr("Exception")
                strcmd.Parameters("@duration").Value = dr("duration")
                strcmd.Parameters("@KWH").Value = dr("KWH")
                strcmd.Parameters("@WheelsCast").Value = dr("WheelsCast")
                strcmd.Parameters("@Remarks").Value = dr("Remarks")
                Try
                    If strcmd.Connection.State = ConnectionState.Closed Then strcmd.Connection.Open()
                    strcmd.ExecuteNonQuery()
                    blnRecordAdded = True
                Catch sqlExp As SqlClient.SqlException
                    If sqlExp.Number = 2627 Then
                        blnRecordAdded = False
                        updtHeatException = "Already Generated"
                    Else
                        updtHeatException = sqlExp.Message
                    End If
                Catch exp As Exception
                    updtHeatException = exp.Message
                    blnRecordAdded = False
                Finally
                    If strcmd.Connection.State = ConnectionState.Open Then strcmd.Connection.Close()
                End Try
                If blnRecordAdded = False Then
                    Exit For
                End If
            Next
            If strcmd.Connection.State = ConnectionState.Open Then strcmd.Connection.Close()
            strcmd.Dispose()
            If blnRecordAdded Then
                updtHeatException = "Generated"
            End If
            strcmd = Nothing
        End Function
        Private Function updtDespatchedSets(ByVal tblDespatchedSets As DataTable, ByVal dDate As Date) As String
            Dim dr As DataRow
            Dim strcmd As New SqlClient.SqlCommand()
            strcmd.CommandText = "Insert into mm_PHLGEN_DespatchedWheelSets ( phl_date, period, count, description ) values ( @phl_date, @period, @count, @description ) "
            strcmd.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
            strcmd.Parameters.Add("@phl_date", SqlDbType.SmallDateTime, 8)
            strcmd.Parameters.Add("@Period", SqlDbType.VarChar, 50)
            strcmd.Parameters.Add("@count", SqlDbType.Int, 4)
            strcmd.Parameters.Add("@description", SqlDbType.VarChar, 50)


            strcmd.Parameters("@phl_date").Direction = ParameterDirection.Input
            strcmd.Parameters("@Period").Direction = ParameterDirection.Input
            strcmd.Parameters("@count").Direction = ParameterDirection.Input
            strcmd.Parameters("@description").Direction = ParameterDirection.Input

            Dim blnRecordAdded As Boolean
            For Each dr In tblDespatchedSets.Rows
                strcmd.Parameters("@phl_date").Value = dDate
                strcmd.Parameters("@Period").Value = dr("Period")
                strcmd.Parameters("@count").Value = dr("count")
                strcmd.Parameters("@description").Value = dr("description")

                Try
                    If strcmd.Connection.State = ConnectionState.Closed Then strcmd.Connection.Open()
                    strcmd.ExecuteNonQuery()
                    blnRecordAdded = True
                Catch sqlExp As SqlClient.SqlException
                    If sqlExp.Number = 2627 Then
                        blnRecordAdded = False
                        updtDespatchedSets = "Already Generated"
                    Else
                        updtDespatchedSets = sqlExp.Message
                    End If
                Catch exp As Exception
                    updtDespatchedSets = exp.Message
                    blnRecordAdded = False
                Finally
                    If strcmd.Connection.State = ConnectionState.Open Then strcmd.Connection.Close()
                End Try
                If blnRecordAdded = False Then
                    Exit For
                End If
            Next
            If strcmd.Connection.State = ConnectionState.Open Then strcmd.Connection.Close()
            strcmd.Dispose()
            If blnRecordAdded Then
                updtDespatchedSets = "Generated"
            End If
            strcmd = Nothing
        End Function
        Private Function updtDespatchedAxles(ByVal tblDespatchedAxles As DataTable, ByVal dDate As Date) As String
            Dim dr As DataRow
            Dim strcmd As New SqlClient.SqlCommand()
            strcmd.CommandText = "Insert into mm_PHLGEN_DespatchedAxles ( phl_Date, Period,  Count, Description ) values ( @phl_Date, @Period,  @Count, @Description )"
            strcmd.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
            strcmd.Parameters.Add("@phl_date", SqlDbType.SmallDateTime, 8)
            strcmd.Parameters.Add("@Period", SqlDbType.VarChar, 50)
            strcmd.Parameters.Add("@count", SqlDbType.Int, 4)
            strcmd.Parameters.Add("@description", SqlDbType.VarChar, 50)


            strcmd.Parameters("@phl_date").Direction = ParameterDirection.Input
            strcmd.Parameters("@Period").Direction = ParameterDirection.Input
            strcmd.Parameters("@count").Direction = ParameterDirection.Input
            strcmd.Parameters("@description").Direction = ParameterDirection.Input

            Dim blnRecordAdded As Boolean
            For Each dr In tblDespatchedAxles.Rows
                strcmd.Parameters("@phl_date").Value = dDate
                strcmd.Parameters("@Period").Value = dr("Period")
                strcmd.Parameters("@count").Value = dr("count")
                strcmd.Parameters("@description").Value = dr("description")

                Try
                    If strcmd.Connection.State = ConnectionState.Closed Then strcmd.Connection.Open()
                    strcmd.ExecuteNonQuery()
                    blnRecordAdded = True
                Catch sqlExp As SqlClient.SqlException
                    If sqlExp.Number = 2627 Then
                        blnRecordAdded = False
                        updtDespatchedAxles = "Already Generated"
                    Else
                        updtDespatchedAxles = sqlExp.Message
                    End If
                Catch exp As Exception
                    updtDespatchedAxles = exp.Message
                    blnRecordAdded = False
                Finally
                    If strcmd.Connection.State = ConnectionState.Open Then strcmd.Connection.Close()
                End Try
                If blnRecordAdded = False Then
                    Exit For
                End If
            Next
            If strcmd.Connection.State = ConnectionState.Open Then strcmd.Connection.Close()
            strcmd.Dispose()
            If blnRecordAdded Then
                updtDespatchedAxles = "Generated"
            End If
            strcmd = Nothing
        End Function
        Private Function updtDespatchedWheels(ByVal tblDespatchedWheels As DataTable, ByVal dDate As Date) As String
            Dim dr As DataRow
            Dim strcmd As New SqlClient.SqlCommand()
            strcmd.CommandText = "Insert into mm_PHLGEN_DespatchedWheels( phl_Date, Period,  Count, Description ) values ( @phl_Date, @Period,  @Count, @Description )"
            strcmd.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
            strcmd.Parameters.Add("@phl_date", SqlDbType.SmallDateTime, 8)
            strcmd.Parameters.Add("@Period", SqlDbType.VarChar, 50)
            strcmd.Parameters.Add("@count", SqlDbType.Int, 4)
            strcmd.Parameters.Add("@description", SqlDbType.VarChar, 50)


            strcmd.Parameters("@phl_date").Direction = ParameterDirection.Input
            strcmd.Parameters("@Period").Direction = ParameterDirection.Input
            strcmd.Parameters("@count").Direction = ParameterDirection.Input
            strcmd.Parameters("@description").Direction = ParameterDirection.Input

            Dim blnRecordAdded As Boolean
            For Each dr In tblDespatchedWheels.Rows
                strcmd.Parameters("@phl_date").Value = dDate
                strcmd.Parameters("@Period").Value = dr("Period")
                strcmd.Parameters("@count").Value = dr("count")
                strcmd.Parameters("@description").Value = dr("description")

                Try
                    If strcmd.Connection.State = ConnectionState.Closed Then strcmd.Connection.Open()
                    strcmd.ExecuteNonQuery()
                    blnRecordAdded = True
                Catch sqlExp As SqlClient.SqlException
                    If sqlExp.Number = 2627 Then
                        blnRecordAdded = False
                        updtDespatchedWheels = "Already Generated"
                    Else
                        updtDespatchedWheels = sqlExp.Message
                    End If
                Catch exp As Exception
                    updtDespatchedWheels = exp.Message
                    blnRecordAdded = False
                Finally
                    If strcmd.Connection.State = ConnectionState.Open Then strcmd.Connection.Close()
                End Try
                If blnRecordAdded = False Then
                    Exit For
                End If
            Next
            If strcmd.Connection.State = ConnectionState.Open Then strcmd.Connection.Close()
            strcmd.Dispose()
            If blnRecordAdded Then
                updtDespatchedWheels = "Generated"
            End If
            strcmd = Nothing
        End Function
        Private Function updtWheelBalance(ByVal tblWheelBalance As DataTable, ByVal dDate As Date) As String
            Dim dr As DataRow
            Dim strcmd As New SqlClient.SqlCommand()
            strcmd.CommandText = "Insert into mm_PHLGEN_WheelShop_FloorBalance ( phl_date, AsonDate, WheelType, OpeningBalance, Manufactured, Despatched, WheelsToAssembly, ClosingBalance ) values ( @phl_date, @AsonDate, @WheelType, @OpeningBalance, @Manufactured, @Despatched, @WheelsToAssembly, @ClosingBalance )"
            strcmd.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
            strcmd.Parameters.Add("@phl_date", SqlDbType.SmallDateTime, 8)
            strcmd.Parameters.Add("@AsonDate", SqlDbType.SmallDateTime, 8)
            strcmd.Parameters.Add("@WheelType", SqlDbType.VarChar, 15)
            strcmd.Parameters.Add("@OpeningBalance", SqlDbType.BigInt, 8)
            strcmd.Parameters.Add("@Manufactured", SqlDbType.BigInt, 8)
            strcmd.Parameters.Add("@Despatched", SqlDbType.BigInt, 8)
            strcmd.Parameters.Add("@WheelsToAssembly", SqlDbType.BigInt, 8)
            strcmd.Parameters.Add("@ClosingBalance", SqlDbType.BigInt, 8)

            strcmd.Parameters("@phl_date").Direction = ParameterDirection.Input
            strcmd.Parameters("@AsonDate").Direction = ParameterDirection.Input
            strcmd.Parameters("@WheelType").Direction = ParameterDirection.Input
            strcmd.Parameters("@OpeningBalance").Direction = ParameterDirection.Input
            strcmd.Parameters("@Manufactured").Direction = ParameterDirection.Input
            strcmd.Parameters("@Despatched").Direction = ParameterDirection.Input
            strcmd.Parameters("@WheelsToAssembly").Direction = ParameterDirection.Input
            strcmd.Parameters("@ClosingBalance").Direction = ParameterDirection.Input

            Dim blnRecordAdded As Boolean
            For Each dr In tblWheelBalance.Rows
                strcmd.Parameters("@phl_date").Value = dDate
                strcmd.Parameters("@AsonDate").Value = dr("AsonDate")
                strcmd.Parameters("@WheelType").Value = dr("WheelType")
                strcmd.Parameters("@OpeningBalance").Value = dr("OpeningBalance")
                strcmd.Parameters("@Manufactured").Value = dr("Manufactured")
                strcmd.Parameters("@Despatched").Value = dr("Despatched")
                strcmd.Parameters("@WheelsToAssembly").Value = dr("WheelsToAssembly")
                strcmd.Parameters("@ClosingBalance").Value = dr("ClosingBalance")
                Try
                    If strcmd.Connection.State = ConnectionState.Closed Then strcmd.Connection.Open()
                    strcmd.ExecuteNonQuery()
                    blnRecordAdded = True
                Catch sqlExp As SqlClient.SqlException
                    If sqlExp.Number = 2627 Then
                        blnRecordAdded = False
                        updtWheelBalance = "Already Generated"
                    Else
                        updtWheelBalance = sqlExp.Message
                    End If
                Catch exp As Exception
                    updtWheelBalance = exp.Message
                    blnRecordAdded = False
                Finally
                    If strcmd.Connection.State = ConnectionState.Open Then strcmd.Connection.Close()
                End Try
                If blnRecordAdded = False Then
                    Exit For
                End If
            Next
            If strcmd.Connection.State = ConnectionState.Open Then strcmd.Connection.Close()
            strcmd.Dispose()
            If blnRecordAdded Then
                updtWheelBalance = "Generated"
            End If
            strcmd = Nothing
        End Function
        Private Function updtAxleShopProudction(ByVal tblAxleShopProudction As DataTable, ByVal dDate As Date) As String
            Dim dr As DataRow
            Dim strcmd As New SqlClient.SqlCommand()
            strcmd.CommandText = "insert into  mm_PHLGEN_AxleShop_numbers_units ( phl_Date, period, drawing_number, product_code, description, type, Value ) values ( @phl_Date, @period, @drawing_number, @product_code, @description, @type, @Value ) "
            strcmd.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
            strcmd.Parameters.Add("@phl_date", SqlDbType.SmallDateTime, 8)
            strcmd.Parameters.Add("@period", SqlDbType.VarChar, 50)
            strcmd.Parameters.Add("@drawing_number", SqlDbType.VarChar, 50)
            strcmd.Parameters.Add("@product_code", SqlDbType.VarChar, 50)
            strcmd.Parameters.Add("@description", SqlDbType.VarChar, 50)
            strcmd.Parameters.Add("@type", SqlDbType.VarChar, 50)
            strcmd.Parameters.Add("@Value", SqlDbType.Float, 8)

            strcmd.Parameters("@phl_date").Direction = ParameterDirection.Input
            strcmd.Parameters("@period").Direction = ParameterDirection.Input
            strcmd.Parameters("@drawing_number").Direction = ParameterDirection.Input
            strcmd.Parameters("@product_code").Direction = ParameterDirection.Input
            strcmd.Parameters("@description").Direction = ParameterDirection.Input
            strcmd.Parameters("@type").Direction = ParameterDirection.Input
            strcmd.Parameters("@Value").Direction = ParameterDirection.Input

            Dim blnRecordAdded As Boolean
            For Each dr In tblAxleShopProudction.Rows
                strcmd.Parameters("@phl_date").Value = dDate
                strcmd.Parameters("@period").Value = dr("period") & ""
                strcmd.Parameters("@drawing_number").Value = dr("drawing_number") & ""
                strcmd.Parameters("@product_code").Value = dr("product_code") & ""
                strcmd.Parameters("@description").Value = dr("description") & ""
                strcmd.Parameters("@type").Value = dr("type") & ""
                strcmd.Parameters("@Value").Value = dr("Value")
                Try
                    If strcmd.Connection.State = ConnectionState.Closed Then strcmd.Connection.Open()
                    strcmd.ExecuteNonQuery()
                    blnRecordAdded = True
                Catch sqlExp As SqlClient.SqlException
                    If sqlExp.Number = 2627 Then
                        blnRecordAdded = False
                        updtAxleShopProudction = "Already Generated"
                    Else
                        updtAxleShopProudction = sqlExp.Message
                    End If
                Catch exp As Exception
                    updtAxleShopProudction = exp.Message
                    blnRecordAdded = False
                Finally
                    If strcmd.Connection.State = ConnectionState.Open Then strcmd.Connection.Close()
                End Try
                If blnRecordAdded = False Then
                    Exit For
                End If
            Next
            If strcmd.Connection.State = ConnectionState.Open Then strcmd.Connection.Close()
            strcmd.Dispose()
            If blnRecordAdded Then
                updtAxleShopProudction = "Generated"
            End If
            strcmd = Nothing
        End Function
        Private Function updtLooseAxlesAvailable(ByVal tblLooseAxlesAvailable As DataTable, ByVal dDate As Date) As String
            Dim dr As DataRow
            Dim strcmd As New SqlClient.SqlCommand()
            strcmd.CommandText = "insert into mm_PHLGEN_ams_loose_axles_available (phl_Date, qty, for_insp, und_insp, und_mcn, long_description, drawing_number, Total, WtTotal ) values (@phl_Date, @qty, @for_insp, @und_insp, @und_mcn, @long_description, @drawing_number, @Total, @WtTotal )"
            strcmd.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
            strcmd.Parameters.Add("@phl_date", SqlDbType.SmallDateTime, 8)
            strcmd.Parameters.Add("@qty", SqlDbType.Int, 4)
            strcmd.Parameters.Add("@for_insp", SqlDbType.Int, 4)
            strcmd.Parameters.Add("@und_insp", SqlDbType.Int, 4)
            strcmd.Parameters.Add("@und_mcn", SqlDbType.Int, 4)
            strcmd.Parameters.Add("@long_description", SqlDbType.VarChar, 150)
            strcmd.Parameters.Add("@drawing_number", SqlDbType.VarChar, 50)
            strcmd.Parameters.Add("@Total", SqlDbType.Int, 4)
            strcmd.Parameters.Add("@WtTotal", SqlDbType.Float, 8)

            strcmd.Parameters("@phl_date").Direction = ParameterDirection.Input
            strcmd.Parameters("@qty").Direction = ParameterDirection.Input
            strcmd.Parameters("@for_insp").Direction = ParameterDirection.Input
            strcmd.Parameters("@und_insp").Direction = ParameterDirection.Input
            strcmd.Parameters("@und_mcn").Direction = ParameterDirection.Input
            strcmd.Parameters("@long_description").Direction = ParameterDirection.Input
            strcmd.Parameters("@drawing_number").Direction = ParameterDirection.Input
            strcmd.Parameters("@Total").Direction = ParameterDirection.Input
            strcmd.Parameters("@WtTotal").Direction = ParameterDirection.Input

            Dim blnRecordAdded As Boolean
            For Each dr In tblLooseAxlesAvailable.Rows
                strcmd.Parameters("@phl_date").Value = dDate
                strcmd.Parameters("@qty").Value = dr("qty")
                strcmd.Parameters("@for_insp").Value = dr("for_insp")
                strcmd.Parameters("@und_insp").Value = dr("und_insp")
                strcmd.Parameters("@und_mcn").Value = dr("und_mcn")
                strcmd.Parameters("@long_description").Value = dr("long_description")
                strcmd.Parameters("@drawing_number").Value = dr("drawing_number")
                strcmd.Parameters("@Total").Value = dr("Total")
                strcmd.Parameters("@WtTotal").Value = dr("WtTotal")

                Try
                    If strcmd.Connection.State = ConnectionState.Closed Then strcmd.Connection.Open()
                    strcmd.ExecuteNonQuery()
                    blnRecordAdded = True
                Catch sqlExp As SqlClient.SqlException
                    If sqlExp.Number = 2627 Then
                        blnRecordAdded = False
                        updtLooseAxlesAvailable = "Already Generated"
                    Else
                        updtLooseAxlesAvailable = sqlExp.Message
                    End If
                Catch exp As Exception
                    updtLooseAxlesAvailable = exp.Message
                    blnRecordAdded = False
                Finally
                    If strcmd.Connection.State = ConnectionState.Open Then strcmd.Connection.Close()
                End Try
                If blnRecordAdded = False Then
                    Exit For
                End If
            Next
            If strcmd.Connection.State = ConnectionState.Open Then strcmd.Connection.Close()
            strcmd.Dispose()
            If blnRecordAdded Then
                updtLooseAxlesAvailable = "Generated"
            End If
            strcmd = Nothing
        End Function
        Private Function updtWheelsetInventory(ByVal tblWheelsetInventory As DataTable, ByVal dDate As Date) As String
            Dim dr As DataRow
            Dim strcmd As New SqlClient.SqlCommand()
            strcmd.CommandText = "insert into mm_PHLGEN_WheelsetInventory ( phl_Date, groupTitle, CountFor, cnt ) values ( @phl_Date, @groupTitle, @CountFor, @cnt )"
            strcmd.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
            strcmd.Parameters.Add("@phl_date", SqlDbType.SmallDateTime, 8)
            strcmd.Parameters.Add("@groupTitle", SqlDbType.VarChar, 15)
            strcmd.Parameters.Add("@cnt", SqlDbType.Int, 4)
            strcmd.Parameters.Add("@CountFor", SqlDbType.VarChar, 30)

            strcmd.Parameters("@phl_date").Direction = ParameterDirection.Input
            strcmd.Parameters("@groupTitle").Direction = ParameterDirection.Input
            strcmd.Parameters("@cnt").Direction = ParameterDirection.Input
            strcmd.Parameters("@CountFor").Direction = ParameterDirection.Input

            Dim blnRecordAdded As Boolean
            For Each dr In tblWheelsetInventory.Rows
                strcmd.Parameters("@phl_date").Value = dDate
                strcmd.Parameters("@groupTitle").Value = dr("groupTitle")
                strcmd.Parameters("@cnt").Value = dr("cnt")
                strcmd.Parameters("@CountFor").Value = dr("CountFor")

                Try
                    If strcmd.Connection.State = ConnectionState.Closed Then strcmd.Connection.Open()
                    strcmd.ExecuteNonQuery()
                    blnRecordAdded = True
                Catch sqlExp As SqlClient.SqlException
                    If sqlExp.Number = 2627 Then
                        blnRecordAdded = False
                        updtWheelsetInventory = "Already Generated"
                    Else
                        updtWheelsetInventory = sqlExp.Message
                    End If
                Catch exp As Exception
                    updtWheelsetInventory = exp.Message
                    blnRecordAdded = False
                Finally
                    If strcmd.Connection.State = ConnectionState.Open Then strcmd.Connection.Close()
                End Try
                If blnRecordAdded = False Then
                    Exit For
                End If
            Next
            If strcmd.Connection.State = ConnectionState.Open Then strcmd.Connection.Close()
            strcmd.Dispose()
            If blnRecordAdded Then
                updtWheelsetInventory = "Generated"
            End If
            strcmd = Nothing
        End Function
        Private Function updtWheelsets(ByVal tblWheelsets As DataTable, ByVal dDate As Date) As String
            Dim dr As DataRow
            Dim strcmd As New SqlClient.SqlCommand()
            strcmd.CommandText = "insert into mm_PHLGEN_WheelSets ( phl_date, Period, Count, Description, Type ) values ( @phl_date, @Period, @Count, @Description, @Type )"
            strcmd.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
            strcmd.Parameters.Add("@phl_date", SqlDbType.SmallDateTime, 8)
            strcmd.Parameters.Add("@Period", SqlDbType.VarChar, 50)
            strcmd.Parameters.Add("@Count", SqlDbType.Int, 4)
            strcmd.Parameters.Add("@Description", SqlDbType.VarChar, 50)
            strcmd.Parameters.Add("@Type", SqlDbType.VarChar, 50)

            strcmd.Parameters("@phl_date").Direction = ParameterDirection.Input
            strcmd.Parameters("@Period").Direction = ParameterDirection.Input
            strcmd.Parameters("@Count").Direction = ParameterDirection.Input
            strcmd.Parameters("@Description").Direction = ParameterDirection.Input
            strcmd.Parameters("@Type").Direction = ParameterDirection.Input

            Dim blnRecordAdded As Boolean
            For Each dr In tblWheelsets.Rows
                strcmd.Parameters("@phl_date").Value = dDate
                strcmd.Parameters("@Period").Value = dr("Period")
                strcmd.Parameters("@Count").Value = dr("Count")
                strcmd.Parameters("@Description").Value = dr("Description")
                strcmd.Parameters("@Type").Value = dr("Type")
                Try
                    If strcmd.Connection.State = ConnectionState.Closed Then strcmd.Connection.Open()
                    strcmd.ExecuteNonQuery()
                    blnRecordAdded = True
                Catch sqlExp As SqlClient.SqlException
                    If sqlExp.Number = 2627 Then
                        blnRecordAdded = False
                        updtWheelsets = "Already Generated"
                    Else
                        updtWheelsets = sqlExp.Message
                    End If
                Catch exp As Exception
                    updtWheelsets = exp.Message
                    blnRecordAdded = False
                Finally
                    If strcmd.Connection.State = ConnectionState.Open Then strcmd.Connection.Close()
                End Try
                If blnRecordAdded = False Then
                    Exit For
                End If
            Next
            If strcmd.Connection.State = ConnectionState.Open Then strcmd.Connection.Close()
            strcmd.Dispose()
            If blnRecordAdded Then
                updtWheelsets = "Generated"
            End If
            strcmd = Nothing
        End Function
        Public Function GenPHLDetailReport(ByVal PHLDate As Date, ByVal blnDone As Boolean, ByVal chkGenListItems0 As Boolean, ByVal chkGenListItems1 As Boolean, ByVal chkGenListItems2 As Boolean, ByVal chkGenListItems3 As Boolean, ByVal chkGenListItems4 As Boolean, ByVal chkGenListItems5 As Boolean, ByVal chkGenListItems6 As Boolean, ByVal chkGenListItems7 As Boolean, ByVal chkGenListItems8 As Boolean, ByVal chkGenListItems9 As Boolean, ByVal chkGenListItems10 As Boolean) As DataTable
            Dim message As String
            Dim dt As New DataTable()
            Dim dr As DataRow
            dt.TableName = "phl"
            dt.Columns.Add("GenListItemsNo")
            dt.Columns.Add("Selected")

            If chkGenListItems0 Then
                Dim strCmd As New SqlClient.SqlCommand()
                strcmd.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
                strcmd.CommandText = "delete from mm_PHLGEN_pp_heat where phl_date = @Date"
                strCmd.Parameters.Add("@Date", SqlDbType.SmallDateTime, 8)
                strcmd.CommandType = CommandType.Text
                strcmd.CommandTimeout = 36000
                Try
                    strCmd.Parameters("@Date").Value = CDate(PHLDate)
                    strcmd.Connection.Open()
                    strcmd.ExecuteNonQuery()
                Catch exp As Exception
                    Throw New Exception(exp.Message)
                    blnDone = False
                Finally
                    strcmd.Connection.Close()
                End Try
                If blnDone Then
                    strcmd.CommandText = "wap.dbo.mm_sp_phlgen_pp_heat"
                    strCmd.CommandType = CommandType.StoredProcedure
                    strCmd.Parameters.Add("@Holiday", SqlDbType.VarChar, 10)
                    strCmd.Parameters("@Holiday").Direction = ParameterDirection.Input
                    strCmd.Parameters("@Holiday").Value = "N"
                    strCmd.Parameters("@Date").Direction = ParameterDirection.Input
                    Dim ds As New DataSet()
                    Dim da As New SqlClient.SqlDataAdapter(strCmd)
                    Try
                        da.Fill(ds, "HeatsOfTheDay")
                        If ds.Tables("HeatsOfTheDay").Rows.Count > 0 Then
                            message = updtHeats(ds.Tables("HeatsOfTheDay"), strCmd.Parameters("@Date").Value, strCmd.Parameters("@Holiday").Value)
                            blnDone = message = "Generated"
                        End If
                        blnDone = True
                        dr = dt.NewRow
                        dr("GenListItemsNo") = "0"
                        dr("Selected") = Not blnDone
                        dt.Rows.Add(dr)
                    Catch exp As Exception
                        Throw New Exception(exp.Message)
                        blnDone = False
                    Finally
                        da.Dispose()
                        ds.Dispose()
                        da = Nothing
                        ds = Nothing
                    End Try
                End If
                strCmd.Dispose()
                strcmd = Nothing
            End If

            If chkGenListItems1 Then
                blnDone = False
                Dim strCmd As New SqlClient.SqlCommand("wap.dbo.mm_sp_PHLGen_PP_Sum", New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con")))
                strcmd.CommandText = "delete from mm_PHLGen_PP_Sum where phl_date = @Date"
                strcmd.CommandType = CommandType.Text
                strCmd.Parameters.Add("@Date", SqlDbType.SmallDateTime, 8)
                strCmd.Parameters("@Date").Direction = ParameterDirection.Input
                strcmd.CommandTimeout = 60 * 60 * 1
                Dim ds As New DataSet()
                Dim da As New SqlClient.SqlDataAdapter(strCmd)
                Try
                    strCmd.Parameters("@Date").Value = CDate(PHLDate)
                    strcmd.Connection.Open()
                    strcmd.ExecuteNonQuery()
                    strcmd.Connection.Close()
                    strcmd.CommandText = "wap.dbo.mm_sp_PHLGen_PP_Sum"
                    strcmd.CommandType = CommandType.StoredProcedure
                    da.Fill(ds, "SummaryOfTheDay")
                    If ds.Tables("SummaryOfTheDay").Rows.Count > 0 Then
                        message = updtSummary(ds.Tables("SummaryOfTheDay"), strCmd.Parameters("@Date").Value)
                        blnDone = message = "Generated"
                    End If
                    dr = dt.NewRow
                    dr("GenListItemsNo") = "1"
                    dr("Selected") = Not blnDone
                    dt.Rows.Add(dr)
                Catch exp As Exception
                    Throw New Exception(exp.Message)
                    blnDone = False
                Finally
                    da.Dispose()
                    strCmd.Dispose()
                End Try
                da = Nothing
                ds = Nothing
                strcmd = Nothing
            End If
            If chkGenListItems2 = True Then
                blnDone = False
                Dim strCmd As New SqlClient.SqlCommand("wap.dbo.mm_sp_PHLGEN_Heat_Exception", New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con")))
                strcmd.CommandText = "delete from mm_PHLGEN_Heat_Exception where phl_date = @Date"
                strcmd.CommandType = CommandType.Text
                strCmd.Parameters.Add("@Date", SqlDbType.SmallDateTime, 8)
                strCmd.Parameters("@Date").Direction = ParameterDirection.Input
                strcmd.CommandTimeout = 60 * 60 * 1
                Dim ds As New DataSet()
                Dim da As New SqlClient.SqlDataAdapter(strCmd)
                Try
                    strCmd.Parameters("@Date").Value = CDate(PHLDate)
                    strcmd.Connection.Open()
                    strcmd.ExecuteNonQuery()
                    strcmd.Connection.Close()
                    strcmd.CommandText = "wap.dbo.mm_sp_PHLGEN_Heat_Exception"
                    strCmd.CommandType = CommandType.StoredProcedure
                    da.Fill(ds, "HeatException")
                    If ds.Tables("HeatException").Rows.Count > 0 Then
                        message = updtHeatException(ds.Tables("HeatException"), strCmd.Parameters("@Date").Value)
                        blnDone = message = "Generated"
                    End If
                    dr = dt.NewRow
                    dr("GenListItemsNo") = "2"
                    dr("Selected") = Not blnDone
                    dt.Rows.Add(dr)
                Catch exp As Exception
                    Throw New Exception(exp.Message)
                    blnDone = False
                Finally
                    da.Dispose()
                    strCmd.Dispose()
                End Try
                da = Nothing
                ds = Nothing
                strcmd = Nothing
            End If

            If chkGenListItems10 = True Then
                blnDone = False
                Dim strCmd As New SqlClient.SqlCommand("wap.dbo.mm_sp_PHLGEN_WheelsetInventory", New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con")))
                strcmd.CommandText = "delete from mm_PHLGEN_WheelsetInventory where phl_date = @Date"
                strCmd.CommandType = CommandType.Text
                strCmd.Parameters.Add("@Date", SqlDbType.SmallDateTime, 8)
                strCmd.Parameters("@Date").Direction = ParameterDirection.Input
                strcmd.CommandTimeout = 60 * 60 * 1
                Dim ds As New DataSet()
                Dim da As New SqlClient.SqlDataAdapter(strCmd)
                Try
                    strCmd.Parameters("@Date").Value = CDate(PHLDate)
                    strcmd.Connection.Open()
                    strcmd.ExecuteNonQuery()
                    strcmd.Connection.Close()
                    strcmd.CommandText = "wap.dbo.mm_sp_PHLGEN_WheelsetInventory"
                    strCmd.CommandType = CommandType.StoredProcedure
                    da.Fill(ds, "WheelsetInventory")
                    If ds.Tables("WheelsetInventory").Rows.Count > 0 Then
                        message = updtWheelsetInventory(ds.Tables("WheelsetInventory"), strCmd.Parameters("@Date").Value)
                        blnDone = message = "Generated"
                    End If
                    dr = dt.NewRow
                    dr("GenListItemsNo") = "10"
                    dr("Selected") = Not blnDone
                    dt.Rows.Add(dr)
                Catch exp As Exception
                    Throw New Exception(exp.Message)
                    blnDone = False
                Finally
                    da.Dispose()
                    strCmd.Dispose()
                End Try
                da = Nothing
                ds = Nothing
                strcmd = Nothing
            End If

            If chkGenListItems9 = True Then
                blnDone = False
                Dim strCmd As New SqlClient.SqlCommand("wap.dbo.mm_sp_PHLGEN_WheelSets", New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con")))
                strcmd.CommandText = "delete from mm_PHLGEN_WheelSets where phl_date = @Date"
                strCmd.CommandType = CommandType.Text
                strCmd.Parameters.Add("@Date", SqlDbType.SmallDateTime, 8)
                strCmd.Parameters("@Date").Direction = ParameterDirection.Input
                strcmd.CommandTimeout = 60 * 60 * 1
                Dim ds As New DataSet()
                Dim da As New SqlClient.SqlDataAdapter(strCmd)
                Try
                    strCmd.Parameters("@Date").Value = CDate(PHLDate)
                    strcmd.Connection.Open()
                    strcmd.ExecuteNonQuery()
                    strcmd.Connection.Close()
                    strcmd.CommandText = "wap.dbo.mm_sp_PHLGEN_WheelSets"
                    strCmd.CommandType = CommandType.StoredProcedure
                    da.Fill(ds, "Wheelsets1")
                    If ds.Tables("Wheelsets1").Rows.Count > 0 Then
                        message = updtWheelsets(ds.Tables("Wheelsets1"), strCmd.Parameters("@Date").Value)
                        blnDone = message = "Generated"
                    End If
                    dr = dt.NewRow
                    dr("GenListItemsNo") = "9"
                    dr("Selected") = Not blnDone
                    dt.Rows.Add(dr)
                Catch exp As Exception
                    Throw New Exception(exp.Message)
                    blnDone = False
                Finally
                    da.Dispose()
                    strCmd.Dispose()
                End Try
                da = Nothing
                ds = Nothing
                strcmd = Nothing
            End If


            If chkGenListItems8 = True Then
                blnDone = False
                Dim strCmd As New SqlClient.SqlCommand("wap.dbo.mm_sp_PHLGEN_ams_loose_axles_available", New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con")))
                strcmd.CommandText = "delete from mm_PHLGEN_ams_loose_axles_available where phl_date = @Date"
                strCmd.CommandType = CommandType.Text
                strCmd.Parameters.Add("@Date", SqlDbType.SmallDateTime, 8)
                strCmd.Parameters("@Date").Direction = ParameterDirection.Input
                strcmd.CommandTimeout = 60 * 60 * 1
                Dim ds As New DataSet()
                Dim da As New SqlClient.SqlDataAdapter(strCmd)
                Try
                    strCmd.Parameters("@Date").Value = CDate(PHLDate)
                    strcmd.Connection.Open()
                    strcmd.ExecuteNonQuery()
                    strcmd.Connection.Close()
                    strcmd.CommandText = "wap.dbo.mm_sp_PHLGEN_ams_loose_axles_available"
                    strCmd.CommandType = CommandType.StoredProcedure
                    da.Fill(ds, "LooseAxlesAvailable")
                    If ds.Tables("LooseAxlesAvailable").Rows.Count > 0 Then
                        message = updtLooseAxlesAvailable(ds.Tables("LooseAxlesAvailable"), strCmd.Parameters("@Date").Value)
                        blnDone = message = "Generated"
                    End If
                    dr = dt.NewRow
                    dr("GenListItemsNo") = "8"
                    dr("Selected") = Not blnDone
                    dt.Rows.Add(dr)
                Catch exp As Exception
                    Throw New Exception(exp.Message)
                    blnDone = False
                Finally
                    da.Dispose()
                    strCmd.Dispose()
                End Try
                da = Nothing
                ds = Nothing
                strcmd = Nothing
            End If

            If chkGenListItems7 = True Then
                blnDone = False
                Dim strCmd As New SqlClient.SqlCommand("wap.dbo.mm_sp_PHLGEN_AxleShop_numbers_units", New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con")))
                strcmd.CommandText = "delete from mm_PHLGEN_AxleShop_numbers_units where phl_date = @Date"
                strcmd.CommandType = CommandType.Text
                strCmd.Parameters.Add("@Date", SqlDbType.SmallDateTime, 8)
                strCmd.Parameters("@Date").Direction = ParameterDirection.Input
                strcmd.CommandTimeout = 60 * 60 * 1
                Dim ds As New DataSet()
                Dim da As New SqlClient.SqlDataAdapter(strCmd)
                Try
                    strCmd.Parameters("@Date").Value = CDate(PHLDate)
                    strcmd.Connection.Open()
                    strcmd.ExecuteNonQuery()
                    strcmd.Connection.Close()
                    strcmd.CommandText = "wap.dbo.mm_sp_PHLGEN_AxleShop_numbers_units"
                    strCmd.CommandType = CommandType.StoredProcedure
                    da.Fill(ds, "AxleShopProudction")
                    If ds.Tables("AxleShopProudction").Rows.Count > 0 Then
                        message = updtAxleShopProudction(ds.Tables("AxleShopProudction"), strCmd.Parameters("@Date").Value)
                        blnDone = message = "Generated"
                    End If
                    dr = dt.NewRow
                    dr("GenListItemsNo") = "7"
                    dr("Selected") = Not blnDone
                    dt.Rows.Add(dr)
                Catch exp As Exception
                    Throw New Exception(exp.Message)
                    blnDone = False
                Finally
                    da.Dispose()
                    strCmd.Dispose()
                End Try
                da = Nothing
                ds = Nothing
                strcmd = Nothing
            End If

            If chkGenListItems6 = True Then
                blnDone = False
                Dim strCmd As New SqlClient.SqlCommand("wap.dbo.mm_si_sp_PHLGEN_WheelShop_FloorBalance", New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con")))
                strcmd.CommandText = "delete from mm_PHLGEN_WheelShop_FloorBalance where phl_date = @Date"
                strCmd.CommandType = CommandType.Text
                strCmd.Parameters.Add("@Date", SqlDbType.SmallDateTime, 8)
                strCmd.Parameters("@Date").Direction = ParameterDirection.Input
                strcmd.CommandTimeout = 60 * 60 * 1
                Dim ds As New DataSet()
                Dim da As New SqlClient.SqlDataAdapter(strCmd)
                Try
                    strCmd.Parameters("@Date").Value = CDate(PHLDate)
                    strcmd.Connection.Open()
                    Dim delRecs As Integer
                    delRecs = strcmd.ExecuteNonQuery()

                    strcmd.Connection.Close()
                    strcmd.CommandText = "wap.dbo.mm_si_sp_PHLGEN_WheelShop_FloorBalance"
                    strCmd.CommandType = CommandType.StoredProcedure
                    da.Fill(ds, "WheelBalance")
                    If ds.Tables("WheelBalance").Rows.Count > 0 Then
                        message = updtWheelBalance(ds.Tables("WheelBalance"), strCmd.Parameters("@Date").Value)
                        blnDone = message = "Generated"
                    End If
                    dr = dt.NewRow
                    dr("GenListItemsNo") = "6"
                    dr("Selected") = Not blnDone
                    dt.Rows.Add(dr)
                Catch exp As Exception
                    Throw New Exception(exp.Message)
                    blnDone = False
                Finally
                    da.Dispose()
                    strCmd.Dispose()
                End Try
                da = Nothing
                ds = Nothing
                strcmd = Nothing
            End If


            If chkGenListItems5 = True Then
                blnDone = False
                Dim strCmd As New SqlClient.SqlCommand("wap.dbo.mm_sp_PHLGEN_DespatchedWheels", New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con")))
                strcmd.CommandText = "delete from mm_PHLGEN_DespatchedWheels where phl_date = @Date"
                strCmd.CommandType = CommandType.Text
                strCmd.Parameters.Add("@Date", SqlDbType.SmallDateTime, 8)
                strCmd.Parameters("@Date").Direction = ParameterDirection.Input
                strcmd.CommandTimeout = 60 * 60 * 1
                Dim ds As New DataSet()
                Dim da As New SqlClient.SqlDataAdapter(strCmd)
                Try
                    strCmd.Parameters("@Date").Value = CDate(PHLDate)
                    strcmd.Connection.Open()
                    strcmd.ExecuteNonQuery()
                    strcmd.Connection.Close()
                    strcmd.CommandText = "wap.dbo.mm_sp_PHLGEN_DespatchedWheels"
                    strCmd.CommandType = CommandType.StoredProcedure
                    da.Fill(ds, "DespatchedWheels")
                    If ds.Tables("DespatchedWheels").Rows.Count > 0 Then
                        message = updtDespatchedWheels(ds.Tables("DespatchedWheels"), strCmd.Parameters("@Date").Value)
                        blnDone = message = "Generated"
                    End If
                    dr = dt.NewRow
                    dr("GenListItemsNo") = "5"
                    dr("Selected") = Not blnDone
                    dt.Rows.Add(dr)
                Catch exp As Exception
                    Throw New Exception(exp.Message)
                    blnDone = False
                Finally
                    da.Dispose()
                    strCmd.Dispose()
                End Try
                da = Nothing
                ds = Nothing
                strcmd = Nothing
            End If

            If chkGenListItems4 = True Then
                blnDone = False
                Dim strCmd As New SqlClient.SqlCommand("wap.dbo.mm_sp_PHLGEN_DespatchedAxle", New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con")))
                strcmd.CommandText = "delete from mm_PHLGEN_DespatchedAxles where phl_date = @Date"
                strCmd.CommandType = CommandType.Text
                strCmd.Parameters.Add("@Date", SqlDbType.SmallDateTime, 8)
                strCmd.Parameters("@Date").Direction = ParameterDirection.Input
                strcmd.CommandTimeout = 60 * 60 * 1
                Dim ds As New DataSet()
                Dim da As New SqlClient.SqlDataAdapter(strCmd)
                Try
                    strCmd.Parameters("@Date").Value = CDate(PHLDate)
                    strcmd.Connection.Open()
                    strcmd.ExecuteNonQuery()
                    strcmd.Connection.Close()
                    strCmd.CommandType = CommandType.StoredProcedure
                    strcmd.CommandText = "wap.dbo.mm_sp_PHLGEN_DespatchedAxle"
                    da.Fill(ds, "DespatchedAxles")
                    If ds.Tables("DespatchedAxles").Rows.Count > 0 Then
                        message = updtDespatchedAxles(ds.Tables("DespatchedAxles"), strCmd.Parameters("@Date").Value)
                        blnDone = message = "Generated"
                    End If
                    dr = dt.NewRow
                    dr("GenListItemsNo") = "4"
                    dr("Selected") = Not blnDone
                    dt.Rows.Add(dr)
                Catch exp As Exception
                    Throw New Exception(exp.Message)
                    blnDone = False
                Finally
                    da.Dispose()
                    strCmd.Dispose()
                End Try
                da = Nothing
                ds = Nothing
                strcmd = Nothing
            End If


            If chkGenListItems3 = True Then
                blnDone = False
                Dim strCmd As New SqlClient.SqlCommand("wap.dbo.mm_sp_PHLGEN_DespatchedWheelSets", New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con")))
                strcmd.CommandText = "delete from mm_PHLGEN_DespatchedWheelSets where phl_date = @Date"
                strCmd.CommandType = CommandType.Text
                strCmd.Parameters.Add("@Date", SqlDbType.SmallDateTime, 8)
                strCmd.Parameters("@Date").Direction = ParameterDirection.Input
                strcmd.CommandTimeout = 60 * 60 * 1
                Dim ds As New DataSet()
                Dim da As New SqlClient.SqlDataAdapter(strCmd)
                Try
                    strCmd.Parameters("@Date").Value = CDate(PHLDate)
                    strcmd.Connection.Open()
                    strcmd.ExecuteNonQuery()
                    strcmd.Connection.Close()
                    strcmd.CommandText = "wap.dbo.mm_sp_PHLGEN_DespatchedWheelSets"
                    strCmd.CommandType = CommandType.StoredProcedure
                    da.Fill(ds, "DespatchedSets")
                    If ds.Tables("DespatchedSets").Rows.Count > 0 Then
                        message = updtDespatchedSets(ds.Tables("DespatchedSets"), strCmd.Parameters("@Date").Value)
                        blnDone = message = "Generated"
                    End If
                    dr = dt.NewRow
                    dr("GenListItemsNo") = "3"
                    dr("Selected") = Not blnDone
                    dt.Rows.Add(dr)
                Catch exp As Exception
                    Throw New Exception(exp.Message)
                    blnDone = False
                Finally
                    da.Dispose()
                    strCmd.Dispose()
                End Try
                da = Nothing
                ds = Nothing
                strcmd = Nothing
            End If
            ' march 08 patch
            ' From 12-03-08 cast wheel counting logic changed from 00 - 00 hrs to 06-05:59:00 hrs
            ' Wheels of 1-03-08 from 00 hrs to 5:59 were not counting in February cast total and 
            ' got skipped in March 08 cast total due this logic change.  CME/W instructed to add
            ' those 158 wheels to monthly cumulative for March 08.
            ' Hence this patch written w.e.f. 13-03-2008
            '
            If blnDone Then
                blnDone = False
                Dim strDelete As String = "delete mm_phlgen_March08_Patch where phl_date = @phlDate"
                Dim strExecute As String = "mm_sp_phlgen_March08_Patch"
                Dim blnPathDone As Boolean = False
                Dim strCmd As New SqlClient.SqlCommand()
                strcmd.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
                strcmd.Parameters.Add("@PhlDate", SqlDbType.SmallDateTime, 4)
                strcmd.Parameters("@PhlDate").Direction = ParameterDirection.Input
                strcmd.Parameters("@PhlDate").Value = CDate(PHLDate)
                strcmd.Parameters.Add("@Message", SqlDbType.VarChar, 50)
                strcmd.Parameters("@Message").Direction = ParameterDirection.Output
                Try
                    strcmd.Connection.Open()
                    strcmd.Transaction = strcmd.Connection.BeginTransaction
                    strcmd.CommandText = strDelete
                    strcmd.CommandType = CommandType.Text
                    strcmd.ExecuteNonQuery()
                    strcmd.CommandText = strExecute
                    strcmd.CommandType = CommandType.StoredProcedure
                    strcmd.ExecuteNonQuery()
                    blnPathDone = True
                Catch exp As Exception
                    Throw New Exception(". March_08 Patch Error : " & exp.Message)
                    blnPathDone = False
                Finally
                    If IsNothing(strcmd) = False Then
                        If blnPathDone Then
                            strcmd.Transaction.Commit()
                        Else
                            strcmd.Transaction.Rollback()
                        End If
                        If strcmd.Connection.State = ConnectionState.Open Then strcmd.Connection.Close()
                        strcmd.Dispose()
                    End If
                    strcmd = Nothing
                End Try
            End If
            Return dt
        End Function
        Public Function PCORemarksEdit(ByVal rdoDataHead As String, ByVal rblProdAffect As Boolean, ByVal MaintGrp As String, ByVal MemoNumber As Double, ByVal BreakFromTime As DateTime, ByVal OriginalData As String, ByVal NewData As String, ByVal EmpCode As String, ByVal HeatNo As Double, ByVal rdoMeltOrPourRems As Integer) As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim blnSaved As Boolean
            Try
                cmd.Parameters.Add("@rblProdAffect", SqlDbType.Bit, 1).Value = rblProdAffect
                cmd.Parameters.Add("@HeatNo", SqlDbType.BigInt, 8).Value = HeatNo
                cmd.Parameters.Add("@GroupName", SqlDbType.VarChar, 50).Value = MaintGrp
                cmd.Parameters.Add("@MemoNumber", SqlDbType.BigInt, 8).Value = MemoNumber
                cmd.Parameters.Add("@breakdown_from_time", SqlDbType.DateTime, 8).Value = BreakFromTime
                cmd.Parameters.Add("@OriginalRemarks", SqlDbType.VarChar, 5000).Value = OriginalData
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 5000).Value = NewData
                cmd.Parameters.Add("@ChangedBy", SqlDbType.VarChar, 50).Value = EmpCode
                cmd.Parameters.Add("@Changedtime", SqlDbType.SmallDateTime, 4).Value = CDate(Now)
                blnSaved = True
            Catch exp As Exception
                Throw New Exception(exp.Message)
            End Try
            If blnSaved = False Then
                Exit Function
            End If
            If blnSaved Then
                blnSaved = False
            End If
            Try
                cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                If rdoDataHead.StartsWith("Exce") Then
                    If rdoMeltOrPourRems = 0 Then cmd.CommandText = "insert into mm_Pco_PreModifiedPhlData (GroupName, InfoHead , RefNo, OriginalRemarks , ChangedBy, changedTime ) values (@GroupName, 'EXPNHEAT' , @HeatNo , @OriginalRemarks , @ChangedBy, @changedTime)"
                    If rdoMeltOrPourRems = 1 Then cmd.CommandText = "insert into mm_Pco_PreModifiedPhlData(GroupName, InfoHead, RefNo, OriginalRemarks, ChangedBy, ChangedTime) select '', 'EXPNPOSTPOURING' , HEAT_NUMBER, REMARKS, @CHANGEDBY, @CHANGEDTIME FROM MM_POST_POURING WHERE HEAT_NUMBER = @HeatNo "
                    If cmd.ExecuteNonQuery > 0 Then
                        If rdoMeltOrPourRems = 0 Then cmd.CommandText = "update mm_post_melt set hea_rem = @Remarks where heat_number = @HeatNo "
                        If rdoMeltOrPourRems = 1 Then cmd.CommandText = "update mm_post_pouring set remarks =@Remarks where heat_number = @HeatNo "
                        If cmd.ExecuteNonQuery > 0 Then
                            blnSaved = True
                        End If
                    End If
                ElseIf rdoDataHead.StartsWith("Break") Then
                    cmd.CommandText = "INSERT INTO mm_Pco_PreModifiedPhlData select b.maintenance_group, 'BRKDTL', b.memo_number, b.breakdown_code, @ChangedBy, @ChangedTime from ms_breakdown_memo a inner join ms_breakdown_details b on a.maintenance_group = b.maintenance_group and a.memo_number = b.memo_number where a.memo_number = @MemoNumber and a.maintenance_group = @GroupName"
                    If cmd.ExecuteNonQuery > 0 Then
                        cmd.CommandText = "insert into mm_Pco_PreModifiedPhlData (GroupName, InfoHead , RefNo, OriginalRemarks , ChangedBy, ChangedTime) values (@GroupName, 'BRKMEMO' , @MemoNumber, @OriginalRemarks , @ChangedBy, @ChangedTime)"
                        If cmd.ExecuteNonQuery > 0 Then
                            If rblProdAffect Then
                                cmd.CommandText = "update ms_breakdown_memo set breakdown_from_time = @breakdown_from_time , production_affected = @rblProdAffect , remarks = @Remarks where maintenance_group = @GroupName and memo_number = @MemoNumber"
                                If cmd.ExecuteNonQuery > 0 Then
                                    cmd.CommandText = "update ms_breakdown_details set breakdown_code = 'REMOVED' where maintenance_group = @GroupName and memo_number = @MemoNumber"
                                    If cmd.ExecuteNonQuery > 0 Then
                                        blnSaved = True
                                    End If
                                End If
                            Else
                                cmd.CommandText = "update ms_breakdown_details set breakdown_code = 'REMOVED' where maintenance_group = @GroupName and memo_number = @MemoNumber"
                                If cmd.ExecuteNonQuery > 0 Then
                                    blnSaved = True
                                End If
                            End If
                        End If
                    End If
                End If
            Catch exp As Exception
                blnSaved = False
                Throw New Exception(exp.Message)
            Finally
                If IsNothing(cmd.Transaction) = False Then
                    If blnSaved Then
                        cmd.Transaction.Commit()
                    Else
                        cmd.Transaction.Rollback()
                    End If
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                End If
                cmd = Nothing
            End Try
            Return blnSaved
        End Function
        Public Function SavePHLPosition(ByVal PositionFor As Date, ByVal WorkingDays As Integer, ByVal RoughTurnTargetShifts As Integer, ByVal RoughTurnActualShifts As Integer, ByVal RoughTurnCumTargetShifts As Integer, ByVal RoughTurnCumActualShifts As Integer, ByVal ShiftTargetOLD As Integer, ByVal ShiftActualOLD As Integer, ByVal ShiftTargetNEW As Integer, ByVal ShiftActualNEW As Integer, ByVal CumShiftTargetOLD As Integer, ByVal CumShiftActualOLD As Integer, ByVal CumShiftTargetNEW As Integer, ByVal CumShiftActualNEW As Integer, ByVal DayTotalForged As Integer, ByVal MonthTotalForged As Integer, ByVal AxlesRoughTurnedDay As Integer, ByVal CumAxlesRoughTurned As Integer, ByVal AAPRENEWDay As Integer, ByVal AAPRENEWCum As Integer, ByVal AAPREWHLDay As Integer, ByVal AAPREWHLCum As Integer, ByVal FromVISLDay As Integer, ByVal FromVISLMonth As Integer, ByVal FromMSFDay As Integer, ByVal FromMSFMonth As Integer, ByVal MachinedWheelsDay As Integer, ByVal MachinedWheelsMonth As Integer, ByVal Remarks As String) As Boolean
            Dim blnCheck As Boolean
            Dim da As SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            da = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "select *  from mm_PHL_Position where PositionFor  = @PositionFor "
            da.SelectCommand.Parameters.Add("@PositionFor", SqlDbType.SmallDateTime, 4).Value = CDate(PositionFor)
            Try
                da.Fill(ds)
                If ds.Tables(0).Rows.Count = 0 Then
                    blnCheck = True
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                da = Nothing
                ds = Nothing
            End Try
            Dim strInsert, strUpdate As String
            Dim oCmd As SqlClient.SqlCommand
            oCmd = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@PositionFor", SqlDbType.SmallDateTime, 4).Value = CDate(PositionFor)
            oCmd.Parameters.Add("@WorkingDays", SqlDbType.Int, 4).Value = Val(WorkingDays)
            oCmd.Parameters.Add("@RoughTurnTargetShifts", SqlDbType.Int, 4).Value = Val(RoughTurnTargetShifts)
            oCmd.Parameters.Add("@RoughTurnActualShifts", SqlDbType.Int, 4).Value = Val(RoughTurnActualShifts)
            oCmd.Parameters.Add("@RoughTurnCumTargetShifts", SqlDbType.Int, 4).Value = Val(RoughTurnCumTargetShifts)
            oCmd.Parameters.Add("@RoughTurnCumActualShifts", SqlDbType.Int, 4).Value = Val(RoughTurnCumActualShifts)
            oCmd.Parameters.Add("@ShiftTargetOLD", SqlDbType.Int, 4).Value = Val(ShiftTargetOLD)
            oCmd.Parameters.Add("@ShiftActualOLD", SqlDbType.Int, 4).Value = Val(ShiftActualOLD)
            oCmd.Parameters.Add("@ShiftTargetNEW", SqlDbType.Int, 4).Value = Val(ShiftTargetNEW)
            oCmd.Parameters.Add("@ShiftActualNEW", SqlDbType.Int, 4).Value = Val(ShiftActualNEW)
            oCmd.Parameters.Add("@CumShiftTargetOLD", SqlDbType.Int, 4).Value = Val(CumShiftTargetOLD)
            oCmd.Parameters.Add("@CumShiftActualOLD", SqlDbType.Int, 4).Value = Val(CumShiftActualOLD)
            oCmd.Parameters.Add("@CumShiftTargetNEW", SqlDbType.Int, 4).Value = Val(CumShiftTargetNEW)
            oCmd.Parameters.Add("@CumShiftActualNEW", SqlDbType.Int, 4).Value = Val(CumShiftActualNEW)
            oCmd.Parameters.Add("@DayTotalForged", SqlDbType.Int, 4).Value = Val(DayTotalForged)
            oCmd.Parameters.Add("@MonthTotalForged", SqlDbType.Int, 4).Value = Val(MonthTotalForged)
            oCmd.Parameters.Add("@AxlesRoughTurnedDay", SqlDbType.Int, 4).Value = Val(AxlesRoughTurnedDay)
            oCmd.Parameters.Add("@CumAxlesRoughTurned", SqlDbType.Int, 4).Value = Val(CumAxlesRoughTurned)
            oCmd.Parameters.Add("@AAPRENEWDay", SqlDbType.Int, 4).Value = Val(AAPRENEWDay)
            oCmd.Parameters.Add("@AAPRENEWCum", SqlDbType.Int, 4).Value = Val(AAPRENEWCum)
            oCmd.Parameters.Add("@AAPREWHLDay", SqlDbType.Int, 4).Value = Val(AAPREWHLDay)
            oCmd.Parameters.Add("@AAPREWHLCum", SqlDbType.Int, 4).Value = Val(AAPREWHLCum)
            oCmd.Parameters.Add("@FromVISLDay", SqlDbType.Int, 4).Value = Val(FromVISLDay)
            oCmd.Parameters.Add("@FromVISLMonth", SqlDbType.Int, 4).Value = Val(FromVISLMonth)
            oCmd.Parameters.Add("@FromMSFDay", SqlDbType.Int, 4).Value = Val(FromMSFDay)
            oCmd.Parameters.Add("@FromMSFMonth", SqlDbType.Int, 4).Value = Val(FromMSFMonth)
            oCmd.Parameters.Add("@MachinedWheelsDay", SqlDbType.Int, 4).Value = Val(MachinedWheelsDay)
            oCmd.Parameters.Add("@MachinedWheelsMonth", SqlDbType.Int, 4).Value = Val(MachinedWheelsMonth)
            oCmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = Remarks


            strInsert = " insert into mm_PHL_Position   " &
                    " ( PositionFor , WorkingDays , RoughTurnTargetShifts , RoughTurnActualShifts , RoughTurnCumTargetShifts , RoughTurnCumActualShifts , " &
                    " ShiftTargetOLD , ShiftActualOLD , ShiftTargetNEW , ShiftActualNEW , CumShiftTargetOLD , CumShiftActualOLD ,  " &
                    " CumShiftTargetNEW , CumShiftActualNEW , DayTotalForged , MonthTotalForged , AxlesRoughTurnedDay ,  " &
                    " CumAxlesRoughTurned , AAPRENEWDay , AAPRENEWCum , AAPREWHLDay , AAPREWHLCum , FromVISLDay , FromVISLMonth , FromMSFDay , FromMSFMonth , MachinedWheelsDay , MachinedWheelsMonth , Remarks )  " &
                    " values ( @PositionFor , @WorkingDays , @RoughTurnTargetShifts , @RoughTurnActualShifts , @RoughTurnCumTargetShifts ,   " &
                    " @RoughTurnCumActualShifts , @ShiftTargetOLD , @ShiftActualOLD , @ShiftTargetNEW , @ShiftActualNEW , @CumShiftTargetOLD  " &
                    "  , @CumShiftActualOLD , @CumShiftTargetNEW , @CumShiftActualNEW , @DayTotalForged , @MonthTotalForged  " &
                    "  , @AxlesRoughTurnedDay , @CumAxlesRoughTurned , @AAPRENEWDay , @AAPRENEWCum , @AAPREWHLDay , @AAPREWHLCum  " &
                    "  , @FromVISLDay , @FromVISLMonth , @FromMSFDay , @FromMSFMonth , @MachinedWheelsDay , @MachinedWheelsMonth , @Remarks )"

            strUpdate = " update mm_PHL_Position   " &
                    " set WorkingDays = @WorkingDays , RoughTurnTargetShifts = @RoughTurnTargetShifts , " &
                    " RoughTurnActualShifts = @RoughTurnActualShifts , RoughTurnCumTargetShifts = @RoughTurnCumTargetShifts " &
                    " , RoughTurnCumActualShifts = @RoughTurnCumActualShifts , " &
                    " ShiftTargetOLD = @ShiftTargetOLD , ShiftActualOLD = @ShiftActualOLD  , ShiftTargetNEW = @ShiftTargetNEW  " &
                    " , ShiftActualNEW = @ShiftActualNEW , CumShiftTargetOLD = @CumShiftTargetOLD , CumShiftActualOLD = @CumShiftActualOLD ,  " &
                    " CumShiftTargetNEW = @CumShiftTargetNEW , CumShiftActualNEW = @CumShiftActualNEW , DayTotalForged = @DayTotalForged " &
                    " , MonthTotalForged = @MonthTotalForged   , AxlesRoughTurnedDay = @AxlesRoughTurnedDay ,  " &
                    " CumAxlesRoughTurned = @CumAxlesRoughTurned , AAPRENEWDay = @AAPRENEWDay  , AAPRENEWCum = @AAPRENEWCum " &
                    " , AAPREWHLDay = @AAPREWHLDay , AAPREWHLCum = @AAPREWHLCum , FromVISLDay = @FromVISLDay  " &
                    " , FromVISLMonth = @FromVISLMonth , FromMSFDay = @FromMSFDay , FromMSFMonth = @FromMSFMonth , " &
                    " MachinedWheelsDay = @MachinedWheelsDay , MachinedWheelsMonth = @MachinedWheelsMonth , Remarks = @Remarks where  PositionFor = @PositionFor "
            Dim Done As Boolean
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                If blnCheck Then
                    oCmd.CommandText = strInsert
                Else
                    oCmd.CommandText = strUpdate
                End If
                If oCmd.ExecuteNonQuery = 1 Then
                    Done = True
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
            Return Done
        End Function
        Public Function UpdateUserPassword(ByVal NewPassword As String, ByVal UserID As String) As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim Done As Boolean
            Try
                cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                cmd.CommandText = "Update menu_your_password SET password = '" & NewPassword.Trim & "' WHERE application = 'MMS' and group_code = 'PCOPCO' and employee_code = '" & UserID & "'"
                If cmd.ExecuteNonQuery = 1 Then Done = True
            Catch exp As Exception
                Done = False
                Throw New Exception(exp.Message)
            Finally
                If IsNothing(cmd) = False Then
                    If Done Then
                        cmd.Transaction.Commit()
                    Else
                        cmd.Transaction.Rollback()
                    End If
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                End If
            End Try
            Return Done
        End Function
        Public Function ManualRMR(ByVal Workorder As String, ByVal Shop_code As String, ByVal plnumber As String, ByVal status As String, ByVal route_code As String, ByVal route_seq As String, ByVal INTQty As Decimal, ByVal userid As String) As DataTable
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim ds As New DataSet()
            Dim da As New SqlClient.SqlDataAdapter(cmd)
            cmd.Parameters.Add("@Workorder", SqlDbType.VarChar, 10).Value = Workorder
            cmd.Parameters.Add("@Shop_code", SqlDbType.VarChar, 10).Value = Shop_code
            cmd.Parameters.Add("@plnumber", SqlDbType.VarChar, 20).Value = plnumber
            cmd.Parameters.Add("@status", SqlDbType.VarChar, 10).Value = status
            cmd.Parameters.Add("@route_code", SqlDbType.VarChar, 10).Value = route_code
            cmd.Parameters.Add("@route_seq", SqlDbType.VarChar, 10).Value = route_seq
            cmd.Parameters.Add("@INTQty", SqlDbType.Float, 8).Value = CDbl(INTQty)
            cmd.Parameters.Add("@userid", SqlDbType.VarChar, 10).Value = userid
            Try
                cmd.Connection.Open()
                cmd.CommandText = "mm_sp_manual_rmr_generation"
                cmd.CommandType = CommandType.StoredProcedure
                da.Fill(ds, "ManualRMR")
                If ds.Tables("ManualRMR").Rows.Count > 0 Then
                    Return ds.Tables("ManualRMR")
                Else
                    Return Nothing
                End If
            Catch exp As Exception
                ManualRMR = Nothing
                Throw New Exception(exp.Message)
            Finally
                cmd.Connection.Close()
                cmd.Dispose()
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
                cmd = Nothing
            End Try
        End Function
        Public Function GenerateRMR(ByVal WO As String, ByVal RMRDate As Date) As String
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim Message As String
            Dim Done As Boolean
            Try
                cmd.Parameters.Add("@WorkOrder", SqlDbType.VarChar, 50).Value = WO
                cmd.Parameters.Add("@RMRDate", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output
                cmd.Parameters.Add("@Message", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                cmd.CommandText = "select @RMRDate = start_date from mm_workorder where number = @WorkOrder"
                cmd.ExecuteScalar()
                cmd.Parameters("@RMRDate").Direction = ParameterDirection.Input
                If cmd.Parameters("@RMRDate").Value < RMRDate Then
                    cmd.Parameters("@RMRDate").Value = RMRDate
                End If
                cmd.CommandText = "mm_sp_RMRGeneration" 'mm_sp_rmr_generation
                cmd.CommandType = CommandType.StoredProcedure
                cmd.ExecuteNonQuery()
                Message = cmd.Parameters("@Message").Value
                If Message.StartsWith("RMRs generated for workorder") Or Message.StartsWith("The RMR has already been generated For Workorder") Then
                    Done = True
                End If
            Catch exp As Exception
                Done = False
                Throw New Exception(exp.Message)
            Finally
                If IsNothing(cmd) = False Then
                    If Done Then
                        cmd.Transaction.Commit()
                    Else
                        cmd.Transaction.Rollback()
                    End If
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                End If
            End Try
            Return Message
        End Function
        Public Function UpdateStPipe(ByVal WO As String, ByVal rdoStopperPipeItems0Selected As Boolean, ByVal rdoStopperPipeItems1Selected As Boolean, ByVal rdoStopperPipeItems0 As String, ByVal rdoStopperPipeItems1 As String) As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim sqlstr1, sqlstr2 As String
            Dim GenerateRMR As Boolean
            Try
                cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                If rdoStopperPipeItems0Selected = True Then
                    cmd.CommandText = "select product_code from mm_workorder where number = '" & WO.Trim & "'"
                    If cmd.ExecuteScalar = "210145" Then
                        Throw New Exception("You have selected Wrong Pl Number for this product")
                        Exit Try
                    End If
                    sqlstr1 = "update mm_bill_of_material set status = 'S' where product_code = '120120' and pl_number = '" & rdoStopperPipeItems1.Trim & "'"
                    sqlstr2 = "update mm_bill_of_material set status = 'Y' where product_code = '120120' and pl_number = '" & rdoStopperPipeItems0.Trim & "'"
                End If
                If rdoStopperPipeItems1Selected = True Then
                    cmd.CommandText = "select product_code from mm_workorder where number = '" & WO.Trim & "'"
                    If cmd.ExecuteScalar <> "210145" Then
                        Throw New Exception("You have selected Wrong Pl Number for this product")
                        Exit Try
                    End If
                    sqlstr1 = "update mm_bill_of_material set status = 'S' where product_code = '120120' and pl_number = '" & rdoStopperPipeItems0.Trim & "'"
                    sqlstr2 = "update mm_bill_of_material set status = 'Y' where product_code = '120120' and pl_number = '" & rdoStopperPipeItems1.Trim & "'"
                End If

#Disable Warning BC42104 ' Variable is used before it has been assigned a value
                cmd.CommandText = sqlstr1
#Enable Warning BC42104 ' Variable is used before it has been assigned a value
                cmd.ExecuteNonQuery()
#Disable Warning BC42104 ' Variable is used before it has been assigned a value
                cmd.CommandText = sqlstr2
#Enable Warning BC42104 ' Variable is used before it has been assigned a value
                cmd.ExecuteNonQuery()
                GenerateRMR = True
            Catch exp As Exception
                GenerateRMR = False
                Throw New Exception("Stopper Selection failed to be saved for : " & exp.Message)
            Finally
                If IsNothing(cmd) = False Then
                    If GenerateRMR Then
                        cmd.Transaction.Commit()
                    Else
                        cmd.Transaction.Rollback()
                    End If
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                End If
            End Try
            Return GenerateRMR
        End Function
        Public Function RegulateRMR(ByVal rblType As String, ByVal RmrNo As Integer) As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim Message As String
            Dim Done As Boolean
            Try
                If rblType = "suspend" Then
                    cmd.CommandText = "Update mm_rmr set status = 'Suspended' where number = @RmrNo "
                Else
                    cmd.CommandText = "Update mm_rmr set status = 'Open' where number = @RmrNo "
                End If
                cmd.Parameters.Add("@RmrNo", SqlDbType.Int, 4).Value = RmrNo
                cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                If cmd.ExecuteNonQuery() > 0 Then Done = True
            Catch exp As Exception
                Done = False
                Throw New Exception(exp.Message)
            Finally
                If IsNothing(cmd) = False Then
                    If Done Then
                        cmd.Transaction.Commit()
                    Else
                        cmd.Transaction.Rollback()
                    End If
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                End If
            End Try
            Return Done
        End Function
        Public Function ChangeProduct(ByVal txtWorkOrder As String, ByVal txtProductCode As String, ByVal lblEmpCode As String, ByVal txtWoQty As Integer, ByVal lblSlNo As Integer) As Boolean
            Dim strInsertLateWo, strCheckLateWo, strInsertWo As String
            strCheckLateWo = "select count(*) from mm_workorder_late where number = @number"
            strInsertLateWo = "Insert into mm_workorder_late  (number, workorder_date, GenBy, GenDate ) values ( @number, @workorder_date, @GenBy, @GenDate)"
            strInsertWo = "Insert into mm_workorder (number, control_number, product_code, Description, route_code, shop_code, cost_center_code, workorder_date, workorder_quantity, start_date, start_shift, end_date, end_shift, status , rmr_generated_qty ) values (@number, @control_number, @product_code, @Description, @route_code, @shop_code, @cost_center_code, @workorder_date, @workorder_quantity, @start_date, @start_shift, @end_date, @end_shift, @status , @rmr_generated_qty )"
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.CommandText = "select @CostCenterCode = CostCenterCode, @stdt = stDate, @endDt = endDate, @ShopCode = ShopCode, @woDate = woDate, @ControlNumber = ControlNumber, @Descr = Descr  from mm_fn_getDetailsForLateWo( @number, @ProdCode) "
            cmd.Parameters.Add("@number", SqlDbType.VarChar, 4).Value = txtWorkOrder
            cmd.Parameters.Add("@ProdCode", SqlDbType.VarChar, 6).Value = txtProductCode
            cmd.Parameters.Add("@stDt", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output
            cmd.Parameters.Add("@endDt", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output
            cmd.Parameters.Add("@ShopCode", SqlDbType.VarChar, 2).Direction = ParameterDirection.Output
            cmd.Parameters.Add("@ControlNumber", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            cmd.Parameters.Add("@Descr", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            cmd.Parameters.Add("@woDate", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output
            cmd.Parameters.Add("@CostCenterCode", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            Dim blnDone As Boolean

            Dim dStartDt, dEndDt, dWoDt As Date
            Dim sShopCode, sControlNumber, sDescr, sCostCenterCode As String

            Try
                cmd.Connection.Open()
                cmd.ExecuteScalar()
                dStartDt = IIf(IsDBNull(cmd.Parameters("@stDt").Value), CDate("01/01/1900"), cmd.Parameters("@stDt").Value)
                dEndDt = IIf(IsDBNull(cmd.Parameters("@endDt").Value), CDate("01/01/1900"), cmd.Parameters("@endDt").Value)
                sShopCode = IIf(IsDBNull(cmd.Parameters("@ShopCode").Value), "", cmd.Parameters("@ShopCode").Value)
                dWoDt = IIf(IsDBNull(cmd.Parameters("@woDate").Value), CDate("01/01/1900"), cmd.Parameters("@woDate").Value)
                sControlNumber = IIf(IsDBNull(cmd.Parameters("@ControlNumber").Value), "", cmd.Parameters("@ControlNumber").Value)
                sDescr = IIf(IsDBNull(cmd.Parameters("@Descr").Value), "", cmd.Parameters("@Descr").Value)
                sCostCenterCode = IIf(IsDBNull(cmd.Parameters("@CostCenterCode").Value), "", cmd.Parameters("@CostCenterCode").Value)
            Catch exp As Exception
                dStartDt = CDate("01/01/1900")
                dEndDt = CDate("01/01/1900")
                sShopCode = ""
                blnDone = True
                Throw New Exception("Retrieval error : " & exp.Message)
            Finally
                If IsNothing(cmd) = False Then
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                End If
            End Try

            If blnDone Then
                If IsNothing(cmd) = False Then
                    cmd.Dispose()
                    cmd = Nothing
                    Exit Function
                End If
            Else
                blnDone = False
            End If

            cmd.Parameters.Add("@workorder_date", SqlDbType.SmallDateTime, 4).Value = dEndDt
            cmd.Parameters.Add("@GenBy", SqlDbType.VarChar, 6).Value = lblEmpCode
            cmd.Parameters.Add("@GenDate", SqlDbType.DateTime, 8).Value = CDate(Now)

            cmd.Parameters.Add("@control_number", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@product_code", SqlDbType.VarChar, 6)
            cmd.Parameters.Add("@Description", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@route_code", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@shop_code", SqlDbType.VarChar, 10)
            cmd.Parameters.Add("@cost_center_code", SqlDbType.VarChar, 10)
            cmd.Parameters.Add("@workorder_quantity", SqlDbType.Int, 4)
            cmd.Parameters.Add("@start_date", SqlDbType.SmallDateTime, 4)
            cmd.Parameters.Add("@end_date", SqlDbType.SmallDateTime, 4)
            cmd.Parameters.Add("@start_shift", SqlDbType.VarChar, 1)
            cmd.Parameters.Add("@end_shift", SqlDbType.VarChar, 1)
            cmd.Parameters.Add("@status", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@rmr_generated_qty", SqlDbType.Int, 4)

            Try
                cmd.Parameters("@number").Value = txtWorkOrder
                cmd.Parameters("@workorder_date").Value = dWoDt
                cmd.Parameters("@GenBy").Value = lblEmpCode
                cmd.Parameters("@GenDate").Value = CDate(Now)

                cmd.Parameters("@control_number").Value = sControlNumber
                cmd.Parameters("@product_code").Value = txtProductCode
                cmd.Parameters("@Description").Value = sDescr
                cmd.Parameters("@route_code").Value = "01"
                cmd.Parameters("@shop_code").Value = sShopCode
                cmd.Parameters("@cost_center_code").Value = sCostCenterCode
                cmd.Parameters("@workorder_quantity").Value = txtWoQty
                cmd.Parameters("@start_date").Value = dStartDt
                cmd.Parameters("@end_date").Value = dEndDt
                cmd.Parameters("@start_shift").Value = "A"
                cmd.Parameters("@end_shift").Value = "C"
                cmd.Parameters("@status").Value = "Open"
                cmd.Parameters("@rmr_generated_qty").Value = 0
                cmd.Parameters.Add("@SlNo", SqlDbType.Int, 4).Value = Val(lblSlNo)
                blnDone = True
            Catch exp As Exception
                Throw New Exception("Value assignment error: " & exp.Message)
            End Try
            If blnDone = False Then
                If IsNothing(cmd) = False Then
                    cmd.Dispose()
                    cmd = Nothing
                    Exit Function
                End If
            Else
                blnDone = False
            End If
            Try
                cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                cmd.CommandText = strCheckLateWo
                If cmd.ExecuteScalar > 0 Then
                    cmd.CommandText = "update mm_workorder set workorder_quantity = @workorder_quantity where number = @number"
                    If cmd.ExecuteNonQuery = 1 Then
                        cmd.CommandText = "update mm_workorder_late set GenDate = @GenDate where number = @number and SlNo = @SlNo"
                        blnDone = True
                    Else
                        Throw New Exception("Late WO update error in work order table")
                    End If
                Else
                    cmd.CommandText = strInsertLateWo
                    If cmd.ExecuteNonQuery = 1 Then
                        cmd.CommandText = strInsertWo
                        If cmd.ExecuteNonQuery = 1 Then
                            blnDone = True
                        Else
                            Throw New Exception("late Work Order insert error in work order table")
                        End If
                    Else
                        Throw New Exception("Late WO insert error in late work order table")
                    End If
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If IsNothing(cmd) = False Then
                    If blnDone Then
                        If IsNothing(cmd.Transaction) = False Then cmd.Transaction.Commit()
                    Else
                        If IsNothing(cmd.Transaction) = False Then cmd.Transaction.Rollback()
                    End If
                    cmd.Dispose()
                    cmd = Nothing
                End If
            End Try
            Return blnDone
        End Function
        Public Function InsertAuthorisation(ByVal chkAutorisableItems As DataTable, ByVal Group As String, ByVal UserID As String, ByVal AuthorisationRemarks As String) As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim Message As String
            Dim Done As Boolean
            cmd.CommandText = "Insert into mm_MMS_Authorisations (AuthorisorLogin, AuthorisorEmpCode, AuthorisationDateTime, AuthorisedActivity, Remarks ) values (@AuthorisorLogin, @AuthorisorEmpCode, @AuthorisationDateTime, @AuthorisedActivity, @Remarks ) "
            cmd.Parameters.Add("@AuthorisorLogin", SqlDbType.VarChar, 50).Value = Group
            cmd.Parameters.Add("@AuthorisorEmpCode", SqlDbType.VarChar, 6).Value = UserID
            cmd.Parameters.Add("@AuthorisationDateTime", SqlDbType.DateTime, 8).Value = Now
            cmd.Parameters.Add("@AuthorisedActivity", SqlDbType.VarChar, 50).Direction = ParameterDirection.Input
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 5000).Value = AuthorisationRemarks
            Try
                Dim i As Integer
                For i = 0 To chkAutorisableItems.Rows.Count - 1
                    cmd.Parameters("@AuthorisedActivity").Value = chkAutorisableItems.Rows(i)(0)
                    If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                    If cmd.ExecuteNonQuery = 1 Then
                        Done = True
                    Else
                        Exit For
                    End If
                Next
            Catch exp As Exception
                Done = False
                Throw New Exception(exp.Message)
            Finally
                If IsNothing(cmd) = False Then
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                End If
            End Try
            Return Done
        End Function
    End Class
    Friend Class ModifyWoProduct
        Private dStartDate, dEndDate As Date
        Private sShopCode As String
        Private tblWorkorders As DataTable
        Private sProductCode As String
        Private tblShopCodes As DataTable
        Private oWorkOrder As WorkOrder
        Public Sub New()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "select Description, code from mm_shop order by Description"
            Dim ds As New DataSet()
            tblShopCodes = New DataTable()
            Try
                da.Fill(ds, "ShopList")
                tblShopCodes = ds.Tables("ShopList").Copy
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Sub
        ReadOnly Property ShopList() As DataTable
            Get
                Return tblShopCodes
            End Get
        End Property
        Property ProductCode() As String
            Get
                Return sProductCode
            End Get
            Set(ByVal Value As String)
                If ProductExists(Value) Then
                    sProductCode = Value
                Else
                    Throw New Exception("Product Code does not exist")
                End If
            End Set
        End Property
        Private Function ProductExists(ByVal ProdCode As String) As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.CommandText = "Select count(*) from mm_product_master where product_code = '" & ProdCode.Trim & "'"
            Try
                cmd.Connection.Open()
                If cmd.ExecuteScalar > 0 Then
                    ProductExists = True
                End If
            Catch exp As Exception
                Throw New Exception("Product Error : " & exp.Message)
            Finally
                If IsNothing(cmd) = False Then
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                End If
            End Try
        End Function
        Property StartDate() As Date
            Get
                Return dStartDate
            End Get
            Set(ByVal Value As Date)
                dStartDate = Value
            End Set
        End Property
        Property EndDate() As Date
            Get
                Return dEndDate
            End Get
            Set(ByVal Value As Date)
                dEndDate = Value
            End Set
        End Property
        Property ShopCode() As String
            Get
                Return sShopCode
            End Get
            Set(ByVal Value As String)
                If Value.ToUpper.Trim.Length > 0 Then
                    sShopCode = Value.ToUpper.Trim
                Else
                    Throw New Exception("Empty Shop code")
                End If
            End Set
        End Property
        ReadOnly Property WorkOrderList() As DataTable
            Get
                Try
                    WoTable()
                Catch exp As Exception
                    tblWorkorders = Nothing
                    Throw New Exception(exp.Message)
                End Try
                Return tblWorkorders
            End Get
        End Property
        Friend Function GetWoDetails(ByVal WoNumber As String) As WorkOrder
            Try
                oWorkOrder = New WorkOrder(WoNumber)
            Catch exp As Exception
                oWorkOrder = Nothing
                Throw New Exception("Wo Error : " & exp.Message)
            End Try
        End Function
        ReadOnly Property Wo() As WorkOrder
            Get
                Return oWorkOrder
            End Get
        End Property
        Private Sub WoTable()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = "Select Number, product_Code, Description from mm_workorder where shop_Code = '" & sShopCode & "' and start_date = @StartDate and End_Date = @EndDate order by Description"
            da.SelectCommand.Parameters.Add("@StartDate", SqlDbType.SmallDateTime, 4).Value = dStartDate
            da.SelectCommand.Parameters.Add("@EndDate", SqlDbType.SmallDateTime, 4).Value = dEndDate
            Try
                da.Fill(ds, "WoTbl")
                tblWorkorders = ds.Tables("WoTbl").Copy
                tblWorkorders.TableName = "WoTbl"
            Catch exp As Exception
                tblWorkorders = Nothing
                Throw New Exception("Wo Table Error : " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Sub
        Public Function ProductModify(ByVal NewProductCode As String, ByVal EmpCode As String, ByVal WoNumber As String, ByVal StartDate As Date, ByVal EndDate As Date, ByVal ProductCodeOriginal As String, ByVal AuthorisationInfo As String) As Boolean
            Dim sBkupWoRecord As String
            Dim sUpdtWoRecord As String
            sBkupWoRecord = "insert into mm_workorder_ProductModified select *, @ModifiedBy, @ModifiedDate, @NewProductCode, @AuthorisationInfo from mm_workorder where number = @number and Start_date = @Start_Date and end_date = @End_Date and Product_code = @ExistingProduct"
            sUpdtWoRecord = "Update a set a.Product_code = c.NewProductCode , a.description = d.description from mm_workorder a inner join " &
                 " ( select a.* ,  SlNo from mm_workorder_ProductModified a " &
                 " inner join ( select product_code , max(sl_no) SlNo from mm_workorder_ProductModified " &
                 " group by product_code ) b on SlNo = sl_no ) c " &
                 " on a.number = c.number and a.start_date = c.start_date and a.end_date = c.end_date and a.shop_code = c.shop_code " &
                 " inner join mm_Product_master b on b.product_code = c.product_code " &
                 " inner join mm_Product_master d on d.product_code = c.NewProductCode " &
                 " where c.NewProductCode = '" & NewProductCode.Trim & "'"
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim blnDone As Boolean
            Try
                cmd.Parameters.Add("@ModifiedBy", SqlDbType.VarChar, 6).Value = EmpCode
                cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime, 8).Value = CDate(Now)
                cmd.Parameters.Add("@NewProductCode", SqlDbType.VarChar, 6).Value = NewProductCode
                cmd.Parameters.Add("@number", SqlDbType.VarChar, 50).Value = WoNumber
                cmd.Parameters.Add("@start_date", SqlDbType.SmallDateTime, 4).Value = CDate(StartDate)
                cmd.Parameters.Add("@End_Date", SqlDbType.SmallDateTime, 4).Value = CDate(EndDate)
                cmd.Parameters.Add("@ExistingProduct", SqlDbType.VarChar, 6).Value = ProductCodeOriginal
                cmd.Parameters.Add("@AuthorisationInfo", SqlDbType.VarChar, 50).Value = Left(AuthorisationInfo.Trim.ToUpper, 50)
                blnDone = True
            Catch exp As Exception
                Throw New Exception("Insufficient Data to save : " & exp.Message)
            End Try
            If blnDone = False Then
                If IsNothing(cmd) = False Then
                    cmd.Dispose()
                    cmd = Nothing
                    Exit Function
                Else
                    Exit Function
                End If
            Else
                blnDone = False
            End If
            Try
                cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                cmd.CommandText = sBkupWoRecord
                If cmd.ExecuteNonQuery > 0 Then
                    cmd.CommandText = sUpdtWoRecord
                    If cmd.ExecuteNonQuery > 0 Then blnDone = True
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If blnDone Then
                    If IsNothing(cmd) = False Then
                        If blnDone Then
                            cmd.Transaction.Commit()
                        Else
                            cmd.Transaction.Rollback()
                        End If
                        If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                        cmd.Dispose()
                        cmd = Nothing
                    End If
                End If
            End Try
            Return blnDone
        End Function
        Friend Class WorkOrder
            Private sWoNumber, sProductCode As String
            Private iWoQty As Integer
            Private iProducedQty As Integer
            ReadOnly Property WoQty() As Integer
                Get
                    Return iWoQty
                End Get
            End Property
            ReadOnly Property ProductCode() As String
                Get
                    Return sProductCode
                End Get
            End Property
            ReadOnly Property ProducedQty() As Integer
                Get
                    Return iProducedQty
                End Get
            End Property
            Public Sub New(ByVal Number As String)
                sWoNumber = Number
                GetData()
            End Sub
            Private Sub GetData()
                Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
                cmd.CommandText = "mm_sp_pco_workorder"
                cmd.Parameters.Add("@WoNo", SqlDbType.VarChar, 4).Value = sWoNumber
                cmd.CommandType = CommandType.StoredProcedure
                Dim dr As SqlClient.SqlDataReader
                Try
                    cmd.Connection.Open()
                    dr = cmd.ExecuteReader
                    If dr.Read Then
                        iWoQty = IIf(IsDBNull(dr("Workorder_Quantity")), 0, dr("Workorder_Quantity"))
                        iProducedQty = IIf(IsDBNull(dr("Produced_Quantity")), 0, dr("Produced_Quantity"))
                        sProductCode = IIf(IsDBNull(dr("Product_Code")), "", dr("Product_Code"))
                    End If
                Catch exp As Exception
                    iWoQty = 0
                    iProducedQty = 0
                    Throw New Exception("Qty Read Error : " & exp.Message)
                Finally
                    Try
#Disable Warning BC42104 ' Variable is used before it has been assigned a value
                        dr.Close()
#Enable Warning BC42104 ' Variable is used before it has been assigned a value
                    Catch

                    End Try
                    If IsNothing(cmd) = False Then
                        If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                        cmd.Dispose()
                        cmd = Nothing
                    End If
                End Try
            End Sub
        End Class
    End Class
    Public Class WorkOrder
#Region " Fields"

#End Region
#Region " Property"

#End Region
#Region " Methods"
        Public Function Save(ByVal strMode As String, ByVal strWono As String, ByVal WOQty As Integer, ByVal PCode As String, ByVal Descr As String, ByVal Shop As String, ByVal StDt As Date, ByVal EnDt As Date) As String
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim status As String
            Dim Done As Boolean
            Try
                cmd.Parameters.Add("@WO", SqlDbType.VarChar, 4).Value = strWono
                cmd.Parameters.Add("@WOQty", SqlDbType.Int, 4).Value = WOQty
                cmd.Parameters.Add("@PCode", SqlDbType.VarChar, 15).Value = PCode
                cmd.Parameters.Add("@Descr", SqlDbType.VarChar, 50).Value = Descr
                cmd.Parameters.Add("@Shop", SqlDbType.VarChar, 10).Value = Shop
                cmd.Parameters.Add("@CC", SqlDbType.VarChar, 10).Value = Left(Shop, 1)
                cmd.Parameters.Add("@WODt", SqlDbType.SmallDateTime, 4).Value = Now.Date
                cmd.Parameters.Add("@StDt", SqlDbType.SmallDateTime, 4).Value = StDt
                cmd.Parameters.Add("@EnDt", SqlDbType.SmallDateTime, 4).Value = EnDt
                cmd.Connection.Open()
                If strMode.ToLower = "new" Then
                    cmd.CommandText = " insert into mm_workorder( number , product_code , description , " &
                    " shop_code , cost_center_code , workorder_date , workorder_quantity , start_date , " &
                    " start_shift , end_date , end_shift , status ) values ( @WO , @PCode , @Descr , @Shop ," &
                    " @CC , @WODt , @WOQty , @StDt , 'A' , @EnDt , 'C' ,  'Open' )"
                    If cmd.ExecuteNonQuery > 0 Then
                        Done = True
                        status = "Data Inserted Successfully"
                    End If
                ElseIf strMode.ToLower = "enhanceqty" Then
                    cmd.CommandText = "Update mm_workorder set workorder_quantity = @WOQty where number = @WO "
                    If cmd.ExecuteNonQuery > 0 Then
                        Done = True
                        status = "Qty Updated Successfully"
                    End If
                ElseIf strMode.ToLower = "suspend" Then
                    cmd.CommandText = "update mm_workorder set status = 'Suspended', suspend_date = '" & Format(Now.Date, "MM/dd/yyyy") & "' where number = @WO "
                    If cmd.ExecuteNonQuery > 0 Then
                        cmd.CommandText = "update mm_rmr set status = 'Suspended' where workorder_number = @WO and status = 'Open'"
                        cmd.ExecuteNonQuery()
                        Done = True
                        status = "Status Updated Successfully"
                    End If
                ElseIf strMode.ToLower = "resume" Then
                    Dim DtResume As Date = Today
                    cmd.CommandText = "update mm_workorder set status = 'Open' , resume_date = '" & Format(Now.Date, "MM/dd/yyyy") & "' where number = @WO"
                    If cmd.ExecuteNonQuery > 0 Then
                        cmd.CommandText = "update mm_rmr set status = 'Open' where workorder_number = @WO and status = 'Suspended'"
                        cmd.ExecuteNonQuery()
                        Done = True
                        status = "WorkOrder resumed Successfully"
                    End If
                ElseIf strMode.ToLower = "delete" Then
                    'blocked the code on 21feb2012 
                    'because of wo 2a6m and 2a7m were deleted by user erronously
                    Exit Function
                ElseIf strMode.ToLower = "close" Then
                    cmd.CommandText = "Update mm_workorder set wo_exception = '1', status = 'Closed'  where number = @WO "
                    If cmd.ExecuteNonQuery > 0 Then
                        cmd.CommandText = "update mm_rmr set status = 'Closed' where workorder_number = @WO and status <> 'N'"
                        If cmd.ExecuteNonQuery > 0 Then
                            Done = True
                            status = "WorkOrder Closed Successfully"
                        End If
                    End If
                End If
            Catch exp As Exception
                Done = False
                Throw New Exception(exp.Message)
            Finally
                If IsNothing(cmd) = False Then
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                End If
            End Try
#Disable Warning BC42104 ' Variable is used before it has been assigned a value
            Save = status
#Enable Warning BC42104 ' Variable is used before it has been assigned a value
        End Function
        Public Function UpdateWO(ByVal strWono As String, ByVal WOQty As Integer) As String
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim Done As Boolean
            Try
                cmd.Parameters.Add("@WO", SqlDbType.VarChar, 4).Value = strWono
                cmd.Parameters.Add("@WOQty", SqlDbType.Int, 4).Value = WOQty
                cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                cmd.CommandText = "Update mm_workorder set workorder_quantity = @WOQty where number = @WO "
                If cmd.ExecuteNonQuery > 0 Then
                    Done = True
                    Return "Qty Updated Successfully"
                Else
                    Return "WO Qty Updatedion Failed"
                End If
            Catch exp As Exception
                Done = False
                Throw New Exception(exp.Message)
            Finally
                If IsNothing(cmd) = False Then
                    If Done Then
                        cmd.Transaction.Commit()
                    Else
                        cmd.Transaction.Rollback()
                    End If
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                End If
            End Try
        End Function
        Public Function UpdateWOQty(ByVal number As String, ByVal Product As String, ByVal WODate As Date, ByVal Passed As Integer, ByVal Rej As Integer) As String
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim Done As Boolean
            Try
                cmd.Parameters.Add("@number", SqlDbType.VarChar, 4).Value = number
                cmd.Parameters.Add("@Product", SqlDbType.VarChar, 50).Value = Product
                cmd.Parameters.Add("@WODate", SqlDbType.SmallDateTime, 4).Value = WODate
                cmd.Parameters.Add("@Passed", SqlDbType.Int, 4).Value = Passed
                cmd.Parameters.Add("@Rej", SqlDbType.Int, 4).Value = Rej
                cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                cmd.CommandText = "update mm_workorder set passed_quantity = @Passed , rejection_quantity  = @Rej " & _
                    " where number = @number and product_code = @Product and @WODate between start_date and end_date "
                If cmd.ExecuteNonQuery > 0 Then
                    Done = True
                    Return "Qty Updated Successfully"
                Else
                    Return "WO Qty Updatedion Failed"
                End If
            Catch exp As Exception
                Done = False
                Throw New Exception(exp.Message)
            Finally
                If IsNothing(cmd) = False Then
                    If Done Then
                        cmd.Transaction.Commit()
                    Else
                        cmd.Transaction.Rollback()
                    End If
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                End If
            End Try
        End Function
#End Region
    End Class
    <Serializable()> Public Class WTA_ProductList
        Private sProductCode As String
        Private sRWFDrawing As String
        Private sCustomerDrawing As String
        Private tblMastProdList As DataTable

        Public Sub New()
            InitVars()
        End Sub
        Private Sub InitVars()
            sProductCode = ""
            sRWFDrawing = ""
            sCustomerDrawing = ""
            tblMastProdList = tables.ProductMasterList
        End Sub
        Property ProductCode() As String
            Get
                Return sProductCode
            End Get
            Set(ByVal Value As String)
                sProductCode = Value
            End Set
        End Property
        Property RWFDrawing() As String
            Get
                Return sRWFDrawing
            End Get
            Set(ByVal Value As String)
                sRWFDrawing = Value.ToUpper.Trim
            End Set
        End Property
        Property CustomerDrawing() As String
            Get
                Return sCustomerDrawing
            End Get
            Set(ByVal Value As String)
                sCustomerDrawing = Value.ToUpper.Trim
            End Set
        End Property
        ReadOnly Property MastList() As DataTable
            Get
                tblMastProdList = tables.ProductMasterList
                Return tblMastProdList
            End Get
        End Property
        ReadOnly Property WtaProdList() As DataTable
            Get
                WtaProdList = tables.WTA_ProductList
            End Get
        End Property
        Public Sub GetWTAProdDetails(ByVal ProdCode As String)
            Try
                Dim dtWTAProdList As DataView
                dtWTAProdList = WtaProdList.DefaultView
                dtWTAProdList.RowFilter = "Product_Code = '" & ProdCode.Trim & "'"
                sRWFDrawing = IIf(IsDBNull(Trim(dtWTAProdList.Item(0)(2))), "", Trim(dtWTAProdList.Item(0)(2)))
                sCustomerDrawing = IIf(IsDBNull(Trim(dtWTAProdList.Item(0)(3))), "", Trim(dtWTAProdList.Item(0)(3)))
            Catch exp As Exception
                Throw New Exception("unable to get product codes details " & exp.Message)
            End Try
        End Sub
        Public Sub GetProdDrg(ByVal ProdCode As String)
            Try
                Dim dtProdList As DataView
                dtProdList = tblMastProdList.DefaultView
                dtProdList.RowFilter = "Product_Code = '" & ProdCode.Trim & "'"
                sRWFDrawing = Trim(dtProdList.Item(0)(2))
                sCustomerDrawing = ""
            Catch exp As Exception
                Throw New Exception("unable to get product codes details " & exp.Message)
            End Try
        End Sub
        Public Sub Save(Optional ByVal Delete As Boolean = False)
            Dim blnSaveProductCode As Boolean
            Dim oCmd As SqlClient.SqlCommand
            oCmd = rwfGen.Connection.CmdObj()
            oCmd.Parameters.Add("@ProductCode", SqlDbType.VarChar, 6)
            oCmd.Parameters("@ProductCode").Direction = ParameterDirection.Input
            oCmd.Parameters.Add("@cnt", SqlDbType.BigInt, 8)
            oCmd.Parameters("@cnt").Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@RWF_Drawing", SqlDbType.VarChar, 50)
            oCmd.Parameters("@RWF_Drawing").Direction = ParameterDirection.Input
            oCmd.Parameters.Add("@CustomerDrawing", SqlDbType.VarChar, 50)
            oCmd.Parameters("@CustomerDrawing").Direction = ParameterDirection.Input
            oCmd.Parameters.Add("@Make", SqlDbType.VarChar, 10)
            oCmd.Parameters("@Make").Direction = ParameterDirection.Output

            Try
                oCmd.Parameters("@ProductCode").Value = sProductCode
                oCmd.Parameters("@RWF_Drawing").Value = sRWFDrawing
                oCmd.Parameters("@CustomerDrawing").Value = sCustomerDrawing
                blnSaveProductCode = True
            Catch exp As Exception
                Throw New Exception("Value Assignment error : " & exp.Message)
            Finally
                ' purposefully left blank
            End Try

            If blnSaveProductCode Then
                blnSaveProductCode = False
            Else
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
                Exit Sub
            End If

            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                oCmd.CommandText = "SELECT @Make =  case when isnull(type,'') = '' then 'RWF' else ltrim(rtrim(type)) end  " & _
                    " FROM mm_product_master where Product_Code = @ProductCode"
                oCmd.ExecuteScalar()
                oCmd.Parameters("@Make").Direction = ParameterDirection.Input
                oCmd.CommandText = "select @cnt = count(*) from mm_pco_WTA_ProductList where Product_Code = @ProductCode"
                oCmd.ExecuteScalar()
                If oCmd.Parameters("@cnt").Value = 0 Then
                    If Delete = False Then SaveProductDetailsADD(oCmd)
                ElseIf oCmd.Parameters("@cnt").Value > 0 Then
                    If Delete = True Then
                        SaveProductDetailsDelete(oCmd)
                    Else
                        SaveProductDetailsUpdate(oCmd)
                    End If
                End If
                blnSaveProductCode = True
            Catch exp As Exception
                Throw New Exception("Pdoduct Code saving to PCO_WTA Tables error : " & exp.Message)
            Finally
                If blnSaveProductCode = True Then
                    oCmd.Transaction.Commit()
                Else
                    oCmd.Transaction.Rollback()
                End If
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try

        End Sub
        Private Sub SaveProductDetailsADD(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " Insert into mm_pco_WTA_ProductList ( Product_Code , RWF_Drawing , CustomerDrawing , Make  ) values ( @ProductCode , @RWF_Drawing , @CustomerDrawing , @Make )"
            Try
                If CMD.ExecuteNonQuery() = 0 Then Throw New Exception("Unable to save Product Details")
            Catch exp As Exception
                Throw New Exception("Product Details Save Error : " & exp.Message)
            End Try
        End Sub
        Private Sub SaveProductDetailsUpdate(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " update mm_pco_WTA_ProductList set RWF_Drawing = @RWF_Drawing , CustomerDrawing = @CustomerDrawing where Product_Code  = @ProductCode"
            Try
                If CMD.ExecuteNonQuery() = 0 Then Throw New Exception(" Unable to update Product code List details ")
            Catch exp As Exception
                Throw New Exception(" Updating of mm_pco_WTA_ProductList table error " & exp.Message)
            End Try
        End Sub
        Private Sub SaveProductDetailsDelete(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " delete mm_pco_WTA_ProductList where Product_Code  = @ProductCode"
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to Delete Product Code Details ")
            Catch exp As Exception
                Throw New Exception(" Product Code Details Delete error : " & exp.Message)
            End Try
        End Sub
    End Class
    <Serializable()> Public Class WTA_NumberList
        Private lWtaRef As Long
        Private sWtaNumber, sWTARefRemarks As String
        Private dWtaDate As Date
        Private tblWTANumberList As DataTable

        Property WtaRef() As Long
            Get
                Return lWtaRef
            End Get
            Set(ByVal Value As Long)
                lWtaRef = Value
            End Set
        End Property
        Property WtaNumber() As String
            Get
                Return sWtaNumber.ToUpper
            End Get
            Set(ByVal Value As String)
                sWtaNumber = Value.ToUpper
                If sWtaNumber = "select" Then
                    sWtaNumber = ""
                    Throw New Exception(" Invalid WTA Number ")
                End If
            End Set
        End Property
        Property WtaDate() As Date
            Get
                Return dWtaDate
            End Get
            Set(ByVal Value As Date)
                dWtaDate = Value
            End Set
        End Property
        Property WTARefRemarks() As String
            Get
                Return sWTARefRemarks.ToUpper.Trim
            End Get
            Set(ByVal Value As String)
                sWTARefRemarks = Value.Trim.ToUpper
            End Set
        End Property
        ReadOnly Property WTANumberList()
            Get
                tblWTANumberList = tables.WTA_NumberList
                Return tblWTANumberList
            End Get
        End Property

        Public Sub New()
            intVars()
        End Sub
        Private Sub intVars()
            lWtaRef = 0
            sWtaNumber = ""
            dWtaDate = "1900-01-01"
            sWTARefRemarks = ""
            tblWTANumberList = Nothing
        End Sub

        Public Sub GetWtaRefDetails(ByVal WtaRef As Long)
            Dim blnProductCode As Boolean
            Dim oCmd As SqlClient.SqlCommand
            oCmd = rwfGen.Connection.CmdObj()

            oCmd.Parameters.Add("@WtaRef", SqlDbType.BigInt, 8)
            oCmd.Parameters("@WtaRef").Direction = ParameterDirection.Input
            oCmd.Parameters("@WtaRef").Value = WtaRef
            oCmd.Parameters.Add("@WtaNumber", SqlDbType.VarChar, 150)
            oCmd.Parameters("@WtaNumber").Direction = ParameterDirection.Output
            oCmd.Parameters("@WtaNumber").Value = WtaNumber
            oCmd.Parameters.Add("@WtaRefDate", SqlDbType.SmallDateTime, 4)
            oCmd.Parameters("@WtaRefDate").Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@WTARefRemarks", SqlDbType.VarChar, 5000)
            oCmd.Parameters("@WTARefRemarks").Direction = ParameterDirection.Output
            Try
                oCmd.Connection.Open()
                oCmd.CommandText = "select @WtaNumber = WtaNumber , @WtaRefDate = WtaDate , @WTARefRemarks = Remarks  from mm_pco_WTA_Meetings where WtaRef  = @WtaRef"
                oCmd.ExecuteScalar()
                sWtaNumber = IIf(IsDBNull(oCmd.Parameters("@WtaNumber").Value), "", oCmd.Parameters("@WtaNumber").Value)
                dWtaDate = IIf(IsDBNull(oCmd.Parameters("@WtaRefDate").Value), "01/01/1900", oCmd.Parameters("@WtaRefDate").Value)
                sWTARefRemarks = IIf(IsDBNull(oCmd.Parameters("@WTARefRemarks").Value), "", oCmd.Parameters("@WTARefRemarks").Value)
            Catch exp As Exception
                Throw New Exception("WTA Number seeking from PCO_WTA Tables error : " & exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Sub
        Public Function Save(Optional ByVal Delete As Boolean = False, Optional ByVal WTAref As Long = 0) As Boolean
            Dim blnSaveWTANumber As Boolean
            Dim oCmd As SqlClient.SqlCommand
            oCmd = rwfGen.Connection.CmdObj()
            oCmd.Parameters.Add("@WtaNumber", SqlDbType.VarChar, 150)
            oCmd.Parameters("@WtaNumber").Direction = ParameterDirection.Input
            oCmd.Parameters.Add("@WtaRef", SqlDbType.BigInt, 8)
            oCmd.Parameters("@WtaRef").Direction = ParameterDirection.Input
            oCmd.Parameters.Add("@WtaRefDate", SqlDbType.SmallDateTime, 4)
            oCmd.Parameters("@WtaRefDate").Direction = ParameterDirection.Input
            oCmd.Parameters.Add("@WTARefRemarks", SqlDbType.VarChar, 5000)
            oCmd.Parameters("@WTARefRemarks").Direction = ParameterDirection.Input

            Try
                If sWtaNumber = "select" Then
                    sWtaNumber = ""
                    Throw New Exception(" Invalid WTA Number ")
                    Exit Try
                Else
                    oCmd.Parameters("@WtaNumber").Value = sWtaNumber
                End If
                oCmd.Parameters("@WtaRef").Value = WTAref
                oCmd.Parameters("@WtaRefDate").Value = dWtaDate
                oCmd.Parameters("@WTARefRemarks").Value = sWTARefRemarks
                blnSaveWTANumber = True
            Catch exp As Exception
                blnSaveWTANumber = False
                Throw New Exception(" Assingement of values of WTA Number error " & exp.Message)
            End Try
            If blnSaveWTANumber = False Then
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
                Exit Function
            Else
                blnSaveWTANumber = False
            End If

            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                If WTAref > 0 Then
                    If Delete = False Then
                        SaveWTANumberDetailsEdit(oCmd)
                    Else
                        SaveWTANumberDetailsDelete(oCmd)
                    End If
                Else
                    If Delete = False Then SaveWTANumberDetailsAdd(oCmd)
                End If
                blnSaveWTANumber = True
            Catch exp As Exception
                Throw New Exception("Pdoduct Code saving to PCO_WTA Tables error : " & exp.Message)
            Finally
                If blnSaveWTANumber = True Then
                    oCmd.Transaction.Commit()
                Else
                    oCmd.Transaction.Rollback()
                End If
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
            Return blnSaveWTANumber
        End Function
        Private Sub SaveWTANumberDetailsAdd(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " Insert into mm_pco_WTA_Meetings ( WtaNumber , WtaDate , Remarks ) values ( @WtaNumber , @WtaRefDate , @WTARefRemarks )"
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Adding of WTA number error")
            Catch exp As Exception
                Throw New Exception(" Insert into mm_pco_WTA_Meetings error " & exp.Message)
            End Try
        End Sub
        Private Sub SaveWTANumberDetailsEdit(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " update mm_pco_WTA_Meetings set WtaNumber = @WtaNumber , WtaDate =  @WtaRefDate , Remarks =  @WTARefRemarks where  WtaRef = @WtaRef "
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to update WTA Number details ")
            Catch exp As Exception
                Throw New Exception(" update of mm_pco_WTA_Meetings error :  " & exp.Message)
            End Try
        End Sub
        Private Sub SaveWTANumberDetailsDelete(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " delete mm_pco_WTA_Meetings  where  WtaRef = @WtaRef and not (wtaDate = '1900-1-1' or wtaRemarks = 'System') " 'set WtaNumber = @WtaNumber , WtaDate =  @WtaRefDate , Remarks =  @WTARefRemarks
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to delete WTA Number details ")
            Catch exp As Exception
                Throw New Exception(" delete of mm_pco_WTA_Meetings error :  " & exp.Message)
            End Try
        End Sub
    End Class
    <Serializable()> Public Class WTA_OrderList
        Private lOrderId As Long
        Private sOrderNumber, sOrderedBy, sOrderType, sSupplyOrdersRemarks As String
        Private dOrderDate As Date
        Private tblOrderNumber As DataTable

        Property OrderId() As Long
            Get
                Return lOrderId
            End Get
            Set(ByVal Value As Long)
                lOrderId = Value
            End Set
        End Property
        Property OrderNumber() As String
            Get
                Return sOrderNumber
            End Get
            Set(ByVal Value As String)
                sOrderNumber = Value.ToUpper.Trim
                If sOrderNumber = "select" Then
                    sOrderNumber = ""
                    Throw New Exception(" Inalid Supply Order Number ")
                End If
            End Set
        End Property
        Property OrderedBy() As String
            Get
                Return sOrderedBy
            End Get
            Set(ByVal Value As String)
                sOrderedBy = Value.Trim.ToUpper
            End Set
        End Property
        Property OrderType() As String
            Get
                Return sOrderType
            End Get
            Set(ByVal Value As String)
                sOrderType = Value.Trim.ToUpper
            End Set
        End Property
        Property OrderDate() As Date
            Get
                Return dOrderDate
            End Get
            Set(ByVal Value As Date)
                dOrderDate = Value
            End Set
        End Property
        Property SupplyOrdersRemarks() As String
            Get
                Return sSupplyOrdersRemarks
            End Get
            Set(ByVal Value As String)
                sSupplyOrdersRemarks = Value.Trim.ToUpper
            End Set
        End Property
        ReadOnly Property OrderList()
            Get
                tblOrderNumber = tables.WTA_SupplyOrdersList
                Return tblOrderNumber
            End Get
        End Property
        Public Sub New()
            intVar()
        End Sub
        Private Sub intVar()
            lOrderId = 0
            sOrderNumber = ""
            dOrderDate = "01/01/1900"
            sOrderedBy = ""
            sOrderType = ""
            sSupplyOrdersRemarks = ""
            tblOrderNumber = Nothing
        End Sub
        Public Sub GetSupplyOrdersDetails(ByVal OrderID As Long)
            Dim strGetSupplyOrdersDetails As String
            Dim blnProductCode As Boolean
            strGetSupplyOrdersDetails = "select @cnt = count(*) from mm_pco_WTA_SupplyOrders where OrderId = @OrderId"
            Dim oCmd As SqlClient.SqlCommand
            oCmd = rwfGen.Connection.CmdObj()
            oCmd.Parameters.Add("@OrderId", SqlDbType.BigInt, 8)
            oCmd.Parameters("@OrderId").Direction = ParameterDirection.Input
            oCmd.Parameters("@OrderId").Value = OrderID
            oCmd.Parameters.Add("@cnt", SqlDbType.BigInt, 8)
            oCmd.Parameters("@cnt").Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@OrderNumber", SqlDbType.VarChar, 250)
            oCmd.Parameters("@OrderNumber").Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@OrderDate", SqlDbType.SmallDateTime, 4)
            oCmd.Parameters("@OrderDate").Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@OrderedBy", SqlDbType.VarChar, 50)
            oCmd.Parameters("@OrderedBy").Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@OrderType", SqlDbType.VarChar, 10)
            oCmd.Parameters("@OrderType").Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@SupplyOrdersRemarks", SqlDbType.VarChar, 500)
            oCmd.Parameters("@SupplyOrdersRemarks").Direction = ParameterDirection.Output
            Try
                oCmd.Connection.Open()
                oCmd.CommandText = strGetSupplyOrdersDetails
                oCmd.ExecuteScalar()
                If oCmd.Parameters("@cnt").Value > 0 Then
                    oCmd.CommandText = "select @OrderNumber = OrderNumber , @OrderDate = OrderDate , @OrderedBy = OrderedBy , @OrderType = OrderType , @SupplyOrdersRemarks = Remarks from mm_pco_WTA_SupplyOrders where OrderId  = @OrderId"
                    oCmd.ExecuteScalar()
                    sOrderNumber = oCmd.Parameters("@OrderNumber").Value & ""
                    dOrderDate = IIf(IsDBNull(oCmd.Parameters("@OrderDate").Value), "01/01/1900", oCmd.Parameters("@OrderDate").Value)
                    sOrderedBy = oCmd.Parameters("@OrderedBy").Value.Trim & ""
                    sOrderType = oCmd.Parameters("@OrderType").Value.Trim & ""
                    sSupplyOrdersRemarks = oCmd.Parameters("@SupplyOrdersRemarks").Value.Trim & ""
                End If
            Catch exp As Exception
                Throw New Exception("Pdoduct Code seeking from PCO_WTA Tables error : " & exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Sub
        Public Function Save(ByVal Delete As Boolean, ByVal OrderId As Long) As Boolean
            Dim blnSaveSupplyOrders As Boolean
            Dim oCmd As SqlClient.SqlCommand
            oCmd = rwfGen.Connection.CmdObj()
            oCmd.Parameters.Add("@OrderId", SqlDbType.BigInt, 8)
            oCmd.Parameters("@OrderId").Direction = ParameterDirection.Input
            oCmd.Parameters.Add("@OrderNumber", SqlDbType.VarChar, 250)
            oCmd.Parameters("@OrderNumber").Direction = ParameterDirection.Input
            oCmd.Parameters.Add("@OrderDate", SqlDbType.SmallDateTime, 4)
            oCmd.Parameters("@OrderDate").Direction = ParameterDirection.Input
            oCmd.Parameters.Add("@OrderedBy", SqlDbType.VarChar, 50)
            oCmd.Parameters("@OrderedBy").Direction = ParameterDirection.Input
            oCmd.Parameters.Add("@OrderType", SqlDbType.VarChar, 10)
            oCmd.Parameters("@OrderType").Direction = ParameterDirection.Input
            oCmd.Parameters.Add("@SupplyOrdersRemarks", SqlDbType.VarChar, 500)
            oCmd.Parameters("@SupplyOrdersRemarks").Direction = ParameterDirection.Input

            Try
                oCmd.Parameters("@OrderId").Value = OrderId
                If sOrderNumber = "select" Or sOrderNumber = "NEW" Then
                    sOrderNumber = ""
                    Throw New Exception(" Invalid Supply Order Number ")
                    Exit Try
                Else
                    oCmd.Parameters("@OrderNumber").Value = sOrderNumber
                End If

                oCmd.Parameters("@OrderDate").Value = dOrderDate
                oCmd.Parameters("@OrderedBy").Value = sOrderedBy
                oCmd.Parameters("@OrderType").Value = sOrderType
                oCmd.Parameters("@SupplyOrdersRemarks").Value = sSupplyOrdersRemarks
                blnSaveSupplyOrders = True
            Catch exp As Exception
                Throw New Exception(" Assingment of values of Supply Orders error ")
            End Try

            If blnSaveSupplyOrders = True Then
                blnSaveSupplyOrders = False
            Else
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
                Exit Function
            End If

            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                If OrderId > 0 Then
                    If Delete = False Then
                        SaveSupplyOrdersDetailsEdit(oCmd)
                    Else
                        SaveSupplyOrdersDetailsDelete(oCmd)
                    End If
                Else
                    If Delete = False Then SaveSupplyOrdersDetailsAdd(oCmd)
                End If
                blnSaveSupplyOrders = True
            Catch exp As Exception
                Throw New Exception("Supply Orders saving to PCO_WTA Tables error : " & exp.Message)
            Finally
                If blnSaveSupplyOrders = True Then
                    oCmd.Transaction.Commit()
                Else
                    oCmd.Transaction.Rollback()
                End If
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
            Return blnSaveSupplyOrders
        End Function
        Private Sub SaveSupplyOrdersDetailsAdd(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " Insert into mm_pco_WTA_SupplyOrders ( OrderNumber , OrderDate , OrderedBy , OrderType ,  Remarks ) values ( @OrderNumber , @OrderDate , @OrderedBy , @OrderType ,  @SupplyOrdersRemarks ) "
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to add Supply Orders Details")
            Catch exp As Exception
                Throw New Exception(" Insert into mm_pco_WTA_SupplyOrders error : " & exp.Message)
            End Try
        End Sub
        Private Sub SaveSupplyOrdersDetailsEdit(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " update mm_pco_WTA_SupplyOrders set OrderNumber = @OrderNumber , OrderDate =  @OrderDate , OrderedBy = @OrderedBy , OrderType = @OrderType , Remarks =  @SupplyOrdersRemarks where  OrderId = @OrderId "
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to update Supply Orders Details")
            Catch exp As Exception
                Throw New Exception(" update of mm_pco_WTA_SupplyOrders error : " & exp.Message)
            End Try
        End Sub
        Private Sub SaveSupplyOrdersDetailsDelete(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " delete mm_pco_WTA_SupplyOrders  where  OrderId = @OrderId " 'set OrderNumber = @OrderNumber , OrderDate =  @OrderDate , OrderedBy = @OrderedBy , OrderType = @OrderType , Remarks =  @SupplyOrdersRemarks
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to delete Supply Orders Details")
            Catch exp As Exception
                Throw New Exception(" deleting from mm_pco_WTA_SupplyOrders error : " & exp.Message)
            End Try
        End Sub
    End Class
    <Serializable()> Public Class WTA_PlannedQuantities
        Private lPlanId, lPlanSupplyOrderId, lPlanWTA_Ref As Long
        Private sPlanProductCode, sPlanRemarks As String
        Private dPlanQtyDate As Date
        Private iPlanOrderQty As Integer

        Property PlanOrderQty() As Integer
            Get
                Return iPlanOrderQty
            End Get
            Set(ByVal Value As Integer)
                iPlanOrderQty = Value
            End Set
        End Property
        Property PlanQtyDate() As Date
            Get
                Return dPlanQtyDate
            End Get
            Set(ByVal Value As Date)
                dPlanQtyDate = Value
            End Set
        End Property
        Property PlanRemarks() As String
            Get
                Return sPlanRemarks
            End Get
            Set(ByVal Value As String)
                sPlanRemarks = Value.Trim.ToUpper
            End Set
        End Property
        Property PlanProductCode() As String
            Get
                Return sPlanProductCode
            End Get
            Set(ByVal Value As String)
                sPlanProductCode = Value.Trim
            End Set
        End Property
        Property PlanWTA_Ref() As Long
            Get
                Return lPlanWTA_Ref
            End Get
            Set(ByVal Value As Long)
                lPlanWTA_Ref = Value
            End Set
        End Property
        Property PlanSupplyOrderId() As Long
            Get
                Return lPlanSupplyOrderId
            End Get
            Set(ByVal Value As Long)
                lPlanSupplyOrderId = Value
            End Set
        End Property
        Property PlanId() As Long
            Get
                Return lPlanId
            End Get
            Set(ByVal Value As Long)
                lPlanId = Value
            End Set
        End Property

        Public Sub New()
            intVars()
        End Sub
        Private Sub intVars()
            lPlanId = lPlanSupplyOrderId = lPlanWTA_Ref = 0
            sPlanProductCode = sPlanRemarks = ""
            dPlanQtyDate = "1900-01-01"
            iPlanOrderQty = 0
        End Sub

        Public Sub GetPlanID(ByVal mode As String)
            Dim blnPlanID As Boolean
            Dim oCmd As SqlClient.SqlCommand
            oCmd = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@PlanId", SqlDbType.BigInt, 8)
            oCmd.Parameters("@PlanId").Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@SupplyOrderId", SqlDbType.BigInt, 8)
            oCmd.Parameters("@SupplyOrderId").Direction = ParameterDirection.Input
            oCmd.Parameters.Add("@ProductCode", SqlDbType.VarChar, 6)
            oCmd.Parameters("@ProductCode").Direction = ParameterDirection.Input
            oCmd.Parameters.Add("@WTA_Ref", SqlDbType.BigInt, 8)
            oCmd.Parameters("@WTA_Ref").Direction = ParameterDirection.Input
            oCmd.Parameters.Add("@QtyDate", SqlDbType.SmallDateTime, 4)
            oCmd.Parameters("@QtyDate").Direction = ParameterDirection.Input
            oCmd.Parameters.Add("@OrderQty", SqlDbType.Int, 4)
            oCmd.Parameters("@OrderQty").Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 500)
            oCmd.Parameters("@Remarks").Direction = ParameterDirection.Output
            Try
                oCmd.Parameters("@SupplyOrderId").Value = lPlanSupplyOrderId
                oCmd.Parameters("@ProductCode").Value = sPlanProductCode
                oCmd.Parameters("@WTA_Ref").Value = lPlanWTA_Ref
                oCmd.Parameters("@QtyDate").Value = dPlanQtyDate
                blnPlanID = True
            Catch exp As Exception
                blnPlanID = False
                Throw New Exception(" Assignment of Planned Quantities error " & exp.Message)
            End Try
            If blnPlanID = True Then
                blnPlanID = False
            Else
                Exit Sub
            End If
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = " select @PlanId = PlanId , @OrderQty = OrderQty , @Remarks = Remarks from mm_pco_wta_PlannedQuantities " & _
                                    " where SupplyOrderId = @SupplyOrderId and ProductCode = @ProductCode and WTA_Ref = @WTA_Ref and QtyDate = @QtyDate "
                oCmd.ExecuteScalar()
                If Not IsDBNull(oCmd.Parameters("@PlanId").Value) Then
                    If mode = "add" Then
                        Throw New Exception(" Data exits for this combination of ProductCode , WTANumber , OrderNumber , Order Date ! ")
                    Else
                        lPlanId = oCmd.Parameters("@PlanId").Value
                        iPlanOrderQty = oCmd.Parameters("@OrderQty").Value
                        sPlanRemarks = oCmd.Parameters("@Remarks").Value
                    End If
                End If
            Catch exp As Exception
                Throw New Exception(" Getting Planned Quantities data error : " & exp.Message)
            End Try
        End Sub
        Public Sub Save(Optional ByVal Delete As Boolean = False, Optional ByVal PlanID As Long = 0)
            Dim blnSavePlanID As Boolean
            Dim oCmd As SqlClient.SqlCommand
            oCmd = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@PlanId", SqlDbType.BigInt, 8)
            oCmd.Parameters("@PlanId").Direction = ParameterDirection.Input
            oCmd.Parameters.Add("@SupplyOrderId", SqlDbType.BigInt, 8)
            oCmd.Parameters("@SupplyOrderId").Direction = ParameterDirection.Input
            oCmd.Parameters.Add("@ProductCode", SqlDbType.VarChar, 6)
            oCmd.Parameters("@ProductCode").Direction = ParameterDirection.Input
            oCmd.Parameters.Add("@WTA_Ref", SqlDbType.BigInt, 8)
            oCmd.Parameters("@WTA_Ref").Direction = ParameterDirection.Input
            oCmd.Parameters.Add("@QtyDate", SqlDbType.SmallDateTime, 4)
            oCmd.Parameters("@QtyDate").Direction = ParameterDirection.Input
            oCmd.Parameters.Add("@OrderQty", SqlDbType.Int, 4)
            oCmd.Parameters("@OrderQty").Direction = ParameterDirection.Input
            oCmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 500)
            oCmd.Parameters("@Remarks").Direction = ParameterDirection.Input
            Try
                oCmd.Parameters("@PlanId").Value = PlanID
                oCmd.Parameters("@SupplyOrderId").Value = lPlanSupplyOrderId
                oCmd.Parameters("@ProductCode").Value = sPlanProductCode
                oCmd.Parameters("@WTA_Ref").Value = lPlanWTA_Ref
                oCmd.Parameters("@QtyDate").Value = dPlanQtyDate
                oCmd.Parameters("@OrderQty").Value = iPlanOrderQty
                oCmd.Parameters("@Remarks").Value = sPlanRemarks
                blnSavePlanID = True
            Catch exp As Exception
                blnSavePlanID = False
                Throw New Exception(" Assignment of Planned Quantities error " & exp.Message)
            End Try
            If blnSavePlanID = True Then
                blnSavePlanID = False
            Else
                Exit Sub
            End If
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                If PlanID > 0 Then
                    If Delete = False Then
                        SavePlannedQuantitiesEdit(oCmd)
                    Else
                        SavePlannedQuantitiesDelete(oCmd)
                    End If
                Else
                    If Delete = False Then SavePlannedQuantitiesAdd(oCmd)
                End If
                blnSavePlanID = True
            Catch exp As Exception
                Throw New Exception("Planned Quantities saving to mm_pco_wta_PlannedQuantities Tables error : " & exp.Message)
            Finally
                If blnSavePlanID = True Then
                    oCmd.Transaction.Commit()
                Else
                    oCmd.Transaction.Rollback()
                End If
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Sub
        Private Sub SavePlannedQuantitiesAdd(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " Insert into mm_pco_wta_PlannedQuantities ( SupplyOrderId , ProductCode , WTA_Ref , QtyDate , OrderQty , Remarks ) values ( @SupplyOrderId , @ProductCode , @WTA_Ref , @QtyDate ,  @OrderQty , @Remarks ) "
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to add Planned Details")
            Catch exp As Exception
                Throw New Exception(" Insert into mm_pco_wta_PlannedQuantities error : " & exp.Message)
            End Try
        End Sub
        Private Sub SavePlannedQuantitiesEdit(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " update mm_pco_wta_PlannedQuantities set QtyDate = @QtyDate , OrderQty =  @OrderQty , Remarks = @Remarks where  PlanId = @PlanId "
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to update Planned Quantities Details")
            Catch exp As Exception
                Throw New Exception(" update of mm_pco_wta_PlannedQuantities error : " & exp.Message)
            End Try
        End Sub
        Private Sub SavePlannedQuantitiesDelete(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " delete mm_pco_wta_PlannedQuantities  where  PlanId = @PlanId " 'set OrderNumber = @OrderNumber , OrderDate =  @OrderDate , OrderedBy = @OrderedBy , OrderType = @OrderType , Remarks =  @SupplyOrdersRemarks
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to delete Planned Quantities Details")
            Catch exp As Exception
                Throw New Exception(" deleting from PlannedQuantities error : " & exp.Message)
            End Try
        End Sub
    End Class
    <Serializable()> Public Class WTA_PlannedSupplies
        Private lSupplyID, lSupplyPlanId As Long
        Private sSupplyConsigneeCode, sSupplyRemarks, sPONumber As String
        Private iOrderedQty, iOrderQty As Integer
        Property PONumber() As String
            Get
                Return sPONumber
            End Get
            Set(ByVal Value As String)
                sPONumber = Value
            End Set
        End Property
        Property SupplyID() As Long
            Get
                Return lSupplyID
            End Get
            Set(ByVal Value As Long)
                lSupplyID = Value
            End Set
        End Property
        Property SupplyPlanId() As Long
            Get
                Return lSupplyPlanId
            End Get
            Set(ByVal Value As Long)
                lSupplyPlanId = Value
            End Set
        End Property
        Property SupplyConsigneeCode() As String
            Get
                Return sSupplyConsigneeCode
            End Get
            Set(ByVal Value As String)
                sSupplyConsigneeCode = Value.Trim.ToUpper
            End Set
        End Property
        Property SupplyRemarks() As String
            Get
                Return sSupplyRemarks
            End Get
            Set(ByVal Value As String)
                sSupplyRemarks = Value.Trim.ToUpper
            End Set
        End Property
        WriteOnly Property OrderQty() As Integer
            Set(ByVal Value As Integer)
                iOrderQty = Value
            End Set
        End Property
        Property OrderedQty() As Integer
            Get
                Return iOrderedQty
            End Get
            Set(ByVal Value As Integer)
                If GetOrderedQty(Value) Then iOrderedQty = Value
            End Set
        End Property
        Public Sub New()
            intVars()
        End Sub
        Private Sub intVars()
            iOrderedQty = 0
            lSupplyID = 0
            sSupplyConsigneeCode = sSupplyRemarks = ""
            iOrderedQty = 0
            sPONumber = ""
        End Sub
        Public Function GetSupplyPlanList(Optional ByVal planID As Long = 0) As DataTable
            Dim dv As New DataView()
            Try
                dv.Table = tables.WTA_SuppliesPlan
                If planID > 0 Then
                    dv.RowFilter = "planID = " & planID
                End If
                Dim tblSupplyPlanList As New DataTable()
                tblSupplyPlanList = tables.WTA_SuppliesPlan.Clone
                Dim dr As DataRow
                Dim rows, flds As Integer
                For rows = 0 To dv.Count - 1
                    dr = tblSupplyPlanList.NewRow
                    For flds = 0 To dv.Table.Columns.Count - 1
                        dr(flds) = dv(rows)(flds)
                    Next
                    tblSupplyPlanList.Rows.Add(dr)
                Next
                Return tblSupplyPlanList
            Catch exp As Exception
                Throw New Exception(exp.Message)
            End Try
        End Function
        Public Function CheckSupplyCompliance() As Boolean
            Dim oCmd As SqlClient.SqlCommand
            oCmd = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@SupplyId", SqlDbType.BigInt, 8)
            oCmd.Parameters("@SupplyId").Direction = ParameterDirection.Input

            oCmd.Parameters.Add("@SupplyComplianceId", SqlDbType.BigInt, 8)
            oCmd.Parameters("@SupplyComplianceId").Direction = ParameterDirection.Output
            Try
                oCmd.Parameters("@SupplyId").Value = lSupplyID
                oCmd.CommandText = " Select @SupplyComplianceId = count(ComplianceID) from mm_pco_WTA_Compliance where SupplyId = @SupplyId "
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.ExecuteScalar()
                If IIf(IsDBNull(oCmd.Parameters("@SupplyComplianceId").Value), 0, oCmd.Parameters("@SupplyComplianceId").Value) > 0 Then
                    CheckSupplyCompliance = True
                End If
            Catch exp As Exception
                Throw New Exception(" Assignment of values to Consignee details error " & exp.Message)
                CheckSupplyCompliance = False
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function
        Public Function GetSupplyConsigneeList() As DataTable
            Dim dv As New DataView()
            dv.Table = tables.WTA_ConsigneeSupplyList()
            dv.RowFilter = "planID = " & lSupplyPlanId
            If lSupplyID > 0 Then
                dv.RowFilter = "SupplyID = " & lSupplyID
            End If
            Dim tblConsigneeList As New DataTable()
            tblConsigneeList = tables.WTA_ConsigneeSupplyList().Clone
            Dim dr As DataRow
            Dim rows, flds As Integer
            For rows = 0 To dv.Count - 1
                dr = tblConsigneeList.NewRow
                For flds = 0 To tblConsigneeList.Columns.Count - 1
                    dr(flds) = dv(rows)(flds)
                Next
                tblConsigneeList.Rows.Add(dr)
            Next
            Return tblConsigneeList
        End Function
        Private Function GetOrderedQty(ByVal Value As Integer) As Boolean
            Dim blnSumSupplyID As Boolean
            Dim oCmd As SqlClient.SqlCommand
            oCmd = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@SumOrderedQty", SqlDbType.BigInt, 8)
            oCmd.Parameters("@SumOrderedQty").Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@SupplyPlanId", SqlDbType.BigInt, 8)
            oCmd.Parameters("@SupplyPlanId").Direction = ParameterDirection.Input
            oCmd.Parameters.Add("@SupplyConsigneeCode", SqlDbType.VarChar, 50)
            oCmd.Parameters("@SupplyConsigneeCode").Direction = ParameterDirection.Input
            oCmd.Parameters.Add("@OrderedQty", SqlDbType.Int, 4)
            oCmd.Parameters("@OrderedQty").Direction = ParameterDirection.Input
            Try
                oCmd.Parameters("@SupplyPlanId").Value = lSupplyPlanId
                oCmd.Parameters("@SupplyConsigneeCode").Value = sSupplyConsigneeCode.Trim
                oCmd.Parameters("@OrderedQty").Value = Value
                blnSumSupplyID = True
            Catch exp As Exception
                blnSumSupplyID = False
                Throw New Exception(" Assignment of values to Consignee details error " & exp.Message)
            End Try
            If blnSumSupplyID = True Then
                blnSumSupplyID = False
            Else
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
                Exit Function
            End If
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = " select @SumOrderedQty = sum(OrderedQty) from mm_pco_wta_supplies " & _
                                    " where PlanId = @SupplyPlanId "
                oCmd.ExecuteScalar()
                If (IIf(IsDBNull(oCmd.Parameters("@SumOrderedQty").Value), 0, oCmd.Parameters("@SumOrderedQty").Value) + Value) > iOrderQty Then
                    Throw New Exception(" Sum of OrderedQty is greater than OrderQty  for the selected PlanID ")
                    blnSumSupplyID = False
                Else
                    iOrderedQty = IIf(IsDBNull(oCmd.Parameters("@OrderedQty").Value), 0, oCmd.Parameters("@OrderedQty").Value)
                    blnSumSupplyID = True
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message & " ; Retrival of OrderedQty Details error ;")
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
            GetOrderedQty = blnSumSupplyID
        End Function
        Public Sub GetSupplyID()
            Dim blnSupplyID As Boolean
            Dim oCmd As SqlClient.SqlCommand
            oCmd = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@SupplyId", SqlDbType.BigInt, 8)
            oCmd.Parameters("@SupplyId").Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@SupplyPlanId", SqlDbType.BigInt, 8)
            oCmd.Parameters("@SupplyPlanId").Direction = ParameterDirection.Input
            oCmd.Parameters.Add("@SupplyConsigneeCode", SqlDbType.VarChar, 50)
            oCmd.Parameters("@SupplyConsigneeCode").Direction = ParameterDirection.Input
            oCmd.Parameters.Add("@OrderedQty", SqlDbType.Int, 4)
            oCmd.Parameters("@OrderedQty").Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@SupplyRemarks", SqlDbType.VarChar, 500)
            oCmd.Parameters("@SupplyRemarks").Direction = ParameterDirection.Output
            Try
                oCmd.Parameters("@SupplyPlanId").Value = lSupplyPlanId
                oCmd.Parameters("@SupplyConsigneeCode").Value = sSupplyConsigneeCode.Trim
                blnSupplyID = True
            Catch exp As Exception
                blnSupplyID = False
                Throw New Exception(" Assignment of values to Consignee details error " & exp.Message)
            End Try
            If blnSupplyID = True Then
                blnSupplyID = False
            Else
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
                Exit Sub
            End If

            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = " select @SupplyID = SupplyID , @OrderedQty = OrderedQty , @SupplyRemarks = Remarks  from mm_pco_wta_supplies " & _
                                    " where PlanId = @SupplyPlanId and ConsigneeCode = @SupplyConsigneeCode "
                oCmd.ExecuteScalar()
                If IIf(IsDBNull(oCmd.Parameters("@SupplyId").Value), 0, oCmd.Parameters("@SupplyId").Value) > 0 Then
                    lSupplyID = IIf(IsDBNull(oCmd.Parameters("@SupplyId").Value), 0, oCmd.Parameters("@SupplyId").Value)
                    iOrderedQty = IIf(IsDBNull(oCmd.Parameters("@OrderedQty").Value), 0, oCmd.Parameters("@OrderedQty").Value)
                    sSupplyRemarks = oCmd.Parameters("@SupplyRemarks").Value & ""
                Else
                    lSupplyID = 0
                    iOrderedQty = 0
                    sSupplyRemarks = ""
                End If
            Catch exp As Exception
                Throw New Exception(" Retrival of Consignee Details error " & exp.Message)
            End Try
        End Sub
        Public Function GetConsigneeCodes() As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            da = rwfGen.Connection.Adapter
            If SupplyID = 0 Then
                da.SelectCommand.CommandText = " select code , name ConsigneeCode from mm_customer_consignee  order by name  "
            Else
                da.SelectCommand.CommandText = " select code , name ConsigneeCode from mm_customer_consignee  order by name  "
            End If
            da.SelectCommand.Parameters.Add("@SupplyId", SqlDbType.BigInt, 8)
            da.SelectCommand.Parameters("@SupplyId").Direction = ParameterDirection.Input
            da.SelectCommand.Parameters.Add("@SupplyPlanId", SqlDbType.BigInt, 8)
            da.SelectCommand.Parameters("@SupplyPlanId").Direction = ParameterDirection.Input
            Try
                da.SelectCommand.Parameters("@SupplyPlanId").Value = lSupplyPlanId
                da.SelectCommand.Parameters("@SupplyId").Value = lSupplyID
                da.Fill(ds)
                GetConsigneeCodes = ds.Tables(0)
            Catch exp As Exception
                GetConsigneeCodes = Nothing
                Throw New Exception("Error in retrival of productList")
            Finally
                ds.Dispose()
                da.Dispose()
                da = Nothing
                ds = Nothing
            End Try
            Return GetConsigneeCodes
        End Function
        Public Function Save(Optional ByVal Delete As Boolean = False) As Boolean
            Dim blnSupplyID As Boolean
            Dim oCmd As SqlClient.SqlCommand
            oCmd = rwfGen.Connection.CmdObj()
            oCmd.Parameters.Add("@SupplyId", SqlDbType.BigInt, 8)
            oCmd.Parameters("@SupplyId").Direction = ParameterDirection.Input
            oCmd.Parameters.Add("@SupplyPlanId", SqlDbType.BigInt, 8)
            oCmd.Parameters("@SupplyPlanId").Direction = ParameterDirection.Input
            oCmd.Parameters.Add("@SupplyConsigneeCode", SqlDbType.VarChar, 50)
            oCmd.Parameters("@SupplyConsigneeCode").Direction = ParameterDirection.Input
            oCmd.Parameters.Add("@OrderedQty", SqlDbType.Int, 4)
            oCmd.Parameters("@OrderedQty").Direction = ParameterDirection.Input
            oCmd.Parameters.Add("@SupplyRemarks", SqlDbType.VarChar, 500)
            oCmd.Parameters("@SupplyRemarks").Direction = ParameterDirection.Input
            oCmd.Parameters.Add("@PONumber", SqlDbType.VarChar, 100)
            oCmd.Parameters("@PONumber").Direction = ParameterDirection.Input
            Try
                oCmd.Parameters("@SupplyId").Value = lSupplyID
                oCmd.Parameters("@SupplyPlanId").Value = lSupplyPlanId
                oCmd.Parameters("@SupplyConsigneeCode").Value = sSupplyConsigneeCode
                oCmd.Parameters("@OrderedQty").Value = iOrderedQty
                oCmd.Parameters("@SupplyRemarks").Value = sSupplyRemarks
                oCmd.Parameters("@PONumber").Value = sPONumber
                blnSupplyID = True
            Catch exp As Exception
                blnSupplyID = False
                Throw New Exception(" Assignment of values to Consignee details error " & exp.Message)
            End Try
            If blnSupplyID = True Then
                blnSupplyID = False
            Else
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
                Exit Function
            End If

            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                If lSupplyID > 0 Then
                    If Delete = False Then
                        SaveWTASupplyDetailsEdit(oCmd)
                    Else
                        SaveWTASupplyDetailsDelete(oCmd)
                    End If
                Else
                    If Delete = False Then SaveWTASupplyDetailsAdd(oCmd)
                End If
                blnSupplyID = True
            Catch exp As Exception
                Throw New Exception("Supplies Details saving to PCO_WTA Tables error : " & exp.Message)
            Finally
                If blnSupplyID = True Then
                    oCmd.Transaction.Commit()
                Else
                    oCmd.Transaction.Rollback()
                End If
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
            Return blnSupplyID
        End Function
        Private Sub SaveWTASupplyDetailsAdd(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " Insert into mm_pco_WTA_Supplies ( PONumber , PlanId , ConsigneeCode , OrderedQty , Remarks ) values ( @PONumber , @SupplyPlanId , @SupplyConsigneeCode , @OrderedQty  , @SupplyRemarks )"
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Adding of WTA Supplies error")
            Catch exp As Exception
                Throw New Exception(" Insert into mm_pco_WTA_Supplies error " & exp.Message)
            End Try
        End Sub
        Private Sub SaveWTASupplyDetailsEdit(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " update mm_pco_WTA_Supplies set PONumber = @PONumber , PlanId = @SupplyPlanId , ConsigneeCode =  @SupplyConsigneeCode , OrderedQty = @OrderedQty ,  Remarks =  @SupplyRemarks where  SupplyID = @SupplyId "
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to update WTA Supplies details ")
            Catch exp As Exception
                Throw New Exception(" update of mm_pco_WTA_Supplies error :  " & exp.Message)
            End Try
        End Sub
        Private Sub SaveWTASupplyDetailsDelete(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " delete  mm_pco_WTA_Supplies where SupplyID = @SupplyId " 'set WtaNumber = @WtaNumber , WtaDate =  @WtaRefDate , Remarks =  @WTARefRemarks
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to delete WTA Supplies details ")
            Catch exp As Exception
                Throw New Exception(" delete of mm_pco_WTA_Supplies error :  " & exp.Message)
            End Try
        End Sub
    End Class
    <Serializable()> Public Class WTA_Compliance
        Private sProductCode As String
        Private lComplianceID, lSupplyId, lSupplyPlanId As Long
        Private sConsigneeCode, sDCNumber, sDCRemarks As String
        Private iDCQty, iDCCount, iCompIdCount As Integer
        Private tblDCNumbers As DataTable
        Private dtFromDate, dtToDate As Date
        ReadOnly Property DCCount()
            Get
                Return iDCCount
            End Get
        End Property
        ReadOnly Property CompIdCount() As Integer
            Get
                Return iCompIdCount
            End Get
        End Property
        WriteOnly Property FromDate() As Date
            Set(ByVal Value As Date)
                dtFromDate = Value
            End Set
        End Property
        WriteOnly Property ToDate() As Date
            Set(ByVal Value As Date)
                dtToDate = Value
            End Set
        End Property
        Property DCNumber() As String
            Get
                Return sDCNumber
            End Get
            Set(ByVal Value As String)
                sDCNumber = Value.Trim.ToUpper
            End Set
        End Property
        Property DCQty() As Integer
            Get
                Return iDCQty
            End Get
            Set(ByVal Value As Integer)
                iDCQty = Value
            End Set
        End Property
        Property DCRemarks() As String
            Get
                Return sDCRemarks
            End Get
            Set(ByVal Value As String)
                sDCRemarks = Value.Trim.ToUpper
            End Set
        End Property
        Property ConsigneeCode() As String
            Get
                Return sConsigneeCode
            End Get
            Set(ByVal Value As String)
                sConsigneeCode = Value.Trim
            End Set
        End Property
        Property ComplianceID() As Long
            Get
                Return lComplianceID
            End Get
            Set(ByVal Value As Long)
                lComplianceID = Value
            End Set
        End Property
        Property SupplyId() As Long
            Get
                Return lSupplyId
            End Get
            Set(ByVal Value As Long)
                lSupplyId = Value
            End Set
        End Property
        Property ProductCode() As String
            Get
                Return sProductCode
            End Get
            Set(ByVal Value As String)
                sProductCode = Value.Trim
            End Set
        End Property
        Property SupplyPlanId() As Long
            Get
                Return lSupplyPlanId
            End Get
            Set(ByVal Value As Long)
                lSupplyPlanId = Value
            End Set
        End Property
        Private Sub intVars()
            sProductCode = ""
            sConsigneeCode = ""
            sDCNumber = ""
            sDCRemarks = ""
            lComplianceID = lSupplyId = iDCQty = lSupplyPlanId = iDCCount = iCompIdCount = 0
            dtFromDate = "1900-01-01"
            dtToDate = "1900-01-01"
        End Sub
        Public Sub New()
            intVars()
        End Sub
        Public Function GetSupplyPlanList(Optional ByVal planID As Long = 0) As DataTable
            Dim WTA_Supplies As New WTA_PlannedSupplies()
            GetSupplyPlanList = WTA_Supplies.GetSupplyPlanList(planID)
        End Function
        Public Function GetSupplyConsigneeList() As DataTable
            Dim WTA_PlannedSupplies As New WTA_PlannedSupplies()
            WTA_PlannedSupplies.SupplyID = lSupplyId
            WTA_PlannedSupplies.SupplyPlanId = lSupplyPlanId
            GetSupplyConsigneeList = WTA_PlannedSupplies.GetSupplyConsigneeList
        End Function
        Public Function GetDCNumbers() As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            Dim WTA_DCNumbers As New DataTable()
            da = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = " select  DcNumber , DcDate , ProductCode , ProdDesc , Consignee , ConsigneeName ,  sum(DespQty) DespQty  from mm_fn_pco_WtaCompliance(@FromDate,@ToDate,@ProductCode,@ConsigneeCode) " & _
                                            " group by DcNumber , DcDate , ProductCode , ProdDesc , Consignee , ConsigneeName "
            da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.SmallDateTime, 4)
            da.SelectCommand.Parameters("@FromDate").Direction = ParameterDirection.Input
            da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.SmallDateTime, 4)
            da.SelectCommand.Parameters("@ToDate").Direction = ParameterDirection.Input
            da.SelectCommand.Parameters.Add("@ProductCode", SqlDbType.VarChar, 6)
            da.SelectCommand.Parameters("@ProductCode").Direction = ParameterDirection.Input
            da.SelectCommand.Parameters.Add("@ConsigneeCode", SqlDbType.VarChar, 50)
            da.SelectCommand.Parameters("@ConsigneeCode").Direction = ParameterDirection.Input
            Try
                da.SelectCommand.Parameters("@FromDate").Value = dtFromDate
                da.SelectCommand.Parameters("@ToDate").Value = dtToDate
                da.SelectCommand.Parameters("@ProductCode").Value = sProductCode
                da.SelectCommand.Parameters("@ConsigneeCode").Value = sConsigneeCode
                da.Fill(ds)
                WTA_DCNumbers = ds.Tables(0)
                iDCCount = ds.Tables(0).Rows.Count
            Catch exp As Exception
                Throw New Exception("Error in retrival of WTA DC Numbers List " & exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                da = Nothing
                ds = Nothing
            End Try
            GetDCNumbers = WTA_DCNumbers
        End Function
        Public Function GetComplianceList() As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            Dim WTA_ComplianceList As New DataTable()
            da = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = " select distinct ComplianceID , SupplyId , PlanId , DCNumber , DCQty , ProductCode , Description , ConsigneeCode , name , DCRemarks " & _
                                            " from mm_vw_pco_WTADetailView where ProductCode = ProductCode and ConsigneeCode = ConsigneeCode and DCNumber in " & _
                                            " ( select  distinct DcNumber  from mm_fn_pco_WtaCompliance(@FromDate,@ToDate,@ProductCode,@ConsigneeCode) " & _
                                            " where  DcDate between @FromDate and @ToDate and  ProductCode =  @ProductCode and Consignee = @ConsigneeCode ) "
            da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.SmallDateTime, 4)
            da.SelectCommand.Parameters("@FromDate").Direction = ParameterDirection.Input
            da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.SmallDateTime, 4)
            da.SelectCommand.Parameters("@ToDate").Direction = ParameterDirection.Input
            da.SelectCommand.Parameters.Add("@ProductCode", SqlDbType.VarChar, 6)
            da.SelectCommand.Parameters("@ProductCode").Direction = ParameterDirection.Input
            da.SelectCommand.Parameters.Add("@ConsigneeCode", SqlDbType.VarChar, 50)
            da.SelectCommand.Parameters("@ConsigneeCode").Direction = ParameterDirection.Input
            Try
                da.SelectCommand.Parameters("@FromDate").Value = dtFromDate
                da.SelectCommand.Parameters("@ToDate").Value = dtToDate
                da.SelectCommand.Parameters("@ProductCode").Value = sProductCode
                da.SelectCommand.Parameters("@ConsigneeCode").Value = sConsigneeCode
                da.Fill(ds)
                WTA_ComplianceList = ds.Tables(0)
                iCompIdCount = ds.Tables(0).Rows.Count
            Catch exp As Exception
                Throw New Exception("Error in retrival of WTA DC Numbers List " & exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                da = Nothing
                ds = Nothing
            End Try
            GetComplianceList = WTA_ComplianceList
        End Function
        Public Function Save(Optional ByVal Delete As Boolean = False) As Boolean
            Dim blnComplianceID As Boolean
            Dim oCmd As SqlClient.SqlCommand
            oCmd = rwfGen.Connection.CmdObj()
            oCmd.Parameters.Add("@ComplianceID", SqlDbType.BigInt, 8)
            oCmd.Parameters("@ComplianceID").Direction = ParameterDirection.Input
            oCmd.Parameters.Add("@SupplyId", SqlDbType.BigInt, 8)
            oCmd.Parameters("@SupplyId").Direction = ParameterDirection.Input
            oCmd.Parameters.Add("@DCNumber", SqlDbType.VarChar, 50)
            oCmd.Parameters("@DCNumber").Direction = ParameterDirection.Input
            oCmd.Parameters.Add("@DCQty", SqlDbType.Int, 4)
            oCmd.Parameters("@DCQty").Direction = ParameterDirection.Input
            oCmd.Parameters.Add("@DCRemarks", SqlDbType.VarChar, 500)
            oCmd.Parameters("@DCRemarks").Direction = ParameterDirection.Input
            Try
                oCmd.Parameters("@ComplianceID").Value = lComplianceID
                oCmd.Parameters("@SupplyId").Value = lSupplyId
                oCmd.Parameters("@DCNumber").Value = sDCNumber
                oCmd.Parameters("@DCQty").Value = iDCQty
                oCmd.Parameters("@DCRemarks").Value = sDCRemarks
                blnComplianceID = True
            Catch exp As Exception
                blnComplianceID = False
                Throw New Exception(" Assignment of values to Consignee details error " & exp.Message)
            End Try
            If blnComplianceID = True Then
                blnComplianceID = False
            Else
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
                Exit Function
            End If

            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                If lComplianceID > 0 Then
                    If Delete = False Then
                        SaveWTAComplianceDetailsEdit(oCmd)
                    Else
                        SaveWTAComplianceDetailsDelete(oCmd)
                    End If
                Else
                    If Delete = False Then SaveWTAComplianceDetailsAdd(oCmd)
                End If
                blnComplianceID = True
            Catch exp As Exception
                Throw New Exception("Compliance Details saving to PCO_WTA Tables error : " & exp.Message)
            Finally
                If blnComplianceID = True Then
                    oCmd.Transaction.Commit()
                Else
                    oCmd.Transaction.Rollback()
                End If
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
            Return blnComplianceID
        End Function
        Private Sub SaveWTAComplianceDetailsAdd(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " Insert into mm_pco_WTA_Compliance ( SupplyId , DCNumber , DCQty , DCRemarks ) values ( @SupplyId , @DCNumber , @DCQty  , @DCRemarks )"
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Adding of WTA Compliance error")
            Catch exp As Exception
                Throw New Exception(" Insert into mm_pco_WTA_Compliance error " & exp.Message)
            End Try
        End Sub
        Private Sub SaveWTAComplianceDetailsEdit(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " update mm_pco_WTA_Compliance set SupplyId = @SupplyId , DCNumber =  @DCNumber , DCQty = @DCQty ,  Remarks =  @DCRemarks where  ComplianceID = @ComplianceID "
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to update WTA Compliance details ")
            Catch exp As Exception
                Throw New Exception(" update of mm_pco_WTA_Compliance error :  " & exp.Message)
            End Try
        End Sub
        Private Sub SaveWTAComplianceDetailsDelete(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " delete  mm_pco_WTA_Compliance where ComplianceID = @ComplianceID "
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to delete WTA Compliance details ")
            Catch exp As Exception
                Throw New Exception(" delete of mm_pco_WTA_Compliance error :  " & exp.Message)
            End Try
        End Sub
    End Class
    Public Class Product
#Region " Fields"
        Private sMessage, sNewProductCode, str, sCastGroup, sAxleProduct, sWheelProduct, sProductMake As String
        Private blnWheel, blnAxle, blnWheelSet, blnOthers, blnAxleEdit, blnDone As Boolean
        Private dtProductList, dtCastGroup, dtMake, dtWheel, dtAxle, dtSource As DataTable
        Private dtNewCGs, dtExistingCGs As DataTable
        Private sMake, sSource, sSourceCode, sR43R16 As String
#End Region
#Region " Property"
        ReadOnly Property Done() As Boolean
            Get
                Return blnDone
            End Get
        End Property
        Property AxleEdit() As Boolean
            Get
                Return blnAxleEdit
            End Get
            Set(ByVal Value As Boolean)
                blnAxleEdit = Value
            End Set
        End Property
        WriteOnly Property ProductMake() As String
            Set(ByVal Value As String)
                sProductMake = Value
            End Set
        End Property
        Property WheelProduct() As String
            Get
                Return sWheelProduct
            End Get
            Set(ByVal Value As String)
                If blnWheelSet Then
                    If Value.ToLower = "select" Then
                        Throw New Exception("InValid Cast Group selection !")
                    Else
                        sWheelProduct = Value
                    End If
                End If
            End Set
        End Property
        Property AxleProduct() As String
            Get
                Return sAxleProduct
            End Get
            Set(ByVal Value As String)
                If blnWheelSet Then
                    If Value.ToLower = "select" Then
                        Throw New Exception("InValid Axle Product selection !")
                    Else
                        sAxleProduct = Value
                    End If
                End If
            End Set
        End Property
        Property CastGroup() As String
            Get
                Return sCastGroup
            End Get
            Set(ByVal Value As String)
                If blnAxle Then
                    If Value.ToLower = "select" Then
                        Throw New Exception("InValid Cast Group selection !")
                    Else
                        sCastGroup = Value
                    End If
                End If
            End Set
        End Property
        Property NewProductCode() As String
            Get
                Return sNewProductCode
            End Get
            Set(ByVal Value As String)
                If blnWheel Then
                    If Value.StartsWith("1") OrElse Value.StartsWith("2") Then
                        sNewProductCode = Value
                    Else
                        Throw New Exception("InValid New Product Code !")
                    End If
                End If
                If blnAxle Then
                    If Value.StartsWith("3") OrElse Value.StartsWith("4") Then
                        sNewProductCode = Value
                    Else
                        Throw New Exception("InValid New Product Code !")
                    End If
                End If
                If blnWheelSet Then
                    If Value.StartsWith("5") OrElse Value.StartsWith("6") Then
                        sNewProductCode = Value
                    Else
                        Throw New Exception("InValid New Product Code !")
                    End If
                End If
            End Set
        End Property
        ReadOnly Property SourceList() As DataTable
            Get
                Return dtSource
            End Get
        End Property
        ReadOnly Property AxleList() As DataTable
            Get
                Return dtAxle
            End Get
        End Property
        ReadOnly Property WheelList() As DataTable
            Get
                Return dtWheel
            End Get
        End Property
        ReadOnly Property AxleMake() As DataTable
            Get
                Return dtMake
            End Get
        End Property
        ReadOnly Property CastGroupList() As DataTable
            Get
                Return dtCastGroup
            End Get
        End Property
        ReadOnly Property ProductList() As DataTable
            Get
                Return dtProductList
            End Get
        End Property
        ReadOnly Property NewCGs() As DataTable
            Get
                Return dtNewCGs
            End Get
        End Property
        ReadOnly Property ExistingCGs() As DataTable
            Get
                Return dtExistingCGs
            End Get
        End Property
        ReadOnly Property Others() As Boolean
            Get
                Return blnOthers
            End Get
        End Property
        ReadOnly Property WheelSet() As Boolean
            Get
                Return blnWheelSet
            End Get
        End Property
        ReadOnly Property Axle() As Boolean
            Get
                Return blnAxle
            End Get
        End Property
        ReadOnly Property Wheel() As Boolean
            Get
                Return blnWheel
            End Get
        End Property
        ReadOnly Property Message() As String
            Get
                Return sMessage
            End Get
        End Property
        Property R43R16() As String
            Get
                Return sR43R16
            End Get
            Set(ByVal Value As String)
                sR43R16 = Value
            End Set
        End Property
        Property Make() As String
            Get
                Return sMake
            End Get
            Set(ByVal Value As String)
                sMake = Value.ToUpper.Trim
                If sSource.Trim.Length > 0 Then
                    If Not CheckSourceCode(sMake, sSource) Then
                        Throw New Exception("SourceCode for the selected Make and Source not available; Contact MIS Centre for source code ! ")
                    End If
                End If
            End Set
        End Property
        Property Source() As String
            Get
                Return sSource
            End Get
            Set(ByVal Value As String)
                sSource = Value.ToUpper.Trim
                If sMake.Trim.Length > 0 Then
                    If Not CheckSourceCode(sMake, sSource) Then
                        Throw New Exception("SourceCode for the selected Make and Source not available; Contact MIS Centre for source code ! ")
                    End If
                End If
            End Set
        End Property
#End Region
#Region " Methods"
        Public Sub New(ByVal ProdType As String, ByVal ProdNature As String, ByVal ServiceType As String, ByVal SuppCondition As String)
            iniVal()
            GetProductCode(ProdType, ProdNature, ServiceType, SuppCondition)
            If blnAxle Then
                dtCastGroup = GetCastGroups()
                dtNewCGs = NewCastGroups(dtCastGroup)
                dtExistingCGs = ExistingCastGroups(dtCastGroup)
                dtMake = GetAxleMake()
                dtSource = GetAxleSource()
            ElseIf blnWheelSet Then
                dtWheel = GetWheelList()
                dtAxle = GetAxleList()
            End If
        End Sub
        Private Sub iniVal()
            blnAxleEdit = False
            sR43R16 = ""
            sMake = ""
            sSource = ""
            sProductMake = ""
            sWheelProduct = ""
            sAxleProduct = ""
            sCastGroup = ""
            sMessage = ""
            sNewProductCode = ""
            str = ""
            blnWheel = False
            blnOthers = False
            blnAxle = False
            blnWheelSet = False
            dtCastGroup = Nothing
            dtMake = Nothing
            dtAxle = Nothing
            dtWheel = Nothing
            dtNewCGs = Nothing
            dtExistingCGs = Nothing
            dtSource = Nothing
        End Sub
        Public Function CheckProdCode(ByVal ProdCode As String, ByVal CastGroup As String, ByVal NewProdCode As String) As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.CommandText = "select @cnt = count(*) from mm_product_master a where a.product_code like '[3,4]%' and a.product_code = @Product_Code and a.cast_group = @CastGroup "
                cmd.Parameters.Add("@Product_Code", SqlDbType.VarChar, 6).Value = ProdCode.Trim
                cmd.Parameters.Add("@CastGroup", SqlDbType.VarChar, 50).Value = CastGroup.Trim
                cmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                cmd.Connection.Open()
                cmd.ExecuteScalar()
                If IIf(IsDBNull(cmd.Parameters("@cnt").Value), 0, cmd.Parameters("@cnt").Value) = 0 Then
                    If ProdCode.Trim = NewProdCode.Trim Then
                        CheckProdCode = True
                    End If
                Else
                    CheckProdCode = True
                End If
            Catch exp As Exception
                Throw New Exception("ProdCode error")
            Finally
                If IsNothing(cmd) = False Then
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                End If
            End Try
        End Function
        Public Function CheckSourceCode(ByVal make As String, ByVal source As String) As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.CommandText = "select @sourceCode = sourceCode  from mm_product_source_codes where make = @make and source = @source"
                cmd.Parameters.Add("@make", SqlDbType.VarChar, 50).Value = make.Trim
                cmd.Parameters.Add("@source", SqlDbType.VarChar, 50).Value = source.Trim
                cmd.Parameters.Add("@sourceCode", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                cmd.Connection.Open()
                cmd.ExecuteScalar()
                If Trim(IIf(IsDBNull(cmd.Parameters("@sourceCode").Value), "", cmd.Parameters("@sourceCode").Value)).Length = 0 Then
                    CheckSourceCode = False
                    sSourceCode = ""
                Else
                    CheckSourceCode = True
                    sSourceCode = Trim(cmd.Parameters("@sourceCode").Value)
                End If
            Catch exp As Exception
                Throw New Exception("ProdCode error")
            Finally
                If IsNothing(cmd) = False Then
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                End If
            End Try
        End Function
        Public Function GetAxleSource() As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            da = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "select distinct rtrim(source) source  from mm_product_source_codes order by source "
            Try
                da.Fill(ds)
                GetAxleSource = ds.Tables(0)
            Catch exp As Exception
                GetAxleSource = Nothing
                Throw New Exception("Error in retrival of Axle Souce List " & exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Function GetWheelList() As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            da = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "select distinct rtrim(ltrim(product_code))  product_code " & _
                " from mm_product_master where product_code like '[1,2]%'  order by product_code "
            Try
                da.Fill(ds)
                GetWheelList = ds.Tables(0)
            Catch exp As Exception
                GetWheelList = Nothing
                Throw New Exception("Error in retrival of AxleMake List " & exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Function GetAxleList() As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            da = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "select distinct rtrim(ltrim(product_code))  product_code " & _
                " from mm_product_master where product_code like '[3,4]%'  order by product_code  "
            Try
                da.Fill(ds)
                GetAxleList = ds.Tables(0)
            Catch exp As Exception
                GetAxleList = Nothing
                Throw New Exception("Error in retrival of AxleMake List " & exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Function GetAxleMake() As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            da = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "select distinct isnull(type,'RWF') Make from mm_product_master " & _
                " where isnull(type,'RWF') <> '' order by isnull(type,'RWF')"
            Try
                da.Fill(ds)
                GetAxleMake = ds.Tables(0)
            Catch exp As Exception
                GetAxleMake = Nothing
                Throw New Exception("Error in retrival of AxleMake List " & exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Function GetCastGroups() As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            da = rwfGen.Connection.Adapter
            'da.SelectCommand.CommandText = "select distinct ltrim(rtrim(cast_group)) cast_group from mm_product_master" & _
            '    " where isnull(cast_group,'') <> ''"
            da.SelectCommand.CommandText = "select * from mm_fn_getCastGroupCodes()"
            Try
                da.Fill(ds)
                GetCastGroups = ds.Tables(0)
            Catch exp As Exception
                GetCastGroups = Nothing
                Throw New Exception("Error in retrival of CastGroups List " & exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Function GetProductDetails(ByVal Pcode As String, ByVal blnWheel As Boolean, ByVal blnAxle As Boolean, ByVal blnWheelSet As Boolean, ByVal blnOthers As Boolean) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            da = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "select rtrim(product_code) Pcode , rtrim(drawing_number) Drg , " & _
                " rtrim(description) Descr , rtrim(long_description) LongDescr" & _
                " from  mm_product_master where product_code like @str " & _
                " order by drawing_number "
            da.SelectCommand.Parameters.Add("@str", SqlDbType.VarChar, 3).Value = str.Trim + "%"
            Try
                da.Fill(ds)
                GetProductDetails = ds.Tables(0)
            Catch exp As Exception
                GetProductDetails = Nothing
                Throw New Exception("Error in retrival of WTA DC Numbers List " & exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Function GetProductCodes(ByVal str As String) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            da = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "select rtrim(product_code) Pcode , rtrim(drawing_number) Drg , " & _
                " rtrim(description) Descr , rtrim(long_description) LongDescr" & _
                " from  mm_product_master where product_code like @str " & _
                " order by drawing_number "
            da.SelectCommand.Parameters.Add("@str", SqlDbType.VarChar, 3).Value = str.Trim + "%"
            Try
                da.Fill(ds)
                GetProductCodes = ds.Tables(0)
            Catch exp As Exception
                GetProductCodes = Nothing
                Throw New Exception("Error in retrival of WTA DC Numbers List " & exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Function ShowSimilarProduct(ByVal basedOn As String, ByVal basedValue As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Select Case basedOn
                Case "Drawing"
                    da.SelectCommand.CommandText = " select a.product_Code , a.description , a.drawing_number , isnull(type,'') type , cast_group from  mm_product_master a where a.product_Code like '[3,4]%' and a.drawing_number = '" & basedValue.Trim & "'"
                Case "Specification"
                    da.SelectCommand.CommandText = " select b.product_code , b.description , b.drawing_number , isnull(type,'') type , cast_group from  " & _
                        " ( select * from mm_AxleProductMaster_R43R16Specs a where a.R43R16 = '" & basedValue.Trim & "' ) a  " & _
                        " inner join mm_product_master b " & _
                        " on a.product_code = b.product_code  " & _
                        " order by a.product_code "
                Case "Make"
                    da.SelectCommand.CommandText = " select b.product_code , b.description , b.drawing_number , isnull(type,'') type , cast_groupfrom  " & _
                                        " mm_product_master b  where isnull(type,'') = '" & basedValue.Trim & "' and product_Code like '[3,4]%' order by a.product_code "
                Case "Source"
                    da.SelectCommand.CommandText = " select b.product_code , b.description , b.drawing_number , isnull(type,'') type , cast_group from  mm_product_master b  " & _
                        " inner join ( select distinct productCode from mm_StageWise_AxleProductMaster  " & _
                        " where sourceCode in ( select sourceCode  from mm_product_source_codes where source = '" & basedValue.Trim & "' )" & _
                        " union  select distinct NextStageProductCode from mm_StageWise_AxleProductMaster" & _
                        " where sourceCode in ( select sourceCode  from mm_product_source_codes where source = '" & basedValue.Trim & "' )) a " & _
                        " on  a.productCode = b.product_code "
                Case "Stage"
                    da.SelectCommand.CommandText = " select a.StageCode , a.ProductCode , ltrim(rtrim(b.description)) description ,  " & _
                        " ltrim(rtrim(b.drawing_number)) drawing_number , isnull(a.NextStageCode,'') NextStageCode ,  " & _
                        " isnull(a.NextStageProductCode,'') NextStageProductCode ,  " & _
                        " case isnull(a.NextStageCode,'') when '' then '' else ltrim(rtrim(c.description)) end NextStageDescription ,  " & _
                        " case isnull(a.NextStageCode,'') when '' then '' else ltrim(rtrim(c.drawing_number)) end NextStageDrawing_number , cast_group  " & _
                        " from  mm_product_master b  " & _
                        " inner join ( select StageCode , ProductCode , NextStageCode , NextStageProductCode from mm_StageWise_AxleProductMaster ) a  " & _
                        " on a.ProductCode = b.product_code " & _
                        " inner join mm_product_master c  " & _
                        " on a.NextStageProductCode = c.product_code " & _
                        " order by a.ProductCode "
                Case "Cast Group"
                    da.SelectCommand.CommandText = " select b.product_code , b.description , b.drawing_number , isnull(type,'') type , cast_group  from  " & _
                                              " mm_product_master b  where cast_group = '" & basedValue.Trim & "' and product_Code like '[3,4]%' order by a.product_code "
                Case Else
                    da.SelectCommand.CommandText = "select * from mm_fn_getCastGroupCodes()"
            End Select
            Try
                da.Fill(ds)
                ShowSimilarProduct = ds.Tables(0).Copy
                ShowSimilarProduct.TableName = "SimilarProduct"
            Catch exp As Exception
                ShowSimilarProduct = Nothing
                Throw New Exception("Unable to Show Similar Product List")
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Function ExistingCastGroups(ByVal tblCastGroups As DataTable) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            da = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "select * from mm_fn_getCastGroupCodes() where used = 1"
            Try
                da.Fill(ds)
                ExistingCastGroups = ds.Tables(0)
            Catch exp As Exception
                ExistingCastGroups = Nothing
                Throw New Exception("Error in retrival of CastGroups List " & exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Function NewCastGroups(ByVal tblCastGroups As DataTable) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter
            Dim ds As New DataSet()
            da = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "select * from mm_fn_getCastGroupCodes() where used = 0"
            Try
                da.Fill(ds)
                NewCastGroups = ds.Tables(0)
            Catch exp As Exception
                NewCastGroups = Nothing
                Throw New Exception("Error in retrival of CastGroups List " & exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Private Sub GetProductCode(ByVal ProdType As String, ByVal ProdNature As String, ByVal ServiceType As String, ByVal SuppCondition As String)
            Select Case ProdNature + ProdType
                Case "BGWheel"
                    ProdNature = "1"
                    blnWheel = True
                Case "MGWheel"
                    ProdNature = "2"
                    blnWheel = True
                Case "OthersWheel"
                    ProdNature = "2"
                    blnWheel = True
                Case "BGAxle"
                    ProdNature = "3"
                    blnAxle = True
                Case "MGAxle"
                    ProdNature = "4"
                    blnAxle = True
                Case "BGWheel Set"
                    ProdNature = "5"
                    blnWheelSet = True
                Case "MGWheel Set"
                    ProdNature = "6"
                    blnWheelSet = True
                Case "OthersOthers"
                    ProdNature = "9"
                    blnOthers = True
                Case Else
                    Throw New Exception("InValid Selection !")
            End Select
            str = ProdNature.Trim + ServiceType.Trim
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@Prodnature", SqlDbType.VarChar, 1).Value = ProdNature
            cmd.Parameters.Add("@ServiceType", SqlDbType.VarChar, 1).Value = ServiceType
            cmd.Parameters.Add("@SuppCondition", SqlDbType.VarChar, 6).Value = SuppCondition
            cmd.Parameters.Add("@@ProdCode", SqlDbType.VarChar, 6).Direction = ParameterDirection.Output
            cmd.CommandText = "mm_sp_GenerateProductCode"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection.Open()
            Try
                cmd.ExecuteScalar()
                sNewProductCode = IIf(IsDBNull(cmd.Parameters("@@ProdCode").Value), "", cmd.Parameters("@@ProdCode").Value)
            Catch exp As Exception
                sNewProductCode = ""
                Throw New Exception("InValid Product Code Generation !")
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
            Try
                dtProductList = GetProductCodes(str)
            Catch exp As Exception
                Throw New Exception("Product Codes retrival error !")
            End Try
        End Sub
        Public Function Product(ByVal ShortDescription As String, ByVal LongDescription As String, ByVal Drawing As String, ByVal Specification As String, ByVal ScrapPercentage As Double, ByVal prodwtg As Double, ByVal product_weightage_at_forge_shop As Double, ByVal loss_percentage As Double, ByVal ProductClass As String, ByVal Transfer_price As Double, ByVal Rough_weight As Double, ByVal Finish_weight As Double, ByVal Wheels_per_heat As Integer, ByVal Sale_price As Double, ByVal WTAName As String, ByVal customer_drawing_number As String, ByVal low_bhn As Integer, ByVal high_bhn As Integer, ByVal WeightPerWheel As Decimal, ByVal RejPercent As Decimal, ByVal SeriesStart As Integer, ByVal SereiesEnd As Integer, ByVal WheelPerMT As Decimal, ByVal MRRejPercent As Decimal, ByVal MinTreadDia As Double, ByVal MaxTreadDia As Double, ByVal MinBoreDia As Double, ByVal MaxBoreDia As Double, ByVal MinPlateThickness As Double, ByVal MaxPlateThickness As Double, ByVal OverSizeMin As Double, ByVal OverSizeMax As Double, ByVal SplSizeMin As Double, ByVal SplSizeMax As Double, ByVal McnMinDia As Double, ByVal min_pressure As Integer, ByVal max_pressure As Integer, ByVal Min_Guage As Decimal, ByVal Max_Guage As Decimal, ByVal MinWhlNo As Integer, ByVal MaxWhlNo As Integer, ByVal axle_size As Double) As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj()
            oCmd.Parameters.Add("@NewProductCode", SqlDbType.VarChar, 50).Value = sNewProductCode
            oCmd.Parameters.Add("@Description", SqlDbType.VarChar, 50).Value = ShortDescription
            oCmd.Parameters.Add("@Drawing", SqlDbType.VarChar, 50).Value = Drawing
            oCmd.Parameters.Add("@Specification", SqlDbType.VarChar, 50).Value = Specification.Trim
            oCmd.Parameters.Add("@ScrapPercentage", SqlDbType.Float, 8).Value = Val(ScrapPercentage)
            oCmd.Parameters.Add("@prodwtg", SqlDbType.Float, 8).Value = Val(prodwtg)
            oCmd.Parameters.Add("@product_weightage_at_forge_shop", SqlDbType.Float, 8).Value = Val(product_weightage_at_forge_shop)
            oCmd.Parameters.Add("@loss_percentage", SqlDbType.Float, 8).Value = Val(loss_percentage)
            oCmd.Parameters.Add("@ProductClass", SqlDbType.VarChar, 10).Value = ProductClass.Trim
            oCmd.Parameters.Add("@Transfer_price", SqlDbType.Float, 8).Value = Val(Transfer_price)
            oCmd.Parameters.Add("@Rough_weight", SqlDbType.Float, 8).Value = Val(Rough_weight)
            oCmd.Parameters.Add("@Finish_weight", SqlDbType.Float, 8).Value = Val(Finish_weight)
            oCmd.Parameters.Add("@cast_group", SqlDbType.VarChar, 50).Value = sCastGroup.Trim
            oCmd.Parameters.Add("@Wheels_per_heat", SqlDbType.Int, 4).Value = Val(Wheels_per_heat)
            oCmd.Parameters.Add("@Sale_price", SqlDbType.Float, 8).Value = Val(Sale_price)
            oCmd.Parameters.Add("@LongDescription", SqlDbType.VarChar, 1000).Value = LongDescription.Trim
            oCmd.Parameters.Add("@Make", SqlDbType.VarChar, 50).Value = sProductMake.Trim
            oCmd.Parameters.Add("@WTAName", SqlDbType.VarChar, 50).Value = WTAName.Trim
            oCmd.Parameters.Add("@customer_drawing_number", SqlDbType.VarChar, 50).Value = customer_drawing_number.Trim
            oCmd.Parameters.Add("@prod_id1", SqlDbType.VarChar, 50).Value = sWheelProduct.Trim
            oCmd.Parameters.Add("@prod_id2", SqlDbType.VarChar, 50).Value = sAxleProduct.Trim
            oCmd.Parameters.Add("@low_bhn", SqlDbType.Int, 4).Value = Val(low_bhn)
            oCmd.Parameters.Add("@high_bhn", SqlDbType.Int, 4).Value = Val(high_bhn)
            oCmd.Parameters.Add("@axle_size", SqlDbType.Float, 9).Value = Val(axle_size)
            oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output

            oCmd.Parameters.Add("@WeightPerWheel", SqlDbType.Float, 8).Value = Val(WeightPerWheel)
            oCmd.Parameters.Add("@RejPercent", SqlDbType.Float, 8).Value = Val(RejPercent)
            oCmd.Parameters.Add("@SeriesStart", SqlDbType.Int, 4).Value = SeriesStart
            oCmd.Parameters.Add("@SereiesEnd", SqlDbType.Int, 4).Value = SereiesEnd
            oCmd.Parameters.Add("@WheelPerMT", SqlDbType.Float, 8).Value = Val(WheelPerMT)
            oCmd.Parameters.Add("@MRRejPercent", SqlDbType.Float, 8).Value = Val(MRRejPercent)
            oCmd.Parameters.Add("@min_pressure", SqlDbType.Int, 4).Value = min_pressure
            oCmd.Parameters.Add("@max_pressure", SqlDbType.Int, 4).Value = max_pressure
            oCmd.Parameters.Add("@Min_Guage", SqlDbType.Float, 8).Value = Val(Min_Guage)
            oCmd.Parameters.Add("@Max_Guage", SqlDbType.Float, 8).Value = Val(Max_Guage)
            oCmd.Parameters.Add("@MinTreadDia", SqlDbType.Float, 8).Value = Val(MinTreadDia)
            oCmd.Parameters.Add("@MaxTreadDia", SqlDbType.Float, 8).Value = Val(MaxTreadDia)
            oCmd.Parameters.Add("@MinBoreDia", SqlDbType.Float, 8).Value = Val(MinBoreDia)
            oCmd.Parameters.Add("@MaxBoreDia", SqlDbType.Float, 8).Value = Val(MaxBoreDia)
            oCmd.Parameters.Add("@MinPlateThickness", SqlDbType.Float, 8).Value = Val(MinPlateThickness)
            oCmd.Parameters.Add("@MaxPlateThickness", SqlDbType.Float, 8).Value = Val(MaxPlateThickness)
            oCmd.Parameters.Add("@OverSizeMin", SqlDbType.Float, 8).Value = Val(OverSizeMin)
            oCmd.Parameters.Add("@OverSizeMax", SqlDbType.Float, 8).Value = Val(OverSizeMax)
            oCmd.Parameters.Add("@SplSizeMin", SqlDbType.Float, 8).Value = Val(SplSizeMin)
            oCmd.Parameters.Add("@SplSizeMax", SqlDbType.Float, 8).Value = Val(SplSizeMax)
            oCmd.Parameters.Add("@McnMinDia", SqlDbType.Float, 8).Value = Val(McnMinDia)
            oCmd.Parameters.Add("@MinWhlNo", SqlDbType.Float, 8).Value = Val(MinWhlNo)
            oCmd.Parameters.Add("@MaxWhlNo", SqlDbType.Float, 8).Value = Val(MaxWhlNo)

            Dim Done As Boolean
            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            Try
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                oCmd.CommandText = "select @cnt = count(*) from mm_product_master where product_code = @NewProductCode "
                oCmd.ExecuteScalar()
                If IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value) = 0 Then
                    oCmd.CommandText = "insert into mm_product_master ( product_code , description , drawing_number , " & _
                        " specification , scrap_percentage , product_weightage , product_weightage_at_forge_shop , " & _
                        " loss_percentage , class , transfer_price , rough_weight , finished_weight ,  cast_group , " & _
                        " wheels_per_heat , sale_price , long_description , type , customer_drawing_number , WTAName ," & _
                        " prod_id1 , prod_id2 , low_bhn , high_bhn , axle_size  ) values " & _
                        " ( @NewProductCode , @Description , @Drawing , @Specification , @ScrapPercentage , " & _
                        " @prodwtg , @product_weightage_at_forge_shop , @loss_percentage , @ProductClass , " & _
                        " @Transfer_price , @Rough_weight , @Finish_weight , @cast_group , " & _
                        " @Wheels_per_heat , @Sale_price , @LongDescription , @Make , @customer_drawing_number , @WTAName ," & _
                        " @prod_id1 , @prod_id2 , @low_bhn , @high_bhn , @axle_size )"
                Else
                    oCmd.CommandText = "update mm_product_master set " & _
                        " specification = @Specification , scrap_percentage = @ScrapPercentage , " & _
                        " product_weightage = @prodwtg , product_weightage_at_forge_shop = @product_weightage_at_forge_shop , " & _
                        " loss_percentage = @loss_percentage , class = @ProductClass , transfer_price = @Transfer_price , " & _
                        " rough_weight = @Rough_weight , finished_weight = @Finish_weight  , prod_desc = @LongDescription , " & _
                        " wheels_per_heat = @Wheels_per_heat , sale_price = @Sale_price , long_description = @LongDescription , " & _
                        " customer_drawing_number = @customer_drawing_number , WTAName = @WTAName , " & _
                        " low_bhn = @low_bhn , high_bhn = @high_bhn , axle_size = @axle_size " & _
                        " where product_code = @NewProductCode "
                End If
                If oCmd.ExecuteNonQuery = 1 Then Done = True
                If Done Then
                    Done = False
                    oCmd.CommandText = "select @cnt = count(*) from mm_product_details where product_code = @NewProductCode "
                    oCmd.ExecuteScalar()
                    If IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value) = 0 Then
                        If blnWheel Then
                            oCmd.CommandText = "INSERT INTO mm_product_details ( product_code , drawing_number, MinWhlNo ,  MaxWhlNo , " & _
                                " description , wt_per_wheel , rej_percent , series_start , series_end , whl_per_MT  , MR_Rej_Percent ) " & _
                                " Values ( @NewProductCode , @Drawing , @MinWhlNo , @MaxWhlNo , " & _
                                " @Description , @WeightPerWheel , @RejPercent , @SeriesStart , @SereiesEnd , @WheelPerMT , @MRRejPercent )"
                        ElseIf blnAxle Then
                            oCmd.CommandText = "INSERT INTO mm_product_details ( product_code , drawing_number,  " & _
                                " description )  Values ( @NewProductCode , @Drawing , @Description  ) "
                        ElseIf blnWheelSet Then
                            oCmd.Parameters.Add("@Product_id1_source", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                            oCmd.Parameters.Add("@Product_id2_Source", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output

                            oCmd.CommandText = "select @Product_id1_source = case when isnull(type,'') = '' then 'RWF' else rtrim(isnull(type,'')) end " & _
                                " from mm_product_master where Product_Code = @prod_id1 ;" & _
                                " select @Product_id2_source = case when isnull(type,'') = '' then 'RWF' else rtrim(isnull(type,'')) end " & _
                                " from mm_product_master where Product_Code = @prod_id2 "
                            oCmd.ExecuteScalar()
                            oCmd.Parameters("@Product_id1_source").Direction = ParameterDirection.Input
                            oCmd.Parameters("@Product_id2_source").Direction = ParameterDirection.Input

                            oCmd.CommandText = "INSERT INTO mm_product_details ( product_code , drawing_number,  " & _
                                " description , Product_id1_source , Product_id2_source )  Values " & _
                                " ( @NewProductCode , @Drawing , @Description , @Product_id1_source , @Product_id2_source ) "
                        End If
                        If oCmd.ExecuteNonQuery = 1 Then Done = True
                    Else
                        If blnWheel Then
                            oCmd.CommandText = "update mm_product_details set " & _
                            " wt_per_wheel = @WeightPerWheel , rej_percent = @RejPercent , " & _
                            " series_start = @SeriesStart , series_end  = @SereiesEnd , whl_per_MT  = @WheelPerMT  , MR_Rej_Percent = @MRRejPercent " & _
                            " where product_code = @NewProductCode "
                            If oCmd.ExecuteNonQuery = 1 Then Done = True
                        Else
                            Done = True
                        End If
                    End If
                End If
                If Done Then
                    Done = False
                    If blnWheel Then
                        oCmd.CommandText = "select @cnt = count(*) from mm_ProductwiseTreadAndBoreSizes where ProductCode = @NewProductCode "
                        oCmd.ExecuteScalar()
                        If IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value) = 0 Then
                            oCmd.CommandText = "insert into mm_ProductwiseTreadAndBoreSizes " & _
                            " ( ProductCode , MinTreadDia , MaxTreadDia , MinBoreDia , MaxBoreDia , MinPlateThickness , MaxPlateThickness ," & _
                            " OverSizeMin , OverSizeMax , SplSizeMin , SplSizeMax , McnMinDia  ) values " & _
                            " ( @NewProductCode , @MinTreadDia , @MaxTreadDia , @MinBoreDia , @MaxBoreDia , @MinPlateThickness , @MaxPlateThickness ," & _
                            " @OverSizeMin , @OverSizeMax , @SplSizeMin , @SplSizeMax , @McnMinDia  ) "
                        Else
                            oCmd.CommandText = "update mm_ProductwiseTreadAndBoreSizes set " & _
                            " MinTreadDia = @MinTreadDia , MaxTreadDia = @MaxTreadDia , MinBoreDia = @MinBoreDia , " & _
                            " MaxBoreDia = @MaxBoreDia , MinPlateThickness = @MinPlateThickness , MaxPlateThickness = @MaxPlateThickness ," & _
                            " OverSizeMin = @OverSizeMin , OverSizeMax = @OverSizeMax , SplSizeMin = @SplSizeMin , SplSizeMax = @SplSizeMax , McnMinDia  = @McnMinDia " & _
                            " where ProductCode = @NewProductCode "
                        End If
                        If oCmd.ExecuteNonQuery = 1 Then Done = True
                    ElseIf blnAxle Then
                        oCmd.CommandText = "select @cnt = count(*) from mm_AxleProdExtDetails where prodCode = @NewProductCode "
                        oCmd.ExecuteScalar()
                        If IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value) = 0 Then
                            oCmd.CommandText = "INSERT INTO mm_AxleProdExtDetails ( prodCode )  " & _
                            " Values ( @NewProductCode ) "
                            If oCmd.ExecuteNonQuery = 1 Then Done = True
                        Else
                            Done = True
                        End If
                    ElseIf blnWheelSet Then
                        oCmd.CommandText = "select @cnt = count(*) from mm_wheelset_mountPressures where Product_Code = @NewProductCode "
                        oCmd.ExecuteScalar()
                        If IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value) = 0 Then
                            oCmd.CommandText = "INSERT INTO mm_wheelset_mountPressures ( product_code , min_pressure , max_pressure )  " & _
                            " Values ( @NewProductCode , @min_pressure , @max_pressure  ) "
                        Else
                            oCmd.CommandText = "update mm_wheelset_mountPressures set min_pressure = @min_pressure , " & _
                            " max_pressure = @max_pressure  " & _
                            " where product_code = @NewProductCode "
                        End If
                        If oCmd.ExecuteNonQuery = 1 Then
                            oCmd.CommandText = "select @cnt = count(*) from mm_wheelset_Trackguages where Product_Code = @NewProductCode "
                            oCmd.ExecuteScalar()
                            If IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value) = 0 Then
                                oCmd.CommandText = "INSERT INTO mm_wheelset_Trackguages ( product_code , Description , Min_Guage , max_Guage )  " & _
                                " Values ( @NewProductCode , @Description , @Min_Guage , @max_Guage  ) "
                            Else
                                oCmd.CommandText = "update mm_wheelset_Trackguages set Min_Guage = @Min_Guage , " & _
                                " max_Guage = @max_Guage  " & _
                                " where product_code = @NewProductCode "
                            End If
                            If oCmd.ExecuteNonQuery = 1 Then Done = True
                        End If
                    End If
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If IsNothing(oCmd) = False Then
                    If Done Then
                        oCmd.Transaction.Commit()
                        sMessage = "Updation successful"
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
        Public Function SaveAxleSpec(ByVal ProdCode As String) As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Parameters.Add("@cast_group", SqlDbType.VarChar, 50).Value = sCastGroup
                cmd.Parameters.Add("@Product_Code", SqlDbType.VarChar, 50).Value = ProdCode
                cmd.Parameters.Add("@Make", SqlDbType.VarChar, 50).Value = sMake & ""
                cmd.Parameters.Add("@Source", SqlDbType.VarChar, 50).Value = sSource
                cmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                cmd.CommandText = " select @cnt = count(*) from mm_product_master where product_code IN( @Product_Code ) and (isnull(cast_group,'') = '' OR isnull(type,'') = '' )"
                cmd.ExecuteScalar()
                If IIf(IsDBNull(cmd.Parameters("@cnt").Value), 0, cmd.Parameters("@cnt").Value) > 0 Then
                    cmd.CommandText = " update mm_product_master set type = @Make , cast_group = @cast_group  where product_code IN( @Product_Code) "
                    If cmd.ExecuteNonQuery > 0 Then
                        cmd.CommandText = " update mm_product_master set type = '' where type = 'RWF'"
                        cmd.ExecuteNonQuery()
                        blnDone = True
                    End If
                Else
                    blnDone = True
                End If
                If blnDone Then
                    blnDone = False
                    cmd.Parameters("@cnt").Value = 0
                    cmd.CommandText = " select @cnt = count(*) from mm_AxleProductMaster_R43R16Specs where product_code = @Product_Code "
                    cmd.ExecuteScalar()
                    cmd.Parameters.Add("@R43R16", SqlDbType.VarChar, 50).Value = sR43R16
                    If IIf(IsDBNull(cmd.Parameters("@cnt").Value), 0, cmd.Parameters("@cnt").Value) = 0 Then
                        cmd.CommandText = "  insert into mm_AxleProductMaster_R43R16Specs ( Product_code , R43R16 ) select @Product_Code, @R43R16  "
                    Else
                        cmd.CommandText = " update mm_AxleProductMaster_R43R16Specs set R43R16 = @R43R16  where product_code IN( @Product_Code ) "
                    End If
                    If cmd.ExecuteNonQuery > 0 Then blnDone = True
                End If
            Catch exp As Exception
                sMessage = "Updation Failed  " & exp.Message
            Finally
                If IsNothing(cmd) = False Then
                    If blnDone Then
                        cmd.Transaction.Commit()
                        sMessage = "Updation successful"
                    Else
                        cmd.Transaction.Rollback()
                    End If
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                End If
            End Try
        End Function
        Public Function Save(ByVal ProdCode As String, ByVal make As String, ByVal source As String, ByVal InitialStage As String, ByVal NextRTProdCode As String, ByVal NextFIProdCode As String) As Boolean
            If ProdCode = "" Or sMake = "" Or sSourceCode = "" Then
                Throw New Exception("Invalid Values for saving ! Cannot save")
            End If
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@Product_Code", SqlDbType.VarChar, 50).Value = ProdCode
            cmd.Parameters.Add("@Make", SqlDbType.VarChar, 50).Value = sMake & ""
            cmd.Parameters.Add("@Source", SqlDbType.VarChar, 50).Value = sSource
            cmd.Parameters.Add("@SourceCode", SqlDbType.VarChar, 50).Value = sSourceCode
            cmd.Parameters.Add("@NextRTProdCode", SqlDbType.VarChar, 50).Value = NextRTProdCode.Trim
            cmd.Parameters.Add("@NextFIProdCode", SqlDbType.VarChar, 50).Value = NextFIProdCode.Trim
            Dim strFGtoRT, strFGtoFI, strRTtoRT, strRTtoFI, strFItoFI As String
            Dim blnDone As New Boolean()
            blnDone = False
            Try
                cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                Select Case InitialStage.Trim
                    Case "FG"
                        InitialStage = "FG"
                        If NextFIProdCode.Trim.Length = 0 Then
                            NextRTProdCode = NextRTProdCode
                            NextFIProdCode = ""
                            cmd.CommandText = " select count(*) from mm_StageWise_AxleProductMaster where StageCode =  'FG' and SourceCode =  @SourceCode and ProductCode =  @Product_Code and NextStageCode =  'RT' and NextStageProductCode =  @Product_Code "
                            If cmd.ExecuteScalar = 0 Then
                                cmd.CommandText = "  insert into mm_StageWise_AxleProductMaster " & _
                                        " ( StageCode , SourceCode , ProductCode , NextStageCode , NextStageProductCode ) " & _
                                        "  select 'FG' , @SourceCode , @Product_Code , 'RT' , @NextRTProdCode "
                                If cmd.ExecuteNonQuery = 1 Then blnDone = True
                            Else
                                blnDone = True
                            End If
                        Else
                            NextRTProdCode = NextRTProdCode
                            NextFIProdCode = NextFIProdCode
                            cmd.CommandText = " select count(*) from mm_StageWise_AxleProductMaster where StageCode =  'FG' and SourceCode =  @SourceCode and ProductCode =  @Product_Code and NextStageCode =  'RT' and NextStageProductCode =  @Product_Code "
                            If cmd.ExecuteScalar = 0 Then
                                cmd.CommandText = "  insert into mm_StageWise_AxleProductMaster " & _
                                        " ( StageCode , SourceCode , ProductCode , NextStageCode , NextStageProductCode ) " & _
                                        "  select 'FG' , @SourceCode , @Product_Code , 'RT' , @NextRTProdCode "
                                If cmd.ExecuteNonQuery = 1 Then
                                    cmd.CommandText = " select count(*) from mm_StageWise_AxleProductMaster where StageCode =  'RT' and SourceCode =  @SourceCode and ProductCode =  @Product_Code and NextStageCode =  'FI' and NextStageProductCode =  @Product_Code "
                                    If cmd.ExecuteScalar = 0 Then
                                        cmd.CommandText = "  insert into mm_StageWise_AxleProductMaster " & _
                                        " ( StageCode , SourceCode , ProductCode , NextStageCode , NextStageProductCode ) " & _
                                        "  select 'RT' , @SourceCode , @NextRTProdCode , 'FI' , @NextFIProdCode "
                                        If cmd.ExecuteNonQuery = 1 Then blnDone = True
                                    Else
                                        blnDone = True
                                    End If
                                End If
                            Else
                                cmd.CommandText = " select count(*) from mm_StageWise_AxleProductMaster where StageCode =  'RT' and SourceCode =  @SourceCode and ProductCode =  @Product_Code and NextStageCode =  'FI' and NextStageProductCode =  @Product_Code "
                                If cmd.ExecuteScalar = 0 Then
                                    cmd.CommandText = "  insert into mm_StageWise_AxleProductMaster " & _
                                        " ( StageCode , SourceCode , ProductCode , NextStageCode , NextStageProductCode ) " & _
                                        " select 'RT' , @SourceCode , @NextRTProdCode , 'FI' , @NextFIProdCode "
                                    If cmd.ExecuteNonQuery = 1 Then blnDone = True
                                Else
                                    blnDone = True
                                End If
                            End If
                        End If
                    Case "RT"
                        InitialStage = "RT"
                        NextRTProdCode = NextRTProdCode
                        If NextFIProdCode.Trim.Length = 0 Then
                            cmd.CommandText = " select count(*) from mm_StageWise_AxleProductMaster where StageCode =  'RT' and SourceCode =  @SourceCode and ProductCode =  @Product_Code and NextStageCode =  'RT' and NextStageProductCode =  @Product_Code"
                            If cmd.ExecuteScalar = 0 Then
                                cmd.CommandText = "  insert into mm_StageWise_AxleProductMaster " & _
                                " ( StageCode , SourceCode , ProductCode , NextStageCode , NextStageProductCode ) " & _
                                " select 'RT' , @SourceCode , @Product_Code , 'RT' , @Product_Code "
                                If cmd.ExecuteNonQuery = 1 Then blnDone = True
                            Else
                                blnDone = True
                            End If
                        Else
                            cmd.CommandText = "  select count(*) from mm_StageWise_AxleProductMaster where StageCode =  'RT' and SourceCode =  @SourceCode and ProductCode =  @Product_Code and NextStageCode =  'RT' and NextStageProductCode =  @Product_Code "
                            If cmd.ExecuteScalar = 0 Then
                                cmd.CommandText = "  insert into mm_StageWise_AxleProductMaster " & _
                                    " ( StageCode , SourceCode , ProductCode , NextStageCode , NextStageProductCode ) " & _
                                    " select 'RT' , @SourceCode , @Product_Code , 'FI' , @NextFIProdCode "
                                If cmd.ExecuteNonQuery = 1 Then blnDone = True
                            Else
                                blnDone = True
                            End If
                        End If
                    Case "FI"
                        InitialStage = "FI"
                        NextRTProdCode = ""
                        NextFIProdCode = NextFIProdCode
                        cmd.CommandText = " select count(*) from mm_StageWise_AxleProductMaster where StageCode =  'FI' and SourceCode =  @SourceCode and ProductCode =  @Product_Code and NextStageCode =  'FI' and NextStageProductCode =  @Product_Code "
                        If cmd.ExecuteScalar = 0 Then
                            cmd.CommandText = "  insert into mm_StageWise_AxleProductMaster " & _
                                " ( StageCode , SourceCode , ProductCode , NextStageCode , NextStageProductCode ) " & _
                                " select 'FI' , @SourceCode , @Product_Code , 'FI' , @NextFIProdCode "
                            If cmd.ExecuteNonQuery = 1 Then blnDone = True
                        Else
                            blnDone = True
                        End If
                End Select
            Catch exp As Exception
                blnDone = False
                sMessage = exp.Message
            Finally
                If IsNothing(cmd) = False Then
                    If Not blnDone Then
                        cmd.Transaction.Rollback()
                        If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                        cmd.Dispose()
                        cmd = Nothing
                    End If
                End If
            End Try
            If blnDone = False Then
                Exit Function
            Else
                blnDone = False
                Try
                    cmd.Parameters.Add("@cast_group", SqlDbType.VarChar, 50).Value = sCastGroup
                    cmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                    cmd.CommandText = " select @cnt = count(*) from mm_product_master where product_code IN( @Product_Code, @NextFIProdCode) and (isnull(cast_group,'') = '' OR isnull(type,'') = '' )"
                    cmd.ExecuteScalar()
                    If IIf(IsDBNull(cmd.Parameters("@cnt").Value), 0, cmd.Parameters("@cnt").Value) > 0 Then
                        cmd.CommandText = " update mm_product_master set type = @Make , cast_group = @cast_group  where product_code IN( @Product_Code, @NextFIProdCode) "
                        If cmd.ExecuteNonQuery > 0 Then
                            cmd.CommandText = " update mm_product_master set type = '' where type = 'RWF'"
                            cmd.ExecuteNonQuery()
                            blnDone = True
                        End If
                    Else
                        blnDone = True
                    End If
                    If blnDone Then
                        blnDone = False
                        cmd.Parameters("@cnt").Value = 0
                        cmd.CommandText = " select @cnt = count(*) from mm_AxleProductMaster_R43R16Specs where product_code = @Product_Code "
                        cmd.ExecuteScalar()
                        cmd.Parameters.Add("@R43R16", SqlDbType.VarChar, 50).Value = sR43R16
                        If IIf(IsDBNull(cmd.Parameters("@cnt").Value), 0, cmd.Parameters("@cnt").Value) = 0 Then
                            cmd.CommandText = "  insert into mm_AxleProductMaster_R43R16Specs ( Product_code , R43R16 ) select @Product_Code, @R43R16  "
                        Else
                            cmd.CommandText = " update mm_AxleProductMaster_R43R16Specs set R43R16 = @R43R16  where product_code IN( @Product_Code ) "
                        End If
                        If cmd.ExecuteNonQuery > 0 Then blnDone = True
                    End If
                Catch exp As Exception
                    sMessage = "Updation Failed  " & exp.Message
                Finally
                    If IsNothing(cmd) = False Then
                        If blnDone Then
                            cmd.Transaction.Commit()
                            sMessage = "Updation successful"
                        Else
                            cmd.Transaction.Rollback()
                        End If
                        If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                        cmd.Dispose()
                        cmd = Nothing
                    End If
                End Try
            End If
            If blnDone Then
                blnDone = False
                Dim ocmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
                ocmd.Connection.Open()
                ocmd.Transaction = ocmd.Connection.BeginTransaction
                Try
                    ocmd.Parameters.Add("@Product_Code", SqlDbType.VarChar, 50).Value = ProdCode
                    ocmd.Parameters.Add("@Source", SqlDbType.VarChar, 50).Value = sSource
                    ocmd.Parameters.Add("@SaveDateTime", SqlDbType.DateTime, 8).Value = Now
                    ocmd.CommandText = " update a set Make = c.type , CtGroup = c.cast_group , R43R16 = d.R43R16 ,  " & _
                                        " ProcuredBy = @Source ,  a.StageCode = b.StageCode , a.NextStageCode = b.NextStageCode , a.NextStageProductCode = b.NextStageProductCode  " & _
                                        " , SaveDateTime = @SaveDateTime from mm_AxleProdExtDetails a  inner join mm_StageWise_AxleProductMaster b " & _
                                        " on a.prodCode = b.ProductCode inner join mm_Product_Master c " & _
                                        " on c.product_Code = a.prodCode inner join mm_AxleProductMaster_R43R16Specs d " & _
                                        " on d.product_Code = a.prodCode where b.productcode = @Product_Code "
                    If ocmd.ExecuteNonQuery > 0 Then blnDone = True
                Catch exp As Exception
                    sMessage = exp.Message
                Finally
                    If IsNothing(ocmd) = False Then
                        If blnDone Then
                            ocmd.Transaction.Commit()
                            sMessage = "Record updated"
                        Else
                            ocmd.Transaction.Rollback()
                            sMessage = sMessage & " but AxleProd ExtDetails  entry failed "
                        End If
                        If ocmd.Connection.State = ConnectionState.Open Then ocmd.Connection.Close()
                        ocmd.Dispose()
                        ocmd = Nothing
                    End If
                End Try
            End If
            Save = blnDone
        End Function
        Public Sub SaveUnifiedPL(ByVal ProdCode As String, ByVal UnifiedPL As String, ByVal ItemDescription As String, ByVal SpecificationNo As String, ByVal DrawingNo As String, ByVal Category As String)
            Dim blnDone As Boolean
            Dim ocmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            ocmd.Connection.Open()
            ocmd.Transaction = ocmd.Connection.BeginTransaction
            Try
                ocmd.Parameters.Add("@ProductCode", SqlDbType.VarChar, 50).Value = ProdCode
                ocmd.Parameters.Add("@UnifiedPL", SqlDbType.VarChar, 50).Value = UnifiedPL
                ocmd.Parameters.Add("@ItemDescription", SqlDbType.VarChar, 250).Value = ItemDescription
                ocmd.Parameters.Add("@SpecificationNo", SqlDbType.VarChar, 250).Value = SpecificationNo
                ocmd.Parameters.Add("@DrawingNo", SqlDbType.VarChar, 250).Value = DrawingNo
                ocmd.Parameters.Add("@Category", SqlDbType.VarChar, 50).Value = Category
                ocmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                ocmd.CommandText = " select @cnt = count(*) from mm_product_UnifiedPL_Details  " & _
                                " where UnifiedPL = @UnifiedPL "
                ocmd.ExecuteScalar()

                If IIf(IsDBNull(ocmd.Parameters("@cnt").Value), 0, ocmd.Parameters("@cnt").Value) = 0 Then
                    ocmd.CommandText = " insert into mm_product_UnifiedPL_Details " & _
                            " ( UnifiedPL , ItemDescription , SpecificationNo , DrawingNo , Category  ) " & _
                            " values ( @UnifiedPL , @ItemDescription , @SpecificationNo , @DrawingNo , @Category )"
                Else
                    ocmd.CommandText = " update mm_product_UnifiedPL_Details  " & _
                            " set ItemDescription = @ItemDescription , " & _
                            " SpecificationNo = @SpecificationNo , DrawingNo = @DrawingNo , Category = @Category " & _
                            " where UnifiedPL = @UnifiedPL "
                End If
                If ocmd.ExecuteNonQuery > 0 Then
                    ocmd.CommandText = " select @cnt = count(*) from mm_product_UnifiedPL  " & _
                                                    " where ProductCode = @ProductCode and  UnifiedPL = @UnifiedPL "
                    ocmd.ExecuteScalar()
                    If IIf(IsDBNull(ocmd.Parameters("@cnt").Value), 0, ocmd.Parameters("@cnt").Value) = 0 Then
                        ocmd.CommandText = " insert into mm_product_UnifiedPL " & _
                                " ( UnifiedPL , ProductCode ) " & _
                                " values ( @UnifiedPL , @ProductCode  )"
                    End If
                    If ocmd.ExecuteNonQuery > 0 Then blnDone = True
                End If
            Catch exp As Exception
                sMessage = exp.Message
            Finally
                If IsNothing(ocmd) = False Then
                    If blnDone Then
                        ocmd.Transaction.Commit()
                        sMessage = "Record updated"
                    Else
                        ocmd.Transaction.Rollback()
                        sMessage = "Updation  entry failed "
                    End If
                    If ocmd.Connection.State = ConnectionState.Open Then ocmd.Connection.Close()
                    ocmd.Dispose()
                    ocmd = Nothing
                End If
            End Try
        End Sub
        Public Sub New(ByVal ProdCode As String, ByVal UnifiedPL As String, ByVal ItemDescription As String, ByVal SpecificationNo As String, ByVal DrawingNo As String, ByVal Category As String)
            SaveUnifiedPL(ProdCode, UnifiedPL, ItemDescription, SpecificationNo, DrawingNo, Category)
        End Sub
#End Region
    End Class
End Namespace
