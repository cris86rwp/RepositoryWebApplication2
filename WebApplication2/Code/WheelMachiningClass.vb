Public Class WheelMachiningClass
#Region " Fields"
    Dim lWheelNumber, lHeatNumber, lMgcHeat, lLastMagSlno As Long
    Dim sAlternateNumber, sWheelNumber, lMagSlNo, strwhl, strLastMcnedCode, sMcnMark As String
    Dim dMcnDate, dMarkedDate As Date
    Dim sShift, sOperator, sAgency, sMcnOpnMarked, sMcnOpnSet, sMachineID, sLastMcnStatus, sWheelTypeSet, sOrgAgency As String
    Dim blnCanBeSent, blnCanBeRecd, blnError As Boolean
    Dim blnWhlMarkedForSetMcnOpn, blnIsInMaster, blnIsInMagna, blnWhlTypeMatched, blnIsAlreadyMachined As Boolean
    Dim blnProcessDtError, blnDoNotRefreshMessage, blnOverridable, blnOverridden As Boolean
    Dim sProductCode As String
    Dim sMessage, strsql, strsqlsave As String
    Dim sGatePassNumber, sRemarks, sPreLocation As String
    Dim blnobjcreated, blnDeleteError, blnLOADetails As Boolean
    Dim sConString As String
    Private sLOANumber, sDCNumber, sBillNumber, sOperations As String
    Private dateLOADate, dateStartDate, dateEndDate, dateAmendedDate, dateDCDate, dateBillDate As Date
    Private intQty, intLOASlno, intDcQty, intAmendedQty As Integer
    Private dateDespatchValidUpto, dateBankGauranteeValidUpto As Date
#End Region
#Region " Property"
    Property BankGauranteeValidUpto() As Date
        Get
            Return dateBankGauranteeValidUpto
        End Get
        Set(ByVal Value As Date)
            dateBankGauranteeValidUpto = Value
        End Set
    End Property
    Property DespatchValidUpto() As Date
        Get
            Return dateDespatchValidUpto
        End Get
        Set(ByVal Value As Date)
            dateDespatchValidUpto = Value
        End Set
    End Property
    Property LOADetails() As Boolean
        Get
            Return blnLOADetails
        End Get
        Set(ByVal Value As Boolean)
            blnLOADetails = Value
        End Set
    End Property
    Property BillDate() As Date
        Get
            Return dateBillDate
        End Get
        Set(ByVal Value As Date)
            dateBillDate = Value
        End Set
    End Property
    Property BillNumber() As String
        Get
            Return sBillNumber
        End Get
        Set(ByVal Value As String)
            sBillNumber = Value
        End Set
    End Property
    Property DcQty() As Integer
        Get
            Return intDcQty
        End Get
        Set(ByVal Value As Integer)
            intDcQty = Value
        End Set
    End Property
    Property DCDate() As Date
        Get
            Return dateDCDate
        End Get
        Set(ByVal Value As Date)
            dateDCDate = Value
        End Set
    End Property
    Property DCNumber() As String
        Get
            Return sDCNumber
        End Get
        Set(ByVal Value As String)
            sDCNumber = Value
        End Set
    End Property
    Property LOASlno() As Integer
        Get
            Return intLOASlno
        End Get
        Set(ByVal Value As Integer)
            intLOASlno = Value
        End Set
    End Property
    Property AmendedQty() As Integer
        Get
            Return intAmendedQty
        End Get
        Set(ByVal Value As Integer)
            intAmendedQty = Value
        End Set
    End Property
    Property Qty() As Integer
        Get
            Return intQty
        End Get
        Set(ByVal Value As Integer)
            intQty = Value
        End Set
    End Property
    Property StartDate() As Date
        Get
            Return dateStartDate
        End Get
        Set(ByVal Value As Date)
            dateStartDate = Value
        End Set
    End Property
    Property EndDate() As Date
        Get
            Return dateEndDate
        End Get
        Set(ByVal Value As Date)
            dateEndDate = Value
        End Set
    End Property
    Property AmendedDate() As Date
        Get
            Return dateAmendedDate
        End Get
        Set(ByVal Value As Date)
            dateAmendedDate = Value
        End Set
    End Property
    Property LOADate() As Date
        Get
            Return dateLOADate
        End Get
        Set(ByVal Value As Date)
            dateLOADate = Value
        End Set
    End Property
    Property Operations() As String
        Get
            Return sOperations
        End Get
        Set(ByVal Value As String)
            sOperations = Value
        End Set
    End Property
    Property LOANumber() As String
        Get
            Return sLOANumber
        End Get
        Set(ByVal Value As String)
            sLOANumber = Value
        End Set
    End Property
    WriteOnly Property ConString() As String
        Set(ByVal Value As String)
            sConString = Value
        End Set
    End Property
    ReadOnly Property PreLocation() As String
        Get
            PreLocation = sPreLocation
        End Get
    End Property
    ReadOnly Property RecordDeleted() As Boolean
        Get
            RecordDeleted = blnDeleteError = False
        End Get
    End Property
    WriteOnly Property objCheck() As Boolean
        Set(ByVal Value As Boolean)
            blnobjcreated = Value
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
    Property GatePass() As String
        Get
            Return sGatePassNumber
        End Get
        Set(ByVal Value As String)
            If blnLOADetails Then
                If Me.CheckGatePass(Me.GetAgency(intLOASlno), Value) Then
                    sGatePassNumber = Value
                Else
                    Throw New Exception("InValid Gate Pass !")
                End If
            Else
                sGatePassNumber = Value
            End If
        End Set
    End Property
    Property IsOverriden() As Boolean
        Get
            Return blnOverridden
        End Get
        Set(ByVal Value As Boolean)
            blnOverridden = Value
        End Set
    End Property
    ReadOnly Property IsOverridable() As Boolean
        Get
            Return blnOverridable
        End Get
    End Property
    ReadOnly Property McnMark() As String
        Get
            Return sMcnMark
        End Get
    End Property
    Public ReadOnly Property CanBeSent() As Boolean
        Get
            Return blnCanBeSent
        End Get
    End Property
    Public ReadOnly Property canbeRecd() As Boolean
        Get
            Return blnCanBeRecd
        End Get
    End Property
    Public Property Wheel() As String
        Get
            Return strwhl
        End Get
        Set(ByVal Value As String)
            Call CheckWheel(Value) ' validate wheel 
            strwhl = Value
        End Set
    End Property
    Property Operator1() As String
        Get
            Return sOperator
        End Get
        Set(ByVal Value As String)
            sOperator = Value
        End Set
    End Property
    Property MachineID() As String
        Get
            Return sMachineID
        End Get
        Set(ByVal Value As String)
            sMachineID = Value
        End Set
    End Property
    Property McnAgency() As String
        Get
            Return sAgency
        End Get
        Set(ByVal Value As String)
            sAgency = Value.ToUpper.Trim
        End Set
    End Property
    Property McnOpnSet() As String
        Get
            Return sMcnOpnSet
        End Get
        Set(ByVal Value As String)
            sMcnOpnSet = Value
            If strwhl <> "" Then
                Call CheckWheel(strwhl)
            End If
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
    Property WheelTypeSet() As String
        Get
            Return sWheelTypeSet
        End Get
        Set(ByVal Value As String)
            sWheelTypeSet = Value
            If strwhl <> "" Then
                Call CheckWheel(strwhl)
            End If
        End Set
    End Property
    Property Shift() As String
        Get
            Return sShift
        End Get
        Set(ByVal Value As String)
            sShift = Value
        End Set
    End Property
    ReadOnly Property McnMarkedOn() As Date
        Get
            Return Format(dMarkedDate, "dd/MM/yyyy")
        End Get
    End Property
    ReadOnly Property ErrStatus() As Boolean
        Get
            blnError = True
            If blnProcessDtError = False Then
                If blnIsInMaster = True And strwhl <> "" Then
                    If blnWhlTypeMatched = True Then
                        If blnIsInMagna = True Then
                            If blnWhlMarkedForSetMcnOpn = True Or blnOverridden = True Then
                                If blnIsAlreadyMachined = False Then
                                    blnError = False
                                End If
                            End If
                        End If
                    End If
                Else
                    blnError = False
                End If

            End If
            Return blnError
        End Get
    End Property
    ReadOnly Property Message() As String
        Get
            blnError = True
            If blnProcessDtError = True Then
                Return sMessage
            Else
                If blnIsInMaster = False Then
                    Return sMessage
                Else
                    If blnWhlTypeMatched = False Then
                        Return sMessage
                    Else
                        If blnIsInMagna = False Then
                            Return sMessage
                        Else
                            If blnWhlMarkedForSetMcnOpn = False Then
                                Return sMessage
                            Else
                                If blnIsAlreadyMachined = False Then
                                    If blnDoNotRefreshMessage = False Then
                                        If blnCanBeRecd = True Then
                                            sMessage = "Wheel Can be Received (Mcn Agency/Mcn Code Selections are ignored) under GatePass No.:" & sGatePassNumber
                                        Else
                                            sMessage = "Messages"
                                        End If
                                        Return sMessage
                                    End If
                                Else
                                    Return sMessage
                                End If
                            End If
                        End If
                    End If
                End If
            End If
            Return sMessage
        End Get
    End Property
    Property ProcessDate() As Date
        Get
            Return Format(dMcnDate, "dd/MM/yyyy")
        End Get
        Set(ByVal value As Date)
            If value > Now.Date.Today Then
                blnProcessDtError = True
                sMessage = "Future Date : " & value
                strsql = "select max(McnDate) > '" & Format(dMcnDate, "yyyy/MM/dd") & "' from mm_wheel_machining_details "
            Else
                sMessage = "Messages"
                blnProcessDtError = False
                dMcnDate = value
            End If
        End Set
    End Property
#End Region
#Region " Methods"
    Public Sub New()
        MyBase.new()
        Refresh()
    End Sub
    Public Sub Refresh()
        dateDespatchValidUpto = "1900-01-01"
        dateBankGauranteeValidUpto = "1900-01-01"
        blnLOADetails = False
        sOperations = ""
        intAmendedQty = 0
        dateBillDate = "1900-01-01"
        sBillNumber = ""
        intDcQty = 0
        dateDCDate = "1900-01-01"
        sDCNumber = ""
        intLOASlno = 0
        intQty = 0
        dateLOADate = "1900-10-10"
        dateStartDate = "1900-10-10"
        dateEndDate = "1900-10-10"
        dateAmendedDate = "1900-10-10"
        sLOANumber = ""
        sMcnMark = ""
        sPreLocation = ""
        strwhl = ""
        sMessage = "Messages"
        blnDoNotRefreshMessage = False
        blnCanBeSent = False
        blnCanBeRecd = False
        blnError = False
        blnWhlMarkedForSetMcnOpn = False
        blnIsInMaster = False
        blnIsInMagna = False
        blnWhlTypeMatched = False
        blnIsAlreadyMachined = False
        blnProcessDtError = False
        blnDoNotRefreshMessage = False
        sGatePassNumber = ""
    End Sub
    Public Sub DeleteRecord(ByVal RecordID As Integer)
        Dim iWheelRecord As Integer
        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        oCmd.Parameters.Add("@RecordID", SqlDbType.Float, 8).Direction = ParameterDirection.Output
        Try
            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            oCmd.CommandText = "select @RecordID = max(sl_no) from mm_wheel_machining_details " & _
                " where wheel = (Select wheel from mm_wheel_machining_details " & _
                " where sl_no = " & Val(RecordID) & ") and status <> 'MCND'"
            oCmd.ExecuteScalar()
            iWheelRecord = IIf(IsDBNull(oCmd.Parameters("@RecordID").Value), 0, oCmd.Parameters("@RecordID").Value)
            If iWheelRecord = Nothing Then
                iWheelRecord = 0
            End If
            If iWheelRecord <> RecordID Then
                blnDeleteError = True
                sMessage = "Earlier transactions of the wheel cannot be deleted"
            Else
                blnDeleteError = True
                oCmd.CommandText = "Delete mm_wheel_machining_details where sl_no = " & RecordID
                oCmd.ExecuteNonQuery()
                oCmd.CommandText = "Select count(*) from mm_wheel_machining_details where sl_no = " & RecordID
                If oCmd.ExecuteScalar() = 0 Then
                    blnDeleteError = False
                    sMessage = "Record Deleted"
                Else
                    blnDeleteError = True
                    sMessage = "Record not Deleted"
                End If
            End If
        Catch exp As Exception
            iWheelRecord = 0
            Throw New Exception(exp.Message)
        Finally
            If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
            oCmd.Dispose()
            oCmd = Nothing
            iWheelRecord = Nothing
        End Try
    End Sub
    Private Sub GetWheelNumber(ByRef strWheelNumber As String)
        If strWheelNumber.Trim = "" Then
            lWheelNumber = 0
            lHeatNumber = 0
            strwhl = ""
            Exit Sub
        End If
        If strWheelNumber.IndexOf("/") < 0 Then
            strWheelNumber += "/0"
        End If
        Dim strWheel() As String = Split(strWheelNumber, "/")
        lWheelNumber = Val(strWheel(0))
        lHeatNumber = Val(strWheel(1))
        strwhl = CStr(lWheelNumber).Trim & "/" & CStr(lHeatNumber).Trim
        strWheel = Nothing
    End Sub
    Private Sub ConvertMgcHeat()
        If Left(strwhl, 1) = "7" And lWheelNumber > 699 Then ' it is mgc wheel
            Dim oCmd As SqlClient.SqlCommand
            oCmd = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@lMgcHeat", SqlDbType.Float, 8).Direction = ParameterDirection.Output
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = "select @lMgcHeat = heat_number from mm_mgc_wheels " & _
                    " where alternate_number = '" & CStr(lHeatNumber) & "'"
                oCmd.ExecuteScalar()
                lMgcHeat = IIf(IsDBNull(oCmd.Parameters("@lMgcHeat").Value), 0, oCmd.Parameters("@lMgcHeat").Value)
            Catch exp As Exception
                lMgcHeat = 0.0
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
            If lMgcHeat = Nothing Then
            Else
                lHeatNumber = lMgcHeat
            End If
        End If
    End Sub
    Public Sub CheckWheel(ByRef strWheelNumber As String)
        blnError = True
        blnDoNotRefreshMessage = False
        If blnProcessDtError = False Then
            GetWheelNumber(strWheelNumber)
            ConvertMgcHeat()
            CheckWheelInMaster()
            If blnIsInMaster = True Then
                GetWheelMcnMark()
                CheckWheelTypeMatched()
                If blnWhlTypeMatched = True Then
                    CheckWheelInMagna()
                    If blnIsInMagna = True Then
                        MarkedForSetMcnOpn(getSentSlNo())
                        If blnWhlMarkedForSetMcnOpn = True Or blnOverridden = True Then
                            CheckAlreadyMachined()
                            If blnIsAlreadyMachined = False Then
                                blnError = False
                                If blnCanBeRecd = True Then
                                    sMessage = "Wheel Can be received. : " & strwhl
                                End If
                            End If
                        End If
                    End If
                End If

            End If
        End If
    End Sub
    Private Function getSentSlNo() As Long
        'getSentSlNo = 2895752
        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            oCmd.Parameters.Add("@strwhl", SqlDbType.VarChar, 50).Value = strwhl
            oCmd.Parameters.Add("@magslno", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
            oCmd.CommandText = " if (select top 1 status from mm_wheel_machining_details where wheel = @strwhl and status <> 'MCND' order by sl_no desc ) = 'SENT' " & _
                                " select top 1 @magslno = magslno from mm_wheel_machining_details where wheel = @strwhl and status = 'SENT'and mcnCode = '" & sMcnOpnSet & "' order by sl_no desc "
            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            oCmd.ExecuteScalar()
            getSentSlNo = IIf(IsDBNull(oCmd.Parameters("@magslno").Value), 0, oCmd.Parameters("@magslno").Value)
        Catch exp As Exception
            getSentSlNo = 0
            Throw New Exception(exp.Message)
        Finally
            If Not IsNothing(oCmd) Then
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End If
        End Try
    End Function
    Private Sub CheckAlreadyMachined()
        If IsOverriden = True Then
            If lMagSlNo = Nothing Then
                lMagSlNo = 0 ' to override for wheels not marked for selected machining
            End If
        End If
        Dim i As Integer
        i = 0
        Dim sLastShiftCode As String
        Dim sLastMcnDate As Date
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        Try
            da.SelectCommand.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
            da.SelectCommand.CommandText = "select top 1 mcnCodeSet, mcnDate mcn_date, shiftcode, status,mcnCode, mcnAgency, MagSlNo, GatePass from mm_wheel_machining_details where " & _
                 " convert(varchar,wap.dbo.mm_si_fn_WhlStrPart(wheel, 'w')) + '/'+ convert(varchar,wap.dbo.mm_si_fn_WhlStrPart(wheel, 'h')) " & _
                 " = '" & strwhl & "' and magslno = " & lMagSlNo & " and mcnCode = '" & sMcnOpnSet & "' order by sl_no desc"
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                If i = 0 Then
                    strLastMcnedCode = IIf(IsDBNull(ds.Tables(0).Rows(0)("mcnCodeSet")), Nothing, CStr(ds.Tables(0).Rows(0)("mcnCodeSet")).ToUpper)
                    sLastMcnDate = IIf(IsDBNull(ds.Tables(0).Rows(0)("mcn_date")), Nothing, CDate(ds.Tables(0).Rows(0)("mcn_date")))
                    sLastShiftCode = IIf(IsDBNull(ds.Tables(0).Rows(0)("shiftcode")), Nothing, CStr(ds.Tables(0).Rows(0)("shiftcode")).ToUpper)
                    sLastMcnStatus = IIf(IsDBNull(ds.Tables(0).Rows(0)("status")), Nothing, CStr(ds.Tables(0).Rows(0)("status")).ToUpper)
                    lLastMagSlno = IIf(IsDBNull(ds.Tables(0).Rows(0)("MagSlNo")), Nothing, CLng(ds.Tables(0).Rows(0)("MagSlNo")))
                    sOrgAgency = IIf(IsDBNull(ds.Tables(0).Rows(0)("McnAgency")), Nothing, ds.Tables(0).Rows(0)("McnAgency"))
                    sGatePassNumber = IIf(IsDBNull(ds.Tables(0).Rows(0)("GatePass")), Nothing, ds.Tables(0).Rows(0)("GatePass"))
                    i = 1
                End If
            End If
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            da.Dispose()
            ds.Dispose()
            da = Nothing
            ds = Nothing
        End Try
        blnCanBeRecd = False
        blnCanBeSent = False
        If i = 1 Then
            If lLastMagSlno = lMagSlNo Then
                If sLastMcnStatus.ToLower = "mcnd" Then
                    blnIsAlreadyMachined = True
                    sMessage = "Already Machined : " & strwhl
                ElseIf sLastMcnStatus.ToLower = "recd" Then
                    sMessage = "Already Machined and received : " & strwhl
                    blnIsAlreadyMachined = True
                ElseIf sLastMcnStatus.ToLower = "sent" Then
                    sMessage = "Already sent for Machining : " & strwhl
                    blnCanBeRecd = True
                Else
                    blnIsAlreadyMachined = False
                End If
            Else
                blnIsAlreadyMachined = False
                blnCanBeSent = True
                sMessage = "Messages"
            End If
        End If
        sLastShiftCode = Nothing
        sLastMcnDate = Nothing
    End Sub
    Public Sub MachineDDL(ByRef ddl As System.Web.UI.WebControls.DropDownList)
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        Try
            da.SelectCommand.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
            da.SelectCommand.CommandText = "select machine_code, machine_code + ' - ' + description  descr " & _
                " from mm_vw_Rework_WheelMachining_Machines"
            da.Fill(ds)
            ddl.DataSource = ds.Tables(0)
            ddl.DataTextField = ds.Tables(0).Columns("Descr").ColumnName
            ddl.DataValueField = ds.Tables(0).Columns("Machine_code").ColumnName
            ddl.DataBind()
            ddl.Items.Insert(0, "Select")
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            da.Dispose()
            ds.Dispose()
            da = Nothing
            ds = Nothing
        End Try
    End Sub
    Private Sub MarkedForSetMcnOpn(Optional ByVal lSentSlNo As Long = 0)
        blnWhlMarkedForSetMcnOpn = False
        strsql = "declare @dt as smalldatetime select top 1 @dt = test_date from  mm_magnaglow_results where wheel_number = " & lWheelNumber & _
                " And heat_number = " & lHeatNumber & " and mcn_operation like '%" & sMcnOpnSet & "%'  order by sl_no desc " & _
                " if @dt  = '" & Format(dMcnDate, "MM/dd/yyyy") & "' begin select top 1 sl_no, test_date testdate , shift_code from mm_magnaglow_results " & _
                " where wheel_number = " & lWheelNumber & " And heat_number = " & lHeatNumber & " and mcn_operation like '%" & sMcnOpnSet & "%' and test_date " & _
                " <= '" & Format(dMcnDate, "MM/dd/yyyy") & "' and shift_code <= '" & sShift & "' order by sl_no desc  End" & _
                " else begin select top 1 0 sl_no, inspection_date testdate , shift_code from mm_final_inspection where wheel_number = " & lWheelNumber & " And heat_number = " & _
                lHeatNumber & " and wheel_status like '%" & sMcnOpnSet & "%' and inspection_date <= '" & Format(dMcnDate, "MM/dd/yyyy") & "' " & _
                " union   select top 1 0 sl_no, inspection_date testdate , shift_code from mm_qci_inspection where wheel_number = " & lWheelNumber & " And heat_number = " & _
                lHeatNumber & " end" 'and wheel_disposition like '%" & sMcnOpnSet & "%' and inspection_date <= '" & Format(dMcnDate, "MM/dd/yyyy") & "' 

        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        da.SelectCommand.CommandText = strsql
        Dim i As Integer
        i = 0
        Try
            da.Fill(ds)
            If lSentSlNo = 0 Then
                lMagSlNo = IIf(lSentSlNo = 0, IIf(IsDBNull(ds.Tables(0).Rows(0)("sl_no")), Nothing, ds.Tables(0).Rows(0)("sl_no")), lSentSlNo)
                dMarkedDate = IIf(IsDBNull(ds.Tables(0).Rows(0)("testdate")), Nothing, CDate(ds.Tables(0).Rows(0)("testdate")))
            Else
                lMagSlNo = lSentSlNo
                dMarkedDate = Nothing
            End If
            i = 1
        Catch exp As Exception
            sMessage = exp.Message
        Finally
            ds.Dispose()
            da.Dispose()
            ds = Nothing
            da = Nothing
        End Try

        If i = 0 And blnOverridden = False Then
            blnOverridable = True
            sMessage = "Wheel Not marked for set operation : " & strwhl & " on or before : " & Format(dMcnDate, "dd/MM/yyyy") & " " & sShift & " Shift"
        Else
            blnOverridable = False
            blnWhlMarkedForSetMcnOpn = True
            sMessage = "Messages"
        End If
        If blnOverridden Then
            blnWhlMarkedForSetMcnOpn = blnWhlMarkedForSetMcnOpn = False
        End If
        i = Nothing
    End Sub
    Private Sub CheckWheelInMaster()
        Dim cnt As Integer
        Dim oCmd As SqlClient.SqlCommand
        oCmd = rwfGen.Connection.CmdObj
        oCmd.Parameters.Add("@cnt", SqlDbType.Float, 8).Direction = ParameterDirection.Output
        Try
            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            oCmd.CommandText = "select @cnt = count(*) from mm_wheel where wheel_number = " & lWheelNumber & " and heat_number = " & lHeatNumber
            oCmd.ExecuteScalar()
            cnt = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)
            If cnt = Nothing Then
                cnt = 0
            End If
            blnIsInMaster = cnt > 0
            If blnIsInMaster = False And strwhl <> "" Then
                sMessage = "Wheel not in Master :" & strwhl
            Else
                sMessage = "Messages"
            End If
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
            oCmd.Dispose()
            oCmd = Nothing
            cnt = Nothing
        End Try
    End Sub
    Private Sub CheckWheelInMagna()
        Dim cnt As Integer
        Dim oCmd As SqlClient.SqlCommand
        oCmd = rwfGen.Connection.CmdObj
        oCmd.Parameters.Add("@cnt", SqlDbType.Float, 8).Direction = ParameterDirection.Output
        oCmd.Parameters.Add("@PreLoc", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
        Try
            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            oCmd.CommandText = "select @cnt = count(*) from mm_wheel where " & _
                " (( wheel_number = " & lWheelNumber & " and heat_number = " & lHeatNumber & " ) " & _
                " and ( location = 'clmt' or location = 'clqc' or location = 'clfi' or location =  'CLFQ' ) )"
            oCmd.ExecuteScalar()
            cnt = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)
            If cnt = Nothing Then
                cnt = 0
            End If
            blnIsInMagna = cnt > 0
            If blnIsInMagna = False Then
                sMessage = "Wheel Not in WFPS Inspection Area with any Machine Marking : " & strwhl
            Else
                sMessage = "Messages"
                oCmd.CommandText = "select @PreLoc = location  from mm_wheel where wheel_number = " & lWheelNumber & " and heat_number = " & lHeatNumber
                oCmd.ExecuteScalar()
                sPreLocation = IIf(IsDBNull(oCmd.Parameters("@PreLoc").Value), "", oCmd.Parameters("@PreLoc").Value)
                If sPreLocation = Nothing Then
                    sPreLocation = ""
                End If
            End If
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
            oCmd.Dispose()
            oCmd = Nothing
            cnt = Nothing
        End Try
    End Sub
    Private Sub GetWheelMcnMark()
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.Parameters.Add("@Sts", SqlDbType.VarChar, 50)
        cmd.Parameters("@Sts").Direction = ParameterDirection.Output
        cmd.CommandText = " select @Sts = mcn_operation from mm_magnaglow_results where wheel_number = " & lWheelNumber & " and heat_number = " & lHeatNumber & " and mcn_operation <> '' "
        Try
            If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
            cmd.ExecuteScalar()
            If IIf(IsDBNull(cmd.Parameters("@Sts").Value), "", cmd.Parameters("@Sts").Value) = "" Then
                cmd.CommandText = " select @Sts =  status from mm_wheel where wheel_number = " & lWheelNumber & " and heat_number = " & lHeatNumber & " "
                cmd.ExecuteScalar()
                If IIf(IsDBNull(cmd.Parameters("@Sts").Value), "", cmd.Parameters("@Sts").Value) = "" Then
                    sMcnMark = ""
                Else
                    sMcnMark = IIf(IsDBNull(cmd.Parameters("@Sts").Value), "", cmd.Parameters("@Sts").Value)
                    sMcnMark = "Wheel marked for :  " & sMcnMark.Trim
                End If
            Else
                sMcnMark = IIf(IsDBNull(cmd.Parameters("@Sts").Value), "", cmd.Parameters("@Sts").Value)
                sMcnMark = "Wheel marked for :  " & sMcnMark.Trim
            End If
        Catch exp As Exception
            sMessage = exp.Message
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
        End Try
    End Sub
    Private Sub CheckWheelTypeMatched()
        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        oCmd.Parameters.Add("@cnt", SqlDbType.Float, 8).Direction = ParameterDirection.Output
        Try
            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            oCmd.CommandText = "select @cnt = count(*) from mm_wheel where wheel_number = " & lWheelNumber & " and heat_number = " & lHeatNumber & " and left(description,3) like '" & Left(sWheelTypeSet, 3) & "'"
            oCmd.ExecuteScalar()
            If IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value) = 0 Then
                blnWhlTypeMatched = False
                sMessage = "Wheel Type MisMatched : " & strwhl
            Else
                blnWhlTypeMatched = True
            End If
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
            oCmd.Dispose()
            oCmd = Nothing
        End Try
    End Sub
    Public Sub MachinedInRWF(Optional ByVal sMarkedBy As String = "CLMT")
        If blnCanBeRecd = True Then
            sMessage = "Already sent for Machining : " & strwhl
            blnError = True
            Exit Sub
        End If
        If sAgency.ToLower.Trim <> "rwf" Then
            sMessage = "Cannot be Machined Inside : " & strwhl
            blnError = True
            Exit Sub
        ElseIf CheckWheel() Then
            sMessage = "Already marked for Inside Machining  : " & strwhl
            blnError = True
            Exit Sub
        End If
        blnError = False
        strsqlsave = "Insert into mm_wheel_machining_details (McnDate, ShiftCode, Operator,  "
        strsqlsave &= " Product_code, Machine_code, Wheel,McnCodeSet, McnCode, MarkedBy, MarkedOn, McnAgency, Status, magslno, wheel_number, heat_number, SentOrMcned, Remarks  ) values ("
        strsqlsave &= "'" & Format(dMcnDate, "MM/dd/yyyy") & "', '" & sShift & "', '" & sOperator & "','"
        strsqlsave &= sProductCode & "','" & sMachineID & "','"
        strsqlsave &= strwhl & "','" & sMcnOpnSet & "', '" & sMcnOpnSet & "','" & sMarkedBy & "', '" & Format(dMcnDate, "MM/dd/yyyy") & "', '"
        strsqlsave &= sAgency & "', 'MCND', " & lMagSlNo & "," & lWheelNumber & ", " & lHeatNumber & ",1, '" & sRemarks & "')"
        sMessage = "Machined :"
        save(strsqlsave)
    End Sub
    Public Sub SendForMachining(Optional ByVal sMarkedBy As String = "CLMT")
        If blnCanBeRecd = True Then
            sMessage = "Already sent for Machining : " & strwhl & "' and McnCode = '" & sMcnOpnSet & "' "
            Exit Sub
        End If
        If sAgency.ToLower.Trim = "rwf" Then
            sMessage = "Cannot be sent to RWF : " & strwhl
            Exit Sub
        End If
        strsqlsave = "Insert into mm_wheel_machining_details (McnDate, ShiftCode, Operator,  "
        strsqlsave &= "  Product_code, McnCodeSet, Wheel, McnCode, MarkedBy, MarkedOn, McnAgency, Status, magslno, wheel_number, heat_number,SentOrMcned, gatePass, remarks, PreLocation ) values ("
        strsqlsave &= "'" & Format(dMcnDate, "MM/dd/yyyy") & "', '" & sShift & "', '" & sOperator & "', '"
        strsqlsave &= sProductCode & "','" & sMcnOpnSet & "', '"
        strsqlsave &= strwhl & "','" & sMcnOpnSet & "','" & sMarkedBy & "', '" & Format(dMcnDate, "MM/dd/yyyy") & "', '"
        strsqlsave &= sAgency & "', 'SENT', " & lMagSlNo & "," & lWheelNumber & ", " & lHeatNumber & ", 1, '" & sGatePassNumber & "','" & sRemarks & "','" & sPreLocation & "' )"
        sMessage = "Sent :"
        save(strsqlsave)
    End Sub
    Private Function CheckWheel() As Boolean
        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            oCmd.CommandText = " select @cnt = count(*) from mm_wheel_machining_details " & _
            " where Wheel_number = " & lWheelNumber & " and  Heat_number = " & lHeatNumber & " and " & _
            " Wheel = '" & strwhl & "' and McnCode = '" & sMcnOpnSet & "' and  McnCodeSet = '" & sMcnOpnSet & "' " & _
            " and  status = 'MCND' and  McnAgency = 'RWF' "
            oCmd.Parameters.Add("@cnt", SqlDbType.Float, 8).Direction = ParameterDirection.Output
            oCmd.ExecuteScalar()
            Return IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            If Not IsNothing(oCmd) Then
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End If
        End Try
    End Function
    Public Sub ReceiveAfterMachining(Optional ByVal sMarkedBy As String = "CLMT")
        Dim IsSent As Boolean
        If blnCanBeRecd = False Or blnCanBeSent = True Then
            sMessage = "Not sent for Machining : " & strwhl
            Exit Sub
        Else
            Dim oCmd As New SqlClient.SqlCommand()
            oCmd = rwfGen.Connection.CmdObj
            Try
                oCmd.Parameters.Add("@cnt", SqlDbType.Float, 8).Direction = ParameterDirection.Output
                oCmd.CommandText = "select @cnt = count(*) from mm_wheel_machining_details where Wheel = '" & strwhl & "' " & _
                    " and McnCodeSet = '" & sMcnOpnSet & "' and McnAgency = '" & sOrgAgency & "' and Status =  'SENT' "
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.ExecuteScalar()
                IsSent = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If Not IsNothing(oCmd) Then
                    If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                    oCmd.Dispose()
                    oCmd = Nothing
                End If
            End Try
        End If
        If IsSent Then
            strsqlsave = "Insert into mm_wheel_machining_details (McnDate, ShiftCode, Operator,  "
            strsqlsave &= "  Product_code, McnCodeSet, Wheel, McnCode, MarkedBy, MarkedOn, McnAgency, Status, magslno, wheel_number, heat_number,SentOrMcned, Gatepass, Remarks ) values ("
            strsqlsave &= "'" & Format(dMcnDate, "MM/dd/yyyy") & "', '" & sShift & "', '" & sOperator & "', '"
            strsqlsave &= sProductCode & "','" & sMcnOpnSet & "', '"
            strsqlsave &= strwhl & "','" & strLastMcnedCode & "','" & sMarkedBy & "', '" & Format(dMcnDate, "MM/dd/yyyy") & "', '"
            strsqlsave &= sOrgAgency & "', 'RECD', " & lMagSlNo & "," & lWheelNumber & ", " & lHeatNumber & ",0, '" & sGatePassNumber & "','" & sRemarks & "' )"
            sMessage = "Received : "
            save(strsqlsave)
        Else
            sMessage = "Wheel Not Yet Sent to be Received now ! "
        End If
        IsSent = Nothing
    End Sub
    Private Sub save(ByVal strsqlsave As String)
        blnDoNotRefreshMessage = True
        Try
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = strsqlsave
                oCmd.ExecuteNonQuery()
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
            sMessage &= strwhl
        Catch exp As Exception
            If CType(exp, System.Data.SqlClient.SqlException).Number = 547 Then
                sMessage = "Cannot Save the wheel Again :" & strwhl
            ElseIf CType(exp, System.Data.SqlClient.SqlException).Number = 2627 Then
                sMessage = "Already Saved : " & strwhl
            Else
                sMessage = exp.Message & " : " & strwhl
            End If
        Catch expsql As SqlClient.SqlException
            If expsql.Number = 2627 Then
                sMessage = "Already Saved : " & strwhl
            Else
                sMessage = expsql.Message & " : " & strwhl
            End If
        End Try
    End Sub
    Public Shared Function GetLOADetails() As DataTable
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        Try
            da.SelectCommand.CommandText = " select LOANumber , convert(varchar(11),LOADate,103) LOADate , " & _
            " convert(varchar(11),StartDate,103) StartDate , " & _
            " convert(varchar(11),EndDate,103) EndDate , " & _
            " convert(varchar(11),AmendedDate,103) AmendedDate , Agency , Qty  , SlNo , AmendedQty , Operations , " & _
            " convert(varchar(11),DespatchValidUpto,103) DespValidUpto , " & _
            " convert(varchar(11),BankGauranteeValidUpto,103) BankGaurValidUpto  " & _
            " from mm_LOADetails order by LOADate desc , LOANumber "
            da.Fill(ds)
            GetLOADetails = ds.Tables(0)
        Catch exp As Exception
            GetLOADetails = Nothing
            Throw New Exception(exp.Message)
        Finally
            da.Dispose()
            ds.Dispose()
            da = Nothing
            ds = Nothing
        End Try
    End Function
    Public Sub SaveLOAGatePassList()
        Dim Done As Boolean
        Dim blnInsert As Boolean
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        da.SelectCommand.CommandText = "select *  from mm_LOAGatePassList where GatePass  = @GatePass and DCNumber  = @DCNumber "
        da.SelectCommand.Parameters.Add("@GatePass", SqlDbType.VarChar, 50).Value = sGatePassNumber.Trim
        da.SelectCommand.Parameters.Add("@DCNumber", SqlDbType.VarChar, 50).Value = sDCNumber.Trim
        Try
            da.Fill(ds)
            If ds.Tables(0).Rows.Count = 0 Then
                blnInsert = True
            End If
        Catch exp As Exception
            sMessage = exp.Message
        Finally
            ds.Dispose()
            da.Dispose()
            da = Nothing
            ds = Nothing
        End Try
        Dim strInsert, strUpdate As String
        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            oCmd.Parameters.Add("@LOASlno", SqlDbType.Float, 8).Value = intLOASlno
            oCmd.Parameters.Add("@GatePass", SqlDbType.VarChar, 50).Value = sGatePassNumber
            oCmd.Parameters.Add("@DCNumber", SqlDbType.VarChar, 50).Value = sDCNumber
            oCmd.Parameters.Add("@DCDate", SqlDbType.SmallDateTime, 4).Value = dateDCDate
            oCmd.Parameters.Add("@DcQty", SqlDbType.Int, 4).Value = intDcQty
            oCmd.Parameters.Add("@BillNumber", SqlDbType.VarChar, 50).Value = sBillNumber
            oCmd.Parameters.Add("@BillDate", SqlDbType.SmallDateTime, 4).Value = dateBillDate


            strInsert = " insert into mm_LOAGatePassList ( LOASlno , GatePass , DCNumber , DCDate , DcQty , BillNumber , BillDate ) " & _
                        " values ( @LOASlno , @GatePass , @DCNumber , @DCDate , @DcQty , @BillNumber , @BillDate  )  "
            strUpdate = " update mm_LOAGatePassList set DCDate = @DCDate  , DcQty = @DcQty " & _
                        " , BillNumber = @BillNumber , BillDate = @BillDate  " & _
                        " where LOASlno = @LOASlno and GatePass = @GatePass and DCNumber =  @DCNumber  "

            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            oCmd.Transaction = oCmd.Connection.BeginTransaction
            If blnInsert Then
                oCmd.CommandText = strInsert
            Else
                oCmd.CommandText = strUpdate
            End If
            If oCmd.ExecuteNonQuery = 1 Then
                Done = True
            End If
        Catch exp As Exception
            sMessage = exp.Message
        Finally
            If Not IsNothing(oCmd) Then
                If Done Then
                    oCmd.Transaction.Commit()
                    sMessage = " Updation Successful !"
                Else
                    sMessage &= " Updation Failed ! "
                    oCmd.Transaction.Rollback()
                End If
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End If
        End Try
        strUpdate = Nothing
        strInsert = Nothing
        Done = Nothing
        blnInsert = Nothing
    End Sub
    Public Sub SaveLOADetails()
        Dim Done As Boolean
        Dim blnInsert As Boolean
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        da.SelectCommand.CommandText = "select *  from mm_LOADetails where LOANumber  = @LOANumber and Agency = @Agency "
        da.SelectCommand.Parameters.Add("@LOANumber", SqlDbType.VarChar, 100).Value = sLOANumber.Trim
        da.SelectCommand.Parameters.Add("@Agency", SqlDbType.VarChar, 50).Value = sAgency.Trim
        Try
            da.Fill(ds)
            If ds.Tables(0).Rows.Count = 0 Then
                blnInsert = True
            End If
        Catch exp As Exception
            sMessage = exp.Message
        Finally
            ds.Dispose()
            da.Dispose()
            da = Nothing
            ds = Nothing
        End Try

        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Dim strInsert, strUpdate As String
        Try
            oCmd.Parameters.Add("@LOANumber", SqlDbType.VarChar, 100).Value = sLOANumber
            oCmd.Parameters.Add("@LOADate", SqlDbType.SmallDateTime, 4)
            oCmd.Parameters("@LOADate").Direction = ParameterDirection.Input
            oCmd.Parameters("@LOADate").Value = dateLOADate
            oCmd.Parameters.Add("@StartDate", SqlDbType.SmallDateTime, 4)
            oCmd.Parameters("@StartDate").Direction = ParameterDirection.Input
            oCmd.Parameters("@StartDate").Value = dateStartDate
            oCmd.Parameters.Add("@EndDate", SqlDbType.SmallDateTime, 4)
            oCmd.Parameters("@EndDate").Direction = ParameterDirection.Input
            oCmd.Parameters("@EndDate").Value = dateEndDate
            oCmd.Parameters.Add("@AmendedDate", SqlDbType.SmallDateTime, 4)
            oCmd.Parameters("@AmendedDate").Direction = ParameterDirection.Input
            oCmd.Parameters("@AmendedDate").Value = dateAmendedDate
            oCmd.Parameters.Add("@Agency", SqlDbType.VarChar, 10)
            oCmd.Parameters("@Agency").Direction = ParameterDirection.Input
            oCmd.Parameters("@Agency").Value = sAgency
            oCmd.Parameters.Add("@Qty", SqlDbType.Int, 4)
            oCmd.Parameters("@Qty").Direction = ParameterDirection.Input
            oCmd.Parameters("@Qty").Value = Val(intQty)
            oCmd.Parameters.Add("@AmendedQty", SqlDbType.Int, 4)
            oCmd.Parameters("@AmendedQty").Direction = ParameterDirection.Input
            oCmd.Parameters("@AmendedQty").Value = Val(intAmendedQty)
            oCmd.Parameters.Add("@DespatchValidUpto", SqlDbType.SmallDateTime, 4)
            oCmd.Parameters("@DespatchValidUpto").Direction = ParameterDirection.Input
            oCmd.Parameters("@DespatchValidUpto").Value = dateDespatchValidUpto
            oCmd.Parameters.Add("@BankGauranteeValidUpto", SqlDbType.SmallDateTime, 4)
            oCmd.Parameters("@BankGauranteeValidUpto").Direction = ParameterDirection.Input
            oCmd.Parameters("@BankGauranteeValidUpto").Value = dateBankGauranteeValidUpto

            strInsert = " insert into mm_LOADetails ( LOANumber , LOADate , StartDate , EndDate , AmendedDate , Agency , Qty  , AmendedQty , DespatchValidUpto ,  BankGauranteeValidUpto ) " & _
                        " values ( @LOANumber , @LOADate , @StartDate , @EndDate , @AmendedDate , @Agency , @Qty  , @AmendedQty , @DespatchValidUpto ,  @BankGauranteeValidUpto )  "

            strUpdate = " update mm_LOADetails set LOADate = @LOADate , StartDate = @StartDate , EndDate = @EndDate , AmendedDate = @AmendedDate , Qty = @Qty , AmendedQty = @AmendedQty  , DespatchValidUpto = @DespatchValidUpto ,  BankGauranteeValidUpto = @BankGauranteeValidUpto where LOANumber = @LOANumber and Agency =  @Agency "

            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            oCmd.Transaction = oCmd.Connection.BeginTransaction
            If blnInsert Then
                oCmd.CommandText = strInsert
            Else
                oCmd.CommandText = strUpdate
            End If
            If oCmd.ExecuteNonQuery = 1 Then
                Done = True
            End If
        Catch exp As Exception
            sMessage = exp.Message
        Finally
            If Not IsNothing(oCmd) Then
                If Done Then
                    oCmd.Transaction.Commit()
                    sMessage = " Updation Successful !"
                Else
                    sMessage &= " Updation Failed ! "
                    oCmd.Transaction.Rollback()
                End If
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End If
        End Try
        Done = Nothing
        blnInsert = Nothing
        strInsert = Nothing
        strUpdate = Nothing
    End Sub
    Public Shared Function GetAgency(ByVal LOASlno As Long) As String
        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            oCmd.Parameters.Add("@LOASlno", SqlDbType.Float, 8).Value = LOASlno
            oCmd.Parameters.Add("@Agency", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            oCmd.CommandText = "select @Agency = Agency from mm_LOADetails where SlNo = @LOASlno "
            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            oCmd.ExecuteScalar()
            GetAgency = IIf(IsDBNull(oCmd.Parameters("@Agency").Value), "", oCmd.Parameters("@Agency").Value)
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            If Not IsNothing(oCmd) Then
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End If
        End Try
    End Function
    Public Shared Function CheckGatePass(ByVal Agency As String, ByVal GatePass As String) As Boolean
        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            oCmd.Parameters.Add("@GatePass", SqlDbType.VarChar, 50).Value = GatePass
            oCmd.Parameters.Add("@Agency", SqlDbType.VarChar, 50).Value = Agency
            oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            oCmd.CommandText = "Select @cnt =  count(*)  from mm_wheel_machining_details " & _
                " where gatepass = @GatePass and McnAgency = @Agency "
            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            oCmd.ExecuteScalar()
            If IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value) > 0 Then CheckGatePass = True
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            If Not IsNothing(oCmd) Then
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End If
        End Try
    End Function
    Public Shared Function GetGatePassDetails(ByVal GatePass As String) As DataSet
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        Try
            da.SelectCommand.Parameters.Add("@GatePass", SqlDbType.VarChar, 50).Value = GatePass
            da.SelectCommand.CommandText = "select convert(varchar(11),MarkedOn,103) GPDate , count(Wheel) GPQty from mm_wheel_machining_details " & _
                " where gatepass = @GatePass and Status = 'sent' group by MarkedOn ; " & _
                " select DCNumber , convert(varchar(11),DCDate,103) DCDate , DcQty , BillNumber , convert(varchar(11),BillDate,103) BillDate from mm_LOAGatePassList " & _
                " where GatePass = @GatePass ;" & _
                " select ltrim(rtrim(b.description)) WhlType , convert(varchar(11),MarkedOn,103) GPDate , count(Wheel) GPQty " & _
                " from mm_wheel_machining_details a inner join mm_product_master b on a.product_code = b.product_code " & _
                " where gatepass = @GatePass and Status = 'sent' group by ltrim(rtrim(b.description)) , MarkedOn "
            da.Fill(ds)
            GetGatePassDetails = ds.Copy
        Catch exp As Exception
            GetGatePassDetails = Nothing
            Throw New Exception(exp.Message)
        Finally
            da.Dispose()
            ds.Dispose()
            ds = Nothing
            da = Nothing
        End Try
    End Function
    Public Shared Function GetDCDetails(ByVal GatePass As String, ByVal DCNumber As String) As DataTable
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        Try
            da.SelectCommand.Parameters.Add("@GatePass", SqlDbType.VarChar, 50).Value = GatePass
            da.SelectCommand.Parameters.Add("@DCNumber", SqlDbType.VarChar, 50).Value = DCNumber
            da.SelectCommand.CommandText = "select LOASlno , convert(varchar(11),DCDate,103) DCDate , DcQty , BillNumber , convert(varchar(11),BillDate,103) BillDate  " & _
                " from mm_LOAGatePassList where DCNumber = @DCNumber and GatePass = @GatePass "
            da.Fill(ds)
            GetDCDetails = ds.Tables(0)
        Catch exp As Exception
            GetDCDetails = Nothing
            Throw New Exception(exp.Message)
        Finally
            da.Dispose()
            ds.Dispose()
            ds = Nothing
            da = Nothing
        End Try
    End Function
    Public Shared Function GetLOAList(ByVal LOASlno As Long) As DataTable
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        Try
            da.SelectCommand.Parameters.Add("@LOASlno", SqlDbType.Float, 8).Value = LOASlno
            da.SelectCommand.CommandText = "select GatePass , DCNumber , convert(varchar(11),DCDate,103) DCDate , DcQty , BillNumber ,  " & _
                " convert(varchar(11),BillDate,103) BillDate from mm_LOADetails a left outer join mm_LOAGatePassList b   " & _
                " on SlNo = LOASlno where LOASlno = @LOASlno order by GatePass , DCNumber ; " & _
                " select sum(Qty) LOAQty , sum(DcQty) TotalDcQty ,  count(Wheel) TotalGPQty from mm_LOADetails a left outer join mm_LOAGatePassList b " & _
                " on SlNo = LOASlno inner join mm_wheel_machining_details c  " & _
                " on McnAgency = Agency where LOASlno = @LOASlno and c.Status = 'sent' "
            da.Fill(ds)
            GetLOAList = ds.Tables(0)
        Catch exp As Exception
            GetLOAList = Nothing
            Throw New Exception(exp.Message)
        Finally
            da.Dispose()
            ds.Dispose()
            ds = Nothing
            da = Nothing
        End Try
    End Function
    Public Shared Function DCQtyMisMatch(ByVal LOASlno As Long, ByVal GatePass As String, ByVal DCQty As Integer) As Boolean
        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            oCmd.Parameters.Add("@LOASlno", SqlDbType.Float, 8).Value = LOASlno
            oCmd.Parameters.Add("@GatePass", SqlDbType.VarChar, 50).Value = GatePass
            oCmd.Parameters.Add("@GPcnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@DCcnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            oCmd.CommandText = "Select @GPcnt =  count(Wheel)  from mm_wheel_machining_details a inner join mm_LOADetails b  " & _
                " on a.McnAgency = b.Agency where GatePass =  @GatePass and Status = 'sent' and SlNo =  @LOASlno ; " & _
                " select @DCcnt = sum(DcQty) from mm_LOADetails a left outer join mm_LOAGatePassList b " & _
                " on SlNo = LOASlno where LOASlno = @LOASlno and GatePass = @GatePass "
            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            oCmd.ExecuteScalar()
            If (IIf(IsDBNull(oCmd.Parameters("@DCcnt").Value), 0, oCmd.Parameters("@DCcnt").Value) + Val(DCQty)) > IIf(IsDBNull(oCmd.Parameters("@GPcnt").Value), 0, oCmd.Parameters("@GPcnt").Value) Then DCQtyMisMatch = True
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            If Not IsNothing(oCmd) Then
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End If
        End Try
    End Function
#End Region
End Class
