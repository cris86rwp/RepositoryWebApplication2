Namespace AxleProcessing
    <Serializable()> Public Class AFSForm
#Region " Fields"
        Private sEmpCodeOperator, sEmpCodeShiftIc, sLoadShift As String
        Private dLoadDate As Date
        Private blnSaveDataGridError As Boolean
#End Region
#Region " Property"
        ReadOnly Property SaveDataGridError() As Boolean
            Get
                Return blnSaveDataGridError
            End Get
        End Property
        ReadOnly Property LoadDate() As Date
            Get
                Return dLoadDate
            End Get
        End Property
        ReadOnly Property LoadShift() As String
            Get
                Return sLoadShift
            End Get
        End Property
        Property EmpCodeOperator() As String
            Get
                Return sEmpCodeOperator
            End Get
            Set(ByVal Value As String)
                If IsValidEmpCode(Value) Then
                    sEmpCodeOperator = Value
                Else
                    sEmpCodeOperator = ""
                    Throw New Exception("Invalid EmpCode : " & Value)
                End If
            End Set
        End Property
        Property EmpCodeShiftIc() As String
            Get
                Return sEmpCodeShiftIc
            End Get
            Set(ByVal Value As String)
                If IsValidEmpCode(Value) Then
                    sEmpCodeShiftIc = Value
                Else
                    sEmpCodeShiftIc = ""
                End If
            End Set
        End Property
#End Region
#Region " Methods"
        Public Sub New()
            GetShift()
            GetDate()
        End Sub
        Private Sub GetShift()
            Select Case Now.Hour
                Case 6 To 13
                    sLoadShift = "A"
                Case 14 To 21
                    sLoadShift = "B"
                Case Else
                    sLoadShift = "C"
            End Select
        End Sub
        Private Sub GetDate()
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.CommandText = "Select top 1 DateLoaded from mm_axle_loaded_to_MachineShop order  by sl_no desc "
            Dim dt As Date
            Try
                cmd.Connection.Open()
                dt = cmd.ExecuteScalar
                If IsNothing(dt) Or IsDBNull(dt) Then
                    dt = Now.Date
                End If
                If Now.Date > dt And sLoadShift <> "C" Then
                    dt = Now.Date
                End If

                While isholiday(dt, "AMA")
                    dt = dt.AddDays(-1)
                    If dt < Now.AddYears(-1) Then
                        Exit While
                    End If
                End While
                dLoadDate = dt
            Catch exp As Exception
                Throw New Exception("Date Error ")
            Finally
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                cmd.Dispose()
                cmd = Nothing
            End Try
            dt = Nothing
        End Sub
        Private Function isholiday(ByVal dt As Date, ByVal shop As String) As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.CommandText = "Select count(*) from mm_calendar_dump where shop = '" & shop & "' and date = @Date"
            cmd.Parameters.Add("@Date", SqlDbType.SmallDateTime, 4)
            cmd.Parameters("@Date").Value = dt
            Try
                cmd.Connection.Open()
                isholiday = cmd.ExecuteScalar > 0
            Catch exp As Exception
                isholiday = False
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Private Function IsValidEmpCode(ByVal EmpCd As String) As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.CommandText = "Select count(*) from hr_Employee_master where employee_code = '" & EmpCd & "'"
            Try
                cmd.Connection.Open()
                If cmd.ExecuteScalar > 0 Then
                    IsValidEmpCode = True
                Else
                    IsValidEmpCode = False
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Function SaveDataTable() As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = "select axleNumber AxleNo  , " & _
                " convert(varchar(10),DateLoaded,103) Date , shiftLoaded Shift " & _
                " from mm_axle_loaded_to_MachineShop where Dateloaded = @DateLoaded and ShiftLoaded = @ShiftLoaded order by  sl_no desc  "
            da.SelectCommand.Parameters.Add("@DateLoaded", SqlDbType.SmallDateTime, 4).Value = dLoadDate
            da.SelectCommand.Parameters.Add("@ShiftLoaded", SqlDbType.VarChar, 1).Value = sLoadShift
            Try
                da.Fill(ds)
                SaveDataTable = ds.Tables(0)
            Catch exp As Exception
                SaveDataTable = Nothing
                blnSaveDataGridError = True
                Throw New Exception("Save Grid Error : " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
#End Region
    End Class
    <Serializable()> Public Class AxleEditForm
#Region " Fields"
        Private sEmpCodeOperator, sEditShift As String
        Private dEditDate As Date
        Private blnSaveDataGridError As Boolean
#End Region
#Region " Property"
        ReadOnly Property SaveDataGridError() As Boolean
            Get
                Return blnSaveDataGridError
            End Get
        End Property
        ReadOnly Property EditDate() As Date
            Get
                Return dEditDate
            End Get
        End Property
        ReadOnly Property EditShift() As String
            Get
                Return sEditShift
            End Get
        End Property
        Property EmpCodeOperator() As String
            Get
                Return sEmpCodeOperator
            End Get
            Set(ByVal Value As String)
                If IsValidEmpCode(Value) Then
                    sEmpCodeOperator = Value
                Else
                    sEmpCodeOperator = ""
                    Throw New Exception("Invalid EmpCode : " & Value)
                End If
            End Set
        End Property
#End Region
#Region " Methods"
        Public Sub New()
            GetShift()
            GetDate()
        End Sub
        Private Sub GetShift()
            Select Case Now.Hour
                Case 6 To 13
                    sEditShift = "A"
                Case 14 To 21
                    sEditShift = "B"
                Case Else
                    sEditShift = "C"
            End Select
        End Sub
        Private Sub GetDate()
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.CommandText = "Select top 1 Date_Forged from mm_axle_master order  by date_forged desc "
            Dim dt As Date
            Try
                cmd.Connection.Open()
                dt = cmd.ExecuteScalar
                If IsNothing(dt) Or IsDBNull(dt) Then
                    dt = Now.Date
                End If
                If Now.Date > dt And sEditShift <> "C" Then
                    dt = Now.Date
                End If

                While isholiday(dt, "AMA")
                    dt = dt.AddDays(-1)
                    If dt < Now.AddYears(-1) Then
                        Exit While
                    End If
                End While
                dEditDate = dt
            Catch exp As Exception
                Throw New Exception("Date Error ")
            Finally
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                cmd.Dispose()
                cmd = Nothing
            End Try
            dt = Nothing
        End Sub
        Private Function isholiday(ByVal dt As Date, ByVal shop As String) As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.CommandText = "Select count(*) from mm_calendar_dump where shop = '" & shop & "' and date = @Date"
            cmd.Parameters.Add("@Date", SqlDbType.SmallDateTime, 4).Value = dt
            Try
                cmd.Connection.Open()
                isholiday = cmd.ExecuteScalar > 0
            Catch exp As Exception
                isholiday = False
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Private Function IsValidEmpCode(ByVal EmpCd As String) As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.CommandText = "Select count(*) from hr_Employee_master where employee_code = '" & EmpCd & "'"
            Try
                cmd.Connection.Open()
                If cmd.ExecuteScalar > 0 Then
                    IsValidEmpCode = True
                Else
                    IsValidEmpCode = False
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Function EditedRecordsTable() As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "select b.axle_number AxleNo , b.drawing_number DrawingNumber , " & _
                " b.cast_number CastNo , b.workorder_number_forge ForgeWO , b.rejection_code RejCode , " & _
                " b.axle_sts Status, b.billet_number  BilletNo from mm_axle_master_audit a inner join mm_axle_master b " & _
                " on a.axle_number = b.axle_number where convert(smalldatetime,convert(varchar(11),a.ChangeDateTime )) = @EditDate " & _
                " and a.ChangedInShift = @EditShift order by a.RecId desc "
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@EditDate", SqlDbType.SmallDateTime, 4).Value = dEditDate
                da.SelectCommand.Parameters.Add("@EditShift", SqlDbType.VarChar, 1).Value = sEditShift
                da.Fill(ds)
                EditedRecordsTable = ds.Tables(0)
            Catch exp As Exception
                EditedRecordsTable = Nothing
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
#End Region
    End Class
    <Serializable()> Public Class AxleEdit
        Public Shared Function ForgeWOTable(ByVal ForgedDate As Date) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = " select a.number , rtrim(a.number)+ '--'+rtrim(b.description)+'--'+(rtrim(b.drawing_number)) Descr " & _
                    " from mm_vw_WorkorderList a , mm_product_master b where a.status like 'O%' and a.shop_code like 'F%'" & _
                    " and b.product_code = a.product_code and year(a.start_date)= '" & CDate(ForgedDate).Year & "' " & _
                    " and month(a.start_date)= '" & CDate(ForgedDate).Month & "' and isnull(b.type,'') = ''"
            Dim ds As New DataSet()
            Try
                da.Fill(ds)
                ForgeWOTable = ds.Tables(0)
            Catch exp As Exception
                ForgeWOTable = Nothing
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
#Region " Fields"
        Private sAxleNumber As String
        Private oAxleEditForm As AxleEditForm
        Private blnAxleError, blnUtDoneError, blnAlreadyLoaded As Boolean
        Private dUTDate, drejection_date, dForgeDate, dChangeDate, dBillet_date As Date
        Private sMessage, sChangedDrg, sChangedWO As String
        Private sAxleCastNumber, sBilletCastNumber, sAxleSts, sWorkOrderNumber, sDrawingNumber, srejection_code, srejection_Location, sAxleLocation, sProductCode, sDescription As String
        Private tblRejCodes, tblWorkOrders As DataTable
        Private sAxleNewCastNumber, sNewWorkOrderNumber, sAxleNewStatus, sNewRejectionCode, sAxleNewDrawingNumber As String
        Private sCastStatus, sForgedShift, sChangeShift, sShift_code As String
        Private sBilletNumber As String, blnAfterUT As Boolean, dsUTDetails As DataSet
#End Region
#Region " Property"
        WriteOnly Property AfterUT() As Boolean
            Set(ByVal Value As Boolean)
                blnAfterUT = Value
            End Set
        End Property
        Property ChangedWO() As String
            Get
                Return sChangedWO
            End Get
            Set(ByVal Value As String)
                Try
                    GetDesc(Value)
                    sChangedWO = Value
                Catch exp As Exception
                    Throw New Exception("InValid Workorder! ;" & exp.Message)
                End Try
            End Set
        End Property
        Property ChangedDrg() As String
            Get
                Return sChangedDrg
            End Get
            Set(ByVal Value As String)
                sChangedDrg = Value
            End Set
        End Property
        ReadOnly Property Billet_date() As Date
            Get
                Return dBillet_date
            End Get
        End Property
        ReadOnly Property Billet_shift() As String
            Get
                Return sShift_code
            End Get
        End Property
        WriteOnly Property ChangeShift() As String
            Set(ByVal Value As String)
                sChangeShift = Value
            End Set
        End Property
        WriteOnly Property ChangeDate() As Date
            Set(ByVal Value As Date)
                If sShift_code.Trim.Length > 0 Then
                    If Value >= dBillet_date Then
                        dChangeDate = Value
                    Else
                        Throw New Exception("Change Date < Billet Date ")
                    End If
                End If
            End Set
        End Property
        ReadOnly Property AxleStatus() As String
            Get
                Return sAxleSts
            End Get
        End Property
        WriteOnly Property AxleNewStatus() As String
            Set(ByVal Value As String)
                sAxleNewStatus = Value.ToUpper
            End Set
        End Property
        ReadOnly Property CastStatus() As String
            Get
                Return sCastStatus
            End Get
        End Property
        ReadOnly Property DrawingNumber() As String
            Get
                Return sDrawingNumber
            End Get
        End Property
        Property EmployeeCode() As String
            Get
                Return oAxleEditForm.EmpCodeOperator
            End Get
            Set(ByVal Value As String)
                oAxleEditForm.EmpCodeOperator = Value
            End Set
        End Property
        ReadOnly Property AxleNumber() As String
            Get
                Return sAxleNumber
            End Get
        End Property
        ReadOnly Property ForgeDate() As Date
            Get
                Return dForgeDate
            End Get
        End Property
        ReadOnly Property ForgedShift() As String
            Get
                Return sForgedShift
            End Get
        End Property
        ReadOnly Property RejectionCode() As String
            Get
                Return srejection_code
            End Get
        End Property
        WriteOnly Property NewRejectionCode() As String
            Set(ByVal Value As String)
                sNewRejectionCode = Value
            End Set
        End Property
        ReadOnly Property RejectionCodeTable() As DataTable
            Get
                Return tblRejCodes
            End Get
        End Property
        ReadOnly Property WorkOrderTable() As DataTable
            Get
                Return tblWorkOrders
            End Get
        End Property
        ReadOnly Property UTTables() As DataSet
            Get
                Return dsUTDetails
            End Get
        End Property
        ReadOnly Property AxleCastNumber() As String
            Get
                Return sAxleCastNumber
            End Get
        End Property
        WriteOnly Property AxleNewCastNumber() As String
            Set(ByVal Value As String)
                sAxleNewCastNumber = Value.ToUpper
            End Set
        End Property
        ReadOnly Property BilletCastNumber() As String
            Get
                Return sBilletCastNumber
            End Get
        End Property
        ReadOnly Property AxleLocation() As String
            Get
                Return sAxleLocation
            End Get
        End Property
        ReadOnly Property RejectionLocation() As String
            Get
                Return srejection_Location
            End Get
        End Property
        ReadOnly Property RejectionDate() As Date
            Get
                Return drejection_date
            End Get
        End Property
        ReadOnly Property WorkOrder() As String
            Get
                Return sWorkOrderNumber
            End Get
        End Property
        WriteOnly Property NewWorkOrder() As String
            Set(ByVal Value As String)
                sNewWorkOrderNumber = Value
            End Set
        End Property
        WriteOnly Property NewDrawingNumber() As String
            Set(ByVal Value As String)
                sAxleNewDrawingNumber = Value
            End Set
        End Property
        ReadOnly Property ProductCode() As String
            Get
                Return sProductCode
            End Get
        End Property
        ReadOnly Property Description() As String
            Get
                Return sDescription
            End Get
        End Property
        ReadOnly Property Message() As String
            Get
                Return sMessage
            End Get
        End Property
#End Region
#Region " Methods"
        Public Sub New(ByVal AxleNumber As String, Optional ByVal Stage As Boolean = False)
            If Stage Then blnAfterUT = True
            sAxleNumber = AxleNumber.ToUpper
            oAxleEditForm = New AxleEditForm()
            tblRejCodes = New DataTable()
            tblWorkOrders = New DataTable()
            Try
                If blnAfterUT Then
                    GetAfterUTData()
                Else
                    GetData()
                End If
            Catch exp As Exception
                Dim saxno As String
                saxno = AxleNumber
                If exp.Message.IndexOf(saxno.ToUpper) < 0 Then
                    Throw New Exception(exp.Message & ":" & AxleNumber)
                Else
                    Throw New Exception(exp.Message)
                End If
                saxno = Nothing
            End Try
        End Sub
        Private Sub GetAfterUTData()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "select top 1  @UtDate =  isnull(test_date ,'1900-1-1')  from mm_axle_test_results_ut  " & _
                    " where axle_number = @axleNumber and operator_west <> '' and  operator_east <> '' order by sl_no desc ; " & _
                    " select top 1  @MPTDate =  isnull(mpt_test_date ,'1900-1-1')  from mm_axle_mpt_test_results" & _
                    " where axle_number = @axleNumber order by sl_no desc ; " & _
                    " select top 1  @MountDate =  isnull(mount_date ,'1900-1-1')  from mm_mounting_press" & _
                    " where axle_number = @axleNumber order by mount_date desc , shift_code  desc"
                da.SelectCommand.Parameters.Add("@axleNumber", SqlDbType.VarChar, 50).Value = sAxleNumber
                da.SelectCommand.Parameters.Add("@UtDate", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output
                da.SelectCommand.Parameters.Add("@MPTDate", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output
                da.SelectCommand.Parameters.Add("@MountDate", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output
                da.SelectCommand.Connection.Open()
                da.SelectCommand.ExecuteScalar()
                If IsDBNull(da.SelectCommand.Parameters("@MountDate").Value) = False Then
                    sMessage = "Axle already mounted at Press on " & da.SelectCommand.Parameters("@MountDate").Value
                    Throw New Exception(sMessage)
                ElseIf IsDBNull(da.SelectCommand.Parameters("@MountDate").Value) = False Then
                    sMessage = "Axle already MPT tested on " & da.SelectCommand.Parameters("@MPTDate").Value
                    Throw New Exception(sMessage)
                ElseIf IsDBNull(da.SelectCommand.Parameters("@UtDate").Value) Then
                    sMessage = "Axle Not Tested at UT. Cannot be processed ! "
                    Throw New Exception(sMessage)
                End If
                da.SelectCommand.CommandText = ""
                da.SelectCommand.Parameters.Add("@ForgedDt", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output
                da.SelectCommand.CommandText = " select convert(varchar(10),date_forged,103) ForgedDt , " & _
                    " shft_forge Sh , cast_number CastNo , drawing_number DrawingNumber , axle_sts Sts" & _
                    " from mm_axle_master where axle_number = @axleNumber ;" & _
                    " select convert(varchar(10),test_date,103) TestDate , " & _
                    " shift_code Sh , ut_status Sts ,ut_remarks UTRemarks , drawing_number DrawingNumber " & _
                    " from mm_axle_test_results_ut where axle_number = @axleNumber order by sl_no desc ; "
                da.Fill(ds)
                dForgeDate = IIf(IsDBNull(ds.Tables(0).Rows(0)("ForgedDt")), CDate("1/1/1900"), ds.Tables(0).Rows(0)("ForgedDt"))
                dsUTDetails = ds.Copy
            Catch exp As Exception
                blnAxleError = True
                If sMessage = "" Then
                    sMessage = "Data Error: " & exp.Message & ":" & sAxleNumber
                End If
                Throw New Exception(sMessage)
            Finally
                If da.SelectCommand.Connection.State = ConnectionState.Open Then da.SelectCommand.Connection.Close()
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Sub
        Private Sub GetDesc(ByVal WO As String)
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@ChangeWO", SqlDbType.VarChar, 50).Value = WO.Trim
            cmd.Parameters.Add("@ChangeDrg", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            Try
                cmd.Connection.Open()
                cmd.CommandText = " select @ChangeDrg = drawing_number from mm_product_master a inner join mm_workorder b " & _
                    " on a.product_code = b.product_code and isnull(a.type,'') = '' where b.number = @ChangeWO "
                cmd.ExecuteScalar()
                If Trim(IIf(IsDBNull(cmd.Parameters("@ChangeDrg").Value), "", cmd.Parameters("@ChangeDrg").Value)).Length > 0 Then
                    sChangedDrg = Trim(cmd.Parameters("@ChangeDrg").Value)
                Else
                    sMessage = "Updation of Master failed"
                End If
            Catch exp As Exception
                sMessage = exp.Message
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Sub
        Private Sub GetData()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "select @DateLoaded = DateLoaded, @ShiftLoaded = ShiftLoaded " & _
                    " from mm_axle_loaded_to_MachineShop where axlenumber = '" & sAxleNumber & "' "
                da.SelectCommand.Parameters.Add("@DateLoaded", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output
                da.SelectCommand.Parameters.Add("@ShiftLoaded", SqlDbType.VarChar, 1).Direction = ParameterDirection.Output
                da.SelectCommand.Connection.Open()
                da.SelectCommand.ExecuteScalar()
                If IsDBNull(da.SelectCommand.Parameters("@DateLoaded").Value) = False Then
                    blnAlreadyLoaded = True
                Else
                    blnAlreadyLoaded = False
                End If
                If blnAlreadyLoaded Then
                    sMessage = "Axle already loaded to AMS:" & sAxleNumber
                    Throw New Exception(sMessage)
                End If
                da.SelectCommand.CommandText = "select wap.dbo.mm_fn_si_AxleUTPassDate('" & sAxleNumber & "')"
                dUTDate = da.SelectCommand.ExecuteScalar
                blnUtDoneError = dUTDate > CDate("1/1/1900")
                If blnUtDoneError Then
                    sMessage = "UT already done for Axle : " & sAxleNumber
                    Throw New Exception(sMessage)
                End If
                da.SelectCommand.CommandText = "select @ForgeDate = a.Date_forged , @ForgeShift = ltrim(rtrim(a.shft_forge)) , " & _
                        " @AxleCastNo = a.cast_number , @BilletCastNo = b.cast_number, @Axle_Sts = a.axle_sts, @Drawing_number = a.drawing_number, " & _
                        " @rejection_date = a.rejection_date, @rejection_location = a.rejection_location, @rejection_code = a.rejection_code, " & _
                        " @AxleLocation = a.Axle_Location, @workorder_number_forge = a.workorder_number_forge, " & _
                        " @Product_Code = c.Product_code, @Description = c.Description, @Billet_number = a.Billet_number ,  " & _
                        " @billet_date = b.billet_date , @shift_code = b.shift_code " & _
                        " from mm_axle_master a inner join mm_billet_heat b on a.billet_number = b.billet_number " & _
                        " inner join mm_workorder c on a.workorder_number_forge = c.number " & _
                        " where a.axle_number = '" & sAxleNumber & "' and axle_location = 'afaf'"

                da.SelectCommand.Parameters.Add("@AxleCastNo", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                da.SelectCommand.Parameters.Add("@BilletCastNo", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                da.SelectCommand.Parameters.Add("@axle_sts", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                da.SelectCommand.Parameters.Add("@drawing_number", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                da.SelectCommand.Parameters.Add("@AxleLocation", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                da.SelectCommand.Parameters.Add("@workorder_number_forge", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                da.SelectCommand.Parameters.Add("@ForgeDate", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output
                da.SelectCommand.Parameters.Add("@ForgeShift", SqlDbType.VarChar, 1).Direction = ParameterDirection.Output
                da.SelectCommand.Parameters.Add("@Product_Code", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                da.SelectCommand.Parameters.Add("@Description", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                da.SelectCommand.Parameters.Add("@Billet_Number", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                da.SelectCommand.Parameters.Add("@billet_date", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output
                da.SelectCommand.Parameters.Add("@shift_code", SqlDbType.VarChar, 1).Direction = ParameterDirection.Output
                da.SelectCommand.Parameters.Add("@rejection_code", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                da.SelectCommand.Parameters.Add("@rejection_date", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output
                da.SelectCommand.Parameters.Add("@rejection_Location", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output

                da.SelectCommand.ExecuteScalar()
                sAxleCastNumber = IIf(IsDBNull(da.SelectCommand.Parameters("@AxleCastNo").Value), "", da.SelectCommand.Parameters("@AxleCastNo").Value)
                sBilletCastNumber = IIf(IsDBNull(da.SelectCommand.Parameters("@BilletCastNo").Value), "", da.SelectCommand.Parameters("@BilletCastNo").Value)
                sAxleSts = IIf(IsDBNull(da.SelectCommand.Parameters("@axle_sts").Value), "", da.SelectCommand.Parameters("@axle_sts").Value)
                sDrawingNumber = IIf(IsDBNull(da.SelectCommand.Parameters("@drawing_number").Value), "", da.SelectCommand.Parameters("@drawing_number").Value)
                srejection_code = IIf(IsDBNull(da.SelectCommand.Parameters("@rejection_code").Value), "", da.SelectCommand.Parameters("@rejection_code").Value)
                drejection_date = IIf(IsDBNull(da.SelectCommand.Parameters("@rejection_date").Value), CDate("1/1/1900"), da.SelectCommand.Parameters("@rejection_date").Value)
                srejection_Location = IIf(IsDBNull(da.SelectCommand.Parameters("@rejection_Location").Value), "", da.SelectCommand.Parameters("@rejection_Location").Value)
                sAxleLocation = IIf(IsDBNull(da.SelectCommand.Parameters("@AxleLocation").Value), "", da.SelectCommand.Parameters("@AxleLocation").Value)
                sWorkOrderNumber = IIf(IsDBNull(da.SelectCommand.Parameters("@workorder_number_forge").Value), "", da.SelectCommand.Parameters("@workorder_number_forge").Value)
                sProductCode = IIf(IsDBNull(da.SelectCommand.Parameters("@Product_code").Value), "", da.SelectCommand.Parameters("@Product_code").Value)
                sDescription = IIf(IsDBNull(da.SelectCommand.Parameters("@Description").Value), "", da.SelectCommand.Parameters("@Description").Value)
                dForgeDate = IIf(IsDBNull(da.SelectCommand.Parameters("@ForgeDate").Value), CDate("1/1/1900"), da.SelectCommand.Parameters("@ForgeDate").Value)
                sForgedShift = IIf(IsDBNull(da.SelectCommand.Parameters("@ForgeShift").Value), "", Trim(da.SelectCommand.Parameters("@ForgeShift").Value))
                sBilletNumber = IIf(IsDBNull(da.SelectCommand.Parameters("@Billet_number").Value), "", da.SelectCommand.Parameters("@Billet_number").Value)
                dBillet_date = IIf(IsDBNull(da.SelectCommand.Parameters("@billet_date").Value), CDate("1/1/1900"), da.SelectCommand.Parameters("@billet_date").Value)
                sShift_code = IIf(IsDBNull(da.SelectCommand.Parameters("@shift_code").Value), "", Trim(da.SelectCommand.Parameters("@shift_code").Value))

                If sBilletCastNumber = "" Or sDrawingNumber = "" Or sAxleSts = "" Then
                    sMessage = "Axle not found in Master : " & sAxleNumber
                    blnAxleError = True
                    Throw New Exception(sMessage)
                End If
                da.SelectCommand.CommandText = "select wap.dbo.mm_si_fn_castTestResult('" & sAxleNumber & "')"
                Dim cststs = da.SelectCommand.ExecuteScalar()
                If IsNothing(cststs) Or IsDBNull(cststs) Then
                    sCastStatus = ""
                Else
                    sCastStatus = CStr(cststs)
                End If
                da.SelectCommand.CommandText = "select a.number, a.product_code, a.description, b.drawing_number, b.cast_group from mm_workorder a inner join mm_product_master b on a.product_code = b.product_code where @ForgeDate between start_date and end_date  and shop_code = 'f1'"
                da.SelectCommand.Parameters("@ForgeDate").Direction = ParameterDirection.Input
                da.SelectCommand.Parameters("@ForgeDate").Value = dForgeDate
                da.Fill(ds, "WorkOrders")
                tblWorkOrders = ds.Tables("WorkOrders")
                da.SelectCommand.CommandText = "select rej_code,rej_desc from mm_mmrjd_dump where location like 'AFAF%'"
                da.Fill(ds, "RejCodes")
                tblRejCodes = ds.Tables("RejCodes")
                cststs = Nothing
            Catch exp As Exception
                blnAxleError = True
                If sMessage = "" Then
                    sMessage = "Data Error: " & exp.Message & ":" & sAxleNumber
                End If
                Throw New Exception(sMessage)
            Finally
                If da.SelectCommand.Connection.State = ConnectionState.Open Then da.SelectCommand.Connection.Close()
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Sub
        Public Function CastTestResult(ByVal CastNumber As String, ByVal DrawingNumber As String, ByVal CastGroup As String) As String
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.CommandText = "Select top 1 Result from ms_cast_test_sample " & _
                " where cast_number = '" & CastNumber & "' and drawing_number = '" & DrawingNumber & "' and Cast_Group = '" & CastGroup & "' " & _
                " order by test_date desc"
            Try
                cmd.Connection.Open()
                CastTestResult = cmd.ExecuteScalar()
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Sub Save()
            Dim blnChangesFound As Boolean
            If oAxleEditForm.EmpCodeOperator = "" Or oAxleEditForm.EditShift = "" Or oAxleEditForm.EditDate = CDate("1/1/1900") Then
                Throw New Exception("Invalid login credentials. Cannot save")
            End If
            If sAxleNewStatus.StartsWith("P") Then
                If sNewRejectionCode.Replace("Select", "") <> "" Then
                    Throw New Exception("Axle Status pass with Rejection information cannot be saved")
                Else
                    sNewRejectionCode = ""
                    srejection_Location = ""
                    drejection_date = CDate("1/1/1900")
                End If
            End If

            If sAxleNewStatus.StartsWith("R") Then
                If sNewRejectionCode.Replace("Select", "") = "" Then
                    Throw New Exception("Axle Status Rejection without rejection information cannot be saved")
                Else
                    srejection_Location = "AFAF"
                    drejection_date = oAxleEditForm.EditDate
                    blnChangesFound = True
                End If
            End If

            If sAxleNumber = "" Then
                Throw New Exception("Invalid axle number")
            End If
            If sDrawingNumber = "" Then
                Throw New Exception("Drawing number not assigned")
            End If
            If sWorkOrderNumber = "" Then
                Throw New Exception("Workorder number not assigned")
            End If
            ' register changes
            If sNewWorkOrderNumber <> "" Then
                ' wo , drawing changed
                If sAxleNewDrawingNumber = "" Then
                    Throw New Exception("New drawing number is not assigned")
                End If
                blnChangesFound = True
            Else
                If sAxleNewDrawingNumber <> "" Then
                    Throw New Exception("New Drawing number assigned without new workorder number")
                End If
            End If
            If sAxleCastNumber = "" And sAxleNewCastNumber = "" Then
                Throw New Exception("Cast Number not assigned")
            End If
            If sBilletCastNumber = "" Then
                Throw New Exception("Billet Number not assigned")
            End If
            If sAxleNewCastNumber <> "" Then
                ' cast number changed
                blnChangesFound = True
            End If
            If blnChangesFound = False Then
                Throw New Exception("No Change found to save")
            End If
            blnChangesFound = Nothing
            Dim strInsertAuditRec, strUpdateAxleMaster, strUpdateBilletMaster, StrCheckBilletCount, strCheckAxleMasterCount, strCheckCastTestSampleCount, strUpdateCastTestSample As String
            PopulateCommandStrings(strInsertAuditRec, strUpdateAxleMaster, strUpdateBilletMaster, StrCheckBilletCount, strCheckAxleMasterCount, strCheckCastTestSampleCount, strUpdateCastTestSample)
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Parameters.Add("@Axle_Number", SqlDbType.VarChar, 50).Value = sAxleNumber
                cmd.Parameters.Add("@cast_number", SqlDbType.VarChar, 50).Value = IIf(sAxleNewCastNumber <> "", sAxleNewCastNumber, sAxleCastNumber)
                cmd.Parameters.Add("@ChangedInShift", SqlDbType.VarChar, 1).Value = oAxleEditForm.EditShift
                cmd.Parameters.Add("@EmpCodeOperator", SqlDbType.VarChar, 6).Value = oAxleEditForm.EmpCodeOperator
                cmd.Parameters.Add("@axle_sts", SqlDbType.VarChar, 50).Value = IIf(sAxleNewStatus <> "", sAxleNewStatus, sAxleSts)
                cmd.Parameters.Add("@billet_number", SqlDbType.VarChar, 50).Value = sBilletNumber

                cmd.Parameters.Add("@drawing_number", SqlDbType.VarChar, 50).Direction = ParameterDirection.Input
                cmd.Parameters.Add("@workorder_number_forge", SqlDbType.VarChar, 50).Direction = ParameterDirection.Input
                cmd.Parameters.Add("@rejection_code", SqlDbType.VarChar, 50).Direction = ParameterDirection.Input
                cmd.Parameters.Add("@rejection_date", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Input
                cmd.Parameters.Add("@rejection_location", SqlDbType.VarChar, 50).Direction = ParameterDirection.Input
                If sNewWorkOrderNumber <> "" Then
                    cmd.Parameters("@drawing_number").Value = sAxleNewDrawingNumber
                    cmd.Parameters("@workorder_number_forge").Value = sNewWorkOrderNumber
                Else
                    cmd.Parameters("@drawing_number").Value = sDrawingNumber
                    cmd.Parameters("@workorder_number_forge").Value = sWorkOrderNumber
                End If
                If sNewRejectionCode <> "" Then
                    cmd.Parameters("@rejection_code").Value = sNewRejectionCode
                    cmd.Parameters("@rejection_date").Value = oAxleEditForm.EditDate
                    cmd.Parameters("@rejection_location").Value = "AFAF"
                Else
                    cmd.Parameters("@rejection_code").Value = srejection_code
                    cmd.Parameters("@rejection_date").Value = drejection_date
                    cmd.Parameters("@rejection_location").Value = srejection_Location
                End If
            Catch exp As Exception
                sMessage = exp.Message
                Throw New Exception(" Assignment Error: " & sMessage)
            End Try
            Dim blnNotSaved As Boolean
            Dim intRecsAffected As Integer

            Try
                cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                cmd.CommandText = strCheckAxleMasterCount
                If cmd.ExecuteScalar <> 1 Then
                    sMessage = "Axle not found in master to update!"
                    blnNotSaved = True
                End If
                If blnNotSaved = False Then
                    cmd.CommandText = strInsertAuditRec
                    intRecsAffected = cmd.ExecuteNonQuery()
                    If intRecsAffected = 0 Then
                        sMessage = "Audit Record failed"
                        blnNotSaved = True
                    End If
                End If
                If blnNotSaved = False Then
                    cmd.CommandText = strUpdateAxleMaster
                    intRecsAffected = cmd.ExecuteNonQuery()
                    If intRecsAffected = 0 Then
                        sMessage = "Update Master failed"
                        blnNotSaved = True
                    End If
                End If
                If blnNotSaved = False Then
                    cmd.CommandText = StrCheckBilletCount
                    intRecsAffected = cmd.ExecuteNonQuery
                    If intRecsAffected = 0 Then
                        sMessage = "Update Billet Master record not found to update"
                        blnNotSaved = True
                    End If
                End If
                If blnNotSaved = False Then
                    cmd.CommandText = strUpdateBilletMaster
                    intRecsAffected = cmd.ExecuteNonQuery
                    If intRecsAffected = 0 Then
                        sMessage = "Update Billet Master failed"
                        blnNotSaved = True
                    End If
                End If
                If blnNotSaved = False Then
                    cmd.CommandText = strCheckCastTestSampleCount
                    intRecsAffected = cmd.ExecuteScalar
                    If intRecsAffected > 0 Then
                        cmd.CommandText = strUpdateCastTestSample
                        intRecsAffected = cmd.ExecuteNonQuery
                        If intRecsAffected = 0 Then
                            sMessage = "Updation of Cast Sample failed "
                            blnNotSaved = True
                        End If
                    End If
                End If
            Catch exp As Exception
                sMessage = "Save Failed : " & exp.Message
                blnNotSaved = True
            Finally
                If blnNotSaved = True Then
                    cmd.Transaction.Rollback()
                Else
                    cmd.Transaction.Commit()
                    sMessage = "Saved Axle No:" & sAxleNumber & " as " & IIf(sAxleNewStatus <> "", sAxleNewStatus, sAxleSts)
                End If
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
            If blnNotSaved Then
                Throw New Exception(sMessage)
            End If
            blnNotSaved = Nothing
            intRecsAffected = Nothing
            strInsertAuditRec = Nothing
            strUpdateAxleMaster = Nothing
            strUpdateBilletMaster = Nothing
            StrCheckBilletCount = Nothing
            strCheckAxleMasterCount = Nothing
        End Sub
        Public Sub UpdateWO()
            Dim blnNotSaved As Boolean
            Dim ChangedInShift As String
            Select Case Now.Hour
                Case 22 To 23
                    ChangedInShift = "C"
                Case 14 To 21
                    ChangedInShift = "B"
                Case 0 To 5
                    ChangedInShift = "C"
                Case 6 To 13
                    ChangedInShift = "A"
            End Select
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@Axle_Number", SqlDbType.VarChar, 50).Value = sAxleNumber
            cmd.Parameters.Add("@ForgedDate", SqlDbType.SmallDateTime, 4).Value = dForgeDate
            cmd.Parameters.Add("@ChangeDrg", SqlDbType.VarChar, 50).Value = sChangedDrg
            cmd.Parameters.Add("@ChangeWO", SqlDbType.VarChar, 50).Value = sChangedWO
            cmd.Parameters.Add("@ChangedInShift", SqlDbType.VarChar, 50).Value = ChangedInShift
            cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 6).Value = oAxleEditForm.EmpCodeOperator
            cmd.Parameters.Add("@product_code", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            Try
                cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                cmd.CommandText = " select @product_code = product_code from mm_workorder where number = @ChangeWO "
                cmd.ExecuteScalar()
                cmd.CommandText = "insert into mm_axle_master_audit " & _
                        " select axle_number, date_forged, drawing_number, cast_number, " & _
                        " workorder_number_forge, axle_location, axle_sts , rejection_code, rejection_date, " & _
                        " rejection_location, shft_forge, billet_number, serial_no, @EmpCode ," & _
                        " getdate(), ChangedInShift = @ChangedInShift from mm_axle_master where axle_number = @axle_Number"
                If cmd.ExecuteNonQuery = 1 Then
                    cmd.CommandText = " update mm_long_forging_machine " & _
                        " set workorder_number = @ChangeWO , product_type = @product_code " & _
                        " where billet_number in ( select billet_number from mm_axle_master " & _
                        " where axle_number = @Axle_Number ) "
                    If cmd.ExecuteNonQuery = 1 Then
                        cmd.CommandText = " update mm_billet_heat " & _
                        " set workorder_number = @ChangeWO , product_type = @product_code " & _
                        " where billet_number in ( select billet_number from mm_axle_master " & _
                        " where axle_number = @Axle_Number ) "
                        If cmd.ExecuteNonQuery = 1 Then
                            cmd.CommandText = " update mm_axle_master set workorder_number_forge = @ChangeWO ,  " & _
                                " drawing_number = @ChangeDrg where axle_number = @Axle_Number and date_forged = @ForgedDate and  axle_location = 'afaf' "
                            If cmd.ExecuteNonQuery = 0 Then
                                sMessage = "Updation of Master failed"
                                blnNotSaved = True
                            Else
                                cmd.CommandText = "Select count(*) from ms_cast_test_sample where axle_number = @Axle_Number"
                                If cmd.ExecuteScalar > 0 Then
                                    cmd.CommandText = "update a set a.cast_number = @cast_number , " & _
                                              " a.drawing_number = b.drawing_number , a.cast_group = b.cast_group " & _
                                              " from ms_cast_test_sample a inner join ( select * from mm_vw_si_RWFAxleProducts where product_code = @product_code ) b  " & _
                                              " on a.drawing_number = b.drawing_number where a.axle_number = @Axle_Number "
                                    If cmd.ExecuteNonQuery = 0 Then
                                        sMessage = "Updation of Cast Sample details failed"
                                        blnNotSaved = True
                                    End If
                                End If
                            End If
                        Else
                            blnNotSaved = True
                        End If
                    Else
                        blnNotSaved = True
                    End If
                Else
                    blnNotSaved = True
                End If
            Catch exp As Exception
                sMessage = "Save Failed : " & exp.Message
                blnNotSaved = True
            Finally
                If blnNotSaved = True Then
                    cmd.Transaction.Rollback()
                Else
                    cmd.Transaction.Commit()
                    sMessage = "Updation of Axle No:" & sAxleNumber & " successfull "
                End If
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
            blnNotSaved = Nothing
            ChangedInShift = Nothing
        End Sub
        Public Sub Savedate()
            Dim blnNotSaved As Boolean
            If dChangeDate >= dBillet_date OrElse (dChangeDate = dBillet_date AndAlso sChangeShift.Trim >= sShift_code.Trim) Then
                Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
                cmd.Parameters.Add("@Axle_Number", SqlDbType.VarChar, 50).Value = sAxleNumber
                cmd.Parameters.Add("@ForgedDate", SqlDbType.SmallDateTime, 4).Value = dForgeDate
                cmd.Parameters.Add("@ForgedShift", SqlDbType.VarChar, 1).Value = sForgedShift
                cmd.Parameters.Add("@ChangeDate", SqlDbType.SmallDateTime, 4).Value = dChangeDate
                cmd.Parameters.Add("@ChangeShift", SqlDbType.VarChar, 1).Value = sChangeShift
                Try
                    cmd.Connection.Open()
                    cmd.Transaction = cmd.Connection.BeginTransaction
                    cmd.CommandText = " update mm_axle_master set date_forged = @ChangeDate ,  shft_forge = @ChangeShift where axle_number = @Axle_Number and date_forged = @ForgedDate and  shft_forge = @ForgedShift "
                    If cmd.ExecuteNonQuery = 0 Then
                        sMessage = "Updation of Master failed"
                        blnNotSaved = True
                    End If
                Catch exp As Exception
                    sMessage = "Save Failed : " & exp.Message
                    blnNotSaved = True
                Finally
                    If blnNotSaved = True Then
                        cmd.Transaction.Rollback()
                    Else
                        cmd.Transaction.Commit()
                        sMessage = "Saved Axle No:" & sAxleNumber & " to Date : " & CDate(dChangeDate) & " and Shift : " & sChangeShift
                    End If
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                End Try
            Else
                sMessage = "Updation of Master failed ! ChangeDate and ChangeShift mis-matches with Billet_date and Billet_Shift ."
                blnNotSaved = True
            End If
            If blnNotSaved Then
                Throw New Exception(sMessage)
            End If
            blnNotSaved = Nothing
        End Sub
        Private Sub PopulateCommandStrings(ByRef strAuditRec As String, ByRef strUpdateAxleMaster As String, ByRef strUpdateBilletMaster As String, ByRef StrCheckBilletCount As String, ByRef strCheckAxleMasterCount As String, ByRef strCheckCastTestSampleCount As String, ByRef strUpdateCastTestSample As String)
            strAuditRec = "insert into mm_axle_master_audit " & _
                " select axle_number, date_forged, drawing_number, cast_number, " & _
                " workorder_number_forge, axle_location, axle_sts , rejection_code, rejection_date, " & _
                " rejection_location, shft_forge, billet_number, serial_no, @EmpCodeOperator ," & _
                " getdate(), ChangedInShift = @ChangedInShift from mm_axle_master where axle_number = @axle_Number"

            ' prepare update command.
            strUpdateAxleMaster = ""
            If sNewWorkOrderNumber <> "" Then
                strUpdateAxleMaster &= " a.drawing_number = @drawing_number,  workorder_number_forge = @workorder_number_forge "
            End If
            If sAxleNewCastNumber <> "" Then
                If strUpdateAxleMaster <> "" Then
                    strUpdateAxleMaster &= ","
                End If
                strUpdateAxleMaster &= " cast_number = @cast_number "
            End If

            If sNewRejectionCode <> "" Or sAxleNewStatus <> "" Then
                If strUpdateAxleMaster <> "" Then
                    strUpdateAxleMaster &= ","
                End If
                strUpdateAxleMaster &= "  rejection_code = @rejection_code, rejection_date = @rejection_date, rejection_location = @rejection_location "
            End If

            If sAxleNewStatus <> "" Then
                If strUpdateAxleMaster <> "" Then
                    strUpdateAxleMaster &= ","
                End If
                strUpdateAxleMaster &= "  axle_sts = @axle_sts "
            End If

            'strUpdateAxleMaster &= "  where axle_number = @Axle_Number"

            strUpdateAxleMaster &= " from mm_axle_master a inner join mm_vw_si_RWFAxleProducts b on a.drawing_number = b.drawing_number " & _
                                    " where axle_number = @Axle_Number "
            ' prefix update command...
            strUpdateAxleMaster = "update a set " & strUpdateAxleMaster

            strCheckAxleMasterCount = "Select count(*) from mm_axle_master where axle_number = @Axle_Number"
            StrCheckBilletCount = "Select count(*) from mm_billet_heat where billet_number = @billet_number"
            strUpdateBilletMaster = "update mm_billet_heat set cast_number = @Cast_number where billet_number = @billet_number"

            strCheckCastTestSampleCount = "Select count(*) from ms_cast_test_sample where axle_number = @Axle_Number"

            strUpdateCastTestSample = "update a set cast_number = @cast_number , " & _
                    " a.drawing_number = @drawing_number , a.cast_group = b.cast_group " & _
                    " from ms_cast_test_sample a inner join mm_vw_si_RWFAxleProducts b  " & _
                    " on a.drawing_number = b.drawing_number where axle_number = @Axle_Number "

        End Sub
#End Region
    End Class
End Namespace

