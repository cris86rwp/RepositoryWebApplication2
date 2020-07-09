<Serializable()> Public Class InspectionAssistant
    Private dInspDate, LastUpDate, dBkupDate As Date
    Private sShift, sMessage, sBkupShift As String
    Private sOperatorCode, sInspectorEmpCode, sDespatchNoteNumber, sPressed, sSetDespatched As String
    Private lWheelNumber, lHeatNumber As Long
    Private sWheelType As String
    Private iBHNValue As Integer
    Private Event NotInMaster()
    Private Event MagnaWheel()
    Private Event YardWheel()
    Private Event FinalWheel()
    Private Event QCIWheel()
    Private Event MouldRoomWheel()
    Private Event WheelTypeChanged()
    Private Event CheckSetDesp()
    Private blnCanNotBeProced, blnMcnedWheel, blnHTMcnedWheel, blnAllowRejOfMagWheel As Boolean
    Private sDescr As String
    Private tblInspParams As DataTable
    Private iDayTarget As Integer
    Private iMonthTarget As Integer
    Private iDayActual As Integer
    Private iMonthActuals As Integer
    Private decTreadDia As Decimal
    Private iShiftActual As Integer
    Private iSeriesWhls As Integer
    Private Event BoreDiachanged()
    Private Event TreadDiaChanged()
    Private Event PlateThicknessChanged()
    Private Event BoreStatusChanged()
    Private Event WheelStatusChanged()
    Private Event rimThicknessChanged()
    Private blnMagNotTested As Boolean

    Private blnDataValid, blnTDBeyondRange, blnBDBeyondRange, blnOverSize, blnPTBeyondRange, blnRTBeyondRange, blnRDTYdone As Boolean
    Private decBoreDia, decPlateThickness, deciRimThickness As Decimal
    Private bln1stWhlInCopeOrDrag, bln20thWheel, blnYardHold, blnGrindingWheel As Boolean
    Private sBoreSts, sWheelSts, sPlateSts, sRimSts As String
    Private sRemarks As String
    Private sMcnOpn, sGrindSts, strloc, strSts, sMagSts, sRdtyWheel, sDrgNo, sPCode As String
    Private iMagProced, iMagStocked As Integer
    Private deciRdtySize, deciRdtyBoc As Decimal
    Private blnContinueShift As Boolean
    Private lMaxWhlNo, lMinWhlNo As Long

    Enum RdtcCheckTypes
        Rdty_Size
        Rdty_BOC
    End Enum
    Property OperatorCode() As String
        Get
            Return sOperatorCode
        End Get
        Set(ByVal Value As String)
            If CheckOperator(Value) Then
                sOperatorCode = Value
            Else
                sOperatorCode = ""
                Throw New Exception("InValid Operator Code : '" & Value.Trim & "'")
            End If
        End Set
    End Property
    Private Function CheckOperator(ByVal EmpCode As String) As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.CommandText = "select @cnt = count(*)  from hr_employee_master where employee_code = @EmpCode and convert(int,employee_status) <= 11 "
        cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 50).Value = EmpCode.Trim
        cmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
        Try
            cmd.Connection.Open()
            cmd.ExecuteScalar()
            If IIf(IsDBNull(cmd.Parameters("@cnt").Value), 0, cmd.Parameters("@cnt").Value) > 0 Then
                CheckOperator = True
                sMessage = ""
            Else
                sMessage = "Invalid operator code for login : " & EmpCode & " "
            End If
        Catch exp As Exception
            sMessage = "Employee Login Check Failed : " & exp.Message
        Finally
            If IsNothing(cmd) = False Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End If
        End Try
    End Function
    ReadOnly Property IsShiftContinued() As Boolean
        Get
            Return blnContinueShift
        End Get
    End Property
    Private Sub ClearVariables()
        sPCode = ""
        sDrgNo = ""
        sOperatorCode = ""
        blnContinueShift = False
        sRdtyWheel = ""
        deciRdtySize = 0.0
        deciRdtyBoc = 0.0
        sMcnOpn = ""
        sGrindSts = ""
        strloc = ""
        strSts = ""
        sMagSts = ""
        sBoreSts = ""
        sWheelSts = ""
        sPlateSts = ""
        sRimSts = ""
        decBoreDia = 0
        decPlateThickness = 0
        deciRimThickness = 0
        blnMcnedWheel = False
        sMessage = ""
        blnYardHold = False
        blnMagNotTested = False
        iSeriesWhls = 0
    End Sub
    ReadOnly Property RdtyWheel() As String
        Get
            Return sRdtyWheel
        End Get
    End Property
    Property RotundityCheck(ByVal sType As RdtcCheckTypes) As Decimal
        Get
            If sType = RdtcCheckTypes.Rdty_BOC Then
                Return deciRdtyBoc
            ElseIf sType = RdtcCheckTypes.Rdty_Size Then
                Return deciRdtySize
            Else
                Return 0
            End If
        End Get
        Set(ByVal Value As Decimal)
            If Value >= 0 Then
                If sType = RdtcCheckTypes.Rdty_BOC Then
                    deciRdtyBoc = Value
                ElseIf sType = RdtcCheckTypes.Rdty_Size Then
                    deciRdtySize = Value
                Else
                    deciRdtyBoc = 0
                    deciRdtySize = 0
                End If
            End If

        End Set
    End Property
    ReadOnly Property MagNotTested() As Boolean
        Get
            Return blnMagNotTested
        End Get
    End Property
    ReadOnly Property IsGrindingWheel() As Boolean
        Get
            Return blnGrindingWheel
        End Get
    End Property
    Public Sub New()
        ClearVariables()
        GetDate()
        AddHandler Me.FinalWheel, AddressOf FIWheel
        AddHandler Me.NotInMaster, AddressOf NMWheel
        AddHandler Me.WheelTypeChanged, AddressOf TypeChange
        AddHandler Me.MagnaWheel, AddressOf magwheel
        AddHandler Me.YardWheel, AddressOf yardwhl
        AddHandler Me.MouldRoomWheel, AddressOf mrwheel
        AddHandler Me.QCIWheel, AddressOf qciwhl
        AddHandler Me.CheckSetDesp, AddressOf SetDespatch
        AddHandler Me.TreadDiaChanged, AddressOf checkTreadDia
        AddHandler Me.PlateThicknessChanged, AddressOf checkPlateThickness
        AddHandler Me.BoreDiachanged, AddressOf checkBoreDia
        AddHandler Me.rimThicknessChanged, AddressOf checkRimThickness
        AddHandler Me.WheelStatusChanged, AddressOf CheckWheelStatus

        iMagProced = -1
        iMagStocked = -1
        blnHTMcnedWheel = isHTMachinedWheel()
        'TypeChange 
        ShiftContinued()
    End Sub
    ReadOnly Property HT_Machined_Wheel() As Boolean
        Get
            Return blnHTMcnedWheel
        End Get
    End Property
    ReadOnly Property IsMcnedWheel() As Boolean
        Get
            Return blnMcnedWheel
        End Get
    End Property
    ReadOnly Property RDTYdone() As Boolean
        Get
            Return blnRDTYdone
        End Get
    End Property
    Public Sub IsRDTYdone()
        Dim ocmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        ocmd.CommandText = "Select top 1 @WheelNumber = wheel_number, @HeatNumber = heat_number, @Done = 1,   @RdtySize = isnull(RotundityCheck_Size,0), @RdtyBoc =  isnull(RotundityCheck_BOC_Size,0) from mm_final_inspection where inspection_date = @Date and shift_code = @shift and remarks like '%RDTY%' order by sl_no desc "
        Try
            ocmd.Parameters.Add("@Date", SqlDbType.SmallDateTime, 4).Value = dInspDate
            ocmd.Parameters.Add("@Shift", SqlDbType.VarChar, 1).Value = sShift
            ocmd.Parameters.Add("@RdtySize", SqlDbType.Float, 4).Direction = ParameterDirection.Output
            ocmd.Parameters.Add("@RdtyBoc", SqlDbType.Float, 4).Direction = ParameterDirection.Output
            ocmd.Parameters.Add("@Done", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            ocmd.Parameters.Add("@WheelNumber", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
            ocmd.Parameters.Add("@HeatNumber", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
            ocmd.Connection.Open()
            ocmd.ExecuteScalar()
            blnRDTYdone = ocmd.Parameters("@Done").Value > 0
            If blnRDTYdone Then
                sRdtyWheel = CStr(ocmd.Parameters("@WheelNumber").Value).Trim + "/" + CStr(ocmd.Parameters("@HeatNumber").Value).Trim
            Else
                sRdtyWheel = ""
            End If

            If blnRDTYdone = True Then
                If deciRdtyBoc = 0 Then
                    deciRdtyBoc = ocmd.Parameters("@RdtyBoc").Value
                End If
                If deciRdtySize = 0 Then
                    deciRdtySize = ocmd.Parameters("@RdtySize").Value
                End If
            Else
                deciRdtyBoc = 0
                deciRdtySize = 0
            End If
        Catch exp As Exception
            blnRDTYdone = False
        Finally
            If ocmd.Connection.State = ConnectionState.Open Then ocmd.Connection.Close()
            ocmd.Dispose()
            ocmd = Nothing
        End Try
    End Sub
    Public Function GetReclPreStatus(ByVal WhlNo As Long, ByVal HtNo As Long) As String
        Dim ocmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        ocmd.CommandText = "select top 1  'QCI Recl Wheel (pre_status : '+ rtrim(d.pre_status)+ ')' qci_Pre_status " & _
            " from mm_qci_inspection d inner join " & _
            " (select * from mm_wheel where wheel_number = " & WhlNo & " and heat_number = " & HtNo & " and location  = 'clmt') e " & _
            " on e.wheel_number = d.wheel_number and e.heat_number = d.heat_number "
        Try
            ocmd.Connection.Open()
            GetReclPreStatus = ocmd.ExecuteScalar
        Catch exp As Exception
            GetReclPreStatus = ""
        Finally
            If ocmd.Connection.State = ConnectionState.Open Then ocmd.Connection.Close()
            ocmd.Dispose()
            ocmd = Nothing
        End Try
    End Function
    Public Function GetWheelWeight(ByVal whlNo As Long, ByVal heatNo As Long) As Decimal
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.CommandText = "select @whlWeight = wap.dbo.mm_fn_GetWheelWeight(" & whlNo & ", " & heatNo & ")"
        cmd.Parameters.Add("@whlWeight", SqlDbType.Decimal, 8, 1).Direction = ParameterDirection.Output
        Try
            cmd.Connection.Open()
            cmd.ExecuteScalar()
            GetWheelWeight = IIf(IsDBNull(cmd.Parameters("@whlWeight").Value), 0, cmd.Parameters("@whlWeight").Value)
        Catch exp As Exception
            sMessage = "Wheel Weight Retrieval Problem: " & exp.Message
        Finally
            If IsNothing(cmd) = False Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End If
        End Try
    End Function
    Public Function GetTreadDia(ByVal WhlNo As Long, ByVal HtNo As Long) As Decimal
        Dim ocmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        ocmd.CommandText = "Select Thread_Diameter from mm_wheel where wheel_number = " & WhlNo & " and heat_number = " & HtNo
        Try
            ocmd.Connection.Open()
            GetTreadDia = ocmd.ExecuteScalar
        Catch exp As Exception
            GetTreadDia = 0.0
        Finally
            If ocmd.Connection.State = ConnectionState.Open Then ocmd.Connection.Close()
            ocmd.Dispose()
            ocmd = Nothing
        End Try
    End Function
    Property Remarks() As String
        Get
            Return sRemarks
        End Get
        Set(ByVal Value As String)
            sRemarks = Value.ToUpper()
        End Set
    End Property
    ReadOnly Property IsTreadDiaOK() As Boolean
        Get
            Return Not blnTDBeyondRange
        End Get
    End Property
    ReadOnly Property Is1stWheelInCope() As Boolean
        Get
            Return bln1stWhlInCopeOrDrag
        End Get
    End Property
    ReadOnly Property MasterStatus() As String
        Get
            Return strSts.ToUpper
        End Get
    End Property
    Private Sub checkTreadDia()
        Dim td As Decimal = decTreadDia
        blnTDBeyondRange = False
        Dim row As DataRow
        For Each row In tblInspParams.Rows
            blnTDBeyondRange = Not (td >= row("MinTd") And td <= row("MaxTD"))
        Next
        td = Nothing
        row = Nothing
    End Sub
    Property PlateSts() As String
        Get
            Return sPlateSts
        End Get
        Set(ByVal Value As String)
            sPlateSts = Value
            RaiseEvent PlateThicknessChanged()
        End Set
    End Property
    Private Sub ShiftContinued()
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.CommandText = "Select wap.dbo.mm_fn_AllowPrevShiftContinue(@Dt, @sh, @ProdType)"
        cmd.Parameters.Add("@Dt", SqlDbType.SmallDateTime, 4).Value = dBkupDate
        cmd.Parameters.Add("@sh", SqlDbType.VarChar, 1).Value = sBkupShift
        cmd.Parameters.Add("@ProdType", SqlDbType.VarChar, 1).Value = "W"
        Try
            cmd.Connection.Open()
            If cmd.ExecuteScalar > 0 Then
                sShift = "C"
                ' put here last saved date.
                dInspDate = getlastInspDate() 'dBkupDate.Subtract(New TimeSpan(1, 0, 0, 0, 0))
                blnContinueShift = True
                Select Case sShift
                    Case "A"
                        ' sShift = "C"
                        dInspDate = dBkupDate.Subtract(New TimeSpan(1, 0, 0, 0, 0))
                        blnContinueShift = True
                    Case "B"
                        'sShift = "A"
                        dInspDate = dBkupDate.Subtract(New TimeSpan(1, 0, 0, 0, 0))
                        blnContinueShift = True
                    Case "C"
                        ' sShift = "B"
                        dInspDate = dBkupDate.Subtract(New TimeSpan(1, 0, 0, 0, 0))
                        blnContinueShift = True
                    Case Else
                        blnContinueShift = False
                End Select
            Else
                blnContinueShift = False
            End If
        Catch exp As Exception
            blnContinueShift = False
        Finally
            If IsNothing(cmd) = False Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End If
        End Try
        If blnContinueShift = True Then
            dInspDate = getlastInspDate()
        End If
        If blnContinueShift = False Then
            dInspDate = dBkupDate
            sShift = sBkupShift
        End If
    End Sub
    Private Sub checkPlateThickness()
        Dim Pt As Decimal = decPlateThickness.Floor(decPlateThickness)
        blnPTBeyondRange = False
        Dim row As DataRow
        For Each row In tblInspParams.Rows
            blnPTBeyondRange = Not (Pt >= row("MinPT") And Pt <= row("MaxPT")) And decPlateThickness > 0
        Next
        If blnPTBeyondRange Then
            sPlateSts = ""
        Else
            sPlateSts = "OK"
        End If
        Pt = Nothing
        row = Nothing
    End Sub
    ReadOnly Property IsPlateThicknessOK() As Boolean
        Get
            Return Not blnPTBeyondRange
        End Get
    End Property
    Property BoreDia() As Decimal
        Get
            Return decBoreDia
        End Get
        Set(ByVal Value As Decimal)
            decBoreDia = Value
            RaiseEvent BoreDiachanged()
            If blnBDBeyondRange Then
                Throw New Exception("Bore Dia is beyond limits. Checkup your Inputs")
            End If
        End Set
    End Property
    Private Sub checkBoreDia()
        Dim bd As Decimal = decBoreDia
        blnBDBeyondRange = False
        If bd < 0 Then
            sBoreSts = "UB"
            Exit Sub
        ElseIf bd = 0 Then
            sBoreSts = "OK"
            Exit Sub
        End If
        Dim row As DataRow
        For Each row In tblInspParams.Rows
            blnBDBeyondRange = Not (bd >= row("MinBore") And bd <= row("MaxBore") And decBoreDia > 0)
            If blnBDBeyondRange Then
                blnOverSize = False
                sBoreSts = ""
                sMessage = "Bore size beyond MinBore and Max_BOS sizes"
                blnBDBeyondRange = Not (bd >= row("BOS_Min") And bd <= row("BOS_Max") And decBoreDia > 0)
                If blnBDBeyondRange = False Then
                    blnOverSize = True
                    sBoreSts = "BOS"
                    sMessage = ""
                End If
            Else
                sBoreSts = "OK"
            End If
        Next
        bd = Nothing
        row = Nothing
    End Sub
    ReadOnly Property ShiftActual() As Integer
        Get
            ShiftActuals()
            Return iShiftActual
        End Get
    End Property
    ReadOnly Property BoreOverSize() As Boolean
        Get
            Return blnOverSize
        End Get
    End Property
    ReadOnly Property IsBoreDiaOK() As Boolean
        Get
            Return Not blnBDBeyondRange
        End Get
    End Property
    ReadOnly Property BoreStatus() As String
        Get
            Return sBoreSts
        End Get
    End Property
    Property RimThickness() As Decimal
        Get
            Return deciRimThickness
        End Get
        Set(ByVal Value As Decimal)
            deciRimThickness = Value
            RaiseEvent rimThicknessChanged()
            If blnRTBeyondRange Then
                Throw New Exception("Rim Thickness is beyond limits. Checkup your Inputs")
            End If
        End Set
    End Property
    Property RimStatus() As String
        Get
            Return sRimSts
        End Get
        Set(ByVal Value As String)
            sRimSts = Value
            RaiseEvent rimThicknessChanged()
        End Set
    End Property
    Private Sub checkRimThickness()
        Dim Rt As Decimal = deciRimThickness
        blnRTBeyondRange = False
        Dim row As DataRow
        For Each row In tblInspParams.Rows
            blnRTBeyondRange = Not (Rt >= row("MinRT") And Rt <= row("MaxRT") And deciRimThickness <> 0)
        Next
        Rt = Nothing
        row = Nothing
    End Sub
    Private Sub ShiftActuals()
        Dim ocmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        ocmd.CommandText = "select count(*) from mm_final_inspection where inspection_date = @Date " & _
            " and shift_code = @shift and wheel_status like 'p%'"
        Try
            ocmd.Parameters.Add("@Date", SqlDbType.SmallDateTime, 4).Value = dInspDate
            ocmd.Parameters.Add("@Shift", SqlDbType.VarChar, 1).Value = sShift
            ocmd.Connection.Open()
            iShiftActual = ocmd.ExecuteScalar
            If IsNothing(iShiftActual) Then
                iShiftActual = 0
            ElseIf IsDBNull(iShiftActual) Then
                iShiftActual = 0
            End If
        Catch exp As Exception
            iShiftActual = 0
        Finally
            If ocmd.Connection.State = ConnectionState.Open Then ocmd.Connection.Close()
            ocmd.Dispose()
            ocmd = Nothing
        End Try
    End Sub
    Property PlateThickness() As Decimal
        Get
            Return decPlateThickness
        End Get
        Set(ByVal Value As Decimal)
            decPlateThickness = Value
            RaiseEvent PlateThicknessChanged()
            If blnPTBeyondRange Then
                Throw New Exception("Plate Thickness is beyond limits. Checkup your Inputs")
            End If
        End Set
    End Property
    ReadOnly Property message() As String
        Get
            Return sMessage
        End Get
    End Property
    ReadOnly Property Valid() As Boolean
        Get
            Return blnDataValid And blnCanNotBeProced = False
        End Get
    End Property
    Property WheelStatus() As String
        Get
            Return sWheelSts
        End Get
        Set(ByVal Value As String)
            sWheelSts = Value
            RaiseEvent WheelStatusChanged()
        End Set
    End Property
    Private Sub CheckWheelStatus()
        CheckData()
        If blnDataValid = True Then
            blnCanNotBeProced = False
        Else
            blnCanNotBeProced = True
        End If
    End Sub
    Public Function SaveErrorWheels(ByVal OperatorCode As String, ByVal Wheel As Long, ByVal Heat As Long, ByVal Remarks As String) As String
        Dim blnSaved As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            cmd.Parameters.Add("@wheel_number", SqlDbType.BigInt, 8).Value = Wheel
            cmd.Parameters.Add("@heat_number", SqlDbType.BigInt, 8).Value = Heat
            cmd.Parameters.Add("@inspection_date", SqlDbType.SmallDateTime, 4).Value = dInspDate
            cmd.Parameters.Add("@shift_code", SqlDbType.VarChar, 1).Value = sShift
            cmd.Parameters.Add("@wap_inspector", SqlDbType.VarChar, 6).Value = sInspectorEmpCode
            cmd.Parameters.Add("@operator_code", SqlDbType.VarChar, 50).Value = OperatorCode
            cmd.Parameters.Add("@remarks", SqlDbType.VarChar, 100).Value = Remarks.ToUpper
            cmd.Parameters.Add("@SavedDateTime", SqlDbType.DateTime, 8).Value = Now

            cmd.CommandText = " insert into mm_final_inspection_SaveErrorWheels " & _
                " ( WheelNumber , HeatNumber , InspCode , OperCode ,  Remarks , InspectionDate ,  InspShift , SavedDateTime ) values " & _
                " ( @wheel_number , @heat_number , @wap_inspector , @operator_code ,  @remarks , @inspection_date ,  @shift_code , @SavedDateTime  ) "

            cmd.Connection.Open()
            cmd.Transaction = cmd.Connection.BeginTransaction
            If cmd.ExecuteNonQuery() = 1 Then blnSaved = True
        Catch exp As Exception
            SaveErrorWheels = exp.Message & " " & lWheelNumber.ToString & "/" & lHeatNumber.ToString
            blnSaved = True
        Finally
            If IsNothing(cmd.Transaction) = False Then
                If blnSaved = True Then
                    cmd.Transaction.Commit()
                Else
                    cmd.Transaction.Rollback()
                End If
            End If
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
        End Try
        blnSaved = Nothing
    End Function
    Public Function Save() As String
        CheckData()
        If Valid = False Then
            Save = sMessage
            Exit Function
        End If
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Dim sInsertFI, sUpdateMaster, sCheckFI, sCheckMaster, sUpdateContinueShiftTbl As String
        sInsertFI = "insert into mm_final_Inspection (wheel_number, heat_number, inspection_date , shift_code, wap_inspector, wheel_status, bore_status, tread_diameter, plate_thickness, remarks, rdso_offtm, RotundityCheck_Size, RotundityCheck_BOC_Size,operator_code) values (@wheel_number, @heat_number, @inspection_date , @shift_code, @wap_inspector, @wheel_status, @bore_status, @tread_diameter, @plate_thickness, @remarks, @rdso_offtm, @RotundityCheck_Size, @RotundityCheck_BOC_Size, @operator_code )"
        sUpdateMaster = "update mm_wheel set location = 'CLFI' , status = @wheel_status , bore_status = @Masterbore_status , bore_diameter = @bore_diameter  , thread_diameter = @tread_diameter  , plate_thickness = @plate_thickness where wheel_number = @wheel_number and heat_number = @heat_number "
        sCheckFI = "Select count(*) from mm_final_Inspection where wheel_number = @wheel_number and heat_number = @heat_number and inspection_date = @Inspection_date and shift_code = @Shift_code and wheel_status = @wheel_status and remarks = @remarks and bore_status = @bore_status and tread_diameter = @tread_diameter and plate_thickness = @plate_thickness"
        sCheckMaster = "Select count(*) from mm_wheel where wheel_number = @wheel_number and heat_number = @heat_number and location = 'CLFI' and status = @wheel_status and bore_status = @Masterbore_status and bore_diameter = @bore_diameter  and thread_diameter = @tread_diameter  and plate_thickness = @plate_thickness"
        sUpdateContinueShiftTbl = "Update mm_ContinueShift_Authorisation set DoneCount = DoneCount + 1 where InspDate = @inspection_date and Shift = @shift_code and ProdType = 'W'"
        cmd.CommandText = sInsertFI
        Dim blnNotSaved As Boolean
        Dim Err As Boolean
        Try
            cmd.Parameters.Add("@wheel_number", SqlDbType.BigInt, 8).Value = lWheelNumber
            cmd.Parameters.Add("@heat_number", SqlDbType.BigInt, 8).Value = lHeatNumber
            cmd.Parameters.Add("@inspection_date", SqlDbType.SmallDateTime, 4).Value = dInspDate
            cmd.Parameters.Add("@shift_code", SqlDbType.VarChar, 1).Value = sShift
            cmd.Parameters.Add("@wap_inspector", SqlDbType.VarChar, 6).Value = sInspectorEmpCode
            cmd.Parameters.Add("@wheel_status", SqlDbType.VarChar, 20).Direction = ParameterDirection.Input
            cmd.Parameters.Add("@bore_status", SqlDbType.VarChar, 50).Direction = ParameterDirection.Input
            cmd.Parameters.Add("@tread_diameter", SqlDbType.Float, 8).Direction = ParameterDirection.Input
            cmd.Parameters.Add("@plate_thickness", SqlDbType.VarChar, 50).Direction = ParameterDirection.Input
            cmd.Parameters.Add("@remarks", SqlDbType.VarChar, 100).Direction = ParameterDirection.Input
            cmd.Parameters.Add("@rdso_offtm", SqlDbType.DateTime, 8).Direction = ParameterDirection.Input
            cmd.Parameters.Add("@bore_diameter", SqlDbType.Float, 8).Direction = ParameterDirection.Input
            cmd.Parameters.Add("@Masterbore_status", SqlDbType.VarChar, 50).Direction = ParameterDirection.Input
            cmd.Parameters.Add("@operator_code", SqlDbType.VarChar, 50).Direction = ParameterDirection.Input
            cmd.Parameters.Add("@RotundityCheck_Size", SqlDbType.Decimal, 18, 2).Direction = ParameterDirection.Input
            cmd.Parameters.Add("@RotundityCheck_BOC_Size", SqlDbType.Decimal, 18, 2).Direction = ParameterDirection.Input

            cmd.Parameters("@wheel_status").Value = sWheelSts
            cmd.Parameters("@remarks").Value = sRemarks.ToUpper
            If sRemarks.IndexOf("RDTY") >= 0 Then
                cmd.Parameters("@RotundityCheck_Size").Value = deciRdtySize
                cmd.Parameters("@RotundityCheck_BOC_Size").Value = deciRdtyBoc
            Else
                cmd.Parameters("@RotundityCheck_Size").Value = 0
                cmd.Parameters("@RotundityCheck_BOC_Size").Value = 0
            End If
            If sWheelSts.StartsWith("P") = True Then
                cmd.Parameters("@bore_status").Value = sBoreSts
                cmd.Parameters("@Masterbore_status").Value = IIf(sBoreSts.StartsWith("U"), "Un-Bore", "B")
                cmd.Parameters("@tread_diameter").Value = decTreadDia
                cmd.Parameters("@plate_thickness").Value = IIf(decPlateThickness > 0, decPlateThickness.ToString, sPlateSts)
                cmd.Parameters("@bore_Diameter").Value = decBoreDia
            Else
                cmd.Parameters("@bore_status").Value = ""
                cmd.Parameters("@Masterbore_status").Value = ""
                cmd.Parameters("@tread_diameter").Value = 0
                cmd.Parameters("@plate_thickness").Value = ""
                ' cmd.Parameters("@remarks").Value = ""
                cmd.Parameters("@bore_Diameter").Value = 0
            End If
            cmd.Parameters("@operator_code").Value = sOperatorCode
            cmd.Parameters("@rdso_offtm").Value = Now

            cmd.Connection.Open()
            cmd.Transaction = cmd.Connection.BeginTransaction
            cmd.CommandText = sCheckFI
            If cmd.ExecuteScalar = 0 Then
                cmd.CommandText = sInsertFI
                cmd.ExecuteNonQuery()
                cmd.CommandText = sCheckFI
                If cmd.ExecuteScalar > 0 Then
                    cmd.CommandText = sUpdateMaster
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = sCheckMaster
                    If cmd.ExecuteScalar = 0 Then
                        blnNotSaved = True
                    End If
                Else
                    blnNotSaved = True
                End If
            End If
            If blnNotSaved = False Then

                Try
                    ' following block was written to celebrate record outturn 2011-12 online
                    ''cmd.CommandText = "select 200000 - wap.dbo.mm_fn_WheelProductionForPeriod('2011-4-1', '2012-3-31')"
                    ''Dim iShortage As Integer
                    ''iShortage = cmd.ExecuteScalar
                    ''If iShortage < 1 Then
                    ''    Save = "CONGRATULATIONS FOR CREATING HISTORY BY PRODUCING 2,00,000 GOOD WHEELS !!! "
                    ''Else
                    ''    Save = "For Record OutTurn " & iShortage.ToString & " Good Wheels are required. "
                    ''End If

                    Save = "Saved " & lWheelNumber.ToString & "/" & lHeatNumber.ToString & " as " & sWheelSts & " Bore: " & sBoreSts & " TD:" & decTreadDia
                    ''iShortage = Nothing
                    ' block over.
                    ' rem above block and un-remark below command after the event.
                Catch exp As Exception
                    Save = "Saved " & lWheelNumber.ToString & "/" & lHeatNumber.ToString & " as " & sWheelSts & " Bore: " & sBoreSts & " TD:" & decTreadDia
                End Try

                ' Save = "Saved " & lWheelNumber.ToString & "/" & lHeatNumber.ToString & " as " & sWheelSts & " Bore: " & sBoreSts & " TD:" & decTreadDia
                If blnContinueShift Then
                    Try
                        cmd.CommandText = sUpdateContinueShiftTbl
                        cmd.Parameters("@inspection_date").Value = dBkupDate
                        cmd.Parameters("@shift_code").Value = sBkupShift
                        cmd.ExecuteNonQuery()
                    Catch exp As Exception
                        Throw New Exception(exp.Message)
                    End Try
                End If
            Else
                Save = "SAVE FAILED : " & lWheelNumber.ToString & "/" & lHeatNumber.ToString & " as " & sWheelSts
            End If
        Catch exp As Exception
            blnNotSaved = True
            Err = True
            Throw New Exception(exp.Message & " " & lWheelNumber.ToString & "/" & lHeatNumber.ToString)
        Finally
            If IsNothing(cmd.Transaction) = False Then
                If Not Err = True Then
                    If blnNotSaved = True Then
                        cmd.Transaction.Rollback()
                    Else
                        cmd.Transaction.Commit()
                    End If
                End If
            End If
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
        End Try
        blnNotSaved = Nothing
        sInsertFI = Nothing
        sUpdateMaster = Nothing
        sCheckFI = Nothing
        sCheckMaster = Nothing
        sUpdateContinueShiftTbl = Nothing
    End Function
    Private Function IsValidEmpCode() As Boolean
        'sInspectorEmpCode
        Dim oEmp As rwfGen.Employee
        Try
            If oEmp.Check(sInspectorEmpCode, "CLRINS") = True Then
                IsValidEmpCode = True
            Else
                Throw New Exception("Invalid Employee code for CLRINS")
            End If
        Catch exp As Exception
            Throw New Exception(exp.Message)
        End Try
        oEmp = Nothing
    End Function
    Public Sub CheckData()
        Dim blnCheckedEmpCode As Boolean
        Try
            If IsValidEmpCode() = False Then
                sMessage = ""
                sMessage = "Not Allowed: "
                Exit Sub
            Else
                blnCheckedEmpCode = True
            End If
        Catch exp As Exception
            sMessage &= exp.Message
        End Try
        If blnCheckedEmpCode = False Then
            Exit Sub
        End If
        blnCheckedEmpCode = Nothing
        blnDataValid = False
        sMessage = ""
        If blnAllowRejOfMagWheel = True And sWheelSts.StartsWith("R") = False Then
            sMessage = "Invalid Status (wheel can only be rejected) "
            Exit Sub
        End If
        If dInspDate = CDate("1/1/1900") Then sMessage = "Inspection Date Invalid" Else If dInspDate <> Today.Date Then sMessage = ""
        If sMessage <> "" Then Exit Sub
        If sShift = "" Then sMessage = "Invalid shift"
        If sMessage <> "" Then Exit Sub
        If sWheelType.Trim = "" Then sMessage = "Invalid Wheel Type"
        If sMessage <> "" Then Exit Sub
        If lWheelNumber <= 0 Then sMessage = "Invalid Wheel Number"
        If sMessage <> "" Then Exit Sub
        If lWheelNumber > lMaxWhlNo And lHeatNumber <> 0 Then sMessage = "Invalid Wheel Number"
        If sMessage <> "" Then Exit Sub
        If lWheelNumber < lMinWhlNo And lHeatNumber <= 0 Then sMessage = "Invalid Wheel Number"
        If sMessage <> "" Then Exit Sub

        If bln1stWhlInCopeOrDrag Then
            If sWheelSts.StartsWith("P") = True Then
                If decTreadDia <= 0 Then
                    sMessage = "Tread Dia was expected since 1st wheel in new cope/drag"
                End If
                If decPlateThickness <= 0 Then
                    sMessage = "Plate Thickness was expected since 1st wheel in new cope/drag"
                End If
                If decBoreDia <= 0 Then
                    If sBoreSts <> "UB" Then ' added on 15-2-08 svi on Inspection complaint
                        sMessage = "Bore Dia was expected since 1st wheel in new cope/drag"
                    End If
                End If
            End If
        ElseIf bln20thWheel Then
            If sWheelSts.StartsWith("P") = True Then
                If decTreadDia <= 0 Then
                    sMessage = "Tread Dia was expected since 20th wheel"
                End If
                If decPlateThickness <= 0 Then
                    sMessage = "Plate Thickness was expected since 20th wheel"
                End If
                If decBoreDia = 0 Then
                    If sBoreSts <> "UB" Then ' added on 15-2-08 svi on Inspection complaint
                        sMessage = "Bore Dia was expected since 20th wheel"
                    End If
                End If
            End If
        End If
        If sWheelSts.StartsWith("P") Then
            If (decBoreDia < 0 And sBoreSts <> "UB") Or (decBoreDia >= 0 And sBoreSts = "UB") Then
                sMessage = "Bore Dia & Status mismatch"
            End If
            If ((sBoreSts = "BOS" And blnOverSize = False) Or (blnOverSize And sBoreSts <> "BOS")) Then
                sMessage = "OverSize Bore Status Bore Dia mismatch"
            End If
            If decTreadDia = 0 Then
                sMessage = "Tread Dia is must for passing a wheel."
            End If
            If ((sPlateSts = "OK" And blnPTBeyondRange) Or (sPlateSts <> "OK" And blnPTBeyondRange = False)) Then
                sMessage = "Plate Status and Thickness mismatch"
            End If
            If sWheelSts = "UnBore Pass" And sBoreSts <> "UB" Then
                sMessage = "Wheel Status and Bore Status mismatch"
            End If
            If sBoreSts = "UB" And decBoreDia > 0 Then
                sMessage = "Wheel Status and Bore Status mismatch"
            End If
            If blnTDBeyondRange And Not (sWheelSts.StartsWith("R") Or sWheelSts.StartsWith("W")) Then
                sMessage = "Wheel Status and Insp Params donot match"
            End If
            If blnBDBeyondRange And Not (sWheelSts.StartsWith("R") Or sWheelSts.StartsWith("W")) Then
                sMessage = "Wheel Status and Insp Params donot match"
            End If
            If blnPTBeyondRange And Not (sWheelSts.StartsWith("R") Or sWheelSts.StartsWith("W")) Then
                sMessage = "Wheel Status and Insp Params donot match"
            End If
        End If
        'If blnMcnedWheel And sWheelSts.StartsWith("R") = False Then ' remarked on 10-08-2009 svi : to be checked why it was written here
        '    sMessage = "This wheel can only be rejected"
        'End If
        If sMessage <> "" Then
            blnDataValid = False
            Exit Sub
        End If
        ' check if already saved wheel
        If alreadySaved() Then
            sMessage = "This wheel is already saved. Cannot be saved again."
        End If
        If sMessage <> "" Then
            blnDataValid = False
            Exit Sub
        End If
        blnDataValid = True
    End Sub
    Public Function ClosureResults(ByVal wh1 As Long, ByVal ht1 As Long) As String
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            cmd.Parameters.Add("@wh1", SqlDbType.BigInt, 8).Value = wh1
            cmd.Parameters.Add("@ht1", SqlDbType.BigInt, 8).Value = ht1
            cmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            cmd.CommandText = "select @cnt = wap.dbo.ms_fn_ClosureResults(@ht1,@wh1)  "
            cmd.Connection.Open()
            cmd.ExecuteScalar()
            If IIf(IsDBNull(cmd.Parameters("@cnt").Value), 0, cmd.Parameters("@cnt").Value) = 0 Then
                ClosureResults = " Closure value not available !"
            End If
        Catch exp As Exception
            ClosureResults = ""
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
        End Try
    End Function
    Private Function alreadySaved() As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.CommandText = "select count(*) from mm_wheel where wheel_number = " & lWheelNumber & " and heat_number = " & lHeatNumber & " and location = 'CLFI' and status like '[p,r]%'"
        Dim cnt As Integer
        Try
            cmd.Connection.Open()
            cnt = cmd.ExecuteScalar
            If IsNothing(cnt) OrElse IsDBNull(cnt) Then
                cnt = -1
            End If
        Catch exp As Exception
            cnt = -1
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
        End Try
        Return cnt > 0
        cnt = Nothing
    End Function
    Property TreadDia() As Decimal
        Get
            Return decTreadDia
        End Get
        Set(ByVal Value As Decimal)
            If decTreadDia <> Value Then
                decTreadDia = Value
                RaiseEvent TreadDiaChanged()
            End If
            If blnTDBeyondRange Then
                Throw New Exception("Tread Dia is beyond limits. Checkup your Inputs")
            End If
            If Value Mod 0.5 <> 0 Then
                Throw New Exception("Tread Dia to be round figure or end with .5")
            End If
            decTreadDia = Value
            If sWheelSts <> "" Then
                RaiseEvent WheelStatusChanged()
            End If
        End Set
    End Property
    Private Sub qciwhl()
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.CommandText = "select 'Wheel NOT Stocked by Magna. QCI Reclaim Status: ' + rtrim(wheel_disposition) + ' on ' + convert(varchar(11), inspection_date, 103) + ' Pre Status: '+rtrim(pre_status)+' Pre Loc: ' + rtrim(pre_location) from mm_qci_Inspection where wheel_number = @wheelnumber and heat_number = @heatnumber group by 'Wheel NOT Stocked by Magna. QCI Reclaim Status: ' + rtrim(wheel_disposition) + ' on ' + convert(varchar(11), inspection_date, 103) + ' Pre Status: '+rtrim(pre_status)+' Pre Loc: ' + rtrim(pre_location)"
        cmd.Parameters.Add("@wheelnumber", SqlDbType.BigInt, 8)
        cmd.Parameters.Add("@heatnumber", SqlDbType.BigInt, 8)
        cmd.Parameters("@wheelnumber").Direction = ParameterDirection.Input
        cmd.Parameters("@heatnumber").Direction = ParameterDirection.Input
        cmd.Parameters("@wheelnumber").Value = lWheelNumber
        cmd.Parameters("@heatnumber").Value = lHeatNumber
        Dim sts As String
        Try
            cmd.Connection.Open()
            sts = cmd.ExecuteScalar()
            If IsNothing(sts) Then sts = ""
        Catch exp As Exception
            sts = exp.Message
        Finally
            blnCanNotBeProced = True
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
        End Try
        Throw New Exception(sts + " : " & lWheelNumber.ToString & "/" & lHeatNumber.ToString)
        sts = Nothing
    End Sub
    Private Sub mrwheel()
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.CommandText = "select top 1 @cnt = count(*), @sts = 'Wheel NOT Processed by Magna. Mould Room Status : ' + case when status <> '' then rtrim(status) else 'OK' end + ' on ' + convert(varchar(11),date_mould,103) from mm_wheel where wheel_number = @wheelnumber and heat_number = @heatnumber and location = 'mopo' group by 'Wheel NOT Processed by Magna. Mould Room Status : ' + case when status <> '' then rtrim(status) else 'OK' end + ' on ' + convert(varchar(11),date_mould,103) "
        cmd.Parameters.Add("@cnt", SqlDbType.Int, 4)
        cmd.Parameters.Add("@sts", SqlDbType.VarChar, 150)
        cmd.Parameters.Add("@wheelnumber", SqlDbType.BigInt, 8)
        cmd.Parameters.Add("@heatnumber", SqlDbType.BigInt, 8)
        cmd.Parameters("@cnt").Direction = ParameterDirection.Output
        cmd.Parameters("@sts").Direction = ParameterDirection.Output
        cmd.Parameters("@wheelnumber").Direction = ParameterDirection.Input
        cmd.Parameters("@heatnumber").Direction = ParameterDirection.Input
        cmd.Parameters("@wheelnumber").Value = lWheelNumber
        cmd.Parameters("@heatnumber").Value = lHeatNumber
        Dim i As Integer, sts As String
        Try
            cmd.Connection.Open()
            cmd.ExecuteScalar()
            i = IIf(IsDBNull(cmd.Parameters("@cnt").Value), 0, cmd.Parameters("@cnt").Value)
            sts = IIf(IsDBNull(cmd.Parameters("@sts").Value), "", cmd.Parameters("@sts").Value)
            If IsNothing(i) Then i = 0
            If IsNothing(sts) Then sts = ""
            blnCanNotBeProced = True
            If i > 0 Then blnMagNotTested = True
        Catch exp As Exception
            i = 0
            sts = exp.Message
        Finally
            blnCanNotBeProced = True
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
        End Try
        i = Nothing
        Throw New Exception(sts)
    End Sub
    ReadOnly Property McnOpn() As String
        Get
            Return sMcnOpn
        End Get
    End Property
    ReadOnly Property GrindSts() As String
        Get
            Return sGrindSts
        End Get
    End Property
    Private Sub magwheel()
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        'cmd.CommandText = "select top 1 @cnt = count(*), @grindstatus = grindstatus, @mcnoperation = mcnoperation, @wheelstatus = wheelstatus from mm_magnaglow_shiftwiseRecords where wheelnumber = @wheelnumber and heatnumber = @heatnumber group by wheelnumber, heatnumber, grindstatus, mcnoperation, wheelstatus, sl_no order by sl_no desc "
        cmd.CommandText = "select top 1 @cnt = count(*), @grindstatus = grind_status, @mcnoperation = mcn_operation, @wheelstatus = wheel_status from mm_magnaglow_results where wheel_number = @wheelnumber and heat_number = @heatnumber group by wheel_number, heat_number, grind_status, mcn_operation, wheel_status, sl_no order by sl_no desc "
        cmd.Parameters.Add("@wheelnumber", SqlDbType.BigInt, 8)
        cmd.Parameters.Add("@heatnumber", SqlDbType.BigInt, 8)
        cmd.Parameters.Add("@cnt", SqlDbType.Int, 4)
        cmd.Parameters("@wheelnumber").Direction = ParameterDirection.Input
        cmd.Parameters("@heatnumber").Direction = ParameterDirection.Input
        cmd.Parameters.Add("@wheelstatus", SqlDbType.VarChar, 50)
        cmd.Parameters.Add("@mcnoperation", SqlDbType.VarChar, 50)
        cmd.Parameters.Add("@grindstatus", SqlDbType.VarChar, 50)
        cmd.Parameters("@wheelstatus").Direction = ParameterDirection.Output
        cmd.Parameters("@mcnoperation").Direction = ParameterDirection.Output
        cmd.Parameters("@grindstatus").Direction = ParameterDirection.Output
        cmd.Parameters("@cnt").Direction = ParameterDirection.Output
        cmd.Parameters("@wheelnumber").Value = lWheelNumber
        cmd.Parameters("@heatnumber").Value = lHeatNumber
        Dim i As Integer
        Dim sWhlsts As String
        Try
            cmd.Connection.Open()
            cmd.ExecuteScalar()
            i = IIf(IsDBNull(cmd.Parameters("@cnt").Value), 0, cmd.Parameters("@cnt").Value)
            If IsNothing(i) Then i = 0
            If i = 0 Then
                cmd.CommandText = "select top 1 @cnt = count(*), @grindstatus = grind_status, @mcnoperation = mcn_operation, @wheelstatus = wheel_status from mm_magnaglow_results where wheel_number = @wheelnumber and heat_number = @heatnumber group by wheel_number, heat_number,grind_status, mcn_operation, wheel_status, sl_no   order by sl_no desc "
                cmd.ExecuteScalar()
            End If
            If IsNothing(i) OrElse IsDBNull(i) Then i = 0
            If i > 0 Then
                sWhlsts = IIf(IsDBNull(cmd.Parameters("@Wheelstatus").Value), "", cmd.Parameters("@Wheelstatus").Value.Trim.ToLower)
                sMcnOpn = IIf(IsDBNull(cmd.Parameters("@mcnoperation").Value), "", cmd.Parameters("@mcnoperation").Value.Trim.ToLower)
                sGrindSts = IIf(IsDBNull(cmd.Parameters("@grindstatus").Value), "", cmd.Parameters("@grindstatus").Value.Trim.ToLower)
                If sMcnOpn.EndsWith("/p") Then
                    cmd.CommandText = "select count(*) from mm_vw_notVerifiedYardInsp_Wheels where wheelnumber = @wheelnumber and heatnumber = @heatnumber"
                    If cmd.ExecuteScalar > 0 Then
                        sMcnOpn &= " (Under Yard Insp)"
                    End If
                End If
                cmd.CommandText = "select @waitingfrom = NotVerifiedFrom, @wheeldisposition = wheeldisposition from mm_vw_notVerifiedYardInsp_Wheels where wheelnumber = @wheelnumber and heatnumber = @heatnumber"
                cmd.Parameters.Add("@wheeldisposition", SqlDbType.VarChar, 50)
                cmd.Parameters.Add("@waitingfrom", SqlDbType.SmallDateTime, 4)
                cmd.Parameters("@waitingfrom").Direction = ParameterDirection.Output
                cmd.Parameters("@wheeldisposition").Direction = ParameterDirection.Output
                cmd.ExecuteScalar()
                If IsDBNull(cmd.Parameters("@wheeldisposition").Value) = False AndAlso CStr(cmd.Parameters("@wheeldisposition").Value).StartsWith("XC") Then
                    sWhlsts = cmd.Parameters("@wheeldisposition").Value & " from : " & CDate(cmd.Parameters("@waitingfrom").Value).Date.ToString & " in Yard (Under Verification)"
                    blnCanNotBeProced = True
                End If
            Else
                sWhlsts = ""
                sMcnOpn = ""
                sGrindSts = ""
            End If
        Catch exp As Exception
            blnCanNotBeProced = True
            sWhlsts = ""
            sMcnOpn = ""
            sGrindSts = ""
            Throw New Exception(exp.Message)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
        End Try
        If sWhlsts.StartsWith("stoc") = False Then ' to accommodate old wheels having stoc marked instead of stock corrected on 8.5.07 svi
            blnCanNotBeProced = True
            Dim msg As String
            msg = "Wheel NOT stocked by Magna : " & lWheelNumber.ToString & "/" & lHeatNumber.ToString & " "
            If sMcnOpn.Trim.Length > 0 Then msg = msg + "McnOperation : " & sMcnOpn.ToUpper
            If sGrindSts.Trim.Length > 0 Then msg = msg + " Grind Sts: " & sGrindSts.ToUpper
            If sWhlsts.Trim.Length > 0 Then msg = msg + " Wheel Status : " & sWhlsts.ToUpper
            If sGrindSts <> "" And sWhlsts.StartsWith("XC") = False Then
                blnGrindingWheel = True
            Else
                blnGrindingWheel = False
            End If
            If blnMcnedWheel = True Then
                If blnAllowRejOfMagWheel = False Then
                    msg = msg + " Check Allow Hold Wheel Rejection and re-enter Wheel & Heat Nos."
                Else
                    If blnCanNotBeProced = True Then
                        blnCanNotBeProced = False
                    End If
                End If
            End If
            sMessage = msg
            If blnCanNotBeProced Then
                Throw New Exception(msg)
            Else
                msg = Nothing
            End If
        End If
        i = Nothing
        sWhlsts = Nothing
    End Sub
    Private Sub yardwhl()
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.CommandText = "select top 1 'Yard Inspection Status : ' + rtrim(wheel_disposition) + ' on ' + convert(varchar(11),yard_inspection_date,103)+ ' Wheel ' from mm_yard_inspection " & _
        " where wheel_number = @wheelnumber and heat_number = @heatnumber order by sl_no desc"
        cmd.Parameters.Add("@wheelnumber", SqlDbType.BigInt, 8)
        cmd.Parameters.Add("@heatnumber", SqlDbType.BigInt, 8)
        cmd.Parameters("@wheelnumber").Value = lWheelNumber
        cmd.Parameters("@heatnumber").Value = lHeatNumber
        Dim sWhlDisp As String
        Try
            cmd.Connection.Open()
            sWhlDisp = cmd.ExecuteScalar
            If IsNothing(sWhlDisp) Then sWhlDisp = ""
        Catch exp As Exception
            blnCanNotBeProced = True
            sWhlDisp = ""
            Throw New Exception(exp.Message)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
        End Try
        If sWhlDisp <> "" Then
            If sWhlDisp.IndexOf("Yard Inspection Status : W") >= 0 Then
                blnYardHold = True
            Else
                blnYardHold = False
            End If
            blnCanNotBeProced = blnYardHold = False
            Dim msg As String
            msg = "Already " & sWhlDisp & " : " & lWheelNumber.ToString & "/" & lHeatNumber.ToString
            Throw New Exception(msg)
        End If
        sWhlDisp = Nothing
    End Sub
    ReadOnly Property DayTarget() As Integer
        Get
            Return iDayTarget
        End Get
    End Property
    Private Sub TypeChange()
        If IsNothing(sWheelType) Then Throw New Exception("InValid Wheel Type !")
        sWheelType = sDescr.Trim
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        If blnHTMcnedWheel = False Then
            da.SelectCommand.CommandText = "select McnMinDia MinTD, MaxTreadDia MaxTD, " & _
                         " minBoreDia MinBore, MaxBoreDia MaxBore, OverSizeMin BOS_Min , OversizeMax BOS_Max , MinPlateThickness MinPT, " & _
                         " MaxPlateThickness MaxPT , minHubLen MinHL , maxHubLen MaxHL , minRimTh MinRT , " & _
                         " maxRimTh MaxRT , minHubProj MinHP , maxHubProj MaxHP " & _
                         " from mm_ProductwiseTreadAndBoreSizes a inner join mm_product_master b " & _
                         " on a.productcode = b.Product_code " & _
                         " where minTreadDia is not null and b.description like '" & sWheelType.Trim & "%'"
        Else
            da.SelectCommand.CommandText = "select MinTreadDia MinTD, MaxTreadDia MaxTD, " & _
                         " minBoreDia MinBore, MaxBoreDia MaxBore, OverSizeMin BOS_Min , OversizeMax BOS_Max , MinPlateThickness MinPT, " & _
                         " MaxPlateThickness MaxPT , minHubLen MinHL , maxHubLen MaxHL , minRimTh MinRT , " & _
                         " maxRimTh MaxRT , minHubProj MinHP , maxHubProj MaxHP " & _
                         " from mm_ProductwiseTreadAndBoreSizes a inner join mm_product_master b " & _
                         " on a.productcode = b.Product_code " & _
                         " where minTreadDia is not null and b.description like '" & sWheelType.Trim & "%'"
        End If

        Dim ds As New DataSet()
        Try
            da.Fill(ds, "InspParams")
            tblInspParams = ds.Tables("InspParams").Copy
        Catch exp As Exception
            tblInspParams = Nothing
            blnCanNotBeProced = True
        Finally
            da.Dispose()
            ds.Dispose()
            da = Nothing
            ds = Nothing
        End Try
    End Sub
    Public Function InspParams() As DataTable
        TypeChange()
        Return tblInspParams
    End Function
    Private Sub NMWheel()
        blnCanNotBeProced = True
        sMessage = "Wheel not in master " & lWheelNumber.ToString & "/" & lHeatNumber.ToString
        Throw New Exception(sMessage)
    End Sub
    ReadOnly Property WheelNumber() As String
        Get
            Return lWheelNumber.ToString.Trim
        End Get
    End Property
    ReadOnly Property HeatHumber() As String
        Get
            Return lHeatNumber.ToString.Trim
        End Get
    End Property
    Property InspectorEmpCode() As String
        Get
            Return sInspectorEmpCode
        End Get
        Set(ByVal Value As String)
            sInspectorEmpCode = Value
            If sInspectorEmpCode = "" Then
                Throw New Exception("Invalid Employee code")
            End If
        End Set
    End Property
    ReadOnly Property InspDate() As Date
        Get
            Return dInspDate
        End Get
    End Property
    Public Sub GeneralShift(ByVal Yes As Boolean, Optional ByVal Lock As Boolean = False)
        If Yes Then
            sShift = "G"
        Else
            If Lock = False Then
                GetShiftCode()
            End If
        End If
    End Sub
    ReadOnly Property ShiftCode() As String
        Get
            Return sShift
        End Get
    End Property
    Private Sub GetDate()
        Dim lastHoliday As Date
        LastUpDate = Today.Date
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.CommandText = "select top 1 inspection_date from mm_final_inspection a , (select top 1 * from mm_pink_sheet order by pink_date desc ) b where inspection_date >= pink_date order by a.inspection_date desc"
        Try
            cmd.Connection.Open()
            LastUpDate = cmd.ExecuteScalar
            cmd.CommandText = "Select top 1 date from mm_calendar_dump where dateadd(hh,8,date) between @dt and getdate() and shop = 'clcl' order by date desc"
            cmd.Parameters.Add("@dt", SqlDbType.SmallDateTime, 4)
            cmd.Parameters("@dt").Value = LastUpDate
            lastHoliday = cmd.ExecuteScalar
        Catch exp As Exception
            LastUpDate = Today.Date
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
        End Try
        If lastHoliday >= LastUpDate Then
            LastUpDate = lastHoliday.AddDays(1)
        End If
        dInspDate = LastUpDate
        GetShiftCode()
        GetDayTarget()
        GetMonthTarget()
        GetCumGoodWheels()
        GetDayGoodWheels()
        dBkupDate = dInspDate
        sBkupShift = sShift
        lastHoliday = Nothing
    End Sub
    Enum RejRew
        Rejection_Codes
        Rework_codes
    End Enum
    ReadOnly Property DayGoodWheels() As Integer
        Get
            Return iDayActual
        End Get
    End Property
    Public Sub GetDayGoodWheels()
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.CommandText = "select wap.dbo.mm_fn_Daily_WheelProduction(@dt)"
        cmd.Parameters.Add("@dt", SqlDbType.SmallDateTime, 4)
        cmd.Parameters("@dt").Direction = ParameterDirection.Input
        cmd.Parameters("@dt").Value = dInspDate
        Try
            cmd.Connection.Open()
            iDayActual = cmd.ExecuteScalar
        Catch exp As Exception
            iDayActual = -1
            Throw New Exception(exp.Message)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
        End Try
    End Sub
    ReadOnly Property CumGoodWheels() As Integer
        Get
            Return iMonthActuals
        End Get
    End Property
    Public Sub GetCumGoodWheels()
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.CommandText = "select wap.dbo.mm_fn_Monthly_WheelProduction(" & dInspDate.Month & "," & dInspDate.Year & ")"
        Try
            cmd.Connection.Open()
            iMonthActuals = cmd.ExecuteScalar
        Catch exp As Exception
            iMonthActuals = -1
            Throw New Exception(exp.Message)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
        End Try
    End Sub
    Private Sub GetMonthTarget()
        'select wap.dbo.mm_si_fn_GetMonthly_RB_Targets(11,2006,'w',0)
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        'cmd.CommandText = "select wap.dbo.mm_si_fn_GetMonthly_RB_Targets(" & dInspDate.Month & ", " & dInspDate.Year & ", 'w','0')"
        cmd.CommandText = "select wap.dbo.mm_si_fn_GetMonthlyTargets(" & dInspDate.Month & ", " & dInspDate.Year & ", 'w','0')"
        Try
            cmd.Connection.Open()
            iMonthTarget = cmd.ExecuteScalar
        Catch exp As Exception
            iMonthTarget = -1
            Throw New Exception(exp.Message)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
        End Try
    End Sub
    ReadOnly Property MonthTarget() As Integer
        Get
            Return iMonthTarget
        End Get
    End Property
    ReadOnly Property MagProced() As Integer
        Get
            Return iMagProced
        End Get
    End Property
    ReadOnly Property MagStocked() As Integer
        Get
            Return iMagStocked
        End Get
    End Property
    Public Sub MagScore()
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.CommandText = "select @Proced = isnull(sum(isnull(Processed,0)),0) , @Stocked = isnull(sum(isnull(Stocked,0)),0)  from (select wheelnumber, heatnumber, case when linenumber like '1%' then 1 else 0 end Processed, case when wheelstatus like 'sto%' then 1 else 0 end Stocked from mm_magnaglow_shiftwiseRecords where testdate = @dt and shiftcode = '" & sShift & "' ) a "
        cmd.Parameters.Add("@Stocked", SqlDbType.Int, 4)
        cmd.Parameters.Add("@Proced", SqlDbType.Int, 4)
        cmd.Parameters("@Stocked").Direction = ParameterDirection.Output
        cmd.Parameters("@Proced").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@dt", SqlDbType.SmallDateTime, 4)
        cmd.Parameters("@dt").Direction = ParameterDirection.Input
        Try
            cmd.Parameters("@dt").Value = dInspDate
            cmd.Connection.Open()
            cmd.ExecuteScalar()
            iMagProced = cmd.Parameters("@Proced").Value
            iMagStocked = cmd.Parameters("@Stocked").Value
        Catch exp As Exception
            iMagProced = -1
            iMagStocked = -1
            Throw New Exception(exp.Message)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
        End Try
    End Sub
    Private Sub GetDayTarget()
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Dim sFinYr As String
        cmd.CommandText = "select wap.dbo.mm_fn_si_GetFinYear('" & Format(dInspDate, "yyyy-MM-dd") & "') finyr"
        cmd.CommandType = CommandType.Text
        Try
            cmd.Connection.Open()
            sFinYr = cmd.ExecuteScalar
            'cmd.CommandText = "select wap.dbo.mm_si_fn_GetDayAnnual_RB_Targets ('" & sFinYr & "', 'W', 'Good'," & dInspDate.Month & ")"
            cmd.CommandText = "select wap.dbo.mm_si_fn_GetDayAnnualTargets ('" & sFinYr & "', 'W', 'Good'," & dInspDate.Month & ")"
            iDayTarget = cmd.ExecuteScalar
        Catch exp As Exception
            iDayTarget = -1
            Throw New Exception(exp.Message)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
        End Try
        sFinYr = Nothing
    End Sub
    Private Sub GetShiftCode()
        Dim dt As Date
        dt = Now
        Select Case dt.Hour
            Case 6 To 13
                sShift = "A"
                If dInspDate <> Today.Date Then
                    dInspDate = Today.Date
                End If
            Case 14 To 21
                sShift = "B"
                If dInspDate <> Today.Date Then
                    dInspDate = Today.Date
                End If
            Case Else
                sShift = "C"
        End Select
        If blnContinueShift Then
            dInspDate = getlastInspDate()
            sShift = "C"
        End If
        dt = Nothing
    End Sub
    Private Function getlastInspDate() As Date
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        ' yrar(now)-1 changed to year(getdate()) 02-05-10
        cmd.CommandText = "Select top 1 @dt = inspection_date from mm_final_inspection where year(inspection_date) >= year(getdate())-1 order by sl_no desc"
        cmd.Parameters.Add("@dt", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output
        Try
            cmd.Connection.Open()
            cmd.ExecuteScalar()
            getlastInspDate = IIf(IsDBNull(cmd.Parameters("@dt").Value), dInspDate.Subtract(New TimeSpan(1, 0, 0, 0)), cmd.Parameters("@dt").Value)
        Catch exp As Exception
            getlastInspDate = dInspDate.Subtract(New TimeSpan(1, 0, 0, 0))
        Finally
            If IsNothing(cmd) = False Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End If
        End Try
    End Function
    ReadOnly Property WheelType() As String
        Get
            Return sWheelType.Trim
        End Get
    End Property
    Private Sub resetVars()
        blnCanNotBeProced = False
        sPressed = ""
        sDespatchNoteNumber = ""
        sSetDespatched = ""
        sRemarks = ""
        blnMcnedWheel = False
        sMessage = ""
    End Sub
    ReadOnly Property DrgNo() As String
        Get
            Return sDrgNo.ToUpper
        End Get
    End Property
    ReadOnly Property PCode() As String
        Get
            Return sPCode.ToUpper
        End Get
    End Property
    ReadOnly Property MasterLocation() As String
        Get
            Return strloc.ToUpper
        End Get
    End Property
    ReadOnly Property MagSts() As String
        Get
            Return sMagSts.ToUpper
        End Get
    End Property
    Property AllowRejOfHoldMagWheel() As Boolean
        Get
            Return blnAllowRejOfMagWheel
        End Get
        Set(ByVal Value As Boolean)
            blnAllowRejOfMagWheel = Value
        End Set
    End Property
    Sub CheckWheel(ByVal WheelNumber As Long, ByVal HeatNumber As Long)
        resetVars()
        ShiftContinued()
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Dim stringBuilder As New System.Text.StringBuilder()
        stringBuilder.Append("select @DrgNo = rtrim(drawing_number)  , @PCode = b.product_code , @location = rtrim(location) , " & _
            " @status = rtrim(a.status) , @despatch_note_number = rtrim(despatch_note_number) , @press_status = rtrim(press_status) , " & _
            " @Description = rtrim(a.Description) , @MagSts = rtrim(Magnaglow_Status) , @BHNValue = BHN_Rate " & _
            " from mm_wheel a inner join mm_workorder b on workorder_melt_mould = number " & _
            " inner join mm_product_master c on b.product_code = c.product_code " & _
            " where wheel_number = " & WheelNumber & " and heat_number = " & HeatNumber)
        cmd.Parameters.Add("@DrgNo", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
        cmd.Parameters.Add("@PCode", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
        cmd.Parameters.Add("@press_status", SqlDbType.VarChar, 1).Direction = ParameterDirection.Output
        cmd.Parameters.Add("@status", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
        cmd.Parameters.Add("@location", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
        cmd.Parameters.Add("@despatch_note_number", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
        cmd.Parameters.Add("@Description", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
        cmd.Parameters.Add("@wheelnumber", SqlDbType.BigInt, 8).Value = WheelNumber
        cmd.Parameters.Add("@heatnumber", SqlDbType.BigInt, 8).Value = HeatNumber
        cmd.Parameters.Add("@MagSts", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
        cmd.Parameters.Add("@BHNValue", SqlDbType.Int, 4).Direction = ParameterDirection.Output
        cmd.Parameters.Add("@MinWhlNo", SqlDbType.Int, 4).Direction = ParameterDirection.Output
        cmd.Parameters.Add("@MaxWhlNo", SqlDbType.Int, 4).Direction = ParameterDirection.Output
        lWheelNumber = WheelNumber
        lHeatNumber = HeatNumber
        Dim msg As String
        Try
            cmd.Connection.Open()
            cmd.CommandText = stringBuilder.ToString
            cmd.ExecuteScalar()
            sDrgNo = IIf(IsDBNull(cmd.Parameters("@DrgNo").Value), "", cmd.Parameters("@DrgNo").Value)
            sPCode = IIf(IsDBNull(cmd.Parameters("@PCode").Value), "", cmd.Parameters("@PCode").Value)
            strloc = IIf(IsDBNull(cmd.Parameters("@Location").Value), "", cmd.Parameters("@Location").Value)
            strSts = IIf(IsDBNull(cmd.Parameters("@status").Value), "", cmd.Parameters("@status").Value)
            sMagSts = IIf(IsDBNull(cmd.Parameters("@MagSts").Value), "", cmd.Parameters("@MagSts").Value)
            iBHNValue = IIf(IsDBNull(cmd.Parameters("@BHNValue").Value), 0, cmd.Parameters("@BHNValue").Value)
            If IsNothing(strloc) Then strloc = ""
            strloc = strloc.Trim
            sDescr = IIf(IsDBNull(cmd.Parameters("@Description").Value), "", cmd.Parameters("@Description").Value)
            sDescr = IIf(IsNothing(sDescr), "", sDescr)

            sDespatchNoteNumber = IIf(IsDBNull(cmd.Parameters("@despatch_note_number").Value), "", cmd.Parameters("@despatch_note_number").Value)
            If IsDBNull(cmd.Parameters("@press_status").Value) Then
                sPressed = ""
            ElseIf cmd.Parameters("@Press_status").Value = " " Then
                sPressed = " ( Pressed and Demuonted ) "
            ElseIf cmd.Parameters("@Press_status").Value = "M" Then
                sPressed = " (Pressed) "
            End If
            cmd.CommandText = ""
            cmd.CommandText = "select @MinWhlNo = MinWhlNo , @MaxWhlNo = MaxWhlNo from mm_Product_details where description = '" & sDescr.Trim & "' "
            cmd.ExecuteScalar()
            lMinWhlNo = IIf(IsDBNull(cmd.Parameters("@MinWhlNo").Value), 0, cmd.Parameters("@MinWhlNo").Value)
            lMaxWhlNo = IIf(IsDBNull(cmd.Parameters("@MaxWhlNo").Value), 0, cmd.Parameters("@MaxWhlNo").Value)

            'If sDescr.Trim = "B25T" Then
            '    lMinWhlNo = 1000
            '    lMaxWhlNo = 1100
            'ElseIf sDescr.Trim = "FBCLHB" Then
            '    lMinWhlNo = 1101
            '    lMaxWhlNo = 1199
            'ElseIf sDescr.Trim = "METRO(866 Dia)" Then
            '    lMinWhlNo = 1200
            '    lMaxWhlNo = 1299
            'Else
            '    lMinWhlNo = 1
            '    lMaxWhlNo = 999
            'End If

            If iBHNValue <= 0 Then
                blnCanNotBeProced = True
            End If
            If strloc = "" Then
                ' sMessage = "Wheel Not in Master : " & lWheelNumber.ToString + "/" + lHeatNumber.ToString
                ' Throw New Exception(sMessage)
            End If

            If IsNothing(sDespatchNoteNumber) OrElse IsDBNull(sDespatchNoteNumber) Then
                sDespatchNoteNumber = ""
            Else
                sDespatchNoteNumber = sDespatchNoteNumber.Trim
            End If

            If IsNothing(sWheelType) OrElse IsDBNull(sWheelType) Then
                sWheelType = ""
            Else
                sWheelType = sWheelType.Trim
            End If

            If sWheelType <> sDescr Then RaiseEvent WheelTypeChanged()
            Select Case strloc
                Case "CLMT" : RaiseEvent MagnaWheel()
                Case "CLQC" : RaiseEvent YardWheel()
                Case "CLFI" : RaiseEvent FinalWheel()
                Case "CLFQ" : RaiseEvent QCIWheel()
                Case "MOPO" : RaiseEvent MouldRoomWheel()
                Case "" : RaiseEvent NotInMaster()
            End Select

            If iBHNValue <= 0 Then ' added on 4/8/07 svi on SSE/Insp request to avoid no bhn wheels passing 
                If blnMagNotTested = False Then
                    sMessage = "No BHN for the wheel"
                Else
                    sMessage = "Wheel Not Tested In Magna"
                End If
                Throw New Exception(sMessage)
            End If
        Catch exp As Exception
            If sDespatchNoteNumber = "" Then
                If exp.Message.IndexOf("Passed") >= 0 Then
                    RaiseEvent CheckSetDesp()
                End If
                Throw New Exception(exp.Message & " " & sPressed & " " & sSetDespatched)
            Else
                If lWheelNumber > 0 Then
                    Throw New Exception(exp.Message & " " & sPressed & " (Despatched)" & " " & sSetDespatched)
                Else
                    Throw New Exception(exp.Message & ". Keep wheel aside and contact MIS")
                End If
            End If
        Catch exp1 As SqlClient.SqlException
            blnCanNotBeProced = True
            If sDespatchNoteNumber = "" Then
                If exp1.Message.IndexOf("Passed") >= 0 Then
                    RaiseEvent CheckSetDesp()
                End If
                If lWheelNumber > 0 Then
                    Throw New Exception(exp1.Message & " : " & WheelNumber.ToString & "/" & HeatNumber.ToString & " " & sPressed & " " & sSetDespatched)
                Else
                    Throw New Exception(exp1.Message & " : . Keep wheel aside and contact MIS")
                End If
            Else
                If lWheelNumber > 0 Then
                    Throw New Exception(exp1.Message & " : " & WheelNumber.ToString & "/" & HeatNumber.ToString & " " & sPressed & " (Despatched)" & " " & sSetDespatched)
                Else
                    Throw New Exception(exp1.Message & " : . Keep wheel aside and contact MIS")
                End If
            End If
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
            If blnCanNotBeProced = True Then
                lWheelNumber = 0
                lHeatNumber = 0
            End If
        End Try
        msg = Nothing
        stringBuilder = Nothing
    End Sub
    Private Sub SetDespatch()
        If sDespatchNoteNumber <> "" Then
            Exit Sub
        End If
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.CommandText = "select count(*) from mm_vw_despatched_sets1 where convert(varchar,@wheelnumber) +'/'+ convert(varchar,@heatnumber) in (east_wheel_number, west_wheel_number)"
        cmd.Parameters.Add("@wheelnumber", SqlDbType.BigInt, 8)
        cmd.Parameters.Add("@heatnumber", SqlDbType.BigInt, 8)
        cmd.Parameters("@wheelnumber").Direction = ParameterDirection.Input
        cmd.Parameters("@heatnumber").Direction = ParameterDirection.Input
        cmd.Parameters("@wheelnumber").Value = lWheelNumber
        cmd.Parameters("@heatnumber").Value = lHeatNumber
        Dim i As Integer
        Try
            cmd.Connection.Open()
            i = cmd.ExecuteScalar
            If IsNothing(i) Then i = 0
            If i > 0 Then
                blnCanNotBeProced = True
                sSetDespatched = " (Despatched in Set) "
            Else
                sSetDespatched = ""
            End If
        Catch exp As Exception
            i = 0
            blnCanNotBeProced = True
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
        End Try
    End Sub
    Public Function SieveAnalysis() As DataTable
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        da.SelectCommand.CommandText = "select " & _
        " 'Test Date: ' + convert(varchar(11),a.test_date,103) + ' for : ' +  rtrim(a.sample_number)+ ' '  +  " & _
        " rtrim(a.Sample_Batch_number)+' Result_value :' + b.result_value   SieveAnalysis " & _
        " from ms_test_sample a inner join ms_test_result b on a.lab_number = b.lab_number  " & _
        " where b.characteristic_code = 10047 " & _
        " and a.test_date = (select max(c.test_date) from ms_test_sample c " & _
        " inner join ms_test_result d on c.lab_number = d.lab_number where d.characteristic_code = 10047 ) " & _
        " order by a.lab_number desc "
        Dim ds As New DataSet()
        Try
            da.Fill(ds, "SieveAnalysisTable")
            SieveAnalysis = ds.Tables("SieveAnalysisTable")
        Catch exp As Exception
            SieveAnalysis = Nothing
            Throw New Exception(exp.Message)
        Finally
            da.Dispose()
            da.Dispose()
            ds = Nothing
            ds = Nothing
        End Try
    End Function
    Public Function isHTMachinedWheel() As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.CommandText = "select count(*) from mm_magnaglow_results where mcn_operation like '%ht%' and wheel_number = @wheel_number and heat_number = @heat_number"
        cmd.Parameters.Add("@wheel_number", SqlDbType.BigInt, 8)
        cmd.Parameters.Add("@Heat_number", SqlDbType.BigInt, 8)
        cmd.Parameters("@wheel_number").Direction = ParameterDirection.Input
        cmd.Parameters("@heat_number").Direction = ParameterDirection.Input
        cmd.Parameters("@wheel_number").Value = lWheelNumber
        cmd.Parameters("@heat_number").Value = lHeatNumber
        Try
            cmd.Connection.Open()
            If cmd.ExecuteScalar > 0 Then
                isHTMachinedWheel = True
                blnHTMcnedWheel = isHTMachinedWheel
                blnMcnedWheel = True
            Else
                isHTMachinedWheel = False
            End If
        Catch exp As Exception
            isHTMachinedWheel = False
            blnHTMcnedWheel = False
            Throw New Exception(exp.Message)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
        End Try
    End Function
    Private Sub FIWheel()
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.CommandText = "select case when a.wheel_status like 'p%' then 'Already Passed on ' " & _
        " when a.wheel_status like 'r%' then 'Already Rejected on ' else a.wheel_status + ' in Final Inspection on ' end + convert(varchar(11), a.Inspection_date, 103)+' '+rtrim(a.shift_code) + case when b.bore_status like 'u%' then '(UnBore)' else '' end Msg " & _
        " from mm_final_Inspection a inner join mm_wheel b on a.wheel_number = b.wheel_number and a.heat_number = b.heat_number where ( ( a.wheel_number = @WheelNumber and a.heat_number = @heatNumber)  and ( a.wheel_status like 'p%' or a.wheel_status like 'r%' or a.wheel_status like 'w%' ) )"
        cmd.Parameters.Add("@WheelNumber", SqlDbType.BigInt, 8)
        cmd.Parameters.Add("@HeatNumber", SqlDbType.BigInt, 8)
        cmd.Parameters("@WheelNumber").Direction = ParameterDirection.Input
        cmd.Parameters("@HeatNumber").Direction = ParameterDirection.Input
        cmd.Parameters("@WheelNumber").Value = lWheelNumber
        cmd.Parameters("@HeatNumber").Value = lHeatNumber
        Dim msg As String
        Try
            cmd.Connection.Open()
            msg = cmd.ExecuteScalar()
            If IsDBNull(msg) Then msg = ""
            If msg = "" Then
                blnCanNotBeProced = True
                Throw New Exception("Cannot Processed : " & lWheelNumber.ToString & "/" & lHeatNumber.ToString)
            ElseIf msg.StartsWith("Already") = True Then
                blnCanNotBeProced = True
                Throw New Exception(msg & " : " & lWheelNumber.ToString & "/" & lHeatNumber.ToString)
            Else
                Throw New Exception(msg)
            End If
        Catch exp As SqlClient.SqlException
            Throw New Exception(exp.Message & lWheelNumber.ToString & "/" & lHeatNumber.ToString)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
            msg = Nothing
        End Try
    End Sub
    Public Function RejRewCodeTable(ByVal TableFor As RejRew) As DataTable
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        If TableFor = RejRew.Rejection_Codes Then
            da.SelectCommand.CommandText = "select (rej_code +'--'+ rej_desc) as rjtype_desc,rej_code from mm_vw_FI_mmrjd_dump where location like '%CLFI%' order by rej_code "
        ElseIf TableFor = RejRew.Rework_codes Then
            da.SelectCommand.CommandText = "select (mcn_type +'--'+ mcn_desc) as mctype_desc,mcn_type from mm_vw_FI_mmload_dump where mcn_desc like '%(FI%' order by mcn_type "
        Else
            RejRewCodeTable = Nothing
        End If
        Try
            da.Fill(ds)
            RejRewCodeTable = ds.Tables(0)
        Catch exp As Exception
            blnCanNotBeProced = True
            RejRewCodeTable = Nothing
        Finally
            da.Dispose()
            ds.Dispose()
        End Try
        ds = Nothing
        da = Nothing
    End Function
    Public Function ShiftScore() As DataTable
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        da.SelectCommand.CommandText = "mm_sp_si_fi_ShiftScore"
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.Parameters.Add("@dt", SqlDbType.SmallDateTime, 4)
        da.SelectCommand.Parameters.Add("@shift", SqlDbType.VarChar, 1)
        da.SelectCommand.Parameters("@dt").Direction = ParameterDirection.Input
        da.SelectCommand.Parameters("@shift").Direction = ParameterDirection.Input
        da.SelectCommand.Parameters("@dt").Value = dInspDate
        da.SelectCommand.Parameters("@shift").Value = sShift
        Dim ds As New DataSet()
        Try
            da.Fill(ds, "ShiftScore")
            ShiftScore = ds.Tables("ShiftScore")
        Catch exp As Exception
            ShiftScore = Nothing
        Finally
            da.Dispose()
            ds.Dispose()
            ds = Nothing
            da = Nothing
        End Try
    End Function
    ReadOnly Property Is20thWheel() As Boolean
        Get
            Return bln20thWheel
        End Get
    End Property
    ReadOnly Property IsTwentiethWheel() As Boolean
        Get
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.CommandText = "mm_sp_twentiethPassedWheel"
            cmd.CommandType = CommandType.StoredProcedure
            Try
                cmd.Connection.Open()
                Dim i As Integer = cmd.ExecuteScalar()
                If IsNothing(i) Then i = 0
                IsTwentiethWheel = i >= 20
                bln20thWheel = i >= 20
                i = Nothing
            Catch exp As Exception
                bln20thWheel = False
                IsTwentiethWheel = False
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Get
    End Property
    Function FirstWheelInCopeOrDrag(ByVal WheelNumber As Long, ByVal HeatNumber As Long) As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.CommandText = "select count(*) from mm_pouring a left outer join mm_final_inspection b " & _
        " on a.engraved_number = b.wheel_number and a.heat_number = b.heat_number where " & _
        " ( (a.engraved_number = " & WheelNumber & " and a.heat_number = " & HeatNumber & ") and (a.cope_used = 1 or a.drag_used = 1 ))"
        cmd.CommandType = CommandType.Text
        Try
            cmd.Connection.Open()
            Dim i As Integer = cmd.ExecuteScalar()
            If IsNothing(i) Then i = 0
            FirstWheelInCopeOrDrag = i > 0
            bln1stWhlInCopeOrDrag = i > 0
            i = Nothing
        Catch exp As Exception
            bln1stWhlInCopeOrDrag = False
            FirstWheelInCopeOrDrag = False
            Throw New Exception(exp.Message)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
        End Try
    End Function
    Public Function SavedDataTable(Optional ByVal InspDate As Date = #1/1/1900#, Optional ByVal InspShift As String = "Z", Optional ByVal NotLoadedWheels As Boolean = False) As DataTable
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        If NotLoadedWheels = False Then
            If InspDate = #1/1/1900# Then
                da.SelectCommand.CommandText = "select convert(varchar, a.wheel_number) +'/'+convert(varchar, a.heat_number) Whl," & _
                         " a.Tread_Diameter TD, a.Bore_Status Bore, b.Bore_diameter BD, a.Plate_Thickness PT, a.Rim_Thickness Rim, a.RotundityCheck_Size RdtySize, a.RotundityCheck_BOC_Size RdtyBoc, " & _
                         " a.Wheel_status WhlSts, a.remarks  from mm_final_Inspection a inner join mm_wheel b on " & _
                         " a.wheel_number = b.wheel_number and a.heat_number = b.heat_number where  " & _
                         " a.inspection_date = '" & Format(dInspDate, "yyyy-MM-dd") & "' and shift_code = '" & sShift & "' order by a.sl_no desc"
            Else
                da.SelectCommand.CommandText = "select convert(varchar, a.wheel_number) +'/'+convert(varchar, a.heat_number) Whl," & _
             " a.Tread_Diameter TD, a.Bore_Status Bore, b.Bore_diameter BD, a.Plate_Thickness PT, a.Rim_Thickness Rim, a.RotundityCheck_Size RdtySize, a.RotundityCheck_BOC_Size RdtyBoc, " & _
             " a.Wheel_status WhlSts, a.remarks  from mm_final_Inspection a inner join mm_wheel b on " & _
             " a.wheel_number = b.wheel_number and a.heat_number = b.heat_number where  " & _
             " a.inspection_date = '" & Format(InspDate, "yyyy-MM-dd") & "' and shift_code = '" & InspShift & "' order by a.sl_no desc"
            End If
        Else
            'mm_fn_StockWhlsNotInspected
            da.SelectCommand.CommandText = "select * from mm_fn_StockWhlsNotInspected(@Dt, @FrDt, @ToDt)"
            da.SelectCommand.Parameters.Add("@dt", SqlDbType.SmallDateTime, 4)
            da.SelectCommand.Parameters.Add("@FrDt", SqlDbType.DateTime, 8)
            da.SelectCommand.Parameters.Add("@ToDt", SqlDbType.DateTime, 8)

            da.SelectCommand.Parameters("@dt").Direction = ParameterDirection.Input
            da.SelectCommand.Parameters("@FrDt").Direction = ParameterDirection.Input
            da.SelectCommand.Parameters("@ToDt").Direction = ParameterDirection.Input

            If InspDate = #1/1/1900# Then
                da.SelectCommand.Parameters("@dt").Value = dInspDate
                Dim FrTmSpan As TimeSpan
                Select Case sShift
                    Case "A"
                        FrTmSpan = New TimeSpan(6, 0, 0)
                    Case "B"
                        FrTmSpan = New TimeSpan(14, 0, 0)
                    Case "C"
                        FrTmSpan = New TimeSpan(22, 0, 0)
                End Select
                da.SelectCommand.Parameters("@FrDt").Value = dInspDate.Add(FrTmSpan)
                da.SelectCommand.Parameters("@ToDt").Value = dInspDate.Add(FrTmSpan).AddHours(8).AddSeconds(-1)
            Else
                Dim FrTmSpan As TimeSpan
                Select Case InspShift
                    Case "A"
                        FrTmSpan = New TimeSpan(6, 0, 0)
                    Case "B"
                        FrTmSpan = New TimeSpan(14, 0, 0)
                    Case "C"
                        FrTmSpan = New TimeSpan(22, 0, 0)
                End Select
                da.SelectCommand.Parameters("@FrDt").Value = InspDate.Add(FrTmSpan)
                da.SelectCommand.Parameters("@ToDt").Value = InspDate.Add(FrTmSpan).AddHours(8).AddSeconds(-1)
                da.SelectCommand.Parameters("@FrDt").Value = InspDate
            End If
        End If

        Dim ds As New DataSet()
        Try
            da.Fill(ds, "DataSaved")
            SavedDataTable = ds.Tables("DataSaved")
        Catch exp As Exception
            SavedDataTable = Nothing
            Throw New Exception(exp.Message)
        Finally
            da.Dispose()
            ds.Dispose()
            ds = Nothing
            da = Nothing
        End Try
    End Function
    Public Function NotPassed(Optional ByVal InspDate As Date = #1/1/1900#, Optional ByVal InspShift As String = "Z", Optional ByVal NotLoadedWheels As Boolean = False) As DataTable
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter

        If InspDate = #1/1/1900# Then
            da.SelectCommand.CommandText = "select convert(varchar, a.wheel_number) +'/'+convert(varchar, a.heat_number) Whl," & _
                     " a.Tread_Diameter TD, a.Bore_Status Bore, b.Bore_diameter BD, a.Plate_Thickness PT, a.Rim_Thickness Rim, a.RotundityCheck_Size RdtySize, a.RotundityCheck_BOC_Size RdtyBoc, " & _
                     " a.Wheel_status WhlSts, a.remarks  from mm_final_Inspection a inner join mm_wheel b on " & _
                     " a.wheel_number = b.wheel_number and a.heat_number = b.heat_number where  " & _
                     " a.inspection_date = '" & Format(dInspDate, "yyyy-MM-dd") & "' and shift_code = '" & sShift & "' and a.Wheel_status <> 'PASSED' order by a.Wheel_status"
        Else
            da.SelectCommand.CommandText = "select convert(varchar, a.wheel_number) +'/'+convert(varchar, a.heat_number) Whl," & _
                    " a.Tread_Diameter TD, a.Bore_Status Bore, b.Bore_diameter BD, a.Plate_Thickness PT, a.Rim_Thickness Rim, a.RotundityCheck_Size RdtySize, a.RotundityCheck_BOC_Size RdtyBoc, " & _
                    " a.Wheel_status WhlSts, a.remarks  from mm_final_Inspection a inner join mm_wheel b on " & _
                    " a.wheel_number = b.wheel_number and a.heat_number = b.heat_number where  " & _
                    " a.inspection_date = '" & Format(InspDate, "yyyy-MM-dd") & "' and shift_code = '" & InspShift & "' and a.Wheel_status <> 'PASSED' order by a.Wheel_status"
        End If
        Dim ds As New DataSet()
        Try
            da.Fill(ds, "DataSaved")
            NotPassed = ds.Tables("DataSaved")
        Catch exp As Exception
            NotPassed = Nothing
            Throw New Exception(exp.Message)
        Finally
            da.Dispose()
            ds.Dispose()
            ds = Nothing
            da = Nothing
        End Try
    End Function
    Public Function UpdateWhlParameters(ByVal productcode As String, ByVal MinTD As Decimal, ByVal MaxTD As Decimal, ByVal MinBore As Decimal, ByVal MaxBore As Decimal, ByVal minHubLen As Decimal, ByVal maxHubLen As Decimal, ByVal minRimTh As Decimal, ByVal maxRimTh As Decimal, ByVal minHubProj As Decimal, ByVal maxHubProj As Decimal, ByVal MinPT As Decimal, ByVal MaxPT As Decimal, ByVal McnMinDia As Decimal, ByVal OverSizeMin As Decimal, ByVal OverSizeMax As Decimal, ByVal MinWhlNo As Decimal, ByVal MaxWhlNo As Decimal, ByVal minrimthickness As Decimal) As String
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Dim blnDone As Boolean
        cmd.Parameters.Add("@MinTD", SqlDbType.Decimal, 9, 2).Value = MinTD
        cmd.Parameters.Add("@MaxTD", SqlDbType.Decimal, 9, 2).Value = MaxTD
        cmd.Parameters.Add("@MinBore", SqlDbType.Decimal, 9, 2).Value = MinBore
        cmd.Parameters.Add("@MaxBore", SqlDbType.Decimal, 9, 2).Value = MaxBore
        cmd.Parameters.Add("@minHubLen", SqlDbType.Decimal, 9, 2).Value = minHubLen
        cmd.Parameters.Add("@maxHubLen", SqlDbType.Decimal, 9, 2).Value = maxHubLen
        cmd.Parameters.Add("@minRimTh", SqlDbType.Decimal, 9, 2).Value = minRimTh
        cmd.Parameters.Add("@maxRimTh", SqlDbType.Decimal, 9, 2).Value = maxRimTh
        cmd.Parameters.Add("@minHubProj", SqlDbType.Decimal, 9, 2).Value = minHubProj
        cmd.Parameters.Add("@maxHubProj", SqlDbType.Decimal, 9, 2).Value = maxHubProj
        cmd.Parameters.Add("@MinPT", SqlDbType.Decimal, 9, 2).Value = MinPT
        cmd.Parameters.Add("@MaxPT", SqlDbType.Decimal, 9, 2).Value = MaxPT
        cmd.Parameters.Add("@McnMinDia", SqlDbType.Decimal, 9, 2).Value = McnMinDia
        cmd.Parameters.Add("@productcode", SqlDbType.VarChar, 50).Value = productcode
        cmd.Parameters.Add("@OverSizeMin", SqlDbType.Decimal, 9, 2).Value = OverSizeMin
        cmd.Parameters.Add("@OverSizeMax", SqlDbType.Decimal, 9, 2).Value = OverSizeMax
        cmd.Parameters.Add("@MinWhlNo", SqlDbType.Decimal, 9, 2).Value = MinWhlNo
        cmd.Parameters.Add("@MaxWhlNo", SqlDbType.Decimal, 9, 2).Value = MaxWhlNo
        cmd.Parameters.Add("@minrimthickness", SqlDbType.Decimal, 9, 2).Value = minrimthickness
        Try
            cmd.CommandText = " update mm_ProductwiseTreadAndBoreSizes " &
                " set MinTreadDia  = @MinTD , MaxTreadDia = @MaxTD ,  minBoreDia = @MinBore , MaxBoreDia = @MaxBore , " &
                " minHubLen = @minHubLen , maxHubLen = @maxHubLen , minRimTh = @minRimTh , maxRimTh = @maxRimTh , " &
                " minHubProj = @minHubProj ,  maxHubProj = @maxHubProj, " &
                " MinPlateThickness = @MinPT , MaxPlateThickness = @MaxPT ," &
                " McnMinDia = @McnMinDia , OverSizeMin = @OverSizeMin , OverSizeMax = @OverSizeMax , minrimthickness=@minrimthickness where productcode = @productcode"
            If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
            cmd.Transaction = cmd.Connection.BeginTransaction
            If cmd.ExecuteNonQuery = 1 Then
                cmd.CommandText = " update mm_product_details " &
                       " set MinWhlNo  = @MinWhlNo , MaxWhlNo = @MaxWhlNo where product_code = @productcode"
                If cmd.ExecuteNonQuery = 1 Then blnDone = True
            End If

        Catch exp As Exception
            blnDone = False
            Throw New Exception("Save Error: " & exp.Message)
        Finally
            If blnDone Then
                cmd.Transaction.Commit()
                UpdateWhlParameters = "Updated !"
            Else
                cmd.Transaction.Rollback()
                UpdateWhlParameters &= " Not Updated "
            End If
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
        End Try
        blnDone = Nothing
    End Function
    Public Function UpdateSetTrackGauges(ByVal product_code As String, ByVal Min_Guage As Decimal, ByVal max_Guage As Decimal) As String
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Dim blnDone As Boolean
        cmd.Parameters.Add("@Min_Guage", SqlDbType.Decimal, 9, 2).Value = Min_Guage
        cmd.Parameters.Add("@max_Guage", SqlDbType.Decimal, 9, 2).Value = max_Guage
        cmd.Parameters.Add("@product_code", SqlDbType.VarChar, 50).Value = product_code

        Try
            cmd.CommandText = " update mm_wheelset_Trackguages " & _
                " set Min_Guage  = @Min_Guage , max_Guage = @max_Guage where product_code = @product_code"
            If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
            cmd.Transaction = cmd.Connection.BeginTransaction
            If cmd.ExecuteNonQuery = 1 Then blnDone = True
        Catch exp As Exception
            blnDone = False
            Throw New Exception("Save Error: " & exp.Message)
        Finally
            If blnDone Then
                cmd.Transaction.Commit()
                UpdateSetTrackGauges = "Updated !"
            Else
                cmd.Transaction.Rollback()
                UpdateSetTrackGauges &= " Not Updated "
            End If
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
        End Try
        blnDone = Nothing
    End Function
    Public Function UpdateSetMountPressures(ByVal product_code As String, ByVal min_pressure As Decimal, ByVal max_pressure As Decimal) As String
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Dim blnDone As Boolean
        cmd.Parameters.Add("@min_pressure", SqlDbType.Decimal, 9, 2).Value = min_pressure
        cmd.Parameters.Add("@max_pressure", SqlDbType.Decimal, 9, 2).Value = max_pressure
        cmd.Parameters.Add("@product_code", SqlDbType.VarChar, 50).Value = product_code

        Try
            cmd.CommandText = " update mm_wheelset_mountPressures " & _
                " set min_pressure  = @min_pressure , max_pressure = @max_pressure where product_code = @product_code"
            If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
            cmd.Transaction = cmd.Connection.BeginTransaction
            If cmd.ExecuteNonQuery = 1 Then blnDone = True
        Catch exp As Exception
            blnDone = False
            Throw New Exception("Save Error: " & exp.Message)
        Finally
            If blnDone Then
                cmd.Transaction.Commit()
                UpdateSetMountPressures = "Updated !"
            Else
                cmd.Transaction.Rollback()
                UpdateSetMountPressures &= " Not Updated "
            End If
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
        End Try
        blnDone = Nothing
    End Function
End Class
<Serializable()> Public Class InspWheelDeleteAssistant
    Private FiForm As New InspectionAssistant()
    Private sMessage As String
    Private lWheelNumber, lHeatNumber, lSlNo As Long
    Private blnConfirmDelete As Boolean
    Private sWheel_Status, sBore_Status, sPlate_thickness, sRemarks As String
    Private deciTread_Diameter As Decimal
    Private dsWhlHistory As DataSet
    Private tblLatestData As DataTable
    Public Shared Function DeletedWheelsInShift(ByVal InspDate As Date) As DataTable
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        da.SelectCommand.CommandText = "select Shift_code, Wheel_number, Heat_number, Wheel_status from mm_final_inspection_deleted where inspection_date = @inspDate order by sl_no desc"
        da.SelectCommand.Parameters.Add("@InspDate", InspDate)
        Try
            da.Fill(ds, "DeletedWheels")
            DeletedWheelsInShift = ds.Tables(0)
        Catch exp As Exception
            DeletedWheelsInShift = Nothing
            Throw New Exception("Deleted Wheels Retrieval error : " & exp.Message)
        Finally
            da.Dispose()
            ds.Dispose()
            ds = Nothing
            da = Nothing
        End Try
    End Function
    Private Sub New()
    End Sub
    ReadOnly Property PlateThickness() As String
        Get
            Return sPlate_thickness
        End Get
    End Property
    ReadOnly Property Remarks() As String
        Get
            Return sRemarks
        End Get
    End Property
    ReadOnly Property Message() As String
        Get
            Return sMessage
        End Get
    End Property
    Public Sub New(ByVal WheelNumber As Long, ByVal HeatNumber As Long, Optional ByVal InGenlShift As Boolean = False)
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.CommandText = "Select top 1 @sl_no = a.sl_no, @Wheel_Status = a.wheel_status, @Bore_Status = a.bore_status, @Tread_Diameter = a.tread_diameter, @Plate_Thickness = a.plate_thickness , @Remarks = a.remarks from mm_final_inspection " & _
        " a inner join mm_wheel b on a.wheel_number = b.wheel_number and a.heat_number = b.heat_number and b.magnaglow_status <> 'K' and  ut_status <> 'sKipped' where a.wheel_number = " & WheelNumber.ToString & " and a.heat_number = " & HeatNumber.ToString & " and " & _
        " a.Inspection_date = @Dt and a.Shift_code = @sh order by a.sl_no desc "
        cmd.Parameters.Add("@Dt", FiForm.InspDate)
        If InGenlShift = False Then
            cmd.Parameters.Add("@Sh", FiForm.ShiftCode)
        Else
            cmd.Parameters.Add("@Sh", "G")
        End If

        cmd.Parameters.Add("@sl_no", SqlDbType.BigInt, 8)
        cmd.Parameters.Add("@Wheel_Status", SqlDbType.VarChar, 50)
        cmd.Parameters.Add("@Bore_Status", SqlDbType.VarChar, 50)
        cmd.Parameters.Add("@Tread_Diameter", SqlDbType.Float, 8)
        cmd.Parameters.Add("@Plate_Thickness", SqlDbType.VarChar, 50)
        cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 100)

        cmd.Parameters("@sl_no").Direction = ParameterDirection.Output
        cmd.Parameters("@Wheel_Status").Direction = ParameterDirection.Output
        cmd.Parameters("@Bore_Status").Direction = ParameterDirection.Output
        cmd.Parameters("@Tread_Diameter").Direction = ParameterDirection.Output
        cmd.Parameters("@Plate_Thickness").Direction = ParameterDirection.Output
        cmd.Parameters("@Remarks").Direction = ParameterDirection.Output
        Dim slno As Long
        Try
            cmd.Connection.Open()
            cmd.ExecuteScalar()
            slno = IIf(IsDBNull(cmd.Parameters("@sl_no").Value), 0, cmd.Parameters("@sl_no").Value)
            If IsNothing(slno) Or IsDBNull(slno) Then
                slno = -1
            End If
            If slno < 1 Then
                sMessage = "Cannot Delete wheel : " & WheelNumber.ToString & "/" & HeatNumber.ToString & " (only current shift wheels can be deleted) "
                ClearVars()
                Throw New Exception(sMessage)
            Else
                lWheelNumber = WheelNumber
                lHeatNumber = HeatNumber
                lSlNo = slno
                sMessage = "Confirm Deletion"
                sWheel_Status = IIf(IsDBNull(cmd.Parameters("@wheel_status").Value), "", cmd.Parameters("@wheel_status").Value)
                sBore_Status = IIf(IsDBNull(cmd.Parameters("@Bore_Status").Value), "", cmd.Parameters("@Bore_Status").Value)
                deciTread_Diameter = IIf(IsDBNull(cmd.Parameters("@Tread_Diameter").Value), 0.0, cmd.Parameters("@Tread_Diameter").Value)
                sPlate_thickness = IIf(IsDBNull(cmd.Parameters("@Plate_thickness").Value), "", cmd.Parameters("@Plate_thickness").Value)
                sRemarks = IIf(IsDBNull(cmd.Parameters("@Remarks").Value), "", cmd.Parameters("@Remarks").Value)
                blnConfirmDelete = False
            End If
        Catch exp As Exception
            ClearVars()
            slno = -1
            If sMessage.StartsWith("Cannot Delete wheel :") = False Then
                sMessage = "Data Seek Error. " & exp.Message & ":" & WheelNumber.ToString & "/" & HeatNumber.ToString
            End If
            Throw New Exception(sMessage)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
            slno = Nothing
        End Try
    End Sub
    Private Sub CreateLatestRecordsTable()
        tblLatestData = New DataTable()
        tblLatestData.Columns.Add(New DataColumn("Location", System.Type.GetType("System.String")))
        tblLatestData.Columns("Location").MaxLength = 50
        tblLatestData.Columns.Add(New DataColumn("LocationDate", System.Type.GetType("System.DateTime")))
        tblLatestData.Columns.Add(New DataColumn("Status", System.Type.GetType("System.String")))
        tblLatestData.Columns("Status").MaxLength = 50
        tblLatestData.Columns.Add(New DataColumn("recId", System.Type.GetType("System.Int64")))
        tblLatestData.Columns("recId").AutoIncrement = True
        tblLatestData.Columns("recId").AutoIncrementSeed = 1
        tblLatestData.Columns("recId").AutoIncrementStep = 1
        ' tblLatestData.Columns.Add(New DataColumn("sl_no", System.Type.GetType("System.Int64")))
    End Sub
    Private Function NewRowInLatestRecordsTable() As DataRow
        NewRowInLatestRecordsTable = tblLatestData.NewRow
    End Function
    Private Sub AddRowInLatestRecordsTable(ByVal row As DataRow)
        tblLatestData.Rows.Add(row)
    End Sub
    ReadOnly Property getLatestDataTable() As DataTable
        Get
            Return tblLatestData
        End Get
    End Property
    Private Sub LatestRecordsOfWheel()
        Dim ds As New DataSet()
        ds = getBriefHistory()
        Dim dr As DataRow
        Dim sLocation, sStatus As String
        Dim dLocationDate As Date
        Dim lSlNo As Long
        Try
            CreateLatestRecordsTable()
            For Each dr In ds.Tables(2).Rows
                sLocation = "CLFI"
                dLocationDate = dr("Insp_date")
                sStatus = dr("Wheel_status")
                'Exit For
                dr = NewRowInLatestRecordsTable()
                dr("Location") = sLocation
                dr("LocationDate") = dLocationDate
                dr("Status") = sStatus
                AddRowInLatestRecordsTable(dr)
            Next
            ' removed to allow multiple records of final inspection 19/2/11 
            'dr = NewRowInLatestRecordsTable()
            'dr("Location") = sLocation
            'dr("LocationDate") = dLocationDate
            'dr("Status") = sStatus
            'AddRowInLatestRecordsTable(dr)
            For Each dr In ds.Tables(1).Rows
                sLocation = "CLMT"
                dLocationDate = dr("test_date")
                sStatus = dr("Wheel_status")
                Exit For
            Next
            ' following dr records take only latest magna record. hence not in for loop. 19/2/11 
            dr = NewRowInLatestRecordsTable()
            dr("Location") = sLocation
            dr("LocationDate") = dLocationDate
            dr("Status") = sStatus
            AddRowInLatestRecordsTable(dr)
        Catch exp As Exception
            Throw New Exception(exp.Message)
        End Try
        ds = Nothing
        dr = Nothing
        sLocation = Nothing
        sStatus = Nothing
        dLocationDate = Nothing
        lSlNo = Nothing
    End Sub
    Public Function Delete(ByVal GenShiftChecked As Boolean) As String
        Dim sPrevLocation, sPrevStatus As String
        LatestRecordsOfWheel()
        Dim dr As DataRow
        Dim i As Integer = 0
        For Each dr In tblLatestData.Rows
            If i = 1 Then
                sPrevLocation = dr("Location")
                sPrevStatus = dr("Status")
                Exit For
            End If
            i = +1
        Next

        If IsNothing(sPrevStatus) OrElse IsDBNull(sPrevStatus) OrElse sPrevStatus = "" Then
            Delete = "Delete Failed : Previous status not found to restore "
            Exit Function
        End If
        Dim sGetTransSlNo, sDeleteTrans, sCheckTransDeletion, sUpdateMaster, sCheckMasterUpdation As String
        sGetTransSlNo = "select max(sl_no)from mm_final_inspection where wheel_number = @wheel_number " & _
            " and heat_number = @heat_number and inspection_date = @Inspection_date  " & _
            " and shift_code = @Shift_code"
        sDeleteTrans = "delete mm_final_inspection where wheel_number = @wheel_number " & _
            " and heat_number = @heat_number and inspection_date = @Inspection_date and " & _
            "  shift_code = @Shift_code and sl_no = @sl_no"
        sCheckTransDeletion = "select count(*) from mm_final_inspection where wheel_number = @wheel_number " & _
                " and heat_number = @heat_number and inspection_date = @Inspection_date and " & _
                "  shift_code = @Shift_code and sl_no = @sl_no"
        sUpdateMaster = "Update mm_wheel set location = @location, status = @status , thread_diameter = 0.0, " & _
            " plate_thickness = '' , bore_status = '' , bore_diameter = 0.0 where wheel_number = @wheel_number " & _
            " and heat_number = @heat_number "

        sCheckMasterUpdation = "Select count(*) from mm_wheel where location = @location and status = @status and thread_diameter = 0.0 and " & _
            " plate_thickness = '' and bore_status = '' and bore_diameter = 0.0 and wheel_number = @wheel_number " & _
            " and heat_number = @heat_number "

        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.Parameters.Add("@Wheel_Number", SqlDbType.BigInt, 8)
        cmd.Parameters.Add("@Heat_Number", SqlDbType.BigInt, 8)
        cmd.Parameters.Add("@Inspection_date", SqlDbType.SmallDateTime, 4)
        cmd.Parameters.Add("@Shift_code", SqlDbType.VarChar, 1)
        cmd.Parameters.Add("@sl_no", SqlDbType.BigInt, 8)
        cmd.Parameters.Add("@location", SqlDbType.VarChar, 50)
        cmd.Parameters.Add("@status", SqlDbType.VarChar, 50)

        cmd.Parameters("@Wheel_Number").Direction = ParameterDirection.Input
        cmd.Parameters("@Heat_Number").Direction = ParameterDirection.Input
        cmd.Parameters("@Inspection_date").Direction = ParameterDirection.Input
        cmd.Parameters("@Shift_code").Direction = ParameterDirection.Input
        cmd.Parameters("@sl_no").Direction = ParameterDirection.Input
        cmd.Parameters("@location").Direction = ParameterDirection.Input
        cmd.Parameters("@status").Direction = ParameterDirection.Input
        If FiForm.InspDate <> Now.Date Then
            If FiForm.ShiftCode <> "C" Then
                Return "Insp Date problem to delete"
            End If
        End If
        If FiForm.ShiftCode = "" Then
            Return "Insp Shift problem to delete"
        End If
        Dim blnDeletedTrans, blnUpdatedMaster, blnDone As Boolean

        Try
            cmd.Parameters("@Wheel_Number").Value = lWheelNumber
            cmd.Parameters("@Heat_Number").Value = lHeatNumber
            cmd.Parameters("@Inspection_date").Value = FiForm.InspDate
            cmd.Parameters("@Shift_code").Value = IIf(GenShiftChecked, "G", FiForm.ShiftCode)
            cmd.Parameters("@sl_no").Value = 0
            cmd.Parameters("@location").Value = sPrevLocation
            cmd.Parameters("@status").Value = sPrevStatus

            cmd.Connection.Open()
            cmd.Transaction = cmd.Connection.BeginTransaction
            cmd.CommandText = sGetTransSlNo
            Dim slno As Long = cmd.ExecuteScalar
            cmd.Parameters("@sl_no").Value = slno
            cmd.CommandText = sUpdateMaster
            cmd.ExecuteNonQuery()
            cmd.CommandText = sCheckMasterUpdation
            Dim ij As Integer = cmd.ExecuteScalar
            blnUpdatedMaster = ij > 0
            cmd.CommandText = sDeleteTrans
            cmd.ExecuteNonQuery()
            cmd.CommandText = sCheckTransDeletion
            blnDeletedTrans = cmd.ExecuteScalar = 0
            blnDone = blnDeletedTrans And blnUpdatedMaster
            ij = Nothing
            slno = Nothing
        Catch exp As Exception
            blnDone = False
            Throw New Exception("Save Error: " & exp.Message)
        Finally
            If blnDone Then
                cmd.Transaction.Commit()
                Delete = "Deleted : " & lWheelNumber.ToString & "/" & lHeatNumber.ToString
            Else
                cmd.Transaction.Rollback()
                Delete &= " Not Deleted : " & lWheelNumber.ToString & "/" & lHeatNumber.ToString
            End If
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
        End Try
        dr = Nothing
        i = Nothing
        sPrevLocation = Nothing
        sPrevStatus = Nothing
        sGetTransSlNo = Nothing
        sDeleteTrans = Nothing
        sCheckTransDeletion = Nothing
        sUpdateMaster = Nothing
        sCheckMasterUpdation = Nothing
        blnDeletedTrans = Nothing
        blnUpdatedMaster = Nothing
        blnDone = Nothing
    End Function
    Public Function getBriefHistory() As DataSet
        If lWheelNumber = 0 Then
            getBriefHistory = Nothing
            Throw New Exception("Not Deletable wheel")
        End If
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        da.SelectCommand.CommandText = "mm_sp_si_wheelHistoryBrief"
        da.SelectCommand.Parameters.Add("@WhlStr", SqlDbType.VarChar, 50)
        da.SelectCommand.Parameters("@WhlStr").Direction = ParameterDirection.Input
        da.SelectCommand.Parameters("@WhlStr").Value = lWheelNumber.ToString.Trim & "/" & lHeatNumber.ToString.Trim
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        dsWhlHistory = New DataSet()
        Try
            da.Fill(dsWhlHistory)
            getBriefHistory = dsWhlHistory
        Catch exp As Exception
            dsWhlHistory = Nothing
            Throw New Exception("History Retrieval Error: " & exp.Message)
        Finally
            da.Dispose()
            dsWhlHistory.Dispose()
            dsWhlHistory = Nothing
            da = Nothing
        End Try
    End Function
    ReadOnly Property WheelStatus() As String
        Get
            Return sWheel_Status
        End Get
    End Property
    ReadOnly Property BoreStatus() As String
        Get
            Return sBore_Status
        End Get
    End Property
    ReadOnly Property TreadDiameter() As Decimal
        Get
            Return deciTread_Diameter
        End Get
    End Property
    Private Sub ClearVars()
        sPlate_thickness = ""
        sRemarks = ""
        sWheel_Status = ""
        sBore_Status = ""
        deciTread_Diameter = 0.0
        lWheelNumber = 0
        lHeatNumber = 0
    End Sub
    ReadOnly Property WheelNumber() As Long
        Get
            Return lWheelNumber
        End Get
    End Property
    ReadOnly Property HeatNumber() As Long
        Get
            Return lHeatNumber
        End Get
    End Property
End Class
