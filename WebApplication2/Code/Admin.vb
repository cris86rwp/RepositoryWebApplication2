Public Class Admin
    Public Shared Function TopPHLDate() As Date
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            cmd.Parameters.Add("@phl_Date", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output
            cmd.CommandText = "select top 1 @phl_Date = phl_Date from mm_PHL_Generation order by phl_Date desc"
            cmd.Connection.Open()
            cmd.ExecuteScalar()
            Return IIf(IsDBNull(cmd.Parameters("@phl_Date").Value), Now.Date, cmd.Parameters("@phl_Date").Value)
        Catch exp As Exception
            Return Now.Date
        Finally
            If IsNothing(cmd) = False Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End If
        End Try
    End Function
    Public Shared Function StockPosition() As DataSet
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        da.SelectCommand.CommandText = "Select * from dm_vw_gm_earItemsLessThan6MonthsStock ; " & _
                " Select * from dm_vw_gm_ItemIssuesMoreThan9MonthsEar "
        Dim ds As New DataSet()
        Try
            da.Fill(ds)
            StockPosition = ds.Copy
        Catch exp As Exception
            StockPosition = Nothing
            Throw New Exception(exp.Message)
        Finally
            da.Dispose()
            ds.Dispose()
            da = Nothing
            ds = Nothing
        End Try
    End Function
    Public Shared Function GetUploadedReports(ByVal Reports As String) As DataTable
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        da.SelectCommand.Parameters.Add("@ReportName", SqlDbType.VarChar, 6).Value = Reports + "%"
        da.SelectCommand.CommandText = "select ReportName from mm_UploadedReports " & _
            " where ReportName like @ReportName and ReportDate >= '2015-04-01' order by ReportDate desc"
        Dim ds As New DataSet()
        Try
            da.Fill(ds)
            GetUploadedReports = ds.Tables(0)
        Catch exp As Exception
            GetUploadedReports = Nothing
            Throw New Exception(exp.Message)
        Finally
            da.Dispose()
            ds.Dispose()
            da = Nothing
            ds = Nothing
        End Try
    End Function
    Public Shared Function strMsg() As String
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            cmd.Parameters.Add("@strMsg", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output
            cmd.CommandText = "select @strMsg = upper(proverb) from fm_scroll_msg where autonum = " & CInt(Rnd() * 100)
            cmd.Connection.Open()
            cmd.ExecuteScalar()
            Return IIf(IsDBNull(cmd.Parameters("@strMsg").Value), "", cmd.Parameters("@strMsg").Value)
        Catch exp As Exception
            Return ""
        Finally
            If IsNothing(cmd) = False Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End If
        End Try
    End Function
    Public Shared Function GetEmpDetails(ByVal employee_code As String, ByVal application As String, ByVal Group As String) As DataTable
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        Try
            da.SelectCommand.Parameters.Add("@Group", SqlDbType.VarChar, 50).Value = Group
            da.SelectCommand.Parameters.Add("@employee_code", SqlDbType.VarChar, 50).Value = employee_code
            da.SelectCommand.Parameters.Add("@application", SqlDbType.VarChar, 50).Value = application
            da.SelectCommand.CommandText = "select isnull(employee_name,'') , isnull(last_login_date,'') " & _
                " from mis.dbo.menu_your_password where application = @application and group_code = @Group and employee_code = @employee_code "
            da.Fill(ds)
            GetEmpDetails = ds.Tables(0)
        Catch exp As Exception
            GetEmpDetails = Nothing
            Throw New Exception(exp.Message)
        Finally
            da.Dispose()
            ds.Dispose()
            da = Nothing
            ds = Nothing
        End Try
    End Function
    Public Shared Function strOld(ByVal employee_code As String, ByVal application As String, ByVal Group As String) As String
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            cmd.Parameters.Add("@Group", SqlDbType.VarChar, 50).Value = Group
            cmd.Parameters.Add("@employee_code", SqlDbType.VarChar, 50).Value = employee_code
            cmd.Parameters.Add("@application", SqlDbType.VarChar, 50).Value = application
            cmd.Parameters.Add("@strOld", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            cmd.CommandText = "Select @strOld = password from mis.dbo.menu_your_password " & _
                " where employee_code = @employee_code and application = @application and group_code = @Group "
            cmd.Connection.Open()
            cmd.ExecuteScalar()
            Return IIf(IsDBNull(cmd.Parameters("@strOld").Value), "", cmd.Parameters("@strOld").Value)
        Catch exp As Exception
            Return ""
        Finally
            If IsNothing(cmd) = False Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End If
        End Try
    End Function
    Public Shared Function GetEmpCodes(ByVal app_code As String, ByVal group As String) As DataTable
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        Try
            da.SelectCommand.Parameters.Add("@app_code", SqlDbType.VarChar, 6).Value = app_code
            da.SelectCommand.Parameters.Add("@group", SqlDbType.VarChar, 10).Value = group
            da.SelectCommand.CommandText = "select rtrim(employee_code) employee_code from mis.dbo.menu_your_password " & _
                    " where application = @app_code and group_code = @group "
            da.Fill(ds)
            GetEmpCodes = ds.Tables(0)
        Catch exp As Exception
            GetEmpCodes = Nothing
            Throw New Exception(exp.Message)
        Finally
            da.Dispose()
            ds.Dispose()
            da = Nothing
            ds = Nothing
        End Try
    End Function
    Public Shared Function GetApplicationGroups(ByVal app_code As String) As DataTable
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        da.SelectCommand.Parameters.Add("@app_code", SqlDbType.VarChar, 6).Value = app_code
        da.SelectCommand.CommandText = "sp_GetApplicationGroups"
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        Dim ds As New DataSet()
        Try
            da.Fill(ds)
            GetApplicationGroups = ds.Tables(0)
        Catch exp As Exception
            GetApplicationGroups = Nothing
            Throw New Exception(exp.Message)
        Finally
            da.Dispose()
            ds.Dispose()
            da = Nothing
            ds = Nothing
        End Try
    End Function
    Public Shared Function GetApplications() As DataTable
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        da.SelectCommand.CommandText = "gen_GetApplications"
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        Dim ds As New DataSet()
        Try
            da.Fill(ds)
            GetApplications = ds.Tables(0)
        Catch exp As Exception
            GetApplications = Nothing
            Throw New Exception(exp.Message)
        Finally
            da.Dispose()
            ds.Dispose()
            da = Nothing
            ds = Nothing
        End Try
    End Function
    Public Shared Function ShopSection(ByVal shop As String) As DataTable
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        da.SelectCommand.Parameters.Add("@shop", SqlDbType.VarChar, 50).Value = shop
        da.SelectCommand.CommandText = "Select distinct ShopSection , Group_head from mis.dbo.menu_vw_EmpInGroups " & _
            " where shop = @shop "
        Dim ds As New DataSet()
        Try
            da.Fill(ds)
            ShopSection = ds.Tables(0)
        Catch exp As Exception
            ShopSection = Nothing
            Throw New Exception(exp.Message)
        Finally
            da.Dispose()
            ds.Dispose()
            da = Nothing
            ds = Nothing
        End Try
    End Function
    Public Shared Function GetShop(ByVal GroupHead As String) As String
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            cmd.Parameters.Add("@GroupHead", SqlDbType.VarChar, 50).Value = GroupHead
            cmd.Parameters.Add("@Shop", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            cmd.CommandText = "Select top 1 @Shop = Shop from mis.dbo.menu_vw_EmpInGroups " & _
                " where Group_head = @GroupHead "
            cmd.Connection.Open()
            cmd.ExecuteScalar()
            Return IIf(IsDBNull(cmd.Parameters("@Shop").Value), "", cmd.Parameters("@Shop").Value)
        Catch exp As Exception
            Return ""
        Finally
            If IsNothing(cmd) = False Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End If
        End Try
    End Function
    Public Shared Function EmpCodesShowGrid(ByVal rdoGroupCodes As String) As DataTable
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        da.SelectCommand.CommandText = "select employee_code, Employee_name " & _
            " from mis.dbo.menu_vw_EmpInGroups where application = 'MMS' and  group_code = '" & rdoGroupCodes & "' " & _
            " order by Employee_code"
        Dim ds As New DataSet()
        Try
            da.Fill(ds)
            EmpCodesShowGrid = ds.Tables(0)
        Catch exp As Exception
            EmpCodesShowGrid = Nothing
        Finally
            da.Dispose()
            ds.Dispose()
            da = Nothing
            ds = Nothing
        End Try
    End Function
    Public Shared Function GetGroupCodes(ByVal rdoShops As String) As DataTable
        Dim ds As New DataSet()
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        da.SelectCommand.Parameters.Add("@rdoShops", SqlDbType.VarChar, 50).Value = rdoShops
        da.SelectCommand.CommandText = "Select distinct Group_Code from menu_group_leaders where group_head = @rdoShops" & _
            " AND Group_Code NOT IN ( SELECT Group_code FROM mm_vw_MMSMenuGroupsNotInUse ) "
        Try
            da.Fill(ds)
            GetGroupCodes = ds.Tables(0).Copy
        Catch exp As Exception
            GetGroupCodes = Nothing
        Finally
            da.Dispose()
            ds.Dispose()
            da = Nothing
            ds = Nothing
        End Try
    End Function
    Public Shared Function CheckEmpCode(ByVal rdoGroupCodes As String, ByVal EmpCode As String, Optional ByVal Delete As Boolean = False) As String
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.CommandText = " select count(*) from mis.dbo.menu_vw_group_leaders where employee_code = '" & EmpCode & "'"
        Try
            cmd.Connection.Open()
            If cmd.ExecuteScalar > 0 Then
                Return " You cannot add/delete Emp Code : " & EmpCode
            Else
                cmd.CommandText = "select count(*) from mis.dbo.menu_your_password " & _
                        " where application = 'MMS' and group_code = '" & rdoGroupCodes & "' and employee_code = '" & EmpCode & "'"
                If cmd.ExecuteScalar > 0 Then
                    If Delete = False Then
                        Return "Emp Code already exists : " & EmpCode & " . To ReInstate , first delete from grid below and then Add again !"
                    End If
                Else
                    If Delete Then
                        Return "Emp Code does not exist : " & EmpCode
                    End If
                End If
            End If
        Catch exp As Exception
            Return "You cannot add Emp Code : " & EmpCode & " Prog.Error : " & exp.Message
        Finally
            If IsNothing(cmd) = False Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End If
        End Try
        Return EmpCode
    End Function
    Public Shared Function SuperPanel(ByVal Group As String, ByVal GroupCodes As String) As Boolean
        Dim blnOpenSuperPnl As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            cmd.CommandText = "Select count(*) from mis.dbo.menu_vw_EmpInGroups where Group_head = '" & Group & "' and group_code = '" & GroupCodes & "'"
            cmd.Connection.Open()
            Dim i As Integer
            i = cmd.ExecuteScalar
            If IsNothing(i) OrElse IsDBNull(i) Then
                i = 0
            End If
            blnOpenSuperPnl = i > 0
            i = Nothing
        Catch exp As Exception
            blnOpenSuperPnl = False
        Finally
            If IsNothing(cmd) = False Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End If
        End Try
        Return blnOpenSuperPnl
    End Function
    Public Shared Function SuperPanelVisible(ByVal GroupHead As String, ByVal GroupCode As String) As Boolean
        Dim blnOpenSuperPnl As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            cmd.Parameters.Add("@GroupHead", SqlDbType.VarChar, 50).Value = GroupHead
            cmd.Parameters.Add("@GroupCode", SqlDbType.VarChar, 50).Value = GroupCode
            cmd.CommandText = "Select count(*) from mis.dbo.menu_vw_EmpInGroups " & _
                " where Group_head = @GroupHead and group_code = @GroupCode "
            cmd.Connection.Open()
            Dim i As Integer
            i = cmd.ExecuteScalar
            If IsNothing(i) OrElse IsDBNull(i) Then
                i = 0
            End If
            blnOpenSuperPnl = i > 0
            i = Nothing
        Catch exp As Exception
            blnOpenSuperPnl = False
        Finally
            If IsNothing(cmd) = False Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End If
        End Try
        Return blnOpenSuperPnl
    End Function
    Public Shared Function GetGroupCode(ByVal Application As String) As DataTable
        Dim ds As New DataSet()
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        da.SelectCommand.Parameters.Add("@Application", SqlDbType.VarChar, 50).Value = Application
        da.SelectCommand.CommandText = "select distinct group_code from menu_group_application where application = @Application order by group_code"
        Try
            da.Fill(ds)
            GetGroupCode = ds.Tables(0).Copy
        Catch exp As Exception
            GetGroupCode = Nothing
        Finally
            da.Dispose()
            ds.Dispose()
            da = Nothing
            ds = Nothing
        End Try
    End Function
    Public Shared Function GetProgramID(ByVal ApplicationName As String, ByVal PrgName As String, ByVal PathName As String) As Integer
        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        oCmd.CommandText = "Select @ProgramId = dbo.mn_fn_GetProgramID('" & ApplicationName & "', '" & PrgName & "','" & PathName & "')"
        oCmd.Parameters.Add("@ProgramID", SqlDbType.Int, 4)
        oCmd.Parameters("@ProgramID").Direction = ParameterDirection.Output
        Try
            oCmd.Connection.Open()
            oCmd.ExecuteScalar()
            GetProgramID = IIf(IsDBNull(oCmd.Parameters("@ProgramID").Value), 0, oCmd.Parameters("@ProgramID").Value)
        Catch exp As Exception
            GetProgramID = 0
        Finally
            If IsNothing(oCmd) = False Then
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End If
        End Try
    End Function
    Public Function RemoveUserId(ByVal Application As String, ByVal Group As String, ByVal Empcode As String) As String
        Dim sqlcmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        sqlcmd.CommandText = "Select count(*) from mis.dbo.menu_your_password where application = '" & Application.Trim & "' and group_code = '" & Group.Trim & "' and employee_code = '" & Empcode.Trim & "'"
        Try
            sqlcmd.Connection.Open()
            If sqlcmd.ExecuteScalar = 0 Then
                Return "Employee does not exist in " & Group.Trim & " of " & Application.Trim
            Else
                sqlcmd.CommandText = "delete mis.dbo.menu_your_password where application = '" & Application.Trim & "' and  group_code = '" & Group.Trim & "' and employee_code = '" & Empcode.Trim & "'"
                sqlcmd.ExecuteNonQuery()
                sqlcmd.CommandText = "Select count(*) from mis.dbo.menu_your_password where application = '" & Application.Trim & "' and group_code = '" & Group.Trim & "' and employee_code = '" & Empcode.Trim & "'"
                If sqlcmd.ExecuteScalar = 0 Then
                    Return "Deleted Employee " & Empcode.Trim & " to " & Group.Trim & " in " & Application.Trim & " application"
                Else
                    Return "Delete Failed"
                End If
            End If
        Catch exp As Exception
            Return exp.Message
        Finally
            If sqlcmd.Connection.State = ConnectionState.Open Then sqlcmd.Connection.Close()
            sqlcmd.Dispose()
            sqlcmd = Nothing
        End Try
    End Function
    Public Function AddUserId(ByVal Application As String, ByVal Group As String, ByVal Empcode As String) As String
        Dim sqlcmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        sqlcmd.CommandText = "Select count(*) from mis.dbo.menu_your_password " & _
            " where application = '" & Application.Trim & "' and group_code = '" & Group.Trim & "' and employee_code = '" & Empcode.Trim & "'"
        Try
            sqlcmd.Connection.Open()
            If sqlcmd.ExecuteScalar > 0 Then
                sqlcmd.CommandText = "update mis.dbo.menu_your_password set password = employee_code where application  = '" & Application.Trim & "' and group_code = '" & Group.Trim & "' and employee_code = '" & Empcode.Trim & "'"
                sqlcmd.ExecuteNonQuery()
                sqlcmd.CommandText = "Select count(*) from mis.dbo.menu_your_password where application = '" & Application.Trim & "' and group_code = '" & Group.Trim & "' and employee_code = '" & Empcode.Trim & "'"
                If sqlcmd.ExecuteScalar > 0 Then
                    Return "Updated password as Employee code"
                Else
                    Return "Updation Failed"
                End If
            Else
                sqlcmd.CommandText = "select ltrim(employee_name) from wap.dbo.hr_employee_master where employee_code = '" & Empcode.Trim & "' and employee_status <= '10'"
                Dim empname As String
                empname = sqlcmd.ExecuteScalar
                If IsDBNull(empname) OrElse IsNothing(empname) Then
                    empname = ""
                End If
                If empname <> "" Then
                    sqlcmd.CommandText = "Insert into mis.dbo.menu_your_password (application, group_code, employee_code, password, active_flag, employee_name) values ('" & Application.Trim & "','" & Group.Trim & "', '" & Empcode.Trim & "','" & Empcode.Trim & "',1, '" & empname & "')"
                    sqlcmd.ExecuteNonQuery()
                    sqlcmd.CommandText = "Select count(*) from mis.dbo.menu_your_password where application = '" & Application.Trim & "' and group_code = '" & Group.Trim & "' and employee_code = '" & Empcode.Trim & "'"
                    If sqlcmd.ExecuteScalar > 0 Then
                        Return "Added Employee " & Empcode.Trim & " to " & Group.Trim & " in " & Application.Trim & " application"
                    Else
                        Return "Add Failed"
                    End If
                Else
                    Return "Invalid Employee Code"
                End If
            End If
        Catch exp As Exception
            Return exp.Message
        Finally
            If sqlcmd.Connection.State = ConnectionState.Open Then sqlcmd.Connection.Close()
            sqlcmd.Dispose()
            sqlcmd = Nothing
        End Try
    End Function
    Public Function DeleteUserId(ByVal GroupCodes As String, ByVal employee_code As String) As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Dim blnDeleted As Boolean
        Try
            cmd.Parameters.Add("@GroupCodes", SqlDbType.VarChar, 50).Value = GroupCodes
            cmd.Parameters.Add("@employee_code", SqlDbType.VarChar, 50).Value = employee_code
            cmd.CommandText = "Delete mis.dbo.menu_your_password where application = 'mms' " & _
                " and group_code = @GroupCodes and employee_code = @employee_code"
            cmd.Connection.Open()
            If cmd.ExecuteNonQuery > 0 Then blnDeleted = True
        Catch exp As Exception
            Throw New Exception("Delete Error : " & exp.Message)
        Finally
            If IsNothing(cmd) = False Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End If
        End Try
        Return blnDeleted
    End Function
    Public Function AddUserId(ByVal GroupCodes As String, ByVal employee_code As String) As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Dim blnDeleted As Boolean
        Try
            cmd.Parameters.Add("@GroupCodes", SqlDbType.VarChar, 50).Value = GroupCodes
            cmd.Parameters.Add("@employee_code", SqlDbType.VarChar, 50).Value = employee_code
            cmd.CommandText = "Insert into mis.dbo.menu_your_password " & _
                " ( application , group_code , employee_code , Password , employee_name , active_flag )   " & _
                " select 'MMS', @GroupCodes , @employee_code , @employee_code , employee_name , 'Y' " & _
                " from hr_employee_master where employee_code =  @employee_code"
            cmd.Connection.Open()
            If cmd.ExecuteNonQuery > 0 Then blnDeleted = True
        Catch exp As Exception
            Throw New Exception("Delete Error : " & exp.Message)
        Finally
            If IsNothing(cmd) = False Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End If
        End Try
        Return blnDeleted
    End Function
    Public Function UpdatePassword(ByVal NewPassword As String, ByVal employee_code As String, ByVal application As String, ByVal Group As String) As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Dim blnUpdate As Boolean
        Try
            cmd.Parameters.Add("@Group", SqlDbType.VarChar, 50).Value = Group
            cmd.Parameters.Add("@employee_code", SqlDbType.VarChar, 50).Value = employee_code
            cmd.Parameters.Add("@application", SqlDbType.VarChar, 50).Value = application
            cmd.Parameters.Add("@NewPassword", SqlDbType.VarChar, 50).Value = NewPassword
            cmd.CommandText = "update mis.dbo.menu_your_password set password = @NewPassword , " & _
                " Last_login_date = getdate(), assigned_date = getdate() " & _
                " where employee_code = @employee_code and application = @application and group_code = @Group "
            cmd.Connection.Open()
            If cmd.ExecuteNonQuery > 0 Then blnUpdate = True
        Catch exp As Exception
            Throw New Exception("Updation Error : " & exp.Message)
        Finally
            If IsNothing(cmd) = False Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End If
        End Try
        Return blnUpdate
    End Function
    Public Function UploadReport(ByVal Employee_code As String, ByVal ReportType As String, ByVal ReportFileNameWithPath As String) As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Dim blnUpdate As Boolean
        Try
            cmd.Parameters.Add("@Employee_code", SqlDbType.VarChar, 6).Value = Employee_code
            cmd.Parameters.Add("@ReportType", SqlDbType.VarChar, 50).Value = ReportType
            cmd.Parameters.Add("@ReportFileNameWithPath", SqlDbType.VarChar, 500).Value = ReportFileNameWithPath
            cmd.Parameters.Add("@UploadedDateTime", SqlDbType.DateTime, 8).Value = Now
            cmd.CommandText = "Insert into mm_uploaded_reports (Employee_code, ReportType, ReportFileNameWithPath, UploadedDateTime) " & _
                " values (@Employee_code, @ReportType, @ReportFileNameWithPath, @UploadedDateTime)  "
            cmd.Connection.Open()
            If cmd.ExecuteNonQuery > 0 Then blnUpdate = True
        Catch exp As Exception
            Throw New Exception("Upload Error : " & exp.Message)
        Finally
            If IsNothing(cmd) = False Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End If
        End Try
        Return blnUpdate
    End Function
    Public Function UploadReportName(ByVal ReportName As String, ByVal ReportDate As Date) As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Dim blnUpdate As Boolean
        Try
            cmd.Parameters.Add("@ReportName", SqlDbType.VarChar, 50).Value = ReportName
            cmd.Parameters.Add("@ReportDate", SqlDbType.SmallDateTime, 4).Value = ReportDate
            cmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            cmd.CommandText = "select @cnt = count(*) from mm_UploadedReports where ReportName = @ReportName"
            If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
            cmd.ExecuteScalar()
            If IIf(IsDBNull(cmd.Parameters("@cnt").Value), 0, cmd.Parameters("@cnt").Value) = 0 Then
                cmd.CommandText = "Insert into mm_UploadedReports (ReportName , ReportDate ) " & _
                                " values (@ReportName , @ReportDate )  "
                If cmd.ExecuteNonQuery > 0 Then blnUpdate = True
            Else
                blnUpdate = True
            End If
        Catch exp As Exception
            Throw New Exception("Upload Error : " & exp.Message)
        Finally
            If IsNothing(cmd) = False Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End If
        End Try
        Return blnUpdate
    End Function
End Class
