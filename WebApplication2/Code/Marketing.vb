Public Class Marketing
    Public Shared Function DespatchAdviceNumberDetails(ByVal DespatchAdviceNumber As String) As DataSet
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        Try
            da.SelectCommand.Parameters.Add("@DespatchAdviceNumber", SqlDbType.VarChar, 50).Value = DespatchAdviceNumber
            da.SelectCommand.CommandText = "select top 1 convert(varchar(10),despatchAdviceDate,103) DespAdviceDt , Consignee , ConsigneeAddress " & _
                "  , po_wta_number  from pm_vw_DespatchAdviceDetails " & _
                " where despatchAdviceNumber = @DespatchAdviceNumber ;" & _
                " select TruckNumber , quantity Qty , product_code Product , description ProductType , sale_price SalePrice" & _
                " from pm_vw_DespatchAdviceDetails" & _
                " where despatchAdviceNumber = @DespatchAdviceNumber ;" & _
                " select invoice_serial_number InvoiceNo , " & _
                " convert(varchar(10),invoice_date,103) InvoiceDt , " & _
                " wagon_lorry_number WagonLryNo , wagon_lorry_quantity Qty , sale_transfer_price SalePrice" & _
                " from dm_fg_excisable_goods_form a inner join pm_SaleInvoiceLink b" & _
                " on InvoiceNo = invoice_serial_number " & _
                " where GroupCode = 'mrkting' and despatch_advice_number = @DespatchAdviceNumber order by invoice_serial_number desc"
            'despatch_advice_number DespatchAdviceNo , convert(varchar(10),despatch_advice_date,103) DespatchADDt , consignee , address ,
            da.Fill(ds)
            DespatchAdviceNumberDetails = ds.Copy
        Catch exp As Exception
            DespatchAdviceNumberDetails = Nothing
            Throw New Exception(exp.Message)
        Finally
            ds.Dispose()
            da.Dispose()
            da = Nothing
            ds = Nothing
        End Try
    End Function
    Public Shared Function SavedInvoicedetails(ByVal GroupCode As String, ByVal FrDt As Date, ByVal ToDt As Date) As DataTable
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        da.SelectCommand.Parameters.Add("@GroupCode", SqlDbType.VarChar, 50).Value = GroupCode
        da.SelectCommand.Parameters.Add("@FrDt", SqlDbType.SmallDateTime, 4).Value = FrDt
        da.SelectCommand.Parameters.Add("@ToDt", SqlDbType.SmallDateTime, 4).Value = ToDt
        da.SelectCommand.CommandText = "select * from pm_vw_SaleInvoiceDetails " & _
        " where GroupCode = @GroupCode and InvoiceDate between  @FrDt and @ToDt order by InvoiceNo "
        Try
            da.Fill(ds)
            SavedInvoicedetails = ds.Tables(0)
        Catch exp As Exception
            SavedInvoicedetails = Nothing
            Throw New Exception(exp.Message)
        Finally
            ds.Dispose()
            da.Dispose()
            da = Nothing
            ds = Nothing
        End Try
    End Function
    Public Shared Function CheckInvoiceNo(ByVal InvoiceNo As String) As DataTable
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        Try
            da.SelectCommand.Parameters.Add("@InvoiceNo", SqlDbType.VarChar, 50).Value = InvoiceNo
            da.SelectCommand.CommandText = "select convert(varchar(10),invoice_date,103) InvoiceDate , " & _
                " wagon_lorry_quantity , wagon_lorry_number " & _
                " from dm_fg_excisable_goods_form  where invoice_serial_number = @InvoiceNo "
            da.Fill(ds)
            CheckInvoiceNo = ds.Tables(0)
        Catch exp As Exception
            CheckInvoiceNo = Nothing
            Throw New Exception(exp.Message)
        Finally
            ds.Dispose()
            da.Dispose()
            da = Nothing
            ds = Nothing
        End Try
    End Function
    Public Shared Function CheckDCNo(ByVal GroupCode As String, ByVal GroupReference As String, ByVal InvoiceNo As String) As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            cmd.Connection.Open()
            cmd.Parameters.Add("@GroupCode", SqlDbType.VarChar, 50).Value = GroupCode
            cmd.Parameters.Add("@GroupReference", SqlDbType.VarChar, 50).Value = GroupReference
            cmd.Parameters.Add("@InvoiceNo", SqlDbType.VarChar, 50).Value = InvoiceNo
            cmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            cmd.CommandText = "select @cnt = count(*)   " & _
                    " from dm_vw_fg_excisable_goods_form " & _
                    " where despatch_advice_number = @GroupReference and invoice_serial_number = @InvoiceNo "
            cmd.ExecuteScalar()
            Return IIf(IsDBNull(cmd.Parameters("@cnt").Value), 0, cmd.Parameters("@cnt").Value)
        Catch exp As Exception
            Return False
            Throw New Exception(exp.Message)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
        End Try
    End Function
    Public Shared Function GetMarketingRefDetails(ByVal RefID As Integer) As DataTable
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        Try
            da.SelectCommand.Parameters.Add("@RefID", SqlDbType.Int, 4).Value = RefID
            da.SelectCommand.CommandText = "select Subject , PIorSANo ,  " & _
                " PIorSADate , Qty , Rate , Packing , ItemDescription " & _
                " from pm_vw_marketing_referance where RefID = @RefID "
            da.Fill(ds)
            GetMarketingRefDetails = ds.Tables(0)
        Catch exp As Exception
            GetMarketingRefDetails = Nothing
            Throw New Exception(exp.Message)
        Finally
            ds.Dispose()
            da.Dispose()
            da = Nothing
            ds = Nothing
        End Try
    End Function
    Public Shared Function GetMarketingRef() As DataTable
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        Try
            da.SelectCommand.CommandText = "select  distinct top 10 RefID , ReferenceNo " & _
                " from pm_vw_marketing_referance order by RefID desc "
            da.Fill(ds)
            GetMarketingRef = ds.Tables(0)
        Catch exp As Exception
            GetMarketingRef = Nothing
            Throw New Exception(exp.Message)
        Finally
            ds.Dispose()
            da.Dispose()
            da = Nothing
            ds = Nothing
        End Try
    End Function
    Public Shared Function SavedGroupReferences(ByVal GroupCode As String, ByVal GroupReference As String) As DataTable
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        da.SelectCommand.Parameters.Add("@GroupCode", SqlDbType.VarChar, 50).Value = GroupCode
        da.SelectCommand.Parameters.Add("@GroupReference", SqlDbType.VarChar, 50).Value = GroupReference
        If GroupCode = "PCOPCO" OrElse GroupCode = "C&F" Then
            da.SelectCommand.CommandText = "select distinct InvoiceNo " & _
            " from pm_SaleInvoiceDetails " & _
            " where GroupCode = @GroupCode and GroupReference = @GroupReference"
        Else
            da.SelectCommand.CommandText = "select InvoiceNo " & _
                       " from pm_SaleInvoiceLink where SaleOrderNo = @despatch_advice_number " & _
                       " order by InvoiceNo desc "
        End If
        Try
            da.Fill(ds)
            SavedGroupReferences = ds.Tables(0)
        Catch exp As Exception
            SavedGroupReferences = Nothing
            Throw New Exception(exp.Message)
        Finally
            ds.Dispose()
            da.Dispose()
            da = Nothing
            ds = Nothing
        End Try
    End Function
    Public Shared Function SaleInvoiceDetails(ByVal GroupCode As String, ByVal GroupReference As String, ByVal InvoiceNo As String) As DataTable
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        da.SelectCommand.Parameters.Add("@GroupCode", SqlDbType.VarChar, 50).Value = GroupCode
        da.SelectCommand.Parameters.Add("@GroupReference", SqlDbType.VarChar, 50).Value = GroupReference
        da.SelectCommand.Parameters.Add("@InvoiceNo", SqlDbType.VarChar, 50).Value = InvoiceNo
        da.SelectCommand.CommandText = "select GroupCode , GroupReference , InvoiceNo , " & _
            " convert(varchar(10),InvoiceDate,103) InvoiceDate , TotalValue , TaxableValue , GoodsHSN , GoodsDescription , " & _
            " UnitCode , Quantity , Rate , ITC , IGSTRate , IGSTChargedAmt , CGSTRate , " & _
            " CGSTChargedAmt , SGSTRate , SGSTChargedAmt , CessRate , CessChargedAmt , " & _
            " GoodsName , PlaceOfSupply, RecepientGSTIN, ReverseTax, TDS , UGSTRate , UGSTChargedAmt " & _
            " from pm_SaleInvoiceDetails " & _
            " where GroupCode = @GroupCode and GroupReference = @GroupReference and InvoiceNo = @InvoiceNo "
        Try
            da.Fill(ds)
            SaleInvoiceDetails = ds.Tables(0)
        Catch exp As Exception
            SaleInvoiceDetails = Nothing
            Throw New Exception(exp.Message)
        Finally
            ds.Dispose()
            da.Dispose()
            da = Nothing
            ds = Nothing
        End Try
    End Function
    Public Shared Function SavedSaleInvoices(ByVal GroupCode As String, ByVal SaleOrderNo As String) As DataTable
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        da.SelectCommand.Parameters.Add("@GroupCode", SqlDbType.VarChar, 50).Value = GroupCode
        da.SelectCommand.Parameters.Add("@SaleOrderNo", SqlDbType.VarChar, 50).Value = SaleOrderNo
        da.SelectCommand.CommandText = "select InvoiceNo " & _
            " from pm_SaleInvoiceLink where GroupCode = @GroupCode and SaleOrderNo = @SaleOrderNo " & _
            " order by InvoiceNo desc "
        Try
            da.Fill(ds)
            SavedSaleInvoices = ds.Tables(0)
        Catch exp As Exception
            SavedSaleInvoices = Nothing
            Throw New Exception(exp.Message)
        Finally
            ds.Dispose()
            da.Dispose()
            da = Nothing
            ds = Nothing
        End Try
    End Function
    Public Shared Function SavedSaleOrders(ByVal GroupCode As String) As DataTable
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        da.SelectCommand.Parameters.Add("@GroupCode", SqlDbType.VarChar, 50).Value = GroupCode
        da.SelectCommand.CommandText = "select distinct SaleOrderNo " & _
            " from pm_SaleInvoiceLink where GroupCode = @GroupCode order by SaleOrderNo desc "
        Try
            da.Fill(ds)
            SavedSaleOrders = ds.Tables(0)
        Catch exp As Exception
            SavedSaleOrders = Nothing
            Throw New Exception(exp.Message)
        Finally
            ds.Dispose()
            da.Dispose()
            da = Nothing
            ds = Nothing
        End Try
    End Function
    Public Shared Function SaleInvoiceLinkDetails(ByVal GroupCode As String, ByVal SaleOrderNo As String) As DataTable
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        Try
            da.SelectCommand.Parameters.Add("@GroupCode", SqlDbType.VarChar, 50).Value = GroupCode
            da.SelectCommand.Parameters.Add("@SaleOrderNo", SqlDbType.VarChar, 50).Value = SaleOrderNo
            da.SelectCommand.CommandText = "select InvoiceNo , convert(varchar(10),InvoiceDate,103) InvoiceDt , " & _
                " InvoiceQty , WagonLorryNo , GatePassNo , convert(varchar(10),GatePassDate,103) GatePassDt , Remarks " & _
                " from pm_SaleInvoiceLink where GroupCode = @GroupCode and SaleOrderNo = @SaleOrderNo " & _
                " order by InvoiceDate desc "
            da.Fill(ds)
            SaleInvoiceLinkDetails = ds.Tables(0)
        Catch exp As Exception
            SaleInvoiceLinkDetails = Nothing
            Throw New Exception(exp.Message)
        Finally
            ds.Dispose()
            da.Dispose()
            da = Nothing
            ds = Nothing
        End Try
    End Function
    Public Shared Function GetTopInvoiceNo() As String
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            cmd.Connection.Open()
            cmd.Parameters.Add("@GroupCode", SqlDbType.VarChar, 50).Value = "WARD30"
            cmd.Parameters.Add("@InvoiceNo", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            cmd.CommandText = "select top 1 @InvoiceNo = isnull(max(convert(int,substring(invoice_serial_number,6,5))),0)  " & _
                    " from dm_fg_excisable_goods_form where left(invoice_serial_number,4) = '2017' "
            cmd.ExecuteScalar()
            If IIf(IsDBNull(cmd.Parameters("@InvoiceNo").Value), "", cmd.Parameters("@InvoiceNo").Value) = "" Then
                GetTopInvoiceNo = "184"
            Else
                GetTopInvoiceNo = cmd.Parameters("@InvoiceNo").Value + 1
                GetTopInvoiceNo = "00000" + CStr(GetTopInvoiceNo)
                GetTopInvoiceNo = "2017" + Right(GetTopInvoiceNo, 5)
            End If
        Catch exp As Exception
            GetTopInvoiceNo = ""
            Throw New Exception(exp.Message)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
        End Try
    End Function
    Public Shared Function CheckSaleOrderNo(ByVal sso_number As String) As DataTable
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        Try
            da.SelectCommand.Parameters.Add("@sso_number", SqlDbType.VarChar, 50).Value = sso_number
            da.SelectCommand.CommandText = " select a.lot_number LotNo , convert(varchar(10),lot_date,103) LotDate ,  " & _
                " a.purchaser_name PurcharserName, quantity Quantity , a.UnitName Unit , a.ToTSaleValue  ,  " & _
                " pl_number PLNumber , short_description ShortDescription , a.gstn_number , hs_nomenclature HSNNo" & _
                " from pm_vw_SaleOrderList a inner join pm_vw_SaleOrderHSNNo b" & _
                " on a.lot_number = b.lot_number and a.sso_number = b.sso_number " & _
                " where a.sso_number = @sso_number"
            da.Fill(ds)
            CheckSaleOrderNo = ds.Tables(0)
        Catch exp As Exception
            CheckSaleOrderNo = Nothing
            Throw New Exception(exp.Message)
        Finally
            ds.Dispose()
            da.Dispose()
            da = Nothing
            ds = Nothing
        End Try
    End Function
    Public Shared Function ReferenceDetails(ByVal GroupCode As String, ByVal GroupReference As String) As DataTable
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        If GroupCode.Trim = "C&F" Then GroupCode = "CnF"
        da.SelectCommand.Parameters.Add("@GroupReference", SqlDbType.VarChar, 50).Value = GroupReference
        da.SelectCommand.Parameters.Add("@GroupCode", SqlDbType.VarChar, 50).Value = GroupCode
        da.SelectCommand.CommandText = "select InvoiceNo , convert(varchar(10),InvoiceDate,103) InvoiceDate , " & _
            " wagon_lorry_number VehicleNo , TotalValue , TaxableValue, GoodsHSN, GoodsDescription, UnitCode, Quantity, Rate" & _
            " from pm_vw_SaleInvoiceDetails " & _
            " where GroupCode = @GroupCode and  GroupReference = @GroupReference " & _
            " order by InvoiceNo desc"
        Try
            da.Fill(ds)
            ReferenceDetails = ds.Tables(0)
        Catch exp As Exception
            ReferenceDetails = Nothing
            Throw New Exception(exp.Message)
        Finally
            ds.Dispose()
            da.Dispose()
            da = Nothing
            ds = Nothing
        End Try
    End Function
    Public Shared Function GroupReference(ByVal GroupCode As String) As DataTable
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        If GroupCode.Trim = "C&F" Then GroupCode = "CnF"
        da.SelectCommand.Parameters.Add("@GroupCode", SqlDbType.VarChar, 50).Value = GroupCode
        da.SelectCommand.CommandText = "select distinct GroupReference from pm_vw_SaleInvoiceDetails " & _
            " where GroupCode = @GroupCode order by GroupReference desc  "
        Try
            da.Fill(ds)
            GroupReference = ds.Tables(0)
        Catch exp As Exception
            GroupReference = Nothing
            Throw New Exception(exp.Message)
        Finally
            ds.Dispose()
            da.Dispose()
            da = Nothing
            ds = Nothing
        End Try
    End Function
    Public Shared Function InvoiceDetails(ByVal invoice_serial_number As String, ByVal GroupCode As String) As DataTable
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        da.SelectCommand.Parameters.Add("@invoice_serial_number", SqlDbType.VarChar, 50).Value = invoice_serial_number
        If GroupCode = "PCOPCO" OrElse GroupCode = "C&F" Then
            da.SelectCommand.CommandText = "select  convert(varchar(10),invoice_date,103) InvoiceDate ,  " & _
                " wagon_lorry_quantity , sale_transfer_price , consignee, a.address, long_description , " & _
                " wagon_lorry_number , consignee_gst , '8607' HSNNo , '' City " & _
                " from dm_fg_excisable_goods_form a inner join mm_product_master b on a.product_code = b.product_code" & _
                " left outer join mm_customer_consignee c on c.name = a.consignee " & _
                " where invoice_serial_number = @invoice_serial_number  "
        ElseIf GroupCode = "WARD30" Then
            da.SelectCommand.CommandText = "select convert(varchar(10),InvoiceDate,103) InvoiceDate , InvoiceQty , " & _
                " convert(decimal(18,2),(Basic/b.quantity)) InvoiceRate , " & _
                " b.purchaser_name , b.purchaser_address , short_description , " & _
                " WagonLorryNo ,  b.gstn_number consignee_gst , hs_nomenclature HSNNo , '' City " & _
                " from pm_SaleInvoiceLink a inner join pm_vw_SaleOrderList b " & _
                " on SaleOrderNo = sso_number inner join pm_vw_SaleOrderHSNNo c" & _
                " on c.sso_number = b.sso_number where InvoiceNo = @invoice_serial_number "
        ElseIf GroupCode = "MRKTING" Then
            da.SelectCommand.CommandText = "select  convert(varchar(10),invoice_date,103) InvoiceDate ,  " & _
                " wagon_lorry_quantity , sale_price sale_transfer_price , consignee, a.address, long_description , " & _
                " wagon_lorry_number ,  consignee_gst , '8607' HSNNo , City " & _
                " from dm_fg_excisable_goods_form a inner join mm_product_master b on a.product_code = b.product_code" & _
                " left outer join mm_vw_NRCCustomerDetails c on c.CustomerName = a.consignee  " & _
                " where invoice_serial_number = @invoice_serial_number  "
        End If
        Try
            da.Fill(ds)
            InvoiceDetails = ds.Tables(0)
        Catch exp As Exception
            InvoiceDetails = Nothing
            Throw New Exception(exp.Message)
        Finally
            ds.Dispose()
            da.Dispose()
            da = Nothing
            ds = Nothing
        End Try
    End Function
    Public Shared Function UnitCodes() As DataTable
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        da.SelectCommand.CommandText = "select rtrim(description) UnitCode , code from code" & _
            " where application = 'pm' and code_type = 'ut' "
        Try
            da.Fill(ds)
            UnitCodes = ds.Tables(0)
        Catch exp As Exception
            UnitCodes = Nothing
            Throw New Exception(exp.Message)
        Finally
            ds.Dispose()
            da.Dispose()
            da = Nothing
            ds = Nothing
        End Try
    End Function
    Public Shared Function SavedDespatchInvoiceNos(ByVal despatch_advice_number As String, ByVal GroupCode As String) As DataTable
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        If GroupCode = "PCOPCO" OrElse GroupCode = "C&F" Then
            da.SelectCommand.CommandText = "select invoice_serial_number " & _
                       " from dm_fg_excisable_goods_form where despatch_advice_number = @despatch_advice_number " & _
                       " and invoice_date > '2017-06-30' order by invoice_serial_number desc "
        Else
            da.SelectCommand.CommandText = "select InvoiceNo " & _
                       " from pm_SaleInvoiceLink where SaleOrderNo = @despatch_advice_number " & _
                       " order by InvoiceNo desc "
        End If
        da.SelectCommand.Parameters.Add("@despatch_advice_number", SqlDbType.VarChar, 50).Value = despatch_advice_number
        Try
            da.Fill(ds)
            SavedDespatchInvoiceNos = ds.Tables(0)
        Catch exp As Exception
            SavedDespatchInvoiceNos = Nothing
            Throw New Exception(exp.Message)
        Finally
            ds.Dispose()
            da.Dispose()
            da = Nothing
            ds = Nothing
        End Try
    End Function

    Public Shared Function SavedDespatchAdvices(Optional ByVal Group As String = "") As DataTable
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        If Group.Trim = "PCOPCO" Then
            da.SelectCommand.CommandText = "select distinct despatch_advice_number , despatch_advice_date " & _
                " from dm_fg_excisable_goods_form where despatch_advice_number " & _
                " not in ( select distinct GroupReference from pm_SaleInvoiceDetails where GroupCode = 'c&f' ) " & _
                " and despatch_advice_date > '2017-06-30' order by despatch_advice_date desc "
        Else
            da.SelectCommand.CommandText = "select distinct despatch_advice_number , despatch_advice_date " & _
                " from dm_fg_excisable_goods_form where despatch_advice_number like 's%'" & _
                " and despatch_advice_date > '2017-06-30' and despatch_advice_number " & _
                " not in ( select distinct GroupReference from pm_SaleInvoiceDetails where GroupCode = 'pcopco' ) " & _
                " order by despatch_advice_date desc "
        End If

        Try
            da.Fill(ds)
            SavedDespatchAdvices = ds.Tables(0)
        Catch exp As Exception
            SavedDespatchAdvices = Nothing
            Throw New Exception(exp.Message)
        Finally
            ds.Dispose()
            da.Dispose()
            da = Nothing
            ds = Nothing
        End Try
    End Function
    Public Shared Function SavedSaleInvoiceDetails(ByVal GroupCode As String, ByVal GroupReference As String) As DataTable
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        da.SelectCommand.Parameters.Add("@GroupCode", SqlDbType.VarChar, 50).Value = GroupCode
        da.SelectCommand.Parameters.Add("@GroupReference", SqlDbType.VarChar, 50).Value = GroupReference
        da.SelectCommand.CommandText = "select GroupReference , InvoiceNo , " & _
            " InvoiceDate , GoodsHSN, GoodsDescription, Quantity, Rate " & _
            " from pm_SaleInvoiceDetails where GroupCode = @GroupCode and GroupReference = @GroupReference " & _
            " order by InvoiceNo desc "
        Try
            da.Fill(ds)
            SavedSaleInvoiceDetails = ds.Tables(0)
        Catch exp As Exception
            SavedSaleInvoiceDetails = Nothing
            Throw New Exception(exp.Message)
        Finally
            ds.Dispose()
            da.Dispose()
            da = Nothing
            ds = Nothing
        End Try
    End Function
    Public Shared Function ReferenceItems(ByVal RefId As Integer) As DataTable
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        da.SelectCommand.CommandText = "select ItemCode , Qty , Rate , CST ," & _
            " Packing , ItemDescription , OtherParticulars from pm_marketing_Items where RefID = @RefID "
        da.SelectCommand.Parameters.Add("@RefID", SqlDbType.Int, 4).Value = RefId
        Try
            da.Fill(ds)
            ReferenceItems = ds.Tables(0)
        Catch exp As Exception
            ReferenceItems = Nothing
            Throw New Exception(exp.Message)
        Finally
            ds.Dispose()
            da.Dispose()
            da = Nothing
            ds = Nothing
        End Try
    End Function
    Public Shared Function NRCCustomerDetails() As DataSet
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        da.SelectCommand.CommandText = "select NRCCode , Authority , FirmName , Address1 , " & _
            " Address2 , City , Pincode , State , email , PhoneNo , FaxNo , MobileNo , NRCID , consignee_gst ," & _
            " mmCustCode from mm_NRC_CustomerDetails order by NRCCode ; " & _
            " select Code , name CustomerName from mm_customer_consignee " & _
            " where customer_code = 'OT' order by name "
        Try
            da.Fill(ds)
            NRCCustomerDetails = ds.Copy
        Catch exp As Exception
            NRCCustomerDetails = Nothing
            Throw New Exception(exp.Message)
        Finally
            ds.Dispose()
            da.Dispose()
            da = Nothing
            ds = Nothing
        End Try
    End Function
    Public Shared Function ProductList(ByVal Product As String) As DataTable
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        If Product.ToLower = "wheel" Then
            da.SelectCommand.CommandText = "select distinct a.product_code Product ,  " & _
                " rtrim(drawing_number) DrawingNo , rtrim(b.description) ItemDescription , long_description ItemLongDescription " & _
                " from mm_workorder a inner join mm_product_master b " & _
                " on a.product_code = b.product_code where workorder_date >= '2016-04-01' " & _
                " and a.product_code like '[1,2]%' " & _
                " order by DrawingNo "
        ElseIf Product.ToLower = "axle" Then
            da.SelectCommand.CommandText = "select distinct a.product_code Product,  " & _
               " rtrim(drawing_number) DrawingNo , rtrim(b.description) ItemDescription , long_description ItemLongDescription " & _
               " from mm_workorder a inner join mm_product_master b " & _
               " on a.product_code = b.product_code where workorder_date >= '2016-04-01' " & _
               " and a.product_code like '[3,4]%' " & _
               " order by DrawingNo "
        ElseIf Product.ToLower = "wheelset" Then
            da.SelectCommand.CommandText = "select distinct a.product_code Product,  " & _
              " rtrim(drawing_number) DrawingNo , rtrim(b.description) ItemDescription , long_description ItemLongDescription " & _
              " from mm_workorder a inner join mm_product_master b " & _
              " on a.product_code = b.product_code where workorder_date >= '2016-04-01' " & _
              " and a.product_code like '[5,6]%' " & _
              " order by DrawingNo "
        End If
        Try
            da.Fill(ds)
            ProductList = ds.Tables(0)
        Catch exp As Exception
            ProductList = Nothing
            Throw New Exception(exp.Message)
        Finally
            ds.Dispose()
            da.Dispose()
            da = Nothing
            ds = Nothing
        End Try
    End Function
    Public Shared Function SavedReferenceIDs() As DataTable
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        da.SelectCommand.CommandText = "select distinct ReferenceNo , RefID " & _
            " from pm_marketing_referance a inner join mm_NRC_CustomerDetails b " & _
            " on Consignee = NRCCode left outer join pm_SaleInvoiceLink c" & _
            " on a.ReferenceNo = c.SaleOrderNo order by RefID desc "
        Try
            da.Fill(ds)
            SavedReferenceIDs = ds.Tables(0)
        Catch exp As Exception
            SavedReferenceIDs = Nothing
            Throw New Exception(exp.Message)
        Finally
            ds.Dispose()
            da.Dispose()
            da = Nothing
            ds = Nothing
        End Try
    End Function
    Public Shared Function SavedReferences(Optional ByVal RefId As Integer = 0) As DataTable
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        If RefId = 0 Then
            da.SelectCommand.CommandText = "select top 10 ReferenceNo , " & _
                " convert(varchar(10),RefDate,103) RefDt , Consignee , KindAttention , Subject , " & _
                " Ref , PIorSANo ,  convert(varchar(10),PIorSADate,103) PIorSADt , " & _
                " PONo ,  convert(varchar(10),PODate,103) PODate , ModeOfPayment , RefID , Officer , " & _
                " Note , Remarks , OtherLetters " & _
                " from pm_marketing_referance order by RefID desc"
        Else
            da.SelectCommand.CommandText = "select ReferenceNo , " & _
                " convert(varchar(10),RefDate,103) RefDt , Consignee , KindAttention , Subject , " & _
                " Ref , PIorSANo ,  convert(varchar(10),PIorSADate,103) PIorSADt , " & _
                " PONo ,  convert(varchar(10),PODate,103) PODate , ModeOfPayment , RefID , Officer , " & _
                " Note , Remarks , OtherLetters " & _
                " from pm_marketing_referance where RefID = @RefID"
            da.SelectCommand.Parameters.Add("@RefID", SqlDbType.Int, 4).Value = RefId
        End If
        Try
            da.Fill(ds)
            SavedReferences = ds.Tables(0)
        Catch exp As Exception
            SavedReferences = Nothing
            Throw New Exception(exp.Message)
        Finally
            ds.Dispose()
            da.Dispose()
            da = Nothing
            ds = Nothing
        End Try
    End Function
    Public Shared Function GetConsignee() As DataTable
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        da.SelectCommand.CommandText = "select NRCCode , Authority , FirmName " & _
            " from mm_NRC_CustomerDetails order by FirmName "
        Try
            da.Fill(ds)
            GetConsignee = ds.Tables(0)
        Catch exp As Exception
            GetConsignee = Nothing
            Throw New Exception(exp.Message)
        Finally
            ds.Dispose()
            da.Dispose()
            da = Nothing
            ds = Nothing
        End Try
    End Function
    Public Function SaveDetails(ByVal ReferenceNo As String, ByVal RefDate As Date, ByVal Consignee As String, ByVal KindAttention As String, ByVal Subject As String, ByVal Ref As String, ByVal PIorSANo As String, ByVal PIorSADate As Date, ByVal PONo As String, ByVal PODate As Date, ByVal ModeOfPayment As String, ByVal RefID As Integer, ByVal Officer As String, ByVal Note As String, ByVal Remarks As String, ByVal OtherLetters As String) As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        If RefID = 0 Then
            cmd.CommandText = "insert into pm_marketing_referance " & _
                " ( ReferenceNo , RefDate , Consignee , KindAttention , Subject , " & _
                " Ref , PIorSANo , PIorSADate , PONo , PODate , ModeOfPayment , Officer , Note , OtherLetters ) " & _
                " values ( @ReferenceNo , @RefDate , @Consignee , @KindAttention , @Subject , " & _
                " @Ref , @PIorSANo , @PIorSADate , @PONo , @PODate , @ModeOfPayment , @Officer , @Note , @OtherLetters )"
        Else
            cmd.CommandText = "update pm_marketing_referance " & _
                " set RefDate = @RefDate , Consignee = @Consignee , KindAttention = @KindAttention , " & _
                " Subject = @Subject , Ref = @Ref , PIorSANo = @PIorSANo , PIorSADate = @PIorSADate , " & _
                " PONo  = @PONo , PODate = @PODate , ModeOfPayment = @ModeOfPayment , Officer = @Officer , " & _
                " Note = @Note , OtherLetters = @OtherLetters " & _
                " where RefID = @RefID and ReferenceNo = @ReferenceNo "
        End If

        cmd.Parameters.Add("@ReferenceNo", SqlDbType.VarChar, 50).Value = ReferenceNo
        cmd.Parameters.Add("@RefDate", SqlDbType.SmallDateTime, 4).Value = RefDate
        cmd.Parameters.Add("@Consignee", SqlDbType.VarChar, 10).Value = Consignee
        cmd.Parameters.Add("@KindAttention", SqlDbType.VarChar, 50).Value = KindAttention
        cmd.Parameters.Add("@Subject", SqlDbType.VarChar, 100).Value = Subject
        cmd.Parameters.Add("@Ref", SqlDbType.VarChar, 50).Value = Ref
        cmd.Parameters.Add("@PIorSANo", SqlDbType.VarChar, 50).Value = PIorSANo
        cmd.Parameters.Add("@PIorSADate", SqlDbType.SmallDateTime, 4).Value = PIorSADate
        cmd.Parameters.Add("@PONo", SqlDbType.VarChar, 50).Value = PONo
        cmd.Parameters.Add("@PODate", SqlDbType.SmallDateTime, 4).Value = RefDate
        cmd.Parameters.Add("@ModeOfPayment", SqlDbType.VarChar, 250).Value = ModeOfPayment '
        cmd.Parameters.Add("@RefID", SqlDbType.Int, 4).Value = RefID
        cmd.Parameters.Add("@Officer", SqlDbType.VarChar, 10).Value = Officer '
        cmd.Parameters.Add("@Note", SqlDbType.VarChar, 250).Value = Note
        cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = Remarks '
        cmd.Parameters.Add("@OtherLetters", SqlDbType.VarChar, 250).Value = OtherLetters
        Try
            cmd.Connection.Open()
            If cmd.ExecuteNonQuery() = 1 Then Return True
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            If IsNothing(cmd) = False Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End If
        End Try
    End Function
    Public Function SaveItems(ByVal RefID As Integer, ByVal ItemCode As String, ByVal Qty As Integer, ByVal Rate As Integer, ByVal ED As Decimal, ByVal CST As Decimal, ByVal Packing As Integer, ByVal ItemDescription As String, ByVal OtherParticulars As String) As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RefID", SqlDbType.Int, 4).Value = RefID
        cmd.Parameters.Add("@ItemCode", SqlDbType.VarChar, 10).Value = ItemCode
        cmd.Connection.Open()
        cmd.CommandText = "select @cnt = count(*) from pm_marketing_Items " & _
                " where RefID = @RefID and ItemCode = @ItemCode "
        cmd.ExecuteScalar()
        If IIf(IsDBNull(cmd.Parameters("@cnt").Value), 0, cmd.Parameters("@cnt").Value) = 0 Then
            cmd.CommandText = "insert into pm_marketing_Items " & _
                " ( RefID , ItemCode , Qty , Rate , ED , CST , Packing , ItemDescription ,  OtherParticulars ) " & _
                " values ( @RefID , @ItemCode , @Qty , @Rate , @ED , @CST , @Packing  , @ItemDescription , @OtherParticulars )"
        Else
            cmd.CommandText = "update pm_marketing_Items " & _
                " set Qty = @Qty , Rate = @Rate , ED = @ED , CST = @CST , Packing = @Packing , " & _
                " ItemDescription = @ItemDescription , OtherParticulars = @OtherParticulars " & _
                " where RefID = @RefID and ItemCode = @ItemCode "
        End If
        cmd.Parameters.Add("@Qty", SqlDbType.Int, 4).Value = Qty
        cmd.Parameters.Add("@Rate", SqlDbType.Int, 4).Value = Rate
        cmd.Parameters.Add("@ED", SqlDbType.Decimal, 8, 2).Value = ED
        cmd.Parameters.Add("@CST", SqlDbType.Decimal, 8, 2).Value = CST
        cmd.Parameters.Add("@Packing", SqlDbType.Int, 4).Value = Packing
        cmd.Parameters.Add("@ItemDescription", SqlDbType.VarChar, 100).Value = ItemDescription
        cmd.Parameters.Add("@OtherParticulars", SqlDbType.VarChar, 100).Value = OtherParticulars

        Try
            If cmd.ExecuteNonQuery() = 1 Then Return True
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            If IsNothing(cmd) = False Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End If
        End Try
    End Function
    Public Function SaveCustomerDetails(ByVal NRCCode As String, ByVal Authority As String, ByVal FirmName As String, ByVal Address1 As String, ByVal Address2 As String, ByVal City As String, ByVal Pincode As String, ByVal State As String, ByVal email As String, ByVal PhoneNo As String, ByVal FaxNo As String, ByVal MobileNo As String, ByVal NRCID As Integer, ByVal consignee_gst As String, ByVal mmCustCode As String) As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        If NRCID = 0 Then
            cmd.CommandText = "insert into mm_NRC_CustomerDetails " & _
                " ( NRCCode , Authority , FirmName , Address1 ,  Address2 , City ," & _
                " Pincode , State , email , PhoneNo , FaxNo , MobileNo , consignee_gst , mmCustCode ) " & _
                " values ( @NRCCode , @Authority , @FirmName , @Address1 , @Address2 , @City , " & _
                " @Pincode , @State , @email , @PhoneNo , @FaxNo , @MobileNo , @consignee_gst , @mmCustCode )"
        Else
            cmd.CommandText = "update mm_NRC_CustomerDetails " & _
                " set Authority = @Authority , FirmName = @FirmName , Address1 = @Address1 , " & _
                " Address2 = @Address2 , City = @City , Pincode = @Pincode , State = @State , " & _
                " email  = @email , PhoneNo = @PhoneNo , FaxNo = @FaxNo , MobileNo = @MobileNo , " & _
                " consignee_gst = @consignee_gst , mmCustCode = @mmCustCode where NRCCode = @NRCCode and NRCID = @NRCID "
        End If

        cmd.Parameters.Add("@NRCCode", SqlDbType.VarChar, 50).Value = NRCCode
        cmd.Parameters.Add("@Authority", SqlDbType.VarChar, 10).Value = Authority
        cmd.Parameters.Add("@FirmName", SqlDbType.VarChar, 50).Value = FirmName
        cmd.Parameters.Add("@Address1", SqlDbType.VarChar, 50).Value = Address1
        cmd.Parameters.Add("@Address2", SqlDbType.VarChar, 50).Value = Address2
        cmd.Parameters.Add("@City", SqlDbType.VarChar, 50).Value = City
        cmd.Parameters.Add("@Pincode", SqlDbType.VarChar, 50).Value = Pincode
        cmd.Parameters.Add("@State", SqlDbType.VarChar, 50).Value = State
        cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = email
        cmd.Parameters.Add("@PhoneNo", SqlDbType.VarChar, 50).Value = PhoneNo
        cmd.Parameters.Add("@FaxNo", SqlDbType.VarChar, 50).Value = FaxNo
        cmd.Parameters.Add("@MobileNo", SqlDbType.VarChar, 50).Value = MobileNo
        cmd.Parameters.Add("@NRCID", SqlDbType.Int, 4).Value = NRCID
        cmd.Parameters.Add("@consignee_gst", SqlDbType.VarChar, 100).Value = consignee_gst
        cmd.Parameters.Add("@mmCustCode", SqlDbType.VarChar, 10).Value = mmCustCode
        Try
            cmd.Connection.Open()
            If cmd.ExecuteNonQuery() = 1 Then Return True
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            If IsNothing(cmd) = False Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End If
        End Try
    End Function
    Public Function SaveSaleInvoiceDetails(ByVal GroupCode As String, ByVal GroupReference As String, ByVal InvoiceNo As String, ByVal InvoiceDate As Date, ByVal TotalValue As Decimal, ByVal TaxableValue As Decimal, ByVal GoodsHSN As String, ByVal GoodsDescription As String, ByVal UnitCode As String, ByVal Quantity As Decimal, ByVal Rate As Decimal, ByVal ITC As String, ByVal IGSTRate As Decimal, ByVal IGSTChargedAmt As Decimal, ByVal CGSTRate As Decimal, ByVal CGSTChargedAmt As Decimal, ByVal SGSTRate As Decimal, ByVal SGSTChargedAmt As Decimal, ByVal CessRate As Decimal, ByVal CessChargedAmt As Decimal, ByVal GoodsName As String, ByVal PlaceOfSupply As String, ByVal RecepientGSTIN As String, ByVal ReverseTax As String, ByVal TDS As String, ByVal UGSTRate As Decimal, ByVal UGSTChargedAmt As Decimal) As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.Parameters.Add("@GroupCode", SqlDbType.VarChar, 50).Value = GroupCode
        cmd.Parameters.Add("@GroupReference", SqlDbType.VarChar, 50).Value = GroupReference
        cmd.Parameters.Add("@InvoiceNo", SqlDbType.VarChar, 50).Value = InvoiceNo
        cmd.Parameters.Add("@InvoiceDate", SqlDbType.SmallDateTime, 4).Value = InvoiceDate
        cmd.Parameters.Add("@TotalValue", SqlDbType.Decimal, 18, 2).Value = TotalValue
        cmd.Parameters.Add("@TaxableValue", SqlDbType.Decimal, 18, 3).Value = TaxableValue
        cmd.Parameters.Add("@GoodsHSN", SqlDbType.VarChar, 50).Value = GoodsHSN
        cmd.Parameters.Add("@GoodsDescription", SqlDbType.VarChar, 250).Value = GoodsDescription
        cmd.Parameters.Add("@UnitCode", SqlDbType.VarChar, 50).Value = UnitCode
        cmd.Parameters.Add("@Quantity", SqlDbType.Decimal, 18, 3).Value = Quantity
        cmd.Parameters.Add("@Rate", SqlDbType.Decimal, 18, 3).Value = Rate
        cmd.Parameters.Add("@ITC", SqlDbType.VarChar, 1).Value = ITC
        cmd.Parameters.Add("@IGSTRate", SqlDbType.Decimal, 18, 3).Value = IGSTRate
        cmd.Parameters.Add("@IGSTChargedAmt", SqlDbType.Decimal, 18, 2).Value = IGSTChargedAmt
        cmd.Parameters.Add("@CGSTRate", SqlDbType.Decimal, 18, 3).Value = CGSTRate
        cmd.Parameters.Add("@CGSTChargedAmt", SqlDbType.Decimal, 18, 2).Value = CGSTChargedAmt
        cmd.Parameters.Add("@SGSTRate", SqlDbType.Decimal, 18, 3).Value = SGSTRate
        cmd.Parameters.Add("@SGSTChargedAmt", SqlDbType.Decimal, 18, 2).Value = SGSTChargedAmt
        cmd.Parameters.Add("@CessRate", SqlDbType.Decimal, 18, 3).Value = CessRate
        cmd.Parameters.Add("@CessChargedAmt", SqlDbType.Decimal, 18, 2).Value = CessChargedAmt
        cmd.Parameters.Add("@GoodsName", SqlDbType.VarChar, 50).Value = GoodsName
        cmd.Parameters.Add("@PlaceOfSupply", SqlDbType.VarChar, 250).Value = PlaceOfSupply
        cmd.Parameters.Add("@RecepientGSTIN", SqlDbType.VarChar, 50).Value = RecepientGSTIN
        cmd.Parameters.Add("@ReverseTax", SqlDbType.VarChar, 1).Value = ReverseTax
        cmd.Parameters.Add("@TDS", SqlDbType.VarChar, 50).Value = TDS
        cmd.Parameters.Add("@UGSTRate", SqlDbType.Decimal, 18, 3).Value = UGSTRate
        cmd.Parameters.Add("@UGSTChargedAmt", SqlDbType.Decimal, 18, 2).Value = UGSTChargedAmt
        cmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output

        cmd.CommandText = "select @cnt = count(*) from pm_SaleInvoiceDetails " & _
            " where GroupCode = @GroupCode and GroupReference = @GroupReference and InvoiceNo = @InvoiceNo "
        cmd.Connection.Open()
        cmd.ExecuteScalar()
        If IIf(IsDBNull(cmd.Parameters("@cnt").Value), 0, cmd.Parameters("@cnt").Value) = 0 Then
            cmd.CommandText = "insert into pm_SaleInvoiceDetails " & _
                " ( GroupCode , GroupReference , InvoiceNo , InvoiceDate ,  TotalValue , TaxableValue ," & _
                " GoodsHSN , GoodsDescription , UnitCode , Quantity , Rate , ITC , IGSTRate , IGSTChargedAmt , " & _
                " CGSTRate , CGSTChargedAmt , SGSTRate , SGSTChargedAmt , CessRate , CessChargedAmt , " & _
                " GoodsName , PlaceOfSupply , RecepientGSTIN , ReverseTax , TDS , UGSTRate , UGSTChargedAmt ) " & _
                " values ( @GroupCode , @GroupReference , @InvoiceNo , @InvoiceDate , @TotalValue , @TaxableValue , " & _
                " @GoodsHSN , @GoodsDescription , @UnitCode , @Quantity , @Rate , @ITC , @IGSTRate , @IGSTChargedAmt , " & _
                " @CGSTRate , @CGSTChargedAmt ,  @SGSTRate , @SGSTChargedAmt , @CessRate , @CessChargedAmt , " & _
                " @GoodsName , @PlaceOfSupply , @RecepientGSTIN , @ReverseTax , @TDS , @UGSTRate , @UGSTChargedAmt )"
        Else
            cmd.CommandText = "update pm_SaleInvoiceDetails " & _
                " set InvoiceDate = @InvoiceDate , TotalValue = @TotalValue , TaxableValue = @TaxableValue , " & _
                " GoodsHSN = @GoodsHSN , GoodsDescription = @GoodsDescription , UnitCode = @UnitCode , Quantity = @Quantity , " & _
                " Rate  = @Rate , ITC = @ITC , IGSTRate = @IGSTRate , IGSTChargedAmt = @IGSTChargedAmt , " & _
                " CGSTRate = @CGSTRate , CGSTChargedAmt = @CGSTChargedAmt , SGSTRate = @SGSTRate , SGSTChargedAmt = @SGSTChargedAmt , " & _
                " CessRate = @CessRate , CessChargedAmt = @CessChargedAmt , GoodsName = @GoodsName , PlaceOfSupply = @PlaceOfSupply ," & _
                " RecepientGSTIN = @RecepientGSTIN , ReverseTax = @ReverseTax , TDS = @TDS , UGSTRate = @UGSTRate , UGSTChargedAmt = @UGSTChargedAmt , " & _
                " GroupCode = @GroupCode , GroupReference = @GroupReference where InvoiceNo = @InvoiceNo "
        End If
        Try

            If cmd.ExecuteNonQuery() > 0 Then Return True
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            If IsNothing(cmd) = False Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End If
        End Try
    End Function
    Public Function SaveSaleInvoiceLinkDetails(ByVal GroupCode As String, ByVal SaleOrderNo As String, ByVal InvoiceNo As String, ByVal InvoiceDate As Date, ByVal InvoiceQty As Decimal, ByVal WagonLorryNo As String, ByVal Remarks As String, ByVal Staff As String, ByVal GatePassNo As String, ByVal GatePassDate As Date, ByVal DespatchAdviceNumber As String) As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.Parameters.Add("@GroupCode", SqlDbType.VarChar, 50).Value = GroupCode
        cmd.Parameters.Add("@SaleOrderNo", SqlDbType.VarChar, 50).Value = SaleOrderNo
        cmd.Parameters.Add("@InvoiceNo", SqlDbType.VarChar, 50).Value = InvoiceNo
        cmd.Parameters.Add("@InvoiceDate", SqlDbType.SmallDateTime, 4).Value = InvoiceDate
        cmd.Parameters.Add("@InvoiceQty", SqlDbType.Decimal, 18, 3).Value = InvoiceQty
        cmd.Parameters.Add("@WagonLorryNo", SqlDbType.VarChar, 50).Value = WagonLorryNo
        cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 50).Value = Remarks
        cmd.Parameters.Add("@Staff", SqlDbType.VarChar, 6).Value = Staff
        cmd.Parameters.Add("@GatePassNo", SqlDbType.VarChar, 50).Value = GatePassNo
        cmd.Parameters.Add("@GatePassDate", SqlDbType.SmallDateTime, 4).Value = GatePassDate
        cmd.Parameters.Add("@DespatchAdviceNumber", SqlDbType.VarChar, 50).Value = DespatchAdviceNumber
        cmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output

        cmd.CommandText = "select @cnt = count(*) from pm_SaleInvoiceLink " & _
            " where GroupCode = @GroupCode and SaleOrderNo = @SaleOrderNo and InvoiceNo = @InvoiceNo "
        cmd.Connection.Open()
        cmd.ExecuteScalar()
        Try
            If IIf(IsDBNull(cmd.Parameters("@cnt").Value), 0, cmd.Parameters("@cnt").Value) = 0 Then
                cmd.CommandText = "insert into pm_SaleInvoiceLink " & _
                    " ( GroupCode , SaleOrderNo , InvoiceNo , InvoiceDate ,  InvoiceQty , WagonLorryNo ," & _
                    " Remarks , Staff , SaveDateTime , GatePassDate , GatePassNo , DespatchAdviceNumber ) " & _
                    " values ( @GroupCode , @SaleOrderNo , @InvoiceNo , @InvoiceDate , @InvoiceQty , @WagonLorryNo , " & _
                    " @Remarks , @Staff , getdate() , @GatePassDate , @GatePassNo , @DespatchAdviceNumber )"
            Else
                cmd.CommandText = "update pm_SaleInvoiceLink " & _
                    " set InvoiceDate = @InvoiceDate , InvoiceQty = @InvoiceQty , WagonLorryNo = @WagonLorryNo , " & _
                    " Remarks = @Remarks , Staff = @Staff , SaveDateTime = getdate() , GatePassDate = @GatePassDate , " & _
                    " GatePassNo = @GatePassNo where GroupCode = @GroupCode and SaleOrderNo = @SaleOrderNo " & _
                    " and DespatchAdviceNumber = @DespatchAdviceNumber and InvoiceNo = @InvoiceNo "
            End If
            If cmd.ExecuteNonQuery() > 0 Then Return True
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            If IsNothing(cmd) = False Then
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing
            End If
        End Try
    End Function
End Class
