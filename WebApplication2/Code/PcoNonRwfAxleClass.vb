Namespace NonRwfAxles
    <Serializable()> Public Class PcoNonRwfAxleClass
#Region " tables"
        Public Shared Function GetCastNo(ByVal AxleNo As String) As String
            Dim sStrNoInLabEntry, sSingleRecInPcoEntry, sSingleRecInAxleMaster, sGetCustomerCastNo, sDespAxle, sPressedAxle As String
            sStrNoInLabEntry = "select count(*) from mm_nonrwfaxles_labEntry a inner join mm_nonrwfaxles_pcoEntry b on a.ritesReference = b.ritesReference where b.rwf_axle_Number = '" & AxleNo & "'"
            sSingleRecInPcoEntry = "select count(*) from mm_nonrwfaxles_pcoEntry where rwf_axle_number = '" & AxleNo & "'"
            sSingleRecInAxleMaster = "select count(*) from mm_nonrwf_axles where axle_number = '" & AxleNo & "'"
            sGetCustomerCastNo = "select customer_cast_number from mm_nonrwf_axles where axle_number = '" & AxleNo & "'"
            sDespAxle = "select count(*) from dm_fg_despatch_products where '" & AxleNo & "' in (axle_no, product_no) "
            sPressedAxle = "Select count(*) from mm_mounting_press where axle_number = '" & AxleNo & "'"

            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim blnValid As Boolean
            Try
                cmd.Connection.Open()
                cmd.CommandText = sSingleRecInAxleMaster
                If cmd.ExecuteScalar = 0 Then
                    Throw New Exception("Axle Not In Master")
                End If
                cmd.CommandText = sSingleRecInPcoEntry
                If Not cmd.ExecuteScalar = 1 Then
                    Throw New Exception("Cannot update this axle. Contact MIS")
                End If
                cmd.CommandText = sStrNoInLabEntry
                If cmd.ExecuteScalar > 0 Then
                    Throw New Exception("Axle cannot be processed in Machine Shop")
                End If
                cmd.CommandText = sDespAxle
                If cmd.ExecuteScalar > 0 Then
                    Throw New Exception("Axle already despatched")
                End If
                cmd.CommandText = sPressedAxle
                If cmd.ExecuteScalar > 0 Then
                    Throw New Exception("Axle pressed/demounted")
                End If
                cmd.CommandText = sGetCustomerCastNo
                Return cmd.ExecuteScalar & ""
            Catch exp As Exception
                Return ""
                Throw New Exception(exp.Message)
            Finally
                If IsNothing(cmd) = False Then
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                End If
            End Try
        End Function
        Public Shared Function populateGrid(ByVal DtChanged As Date) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter
            da = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "Select convert(varchar(10),DtChanged,103) DtChanged , " & _
                " Axle_Number , EmpCode , OrgCast , RevisedCast , " & _
                " convert(varchar(10),SaveDateTime,103) SaveDate , convert(varchar(10),SaveDateTime,108) SaveTime  , Sl_no " & _
                " from mm_Nonrwfaxles_CastChanged where dtChanged = @DtChanged order by sl_no desc"
            da.SelectCommand.Parameters.Add("@DtChanged", SqlDbType.SmallDateTime).Value = CDate(DtChanged)
            Try
                da.Fill(ds)
                populateGrid = ds.Tables(0)
            Catch exp As Exception
                populateGrid = Nothing
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function AxleProdTable() As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter
            da = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "Select product_code, description, drawing_number , Make from mm_vw_AxleProducts_ForAxleRefInputs order by description, drawing_number, make"
            Try
                da.Fill(ds)
                AxleProdTable = ds.Tables(0)
            Catch exp As Exception
                AxleProdTable = Nothing
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function AxleProdDetails(ByVal Product_Code As String) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter
            da = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "Select product_code, description, drawing_number , Make " & _
            " from mm_vw_AxleProducts_ForAxleRefInputs where product_code = '" & Product_Code.Trim & "'"
            Try
                da.Fill(ds)
                AxleProdDetails = ds.Tables(0)
            Catch exp As Exception
                AxleProdDetails = Nothing
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function RitesCertificateTable(Optional ByVal ProductCode As String = "", Optional ByVal CertDate As Date = #1/1/1900#) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter
            da = rwfGen.Connection.Adapter
            If CertDate > #1/1/1900# Then
                da.SelectCommand.CommandText = "select ritesReference RefId, RitesLetterNumber RitesLtrNo, RitesCertificateNumber CertNo, CertificateDate CertDt, BookNumber BookNo, SetNumber SetNo, AxleProductcode ProdCode, CustomerDrgNumber CustDrg, TotQtyOrdered TotQty, CurSupply, BalanceSupply Balance, Manufacturer, Contractor, ContractReference, purchasingAuthority  from mm_NonrwfAxles_PcoRef where CertificateDate = @CertificateDate order by ritesReference desc "
                da.SelectCommand.Parameters.Add("@CertificateDate", SqlDbType.SmallDateTime, 4)
                da.SelectCommand.Parameters("@CertificateDate").Direction = ParameterDirection.Input
                da.SelectCommand.Parameters("@CertificateDate").Value = CertDate
            ElseIf ProductCode <> "" Then
                da.SelectCommand.CommandText = "select top 20 ritesReference RefId, RitesLetterNumber RitesLtrNo, RitesCertificateNumber CertNo, CertificateDate CertDt, BookNumber BookNo, SetNumber SetNo, AxleProductcode ProdCode, CustomerDrgNumber CustDrg, TotQtyOrdered TotQty, CurSupply, BalanceSupply Balance, Manufacturer, Contractor, ContractReference, purchasingAuthority  from mm_NonrwfAxles_PcoRef where AxleProductcode = '" & ProductCode.Trim & "' and CertificateDate >= '2011-04-01' order by ritesReference desc "
            Else
                da.SelectCommand.CommandText = "select ritesReference RefId, RitesLetterNumber RitesLtrNo, RitesCertificateNumber CertNo, CertificateDate CertDt, BookNumber BookNo, SetNumber SetNo, AxleProductcode ProdCode, CustomerDrgNumber CustDrg, TotQtyOrdered TotQty, CurSupply, BalanceSupply Balance, Manufacturer, Contractor, ContractReference, purchasingAuthority  from mm_NonrwfAxles_PcoRef where CertificateDate >= '2011-04-01' order by ritesReference desc "
            End If
            Try
                da.Fill(ds)
                RitesCertificateTable = ds.Tables(0)
            Catch exp As Exception
                RitesCertificateTable = Nothing
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function RwfProductTable(ByVal ProductCode As String) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter
            da = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "select description, drawing_number, type from mm_Product_master where Product_code = '" & ProductCode & "'"
            Try
                da.Fill(ds)
                RwfProductTable = ds.Tables(0)
            Catch exp As Exception
                RwfProductTable = Nothing
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function PcoSavedNonRwfAxles(ByVal RitesReference As Long) As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter
            da = rwfGen.Connection.Adapter
            da.SelectCommand.CommandText = "select row_number() over (order by DateTimePcoSaved ) Sl , * " & _
                " from mm_nonrwfAxles_PcoEntry where RitesReference = " & RitesReference & " order by DateTimePcoSaved desc"
            Try
                da.Fill(ds)
                PcoSavedNonRwfAxles = ds.Tables(0)
            Catch exp As Exception
                PcoSavedNonRwfAxles = Nothing
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function CustomerCastNumberTable(Optional ByVal CustomerAxleNumber As String = "") As DataTable
            Dim ds As New DataSet()
            Dim da As SqlClient.SqlDataAdapter
            da = rwfGen.Connection.Adapter
            If CustomerAxleNumber <> "" Then
                da.SelectCommand.CommandText = "select distinct CustomerCastNumber from mm_nonrwfAxles_PcoEntry where CustomerAxleNumber = '" & CustomerAxleNumber & "' order by CustomerCastNumber desc"
            Else
                da.SelectCommand.CommandText = "select distinct CustomerCastNumber from mm_nonrwfAxles_PcoEntry order by CustomerCastNumber desc"
            End If

            Try
                da.Fill(ds)
                CustomerCastNumberTable = ds.Tables(0)
            Catch exp As Exception
                CustomerCastNumberTable = Nothing
            Finally
                da.Dispose()
                ds.Dispose()
                da = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function NonRWFAxlesInspMptDrg() As DataTable
            Dim ds As New DataSet()
            Dim sqlda As New SqlClient.SqlDataAdapter()
            sqlda = rwfGen.Connection.Adapter
            sqlda.SelectCommand.CommandText = "Select InspDrg, MPTDrg from mm_vw_NonRWFAxlesReceivedInspDrg"
            sqlda.SelectCommand.CommandType = CommandType.Text
            Try
                sqlda.Fill(ds, "InspMptDrg")
                NonRWFAxlesInspMptDrg = ds.Tables("InspMptDrg")
            Catch exp As Exception
                Throw New Exception("Insp Mpt Drg Seek Error : " & exp.Message)
            Finally
                ds.Dispose()
                sqlda.Dispose()
                sqlda = Nothing
                ds = Nothing
            End Try
        End Function
        Public Shared Function NonRwfAxlesIntroduced(Optional ByVal IntroDate As Date = #1/1/1900#) As DataTable
            Dim ds As New DataSet()
            Dim sqlda As New SqlClient.SqlDataAdapter()
            sqlda = rwfGen.Connection.Adapter
            If IntroDate > #1/1/1900# Then
                sqlda.SelectCommand.CommandText = "Select Axle_Number AxlNum, Customer_Axle_Number CustAxleNum, Customer_Cast_Number CustCastNum, Year(Date_manufactured) MfgYr , Source, Make from mm_nonrwf_axles where Date_Axle_Created = @IntroDate order by Serial_no desc "
                sqlda.SelectCommand.Parameters.Add("@IntroDate", SqlDbType.SmallDateTime, 4)
                sqlda.SelectCommand.Parameters("@IntroDate").Direction = ParameterDirection.Input
                sqlda.SelectCommand.Parameters("@IntroDate").Value = IntroDate
            Else
                sqlda.SelectCommand.CommandText = "Select Axle_Number AxlNum, Customer_Axle_Number CustAxleNum, Customer_Cast_Number CustCastNum, Year(Date_manufactured) MfgYr , Source, Make from mm_nonrwf_axles order by Serial_no desc "
            End If
            sqlda.SelectCommand.CommandType = CommandType.Text
            Try
                sqlda.Fill(ds, "IntrodAxles")
                NonRwfAxlesIntroduced = ds.Tables("IntrodAxles")
            Catch exp As Exception
                Throw New Exception("Inroduced Axles list Error : " & exp.Message)
            Finally
                ds.Dispose()
                sqlda.Dispose()
                sqlda = Nothing
                ds = Nothing
            End Try
        End Function
#End Region
    End Class
    <Serializable()> Public Class InspCertificate
#Region "Fields"
        Private sAxleProductCode, sRitesCertificateNumber, sManufacturer, sBillPayingAuthority As String
        Private sPurchasingAuthority, sCustomerDrgNumber As String
        Private dCertificateDate As Date
        Private iBookNumber, iSetNumber, iTotQtyOrdered, iCurSupply, iBalanceSupply, iPreviousSupply As Integer
        Private lRitesReference As Long
        Private sRitesLetterNumber, sContractor, sContractReference, sEmpCode As String

#End Region
#Region "Properties"
        ReadOnly Property PreviousSupply() As Integer
            Get
                iPreviousSupply = iTotQtyOrdered - iCurSupply - iBalanceSupply
                Return iPreviousSupply
            End Get
        End Property
        Property AxleProductCode() As String
            Get
                Return sAxleProductCode
            End Get
            Set(ByVal Value As String)
                sAxleProductCode = Value.ToUpper.Trim
            End Set
        End Property

        Property RitesCertificateNumber() As String
            Get
                Return sRitesCertificateNumber
            End Get
            Set(ByVal Value As String)
                sRitesCertificateNumber = Value.ToUpper.Trim
            End Set
        End Property
        Property Manufacturer() As String
            Get
                Return sManufacturer
            End Get
            Set(ByVal Value As String)
                sManufacturer = Value.ToUpper.Trim
            End Set
        End Property
        Property RitesLetterNumber() As String
            Get
                Return sRitesLetterNumber
            End Get
            Set(ByVal Value As String)
                sRitesLetterNumber = Value.ToUpper.Trim
            End Set
        End Property
        Property BillPayingAuthority() As String
            Get
                Return sBillPayingAuthority
            End Get
            Set(ByVal Value As String)
                sBillPayingAuthority = Value.ToUpper.Trim
            End Set
        End Property
        Property PurchasingAuthority() As String
            Get
                Return sPurchasingAuthority
            End Get
            Set(ByVal Value As String)
                sPurchasingAuthority = Value.ToUpper.Trim
            End Set
        End Property
        Property CustomerDrgNumber() As String
            Get
                Return sCustomerDrgNumber
            End Get
            Set(ByVal Value As String)
                sCustomerDrgNumber = Value.ToUpper.Trim
            End Set
        End Property
        Property RitesReference() As Long
            Get
                Return lRitesReference
            End Get
            Set(ByVal Value As Long)
                lRitesReference = Value
            End Set
        End Property
        Property CertificateDate() As Date
            Get
                Return dCertificateDate
            End Get
            Set(ByVal Value As Date)
                dCertificateDate = Value
            End Set
        End Property
        Property BookNumber() As Integer
            Get
                Return iBookNumber
            End Get
            Set(ByVal Value As Integer)
                If Value < 0 Then
                    iBookNumber = 0
                    Throw New Exception("Negative value cannot be accepted")
                Else
                    iBookNumber = Value
                End If
            End Set
        End Property
        Property SetNumber() As Integer
            Get
                Return iSetNumber
            End Get
            Set(ByVal Value As Integer)
                If Value < 0 Then
                    iSetNumber = 0
                    Throw New Exception("Negative value cannot be accepted")
                Else
                    iSetNumber = Value
                End If

            End Set
        End Property
        Property TotQtyOrdered() As Integer
            Get
                Return iTotQtyOrdered
            End Get
            Set(ByVal Value As Integer)
                If Value < 0 Then
                    iTotQtyOrdered = 0
                    Throw New Exception("Negative value cannot be accepted")
                Else
                    iTotQtyOrdered = Value
                End If
            End Set
        End Property
        Property CurSupply() As Integer
            Get
                Return iCurSupply
            End Get
            Set(ByVal Value As Integer)
                If Value < 0 Then
                    iCurSupply = 0
                    Throw New Exception("Negative value cannot be accepted")
                Else
                    iCurSupply = Value
                End If

            End Set
        End Property
        Property BalanceSupply() As Integer
            Get
                Return iBalanceSupply
            End Get
            Set(ByVal Value As Integer)
                If Value < 0 Then
                    iBalanceSupply = 0
                    Throw New Exception("Negative value cannot be accepted")
                Else
                    iBalanceSupply = Value
                End If
            End Set
        End Property
        Property Contractor() As String
            Get
                Return sContractor
            End Get
            Set(ByVal Value As String)
                sContractor = Value.ToUpper.Trim
            End Set
        End Property
        Property ContractReference() As String
            Get
                Return sContractReference
            End Get
            Set(ByVal Value As String)
                sContractReference = Value.ToUpper.Trim
            End Set
        End Property
        Property EmployeeCode() As String
            Get
                Return sEmpCode
            End Get
            Set(ByVal Value As String)
                Dim oEmp As New rwfGen.Employee()
                Try
                    If oEmp.Check(Value, "PCOPCO") Then
                        sEmpCode = Value
                    Else
                        sEmpCode = ""
                    End If
                Catch exp As Exception
                    If oEmp.Check(Value, "AXLREF") Then
                        sEmpCode = Value
                    Else
                        sEmpCode = ""
                    End If
                End Try
                If sEmpCode = "" Then
                    Throw New Exception("Invalid login")
                End If
            End Set
        End Property
#End Region
#Region "Methods"
        Private Sub initVars()
            sRitesLetterNumber = ""
            sAxleProductCode = ""
            sRitesCertificateNumber = ""
            sManufacturer = ""
            sBillPayingAuthority = ""
            sPurchasingAuthority = "RB"
            sCustomerDrgNumber = ""
            lRitesReference = 0
            dCertificateDate = CDate("1/1/1900")
            iBookNumber = 0
            iSetNumber = 0
            iTotQtyOrdered = 0
            iCurSupply = 0
            iBalanceSupply = 0
            sEmpCode = ""
        End Sub
        Public Sub New()
            initVars()
        End Sub
        Public Sub New(ByVal CertificateNumber As String, ByVal BookNumber As Integer, ByVal SetNumber As Integer, ByVal CertificateDate As Date, ByVal ProductCode As String)
            initVars()
            sRitesCertificateNumber = CertificateNumber
            iBookNumber = BookNumber
            iSetNumber = SetNumber
            dCertificateDate = CertificateDate
            sAxleProductCode = ProductCode

            Dim cmd As New SqlClient.SqlCommand()
            cmd = rwfGen.Connection.CmdObj
            cmd.CommandText = "select count(*) from mm_NonrwfAxles_PcoRef where CertificateDate = @CertificateDate and RitesCertificateNumber = @RitesCertificateNumber and BookNumber = @BookNumber and SetNumber = @SetNumber and AxleProductCode = @AxleProductCode  "
            cmd.Parameters.Add("@CertificateDate", SqlDbType.SmallDateTime, 4)
            cmd.Parameters("@CertificateDate").Direction = ParameterDirection.Input
            cmd.Parameters("@CertificateDate").Value = dCertificateDate

            cmd.Parameters.Add("@RitesCertificateNumber", SqlDbType.VarChar, 2000)
            cmd.Parameters("@RitesCertificateNumber").Direction = ParameterDirection.Input
            cmd.Parameters("@RitesCertificateNumber").Value = CertificateNumber.ToUpper.Trim
            cmd.Parameters.Add("@BookNumber", SqlDbType.Int, 4)
            cmd.Parameters("@BookNumber").Direction = ParameterDirection.Input
            cmd.Parameters("@BookNumber").Value = BookNumber
            cmd.Parameters.Add("@SetNumber", SqlDbType.Int, 4)
            cmd.Parameters("@SetNumber").Direction = ParameterDirection.Input
            cmd.Parameters("@SetNumber").Value = SetNumber
            cmd.Parameters.Add("@AxleProductCode", SqlDbType.VarChar, 2000)
            cmd.Parameters("@AxleProductCode").Direction = ParameterDirection.Input
            cmd.Parameters("@AxleProductCode").Value = sAxleProductCode

            cmd.Parameters.Add("@Manufacturer", SqlDbType.VarChar, 2000)
            cmd.Parameters.Add("@ContractReference", SqlDbType.VarChar, 2000)
            cmd.Parameters("@ContractReference").Direction = ParameterDirection.Output
            cmd.Parameters.Add("@Contractor", SqlDbType.VarChar, 2000)
            cmd.Parameters("@Contractor").Direction = ParameterDirection.Output
            cmd.Parameters("@Manufacturer").Direction = ParameterDirection.Output
            cmd.Parameters.Add("@BillPayingAuthority", SqlDbType.VarChar, 2000)
            cmd.Parameters("@BillPayingAuthority").Direction = ParameterDirection.Output
            cmd.Parameters.Add("@PurchasingAuthority", SqlDbType.VarChar, 2000)
            cmd.Parameters("@PurchasingAuthority").Direction = ParameterDirection.Output
            cmd.Parameters.Add("@CustomerDrgNumber", SqlDbType.VarChar, 2000)
            cmd.Parameters("@CustomerDrgNumber").Direction = ParameterDirection.Output
            cmd.Parameters.Add("@RitesReference", SqlDbType.BigInt, 8)
            cmd.Parameters("@RitesReference").Direction = ParameterDirection.Output

            cmd.Parameters.Add("@TotQtyOrdered", SqlDbType.Int, 4)
            cmd.Parameters("@TotQtyOrdered").Direction = ParameterDirection.Output
            cmd.Parameters.Add("@CurSupply", SqlDbType.Int, 4)
            cmd.Parameters("@CurSupply").Direction = ParameterDirection.Output
            cmd.Parameters.Add("@BalanceSupply", SqlDbType.Int, 4)
            cmd.Parameters("@BalanceSupply").Direction = ParameterDirection.Output
            cmd.Parameters.Add("@PreviousSupply", SqlDbType.Int, 4)
            cmd.Parameters("@PreviousSupply").Direction = ParameterDirection.Output

            Try
                cmd.Connection.Open()
                cmd.ExecuteScalar()
                cmd.CommandText = "select @PreviousSupply = PreviousSupply, @Contractor = Contractor,  @ContractReference = ContractReference, @AxleProductCode = AxleProductCode, @Manufacturer = Manufacturer, @BillPayingAuthority = BillPayingAuthority,  @PurchasingAuthority = PurchasingAuthority, @CustomerDrgNumber = CustomerDrgNumber, @TotQtyOrdered = TotQtyOrdered, @CurSupply = CurSupply, @BalanceSupply = BalanceSupply from mm_NonrwfAxles_PcoRef where CertificateDate = @CertificateDate and RitesCertificateNumber = @RitesCertificateNumber and BookNumber = @BookNumber and SetNumber = @SetNumber "
                cmd.ExecuteScalar()
                sAxleProductCode = IIf(IsDBNull(cmd.Parameters("@AxleProductCode").Value), "", cmd.Parameters("@AxleProductCode").Value)
                sManufacturer = IIf(IsDBNull(cmd.Parameters("@Manufacturer").Value), "", cmd.Parameters("@Manufacturer").Value)
                sBillPayingAuthority = IIf(IsDBNull(cmd.Parameters("@BillPayingAuthority").Value), "", cmd.Parameters("@BillPayingAuthority").Value)
                sPurchasingAuthority = IIf(IsDBNull(cmd.Parameters("@PurchasingAuthority").Value), "", cmd.Parameters("@PurchasingAuthority").Value)
                sCustomerDrgNumber = IIf(IsDBNull(cmd.Parameters("@CustomerDrgNumber").Value), "", cmd.Parameters("@CustomerDrgNumber").Value)
                iTotQtyOrdered = IIf(IsDBNull(cmd.Parameters("@TotQtyOrdered").Value), 0, cmd.Parameters("@TotQtyOrdered").Value)
                iCurSupply = IIf(IsDBNull(cmd.Parameters("@CurSupply").Value), 0, cmd.Parameters("@CurSupply").Value)
                iBalanceSupply = IIf(IsDBNull(cmd.Parameters("@BalanceSupply").Value), 0, cmd.Parameters("@BalanceSupply").Value)
                iPreviousSupply = IIf(IsDBNull(cmd.Parameters("@PreviousSupply").Value), 0, cmd.Parameters("@PreviousSupply").Value)
                sContractor = IIf(IsDBNull(cmd.Parameters("@Contractor").Value), "", cmd.Parameters("@Contractor").Value)
                sContractReference = IIf(IsDBNull(cmd.Parameters("@ContractReference").Value), "", cmd.Parameters("@ContractReference").Value)
            Catch exp As Exception
                initVars()
                Throw New Exception("Object Initialisation error:" & exp.Message)
            Finally
                If IsNothing(cmd) = False Then
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                End If
            End Try
        End Sub

        Public Sub Save(Optional ByVal Delete As Boolean = False)
            Dim blnDone As Boolean
            Dim sCheckRecord, sInsertRecord, sUpdateRecord, sDeleteRecord, sInsertLabEntry As String
            sCheckRecord = "select count(*) from mm_NonrwfAxles_PcoRef where CertificateDate = @CertificateDate and RitesCertificateNumber = @RitesCertificateNumber and BookNumber = @BookNumber and SetNumber = @SetNumber and AxleProductCode = @AxleProductCode  "
            sInsertRecord = "insert into mm_NonrwfAxles_PcoRef (SaveDateTime, EnteredBy, RitesLetterNumber, Contractor, ContractReference, AxleProductCode,  Manufacturer,  BillPayingAuthority,  PurchasingAuthority, CustomerDrgNumber, TotQtyOrdered, CurSupply, BalanceSupply, CertificateDate, RitesCertificateNumber, BookNumber, SetNumber, PreviousSupply) values ( @SaveDateTime, @EnteredBy, @RitesLetterNumber, @Contractor, @ContractReference, @AxleProductCode,  @Manufacturer,  @BillPayingAuthority,  @PurchasingAuthority, @CustomerDrgNumber, @TotQtyOrdered, @CurSupply, @BalanceSupply, @CertificateDate, @RitesCertificateNumber, @BookNumber, @SetNumber, @PreviousSupply )"
            sUpdateRecord = "update mm_NonrwfAxles_PcoRef set SaveDateTime = @SaveDateTime, EnteredBy = @EnteredBy, RitesLetterNumber =@RitesLetterNumber, Contractor = @Contractor, ContractReference = @ContractReference, AxleProductCode  = @AxleProductCode,  Manufacturer = @Manufacturer,  BillPayingAuthority = @BillPayingAuthority,  PurchasingAuthority = @PurchasingAuthority, CustomerDrgNumber = @CustomerDrgNumber, TotQtyOrdered = @TotQtyOrdered, CurSupply = @CurSupply, BalanceSupply = @BalanceSupply, CertificateDate = @CertificateDate,  RitesCertificateNumber = @RitesCertificateNumber, BookNumber = @BookNumber, SetNumber = @SetNumber, PreviousSupply = @PreviousSupply where CertificateDate = @CertificateDate and RitesCertificateNumber = @RitesCertificateNumber and BookNumber = @BookNumber and SetNumber = @SetNumber and AxleProductCode = @AxleProductCode  "
            sDeleteRecord = "delete mm_NonrwfAxles_PcoRef where CertificateDate = @CertificateDate and RitesCertificateNumber = @RitesCertificateNumber and BookNumber = @BookNumber and SetNumber = @SetNumber and AxleProductCode = @AxleProductCode "
            sInsertLabEntry = "exec mm_sp_AddRitesRefToLabEntry @RitesCertificateNumber , @BookNumber , @SetNumber "
            Dim cmd As New SqlClient.SqlCommand()
            cmd = rwfGen.Connection.CmdObj

            cmd.Parameters.Add("@CertificateDate", SqlDbType.SmallDateTime, 4)
            cmd.Parameters("@CertificateDate").Direction = ParameterDirection.Input
            cmd.Parameters("@CertificateDate").Value = dCertificateDate

            cmd.Parameters.Add("@RitesCertificateNumber", SqlDbType.VarChar, 2000)
            cmd.Parameters("@RitesCertificateNumber").Direction = ParameterDirection.Input
            cmd.Parameters("@RitesCertificateNumber").Value = sRitesCertificateNumber.ToUpper.Trim
            cmd.Parameters.Add("@BookNumber", SqlDbType.Int, 4)
            cmd.Parameters("@BookNumber").Direction = ParameterDirection.Input
            cmd.Parameters("@BookNumber").Value = BookNumber
            cmd.Parameters.Add("@SetNumber", SqlDbType.Int, 4)
            cmd.Parameters("@SetNumber").Direction = ParameterDirection.Input
            cmd.Parameters("@SetNumber").Value = SetNumber
            cmd.Parameters.Add("@AxleProductCode", SqlDbType.VarChar, 2000)
            cmd.Parameters("@AxleProductCode").Direction = ParameterDirection.Input
            cmd.Parameters("@AxleProductCode").Value = sAxleProductCode

            cmd.Parameters.Add("@Manufacturer", SqlDbType.VarChar, 2000)
            cmd.Parameters.Add("@Contractor", SqlDbType.VarChar, 2000)
            cmd.Parameters.Add("@ContractReference", SqlDbType.VarChar, 2000)
            cmd.Parameters.Add("@BillPayingAuthority", SqlDbType.VarChar, 2000)
            cmd.Parameters.Add("@PurchasingAuthority", SqlDbType.VarChar, 2000)
            cmd.Parameters.Add("@CustomerDrgNumber", SqlDbType.VarChar, 2000)
            cmd.Parameters.Add("@TotQtyOrdered", SqlDbType.Int, 4)
            cmd.Parameters.Add("@CurSupply", SqlDbType.Int, 4)
            cmd.Parameters.Add("@BalanceSupply", SqlDbType.Int, 4)
            cmd.Parameters.Add("@PreviousSupply", SqlDbType.Int, 4)


            cmd.Parameters.Add("@SaveDateTime", SqlDbType.DateTime, 8)
            cmd.Parameters.Add("@EnteredBy", SqlDbType.VarChar, 6)
            cmd.Parameters.Add("@RitesLetterNumber", SqlDbType.VarChar, 2000)

            cmd.Parameters("@SaveDateTime").Direction = ParameterDirection.Input
            cmd.Parameters("@EnteredBy").Direction = ParameterDirection.Input
            cmd.Parameters("@RitesLetterNumber").Direction = ParameterDirection.Input
            cmd.Parameters("@Contractor").Direction = ParameterDirection.Input
            cmd.Parameters("@ContractReference").Direction = ParameterDirection.Input


            cmd.Parameters("@ContractReference").Direction = ParameterDirection.Input
            cmd.Parameters("@Contractor").Direction = ParameterDirection.Input
            cmd.Parameters("@Manufacturer").Direction = ParameterDirection.Input
            cmd.Parameters("@BillPayingAuthority").Direction = ParameterDirection.Input
            cmd.Parameters("@PurchasingAuthority").Direction = ParameterDirection.Input
            cmd.Parameters("@CustomerDrgNumber").Direction = ParameterDirection.Input
            cmd.Parameters("@TotQtyOrdered").Direction = ParameterDirection.Input
            cmd.Parameters("@CurSupply").Direction = ParameterDirection.Input
            cmd.Parameters("@BalanceSupply").Direction = ParameterDirection.Input
            cmd.Parameters("@PreviousSupply").Direction = ParameterDirection.Input


            cmd.Parameters("@ContractReference").Value = sContractReference
            cmd.Parameters("@Contractor").Value = sContractor
            cmd.Parameters("@Manufacturer").Value = sManufacturer
            cmd.Parameters("@BillPayingAuthority").Value = sBillPayingAuthority
            cmd.Parameters("@PurchasingAuthority").Value = sPurchasingAuthority
            cmd.Parameters("@CustomerDrgNumber").Value = sCustomerDrgNumber
            cmd.Parameters("@TotQtyOrdered").Value = iTotQtyOrdered
            cmd.Parameters("@CurSupply").Value = iCurSupply
            cmd.Parameters("@BalanceSupply").Value = iBalanceSupply
            cmd.Parameters("@PreviousSupply").Value = Me.PreviousSupply

            cmd.Parameters("@SaveDateTime").Value = CDate(Now)
            cmd.Parameters("@EnteredBy").Value = sEmpCode
            cmd.Parameters("@RitesLetterNumber").Value = sRitesLetterNumber
            cmd.Parameters("@Contractor").Value = sContractor
            cmd.Parameters("@ContractReference").Value = sContractReference


            Dim sMessage As String
            Try
                If sEmpCode = "" Then
                    Throw New Exception("Invalid Login")
                End If
                cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                cmd.CommandText = sCheckRecord
                If cmd.ExecuteScalar > 0 Then
                    If Delete Then
                        cmd.CommandText = sDeleteRecord
                        sMessage = "Deleted"
                    Else
                        cmd.CommandText = sUpdateRecord
                        sMessage = "Updated"
                    End If
                Else
                    cmd.CommandText = sInsertRecord
                    sMessage = "Inserted"
                End If
                If cmd.ExecuteNonQuery > 0 Then
                    cmd.CommandText = sInsertLabEntry
                    cmd.ExecuteNonQuery()
                    blnDone = True
                End If
            Catch exp As Exception
                If Delete = False Then
                    sMessage = "Save Error : " & exp.Message
                Else
                    sMessage = "Delete Error : " & exp.Message
                End If
            Finally
                If IsNothing(cmd) = False Then
                    If IsNothing(cmd.Transaction) = False Then
                        If blnDone Then
                            cmd.Transaction.Commit()
                        Else
                            cmd.Transaction.Rollback()
                        End If
                    End If
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                End If
            End Try
            Throw New Exception(sMessage)
        End Sub

#End Region
    End Class
    <Serializable()> Public Class CertifiedAxles
#Region "Fields"
        Private sCustomerCastNumber As String
        Private sCustomerAxleNumber, sRWF_Axle_Number As String
        Private lRitesReference As Long
        Private sEmpCode As String
        Private dDateTimePcoSaved As Date
        Private blnAlreadyEntered As Boolean
#End Region
#Region " Property"
        Enum TestTypes
            CastTest
            UT
            MPT
        End Enum
        ReadOnly Property AlreadyEntered() As Boolean
            Get
                Return blnAlreadyEntered
            End Get
        End Property
        ReadOnly Property EmpCode() As String
            Get
                Return sEmpCode
            End Get
        End Property
        ReadOnly Property RWF_Axle_Number() As String
            Get
                If sCustomerAxleNumber <> "" AndAlso sCustomerCastNumber <> "" And lRitesReference > 0 Then
                    sRWF_Axle_Number = getRwfAxleNumber()
                Else
                    sRWF_Axle_Number = ""
                End If
                Return sRWF_Axle_Number
            End Get
        End Property
        Property CustomerCastNumber() As String
            Get
                Return sCustomerCastNumber
            End Get
            Set(ByVal Value As String)
                sCustomerCastNumber = Value.Trim.ToUpper
            End Set
        End Property
        Property CustomerAxleNumber() As String
            Get
                Return sCustomerAxleNumber
            End Get
            Set(ByVal Value As String)

                sCustomerAxleNumber = Value.Trim.ToUpper

            End Set
        End Property
        Property RitesReference() As Long
            Get
                Return lRitesReference
            End Get
            Set(ByVal Value As Long)
                lRitesReference = Value
            End Set
        End Property
#End Region
#Region "Methods"
        Public Sub New(ByVal EmpCode As String)
            InitVars()
            sEmpCode = EmpCode
        End Sub
        Private Sub InitVars()
            sCustomerCastNumber = ""
            sCustomerAxleNumber = ""
            sRWF_Axle_Number = ""
            lRitesReference = 0
            sEmpCode = ""
            dDateTimePcoSaved = CDate("1/1/1900")
            blnAlreadyEntered = False
        End Sub
        Private Function getRwfAxleNumber() As String
            Dim dv As New DataView()
            dv.Table = NonRwfAxles.PcoNonRwfAxleClass.PcoSavedNonRwfAxles(lRitesReference)
            dv.RowFilter = "RitesReference = " & lRitesReference.ToString.Trim & " and CustomerCastNumber = '" & sCustomerCastNumber & "' and CustomerAxleNumber = '" & sCustomerAxleNumber & "'"
            If dv.Count > 0 Then
                getRwfAxleNumber = dv(0)("RWF_Axle_Number") & ""
                blnAlreadyEntered = True
            Else
                getRwfAxleNumber = ""
            End If
            dv.Dispose()
        End Function
        Public Function DdlTable() As DataTable
            Dim dt As New DataTable("ddlTable")
            dt.Columns.Add(New DataColumn("TxtFld", System.Type.GetType("System.String")))
            dt.Columns("TxtFld").MaxLength = 2000
            dt.Columns.Add(New DataColumn("ValFld", System.Type.GetType("System.Int64")))
            Dim drSrc, drTgt As DataRow
            For Each drSrc In NonRwfAxles.PcoNonRwfAxleClass.RitesCertificateTable.Rows
                drTgt = dt.NewRow
                drTgt("TxtFld") = CStr(drSrc("CertNo")).Trim & " Book No.: " & CStr(drSrc("BookNo")).Trim & " Set No.: " & CStr(drSrc("SetNo")).Trim
                drTgt("ValFld") = drSrc("RefId")
                dt.Rows.Add(drTgt)
            Next
            Return dt
        End Function
        Public Sub save(Optional ByVal Delete As Boolean = False)
            If sRWF_Axle_Number <> "" Then
                Throw New Exception("RWF Number is punched. Modification/Deletion not allowed")
            End If
            Dim sCheckAxle, sInsertAxle, sDeleteAxle As String
            sCheckAxle = "Select count(*) from mm_nonrwfAxles_PcoEntry where CustomerCastNumber = @CustomerCastNumber and CustomerAxleNumber = @CustomerAxleNumber and RitesReference = @RitesReference"
            sInsertAxle = "Insert into mm_nonrwfAxles_PcoEntry (RitesReference, CustomerCastNumber, CustomerAxleNumber, PcoEmpCode, DateTimePcoSaved) values (@RitesReference, @CustomerCastNumber, @CustomerAxleNumber, @PcoEmpCode, @DateTimePcoSaved) "
            sDeleteAxle = "Delete from mm_nonrwfAxles_PcoEntry where CustomerCastNumber = @CustomerCastNumber and CustomerAxleNumber = @CustomerAxleNumber and RitesReference = @RitesReference and isnull(RWF_Axle_Number,'') = ''"

            Dim blnDone As Boolean

            Dim cmd As New SqlClient.SqlCommand()
            cmd = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@CustomerCastNumber", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@CustomerAxleNumber", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@RitesReference", SqlDbType.BigInt, 8)
            cmd.Parameters.Add("@PcoEmpCode", SqlDbType.VarChar, 6)
            cmd.Parameters.Add("@DateTimePcoSaved", SqlDbType.DateTime, 8)

            cmd.Parameters("@CustomerCastNumber").Direction = ParameterDirection.Input
            cmd.Parameters("@CustomerAxleNumber").Direction = ParameterDirection.Input
            cmd.Parameters("@RitesReference").Direction = ParameterDirection.Input
            cmd.Parameters("@PcoEmpCode").Direction = ParameterDirection.Input
            cmd.Parameters("@DateTimePcoSaved").Direction = ParameterDirection.Input
            Dim sMessage As String
            Try
                cmd.Parameters("@CustomerCastNumber").Value = sCustomerCastNumber
                cmd.Parameters("@CustomerAxleNumber").Value = sCustomerAxleNumber
                cmd.Parameters("@RitesReference").Value = lRitesReference
                cmd.Parameters("@PcoEmpCode").Value = sEmpCode
                cmd.Parameters("@DateTimePcoSaved").Value = CDate(Now)
                cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                cmd.CommandText = sCheckAxle
                If Delete Then
                    If cmd.ExecuteScalar > 0 Then
                        cmd.CommandText = sDeleteAxle
                        sMessage = "Deleted :"
                    Else
                        sMessage = "Deleted :"
                    End If
                ElseIf Not Delete Then
                    cmd.CommandText = sInsertAxle
                    sMessage = "Saved :"
                Else
                    sMessage = "Saved :"
                End If
                If cmd.ExecuteNonQuery > 0 Then
                    sMessage = sMessage & " " & sCustomerAxleNumber & "/" & sCustomerCastNumber
                    blnDone = True
                Else
                    sMessage = "Not " & sMessage & " " & sCustomerAxleNumber & "/" & sCustomerCastNumber
                End If
            Catch exp As Exception
                sMessage = "Save Error : " & exp.Message
            Finally
                If IsNothing(cmd) = False Then
                    If IsNothing(cmd.Transaction) = False Then
                        If blnDone Then
                            cmd.Transaction.Commit()
                        Else
                            cmd.Transaction.Rollback()
                        End If
                    End If
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                End If
            End Try
            Throw New Exception(sMessage)
        End Sub
        Public Function UpdateCastNumber(ByVal AxleNo As String, ByVal CustCastNo As String, ByVal DtChanged As Date, ByVal OriginalCastNo As String) As Boolean
            Dim sStrNoInLabEntry, sSingleRecInPcoEntry, sSingleRecInAxleMaster, sGetCustomerCastNo, sDespAxle, sPressedAxle As String
            Dim sUpdatePcoEntry, sUpdateAxleMaster As String

            sStrNoInLabEntry = "select count(*) from mm_nonrwfaxles_labEntry a inner join mm_nonrwfaxles_pcoEntry b on a.ritesReference = b.ritesReference where b.rwf_axle_Number = '" & AxleNo & "'"
            sSingleRecInPcoEntry = "select count(*) from mm_nonrwfaxles_pcoEntry where rwf_axle_number = '" & AxleNo & "'"
            sSingleRecInAxleMaster = "select count(*) from mm_nonrwf_axles where axle_number = '" & AxleNo & "'"
            sGetCustomerCastNo = "select customer_cast_number from mm_nonrwf_axles where axle_number = '" & AxleNo & "'"
            sDespAxle = "select count(*) from dm_fg_despatch_products where '" & AxleNo & "' in (axle_no, product_no) "
            sPressedAxle = "Select count(*) from mm_mounting_press where axle_number = '" & AxleNo & "'"

            sUpdatePcoEntry = "Update mm_nonrwfaxles_pcoEntry set customerCastNumber = '" & CustCastNo & "' where rwf_axle_number = '" & AxleNo & "'"
            sUpdateAxleMaster = "update mm_nonrwf_axles set customer_cast_number = '" & CustCastNo & "' where axle_number = '" & AxleNo & "' and final_status is null and ut_status is null and mpt_status is null "

            Dim sInsertLog As String
            sInsertLog = "Insert into mm_Nonrwfaxles_CastChanged (DtChanged, EmpCode, OrgCast, RevisedCast, SaveDateTime, Axle_Number) select @DtChanged, @EmpCode, @OrgCast, @RevisedCast, @SaveDateTime, @axleNo "

            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim blnValid As Boolean
            Try
                cmd.Parameters.Add("@DtChanged", SqlDbType.SmallDateTime, 4).Value = CDate(DtChanged)
                cmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 6).Value = Me.EmpCode
                cmd.Parameters.Add("@OrgCast", SqlDbType.VarChar, 50).Value = OriginalCastNo
                cmd.Parameters.Add("@RevisedCast", SqlDbType.VarChar, 50).Value = CustCastNo
                cmd.Parameters.Add("@SaveDateTime", SqlDbType.DateTime, 8).Value = Now
                cmd.Parameters.Add("@axleNo", SqlDbType.VarChar, 50).Value = AxleNo
                cmd.Connection.Open()
                cmd.CommandText = sSingleRecInAxleMaster
                If cmd.ExecuteScalar = 0 Then
                    Throw New Exception("Axle Not In Master")
                End If
                cmd.CommandText = sSingleRecInPcoEntry
                If Not cmd.ExecuteScalar = 1 Then
                    Throw New Exception("Cannot update this axle. Contact MIS")
                End If
                cmd.CommandText = sStrNoInLabEntry
                If cmd.ExecuteScalar > 0 Then
                    Throw New Exception("Axle cannot be processed in Machine Shop")
                End If
                cmd.CommandText = sPressedAxle
                If cmd.ExecuteScalar > 0 Then
                    Throw New Exception("Axle pressed/demounted")
                End If
                cmd.CommandText = sDespAxle
                If cmd.ExecuteScalar > 0 Then
                    Throw New Exception("Axle already despatched")
                End If
                cmd.Transaction = cmd.Connection.BeginTransaction
                cmd.CommandText = sUpdatePcoEntry
                If cmd.ExecuteNonQuery = 1 Then
                    cmd.CommandText = sUpdateAxleMaster
                    If cmd.ExecuteNonQuery = 1 Then
                        cmd.CommandText = sInsertLog
                        If cmd.ExecuteNonQuery > 0 Then
                            blnValid = True
                        End If
                    End If
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If IsNothing(cmd) = False Then
                    If IsNothing(cmd.Transaction) = False Then
                        If blnValid Then
                            cmd.Transaction.Commit()
                        Else
                            cmd.Transaction.Rollback()
                        End If
                    End If
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                    cmd = Nothing
                End If
            End Try
            Return blnValid
        End Function
#End Region
    End Class
    <Serializable()> Public Class AMSReceivedAxles
#Region " Fields"
        Inherits CertifiedAxles
        Private blnNonRWFCastTest, blnNonRWFUT, blnNonRWFMpt As Boolean
        Private sMptDrawing As String
        Private ddateManufactured, dIntroductionDate As Date
        Private sPrefixAxleNumber As String
        Private sCustDrg As String
        Private sMake As String
        Private sSource, sInspectionDrawing, sIntroductionShift, sAxleStatus As String
        Dim sMessage, sRwfNumber As String
        Private blnRwfNumberExists, blnDuplicateRefExists As Boolean
#End Region
#Region " Property"
        ReadOnly Property DuplicateReferenceExists() As Boolean
            Get
                Return blnDuplicateRefExists
            End Get
        End Property
        ReadOnly Property Message() As String
            Get
                Return sMessage
            End Get
        End Property
        ReadOnly Property PcoReference() As Long
            Get
                Return MyBase.RitesReference
            End Get
        End Property
        Property AxleStatus() As String
            Get
                Return sAxleStatus
            End Get
            Set(ByVal Value As String)
                sAxleStatus = Value.ToUpper.Trim
            End Set
        End Property
        Property IntroductionShift() As String
            Get
                Return sIntroductionShift
            End Get
            Set(ByVal Value As String)
                sIntroductionShift = Value
            End Set
        End Property
        Property InspectionDrawing() As String
            Get
                Return sInspectionDrawing
            End Get
            Set(ByVal Value As String)
                sInspectionDrawing = Value.ToUpper.Trim
            End Set
        End Property
        Property Make() As String
            Get
                Return sMake
            End Get
            Set(ByVal Value As String)
                sMake = Value.ToUpper.Trim
            End Set
        End Property
        Property Source() As String
            Get
                Return sSource
            End Get
            Set(ByVal Value As String)
                sSource = Value.ToUpper.Trim
            End Set
        End Property
        Property CustomerDrawing() As String
            Get
                Return sCustDrg
            End Get
            Set(ByVal Value As String)
                sCustDrg = Value.ToUpper.Trim
            End Set
        End Property
        Property ShiftManufactured() As String
            Get
                Return sIntroductionShift
            End Get
            Set(ByVal Value As String)
                sIntroductionShift = Value.ToUpper.Trim
            End Set
        End Property
        Property IntroductionDate() As Date
            Get
                Return dIntroductionDate
            End Get
            Set(ByVal Value As Date)
                dIntroductionDate = Value
            End Set
        End Property
        Property dateManufactured() As Date
            Get
                Return ddateManufactured
            End Get
            Set(ByVal Value As Date)
                ddateManufactured = Value
            End Set
        End Property
        Property MptDrawing() As String
            Get
                Return sMptDrawing
            End Get
            Set(ByVal Value As String)
                sMptDrawing = Value.ToUpper.Trim
            End Set
        End Property
        Property RwfTests(ByVal TestType As TestTypes) As Boolean
            Get
                Select Case TestType
                    Case TestTypes.CastTest
                        Return blnNonRWFCastTest
                    Case TestTypes.MPT
                        Return blnNonRWFMpt
                    Case TestTypes.UT
                        Return blnNonRWFUT
                End Select
            End Get
            Set(ByVal Value As Boolean)
                Select Case TestType
                    Case TestTypes.CastTest
                        blnNonRWFCastTest = Value
                    Case TestTypes.MPT
                        blnNonRWFMpt = Value
                    Case TestTypes.UT
                        blnNonRWFUT = Value
                End Select
            End Set
        End Property
#End Region
#Region "Methods"
        Public Sub New(ByVal EmpCode As String)
            MyBase.New(EmpCode)
        End Sub
        Private Sub InitVars()
            blnNonRWFCastTest = False
            blnNonRWFUT = False
            blnNonRWFMpt = False
            sMptDrawing = ""
            blnDuplicateRefExists = False
        End Sub
        Public Function GetRitesReference(ByVal AxleNo As String, ByVal CastNo As String) As Long
            Dim lrNo As Long
            Dim cmd As SqlClient.SqlCommand
            cmd = rwfGen.Connection.CmdObj
            cmd.CommandText = "select isnull(ritesReference,0) from mm_nonrwfAxles_PcoEntry where customercastnumber = '" & CastNo & "' and customeraxlenumber = '" & AxleNo & "'"
            Try
                cmd.Connection.Open()
                lrNo = cmd.ExecuteScalar
            Catch exp As Exception
                lrNo = 0
                Throw New Exception("Rites Reference seek error : " & exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
            Return lrNo
        End Function
        Public Sub CheckPcoRef()
            sMessage = ""
            If MyBase.CustomerAxleNumber <> "" And MyBase.CustomerCastNumber <> "" Then
                If PcoRefExists() = False Then
                    If blnRwfNumberExists = False Then
                        sMessage = " No PCO Entry" & MyBase.CustomerAxleNumber & "/" & MyBase.CustomerCastNumber
                    End If
                    MyBase.CustomerCastNumber = ""
                    MyBase.CustomerAxleNumber = ""
                    Throw New Exception(sMessage)
                Else
                    If blnRwfNumberExists = True Then
                        sMessage = "Rwf Number already assigned : " & sRwfNumber
                        Throw New Exception(sMessage)
                    End If
                End If
                Try
                    DuplicateRefExists()
                Catch exp As Exception
                    sMessage = exp.Message
                    Throw New Exception(sMessage)
                End Try
            End If
        End Sub
        Private Function DuplicateRefExists() As Boolean
            Dim cnt As Int16
            Dim cmd As SqlClient.SqlCommand
            cmd = rwfGen.Connection.CmdObj
            cmd.CommandText = "select @ritesReference = count(ritesReference)  from mm_nonrwfAxles_PcoEntry where customerCastNumber = @CustomerCastNumber and customerAxleNumber = @CustomerAxleNumber "
            cmd.Parameters.Add("@CustomerCastNumber", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@customerAxleNumber", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@ritesReference", SqlDbType.BigInt, 8)
            cmd.Parameters("@CustomerCastNumber").Direction = ParameterDirection.Input
            cmd.Parameters("@customerAxleNumber").Direction = ParameterDirection.Input
            cmd.Parameters("@ritesReference").Direction = ParameterDirection.Output
            cmd.Parameters("@CustomerCastNumber").Value = MyBase.CustomerCastNumber
            cmd.Parameters("@customerAxleNumber").Value = MyBase.CustomerAxleNumber

            Try
                cnt = 0
                cmd.Connection.Open()
                cmd.ExecuteScalar()
                cnt = IIf(IsDBNull(cmd.Parameters("@ritesReference").Value), 0, cmd.Parameters("@ritesReference").Value)

                If cnt > 1 Then
                    blnDuplicateRefExists = True
                    DuplicateRefExists = True
                Else
                    blnDuplicateRefExists = False
                    DuplicateRefExists = False
                End If
            Catch exp As Exception
                DuplicateRefExists = False
                Throw New Exception("Pco Reference Error : " & exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Private Function PcoRefExists() As Boolean
            Dim cmd As SqlClient.SqlCommand
            cmd = rwfGen.Connection.CmdObj
            cmd.CommandText = "select @ritesReference = ritesReference, @RwfNumber = isnull(rwf_axle_number,'')  from mm_nonrwfAxles_PcoEntry where customerCastNumber = @CustomerCastNumber and customerAxleNumber = @CustomerAxleNumber "
            cmd.Parameters.Add("@CustomerCastNumber", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@customerAxleNumber", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@ritesReference", SqlDbType.BigInt, 8)
            cmd.Parameters.Add("@RwfNumber", SqlDbType.VarChar, 50)


            cmd.Parameters("@CustomerCastNumber").Direction = ParameterDirection.Input
            cmd.Parameters("@customerAxleNumber").Direction = ParameterDirection.Input
            cmd.Parameters("@ritesReference").Direction = ParameterDirection.Output
            cmd.Parameters("@RwfNumber").Direction = ParameterDirection.Output



            cmd.Parameters("@CustomerCastNumber").Value = MyBase.CustomerCastNumber
            cmd.Parameters("@customerAxleNumber").Value = MyBase.CustomerAxleNumber


            Try
                cmd.Connection.Open()
                cmd.ExecuteScalar()
                MyBase.RitesReference = IIf(IsDBNull(cmd.Parameters("@ritesReference").Value), 0, cmd.Parameters("@ritesReference").Value)

                If MyBase.RitesReference > 0 Then
                    PcoRefExists = True
                    If cmd.Parameters("@RwfNumber").Value <> "" Then
                        sRwfNumber = cmd.Parameters("@RwfNumber").Value
                        blnRwfNumberExists = True
                    Else
                        blnRwfNumberExists = False
                        sRwfNumber = ""
                    End If
                Else
                    MyBase.RitesReference = 0
                    PcoRefExists = False
                End If
            Catch exp As Exception
                PcoRefExists = False
                Throw New Exception("Pco Reference Error : " & exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End Try
        End Function
        Public Shadows Function save(Optional ByVal Delete As Boolean = False) As String
            If Delete Then Throw New Exception("Delete Option should not be given. Replace with another axle data instead manually.")
            Dim sNewRwfNo As String
            If IsNothing(sAxleStatus) Then
                Throw New Exception("Axle Status not entered")
            End If
            sPrefixAxleNumber = "RWF"
            If sMptDrawing = "WD-89025/S-2" Or sMptDrawing = "WAP/SK/MA-291" Then
                sPrefixAxleNumber = "RBC"
            End If

            Dim sCheckExists, sInsertAxle, sUpdateAxle, sGetRWFAxleNo, sUpdateAxleNoAsRWFAxle, sUpdatePcoRef As String
            sCheckExists = "Select count(*) from mm_nonrwf_axles where customer_axle_number = @CustomerAxleNumber and customer_cast_number = @CustomerCastNumber and axle_number like '" & sPrefixAxleNumber & "%' "
            sInsertAxle = "Insert into mm_nonrwf_axles ( source, customer_axle_number, axle_number, make, " & _
                                 " Date_Axle_Created, Shift_Axle_Created, Date_Manufactured, Customer_Cast_Number," & _
                                 " Non_RWF_CastTest,Customer_Drawing_Number,  Drawing_Number, Inspection_drawing_number, Non_RWF_UT, " & _
                                 " Non_rwf_mpt, Axle_sts, EmployeeCode_Axle_Created ) VALUES ( @source,  @CustomerAxleNumber , @AxleNumber , @make , " & _
                                 " @IntroDate , @shift , @DateManufactured , @CustomerCastNumber , @NonRWFCastTest , @CustomerDrawing, @MPTDrawing , @InspectionDrawing , " & _
                                 " @NonRWFUT , @NonRWFMPT ,   @AxleSts , @IntroducedBy ) "

            sUpdateAxleNoAsRWFAxle = "update mm_nonrwf_axles set axle_number =  '" & sPrefixAxleNumber & "'+CONVERT(VARCHAR,serial_no) where axle_number = '" & sPrefixAxleNumber & "' and len(rtrim(axle_number)) = 3 and customer_axle_number = @CustomerAxleNumber  and  customer_cast_number = @CustomerCastNumber and isnull(axle_number,'') = '" & sPrefixAxleNumber & "'"


            'sUpdateAxleNoAsRWFAxle = "update mm_nonrwf_axles set axle_number =  'RWF'+CONVERT(VARCHAR,serial_no) where axle_number = 'RWF' and len(rtrim(axle_number)) = 3 and customer_axle_number = @CustomerAxleNumber and  customer_cast_number = @CustomerCastNumber and isnull(axle_number,'') = ''; " & _
            '                         "update mm_nonrwf_axles set axle_number =  'RBC'+CONVERT(VARCHAR,serial_no) where axle_number = 'RBC' and len(rtrim(axle_number)) = 3 and customer_axle_number = @CustomerAxleNumber  and  customer_cast_number = @CustomerCastNumber and isnull(axle_number,'') = ''"

            sUpdatePcoRef = "update a set a.rwf_axle_number = b.axle_number from  mm_nonrwfAxles_PcoEntry a inner join mm_nonrwf_axles b on b.customer_Cast_number = a.customerCastNumber and a.CustomerAxleNumber = b.customer_axle_number where a.ritesReference = @RitesReference and isnull(a.rwf_axle_number,'') = '' and a.customeraxlenumber = @CustomerAxleNumber and a.customercastnumber = @CustomerCastNumber"

            sGetRWFAxleNo = "select axle_number from mm_nonrwf_axles where customer_axle_number = @customeraxlenumber and  customer_cast_number = @CustomerCastNumber and axle_number like '" + sPrefixAxleNumber + "%'" ' Store this to lblRWFNumber

            Dim cmd As SqlClient.SqlCommand
            cmd = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@IntroDate", SqlDbType.DateTime, 8)
            cmd.Parameters.Add("@Shift", SqlDbType.VarChar, 1)
            cmd.Parameters.Add("@IntroducedBy", SqlDbType.VarChar, 6)
            cmd.Parameters.Add("@CustomerAxleNumber", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@InspectionDrawing", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@MPTDrawing", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@CustomerDrawing", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Source", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Make", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@CustomerCastNumber", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@AxleSts", SqlDbType.VarChar, 1)
            cmd.Parameters.Add("@NonRWFUT", SqlDbType.Bit, 1)
            cmd.Parameters.Add("@NonRWFMPT", SqlDbType.Bit, 1)
            cmd.Parameters.Add("@NonRWFCastTest", SqlDbType.Bit, 1)
            cmd.Parameters.Add("@AxleNumber", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@DateManufactured", SqlDbType.DateTime, 8)
            cmd.Parameters("@AxleNumber").Value = sPrefixAxleNumber
            cmd.Parameters.Add("@RitesReference", SqlDbType.BigInt, 8)
            cmd.Parameters("@RitesReference").Direction = ParameterDirection.Input

            Dim blnDone As Boolean
            Try
                If blnNonRWFCastTest = True Then
                    cmd.Parameters("@NonRWFCastTest").Value = 1
                Else
                    cmd.Parameters("@NonRWFCastTest").Value = 0
                End If
                If blnNonRWFUT = True Then
                    cmd.Parameters("@NonRWFUT").Value = 1
                Else
                    cmd.Parameters("@NonRWFUT").Value = 0
                End If
                If blnNonRWFMpt = True Then
                    cmd.Parameters("@NonRWFMPT").Value = 1
                Else
                    cmd.Parameters("@NonRWFMPT").Value = 0
                End If
                cmd.Parameters("@RitesReference").Value = MyBase.RitesReference
                cmd.Parameters("@AxleSts").Value = sAxleStatus
                cmd.Parameters("@CustomerCastNumber").Value = MyBase.CustomerCastNumber
                cmd.Parameters("@Make").Value = sMake
                cmd.Parameters("@Source").Value = sSource
                cmd.Parameters("@CustomerDrawing").Value = sCustDrg
                cmd.Parameters("@InspectionDrawing").Value = sInspectionDrawing
                cmd.Parameters("@MPTDrawing").Value = sMptDrawing
                cmd.Parameters("@CustomerAxleNumber").Value = MyBase.CustomerAxleNumber
                cmd.Parameters("@IntroducedBy").Value = MyBase.EmpCode
                cmd.Parameters("@Shift").Value = sIntroductionShift
                cmd.Parameters("@IntroDate").Value = dIntroductionDate
                cmd.Parameters("@DateManufactured").Value = ddateManufactured
                blnDone = True
            Catch exp As Exception
                Throw New Exception("Save Params Error : " & exp.Message)
            End Try

            If blnDone = False Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
                Exit Function
            Else
                blnDone = False
            End If
            sNewRwfNo = ""
            Try
                cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                cmd.CommandText = sCheckExists
                If cmd.ExecuteScalar > 0 Then
                    sMessage = "Alreay exists. Cannot add one more"
                Else
                    cmd.CommandText = sInsertAxle
                    If cmd.ExecuteNonQuery > 0 Then
                        cmd.CommandText = sUpdateAxleNoAsRWFAxle
                        If cmd.ExecuteNonQuery > 0 Then
                            cmd.CommandText = sUpdatePcoRef
                            If cmd.ExecuteNonQuery > 0 Then
                                blnDone = True
                                cmd.CommandText = sGetRWFAxleNo
                                sNewRwfNo = cmd.ExecuteScalar & ""
                                sMessage = "Saved : " & sNewRwfNo
                            End If
                        End If
                    End If
                End If
            Catch exp As Exception
                sMessage = "Save Error " & exp.Message
            Finally
                If IsNothing(cmd) = False Then
                    If IsNothing(cmd.Transaction) = False Then
                        If blnDone = True Then
                            cmd.Transaction.Commit()
                        Else
                            cmd.Transaction.Rollback()
                        End If
                        If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                        cmd.Dispose()
                        cmd = Nothing
                    End If
                End If
            End Try
            cmd.Dispose()
            cmd = Nothing
            Return sNewRwfNo
        End Function
        Public Function DeleteRef(ByVal RitesReference As Long, ByVal CustAxleNo As String, ByVal CastHeatNo As String) As Boolean
            Dim str As String
            Dim Done As Boolean
            str = " select @cnt =  count(*) from mm_nonrwfaxles_pcoentry" & _
                    " where RitesReference = @RitesReference and CustomerAxleNumber = @CustomerAxleNumber  and CustomerCastNumber = @CustomerCastNumber and rwf_axle_number is null"
            Dim Cmd As System.Data.SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                Cmd.Parameters.Add("@RitesReference", SqlDbType.BigInt, 8).Value = RitesReference
                Cmd.Parameters.Add("@CustomerAxleNumber", SqlDbType.VarChar, 50).Value = CustAxleNo
                Cmd.Parameters.Add("@CustomerCastNumber", SqlDbType.VarChar, 50).Value = CastHeatNo
                Cmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                Cmd.CommandText = str
                If Cmd.Connection.State = ConnectionState.Closed Then Cmd.Connection.Open()
                Cmd.ExecuteScalar()
                If IIf(IsDBNull(Cmd.Parameters("@cnt").Value), 0, Cmd.Parameters("@cnt").Value) Then
                    str = " delete mm_nonrwfaxles_pcoentry" & _
                                    " where RitesReference = @RitesReference and CustomerAxleNumber = @CustomerAxleNumber  and CustomerCastNumber = @CustomerCastNumber and rwf_axle_number is null"
                    Cmd.Transaction = Cmd.Connection.BeginTransaction
                    Cmd.CommandText = str
                    If Cmd.ExecuteNonQuery > 0 Then Done = True
                End If
            Catch exp As Exception
                DeleteRef = False
                Throw New Exception(exp.Message)
            Finally
                If Done Then
                    Cmd.Transaction.Commit()
                    DeleteRef = True
                Else
                    Cmd.Transaction.Rollback()
                    DeleteRef = False
                End If
                If Cmd.Connection.State = ConnectionState.Open Then Cmd.Connection.Close()
                Cmd.Dispose()
                Cmd = Nothing
            End Try
        End Function
#End Region
    End Class
End Namespace
