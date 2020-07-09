Namespace RWF
    Public Class WHLQCI
        Public Shared Function GetQCIWheelsDetails(ByVal Wheel As Long, ByVal Heat As Long) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.Parameters.Add("@Wheel", SqlDbType.BigInt, 8).Value = Wheel
            da.SelectCommand.Parameters.Add("@Heat", SqlDbType.BigInt, 8).Value = Heat
            da.SelectCommand.CommandText = " select rtrim(status)  status ,  rtrim(location) location  , " &
                " rtrim(description) description  from mm_wheel where wheel_number = @Wheel and heat_number = @Heat "
            Try
                da.Fill(ds)
                GetQCIWheelsDetails = ds.Tables(0)
            Catch exp As Exception
                GetQCIWheelsDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function CheckInspDate(ByVal InspDate As Date) As Int16
            Dim oCmd As SqlClient.SqlCommand
            oCmd = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@InspDate", SqlDbType.SmallDateTime, 4).Value = InspDate
            oCmd.Parameters.Add("@Cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = "Select @Cnt = count(*) from mm_pink_sheet where pink_date = @InspDate "
                oCmd.ExecuteScalar()
                CheckInspDate = IIf(IsDBNull(oCmd.Parameters("@Cnt").Value), 0, oCmd.Parameters("@Cnt").Value)
            Catch exp As Exception
                CheckInspDate = 0
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function
        Public Shared Function GetSavedQCIWheels(ByVal InspDate As Date) As DataSet
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "select row_number() over ( order by sl_no desc ) Sl , sl_no ,  " &
                " convert(varchar(11),inspection_date,103) QCIDate , shift_code Sh , lab_authority LAB , " &
                " technical_authority Tech , inspection_authority Insp , wheel_number Wh , heat_number Ht , " &
                " pre_location PreLoc , pre_status PreSts , wheel_disposition QCISts , remarks_qci " &
                " from mm_qci_inspection where inspection_date = @InspDate order by sl_no desc ;" &
                " select row_number() over ( order by wheel_disposition ) Sl , " &
                " wheel_disposition QCISts , count(*) cnt" &
                " from mm_qci_inspection" &
                " where inspection_date = @InspDate " &
                " group by wheel_disposition " &
                " order by wheel_disposition "
            da.SelectCommand.Parameters.Add("@InspDate", SqlDbType.SmallDateTime, 4).Value = InspDate
            Try
                da.Fill(ds)
                GetSavedQCIWheels = ds.Copy
            Catch exp As Exception
                GetSavedQCIWheels = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Function QCIWheelAdd(ByVal InspDate As Date, ByVal Shift As String, ByVal Lab As String, ByVal Technical As String, ByVal Inspector As String, ByVal Wheel As Long, ByVal Heat As Long, ByVal status As String, ByVal loca As String, ByVal wheeltype As String, ByVal WheelDisposition As String, ByVal Remarks As String, ByVal SlNo As Integer) As Boolean
            Dim Done As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                oCmd.Parameters.Add("@InspDate", SqlDbType.SmallDateTime, 4).Value = CDate(InspDate)
                oCmd.Parameters.Add("@Shift", SqlDbType.VarChar, 1).Value = Shift
                oCmd.Parameters.Add("@Lab", SqlDbType.VarChar, 6).Value = Lab
                oCmd.Parameters.Add("@Technical", SqlDbType.VarChar, 6).Value = Technical
                oCmd.Parameters.Add("@Inspector", SqlDbType.VarChar, 6).Value = Inspector
                oCmd.Parameters.Add("@Wheel", SqlDbType.BigInt, 8).Value = Wheel
                oCmd.Parameters.Add("@Heat", SqlDbType.BigInt, 8).Value = Heat
                oCmd.Parameters.Add("@status", SqlDbType.VarChar, 50).Value = status
                oCmd.Parameters.Add("@loca", SqlDbType.VarChar, 50).Value = loca
                oCmd.Parameters.Add("@wheeltype", SqlDbType.VarChar, 50).Value = wheeltype
                oCmd.Parameters.Add("@WheelDisposition", SqlDbType.VarChar, 50).Value = WheelDisposition
                oCmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 50).Value = Remarks
                oCmd.Parameters.Add("@sl_no", SqlDbType.BigInt, 8).Value = SlNo

                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                If SlNo = 0 Then
                    oCmd.CommandText = "select count(*) from mm_qci_inspection " &
                                        " where inspection_date = @InspDate and shift_code = @Shift and lab_authority = @Lab " &
                                        " and wheel_number = @Wheel  and heat_number = @Heat and wheel_disposition = @WheelDisposition "
                    Dim intDupcount As Integer = oCmd.ExecuteScalar
                    If intDupcount > 0 Then
                        Done = False
                        Throw New Exception(" This Record already exisits !")
                        Exit Try
                    End If
                    oCmd.CommandText = "insert into mm_qci_inspection ( inspection_date , shift_code , " &
                        " lab_authority , technical_authority , inspection_authority , wheel_number , heat_number , " &
                        " pre_status , pre_location , product_code , wheel_disposition , remarks_qci ) " &
                        " values (  @InspDate , @Shift , @Lab , @Technical , @Inspector , @Wheel , @Heat , @status , @loca , " &
                        " @wheeltype , @WheelDisposition , @Remarks ) "
                Else
                    oCmd.CommandText = "update mm_qci_inspection set wheel_disposition = @WheelDisposition " &
                        " where wheel_number = @Wheel and heat_number =  @Heat and sl_no = @sl_no"
                End If
                If oCmd.ExecuteNonQuery() = 1 Then
                    oCmd.CommandText = "update mm_wheel set location = 'CLFQ', status = @WheelDisposition " &
                        " where wheel_number = @Wheel and heat_number = @Heat"
                    If oCmd.ExecuteNonQuery() = 1 Then
                        Done = True
                    End If
                End If
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

        Public Shared Function CheckQCIInsp(ByVal InspDate As Date, ByVal Whl As Long, ByVal Ht As Long) As Boolean
            Dim oCmd As SqlClient.SqlCommand
            oCmd = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@Whl", SqlDbType.BigInt, 8).Value = Whl
            oCmd.Parameters.Add("@Ht", SqlDbType.BigInt, 8).Value = Ht
            oCmd.Parameters.Add("@InspDate", SqlDbType.SmallDateTime, 4).Value = InspDate
            oCmd.Parameters.Add("@Cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = "Select @Cnt = count(*) from mm_qci_inspection where inspection_date = @InspDate " &
                    " and wheel_number = @Whl and heat_number = @Ht "
                oCmd.ExecuteScalar()
                CheckQCIInsp = IIf(IsDBNull(oCmd.Parameters("@Cnt").Value), 0, oCmd.Parameters("@Cnt").Value)
            Catch exp As Exception
                CheckQCIInsp = 0
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function
    End Class

End Namespace