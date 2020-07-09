Namespace HSD_Data
    Public Class HsdPoint
        Dim sLogin, sHeader, sMessage As String
        Dim blnError, blnWithdrawn As Boolean
        Dim dStartUpDate, dWithDrawnDate, dWithDrawnSaveDateTime, dSaveDateTime As Date
        Dim sStartUpShift, sHsdPoint, sProcessHsdUsed, sShopCode, sReadingUnit, sWithdrawnShift, sWithDrawnBy, sEnteredBy As String
        Dim lStartUpReading, lEndUpReading As Long
        Dim dHsdDate As Date
        Dim sHsdShift As String
        Dim tblHsdPoints As DataTable
        'Dim tblHsdPoints1 As DataTable
        Dim sLastRec As String
        Dim strCheckRec As String = " select @cnt = count(*) from mm_hsd_points where shopCode = @ShopCode and HsdPoint = @HsdPoint "
        Dim sHsdNewPoint, sNewProcessHsdUsed As String
        Dim iMultiPlyingFactor As Integer

         
        Dim strUpdateWithdrawal As String = " update mm_hsd_points set  WithDrawnDate = @WithDrawnDate, WithDrawnSaveDateTime = @WithDrawnSaveDateTime " & _
                            ", WithdrawnShift = @WithdrawnShift,  EndUpReading = @EndUpReading, WithDrawnBy = @WithDrawnBy  where " & _
                             " shopCode = @ShopCode and HsdPoint = @HsdPoint "


        Dim strUpdateHsdPoints As String = " update mm_hsd_points set MtrMultiplyFactor = @MultiPlyingFactor,  HsdPoint = @NewHsdPoint , InputDate = @HsdDate, InputShift= @HsdShift, startupDate = @StartUpDate, startUpShift = @StartUpShift " & _
                                  ", ProcessHsdUsed = @ProcessHsdUsed, ReadingUnit = @ReadingUnit, StartUpReading = @StartUpReading, " & _
                                  " EnteredBy = @EnteredBy, SaveDateTime = @SaveDateTime" & _
                                  " where " & _
                                  " shopCode = @ShopCode and HsdPoint = @HsdPoint"

        Dim strDeleteRec As String = "delete mm_hsd_points where shopCode = @ShopCode and HsdPoint = @HsdPoint"

        Dim strInsertHsdPoint As String = "insert into mm_hsd_points (MtrMultiplyFactor, InputDate, InputShift, HsdPoint,ShopCode,ProcessHsdUsed,ReadingUnit,StartUpDate,StartUpShift,StartUpReading," & _
        " WithDrawnDate,WithdrawnShift,WithDrawnBy,EndUpReading,WithDrawnSaveDateTime," & _
        " EnteredBy,SaveDateTime) " & _
        " values (@MultiPlyingFactor,@HsdDate, @HsdShift, @HsdPoint,@ShopCode,@ProcessHsdUsed,@ReadingUnit,@StartUpDate,@StartUpShift,@StartUpReading," & _
        " @WithDrawnDate, @WithdrawnShift,@WithDrawnBy,@EndUpReading,@WithDrawnSaveDateTime, " & _
        "@EnteredBy,@SaveDateTime)"

        Public Sub New(ByVal EmpCode As String, ByVal GroupCode As String)
            InitVars()
            sShopCode = ""
            sLogin = ""
            sEnteredBy = ""
            sHeader = ""
            tblHsdPoints = New DataTable()
            'tblHsdPoints1 = New DataTable()
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@CC", SqlDbType.VarChar, 4).Direction = ParameterDirection.Output
            cmd.Parameters.Add("@ShopCode", SqlDbType.VarChar, 2).Direction = ParameterDirection.Output
            cmd.CommandText = "select @CC = ltrim(rtrim(CC)), @ShopCode = ShopCode from mm_Hsd_ConsigneeCodes where Login = '" & GroupCode & "'"
            Try
                cmd.Connection.Open()
                cmd.ExecuteScalar()
                sLogin = cmd.Parameters("@CC").Value & ""
                sShopCode = cmd.Parameters("@ShopCode").Value & ""
                If sLogin <> "" Then
                    sHeader = "LPG & BMCG Consumption points for " & sLogin
                Else
                    sMessage = "No LPG & BMCG Consumption Points in your shop"
                    blnError = True
                End If
            Catch exp As Exception
                sMessage = exp.Message
                blnError = True
            Finally
                If IsNothing(cmd) = False Then
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                End If
            End Try
            If blnError Then
                Throw New Exception(sMessage)
            Else
                sEnteredBy = EmpCode
                DataTable()
            End If
        End Sub
        ReadOnly Property HsdPointsTable() As DataTable
            Get
                Return tblHsdPoints
            End Get
        End Property

        'ReadOnly Property HsdPointsTable1() As DataTable
        '    Get
        '        Return tblHsdPoints1
        '    End Get
        'End Property
        Private Sub DataTable()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "select MtrMultiplyFactor, InputDate, InputShift, HsdPoint, ShopCode, ProcessHsdUsed HsdUsedFor, StartUpReading, " & _
                    " ReadingUnit, StartUpDate, StartUpShift, StartUpReading, WithDrawnDate, WithdrawnShift, WithDrawnBy, EndUpReading, WithDrawnSaveDateTime " & _
                    " from mm_vw_hsdCurrentPoints where shopcode = @shopCode order by SaveDateTime "
            da.SelectCommand.Parameters.Add("@shopCode", SqlDbType.VarChar, 2).Value = sShopCode
            Dim ds As New DataSet()
            Try
                da.Fill(ds, "HsdPoints")
                tblHsdPoints = ds.Tables(0).Copy
                tblHsdPoints.TableName = "HsdPoints"
            Catch exp As Exception
                sMessage = "Hsd Points Collection Error : " & exp.Message
                Throw New Exception(sMessage)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Sub
        Private Sub InitVars()
            iMultiPlyingFactor = 0
            sHsdNewPoint = ""
            sMessage = ""
            blnError = False
            dStartUpDate = CDate("1/1/1900")
            dWithDrawnDate = CDate("1/1/1900")
            dWithDrawnSaveDateTime = CDate("1/1/1900")
            dSaveDateTime = CDate("1/1/1900")
            dHsdDate = CDate("1/1/1900")
            sHsdShift = ""
            sStartUpShift = ""
            sHsdPoint = ""
            sProcessHsdUsed = ""
            sReadingUnit = ""
            sWithdrawnShift = ""
            sWithDrawnBy = ""
            lStartUpReading = 0
            lEndUpReading = 0
            sNewProcessHsdUsed = ""
        End Sub
        Property MultiPlyingFactor() As Integer
            Get
                Return iMultiPlyingFactor
            End Get
            Set(ByVal Value As Integer)
                iMultiPlyingFactor = Value
            End Set
        End Property
        Property HsdDate() As Date
            Get
                Return dHsdDate
            End Get
            Set(ByVal Value As Date)
                If Value <= Now.Today.Date Then
                    dHsdDate = Value
                Else
                    sMessage = "Future Date : " & Value.Date.ToString
                    blnError = True
                    Throw New Exception(sMessage)
                End If
            End Set
        End Property
        Property HsdShift() As String
            Get
                Return sHsdShift
            End Get
            Set(ByVal Value As String)
                sHsdShift = Left(Value.ToUpper.Trim, 1)
            End Set
        End Property
        ReadOnly Property ScreenHeader() As String
            Get
                Return sHeader
            End Get
        End Property
        ReadOnly Property ShopCode() As String
            Get
                Return sShopCode
            End Get
        End Property
        WriteOnly Property HsdNewPoint() As String
            Set(ByVal Value As String)
                sHsdNewPoint = Value.ToUpper.Trim
                If sHsdPoint = "" Then
                    sHsdPoint = sHsdNewPoint
                End If
            End Set
        End Property
        WriteOnly Property NewProcessHsdUsed() As String
            Set(ByVal Value As String)
                sNewProcessHsdUsed = Value.ToUpper.Trim
            End Set
        End Property
        Property HsdPoint() As String
            Get
                Return sHsdPoint
            End Get
            Set(ByVal Value As String)
                sHsdPoint = Left(Value.ToUpper.Trim, 50)
                If sShopCode <> "" Then
                    GetData()
                End If
            End Set
        End Property
        Property ProcessHsdUsed() As String
            Get
                Return sProcessHsdUsed
            End Get
            Set(ByVal Value As String)
                sProcessHsdUsed = Left(Value.ToUpper.Trim, 50)
            End Set
        End Property
        Property ReadingUnit() As String
            Get
                Return sReadingUnit
            End Get
            Set(ByVal Value As String)
                sReadingUnit = Left(Value.ToUpper.Trim, 50)
            End Set
        End Property
        Property StartUpDate() As Date
            Get
                Return dStartUpDate
            End Get
            Set(ByVal Value As Date)
                dStartUpDate = Value
            End Set
        End Property
        Property StartUpShift() As String
            Get
                Return sStartUpShift
            End Get
            Set(ByVal Value As String)
                sStartUpShift = Left(Value.ToUpper.Trim, 1)
            End Set
        End Property
        Property StartUpReading() As Long
            Get
                Return lStartUpReading
            End Get
            Set(ByVal Value As Long)
                Try
                    Dim minRdg As Long = MinDlyReading()
                    If Value >= 0 AndAlso Value <= IIf(minRdg = 0, Value, minRdg) Then lStartUpReading = Value
                    minRdg = Nothing
                Catch exp As Exception
                    Throw New Exception(exp.Message)
                End Try
            End Set
        End Property
        Private Function MinDlyReading() As Long
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.CommandText = "select @MinMtrRdg = min(isnull(MtrReading,0)) from mm_hsd_points a left outer join mm_hsd_consumption b on a.hsdpoint = b.hsdpoint and a.shopcode = b.shopcode where a.hsdPoint = @HsdPoint and a.ShopCode = @ShopCode"
            oCmd.Parameters.Add("@HsdPoint", SqlDbType.VarChar, 50).Direction = ParameterDirection.Input
            oCmd.Parameters.Add("@ShopCode", SqlDbType.VarChar, 2).Direction = ParameterDirection.Input
            oCmd.Parameters.Add("@MinMtrRdg", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
            Try
                oCmd.Parameters("@HsdPoint").Value = sHsdPoint
                oCmd.Parameters("@ShopCode").Value = sShopCode
                oCmd.Connection.Open()
                oCmd.ExecuteScalar()
                MinDlyReading = IIf(IsDBNull(oCmd.Parameters("@MinMtrRdg").Value), -1, oCmd.Parameters("@MinMtrRdg").Value)
            Catch exp As Exception
                MinDlyReading = -1
                Throw New Exception("Min Reading Error : " & exp.Message)
            Finally
                If IsNothing(oCmd) = False Then
                    If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                    oCmd.Dispose()
                    oCmd = Nothing
                End If
            End Try
        End Function
        Property WithDrawnDate() As Date
            Get
                Return dWithDrawnDate
            End Get
            Set(ByVal Value As Date)
                dWithDrawnDate = Value
            End Set
        End Property
        Property WithdrawnShift() As String
            Get
                Return sWithdrawnShift
            End Get
            Set(ByVal Value As String)
                sWithdrawnShift = Left(Value.ToUpper.Trim, 1)
            End Set
        End Property
        Property WithDrawnBy() As String
            Get
                Return sWithDrawnBy
            End Get
            Set(ByVal Value As String)
                sWithDrawnBy = Left(Value.ToUpper.Trim, 6)
            End Set
        End Property
        ReadOnly Property LastRec() As String
            Get
                Return sLastRec
            End Get
        End Property
        Property EndUpReading() As Long
            Get
                Return lEndUpReading
            End Get
            Set(ByVal Value As Long)
                If Value >= 0 Then
                    lEndUpReading = Value
                Else
                    Throw New Exception("Invalid Endup Reading")
                End If

            End Set
        End Property
        Property Withdrawn() As Boolean
            Get
                Return blnWithdrawn
            End Get
            Set(ByVal Value As Boolean)
                blnWithdrawn = Value
            End Set
        End Property
        ReadOnly Property EnteredBy() As String
            Get
                Return sEnteredBy
            End Get
        End Property
        Private Sub GetData()
            Dim dv As New DataView()
            dv.Table = tblHsdPoints
            dv.RowFilter = "shopcode = '" & sShopCode & "' and hsdpoint = '" & sHsdPoint & "'"
            If dv.Count > 0 Then
                dWithDrawnDate = CDate(IIf(IsDBNull(dv(0)("WithDrawnDate")), "1/1/1900", dv(0)("WithDrawnDate")))
                dWithDrawnSaveDateTime = CDate(IIf(IsDBNull(dv(0)("WithDrawnSaveDateTime")), "1/1/1900", dv(0)("WithDrawnSaveDateTime")))
                sProcessHsdUsed = dv(0)("HsdUsedFor") & ""
                sReadingUnit = dv(0)("ReadingUnit") & ""
                sWithdrawnShift = dv(0)("WithdrawnShift") & ""
                sWithDrawnBy = dv(0)("WithDrawnBy") & ""
                lStartUpReading = IIf(IsDBNull(dv(0)("StartUpReading")), 0, dv(0)("StartUpReading"))
                lEndUpReading = IIf(IsDBNull(dv(0)("EndUpReading")), 0, dv(0)("EndUpReading"))
                dStartUpDate = dv(0)("StartUpDate")
                sStartUpShift = dv(0)("StartUpShift")
                iMultiPlyingFactor = IIf(IsDBNull(dv(0)("MtrMultiplyFactor")) = True, 0, dv(0)("MtrMultiplyFactor"))
                sLastRec = "Last Update: " & CDate(dv(0)("InputDate")).Date & " Shift : " & dv(0)("InputShift") & "'"
            Else
                InitVars()
                sLastRec = ""
            End If
            dv = Nothing
        End Sub
        ReadOnly Property Message() As String
            Get
                Return sMessage
            End Get
        End Property
        Public Sub Save(Optional ByVal Delete As Boolean = False)
            If iMultiPlyingFactor < 0 Then
                Throw New Exception("Multiplying factor is < 0 ")
                Exit Sub
            End If
            If sEnteredBy = "" Then
                Throw New Exception("Invalid User option")
                Exit Sub
            End If
            If sHsdPoint = "" Then
                Throw New Exception("Invalid HSD Point")
                Exit Sub
            End If
            If dStartUpDate.Date = CDate("1/1/1900") Then
                Throw New Exception("Invalid Startup Date")
                Exit Sub
            End If
            If sStartUpShift.IndexOfAny("ABC") < 0 Then
                Throw New Exception("Invalid Shift")
                Exit Sub
            End If
            If blnWithdrawn Then
                If dWithDrawnDate.Date = CDate("1/1/1900") Then
                    Throw New Exception("Invalid Startup Date")
                    Exit Sub
                End If
                If sWithdrawnShift.IndexOfAny("ABC") < 0 Then
                    Throw New Exception("Invalid Shift")
                    Exit Sub
                End If
                If sWithDrawnBy = "" Then
                    sWithDrawnBy = sEnteredBy
                    If sWithDrawnBy = "" Then
                        Throw New Exception("Invalid login")
                        Exit Sub
                    End If
                End If
            End If
            Dim blnNoErrors As Boolean
            '
            Dim ocmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                ocmd.Parameters.Add("@HsdPoint", SqlDbType.VarChar, 50).Value = sHsdPoint
                ocmd.Parameters.Add("@ShopCode", SqlDbType.VarChar, 2).Value = sShopCode
                ocmd.Parameters.Add("@ProcessHsdUsed", SqlDbType.VarChar, 50).Value = IIf(sNewProcessHsdUsed <> "", sNewProcessHsdUsed, sProcessHsdUsed)
                ocmd.Parameters.Add("@ReadingUnit", SqlDbType.VarChar, 50).Value = sReadingUnit
                ocmd.Parameters.Add("@StartUpDate", SqlDbType.SmallDateTime, 4).Value = dStartUpDate
                ocmd.Parameters.Add("@StartUpShift", SqlDbType.VarChar, 1).Value = sStartUpShift
                ocmd.Parameters.Add("@StartUpReading", SqlDbType.BigInt, 8).Value = lStartUpReading
                ocmd.Parameters.Add("@WithDrawnDate", SqlDbType.SmallDateTime, 4).Value = dWithDrawnDate
                ocmd.Parameters.Add("@WithdrawnShift", SqlDbType.VarChar, 1).Value = sWithdrawnShift
                ocmd.Parameters.Add("@WithDrawnBy", SqlDbType.VarChar, 6).Value = IIf(dWithDrawnDate > CDate("1/1/1900"), sEnteredBy, "")
                ocmd.Parameters.Add("@EndUpReading", SqlDbType.BigInt, 8).Value = lEndUpReading
                ocmd.Parameters.Add("@WithDrawnSaveDateTime", SqlDbType.DateTime, 8).Value = IIf(dWithDrawnDate > CDate("1/1/1900"), Now, CDate("1/1/1900"))
                ocmd.Parameters.Add("@EnteredBy", SqlDbType.VarChar, 6).Value = sEnteredBy
                ocmd.Parameters.Add("@SaveDateTime", SqlDbType.DateTime, 8).Value = Now
                ocmd.Parameters.Add("@HsdDate", SqlDbType.SmallDateTime, 4).Value = dHsdDate
                ocmd.Parameters.Add("@HsdShift", SqlDbType.VarChar, 1).Value = sHsdShift
                ocmd.Parameters.Add("@NewHsdPoint", SqlDbType.VarChar, 50).Value = IIf(sHsdNewPoint <> "", sHsdNewPoint, sHsdPoint)
                ocmd.Parameters.Add("@MultiPlyingFactor", SqlDbType.Int, 4).Value = iMultiPlyingFactor
                ocmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                ocmd.Connection.Open()
                ocmd.Transaction = ocmd.Connection.BeginTransaction
                ocmd.CommandText = strCheckRec
                ocmd.ExecuteScalar()
                If ocmd.Parameters("@cnt").Value > 0 Then
                    If Delete Then
                        ocmd.CommandText = strDeleteRec
                        If ocmd.ExecuteNonQuery > 0 Then
                            blnNoErrors = True
                        End If
                    Else
                        ocmd.CommandText = strUpdateHsdPoints
                        If ocmd.ExecuteNonQuery > 0 Then
                            If blnWithdrawn Then
                                ocmd.CommandText = strUpdateWithdrawal
                                If ocmd.ExecuteNonQuery > 0 Then
                                    blnNoErrors = True
                                End If
                            Else
                                blnNoErrors = True
                            End If
                        End If
                    End If
                Else
                    ocmd.CommandText = strInsertHsdPoint
                    If ocmd.ExecuteNonQuery > 0 Then
                        blnNoErrors = True
                    End If
                End If
            Catch exp As Exception
                sMessage = "Save Error : " & exp.Message
            Finally
                If IsNothing(ocmd) = False Then
                    If blnNoErrors = True Then
                        ocmd.Transaction.Commit()
                    Else
                        ocmd.Transaction.Rollback()
                    End If
                    If ocmd.Connection.State = ConnectionState.Open Then ocmd.Connection.Close()
                    ocmd.Dispose()
                    ocmd = Nothing
                End If
            End Try
            If blnNoErrors = False Then
                Throw New Exception(sMessage)
            Else
                DataTable()
                sMessage = IIf(Delete = False, "Saved", "Deleted")
            End If
            blnNoErrors = Nothing
        End Sub
    End Class
    Public Class HsdConsumption
        Dim dSaveDateTime As Date
        Dim sMessage, sRemarks As String
        Private odtshft As rwfGen.DateShift
        Private oMeter As HsdPoint
        Private oReadings As Readings
        Private oConsumptionDate As ConsumptionDateShift
        Private sConsumptionShift As String
        Private blnError As Boolean

        ReadOnly Property IsErr() As Boolean
            Get
                Return blnError
            End Get
        End Property
        ReadOnly Property Message() As String
            Get
                Return sMessage
            End Get
        End Property
        ReadOnly Property HsdPoint() As HsdPoint
            Get
                Return oMeter
            End Get
        End Property
        Private Function IsMeterWithdrawn() As Boolean
            If oConsumptionDate.ConsumptionDate = oMeter.WithDrawnDate Then
                If oConsumptionDate.ConsumptionShift > oMeter.WithdrawnShift Then
                    IsMeterWithdrawn = True
                End If
            ElseIf oConsumptionDate.ConsumptionDate > oMeter.WithDrawnDate AndAlso oMeter.WithDrawnDate > CDate("1/1/1900") Then
                IsMeterWithdrawn = True
            Else
                IsMeterWithdrawn = False
            End If
            If IsMeterWithdrawn = True Then
                Throw New Exception("Meter is withdrawn from : " & oMeter.WithDrawnDate.Date & " Shift : " & oMeter.WithdrawnShift & ".  No Data can be accepted after withdrawal")
            End If
        End Function
        WriteOnly Property SelectedHsdPoint() As String
            Set(ByVal Value As String)
                oMeter.HsdPoint = Value
                If IsMeterWithdrawn() = False Then
                    oReadings = New HSD_Data.Readings(oMeter, oConsumptionDate)
                End If
            End Set
        End Property
        ReadOnly Property DateShift() As ConsumptionDateShift
            Get
                Return oConsumptionDate
            End Get
        End Property
        WriteOnly Property ConsumptionDate() As Date
            Set(ByVal Value As Date)
                oConsumptionDate = New ConsumptionDateShift(odtshft, Value, odtshft.DefaultShift)
            End Set
        End Property
        Property Remarks() As String
            Get
                Return sRemarks
            End Get
            Set(ByVal Value As String)
                If Value <> "" Then
                    sRemarks = Left(Value.ToUpper.Trim, 50)
                Else
                    sRemarks = ""
                End If
            End Set
        End Property
        WriteOnly Property ConsumptionShift() As String
            Set(ByVal Value As String)
                If IsNothing(oConsumptionDate) Then
                    oConsumptionDate = New ConsumptionDateShift(odtshft, odtshft.DefaultDate, Value)
                Else
                    Dim dt As Date = oConsumptionDate.ConsumptionDate
                    oConsumptionDate = New ConsumptionDateShift(odtshft, dt, Value)
                End If
            End Set
        End Property
        ReadOnly Property Reading() As Readings
            Get
                Return oReadings
            End Get
        End Property
        Public Sub New(ByVal EmpCode As String, ByVal GroupCode As String)
            InitVars()
            Try
                odtshft = New rwfGen.DateShift("mm_hsd_Consumption", "HsdDate", "HsdDate")
                oConsumptionDate = New ConsumptionDateShift(odtshft, odtshft.DefaultDate, odtshft.DefaultShift)
                oMeter = New HSD_Data.HsdPoint(EmpCode, GroupCode)
                odtshft = New rwfGen.DateShift("mm_hsd_Consumption", "HsdDate", "HsdDate")
                oReadings = New HSD_Data.Readings(oMeter, oConsumptionDate)
            Catch exp As Exception
                Throw New Exception("Invalid Data to Proceed:" & exp.Message)
            End Try
        End Sub
        Private Sub InitVars()
            dSaveDateTime = CDate("1/1/1900")
            sMessage = ""
        End Sub
        Public Sub Save(Optional ByVal Delete As Boolean = False)
            Try
                If IsMeterWithdrawn() = True Then
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
            End Try
            Dim sCheckStr, sInsertStr, sUpdateStr, sDeleteStr As String
            sCheckStr = "Select @slNo = slNo from mm_hsd_consumption where HsdPoint = @HsdPoint and ShopCode = @ShopCode and  hsdDate = @HsdDate and hsdShift = @HsdShift "
            sInsertStr = "Insert into mm_hsd_consumption (HsdPoint, ShopCode, hsdDate, hsdShift, MtrReading, Consumption, Operator, SaveDateTime, Remarks ) values (@HsdPoint, @ShopCode, @hsdDate, @hsdShift, @MtrReading, @Consumption, @Operator, @SaveDateTime, @Remarks )"
            sUpdateStr = "Update mm_hsd_Consumption set HsdPoint = @HsdPoint, ShopCode = @ShopCode, hsdDate = @hsdDate, hsdShift = @hsdShift, MtrReading = @MtrReading, Consumption = @Consumption, Operator = @Operator, SaveDateTime = @SaveDateTime, Remarks = @Remarks  where slNo = @slNo"
            sDeleteStr = "Delete mm_hsd_Consumption where slNo = @slNo"
            Dim blnDone As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                oCmd.Parameters.Add("@HsdDate", SqlDbType.SmallDateTime, 4).Value = DateShift.ConsumptionDate
                oCmd.Parameters.Add("@HsdShift", SqlDbType.VarChar, 1).Value = DateShift.ConsumptionShift
                oCmd.Parameters.Add("@HsdPoint", SqlDbType.VarChar, 50).Value = oMeter.HsdPoint
                oCmd.Parameters.Add("@ShopCode", SqlDbType.VarChar, 2).Value = oMeter.ShopCode
                oCmd.Parameters.Add("@MtrReading", SqlDbType.BigInt, 8).Value = oReadings.Current
                oCmd.Parameters.Add("@Consumption", SqlDbType.BigInt, 8).Value = oReadings.Consumption
                oCmd.Parameters.Add("@Operator", SqlDbType.VarChar, 6).Value = oMeter.EnteredBy
                oCmd.Parameters.Add("@SaveDateTime", SqlDbType.DateTime, 8).Value = Now
                oCmd.Parameters.Add("@slNo", SqlDbType.BigInt, 8).Direction = ParameterDirection.InputOutput
                oCmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 50).Direction = ParameterDirection.InputOutput
                oCmd.Parameters("@slNo").Value = 0
                oCmd.Parameters("@Remarks").Value = sRemarks & ""
                oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                oCmd.CommandText = sCheckStr
                oCmd.ExecuteScalar()
                If oCmd.Parameters("@SlNo").Value > 0 Then
                    If Delete Then
                        oCmd.CommandText = sDeleteStr
                    Else
                        oCmd.CommandText = sUpdateStr
                    End If
                Else
                    If Delete = False Then
                        oCmd.CommandText = sInsertStr
                    End If
                End If
                If oCmd.ExecuteNonQuery > 0 Then
                    blnDone = True
                End If
            Catch exp As Exception
                If oCmd.Parameters("@SlNo").Value > 0 Then
                    If Delete Then
                        sMessage = "Delete Error : " & exp.Message
                    Else
                        sMessage = "Update Error : " & exp.Message
                    End If
                Else
                    sMessage = "Insert Error : " & exp.Message
                End If
                Throw New Exception(sMessage)
            Finally
                If IsNothing(oCmd) = False Then
                    If blnDone Then
                        oCmd.Transaction.Commit()
                        If oCmd.Parameters("@SlNo").Value > 0 Then
                            If Delete Then
                                sMessage = "Deleted"
                            Else
                                sMessage = "Updated"
                            End If
                        Else
                            sMessage = "Inserted"
                        End If
                    Else
                        oCmd.Transaction.Rollback()
                        If oCmd.Parameters("@SlNo").Value > 0 Then
                            If Delete Then
                                sMessage = " Delete failed"
                            Else
                                sMessage = " Update failed"
                            End If
                        Else
                            sMessage = " Nothing to do...?!"
                        End If
                    End If
                    If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                    oCmd.Dispose()
                    oCmd = Nothing
                End If
            End Try
            sCheckStr = Nothing
            sInsertStr = Nothing
            sUpdateStr = Nothing
            sDeleteStr = Nothing
            blnDone = Nothing
        End Sub
        Public Function HsdConsumptionTable() As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "Select * from mm_hsd_consumption where hsdPoint = @hsdPoint and shopCode = @ShopCode and hsddate = @HsdDate and hsdShift = @HsdShift order by slNo desc"
            da.SelectCommand.Parameters.Add("@HsdPoint", SqlDbType.VarChar, 50).Value = oMeter.HsdPoint
            da.SelectCommand.Parameters.Add("@HsdShift", SqlDbType.VarChar, 1).Value = DateShift.ConsumptionShift
            da.SelectCommand.Parameters.Add("@HsdDate", SqlDbType.SmallDateTime, 4).Value = DateShift.ConsumptionDate
            da.SelectCommand.Parameters.Add("@ShopCode", SqlDbType.VarChar, 50).Value = oMeter.ShopCode
            Dim ds As New DataSet()
            Try
                da.Fill(ds, "SavedRecs")
                HsdConsumptionTable = ds.Tables("SavedRecs").Copy
            Catch exp As Exception
                HsdConsumptionTable = Nothing
                Throw New Exception("Grid Population Error: " & exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
    End Class
    Public Class ConsumptionDateShift
        Private dConsumptionDate As Date
        Private sConsumptionShift As String
        Private dDefaultDate As Date
        Private sDefaultShift As String

        Public Sub New(ByVal odtshft As rwfGen.DateShift, ByVal ConsumptionDate As Date, ByVal ConsumptionShift As String)
            If ConsumptionDate > Today Then
                Throw New Exception("Future Date cannot be accepted")
            ElseIf ConsumptionDate = Today And ConsumptionShift > odtshft.DefaultShift Then
                Throw New Exception("Future Shift cannot be accepted")
            End If
            dDefaultDate = odtshft.DefaultDate
            sDefaultShift = odtshft.DefaultShift
            dConsumptionDate = ConsumptionDate
            sConsumptionShift = ConsumptionShift
        End Sub
        ReadOnly Property ConsumptionDate() As Date
            Get
                Return IIf(dConsumptionDate > CDate("1/1/1900"), dConsumptionDate, dDefaultDate)
            End Get
        End Property
        ReadOnly Property ConsumptionShift() As String
            Get
                If dConsumptionDate = dDefaultDate Then
                    If sConsumptionShift <= sDefaultShift Then
                        Return sConsumptionShift
                    Else
                        Return sDefaultShift
                    End If
                Else
                    Return sConsumptionShift
                End If
            End Get
        End Property
    End Class
    Public Class UpdateConsumption
        Private sHsdPoint As String
        Private sShopCode As String
        Public Sub New(ByVal HsdPoint As String, ByVal ShopCode As String)
            sHsdPoint = HsdPoint
            sShopCode = ShopCode
        End Sub
        Public Sub Calculate()
            Dim tblData As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "SELECT * FROM mm_vw_Hsd_MeterReadings where shopcode = @shopcode and  hsdpoint = @hsdpoint  order by  shopcode, hsdpoint, hsddate, hsdshift, slNo"
            da.SelectCommand.Parameters.Add("@HsdPoint", SqlDbType.VarChar, 50).Value = sHsdPoint
            da.SelectCommand.Parameters.Add("@shopcode", SqlDbType.VarChar, 50).Value = sShopCode
            Dim ds As New DataSet()
            Try
                da.Fill(ds)
                tblData = ds.Tables(0).Copy
                tblData.TableName = "HsdReadings"
            Catch exp As Exception
                tblData = Nothing
            Finally
                da.Dispose()
                ds.Dispose()
                ds = Nothing
                da = Nothing
            End Try
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.CommandText = "Update mm_hsd_consumption set Consumption = @Consumption where slNo = @slNo"
            cmd.Parameters.Add("@Consumption", SqlDbType.BigInt, 8).Direction = ParameterDirection.Input
            cmd.Parameters.Add("@SlNo", SqlDbType.BigInt, 8).Direction = ParameterDirection.Input
            Dim dr As DataRow
            Static lEndReading, lStartReading, lConsumption, lSlNo As Long
            Dim blnReadStart, blnReadEnd As Boolean
            Dim i As Integer
            i = 0
            For Each dr In tblData.Rows
                If blnReadStart = False Then
                    lStartReading = IIf(IsDBNull(dr("MtrReading")), 0, dr("MtrReading"))
                    blnReadStart = True
                ElseIf blnReadEnd = False Then
                    lEndReading = IIf(IsDBNull(dr("MtrReading")), 0, dr("MtrReading"))
                    lSlNo = IIf(IsDBNull(dr("SlNo")), 0, dr("SlNo"))
                    blnReadEnd = True
                End If

                If blnReadStart AndAlso blnReadEnd Then
                    If lEndReading = 0 Then
                        lStartReading = 0
                    End If
                    lConsumption = lEndReading - lStartReading
                    If lSlNo > 0 Then
                        cmd.Parameters("@Consumption").Value = lEndReading - lStartReading
                        cmd.Parameters("@SlNo").Value = lSlNo
                        Try
                            If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                            cmd.ExecuteNonQuery()
                        Catch exp As Exception
                            lSlNo = 0
                            Throw New Exception(exp.Message)
                        Finally
                            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                        End Try
                    End If
                    blnReadEnd = False
                    lConsumption = 0
                    lStartReading = lEndReading
                    lEndReading = 0
                    If lSlNo = 0 Then Exit For
                End If
            Next
            If IsNothing(cmd) = False Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End If
            If IsNothing(tblData) = False Then
                tblData.Dispose()
            End If
            dr = Nothing
            lEndReading = Nothing
            lStartReading = Nothing
            lConsumption = Nothing
            lSlNo = Nothing
            blnReadStart = Nothing
            blnReadEnd = Nothing
            i = Nothing
            tblData = Nothing
        End Sub
    End Class
    Public Class Readings
        Private lPrevReading, lNextReading, lConsumption, lCurrentReading As Long
        Private sPrevReadingShift, sPrevRdgShift As String
        Private dPrevRdgDt As Date

        Private Sub InitVars()
            lPrevReading = 0
            lNextReading = 0
            lCurrentReading = 0
            lConsumption = 0
            dPrevRdgDt = CDate("1/1/1900")
            sPrevRdgShift = ""
            lNextReading = 0
        End Sub
        ReadOnly Property PrevRdgShift() As String
            Get
                Return sPrevRdgShift
            End Get
        End Property
        ReadOnly Property PrevRdgDt() As Date
            Get
                Return dPrevRdgDt
            End Get
        End Property
        ReadOnly Property Consumption() As Long
            Get
                lConsumption = lCurrentReading - Previous
                If lConsumption < 0 Then
                    Throw New Exception("Illogical Metering Inputs detected")
                End If
                Return lConsumption
            End Get
        End Property
        ReadOnly Property Previous() As Long
            Get
                Return lPrevReading
            End Get
        End Property
        ReadOnly Property [Next]() As Long
            Get
                Return lNextReading
            End Get
        End Property
        Property Current() As Long
            Get
                Return lCurrentReading
            End Get
            Set(ByVal Value As Long)
                If Value >= 0 Then
                    If Value < lPrevReading Then
                        Throw New Exception("Not acceptable Cur Rdg since less than " & lPrevReading)
                    ElseIf Value > lNextReading And lNextReading <> Previous Then
                        Throw New Exception("Not acceptable Cur Rdg since more than " & lNextReading)
                    Else
                        lCurrentReading = Value
                    End If
                Else
                    Throw New Exception("Negative values cannot be accepted")
                End If
            End Set
        End Property
        Public Sub New(ByVal oMeter As HSD_Data.HsdPoint, ByVal oConsDtShift As ConsumptionDateShift)
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim dr As SqlClient.SqlDataReader
            Try
                oCmd.CommandText = "mm_sp_GetHsdPrevNextReadings"
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.Parameters.Add("@HsdDate", SqlDbType.SmallDateTime, 4).Value = oConsDtShift.ConsumptionDate
                oCmd.Parameters.Add("@HsdShift", SqlDbType.VarChar, 1).Value = oConsDtShift.ConsumptionShift
                oCmd.Parameters.Add("@HsdPoint", SqlDbType.VarChar, 50).Value = oMeter.HsdPoint
                oCmd.Parameters.Add("@ShopCode", SqlDbType.VarChar, 2).Value = oMeter.ShopCode
                oCmd.Connection.Open()
                dr = oCmd.ExecuteReader
                While dr.Read
                    lPrevReading = IIf(IsDBNull(dr("PrevReading")), 0, dr("PrevReading"))
                    lNextReading = IIf(IsDBNull(dr("NextReading")), 0, dr("NextReading"))
                    dPrevRdgDt = IIf(IsDBNull(dr("PrevRdgDt")), CDate("1/1/1900"), dr("PrevRdgDt"))
                    sPrevRdgShift = IIf(IsDBNull(dr("PrevRdgShift")), "", dr("PrevRdgShift"))
                End While
                If lNextReading = 0 Then
                    lNextReading = IIf(lPrevReading > lNextReading, lPrevReading, lNextReading)
                End If
            Catch exp As Exception
                Throw New Exception("Prev/Next Reading Error : " & exp.Message)
            Finally
                dr.Close()
                If IsNothing(oCmd) = False Then
                    If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                    oCmd.Dispose()
                    oCmd = Nothing
                End If
                dr = Nothing
            End Try
        End Sub
    End Class
    Public Class HsdPointReset
        'mm_Hsd_ConsumptionReset
        ' this table need not be populated.
        ' sysRemarks of mm_hsd_consumption will be updated by the Stored Procedure.
        ' Dropping of table has to be checked as it is having Referencial Integrity with 
        ' mm_hsd_consumption table.
        Private sMessage As String
        Private dResetDate As Date
        Private sResetShift As String
        Private sHsdPoint As String
        Private sShopCode As String
        Private blnDone As Boolean
        Private oHsdConsumption As HsdConsumption
        Private Sub InitVars()
            sMessage = Nothing
            blnDone = Nothing
            sHsdPoint = Nothing
            sShopCode = Nothing
        End Sub
        ReadOnly Property Done() As Boolean
            Get
                Return blnDone
            End Get
        End Property
        ReadOnly Property Message() As String
            Get
                Return sMessage
            End Get
        End Property
        Public Sub New(ByVal EmpCode As String, ByVal GroupCode As String, ByVal HsdPoint As String)
            Try
                InitVars()
                oHsdConsumption = New HsdConsumption(EmpCode, GroupCode)
                oHsdConsumption.SelectedHsdPoint = HsdPoint
                Reset()
            Catch exp As Exception
                Throw New Exception(exp.Message)
            End Try
        End Sub
        Private Sub Reset()
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.CommandText = "mm_sp_Hsd_Consumption_Reset"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@HsdPoint", SqlDbType.VarChar, 50).Value = oHsdConsumption.HsdPoint.HsdPoint
                cmd.Parameters.Add("@ShopCode", SqlDbType.VarChar, 50).Value = oHsdConsumption.HsdPoint.ShopCode
                sMessage = "Insufficient Data to reset"
                If oHsdConsumption.HsdPoint.HsdPoint = Nothing OrElse oHsdConsumption.HsdPoint.HsdPoint = "" Then
                    Throw New Exception("Insufficient Data to reset")
                End If
                If oHsdConsumption.HsdPoint.ShopCode = Nothing OrElse oHsdConsumption.HsdPoint.ShopCode = "" Then
                    Throw New Exception("Insufficient Data to reset")
                End If
                sMessage = ""
                cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                If cmd.ExecuteNonQuery > 0 Then blnDone = True
            Catch exp As Exception
                sMessage = exp.Message
            Finally
                If IsNothing(cmd) = False Then
                    If IsNothing(cmd.Transaction) = False Then
                        If blnDone Then
                            cmd.Transaction.Commit()
                            sMessage = "Reset Done"
                        Else
                            cmd.Transaction.Rollback()
                            sMessage &= ". Reset Not Done"
                        End If
                        If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                        cmd.Dispose()
                        cmd = Nothing
                    End If
                End If
            End Try
            If blnDone = False Then
                Throw New Exception(sMessage)
            End If
        End Sub
    End Class
End Namespace
