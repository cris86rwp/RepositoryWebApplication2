Namespace YardInsp
    Public Class Rejection
        Private sDefCodes, sLocCodes, sWheelStatus, sErrorMessage As String
        Private blnError As Boolean
        Public ReadOnly Property ErrStatus() As Boolean
            Get
                ErrStatus = blnError
            End Get
        End Property
        Public Sub New()
            getDefectCodes()
            getLocationCodes()
        End Sub
        Property WheelStatus() As String
            Get
                WheelStatus = sWheelStatus.ToUpper.Trim
            End Get
            Set(ByVal Value As String)
                validateWheelStatus(Value)
            End Set
        End Property
        ReadOnly Property Message()
            Get
                Return sErrorMessage
            End Get
        End Property
        Private Sub getDefectCodes()
            sDefCodes = ""
            Dim da As New SqlClient.SqlDataAdapter()
            da.SelectCommand = New SqlClient.SqlCommand()
            da.SelectCommand.Connection = rwfGen.Connection.ConObj
            da.SelectCommand.CommandText = "SELECT isnull(rej_code,'') rejcode  FROM mm_mmrjd_dump where location = 'WHEE' and respon = 'WHEE' and isnumeric(rej_code) = 1  "
            Dim ds As New DataSet()
            Try
                da.Fill(ds, "Rejcodes")
            Catch exp As Exception
                ds = Nothing
                ErrorMessage(exp.Message)
            Finally
                da.Dispose()
            End Try
            Dim row As DataRow
            For Each row In ds.Tables("Rejcodes").Rows
                sDefCodes &= Trim(row("RejCode")) & ","
            Next
            ds.Dispose()
            If sDefCodes <> "" Then sDefCodes = Left(sDefCodes.Trim, sDefCodes.Length - 1)
            da = Nothing
            ds = Nothing
            row = Nothing
        End Sub
        Private Sub getLocationCodes()
            sLocCodes = ""
            Dim da As New SqlClient.SqlDataAdapter()
            da.SelectCommand = New SqlClient.SqlCommand()
            da.SelectCommand.Connection = rwfGen.Connection.ConObj
            da.SelectCommand.CommandText = "SELECT Ltrim(Rtrim(wheel_spot_code)) as Code FROM mm_wheel_spots_codes"
            Dim ds As New DataSet()
            Try
                da.Fill(ds, "LocCodes")
            Catch exp As Exception
                ds = Nothing
                ErrorMessage(exp.Message)
            Finally
                da.Dispose()
            End Try
            Dim row As DataRow
            For Each row In ds.Tables("LocCodes").Rows
                sLocCodes &= Trim(row("Code")) & ","
            Next
            ds.Dispose()
            If sLocCodes <> "" Then sLocCodes = Left(sLocCodes.Trim, sLocCodes.Length - 1)
            da = Nothing
            ds = Nothing
            row = Nothing
        End Sub
        Private Sub ErrorMessage(ByVal msg As String, Optional ByVal warning As Boolean = False)
            sErrorMessage = msg
            If Not warning And msg <> "" Then
                blnError = True
                sWheelStatus = ""
            Else
                blnError = False
                sWheelStatus = sWheelStatus.ToUpper.Trim
            End If
        End Sub
        Private Sub validateWheelStatus(ByVal whlsts As String)
            If whlsts.Trim = "" Then
                ErrorMessage("Cannot be empty")
                Exit Sub
            End If
            If whlsts.ToLower = "xc8rht" Then
                ErrorMessage("Cannot give RHT status to wheel in Yard Inspection")
                Exit Sub
            End If
            whlsts = whlsts.ToUpper.Replace("XC", "")
            If Val(whlsts) = 0 Then
                ErrorMessage("No valid Rejection codes found after XC")
                Exit Sub
            End If
            Dim errmsgloc, errmsgdef, strSql, strInput As String
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
                    Exit Sub
                Else
                    blnError = False
                    sWheelStatus = strInput
                End If
                sWheelStatus = strInput
                If errmsgdef <> "" Then
                    ErrorMessage(errmsgdef)
                    Exit Sub
                End If
                If errmsgloc <> "" Then
                    ErrorMessage(errmsgloc)
                    Exit Sub
                End If
                ErrorMessage("")
                If Left(sWheelStatus.Trim.ToUpper, 2) = "16" Then
                    ErrorMessage("Cannot give UT rejection in Yard Inspection")
                End If
                If Left(sWheelStatus.Trim.ToUpper, 4) = "XC16" Then
                    ErrorMessage("Cannot give UT rejection in Yard Inspection")
                End If
                If Not (strInput Is Nothing) Then
                    sWheelStatus = "XC" + strInput.Trim
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
                strSql = exp.StackTrace
                ErrorMessage("Line : " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message)
            End Try
        End Sub
    End Class
End Namespace


