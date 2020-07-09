Namespace RWF
    <Serializable()> Public Class AWMCLR
        Public Shared Function WFPSOffLoadWheelsSummary(ByVal FrDt As Date, ByVal Sh As String) As DataSet
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "mm_sp_WFPSOffLoadWheelsSummary"
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.Add("@FrDt", SqlDbType.SmallDateTime, 4).Value = FrDt
            da.SelectCommand.Parameters.Add("@Sh", SqlDbType.VarChar, 1).Value = Sh
            Try
                da.Fill(ds)
                WFPSOffLoadWheelsSummary = ds.Copy
            Catch exp As Exception
                WFPSOffLoadWheelsSummary = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function WFPSOffWheelCheck(ByVal Wheel As Long, ByVal Heat As Long, ByVal OffLdDate As Date, ByVal Sh As String) As String
            WFPSOffWheelCheck = ""
            Dim dt As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "select status , location , description " & _
                " from mm_wheel where wheel_number = '" & CInt(Wheel) & "' and heat_number = '" & CInt(Heat) & "'"
            Try
                da.Fill(ds)
                dt = ds.Tables(0).Copy
                If dt.Rows.Count = 0 Then
                    WFPSOffWheelCheck = "Wheel Not found in Master"
                    Exit Function
                Else
                    Dim status As String = Trim(dt.Rows(0)("status"))
                    Dim location As String = Trim(dt.Rows(0)("location"))
                    Dim ocmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
                    ocmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output

                    ocmd.Parameters.Add("@OffLdDate", SqlDbType.SmallDateTime, 4).Value = OffLdDate
                    ocmd.Parameters.Add("@Sh", SqlDbType.VarChar, 1).Value = Sh
                    ocmd.CommandText = "select @cnt = count(*) from mm_WFPSOffLoads " & _
                        " where Wheel = '" & CInt(Wheel) & "' and Heat = '" & CInt(Heat) & "' " & _
                        " and OffLoadDate = @OffLdDate and Shift = @Sh"
                    If ocmd.Connection.State = ConnectionState.Closed Then ocmd.Connection.Open()
                    ocmd.ExecuteScalar()
                    Try
                        If IIf(IsDBNull(ocmd.Parameters("@cnt").Value), 0, ocmd.Parameters("@cnt").Value) > 0 Then
                            Throw New Exception("This Wheel already saved in this Date and Shift !")
                        End If
                    Catch exp As Exception
                        Throw New Exception(exp.Message)
                    Finally
                        If ocmd.Connection.State = ConnectionState.Open Then ocmd.Connection.Close()
                        ocmd.Dispose()
                        ocmd = Nothing
                    End Try

                    If Not WFPSOffWheelCheck.StartsWith("Message") Then
                        WFPSOffWheelCheck = "Wheel Status : " & Trim(dt.Rows(0)("status")) & " Location : " & Trim(dt.Rows(0)("location")) & " WhlType : " & Trim(dt.Rows(0)("description"))
                    End If
                    status = Nothing
                    location = Nothing
                End If
            Catch exp As Exception
                dt = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
                dt = Nothing
            End Try
        End Function
        Public Shared Function RMWheelsSummary(ByVal FrDt As Date, ByVal ToDt As Date, ByVal Type As Integer) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "mm_sp_RMWheelsSummary"
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.SmallDateTime, 4).Value = FrDt
            da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.SmallDateTime, 4).Value = ToDt
            da.SelectCommand.Parameters.Add("@UserGroup", SqlDbType.VarChar, 50).Value = "AWMCLR"
            da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = Type
            Try
                da.Fill(ds)
                RMWheelsSummary = ds.Tables(0).Copy
            Catch exp As Exception
                RMWheelsSummary = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function CheckDS8No(ByVal UserGroup As String, ByVal AdviceNoteNo As String) As Integer
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@UserGroup", SqlDbType.VarChar, 6).Value = UserGroup
            cmd.Parameters.Add("@AdviceNoteNo", SqlDbType.VarChar, 6).Value = AdviceNoteNo
            cmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            cmd.CommandText = "select @cnt = count(*) from mm_ReturnedStoresDetails " & _
                " where AdviceNoteNo = @AdviceNoteNo and UserGroup = @UserGroup"
            Try
                cmd.Connection.Open()
                cmd.ExecuteScalar()
                CheckDS8No = IIf(IsDBNull(cmd.Parameters("@cnt").Value), 0, cmd.Parameters("@cnt").Value)
            Catch exp As Exception
                CheckDS8No = 0
                Throw New Exception(exp.Message)
            Finally
                If IsNothing(cmd) = False Then
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                End If
            End Try
        End Function
        Public Shared Function checkwheel(ByVal Wheel As Long, ByVal Heat As Long) As String
            checkwheel = ""
            Dim dt As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = " select status , location , description " & _
                " from mm_wheel where wheel_number = '" & CInt(Wheel) & "' and heat_number = '" & CInt(Heat) & "'"
            da.SelectCommand.Parameters.Add("@Today", SqlDbType.SmallDateTime, 4).Value = Now.Date
            da.SelectCommand.Parameters.Add("@Product", SqlDbType.VarChar, 1).Value = "W"
            Try
                da.Fill(ds)
                dt = ds.Tables(0).Copy
            Catch exp As Exception
                dt = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
            If dt.Rows.Count = 0 Then
                checkwheel = "Wheel Not found in Master"
                Exit Function
            Else
                Dim status As String = Trim(dt.Rows(0)("status"))
                Dim location As String = Trim(dt.Rows(0)("location"))
                If location = "CLMT" Then
                    If Left(status.ToUpper, 2) = "XC" Then
                        If Left(status, 3).ToUpper = "XC8" Then
                            checkwheel = "Message : This wheel is not a Rejected ; having the status " & Trim(dt.Rows(0)("status")) & " Location:" & Trim(dt.Rows(0)("location"))
                            Exit Function
                        End If
                    Else
                        checkwheel = "Message : This wheel is not a Rejected having the status " & Trim(dt.Rows(0)("status")) & " Location:" & Trim(dt.Rows(0)("location"))
                        Exit Function
                    End If
                End If
                If location = "CLFI" Then
                    If Left(Trim(dt.Rows(0)("status")).ToUpper, 1) <> "R" Then
                        checkwheel = "Message : This wheel is having the last status:" & Trim(dt.Rows(0)("status")) & " Location:" & Trim(dt.Rows(0)("location"))
                        Exit Function
                    End If
                End If
                If location = "CLQC" Then
                    If (Left(Trim(dt.Rows(0)("status")).ToUpper, 1)) <> "XC" OrElse (Left(Trim(dt.Rows(0)("status")).ToUpper, 2)) <> "RL" Then
                        checkwheel = "Message : This wheel is having the last status:" & Trim(dt.Rows(0)("status")) & " Location:" & Trim(dt.Rows(0)("location"))
                        Exit Function
                    End If
                End If
                If location = "CLFQ" Then
                    If Left(Trim(dt.Rows(0)("status")).ToUpper, 1) = "W" Then
                        checkwheel = "Message : This wheel is having the last status:" & Trim(dt.Rows(0)("status")) & " Location:" & Trim(dt.Rows(0)("location"))
                        Exit Function
                    End If
                End If
                If Trim(dt.Rows(0)("location")) <> "CLMT" And Trim(dt.Rows(0)("location")) <> "CLFI" And Trim(dt.Rows(0)("location")) <> "CLQC" And Trim(dt.Rows(0)("location")) <> "CLFQ" Then
                    checkwheel = "Message : This wheel is having the status " & Trim(dt.Rows(0)("status")) & " Location:" & Trim(dt.Rows(0)("location"))
                    Exit Function
                End If
                If Not checkwheel.StartsWith("Message") Then
                    checkwheel = " Wheel Status : " & Trim(dt.Rows(0)("status")) & " Location : " & Trim(dt.Rows(0)("location")) & " WhlType : " & Trim(dt.Rows(0)("description"))
                End If
                status = Nothing
                location = Nothing
                dt = Nothing
            End If
        End Function
        Public Shared Function GetRMWheelsDatesForDS8(ByVal UserGroup As String) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.Parameters.Add("@UserGroup", SqlDbType.VarChar, 50).Value = UserGroup
            da.SelectCommand.CommandText = " select distinct convert(varchar(10),LoadedDate,103) LoadedDate , " & _
                " LoadedDate LoadedDt from mm_ReturnedStoresDetails a inner join mm_ReturnedStoresList b" & _
                " on a.DS8Id = b.DS8Id inner join mm_qci_inspection c" & _
                " on LoadedDate = inspection_date and " & _
                " Item = convert(varchar,wheel_number)+'/'+convert(varchar,heat_number)" & _
                " where UserGroup = @UserGroup and Remarks = 'Dummy'" & _
                " and wheel_disposition = 'rm'" & _
                " order by LoadedDate desc "
            Try
                da.Fill(ds)
                GetRMWheelsDatesForDS8 = ds.Tables(0).Copy
            Catch exp As Exception
                GetRMWheelsDatesForDS8 = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function GetRMWheelsForDS8(ByVal UserGroup As String) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.Parameters.Add("@UserGroup", SqlDbType.VarChar, 50).Value = UserGroup
            da.SelectCommand.CommandText = " select Sl , convert(varchar(11),LoadedDate,103) LoadedDate , LoadedIn , WhlType , cnt , DS8Id " & _
                " from ( select row_number() over ( order by LoadedDate , LoadedIn , product_code ) Sl ," & _
                " LoadedDate  , LoadedIn , product_code WhlType , count(*) cnt , max(a.DS8Id) DS8Id" & _
                " from mm_ReturnedStoresDetails a inner join mm_ReturnedStoresList b" & _
                " on a.DS8Id = b.DS8Id inner join mm_qci_inspection c" & _
                " on LoadedDate = inspection_date and " & _
                " Item = convert(varchar,wheel_number)+'/'+convert(varchar,heat_number)" & _
                " where UserGroup = @UserGroup and Remarks = 'Dummy'" & _
                " and wheel_disposition = 'rm'" & _
                " group by LoadedDate , LoadedIn , product_code ) a" & _
                " order by LoadedDate , LoadedIn "
            Try
                da.Fill(ds)
                GetRMWheelsForDS8 = ds.Tables(0).Copy
            Catch exp As Exception
                GetRMWheelsForDS8 = Nothing
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function GetSavedRMWheels(ByVal UserGroup As String, ByVal LoadedIn As String, ByVal LoadedDate As Date) As DataSet
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            If LoadedIn.Trim.Length > 0 Then
                da.SelectCommand.CommandText = "select row_number() over ( order by ItemId desc ) SlNo ," & _
                    " LoadedIn , LoadedDate , WhlNo ,  Sts , MasterSts from ( " & _
                    " select ItemId , LoadedIn , convert(varchar(11), LoadedDate,103) LoadedDate , Item WhlNo , rtrim(status) Sts , rtrim(status) MasterSts" & _
                    " from mm_ReturnedStoresDetails a inner join mm_ReturnedStoresList b " & _
                    " on a.DS8Id = b.DS8Id inner join mm_wheel c" & _
                    " on dbo.mm_si_fn_WhlStrPart(Item,'w') = wheel_number and dbo.mm_si_fn_WhlStrPart(Item,'h')  = heat_number" & _
                    " where LoadedIn = @LoadedIn and UserGroup = @UserGroup" & _
                    " and LoadedDate = @LoadedDate and Remarks = 'Dummy' and status <> 'REWORK'" & _
                    " union all" & _
                    " select ItemId , LoadedIn , convert(varchar(11),LoadedDate,103) LoadedDate , Item WhlNo , rtrim(d.status) Sts , rtrim(c.status) MasterSts " & _
                    " from mm_ReturnedStoresDetails a inner join mm_ReturnedStoresList b " & _
                    " on a.DS8Id = b.DS8Id inner join mm_WheelsNotPostedAtMagna d" & _
                    " on Item = Wheel inner join mm_wheel c" & _
                    " on dbo.mm_si_fn_WhlStrPart(Item,'w') = wheel_number and dbo.mm_si_fn_WhlStrPart(Item,'h')  = heat_number" & _
                    " where LoadedIn = @LoadedIn and UserGroup = @UserGroup" & _
                    " and LoadedDate = @LoadedDate and a.Remarks = 'Dummy' and c.status = 'REWORK' " & _
                    " ) a order by ItemId desc ;" & _
                    " select LoadedIn , count(*) Cnt " & _
                    " from mm_ReturnedStoresDetails a inner join mm_ReturnedStoresList b " & _
                    " on a.DS8Id = b.DS8Id where UserGroup = @UserGroup" & _
                    " and LoadedDate = @LoadedDate and Remarks = 'Dummy'" & _
                    " group by LoadedIn " & _
                    " order by LoadedIn ;" & _
                    " select product_code WhlType , count(*) cnt " & _
                    " from mm_qci_inspection " & _
                    " where inspection_date = @LoadedDate and wheel_disposition = 'RM'" & _
                    " group by product_code" & _
                    " order by product_code"
            Else
                da.SelectCommand.CommandText = "select row_number() over ( order by ItemId desc ) SlNo ," & _
                    " LoadedIn , LoadedDate , WhlNo ,  Sts , MasterSts from ( " & _
                    " select ItemId , LoadedIn , convert(varchar(11), LoadedDate,103) LoadedDate , Item WhlNo , rtrim(status) Sts , rtrim(status) MasterSts" & _
                    " from mm_ReturnedStoresDetails a inner join mm_ReturnedStoresList b " & _
                    " on a.DS8Id = b.DS8Id inner join mm_wheel c" & _
                    " on dbo.mm_si_fn_WhlStrPart(Item,'w') = wheel_number and dbo.mm_si_fn_WhlStrPart(Item,'h')  = heat_number" & _
                    " where UserGroup = @UserGroup" & _
                    " and LoadedDate = @LoadedDate and Remarks = 'Dummy' and status <> 'REWORK'" & _
                    " union all" & _
                    " select ItemId , LoadedIn , convert(varchar(11),LoadedDate,103) LoadedDate , Item WhlNo , rtrim(d.status) Sts , rtrim(c.status) MasterSts" & _
                    " from mm_ReturnedStoresDetails a inner join mm_ReturnedStoresList b " & _
                    " on a.DS8Id = b.DS8Id inner join mm_WheelsNotPostedAtMagna d" & _
                    " on Item = Wheel inner join mm_wheel c" & _
                    " on dbo.mm_si_fn_WhlStrPart(Item,'w') = wheel_number and dbo.mm_si_fn_WhlStrPart(Item,'h')  = heat_number" & _
                    " where UserGroup = @UserGroup" & _
                    " and LoadedDate = @LoadedDate and a.Remarks = 'Dummy' and c.status = 'REWORK' " & _
                    " ) a order by ItemId desc ;" & _
                    " select LoadedIn , count(*) Cnt " & _
                    " from mm_ReturnedStoresDetails a inner join mm_ReturnedStoresList b " & _
                    " on a.DS8Id = b.DS8Id where UserGroup = @UserGroup" & _
                    " and LoadedDate = @LoadedDate and Remarks = 'Dummy'" & _
                    " group by LoadedIn " & _
                    " order by LoadedIn ;" & _
                    " select product_code WhlType , count(*) cnt " & _
                    " from mm_qci_inspection " & _
                    " where inspection_date = @LoadedDate and wheel_disposition = 'RM'" & _
                    " group by product_code" & _
                    " order by product_code"
            End If
            da.SelectCommand.Parameters.Add("@LoadedDate", SqlDbType.SmallDateTime, 4).Value = LoadedDate
            da.SelectCommand.Parameters.Add("@LoadedIn", SqlDbType.VarChar, 50).Value = LoadedIn
            da.SelectCommand.Parameters.Add("@UserGroup", SqlDbType.VarChar, 50).Value = UserGroup
            da.SelectCommand.Parameters.Add("@AdviceNoteNo", SqlDbType.VarChar, 50).Value = Left(Now.Date.ToString, 10)

            Try
                da.Fill(ds)
                GetSavedRMWheels = ds
            Catch exp As Exception
                GetSavedRMWheels = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function GetContinueShiftData(ByVal InspDate As Date) As DataSet
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.Parameters.Add("@Product", SqlDbType.VarChar, 1).Value = "W"
            da.SelectCommand.Parameters.Add("@dt", SqlDbType.SmallDateTime, 4).Value = CDate(InspDate)

            da.SelectCommand.CommandText = "Select top 20 convert(varchar(11),InspDate,103) WhlsFromDt, Shift , " & _
                " RequiredCount ReqdWhls, DoneCount ShiftedCount , DateTimeAuthorised " & _
                " from mm_ContinueShift_Authorisation  where prodType = @Product order by inspDate desc ,  Shift desc ;" & _
                " select convert(varchar(11),inspection_date,103) InspDate , 'Processed-'+shift_code Shift , count(*) Cnt  " & _
                " from mm_final_inspection where inspection_date = @dt  " & _
                " group by convert(varchar(11),inspection_date,103) , shift_code union " & _
                " select convert(varchar(11),inspection_date,103) InspDate , 'Processed-Total' Shift , count(*) Processed " & _
                " from mm_final_inspection where inspection_date = @dt " & _
                " group by convert(varchar(11),inspection_date,103)  union " & _
                " select convert(varchar(11),inspection_date,103) InspDate, 'Passed-'+shift_code Shift , count(*) Cnt " & _
                " from mm_final_inspection  where inspection_date = @dt and wheel_status like 'P%' " & _
                " group by inspection_date, shift_code  union " & _
                " select convert(varchar(11),inspection_date,103)InspDate , 'Passed-Total' Shift , count(*) Processed  " & _
                " from mm_final_inspection  where inspection_date = @dt and wheel_status like 'P%' " & _
                " group by convert(varchar(11),inspection_date,103) ; " & _
                " select top 20 convert(varchar(10),date,103) HolidayDt , " & _
                " case when shop = 'MEME' then 'Melting' " & _
                "      when shop = 'MOPO' then 'Moulding' " & _
                "      when shop = 'CLCL' then 'WFP Shop'  " & _
                "      when shop = 'AMA' then 'Axle Shop' end  ShopName  , rtrim(dueto) Reason " & _
                " from mm_calendar_dump " & _
                " where shop in ( 'meme' , 'clcl' , 'MOPO' ) " & _
                " order by date desc , ShopName "
            Try
                da.Fill(ds)
                GetContinueShiftData = ds.Copy
            Catch exp As Exception
                GetContinueShiftData = Nothing
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function GetTop1Data() As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "Select top 1 convert(varchar(11),InspDate,103) WhlsFromDt, " & _
                " Shift WhlsFromShift, RequiredCount ReqdWhls, DoneCount  from mm_ContinueShift_Authorisation  " & _
                " where DoneCount = 0 and InspDate >= ( select max(inspection_date) from mm_final_inspection) " & _
                " order by inspDate desc ,  Shift desc "
            Try
                da.Fill(ds)
                GetTop1Data = ds.Tables(0).Copy
            Catch exp As Exception
                GetTop1Data = Nothing
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function GetPosted(ByVal InspDate As Date, ByVal InspShift As String, Optional ByVal Type As Int16 = 0) As Integer
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            If Type = 0 Then
                cmd.CommandText = "Select @cnt = count(*) from mm_final_Inspection where inspection_date = @InspDate and shift_code = @Shift"
                cmd.Parameters.Add("@cnt", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
                cmd.Parameters.Add("@InspDate", SqlDbType.SmallDateTime, 4).Value = CDate(InspDate)
                cmd.Parameters.Add("@Shift", SqlDbType.VarChar, 1).Value = InspShift
            Else
                cmd.CommandText = "Select @cnt = count(*) from mm_final_Inspection where rdso_offtm between @rdsoOfftmFrom and @rdsoOfftmTo"
                cmd.Parameters.Add("@cnt", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
                Dim rdsoOfftmFrom, rdsoOfftmTo As DateTime
                Select Case InspShift
                    Case "A"
                        rdsoOfftmFrom = CDate(InspDate + " 06:00:00")
                        rdsoOfftmTo = CDate(InspDate + " 13:59:59")
                    Case "B"
                        rdsoOfftmFrom = CDate(InspDate + " 14:00:00")
                        rdsoOfftmTo = CDate(InspDate + " 21:59:59")
                    Case "C"
                        rdsoOfftmFrom = CDate(InspDate + " 22:00:00")
                        rdsoOfftmTo = CDate(CDate(InspDate).AddDays(1) + " 05:59:59")
                End Select
                cmd.Parameters.Add("@rdsoOfftmFrom", SqlDbType.DateTime, 8).Value = rdsoOfftmFrom
                cmd.Parameters.Add("@rdsoOfftmTo", SqlDbType.DateTime, 8).Value = rdsoOfftmTo
                rdsoOfftmFrom = Nothing
                rdsoOfftmTo = Nothing
            End If
            Try
                cmd.Connection.Open()
                cmd.ExecuteScalar()
                GetPosted = IIf(IsDBNull(cmd.Parameters("@cnt").Value), 0, cmd.Parameters("@cnt").Value)
            Catch exp As Exception
                GetPosted = 0
            Finally
                If IsNothing(cmd) = False Then
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                End If
            End Try
        End Function
        Public Shared Function LatestPHLDate() As Date
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.CommandText = "Select top 1 Phl_date from mm_phl_Generation order by phl_date desc"
            Try
                cmd.Connection.Open()
                LatestPHLDate = IIf(IsDBNull(cmd.ExecuteScalar), CDate("1/1/1900"), cmd.ExecuteScalar)
            Catch exp As Exception
                LatestPHLDate = CDate("1/1/1900")
            Finally
                If IsNothing(cmd) = False Then
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                End If
            End Try
        End Function
        Public Shared Function getNextLatestData() As DataTable
            Dim dt As Date
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.CommandText = "Select top 1 Phl_date from mm_phl_Generation order by phl_date desc"
            cmd.Connection.Open()
            dt = IIf(IsDBNull(cmd.ExecuteScalar), CDate("1/1/1900"), cmd.ExecuteScalar)
            cmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            cmd.Parameters.Add("@dt", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Input
            cmd.Parameters("@dt").Value = Now.Today.Date
            Do
                cmd.Parameters("@dt").Value = dt
                cmd.CommandText = "select @cnt = count(*) from mm_calendar_dump where shop = 'meme' and date = @dt"
                cmd.ExecuteScalar()
                If cmd.Parameters("@cnt").Value > 0 Then
                    dt = dt.AddDays(1)
                    cmd.Parameters("@dt").Value = dt
                    If dt.Month = Now.Month Then Exit Do
                Else
                    dt = dt
                    cmd.Parameters("@dt").Value = dt
                    Exit Do
                End If
            Loop While dt.Month = Now.Month

            cmd.CommandText = "Select @cnt = count(*) from mm_final_inspection where inspection_date = @dt"
            cmd.ExecuteScalar()
            If cmd.Parameters("@cnt").Value > 0 Then
                dt = dt.AddDays(1)
                cmd.Parameters("@dt").Value = dt
                cmd.CommandText = "select @cnt = count(*) from mm_calendar_dump where shop = 'clcl' and date = @dt"
                While dt.Month = Now.Month
                    cmd.Parameters("@dt").Value = dt
                    cmd.ExecuteScalar()
                    If cmd.Parameters("@cnt").Value > 0 Then
                        dt = dt.AddDays(1)
                    Else
                        Exit While
                    End If
                End While
            End If
            Dim sCheckQty, InspShift As String
            sCheckQty = "Select @cnt = RequiredCount from mm_ContinueShift_Authorisation where InspDate = @InspDate and Shift = @Shift and ProdType = @ProdType"
            cmd.Parameters.Add("@InspDate", SqlDbType.SmallDateTime, 4).Value = dt
            cmd.Parameters.Add("@Shift", SqlDbType.VarChar, 1).Value = "A"
            cmd.Parameters.Add("@ProdType", SqlDbType.VarChar, 1).Value = "W"
            cmd.CommandText = sCheckQty
            If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
            cmd.ExecuteScalar()
            Dim QtyReqd As Integer = IIf(IsDBNull(cmd.Parameters("@cnt").Value), 0, cmd.Parameters("@cnt").Value)
            Dim InspDate As Date
            If dt >= Now.Date.Today.Date Then
                InspDate = dt.Date
            Else
                InspDate = dt.AddDays(1)
            End If
            InspShift = "A"
            Dim dt2 As New DataTable()
            Dim dr As DataRow
            dt2.TableName = "wheels"
            dt2.Columns.Add("InspDate")
            dt2.Columns.Add("InspShift")
            dt2.Columns.Add("QtyReqd")
            Try
                dr = dt2.NewRow
                dr("InspDate") = InspDate
                dr("InspShift") = InspShift
                dr("QtyReqd") = QtyReqd
                dt2.Rows.Add(dr)
                getNextLatestData = dt2
            Catch exp As Exception
                getNextLatestData = Nothing
            End Try
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
            sCheckQty = Nothing
            InspShift = Nothing
            QtyReqd = Nothing
            InspDate = Nothing
            dt = Nothing
            dt2 = Nothing
            dr = Nothing
        End Function
        Public Shared Function GetShiftedCount(ByVal inspDate As Date, ByVal Shift As String) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "Select top 1 convert(varchar(11),InspDate,103) WhlsFromDt, " & _
                " Shift WhlsFromShift, RequiredCount ReqdWhls, DoneCount ProcessedCount " & _
                " from mm_ContinueShift_Authorisation  where prodType = @Product " & _
                " and inspDate = @inspDate  and  Shift = @Shift "
            da.SelectCommand.Parameters.Add("@Product", SqlDbType.VarChar, 1).Value = "W"
            da.SelectCommand.Parameters.Add("@inspDate", SqlDbType.SmallDateTime, 4).Value = CDate(inspDate)
            da.SelectCommand.Parameters.Add("@Shift", SqlDbType.VarChar, 1).Value = Shift
            Try
                da.Fill(ds)
                GetShiftedCount = ds.Tables(0).Copy
            Catch exp As Exception
                GetShiftedCount = Nothing
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function GetLastShiftedCount() As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "Select top 1 convert(varchar(11),InspDate,103) WhlsFromDt, " & _
                " Shift WhlsFromShift, RequiredCount ReqdWhls, DoneCount ProcessedCount " & _
                " from mm_ContinueShift_Authorisation  where prodType = @Product " & _
                " order by inspDate desc ,  Shift desc "
            da.SelectCommand.Parameters.Add("@Product", SqlDbType.VarChar, 1).Value = "W"
            Try
                da.Fill(ds)
                GetLastShiftedCount = ds.Tables(0).Copy
            Catch exp As Exception
                GetLastShiftedCount = Nothing
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function getLatestData(Optional ByVal Product As String = "W") As DataTable
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.CommandText = "Select top 1 Phl_date from mm_phl_Generation order by phl_date desc"
            Dim dt As Date
            Try
                cmd.Connection.Open()
                cmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                cmd.Parameters.Add("@dt", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Input
                Dim NowDt As Date
                If Now.Hour < 6 Then
                    NowDt = Now.Date.AddDays(-1)
                Else
                    NowDt = Now.Date
                End If
                cmd.Parameters("@dt").Value = NowDt
                dt = IIf(IsDBNull(cmd.ExecuteScalar), CDate("1/1/1900"), cmd.ExecuteScalar)
                Do
                    cmd.Parameters("@dt").Value = dt
                    cmd.CommandText = "select @cnt = count(*) from mm_calendar_dump where shop = 'meme' and date = @dt"
                    cmd.ExecuteScalar()
                    If cmd.Parameters("@cnt").Value > 0 Then
                        dt = dt.AddDays(1)
                        cmd.Parameters("@dt").Value = dt
                        If dt.Month = Now.Month Then Exit Do
                    Else
                        dt = dt.AddDays(1)
                        Exit Do
                    End If
                Loop While dt.Month = Now.Month
                If Now.Hour < 8 Then
                Else
                    Do While dt < Now.Today.Date
                        dt = dt.AddDays(1)
                    Loop
                End If
                cmd.CommandText = "Select @cnt = count(*) from mm_final_inspection where inspection_date = @dt"
                cmd.ExecuteScalar()
                If cmd.Parameters("@cnt").Value > 0 Then
                    dt = dt.AddDays(1)
                    cmd.Parameters("@dt").Value = dt
                    cmd.CommandText = "select @cnt = count(*) from mm_calendar_dump where shop = 'clcl' and date = @dt"
                    While dt.Month = Now.Month
                        cmd.Parameters("@dt").Value = dt
                        cmd.ExecuteScalar()
                        If cmd.Parameters("@cnt").Value > 0 Then
                            dt = dt.AddDays(1)
                        Else
                            Exit While
                        End If
                    End While
                End If

                Dim dt1 As Date
                dt1 = Now.Date.Today
                Dim sCheckQty As String
                sCheckQty = "Select @cnt = RequiredCount from mm_ContinueShift_Authorisation where InspDate = @InspDate and Shift = @Shift and ProdType = @ProdType"
                cmd.Parameters.Add("@InspDate", SqlDbType.SmallDateTime, 4).Value = dt
                cmd.Parameters.Add("@Shift", SqlDbType.VarChar, 1).Value = "A"
                cmd.Parameters.Add("@ProdType", SqlDbType.VarChar, 1).Value = Product
                cmd.CommandText = sCheckQty
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.ExecuteScalar()
                Dim QtyReqd As Integer = IIf(IsDBNull(cmd.Parameters("@cnt").Value), 0, cmd.Parameters("@cnt").Value)
                Dim reasonable_Qty As Integer
                reasonable_Qty = 40
                Dim InspDate As Date
                If dt > NowDt Then
                    InspDate = dt.Date
                Else
                    InspDate = dt.AddDays(1)
                End If
                cmd.CommandText = "Select @cnt = count(*) from mm_final_Inspection where inspection_date = @InspDate and shift_code = 'A'"
                Dim Posted As Integer
                Try
                    cmd.ExecuteScalar()
                    Posted = IIf(IsDBNull(cmd.Parameters("@cnt").Value), 0, cmd.Parameters("@cnt").Value)
                Catch exp As Exception
                    InspDate = ""
                    Throw New Exception(exp.Message)
                End Try
                Dim dt2 As New DataTable()
                Dim dr As DataRow
                dt2.TableName = "wheels"
                dt2.Columns.Add("InspDate")
                dt2.Columns.Add("InspShift")
                dt2.Columns.Add("QtyReqd")
                Try
                    dr = dt2.NewRow
                    dr("InspDate") = InspDate
                    dr("InspShift") = "A"
                    dr("QtyReqd") = QtyReqd
                    dt2.Rows.Add(dr)
                Catch ex As Exception
                End Try
                getLatestData = dt2
                NowDt = Nothing
                dt1 = Nothing
                sCheckQty = Nothing
                QtyReqd = Nothing
                reasonable_Qty = Nothing
                Posted = Nothing
                dt2 = Nothing
                dr = Nothing
            Catch exp As Exception
                getLatestData = Nothing
                dt = CDate("1/1/1900")
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
            End Try
            If IsNothing(cmd) = False Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End If
            dt = Nothing
        End Function
        Public Shared Function GetShiftedCount() As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "Select InspDate WhlsFromDt, Shift WhlsFromShift, " & _
                " RequiredCount ReqdWhls, DoneCount ShiftedCount from mm_ContinueShift_Authorisation " & _
                " where inspDate = @today and prodType = @Product"
            da.SelectCommand.Parameters.Add("@Today", SqlDbType.SmallDateTime, 4).Value = Now.Today.Date
            da.SelectCommand.Parameters.Add("@Product", SqlDbType.VarChar, 1).Value = "W"
            Try
                da.Fill(ds)
                GetShiftedCount = ds.Tables(0).Copy
            Catch exp As Exception
                GetShiftedCount = Nothing
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function GetLastDate() As Date
            Dim oCmd As SqlClient.SqlCommand
            oCmd = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@LastDate", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = "Select top 1 @LastDate = As_on from mm_WheelShop_FloorBalance order by As_on desc "
                oCmd.ExecuteScalar()
                GetLastDate = IIf(IsDBNull(oCmd.Parameters("@LastDate").Value), CDate("1900-01-01"), oCmd.Parameters("@LastDate").Value)
            Catch exp As Exception
                GetLastDate = CDate("1900-01-01")
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function
        Public Shared Function GetWheelShopFloorBalance(ByVal dt As Date) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.Parameters.Add("@dt", SqlDbType.SmallDateTime, 4).Value = dt
                da.SelectCommand.CommandText = "mm_sp_WheelShop_FloorBalance"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.Fill(ds)
                GetWheelShopFloorBalance = ds.Tables(0)
            Catch exp As Exception
                GetWheelShopFloorBalance = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function

        Public Function Save(ByVal InputDate As Date, ByVal Shift As String, ByVal Operator1 As String, ByVal Dispatch As String, ByVal Wheels As String, ByVal CBForDate As Date, ByVal QTY As DataTable) As Boolean
            Dim sInsertTrans, sUpdateTrans, sUpdateMaster, sCheckTrans, sCheckMaster, sInsertMaster As String
            Dim dlastDate As Date
            Dim blnSaved As Boolean
            blnSaved = False
            Dim oCmd As SqlClient.SqlCommand
            oCmd = rwfGen.Connection.CmdObj
            sCheckMaster = "Select count(*) from mm_WheelShop_FloorBalance where Product_Code = @ProductCode and as_on = @CBForDate "

            sCheckTrans = "Select count(*) from mm_WheelShopFloorBalance_ReconciledCB where ProductCode = @ProductCode and CBForDate = @CBForDate "

            sUpdateTrans = "Update mm_WheelShopFloorBalance_ReconciledCB set CBQty= @CBQty, Dispatch = @dispatch, Wheels = @Wheels" &
            " where  ProductCode = @ProductCode and CBForDate = @CBForDate "

            sInsertTrans = "Insert into mm_WheelShopFloorBalance_ReconciledCB (InputDate, InputShift, Operator_code, ProductCode, CBForDate, CBQty, SavedDateTime, Dispatch, Wheels ) " &
                  " values (@InputDate, @InputShift, @Operator_code, @ProductCode, @CBForDate, @CBQty, @SavedDateTime, @dispatch, @Wheels)"

            sUpdateMaster = "Update mm_WheelShop_FloorBalance set Closing_Balance = @CBQty where product_code  = @ProductCode and as_on = @CBForDate "

            sInsertMaster = "Insert into mm_WheelShop_FloorBalance ( As_On , Product_Code , Opening_Balance , Closing_Balance ) values ( @CBForDate , @ProductCode , 0 , @CBQty ) "
            Dim i As Integer = 0
            Try
                oCmd.Parameters.Add("@InputDate", SqlDbType.SmallDateTime, 4).Value = CDate(InputDate)
                oCmd.Parameters.Add("@InputShift", SqlDbType.VarChar, 1).Value = Shift
                oCmd.Parameters.Add("@Operator_code", SqlDbType.VarChar, 6).Value = Operator1
                oCmd.Parameters.Add("@CBForDate", SqlDbType.SmallDateTime, 4).Value = CDate(CBForDate)
                oCmd.Parameters.Add("@SavedDateTime", SqlDbType.DateTime, 8).Value = Now

                oCmd.Parameters.Add("@Dispatch", SqlDbType.VarChar, 6).Value = Dispatch
                oCmd.Parameters.Add("@Wheels", SqlDbType.VarChar, 6).Value = Wheels
                oCmd.Parameters.Add("@CBQty", SqlDbType.Int, 4).Direction = ParameterDirection.Input
                oCmd.Parameters.Add("@ProductCode", SqlDbType.VarChar, 50).Direction = ParameterDirection.Input
                For i = 0 To QTY.Rows.Count - 1
                    blnSaved = False
                    oCmd.Connection.Open()
                    oCmd.Transaction = oCmd.Connection.BeginTransaction
                    oCmd.Parameters("@CBQty").Value = Val(QTY.Rows(i)(0))
                    oCmd.Parameters("@ProductCode").Value = QTY.Rows(i)(1)
                    oCmd.CommandText = sCheckTrans
                    If oCmd.ExecuteScalar() > 0 Then
                        oCmd.CommandText = sUpdateTrans
                    Else
                        oCmd.CommandText = sInsertTrans
                    End If
                    oCmd.ExecuteNonQuery()
                    oCmd.CommandText = sCheckMaster
                    If oCmd.ExecuteScalar() > 0 Then
                        oCmd.CommandText = sUpdateMaster
                    Else
                        oCmd.CommandText = sInsertMaster
                    End If
                    If oCmd.ExecuteNonQuery() = 1 Then
                        Save = True
                        oCmd.Transaction.Commit()
                    Else
                        oCmd.Transaction.Rollback()
                    End If
                    oCmd.Connection.Close()
                Next
            Catch exp As Exception
                Throw New Exception(exp.Message)
            End Try
            If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
            oCmd.Dispose()
            oCmd = Nothing
            sInsertTrans = Nothing
            sUpdateTrans = Nothing
            sUpdateMaster = Nothing
            sCheckTrans = Nothing
            sCheckMaster = Nothing
            sInsertMaster = Nothing
            dlastDate = Nothing
            blnSaved = Nothing
            i = Nothing
        End Function

        Public Function ContinueShift(ByVal InspDate As Date, ByVal InspShift As String, ByVal EmpCode As String, ByVal QtyReqd As Integer) As String
            Dim sChecFiPosting, sInsertQty, sUpdateQty, sCheckQty, Message As String
            sCheckQty = "Select @cnt = count(*) from mm_ContinueShift_Authorisation where InspDate = @InspDate and Shift = @Shift and ProdType = @ProdType"
            sInsertQty = "insert into mm_ContinueShift_Authorisation ( EmpCode, InspDate, Shift, ProdType, RequiredCount, DateTimeAuthorised ) values ( @EmpCode, @InspDate, @Shift, @ProdType, @RequiredCount, @DateTimeAuthorised )"
            sUpdateQty = "Update mm_ContinueShift_Authorisation set RequiredCount = @RequiredCount where InspDate = @InspDate and Shift = @Shift and ProdType = @ProdType"
            sChecFiPosting = "Select @cnt = count(*) from mm_final_inspection where inspection_date = @InspDate"
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim blnDone As Boolean
            Try
                cmd.Parameters.Add("@InspDate", SqlDbType.SmallDateTime, 4).Value = CDate(InspDate)
                cmd.Parameters.Add("@Shift", SqlDbType.VarChar, 1).Value = InspShift
                cmd.Parameters.Add("@ProdType", SqlDbType.VarChar, 1).Value = "W"
                cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 6).Value = EmpCode
                cmd.Parameters.Add("@RequiredCount", SqlDbType.Int, 4).Value = Val(QtyReqd)
                cmd.Parameters.Add("@DateTimeAuthorised", SqlDbType.DateTime, 8).Value = Now
                cmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                blnDone = True
            Catch exp As Exception
                Message = exp.Message
            End Try
            If blnDone = False Then
                If IsNothing(cmd) = False Then
                    cmd.Dispose()
                    Exit Function
                Else
                    blnDone = False
                End If
            Else
                blnDone = False
            End If
            Dim blnUpdated As Boolean
            Try
                cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                cmd.CommandText = sChecFiPosting
                cmd.ExecuteScalar()
                If cmd.Parameters("@cnt").Value = 0 Then
                    cmd.CommandText = sCheckQty
                    cmd.ExecuteScalar()
                    If cmd.Parameters("@cnt").Value > 0 Then
                        cmd.CommandText = sUpdateQty
                        blnUpdated = True
                    Else
                        cmd.CommandText = sInsertQty
                        blnUpdated = False
                    End If
                    If cmd.ExecuteNonQuery > 0 Then blnDone = True
                Else
                    Message = "Final Inspection has posted Records"
                End If
            Catch exp As Exception
                If blnUpdated Then
                    Message = "Update Failed : " '& exp.Message
                Else
                    Message = "Insert Failed : " '& exp.Message
                End If
            Finally
                If IsNothing(cmd) = False Then
                    If blnDone Then
                        cmd.Transaction.Commit()
                        If blnUpdated Then
                            Message = "Updated"
                        Else
                            Message = "Inserted"
                        End If
                    Else
                        cmd.Transaction.Rollback()
                    End If
                End If
            End Try
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
            sChecFiPosting = Nothing
            sInsertQty = Nothing
            sUpdateQty = Nothing
            sCheckQty = Nothing
            blnDone = Nothing
            Return Message
        End Function
        Public Function DeleteContinueShift(ByVal InspDate As Date, ByVal Shift As String, ByVal RequiredCount As Integer, ByVal DoneCount As Integer) As String
            Dim Done As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                oCmd.Parameters.Add("@InspDate", SqlDbType.SmallDateTime, 4).Value = CDate(InspDate)
                oCmd.Parameters.Add("@Shift", SqlDbType.VarChar, 1).Value = Shift
                oCmd.Parameters.Add("@RequiredCount", SqlDbType.Int, 4).Value = RequiredCount
                oCmd.Parameters.Add("@DoneCount", SqlDbType.Int, 4).Value = DoneCount
                oCmd.CommandText = " delete from mm_ContinueShift_Authorisation  where InspDate = @InspDate and Shift = @Shift and RequiredCount = @RequiredCount and DoneCount = @DoneCount "
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                If oCmd.ExecuteNonQuery = 1 Then Done = True
            Catch exp As Exception
                Done = False
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
        Public Function UpdateContinueShift(ByVal InspDate As Date, ByVal InspShift As String, ByVal EmpCode As String, ByVal QtyReqd As Integer) As Boolean
            Dim blnDone As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Parameters.Add("@InspDate", SqlDbType.SmallDateTime, 4).Value = CDate(InspDate)
                cmd.Parameters.Add("@Shift", SqlDbType.VarChar, 1).Value = InspShift
                cmd.Parameters.Add("@ProdType", SqlDbType.VarChar, 1).Value = "W"
                cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 6).Value = EmpCode
                cmd.Parameters.Add("@RequiredCount", SqlDbType.Int, 4).Value = QtyReqd
                blnDone = True
            Catch exp As Exception
                Throw New Exception(exp.Message)
            End Try
            If blnDone = False Then
                If IsNothing(cmd) = False Then
                    cmd.Dispose()
                    Exit Function
                Else
                    blnDone = False
                End If
            Else
                blnDone = False
            End If
            Dim blnUpdated As Boolean
            Try
                cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                cmd.CommandText = "Update mm_ContinueShift_Authorisation set RequiredCount = @RequiredCount " & _
                    " where InspDate = @InspDate and Shift = @Shift and ProdType = @ProdType"
                If cmd.ExecuteNonQuery > 0 Then
                    blnUpdated = True
                    blnDone = True
                End If
            Catch exp As Exception
                blnUpdated = False
                Throw New Exception(exp.Message)
            Finally
                If IsNothing(cmd) = False Then
                    If blnDone Then
                        cmd.Transaction.Commit()
                    Else
                        cmd.Transaction.Rollback()
                    End If
                End If
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
            Return blnUpdated
        End Function
        Public Function SaveDS8NoForRMWheels(ByVal dgSavedData As DataTable) As Boolean
            Dim Done As Boolean = False
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@UserGroup", SqlDbType.VarChar, 6)
            cmd.Parameters.Add("@AdviceNoteNo", SqlDbType.VarChar, 6)
            cmd.Parameters.Add("@AdviceNoteDate", SqlDbType.SmallDateTime, 4)
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 6)
            cmd.Parameters.Add("@DS8Id", SqlDbType.BigInt, 8)
            Dim i As Integer
            Try
                For i = 0 To dgSavedData.Rows.Count - 1
                    Try
                        cmd.Parameters("@UserGroup").Value = dgSavedData.Rows(i)("UserGroup")
                        cmd.Parameters("@AdviceNoteNo").Value = dgSavedData.Rows(i)("AdviceNoteNo")
                        cmd.Parameters("@AdviceNoteDate").Value = dgSavedData.Rows(i)("AdviceNoteDate")
                        cmd.Parameters("@Remarks").Value = dgSavedData.Rows(i)("UserGroup")
                        cmd.Parameters("@DS8Id").Value = dgSavedData.Rows(i)("Remarks")
                        cmd.CommandText = "update mm_ReturnedStoresDetails " & _
                            " set AdviceNoteNo = @AdviceNoteNo , AdviceNoteDate = @AdviceNoteDate ," & _
                            " Remarks = @Remarks where DS8Id = @DS8Id "
                        If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                        If cmd.ExecuteNonQuery() Then Done = True
                    Catch exp As Exception
                        Done = False
                        Throw New Exception(exp.Message)
                    End Try
                    If Done = False Then Exit For
                Next
            Catch exp As Exception
                Done = False
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
            i = Nothing
            Return Done
        End Function
        Public Function RMWheelsAtQCI(ByVal Wheel As Long, ByVal Heat As Long, ByVal InspDate As Date, ByVal Shift As String, ByVal Lab As String, ByVal Technical As String, ByVal Inspector As String) As Boolean
            Dim ocmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            ocmd.Parameters.Add("@Wheel", SqlDbType.BigInt, 8).Value = Wheel
            ocmd.Parameters.Add("@Heat", SqlDbType.BigInt, 8).Value = Heat
            ocmd.Parameters.Add("@InspDate", SqlDbType.SmallDateTime, 4).Value = CDate(InspDate)
            ocmd.Parameters.Add("@Shift", SqlDbType.VarChar, 1).Value = Shift
            ocmd.Parameters.Add("@Lab", SqlDbType.VarChar, 6).Value = Lab
            ocmd.Parameters.Add("@Technical", SqlDbType.VarChar, 6).Value = Technical
            ocmd.Parameters.Add("@Inspector", SqlDbType.VarChar, 6).Value = Inspector
            ocmd.Parameters.Add("@PreStatus", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            ocmd.Parameters.Add("@PreLoc", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            ocmd.Parameters.Add("@PCode", SqlDbType.VarChar, 6).Direction = ParameterDirection.Output
            ocmd.Parameters.Add("@WhlType", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            Dim blnDone As Boolean
            Try
                ocmd.Connection.Open()
                ocmd.Transaction = ocmd.Connection.BeginTransaction
                ocmd.CommandText = " select @PreStatus = rtrim(status) , @PreLoc = rtrim(location) , @PCode = b.product_code ,  " & _
                    " @WhlType = ltrim(rtrim(b.description)) from mm_wheel a inner join mm_product_master b" & _
                    " on ltrim(rtrim(a.description)) = ltrim(rtrim(b.description)) " & _
                    " where wheel_number = @Wheel And heat_number = @Heat "
                ocmd.ExecuteScalar()
                ocmd.Parameters("@PreStatus").Direction = ParameterDirection.Input
                ocmd.Parameters("@PreLoc").Direction = ParameterDirection.Input
                ocmd.Parameters("@PCode").Direction = ParameterDirection.Input
                ocmd.Parameters("@WhlType").Direction = ParameterDirection.Input
                ocmd.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = "RM-" & ocmd.Parameters("@PreStatus").Value

                blnDone = False
                Try
                    ocmd.CommandText = " insert into mm_qci_inspection ( inspection_date , shift_code , " & _
                        " lab_authority , technical_authority , inspection_authority , wheel_number , " & _
                        " heat_number , pre_status , pre_location , tread_diameter , product_code , " & _
                        " wheel_disposition , remarks_qci ) " & _
                        " values ( @InspDate , @Shift , @Lab , @Technical , @Inspector ,  @Wheel , @Heat , " & _
                        " @PreStatus , @PreLoc , 0 , @WhlType , 'RM' , 'WheelForReMelt' ) "
                    If ocmd.ExecuteNonQuery = 1 Then
                        ocmd.CommandText = " update mm_wheel set status = @Status , location = 'CLFQ' " & _
                        " where wheel_number = @Wheel And heat_number = @Heat "
                        If ocmd.ExecuteNonQuery() = 1 Then
                            ocmd.CommandText = " insert into mm_wheel_RMWheels ( wheel_number , heat_number , status , location , RMDate )" & _
                                " values (@Wheel , @Heat , @PreStatus , @PreLoc , @InspDate ) "
                            If ocmd.ExecuteNonQuery() = 1 Then
                                blnDone = True
                            End If
                        End If
                    End If
                Catch exp As Exception
                    blnDone = False
                    Throw New Exception(exp.Message)
                End Try
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If IsNothing(ocmd) = False Then
                    If blnDone Then
                        ocmd.Transaction.Commit()
                    Else
                        ocmd.Transaction.Rollback()
                    End If
                    If ocmd.Connection.State = ConnectionState.Open Then ocmd.Connection.Close()
                    ocmd.Dispose()
                    ocmd = Nothing
                End If
            End Try
            Return blnDone
        End Function
        Public Function WFPSOffLoads(ByVal Wheel As Long, ByVal Heat As Long, ByVal OffLoadDate As Date, ByVal Shift As String, ByVal Remarks As String, ByVal Point As String, ByVal Bore As String) As Boolean
            Dim ocmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            ocmd.Parameters.Add("@Wheel", SqlDbType.BigInt, 8).Value = Wheel
            ocmd.Parameters.Add("@Heat", SqlDbType.BigInt, 8).Value = Heat
            ocmd.Parameters.Add("@OffLoadDate", SqlDbType.SmallDateTime, 4).Value = CDate(OffLoadDate)
            ocmd.Parameters.Add("@Shift", SqlDbType.VarChar, 1).Value = Shift
            ocmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 50).Value = Remarks
            ocmd.Parameters.Add("@Point", SqlDbType.VarChar, 10).Value = Point
            ocmd.Parameters.Add("@Bore", SqlDbType.VarChar, 10).Value = Bore
            ocmd.Parameters.Add("@Status", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            ocmd.Parameters.Add("@Location", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            Dim blnDone As Boolean
            Try
                ocmd.Connection.Open()
                ocmd.Transaction = ocmd.Connection.BeginTransaction
                ocmd.CommandText = " select @Status = rtrim(status) , @Location = rtrim(location) " & _
                    " from mm_wheel where wheel_number = @Wheel And heat_number = @Heat "
                ocmd.ExecuteScalar()
                ocmd.Parameters("@Status").Direction = ParameterDirection.Input
                ocmd.Parameters("@Location").Direction = ParameterDirection.Input

                ocmd.Parameters.Add("@GrindSts", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                ocmd.Parameters.Add("@MCNSts", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                ocmd.Parameters("@GrindSts").Value = ""
                ocmd.Parameters("@MCNSts").Value = ""
                If Trim(ocmd.Parameters("@Location").Value) = "CLMT" Then
                    If Trim(ocmd.Parameters("@Status").Value) = "REWORK" Then
                        ocmd.CommandText = " select TOP 1 @GrindSts = rtrim(grind_status) , @MCNSts = rtrim(mcn_operation) " & _
                            " from mm_magnaglow_results where wheel_number = @Wheel And heat_number = @Heat " & _
                            " and wheel_status = 'rework' order by sl_no desc"
                        ocmd.ExecuteScalar()
                    End If
                End If
                ocmd.Parameters("@GrindSts").Direction = ParameterDirection.Input
                ocmd.Parameters("@MCNSts").Direction = ParameterDirection.Input

                ocmd.CommandText = " insert into mm_WFPSOffLoads ( OffLoadDate , Shift , Wheel , Heat , status , location , GrindSts , MCNSts , Remarks  , Point , Bore , SaveDateTime )" & _
                    " values ( @OffLoadDate , @Shift , @Wheel , @Heat , @status , @location , @GrindSts , @MCNSts , @Remarks , @Point ,  @Bore , getdate() ) "
                If ocmd.ExecuteNonQuery() = 1 Then blnDone = True
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If IsNothing(ocmd) = False Then
                    If blnDone Then
                        ocmd.Transaction.Commit()
                    Else
                        ocmd.Transaction.Rollback()
                    End If
                    If ocmd.Connection.State = ConnectionState.Open Then ocmd.Connection.Close()
                    ocmd.Dispose()
                    ocmd = Nothing
                End If
            End Try
            Return blnDone
        End Function
        Public Function DeleteWFPSOffLoads(ByVal sl As Integer) As Boolean
            Dim ocmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            ocmd.Parameters.Add("@sl", SqlDbType.BigInt, 8).Value = sl
            Dim blnDone As Boolean
            Try
                ocmd.Connection.Open()
                ocmd.Transaction = ocmd.Connection.BeginTransaction
                ocmd.CommandText = "delete mm_WFPSOffLoads where sl = @sl"
                If ocmd.ExecuteNonQuery() = 1 Then blnDone = True
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If IsNothing(ocmd) = False Then
                    If blnDone Then
                        ocmd.Transaction.Commit()
                    Else
                        ocmd.Transaction.Rollback()
                    End If
                    If ocmd.Connection.State = ConnectionState.Open Then ocmd.Connection.Close()
                    ocmd.Dispose()
                    ocmd = Nothing
                End If
            End Try
            Return blnDone
        End Function
    End Class
    Public Class RMWheels
        Private sMessage As String
        Private blnNotPostedWheel As Boolean
        Property NotPostedWheel() As Boolean
            Get
                Return blnNotPostedWheel
            End Get
            Set(ByVal Value As Boolean)
                blnNotPostedWheel = Value
            End Set
        End Property
        ReadOnly Property Message() As String
            Get
                Return sMessage
            End Get
        End Property
        Public Sub New(ByVal Wheel As Long, ByVal Heat As Long)
            Try
                sMessage = checkRMWheel(Wheel, Heat)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            End Try
        End Sub
        Private Function checkRMWheel(ByVal Wheel As Long, ByVal Heat As Long) As String
            checkRMWheel = ""
            Dim dt, dt1 As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = " select rtrim(status) status , rtrim(location) location , " & _
                " rtrim(description) description from mm_wheel " & _
                " where wheel_number = '" & CInt(Wheel) & "' and heat_number = '" & CInt(Heat) & "'"
            da.SelectCommand.Parameters.Add("@Today", SqlDbType.SmallDateTime, 4).Value = Now.Today.Date
            da.SelectCommand.Parameters.Add("@Product", SqlDbType.VarChar, 1).Value = "W"
            Try
                da.Fill(ds)
                dt = ds.Tables(0).Copy
            Catch exp As Exception
                dt = Nothing
                Throw New Exception(exp.Message)
            End Try
            If dt.Rows.Count = 0 Then
                checkRMWheel = "Message :Wheel Not found in Master"
                Exit Function
            Else
                Dim status As String = Trim(dt.Rows(0)("status"))
                Dim location As String = Trim(dt.Rows(0)("location"))
                If location = "MOPO" Then
                    Try
                        dt1 = NotPostedData(CInt(Wheel), CInt(Heat))
                    Catch exp As Exception
                        dt1 = Nothing
                    End Try
                    If dt1.Rows.Count = 0 Then
                        checkRMWheel = "Message : This wheel is not a Rejected having the status " & Trim(dt.Rows(0)("status")) & " Location:" & Trim(dt.Rows(0)("location"))
                        Exit Function
                    Else
                        blnNotPostedWheel = True
                        checkRMWheel = " Wheel Status : " & Trim(dt1.Rows(0)("status")) & " Location : " & Trim(dt1.Rows(0)("location")) & " WhlType : " & Trim(dt1.Rows(0)("description"))
                        Exit Function
                    End If
                End If
                If location = "CLMT" Then
                    If Left(status.ToUpper, 2) = "XC" Then
                        If Left(status, 3).ToUpper = "XC8" Then
                            checkRMWheel = "Message : This wheel is not a Rejected ; having the status " & Trim(dt.Rows(0)("status")) & " Location:" & Trim(dt.Rows(0)("location"))
                            Exit Function
                        End If
                    Else
                        Try
                            dt1 = NotPostedData(CInt(Wheel), CInt(Heat))
                        Catch exp As Exception
                            dt1 = Nothing
                        End Try
                        If dt1.Rows.Count = 0 Then
                            checkRMWheel = "Message : This wheel is not a Rejected having the status " & Trim(dt.Rows(0)("status")) & " Location:" & Trim(dt.Rows(0)("location"))
                            Exit Function
                        Else
                            blnNotPostedWheel = True
                            checkRMWheel = " Wheel Status : " & Trim(dt1.Rows(0)("status")) & " Location : " & Trim(dt1.Rows(0)("location")) & " WhlType : " & Trim(dt1.Rows(0)("description"))
                            Exit Function
                        End If
                    End If
                End If
                If location = "CLFI" Then
                    If Left(Trim(dt.Rows(0)("status")).ToUpper, 1) <> "R" Then
                        checkRMWheel = "Message : This wheel is having the last status:" & Trim(dt.Rows(0)("status")) & " Location:" & Trim(dt.Rows(0)("location"))
                        Exit Function
                    End If
                End If
                If location = "CLQC" Then
                    If (Left(Trim(dt.Rows(0)("status")).ToUpper, 1)) <> "XC" OrElse (Left(Trim(dt.Rows(0)("status")).ToUpper, 2)) <> "RL" Then
                        checkRMWheel = "Message : This wheel is having the last status:" & Trim(dt.Rows(0)("status")) & " Location:" & Trim(dt.Rows(0)("location"))
                        Exit Function
                    End If
                End If
                If location = "CLFQ" Then
                    If Left(Trim(dt.Rows(0)("status")).ToUpper, 1) = "W" Then
                        checkRMWheel = "Message : This wheel is having the last status:" & Trim(dt.Rows(0)("status")) & " Location:" & Trim(dt.Rows(0)("location"))
                        Exit Function
                    End If
                End If
                If Trim(dt.Rows(0)("location")) <> "MOPO" And Trim(dt.Rows(0)("location")) <> "CLMT" And Trim(dt.Rows(0)("location")) <> "CLFI" And Trim(dt.Rows(0)("location")) <> "CLQC" And Trim(dt.Rows(0)("location")) <> "CLFQ" Then
                    checkRMWheel = "Message : This wheel is having the status " & Trim(dt.Rows(0)("status")) & " Location:" & Trim(dt.Rows(0)("location"))
                    Exit Function
                End If
                If AlreadyRMWheels(Wheel, Heat) Then
                    checkRMWheel = "Message : This wheel is already made RM ! "
                    Exit Function
                End If
                If Not checkRMWheel.StartsWith("Message") Then
                    checkRMWheel = " Wheel Status : " & Trim(dt.Rows(0)("status")) & " Location : " & Trim(dt.Rows(0)("location")) & " WhlType : " & Trim(dt.Rows(0)("description"))
                End If
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
                dt = Nothing
                dt1 = Nothing
                status = Nothing
                location = Nothing
            End If
        End Function
        Private Function NotPostedData(ByVal Wheel As Long, ByVal Heat As Long) As DataTable
            Dim ds1 As New DataSet()
            Dim da1 As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da1.SelectCommand.CommandText = " select a.Status , rtrim(location) location , rtrim(description) description" & _
                " from mm_WheelsNotPostedAtMagna a inner join mm_wheel b" & _
                " on a.Whl = b.wheel_number and Heat = heat_number " & _
                " where b.wheel_number = '" & CInt(Wheel) & "' and b.heat_number = '" & CInt(Heat) & "'"
            Try
                da1.Fill(ds1)
                Return ds1.Tables(0).Copy
            Catch exp As Exception
                Return Nothing
            Finally
                ds1.Dispose()
                da1.Dispose()
                da1 = Nothing
                ds1 = Nothing
            End Try
        End Function
        Public Shared Function AlreadyRMWheels(ByVal Wheel As Long, ByVal Heat As Long) As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@AlreadyRMWheels", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = "Select @AlreadyRMWheels = count(*) from mm_wheel_RMWheels " & _
                    " where wheel_number = '" & CLng(Wheel) & "' and heat_number = '" & CLng(Heat) & "'"
                oCmd.ExecuteScalar()
                AlreadyRMWheels = IIf(IsDBNull(oCmd.Parameters("@AlreadyRMWheels").Value), 0, oCmd.Parameters("@AlreadyRMWheels").Value)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function
        Public Function RMWheelsAdd(ByVal UserId As String, ByVal WheelNo As String, ByVal Wheel As Long, ByVal Heat As Long, ByVal UserGroup As String, ByVal LoadedIn As String, ByVal Remarks As String, ByVal LoadedDate As Date, ByVal LoadType As Integer, ByVal NotPostedWheel As Boolean) As Boolean
            Dim ocmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            ocmd.Parameters.Add("@UserId", SqlDbType.VarChar, 10).Value = UserId
            ocmd.Parameters.Add("@UserGroup", SqlDbType.VarChar, 10).Value = UserGroup
            ocmd.Parameters.Add("@AdviceNoteNo", SqlDbType.VarChar, 50).Value = Left(Now.Date.ToString, 10)
            ocmd.Parameters.Add("@AdviceNoteDate", SqlDbType.SmallDateTime, 4).Value = CDate(LoadedDate)
            ocmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 50).Value = "Dummy"
            ocmd.Parameters.Add("@Item", SqlDbType.VarChar, 50).Value = WheelNo.Trim
            ocmd.Parameters.Add("@Wheel", SqlDbType.BigInt, 8).Value = Wheel
            ocmd.Parameters.Add("@Heat", SqlDbType.BigInt, 8).Value = Heat
            ocmd.Parameters.Add("@WheelNo", SqlDbType.VarChar, 50).Value = WheelNo
            ocmd.Parameters.Add("@LoadedIn", SqlDbType.VarChar, 50).Value = LoadedIn
            ocmd.Parameters.Add("@LoadType", SqlDbType.Int, 4).Value = LoadType
            ocmd.Parameters.Add("@LoadedDate", SqlDbType.SmallDateTime, 4).Value = CDate(LoadedDate)
            ocmd.Parameters.Add("@DS8Id", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
            ocmd.Parameters.Add("@ItemId", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
            ocmd.Parameters.Add("@PreStatus", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            ocmd.Parameters.Add("@PreLoc", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            ocmd.Parameters.Add("@PCode", SqlDbType.VarChar, 6).Direction = ParameterDirection.Output
            ocmd.Parameters.Add("@WhlType", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            ocmd.Parameters.Add("@SlNo", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
            Dim blnDone As Boolean
            Try
                If NotPostedData(CInt(Wheel), CInt(Heat)).Rows.Count > 0 Then blnNotPostedWheel = True
                ocmd.Connection.Open()
                ocmd.Transaction = ocmd.Connection.BeginTransaction
                ocmd.CommandText = " select @PreStatus = rtrim(status) , @PreLoc = rtrim(location) , @PCode = b.product_code ,  " & _
                    " @WhlType = ltrim(rtrim(b.description)) from mm_wheel a inner join mm_product_master b" & _
                    " on ltrim(rtrim(a.description)) = ltrim(rtrim(b.description)) " & _
                    " where wheel_number = @Wheel And heat_number = @Heat "
                ocmd.ExecuteScalar()
                If IsDBNull(ocmd.Parameters("@PreStatus").Value) OrElse IsDBNull(ocmd.Parameters("@PreLoc").Value) Then
                    Throw New Exception("InValid Data !")
                End If
                ocmd.Parameters("@PreStatus").Direction = ParameterDirection.Input
                ocmd.Parameters("@PreLoc").Direction = ParameterDirection.Input
                ocmd.Parameters("@PCode").Direction = ParameterDirection.Input
                ocmd.Parameters("@WhlType").Direction = ParameterDirection.Input
                ocmd.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = "RM-" & ocmd.Parameters("@PreStatus").Value

                ocmd.CommandText = " select @DS8Id = DS8Id from mm_ReturnedStoresDetails where AdviceNoteNo = @AdviceNoteNo and UserGroup = @UserGroup "
                ocmd.ExecuteScalar()
                If IIf(IsDBNull(ocmd.Parameters("@DS8Id").Value), 0, ocmd.Parameters("@DS8Id").Value) > 0 Then
                    ocmd.Parameters("@DS8Id").Direction = ParameterDirection.Input
                    ocmd.CommandText = " update mm_ReturnedStoresDetails set AdviceNoteDate = @AdviceNoteDate , Remarks = @Remarks" & _
                        " where UserGroup = @UserGroup and AdviceNoteNo = @AdviceNoteNo and DS8Id = @DS8Id "
                    If ocmd.ExecuteNonQuery > 0 Then
                        blnDone = True
                    End If
                Else
                    ocmd.CommandText = " insert into mm_ReturnedStoresDetails ( UserGroup , AdviceNoteNo ,  Remarks )" & _
                        " values ( @UserGroup , @AdviceNoteNo , @Remarks ) "
                    If ocmd.ExecuteNonQuery > 0 Then
                        ocmd.CommandText = " select @DS8Id = DS8Id from mm_ReturnedStoresDetails where AdviceNoteNo = @AdviceNoteNo and UserGroup = @UserGroup "
                        ocmd.ExecuteScalar()
                        ocmd.Parameters("@DS8Id").Direction = ParameterDirection.Input
                        blnDone = True
                    End If
                End If
                If blnDone Then
                    blnDone = False
                    ocmd.CommandText = " select @ItemId = ItemId from mm_ReturnedStoresList where Item = @Item "
                    ocmd.ExecuteScalar()
                    If IIf(IsDBNull(ocmd.Parameters("@ItemId").Value), 0, ocmd.Parameters("@ItemId").Value) = 0 Then
                        ocmd.CommandText = " insert into mm_ReturnedStoresList ( DS8Id , Item , ProductCode , LoadedIn , LoadedDate , LoadType ) " & _
                            " values ( @DS8Id , @Item , @PCode , @LoadedIn , @LoadedDate , @LoadType ) "
                        If ocmd.ExecuteNonQuery > 0 Then
                            blnDone = True
                        End If
                    Else
                        blnDone = True
                    End If
                End If
                If blnDone Then
                    blnDone = False
                    Try
                        If NotPostedWheel Then
                            'ocmd.CommandText = " update mm_wheel set magnaglow_status = 'WheelForRM' " & _
                            '" where wheel_number = @Wheel And heat_number = @Heat "
                            'If ocmd.ExecuteNonQuery = 1 Then
                            '    If ocmd.Parameters("@PreLoc").Value = "CLMT" Then
                            '        ocmd.CommandText = " select top 1 @SlNo =  sl_no from mm_magnaglow_results " & _
                            '         " where wheel_number = @Wheel And heat_number = @Heat order by sl_no desc"
                            '        ocmd.ExecuteScalar()
                            '        ocmd.Parameters("@SlNo").Direction = ParameterDirection.Input
                            '        ocmd.CommandText = "update mm_magnaglow_results set mag_status = 'RM' , " & _
                            '            " remarks = 'WheelForRM' where sl_no = @SlNo "
                            '        If ocmd.ExecuteNonQuery = 1 Then
                            '            ocmd.Parameters("@SlNo").Direction = ParameterDirection.Output
                            '            ocmd.CommandText = " select top 1 @SlNo =  sl_no from mm_magnaglow_shiftwiserecords " & _
                            '                   " where wheelnumber = @Wheel And heatnumber = @Heat order by sl_no desc"
                            '            ocmd.ExecuteScalar()
                            '            ocmd.Parameters("@SlNo").Direction = ParameterDirection.Input
                            '            ocmd.CommandText = "update mm_magnaglow_shiftwiserecords set Remarks = 'WheelForRM' where sl_no = @SlNo "
                            '            If ocmd.ExecuteNonQuery() = 1 Then
                            '                blnDone = True
                            '            End If
                            '        End If
                            '    Else
                            '        blnDone = True
                            '    End If
                            '    If blnDone = True Then
                            '        blnDone = False
                            '    Else
                            '        Exit Try
                            '    End If
                            '    ocmd.CommandText = " select @PreStatus = rtrim(a.Status) , @PreLoc = rtrim(location) " & _
                            '                    " from mm_WheelsNotPostedAtMagna a inner join mm_wheel b " & _
                            '                    " on a.Whl = b.wheel_number and Heat = b.heat_number " & _
                            '                    " where b.wheel_number = @Wheel And b.heat_number = @Heat "
                            '    ocmd.ExecuteScalar()
                            '    ocmd.CommandText = " insert into mm_wheel_RMWheels ( wheel_number , heat_number , status , location , RMDate )" & _
                            '                 " values (@Wheel , @Heat , @PreStatus , @PreLoc , @AdviceNoteDate ) "
                            '    If ocmd.ExecuteNonQuery() = 1 Then blnDone = True
                            'End If
                        Else
                            ocmd.CommandText = " insert into mm_qci_inspection ( inspection_date , shift_code , " & _
                                " lab_authority , technical_authority , inspection_authority , wheel_number , " & _
                                " heat_number , pre_status , pre_location , tread_diameter , product_code , " & _
                                " wheel_disposition , remarks_qci ) " & _
                                " values ( @AdviceNoteDate , 'G' , @UserId , @UserId , @UserId ,  @Wheel , @Heat , " & _
                                " @PreStatus , @PreLoc , 0 , @WhlType , 'RM' , 'WheelForReMelt' ) "
                            If ocmd.ExecuteNonQuery = 1 Then
                                ocmd.CommandText = " insert into mm_wheel_RMWheels ( wheel_number , heat_number , status , location , RMDate )" & _
                                    " values (@Wheel , @Heat , @PreStatus , @PreLoc , @AdviceNoteDate ) "
                                If ocmd.ExecuteNonQuery() = 1 Then blnDone = True
                            End If
                        End If
                    Catch exp As Exception
                        blnDone = False
                        Throw New Exception(exp.Message)
                    End Try
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If IsNothing(ocmd) = False Then
                    If blnDone Then
                        ocmd.Transaction.Commit()
                    Else
                        ocmd.Transaction.Rollback()
                    End If
                    If ocmd.Connection.State = ConnectionState.Open Then ocmd.Connection.Close()
                    ocmd.Dispose()
                    ocmd = Nothing
                End If
            End Try
            Return blnDone
        End Function
    End Class
End Namespace
