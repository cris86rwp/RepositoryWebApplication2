Public Class SSINSP
    Public Shared Function MountStatusCheckBeforeInsp(ByVal Axle As String) As String
        Dim Cmd As System.Data.SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Cmd.Parameters.Add("@Ax", SqlDbType.VarChar, 50).Value = Axle.Trim.ToUpper
        Cmd.Parameters.Add("@done", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandText = "mm_sp_UpdateMountStatusCheckBeforeInsp"
        Try
            If Cmd.Connection.State = ConnectionState.Closed Then Cmd.Connection.Open()
            Cmd.ExecuteScalar()
            MountStatusCheckBeforeInsp = IIf(IsDBNull(Cmd.Parameters("@done").Value), "", Cmd.Parameters("@done").Value)
        Catch exp As Exception
            MountStatusCheckBeforeInsp = ""
            Throw New Exception(exp.Message)
        Finally
            If Cmd.Connection.State = ConnectionState.Open Then Cmd.Connection.Close()
            Cmd.Dispose()
            Cmd = Nothing
        End Try
    End Function
    Public Shared Function MountStatusCheck(ByVal Axle As String) As String
        Dim Cmd As System.Data.SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Cmd.Parameters.Add("@Ax", SqlDbType.VarChar, 50).Value = Axle.Trim.ToUpper
        Cmd.Parameters.Add("@done", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandText = "mm_sp_UpdateMountStatusCheck"
        Try
            If Cmd.Connection.State = ConnectionState.Closed Then Cmd.Connection.Open()
            Cmd.ExecuteScalar()
            MountStatusCheck = IIf(IsDBNull(Cmd.Parameters("@done").Value), "", Cmd.Parameters("@done").Value)
        Catch exp As Exception
            MountStatusCheck = ""
            Throw New Exception(exp.Message)
        Finally
            If Cmd.Connection.State = ConnectionState.Open Then Cmd.Connection.Close()
            Cmd.Dispose()
            Cmd = Nothing
        End Try
    End Function
    Public Shared Function GetWhlType(ByVal WhlNum As Long, ByVal HtNum As Long) As String
        Dim Cmd As System.Data.SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Cmd.Parameters.Add("@Type", SqlDbType.VarChar, 50)
        Cmd.Parameters("@Type").Direction = ParameterDirection.Output
        Cmd.CommandText = " select @Type = description from mm_wheel where wheel_number = @WhlNum and heat_number = @HtNum "
        Try
            Cmd.Parameters.Add("@WhlNum", SqlDbType.BigInt, 8).Value = WhlNum
            Cmd.Parameters.Add("@HtNum", SqlDbType.BigInt, 8).Value = HtNum
            If Cmd.Connection.State = ConnectionState.Closed Then Cmd.Connection.Open()
            Cmd.ExecuteScalar()
            GetWhlType = Cmd.Parameters("@Type").Value
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            If Cmd.Connection.State = ConnectionState.Open Then Cmd.Connection.Close()
            Cmd.Dispose()
            Cmd = Nothing
        End Try
    End Function
    Public Shared Function tblGetTypes() As DataTable
        Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        da.SelectCommand.CommandText = " select description from mm_product_master where product_code like '[1,2]%' order by description "
        Try
            da.Fill(ds)
            tblGetTypes = ds.Tables(0).Copy
            tblGetTypes.TableName = "Prods"
        Catch exp As Exception
            tblGetTypes = Nothing
            Throw New Exception(exp.Message)
        Finally
            ds.Dispose()
            da.Dispose()
            da = Nothing
            ds = Nothing
        End Try
    End Function
    Public Shared Function wheelHistoryCheckforTreadDiaBeforePress(ByVal whlstr As String) As DataSet
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "mm_sp_wheelHistoryCheckforTreadDiaBeforePress"
        oDa.SelectCommand.CommandType = CommandType.StoredProcedure
        oDa.SelectCommand.Parameters.Add("@whlstr", SqlDbType.VarChar, 50).Value = whlstr
        Try
            oDa.Fill(oDs)
            wheelHistoryCheckforTreadDiaBeforePress = oDs.Copy
        Catch exp As Exception
            wheelHistoryCheckforTreadDiaBeforePress = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
            oDa = Nothing
            oDs = Nothing
        End Try
    End Function
    Public Shared Function IsValidWheel(ByVal Wheel As Long, ByVal Heat As Long) As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.CommandText = "select count(*)  from mm_wheel a inner join mm_final_inspection b " & _
                " on a.wheel_number = b.wheel_number and a.heat_number = b.heat_number " & _
                " and thread_diameter = tread_diameter " & _
                " where a.wheel_number = " & Wheel & " And b.heat_number = " & Heat & "" & _
                " and ( press_status is null or press_status <> 'm' ) "
        Try
            cmd.Connection.Open()
            If cmd.ExecuteScalar > 0 Then IsValidWheel = True
        Catch exp As Exception
            IsValidWheel = False
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
        End Try
    End Function
    Public Shared Function PressSetDetails(ByVal Batch As String, ByVal DaySerial As Integer) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = " select wap.dbo.mm_si_fn_WhlStrPart(a.east_wheel_number, 'w') EWhl , " & _
            " wap.dbo.mm_si_fn_WhlStrPart(a.east_wheel_number, 'h') EHt , " & _
            " isnull(convert(numeric(6,1),a.east_tread_dia),0) ETreDia , " & _
            " wap.dbo.mm_si_fn_WhlStrPart(a.west_wheel_number, 'w') WWhl ,  " & _
            " wap.dbo.mm_si_fn_WhlStrPart(a.west_wheel_number, 'h') WHt , " & _
            " isnull(convert(numeric(6,1),a.west_tread_dia),0) WTreDia , " & _
            " b.NotIdentifiedRemarksByOp Rem ," & _
            " c.location ELoc , d.location WLoc" & _
            " from mm_mounting_press a inner join mm_wheelset_Identification_Remarks b " & _
            " on a.batch_number = b.batch_number and a.day_serial = b.day_serial " & _
            " inner join mm_wheel c on wap.dbo.mm_si_fn_WhlStrPart(a.east_wheel_number, 'w') = c.wheel_number" & _
            " and wap.dbo.mm_si_fn_WhlStrPart(a.east_wheel_number, 'h') = c.heat_number" & _
            " inner join mm_wheel d on wap.dbo.mm_si_fn_WhlStrPart(a.west_wheel_number, 'w') = d.wheel_number" & _
            " and wap.dbo.mm_si_fn_WhlStrPart(a.west_wheel_number, 'h') = d.heat_number" & _
            " where a.batch_number = '" & Batch & "' and a.day_serial =  " & DaySerial & " "
        Try
            oDa.Fill(oDs)
            PressSetDetails = oDs.Tables(0)
        Catch exp As Exception
            PressSetDetails = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
            oDa = Nothing
            oDs = Nothing
        End Try
    End Function
    Public Shared Function IsValidDia(ByVal Wheel As Long, ByVal Heat As Long, ByVal ReqTreadDia As Decimal) As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.CommandText = "select count(*) from mm_wheel a inner join mm_product_master b" & _
                " on a.description = b.description inner join mm_ProductwiseTreadAndBoreSizes c" & _
                " on c.productcode = b.product_code" & _
                " where wheel_number = " & Wheel & " And heat_number = " & Heat & "" & _
                " and " & ReqTreadDia & " between MinTreadDia and MaxTreadDia"
        Try
            cmd.Connection.Open()
            If cmd.ExecuteScalar > 0 Then IsValidDia = True
        Catch exp As Exception
            IsValidDia = False
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
        End Try
    End Function
    Public Shared Function wheelHistoryCheck(ByVal Wheel As String) As DataSet
        Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        Try
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.CommandText = "mm_sp_wheelHistoryCheck"
            da.SelectCommand.Parameters.Add("@whlstr", SqlDbType.VarChar, 50)
            da.SelectCommand.Parameters("@whlstr").Direction = ParameterDirection.Input
            da.SelectCommand.Parameters("@whlstr").Value = Wheel.Trim
            da.Fill(ds)
            wheelHistoryCheck = ds.Copy
        Catch exp As Exception
            wheelHistoryCheck = Nothing
            Throw New Exception(exp.Message)
        Finally
            ds.Dispose()
            da.Dispose()
            da = Nothing
            ds = Nothing
        End Try
    End Function
    Public Function UpdateWheelTreadDia(ByVal Wheel As Long, ByVal Heat As Long, ByVal ReqTreadDia As Decimal) As Boolean
        Dim blnDone As New Boolean()
        Dim Cmd As System.Data.SqlClient.SqlCommand = rwfGen.Connection.CmdObj()
        Try
            Cmd.Parameters.Add("@wh", SqlDbType.BigInt, 8).Value = Wheel
            Cmd.Parameters.Add("@ht", SqlDbType.BigInt, 8).Value = Heat
            Cmd.CommandText = " update mm_wheel set thread_diameter = " & Val(ReqTreadDia) & " where heat_number = @ht and wheel_number = @wh "
            If Cmd.Connection.State = ConnectionState.Closed Then Cmd.Connection.Open()
            Cmd.Transaction = Cmd.Connection.BeginTransaction
            Dim iAffectedRecs As Integer
            iAffectedRecs = Cmd.ExecuteNonQuery
            If iAffectedRecs = 1 Then
                iAffectedRecs = 0
                Cmd.CommandText = " update mm_final_inspection set tread_diameter = " & Val(ReqTreadDia) & " where heat_number = @ht and wheel_number = @wh and wheel_status like 'p%' "
                iAffectedRecs = Cmd.ExecuteNonQuery
                If iAffectedRecs = 1 Then
                    blnDone = True
                End If
            Else
                Throw New Exception(IIf(iAffectedRecs > 0, "Inform MIS. Serious error averted.", "Not a mounted wheel"))
            End If
            iAffectedRecs = Nothing
        Catch exp As Exception
            blnDone = False
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
        Return blnDone
    End Function
    Public Function UpdateTreadDia(ByVal Wheel As Long, ByVal Heat As Long, ByVal ReqTreadDia As Decimal) As Boolean
        Dim blnDone As Boolean
        Dim Cmd As System.Data.SqlClient.SqlCommand = rwfGen.Connection.CmdObj()
        Try
            Cmd.Parameters.Add("@wh", SqlDbType.BigInt, 8).Value = Wheel
            Cmd.Parameters.Add("@ht", SqlDbType.BigInt, 8).Value = Heat
            Cmd.CommandText = " update mm_wheel set thread_diameter = " & Val(ReqTreadDia) & " where heat_number = @ht and wheel_number = @wh "
            If Cmd.Connection.State = ConnectionState.Closed Then Cmd.Connection.Open()
            Cmd.Transaction = Cmd.Connection.BeginTransaction
            Dim iAffectedRecs As Integer
            iAffectedRecs = Cmd.ExecuteNonQuery
            If iAffectedRecs = 1 Then
                iAffectedRecs = 0
                Cmd.CommandText = " update mm_final_inspection set tread_diameter = " & Val(ReqTreadDia) & " where heat_number = @ht and wheel_number = @wh and wheel_status like 'p%' "
                iAffectedRecs = Cmd.ExecuteNonQuery
                If iAffectedRecs = 1 Then
                    blnDone = True
                End If
            Else
                Throw New Exception(IIf(iAffectedRecs > 0, "Inform MIS. Serious error averted.", "Not a mounted wheel"))
            End If
            iAffectedRecs = Nothing
        Catch exp As Exception
            blnDone = False
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
        Return blnDone
    End Function
    Public Function UpdateTreafDiaAfterPress(ByVal BatchNumber As String, ByVal DaySerial As Integer, ByVal UserID As String, ByVal ELocation As String, ByVal WLocation As String, ByVal Ewhl As Long, ByVal Eheat As Long, ByVal EastDia As Decimal, ByVal PreEastDia As Decimal, ByVal Wwhl As Long, ByVal Wheat As Long, ByVal WestDia As Decimal, ByVal PreWestDia As Decimal) As Boolean
        Dim cmd As System.Data.SqlClient.SqlCommand = rwfGen.Connection.CmdObj()
        Dim blnDone As Boolean
        Try
            cmd.Parameters.Add("@wheel_number", SqlDbType.BigInt, 8).Direction = ParameterDirection.Input
            cmd.Parameters.Add("@heat_number", SqlDbType.BigInt, 8).Direction = ParameterDirection.Input
            cmd.Parameters.Add("@TreadDia", SqlDbType.Float, 8).Direction = ParameterDirection.Input
            cmd.Parameters.Add("@Pre_TreadDia", SqlDbType.Float, 8).Direction = ParameterDirection.Input

            cmd.Parameters.Add("@batch_number", SqlDbType.VarChar, 3).Value = BatchNumber
            cmd.Parameters.Add("@Day_serial", SqlDbType.Int, 4).Value = Val(DaySerial)
            cmd.Parameters.Add("@ChangedBy", SqlDbType.VarChar, 6).Value = UserID
            cmd.Parameters.Add("@DateTimeSaved", SqlDbType.DateTime, 8).Value = Now

            cmd.Connection.Open()
            cmd.Transaction = cmd.Connection.BeginTransaction
            If ELocation.Trim = "CLFI" Then
                ' UPDATE IN FI
                ' East Tread Dia
                cmd.Parameters("@wheel_number").Value = Val(Ewhl)
                cmd.Parameters("@heat_number").Value = Val(Eheat)
                cmd.Parameters("@treadDia").Value = Val(EastDia)
                cmd.Parameters("@Pre_TreadDia").Value = CDec(PreEastDia)
                cmd.CommandText = "Update mm_final_inspection set tread_diameter = @treadDia where wheel_number = @wheel_number and heat_number = @heat_number and wheel_status like 'p%' "
                If cmd.ExecuteNonQuery() = 1 Then
                    ' update master
                    cmd.CommandText = "update mm_wheel set thread_diameter =  @treadDia where wheel_number = @wheel_number  and heat_number = @heat_number "
                    If cmd.ExecuteNonQuery() = 1 Then
                        ' update press
                        cmd.CommandText = "update mm_mounting_press set east_tread_dia =  @treadDia where batch_number = '" & BatchNumber & "' and day_serial = " & DaySerial
                        If cmd.ExecuteNonQuery() = 1 Then
                            ' insert in log
                            cmd.CommandText = "Insert into mm_TreadDia_Audit (batch_number, Day_serial, Wheel_number, Heat_number, Pre_TreadDia, ChangedBy, DateTimeSaved ) values (@batch_number, @Day_serial, @Wheel_number, @Heat_number, @Pre_TreadDia, @ChangedBy, @DateTimeSaved)"
                            If cmd.ExecuteNonQuery() = 1 Then blnDone = True
                        End If
                    End If
                End If
            End If
            If WLocation.Trim = "CLFI" Then
                blnDone = False
                ' west tread dia
                cmd.Parameters("@wheel_number").Value = Val(Wwhl)
                cmd.Parameters("@heat_number").Value = Val(Wheat)
                cmd.Parameters("@treadDia").Value = CDec(WestDia)
                cmd.Parameters("@Pre_TreadDia").Value = CDec(PreWestDia)
                cmd.CommandText = "Update mm_final_inspection set tread_diameter = @treadDia where wheel_number = @wheel_number and heat_number = @heat_number and wheel_status like 'p%' "
                If cmd.ExecuteNonQuery() = 1 Then
                    ' update master
                    cmd.CommandText = "update mm_wheel set thread_diameter = @treadDia where wheel_number = @wheel_number  and heat_number = @heat_number "
                    If cmd.ExecuteNonQuery() = 1 Then
                        ' update press
                        cmd.CommandText = "update mm_mounting_press set West_tread_dia =  @treadDia where batch_number = '" & BatchNumber & "' and day_serial = " & DaySerial
                        If cmd.ExecuteNonQuery() = 1 Then
                            ' insert in log
                            cmd.CommandText = "Insert into mm_TreadDia_Audit (batch_number, Day_serial, Wheel_number, Heat_number, Pre_TreadDia, ChangedBy, DateTimeSaved ) values (@batch_number, @Day_serial, @Wheel_number, @Heat_number, @Pre_TreadDia, @ChangedBy, @DateTimeSaved)"
                            If cmd.ExecuteNonQuery() = 1 Then blnDone = True
                        End If
                    End If
                End If
            End If
            If ELocation.Trim = "CLQC" Then
                ' UPDATE IN YARD
                ' East Wheel
                blnDone = False
                cmd.Parameters("@wheel_number").Value = Val(Ewhl)
                cmd.Parameters("@heat_number").Value = Val(Eheat)
                cmd.Parameters("@treadDia").Value = CDec(EastDia)
                cmd.Parameters("@Pre_TreadDia").Value = CDec(PreEastDia)
                cmd.CommandText = "Update mm_yard_inspection set tread_diameter_by_final_inspection = @treadDia where wheel_number = @wheel_number and heat_number = @heat_number and wheel_disposition like 's%p' "
                If cmd.ExecuteNonQuery() = 1 Then
                    ' update master
                    cmd.CommandText = "update mm_wheel set thread_diameter =  @treadDia where wheel_number = @wheel_number  and heat_number = @heat_number "
                    If cmd.ExecuteNonQuery() = 1 Then
                        ' update press
                        cmd.CommandText = "update mm_mounting_press set East_tread_dia = @TreadDia where batch_number = '" & BatchNumber & "' and day_serial = " & DaySerial
                        If cmd.ExecuteNonQuery() = 1 Then
                            ' insert in log
                            cmd.CommandText = "Insert into mm_TreadDia_Audit (batch_number, Day_serial, Wheel_number, Heat_number, Pre_TreadDia, ChangedBy, DateTimeSaved ) values (@batch_number, @Day_serial, @Wheel_number, @Heat_number, @Pre_TreadDia, @ChangedBy, @DateTimeSaved)"
                            If cmd.ExecuteNonQuery() = 1 Then

                            End If
                        End If
                    End If
                End If
            End If
            If WLocation.Trim = "CLQC" Then
                blnDone = False
                ' West Wheel 
                cmd.Parameters("@wheel_number").Value = Val(Wwhl)
                cmd.Parameters("@heat_number").Value = Val(Wheat)
                cmd.Parameters("@treadDia").Value = CDec(WestDia)
                cmd.Parameters("@Pre_TreadDia").Value = CDec(PreWestDia)
                cmd.CommandText = "Update mm_yard_inspection set tread_diameter_by_final_inspection = @treadDia where wheel_number = @wheel_number and heat_number = @heat_number and wheel_disposition like 's%p' "
                If cmd.ExecuteNonQuery() = 1 Then
                    ' update master
                    cmd.CommandText = "update mm_wheel set thread_diameter = @TreadDia where wheel_number = @wheel_number  and heat_number = @heat_number "
                    If cmd.ExecuteNonQuery() = 1 Then
                        ' update press
                        cmd.CommandText = "update mm_mounting_press set West_tread_dia = @TreadDia where batch_number = '" & BatchNumber & "' and day_serial = " & DaySerial
                        If cmd.ExecuteNonQuery() = 1 Then
                            ' insert in log
                            cmd.CommandText = "Insert into mm_TreadDia_Audit (batch_number, Day_serial, Wheel_number, Heat_number, Pre_TreadDia, ChangedBy, DateTimeSaved ) values (@batch_number, @Day_serial, @Wheel_number, @Heat_number, @Pre_TreadDia, @ChangedBy, @DateTimeSaved)"
                            If cmd.ExecuteNonQuery() = 1 Then blnDone = True
                        End If
                    End If
                End If
            End If
            ' UPDATE REMS
            blnDone = False
            cmd.CommandText = "update mm_wheelset_Identification_Remarks set NotIdentifiedRemarksByOp = replace (NotIdentifiedRemarksByOp, 'Unpairable set Due to Tread Dia','') where batch_number = '" & BatchNumber & "' and day_serial = " & DaySerial
            If cmd.ExecuteNonQuery() = 1 Then blnDone = True
        Catch exp As Exception
            blnDone = False
            Throw New Exception(exp.Message)
        Finally
            If IsNothing(cmd.Transaction) = False Then
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
        Return blnDone
    End Function
    Public Function ChangeWhlType(ByVal WhlNum As Long, ByVal HtNum As Long, ByVal NewTypesOfWhleel As String, ByVal PresentType As String, ByVal EmpCode As String) As Boolean
        Dim blnDone As New Boolean()
        Dim Cmd As System.Data.SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            Cmd.CommandText = "select wap.dbo.mm_fn_si_IsWheelDespatched('" & WhlNum & "/" & HtNum & "')"
            If Cmd.Connection.State = ConnectionState.Closed Then Cmd.Connection.Open()
            If Cmd.ExecuteScalar > 0 Then
                Throw New Exception("Wheel is already despatched")
            End If
            Cmd.CommandText = " update mm_wheel set description = @Type where wheel_number = @WhlNum and heat_number = @HtNum "
            Cmd.Parameters.Add("@Type", SqlDbType.VarChar, 50).Value = NewTypesOfWhleel.Trim
            Cmd.Parameters.Add("@WhlNum", SqlDbType.BigInt, 8).Value = WhlNum
            Cmd.Parameters.Add("@HtNum", SqlDbType.BigInt, 8).Value = HtNum
            Cmd.Transaction = Cmd.Connection.BeginTransaction
            If Cmd.ExecuteNonQuery = 1 Then
                Cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 6).Value = EmpCode.Trim
                Cmd.Parameters.Add("@PresentType", SqlDbType.VarChar, 50).Value = PresentType.Trim
                Cmd.Parameters.Add("@SavedDtTime", SqlDbType.DateTime, 8).Value = Now
                Cmd.CommandText = " insert into mm_wheel_TypeChangeByInsp ( wheel_number , heat_number , InspCode , originalDescr , RevisedDescr , SaveDateTime ) " & _
                        " values ( @WhlNum , @HtNum , @EmpCode, @PresentType , @Type , @SavedDtTime)"
                If Cmd.ExecuteNonQuery = 1 Then blnDone = True
            End If
        Catch exp As Exception
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
        Return blnDone
    End Function
    Public Function ClearMountStatus(ByVal ReturnWheel As Long, ByVal ReturnHeat As Long) As Boolean
        Dim blnDone As New Boolean()
        Dim Cmd As System.Data.SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            Cmd.Parameters.Add("@wheel_number", SqlDbType.BigInt, 8).Value = ReturnWheel
            Cmd.Parameters.Add("@heat_Number", SqlDbType.BigInt, 8).Value = ReturnHeat
            Cmd.CommandText = " update mm_wheel set press_status = null where heat_number = @heat_number and wheel_number = @wheel_number and press_status = 'M'"
            If Cmd.Connection.State = ConnectionState.Closed Then Cmd.Connection.Open()
            Cmd.Transaction = Cmd.Connection.BeginTransaction
            Dim iAffectedRecs As Integer
            iAffectedRecs = Cmd.ExecuteNonQuery
            If iAffectedRecs = 1 Then
                blnDone = True
            Else
                Throw New Exception(IIf(iAffectedRecs > 0, "Inform MIS. Serious error averted.", "Not a mounted wheel"))
            End If
            iAffectedRecs = Nothing
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
        Return blnDone
    End Function
    Public Function UpdateMountStatus(ByVal Axle As String) As String
        Dim blnDone As New Boolean()
        Dim Cmd As System.Data.SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            Cmd.Parameters.Add("@Ax", SqlDbType.VarChar, 50).Value = Axle.Trim
            Cmd.Parameters.Add("@done", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.CommandText = "mm_sp_UpdateMountStatus"
            If Cmd.Connection.State = ConnectionState.Closed Then Cmd.Connection.Open()
            Cmd.Transaction = Cmd.Connection.BeginTransaction
            If Cmd.ExecuteNonQuery > 0 Then
                blnDone = True
            End If
            Return Cmd.Parameters("@done").Value
        Catch exp As Exception
            blnDone = False
        Finally
            If blnDone Then
                Cmd.Transaction.Commit()
            Else
                Cmd.Transaction.Rollback()
            End If
            If Cmd.Connection.State = ConnectionState.Open Then Cmd.Connection.Close()
            Cmd.Dispose()
            Cmd = Nothing
            blnDone = Nothing
        End Try
    End Function
    Public Function UpdateMountStatusBeforeInsp(ByVal Axle As String) As String
        Dim blnDone As New Boolean()
        Dim Cmd As System.Data.SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            Cmd.Parameters.Add("@Ax", SqlDbType.VarChar, 50).Value = Axle.Trim
            Cmd.Parameters.Add("@done", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.CommandText = "mm_sp_UpdateMountStatusBeforeInsp"
            If Cmd.Connection.State = ConnectionState.Closed Then Cmd.Connection.Open()
            Cmd.Transaction = Cmd.Connection.BeginTransaction
            If Cmd.ExecuteNonQuery > 0 Then
                blnDone = True
            End If
            Return Cmd.Parameters("@done").Value
        Catch exp As Exception
            blnDone = False
        Finally
            If blnDone Then
                Cmd.Transaction.Commit()
            Else
                Cmd.Transaction.Rollback()
            End If
            If Cmd.Connection.State = ConnectionState.Open Then Cmd.Connection.Close()
            Cmd.Dispose()
            Cmd = Nothing
            blnDone = Nothing
        End Try
    End Function
End Class