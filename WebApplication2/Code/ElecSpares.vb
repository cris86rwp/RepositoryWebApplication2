Namespace ElecSpares
    Public Class Tables
        Public Shared Function GetSuppliers(ByVal FrDate As Date, ByVal ToDate As Date) As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            da.SelectCommand = New SqlClient.SqlCommand()
            da.SelectCommand.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
            da.SelectCommand.CommandText = " select distinct supplier , supplier_code  from ms_vw_Sparecell_PODues  " & _
                        " where  order_completion_date  between @FrDate and  @ToDate and consignee = 'EAAC' order by supplier "
            da.SelectCommand.Parameters.Add("@FrDate", SqlDbType.SmallDateTime, 4)
            da.SelectCommand.Parameters("@FrDate").Direction = ParameterDirection.Input
            da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.SmallDateTime, 4)
            da.SelectCommand.Parameters("@ToDate").Direction = ParameterDirection.Input
            da.SelectCommand.CommandTimeout = "1080000"
            Try
                da.SelectCommand.Parameters("@FrDate").Value = FrDate
                da.SelectCommand.Parameters("@ToDate").Value = ToDate
                da.Fill(ds)
                GetSuppliers = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetIndentDetails(ByVal Consi As String, ByVal Indent As String) As DataTable
            Dim dt As New DataTable()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@Consi", SqlDbType.VarChar, 4).Value = Consi.Trim
                da.SelectCommand.Parameters.Add("@Indent", SqlDbType.VarChar, 12).Value = Indent.Trim

                da.SelectCommand.CommandText = " select a.* , NSIDNno , NSIDNTime , PLRecdQty , PLRecdOn , Remarks , InVoiceNo , InVoiceDate , RegRemarks , NSDBRNo , NSDBRDate from ms_vw_NonStockIndentDetails  " & _
                                " a left outer join ms_vw_ElecNSIDNDetails b " & _
                                " on a.consignee = b.ConsigneeName and a.pl_number = b.pl_number and a.po_number = b.PO_No " & _
                                " where  a.indent_number = @Indent and consignee = @Consi "

                da.Fill(ds)
                GetIndentDetails = ds.Tables(0).Copy
            Catch exp As Exception
                GetIndentDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function GetDetails(ByVal Consi As String, ByVal QryNo As Long, ByVal frDt As Date, ByVal toDt As Date) As DataTable
            Dim dt As New DataTable()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@Consi", SqlDbType.VarChar, 4).Value = Consi.Trim
                da.SelectCommand.Parameters.Add("@frDt", SqlDbType.SmallDateTime, 4).Value = frDt
                da.SelectCommand.Parameters.Add("@toDt", SqlDbType.SmallDateTime, 4).Value = toDt
                Select Case QryNo
                    Case 0
                        da.SelectCommand.CommandText = " select a.* , NSIDNno , NSIDNTime , PLRecdQty , PLRecdOn , Remarks , InVoiceNo , InVoiceDate , RegRemarks , NSDBRNo , NSDBRDate from ms_vw_NonStockIndentDetails  " & _
                        " a left outer join ms_vw_ElecNSIDNDetails b " & _
                        " on a.consignee = b.ConsigneeName and a.pl_number = b.pl_number and a.po_number = b.PO_No " & _
                        " where  indent_date between @frDt and @toDt and consignee = @Consi "
                    Case 1
                        da.SelectCommand.CommandText = " select a.* , NSIDNno , NSIDNTime , PLRecdQty , PLRecdOn , Remarks , InVoiceNo , InVoiceDate , RegRemarks , NSDBRNo , NSDBRDate from ms_vw_NonStockIndentDetails  " & _
                        " a left outer join ms_vw_ElecNSIDNDetails b " & _
                        " on a.consignee = b.ConsigneeName and a.pl_number = b.pl_number and a.po_number = b.PO_No " & _
                        " where  indent_date between @frDt and @toDt and consignee = @Consi " & _
                        " and isnull(a.po_date,'') <> '1900-01-01' "
                    Case 2
                        da.SelectCommand.CommandText = " select a.* , NSIDNno , NSIDNTime , PLRecdQty , PLRecdOn , Remarks , InVoiceNo , InVoiceDate , RegRemarks , NSDBRNo , NSDBRDate from ms_vw_NonStockIndentDetails  " & _
                        " a left outer join ms_vw_ElecNSIDNDetails b " & _
                        " on a.consignee = b.ConsigneeName and a.pl_number = b.pl_number and a.po_number = b.PO_No " & _
                        " where  a.order_completion_date between @frDt and @toDt and consignee = @Consi " & _
                        " and isnull(a.po_date,'') <> '1900-01-01' "
                End Select

                da.Fill(ds)
                GetDetails = ds.Tables(0).Copy
            Catch exp As Exception
                GetDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function getNSIDNRegisterDetails(ByVal NSIDNno As Long) As DataSet
            Dim str As String
            str = "  select b.NsIDNno , convert(varchar(11), b.NSIDNTime,103) NSIDNDt , convert(varchar(5), b.NSIDNTime,108) Time , " & _
                        " b.pl_number PLNumber , b.PO_No PONumber , convert(varchar(11), b.po_date,103) po_date , b.PO_QTY , b.PLRecdQty , b.Unit ,  " & _
                        " convert(varchar(11), b.PLRecdOn,103) PLRecdOn , b.ConsigneeName  Consignee ,  b.Remarks  " & _
                        " from ms_vw_ElecNSIDNDetails b  where b.NsIDnno =   " & NSIDNno & " ; " & _
                        " select SentToShopOn , RecdFromShopOn , PLAcceptedQty , PLRejQty , Authority , Status , LedgerNumber , Location , Remarks , SlNo  " & _
                        " , NSDBRNo , NSDBRDate from ms_ElecSpares_Register where NSIDNno = " & NSIDNno & " ;  "
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = str
            Try
                da.Fill(ds)
                getNSIDNRegisterDetails = ds.Copy
            Catch exp As Exception
                getNSIDNRegisterDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                str = Nothing
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function NSIDNDetails(ByVal NSIDNno As Long) As DataTable
            Dim str As String
            str = "  select b.NsIDnno , b.NSIDNDate , b.NSIDNTime , b.PO_No PONumber , b.pl_number PLNumber ,  b.PLRecdOn , " & _
                        " b.ConsigneeName  Consignee , b.PLRecdQty ,  b.Remarks , b.Unit " & _
                        " , b.po_date , b.PO_QTY , InVoiceNo , InVoiceDate from ms_vw_ElecNSIDNDetails b  where b.NsIDnno =   " & NSIDNno & " ; "
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Dim dt As New DataTable()
            da.SelectCommand.CommandText = str
            Try
                da.Fill(ds)
                dt = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                str = Nothing
                ds.Dispose()
                da.Dispose()
            End Try
            Return dt
        End Function
        Public Shared Function GetNSIDNs() As DataTable
            Dim dt As New DataTable()
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select NSIDNno from ms_ElecSpares_nsidnno  order by NSIDNno desc "
            Try
                da.Fill(ds)
                GetNSIDNs = ds.Tables(0).Copy
            Catch exp As Exception
                GetNSIDNs = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function GetConsignee() As DataTable
            Dim str As String = "select  Consignee , ConsigneeName   from ms_ElecSpares_Consignee   order by ConsigneeName "
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Dim dt As New DataTable()
            da.SelectCommand.CommandText = str
            Try
                da.Fill(ds)
                dt = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                str = Nothing
                ds.Dispose()
                da.Dispose()
            End Try
            Return dt
        End Function
        Public Shared Function getNSPODetails(ByVal PONumber As String) As DataSet
            Dim strPODetails As String
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            strPODetails = " select  a.po_number , a.po_date , a.po_value ,a.order_completion_date PODueDate , c.name " & _
                                            " from pm_po_header a , pm_supplier_master c " & _
                                            " where  c.supplier_code = a.supplier_code and a.po_number = '" & PONumber.Trim & "' ; " & _
                                            " select a.po_number, a.pl_number, substring(a.long_description,1,60) pl_desc , a.order_quantity Qty , a.unit_rate Rate, f.description UnitName  " & _
                                            " from pm_po_details a  left outer join pm_itemMasterOnly b on b.pl_number = a.pl_number     " & _
                                            " left outer join code f on f.code = b.uom and f.application = 'pm' and f.code_type = 'UT' " & _
                                            " where a.po_number = '" & PONumber.Trim & "' ; " & _
                                            " select po_number , pl_number , po_quantity OrderQty , consignee from ms_vw_NsPoDetails where po_number = '" & PONumber.Trim & "' ;" & _
                                            " exec  ms_PoWarAndPaymentTerms '" & PONumber.Trim & "' ; " & _
                                            " select b.NsIDnId NSIDNId, convert(varchar,b.NSIDNDate,103) NSIDNDate , a.PONumber, a.PLNumber , d.consigneename Consi ,  " & _
                                            " b.PLRecdQty RecdQty , c.PLAcceptedQty AccpQty , c.PLRejQty RejQty , c.Status   " & _
                                            " from ms_sparecell_po a inner join ms_sparecell_nsidnno b on b.poid = a.poid " & _
                                            " left outer join ms_IMBRegister c on c.NsIdnId = b.NsIdnId  " & _
                                            " inner join ms_sparecell_consignee d on d.Consignee = b.POConsignee  where a.PONumber = '" & PONumber.Trim & "' ; " & _
                                            " select ltrim(rtrim(po_status)) po_status , dbo.ms_fn_PoWarAndPaymentTerms(po_number) PT , ltrim(rtrim(order_type)) order_type from pm_po_header where  po_number = '" & PONumber.Trim & "' ; " & _
                                            " select  count(*) cnt from ms_vw_NsPoDetails where  po_number = '" & PONumber.Trim & "' ;" & _
                                            " select *  from ms_vw_sparecell_PIDetails where isnull(NSIDNId,'') = '' and  ponumber = '" & PONumber.Trim & "' ;"
            da.SelectCommand.CommandText = strPODetails
            Try
                da.Fill(ds)
                getNSPODetails = ds.Copy
            Catch exp As Exception
                getNSPODetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                strPODetails = Nothing
                ds.Dispose()
                da.Dispose()
            End Try
            Return ds
        End Function
        Public Shared Function getNSPOPlDetails(ByVal PONumber As String, ByVal PlNumber As String, ByVal Consignee As String) As DataSet
            Dim strPODetails As String
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            strPODetails = " select po_number , pl_number , consignee , short_description , order_quantity , UnitName  from ms_vw_NonStockIndentDetails " & _
                        " where  po_number = '" & PONumber.Trim & "' and consignee = '" & Consignee.Trim & "' and pl_number = '" & PlNumber.Trim & "'  "

            da.SelectCommand.CommandText = strPODetails
            Try
                da.Fill(ds)
                getNSPOPlDetails = ds.Copy
            Catch exp As Exception
                getNSPOPlDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                strPODetails = Nothing
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
    End Class
    Public Class NSIDNs
#Region "  fields "
        Private lNSIDNno As Long
        Private decPLRecdQty, decAccpQty, decRejQty As Decimal
        Private sPONumber, sPLNumber, sPORemarks, sWarGuar, sLedgerNumber, sLocation, sAuthority, sStatus, sRegRemarks, sInVoiceNo, sNSDBRNo As String
        Private dateNSIDNDate, dateNSIDNDateTime, datePLRecdOn, dateSentToShopOn, dateRecdFromShopOn, dateInVoiceDate, dateNSDBRDate As Date
        Private intPOConsignee As Integer
        Private blnNextNumberGenerated, blnUpdation, blnRegUpdation As Boolean
#End Region
#Region "  property "
        Property InVoiceNo() As String
            Get
                Return sInVoiceNo
            End Get
            Set(ByVal Value As String)
                sInVoiceNo = Value
            End Set
        End Property
        Property InVoiceDate() As Date
            Get
                Return dateInVoiceDate
            End Get
            Set(ByVal Value As Date)
                dateInVoiceDate = Value
            End Set
        End Property
        ReadOnly Property RegUpdation() As Boolean
            Get
                Return blnRegUpdation
            End Get
        End Property
        Property RegRemarks() As String
            Get
                Return sRegRemarks
            End Get
            Set(ByVal Value As String)
                sRegRemarks = Value
            End Set
        End Property
        Property Location() As String
            Get
                Return sLocation
            End Get
            Set(ByVal Value As String)
                sLocation = Value
            End Set
        End Property
        Property Authority() As String
            Get
                Return sAuthority
            End Get
            Set(ByVal Value As String)
                sAuthority = Value
            End Set
        End Property
        Property Status() As String
            Get
                Return sStatus
            End Get
            Set(ByVal Value As String)
                sStatus = Value
            End Set
        End Property
        Property LedgerNumber() As String
            Get
                Return sLedgerNumber
            End Get
            Set(ByVal Value As String)
                sLedgerNumber = Value
            End Set
        End Property
        Property RejQty() As Decimal
            Get
                Return decRejQty
            End Get
            Set(ByVal Value As Decimal)
                decRejQty = Value
            End Set
        End Property
        Property AccpQty() As Decimal
            Get
                Return decAccpQty
            End Get
            Set(ByVal Value As Decimal)
                decAccpQty = Value
            End Set
        End Property
        ReadOnly Property Updation() As Boolean
            Get
                Return blnUpdation
            End Get
        End Property
        ReadOnly Property NextNumberGenerated() As Boolean
            Get
                Return blnNextNumberGenerated
            End Get
        End Property
        WriteOnly Property WarGuar() As String
            Set(ByVal Value As String)
                sWarGuar = Value
            End Set
        End Property
        Property RecdFromShopOn() As Date
            Get
                Return dateRecdFromShopOn
            End Get
            Set(ByVal Value As Date)
                dateRecdFromShopOn = Value
            End Set
        End Property
        Property SentToShopOn() As Date
            Get
                Return dateSentToShopOn
            End Get
            Set(ByVal Value As Date)
                dateSentToShopOn = Value
            End Set
        End Property
        Property PLRecdOn() As Date
            Get
                Return datePLRecdOn
            End Get
            Set(ByVal Value As Date)
                datePLRecdOn = Value
            End Set
        End Property
        Property POConsignee() As Integer
            Get
                Return intPOConsignee
            End Get
            Set(ByVal Value As Integer)
                intPOConsignee = Value
            End Set
        End Property
        Property NSIDNDateTime() As Date
            Get
                Return dateNSIDNDateTime
            End Get
            Set(ByVal Value As Date)
                dateNSIDNDateTime = Value
            End Set
        End Property
        Property NSIDNDate() As Date
            Get
                Return dateNSIDNDate
            End Get
            Set(ByVal Value As Date)
                dateNSIDNDate = Value
            End Set
        End Property
        Property PLRecdQty() As Decimal
            Get
                Return decPLRecdQty
            End Get
            Set(ByVal Value As Decimal)
                decPLRecdQty = Value
            End Set
        End Property
        Property PLNumber() As String
            Get
                Return sPLNumber
            End Get
            Set(ByVal Value As String)
                sPLNumber = Value
            End Set
        End Property
        Property PONumber() As String
            Get
                Return sPONumber
            End Get
            Set(ByVal Value As String)
                sPONumber = Value
            End Set
        End Property
        Property NSIDNno() As Long
            Get
                Return lNSIDNno
            End Get
            Set(ByVal Value As Long)
                lNSIDNno = Value
            End Set
        End Property
        Property PORemarks() As String
            Get
                Return sPORemarks
            End Get
            Set(ByVal Value As String)
                sPORemarks = Value
            End Set
        End Property
        Property NSDBRDate() As Date
            Get
                Return dateNSDBRDate
            End Get
            Set(ByVal Value As Date)
                dateNSDBRDate = Value
            End Set
        End Property
        Property NSDBRNo() As String
            Get
                Return sNSDBRNo
            End Get
            Set(ByVal Value As String)
                sNSDBRNo = Value
            End Set
        End Property
#End Region
#Region "  methods "
        Private Sub iniVals()
            dateNSDBRDate = "1900-01-01"
            sNSDBRNo = ""
            dateInVoiceDate = "1900-01-01"
            sInVoiceNo = ""
            blnRegUpdation = False
            sRegRemarks = ""
            sStatus = ""
            sAuthority = ""
            sLocation = ""
            sLedgerNumber = ""
            decAccpQty = 0
            decRejQty = 0
            blnUpdation = False
            sWarGuar = ""
            dateRecdFromShopOn = "1900-01-01"
            dateSentToShopOn = "1900-01-01"
            sPORemarks = ""
            datePLRecdOn = "1900-01-01"
            intPOConsignee = 0
            dateNSIDNDateTime = "1900-01-01"
            dateNSIDNDate = "1900-01-01"
            decPLRecdQty = 0
            sPLNumber = ""
            sPONumber = ""
            lNSIDNno = 0
            blnNextNumberGenerated = False
        End Sub
        Public Sub New()
            iniVals()
        End Sub
        Public Sub Generate(ByVal NSIDN As Long)
            Dim oCmd As New SqlClient.SqlCommand()
            oCmd.Connection = rwfGen.Connection.ConObj
            Dim done As New Boolean()
            Dim insert As New Boolean()
            Dim sPO, strPO As String
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction

                oCmd.Parameters.Add("@PONumber", SqlDbType.VarChar, 9).Value = sPONumber
                oCmd.Parameters.Add("@PLNumber", SqlDbType.VarChar, 8).Value = sPLNumber
                oCmd.Parameters.Add("@POid", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
                oCmd.CommandText = " select  @POid = PoId from ms_ElecSpares_PO where PONumber =  @PONumber  and   PLNumber = @PLNumber "
                oCmd.ExecuteScalar()
                If IIf(IsDBNull(oCmd.Parameters("@POid").Value), 0, oCmd.Parameters("@POid").Value) = 0 Then
                    oCmd.CommandText = " insert into ms_ElecSpares_PO ( PONumber , PLNumber ) values ( @PONumber , @PLNumber ) "
                    If oCmd.ExecuteNonQuery = 1 Then
                        sPO = " select  @POid = PoId from ms_ElecSpares_PO  where PONumber =  @PONumber  and   PLNumber = @PLNumber "
                        oCmd.CommandText = sPO
                        oCmd.ExecuteScalar()
                        If IIf(IsDBNull(oCmd.Parameters("@POid").Value), 0, oCmd.Parameters("@POid").Value) > 0 Then
                            oCmd.Parameters("@POid").Direction = ParameterDirection.Input
                            done = True
                        End If
                    Else
                        done = False
                    End If
                Else
                    done = True
                End If
                If done Then
                    oCmd.Parameters.Add("@NSIDNNo", SqlDbType.BigInt, 8).Value = lNSIDNno
                    oCmd.Parameters.Add("@NSIDNDate", SqlDbType.SmallDateTime, 4).Value = dateNSIDNDate
                    oCmd.Parameters.Add("@NSIDNDateTime", SqlDbType.SmallDateTime, 4).Value = dateNSIDNDateTime
                    oCmd.Parameters.Add("@POConsignee", SqlDbType.Int, 4).Value = intPOConsignee
                    oCmd.Parameters.Add("@PLRecdQty", SqlDbType.Float, 8).Value = decPLRecdQty
                    oCmd.Parameters.Add("@PLRecdOn", SqlDbType.SmallDateTime, 4).Value = datePLRecdOn
                    oCmd.Parameters.Add("@PORemarks", SqlDbType.VarChar, 250).Value = sPORemarks
                    oCmd.Parameters.Add("@SentToShopOn", SqlDbType.SmallDateTime, 4).Value = dateSentToShopOn
                    oCmd.Parameters.Add("@RecdFromShopOn", SqlDbType.SmallDateTime, 4).Value = dateRecdFromShopOn
                    oCmd.Parameters.Add("@WarGuar", SqlDbType.VarChar, 250).Value = sWarGuar
                    oCmd.Parameters.Add("@InVoiceNo", SqlDbType.VarChar, 50).Value = sInVoiceNo
                    oCmd.Parameters.Add("@InVoiceDate", SqlDbType.SmallDateTime, 4).Value = dateInVoiceDate
                    oCmd.Parameters("@POid").Direction = ParameterDirection.Input
                    oCmd.CommandText = " insert into ms_ElecSpares_nsidnno ( NSIDNno , NSIDNDate , NSIDNTime , POConsignee , PLRecdQty , PLRecdOn , PoId , Remarks , InVoiceNo , InVoiceDate ) " & _
                            " values ( @NSIDNNo , @NSIDNDate , @NSIDNDateTime , @POConsignee , @PLRecdQty , @PLRecdOn , @POid , @PORemarks , @InVoiceNo , @InVoiceDate ) "
                    If oCmd.ExecuteNonQuery = 1 Then
                        oCmd.CommandText = " insert into ms_ElecSpares_Register ( NSIDNno , SentToShopOn , RecdFromShopOn ) " & _
                            " values ( @NSIDNno , @SentToShopOn , @RecdFromShopOn )"
                        If oCmd.ExecuteNonQuery = 1 Then
                            oCmd.CommandText = " insert into ms_ElecSpares_WarGuar (  NSIDNno , WarGuar ) " & _
                                  " values (  @NSIDNNo , @WarGuar )"
                            If oCmd.ExecuteNonQuery = 1 Then
                                done = True
                            End If
                        End If
                    End If
                End If
            Catch exp As Exception
                done = False
                Throw New Exception("Generaring NSIDN  values failed !" & exp.Message)
            Finally
                If done Then
                    blnNextNumberGenerated = True
                    oCmd.Transaction.Commit()
                Else
                    blnNextNumberGenerated = False
                    oCmd.Transaction.Rollback()
                End If
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End Try
        End Sub
        Public Sub Update(ByVal NSIDN As Long)
            Dim oCmd As New SqlClient.SqlCommand()
            oCmd.Connection = rwfGen.Connection.ConObj
            Dim done As New Boolean()
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                oCmd.Parameters.Add("@NSIDNNo", SqlDbType.BigInt, 8).Value = lNSIDNno
                oCmd.Parameters.Add("@NSIDNDate", SqlDbType.SmallDateTime, 4).Value = dateNSIDNDate
                oCmd.Parameters.Add("@NSIDNDateTime", SqlDbType.SmallDateTime, 4).Value = dateNSIDNDateTime
                oCmd.Parameters.Add("@POConsignee", SqlDbType.Int, 4).Value = intPOConsignee
                oCmd.Parameters.Add("@PLRecdQty", SqlDbType.Float, 8).Value = decPLRecdQty
                oCmd.Parameters.Add("@PLRecdOn", SqlDbType.SmallDateTime, 4).Value = datePLRecdOn
                oCmd.Parameters.Add("@PORemarks", SqlDbType.VarChar, 250).Value = sPORemarks
                oCmd.Parameters.Add("@InVoiceDate", SqlDbType.SmallDateTime, 4).Value = dateInVoiceDate
                oCmd.Parameters.Add("@InVoiceNo", SqlDbType.VarChar, 50).Value = sInVoiceNo
                oCmd.CommandText = " update ms_ElecSpares_nsidnno set NSIDNDate = @NSIDNDate , NSIDNTime = @NSIDNDateTime , POConsignee = @POConsignee , " & _
                            " PLRecdQty = @PLRecdQty , PLRecdOn = @PLRecdOn , Remarks = @PORemarks , InVoiceNo = @InVoiceNo , InVoiceDate = @InVoiceDate  " & _
                            " where NSIDNno = @NSIDNNo "
                If oCmd.ExecuteNonQuery = 1 Then
                    done = True
                End If
            Catch exp As Exception
                done = False
                Throw New Exception("Updation of NSIDN  values failed !" & exp.Message)
            Finally
                If done Then
                    blnUpdation = True
                    oCmd.Transaction.Commit()
                Else
                    blnUpdation = False
                    oCmd.Transaction.Rollback()
                End If
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End Try
        End Sub
        Public Sub UpdateRegister(ByVal NSIDN As Long)
            Dim oCmd As New SqlClient.SqlCommand()
            oCmd.Connection = rwfGen.Connection.ConObj
            Dim done As New Boolean()
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                oCmd.Parameters.Add("@NSIDNNo", SqlDbType.BigInt, 8).Value = lNSIDNno
                oCmd.Parameters.Add("@SentToShopOn", SqlDbType.SmallDateTime, 4).Value = dateSentToShopOn
                oCmd.Parameters.Add("@RecdFromShopOn", SqlDbType.SmallDateTime, 4).Value = dateRecdFromShopOn
                oCmd.Parameters.Add("@PLAcceptedQty", SqlDbType.Float, 8).Value = decAccpQty
                oCmd.Parameters.Add("@PLRejQty", SqlDbType.Float, 8).Value = decRejQty
                oCmd.Parameters.Add("@Authority", SqlDbType.VarChar, 50).Value = sAuthority
                oCmd.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = sStatus
                oCmd.Parameters.Add("@LedgerNumber", SqlDbType.VarChar, 50).Value = sLedgerNumber
                oCmd.Parameters.Add("@Location", SqlDbType.VarChar, 50).Value = sLocation
                oCmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 50).Value = sRegRemarks
                oCmd.Parameters.Add("@NSDBRNo", SqlDbType.VarChar, 50).Value = sNSDBRNo
                oCmd.Parameters.Add("@NSDBRDate", SqlDbType.SmallDateTime, 4).Value = dateNSDBRDate
                oCmd.CommandText = " update ms_ElecSpares_Register set SentToShopOn = @SentToShopOn ,  RecdFromShopOn = @RecdFromShopOn ,  PLAcceptedQty = @PLAcceptedQty , " & _
                            " PLRejQty = @PLRejQty , Authority = @Authority , Status = @Status , LedgerNumber = @LedgerNumber , Location = @Location , Remarks = @Remarks " & _
                            " , NSDBRNo = @NSDBRNo , NSDBRDate = @NSDBRDate where NSIDNno = @NSIDNNo "
                If oCmd.ExecuteNonQuery = 1 Then
                    done = True
                End If
            Catch exp As Exception
                done = False
                Throw New Exception("Updation of NSIDN Register values failed !" & exp.Message)
            Finally
                If done Then
                    blnRegUpdation = True
                    oCmd.Transaction.Commit()
                Else
                    blnRegUpdation = False
                    oCmd.Transaction.Rollback()
                End If
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End Try
        End Sub
#End Region
    End Class
End Namespace

