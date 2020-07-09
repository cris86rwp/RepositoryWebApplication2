Namespace CalibrationTest
    <Serializable()> Public Class Tables
        Public Shared Function getUVData(ByVal UVDate As Date) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Connection = rwfGen.Connection.ConObj
                da.SelectCommand.Parameters.Add("@UVDate", SqlDbType.SmallDateTime, 4).Value = UVDate
                da.SelectCommand.CommandText = "select convert(varchar(11),CalibrationDate,103) UVClaiDt , " &
                    " Shift Sh , LineNumber Line , Operator ,copec2,copec3,copec4,
Drag_ID,dragd2,dragd3,dragd4,tread , " &
                    " Convert(varchar(11), DueDate, 103) DueDate , " &
                    " Results , Remarks , SlNo " &
                    " from ms_vw_uv_calibration_new where  CalibrationDate = @UVDate "
                da.Fill(ds)
                getUVData = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function CalibrationData(ByVal FromDate As String, ByVal ToDate As String, ByVal FiledName As String) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.Parameters.Add("@fr", SqlDbType.SmallDateTime, 4).Value = CDate(FromDate)
                da.SelectCommand.Parameters.Add("@to", SqlDbType.SmallDateTime, 4).Value = CDate(ToDate)
                If FiledName.ToLower = "mag" Then
                    da.SelectCommand.CommandText = "select Convert(Varchar(10),calibration_date,103) Dt , shift_code Sh , inspector , line_number Line , " & _
                            " wheel_type WhlType , bath_concentration BathCon , results , remarks , SavedDateTime , SlNo " & _
                            " from ms_magnaglow_calibration where calibration_date between @fr and @to " & _
                            " order by calibration_date  ,  shift_code , line_number , SavedDateTime "
                ElseIf FiledName.ToLower = "ut" Then
                    da.SelectCommand.CommandText = "select Convert(Varchar(10),calibration_date,103) Dt , shift_code Sh , inspector , line_number Line , " & _
                            " wheel_type WhlType , time_from TimeFrom , time_to TimeTo , results , remarks , SavedDateTime , SlNo " & _
                            " from ms_ut_calibration where calibration_date between @fr and @to and SetUp = 'Results' " & _
                            " order by calibration_date ,  shift_code , line_number , SavedDateTime "
                ElseIf FiledName.ToLower = "bhn" Then
                    da.SelectCommand.CommandText = "select convert(varchar(11),calibration_date,103) BHNClaiDt , " & _
                            " shift_code Sh , line_number Line , wheel_type WhlType , " & _
                            " inspector , bhn_certified BHNCertified , bhn_mean_obtained " & _
                            " BHNObtained , process_tolerance Tolerance , " & _
                            " acceptable_criteria AccCriteria , Convert(varchar(11), due_date_calibration, 103)" & _
                            " DueDate, results, remarks" & _
                            " from ms_bhn_calibration where  calibration_date between @fr and @to " & _
                            " order by calibration_date  ,  shift_code , line_number "
                ElseIf FiledName.ToLower = "uv" Then
                    da.SelectCommand.CommandText = "select convert(varchar(11),CalibrationDate,103) UVClaiDt , " & _
                            " Shift Sh , LineNumber Line , Operator , CopeValue , DragValue , " & _
                            " Convert(varchar(11), DueDate, 103) DueDate , Results , Remarks " & _
                            " from ms_vw_uv_calibration where  CalibrationDate between @fr and @to " & _
                            " order by CalibrationDate  ,  Shift , LineNumber "
                ElseIf FiledName.ToLower = "ut setup" Then
                    da.SelectCommand.CommandText = "select Convert(Varchar(10),calibration_date,103) Dt , shift_code Sh , inspector , line_number Line , " & _
                            " wheel_type FromWhlType , time_from TimeFrom , time_to TimeTo , results ToWhlType , remarks , SavedDateTime , SlNo " & _
                            " from ms_ut_calibration where calibration_date between @fr and @to and SetUp = 'SetUp' " & _
                            " order by calibration_date ,  shift_code , line_number , SavedDateTime "
                End If
                da.Fill(ds)
                Return ds.Tables(0).Copy
            Catch exp As Exception
                Throw New Exception("Data Retrieval Error : " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function getBHNData(ByVal BHNDate As Date) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Connection = rwfGen.Connection.ConObj
                da.SelectCommand.Parameters.Add("@BHNDate", SqlDbType.SmallDateTime, 4).Value = BHNDate
                da.SelectCommand.CommandText = "select convert(varchar(11),calibration_date,103) BHNClaiDt , " &
                    " shift_code Sh , line_number Line , wheel_type WhlType , " &
                    " inspector , bhn_certified BHNCertified , bhn_mean_obtained " &
                    " BHNObtained , '+/- '+convert(varchar,process_tolerance) Tolerance , " &
                    " '+/- '+convert(varchar,acceptable_criteria)+' BHN' AccCriteria , Convert(varchar(11), due_date_calibration, 103)" &
                    " DueDate, results, remarks" &
                    " from ms_bhn_calibration where  calibration_date = @BHNDate "
                da.Fill(ds)
                getBHNData = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function LastRecord() As String
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Connection.Open()
                cmd.Parameters.Add("@LastRecord", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output
                cmd.CommandText = "select top 1 @LastRecord = 'Last Record : Date = " & _
                    " '+convert(varchar(11),calibration_date,103)+' Shift = '" & _
                    " +shift_code+' Line = '+line_number+' Wheel = '+wheel_type " & _
                    " from ms_bhn_calibration where  calibration_date = " & _
                    " (select max(calibration_date) from ms_bhn_calibration)"
                cmd.ExecuteScalar()
                LastRecord = IIf(IsDBNull(cmd.Parameters("@LastRecord").Value), "", cmd.Parameters("@LastRecord").Value)
            Catch exp As Exception
                LastRecord = ""
                Throw New Exception(exp.Message)
            Finally
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function getWhlType() As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "select distinct left(ltrim(rtrim(description)),4) WhlType " & _
                    " from mm_product_master where product_code like '1%' OR product_code like '2%'"
                da.Fill(ds, "WhlType")
                getWhlType = ds.Tables("WhlType")
            Catch exp As Exception
                Throw New Exception(" Retrival of WhlType Details List " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function getCalibrationDetails(ByVal CalibrationType As String, ByVal CalibrationDate As Date, ByVal Shift As String, ByVal LineNumber As String, ByVal WhlType As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                If CalibrationType.ToLower = "mag" Then
                    da.SelectCommand.CommandText = "select Convert(Varchar(10),calibration_date,103) Date , " &
                            " shift_code Shift , Inspector , line_number Line ," &
                            " wheel_type WhlType , bath_concentration BathCon , results , remarks ,  SlNo ,cope  " &
                            " from ms_magnaglow_calibration where calibration_date = @CalibrationDate " &
                            " and shift_code = @Shift and line_number = @LineNumber and wheel_type = @WhlType " &
                            " order by calibration_date desc ,  shift_code , line_number  "
                ElseIf CalibrationType.ToLower = "ut" Then
                    da.SelectCommand.CommandText = "select Convert(Varchar(10),calibration_date,103) Dt , " &
                            " shift_code Shift , Inspector , line_number Line , " &
                            " wheel_type WhlType , time_from TimeFrom , time_to TimeTo , " &
                            " results , remarks ,cope, SlNo , SetUp " &
                            " from ms_ut_calibration where calibration_date = @CalibrationDate and SetUp = 'results' " &
                            " and shift_code = @Shift and line_number = @LineNumber and wheel_type = @WhlType " &
                            " order by calibration_date desc ,  shift_code , line_number "
                ElseIf CalibrationType.ToLower = "ut setup" Then
                    da.SelectCommand.CommandText = "select Convert(Varchar(10),calibration_date,103) Dt , " &
                            " shift_code Shift , Inspector , line_number Line , " &
                            " wheel_type FromWhlType , time_from TimeFrom , time_to TimeTo , " &
                            " results ToWhlType, remarks , SlNo , SetUp " &
                            " from ms_ut_calibration where calibration_date = @CalibrationDate and SetUp = 'setup'" &
                            " and shift_code = @Shift and line_number = @LineNumber and wheel_type = @WhlType " &
                            " order by calibration_date desc ,  shift_code , line_number "
                End If
                da.SelectCommand.Parameters.Add("@CalibrationDate", SqlDbType.SmallDateTime, 4).Value = CalibrationDate
                da.SelectCommand.Parameters.Add("@Shift", SqlDbType.VarChar, 1).Value = Shift
                da.SelectCommand.Parameters.Add("@LineNumber", SqlDbType.VarChar, 2).Value = LineNumber
                da.SelectCommand.Parameters.Add("@WhlType", SqlDbType.VarChar, 4).Value = WhlType
                da.Fill(ds, "CalibrationSavedData")
                getCalibrationDetails = ds.Tables("CalibrationSavedData")
            Catch exp As Exception
                Throw New Exception(" Retrival of Calibration Details List " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function getCalibrationData(ByVal CalibrationType As String, ByVal CalibrationDate As Date) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                If CalibrationType.ToLower = "mag" Then
                    da.SelectCommand.CommandText = "select SlNo , Convert(Varchar(10),calibration_date,103) Dt , shift_code Sh , inspector , line_number Line , " & _
                            " wheel_type WhlType , bath_concentration BathCon , results , remarks , SavedDateTime " & _
                            " from ms_magnaglow_calibration where calibration_date = @CalibrationDate " & _
                            " order by calibration_date desc ,  shift_code , line_number , SavedDateTime "
                ElseIf CalibrationType.ToLower = "ult" Then
                    da.SelectCommand.CommandText = "select SlNo , Convert(Varchar(10),calibration_date,103) Dt , shift_code Sh , inspector , line_number Line , " & _
                            " wheel_type WhlType , time_from TimeFrom , time_to TimeTo , results , remarks , SavedDateTime " & _
                            " from ms_ut_calibration where calibration_date = @CalibrationDate " & _
                            " order by calibration_date desc ,  shift_code , line_number , SavedDateTime "
                ElseIf CalibrationType.ToLower = "bhn" Then
                    da.SelectCommand.CommandText = "select SlNo , convert(varchar(11),calibration_date,103) BHNClaiDt , " & _
                            " shift_code Sh , line_number Line , wheel_type WhlType , " & _
                            " inspector , bhn_certified BHNCertified , bhn_mean_obtained " & _
                            " BHNObtained , '+/- '+convert(varchar,process_tolerance) Tolerance , " & _
                            " convert(varchar,acceptable_criteria)+' BHN' AccCriteria , Convert(varchar(11), due_date_calibration, 103)" & _
                            " DueDate, results, remarks" & _
                            " from ms_bhn_calibration where  calibration_date = @CalibrationDate "
                ElseIf CalibrationType.ToLower = "uv" Then
                    da.SelectCommand.CommandText = " select SlNo , convert(varchar(11),CalibrationDate,103) UVClaiDt ," & _
                        " Shift Sh , LineNumber Line , Operator , CopeValue , DragValue ," & _
                        " Convert(varchar(11), DueDate, 103) DueDate , Results , Remarks" & _
                        " from ms_vw_uv_calibration where  CalibrationDate = @CalibrationDate  "
                End If
                da.SelectCommand.Parameters.Add("@CalibrationDate", SqlDbType.SmallDateTime, 4).Value = CalibrationDate

                da.Fill(ds)
                getCalibrationData = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(" Retrival of Calibration Details List " & exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
    End Class
    MustInherit Class BaseValues
#Region " Fields"
        Private dateCalibrationDate, dateSavedDateTime As Date
        Private sMessage, sShift, sInspector, sLineNumber, sWheelType, sResults, sRemarks, sSetUp As String
        Private intSlNo, intResultID, intcope As Integer
#End Region
#Region " Property"
        Property Message() As String
            Get
                Return sMessage
            End Get
            Set(ByVal Value As String)
                sMessage = Value
            End Set
        End Property
        Property SlNo() As Integer
            Get
                Return intSlNo
            End Get
            Set(ByVal Value As Integer)
                intSlNo = Value
            End Set
        End Property
        Property SavedDateTime() As Date
            Get
                Return dateSavedDateTime
            End Get
            Set(ByVal Value As Date)
                dateSavedDateTime = Value
            End Set
        End Property '
        Property SetUp() As String
            Get
                Return sSetUp
            End Get
            Set(ByVal Value As String)
                sSetUp = Value
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
        Property ResultID() As Integer
            Get
                Return intResultID
            End Get
            Set(ByVal Value As Integer)
                intResultID = Value
            End Set
        End Property
        Property Results() As String
            Get
                Return sResults
            End Get
            Set(ByVal Value As String)
                sResults = Value
            End Set
        End Property
        Property WheelType() As String
            Get
                Return sWheelType
            End Get
            Set(ByVal Value As String)
                sWheelType = Value
            End Set
        End Property
        Property LineNumber() As String
            Get
                Return sLineNumber
            End Get
            Set(ByVal Value As String)
                sLineNumber = Value
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
        Property CalibrationDate() As Date
            Get
                Return dateCalibrationDate
            End Get
            Set(ByVal Value As Date)
                dateCalibrationDate = Value
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
        'new property
        Property copemag() As Integer
            Get
                Return intcope
            End Get
            Set(ByVal Value As Integer)
                intcope = Value
            End Set
        End Property

#End Region
#Region " Methods"
        Private Sub iniVals()
            sSetUp = ""
            sMessage = ""
            intSlNo = 0
            dateSavedDateTime = CDate("1-1-1900")
            sRemarks = ""
            sResults = ""
            sWheelType = ""
            sLineNumber = ""
            sInspector = ""
            sShift = ""
            dateCalibrationDate = CDate("01-01-1900")
        End Sub
#End Region
    End Class
    Friend Class MAG
        Inherits CalibrationTest.BaseValues
#Region " Fields"
        Private sBathConcentration As String
#End Region
#Region " Property"
        Property BathConcentration() As String
            Get
                Return sBathConcentration
            End Get
            Set(ByVal Value As String)
                sBathConcentration = Value
            End Set
        End Property
#End Region
#Region " Methods"
        Private Sub iniVals()
            sBathConcentration = ""
        End Sub
        Public Sub New()
            iniVals()
        End Sub
        Public Sub Save(Optional ByVal SlNo As Integer = 0)
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                oCmd.Parameters.Add("@calibration_date", SqlDbType.SmallDateTime, 4).Value = Me.CalibrationDate
                oCmd.Parameters.Add("@shift_code", SqlDbType.VarChar, 1).Value = Me.Shift
                oCmd.Parameters.Add("@inspector", SqlDbType.VarChar, 50).Value = Me.Inspector
                oCmd.Parameters.Add("@line_number", SqlDbType.VarChar, 50).Value = Me.LineNumber
                oCmd.Parameters.Add("@wheel_type", SqlDbType.VarChar, 50).Value = Me.WheelType
                oCmd.Parameters.Add("@bath_concentration", SqlDbType.VarChar, 50).Value = sBathConcentration
                oCmd.Parameters.Add("@results", SqlDbType.VarChar, 50).Value = Me.Results
                oCmd.Parameters.Add("@remarks", SqlDbType.VarChar, 50).Value = Me.Remarks
                oCmd.Parameters.Add("@SavedDateTime", SqlDbType.DateTime, 8).Value = Now
                oCmd.Parameters.Add("@SlNo", SqlDbType.Int, 4).Value = Me.SlNo
                oCmd.Parameters.Add("@cope", SqlDbType.VarChar, 50).Value = Me.copemag
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                If IIf(IsDBNull(oCmd.Parameters("@SlNo").Value), 0, oCmd.Parameters("@SlNo").Value) = 0 Then
                    oCmd.CommandText = " insert into ms_magnaglow_calibration ( calibration_date , shift_code , inspector , line_number , wheel_type , bath_concentration , results , remarks , SavedDateTime ,cope )" &
                        " values ( @calibration_date , @shift_code , @inspector , @line_number , @wheel_type , @bath_concentration , @results , @remarks , @SavedDateTime ,@cope )"
                Else
                    oCmd.CommandText = " update ms_magnaglow_calibration set calibration_date = @calibration_date , shift_code = @shift_code , inspector = @inspector , " &
                        "  line_number = @line_number , wheel_type = @wheel_type , bath_concentration = @bath_concentration ,  " &
                        "  results = @results , remarks = @remarks , SavedDateTime = @SavedDateTime , cope = @cope where SlNo = @SlNo "
                End If
                If oCmd.ExecuteNonQuery() > 0 Then
                    Me.Message = "Updation successful !"
                Else
                    Me.Message = "Updation Failed !"
                End If
            Catch exp As Exception
                Me.Message = exp.Message
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Sub
#End Region
    End Class
    Friend Class UT
        Inherits CalibrationTest.BaseValues
#Region " Fields"
        Private sTimeFrom, sTimeTo As String
        Private intcope As Integer

#End Region
#Region " Property"
        Property TimeTo() As String
            Get
                Return sTimeTo
            End Get
            Set(ByVal Value As String)
                sTimeFrom = Value
            End Set
        End Property
        Property TimeFrom() As String
            Get
                Return sTimeFrom
            End Get
            Set(ByVal Value As String)
                sTimeTo = Value
            End Set
        End Property
        'new property
        Property copeut() As Integer
            Get
                Return intcope
            End Get
            Set(ByVal Value As Integer)
                intcope = Value
            End Set
        End Property

#End Region
#Region " Methods"
        Private Sub iniVals()
            sTimeTo = ""
            sTimeFrom = ""
        End Sub
        Public Sub New()
            iniVals()
        End Sub
        Public Sub Save(Optional ByVal SlNo As Integer = 0)
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                oCmd.Parameters.Add("@calibration_date", SqlDbType.SmallDateTime, 4).Value = Me.CalibrationDate
                oCmd.Parameters.Add("@shift_code", SqlDbType.VarChar, 1).Value = Me.Shift
                oCmd.Parameters.Add("@inspector", SqlDbType.VarChar, 50).Value = Me.Inspector
                oCmd.Parameters.Add("@line_number", SqlDbType.VarChar, 50).Value = Me.LineNumber
                oCmd.Parameters.Add("@wheel_type", SqlDbType.VarChar, 50).Value = Me.WheelType
                oCmd.Parameters.Add("@time_from", SqlDbType.VarChar, 50).Value = sTimeFrom
                oCmd.Parameters.Add("@time_to", SqlDbType.VarChar, 50).Value = sTimeTo
                oCmd.Parameters.Add("@results", SqlDbType.VarChar, 50).Value = Me.Results
                oCmd.Parameters.Add("@remarks", SqlDbType.VarChar, 50).Value = Me.Remarks '
                oCmd.Parameters.Add("@SetUp", SqlDbType.VarChar, 50).Value = Me.SetUp
                oCmd.Parameters.Add("@SavedDateTime", SqlDbType.DateTime, 8).Value = Now
                oCmd.Parameters.Add("@SlNo", SqlDbType.Int, 4).Value = Me.SlNo
                oCmd.Parameters.Add("@cope", SqlDbType.VarChar, 50).Value = Me.copeut
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                If IIf(IsDBNull(oCmd.Parameters("@SlNo").Value), 0, oCmd.Parameters("@SlNo").Value) = 0 Then
                    oCmd.CommandText = " insert into ms_ut_calibration ( calibration_date , shift_code , inspector , line_number , wheel_type , time_from , time_to , results , remarks , SavedDateTime , SetUp ,cope )" &
                        " values ( @calibration_date , @shift_code , @inspector , @line_number , @wheel_type , @time_from , @time_to , @results , @remarks , @SavedDateTime , @SetUp , @cope )"
                Else
                    oCmd.CommandText = " update ms_ut_calibration set calibration_date = @calibration_date , shift_code = @shift_code , inspector = @inspector , " &
                        "  line_number = @line_number , wheel_type = @wheel_type , time_from = @time_from , time_to = @time_to  ,  " &
                        "  results = @results , remarks = @remarks , SavedDateTime = @SavedDateTime cope=@cope where SlNo = @SlNo "
                End If
                If oCmd.ExecuteNonQuery() > 0 Then
                    Me.Message = "Updation successful !"
                Else
                    Me.Message = "Updation Failed !"
                End If
            Catch exp As Exception
                Me.Message = exp.Message
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Sub
#End Region
    End Class
    Friend Class BHN
        Inherits CalibrationTest.BaseValues
#Region " Fields"
        Private sBHNCertified, electop, mechop As String
        Private intBHNObtained, intTolerance, intAccCriteria, intcope As Integer
        Private dateDueDate As Date
#End Region
#Region " Property"
        WriteOnly Property Tolerance() As Integer
            Set(ByVal Value As Integer)
                intTolerance = Value
            End Set
        End Property
        WriteOnly Property AccCriteria() As Integer
            Set(ByVal Value As Integer)
                intAccCriteria = Value
            End Set
        End Property
        WriteOnly Property BHNObtained() As Integer
            Set(ByVal Value As Integer)
                intBHNObtained = Value
            End Set
        End Property
        WriteOnly Property DueDate() As Date
            Set(ByVal Value As Date)
                dateDueDate = Value
            End Set
        End Property
        WriteOnly Property BHNCertified() As String
            Set(ByVal Value As String)
                sBHNCertified = Value
            End Set
        End Property
        'new
        Property BHNcope() As Integer
            Get
                Return intcope
            End Get
            Set(ByVal Value As Integer)
                intcope = Value
            End Set
        End Property
        Property BHNelect() As String
            Get
                Return electop
            End Get
            Set(ByVal Value As String)
                electop = Value
            End Set
        End Property
        Property BHNmech() As String
            Get
                Return mechop
            End Get
            Set(ByVal Value As String)
                mechop = Value
            End Set
        End Property

#End Region
#Region " Methods"
        Private Sub iniVals()
            intBHNObtained = 0
            intTolerance = 0
            intAccCriteria = 0
            sBHNCertified = ""
            dateDueDate = "1900-01-01"
        End Sub
        Public Sub New()
            iniVals()
        End Sub
        Public Function SaveBHN() As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                oCmd.Parameters.Add("@calibration_date", SqlDbType.SmallDateTime, 4).Value = Me.CalibrationDate
                oCmd.Parameters.Add("@shift_code", SqlDbType.VarChar, 1).Value = Me.Shift
                oCmd.Parameters.Add("@inspector", SqlDbType.VarChar, 50).Value = Me.Inspector
                oCmd.Parameters.Add("@line_number", SqlDbType.VarChar, 50).Value = Me.LineNumber
                oCmd.Parameters.Add("@wheel_type", SqlDbType.VarChar, 50).Value = Me.WheelType
                oCmd.Parameters.Add("@BHNCertified", SqlDbType.VarChar, 50).Value = sBHNCertified
                oCmd.Parameters.Add("@BHNObtained", SqlDbType.Int, 4).Value = intBHNObtained
                oCmd.Parameters.Add("@Tolerance", SqlDbType.Int, 4).Value = intTolerance
                oCmd.Parameters.Add("@AccCriteria", SqlDbType.Int, 4).Value = intAccCriteria
                oCmd.Parameters.Add("@results", SqlDbType.VarChar, 50).Value = Me.Results
                oCmd.Parameters.Add("@remarks", SqlDbType.VarChar, 50).Value = Me.Remarks
                oCmd.Parameters.Add("@DueDate", SqlDbType.SmallDateTime, 4).Value = dateDueDate
                oCmd.Parameters.Add("@SlNo", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                oCmd.Parameters.Add("@cope", SqlDbType.VarChar, 50).Value = Me.BHNcope
                oCmd.Parameters.Add("@elect", SqlDbType.VarChar, 50).Value = Me.BHNelect
                oCmd.Parameters.Add("@mech", SqlDbType.VarChar, 50).Value = Me.BHNmech
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = "select @SlNo = count(*) from ms_bhn_calibration " &
                    " where  calibration_date = @calibration_date and shift_code = @shift_code " &
                    " and line_number = @line_number and wheel_type = @wheel_type "
                oCmd.ExecuteScalar()
                If IIf(IsDBNull(oCmd.Parameters("@SlNo").Value), 0, oCmd.Parameters("@SlNo").Value) = 0 Then
                    oCmd.CommandText = " insert into ms_bhn_calibration " &
                    " ( calibration_date , shift_code , line_number , wheel_type ," &
                    " Inspector , bhn_certified , bhn_mean_obtained , process_tolerance, " &
                    " acceptable_criteria , due_date_calibration , results , remarks,cope, Elect_ID, Mech_ID ) " &
                    " values ( @calibration_date , @shift_code ,  @line_number , @wheel_type , " &
                    " @inspector , @BHNCertified  , @BHNObtained , @Tolerance , @AccCriteria , " &
                    " @DueDate , @results , @remarks,@cope,@elect,@mech )"
                Else
                    oCmd.CommandText = " update ms_bhn_calibration " &
                    " set inspector = @inspector , bhn_certified = @BHNCertified , " &
                    " bhn_mean_obtained = @BHNObtained , process_tolerance = @Tolerance , " &
                    " acceptable_criteria = @AccCriteria , due_date_calibration = @DueDate , " &
                    " results = @results , remarks = @remarks , cope=@cope , Elect_ID=@elect ,Mech_ID= @mech" &
                    " where  calibration_date = @calibration_date and shift_code = @shift_code " &
                    " and line_number = @line_number and wheel_type = @wheel_type "
                End If
                If oCmd.ExecuteNonQuery() > 0 Then
                    Me.Message = "Updation successful !"
                Else
                    Me.Message = "Updation Failed !"
                End If
            Catch exp As Exception
                Me.Message = exp.Message
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function
#End Region
    End Class
    Public Class CalibrationDelete
        Public Function Delete(ByVal Test As String, ByVal SlNo As Long) As Boolean
            Dim blnDone As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Parameters.Add("@SlNo", SqlDbType.BigInt, 8).Value = SlNo
                If Test.ToLower = "mag" Then
                    oCmd.CommandText = "delete ms_magnaglow_calibration where SlNo = @SlNo"
                ElseIf Test.ToLower = "ult" Then
                    oCmd.CommandText = "delete ms_ut_calibration where SlNo = @SlNo"
                ElseIf Test.ToLower = "bhn" Then
                    oCmd.CommandText = "delete ms_bhn_calibration where SlNo = @SlNo"
                ElseIf Test.Trim.ToLower = "uv" Then
                    oCmd.CommandText = "delete ms_uv_calibration where SlNo = @SlNo"
                End If
                If oCmd.ExecuteNonQuery = 1 Then blnDone = True
            Catch exp As Exception
                blnDone = False
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
            Return blnDone
        End Function
    End Class
    Friend Class UV
        Inherits CalibrationTest.BaseValues
#Region " Fields"
        Private intCopeIntensity, intDragIntensity, copec1, copec2, copec3, copec4, dragd1, dragd2, dragd3, dragd4, tread, drag As Integer
        Private dateDueDate As Date
#End Region
#Region " Property"
        WriteOnly Property DragIntensity() As Integer
            Set(ByVal Value As Integer)
                intDragIntensity = Value
            End Set
        End Property
        WriteOnly Property CopeIntensity() As Integer
            Set(ByVal Value As Integer)
                intCopeIntensity = Value
            End Set
        End Property
        WriteOnly Property DueDate() As Date
            Set(ByVal Value As Date)
                dateDueDate = Value
            End Set
        End Property
        'new
        Property Setcopec1() As Integer
            Get
                Return copec1
            End Get
            Set(ByVal Value As Integer)
                copec1 = Value
            End Set
        End Property
        Property Setcopec2() As Integer
            Get
                Return copec2
            End Get
            Set(ByVal Value As Integer)
                copec2 = Value
            End Set
        End Property
        Property Setcopec3() As Integer
            Get
                Return copec3
            End Get
            Set(ByVal Value As Integer)
                copec3 = Value
            End Set
        End Property
        Property Setcopec4() As Integer
            Get
                Return copec4
            End Get
            Set(ByVal Value As Integer)
                copec4 = Value
            End Set
        End Property
        Property Setdragd1() As Integer
            Get
                Return dragd1
            End Get
            Set(ByVal Value As Integer)
                dragd1 = Value
            End Set
        End Property
        Property Setdragd2() As Integer
            Get
                Return dragd2
            End Get
            Set(ByVal Value As Integer)
                dragd2 = Value
            End Set
        End Property
        Property Setdragd3() As Integer
            Get
                Return dragd3
            End Get
            Set(ByVal Value As Integer)
                dragd3 = Value
            End Set
        End Property
        Property Setdragd4() As Integer
            Get
                Return dragd4
            End Get
            Set(ByVal Value As Integer)
                dragd4 = Value
            End Set
        End Property
        Property Setdrag() As Integer
            Get
                Return drag
            End Get
            Set(ByVal Value As Integer)
                drag = Value
            End Set
        End Property
        Property SetTread() As Integer
            Get
                Return tread
            End Get
            Set(ByVal Value As Integer)
                tread = Value
            End Set
        End Property

#End Region
#Region " Methods"
        Private Sub iniVals()
            intCopeIntensity = 0
            intDragIntensity = 0
            dateDueDate = "1900-01-01"
        End Sub
        Public Sub New()
            iniVals()
        End Sub
        Public Function SaveUV(Optional ByVal Sl As Integer = 0) As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                oCmd.Parameters.Add("@calibration_date", SqlDbType.SmallDateTime, 4).Value = Me.CalibrationDate
                oCmd.Parameters.Add("@shift_code", SqlDbType.VarChar, 1).Value = Me.Shift
                oCmd.Parameters.Add("@inspector", SqlDbType.VarChar, 50).Value = Me.Inspector
                oCmd.Parameters.Add("@line_number", SqlDbType.VarChar, 50).Value = Me.LineNumber
                'oCmd.Parameters.Add("@CopeValue", SqlDbType.VarChar, 50).Value = intCopeIntensity
                'oCmd.Parameters.Add("@DragValue", SqlDbType.Int, 4).Value = intDragIntensity
                oCmd.Parameters.Add("@Results", SqlDbType.SmallInt, 2).Value = Me.ResultID
                oCmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 50).Value = Me.Remarks
                oCmd.Parameters.Add("@DueDate", SqlDbType.SmallDateTime, 4).Value = dateDueDate
                oCmd.Parameters.Add("@SaveDateTime", SqlDbType.DateTime, 8).Value = Now
                oCmd.Parameters.Add("@copeone", SqlDbType.VarChar, 50).Value = Me.Setcopec1
                oCmd.Parameters.Add("@copetwo", SqlDbType.VarChar, 50).Value = Me.Setcopec2
                oCmd.Parameters.Add("@copethree", SqlDbType.VarChar, 50).Value = Me.Setcopec3
                oCmd.Parameters.Add("@copefour", SqlDbType.VarChar, 50).Value = Me.Setcopec4
                oCmd.Parameters.Add("@dragone", SqlDbType.VarChar, 50).Value = Me.Setdragd1
                oCmd.Parameters.Add("@dragtwo", SqlDbType.VarChar, 50).Value = Me.Setdragd2
                oCmd.Parameters.Add("@dragthree", SqlDbType.VarChar, 50).Value = Me.Setdragd3
                oCmd.Parameters.Add("@dragfour", SqlDbType.VarChar, 50).Value = Me.Setdragd4
                oCmd.Parameters.Add("@drag", SqlDbType.VarChar, 50).Value = Me.Setdrag
                oCmd.Parameters.Add("@tread", SqlDbType.VarChar, 50).Value = Me.SetTread
                oCmd.Parameters.Add("@SlNo", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = "select @SlNo = count(*) from ms_uv_calibration " &
                    " where  CalibrationDate = @calibration_date and Shift = @shift_code " &
                    " and LineNumber = @line_number "
                oCmd.ExecuteScalar()
                If IIf(IsDBNull(oCmd.Parameters("@SlNo").Value), 0, oCmd.Parameters("@SlNo").Value) = 0 Then
                    oCmd.CommandText = " insert into ms_uv_calibration " &
                    " ( CalibrationDate , Shift , LineNumber ," &
                    "  Operator , DueDate , Results , Remarks , SaveDateTime, copec1,copec2,copec3,copec4,dragd1,dragd2,dragd3,dragd4,Drag_ID,tread ) " &
                    " values ( @calibration_date , @shift_code ,  @line_number ,  " &
                    "   @inspector , @DueDate , @results , @Remarks , @SaveDateTime,@copeone,@copetwo,@copethree,@copefour,@dragone,@dragtwo,@dragthree,@dragfour,@drag,@tread )"
                ElseIf oCmd.Parameters("@SlNo").Value = Sl Then
                    oCmd.CommandText = " update ms_uv_calibration " &
                    " set Operator = @inspector ,  " &
                    "  DueDate = @DueDate , " &
                    " Results = @Results , remarks = @remarks  , copec1=@copeone , copec2=@copetwo ,copec3=@copethree , copec4=@copefour ,dragd1=@dragone,dragd2=@dragtwo,dragd3=@dragthree,dragd4=@dragfour,Drag_ID=@drag,tread=@tread" &
                    " where  CalibrationDate = @calibration_date and Shift = @shift_code " &
                    " and LineNumber = @line_number "
                End If
                If oCmd.ExecuteNonQuery() > 0 Then
                    SaveUV = True
                    Me.Message = "Updation successful !"
                Else
                    Me.Message = "Updation Failed !"
                End If
            Catch exp As Exception
                Me.Message = exp.Message
                SaveUV = False
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function
#End Region
    End Class
End Namespace
