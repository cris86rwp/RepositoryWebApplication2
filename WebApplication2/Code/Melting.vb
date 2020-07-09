Namespace RWF
    Public Class Melting
        Public Shared Function GetPFremarks(ByVal YearMonth As String, ByVal PFNo As String) As String
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Parameters.Add("@YearMonth", SqlDbType.VarChar, 6).Value = YearMonth
                oCmd.Parameters.Add("@PFNo", SqlDbType.VarChar, 6).Value = PFNo
                oCmd.Parameters.Add("@PFRemarks", SqlDbType.VarChar, 250).Direction = ParameterDirection.Output
                oCmd.CommandText = "select @PFRemarks = PFRemarks from mm_vw_MeltPCDO where YearMonth = @YearMonth " &
                        " and PFNo = @PFNo "
                oCmd.ExecuteScalar()
                GetPFremarks = IIf(IsDBNull(oCmd.Parameters("@PFRemarks").Value), "", oCmd.Parameters("@PFRemarks").Value)
            Catch exp As Exception
                Throw New Exception("Data for Life Error : " & exp.Message)
            Finally
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function
        Public Shared Function GetMeltPCDODetails(ByVal YearMonth As String) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = " select Accidents , DAR , OT , PFNo , EmployeeName , Designation ,  " &
                    " PFRemarks from mm_vw_MeltPCDO where YearMonth = @YearMonth "
                da.SelectCommand.Parameters.Add("@YearMonth", SqlDbType.VarChar, 6).Value = YearMonth
                da.Fill(ds)
                Return ds.Tables(0)
            Catch exp As Exception
                Throw New Exception("Data for PreHeated Ladle Details Error : " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function GetPFDetails(ByVal PFNo As String) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = " select employee_name EmployeeName, short_description Designation " &
                    " from hr_employee_master c inner join hr_designation_master d on c.designation_code = d.designation_code " &
                    " where employee_code  = @PFNo "
                da.SelectCommand.Parameters.Add("@PFNo", SqlDbType.VarChar, 6).Value = PFNo
                da.Fill(ds)
                Return ds.Tables(0)
            Catch exp As Exception
                Throw New Exception("Data for PreHeated Ladle Details Error : " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function GetFESLink(ByVal HeatNo As Long) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = " select *  from mm_vw_FESLink where HeatNo  = @HeatNo "
                da.SelectCommand.Parameters.Add("@HeatNo", SqlDbType.BigInt, 8).Value = HeatNo
                da.Fill(ds)
                Return ds.Tables(0)
            Catch exp As Exception
                Throw New Exception("Data for PreHeated Ladle Details Error : " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function GetFumeExtractionDetails() As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = " select top 5 FromHeat , ToHeat , " &
                    " convert(varchar(10),OffTime,103) OffDate , convert(varchar(5),OffTime,108) OffTime ,  " &
                    " convert(varchar(10),OnTime,103) OnDate , convert(varchar(5),OnTime,108) OnTime ,  Remarks , SlNo " &
                    " from mm_FumeExtraction order by FromHeat desc "
                da.Fill(ds)
                Return ds.Tables(0)
            Catch exp As Exception
                Throw New Exception("Data for PreHeated Ladle Details Error : " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function GetLadlePreHeatLiningNos() As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = "select distinct LiningNo from mm_PreHeatedLadleDetails order by LiningNo desc "
                da.Fill(ds)
                Return ds.Tables(0)
            Catch exp As Exception
                Throw New Exception("Data for PreHeated Ladle Details Error : " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function GetPreHeatedLadleSetTemp(ByVal PreHeatID As Integer) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.Parameters.Add("@PreHeatID", SqlDbType.Int, 4).Value = PreHeatID
                da.SelectCommand.CommandText = "select PreHeatID , convert(varchar(10),SetDateTime,103) SetDate  ," &
                    " convert(varchar(5),SetDateTime,108) SetTime , LPH , HSDQty , SetTemp , ActualTemp , Staff , Remarks , SetID " &
                    " from mm_PreHeatedLadleSetTemp where PreHeatID = @PreHeatID order by SetDateTime desc "
                da.Fill(ds)
                Return ds.Tables(0)
            Catch exp As Exception
                Throw New Exception("Data for PreHeated Ladle SetTemp Error : " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function GetLiningDetails(ByVal LiningNo As String) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = "select LadleNo , convert(varchar(10),StartTime,103) StartDate  ," &
                    " convert(varchar(5),StartTime,108) StTime , case when Type = '0' then 'New' else 'ReHeat' end Type , " &
                    " LiftingTemp , FromHeat , ToHeat , Remarks  " &
                    " from mm_PreHeatedLadleDetails where LiningNo = @LiningNo order by StartTime desc "
                da.SelectCommand.Parameters.Add("@LiningNo", SqlDbType.VarChar, 50).Value = LiningNo
                da.Fill(ds)
                Return ds.Tables(0)
            Catch exp As Exception
                Throw New Exception("Data for PreHeated Ladle Details Error : " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function GetPreHeatIDs() As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = "select LiningNo , LadleNo , convert(varchar(10),StartTime,103) StartDate  ," &
                    " convert(varchar(5),StartTime,108) StTime , case when Type = '0' then 'New' else 'ReHeat' end Type , " &
                    " PreHeatID from mm_PreHeatedLadleDetails order by StartTime desc "
                da.Fill(ds)
                Return ds.Tables(0)
            Catch exp As Exception
                Throw New Exception("Data for PreHeated Ladle Details Error : " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function GetLiningNoDetails(ByVal LiningNo As String) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.Parameters.Add("@LiningNo", SqlDbType.VarChar, 50).Value = LiningNo
                da.SelectCommand.CommandText = "select LiningItemNo LadleNo ," &
                    " convert(varchar(10),HandedOverOn,103) HandedOverDt , convert(varchar(5),HandedOverOn,114) HOTime , " &
                    " convert(varchar(10),WorkStartedOn,103) WorkSartDt , convert(varchar(5),WorkStartedOn,114) WSTime , " &
                    " convert(varchar(10),WorkCompletedOn,103) WorkCompDt , convert(varchar(5),WorkCompletedOn,114) WCTime " &
                    " from ms_FurnaceLining where LiningNo = @LiningNo and LT = 3 "
                da.Fill(ds)
                Return ds.Tables(0)
            Catch exp As Exception
                Throw New Exception("Data for FurnaceLining Error : " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function GetPreHeatedLadleDetails(ByVal LiningNo As String) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.Parameters.Add("@LiningNo", SqlDbType.VarChar, 50).Value = LiningNo
                da.SelectCommand.CommandText = "select LiningNo , LadleNo , convert(varchar(10),StartTime,103) StartDate  ," &
                    " convert(varchar(5),StartTime,108) StTime , convert(varchar(10),EndTime,103) EndDate , " &
                    " convert(varchar(5),EndTime,108) EndTime , wap.dbo.ms_fn_ConvertTimeInNumberToHour(datediff(mi,StartTime,EndTime)) TotTime ,     " &
                    " LiftingTemp , FromHeat , ToHeat , StaffNo , case when Type = '0' then 'New' else 'ReHeat' end Type , Remarks , PreHeatID " &
                    " from mm_PreHeatedLadleDetails where LiningNo = @LiningNo " &
                    " order by StartTime "
                da.Fill(ds)
                Return ds.Tables(0)
            Catch exp As Exception
                Throw New Exception("Data for PreHeatedLadleDetail Error : " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function GetFurnaceLife(ByVal FurNo As String) As String
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Parameters.Add("@FurNo", SqlDbType.VarChar, 10).Value = FurNo
                oCmd.Parameters.Add("@Life", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                oCmd.CommandText = "select top 1 @Life = isnull(furnace_life,0) from mm_vw_HeatTapped a inner join mm_furnace_condition b" &
                    " on a.heat_number = b.heat_number and heat_tapped >=  ( " &
                    " select top 1 WorkCompletedOn from ms_FurnaceLining" &
                    " where lt = 2 and LiningItemNo = @FurNo " &
                    " order by WorkCompletedOn desc )" &
                    " and furnace_code = @FurNo order by a.heat_number desc"
                oCmd.ExecuteScalar()
                GetFurnaceLife = IIf(IsDBNull(oCmd.Parameters("@Life").Value), 0, oCmd.Parameters("@Life").Value)
                GetFurnaceLife = GetFurnaceLife + 1
            Catch exp As Exception
                Throw New Exception("Data for Life Error : " & exp.Message)
            Finally
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function
        Public Shared Function GetRoofLiningNo(ByVal RoofNo As String, ByVal HeatNo As Long) As String
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Parameters.Add("@RoofNo", SqlDbType.VarChar, 10).Value = RoofNo
                oCmd.Parameters.Add("@HeatNo", SqlDbType.BigInt, 8).Value = HeatNo
                oCmd.Parameters.Add("@LiningNo", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                oCmd.CommandText = "select top 1 @LiningNo = LiningNo from ms_furnacelining" &
                    " where lt = 4 and liningItemNo = @RoofNo " &
                    " and WorkCompletedOn < ( select heat_tapped from mm_vw_HeatTapped" &
                    " where heat_number = @HeatNo )" &
                    " order by WorkCompletedOn desc "
                oCmd.ExecuteScalar()
                GetRoofLiningNo = IIf(IsDBNull(oCmd.Parameters("@LiningNo").Value), "", oCmd.Parameters("@LiningNo").Value)
            Catch exp As Exception
                Throw New Exception("Data for RoofNo Error : " & exp.Message)
            Finally
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function
        Public Shared Function GetRoofLife(ByVal RoofNo As String) As String
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Parameters.Add("@RoofNo", SqlDbType.VarChar, 10).Value = RoofNo
                oCmd.Parameters.Add("@Life", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                oCmd.CommandText = "select top 1 @Life = Life from mm_roof_details " &
                    " where roof_number = @RoofNo " &
                    " order by heat_number desc "
                oCmd.ExecuteScalar()
                GetRoofLife = IIf(IsDBNull(oCmd.Parameters("@Life").Value), 0, oCmd.Parameters("@Life").Value)
                GetRoofLife = GetRoofLife + 1
            Catch exp As Exception
                Throw New Exception("Data for RoofNo Error : " & exp.Message)
            Finally
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function
        Public Shared Function GetRoofNo(ByVal FurNo As String, ByVal FromHeatNo As Long) As String
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Parameters.Add("@FurnaceCode", SqlDbType.VarChar, 10).Value = FurNo
                oCmd.Parameters.Add("@FromHeatNo", SqlDbType.VarChar, 10).Value = FromHeatNo
                oCmd.Parameters.Add("@RoofNo", SqlDbType.VarChar, 10).Direction = ParameterDirection.Output
                oCmd.CommandText = "select top 1 @RoofNo = RoofNo from mm_RoofFixing " &
                    " where FurnaceCode = @FurnaceCode and ToHeatNo = 0 and @FromHeatNo >= FromHeatNo " &
                    " order by FromHeatNo desc "
                oCmd.ExecuteScalar()
                GetRoofNo = IIf(IsDBNull(oCmd.Parameters("@RoofNo").Value), "", oCmd.Parameters("@RoofNo").Value)
            Catch exp As Exception
                Throw New Exception("Data for RoofNo Error : " & exp.Message)
            Finally
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function
        Public Shared Function RoofFixingList(ByVal RoofNo As String) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.Parameters.Add("@RoofNo", SqlDbType.VarChar, 10).Value = RoofNo
                da.SelectCommand.CommandText = "select top 5 RoofNo , FurnaceCode Fur , " &
                    " FromHeatNo , ToHeatNo , Reason , Remarks , LiningNo from mm_RoofFixing " &
                    " where RoofNo = @RoofNo " &
                    " order by FromHeatNo desc "
                da.Fill(ds)
                Return ds.Tables(0)
            Catch exp As Exception
                Throw New Exception("Data for RoofNo Error : " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function ContractDetails(ByVal ContractNo As String) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.Parameters.Add("@ContractNo", SqlDbType.VarChar, 10).Value = ContractNo
                da.SelectCommand.CommandText = " select  convert(varchar(10),a.contract_date,103) ContractDt  ,  " &
                    " a.contract_number ContractNo , Qty , (rtrim(a.agrement_number)) AgrementNumber ,  " &
                    " rtrim((isnull(a.contractor_name,''))) ContractorName , ltrim((rtrim(a.work_name))) WorkName " &
                    " from fm_contract a  inner join code b on  a.consignee = b.code and b.application = 'PM' and b.code_type = 'CC'  " &
                    " inner join fm_code c on a.department_code = c.code and c.code_type = 'CC' AND LEFT(RTRIM(C.CODE),1) NOT IN ('B','R','O','W')  " &
                    " left outer join mm_ContractQty e on ContractNo = a.contract_number " &
                    " left outer join fm_vw_Contract_Total_Payment d on a.department_code = d.department_code " &
                    " and a.contract_number = d.contract_number " &
                    " where a.consignee = 'PTMS' and a.department_code = 'HH'" &
                    " and a.contract_number = @ContractNo "
                da.Fill(ds)
                Return ds.Tables(0)
            Catch exp As Exception
                Throw New Exception("Data for RoofNo Error : " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        'Public Shared Function RoofNos() As DataTable
        '    Dim ds As New DataSet()
        '    Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        '    Try
        '        da.SelectCommand.CommandText = "select distinct 'WC'+LiningItemNo RoofNo from ms_FurnaceLining" & _
        '            " where LT = 4 and FirstHeatNo is null " & _
        '            " and LiningItemNo not in (  " & _
        '            " select Roof from ms_vw_RoofsNotInUse ) " & _
        '            " order by RoofNo"
        '        da.Fill(ds)
        '        Return ds.Tables(0)
        '    Catch exp As Exception
        '        Throw New Exception("Data for RoofNo Error : " & exp.Message)
        '    Finally
        '        da.Dispose()
        '        ds.Dispose()
        '        ds = Nothing
        '        da = Nothing
        '    End Try
        'End Function
        Public Shared Function RoofNos(ByVal rbf As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@rbf", SqlDbType.VarChar, 50).Value = rbf
                'da.SelectCommand.CommandText = "select distinct LiningItemNo RoofNo from ms_FurnaceLining" &
                '    " where LT = 4 and FirstHeatNo is null " &
                '    " and LiningItemNo not in (  " &
                '    " select Roof from ms_vw_RoofsNotInUse ) " &
                '    " order by RoofNo"
                da.SelectCommand.CommandText = "select distinct (select Roof from ms_vw_RoofsNo where FurnaceCode=@rbf)+LiningItemNo RoofNo from ms_FurnaceLining a, mm_RoofFixing b" &
                " where LT = 4 and FirstHeatNo is null "

                da.Fill(ds)
                Return ds.Tables(0)
            Catch exp As Exception
                Throw New Exception("Data for RoofNo Error : " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function LadlePOSavedDetails(ByVal PONumber As String) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.Parameters.Add("@PONumber", SqlDbType.VarChar, 50).Value = PONumber
                da.SelectCommand.CommandText = "select InspCertificateNo CerNo , " &
                    " convert(varchar(10),InspCertificateDate,103) CerDate, AcceptedQty , " &
                    " BricksSize , PLC, RUL, PCE, AP, Remarks " &
                    " from mm_LadlePODetails where PONumber = @PONumber "
                da.Fill(ds)
                Return ds.Tables(0)
            Catch exp As Exception
                Throw New Exception("Data Retrieval Error : " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function LadlePODetails(ByVal PONumber As String) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.Parameters.Add("@PONumber", SqlDbType.VarChar, 50).Value = PONumber
                da.SelectCommand.CommandText = "select po_date , order_quantity , received_quantity , " &
                    " rtrim(c.UnitName) UnitName , po_alternate_description , d.name Firm" &
                    " from pm_po_header a inner join pm_po_details b on a.po_number = b.po_number " &
                    " inner join pm_ItemMaster c on c.pl_number = b.pl_number " &
                    " inner join pm_SupplierMaster d on d.supplier_code = a.supplier_code " &
                    " where a.po_number  = @PONumber "
                da.Fill(ds)
                Return ds.Tables(0)
            Catch exp As Exception
                Throw New Exception("Data Retrieval Error : " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function CheckPreviousHeatTapTime(ByVal heat_number As Long, ByVal heat_tapped As Date) As String
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@PreHeatNumber", SqlDbType.BigInt, 8).Value = heat_number - 1
            oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@PreHeatTapped", SqlDbType.DateTime, 8).Direction = ParameterDirection.Output
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()

                oCmd.CommandText = "select @PreHeatTapped = heat_number from mm_offheat_heatsheet_header " &
                    " where heat_number = @PreHeatNumber"
                oCmd.ExecuteScalar()

                If IsDBNull(oCmd.Parameters("@PreHeatTapped").Value) Then
                    oCmd.CommandText = "select @PreHeatTapped = heat_tapped from " &
                                        " mm_vw_HeatTapped where heat_number =  @PreHeatNumber"
                    oCmd.ExecuteScalar()
                Else
                    oCmd.CommandText = "select @PreHeatTapped = heat_number from mm_offheat_heatsheet_header " &
                                      " where heat_number = @PreHeatNumber - 1 "
                    oCmd.ExecuteScalar()
                    If IsDBNull(oCmd.Parameters("@PreHeatTapped").Value) Then
                        oCmd.CommandText = "select @PreHeatTapped = heat_tapped from " &
                            " mm_vw_HeatTapped where heat_number =  @PreHeatNumber - 1 "
                        oCmd.ExecuteScalar()
                    End If
                End If
                Dim PreHeatTapped As DateTime = oCmd.Parameters("@PreHeatTapped").Value
                Dim str As String = PreHeatTapped.ToString
                CheckPreviousHeatTapTime = IIf(PreHeatTapped > heat_tapped, str, "")
            Catch exp As Exception
                CheckPreviousHeatTapTime = False
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function
        Public Shared Function IsMeltDateOfPreviousHeatGreater(ByVal PreviousHt As Long, ByVal MeltDate As Date) As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@melt_date", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@PreviousHt", SqlDbType.BigInt, 8).Value = PreviousHt
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = "select @melt_date = melt_date  " &
                    " from mm_heatsheet_header a  where a.heat_number =  @PreviousHt "
                oCmd.ExecuteScalar()
                If IsDBNull(oCmd.Parameters("@melt_date").Value) Then
                    oCmd.CommandText = "select @melt_date = melt_date  " &
                                       " from mm_offheat_heatsheet_header a  where a.heat_number =  @PreviousHt "
                    oCmd.ExecuteScalar()
                End If
                If IIf(IsDBNull(oCmd.Parameters("@melt_date").Value), Now.Date, oCmd.Parameters("@melt_date").Value) > MeltDate Then
                    IsMeltDateOfPreviousHeatGreater = True
                End If
            Catch exp As Exception
                IsMeltDateOfPreviousHeatGreater = False
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function
        Public Shared Function CheckPHLDateForHeatNo(ByVal heat_number As Long) As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@cnt", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = "select @cnt = count(*) from " &
                    " mm_heatsheet_header a inner join mm_vw_HeatTapped b" &
                    " on a.heat_number = b.heat_number inner join " &
                    " mm_phl_generation  c on phl_Date = TappedDate " &
                    " where a.heat_number =  " & heat_number & ""
                oCmd.ExecuteScalar()
                CheckPHLDateForHeatNo = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)
            Catch exp As Exception
                CheckPHLDateForHeatNo = False
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function
        Public Shared Function GetSampleData(ByVal heat_number As Long, Optional ByVal Sample As String = "") As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.Parameters.Add("@Heat", SqlDbType.BigInt, 8).Value = heat_number
                da.SelectCommand.CommandText = "select sample_number SmpNo  , " &
                    " rtrim(sample_taken_time) SmpTime ,  sample_temperature SmpTemp , " &
                    " car_car C , man_man Mn ,  sil_sil Si , pho_pho P , sul_sul S , chr_chr Cr , ni_ni N , " &
                    " cop_cop Cu , alu_alu Al ,  moly_moly Mo , Ven_Ven V , nitro_nitro Ni , hydro_hydro H " &
                    " from mm_spectro_results where heat_number =  @Heat "
                If Sample.Trim.Length = 0 Then
                    da.SelectCommand.CommandText &= " order by sample_taken_time ; "
                Else
                    da.SelectCommand.CommandText &= " and sample_number = '" & Sample.Trim & "' ; "
                End If
                da.Fill(ds)
                Return ds.Tables(0)
            Catch exp As Exception
                Throw New Exception("Data Retrieval Error : " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function GetSheet3Data(ByVal heat_number As Long) As DataSet
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.Parameters.Add("@Heat", SqlDbType.BigInt, 8).Value = heat_number
                da.SelectCommand.CommandText = "select brkdn_code , (brkdn_code+ '-' + brkdn_desc) as code from mm_mmbdc order by brkdn_code ; " &
                    " select convert(varchar(1),heat_status) heatStatus , convert(varchar(1),tap_drain) TapDrain , " &
                    " graphite_dust_make , kwh_used , kwh_initial_reading , kwh_final_reading , tip_make , " &
                    " lpipe_make , tip_quantity , lpipe_quantity , electrode_dip_time , fettling_info , " &
                    " oxygen_initial_reading , oxygen_final_reading , oxygen_used , tap_temperature , " &
                    " tap_begin , tap_end , tap_time , sos_temperature , jmp_st_temperature , slag_condition ," &
                    " lm_level , sos_aluminium_star , jmp_aluminium_star , lm_level_final , " &
                    " convert(varchar(1),process_delay) ProcessDelay , hea_rem , heat_tapped , LOF , SOS " &
                    " from mm_post_melt where heat_number = @Heat ; " &
                    " select * from mm_process_delay where heat_number = @Heat "
                da.Fill(ds)
                Return ds.Copy
            Catch exp As Exception
                Throw New Exception("Data Retrieval Error : " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function GetSheet2Data(ByVal heat_number As Long) As DataSet
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.Parameters.Add("@Heat", SqlDbType.BigInt, 8).Value = heat_number
                da.SelectCommand.CommandText = "select furnace_inspection ," &
                    " roof_outtime , charge_start , charge_end , removed_material ," &
                    " levelling , roof_in , back_charge_metal , bucket_charge ," &
                    " charge_met , t2_power,PowerOn from mm_heat_sheet_melting " &
                    " where heat_number = @Heat ; " &
                    " select furnace_si_mn , furnace_fe_si , furnace_fe_mn , furnace_floor_spar , furnace_limestone ," &
                    " ladle_si_mn , ladle_fe_si , ladle_fe_mn , ladle_floor_spar , ladle_limestone , ContractNo , " &
                    " furnace_gunningdust , ladle_gunningdust , furnace_calcium_lime , rsm_contract , rsm_dept  " &
                    " from mm_inprocess_additives where heat_number = @Heat ; "
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
        Public Shared Function GetContractDetails(ByVal ContractNo As String) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.Parameters.Add("@ContractNo", SqlDbType.VarChar, 50).Value = ContractNo.Trim
                da.SelectCommand.CommandText = "select convert(varchar(10), contract_date,103) ContractDt , " &
                    " (rtrim(agrement_number)) AgrementNumber , rtrim((isnull(contractor_name,''))) ContractorName , " &
                    " convert(decimal(9,3),Qty) LOAQty , UsedQty = ( select  convert(decimal(9,3),sum(rsm_contract)) " &
                    " from mm_inprocess_additives a inner join mm_vw_HeatTapped b on a.heat_number = b.heat_number " &
                    " where ContractNo = @ContractNo ) , Balance = convert(decimal(9,3), " &
                    " ( Qty - ( select convert(decimal(9,3),sum(rsm_contract)) from mm_inprocess_additives " &
                    " a inner join mm_vw_HeatTapped b on a.heat_number = b.heat_number " &
                    " where ContractNo = @ContractNo) )) from fm_contract inner join mm_ContractQty b " &
                    " on contract_number = ContractNo where consignee = 'PTMS' and department_code = 'HH' " &
                    " and contract_number = @ContractNo "
                da.Fill(ds)
                Return ds.Tables(0)
            Catch exp As Exception
                Throw New Exception("Data Retrieval Error : " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function GetSheet1Data(ByVal heat_number As Long) As DataSet
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.Parameters.Add("@Heat", SqlDbType.BigInt, 8).Value = heat_number
                da.SelectCommand.CommandText = " select * from mm_heatsheet_header where heat_number = @Heat ; " &
                    " select bottom , furnace_life , sidewall_up , sidewall_low , bank ,rmk_sidewall_up,rmk_sidewall_low,rmk_bank,rmk_bottom,DRM_life,Brick_life  from mm_furnace_condition " &
                    " where heat_number = @Heat ; " &
                    " select ladle_number , life , bottom , sidewall from mm_ladle_details where heat_number = @Heat ; " &
                    " select roof_number , life , delta , roof_outer from mm_roof_details where heat_number = @Heat ; " &
                    " select bucket_number , entered_by , bucket_number2 , entered_by2 , bucket_number3 , " &
                    " entered_by3 from mm_heat_bucket where heat_number = @Heat ; " &
                    " select skull , riser_hub , cut_scrap , hbi , pygmy_pot , wheel_cut , lms,slpr_cut , hot_heal , " &
                    " axle_cut , tuning_boring , wheel , axle_end , shredded_scrap , Rail_cut , Remarks " &
                    " from mm_heat_sheet_charge where heat_number = @Heat ; " &
                    " select e1make , e1added ,  e1tip_profile , e2make , e2added ,  e2tip_profile , " &
                    " e3make , e3added,  e3tip_profile from mm_electrode where heat_number = @Heat ; " &
                    " select * from mm_nonmetal_addition where heat_number = @Heat ; " &
                    " select ramming_mass_make , ramming_mass_quantity , gunning_mix_make , gunning_mix_quantity , " &
                    " wet_ramming_mass_make , wet_ramming_mass_quantity  from mm_fettling_details where heat_number = @Heat ; "
                da.Fill(ds)
                Return ds.Copy
            Catch exp As Exception
                Throw New Exception("Data Retrieval Error : " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function GetSheet1ElectrodeDetails(ByVal heat_number As Long) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@Heat", SqlDbType.BigInt, 8).Value = heat_number
                da.SelectCommand.CommandText = " select e1Reason , e2Reason , e3Reason , " &
                    " e1Time , e2Time, e3Time, e1remark, e2remark, e3remark ,  " &
                    " Location1 , Location2 , Location3 " &
                    " from mm_electrode where heat_number = @Heat"
                da.Fill(ds)
                GetSheet1ElectrodeDetails = ds.Tables(0).Copy
            Catch exp As Exception
                GetSheet1ElectrodeDetails = Nothing
                Throw New Exception(" Retrival error" & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function CheckTap_time(ByVal heat_number As Long) As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@tap_time", SqlDbType.Float, 8).Direction = ParameterDirection.Output
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = "select @tap_time = tap_time from mm_post_melt where heat_number =  " & heat_number & ""
                oCmd.ExecuteScalar()
                CheckTap_time = IIf(IsDBNull(oCmd.Parameters("@tap_time").Value), 0, oCmd.Parameters("@tap_time").Value)
            Catch exp As Exception
                CheckTap_time = 0
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function
        Public Shared Function PreviousLadleDetails(ByVal heat_number As Long, ByVal ladle_number As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = " select top 1 life , heat_number from mm_ladle_details " &
                    " where ladle_number = '" & ladle_number.Trim & "' and heat_number < " & CInt(heat_number) & " order by heat_number desc"
                da.Fill(ds)
                PreviousLadleDetails = ds.Tables(0).Copy
            Catch exp As Exception
                PreviousLadleDetails = Nothing
                Throw New Exception(" Retrival error" & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function CheckHeatNo(ByVal heat_number As Long, Optional ByVal Type As Int16 = 1) As Boolean
            Dim cnt As Long
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@cnt", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = "select @cnt = count(heat_number) from mm_heatsheet_header where heat_number = " & heat_number & ""
                oCmd.ExecuteScalar()
                cnt = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)
                If cnt = 0 Then
                    If Type = 0 Then
                        cnt = RWF.Melting.GenerateHeatNo
                        If heat_number = cnt Then CheckHeatNo = True
                    End If
                Else
                    CheckHeatNo = True
                End If
            Catch exp As Exception
                CheckHeatNo = False
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
                cnt = Nothing
            End Try
        End Function
        Public Shared Function ScrapAccontalCB(ByVal MeltDate As Date) As DataTable
            Dim dt As Date
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = "ms_sp_ScrapAccontal"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.Add("@FrDate", SqlDbType.SmallDateTime, 4).Value = MeltDate
                da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.SmallDateTime, 4).Value = MeltDate
                da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = 6
                da.Fill(ds)
                Return ds.Tables(0)
            Catch exp As Exception
                Throw New Exception("Data Retrieval Error : " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                ds = Nothing
                da = Nothing
                dt = Nothing
            End Try
        End Function
        Public Shared Function GetMakes() As DataSet
            Dim dt As Date
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = "select TipMake from mm_vw_TipMake order by TipMake ; " &
                    " select LPipeMake from mm_vw_LancingPipeMake order by LPipeMake desc ; " &
                    " select DRMMake from mm_vw_DRMMake order by DRMMake ; " &
                    " select WRMMake from mm_vw_WRMMake order by WRMMake ; " &
                    " select GMixMake from mm_vw_GMixMake order by GMixMake ; "
                da.Fill(ds)
                Return ds.Copy
            Catch exp As Exception
                Throw New Exception("Data Retrieval Error : " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                ds = Nothing
                da = Nothing
                dt = Nothing
            End Try
        End Function
        Public Shared Function GetWoNo(ByVal MeltDate As Date) As DataTable
            Dim dt As Date
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                Dim str, str_nxt As String
                dt = MeltDate
                str = Right(dt.Year, 1) & Chr(dt.Month + 64) & "%"
                da.SelectCommand.CommandText = "select RTRIM(number+'-'+description) as wonumber , number " &
                    " from mm_workorder where shop_code like 'E%' and status like 'O%' " &
                    " and number like '" & str & "' and product_code <> '110344' "

                da.Fill(ds)
                ' following 8 lines added on 01Dec2016
                ' to allow workorder of previous month to appear if present month WO are nil
                If ds.Tables(0).Rows.Count = 0 Then
                    dt.AddMonths(-1)
                    str = Right(dt.Year, 1) & Chr(dt.Month + 64) & "%"
                    da.SelectCommand.CommandText = "select RTRIM(number+'-'+description) as wonumber , number " &
                        " from mm_workorder where shop_code like 'E%' and status like 'O%' " &
                        " and number like '" & str & "' and product_code <> '110344' "
                    ds.Clear()
                    da.Fill(ds)
                End If
                str = Nothing
                str_nxt = Nothing
                Return ds.Tables(0)
            Catch exp As Exception
                Throw New Exception("Data Retrieval Error : " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                ds = Nothing
                da = Nothing
                dt = Nothing
            End Try
        End Function
        Public Shared Function GetMeltDateForHeatNo(ByVal heat_number As Long) As Date
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@heat_number", SqlDbType.BigInt, 8).Value = heat_number
            oCmd.Parameters.Add("@melt_date", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = "select @melt_date = melt_date from mm_heatsheet_header where heat_number = @heat_number"
                oCmd.ExecuteScalar()
                Dim MeltDate As Date = IIf(IsDBNull(oCmd.Parameters("@melt_date").Value), IIf(Now.Hour < 6, Now.Date.AddDays(-1), Now.Date), oCmd.Parameters("@melt_date").Value)
                oCmd.Parameters.Add("@CalendarDate", SqlDbType.SmallDateTime, 4).Value = MeltDate
                oCmd.CommandText = "select @cnt = count(*) from mm_calendar_dump where shop = 'MEME' and date = @CalendarDate"
                oCmd.ExecuteScalar()
                If IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value) = 0 Then
                    GetMeltDateForHeatNo = MeltDate
                Else
                    Dim i As Integer
                    For i = 1 To 300
                        MeltDate = MeltDate.AddDays(i)
                        oCmd.Parameters("@CalendarDate").Value = MeltDate
                        oCmd.CommandText = "select @cnt = count(*) from mm_calendar_dump where shop = 'MEME' and date = @CalendarDate"
                        oCmd.ExecuteScalar()
                        If IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value) = 0 Then
                            GetMeltDateForHeatNo = MeltDate
                            Exit For
                        End If
                    Next
                End If
            Catch exp As Exception
                GetMeltDateForHeatNo = Now.Date
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function
        Public Shared Function CheckOffHeatNo(ByVal HeatNo As Long) As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@cnt", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@HeatNo", SqlDbType.BigInt, 8).Value = HeatNo
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = "select @cnt = count(*) from mm_offheat_heatsheet_header " &
                    " where heat_number = @HeatNo "
                oCmd.ExecuteScalar()
                CheckOffHeatNo = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)
            Catch exp As Exception
                CheckOffHeatNo = 0
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function
        Public Shared Function GenerateHeatNo() As Long
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@heat_number", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = "select @heat_number = heat_number from mm_vw_Top1HeatNumberForMelting "
                oCmd.ExecuteScalar()
                GenerateHeatNo = IIf(IsDBNull(oCmd.Parameters("@heat_number").Value), 0, oCmd.Parameters("@heat_number").Value) + 1
            Catch exp As Exception
                GenerateHeatNo = 0
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function
        Public Shared Function LadleWeightsData(ByVal heat_number As Long) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = " select w1 , w2 from mm_ladleweights where heat_number = " & CInt(heat_number)
                da.Fill(ds)
                Return ds.Tables(0)
            Catch exp As Exception
                Throw New Exception("Data Retrieval Error : " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                ds = Nothing
                da = Nothing
            End Try
        End Function
        Public Shared Function CheckHeat(ByVal heat_number As Long) As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = "select @cnt = count(*) from mm_heatsheet_header where heat_number =  " & CInt(heat_number)
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
        Public Shared Function MeltingData(ByVal Qry As Integer, ByVal FromDate As Date, ByVal ToDate As Date, ByVal FrHt As Long, ByVal ToHt As Long, ByVal Type As Int16) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.SmallDateTime, 4).Value = FromDate
            da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.SmallDateTime, 4).Value = ToDate
            da.SelectCommand.Parameters.Add("@frht", SqlDbType.BigInt, 8).Value = FrHt
            da.SelectCommand.Parameters.Add("@toht", SqlDbType.BigInt, 8).Value = ToHt
            da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = Type
            da.SelectCommand.Parameters.Add("@Qry", SqlDbType.Int, 4).Value = Qry
            Try
                da.SelectCommand.CommandText = "mm_sp_MeltingQry"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
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
        Public Shared Function Carbon(ByVal FromDate As Date, ByVal ToDate As Date, ByVal FrHt As Long, ByVal ToHt As Long, ByVal Type As Int16, ByVal car As Decimal) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.SmallDateTime, 4).Value = FromDate
            da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.SmallDateTime, 4).Value = ToDate
            da.SelectCommand.Parameters.Add("@frht", SqlDbType.BigInt, 8).Value = FrHt
            da.SelectCommand.Parameters.Add("@toht", SqlDbType.BigInt, 8).Value = ToHt
            da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = Type
            da.SelectCommand.Parameters.Add("@car", SqlDbType.Decimal, 5, 2).Value = car
            Try
                da.SelectCommand.CommandText = "mm_sp_MeltingCarbonDetails"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
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
        Public Function LadleWeights(ByVal Heat As Long, ByVal w1 As Double, ByVal w2 As Double) As Boolean
            Dim Done As Boolean
            Dim CheckHeat As Int16
            Try
                Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                Try
                    oCmd.Parameters.Add("@Heat", SqlDbType.BigInt, 8).Value = Heat
                    oCmd.Parameters.Add("@w1", SqlDbType.Float, 8).Value = w1
                    oCmd.Parameters.Add("@w2", SqlDbType.Float, 8).Value = w2
                    oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                    oCmd.CommandText = "select @cnt = count(*) from mm_ladleweights where heat_number =  " & CInt(Heat)
                    oCmd.ExecuteScalar()
                    CheckHeat = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)
                    If CheckHeat = 0 Then
                        oCmd.CommandText = "insert into mm_ladleweights ( heat_number,w1,w2 ) " &
                             " values ( @Heat , @w1 , @w2 )"
                    Else
                        oCmd.CommandText = "update mm_ladleweights set w1 = @w1 , w2 = @w2 where heat_number = @Heat "
                    End If
                    CheckHeat = Nothing
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
            Catch exp As Exception
                Throw New Exception(exp.Message)
                Done = False
            End Try
            Return Done
        End Function
        Public Function SaveHeatSheet(ByVal Heat As Long, ByVal furnace_code As String, ByVal melt_date As Date, ByVal shift_code As String, ByVal shift_incharge As String, ByVal furnace_incharge As String, ByVal FurnaceOperator As String, ByVal workorder_number As String) As Boolean
            Dim Done As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            Try
                oCmd.Parameters.Add("@heat_number", SqlDbType.BigInt, 8).Value = Heat
                oCmd.Parameters.Add("@furnace_code", SqlDbType.VarChar, 10).Value = furnace_code.ToUpper
                oCmd.Parameters.Add("@melt_date", SqlDbType.SmallDateTime, 4).Value = melt_date
                oCmd.Parameters.Add("@shift_code", SqlDbType.VarChar, 1).Value = shift_code
                oCmd.Parameters.Add("@shift_incharge", SqlDbType.VarChar, 30).Value = shift_incharge
                oCmd.Parameters.Add("@furnace_incharge", SqlDbType.VarChar, 30).Value = furnace_incharge
                oCmd.Parameters.Add("@FurnaceOperator", SqlDbType.VarChar, 30).Value = FurnaceOperator
                oCmd.Parameters.Add("@workorder_number", SqlDbType.VarChar, 50).Value = workorder_number
                oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                oCmd.CommandText = "select @cnt = count(*) FROM mm_heatsheet_header WHERE heat_number = @heat_number "
                oCmd.ExecuteScalar()
                Done = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)
                If Done Then
                    Done = False
                    oCmd.CommandText = "update mm_heatsheet_header set furnace_code = @furnace_code , melt_date = @melt_date , " &
                       " shift_code = @shift_code , shift_incharge = @shift_incharge , furnace_incharge = @furnace_incharge ," &
                       " FurnaceOperator = @FurnaceOperator, workorder_number = @workorder_number where heat_number = @heat_number " '
                Else
                    oCmd.CommandText = "insert into mm_heatsheet_header ( heat_number , furnace_code , " &
                        " melt_date , shift_code , shift_incharge , furnace_incharge ,FurnaceOperator, workorder_number ) " &
                        " values ( @heat_number , @furnace_code , " &
                        " @melt_date , @shift_code , @shift_incharge , @furnace_incharge ,@FurnaceOperator, @workorder_number ) "
                End If
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                If oCmd.ExecuteNonQuery > 0 Then Done = True
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
        Public Function SaveRoof(ByVal heat_number As Long, ByVal roof_number As String, ByVal life As Integer, ByVal delta As String, ByVal roof_outer As String) As Boolean
            Dim Done As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            Try
                oCmd.Parameters.Add("@heat_number", SqlDbType.BigInt, 8).Value = heat_number
                oCmd.Parameters.Add("@roof_number", SqlDbType.VarChar, 50).Value = roof_number
                oCmd.Parameters.Add("@life", SqlDbType.Int, 4).Value = life
                oCmd.Parameters.Add("@delta", SqlDbType.VarChar, 50).Value = delta
                oCmd.Parameters.Add("@roof_outer", SqlDbType.VarChar, 50).Value = roof_outer
                oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                oCmd.CommandText = "select @cnt = count(*) FROM mm_roof_details WHERE heat_number = @heat_number "
                oCmd.ExecuteScalar()
                Done = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)
                If Done Then
                    Done = False
                    oCmd.CommandText = "update mm_roof_details set roof_number = @roof_number , life = @life , " &
                        " delta = @delta , roof_outer = @roof_outer where heat_number = @heat_number "
                Else
                    oCmd.CommandText = "insert into mm_roof_details ( heat_number ,  " &
                        " roof_number , life , delta , roof_outer ) " &
                        " values ( @heat_number , @roof_number , " &
                        " @life , @delta , @roof_outer ) "
                End If
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
        Public Function SaveLadle(ByVal heat_number As Long, ByVal ladle_number As String, ByVal life As Integer, ByVal bottom As String, ByVal sidewall As String) As Boolean
            Dim Done As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            Try
                oCmd.Parameters.Add("@heat_number", SqlDbType.BigInt, 8).Value = heat_number
                oCmd.Parameters.Add("@ladle_number", SqlDbType.VarChar, 50).Value = ladle_number
                oCmd.Parameters.Add("@life", SqlDbType.Int, 4).Value = life
                oCmd.Parameters.Add("@bottom", SqlDbType.VarChar, 50).Value = bottom
                oCmd.Parameters.Add("@sidewall", SqlDbType.VarChar, 50).Value = sidewall
                oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                oCmd.CommandText = "select @cnt = count(*) FROM mm_ladle_details WHERE heat_number = @heat_number "
                oCmd.ExecuteScalar()
                Done = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)
                If Done Then
                    Done = False
                    oCmd.CommandText = "update mm_ladle_details set ladle_number = @ladle_number , life = @life , " &
                        " bottom = @bottom , sidewall = @sidewall where heat_number = @heat_number "
                Else
                    oCmd.CommandText = "insert into mm_ladle_details ( heat_number ,  " &
                        " ladle_number , life , bottom , sidewall ) " &
                        " values ( @heat_number , @ladle_number , " &
                        " @life , @bottom , @sidewall ) "
                End If
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
        Public Function SaveFurnace(ByVal heat_number As Long, ByVal furnace_code As String, ByVal bottom As String, ByVal furnace_life As Integer, ByVal sidewall_up As String, ByVal sidewall_low As String, ByVal bank As String, ByVal melt_date As Date, ByVal shift_code As String, ByVal shift_incharge As String, ByVal FBRMK As String, ByVal FSWURMK As String, ByVal FSWLRMK As String, ByVal FBTRMK As String, ByVal TXTDRM As Integer, ByVal TXTBRICK As Integer) As Boolean
            Dim Done As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            Try
                oCmd.Parameters.Add("@heat_number", SqlDbType.BigInt, 8).Value = heat_number
                oCmd.Parameters.Add("@furnace_code", SqlDbType.VarChar, 10).Value = furnace_code
                oCmd.Parameters.Add("@bottom", SqlDbType.VarChar, 50).Value = bottom
                oCmd.Parameters.Add("@furnace_life", SqlDbType.Int, 4).Value = furnace_life
                oCmd.Parameters.Add("@sidewall_up", SqlDbType.VarChar, 50).Value = sidewall_up
                oCmd.Parameters.Add("@sidewall_low", SqlDbType.VarChar, 50).Value = sidewall_low
                oCmd.Parameters.Add("@bank", SqlDbType.VarChar, 50).Value = bank
                oCmd.Parameters.Add("@shift_code", SqlDbType.VarChar, 1).Value = shift_code
                oCmd.Parameters.Add("@melt_date", SqlDbType.SmallDateTime, 4).Value = melt_date
                oCmd.Parameters.Add("@shift_incharge", SqlDbType.VarChar, 30).Value = shift_incharge
                oCmd.Parameters.Add("@FBRMK", SqlDbType.VarChar, 50).Value = FBRMK
                oCmd.Parameters.Add("@FSWURMK", SqlDbType.VarChar, 50).Value = FSWURMK
                oCmd.Parameters.Add("@FSWLRMK", SqlDbType.VarChar, 50).Value = FSWLRMK
                oCmd.Parameters.Add("@FBTRMK", SqlDbType.VarChar, 50).Value = FBTRMK
                oCmd.Parameters.Add("@TXTDRM", SqlDbType.Int, 4).Value = TXTDRM
                oCmd.Parameters.Add("@TXTBRICK", SqlDbType.Int, 4).Value = TXTBRICK
                oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                oCmd.CommandText = "select @cnt = count(*) FROM mm_furnace_condition WHERE heat_number = @heat_number "
                oCmd.ExecuteScalar()
                Done = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)
                If Done Then
                    Done = False
                    oCmd.CommandText = "update mm_furnace_condition set furnace_code = @furnace_code , melt_date = @melt_date , " &
                        " shift_code = @shift_code , shift_incharge = @shift_incharge , bottom = @bottom ," &
                        " furnace_life = @furnace_life , sidewall_up = @sidewall_up , sidewall_low = @sidewall_low , " &
                        " rmk_sidewall_up = @FSWURMK , rmk_sidewall_low = @FSWLRMK , rmk_bank = @FBTRMK , rmk_bottom = @FBRMK ," &
                        "DRM_life = @TXTDRM ,BRICK_life= @TXTBRICK ," &
                        " bank = @bank where heat_number = @heat_number "
                Else
                    oCmd.CommandText = "insert into mm_furnace_condition ( furnace_code , bottom , furnace_life , " &
                        " sidewall_up , sidewall_low , bank , heat_number , shift_code, melt_date , shift_incharge, " &
                        "rmk_sidewall_up, rmk_sidewall_low, rmk_bank, rmk_bottom ,DRM_life , Brick_life )" &
                        " values ( @furnace_code , @bottom , @furnace_life , " &
                        " @sidewall_up , @sidewall_low , @bank , @heat_number , @shift_code, @melt_date , @shift_incharge, " &
                        "@FSWURMK ,@FSWLRMK ,@FBTRMK ,@FBRMK ,@TXTDRM, @TXTBRICK)"
                End If
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
        Public Function SaveBucket(ByVal heat_number As Long, ByVal bucket_number As String, ByVal entered_by As String, ByVal bucket_number2 As String, ByVal entered_by2 As String, ByVal bucket_number3 As String, ByVal entered_by3 As String) As Boolean
            Dim Done As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            Try
                oCmd.Parameters.Add("@heat_number", SqlDbType.BigInt, 8).Value = heat_number
                oCmd.Parameters.Add("@bucket_number", SqlDbType.VarChar, 50).Value = bucket_number
                oCmd.Parameters.Add("@entered_by", SqlDbType.VarChar, 50).Value = entered_by
                oCmd.Parameters.Add("@bucket_number2", SqlDbType.VarChar, 50).Value = bucket_number2
                oCmd.Parameters.Add("@entered_by2", SqlDbType.VarChar, 50).Value = entered_by2
                oCmd.Parameters.Add("@bucket_number3", SqlDbType.VarChar, 50).Value = bucket_number3
                oCmd.Parameters.Add("@entered_by3", SqlDbType.VarChar, 50).Value = entered_by3
                oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                oCmd.CommandText = "select @cnt = count(*) FROM mm_heat_bucket WHERE heat_number = @heat_number "
                oCmd.ExecuteScalar()
                Done = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)
                If Done Then
                    Done = False
                    oCmd.CommandText = "update mm_heat_bucket set bucket_number = @bucket_number , entered_by = @entered_by , " &
                        " bucket_number2 = @bucket_number2 , entered_by2 = @entered_by2 , " &
                        " bucket_number3 = @bucket_number3 , entered_by3 = @entered_by3 where heat_number = @heat_number "
                Else
                    oCmd.CommandText = "insert into mm_heat_bucket ( heat_number ,  " &
                        " bucket_number , entered_by , bucket_number2 , entered_by2 , bucket_number3 , entered_by3  ) " &
                        " values ( @heat_number , @bucket_number , " &
                        " @entered_by , @bucket_number2 , @entered_by2 , @bucket_number3 , @entered_by3 ) "
                End If
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
        Public Function SaveHeatCharge(ByVal heat_number As Long, ByVal skull As Double, ByVal riser_hub As Double, ByVal cut_scrap As Double, ByVal hbi As Double, ByVal pygmy_pot As Double, ByVal wheel_cut As Double, ByVal lms As Double, ByVal slpr_cut As Double, ByVal hot_heal As Double, ByVal axle_cut As Double, ByVal tuning_boring As Double, ByVal wheel As Double, ByVal axle_end As Double, ByVal shredded_scrap As Double, ByVal nm_gunny_dust As Double, ByVal nm_calcium_lime As Double, ByVal Rail_Cut As Double, ByVal Remarks As String) As String
            Dim Done As Boolean
            Dim S As String = ""
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            Try
                oCmd.Parameters.Add("@heat_number", SqlDbType.BigInt, 8).Value = heat_number
                oCmd.Parameters.Add("@skull", SqlDbType.Float, 8).Value = skull
                oCmd.Parameters.Add("@riser_hub", SqlDbType.Float, 8).Value = riser_hub
                oCmd.Parameters.Add("@cut_scrap", SqlDbType.Float, 8).Value = cut_scrap
                oCmd.Parameters.Add("@hbi", SqlDbType.Float, 8).Value = hbi
                oCmd.Parameters.Add("@pygmy_pot", SqlDbType.Float, 8).Value = pygmy_pot
                oCmd.Parameters.Add("@wheel_cut", SqlDbType.Float, 8).Value = wheel_cut
                oCmd.Parameters.Add("@lms", SqlDbType.Float, 8).Value = lms
                oCmd.Parameters.Add("@slpr_cut", SqlDbType.Float, 8).Value = slpr_cut
                oCmd.Parameters.Add("@hot_heal", SqlDbType.Float, 8).Value = hot_heal
                oCmd.Parameters.Add("@axle_cut", SqlDbType.Float, 8).Value = axle_cut
                oCmd.Parameters.Add("@tuning_boring", SqlDbType.Float, 8).Value = tuning_boring
                oCmd.Parameters.Add("@wheel", SqlDbType.Float, 8).Value = wheel
                oCmd.Parameters.Add("@axle_end", SqlDbType.Float, 8).Value = axle_end
                oCmd.Parameters.Add("@shredded_scrap", SqlDbType.Float, 8).Value = shredded_scrap
                oCmd.Parameters.Add("@nm_gunny_dust", SqlDbType.Float, 8).Value = nm_gunny_dust
                oCmd.Parameters.Add("@nm_calcium_lime", SqlDbType.Float, 8).Value = nm_calcium_lime
                oCmd.Parameters.Add("@Rail_Cut", SqlDbType.Float, 8).Value = Rail_Cut
                oCmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 100).Value = Remarks
                oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                oCmd.CommandText = "select @cnt = count(*) FROM mm_heat_sheet_charge WHERE heat_number = @heat_number "
                oCmd.ExecuteScalar()
                Done = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)
                If Done Then
                    Done = False
                    oCmd.CommandText = "update mm_heat_sheet_charge set skull = @skull , " &
                        " riser_hub = @riser_hub , cut_scrap = @cut_scrap , hbi = @hbi , pygmy_pot = @pygmy_pot , " &
                        " wheel_cut = @wheel_cut , lms = @lms , slpr_cut = @slpr_cut , hot_heal = @hot_heal ,  " &
                        " axle_cut = @axle_cut , tuning_boring = @tuning_boring , wheel = @wheel , axle_end = @axle_end , " &
                        " shredded_scrap = @shredded_scrap , nm_gunny_dust = @nm_gunny_dust,  Remarks = @Remarks ," &
                        " nm_calcium_lime = @nm_calcium_lime , Rail_Cut = @Rail_Cut where heat_number = @heat_number "
                Else
                    oCmd.CommandText = "insert into mm_heat_sheet_charge ( heat_number ,  " &
                        " skull , riser_hub , cut_scrap , hbi,pygmy_pot , wheel_cut , lms , slpr_cut , hot_heal ,  " &
                        " axle_cut , tuning_boring , wheel , axle_end , shredded_scrap , nm_gunny_dust ,  " &
                        " nm_calcium_lime , Rail_Cut , Remarks )" &
                        " values ( @heat_number , @skull , @riser_hub , @cut_scrap , @hbi , @pygmy_pot , " &
                        " @wheel_cut , @lms , @slpr_cut , @hot_heal , @axle_cut , @tuning_boring , @wheel , " &
                        " @axle_end , @shredded_scrap , @nm_gunny_dust , @nm_calcium_lime , @Rail_Cut , @Remarks ) "
                End If
                If oCmd.ExecuteNonQuery > 0 Then Done = True
            Catch exp As Exception
                S = exp.Message
            Finally
                If Not IsNothing(oCmd) Then
                    If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                    oCmd.Dispose()
                    oCmd = Nothing
                End If
            End Try
            If S.Length > 0 Then
                Return S
            Else
                If Done Then
                    Return 1
                Else
                    Return 0
                End If
            End If
        End Function
        Public Function SaveFettling(ByVal heat_number As Long, ByVal ramming_mass_make As String, ByVal ramming_mass_quantity As Double, ByVal wet_ramming_mass_make As String, ByVal wet_ramming_mass_quantity As Double, ByVal gunning_mix_make As String, ByVal gunning_mix_quantity As Double)
            Dim Done As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            Try
                oCmd.Parameters.Add("@heat_number", SqlDbType.BigInt, 8).Value = heat_number
                oCmd.Parameters.Add("@ramming_mass_make", SqlDbType.VarChar, 50).Value = ramming_mass_make
                oCmd.Parameters.Add("@ramming_mass_quantity", SqlDbType.Float, 8).Value = ramming_mass_quantity
                oCmd.Parameters.Add("@wet_ramming_mass_make", SqlDbType.VarChar, 50).Value = wet_ramming_mass_make
                oCmd.Parameters.Add("@wet_ramming_mass_quantity", SqlDbType.Float, 8).Value = wet_ramming_mass_quantity
                oCmd.Parameters.Add("@gunning_mix_make", SqlDbType.VarChar, 50).Value = gunning_mix_make
                oCmd.Parameters.Add("@gunning_mix_quantity", SqlDbType.Float, 8).Value = gunning_mix_quantity
                oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                oCmd.CommandText = "select @cnt = count(*) FROM mm_fettling_details WHERE heat_number = @heat_number "
                oCmd.ExecuteScalar()
                Done = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)
                If Done Then
                    Done = False
                    oCmd.CommandText = "update mm_fettling_details set ramming_mass_make = @ramming_mass_make , " &
                       " ramming_mass_quantity = @ramming_mass_quantity , wet_ramming_mass_make = @wet_ramming_mass_make , " &
                       " wet_ramming_mass_quantity = @wet_ramming_mass_quantity , gunning_mix_make = @gunning_mix_make ,  " &
                       " gunning_mix_quantity = @gunning_mix_quantity where heat_number = @heat_number "
                Else
                    oCmd.CommandText = "insert into mm_fettling_details ( heat_number ,  " &
                        " ramming_mass_make , ramming_mass_quantity , wet_ramming_mass_make , " &
                        " wet_ramming_mass_quantity , gunning_mix_make , gunning_mix_quantity  ) " &
                        " values ( @heat_number , " &
                        " @ramming_mass_make , @ramming_mass_quantity , @wet_ramming_mass_make , " &
                        " @wet_ramming_mass_quantity , @gunning_mix_make , @gunning_mix_quantity  )"
                End If
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
        Public Function SaveElectrodeNew(ByVal heat_number As Long, ByVal eNo As String, ByVal Reason As String, ByVal Time As Date, ByVal Remarks As String, ByVal Location As String) As Boolean
            Dim Done As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            Try
                oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                oCmd.Parameters.Add("@heat_number", SqlDbType.BigInt, 8).Value = heat_number
                If eNo = "E1" Then
                    oCmd.Parameters.Add("@e1Reason", SqlDbType.VarChar, 50).Value = Reason
                    oCmd.Parameters.Add("@e1Time", SqlDbType.SmallDateTime, 4).Value = Time
                    oCmd.Parameters.Add("@e1remark", SqlDbType.VarChar, 250).Value = Remarks.Trim
                    oCmd.Parameters.Add("@Location1", SqlDbType.VarChar, 50).Value = Location.Trim
                End If
                If eNo = "E2" Then
                    oCmd.Parameters.Add("@e2Reason", SqlDbType.VarChar, 50).Value = Reason
                    oCmd.Parameters.Add("@e2Time", SqlDbType.SmallDateTime, 4).Value = Time
                    oCmd.Parameters.Add("@e2remark", SqlDbType.VarChar, 250).Value = Remarks.Trim
                    oCmd.Parameters.Add("@Location2", SqlDbType.VarChar, 50).Value = Location.Trim
                End If

                If eNo = "E3" Then
                    oCmd.Parameters.Add("@e3Reason", SqlDbType.VarChar, 50).Value = Reason
                    oCmd.Parameters.Add("@e3Time", SqlDbType.SmallDateTime, 4).Value = Time
                    oCmd.Parameters.Add("@e3remark", SqlDbType.VarChar, 250).Value = Remarks.Trim
                    oCmd.Parameters.Add("@Location3", SqlDbType.VarChar, 50).Value = Location.Trim
                End If

                oCmd.CommandText = "select @cnt = count(*) FROM mm_electrode where heat_number = @heat_number "
                oCmd.ExecuteScalar()
                Done = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)
                If eNo = "E1" Then
                    If Done Then
                        oCmd.CommandText = "update mm_electrode set e1Reason = @e1Reason , " &
                                 " e1Time = @e1Time ,  e1remark = @e1remark , Location1 = @Location1" &
                                 " where heat_number = @heat_number "
                    Else
                        oCmd.CommandText = "insert into mm_electrode " &
                            " ( heat_number ,  e1Reason , e1Time ,  e1remark , Location1 ) " &
                            " values ( @heat_number , @e1Reason , @e1Time ,  @e1remark , @Location2 )"
                    End If
                End If

                If eNo = "E2" Then
                    If Done Then
                        oCmd.CommandText = "update mm_electrode set e2Reason = @e2Reason , " &
                                 " e2Time = @e2Time ,  e2remark = @e2remark , Location2 = @Location2 " &
                                 " where heat_number = @heat_number "
                    Else
                        oCmd.CommandText = "insert into mm_electrode " &
                            " ( heat_number ,  e2Reason , e2Time ,  e2remark , Location2 ) " &
                            " values ( @heat_number , @e2Reason , @e2Time ,  @e2remark , @Location2 )"
                    End If
                End If

                If eNo = "E3" Then
                    If Done Then
                        oCmd.CommandText = "update mm_electrode set e3Reason = @e3Reason , " &
                                 " e3Time = @e3Time ,  e3remark = @e3remark , Location3 = @Location3 " &
                                 " where heat_number = @heat_number "
                    Else
                        oCmd.CommandText = "insert into mm_electrode " &
                            " ( heat_number ,  e3Reason , e3Time ,  e3remark , Location3 ) " &
                            " values ( @heat_number , @e3Reason , @e3Time ,  @e3remark , @Location3 )"
                    End If
                End If
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
        Public Function SaveElectrode(ByVal heat_number As Long, ByVal e1make As String, ByVal e1added As Double, ByVal e1tip_profile As String, ByVal e2make As String, ByVal e2added As Double, ByVal e2tip_profile As String, ByVal e3make As String, ByVal e3added As Double, ByVal e3tip_profile As String) As Boolean
            Dim Done As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            Try
                oCmd.Parameters.Add("@heat_number", SqlDbType.BigInt, 8).Value = heat_number
                oCmd.Parameters.Add("@e1make", SqlDbType.VarChar, 50).Value = e1make.Trim
                oCmd.Parameters.Add("@e1added", SqlDbType.Float, 8).Value = e1added
                'oCmd.Parameters.Add("@e1remark", SqlDbType.VarChar, 50).Value = e1remark
                oCmd.Parameters.Add("@e1tip_profile", SqlDbType.VarChar, 50).Value = e1tip_profile
                oCmd.Parameters.Add("@e2make", SqlDbType.VarChar, 50).Value = e2make.Trim
                oCmd.Parameters.Add("@e2added", SqlDbType.Float, 8).Value = e2added
                'oCmd.Parameters.Add("@e2remark", SqlDbType.VarChar, 50).Value = e2remark
                oCmd.Parameters.Add("@e2tip_profile", SqlDbType.VarChar, 50).Value = e2tip_profile
                oCmd.Parameters.Add("@e3make", SqlDbType.VarChar, 50).Value = e3make.Trim
                oCmd.Parameters.Add("@e3added", SqlDbType.Float, 8).Value = e3added
                'oCmd.Parameters.Add("@e3remark", SqlDbType.VarChar, 50).Value = e3remark
                ' e1remark = @e1remark , e2remark = @e2remark , e3remark = @e3remark ,
                'e1remark , e2remark , e3remark ,
                oCmd.Parameters.Add("@e3tip_profile", SqlDbType.VarChar, 50).Value = e3tip_profile

                oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                oCmd.CommandText = "select @cnt = count(*) FROM mm_electrode WHERE heat_number = @heat_number "
                oCmd.ExecuteScalar()
                Done = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)
                If Done Then
                    Done = False
                    oCmd.CommandText = "update mm_electrode set " &
                        " e1make = @e1make ,  e1added = @e1added ,  e1tip_profile = @e1tip_profile ,  " &
                        " e2make = @e2make ,  e2added = @e2added ,  e2tip_profile = @e2tip_profile , " &
                        " e3make = @e3make ,  e3added = @e3added ,  e3tip_profile = @e3tip_profile " &
                        " where heat_number = @heat_number "
                Else
                    oCmd.CommandText = "insert into mm_electrode ( heat_number ,  " &
                        " e1make , e1added ,  e1tip_profile , " &
                        " e2make , e2added ,  e2tip_profile , " &
                        " e3make , e3added ,  e3tip_profile ) " &
                        " values ( @heat_number , " &
                        " @e1make , @e1added ,  @e1tip_profile , " &
                        " @e2make , @e2added ,  @e2tip_profile , " &
                        " @e3make , @e3added ,  @e3tip_profile )"
                End If
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
        Public Function SaveNonMetailic(ByVal heat_number As Long, ByVal NCNL As Double, ByVal NGRD As Double, ByVal NLMS As Double) As Boolean
            Dim Done As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            Try
                oCmd.Parameters.Add("@heat_number", SqlDbType.BigInt, 8).Value = heat_number
                oCmd.Parameters.Add("@pl_number", SqlDbType.VarChar, 50).Direction = ParameterDirection.Input
                oCmd.Parameters.Add("@quantity", SqlDbType.Float, 8).Direction = ParameterDirection.Input

                oCmd.Parameters("@pl_number").Value = "NCNL"
                oCmd.Parameters("@quantity").Value = NCNL
                oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                oCmd.CommandText = "select @cnt = count(*) FROM mm_nonmetal_addition " &
                    " WHERE heat_number = @heat_number and pl_number = @pl_number "
                oCmd.ExecuteScalar()
                Done = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)
                If Done Then
                    Done = False
                    oCmd.CommandText = "update mm_nonmetal_addition set quantity = @quantity  " &
                        " where heat_number = @heat_number and pl_number = @pl_number "
                Else
                    oCmd.CommandText = "insert into mm_nonmetal_addition   " &
                        " ( heat_number , pl_number , quantity ) " &
                        " values ( @heat_number , @pl_number , @quantity )"
                End If
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                If oCmd.ExecuteNonQuery = 1 Then
                    Done = True
                Else
                    Exit Function
                End If
                oCmd.Parameters("@pl_number").Value = "NGRD"
                oCmd.Parameters("@quantity").Value = NGRD
                oCmd.CommandText = "select @cnt = count(*) FROM mm_nonmetal_addition " &
                    " WHERE heat_number = @heat_number and pl_number = @pl_number "
                oCmd.ExecuteScalar()
                Done = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)

                If Done Then
                    Done = False
                    oCmd.CommandText = "update mm_nonmetal_addition set quantity = @quantity  " &
                        " where heat_number = @heat_number and pl_number = @pl_number "
                Else
                    oCmd.CommandText = "insert into mm_nonmetal_addition   " &
                        " ( heat_number , pl_number , quantity ) " &
                        " values ( @heat_number , @pl_number , @quantity )"
                End If
                If oCmd.ExecuteNonQuery = 1 Then
                    Done = True
                Else
                    Exit Function
                End If
                oCmd.Parameters("@pl_number").Value = "NLMS"
                oCmd.Parameters("@quantity").Value = NLMS
                oCmd.CommandText = "select @cnt = count(*) FROM mm_nonmetal_addition " &
                    " WHERE heat_number = @heat_number and pl_number = @pl_number "
                oCmd.ExecuteScalar()
                Done = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)

                If Done Then
                    Done = False
                    oCmd.CommandText = "update mm_nonmetal_addition set quantity = @quantity  " &
                        " where heat_number = @heat_number and pl_number = @pl_number "
                Else
                    oCmd.CommandText = "insert into mm_nonmetal_addition   " &
                        " ( heat_number , pl_number , quantity ) " &
                        " values ( @heat_number , @pl_number , @quantity )"
                End If
                If oCmd.ExecuteNonQuery = 1 Then
                    Done = True
                Else
                    Exit Function
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
        'Public Function SaveHeatLog(ByVal heat_number As Long, ByVal furnace_inspection As DateTime, ByVal roof_outtime As DateTime, ByVal charge_start As DateTime, ByVal charge_end As DateTime, ByVal removed_material As DateTime, ByVal levelling As DateTime, ByVal roof_in As DateTime, ByVal back_charge_metal As DateTime, ByVal bucket_charge As DateTime, ByVal charge_met As DateTime, ByVal t6_power As DateTime, ByVal t2_power As DateTime) ', ByVal t4_power As DateTime, ByVal t8_power As DateTime, ByVal t10_power As DateTime, ByVal t12_power As DateTime) As Boolean
        '    Dim Done As Boolean
        '    Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        '    If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
        '    Try
        '        oCmd.Parameters.Add("@heat_number", SqlDbType.BigInt, 8).Value = heat_number
        '        oCmd.Parameters.Add("@furnace_inspection", SqlDbType.DateTime, 8).Value = furnace_inspection
        '        oCmd.Parameters.Add("@roof_outtime", SqlDbType.DateTime, 8).Value = roof_outtime
        '        oCmd.Parameters.Add("@charge_start", SqlDbType.DateTime, 8).Value = charge_start
        '        oCmd.Parameters.Add("@charge_end", SqlDbType.DateTime, 8).Value = charge_end
        '        oCmd.Parameters.Add("@removed_material", SqlDbType.DateTime, 8).Value = removed_material
        '        oCmd.Parameters.Add("@levelling", SqlDbType.DateTime, 8).Value = levelling
        '        oCmd.Parameters.Add("@roof_in", SqlDbType.DateTime, 8).Value = roof_in
        '        oCmd.Parameters.Add("@back_charge_metal", SqlDbType.DateTime, 8).Value = back_charge_metal
        '        oCmd.Parameters.Add("@bucket_charge", SqlDbType.DateTime, 8).Value = bucket_charge
        '        oCmd.Parameters.Add("@charge_met", SqlDbType.DateTime, 8).Value = charge_met
        '        oCmd.Parameters.Add("@t6_power", SqlDbType.DateTime, 8).Value = t6_power
        '        oCmd.Parameters.Add("@t2_power", SqlDbType.DateTime, 8).Value = t2_power
        '        'oCmd.Parameters.Add("@t4_power", SqlDbType.DateTime, 8).Value = t4_power
        '        'oCmd.Parameters.Add("@t8_power", SqlDbType.DateTime, 8).Value = t8_power
        '        'oCmd.Parameters.Add("@t10_power", SqlDbType.DateTime, 8).Value = t10_power
        '        'oCmd.Parameters.Add("@t12_power", SqlDbType.DateTime, 8).Value = t12_power
        '        oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
        '        oCmd.CommandText = "select @cnt = count(*) FROM mm_heat_sheet_melting " &
        '            " WHERE heat_number = @heat_number "
        '        oCmd.ExecuteScalar()
        '        Done = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)
        '        If Done Then
        '            Done = False
        '            oCmd.CommandText = "update mm_heat_sheet_melting set furnace_inspection = @furnace_inspection , " &
        '                " roof_outtime = @roof_outtime , charge_start = @charge_start , charge_end = @charge_end , " &
        '                " removed_material = @removed_material , levelling = @levelling , roof_in = @roof_in , " &
        '                " back_charge_metal = @back_charge_metal , bucket_charge = @bucket_charge , " &
        '                " charge_met = @charge_met , t6_power = @t6_power , t2_power = @t2_power " &
        '                " where heat_number = @heat_number "
        '        Else
        '            oCmd.CommandText = "insert into mm_heat_sheet_melting   " &
        '                " ( heat_number , furnace_inspection , roof_outtime , charge_start , charge_end , " &
        '                " removed_material , levelling , roof_in , back_charge_metal , bucket_charge , " &
        '                " charge_met , t6_power , t2_power ) " &
        '                " values ( @heat_number , @furnace_inspection , @roof_outtime , @charge_start , @charge_end , " &
        '                " @removed_material , @levelling , @roof_in , @back_charge_metal , @bucket_charge , " &
        '                " @charge_met , @t6_power , @t2_power ) "
        '        End If
        '        oCmd.Transaction = oCmd.Connection.BeginTransaction
        '        If oCmd.ExecuteNonQuery = 1 Then
        '            Done = True
        '        Else
        '            Exit Function
        '        End If
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
        '            oCmd = Nothing
        '        End If
        '    End Try
        '    Return Done
        'End Function
        Public Function SaveHeatLog(ByVal heat_number As Long, ByVal furnace_inspection As DateTime, ByVal roof_outtime As DateTime, ByVal charge_start As DateTime, ByVal charge_end As DateTime, ByVal removed_material As DateTime, ByVal levelling As DateTime, ByVal roof_in As DateTime, ByVal back_charge_metal As DateTime, ByVal bucket_charge As DateTime, ByVal charge_met As DateTime, ByVal t101_power As DateTime, ByVal PowerOn As String) As Boolean
            Dim Done As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            Try
                oCmd.Parameters.Add("@heat_number", SqlDbType.BigInt, 8).Value = heat_number
                oCmd.Parameters.Add("@furnace_inspection", SqlDbType.DateTime, 8).Value = furnace_inspection
                oCmd.Parameters.Add("@roof_outtime", SqlDbType.DateTime, 8).Value = roof_outtime
                oCmd.Parameters.Add("@charge_start", SqlDbType.DateTime, 8).Value = charge_start
                oCmd.Parameters.Add("@charge_end", SqlDbType.DateTime, 8).Value = charge_end
                oCmd.Parameters.Add("@removed_material", SqlDbType.DateTime, 8).Value = removed_material
                oCmd.Parameters.Add("@levelling", SqlDbType.DateTime, 8).Value = levelling
                oCmd.Parameters.Add("@roof_in", SqlDbType.DateTime, 8).Value = roof_in
                oCmd.Parameters.Add("@back_charge_metal", SqlDbType.DateTime, 8).Value = back_charge_metal
                oCmd.Parameters.Add("@bucket_charge", SqlDbType.DateTime, 8).Value = bucket_charge
                oCmd.Parameters.Add("@charge_met", SqlDbType.DateTime, 8).Value = charge_met
                'oCmd.Parameters.Add("@t6_power", SqlDbType.DateTime, 8).Value = t6_power
                oCmd.Parameters.Add("@t101_power", SqlDbType.DateTime, 8).Value = t101_power
                'oCmd.Parameters.Add("@t4_power", SqlDbType.DateTime, 8).Value = t4_power
                'oCmd.Parameters.Add("@t8_power", SqlDbType.DateTime, 8).Value = t8_power
                'oCmd.Parameters.Add("@t102_power", SqlDbType.DateTime, 8).Value = t102_power
                'oCmd.Parameters.Add("@t12_power", SqlDbType.DateTime, 8).Value = t12_power
                oCmd.Parameters.Add("@PowerOn", SqlDbType.VarChar, 15).Value = PowerOn
                oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                oCmd.CommandText = "select @cnt = count(*) FROM mm_heat_sheet_melting " &
                    " WHERE heat_number = @heat_number "
                oCmd.ExecuteScalar()
                Done = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)
                If Done Then
                    Done = False
                    oCmd.CommandText = "update mm_heat_sheet_melting set furnace_inspection = @furnace_inspection , " &
                     " roof_outtime = @roof_outtime , charge_start = @charge_start , charge_end = @charge_end , " &
                     " removed_material = @removed_material , levelling = @levelling , roof_in = @roof_in , " &
                     " back_charge_metal = @back_charge_metal , bucket_charge = @bucket_charge , " &
                     " charge_met = @charge_met , t2_power = @t101_power,PowerOn=@PowerOn " &
                      " where heat_number = @heat_number "
                    'oCmd.CommandText = "update mm_heat_sheet_melting set furnace_inspection = @furnace_inspection , " &
                    '    " roof_outtime = @roof_outtime , charge_start = @charge_start , charge_end = @charge_end , " &
                    '    " removed_material = @removed_material , levelling = @levelling , roof_in = @roof_in , " &
                    '    " back_charge_metal = @back_charge_metal , bucket_charge = @bucket_charge , " &
                    '    " charge_met = @charge_met , t6_power = @t6_power , t2_power = @t101_power ," &
                    '    "t4_power = @t4_power , t8_power = @t8_power ,t10_power = @t102_power , t12_power = @t12_power " &
                    '    " where heat_number = @heat_number "
                Else
                    oCmd.CommandText = "insert into mm_heat_sheet_melting   " &
                        " ( heat_number , furnace_inspection , roof_outtime , charge_start , charge_end , " &
                        " removed_material , levelling , roof_in , back_charge_metal , bucket_charge , " &
                        " charge_met , t2_power,PowerOn ) " &
                        " values ( @heat_number , @furnace_inspection , @roof_outtime , @charge_start , @charge_end , " &
                        " @removed_material , @levelling , @roof_in , @back_charge_metal , @bucket_charge , " &
                        " @charge_met , @t101_power,@PowerOn  ) "
                End If
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                If oCmd.ExecuteNonQuery = 1 Then
                    Done = True
                Else
                    Exit Function
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
        Public Function SaveInProcessAdditives(ByVal heat_number As Long, ByVal furnace_si_mn As Double, ByVal furnace_fe_si As Double, ByVal furnace_fe_mn As Double, ByVal furnace_floor_spar As Double, ByVal furnace_limestone As Double, ByVal ladle_si_mn As Double, ByVal ladle_fe_si As Double, ByVal ladle_fe_mn As Double, ByVal ladle_floor_spar As Double, ByVal ladle_limestone As Double, ByVal furnace_gunningdust As Double, ByVal ladle_gunningdust As Double, ByVal furnace_calcium_lime As Double, ByVal rsm_dept As Double, ByVal rsm_contract As Double, ByVal ContractNo As String) As Boolean
            Dim Done As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            Try
                oCmd.Parameters.Add("@heat_number", SqlDbType.BigInt, 8).Value = heat_number
                oCmd.Parameters.Add("@furnace_si_mn", SqlDbType.Float, 8).Value = furnace_si_mn
                oCmd.Parameters.Add("@furnace_fe_si", SqlDbType.Float, 8).Value = furnace_fe_si
                oCmd.Parameters.Add("@furnace_fe_mn", SqlDbType.Float, 8).Value = furnace_fe_mn
                oCmd.Parameters.Add("@furnace_floor_spar", SqlDbType.Float, 8).Value = furnace_floor_spar
                oCmd.Parameters.Add("@furnace_limestone", SqlDbType.Float, 8).Value = furnace_limestone
                oCmd.Parameters.Add("@ladle_si_mn", SqlDbType.Float, 8).Value = ladle_si_mn
                oCmd.Parameters.Add("@ladle_fe_si", SqlDbType.Float, 8).Value = ladle_fe_si
                oCmd.Parameters.Add("@ladle_fe_mn", SqlDbType.Float, 8).Value = ladle_fe_mn
                oCmd.Parameters.Add("@ladle_floor_spar", SqlDbType.Float, 8).Value = ladle_floor_spar
                oCmd.Parameters.Add("@ladle_limestone", SqlDbType.Float, 8).Value = ladle_limestone
                oCmd.Parameters.Add("@furnace_gunningdust", SqlDbType.Float, 8).Value = furnace_gunningdust
                oCmd.Parameters.Add("@ladle_gunningdust", SqlDbType.Float, 8).Value = ladle_gunningdust
                oCmd.Parameters.Add("@furnace_calcium_lime", SqlDbType.Float, 8).Value = furnace_calcium_lime
                oCmd.Parameters.Add("@rsm_dept", SqlDbType.Float, 8).Value = rsm_dept
                oCmd.Parameters.Add("@rsm_contract", SqlDbType.Float, 8).Value = rsm_contract
                oCmd.Parameters.Add("@ContractNo", SqlDbType.VarChar, 50).Value = ContractNo

                oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                oCmd.CommandText = "select @cnt = count(*) FROM mm_inprocess_additives " &
                    " WHERE heat_number = @heat_number "
                oCmd.ExecuteScalar()
                Done = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)
                If Done Then
                    Done = False
                    oCmd.CommandText = "update mm_inprocess_additives " &
                        " set furnace_si_mn = @furnace_si_mn , furnace_fe_si = @furnace_fe_si ," &
                        " furnace_fe_mn = @furnace_fe_mn , furnace_floor_spar = @furnace_floor_spar , " &
                        " furnace_limestone = @furnace_limestone , ContractNo = @ContractNo , " &
                        " ladle_si_mn = @ladle_si_mn , ladle_fe_si = @ladle_fe_si , " &
                        " ladle_fe_mn = @ladle_fe_mn , ladle_floor_spar = @ladle_floor_spar , " &
                        " ladle_limestone = @ladle_limestone , furnace_gunningdust = @furnace_gunningdust , " &
                        " ladle_gunningdust = @ladle_gunningdust ,  furnace_calcium_lime = @furnace_calcium_lime , " &
                        " rsm_dept = @rsm_dept , rsm_contract = @rsm_contract where heat_number = @heat_number "
                Else
                    oCmd.CommandText = "insert into mm_inprocess_additives   " &
                        " ( heat_number , furnace_si_mn , furnace_fe_si , furnace_fe_mn , furnace_floor_spar , " &
                        " furnace_limestone , ladle_si_mn , ladle_fe_si , ladle_fe_mn , ladle_floor_spar , " &
                        " ladle_limestone , furnace_gunningdust , ladle_gunningdust , furnace_calcium_lime , " &
                        " rsm_dept , rsm_contract , ContractNo ) " &
                        " values ( @heat_number , @furnace_si_mn , @furnace_fe_si , @furnace_fe_mn , @furnace_floor_spar , " &
                        " @furnace_limestone , @ladle_si_mn , @ladle_fe_si , @ladle_fe_mn , @ladle_floor_spar , " &
                        " @ladle_limestone , @furnace_gunningdust , @ladle_gunningdust , @furnace_calcium_lime , " &
                        " @rsm_dept , @rsm_contract , @ContractNo ) "
                End If
                If oCmd.ExecuteNonQuery = 1 Then Done = True
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
        Public Function SaveSpectro(ByVal heat_number As Long, ByVal sample_number As String, ByVal sample_temperature As Double, ByVal sample_taken_time As String, ByVal ni_ni As Decimal, ByVal car_car As Decimal, ByVal man_man As Decimal, ByVal sil_sil As Decimal, ByVal pho_pho As Decimal, ByVal sul_sul As Decimal, ByVal chr_chr As Decimal, ByVal cop_cop As Decimal, ByVal alu_alu As Decimal, ByVal Ven_Ven As Decimal, ByVal moly_moly As Decimal, ByVal nitro_nitro As Decimal, ByVal hydro_hydro As Decimal) As Boolean
            Dim Done As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            Try
                oCmd.Parameters.Add("@heat_number", SqlDbType.BigInt, 8).Value = heat_number
                oCmd.Parameters.Add("@sample_number", SqlDbType.VarChar, 10).Value = sample_number
                oCmd.Parameters.Add("@sample_taken_time", SqlDbType.VarChar, 10).Value = sample_taken_time
                oCmd.Parameters.Add("@ni_ni", SqlDbType.Float, 8).Value = ni_ni
                oCmd.Parameters.Add("@sample_temperature", SqlDbType.Float, 8).Value = sample_temperature
                oCmd.Parameters.Add("@car_car", SqlDbType.Float, 8).Value = car_car
                oCmd.Parameters.Add("@man_man", SqlDbType.Float, 8).Value = man_man
                oCmd.Parameters.Add("@sil_sil", SqlDbType.Float, 8).Value = sil_sil
                oCmd.Parameters.Add("@pho_pho", SqlDbType.Float, 8).Value = pho_pho
                oCmd.Parameters.Add("@sul_sul", SqlDbType.Float, 8).Value = sul_sul
                oCmd.Parameters.Add("@chr_chr", SqlDbType.Float, 8).Value = chr_chr
                oCmd.Parameters.Add("@cop_cop", SqlDbType.Float, 8).Value = cop_cop
                oCmd.Parameters.Add("@alu_alu", SqlDbType.Float, 8).Value = alu_alu
                oCmd.Parameters.Add("@Ven_Ven", SqlDbType.Float, 8).Value = Ven_Ven
                oCmd.Parameters.Add("@moly_moly", SqlDbType.Float, 8).Value = moly_moly
                oCmd.Parameters.Add("@nitro_nitro", SqlDbType.Float, 8).Value = nitro_nitro
                oCmd.Parameters.Add("@hydro_hydro", SqlDbType.Float, 8).Value = hydro_hydro

                oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                oCmd.CommandText = "select @cnt = count(*) FROM mm_spectro_results " &
                    " WHERE heat_number = @heat_number and sample_number = @sample_number "
                oCmd.ExecuteScalar()
                Done = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)
                If Done Then
                    Done = False
                    oCmd.CommandText = "update mm_spectro_results " &
                        " set sample_temperature = @sample_temperature , sample_taken_time = @sample_taken_time ," &
                        " ni_ni = @ni_ni , car_car = @car_car , sil_sil = @sil_sil ," &
                        " man_man = @man_man , pho_pho = @pho_pho , sul_sul = @sul_sul , chr_chr = @chr_chr , " &
                        " cop_cop = @cop_cop , alu_alu = @alu_alu , Ven_Ven = @Ven_Ven , moly_moly = @moly_moly , " &
                        " nitro_nitro = @nitro_nitro ,  hydro_hydro = @hydro_hydro  " &
                        " where heat_number = @heat_number and sample_number = @sample_number "
                Else
                    oCmd.CommandText = "insert into mm_spectro_results   " &
                        " ( heat_number , sample_number , sample_temperature , sample_taken_time , " &
                        " ni_ni , car_car , man_man , sil_sil , pho_pho , sul_sul , chr_chr , " &
                        " cop_cop , alu_alu , Ven_Ven , moly_moly , nitro_nitro , hydro_hydro ) " &
                        " values ( @heat_number , @sample_number , @sample_temperature , @sample_taken_time , " &
                        " @ni_ni , @car_car , @man_man , @sil_sil , @pho_pho , @sul_sul , @chr_chr , " &
                        " @cop_cop , @alu_alu , @Ven_Ven , @moly_moly , @nitro_nitro , @hydro_hydro ) "
                End If
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
        Public Function SaveDelay(ByVal heat_number As Long, ByVal fromtime As String, ByVal totime As String, ByVal remarks As String, ByVal delay_code As String) As Boolean
            Dim Done As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            Try
                oCmd.Parameters.Add("@heat_number", SqlDbType.BigInt, 8).Value = heat_number
                oCmd.Parameters.Add("@fromtime", SqlDbType.VarChar, 50).Value = fromtime
                oCmd.Parameters.Add("@totime", SqlDbType.VarChar, 50).Value = totime
                oCmd.Parameters.Add("@remarks", SqlDbType.VarChar, 50).Value = remarks
                oCmd.Parameters.Add("@delay_code", SqlDbType.VarChar, 50).Value = delay_code

                oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                oCmd.CommandText = "select @cnt = count(*) FROM mm_process_delay " &
                    " WHERE heat_number = @heat_number and delay_code = @delay_code "
                oCmd.ExecuteScalar()
                Done = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)
                If Done Then
                    Done = False
                    oCmd.CommandText = "update mm_process_delay " &
                        " set fromtime = @fromtime , totime = @totime ," &
                        " remarks = @remarks where heat_number = @heat_number and delay_code = @delay_code  "
                Else
                    oCmd.CommandText = "insert into mm_process_delay   " &
                        " ( heat_number , delay_code , fromtime , totime , remarks ) " &
                        " values ( @heat_number , @delay_code , @fromtime , @totime , @remarks ) "
                End If
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                If oCmd.ExecuteNonQuery = 1 Then
                    Done = True
                Else
                    Exit Function
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
        Public Function SaveOffHeat(ByVal heat_number As Long) As Boolean
            Dim Done As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            Try
                oCmd.Parameters.Add("@heat_number", SqlDbType.BigInt, 8).Value = heat_number
                oCmd.CommandText = "mm_sp_offheat"
                oCmd.CommandType = CommandType.StoredProcedure
                If oCmd.ExecuteNonQuery > 0 Then
                    Done = True
                Else
                    Throw New Exception("Heat not saved as offheat !")
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
            Return Done
        End Function
        Public Function SavePostMelt(ByVal heat_number As Long, ByVal heat_status As String, ByVal tap_drain As String, ByVal graphite_dust_make As String, ByVal tip_make As String, ByVal lpipe_make As String, ByVal tip_quantity As Double, ByVal lpipe_quantity As Double, ByVal electrode_dip_time As String, ByVal fettling_info As String, ByVal tap_temperature As Double, ByVal tap_begin As Double, ByVal tap_end As Double, ByVal tap_time As Double, ByVal sos_temperature As Double, ByVal jmp_st_temperature As Double, ByVal slag_condition As String, ByVal lm_level As String, ByVal sos_aluminium_star As String, ByVal jmp_aluminium_star As String, ByVal lm_level_final As String, ByVal process_delay As String, ByVal hea_rem As String, ByVal heat_tapped As Date, ByVal DDLLOF As String, ByVal DDLSOS As String) As Boolean
            Dim Done As Boolean
            If heat_status = "0" Then
                Dim oCmdOff As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
                If oCmdOff.Connection.State = ConnectionState.Closed Then oCmdOff.Connection.Open()
                oCmdOff.Transaction = oCmdOff.Connection.BeginTransaction
                Try
                    oCmdOff.Parameters.Add("@heat_number", SqlDbType.BigInt, 8).Value = heat_number
                    oCmdOff.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                    oCmdOff.CommandText = "select @cnt = count(*) FROM mm_offheat_post_melt " &
                        " WHERE heat_number = @heat_number "
                    oCmdOff.CommandType = CommandType.Text
                    oCmdOff.ExecuteScalar()
                    If IIf(IsDBNull(oCmdOff.Parameters("@cnt").Value), 0, oCmdOff.Parameters("@cnt").Value) Then
                        Throw New Exception("Heat already made OffHeat !")
                        Exit Function
                    End If
                    SaveOffHeat(heat_number)
                    oCmdOff.CommandText = "select @cnt = count(*) FROM mm_offheat_post_melt " &
                    " WHERE heat_number = @heat_number "
                    oCmdOff.CommandType = CommandType.Text
                    oCmdOff.ExecuteScalar()
                    Done = IIf(IsDBNull(oCmdOff.Parameters("@cnt").Value), 0, oCmdOff.Parameters("@cnt").Value)
                    oCmdOff.Parameters.Add("@heat_status", SqlDbType.VarChar, 50).Value = heat_status
                    oCmdOff.Parameters.Add("@tap_drain", SqlDbType.VarChar, 50).Value = tap_drain
                    oCmdOff.Parameters.Add("@graphite_dust_make", SqlDbType.VarChar, 50).Value = graphite_dust_make
                    oCmdOff.Parameters.Add("@tip_make", SqlDbType.VarChar, 50).Value = tip_make
                    oCmdOff.Parameters.Add("@lpipe_make", SqlDbType.VarChar, 50).Value = lpipe_make
                    oCmdOff.Parameters.Add("@fettling_info", SqlDbType.VarChar, 50).Value = fettling_info
                    oCmdOff.Parameters.Add("@slag_condition", SqlDbType.VarChar, 100).Value = slag_condition
                    oCmdOff.Parameters.Add("@lm_level", SqlDbType.VarChar, 50).Value = lm_level
                    oCmdOff.Parameters.Add("@sos_aluminium_star", SqlDbType.VarChar, 50).Value = sos_aluminium_star
                    oCmdOff.Parameters.Add("@jmp_aluminium_star", SqlDbType.VarChar, 50).Value = jmp_aluminium_star
                    oCmdOff.Parameters.Add("@lm_level_final", SqlDbType.VarChar, 50).Value = lm_level_final
                    oCmdOff.Parameters.Add("@process_delay", SqlDbType.VarChar, 50).Value = process_delay
                    oCmdOff.Parameters.Add("@electrode_dip_time", SqlDbType.VarChar, 50).Value = electrode_dip_time
                    oCmdOff.Parameters.Add("@sos_temperature", SqlDbType.Float, 8).Value = sos_temperature
                    oCmdOff.Parameters.Add("@jmp_st_temperature", SqlDbType.Float, 8).Value = jmp_st_temperature
                    oCmdOff.Parameters.Add("@tip_quantity", SqlDbType.Float, 8).Value = tip_quantity
                    oCmdOff.Parameters.Add("@lpipe_quantity", SqlDbType.Float, 8).Value = lpipe_quantity
                    oCmdOff.Parameters.Add("@tap_temperature", SqlDbType.Float, 8).Value = tap_temperature
                    oCmdOff.Parameters.Add("@tap_begin", SqlDbType.Float, 8).Value = tap_begin
                    oCmdOff.Parameters.Add("@tap_end", SqlDbType.Float, 8).Value = tap_end
                    oCmdOff.Parameters.Add("@tap_time", SqlDbType.Float, 8).Value = tap_time
                    oCmdOff.Parameters.Add("@hea_rem", SqlDbType.VarChar, 5000).Value = hea_rem
                    oCmdOff.Parameters.Add("@heat_tapped", SqlDbType.DateTime, 8).Value = heat_tapped
                    oCmdOff.Parameters.Add("@DDLLOF", SqlDbType.VarChar, 50).Value = DDLLOF
                    oCmdOff.Parameters.Add("@DDLSOS", SqlDbType.VarChar, 50).Value = DDLSOS
                    If Done Then
                        oCmdOff.CommandText = "update mm_offheat_post_melt set heat_status = @heat_status , " &
                            " tap_drain = @tap_drain , graphite_dust_make = @graphite_dust_make , tip_make = @tip_make , " &
                            " lpipe_make = @lpipe_make , tip_quantity = @tip_quantity , lpipe_quantity = @lpipe_quantity , " &
                            " electrode_dip_time = @electrode_dip_time , fettling_info = @fettling_info , " &
                            " tap_temperature = @tap_temperature , tap_begin = @tap_begin , tap_end = @tap_end , " &
                            " tap_time = @tap_time , sos_temperature = @sos_temperature , " &
                            " jmp_st_temperature = @jmp_st_temperature , slag_condition = @slag_condition , " &
                            " lm_level = @lm_level , sos_aluminium_star = @sos_aluminium_star , " &
                            " jmp_aluminium_star = @jmp_aluminium_star , lm_level_final = @lm_level_final , " &
                            " process_delay = @process_delay , hea_rem = @hea_rem , heat_tapped = @heat_tapped , " &
                            " LOF = @DDLLOF, SOS = @DDLSOS where heat_number = @heat_number "
                    Else
                        oCmdOff.CommandText = "insert into mm_offheat_post_melt   " &
                            " ( heat_number , heat_status , tap_drain , graphite_dust_make ,  tip_make , lpipe_make , tip_quantity , " &
                            " lpipe_quantity , electrode_dip_time , fettling_info , tap_temperature , tap_begin , tap_end , tap_time , " &
                            " sos_temperature , jmp_st_temperature , slag_condition , lm_level , sos_aluminium_star , " &
                            " jmp_aluminium_star , lm_level_final , process_delay , hea_rem , LOF, SOS) " &
                            " values ( @heat_number , @heat_status , @tap_drain , @graphite_dust_make , " &
                            " @tip_make , @lpipe_make , @tip_quantity , " &
                            " @lpipe_quantity , @electrode_dip_time , @fettling_info ,  " &
                            " @tap_temperature , @tap_begin , @tap_end , @tap_time , " &
                            " @sos_temperature , @jmp_st_temperature , @slag_condition , @lm_level , @sos_aluminium_star , " &
                            " @jmp_aluminium_star , @lm_level_final , @process_delay , @hea_rem , @DDLLOF  ,@DDLSOS ) "
                    End If
                    If oCmdOff.ExecuteNonQuery() = 1 Then Done = True
                Catch exp As Exception
                    Throw New Exception(exp.Message)
                Finally
                    If Not IsNothing(oCmdOff) Then
                        If Done Then
                            oCmdOff.Transaction.Commit()
                        Else
                            oCmdOff.Transaction.Rollback()
                        End If
                        If oCmdOff.Connection.State = ConnectionState.Open Then oCmdOff.Connection.Close()
                        oCmdOff.Dispose()
                        oCmdOff = Nothing
                    End If
                End Try
            Else
                Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                Try
                    oCmd.Parameters.Add("@heat_number", SqlDbType.BigInt, 8).Value = heat_number
                    oCmd.Parameters.Add("@heat_status", SqlDbType.VarChar, 50).Value = heat_status
                    oCmd.Parameters.Add("@tap_drain", SqlDbType.VarChar, 50).Value = tap_drain
                    oCmd.Parameters.Add("@graphite_dust_make", SqlDbType.VarChar, 50).Value = graphite_dust_make
                    oCmd.Parameters.Add("@tip_make", SqlDbType.VarChar, 50).Value = tip_make
                    oCmd.Parameters.Add("@lpipe_make", SqlDbType.VarChar, 50).Value = lpipe_make
                    oCmd.Parameters.Add("@fettling_info", SqlDbType.VarChar, 50).Value = fettling_info
                    oCmd.Parameters.Add("@slag_condition", SqlDbType.VarChar, 100).Value = slag_condition
                    oCmd.Parameters.Add("@lm_level", SqlDbType.VarChar, 50).Value = lm_level
                    oCmd.Parameters.Add("@sos_aluminium_star", SqlDbType.VarChar, 50).Value = sos_aluminium_star
                    oCmd.Parameters.Add("@jmp_aluminium_star", SqlDbType.VarChar, 50).Value = jmp_aluminium_star
                    oCmd.Parameters.Add("@lm_level_final", SqlDbType.VarChar, 50).Value = lm_level_final
                    oCmd.Parameters.Add("@process_delay", SqlDbType.VarChar, 50).Value = process_delay
                    oCmd.Parameters.Add("@electrode_dip_time", SqlDbType.VarChar, 50).Value = electrode_dip_time
                    oCmd.Parameters.Add("@sos_temperature", SqlDbType.Float, 8).Value = sos_temperature
                    oCmd.Parameters.Add("@jmp_st_temperature", SqlDbType.Float, 8).Value = jmp_st_temperature
                    oCmd.Parameters.Add("@tip_quantity", SqlDbType.Float, 8).Value = tip_quantity
                    oCmd.Parameters.Add("@lpipe_quantity", SqlDbType.Float, 8).Value = lpipe_quantity
                    oCmd.Parameters.Add("@tap_temperature", SqlDbType.Float, 8).Value = tap_temperature
                    oCmd.Parameters.Add("@tap_begin", SqlDbType.Float, 8).Value = tap_begin
                    oCmd.Parameters.Add("@tap_end", SqlDbType.Float, 8).Value = tap_end
                    oCmd.Parameters.Add("@tap_time", SqlDbType.Float, 8).Value = tap_time
                    oCmd.Parameters.Add("@hea_rem", SqlDbType.VarChar, 5000).Value = hea_rem
                    oCmd.Parameters.Add("@heat_tapped", SqlDbType.DateTime, 8).Value = heat_tapped
                    oCmd.Parameters.Add("@DDLLOF", SqlDbType.VarChar, 50).Value = DDLLOF
                    oCmd.Parameters.Add("@DDLSOS", SqlDbType.VarChar, 50).Value = DDLSOS
                    oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                    oCmd.Transaction = oCmd.Connection.BeginTransaction
                    oCmd.CommandText = "select @cnt = count(*) FROM mm_post_melt " &
                            " WHERE heat_number = @heat_number "
                    oCmd.ExecuteScalar()
                    Done = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)
                    If Done Then
                        Done = False
                        oCmd.CommandText = "update mm_post_melt " &
                            " set heat_status = @heat_status , tap_drain = @tap_drain ," &
                            " graphite_dust_make = @graphite_dust_make , " &
                            " tip_make = @tip_make , lpipe_make = @lpipe_make , tip_quantity = @tip_quantity , " &
                            " lpipe_quantity = @lpipe_quantity , electrode_dip_time = @electrode_dip_time , fettling_info = @fettling_info ," &
                            " tap_temperature  = @tap_temperature , " &
                            " tap_begin = @tap_begin , tap_end = @tap_end , tap_time = @tap_time , " &
                            " sos_temperature = @sos_temperature , jmp_st_temperature = @jmp_st_temperature , " &
                            " slag_condition = @slag_condition , lm_level = @lm_level , " &
                            " sos_aluminium_star = @sos_aluminium_star , jmp_aluminium_star = @jmp_aluminium_star , " &
                            " lm_level_final = @lm_level_final , process_delay  = @process_delay , " &
                            " hea_rem = @hea_rem , heat_tapped = @heat_tapped ," &
                            " LOF = @DDLLOF, SOS = @DDLSOS where heat_number = @heat_number "
                    Else
                        oCmd.CommandText = "insert into mm_post_melt   " &
                            " ( heat_number , heat_status , tap_drain , graphite_dust_make , tip_make , lpipe_make , tip_quantity ," &
                            " lpipe_quantity , electrode_dip_time , fettling_info , tap_temperature , tap_begin , tap_end , tap_time , " &
                            " sos_temperature , jmp_st_temperature , slag_condition , lm_level , sos_aluminium_star , " &
                            " jmp_aluminium_star , lm_level_final , process_delay , hea_rem , heat_tapped , LOF , SOS ) " &
                            " values ( @heat_number , @heat_status , @tap_drain , @graphite_dust_make , " &
                            " @tip_make , @lpipe_make , @tip_quantity , " &
                            " @lpipe_quantity , @electrode_dip_time , @fettling_info , @tap_temperature , @tap_begin , @tap_end , @tap_time , " &
                            " @sos_temperature , @jmp_st_temperature , @slag_condition , @lm_level , @sos_aluminium_star , " &
                            " @jmp_aluminium_star , @lm_level_final , @process_delay , @hea_rem , @heat_tapped, " &
                            "@DDLLOF, @DDLSOS ) "
                    End If
                    If oCmd.ExecuteNonQuery() = 1 Then Done = True
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
            End If
            Return Done
        End Function
        Public Function SaveLadlePODetails(ByVal PONumber As String, ByVal InspCertificateNo As String, ByVal InspCertificateDate As Date, ByVal AcceptedQty As Integer, ByVal BricksSize As String, ByVal PLC As String, ByVal RUL As String, ByVal PCE As String, ByVal AP As String, ByVal Remarks As String) As Boolean
            Dim Done As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            Try
                oCmd.Parameters.Add("@PONumber", SqlDbType.VarChar, 9).Value = PONumber
                oCmd.Parameters.Add("@InspCertificateNo", SqlDbType.VarChar, 50).Value = InspCertificateNo
                oCmd.Parameters.Add("@InspCertificateDate", SqlDbType.SmallDateTime, 4).Value = InspCertificateDate
                oCmd.Parameters.Add("@AcceptedQty", SqlDbType.Int, 4).Value = AcceptedQty
                oCmd.Parameters.Add("@BricksSize", SqlDbType.VarChar, 50).Value = BricksSize
                oCmd.Parameters.Add("@PLC", SqlDbType.VarChar, 50).Value = PLC
                oCmd.Parameters.Add("@RUL", SqlDbType.VarChar, 50).Value = RUL
                oCmd.Parameters.Add("@PCE", SqlDbType.VarChar, 50).Value = PCE
                oCmd.Parameters.Add("@AP", SqlDbType.VarChar, 50).Value = AP
                oCmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 50).Value = Remarks
                oCmd.Parameters.Add("@SlNo", SqlDbType.Int, 4).Direction = ParameterDirection.Output

                oCmd.CommandText = "select @SlNo = SlNo FROM mm_LadlePODetails " &
                    " WHERE PONumber = @PONumber and InspCertificateNo = @InspCertificateNo and BricksSize = @BricksSize "
                oCmd.ExecuteScalar()
                Done = IIf(IsDBNull(oCmd.Parameters("@SlNo").Value), 0, oCmd.Parameters("@SlNo").Value)
                If Done Then
                    Done = False
                    oCmd.CommandText = "update mm_LadlePODetails " &
                        " set InspCertificateDate = @InspCertificateDate , AcceptedQty = @AcceptedQty ," &
                        " PLC = @PLC , RUL = @RUL , PCE = @PCE , AP = @AP , " &
                        " Remarks = @Remarks WHERE PONumber = @PONumber and InspCertificateNo = @InspCertificateNo and BricksSize = @BricksSize  "
                Else
                    oCmd.CommandText = "insert into mm_LadlePODetails   " &
                        " ( PONumber , InspCertificateNo , InspCertificateDate , AcceptedQty , " &
                        " BricksSize , PLC , RUL , PCE , AP , Remarks  ) " &
                        " values ( @PONumber , @InspCertificateNo , @InspCertificateDate , @AcceptedQty , " &
                        " @BricksSize , @PLC , @RUL , @PCE , @AP , @Remarks  ) "
                End If
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                If oCmd.ExecuteNonQuery = 1 Then
                    Done = True
                Else
                    Exit Function
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
        Public Function SaveRoofFixingDetails(ByVal RoofNo As String, ByVal FurnaceCode As String, ByVal FromHeatNo As Long, ByVal ToHeatNo As Long, ByVal Reason As String, ByVal Remarks As String) As Boolean
            Dim Done As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            Try
                oCmd.Parameters.Add("@RoofNo", SqlDbType.VarChar, 10).Value = RoofNo
                oCmd.Parameters.Add("@FurnaceCode", SqlDbType.VarChar, 1).Value = FurnaceCode
                oCmd.Parameters.Add("@FromHeatNo", SqlDbType.BigInt, 4).Value = FromHeatNo
                oCmd.Parameters.Add("@ToHeatNo", SqlDbType.BigInt, 4).Value = ToHeatNo
                oCmd.Parameters.Add("@Reason", SqlDbType.VarChar, 50).Value = Reason
                oCmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = Remarks
                oCmd.Parameters.Add("@LiningNo", SqlDbType.VarChar, 50).Direction = ParameterDirection.Input
                oCmd.Parameters.Add("@SlNo", SqlDbType.Int, 4).Direction = ParameterDirection.Output

                If Val(FromHeatNo) > 0 Then
                    oCmd.Parameters("@LiningNo").Value = RWF.Melting.GetRoofLiningNo(RoofNo.Substring(2, 2), Val(FromHeatNo))
                Else
                    oCmd.Parameters("@LiningNo").Value = ""
                End If
                oCmd.CommandText = "select @SlNo = count(*) FROM mm_RoofFixing " &
                    " WHERE RoofNo = @RoofNo and FurnaceCode = @FurnaceCode and FromHeatNo = @FromHeatNo "
                oCmd.ExecuteScalar()
                Done = IIf(IsDBNull(oCmd.Parameters("@SlNo").Value), 0, oCmd.Parameters("@SlNo").Value)
                If Done Then
                    Done = False
                    oCmd.CommandText = "update mm_RoofFixing " &
                        " set ToHeatNo = @ToHeatNo , Reason = @Reason , Remarks = @Remarks , FromHeatNo = @FromHeatNo , " &
                        " LiningNo = @LiningNo WHERE RoofNo = @RoofNo and FurnaceCode = @FurnaceCode and FromHeatNo = @FromHeatNo "
                Else
                    oCmd.CommandText = "insert into mm_RoofFixing   " &
                        " ( RoofNo , FurnaceCode , FromHeatNo , ToHeatNo , Reason  , Remarks  , LiningNo ) " &
                        " values ( @RoofNo , @FurnaceCode , @FromHeatNo , @ToHeatNo , @Reason  , @Remarks , @LiningNo ) "
                End If
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                If oCmd.ExecuteNonQuery = 1 Then
                    Done = True
                Else
                    Exit Function
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
        Public Function SaveContractNo(ByVal ContractNo As String, ByVal Qty As Double) As Boolean
            Dim Done As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            Try
                oCmd.Parameters.Add("@ContractNo", SqlDbType.VarChar, 50).Value = ContractNo
                oCmd.Parameters.Add("@Qty", SqlDbType.Float, 9).Value = Qty
                oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                oCmd.CommandText = "select @cnt = count(*) from mm_ContractQty " &
                    " where ContractNo = @ContractNo "
                oCmd.ExecuteScalar()
                Done = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)
                If Done Then
                    Done = False
                    oCmd.CommandText = "update mm_ContractQty " &
                        " set Qty = @Qty where ContractNo = @ContractNo "
                Else
                    oCmd.CommandText = "insert into mm_ContractQty   " &
                        " ( ContractNo , Qty ) " &
                        " values ( @ContractNo , @Qty ) "
                End If
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                If oCmd.ExecuteNonQuery = 1 Then
                    Done = True
                Else
                    Exit Function
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
        Public Function SavePreHeatedLadleDetails(ByVal LadleNo As String, ByVal StartTime As Date, ByVal EndTime As Date, ByVal LiftingTemp As Integer, ByVal FromHeat As Double, ByVal ToHeat As Double, ByVal Remarks As String, ByVal LiningNo As String, ByVal StaffNo As String, ByVal Type As String, ByVal PreHeatID As Integer, Optional ByVal delete As Boolean = False) As Boolean
            Dim Done As Boolean

            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            Try
                oCmd.Parameters.Add("@LadleNo", SqlDbType.VarChar, 50).Value = LadleNo
                oCmd.Parameters.Add("@StartTime", SqlDbType.SmallDateTime, 4).Value = StartTime
                oCmd.Parameters.Add("@EndTime", SqlDbType.SmallDateTime, 4).Value = EndTime
                oCmd.Parameters.Add("@LiftingTemp", SqlDbType.Int, 4).Value = LiftingTemp
                oCmd.Parameters.Add("@FromHeat", SqlDbType.BigInt, 8).Value = FromHeat
                oCmd.Parameters.Add("@ToHeat", SqlDbType.BigInt, 8).Value = ToHeat
                oCmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 100).Value = Remarks
                oCmd.Parameters.Add("@LiningNo", SqlDbType.VarChar, 50).Value = LiningNo
                oCmd.Parameters.Add("@StaffNo", SqlDbType.VarChar, 50).Value = StaffNo
                oCmd.Parameters.Add("@Type", SqlDbType.VarChar, 1).Value = Type
                oCmd.Parameters.Add("@PreHeatID", SqlDbType.Int, 4).Value = PreHeatID
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                If delete Then
                    oCmd.CommandText = "delete mm_PreHeatedLadleSetTemp " &
                        " where PreHeatID = @PreHeatID "
                    oCmd.ExecuteNonQuery()
                    oCmd.CommandText = "delete mm_PreHeatedLadleDetails " &
                        " where PreHeatID = @PreHeatID "
                Else
                    If PreHeatID > 0 Then
                        Done = False
                        oCmd.Parameters("@PreHeatID").Direction = ParameterDirection.Input
                        oCmd.CommandText = "update mm_PreHeatedLadleDetails " &
                            " set EndTime = @EndTime , LiftingTemp = @LiftingTemp , FromHeat = @FromHeat , StaffNo = @StaffNo ," &
                            " ToHeat = @ToHeat , Remarks = @Remarks , StartTime = @StartTime , Type = @Type " &
                            " where LadleNo = @LadleNo and LiningNo = @LiningNo and PreHeatID = @PreHeatID "
                    Else
                        oCmd.CommandText = "insert into mm_PreHeatedLadleDetails   " &
                            " ( LadleNo , StartTime , EndTime , LiftingTemp , FromHeat , ToHeat , Remarks , LiningNo , StaffNo , Type ) " &
                            " values ( @LadleNo , @StartTime , @EndTime , @LiftingTemp , @FromHeat , @ToHeat , @Remarks , @LiningNo , @StaffNo , @Type ) "
                    End If
                End If

                If oCmd.ExecuteNonQuery = 1 Then
                    Done = True
                Else
                    Exit Function
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
        Public Function SavePreHeatedLadleSetTemp(ByVal PreHeatID As String, ByVal SetDateTime As Date, ByVal LPH As Integer, ByVal HSDQty As Integer, ByVal SetTemp As Integer, ByVal ActualTemp As Double, ByVal Remarks As String, ByVal Staff As String, Optional ByVal SetID As Integer = 0) As Boolean
            Dim Done As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            Try
                oCmd.Parameters.Add("@PreHeatID", SqlDbType.Int, 4).Value = PreHeatID
                oCmd.Parameters.Add("@SetDateTime", SqlDbType.SmallDateTime, 4).Value = SetDateTime
                oCmd.Parameters.Add("@LPH", SqlDbType.Int, 4).Value = LPH
                oCmd.Parameters.Add("@HSDQty", SqlDbType.Int, 4).Value = HSDQty
                oCmd.Parameters.Add("@SetTemp", SqlDbType.Int, 4).Value = SetTemp
                oCmd.Parameters.Add("@ActualTemp", SqlDbType.Int, 4).Value = ActualTemp
                oCmd.Parameters.Add("@Staff", SqlDbType.VarChar, 6).Value = Staff
                oCmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = Remarks

                If SetID > 0 Then
                    oCmd.CommandText = "delete mm_PreHeatedLadleSetTemp " &
                    " where SetID = " & SetID & " and PreHeatID = @PreHeatID and SetDateTime = @SetDateTime"
                Else
                    oCmd.CommandText = "insert into mm_PreHeatedLadleSetTemp   " &
                      " ( PreHeatID , SetDateTime , LPH , HSDQty , SetTemp , ActualTemp , Staff , Remarks  ) " &
                      " values ( @PreHeatID , @SetDateTime , @LPH , @HSDQty , @SetTemp , @ActualTemp , @Staff , @Remarks  ) "
                End If
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                If oCmd.ExecuteNonQuery = 1 Then
                    Done = True
                Else
                    Exit Function
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
        Public Function SaveFumeExtractionDetails(ByVal FromHeat As Long, ByVal ToHeat As Long, ByVal OffTime As Date, ByVal OnTime As Date, ByVal Remarks As String, ByVal SlNo As Integer, Optional ByVal Delete As Boolean = False) As Boolean
            Dim Done As Boolean

            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            Try
                oCmd.Parameters.Add("@FromHeat", SqlDbType.BigInt, 8).Value = FromHeat '
                oCmd.Parameters.Add("@ToHeat", SqlDbType.BigInt, 8).Value = ToHeat
                oCmd.Parameters.Add("@OffTime", SqlDbType.SmallDateTime, 4).Value = OffTime
                oCmd.Parameters.Add("@OnTime", SqlDbType.SmallDateTime, 4).Value = OnTime
                oCmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 100).Value = Remarks
                oCmd.Parameters.Add("@SlNo", SqlDbType.Int, 4).Value = SlNo
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                If SlNo > 0 Then
                    If Delete Then
                        oCmd.CommandText = "delete mm_FumeExtraction " &
                            " where FromHeat = @FromHeat and SlNo = @SlNo "
                    Else
                        oCmd.CommandText = "update mm_FumeExtraction " &
                            " set ToHeat = @ToHeat , OffTime = @OffTime , OnTime = @OnTime , Remarks = @Remarks " &
                            " where FromHeat = @FromHeat and SlNo = @SlNo "
                    End If
                Else
                    oCmd.CommandText = "insert into mm_FumeExtraction   " &
                        " ( FromHeat , ToHeat , OffTime , OnTime ,  Remarks ) " &
                        " values ( @FromHeat , @ToHeat , @OffTime , @OnTime , @Remarks ) "
                End If
                If oCmd.ExecuteNonQuery = 1 Then
                    Done = True
                Else
                    Exit Function
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
        Public Function SavePCDODetails(ByVal YearMonth As String, ByVal Accidents As Long, ByVal DAR As Integer, ByVal OT As Integer, ByVal PFNo As String, ByVal PFRemarks As String, Optional ByVal Delete As Boolean = False) As Boolean
            Dim Done As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            Try
                oCmd.Parameters.Add("@YearMonth", SqlDbType.VarChar, 6).Value = YearMonth
                oCmd.Parameters.Add("@Accidents", SqlDbType.Int, 4).Value = Accidents
                oCmd.Parameters.Add("@DAR", SqlDbType.Int, 4).Value = DAR
                oCmd.Parameters.Add("@OT", SqlDbType.Int, 4).Value = OT
                oCmd.Parameters.Add("@PFNo", SqlDbType.VarChar, 6).Value = PFNo
                oCmd.Parameters.Add("@PFRemarks", SqlDbType.VarChar, 250).Value = PFRemarks
                oCmd.Parameters.Add("@PCDOId", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                oCmd.CommandText = " select @PCDOId = PCDOId from mm_MeltPCDO where YearMonth = @YearMonth"
                oCmd.ExecuteScalar()
                If IIf(IsDBNull(oCmd.Parameters("@PCDOId").Value), 0, oCmd.Parameters("@PCDOId").Value) = 0 Then
                    oCmd.CommandText = "insert mm_MeltPCDO ( YearMonth , Accidents , DAR , OT ) values " &
                        " ( @YearMonth , @Accidents , @DAR , @OT ) "
                    If oCmd.ExecuteNonQuery = 1 Then
                        oCmd.Parameters("@PCDOId").Direction = ParameterDirection.Output
                        oCmd.CommandText = " select @PCDOId = PCDOId from mm_MeltPCDO where YearMonth = @YearMonth"
                        oCmd.ExecuteScalar()
                    Else
                        Exit Function
                    End If
                Else
                    oCmd.Parameters("@PCDOId").Direction = ParameterDirection.Input
                    oCmd.CommandText = "update mm_MeltPCDO " &
                        " set Accidents = @Accidents , DAR = @DAR , OT = @OT " &
                        " where YearMonth = @YearMonth and PCDOId = @PCDOId "
                    If oCmd.ExecuteNonQuery = 1 Then
                        Done = True
                    Else
                        Exit Function
                    End If
                End If
                oCmd.Parameters("@PCDOId").Direction = ParameterDirection.Input
                oCmd.CommandText = "select @cnt = count(*) from mm_MeltPCDOList where PFNo = @PFNo and PCDOId = @PCDOId "
                oCmd.ExecuteScalar()
                If IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value) = 0 Then
                    oCmd.CommandText = "insert into mm_MeltPCDOList ( PCDOId , PFNo , PFRemarks ) " &
                                    " values ( @PCDOId , @PFNo , @PFRemarks ) "
                Else
                    If Delete Then
                        oCmd.CommandText = "delete mm_MeltPCDOList where PCDOId = @PCDOId and  PFNo = @PFNo "
                    Else
                        oCmd.CommandText = "update mm_MeltPCDOList set PFRemarks = @PFRemarks " &
                            "  where PCDOId = @PCDOId and  PFNo = @PFNo "
                    End If
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
End Namespace
