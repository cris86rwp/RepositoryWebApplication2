Namespace SparesCell
    Public Class IDN
        Public Shared Function CheckAssessNo(ByVal AssessNo As String, ByVal PL As String, ByVal Cons As String) As String
            Dim Cmd As System.Data.SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Cmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            Cmd.CommandText = " select @cnt = count(*) from pm_spare_assessment_header " & _
                    " where consignee = @Cons and assessment_number = @AssessNo and pl_number = @PL "
            Try
                Cmd.Parameters.Add("@AssessNo", SqlDbType.VarChar, 50).Value = AssessNo
                Cmd.Parameters.Add("@PL", SqlDbType.VarChar, 50).Value = PL
                Cmd.Parameters.Add("@Cons", SqlDbType.VarChar, 50).Value = Cons
                If Cmd.Connection.State = ConnectionState.Closed Then Cmd.Connection.Open()
                Cmd.ExecuteScalar()
                If IIf(IsDBNull(Cmd.Parameters("@cnt").Value), 0, Cmd.Parameters("@cnt").Value) = 0 Then
                    Cmd.CommandText = " select @cnt = count(*) from pm_spare_assessment_header " & _
                                        " where consignee = @Cons and assessment_number = @AssessNo "
                    Cmd.ExecuteScalar()
                    If IIf(IsDBNull(Cmd.Parameters("@cnt").Value), 0, Cmd.Parameters("@cnt").Value) = 1 Then
                        CheckAssessNo = "This Assessment Number is with new PL Number !"
                    Else
                        CheckAssessNo = "InValid Assessment Number !"
                    End If
                End If
            Catch exp As Exception
                CheckAssessNo = exp.Message
            Finally
                If Cmd.Connection.State = ConnectionState.Open Then Cmd.Connection.Close()
                Cmd.Dispose()
            End Try
            Return CheckAssessNo
        End Function
        Public Shared Function IndentDetails(ByVal IndentNo As String) As DataSet
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select a.indent_number IndentNo , " & _
                " convert(varchar(10),a.indent_date,103) IndentDt , a.consignee Cons , " & _
                " indent_quantity Qty ,  a.estimated_value EstValue , " & _
                " a.Purpose , pl_number PLNumber , long_description" & _
                " from pm_indent_header a inner join pm_indent_detail b" & _
                " on a.indent_number = b.indent_number" & _
                " where a.indent_number = @IndentNo ;" & _
                " select * from ms_Sparecell_AssessmentLink " & _
                " where IndentNo = @IndentNo ;"
            Try
                da.SelectCommand.Parameters.Add("@IndentNo", SqlDbType.VarChar, 50).Value = IndentNo
                da.Fill(ds)
                IndentDetails = ds.Copy
            Catch exp As Exception
                IndentDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Function SaveAssessNo(ByVal AssessmentNo As String, ByVal IndentNo As String, Optional ByVal AssessID As Integer = 0) As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Parameters.Add("@IndentNo", SqlDbType.VarChar, 50).Value = IndentNo.Trim
                cmd.Parameters.Add("@AssessmentNo", SqlDbType.VarChar, 50).Value = AssessmentNo.Trim
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                If AssessID = 0 Then
                    cmd.CommandText = " insert into ms_Sparecell_AssessmentLink ( IndentNo ,  AssessmentNo )  " & _
                            " values ( @IndentNo , @AssessmentNo )"
                Else
                    cmd.Parameters.Add("@AssessID", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                    cmd.CommandText = " select @AssessID = AssessID from ms_Sparecell_AssessmentLink" & _
                        " where IndentNo = @IndentNo and  AssessID  = " & AssessID
                    cmd.ExecuteScalar()
                    If IIf(IsDBNull(cmd.Parameters("@AssessID").Value), 0, cmd.Parameters("@AssessID").Value) = 0 Then
                        Throw New Exception("InValid Assessment No !")
                    Else
                        cmd.Parameters("@AssessID").Direction = ParameterDirection.Input
                        cmd.CommandText = " update ms_Sparecell_AssessmentLink set AssessmentNo = @AssessmentNo  " & _
                            " where IndentNo = @IndentNo and AssessID = @AssessID "
                    End If
                End If
                If cmd.ExecuteNonQuery() > 0 Then
                    cmd.Transaction.Commit()
                    Return True
                Else
                    cmd.Transaction.Rollback()
                    Return False
                End If
            Catch exp As Exception
                Return False
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
            End Try
        End Function
    End Class
    <Serializable()> Public Class NSIDN
#Region "  tables "
        Public Shared Function CheckRejIDs(ByVal DocumentID As Long, ByVal AdviceDate As Date) As Boolean
            Dim Cmd As System.Data.SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Cmd.Parameters.Add("@SavedDate", SqlDbType.SmallDateTime, 4).Direction = ParameterDirection.Output
            Cmd.CommandText = " select @SavedDate = SavedDate from ms_vw_sparecell_BillsDocumentDetails " & _
                    " where DocumentID = @DocumentID "
            Try
                Cmd.Parameters.Add("@DocumentID", SqlDbType.BigInt, 8).Value = DocumentID
                If Cmd.Connection.State = ConnectionState.Closed Then Cmd.Connection.Open()
                Cmd.ExecuteScalar()
                If AdviceDate > IIf(IsDBNull(Cmd.Parameters("@SavedDate").Value), "1900-01-01", Cmd.Parameters("@SavedDate").Value) Then CheckRejIDs = True
            Catch exp As Exception
                CheckRejIDs = False
                Throw New Exception(exp.Message)
            Finally
                If Cmd.Connection.State = ConnectionState.Open Then Cmd.Connection.Close()
                Cmd.Dispose()
            End Try
        End Function
        Public Shared Function POPLNDetails(ByVal POnum As String, ByVal PLnum As String) As DataSet
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select  a.po_number , convert(varchar,a.po_date,103) po_date , " & _
                " a.po_value , convert(varchar,a.order_completion_date,103) PODueDate , c.name  " & _
                " from pm_po_header a , pm_supplier_master c  where  c.supplier_code = a.supplier_code " & _
                " and a.po_number = @PoNumber ; " & _
                " select a.po_number, a.pl_number, substring(a.long_description,1,60) pl_long_description , " & _
                " a.order_quantity , a.unit_rate , f.description UnitName   " & _
                " from pm_po_details a  left outer join pm_itemMasterOnly b on b.pl_number = a.pl_number " & _
                " left outer join code f on f.code = b.uom and f.application ='pm' and f.code_type ='UT'  " & _
                " where a.po_number = @PoNumber and a.pl_number = @PLnum ; " & _
                " exec ms_PoWarAndPaymentTerms @PoNumber   "
            Try
                da.SelectCommand.Parameters.Add("@PoNumber", SqlDbType.VarChar, 50).Value = POnum
                da.SelectCommand.Parameters.Add("@PLnum", SqlDbType.VarChar, 50).Value = PLnum
                da.Fill(ds)
                POPLNDetails = ds.Copy
            Catch exp As Exception
                POPLNDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function NSIDNDetails(ByVal NSIDNNo As String) As DataSet
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select  b.NsIDnId NSIDNno , convert(varchar,b.NsIDndate,103) NSIDNdate ,  " & _
            " a.PONumber, a.PLNumber , c.consigneename ConsigneeName, b.PLRecdQty  " & _
            " from ms_sparecell_po a inner join ms_sparecell_nsidnno b  " & _
            " on b.poid = a.poid   inner join ms_sparecell_consignee c  " & _
            " on c.consignee = b.poconsignee  " & _
            " where b.NsIDnId = @NSIDNNo ; " & _
            " SELECT * from ms_IMBRegister where NSIDNid = @NSIDNNo; " & _
            " SELECT COUNT(*) from ms_IMBRegister where NSIDNid = @NSIDNNo ; " & _
            " SELECT COUNT(*) from ms_NSGatePass where NSIDNid = @NSIDNNo; " & _
            " SELECT  * from ms_NSGatePass where NSIDNid = @NSIDNNo ; " & _
            " SELECT  * from ms_vw_NsIdnLocation where NSIDNid = @NSIDNNo ; " & _
            " select count(*)  from ms_sparecell_nsidnbill where NSIDNid = @NSIDNNo ;" & _
            " select count(*)  from ms_sparecell_nsidnno where NSIDNid = @NSIDNNo " & _
            " SELECT  * from ms_imb_store  order by locationID "
            Try
                da.SelectCommand.Parameters.Add("@NSIDNNo", SqlDbType.VarChar, 50).Value = NSIDNNo
                da.Fill(ds)
                NSIDNDetails = ds.Copy
            Catch exp As Exception
                NSIDNDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function GetSuppliers(ByVal FrDt As Date, ByVal ToDt As Date) As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            da.SelectCommand = New SqlClient.SqlCommand()
            da.SelectCommand.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
            da.SelectCommand.CommandText = " select distinct supplier , supplier_code from ms_vw_Sparecell_PODues where  po_date  between @FrDate and  @ToDate    " & _
                        " and consignee in ( select consigneename from ms_sparecell_consignee where consignee <> 100 ) order by supplier "
            da.SelectCommand.Parameters.Add("@FrDate", SqlDbType.SmallDateTime, 4)
            da.SelectCommand.Parameters("@FrDate").Direction = ParameterDirection.Input
            da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.SmallDateTime, 4)
            da.SelectCommand.Parameters("@ToDate").Direction = ParameterDirection.Input
            da.SelectCommand.CommandTimeout = "1080000"
            Try
                da.SelectCommand.Parameters("@FrDate").Value = FrDt
                da.SelectCommand.Parameters("@ToDate").Value = ToDt
                da.Fill(ds)
                GetSuppliers = ds.Tables(0).Copy
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function CheckNSIDN(ByVal NSIDNno As Long) As Boolean
            Dim Cmd As System.Data.SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Cmd.Parameters.Add("@Cnt", SqlDbType.Int, 4)
            Cmd.Parameters("@Cnt").Direction = ParameterDirection.Output
            Cmd.CommandText = " select @Cnt = count(*) from ms_sparecell_nsidnno where nsidnid = @NSIDNno "
            Try
                Cmd.Parameters.Add("@NSIDNno", SqlDbType.BigInt, 8).Value = NSIDNno
                If Cmd.Connection.State = ConnectionState.Closed Then Cmd.Connection.Open()
                Cmd.ExecuteScalar()
                CheckNSIDN = IIf(IsDBNull(Cmd.Parameters("@Cnt").Value), 0, Cmd.Parameters("@Cnt").Value)
            Catch exp As Exception
                CheckNSIDN = False
                Throw New Exception(exp.Message)
            Finally
                If Cmd.Connection.State = ConnectionState.Open Then Cmd.Connection.Close()
                Cmd.Dispose()
            End Try
        End Function
        Public Shared Function NSBillsList(ByVal ListType As Integer, ByVal ListNumber As Integer) As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            da.SelectCommand = New SqlClient.SqlCommand()
            da.SelectCommand.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
            Dim strNSIDNNo As String
            If ListType = 0 Then
                'If ListNumber = 0 Then
                '    da.SelectCommand.CommandText = " select distinct PONumber  FROM ms_sparecell_po " & _
                '                                   " order by PONumber desc "
                'Else
                '    da.SelectCommand.CommandText = " select distinct NsIDnId  FROM ms_sparecell_nsidnno " & _
                '" order by NsIDnId desc "
                'End If
                da.SelectCommand.CommandText = " select distinct NsIDnId  FROM ms_sparecell_nsidnbill " & _
                                                " order by NsIDnId desc "
            ElseIf ListType = 1 Then
                da.SelectCommand.CommandText = " select distinct nsprc_number  FROM ms_vw_sparecell_PRCDetails " & _
                                               " order by nsprc_number desc "
            ElseIf ListType = 2 Then
                da.SelectCommand.CommandText = " select distinct PIid  FROM ms_vw_sparecell_PIDetails " & _
                                               " order by PIid desc "
            End If

            Try
                da.Fill(ds)
                NSBillsList = ds.Tables(0)
            Catch exp As Exception
                NSBillsList = Nothing
                If strNSIDNNo = "Yet to develop !" Then
                    Throw New Exception("Yet to develop !")
                Else
                    Throw New Exception(exp.Message)
                End If
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function populateNSPRCNo() As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            da.SelectCommand = New SqlClient.SqlCommand()
            da.SelectCommand.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
            Dim strNSIDNNo As String
            da.SelectCommand.CommandText = " select nsprc_number  from ms_sparecell_PRC order by nsprc_number desc "
            Try
                da.Fill(ds)
                populateNSPRCNo = ds.Tables(0)
            Catch exp As Exception
                populateNSPRCNo = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetPIPONumberDetails(ByVal PONumber As String) As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            da.SelectCommand = New SqlClient.SqlCommand()
            da.SelectCommand.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
            Dim strNSIDNNo As String
            da.SelectCommand.CommandText = " select Consignee , InvoiceNumber , convert(varchar(11),InvoiceDate,103) InvoiceDate , Para2 , convert(varchar(11), PIDate ,103 ) PIDate , PLNumber , Qty , Amount , NSIDNId , PIid , PIDetailsid from ms_vw_sparecell_PIDetails  where PONumber = '" & PONumber.Trim & "'"
            Try
                da.Fill(ds)
                GetPIPONumberDetails = ds.Tables(0)
            Catch exp As Exception
                GetPIPONumberDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetPIPONumbers() As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            da.SelectCommand = New SqlClient.SqlCommand()
            da.SelectCommand.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
            Dim strNSIDNNo As String
            da.SelectCommand.CommandText = " select distinct PONumber from ms_vw_sparecell_PIDetails order by PONumber desc "
            Try
                da.Fill(ds)
                GetPIPONumbers = ds.Tables(0)
            Catch exp As Exception
                GetPIPONumbers = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetConsignee(ByVal Group As String, ByVal UserId As String) As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()

            da.SelectCommand.CommandText = " select description , dbo.ms_fn_ConsigneeName(description) ConsigneeName from ms_group_location where purpose = 'Sub-Stores' " & _
                    " and group_code = (select group_code from mis.dbo.menu_your_password " & _
                    " where employee_code = @UserId and application = 'MSS' 	and group_code = @Group ) "
            Try
                da.SelectCommand.Parameters.Add("@Group", SqlDbType.VarChar, 7).Value = Group.Trim
                da.SelectCommand.Parameters.Add("@UserId", SqlDbType.VarChar, 6).Value = UserId.Trim
                da.Fill(ds, "Consignee")
                If Trim(IIf(IsNothing(ds.Tables("Consignee").Rows(0)(0)), "", ds.Tables("Consignee").Rows(0)(0))).Length > 0 Then Return ds.Tables("Consignee")
            Catch exp As Exception
                Return Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function VerifyNSDBRNumber(ByVal NSDBRNumber As String, ByVal NsIDnId As Long) As DataSet
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Dim strNSDBRNo As String
            da.SelectCommand.CommandText = " select * from pm_nonstock_receipt a inner join ms_vw_SpareCellNSIDNs b " & _
                " on  b.ConsigneeName = a.consignee and b.PLNumber = a.pl_number and b.PONumber = a.po_number and b.PLRecdQty = a.received_quantity " & _
                " where a.nsdbr_number = '" & NSDBRNumber.Trim & "' and b.NSIDNDate >= a.received_date and b.NsIDnId =  " & NsIDnId & " ; " & _
                " select a.po_number , a.pl_number ,  a.consignee , a.received_quantity  , a.received_date  from pm_nonstock_receipt a where a.nsdbr_number = '" & NSDBRNumber.Trim & "' ; " & _
                " select b.PONumber  , b.PLNumber , b.ConsigneeName ,  b.PLRecdQty ,  b.NSIDNDate from ms_vw_SpareCellNSIDNs b  where b.NsIDnId = " & NsIDnId & " ;  "
            Try
                da.Fill(ds)
                VerifyNSDBRNumber = ds.Copy
            Catch exp As Exception
                VerifyNSDBRNumber = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function populateGrid(ByVal NsIDnId As Long) As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Dim dt As New DataTable()
            da.SelectCommand = New SqlClient.SqlCommand()
            da.SelectCommand.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
            Dim strGrid As String
            strGrid = " select  NSIDNid , nsdbr_number , convert(varchar(11),sentToHQon,103) sentToHQon , Remarks , BillAmount " & _
                        " from ms_sparecell_nsidnbill where NSIDNid = " & NsIDnId & " "
            da.SelectCommand.CommandText = strGrid
            Try
                da.Fill(ds)
                populateGrid = ds.Tables(0)
            Catch exp As Exception
                populateGrid = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function populateNSIDNNo(Optional ByVal PONumber As String = "") As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            da.SelectCommand = New SqlClient.SqlCommand()
            da.SelectCommand.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
            Dim strNSIDNNo As String
            'strNSIDNNo = " select nsidnid  from ms_sparecell_nsidnno where not (RecdByShopOn is null or  RecdByShopOn = '1900-01-01 00:00:00') "
            'strNSIDNNo = " select nsidnid  from ms_sparecell_nsidnno order by nsidnid desc" 'where not (RecdByShopOn is null or  RecdByShopOn = '1900-01-01 00:00:00') "
            If PONumber.Trim.Length = 0 Then
                da.SelectCommand.CommandText = "select nsidnid  from ms_sparecell_nsidnno order by nsidnid desc "
            Else
                da.SelectCommand.CommandText = " select nsidnid from ms_sparecell_po a inner join ms_sparecell_nsidnno b" & _
                                " on a.POid = b.POid where PONumber = '" & PONumber.Trim & "' "
            End If
            Try
                da.Fill(ds)
                populateNSIDNNo = ds.Tables(0)
            Catch exp As Exception
                populateNSIDNNo = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetNSIDNsStatus(ByVal FromDate As Date, ByVal ToDate As Date, ByVal int As Int16) As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            da.SelectCommand = New SqlClient.SqlCommand()
            da.SelectCommand.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
            If int = 0 Then
                da.SelectCommand.CommandText = " declare @frDt smalldatetime ,  @toDt smalldatetime  " & _
                                " select @frDt = '" & Format(CDate(FromDate), "yyyy/MM/dd 00:00:00") & "' " & _
                                " select @toDt = '" & Format(CDate(ToDate), "yyyy/MM/dd 00:00:00") & "' " & _
                                " select * ,  convert(varchar(11),dbo.ms_fn_NsIdnSentToHQon(nsidnid),103) SentToHQon from ms_vw_NsIdnsDetails where NSIDNDate between @frDt and @toDt "
            ElseIf int = 1 Then
                da.SelectCommand.CommandText = " declare @frDt smalldatetime ,  @toDt smalldatetime  " & _
                                " select @frDt = '" & Format(CDate(FromDate), "yyyy/MM/dd 00:00:00") & "' " & _
                                " select @toDt = '" & Format(CDate(ToDate), "yyyy/MM/dd 00:00:00") & "' " & _
                                " select dbo.pm_supplier_master.name Supplier, NsIDnId , NSIDNDate , ConsigneeName , PLNumber , PONumber ," & _
                                " PLRecdQty , PLAcceptedQty, PLRejQty, Status, IDNRemarks, code.description UOM   " & _
                                " from ms_vw_SpareCellIDN a INNER JOIN dbo.pm_po_details on  pm_po_details.po_number = a.PONumber and    " & _
                                " pm_po_details.pl_number = a.PLNumber " & _
                                " INNER JOIN  dbo.pm_po_header  ON dbo.pm_po_details.po_number = dbo.pm_po_header.po_number " & _
                                " INNER JOIN dbo.pm_supplier_master   ON dbo.pm_po_header.supplier_code = dbo.pm_supplier_master.supplier_code " & _
                                " INNER JOIN dbo.pm_item_Master ON dbo.pm_po_details.pl_number = dbo.pm_item_Master.pl_number     " & _
                                " inner join dbo.code ON dbo.code.code = dbo.pm_item_Master.uom  and application = 'PM' and code_type = 'UT'" & _
                                " where NSIDNDate between @frDt and @toDt order by dbo.pm_supplier_master.name  "
            ElseIf int = 2 Then
                da.SelectCommand.CommandText = "ms_sp_Sparecell_PORejNotSupplied"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.Add("@frDt", SqlDbType.SmallDateTime, 4).Value = CDate(FromDate)
                da.SelectCommand.Parameters.Add("@toDt", SqlDbType.SmallDateTime, 4).Value = CDate(ToDate)

            ElseIf int = 3 Then
                da.SelectCommand.CommandText = "ms_sp_Sparecell_PORejAdviceList"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.Add("@frDt", SqlDbType.SmallDateTime, 4).Value = CDate(FromDate)
                da.SelectCommand.Parameters.Add("@toDt", SqlDbType.SmallDateTime, 4).Value = CDate(ToDate)
            End If
            Try
                da.Fill(ds)
                GetNSIDNsStatus = ds.Tables(0)
            Catch exp As Exception
                GetNSIDNsStatus = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function PODetailsQry(ByVal PONumber As String) As DataSet
            Dim strPOdetails As String
            strPOdetails = " declare @po_number as varchar(9)  " & _
                        " select @po_number = '" & PONumber.Trim & "' " & _
                        " select  a.po_number , convert(varchar(11) ,a.po_date ,103) po_date , a.po_value , convert(varchar(11) ,a.order_completion_date ,103)  PODueDate , c.name   " & _
                        " from pm_po_header a , pm_supplier_master c   " & _
                        " where  c.supplier_code = a.supplier_code and a.po_number = @po_number ;  " & _
                        " select a.po_number, a.pl_number, substring(a.long_description,1,100) pl_desc , a.order_quantity , a.unit_rate , f.description UnitName    " & _
                        " from pm_po_details a  left outer join pm_itemMasterOnly b  " & _
                        " on b.pl_number = a.pl_number      left outer join code f  " & _
                        " on f.code = b.uom and f.application ='pm' and f.code_type ='UT'   " & _
                        " where a.po_number = @po_number ;   " & _
                        " select po_number , pl_number , po_quantity OrderQty , consignee from ms_vw_NsPoDetails where po_number = @po_number ;" & _
                        " exec  ms_PoWarAndPaymentTerms @po_number  ;  " & _
                        " select b.NsIDnId NSIDNId, convert(varchar(11) , b.NSIDNDate ,103) NSIDNDate , a.PONumber, a.PLNumber , d.consigneename Consi , b.PLRecdQty PLRecdQty " & _
                        " , convert(varchar(11) , b.PLRecdOn ,103) PLRecdOn from ms_sparecell_po a inner join ms_sparecell_nsidnno b  " & _
                        " on b.poid = a.poid     inner join ms_sparecell_consignee d  " & _
                        " on d.Consignee = b.POConsignee  where a.PONumber = @po_number ; " & _
                        " select b.NsIDnId NSIDNId, a.PONumber, a.PLNumber , d.consigneename Consi , b.PLRecdQty RecdQty , " & _
                        " c.PLAcceptedQty AccpQty , c.PLRejQty RejQty , c.Status  , convert(varchar(11) , c.SentBackToSpareCellOn ,103) AccpRejDate , convert(varchar(11) , b.RecdByShopOn ,103) RecdFromCons     " & _
                        " from ms_sparecell_po a inner join ms_sparecell_nsidnno b  " & _
                        " on b.poid = a.poid inner join ms_IMBRegister c  " & _
                        " on c.NsIdnId = b.NsIdnId   inner join ms_sparecell_consignee d  " & _
                        " on d.Consignee = b.POConsignee  where a.PONumber = @po_number ; " & _
                        " select po_number , pl_number , delivery_challan_number DCNumber , convert(varchar(11) , delivery_challan_date ,103) DCdate , nsdbr_number , consignee , " & _
                        " convert(varchar(11) , received_date ,103) received_date , received_quantity " & _
                        " from pm_nonstock_receipt  where PO_Number = @po_number ; " & _
                        " exec ms_sp_sparecellGetNsdbrNumber @po_number ;" & _
                        " SELECT rpt_StoresPrintVIEW.bill_serial_number, convert(varchar(11) , rpt_StoresPrintVIEW.bill_date, 103) bill_date , rpt_StoresPrintVIEW.po_number, rpt_StoresPrintVIEW.bill_description, rpt_StoresPrintVIEW.bill_amount, rpt_StoresPrintVIEW.AMOUNT_PAYABLE, rpt_StoresPrintVIEW.DEDUCTION, rpt_StoresPrintVIEW.VOUCHER_NUMBER, rpt_StoresPrintVIEW.code_description, rpt_StoresPrintVIEW.supplier_code, rpt_StoresPrintVIEW.name " & _
                        " FROM wap.dbo.rpt_StoresPrintVIEW rpt_StoresPrintVIEW " & _
                        " WHERE rpt_StoresPrintVIEW.po_number = @po_number and code_description = 'HQ OFFICE/MECHANICAL' " & _
                        " ORDER BY rpt_StoresPrintVIEW.bill_serial_number ASC ; " & _
                        " select a.po_number PO_NUMBER , b.name SUPPLIER,a.bill_serial_number BILL_NO , " & _
                        " convert(varchar,a.bill_Date,103) BILL_DATE , a.bill_amount BILL_AMOUNT , a.deduction DEDUCTION , " & _
                        " a.amount_payable AMOUNT_PAYABLE , c.cheque_number CHEQUE_NUMBER,convert(varchar,c.pmr_date,103) CHEQUE_DATE " & _
                        " from fm_supplier_bill_header a , pm_supplier_master b,fm_pmr_register c " & _
                        " where a.supplier_code = b.supplier_code and a.co6_number = c.co6_number and " & _
                        " c.section_Code = '04' and a.po_number = @po_number order by c.pmr_date desc ;" & _
                        " select Subject , ID , Dt from ms_vw_SpareCell_BillsList " & _
                        " where PONumber = @po_number order by Sl , ID "
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = strPOdetails
            Try
                da.Fill(ds)
                PODetailsQry = ds.Copy
            Catch exp As Exception
                PODetailsQry = Nothing
                Throw New Exception(exp.Message)
            Finally
                strPOdetails = Nothing
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function NSPODetails(ByVal PONumber As String, Optional ByVal CheckListID As Long = 0) As DataSet
            Dim strPODetails As String
            If CheckListID = 0 Then
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
            Else
                If CheckListID < 39 Then
                    strPODetails = " select  a.po_number , a.po_date , a.po_value ,a.order_completion_date PODueDate , c.name " & _
                                                   " from pm_po_header a , pm_supplier_master c  where  c.supplier_code = a.supplier_code and a.po_number = '" & PONumber.Trim & "' ;" & _
                                                   " select PONumber , po_date , Supplier , pl_number , pl_desc , QtyAsPerPO , Rate NSIDNId , ActualQty  , " & _
                                                   " UnitName , DeliveryDate , TotalValue , DueDate , Delivery , Quantity , Others , OtherPayment , SpecialConditions , " & _
                                                   " Erection , DateOfReceipt , DateOfSending , AnyOtherEnclosures ,  CheckListItemsID , CheckListID  from ms_vw_sparecell_BillsCheckListItemsOld where PONumber = '" & PONumber.Trim & "' and  CheckListID = " & CheckListID & " ; " & _
                                                   " exec  ms_PoWarAndPaymentTerms '" & PONumber.Trim & "' ; select pl_number , pl_desc , QtyAsPerPO , Rate NSIDNId , UnitName , ActualQty ,  DeliveryDate ,CheckListItemsID from ms_vw_sparecell_BillsCheckListItems "
                Else
                    strPODetails = " select  a.po_number , a.po_date , a.po_value ,a.order_completion_date PODueDate , c.name " & _
                               " from pm_po_header a , pm_supplier_master c  where  c.supplier_code = a.supplier_code and a.po_number = '" & PONumber.Trim & "' ;" & _
                               " select PONumber , po_date , Supplier , pl_number , pl_desc , QtyAsPerPO , Rate NSIDNId , ActualQty  , " & _
                               " UnitName , DeliveryDate , TotalValue , DueDate , Delivery , Quantity , Others , OtherPayment , SpecialConditions , " & _
                               " Erection , DateOfReceipt , DateOfSending , AnyOtherEnclosures ,  CheckListItemsID , CheckListID  from ms_vw_sparecell_BillsCheckListItems where PONumber = '" & PONumber.Trim & "' and  CheckListID = " & CheckListID & " ; " & _
                               " exec  ms_PoWarAndPaymentTerms '" & PONumber.Trim & "' ; select pl_number , pl_desc , QtyAsPerPO , Rate NSIDNId , UnitName , ActualQty ,  DeliveryDate ,CheckListItemsID from ms_vw_sparecell_BillsCheckListItems "
                End If

            End If

            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = strPODetails
            Try
                da.Fill(ds)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                strPODetails = Nothing
                da.Dispose()
            End Try
            Return ds
        End Function
        Public Shared Function GetNSIDNsDetails(ByVal NsIDnId As Long) As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Dim dt As New DataTable()
            da.SelectCommand = New SqlClient.SqlCommand()
            da.SelectCommand.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
            da.SelectCommand.CommandText = " select NsIDnId , " & _
                " convert(varchar(10),NSIDNDate,103) NSIDNDate  , PLRecdQty Qty , convert(varchar(10),PLRecdOn,103) PLRecdOn , " & _
                " convert(varchar(10),SentToShopOn,103) SentDt , convert(varchar(10),RecdByShopOn,103) RecdDt , " & _
                " Remarks from ms_sparecell_nsidnno  where NsIDnId  = '" & NsIDnId & "' "
            Try
                da.Fill(ds)
                GetNSIDNsDetails = ds.Tables(0)
            Catch exp As Exception
                GetNSIDNsDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetNSIDNidsForDelete() As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            da.SelectCommand = New SqlClient.SqlCommand()
            da.SelectCommand.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
            da.SelectCommand.CommandText = " select NsIDnId from ms_sparecell_nsidnno " & _
                          " where NsIDnId  not in  ( select NsIDnId  from ms_IMBREGISTER " & _
                          " where NsIDnId  not in  ( select NsIDnId  from ms_sparecell_nsidnbill ) ) " & _
                          " order by NsIDnId desc "
            Try
                da.Fill(ds)
                GetNSIDNidsForDelete = ds.Tables(0)
            Catch exp As Exception
                GetNSIDNidsForDelete = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function PORegisterDetails(ByVal POnum As String, ByVal PLnum As String) As DataSet
            Dim strPOdetails As String
            strPOdetails = " select  a.po_number , convert(varchar,a.po_date,103) po_date , a.po_value , convert(varchar,a.order_completion_date,103) PODueDate , c.name  from pm_po_header a inner join  pm_supplier_master c  on  c.supplier_code = a.supplier_code where a.po_number = '" & POnum.Trim & "' ;"
            strPOdetails &= " select a.po_number, a.pl_number, substring(a.long_description,1,60) pl_long_description , a.order_quantity , a.unit_rate , f.description UnitName   from pm_po_details a  left outer join pm_itemMasterOnly b on b.pl_number = a.pl_number      left outer join code f on f.code = b.uom and f.application ='pm' and f.code_type ='UT'  where a.po_number = '" & POnum.Trim & "' and a.pl_number = '" & PLnum.Trim & "'; "
            strPOdetails &= " exec ms_PoWarAndPaymentTerms '" & POnum.Trim & "'   "
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = strPOdetails
            Try
                da.Fill(ds)
                PORegisterDetails = ds.Copy
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                strPOdetails = Nothing
                ds.Dispose()
                da.Dispose()
            End Try
            Return PORegisterDetails
        End Function
        Public Shared Function NSIDNRegisterDetails(ByVal NSIDNno As Long) As DataSet
            Dim strNSIDN As String
            strNSIDN = " select  b.NsIDnId NSIDNno , convert(varchar,b.NsIDndate,103) NSIDNdate ,  " & _
                   " a.PONumber, a.PLNumber , c.consigneename ConsigneeName, b.PLRecdQty , convert(varchar,b.RecdByShopOn,103) RecdByShopOn " & _
                   " from ms_sparecell_po a inner join ms_sparecell_nsidnno b  " & _
                   " on b.poid = a.poid   inner join ms_sparecell_consignee c  " & _
                   " on c.consignee = b.poconsignee  " & _
                   " where b.NsIDnId = " & NSIDNno & " ;" & _
                   " SELECT * from ms_IMBRegister where NSIDNid = '" & NSIDNno & "'; " & _
                    " SELECT COUNT(*) from ms_IMBRegister where NSIDNid = '" & NSIDNno & "' ; " & _
                    " SELECT COUNT(*) from ms_NSGatePass where NSIDNid = '" & NSIDNno & "'; " & _
                    " SELECT  * from ms_NSGatePass where NSIDNid = '" & NSIDNno & "' ; " & _
                    " SELECT  * from ms_vw_NsIdnLocation where NSIDNid = '" & NSIDNno & "' ; " & _
                    " select count(*)  from ms_sparecell_nsidnbill where NSIDNid = '" & NSIDNno & "' ;" & _
                    " select count(*)  from ms_sparecell_nsidnno where NSIDNid = '" & NSIDNno & "' ; " & _
                    " SELECT  * from ms_imb_store  order by locationID "
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = strNSIDN
            Try
                da.Fill(ds)
                NSIDNRegisterDetails = ds.Copy
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                strNSIDN = Nothing
                ds.Dispose()
                da.Dispose()
            End Try
            Return NSIDNRegisterDetails
        End Function
        Public Shared Function IsValidPO(ByVal PONumber As String) As Boolean
            Dim oCmd As New SqlClient.SqlCommand()
            Try
                oCmd.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = " select @Cnt = count(*)  from ms_vw_NsPoDetails where  po_number = @PONumber "
                oCmd.Parameters.Add("@PONumber", SqlDbType.VarChar, 9)
                oCmd.Parameters("@PONumber").Direction = ParameterDirection.Input
                oCmd.Parameters("@PONumber").Value = PONumber.Trim
                oCmd.Parameters.Add("@Cnt", SqlDbType.Int, 4)
                oCmd.Parameters("@Cnt").Direction = ParameterDirection.Output
                oCmd.ExecuteScalar()
                IsValidPO = IIf(IsDBNull(oCmd.Parameters("@Cnt").Value), 0, oCmd.Parameters("@Cnt").Value)
            Catch exp As Exception
                IsValidPO = False
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End Try
        End Function
        Public Shared Function IsNotActivePO(ByVal PONumber As String) As Boolean
            Dim POStatus As String
            Dim oCmd As New SqlClient.SqlCommand()
            Try
                oCmd.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = " select @po_status = po_status from pm_po_header where  po_number = @PONumber "
                oCmd.Parameters.Add("@PONumber", SqlDbType.VarChar, 9)
                oCmd.Parameters("@PONumber").Direction = ParameterDirection.Input
                oCmd.Parameters("@PONumber").Value = PONumber.Trim
                oCmd.Parameters.Add("@po_status", SqlDbType.VarChar, 4)
                oCmd.Parameters("@po_status").Direction = ParameterDirection.Output
                oCmd.ExecuteScalar()
                POStatus = IIf(IsDBNull(oCmd.Parameters("@po_status").Value), "", oCmd.Parameters("@po_status").Value)
                If POStatus.ToUpper.Trim = "CAN" Then IsNotActivePO = True
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End Try
            Return IsNotActivePO
        End Function
        Public Shared Function GetConsignee(ByVal Group As String) As DataTable
            Dim str As String
            'If Group = "EAAC" Then
            '    str = "select consignee , consigneename  from ms_ElecSpares_Consignee  order by consignee "
            'Else
            str = "select consignee , consigneename  from ms_sparecell_consignee  order by consignee "
            'End If
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
                ds = Nothing
                da.Dispose()
            End Try
            Return dt
        End Function
        Public Shared Function GetNSIDNs() As DataTable
            Dim str As String
            Dim dt As New DataTable()
            'str = " select NsIDnId from ms_sparecell_nsidnno where NsIDnId not in ( select NsIDnId from ms_sparecell_nsidnbill ) order by NsIDnId desc "
            str = " select NsIDnId from ms_sparecell_nsidnno  order by NsIDnId desc "
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
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
        Public Shared Function NSIDNDetails(ByVal NSIDNno As Long) As DataTable
            Dim str As String
            str = "  select b.NsIDnId , b.NSIDNDate , b.PO_No PONumber , b.pl_number PLNumber ,  b.PLRecdOn , " & _
                        " b.ConsigneeName  Consignee , b.PLRecdQty ,  b.SentToShopOn , b.RecdByShopOn, b.Remarks , dbo.ms_fn_PlUnitName(b.pl_number) Unit " & _
                        " , b.po_date , b.PO_QTY , InVoiceNo , InVoiceDate from ms_vw_NsIdnsDetails b  where b.NsIDnId =   " & NSIDNno & " ; "
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
        Public Shared Function BillNotingPODetails(ByVal PO As String, Optional ByVal NSIDNNo As Long = 0) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim dt As New DataTable()
            Dim ds As New DataSet()
            If NSIDNNo = 0 Then
                da.SelectCommand.CommandText = " select  ID , Dt  , NSIDNno , BillPercent from ms_vw_SpareCell_BillsList a inner join ms_sparecell_BillsNoting b " & _
                                    " on NotingID = ID where PONumber = '" & PO.Trim & "' and a.subject = 'Forwarding of NS Bill' order by Sl , ID  "
            Else
                da.SelectCommand.CommandText = " select  ID , Dt  , NSIDNno , BillPercent from ms_vw_SpareCell_BillsList a inner join ms_sparecell_BillsNoting b " & _
                                                    " on NotingID = ID where PONumber = '" & PO.Trim & "' and NSIDNNo = " & NSIDNNo & "  and a.subject = 'Forwarding of NS Bill' order by Sl , ID  "
            End If
            Try
                da.Fill(ds)
                dt = ds.Tables(0).Copy
            Catch exp As Exception
                dt = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
            Return dt
        End Function
        Public Shared Function BillNotingDetails(ByVal NotingID As Long) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim dt As New DataTable()
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select * from ms_sparecell_BillsNoting where NotingID = " & NotingID & " "
            Try
                da.Fill(ds)
                dt = ds.Tables(0).Copy
            Catch exp As Exception
                dt = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
            Return dt
        End Function
        Public Shared Function CheckPO(ByVal PONumber As String) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select order_type , po_status from pm_po_header where po_number = '" & PONumber & "' "
            Try
                da.Fill(ds)
                CheckPO = ds.Tables(0).Copy
            Catch exp As Exception
                CheckPO = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function SpareCellPODetails(ByVal PONumber As String, Optional ByVal NSIDNno As Long = 0, Optional ByVal Bill As Boolean = False, Optional ByVal DocumnetType As Integer = 0, Optional ByVal POType As String = "") As DataTable
            Dim strPODetails As String
            If NSIDNno = 0 Then
                strPODetails = " select  NSIDNId , NSIDNDate , PONumber ,  " & _
                               " convert(varchar(10),a.po_date,103) po_date , rtrim(name) Firm , PLNumber , address , " & _
                               " pin_code , phone_number , fax_number , telex_number , email_id , contact_person  , dbo.ms_fn_PoWarAndPaymentTerms(PONumber) PT , short_description , po_quantity , UnitName , unit_rate " & _
                               " from ms_vw_sparecell_po_nsidnno a inner join ms_vw_NsPoDetails b " & _
                               " on PO_Number = PONumber " & _
                               " where PONumber = '" & PONumber.Trim & "' and NsIdnId not in ( select NSIDNno from ms_sparecell_BillsPending where isnull( Deleted , '0') = '0' )"
                If Not POType Is Nothing Then
                    If POType.ToLower = "pi" Then
                        strPODetails = "select 0 NSIDNId , '' NSIDNDate , po_number , convert(varchar(10),po_date,103) po_date , rtrim(Supplier)  Firm , pl_number PLNumber , '' address , " & _
                            " '' pin_code , '' phone_number , '' fax_number , '' telex_number , '' email_id , " & _
                            " '' contact_person , dbo.ms_fn_PoWarAndPaymentTerms(po_number) PT  , short_description , po_quantity , UnitName , unit_rate from ms_vw_NsPoDetails where po_number = '" & PONumber.Trim & "'"
                    End If
                End If
            Else
                strPODetails = " select * from ms_vw_sparecell_po_nsidnno where PONumber = '" & PONumber.Trim & "' and NSIDNId =   " & NSIDNno & "  "
            End If
            If Bill Then
                strPODetails = " select a.* , PLAcceptedQty*unit_rate  Amount , '' Qty , '' DueDate , dbo.ms_fn_PlShortName(a.PLNumber) Description , dbo.ms_fn_PlUnitName(a.PLNumber) Unit , dbo.ms_fn_PoWarAndPaymentTerms(a.PONumber) PT , " & _
                " PIDetails = ( select count(*) from ms_vw_sparecell_PIDetails  where PONumber = '" & PONumber.Trim & "' and isnull(NsIDnId,'') <> '') ," & _
                " PRCDetails = ( select count(*) from ms_vw_sparecell_PRCDetails  where PONumber = '" & PONumber.Trim & "' and isnull(NsIDnId,'') <> '')  , " & _
                " convert(varchar(10),PLRecdOn,103) PLRecdOn , PLAcceptedQty AccQty " & _
                " from ms_vw_sparecell_po_nsidnno a inner join ms_vw_SpareCellIDN b on a.NsIDnId = b.NsIDnId inner join pm_po_header c on a.PONumber = c.po_number " & _
                " inner join pm_po_details d on d.PO_Number = c.po_number and d.PL_Number = a.PLNumber " & _
                " where a.PONumber = '" & PONumber.Trim & "' and a.status not in ( 'PENDING' , 'Select', 'REJECTED' ); "
            End If
            If DocumnetType = 1 Or DocumnetType = 2 Then
                strPODetails = " select  PLNumber , Description , Qty , po_date , Firm  ,  Unit , convert(varchar(10), DueDate , 103) DueDate , dbo.ms_fn_PoWarAndPaymentTerms(PONumber) PT  from ms_vw_sparecell_podetails where PONumber = '" & PONumber.Trim & "' "
            ElseIf DocumnetType = 4 Then
                'strPODetails = " select a.PLNumber , Description , Qty , po_date , Firm  ,  Unit ,  PLAcceptedQty AcpQty , Status , LedgerNumber , NsIDnId  " & _
                '        " from ms_vw_sparecell_podetails a inner join ms_vw_SpareCellIDN b on a.PONumber = b.PONumber and a.PLNumber = b.PLNumber where a.PONumber = '" & PONumber.Trim & "' "
                strPODetails = " select a.PLNumber , Description , c.Qty , po_date , Firm  ,  Unit ,  PLAcceptedQty AcpQty , Status , LedgerNumber , b.NsIDnId   " & _
                    " from ms_vw_sparecell_podetails a inner join ms_vw_SpareCellIDN b on a.PONumber = b.PONumber and a.PLNumber = b.PLNumber  " & _
                    " inner join ms_vw_sparecell_PIDetails c on c.PONumber = b.PONumber and c.PLNumber = b.PLNumber and c.NsIDnId = b.NsIDnId " & _
                    " where a.PONumber = '" & PONumber.Trim & "' and isnull(c.NsIDnId,'') <> '' "
            ElseIf DocumnetType = 5 Then
                'strPODetails = " select  a.po_number , a.po_date , a.po_value , a.order_completion_date PODueDate , c.name  " & _
                '        " from pm_po_header a , pm_supplier_master c  where  c.supplier_code = a.supplier_code and a.po_number = '" & PONumber.Trim & "'  "
                strPODetails = " select a.PONumber , a.po_date , sum(( a.QTY * unit_rate )) po_value  ,  a.DueDate PODueDate , a.Firm name ," & _
                    " dbo.ms_fn_ConsigneeName(b.Consignee) Consignee , " & _
                    " (' InvoiceNumber : '+ b.InvoiceNumber + ', Dt:  ' + convert(varchar(11) , b.InvoiceDate , 103 ) ) InvoiceNumber " & _
                    " from ms_vw_sparecell_podetails a " & _
                    " inner join ms_vw_sparecell_PIDetails b  on a.PONumber = b.PONumber and a.PLNumber = b.PLNumber" & _
                    " where isnull(b.NSIDNId,'') = '' and  a.PONumber = '" & PONumber.Trim & "' " & _
                    " group by a.PONumber , a.po_date , a.DueDate  , a.Firm , dbo.ms_fn_ConsigneeName(b.Consignee) , " & _
                    " ' InvoiceNumber : '+ b.InvoiceNumber + ', Dt:  ' + convert(varchar(11) , b.InvoiceDate , 103 ) "
            ElseIf DocumnetType = 6 Then
                strPODetails = " select a.PLNumber , Description , Qty , po_date , Firm  , NsIDnId , PLRecdQty RecQty , PLRejQty RejQty ,  Unit ,  IDNRemarks Remarks , ConsigneeName Consignee" & _
                        " from ms_vw_sparecell_podetails a inner join ms_vw_SpareCellIDN b on a.PONumber = b.PONumber and a.PLNumber = b.PLNumber  where a.PONumber = '" & PONumber.Trim & "' and Status = 'REJECTED' "
            ElseIf DocumnetType = 7 Then
                strPODetails = " select dbo.pm_po_details.pl_number , ms_vw_SpareCellIDN.NsIDNId, ms_vw_SpareCellIDN.PLRecdOn , po_date , name Firm  , ms_vw_SpareCellIDN.PLRecdQty, description unit  " & _
                    " FROM dbo.pm_po_details INNER JOIN dbo.pm_po_header  " & _
                    " ON dbo.pm_po_details.po_number = dbo.pm_po_header.po_number INNER JOIN dbo.pm_supplier_master  " & _
                    " ON dbo.pm_po_header.supplier_code = dbo.pm_supplier_master.supplier_code INNER JOIN dbo.pm_item_Master  " & _
                    " ON dbo.pm_po_details.pl_number = dbo.pm_item_Master.pl_number  INNER JOIN  dbo.code  " & _
                    " ON dbo.code.code = dbo.pm_item_Master.uom " & _
                    " left outer JOIN dbo.ms_vw_SpareCellIDN ON ms_vw_SpareCellIDN.ponumber = dbo.pm_po_header.po_number and ms_vw_SpareCellIDN.plnumber = dbo.pm_po_details.pl_number " & _
                    " WHERE (dbo.code.code_type = 'UT') AND (dbo.code.application = 'PM') and dbo.pm_po_header.po_number = '" & PONumber.Trim & "' "
            End If
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim dt As New DataTable()
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = strPODetails
            Try
                da.Fill(ds)
                dt = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                strPODetails = Nothing
                da.Dispose()
                dt.Dispose()
            End Try
            Return dt
        End Function
        Public Shared Function ElecPODetails(ByVal PONumber As String, Optional ByVal CheckListID As Long = 0) As DataSet
            Dim strPODetails As String
            If CheckListID = 0 Then
                strPODetails = " select  ConsigneeName , NSIDNno , NSIDNDate , PO_No , po_date , Firm , pl_number , PlShortName , " & _
                    " Unit , PO_QTY , po_value , order_completion_date , PLRecdQty , PLRecdOn , PLAcceptedQty , " & _
                    " PLRejQty , Authority , Remarks , InVoiceNo , InVoiceDate , Status , LedgerNumber , " & _
                    " Location , RegRemarks , NSDBRNo , NSDBRDate from ms_vw_ElecNSIDNDetails where po_no =  '" & PONumber.Trim & "'"
            Else

            End If
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = strPODetails
            Try
                da.Fill(ds)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                strPODetails = Nothing
                da.Dispose()
            End Try
            Return ds
        End Function
        Public Shared Function PODetails(ByVal PONumber As String, Optional ByVal CheckListID As Long = 0) As DataSet
            Dim strPODetails As String
            If CheckListID = 0 Then
                strPODetails = " select  a.po_number , a.po_date , a.po_value ,a.order_completion_date PODueDate , c.name , dbo.ms_fn_PoWarAndPaymentTerms(a.po_number) PT " & _
                                            " from pm_po_header a , pm_supplier_master c " & _
                                            " where  c.supplier_code = a.supplier_code and a.po_number = '" & PONumber.Trim & "' ; " & _
                                            " select a.PONumber po_number , a.PLNumber pl_number , " & _
                                            " substring(dbo.ms_fn_PlLongName(a.PLNumber),1,60) pl_desc , b.PLRecdQty Qty , b.NsIDnId  ," & _
                                            " dbo.ms_fn_PlUnitName(a.PLNumber) UnitName , c.PLAcceptedQty ActualQty , " & _
                                            " convert(varchar(11) , c.SentBackToSpareCellOn ,103) Dt " & _
                                            " from ms_sparecell_po a inner join ms_sparecell_nsidnno b   on b.poid = a.poid " & _
                                            " inner join ms_IMBRegister c   on c.NsIdnId = b.NsIdnId   " & _
                                            " inner join ms_sparecell_consignee d   on d.Consignee = b.POConsignee " & _
                                            " where a.PONumber = '" & PONumber.Trim & "' and c.Status  = 'ACCEPTED' ; " & _
                                            " select distinct b.po_number , b.pl_number , b.order_quantity OrderQty , c.consignee " & _
                                            " from pm_indent_detail  a inner join pm_po_details b  " & _
                                            " on b.pl_number = a.pl_number inner join pm_indent_header c  " & _
                                            " on c.indent_number = a.indent_number where b.po_number = '" & PONumber.Trim & "' ; exec  ms_PoWarAndPaymentTerms '" & PONumber.Trim & "' ; " & _
                                            " select b.NsIDnId NSIDNId, convert(varchar,b.NSIDNDate,103) NSIDNDate , a.PONumber, a.PLNumber , d.consigneename Consi ,  " & _
                                            " b.PLRecdQty RecdQty , c.PLAcceptedQty AccpQty , c.PLRejQty RejQty , c.Status   " & _
                                            " from ms_sparecell_po a inner join ms_sparecell_nsidnno b on b.poid = a.poid " & _
                                            " left outer join ms_IMBRegister c on c.NsIdnId = b.NsIdnId  " & _
                                            " inner join ms_sparecell_consignee d on d.Consignee = b.POConsignee  where a.PONumber = '" & PONumber.Trim & "' ; " & _
                                            " select a.PONumber po_number , a.PLNumber pl_number ,  substring(dbo.ms_fn_PlLongName(a.PLNumber),1,60) pl_desc ,  " & _
                                            " b.PLRecdQty Qty , b.NsIDnId  , dbo.ms_fn_PlUnitName(a.PLNumber) UnitName , b.PLRecdQty ActualQty ,  convert(varchar(11) , c.LetterDate ,103) Dt   " & _
                                            " from ms_sparecell_po a inner join ms_sparecell_nsidnno b   on b.poid = a.poid  inner join ms_vw_sparecell_PRCDetails c  " & _
                                            " on c.NsIdnId = b.NsIdnId where a.PONumber = '" & PONumber.Trim & "' ; " & _
                                            " select a.PLNumber pl_number , substring(dbo.ms_fn_PlLongName(a.PLNumber),1,60) pl_desc , c.Qty ,  " & _
                                            " Unit UnitName ,  PLAcceptedQty ActualQty ,  convert(varchar(11) , c.PIDate ,103) Dt  , b.NsIDnId " & _
                                            " from ms_vw_sparecell_podetails a inner join ms_vw_SpareCellIDN b on a.PONumber = b.PONumber and a.PLNumber = b.PLNumber " & _
                                            " inner join ms_vw_sparecell_PIDetails c on c.PONumber = b.PONumber and c.PLNumber = b.PLNumber and c.NsIDnId = b.NsIDnId " & _
                                            " where a.PONumber = '" & PONumber.Trim & "' and isnull(c.NsIDnId,'') <> '' ; " & _
                                            " select PONumber , pl_number , pl_desc , QtyAsPerPO , Rate , ActualQty , UnitName  from ms_vw_sparecell_BillsCheckListItems where PONumber = '" & PONumber.Trim & "'"
                '" select a.po_number, a.pl_number, substring(a.long_description,1,60) pl_desc , a.order_quantity Qty , a.unit_rate Rate, f.description UnitName  " & _
                '" from pm_po_details a  left outer join pm_itemMasterOnly b on b.pl_number = a.pl_number     " & _
                '" left outer join code f on f.code = b.uom and f.application = 'pm' and f.code_type = 'UT' " & _
                '" where a.po_number = '" & PONumber.Trim & "' ; " & _
            Else
                If CheckListID < 39 Then
                    strPODetails = " select  a.po_number , a.po_date , a.po_value ,a.order_completion_date PODueDate , c.name " & _
                                                   " from pm_po_header a , pm_supplier_master c  where  c.supplier_code = a.supplier_code and a.po_number = '" & PONumber.Trim & "' ;" & _
                                                   " select PONumber , po_date , Supplier , pl_number , pl_desc , QtyAsPerPO , Rate NSIDNId , ActualQty  , " & _
                                                   " UnitName , DeliveryDate , TotalValue , DueDate , Delivery , Quantity , Others , OtherPayment , SpecialConditions , " & _
                                                   " Erection , DateOfReceipt , DateOfSending , AnyOtherEnclosures ,  CheckListItemsID , CheckListID  from ms_vw_sparecell_BillsCheckListItemsOld where PONumber = '" & PONumber.Trim & "' and  CheckListID = " & CheckListID & " ; " & _
                                                   " exec  ms_PoWarAndPaymentTerms '" & PONumber.Trim & "' ; select pl_number , pl_desc , QtyAsPerPO , Rate NSIDNId , UnitName , ActualQty ,  DeliveryDate ,CheckListItemsID from ms_vw_sparecell_BillsCheckListItems "
                Else
                    strPODetails = " select  a.po_number , a.po_date , a.po_value ,a.order_completion_date PODueDate , c.name " & _
                               " from pm_po_header a , pm_supplier_master c  where  c.supplier_code = a.supplier_code and a.po_number = '" & PONumber.Trim & "' ;" & _
                               " select PONumber , po_date , Supplier , pl_number , pl_desc , QtyAsPerPO , Rate NSIDNId , ActualQty  , " & _
                               " UnitName , DeliveryDate , TotalValue , DueDate , Delivery , Quantity , Others , OtherPayment , SpecialConditions , " & _
                               " Erection , DateOfReceipt , DateOfSending , AnyOtherEnclosures ,  CheckListItemsID , CheckListID  from ms_vw_sparecell_BillsCheckListItems where PONumber = '" & PONumber.Trim & "' and  CheckListID = " & CheckListID & " ; " & _
                               " exec  ms_PoWarAndPaymentTerms '" & PONumber.Trim & "' ; select pl_number , pl_desc , QtyAsPerPO , Rate NSIDNId , UnitName , ActualQty ,  DeliveryDate ,CheckListItemsID from ms_vw_sparecell_BillsCheckListItems "
                End If

            End If

            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = strPODetails
            Try
                da.Fill(ds)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                strPODetails = Nothing
                da.Dispose()
            End Try
            Return ds
        End Function
        Public Shared Function BillCheckList()
            Dim dtCheckList As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select distinct a.CheckListID , PONumber from ms_sparecell_BillsCheckList a inner join  ms_sparecell_BillsCheckListItems b    " & _
                            " on a.CheckListID =  b.CheckListID order by a.CheckListID desc"
            Try
                da.Fill(ds, "CheckList")
                dtCheckList = ds.Tables("CheckList")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtCheckList
        End Function
        Public Shared Function GetDocType(ByVal DocumentID As Long) As Integer
            Dim DocumnetType As Integer
            Dim Cmd As System.Data.SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Cmd.Parameters.Add("@Cnt", SqlDbType.Int, 4)
            Cmd.Parameters("@Cnt").Direction = ParameterDirection.Output
            Cmd.CommandText = " select @Cnt = ( select top 1 DocumnetType from ms_vw_sparecell_BillsDocumentDetails where DocumentID = @DocumentID ) "
            Try
                Cmd.Parameters.Add("@DocumentID", SqlDbType.BigInt, 8).Value = DocumentID
                If Cmd.Connection.State = ConnectionState.Closed Then Cmd.Connection.Open()
                Cmd.ExecuteScalar()
                DocumnetType = IIf(IsDBNull(Cmd.Parameters("@Cnt").Value), 0, Cmd.Parameters("@Cnt").Value)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If Cmd.Connection.State = ConnectionState.Open Then Cmd.Connection.Close()
                Cmd.Dispose()
            End Try
            Return DocumnetType
        End Function
        Public Shared Function BillDocumentDetails(ByVal DocumentID As Long, Optional ByVal Type As Integer = 0) As DataTable
            Dim dtBillDocument As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            If Type = 6 Then
                da.SelectCommand.CommandText = " select a.* ,  PLRecdQty RecQty , PLRejQty RejQty ,  Unit ,  IDNRemarks Remarks , ConsigneeName Consignee " & _
                                    " from ms_vw_sparecell_BillsDocumentDetails  a inner join ms_vw_SpareCellIDN b on a.PONumber = b.PONumber and a.PLNumber = b.PLNumber and a.NsIDnId = b.NsIDnId where DocumentID = " & DocumentID
            ElseIf Type = 7 Then
                da.SelectCommand.CommandText = "select  * , 0 PLRecdQty , '1900-01-01' PLRecdOn , name Firm from ms_vw_sparecell_BillsDocumentDetails a inner join dbo.pm_po_details " & _
                                    " on a.PONumber = dbo.pm_po_details.po_number and dbo.pm_po_details.pl_number = a.PLNumber " & _
                                    " INNER JOIN dbo.pm_po_header   ON dbo.pm_po_details.po_number = dbo.pm_po_header.po_number " & _
                                    " INNER JOIN dbo.pm_supplier_master   ON dbo.pm_po_header.supplier_code = dbo.pm_supplier_master.supplier_code " & _
                                    " INNER JOIN dbo.pm_item_Master   ON dbo.pm_po_details.pl_number = dbo.pm_item_Master.pl_number  " & _
                                    " INNER JOIN  dbo.code   ON dbo.code.code = dbo.pm_item_Master.uom  " & _
                                    " WHERE (dbo.code.code_type = 'UT') AND (dbo.code.application = 'PM') and DocumentID = " & DocumentID
            ElseIf Type = 4 Then
                da.SelectCommand.CommandText = "select * ,  PLAcceptedQty AcpQty  from ms_vw_sparecell_BillsDocumentDetails a inner join ms_vw_SpareCellIDN b on a.PONumber = b.PONumber and a.PLNumber = b.PLNumber and a.NsIDnId = b.NsIDnId where DocumentID = " & DocumentID
            Else
                da.SelectCommand.CommandText = "select *  from ms_vw_sparecell_BillsDocumentDetails where DocumentID = " & DocumentID
            End If

            Try
                da.Fill(ds, "BillDocument")
                dtBillDocument = ds.Tables("BillDocument")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtBillDocument
        End Function
        Public Shared Function BillDocuments(ByVal DocumnetType As Integer) As DataSet
            Dim dtBillDocument As New DataSet()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select distinct DocumentID , convert(varchar,DocumnetType)+convert(varchar,DocumentID) DocumnetType " & _
                " from ms_vw_sparecell_BillsDocumentDetails where DocumnetType = " & DocumnetType & " order by DocumentID desc ;" & _
                " select distinct DocumentID , DocumnetType from ms_vw_sparecell_BillsDocumentDetails order by DocumentID desc "
            Try
                da.Fill(ds, "BillDocument")
                dtBillDocument = ds.Copy
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtBillDocument
        End Function
        Public Shared Function AdviceLetters()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select distinct AdviceId " & _
                " from ms_sparecell_AdviceID order by AdviceId desc ; "
            Try
                da.Fill(ds)
                Return ds.Tables(0)
            Catch exp As Exception
                Return Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function RejectedIDNs()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select distinct NsIDnId " & _
                " from ms_vw_SpareCellIDN where Status = 'REJECTED' order by NsIDnId desc ; "
            Try
                da.Fill(ds)
                Return ds.Tables(0)
            Catch exp As Exception
                Return Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function BillNotings()
            Dim dtBillNotings As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select NotingID , NSIDNno from ms_sparecell_BillsNoting order by NotingID desc"
            Try
                da.Fill(ds, "BillNotings")
                dtBillNotings = ds.Tables("BillNotings")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtBillNotings
        End Function
        Public Shared Function BillPercent()
            Dim dtBillPercent As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select distinct BillPercent from ms_sparecell_BillsPercentFormat "
            Try
                da.Fill(ds, "BillPercent")
                dtBillPercent = ds.Tables("BillPercent")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtBillPercent
        End Function
        Public Shared Function BillPercentDetails(ByVal BillPercent As Long)
            Dim dtBillPercent As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select * from ms_sparecell_BillsPercentFormat where BillPercent = " & BillPercent & ""
            Try
                da.Fill(ds, "BillPercent")
                dtBillPercent = ds.Tables("BillPercent")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtBillPercent
        End Function
        Public Shared Function BillsPendingPOs(Optional ByVal Delete As Boolean = False) As DataTable
            Dim dtBillsPendingPOs As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select distinct PONumber from ms_sparecell_po "
            Try
                da.Fill(ds, "BillsPendingPOs")
                dtBillsPendingPOs = ds.Tables("BillsPendingPOs")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtBillsPendingPOs
        End Function
        Public Shared Function SavedBillsPendingPOs(Optional ByVal Delete As Boolean = False) As DataTable
            Dim dtSavedBillsPendingPOs As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            If Delete Then
                da.SelectCommand.CommandText = " select distinct PONumber from ms_vw_sparecell_BillsPendingNew  where isnull(Deleted,0) = 1 order by PONumber desc"
            Else
                da.SelectCommand.CommandText = " select distinct PONumber  from ms_vw_sparecell_BillsPendingNew where isnull(Deleted,0) = 0 order by PONumber desc"
            End If
            Try
                da.Fill(ds, "SavedBillsPendingPOs")
                dtSavedBillsPendingPOs = ds.Tables("SavedBillsPendingPOs")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtSavedBillsPendingPOs
        End Function
        Public Shared Function SavedBillsPendingDetails(ByVal PONumber As String, Optional ByVal Delete As Boolean = False, Optional ByVal NSIDNno As Long = 0) As DataTable
            Dim dtSavedBillsPendingDetails As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.Parameters.Add("@PONumber", SqlDbType.VarChar, 9)
            da.SelectCommand.Parameters("@PONumber").Direction = ParameterDirection.Input
            da.SelectCommand.Parameters("@PONumber").Value = PONumber.Trim
            If Delete Then
                da.SelectCommand.CommandText = " select PONumber, NSIDNno, convert(varchar,NSIDNDate,103) NSIDNDate , Reasons , SentOn, ReceivedOn, RecID ,  convert(varchar,PODate,103) PODate , Supplier  " & _
                            " from  ms_vw_sparecell_BillsPending where PONumber = @PONumber and isnull(Deleted,0) = 1 order by NSIDNno "
            Else
                da.SelectCommand.CommandText = " select PONumber, NSIDNno, convert(varchar,NSIDNDate,103) NSIDNDate , Reasons , SentOn, ReceivedOn, RecID ,  convert(varchar,PODate,103) PODate , Supplier  " & _
                            " from  ms_vw_sparecell_BillsPending where PONumber = @PONumber and isnull(Deleted,0) = 0 order by NSIDNno "
            End If
            If NSIDNno > 0 Then
                da.SelectCommand.CommandText = " select PONumber, NSIDNno, convert(varchar,NSIDNDate,103) NSIDNDate , Reasons , SentOn, ReceivedOn, RecID  ,  convert(varchar,PODate,103) PODate , Supplier " & _
                                " from  ms_vw_sparecell_BillsPending where PONumber = @PONumber and isnull(Deleted,0) = 0 and NSIDNno = " & NSIDNno & " "
                If Delete Then
                    da.SelectCommand.CommandText = " select PONumber, NSIDNno, convert(varchar,NSIDNDate,103) NSIDNDate , Reasons , SentOn, ReceivedOn, RecID  ,  convert(varchar,PODate,103) PODate , Supplier " & _
                                    " from  ms_vw_sparecell_BillsPending where PONumber = @PONumber and isnull(Deleted,0) = 1 and NSIDNno = " & NSIDNno & " "
                End If
            End If
            Try
                da.Fill(ds, "SavedBillsPendingDetails")
                dtSavedBillsPendingDetails = ds.Tables("SavedBillsPendingDetails")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtSavedBillsPendingDetails
        End Function
#End Region
#Region "  fields "
        Private sLocation, sAcceptingAuthority, sStatus, sPONumber, sPLNumber, sRemarks, sWarGuarantee, sMessage, sLedgerNumber As String
        Private decPLRecdQty, decAccpQty, decRejQty As Decimal
        Private dateInVoiceDate, dateLetterDate, dateDCDate, dateSentToHQOn, dateSentToSparesOn, dateReceivedBackOn, dateDateRecdbySpaceCell, dateNSIDNDate, dateSentToShopOn, dateRecdByShopOn, dateNSIDNRecdOn As Date
        Private intConsignee, intNextNumber As Integer
        Private longNSIDNid, lPRCid, lPIid As Long
        Private blnNextNumberGenerated As Boolean
        Private sNSDBRNo, snsprc_number, sConsignee, sLetterNo, sDCNumber, sPara2, sInVoiceNo As String
        Private dtPRCTable, dtPRCItems, dtPRCSavedTable, dtPITable, dtPIItems, dtPISavedDetails As DataTable
#End Region
#Region "  property " '
        Property InVoiceDate() As Date
            Get
                Return dateInVoiceDate
            End Get
            Set(ByVal Value As Date)
                dateInVoiceDate = Value
            End Set
        End Property
        Property InVoiceNo() As String
            Get
                Return sInVoiceNo
            End Get
            Set(ByVal Value As String)
                sInVoiceNo = Value
            End Set
        End Property
        Property PIid() As Long
            Get
                Return lPIid
            End Get
            Set(ByVal Value As Long)
                lPIid = Value
            End Set
        End Property
        Property Para2() As String
            Get
                Return sPara2
            End Get
            Set(ByVal Value As String)
                sPara2 = Value
            End Set
        End Property
        Property DCNumber() As String
            Get
                Return sDCNumber
            End Get
            Set(ByVal Value As String)
                sDCNumber = Value
            End Set
        End Property
        Property LetterNo() As String
            Get
                Return sLetterNo
            End Get
            Set(ByVal Value As String)
                sLetterNo = Value
            End Set
        End Property
        Property ConsigneeName() As String
            Get
                Return (sConsignee)
            End Get
            Set(ByVal Value As String)
                sConsignee = Value
            End Set
        End Property
        Property nsprc_number() As String
            Get
                Return snsprc_number
            End Get
            Set(ByVal Value As String)
                snsprc_number = Value
            End Set
        End Property
        Property PRCid() As Long
            Get
                Return lPRCid
            End Get
            Set(ByVal Value As Long)
                lPRCid = Value
            End Set
        End Property
        Property DCDate() As Date
            Get
                Return dateDCDate
            End Get
            Set(ByVal Value As Date)
                dateDCDate = Value
            End Set
        End Property
        Property LetterDate() As Date
            Get
                Return dateLetterDate
            End Get
            Set(ByVal Value As Date)
                dateLetterDate = Value
            End Set
        End Property
        Property SentToHQOn() As Date
            Get
                Return dateSentToHQOn
            End Get
            Set(ByVal Value As Date)
                dateSentToHQOn = Value
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
        Property SentToSparesOn() As Date
            Get
                Return dateSentToSparesOn
            End Get
            Set(ByVal Value As Date)
                dateSentToSparesOn = Value
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
        Property AcceptingAuthority() As String
            Get
                Return sAcceptingAuthority
            End Get
            Set(ByVal Value As String)
                sAcceptingAuthority = Value
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
        Property ReceivedBackOn() As Date
            Get
                Return dateReceivedBackOn
            End Get
            Set(ByVal Value As Date)
                dateReceivedBackOn = Value
            End Set
        End Property
        Property NSIDNRecdOn() As Date
            Get
                Return dateNSIDNRecdOn
            End Get
            Set(ByVal Value As Date)
                dateNSIDNRecdOn = Value
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
        Property NextNumberGenerated() As Boolean
            Get
                Return blnNextNumberGenerated
            End Get
            Set(ByVal Value As Boolean)
                blnNextNumberGenerated = Value
            End Set
        End Property
        Property NSIDNid() As Long
            Get
                Return longNSIDNid
            End Get
            Set(ByVal Value As Long)
                longNSIDNid = Value
            End Set
        End Property
        Property Message() As String
            Get
                Return sMessage
            End Get
            Set(ByVal Value As String)
                sMessage = Value
            End Set
        End Property
        Property WarGuarantee() As String
            Get
                Return sWarGuarantee
            End Get
            Set(ByVal Value As String)
                sWarGuarantee = Value
            End Set
        End Property
        Property NextNumber() As Integer
            Get
                Return intNextNumber
            End Get
            Set(ByVal Value As Integer)
                intNextNumber = Value
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
        Property RecdByShopOn() As Date
            Get
                Return dateRecdByShopOn
            End Get
            Set(ByVal Value As Date)
                dateRecdByShopOn = Value
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
        Property NSIDNDate() As Date
            Get
                Return dateNSIDNDate
            End Get
            Set(ByVal Value As Date)
                dateNSIDNDate = Value
            End Set
        End Property
        Property Consignee() As Integer
            Get
                Return intConsignee
            End Get
            Set(ByVal Value As Integer)
                intConsignee = Value
            End Set
        End Property
        Property DateRecdbySpaceCell() As Date
            Get
                Return dateDateRecdbySpaceCell
            End Get
            Set(ByVal Value As Date)
                dateDateRecdbySpaceCell = Value
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
        Property PRCTable() As DataTable
            Get
                Return dtPRCTable
            End Get
            Set(ByVal Value As DataTable)
                dtPRCTable = Value
            End Set
        End Property
        Property PRCItems() As DataTable
            Get
                Return dtPRCItems
            End Get
            Set(ByVal Value As DataTable)
                dtPRCItems = Value
            End Set
        End Property
        Property PRCSavedDetails() As DataTable
            Get
                Return dtPRCSavedTable
            End Get
            Set(ByVal Value As DataTable)
                dtPRCSavedTable = Value
            End Set
        End Property
        Property PITable() As DataTable
            Get
                Return dtPITable
            End Get
            Set(ByVal Value As DataTable)
                dtPITable = Value
            End Set
        End Property
        Property PIItems() As DataTable
            Get
                Return dtPIItems
            End Get
            Set(ByVal Value As DataTable)
                dtPIItems = Value
            End Set
        End Property
        Property PISavedDetails() As DataTable
            Get
                Return dtPISavedDetails
            End Get
            Set(ByVal Value As DataTable)
                dtPISavedDetails = Value
            End Set
        End Property
#End Region
#Region "  methods "
        Private Sub iniVals()
            dateInVoiceDate = CDate("1900-01-01")
            sInVoiceNo = ""
            dateSentToHQOn = CDate("1900-01-01")
            sNSDBRNo = ""
            dateSentToSparesOn = CDate("1900-01-01")
            sLocation = ""
            sAcceptingAuthority = ""
            sStatus = ""
            dateReceivedBackOn = CDate("1900-01-01")
            dateNSIDNRecdOn = CDate("1900-01-01")
            sLedgerNumber = ""
            decRejQty = 0.0
            decAccpQty = 0.0
            longNSIDNid = 0
            sMessage = ""
            sWarGuarantee = ""
            intNextNumber = 0
            sRemarks = ""
            dateRecdByShopOn = CDate("1900-01-01")
            dateSentToShopOn = CDate("1900-01-01")
            dateNSIDNDate = CDate("1900-01-01")
            intConsignee = 0
            sPLNumber = ""
            sPONumber = ""
            blnNextNumberGenerated = False
            lPRCid = 0
            lPIid = 0
            dateDCDate = "1900-01-01"
            dateLetterDate = "1900-01-01"
            snsprc_number = ""
            sLetterNo = ""
            sPara2 = ""
            dtPRCTable = Nothing
            dtPRCItems = Nothing
            dtPRCSavedTable = Nothing
            dtPITable = Nothing
            dtPIItems = Nothing
            dtPISavedDetails = Nothing
        End Sub
        Public Sub New()
            iniVals()
        End Sub
        Public Function CheckNSIDNid(ByVal NSIDNno As Long, ByVal PONumber As String, ByVal PLNumber As String, ByVal Qty As Decimal) As Boolean
            Dim Found As Integer
            Dim Cmd As System.Data.SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim ds As New DataSet()
            Cmd.Parameters.Add("@Cnt", SqlDbType.Int, 4)
            Cmd.Parameters("@Cnt").Direction = ParameterDirection.Output

            Cmd.CommandText = " select @Cnt = count(*) from ms_vw_SpareCellIDN where PONumber = @PONumber and PLNumber = @PLNumber and NSIDNId = @NSIDNno and PLAcceptedQty = @Qty  ; "
            Try
                Cmd.Parameters.Add("@NSIDNno", SqlDbType.Int, 4).Value = NSIDNno
                Cmd.Parameters.Add("@PONumber", SqlDbType.VarChar, 9).Value = PONumber.Trim
                Cmd.Parameters.Add("@PLNumber", SqlDbType.VarChar, 8).Value = PLNumber.Trim
                Cmd.Parameters.Add("@Qty", SqlDbType.Float, 8).Value = Qty
                If Cmd.Connection.State = ConnectionState.Closed Then Cmd.Connection.Open()
                Cmd.ExecuteScalar()
                Found = IIf(IsDBNull(Cmd.Parameters("@Cnt").Value), 0, Cmd.Parameters("@Cnt").Value)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If Cmd.Connection.State = ConnectionState.Open Then Cmd.Connection.Close()
                Cmd.Dispose()
            End Try
            If Found > 0 Then Return True
        End Function
        Public Function PIDetails(ByVal PONumber As String, Optional ByVal edit As Boolean = False) As Boolean
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim dt As New DataTable()
            Dim ds As New DataSet()
            Dim dtPRCDetails As New DataTable()
            Dim Done As Boolean
            If edit Then
                da.SelectCommand.CommandText = " select a.* , b.PLRecdQty , (QTY*unit_rate)  Amount , dbo.ms_fn_PoWarAndPaymentTerms(a.PONumber) PT , dbo.ms_fn_POconsignee(a.PONumber) con  " & _
                                " from ms_vw_sparecell_podetails a inner join ms_vw_SpareCellNSIDNs b on a.PONumber = b.PONumber  " & _
                                " and a.PLNumber = b.PLNumber and dbo.ms_fn_POconsignee(a.PONumber) = b.ConsigneeName " & _
                                " where a.PONumber = '" & PONumber & "'  ;" & _
                                " select Consignee , InvoiceNumber , convert(varchar(11),InvoiceDate,103) InvoiceDate , convert(varchar(11),PIDate,103) PIDate , PIid , PLNumber , Qty , Amount , NSIDNId FROM ms_vw_sparecell_PIDetails where PONumber = '" & PONumber & "'  "

                da.SelectCommand.CommandText = " select a.* , b.Para2 ,  b.InvoiceNumber , convert(varchar(11),b.InvoiceDate,103) InvoiceDate ,  convert(varchar(11),b.PIDate,103) PIDate , b.NSIDNId , b.PIid , b.PIDetailsid , b.Qty PLAcceptedQty , dbo.ms_fn_PoWarAndPaymentTerms(a.PONumber) PT , dbo.ms_fn_POconsignee(a.PONumber) con , b.Amount from ms_vw_sparecell_podetails a inner join ms_vw_sparecell_PIDetails b  on a.PONumber = b.PONumber and a.PLNumber = b.PLNumber where isnull(b.NSIDNId,'') = '' and  a.PONumber = '" & PONumber & "'  ;" & _
                                            " select Consignee , InvoiceNumber , convert(varchar(11),InvoiceDate,103) InvoiceDate , convert(varchar(11),PIDate,103) PIDate , PIid , PLNumber , Qty , Amount , NSIDNId , PIDetailsid FROM ms_vw_sparecell_PIDetails where PONumber = '" & PONumber & "'  "
            Else
                da.SelectCommand.CommandText = " select a.* , a.Qty PLRecdQty , (QTY*unit_rate)  Amount , dbo.ms_fn_PoWarAndPaymentTerms(a.PONumber) PT , dbo.ms_fn_POconsignee(a.PONumber) con  " & _
                                " from ms_vw_sparecell_podetails a  where a.PONumber = '" & PONumber & "'  ;" & _
                                " select Consignee , InvoiceNumber , convert(varchar(11),InvoiceDate,103) InvoiceDate , convert(varchar(11),PIDate,103) PIDate , PIid , PLNumber , Qty , Amount , NSIDNId FROM ms_vw_sparecell_PIDetails where PONumber = '" & PONumber & "'  "
            End If
            Try
                da.Fill(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(0)("PT") = "1" Then
                        dtPITable = ds.Tables(0).Copy
                        If ds.Tables(1).Rows.Count > 0 Then
                            dtPISavedDetails = ds.Tables(1).Copy
                        End If
                        Done = True
                    Else
                        sMessage = " PO no : '" & ds.Tables(0).Rows(0)("po_no") & "'  has no PI Clause !"
                    End If
                Else
                    If edit Then
                        sMessage = " PO no : " & PONumber & " without NSIDNs  does not exists !"
                    Else
                        sMessage = " PO no : " & PONumber & "  does not exists !"
                    End If
                    If ds.Tables(1).Rows.Count > 0 Then
                        dtPISavedDetails = ds.Tables(1).Copy
                        Done = True
                    End If
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
            Return Done
        End Function
        Public Function PRCDetails(ByVal PONumber As String) As Boolean
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim dt As New DataTable()
            Dim ds As New DataSet()
            Dim dtPRCDetails As New DataTable()
            Dim Done As Boolean
            da.SelectCommand.CommandText = " select * , dbo.ms_fn_PoWarAndPaymentTerms(po_no) PT , ( PLRecdQty * unit_rate ) Amount  from ms_vw_NsIdnsDetails where PO_No = '" & PONumber & "'  ;" & _
                        " select Consignee , convert(varchar(11),LetterDate,103) PIDate , DCNumber , convert(varchar(11),DCDate,103) DCDate ,  Para2 , nsprc_number , NSIDNId , Amount , PRCid  from ms_vw_sparecell_PRCDetails where PONumber = '" & PONumber & "'  ; "
            Try
                da.Fill(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(0)("PT") = "D" Then
                        dtPRCTable = ds.Tables(0).Copy
                        If ds.Tables(1).Rows.Count > 0 Then
                            dtPRCSavedTable = ds.Tables(1).Copy
                        End If
                        Done = True
                    Else
                        sMessage = " PO no : '" & ds.Tables(0).Rows(0)("po_no") & "'  has no PRC Clause !"
                    End If
                Else
                    sMessage = " NS IDN no : " & NSIDNid & "  does not exists !"
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
            Return Done
        End Function
        Public Function GenerateNSIDNs(Optional ByVal longNSIDNid As Long = 0) As Boolean
            If longNSIDNid = 0 Then
                Dim sPO, strPO, strPOid, strNSIDN, strNSIDNNo, strNSIDNWarGuar As String
                Dim sqlCon As New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
                Dim POparam(1), pPO(2), POidparam(2), NSIDNparam(10), NSIDNNoparam(5), NSIDNWarGuarparam(1) As SqlClient.SqlParameter
                Dim strTran As SqlClient.SqlTransaction
                Dim sqlcmd As New SqlClient.SqlCommand()
                Dim j As Integer
                Dim PoId As Double
                Dim iPOid As Decimal
                Dim oCmd As New SqlClient.SqlCommand()
                oCmd.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))

                sPO = " select  @POid = PoId from ms_sparecell_po " & _
                      " where PONumber =  @PONumber  and   PLNumber = @PLNumber "

                pPO(0) = New SqlClient.SqlParameter("@POid", SqlDbType.BigInt, 8)
                pPO(1) = New SqlClient.SqlParameter("@PONumber", SqlDbType.VarChar, 9)
                pPO(2) = New SqlClient.SqlParameter("@PLNumber", SqlDbType.VarChar, 8)

                pPO(0).Direction = ParameterDirection.Output
                pPO(1).Direction = ParameterDirection.Input
                pPO(2).Direction = ParameterDirection.Input
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                Dim t As Integer
                Try
                    pPO(1).Value = sPONumber
                    pPO(2).Value = sPLNumber
                    For t = 0 To 2
                        oCmd.Parameters.Add(pPO(t))
                    Next
                    oCmd.CommandText = sPO

                    oCmd.ExecuteScalar()
                    iPOid = IIf(IsDBNull(pPO(0).Value), 0, pPO(0).Value)
                    For t = 0 To 2
                        oCmd.Parameters.Remove(pPO(t))
                    Next
                    blnNextNumberGenerated = True
                Catch exp As Exception
                    sMessage = exp.Message
                Finally
                    If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                    oCmd.Dispose()
                End Try
                If blnNextNumberGenerated = False Then
                    Exit Function
                Else
                    blnNextNumberGenerated = False
                End If
                If iPOid = 0 Then
                    strPO = " insert into ms_sparecell_po ( PONumber , PLNumber ) values ( @txtPONumber , @ddlPLNumber ) "
                End If
                strPOid = " select @POid = POid from ms_sparecell_po where PONumber = @txtPONumber  and  PLNumber = @ddlPLNumber "
                strNSIDN = " insert into ms_sparecell_nsidnno (  PoId , PLRecdQty , PLRecdOn ,  POConsignee , NSIDNDate , SentToShopOn , RecdByShopOn , Remarks  , NsIDnId , InVoiceNo , InVoiceDate ) " & _
                           " values (  @POid  , @PLRecdQty , @DateRecdbySpaceCell , @ddlCons, @NSIDNDate , @SentToShopOn , @RecdByShopOn , @Remarks , @NextNumber , @InVoiceNo , @InVoiceDate )"
                strNSIDNNo = " select @NSIDNNo = NsIDnId from ms_sparecell_nsidnno where " & _
                            "  PoId =  @POid and  PLRecdQty =  @PLRecdQty  and PLRecdOn = @DateRecdbySpaceCell  and  POConsignee =  @ddlCons and  NSIDNDate = @NSIDNDate "
                strNSIDNWarGuar = " insert into ms_sparecell_nsidnWarGuar (  NsIDnId , WarGuar ) " & _
                                  " values (  @NsIDnId , @WarGuar )"
                POparam(0) = New SqlClient.SqlParameter("@txtPONumber", SqlDbType.VarChar, 9)
                POparam(0).Direction = ParameterDirection.Input
                POparam(1) = New SqlClient.SqlParameter("@ddlPLNumber", SqlDbType.VarChar, 8)
                POparam(1).Direction = ParameterDirection.Input

                POidparam(0) = New SqlClient.SqlParameter("@txtPONumber", SqlDbType.VarChar, 9)
                POidparam(0).Direction = ParameterDirection.Input
                POidparam(1) = New SqlClient.SqlParameter("@ddlPLNumber", SqlDbType.VarChar, 8)
                POidparam(1).Direction = ParameterDirection.Input
                POidparam(2) = New SqlClient.SqlParameter("@POid", SqlDbType.BigInt, 8)
                POidparam(2).Direction = ParameterDirection.Output

                NSIDNparam(0) = New SqlClient.SqlParameter("@POid", SqlDbType.BigInt, 8)
                NSIDNparam(0).Direction = ParameterDirection.Input
                NSIDNparam(1) = New SqlClient.SqlParameter("@PLRecdQty", SqlDbType.Float, 8)
                NSIDNparam(1).Direction = ParameterDirection.Input
                NSIDNparam(2) = New SqlClient.SqlParameter("@DateRecdbySpaceCell", SqlDbType.SmallDateTime, 4)
                NSIDNparam(2).Direction = ParameterDirection.Input
                NSIDNparam(3) = New SqlClient.SqlParameter("@ddlCons", SqlDbType.Int, 4)
                NSIDNparam(3).Direction = ParameterDirection.Input
                NSIDNparam(4) = New SqlClient.SqlParameter("@NSIDNDate", SqlDbType.SmallDateTime, 4)
                NSIDNparam(4).Direction = ParameterDirection.Input
                NSIDNparam(5) = New SqlClient.SqlParameter("@SentToShopOn", SqlDbType.SmallDateTime, 4)
                NSIDNparam(5).Direction = ParameterDirection.Input
                NSIDNparam(6) = New SqlClient.SqlParameter("@RecdByShopOn", SqlDbType.SmallDateTime, 4)
                NSIDNparam(6).Direction = ParameterDirection.Input
                NSIDNparam(7) = New SqlClient.SqlParameter("@Remarks", SqlDbType.VarChar, 500)
                NSIDNparam(7).Direction = ParameterDirection.Input
                NSIDNparam(8) = New SqlClient.SqlParameter("@NextNumber", SqlDbType.BigInt, 8)
                NSIDNparam(8).Direction = ParameterDirection.Input
                NSIDNparam(9) = New SqlClient.SqlParameter("@InVoiceNo", SqlDbType.VarChar, 50)
                NSIDNparam(9).Direction = ParameterDirection.Input
                NSIDNparam(10) = New SqlClient.SqlParameter("@InVoiceDate", SqlDbType.SmallDateTime, 4)
                NSIDNparam(10).Direction = ParameterDirection.Input

                NSIDNNoparam(0) = New SqlClient.SqlParameter("@POid", SqlDbType.BigInt, 8)
                NSIDNNoparam(0).Direction = ParameterDirection.Input
                NSIDNNoparam(1) = New SqlClient.SqlParameter("@PLRecdQty", SqlDbType.Float, 8)
                NSIDNNoparam(1).Direction = ParameterDirection.Input
                NSIDNNoparam(2) = New SqlClient.SqlParameter("@DateRecdbySpaceCell", SqlDbType.SmallDateTime, 4)
                NSIDNNoparam(2).Direction = ParameterDirection.Input
                NSIDNNoparam(3) = New SqlClient.SqlParameter("@ddlCons", SqlDbType.Int, 4)
                NSIDNNoparam(3).Direction = ParameterDirection.Input
                NSIDNNoparam(4) = New SqlClient.SqlParameter("@NSIDNDate", SqlDbType.SmallDateTime, 4)
                NSIDNNoparam(4).Direction = ParameterDirection.Input
                NSIDNNoparam(5) = New SqlClient.SqlParameter("@NSIDNNo", SqlDbType.BigInt, 8)
                NSIDNNoparam(5).Direction = ParameterDirection.Output


                NSIDNWarGuarparam(0) = New SqlClient.SqlParameter("@NsIDnId", SqlDbType.BigInt, 8)
                NSIDNWarGuarparam(1) = New SqlClient.SqlParameter("@WarGuar", SqlDbType.VarChar, 100)

                NSIDNWarGuarparam(0).Direction = ParameterDirection.Input
                NSIDNWarGuarparam(1).Direction = ParameterDirection.Input
                Try
                    If iPOid = 0 Then
                        POparam(0).Value = sPONumber
                        POparam(1).Value = sPLNumber
                    End If
                    POidparam(0).Value = sPONumber
                    POidparam(1).Value = sPLNumber


                    NSIDNparam(1).Value = decPLRecdQty
                    NSIDNparam(2).Value = dateDateRecdbySpaceCell
                    NSIDNparam(3).Value = intConsignee
                    NSIDNparam(4).Value = dateNSIDNDate
                    NSIDNparam(5).Value = dateSentToShopOn
                    NSIDNparam(6).Value = dateRecdByShopOn
                    NSIDNparam(7).Value = sRemarks
                    NSIDNparam(8).Value = intNextNumber
                    NSIDNparam(9).Value = sInVoiceNo
                    NSIDNparam(10).Value = dateInVoiceDate

                    NSIDNNoparam(1).Value = decPLRecdQty
                    NSIDNNoparam(2).Value = dateDateRecdbySpaceCell
                    NSIDNNoparam(3).Value = intConsignee
                    NSIDNNoparam(4).Value = dateNSIDNDate
                    NSIDNWarGuarparam(1).Value = sWarGuarantee
                    blnNextNumberGenerated = True
                Catch exp As Exception
                    sMessage &= exp.Message
                End Try
                If blnNextNumberGenerated = False Then
                    Exit Function
                Else
                    blnNextNumberGenerated = False
                End If
                Dim i As Integer

                Try
                    sqlcmd.Connection = sqlCon
                    If sqlcmd.Connection.State = ConnectionState.Closed Then sqlcmd.Connection.Open()
                    sqlcmd.Transaction = sqlcmd.Connection.BeginTransaction
                    If iPOid = 0 Then
                        For j = 0 To 1
                            sqlcmd.Parameters.Add(POparam(j))
                        Next
                        sqlcmd.CommandText = strPO
                        i = sqlcmd.ExecuteNonQuery()
                        For j = 0 To 1
                            sqlcmd.Parameters.Remove(POparam(j))
                        Next
                    End If
                    i = 0
                    For j = 0 To 2
                        sqlcmd.Parameters.Add(POidparam(j))
                    Next
                    sqlcmd.CommandText = strPOid
                    sqlcmd.ExecuteScalar()
                    PoId = sqlcmd.Parameters("@POid").Value
                    For j = 0 To 2
                        sqlcmd.Parameters.Remove(POidparam(j))
                    Next
                    i = 1
                    NSIDNparam(0).Value = PoId
                    For j = 0 To 10
                        sqlcmd.Parameters.Add(NSIDNparam(j))
                    Next
                    i = 0
                    sqlcmd.CommandText = strNSIDN
                    i = sqlcmd.ExecuteNonQuery()
                    For j = 0 To 10
                        sqlcmd.Parameters.Remove(NSIDNparam(j))
                    Next

                    For j = 0 To 5
                        sqlcmd.Parameters.Add(NSIDNNoparam(j))
                    Next
                    i = 0
                    NSIDNNoparam(0).Value = PoId
                    sqlcmd.CommandText = strNSIDNNo
                    i = sqlcmd.ExecuteNonQuery()
                    For j = 0 To 5
                        sqlcmd.Parameters.Remove(NSIDNNoparam(j))
                    Next
                    longNSIDNid = NSIDNNoparam(5).Value
                    NSIDNWarGuarparam(0).Value = NSIDNNoparam(5).Value
                    For j = 0 To 1
                        sqlcmd.Parameters.Add(NSIDNWarGuarparam(j))
                    Next
                    i = 0
                    sqlcmd.CommandText = strNSIDNWarGuar
                    i = sqlcmd.ExecuteNonQuery
                    For j = 0 To 1
                        sqlcmd.Parameters.Remove(NSIDNWarGuarparam(j))
                    Next
                Catch exp As Exception
                    sMessage &= exp.Message
                Finally
                    If i <> 0 Then
                        sqlcmd.Transaction.Commit()
                        blnNextNumberGenerated = True
                        sMessage = "NS IDN No : '" & longNSIDNid & "' Generated & displayed below"
                    Else
                        blnNextNumberGenerated = False
                        sqlcmd.Transaction.Rollback()
                    End If
                    If sqlCon.State = ConnectionState.Open Then sqlCon.Close()
                    sqlcmd.Dispose()
                End Try
            Else
                Dim strUpdateNSIDN, strUpdateNSIDNWarGuar As String
                Dim sqlCon As New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
                Dim UpdateParam(9) As SqlClient.SqlParameter
                Dim strTran As SqlClient.SqlTransaction
                Dim sqlcmd As New SqlClient.SqlCommand()
                Dim j As Integer

                strUpdateNSIDN = " update ms_sparecell_nsidnno set " & _
                                 "  PLRecdQty =  @PLRecdQty ,  PLRecdOn = @DateRecdbySpaceCell ,  POConsignee =  @ddlCons ,  NSIDNDate = @NSIDNDate , " & _
                                 "  SentToShopOn = @SentToShopOn ,  RecdByShopOn = @RecdByShopOn ,  Remarks =  @Remarks  , " & _
                                 "  InVoiceNo = @InVoiceNo , InVoiceDate = @InVoiceDate where  NsIDnId = @NSIDNNo  "

                UpdateParam(0) = New SqlClient.SqlParameter("@NSIDNNo", SqlDbType.BigInt, 8)
                UpdateParam(1) = New SqlClient.SqlParameter("@PLRecdQty", SqlDbType.Float, 8)
                UpdateParam(2) = New SqlClient.SqlParameter("@DateRecdbySpaceCell", SqlDbType.SmallDateTime, 4)
                UpdateParam(3) = New SqlClient.SqlParameter("@ddlCons", SqlDbType.Int, 4)
                UpdateParam(4) = New SqlClient.SqlParameter("@NSIDNDate", SqlDbType.SmallDateTime, 4)
                UpdateParam(5) = New SqlClient.SqlParameter("@SentToShopOn", SqlDbType.SmallDateTime, 4)
                UpdateParam(6) = New SqlClient.SqlParameter("@RecdByShopOn", SqlDbType.SmallDateTime, 4)
                UpdateParam(7) = New SqlClient.SqlParameter("@Remarks", SqlDbType.VarChar, 500)
                UpdateParam(8) = New SqlClient.SqlParameter("@InVoiceNo", SqlDbType.VarChar, 50)
                UpdateParam(9) = New SqlClient.SqlParameter("@InVoiceDate", SqlDbType.SmallDateTime, 4)


                UpdateParam(0).Direction = ParameterDirection.Input
                UpdateParam(1).Direction = ParameterDirection.Input
                UpdateParam(2).Direction = ParameterDirection.Input
                UpdateParam(3).Direction = ParameterDirection.Input
                UpdateParam(4).Direction = ParameterDirection.Input
                UpdateParam(5).Direction = ParameterDirection.Input
                UpdateParam(6).Direction = ParameterDirection.Input
                UpdateParam(7).Direction = ParameterDirection.Input
                UpdateParam(8).Direction = ParameterDirection.Input
                UpdateParam(9).Direction = ParameterDirection.Input

                Try
                    UpdateParam(0).Value = longNSIDNid
                    UpdateParam(1).Value = decPLRecdQty
                    UpdateParam(2).Value = dateDateRecdbySpaceCell
                    UpdateParam(3).Value = intConsignee
                    UpdateParam(4).Value = dateNSIDNDate
                    UpdateParam(5).Value = dateSentToShopOn
                    UpdateParam(6).Value = dateRecdByShopOn
                    UpdateParam(7).Value = sRemarks & ""
                    UpdateParam(8).Value = sInVoiceNo & ""
                    UpdateParam(9).Value = dateInVoiceDate
                Catch exp As Exception
                    sMessage &= exp.Message
                End Try
                Dim i As Integer
                Try
                    sqlcmd.Connection = sqlCon
                    If sqlcmd.Connection.State = ConnectionState.Closed Then sqlcmd.Connection.Open()
                    sqlcmd.Transaction = sqlcmd.Connection.BeginTransaction

                    For j = 0 To 9
                        sqlcmd.Parameters.Add(UpdateParam(j))
                    Next
                    sqlcmd.CommandText = strUpdateNSIDN
                    i = sqlcmd.ExecuteNonQuery()
                    For j = 0 To 9
                        sqlcmd.Parameters.Remove(UpdateParam(j))
                    Next
                Catch exp As Exception
                    sMessage &= exp.Message
                Finally
                    If i <> 0 Then
                        sqlcmd.Transaction.Commit()
                        blnNextNumberGenerated = True
                        sMessage = "NS IDN No : '" & longNSIDNid & "' Updated "
                    Else
                        sMessage &= sMessage
                        blnNextNumberGenerated = False
                        sqlcmd.Transaction.Rollback()
                    End If
                    If sqlCon.State = ConnectionState.Open Then sqlCon.Close()
                    sqlcmd.Dispose()
                End Try
            End If
            Return blnNextNumberGenerated
        End Function
        Public Function SaveIMBRegister(ByVal NSCount As Integer) As Boolean
            Dim strNSIDNRegister, strPOid, strNSIDN, strNSGP, strNSslno As String
            Dim sqlCon As New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
            Dim NSIDNRegparam(11), NSSparesParam(3), NSSlNoparam(2) As SqlClient.SqlParameter
            Dim sqlcmd As New SqlClient.SqlCommand()
            Dim j As Integer
            If NSCount > 0 Then
                strNSIDNRegister = " update ms_IMBRegister set LedgerNumber = @IMBLedgerNumber ,  NSIDNRecdOn = @DateRecdByIMB , " & _
                                   " SentToConsigneeOn = @DateSentToConsigneeOn , RecdBackOnFromConsignee =  @DateReceivedBackOnFromShop , " & _
                                   " Status = @Status , AcceptingAuthority = @AcceptingAuthority ,  " & _
                                   " LocationID = @LocationID , Remarks = @Remarks , SentBackToSpareCellOn = @SentBackToSpareCellOn ," & _
                                   " PLAcceptedQty = @PLAcceptedQty , PLRejQty = @PLRejQty " & _
                                   " where NSIDNid = @NSIDNid "
            Else
                strNSIDNRegister = " insert into ms_IMBRegister ( LedgerNumber , NSIDNid , NSIDNRecdOn , SentToConsigneeOn ," & _
                                   " RecdBackOnFromConsignee , Status , AcceptingAuthority , " & _
                                   " LocationID , Remarks , SentBackToSpareCellOn  , PLAcceptedQty , PLRejQty )" & _
                                   "  values ( @IMBLedgerNumber , @NSIDNid , @DateRecdByIMB, " & _
                                   " @DateSentToConsigneeOn , @DateReceivedBackOnFromShop , @Status , @AcceptingAuthority , " & _
                                   " @LocationID , @Remarks , @SentBackToSpareCellOn , @PLAcceptedQty , @PLRejQty  )"
            End If
            NSIDNRegparam(0) = New SqlClient.SqlParameter("@IMBLedgerNumber", SqlDbType.VarChar, 50)
            NSIDNRegparam(1) = New SqlClient.SqlParameter("@NSIDNid", SqlDbType.BigInt, 8)
            NSIDNRegparam(2) = New SqlClient.SqlParameter("@DateRecdByIMB", SqlDbType.SmallDateTime, 4)
            NSIDNRegparam(3) = New SqlClient.SqlParameter("@DateSentToConsigneeOn", SqlDbType.SmallDateTime, 4)
            NSIDNRegparam(4) = New SqlClient.SqlParameter("@DateReceivedBackOnFromShop", SqlDbType.SmallDateTime, 4)
            NSIDNRegparam(5) = New SqlClient.SqlParameter("@Status", SqlDbType.VarChar, 20)
            NSIDNRegparam(6) = New SqlClient.SqlParameter("@AcceptingAuthority", SqlDbType.VarChar, 20)
            NSIDNRegparam(7) = New SqlClient.SqlParameter("@LocationID", SqlDbType.VarChar, 20)
            NSIDNRegparam(8) = New SqlClient.SqlParameter("@Remarks", SqlDbType.VarChar, 2000)
            NSIDNRegparam(9) = New SqlClient.SqlParameter("@SentBackToSpareCellOn", SqlDbType.SmallDateTime, 4)
            NSIDNRegparam(10) = New SqlClient.SqlParameter("@PLAcceptedQty", SqlDbType.Float, 8)
            NSIDNRegparam(11) = New SqlClient.SqlParameter("@PLRejQty", SqlDbType.Float, 8)

            NSIDNRegparam(0).Direction = ParameterDirection.Input
            NSIDNRegparam(1).Direction = ParameterDirection.Input
            NSIDNRegparam(2).Direction = ParameterDirection.Input
            NSIDNRegparam(3).Direction = ParameterDirection.Input
            NSIDNRegparam(4).Direction = ParameterDirection.Input
            NSIDNRegparam(5).Direction = ParameterDirection.Input
            NSIDNRegparam(6).Direction = ParameterDirection.Input
            NSIDNRegparam(7).Direction = ParameterDirection.Input
            NSIDNRegparam(8).Direction = ParameterDirection.Input
            NSIDNRegparam(9).Direction = ParameterDirection.Input
            NSIDNRegparam(10).Direction = ParameterDirection.Input
            NSIDNRegparam(11).Direction = ParameterDirection.Input

            strNSslno = " select @IncrNo = IncrNo , @SlNo = SlNo  from ms_imbregister where NSIDNid = @NSIDNid "

            NSSlNoparam(0) = New SqlClient.SqlParameter("@NSIDNid", SqlDbType.BigInt, 8)
            NSSlNoparam(1) = New SqlClient.SqlParameter("@IncrNo", SqlDbType.Int, 4)
            NSSlNoparam(2) = New SqlClient.SqlParameter("@SlNo", SqlDbType.VarChar, 33)

            NSSlNoparam(0).Direction = ParameterDirection.Input
            NSSlNoparam(1).Direction = ParameterDirection.Output
            NSSlNoparam(2).Direction = ParameterDirection.Output

            NSSparesParam(0) = New SqlClient.SqlParameter("@NSIDNid", SqlDbType.BigInt, 8)
            NSSparesParam(1) = New SqlClient.SqlParameter("@RecdByShopOn", SqlDbType.SmallDateTime, 4)
            NSSparesParam(2) = New SqlClient.SqlParameter("@InVoiceNo", SqlDbType.VarChar, 50)
            NSSparesParam(3) = New SqlClient.SqlParameter("@InVoiceDate", SqlDbType.SmallDateTime, 4)

            Try
                NSSlNoparam(0).Value = IIf(IsDBNull(longNSIDNid), "0", longNSIDNid)
            Catch exp As Exception
                sMessage = exp.Message
            End Try
            Dim i As Integer
            Try
                NSIDNRegparam(0).Value = sLedgerNumber
                NSIDNRegparam(1).Value = IIf(IsDBNull(longNSIDNid), "0", longNSIDNid)
                NSIDNRegparam(2).Value = dateNSIDNRecdOn
                NSIDNRegparam(3).Value = dateSentToShopOn
                NSIDNRegparam(4).Value = dateReceivedBackOn
                NSIDNRegparam(5).Value = sStatus
                NSIDNRegparam(6).Value = sAcceptingAuthority
                NSIDNRegparam(7).Value = sLocation
                NSIDNRegparam(8).Value = sRemarks
                NSIDNRegparam(9).Value = dateSentToSparesOn
                NSIDNRegparam(10).Value = decAccpQty
                NSIDNRegparam(11).Value = decRejQty
                NSSparesParam(0).Value = IIf(IsDBNull(longNSIDNid), "0", longNSIDNid)
                NSSparesParam(1).Value = dateRecdByShopOn
                NSSparesParam(2).Value = sInVoiceNo
                NSSparesParam(3).Value = dateInVoiceDate
                i = 1
            Catch exp As Exception
                sMessage = exp.Message
            End Try
            If i = 1 Then
                i = 0
            Else
                Throw New Exception("Value assignment error !")
            End If


            Try
                sqlcmd.Connection = sqlCon
                sqlcmd.CommandText = strNSIDNRegister
                For j = 0 To 11
                    sqlcmd.Parameters.Add(NSIDNRegparam(j))
                Next
                If sqlcmd.Connection.State = ConnectionState.Closed Then sqlcmd.Connection.Open()
                sqlcmd.Transaction = sqlcmd.Connection.BeginTransaction
                i = sqlcmd.ExecuteNonQuery
                For j = 0 To 11
                    sqlcmd.Parameters.Remove(NSIDNRegparam(j))
                Next
                If i = 1 Then
                    sqlcmd.CommandText = " update ms_sparecell_nsidnno set  RecdByShopOn = @RecdByShopOn ," & _
                                    " InVoiceNo = @InVoiceNo , InVoiceDate = @InVoiceDate  where   NSIDNid =  @NSIDNid "
                    For j = 0 To 3
                        sqlcmd.Parameters.Add(NSSparesParam(j))
                    Next
                    Try
                        i = sqlcmd.ExecuteNonQuery
                        For j = 0 To 3
                            sqlcmd.Parameters.Remove(NSSparesParam(j))
                        Next
                    Catch exp As Exception
                        sMessage = exp.Message
                    End Try
                    If i = 1 Then
                        sqlcmd.CommandText = strNSslno
                        For j = 0 To 2
                            sqlcmd.Parameters.Add(NSSlNoparam(j))
                        Next
                        i = 0
                        Try
                            sqlcmd.ExecuteScalar()
                            For j = 0 To 2
                                sqlcmd.Parameters.Remove(NSSlNoparam(j))
                            Next
                            i = 1
                        Catch exp As Exception
                            sMessage = exp.Message
                        End Try
                    End If
                End If
            Catch exp As Exception
                sMessage = exp.Message
            Finally
                If i <> 0 Then
                    sqlcmd.Transaction.Commit()
                    sMessage = "NS IDN No : '" & longNSIDNid & "' UPDATED"
                    SaveIMBRegister = True
                Else
                    sqlcmd.Transaction.Rollback()
                End If
                If sqlcmd.Connection.State = ConnectionState.Open Then sqlcmd.Connection.Close()
                sqlcmd.Dispose()
            End Try
        End Function
        Public Shared Function DeleteNSIDNid(ByVal NSIDNid As Long) As Boolean
            Dim da As New SqlClient.SqlDataAdapter()
            da.SelectCommand = New SqlClient.SqlCommand()
            da.SelectCommand.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
            da.SelectCommand.CommandText = " delete from ms_sparecell_nsidnno  where NsIDnId  = " & NSIDNid & " "
            Try
                If da.SelectCommand.Connection.State = ConnectionState.Closed Then da.SelectCommand.Connection.Open()
                If da.SelectCommand.ExecuteNonQuery() Then Return True
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If da.SelectCommand.Connection.State = ConnectionState.Open Then da.SelectCommand.Connection.Close()
                da.Dispose()
            End Try
        End Function
        Public Shared Function DeletePI(ByVal NSIDNid As Long) As Boolean
            Dim da As New SqlClient.SqlDataAdapter()
            da.SelectCommand = New SqlClient.SqlCommand()
            da.SelectCommand.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
            da.SelectCommand.CommandText = " delete from ms_sparecell_nsidnno  where NsIDnId  = " & NSIDNid & " "
            Try
                If da.SelectCommand.Connection.State = ConnectionState.Closed Then da.SelectCommand.Connection.Open()
                If da.SelectCommand.ExecuteNonQuery() Then Return True
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If da.SelectCommand.Connection.State = ConnectionState.Open Then da.SelectCommand.Connection.Close()
                da.Dispose()
            End Try
        End Function
        Public Shared Function DeleteNSDBR(ByVal NSDBR As String) As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Parameters.Add("@NSDBR", SqlDbType.VarChar, 9).Value = NSDBR.Trim
                cmd.CommandText = " delete ms_sparecell_nsdbrs  where nsdbr_number = @NSDBR "
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                If cmd.ExecuteNonQuery() > 0 Then
                    cmd.Transaction.Commit()
                    Return True
                Else
                    cmd.Transaction.Rollback()
                    Return False
                End If
            Catch exp As Exception
                Return False
                Throw New Exception(exp.Message)
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
            End Try
        End Function
        Public Function SaveNSDBR() As Boolean
            Dim sNSDBR, strNSDBR, strNSDBRNo As String
            Dim sqlCon As New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
            Dim pNSDBR(0), NSDBRparam(0), NSDBRNoparam(4) As SqlClient.SqlParameter
            Dim strTran As SqlClient.SqlTransaction
            Dim sqlcmd As New SqlClient.SqlCommand()
            Dim j As Integer
            Dim PoId As Double
            Dim iPOid As Decimal
            Dim oCmd As New SqlClient.SqlCommand()
            oCmd.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))

            sNSDBR = " select  count(*) from ms_sparecell_nsdbrs " & _
                  " where nsdbr_number =  @nsdbr_number "

            pNSDBR(0) = New SqlClient.SqlParameter("@nsdbr_number", SqlDbType.VarChar, 9)

            pNSDBR(0).Direction = ParameterDirection.Input

            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            Dim t As Integer
            Try
                pNSDBR(0).Value = sNSDBRNo.Trim
                oCmd.Parameters.Add(pNSDBR(0))
                oCmd.CommandText = sNSDBR
                iPOid = oCmd.ExecuteScalar()
                oCmd.Parameters.Remove(pNSDBR(0))
            Catch exp As Exception
                sMessage = exp.Message
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End Try
            If iPOid = 0 Then
                strNSDBR = " insert into ms_sparecell_nsdbrs ( nsdbr_number ) values ( @nsdbr_number ) "
            End If

            strNSDBRNo = " insert into ms_sparecell_nsidnbill ( NSIDNid , nsdbr_number , sentToHQon , Remarks , BillAmount ) " & _
                       " values ( @NSIDNid , @nsdbr_number , @sentToHQon , @Remarks , @BillAmount ) "


            NSDBRparam(0) = New SqlClient.SqlParameter("@nsdbr_number", SqlDbType.VarChar, 9)
            NSDBRparam(0).Direction = ParameterDirection.Input


            NSDBRNoparam(0) = New SqlClient.SqlParameter("@NSIDNid", SqlDbType.BigInt, 8)
            NSDBRNoparam(0).Direction = ParameterDirection.Input
            NSDBRNoparam(1) = New SqlClient.SqlParameter("@nsdbr_number", SqlDbType.VarChar, 9)
            NSDBRNoparam(1).Direction = ParameterDirection.Input
            NSDBRNoparam(2) = New SqlClient.SqlParameter("@sentToHQon", SqlDbType.SmallDateTime, 4)
            NSDBRNoparam(2).Direction = ParameterDirection.Input
            NSDBRNoparam(3) = New SqlClient.SqlParameter("@Remarks", SqlDbType.VarChar, 500)
            NSDBRNoparam(3).Direction = ParameterDirection.Input
            NSDBRNoparam(4) = New SqlClient.SqlParameter("@BillAmount", SqlDbType.Float, 8)
            NSDBRNoparam(4).Direction = ParameterDirection.Input
            Try
                If iPOid = 0 Then
                    NSDBRparam(0).Value = sNSDBRNo.Trim
                End If

                NSDBRNoparam(0).Value = longNSIDNid
                NSDBRNoparam(1).Value = sNSDBRNo.Trim
                NSDBRNoparam(2).Value = dateSentToHQOn
                NSDBRNoparam(3).Value = sRemarks & ""
                NSDBRNoparam(4).Value = decAccpQty
            Catch exp As Exception
                sMessage = exp.Message
            End Try
            Dim i As Integer

            Try
                sqlcmd.Connection = sqlCon
                If sqlcmd.Connection.State = ConnectionState.Closed Then sqlcmd.Connection.Open()
                sqlcmd.Transaction = sqlcmd.Connection.BeginTransaction
                If iPOid = 0 Then
                    sqlcmd.Parameters.Add(NSDBRparam(0))
                    sqlcmd.CommandText = strNSDBR
                    i = sqlcmd.ExecuteNonQuery()
                    sqlcmd.Parameters.Remove(NSDBRparam(0))
                End If
                i = 0
                For j = 0 To 4
                    sqlcmd.Parameters.Add(NSDBRNoparam(j))
                Next
                Dim strCnt, strUpdate As String
                strCnt = "select count(*) from ms_sparecell_nsidnbill " & _
                        " where  NSIDNid =  @NSIDNid "
                sqlcmd.CommandText = strCnt
                i = sqlcmd.ExecuteScalar
                strUpdate = " update ms_sparecell_nsidnbill set nsdbr_number = @nsdbr_number , BillAmount = @BillAmount , sentToHQon = @sentToHQon , Remarks = @Remarks" & _
                            " where  NSIDNid =  @NSIDNid "
                If i > 0 Then
                    sqlcmd.CommandText = strUpdate
                    i = sqlcmd.ExecuteNonQuery
                Else
                    sqlcmd.CommandText = strNSDBRNo
                    i = sqlcmd.ExecuteNonQuery
                End If
                For j = 0 To 4
                    sqlcmd.Parameters.Remove(NSDBRNoparam(j))
                Next
            Catch exp As Exception
                sMessage = exp.Message
            Finally
                If i <> 0 Then
                    sqlcmd.Transaction.Commit()
                    sMessage = "NS DBR No : '" & sNSDBRNo.Trim & "' saved as below"
                Else
                    sMessage = "NS DBR No : '" & sNSDBRNo.Trim & "' Not saved "
                    sqlcmd.Transaction.Rollback()
                End If
                sqlcmd.Connection.Close()
                sqlcmd.Dispose()
            End Try
            If i <> 0 Then Return True
        End Function
        Public Function SavePRCDetails(ByVal PONumber As String, Optional ByVal PRCid As Long = 0) As Boolean
            Dim blnDone As Boolean
            Dim CMD As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            CMD.Parameters.Add("@PRCid", SqlDbType.BigInt, 8)
            CMD.Parameters("@PRCid").Direction = ParameterDirection.Output
            Try
                CMD.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = sConsignee
                CMD.Parameters.Add("@PONumber", SqlDbType.VarChar, 9).Value = sPONumber
                CMD.Parameters.Add("@LetterNo", SqlDbType.VarChar, 100).Value = sLetterNo
                CMD.Parameters.Add("@LetterDate", SqlDbType.SmallDateTime, 4).Value = dateLetterDate
                CMD.Parameters.Add("@DCNumber", SqlDbType.VarChar, 50).Value = sDCNumber.ToString
                CMD.Parameters.Add("@DCDate", SqlDbType.SmallDateTime, 4).Value = dateDCDate
                CMD.Parameters.Add("@Para2", SqlDbType.VarChar, 250).Value = sPara2
                CMD.Parameters.Add("@nsprc_number", SqlDbType.VarChar, 9).Value = snsprc_number.ToString
                blnDone = True
            Catch exp As Exception
                blnDone = False
            End Try
            If blnDone = True Then
                blnDone = False
            Else
                CMD.Dispose()
                Throw New Exception("Value assingement error !")
                Exit Function
            End If
            Try
                If CMD.Connection.State = ConnectionState.Closed Then CMD.Connection.Open()
                CMD.Transaction = CMD.Connection.BeginTransaction
                If PRCid > 0 Then
                    CMD.Parameters("@PRCid").Direction = ParameterDirection.Input
                    CMD.Parameters("@PRCid").Value = PRCid
                    PRCDetailsEdit(CMD)
                    blnDone = True
                Else
                    PRCDetailsAdd(CMD)
                    If lPRCid > 0 Then blnDone = True
                End If
            Catch exp As Exception
                Throw New Exception("Saving to ms_sparecell_PRC Tables error : " & exp.Message)
            Finally
                If blnDone = True Then
                    If PRCid > 0 Then
                        sMessage = "Updation of NS PRC no : '" & snsprc_number.Trim & "' successful !"
                    Else
                        sMessage = "Generated NS PRC no : '" & snsprc_number.Trim & "' successfully !"
                    End If

                    CMD.Transaction.Commit()
                Else
                    If PRCid > 0 Then
                        sMessage = "Updation of NS PRC no failed !"
                    Else
                        sMessage = "Generation of NS PRC no failed !"
                    End If
                    CMD.Transaction.Rollback()
                End If
                If CMD.Connection.State = ConnectionState.Open Then CMD.Connection.Close()
                CMD.Dispose()
            End Try
            Return blnDone
        End Function
        Private Sub PRCDetailsAdd(ByRef CMD As SqlClient.SqlCommand)
            Try
                CMD.CommandText = "select @PRCid = PRCid  from ms_sparecell_PRC where Consignee = @Consignee and PONumber =  @PONumber " & _
                            " and LetterNo =  @LetterNo and LetterDate =  @LetterDate and DCNumber =  @DCNumber " & _
                            " and DCDate =  @DCDate and Para2 =  @Para2 and nsprc_number = @nsprc_number "
                CMD.ExecuteScalar()
                lPRCid = IIf(IsDBNull(CMD.Parameters("@PRCid").Value), 0, CMD.Parameters("@PRCid").Value)
                If lPRCid = 0 Then
                    CMD.CommandText = " insert into ms_sparecell_PRC ( Consignee , PONumber , LetterNo , LetterDate , DCNumber , DCDate ,  Para2 ,  nsprc_number  )" & _
                                        " values (  @Consignee , @PONumber , @LetterNo , @LetterDate , @DCNumber , @DCDate  , @Para2 ,  @nsprc_number  ) "
                    If CMD.ExecuteNonQuery = 0 Then
                        Throw New Exception(" PRC Saving error")
                    Else
                        CMD.CommandText = "select @PRCid = PRCid  from ms_sparecell_PRC where Consignee = @Consignee and PONumber =  @PONumber " & _
                                " and LetterNo =  @LetterNo and LetterDate =  @LetterDate and DCNumber =  @DCNumber " & _
                                " and DCDate =  @DCDate and Para2 =  @Para2 and nsprc_number = @nsprc_number  "
                        CMD.ExecuteScalar()
                        lPRCid = IIf(IsDBNull(CMD.Parameters("@PRCid").Value), 0, CMD.Parameters("@PRCid").Value)
                        If IsNothing(dtPRCItems) = False Then
                            If dtPRCItems.Rows.Count > 0 Then
                                If SavePRCItemsAdd(CMD, lPRCid, dtPRCItems) = False Then Throw New Exception(" PRC Items Saving error")
                            End If
                        End If
                    End If
                Else
                    sMessage = " NS PRC No : '" & snsprc_number.Trim & "' already exists for NS IDN no : '" & longNSIDNid & "' !"
                End If
            Catch exp As Exception
                Throw New Exception(" Insert into ms_sparecell_PRC error " & exp.Message)
            End Try
        End Sub
        Private Sub PRCDetailsEdit(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " update ms_sparecell_PRC " & _
                    " set LetterNo =  @LetterNo , LetterDate =  @LetterDate ,  DCNumber =  @DCNumber , " & _
                    " DCDate =  @DCDate , MaterialDate =  @MaterialDate , Para2 =  @Para2 " & _
                    " where PONumber =  @PONumber and  PRCid = @PRCid and NsIDnId = @NsIDnId "
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to update PRC details ")
            Catch exp As Exception
                Throw New Exception(" update of ms_sparecell_PRC error :  " & exp.Message)
            End Try
        End Sub
        Public Function SavePRCItemsAdd(ByRef CMD As SqlClient.SqlCommand, ByVal lPRCid As Long, ByVal dtPRCItems As DataTable) As Boolean
            Dim blnDone As Boolean
            Dim cnt As Int16
            CMD.Parameters("@PRCid").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@NSIDNId", SqlDbType.BigInt, 8)
            CMD.Parameters("@NSIDNId").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@Amount", SqlDbType.Float, 8)
            CMD.Parameters("@Amount").Direction = ParameterDirection.Input
            Try
                If dtPRCItems.Rows.Count > 0 Then
                    For cnt = 0 To dtPRCItems.Rows.Count - 1
                        CMD.Parameters("@PRCid").Value = lPRCid
                        CMD.Parameters("@NSIDNId").Value = dtPRCItems.Rows(cnt)(0)
                        CMD.Parameters("@Amount").Value = dtPRCItems.Rows(cnt)(5)
                        CMD.CommandText = "insert into ms_sparecell_PRC_Details ( PRCid , NSIDNId , Amount ) values ( @PRCid , @NSIDNId , @Amount )"
                        If CMD.ExecuteNonQuery() > 0 Then
                            blnDone = True
                        Else
                            Exit For
                        End If
                    Next
                End If
            Catch exp As Exception
                blnDone = False
                Throw New Exception(exp.Message)
            End Try
            Return blnDone
        End Function
        Public Function SavePIDetails(ByVal PONumber As String, Optional ByVal PIid As Long = 0) As Boolean
            Dim blnDone As Boolean
            Dim CMD As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            CMD.Parameters.Add("@PIid", SqlDbType.BigInt, 8)
            CMD.Parameters("@PIid").Direction = ParameterDirection.Output
            Try
                CMD.Parameters.Add("@Consignee", SqlDbType.VarChar, 4).Value = sConsignee
                CMD.Parameters.Add("@PONumber", SqlDbType.VarChar, 9).Value = sPONumber
                CMD.Parameters.Add("@PIDate", SqlDbType.SmallDateTime, 4).Value = dateLetterDate
                CMD.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar, 50).Value = sDCNumber.ToString
                CMD.Parameters.Add("@InvoiceDate", SqlDbType.SmallDateTime, 4).Value = dateDCDate
                CMD.Parameters.Add("@Para2", SqlDbType.VarChar, 250).Value = sPara2
                blnDone = True
            Catch exp As Exception
                blnDone = False
            End Try
            If blnDone = True Then
                blnDone = False
            Else
                CMD.Dispose()
                Throw New Exception("Value assingement error !")
                Exit Function
            End If
            Try
                If CMD.Connection.State = ConnectionState.Closed Then CMD.Connection.Open()
                CMD.Transaction = CMD.Connection.BeginTransaction
                If PIid > 0 Then
                    CMD.Parameters("@PIid").Direction = ParameterDirection.Input
                    CMD.Parameters("@PIid").Value = PIid
                    PIDetailsEdit(CMD)
                    blnDone = True
                Else
                    PIDetailsAdd(CMD)
                    If lPIid > 0 Then blnDone = True
                End If
            Catch exp As Exception
                Throw New Exception("Saving to ms_sparecell_PI Tables error : " & exp.Message)
            Finally
                If blnDone = True Then
                    If PIid > 0 Then
                        sMessage = "Updation of NS PI no  successful !"
                    Else
                        sMessage = "Generated NS PI no successfully !"
                    End If
                    CMD.Transaction.Commit()
                Else
                    If PIid = 0 Then
                        sMessage = "Updation of NS PI no failed !"
                    Else
                        sMessage = "Generation of NS PI no failed !"
                    End If
                    CMD.Transaction.Rollback()
                End If
                If CMD.Connection.State = ConnectionState.Open Then CMD.Connection.Close()
                CMD.Dispose()
                If blnDone = True Then
                    Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
                    da.SelectCommand.CommandText = " select a.PLNumber , b.PLAcceptedQty  , b.NsIDnId , PIid , PIDetailsid from ms_vw_sparecell_PIDetails a left outer join ms_vw_SpareCellIDN b " & _
                                                                " on a.PONumber = b.PONumber and a.PLNumber = b.PLNumber where  a.PIid = " & lPIid & " "
                    Dim ds As New DataSet()
                    da.Fill(ds)
                    dtPISavedDetails = ds.Tables(0).Copy
                    da.Dispose()
                    ds.Dispose()
                End If
            End Try
            Return blnDone
        End Function
        Private Sub PIDetailsAdd(ByRef CMD As SqlClient.SqlCommand)
            Dim blnDone As Boolean
            Try
                CMD.CommandText = "select @PIid = PIid  from ms_sparecell_PI where Consignee = @Consignee and PONumber =  @PONumber " & _
                            " and PIDate =  @PIDate and InvoiceNumber =  @InvoiceNumber " & _
                            " and InvoiceDate =  @InvoiceDate and Para2 =  @Para2 "
                CMD.ExecuteScalar()
                lPIid = IIf(IsDBNull(CMD.Parameters("@PIid").Value), 0, CMD.Parameters("@PIid").Value)
                If lPRCid = 0 Then
                    CMD.CommandText = " insert into ms_sparecell_PI ( Consignee , PONumber , PIDate , InvoiceNumber , InvoiceDate ,  Para2 )" & _
                                        " values (  @Consignee , @PONumber , @PIDate , @InvoiceNumber , @InvoiceDate  , @Para2 ) "
                    If CMD.ExecuteNonQuery = 0 Then
                        Throw New Exception(" PI Saving error")
                    Else
                        CMD.CommandText = "select @PIid = PIid  from ms_sparecell_PI where Consignee = @Consignee and PONumber =  @PONumber " & _
                                " and PIDate =  @PIDate and InvoiceNumber =  @InvoiceNumber " & _
                                " and InvoiceDate =  @InvoiceDate and Para2 =  @Para2 "
                        CMD.ExecuteScalar()
                        lPIid = IIf(IsDBNull(CMD.Parameters("@PIid").Value), 0, CMD.Parameters("@PIid").Value)
                        If IsNothing(dtPIItems) = False Then
                            If dtPIItems.Rows.Count > 0 Then
                                If SavePIItemsAdd(CMD, lPIid, dtPIItems) = False Then Throw New Exception(" PI Items Saving error")
                            End If
                        End If
                    End If
                Else
                    sMessage = " NS PI No  already exists for PONumber : '" & sPONumber & "' !"
                End If
            Catch exp As Exception
                Throw New Exception(" Insert into ms_sparecell_PI error " & exp.Message)
            End Try
        End Sub
        Private Sub PIDetailsEdit(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " update ms_sparecell_PI " & _
                    " set  PIDate =  @PIDate ,  InvoiceNumber =  @InvoiceNumber , " & _
                    " InvoiceDate =  @InvoiceDate , Para2 =  @Para2 " & _
                    " where PONumber =  @PONumber and  PIid = @PIid "
            Try
                If CMD.ExecuteNonQuery = 0 Then
                    Throw New Exception(" PI Updation error")
                Else
                    If IsNothing(dtPIItems) = False Then
                        If dtPIItems.Rows.Count > 0 Then
                            If SavePIItemsEdit(CMD, lPIid, dtPIItems) = False Then Throw New Exception(" PI Items Saving error")
                        End If
                    End If
                End If
            Catch exp As Exception
                Throw New Exception(" update of ms_sparecell_PI error :  " & exp.Message)
            End Try
        End Sub
        Public Function SavePIItemsAdd(ByRef CMD As SqlClient.SqlCommand, ByVal lPIid As Long, ByVal dtPIItems As DataTable) As Boolean
            Dim blnDone As Boolean
            Dim cnt As Int16
            CMD.Parameters("@PIid").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@PLNumber", SqlDbType.VarChar, 8).Direction = ParameterDirection.Input
            CMD.Parameters.Add("@Qty", SqlDbType.Float, 8).Direction = ParameterDirection.Input
            CMD.Parameters.Add("@Amount", SqlDbType.Float, 8).Direction = ParameterDirection.Input
            Try
                If dtPIItems.Rows.Count > 0 Then
                    For cnt = 0 To dtPIItems.Rows.Count - 1
                        CMD.Parameters("@PIid").Value = lPIid
                        CMD.Parameters("@PLNumber").Value = dtPIItems.Rows(cnt)(0)
                        CMD.Parameters("@Qty").Value = dtPIItems.Rows(cnt)(3)
                        CMD.Parameters("@Amount").Value = dtPIItems.Rows(cnt)(5)
                        CMD.CommandText = "insert into ms_sparecell_PI_Details ( PIid , PLNumber , Qty ,  Amount ) values ( @PIid , @PLNumber , @Qty , @Amount )"
                        If CMD.ExecuteNonQuery() > 0 Then
                            blnDone = True
                        Else
                            Exit For
                        End If
                    Next
                End If
            Catch exp As Exception
                blnDone = False
                Throw New Exception(exp.Message)
            End Try
            Return blnDone
        End Function
        Public Function SavePIItemsEdit(ByRef CMD As SqlClient.SqlCommand, ByVal lPIid As Long, ByVal dtPIItems As DataTable) As Boolean
            Dim blnDone As Boolean
            Dim cnt As Int16
            CMD.Parameters("@PIid").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@PLNumber", SqlDbType.VarChar, 8).Direction = ParameterDirection.Input
            CMD.Parameters.Add("@NsIDnId", SqlDbType.BigInt, 8).Direction = ParameterDirection.Input
            CMD.Parameters.Add("@PIDetailsid", SqlDbType.BigInt, 8).Direction = ParameterDirection.Input
            Try
                If dtPIItems.Rows.Count > 0 Then
                    For cnt = 0 To dtPIItems.Rows.Count - 1
                        CMD.Parameters("@PLNumber").Value = dtPIItems.Rows(cnt)(2)
                        CMD.Parameters("@NsIDnId").Value = dtPIItems.Rows(cnt)(5)
                        CMD.Parameters("@PIid").Value = dtPIItems.Rows(cnt)(6)
                        CMD.Parameters("@PIDetailsid").Value = dtPIItems.Rows(cnt)(7)
                        CMD.CommandText = "update ms_sparecell_PI_Details set NsIDnId = @NsIDnId where PIid = @PIid and PIDetailsid =  @PIDetailsid "
                        If CMD.ExecuteNonQuery() > 0 Then
                            blnDone = True
                        Else
                            Exit For
                        End If
                    Next
                End If
            Catch exp As Exception
                blnDone = False
                Throw New Exception(exp.Message)
            End Try
            Return blnDone
        End Function
        Public Function UpdatePrint(ByVal Selected As Int16, ByVal SelectedString As String) As Boolean
            Dim blnDone As Boolean
            Dim CMD As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                If CMD.Connection.State = ConnectionState.Closed Then CMD.Connection.Open()
                CMD.Transaction = CMD.Connection.BeginTransaction
                If Selected = 0 Then
                    CMD.CommandText = " update ms_sparecell_nsidnbill set Printed = 0 "
                    If CMD.ExecuteNonQuery > 0 Then
                        CMD.CommandText = "  update ms_sparecell_nsidnbill set Printed = 1 where NsIDnId in " & SelectedString & " "
                        If CMD.ExecuteNonQuery > 0 Then blnDone = True
                    End If
                ElseIf Selected = 1 Then
                    CMD.CommandText = " update ms_sparecell_PRC set Printed = 0 "
                    If CMD.ExecuteNonQuery > 0 Then
                        CMD.CommandText = "  update ms_sparecell_PRC set Printed = 1 where nsprc_number in " & SelectedString & " "
                        If CMD.ExecuteNonQuery > 0 Then blnDone = True
                    End If
                Else
                    CMD.CommandText = " update ms_sparecell_PI set Printed = 0 "
                    If CMD.ExecuteNonQuery > 0 Then
                        CMD.CommandText = "  update ms_sparecell_PI set Printed = 1 where PIid in " & SelectedString & " "
                        If CMD.ExecuteNonQuery > 0 Then blnDone = True
                    End If
                End If
            Catch exp As Exception
                blnDone = False
                Throw New Exception(exp.Message)
            Finally
                If blnDone Then
                    CMD.Transaction.Commit()
                Else
                    CMD.Transaction.Rollback()
                End If
                CMD.Dispose()
            End Try
            Return blnDone
        End Function
        Public Shared Function DeletePI(ByVal PIid As Long, ByVal PIDetailsid As Long) As Boolean
            Dim done As Boolean
            Dim da As New SqlClient.SqlDataAdapter()
            da.SelectCommand = New SqlClient.SqlCommand()
            da.SelectCommand.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
            da.SelectCommand.CommandText = " delete  ms_sparecell_PI_Details where PIid =   " & PIid & " "
            Try
                If da.SelectCommand.Connection.State = ConnectionState.Closed Then da.SelectCommand.Connection.Open()
                da.SelectCommand.Transaction = da.SelectCommand.Connection.BeginTransaction
                If da.SelectCommand.ExecuteNonQuery > 0 Then
                    da.SelectCommand.CommandText = " delete  ms_sparecell_pi where PIid =   " & PIid & " "
                    If da.SelectCommand.ExecuteNonQuery = 1 Then
                        done = True
                    End If
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If done Then
                    da.SelectCommand.Transaction.Commit()
                Else
                    da.SelectCommand.Transaction.Rollback()
                End If
                If da.SelectCommand.Connection.State = ConnectionState.Open Then da.SelectCommand.Connection.Close()
                da.Dispose()
            End Try
            Return done
        End Function
        Public Shared Function RejAdvice(ByVal DocumentID As Long, ByVal AdviceDate As Date) As Long
            Dim blnDone As Boolean
            Dim CMD As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            CMD.Parameters.Add("@AdviceId", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
            Try
                CMD.Parameters.Add("@DocumentID", SqlDbType.BigInt, 8).Value = DocumentID
                CMD.Parameters.Add("@AdviceDate", SqlDbType.SmallDateTime, 4).Value = AdviceDate
                CMD.Connection.Open()
                CMD.CommandText = " insert into ms_sparecell_AdviceID ( DocumentID , AdviceDate )" & _
                      " values (  @DocumentID , @AdviceDate ) "
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" PI Saving error")
                CMD.CommandText = "select @AdviceId = AdviceId  from ms_sparecell_AdviceID " & _
                           " where DocumentID = @DocumentID and AdviceDate =  @AdviceDate "
                CMD.ExecuteScalar()
                RejAdvice = IIf(IsDBNull(CMD.Parameters("@AdviceId").Value), 0, CMD.Parameters("@AdviceId").Value)
            Catch exp As Exception
                Throw New Exception(" Insert into ms_sparecell_AdviceID error " & exp.Message)
            Finally
                CMD.Connection.Close()
                CMD.Dispose()
            End Try
        End Function
#End Region
    End Class
    <Serializable()> Public Class Bills
#Region " Bills Fields "
        Private intNSIDNno, intDocumnetType, intBillPercent As Integer
        Private sReasons, sSentOn, sReceivedOn, sMessage, sSupplierCode, sPONumber As String
        Private sSubject, sReference, sPara1, sPara2, sPara3, sPara4, sConsigneeName As String
        Private blnDeleted As Boolean
        Private dateDateSaved As Date
        Private lRecID, lNotingID, lCheckListID, lDocumentID As Long
        Private objItemsList As CriticalItems.Listing
        Private dtCheckListItems, dtDocumentItems, dtSavedCheckListItems As DataTable
#End Region
#Region " Bills Property "
        Property BillPercent() As Integer
            Get
                Return intBillPercent
            End Get
            Set(ByVal Value As Integer)
                intBillPercent = Value
            End Set
        End Property
        Property SavedCheckListItems() As DataTable
            Get
                Return dtSavedCheckListItems
            End Get
            Set(ByVal Value As DataTable)
                dtSavedCheckListItems = Value
            End Set
        End Property
        Property DocumnetType() As Integer
            Get
                Return intDocumnetType
            End Get
            Set(ByVal Value As Integer)
                intDocumnetType = Value
            End Set
        End Property
        Property DocumentID() As Long
            Get
                Return lDocumentID
            End Get
            Set(ByVal Value As Long)
                lDocumentID = Value
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
        Property SupplierCode() As String
            Get
                Return sSupplierCode
            End Get
            Set(ByVal Value As String)
                sSupplierCode = Value
            End Set
        End Property
        Property DocumentItems() As DataTable
            Get
                Return dtDocumentItems
            End Get
            Set(ByVal Value As DataTable)
                dtDocumentItems = Value
            End Set
        End Property
        Property CheckListItemsTable() As DataTable
            Get
                Return dtCheckListItems
            End Get
            Set(ByVal Value As DataTable)
                dtCheckListItems = Value
            End Set
        End Property
        Property CheckListID() As Long
            Get
                Return lCheckListID
            End Get
            Set(ByVal Value As Long)
                lCheckListID = Value
            End Set
        End Property
        ReadOnly Property ItemsList() As CriticalItems.Listing
            Get
                Return objItemsList
            End Get
        End Property
        Property Subject() As String
            Get
                Return sSubject
            End Get
            Set(ByVal Value As String)
                sSubject = Value
            End Set
        End Property
        Property Reference() As String
            Get
                Return sReference
            End Get
            Set(ByVal Value As String)
                sReference = Value
            End Set
        End Property
        Property Para1() As String
            Get
                Return sPara1
            End Get
            Set(ByVal Value As String)
                sPara1 = Value
            End Set
        End Property
        Property Para2() As String
            Get
                Return sPara2
            End Get
            Set(ByVal Value As String)
                sPara2 = Value
            End Set
        End Property
        Property Para3() As String
            Get
                Return sPara3
            End Get
            Set(ByVal Value As String)
                sPara3 = Value
            End Set
        End Property
        Property Para4() As String
            Get
                Return sPara4
            End Get
            Set(ByVal Value As String)
                sPara4 = Value
            End Set
        End Property
        Property NotingID() As Long
            Get
                Return lNotingID
            End Get
            Set(ByVal Value As Long)
                lNotingID = Value
            End Set
        End Property
        ReadOnly Property Message() As String
            Get
                Return sMessage
            End Get
        End Property
        Property DateSaved() As Date
            Get
                Return dateDateSaved
            End Get
            Set(ByVal Value As Date)
                dateDateSaved = Value
            End Set
        End Property
        Property RecID() As Long
            Get
                Return lRecID
            End Get
            Set(ByVal Value As Long)
                lRecID = Value
            End Set
        End Property
        Property Deleted() As Boolean
            Get
                Return blnDeleted
            End Get
            Set(ByVal Value As Boolean)
                blnDeleted = Value
            End Set
        End Property
        Property SentOn() As String
            Get
                Return sSentOn
            End Get
            Set(ByVal Value As String)
                sSentOn = Value
            End Set
        End Property
        Property ReceivedOn() As String
            Get
                Return sReceivedOn
            End Get
            Set(ByVal Value As String)
                sReceivedOn = Value
            End Set
        End Property
        Property Reasons() As String
            Get
                Return sReasons
            End Get
            Set(ByVal Value As String)
                sReasons = Value
            End Set
        End Property
        Property NSIDNno() As Integer
            Get
                Return intNSIDNno
            End Get
            Set(ByVal Value As Integer)
                If Value <= 0 Then
                    Throw New Exception("InValid NS IDN no !")
                Else
                    intNSIDNno = Value
                End If
            End Set
        End Property
#End Region
#Region " Bills Methods "
        Private Sub intVals()
            intBillPercent = 0
            sConsigneeName = ""
            sPONumber = ""
            sReasons = ""
            sSentOn = ""
            sReceivedOn = ""
            blnDeleted = False
            dateDateSaved = "01/01/1900"
            sSubject = ""
            sReference = " "
            sPara1 = ""
            sPara2 = ""
            sPara3 = ""
            sPara4 = ""
            sSupplierCode = ""
            lDocumentID = 0
            intDocumnetType = 0
            dtSavedCheckListItems = Nothing
        End Sub
        Public Sub New(ByVal PONumber As String, ByVal DocumnetType As Integer)
            intVals()
            If CheckPO(PONumber, DocumnetType) Then
                sSupplierCode = sSupplierCode
            Else
                Throw New Exception("InValid PO Number !")
            End If
        End Sub
        Public Sub New(ByVal NSIDNno As Double)
            intVals()
            If CheckNSIDNno(NSIDNno) Then
                intNSIDNno = NSIDNno
            Else
                Throw New Exception("Unable to Initialize Class!")
            End If
        End Sub
        Public Sub New()
            objItemsList = New CriticalItems.Listing()
        End Sub
        Private Function CheckPO(ByVal PONumber As String, ByVal DocumnetType As Integer) As Boolean
            Dim Found As Integer
            Dim Cmd As System.Data.SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Cmd.Parameters.Add("@Cnt", SqlDbType.Int, 4)
            Cmd.Parameters("@Cnt").Direction = ParameterDirection.Output
            Cmd.Parameters.Add("@PONumber", SqlDbType.VarChar, 9)
            Cmd.Parameters("@PONumber").Direction = ParameterDirection.Input
            Cmd.Parameters.Add("@SupplierCode", SqlDbType.VarChar, 8)
            Cmd.Parameters("@SupplierCode").Direction = ParameterDirection.Output
            If DocumnetType = 6 Then
                Cmd.CommandText = " select  @Cnt = count(*) from ms_vw_sparecell_podetails a inner join ms_vw_SpareCellIDN b on a.PONumber = b.PONumber and a.PLNumber = b.PLNumber  " & _
                " where a.PONumber = @PONumber and Status = 'REJECTED'    ; " & _
                " select @SupplierCode = a.supplier_code from ms_vw_sparecell_podetails a inner join ms_vw_SpareCellIDN b on a.PONumber = b.PONumber and a.PLNumber = b.PLNumber  " & _
                " where a.PONumber = @PONumber and Status = 'REJECTED' "
            ElseIf DocumnetType = 5 Then
                Cmd.CommandText = " select  @Cnt = count(*) from pm_po_header a , pm_supplier_master c  where  c.supplier_code = a.supplier_code and a.po_number = @PONumber  ; select @SupplierCode = a.supplier_code from pm_po_header a , pm_supplier_master c  where  c.supplier_code = a.supplier_code and a.po_number = @PONumber "
            ElseIf DocumnetType = 0 Or DocumnetType = 1 Or DocumnetType = 2 Or DocumnetType = 7 Then
                Cmd.CommandText = " select @Cnt = count(*) from ms_vw_sparecell_podetails where PONumber = @PONumber ; select @SupplierCode = supplier_code from ms_vw_sparecell_podetails where PONumber = @PONumber "
            Else
                Cmd.CommandText = " select @Cnt = count(*) from ms_sparecell_po where PONumber = @PONumber ; select @SupplierCode = supplier_code from ms_vw_sparecell_po_nsidnno where PONumber = @PONumber and Status = 'ACCEPTED'"
            End If

            Try
                Cmd.Parameters("@PONumber").Value = PONumber
                If Cmd.Connection.State = ConnectionState.Closed Then Cmd.Connection.Open()
                Cmd.ExecuteScalar()
                Found = IIf(IsDBNull(Cmd.Parameters("@Cnt").Value), 0, Cmd.Parameters("@Cnt").Value)
                If Found Then
                    sSupplierCode = Cmd.Parameters("@SupplierCode").Value
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If Cmd.Connection.State = ConnectionState.Open Then Cmd.Connection.Close()
                Cmd.Dispose()
            End Try
            If Found > 0 Then Return True
        End Function
        Public Shared Function CheckNSIDNno(ByVal NSIDNno As Integer) As Boolean
            Dim Found As Integer
            Dim Cmd As System.Data.SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Dim ds As New DataSet()
            Cmd.Parameters.Add("@Cnt", SqlDbType.Int, 4)
            Cmd.Parameters("@Cnt").Direction = ParameterDirection.Output
            Cmd.Parameters.Add("@NSIDNno", SqlDbType.Int, 4)
            Cmd.Parameters("@NSIDNno").Direction = ParameterDirection.Input

            Cmd.CommandText = " select @Cnt = count(*) from ms_sparecell_nsidnno where NsIDnId = @NSIDNno ; "
            Try
                Cmd.Parameters("@NSIDNno").Value = NSIDNno
                If Cmd.Connection.State = ConnectionState.Closed Then Cmd.Connection.Open()
                Cmd.ExecuteScalar()
                Found = IIf(IsDBNull(Cmd.Parameters("@Cnt").Value), 0, Cmd.Parameters("@Cnt").Value)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If Cmd.Connection.State = ConnectionState.Open Then Cmd.Connection.Close()
                Cmd.Dispose()
            End Try
            If Found > 0 Then Return True
        End Function
        Public Function SaveBillsPending(ByVal intNSIDNno As Integer, Optional ByVal lRecID As Long = 0, Optional ByVal Delete As Boolean = False, Optional ByVal UndoDelete As Boolean = False) As Boolean
            Dim blnDone As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@NSIDNno", SqlDbType.Int, 4)
            cmd.Parameters("@NSIDNno").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@Reasons", SqlDbType.VarChar, 500)
            cmd.Parameters("@Reasons").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@SentOn", SqlDbType.VarChar, 100)
            cmd.Parameters("@SentOn").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@ReceivedOn", SqlDbType.VarChar, 100)
            cmd.Parameters("@ReceivedOn").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@DeleteStatus", SqlDbType.Bit, 1)
            cmd.Parameters("@DeleteStatus").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@DateSaved", SqlDbType.DateTime, 8)
            cmd.Parameters("@DateSaved").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@RecID", SqlDbType.BigInt, 8)
            cmd.Parameters("@RecID").Direction = ParameterDirection.Output
            Try
                cmd.Parameters("@NSIDNno").Value = intNSIDNno
                cmd.Parameters("@Reasons").Value = sReasons
                cmd.Parameters("@SentOn").Value = sSentOn
                cmd.Parameters("@ReceivedOn").Value = sReceivedOn
                cmd.Parameters("@DeleteStatus").Value = blnDeleted
                cmd.Parameters("@DateSaved").Value = Now
                cmd.Parameters("@RecID").Value = lRecID
                blnDone = True
            Catch exp As Exception
                blnDone = False
            End Try
            If blnDone = True Then
                blnDone = False
            Else
                cmd.Dispose()
                Throw New Exception("Value assingement error !")
                Exit Function
            End If
            Try
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                'cmd.CommandText = " select @YWid = YWid from mm_YardWheelAccount where AreaNo = @AreaNo and WheelCategory = @WheelCategory and  LineNumber = @LineNumber and  WheelStatus  = @WheelStatus "
                If lRecID > 0 Then
                    cmd.Parameters("@RecID").Direction = ParameterDirection.Input
                    If UndoDelete = False Then
                        If Delete = False Then
                            BillsPendingEdit(cmd)
                        Else
                            BillsPendingDelete(cmd)
                        End If
                    Else
                        BillsPendingUndoDelete(cmd)
                    End If
                Else
                    If Delete = False Then BillsPendingAdd(cmd)
                End If
                blnDone = True
            Catch exp As Exception
                sMessage = exp.Message
                Throw New Exception(exp.Message)
            Finally
                If blnDone = True Then
                    cmd.Transaction.Commit()
                Else
                    cmd.Transaction.Rollback()
                End If
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
            End Try
            Return blnDone
        End Function
        Private Sub BillsPendingAdd(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " insert into ms_sparecell_BillsPending  " & _
                        " ( NSIDNno , Reasons , SentOn , ReceivedOn ,  Deleted , DateSaved) " & _
                        " values  ( @NSIDNno , @Reasons ,  @SentOn , @ReceivedOn , @DeleteStatus , @DateSaved )"
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Bills Pending List error")
            Catch exp As Exception
                Throw New Exception(" Insert into ms_sparecell_BillsPending error " & exp.Message)
            End Try
        End Sub
        Private Sub BillsPendingEdit(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " update ms_sparecell_BillsPending set Reasons = @Reasons , " & _
                        " SentOn = @SentOn  , ReceivedOn = @ReceivedOn , DateSaved = @DateSaved " & _
                        " where RecID = @RecID and NSIDNno = @NSIDNno"
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to update Bills Pending  List details ")
            Catch exp As Exception
                Throw New Exception(" update of ms_sparecell_BillsPending error :  " & exp.Message)
            End Try
        End Sub
        Private Sub BillsPendingDelete(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " update  ms_sparecell_BillsPending set Deleted = @DeleteStatus where RecID = @RecID"
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to delete Bills Pending List details ")
            Catch exp As Exception
                Throw New Exception(" delete of ms_sparecell_BillsPending error :  " & exp.Message)
            End Try
        End Sub
        Private Sub BillsPendingUndoDelete(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " update  ms_sparecell_BillsPending set Deleted = '0' where RecID = @RecID"
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to Undo Delete Bills Pending List details ")
            Catch exp As Exception
                Throw New Exception(" Undo Delete of ms_sparecell_BillsPending error :  " & exp.Message)
            End Try
        End Sub
        Public Function SaveBillsNoting(ByVal intNSIDNno As Integer, Optional ByVal lNotingID As Long = 0, Optional ByVal Delete As Boolean = False, Optional ByVal UndoDelete As Boolean = False) As Boolean
            Dim blnDone As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.Parameters.Add("@NSIDNno", SqlDbType.BigInt, 8)
            cmd.Parameters("@NSIDNno").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@Subject", SqlDbType.VarChar, 100)
            cmd.Parameters("@Subject").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@Reference", SqlDbType.VarChar, 200)
            cmd.Parameters("@Reference").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@Para1", SqlDbType.VarChar, 2000)
            cmd.Parameters("@Para1").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@Para2", SqlDbType.VarChar, 2000)
            cmd.Parameters("@Para2").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@Para3", SqlDbType.VarChar, 2000)
            cmd.Parameters("@Para3").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@Para4", SqlDbType.VarChar, 2000)
            cmd.Parameters("@Para4").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@DateOfSaving", SqlDbType.SmallDateTime, 4)
            cmd.Parameters("@DateOfSaving").Direction = ParameterDirection.Input
            cmd.Parameters.Add("@BillPercent", SqlDbType.Int, 4).Direction = ParameterDirection.Input
            cmd.Parameters.Add("@NotingID", SqlDbType.BigInt, 8)
            cmd.Parameters("@NotingID").Direction = ParameterDirection.Output
            Try
                cmd.Parameters("@NSIDNno").Value = intNSIDNno
                cmd.Parameters("@Subject").Value = sSubject
                cmd.Parameters("@Reference").Value = sReference
                cmd.Parameters("@Para1").Value = sPara1
                cmd.Parameters("@Para2").Value = sPara2
                cmd.Parameters("@Para3").Value = sPara3
                cmd.Parameters("@Para4").Value = sPara4
                cmd.Parameters("@DateOfSaving").Value = Now.Date
                cmd.Parameters("@BillPercent").Value = intBillPercent
                cmd.Parameters("@NotingID").Value = lNotingID
                blnDone = True
            Catch exp As Exception
                blnDone = False
            End Try
            If blnDone = True Then
                blnDone = False
            Else
                cmd.Dispose()
                Throw New Exception("Value assingement error !")
                Exit Function
            End If
            Try
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                'cmd.CommandText = " select @YWid = YWid from mm_YardWheelAccount where AreaNo = @AreaNo and WheelCategory = @WheelCategory and  LineNumber = @LineNumber and  WheelStatus  = @WheelStatus "
                If lNotingID > 0 Then
                    cmd.Parameters("@NotingID").Direction = ParameterDirection.Input
                    If UndoDelete = False Then
                        If Delete = False Then
                            BillsNotingEdit(cmd)
                        Else
                            BillsNotingDelete(cmd)
                        End If
                    Else
                        'BillsNotingUndoDelete(cmd)
                    End If
                Else
                    If Delete = False Then BillsNotingAdd(cmd)
                End If
                blnDone = True
            Catch exp As Exception
                sMessage = exp.Message
                Throw New Exception(exp.Message)
            Finally
                If blnDone = True Then
                    cmd.Transaction.Commit()
                Else
                    cmd.Transaction.Rollback()
                End If
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
            End Try
            Return blnDone
        End Function
        Private Sub BillsNotingAdd(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " insert into ms_sparecell_BillsNoting  " & _
                        " ( Subject , Reference , Para1 , Para2 , Para3 , Para4 , NSIDNno , SavedDate , BillPercent ) " & _
                        " values  ( @Subject , @Reference , @Para1 , @Para2 , @Para3 , @Para4 , @NSIDNno , @DateOfSaving , @BillPercent )"
            Try
                If CMD.ExecuteNonQuery = 0 Then
                    Throw New Exception(" Bills Pending List error")
                Else
                    CMD.CommandText = " select @NotingID = NotingID from ms_sparecell_BillsNoting where Subject = @Subject and Reference = @Reference and  " & _
                        " Para1 = @Para1 and Para2 = @Para2 and Para3 = @Para3 and Para4 = @Para4 and NSIDNno = @NSIDNno and BillPercent = @BillPercent "
                    CMD.ExecuteScalar()
                    lNotingID = IIf(IsDBNull(CMD.Parameters("@NotingID").Value), 0, CMD.Parameters("@NotingID").Value)
                    If lNotingID = 0 Then
                        Throw New Exception(" Selection of Noting no error ")
                    End If
                End If
            Catch exp As Exception
                Throw New Exception(" Insert into ms_sparecell_BillsNoting error " & exp.Message)
            End Try
        End Sub
        Private Sub BillsNotingEdit(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " update ms_sparecell_BillsNoting set Subject = @Subject , Reference = @Reference ,  " & _
                        " Para1 = @Para1 , Para2 = @Para2 , Para3 = @Para3 , Para4 = @Para4  " & _
                        " where NotingID = @NotingID and NSIDNno = @NSIDNno"
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to update Bills Noting  details ")
            Catch exp As Exception
                Throw New Exception(" update of ms_sparecell_BillsNoting error :  " & exp.Message)
            End Try
        End Sub
        Private Sub BillsNotingDelete(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " delete  ms_sparecell_BillsNoting  where NotingID = @NotingID"
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to delete Bills Noting  details ")
            Catch exp As Exception
                Throw New Exception(" delete of ms_sparecell_BillsNoting error :  " & exp.Message)
            End Try
        End Sub
        Public Function SaveBillsCheckList(Optional ByVal CheckListID As Long = 0, Optional ByVal Delete As Boolean = False) As Boolean
            Dim blnDone As Boolean
            Dim CMD As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            CMD.Parameters.Add("@PONumber", SqlDbType.VarChar, 9)
            CMD.Parameters("@PONumber").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@TotalValue", SqlDbType.Float, 8)
            CMD.Parameters("@TotalValue").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@DueDate", SqlDbType.SmallDateTime, 4)
            CMD.Parameters("@DueDate").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@Delivery", SqlDbType.VarChar, 200)
            CMD.Parameters("@Delivery").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@Quantity", SqlDbType.VarChar, 200)
            CMD.Parameters("@Quantity").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@Others", SqlDbType.VarChar, 200)
            CMD.Parameters("@Others").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@OtherPayment", SqlDbType.VarChar, 200)
            CMD.Parameters("@OtherPayment").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@SpecialConditions", SqlDbType.VarChar, 200)
            CMD.Parameters("@SpecialConditions").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@Erection", SqlDbType.VarChar, 200)
            CMD.Parameters("@Erection").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@DateOfReceipt", SqlDbType.SmallDateTime, 4)
            CMD.Parameters("@DateOfReceipt").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@DateOfSending", SqlDbType.SmallDateTime, 4)
            CMD.Parameters("@DateOfSending").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@AnyOtherEnclosures", SqlDbType.VarChar, 500)
            CMD.Parameters("@AnyOtherEnclosures").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@DateOfSaving", SqlDbType.SmallDateTime, 4)
            CMD.Parameters("@DateOfSaving").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@CheckListID", SqlDbType.BigInt, 8)
            CMD.Parameters("@CheckListID").Direction = ParameterDirection.Output
            Try
                ' Assingned unreleated text items to objects property just to test !
                CMD.Parameters("@PONumber").Value = objItemsList.PO
                CMD.Parameters("@TotalValue").Value = objItemsList.BOMQty
                CMD.Parameters("@DueDate").Value = objItemsList.LastIssueDate
                CMD.Parameters("@Delivery").Value = objItemsList.BOMSource
                CMD.Parameters("@Quantity").Value = objItemsList.BOMType
                CMD.Parameters("@Others").Value = objItemsList.ContactPerson
                CMD.Parameters("@OtherPayment").Value = objItemsList.EARES
                CMD.Parameters("@SpecialConditions").Value = ItemsList.Equip
                CMD.Parameters("@Erection").Value = ItemsList.PhoneNumber
                CMD.Parameters("@DateOfReceipt").Value = ItemsList.PODt
                CMD.Parameters("@DateOfSending").Value = ItemsList.StatusDate
                CMD.Parameters("@AnyOtherEnclosures").Value = ItemsList.Remarks
                CMD.Parameters("@DateOfSaving").Value = Now.Date
                CMD.Parameters("@CheckListID").Value = lCheckListID
                blnDone = True
            Catch exp As Exception
                blnDone = False
            End Try
            If blnDone = True Then
                blnDone = False
            Else
                CMD.Dispose()
                Throw New Exception("Value assingement error !")
                Exit Function
            End If

            Try
                If CMD.Connection.State = ConnectionState.Closed Then CMD.Connection.Open()
                CMD.Transaction = CMD.Connection.BeginTransaction
                'CMD.CommandText = " select @ReplyID = ReplyID from mm_YardWheelAccount where AreaNo = @AreaNo and WheelCategory = @WheelCategory and  LineNumber = @LineNumber and  WheelStatus  = @WheelStatus "
                If CheckListID > 0 Then
                    lCheckListID = CheckListID
                    CMD.Parameters("@CheckListID").Value = CheckListID
                    CMD.Parameters("@CheckListID").Direction = ParameterDirection.Input
                    If Delete = False Then
                        BillsCheckListEdit(CMD, CheckListID)
                        blnDone = True
                    Else
                        BillsCheckListDelete(CMD)
                        blnDone = True
                    End If
                Else
                    If Delete = False Then BillsCheckListAdd(CMD)
                    blnDone = True
                End If
            Catch exp As Exception
                Throw New Exception("Bills CheckList saving to ms_sparecell_BillsCheckList Tables error : " & exp.Message)
            Finally
                If blnDone = True Then
                    CMD.Transaction.Commit()
                Else
                    CMD.Transaction.Rollback()
                End If
                If CMD.Connection.State = ConnectionState.Open Then CMD.Connection.Close()
                CMD.Dispose()
            End Try
            If blnDone Then
                dtSavedCheckListItems = GetSavedData()
            End If
            Return blnDone
        End Function
        Private Sub BillsCheckListAdd(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " insert into ms_sparecell_BillsCheckList ( PONumber , TotalValue , DueDate , Delivery , Quantity , Others , OtherPayment , " & _
                        " SpecialConditions , Erection  , DateOfReceipt , DateOfSending , AnyOtherEnclosures , Saveddate ) " & _
                        " values ( @PONumber , @TotalValue , @DueDate , @Delivery , @Quantity , @Others , @OtherPayment , " & _
                        " @SpecialConditions , @Erection , @DateOfReceipt , @DateOfSending , @AnyOtherEnclosures , @DateOfSaving ) "

            Try
                If CMD.ExecuteNonQuery = 0 Then
                    Throw New Exception(" CheckList Saving error")
                Else
                    CMD.CommandText = " select @CheckListID = CheckListID from ms_sparecell_BillsCheckList where " & _
                                " PONumber = @PONumber and  TotalValue = @TotalValue and  DueDate = @DueDate and  Delivery =@Delivery and " & _
                                " Quantity = @Quantity and  Others = @Others and  OtherPayment = @OtherPayment and " & _
                                " SpecialConditions = @SpecialConditions and  Erection = @Erection and DateOfReceipt = @DateOfReceipt and " & _
                                " DateOfSending = @DateOfSending and  AnyOtherEnclosures = @AnyOtherEnclosures  "
                    CMD.ExecuteScalar()
                    lCheckListID = IIf(IsDBNull(CMD.Parameters("@CheckListID").Value), 0, CMD.Parameters("@CheckListID").Value)
                    If IsNothing(dtCheckListItems) = False Then
                        If dtCheckListItems.Rows.Count > 0 Then
                            If SaveCheckListItemsAdd(CMD, lCheckListID, dtCheckListItems) = False Then Throw New Exception(" CheckList Items Saving error")
                        End If
                    End If
                End If
            Catch exp As Exception
                Throw New Exception(" Insert into ms_sparecell_BillsCheckList error " & exp.Message)
            End Try
        End Sub
        Private Sub BillsCheckListEdit(ByRef CMD As SqlClient.SqlCommand, ByVal CheckListID As Long)
            CMD.CommandText = " update ms_sparecell_BillsCheckList set TotalValue = @TotalValue ,  DueDate = @DueDate ,  Delivery = @Delivery ," & _
                    " Quantity = @Quantity ,  Others = @Others ,  OtherPayment = @OtherPayment , " & _
                    " SpecialConditions = @SpecialConditions ,  Erection = @Erection , DateOfReceipt = @DateOfReceipt ," & _
                    " DateOfSending = @DateOfSending ,  AnyOtherEnclosures = @AnyOtherEnclosures " & _
                    " where CheckListID = @CheckListID and PONumber = @PONumber "
            Try
                If CMD.ExecuteNonQuery = 0 Then
                    Throw New Exception(" Unable to update CheckList details ")
                Else
                    If IsNothing(dtCheckListItems) = False Then
                        If dtCheckListItems.Rows.Count > 0 Then
                            If SaveCheckListItemsEdit(CMD, CheckListID, dtCheckListItems) = False Then Throw New Exception(" Check List Saving error")
                        End If
                    End If
                End If
            Catch exp As Exception
                Throw New Exception(" update of ms_sparecell_BillsCheckList error :  " & exp.Message)
            End Try
        End Sub
        Private Sub BillsCheckListDelete(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " delete ms_sparecell_BillsCheckListItems where CheckListID = @CheckListID "
            Try
                If CMD.ExecuteNonQuery = 0 Then
                    Throw New Exception(" Unable to delete CheckListItems details ")
                Else
                    CMD.CommandText = " delete ms_sparecell_BillsCheckList where CheckListID = @CheckListID "
                    If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to delete CheckList details ")
                End If
            Catch exp As Exception
                Throw New Exception(" delete of ms_sparecell_BillsCheckList error :  " & exp.Message)
            End Try
        End Sub
        Public Function SaveCheckListItemsAdd(ByRef CMD As SqlClient.SqlCommand, ByVal lReplyID As Long, ByVal dtCheckListItems As DataTable) As Boolean
            Dim blnDone As Boolean
            Dim cnt As Int16
            CMD.Parameters("@CheckListID").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@PLNumber", SqlDbType.VarChar, 8)
            CMD.Parameters("@PLNumber").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@ActualQty", SqlDbType.VarChar, 200)
            CMD.Parameters("@ActualQty").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@Dt", SqlDbType.VarChar, 200)
            CMD.Parameters("@Dt").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@NSIDNId", SqlDbType.BigInt, 8)
            CMD.Parameters("@NSIDNId").Direction = ParameterDirection.Input
            Try
                If dtCheckListItems.Rows.Count > 0 Then
                    For cnt = 0 To dtCheckListItems.Rows.Count - 1
                        CMD.Parameters("@CheckListID").Value = lCheckListID
                        CMD.Parameters("@PLNumber").Value = dtCheckListItems.Rows(cnt)(0)
                        CMD.Parameters("@ActualQty").Value = dtCheckListItems.Rows(cnt)(5)
                        CMD.Parameters("@Dt").Value = dtCheckListItems.Rows(cnt)(6)
                        CMD.Parameters("@NSIDNId").Value = dtCheckListItems.Rows(cnt)(3)
                        CMD.CommandText = "insert into ms_sparecell_BillsCheckListItems ( CheckListID , PLNumber , ActualQty , Dt , NSIDNId ) values ( @CheckListID , @PLNumber , @ActualQty , @Dt , @NSIDNId )"
                        If CMD.ExecuteNonQuery() > 0 Then
                            blnDone = True
                        Else
                            Exit For
                        End If
                    Next
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
                blnDone = False
            End Try
            Return blnDone
        End Function
        Public Function GetSavedData() As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select pl_number , pl_desc , QtyAsPerPO , Rate NSIDNId , UnitName , ActualQty ,  DeliveryDate , CheckListID " & _
                            " from ms_vw_sparecell_BillsCheckListItems where CheckListID = " & lCheckListID & " "
            Try
                da.Fill(ds, "BillsPendingPOs")
                GetSavedData = ds.Tables("BillsPendingPOs")
            Catch exp As Exception
                GetSavedData = Nothing
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Function SaveCheckListItemsEdit(ByRef CMD As SqlClient.SqlCommand, ByVal lCheckListID As Long, ByVal dtCheckListItems As DataTable) As Boolean
            Dim blnDone As Boolean
            Dim cnt, replyCnt As Int16
            CMD.Parameters("@CheckListID").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@PLNumber", SqlDbType.VarChar, 8)
            CMD.Parameters("@PLNumber").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@ActualQty", SqlDbType.VarChar, 200)
            CMD.Parameters("@ActualQty").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@Dt", SqlDbType.VarChar, 200)
            CMD.Parameters("@Dt").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@CheckListItemsID", SqlDbType.BigInt, 8)
            CMD.Parameters("@CheckListItemsID").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@NSIDNId", SqlDbType.BigInt, 8)
            CMD.Parameters("@NSIDNId").Direction = ParameterDirection.Input
            Try
                If dtCheckListItems.Rows.Count > 0 Then
                    For cnt = 0 To dtCheckListItems.Rows.Count - 1
                        CMD.Parameters("@CheckListID").Value = lCheckListID
                        CMD.Parameters("@PLNumber").Value = dtCheckListItems.Rows(cnt)(0)
                        CMD.Parameters("@ActualQty").Value = dtCheckListItems.Rows(cnt)(5)
                        CMD.Parameters("@Dt").Value = dtCheckListItems.Rows(cnt)(6)
                        CMD.Parameters("@CheckListItemsID").Value = dtCheckListItems.Rows(cnt)(7)
                        CMD.Parameters("@NSIDNId").Value = dtCheckListItems.Rows(cnt)(3)
                        CMD.CommandText = "update ms_sparecell_BillsCheckListItems set  ActualQty = @ActualQty , Dt = @Dt  where CheckListID  = @CheckListID and PLNumber = @PLNumber and CheckListItemsID = @CheckListItemsID and NSIDNId = @NSIDNId "
                        Try
                            If CMD.ExecuteNonQuery() > 0 Then
                                blnDone = True
                            End If
                        Catch exp As Exception
                            Throw New Exception(exp.Message)
                        End Try
                    Next
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
                blnDone = False
            End Try
            Return blnDone
        End Function
        Public Function SaveBillsDocument(Optional ByVal DocumentID As Long = 0, Optional ByVal Delete As Boolean = False) As Boolean
            Dim blnDone As Boolean
            Dim CMD As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            CMD.Parameters.Add("@DocumentID", SqlDbType.BigInt, 8)
            CMD.Parameters("@DocumentID").Direction = ParameterDirection.Output
            Try
                CMD.Parameters.Add("@PONumber", SqlDbType.VarChar, 9).Value = sPONumber
                CMD.Parameters.Add("@Subject", SqlDbType.VarChar, 100).Value = sSubject
                CMD.Parameters.Add("@Reference", SqlDbType.VarChar, 200).Value = sReference
                CMD.Parameters.Add("@Para1", SqlDbType.VarChar, 2000).Value = sPara1
                CMD.Parameters.Add("@DocumnetType", SqlDbType.Int, 4).Value = intDocumnetType
                CMD.Parameters.Add("@Para2", SqlDbType.VarChar, 2000).Value = IIf(IsNothing(sPara2), "", sPara2)
                CMD.Parameters.Add("@SavedDate", SqlDbType.SmallDateTime, 4).Value = IIf(IsNothing(dateDateSaved), CDate("1900-01-01"), dateDateSaved)
                CMD.Parameters("@DocumentID").Value = lDocumentID
                blnDone = True
            Catch exp As Exception
                blnDone = False
            End Try
            If blnDone = True Then
                blnDone = False
            Else
                CMD.Dispose()
                Throw New Exception("Value assingement error !")
                Exit Function
            End If

            Try
                If CMD.Connection.State = ConnectionState.Closed Then CMD.Connection.Open()
                CMD.Transaction = CMD.Connection.BeginTransaction
                'CMD.CommandText = " select @ReplyID = ReplyID from mm_YardWheelAccount where AreaNo = @AreaNo and WheelCategory = @WheelCategory and  LineNumber = @LineNumber and  WheelStatus  = @WheelStatus "
                If DocumentID > 0 Then
                    lDocumentID = DocumentID
                    CMD.Parameters("@DocumentID").Value = DocumentID
                    CMD.Parameters("@DocumentID").Direction = ParameterDirection.Input
                    If Delete = False Then
                        BillsDocumentEdit(CMD, DocumentID)
                        blnDone = True
                    Else
                        BillsDocumentDelete(CMD)
                        blnDone = True
                    End If
                Else
                    If Delete = False Then BillsDocumentAdd(CMD)
                    blnDone = True
                End If
            Catch exp As Exception
                Throw New Exception("Bill Documents saving to ms_sparecell_BillsDocument Tables error : " & exp.Message)
            Finally
                If blnDone = True Then
                    CMD.Transaction.Commit()
                Else
                    CMD.Transaction.Rollback()
                End If
                If CMD.Connection.State = ConnectionState.Open Then CMD.Connection.Close()
                CMD.Dispose()
            End Try
            Return blnDone
        End Function
        Private Sub BillsDocumentAdd(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " insert into ms_sparecell_BillsDocument ( PONumber , Subject , Reference , Para1 , DocumnetType , Para2 , SavedDate ) " & _
                        " values ( @PONumber , @Subject , @Reference , @Para1 , @DocumnetType , @Para2 , @SavedDate ) "
            Try
                If CMD.ExecuteNonQuery = 0 Then
                    Throw New Exception(" Documents Saving error")
                Else
                    CMD.CommandText = " select @DocumentID = DocumentID from ms_sparecell_BillsDocument where " & _
                                " PONumber = @PONumber and  Subject = @Subject and  Reference = @Reference and  Para1 = @Para1 and DocumnetType = @DocumnetType and Para2 = @Para2 and SavedDate = @SavedDate "
                    CMD.ExecuteScalar()
                    lDocumentID = IIf(IsDBNull(CMD.Parameters("@DocumentID").Value), 0, CMD.Parameters("@DocumentID").Value)
                    If IsNothing(dtDocumentItems) = False Then
                        If dtDocumentItems.Rows.Count > 0 Then
                            If SaveDocumentItemsAdd(CMD, lDocumentID, dtDocumentItems, intDocumnetType) = False Then Throw New Exception(" Document Items Saving error")
                        End If
                    End If
                End If
            Catch exp As Exception
                Throw New Exception(" Insert into ms_sparecell_BillsDocument error " & exp.Message)
            End Try
        End Sub
        Private Sub BillsDocumentEdit(ByRef CMD As SqlClient.SqlCommand, ByVal DocumentID As Long)
            CMD.CommandText = " update ms_sparecell_BillsDocument set Subject = @Subject ,  Reference = @Reference ,  Para1 = @Para1 , Para2 = @Para2 , SavedDate = @SavedDate " & _
                    " where DocumentID = @DocumentID and PONumber = @PONumber and DocumnetType = @DocumnetType"
            Try
                If CMD.ExecuteNonQuery = 0 Then
                    Throw New Exception(" Unable to update Document details ")
                Else
                    If IsNothing(dtDocumentItems) = False Then
                        If dtDocumentItems.Rows.Count > 0 Then
                            If SaveDocumentItemsEdit(CMD, DocumentID, dtDocumentItems, intDocumnetType) = False Then Throw New Exception(" Document List Saving error")
                        End If
                    End If
                End If
            Catch exp As Exception
                Throw New Exception(" update of ms_sparecell_BillsDocumentItems error :  " & exp.Message)
            End Try
        End Sub
        Private Sub BillsDocumentDelete(ByRef CMD As SqlClient.SqlCommand)
            CMD.CommandText = " delete ms_sparecell_BillsDocument where DocumentID = @DocumentID "
            Try
                If CMD.ExecuteNonQuery = 0 Then Throw New Exception(" Unable to delete Document details ")
            Catch exp As Exception
                Throw New Exception(" delete of ms_sparecell_BillsDocument error :  " & exp.Message)
            End Try
        End Sub
        Public Function SaveDocumentItemsAdd(ByRef CMD As SqlClient.SqlCommand, ByVal lDocumentID As Long, ByVal dtDocumentItems As DataTable, ByVal Type As Integer) As Boolean
            Dim blnDone As Boolean
            Dim cnt As Int16
            CMD.Parameters("@DocumentID").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@PLNumber", SqlDbType.VarChar, 8)
            CMD.Parameters("@PLNumber").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@Qty", SqlDbType.VarChar, 200)
            CMD.Parameters("@Qty").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@DueDate", SqlDbType.VarChar, 11)
            CMD.Parameters("@DueDate").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@NsIDnId", SqlDbType.BigInt, 8)
            CMD.Parameters("@NsIDnId").Direction = ParameterDirection.Input
            Try
                If dtDocumentItems.Rows.Count > 0 Then
                    If intDocumnetType = 4 Or intDocumnetType = 6 Then
                        For cnt = 0 To dtDocumentItems.Rows.Count - 1
                            CMD.Parameters("@DocumentID").Value = lDocumentID
                            CMD.Parameters("@NsIDnId").Value = dtDocumentItems.Rows(cnt)(0)
                            CMD.Parameters("@PLNumber").Value = dtDocumentItems.Rows(cnt)(1)
                            CMD.Parameters("@Qty").Value = dtDocumentItems.Rows(cnt)(4)
                            CMD.Parameters("@DueDate").Value = "1900-01-01"
                            CMD.CommandText = "insert into ms_sparecell_BillsDocumentItems ( DocumentID , PLNumber , Qty , DueDate	, NsIDnId  ) values ( @DocumentID , @PLNumber , @Qty , @DueDate , @NsIDnId )"
                            If CMD.ExecuteNonQuery() > 0 Then
                                blnDone = True
                            Else
                                Exit For
                            End If
                        Next
                    ElseIf intDocumnetType = 7 Then
                        For cnt = 0 To dtDocumentItems.Rows.Count - 1
                            CMD.Parameters("@DocumentID").Value = lDocumentID
                            CMD.Parameters("@NsIDnId").Value = dtDocumentItems.Rows(cnt)(1)
                            CMD.Parameters("@PLNumber").Value = dtDocumentItems.Rows(cnt)(0)
                            CMD.Parameters("@Qty").Value = dtDocumentItems.Rows(cnt)(3)
                            CMD.Parameters("@DueDate").Value = dtDocumentItems.Rows(cnt)(2)
                            CMD.CommandText = "insert into ms_sparecell_BillsDocumentItems ( DocumentID , PLNumber , Qty , DueDate	, NsIDnId  ) values ( @DocumentID , @PLNumber , @Qty , @DueDate , @NsIDnId )"
                            If CMD.ExecuteNonQuery() > 0 Then
                                blnDone = True
                            Else
                                Exit For
                            End If
                        Next
                    Else
                        For cnt = 0 To dtDocumentItems.Rows.Count - 1
                            CMD.Parameters("@DocumentID").Value = lDocumentID
                            CMD.Parameters("@NsIDnId").Value = "0"
                            CMD.Parameters("@PLNumber").Value = dtDocumentItems.Rows(cnt)(0)
                            CMD.Parameters("@Qty").Value = dtDocumentItems.Rows(cnt)(2)
                            CMD.Parameters("@DueDate").Value = dtDocumentItems.Rows(cnt)(4)
                            CMD.CommandText = "insert into ms_sparecell_BillsDocumentItems ( DocumentID , PLNumber , Qty , DueDate	 ) values ( @DocumentID , @PLNumber , @Qty , @DueDate )"
                            If CMD.ExecuteNonQuery() > 0 Then
                                blnDone = True
                            Else
                                Exit For
                            End If
                        Next
                    End If
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
                blnDone = False
            End Try
            Return blnDone
        End Function
        Public Function SaveDocumentItemsEdit(ByRef CMD As SqlClient.SqlCommand, ByVal lDocumentID As Long, ByVal dtDocumentItems As DataTable, ByVal Type As Integer) As Boolean
            Dim blnDone As Boolean
            Dim cnt, replyCnt As Int16
            CMD.Parameters("@DocumentID").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@PLNumber", SqlDbType.VarChar, 8)
            CMD.Parameters("@PLNumber").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@Qty", SqlDbType.VarChar, 200)
            CMD.Parameters("@Qty").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@DueDate", SqlDbType.VarChar, 200)
            CMD.Parameters("@DueDate").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@DocumentItemsID", SqlDbType.BigInt, 8)
            CMD.Parameters("@DocumentItemsID").Direction = ParameterDirection.Input
            CMD.Parameters.Add("@NsIDnId", SqlDbType.BigInt, 8)
            CMD.Parameters("@NsIDnId").Direction = ParameterDirection.Input
            Try
                If dtDocumentItems.Rows.Count > 0 Then
                    If intDocumnetType = 4 Then
                        For cnt = 0 To dtDocumentItems.Rows.Count - 1
                            CMD.Parameters("@DocumentID").Value = lDocumentID
                            CMD.Parameters("@NsIDnId").Value = dtDocumentItems.Rows(cnt)(0)
                            CMD.Parameters("@PLNumber").Value = dtDocumentItems.Rows(cnt)(1)
                            CMD.Parameters("@Qty").Value = dtDocumentItems.Rows(cnt)(4)
                            CMD.Parameters("@DueDate").Value = "1900-01-01"
                            CMD.Parameters("@DocumentItemsID").Value = dtDocumentItems.Rows(cnt)(7)
                            CMD.CommandText = "update ms_sparecell_BillsDocumentItems set  Qty = @Qty , DueDate = @DueDate  where NsIDnId = @NsIDnId and DocumentID  = @DocumentID and PLNumber = @PLNumber and DocumentItemsID = @DocumentItemsID"
                            Try
                                If CMD.ExecuteNonQuery() > 0 Then blnDone = True
                            Catch exp As Exception
                                Throw New Exception(exp.Message)
                            End Try
                        Next
                    Else
                        For cnt = 0 To dtDocumentItems.Rows.Count - 1
                            CMD.Parameters("@DocumentID").Value = lDocumentID
                            CMD.Parameters("@NsIDnId").Value = "0"
                            CMD.Parameters("@PLNumber").Value = dtDocumentItems.Rows(cnt)(0)
                            CMD.Parameters("@Qty").Value = dtDocumentItems.Rows(cnt)(2)
                            CMD.Parameters("@DueDate").Value = dtDocumentItems.Rows(cnt)(4)
                            CMD.Parameters("@DocumentItemsID").Value = dtDocumentItems.Rows(cnt)(5)
                            CMD.CommandText = "update ms_sparecell_BillsDocumentItems set  Qty = @Qty , DueDate = @DueDate  where DocumentID  = @DocumentID and PLNumber = @PLNumber and DocumentItemsID = @DocumentItemsID"
                            Try
                                If CMD.ExecuteNonQuery() > 0 Then blnDone = True
                            Catch exp As Exception
                                Throw New Exception(exp.Message)
                            End Try
                        Next
                    End If

                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
                blnDone = False
            End Try
            Return blnDone
        End Function
#End Region
    End Class
End Namespace

