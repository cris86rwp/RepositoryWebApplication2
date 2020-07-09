Namespace LooseAxleInspClass
    Public Class Connection
        Public Shared Function ConString(Optional ByVal Local As Boolean = False) As String
            If Not Local Then ConString = ConfigurationSettings.AppSettings("con")
            ' If Local Then ConString = ConfigurationSettings.AppSettings("svicon")
        End Function
        Public Shared Function ConObj(Optional ByVal Local As Boolean = False) As SqlClient.SqlConnection
            ConObj = New SqlClient.SqlConnection()
            ConObj.ConnectionString = ConString(Local)
        End Function
        Public Shared Function CmdObj(Optional ByVal Local As Boolean = False, Optional ByVal TimeOutInSeconds As Integer = 9000) As SqlClient.SqlCommand
            CmdObj = New SqlClient.SqlCommand()
            CmdObj.Connection = ConObj(Local)
            CmdObj.CommandTimeout = TimeOutInSeconds
        End Function
        Public Shared Function Adapter(Optional ByVal Local As Boolean = False, Optional ByVal TimeOutInSeconds As Integer = 9000) As SqlClient.SqlDataAdapter
            Adapter = New SqlClient.SqlDataAdapter()
            Adapter.SelectCommand = CmdObj(Local, TimeOutInSeconds)
            Adapter.InsertCommand = CmdObj(Local, TimeOutInSeconds)
            Adapter.UpdateCommand = CmdObj(Local, TimeOutInSeconds)
            Adapter.DeleteCommand = CmdObj(Local, TimeOutInSeconds)
        End Function
    End Class
    Public Class Batch
        Private sBatchNumber As String
        Private iBatchQty As Integer
        Private iSampleSize As Integer
        Private blnRefresh As Boolean
        Private sInspStatus As String
        Private iInspQty As Integer
        Private dOfferDate As Date
        Private Sub New()

        End Sub
        ReadOnly Property InspectedQty() As Integer
            Get
                Dim cmd As SqlClient.SqlCommand = Connection.CmdObj
                cmd.CommandText = "select count(*) from mm_vw_si_LooseAxleInspSamples where batchnumber = '" & sBatchNumber & "'"
                Try
                    cmd.Connection.Open()
                    iInspQty = cmd.ExecuteScalar
                Catch exp As Exception
                    iInspQty = 0
                    Throw New Exception(exp.Message)
                Finally
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                    If IsNothing(iInspQty) Then
                        iInspQty = 0
                    End If
                    If IsDBNull(iInspQty) Then
                        iInspQty = 0
                    End If
                End Try
                Return iInspQty
            End Get
        End Property
        ReadOnly Property OfferDate() As Date
            Get
                Dim cmd As SqlClient.SqlCommand = Connection.CmdObj
                cmd.CommandText = "select max(offered_date) OfferedDate from mm_rdso_offered_axles where batch_number_loose_axles like '" & sBatchNumber & "/%'"
                Try
                    cmd.Connection.Open()
                    dOfferDate = cmd.ExecuteScalar
                Catch exp As Exception
                    dOfferDate = CDate("1/1/1900")
                Finally
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                    If IsNothing(dOfferDate) Then
                        dOfferDate = CDate("1/1/1900")
                    End If
                    If IsDBNull(dOfferDate) Then
                        dOfferDate = CDate("1/1/1900")
                    End If
                End Try
                Return dOfferDate
            End Get
        End Property
        ReadOnly Property BatchInspStatus() As String
            Get
                Dim cmd As SqlClient.SqlCommand = Connection.CmdObj
                cmd.CommandText = "select count(*) from mm_vw_si_LooseAxlesInspHold where batchNumber = '" & sBatchNumber & "'"
                Try
                    cmd.Connection.Open()
                    sInspStatus = IIf(cmd.ExecuteScalar > 0, "HOLD", "")
                    If sInspStatus = "" Then
                        If iInspQty = iSampleSize And iSampleSize > 0 Then
                            sInspStatus = "PASSED"
                        Else
                            sInspStatus = ""
                        End If
                    End If
                    If sInspStatus = "" Then
                        sInspStatus = "IN PROGRESS"
                    End If
                Catch exp As Exception
                    sInspStatus = ""
                    Throw New Exception(exp.Message)
                Finally
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                    If IsNothing(sInspStatus) Or IsDBNull(sInspStatus) Then
                        sInspStatus = ""
                    End If
                    sInspStatus = sInspStatus.ToUpper.Trim
                End Try
                Return sInspStatus
            End Get
        End Property
        Public Sub New(ByVal BatchNumber As String, ByVal Refresh As Boolean)
            sBatchNumber = BatchNumber
            blnRefresh = Refresh
            iBatchQty = 0
            iSampleSize = 0
        End Sub
        ReadOnly Property BatchNumber() As String
            Get
                Return sBatchNumber.ToUpper
            End Get
        End Property
        ReadOnly Property BatchQty() As Integer
            Get
                Return iBatchQty
            End Get
        End Property
        Public Function OfferedAxles() As DataTable
            Dim da As SqlClient.SqlDataAdapter = Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = "Select * from mm_vw_si_LooseAxlesOfferedForInspection where batchNumber = '" & sBatchNumber & "'  order by BatchNumber, BatchSlNo "
            Try
                da.Fill(ds, "OfferedAxles")
                OfferedAxles = ds.Tables("OfferedAxles")
            Catch exp As Exception
                ds = Nothing
                OfferedAxles = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                If IsNothing(ds) = False Then OfferedAxles = ds.Tables("OfferedAxles")
                ds.Dispose()
            End Try
        End Function
        ReadOnly Property SampleSize() As Integer
            Get
                Return iSampleSize
            End Get
        End Property
        Public Sub BatchInsert(ByVal oInspection As AxleInspection)
            Dim dt As DataTable = OfferedAxles()
            Dim rowSrc As DataRow
            If blnRefresh Then
                If BatchExists(sBatchNumber) Then
                    If BatchDelete(sBatchNumber) = False Then
                        ' Insert will fail hence exit sub
                        Exit Sub
                    End If
                End If
            End If

            Dim cmd As SqlClient.SqlCommand = Connection.CmdObj
            If blnRefresh Then
                cmd.CommandText = "insert into mm_loose_axle_inspection (BatchNumber, BatchSerial, AxleNumber, InspDate, InspShift, Inspector) values (@BatchNumber, @BatchSerial, @AxleNumber, @InspDate, @InspShift, @InspEmpCode)"
                cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar, 50)
                cmd.Parameters.Add("@BatchSerial", SqlDbType.Int, 4)
                cmd.Parameters.Add("@AxleNumber", SqlDbType.VarChar, 50)

                cmd.Parameters.Add("@InspDate", SqlDbType.SmallDateTime, 4)
                cmd.Parameters.Add("@InspShift", SqlDbType.VarChar, 1)
                cmd.Parameters.Add("@InspEmpCode", SqlDbType.VarChar, 6)

                cmd.Parameters("@BatchNumber").Direction = ParameterDirection.Input
                cmd.Parameters("@BatchSerial").Direction = ParameterDirection.Input
                cmd.Parameters("@AxleNumber").Direction = ParameterDirection.Input

                cmd.Parameters("@InspDate").Direction = ParameterDirection.Input
                cmd.Parameters("@InspShift").Direction = ParameterDirection.Input
                cmd.Parameters("@InspEmpCode").Direction = ParameterDirection.Input
                cmd.Parameters("@InspDate").Value = oInspection.InspDate
                cmd.Parameters("@InspShift").Value = oInspection.InspShift
                cmd.Parameters("@InspEmpCode").Value = oInspection.InspEmpCode
                Try
                    cmd.Connection.Open()
                    For Each rowSrc In dt.Rows
                        cmd.Parameters("@BatchNumber").Value = CStr(rowSrc("BatchNumber"))
                        cmd.Parameters("@BatchSerial").Value = rowSrc("BatchSlNo")
                        cmd.Parameters("@AxleNumber").Value = rowSrc("AxleNumber")
                        cmd.ExecuteNonQuery()
                    Next
                Catch exp As Exception
                    Throw New Exception(exp.Message)
                Finally
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                End Try
            Else
                ' no action needed

            End If
            GetBatchQty()
        End Sub
        Private Function BatchExists(ByVal BatchNumber As String) As Boolean
            Dim cmd As SqlClient.SqlCommand = Connection.CmdObj
            cmd.CommandText = "select count(*) from mm_loose_axle_Inspection where batchNumber = '" & BatchNumber & "'"
            Try
                cmd.Connection.Open()
                BatchExists = cmd.ExecuteScalar > 0
            Catch exp As Exception
                BatchExists = False
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Private Function BatchDelete(ByVal BatchNumber As String) As Boolean
            Dim cmd As SqlClient.SqlCommand = Connection.CmdObj
            cmd.CommandText = "Delete from mm_loose_axle_Inspection where batchNumber = '" & BatchNumber & "'"
            Try
                cmd.Connection.Open()
                cmd.ExecuteNonQuery()
                BatchDelete = Not BatchExists(BatchNumber)
            Catch exp As Exception
                BatchDelete = False
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Private Sub GetBatchQty()
            Dim cmd As SqlClient.SqlCommand = Connection.CmdObj
            cmd.CommandText = "Select count(*) from mm_loose_axle_inspection where batchNumber = '" & sBatchNumber & "'"
            Try
                cmd.Connection.Open()
                iBatchQty = cmd.ExecuteScalar()
                If IsDBNull(iBatchQty) Then
                    iBatchQty = 0
                End If
                If IsNothing(iBatchQty) Then
                    iBatchQty = 0
                End If
            Catch exp As Exception
                iBatchQty = 0
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
            getbatchsize()
            updateBatchQty()
        End Sub
        Private Sub updateBatchQty()
            Dim cmd As SqlClient.SqlCommand = Connection.CmdObj
            cmd.CommandText = "update mm_loose_axle_inspection set BatchQty = " & iBatchQty & ", SampleSize = " & iSampleSize & " where batchNumber = '" & sBatchNumber & "'"
            Try
                cmd.Connection.Open()
                cmd.ExecuteNonQuery()
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Sub
        Private Sub getbatchsize()
            Select Case iBatchQty
                Case Is > 1200
                    iSampleSize = 50
                Case Is > 500
                    iSampleSize = 32
                Case Is > 280
                    iSampleSize = 20
                Case Is > 150
                    iSampleSize = 13
                Case Is > 90
                    iSampleSize = 8
                Case Is > 25
                    iSampleSize = 5
                Case Is > 15
                    iSampleSize = 3
                Case Is > 1
                    iSampleSize = 2
                Case Else
                    iSampleSize = iBatchQty
            End Select
        End Sub
        Public Function SampleAxlesTable() As DataTable
            Dim da As SqlClient.SqlDataAdapter = Connection.Adapter
            da.SelectCommand.CommandText = "select sampleNumber, InspDate , InspShift, Inspector, AxleInspStatus, InspRemarks, Journal_TapHole_UTP, Journal_Pitch_Circle_UTP, Journal_Cone_Dia_UTP, Journal_Centre_Type_UTP, Journal_Dia_UTP, Journal_Length_UTP, Journal_Thread_Condition_UTP, Journal_TapHole_UTO, Journal_Pitch_Circle_UTO, Journal_Cone_Dia_UTO, Journal_Centre_Type_UTO, Journal_Dia_UTO, Journal_Length_UTO, Journal_Thread_Condition_UTO, Wheel_Seat_Dia_UTP, Wheel_Seat_Length_UTP, Wheel_Seat_Dia_UTO, Wheel_Seat_Length_UTO, Body_Dia, Body_Length, FullAxle, FullAxleLength, DustGuard_Dia_UTP, DustGuard_Dia_UTO, DustGuard_Length_UTO, DustGuard_Length_UTP, RwCodeFullAxle, RwCodeJournalUT, RwCodeDustGuardUT, RwCodeWhlSeatUT, RwCodeBody, RwCodeWhlSeatMPT, RwCodeDustGuardMPT, RwCodeJournalMPT from mm_loose_axle_inspection where BatchNumber= '" & sBatchNumber & "' and isnull(sampleNumber,'') <> '' order by SampleNumber desc"
            Dim ds As New DataSet()
            Try
                da.Fill(ds, "SampleAxles")
                SampleAxlesTable = ds.Tables("SampleAxles")
            Catch exp As Exception
                ds = Nothing
                SampleAxlesTable = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
    End Class
    Public Class AxleInspection
        Private dInspDate As Date
        Private sShift As String
        Private sInspEmpcode As String
        Public Sub New(ByVal InspEmpCode As String)
            dInspDate = Today.Date
            Select Case Now.Hour
                Case 6 To 13
                    sShift = "A"
                Case 14 To 21
                    sShift = "B"
                Case Else
                    sShift = "C"
            End Select
            sInspEmpcode = InspEmpCode
        End Sub
        ReadOnly Property InspDate() As Date
            Get
                Return dInspDate
            End Get
        End Property
        ReadOnly Property InspShift() As String
            Get
                Select Case Now.Hour
                    Case 6 To 13
                        sShift = "A"
                    Case 14 To 21
                        sShift = "B"
                    Case Else
                        sShift = "C"
                End Select
                Return sShift
            End Get
        End Property
        ReadOnly Property InspEmpCode() As String
            Get
                Return sInspEmpcode
            End Get
        End Property
        Public Function AddSample(ByRef oSampleAxleObj As LooseAxleInspClass.SampleAxle, ByRef oBatchObj As LooseAxleInspClass.Batch) As String
            Dim strCheck, strNewSampleNo, strAddSample, strSampleNoForAxle As String
            strCheck = "select count(*) from mm_loose_axle_inspection where BatchNumber= '" & oBatchObj.BatchNumber & "'"
            strNewSampleNo = "select count(*)+1 from mm_loose_axle_inspection where BatchNumber= '" & oBatchObj.BatchNumber & "' and isnull(sampleNumber,'') <> ''"
            strSampleNoForAxle = "Select isnull(SampleNumber,0) from mm_loose_axle_inspection where batchNumber = '" & oBatchObj.BatchNumber & "' and AxleNumber = '" & oSampleAxleObj.AxleNumber & "'"
            strAddSample = " update  " & _
            " mm_loose_axle_inspection  " & _
            " set  " & _
            " sampleNumber = @sampleNumber, " & _
            " InspDate = @InspDate , " & _
            " InspShift = @InspShift, " & _
            " Inspector = @Inspector, " & _
            " AxleInspStatus = @AxleInspStatus, " & _
            " InspRemarks = @InspRemarks,  " & _
            " Journal_TapHole_UTP = @Journal_TapHole_UTP,  " & _
            " Journal_Pitch_Circle_UTP = @Journal_Pitch_Circle_UTP, " & _
            " Journal_Cone_Dia_UTP = @Journal_Cone_Dia_UTP,  " & _
            " Journal_Centre_Type_UTP = @Journal_Centre_Type_UTP, " & _
            " Journal_Dia_UTP = @Journal_Dia_UTP,  " & _
            " Journal_Length_UTP = @Journal_Length_UTP,  " & _
            " Journal_Thread_Condition_UTP = @Journal_Thread_Condition_UTP, " & _
            " Journal_TapHole_UTO = @Journal_TapHole_UTO,  " & _
            " Journal_Pitch_Circle_UTO = @Journal_Pitch_Circle_UTO,  " & _
            " Journal_Cone_Dia_UTO = @Journal_Cone_Dia_UTO, " & _
            " Journal_Centre_Type_UTO = @Journal_Centre_Type_UTO, " & _
            " Journal_Dia_UTO = @Journal_Dia_UTO,  " & _
            " Journal_Length_UTO = @Journal_Length_UTO,  " & _
            " Journal_Thread_Condition_UTO = @Journal_Thread_Condition_UTO,  " & _
            " Wheel_Seat_Dia_UTP = @Wheel_Seat_Dia_UTP,  " & _
            " Wheel_Seat_Length_UTP = @Wheel_Seat_Length_UTP,  " & _
            " Wheel_Seat_Dia_UTO = @Wheel_Seat_Dia_UTO,  " & _
            " Wheel_Seat_Length_UTO = @Wheel_Seat_Length_UTO,  " & _
            " Body_Dia = @Body_Dia,  " & _
            " Body_Length = @Body_Length,  " & _
            " FullAxle = @FullAxle,  " & _
            " FullAxleLength = @FullAxleLength,  " & _
            " DustGuard_Dia_UTP = @DustGuard_Dia_UTP,  " & _
            " DustGuard_Dia_UTO = @DustGuard_Dia_UTO,  " & _
            " DustGuard_Length_UTO = @DustGuard_Length_UTO,  " & _
            " DustGuard_Length_UTP = @DustGuard_Length_UTP,  " & _
            " RwCodeFullAxle = @RwCodeFullAxle,  " & _
            " RwCodeJournalUT = @RwCodeJournalUT, " & _
            " RwCodeDustGuardUT = @RwCodeDustGuardUT, " & _
            " RwCodeWhlSeatUT = @RwCodeWhlSeatUT,  " & _
            " RwCodeBody = @RwCodeBody,  " & _
            " RwCodeWhlSeatMPT = @RwCodeWhlSeatMPT,  " & _
            " RwCodeDustGuardMPT = @RwCodeDustGuardMPT,  " & _
            " RwCodeJournalMPT = @RwCodeJournalMPT " & _
            " where  " & _
            " BatchNumber= @BatchNumber and axleNumber = @axleNumber "
            Dim strBatchStatusUpdt As String
            strBatchStatusUpdt = "Update mm_loose_axle_inspection set BatchInspStatus = @BatchInspStatus where batchNumber = @BatchNumber"

            Dim cmd As SqlClient.SqlCommand = Connection.CmdObj
            Dim newNo As Integer
            Dim ExistingNo As Integer
            Dim recordsAffected As Integer
            Dim blnUpdated As Boolean

            Try
                Dim iInspectedQty, iSampleSize As Integer ' collected outside obatchobj to avoid trans lock down under.

                iInspectedQty = oBatchObj.InspectedQty
                iSampleSize = oBatchObj.SampleSize

                ExistingNo = oSampleAxleObj.GetSampleNumber(oBatchObj)
                cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                If ExistingNo = 0 Then
                    cmd.CommandText = strCheck
                    If cmd.ExecuteScalar > 0 Then
                        cmd.CommandText = strNewSampleNo
                        newNo = cmd.ExecuteScalar
                    Else
                        newNo = 0
                    End If
                Else
                    newNo = ExistingNo
                End If

                If ExistingNo = 0 And newNo = 0 Then
                    Throw New Exception("Cannot be saved. Contact MIS center")
                End If
                AppendParameters(cmd)
                ParamDirection(cmd)
                ParamAssignValues(cmd, oSampleAxleObj, oBatchObj, newNo)
                cmd.CommandText = strAddSample
                recordsAffected = cmd.ExecuteNonQuery
                If recordsAffected > 0 Then
                    If CStr(cmd.Parameters("@AxleInspStatus").Value).StartsWith("HOLD") Then
                        cmd.CommandText = "Select count(*) from mm_loose_axle_inspection_hold where batchNumber = @batchNumber and axleNumber = @axleNumber"
                        If cmd.ExecuteScalar = 0 Then
                            cmd.CommandText = "insert into mm_loose_axle_inspection_hold select * from mm_loose_Axle_inspection where batchnumber = @batchNumber and axleNumber = @AxleNumber "
                            recordsAffected = cmd.ExecuteNonQuery()
                        End If
                    Else
                        cmd.CommandText = "Select count(*) from mm_loose_axle_inspection_hold where batchNumber = @batchNumber and axleNumber = @axleNumber"
                        If cmd.ExecuteScalar > 0 Then
                            cmd.CommandText = "delete mm_loose_axle_inspection_hold where batchnumber = @batchNumber and axleNumber = @AxleNumber "
                            recordsAffected = cmd.ExecuteNonQuery()
                        End If
                    End If
                    If recordsAffected > 0 Then
                        Dim sBatchInspStatus As String ' collected outside oBatchObj because of transaction is live
                        cmd.CommandText = "select count(*) from mm_vw_si_LooseAxlesInspHold where batchNumber = '" & oBatchObj.BatchNumber & "'"
                        sBatchInspStatus = IIf(cmd.ExecuteScalar > 0, "HOLD", "")
                        If IsNothing(sBatchInspStatus) Or IsDBNull(sBatchInspStatus) Then
                            sBatchInspStatus = ""
                        End If
                        If sBatchInspStatus = "" Then
                            If iInspectedQty = iSampleSize Then
                                sBatchInspStatus = "PASSED"
                            Else
                                sBatchInspStatus = ""
                            End If
                        End If
                        If sBatchInspStatus = "" Then
                            sBatchInspStatus = "IN PROGRESS"
                        End If
                        If IsNothing(sBatchInspStatus) Or IsDBNull(sBatchInspStatus) Then
                            sBatchInspStatus = ""
                        End If
                        sBatchInspStatus = sBatchInspStatus.ToUpper.Trim
                        cmd.CommandText = strBatchStatusUpdt
                        cmd.Parameters.Add("@BatchInspStatus", SqlDbType.VarChar, 50)
                        cmd.Parameters("@BatchInspStatus").Direction = ParameterDirection.Input
                        cmd.Parameters("@BatchInspStatus").Value = sBatchInspStatus
                        recordsAffected = cmd.ExecuteNonQuery()
                    End If
                End If
                blnUpdated = recordsAffected > 0
            Catch exp As Exception
                blnUpdated = False
                Throw New Exception(exp.Message)
            Finally
                If blnUpdated Then
                    cmd.Transaction.Commit()
                Else
                    cmd.Transaction.Rollback()
                End If
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
            If blnUpdated Then
                AddSample = "Updated"
            Else
                AddSample = Nothing
            End If
        End Function
        Private Sub AppendParameters(ByRef cmd As SqlClient.SqlCommand)
            cmd.Parameters.Add("@sampleNumber", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@InspDate", SqlDbType.SmallDateTime, 4)
            cmd.Parameters.Add("@InspShift", SqlDbType.VarChar, 1)
            cmd.Parameters.Add("@Inspector", SqlDbType.VarChar, 6)
            cmd.Parameters.Add("@AxleInspStatus", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@InspRemarks", SqlDbType.VarChar, 5000)
            cmd.Parameters.Add("@Journal_TapHole_UTP", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Journal_Pitch_Circle_UTP", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Journal_Cone_Dia_UTP", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Journal_Centre_Type_UTP", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Journal_Dia_UTP", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Journal_Length_UTP", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Journal_Thread_Condition_UTP", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Journal_TapHole_UTO", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Journal_Pitch_Circle_UTO", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Journal_Cone_Dia_UTO", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Journal_Centre_Type_UTO", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Journal_Dia_UTO", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Journal_Length_UTO", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Journal_Thread_Condition_UTO", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Wheel_Seat_Dia_UTP", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Wheel_Seat_Length_UTP", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Wheel_Seat_Dia_UTO", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Wheel_Seat_Length_UTO", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@FullAxle", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@FullAxleLength", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@DustGuard_Dia_UTP", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@DustGuard_Dia_UTO", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@DustGuard_Length_UTO", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@DustGuard_Length_UTP", SqlDbType.VarChar, 50)

            cmd.Parameters.Add("@Body_dia", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Body_length", SqlDbType.VarChar, 50)

            cmd.Parameters.Add("@RwCodeFullAxle", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@RwCodeJournalUT", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@RwCodeDustGuardUT", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@RwCodeWhlSeatUT", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@RwCodeBody", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@RwCodeWhlSeatMPT", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@RwCodeDustGuardMPT", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@RwCodeJournalMPT", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@axleNumber", SqlDbType.VarChar, 50)
        End Sub
        Private Sub ParamDirection(ByRef cmd As SqlClient.SqlCommand)
            cmd.Parameters("@sampleNumber").Direction = ParameterDirection.Input
            cmd.Parameters("@InspDate").Direction = ParameterDirection.Input
            cmd.Parameters("@InspShift").Direction = ParameterDirection.Input
            cmd.Parameters("@Inspector").Direction = ParameterDirection.Input
            cmd.Parameters("@AxleInspStatus").Direction = ParameterDirection.Input
            cmd.Parameters("@Journal_TapHole_UTP").Direction = ParameterDirection.Input
            cmd.Parameters("@Journal_Pitch_Circle_UTP").Direction = ParameterDirection.Input
            cmd.Parameters("@Journal_Cone_Dia_UTP").Direction = ParameterDirection.Input
            cmd.Parameters("@Journal_Centre_Type_UTP").Direction = ParameterDirection.Input
            cmd.Parameters("@Journal_Dia_UTP").Direction = ParameterDirection.Input
            cmd.Parameters("@Journal_Length_UTP").Direction = ParameterDirection.Input
            cmd.Parameters("@Journal_Thread_Condition_UTP").Direction = ParameterDirection.Input
            cmd.Parameters("@Journal_TapHole_UTO").Direction = ParameterDirection.Input
            cmd.Parameters("@Journal_Pitch_Circle_UTO").Direction = ParameterDirection.Input
            cmd.Parameters("@Journal_Cone_Dia_UTO").Direction = ParameterDirection.Input
            cmd.Parameters("@Journal_Centre_Type_UTO").Direction = ParameterDirection.Input
            cmd.Parameters("@Journal_Dia_UTO").Direction = ParameterDirection.Input
            cmd.Parameters("@Journal_Length_UTO").Direction = ParameterDirection.Input
            cmd.Parameters("@Journal_Thread_Condition_UTO").Direction = ParameterDirection.Input
            cmd.Parameters("@Wheel_Seat_Dia_UTP").Direction = ParameterDirection.Input
            cmd.Parameters("@Wheel_Seat_Length_UTP").Direction = ParameterDirection.Input
            cmd.Parameters("@Wheel_Seat_Dia_UTO").Direction = ParameterDirection.Input
            cmd.Parameters("@Wheel_Seat_Length_UTO").Direction = ParameterDirection.Input
            cmd.Parameters("@FullAxle").Direction = ParameterDirection.Input
            cmd.Parameters("@FullAxleLength").Direction = ParameterDirection.Input
            cmd.Parameters("@DustGuard_Dia_UTP").Direction = ParameterDirection.Input
            cmd.Parameters("@DustGuard_Dia_UTO").Direction = ParameterDirection.Input
            cmd.Parameters("@DustGuard_Length_UTO").Direction = ParameterDirection.Input
            cmd.Parameters("@DustGuard_Length_UTP").Direction = ParameterDirection.Input

            cmd.Parameters("@Body_dia").Direction = ParameterDirection.Input
            cmd.Parameters("@Body_length").Direction = ParameterDirection.Input

            cmd.Parameters("@RwCodeFullAxle").Direction = ParameterDirection.Input
            cmd.Parameters("@RwCodeJournalUT").Direction = ParameterDirection.Input
            cmd.Parameters("@RwCodeDustGuardUT").Direction = ParameterDirection.Input
            cmd.Parameters("@RwCodeWhlSeatUT").Direction = ParameterDirection.Input
            cmd.Parameters("@RwCodeBody").Direction = ParameterDirection.Input
            cmd.Parameters("@RwCodeWhlSeatMPT").Direction = ParameterDirection.Input
            cmd.Parameters("@RwCodeDustGuardMPT").Direction = ParameterDirection.Input
            cmd.Parameters("@RwCodeJournalMPT").Direction = ParameterDirection.Input
            cmd.Parameters("@BatchNumber").Direction = ParameterDirection.Input
            cmd.Parameters("@axleNumber").Direction = ParameterDirection.Input
        End Sub
        Private Sub ParamAssignValues(ByRef cmd As SqlClient.SqlCommand, ByRef oSampleAxleObj As LooseAxleInspClass.SampleAxle, ByRef oBatchObj As LooseAxleInspClass.Batch, ByVal SampleNumber As Integer)
            Try
                cmd.Parameters("@sampleNumber").Value = SampleNumber
                cmd.Parameters("@InspDate").Value = InspDate
                cmd.Parameters("@InspShift").Value = InspShift
                cmd.Parameters("@Inspector").Value = InspEmpCode
                cmd.Parameters("@AxleInspStatus").Value = oSampleAxleObj.SampleAxleStatus
                cmd.Parameters("@InspRemarks").Value = oSampleAxleObj.Remarks
                cmd.Parameters("@Journal_TapHole_UTP").Value = oSampleAxleObj.UTTapHoleJournal
                cmd.Parameters("@Journal_Pitch_Circle_UTP").Value = oSampleAxleObj.UTPitchCircleDiaJournal
                cmd.Parameters("@Journal_Cone_Dia_UTP").Value = oSampleAxleObj.UTConeDiaJournal
                cmd.Parameters("@Journal_Centre_Type_UTP").Value = oSampleAxleObj.UTCentreTypeJournal
                cmd.Parameters("@Journal_Dia_UTP").Value = oSampleAxleObj.UTDiaJournal
                cmd.Parameters("@Journal_Length_UTP").Value = oSampleAxleObj.UTLengthJournal
                cmd.Parameters("@Journal_Thread_Condition_UTP").Value = oSampleAxleObj.UTThreadConditionJournal
                cmd.Parameters("@Journal_TapHole_UTO").Value = oSampleAxleObj.MPTTapHoleJournal
                cmd.Parameters("@Journal_Pitch_Circle_UTO").Value = oSampleAxleObj.MPTPitchCircleDiaJournal
                cmd.Parameters("@Journal_Cone_Dia_UTO").Value = oSampleAxleObj.MPTConeDiaJournal
                cmd.Parameters("@Journal_Centre_Type_UTO").Value = oSampleAxleObj.MPTCentreTypeJournal
                cmd.Parameters("@Journal_Dia_UTO").Value = oSampleAxleObj.MPTDiaJournal
                cmd.Parameters("@Journal_Length_UTO").Value = oSampleAxleObj.MPTLengthJournal
                cmd.Parameters("@Journal_Thread_Condition_UTO").Value = oSampleAxleObj.MPTThreadConditionJournal
                cmd.Parameters("@Wheel_Seat_Dia_UTP").Value = oSampleAxleObj.UTDiaWhlSeat
                cmd.Parameters("@Wheel_Seat_Length_UTP").Value = oSampleAxleObj.UTLengthWhlSeat
                cmd.Parameters("@Wheel_Seat_Dia_UTO").Value = oSampleAxleObj.MPTDiaWhlSeat
                cmd.Parameters("@Wheel_Seat_Length_UTO").Value = oSampleAxleObj.MPTLengthWhlSeat
                cmd.Parameters("@FullAxle").Value = oSampleAxleObj.FullAxleStatus
                cmd.Parameters("@FullAxleLength").Value = oSampleAxleObj.FullAxleLength
                cmd.Parameters("@DustGuard_Dia_UTP").Value = oSampleAxleObj.UTDiaDustGuard
                cmd.Parameters("@DustGuard_Dia_UTO").Value = oSampleAxleObj.MPTDiaDustGuard
                cmd.Parameters("@DustGuard_Length_UTO").Value = oSampleAxleObj.MPTLengthDustGuard
                cmd.Parameters("@DustGuard_Length_UTP").Value = oSampleAxleObj.UTLengthDustGuard

                cmd.Parameters("@Body_dia").Value = oSampleAxleObj.BodyDia
                cmd.Parameters("@Body_length").Value = oSampleAxleObj.BodyLength

                cmd.Parameters("@RwCodeFullAxle").Value = oSampleAxleObj.RwCodesForFullAxle
                cmd.Parameters("@RwCodeJournalUT").Value = oSampleAxleObj.UTRwCodesForJournal
                cmd.Parameters("@RwCodeDustGuardUT").Value = oSampleAxleObj.UTRwCodesForDustGuard
                cmd.Parameters("@RwCodeWhlSeatUT").Value = oSampleAxleObj.UTRwCodesForWhlSeat
                cmd.Parameters("@RwCodeBody").Value = oSampleAxleObj.RwCodesForBody
                cmd.Parameters("@RwCodeWhlSeatMPT").Value = oSampleAxleObj.MPTRwCodesForWhlSeat
                cmd.Parameters("@RwCodeDustGuardMPT").Value = oSampleAxleObj.MPTRwCodesForDustGuard
                cmd.Parameters("@RwCodeJournalMPT").Value = oSampleAxleObj.MPTRwCodesForJournal
                cmd.Parameters("@BatchNumber").Value = oBatchObj.BatchNumber
                cmd.Parameters("@axleNumber").Value = oSampleAxleObj.AxleNumber
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
            End Try
        End Sub
    End Class
    Public Class SampleAxle
#Region " tables"
        Public Shared Function GetLooseAxleDetails(ByVal Axle As String) As DataSet
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "select a.dc_number , b.dc_date from dm_fg_despatch_products a inner join dm_fg_despatch_rr b  " & _
                " on a.dc_number = b.dc_number where @Axle in ( product_no , axle_no ) ; " & _
                " select * FROM mm_rdso_offered_axles where axle_number = @Axle ; " & _
                " select AxleNumber , BatchNumber , BatchSerial , BatchQty , InspDate , InspShift , Inspector  " & _
                " FROM mm_loose_axle_inspection where axlenumber  = @Axle ; " & _
                " select * FROM mm_LooseAxle_New_InternalQAC_detail where Product_no  = @Axle ; " & _
                " select Axle_Number , product_code , cast_Number , castResult , drawing_number , Dc_Number , dc_date " & _
                " FROM mm_LooseAxle_New_InternalQAC_Reference where Axle_Number  = @Axle "
            da.SelectCommand.Parameters.Add("@Axle", SqlDbType.VarChar, 10).Value = Axle.Trim
            Dim ds As New DataSet()
            Try
                da.Fill(ds)
                GetLooseAxleDetails = ds.Copy
            Catch exp As Exception
                GetLooseAxleDetails = Nothing
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
#End Region
#Region " Fields"
        Private sAxleNumber, sAxleInspStatus As String
        Private sCastNumber, sDrawingNumber, sCastGroup, sCastResult, sUtStatus, sMPTStatus, sDcNumber, sWagNumber, sLabNumber As String
        Private sProductCode, sDescription, sSpecification As String
        Private dUtPassDate, dMPTDate, dDcDate As Date
        Private dInspDate As Date
        Private blnValidAxle As Boolean
        Private sBatchNumber As String
        Private iDaySerial As Integer
        Private sInspShift, sInspector As String
        Private sRemarks As String
        Private dsRewCodes As DataSet
        Private isampleNumber As Integer
        Private oInspection As LooseAxleInspClass.AxleInspection
        Private oLastInsp As LastInsp
        ' Full Axle  fields
        Private sFullAxleSts, sFullAxleLength, sRwCodesForFullAxle As String
        ' Ut side Journal fields
        Private sStsUTTapHoleJournal, sStsUTThreadConditionJournal, sStsUTPitchCircleDiaJournal, sStsUTConeDiaJournal, sStsUTCentreTypeJournal, _
                sStsUTDiaJournal, sStsUTLengthJournal, sUTRwCodesForJournal As String
        'MPT side Journal fields
        Private sStsMPTTapHoleJournal, sStsMPTThreadConditionJournal, sStsMPTPitchCircleDiaJournal, sStsMPTConeDiaJournal, sStsMPTCentreTypeJournal, _
                      sStsMPTDiaJournal, sStsMPTLengthJournal, sMPTRwCodesForJournal As String
        'UT side Wheel Seat fields
        Private sStsUTDiaWhlSeat, sStsUTLengthWhlSeat, sUTRwCodesForWhlSeat As String
        'MPT side Wheel Seat fields
        Private sStsMPTDiaWhlSeat, sStsMPTLengthWhlSeat, sMPTRwCodesForWhlSeat As String
        ' UT side Dust Guard fields
        Private sStsUTDiaDustGuard, sStsUTLengthDustGuard, sUTRwCodesForDustGuard As String
        ' MPT side Dust Guard fields
        Private sStsMPTDiaDustGuard, sStsMPTLengthDustGuard, sMPTRwCodesForDustGuard As String
        'Body side fields
        Private sStsBodyDia, sStsBodyLength, sRwCodesForBody As String

#End Region
#Region " Property"
        WriteOnly Property InspObj() As LooseAxleInspClass.AxleInspection
            Set(ByVal Value As LooseAxleInspClass.AxleInspection)
                oInspection = Value
            End Set
        End Property
        ReadOnly Property ProductCode() As String
            Get
                Return sProductCode
            End Get
        End Property
        ReadOnly Property ProdDesc() As String
            Get
                Return sDescription
            End Get
        End Property
        ReadOnly Property ProdSpecs() As String
            Get
                Return sSpecification
            End Get
        End Property
        Property AxleNumber() As String
            Get
                Return sAxleNumber
            End Get
            Set(ByVal Value As String)
                sAxleNumber = Value.ToUpper
                dsRewCodes = New DataSet()
                GetRewCodesForDDl()
                If ValidateAxle(AxleNumber) Then
                    blnValidAxle = True
                Else
                    blnValidAxle = False
                    sAxleNumber = ""
                    Throw New Exception("Axle " & AxleNumber & " Not Acceptable ")
                End If
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
        ReadOnly Property IsValid() As Boolean
            Get
                Return blnValidAxle
            End Get
        End Property
        ReadOnly Property PreStatus() As String
            Get
                Dim str As New System.Text.StringBuilder()
                str.Append("Drg No:" & sDrawingNumber & " ProdCd: " & sProductCode & " Desc:" & sDescription & " Specs:" & sSpecification)
                If sCastResult <> "" Then
                    str.Append("<BR>CastResult: " & sCastResult & "{Cast Grp: " & sCastGroup & " LabNo:" & sLabNumber & "}")
                End If
                If sUtStatus <> "" Then
                    str.Append("<BR>UT Result:" & sUtStatus & "{" & Left(dUtPassDate.Date.ToString, 10) & "}")
                End If
                If sMPTStatus <> "" Then
                    str.Append("<BR>MPT Result:" & sMPTStatus & "{" & Left(dMPTDate.Date.ToString, 10) & "}")
                End If
                If sBatchNumber <> "" Then
                    str.Append("<BR>Press Status : " & sBatchNumber & "/" & iDaySerial.ToString)
                End If
                If sDcNumber <> "" Then
                    str.Append("<BR>Dc Number:" & sDcNumber & " Dc_Date:" & Left(dDcDate.Date.ToString, 10) & " Wagon: " & sWagNumber)
                End If
                PreStatus = str.ToString
                str = Nothing
            End Get
        End Property
        ReadOnly Property LastInspStatus() As String
            Get
                Dim str As New System.Text.StringBuilder()
                If sAxleInspStatus <> "" Then
                    str.Append(sAxleInspStatus & "{" & Left(dInspDate.Date.ToString, 10) & ", Shift:" & sInspShift & "}")
                End If
                LastInspStatus = str.ToString
                str = Nothing
            End Get
        End Property
        ' full axle properties
        Property FullAxleStatus() As String
            Get
                Return sFullAxleSts
            End Get
            Set(ByVal Value As String)
                sFullAxleSts = Value
            End Set
        End Property
        Property FullAxleLength() As String
            Get
                Return sFullAxleLength
            End Get
            Set(ByVal Value As String)
                sFullAxleLength = Value
            End Set
        End Property
        Property RwCodesForFullAxle() As String
            Get
                Return sRwCodesForFullAxle
            End Get
            Set(ByVal Value As String)
                If Value = "Select" Then
                    Value = ""
                End If
                sRwCodesForFullAxle = Value
            End Set
        End Property
        ' ut side journal properties
        Property UTTapHoleJournal() As String
            Get
                Return sStsUTTapHoleJournal
            End Get
            Set(ByVal Value As String)
                sStsUTTapHoleJournal = Value.ToUpper
            End Set
        End Property
        Property UTThreadConditionJournal() As String
            Get
                Return sStsUTThreadConditionJournal
            End Get
            Set(ByVal Value As String)
                sStsUTThreadConditionJournal = Value.ToUpper
            End Set
        End Property
        Property UTPitchCircleDiaJournal() As String
            Get
                Return sStsUTPitchCircleDiaJournal
            End Get
            Set(ByVal Value As String)
                sStsUTPitchCircleDiaJournal = Value.ToUpper
            End Set
        End Property
        Property UTConeDiaJournal() As String
            Get
                Return sStsUTConeDiaJournal
            End Get
            Set(ByVal Value As String)
                sStsUTConeDiaJournal = Value.ToUpper
            End Set
        End Property
        Property UTCentreTypeJournal() As String
            Get
                Return sStsUTCentreTypeJournal
            End Get
            Set(ByVal Value As String)
                sStsUTCentreTypeJournal = Value.ToUpper
            End Set
        End Property
        Property UTDiaJournal() As String
            Get
                Return sStsUTDiaJournal
            End Get
            Set(ByVal Value As String)
                sStsUTDiaJournal = Value.ToUpper
            End Set
        End Property
        Property UTLengthJournal() As String
            Get
                Return sStsUTLengthJournal
            End Get
            Set(ByVal Value As String)
                sStsUTLengthJournal = Value.ToUpper
            End Set
        End Property
        Property UTRwCodesForJournal() As String
            Get
                Return sUTRwCodesForJournal
            End Get
            Set(ByVal Value As String)
                If Value = "Select" Then
                    Value = ""
                End If
                sUTRwCodesForJournal = Value.ToUpper
            End Set
        End Property
        ' MPT side Journal properties
        Property MPTTapHoleJournal() As String
            Get
                Return sStsMPTTapHoleJournal
            End Get
            Set(ByVal Value As String)
                sStsMPTTapHoleJournal = Value.ToUpper
            End Set
        End Property
        Property MPTThreadConditionJournal() As String
            Get
                Return sStsMPTThreadConditionJournal
            End Get
            Set(ByVal Value As String)
                sStsMPTThreadConditionJournal = Value.ToUpper
            End Set
        End Property
        Property MPTPitchCircleDiaJournal() As String
            Get
                Return sStsMPTPitchCircleDiaJournal
            End Get
            Set(ByVal Value As String)
                sStsMPTPitchCircleDiaJournal = Value.ToUpper
            End Set
        End Property
        Property MPTConeDiaJournal() As String
            Get
                Return sStsMPTConeDiaJournal
            End Get
            Set(ByVal Value As String)
                sStsMPTConeDiaJournal = Value.ToUpper
            End Set
        End Property
        Property MPTCentreTypeJournal() As String
            Get
                Return sStsMPTCentreTypeJournal
            End Get
            Set(ByVal Value As String)
                sStsMPTCentreTypeJournal = Value.ToUpper
            End Set
        End Property
        Property MPTDiaJournal() As String
            Get
                Return sStsMPTDiaJournal
            End Get
            Set(ByVal Value As String)
                sStsMPTDiaJournal = Value.ToUpper
            End Set
        End Property
        Property MPTLengthJournal() As String
            Get
                Return sStsMPTLengthJournal
            End Get
            Set(ByVal Value As String)
                sStsMPTLengthJournal = Value.ToUpper
            End Set
        End Property
        Property MPTRwCodesForJournal() As String
            Get
                Return sMPTRwCodesForJournal
            End Get
            Set(ByVal Value As String)
                If Value = "Select" Then
                    Value = ""
                End If
                sMPTRwCodesForJournal = Value.ToUpper
            End Set
        End Property
        ' UT Side Wheel Seat Properties
        Property UTDiaWhlSeat() As String
            Get
                Return sStsUTDiaWhlSeat
            End Get
            Set(ByVal Value As String)
                sStsUTDiaWhlSeat = Value.ToUpper
            End Set
        End Property
        Property UTLengthWhlSeat() As String
            Get
                Return sStsUTLengthWhlSeat
            End Get
            Set(ByVal Value As String)
                sStsUTLengthWhlSeat = Value.ToUpper
            End Set
        End Property
        Property UTRwCodesForWhlSeat() As String
            Get
                Return sUTRwCodesForWhlSeat
            End Get
            Set(ByVal Value As String)
                sUTRwCodesForWhlSeat = Value.ToUpper
            End Set
        End Property
        ' MPT Side Wheel Seat Properties
        Property MPTDiaWhlSeat() As String
            Get
                Return sStsMPTDiaWhlSeat
            End Get
            Set(ByVal Value As String)
                sStsMPTDiaWhlSeat = Value.ToUpper
            End Set
        End Property
        Property MPTLengthWhlSeat() As String
            Get
                Return sStsMPTLengthWhlSeat
            End Get
            Set(ByVal Value As String)
                sStsMPTLengthWhlSeat = Value.ToUpper
            End Set
        End Property
        Property MPTRwCodesForWhlSeat() As String
            Get
                Return sMPTRwCodesForWhlSeat
            End Get
            Set(ByVal Value As String)
                If Value = "Select" Then
                    Value = ""
                End If
                sMPTRwCodesForWhlSeat = Value.ToUpper
            End Set
        End Property
        ' UT side Dust Guard Properties
        Property UTDiaDustGuard() As String
            Get
                Return sStsUTDiaDustGuard
            End Get
            Set(ByVal Value As String)
                sStsUTDiaDustGuard = Value.ToUpper
            End Set
        End Property
        Property UTLengthDustGuard() As String
            Get
                Return sStsUTLengthDustGuard
            End Get
            Set(ByVal Value As String)
                sStsUTLengthDustGuard = Value.ToUpper
            End Set
        End Property
        Property UTRwCodesForDustGuard() As String
            Get
                Return sUTRwCodesForDustGuard
            End Get
            Set(ByVal Value As String)
                If Value = "Select" Then
                    Value = ""
                End If
                sUTRwCodesForDustGuard = Value.ToUpper
            End Set
        End Property
        ' MPT side Dust Guard Properties
        Property MPTDiaDustGuard() As String
            Get
                Return sStsMPTDiaDustGuard
            End Get
            Set(ByVal Value As String)
                sStsMPTDiaDustGuard = Value.ToUpper
            End Set
        End Property
        Property MPTLengthDustGuard() As String
            Get
                Return sStsMPTLengthDustGuard
            End Get
            Set(ByVal Value As String)
                sStsMPTLengthDustGuard = Value.ToUpper
            End Set
        End Property
        Property MPTRwCodesForDustGuard() As String
            Get
                Return sMPTRwCodesForDustGuard
            End Get
            Set(ByVal Value As String)
                If Value = "Select" Then
                    Value = ""
                End If
                sMPTRwCodesForDustGuard = Value.ToUpper
            End Set
        End Property
        ' Body side Properties
        Property BodyDia() As String
            Get
                Return sStsBodyDia
            End Get
            Set(ByVal Value As String)
                sStsBodyDia = Value.ToUpper
            End Set
        End Property
        Property BodyLength() As String
            Get
                Return sStsBodyLength
            End Get
            Set(ByVal Value As String)
                sStsBodyLength = Value.ToUpper
            End Set
        End Property
        Property RwCodesForBody() As String
            Get
                Return sRwCodesForBody
            End Get
            Set(ByVal Value As String)
                If Value = "Select" Then
                    Value = ""
                End If
                sRwCodesForBody = Value.ToUpper
            End Set
        End Property
        ReadOnly Property SampleAxleStatus() As String
            Get
                If (sFullAxleSts + sFullAxleLength + sStsUTTapHoleJournal + sStsUTThreadConditionJournal + sStsUTPitchCircleDiaJournal + sStsUTConeDiaJournal + sStsUTCentreTypeJournal + sStsUTDiaJournal + sStsUTLengthJournal + sStsMPTTapHoleJournal + sStsMPTThreadConditionJournal + sStsMPTPitchCircleDiaJournal + sStsMPTConeDiaJournal + sStsMPTCentreTypeJournal + sStsMPTDiaJournal + sStsMPTLengthJournal + sStsUTDiaWhlSeat + sStsUTLengthWhlSeat + sStsMPTDiaWhlSeat + sStsMPTLengthWhlSeat + sStsUTDiaDustGuard + sStsUTLengthDustGuard + sStsMPTDiaDustGuard + sStsMPTLengthDustGuard + sStsBodyDia + sStsBodyLength).IndexOf("W") >= 0 Then
                    SampleAxleStatus = "Hold".ToUpper
                Else
                    SampleAxleStatus = "Pass".ToUpper
                End If
            End Get
        End Property
#End Region
#Region " Methods"
        Public Sub New()
            ResetInspParams()
        End Sub
        Public Sub New(ByVal AxleNumber As String)
            sAxleNumber = AxleNumber.ToUpper
            GetRewCodesForDDl()
            ResetInspParams()
            If ValidateAxle(AxleNumber) Then
                blnValidAxle = True
            Else
                blnValidAxle = False
                Throw New Exception("Axle " & AxleNumber & " Not Acceptable ")
            End If
        End Sub
        Public Function GetAxleInspDetails() As LastInsp
            oLastInsp = New LastInsp()
            Dim cmd As SqlClient.SqlCommand = Connection.CmdObj
            cmd.CommandText = " Select top 1 @sampleNumber = isnull(sampleNumber,0), @InspDate = InspDate, @InspShift = InspShift, @Inspector = Inspector, @AxleInspStatus = AxleInspStatus, @InspRemarks = InspRemarks, @Journal_TapHole_UTP = Journal_TapHole_UTP, @Journal_Pitch_Circle_UTP = Journal_Pitch_Circle_UTP, @Journal_Cone_Dia_UTP = Journal_Cone_Dia_UTP, @Journal_Centre_Type_UTP = Journal_Centre_Type_UTP, @Journal_Dia_UTP = Journal_Dia_UTP, @Journal_Length_UTP = Journal_Length_UTP, @Journal_Thread_Condition_UTP = Journal_Thread_Condition_UTP, @Journal_TapHole_UTO = Journal_TapHole_UTO, @Journal_Pitch_Circle_UTO = Journal_Pitch_Circle_UTO, @Journal_Cone_Dia_UTO = Journal_Cone_Dia_UTO , @Journal_Centre_Type_UTO = Journal_Centre_Type_UTO , @Journal_Dia_UTO = Journal_Dia_UTO , @Journal_Length_UTO = Journal_Length_UTO , @Journal_Thread_Condition_UTO = Journal_Thread_Condition_UTO ," & _
                              " @Wheel_Seat_Dia_UTP = Wheel_Seat_Dia_UTP, @Wheel_Seat_Length_UTP = Wheel_Seat_Length_UTP, @Wheel_Seat_Dia_UTO = Wheel_Seat_Dia_UTO , @Wheel_Seat_Length_UTO = Wheel_Seat_Length_UTO, @Body_Dia = Body_Dia , @Body_Length = Body_Length, @FullAxle = FullAxle, @FullAxleLength = FullAxleLength, @DustGuard_Dia_UTP = DustGuard_Dia_UTP, @DustGuard_Dia_UTO = DustGuard_Dia_UTO, @DustGuard_Length_UTO = DustGuard_Length_UTO, @DustGuard_Length_UTP = DustGuard_Length_UTP, @RwCodeFullAxle = RwCodeFullAxle, @RwCodeJournalUT = RwCodeJournalUT, @RwCodeDustGuardUT = RwCodeDustGuardUT, @RwCodeWhlSeatUT = RwCodeWhlSeatUT, @RwCodeBody = RwCodeBody, @RwCodeWhlSeatMPT = RwCodeWhlSeatMPT, @RwCodeDustGuardMPT = RwCodeDustGuardMPT, @RwCodeJournalMPT = RwCodeJournalMPT, " & _
                              " @batchnumber = BatchNumber, @BatchSerial = BatchSerial from    mm_loose_axle_inspection where axlenumber = '" & sAxleNumber & "' order by slno desc "
            AppendParameters(cmd)
            ParamDirection(cmd)
            Dim blnFound As Boolean
            Try
                Dim i As Integer
                cmd.Connection.Open()
                i = cmd.ExecuteScalar()
                AssignValues(cmd, oLastInsp)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
            Return oLastInsp
        End Function
        Private Sub AssignValues(ByRef Cmd As SqlClient.SqlCommand, ByRef oLastInsp As LastInsp)
            oLastInsp.InspRemarks = IIf(IsDBNull(Cmd.Parameters("@InspRemarks").Value), "", Cmd.Parameters("@InspRemarks").Value)
            oLastInsp.AxleInspStatus = IIf(IsDBNull(Cmd.Parameters("@AxleInspStatus").Value), "", Cmd.Parameters("@AxleInspStatus").Value)
            oLastInsp.SampleNumber = IIf(IsDBNull(Cmd.Parameters("@sampleNumber").Value), 0, Cmd.Parameters("@sampleNumber").Value)
            oLastInsp.BatchNumber = IIf(IsDBNull(Cmd.Parameters("@batchnumber").Value), "", Cmd.Parameters("@batchnumber").Value)
            oLastInsp.BatchSerial = IIf(IsDBNull(Cmd.Parameters("@batchSerial").Value), 0, Cmd.Parameters("@batchSerial").Value)
            oLastInsp.BodyDia = IIf(IsDBNull(Cmd.Parameters("@Body_dia").Value), "OK", Cmd.Parameters("@Body_dia").Value)
            oLastInsp.BodyLength = IIf(IsDBNull(Cmd.Parameters("@Body_length").Value), "OK", Cmd.Parameters("@Body_length").Value)
            oLastInsp.FullAxleStatus = IIf(IsDBNull(Cmd.Parameters("@FullAxle").Value), "OK", Cmd.Parameters("@FullAxle").Value)
            oLastInsp.FullAxleLength = IIf(IsDBNull(Cmd.Parameters("@FullAxleLength").Value), "OK", Cmd.Parameters("@FullAxleLength").Value)
            oLastInsp.MPTCentreTypeJournal = IIf(IsDBNull(Cmd.Parameters("@Journal_Centre_Type_UTO").Value), "OK", Cmd.Parameters("@Journal_Centre_Type_UTO").Value)
            oLastInsp.MPTConeDiaJournal = IIf(IsDBNull(Cmd.Parameters("@Journal_Cone_Dia_UTO").Value), "OK", Cmd.Parameters("@Journal_Cone_Dia_UTO").Value)
            oLastInsp.MPTDiaDustGuard = IIf(IsDBNull(Cmd.Parameters("@DustGuard_Dia_UTO").Value), "OK", Cmd.Parameters("@DustGuard_Dia_UTO").Value)
            oLastInsp.MPTDiaJournal = IIf(IsDBNull(Cmd.Parameters("@Journal_Dia_UTO").Value), "OK", Cmd.Parameters("@Journal_Dia_UTO").Value)
            oLastInsp.MPTDiaWhlSeat = IIf(IsDBNull(Cmd.Parameters("@Wheel_Seat_Dia_UTO").Value), "OK", Cmd.Parameters("@Wheel_Seat_Dia_UTO").Value)
            oLastInsp.MPTLengthDustGuard = IIf(IsDBNull(Cmd.Parameters("@DustGuard_Length_UTO").Value), "OK", Cmd.Parameters("@DustGuard_Length_UTO").Value)
            oLastInsp.MPTLengthJournal = IIf(IsDBNull(Cmd.Parameters("@Journal_Length_UTO").Value), "OK", Cmd.Parameters("@Journal_Length_UTO").Value)
            oLastInsp.MPTLengthWhlSeat = IIf(IsDBNull(Cmd.Parameters("@Wheel_Seat_Length_UTO").Value), "OK", Cmd.Parameters("@Wheel_Seat_Length_UTO").Value)
            oLastInsp.MPTPitchCircleDiaJournal = IIf(IsDBNull(Cmd.Parameters("@Journal_Pitch_Circle_UTO").Value), "OK", Cmd.Parameters("@Journal_Pitch_Circle_UTO").Value)
            oLastInsp.MPTRwCodesForDustGuard = IIf(IsDBNull(Cmd.Parameters("@RwCodeDustGuardMPT").Value), "", Cmd.Parameters("@RwCodeDustGuardMPT").Value)
            oLastInsp.MPTRwCodesForJournal = IIf(IsDBNull(Cmd.Parameters("@RwCodeJournalMPT").Value), "", Cmd.Parameters("@RwCodeJournalMPT").Value)
            oLastInsp.MPTRwCodesForWhlSeat = IIf(IsDBNull(Cmd.Parameters("@RwCodeWhlSeatMPT").Value), "", Cmd.Parameters("@RwCodeWhlSeatMPT").Value)
            oLastInsp.MPTTapHoleJournal = IIf(IsDBNull(Cmd.Parameters("@Journal_TapHole_UTO").Value), "OK", Cmd.Parameters("@Journal_TapHole_UTO").Value)
            oLastInsp.MPTThreadConditionJournal = IIf(IsDBNull(Cmd.Parameters("@Journal_Thread_Condition_UTO").Value), "OK", Cmd.Parameters("@Journal_Thread_Condition_UTO").Value)
            oLastInsp.RwCodesForBody = IIf(IsDBNull(Cmd.Parameters("@RwCodeBody").Value), "", Cmd.Parameters("@RwCodeBody").Value)
            oLastInsp.RwCodesForFullAxle = IIf(IsDBNull(Cmd.Parameters("@RwCodeFullAxle").Value), "", Cmd.Parameters("@RwCodeFullAxle").Value)
            oLastInsp.UTCentreTypeJournal = IIf(IsDBNull(Cmd.Parameters("@Journal_Centre_Type_UTP").Value), "OK", Cmd.Parameters("@Journal_Centre_Type_UTP").Value)
            oLastInsp.UTConeDiaJournal = IIf(IsDBNull(Cmd.Parameters("@Journal_Cone_Dia_UTP").Value), "OK", Cmd.Parameters("@Journal_Cone_Dia_UTP").Value)
            oLastInsp.UTDiaDustGuard = IIf(IsDBNull(Cmd.Parameters("@DustGuard_Dia_UTP").Value), "OK", Cmd.Parameters("@DustGuard_Dia_UTP").Value)
            oLastInsp.UTDiaJournal = IIf(IsDBNull(Cmd.Parameters("@Journal_Dia_UTP").Value), "OK", Cmd.Parameters("@Journal_Dia_UTP").Value)
            oLastInsp.UTDiaWhlSeat = IIf(IsDBNull(Cmd.Parameters("@Wheel_Seat_Dia_UTP").Value), "OK", Cmd.Parameters("@Wheel_Seat_Dia_UTP").Value)
            oLastInsp.UTLengthDustGuard = IIf(IsDBNull(Cmd.Parameters("@DustGuard_Length_UTP").Value), "OK", Cmd.Parameters("@DustGuard_Length_UTP").Value)
            oLastInsp.UTLengthJournal = IIf(IsDBNull(Cmd.Parameters("@Journal_Length_UTP").Value), "OK", Cmd.Parameters("@Journal_Length_UTP").Value)
            oLastInsp.UTLengthWhlSeat = IIf(IsDBNull(Cmd.Parameters("@Wheel_Seat_Length_UTP").Value), "OK", Cmd.Parameters("@Wheel_Seat_Length_UTP").Value)
            oLastInsp.UTPitchCircleDiaJournal = IIf(IsDBNull(Cmd.Parameters("@Journal_Pitch_Circle_UTP").Value), "OK", Cmd.Parameters("@Journal_Pitch_Circle_UTP").Value)
            oLastInsp.UTRwCodesForDustGuard = IIf(IsDBNull(Cmd.Parameters("@RwCodeDustGuardUT").Value), "", Cmd.Parameters("@RwCodeDustGuardUT").Value)
            oLastInsp.UTRwCodesForJournal = IIf(IsDBNull(Cmd.Parameters("@RwCodeJournalUT").Value), "", Cmd.Parameters("@RwCodeJournalUT").Value)
            oLastInsp.UTRwCodesForWhlSeat = IIf(IsDBNull(Cmd.Parameters("@RwCodeWhlSeatUT").Value), "", Cmd.Parameters("@RwCodeWhlSeatUT").Value)
            oLastInsp.UTTapHoleJournal = IIf(IsDBNull(Cmd.Parameters("@Journal_TapHole_UTP").Value), "OK", Cmd.Parameters("@Journal_TapHole_UTP").Value)
            oLastInsp.UTThreadConditionJournal = IIf(IsDBNull(Cmd.Parameters("@Journal_Thread_Condition_UTP").Value), "OK", Cmd.Parameters("@Journal_Thread_Condition_UTP").Value)
        End Sub
        Private Sub AppendParameters(ByRef cmd As SqlClient.SqlCommand)
            cmd.Parameters.Add("@sampleNumber", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@InspDate", SqlDbType.SmallDateTime, 4)
            cmd.Parameters.Add("@InspShift", SqlDbType.VarChar, 1)
            cmd.Parameters.Add("@Inspector", SqlDbType.VarChar, 6)


            cmd.Parameters.Add("@AxleInspStatus", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@InspRemarks", SqlDbType.VarChar, 5000)
            cmd.Parameters.Add("@Journal_TapHole_UTP", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Journal_Pitch_Circle_UTP", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Journal_Cone_Dia_UTP", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Journal_Centre_Type_UTP", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Journal_Dia_UTP", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Journal_Length_UTP", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Journal_Thread_Condition_UTP", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Journal_TapHole_UTO", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Journal_Pitch_Circle_UTO", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Journal_Cone_Dia_UTO", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Journal_Centre_Type_UTO", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Journal_Dia_UTO", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Journal_Length_UTO", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Journal_Thread_Condition_UTO", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Wheel_Seat_Dia_UTP", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Wheel_Seat_Length_UTP", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Wheel_Seat_Dia_UTO", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Wheel_Seat_Length_UTO", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@FullAxle", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@FullAxleLength", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@DustGuard_Dia_UTP", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@DustGuard_Dia_UTO", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@DustGuard_Length_UTO", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@DustGuard_Length_UTP", SqlDbType.VarChar, 50)

            cmd.Parameters.Add("@Body_dia", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Body_length", SqlDbType.VarChar, 50)

            cmd.Parameters.Add("@RwCodeFullAxle", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@RwCodeJournalUT", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@RwCodeDustGuardUT", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@RwCodeWhlSeatUT", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@RwCodeBody", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@RwCodeWhlSeatMPT", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@RwCodeDustGuardMPT", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@RwCodeJournalMPT", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@batchnumber", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@batchSerial", SqlDbType.Int, 4)


        End Sub
        Private Sub ParamDirection(ByRef cmd As SqlClient.SqlCommand)
            cmd.Parameters("@sampleNumber").Direction = ParameterDirection.Output
            cmd.Parameters("@InspDate").Direction = ParameterDirection.Output
            cmd.Parameters("@InspShift").Direction = ParameterDirection.Output
            cmd.Parameters("@Inspector").Direction = ParameterDirection.Output
            cmd.Parameters("@AxleInspStatus").Direction = ParameterDirection.Output
            cmd.Parameters("@Journal_TapHole_UTP").Direction = ParameterDirection.Output
            cmd.Parameters("@Journal_Pitch_Circle_UTP").Direction = ParameterDirection.Output
            cmd.Parameters("@Journal_Cone_Dia_UTP").Direction = ParameterDirection.Output
            cmd.Parameters("@Journal_Centre_Type_UTP").Direction = ParameterDirection.Output
            cmd.Parameters("@Journal_Dia_UTP").Direction = ParameterDirection.Output
            cmd.Parameters("@Journal_Length_UTP").Direction = ParameterDirection.Output
            cmd.Parameters("@Journal_Thread_Condition_UTP").Direction = ParameterDirection.Output
            cmd.Parameters("@Journal_TapHole_UTO").Direction = ParameterDirection.Output
            cmd.Parameters("@Journal_Pitch_Circle_UTO").Direction = ParameterDirection.Output
            cmd.Parameters("@Journal_Cone_Dia_UTO").Direction = ParameterDirection.Output
            cmd.Parameters("@Journal_Centre_Type_UTO").Direction = ParameterDirection.Output
            cmd.Parameters("@Journal_Dia_UTO").Direction = ParameterDirection.Output
            cmd.Parameters("@Journal_Length_UTO").Direction = ParameterDirection.Output
            cmd.Parameters("@Journal_Thread_Condition_UTO").Direction = ParameterDirection.Output
            cmd.Parameters("@Wheel_Seat_Dia_UTP").Direction = ParameterDirection.Output
            cmd.Parameters("@Wheel_Seat_Length_UTP").Direction = ParameterDirection.Output
            cmd.Parameters("@Wheel_Seat_Dia_UTO").Direction = ParameterDirection.Output
            cmd.Parameters("@Wheel_Seat_Length_UTO").Direction = ParameterDirection.Output
            cmd.Parameters("@FullAxle").Direction = ParameterDirection.Output
            cmd.Parameters("@FullAxleLength").Direction = ParameterDirection.Output
            cmd.Parameters("@DustGuard_Dia_UTP").Direction = ParameterDirection.Output
            cmd.Parameters("@DustGuard_Dia_UTO").Direction = ParameterDirection.Output
            cmd.Parameters("@DustGuard_Length_UTO").Direction = ParameterDirection.Output
            cmd.Parameters("@DustGuard_Length_UTP").Direction = ParameterDirection.Output

            cmd.Parameters("@Body_dia").Direction = ParameterDirection.Output
            cmd.Parameters("@Body_length").Direction = ParameterDirection.Output

            cmd.Parameters("@RwCodeFullAxle").Direction = ParameterDirection.Output
            cmd.Parameters("@RwCodeJournalUT").Direction = ParameterDirection.Output
            cmd.Parameters("@RwCodeDustGuardUT").Direction = ParameterDirection.Output
            cmd.Parameters("@RwCodeWhlSeatUT").Direction = ParameterDirection.Output
            cmd.Parameters("@RwCodeBody").Direction = ParameterDirection.Output
            cmd.Parameters("@RwCodeWhlSeatMPT").Direction = ParameterDirection.Output
            cmd.Parameters("@RwCodeDustGuardMPT").Direction = ParameterDirection.Output
            cmd.Parameters("@RwCodeJournalMPT").Direction = ParameterDirection.Output
            cmd.Parameters("@batchnumber").Direction = ParameterDirection.Output
            cmd.Parameters("@batchSerial").Direction = ParameterDirection.Output
            cmd.Parameters("@AxleInspStatus").Direction = ParameterDirection.Output
            cmd.Parameters("@InspRemarks").Direction = ParameterDirection.Output
        End Sub
        Public Function GetSampleNumber(ByRef oBatchObj As LooseAxleInspClass.Batch) As Integer
            Dim cmd As SqlClient.SqlCommand = Connection.CmdObj
            cmd.CommandText = "select isnull(sampleNumber,'0') from mm_loose_axle_inspection where batchnumber = '" & oBatchObj.BatchNumber & "' and axleNumber = '" & sAxleNumber & "'"
            Try
                cmd.Connection.Open()
                GetSampleNumber = cmd.ExecuteScalar()
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        ' area-wise rew code tables
        Public Function UTsideJournalRewCodes() As DataTable
            Return dsRewCodes.Tables("JournalUT")
        End Function
        Public Function UTsideDustGuardRewCodes() As DataTable
            Return dsRewCodes.Tables("DustGuardUT")
        End Function
        Public Function UTsideWhlSeatRewCodes() As DataTable
            Return dsRewCodes.Tables("WhlSeatUT")
        End Function
        Public Function MPTsideJournalRewCodes() As DataTable
            Return dsRewCodes.Tables("JournalMPT")
        End Function
        Public Function MPTsideDustGuardRewCodes() As DataTable
            Return dsRewCodes.Tables("DustGuardMPT")
        End Function
        Public Function MPTsideWhlSeatRewCodes() As DataTable
            Return dsRewCodes.Tables("WhlSeatMPT")
        End Function
        Public Function BodyRewCodes() As DataTable
            Return dsRewCodes.Tables("Body")
        End Function
        Public Function FullAxleRewCodes() As DataTable
            Return dsRewCodes.Tables("FullAxle")
        End Function
        ' private methods
        ' Reset fields
        Private Sub ResetInspParams()
            ' full axle fields
            sRemarks = ""
            sFullAxleSts = "OK"
            sFullAxleLength = "OK"
            sRwCodesForFullAxle = ""
            ' UT journal fields
            sStsUTTapHoleJournal = "OK"
            sStsUTThreadConditionJournal = "OK"
            sStsUTPitchCircleDiaJournal = "OK"
            sStsUTConeDiaJournal = "OK"
            sStsUTCentreTypeJournal = "OK"
            sStsUTDiaJournal = "OK"
            sStsUTLengthJournal = "OK"
            sUTRwCodesForJournal = ""
            ' MPT journal fields
            sStsMPTTapHoleJournal = "OK"
            sStsMPTThreadConditionJournal = "OK"
            sStsMPTPitchCircleDiaJournal = "OK"
            sStsMPTConeDiaJournal = "OK"
            sStsMPTCentreTypeJournal = "OK"
            sStsMPTDiaJournal = "OK"
            sStsMPTLengthJournal = "OK"
            sMPTRwCodesForJournal = ""
            ' UT side Whl Seat fields
            sStsUTDiaWhlSeat = "OK"
            sStsUTLengthWhlSeat = "OK"
            sUTRwCodesForWhlSeat = ""
            ' MPT side Whl Seat fields
            sStsMPTDiaWhlSeat = "OK"
            sStsMPTLengthWhlSeat = "OK"
            sMPTRwCodesForWhlSeat = ""
            ' UT side Dust Guard fields
            sStsUTDiaDustGuard = "OK"
            sStsUTLengthDustGuard = "OK"
            sUTRwCodesForDustGuard = ""
            ' MPT side Dust Guard fields
            sStsMPTDiaDustGuard = "OK"
            sStsMPTLengthDustGuard = "OK"
            sMPTRwCodesForDustGuard = ""
            ' Body side fields
            sStsBodyDia = "OK"
            sStsBodyLength = "OK"
            sRwCodesForBody = ""
        End Sub
        ' rew code list
        Private Sub GetReworkcodes(ByRef ds As DataSet, ByVal TableName As String)
            Dim da As SqlClient.SqlDataAdapter = Connection.Adapter

            Select Case TableName
                Case "FullAxle"
                    da.SelectCommand.CommandText = "select rej_Desc, rej_code from mm_LooseAxle_RejCodes where area like '%Full Axle%'"
                Case "JournalUT", "JournalMPT"
                    da.SelectCommand.CommandText = "select rej_Desc, rej_code from mm_LooseAxle_RejCodes where area like '%Journal%'"
                Case "DustGuardUT", "DustGuardMPT"
                    da.SelectCommand.CommandText = "select rej_Desc, rej_code from mm_LooseAxle_RejCodes where area like '%Dust Guard%'"
                Case "WhlSeatUT", "WhlSeatMPT"
                    da.SelectCommand.CommandText = "select rej_Desc, rej_code from mm_LooseAxle_RejCodes where area like '%Wheel Seat%'"
                Case "Body"
                    da.SelectCommand.CommandText = "select rej_Desc, rej_code from mm_LooseAxle_RejCodes where area like '%Body%'"
                Case Else
                    da.SelectCommand.CommandText = ""
            End Select
            Try
                da.Fill(ds, TableName)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
            End Try
            ' GetReworkcodes = ds.Tables(TableName)
        End Sub
        Private Sub GetRewCodesForDDl()
            dsRewCodes = New DataSet()
            GetReworkcodes(dsRewCodes, "FullAxle")
            GetReworkcodes(dsRewCodes, "JournalUT")
            GetReworkcodes(dsRewCodes, "DustGuardUT")
            GetReworkcodes(dsRewCodes, "WhlSeatUT")

            GetReworkcodes(dsRewCodes, "JournalMPT")
            GetReworkcodes(dsRewCodes, "DustGuardMPT")
            GetReworkcodes(dsRewCodes, "WhlSeatMPT")
            GetReworkcodes(dsRewCodes, "Body")
        End Sub
        Private Function ValidateAxle(ByVal AxleNumber As String)
            Dim cmd As SqlClient.SqlCommand = Connection.CmdObj
            cmd.CommandText = "mm_sp_si_LooseAxle_PreStatus"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Ax", SqlDbType.VarChar, 50)
            cmd.Parameters("@Ax").Direction = ParameterDirection.Input
            cmd.Parameters("@Ax").Value = AxleNumber
            Dim dr As SqlClient.SqlDataReader
            Try
                cmd.Connection.Open()
                dr = cmd.ExecuteReader()
                If dr.Read Then
                    sCastNumber = IIf(IsDBNull(dr("Cast_number")), "", dr("Cast_number"))
                    sDrawingNumber = IIf(IsDBNull(dr("drawing_Number")), "", dr("drawing_Number"))
                    sCastGroup = IIf(IsDBNull(dr("Cast_Group")), "", dr("Cast_Group"))
                    sCastResult = IIf(IsDBNull(dr("CastTestResult")), "", dr("CastTestResult"))
                    sUtStatus = IIf(IsDBNull(dr("Ut_Status")), "", dr("Ut_Status"))
                    dUtPassDate = IIf(IsDBNull(dr("ut_Date")), #1/1/1900#, dr("ut_Date"))
                    sMPTStatus = IIf(IsDBNull(dr("Mpt_Status")), "", dr("Mpt_Status"))
                    dMPTDate = IIf(IsDBNull(dr("Mpt_Date")), #1/1/1900#, dr("Mpt_Date"))
                    sDcNumber = IIf(IsDBNull(dr("dc_Number")), "", dr("dc_Number"))
                    sWagNumber = IIf(IsDBNull(dr("WagLorry_number")), "", dr("WagLorry_number"))
                    sLabNumber = IIf(IsDBNull(dr("Lab_Number")), "", dr("Lab_Number"))
                    dDcDate = IIf(IsDBNull(dr("Dc_Date")), #1/1/1900#, dr("Dc_Date"))
                    sBatchNumber = IIf(IsDBNull(dr("Batch_number")), "", dr("Batch_number"))
                    iDaySerial = IIf(IsDBNull(dr("Day_serial")), 0, dr("Day_serial"))
                    sDescription = IIf(IsDBNull(dr("Description")), "", dr("Description"))
                    sSpecification = IIf(IsDBNull(dr("Specification")), "", dr("Specification"))
                    sProductCode = IIf(IsDBNull(dr("Product_code")), "", dr("Product_code"))
                End If
                dr.Close()
                cmd.CommandText = "mm_sp_si_LooseAxle_InspStatus"
                dr = cmd.ExecuteReader
                If dr.Read Then
                    sAxleInspStatus = IIf(IsDBNull(dr("AxleInspStatus")), "", dr("AxleInspStatus"))
                    dInspDate = IIf(IsDBNull(dr("InspDate")), #1/1/1900#, dr("InspDate"))
                    sInspShift = IIf(IsDBNull(dr("InspShift")), "", dr("InspShift"))
                End If
                dr.Close()
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If IsNothing(dr) = False Then
                    dr.Close()
                End If
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
            blnValidAxle = True
            If sUtStatus <> "P" Then
                blnValidAxle = False
                Throw New Exception("Axle UT Not Passed")
            End If
            If sCastResult <> "P" Then
                blnValidAxle = False
                Throw New Exception("Axle Cast Test Not Passed")
            End If
            Return blnValidAxle
        End Function
        Public Function Save(ByRef oSampleAxleObj As LooseAxleInspClass.SampleAxle, ByRef oBatchObj As LooseAxleInspClass.Batch) As String
            If Not blnValidAxle Then
                Throw New Exception("Invalid Axle. Cannot be saved as sample.")
            End If
            If sAxleNumber = "" Then
                Throw New Exception("Empty Axle Number. Cannot be saved as sample.")
            End If
            ' check W and Rw code are given 
            If (sFullAxleSts + sFullAxleLength).IndexOf("W") >= 0 Then
                If (sRwCodesForFullAxle <> "Select" And sRwCodesForFullAxle <> "") = False Then
                    Throw New Exception("Rw code not selected for Full Axle")
                End If
            ElseIf (sStsUTTapHoleJournal + sStsUTThreadConditionJournal + sStsUTPitchCircleDiaJournal + sStsUTConeDiaJournal + sStsUTCentreTypeJournal + sStsUTDiaJournal + sStsUTLengthJournal).IndexOf("W") >= 0 Then
                If (sUTRwCodesForJournal <> "Select" And sUTRwCodesForJournal <> "") = False Then
                    Throw New Exception("Rw code not selected for UT side Journal")
                End If
            ElseIf (sStsMPTTapHoleJournal + sStsMPTThreadConditionJournal + sStsMPTPitchCircleDiaJournal + sStsMPTConeDiaJournal + sStsMPTCentreTypeJournal + sStsMPTDiaJournal + sStsMPTLengthJournal).IndexOf("W") >= 0 Then
                If (sMPTRwCodesForJournal <> "Select" And sMPTRwCodesForJournal <> "") = False Then
                    Throw New Exception("Rw code not selected for MPT side Journal")
                End If
            ElseIf (sStsUTDiaWhlSeat + sStsUTLengthWhlSeat).IndexOf("W") >= 0 Then
                If (sUTRwCodesForWhlSeat <> "Select" And sUTRwCodesForWhlSeat <> "") = False Then
                    Throw New Exception("Rw code not selected for UT side Wheel Seat")
                End If
            ElseIf (sStsMPTDiaWhlSeat + sStsMPTLengthWhlSeat).IndexOf("W") >= 0 Then
                If (sMPTRwCodesForWhlSeat <> "Select" And sMPTRwCodesForWhlSeat <> "") = False Then
                    Throw New Exception("Rw code not selected for MPT side Wheel Seat")
                End If
            ElseIf (sStsUTDiaDustGuard + sStsUTLengthDustGuard).IndexOf("W") >= 0 Then
                If (sUTRwCodesForDustGuard <> "Select" And sUTRwCodesForDustGuard <> "") = False Then
                    Throw New Exception("Rw code not selected for UT side Dust Guard")
                End If
            ElseIf (sStsMPTDiaDustGuard + sStsMPTLengthDustGuard).IndexOf("W") >= 0 Then
                If (sMPTRwCodesForDustGuard <> "Select" And sMPTRwCodesForDustGuard <> "") = False Then
                    Throw New Exception("Rw code not selected for MPT side Dust Guard")
                End If
            ElseIf (sStsBodyDia + sStsBodyLength).IndexOf("W") >= 0 Then
                If (sRwCodesForBody <> "Select" And sRwCodesForBody <> "") = False Then
                    Throw New Exception("Rw code not selected for Body side")
                End If
            End If

            ' if rw code is selected and param sts is not W
            ' check W and Rw code are given 

            If (sRwCodesForFullAxle <> "Select" And sRwCodesForFullAxle <> "") Then
                If (sFullAxleSts + sFullAxleLength).IndexOf("W") < 0 Then
                    Throw New Exception("Rw code not supported by W for any Insp Param of Full Axle")
                End If
            ElseIf (sUTRwCodesForJournal <> "Select" And sUTRwCodesForJournal <> "") Then
                If (sStsUTTapHoleJournal + sStsUTThreadConditionJournal + sStsUTPitchCircleDiaJournal + sStsUTConeDiaJournal + sStsUTCentreTypeJournal + sStsUTDiaJournal + sStsUTLengthJournal).IndexOf("W") < 0 Then
                    Throw New Exception("RRw code not supported by W for any Insp Param of  UT side Journal")
                End If
            ElseIf (sMPTRwCodesForJournal <> "Select" And sMPTRwCodesForJournal <> "") Then
                If (sStsMPTTapHoleJournal + sStsMPTThreadConditionJournal + sStsMPTPitchCircleDiaJournal + sStsMPTConeDiaJournal + sStsMPTCentreTypeJournal + sStsMPTDiaJournal + sStsMPTLengthJournal).IndexOf("W") < 0 Then
                    Throw New Exception("Rw code not supported by W for any Insp Param of  MPT side Journal")
                End If
            ElseIf (sUTRwCodesForWhlSeat <> "Select" And sUTRwCodesForWhlSeat <> "") Then
                If (sStsUTDiaWhlSeat + sStsUTLengthWhlSeat).IndexOf("W") < 0 Then
                    Throw New Exception("Rw code not supported by W for any Insp Param of  UT side Wheel Seat")
                End If
            ElseIf (sMPTRwCodesForWhlSeat <> "Select" And sMPTRwCodesForWhlSeat <> "") Then
                If (sStsMPTDiaWhlSeat + sStsMPTLengthWhlSeat).IndexOf("W") < 0 Then
                    Throw New Exception("Rw code not supported by W for any Insp Param of  MPT side Wheel Seat")
                End If
            ElseIf (sUTRwCodesForDustGuard <> "Select" And sUTRwCodesForDustGuard <> "") Then
                If (sStsUTDiaDustGuard + sStsUTLengthDustGuard).IndexOf("W") < 0 Then
                    Throw New Exception("Rw code not supported by W for any Insp Param of  UT side Dust Guard")
                End If
            ElseIf (sMPTRwCodesForDustGuard <> "Select" And sMPTRwCodesForDustGuard <> "") Then
                If (sStsMPTDiaDustGuard + sStsMPTLengthDustGuard).IndexOf("W") < 0 Then
                    Throw New Exception("Rw code not supported by W for any Insp Param of  MPT side Dust Guard")
                End If
            ElseIf (sRwCodesForBody <> "Select" And sRwCodesForBody <> "") Then
                If (sStsBodyDia + sStsBodyLength).IndexOf("W") < 0 Then
                    Throw New Exception("Rw code not supported by W for any Insp Param of  Body side")
                End If
            End If
            If IsNothing(oInspection) Then
                Throw New Exception("Inspection Object not created")
            End If
            If IsNothing(oInspection.InspDate) Then
                Throw New Exception("Inspection Date unavailable")
            End If
            If IsNothing(oInspection.InspShift) Then
                Throw New Exception("Inspection Shift unavailable")
            End If
            If IsNothing(oInspection.InspEmpCode) Then
                Throw New Exception("Inspector Employee code unavailable")
            End If

            If Not oInspection.InspDate > CDate("1/1/1900") Then
                Throw New Exception("Inspection Date unavailable")
            End If
            If Not oInspection.InspShift <> "" Then
                Throw New Exception("Inspection Shift unavailable")
            End If
            If Not oInspection.InspEmpCode <> "" Then
                Throw New Exception("Inspector Employee code unavailable")
            End If
            Try
                Save = oInspection.AddSample(oSampleAxleObj, oBatchObj)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
            End Try
        End Function
        Public Shared Function DeleteLooseAxle(ByVal Axle As String, ByVal User As String) As String
            Dim cmd As SqlClient.SqlCommand = Connection.CmdObj
            cmd.CommandText = "mm_sp_DeleteLooseAxle"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Axle", SqlDbType.VarChar, 10).Value = Axle.Trim
            cmd.Parameters.Add("@DeletedBy", SqlDbType.VarChar, 10).Value = User.Trim
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            Try
                cmd.Connection.Open()
                cmd.ExecuteNonQuery()
                DeleteLooseAxle = IIf(IsDBNull(cmd.Parameters("@Remarks").Value), "", cmd.Parameters("@Remarks").Value)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Class LastInsp
            Private sInspRemarks As String
            Private sAxleInspStatus As String
            Private iSampleNumber As Integer
            Private dInspDate As Date
            Private sBatchNumber As String
            Private iBatchSerial As Integer
            Private sInspShift, sInspector As String
            Private sRemarks As String

            ' Full Axle  fields
            Private sFullAxleSts, sFullAxleLength, sRwCodesForFullAxle As String

            ' Ut side Journal fields
            Private sStsUTTapHoleJournal, sStsUTThreadConditionJournal, sStsUTPitchCircleDiaJournal, sStsUTConeDiaJournal, sStsUTCentreTypeJournal, _
                    sStsUTDiaJournal, sStsUTLengthJournal, sUTRwCodesForJournal As String

            'MPT side Journal fields
            Private sStsMPTTapHoleJournal, sStsMPTThreadConditionJournal, sStsMPTPitchCircleDiaJournal, sStsMPTConeDiaJournal, sStsMPTCentreTypeJournal, _
                           sStsMPTDiaJournal, sStsMPTLengthJournal, sMPTRwCodesForJournal As String

            'UT side Wheel Seat fields
            Private sStsUTDiaWhlSeat, sStsUTLengthWhlSeat, sUTRwCodesForWhlSeat As String
            'MPT side Wheel Seat fields
            Private sStsMPTDiaWhlSeat, sStsMPTLengthWhlSeat, sMPTRwCodesForWhlSeat As String
            ' UT side Dust Guard fields
            Private sStsUTDiaDustGuard, sStsUTLengthDustGuard, sUTRwCodesForDustGuard As String
            ' MPT side Dust Guard fields
            Private sStsMPTDiaDustGuard, sStsMPTLengthDustGuard, sMPTRwCodesForDustGuard As String
            'Body side fields
            Private sStsBodyDia, sStsBodyLength, sRwCodesForBody As String

            Property InspRemarks() As String
                Get
                    Return sInspRemarks
                End Get
                Set(ByVal Value As String)
                    sInspRemarks = Value
                End Set
            End Property
            Property AxleInspStatus() As String
                Get
                    Return sAxleInspStatus
                End Get
                Set(ByVal Value As String)
                    sAxleInspStatus = Value
                End Set
            End Property
            Property SampleNumber() As Integer
                Get
                    Return iSampleNumber
                End Get
                Set(ByVal Value As Integer)
                    iSampleNumber = Value
                End Set
            End Property
            Property InspDate() As Date
                Get
                    Return dInspDate
                End Get
                Set(ByVal Value As Date)
                    dInspDate = Value
                End Set
            End Property
            Property InspShift() As String
                Get
                    Return sInspShift
                End Get
                Set(ByVal Value As String)
                    sInspShift = Value
                End Set
            End Property
            Property Inspector() As String
                Get
                    Return sInspector
                End Get
                Set(ByVal Value As String)
                    sInspector = Value
                End Set
            End Property
            Property BatchNumber() As String
                Get
                    Return sBatchNumber
                End Get
                Set(ByVal Value As String)
                    sBatchNumber = Value
                End Set
            End Property
            Property BatchSerial() As Integer
                Get
                    Return iBatchSerial
                End Get
                Set(ByVal Value As Integer)
                    iBatchSerial = Value
                End Set
            End Property
            ' full axle properties
            Property FullAxleStatus() As String
                Get
                    Return sFullAxleSts
                End Get
                Set(ByVal Value As String)
                    sFullAxleSts = Value
                End Set
            End Property
            Property FullAxleLength() As String
                Get
                    Return sFullAxleLength
                End Get
                Set(ByVal Value As String)
                    sFullAxleLength = Value
                End Set
            End Property
            Property RwCodesForFullAxle() As String
                Get
                    Return sRwCodesForFullAxle
                End Get
                Set(ByVal Value As String)
                    If Value = "Select" Then
                        Value = ""
                    End If
                    sRwCodesForFullAxle = Value
                End Set
            End Property

            ' ut side journal properties
            Property UTTapHoleJournal() As String
                Get
                    Return sStsUTTapHoleJournal
                End Get
                Set(ByVal Value As String)
                    sStsUTTapHoleJournal = Value.ToUpper
                End Set
            End Property
            Property UTThreadConditionJournal() As String
                Get
                    Return sStsUTThreadConditionJournal
                End Get
                Set(ByVal Value As String)
                    sStsUTThreadConditionJournal = Value.ToUpper
                End Set
            End Property
            Property UTPitchCircleDiaJournal() As String
                Get
                    Return sStsUTPitchCircleDiaJournal
                End Get
                Set(ByVal Value As String)
                    sStsUTPitchCircleDiaJournal = Value.ToUpper
                End Set
            End Property
            Property UTConeDiaJournal() As String
                Get
                    Return sStsUTConeDiaJournal
                End Get
                Set(ByVal Value As String)
                    sStsUTConeDiaJournal = Value.ToUpper
                End Set
            End Property
            Property UTCentreTypeJournal() As String
                Get
                    Return sStsUTCentreTypeJournal
                End Get
                Set(ByVal Value As String)
                    sStsUTCentreTypeJournal = Value.ToUpper
                End Set
            End Property
            Property UTDiaJournal() As String
                Get
                    Return sStsUTDiaJournal
                End Get
                Set(ByVal Value As String)
                    sStsUTDiaJournal = Value.ToUpper
                End Set
            End Property
            Property UTLengthJournal() As String
                Get
                    Return sStsUTLengthJournal
                End Get
                Set(ByVal Value As String)
                    sStsUTLengthJournal = Value.ToUpper
                End Set
            End Property
            Property UTRwCodesForJournal() As String
                Get
                    Return sUTRwCodesForJournal
                End Get
                Set(ByVal Value As String)
                    If Value = "Select" Then
                        Value = ""
                    End If
                    sUTRwCodesForJournal = Value.ToUpper
                End Set
            End Property

            ' MPT side Journal properties
            Property MPTTapHoleJournal() As String
                Get
                    Return sStsMPTTapHoleJournal
                End Get
                Set(ByVal Value As String)
                    sStsMPTTapHoleJournal = Value.ToUpper
                End Set
            End Property
            Property MPTThreadConditionJournal() As String
                Get
                    Return sStsMPTThreadConditionJournal
                End Get
                Set(ByVal Value As String)
                    sStsMPTThreadConditionJournal = Value.ToUpper
                End Set
            End Property
            Property MPTPitchCircleDiaJournal() As String
                Get
                    Return sStsMPTPitchCircleDiaJournal
                End Get
                Set(ByVal Value As String)
                    sStsMPTPitchCircleDiaJournal = Value.ToUpper
                End Set
            End Property
            Property MPTConeDiaJournal() As String
                Get
                    Return sStsMPTConeDiaJournal
                End Get
                Set(ByVal Value As String)
                    sStsMPTConeDiaJournal = Value.ToUpper
                End Set
            End Property
            Property MPTCentreTypeJournal() As String
                Get
                    Return sStsMPTCentreTypeJournal
                End Get
                Set(ByVal Value As String)
                    sStsMPTCentreTypeJournal = Value.ToUpper
                End Set
            End Property
            Property MPTDiaJournal() As String
                Get
                    Return sStsMPTDiaJournal
                End Get
                Set(ByVal Value As String)
                    sStsMPTDiaJournal = Value.ToUpper
                End Set
            End Property
            Property MPTLengthJournal() As String
                Get
                    Return sStsMPTLengthJournal
                End Get
                Set(ByVal Value As String)
                    sStsMPTLengthJournal = Value.ToUpper
                End Set
            End Property
            Property MPTRwCodesForJournal() As String
                Get
                    Return sMPTRwCodesForJournal
                End Get
                Set(ByVal Value As String)
                    If Value = "Select" Then
                        Value = ""
                    End If
                    sMPTRwCodesForJournal = Value.ToUpper
                End Set
            End Property

            ' UT Side Wheel Seat Properties
            Property UTDiaWhlSeat() As String
                Get
                    Return sStsUTDiaWhlSeat
                End Get
                Set(ByVal Value As String)
                    sStsUTDiaWhlSeat = Value.ToUpper
                End Set
            End Property
            Property UTLengthWhlSeat() As String
                Get
                    Return sStsUTLengthWhlSeat
                End Get
                Set(ByVal Value As String)
                    sStsUTLengthWhlSeat = Value.ToUpper
                End Set
            End Property
            Property UTRwCodesForWhlSeat() As String
                Get
                    Return sUTRwCodesForWhlSeat
                End Get
                Set(ByVal Value As String)
                    sUTRwCodesForWhlSeat = Value.ToUpper
                End Set
            End Property

            ' MPT Side Wheel Seat Properties
            Property MPTDiaWhlSeat() As String
                Get
                    Return sStsMPTDiaWhlSeat
                End Get
                Set(ByVal Value As String)
                    sStsMPTDiaWhlSeat = Value.ToUpper
                End Set
            End Property
            Property MPTLengthWhlSeat() As String
                Get
                    Return sStsMPTLengthWhlSeat
                End Get
                Set(ByVal Value As String)
                    sStsMPTLengthWhlSeat = Value.ToUpper
                End Set
            End Property
            Property MPTRwCodesForWhlSeat() As String
                Get
                    Return sMPTRwCodesForWhlSeat
                End Get
                Set(ByVal Value As String)
                    If Value = "Select" Then
                        Value = ""
                    End If
                    sMPTRwCodesForWhlSeat = Value.ToUpper
                End Set
            End Property

            ' UT side Dust Guard Properties
            Property UTDiaDustGuard() As String
                Get
                    Return sStsUTDiaDustGuard
                End Get
                Set(ByVal Value As String)
                    sStsUTDiaDustGuard = Value.ToUpper
                End Set
            End Property
            Property UTLengthDustGuard() As String
                Get
                    Return sStsUTLengthDustGuard
                End Get
                Set(ByVal Value As String)
                    sStsUTLengthDustGuard = Value.ToUpper
                End Set
            End Property
            Property UTRwCodesForDustGuard() As String
                Get
                    Return sUTRwCodesForDustGuard
                End Get
                Set(ByVal Value As String)
                    If Value = "Select" Then
                        Value = ""
                    End If
                    sUTRwCodesForDustGuard = Value.ToUpper
                End Set
            End Property

            ' MPT side Dust Guard Properties
            Property MPTDiaDustGuard() As String
                Get
                    Return sStsMPTDiaDustGuard
                End Get
                Set(ByVal Value As String)
                    sStsMPTDiaDustGuard = Value.ToUpper
                End Set
            End Property
            Property MPTLengthDustGuard() As String
                Get
                    Return sStsMPTLengthDustGuard
                End Get
                Set(ByVal Value As String)
                    sStsMPTLengthDustGuard = Value.ToUpper
                End Set
            End Property
            Property MPTRwCodesForDustGuard() As String
                Get
                    Return sMPTRwCodesForDustGuard
                End Get
                Set(ByVal Value As String)
                    If Value = "Select" Then
                        Value = ""
                    End If
                    sMPTRwCodesForDustGuard = Value.ToUpper
                End Set
            End Property

            ' Body side Properties
            Property BodyDia() As String
                Get
                    Return sStsBodyDia
                End Get
                Set(ByVal Value As String)
                    sStsBodyDia = Value.ToUpper
                End Set
            End Property
            Property BodyLength() As String
                Get
                    Return sStsBodyLength
                End Get
                Set(ByVal Value As String)
                    sStsBodyLength = Value.ToUpper
                End Set
            End Property
            Property RwCodesForBody() As String
                Get
                    Return sRwCodesForBody
                End Get
                Set(ByVal Value As String)
                    If Value = "Select" Then
                        Value = ""
                    End If
                    sRwCodesForBody = Value.ToUpper
                End Set
            End Property
        End Class
#End Region
    End Class
End Namespace


