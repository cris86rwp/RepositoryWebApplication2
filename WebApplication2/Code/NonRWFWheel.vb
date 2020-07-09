Public Class NonRWFWheel
    Public Shared Function CheckWhl(ByVal NonRWFWheelNumber As String) As Integer
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            cmd.Connection.Open()
            cmd.Parameters.Add("@WhlCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            cmd.CommandText = "Select @WhlCount = count(*) from mm_nonRwf_Wheels where NonRWFWheelNumber = '" & NonRWFWheelNumber.Trim & "' and location <> 'CLFI'"
            cmd.ExecuteScalar()
            CheckWhl = IIf(IsDBNull(cmd.Parameters("@WhlCount").Value), 0, cmd.Parameters("@WhlCount").Value)
        Catch exp As Exception
            CheckWhl = 0
            Throw New Exception(exp.Message)
        Finally
            cmd.Dispose()
            cmd = Nothing
        End Try
    End Function
    Public Shared Function RWFNumDetails(ByVal RWFNumber As Integer) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "Select Description, NonRWFWheelNumber, thread_diameter, " & _
         " rwfNumber, isnull(press_status,'') Press_status from mm_nonrwf_wheels " & _
         " where RWFNumber = '" & RWFNumber & "'"""
        Try
            oDa.Fill(oDs)
            RWFNumDetails = oDs.Tables(0).Copy
        Catch exp As Exception
            RWFNumDetails = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
            oDa = Nothing
            oDs = Nothing
        End Try
    End Function
    Public Shared Function PopulateGrid(ByVal DateAccepted As Date) As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.Parameters.Add("@DateAccepted", SqlDbType.SmallDateTime, 4).Value = DateAccepted
        oDa.SelectCommand.CommandText = "Select NonRWFWheelNumber wheel, RWFNumber , thread_diameter, sl_no " & _
            " from mm_nonRwf_Wheels where DateAccepted = @DateAccepted order by sl_no desc"
        Try
            oDa.Fill(oDs)
            PopulateGrid = oDs.Tables(0).Copy
        Catch exp As Exception
            PopulateGrid = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
            oDa = Nothing
            oDs = Nothing
        End Try
    End Function
    Public Shared Function Products() As DataTable
        Dim oDs As New DataSet()
        Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        oDa.SelectCommand.CommandText = "select left(Description,4) Descr, Product_code from mm_product_master where product_code like '[1,2]%'"
        Try
            oDa.Fill(oDs)
            Products = oDs.Tables(0).Copy
        Catch exp As Exception
            Products = Nothing
            Throw New Exception(exp.Message)
        Finally
            oDa.Dispose()
            oDs.Dispose()
            oDa = Nothing
            oDs = Nothing
        End Try
    End Function
    Public Function DeleteWhl(ByVal NonRWFWheelNumber As String) As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            cmd.Connection.Open()
            cmd.CommandText = "delete mm_nonrwf_wheels where NonRWFWheelNumber = '" & NonRWFWheelNumber & "'"
            cmd.ExecuteNonQuery()
            DeleteWhl = True
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            cmd.Dispose()
            cmd = Nothing
        End Try
    End Function
    Public Function SaveWhl(ByVal NonRWFWheelNumber As String, ByVal CastType As String, ByVal Source As String, ByVal RWFNUmber As Integer, ByVal Status As String, ByVal FinalInsp As String, ByVal Products As String, ByVal BoreStatus As String, ByVal BoreDia As String, ByVal RimThickness As String, ByVal TreadDia As String, ByVal PlateThickness As String, ByVal AccDate As Date, ByVal ProductCode As String) As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Dim sqlstr As String
        Try
            cmd.Connection.Open()
            cmd.Parameters.Add("@WhlCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            cmd.CommandText = "Select @WhlCount = count(*) from mm_nonRwf_Wheels where NonRWFWheelNumber = '" & NonRWFWheelNumber.Trim & "' and location <> 'CLFI'"
            cmd.ExecuteScalar()
            If IIf(IsDBNull(cmd.Parameters("@WhlCount").Value), 0, cmd.Parameters("@WhlCount").Value) > 0 Then
                sqlstr = "update mm_nonRwf_Wheels set "
                sqlstr &= "ForgedCastWheel= '" & CastType & "',"
                sqlstr &= "NOnRWFSource = '" & Source & "',"
                sqlstr &= "RWFNumber = '" & RWFNUmber & "',"
                sqlstr &= "NonRWFWheelNumber = '" & NonRWFWheelNumber & "',"
                sqlstr &= "status = '" & Status & "',"
                sqlstr &= "InspectorFinal= '" & FinalInsp & "',"
                sqlstr &= "description = '" & Products & "',"
                sqlstr &= "bore_status = '" & BoreStatus & "',"
                sqlstr &= "bore_diameter = '" & BoreDia & "',"
                sqlstr &= "rim_thickness = '" & RimThickness & "',"
                sqlstr &= "thread_diameter = '" & TreadDia & "',"
                sqlstr &= "plate_thickness = '" & PlateThickness & "',"
                sqlstr &= "dateAccepted  = '" & CDate(AccDate) & "',"
                sqlstr &= "location_date = '" & CDate(AccDate) & "',"
                sqlstr &= "location = 'CLFI', "
                sqlstr &= "product_code = '" & ProductCode & "'"
                sqlstr &= " where NonRWFWheelNumber = '" & NonRWFWheelNumber & "'"
            Else
                sqlstr = "Insert into mm_nonRwf_Wheels ( "
                sqlstr &= "ForgedCastWheel, NOnRWFSource, "
                sqlstr &= "NonRWFWheelNumber, "
                sqlstr &= "RWFNumber, "
                sqlstr &= "status, "
                sqlstr &= "InspectorFinal, "
                sqlstr &= "description,"
                sqlstr &= "bore_status, "
                sqlstr &= "bore_diameter, "
                sqlstr &= "rim_thickness, "
                sqlstr &= "thread_diameter, "
                sqlstr &= "plate_thickness, "
                sqlstr &= "dateAccepted, "
                sqlstr &= "location_date, "
                sqlstr &= "location, "
                sqlstr &= "product_code ) values ( "
                sqlstr &= "'" & CastType & "',"
                sqlstr &= "'" & Source & "',"
                sqlstr &= "'" & NonRWFWheelNumber & "',"
                sqlstr &= "'" & RWFNUmber & "',"
                sqlstr &= "'" & Status & "',"
                sqlstr &= "'" & FinalInsp & "',"
                sqlstr &= "'" & Products & "',"
                sqlstr &= "'" & BoreStatus & "',"
                sqlstr &= "'" & BoreDia & "',"
                sqlstr &= "'" & RimThickness & "',"
                sqlstr &= "'" & TreadDia & "',"
                sqlstr &= "'" & PlateThickness & "',"
                sqlstr &= "'" & CDate(AccDate) & "',"
                sqlstr &= "'" & CDate(AccDate) & "',"
                sqlstr &= "'CLFI',"
                sqlstr &= "'" & ProductCode & "')"
            End If
            If cmd.ExecuteNonQuery() > 0 Then SaveWhl = True
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            cmd.Dispose()
            cmd = Nothing
        End Try
    End Function
End Class
