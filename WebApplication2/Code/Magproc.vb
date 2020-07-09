<Serializable()> Public Class GenUtils
    Public Class grids
        Dim mConStr As String
        Dim mSqlStr As String
        Dim mascdesc As String
        Dim mfieldname As String
        Dim mpagesize As Integer
        Dim mcurPage As Integer
        Property cur_page()
            Get
                Return mcurPage
            End Get
            Set(ByVal Value)
                mcurPage = Value
            End Set
        End Property
        Property page_size()
            Get
                Return mpagesize
            End Get
            Set(ByVal Value)
                mpagesize = Value
            End Set
        End Property
        Property field_name()
            Get
                Return mfieldname
            End Get
            Set(ByVal Value)
                mfieldname = Value
            End Set
        End Property
        Property order()
            Get
                Return mascdesc
            End Get
            Set(ByVal Value)
                mascdesc = Value
            End Set
        End Property
        Property Constring()
            Get
                Return mConStr
            End Get
            Set(ByVal Value)
                mConStr = Value
            End Set
        End Property
        Property sqlstring()
            Get
                Return mSqlStr
            End Get
            Set(ByVal Value)
                mSqlStr = Value
            End Set
        End Property
        Sub bindmygrid(ByRef mygrid As System.Web.UI.WebControls.DataGrid)
            If mascdesc = Nothing Or Not (mascdesc.ToLower = "asc" Or mascdesc.ToLower = "desc") Then
                mascdesc = "asc"
            End If

            Dim ds As System.Data.DataSet
            ds = New System.Data.DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = mSqlStr
                da.Fill(ds)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            End Try
            If ds.Tables(0).Rows.Count < mpagesize Then
                mpagesize = ds.Tables(0).Rows.Count
            End If
            Dim source As DataView = ds.Tables(0).DefaultView
            source.Sort = mfieldname & " " & mascdesc
            mygrid.DataSource = source
            mygrid.AllowSorting = True
            mygrid.AllowPaging = True
            mygrid.PageSize = mpagesize
            mygrid.CurrentPageIndex = mcurPage
            mygrid.PagerStyle.Mode = PagerMode.NumericPages
            mygrid.DataBind()
            da.Dispose()
            ds.Dispose()
            da = Nothing
            ds = Nothing
            source = Nothing
        End Sub
    End Class
    Public Class ddl
        Dim mConStr As String
        Dim mSqlStr, txtfld, valfld, mcondition, mtable As String
        Property qrycondition()
            Set(ByVal Value)
                mcondition = Value
            End Set
            Get
                Return mcondition
            End Get
        End Property
        WriteOnly Property table()
            Set(ByVal Value)
                mtable = Value
            End Set
        End Property
        Property Constring()
            Get
                Return mConStr
            End Get
            Set(ByVal Value)
                mConStr = Value
            End Set
        End Property
        WriteOnly Property textField()
            Set(ByVal Value)
                txtfld = Value
            End Set
        End Property
        WriteOnly Property valuefield()
            Set(ByVal Value)
                valfld = Value
            End Set
        End Property
        Public Sub prepare(ByRef ddlobj As System.Web.UI.WebControls.DropDownList)
            If mcondition = "" Then
                mSqlStr = "select distinct " & txtfld & " txtfld , " & valfld & " valfld from " & mtable
            Else
                mSqlStr = "select distinct " & txtfld & " txtfld , " & valfld & " valfld from " & mtable & " where " & mcondition
            End If
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = mSqlStr
                da.Fill(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    ddlobj.DataSource = ds.Tables(0)
                    ddlobj.DataTextField = ds.Tables(0).Columns("txtfld").ColumnName
                    ddlobj.DataValueField = ds.Tables(0).Columns("valfld").ColumnName
                    ddlobj.DataBind()
                    If ddlobj.Items.Count = 0 Then
                        ddlobj.Items.Clear()
                    End If
                    ddlobj.Items.Insert(0, "Select")
                Else
                    Throw New Exception("No proper WorkOrders available. Contact PCO !")
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Sub
    End Class
End Class
<Serializable()> Public Class Magwheelfrm
    Dim blnTableCreated As Boolean = False
    Dim MagTable As DataTable = New DataTable("MagTable")
    Dim dPinkDate As Date, dTestDate As Date, dMagTest_date As Date
    Dim sLastRecord As String, sMessage As String, sDefCodes As String, sLocCodes As String
    Dim sMcn As String
    Dim cDefaultShift As Char
    Dim sCurLocation As String, sWheelType As String, sMasterStatus As String
    Dim sMagRecord As String, dBHNRate As Integer, sFIRecord As String, sYardRecord As String
    Dim sQCRecord As String, sCurStatus As String
    Dim sWheelNumber As String
    Dim flgMagTestDate, flgMagTestShift, flgCopeInpsector, flgDragInspector, blnError As Boolean
    Dim cMagTest_Shift As Char
    Dim sErrorMessage, sCopeInspector, sDragInspector, sLineNumber As String
    Dim sLastHeat As Long
    Dim sWheelTypeSelected As String
    Dim sWorkOrder As String
    Public Sub New()
        MyBase.new()
    End Sub
    Public Sub getformdata()
        LastUpdate(sLineNumber)
        getDefectCodes()
        getLocationCodes()
        GetMCNCode(sLineNumber)
        getDefaultShiftCode()
    End Sub
    Property workorder() As String
        Get
            workorder = sWorkOrder
        End Get
        Set(ByVal Value As String)
            sWorkOrder = Value
        End Set
    End Property
    Property WheelType() As String
        Get
            WheelType = sWheelTypeSelected
        End Get
        Set(ByVal Value As String)
            sWheelTypeSelected = Value
        End Set
    End Property
    Public Function ShiftScore(ByVal dTestDate As Date, ByVal cTestShift As Char) As String
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        da.SelectCommand.CommandText = "select " & _
                 " sum(case when wheelstatus like 'xc%' and wheelstatus not like 'xc8%' then 1 else 0 end)  XC ," & _
                 " sum(case when wheelstatus like 'xc8%' then 1 else 0 end) XC8RHT , " & _
                 " sum(case when mcnoperation <> '' then 1 else 0 end) OffLoad , " & _
                 " sum(case when mcnoperation = '' and grindstatus <> '' then 1 else 0 end) Rework, " & _
                 " sum(case when wheelstatus like 's%' then 1 else 0 end) Stock , " & _
                 " sum(1) TotalProcessed " & _
                 " from mm_magnaglow_shiftwiserecords " & _
                 " where testdate = @TestDate and shiftCode = @TestShift  and linenumber = @LineNumber "
        da.SelectCommand.Parameters.Add("@TestDate", SqlDbType.SmallDateTime, 4).Value = dTestDate
        da.SelectCommand.Parameters.Add("@LineNumber", SqlDbType.VarChar, 4).Value = sLineNumber
        da.SelectCommand.Parameters.Add("@TestShift", SqlDbType.VarChar, 4).Value = cTestShift
        Dim ds As New DataSet()
        Try
            da.Fill(ds, "Score")
        Catch exp As Exception
            ds = Nothing
            sMessage = exp.Message
        Finally
            da.Dispose()
        End Try
        Dim row As DataRow
        ShiftScore = ""
        If IsNothing(ds) = False Then
            For Each row In ds.Tables("Score").Rows
                ShiftScore = "Stock : " + CStr(row("stock") & "").Trim + " Offloads : " + CStr(row("Offload") & "").Trim + " Rework: " + CStr(row("Rework") & "").Trim + " XCs : " + CStr(row("XC") & "").Trim + " RHT :" + CStr(row("XC8RHT") & "") + " Total : " + CStr(row("TotalProcessed") & "").Trim
            Next
            ds.Dispose()
        End If
        da = Nothing
        ds = Nothing
    End Function
    ReadOnly Property LastHeat() As Long
        Get
            LastHeat = sLastHeat
        End Get
    End Property
    Private Sub ErrorMessage(ByVal msg As String, Optional ByVal warning As Boolean = False)
        sErrorMessage = msg
    End Sub
    Property MagTestDate() As Date
        Get
            MagTestDate = Format(dMagTest_date, "dd/MM/yyyy")
        End Get
        Set(ByVal Value As Date)
            If Value <= dPinkDate Then
                flgMagTestDate = False
                blnError = True
                ErrorMessage("Pink Sheet Already Generated." & " Input date: " & dPinkDate & " changed to default date")
            Else
                If Value > Now.Date Then
                    blnError = True
                    flgMagTestDate = False
                    ErrorMessage("Future Date")
                Else
                    flgMagTestDate = True
                    blnError = False
                    dMagTest_date = Value
                    ErrorMessage("")
                End If
            End If
        End Set
    End Property
    Property MagTestShift() As Char
        Get
            MagTestShift = cMagTest_Shift
        End Get
        Set(ByVal Value As Char)
            Select Case Value.ToLower(Value)
                Case "a", "b", "c"
                    flgMagTestShift = True
                    MagTestShift = Value
                    blnError = False
                Case Else
                    blnError = True
                    flgMagTestShift = False
                    ErrorMessage("Invalid Shift : " & Value & " Default Shift Restored.")
            End Select
        End Set
    End Property
    Property MagCopeInspector() As String
        Get
            MagCopeInspector = sCopeInspector
        End Get
        Set(ByVal Value As String)
            If Val(Value.Trim) > 0 And Value.Trim.Length = 6 Then
                Dim myCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
                myCmd.CommandText = "Select count(*) from mis.dbo.menu_your_password where application = 'MMS' and group_code = 'CLRMAG' and employee_code = '" & Value.Trim & "'"
                Try
                    myCmd.Connection.Open()
                    flgCopeInpsector = myCmd.ExecuteScalar > 0
                    blnError = Not flgCopeInpsector
                    If blnError = False Then
                        sCopeInspector = Value
                    Else
                        sCopeInspector = ""
                    End If
                Catch exp As Exception
                    flgCopeInpsector = False
                Finally
                    If flgCopeInpsector = False Then
                        blnError = True
                    End If
                    If myCmd.Connection.State = ConnectionState.Open Then myCmd.Connection.Close()
                    myCmd.Dispose()
                    myCmd = Nothing
                End Try
                If blnError = False Then
                    ErrorMessage("")
                Else
                    ErrorMessage("Invalid Cope Inspector Code")
                End If
            Else
                blnError = True
                flgCopeInpsector = False
                ErrorMessage("Invalid Cope Inspector Code")
            End If
        End Set
    End Property
    Property MagDragInspector() As String
        Get
            MagDragInspector = sDragInspector
        End Get
        Set(ByVal Value As String)
            If Val(Value.Trim) > 0 And Value.Trim.Length = 6 Then
                blnError = False
                sDragInspector = Value
                ErrorMessage("")
            Else
                blnError = True
                flgDragInspector = False
                ErrorMessage("Invalid Drag Inspector Code")
            End If
        End Set
    End Property
    ReadOnly Property pinkdate() As Date
        Get
            Return Format(dPinkDate, "dd/MM/yyyy")
        End Get
    End Property
    ReadOnly Property ErrMessage()
        Get
            ErrMessage = sErrorMessage
        End Get
    End Property
    ReadOnly Property LastRecord()
        Get
            Return sLastRecord
        End Get
    End Property
    Public ReadOnly Property ErrStatus() As Boolean
        Get
            ErrStatus = blnError
        End Get
    End Property
    ReadOnly Property DefaultShift()
        Get
            Return cDefaultShift
        End Get
    End Property
    ReadOnly Property DefaultTestDate() As Date
        Get
            Return dTestDate
        End Get
    End Property
    ReadOnly Property McnOpnCodes() As String
        Get
            McnOpnCodes = sMcn
        End Get
    End Property
    ReadOnly Property LocCodes() As String
        Get
            Return sLocCodes
        End Get
    End Property
    ReadOnly Property DefCodes() As String
        Get
            Return sDefCodes
        End Get
    End Property
    WriteOnly Property LineNumber() As String
        Set(ByVal Value As String)
            sLineNumber = Value
        End Set
    End Property
    Public Shared Function GetCalibrationTestWheelType(ByVal ClaiDt As Date, ByVal Sh As String, ByVal Line As String) As String
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.Parameters.Add("@ClaiDt", SqlDbType.SmallDateTime, 4).Value = ClaiDt
        cmd.Parameters.Add("@Sh", SqlDbType.VarChar, 1).Value = Sh
        cmd.Parameters.Add("@Line", SqlDbType.VarChar, 2).Value = Line
        cmd.Parameters.Add("@WhlType", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
        Try
            cmd.Connection.Open()
            cmd.CommandText = "select @WhlType = wheel_type from ms_ut_calibration " & _
                 " where calibration_date = @ClaiDt and  shift_code = @Sh " & _
                 " and line_number = @Line "
            cmd.ExecuteScalar()
            Return IIf(IsDBNull(cmd.Parameters("@WhlType").Value), "", cmd.Parameters("@WhlType").Value)
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
    Public Shared Function IsCalibrationTestDone(ByVal ClaiDt As Date, ByVal Sh As String, ByVal Line As String, ByVal WhlType As String) As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.CommandText = "select @Cnt = count(*) from ms_magnaglow_calibration " & _
            " where calibration_date = @ClaiDt and  shift_code = @Sh " & _
            " and line_number = @Line "
        cmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
        cmd.Parameters.Add("@ClaiDt", SqlDbType.SmallDateTime, 4).Value = ClaiDt
        cmd.Parameters.Add("@Sh", SqlDbType.VarChar, 1).Value = Sh
        cmd.Parameters.Add("@Line", SqlDbType.VarChar, 2).Value = Line
        cmd.Parameters.Add("@WhlType", SqlDbType.VarChar, 50).Value = WhlType
        Try
            cmd.Connection.Open()
            cmd.ExecuteScalar()
            If IIf(IsDBNull(cmd.Parameters("@Cnt").Value), 0, cmd.Parameters("@Cnt").Value) > 0 Then
                cmd.CommandText = "select @Cnt = count(*) from ms_uv_calibration " & _
                                            " where DueDate > @ClaiDt " & _
                                            " and LineNumber = @Line  "
                cmd.ExecuteScalar()
                If IIf(IsDBNull(cmd.Parameters("@Cnt").Value), 0, cmd.Parameters("@Cnt").Value) > 0 Then
                    If Left(Line, 1) <> "2" Then
                        cmd.CommandText = "select @Cnt = count(*) from ms_ut_calibration " & _
                                                    " where calibration_date = @ClaiDt and  shift_code = @Sh " & _
                                                    " and line_number = @Line  and wheel_type = @WhlType "
                        cmd.ExecuteScalar()
                        If IIf(IsDBNull(cmd.Parameters("@Cnt").Value), 0, cmd.Parameters("@Cnt").Value) > 0 Then
                            cmd.CommandText = "select @Cnt = count(*) from ms_bhn_calibration " & _
                                " where due_date_calibration  > @ClaiDt " & _
                                " and line_number = @Line  and wheel_type = @WhlType "
                            cmd.ExecuteScalar()
                            If IIf(IsDBNull(cmd.Parameters("@Cnt").Value), 0, cmd.Parameters("@Cnt").Value) > 0 Then
                                IsCalibrationTestDone = True
                            Else
                                Throw New Exception("BHN Calibration Details not done for line " & Line & " and " & WhlType & "  and Date : " & ClaiDt & "!")
                            End If
                        Else
                            Throw New Exception("UT Calibration Details not done for line " & Line & " and " & WhlType & " and Date : " & ClaiDt & " and  Shift : " & Sh & " !")
                        End If
                    Else
                        IsCalibrationTestDone = True
                    End If
                Else
                    Throw New Exception("UV Calibration Details not done for " & Line & " and Date : " & ClaiDt & "!")
                End If
            Else
                Throw New Exception("Mag Calibration Details not done for line " & Line & "  and Date : " & ClaiDt & " !")
            End If
        Catch exp As Exception
            IsCalibrationTestDone = 0
            Throw New Exception(exp.Message)
        Finally
            If IsNothing(cmd) = False Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End If
        End Try
    End Function
    Private Sub setflagsOnLoad()
        flgMagTestDate = True
        flgMagTestShift = True
        flgCopeInpsector = True
        flgDragInspector = True
    End Sub
    Public Sub productsddl(ByRef ddlwo As System.Web.UI.WebControls.DropDownList)
        Dim myddl As New GenUtils.ddl()
        myddl.Constring = rwfGen.Connection.ConString
        myddl.table = "mm_workorder"
        myddl.qrycondition = " number like right(convert(varchar,year('" & Format(dTestDate, "yyyy-MM-dd") & "')),1)  + substring('ABCDEFGHIJKL',month('" & Format(dTestDate, "yyyy-MM-dd") & "'),1)+'%' and shop_code like 'n%'"
        myddl.textField = "Description"
        myddl.valuefield = "Number"
        myddl.prepare(ddlwo)
        ddlwo.ClearSelection()
        Dim i As Integer
        For i = 0 To ddlwo.Items.Count - 1
            If Left(ddlwo.Items(i).Text, 4).ToUpper = sWheelType Then
                ddlwo.Items(i).Selected = True
                Exit For
            End If
        Next
        i = Nothing
        myddl = Nothing
    End Sub
    Public Sub LastUpdate(ByVal sLine As String)
        sLineNumber = sLine
        Dim ds As New DataSet()
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        da.SelectCommand.Parameters.Add("@line", SqlDbType.VarChar, 2).Value = sLineNumber
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "mm_sp_magproc_lastrecord"
        Try
            da.Fill(ds, "LastUpdate")
            Dim row As DataRow
            For Each row In ds.Tables("LastUpdate").Rows
                dPinkDate = IIf(IsDBNull(row("pink_date")), CDate("1/1/1900"), row("pink_date"))
                sLastRecord = IIf(IsDBNull(row("LastRecord")), 0, row("LastRecord"))
                dTestDate = IIf(IsDBNull(row("test_date")), CDate("1/1/1900"), row("test_date"))
                sWheelType = IIf(IsDBNull(row("LastWheelType")), "", row("LastWheelType"))
                sLastHeat = IIf(IsDBNull(row("LastHeat")), 0, row("LastHeat"))
            Next
            row = Nothing
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            If IsNothing(da) = False Then da.Dispose()
            If IsNothing(ds) = False Then ds.Dispose()
            da = Nothing
            ds = Nothing
        End Try
    End Sub
    Private Sub getDefectCodes()
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        da.SelectCommand.CommandText = "SELECT isnull(rej_code,'') rejcode  FROM mm_mmrjd_dump " & _
            " where location = 'WHEE' and respon = 'WHEE' and isnumeric(rej_code) = 1  "
        sDefCodes = ""
        Dim ds As New DataSet()
        Try
            da.Fill(ds, "Rejcodes")
        Catch exp As Exception
            ds = Nothing
            sMessage = exp.Message
        Finally
            da.Dispose()
        End Try
        Dim row As DataRow
        For Each row In ds.Tables("Rejcodes").Rows
            sDefCodes &= Trim(row("RejCode")) & ","
        Next
        ds.Dispose()
        If sDefCodes <> "" Then
            sDefCodes = Left(sDefCodes.Trim, sDefCodes.Length - 1)
        End If
        row = Nothing
        da = Nothing
        ds = Nothing
    End Sub
    Private Sub getLocationCodes()
        sLocCodes = ""
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        da.SelectCommand.CommandText = "SELECT Ltrim(Rtrim(wheel_spot_code)) as Code FROM mm_wheel_spots_codes"
        Dim ds As New DataSet()
        Try
            da.Fill(ds, "LocCodes")
        Catch exp As Exception
            ds = Nothing
            sMessage = exp.Message
        Finally
            da.Dispose()
        End Try
        Dim row As DataRow
        For Each row In ds.Tables("LocCodes").Rows
            sLocCodes &= Trim(row("Code")) & ","
        Next
        ds.Dispose()
        If sLocCodes <> "" Then
            sLocCodes = Left(sLocCodes.Trim, sLocCodes.Length - 1)
        End If
        da = Nothing
        ds = Nothing
    End Sub
    Private Sub GetMCNCode(ByVal sLine As String)
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        da.SelectCommand.CommandText = "SELECT mcn_code code FROM mm_machineoperation_code " & _
            " WHERE line_number = @Line "
        da.SelectCommand.Parameters.Add("@Line", SqlDbType.VarChar, 10).Value = sLine
        Dim ds As New DataSet()
        Try
            da.Fill(ds, "MCNCode")
        Catch exp As Exception
            ds = Nothing
            sMessage = exp.Message
        Finally
            da.Dispose()
        End Try
        Dim row As DataRow
        sMcn = ""
        For Each row In ds.Tables("MCNCode").Rows
            sMcn &= Trim(row("Code")) & ","
        Next
        ds.Dispose()
        If sMcn <> "" Then
            sMcn = Left(sMcn.Trim, sMcn.Length - 1)
        End If
        da = Nothing
        ds = Nothing
    End Sub
    Private Sub getDefaultShiftCode()
        Dim dt As Date
        dt = Now()
        Select Case dt.Hour
            Case 6, 7, 8, 9, 10, 11, 12, 13
                cDefaultShift = "A"
            Case 14, 15, 16, 17, 18, 19, 20, 21
                cDefaultShift = "B"
            Case Else
                cDefaultShift = "C"
        End Select
    End Sub
    Public Sub FormGrid(ByRef dgWheels As System.Web.UI.WebControls.DataGrid, ByVal sLineNumber As String, Optional ByVal mcurPage As Integer = 0, Optional ByVal allowpaging As Boolean = True)
        Dim myDataSet As New System.Data.DataSet()
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Try
            da.SelectCommand.CommandText = "Select rtrim(Wheel) wheel , rtrim(WheelStatus) WheelStatus,  " & _
                " rtrim(GrindStatus) GrindStatus, rtrim(McnOperation) McnOperation, rtrim(UtStatus) UT, BHN " & _
                " from mm_magnaglow_shiftwiseRecords " & _
                " where testdate = @TestDate and ShiftCode = @DefaultShift  and Linenumber = @LineNumber " & _
                " order by Sl_no desc "
            da.SelectCommand.Parameters.Add("@TestDate", SqlDbType.SmallDateTime, 4).Value = dTestDate
            da.SelectCommand.Parameters.Add("@DefaultShift", SqlDbType.VarChar, 4).Value = cDefaultShift
            da.SelectCommand.Parameters.Add("@LineNumber", SqlDbType.VarChar, 4).Value = sLineNumber
            da.Fill(myDataSet)
        Catch exp As Exception
            myDataSet = Nothing
            Throw New Exception(exp.Message)
        Finally
            da.Dispose()
        End Try
        dgWheels.DataSource = myDataSet
        dgWheels.AllowSorting = False
        dgWheels.AllowPaging = allowpaging
        dgWheels.PagerStyle.Mode = PagerMode.NumericPages
        dgWheels.CurrentPageIndex = IIf(myDataSet.Tables(0).Rows.Count < mcurPage, myDataSet.Tables(0).Rows.Count, mcurPage)
        dgWheels.PageSize = 3
        dgWheels.DataBind()
        da = Nothing
        myDataSet = Nothing
    End Sub
    Public Sub dispose()
        MyBase.Finalize()
    End Sub
End Class
<Serializable()> Public Class MagWheel
    Dim dPinkDate As Date
    Dim sMessage As String, sDefCodes As String, sLocCodes As String
    Dim sMcn, sCurGrindSts, sCurMcnSts As String
    Dim cDefaultShift As Char
    Dim sCurLocation As String, sWheelType As String, sMasterStatus As String, sWheelTypeFromMaster As String
    Dim sMagRecord As String, dBHNRate As Integer, sFIRecord As String, sYardRecord As String
    Dim sQCRecord As String, sCurStatus As String
    Dim sWheelNumber, sQciStatus, sFiStatus, sGrindStatus, sMcnStatus, sLine_number As String
    Dim lWheelNumber, lHeatNumber, lRegular_heat_for_mgc_wheels As Long

    ' Following part of this class pertains to validations and saving of mag record.
    Dim sPrevMcnOpn As String
    Dim sPrevGrindSts As String
    Dim sMcnOperation As String
    Dim cUTStatus As Char
    Dim iBHNStatus0 As Integer
    Dim iBHNStatus1 As Integer
    Dim iBHNStatus2 As Integer
    Dim sRemarks As String
    Dim sWheelStatus As String
    Dim blnError As Boolean
    Dim blnchkPlatePass As Boolean
    Dim sErrorMessage As String
    Dim sBtnSaveText As String
    Dim sMouldRoomStatus As String
    Dim sLineNumber As String
    Dim cPrevUTStatus As Char
    Dim sSelectedWheelType As String
    Dim sWorkOrder, sLastTestDate, sLastLine As String
    Dim s2ndPrevWhl, sPrevWhl As String
    Dim l2ndPrevWhlSlno, lPrevWhlSlno, l2ndPrevWhlPilotSlNo, lPrevWhlPilotSlNo As Long
    Dim flgGrindStatus, flgMouldRoomStatus, flgMcnOpn, flgWheelStatus, flgUTStatus, flgWheelNumber, flgFirstLineProcessed, flgSecondWheelRHT, flgFirstWheelRHT, flgcurWheelRHT, flgCurWheelTypeChange, flgRHTWheel, flgNewSerieswhl As Boolean
    Dim flgFirstWheelTypeChange, flgSecondWheelTypeChange, flgWheelTypeChange, flgwheelNotFound As Boolean
    Dim blnTypeOverride As Boolean
    Dim sSecondPrevwhltype, sPrevwhltype As String

    ReadOnly Property IsHeatNumberValid() As Boolean
        Get
            Dim sMessageSpl As String
            If Val(MagHeatNumber) <> 0 And Val(MagWheelNumber) >= 100000 Then
                IsHeatNumberValid = False
                sMessageSpl = "Series wheel should not have only zero (0) as heat number."
            Else
                sMessageSpl = ""
                IsHeatNumberValid = True
            End If
            ErrorMessage(sMessageSpl, True)
            sMessageSpl = Nothing
        End Get
    End Property
    ReadOnly Property prevUTStatus() As Char
        Get
            prevUTStatus = cPrevUTStatus
        End Get
    End Property
    ReadOnly Property getSecondPrevWheel() As String
        Get
            getSecondPrevWheel = s2ndPrevWhl
        End Get
    End Property
    Function GetBHN(ByVal whlno As String) As Integer
        Dim LBHNWhl As Long
        Dim LBHNht As Long
        Try
            Dim strarr() As String = Split(whlno, "/")
            LBHNWhl = CLng(strarr(0))
            LBHNht = CLng(strarr(1))
            ' bhn null checked on 26/7/04
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Connection.Open()
                cmd.Parameters.Add("@GetBHN", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                cmd.CommandText = "Select @GetBHN = isnull(BHN,0) from mm_magnaglow_shiftwiseRecords where wheelnumber = " & LBHNWhl & " and heatnumber = " & LBHNht
                cmd.ExecuteScalar()
                If IIf(IsDBNull(cmd.Parameters("@GetBHN").Value), 0, cmd.Parameters("@GetBHN").Value) = 0 Then
                    cmd.CommandText = "Select @GetBHN = isnull(BHN_Rate,0) from mm_wheel where wheel_number = " & LBHNWhl & " and heat_number = " & LBHNht
                    cmd.ExecuteScalar()
                    GetBHN = IIf(IsDBNull(cmd.Parameters("@GetBHN").Value), 0, cmd.Parameters("@GetBHN").Value)
                Else
                    GetBHN = cmd.Parameters("@GetBHN").Value
                End If
            Catch exp As Exception
                GetBHN = 0
                Throw New Exception(exp.Message)
            Finally
                cmd.Dispose()
                cmd = Nothing
            End Try
            strarr = Nothing
        Catch exp As Exception
            GetBHN = 0
        End Try
        LBHNWhl = Nothing
        LBHNht = Nothing
    End Function
    Private Sub previouswheels(ByVal dtestDate As Date, ByVal dpinkdate As Date)
        sPrevWhl = ""
        lPrevWhlSlno = 0
        lPrevWhlPilotSlNo = 0
        l2ndPrevWhlPilotSlNo = 0
        If Left(sLineNumber.Trim, 1) = "2" OrElse Left(sLineNumber.Trim, 2) = "1A" Then ' added Left(sLineNumber.Trim, 2) = "1A" on 30/5/2006 svi
            Exit Sub
        End If
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = IIf(sLineNumber = "1", "mm_sp_magproc_PreviousWheels", "mm_sp_magproc_PreviousWheels1B")
        da.SelectCommand.Parameters.Add("@fromDate", SqlDbType.SmallDateTime, 8).Value = dpinkdate
        da.SelectCommand.Parameters.Add("@toDate", SqlDbType.SmallDateTime, 8).Value = dtestDate
        da.SelectCommand.CommandTimeout = 60 * 60 * 1 ' added on 5/6/06 svi
        Dim ds As New DataSet()
        Dim swhl1 As String = ""
        Dim swhl2 As String = ""
        Try
            da.Fill(ds, "PrevWheels")
            Dim row As DataRow
            For Each row In ds.Tables("PrevWheels").Rows
                ' previous wheel
                sPrevWhl = row("prevwhlmag") & ""
                lPrevWhlSlno = IIf(IsDBNull(row("prevslnomag")), 0, row("prevslnomag"))
                swhl1 = row("prevwhlpilot") & ""
                lPrevWhlPilotSlNo = IIf(IsDBNull(row("prevslnopilot")), 0, row("prevslnopilot"))
                sPrevwhltype = row("PrevWhlType") & ""
                'second prev wheel
                s2ndPrevWhl = row("secondprevwhlmag") & ""
                l2ndPrevWhlSlno = IIf(IsDBNull(row("secondprevslnomag")), 0, row("secondprevslnomag"))
                swhl2 = row("secondwhlpilot") & ""
                l2ndPrevWhlPilotSlNo = IIf(IsDBNull(row("secondprevslnopilot")), 0, row("secondprevslnopilot"))
                sSecondPrevwhltype = row("SecondPrevWhlType") & ""
            Next
            row = Nothing
        Catch exp As Exception
            ds = Nothing
            sPrevWhl = ""
        Finally
            da.Dispose()
        End Try

        If swhl2.Trim <> s2ndPrevWhl.Trim Then
            l2ndPrevWhlPilotSlNo = 0
        End If
        If swhl1.Trim <> sPrevWhl.Trim Then
            lPrevWhlPilotSlNo = 0  ' i.e. wheel not in shiftrecords ignore condition
        End If
        da = Nothing
        ds = Nothing
        swhl1 = Nothing
        swhl2 = Nothing
    End Sub
    ReadOnly Property getPrevWheel() As String
        Get
            getPrevWheel = sPrevWhl
        End Get
    End Property
    ReadOnly Property IsValidWheel() As Boolean
        Get
            Dim blnresult As Boolean = False
            If Left(sLineNumber, 1) = "1" Then
                blnresult = ((flgGrindStatus And flgMcnOpn And flgWheelStatus And flgUTStatus And flgWheelNumber And flgMouldRoomStatus) And sWheelNumber.IndexOfAny("/") > 0) And sWheelNumber.Trim <> ""
            Else
                blnresult = (flgGrindStatus And flgMcnOpn And flgWheelStatus And flgUTStatus And flgWheelNumber And flgMouldRoomStatus) And sWheelNumber.IndexOfAny("/") > 0 And flgFirstLineProcessed = True And flgNewSerieswhl = False And sWheelNumber.Trim <> "" And flgwheelNotFound = False
            End If
            If Left(sLineNumber, 1) = "2" Then
                If Left(sWheelStatus.Trim.ToLower, 2) = "st" And iBHNStatus0 < 1 And blnresult = True Then
                    sErrorMessage &= "BHN not entered. Cannot be Stocked."
                    blnresult = False
                    blnError = True
                End If
            End If
            If Left(sLineNumber, 1) = "1" And sLineNumber <> "1A" Then
                If iBHNStatus2 < 1 And blnresult = True And s2ndPrevWhl <> "" Then
                    sErrorMessage &= "BHN not entered for " & s2ndPrevWhl & " . Cannot be Stocked."
                    blnresult = False
                    blnError = True
                End If
                If IsDBNull(iBHNStatus2) And blnresult = True And s2ndPrevWhl <> "" Then
                    sErrorMessage &= "BHN not entered for " & s2ndPrevWhl & " . Cannot be Stocked." '
                    blnresult = False
                    blnError = True
                End If
            End If
            If sLineNumber = "1A" Then
                If iBHNStatus0 < 1 And blnresult = True Then
                    sErrorMessage &= "BHN not entered for " & s2ndPrevWhl & " . Cannot be Stocked." '
                    blnresult = False
                    blnError = True
                End If
                If IsDBNull(iBHNStatus0) And blnresult = True Then
                    sErrorMessage &= "BHN not entered for " & s2ndPrevWhl & " . Cannot be Stocked." '
                    blnresult = False
                    blnError = True
                End If
            End If
            If Left(sLineNumber, 1) = "2" Then
                If blnchkPlatePass = True Then
                    If sMcnOperation.ToLower.IndexOfAny("/p") >= 0 Then
                        If blnresult = True Then
                            blnresult = True
                        Else
                            blnresult = False
                        End If
                    Else
                        blnresult = False
                    End If
                End If
            End If
            If blnresult = False Then
                blnError = True
            End If
            If blnresult = True Then
                If sLineNumber = "1A" Then
                    If ((iBHNStatus0 > 0 And (iBHNStatus0 > 399 Or iBHNStatus0 < 200))) = True Then
                        blnresult = False
                        sErrorMessage &= " Check BHN of current wheel between 200 and 399" '
                    End If
                End If
                If sLineNumber = "1" Or sLineNumber = "1B" Then
                    If ((iBHNStatus1 > 0 And (iBHNStatus1 > 399 Or iBHNStatus1 < 200))) = True Then
                        blnresult = False
                        sErrorMessage &= " Check BHN of previous wheel between 200 and 399" ' 
                    End If
                    If ((iBHNStatus2 > 0 And (iBHNStatus2 > 399 Or iBHNStatus2 < 200))) = True Then
                        blnresult = False
                        sErrorMessage &= " Check BHN of 2nd Previous wheel between 200 and 399  " '
                    End If
                End If
            End If
            If flgCurWheelTypeChange = True Then
                If TypeOverride = False Then
                    blnresult = False
                End If
            End If

            ' added on 25-9-04  to handle cannot be platepassed wheels coming on line 2/2A
            If LastMcnOperation <> "" And LastMcnOperation.ToUpper.IndexOf("/P") < 0 Then
                If CanBePlatePassed(LastMcnOperation) = False And Left(sLineNumber, 1) = "2" Then                    If blnresult = True Then                        blnError = True
                        sErrorMessage &= "Cannot be Plate Passed. Reload on Line 1/1A"  '                        blnresult = False
                    End If
                End If
            End If
            ' added on 5-4-05 as per user requirement 
            ' that rht wheel not to be accepted in line 2/2A
            If blnresult = True Then
                If flgcurWheelRHT = True Then
                    If Left(sLineNumber, 1) = "2" Then
                        blnresult = False
                    End If
                End If
            End If
            ' added on 18-2-08 as per Mr. Hegde
            'If lHeatNumber = 66980 Or lHeatNumber = 67042 Then ' rem on 25-2-08 as per Mr.Hegde
            'If lHeatNumber = 66980 Or lHeatNumber = 67847 Then
            '    sErrorMessage = "High Carbon Heat. Mark for HF." & sErrorMessage
            'End If
            ' check for heats hold from magna processing and display message corrected on 11-4-2008 as instructed by Mr.Hegde orally
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@Message", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            cmd.Parameters.Add("@HoldWhlType", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output

            cmd.CommandText = "select @Message = Message, @HoldWhlType = HoldWhlType from mm_HoldHeatsFromMagProcessing  where heat_number = " & lHeatNumber.ToString.Trim & " and convert(smalldatetime, convert(varchar(11),getdate())) <= isnull(HoldToDate, convert(smalldatetime, convert(varchar(11),getdate())))"
            Try
                cmd.Connection.Open()
                Dim msg As String
                cmd.ExecuteScalar()
                msg = cmd.Parameters("@Message").Value & ""
                Dim sHoldWhlType As String
                sHoldWhlType = cmd.Parameters("@HoldWhlType").Value & ""

                ' msg = IIf(IsDBNull(cmd.ExecuteScalar), "", cmd.ExecuteScalar)
                If msg <> "" Then
                    If sHoldWhlType <> "" Then
                        If Left(sHoldWhlType, 4).ToUpper.Trim = Left(sWheelTypeFromMaster, 4).ToUpper.Trim Then
                            blnresult = False
                            blnError = True
                            sErrorMessage &= msg '
                        End If
                    Else
                        blnresult = False
                        blnError = True
                        sErrorMessage &= msg '
                    End If
                End If
                msg = Nothing
                sHoldWhlType = Nothing
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If IsNothing(cmd) = False Then
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                End If
            End Try
            IsValidWheel = blnresult
            blnresult = Nothing
        End Get
    End Property
    Property TypeOverride() As Boolean
        Get
            TypeOverride = blnTypeOverride
        End Get
        Set(ByVal Value As Boolean)
            blnTypeOverride = Value
        End Set
    End Property
    Public Sub dispose()
        'MyBase.Finalize() ' removed purposefully on 5/8/05 svi
    End Sub
    Public Sub New() '(ByVal whlno As String, ByVal sLine As String, ByVal sWheelType As String)
        MyBase.new()
    End Sub
    Public Sub getwheeldata(ByVal dtestdate As Date, ByVal dpinkdate As Date)
        DispLastStatus()
        setflagsOnLoad()
        checkwheel()
        If sLineNumber = "1" Or sLineNumber = "1B" Then ' previouswheels(dtestdate, dpinkdate) brought in if block on 30/5/2006 svi
            previouswheels(dtestdate, dpinkdate)
        End If
        Dim str1 As String
        str1 = WheelTypeChange(sWheelNumber, sWheelType)
        If flgWheelTypeChange = True Then
            ErrorMessage(str1, True)
        End If
        str1 = Nothing
    End Sub
    Property LineNumber() As String
        Get
            LineNumber = sLineNumber
        End Get
        Set(ByVal Value As String)
            sLineNumber = Value
        End Set
    End Property
    Public Property wheel_Number() As String
        Get
            wheel_Number = sWheelNumber
        End Get
        Set(ByVal Value As String)
            sWheelNumber = Value
        End Set
    End Property
    Public Function WheelNotFound() As Boolean
        WheelNotFound = flgwheelNotFound
    End Function
    Private Sub setflagsOnLoad()
        flgwheelNotFound = False
        flgGrindStatus = True
        flgMcnOpn = True
        flgWheelStatus = True
        flgUTStatus = True
        flgWheelNumber = True
        flgMouldRoomStatus = True
        flgCurWheelTypeChange = False
        flgRHTWheel = False
    End Sub
    Private Sub checkwheel()
        Select Case sCurLocation.Trim.ToLower
            Case "clmt"
                Select Case Left(sMasterStatus.Trim.ToLower, 3)
                    Case "rew"
                    Case "xc8" ' added on 24-03-05
                    Case Else
                        flgWheelNumber = False
                End Select
            Case "clfi"
                Select Case Left(sMasterStatus.Trim.ToLower, 1)
                    Case "m"
                    Case Else
                        flgWheelNumber = False
                End Select
            Case "clfq"
                Select Case Left(sMasterStatus.Trim.ToLower, 1)
                    Case "w"
                    Case Else
                        flgWheelNumber = False
                End Select
            Case "clqc"
                flgWheelNumber = False
            Case "mopo"
                'Rmarked as per User Request letter no: RWF/WS/MR/035 DATED:10-10-2012
                'ON 12Oct2012 to allow numeric marked wheels at pouring
                'Select Case Left(sMasterStatus.Trim.ToLower, 1)
                '    Case Is = "x", "6", "7", "2"
                '        flgMouldRoomStatus = False
                '    Case Else
                '        flgMouldRoomStatus = True
                'End Select
                flgMouldRoomStatus = validateMopoWheel(sMasterStatus.Trim.ToLower)
            Case Else
                If sCurStatus = "Wheel Not Found" And sCurLocation = "" Then
                    flgwheelNotFound = True
                    flgWheelNumber = False
                Else
                    flgWheelNumber = True
                End If

        End Select
        If sCurLocation.Trim.ToLower = "mopo" And Left(sLineNumber, 1) = "2" Then
            flgFirstLineProcessed = False
        Else
            flgFirstLineProcessed = True
        End If
        If IsHeatNumberValid() = False Then
            flgWheelNumber = False
        End If
    End Sub
    Private Function validateMopoWheel(ByVal MasterStatus As String) As Boolean
        Return IIf(Not (((Val(MasterStatus) > 0 And Val(MasterStatus) <> 6 And Val(MasterStatus) <> 7) OrElse MasterStatus.Trim.Length = 0) OrElse (Val(MasterStatus) = 0 And MasterStatus.Trim.ToUpper = "OK")), False, True)
    End Function
    ReadOnly Property CurGrindStatus() As String
        Get
            CurGrindStatus = sCurGrindSts
        End Get
    End Property
    ReadOnly Property CurMcnStatus() As String
        Get
            CurMcnStatus = sCurMcnSts
        End Get
    End Property
    ReadOnly Property LastStatus() As String
        Get
            LastStatus = sCurStatus
        End Get
    End Property
    Private Sub ResetStatusses()
        sLastTestDate = ""
        sLastLine = ""
        sPrevMcnOpn = ""
        sGrindStatus = ""
        sCurLocation = ""
        sWheelType = ""
        sWheelTypeFromMaster = ""
        sMasterStatus = ""
        sMagRecord = ""
        dBHNRate = 0
        sFIRecord = ""
        sYardRecord = ""
        sQCRecord = ""
        sCurStatus = "Wheel Not Found"
        sCurGrindSts = ""
        sCurMcnSts = ""
        lWheelNumber = 0
        lHeatNumber = 0
        sQciStatus = ""
        sFiStatus = ""
        sMcnStatus = ""
        sLine_number = ""
        sMouldRoomStatus = ""
    End Sub
    ReadOnly Property prevGrindSts() As String
        Get
            prevGrindSts = sPrevGrindSts
        End Get
    End Property
    ReadOnly Property prevMcnOpn() As String
        Get
            prevMcnOpn = sPrevMcnOpn
        End Get
    End Property
    ReadOnly Property NewSeriesWheel() As Boolean
        Get
            NewSeriesWheel = flgNewSerieswhl
        End Get
    End Property
    ReadOnly Property LastTestDate() As String
        Get
            LastTestDate = sLastTestDate
        End Get
    End Property
    ReadOnly Property LastLine() As String
        Get
            LastLine = sLastLine
        End Get
    End Property
    Private Sub DispLastStatus()
        ResetStatusses()
        If sWheelNumber.Trim = "" Then
            Exit Sub
        End If
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.CommandText = "mm_sp_magproc_wheelInfo"
        da.SelectCommand.Parameters.Add("@wheelnumber", SqlDbType.VarChar, 50)
        da.SelectCommand.Parameters("@wheelnumber").Direction = ParameterDirection.Input
        da.SelectCommand.Parameters("@wheelnumber").Value = sWheelNumber.Trim
        Dim ds As New DataSet()
        Try
            da.Fill(ds, "WheelInfo")
        Catch exp As Exception
            ds = Nothing
        Finally
            da.Dispose()
        End Try
        Dim row As DataRow
        For Each row In ds.Tables("WheelInfo").Rows
            sCurLocation = row("CurLocation") & ""
            sWheelType = row("WheelType") & ""
            sWheelTypeFromMaster = sWheelType
            sMasterStatus = row("MasterStatus") & ""
            sMagRecord = row("MagRecord") & ""
            dBHNRate = IIf(IsDBNull(row("BHNRate")), 0, row("BHNRate"))
            sFIRecord = row("FIRecord") & ""
            sYardRecord = row("YardRecord") & ""
            sQCRecord = row("QCRecord") & ""
            lWheelNumber = row("wheel_number")
            lHeatNumber = row("heat_number")
            lRegular_heat_for_mgc_wheels = row("Regular_heat_for_mgc_wheels")
            sQciStatus = row("Qci_Status") & ""
            sFiStatus = row("fi_status") & ""
            sPrevGrindSts = row("GrindStatus") & ""
            sPrevMcnOpn = row("Mcn_Status") & ""
            sLine_number = row("Line_Number") & ""
            sMouldRoomStatus = row("MouldRoomStatus") & ""
            cPrevUTStatus = row("Ut_Status") & ""
            sLastTestDate = row("LastTestDate") & ""
            sLastLine = row("LastLine") & ""
        Next
        ds.Dispose()
        sCurStatus = "Wheel Not Found"
        sMcnStatus = sPrevMcnOpn
        flgNewSerieswhl = False
        Select Case sCurLocation.ToLower.Trim
            Case "clmt" : sCurStatus = sMagRecord & " Location : CLMT "
            Case "clfi" : sCurStatus = sFIRecord & " Location : CLFI "
            Case "clqc" : sCurStatus = sYardRecord & " Location : CLQC "
            Case "clfq" : sCurStatus = sQCRecord & " Location : CLFQ "
            Case "mopo" : sCurStatus = sMouldRoomStatus & " Location : MOPO "
            Case Else
                If Val(sWheelNumber) >= 100000 Then
                    If sWheelNumber.IndexOfAny("/") > 0 Then
                        sCurStatus = "New Series Wheel."
                        blnError = False
                        flgNewSerieswhl = True
                    Else
                        ErrorMessage("Heat Number to be entered with / prefixed")
                        blnError = True
                        flgWheelNumber = False
                        sCurStatus = "New Series Wheel."
                    End If
                Else
                    If sCurLocation = "" Then
                        sCurStatus = "Wheel Not Found"
                    End If
                End If
        End Select
        If sMcnStatus.Trim <> "" Then
            Dim arr() As String
            arr = Split(sMcnStatus, ",")
            blnchkPlatePass = False
            If arr.Length = 1 Then
                blnchkPlatePass = sMcnStatus.Trim.ToUpper.IndexOf("/P") = -1
            End If
            arr = Nothing
        End If
        da = Nothing
        ds = Nothing
        row = Nothing
    End Sub
    Property CurrentWheelType() As String
        Get
            CurrentWheelType = sWheelType
        End Get
        Set(ByVal Value As String)
            sWheelType = Value
            Dim str1 As String
            str1 = WheelTypeChange(sWheelNumber, sWheelType)
            ErrorMessage(str1, True)
            str1 = Nothing
        End Set
    End Property
    ReadOnly Property CurrentLocation() As String
        Get
            CurrentLocation = sCurLocation
        End Get
    End Property
    ReadOnly Property CurrentMasterStatus() As String
        Get
            CurrentMasterStatus = sMasterStatus
        End Get
    End Property
    Property McnOpnCodes() As String
        Get
            McnOpnCodes = sMcn
        End Get
        Set(ByVal Value As String)
            sMcn = Value
        End Set
    End Property
    Property LocCodes() As String
        Get
            Return sLocCodes
        End Get
        Set(ByVal Value As String)
            sLocCodes = Value
        End Set
    End Property
    Property DefCodes() As String
        Get
            Return sDefCodes
        End Get
        Set(ByVal Value As String)
            sDefCodes = Value
        End Set
    End Property
    ReadOnly Property Message()
        Get
            Return sMessage
        End Get
    End Property
    ReadOnly Property WheelStatusText() As String
        Get
            Try
                If IsNothing(sGrindStatus) = False AndAlso (sGrindStatus.Trim <> "") Then
                    sWheelStatus = "REWORK"
                End If
                If IsNothing(sMcnOperation) = False AndAlso sMcnOperation.Trim <> "" Then
                    sWheelStatus = "REWORK"
                End If
                If Left(sWheelStatus, 2).ToLower <> "xc" And Left(sWheelStatus, 2).ToLower <> "re" Then
                    sWheelStatus = "STOCK"
                End If
                ' If sLineNumber = "1" And flgcurWheelRHT = True Then
                'As per user requirement corrected on 5-4-05 that rht wheel
                ' not to be processed for any other status.
                If flgcurWheelRHT = True Then
                    sWheelStatus = "XC8RHT"
                End If
                If CStr(cUTStatus).ToUpper = "R" Then
                    If Left(sWheelStatus, 4).ToUpper <> "XC16" Then
                        sWheelStatus = "XC16"
                    End If
                Else
                    If IsNothing(sGrindStatus) = False AndAlso (sGrindStatus.Trim <> "") Then
                        sWheelStatus = "REWORK"
                    End If
                    If IsNothing(sMcnOperation) = False AndAlso (sMcnOperation.Trim <> "") Then
                        sWheelStatus = "REWORK"
                    End If
                    If Left(sWheelStatus, 2).ToLower <> "xc" And Left(sWheelStatus, 2).ToLower <> "re" Then
                        sWheelStatus = "STOCK"
                    End If
                    If sLineNumber = "1A" And flgcurWheelRHT = True Then
                        sWheelStatus = "XC8RHT"
                    End If
                End If
                If Left(sWheelStatus, 4).ToUpper = "XC16" Then
                    cUTStatus = "R"
                End If
                WheelStatusText = sWheelStatus
                If sWheelStatus.Trim.ToUpper = "XC8RHT" Then
                    sGrindStatus = ""
                    sMcnOperation = ""
                End If
                If sWheelStatus.Trim.ToUpper = "XC16" Then
                    sGrindStatus = ""
                    sMcnOperation = ""
                End If
            Catch exp As Exception
                sErrorMessage = exp.Message
                WheelStatusText = ""
            End Try
        End Get
    End Property
    ReadOnly Property BtnSaveText() As String
        Get
            BtnSaveText = "Save"
            If sWheelStatus = Nothing Then
                sWheelStatus = ""
            End If
            If sWheelStatus.Trim.ToLower = "stock" Then
                BtnSaveText = "STOCK"
            End If
        End Get
    End Property
    Property pinkdate() As Date
        Get
            Return dPinkDate
        End Get
        Set(ByVal Value As Date)
            dPinkDate = Value
        End Set
    End Property
    Private Sub setflagsOnwheelcheck()
        flgGrindStatus = True
        flgMcnOpn = True
        flgWheelStatus = True
        flgUTStatus = True
        flgWheelNumber = True
        flgNewSerieswhl = False
    End Sub
    Public ReadOnly Property ErrStatus() As Boolean
        Get
            ErrStatus = blnError
        End Get
    End Property
    Private Sub ErrorMessage(ByVal msg As String, Optional ByVal warning As Boolean = False)
        sErrorMessage = msg
    End Sub
    ReadOnly Property ErrMessage()
        Get
            ErrMessage = sErrorMessage
        End Get
    End Property
    ReadOnly Property MagWheelNumber() As Long
        Get
            Dim whlarr() As String
            whlarr = Split(sWheelNumber, "/")
            MagWheelNumber = CLng(whlarr(0))
            whlarr = Nothing
        End Get
    End Property
    WriteOnly Property WorkOrder() As String
        Set(ByVal Value As String)
            sWorkOrder = Value
        End Set
    End Property
    ReadOnly Property MagHeatNumber() As Long
        Get
            Dim whlarr() As String
            whlarr = Split(sWheelNumber, "/")
            MagHeatNumber = CLng(whlarr(1))
            If MagHeatNumber >= 1 And MagHeatNumber <= 999 Then
                MagHeatNumber = lRegular_heat_for_mgc_wheels
            End If
            whlarr = Nothing
        End Get
    End Property
    Property GrindStatus() As String
        Get
            GrindStatus = sGrindStatus
        End Get
        Set(ByVal Value As String)
            If Value.Trim = "" Then
                sGrindStatus = ""
            Else
                validateGrindStatus(Value)
            End If
        End Set
    End Property
    ReadOnly Property CanBePlatePassed(ByVal mcnopn As String, Optional ByVal convert_to_SingleCharacterCode As Boolean = False) As Boolean
        Get
            If convert_to_SingleCharacterCode = True Then
                mcnopn = ConvertToSingleMcnCode(mcnopn)
            End If
            mcnopn = mcnopn.Replace(",", "")
            If mcnopn.Trim.Length > 1 Then  ' for no plate pass for multiple mcn operations
                blnchkPlatePass = False
            Else
                Select Case mcnopn.Trim
                    Case "T", "R", "F", "M", "H"  ' only these mcn operations can be platepassed 
                        blnchkPlatePass = True
                    Case Else
                        blnchkPlatePass = False
                End Select
            End If
            CanBePlatePassed = blnchkPlatePass
            ' added on 05-04-05 as user requirement that rht wheel 
            ' not to be processed for any other reason that xc8rht
            If flgcurWheelRHT = True Then
                sWheelStatus = "XC8RHT"
                sGrindStatus = ""
                sMcnOperation = ""
                CanBePlatePassed = False
            End If
        End Get
    End Property
    ReadOnly Property LastMcnOperation() As String
        Get
            sMcnStatus = sMcnStatus.Replace("HB", "B")
            sMcnStatus = sMcnStatus.Replace("HT", "T")
            sMcnStatus = sMcnStatus.Replace("HF", "F")
            sMcnStatus = sMcnStatus.Replace("VT", "V")
            sMcnStatus = sMcnStatus.Replace("HR", "R")
            sMcnStatus = sMcnStatus.Replace("HP", "P")
            sMcnStatus = sMcnStatus.Replace("BR", "M")
            sMcnStatus = sMcnStatus.Replace("BH", "H")
            LastMcnOperation = sMcnStatus
        End Get
    End Property
    Public Function ConvertToSingleMcnCode(ByVal mcncode As String) As String
        mcncode = mcncode.Replace("HB", "B")
        mcncode = mcncode.Replace("HT", "T")
        mcncode = mcncode.Replace("HF", "F")
        mcncode = mcncode.Replace("VT", "V")
        mcncode = mcncode.Replace("HR", "R")
        mcncode = mcncode.Replace("HP", "P")
        mcncode = mcncode.Replace("BR", "M")
        mcncode = mcncode.Replace("BH", "H")
        sMcnStatus = mcncode
        ConvertToSingleMcnCode = mcncode
    End Function
    Property McnOperation() As String
        Get
            McnOperation = sMcnOperation
        End Get
        Set(ByVal Value As String)
            validateMcnOperation(Value)
        End Set
    End Property
    Property UTStatus() As Char
        Get
            UTStatus = cUTStatus
        End Get
        Set(ByVal Value As Char)
            cUTStatus = Value
        End Set
    End Property
    Property BHNStatus_for2ndPrevWheel(ByVal sSelectedWhlType As String) As Integer
        Get
            BHNStatus_for2ndPrevWheel = iBHNStatus2
        End Get
        Set(ByVal Value As Integer)
            Warning(getSecondPrevWheel(), Value, sSecondPrevwhltype)
            'Warning(getSecondPrevWheel(), Value, sSelectedWhlType)
            flgSecondWheelRHT = flgRHTWheel ' to be rectified 
            'flgSecondWheelRHT = False
            ' Not necessary to check wheeltype change since wheeltype is checked for current wheel only
            Dim str1 As String = ""
            If (flgSecondWheelRHT) Then
                str1 = "Wheel No.: " & getSecondPrevWheel() & " - " & sErrorMessage
            Else
                str1 = ""
            End If
            ErrorMessage(str1, True)
            iBHNStatus2 = Value
            str1 = Nothing
        End Set
    End Property
    ReadOnly Property SecondWheelRHT() As Boolean
        Get
            SecondWheelRHT = flgSecondWheelRHT
        End Get
    End Property
    ReadOnly Property FirstWheelRHT() As Boolean
        Get
            FirstWheelRHT = flgFirstWheelRHT
        End Get
    End Property
    Property BHNStatus_for1stPrevWheel(ByVal sSelectedWhlType As String) As Integer
        Get
            BHNStatus_for1stPrevWheel = iBHNStatus1
        End Get
        Set(ByVal Value As Integer)
            ' remarked on 5.4.05 to avoid type change for first / second prev whl 
            ' Warning(getPrevWheel(), Value, sSelectedWhlType)
            Warning(getPrevWheel(), Value, sPrevwhltype)
            flgFirstWheelRHT = flgRHTWheel
            ' Not necessary to check wheeltype change since wheeltype is checked for current wheel only
            Dim str1 As String
            If (flgFirstWheelRHT) Then
                str1 = "Wheel No.: " & getPrevWheel() & " - " & sErrorMessage
            Else
                str1 = ""
            End If
            ErrorMessage(str1, True)
            iBHNStatus1 = Value
            str1 = Nothing
        End Set
    End Property
    Property BHNStatus_forCurWheel(ByVal sSelectedWhlType As String) As Integer
        Get
            BHNStatus_forCurWheel = iBHNStatus0
        End Get
        Set(ByVal Value As Integer)
            Dim str1 As String = ""
            Dim Str2 As String = ""
            Dim str3 As String = ""

            Str2 = WheelTypeChange(sWheelNumber, sSelectedWhlType)
            str1 = Warning(sWheelNumber, Value, sSelectedWhlType)
            flgcurWheelRHT = flgRHTWheel
            flgCurWheelTypeChange = flgWheelTypeChange
            If flgcurWheelRHT = True Or flgCurWheelTypeChange = True Then
                str3 = " Wheel No.: " & sWheelNumber & " - "
                If flgRHTWheel = True Then
                    str3 &= str1
                End If
                If flgCurWheelTypeChange = True Then
                    str3 &= " " & sErrorMessage
                End If
            End If
            ErrorMessage(str3, True)
            iBHNStatus0 = Value
            str1 = Nothing
            Str2 = Nothing
            str3 = Nothing
        End Set
    End Property
    ReadOnly Property CurWheelRHT() As Boolean
        Get
            CurWheelRHT = flgcurWheelRHT
        End Get
    End Property
    Public Sub UTPassed(ByVal passed As Boolean)
        If passed = True Then
            cUTStatus = "P"
            sWheelStatus = ""
        Else
            cUTStatus = "R"
            sWheelStatus = "XC16"
        End If
    End Sub
    Public Sub MagTrans(ByRef dgtrans As System.Web.UI.WebControls.DataGrid)
        Dim ds As New DataSet()
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Try
            da.SelectCommand.CommandText = "select convert(varchar, test_date, 103) Test_date, " & _
                " Shift_code, Line_number, Grind_Status, Mcn_Operation, Wheel_Status, " & _
                " Inspector_cope, Inspector_Drag, Remarks " & _
                " from mm_magnaglow_results where wheel_number = " & lWheelNumber & " " & _
                " and heat_number = " & lHeatNumber & " order by sl_no desc "
            da.Fill(ds)
            dgtrans.DataSource = ds.Tables(0)
            dgtrans.DataBind()
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            da.Dispose()
            ds.Dispose()
            da = Nothing
            ds = Nothing
        End Try
    End Sub
    Private Function WheelTypeChange(ByVal whlno As String, ByVal sSelectedWhlType As String) As String
        Dim sWhltype As String
        Dim whlarr() As String
        Dim str1 As String = ""
        whlarr = Split(whlno, "/")
        flgWheelTypeChange = False
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            cmd.Connection.Open()
            cmd.Parameters.Add("@Whltype", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            If Left(sSelectedWhlType, 3).ToUpper = "MGC" Then
                cmd.CommandText = "Select @Whltype = isnull(rtrim(description),'') from mm_wheel where wheel_number = " & Val(whlarr(0)) & " and heat_number = " & lRegular_heat_for_mgc_wheels
            Else
                cmd.CommandText = "Select @Whltype = isnull(rtrim(description),'') from mm_wheel where wheel_number = " & Val(whlarr(0)) & " and heat_number = " & Val(whlarr(1))
            End If
            cmd.ExecuteScalar()
            sWhltype = IIf(IsDBNull(cmd.Parameters("@Whltype").Value), "", cmd.Parameters("@Whltype").Value)
            If sWhltype = Nothing Then
                sWhltype = ""
            End If
            If sWhltype = "" Then
                If Val(whlarr(1)) = 0 Then   ' wheel type for new series wheel
                    cmd.CommandText = "select @Whltype = isnull(rtrim(description),'') from mm_product_details where product_code like '[1,2]%' and " & whlarr(0) & "  between series_start and series_end"
                    cmd.ExecuteScalar()
                    sWhltype = IIf(IsDBNull(cmd.Parameters("@Whltype").Value), "", cmd.Parameters("@Whltype").Value)
                End If
            End If
        Catch exp As Exception
            sWhltype = ""
            Throw New Exception(exp.Message)
        Finally
            cmd.Dispose()
            cmd = Nothing
        End Try
        If sWhltype = Nothing Then
            If sCurStatus.ToLower.Trim = "new series wheel." Then
                flgWheelNumber = False
                str1 = "Invalid Series Wheel Number."
                blnError = True
            End If
            sWhltype = ""
        End If
        If sWhltype.Trim.ToUpper <> sSelectedWhlType.Trim.ToUpper Then
            sWheelType = sSelectedWhlType  ' Assign user selected type as override and warn.
            If sCurStatus.ToLower.Trim.ToLower <> "new series wheel." Then
                str1 = "Wheel Type MisMatch. Previous Record Shows: " & sWhltype.Trim
                str1 += ". Mould Room "
                str1 += " Records of Wheel Type will be modified to : " & sSelectedWhlType.Trim
                str1 += " if saved."
            Else
                If flgWheelNumber = True Then
                    str1 = "Wheel Type MisMatch. This series wheel should have been of type : " & sWhltype.Trim
                    str1 += ". Mould Room "
                    str1 += " Wheel Type will be modified to : " & sSelectedWhlType.Trim
                    str1 += " if saved."
                Else
                    'str1 = ""
                End If
            End If
            flgWheelTypeChange = True
        Else
            If flgWheelNumber = True Then
                str1 = ""
            End If
        End If
        WheelTypeChange = str1
        whlarr = Nothing
        str1 = Nothing
        sWhltype = Nothing
    End Function
    Private Function Warning(ByVal whlno As String, ByVal value As Integer, ByVal sSelectedWhlType As String) As String
        Dim str1 As String
        Dim iLowBhn, iHighBhn As Integer
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        da.SelectCommand.CommandText = "Select top 1   isnull(b.low_bhn,0) low_bhn  ,  " & _
            " isnull(b.high_bhn, 0) high_bhn from mm_product_master b " & _
            " where b.description like '" & getwheeltype(whlno) & "%' and product_code like '[1,2]%'"         ' to check wheel type of actual wheel no passed to this function added on 20/12/05 svi
        Dim dsBhn As New DataSet()
        Try
            da.Fill(dsBhn, "BHNRef")
            Dim dr As DataRow = dsBhn.Tables("BHNRef").Rows(0)
            iLowBhn = dr("low_bhn")
            iHighBhn = dr("high_bhn")
        Catch exp As Exception
            iLowBhn = 600   ' purposefully given to make wheel rht and user will call in such case  
            iHighBhn = 600  '
        Finally
            da.Dispose()
        End Try
        If (value <= iLowBhn Or value >= iHighBhn) And value > 0 And iLowBhn > 0 And iHighBhn > 0 Then
            str1 = "Warning : BHN Beyond Range. Check your inputs before saving. "
            flgRHTWheel = True
            Warning = "XC8RHT"
        Else
            str1 = ""
            flgRHTWheel = False
            Warning = ""
        End If
        ErrorMessage(str1, True)
        da = Nothing
        dsBhn = Nothing
        str1 = Nothing
        iLowBhn = Nothing
        iHighBhn = Nothing
    End Function
    Private Function getwheeltype(ByVal wheelno As String) As String
        If wheelno.IndexOf("/") <= 0 Then
            wheelno = wheelno + "/0"
        End If
        Dim whlarr() As String
        whlarr = Split(wheelno, "/")
        Dim lwhlno, lhtno As Long
        lwhlno = Val(whlarr(0))
        lhtno = Val(whlarr(1))
        Dim strType As String = ""
        Try
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Connection.Open()
                cmd.Parameters.Add("@strType", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                cmd.CommandText = "select @strType = description from mm_wheel where wheel_number = " & lwhlno & " and heat_number = " & lhtno
                cmd.ExecuteScalar()
                strType = IIf(IsDBNull(cmd.Parameters("@strType").Value), "", cmd.Parameters("@strType").Value)
            Catch exp As Exception
                strType = ""
                Throw New Exception(exp.Message)
            Finally
                cmd.Dispose()
                cmd = Nothing
            End Try
            If strType = Nothing Then
                strType = sWheelType
            End If
        Catch exp As Exception
            strType = sWheelType
        End Try
        getwheeltype = strType.Trim
        strType = Nothing
        whlarr = Nothing
        lwhlno = Nothing
        lhtno = Nothing
    End Function
    Property Remarks() As String
        Get
            Remarks = sRemarks
        End Get
        Set(ByVal Value As String)
            sRemarks = Value
        End Set
    End Property
    Property WheelStatus() As String
        Get
            WheelStatus = sWheelStatus
        End Get
        Set(ByVal Value As String)
            If Value <> "" Then
                validateWheelStatus(Value)
            Else
                sWheelStatus = ""
            End If
        End Set
    End Property
    Private Sub validateGrindStatus(ByVal grsts As String)
        Try
            Dim arr As Array
            Dim input(), code, location, defCode(), locCode(), inlocCode(), tmpLoc, strInput, strCode, strLocation As String
            Dim i, j As Integer
            arr = Split(grsts.ToUpper.Trim, ",")
            input = arr
            arr = Split(sDefCodes, ",")
            defCode = arr
            arr = Split(sLocCodes, ",")
            locCode = arr
            strInput = ""
            strCode = ""
            strLocation = ""
            For i = 0 To input.Length - 1
                code = Val(input(i).Trim)
                location = input(i).Replace(Val(input(i).Trim.ToUpper), "")
                If defCode.LastIndexOf(defCode, code) <> -1 Then
                    If strInput.Trim <> "" Then
                        strInput &= ","
                    End If
                    If strLocation.Trim <> "" Then
                        strLocation &= ","
                    End If
                    strInput &= code.Trim
                    If location.Trim <> "" Then
                        arr = Split(location, "/")
                        inlocCode = arr
                        tmpLoc = ""
                        For j = 0 To inlocCode.Length - 1
                            If locCode.LastIndexOf(locCode, inlocCode(j).Trim) <> -1 Then

                                tmpLoc &= inlocCode(j).Trim.ToUpper
                                If Val(Left(tmpLoc, 2)) = 0 Then
                                    tmpLoc &= "/"
                                End If
                            End If
                        Next
                        If tmpLoc <> "" And Right(tmpLoc.Trim, 1) = "/" Then tmpLoc = Left(tmpLoc.Trim, tmpLoc.Trim.Length - 1)
                        If tmpLoc <> "" Then
                            If Val(Left(tmpLoc, 2)) > 0 Then
                                strInput &= "/"
                            End If
                            strInput &= tmpLoc.Trim
                        Else
                            If strLocation = "" Then
                                strLocation = "Given Location Code are not Valid: " & location & ","
                            Else
                                strLocation &= location.Trim '& ","
                            End If
                        End If
                    End If
                Else
                    If strCode = "" And Val(code) > 0 Then
                        strCode = "Given Defect Code are not Valid: " & code.Trim & ","
                    Else
                        If code.Trim <> "" Then
                            strCode &= code.Trim & ","
                        End If
                    End If
                End If
            Next
            If strInput <> "" And Right(strInput.Trim, 1) = "," Then strInput = Left(strInput.Trim, strInput.Trim.Length - 1)
            If strCode <> "" And Right(strCode.Trim, 1) = "," Then strCode = Left(strCode.Trim, strCode.Trim.Length - 1)
            If strLocation <> "" And Right(strLocation.Trim, 1) = "," Then strLocation = Left(strLocation.Trim, strLocation.Trim.Length - 1)
            If strCode <> "" Or strLocation <> "" Then
                ErrorMessage(strCode & " " & strLocation)
                flgGrindStatus = False
                blnError = True
                sGrindStatus = ""
                Exit Sub
            Else
                blnError = False
                sGrindStatus = strInput
                flgGrindStatus = True
                ErrorMessage("")
            End If
            i = Nothing
            j = Nothing
            arr = Nothing
            input = Nothing
            code = Nothing
            location = Nothing
            defCode = Nothing
            locCode = Nothing
            inlocCode = Nothing
            tmpLoc = Nothing
            strInput = Nothing
            strCode = Nothing
            strLocation = Nothing
        Catch exp As Exception
            flgGrindStatus = False
            ErrorMessage(exp.Message)
        End Try
    End Sub
    Private Sub validateMcnOperation(ByVal mcnopn As String)
        ' Added on 5-4-05 as per user requriement
        If flgcurWheelRHT = True Then
            sWheelStatus = "XC8RHT"
            sMcnOperation = ""
            sGrindStatus = ""
            Exit Sub
        End If
        Dim errmsg As String
        errmsg = ""
        Dim preserved As String = ""
        If mcnopn.Trim.ToLower.EndsWith("/p") Then
            preserved = "/P"
            mcnopn = mcnopn.Replace("/p", "")
            mcnopn = mcnopn.Replace("/P", "")
        Else
            preserved = ""
        End If
        Try
            Dim arr As Array
            Dim mcn_operation As String
            mcn_operation = mcnopn ' sMcnStatus.Trim  ' last machine opn of the wheel.

            If mcn_operation.Trim <> "" Then
                arr = Split(mcn_operation, ",")
                If arr.Length = 1 Then
                    If mcn_operation.ToUpper.IndexOf("/P") = -1 Then
                        blnchkPlatePass = True
                    End If
                End If
            End If

            Dim chrArray() As Char = mcnopn.ToUpper.ToCharArray()
            Dim strMcn1 As String
            Dim strarray() As String = New String(chrArray.Length - 1) {}
            Dim i As Integer
            For i = 0 To chrArray.Length - 1
                strarray(i) = expand(chrArray(i))
            Next
            strMcn1 = ""
            Dim filled As Boolean = False
            Dim str1 As String = ""
            For i = 0 To strarray.Length - 1
                If i < strarray.Length And strMcn1 <> "" And filled = True Then
                    strMcn1 += ","
                End If
                str1 = strarray(i)
                If (strMcn1.IndexOf(str1)) < 0 Then
                    strMcn1 += strarray(i)
                    filled = True
                Else
                    filled = False
                End If
            Next

            Dim sInvalidList As String
            sInvalidList = mcnopn.ToUpper.Trim
            sInvalidList = sInvalidList.Replace("T", "")
            sInvalidList = sInvalidList.Replace("R", "")
            sInvalidList = sInvalidList.Replace("B", "")
            sInvalidList = sInvalidList.Replace("F", "")
            sInvalidList = sInvalidList.Replace("P", "")
            sInvalidList = sInvalidList.Replace("V", "")
            sInvalidList = sInvalidList.Replace("M", "")
            sInvalidList = sInvalidList.Replace("H", "")
            sInvalidList = sInvalidList.Replace(",", " ")
            sInvalidList = sInvalidList.Trim
            If sInvalidList.Trim <> "" Then
                errmsg = "Given MCN Code are not allowed: " & sInvalidList.Trim.ToUpper
            End If
            mcnopn = strMcn1.Trim

            Dim strInput As String
            strInput = strMcn1.Trim

            If strInput.EndsWith(",") = True Then
                If strInput <> "" Then strInput = Left(strInput.Trim, strInput.Trim.Length - 1)
            End If
            If strInput.IndexOf(",") < 0 Then
                sMcnOperation = strInput & preserved
            Else
                sMcnOperation = strInput
            End If
            errmsg = errmsg.Trim
            If errmsg.EndsWith(",") = True Then
                If errmsg <> "" Then errmsg = Left(errmsg.Trim, errmsg.Trim.Length - 1)
            End If

            If errmsg <> "" Then
                flgMcnOpn = False
                blnError = True
                ErrorMessage(errmsg)
            Else
                blnError = False
                flgMcnOpn = True
                ErrorMessage("")
            End If
            arr = Nothing
            mcn_operation = Nothing
            sInvalidList = Nothing
            strInput = Nothing
            filled = Nothing
            str1 = Nothing
            i = Nothing
            chrArray = Nothing
            strMcn1 = Nothing
            strarray = Nothing
        Catch exp As Exception
            flgMcnOpn = False
            ErrorMessage(exp.Message)
        End Try
        errmsg = Nothing
        preserved = Nothing
    End Sub
    Private Function expand(ByVal c As Char) As String
        Select Case c
            Case "T" : expand = "HT"
            Case "R" : expand = "HR"
            Case "B" : expand = "HB"
            Case "F" : expand = "HF"
            Case "P" : expand = "HP"
            Case "H" : expand = "BH"
            Case "V" : expand = "VT"
            Case "M" : expand = "BR"
        End Select
    End Function
    Private Sub validateWheelStatus(ByVal whlsts As String)
        If whlsts.ToLower = "xc8rht" Then
            If flgcurWheelRHT = False Then
                whlsts = ""
            Else
                Exit Sub
            End If
        End If

        whlsts = whlsts.ToUpper.Replace("XC", "")
        If Val(whlsts) = 0 Then
            Exit Sub
        End If
        Dim errmsgloc, errmsgdef, strInput As String
        strInput = ""
        errmsgdef = ""
        errmsgloc = ""
        Try
            Dim arr As Array
            Dim input(), code, location, defCode(), locCode(), inlocCode(), tmpLoc, strCode, strLocation As String
            Dim i, j As Integer
            arr = Split(whlsts.ToUpper.Trim, ",")
            input = arr
            arr = Split(sDefCodes, ",")
            defCode = arr
            arr = Split(sLocCodes, ",")
            locCode = arr
            strInput = ""
            strCode = ""
            strLocation = ""
            For i = 0 To input.Length - 1
                code = Val(input(i).Trim)
                location = input(i).Replace(Val(input(i).Trim.ToUpper), "")
                If defCode.LastIndexOf(defCode, code) <> -1 Then
                    If strInput.Trim <> "" Then
                        strInput &= ","
                    End If
                    If strLocation.Trim <> "" Then
                        strLocation &= ","
                    End If
                    strInput &= code.Trim
                    If location.Trim <> "" Then
                        arr = Split(location, "/")
                        inlocCode = arr
                        tmpLoc = ""
                        For j = 0 To inlocCode.Length - 1
                            If locCode.LastIndexOf(locCode, inlocCode(j).Trim) <> -1 Then
                                tmpLoc &= inlocCode(j).Trim.ToUpper & "/"
                            End If
                        Next
                        If tmpLoc <> "" Then tmpLoc = Left(tmpLoc.Trim, tmpLoc.Trim.Length - 1)
                        If tmpLoc <> "" Then
                            strInput &= tmpLoc.Trim ' & "," 'code.Trim & tmpLoc.Trim & ","
                        Else
                            If strLocation = "" Then
                                strLocation = "Given Location Code are not Valid: " & location & ","
                            Else
                                strLocation &= location.Trim '& ","
                            End If
                        End If
                    End If
                Else
                    If strCode = "" And Val(code) > 0 Then
                        strCode = "Given Defect Code are not Valid: " & code.Trim & ","
                    Else
                        If code.Trim <> "" Then
                            strCode &= code.Trim & ","
                        End If
                    End If
                End If
            Next
            If strInput <> "" And Right(strInput.Trim, 1) = "," Then strInput = Left(strInput.Trim, strInput.Trim.Length - 1)
            If strCode <> "" And Right(strCode.Trim, 1) = "," Then strCode = Left(strCode.Trim, strCode.Trim.Length - 1)
            If strLocation <> "" And Right(strLocation.Trim, 1) = "," Then strLocation = Left(strLocation.Trim, strLocation.Trim.Length - 1)
            If strCode <> "" Or strLocation <> "" Then
                ErrorMessage(strCode & " " & strLocation)
                flgWheelStatus = False
                blnError = True
                sWheelStatus = ""
                Exit Sub
            Else
                blnError = False
                sWheelStatus = strInput
                flgWheelStatus = True
                ' ErrorMessage("")
            End If

            sWheelStatus = strInput
            If errmsgdef <> "" Then
                flgWheelStatus = False
                ErrorMessage(errmsgdef)
                blnError = True
                Exit Sub
            End If
            If errmsgloc <> "" Then
                flgWheelStatus = False
                ErrorMessage(errmsgloc)
                blnError = True
                Exit Sub
            End If
            flgWheelStatus = True
            blnError = False
            ErrorMessage("")
            cUTStatus = "P"
            If Left(sWheelStatus.Trim.ToUpper, 2) = "16" Then
                cUTStatus = "R"
            End If
            If Left(sWheelStatus.Trim.ToUpper, 4) = "XC16" Then
                cUTStatus = "R"
            End If
            If Not (strInput Is Nothing) Then
                sWheelStatus = "XC" + strInput.Trim
            End If

            If sWheelStatus.Trim <> "" Then
                sMcnOperation = ""
                sGrindStatus = ""
            End If
            arr = Nothing
            input = Nothing
            code = Nothing
            location = Nothing
            defCode = Nothing
            locCode = Nothing
            inlocCode = Nothing
            tmpLoc = Nothing
            strCode = Nothing
            strLocation = Nothing
            i = Nothing
            j = Nothing
        Catch exp As Exception
            flgWheelStatus = False
            ErrorMessage(exp.Message)
        End Try
        errmsgloc = Nothing
        errmsgdef = Nothing
        strInput = Nothing
    End Sub
    Public Function PlatePassed(ByVal passed As Boolean) As String
        ' Added on 5-4-05 as per user requriement
        If flgcurWheelRHT = True Then
            sWheelStatus = "XC8RHT"
            sMcnOperation = ""
            sGrindStatus = ""
        End If
        If sMcnOperation = "" Then
            Exit Function
        End If
        ConvertToSingleMcnCode(sMcnOperation)
        If passed = True Then
            sMcnOperation &= "/P"
        Else
            If sMcnStatus.EndsWith("/P") Then
                sMcnOperation = sMcnOperation.Replace("/P", "")
            End If
        End If
        PlatePassed = sMcnOperation
    End Function
    Public Function ShiftScore(ByVal dTestDate As Date, ByVal cTestShift As Char) As String
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        da.SelectCommand.CommandText = "select " & _
                 "  sum(case when wheelstatus like 'xc%' and wheelstatus not like 'xc8%' then 1 else 0 end)  XC ," & _
                 "  sum(case when wheelstatus like 'xc8%' then 1 else 0 end) XC8RHT , " & _
                 "  sum(case when mcnoperation <> '' then 1 else 0 end) OffLoad , " & _
                 "  sum(case when mcnoperation = '' and grindstatus <> '' then 1 else 0 end) Rework, " & _
                 "  sum(case when wheelstatus like 's%' then 1 else 0 end) Stock , " & _
                 "  sum(1) TotalProcessed " & _
                 "  from mm_magnaglow_shiftwiserecords " & _
                 "  where testdate = @TestDate and shiftCode = @TestShift  and linenumber = @LineNumber  "
        da.SelectCommand.Parameters.Add("@TestDate", SqlDbType.SmallDateTime, 4).Value = dTestDate
        da.SelectCommand.Parameters.Add("@TestShift", SqlDbType.VarChar, 4).Value = cTestShift
        da.SelectCommand.Parameters.Add("@LineNumber", SqlDbType.VarChar, 4).Value = sLineNumber
        Dim ds As New DataSet()
        Try
            da.Fill(ds, "Score")
        Catch exp As Exception
            ds = Nothing
            sMessage = exp.Message
        Finally
            da.Dispose()
        End Try
        Dim row As DataRow
        ShiftScore = ""
        If IsNothing(ds) = False Then
            For Each row In ds.Tables("Score").Rows
                ShiftScore = "Stock : " + CStr(row("stock") & "").Trim + " Offloads : " + CStr(row("Offload") & "").Trim + " Rework: " + CStr(row("Rework") & "").Trim + " XCs : " + CStr(row("XC") & "").Trim + " RHT :" + CStr(row("XC8RHT") & "") + " Total : " + CStr(row("TotalProcessed") & "").Trim
            Next
            ds.Dispose()
        End If
        da = Nothing
        ds = Nothing
        row = Nothing
    End Function
    ReadOnly Property curWheelTypeChanged() As Boolean
        Get
            flgCurWheelTypeChange = flgWheelTypeChange
            Return flgCurWheelTypeChange
        End Get
    End Property
    Private Sub SaveMyWheel(ByVal dTestDate As Date, ByVal cTestShift As Char, ByVal sCopeInspector As String, ByVal sDragInspector As String, ByVal sWorkorder As String, ByVal sRemarks As String)
        ' imp: test for 1st prev whl 2nd prev whl and cur whl rht today evening
        ' 05-04-2005 svi
        ' check for cope inspector validity 
        ' added on 18-2-08 as per Mr.Hegde
        '        If (Val(MagHeatNumber) = 66980 And sWheelStatus.StartsWith("S")) Or (Val(MagHeatNumber) = 67042 And sWheelStatus.StartsWith("S")) Then
        If (Val(MagHeatNumber) = 66980 And sWheelStatus.StartsWith("S")) Or (Val(MagHeatNumber) = 67847 And sWheelStatus.StartsWith("S")) Then
            sMessage = "High Carbon Heat. Mark for HF. cannot stock" & sMessage
            Exit Sub
        End If

        Dim myCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        myCmd.CommandText = "Select count(*) from mis.dbo.menu_your_password where application = 'MMS' and group_code = 'CLRMAG' and employee_code = '" & sCopeInspector.Trim & "'"
        Dim flgCopeInpsector As Boolean
        Try
            myCmd.Connection.Open()
            flgCopeInpsector = myCmd.ExecuteScalar > 0
            blnError = Not flgCopeInpsector
        Catch exp As Exception
            flgCopeInpsector = False
        Finally
            If myCmd.Connection.State = ConnectionState.Open Then myCmd.Connection.Close()
            myCmd.Dispose()
            myCmd = Nothing
        End Try
        If flgCopeInpsector = False Then
            sMessage = "Invalid Cope Inspector Code Cannot save."
            Exit Sub
        End If

        Dim dlXcorStock As Double
        Dim sInsertPilotSql As String
        Dim lHeatNumber As Long
        Dim sqlstr As String
        Dim sqlstr1 As String
        Dim SecondPrevWhlPilotQry, SecondPrevWhlMasterQry, FirstPrevWhlPilotQry, FirstPrevWhlMasterQry, FirstPrevWhlQryMag, SecondPrevWhlQryMag, curWhlPilotQry As String
        Dim sqlPilotWhlTypeChange1, sqlMasterWhlTypeChange1, sqlPilotWhlTypeChange2, sqlMasterWhlTypeChange2 As String
        Dim sqlMasterCurWhl, sInsertMasterSql As String
        Dim sFirstWhl, sSecondWhl As String
        Dim strarr() As String = {}
        sInsertMasterSql = ""
        FirstPrevWhlPilotQry = ""
        FirstPrevWhlMasterQry = ""
        SecondPrevWhlMasterQry = ""
        SecondPrevWhlPilotQry = ""
        FirstPrevWhlQryMag = ""
        SecondPrevWhlQryMag = ""
        Dim cMagSts As Char
        If flgwheelNotFound = True Then
            If Left(sLineNumber, 1) = "2" Then
                sMessage = "New Wheel cannot be added in 2/2A lines "
                Exit Sub
            Else
                If Val(MagHeatNumber) = 0 Then
                Else
                    sMessage = "Only Series wheels can be added to master when wheel not found in line 1/1A"
                    Exit Sub
                End If
            End If
        End If
        If Val(MagHeatNumber) <> 0 And Val(MagWheelNumber) >= 100000 Then
            sMessage = "Series wheel should not have only zero (0) as heat number."
            Exit Sub
        End If
        If dTestDate = CDate("01/01/1900") Or dTestDate > Now().Date.Today Then
            sMessage = "Test Date not acceptable."
            Exit Sub
        End If

        If sWheelStatus.ToLower = "rework" Then
            If sGrindStatus <> "" And sMcnOperation = "" Then
                cMagSts = "G"
            ElseIf sMcnOperation <> "" Then
                cMagSts = "M"
            Else
                cMagSts = " "
                sErrorMessage = "Illogical Data : Rework wheel should have grind or mcn sts"
                sMessage = sErrorMessage
                blnError = True
                Exit Sub
            End If
        ElseIf sWheelStatus.ToLower = "xc8rht" Then
            cMagSts = "H"
        ElseIf sWheelStatus.ToLower = "stock" Then
            If sMcnOperation <> "" Or sGrindStatus <> "" Then
                sErrorMessage = "Illogical Data : Stock wheel should not have grind or mcn sts"
                sMessage = sErrorMessage
                blnError = True
                Exit Sub
            End If
            cMagSts = "STOC"
        Else
            cMagSts = "X"
        End If
        sWheelStatus = sWheelStatus.ToUpper
        Dim iNewReload As Long
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            cmd.Connection.Open()
            cmd.Parameters.Add("@WhlCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            cmd.CommandText = "select @WhlCount = count(*) from mm_magnaglow_Results where wheel_number = " & Val(MagWheelNumber) & " and heat_number = " & Val(MagHeatNumber)
            cmd.ExecuteScalar()
            iNewReload = IIf(IsDBNull(cmd.Parameters("@WhlCount").Value), 0, cmd.Parameters("@WhlCount").Value)
        Catch exp As Exception
            iNewReload = 0
            Throw New Exception(exp.Message)
        Finally
            cmd.Dispose()
            cmd = Nothing
        End Try
        iNewReload += 1
        Dim Ocmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Dim cnt As Integer
        Try
            Ocmd.Connection.Open()
            Ocmd.Parameters.Add("@WhlCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            Ocmd.CommandText = "Select @WhlCount = count(*) from mm_magnaglow_shiftwiseRecords where wheelnumber = " & Val(MagWheelNumber) & " and heatnumber = " & Val(MagHeatNumber) & " and xcorstock  = 0.0 "
            Ocmd.ExecuteScalar()
            cnt = IIf(IsDBNull(Ocmd.Parameters("@WhlCount").Value), 0, Ocmd.Parameters("@WhlCount").Value)
        Catch exp As Exception
            cnt = 0
            Throw New Exception(exp.Message)
        Finally
            Ocmd.Dispose()
            Ocmd = Nothing
        End Try
        If cnt > 0 Then
            'Dim strAllowReclaim As String
            'strAllowReclaim = " declare @recldate smalldatetime, @xcdate smalldatetime, @rejDate smalldatetime, @rjdate smalldatetime"
            'strAllowReclaim &= " declare @val as float"
            'strAllowReclaim &= " declare @wh as bigint"
            'strAllowReclaim &= " declare @ht as bigint"
            'strAllowReclaim &= " declare @retval as float"
            'strAllowReclaim &= " declare @slno as bigint"

            'strAllowReclaim &= " set @wh = " & Val(MagWheelNumber)
            'strAllowReclaim &= " set @ht = " & Val(MagHeatNumber)

            '' added on 30-10-2004 svi to allow relcaimed wheels on fi account
            'strAllowReclaim &= " select @recldate = ( select top 1 inspection_date  from mm_qci_inspection where wheel_number = @wh and heat_number = @ht order by sl_no desc  ),"
            'strAllowReclaim &= " @xcdate = ( select top 1 testdate from mm_magnaglow_shiftwiserecords where wheelnumber = @wh and heatnumber = @ht and wheelstatus like 'xc%' and wheelstatus not like 'xc8%' order by sl_no desc), "
            'strAllowReclaim &= " @rejDate = (select top 1 inspection_date from mm_final_inspection where wheel_number = @wh and heat_number = @ht and wheel_status like 'r%' order by sl_no desc ), "
            'strAllowReclaim &= " @slno = ( select top 1 sl_no  from mm_magnaglow_shiftwiserecords where (( wheelnumber = @wh and heatnumber = @ht) and ( (wheelstatus like 'xc%' and wheelstatus not like 'xc8%') or ( wheelstatus like 'st%'))) order by sl_no desc),  "
            'strAllowReclaim &= " @val = (select convert(float, getdate())) "

            'strAllowReclaim &= " if @rejdate is not null "
            'strAllowReclaim &= " begin "
            'strAllowReclaim &= " set @rjdate = @rejdate "
            'strAllowReclaim &= " end "
            'strAllowReclaim &= " else "
            'strAllowReclaim &= " begin "
            'strAllowReclaim &= " set @rjdate = @xcdate "
            'strAllowReclaim &= " end "

            'strAllowReclaim &= " if @recldate >= @rjdate "
            'strAllowReclaim &= " begin "
            'strAllowReclaim &= " set @retval = @val "
            'strAllowReclaim &= " End "
            'strAllowReclaim &= " else "
            'strAllowReclaim &= " begin "
            'strAllowReclaim &= " set  @retval = 0.0 "
            'strAllowReclaim &= " End "
            'strAllowReclaim &= " update mm_magnaglow_shiftwiserecords  set xcorstock = @retval where sl_no = @slno"
            Dim AllowReclaim As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                AllowReclaim.Connection.Open()
                'AllowReclaim.Parameters.Add("@WhlCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                'AllowReclaim.CommandText = strAllowReclaim
                AllowReclaim.Parameters.Add("@wh", SqlDbType.BigInt, 8).Value = Val(MagWheelNumber)
                AllowReclaim.Parameters.Add("@ht", SqlDbType.BigInt, 8).Value = Val(MagHeatNumber)
                AllowReclaim.CommandText = "mm_sp_AllowReclaim"
                AllowReclaim.CommandType = CommandType.StoredProcedure

                AllowReclaim.ExecuteNonQuery()
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                AllowReclaim.Dispose()
                AllowReclaim = Nothing
            End Try
        End If
        Dim AlreadyStkXC As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Dim StkXC As Integer
        Try
            AlreadyStkXC.Connection.Open()
            AlreadyStkXC.Parameters.Add("@WhlCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            AlreadyStkXC.CommandText = "Select @WhlCount = count(*) from mm_magnaglow_shiftwiseRecords where wheel ='" & sWheelNumber & "' and xcorstock  = 0.0 "
            AlreadyStkXC.ExecuteScalar()
            StkXC = IIf(IsDBNull(AlreadyStkXC.Parameters("@WhlCount").Value), 0, AlreadyStkXC.Parameters("@WhlCount").Value)
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            AlreadyStkXC.Dispose()
            AlreadyStkXC = Nothing
        End Try
        If StkXC > 0 Then
            sMessage = "Wheel already stock/XC"
            Exit Sub
        End If
        StkXC = Nothing
        Dim checkstr As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            checkstr.Connection.Open()
            checkstr.Parameters.Add("@str", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            checkstr.CommandText = "Select @str = convert(float, getdate()) "
            checkstr.ExecuteScalar()
            dlXcorStock = IIf(IsDBNull(checkstr.Parameters("@str").Value), 0, checkstr.Parameters("@str").Value)
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            checkstr.Dispose()
            checkstr = Nothing
        End Try
        Select Case Left(WheelStatusText.ToUpper, 2)
            Case "XC", "ST"
                If Left(sWheelStatus.ToUpper, 3) <> "XC8" Then
                    dlXcorStock = 0.0
                End If
        End Select
        If iBHNStatus0 = Nothing Then
            iBHNStatus0 = 0
        End If
        'check bhn updt in pilot file
        If sLineNumber.Trim = "1" Or sLineNumber.Trim = "1B" Then
            sInsertPilotSql = "INSERT INTO mm_magnaglow_ShiftwiseRecords(wheelNumber, HeatNumber, LineNumber, " & _
                " TestDate, ShiftCode, GrindStatus, McnOperation, WheelStatus, Remarks, UtStatus, " & _
                " Wheel,XCorStock, copeInspector, dragInspector, NewReload, savedatetime, Description , bhn) " & _
                " VALUES (" & Val(MagWheelNumber) & "," & Val(MagHeatNumber) & ",'" & sLineNumber & "', " & _
                " convert(smalldatetime,'" & dTestDate & "',103), '" & CStr(cTestShift) & "' , " & _
                " '" & sGrindStatus & "' , '" & sMcnOperation & "' , '" & sWheelStatus & "' , '" & sRemarks & "', " & _
                " '" & CStr(cUTStatus) & "' , '" & sWheelNumber & "' ,'" & dlXcorStock & "','" & sCopeInspector & "', " & _
                " '" & sDragInspector & "' , " & iNewReload & " , convert(datetime,getdate()), '" & sWheelType & "', " & iBHNStatus0 & ")"
        Else
            sInsertPilotSql = "INSERT INTO mm_magnaglow_ShiftwiseRecords(wheelNumber, HeatNumber, LineNumber, " & _
                " TestDate, ShiftCode, GrindStatus, McnOperation, WheelStatus, Remarks, UtStatus, " & _
                " Wheel,XCorStock, copeInspector, dragInspector, newreload,savedatetime, Description, bhn ) " & _
                " VALUES (" & Val(MagWheelNumber) & ", " & Val(MagHeatNumber) & ", '" & sLineNumber & "', " & _
                " convert(smalldatetime,'" & dTestDate & "',103), '" & CStr(cTestShift) & "', " & _
                " '" & sGrindStatus & "', '" & sMcnOperation & "', '" & sWheelStatus & "' ,'" & sRemarks & "', " & _
                " '" & CStr(cUTStatus) & "' , '" & sWheelNumber & " ', '" & dlXcorStock & "' ,'" & sCopeInspector & "', " & _
                " '" & sDragInspector & "', " & iNewReload & " , convert(datetime,getdate()) , '" & sWheelType & "', " & _
                " " & iBHNStatus0 & ")"
        End If
        If flgNewSerieswhl = True Then
            strarr = Split(sWheelNumber, "/")
            sInsertMasterSql = "INSERT INTO mm_wheel (wheel_number, heat_number, description ) " & _
                " values (" & Val(strarr(0)) & ", " & Val(strarr(1)) & ", '" & sWheelType & "')"
        End If
        If Left(sLineNumber, 1) = "1" Then
            If iBHNStatus1 = Nothing Then
                iBHNStatus1 = 0
            End If
            If iBHNStatus2 = Nothing Then
                iBHNStatus2 = 0
            End If

            sFirstWhl = getPrevWheel()
            strarr = Split(sFirstWhl, "/")
            sSecondWhl = getSecondPrevWheel()
            If iBHNStatus0 > 0 AndAlso sWheelNumber <> "" Then
                curWhlPilotQry = "update mm_magnaglow_shiftwiseRecords set "
                curWhlPilotQry &= " bhn = " & iBHNStatus0
                If (flgcurWheelRHT) Then
                    curWhlPilotQry &= ", WheelStatus = 'XC8RHT' "
                End If
                curWhlPilotQry &= " where wheel = '" & sWheelNumber & "'"
            End If

            If sLineNumber.Trim = "1" Or sLineNumber.Trim = "1B" Then
                If lPrevWhlPilotSlNo > 0 Then
                    FirstPrevWhlPilotQry = "update mm_magnaglow_shiftwiseRecords set "
                    FirstPrevWhlPilotQry &= " bhn = " & iBHNStatus1
                    If (flgFirstWheelRHT) Then
                        FirstPrevWhlPilotQry &= ", WheelStatus = 'XC8RHT' "
                    End If
                    FirstPrevWhlPilotQry &= " where sl_no = " & lPrevWhlPilotSlNo
                End If

                If lPrevWhlSlno > 0 Then
                    If (flgFirstWheelRHT) Then
                        FirstPrevWhlQryMag = "update mm_magnaglow_results set " & _
                            " Wheel_Status = 'XC8RHT' where sl_no = " & lPrevWhlSlno
                    End If

                End If
                If sFirstWhl <> "" Then
                    FirstPrevWhlMasterQry = "update mm_wheel set "
                    FirstPrevWhlMasterQry &= " bhn_rate = " & iBHNStatus1
                    If (flgFirstWheelRHT) Then
                        FirstPrevWhlMasterQry &= ", Status = 'XC8RHT' , magnaglow_status = 'R'"
                    End If
                    FirstPrevWhlMasterQry &= " where wheel_number = " & Val(strarr(0)) & " and heat_number = " & Val(strarr(1))
                End If
                strarr = Split(sSecondWhl, "/")
                If l2ndPrevWhlPilotSlNo > 0 Then
                    SecondPrevWhlPilotQry = "update mm_magnaglow_shiftwiseRecords set "
                    SecondPrevWhlPilotQry &= " bhn = " & iBHNStatus2
                    If (flgSecondWheelRHT) Then
                        ' SecondPrevWhlPilotQry &= ", WheelStatus = 'XC8RHT' ,  magnaglow_status = 'R'"
                        SecondPrevWhlPilotQry &= ", WheelStatus = 'XC8RHT' "
                    End If
                    SecondPrevWhlPilotQry &= " where  sl_no = " & l2ndPrevWhlPilotSlNo
                End If
                If l2ndPrevWhlSlno > 0 Then
                    If (flgSecondWheelRHT) Then
                        SecondPrevWhlQryMag = "update mm_magnaglow_results set "
                        'SecondPrevWhlQryMag &= " Wheel_Status = 'XC8RHT',  magnaglow_status = 'R'"
                        SecondPrevWhlQryMag &= " Wheel_Status = 'XC8RHT' "
                        SecondPrevWhlQryMag &= " where sl_no = " & l2ndPrevWhlSlno
                    End If

                    SecondPrevWhlMasterQry = "update mm_wheel set "
                    SecondPrevWhlMasterQry &= " bhn_rate = " & iBHNStatus2
                    If (flgSecondWheelRHT) Then
                        SecondPrevWhlMasterQry &= ", Status = 'XC8RHT', magnaglow_status = 'R' "
                    End If
                    SecondPrevWhlMasterQry &= " where wheel_number = " & Val(strarr(0)) & " and heat_number = " & Val(strarr(1))
                End If

            End If
            'to be saved when move to live WITHOUT FAIL. this view is taken in the light of the following facts:
            'This will rectify wrong wheel type updation in Mould Room.  
            ' - Mag Insp sees wheel in cold condition, one by one hence error chances are less and on err in wheel type
            ' - only that wheel is affected whereas in case of mould room operator error more wheels are affected.
            ' - with less chance to rectify the error.
        End If

        sqlMasterCurWhl = "Update mm_wheel set location = 'CLMT', status = '"
        sqlMasterCurWhl &= sWheelStatus & "'"
        If flgCurWheelTypeChange = True Then
            If sWheelType <> "" Then
                sqlMasterCurWhl &= ", description = '" & sWheelType & "'"
            End If
        End If
        If iBHNStatus0 > 0 Then
            sqlMasterCurWhl &= ", bhn_rate = " & iBHNStatus0
        End If
        sqlMasterCurWhl &= ", workorder_cleaning_room = '" & sWorkorder & "'"
        sqlMasterCurWhl &= ", Ut_Status = '" & cUTStatus & "'"
        sqlMasterCurWhl &= ", Magnaglow_Status = '" & cMagSts & "'"
        sqlMasterCurWhl &= " where wheel_number = "
        sqlMasterCurWhl &= Val(MagWheelNumber)
        sqlMasterCurWhl &= " and heat_number = "
        sqlMasterCurWhl &= Val(MagHeatNumber)
        ' 
        Dim sMagResultStr As String
        ''sMagResultStr = "INSERT INTO mm_magnaglow_results ( wheel_number, heat_number, grind_status, mcn_operation, wheel_status, time_entered, ut_result, remarks, inspector_cope, inspector_drag,"
        ''sMagResultStr &= " line_number, shift_code, test_date, workorder_number, new_reload, wheel_transfer_status ) values ("
        ''sMagResultStr &= Val(MagWheelNumber) & ", " & Val(MagHeatNumber) & ", '" & sGrindStatus & "','" & sMcnOperation & "', '" & sWheelStatus & "','" & CStr(Format(Now, "HH:mm:ss")) & "','" & CStr(cUTStatus) & "','" & sRemarks & "','" & sCopeInspector & "','" & sDragInspector & "','"
        ''sMagResultStr &= sLineNumber & "','" & CStr(cTestShift) & "'," & " convert(smalldatetime,'" & dTestDate & "',103),'" & sWorkorder & "'," & iNewReload
        ''sMagResultStr &= ", '" & sWheelType & "')"
        ''' below line takes time of sqlcluster (database server) above line takes time of appln server 
        sMagResultStr = "INSERT INTO mm_magnaglow_results ( wheel_number, heat_number, grind_status, mcn_operation , " & _
            " wheel_status, time_entered, ut_result, remarks, inspector_cope, inspector_drag," & _
            " line_number, shift_code, test_date, workorder_number, new_reload, wheel_transfer_status ) values ( " & _
            " " & Val(MagWheelNumber) & ", " & Val(MagHeatNumber) & ", '" & sGrindStatus & "','" & sMcnOperation & "', " & _
            " '" & sWheelStatus & "',  convert(varchar, getdate(), 108) , '" & CStr(cUTStatus) & "' , " & _
            " '" & sRemarks & "', '" & sCopeInspector & "', '" & sDragInspector & "' ,  " & _
            " '" & sLineNumber & "', '" & CStr(cTestShift) & "', convert(smalldatetime,'" & dTestDate & "',103), " & _
            " '" & sWorkorder & "', " & iNewReload & " , '" & sWheelType & "' )"

        Dim sqlCon As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            sqlCon.Connection.Open()
            sqlCon.Transaction = sqlCon.Connection.BeginTransaction()
            If flgNewSerieswhl = True Then
                sqlCon.CommandText = sInsertMasterSql
                sqlCon.ExecuteNonQuery()
            End If
            If sLineNumber = "1" Or sLineNumber = "1B" Then
                If iBHNStatus2 > 0 Then
                    If l2ndPrevWhlPilotSlNo > 0 Then
                        sqlCon.CommandText = SecondPrevWhlPilotQry
                        sqlCon.ExecuteNonQuery()
                    End If
                    If (flgSecondWheelRHT) Then
                        sqlCon.CommandText = SecondPrevWhlQryMag
                        sqlCon.ExecuteNonQuery()
                    End If
                    sqlCon.CommandText = SecondPrevWhlMasterQry
                    sqlCon.ExecuteNonQuery()
                End If
                If iBHNStatus1 > 0 Then
                    If lPrevWhlPilotSlNo > 0 Then
                        sqlCon.CommandText = FirstPrevWhlPilotQry
                        sqlCon.ExecuteNonQuery()
                    End If
                    If flgFirstWheelRHT Then
                        sqlCon.CommandText = FirstPrevWhlQryMag
                        sqlCon.ExecuteNonQuery()
                    End If
                    sqlCon.CommandText = FirstPrevWhlMasterQry
                    sqlCon.ExecuteNonQuery()
                End If
            End If
            If Left(sLineNumber, 1) = "1" Then
                If iBHNStatus0 > 0 Then
                    '  If lPrevWhlPilotSlNo > 0 Then ' rem on 5/6/2006 svi 
                    If iBHNStatus0 > 0 Then
                        sqlCon.CommandText = curWhlPilotQry
                        sqlCon.ExecuteNonQuery()
                    End If
                    'End If
                End If
            End If
            sqlCon.CommandText = sqlMasterCurWhl
            sqlCon.ExecuteNonQuery()
            sqlCon.CommandText = sInsertPilotSql
            sqlCon.ExecuteNonQuery()
            sqlCon.CommandText = sMagResultStr
            sqlCon.ExecuteNonQuery()
            sqlCon.Transaction.Commit()
            sMessage = ""
            sMagResultStr = Nothing
        Catch exp As Exception
            sMessage = exp.Message & " " & "Incomplete Data to save" & " or " & "Wheel Already Stocked/XC."
            sqlCon.Transaction.Rollback()
        Catch exp As Exception
            sInsertPilotSql = exp.StackTrace
            sMessage = "Line : " & Mid(sInsertPilotSql, InStr(sInsertPilotSql, "line") + 5) & " Message : " + exp.Message
            sqlCon.Transaction.Rollback()
        Finally
            sqlCon.Connection.Close()
            sqlCon.Connection.Dispose()
            sqlCon = Nothing
        End Try
        dlXcorStock = Nothing
        sInsertPilotSql = Nothing
        lHeatNumber = Nothing
        sqlstr = Nothing
        sqlstr1 = Nothing
        SecondPrevWhlPilotQry = Nothing
        SecondPrevWhlMasterQry = Nothing
        FirstPrevWhlPilotQry = Nothing
        FirstPrevWhlMasterQry = Nothing
        FirstPrevWhlQryMag = Nothing
        SecondPrevWhlQryMag = Nothing
        curWhlPilotQry = Nothing
        sqlPilotWhlTypeChange1 = Nothing
        sqlMasterWhlTypeChange1 = Nothing
        sqlPilotWhlTypeChange2 = Nothing
        sqlMasterWhlTypeChange2 = Nothing
        sqlMasterCurWhl = Nothing
        sInsertMasterSql = Nothing
        sFirstWhl = Nothing
        sSecondWhl = Nothing
        strarr = Nothing
        cMagSts = Nothing
        cnt = Nothing
        iNewReload = Nothing
    End Sub
    Public Function save(ByVal dTestDate As Date, ByVal cTestShift As Char, ByVal sCopeInspector As String, ByVal sDragInspector As String, ByVal sWorkorder As String, ByVal sRemarks As String) As String
        Select Case BtnSaveText.ToLower
            Case "stock"
                ' stocking logic
                SaveMyWheel(dTestDate, cTestShift, sCopeInspector, sDragInspector, sWorkorder, sRemarks)
                If sMessage = "" Then
                    save = "Saved " & sWheelNumber & " As " & "Stocked"
                Else
                    save = sMessage
                End If
                ResetStatusses()
                DispLastStatus()
            Case Else
                ' saving as rework or xc wheel logic
                SaveMyWheel(dTestDate, cTestShift, sCopeInspector, sDragInspector, sWorkorder, sRemarks)
                If sMessage = "" Then
                    save = "Saved " & sWheelNumber & " As " & sWheelStatus
                Else
                    save = sMessage
                End If
                ResetStatusses()
                DispLastStatus()
        End Select
    End Function
    Private Function UpdateMasterForWheelType(ByVal whlno As String, ByVal sType As String, Optional ByVal SaveToApMMsMMWheel As Boolean = False) As String
        Dim sUpdateMasterWheelTyupe, sUpdateMasterWheelType As String
        Dim whlarr() As String = Split(whlno, "/")
        If SaveToApMMsMMWheel = True Then
            sUpdateMasterWheelType = "Update mm_wheel set Description = '" & sWheelType & "' where wheel_number = "
            sUpdateMasterWheelType &= Val(whlarr(0))
            sUpdateMasterWheelType &= " and heat_number = "
            If Val(whlarr(1)) < 1000 Then
                sUpdateMasterWheelType &= lRegular_heat_for_mgc_wheels
            Else
                sUpdateMasterWheelType &= Val(whlarr(1))
            End If
        Else
            sUpdateMasterWheelType = "Update mm_magnaglow_shiftwiseRecords set Description = '" & sWheelType & "' where wheelnumber = "
            sUpdateMasterWheelType &= Val(whlarr(0))
            sUpdateMasterWheelType &= " and heatnumber = "
            If Val(whlarr(1)) < 1000 Then
                sUpdateMasterWheelType &= lRegular_heat_for_mgc_wheels
            Else
                sUpdateMasterWheelType &= Val(whlarr(1))
            End If
        End If
        UpdateMasterForWheelType = sUpdateMasterWheelType
    End Function
End Class
