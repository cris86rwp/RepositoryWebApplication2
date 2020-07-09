Namespace RWF
    <Serializable()> Public Class tables
        Public Shared Function CheckWorkingDate(ByVal GroupCode As String, ByVal WorkingDate As Date) As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@GroupCode", SqlDbType.VarChar, 50).Value = GroupCode
            oCmd.Parameters.Add("@WorkingDate", SqlDbType.SmallDateTime, 4).Value = WorkingDate
            oCmd.Parameters.Add("@cnt", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@Shop", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = "select @Shop = location " & _
                   " from ms_group_location where group_code = @GroupCode and purpose = 'WorkingDate' "
                oCmd.ExecuteScalar()
                oCmd.Parameters("@Shop").Direction = ParameterDirection.Input
                oCmd.CommandText = "select @cnt = count(*) from mm_calendar_dump where shop = @Shop and date = @WorkingDate"
                oCmd.ExecuteScalar()
                Return IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)
            Catch exp As Exception
                Return False
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function
        'function to get latest heat from spray
        Public Shared Function GetLatestHeatspray() As Long
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@heatnumber", SqlDbType.BigInt, 4).Direction = ParameterDirection.Output
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = "select top 1 @heatnumber = heatnumber from  mm_spraystation order by  heatnumber desc "
                oCmd.ExecuteScalar()
                GetLatestHeatspray = IIf(IsDBNull(oCmd.Parameters("@heatnumber").Value), 0, oCmd.Parameters("@heatnumber").Value)
            Catch exp As Exception
                GetLatestHeatspray = 0
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function

        Public Shared Function CheckHeatPrePouring(ByVal HeatNumber As Long) As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = "select @cnt = heat_number from  mm_pre_pouring where heat_number = " & CInt(HeatNumber)
                oCmd.ExecuteScalar()
                CheckHeatPrePouring = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)

            Catch exp As Exception
                CheckHeatPrePouring = 0
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function

        Public Shared Function GetLatestHeathotwheelline1() As Long
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@HC_HeatNo", SqlDbType.BigInt, 4).Direction = ParameterDirection.Output
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = "select top 1 @HC_HeatNo = HC_HeatNo from  mm_HotWheelLineHubCutDetails order by  HC_HeatNo desc "
                oCmd.ExecuteScalar()
                GetLatestHeathotwheelline1 = IIf(IsDBNull(oCmd.Parameters("@HC_HeatNo").Value), 0, oCmd.Parameters("@HC_HeatNo").Value)
            Catch exp As Exception
                GetLatestHeathotwheelline1 = 0
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function


        Public Shared Function GetLatestHWNozzalLifeDetails() As Long
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@HC_NzR_Heat_No", SqlDbType.BigInt, 4).Direction = ParameterDirection.Output
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = "select top 1 @HC_NzR_Heat_No = HC_NzR_Heat_No from  mm_HWNozzalLifeDetails order by  HC_NzR_Heat_No desc "
                oCmd.ExecuteScalar()
                GetLatestHWNozzalLifeDetails = IIf(IsDBNull(oCmd.Parameters("@HC_NzR_Heat_No").Value), 0, oCmd.Parameters("@HC_NzR_Heat_No").Value)
            Catch exp As Exception
                GetLatestHWNozzalLifeDetails = 0
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function



        Public Shared Function GetLatestHeathotwheelline() As Long
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@heat_heatno", SqlDbType.BigInt, 4).Direction = ParameterDirection.Output
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = "select top 1 @heat_heatno = heat_heatno from  mm_hotwheelline_spg order by  heat_heatno desc "
                oCmd.ExecuteScalar()
                GetLatestHeathotwheelline = IIf(IsDBNull(oCmd.Parameters("@heat_heatno").Value), 0, oCmd.Parameters("@heat_heatno").Value)
            Catch exp As Exception
                GetLatestHeathotwheelline = 0
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function
        Public Shared Function GetLatestHeathotwheellife() As Long
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@SPG_heat_no", SqlDbType.BigInt, 4).Direction = ParameterDirection.Output
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = "select top 1 @SPG_heat_no = SPG_heat_no from  mm_hotwheellife order by  SPG_heat_no desc "
                oCmd.ExecuteScalar()
                GetLatestHeathotwheellife = IIf(IsDBNull(oCmd.Parameters("@SPG_heat_no").Value), 0, oCmd.Parameters("@SPG_heat_no").Value)
            Catch exp As Exception
                GetLatestHeathotwheellife = 0
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function
        Public Shared Function GetLatestHeathotwheellife1() As Long
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@ST_Pipe_heat_no", SqlDbType.BigInt, 4).Direction = ParameterDirection.Output
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = "select top 1 @ST_Pipe_heat_no = ST_Pipe_heat_no from  mm_hotwheellife order by  ST_Pipe_heat_no desc "
                oCmd.ExecuteScalar()
                GetLatestHeathotwheellife1 = IIf(IsDBNull(oCmd.Parameters("@ST_Pipe_heat_no").Value), 0, oCmd.Parameters("@ST_Pipe_heat_no").Value)
            Catch exp As Exception
                GetLatestHeathotwheellife1 = 0
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function


        Public Shared Function GetLatestHeatbaking() As Long
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@heatnumber", SqlDbType.BigInt, 4).Direction = ParameterDirection.Output
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = "select top 1 @heatnumber = heatnumber from  mm_bakingstation1 order by  heatnumber desc "
                oCmd.ExecuteScalar()
                GetLatestHeatbaking = IIf(IsDBNull(oCmd.Parameters("@heatnumber").Value), 0, oCmd.Parameters("@heatnumber").Value)
            Catch exp As Exception
                GetLatestHeatbaking = 0
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function

        Public Shared Function GetWorkingDate(ByVal GroupCode As String, Optional ByVal HeatNo As Long = 0) As Date
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            If HeatNo > 0 Then
                oCmd.Parameters.Add("@heat_number", SqlDbType.BigInt, 8).Value = HeatNo
            End If
            Dim Shop, ShopName As String
            oCmd.Parameters.Add("@GroupCode", SqlDbType.VarChar, 50).Value = GroupCode
            oCmd.Parameters.Add("@WorkingDate", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@Shop", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@ShopName", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@melt_date", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output
            Dim SetDate As Date
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = "select @Shop = location ,  @ShopName = description " &
                    " from ms_group_location where group_code = @GroupCode and purpose = 'WorkingDate' "
                oCmd.ExecuteScalar()
                oCmd.Parameters("@Shop").Direction = ParameterDirection.Input
                oCmd.Parameters("@ShopName").Direction = ParameterDirection.Input
                Select Case GroupCode
                    Case "WHLMLT"
                        oCmd.CommandText = "select @melt_date = melt_date from mm_heatsheet_header where heat_number = @heat_number"
                        oCmd.ExecuteScalar()
                        SetDate = IIf(IsDBNull(oCmd.Parameters("@melt_date").Value), IIf(Now.Hour < 6, Now.Date.AddDays(-1), Now.Date), oCmd.Parameters("@melt_date").Value)
                    Case "MLDING"
                        SetDate = IIf(Now.Hour < 6, Now.Date.AddDays(-1), Now.Date)
                    Case "MLDPOUR"
                        SetDate = IIf(Now.Hour < 6, Now.Date.AddDays(-1), Now.Date)
                End Select
                oCmd.Parameters.Add("@CalendarDate", SqlDbType.SmallDateTime, 4).Value = SetDate
                oCmd.CommandText = "select @cnt = count(*) from mm_calendar_dump where shop = @Shop and date = @CalendarDate"
                oCmd.ExecuteScalar()
                If IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value) = 0 Then
                    GetWorkingDate = SetDate
                Else
                    Dim i As Integer
                    For i = 1 To 300
                        SetDate = SetDate.AddDays(i)
                        oCmd.Parameters("@CalendarDate").Value = SetDate
                        oCmd.CommandText = "select @cnt = count(*) from mm_calendar_dump where shop = @Shop and date = @CalendarDate"
                        oCmd.ExecuteScalar()
                        If IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value) = 0 Then
                            GetWorkingDate = SetDate
                            Exit For
                        End If
                    Next
                End If
            Catch exp As Exception
                GetWorkingDate = Now.Date
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function

        Public Shared Function GBPlData(ByVal Group_Code As String, ByVal GBDate As Date, ByVal pl_number As String) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = "mm_sp_GroundBalancePLList"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.Add("@Group_Code", SqlDbType.VarChar, 50).Value = Group_Code.Trim
                da.SelectCommand.Parameters.Add("@GBDate", SqlDbType.DateTime, 4).Value = GBDate
                da.SelectCommand.Parameters.Add("@pl_number", SqlDbType.VarChar, 10).Value = pl_number.Trim
                da.Fill(ds)
                Return ds.Tables(0)
            Catch exp As Exception
                Throw New Exception("Data Retrieval Error : " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function GBPls(ByVal Group_Code As String) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            ' Code modified for stock ,Non Stock & Other Railway Item Category
            '--------------------------------------------------------------
            Try
                da.SelectCommand.CommandText = "select a.PlNo  , PLDesc , a.UOM , " &
                    "CASE WHEN (a.ItemType = 1 or a.ItemType =5 ) THEN 'Stock' " &
                    " WHEN a.ItemType =5  THEN 'Non Stock'  " &
                    " WHEN a.ItemType=7 THEN 'Order from RlY/Unit' " &
                    "END AS 'ItemType' " &
                     " from mm_vw_GroundBalancePLs_new a " &
                    " inner join pm_ItemMaster x on x.pl_number =  PlNo " &
                    " left outer join ms_vw_ProdConsumables d on d.PLNO = a.PLNO  " &
                    " where a.Group_Code = @Group_Code order by d.ward , a.PlNo "
                '------------------------------------------------------
                da.SelectCommand.Parameters.Add("@Group_Code", SqlDbType.VarChar, 50).Value = Group_Code.Trim
                da.Fill(ds)
                Return ds.Tables(0)
            Catch exp As Exception
                Throw New Exception("Data Retrieval Error : " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function GBPlsList(ByVal Group_Code As String, ByVal GBDate As Date) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = "mm_sp_GroundBalanceList"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.Add("@Group_Code", SqlDbType.VarChar, 50).Value = Group_Code.Trim
                da.SelectCommand.Parameters.Add("@GBDate", SqlDbType.DateTime, 4).Value = GBDate
                da.Fill(ds)
                Return ds.Tables(0)
            Catch exp As Exception
                Throw New Exception("Data Retrieval Error : " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function WheelHistory(ByVal Wheel As String) As DataSet
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.CommandText = "mm_sp_si_wheelHistory"
                da.SelectCommand.Parameters.Add("@whlstr", SqlDbType.VarChar, 50).Value = Wheel.Trim
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
        Public Shared Function ShopGroundBalance(ByVal wo As String, ByVal SubShop As String, ByVal WODate As Date, ByVal Group As String)
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                cmd.Connection.Open()
                cmd.CommandText = "select number from mm_workorder where number like '" & wo.Trim & "'"
                da.SelectCommand = cmd
                da.Fill(ds, "woList")

                da.SelectCommand.CommandText = "select HD.hvpl PlNo, HD.hvpldesc PLDesc , hd.hvuom UOM, convert(float,0.0) OB, convert(float,0.0) Receipt "
                Dim row As DataRow
                For Each row In ds.Tables("woList").Rows
                    da.SelectCommand.CommandText &= ", convert(float,0) " + "'" + row(0) + "'"
                Next
                da.SelectCommand.CommandText &= ", convert(float,0.0) CB FROM mm_vw_HighValueItems as HD, mm_ShopGround_ShopCode as SC WHERE hvshop LIKE SC.Shop_Code + '%' and SC.Group_Code LIKE '" & Group & "%' and HD.hvpl IN (SELECT pl_number FROM [rwfdb\rwfdbcluster].wap.dbo.pm_itemmaster) ORDER BY hvpl"
                da.Fill(ds, "PlList")
                da.SelectCommand.Parameters.Add("@Pl", SqlDbType.VarChar, 8).Direction = ParameterDirection.Input
                da.SelectCommand.Parameters.Add("@ShopCode", SqlDbType.VarChar, 4).Value = SubShop
                da.SelectCommand.Parameters.Add("@CurYear", SqlDbType.Int, 4).Value = CDate(WODate).Year
                da.SelectCommand.Parameters.Add("@CurMonth", SqlDbType.Int, 4).Value = CDate(WODate).Month

                da.SelectCommand.Parameters.Add("@wo", SqlDbType.VarChar, 4).Direction = ParameterDirection.Input
                da.SelectCommand.Parameters("@wo").Value = ""
                Dim deciClosingBalance As Decimal
                da.SelectCommand.Parameters.Add("@OB", SqlDbType.Float, 8).Direction = ParameterDirection.Output
                For Each row In ds.Tables("PlList").Rows
                    ' update OB 
                    da.SelectCommand.Parameters("@Pl").Value = row("plno")
                    da.SelectCommand.CommandText = "declare @Cb float " & _
                        " declare @OBCBDt smalldatetime " & _
                        " select @OBCBDt = max(record_date) from mm_shop_accountal where shop_code = @ShopCode " & _
                        " and pl_number = @Pl and record_date <= convert(smalldatetime,convert(varchar, @CurYear)+'-'+convert(varchar,@CurMonth)+'-01') " & _
                        " select @OB = closing_balance   from mm_shop_accountal where shop_code like @ShopCode+'%' and " & _
                        " record_date = @obcbdt and pl_number = @Pl "
                    Try
                        If da.SelectCommand.Connection.State = ConnectionState.Closed Then da.SelectCommand.Connection.Open()
                        row.BeginEdit()
                        da.SelectCommand.ExecuteScalar()
                        If IsDBNull(da.SelectCommand.Parameters("@OB").Value) Then
                            row("OB") = 0.0
                        Else
                            row("OB") = da.SelectCommand.Parameters("@OB").Value
                        End If
                        If IsDBNull(row("OB")) Then
                            row("OB") = 0.0
                        End If

                        da.SelectCommand.CommandText = "select isnull(sum(isnull(quantity_received,0.0)),0.0) QtyRecd from mm_shop_pl_receipt where shop_code like @ShopCode+'%' and " & _
                            " pl_number = @Pl  and year(receipt_date) = @CurYear and  month(receipt_date) = @CurMonth "
                        Dim receipt As Decimal
                        receipt = da.SelectCommand.ExecuteScalar
                        row("Receipt") = IIf(IsDBNull(receipt), 0.0, receipt)
                        If IsDBNull(row("Receipt")) = False Then
                            deciClosingBalance = CDec(row("OB")) + CDec(row("Receipt"))
                        Else
                            deciClosingBalance = CDec(row("OB")) + 0
                        End If

                        Dim rw As DataRow
                        Dim ij As Integer = -1
                        ij += 1
                        Dim woqty As Decimal
                        Dim woqnty As Decimal
                        For Each rw In ds.Tables("woList").Rows
                            da.SelectCommand.Parameters("@Wo").Value = rw("number")
                            da.SelectCommand.CommandText = "select isnull(Sum(isnull(quantity,0.0)),0.0)  " & _
                                                  " from mm_daily_pl_consumption where shop_code like @ShopCode+'%' and " & _
                                                  " pl_number = @Pl  and year(Consumed_date) = @CurYear and " & _
                                                  " month(Consumed_date) = @CurMonth and workorder_number = @wo "
                            woqty = da.SelectCommand.ExecuteScalar
                            If IsDBNull(woqty) Then woqnty = 0.0 Else woqnty = woqty
                            row(ij + 5) = woqnty
                            deciClosingBalance -= woqnty
                            ij += 1
                        Next
                        row("CB") = deciClosingBalance
                        row.EndEdit()
                        woqnty = Nothing
                        woqty = Nothing
                        ij = Nothing
                        rw = Nothing
                        receipt = Nothing
                    Catch exp As Exception
                        Throw New Exception(exp.Message)
                    Finally
                        If da.SelectCommand.Connection.State = ConnectionState.Open Then da.SelectCommand.Connection.Close()
                    End Try
                Next
                row = Nothing
                deciClosingBalance = Nothing
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
            Return ds.Tables("PlList")
            da = Nothing
            ds = Nothing
            cmd = Nothing
        End Function
        Public Shared Function ShopCodes(ByVal sUser As String) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = "select Group_Code , Shop_Code , Shop , Consignee  , CostCentre " & _
                    " from  mm_vw_GroundBalanceShops where group_code = '" & sUser & "'"
                da.Fill(ds)
                Return ds.Tables(0)
            Catch exp As Exception
                Throw New Exception("Data Retrieval Error : " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function BreakDownMemo(ByVal GROUP As String, ByVal Machine As String, ByVal FromDate As Date, ByVal ToDate As Date) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@fr", SqlDbType.SmallDateTime, 4).Value = FromDate
                da.SelectCommand.Parameters.Add("@to", SqlDbType.SmallDateTime, 4).Value = ToDate
                da.SelectCommand.Parameters.Add("@machine", SqlDbType.VarChar, 50).Value = Machine
                da.SelectCommand.Parameters.Add("@GROUP", SqlDbType.VarChar, 50).Value = GROUP
                da.SelectCommand.CommandText = "mm_sp_BreakDownMemo"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.Fill(ds)
                BreakDownMemo = ds.Tables(0)
            Catch exp As Exception
                BreakDownMemo = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function GroupWiseBreakDownDetails(ByVal GROUP As String, ByVal Location As String, ByVal FromDate As Date, ByVal ToDate As Date) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@GroupCode", SqlDbType.VarChar, 10).Value = GROUP
                da.SelectCommand.Parameters.Add("@Location", SqlDbType.VarChar, 10).Value = Location
                da.SelectCommand.Parameters.Add("@FrDt", SqlDbType.SmallDateTime, 4).Value = FromDate
                da.SelectCommand.Parameters.Add("@ToDt", SqlDbType.SmallDateTime, 4).Value = ToDate
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.CommandText = "mm_sp_GroupWiseBreakDownDetails"
                da.Fill(ds)
                GroupWiseBreakDownDetails = ds.Tables(0)
            Catch exp As Exception
                GroupWiseBreakDownDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function GetMachines(ByVal GROUP As String) As DataSet
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "select distinct a.machine_code , description from ms_breakdown_memo A INNER JOIN ms_machinery_master b" & _
                    " on a.machine_code = b.machine_code where maintenance_group = @GROUP order by a.machine_code ; " & _
                    " select location from ms_vw_GroupCodeLocation where group_code = @GROUP "
                da.SelectCommand.Parameters.Add("@GROUP", SqlDbType.VarChar, 10).Value = GROUP
                da.Fill(ds)
                GetMachines = ds.Copy
            Catch exp As Exception
                GetMachines = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function GetTotalPourTime(ByVal HeatNumber As Long, ByVal EndTime As DateTime) As Double
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@EndTime", SqlDbType.DateTime, 8).Value = EndTime
            oCmd.Parameters.Add("@HeatNumber", SqlDbType.BigInt, 8).Value = HeatNumber
            oCmd.Parameters.Add("@PourTime", SqlDbType.Float, 8).Direction = ParameterDirection.Output
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = "select @PourTime = wap.dbo.mm_fn_GetTotalPourTime(@HeatNumber,@EndTime)"
                oCmd.ExecuteScalar()
                GetTotalPourTime = IIf(IsDBNull(oCmd.Parameters("@PourTime").Value), 0, oCmd.Parameters("@PourTime").Value)
            Catch exp As Exception
                GetTotalPourTime = 0.0
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function
        Public Shared Function GetPostPourHeatDetails(ByVal HeatNumber As Long) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "SELECT dome_disc_used , end_time , end_temperature , drain_mm ,operator_mould,sic, " &
                    " d13_temperature , d14_temperature , c20_temperature , c21_temperature , " &
                    " cope_spray_r , cope_spray_p , cope_spray_h , cope_spray_b , " &
                    " drag_spray_r , drag_spray_h , drag_spray_p , drag_spray_b , drag_spray_starttime ,  " &
                    " drag_spray_endtime , tube_condition , remarks , cope_drag_spray_sttime , cope_drag_spray_endtime , " &
                    " spru_wash_sttime , spru_wash_endtime , hub_cut_sttime , hub_cut_endtime , " &
                    " core_bak_sttime , core_bak_endtime , sprue_ampere , spure_pressure , convert(decimal(10,2),total_pour_time)  total_pour_time, " &
                    " tube1conditionrmk,tube2conditionrmk,tube3conditionrmk,lesswheelrsn,excessprdelayrsn,excessprtimersn,riserwt,lwtatpouring " &
                    " FROM mm_post_pouring where heat_number = " & CInt(HeatNumber)
                da.Fill(ds)
                GetPostPourHeatDetails = ds.Tables(0)
            Catch exp As Exception
                GetPostPourHeatDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function


        Public Shared Function getWheelsCopesDragsUsed(ByVal HeatNumber As Long) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = " select WhlsCast = ( select count(*) from mm_pouring " & _
                    " where  heat_number = " & CInt(HeatNumber) & " and ( rejection_code not in ( '6','7','6&7' ) and rejection_code not like 'x%' ) ) " & _
                    " , CopesUsed = ( select count(*) from mm_pouring " & _
                    " where  heat_number = " & CInt(HeatNumber) & " and cope_number not in ( '0' ) and rejection_code not in ( '7') ) " & _
                    " , DragsUsed = ( select count(*) from mm_pouring where  heat_number = " & CInt(HeatNumber) & " ) " & _
                    " , CastWheels = wap.dbo.mm_fn_CastWheelsString(" & CInt(HeatNumber) & " ) "
                da.Fill(ds)
                getWheelsCopesDragsUsed = ds.Tables(0)
            Catch exp As Exception
                getWheelsCopesDragsUsed = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function GetPrePourHeatDetails(ByVal HeatNumber As Long) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "select getdate(),operator_mould,shift_supervisor,jmp_cover1,ladle_lift_time,tube1_immersion1_time," &
                    " tube1_immersion1_temperature,tube1_immersion2_time,tube1_immersion2_temperature,tube1_immersion3_time," &
                    " tube1_immersion3_temperature,aluminium_stars,aluminium_dip_temperature,slag_condition,chemical_composition," &
                    " stop_support,riser_weight,tube1_mfg,tube2_mfg,tube3_mfg,tube1_life,tube2_life,tube3_life,pouring_tank_number," &
                    " ladle_metal_level,ladle_insl,tube1_in_time,tube2_in_time,tube3_in_time,tube1_out_time,tube2_out_time,tube3_out_time," &
                    " ladle_in_time, ladle_temp, tube_no_1, tube_no_2, tube_no_3, metal_recieved , isnull(ShiftGroup,'') ShiftGroup" &
                    " from mm_pre_pouring a left outer join mm_pouring_group b on a.heat_number = b.heat_number " &
                    " where a.heat_number = " & CInt(HeatNumber)
                da.Fill(ds)
                GetPrePourHeatDetails = ds.Tables(0)
            Catch exp As Exception
                GetPrePourHeatDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function

        Public Shared Function GetPourSessionDetails(ByVal HeatNumber As Long) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "select top 1 LIM,SHIFTID, OPERATOR ,SIC ,TBINT,TBOUTT from mm_pouring where heat_number = " & CInt(HeatNumber)
                da.Fill(ds)
                GetPourSessionDetails = ds.Tables(0)
            Catch exp As Exception
                GetPourSessionDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function

        Public Shared Function GetCopetempDetails(ByVal HeatNumber As Long, ByVal CopeNumber As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()

            Try

                da.SelectCommand.CommandText = "Select top 1 cope_temp from mm_spraystation_cope where heat_number < '" & CInt(HeatNumber) & "' and cope_number ='" & CopeNumber & "'"

                da.Fill(ds)
                Return ds.Tables(0)
            Catch exp As Exception
                ' GetCopetempDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function

        Public Shared Function GetDragtempDetails(ByVal HeatNumber As Long, ByVal DragNumber As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "Select top 1 drag_temp from mm_spraystation_drag where heat_number < '" & CInt(HeatNumber) & "' And drag_number='" & DragNumber & "'"

                da.Fill(ds)
                Return ds.Tables(0)
            Catch exp As Exception
                GetDragtempDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function

        Public Shared Function GetBakCopeTempDetails(ByVal HeatNumber As Long, ByVal CopeNumber As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "Select top 1 cope_tmp from mm_bakingstation where  heatnumber < '" & CInt(HeatNumber) & "' and cope_no ='" & CopeNumber & "'"

                da.Fill(ds)
                Return ds.Tables(0)
            Catch exp As Exception
                GetBakCopeTempDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function

        Public Shared Function getpourstartend(ByVal HeatNumber As Long) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "select  heat_number,start_pour,end_pour,pour_time from mm_vw_pouring where heat_number= " & CInt(HeatNumber)
                da.Fill(ds)
                getpourstartend = ds.Tables(0)
            Catch exp As Exception
                getpourstartend = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function


        Public Shared Function CheckOffHeat(ByVal heat_number As Integer) As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@heat_number", SqlDbType.Int, 4).Value = heat_number
            oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = "select @cnt = count(heat_number) from  mm_offheat_heatsheet_header where  heat_number = @heat_number"
                oCmd.ExecuteScalar()
                CheckOffHeat = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)
            Catch exp As Exception
                CheckOffHeat = 0
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function
        Public Shared Function GetLatestPrePourHeat(Optional ByVal Type As Int16 = 0) As Long
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@heat_number", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                If Type = 0 Then
                    oCmd.CommandText = "select top 1 @heat_number = heat_number+1 from  mm_pre_pouring order by  heat_number desc "
                Else
                    oCmd.CommandText = "select top 1 @heat_number = heat_number from  mm_offheat_heatsheet_header order by  heat_number desc "
                End If
                oCmd.ExecuteScalar()
                GetLatestPrePourHeat = IIf(IsDBNull(oCmd.Parameters("@heat_number").Value), 0, oCmd.Parameters("@heat_number").Value)
            Catch exp As Exception
                GetLatestPrePourHeat = 0
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function
        Public Shared Function GetLatestPourHeat() As Long
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@heat_number", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = "select top 1 @heat_number = heat_number from  mm_pouring order by  heat_number desc "
                'oCmd.CommandText = "select @heat_number =127056"
                oCmd.ExecuteScalar()
                GetLatestPourHeat = IIf(IsDBNull(oCmd.Parameters("@heat_number").Value), 0, oCmd.Parameters("@heat_number").Value)
            Catch exp As Exception
                GetLatestPourHeat = 0
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function
        Public Shared Function CheckPourTime(ByVal HeatNumber As Long, ByVal PourOrder As Integer, ByVal PourTime As Date) As Integer
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@HeatNumber", SqlDbType.BigInt, 8).Value = HeatNumber
            oCmd.Parameters.Add("@PourOrder", SqlDbType.Int, 4).Value = PourOrder
            oCmd.Parameters.Add("@PourTime", SqlDbType.SmallDateTime, 4).Value = PourTime
            oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            oCmd.CommandText = "if @PourTime BETWEEN isnull((SELECT Top 1 pour_time FROM mm_pouring " &
                    " WHERE heat_number = @HeatNumber and pouring_order < @PourOrder ORDER BY pouring_order DESC),'1/1/1900')  " &
                    " AND isnull((SELECT Top 1 DateAdd(d,1,pour_time) FROM mm_pouring  " &
                    " WHERE heat_number = @HeatNumber  and pouring_order > @PourOrder  ORDER BY pouring_order),GetDate()) " &
                    " SELECT @cnt = 1 ELSE SELECT @cnt = 0 "
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.ExecuteScalar()
                CheckPourTime = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)
            Catch exp As Exception
                CheckPourTime = 0
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function

        Public Shared Function CheckHeat_pre(ByVal HeatNumber As Long) As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = "select @cnt = heat_number from  mm_pre_pouring where heat_number = " & CInt(HeatNumber)
                oCmd.ExecuteScalar()
                CheckHeat_pre = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)
            Catch exp As Exception
                CheckHeat_pre = 0
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function

        Public Shared Function GetPreHeatDetails(ByVal HeatNumber As Long) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "select getdate(),cast_date,operator_mould,shift_supervisor,jmp_cover1,ladle_lift_time,tube1_immersion1_time," &
                    " tube1_immersion1_temperature,tube1_immersion2_time,tube1_immersion2_temperature,tube1_immersion3_time," &
                    " tube1_immersion3_temperature,aluminium_stars,aluminium_dip_temperature,slag_condition,chemical_composition," &
                    " stop_support,riser_weight,tube1_mfg,tube2_mfg,tube3_mfg,tube1_life,tube2_life,tube3_life,pouring_tank_number," &
                    " ladle_metal_level,ladle_insl,tube1_in_time,tube2_in_time,tube3_in_time,tube1_out_time,tube2_out_time,tube3_out_time," &
                    " ladle_in_time, ladle_temp, tube_no_1, tube_no_2, tube_no_3,Plunser_pressure,pouring_start_time, metal_recieved  " &
                    " from mm_pre_pouring a " &
                    " where a.heat_number = " & CInt(HeatNumber)
                da.Fill(ds)
                GetPreHeatDetails = ds.Tables(0)
            Catch exp As Exception
                GetPreHeatDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function GetLatestHeat() As Long
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@heat_number", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = "select top 1 @heat_number = heat_number from  mm_pre_pouring order by  heat_number desc "
                oCmd.ExecuteScalar()
                GetLatestHeat = IIf(IsDBNull(oCmd.Parameters("@heat_number").Value), 0, oCmd.Parameters("@heat_number").Value)
            Catch exp As Exception
                GetLatestHeat = 0
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function
        Public Shared Function CheckHeat(ByVal HeatNumber As Long) As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = "select @cnt = heat_number from  mm_heatsheet_header where heat_number = " & CInt(HeatNumber)
                oCmd.ExecuteScalar()
                CheckHeat = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)
            Catch exp As Exception
                CheckHeat = 0
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function
        Public Shared Function CheckHeatpost(ByVal HeatNumber As Long) As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = "select @cnt = heat_number from  mm_post_pouring where heat_number = " & CInt(HeatNumber)
                oCmd.ExecuteScalar()
                CheckHeatpost = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)
            Catch exp As Exception
                CheckHeatpost = 0
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function
        Public Shared Function GetPouringDate(ByVal HeatNumber As Long) As DateTime
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@pour_time", SqlDbType.DateTime, 8).Direction = ParameterDirection.Output
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = "select top 1 @pour_time = pour_time from mm_pouring where heat_number = " & CInt(HeatNumber) & " order by pouring_order desc "
                oCmd.ExecuteScalar()
                GetPouringDate = IIf(IsDBNull(oCmd.Parameters("@pour_time").Value), "1900-01-01", oCmd.Parameters("@pour_time").Value)
            Catch exp As Exception
                GetPouringDate = "1900-01-01"
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function
        Public Shared Function GetMeltingWO(ByVal HeatNumber As Long) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "select ltrim(rtrim(workorder_number)) WO , ltrim(rtrim(b.description)) WODesc " & _
                    " from  mm_heatsheet_header a inner join mm_workorder b " & _
                    " on workorder_number = number where heat_number = " & CInt(HeatNumber)
                da.Fill(ds)
                GetMeltingWO = ds.Tables(0)
            Catch exp As Exception
                GetMeltingWO = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function GetDragDetails(ByVal Drag As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = " select engraved_number , case when cpdglf >= 0 then cpdglf else 0 end  cpdglf,  " & _
                    " case when inglif >= 0 then inglif else 0 end  inglif  " & _
                    " from mm_mmmdmt_dump a inner join mm_mould_master b " & _
                    " on mould_number = mld_no and mld_typ = type " & _
                    " where mld_no = '" & Drag & "' and mld_typ = 'D' and mld_sts <> 'C' "
                da.Fill(ds)
                GetDragDetails = ds.Tables(0)
            Catch exp As Exception
                GetDragDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function ValidateDrag(ByVal Drag As String, ByVal Heat As Long, Optional ByVal ExistingDrag As String = "") As String
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@cnt1", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@cnt2", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@Status", SqlDbType.VarChar, 10).Direction = ParameterDirection.Output
            ValidateDrag = ""
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = " select @cnt = count(*) from mm_mmmdmt_dump where mld_no = '" & Drag & "' and mld_typ = 'D' ;" & _
                           " select @cnt1 = count(*) from mm_pouring where heat_number = " & Heat & " and drag_number = '" & Drag & "' ;" & _
                           " Select @Status = mld_sts from mm_mmmdmt_dump where mld_no = '" & Drag & "' and mld_typ = 'D' ; "

                oCmd.ExecuteScalar()
                Dim intValmld As Integer = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)
                If intValmld = 0 Then
                    ValidateDrag = "Drag With No. " & Drag.Trim & " Is  Not Existing."
                End If
                Dim intCnt As Integer = IIf(IsDBNull(oCmd.Parameters("@cnt1").Value), 0, oCmd.Parameters("@cnt1").Value)
                If intCnt <> 0 Then
                    ValidateDrag = "Drag No. " & Drag & " Is already Used In This Heat."
                End If
                Dim Status As String = IIf(IsDBNull(oCmd.Parameters("@Status").Value), "", oCmd.Parameters("@Status").Value)
                If Status.Trim.ToUpper = "C" Then
                    ValidateDrag = "Drag No with No. " & Drag & " Is already Condemned ."
                End If
                intCnt = Nothing
                Status = Nothing
            Catch exp As Exception
                ValidateDrag = ""
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function
        Public Shared Function GetCopeLife(ByVal Cope As String) As Integer
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = "select @cnt = case when cpdglf >= 0 then cpdglf else 0 end  + 1  from mm_mmmdmt_dump where mld_no = '" & Cope & "' and mld_typ = 'C' and mld_sts <> 'C'"
                oCmd.ExecuteScalar()
                GetCopeLife = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)
            Catch exp As Exception
                GetCopeLife = 0
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function
        Public Shared Function ValidateCope(ByVal Cope As String, ByVal Heat As Long) As String
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@cnt1", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@Status", SqlDbType.VarChar, 10).Direction = ParameterDirection.Output
            ValidateCope = ""
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = "select @cnt = count(*) from mm_mmmdmt_dump where mld_no = '" & Cope & "' and mld_typ = 'C' ; " & _
                                " select @cnt1 =  count(*) from mm_pouring where heat_number = " & Heat & " and cope_number='" & Cope & "' ; " & _
                                " Select @Status = mld_sts from mm_mmmdmt_dump where mld_no = '" & Cope & "' and mld_typ = 'C' "
                oCmd.ExecuteScalar()
                Dim intValmld As Integer = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)
                If intValmld = 0 Then
                    ValidateCope = "Cope with No. " & Cope & " Is Not Existing."
                End If
                Dim intCnt As Integer = IIf(IsDBNull(oCmd.Parameters("@cnt1").Value), 0, oCmd.Parameters("@cnt1").Value)
                If intCnt > 0 Then
                    ValidateCope = "Cope No. " & Cope & " Is already Used In This Heat."
                End If
                Dim Status As String = IIf(IsDBNull(oCmd.Parameters("@Status").Value), "", oCmd.Parameters("@Status").Value)
                If Status.Trim.ToUpper = "C" Then
                    ValidateCope = "Cope with No. " & Cope & " Is already Condemned ."
                End If
                intCnt = Nothing
                Status = Nothing
                intValmld = Nothing
            Catch exp As Exception
                ValidateCope = ""
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function
        Public Shared Function GetCumulativeCnt(ByVal HeatNumber As Long) As Integer
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            oCmd.CommandText = "SELECT @cnt = isnull(max(pouring_order),0) + 1 FROM mm_pouring WHERE heat_number = " & HeatNumber
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.ExecuteScalar()
                GetCumulativeCnt = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)
            Catch exp As Exception
                GetCumulativeCnt = 0
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function
        Public Shared Function PopulateGrid(ByVal HeatNumber As Integer) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = " Select pouring_order, Convert(Varchar(5),pour_time,108) as PourTime  , ltrim(rtrim(a.cope_number)) cope_number ," &
                    " cope_used, ltrim(rtrim(a.drag_number)) drag_number , engraved_number , drag_used ,ingate_used , right(convert(Varchar(8),split_time,108),5) SplitTime," &
                    " whether_f_c, ControledRate CRate , FastRate FRate , rtrim(rejection_code) rejection_code , " &
                    " rtrim(remarks) remarks ,left(rtrim(wheel_type),4) WhlType , slno , " &
                    " case when ltrim(rtrim(location)) = 'mopo' then '' else 'NotInMR' end Sts  " &
                    " From mm_pouring a left outer join mm_pouring_rate b " &
                    " on a.heat_number = b.heat_number and engraved_number = wheel_number " &
                    " inner join mm_wheel c on a.heat_number = c.heat_number and c.wheel_number = engraved_number " &
                    " where a.heat_number = " & CInt(HeatNumber) & " " &
                    " order by pouring_order desc "
                da.Fill(ds)
                PopulateGrid = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function PopulateGridnew(ByVal HeatNumber As Integer) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()


            Try
                da.SelectCommand.CommandText = " Select pouring_order, Convert(Varchar(5),pour_time,108) as PourTime  , ltrim(rtrim(a.cope_number)) cope_number ," &
                    "cope_used, CHOTMP  , BCTMP , SCTMP ,CHONO," &
                    "  ltrim(rtrim(a.drag_number)) drag_number , engraved_number , drag_used ,DHOTMP , SDTMP ,  DHONO ,ingate_used , " &
                    "right(convert(Varchar(8),split_time,108),5) SplitTime," &
                    " whether_f_c, ControledRate CRate , FastRate FRate , rtrim(rejection_code) rejection_code , " &
                    " rtrim(remarks) remarks ,left(rtrim(wheel_type),4) WhlType , slno , " &
                    " case when ltrim(rtrim(location)) = 'mopo' then '' else 'NotInMR' end Sts  " &
                    " From mm_pouring a left outer join mm_pouring_rate b " &
                    " on a.heat_number = b.heat_number and engraved_number = wheel_number " &
                    " inner join mm_wheel c on a.heat_number = c.heat_number and c.wheel_number = engraved_number " &
                    " where a.heat_number = " & CInt(HeatNumber) & " " &
                    " order by pouring_order desc "
                da.Fill(ds)
                PopulateGridnew = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function getGridDetails(ByVal HeatNumber As Integer) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "Select pouring_order PO , Convert(Varchar(5),pour_time,108) as PTime , " & _
                    " ltrim(rtrim(a.cope_number)) Cope , cope_used CL , ltrim(rtrim(a.drag_number)) Drag , engraved_number WhlNo ,  " & _
                    " drag_used DL , ingate_used IngL , substring(convert(Varchar(9),split_time,108),4,5) as Split , whether_f_c FC , " & _
                    " ControledRate CRate , FastRate FRate , case when isnull(ltrim(rtrim(rejection_code)),'') = '' then ltrim(rtrim(status)) else ltrim(rtrim(rejection_code)) end Rej ,  " & _
                    " ltrim(rtrim(remarks)) [Remarks_________________________] , " & _
                    " left(ltrim(rtrim(wheel_type)),4) Whl , slno , " & _
                    " case when ltrim(rtrim(location)) = 'mopo' then '' else 'NotInMR' end Sts  " & _
                    " From mm_pouring a left outer join mm_pouring_rate c " & _
                    " on a.heat_number = c.heat_number and engraved_number = c.wheel_number " & _
                    " inner join mm_wheel b on a.heat_number = b.heat_number and b.wheel_number = engraved_number " & _
                    " where a.heat_number = " & CInt(HeatNumber) & " order by pouring_order desc "
                da.Fill(ds)
                getGridDetails = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function GetWOProdId(ByVal strwo As String) As String
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@product_code", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            oCmd.CommandText = "select @product_code = isnull(product_code,'') from mm_workorder where number = '" & strwo & "'"
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.ExecuteScalar()
                GetWOProdId = IIf(IsDBNull(oCmd.Parameters("@product_code").Value), "", oCmd.Parameters("@product_code").Value)
            Catch exp As Exception
                GetWOProdId = ""
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function
        Public Shared Function GetWoDesc(ByVal strwo As String) As String
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@description", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            oCmd.CommandText = "select @description = description from mm_workorder where number='" & Trim(strwo) & "'"
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.ExecuteScalar()
                GetWoDesc = IIf(IsDBNull(oCmd.Parameters("@description").Value), "", oCmd.Parameters("@description").Value)
            Catch exp As Exception
                GetWoDesc = ""
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function

        Public Shared Function ValidateCope_baking(ByVal Cope As String, ByVal Heat As Long) As String
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@cnt1", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@Status", SqlDbType.VarChar, 10).Direction = ParameterDirection.Output
            ValidateCope_baking = ""
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = "select @cnt = count(*) from mm_mmmdmt_dump where mld_no = '" & Cope & "' and mld_typ = 'C' ; " &
                                " select @cnt1 =  count(*) from mm_pouring where heat_number = " & Heat & " and cope_number='" & Cope & "' ; " &
                                " Select @Status = mld_sts from mm_mmmdmt_dump where mld_no = '" & Cope & "' and mld_typ = 'C' "
                oCmd.ExecuteScalar()
                Dim intValmld As Integer = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)
                If intValmld = 0 Then
                    ValidateCope_baking = "Cope with No. " & Cope & " Is Not Existing."
                End If
                'Dim intCnt As Integer = IIf(IsDBNull(oCmd.Parameters("@cnt1").Value), 0, oCmd.Parameters("@cnt1").Value)
                'If intCnt > 0 Then
                '    ValidateCope_baking = "Cope No. " & Cope & " Is already Used In This Heat."
                'End If
                Dim Status As String = IIf(IsDBNull(oCmd.Parameters("@Status").Value), "", oCmd.Parameters("@Status").Value)
                If Status.Trim.ToUpper = "C" Then
                    ValidateCope_baking = "Cope with No. " & Cope & " Is already Condemned ."
                End If
                'intCnt = Nothing
                Status = Nothing
                intValmld = Nothing
            Catch exp As Exception
                ValidateCope_baking = ""
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function

        Public Shared Function getHeatWo(ByVal heat As Long) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@heat", SqlDbType.BigInt, 8).Value = heat
            da.SelectCommand.CommandText = "select RTRIM(number+'-'+description) as wonumber , number " & _
                " from mm_workorder where number in ( select distinct workorder_number from mm_pouring " & _
                " where heat_number = @heat ) "
            Try
                da.Fill(ds)
                getHeatWo = ds.Tables(0)
            Catch exp As Exception
                getHeatWo = Nothing
                Throw New Exception(" Retrival of MouldRoom WO Details List error : " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function getWO(ByVal Heat As Long) As DataTable
            Dim dt As Date
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@date_mould", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output
            oCmd.CommandText = "Select top 1 @date_mould = date_mould from mm_wheel where heat_number = " & Heat & " order by pour_order desc "
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.ExecuteScalar()
                If IsDBNull(oCmd.Parameters("@date_mould").Value) Then
                    oCmd.CommandText = "Select @date_mould = max(pour_time) from mm_pouring "
                    oCmd.ExecuteScalar()
                End If
                dt = IIf(IsDBNull(oCmd.Parameters("@date_mould").Value), CDate("1900-01-01"), oCmd.Parameters("@date_mould").Value)
                dt = CDate(dt)
            Catch exp As Exception
                dt = dt.Now
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
            If dt = Nothing Then
                dt = dt.Now
            End If

            ' following 5 lines added on 02July2012
            ' to allow workorder of previous month to appear 
            ' till 6 am ( 'C' shift ) of 1st of the month
            If Now.Day = 1 Then
                If Now.Hour < 6 Then
                    dt = dt.AddDays(-1)
                End If
            End If
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Dim str, str_nxt As String
            str = Right(dt.Year, 1) & Chr(dt.Month + 64) & "%"
            str_nxt = Right(DateAdd(DateInterval.Month, 1, dt).Year, 1) & Chr(DateAdd(DateInterval.Month, 1, dt).Month + 64) & "%"
            da.SelectCommand.CommandText = "select RTRIM(number+'-'+description) as wonumber , number from mm_workorder where shop_code like 'E%' and status like 'O%' and (number like '" & str & "' or number like '" & str_nxt & "') and product_code <> '110344' "
            Try
                da.Fill(ds)
                getWO = ds.Tables(0)
            Catch exp As Exception
                getWO = Nothing
                Throw New Exception(" Retrival of MouldRoom WO Details List error : " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
            str = Nothing
            str_nxt = Nothing
        End Function
        Public Shared Function WheelInspectionDetails(ByVal FromDate As String, ByVal ToDate As String, ByVal Type As Integer) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "mm_sp_WheelInspectionDetails"
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.Add("@FrDate", SqlDbType.SmallDateTime, 4).Value = FromDate
            da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.SmallDateTime, 4).Value = ToDate
            da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = Type
            Try
                da.Fill(ds)
                Return ds.Tables(0).Copy
            Catch exp As Exception
                Throw New Exception("Data Retrieval Error : " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function SetWOforGivenWheel(ByVal WheelNumber As Long, ByVal HeatNumber As Long) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = "mm_sp_SetWOforGivenWheel"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.Add("@Ht", SqlDbType.BigInt, 8).Value = HeatNumber
                da.SelectCommand.Parameters.Add("@Whl", SqlDbType.BigInt, 8).Value = WheelNumber
                da.Fill(ds)
                Return ds.Tables(0).Copy
            Catch exp As Exception
                Throw New Exception("Data Retrieval Error : " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function IsTypePresent(ByVal PinkDt As Date, ByVal Type As String) As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.CommandText = "select @Cnt = count(*) FROM mm_pink_sheet_heatno " & _
                " WHERE test_date = @PinkDt and Type = @Type "
            cmd.Parameters.Add("@PinkDt", SqlDbType.SmallDateTime, 4).Value = PinkDt
            cmd.Parameters.Add("@Type", SqlDbType.VarChar, 10).Value = Type
            cmd.Parameters.Add("@Cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            Try
                cmd.Connection.Open()
                cmd.ExecuteScalar()
                If IIf(IsDBNull(cmd.Parameters("@Cnt").Value), 0, cmd.Parameters("@Cnt").Value) > 0 Then Return True
            Catch exp As Exception
                Return True
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function GetPinkSheetProducts(ByVal PinkDt As Date) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.Parameters.Add("@PinkDt", SqlDbType.SmallDateTime, 4).Value = PinkDt
                da.SelectCommand.CommandText = " select distinct rtrim(type) type  from mm_PinkSheet_TOP10 " & _
                    " where pinkdate = @PinkDt  order by type desc "
                da.Fill(ds)
                Return ds.Tables(0).Copy
            Catch exp As Exception
                Throw New Exception("Data Retrieval Error : " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function GetPinkSheetDates() As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = " select distinct convert(varchar(11),pinkdate,103) pinkdate , pinkdate " & _
                    " from mm_PinkSheet_TOP10 order by pinkdate desc "
                da.Fill(ds)
                Return ds.Tables(0).Copy
            Catch exp As Exception
                Throw New Exception("Data Retrieval Error : " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function IsTypeMisMatch(ByVal WheelNumber As Long, ByVal HeatNumber As Long) As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.CommandText = "select @Cnt = count(*)  from  mm_magnaglow_results a inner join mm_pouring  b " & _
            " on engraved_number  = wheel_number and a.heat_number = b.heat_number " & _
            " where a.wheel_number = @Whl and a.heat_number = @Ht " & _
            " and ltrim(rtrim(wheel_transfer_status)) <> ltrim(rtrim(wheel_type)) "
            cmd.Parameters.Add("@Whl", SqlDbType.BigInt, 8).Value = WheelNumber
            cmd.Parameters.Add("@Ht", SqlDbType.BigInt, 8).Value = HeatNumber
            cmd.Parameters.Add("@Cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            Try
                cmd.Connection.Open()
                cmd.ExecuteScalar()
                If IIf(IsDBNull(cmd.Parameters("@Cnt").Value), 0, cmd.Parameters("@Cnt").Value) > 0 Then Return True
            Catch exp As Exception
                Return True
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function IsTypeMisMatchAtMag(ByVal WheelNumber As Long, ByVal HeatNumber As Long, ByVal SelectedWhlType As String) As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.CommandText = "select @Cnt = count(*)  from  mm_magnaglow_results a inner join mm_pouring  b " & _
                                    " on engraved_number  = wheel_number and a.heat_number = b.heat_number " & _
                                    " where a.wheel_number = @Whl and a.heat_number = @Ht " & _
                                    " and ltrim(rtrim(wheel_transfer_status)) <> ltrim(rtrim(wheel_type)) "
                cmd.Parameters.Add("@Whl", SqlDbType.BigInt, 8).Value = WheelNumber
                cmd.Parameters.Add("@Ht", SqlDbType.BigInt, 8).Value = HeatNumber
                cmd.Parameters.Add("@SelectedWhlType", SqlDbType.VarChar, 50).Value = SelectedWhlType.Trim
                cmd.Parameters.Add("@Cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output

                cmd.Connection.Open()
                cmd.ExecuteScalar()
                If IIf(IsDBNull(cmd.Parameters("@Cnt").Value), 0, cmd.Parameters("@Cnt").Value) > 0 Then
                    Return True
                Else
                    cmd.CommandText = "select @Cnt = count(*)  from  mm_pouring " & _
                            " where engraved_number = @Whl and heat_number = @Ht " & _
                            " and ltrim(rtrim(wheel_type)) <> @SelectedWhlType "
                    cmd.ExecuteScalar()
                    If IIf(IsDBNull(cmd.Parameters("@Cnt").Value), 0, cmd.Parameters("@Cnt").Value) > 0 Then
                        Return True
                    End If
                End If
            Catch exp As Exception
                Return True
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
    End Class
    Public Class GroundBalance
        Public Function Update(ByVal employee_code As String, ByVal Consignee As String, ByVal TrnDate As Date, ByVal TrnType As String, ByVal PlNo As String, ByVal WO As String, ByVal TrnQty As Double) As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim Done As Boolean
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Parameters.Add("@Consignee", SqlDbType.VarChar, 50).Value = Consignee
                oCmd.Parameters.Add("@pl_number", SqlDbType.VarChar, 9).Value = PlNo
                oCmd.Parameters.Add("@GBDate", SqlDbType.SmallDateTime, 4).Value = TrnDate

                oCmd.CommandText = "mm_sp_GroundBalanceOBUpdate"
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.ExecuteNonQuery()

                If TrnType.StartsWith("R") Then
                    oCmd.Parameters.Add("@Qty", SqlDbType.Float, 9).Value = TrnQty
                    oCmd.Parameters.Add("@employee_code", SqlDbType.VarChar, 6).Value = employee_code
                    oCmd.CommandText = "mm_sp_GroundBalanceReceiptUpdate"
                    oCmd.CommandType = CommandType.StoredProcedure
                    oCmd.ExecuteNonQuery()
                Else
                    oCmd.Parameters.Add("@Qty", SqlDbType.Float, 9).Value = TrnQty
                    oCmd.Parameters.Add("@WO", SqlDbType.VarChar, 6).Value = WO
                    oCmd.CommandText = "mm_sp_GroundBalanceConsumptionUpdate"
                    oCmd.CommandType = CommandType.StoredProcedure
                    oCmd.ExecuteNonQuery()
                End If
                If GroundBalanceCBUpdate(Consignee, TrnDate, PlNo) Then Done = True
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If Not IsNothing(oCmd) Then
                    If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                    oCmd.Dispose()
                    oCmd = Nothing
                End If
            End Try
            Return Done
        End Function
        Private Function GroundBalanceCBUpdate(ByVal Consignee As String, ByVal TrnDate As Date, ByVal PlNo As String) As Boolean
            Dim oCmd1 As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim Done As Boolean
            Try
                If oCmd1.Connection.State = ConnectionState.Closed Then oCmd1.Connection.Open()
                oCmd1.Transaction = oCmd1.Connection.BeginTransaction
                oCmd1.Parameters.Add("@Consignee", SqlDbType.VarChar, 50).Value = Consignee
                oCmd1.Parameters.Add("@pl_number", SqlDbType.VarChar, 9).Value = PlNo
                oCmd1.Parameters.Add("@GBDate", SqlDbType.SmallDateTime, 4).Value = TrnDate
                oCmd1.CommandText = "mm_sp_GroundBalanceCBUpdate"
                oCmd1.CommandType = CommandType.StoredProcedure
                oCmd1.ExecuteNonQuery()
                Done = True
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If Not IsNothing(oCmd1) Then
                    If Done Then
                        oCmd1.Transaction.Commit()
                    Else
                        oCmd1.Transaction.Rollback()
                    End If
                    If oCmd1.Connection.State = ConnectionState.Open Then oCmd1.Connection.Close()
                    oCmd1.Dispose()
                    oCmd1 = Nothing
                End If
            End Try
            Return Done
        End Function
        Public Function UpdateGroundBalance(ByVal TrnType As String, ByVal PlNo As String, ByVal WO As String, ByVal TrnQty As Decimal, ByVal PlTbl As DataTable, ByVal ConDate As Date, ByVal SubShop As String, ByVal UserID As String, ByVal ReceiptDate As Date, ByVal FirstConDate As Date, ByVal woTbl As DataTable) As Boolean
            Dim tbl As DataTable = CType(PlTbl, DataTable)
            Dim row As DataRow
            Dim blnDone As Boolean
            Dim modeObCb, modeReceipt, modeConsumption As String
            Dim strUpdtConsumption, strChkExistenceConsumption, strInsertConsumption As String
            strUpdtConsumption = "update c set c.quantity = @ConsumedQty from  mm_daily_pl_consumption c where " & _
                                 " c.pl_number = @plNumber and  consumed_date = @consumedDate and workorder_number = @wo "
            strChkExistenceConsumption = "select @ConsumptionExists = count(*) from  mm_daily_pl_consumption c where c.pl_number = @plNumber and  consumed_date = @consumedDate and workorder_number = @wo"
            strInsertConsumption = "insert into  mm_daily_pl_consumption (consumed_date, Shift_Code, Shop_Code, Workorder_number, " & _
                                   " pl_number, quantity ) values (@ConsumedDate, @shiftCode, @shopCode, @wo, @plNumber, @ConsumedQty ) "

            Dim strUpdtReceipt, strChkExistenceReceipt, strInsertReceipt, strGetReceiptCode As String
            strUpdtReceipt = "update a set a.quantity_received = @ReceivedQty, a.Employee_code = @EmpCode from mm_shop_pl_receipt a where a.pl_number = @plNumber and shop_code = @shopCode and receipt_date = @ReceiptDate"
            strInsertReceipt = "insert into mm_shop_pl_receipt ( Pl_Number, Shop_Code, Quantity_Received, Receipt_Date, Employee_code  )   values ( @PlNumber, @shopCode, @ReceivedQty, @ReceiptDate, @EmpCode )"
            strChkExistenceReceipt = "Select @ReceiptExists = count(*) from mm_shop_pl_receipt a where a.pl_number = @plNumber and shop_code = @shopCode and receipt_date = @ReceiptDate"

            strGetReceiptCode = "select top 1 isnull(receipt_code,0) from mm_shop_pl_receipt order by receipt_code desc"


            Dim strUpdtOBCB, strCheckExistenceOBCB, strInsertOBCB As String
            strUpdtOBCB = "update a set a.Opening_balance = @OpeningBalance, a.Closing_Balance = @ClosingBalance " & _
                          " from mm_shop_accountal a where a.pl_number = @PlNumber and a.shop_code = @shopCode and " & _
                          " a.record_date = @OBCBDate"
            strCheckExistenceOBCB = "select @ObCbExists = count(*) from mm_shop_accountal a where a.pl_number = @PlNumber and a.shop_code = @shopCode and a.record_date = @OBCBDate"
            strInsertOBCB = "insert into mm_shop_accountal (record_date, shop_code, pl_number, opening_balance, Closing_Balance ) values ( @ObCbDate, @shopCode, @plNumber, @OpeningBalance, @ClosingBalance )"

            Dim params(15) As SqlClient.SqlParameter
            params(0) = New SqlClient.SqlParameter("@ConsumedQty", SqlDbType.Decimal, 4)
            params(1) = New SqlClient.SqlParameter("@plNumber", SqlDbType.VarChar, 8)
            params(2) = New SqlClient.SqlParameter("@consumedDate", SqlDbType.SmallDateTime, 4)
            params(3) = New SqlClient.SqlParameter("@wo", SqlDbType.VarChar, 4)

            params(4) = New SqlClient.SqlParameter("@ConsumptionExists", SqlDbType.Int, 4)

            params(5) = New SqlClient.SqlParameter("@shiftCode", SqlDbType.VarChar, 1)
            params(6) = New SqlClient.SqlParameter("@shopCode", SqlDbType.VarChar, 4)
            params(7) = New SqlClient.SqlParameter("@ReceivedQty", SqlDbType.Decimal, 4)
            params(8) = New SqlClient.SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
            params(9) = New SqlClient.SqlParameter("@ReceiptDate", SqlDbType.SmallDateTime, 4)

            params(10) = New SqlClient.SqlParameter("@ReceiptExists", SqlDbType.Int, 4)

            params(11) = New SqlClient.SqlParameter("@OpeningBalance", SqlDbType.Decimal, 4)
            params(12) = New SqlClient.SqlParameter("@ClosingBalance", SqlDbType.Decimal, 4)
            params(13) = New SqlClient.SqlParameter("@OBCBDate", SqlDbType.SmallDateTime, 4)

            params(14) = New SqlClient.SqlParameter("@ObCbExists", SqlDbType.Int, 4)

            Dim i As Integer
            For i = 0 To 14
                If i = 4 Or i = 10 Or i = 14 Then
                    params(i).Direction = ParameterDirection.Output
                Else
                    params(i).Direction = ParameterDirection.Input
                End If
            Next
            Dim rw As DataRow

            For Each row In tbl.Rows
                ' assign values to params
                Try
                    params(1).Value = row("plNo")
                    params(2).Value = CDate(ConDate) ' consumed date
                    params(5).Value = "A"
                    params(6).Value = SubShop
                    params(7).Value = row("Receipt")
                    params(8).Value = UserID
                    params(9).Value = CDate(ReceiptDate) ' 
                    params(11).Value = row("OB")
                    params(12).Value = row("CB")
                    params(13).Value = CDate(FirstConDate)

                    ' values to be updated before each save
                    params(0).Value = 0 ' consumed qty
                    params(3).Value = "" ' wo
                    blnDone = True
                Catch exp As Exception
                    Throw New Exception(exp.Message)
                End Try
                If blnDone = False Then
                    Exit Function
                End If
                blnDone = False
                Dim blnObCbSaved, blnReceiptSaved, blnConsumptionSaved As Boolean
                Dim cmd As New SqlClient.SqlCommand()
                cmd.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
                i = 0
                For i = 0 To 14
                    cmd.Parameters.Add(params(i))
                Next
                ' execute save commands
                Try
                    cmd.Connection.Open()
                    cmd.CommandText = strCheckExistenceOBCB
                    cmd.ExecuteScalar()
                    If cmd.Parameters("@ObCbExists").Value > 0 Then
                        modeObCb = "Update"
                    Else
                        modeObCb = "Insert"
                    End If
                    cmd.CommandText = strChkExistenceReceipt
                    cmd.ExecuteScalar()
                    If cmd.Parameters("@ReceiptExists").Value > 0 Then
                        modeReceipt = "Update"
                    Else
                        modeReceipt = "Insert"
                    End If
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Connection.Open()
                    cmd.Transaction = cmd.Connection.BeginTransaction
                    If modeObCb = "Insert" Then
                        cmd.CommandText = strInsertOBCB
                        cmd.ExecuteNonQuery()
                        blnObCbSaved = True
                    ElseIf modeObCb = "Update" Then
                        cmd.CommandText = strUpdtOBCB
                        cmd.ExecuteNonQuery()
                        blnObCbSaved = True
                    End If
                    If modeReceipt = "Insert" Then
                        cmd.CommandText = strGetReceiptCode
                        cmd.Parameters.Add("@ReceiptCode", SqlDbType.Int, 4)
                        cmd.Parameters("@ReceiptCode").Direction = ParameterDirection.Output
                        cmd.Parameters("@ReceiptCode").Value = cmd.ExecuteScalar
                        cmd.Parameters("@ReceiptCode").Value += 1
                        cmd.Parameters("@ReceiptCode").Direction = ParameterDirection.Input
                        cmd.CommandText = strInsertReceipt
                        cmd.ExecuteNonQuery()
                        blnReceiptSaved = True
                    ElseIf modeReceipt = "Update" Then
                        cmd.CommandText = strUpdtReceipt
                        cmd.ExecuteNonQuery()
                        blnReceiptSaved = True
                    End If
                    For Each rw In CType(woTbl, DataTable).Rows
                        params(3).Value = rw("number") ' wo
                        params(0).Value = row(params(3).Value) ' consumed qty
                        cmd.CommandText = strChkExistenceConsumption
                        cmd.ExecuteScalar()
                        If cmd.Parameters("@ConsumptionExists").Value > 0 Then
                            modeConsumption = "Update"
                        Else
                            modeConsumption = "Insert"
                        End If
                        If modeConsumption = "Insert" Then
                            cmd.CommandText = strInsertConsumption
                            cmd.ExecuteNonQuery()
                            blnConsumptionSaved = True
                        ElseIf modeConsumption = "Update" Then
                            cmd.CommandText = strUpdtConsumption
                            cmd.ExecuteNonQuery()
                            blnConsumptionSaved = True
                        End If
                    Next
                    blnDone = blnConsumptionSaved And blnReceiptSaved And blnObCbSaved
                Catch exp As Exception
                    Throw New Exception(exp.Message)
                    blnDone = False
                Finally
                    If Not blnDone Then
                        If IsNothing(cmd) = False Then cmd.Transaction.Rollback()
                    Else
                        If IsNothing(cmd) = False Then cmd.Transaction.Commit()
                    End If
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    If IsNothing(cmd) Then cmd.Dispose()
                End Try
                If blnDone = False Then
                    Exit For
                End If
                i = 0
                For i = 0 To 14
                    cmd.Parameters.Remove(params(i))
                Next
                cmd = Nothing
                blnObCbSaved = Nothing
                blnReceiptSaved = Nothing
                blnConsumptionSaved = Nothing
            Next
            params(15) = Nothing
            i = Nothing
            strUpdtReceipt = Nothing
            strChkExistenceReceipt = Nothing
            strInsertReceipt = Nothing
            strGetReceiptCode = Nothing
            strUpdtReceipt = Nothing
            strChkExistenceReceipt = Nothing
            strInsertReceipt = Nothing
            strGetReceiptCode = Nothing
            strUpdtOBCB = Nothing
            strCheckExistenceOBCB = Nothing
            strInsertOBCB = Nothing
            row = Nothing
            blnDone = Nothing
            modeObCb = Nothing
            modeReceipt = Nothing
            modeConsumption = Nothing
            Return blnDone
        End Function
    End Class
    Public Class WNFM
        Public Shared Function GetWNFMList(ByVal ListValue As Integer, ByVal WhlNo As String, ByVal WhlType As String, ByVal YearOfManf As String, ByVal HeatNo As Long) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                If ListValue = 1 Then
                    da.SelectCommand.CommandText = "select wheel_number WhlNo , " & _
                        " a.heat_number HeatNo , rtrim(status) Sts , rtrim(a.drag_number) Drag , rtrim(remarks) Remarks " & _
                        " from mm_wheel a inner join mm_pouring b on a.heat_number = b.heat_number and a.wheel_number = b.engraved_number " & _
                        " where location = 'mopo' and description =  @WhlType and year(date_melt) = @YearOfManf " & _
                        " and wheel_number = @WhlNo order by a.heat_number , wheel_number"
                ElseIf ListValue = 2 Then
                    da.SelectCommand.CommandText = "select a.wheel_number WhlNo , " & _
                        " a.heat_number HeatNo , rtrim(status) Sts , rtrim(a.drag_number) Drag , rtrim(remarks) Remarks " & _
                        " from mm_wheel a inner join mm_pouring b on a.heat_number = b.heat_number and a.wheel_number = b.engraved_number " & _
                        " where a.heat_number =  @HeatNo and status <> 'passed' " & _
                        " order by a.heat_number , wheel_number "
                    da.SelectCommand.Parameters.Add("@HeatNo", SqlDbType.BigInt, 8).Value = Val(HeatNo)
                ElseIf ListValue = 3 Then
                    da.SelectCommand.CommandText = "select a.wheel_number WhlNo  , " & _
                        " a.heat_number HeatNo , rtrim(status) Sts , rtrim(a.drag_number) Drag , rtrim(remarks) Remarks " & _
                        " from mm_wheel a inner join mm_pouring b on a.heat_number = b.heat_number and a.wheel_number = b.engraved_number " & _
                        " where year(date_melt) = @YearOfManf and wheel_number = @WhlNo " & _
                        " and status <> 'passed' order by a.heat_number , wheel_number  "
                End If

                da.SelectCommand.Parameters.Add("@WhlNo", SqlDbType.BigInt, 8).Value = Val(WhlNo)
                da.SelectCommand.Parameters.Add("@WhlType", SqlDbType.VarChar, 50).Value = WhlType
                da.SelectCommand.Parameters.Add("@YearOfManf", SqlDbType.Int, 4).Value = Val(YearOfManf)
                da.Fill(ds)
                Return ds.Tables(0).Copy
            Catch exp As Exception
                Throw New Exception("Data Retrieval Error : " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function GetWNFMWheels() As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = "select WhlNo , HeatNo ," & _
                    " WhlType , YearOfManf , SlNo from mm_WheelNotFoundInMaster" & _
                    " where MRDate is null "
                da.Fill(ds)
                Return ds.Tables(0).Copy
            Catch exp As Exception
                Throw New Exception("Data Retrieval Error : " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function GetWheelTypes() As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = "select distinct description from mm_workorder" & _
                    " where product_code like '[1,2]%'" & _
                    " and workorder_date >= '2015-01-01'"
                da.Fill(ds)
                Return ds.Tables(0).Copy
            Catch exp As Exception
                Throw New Exception("Data Retrieval Error : " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Function SaveWNFMWheel(ByVal WhlNo As String, ByVal HeatNo As String, ByVal WhlType As String, ByVal YearOfManf As String, ByVal FedDate As Date) As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim Done As Boolean
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Parameters.Add("@WhlNo", SqlDbType.VarChar, 50).Value = WhlNo
                oCmd.Parameters.Add("@HeatNo", SqlDbType.VarChar, 50).Value = HeatNo
                oCmd.Parameters.Add("@WhlType", SqlDbType.VarChar, 50).Value = WhlType
                oCmd.Parameters.Add("@YearOfManf", SqlDbType.VarChar, 50).Value = YearOfManf
                oCmd.Parameters.Add("@FedDate", SqlDbType.SmallDateTime, 4).Value = FedDate
                oCmd.CommandText = "insert into mm_WheelNotFoundInMaster ( WhlNo , HeatNo , WhlType , YearOfManf , FedDate ) " & _
                    " values ( @WhlNo , @HeatNo , @WhlType , @YearOfManf , @FedDate )"
                If oCmd.ExecuteNonQuery() = 1 Then Done = True
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If Not IsNothing(oCmd) Then
                    If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                    oCmd.Dispose()
                    oCmd = Nothing
                End If
            End Try
            Return Done
        End Function
        Public Function DeleteWNFMWheel(ByVal WhlNo As String, ByVal HeatNo As String, ByVal WhlType As String, ByVal YearOfManf As String, ByVal SlNo As Integer) As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim Done As Boolean
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Parameters.Add("@WhlNo", SqlDbType.VarChar, 50).Value = WhlNo
                oCmd.Parameters.Add("@HeatNo", SqlDbType.VarChar, 50).Value = HeatNo
                oCmd.Parameters.Add("@WhlType", SqlDbType.VarChar, 50).Value = WhlType
                oCmd.Parameters.Add("@YearOfManf", SqlDbType.VarChar, 50).Value = YearOfManf
                oCmd.Parameters.Add("@SlNo", SqlDbType.Int, 4).Value = SlNo
                oCmd.CommandText = "delete from mm_WheelNotFoundInMaster where WhlNo = @WhlNo and HeatNo = @HeatNo " & _
                    " and WhlType = @WhlType  and YearOfManf = @YearOfManf  and SlNo = @SlNo "

                If oCmd.ExecuteNonQuery() = 1 Then Done = True
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If Not IsNothing(oCmd) Then
                    If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                    oCmd.Dispose()
                    oCmd = Nothing
                End If
            End Try
            Return Done
        End Function
        Public Function UpdateWNFMWheel(ByVal WhlReadAtMR As String, ByVal Wheel_number As Long, ByVal heat_number As Long, ByVal MRDate As Date, ByVal Remarks As String, ByVal SIC As String, ByVal SlNo As Long) As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim Done As Boolean
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Parameters.Add("@WhlReadAtMR", SqlDbType.VarChar, 50).Value = WhlReadAtMR
                oCmd.Parameters.Add("@Wheel_number", SqlDbType.BigInt, 8).Value = Wheel_number
                oCmd.Parameters.Add("@heat_number", SqlDbType.BigInt, 8).Value = heat_number
                oCmd.Parameters.Add("@MRDate", SqlDbType.SmallDateTime, 4).Value = MRDate
                oCmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 50).Value = Remarks
                oCmd.Parameters.Add("@SIC", SqlDbType.VarChar, 50).Value = SIC
                oCmd.Parameters.Add("@SlNo", SqlDbType.BigInt, 8).Value = SlNo
                oCmd.CommandText = "update mm_WheelNotFoundInMaster set WhlReadAtMR = @WhlReadAtMR , " & _
                    " Wheel_number = @Wheel_number , heat_number = @heat_number , MRDate = @MRDate ," & _
                    " Remarks = @Remarks , SIC = @SIC where SlNo = @SlNo "
                If oCmd.ExecuteNonQuery() = 1 Then Done = True
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If Not IsNothing(oCmd) Then
                    If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                    oCmd.Dispose()
                    oCmd = Nothing
                End If
            End Try
            Return Done
        End Function
    End Class
End Namespace
