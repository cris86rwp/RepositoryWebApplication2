Namespace RWF
    <Serializable()> Public Class CLRINS
        Public Shared Function DCDetails(ByVal Batch As String) As DataSet
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = " select  " & _
                    " distinct wagon_lorry_number FROM dm_fg_despatch_wagon a inner join dm_fg_despatch_products b" & _
                    " on a.dc_number = b.dc_number WHERE a.dc_number = @DC ; " & _
                    " select distinct product_code from dm_fg_despatch_products " & _
                    " where dc_number = @DC and waglorry_number in " & _
                    " ( select wagon_lorry_number from dm_fg_despatch_wagon where dc_number = @DC ) ; " & _
                    " select row_number() over ( order by a.dc_number , wagon_lorry_number , b.product_code ) Sl , " & _
                    " a.dc_number DCNo , rtrim(wagon_lorry_number) WagonLryNo , " & _
                    " b.product_code Product , max(wagon_lorry_quantity) Qty , count(*) Count" & _
                    " from dm_fg_despatch_rr a inner join dm_fg_despatch_wagon b    " & _
                    " on a.dc_number = b.dc_number inner join dm_fg_despatch_products c  " & _
                    " on a.dc_number = c.dc_number and wagon_lorry_number = waglorry_number   " & _
                    " and b.product_code = c.product_code and wagon_lorry_ind = waglorry_ind     " & _
                    " inner join mm_product_master d on b.product_code = d.product_code    " & _
                    " inner join mm_customer_consignee e on consignee = code       " & _
                    " where a.dc_number = @DC " & _
                    " group by a.dc_number , wagon_lorry_number , b.product_code "
                da.SelectCommand.Parameters.Add("@DC", SqlDbType.VarChar, 50).Value = Batch
                da.Fill(ds)
                DCDetails = ds.Copy
            Catch exp As Exception
                DCDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function PressBatchData(ByVal Batch As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "SELECT DISTINCT product_code FROM dm_fg_despatch_products " & _
                    " WHERE dc_number = @DC and waglorry_number in " & _
                    " ( SELECT wagon_lorry_number FROM dm_fg_despatch_wagon WHERE dc_number = @DC )"
                da.SelectCommand.Parameters.Add("@DC", SqlDbType.VarChar, 50).Value = Batch
                da.Fill(ds)
                PressBatchData = ds.Tables(0)
            Catch exp As Exception
                PressBatchData = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function WagonLorryNoProductCode(ByVal DC As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "SELECT DISTINCT product_code FROM dm_fg_despatch_products " & _
                    " WHERE dc_number = @DC and waglorry_number in " & _
                    " ( SELECT wagon_lorry_number FROM dm_fg_despatch_wagon WHERE dc_number = @DC )"
                da.SelectCommand.Parameters.Add("@DC", SqlDbType.VarChar, 50).Value = DC
                da.Fill(ds)
                WagonLorryNoProductCode = ds.Tables(0)
            Catch exp As Exception
                WagonLorryNoProductCode = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function WagonLorryNo(ByVal DC As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "SELECT wagon_lorry_number FROM dm_fg_despatch_wagon " & _
                        " WHERE dc_number = @DC"
                da.SelectCommand.Parameters.Add("@DC", SqlDbType.VarChar, 50).Value = DC
                da.Fill(ds)
                WagonLorryNo = ds.Tables(0)
            Catch exp As Exception
                WagonLorryNo = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function FiOffloadsPassedWheels(ByVal FrDt As Date, ByVal ToDt As Date) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()

            Try
                da.SelectCommand.CommandText = "mm_sp_FiOffloadsPassedWheels"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.Add("@fromdt", SqlDbType.SmallDateTime, 4).Value = CDate(FrDt)
                da.SelectCommand.Parameters.Add("@todt", SqlDbType.SmallDateTime, 4).Value = CDate(ToDt)
                da.Fill(ds, "rew")
                FiOffloadsPassedWheels = ds.Tables("rew")
            Catch exp As Exception
                FiOffloadsPassedWheels = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function FiOffloadsDistinctWheels(ByVal FrDt As Date, ByVal ToDt As Date) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "mm_sp_FiOffloadsDistinctWheels"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.Add("@fromdt", SqlDbType.SmallDateTime, 4).Value = CDate(FrDt)
                da.SelectCommand.Parameters.Add("@todt", SqlDbType.SmallDateTime, 4).Value = CDate(ToDt)
                da.Fill(ds, "rew")
                FiOffloadsDistinctWheels = ds.Tables("rew")
            Catch exp As Exception
                FiOffloadsDistinctWheels = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function FiOffloads(ByVal FrDt As Date, ByVal ToDt As Date) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()

            Try
                da.SelectCommand.CommandText = "mm_sp_si_FiOffloads"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.Add("@fromdt", SqlDbType.SmallDateTime, 4).Value = CDate(FrDt)
                da.SelectCommand.Parameters.Add("@todt", SqlDbType.SmallDateTime, 4).Value = CDate(ToDt)
                da.SelectCommand.Parameters.Add("@wheelwise", SqlDbType.Int, 4).Value = 0
                da.Fill(ds, "rew")
                FiOffloads = ds.Tables("rew")
            Catch exp As Exception
                FiOffloads = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function fi_Score(ByVal dt As Date) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "mm_sp_si_fi_Score"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.Add("@dt", SqlDbType.SmallDateTime, 4).Value = dt
                da.Fill(ds)
                fi_Score = ds.Tables(0)
            Catch exp As Exception
                fi_Score = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function wagon_product_code(ByVal DCNumber As String, ByVal wagon As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "SELECT DISTINCT product_code FROM dm_fg_despatch_products " & _
                        " WHERE dc_number = '" & DCNumber.Trim & "' and waglorry_number = '" & wagon.Trim & "'"
                da.Fill(ds)
                wagon_product_code = ds.Tables(0)
            Catch exp As Exception
                wagon_product_code = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function wagon_lorry_number(ByVal DCNumber As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "SELECT wagon_lorry_number FROM dm_fg_despatch_wagon WHERE dc_number = '" & DCNumber.Trim & "'"
                da.Fill(ds)
                wagon_lorry_number = ds.Tables(0)
            Catch exp As Exception
                wagon_lorry_number = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function TreadDia(ByVal sProdCode As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "select MinTreadDia ,  MaxTreadDia " & _
                    " from mm_ProductwiseTreadAndBoreSizes where productcode = '" & sProdCode & "'"
                da.Fill(ds)
                TreadDia = ds.Tables(0)
            Catch exp As Exception
                TreadDia = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function CheckProdCode(ByVal TreadDiameter As Decimal, ByVal WheelNumber As Long, ByVal HeatNumber As Long) As String
            Dim sqlcmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            sqlcmd.CommandText = "select c.product_code from mm_wheel a inner join mm_workorder b " & _
                " on a.workorder_cleaning_room = b.number inner join mm_product_master c " & _
                " on c.product_code = b.product_code where a.wheel_number = " & WheelNumber & " and a.heat_number = " & HeatNumber
            Try
                sqlcmd.Connection.Open()
                CheckProdCode = sqlcmd.ExecuteScalar
            Catch exp As Exception
                CheckProdCode = ""
                Throw New Exception(exp.Message)
            Finally
                If sqlcmd.Connection.State = ConnectionState.Open Then sqlcmd.Connection.Close()
                sqlcmd.Connection.Dispose()
                sqlcmd = Nothing
            End Try
        End Function
        Public Shared Function CheckEmp(ByVal TechnicalAuthority As String) As Boolean
            Dim sqlcmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            sqlcmd.CommandText = "Select count(*) from hr_employee_master " & _
                " where employee_code = '" & TechnicalAuthority & "' and employee_status < 10 "
            Dim i As Integer
            Try
                sqlcmd.Connection.Open()
                i = sqlcmd.ExecuteScalar
                If IsNothing(i) OrElse IsDBNull(i) Then
                    i = 0
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
                i = 0
            Finally
                If sqlcmd.Connection.State = ConnectionState.Open Then
                    sqlcmd.Connection.Close()
                End If
                sqlcmd.Dispose()
                sqlcmd = Nothing
            End Try
            Return i
        End Function
        Public Shared Function CheckBHN(ByVal txtBHN As Integer, ByVal WheelNumber As Long, ByVal HeatNumber As Long) As Boolean
            ' take bhn range from pm and if entered val is between range then return true
            Dim low_bhn, high_bhn As Decimal
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.CommandText = "  select @low_bhn = isnull(c.low_bhn,0.0)  , @high_bhn = isnull(c.high_bhn,0.0)  " & _
                " from mm_wheel a inner join mm_workorder b on a.workorder_cleaning_room = b.number " & _
                " inner join mm_product_master c on c.product_code = b.product_code   " & _
                " where a.wheel_number = " & WheelNumber & " and a.heat_number = " & HeatNumber

            cmd.Parameters.Add("@low_bhn", SqlDbType.Float, 8).Direction = ParameterDirection.Output
            cmd.Parameters.Add("@high_bhn", SqlDbType.Float, 8).Direction = ParameterDirection.Output
            Try
                cmd.Connection.Open()
                cmd.ExecuteScalar()
                low_bhn = cmd.Parameters("@low_bhn").Value
                high_bhn = cmd.Parameters("@high_bhn").Value
            Catch exp As Exception
                low_bhn = 0.0
                high_bhn = 0.0
                Throw New Exception(exp.Message)
            Finally
                If IsDBNull(low_bhn) = True OrElse IsNothing(low_bhn) = True Then low_bhn = 0.0
                If IsDBNull(high_bhn) = True OrElse IsNothing(high_bhn) = True Then high_bhn = 0.0
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
            Return Val(txtBHN) >= low_bhn AndAlso Val(txtBHN) <= high_bhn
        End Function
        Public Shared Function MagnaDisposition(ByVal WheelNumber As Long, ByVal HeatNumber As Long) As String
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@whl", SqlDbType.BigInt, 8).Value = WheelNumber
            cmd.Parameters.Add("@heat", SqlDbType.BigInt, 8).Value = HeatNumber
            cmd.CommandText = "select MagnaDisposition from mm_vw_wheelstobeverified where wheelnumber = @whl and heatnumber = @heat"
            Try
                cmd.Connection.Open()
                MagnaDisposition = cmd.ExecuteScalar
            Catch exp As Exception
                MagnaDisposition = ""
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function PendVerification(ByVal WheelNumber As Long, ByVal HeatNumber As Long) As String
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@whl", SqlDbType.BigInt, 8).Value = WheelNumber
            cmd.Parameters.Add("@heat", SqlDbType.BigInt, 8).Value = HeatNumber
            cmd.CommandText = "select 'Wheel : ' + wheel +'('+MagnaDisposition+')'+ 'waiting for Final Verification in Yard from '+ waitingfrom  " & _
                " from mm_vw_wheelstobeverified where wheelnumber = @whl and heatnumber = @heat"
            Try
                cmd.Connection.Open()
                PendVerification = cmd.ExecuteScalar
            Catch exp As Exception
                PendVerification = ""
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function stockwheelVerfication(ByVal WheelNumber As Long, ByVal HeatNumber As Long) As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.CommandText = "select count(*) from mm_wheel " & _
                " where wheel_number = " & CLng(WheelNumber) & " and heat_number = " & CLng(HeatNumber) & " " & _
                " and location = 'CLMT' and status = 'stock'"
            Try
                cmd.Connection.Open()
                stockwheelVerfication = cmd.ExecuteScalar > 0
            Catch exp As Exception
                stockwheelVerfication = False
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function WaitingForVerfication(ByVal WheelNumber As Long, ByVal HeatNumber As Long) As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.CommandText = "select top 100 percent  count(d.wheel_number) " & _
                " from mm_yardInspection_technical a  " & _
                " inner join  mm_yardInspection_magna b  on b.techslno = a.slno " & _
                " inner join mm_yardInspection_final c on c.Magslno = b.slno  " & _
                " inner join mm_wheel d on a.wheelnumber = d.wheel_number and a.heatnumber = d.heat_number  " & _
                " where d.location <> 'clmt' and d.wheel_number = " & WheelNumber & " and d.heat_number = " & HeatNumber
            Try
                cmd.Connection.Open()
                WaitingForVerfication = cmd.ExecuteScalar > 0
            Catch exp As Exception
                WaitingForVerfication = False
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function YardWheelStatus(ByVal WheelNumber As Long, ByVal HeatNumber As Long) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            'on 20/02/2014 to enable passing of RLPT wheels as per ACMT/W letter dated:30/01/2014
            ' " when b.location = 'clfi' and a.mcn_operation not like 'RLPT%' then 4 " & _
            Try
                da.SelectCommand.Parameters.Add("@whl", SqlDbType.BigInt, 8).Value = WheelNumber
                da.SelectCommand.Parameters.Add("@heat", SqlDbType.BigInt, 8).Value = HeatNumber
                da.SelectCommand.CommandText = " select sts = case when ( ( ( a.mcn_operation like '%/p' or a.wheel_status like 'st%') and b.location = 'clmt' ) or (b.location = 'clqci' and b.status not like '[s,x, rl]%') )  then 0 " & _
                    " when (b.location = 'clqc' and ( b.status like 's%p' or b.status like 'p%')) or (b.location = 'clfi' and ( b.status like 's%p' or b.status like 'p%')) then 1  " & _
                    " when (b.location = 'clqc' and ( b.status like 'xc%' or b.status like 'rej%')) then 2  " & _
                    " when b.location = 'clmt' and a.mcn_operation not like '%/p'  then 3 " & _
                    " else -1 end  , loc = b.location, masterSts = b.status , mcnsts = a.mcn_operation , BHN = b.bhn_rate , " & _
                    " TreDia = b.thread_diameter , PlaTh = b.plate_thickness , BoSta = b.bore_status  " & _
                    " from mm_magnaglow_results a inner join mm_wheel b " & _
                    " on a.wheel_number = b.wheel_number and a.heat_number = b.heat_number " & _
                    " where a.wheel_number = @whl and  a.heat_number = @heat and  " & _
                    " a.sl_no = (select max(sl_no) from mm_magnaglow_results " & _
                    " where wheel_number = @whl and  heat_number = @heat ) " & _
                    " group by a.mcn_operation , b.location , b.status , b.bhn_rate , b.thread_diameter , b.plate_thickness , b.bore_status, a.wheel_status  "
                da.Fill(ds)
                YardWheelStatus = ds.Tables(0)
            Catch exp As Exception
                YardWheelStatus = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function YardWheelDetails(ByVal WheelNumber As Long, ByVal HeatNumber As Long) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "select convert(varchar(10),Dt,103) Dt , Shift , SaveDateTime from mm_yardInspection_Technical " & _
                    " where wheelnumber = " & WheelNumber & " and heatnumber = " & HeatNumber
                da.Fill(ds)
                YardWheelDetails = ds.Tables(0)
            Catch exp As Exception
                YardWheelDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function YardWheels(ByVal YardDate As Date) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@YardDate", SqlDbType.SmallDateTime, 4).Value = YardDate
                da.SelectCommand.CommandText = "select row_number() over ( order by b.slno ) Sl , " & _
                    " convert(varchar(10),b.dt,103) YardMagdt, " & _
                    " rtrim(b.shift) Sh , a.wheelNumber Whl , a.heatNumber Heat , rtrim(a.LastMcnOpn) LastMcnOpn , " & _
                    " case when b.wheelDisposition = 'SY_P' then 'SY_' else rtrim(b.wheelDisposition) end WhlDisposition, " & _
                    " c.TreadDia , rtrim(c.BoreStatus) BoreSts , rtrim(c.Platestatus) PlSts from mm_YardInspection_Technical  a " & _
                    " inner join mm_YardInspection_Magna b on b.techslno = a.slno " & _
                    " inner join mm_YardInspection_Final c on c.magslno = b.slno " & _
                    " where a.dt = @YardDate order by b.slno desc "
                da.Fill(ds)
                YardWheels = ds.Tables(0)
            Catch exp As Exception
                YardWheels = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function ValidDate(ByVal PinkDate As Date) As Integer
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Connection.Open()
                cmd.Parameters.Add("@PinkDate", SqlDbType.SmallDateTime, 4).Value = PinkDate
                cmd.Parameters.Add("@Cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                cmd.CommandText = "select @Cnt = count(*) from mm_pink_sheet where pink_date >= @PinkDate"
                cmd.ExecuteScalar()
                ValidDate = IIf(IsDBNull(cmd.Parameters("@Cnt").Value), 0, cmd.Parameters("@Cnt").Value)
            Catch exp As Exception
                ValidDate = False
                Throw New Exception(exp.Message)
            Finally
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function HoldHeatsFromFIPassing() As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            da.SelectCommand = rwfGen.Connection.CmdObj
            Try
                da.SelectCommand.CommandText = " select heat_number  , convert(varchar(11),HoldFromDate,103) HoldFromDate , " & _
                    " convert(varchar(11),HoldToDate,103) HoldToDate , Message , EmpCode " & _
                    " from mm_HoldHeatsFromFIPassing order by heat_number desc "
                da.Fill(ds)
                HoldHeatsFromFIPassing = ds.Tables(0)
            Catch exp As Exception
                HoldHeatsFromFIPassing = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function ValidHeat(ByVal lHeatNumber As Long) As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Connection.Open()
                cmd.Parameters.Add("@Cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                cmd.CommandText = "select @Cnt = count(heat_number) from mm_wheel where heat_number = " & Val(lHeatNumber)
                cmd.ExecuteScalar()
                ValidHeat = IIf(IsDBNull(cmd.Parameters("@Cnt").Value), 0, cmd.Parameters("@Cnt").Value)
            Catch exp As Exception
                ValidHeat = False
                Throw New Exception(exp.Message)
            Finally
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function HoldHeatsFromDespatch() As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            da.SelectCommand = rwfGen.Connection.CmdObj
            Try
                da.SelectCommand.CommandText = " select heat_number  , convert(varchar(11),HoldFromDate,103) HoldFromDate , " & _
                    " convert(varchar(11),HoldToDate,103) HoldToDate , Message , EmpCode " & _
                    "from mm_HoldHeatsFromDespatch order by heat_number desc "
                da.Fill(ds)
                HoldHeatsFromDespatch = ds.Tables(0)
            Catch exp As Exception
                HoldHeatsFromDespatch = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function getPrestatus(ByVal lWheelNumber As Long, ByVal lHeatNumber As Long) As String
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Connection.Open()
                cmd.Parameters.Add("@Prestatus", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                cmd.CommandText = "select top 1 @Prestatus = status from mm_wheel where wheel_number = " & lWheelNumber & "  " & _
                " and a.heat_number =  " & lHeatNumber & " and location = 'CLQC' "
                cmd.ExecuteScalar()
                getPrestatus = IIf(IsDBNull(cmd.Parameters("@Prestatus").Value), "", cmd.Parameters("@Prestatus").Value)
            Catch exp As Exception
                getPrestatus = "Not Found"
                Throw New Exception(exp.Message)
            Finally
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function getTechInsp(ByVal lWheelNumber As Long, ByVal lHeatNumber As Long) As String
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Connection.Open()
                cmd.Parameters.Add("@LabInsp", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                cmd.CommandText = "select top 1 @LabInsp = tech_Inspector from mm_yard_inspection where wheel_number = " & lWheelNumber & "  " & _
                " and a.heat_number =  " & lHeatNumber & " order by sl_no asc "
                cmd.ExecuteScalar()
                getTechInsp = IIf(IsDBNull(cmd.Parameters("@LabInsp").Value), "", cmd.Parameters("@LabInsp").Value)
            Catch exp As Exception
                getTechInsp = "Not Found"
                Throw New Exception(exp.Message)
            Finally
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function getLabInsp(ByVal lWheelNumber As Long, ByVal lHeatNumber As Long) As String
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Connection.Open()
                cmd.Parameters.Add("@LabInsp", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                cmd.CommandText = "select top 1 @LabInsp = lab_Inspector from mm_yard_inspection where wheel_number = " & lWheelNumber & "  " & _
                " and a.heat_number =  " & lHeatNumber & " order by sl_no asc "
                cmd.ExecuteScalar()
                getLabInsp = IIf(IsDBNull(cmd.Parameters("@LabInsp").Value), "", cmd.Parameters("@LabInsp").Value)
            Catch exp As Exception
                getLabInsp = "Not Found"
                Throw New Exception(exp.Message)
            Finally
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function wheelPassed(ByVal lWheelNumber As Long, ByVal lHeatNumber As Long) As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Connection.Open()
                cmd.Parameters.Add("@Cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                cmd.CommandText = "select @Cnt = count(*) from " & _
                    "  mm_yardInspection_technical a inner join mm_yardInspection_magna  b on b.techslno = a.slno inner join mm_yardInspection_final  c on c.magslno = b.slno " & _
                    " where a.wheelNumber = " & lWheelNumber & " and a.heatNumber = " & lHeatNumber & " and c.wheelDisposition = 'SY_P' "
                cmd.ExecuteScalar()
                wheelPassed = IIf(IsDBNull(cmd.Parameters("@Cnt").Value), 0, cmd.Parameters("@Cnt").Value)
            Catch exp As Exception
                wheelPassed = False
                Throw New Exception(exp.Message)
            Finally
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function YardWhlLocation(ByVal lWheelNumber As Long, ByVal lHeatNumber As Long) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "Select location, status, press_status, despatch_note_number, " & _
                    " thread_diameter, Bore_status, Bore_diameter from mm_wheel " & _
                    " where wheel_number = " & lWheelNumber & " and heat_number = " & lHeatNumber & " and location <> 'clmt' "
                da.Fill(ds)
                YardWhlLocation = ds.Tables(0)
            Catch exp As Exception
                YardWhlLocation = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function getwheeltype(ByVal lWheelNumber As Long, ByVal lHeatNumber As Long) As String
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Connection.Open()
                cmd.Parameters.Add("@WhlType", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                cmd.CommandText = "select @WhlType = b.product_code from mm_wheel a inner join mm_workorder b " & _
                    " on a.workorder_cleaning_room = b.number where a.wheel_number = " & lWheelNumber & " " & _
                    " and a.heat_number =  " & lHeatNumber
                cmd.ExecuteScalar()
                getwheeltype = IIf(IsDBNull(cmd.Parameters("@WhlType").Value), "", cmd.Parameters("@WhlType").Value)
            Catch exp As Exception
                getwheeltype = ""
                Throw New Exception(exp.Message)
            Finally
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function getTreadDiaBoundary(ByVal ProdCode As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "select isnull(minTreadDia,0) minTreadDia  , isnull(MaxTreadDia,0) MaxTreadDia " & _
                    " from mm_ProductwiseTreadAndBoreSizes where productCode = '" & ProdCode & "'"
                da.Fill(ds)
                getTreadDiaBoundary = ds.Tables(0)
            Catch exp As Exception
                getTreadDiaBoundary = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function YardWhlDetails(ByVal wheel As String, Optional ByVal ReInspWheel As Boolean = False) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                If ReInspWheel = False Then
                    da.SelectCommand.CommandText = "select wheel, waitingFrom, shift, lastmcnopn, WheelDisposition disposition, " & _
                        " MagnaDisposition, treaddia, BoreStatus borests, PlateStatus platests, boreDia  " & _
                        " from mm_vw_wheelsToBeVerified where wheel = @wheel"
                Else
                    da.SelectCommand.CommandText = "select wheel, waitingFrom, shift, lastmcnopn, WheelDisposition disposition, " & _
                        " MagnaDisposition, treaddia, BoreStatus borests, PlateStatus platests, BoreDia  " & _
                        " from mm_vw_wheelsToBeVerifiedForReInsp where wheel = @wheel"
                End If
                da.SelectCommand.Parameters.Add("@wheel", SqlDbType.VarChar, 50)
                da.SelectCommand.Parameters("@wheel").Direction = ParameterDirection.Input
                da.SelectCommand.Parameters("@wheel").Value = wheel
                da.Fill(ds)
                YardWhlDetails = ds.Tables(0)
            Catch exp As Exception
                YardWhlDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function ReListWheels(Optional ByVal XcWheels As Boolean = False, Optional ByVal ReInspWheels As Boolean = False, Optional ByVal RLPTWheels As Boolean = False) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                If XcWheels Then
                    da.SelectCommand.CommandText = "select wheel, wheel from mm_vw_wheelsToBeVerified where magnaDisposition like 'xc%' order by slno "
                End If
                If XcWheels = False And ReInspWheels = False Then
                    da.SelectCommand.CommandText = "select wheel, wheel from mm_vw_wheelsToBeVerified order by slno "
                End If
                If ReInspWheels Then
                    da.SelectCommand.CommandText = "select wheel, wheel from mm_vw_wheelsToBeVerifiedForReInsp order by sl_no asc "
                End If
                If RLPTWheels Then
                    da.SelectCommand.CommandText = "select wheel, wheel from mm_vw_RLPTWheelsToBeVerifiedForReInsp "
                End If
                da.Fill(ds)
                ReListWheels = ds.Tables(0)
            Catch exp As Exception
                ReListWheels = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function YardRej() As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "select (rej_code +'--'+ rej_desc) as rjtype_desc , rej_code " & _
                    " from mm_mmrjd_dump where location like '%CLFI%'"
                da.Fill(ds)
                YardRej = ds.Tables(0)
            Catch exp As Exception
                YardRej = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function YardRew() As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "select (mcn_type +'--'+ mcn_desc) as mctype_desc , mcn_type " & _
                    " from mm_mmload_dump where mcn_desc like '%(FI%'"
                da.Fill(ds)
                YardRew = ds.Tables(0)
            Catch exp As Exception
                YardRew = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function YardInspectedWhl(ByVal lWheelNumber As Long, ByVal lHeatNumber As Long) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "select Thread_Diameter, Bore_Status, Plate_status " & _
                    " from mm_wheel where wheel_number = " & lWheelNumber & " and heat_number = " & lHeatNumber
                da.Fill(ds)
                YardInspectedWhl = ds.Tables(0)
            Catch exp As Exception
                YardInspectedWhl = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function YardInspData(Optional ByVal SavedData As Boolean = False) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                If SavedData Then
                    da.SelectCommand.CommandText = "select convert(varchar(11),yard_inspection_date,103) InspDate, " & _
                        " shift_code shift, a.wheel_number whl , a.heat_number heat, wheel_Disposition Disposition, " & _
                        " tech_Inspector techInsp, lab_Inspector LabInsp, Final_Inspector FinInsp, " & _
                        " Tread_diameter_by_final_inspection TD, Plate_thickness PlateSts, bore_status BoreSts, " & _
                        " b.bore_diameter BoreDia from mm_yard_inspection a inner join mm_wheel b " & _
                        " on a.wheel_number = b.wheel_number and a.heat_number = b.heat_number " & _
                        " where a.yard_Inspection_date = '" & Format(Today.Date, "yyyy-MM-dd") & "' " & _
                        " order by a.sl_no desc  "
                    da.SelectCommand.CommandType = CommandType.Text
                Else
                    da.SelectCommand.CommandText = "mm_sp_si_yardScore"
                    da.SelectCommand.CommandType = CommandType.StoredProcedure
                    da.SelectCommand.Parameters.Add("@Date", SqlDbType.SmallDateTime, 4).Value = Now.Date
                End If
            Catch exp As Exception
                YardInspData = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function InspectedDateShift(ByVal lWheelNumber As Long, ByVal lHeatNumber As Long) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "select InspectedDate LastInspDate , InspectedShift lastInspShift " & _
                    " from mm_unborewheels_inspection where sl_no = (Select top 1 sl_no from mm_unborewheels_inspection " & _
                    " where wheel_number = " & lWheelNumber & " and Heat_Number = " & lHeatNumber & " order by sl_no desc )"
                da.Fill(ds)
                InspectedDateShift = ds.Tables(0)
            Catch exp As Exception
                InspectedDateShift = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function getInspDateShift(ByRef dInspDate As Date, ByRef sInspShift As String, ByVal sFileName As String, ByVal lWheelNumber As Long, ByVal lHeatNumber As Long) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()

            Try
                dInspDate = #1/1/1900#
                sInspShift = ""
                If sFileName = "mm_final_inspection" Then
                    da.SelectCommand.CommandText = "Select  Inspection_Date , Shift_code from mm_final_inspection " & _
                    " where wheel_number = " & lWheelNumber & _
                    " and heat_number = " & lHeatNumber & " and wheel_status like 'p%'"
                End If
                If sFileName <> "mm_final_inspection" Then
                    da.SelectCommand.CommandText = "Select  top 1  yard_Inspection_Date , Shift_code " & _
                    " from mm_yard_inspection where wheel_number = " & lWheelNumber & _
                    " and heat_number = " & lHeatNumber & " and wheel_disposition like 's%p' order by sl_no desc "
                End If
                da.Fill(ds)
                getInspDateShift = ds.Tables(0)
            Catch exp As Exception
                getInspDateShift = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function IsInMaster(ByVal lWheelNumber As Long, ByVal lHeatNumber As Long) As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Connection.Open()
                cmd.Parameters.Add("@Cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                cmd.CommandText = "select @Cnt = count(a.wheel_number)  " & _
                      " from mm_wheel a where a.wheel_number = " & lWheelNumber & _
                      " and a.heat_number = " & lHeatNumber
                cmd.ExecuteScalar()
                IsInMaster = IIf(IsDBNull(cmd.Parameters("@Cnt").Value), 0, cmd.Parameters("@Cnt").Value)
            Catch exp As Exception
                IsInMaster = False
                Throw New Exception(exp.Message)
            Finally
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function GetUnBorePassedWheelLocation(ByVal lWheelNumber As Long, ByVal lHeatNumber As Long) As String
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Connection.Open()
                cmd.Parameters.Add("@Loc", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                cmd.Parameters.Add("@Bore", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                cmd.Parameters.Add("@BoreSts", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                cmd.CommandText = "select @Loc = rtrim(a.location) from mm_wheel a where a.wheel_number = " & lWheelNumber & _
                            " and a.heat_number = " & lHeatNumber & " and  (( a.location = 'clfi' and a.status like 'p%' ) or ( a.location = 'clqc' and a.status like 's%p')) "
                cmd.ExecuteScalar()
                GetUnBorePassedWheelLocation = IIf(IsDBNull(cmd.Parameters("@Loc").Value), "", cmd.Parameters("@Loc").Value)
                If GetUnBorePassedWheelLocation = Nothing Then
                    GetUnBorePassedWheelLocation = ""
                End If
                If GetUnBorePassedWheelLocation.ToLower = "clfi" Then
                    Dim BoreStsInMaster, BoreStatusInTrans As String
                    cmd.CommandText = "select @Bore = rtrim(a.BORE_STATUS) " & _
                        " from mm_wheel a where a.wheel_number = " & lWheelNumber & _
                        " and a.heat_number = " & lHeatNumber
                    cmd.ExecuteScalar()
                    BoreStsInMaster = IIf(IsDBNull(cmd.Parameters("@Bore").Value), "", cmd.Parameters("@Bore").Value)
                    cmd.CommandText = "Select @BoreSts = Bore_Status from mm_final_inspection where wheel_number = " & lWheelNumber & _
                        " and heat_number = " & lHeatNumber & " and wheel_status like 'p%' order by sl_no desc "
                    cmd.ExecuteScalar()
                    BoreStatusInTrans = IIf(IsDBNull(cmd.Parameters("@BoreSts").Value), "", cmd.Parameters("@BoreSts").Value)
                    If BoreStsInMaster.ToLower.Trim.StartsWith("u") OrElse (BoreStsInMaster.ToLower.Trim.StartsWith("b") And BoreStatusInTrans.ToLower.Trim.StartsWith("u")) Then
                        GetUnBorePassedWheelLocation = "CLFI"
                    Else
                        GetUnBorePassedWheelLocation = ""
                    End If
                    BoreStsInMaster = Nothing
                    BoreStatusInTrans = Nothing
                End If
            Catch exp As Exception
                GetUnBorePassedWheelLocation = ""
                Throw New Exception(exp.Message)
            Finally
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function LastInsp(ByVal lWheelNumber As Long, ByVal lHeatNumber As Long) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "Select top 1 convert(varchar(11),InspectedDate,103) InspDt, " & _
                    " InspectedShift Shift, BoreDia, BoreStatus from mm_UnBoreWheels_Inspection " & _
                    " where wheel_number = " & lWheelNumber & " and heat_number = " & lHeatNumber & " " & _
                    " order by sl_no desc "
                da.Fill(ds)
                LastInsp = ds.Tables(0)
            Catch exp As Exception
                LastInsp = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function getBriefHistory(ByVal lWheelNumber As Long, ByVal lHeatNumber As Long) As DataSet
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "mm_sp_WheelHistoryBrief"
                da.SelectCommand.Parameters.Add("@WhlStr", SqlDbType.VarChar, 50).Value = lWheelNumber.ToString.Trim & "/" & lHeatNumber.ToString.Trim
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.Fill(ds)
                getBriefHistory = ds.Copy
            Catch exp As Exception
                getBriefHistory = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function IsWheelDesp(ByVal WheelNumber As Long, ByVal HeatNumber As Long) As String
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.CommandText = "Select  'Wheel is Despatched under DC No : '+dc_number+' Wagno : '+waglorry_number+' to '+Consignee Sts " & _
                " from mm_vw_wheel_Despatched where wheel_number = '" & WheelNumber & "' and heat_number = '" & HeatNumber & "'"
            Dim dr As SqlClient.SqlDataReader
            Try
                cmd.Connection.Open()
                dr = cmd.ExecuteReader
                While dr.Read
                    IsWheelDesp = CStr(dr("Sts")).Trim & ""
                End While
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If IsNothing(dr) = False Then dr.Close()
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
                dr = Nothing
            End Try
        End Function
        Public Shared Function CheckWheel(ByVal WheelNumber As Long, ByVal HeatNumber As Long) As String
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.CommandText = "Select  case when isnull(Despatch_note_Number, '') = '' then 0 else 1 end  Despd , " & _
                " case when Press_status = 'm' then 1 else 0 end  PressSts from mm_wheel where wheel_number = '" & WheelNumber & "' and heat_number = '" & HeatNumber & "'"
            Dim dr As SqlClient.SqlDataReader
            Dim blnDone As Boolean
            Try
                cmd.Connection.Open()
                dr = cmd.ExecuteReader
                While dr.Read
                    blnDone = True
                    If CStr(dr("PressSts")).Trim & "" = "1" Then
                        CheckWheel = " Assembled Wheel"
                        blnDone = False
                    End If
                    If CStr(dr("Despd")).Trim = "1" Then
                        CheckWheel = " Loose Despatched Wheel "
                        blnDone = False
                    End If
                End While
                If blnDone = False Then
                    dr.Close()
                    If IsNothing(cmd) = False Then
                        If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                        cmd.Dispose()
                        cmd = Nothing
                    End If
                Else
                    dr.Close()
                End If
                If blnDone Then
                    cmd.CommandText = "select top 1 * from mm_final_inspection a inner join mm_wheel b " & _
                                      " on a.wheel_number = b.wheel_number and a.heat_number = b.heat_number " & _
                                      " where a.wheel_number = '" & WheelNumber & "' and a.heat_number = '" & HeatNumber & "' order by a.sl_no desc"
                    dr = cmd.ExecuteReader
                    If dr.Read Then
                        Dim strMsg As String = dr("Wheel_status") & ""
                        If Not strMsg.StartsWith("P") Then
                            CheckWheel = "Last Line Insp Sts: " & strMsg
                        Else
                            CheckWheel = "Last Line Insp Sts: " & dr("Bore_status") & " " & strMsg & " " & CDate(dr("Inspection_date")).Date
                            If dr("Bore_Diameter") > 0 Then
                                CheckWheel &= " BoreDia :" & dr("Bore_Diameter") & ""
                            End If
                            CheckWheel &= " OK"
                        End If
                        strMsg = Nothing
                    Else
                        CheckWheel = "Not inspected in Line by Final Inspection"
                    End If
                End If
            Catch exp As Exception
                CheckWheel &= " Data Retrieval error : " & exp.Message
            Finally
                If IsNothing(dr) = False Then
                    dr.Close()
                End If
                If IsNothing(cmd) = False Then
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                    dr = Nothing
                    blnDone = Nothing
                End If
            End Try
        End Function
        Public Shared Function ShowScore(ByVal BoDate As Date, ByVal Shift As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@InspectedDate", SqlDbType.SmallDateTime, 4).Value = BoDate
            da.SelectCommand.Parameters.Add("@InspectedShift", SqlDbType.VarChar, 1).Value = Shift
            Try
                da.SelectCommand.CommandText = "select Bore_Status BoreSts, Description WhlType, " & _
                    " whlscount Score from mm_vw_si_BoreInspection " & _
                    " where inspecteddate = @InspectedDate and inspectedshift = @InspectedShift"
                da.Fill(ds)
                ShowScore = ds.Tables(0)
            Catch exp As Exception
                ShowScore = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function BoreDiaCheck(ByVal Whl As Long, ByVal Heat As Long, ByVal Dia As Decimal) As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Connection.Open()
                cmd.Parameters.Add("@Whl", SqlDbType.BigInt, 8).Value = Whl
                cmd.Parameters.Add("@Heat", SqlDbType.BigInt, 8).Value = Heat
                cmd.Parameters.Add("@Dia", SqlDbType.Float, 8).Value = Dia
                cmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                cmd.CommandText = "select @cnt = count(*) " & _
                         " from mm_ProductwiseTreadAndBoreSizes a inner join mm_product_master b " & _
                         " on a.productcode = b.Product_code inner join mm_wheel c " & _
                         " on b.description = c.description " & _
                         " where minTreadDia is not null and b.description = c.description " & _
                         " and wheel_Number = @Whl and Heat_number = @Heat " & _
                         " and @Dia between minBoreDia and OverSizeMax "
                cmd.ExecuteScalar()
                BoreDiaCheck = IIf(IsDBNull(cmd.Parameters("@cnt").Value), 0, cmd.Parameters("@cnt").Value)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function LastBoreDate() As Date
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Connection.Open()
                cmd.Parameters.Add("@LastInspDate", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output
                cmd.CommandText = "Select @LastInspDate = max(InspectedDate)  from mm_unborewheels_inspection  "
                cmd.ExecuteScalar()
                LastBoreDate = IIf(IsDBNull(cmd.Parameters("@LastInspDate").Value), CDate("1900-01-01"), cmd.Parameters("@LastInspDate").Value)
            Catch exp As Exception
                LastBoreDate = CDate("1900-01-01")
                Throw New Exception(exp.Message)
            Finally
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function GetDetails(ByVal BoDate As Date, ByVal Shift As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@BoDate", SqlDbType.SmallDateTime, 4).Value = BoDate
            da.SelectCommand.Parameters.Add("@Shift", SqlDbType.VarChar, 1).Value = Shift
            da.SelectCommand.CommandText = "select row_number() over ( order by sl_No desc,  savedDateTime desc ) Sl , " & _
                " convert(varchar,InspectedDate,103) changeDt, " & _
                " InspectedShift Sh, wheel_number Whl, Heat_number Heat, BoreStatus BSts , BoreDia BDia , Remarks," & _
                " convert(varchar, SavedDateTime,103) + ' ' +convert(varchar(5),SavedDateTime,108)  SavedTime , Inspector " & _
                " from mm_unborewheels_inspection " & _
                " where InspectedDate = @BoDate and InspectedShift = @Shift " & _
                " order by sl_No desc,  savedDateTime desc "
            Try
                da.Fill(ds)
                GetDetails = ds.Tables(0)
            Catch exp As Exception
                GetDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Function Save(ByVal WheelNumber As Long, ByVal HeatNumber As Long, ByVal Inspector As String, ByVal BoreWheel As Boolean, ByVal BoreDate As Date, ByVal Shift As String, ByVal BoreDia As Decimal, ByVal Remarks As String) As String
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            oCmd.Parameters.Add("@wheel_Number", SqlDbType.BigInt, 8).Value = Val(WheelNumber)
            oCmd.Parameters.Add("@Heat_Number", SqlDbType.BigInt, 8).Value = Val(HeatNumber)
            oCmd.Parameters.Add("@Inspector", SqlDbType.VarChar, 6).Value = Inspector
            oCmd.Parameters.Add("@BoreStatus", SqlDbType.VarChar, 5).Value = IIf(BoreWheel, "UnBore", "B")
            oCmd.Parameters.Add("@BoreInspDate", SqlDbType.SmallDateTime, 4).Value = BoreDate
            oCmd.Parameters.Add("@BoreInspShift", SqlDbType.VarChar, 1).Value = Shift
            oCmd.Parameters.Add("@SavedDateTime", SqlDbType.DateTime, 8).Value = Now
            oCmd.Parameters.Add("@BoreDia", SqlDbType.Decimal, 9, 3).Value = BoreDia
            oCmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 50).Value = Remarks
            Dim sqlstrCheck As String
            Dim sqlstrInsert As String
            Dim sqlstrUpdate As String
            Dim sqlstrMasterUpdate As String

            sqlstrCheck = "Select count(*) from mm_UnBoreWheels_Inspection where wheel_number  = @Wheel_Number " & _
                                  " and heat_number = @Heat_Number and InspectedDate= @BoreInspDate and InspectedShift =@BoreInspShift "
            sqlstrInsert = "Insert into mm_UnBoreWheels_Inspection (InspectedDate, InspectedShift," & _
                                 "Inspector, wheel_number, Heat_number,  BoreStatus, BoreDia, Remarks, SavedDateTime) values (" & _
                                 " @BoreInspDate, @BoreInspShift, @Inspector, @wheel_number, @Heat_Number, @BoreStatus, @BoreDia, " & _
                                 " @Remarks, @SavedDateTime)"
            If BoreDia > 0 Then
                sqlstrUpdate = "Update mm_UnBoreWheels_Inspection set BoreStatus = @BoreStatus, BoreDia = @BoreDia, Remarks = @Remarks, " & _
                                       "InspectedDate = @BoreInspDate, InspectedShift = @BoreInspShift, SavedDateTime = @SavedDateTime  where wheel_number = " & _
                                       " @Wheel_Number and Heat_Number = @Heat_Number and InspectedDate= @BoreInspDate and InspectedShift =@BoreInspShift "
            Else
                sqlstrUpdate = "Update mm_UnBoreWheels_Inspection set BoreStatus = @BoreStatus,  Remarks = @Remarks, " & _
                           "InspectedDate = @BoreInspDate, InspectedShift = @BoreInspShift, SavedDateTime = @SavedDateTime  where wheel_number = " & _
                           " @Wheel_Number and Heat_Number = @Heat_Number  and InspectedDate= @BoreInspDate and InspectedShift = @BoreInspShift and BoreStatus = @BoreStatus"
            End If
            If BoreDia > 0 Then
                sqlstrMasterUpdate = "Update mm_wheel set Bore_Status = @BoreStatus, Bore_Diameter = @BoreDia where wheel_Number = @Wheel_Number and " & _
                                                       " Heat_number = @Heat_Number "
            Else
                sqlstrMasterUpdate = "Update mm_wheel set Bore_Status = @BoreStatus where wheel_Number = @Wheel_Number and " & _
                                                       " Heat_number = @Heat_Number "
            End If
            Try
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                oCmd.CommandText = sqlstrCheck
                Dim cnt As Integer = oCmd.ExecuteScalar()
                If cnt > 0 Then
                    oCmd.CommandText = sqlstrUpdate
                Else
                    oCmd.CommandText = sqlstrInsert
                End If
                oCmd.ExecuteNonQuery()
                oCmd.CommandText = sqlstrMasterUpdate
                oCmd.ExecuteNonQuery()
                Save = "Saved"
            Catch exp As Exception
                Save = exp.Message
            Finally
                If Save = "Saved" Then
                    oCmd.Transaction.Commit()
                Else
                    oCmd.Transaction.Rollback()
                End If
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
            sqlstrCheck = Nothing
            sqlstrInsert = Nothing
            sqlstrUpdate = Nothing
            sqlstrMasterUpdate = Nothing
        End Function
        Public Function updatePassInGrid(ByVal WheelNumber As Long, ByVal HeatNumber As Long) As Boolean
            Dim sqlcmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            sqlcmd.CommandText = "Update c set c.wheelDisposition = 'SY_P' from  " & _
                                 " mm_yardInspection_technical a inner join mm_yardInspection_magna  b on b.techslno = a.slno inner join mm_yardInspection_final  c on " & _
                                 " c.magslno = b.slno where a.wheelNumber = @wheelNumber and a.heatNumber = @heatNumber and b.wheelDisposition = 'SY_P'"
            sqlcmd.Parameters.Add("@WheelNumber", SqlDbType.BigInt, 8).Value = CLng(WheelNumber)
            sqlcmd.Parameters.Add("@HeatNumber", SqlDbType.BigInt, 8).Value = CLng(HeatNumber)
            Try
                sqlcmd.Connection.Open()
                sqlcmd.ExecuteNonQuery()
                sqlcmd.CommandText = "SELECT  COUNT(*) from  " & _
                                 "  mm_yardInspection_technical a inner join mm_yardInspection_magna  b on b.techslno = a.slno inner join mm_yardInspection_final  c on " & _
                                 " c.magslno = b.slno where a.wheelNumber = @wheelNumber and a.heatNumber = @heatNumber AND c.wheelDisposition = 'SY_P'"
                updatePassInGrid = sqlcmd.ExecuteScalar
            Catch exp As Exception
                updatePassInGrid = False
                Throw New Exception(exp.Message)
            Finally
                If sqlcmd.Connection.State = ConnectionState.Open Then sqlcmd.Connection.Close()
                sqlcmd.Dispose()
                sqlcmd = Nothing
            End Try
        End Function
        Public Function VerifyUpdate(ByVal WheelNumber As Long, ByVal HeatNumber As Long, ByVal TreadDia As Decimal, ByVal BoreSts As String, ByVal PlateSts As String) As Boolean
            Dim sqlcmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            sqlcmd.CommandText = "Update c set c.TreadDia = " & CDec(TreadDia) & ", c.borestatus = '" & BoreSts.ToUpper & "', c.PlateStatus = '" & PlateSts.ToUpper & "' from  " & _
                                 "  mm_yardInspection_technical a inner join mm_yardInspection_magna  b on b.techslno = a.slno inner join mm_yardInspection_final  c on " & _
                                 " c.magslno = b.slno where a.wheelNumber = @wheelNumber and a.heatNumber = @heatNumber"
            sqlcmd.Parameters.Add("@WheelNumber", SqlDbType.BigInt, 8).Value = WheelNumber
            sqlcmd.Parameters.Add("@HeatNumber", SqlDbType.BigInt, 8).Value = HeatNumber
            Try
                sqlcmd.Connection.Open()
                sqlcmd.ExecuteNonQuery()
                sqlcmd.CommandText = "select count(*) from  " & _
                                "  mm_yardInspection_technical a inner join mm_yardInspection_magna  b on b.techslno = a.slno inner join mm_yardInspection_final  c on " & _
                                " c.magslno = b.slno where a.wheelNumber = @wheelNumber and a.heatNumber = @heatNumber and c.TreadDia = " & CDec(TreadDia) & " and  c.borestatus = '" & BoreSts.ToUpper & "' and c.PlateStatus = '" & PlateSts.ToUpper & "'"
                VerifyUpdate = sqlcmd.ExecuteScalar
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If sqlcmd.Connection.State = ConnectionState.Open Then sqlcmd.Connection.Close()
                sqlcmd.Dispose()
                sqlcmd = Nothing
            End Try
        End Function
        Public Function Update(ByVal WheelNumber As Long, ByVal HeatNumber As Long, ByVal TreadDia As Decimal, ByVal BoreSts As String, ByVal PlateSts As String, ByVal BoreDia As Decimal) As Boolean
            Dim sqlcmd1 As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            sqlcmd1.CommandText = "update c set c.TreadDia = @TreadDia , c.BoreStatus = @BoreSts  , " & _
                " c.PlateStatus = @PlateSts, c.boredia = " & CDec(BoreDia) & " from mm_yardInspection_technical a " & _
                " inner join mm_yardInspection_magna  b on b.techslno = a.slno inner join mm_yardInspection_final  c " & _
                " on c.magslno = b.slno where wheelnumber = " & WheelNumber & " " & _
                " and heatnumber = " & HeatNumber

            sqlcmd1.Parameters.Add("@TreadDia", SqlDbType.Float, 8).Value = CDec(TreadDia)
            sqlcmd1.Parameters.Add("@BoreSts", SqlDbType.VarChar, 50).Value = BoreSts.ToUpper
            sqlcmd1.Parameters.Add("@PlateSts", SqlDbType.VarChar, 50).Value = PlateSts.ToUpper
            Try
                sqlcmd1.Connection.Open()
                Update = sqlcmd1.ExecuteNonQuery()
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If sqlcmd1.Connection.State = ConnectionState.Open Then sqlcmd1.Connection.Close()
                sqlcmd1.Dispose()
                sqlcmd1 = Nothing
            End Try
        End Function
        Public Function SaveYardWhl(text As String, text1 As String, ByVal WheelNumber As Long, ByVal HeatNumber As Long, ByVal TreadDia As Decimal, ByVal BoreSts As String, ByVal PlateSts As String, ByVal BoreDia As Decimal, ByVal UserID As String) As Boolean
            Dim sqlcmd1 As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim done As Boolean
            sqlcmd1.CommandText = "update c set c.TreadDia = @TreadDia , c.BoreStatus = @BoreSts  , c.PlateStatus = @PlateSts, c.boredia = " & CDec(BoreDia) & " " & _
                " from mm_yardInspection_technical a inner join mm_yardInspection_magna  b " & _
                " on b.techslno = a.slno inner join mm_yardInspection_final  c on c.magslno = b.slno " & _
                " where wheelnumber = " & WheelNumber & " and heatnumber = " & HeatNumber

            Try
                sqlcmd1.Parameters.Add("@TreadDia", SqlDbType.Float, 8).Value = CDec(TreadDia)
                sqlcmd1.Parameters.Add("@BoreSts", SqlDbType.VarChar, 50).Value = BoreSts.ToUpper
                sqlcmd1.Parameters.Add("@PlateSts", SqlDbType.VarChar, 50).Value = PlateSts.ToUpper
                sqlcmd1.Connection.Open()
                sqlcmd1.ExecuteNonQuery()
                done = True
            Catch exp As Exception
                done = False
                Throw New Exception("Data Error : " & WheelNumber & "/" & HeatNumber)
            Finally
                If sqlcmd1.Connection.State = ConnectionState.Open Then sqlcmd1.Connection.Close()
                sqlcmd1.Dispose()
                sqlcmd1 = Nothing
            End Try
            If done = False Then
                Exit Function
            End If

            Dim sqlcmd As New SqlClient.SqlCommand()
            sqlcmd.Connection = rwfGen.Connection.ConObj
            Try
                sqlcmd.Connection.Open()
                sqlcmd.Transaction = sqlcmd.Connection.BeginTransaction
                sqlcmd.CommandText = "insert into mm_yard_Inspection ( yard_inspection_date, shift_code, " & _
                    " wheel_number, heat_number, wheel_disposition, final_inspector, lab_inspector, tech_inspector, " & _
                    " tread_diameter_by_final_Inspection, plate_thickness_by_final_inspection, pre_location, " & _
                    " pre_status , lab_remarks_date, lab_remarks_shift, final_inspection_date, final_inspection_shift, " & _
                    " Bore_diameter_by_final_inspection)" & _
                    " select '" & Format(Today.Date, "yyyy-MM-dd") & "', 'G', a.wheelnumber, a.heatnumber, " & _
                    " case when isnull(c.wheeldisposition,'') = '' then b.wheeldisposition else c.wheeldisposition end, " & _
                    " '" & CStr(UserID) & "', b.empCode, a.EmpCode, c.treadDia, c.plateStatus, " & _
                    " a.preLocation , a.lastmcnopn, isnull(b.saveDateTime, b.dt ), b.shift, getdate(), 'G', " & _
                    " " & CDec(BoreDia) & "  from mm_yardInspection_technical a inner join " & _
                    " mm_yardInspection_magna  b on b.techslno = a.slno inner join mm_yardInspection_final  c " & _
                    " on c.magslno = b.slno where " & _
                    " (((case when isnull(c.wheeldisposition,'') = '' then b.wheeldisposition else c.wheeldisposition end = 'SY_P' and c.treadDia > 0 ) " & _
                    " or (case when isnull(c.wheeldisposition,'') = '' then b.wheeldisposition else c.wheeldisposition end <> 'SY_P' )) " & _
                    " and a.wheelnumber =  " & WheelNumber & " and a.heatnumber = " & HeatNumber & ")"
                sqlcmd.ExecuteNonQuery()
                sqlcmd.CommandText = " update d set d.location = 'CLQC' , " & _
                    " d.status = case when isnull(c.wheeldisposition,'') = '' then b.wheeldisposition else c.wheeldisposition end, " & _
                    " d.thread_diameter = convert(float,c.treaddia) , d.bore_status = case when isnull(c.borestatus,'') = 'OK' then 'B' else c.borestatus end , " & _
                    " d.bore_diameter = " & CDec(BoreDia) & " , d.plate_thickness = c.platestatus from  " & _
                    " mm_yardInspection_technical a inner join mm_yardInspection_magna  b on b.techslno = a.slno " & _
                    " inner join mm_yardInspection_final  c on c.magslno = b.slno  inner join mm_wheel d " & _
                    " on d.wheel_number = a.wheelnumber and d.heat_number = a.heatnumber " & _
                    " where a.wheelnumber = " & WheelNumber & " and a.heatnumber = " & HeatNumber
                sqlcmd.ExecuteNonQuery()
                sqlcmd.CommandText = "select b.slno from mm_yardInspection_technical a inner join " & _
                    " mm_yardInspection_magna b on b.techslno = a.slno inner join mm_yardInspection_final c " & _
                    " on c.magslno = b.slno  where  a.wheelnumber = " & WheelNumber & " and a.heatnumber = " & HeatNumber
                Dim magslno As Long
                magslno = sqlcmd.ExecuteScalar
                sqlcmd.CommandText = "delete mm_yardInspection_final where magslno = " & magslno & " ; " & _
                    " delete mm_yardInspection_magna where slno = " & magslno & " ; " & _
                    " delete mm_yardInspection_technical where  wheelnumber = " & WheelNumber & " " & _
                    " and heatnumber = " & HeatNumber
                sqlcmd.ExecuteNonQuery()
                done = True
                sqlcmd.CommandText = "select count(*) from mm_wheel a where wheel_number = " & WheelNumber & " " & _
                    " and heat_number = " & HeatNumber & " and location = 'CLQC' and isnull(status,'') like  '[x,w,sy,r]%'"
                If sqlcmd.ExecuteScalar = 0 Then
                    sqlcmd.CommandText = "Select count(*) from mm_yard_inspection a inner join mm_wheel b " & _
                    " on a.wheel_number = b.wheel_number and a.heat_number = b.heat_number and " & _
                    " b.status = a.wheel_disposition and b.thread_diameter = a.tread_diameter_by_final_Inspection " & _
                    " where a.yard_inspection_date = convert(smalldatetime, convert(varchar(11), getdate())) " & _
                    " and a.wheel_number = " & WheelNumber & " and a.heat_number = " & HeatNumber
                    If sqlcmd.ExecuteScalar = 0 Then done = False
                Else
                    sqlcmd.CommandText = "Select count(*) from mm_yard_inspection a inner join mm_wheel b " & _
                    " on a.wheel_number = b.wheel_number and a.heat_number = b.heat_number and  " & _
                    " b.status = a.wheel_disposition and b.thread_diameter = a.tread_diameter_by_final_Inspection " & _
                    " where a.yard_inspection_date = convert(smalldatetime, convert(varchar(11), getdate())) " & _
                    " and a.wheel_number = " & WheelNumber & " and a.heat_number = " & HeatNumber
                    If sqlcmd.ExecuteScalar = 0 Then done = False
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If done Then
                    sqlcmd.Transaction.Commit()
                Else
                    sqlcmd.Transaction.Rollback()
                End If
                If sqlcmd.Connection.State = ConnectionState.Open Then sqlcmd.Connection.Close()
                sqlcmd.Dispose()
                sqlcmd = Nothing
            End Try
            Return done
        End Function
        Public Function SaveYardWhlReInspect(ByVal WheelNumber As Long, ByVal HeatNumber As Long, ByVal BoreSts As String, ByVal Disposition As String, ByVal UserID As String, ByVal LabInsp As String, ByVal TechInsp As String, ByVal Treaddia As Decimal, ByVal PlateSts As String, ByVal Prestatus As String) As Boolean
            Dim sqlcmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            sqlcmd.Parameters.Add("@yard_inspection_date", SqlDbType.SmallDateTime, 4).Value = Today.Date
            sqlcmd.Parameters.Add("@shift_code", SqlDbType.VarChar, 1).Value = "G"
            sqlcmd.Parameters.Add("@wheel_number", SqlDbType.BigInt, 8).Value = Val(WheelNumber)
            sqlcmd.Parameters.Add("@heat_number", SqlDbType.BigInt, 8).Value = Val(HeatNumber)
            sqlcmd.Parameters.Add("@wheel_disposition", SqlDbType.VarChar, 50).Direction = ParameterDirection.Input
            sqlcmd.Parameters.Add("@final_inspector", SqlDbType.VarChar, 6).Value = UserID
            sqlcmd.Parameters.Add("@lab_inspector", SqlDbType.VarChar, 6).Value = LabInsp
            sqlcmd.Parameters.Add("@tech_inspector", SqlDbType.VarChar, 6).Value = TechInsp
            sqlcmd.Parameters.Add("@tread_diameter_by_final_Inspection", SqlDbType.Float, 8).Value = CDbl(Treaddia)
            sqlcmd.Parameters.Add("@plate_thickness_by_final_inspection", SqlDbType.VarChar, 50).Value = PlateSts
            sqlcmd.Parameters.Add("@pre_location", SqlDbType.VarChar, 50).Value = "CLQC"
            sqlcmd.Parameters.Add("@pre_status", SqlDbType.VarChar, 50).Value = Prestatus
            sqlcmd.Parameters.Add("@lab_remarks_date", SqlDbType.SmallDateTime, 4).Value = CDate("1/1/1900")
            sqlcmd.Parameters.Add("@lab_remarks_shift", SqlDbType.VarChar, 1).Value = "G"
            sqlcmd.Parameters.Add("@final_inspection_date", SqlDbType.SmallDateTime, 4).Value = Now.Date
            sqlcmd.Parameters.Add("@final_inspection_shift", SqlDbType.VarChar, 1).Value = "G"
            sqlcmd.Parameters.Add("@bore_Status", SqlDbType.VarChar, 50).Value = BoreSts

            Try
                Select Case Disposition
                    Case "P"
                        sqlcmd.Parameters("@wheel_disposition").Value = "SY_P"
                    Case "W"
                        sqlcmd.Parameters("@wheel_disposition").Value = "W" & Disposition
                    Case "R"
                        sqlcmd.Parameters("@wheel_disposition").Value = "W" & Disposition
                    Case Else
                        sqlcmd.Parameters("@wheel_disposition").Value = ""
                End Select
            Catch exp As Exception
                Throw New Exception(exp.Message)
            End Try
            Dim strInsertInspData, strUpdateMaster, strCheckUpdateMaster, strCheckInspData As String
            strInsertInspData = "insert into mm_yard_Inspection ( yard_inspection_date, shift_code, " & _
                " wheel_number, heat_number, wheel_disposition, final_inspector, lab_inspector, tech_inspector, " & _
                " tread_diameter_by_final_Inspection, plate_thickness_by_final_inspection, pre_location, " & _
                " pre_status , lab_remarks_date, lab_remarks_shift, final_inspection_date, final_inspection_shift) " & _
                " values (@yard_inspection_date, @shift_code, @wheel_number, @heat_number, @wheel_disposition, " & _
                " @final_inspector, @lab_inspector, @tech_inspector, @tread_diameter_by_final_Inspection, " & _
                " @plate_thickness_by_final_inspection, @pre_location, @pre_status , @lab_remarks_date, " & _
                " @lab_remarks_shift, @final_inspection_date, @final_inspection_shift)"
            strUpdateMaster = "Update mm_wheel set location = 'CLQC', status =  @wheel_disposition , " & _
                " Bore_Status = @Bore_Status, thread_diameter = @tread_diameter_by_final_Inspection, " & _
                " plate_thickness = @plate_thickness_by_final_inspection where wheel_number = @wheel_number " & _
                " and heat_number = @heat_number"
            strCheckUpdateMaster = "Select count(*) from mm_wheel where wheel_number = @wheel_number " & _
                " and heat_number = @heat_number and location = 'CLQC' and status = @wheel_disposition " & _
                " and Bore_Status = @Bore_Status and thread_diameter = @tread_diameter_by_final_Inspection " & _
                " and plate_thickness = @plate_thickness_by_final_inspection "
            strCheckInspData = "Select Count(*) from mm_yard_Inspection where wheel_number = @wheel_number " & _
                " and heat_number = @heat_number and yard_inspection_date = @yard_inspection_date " & _
                " and shift_code = 'G' and wheel_disposition = @wheel_disposition and " & _
                " tread_diameter_by_final_Inspection = @tread_diameter_by_final_Inspection " & _
                " and plate_thickness_by_final_inspection = @plate_thickness_by_final_inspection "

            Dim blnSaved As Boolean
            Try
                sqlcmd.Connection.Open()
                sqlcmd.Transaction = sqlcmd.Connection.BeginTransaction
                sqlcmd.CommandText = strInsertInspData
                sqlcmd.ExecuteNonQuery()
                sqlcmd.CommandText = strUpdateMaster
                sqlcmd.ExecuteNonQuery()
                sqlcmd.CommandText = strCheckInspData
                blnSaved = sqlcmd.ExecuteScalar > 0
                If blnSaved = True Then
                    sqlcmd.CommandText = strCheckUpdateMaster
                    blnSaved = sqlcmd.ExecuteScalar > 0
                End If
            Catch exp As Exception
                blnSaved = False
                Throw New Exception("SAVE FAILED : " & exp.Message)
            Finally
                If blnSaved = False Then
                    sqlcmd.Transaction.Rollback()
                Else
                    sqlcmd.Transaction.Commit()
                End If
                If sqlcmd.Connection.State = ConnectionState.Open Then sqlcmd.Connection.Close()
                sqlcmd.Dispose()
                sqlcmd = Nothing
            End Try
        End Function
        Public Function yardInspectionMagna(ByVal WheelNumber As Long, ByVal HeatNumber As Long, ByVal Rej As String) As Boolean
            Dim sqlcmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim done As Boolean
            sqlcmd.CommandText = " Update c set c.treaddia = 0, c.platestatus = '', c.borestatus = '', c.wheelDisposition = 'R'+'" & Rej & "' from  " & _
                                 " mm_yardInspection_technical a inner join mm_yardInspection_magna  b on b.techslno = a.slno inner join mm_yardInspection_final  c on c.magslno = b.slno " & _
                                 " where a.wheelNumber = @wheelNumber and a.heatNumber = @heatNumber AND b.wheelDisposition = 'SY_P'"
            sqlcmd.Parameters.Add("@WheelNumber", SqlDbType.BigInt, 8).Value = CLng(WheelNumber)
            sqlcmd.Parameters.Add("@HeatNumber", SqlDbType.BigInt, 8).Value = CLng(HeatNumber)
            Try
                sqlcmd.Connection.Open()
                sqlcmd.ExecuteNonQuery()
                sqlcmd.CommandText = "SELECT  COUNT(*) from  " & _
                                 "  mm_yardInspection_technical a inner join mm_yardInspection_magna  b on b.techslno = a.slno inner join mm_yardInspection_final  c on " & _
                                 " c.magslno = b.slno where a.wheelNumber = @wheelNumber and a.heatNumber = @heatNumber AND c.wheelDisposition = 'R'+'" & Rej & "'"
                done = sqlcmd.ExecuteScalar
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If sqlcmd.Connection.State = ConnectionState.Open Then sqlcmd.Connection.Close()
                sqlcmd.Dispose()
                sqlcmd = Nothing
            End Try
        End Function
        Public Function SaveHeats(ByVal TableName As String, ByVal Heat As Long, ByVal FromDate As Date, ByVal ToDate As Date, ByVal Message As String, ByVal EmpCode As String) As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@heat_number", SqlDbType.BigInt, 8).Value = Val(Heat)
            cmd.Parameters.Add("@HoldFromDate", SqlDbType.SmallDateTime, 4).Value = CDate(FromDate)
            cmd.Parameters.Add("@HoldToDate", SqlDbType.SmallDateTime, 4).Value = CDate(ToDate)
            cmd.Parameters.Add("@Message", SqlDbType.VarChar, 150).Value = Message.Trim
            cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 10).Value = EmpCode.Trim
            cmd.Parameters.Add("@SavedDateTime", SqlDbType.DateTime, 8).Value = Now
            cmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            If TableName = "mm_HoldHeatsFromDespatch" Then
                cmd.CommandText = "Select @cnt = count(heat_number) from mm_HoldHeatsFromDespatch where heat_number = " & Val(Heat)
                cmd.Connection.Open()
                cmd.ExecuteScalar()
                If IIf(IsDBNull(cmd.Parameters("@cnt").Value), 0, cmd.Parameters("@cnt").Value) = 0 Then
                    cmd.CommandText = "insert into mm_HoldHeatsFromDespatch ( heat_number , Message , HoldFromDate , HoldToDate , EmpCode , SavedDateTime )" & _
                    " values (  @heat_number , @Message , @HoldFromDate , @HoldToDate , @EmpCode , @SavedDateTime ) "
                Else
                    cmd.CommandText = " UPDATE mm_HoldHeatsFromDespatch" & _
                    " set HoldFromDate = @HoldFromDate , HoldToDate = @HoldToDate ," & _
                    " Message = @Message , EmpCode = @EmpCode , SavedDateTime = @SavedDateTime " & _
                    " where heat_number = @heat_number "
                End If
            Else
                cmd.CommandText = "Select @cnt = count(heat_number) from mm_HoldHeatsFromFIPassing where heat_number = " & Val(Heat)
                cmd.Connection.Open()
                cmd.ExecuteScalar()
                If IIf(IsDBNull(cmd.Parameters("@cnt").Value), 0, cmd.Parameters("@cnt").Value) = 0 Then
                    cmd.CommandText = "insert into mm_HoldHeatsFromFIPassing ( heat_number , Message , HoldFromDate , HoldToDate , EmpCode , SavedDateTime )" & _
                    " values (  @heat_number , @Message , @HoldFromDate , @HoldToDate , @EmpCode , @SavedDateTime ) "
                Else
                    cmd.CommandText = " UPDATE mm_HoldHeatsFromFIPassing" & _
                    " set HoldFromDate = @HoldFromDate , HoldToDate = @HoldToDate ," & _
                    " Message = @Message , EmpCode = @EmpCode , SavedDateTime = @SavedDateTime " & _
                    " where heat_number = @heat_number "
                End If
            End If
            Try
                SaveHeats = cmd.ExecuteNonQuery()
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        'Public Function SaveYardWheelMagna(ByVal txtWheelNumber As Double, ByVal txtHeatNumber As Double, ByVal txtDate As Date, ByVal lblShift As String, ByVal txtTechnicalAuthority As String, ByVal txtBdNo As String, ByVal lblStatus As String, ByVal lblLoca As String, ByVal lblLabAuthority As String, ByVal btnSave As String, ByVal txtBHN As Integer, ByVal txtTreadDiameter As Double, ByVal txtBorestatus As String, ByVal txtPlateThickness As String) As Boolean
        '    Dim strAddTechData, strAddLabData, strAddFinData, strGetTechId, strGetLabId, strGetFinId As String
        '    Dim TechParams(8), LabParams(7), FinParams(4), whlparam(1) As SqlClient.SqlParameter

        '    whlparam(0) = New SqlClient.SqlParameter("@wheelNumber", SqlDbType.BigInt, 8)
        '    whlparam(1) = New SqlClient.SqlParameter("@heatNumber", SqlDbType.BigInt, 8)
        '    whlparam(0).Direction = ParameterDirection.Input
        '    whlparam(1).Direction = ParameterDirection.Input

        '    FinParams(0) = New SqlClient.SqlParameter("@MagSlNo", SqlDbType.BigInt, 8)
        '    FinParams(1) = New SqlClient.SqlParameter("@TreadDia", SqlDbType.Decimal, 4)
        '    FinParams(2) = New SqlClient.SqlParameter("@BoreStatus", SqlDbType.VarChar, 10)
        '    FinParams(3) = New SqlClient.SqlParameter("@PlateStatus", SqlDbType.VarChar, 10)
        '    FinParams(4) = New SqlClient.SqlParameter("@SaveDateTime", SqlDbType.SmallDateTime, 4)

        '    FinParams(0).Direction = ParameterDirection.Input
        '    FinParams(1).Direction = ParameterDirection.Input
        '    FinParams(2).Direction = ParameterDirection.Input
        '    FinParams(3).Direction = ParameterDirection.Input
        '    FinParams(4).Direction = ParameterDirection.Input

        '    LabParams(0) = New SqlClient.SqlParameter("@dt", SqlDbType.SmallDateTime, 4)
        '    LabParams(1) = New SqlClient.SqlParameter("@Shift", SqlDbType.VarChar, 1)
        '    LabParams(2) = New SqlClient.SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
        '    LabParams(3) = New SqlClient.SqlParameter("@TechSlNo", SqlDbType.BigInt, 8)
        '    LabParams(4) = New SqlClient.SqlParameter("@WheelDisposition", SqlDbType.VarChar, 50)
        '    LabParams(5) = New SqlClient.SqlParameter("@bhn", SqlDbType.Int, 4)
        '    LabParams(6) = New SqlClient.SqlParameter("@IsXCorPass", SqlDbType.Float, 8)
        '    LabParams(7) = New SqlClient.SqlParameter("@SaveDateTime", SqlDbType.SmallDateTime, 4)

        '    LabParams(7).Direction = ParameterDirection.Input
        '    LabParams(6).Direction = ParameterDirection.Input
        '    LabParams(5).Direction = ParameterDirection.Input
        '    LabParams(4).Direction = ParameterDirection.Input
        '    LabParams(3).Direction = ParameterDirection.Input
        '    LabParams(2).Direction = ParameterDirection.Input
        '    LabParams(1).Direction = ParameterDirection.Input
        '    LabParams(0).Direction = ParameterDirection.Input


        '    TechParams(0) = New SqlClient.SqlParameter("@dt", SqlDbType.SmallDateTime, 4)
        '    TechParams(1) = New SqlClient.SqlParameter("@Shift", SqlDbType.VarChar, 1)
        '    TechParams(2) = New SqlClient.SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
        '    TechParams(3) = New SqlClient.SqlParameter("@WheelNumber", SqlDbType.BigInt, 8)
        '    TechParams(4) = New SqlClient.SqlParameter("@HeatNumber", SqlDbType.BigInt, 8)
        '    TechParams(5) = New SqlClient.SqlParameter("@BoardNo", SqlDbType.VarChar, 5)
        '    TechParams(6) = New SqlClient.SqlParameter("@SaveDateTime", SqlDbType.SmallDateTime, 4)
        '    TechParams(7) = New SqlClient.SqlParameter("@LastMcnOpn", SqlDbType.VarChar, 50)
        '    TechParams(8) = New SqlClient.SqlParameter("@PreLocation", SqlDbType.VarChar, 10)

        '    TechParams(8).Direction = ParameterDirection.Input
        '    TechParams(7).Direction = ParameterDirection.Input
        '    TechParams(6).Direction = ParameterDirection.Input
        '    TechParams(5).Direction = ParameterDirection.Input
        '    TechParams(4).Direction = ParameterDirection.Input
        '    TechParams(3).Direction = ParameterDirection.Input
        '    TechParams(2).Direction = ParameterDirection.Input
        '    TechParams(1).Direction = ParameterDirection.Input
        '    TechParams(0).Direction = ParameterDirection.Input

        '    strAddTechData = "insert into mm_YardInspection_Technical ( Dt, Shift, EmpCode, WheelNumber, HeatNumber, BoardNo, LastMcnOpn, PreLocation, SaveDateTime ) values ( @Dt, @Shift, @EmpCode, @WheelNumber, @HeatNumber, @BoardNo, @LastMcnOpn, @PreLocation, @SaveDateTime )  "
        '    strGetTechId = "select a.slNo from mm_YardInspection_Technical a where a.wheelNumber = @wheelNumber and a.heatNumber = @heatNumber"
        '    strAddLabData = "insert into mm_YardInspection_Magna (Dt, Shift, EmpCode, TechSlNo, WheelDisposition, BHN, IsXCorPass, SaveDateTime ) values (@Dt, @Shift, @EmpCode, @TechSlNo, @WheelDisposition, @BHN, @IsXCorPass, @SaveDateTime )"
        '    strGetLabId = "select a.slNo from mm_YardInspection_Magna a inner join mm_YardInspection_Technical b on a.techslno = b.slno where b.wheelNumber = @wheelNumber and b.heatNumber = @heatNumber"
        '    strAddFinData = "insert into mm_YardInspection_Final ( MagSlNo, TreadDia, BoreStatus, PlateStatus ) values ( @MagSlNo, @TreadDia, @BoreStatus, @PlateStatus )"
        '    strGetFinId = "select count(*) from mm_YardInspection_Final a inner join mm_YardInspection_Magna b on a.magslno = b.slno inner join  mm_YardInspection_Technical c on b.techslno = c.slno where c.wheelNumber = @wheelNumber and c.heatNumber = @heatNumber" ' after verified for the wheel will be deleted.
        '    Try
        '        whlparam(0).Value = CLng(txtWheelNumber)
        '        whlparam(1).Value = CLng(txtHeatNumber)

        '        TechParams(0).Value = CDate(txtDate)
        '        TechParams(1).Value = lblShift
        '        TechParams(2).Value = txtTechnicalAuthority
        '        TechParams(3).Value = CLng(txtWheelNumber)
        '        TechParams(4).Value = CLng(txtHeatNumber)
        '        TechParams(5).Value = Val(txtBdNo)
        '        TechParams(6).Value = Now
        '        TechParams(7).Value = lblStatus
        '        TechParams(8).Value = lblLoca

        '        LabParams(0).Value = CDate(txtDate)
        '        LabParams(1).Value = lblShift
        '        LabParams(2).Value = lblLabAuthority
        '        LabParams(3).Value = 0  ' to be assigned later
        '        LabParams(4).Value = IIf(btnSave = "SY_", "SY_P", btnSave)
        '        LabParams(5).Value = CInt(txtBHN)
        '        Dim sqlcmd1 As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        '        sqlcmd1.CommandText = "select convert(float, getdate())"
        '        Dim deciVal As Decimal
        '        deciVal = 0
        '        sqlcmd1.Connection.Open()
        '        deciVal = sqlcmd1.ExecuteScalar
        '        If sqlcmd1.Connection.State = ConnectionState.Open Then sqlcmd1.Connection.Close()
        '        sqlcmd1.Dispose()
        '        sqlcmd1 = Nothing
        '        LabParams(6).Value = IIf(CStr(LabParams(4).Value).StartsWith("S") Or CStr(LabParams(4).Value).StartsWith("X"), 0, deciVal)
        '        LabParams(7).Value = Now
        '        deciVal = Nothing

        '        FinParams(0).Value = 0  ' to be assigned later
        '        FinParams(1).Value = CDec(Val(txtTreadDiameter))
        '        FinParams(2).Value = IIf(txtBorestatus.ToUpper.StartsWith("U"), "U", "B")
        '        FinParams(3).Value = txtPlateThickness.ToUpper
        '        FinParams(4).Value = Now
        '    Catch exp As Exception
        '        Throw New Exception(exp.Message)
        '        Exit Function
        '    Finally
        '        ' left blank
        '    End Try

        '    Dim strTran As SqlClient.SqlTransaction
        '    Dim sqlcmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        '    Dim j As Integer
        '    Dim done As Integer
        '    Try
        '        sqlcmd.Connection.Open()
        '        sqlcmd.Transaction = sqlcmd.Connection.BeginTransaction
        '        For j = 0 To 8
        '            sqlcmd.Parameters.Add(TechParams(j))
        '        Next
        '        sqlcmd.CommandText = strAddTechData
        '        sqlcmd.ExecuteNonQuery()
        '        For j = 0 To 8
        '            sqlcmd.Parameters.Remove(TechParams(j))
        '        Next
        '        For j = 0 To 1
        '            sqlcmd.Parameters.Add(whlparam(j))
        '        Next
        '        sqlcmd.CommandText = strGetTechId
        '        LabParams(3).Value = sqlcmd.ExecuteScalar
        '        For j = 0 To 1
        '            sqlcmd.Parameters.Remove(whlparam(j))
        '        Next
        '        For j = 0 To 7
        '            sqlcmd.Parameters.Add(LabParams(j))
        '        Next
        '        sqlcmd.CommandText = strAddLabData
        '        sqlcmd.ExecuteNonQuery()
        '        For j = 0 To 7
        '            sqlcmd.Parameters.Remove(LabParams(j))
        '        Next
        '        For j = 0 To 1
        '            sqlcmd.Parameters.Add(whlparam(j))
        '        Next
        '        sqlcmd.CommandText = strGetLabId
        '        FinParams(0).Value = sqlcmd.ExecuteScalar
        '        For j = 0 To 1
        '            sqlcmd.Parameters.Remove(whlparam(j))
        '        Next
        '        For j = 0 To 4
        '            sqlcmd.Parameters.Add(FinParams(j))
        '        Next
        '        sqlcmd.CommandText = strAddFinData
        '        sqlcmd.ExecuteNonQuery()
        '        For j = 0 To 4
        '            sqlcmd.Parameters.Remove(FinParams(j))
        '        Next
        '        For j = 0 To 1
        '            sqlcmd.Parameters.Add(whlparam(j))
        '        Next
        '        sqlcmd.CommandText = strGetFinId
        '        done = sqlcmd.ExecuteScalar
        '    Catch exp As Exception
        '        Throw New Exception(exp.Message)
        '    Finally
        '        If done Then
        '            sqlcmd.Transaction.Commit()
        '        Else
        '            sqlcmd.Transaction.Rollback()
        '        End If
        '        If sqlcmd.Connection.State = ConnectionState.Open Then sqlcmd.Connection.Close()
        '        sqlcmd.Dispose()
        '        sqlcmd = Nothing
        '    End Try
        '    TechParams(8) = Nothing
        '    LabParams(7) = Nothing
        '    FinParams(4) = Nothing
        '    whlparam(1) = Nothing
        '    strAddTechData = Nothing
        '    strAddLabData = Nothing
        '    strAddFinData = Nothing
        '    strGetTechId = Nothing
        '    strGetLabId = Nothing
        '    strGetFinId = Nothing
        '    j = Nothing
        '    strTran = Nothing
        '    Return done
        'End Function

        Public Function SaveYardWheelMagna(ByVal txtWheelNumber As Double, ByVal txtHeatNumber As Double, ByVal txtDate As Date, ByVal lblShift As String, ByVal txtTechnicalAuthority As String, ByVal txtBdNo As String, ByVal lblStatus As String, ByVal lblLoca As String, ByVal lblLabAuthority As String, ByVal btnSave As String, ByVal txtBHN As Integer, ByVal txtTreadDiameter As Double, ByVal txtBorestatus As String, ByVal txtPlateThickness As String, ByVal txtmr As String, ByVal txtsms As String, ByVal txtwfps As String, ByVal txtautech As String, ByVal txtjicStatus As String, ByVal txtjicremark As String) As Boolean
            Dim strAddTechData, strAddLabData, strAddFinData, strGetTechId, strGetLabId, strGetFinId As String
            Dim TechParams(8), LabParams(13), FinParams(4), whlparam(1) As SqlClient.SqlParameter

            whlparam(0) = New SqlClient.SqlParameter("@wheelNumber", SqlDbType.BigInt, 8)
            whlparam(1) = New SqlClient.SqlParameter("@heatNumber", SqlDbType.BigInt, 8)
            whlparam(0).Direction = ParameterDirection.Input
            whlparam(1).Direction = ParameterDirection.Input

            FinParams(0) = New SqlClient.SqlParameter("@MagSlNo", SqlDbType.BigInt, 8)
            FinParams(1) = New SqlClient.SqlParameter("@TreadDia", SqlDbType.Decimal, 4)
            FinParams(2) = New SqlClient.SqlParameter("@BoreStatus", SqlDbType.VarChar, 10)
            FinParams(3) = New SqlClient.SqlParameter("@PlateStatus", SqlDbType.VarChar, 10)
            FinParams(4) = New SqlClient.SqlParameter("@SaveDateTime", SqlDbType.SmallDateTime, 4)

            FinParams(0).Direction = ParameterDirection.Input
            FinParams(1).Direction = ParameterDirection.Input
            FinParams(2).Direction = ParameterDirection.Input
            FinParams(3).Direction = ParameterDirection.Input
            FinParams(4).Direction = ParameterDirection.Input

            LabParams(0) = New SqlClient.SqlParameter("@dt", SqlDbType.SmallDateTime, 4)
            LabParams(1) = New SqlClient.SqlParameter("@Shift", SqlDbType.VarChar, 1)
            LabParams(2) = New SqlClient.SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
            LabParams(3) = New SqlClient.SqlParameter("@TechSlNo", SqlDbType.BigInt, 8)
            LabParams(4) = New SqlClient.SqlParameter("@WheelDisposition", SqlDbType.VarChar, 50)
            LabParams(5) = New SqlClient.SqlParameter("@bhn", SqlDbType.Int, 4)
            LabParams(6) = New SqlClient.SqlParameter("@IsXCorPass", SqlDbType.Float, 8)
            LabParams(7) = New SqlClient.SqlParameter("@SaveDateTime", SqlDbType.SmallDateTime, 4)
            LabParams(8) = New SqlClient.SqlParameter("@ssemr", SqlDbType.VarChar, 50)
            LabParams(9) = New SqlClient.SqlParameter("@ssesms", SqlDbType.VarChar, 50)
            LabParams(10) = New SqlClient.SqlParameter("@ssewfps", SqlDbType.VarChar, 50)
            LabParams(11) = New SqlClient.SqlParameter("@authtech", SqlDbType.VarChar, 50)
            LabParams(12) = New SqlClient.SqlParameter("@jicstatus", SqlDbType.VarChar, 50)
            LabParams(13) = New SqlClient.SqlParameter("@jicremark", SqlDbType.VarChar, 150)


            LabParams(13).Direction = ParameterDirection.Input
            LabParams(12).Direction = ParameterDirection.Input
            LabParams(11).Direction = ParameterDirection.Input
            LabParams(10).Direction = ParameterDirection.Input
            LabParams(9).Direction = ParameterDirection.Input
            LabParams(8).Direction = ParameterDirection.Input
            LabParams(7).Direction = ParameterDirection.Input
            LabParams(6).Direction = ParameterDirection.Input
            LabParams(5).Direction = ParameterDirection.Input
            LabParams(4).Direction = ParameterDirection.Input
            LabParams(3).Direction = ParameterDirection.Input
            LabParams(2).Direction = ParameterDirection.Input
            LabParams(1).Direction = ParameterDirection.Input
            LabParams(0).Direction = ParameterDirection.Input


            TechParams(0) = New SqlClient.SqlParameter("@dt", SqlDbType.SmallDateTime, 4)
            TechParams(1) = New SqlClient.SqlParameter("@Shift", SqlDbType.VarChar, 1)
            TechParams(2) = New SqlClient.SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
            TechParams(3) = New SqlClient.SqlParameter("@WheelNumber", SqlDbType.BigInt, 8)
            TechParams(4) = New SqlClient.SqlParameter("@HeatNumber", SqlDbType.BigInt, 8)
            TechParams(5) = New SqlClient.SqlParameter("@BoardNo", SqlDbType.VarChar, 5)
            TechParams(6) = New SqlClient.SqlParameter("@SaveDateTime", SqlDbType.SmallDateTime, 4)
            TechParams(7) = New SqlClient.SqlParameter("@LastMcnOpn", SqlDbType.VarChar, 50)
            TechParams(8) = New SqlClient.SqlParameter("@PreLocation", SqlDbType.VarChar, 10)

            TechParams(8).Direction = ParameterDirection.Input
            TechParams(7).Direction = ParameterDirection.Input
            TechParams(6).Direction = ParameterDirection.Input
            TechParams(5).Direction = ParameterDirection.Input
            TechParams(4).Direction = ParameterDirection.Input
            TechParams(3).Direction = ParameterDirection.Input
            TechParams(2).Direction = ParameterDirection.Input
            TechParams(1).Direction = ParameterDirection.Input
            TechParams(0).Direction = ParameterDirection.Input

            strAddTechData = "insert into mm_YardInspection_Technical ( Dt, Shift, EmpCode, WheelNumber, HeatNumber, BoardNo, LastMcnOpn, PreLocation, SaveDateTime ) values ( @Dt, @Shift, @EmpCode, @WheelNumber, @HeatNumber, @BoardNo, @LastMcnOpn, @PreLocation, @SaveDateTime )  "
            strGetTechId = "select a.slNo from mm_YardInspection_Technical a where a.wheelNumber = @wheelNumber and a.heatNumber = @heatNumber"
            strAddLabData = "insert into mm_YardInspection_Magna_new (Dt, Shift, EmpCode, TechSlNo, WheelDisposition, BHN, IsXCorPass, SaveDateTime,ssemr ,ssesms,ssewfps,authtech,jicstatus,jicremark ) values (@Dt, @Shift, @EmpCode, @TechSlNo, @WheelDisposition, @BHN, @IsXCorPass, @SaveDateTime ,@ssemr,@ssesms,@ssewfps,@authtech,@jicstatus,@jicremark)"
            strGetLabId = "select a.slNo from mm_YardInspection_Magna_new a inner join mm_YardInspection_Technical b on a.techslno = b.slno where b.wheelNumber = @wheelNumber and b.heatNumber = @heatNumber"
            strAddFinData = "insert into mm_YardInspection_Final ( MagSlNo, TreadDia, BoreStatus, PlateStatus ) values ( @MagSlNo, @TreadDia, @BoreStatus, @PlateStatus )"
            strGetFinId = "select count(*) from mm_YardInspection_Final a inner join mm_YardInspection_Magna_new b on a.magslno = b.slno inner join  mm_YardInspection_Technical c on b.techslno = c.slno where c.wheelNumber = @wheelNumber and c.heatNumber = @heatNumber" ' after verified for the wheel will be deleted.
            Try
                whlparam(0).Value = CLng(txtWheelNumber)
                whlparam(1).Value = CLng(txtHeatNumber)

                TechParams(0).Value = CDate(txtDate)
                TechParams(1).Value = lblShift
                TechParams(2).Value = txtTechnicalAuthority
                TechParams(3).Value = CLng(txtWheelNumber)
                TechParams(4).Value = CLng(txtHeatNumber)
                TechParams(5).Value = Val(txtBdNo)
                TechParams(6).Value = Now
                TechParams(7).Value = lblStatus
                TechParams(8).Value = lblLoca

                LabParams(0).Value = CDate(txtDate)
                LabParams(1).Value = lblShift
                LabParams(2).Value = lblLabAuthority
                LabParams(3).Value = 0  ' to be assigned later
                LabParams(4).Value = IIf(btnSave = "SY_", "SY_P", btnSave)
                LabParams(5).Value = CInt(txtBHN)
                Dim sqlcmd1 As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
                sqlcmd1.CommandText = "select convert(float, getdate())"
                Dim deciVal As Decimal
                deciVal = 0
                sqlcmd1.Connection.Open()
                deciVal = sqlcmd1.ExecuteScalar
                If sqlcmd1.Connection.State = ConnectionState.Open Then sqlcmd1.Connection.Close()
                sqlcmd1.Dispose()
                sqlcmd1 = Nothing
                LabParams(6).Value = IIf(CStr(LabParams(4).Value).StartsWith("S") Or CStr(LabParams(4).Value).StartsWith("X"), 0, deciVal)
                LabParams(7).Value = Now
                deciVal = Nothing

                LabParams(8).Value = txtmr
                LabParams(9).Value = txtsms
                LabParams(10).Value = txtwfps
                LabParams(11).Value = txtautech
                LabParams(12).Value = txtjicStatus
                LabParams(13).Value = txtjicremark

                FinParams(0).Value = 0  ' to be assigned later
                FinParams(1).Value = CDec(Val(txtTreadDiameter))
                FinParams(2).Value = IIf(txtBorestatus.ToUpper.StartsWith("U"), "U", "B")
                FinParams(3).Value = txtPlateThickness.ToUpper
                FinParams(4).Value = Now
            Catch exp As Exception
                Throw New Exception(exp.Message)
                Exit Function
            Finally
                ' left blank
            End Try

            Dim strTran As SqlClient.SqlTransaction
            Dim sqlcmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim j As Integer
            Dim done As Integer
            Try
                sqlcmd.Connection.Open()
                sqlcmd.Transaction = sqlcmd.Connection.BeginTransaction
                For j = 0 To 8
                    sqlcmd.Parameters.Add(TechParams(j))
                Next
                sqlcmd.CommandText = strAddTechData
                sqlcmd.ExecuteNonQuery()
                For j = 0 To 8
                    sqlcmd.Parameters.Remove(TechParams(j))
                Next
                For j = 0 To 1
                    sqlcmd.Parameters.Add(whlparam(j))
                Next
                sqlcmd.CommandText = strGetTechId
                LabParams(3).Value = sqlcmd.ExecuteScalar
                For j = 0 To 1
                    sqlcmd.Parameters.Remove(whlparam(j))
                Next
                For j = 0 To 13
                    sqlcmd.Parameters.Add(LabParams(j))
                Next
                sqlcmd.CommandText = strAddLabData
                sqlcmd.ExecuteNonQuery()
                For j = 0 To 7
                    sqlcmd.Parameters.Remove(LabParams(j))
                Next
                For j = 0 To 1
                    sqlcmd.Parameters.Add(whlparam(j))
                Next
                sqlcmd.CommandText = strGetLabId
                FinParams(0).Value = sqlcmd.ExecuteScalar
                For j = 0 To 1
                    sqlcmd.Parameters.Remove(whlparam(j))
                Next
                For j = 0 To 4
                    sqlcmd.Parameters.Add(FinParams(j))
                Next
                sqlcmd.CommandText = strAddFinData
                sqlcmd.ExecuteNonQuery()
                For j = 0 To 4
                    sqlcmd.Parameters.Remove(FinParams(j))
                Next
                For j = 0 To 1
                    sqlcmd.Parameters.Add(whlparam(j))
                Next
                sqlcmd.CommandText = strGetFinId
                done = sqlcmd.ExecuteScalar
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If done Then
                    sqlcmd.Transaction.Commit()
                Else
                    sqlcmd.Transaction.Rollback()
                End If
                If sqlcmd.Connection.State = ConnectionState.Open Then sqlcmd.Connection.Close()
                sqlcmd.Dispose()
                sqlcmd = Nothing
            End Try
            TechParams(8) = Nothing
            LabParams(7) = Nothing
            FinParams(4) = Nothing
            whlparam(1) = Nothing
            strAddTechData = Nothing
            strAddLabData = Nothing
            strAddFinData = Nothing
            strGetTechId = Nothing
            strGetLabId = Nothing
            strGetFinId = Nothing
            j = Nothing
            strTran = Nothing
            Return done
        End Function
        Public Function DeleteYardWheel(ByVal WheelNumber As Double, ByVal HeatNumber As Double) As Boolean
            Dim sqlcmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim i As Integer
            Dim yardmag, yardtech As Long
            sqlcmd.CommandText = "select @magSlno = isnull(a.magslno,0), @TechSlno = b.Techslno  from mm_yardInspection_final " & _
                " a inner join mm_yardInspection_magna b on a.magslno = b.slno " & _
                " inner join mm_YardInspection_technical c on b.techslno = c.slno " & _
                " where c.wheelnumber = " & CLng(WheelNumber) & " and c.heatnumber = " & CLng(HeatNumber) & " and isnull(a.isverfied,0) = 0 "
            sqlcmd.Parameters.Add("@magSlno", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
            sqlcmd.Parameters.Add("@TechSlno", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
            sqlcmd.Parameters.Add("@WheelNumber", SqlDbType.BigInt, 8).Value = WheelNumber
            sqlcmd.Parameters.Add("@HeatNumber", SqlDbType.BigInt, 8).Value = HeatNumber
            Try
                sqlcmd.Connection.Open()
                sqlcmd.ExecuteScalar()
                yardmag = sqlcmd.Parameters("@magSlno").Value
                yardtech = sqlcmd.Parameters("@TechSlno").Value
                If yardmag > 0 And yardtech > 0 Then
                    sqlcmd.CommandText = "Select count(*) from mm_wheel where wheel_number = @WheelNumber " & _
                        " and heat_number = @HeatNumber and location in ( 'CLMT' , 'CLFI' )"
                    If sqlcmd.ExecuteScalar > 0 Then
                        sqlcmd.CommandText = "delete mm_yardInspection_technical where slno = " & yardtech & " ; "
                        If sqlcmd.ExecuteNonQuery() > 0 Then
                            sqlcmd.CommandText = " delete mm_yardInspection_magna where techslno = " & yardtech & " ; "
                            If sqlcmd.ExecuteNonQuery > 0 Then
                                sqlcmd.CommandText = " delete mm_yardInspection_final where magslno = " & yardmag & " "
                                If sqlcmd.ExecuteNonQuery > 0 Then
                                    sqlcmd.CommandText = "select count(*) from mm_yardInspection_final a " & _
                                           " inner join mm_yardInspection_magna b on a.magslno = b.slno " & _
                                           " inner join mm_YardInspection_technical c on b.techslno = c.slno " & _
                                           " where c.wheelnumber = @WheelNumber and c.heatnumber = @HeatNumber and isnull(a.isverfied,0) = 0 "
                                    i = sqlcmd.ExecuteScalar
                                    If IsDBNull(i) OrElse IsNothing(i) Then
                                        i = 0
                                    End If
                                End If
                            End If
                        End If
                    Else
                        Throw New Exception("Not Deleted as it has been verified by the time")
                    End If
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If sqlcmd.Connection.State = ConnectionState.Open Then sqlcmd.Connection.Close()
                sqlcmd.Dispose()
                sqlcmd = Nothing
            End Try
            yardmag = Nothing
            yardtech = Nothing
            Return i
        End Function
    End Class
End Namespace
Namespace AxleProcessing
    <Serializable()> Public Class CLRINS
#Region " tables"
        Public Shared Function IQAC_Data(ByVal FrDt As Date, ByVal Type As Integer) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.Parameters.Add("@FrDt", SqlDbType.SmallDateTime, 4).Value = CDate(FrDt)
                da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = Type
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.CommandText = "mm_sp_IQAC_Data"
                da.Fill(ds)
                IQAC_Data = ds.Tables(0)
            Catch exp As Exception
                IQAC_Data = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function IQAC(ByVal InspDate As Date, ByVal FailedIQAC As Boolean, ByVal ReportName As String) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                If FailedIQAC Then
                    da.SelectCommand.Parameters.Add("@Insp_Date", SqlDbType.SmallDateTime, 4).Value = CDate(InspDate)
                    da.SelectCommand.CommandType = CommandType.StoredProcedure
                    da.SelectCommand.CommandText = "mm_sp_IQAC_FailedSets"
                Else
                    If ReportName = "mm_sp_ProdwiseAxles_Despatched" Then
                        da.SelectCommand.Parameters.Add("@dc_date", SqlDbType.SmallDateTime, 4).Value = CDate(InspDate)
                        da.SelectCommand.CommandType = CommandType.StoredProcedure
                        da.SelectCommand.CommandText = "mm_sp_ProdwiseAxles_Despatched"
                    Else
                        da.SelectCommand.CommandText = "Select convert(varchar(11),InspectionDate,103) DatesRequiringReGenQAC " & _
                        " from mm_vw_SetQACRegenRequired"
                    End If
                End If
                da.Fill(ds)
                IQAC = ds.Tables(0)
            Catch exp As Exception
                IQAC = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function DatesRequiringReGenQAC() As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = "Select convert(varchar(11),InspectionDate,103) " & _
                    " DatesRequiringReGenQAC from mm_vw_SetQACRegenRequired"
                da.Fill(ds)
                DatesRequiringReGenQAC = ds.Tables(0)
            Catch exp As Exception
                DatesRequiringReGenQAC = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function LastInspectionDate() As Date
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Connection.Open()
                cmd.Parameters.Add("@LastInspectionDate", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output
                cmd.CommandText = "Select @LastInspectionDate = max(inspection_date) from mm_wheelset_inspection_details WHERE memo_number <> ''"""
                cmd.ExecuteScalar()
                LastInspectionDate = IIf(IsDBNull(cmd.Parameters("@LastInspectionDate").Value), "1900-01-01", cmd.Parameters("@LastInspectionDate").Value)
            Catch exp As Exception
                LastInspectionDate = "1900-01-01"
                Throw New Exception(exp.Message)
            Finally
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function BatchRemarks(ByVal Axle As String, ByVal Batch As String, ByVal Sl As Integer) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = "select rework_remarks , mount_date , product_code " & _
                " from mm_mounting_press a inner join mm_workorder c on number = workorder_number " & _
                " where axle_number = '" & Trim(Axle) & "' and batch_number = '" & Trim(Batch) & "' and day_serial = '" & Sl & "' "
                da.Fill(ds)
                BatchRemarks = ds.Tables(0)
            Catch exp As Exception
                BatchRemarks = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function '
        Public Shared Function IsNotValidDt(ByVal InspDt As Date, ByVal Batch As String, ByVal Sl As Integer) As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Connection.Open()
                cmd.Parameters.Add("@AxleCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                cmd.Parameters.Add("@inspection_date", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output
                cmd.CommandText = " select @inspection_date = inspection_date from mm_wheelset_inspection_details " & _
                    " where sl_no = '" & Sl & "' and batch_no = '" & Batch.Trim & "' "
                cmd.ExecuteScalar()
                If InspDt < IIf(IsDBNull(cmd.Parameters("@inspection_date").Value), CDate("1900-01-01"), cmd.Parameters("@inspection_date").Value) Then IsNotValidDt = True

            Catch exp As Exception
                IsNotValidDt = 0
                Throw New Exception(exp.Message)
            Finally
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function BatchAxleCount(ByVal Axle As String, ByVal Batch As String, ByVal Sl As Integer) As Integer
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Connection.Open()
                cmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                cmd.CommandText = "select @cnt = count(*) from mm_mounting_press " & _
                    " where axle_number = '" & Trim(Axle) & "' and batch_number = '" & Trim(Batch) & "' and day_serial = '" & Sl & "' "
                cmd.ExecuteScalar()
                BatchAxleCount = IIf(IsDBNull(cmd.Parameters("@cnt").Value), "", cmd.Parameters("@cnt").Value)
            Catch exp As Exception
                BatchAxleCount = ""
                Throw New Exception(exp.Message)
            Finally
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function BatchSts(ByVal Axle As String) As String
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Connection.Open()
                cmd.Parameters.Add("@Sts", SqlDbType.VarChar, 4).Direction = ParameterDirection.Output
                cmd.CommandText = "select top 1 @Sts = wap_status from mm_wheelset_inspection_details " & _
                    " where axle_number = '" & Trim(Axle) & "' order by inspection_date desc , shift_code desc "
                cmd.ExecuteScalar()
                BatchSts = IIf(IsDBNull(cmd.Parameters("@Sts").Value), "", cmd.Parameters("@Sts").Value)
            Catch exp As Exception
                BatchSts = ""
                Throw New Exception(exp.Message)
            Finally
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function BatchWO(ByVal Axle As String, ByVal Batch As String, ByVal Sl As Integer) As String
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Connection.Open()
                cmd.Parameters.Add("@WO", SqlDbType.VarChar, 4).Direction = ParameterDirection.Output
                cmd.CommandText = "select @WO = workorder_number from mm_mounting_press " & _
                    " where axle_number = '" & Trim(Axle) & "' and batch_number = '" & Trim(Batch) & "' and day_serial = '" & Sl & "' "
                cmd.ExecuteScalar()
                BatchWO = IIf(IsDBNull(cmd.Parameters("@WO").Value), "", cmd.Parameters("@Wo").Value)
            Catch exp As Exception
                BatchWO = ""
                Throw New Exception(exp.Message)
            Finally
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function BatchAxleNumber(ByVal Batch As String, ByVal Sl As Integer) As String
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Connection.Open()
                cmd.Parameters.Add("@AxleCount", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                cmd.CommandText = "Select @AxleCount =  axle_number from mm_mounting_press " & _
                    " where batch_number = '" & Batch.Trim & "' and day_serial = " & Sl & " " & _
                    " and mount_date = (select max(mount_date) from mm_mounting_press " & _
                    " where batch_number = '" & Batch.Trim & "' and day_serial = " & Sl & " )  "
                cmd.ExecuteScalar()
                BatchAxleNumber = IIf(IsDBNull(cmd.Parameters("@AxleCount").Value), "", cmd.Parameters("@AxleCount").Value)
            Catch exp As Exception
                BatchAxleNumber = 0
                Throw New Exception(exp.Message)
            Finally
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function BatchSlPassCount(ByVal Batch As String, ByVal Sl As Integer) As Integer
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Connection.Open()
                cmd.Parameters.Add("@AxleCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                cmd.CommandText = "Select @AxleCount = count(*) from mm_wheelset_inspection_details " & _
                    " where batch_no = '" & Batch.Trim & "' and sl_no = " & Sl & " " & _
                    " and memo_number <> '' and hld_Rem <> 'rej2hold'"
                cmd.ExecuteScalar()
                BatchSlPassCount = IIf(IsDBNull(cmd.Parameters("@AxleCount").Value), 0, cmd.Parameters("@AxleCount").Value)
            Catch exp As Exception
                BatchSlPassCount = 0
                Throw New Exception(exp.Message)
            Finally
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function BatchSlCount(ByVal Batch As String, ByVal Sl As Integer) As Integer
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Connection.Open()
                cmd.Parameters.Add("@AxleCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                cmd.CommandText = "Select @AxleCount = count(*) from mm_wheelset_inspection_details " & _
                    " where batch_no = '" & Batch.Trim & "' and sl_no = " & Sl & ""
                cmd.ExecuteScalar()
                BatchSlCount = IIf(IsDBNull(cmd.Parameters("@AxleCount").Value), 0, cmd.Parameters("@AxleCount").Value)
            Catch exp As Exception
                BatchSlCount = 0
                Throw New Exception(exp.Message)
            Finally
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function BatchCount(ByVal Batch As String) As Integer
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Connection.Open()
                cmd.Parameters.Add("@AxleCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                cmd.CommandText = "Select @AxleCount =  count(*) from mm_wheelset_inspection_details where batch_no = '" & Batch.Trim & "'"
                cmd.ExecuteScalar()
                BatchCount = IIf(IsDBNull(cmd.Parameters("@AxleCount").Value), 0, cmd.Parameters("@AxleCount").Value)
            Catch exp As Exception
                BatchCount = 0
                Throw New Exception(exp.Message)
            Finally
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function AxleCount(ByVal Axle As String) As Integer
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Connection.Open()
                cmd.Parameters.Add("@AxleCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                cmd.CommandText = "Select @AxleCount = Count(*) from mm_mounting_press where axle_number = '" & Axle.Trim & "'"
                cmd.ExecuteScalar()
                AxleCount = IIf(IsDBNull(cmd.Parameters("@AxleCount").Value), 0, cmd.Parameters("@AxleCount").Value)
            Catch exp As Exception
                AxleCount = 0
                Throw New Exception(exp.Message)
            Finally
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function ShowInspectionGrid(ByVal InspDate As Date) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.Parameters.Add("@InspDate", SqlDbType.SmallDateTime, 4).Value = InspDate
                da.SelectCommand.CommandText = "select row_number() over ( order by SlNo ) SlNo ," & _
                    " axle_number AxleNo , memo_number MemoNumber , wap_status Sts , batch_no Batch , sl_no Sl " & _
                    " From  mm_wheelset_inspection_details where inspection_date = @InspDate and " & _
                    " isnull(memo_number,'') <>'' order by SlNo desc  "
                da.Fill(ds)
                ShowInspectionGrid = ds.Tables(0)
            Catch exp As Exception
                ShowInspectionGrid = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function ShowInternalQAC(ByVal InspDate As Date, Optional ByVal str As String = "") As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.Parameters.Add("@InspDate", SqlDbType.SmallDateTime, 4).Value = InspDate
                If str.Trim.Length = 0 Then
                    da.SelectCommand.CommandText = "select a.batch_number, a.Day_serial,  a.mount_date, a.wap_status , " & _
                        " a.axle_source, a.wheel_source, isnull(aNonRWFUT,'') aNonRWFUT, isnull(aNonRWFMPT,'') aNonRWFMPT,  " & _
                        " workorder_number wo, Track_Guage_Reading1 TGR1,  Track_Guage_Reading2 TGR2,  " & _
                        " Track_Guage_Reading3 TGR3,  Axle_number,  axleStatus, aUtEmpCode,  aUtPassedDt UtDate, " & _
                        " aMPTEmpCode, aMPTPassedDt MPTDt, aFIEmpCode, a.InspectionDate SetInspDt,  " & _
                        " east_wheel_number, eWhlStatus, eWhlUtEmpCode, eWhlMPTEmpCode,  east_Tread_dia, " & _
                        " East_mount_pressure, west_wheel_number, wWhlStatus, wWhlUtEmpCode, wWhlMPTEmpCode, " & _
                        " wWhlFIEmpCode, west_Tread_dia, west_mount_pressure " & _
                        " from mm_wheelsets_internalqac_reference a " & _
                        " inner join mm_internal_qac_detail b on b.batch_number = a.batch_number " & _
                        " and b.day_serial = a.day_serial " & _
                        " where inspectionDate = @InspDate"
                Else
                    da.SelectCommand.CommandText = str
                End If
                da.Fill(ds)
                ShowInternalQAC = ds.Tables(0)
            Catch exp As Exception
                ShowInternalQAC = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function WheelSetsInternalQAC(ByVal InspDate As Date) As DataSet
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = "mm_sp_si_InternalQAC"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.Add("@Insp_Date", SqlDbType.SmallDateTime, 4).Value = InspDate
                da.SelectCommand.CommandTimeout = 60 * 60 * 1
                da.Fill(ds)
                WheelSetsInternalQAC = ds
            Catch exp As Exception
                WheelSetsInternalQAC = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function InspectionEditDetails(ByVal InspDate As Date) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.Parameters.Add("@InspDate", SqlDbType.SmallDateTime, 4).Value = InspDate
                da.SelectCommand.CommandText = "select row_number() over ( order by a.batch_no , a.sl_no ) Sl , " & _
                    " convert(varchar(11),a.inspection_date,103) InspDt  , " & _
                    " a.shift_code Sh, a.axle_number Axle, a.memo_number Memo , a.batch_no Batch ," & _
                    " a.sl_no Sl , a.inspection_code PreCode , a.wap_status PreSts , " & _
                    " b.wap_status PresentSts, b.hld_rem, EditedDateTime, EditedBy " & _
                    " from mm_wheelset_inspection_details_audit a inner join mm_wheelset_inspection_details b" & _
                    " on a.axle_number = b.axle_number and a.batch_no = b.batch_no and a.sl_no = b.sl_no " & _
                    " and a.inspection_code = b.inspection_code where a.inspection_date = @InspDate"
                da.Fill(ds)
                InspectionEditDetails = ds.Tables(0)
            Catch exp As Exception
                InspectionEditDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function InspectionBatchDetails(ByVal InspDate As Date) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.Parameters.Add("@InspDate", SqlDbType.SmallDateTime, 4).Value = InspDate
                da.SelectCommand.CommandText = "select row_number() over ( order by batch_no , sl_no ) Sl , " & _
                    " convert(varchar(11),Inspection_Date,103) InspDate , " & _
                    " Shift_code Sh , operator_code Oper , axle_number Axle , memo_number , batch_no Batch , sl_no DaySl , wap_status Sts , " & _
                    " hld_rem from mm_wheelset_inspection_details where Inspection_Date = @InspDate " & _
                    " order by batch_no , sl_no "
                da.Fill(ds)
                InspectionBatchDetails = ds.Tables(0)
            Catch exp As Exception
                InspectionBatchDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function LastInspDate() As Date
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Connection.Open()
                cmd.Parameters.Add("@LastInspDate", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output
                cmd.CommandText = "Select @LastInspDate = max(inspection_date) from mm_wheelset_inspection_details "
                cmd.ExecuteScalar()
                LastInspDate = IIf(IsDBNull(cmd.Parameters("@LastInspDate").Value), CDate("1900-01-01"), cmd.Parameters("@LastInspDate").Value)
            Catch exp As Exception
                LastInspDate = CDate("1900-01-01")
                Throw New Exception(exp.Message)
            Finally
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function InspectionBatchDetails(ByVal AxleNo As String, ByVal BatchNo As String, ByVal DaySl As Integer) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = "select top 1 Inspection_Date, Shift_code, wap_status, " & _
                    " hld_rem from mm_wheelset_inspection_details where axle_number = '" & Trim(AxleNo) & "' " & _
                    " and batch_no = '" & BatchNo & "' and sl_no = " & Val(DaySl) & " " & _
                    " order by inspection_date desc, shift_code desc "
                da.Fill(ds)
                InspectionBatchDetails = ds.Tables(0)
            Catch exp As Exception
                InspectionBatchDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function BatchSlDetails(ByVal BatchNo As String, ByVal DaySl As Integer) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = "select top 1 convert(varchar(10),mount_date,103) MountDt , rtrim(shift_code) Sh ,  " & _
                    " axle_number AxleNo , East_Wheel_Number EWhlNo , East_Tread_Dia ETrDia , west_wheel_number WWhlNo , " & _
                    " West_Tread_dia WTrDia , mount_status Sts , workorder_number WO " & _
                    " from mm_mounting_press where batch_number = '" & Trim(BatchNo) & "' " & _
                    " and East_Wheel_Number <> '0/0' and west_wheel_number <> '0/0' and axle_number <> '' " & _
                    " and day_serial = " & Val(DaySl) & " order by Mount_date desc "
                da.Fill(ds)
                BatchSlDetails = ds.Tables(0)
            Catch exp As Exception
                BatchSlDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function MountCount(ByVal BatchNo As String) As Integer
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Connection.Open()
                cmd.Parameters.Add("@BatchNo", SqlDbType.VarChar, 50).Value = BatchNo
                cmd.Parameters.Add("@SetsCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                cmd.CommandText = "Select @SetsCount = count(*) from mm_mounting_press where batch_number = @BatchNo "
                cmd.ExecuteScalar()
                MountCount = IIf(IsDBNull(cmd.Parameters("@SetsCount").Value), 0, cmd.Parameters("@SetsCount").Value)
            Catch exp As Exception
                MountCount = 0
                Throw New Exception(exp.Message)
            Finally
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function GetAxleProductCode(ByVal Axle As String) As String
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Connection.Open()
                cmd.Parameters.Add("@Axle", SqlDbType.VarChar, 50).Value = Axle
                cmd.Parameters.Add("@GetAxleProductCode", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                cmd.CommandText = "Select top 1 @GetAxleProductCode = product_code from mm_axle_mpt_test_results " & _
                    " where axle_number = @Axle and mpt_status = 'p' order by sl_no desc "
                cmd.ExecuteScalar()
                GetAxleProductCode = IIf(IsDBNull(cmd.Parameters("@GetAxleProductCode").Value), "", cmd.Parameters("@GetAxleProductCode").Value)
                If GetAxleProductCode = "" Then
                    cmd.CommandText = "Select @GetAxleProductCode = AxleProductCode " & _
                        " from mm_nonrwfaxles_pcoEntry a inner join mm_nonrwfaxles_pcoRef b on a.ritesReference = b.ritesReference " & _
                        " where a.rwf_axle_number = @Axle "
                    GetAxleProductCode = IIf(IsDBNull(cmd.Parameters("@GetAxleProductCode").Value), "", cmd.Parameters("@GetAxleProductCode").Value)
                End If
            Catch exp As Exception
                GetAxleProductCode = ""
                Throw New Exception(exp.Message)
            Finally
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function RejRewDesc(ByVal sRejRewCode As String) As String
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Connection.Open()
                cmd.Parameters.Add("@RejectionDesc", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                cmd.CommandText = "select top 1 @RejectionDesc = rej_desc from mm_mmrjd_dump " & _
                    " where location = 'ASIN' or location = 'AAIN' and rej_code = '" & sRejRewCode & "'"
                cmd.ExecuteScalar()
                RejRewDesc = IIf(IsDBNull(cmd.Parameters("@RejectionDesc").Value), "", cmd.Parameters("@RejectionDesc").Value)
            Catch exp As Exception
                RejRewDesc = 0
                Throw New Exception(exp.Message)
            Finally
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function RejectionDesc(ByVal axle As String) As String
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Connection.Open()
                cmd.Parameters.Add("@RejectionDesc", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                cmd.CommandText = "select @RejectionDesc = rejection_rework_code from mm_axle_rejection_details where axle_number = '" & Trim(axle) & "' and rejection_location = 'AAIN'"
                cmd.ExecuteScalar()
                RejectionDesc = IIf(IsDBNull(cmd.Parameters("@RejectionDesc").Value), "", cmd.Parameters("@RejectionDesc").Value)
            Catch exp As Exception
                RejectionDesc = 0
                Throw New Exception(exp.Message)
            Finally
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function BatchDetailsForEdit(ByVal axle As String) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = "select * from mm_wheelset_inspection_details where axle_number='" & Trim(axle) & "'"
                da.Fill(ds)
                BatchDetailsForEdit = ds.Tables(0)
            Catch exp As Exception
                BatchDetailsForEdit = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function BatchDetailsForPassRest(ByVal BatchNo As String) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.Parameters.Add("@Batch_Number", SqlDbType.VarChar, 50).Value = BatchNo.Trim
                da.SelectCommand.CommandText = "select Mount_Date, Day_serial , Axle_number, workorder_number, " & _
                    " Product_code , east_tread_dia , west_tread_dia from mm_mounting_press " & _
                    " inner join mm_workorder on workorder_number = number where batch_number = @Batch_Number " & _
                    " and isnull(wap_status,'') = '' and  axle_number <> '' " & _
                    " and case when isnull(east_wheel_number,'') = '0/0' then '' else isnull(east_wheel_number,'') end  <> '' and " & _
                    " case when isnull(west_wheel_number,'') = '0/0' then '' else isnull(west_wheel_number,'') end  <> '' " & _
                    " and mount_status = 'y' and tap_hole_status  = 'y' order by Day_serial"
                da.Fill(ds)
                BatchDetailsForPassRest = ds.Tables(0)
            Catch exp As Exception
                BatchDetailsForPassRest = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function AxleWheelExists(ByVal BatchNo As String, ByVal DaySl As Integer) As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Connection.Open()
                cmd.Parameters.Add("@BatchNo", SqlDbType.VarChar, 50).Value = BatchNo
                cmd.Parameters.Add("@DaySl", SqlDbType.Int, 4).Value = DaySl
                cmd.Parameters.Add("@SetsCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                cmd.CommandText = "Select @SetsCount = count(*) from mm_mounting_press where batch_number = @BatchNo " & _
                    " and day_serial = @DaySl and ( axle_number = '' or west_wheel_number = '' or east_wheel_number  = '' ) "
                cmd.ExecuteScalar()
                AxleWheelExists = IIf(IsDBNull(cmd.Parameters("@SetsCount").Value), 0, cmd.Parameters("@SetsCount").Value)
            Catch exp As Exception
                AxleWheelExists = 0
                Throw New Exception(exp.Message)
            Finally
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function NotMountCount(ByVal BatchNo As String, ByVal DaySl As Integer) As Integer
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Connection.Open()
                cmd.Parameters.Add("@BatchNo", SqlDbType.VarChar, 50).Value = BatchNo
                cmd.Parameters.Add("@DaySl", SqlDbType.Int, 4).Value = DaySl
                cmd.Parameters.Add("@SetsCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                cmd.CommandText = "Select @SetsCount = count(*) from mm_mounting_press where batch_number = @BatchNo " & _
                    " and day_serial = @DaySl and (wap.dbo.mm_fn_si_IsRWFWhlPressed(east_wheel_number) + wap.dbo.mm_fn_si_IsRWFWhlPressed(west_wheel_number) + wap.dbo.mm_fn_si_IsAxlePressed(axle_number) ) <> 'MMM' and isnull(wap_status,'') = ''  "
                cmd.ExecuteScalar()
                NotMountCount = IIf(IsDBNull(cmd.Parameters("@SetsCount").Value), 0, cmd.Parameters("@SetsCount").Value)
            Catch exp As Exception
                NotMountCount = 0
                Throw New Exception(exp.Message)
            Finally
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function ClosureResultsForWhlSet(ByVal dt As DataTable, ByVal BatchNo As String, ByVal DaySl As Integer) As String
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim i, cnt As Int16
            ClosureResultsForWhlSet = ""
            Try
                cmd.Connection.Open()
                cmd.Parameters.Add("@BatchNo", SqlDbType.VarChar, 50).Value = BatchNo
                cmd.Parameters.Add("@DaySl", SqlDbType.Int, 4).Direction = ParameterDirection.Input
                cmd.Parameters.Add("@SetsCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                For i = 0 To dt.Rows.Count - 1
                    cnt = 0
                    cmd.Parameters("@DaySl").Value = dt.Rows(i)("Day_Serial")
                    cmd.CommandText = "Select @SetsCount = wap.dbo.ms_fn_ClosureResultsForWhlSet(@BatchNo,@DaySl)"
                    cmd.ExecuteScalar()
                    cnt = IIf(IsDBNull(cmd.Parameters("@SetsCount").Value), 0, cmd.Parameters("@SetsCount").Value)
                    If cnt = 0 Then
                        ClosureResultsForWhlSet = ClosureResultsForWhlSet + CStr(dt.Rows(i)("Day_Serial")) + " , "
                    End If
                Next
                If ClosureResultsForWhlSet.Trim.Length > 0 Then
                    ClosureResultsForWhlSet = "Closure Not Passed for " + ClosureResultsForWhlSet
                End If
            Catch exp As Exception
                ClosureResultsForWhlSet = 0
                Throw New Exception(exp.Message)
            Finally
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function ClosureResultsForWhlSet(ByVal BatchNo As String, ByVal DaySl As Integer) As Integer
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim i As Int16
            Try
                cmd.Connection.Open()
                cmd.Parameters.Add("@BatchNo", SqlDbType.VarChar, 50).Value = BatchNo
                cmd.Parameters.Add("@DaySl", SqlDbType.Int, 4).Value = DaySl
                cmd.Parameters.Add("@SetsCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                cmd.CommandText = "Select @SetsCount = wap.dbo.ms_fn_ClosureResultsForWhlSet(@BatchNo,@DaySl)"
                cmd.ExecuteScalar()
                ClosureResultsForWhlSet = IIf(IsDBNull(cmd.Parameters("@SetsCount").Value), 0, cmd.Parameters("@SetsCount").Value)
            Catch exp As Exception
                ClosureResultsForWhlSet = 0
                Throw New Exception(exp.Message)
            Finally
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function BatchDetails(ByVal BatchNo As String, ByVal DaySl As Integer) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = "Select Mount_Date, Product_Code, workorder_number, Axle_number, " & _
                    " ' EWhl: '+rtrim(east_wheel_number) + ' WWhl: ' + rtrim(west_wheel_number) SetStr , " & _
                    " east_wheel_number, west_wheel_number,  wap_status , east_tread_dia , west_tread_dia , tap_hole_status  " & _
                    " from mm_mounting_press inner join mm_workorder on number = workorder_number " & _
                    " where batch_number = '" & BatchNo.Trim & "' and day_serial = " & DaySl
                da.Fill(ds)
                BatchDetails = ds.Tables(0)
            Catch exp As Exception
                BatchDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function MarkedForHold(ByVal BatchNo As String, ByVal DaySl As Integer, ByVal EndDate As Date) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.Parameters.Add("@EndDate", SqlDbType.SmallDateTime, 4).Value = EndDate
                da.SelectCommand.CommandText = "select cnt = case when c.heat_number is null then b.heat_number else c.heat_number end , " & _
                    " Message = case when b.Message is null then c.Message else b.Message end  " & _
                    " from mm_vw_EastWestWhls_5DigitHtNo a " & _
                    " left outer join mm_HoldHeatsFromDespatch b on EastHtNo = b.heat_number " & _
                    " left outer join mm_HoldHeatsFromDespatch c on WestHtNo = c.heat_number " & _
                    " where batch_number = '" & BatchNo.Trim & "' and day_serial = " & Val(DaySl) & " " & _
                    " and ( @EndDate <= isnull(b.HoldToDate,'1900-01-01') or @EndDate <= isnull(c.HoldToDate,'1900-01-01') )"
                da.Fill(ds)
                MarkedForHold = ds.Tables(0)
            Catch exp As Exception
                MarkedForHold = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function InspSets(ByVal BatchNumber As String) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "mm_sp_InspSetsList"
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.Add("@batch_number", SqlDbType.VarChar, 3).Value = BatchNumber.Trim
            Try
                da.Fill(ds)
                InspSets = ds.Tables(0)
            Catch exp As Exception
                InspSets = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function RejRewCodes() As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "select rej_code+'-'+rtrim(rej_desc) rej_desc , rej_code " & _
                " from mm_mmrjd_dump where location = 'ASIN' or  location = 'AAIN' order by rej_code "
            Try
                da.Fill(ds)
                RejRewCodes = ds.Tables(0)
            Catch exp As Exception
                RejRewCodes = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function InspScore(ByVal BatchNumber As String) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "mm_sp_si_InspectionScore"
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar, 3).Value = BatchNumber.Trim
            Try
                da.Fill(ds)
                InspScore = ds.Tables(0)
            Catch exp As Exception
                InspScore = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function LooseAxleInspBatches() As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "Select distinct right(batchNumber,3) Ba, BatchNumber Batch" & _
                " from mm_vw_LooseAxlesOfferedForInsp" & _
                " order by right(batchNumber,3) desc , BatchNumber desc"
            Try
                da.Fill(ds)
                LooseAxleInspBatches = ds.Tables(0)
            Catch exp As Exception
                LooseAxleInspBatches = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function PopulateInspWOProductList(ByVal InspDate As Date) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.Parameters.Add("@InspDate", SqlDbType.SmallDateTime, 4).Value = InspDate
            da.SelectCommand.CommandText = "Select distinct a.BatchNumber BatchNo , d.product_code PrCode ," & _
                " case when isnull(type,'') = '' then 'RWF' else rtrim(type) end Make ," & _
                " rtrim(d.drawing_number) DrawingNumber , rtrim(d.description) AxleDescription" & _
                " from mm_loose_axle_inspection a inner join mm_axle_master b" & _
                " on a.AxleNumber = b.axle_number inner join mm_workorder c" & _
                " on c.number = b.workorder_number_ams inner join mm_product_master d" & _
                " on d.product_code = c.product_code and d.product_code not in" & _
                " ( select ProductCode from mm_AxleProductParameters )" & _
                " where InspDate = @InspDate union " & _
                " Select distinct a.BatchNumber BatchNo , d.product_code PrCode ," & _
                " case when isnull(type,'') = '' then 'RWF' else rtrim(type) end Make ," & _
                " rtrim(d.drawing_number) DrawingNumber , rtrim(d.description) AxleDescription" & _
                " from mm_loose_axle_inspection a inner join mm_nonrwf_axles b" & _
                " on a.AxleNumber = b.axle_number inner join mm_workorder c" & _
                " on c.number = b.workorder_number_ams inner join mm_product_master d" & _
                " on d.product_code = c.product_code and d.product_code not in" & _
                " ( select ProductCode from mm_AxleProductParameters )" & _
                " where InspDate = @InspDate "
            Try
                da.Fill(ds)
                PopulateInspWOProductList = ds.Tables(0)
            Catch exp As Exception
                PopulateInspWOProductList = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function LooseAxleProduct(ByVal BatchNo As String, Optional ByVal Offer As Boolean = False) As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim i As Int16
            Try
                cmd.Connection.Open()
                cmd.Parameters.Add("@BatchNo", SqlDbType.VarChar, 50).Value = BatchNo
                cmd.Parameters.Add("@Count", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                If Offer Then
                    cmd.CommandText = "Select @Count = count(*) from mm_AxleProductParameters " & _
                        " where ProductCode in ( " & _
                        " Select distinct d.product_code" & _
                        " from mm_vw_LooseAxlesOfferedForInsp a inner join mm_axle_master b" & _
                        " on a.AxleNumber = b.axle_number inner join mm_workorder c" & _
                        " on c.number = b.workorder_number_ams inner join mm_product_master d" & _
                        " on d.product_code = c.product_code " & _
                        " where a.BatchNumber = @BatchNo union " & _
                        " Select distinct d.product_code" & _
                        " from mm_vw_LooseAxlesOfferedForInsp a inner join mm_nonrwf_axles b" & _
                        " on a.AxleNumber = b.axle_number inner join mm_workorder c" & _
                        " on c.number = b.workorder_number_ams inner join mm_product_master d" & _
                        " on d.product_code = c.product_code " & _
                        " where a.BatchNumber = @BatchNo )"
                Else
                    cmd.CommandText = "Select @Count = count(*) from mm_AxleProductParameters " & _
                        " where ProductCode in ( " & _
                        " Select distinct d.product_code" & _
                        " from mm_loose_axle_inspection a inner join mm_axle_master b" & _
                        " on a.AxleNumber = b.axle_number inner join mm_workorder c" & _
                        " on c.number = b.workorder_number_ams inner join mm_product_master d" & _
                        " on d.product_code = c.product_code " & _
                        " where a.BatchNumber = @BatchNo union " & _
                        " Select distinct d.product_code" & _
                        " from mm_loose_axle_inspection a inner join mm_nonrwf_axles b" & _
                        " on a.AxleNumber = b.axle_number inner join mm_workorder c" & _
                        " on c.number = b.workorder_number_ams inner join mm_product_master d" & _
                        " on d.product_code = c.product_code " & _
                        " where a.BatchNumber = @BatchNo )"
                End If
                cmd.ExecuteScalar()
                LooseAxleProduct = IIf(IsDBNull(cmd.Parameters("@Count").Value), 0, cmd.Parameters("@Count").Value)
            Catch exp As Exception
                LooseAxleProduct = 0
                Throw New Exception(exp.Message)
            Finally
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function PopulateInspBatches(Optional ByVal InspDate As Date = #1/1/1900#) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim sqlstr As New System.Text.StringBuilder()
            sqlstr.Append("Select distinct BatchNumber , InspDate from mm_loose_axle_inspection ")
            If InspDate > CDate("1/1/1900") Then
                da.SelectCommand.Parameters.Add("@InspDate", SqlDbType.SmallDateTime, 4).Value = InspDate
                sqlstr.Append(" where InspDate = @InspDate")
            Else
                sqlstr.Append(" where InspDate between dateadd(m,-3,getdate()) and getdate()")
            End If
            sqlstr.Append(" order by InspDate desc , BatchNumber Desc ")
            da.SelectCommand.CommandText = sqlstr.ToString
            Try
                da.Fill(ds)
                PopulateInspBatches = ds.Tables(0)
            Catch exp As Exception
                PopulateInspBatches = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
                sqlstr = Nothing
            End Try
        End Function
        Public Shared Function InspDates() As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "Select distinct InspDate , convert(varchar(11),InspDate,103) InspDateCh " & _
                " from mm_loose_axle_inspection where InspDate between dateadd(m,-3,getdate()) and getdate() order by InspDate Desc"
            Try
                da.Fill(ds)
                InspDates = ds.Tables(0)
            Catch exp As Exception
                InspDates = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function QACDetails(ByVal dc As String, ByVal wagLorryNumber As String, ByVal ProductCode As String) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.Parameters.Add("@dc", SqlDbType.VarChar, 50).Value = dc.Trim
            da.SelectCommand.Parameters.Add("@wagLorryNumber", SqlDbType.VarChar, 50).Value = wagLorryNumber.Trim
            da.SelectCommand.Parameters.Add("@ProductCode", SqlDbType.VarChar, 50).Value = ProductCode.Trim
            da.SelectCommand.CommandText = "mm_sp_QAC_Querry"
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            Try
                da.Fill(ds)
                QACDetails = ds.Tables(0)
            Catch exp As Exception
                QACDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function ProductNumbers(ByVal DCNumber As String, ByVal Wagon As String) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.Parameters.Add("@dcNo", SqlDbType.VarChar, 50).Value = DCNumber.Trim
            da.SelectCommand.Parameters.Add("@wagon", SqlDbType.VarChar, 50).Value = Wagon.Trim
            da.SelectCommand.CommandText = "mm_sp_si_ProductCodesDespatched"
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            Try
                da.Fill(ds)
                ProductNumbers = ds.Tables(0)
            Catch exp As Exception
                ProductNumbers = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function WagonNumbers(ByVal DCNumber As String) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.Parameters.Add("@DCNumber", SqlDbType.VarChar, 50).Value = DCNumber.Trim
            da.SelectCommand.CommandText = "select distinct wagon_lorry_number FROM dm_fg_despatch_wagon WHERE dc_number = @DCNumber "
            Try
                da.Fill(ds)
                WagonNumbers = ds.Tables(0)
            Catch exp As Exception
                WagonNumbers = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function DCDetails(ByVal DCNumber As String) As DataSet
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.Parameters.Add("@DCNumber", SqlDbType.VarChar, 20).Value = DCNumber
            da.SelectCommand.CommandText = "SELECT wagon_lorry_number FROM dm_fg_despatch_wagon " & _
                " WHERE dc_number = @DCNumber ; " & _
                " SELECT DISTINCT product_code FROM dm_fg_despatch_products " & _
                " WHERE dc_number = @DCNumber "
            Try
                da.Fill(ds)
                DCDetails = ds
            Catch exp As Exception
                DCDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
#End Region
#Region " Methods"
        Public Function ReOffer(ByVal InspectionDate As Date, ByVal Shift As String, ByVal Operator1 As String, ByVal Axle As String, ByVal Memo As String, ByVal Qty As Integer, ByVal WapStatus As String, ByVal SLno As Integer, ByVal WO As String, ByVal dat As Date, ByVal oldrem As String, ByVal Batch As String, ByVal Rej As Boolean, ByVal Str As String, ByVal pcode As String) As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim done As Boolean
            Dim err As Boolean
            Try
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                cmd.CommandText = " insert into mm_wheelset_inspection_details (inspection_date , shift_code , " &
                    " operator_code , axle_number , memo_number , batch_quantity , inspection_code , wap_status , " &
                    " sl_no , wo_no , mount_date , hld_rem , batch_no ) " &
                    " values ('" & Format(CDate(InspectionDate), "MM/dd/yyyy") & "', '" & Shift & "', " &
                    " '" & Operator1 & "','" & Axle & "','" & Memo & "','" & CInt(Qty) & "','" & WapStatus & "', " &
                    " '" & WapStatus & "','" & SLno & "','" & WO & "','" & Format(CDate(Trim(dat)), "MM/dd/yyyy") & "', " &
                    " '" & oldrem & "','" & Batch.Trim & "')"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "update mm_mounting_press set rdso_inspection_status = '" & WapStatus & "' , " &
                    " rdso_inspection_number = '" & Batch & "', wap_status = '" & WapStatus & "' " &
                    " where axle_number = '" & Axle & "' and batch_number = '" & Batch & "' " &
                    " and day_serial =' " & SLno & "' "
                cmd.ExecuteNonQuery()
                If Rej Then
                    cmd.CommandText = "insert into mm_axle_rejection_details ( rejection_date , shift_code , " &
                        " axle_number , rejection_rework_code , rejection_rework_description , workorder_number , " &
                        " rejection_location , product_code ) values ('" & Format(CDate(InspectionDate), "MM/dd/yyyy") & "' , " &
                        " '" & Shift & "','" & Axle & "','" & oldrem & "','" & Str.Trim & "','" & WO & "','AAIN','" & pcode & "')"
                    cmd.ExecuteNonQuery()
                End If
                done = True
            Catch exp As Exception
                err = True
                Throw New Exception("Update Sets Edited Flag error : " & exp.Message)
            Finally
                If err = False Then
                    If done Then
                        cmd.Transaction.Commit()
                    Else
                        cmd.Transaction.Rollback()
                    End If
                End If
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
            Return done
        End Function
        Public Sub updateSetsEditedFlag(ByVal InspDate As Date)
            Dim sqlcmd As New SqlClient.SqlCommand()
            sqlcmd.Connection = rwfGen.Connection.ConObj
            sqlcmd.CommandText = " update c set c.SetsEdited = 0 " & _
                " from mm_Wheelsets_internalQAC_Reference a " & _
                " inner join mm_internal_qac_detail b on a.batch_number = b.batch_number and " & _
                " a.day_serial = b.day_serial inner join mm_internal_qac_header c " & _
                " on c.internal_qac_id = b.internal_qac_id  " & _
                " where a.inspectionDate = @InspDate "
            sqlcmd.Parameters.Add("@InspDate", SqlDbType.SmallDateTime, 4).Value = CDate(InspDate)
            Dim done As Boolean
            Try
                If sqlcmd.Connection.State = ConnectionState.Closed Then sqlcmd.Connection.Open()
                sqlcmd.Transaction = sqlcmd.Connection.BeginTransaction
                sqlcmd.ExecuteNonQuery()
                done = True
            Catch exp As Exception
                Throw New Exception("Update Sets Edited Flag error : " & exp.Message)
            Finally
                If done Then
                    sqlcmd.Transaction.Commit()
                Else
                    sqlcmd.Transaction.Rollback()
                End If
                If sqlcmd.Connection.State = ConnectionState.Open Then sqlcmd.Connection.Close()
                sqlcmd.Dispose()
                sqlcmd = Nothing
                done = Nothing
            End Try
        End Sub
        Public Sub DeleteInQAC()
            ' added on 15-2-2006 svi
            ' sDeleteFromQACDetailNotPassedSets
            ' Wheelset Inspection can revise wap_status before DMS despatches
            ' To accommdate turning Passed to Not Passed status of wheelset
            ' before Inspection before despatch this command will delete 
            ' set from internal qac whose latest status is not passed
            Dim sqlcmd As New SqlClient.SqlCommand()
            Dim done As Boolean
            sqlcmd.Connection = rwfGen.Connection.ConObj
            Try
                If sqlcmd.Connection.State = ConnectionState.Closed Then sqlcmd.Connection.Open()
                sqlcmd.Transaction = sqlcmd.Connection.BeginTransaction
                sqlcmd.CommandText = " delete mm_internal_qac_detail " & _
                " where isnull(despatched,0) = 0  and product_no in (" & _
                " select a.product_no from mm_wheelsets_internalqac_reference a inner join  " & _
                " mm_internal_qac_detail b on a.product_no = b.product_no and isnull(a.wap_status,'') <> 'p') "
                sqlcmd.ExecuteNonQuery()
                done = True
            Catch exp As Exception
                Throw New Exception(" Delete Error: " & exp.Message)
            Finally
                If done Then
                    sqlcmd.Transaction.Commit()
                Else
                    sqlcmd.Transaction.Rollback()
                End If
                If sqlcmd.Connection.State = ConnectionState.Open Then sqlcmd.Connection.Close()
                sqlcmd.Dispose()
                sqlcmd = Nothing
                done = Nothing
            End Try
        End Sub
        Public Function CloseInternalQAC() As Boolean
            Dim sqlcmd As New SqlClient.SqlCommand()
            sqlcmd.Connection = rwfGen.Connection.ConObj
            sqlcmd.Parameters.Add("@Used", SqlDbType.Bit, 1).Value = False
            sqlcmd.Parameters.Add("@UnUsed", SqlDbType.Bit, 1).Direction = ParameterDirection.Output
            sqlcmd.Parameters.Add("@Internal_QAC_ID", SqlDbType.BigInt, 8).Direction = ParameterDirection.InputOutput
            sqlcmd.Parameters("@Internal_QAC_ID").Value = 0
            Dim sCheckForUnusedQACID As String = " select @UnUsed = count(*) from mm_internal_qac_header where used = 0 "
            Dim sGetQACID As String = " select top 1 @Internal_QAC_ID =  Internal_QAC_ID " & _
                            " from mm_internal_qac_header where used = 0 order by Internal_QAC_ID desc"
            Dim sUpdateQACHeader As String = "update mm_internal_QAC_header " & _
                            " set used = @Used where internal_qac_id = @Internal_QAC_ID"
            Try
                If sqlcmd.Connection.State = ConnectionState.Closed Then sqlcmd.Connection.Open()
                sqlcmd.Transaction = sqlcmd.Connection.BeginTransaction
                sqlcmd.CommandText = sCheckForUnusedQACID
                sqlcmd.ExecuteScalar()
                If sqlcmd.Parameters("@UnUsed").Value = True Then
                    sqlcmd.CommandText = sGetQACID
                    sqlcmd.ExecuteScalar()
                    sqlcmd.CommandText = sUpdateQACHeader
                    sqlcmd.Parameters("@Used").Value = True
                    sqlcmd.ExecuteNonQuery()
                End If
                CloseInternalQAC = True
            Catch exp As Exception
                Throw New Exception(exp.Message)
                CloseInternalQAC = False
            Finally
                If CloseInternalQAC Then
                    sqlcmd.Transaction.Commit()
                Else
                    sqlcmd.Transaction.Rollback()
                End If
                If sqlcmd.Connection.State = ConnectionState.Open Then sqlcmd.Connection.Close()
                sqlcmd.Dispose()
                sqlcmd = Nothing
            End Try
            sCheckForUnusedQACID = Nothing
            sGetQACID = Nothing
            sUpdateQACHeader = Nothing
        End Function
        Public Function GenQAC(ByVal row As DataRow, ByVal UserID As String) As Boolean
            Dim sCheckBatchInQACDetails As String = "select @RelasedProduct = count(*) " & _
                " from mm_internal_qac_detail where batch_number = @BatchNumber and day_serial = @DaySerial "
            Dim sCheckForUnusedQACID As String = " select @UnUsed = count(*) from mm_internal_qac_header where used = 0 "
            Dim sInsertInQACHeader As String = " insert into  mm_internal_qac_header " & _
                " (empcode, datetimesaved, used ) values (@empCode, @DateTimeSaved, @Used)"
            Dim sGetQACID As String = " select top 1 @Internal_QAC_ID =  Internal_QAC_ID " & _
                " from mm_internal_qac_header where used = 0 order by Internal_QAC_ID desc"
            Dim sInsertInQACDetail As String = "insert into mm_internal_qac_detail " & _
                " (Internal_QAC_ID, Batch_Number, Day_serial ) values " & _
                " (@StoreInternal_QAC_ID, @BatchNumber, @Dayserial )"
            Dim sUpdateQACHeader As String = "update mm_internal_QAC_header " & _
                " set used = @Used where internal_qac_id = @Internal_QAC_ID"
            Dim sUpdateQACProductNo As String = "update mm_internal_qac_detail " & _
                " set product_no = batch_number + '/'+convert(varchar,day_serial) " & _
                " where isnull(product_no ,'') <> batch_number + '/'+convert(varchar,day_serial)"
            Dim sqlcmd As New SqlClient.SqlCommand()
            sqlcmd.Connection = rwfGen.Connection.ConObj
            sqlcmd.Parameters.Add("@RelasedProduct", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            sqlcmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar, 50).Value = row("Batch_Number")
            sqlcmd.Parameters.Add("@DaySerial", SqlDbType.Int, 4).Value = row("Day_Serial")
            sqlcmd.Parameters.Add("@empCode", SqlDbType.VarChar, 6).Value = UserID
            sqlcmd.Parameters.Add("@DateTimeSaved", SqlDbType.SmallDateTime, 8).Value = Now
            sqlcmd.Parameters.Add("@Used", SqlDbType.Bit, 1).Value = False
            sqlcmd.Parameters.Add("@StoreInternal_QAC_ID", SqlDbType.BigInt, 8).Value = 0

            sqlcmd.Parameters.Add("@UnUsed", SqlDbType.Bit, 1).Direction = ParameterDirection.Output
            sqlcmd.Parameters.Add("@Internal_QAC_ID", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
            Try
                If sqlcmd.Connection.State = ConnectionState.Closed Then sqlcmd.Connection.Open()
                sqlcmd.Transaction = sqlcmd.Connection.BeginTransaction
                sqlcmd.CommandText = sCheckBatchInQACDetails
                sqlcmd.ExecuteScalar()
                If sqlcmd.Parameters("@RelasedProduct").Value = 0 Then
                    sqlcmd.CommandText = sCheckForUnusedQACID
                    sqlcmd.ExecuteScalar()
                    If sqlcmd.Parameters("@UnUsed").Value = False Then
                        sqlcmd.CommandText = sInsertInQACHeader
                        sqlcmd.ExecuteNonQuery()
                    End If
                    sqlcmd.CommandText = sGetQACID
                    sqlcmd.ExecuteScalar()
                    sqlcmd.Parameters("@StoreInternal_QAC_ID").Value = sqlcmd.Parameters("@Internal_QAC_ID").Value
                    sqlcmd.CommandText = sInsertInQACDetail
                    sqlcmd.ExecuteNonQuery()
                    sqlcmd.CommandText = sUpdateQACHeader
                    sqlcmd.Parameters("@Used").Value = True
                    sqlcmd.ExecuteNonQuery()
                    sqlcmd.CommandText = sUpdateQACProductNo
                    sqlcmd.ExecuteNonQuery()
                End If
                GenQAC = True
            Catch exp As Exception
                GenQAC = False
                Throw New Exception(exp.Message)
            Finally
                If GenQAC Then
                    sqlcmd.Transaction.Commit()
                Else
                    sqlcmd.Transaction.Rollback()
                End If
                If sqlcmd.Connection.State = ConnectionState.Open Then sqlcmd.Connection.Close()
                sqlcmd.Dispose()
                sqlcmd = Nothing
            End Try
            sCheckBatchInQACDetails = Nothing
            sCheckForUnusedQACID = Nothing
            sInsertInQACHeader = Nothing
            sGetQACID = Nothing
            sInsertInQACDetail = Nothing
            sUpdateQACHeader = Nothing
            sUpdateQACProductNo = Nothing
        End Function
        Public Function EditInspDetails(ByVal LastInspDate As Date, ByVal LastInspRem As String, ByVal Axle As String, ByVal Batch As String, ByVal SLno As Integer, ByVal LastInspShift As String, ByVal Operator1 As String, ByVal Shift As String, ByVal AxleProductCode As String, ByVal RejCode As String, ByVal RejRewDesc As String, ByVal WO As String, ByVal Wap_status As String) As Boolean
            Dim strCmdAudit, strCmdRejRewDel, strCmdInsertRejRew, strCmdLastRejRew, strUpdateInsp, strMountPressUpdate, sBlockInternalQAC As String
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            cmd.Parameters.Add("@EditedDateTime", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output

            cmd.Parameters.Add("@inspection_date", SqlDbType.SmallDateTime, 4).Value = CDate(LastInspDate)
            cmd.Parameters.Add("@LastInspRem", SqlDbType.VarChar, 50).Value = LastInspRem
            cmd.Parameters.Add("@axle_Number", SqlDbType.VarChar, 50).Value = Axle
            cmd.Parameters.Add("@batch_no", SqlDbType.VarChar, 50).Value = Batch.ToUpper
            cmd.Parameters.Add("@sl_no", SqlDbType.Int, 4).Value = Val(SLno)
            cmd.Parameters.Add("@shift_code", SqlDbType.VarChar, 1).Value = LastInspShift
            cmd.Parameters.Add("@EditedBy", SqlDbType.VarChar, 6).Value = Operator1
            cmd.Parameters.Add("@rejection_Date", SqlDbType.SmallDateTime, 4).Value = CDate(LastInspDate)
            cmd.Parameters.Add("@Shift", SqlDbType.VarChar, 1).Value = Shift
            cmd.Parameters.Add("@product_code", SqlDbType.VarChar, 6).Value = AxleProductCode
            cmd.Parameters.Add("@Rejection_Rework_code", SqlDbType.VarChar, 50).Value = RejCode
            cmd.Parameters.Add("@rejection_rework_description", SqlDbType.VarChar, 50).Value = RejRewDesc
            cmd.Parameters.Add("@workorder_number", SqlDbType.VarChar, 4).Value = WO
            cmd.Parameters.Add("@Rejection_Location", SqlDbType.VarChar, 4).Value = "AAIN"
            cmd.Parameters.Add("@wap_status", SqlDbType.VarChar, 1).Value = Wap_status
            cmd.Parameters.Add("@hldRem", SqlDbType.VarChar, 50).Value = RejCode
            cmd.Parameters.Add("@Batch_Number", SqlDbType.VarChar, 50).Value = Batch.ToUpper
            cmd.Parameters.Add("@day_serial", SqlDbType.Int, 4).Value = Val(SLno)
            cmd.Parameters.Add("@InspDate", SqlDbType.SmallDateTime, 4).Value = CDate(LastInspDate)

            sBlockInternalQAC = "update c set c.SetsEdited = 1 from mm_Wheelsets_internalQAC_Reference a " &
                                       " inner join mm_internal_qac_detail b on a.batch_number = b.batch_number and " &
                                       " a.day_serial = b.day_serial inner join mm_internal_qac_header c " &
                                       " on c.internal_qac_id = b.internal_qac_id  " &
                                       " where a.inspectionDate = @InspDate"

            strCmdAudit = " insert into mm_wheelset_inspection_details_audit ( " &
                                    " inspection_date, shift_code, " &
                                    " operator_code, axle_number, memo_number, batch_no, " &
                                    " batch_quantity, Inspection_code, wap_status, " &
                                    " sl_no, mount_date, wo_no, hld_rem , " &
                                    " EditedDateTime, EditedBy ) " &
                                    " select top 1 inspection_date, shift_code, " &
                                    " operator_code, axle_number, memo_number, batch_no, " &
                                    " batch_quantity, Inspection_code, wap_status, " &
                                    " sl_no, mount_date, wo_no, hld_rem , " &
                                    " getdate() , @EditedBy from mm_wheelset_inspection_details " &
                                    " where batch_no = @batch_no and sl_no = @sl_no and " &
                                    " inspection_date = @inspection_date and shift_code = @shift_code " &
                                    " order by inspection_date desc , shift_code desc ; " &
                                    " select top 1 @EditedDateTime = EditedDateTime from mm_wheelset_inspection_details_audit where " &
                                    " batch_no = @batch_no and sl_no = @sl_no and " &
                                    " inspection_date = @inspection_date and shift_code = @shift_code order by " &
                                    " RecordNumber desc "

            strCmdLastRejRew = "select @cnt = count(*) from mm_axle_rejection_details where rejection_date = @inspection_date and " &
                     " rejection_location = 'aain' and rejection_rework_code = @LastInspRem and axle_number = @Axle_Number"

            strCmdRejRewDel = "Delete from mm_axle_rejection_details where rejection_date = @inspection_date and " &
                              " rejection_location = 'aain' and rejection_rework_code = @LastInspRem and axle_number = @Axle_Number"

            strCmdInsertRejRew = "Insert into mm_axle_rejection_details (rejection_Date, Shift_code, axle_number, product_code, Rejection_Rework_code, rejection_rework_description, workorder_number, rejection_location ) values (" &
                                      " @rejection_Date, @Shift, @axle_Number, @product_code, @Rejection_Rework_code, @rejection_rework_description, @workorder_number, @rejection_location ) "

            strUpdateInsp = "Update mm_wheelset_Inspection_details set wap_status = @wap_status, hld_rem = @hldRem " &
                            " where batch_no = @Batch_No and sl_no = @sl_no and " &
                            " axle_number = @Axle_Number  and Inspection_date = @inspection_date and hld_rem = @LastInspRem "
            strMountPressUpdate = "update mm_mounting_press set wap_status = @wap_status, rdso_inspection_status = @wap_status where batch_number = @batch_number and day_serial = @day_serial and axle_number = @axle_number"
            Dim done As Boolean
            Try
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                cmd.CommandText = strCmdAudit
                cmd.ExecuteNonQuery()
                cmd.CommandText = sBlockInternalQAC
                cmd.ExecuteNonQuery()

                If LastInspRem = "W" Or LastInspRem = "R" Then
                    cmd.CommandText = strCmdLastRejRew
                    Dim cnt As Integer
                    cnt = cmd.ExecuteNonQuery
                    If cnt > 0 Then
                        cmd.CommandText = strCmdRejRewDel
                        cmd.ExecuteNonQuery()
                    End If
                    cnt = Nothing
                End If

                If Wap_status.ToUpper = "R" Or Wap_status.ToUpper.Trim = "W" Then
                    cmd.CommandText = strCmdInsertRejRew
                    cmd.ExecuteNonQuery()
                End If
                cmd.CommandText = strUpdateInsp
                cmd.ExecuteNonQuery()
                cmd.CommandText = strMountPressUpdate
                cmd.ExecuteNonQuery()
                done = True
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If Not cmd Is Nothing Then
                    If done Then
                        cmd.Transaction.Commit()
                    Else
                        cmd.Transaction.Rollback()
                    End If
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                End If
            End Try
            EditInspDetails = done
            strCmdAudit = Nothing
            strCmdRejRewDel = Nothing
            strCmdInsertRejRew = Nothing
            strCmdLastRejRew = Nothing
            strUpdateInsp = Nothing
            strMountPressUpdate = Nothing
            sBlockInternalQAC = Nothing
        End Function
        Public Function SaveOne(ByVal InspDate As Date, ByVal sInspStatusValue As String, ByVal sBatchNumber As String, ByVal iSl_No As Integer, ByVal Shift As String, ByVal Inspector As String, ByVal TotalQty As Integer, ByVal dMountDate As Date, ByVal sWoNo As String, ByVal sRejRewCode As String, ByVal sAxleNumber As String, ByVal sMemoNumber As String, ByVal sProductCode As String, ByVal sRejRewDesc As String) As Boolean
            Dim strTrans, strRej, sMtPress, sBlockInternalQAC As String
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            sBlockInternalQAC = "update c set c.SetsEdited = 1 from mm_Wheelsets_internalQAC_Reference a " & _
                                " inner join mm_internal_qac_detail b on a.batch_number = b.batch_number and " & _
                                " a.day_serial = b.day_serial inner join mm_internal_qac_header c " & _
                                " on c.internal_qac_id = b.internal_qac_id  " & _
                                " where a.inspectionDate = @InspDate"

            strTrans = "Insert into mm_wheelset_Inspection_details (inspection_date, shift_code, operator_code, axle_number, " & _
                                  " batch_no, sl_no,  batch_quantity, inspection_code, wap_status,  mount_date, wo_no, hld_rem, memo_number ) values " & _
                                  " (@inspection_date, @shift_code, @operator_code, @axle_number, @batch_number, @Day_Serial, @batch_quantity, " & _
                                  "@inspection_code, @wap_status, @mount_date, @wo_no, @hld_rem, @Memo_Number) "

            strRej = "Insert into mm_axle_rejection_details (rejection_date, shift_code, axle_number, product_code, " & _
                                          " rejection_rework_code, rejection_rework_description, workorder_number,   rejection_location ) " & _
                                          " values (@rejection_date, @shift_code, @axle_number, @product_code, @rejection_rework_code, " & _
                                          " @rejection_rework_description, @workorder_number,   @rejection_location ) "

            sMtPress = "Update mm_Mounting_Press set rdso_inspection_status = @rdso_inspection_status, rdso_inspection_number " & _
                                   "= @rdso_inspection_number, wap_status = @wap_status where batch_number = @Batch_Number and " & _
                                   " day_serial = @Day_serial "

            cmd.Parameters.Add("@InspDate", SqlDbType.SmallDateTime, 4).Value = CDate(InspDate)
            cmd.Parameters.Add("@rdso_inspection_status", SqlDbType.VarChar, 1).Value = sInspStatusValue
            cmd.Parameters.Add("@rdso_inspection_number", SqlDbType.VarChar, 3).Value = sBatchNumber
            cmd.Parameters.Add("@wap_status", SqlDbType.VarChar, 1).Value = sInspStatusValue
            cmd.Parameters.Add("@batch_Number", SqlDbType.VarChar, 3).Value = sBatchNumber
            cmd.Parameters.Add("@Day_serial", SqlDbType.Int, 4).Value = iSl_No
            cmd.Parameters.Add("@inspection_date", SqlDbType.SmallDateTime, 4).Value = CDate(InspDate)
            cmd.Parameters.Add("@shift_code", SqlDbType.VarChar, 1).Value = Shift
            cmd.Parameters.Add("@operator_code", SqlDbType.VarChar, 6).Value = Inspector
            cmd.Parameters.Add("@batch_quantity", SqlDbType.Int, 4).Value = TotalQty
            cmd.Parameters.Add("@inspection_code", SqlDbType.VarChar, 50).Value = Inspector
            cmd.Parameters.Add("@mount_date", SqlDbType.SmallDateTime, 4).Value = dMountDate
            cmd.Parameters.Add("@wo_no", SqlDbType.VarChar, 4).Value = sWoNo
            If sInspStatusValue.Trim.ToLower.StartsWith("p") Then sRejRewCode = ""
            cmd.Parameters.Add("@hld_rem", SqlDbType.VarChar, 50).Value = sRejRewCode
            cmd.Parameters.Add("@axle_number", SqlDbType.VarChar, 50).Value = sAxleNumber
            cmd.Parameters.Add("@Memo_Number", SqlDbType.VarChar, 20).Value = sMemoNumber
            cmd.Parameters.Add("@rejection_date", SqlDbType.SmallDateTime, 4).Value = CDate(InspDate)
            cmd.Parameters.Add("@product_code", SqlDbType.VarChar, 6).Value = sProductCode
            cmd.Parameters.Add("@rejection_rework_code", SqlDbType.VarChar, 50).Value = sRejRewCode
            cmd.Parameters.Add("@rejection_rework_description", SqlDbType.VarChar, 50).Value = sRejRewDesc
            cmd.Parameters.Add("@rejection_location", SqlDbType.VarChar, 4).Value = "AAIN"
            cmd.Parameters.Add("@workorder_number", SqlDbType.VarChar, 4).Value = sWoNo
            Dim msg As String = ""
            Try
                cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction()
                cmd.CommandText = sMtPress
                cmd.ExecuteNonQuery()
                cmd.CommandText = strTrans
                cmd.ExecuteNonQuery()
                cmd.CommandText = sBlockInternalQAC
                cmd.ExecuteNonQuery()
                If sInspStatusValue <> "P" Then
                    cmd.CommandText = strRej
                    cmd.ExecuteNonQuery()
                End If
                SaveOne = True
            Catch exp As Exception
                SaveOne = False
                msg = exp.Message
            Finally
                If Not msg.EndsWith("The transaction ended in the trigger. The batch has been aborted.") Then
                    If SaveOne Then
                        cmd.Transaction.Commit()
                    Else
                        cmd.Transaction.Rollback()
                    End If
                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If
                    cmd.Dispose()
                    cmd = Nothing
                    If msg.Trim.Length > 0 Then
                        Throw New Exception(msg)
                    End If
                Else
                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If
                    cmd.Dispose()
                    cmd = Nothing
                    Throw New Exception(msg)
                End If
            End Try
            strTrans = Nothing
            strRej = Nothing
            sMtPress = Nothing
            sBlockInternalQAC = Nothing
        End Function
#End Region
    End Class
End Namespace
