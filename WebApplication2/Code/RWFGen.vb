Namespace rwfGen
    Public Class ReportServer
        Shared Function ServerName() As String
            ServerName = "RWFAPP03"
        End Function
    End Class
    'Commented for db connection issue
    'Public Class Connection
    '    Shared Function ConString() As String
    '        ConString = ConfigurationSettings.AppSettings("con")
    '    End Function

    Public Class Connection
        Shared Function ConString() As String
            ConString = ConfigurationManager.ConnectionStrings("con").ConnectionString
        End Function

        Shared Function ConObj() As SqlClient.SqlConnection
            ConObj = New SqlClient.SqlConnection()
            ConObj.ConnectionString = Connection.ConString
        End Function
        Shared Function CmdObj(Optional ByVal TimeOutInSeconds As Integer = 600) As SqlClient.SqlCommand
            CmdObj = New SqlClient.SqlCommand()
            CmdObj.Connection = ConObj()
            CmdObj.CommandTimeout = TimeOutInSeconds
        End Function
        Shared Function Adapter(Optional ByVal TimeOutInSeconds As Integer = 600) As SqlClient.SqlDataAdapter
            Adapter = New SqlClient.SqlDataAdapter()
            Adapter.SelectCommand = CmdObj(TimeOutInSeconds)
            'Adapter.InsertCommand = CmdObj(TimeOutInSeconds)
            'Adapter.UpdateCommand = CmdObj(TimeOutInSeconds)
            'Adapter.DeleteCommand = CmdObj(TimeOutInSeconds)
        End Function
    End Class
    Public Class Employee
        Public Shared Function Check(ByVal EmpCode As String, ByVal GroupCode As String, Optional ByVal Application As String = "MMS") As Boolean
            Dim cmd As SqlClient.SqlCommand = Connection.CmdObj
            'cmd.CommandText = "Select count(*) from wap.dbo.menu_your_password_new a inner join (select employee_code from hr_employee_master where employee_code = '" & EmpCode & "' and convert(int,employee_status) <= 11) b on a.employee_code = b.employee_code where a.employee_code = '" & EmpCode & "' and a.group_Code = '" & GroupCode & "' and a.application = '" & Application & "' and isnull(a.active_flag,'') like '[1,Y,T]%'"
            cmd.CommandText = "Select count(*) from wap.dbo.menu_your_password_new where employee_code = '" & EmpCode & "' and group_Code = '" & GroupCode & "' and application = '" & Application & "'"
            Dim sMessage As String
            Try
                cmd.Connection.Open()
                If cmd.ExecuteScalar > 0 Then
                    Check = True
                    sMessage = ""
                Else
                    sMessage = "Invalid employee code for login : " & EmpCode & " for : " & GroupCode
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
            If sMessage <> "" Then
                Throw New Exception(sMessage)
            Else
                Return Check
            End If

        End Function
    End Class
    Public Class CalendarDay
        Public Shared Function IsHoliday(ByVal Dt As Date, ByVal Shop As String) As Boolean
            Dim cmd As SqlClient.SqlCommand = Connection.CmdObj
            cmd.CommandText = "Select count(*) from mm_calendar_dump where shop = '" & Shop & "' and date ='" & Format(Dt, "MM/dd/yyyy") & "'"
            Try
                cmd.Connection.Open()
                If cmd.ExecuteScalar > 0 Then
                    IsHoliday = True
                Else
                    IsHoliday = False
                End If
            Catch exp As Exception
                IsHoliday = Nothing
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shared Function CalendarMonths() As DataTable
            Dim sMonths() As String = {"", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"}
            Dim tblMonths As New DataTable()
            tblMonths.Columns.Add(New DataColumn("MonthName", System.Type.GetType("System.String")))
            tblMonths.Columns.Add(New DataColumn("MonthNo", System.Type.GetType("System.Int16")))
            Dim dr As DataRow
            Dim i As Integer
            For i = 1 To 12
                dr = tblMonths.NewRow
                dr("MonthName") = sMonths(i)
                dr("MonthNo") = i
                tblMonths.Rows.Add(dr)
            Next
            CalendarMonths = tblMonths
        End Function
        Public Shared Function YearList(Optional ByVal iPreviousYears As Int16 = 1, Optional ByVal iNextYears As Int16 = 1) As DataTable
            Dim tblYears As New DataTable()
            tblYears.Columns.Add(New DataColumn("Year", System.Type.GetType("System.Int16")))
            Dim i As Int16
            Dim dr As DataRow

            For i = Now.Year - iPreviousYears To Now.Year + iNextYears
                dr = tblYears.NewRow
                dr("Year") = i
                tblYears.Rows.Add(dr)
            Next
            YearList = tblYears
        End Function
    End Class
    Public Class DateShift
        Private dLastUpdtDate As Date
        Private sShift As String
        Private dDefaultDate As Date
        Public Sub New(ByVal TransactionTableName As String, ByVal DateFieldName As String, ByVal OrderByField As String)
            Dim cmd As SqlClient.SqlCommand = Connection.CmdObj
            cmd.CommandText = "Select top 1 @dt=" & DateFieldName & " from " & TransactionTableName & " order by " & OrderByField & " desc "
            cmd.Parameters.Add("@Dt", SqlDbType.SmallDateTime, 4)
            cmd.Parameters("@Dt").Direction = ParameterDirection.Output
            Try
                cmd.Connection.Open()
                cmd.ExecuteScalar()
                dLastUpdtDate = IIf(IsDBNull(cmd.Parameters("@Dt").Value), Now.Today.Date, cmd.Parameters("@Dt").Value)
            Catch exp As Exception
                dLastUpdtDate = Now.Today.Date
            Finally
                If IsNothing(cmd) = False Then
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                End If
            End Try
            dDefaultDate = Now.Today.Date
            Select Case Now.Hour
                Case 6 To 13
                    sShift = "A"
                Case 14 To 21
                    sShift = "B"
                Case Else
                    sShift = "C"
            End Select
            ' holiday date with any shift is admissible as shop works on holidays too.
            If sShift = "C" Then
                dDefaultDate = dLastUpdtDate
                Dim tmsp As New TimeSpan()
                tmsp = Now.Date.Today.Subtract(dDefaultDate)
                If tmsp.Days >= 1 Then
                    ' after midnight previous date
                    dDefaultDate = DateAdd(DateInterval.Day, -tmsp.Days, Now.Date)
                    dDefaultDate = DateAdd(DateInterval.Day, -1, Now.Date)
                Else
                    ' before midnight cur date
                    dDefaultDate = Now.Date
                End If
            Else
                dDefaultDate = Now.Date
            End If
        End Sub
        ReadOnly Property DefaultDate() As Date
            Get
                Return dDefaultDate
            End Get
        End Property
        ReadOnly Property DefaultShift() As String
            Get
                Return sShift
            End Get

        End Property
    End Class
    <Serializable()> Public Class ConvertToWords
        Private deciNumber As Double
        Private lLongInteger As Long
        Private iDecimals, iThousands, iHundreds, iTens, iTeens, iSingles, iLakhs, iCrores As Integer
        Private sSingles() As String = {"", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine"}
        Private sTens() As String = {"", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"}
        Private sTeens() As String = {"", "Eleven", "Twelve", "Thirteen", "Forteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "NineTeen"}
        Private sWords, sMinus, sRupees, sPaise As String
        Public Sub New(ByVal Number As Double)
            sWords = ""
            If CDbl(Math.Round(Number, 2)) <= CDbl(Math.Round(999999999.99, 2)) Then
            Else
                Throw New Exception("Unable to convert to words")
            End If
            Try
                If Number < 0 Then
                    sMinus = "(Minus) "
                    Number = Number * -1
                End If
                deciNumber = Number
                lLongInteger = Math.Floor(Number / 1)
                iDecimals = (Number - lLongInteger) * 100
                Distribute(lLongInteger)
                If lLongInteger > 0 Then
                    If lLongInteger > 1 Then
                        sRupees = "Rupees " & sWords
                    ElseIf lLongInteger = 1 Then
                        sRupees = "Rupee " & sWords
                    End If
                Else
                    sRupees = "Rupee Zero"
                End If
                sWords = ""
                Distribute(iDecimals)
                If iDecimals > 1 Then
                    If iDecimals > 1 Then
                        sPaise = " Paise " & sWords
                    ElseIf iDecimals = 1 Then
                        sPaise = " Paisa " & sWords
                    Else
                        sPaise = "Paisa Zero"
                    End If
                End If
                sWords = sRupees
                If sPaise <> "" Then
                    If sWords <> "" Then
                        sWords &= " and "
                    End If
                    sWords &= sPaise
                    sWords &= " only"
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
            End Try
        End Sub
        Private Sub Distribute(ByVal lLongInteger As Long)
            Dim lNo As Long
            iCrores = 0
            iLakhs = 0
            iHundreds = 0
            iTeens = 0
            iSingles = 0
            iTens = 0
            Try
                lNo = lLongInteger
                iCrores = Math.Floor(lNo / 10000000)
                lNo = lNo - (iCrores * 10000000)
                iLakhs = Math.Floor(lNo / 100000)
                lNo = lNo - (iLakhs * 100000)
                iThousands = Math.Floor(lNo / 1000)
                lNo = lNo - (iThousands * 1000)
                iHundreds = Math.Floor(lNo / 100)
                lNo = lNo - (iHundreds * 100)
                If lNo > 10 And lNo < 20 Then
                    iTeens = lNo - 10
                    lNo = lNo - (iTeens + 10)
                ElseIf lNo > 9 Then
                    iTens = Math.Floor(lNo / 10)
                    lNo = lNo - (iTens * 10)
                    iSingles = lNo
                Else
                    iTens = 0
                    iSingles = lNo
                End If
                If iCrores > 0 Then
                    If iCrores > 1 Then
                        sWords = TurnToWords(iCrores) & " Crores "
                    Else
                        sWords = TurnToWords(iCrores) & " Crore "
                    End If
                End If
                If iLakhs > 0 Then
                    If iLakhs > 1 Then
                        sWords &= TurnToWords(iLakhs) & " Lakhs "
                    Else
                        sWords &= TurnToWords(iLakhs) & " Lakhs "
                    End If
                End If
                If iThousands > 0 Then
                    sWords &= " " & TurnToWords(iThousands) & " Thousand "
                End If
                If iHundreds > 0 Then
                    sWords &= " " & TurnToWords(iHundreds) & " Hundred "
                End If
                If iTens > 0 Then
                    sWords &= " " & sTens(iTens)
                End If
                If iTeens > 0 Then
                    sWords &= " " & sTeens(iTeens)
                End If
                If iSingles > 0 Then
                    If iTens = 0 Then sWords &= " "
                    sWords &= sSingles(iSingles)
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
            End Try
            lNo = Nothing
        End Sub
        Private Function TurnToWords(ByVal no As Long) As String
            Select Case no
                Case 1
                    TurnToWords = sSingles(no)
                Case 2 To 9
                    TurnToWords = sSingles(no)
                Case 10, 20, 30, 40, 50, 60, 70, 80, 90
                    TurnToWords = sTens(Math.Floor(no / 10))
                Case 11 To 19
                    TurnToWords = sTeens(no - 10)
                Case Is < 100
                    TurnToWords = sTens(Math.Floor(no / 10))
                    TurnToWords &= sSingles(no Mod 10)
                Case Else
                    If no > 0 Then
                        TurnToWords = "** Over Flow **"
                    Else
                        TurnToWords = ""
                    End If
            End Select
        End Function
        ReadOnly Property Towards() As String
            Get
                Return (sMinus & sWords)
            End Get
        End Property
        Shared ReadOnly Property LimitationMessage() As String
            Get
                Return "[Convertion upto than (+/-) 99,99,99,999.99]"
            End Get
        End Property
    End Class
    Public Class CurrentShift
        ' to get currentTime for given shift eg A of 12/1/10 ShiftStart will return 12/01/2010 06:00:00
        Enum ShiftCode
            G
            A
            B
            C
        End Enum
        Enum Time
            ShiftStart
            ShiftEnd
        End Enum

        Private Sub New()
        End Sub
        Public Shared Function GetDateTimeForShift(ByVal sh As ShiftCode, ByVal ForTime As Time) As Date
            Dim ShiftAfromDate, ShiftAtoDate, ShiftBfromDate, ShiftBtoDate, ShiftCfromDate, ShiftCtoDate, ShiftGfromDate, ShiftGtoDate, dt As Date
            Select Case Now.Hour
                Case 6 To 23
                    dt = Now.Date
                Case Else
                    dt = Now.Date.AddDays(-1)
            End Select
            ShiftAfromDate = dt.Add(New TimeSpan(6, 0, 0))
            ShiftAtoDate = ShiftAfromDate.Add(New TimeSpan(7, 59, 59))
            ShiftBfromDate = dt.Add(New TimeSpan(14, 0, 0))
            ShiftBtoDate = ShiftBfromDate.Add(New TimeSpan(7, 59, 59))
            ShiftCfromDate = dt.Add(New TimeSpan(22, 0, 0))
            ShiftCtoDate = ShiftCfromDate.Add(New TimeSpan(7, 59, 59))
            ShiftGfromDate = dt.Add(New TimeSpan(8, 0, 0))
            ShiftGtoDate = ShiftGfromDate.Add(New TimeSpan(7, 59, 59))
            Select Case sh
                Case ShiftCode.A
                    If ForTime = Time.ShiftStart Then Return ShiftAfromDate
                    If ForTime = Time.ShiftEnd Then Return ShiftAtoDate
                Case ShiftCode.B
                    If ForTime = Time.ShiftStart Then Return ShiftBfromDate
                    If ForTime = Time.ShiftEnd Then Return ShiftBtoDate
                Case ShiftCode.C
                    If ForTime = Time.ShiftStart Then Return ShiftCfromDate
                    If ForTime = Time.ShiftEnd Then Return ShiftCtoDate
                Case ShiftCode.G
                    If ForTime = Time.ShiftStart Then Return ShiftGfromDate
                    If ForTime = Time.ShiftEnd Then Return ShiftGtoDate
                Case Else
                    Return CDate("1/1/1900")
            End Select
            ShiftAfromDate = Nothing
            ShiftAtoDate = Nothing
            ShiftBfromDate = Nothing
            ShiftBtoDate = Nothing
            ShiftCfromDate = Nothing
            ShiftCtoDate = Nothing
            ShiftGfromDate = Nothing
            ShiftGtoDate = Nothing
            dt = Nothing
        End Function
        Public Shared Function GetCurrentShift(Optional ByVal ConfirmShiftGByReturningG As Boolean = False) As String
            Dim ShiftAfromDate, ShiftAtoDate, ShiftBfromDate, ShiftBtoDate, ShiftCfromDate, ShiftCtoDate, ShiftGfromDate, ShiftGtoDate, dt As Date
            If Now.Hour < 24 And Now.Hour > 21 Then
                dt = Now.Date.AddDays(-1)
            Else
                dt = Now.Date
            End If
            ShiftAfromDate = dt.Add(New TimeSpan(6, 0, 0))
            ShiftAtoDate = ShiftAfromDate.Add(New TimeSpan(7, 59, 59))
            ShiftBfromDate = dt.Add(New TimeSpan(14, 0, 0))
            ShiftBtoDate = ShiftBfromDate.Add(New TimeSpan(7, 59, 59))
            ShiftCfromDate = dt.Add(New TimeSpan(22, 0, 0))
            ShiftCtoDate = ShiftCfromDate.Add(New TimeSpan(7, 59, 59))
            ShiftGfromDate = dt.Add(New TimeSpan(8, 0, 0))
            ShiftGtoDate = ShiftGfromDate.Add(New TimeSpan(7, 59, 59))
            If ConfirmShiftGByReturningG = False Then
                Select Case Now
                    Case ShiftAfromDate To ShiftAtoDate
                        Return "A"
                    Case ShiftBfromDate To ShiftBtoDate
                        Return "B"
                    Case ShiftCfromDate To ShiftCtoDate
                        Return "C"
                    Case Else
                        Return ""
                End Select
            Else
                Select Case Now
                    Case ShiftGfromDate To ShiftGtoDate
                        Return "G"
                    Case Else
                        Return ""
                End Select
            End If
            ShiftAfromDate = Nothing
            ShiftAtoDate = Nothing
            ShiftBfromDate = Nothing
            ShiftBtoDate = Nothing
            ShiftCfromDate = Nothing
            ShiftCtoDate = Nothing
            ShiftGfromDate = Nothing
            ShiftGtoDate = Nothing
            dt = Nothing
        End Function
    End Class
End Namespace