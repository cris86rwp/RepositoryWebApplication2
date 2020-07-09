Namespace RWF
    <Serializable()> Public Class BreakDown
#Region " Tables"
        Public Shared Function PopulateMemoNumber(ByVal Group As String, ByVal Shop As String, Optional ByVal ExtendedEdit As Boolean = False) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@Group", SqlDbType.VarChar, 10).Value = Group.Trim
                da.SelectCommand.Parameters.Add("@Shop", SqlDbType.VarChar, 10).Value = Shop.Trim
                If ExtendedEdit = False Then
                    If Group = "WHLMLT" Then
                        da.SelectCommand.CommandText = "select  breakdown_from_time BDFromTime , machine_code MCcode,  memo_number MemoNum, " & _
                            " memo_slip_number MemoSlipNum ,  remarks Remarks , operator , production_affected ProdAffec " & _
                            " , breakdown_to_time , CodeType from ms_vw_breakdown_memo_WHLMLT where shop_code = @Shop " & _
                            " and maintenance_group = @Group and breakdown_to_time = '1900-01-01 00:00:00.000' " & _
                            " order by breakdown_from_time , machine_code "
                    Else
                        da.SelectCommand.CommandText = "select  breakdown_from_time BDFromTime , machine_code MCcode,  memo_number MemoNum, " & _
                            " memo_slip_number MemoSlipNum ,  remarks Remarks , operator , production_affected ProdAffec " & _
                            " , breakdown_to_time , CodeType from ms_vw_breakdown_memo where shop_code = @Shop " & _
                            " and maintenance_group = @Group and breakdown_to_time = '1900-01-01 00:00:00.000' " & _
                            " order by breakdown_from_time , machine_code "
                    End If
                Else
                    If Group = "WHLMLT" Then
                        da.SelectCommand.CommandText = "select  a.breakdown_from_time BDFromTime, a.machine_code MCcode,  a.memo_number MemoNum, " & _
                            " a.memo_slip_number MemoSlipNum , a.remarks Remarks , a.operator , a.production_affected ProdAffec " & _
                            " , a.breakdown_to_time , CodeType from ms_vw_breakdown_memo_WHLMLT a " & _
                            " inner join mm_vw_EditableBreakdownsTillPhlGen b on a.maintenance_group = b.maintenance_group and a.memo_number = b.memo_number " & _
                            " where a.shop_code = @Shop and a.breakdown_to_time = '1900-01-01 00:00:00.000' " & _
                            " and a.maintenance_group = @Group " & _
                            " order by a.breakdown_from_time , a.machine_code "
                    Else
                        da.SelectCommand.CommandText = "select  a.breakdown_from_time BDFromTime, a.machine_code MCcode,  a.memo_number MemoNum, " & _
                            " a.memo_slip_number MemoSlipNum , a.remarks Remarks , a.operator , a.production_affected ProdAffec " & _
                            " , a.breakdown_to_time , CodeType from ms_vw_breakdown_memo a " & _
                            " inner join mm_vw_EditableBreakdownsTillPhlGen b on a.maintenance_group = b.maintenance_group and a.memo_number = b.memo_number " & _
                            " where a.shop_code = @Shop " & _
                            " and a.maintenance_group = @Group " & _
                            " order by a.breakdown_from_time , a.machine_code "
                    End If
                End If
                da.Fill(ds)
                PopulateMemoNumber = ds.Tables(0)
            Catch exp As Exception
                PopulateMemoNumber = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function MemoNumber(ByVal Group As String, ByVal Memoslip As String, ByVal MemoNo As Integer) As Integer
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@Group", SqlDbType.VarChar, 10).Value = Group.Trim
            oCmd.Parameters.Add("@Memoslip", SqlDbType.VarChar, 50).Value = Memoslip.Trim
            oCmd.Parameters.Add("@MemoNo", SqlDbType.Int, 4).Value = MemoNo
            oCmd.Parameters.Add("@Cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = "select @Cnt = count(*) from ms_breakdown_memo " & _
                    " where maintenance_group = @Group and memo_slip_number = @Memoslip and memo_number = @MemoNo"
                oCmd.ExecuteScalar()
                MemoNumber = IIf(IsDBNull(oCmd.Parameters("@Cnt").Value), 0, oCmd.Parameters("@Cnt").Value)
            Catch exp As Exception
                MemoNumber = 0
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function
        Public Shared Function MemoSlipNumber(ByVal Group As String, ByVal Memoslip As String) As Integer
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@Group", SqlDbType.VarChar, 10).Value = Group.Trim
            oCmd.Parameters.Add("@Memoslip", SqlDbType.VarChar, 50).Value = Memoslip.Trim
            oCmd.Parameters.Add("@MemoNo", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = "select @MemoNo = count(*) from ms_breakdown_memoslips " & _
                    " where maintenance_group = @Group and memo_slip_number = @Memoslip "
                oCmd.ExecuteScalar()
                MemoSlipNumber = IIf(IsDBNull(oCmd.Parameters("@MemoNo").Value), 0, oCmd.Parameters("@MemoNo").Value)
            Catch exp As Exception
                MemoSlipNumber = 0
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function
        Public Shared Function CheckFrDate(ByVal MemoDate As Date, ByVal Shift As String, ByVal FrDate As Date) As Boolean
            Dim str As Int16
            Dim FrSh, sShift As String
            Dim Continue1 As Boolean
            Try
                Select Case Now.Hour
                    Case 6 To 13
                        sShift = "A"
                    Case 14 To 21
                        sShift = "B"
                    Case Else
                        sShift = "C"
                End Select
                str = FrDate.Hour
                Select Case str
                    Case 6 To 13
                        FrSh = "A"
                    Case 14 To 21
                        FrSh = "B"
                    Case Else
                        FrSh = "C"
                End Select
                If MemoDate = Now.Today.Date AndAlso Shift <= sShift Then
                    Continue1 = True
                Else
                    If MemoDate < Now.Today.Date Then
                        Continue1 = True
                    End If
                End If
                If Continue1 Then
                    If MemoDate = FrDate.Date Then
                        If Shift = FrSh Then
                            CheckFrDate = True
                        End If
                    Else
                        If MemoDate.AddDays(1) = FrDate.Date Then
                            If Shift = FrSh Then
                                CheckFrDate = True
                            End If
                        End If
                    End If
                End If
            Catch exp As Exception
                CheckFrDate = 0
            End Try
            str = Nothing
            FrSh = Nothing
            sShift = Nothing
            Continue1 = Nothing
        End Function
        Public Shared Function GetBDDetails(ByVal Group As String, ByVal BDDate As Date, ByVal Shift As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@Group", SqlDbType.VarChar, 10).Value = Group.Trim
                da.SelectCommand.Parameters.Add("@BDDate", SqlDbType.SmallDateTime, 4).Value = BDDate
                da.SelectCommand.Parameters.Add("@Shift", SqlDbType.VarChar, 1).Value = Shift.Trim
                da.SelectCommand.CommandText = " select row_number() over ( order by memo_number ) SlNo , " & _
                    " memo_number MemoNo , memo_slip_number MemoSlipNo , " & _
                    " machine_code Machine , MachineShortName , " & _
                    " convert(varchar(11),breakdown_from_time,103) BDFrDate , " & _
                    " convert(varchar(5),breakdown_from_time,108) BDFrTime ," & _
                    " convert(varchar(11),breakdown_to_time,103) BDToDate , " & _
                    " convert(varchar(5),breakdown_to_time,108) BDToTime , TimeLoss ,  " & _
                    " case when production_affected = 1 then 'Yes' else 'No' end YorN , CodeType , " & _
                    " breakdown_code BDCode, BreakdownCode" & _
                    " from ms_vw_breakdown_memo " & _
                    " where breakdown_date = @BDDate and maintenance_group = @Group and shift_code = @Shift "
                da.Fill(ds)
                GetBDDetails = ds.Tables(0)
            Catch exp As Exception
                GetBDDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function GetBDMemos(ByVal Group As String, ByVal MemoDate As Date, ByVal Shift As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@Group", SqlDbType.VarChar, 50).Value = Group
                da.SelectCommand.Parameters.Add("@MemoDate", SqlDbType.SmallDateTime, 4).Value = MemoDate
                da.SelectCommand.Parameters.Add("@Shift", SqlDbType.VarChar, 1).Value = Shift
                da.SelectCommand.CommandText = " select distinct a.code_type , a.description from code_type a " & _
                    " inner join code b  on a.application = b.application and a.code_type = b.code_type " & _
                    " and substring(code,1,3) = @EqpID " & _
                    " where a.application = 'MS' and a.code_type like 'BD%' "
                da.Fill(ds)
                GetBDMemos = ds.Tables(0)
            Catch exp As Exception
                GetBDMemos = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function GetBDCodeDesc(ByVal BDCode As String, ByVal EqpID As String, Optional ByVal Group As String = "") As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                If Group.Trim = "WHLMLT" AndAlso EqpID = "ALL" AndAlso (BDCode = "BDC" Or BDCode = "BDMR" Or BDCode = "BDN" Or BDCode = "BDP" Or BDCode = "BDU" Or BDCode = "BDRT") Then
                    da.SelectCommand.CommandText = "SELECT  codeDesc , code from mm_vw_BDCodesNew " &
                         " where BDType = @BDCode and Eqp = @EqpID and BDGroup = '" & Group.Trim & "' " &
                         " ORDER BY codeDesc  "
                Else
                    da.SelectCommand.CommandText = "SELECT  codeDesc , code from mm_vw_BDCodes " & _
                         " where BDType = @BDCode and Eqp = @EqpID " & _
                         " ORDER BY codeDesc  "
                End If


                da.SelectCommand.Parameters.Add("@BDCode", SqlDbType.VarChar, 10).Value = BDCode.Trim
                da.SelectCommand.Parameters.Add("@EqpID", SqlDbType.VarChar, 10).Value = EqpID.Trim

                da.Fill(ds)
                If ds.Tables(0).Rows.Count = 0 Then
                    da.SelectCommand.CommandText = "SELECT  codeDesc , code from mm_vw_BDCodes " & _
                        " where BDType = @BDCode ORDER BY codeDesc  "
                    da.Fill(ds)
                End If
                GetBDCodeDesc = ds.Tables(0)
            Catch exp As Exception
                GetBDCodeDesc = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function GetBDCodes(ByVal EqpID As String, Optional ByVal Group As String = "") As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@EqpID", SqlDbType.VarChar, 50).Value = EqpID
                If Group.Trim = "WHLMLT" Then
                    da.SelectCommand.CommandText = " select BDType , BDTypeDesc from ms_BDType "
                    da.Fill(ds)
                Else
                    da.SelectCommand.CommandText = " select BDType , BDTypeDesc from mm_vw_BDTypes " & _
                        " where Eqp = @EqpID "
                    da.Fill(ds)
                End If
                If ds.Tables(0).Rows.Count = 0 Then
                    da.SelectCommand.CommandText = " select distinct BDType , BDTypeDesc from mm_vw_BDTypes "
                    da.Fill(ds)
                End If
                GetBDCodes = ds.Tables(0)
            Catch exp As Exception
                GetBDCodes = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function GetMemoNumber(ByVal Group As String) As Integer
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            oCmd.Parameters.Add("@Group", SqlDbType.VarChar, 10).Value = Group.Trim
            oCmd.Parameters.Add("@MemoNo", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = "select @MemoNo = max(memo_number) from ms_breakdown_memo " & _
                    " where maintenance_group = @Group "
                oCmd.ExecuteScalar()
                GetMemoNumber = IIf(IsDBNull(oCmd.Parameters("@MemoNo").Value), 1, oCmd.Parameters("@MemoNo").Value + 1)
            Catch exp As Exception
                GetMemoNumber = 0
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function
        Public Shared Function GetMachineCodes(ByVal Group As String, ByVal Shop As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                If Shop.Trim.ToLower = "rt" Then
                    da.SelectCommand.CommandText = "select (substring(machine_code,3,10)+'--'+ description) mccode_desc , " & _
                        " rtrim(machine_code) machine_code " & _
                        " from ms_machinery_master where location_code = @Shop " & _
                        " and equipment_code in  ( select equipment_id from ms_group_location " & _
                        " where location = @Shop and group_code = @Group )  order by  description "
                Else
                    da.SelectCommand.CommandText = "select rtrim(description) mccode_desc , " & _
                       " rtrim(machine_code) machine_code " & _
                       " from ms_machinery_master where location_code = @Shop " & _
                       " and equipment_code in  ( select equipment_id from ms_group_location " & _
                       " where location = @Shop and group_code = @Group )  " & _
                       " and machine_code not in ( select machine_code  from ms_MachinesNotInUse )  " & _
                       " order by  description "
                End If
                da.SelectCommand.Parameters.Add("@Group", SqlDbType.VarChar, 10).Value = Group.Trim
                da.SelectCommand.Parameters.Add("@Shop", SqlDbType.VarChar, 10).Value = Shop.Trim

                da.Fill(ds)
                GetMachineCodes = ds.Tables(0)
            Catch exp As Exception
                GetMachineCodes = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function GetShopCodes(ByVal Group As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = " select distinct rtrim(location) location  , rtrim(code.description) description  " &
                    " from ms_group_location,code " &
                    " where group_code = '" & Trim(Group) & "'" &
                    " and location = code and code_type = 'LC' and code.application = 'MS' " ' & _
                '" order by code.description "
                ' This commented due to avoid db error

                da.Fill(ds)
                GetShopCodes = ds.Tables(0)
            Catch exp As Exception
                GetShopCodes = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
#End Region
#Region " Fields"
        Private sGroup, sMemoSlip, sBDCode, sRemarks, sShift, sShop, sMachine, sOperator As String
        Private sAff, sBDType, sMessage As String
        Private intMemoNo As Integer
        Private dateBDFromTime, dateBDToTime As DateTime
        Private dateBDDate As Date
#End Region
#Region " Property"
        WriteOnly Property BDToTime() As DateTime
            Set(ByVal Value As DateTime)
                dateBDToTime = Value
            End Set
        End Property
        ReadOnly Property Message() As String
            Get
                Return sMessage
            End Get
        End Property
        WriteOnly Property BDType() As String
            Set(ByVal Value As String)
                sBDType = Value
            End Set
        End Property
        WriteOnly Property Aff() As String
            Set(ByVal Value As String)
                sAff = Value
            End Set
        End Property
        WriteOnly Property Operator1() As String
            Set(ByVal Value As String)
                sOperator = Value
            End Set
        End Property
        WriteOnly Property Machine() As String
            Set(ByVal Value As String)
                sMachine = Value
            End Set
        End Property
        WriteOnly Property Shop() As String
            Set(ByVal Value As String)
                sShop = Value
            End Set
        End Property
        WriteOnly Property Shift() As String
            Set(ByVal Value As String)
                sShift = Value
            End Set
        End Property
        WriteOnly Property BDDate() As Date
            Set(ByVal Value As Date)
                dateBDDate = Value
            End Set
        End Property
        WriteOnly Property Remarks() As String
            Set(ByVal Value As String)
                sRemarks = Value
            End Set
        End Property
        WriteOnly Property BDFromTime() As DateTime
            Set(ByVal Value As DateTime)
                dateBDFromTime = Value
            End Set
        End Property
        WriteOnly Property Group() As String
            Set(ByVal Value As String)
                sGroup = Value
            End Set
        End Property
        WriteOnly Property MemoSlip() As String
            Set(ByVal Value As String)
                sMemoSlip = Value
            End Set
        End Property
        WriteOnly Property BDCode() As String
            Set(ByVal Value As String)
                sBDCode = Value
            End Set
        End Property
        WriteOnly Property MemoNo() As Integer
            Set(ByVal Value As Integer)
                intMemoNo = Value
            End Set
        End Property
#End Region
#Region " Methods"
        Private Sub iniVals()
            sAff = "0"
            sGroup = ""
            sMemoSlip = ""
            sBDCode = ""
            intMemoNo = 0
            dateBDFromTime = "1900-01-01"
            dateBDToTime = "1900-01-01"
            sRemarks = ""
            dateBDDate = "1900-01-01"
            sShift = ""
            sShop = ""
            sMachine = ""
            sOperator = ""
            sBDType = ""
            sMessage = ""
        End Sub
        Public Sub New()
            iniVals()
        End Sub
        Public Function SaveMemo() As Boolean
            Dim done As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj

            oCmd.Parameters.Add("@Group", SqlDbType.VarChar, 50).Value = sGroup
            oCmd.Parameters.Add("@MemoSlip", SqlDbType.VarChar, 50).Value = sMemoSlip
            oCmd.Parameters.Add("@BDCode", SqlDbType.VarChar, 50).Value = sBDCode
            oCmd.Parameters.Add("@MemoNo", SqlDbType.Int, 4).Value = intMemoNo
            oCmd.Parameters.Add("@BDFromTime", SqlDbType.DateTime, 8).Value = dateBDFromTime
            oCmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 1000).Value = sRemarks
            oCmd.Parameters.Add("@BDDate", SqlDbType.SmallDateTime, 4).Value = dateBDDate
            oCmd.Parameters.Add("@Shift", SqlDbType.VarChar, 1).Value = sShift
            oCmd.Parameters.Add("@Shop", SqlDbType.VarChar, 50).Value = sShop
            oCmd.Parameters.Add("@Machine", SqlDbType.VarChar, 50).Value = sMachine
            oCmd.Parameters.Add("@status", SqlDbType.VarChar, 2).Value = "nc"
            oCmd.Parameters.Add("@Operator", SqlDbType.VarChar, 50).Value = sOperator
            oCmd.Parameters.Add("@production_affected", SqlDbType.VarChar, 1).Value = sAff
            oCmd.Parameters.Add("@BDType", SqlDbType.VarChar, 50).Value = sBDType
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                oCmd.CommandText = " insert into ms_breakdown_memoslips values ( @Group , @MemoSlip ) "
                If oCmd.ExecuteNonQuery = 1 Then
                    oCmd.CommandText = "insert into ms_breakdown_details( maintenance_group , memo_number , breakdown_code ) " & _
                        " values( @Group , @MemoNo , @BDCode )"
                    If oCmd.ExecuteNonQuery = 1 Then
                        oCmd.CommandText = " insert into ms_breakdown_memo ( maintenance_group , memo_number , memo_slip_number , " & _
                          " breakdown_from_time , remarks , breakdown_date , shift_code , shop_code , machine_code , " & _
                          " status , operator , production_affected , breakdown_type ) values " & _
                          " ( @Group , @MemoNo , @MemoSlip , @BDFromTime , @Remarks , @BDDate , @Shift , @Shop , @Machine , " & _
                          " @status , @Operator , @production_affected , @BDType )"
                        If oCmd.ExecuteNonQuery = 1 Then done = True
                    End If
                End If
            Catch exp As Exception
                sMessage = exp.Message
            Finally
                If done Then
                    oCmd.Transaction.Commit()
                Else
                    oCmd.Transaction.Rollback()
                End If
                oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
            Return done
        End Function
        Public Function UpdateMemo() As Boolean
            Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj

            oCmd.CommandText = "update ms_breakdown_memo set  breakdown_to_time = @breakdown_to_time , " & _
                   " remarks = @remarks , production_affected = @production_affected " & _
                   " where memo_number = @memo_number " & _
                   " and shop_code = @shop_code and maintenance_group = @maintenance_group "

            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            Try
                oCmd.Parameters.Add("@breakdown_to_time", SqlDbType.DateTime, 8).Value = dateBDToTime
                oCmd.Parameters.Add("@remarks", SqlDbType.VarChar, 1000).Value = sRemarks
                oCmd.Parameters.Add("@memo_number", SqlDbType.Int, 4).Value = intMemoNo
                oCmd.Parameters.Add("@shop_code", SqlDbType.VarChar, 50).Value = sShop
                oCmd.Parameters.Add("@maintenance_group", SqlDbType.VarChar, 50).Value = sGroup
                oCmd.Parameters.Add("@production_affected", SqlDbType.VarChar, 50).Value = sAff
                If oCmd.ExecuteNonQuery > 0 Then UpdateMemo = True
            Catch exp As Exception
                sMessage = exp.Message
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
                oCmd = Nothing
            End Try
        End Function
#End Region
    End Class
End Namespace
