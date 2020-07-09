Namespace metLab
    Public Enum TestType
        Experimental
        Regular
    End Enum
    Public Class tables
        Public Shared Function Top1JMPHeat() As Double
            Dim oCmd As New SqlClient.SqlCommand()
            oCmd.Connection = rwfGen.Connection.ConObj
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Parameters.Add("@heat_number", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
                oCmd.CommandText = " select top 1 @heat_number = heat_number from mm_vw_spectro_results_JMP " & _
                    " order by heat_number desc "
                oCmd.ExecuteScalar()
                Top1JMPHeat = IIf(IsDBNull(oCmd.Parameters("@heat_number").Value), 0, oCmd.Parameters("@heat_number").Value)
            Catch exp As Exception
                Top1JMPHeat = ""
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End Try
        End Function
        Public Shared Function JMPDetails(ByVal frht As Double, ByVal toht As Double, ByVal Type As Integer) As DataTable
            Dim ds As New DataSet()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.Parameters.Add("@frht", SqlDbType.BigInt, 8).Value = frht
                da.SelectCommand.Parameters.Add("@toht", SqlDbType.BigInt, 8).Value = toht
                da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = Type
                da.SelectCommand.CommandText = "mm_sp_SpectroQuerry"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.CommandTimeout = 3600
                da.Fill(ds)
                JMPDetails = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function SpectroDetails(ByVal frht As Double, ByVal toht As Double, ByVal Sample As String) As DataTable
            Dim ds As New DataSet()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.Parameters.Add("@frht", SqlDbType.BigInt, 8).Value = frht
                da.SelectCommand.Parameters.Add("@toht", SqlDbType.BigInt, 8).Value = toht
                da.SelectCommand.Parameters.Add("@Sample", SqlDbType.VarChar, 10).Value = Sample
                da.SelectCommand.CommandText = "ms_sp_SpectroResults"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.Fill(ds)
                SpectroDetails = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function TestSampleDetails(ByVal FrDt As Date, ByVal ToDt As Date, ByVal Type As Integer) As DataTable
            Dim ds As New DataSet()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = "ms_sp_TestSampleDetails"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.Add("@frDt", SqlDbType.SmallDateTime, 4).Value = FrDt
                da.SelectCommand.Parameters.Add("@ToDt", SqlDbType.SmallDateTime, 4).Value = ToDt
                da.SelectCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = Type
                da.Fill(ds)
                TestSampleDetails = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function getCastTestDrgsDetails(ByVal FrDt As Date, ByVal ToDt As Date, ByVal Drg As String) As DataTable
            Dim ds As New DataSet()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.Parameters.Add("@Frdt", SqlDbType.SmallDateTime, 4).Value = FrDt
                da.SelectCommand.Parameters.Add("@ToDt", SqlDbType.SmallDateTime, 4).Value = ToDt
                If Drg.Trim.ToLower = "all" Then
                    da.SelectCommand.CommandText = " SELECT a.lab_number LabNo , " & _
                        " rtrim(b.drawing_number) DrawingNumber  , rtrim(b.cast_number) CastNo, " & _
                        " convert(varchar(10),A.test_date,103)  TestDt  ,   " & _
                        " b.axle_number AxleNo , a.yield_strength YS , ut_strength Tensile , elongation [Elong %] ,   " & _
                        " reduction [R.A.%] ,a.charpy , astm , rtrim(b.remarks) Spec , " & _
                        " carbon C , phosphorus P , manganese Mn , sulphur S , silicon Si , chromium Cr , nickle Ni , copper Cu , " & _
                        " vanadium V , molybdenum Mo , phosphorus_sulphur [P+S]  " & _
                        " FROM  ms_casttest_physical A inner join ms_cast_test_sample B " & _
                        " on A.lab_number = B.lab_number left outer join ms_casttest_chemical C" & _
                        " on A.lab_number = C.lab_number" & _
                        " WHERE A.test_date between @Frdt and @ToDt order by a.lab_number"
                Else
                    da.SelectCommand.CommandText = " SELECT a.lab_number LabNo, " & _
                        " rtrim(b.drawing_number) DrawingNumber  , rtrim(b.cast_number) CastNo, " & _
                        " convert(varchar(10),A.test_date,103)  TestDt ,   " & _
                        " b.axle_number AxleNo , a.yield_strength YS , ut_strength Tensile , elongation [Elong %] ,   " & _
                        " reduction [R.A.%] ,a.charpy , astm , rtrim(b.remarks) Spec , " & _
                        " carbon C , phosphorus P , manganese Mn , sulphur S , silicon Si , chromium Cr , nickle Ni , copper Cu , " & _
                        " vanadium V , molybdenum Mo , phosphorus_sulphur [P+S]  " & _
                        " FROM  ms_casttest_physical A inner join ms_cast_test_sample B " & _
                        " on A.lab_number = B.lab_number left outer join ms_casttest_chemical C" & _
                        " on A.lab_number = C.lab_number" & _
                        " WHERE A.test_date between @Frdt and @ToDt and b.drawing_number = @Drg " & _
                        " order by a.lab_number "
                    da.SelectCommand.Parameters.Add("@Drg", SqlDbType.VarChar, 50).Value = Drg
                End If
                da.Fill(ds)
                getCastTestDrgsDetails = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function getCastTestDrgs() As DataTable
            Dim ds As New DataSet()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = " SELECT distinct rtrim(b.drawing_number) drawing_number " & _
                    " FROM  ms_casttest_physical A inner join ms_cast_test_sample B " & _
                    " on A.lab_number = B.lab_number left outer join ms_casttest_chemical C" & _
                    " on A.lab_number = C.lab_number where drawing_number <> ''  and sent_date >= '2010-01-01'  " & _
                    " order by rtrim(b.drawing_number) "
                da.Fill(ds)
                getCastTestDrgs = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function VerifyCast(ByVal CastNumber As String) As Boolean
            Dim oCmd As New SqlClient.SqlCommand()
            oCmd.Connection = rwfGen.Connection.ConObj
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Parameters.Add("@CastNumber", SqlDbType.VarChar, 50).Value = CastNumber
                oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                oCmd.CommandText = " select @cnt = COUNT(*) FROM mm_axle_master   " & _
                    " WHERE cast_number = @CastNumber "
                oCmd.ExecuteScalar()
                VerifyCast = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)
            Catch exp As Exception
                VerifyCast = ""
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End Try
        End Function
        Public Shared Function getLabNo(ByVal Whl As Double, ByVal Ht As Double) As String
            Dim oCmd As New SqlClient.SqlCommand()
            oCmd.Connection = rwfGen.Connection.ConObj
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Parameters.Add("@Whl", SqlDbType.BigInt, 8).Value = Whl
                oCmd.Parameters.Add("@Ht", SqlDbType.BigInt, 8).Value = Ht
                oCmd.Parameters.Add("@lab_number", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                oCmd.CommandText = " select @lab_number = lab_number from ms_wheel_hardness_sample " & _
                    " where wheel_number = @Whl and heat_number = @Ht "
                oCmd.ExecuteScalar()
                getLabNo = IIf(IsDBNull(oCmd.Parameters("@lab_number").Value), "", oCmd.Parameters("@lab_number").Value)
            Catch exp As Exception
                getLabNo = ""
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End Try
        End Function
        Public Shared Function getHardnessTestWheelNumbers() As DataTable
            Dim ds As New DataSet()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = " select convert(varchar,wheel_number)+'/'+convert(varchar,heat_number) WhlNo , lab_number " & _
                    " from ms_wheel_hardness_htdetails " & _
                    " where lab_number in (  select top 75 lab_number from ms_wheel_hardness_details " & _
                    " where lab_number in  (select top 75 lab_number from ms_wheel_hardness_sample order by sent_date desc) ) " & _
                    " order by lab_number desc  "
                da.Fill(ds)
                getHardnessTestWheelNumbers = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetSampleAxleDetails(ByVal Type As String, ByVal No As String) As DataTable
            Dim oDs As New DataSet()
            Dim oDa As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            oDa.SelectCommand.CommandText = " select top 1 sent_date , shift_code , operator_code , " & _
                " axle_number , a.remarks Spec , a.lab_number , result , cast_number , a.test_date , " & _
                " cast_group , drawing_number , ut_strength , yield_strength , elongation , reduction , " & _
                " charpy , astm , macro_vert , macro_long , b.remarks , bend , " & _
                " carbon , phosphorus , manganese , sulphur , silicon , chromium , nickle ," & _
                " copper, vanadium, molybdenum, phosphorus_sulphur, nitrogen" & _
                " from  ms_cast_test_sample a left outer join ms_casttest_physical b " & _
                " on a.lab_number = b.lab_number left outer join ms_casttest_chemical c " & _
                " on a.lab_number = c.lab_number "
            If Type.ToLower = "axle" Then
                oDa.SelectCommand.CommandText &= " where a.axle_number = @AxleNo "
            ElseIf Type.ToLower = "cast" Then
                oDa.SelectCommand.CommandText &= " where cast_number = @AxleNo "
            ElseIf Type.ToLower = "lab" Then
                oDa.SelectCommand.CommandText &= " where a.lab_number = @AxleNo "
            End If
            oDa.SelectCommand.CommandText &= " order by a.test_date desc "
            oDa.SelectCommand.Parameters.Add("@AxleNo", SqlDbType.VarChar, 50).Value = No
            Try
                oDa.Fill(oDs)
                GetSampleAxleDetails = oDs.Tables(0).Copy
            Catch exp As Exception
                GetSampleAxleDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                oDa.Dispose()
                oDs.Dispose()
            End Try
        End Function
        Public Shared Function CastTestDetails(ByVal FromDate As Date, ByVal ToDate As Date, ByVal Qry As Integer) As DataTable
            Dim ds As New DataSet()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = "ms_sp_DetailsOfTests"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.Add("@frDt", SqlDbType.SmallDateTime, 4).Value = FromDate
                da.SelectCommand.Parameters.Add("@toDt", SqlDbType.SmallDateTime, 4).Value = ToDate
                da.SelectCommand.Parameters.Add("@Qry", SqlDbType.Int, 4).Value = Qry
                da.Fill(ds)
                CastTestDetails = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function LabStatusForDespatchedWheels(ByVal FromDate As Date, ByVal ToDate As Date) As DataTable
            Dim ds As New DataSet()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.CommandText = "ms_sp_LabStatusForDespatchedWheels"
                da.SelectCommand.Parameters.Add("@fr", SqlDbType.SmallDateTime, 4).Value = FromDate
                da.SelectCommand.Parameters.Add("@to", SqlDbType.SmallDateTime, 4).Value = ToDate
                da.Fill(ds)
                LabStatusForDespatchedWheels = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function WheelHardnessTestValues(ByVal FromDate As Date, ByVal ToDate As Date, ByVal Choice As Integer, ByVal WheelType As String) As DataTable
            Dim ds As New DataSet()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.CommandText = "ms_sp_WheelHardnessTestValues"
                da.SelectCommand.Parameters.Add("@frDt", SqlDbType.SmallDateTime, 4).Value = FromDate
                da.SelectCommand.Parameters.Add("@toDt", SqlDbType.SmallDateTime, 4).Value = ToDate
                da.SelectCommand.Parameters.Add("@DtType", SqlDbType.Int, 4).Value = Choice
                da.SelectCommand.Parameters.Add("@product", SqlDbType.VarChar, 6).Value = WheelType
                da.Fill(ds)
                WheelHardnessTestValues = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function SimilarCastGroup(ByVal ProductCode As String, Optional ByVal CastGroup As String = "") As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@product_code", SqlDbType.VarChar, 50).Value = ProductCode
                If CastGroup = "" Then
                    da.SelectCommand.CommandText = " select product_code , long_description , a.drawing_number , cast_group from mm_product_master a " & _
                        " inner join ( select ltrim(rtrim(drawing_number)) drawing_number from mm_product_master where product_code = @product_code ) b " & _
                        " on a.drawing_number = b.drawing_number where a.product_code <> @product_code  and a.product_code like '[3,4]%' "
                Else
                    da.SelectCommand.CommandText = " select product_code , long_description , a.drawing_number , cast_group from mm_product_master a " & _
                        " inner join ( select ltrim(rtrim(drawing_number)) drawing_number from mm_product_master where product_code = @product_code ) b " & _
                        " on a.drawing_number = b.drawing_number where a.product_code <> @product_code  and a.product_code like '[3,4]%' and cast_group = @CastGroup "
                    da.SelectCommand.Parameters.Add("@CastGroup", SqlDbType.VarChar, 50).Value = CastGroup
                End If

                da.Fill(ds, "ProductCodes")
                SimilarCastGroup = ds.Tables("ProductCodes")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function GetAxleProductList() As DataTable
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select product_code , long_description , description , drawing_number , type " & _
                                " from mm_product_master where cast_group is null and product_code like '[3,4]%' order by product_code "
            Try
                da.Fill(ds, "ProductCodes")
                GetAxleProductList = ds.Tables("ProductCodes")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
        End Function
        Public Shared Function SavedR43R16Specs(Optional ByVal Product_code As String = "", Optional ByVal R43R16 As String = "") As DataTable
            Dim dtSavedR43R16Specs As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select a.Product_code PCode , a.R43R16 , b.drawing_number ,  b.description , b.long_description" & _
                                " from mm_AxleProductMaster_R43R16Specs a inner join mm_product_master b on a.Product_code = b.Product_code "
            Try
                If Product_code.Trim.Length > 0 Then
                    da.SelectCommand.CommandText &= " where a.Product_code = @Product_code"
                    da.SelectCommand.Parameters.Add("@Product_code", SqlDbType.VarChar, 6)
                    da.SelectCommand.Parameters("@Product_code").Direction = ParameterDirection.Input
                    da.SelectCommand.Parameters("@Product_code").Value = Product_code.Trim
                End If
                da.Fill(ds, "SavedR43R16Specs")
                dtSavedR43R16Specs = ds.Tables("SavedR43R16Specs")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtSavedR43R16Specs
        End Function
        Public Shared Function GetCastNoDetails(ByVal Cast_no As String) As DataTable
            Dim ds As New DataSet()
            Dim da As New SqlClient.SqlDataAdapter()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.CommandText = "select top 1 d.r43r16, b.RitesReference, " & _
                    " B.AxleProductCode Product_code, a.RWF_Axle_Number, c.drawing_number, a.customerCastNumber, " & _
                    " c.cast_group, b.RitesCertificateNumber, b.CertificateDate, c.description  " & _
                    " from mm_nonrwfAxles_PcoEntry A INNER JOIN mm_nonrwfAxles_PcoRef b " & _
                    " on a.RitesReference = b.RitesReference inner join mm_product_master c " & _
                    " on c.product_code = b.axleProductCode inner join  mm_AxleProductMaster_R43R16Specs d " & _
                    " on d.product_code = b.AxleProductCode " & _
                    " where a.customerCastNumber = @Cast_no " & _
                    " and a.RWF_Axle_Number is not null"
                da.SelectCommand.Parameters.Add("@Cast_no", SqlDbType.VarChar, 50).Value = Cast_no
                da.Fill(ds)
                GetCastNoDetails = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetNonRWFAxleNoDetails(ByVal AxleNo As String) As DataTable
            Dim ds As New DataSet()
            Dim da As New SqlClient.SqlDataAdapter()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.CommandText = "select a.RitesReference ,  a.RitesCertificateNumber ,  " & _
                    " a.CertificateDate  ,  a.AxleProductCode, c.drawing_number, b.customerAxleNumber, " & _
                    " b.CustomerCastNumber, b.RWF_Axle_Number, a.RitesCertificateNumber, a.CertificateDate , " & _
                    " c.cast_group , c.Specification , c.description , c.Product_code " & _
                    " from mm_NonrwfAxles_PcoRef a inner join mm_NonrwfAxles_PcoEntry b " & _
                    " on a.RitesReference = b.RitesReference inner join mm_product_master c " & _
                    " on c.product_code = a.AxleProductCode " & _
                    " where b.RWF_Axle_Number = @AxleNo "
                da.SelectCommand.Parameters.Add("@AxleNo", SqlDbType.VarChar, 50).Value = AxleNo
                da.Fill(ds)
                GetNonRWFAxleNoDetails = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function CheckAxleNo(ByVal AxleNo As String) As String
            Dim oCmd As New SqlClient.SqlCommand()
            oCmd.Connection = rwfGen.Connection.ConObj
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Parameters.Add("@AxleNo", SqlDbType.VarChar, 50).Value = AxleNo
                oCmd.Parameters.Add("@lab_number", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                oCmd.CommandText = " select @lab_number = lab_number from ms_cast_test_sample where axle_number =  @AxleNo "
                oCmd.ExecuteScalar()
                Dim LabNo As String = IIf(IsDBNull(oCmd.Parameters("@lab_number").Value), "", oCmd.Parameters("@lab_number").Value)
                If LabNo.Trim.Length > 0 Then
                    Throw New Exception("Axle No " & AxleNo.Trim & " already tested in LabNo : " & LabNo.Trim & " ")
                End If
            Catch exp As Exception
                CheckAxleNo = ""
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End Try
        End Function
        Public Shared Function GetAxleNoDetails(ByVal AxleNo As String) As DataTable
            Dim ds As New DataSet()
            Dim da As New SqlClient.SqlDataAdapter()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.CommandText = " select a.cast_number , a.drawing_number , " & _
                    " rtrim(b.cast_group) CastGrp , dbo.mm_fn_GetAxleSpecs(a.axle_number) Specification " & _
                    " from mm_axle_master a inner join mm_vw_si_RWFAxleProducts b " & _
                    " on a.drawing_number = b.drawing_number" & _
                    " and a.axle_number = @AxleNo "
                da.SelectCommand.Parameters.Add("@AxleNo", SqlDbType.VarChar, 50).Value = AxleNo
                da.Fill(ds)
                GetAxleNoDetails = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetLabNoList(ByVal sent_date As Date) As DataTable
            Dim ds As New DataSet()
            Dim da As New SqlClient.SqlDataAdapter()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.CommandText = " select rtrim(lab_number) LabNo ,  " & _
                    " rtrim(axle_number) AxleNo , rtrim(remarks) Spec , rtrim(cast_number) CastNo ,   " & _
                    " rtrim(cast_group) CastGroup , rtrim(drawing_number) DrgNo , Result " & _
                    " from ms_cast_test_sample where axle_number like 'rwf%' and sent_date = @sent_date " & _
                    " order by lab_number desc "
                da.SelectCommand.Parameters.Add("@sent_date", SqlDbType.SmallDateTime, 4).Value = sent_date
                da.Fill(ds)
                GetLabNoList = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function generateLabNumber() As String
            Dim ds As New DataSet()
            Dim da As New SqlClient.SqlDataAdapter()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                Dim a, b As String
                Dim cnt, precnt, i As Integer
                Dim dat As Date
                precnt = 0
                i = 0
                a = Date.Today.Year
                a = a.Substring(2, 2) & "%"
                da.SelectCommand.CommandText = "select rtrim(lab_number) lab_number from ms_cast_test_sample where lab_number like '" & a & "' order by lab_number"
                da.Fill(ds)
                Dim rowCnt As Integer = 0
                If ds.Tables(0).Rows.Count > 0 Then
                    For rowCnt = 0 To ds.Tables(0).Rows.Count - 1
                        i = i + 1
                        b = ds.Tables(0).Rows(rowCnt)(0)
                        cnt = b.Substring(3)
                        If cnt < precnt Then
                            cnt = precnt
                        End If
                        precnt = cnt
                        If i = 1 Then
                            b = ds.Tables(0).Rows(rowCnt)(0)
                            cnt = b.Substring(3)
                            precnt = cnt
                        End If
                    Next
                End If
                a = a.Replace("%", "/")
                If i = 0 Then
                    generateLabNumber = a & "1"
                Else
                    cnt = cnt + 1
                    generateLabNumber = a & cnt
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function CheckDesc(ByVal Wh As Long, ByVal Ht As Long, ByVal Des As String, ByVal TestType As String) As String
            Dim oCmd As New SqlClient.SqlCommand()
            oCmd.Connection = rwfGen.Connection.ConObj
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Parameters.Add("@Description", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                oCmd.CommandText = " SELECT @Description = description FROM mm_wheel WHERE wheel_number = " & Wh & " and heat_number = " & Ht & "" & _
                                " select  @cnt = count(*) from mm_wheel a where ((a.location = 'mopo' and a.status like 'x%') or ((a.location in ('clmt', 'clqc', 'clfq')  and a.status like 'XC%' and a.status not like 'XC8%' ) or ( a.location = 'clfi' and a.status like 'r%'))) " & _
                                " and a.heat_number = " & Val(Ht) & " and a.wheel_number = " & Val(Wh) & " "
                oCmd.ExecuteScalar()
                Dim ChangeDesc As String = IIf(IsDBNull(oCmd.Parameters("@Description").Value), "", oCmd.Parameters("@Description").Value)
                If Not ChangeDesc.Trim = Des.Trim Then
                    Throw New Exception("Wheel Description mismatch !")
                ElseIf TestType = "Regular" Then
                    If IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value) = 0 Then
                        Throw New Exception(" Wheel No: " & Val(Wh) & " and Heat number: " & Val(Ht) & " is Invalid !")
                    Else
                        CheckDesc = ChangeDesc
                    End If
                Else
                    CheckDesc = ChangeDesc
                End If
            Catch exp As Exception
                CheckDesc = ""
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End Try
        End Function
        Public Shared Function getCasttestPhysical(ByVal LabNo As String) As DataTable
            Dim ds As New DataSet()
            Dim da As New SqlClient.SqlDataAdapter()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.CommandText = " SELECT * FROM ms_casttest_physical " & _
                    " WHERE lab_number = @LabNo "
                da.SelectCommand.Parameters.Add("@LabNo", SqlDbType.VarChar, 50).Value = LabNo
                da.Fill(ds)
                getCasttestPhysical = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function ShowAxleValues(ByVal LabNo As String) As DataTable
            Dim ds As New DataSet()
            Dim da As New SqlClient.SqlDataAdapter()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.CommandText = " select lab_number ,  carbon , phosphorus , " & _
                    " manganese ,  sulphur , silicon , chromium , " & _
                    " nickle , copper ,  vanadium , molybdenum , phosphorus_sulphur  " & _
                    " from  ms_casttest_chemical where lab_number = @LabNo "
                da.SelectCommand.Parameters.Add("@LabNo", SqlDbType.VarChar, 50).Value = LabNo
                da.Fill(ds)
                ShowAxleValues = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function getCastDetails(ByVal CastNo As String) As DataTable
            Dim ds As New DataSet()
            Dim da As New SqlClient.SqlDataAdapter()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.CommandText = " SELECT 'Result = ' + rtrim(isnull(result,'')) + " & _
                    " ', Lab Number = ' + Rtrim(lab_number) + ', Drawing Number = ' + rtrim(drawing_number) + " & _
                    " ', Cast Group = ' + rtrim(cast_group)+' Test Date = '+convert(varchar(10),test_date,103)" & _
                    " FROM ms_cast_test_sample " & _
                    " WHERE cast_number = @CastNo " & _
                    " and lab_number = ( SELECT MAX(lab_number) FROM ms_cast_test_sample " & _
                    " WHERE cast_number = @CastNo and test_date is not null) "
                da.SelectCommand.Parameters.Add("@CastNo", SqlDbType.VarChar, 50).Value = CastNo
                da.Fill(ds)
                getCastDetails = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function getLabNoDetails(ByVal LabNo As String) As DataTable
            Dim ds As New DataSet()
            Dim da As New SqlClient.SqlDataAdapter()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.CommandText = "select  sent_date , cast_group , " & _
                    " rtrim(a.cast_number) cast_number , " & _
                    " rtrim(a.drawing_number) drawing_number , rtrim(billet_number) billet_number" & _
                    " from ms_cast_test_sample a inner join mm_axle_master b " & _
                    " on a.axle_number = b.axle_number and a.cast_number = b.cast_number " & _
                    " where lab_number = @LabNo "
                da.SelectCommand.Parameters.Add("@LabNo", SqlDbType.VarChar, 50).Value = LabNo
                da.Fill(ds)
                If ds.Tables(0).Rows.Count = 0 Then
                    da.SelectCommand.CommandText = "select  sent_date , a.cast_group , " & _
                            " rtrim(a.cast_number) cast_number , " & _
                            " rtrim(a.drawing_number) drawing_number " & _
                            " from ms_cast_test_sample a inner join mm_nonrwf_axles b " & _
                            " on a.axle_number = b.axle_number and a.cast_number = b.Customer_cast_Number " & _
                            " where lab_number = @LabNo "
                    da.Fill(ds)
                End If
                getLabNoDetails = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function getWheelNumbers() As DataTable
            Dim ds As New DataSet()
            Dim da As New SqlClient.SqlDataAdapter()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.CommandText = "select wheel_number, heat_number , " & _
                    " lab_number from ms_wheel_hardness_sample where " & _
                    " convert(varchar,convert(bigint,wheel_number))+'/'+ convert(varchar, heat_number)  " & _
                    " not in (select convert(varchar,wheel_number)+'/'+ convert(varchar, heat_number) " & _
                    " from ms_wheel_hardness_htdetails) " & _
                    " and sent_date >  dateadd(m , -3 , getdate())  "
                da.Fill(ds)
                getWheelNumbers = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function getAxleDetails(ByVal LabNumber As String, ByVal AxleNumber As String) As DataSet
            Dim da As New SqlClient.SqlDataAdapter()
            da.SelectCommand = rwfGen.Connection.CmdObj
            Dim ds As New DataSet()
            Try
                da.SelectCommand.CommandText = "select sent_date , cast_group , cast_number , " & _
                    " drawing_number ,  result from ms_cast_test_sample " & _
                    " where lab_number = '" & LabNumber & "' ; " & _
                    " select cast_number , billet_number from mm_axle_master " & _
                    " where axle_number = '" & AxleNumber & "'"
                da.Fill(ds)
                getAxleDetails = ds.Copy
            Catch exp As Exception
                getAxleDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function getLab_numbers(ByVal Mode As String) As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            da.SelectCommand = rwfGen.Connection.CmdObj
            Dim ds As New DataSet()
            Try
                If Mode.Equals("add") Then
                    da.SelectCommand.CommandText = "select a.axle_number, a.lab_number from ms_cast_test_sample a " & _
                    " left outer join mm_Nonrwf_Axles_CertificateBasedCastResults b " & _
                    " on a.lab_number = b.lab_number where  a.lab_number not in (select lab_number from ms_casttest_physical) " & _
                    " and isnull(a.result,'') = '' and a.sent_date >= '2016-04-01' " 'and b.lab_number is null
                Else
                    da.SelectCommand.CommandText = "select a.axle_number, a.lab_number from ms_cast_test_sample a " & _
                    " left outer join ms_casttest_physical b  on a.lab_number = b.lab_number " & _
                    " left outer join mm_Nonrwf_Axles_CertificateBasedCastResults c " & _
                    " on a.lab_number = c.lab_number where  c.ritesreference is null and a.sent_date >= '2016-04-01' "
                End If
                da.Fill(ds)
                getLab_numbers = ds.Tables(0)
            Catch exp As Exception
                getLab_numbers = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function SandTestResults(ByVal FromDate As Date, ByVal ToDate As Date) As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            da.SelectCommand = rwfGen.Connection.CmdObj
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@FrDt", SqlDbType.SmallDateTime, 4).Value = FromDate
                da.SelectCommand.Parameters.Add("@ToDt", SqlDbType.SmallDateTime, 4).Value = ToDate
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.CommandText = "ms_sp_SandTestResults"
                da.Fill(ds)
                SandTestResults = ds.Tables(0)
            Catch exp As Exception
                SandTestResults = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function DateWiseReport(ByVal FrDt As Date, ByVal ToDt As Date, ByVal lab_code As Integer) As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            da.SelectCommand = rwfGen.Connection.CmdObj
            Dim ds As New DataSet()
            Try
                da.SelectCommand.Parameters.Add("@FrDt", SqlDbType.SmallDateTime, 4).Value = FrDt
                da.SelectCommand.Parameters.Add("@ToDt", SqlDbType.SmallDateTime, 4).Value = ToDt
                da.SelectCommand.Parameters.Add("@lab_code", SqlDbType.Int, 4).Value = lab_code
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.CommandText = "ms_sp_DateWiseLabResults"
                da.Fill(ds)
                DateWiseReport = ds.Tables(0)
            Catch exp As Exception
                DateWiseReport = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function NewResults(ByVal dtFrom As Date, ByVal dtTo As Date, ByVal str As Integer) As DataTable
            Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            'If str = 10003 Then
            '    da.SelectCommand.CommandText = "select convert(varchar(11),test_date,103) test_date , a.lab_number , b.Material , " & _
            '    " sample_batch_number , lorry_number  , supplier ," & _
            '    " CaO = ( select e.result_value from ms_test_sample x inner join ms_vw_MaterialList b" & _
            '    " on lab_code = b.MaterialID inner join ms_vw_MaterialCharacteristics d  " & _
            '    " on b.MaterialID = d.MaterialID inner join ms_test_result e" & _
            '    " on e.lab_number = a.lab_number  and CharID = characteristic_code " & _
            '    " where x.lab_number = a.lab_number and CharName = 'CaO' ) ," & _
            '    " SiO2 = ( select e.result_value from ms_test_sample x inner join ms_vw_MaterialList b" & _
            '    " on lab_code = b.MaterialID inner join ms_vw_MaterialCharacteristics d  " & _
            '    " on b.MaterialID = d.MaterialID inner join ms_test_result e" & _
            '    " on e.lab_number = a.lab_number  and CharID = characteristic_code " & _
            '    " where x.lab_number = a.lab_number and CharName = 'SiO2' ) ," & _
            '    " LOI = ( select e.result_value from ms_test_sample x inner join ms_vw_MaterialList b" & _
            '    " on lab_code = b.MaterialID inner join ms_vw_MaterialCharacteristics d  " & _
            '    " on b.MaterialID = d.MaterialID inner join ms_test_result e" & _
            '    " on e.lab_number = a.lab_number  and CharID = characteristic_code " & _
            '    " where x.lab_number = a.lab_number and CharName = 'Loss On Ignition' ) ," & _
            '    " Sulphur = ( select e.result_value from ms_test_sample x inner join ms_vw_MaterialList b" & _
            '    " on lab_code = b.MaterialID inner join ms_vw_MaterialCharacteristics d  " & _
            '    " on b.MaterialID = d.MaterialID inner join ms_test_result e" & _
            '    " on e.lab_number = a.lab_number  and CharID = characteristic_code " & _
            '    " where x.lab_number = a.lab_number and CharName = 'Total Sulphur' )" & _
            '    " , Results , convert(varchar(10),result_date,103) ResultDt " & _
            '    " from ms_test_sample a inner join ms_vw_MaterialListCharName b on lab_code = b.MaterialID " & _
            '    " where test_date between @frDate and @toDate and lab_code = 10003 order by supplier , test_date , a.lab_number "
            'ElseIf str = 10002 Then
            '    da.SelectCommand.CommandText = "select convert(varchar(11),test_date,103) test_date , a.lab_number , b.Material , " & _
            '    " sample_batch_number , lorry_number  , supplier ," & _
            '    " GFN = ( select e.result_value from ms_test_sample x inner join ms_vw_MaterialList b" & _
            '    " on lab_code = b.MaterialID inner join ms_vw_MaterialCharacteristics d  " & _
            '    " on b.MaterialID = d.MaterialID inner join ms_test_result e" & _
            '    " on e.lab_number = a.lab_number  and CharID = characteristic_code " & _
            '    " where x.lab_number = a.lab_number and CharName = 'GFN' ) ," & _
            '    " Sieve3Rtn = ( select e.result_value from ms_test_sample x inner join ms_vw_MaterialList b" & _
            '    " on lab_code = b.MaterialID inner join ms_vw_MaterialCharacteristics d  " & _
            '    " on b.MaterialID = d.MaterialID inner join ms_test_result e" & _
            '    " on e.lab_number = a.lab_number  and CharID = characteristic_code " & _
            '    " where x.lab_number = a.lab_number and CharName = '3 SIEVE RETENTION(40+50+70)' ) ," & _
            '    " RtnOn30 = ( select e.result_value from ms_test_sample x inner join ms_vw_MaterialList b" & _
            '    " on lab_code = b.MaterialID inner join ms_vw_MaterialCharacteristics d  " & _
            '    " on b.MaterialID = d.MaterialID inner join ms_test_result e" & _
            '    " on e.lab_number = a.lab_number  and CharID = characteristic_code " & _
            '    " where x.lab_number = a.lab_number and CharName = 'RETENTION ON ASTM 30' ) " & _
            '    " , Results , convert(varchar(10),result_date,103) ResultDt " & _
            '    " from ms_test_sample a inner join ms_vw_MaterialListCharName b on lab_code = b.MaterialID " & _
            '    " where test_date between @frDate and @toDate and lab_code = 10002 order by supplier , test_date , a.lab_number "
            'Else
            '    da.SelectCommand.CommandText = "  select row_number() over ( order by Supplier , a.lab_number ) SlNo ," & _
            '        " convert(varchar(11),test_date,103) TestDate , a.lab_number LabNo , " & _
            '        " Material TestName, sample_batch_number SBNo , dbr_number  DBRno ,  " & _
            '        " sample_number SNo , lorry_number LorryNo ,  idn_number IDNNo  , supplier   ,  " & _
            '        " tested_by TestedBy , reference_note Ref , CharName , result_value CharValue , Unit , " & _
            '        " Results , convert(varchar(10),result_date,103) ResultDt " & _
            '        " from ms_test_sample a inner join ms_vw_LabTestValues b on lab_code = b.MaterialID " & _
            '        " and a.lab_number = b.lab_number " & _
            '        " where test_date between @frDate and @toDate   " & _
            '        " and b.MaterialID = @MaterialID " & _
            '        " order by Supplier , a.lab_number "
            'End If
            da.SelectCommand.CommandText = "ms_sp_ChemicalTestSamples"
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.Add("@frDt", SqlDbType.SmallDateTime, 4).Value = dtFrom
            da.SelectCommand.Parameters.Add("@toDt", SqlDbType.SmallDateTime, 4).Value = dtTo
            da.SelectCommand.Parameters.Add("@str", SqlDbType.Int, 4).Value = str
            Try
                da.Fill(ds)
                NewResults = ds.Tables(0).Copy
            Catch exp As Exception
                NewResults = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function OldResults(ByVal dtFrom As Date, ByVal dtTo As Date, ByVal str As String)
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            da.SelectCommand = rwfGen.Connection.CmdObj
            da.SelectCommand.CommandText = "ms_sp_ChemicalTestSamplesOld"
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.Add("@FrDt", SqlDbType.SmallDateTime, 4).Value = dtFrom
            da.SelectCommand.Parameters.Add("@ToDt", SqlDbType.SmallDateTime, 4).Value = dtTo
            da.SelectCommand.Parameters.Add("@str", SqlDbType.VarChar, 250).Value = str
            'da.SelectCommand.Parameters.Add("@dtFrom", SqlDbType.SmallDateTime, 4).Value = dtFrom
            'da.SelectCommand.Parameters.Add("@dtTo", SqlDbType.SmallDateTime, 4).Value = dtTo
            'If str = "CALCINED LIME/ BURNT LIME" Then
            '    da.SelectCommand.CommandText = " select rtrim(ms_vw_test_sample.supplier)   supplier , " & _
            '    " convert(varchar(11),ms_vw_test_sample.test_date,103)  TestDt   , replace(ms_vw_test_sample.lab_number,'/','\') lab_number  ,     ms_vw_test_sample.test_name  , " & _
            '    " ms_vw_test_sample.sample_batch_number  ,  ms_vw_test_sample.lorry_number  ,   " & _
            '    " Cao = ( select b.result_value from wap.dbo.ms_vw_si_test_characteristics a inner join  wap.dbo.ms_test_result  b " & _
            '    " on a.characteristic_code = b.characteristic_code inner join ms_vw_test_sample c  " & _
            '    " on  b.lab_number = c.lab_number and a.test_code = c.test_code " & _
            '    " where c.lab_number = ms_vw_test_sample.lab_number and b.characteristic_code = '1' ) , " & _
            '    " SiO2 = ( select b.result_value from wap.dbo.ms_vw_si_test_characteristics a inner join  wap.dbo.ms_test_result  b " & _
            '    " on a.characteristic_code = b.characteristic_code inner join ms_vw_test_sample c  " & _
            '    " on  b.lab_number = c.lab_number and a.test_code = c.test_code " & _
            '    " where c.lab_number = ms_vw_test_sample.lab_number and b.characteristic_code = '2' ) , " & _
            '    " LoI = ( select b.result_value from wap.dbo.ms_vw_si_test_characteristics a inner join  wap.dbo.ms_test_result  b " & _
            '    " on a.characteristic_code = b.characteristic_code inner join ms_vw_test_sample c  " & _
            '    " on  b.lab_number = c.lab_number and a.test_code = c.test_code " & _
            '    " where c.lab_number = ms_vw_test_sample.lab_number and b.characteristic_code = '3' ) ,  " & _
            '    " Sulphur = ( select b.result_value from wap.dbo.ms_vw_si_test_characteristics a inner join  wap.dbo.ms_test_result  b  " & _
            '    " on a.characteristic_code = b.characteristic_code inner join ms_vw_test_sample c  " & _
            '    " on  b.lab_number = c.lab_number and a.test_code = c.test_code " & _
            '    " where c.lab_number = ms_vw_test_sample.lab_number and b.characteristic_code = '4' ) " & _
            '    " from ms_vw_test_sample  " & _
            '    " where test_date between @dtFrom  and @dtTo  " & _
            '    " AND test_name = 'CALCINED LIME/ BURNT LIME' order by ms_test_sample.supplier , ms_vw_test_sample.test_date  , ms_vw_test_sample.lab_number "
            'ElseIf str = "SILICA SAND 45 AFS" Then
            '    da.SelectCommand.CommandText = " select  rtrim(ms_vw_test_sample.supplier)   supplier  , " & _
            '        " convert(varchar(11),ms_vw_test_sample.test_date,103)  TestDt   , replace(ms_vw_test_sample.lab_number,'/','\') lab_number  ,     ms_vw_test_sample.test_name  , " & _
            '        " ms_vw_test_sample.sample_batch_number  ,  ms_vw_test_sample.lorry_number  , " & _
            '        " GFN = ( select b.result_value from wap.dbo.ms_vw_si_test_characteristics a inner join  wap.dbo.ms_test_result  b " & _
            '        " on a.characteristic_code = b.characteristic_code inner join ms_vw_test_sample c  " & _
            '        " on  b.lab_number = c.lab_number and a.test_code = c.test_code " & _
            '        " where c.lab_number = ms_vw_test_sample.lab_number and b.characteristic_code = '3' ) , " & _
            '        " Sieve3Rtn = ( select b.result_value from wap.dbo.ms_vw_si_test_characteristics a inner join  wap.dbo.ms_test_result  b " & _
            '        " on a.characteristic_code = b.characteristic_code inner join ms_vw_test_sample c  " & _
            '        " on  b.lab_number = c.lab_number and a.test_code = c.test_code " & _
            '        " where c.lab_number = ms_vw_test_sample.lab_number and b.characteristic_code = '4' ) , " & _
            '        " RtnOn30 = ( select b.result_value from wap.dbo.ms_vw_si_test_characteristics a inner join  wap.dbo.ms_test_result  b " & _
            '        " on a.characteristic_code = b.characteristic_code inner join ms_vw_test_sample c  " & _
            '        " on  b.lab_number = c.lab_number and a.test_code = c.test_code " & _
            '        " where c.lab_number = ms_vw_test_sample.lab_number and b.characteristic_code = '5' )   " & _
            '        " from ms_vw_test_sample  " & _
            '        " where test_date between @dtFrom  and @dtTo " & _
            '        " AND test_name = 'SILICA SAND 45 AFS' order by ms_test_sample.supplier , ms_vw_test_sample.test_date  , ms_vw_test_sample.lab_number "
            'Else
            '    If str = "ALL" Then
            '        da.SelectCommand.CommandText = "     declare @Table table  (  SlNo int IDENTITY (1 , 1) ,  TestDate  varchar(11) , LabNo varchar(50) , TestName varchar(500) , SBNo varchar(50) , " & _
            '            "    DBRno varchar(50) , SNo varchar(50) , LorryNo varchar(50) , IDNNo  varchar(50) , Supplier  varchar(100) , TestedBy varchar(50) , Ref varchar(500)  ) " & _
            '            "    insert into @table " & _
            '            "    SELECT   convert(varchar(11),ms_test_sample.test_date,103)  test_date  , replace(ms_test_sample.lab_number,'/','\') lab_number  ,     ms_test_directory.test_name  ,  " & _
            '            "    ms_test_sample.sample_batch_number  ,   ms_test_sample.dbr_number  ,  ms_test_sample.sample_number  , ms_test_sample.lorry_number  ,    " & _
            '            "    ms_test_sample.idn_number  ,      ms_test_sample.supplier  ,       ms_test_sample.tested_by   , ms_test_sample.reference_note    " & _
            '            "    FROM  wap.dbo.ms_test_sample ms_test_sample,  " & _
            '            "    wap.dbo.ms_test_directory ms_test_directory  " & _
            '            "    WHERE ms_test_sample.test_code = ms_test_directory.test_code AND  " & _
            '            "    ms_test_sample.test_date between @dtFrom  and @dtTo  " & _
            '            "    ORDER BY  ms_test_sample.test_date ASC ,  " & _
            '            "    ms_test_sample.lab_number ASC  , ms_test_directory.test_name asc " & _
            '            "    select * from @Table ORDER BY   Supplier   , LabNo  ASC   "
            '    Else
            '        da.SelectCommand.CommandText = "    declare @Table table  (  SlNo int IDENTITY (1 , 1) ,  TestDate  varchar(11) , LabNo varchar(50) , TestName varchar(500) , SBNo varchar(50) , " & _
            '            "    DBRno varchar(50) , SNo varchar(50) , LorryNo varchar(50) , IDNNo  varchar(50) , Supplier  varchar(100) , TestedBy varchar(50) , Ref varchar(500)  ) " & _
            '            "    insert into @table " & _
            '            "    SELECT  convert(varchar(11),ms_test_sample.test_date,103)  test_date   , replace(ms_test_sample.lab_number,'/','\') lab_number  ,     ms_test_directory.test_name  ,  " & _
            '            "    ms_test_sample.sample_batch_number  ,   ms_test_sample.dbr_number  ,  ms_test_sample.sample_number  , ms_test_sample.lorry_number  ,    " & _
            '            "    ms_test_sample.idn_number  ,      ms_test_sample.supplier  ,       ms_test_sample.tested_by   , ms_test_sample.reference_note      " & _
            '            "    FROM  wap.dbo.ms_test_sample ms_test_sample,  " & _
            '            "    wap.dbo.ms_test_directory ms_test_directory  " & _
            '            "    WHERE ms_test_sample.test_code = ms_test_directory.test_code AND  " & _
            '            "    ms_test_sample.test_date between @dtFrom  and @dtTo AND  " & _
            '            "    ms_test_directory.test_name = '" & str.Trim & "'  " & _
            '            "    ORDER BY  ms_test_sample.test_date ASC,  " & _
            '            "    ms_test_sample.lab_number ASC , ms_test_directory.test_name asc  " & _
            '            "    select * from @Table ORDER BY   Supplier   , LabNo  ASC "
            '    End If
            'End If

            Try
                da.Fill(ds)
                OldResults = ds.Tables(0)
            Catch exp As Exception
                OldResults = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
            End Try
        End Function
        Public Shared Function test_name() As DataSet
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.CommandText = " select distinct test_name FROM " & _
                            " wap.dbo.ms_test_directory ; " & _
                            " select Material , MaterialID from  ms_vw_MaterialList order by Material"
                da.Fill(ds)
                test_name = ds.Copy
            Catch exp As Exception
                test_name = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function SandSamples(ByVal sand_date As Date, Optional ByVal BatchNo As String = "") As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                If BatchNo.Trim.Length = 0 Then
                    da.SelectCommand.CommandText = "select convert(varchar(10),sand_date,103) SentDate , " & _
                        " shift_code Sh , sample_batch_number Batch ," & _
                        " sample_cts CTS , sample_hts HTS , sample_stick_point SP , test_status Results" & _
                        " from mm_sand_system where sand_date = @sand_date order by sand_date , shift_code , sample_batch_number "
                Else
                    da.SelectCommand.CommandText = "select convert(varchar(10),sand_date,103) SentDate , " & _
                        " shift_code Sh , sample_batch_number Batch ," & _
                        " sample_cts CTS , sample_hts HTS , sample_stick_point SP , test_status Results" & _
                        " from mm_sand_system where sand_date = @sand_date and sample_batch_number = @BatchNo "
                    da.SelectCommand.Parameters.Add("@BatchNo", SqlDbType.VarChar, 50).Value = BatchNo
                End If
                da.SelectCommand.Parameters.Add("@sand_date", SqlDbType.SmallDateTime, 4).Value = sand_date
                da.Fill(ds)
                SandSamples = ds.Tables(0)
            Catch exp As Exception
                SandSamples = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function DailySamples(ByVal From As Date, ByVal ToDate As Date) As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.CommandText = "ms_sp_TestSampleList"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.Add("@FrDt", SqlDbType.SmallDateTime, 4).Value = From
                da.SelectCommand.Parameters.Add("@ToDt", SqlDbType.SmallDateTime, 4).Value = ToDate
                da.Fill(ds)
                DailySamples = ds.Tables(0)
            Catch exp As Exception
                DailySamples = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function MaterialLabNumbers(ByVal MaterialID As Integer) As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.CommandText = "select lab_number from ms_test_sample where lab_code = " & MaterialID & " order by lab_number desc"
                da.Fill(ds)
                MaterialLabNumbers = ds.Tables(0)
            Catch exp As Exception
                MaterialLabNumbers = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function DBRDetails(ByVal dbr_number As String) As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.CommandText = " select  po_number , po_date , OrderQty po_qty , " & _
                    " dbr_number , dbr_date , DCNo , convert(varchar(10),InvoiceDt,103) DCDate , InvoiceQty DCQty ," & _
                    " DumpNo , VehicleNumber ,  RecQty , AccQty , SupplierName " & _
                    " from ms_vw_CalcinedLimeReceipts " & _
                    " where dbr_number = @dbr_number "
                da.SelectCommand.Parameters.Add("@dbr_number", SqlDbType.VarChar, 50).Value = dbr_number
                da.Fill(ds)
                DBRDetails = ds.Tables(0)
            Catch exp As Exception
                DBRDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function SandDBRDetails(ByVal dbr_number As String) As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.CommandText = " select  po_number , po_date , OrderQty po_qty , " & _
                    " dbr_number , dbr_date , DCNo , convert(varchar(10),InvoiceDt,103) DCDate , InvoiceQty DCQty ," & _
                    " DumpNo , VehicleNumber ,  RecQty , AccQty , SupplierName " & _
                    " from ms_vw_SilicaSand45AFSReceipts " & _
                    " where dbr_number = @dbr_number "
                da.SelectCommand.Parameters.Add("@dbr_number", SqlDbType.VarChar, 50).Value = dbr_number
                da.Fill(ds)
                SandDBRDetails = ds.Tables(0)
            Catch exp As Exception
                SandDBRDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function SandDBRList() As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.CommandText = " select top 8 dbr_number from ms_vw_SilicaSand45AFSReceipts " & _
                    " order by dbr_number desc"
                da.Fill(ds)
                SandDBRList = ds.Tables(0)
            Catch exp As Exception
                SandDBRList = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function DBRList() As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.CommandText = " select top 5 dbr_number from ms_vw_CalcinedLimeReceipts " & _
                    " order by dbr_number desc"
                da.Fill(ds)
                DBRList = ds.Tables(0)
            Catch exp As Exception
                DBRList = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function MaterialListGroup(ByVal GroupCode As String) As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.CommandText = " select MaterialID , Material  from ms_vw_MaterialListGroup " & _
                    " where GroupCode =  '" & GroupCode.Trim & "'"
                da.Fill(ds)
                MaterialListGroup = ds.Tables(0)
            Catch exp As Exception
                MaterialListGroup = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetTestID(ByVal MaterialID As Integer) As Integer
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.CommandText = " select @TestID = TestID from  ms_vw_MaterialList where MaterialID = @MaterialID  "
                da.SelectCommand.Parameters.Add("@MaterialID", SqlDbType.Int, 4).Value = MaterialID
                da.SelectCommand.Parameters.Add("@TestID", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                da.Fill(ds)
                GetTestID = da.SelectCommand.Parameters("@TestID").Value
            Catch exp As Exception
                GetTestID = ""
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetMaterialList() As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.CommandText = " select Material , MaterialID from  ms_vw_MaterialList " & _
                    " where Material not like 'hardnes%' order by Material "
                da.Fill(ds)
                GetMaterialList = ds.Tables(0)
            Catch exp As Exception
                GetMaterialList = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetHardnessMaterialList() As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.CommandText = " select replace(Material,'hardness','') Material , MaterialID from  ms_vw_MaterialList " & _
                    " where Material like 'hardnes%' order by Material "
                da.Fill(ds)
                GetHardnessMaterialList = ds.Tables(0)
            Catch exp As Exception
                GetHardnessMaterialList = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetCalcinedLimeData(ByVal dbr_number As String, ByVal Material As Integer) As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                If Material = 10003 Then
                    da.SelectCommand.CommandText = " select 'DBR No. '+dbr_number+' Dt: '+dbr_date dbr_number " & _
                        " , 'DC No: '+DCNo+'  Dt: '+DCDate sample_batch_number , 'M/s. '+SupplierName supplier " & _
                        " , VehicleNumber lorry_number " & _
                        " , 'Letter from CDMS/RB - I; NO.RWF/RB-I/CALCINNED LIME Dt :       '+replace(MaterialSpecification,'CALCINED LIME AS PER SPECIFICATION NO.' , 'Spec : ') reference_note " & _
                        " from ms_vw_CalcinedLimeReceipts " & _
                        " where dbr_number = @dbr_number "
                Else
                    da.SelectCommand.CommandText = " select 'DBR No. '+dbr_number+' Dt: '+dbr_date dbr_number " & _
                        " , 'DC No: '+DCNo+'  Dt: '+DCDate sample_batch_number , 'M/s. '+SupplierName supplier " & _
                        " , VehicleNumber lorry_number " & _
                        " , 'Letter from CDMS/RB - III; NO.RWF/RB-III/'+po_number+' Dt :       '+replace(MaterialSpecification,'SILICA SAND-45 AFS AS PER RWF SPECIFICATION NO.' , 'Spec : ') reference_note " & _
                        " from ms_vw_SilicaSand45AFSReceipts " & _
                        " where dbr_number = @dbr_number "
                End If

                da.SelectCommand.Parameters.Add("@dbr_number", SqlDbType.VarChar, 10).Value = dbr_number
                da.Fill(ds)
                GetCalcinedLimeData = ds.Tables(0)
            Catch exp As Exception
                GetCalcinedLimeData = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetSavedLabResults(ByVal LabNumber As String) As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.Parameters.Add("@LabNumber", SqlDbType.VarChar, 50).Value = LabNumber
                da.SelectCommand.CommandText = " select CharName , result_value , Unit , MinValue , MaxValue " & _
                    " from ms_test_result x inner join ms_test_sample a " & _
                    " on x.lab_number = a.lab_number inner join ms_vw_MaterialList b " & _
                    " on lab_code = MaterialID inner join pm_ItemMaster c  " & _
                    " on Material = pl_number inner join ms_vw_MaterialCharacteristics d " & _
                    " on c.MaterialID = d.MaterialID where lab_number = @LabNumber order by OrderBy "
                da.Fill(ds)
                GetSavedLabResults = ds.Tables(0)
            Catch exp As Exception
                GetSavedLabResults = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetTestMaterialListForEdit(ByVal LabNumber As String) As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.Parameters.Add("@LabNumber", SqlDbType.VarChar, 50).Value = LabNumber
                da.SelectCommand.CommandText = " select CharID , CharName , result_value , Unit , MinValue , MaxValue  , e.remarks" & _
                    " from ms_test_sample a inner join ms_vw_MaterialList b on lab_code = MaterialID   " & _
                    " inner join ms_vw_MaterialCharacteristics d  on b.MaterialID = d.MaterialID " & _
                    " left outer join ms_test_result e on e.lab_number = a.lab_number " & _
                    " and e.characteristic_code = CharID" & _
                    " where a.lab_number = @LabNumber order by OrderBy"
                da.Fill(ds)
                GetTestMaterialListForEdit = ds.Tables(0)
            Catch exp As Exception
                GetTestMaterialListForEdit = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetTestMaterialList(ByVal LabNumber As String) As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.Parameters.Add("@LabNumber", SqlDbType.VarChar, 50).Value = LabNumber
                da.SelectCommand.CommandText = " select CharID , CharName , Unit , MinValue , MaxValue , NominalValue " & _
                    " from ms_test_sample a inner join ms_vw_MaterialList b on lab_code = MaterialID  " & _
                    " inner join ms_vw_MaterialCharacteristics d " & _
                    " on b.MaterialID = d.MaterialID where lab_number = @LabNumber order by OrderBy "
                da.Fill(ds)
                GetTestMaterialList = ds.Tables(0)
            Catch exp As Exception
                GetTestMaterialList = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetLabNumbersDetails(ByVal lab_number As String) As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.CommandText = " select lab_number, remarks, idn_number, dbr_number, tested_by, test_code, sample_batch_number, " & _
                " sample_number, supplier, lorry_number, reference_note, user_id , BatchNo , result_date , results  , expected_test_date " & _
                " from ms_test_sample where lab_number = @lab_number  "
                da.SelectCommand.Parameters.Add("@lab_number", SqlDbType.VarChar, 20).Value = lab_number
                da.Fill(ds)
                GetLabNumbersDetails = ds.Tables(0)
            Catch exp As Exception
                GetLabNumbersDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetSavedLabNumbersForEdit() As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.CommandText = " select lab_number , ltrim(rtrim(lab_number)) + '--' + 'Testing of ' + ltrim(rtrim(Material)) Material " & _
                    " from ms_test_sample a inner join ms_vw_MaterialList b " & _
                    " on lab_code = MaterialID left outer join pm_ItemMaster c on b.pl_number = c.pl_number where lab_code > '10000' " & _
                    " order by lab_number desc "
                da.Fill(ds)
                GetSavedLabNumbersForEdit = ds.Tables(0)
            Catch exp As Exception
                GetSavedLabNumbersForEdit = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetSavedLabNumbers(ByVal test_date As Date) As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.CommandText = " select lab_number , 'Testing of ' + ltrim(rtrim(Material)) Material from ms_test_sample a inner join ms_vw_MaterialList b " & _
                    " on lab_code = MaterialID left outer join pm_ItemMaster c on b.pl_number = c.pl_number where lab_code > '10000' " & _
                    " and test_date =  @test_date order by lab_number desc "
                da.SelectCommand.Parameters.Add("@test_date", SqlDbType.SmallDateTime, 4).Value = test_date
                da.Fill(ds)
                GetSavedLabNumbers = ds.Tables(0)
            Catch exp As Exception
                GetSavedLabNumbers = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetMaterialListForChange(ByVal lab_number As String) As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.Parameters.Add("@LAB", SqlDbType.VarChar, 50).Value = lab_number
                da.SelectCommand.CommandText = " select TestID , MaterialID , TestType TestTypeDescription ,  " & _
                    " pl_number , Material , Spec from ms_vw_MaterialList" & _
                    " where MaterialID not in ( select MaterialID " & _
                    " from ms_vw_LabMaterialList where lab_number = @LAB )" & _
                    " order by Material "
                da.Fill(ds)
                GetMaterialListForChange = ds.Tables(0)
            Catch exp As Exception
                GetMaterialListForChange = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetLabNumbersForChange() As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.CommandText = " select lab_number , ltrim(rtrim(lab_number)) + '--' + 'Testing of ' + ltrim(rtrim(short_description)) Material " & _
                    " , test_date , right(lab_number,( len(ltrim(rtrim(lab_number)))-charindex('/',lab_number))) from ms_test_sample a inner join ms_vw_MaterialList b " & _
                    " on lab_code = MaterialID inner join pm_ItemMaster c on b.pl_number = c.pl_number where lab_code > '10000' " & _
                    " and lab_number not in ( select lab_number from ms_test_result ) " & _
                    " union " & _
                    " select lab_number , ltrim(rtrim(lab_number)) + '--' + 'Testing of ' + ltrim(rtrim(material))  Material  " & _
                    " , test_date , right(lab_number,( len(ltrim(rtrim(lab_number)))-charindex('/',lab_number))) from ms_test_sample a inner join ms_vw_MaterialList b   " & _
                    " on lab_code = MaterialID where lab_code > '10000'  and  " & _
                    " lab_number not in ( select lab_number from ms_test_result ) and b.pl_number is null  " & _
                    " order by lab_number , right(lab_number,( len(ltrim(rtrim(lab_number)))-charindex('/',lab_number))) desc "
                da.Fill(ds)
                GetLabNumbersForChange = ds.Tables(0)
            Catch exp As Exception
                GetLabNumbersForChange = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetLabNumbersForEdit() As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.CommandText = " select lab_number , ltrim(rtrim(lab_number)) + '--' + 'Testing of ' + ltrim(rtrim(short_description)) Material " & _
                    " , test_date , right(lab_number,( len(ltrim(rtrim(lab_number)))-charindex('/',lab_number))) from ms_test_sample a inner join ms_vw_MaterialList b " & _
                    " on lab_code = MaterialID inner join pm_ItemMaster c on b.pl_number = c.pl_number where lab_code > '10000' " & _
                    " and lab_number in ( select lab_number from ms_test_result ) " & _
                    " union " & _
                    " select lab_number , ltrim(rtrim(lab_number)) + '--' + 'Testing of ' + ltrim(rtrim(material))  Material  " & _
                    " , test_date , right(lab_number,( len(ltrim(rtrim(lab_number)))-charindex('/',lab_number))) " & _
                    " from ms_test_sample a inner join ms_vw_MaterialList b   " & _
                    " on lab_code = MaterialID where lab_code > '10000'  and  " & _
                    " lab_number in ( select lab_number from ms_test_result )   " & _
                    " order by lab_number desc , right(lab_number,( len(ltrim(rtrim(lab_number)))-charindex('/',lab_number))) desc "
                da.Fill(ds)
                GetLabNumbersForEdit = ds.Tables(0)
            Catch exp As Exception
                GetLabNumbersForEdit = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetLabNumbers() As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.CommandText = " select lab_number , 'Testing of ' + ltrim(rtrim(short_description)) + '--' + ltrim(rtrim(lab_number)) Material " & _
                    " , test_date , right(lab_number,( len(ltrim(rtrim(lab_number)))-charindex('/',lab_number))) from ms_test_sample a inner join ms_vw_MaterialList b " & _
                    " on lab_code = MaterialID inner join pm_ItemMaster c on b.pl_number = c.pl_number where lab_code > '10000' " & _
                    " and lab_number not in ( select lab_number from ms_test_result ) " & _
                    " union " & _
                    " select lab_number , 'Testing of ' + ltrim(rtrim(material)) + '--' + ltrim(rtrim(lab_number)) Material  " & _
                    " , test_date , right(lab_number,( len(ltrim(rtrim(lab_number)))-charindex('/',lab_number))) from ms_test_sample a inner join ms_vw_MaterialList b   " & _
                    " on lab_code = MaterialID where lab_code > '10000'  and  " & _
                    " lab_number not in ( select lab_number from ms_test_result ) " & _
                    " order by lab_number desc , right(lab_number,( len(ltrim(rtrim(lab_number)))-charindex('/',lab_number))) desc "
                da.Fill(ds)
                GetLabNumbers = ds.Tables(0)
            Catch exp As Exception
                GetLabNumbers = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetNumberDetails(ByVal Type As String, ByVal Number As String) As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                If Type = "IDN" Then
                    da.SelectCommand.CommandText = " select idn_number , convert(varchar(11),idn_date,103) Dt ,  " & _
                    " 'DBR No. '+dbr_number+' Dt: '+convert(varchar(11),dbr_date,103)  DBR ,  " & _
                    " 'DUMP LOC: '+dump_location DumpNo , 'Testing of '+ltrim(rtrim(short_description)) Sub ,  " & _
                    " 'Qty: '+convert(varchar,idn_quantity)+' '+ltrim(rtrim(UnitName))+' Spec: '+Spec Ref  " & _
                    " , '' SampleNo , '' Supplier , '' Lorry , TestID , MaterialID " & _
                    " from dm_DBRMasterAndDetails a inner join pm_ItemMaster b  " & _
                    " on a.pl_number = b.pl_number inner join ms_vw_MaterialList c " & _
                    " on Material = b.short_description where idn_number =  @Number "
                Else
                    da.SelectCommand.CommandText = ""
                End If
                da.SelectCommand.Parameters.Add("@Number", SqlDbType.VarChar, 20).Value = Number
                da.Fill(ds)
                GetNumberDetails = ds.Tables(0)
            Catch exp As Exception
                GetNumberDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetSavedLabNumber(ByVal TestDate As Date) As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.CommandText = " SELECT test_name, M.material_name FROM ms_test_sample as S, " & _
                    " ms_test_directory as T, ms_test_material as M WHERE S.test_code = T.test_code  " & _
                    " and M.material_code = T.material_code and test_date = @TestDate "

                da.SelectCommand.Parameters.Add("@TestDate", SqlDbType.SmallDateTime, 4).Value = TestDate
                da.Fill(ds)
                GetSavedLabNumber = ds.Tables(0)
            Catch exp As Exception
                GetSavedLabNumber = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetLabNumber(ByVal TestDate As Date) As String
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.CommandText = " if (select  count(*) from ms_test_sample where lab_number like @TestDate ) > 0  begin " & _
                " select @LabNumber = right('0000'+convert(varchar,max(convert(integer,substring(lab_number,4,4)))+1),4) " & _
                " from ms_test_sample where lab_number like @TestDate " & _
                " end else select  @LabNumber = '0001' "
                da.SelectCommand.Parameters.Add("@TestDate", SqlDbType.VarChar, 4).Value = Right(CStr(CDate(TestDate).Year), 2) + "/%"
                da.SelectCommand.Parameters.Add("@LabNumber", SqlDbType.VarChar, 10).Direction = ParameterDirection.Output
                da.Fill(ds)
                GetLabNumber = Right(CStr(CDate(TestDate).Year), 2) + "/" + da.SelectCommand.Parameters("@LabNumber").Value
            Catch exp As Exception
                GetLabNumber = ""
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetMaterialCharList(ByVal MaterialID As Long) As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.CommandText = " select ltrim(rtrim(CharName)) CharName  , Unit , MinValue , MaxValue  , NominalValue , " & _
                    " OrderBY , ltrim(rtrim(Remarks)) Remarks , MaterialID , CharID from ms_ChemicalTesting_MaterialCharacteristics " & _
                    " where MaterialID = @MaterialID order by OrderBY "

                da.SelectCommand.Parameters.Add("@MaterialID", SqlDbType.BigInt, 8).Value = MaterialID
                da.Fill(ds)
                GetMaterialCharList = ds.Tables(0)
            Catch exp As Exception
                GetMaterialCharList = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetMaterialList(ByVal TestType As Int16) As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                If TestType = 0 Or TestType = 1 Then
                    da.SelectCommand.CommandText = " select ltrim(rtrim(a.Material)) Material , ltrim(rtrim(short_description)) MaterialName , " & _
                    " ltrim(rtrim(Spec)) Spec , Remarks , TestType , MaterialID " & _
                    " from ms_ChemicalTesting_MaterialList a inner join pm_Item_Master b on b.pl_number = ltrim(rtrim(a.Material)) " & _
                    " where a.TestType = @TestType order by ltrim(rtrim(short_description)) "
                Else
                    da.SelectCommand.CommandText = " select ltrim(rtrim(a.Material)) Material , '' MaterialName , " & _
                    " ltrim(rtrim(Spec)) Spec , Remarks , TestType , MaterialID " & _
                    " from ms_ChemicalTesting_MaterialList a  where a.TestType = @TestType order by ltrim(rtrim(a.Material)) "
                End If
                da.SelectCommand.Parameters.Add("@TestType", SqlDbType.Int, 4).Value = TestType
                da.Fill(ds)
                GetMaterialList = ds.Tables(0)
            Catch exp As Exception
                GetMaterialList = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetPLDetails(ByVal Marerial As String, ByVal Based As Int16) As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                If Based = 0 Then
                    da.SelectCommand.CommandText = " select short_description, pl_number , unitName  from pm_ItemMaster where short_description like @Marerial order by short_description"
                Else
                    da.SelectCommand.CommandText = " select short_description, pl_number , unitName  from pm_ItemMaster where pl_number like @Marerial  order by short_description"
                End If
                da.SelectCommand.Parameters.Add("@Marerial", SqlDbType.VarChar, 60).Value = Marerial.Trim
                da.Fill(ds)
                GetPLDetails = ds.Tables(0)
            Catch exp As Exception
                GetPLDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetChemicalMaterialData(ByVal Marerial As String) As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.Parameters.Add("@Marerial", SqlDbType.VarChar, 50).Value = Marerial.Trim
                da.SelectCommand.CommandText = " select pl_number , short_description , unitName  from pm_ItemMaster where pl_number = @Marerial "
                da.Fill(ds)
                GetChemicalMaterialData = ds.Tables(0)
            Catch exp As Exception
                GetChemicalMaterialData = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetChemicalTestingTestType() As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.CommandText = " select TestType , TestID from ms_ChemicalTesting_TestType "
                da.Fill(ds)
                GetChemicalTestingTestType = ds.Tables(0)
            Catch exp As Exception
                GetChemicalTestingTestType = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetCaliData(ByVal EquipID As Long) As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.CommandText = " select Instrument , Identification , CalibrationDueDate , CalibrationDoneDate , Remarks from ms_MLabEquipments a inner join ms_MLabEquipments_Calibration b " & _
                                        " on a.EquipID = b.EquipID where a.EquipID = @EquipID "
                da.SelectCommand.Parameters.Add("EquipID", SqlDbType.BigInt, 8).Value = EquipID
                da.Fill(ds)
                GetCaliData = ds.Tables(0)
            Catch exp As Exception
                GetCaliData = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetInstruments() As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()

            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.CommandText = " select ltrim(rtrim(Instrument))+'--'+ltrim(rtrim(Identification)) Instrument , EquipID  from ms_MLabEquipments "
                da.Fill(ds)
                GetInstruments = ds.Tables(0)
            Catch exp As Exception
                GetInstruments = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetData(ByVal Instrument As String, ByVal Identification As String) As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.CommandText = " select * from ms_MLabEquipments " & _
                                   " where  Instrument = @Instrument and Identification = @Identification "
                da.SelectCommand.Parameters.Add("@Instrument", SqlDbType.VarChar, 250).Value = Instrument.Trim
                da.SelectCommand.Parameters.Add("@Identification", SqlDbType.VarChar, 50).Value = Identification.Trim
                da.Fill(ds)
                GetData = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetClosureData(ByVal Whl As Long, ByVal Ht As Long) As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.Parameters.Add("@wheel_number", SqlDbType.BigInt, 8).Value = Whl
                da.SelectCommand.Parameters.Add("@heat_number", SqlDbType.BigInt, 8).Value = Ht
                da.SelectCommand.CommandText = "SELECT * FROM ms_wheel_hardness_sample WHERE wheel_number = @wheel_number AND heat_number = @heat_number "
                da.Fill(ds)
                GetClosureData = ds.Tables(0).Copy
            Catch exp As Exception
                GetClosureData = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function fillClosureData(ByVal Whl As Long, ByVal Ht As Long) As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.Parameters.Add("@wheel_number", SqlDbType.BigInt, 8).Value = Whl
                da.SelectCommand.Parameters.Add("@heat_number", SqlDbType.BigInt, 8).Value = Ht
                da.SelectCommand.CommandText = " select date_received , report_date , " & _
                    " convert(decimal(7,3),intial_guage) intial_guage , convert(decimal(7,3),final_guage) final_guage , " & _
                    " convert(decimal(7,3),closure_value) closure_value , remarks , drawing_no , lab_number , test_type " & _
                    " from mm_closuretest_details a inner join ms_wheel_hardness_sample b " & _
                    " on b.wheel_number = convert(varchar,a.wheel_number) and b.heat_number = a.heat_number " & _
                    " WHERE a.wheel_number = @wheel_number AND a.heat_number = @heat_number "
                da.Fill(ds)
                fillClosureData = ds.Tables(0).Copy
            Catch exp As Exception
                fillClosureData = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetClosureWheels() As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.CommandText = "SELECT whlno , Lab_number " & _
                    " FROM ms_vw_hardness_sample  " & _
                    " where whlno not in (  " & _
                    " select whlno from mm_vw_closuretest_details )  "
                da.Fill(ds)
                GetClosureWheels = ds.Tables(0).Copy
            Catch exp As Exception
                GetClosureWheels = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetHardnessValues(ByVal Whl As Long, ByVal Ht As Long, ByVal Wheel As String) As DataSet
            Dim ds As New DataSet()
            Dim da As New SqlClient.SqlDataAdapter()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.CommandText = "select * from ms_wheel_hardness_physical a inner join ms_wheel_hardness_sample b on a.lab_number = b.lab_number " & _
                        " where b.wheel_number = '" & Whl & "' and b.heat_number = " & Ht & " and b.wheel = '" & Wheel & "' ; " & _
                        " select * from ms_wheel_hardness_details a inner join ms_wheel_hardness_sample b on a.lab_number = b.lab_number where b.wheel_number = '" & Whl & "' and b.heat_number = " & Ht & " and b.wheel = '" & Wheel & "' ; " & _
                        " select * from ms_wheel_hardness_inclusion_details a inner join ms_wheel_hardness_sample b on a.lab_number = b.lab_number where b.wheel_number = '" & Whl & "' and b.heat_number = " & Ht & " and b.wheel = '" & Wheel & "' ;  "
                da.Fill(ds)
                GetHardnessValues = ds.Copy
            Catch exp As Exception
                GetHardnessValues = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetSampleHeatRanges(ByVal test_type As String, ByVal wheel_type As String, ByVal Nos As String) As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                If Nos.Trim.ToLower = "all" Then
                    da.SelectCommand.CommandText = " select lab_number LabNo , wheel_number Whl , " & _
                           " heat_number Heat , convert(varchar(11),sent_date,103) SentDt , " & _
                           " heat_from HeatFr , heat_to HeatTo , test_type TestType , wheel_class WhlCl , wheel_type WhlType " & _
                           " from ms_vw_wheel_hardness_sample " & _
                           " where test_type = '" & test_type & "' and product_code = '" & wheel_type & "' " & _
                           " order by lab_code desc "
                Else
                    da.SelectCommand.CommandText = " select top 10 lab_number LabNo , wheel_number Whl , " & _
                            " heat_number Heat , convert(varchar(11),sent_date,103) SentDt , " & _
                            " heat_from HeatFr , heat_to HeatTo , test_type TestType , wheel_class WhlCl , wheel_type WhlType " & _
                            " from ms_vw_wheel_hardness_sample " & _
                            " where test_type = '" & test_type & "' and product_code = '" & wheel_type & "' " & _
                            " order by lab_code desc "
                End If
                da.Fill(ds)
                GetSampleHeatRanges = ds.Tables(0).Copy
            Catch exp As Exception
                GetSampleHeatRanges = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetHTDetails(ByVal Whl As Long, ByVal Ht As Long) As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.Parameters.Add("@wheel_number", SqlDbType.BigInt, 8).Value = Whl
                da.SelectCommand.Parameters.Add("@heat_number", SqlDbType.BigInt, 8).Value = Ht
                da.SelectCommand.CommandText = " select lab_number , wheel_number , heat_number , NFChargeDate , NFChargeTime , " & _
                            " NFChargeCondition , NFDischargeTime , NFZone1 , NFZone2 , NFZone3 , NFZone4 , NFZone5 , NFZone6 , NFZone7 , " & _
                            " DFZone1 , DFZone2 , DFZone3 , DFZone4 , DFZone5 , DFZone6 , DFZone7 , DFZone8 , " & _
                            " QuencherNo , QTimeMin , QTimeSec , HC1Code , HC2Code , HC3Code , HC1 , HC2 , HC3 " & _
                            " from ms_wheel_hardness_htdetails where wheel_number = @wheel_number and heat_number = @heat_number  "
                da.Fill(ds)
                GetHTDetails = ds.Tables(0).Copy
            Catch exp As Exception
                GetHTDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetDDLValues() As DataSet
            Dim ds As New DataSet()
            Dim da As New SqlClient.SqlDataAdapter()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.CommandText = "select machine_code , machine_code from ms_machinery_master where machine_code like '%moquerq%' ; select machine_code , machine_code from ms_machinery_master where machine_code like '%MOCOOHC%' ; " & _
                        " select lab_number , convert(varchar,convert(bigint,wheel_number))+'/'+ convert(varchar, heat_number)  from ms_wheel_hardness_sample where " & _
                        " convert(varchar,convert(bigint,wheel_number))+'/'+ convert(varchar, heat_number)  not in (select convert(varchar,wheel_number)+'/'+ convert(varchar, heat_number) from ms_wheel_hardness_htdetails) " & _
                        " and sent_date >  dateadd(m , -7 , getdate()) order by heat_number , wheel_number "
                da.Fill(ds)
                GetDDLValues = ds.Copy
            Catch exp As Exception
                GetDDLValues = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetProdValues(ByVal Prod As String, ByVal lab_number As String) As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.Parameters.Add("@ddllab_number", SqlDbType.VarChar, 50).Value = lab_number.Trim
                If Prod.Equals("Wheel") Then
                    da.SelectCommand.CommandText = " select  a.carbon , a.phosphorus , a.manganese , a.sulphur , a.silicon , a.chromium , " & _
                                    " a.nickle , a.copper , a.vanadium , a.molybdenum , a.phosphorus_sulphur , a.alunimum , b.EmpCode , a.nitrogen , a.hydrogen " & _
                                    " from  ms_wheel_hardness_chemical a , ms_wheel_hardness_chemical_empcode b where  b.lab_number = a.lab_number and a.lab_number = @ddllab_number "
                Else
                    da.SelectCommand.CommandText = "  select  a.carbon , a.phosphorus , a.manganese , a.sulphur , a.silicon , a.chromium , " & _
                                    " a.nickle , a.copper , a.vanadium , a.molybdenum , a.phosphorus_sulphur ,  b.EmpCode , a.nitrogen  " & _
                                    " from  ms_casttest_chemical a , ms_casttest_chemical_empcode b where  b.lab_number = a.lab_number and a.lab_number = @ddllab_number "
                End If
                da.Fill(ds)
                GetProdValues = ds.Tables(0).Copy
            Catch exp As Exception
                GetProdValues = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetWheelNumbers(ByVal Mode As String) As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                If Mode.Equals("add") Then
                    da.SelectCommand.CommandText = "select (convert(varchar,a.wheel_number)+'/'+ convert(varchar,a.heat_number)) , a.lab_number  , b.description , a.wheel_class from ms_wheel_hardness_sample a , mm_wheel b where " & _
                                " convert(numeric,a.wheel_number) = b.wheel_number and a.heat_number = b.heat_number and a.lab_number not in (select lab_number from ms_wheel_hardness_chemical )  "
                Else
                    da.SelectCommand.CommandText = " select (convert(varchar,a.wheel_number)+'/'+ convert(varchar,a.heat_number)) , a.lab_number , b.description , a.wheel_class  from ms_wheel_hardness_sample a , mm_wheel b where " & _
                                " convert(numeric,a.wheel_number) = b.wheel_number and a.heat_number = b.heat_number and a.lab_number in (select lab_number from ms_wheel_hardness_chemical ) and a.sent_date >= dateadd(m,-3,getdate()) order by a.heat_number , a.wheel_number  "
                End If
                da.Fill(ds)
                GetWheelNumbers = ds.Tables(0).Copy
            Catch exp As Exception
                GetWheelNumbers = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetAxleNumbers(ByVal Mode As String) As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                If Mode.Equals("add") Then
                    da.SelectCommand.CommandText = " select axle_number , lab_number ,  remarks  from ms_cast_test_sample where ( lab_number not in (select lab_number from ms_casttest_chemical ) ) " & _
                            " and ( lab_number not in (select lab_number from mm_Nonrwf_Axles_CertificateBasedCastResults )) order by axle_number "
                Else
                    da.SelectCommand.CommandText = " select a.axle_number, a.lab_number , a.remarks  from ms_cast_test_sample a , ms_casttest_chemical b " & _
                            " where a.lab_number = b.lab_number  and a.sent_date >=  dateadd(m,-1,getdate())   order by a.axle_number "
                End If
                da.Fill(ds)
                GetAxleNumbers = ds.Tables(0).Copy
            Catch exp As Exception
                GetAxleNumbers = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetLabValues(ByVal LabNumber As String, ByVal mywheel As String, ByVal myheat As String) As DataSet
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.Parameters.Add("@LabNumber", SqlDbType.VarChar, 50).Value = LabNumber.Trim
                da.SelectCommand.CommandText = "SELECT CAST(intial_guage AS VARCHAR(10)), CAST(final_guage AS VARCHAR(10)), CAST(closure_value AS VARCHAR(10)) , closure_result " & _
                        " FROM mm_closuretest_details WHERE wheel_number='" & mywheel & "' AND heat_number='" & myheat & "' ; " & _
                        " SELECT sent_date , heat_from , heat_to , wheel , wheel_class , test_type from ms_wheel_hardness_sample where " & _
                        " wheel_number = '" & mywheel & "' AND heat_number = '" & myheat & "' ; " & _
                        " select pour_time , pouring_order , cope_used , drag_used , wheel_type " & _
                        " from mm_pouring where engraved_number = '" & mywheel & "' AND heat_number = '" & myheat & "' ; " & _
                        " select aluminium_dip_temperature , end_temperature from mm_post_pouring a inner join mm_pre_pouring b " & _
                        " on a.heat_number = b.heat_number where a.heat_number = '" & myheat & "' ; " & _
                        " select  carbon , phosphorus , manganese , sulphur , silicon , chromium , " & _
                        " nickle , copper , vanadium , molybdenum , phosphorus_sulphur , alunimum , nitrogen , hydrogen " & _
                        " from  ms_wheel_hardness_chemical where lab_number = '" & LabNumber.Trim & "' ; " & _
                        " select * from ms_wheel_hardness_values where lab_number = '" & LabNumber.Trim & "' ; " & _
                        " select lab_number , wheel_number , heat_number , NFChargeDate , NFChargeTime , " & _
                        " NFChargeCondition , NFDischargeTime , NFZone1 , NFZone2 , NFZone3 , NFZone4 , NFZone5 , NFZone6 , NFZone7 , " & _
                        " DFZone1 , DFZone2 , DFZone3 , DFZone4 , DFZone5 , DFZone6 , DFZone7 , DFZone8 , " & _
                        " QuencherNo , QTimeMin , QTimeSec , HC1Code , HC2Code , HC3Code , HC1 , HC2 , HC3 " & _
                        " from ms_wheel_hardness_htdetails where lab_number = '" & LabNumber.Trim & "' ;  "
                da.Fill(ds)
                GetLabValues = ds.Copy
            Catch exp As Exception
                GetLabValues = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetLabNumber() As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.CommandText = "select wheel , lab_number from ms_wheel_hardness_sample where test_type <> 'Experimental' and " & _
                          " lab_number not in (select lab_number from ms_wheel_hardness_details) "
                da.Fill(ds)
                GetLabNumber = ds.Tables(0).Copy
            Catch exp As Exception
                GetLabNumber = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetExpPhyLabNumber() As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.CommandText = "select wheel , lab_number from ms_wheel_hardness_sample where test_type = 'Experimental' " & _
                          " and lab_number not in (select lab_number from ms_wheel_hardness_physical) "
                da.Fill(ds)
                GetExpPhyLabNumber = ds.Tables(0).Copy
            Catch exp As Exception
                GetExpPhyLabNumber = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetExpResultsLabNumber() As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.CommandText = "select wheel , lab_number from ms_wheel_hardness_sample where test_type = 'Experimental' " & _
                          " and lab_number not in (select lab_number from ms_wheel_hardness_details) "
                da.Fill(ds)
                GetExpResultsLabNumber = ds.Tables(0).Copy
            Catch exp As Exception
                GetExpResultsLabNumber = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetHeatRangeValues(ByVal Wh As Long, ByVal Ht As Long, ByVal TestType As Integer) As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.CommandText = " select * from wap.dbo.ms_fn_GetHeatRangeValuesWithCheck(" & Wh & "," & Ht & "," & TestType & ") "
                da.Fill(ds)
                GetHeatRangeValues = ds.Tables(0).Copy
            Catch exp As Exception
                GetHeatRangeValues = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetLabDetails(ByVal LabNumber As String) As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.Parameters.Add("@LabNumber", SqlDbType.VarChar, 50).Value = LabNumber.Trim
                da.SelectCommand.CommandText = " select  *  from ms_wheel_hardness_sample where lab_number = @LabNumber ; "
                da.Fill(ds)
                GetLabDetails = ds.Tables(0).Copy
            Catch exp As Exception
                GetLabDetails = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetHeatValidity(ByVal myheat As Long) As Boolean
            Dim oCmd As New SqlClient.SqlCommand()
            oCmd.Connection = rwfGen.Connection.ConObj
            Try
                oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = "select @cnt = count(heat_number) from mm_wheel where heat_number = " & myheat
                oCmd.ExecuteScalar()
                GetHeatValidity = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), "0", oCmd.Parameters("@cnt").Value)
            Catch exp As Exception
                Throw New Exception("InValid Heat Number !" & exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End Try
        End Function
        Public Shared Function GetPrevious(ByVal TestYype As String, ByVal WheelType As String) As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                If TestYype.Trim = "Regular" Then
                    da.SelectCommand.CommandText = " select top 1 * from ms_vw_DistinctWheelTypeWithLabNumber where test_type = '" & TestYype.Trim & "' and description = '" & WheelType.Trim & "' order by sent_date desc "
                Else
                    da.SelectCommand.CommandText = " select top 1 * from ms_wheel_hardness_sample where test_type = '" & TestYype.Trim & "' and wheel_type = '" & WheelType.Trim & "' order by sent_date desc "
                End If
                da.Fill(ds)
                GetPrevious = ds.Tables(0).Copy
            Catch exp As Exception
                GetPrevious = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetScheduledSampleList(ByVal ProdCode As String) As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.CommandText = " select Top 1 b.description , b.product_code , a.heat_from , a.heat_to from ms_wheel_hardness_sample_schedule a inner join mm_product_master b " & _
                        " on b.product_code = a.product_code where lab_code = 0 and selected = 0 and a.product_code = '" & ProdCode.Trim & "'  order by a.heat_to desc"
                da.Fill(ds)
                GetScheduledSampleList = ds.Tables(0).Copy
            Catch exp As Exception
                GetScheduledSampleList = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetScheduledSamples() As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.CommandText = " select distinct c.description , a.product_code from ms_wheel_hardness_sample_schedule a " & _
                            " inner join mm_product_master c on a.product_code  = c.product_code " & _
                            " where lab_code = 0 and selected = 0 "
                da.Fill(ds)
                GetScheduledSamples = ds.Tables(0).Copy
            Catch exp As Exception
                GetScheduledSamples = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetWheelTypes() As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                'da.SelectCommand.CommandText = " select distinct drawing_no description , product_code from mm_closuretest_details a inner join mm_product_master b " & _
                '    " on b.description = a.drawing_no order by b.description"
                'da.SelectCommand.CommandText = " select distinct b.description , b.product_code from mm_vw_WheelMasterProdwise a inner join mm_product_master b " & _
                '" on a.ProdCode = b.product_code order by b.description "
                'da.SelectCommand.CommandText = " select  description , product_code from mm_vw_WheelMasterProdwiseNew order by description"
                da.SelectCommand.CommandText = " select  WheelType description , ProdCode product_code " & _
                    " from ms_vw_WheelHardnessSampleWheelType order by WheelType "
                da.Fill(ds)
                GetWheelTypes = ds.Tables(0).Copy
            Catch exp As Exception
                GetWheelTypes = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetXCWheels(ByVal FrHeat As Long, ByVal ToHeat As Long, ByVal wheel_type As String) As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.Parameters.Add("@FrHeat", SqlDbType.BigInt, 8).Value = FrHeat
                da.SelectCommand.Parameters.Add("@ToHeat", SqlDbType.BigInt, 8).Value = ToHeat
                da.SelectCommand.Parameters.Add("@Wheel_type", SqlDbType.VarChar, 50).Value = wheel_type.Trim
                da.SelectCommand.CommandText = " select rtrim(wheel_number)+'/'+ltrim(heat_number) wheel , location  from " & _
                  " ( select   wheel_number, heat_number, location, status , magnaglow_status from mm_wheel  " & _
                  " where heat_number between  @FrHeat and @ToHeat and  description = @Wheel_type  ) a  " & _
                  " where ( ( a.location <> 'mopo' and a.location <> 'clfi' and a.status not like 'XC8%' and a.status like 'xc%')  " & _
                  " or ( a.location = 'clfi' and a.status like 'r%') or ( a.location = 'clfq' and a.magnaglow_status like 'x%') or ( a.location = 'mopo' and a.status like 'x96%')) " & _
                  " and rtrim(wheel_number)+'/'+ltrim(heat_number) not in ( select wheel from ms_wheel_hardness_sample ) " & _
                  " order by heat_number , wheel_number  "
                da.Fill(ds)
                GetXCWheels = ds.Tables(0).Copy
            Catch exp As Exception
                GetXCWheels = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetGoodWheels(ByVal FrHeat As Long, ByVal ToHeat As Long, ByVal wheel_type As String) As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.Parameters.Add("@FrHeat", SqlDbType.BigInt, 8).Value = FrHeat
                da.SelectCommand.Parameters.Add("@ToHeat", SqlDbType.BigInt, 8).Value = ToHeat
                da.SelectCommand.Parameters.Add("@Wheel_type", SqlDbType.VarChar, 50).Value = wheel_type.Trim
                da.SelectCommand.CommandText = " select rtrim(wheel_number)+'/'+ltrim(heat_number) wheel , location  from " & _
                " ( select   wheel_number, heat_number, location, status , press_status , despatch_note_number from mm_wheel " & _
                " where heat_number between  @FrHeat and @ToHeat and  description = @Wheel_type  ) a " & _
                " where a.location <> 'mopo' and a.press_status is null and isnull(a.despatch_note_number,'') = ''  " & _
                " and rtrim(wheel_number)+'/'+ltrim(heat_number) not in ( select wheel from ms_wheel_hardness_sample ) " & _
                " order by heat_number , wheel_number "
                da.Fill(ds)
                GetGoodWheels = ds.Tables(0).Copy
            Catch exp As Exception
                GetGoodWheels = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetHeatRangeForHardnessTest(ByVal wheel_type As String, ByVal ForceRange As Integer) As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.CommandText = " exec dbo.ms_sp_GetHeatRangeForHardnessTest'" & wheel_type.Trim & "'," & ForceRange & " "
                da.Fill(ds)
                GetHeatRangeForHardnessTest = ds.Tables(0).Copy
            Catch exp As Exception
                GetHeatRangeForHardnessTest = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetDistinctWheelType(ByVal test_type As String) As DataTable
            Dim da As New SqlClient.SqlDataAdapter()
            Dim ds As New DataSet()
            Try
                da.SelectCommand = rwfGen.Connection.CmdObj
                da.SelectCommand.CommandText = " SELECT *  FROM ms_vw_DistinctWheelTypeWithLabNumber where test_type = '" & test_type.Trim & "' order by sent_date desc  "
                da.Fill(ds)
                GetDistinctWheelType = ds.Tables(0).Copy
            Catch exp As Exception
                GetDistinctWheelType = Nothing
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function GetDescription(ByVal Wh As Long, ByVal Ht As Long) As String
            Dim oCmd As New SqlClient.SqlCommand()
            oCmd.Connection = rwfGen.Connection.ConObj
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Parameters.Add("@Description", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                oCmd.CommandText = " SELECT @Description = description FROM mm_wheel WHERE wheel_number = " & Wh & " and heat_number = " & Ht & ""
                oCmd.ExecuteScalar()
                GetDescription = IIf(IsDBNull(oCmd.Parameters("@Description").Value), "", oCmd.Parameters("@Description").Value)
            Catch exp As Exception
                GetDescription = Nothing
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End Try
        End Function
        Public Shared Function GetClass(ByVal ProdCode As String) As String
            Dim oCmd As New SqlClient.SqlCommand()
            oCmd.Connection = rwfGen.Connection.ConObj
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Parameters.Add("@Class", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                oCmd.CommandText = " SELECT @Class = Class FROM mm_product_master WHERE product_code = '" & ProdCode.Trim & "' "
                oCmd.ExecuteScalar()
                GetClass = IIf(IsDBNull(oCmd.Parameters("@Class").Value), "", oCmd.Parameters("@Class").Value)
            Catch exp As Exception
                GetClass = Nothing
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End Try
        End Function
        Public Shared Function CheckValidity(ByVal myheat As Long, ByVal mywheel As Long) As Boolean
            Dim oCmd As New SqlClient.SqlCommand()
            oCmd.Connection = rwfGen.Connection.ConObj
            Try
                oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = "select @cnt = count(heat_number) from mm_wheel where heat_number = " & myheat & " and wheel_number  = " & mywheel
                oCmd.ExecuteScalar()
                CheckValidity = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), "0", oCmd.Parameters("@cnt").Value)
            Catch exp As Exception
                CheckValidity = False
                Throw New Exception("InValid Heat Number !" & exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End Try
        End Function
    End Class
    MustInherit Class WheelHardness
#Region "  Fields"
        Protected lWheelNumber, lHeatNumber, lHeatFrom, lHeatTo As Long
        Protected sMessage, sWheelType, sLabNumber, sshift_code, sinspector, swheel, swheel_class As String
        Protected datesent_date, dateexpected_test_date As Date
        Protected llab_code As Long
        Protected dtInclusionTable As DataTable
#End Region
#Region "  Property"
        Property InclusionTable() As DataTable
            Get
                Return dtInclusionTable
            End Get
            Set(ByVal Value As DataTable)
                dtInclusionTable = Value
            End Set
        End Property
        Property wheel_class() As String
            Get
                Return swheel_class
            End Get
            Set(ByVal Value As String)
                swheel_class = Value
            End Set
        End Property
        Property wheel() As String
            Get
                Return swheel
            End Get
            Set(ByVal Value As String)
                swheel = Value
            End Set
        End Property
        Property inspector() As String
            Get
                Return sinspector
            End Get
            Set(ByVal Value As String)
                sinspector = Value
            End Set
        End Property
        Property shift_code() As String
            Get
                Return sshift_code
            End Get
            Set(ByVal Value As String)
                sshift_code = Value
            End Set
        End Property
        Property lab_code() As Long
            Get
                Return llab_code
            End Get
            Set(ByVal Value As Long)
                llab_code = Value
            End Set
        End Property
        Property sent_date() As Date
            Get
                Return datesent_date
            End Get
            Set(ByVal Value As Date)
                datesent_date = Value
            End Set
        End Property
        Property expected_test_date() As Date
            Get
                Return dateexpected_test_date
            End Get
            Set(ByVal Value As Date)
                dateexpected_test_date = Value
            End Set
        End Property
        Property LabNumber() As String
            Get
                Return sLabNumber
            End Get
            Set(ByVal Value As String)
                sLabNumber = Value.Trim
            End Set
        End Property
        Property WheelType() As String
            Get
                Return sWheelType.Trim
            End Get
            Set(ByVal Value As String)
                sWheelType = Value.Trim
            End Set
        End Property
        Property WheelNumber() As Long
            Get
                Return lWheelNumber
            End Get
            Set(ByVal Value As Long)
                lWheelNumber = Value
            End Set
        End Property
        Property HeatNumber() As Long
            Get
                Return lHeatNumber
            End Get
            Set(ByVal Value As Long)
                lHeatNumber = Value
            End Set
        End Property
        Property HeatFrom() As Long
            Get
                Return lHeatFrom
            End Get
            Set(ByVal Value As Long)
                lHeatFrom = Value
            End Set
        End Property
        Property HeatTo() As Long
            Get
                Return lHeatTo
            End Get
            Set(ByVal Value As Long)
                lHeatTo = Value
            End Set
        End Property
        ReadOnly Property Message() As String
            Get
                Return sMessage
            End Get
        End Property
#End Region
#Region "  Methods"
        Private Sub iniVals()
            dateexpected_test_date = "1900-01-01"
            dtInclusionTable = Nothing
            swheel_class = ""
            swheel = ""
            sinspector = ""
            sshift_code = ""
            llab_code = 0
            datesent_date = "1900-01-01"
            sLabNumber = ""
            sMessage = ""
            sWheelType = ""
            lWheelNumber = 0
            lHeatNumber = 0
            lHeatFrom = 0
            lHeatTo = 0
        End Sub
        Public Sub New()
            iniVals()
        End Sub
        Public Function SaveSample(ByVal TestType As String) As Boolean
            Dim Cmd As New SqlClient.SqlCommand()
            Cmd.Connection = rwfGen.Connection.ConObj
            Try
                If Cmd.Connection.State = ConnectionState.Closed Then Cmd.Connection.Open()
                Cmd.CommandText = " insert into ms_wheel_hardness_sample ( wheel_number , heat_number , " & _
                            " heat_from , heat_to , sent_date , lab_number , shift_code , inspector , wheel , " & _
                            " wheel_type , test_type , wheel_class , expected_test_date ) values ( @wheel_number , @heat_number , " & _
                            " @heat_from , @heat_to , @sent_date , @lab_number , @shift_code , @inspector , @wheel , " & _
                            " @wheel_type , @test_type , @wheel_class , @expected_test_date )"

                Cmd.Parameters.Add("@wheel_number", SqlDbType.VarChar, 50).Value = CStr(Me.WheelNumber)
                Cmd.Parameters.Add("@heat_number", SqlDbType.BigInt, 8).Value = Me.HeatNumber
                Cmd.Parameters.Add("@heat_from", SqlDbType.BigInt, 8).Value = Me.HeatFrom
                Cmd.Parameters.Add("@heat_to", SqlDbType.BigInt, 8).Value = Me.HeatTo
                Cmd.Parameters.Add("@sent_date", SqlDbType.SmallDateTime, 4).Value = Me.sent_date
                Cmd.Parameters.Add("@lab_number", SqlDbType.VarChar, 50).Value = Me.LabNumber
                Cmd.Parameters.Add("@shift_code", SqlDbType.VarChar, 1).Value = Me.shift_code
                Cmd.Parameters.Add("@inspector", SqlDbType.VarChar, 50).Value = Me.inspector
                Cmd.Parameters.Add("@wheel", SqlDbType.VarChar, 50).Value = Me.wheel
                Cmd.Parameters.Add("@wheel_type", SqlDbType.VarChar, 20).Value = Me.WheelType
                Cmd.Parameters.Add("@test_type", SqlDbType.VarChar, 20).Value = TestType.Trim
                Cmd.Parameters.Add("@wheel_class", SqlDbType.VarChar, 20).Value = Me.wheel_class
                Cmd.Parameters.Add("@expected_test_date", SqlDbType.SmallDateTime, 4).Value = Me.expected_test_date
                If Cmd.ExecuteNonQuery > 0 Then SaveSample = True
            Catch exp As Exception
                sMessage = exp.Message
            Finally
                If Cmd.Connection.State = ConnectionState.Open Then Cmd.Connection.Close()
                Cmd.Dispose()
            End Try
        End Function
        Public Function UpdateSample(ByVal TestType As String) As Boolean
            Dim Cmd As New SqlClient.SqlCommand()
            Cmd.Connection = rwfGen.Connection.ConObj
            Dim done As New Boolean()
            Try
                If TestType = "Regular" Then
                    If Cmd.Connection.State = ConnectionState.Closed Then Cmd.Connection.Open()
                    Cmd.Transaction = Cmd.Connection.BeginTransaction
                    Cmd.CommandText = " update ms_wheel_hardness_sample set wheel_number = @wheel_number ,  heat_number = @heat_number  , " & _
                                " wheel = @wheel  where lab_number =  @lab_number "

                    Cmd.Parameters.Add("@wheel_number", SqlDbType.VarChar, 50).Value = CStr(Me.WheelNumber)
                    Cmd.Parameters.Add("@heat_number", SqlDbType.BigInt, 8).Value = Me.HeatNumber
                    Cmd.Parameters.Add("@lab_number", SqlDbType.VarChar, 50).Value = Me.LabNumber
                    Cmd.Parameters.Add("@wheel", SqlDbType.VarChar, 50).Value = Me.wheel
                    'Cmd.Parameters.Add("@heat_from", SqlDbType.BigInt, 8).Value = Me.HeatFrom
                    'Cmd.Parameters.Add("@heat_to", SqlDbType.BigInt, 8).Value = Me.HeatTo
                    'Cmd.Parameters.Add("@sent_date", SqlDbType.SmallDateTime, 4).Value = Me.sent_date
                    'Cmd.Parameters.Add("@inspector", SqlDbType.VarChar, 50).Value = Me.inspector
                    'Cmd.Parameters.Add("@wheel_type", SqlDbType.VarChar, 20).Value = Me.WheelType
                    'Cmd.Parameters.Add("@test_type", SqlDbType.VarChar, 20).Value = TestType.Trim
                    'Cmd.Parameters.Add("@wheel_class", SqlDbType.VarChar, 20).Value = Me.wheel_class
                    If Cmd.ExecuteNonQuery > 0 Then
                        Cmd.CommandText = "delete ms_wheel_hardness_chemical where lab_number = @lab_number "
                        Cmd.ExecuteNonQuery()
                        Cmd.CommandText = "delete ms_wheel_hardness_chemical_empcode where lab_number = @lab_number "
                        Cmd.ExecuteNonQuery()
                        Cmd.CommandText = "delete ms_wheel_hardnessvalues_reference where lab_number = @lab_number "
                        Cmd.ExecuteNonQuery()
                        Cmd.CommandText = "delete ms_wheel_hardness_values where lab_number = @lab_number "
                        Cmd.ExecuteNonQuery()
                        Cmd.CommandText = "delete ms_wheel_hardness_physical where lab_number = @lab_number "
                        Cmd.ExecuteNonQuery()
                        Cmd.CommandText = "delete ms_wheel_hardness_HTDetails where lab_number = @lab_number "
                        Cmd.ExecuteNonQuery()
                        Cmd.CommandText = "delete ms_wheel_hardness_details where lab_number = @lab_number "
                        Cmd.ExecuteNonQuery()
                        Cmd.CommandText = "delete ms_wheel_hardness_inclusion_details where lab_number = @lab_number "
                        Cmd.ExecuteNonQuery()
                        done = True
                    End If
                Else
                    If Cmd.Connection.State = ConnectionState.Closed Then Cmd.Connection.Open()
                    Cmd.Transaction = Cmd.Connection.BeginTransaction
                    Cmd.CommandText = " update ms_wheel_hardness_sample set wheel_number = @wheel_number ,  heat_number = @heat_number  , " & _
                                " wheel = @wheel , heat_from = @heat_from , heat_to = @heat_to where lab_number =  @lab_number "

                    Cmd.Parameters.Add("@wheel_number", SqlDbType.VarChar, 50).Value = CStr(Me.WheelNumber)
                    Cmd.Parameters.Add("@heat_number", SqlDbType.BigInt, 8).Value = Me.HeatNumber
                    Cmd.Parameters.Add("@lab_number", SqlDbType.VarChar, 50).Value = Me.LabNumber
                    Cmd.Parameters.Add("@wheel", SqlDbType.VarChar, 50).Value = Me.wheel
                    Cmd.Parameters.Add("@heat_from", SqlDbType.BigInt, 8).Value = Me.HeatFrom
                    Cmd.Parameters.Add("@heat_to", SqlDbType.BigInt, 8).Value = Me.HeatTo
                    'Cmd.Parameters.Add("@sent_date", SqlDbType.SmallDateTime, 4).Value = Me.sent_date
                    'Cmd.Parameters.Add("@inspector", SqlDbType.VarChar, 50).Value = Me.inspector
                    'Cmd.Parameters.Add("@wheel_type", SqlDbType.VarChar, 20).Value = Me.WheelType
                    'Cmd.Parameters.Add("@test_type", SqlDbType.VarChar, 20).Value = TestType.Trim
                    'Cmd.Parameters.Add("@wheel_class", SqlDbType.VarChar, 20).Value = Me.wheel_class
                    If Cmd.ExecuteNonQuery > 0 Then
                        Cmd.CommandText = "delete ms_wheel_hardness_chemical where lab_number = @lab_number "
                        Cmd.ExecuteNonQuery()
                        Cmd.CommandText = "delete ms_wheel_hardness_chemical_empcode where lab_number = @lab_number "
                        Cmd.ExecuteNonQuery()
                        Cmd.CommandText = "delete ms_wheel_hardnessvalues_reference where lab_number = @lab_number "
                        Cmd.ExecuteNonQuery()
                        Cmd.CommandText = "delete ms_wheel_hardness_values where lab_number = @lab_number "
                        Cmd.ExecuteNonQuery()
                        Cmd.CommandText = "delete ms_wheel_hardness_physical where lab_number = @lab_number "
                        Cmd.ExecuteNonQuery()
                        Cmd.CommandText = "delete ms_wheel_hardness_HTDetails where lab_number = @lab_number "
                        Cmd.ExecuteNonQuery()
                        Cmd.CommandText = "delete ms_wheel_hardness_details where lab_number = @lab_number "
                        Cmd.ExecuteNonQuery()
                        Cmd.CommandText = "delete ms_wheel_hardness_inclusion_details where lab_number = @lab_number "
                        Cmd.ExecuteNonQuery()
                        done = True
                    End If
                End If
            Catch exp As Exception
                sMessage = exp.Message
            Finally
                If done Then
                    Cmd.Transaction.Commit()
                Else
                    Cmd.Transaction.Rollback()
                End If
                If Cmd.Connection.State = ConnectionState.Open Then Cmd.Connection.Close()
                Cmd.Dispose()
            End Try
            Return done
        End Function
        Public Function UpdateSampleFrToHeat() As Boolean
            Dim Cmd As New SqlClient.SqlCommand()
            Cmd.Connection = rwfGen.Connection.ConObj
            Dim done As New Boolean()
            Try
                If Cmd.Connection.State = ConnectionState.Closed Then Cmd.Connection.Open()
                Cmd.Transaction = Cmd.Connection.BeginTransaction
                Cmd.CommandText = " update ms_wheel_hardness_sample set heat_from = @heat_from ,  heat_to = @heat_to " & _
                            " where lab_number =  @lab_number " 
                Cmd.Parameters.Add("@lab_number", SqlDbType.VarChar, 50).Value = Me.LabNumber
                Cmd.Parameters.Add("@heat_from", SqlDbType.BigInt, 8).Value = Me.HeatFrom
                Cmd.Parameters.Add("@heat_to", SqlDbType.BigInt, 8).Value = Me.HeatTo
                If Cmd.ExecuteNonQuery = 1 Then done = True
            Catch exp As Exception
                sMessage = exp.Message
            Finally
                If done Then
                    Cmd.Transaction.Commit()
                Else
                    Cmd.Transaction.Rollback()
                End If
                If Cmd.Connection.State = ConnectionState.Open Then Cmd.Connection.Close()
                Cmd.Dispose()
            End Try
            Return done
        End Function
        Public Function GetLabNumber() As String
            Dim intBid As Integer
            Dim code, yr, yrTemp As String
            Dim oCmd As New SqlClient.SqlCommand()
            oCmd.Connection = rwfGen.Connection.ConObj
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Parameters.Add("@LabCode", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
                oCmd.Parameters.Add("@LabNumber", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output

                oCmd.CommandText = "select top 1 @LabCode =  max(lab_code) , @LabNumber = lab_number  from ms_wheel_hardness_sample group by lab_code , lab_number order by lab_code desc"
                oCmd.ExecuteScalar()
                intBid = IIf(IsDBNull(oCmd.Parameters("@LabCode").Value), 1, oCmd.Parameters("@LabCode").Value)
                If intBid = 1 Then
                    yr = Date.Today.Year
                    yr = yr.Substring(2)
                Else
                    code = oCmd.Parameters("@LabNumber").Value
                    yrTemp = code.Substring(0, 2)
                    yr = Date.Today.Year
                    yr = yr.Substring(2)
                    intBid = code.Substring(3)
                    If Not yrTemp.Equals(yr) Then
                        intBid = 0
                    End If
                    intBid = intBid + 1
                End If
                GetLabNumber = yr & "/" & intBid
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End Try
        End Function
        Public Function CheckStatus(ByVal TestType As String, ByVal PresentWheel As Long, ByVal PresentHeat As Long) As Boolean
            Dim oCmd As New SqlClient.SqlCommand()
            oCmd.Connection = rwfGen.Connection.ConObj
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                If TestType.Trim = "Regular" Then
                    'Regular test type wheel should be a heat treated wheel
                    'Hence location = 'mopo' wheels should not be taken for consideration
                    oCmd.CommandText = " select  @cnt = count(*) from mm_wheel a where (((a.location in ('clmt', 'clqc', 'clfq')  and a.status like 'XC%' and a.status not like 'XC8%' ) or ( a.location = 'clfi' and a.status like 'r%') or ( a.location = 'clfq' and a.magnaglow_status like 'x%' )or ( a.location = 'mopo' and a.status like 'x96%'))) " & _
                                                   " and a.heat_number = " & PresentHeat & " and a.wheel_number = " & PresentWheel & " ; "

                    'oCmd.CommandText = " select  @cnt = count(*) from mm_wheel a where ((a.location = 'mopo' and a.status like 'x%') or ((a.location in ('clmt', 'clqc', 'clfq')  and a.status like 'XC%' and a.status not like 'XC8%' ) or ( a.location = 'clfi' and a.status like 'r%'))) " & _
                    '                " and a.heat_number = " & PresentHeat & " and a.wheel_number = " & PresentWheel & " ; "
                Else
                    oCmd.CommandText = " select  @cnt = count(*) from mm_wheel a where a.heat_number = " & PresentHeat & " and a.wheel_number = " & PresentWheel & " ; "
                End If
                oCmd.ExecuteScalar()
                CheckStatus = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)
            Catch exp As Exception
                CheckStatus = False
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End Try
        End Function
        Public Function CheckPrevious() As Boolean
            Dim oCmd As New SqlClient.SqlCommand()
            oCmd.Connection = rwfGen.Connection.ConObj
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Parameters.Add("@PresentWheelType", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                oCmd.CommandText = " select  @PresentWheelType = description from mm_wheel a where a.heat_number = " & Me.HeatNumber & " and a.wheel_number = " & Me.WheelNumber & " "
                oCmd.ExecuteScalar()
                Me.WheelType = IIf(IsDBNull(oCmd.Parameters("@PresentWheelType").Value), "", oCmd.Parameters("@PresentWheelType").Value)
                If Me.WheelType.Trim.Length > 0 Then
                    oCmd.Parameters.Add("@PreviousHeatTo", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
                    oCmd.Parameters.Add("@PreviousWheelType", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                    oCmd.Parameters("@PresentWheelType").Direction = ParameterDirection.Input
                    oCmd.Parameters("@PresentWheelType").Value = Me.WheelType
                    oCmd.CommandText = " select @PreviousWheelType = wheel_type , @PreviousHeatTo = heat_to from  ms_vw_DistinctWheelTypeWithLabNumber where Wheel_type = @PresentWheelType and test_type = 'Regular' "
                    oCmd.ExecuteScalar()
                    Dim PreHtTo As Long = IIf(IsDBNull(oCmd.Parameters("@PreviousHeatTo").Value), 0, oCmd.Parameters("@PreviousHeatTo").Value)
                    If Me.HeatFrom >= PreHtTo Then
                        If Me.WheelType.Trim = IIf(IsDBNull(oCmd.Parameters("@PreviousWheelType").Value), "", oCmd.Parameters("@PreviousWheelType").Value) Then
                            CheckPrevious = True
                        End If
                    End If
                End If
            Catch exp As Exception
                sMessage = exp.Message
                CheckPrevious = False
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End Try
        End Function
        Public Function CheckXCCount(ByVal PresentWheel As Long, ByVal PresentHeat As Long, ByVal PresentHeatFrom As Long, ByVal PresentHeatTo As Long) As Boolean
            Dim oCmd As New SqlClient.SqlCommand()
            oCmd.Connection = rwfGen.Connection.ConObj
            If Val(PresentHeat) >= PresentHeatFrom AndAlso Val(PresentHeat) <= PresentHeatTo Then
                Try
                    If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                    oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                    oCmd.CommandText = " select  @cnt = count(*) from mm_wheel a where (((a.location in ('clmt', 'clqc', 'clfq')  and a.status like 'XC%' and a.status not like 'XC8%' ) or ( a.location = 'clfi' and a.status like 'r%')or ( a.location = 'clfq' and a.magnaglow_status like 'x%' )or ( a.location = 'mopo' and a.status like 'x96%'))) " & _
                                                   " and a.heat_number between " & PresentHeatFrom & " and " & PresentHeatTo & " ; "
                    oCmd.ExecuteScalar()
                    If IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value) = 0 Then
                        oCmd.CommandText = " select  @cnt = count(*) from mm_wheel a where a.heat_number = " & PresentHeat & " and a.wheel_number = " & PresentWheel & " ; "
                        oCmd.ExecuteScalar()
                        If IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value) > 0 Then
                            If CheckPrevious() Then
                                CheckXCCount = True
                            Else
                                Throw New Exception("InValid Wheel Type !")
                            End If
                        Else
                            Throw New Exception("InValid Wheel Count !")
                        End If
                        Throw New Exception("InValid WHEEL !")
                    End If
                Catch exp As Exception
                    sMessage = exp.Message
                    CheckXCCount = False
                Finally
                    If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                    oCmd.Dispose()
                End Try
            Else
                CheckXCCount = False
            End If
        End Function
#End Region
    End Class
    Friend Class RegularTest
        Inherits metLab.WheelHardness
#Region "  Fields"
        Private lPreviousWheelNumber, lPreviousHeatNumber, lPreviousHeatFrom, lPreviousHeatTo As Long
        Private sTestType As String
#End Region
#Region "  Property"
        Property TestType() As String
            Get
                Return sTestType
            End Get
            Set(ByVal Value As String)
                sTestType = Value.Trim
            End Set
        End Property
#End Region
#Region "  Methods"
        Private Sub iniVals()
            sTestType = ""
        End Sub
        Public Sub New()
            iniVals()
        End Sub
        Public Sub New(ByVal LabNumber As String)
            iniVals()
            Me.LabNumber = LabNumber
            GetLabValues(Me.LabNumber)
        End Sub
        Public Sub New(ByVal PresentWheel As Long, ByVal PresentHeat As Long, ByVal PresentHeatFrom As Long, ByVal PresentHeatTo As Long)
            iniVals()
            sTestType = "Regular"
            If CheckStatus(sTestType, PresentWheel, PresentHeat) Then
                If Val(PresentHeat) >= PresentHeatFrom AndAlso Val(PresentHeat) <= PresentHeatTo Then
                    Me.WheelNumber = PresentWheel
                    Me.HeatNumber = PresentHeat
                    Me.HeatFrom = PresentHeatFrom
                    Me.HeatTo = PresentHeatTo
                    'If CheckPrevious() Then
                    Me.LabNumber = GetLabNumber()
                    'Else
                    '    Throw New Exception("Previous wheel type mis-match !")
                    'End If
                Else
                    Throw New Exception(" Heat Number : '" & PresentHeat & "' is beyond  FromHeat : '" & PresentHeatFrom & "' and ToHeat : '" & PresentHeatTo & "' heats !")
                End If
            Else
                If CheckXCCount(PresentWheel, PresentHeat, PresentHeatFrom, PresentHeatTo) Then
                    Me.LabNumber = GetLabNumber()
                Else
                    Throw New Exception("InValid Status Wheel !")
                End If
            End If
        End Sub
        Private Sub GetLabValues(ByVal LabNumber As String)
            Dim oCmd As New SqlClient.SqlCommand()
            oCmd.Connection = rwfGen.Connection.ConObj
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Parameters.Add("@LabNumber", SqlDbType.VarChar, 50).Value = LabNumber.Trim
                oCmd.Parameters.Add("@wheel_number", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
                oCmd.Parameters.Add("@heat_number", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
                oCmd.Parameters.Add("@heat_from", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
                oCmd.Parameters.Add("@heat_to", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
                oCmd.Parameters.Add("@lab_code", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
                oCmd.Parameters.Add("@wheel", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                oCmd.Parameters.Add("@wheel_type", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output

                oCmd.CommandText = " select  @wheel_number = wheel_number , @heat_number =  heat_number , @heat_from = heat_from , @heat_to = heat_to , @lab_code = lab_code , @wheel = wheel , @wheel_type = wheel_type from ms_wheel_hardness_sample where lab_number = @LabNumber ; "
                oCmd.ExecuteScalar()
                Me.WheelNumber = IIf(IsDBNull(oCmd.Parameters("@wheel_number").Value), 0, oCmd.Parameters("@wheel_number").Value)
                Me.HeatNumber = IIf(IsDBNull(oCmd.Parameters("@heat_number").Value), 0, oCmd.Parameters("@heat_number").Value)
                Me.HeatFrom = IIf(IsDBNull(oCmd.Parameters("@heat_from").Value), 0, oCmd.Parameters("@heat_from").Value)
                Me.HeatTo = IIf(IsDBNull(oCmd.Parameters("@heat_to").Value), 0, oCmd.Parameters("@heat_to").Value)
                Me.WheelType = IIf(IsDBNull(oCmd.Parameters("@wheel_type").Value), "", oCmd.Parameters("@wheel_type").Value)
                Me.lab_code = IIf(IsDBNull(oCmd.Parameters("@lab_code").Value), 0, oCmd.Parameters("@lab_code").Value)
                Me.wheel = IIf(IsDBNull(oCmd.Parameters("@wheel").Value), "", oCmd.Parameters("@wheel").Value)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End Try
        End Sub
        Private Function CheckPresentWheelType() As Boolean
            Dim oCmd As New SqlClient.SqlCommand()
            oCmd.Connection = rwfGen.Connection.ConObj
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Parameters.Add("@PreviousHeatTo", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
                oCmd.Parameters.Add("@PresentWheelType", SqlDbType.VarChar, 50).Value = WheelType
                oCmd.CommandText = " select @PreviousHeatTo = heat_to from  ms_vw_DistinctWheelTypeWithLabNumber where description = @PresentWheelType and test_type = 'Regular' "
                oCmd.ExecuteScalar()
                Dim PreHtTo As Long = IIf(IsDBNull(oCmd.Parameters("@PreviousHeatTo").Value), 0, oCmd.Parameters("@PreviousHeatTo").Value)
                If Me.HeatFrom > PreHtTo Then CheckPresentWheelType = True
            Catch exp As Exception
                sMessage = exp.Message
                CheckPresentWheelType = False
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End Try
        End Function
        Public Function BHNSampleScheduleDelete(ByVal WheelType As String, ByVal heat_from As Decimal, ByVal heat_to As Decimal) As Boolean
            Dim oCmd As New SqlClient.SqlCommand()
            oCmd.Connection = rwfGen.Connection.ConObj
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Parameters.Add("@product_code", SqlDbType.VarChar, 8).Value = WheelType
                oCmd.Parameters.Add("@heat_from", SqlDbType.Decimal, 8).Value = heat_from
                oCmd.Parameters.Add("@heat_to", SqlDbType.Decimal, 8).Value = heat_to
                oCmd.CommandText = "delete  ms_wheel_hardness_sample_schedule " & _
                    " where product_code = @product_code and heat_from = @heat_from and heat_to = @heat_to"
                If oCmd.ExecuteNonQuery = 1 Then BHNSampleScheduleDelete = True
            Catch exp As Exception
                sMessage = exp.Message
                BHNSampleScheduleDelete = False
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End Try
        End Function
#End Region
    End Class
    Friend Class ExperimentalTest
        Inherits metLab.WheelHardness
#Region "  Fields"
        Private sTestType As String
#End Region
#Region "  Property"
        Property TestType() As String
            Get
                Return sTestType
            End Get
            Set(ByVal Value As String)
                sTestType = Value.Trim
            End Set
        End Property
#End Region
#Region "  Methods"
        Private Sub iniVals()
            sTestType = ""
        End Sub
        Public Sub New(ByVal PresentWheel As Long, ByVal PresentHeat As Long, ByVal PresentHeatFrom As Long, ByVal PresentHeatTo As Long)
            iniVals()
            sTestType = "Experimental"
            If CheckStatus(sTestType, PresentWheel, PresentHeat) Then
                If Val(PresentHeat) >= PresentHeatFrom AndAlso Val(PresentHeat) <= PresentHeatTo Then
                    Me.WheelNumber = PresentWheel
                    Me.HeatNumber = PresentHeat
                    Me.HeatFrom = PresentHeatFrom
                    Me.HeatTo = PresentHeatTo
                    'If CheckPrevious() Then
                    Me.LabNumber = GetLabNumber()
                    'Else
                    '    Throw New Exception("Previous wheel type mis-match !")
                    'End If
                Else
                    Throw New Exception(" Heat Number : '" & PresentHeat & "' is beyond  FromHeat : '" & PresentHeatFrom & "' and ToHeat : '" & PresentHeatTo & "' heats !")
                End If
            Else
                Throw New Exception("InValid Status Wheel !")
            End If
        End Sub
        Public Sub New(ByVal LabNumber As String)
            iniVals()
            Me.LabNumber = LabNumber
            GetLabValues(Me.LabNumber)
        End Sub
        Private Sub GetLabValues(ByVal LabNumber As String)
            Dim oCmd As New SqlClient.SqlCommand()
            oCmd.Connection = rwfGen.Connection.ConObj
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Parameters.Add("@LabNumber", SqlDbType.VarChar, 50).Value = LabNumber.Trim
                oCmd.Parameters.Add("@wheel_number", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
                oCmd.Parameters.Add("@heat_number", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
                oCmd.Parameters.Add("@heat_from", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
                oCmd.Parameters.Add("@heat_to", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
                oCmd.Parameters.Add("@lab_code", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
                oCmd.Parameters.Add("@wheel", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                oCmd.Parameters.Add("@wheel_type", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output

                oCmd.CommandText = " select  @wheel_number = wheel_number , @heat_number =  heat_number , @heat_from = heat_from , @heat_to = heat_to , @lab_code = lab_code , @wheel = wheel , @wheel_type = wheel_type from ms_wheel_hardness_sample where lab_number = @LabNumber ; "
                oCmd.ExecuteScalar()
                Me.WheelNumber = IIf(IsDBNull(oCmd.Parameters("@wheel_number").Value), 0, oCmd.Parameters("@wheel_number").Value)
                Me.HeatNumber = IIf(IsDBNull(oCmd.Parameters("@heat_number").Value), 0, oCmd.Parameters("@heat_number").Value)
                Me.HeatFrom = IIf(IsDBNull(oCmd.Parameters("@heat_from").Value), 0, oCmd.Parameters("@heat_from").Value)
                Me.HeatTo = IIf(IsDBNull(oCmd.Parameters("@heat_to").Value), 0, oCmd.Parameters("@heat_to").Value)
                Me.WheelType = IIf(IsDBNull(oCmd.Parameters("@wheel_type").Value), "", oCmd.Parameters("@wheel_type").Value)
                Me.lab_code = IIf(IsDBNull(oCmd.Parameters("@lab_code").Value), 0, oCmd.Parameters("@lab_code").Value)
                Me.wheel = IIf(IsDBNull(oCmd.Parameters("@wheel").Value), "", oCmd.Parameters("@wheel").Value)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End Try
        End Sub
#End Region
    End Class
    MustInherit Class SteelClass
        Inherits WheelHardness
#Region "  Fields"
        Protected lnitrogen, lhydrogen, lcarbon, lphosphorus, lmanganese, lsulphur, lsilicon, lchromium, lnickle, lcopper, lalunimum, lmolybdenum, lvanadium As Decimal
        Protected sEmployeeCode As String
#End Region
#Region "  Property"
        Property nitrogen() As Decimal
            Get
                Return lnitrogen
            End Get
            Set(ByVal Value As Decimal)
                lnitrogen = Value
            End Set
        End Property
        Property hydrogen() As Decimal
            Get
                Return lhydrogen
            End Get
            Set(ByVal Value As Decimal)
                lhydrogen = Value
            End Set
        End Property
        Property EmployeeCode() As String
            Get
                Return sEmployeeCode
            End Get
            Set(ByVal Value As String)
                sEmployeeCode = Value
            End Set
        End Property
        Property carbon() As Decimal
            Get
                Return lcarbon
            End Get
            Set(ByVal Value As Decimal)
                lcarbon = Value
            End Set
        End Property
        Property phosphorus() As Decimal
            Get
                Return lphosphorus
            End Get
            Set(ByVal Value As Decimal)
                lphosphorus = Value
            End Set
        End Property
        Property manganese() As Decimal
            Get
                Return lmanganese
            End Get
            Set(ByVal Value As Decimal)
                lmanganese = Value
            End Set
        End Property
        Property sulphur() As Decimal
            Get
                Return lsulphur
            End Get
            Set(ByVal Value As Decimal)
                lsulphur = Value
            End Set
        End Property
        Property silicon() As Decimal
            Get
                Return lsilicon
            End Get
            Set(ByVal Value As Decimal)
                lsilicon = Value
            End Set
        End Property
        Property chromium() As Decimal
            Get
                Return lchromium
            End Get
            Set(ByVal Value As Decimal)
                lchromium = Value
            End Set
        End Property
        Property nickle() As Decimal
            Get
                Return lnickle
            End Get
            Set(ByVal Value As Decimal)
                lnickle = Value
            End Set
        End Property
        Property copper() As Decimal
            Get
                Return lcopper
            End Get
            Set(ByVal Value As Decimal)
                lcopper = Value
            End Set
        End Property
        Property alunimum() As Decimal
            Get
                Return lalunimum
            End Get
            Set(ByVal Value As Decimal)
                lalunimum = Value
            End Set
        End Property
        Property molybdenum() As Decimal
            Get
                Return lmolybdenum
            End Get
            Set(ByVal Value As Decimal)
                lmolybdenum = Value
            End Set
        End Property
        Property vanadium() As Decimal
            Get
                Return lvanadium
            End Get
            Set(ByVal Value As Decimal)
                lvanadium = Value
            End Set
        End Property
#End Region
#Region "  Methods"
        Private Sub iniVals()
            lnitrogen = 0.0
            lhydrogen = 0.0
            lcarbon = 0.0
            lphosphorus = 0.0
            lmanganese = 0.0
            lsulphur = 0.0
            lsilicon = 0.0
            lchromium = 0.0
            lnickle = 0.0
            lcopper = 0.0
            lalunimum = 0.0
            lmolybdenum = 0.0
            lvanadium = 0.0
        End Sub
        Public Function SaveChemicalValues(ByVal Product As String, ByVal Mode As String)
            If Product.Trim.Length = 0 Then
                sMessage = " Select A Product Number "
                Exit Function
            End If
            Dim saveDateTime As DateTime
            saveDateTime = DateTime.Now
            Dim chemparam(14), empparam(2), FinIdparam(0), chemAxleparam(12) As SqlClient.SqlParameter
            Dim strCmdEmp, strAxleCmd, strCmdChem, strGetFinId As String
            Dim done As Integer = Nothing
            Dim sqlcon As New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
            Dim strTran As SqlClient.SqlTransaction
            Dim sqlcmd As New SqlClient.SqlCommand()
            Dim j As Integer

            If Product.Trim = "Axle" Then

                If Mode.Equals("edit") Then
                    strCmdEmp = " update ms_casttest_chemical_empcode  set EmpCode =  @EmpCode ,  saveDateTime =  @saveDateTime   "
                    strCmdEmp &= "  where  lab_number = @lab_number   "

                    strAxleCmd = " update ms_casttest_chemical set carbon = @txtcarbon , phosphorus = @txtphosphorus , "
                    strAxleCmd &= " manganese = @txtmanganese , sulphur = @txtsulphur , silicon = @txtsilicon , "
                    strAxleCmd &= " chromium = @txtchromium , nickle = @txtnickle , copper = @txtcopper , vanadium = @txtvanadium , "
                    strAxleCmd &= " molybdenum = @txtmolybdenum , phosphorus_sulphur = @txtphosphorus_sulphur "
                    strAxleCmd &= " , nitrogen = @nitrogen where lab_number = @ddllab_number "

                    strGetFinId = " select count(*) from ms_casttest_chemical_empcode where lab_number = @lab_number "
                Else
                    strCmdEmp = " insert into ms_casttest_chemical_empcode ( lab_number , EmpCode , saveDateTime )  "
                    strCmdEmp &= "  values ( @lab_number , @EmpCode , @saveDateTime ) "

                    strAxleCmd = " insert into ms_casttest_chemical ( lab_number , carbon,phosphorus , "
                    strAxleCmd &= " manganese,sulphur , silicon , chromium , nickle , copper , vanadium , "
                    strAxleCmd &= " molybdenum , phosphorus_sulphur , nitrogen ) values ( @ddllab_number , "
                    strAxleCmd &= " @txtcarbon , @txtphosphorus , @txtmanganese , @txtsulphur , @txtsilicon , "
                    strAxleCmd &= " @txtchromium , @txtnickle , @txtcopper , @txtvanadium , @txtmolybdenum , "
                    strAxleCmd &= " @txtphosphorus_sulphur , @nitrogen )"

                    strGetFinId = " select count(*) from ms_casttest_chemical_empcode where lab_number = @lab_number "
                End If

                FinIdparam(0) = New SqlClient.SqlParameter("@lab_number", SqlDbType.VarChar, 50)
                FinIdparam(0).Direction = ParameterDirection.Input

                empparam(0) = New SqlClient.SqlParameter("@lab_number", SqlDbType.VarChar, 50)
                empparam(1) = New SqlClient.SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
                empparam(2) = New SqlClient.SqlParameter("@saveDateTime", SqlDbType.SmallDateTime, 4)

                empparam(0).Direction = ParameterDirection.Input
                empparam(1).Direction = ParameterDirection.Input
                empparam(2).Direction = ParameterDirection.Input

                chemAxleparam(0) = New SqlClient.SqlParameter("@ddllab_number", SqlDbType.VarChar, 50)
                chemAxleparam(1) = New SqlClient.SqlParameter("@txtcarbon", SqlDbType.Float, 8)
                chemAxleparam(2) = New SqlClient.SqlParameter("@txtphosphorus", SqlDbType.Float, 8)
                chemAxleparam(3) = New SqlClient.SqlParameter("@txtmanganese", SqlDbType.Float, 8)
                chemAxleparam(4) = New SqlClient.SqlParameter("@txtsulphur", SqlDbType.Float, 8)
                chemAxleparam(5) = New SqlClient.SqlParameter("@txtsilicon", SqlDbType.Float, 8)
                chemAxleparam(6) = New SqlClient.SqlParameter("@txtchromium", SqlDbType.Float, 8)
                chemAxleparam(7) = New SqlClient.SqlParameter("@txtnickle", SqlDbType.Float, 8)
                chemAxleparam(8) = New SqlClient.SqlParameter("@txtcopper", SqlDbType.Float, 8)
                'chemparam(9) = New SqlClient.SqlParameter("@txtal", SqlDbType.Decimal, 4)
                chemAxleparam(9) = New SqlClient.SqlParameter("@txtmolybdenum", SqlDbType.Float, 8)
                chemAxleparam(10) = New SqlClient.SqlParameter("@txtvanadium", SqlDbType.Float, 8)
                chemAxleparam(11) = New SqlClient.SqlParameter("@txtphosphorus_sulphur", SqlDbType.Float, 8)
                chemAxleparam(12) = New SqlClient.SqlParameter("@nitrogen", SqlDbType.Float, 8)

                chemAxleparam(0).Direction = ParameterDirection.Input
                chemAxleparam(1).Direction = ParameterDirection.Input
                chemAxleparam(2).Direction = ParameterDirection.Input
                chemAxleparam(3).Direction = ParameterDirection.Input
                chemAxleparam(4).Direction = ParameterDirection.Input
                chemAxleparam(5).Direction = ParameterDirection.Input
                chemAxleparam(6).Direction = ParameterDirection.Input
                chemAxleparam(7).Direction = ParameterDirection.Input
                chemAxleparam(8).Direction = ParameterDirection.Input
                'chemparam(9).Direction = ParameterDirection.Input
                chemAxleparam(9).Direction = ParameterDirection.Input
                chemAxleparam(10).Direction = ParameterDirection.Input
                chemAxleparam(11).Direction = ParameterDirection.Input
                chemAxleparam(12).Direction = ParameterDirection.Input

                Try
                    FinIdparam(0).Value = sLabNumber

                    empparam(0).Value = sLabNumber
                    empparam(1).Value = sEmployeeCode
                    empparam(2).Value = saveDateTime

                    chemAxleparam(0).Value = sLabNumber
                    chemAxleparam(1).Value = lcarbon
                    chemAxleparam(2).Value = lphosphorus
                    chemAxleparam(3).Value = lmanganese
                    chemAxleparam(4).Value = lsulphur
                    chemAxleparam(5).Value = lsilicon
                    chemAxleparam(6).Value = lchromium
                    chemAxleparam(7).Value = lnickle
                    chemAxleparam(8).Value = lcopper
                    'chemparam(9).Value = lalunimum
                    chemAxleparam(9).Value = lmolybdenum
                    chemAxleparam(10).Value = lvanadium
                    chemAxleparam(11).Value = lphosphorus + lsulphur
                    chemAxleparam(12).Value = lnitrogen

                Catch exp As Exception
                    sMessage = exp.Message
                    Exit Function
                End Try
                Try
                    sqlcmd.Connection = sqlcon
                    sqlcmd.Connection.Open()
                    sqlcmd.Transaction = sqlcmd.Connection.BeginTransaction
                    For j = 0 To 2
                        sqlcmd.Parameters.Add(empparam(j))
                    Next
                    sqlcmd.CommandText = strCmdEmp
                    done = sqlcmd.ExecuteNonQuery()
                    For j = 0 To 2
                        sqlcmd.Parameters.Remove(empparam(j))
                    Next
                    If done > 0 Then
                        done = 0
                        For j = 0 To 12
                            sqlcmd.Parameters.Add(chemAxleparam(j))
                        Next
                        sqlcmd.CommandText = strAxleCmd
                        done = sqlcmd.ExecuteNonQuery()
                        For j = 0 To 12
                            sqlcmd.Parameters.Remove(chemAxleparam(j))
                        Next
                        If done > 0 Then
                            done = 0
                            j = 0
                            sqlcmd.Parameters.Add(FinIdparam(j))
                            sqlcmd.CommandText = strGetFinId
                            done = sqlcmd.ExecuteScalar
                            If done > 0 Then
                                sMessage = "Record Saved"
                            Else
                                sMessage = "could not save the record"
                            End If
                        Else
                            sMessage = "could not save the record"
                        End If
                    Else
                        sMessage = "could not save the record"
                    End If

                Catch exp As Exception
                    sMessage = exp.Message
                Finally
                    If sMessage = "Record Saved" Then
                        sqlcmd.Transaction.Commit()
                    Else
                        sqlcmd.Transaction.Rollback()
                    End If
                    If sqlcmd.Connection.State = ConnectionState.Open Then sqlcmd.Connection.Close()
                    sqlcmd.Dispose()
                End Try
            ElseIf Product = "Wheel" Then
                If Mode.Equals("edit") Then
                    strCmdEmp = " update ms_wheel_hardness_chemical_empcode  set EmpCode =  @EmpCode ,  saveDateTime =  @saveDateTime   "
                    strCmdEmp &= "  where  lab_number = @lab_number   "

                    strCmdChem = " update ms_wheel_hardness_chemical set carbon = @txtc , phosphorus = @txtp , manganese = @txtmn , sulphur = @txts , silicon = @txtsi , "
                    strCmdChem &= " chromium = @txtcr , nickle = @txtni , copper = @txtcu , alunimum = @txtal , molybdenum = @txtmo , vanadium = @txtv , phosphorus_sulphur = @txtps , "
                    strCmdChem &= " nitrogen = @txtN , hydrogen = @txtH where lab_number = @ddllab_number "

                    strGetFinId = " select count(*) from ms_wheel_hardness_chemical_empcode where lab_number = @lab_number "
                Else
                    strCmdEmp = " insert into ms_wheel_hardness_chemical_empcode ( lab_number , EmpCode , saveDateTime )  "
                    strCmdEmp &= "  values ( @lab_number , @EmpCode , @saveDateTime ) "

                    strCmdChem = " insert into ms_wheel_hardness_chemical(lab_number, "
                    strCmdChem &= " carbon , phosphorus , manganese , sulphur , silicon , chromium , nickle , copper , alunimum , molybdenum , vanadium , phosphorus_sulphur , nitrogen , hydrogen ) values ( @ddllab_number , @txtc , @txtp , "
                    strCmdChem &= " @txtmn , @txts , @txtsi , @txtcr , @txtni , @txtcu , @txtal , @txtmo , @txtv , @txtps , @txtN , @txtH ) "

                    strGetFinId = " select count(*) from ms_wheel_hardness_chemical_empcode where lab_number = @lab_number "
                End If
                FinIdparam(0) = New SqlClient.SqlParameter("@lab_number", SqlDbType.VarChar, 50)
                FinIdparam(0).Direction = ParameterDirection.Input

                empparam(0) = New SqlClient.SqlParameter("@lab_number", SqlDbType.VarChar, 50)
                empparam(1) = New SqlClient.SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
                empparam(2) = New SqlClient.SqlParameter("@saveDateTime", SqlDbType.SmallDateTime, 4)

                empparam(0).Direction = ParameterDirection.Input
                empparam(1).Direction = ParameterDirection.Input
                empparam(2).Direction = ParameterDirection.Input

                chemparam(0) = New SqlClient.SqlParameter("@ddllab_number", SqlDbType.VarChar, 50)
                chemparam(1) = New SqlClient.SqlParameter("@txtc", SqlDbType.Float, 8)
                chemparam(2) = New SqlClient.SqlParameter("@txtp", SqlDbType.Float, 8)
                chemparam(3) = New SqlClient.SqlParameter("@txtmn", SqlDbType.Float, 8)
                chemparam(4) = New SqlClient.SqlParameter("@txts", SqlDbType.Float, 8)
                chemparam(5) = New SqlClient.SqlParameter("@txtsi", SqlDbType.Float, 8)
                chemparam(6) = New SqlClient.SqlParameter("@txtcr", SqlDbType.Float, 8)
                chemparam(7) = New SqlClient.SqlParameter("@txtni", SqlDbType.Float, 8)
                chemparam(8) = New SqlClient.SqlParameter("@txtcu", SqlDbType.Float, 8)
                chemparam(9) = New SqlClient.SqlParameter("@txtal", SqlDbType.Float, 8)
                chemparam(10) = New SqlClient.SqlParameter("@txtmo", SqlDbType.Float, 8)
                chemparam(11) = New SqlClient.SqlParameter("@txtv", SqlDbType.Float, 8)
                chemparam(12) = New SqlClient.SqlParameter("@txtps", SqlDbType.Float, 8)
                chemparam(13) = New SqlClient.SqlParameter("@txtN", SqlDbType.Float, 8)
                chemparam(14) = New SqlClient.SqlParameter("@txtH", SqlDbType.Float, 8)

                chemparam(0).Direction = ParameterDirection.Input
                chemparam(1).Direction = ParameterDirection.Input
                chemparam(2).Direction = ParameterDirection.Input
                chemparam(3).Direction = ParameterDirection.Input
                chemparam(4).Direction = ParameterDirection.Input
                chemparam(5).Direction = ParameterDirection.Input
                chemparam(6).Direction = ParameterDirection.Input
                chemparam(7).Direction = ParameterDirection.Input
                chemparam(8).Direction = ParameterDirection.Input
                chemparam(9).Direction = ParameterDirection.Input
                chemparam(10).Direction = ParameterDirection.Input
                chemparam(11).Direction = ParameterDirection.Input
                chemparam(12).Direction = ParameterDirection.Input
                chemparam(13).Direction = ParameterDirection.Input
                chemparam(14).Direction = ParameterDirection.Input
                Try
                    FinIdparam(0).Value = sLabNumber

                    empparam(0).Value = sLabNumber
                    empparam(1).Value = sEmployeeCode.Trim
                    empparam(2).Value = saveDateTime

                    chemparam(0).Value = sLabNumber
                    chemparam(1).Value = lcarbon
                    chemparam(2).Value = lphosphorus
                    chemparam(3).Value = lmanganese
                    chemparam(4).Value = lsulphur
                    chemparam(5).Value = lsilicon
                    chemparam(6).Value = lchromium
                    chemparam(7).Value = lnickle
                    chemparam(8).Value = lcopper
                    chemparam(9).Value = lalunimum
                    chemparam(10).Value = lmolybdenum
                    chemparam(11).Value = lvanadium
                    chemparam(12).Value = lphosphorus + lsulphur
                    chemparam(13).Value = lnitrogen
                    chemparam(14).Value = lhydrogen
                Catch exp As Exception
                    sMessage = exp.Message
                    Exit Function
                End Try
                Try
                    sqlcmd.Connection = sqlcon
                    sqlcmd.Connection.Open()
                    sqlcmd.Transaction = sqlcmd.Connection.BeginTransaction
                    For j = 0 To 2
                        sqlcmd.Parameters.Add(empparam(j))
                    Next
                    sqlcmd.CommandText = strCmdEmp
                    done = sqlcmd.ExecuteNonQuery()
                    For j = 0 To 2
                        sqlcmd.Parameters.Remove(empparam(j))
                    Next
                    If done > 0 Then
                        done = 0
                        For j = 0 To 14
                            sqlcmd.Parameters.Add(chemparam(j))
                        Next
                        sqlcmd.CommandText = strCmdChem
                        done = sqlcmd.ExecuteNonQuery()
                        For j = 0 To 14
                            sqlcmd.Parameters.Remove(chemparam(j))
                        Next
                        If done > 0 Then
                            done = 0
                            j = 0
                            sqlcmd.Parameters.Add(FinIdparam(j))
                            sqlcmd.CommandText = strGetFinId
                            done = sqlcmd.ExecuteScalar
                            If Mode.Equals("edit") Then
                                done = 0
                                sqlcmd.CommandText = " update ms_wheel_hardness_chemical_empcode set EmpCode = @EmpCode , saveDateTime = @saveDateTime where  lab_number = '" & sLabNumber.Trim & "' "
                                sqlcmd.Parameters.Add("@EmpCode", SqlDbType.VarChar, 6).Value = sEmployeeCode.Trim
                                sqlcmd.Parameters.Add("@saveDateTime", SqlDbType.SmallDateTime, 4).Value = Now.Date
                                done = sqlcmd.ExecuteNonQuery()
                            End If
                            If done > 0 Then
                                sMessage = "Record Saved"
                            Else
                                sMessage = "could not save the record"
                            End If
                        Else
                            sMessage = "could not save the record"
                        End If
                    Else
                        sMessage = "could not save the record"
                    End If
                Catch exp As Exception
                    sMessage = exp.Message
                Finally
                    If sMessage = "Record Saved" Then
                        sqlcmd.Transaction.Commit()
                    Else
                        sqlcmd.Transaction.Rollback()
                    End If
                    If sqlcmd.Connection.State = ConnectionState.Open Then sqlcmd.Connection.Close()
                    sqlcmd.Dispose()
                End Try
            End If
        End Function
#End Region
    End Class
    Friend Class Product
        Inherits SteelClass
#Region "  Fields"
        Private lthick, lthin As Decimal
        Private sTestType, sinclusion, smicro, sgrain_size, smacro, sresult, sremarks, sclosure As String
        Private lkurim_a, lkurim_b, lkurim_c As Long
        Private linitial_gaugelength, lfinal_gaugelength, luts_rim, lys_rim, lklengation_rim, lrednarea_rim, luts_plate, lys_plate, lklengation_plate, lrednarea_plate As Decimal
        Private datedatetoday, dateNFChargeDate As Date
        Private sNFChargeTime, sNFChargeCondition, sNFDischargeTime As String
        Private intNFZone1, intNFZone2, intNFZone3, intNFZone4, intNFZone5, intNFZone6, intNFZone7 As Int16
        Private intDFZone1, intDFZone2, intDFZone3, intDFZone4, intDFZone5, intDFZone6, intDFZone7, intDFZone8 As Int16
        Private sHubCooler1, sHubCooler2, sHubCooler3, sHC1, sHC2, sHC3, sQuencherNo, sQTimeMin, sQTimeSec As String
#End Region
#Region "  Property"
        Property QTimeSec() As String
            Get
                Return sQTimeSec
            End Get
            Set(ByVal Value As String)
                sQTimeSec = Value
            End Set
        End Property
        Property QTimeMin() As String
            Get
                Return sQTimeMin
            End Get
            Set(ByVal Value As String)
                sQTimeMin = Value
            End Set
        End Property
        Property QuencherNo() As String
            Get
                Return sQuencherNo
            End Get
            Set(ByVal Value As String)
                sQuencherNo = Value
            End Set
        End Property
        Property HC3() As String
            Get
                Return sHC3
            End Get
            Set(ByVal Value As String)
                sHC3 = Value
            End Set
        End Property
        Property HC2() As String
            Get
                Return sHC2
            End Get
            Set(ByVal Value As String)
                sHC2 = Value
            End Set
        End Property
        Property HC1() As String
            Get
                Return sHC1
            End Get
            Set(ByVal Value As String)
                sHC1 = Value
            End Set
        End Property

        Property HubCooler3() As String
            Get
                Return sHubCooler3
            End Get
            Set(ByVal Value As String)
                sHubCooler3 = Value
            End Set
        End Property
        Property HubCooler2() As String
            Get
                Return sHubCooler2
            End Get
            Set(ByVal Value As String)
                sHubCooler2 = Value
            End Set
        End Property
        Property HubCooler1() As String
            Get
                Return sHubCooler1
            End Get
            Set(ByVal Value As String)
                sHubCooler1 = Value
            End Set
        End Property

        Property DFZone8() As Int16
            Get
                Return intDFZone8
            End Get
            Set(ByVal Value As Int16)
                intDFZone8 = Value
            End Set
        End Property
        Property DFZone7() As Int16
            Get
                Return intDFZone7
            End Get
            Set(ByVal Value As Int16)
                intDFZone7 = Value
            End Set
        End Property
        Property DFZone6() As Int16
            Get
                Return intDFZone6
            End Get
            Set(ByVal Value As Int16)
                intDFZone6 = Value
            End Set
        End Property
        Property DFZone5() As Int16
            Get
                Return intDFZone5
            End Get
            Set(ByVal Value As Int16)
                intDFZone5 = Value
            End Set
        End Property
        Property DFZone4() As Int16
            Get
                Return intDFZone4
            End Get
            Set(ByVal Value As Int16)
                intDFZone4 = Value
            End Set
        End Property
        Property DFZone3() As Int16
            Get
                Return intDFZone3
            End Get
            Set(ByVal Value As Int16)
                intDFZone3 = Value
            End Set
        End Property
        Property DFZone2() As Int16
            Get
                Return intDFZone2
            End Get
            Set(ByVal Value As Int16)
                intDFZone2 = Value
            End Set
        End Property
        Property DFZone1() As Int16
            Get
                Return intDFZone1
            End Get
            Set(ByVal Value As Int16)
                intDFZone1 = Value
            End Set
        End Property
        Property NFZone7() As Int16
            Get
                Return intNFZone7
            End Get
            Set(ByVal Value As Int16)
                intNFZone7 = Value
            End Set
        End Property
        Property NFZone6() As Int16
            Get
                Return intNFZone6
            End Get
            Set(ByVal Value As Int16)
                intNFZone6 = Value
            End Set
        End Property
        Property NFZone5() As Int16
            Get
                Return intNFZone5
            End Get
            Set(ByVal Value As Int16)
                intNFZone5 = Value
            End Set
        End Property
        Property NFZone4() As Int16
            Get
                Return intNFZone4
            End Get
            Set(ByVal Value As Int16)
                intNFZone4 = Value
            End Set
        End Property
        Property NFZone3() As Int16
            Get
                Return intNFZone3
            End Get
            Set(ByVal Value As Int16)
                intNFZone3 = Value
            End Set
        End Property
        Property NFZone2() As Int16
            Get
                Return intNFZone2
            End Get
            Set(ByVal Value As Int16)
                intNFZone2 = Value
            End Set
        End Property
        Property NFZone1() As Int16
            Get
                Return intNFZone1
            End Get
            Set(ByVal Value As Int16)
                intNFZone1 = Value
            End Set
        End Property
        Property NFDischargeTime() As String
            Get
                Return sNFDischargeTime
            End Get
            Set(ByVal Value As String)
                sNFDischargeTime = Value
            End Set
        End Property
        Property NFChargeCondition() As String
            Get
                Return sNFChargeCondition
            End Get
            Set(ByVal Value As String)
                sNFChargeCondition = Value
            End Set
        End Property
        Property NFChargeTime() As String
            Get
                Return sNFChargeTime
            End Get
            Set(ByVal Value As String)
                sNFChargeTime = Value
            End Set
        End Property
        Property NFChargeDate() As Date
            Get
                Return dateNFChargeDate
            End Get
            Set(ByVal Value As Date)
                dateNFChargeDate = Value
            End Set
        End Property
        Property closure() As String
            Get
                Return sclosure
            End Get
            Set(ByVal Value As String)
                sclosure = Value
            End Set
        End Property
        Property datetoday() As Date
            Get
                Return datedatetoday
            End Get
            Set(ByVal Value As Date)
                datedatetoday = Value
            End Set
        End Property
        Property initial_gaugelength() As Decimal
            Get
                Return linitial_gaugelength
            End Get
            Set(ByVal Value As Decimal)
                linitial_gaugelength = Value
            End Set
        End Property
        Property final_gaugelength() As Decimal
            Get
                Return lfinal_gaugelength
            End Get
            Set(ByVal Value As Decimal)
                lfinal_gaugelength = Value
            End Set
        End Property
        Property uts_rim() As Decimal
            Get
                Return luts_rim
            End Get
            Set(ByVal Value As Decimal)
                luts_rim = Value
            End Set
        End Property
        Property ys_rim() As Decimal
            Get
                Return lys_rim
            End Get
            Set(ByVal Value As Decimal)
                lys_rim = Value
            End Set
        End Property
        Property klengation_rim() As Decimal
            Get
                Return lklengation_rim
            End Get
            Set(ByVal Value As Decimal)
                lklengation_rim = Value
            End Set
        End Property
        Property rednarea_rim() As Decimal
            Get
                Return lrednarea_rim
            End Get
            Set(ByVal Value As Decimal)
                lrednarea_rim = Value
            End Set
        End Property
        Property uts_plate() As Decimal
            Get
                Return luts_plate
            End Get
            Set(ByVal Value As Decimal)
                luts_plate = Value
            End Set
        End Property
        Property ys_plate() As Decimal
            Get
                Return lys_plate
            End Get
            Set(ByVal Value As Decimal)
                lys_plate = Value
            End Set
        End Property
        Property klengation_plate() As Decimal
            Get
                Return lklengation_plate
            End Get
            Set(ByVal Value As Decimal)
                lklengation_plate = Value
            End Set
        End Property
        Property rednarea_plate() As Decimal
            Get
                Return lrednarea_plate
            End Get
            Set(ByVal Value As Decimal)
                lrednarea_plate = Value
            End Set
        End Property
        Property kurim_a() As Long
            Get
                Return lkurim_a
            End Get
            Set(ByVal Value As Long)
                lkurim_a = Value
            End Set
        End Property
        Property kurim_b() As Long
            Get
                Return lkurim_b
            End Get
            Set(ByVal Value As Long)
                lkurim_b = Value
            End Set
        End Property
        Property kurim_c() As Long
            Get
                Return lkurim_c
            End Get
            Set(ByVal Value As Long)
                lkurim_c = Value
            End Set
        End Property
        Property thick() As Decimal
            Get
                Return lthick
            End Get
            Set(ByVal Value As Decimal)
                lthick = Value
            End Set
        End Property
        Property thin() As Decimal
            Get
                Return lthin
            End Get
            Set(ByVal Value As Decimal)
                lthin = Value
            End Set
        End Property
        Property inclusion() As String
            Get
                Return sinclusion
            End Get
            Set(ByVal Value As String)
                sinclusion = Value
            End Set
        End Property
        Property micro() As String
            Get
                Return smicro
            End Get
            Set(ByVal Value As String)
                smicro = Value
            End Set
        End Property
        Property grain_size() As String
            Get
                Return sgrain_size
            End Get
            Set(ByVal Value As String)
                sgrain_size = Value
            End Set
        End Property
        Property macro() As String
            Get
                Return smacro
            End Get
            Set(ByVal Value As String)
                smacro = Value
            End Set
        End Property
        Property result() As String
            Get
                Return sresult
            End Get
            Set(ByVal Value As String)
                sresult = Value
            End Set
        End Property
        Property remarks() As String
            Get
                Return sremarks
            End Get
            Set(ByVal Value As String)
                sremarks = Value
            End Set
        End Property
        Property TestType() As String
            Get
                Return sTestType
            End Get
            Set(ByVal Value As String)
                sTestType = Value
            End Set
        End Property
#End Region
#Region "  Methods"
        Private Sub iniVals()
            sQTimeSec = ""
            sQTimeMin = ""
            sQuencherNo = ""
            sHC3 = ""
            sHC2 = ""
            sHC1 = ""
            sHubCooler3 = ""
            sHubCooler2 = ""
            sHubCooler1 = ""
            intDFZone8 = 0
            intDFZone7 = 0
            intDFZone6 = 0
            intDFZone5 = 0
            intDFZone4 = 0
            intDFZone3 = 0
            intDFZone2 = 0
            intDFZone1 = 0
            intNFZone7 = 0
            intNFZone6 = 0
            intNFZone5 = 0
            intNFZone4 = 0
            intNFZone3 = 0
            intNFZone2 = 0
            intNFZone1 = 0
            sNFDischargeTime = ""
            sNFChargeCondition = ""
            sNFChargeTime = ""
            dateNFChargeDate = "1900-01-01"
            sclosure = ""
            datedatetoday = "1900-01-01"
            linitial_gaugelength = 0.0
            lfinal_gaugelength = 0.0
            luts_rim = 0.0
            lys_rim = 0.0
            lklengation_rim = 0.0
            lrednarea_rim = 0.0
            luts_plate = 0.0
            lys_plate = 0.0
            lklengation_plate = 0.0
            lrednarea_plate = 0.0
            lkurim_a = 0.0
            lkurim_b = 0.0
            lkurim_c = 0.0
            sTestType = ""
            sinclusion = ""
            smicro = ""
            sgrain_size = ""
            smacro = ""
            sresult = ""
            sremarks = ""
            lthick = 0
            lthin = 0
        End Sub
        Public Function saveExpWheels(ByVal LabNumber As String, ByVal Mode As String, ByVal Details As String) As Boolean
            Dim oCmd As New SqlClient.SqlCommand()
            oCmd.Connection = rwfGen.Connection.ConObj
            Dim done As New Boolean()
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                If Details = "Results" Then
                    oCmd.Parameters.Add("@lab_number", SqlDbType.VarChar, 50).Value = Me.LabNumber
                    If saveHardnessDeatils(oCmd, Mode) Then
                        If Me.InclusionTable.Rows.Count > 0 Then
                            If saveHardnessInclusions(oCmd, Mode) Then
                                If UpdateWheel(oCmd) Then
                                    done = True
                                End If
                            End If
                        Else
                            If UpdateWheel(oCmd) Then
                                done = True
                            End If
                        End If

                    End If
                ElseIf Details = "Physical" Then
                    If savePhysicalValues(LabNumber, Mode, "Physical") Then
                        done = True
                    End If
                ElseIf Details = "" Then

                ElseIf Details = "" Then

                End If
            Catch exp As Exception
                done = False
                Throw New Exception("Adding of Hardness Details values failed !" & exp.Message)
            Finally
                If done Then
                    oCmd.Transaction.Commit()
                Else
                    oCmd.Transaction.Rollback()
                End If
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End Try
            saveExpWheels = done
        End Function
        Public Function savePhysicalValues(ByVal LabNumber As String, ByVal Mode As String, Optional ByVal type As String = "") As Boolean
            Dim oCmd As New SqlClient.SqlCommand()
            oCmd.Connection = rwfGen.Connection.ConObj
            Dim done As New Boolean()
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                If Mode.ToLower = "add" Then
                    oCmd.CommandText = "insert into ms_wheel_hardness_physical(lab_number," & _
                                " initial_gaugelength , final_gaugelength , closure , uts_rim , " & _
                                " ys_rim , klengation_rim , rednarea_rim , uts_plate , ys_plate , " & _
                                " klengation_plate , rednarea_plate , kurim_a , kurim_b , kurim_c , datetoday ) " & _
                                " values( @lab_number , @initial_gaugelength , @final_gaugelength , " & _
                                " @closure , @uts_rim , @ys_rim , @klengation_rim , @rednarea_rim , " & _
                                " @uts_plate , @ys_plate , @klengation_plate , @rednarea_plate , " & _
                                " @kurim_a , @kurim_b , @kurim_c , @datetoday)"
                Else
                    oCmd.CommandText = " update ms_wheel_hardness_physical set initial_gaugelength = @initial_gaugelength , " & _
                                " final_gaugelength = @final_gaugelength , closure = @closure , uts_rim = @uts_rim , " & _
                                " ys_rim = @ys_rim , klengation_rim = @klengation_rim , rednarea_rim = @rednarea_rim , " & _
                                " uts_plate = @uts_plate , ys_plate = @ys_plate , klengation_plate = @klengation_plate , " & _
                                " rednarea_plate = @rednarea_plate , kurim_a = @kurim_a , kurim_b = @kurim_b , kurim_c = @kurim_c where lab_number = @lab_number "
                End If

                oCmd.Parameters.Add("@lab_number", SqlDbType.VarChar, 50).Value = Me.LabNumber
                oCmd.Parameters.Add("@initial_gaugelength", SqlDbType.Float, 8).Value = linitial_gaugelength
                oCmd.Parameters.Add("@final_gaugelength", SqlDbType.Float, 8).Value = lfinal_gaugelength
                oCmd.Parameters.Add("@closure", SqlDbType.VarChar, 10).Value = sclosure
                oCmd.Parameters.Add("@uts_rim", SqlDbType.Float, 8).Value = luts_rim
                oCmd.Parameters.Add("@ys_rim", SqlDbType.Float, 8).Value = lys_rim
                oCmd.Parameters.Add("@klengation_rim", SqlDbType.Float, 8).Value = lklengation_rim
                oCmd.Parameters.Add("@rednarea_rim", SqlDbType.Float, 8).Value = lrednarea_rim
                oCmd.Parameters.Add("@uts_plate", SqlDbType.Float, 8).Value = luts_plate
                oCmd.Parameters.Add("@ys_plate", SqlDbType.Float, 8).Value = lys_plate
                oCmd.Parameters.Add("@klengation_plate", SqlDbType.Float, 8).Value = lklengation_plate
                oCmd.Parameters.Add("@rednarea_plate", SqlDbType.Float, 8).Value = lrednarea_plate
                oCmd.Parameters.Add("@kurim_a", SqlDbType.Float, 8).Value = lkurim_a
                oCmd.Parameters.Add("@kurim_b", SqlDbType.Float, 8).Value = lkurim_b
                oCmd.Parameters.Add("@kurim_c", SqlDbType.Float, 8).Value = lkurim_c
                oCmd.Parameters.Add("@datetoday", SqlDbType.DateTime, 8).Value = datedatetoday
                If type = "Physical" Then
                    If oCmd.ExecuteNonQuery > 0 Then
                        done = True
                    End If
                Else
                    If oCmd.ExecuteNonQuery > 0 Then
                        If saveHardnessDeatils(oCmd, Mode) Then
                            If saveHardnessInclusions(oCmd, Mode) Then
                                If UpdateWheel(oCmd) Then
                                    done = True
                                End If
                            End If
                        End If
                    End If
                End If
            Catch exp As Exception
                done = False
                Throw New Exception("Adding of Physical values failed !" & exp.Message)
            Finally
                If done Then
                    oCmd.Transaction.Commit()
                Else
                    oCmd.Transaction.Rollback()
                End If
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End Try
            savePhysicalValues = done
        End Function
        Private Function saveHardnessDeatils(ByRef oCmd As SqlClient.SqlCommand, ByVal Mode As String) As Boolean
            Try
                If Mode.ToLower = "add" Then
                    oCmd.CommandText = " insert into ms_wheel_hardness_details( lab_number , micro , grain_size , macro , result , remarks ) " & _
                                   " values( @lab_number , @micro , @grain_size , @macro , @result , @remarks )"

                Else
                    oCmd.CommandText = " update ms_wheel_hardness_details set micro = @micro , grain_size = @grain_size , macro = @macro , result = @result , " & _
                                                   " remarks = @remarks where lab_number = @lab_number "
                End If
                oCmd.Parameters.Add("@micro", SqlDbType.VarChar, 50).Value = smicro & ""
                oCmd.Parameters.Add("@grain_size", SqlDbType.VarChar, 50).Value = IIf(IsNothing(sgrain_size), " ", sgrain_size)
                oCmd.Parameters.Add("@macro", SqlDbType.VarChar, 20).Value = IIf(IsNothing(smacro), " ", smacro)
                oCmd.Parameters.Add("@result", SqlDbType.VarChar, 10).Value = sresult & ""
                oCmd.Parameters.Add("@remarks", SqlDbType.VarChar, 500).Value = sremarks & ""
                saveHardnessDeatils = oCmd.ExecuteNonQuery
            Catch exp As Exception
                saveHardnessDeatils = False
                Throw New Exception(" Addnig Details values failed !" & exp.Message)
            End Try
        End Function
        Private Function saveHardnessInclusions(ByRef oCmd As SqlClient.SqlCommand, ByVal Mode As String) As Boolean
            Dim blnSave As Boolean
            Try
                Dim i As Integer = Nothing
                oCmd.Parameters.Add("@inclusion", SqlDbType.VarChar, 10).Direction = ParameterDirection.Input
                oCmd.Parameters.Add("@thin", SqlDbType.Float, 8).Direction = ParameterDirection.Input
                oCmd.Parameters.Add("@thick", SqlDbType.Float, 8).Direction = ParameterDirection.Input
                oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                If Mode.ToLower = "add" Then
                    oCmd.CommandText = " insert into ms_wheel_hardness_inclusion_details ( lab_number , inclusion , thin , thick  ) " & _
                                   " values( @lab_number , @inclusion , @thin , @thick )"
                    For i = 0 To Me.InclusionTable.Rows.Count - 1
                        blnSave = False
                        oCmd.Parameters("@inclusion").Value = Me.InclusionTable.Rows(i)(1)
                        oCmd.Parameters("@thin").Value = Me.InclusionTable.Rows(i)(2)
                        oCmd.Parameters("@thick").Value = Me.InclusionTable.Rows(i)(3)
                        If oCmd.ExecuteNonQuery <= 0 Then
                            blnSave = False
                            Exit For
                        Else
                            blnSave = True
                        End If
                    Next
                Else
                    For i = 0 To Me.InclusionTable.Rows.Count - 1
                        blnSave = False
                        oCmd.Parameters("@cnt").Value = 0
                        oCmd.Parameters("@inclusion").Value = Me.InclusionTable.Rows(i)(1)
                        oCmd.Parameters("@thin").Value = Me.InclusionTable.Rows(i)(2)
                        oCmd.Parameters("@thick").Value = Me.InclusionTable.Rows(i)(3)
                        oCmd.CommandText = " select @cnt = count(*) from ms_wheel_hardness_inclusion_details  where lab_number = @lab_number and inclusion = @inclusion "
                        oCmd.ExecuteScalar()
                        If IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value) = 0 Then
                            oCmd.CommandText = " insert into ms_wheel_hardness_inclusion_details ( lab_number , inclusion , thin , thick  ) " & _
                                                              " values( @lab_number , @inclusion , @thin , @thick )"
                        Else
                            oCmd.CommandText = " update ms_wheel_hardness_inclusion_details set thin = @thin , thick = @thick " & _
                                                                              " where lab_number = @lab_number and inclusion = @inclusion "
                        End If
                        If oCmd.ExecuteNonQuery <= 0 Then
                            blnSave = False
                            Exit For
                        Else
                            blnSave = True
                        End If
                    Next
                End If
            Catch exp As Exception
                saveHardnessInclusions = blnSave
                Throw New Exception(" Addnig Inclusion Details values failed !" & exp.Message)
            Finally
                saveHardnessInclusions = blnSave
            End Try
        End Function
        Private Function UpdateWheel(ByRef oCmd As SqlClient.SqlCommand) As Boolean
            oCmd.CommandText = " update mm_wheel set closure_test_result = @result where heat_number = " & lHeatNumber & "  and wheel_number = " & lWheelNumber & " "
            Try
                UpdateWheel = oCmd.ExecuteNonQuery
            Catch exp As Exception
                UpdateWheel = False
                Throw New Exception(" updation of mm_wheel failed !" & exp.Message)
            End Try
        End Function
        Public Function saveHTValues(ByVal Whl As Long, ByVal Ht As Long, ByVal Mode As String) As Boolean
            Dim oCmd As New SqlClient.SqlCommand()
            oCmd.Connection = rwfGen.Connection.ConObj
            Dim done As New Boolean()
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                If Mode.Trim.ToLower.Equals("add") Then
                    oCmd.CommandText = " insert into ms_wheel_hardness_htdetails " & _
                                    " ( lab_number , wheel_number , heat_number , NFChargeDate , NFChargeTime , " & _
                                    " NFChargeCondition , NFDischargeTime , NFZone1 , NFZone2 , NFZone3 , NFZone4 , NFZone5 , " & _
                                    " NFZone6 , NFZone7 , DFZone1 , DFZone2 , DFZone3 , DFZone4 , DFZone5 , " & _
                                    " DFZone6 , DFZone7 , DFZone8 , QuencherNo , QTimeMin , QTimeSec , " & _
                                    " HC1 , HC1Code , HC2 ,HC2Code , HC3 , HC3Code ) values " & _
                                    " ( @lab_number , @wheel_number , @heat_number , @NFChargeDate , @NFChargeTime , " & _
                                    " @NFChargeCondition , @NFDischargeTime , @NFZone1 , @NFZone2 , @NFZone3 , @NFZone4 , @NFZone5 , " & _
                                    " @NFZone6 , @NFZone7 , @DFZone1 , @DFZone2 , @DFZone3 , @DFZone4 , @DFZone5 , " & _
                                    " @DFZone6 , @DFZone7 , @DFZone8 , @QuencherNo , @QTimeMin , @QTimeSec , " & _
                                    " @HC1 , @HC1Code , @HC2 , @HC2Code , @HC3 , @HC3Code )"
                Else
                    oCmd.CommandText = " update ms_wheel_hardness_htdetails set " & _
                                    " lab_number = @lab_number , wheel_number = @wheel_number , heat_number = @heat_number , NFChargeDate = @NFChargeDate , NFChargeTime = @NFChargeTime , " & _
                                    " NFChargeCondition = @NFChargeCondition , NFDischargeTime = @NFDischargeTime , NFZone1 = @NFZone1 , NFZone2 = @NFZone2 , NFZone3 = @NFZone3 , NFZone4 = @NFZone4 , NFZone5 = @NFZone5 , " & _
                                    " NFZone6 = @NFZone6 , NFZone7 = @NFZone7 , DFZone1 = @DFZone1 , DFZone2 = @DFZone2 , DFZone3 = @DFZone3 , DFZone4 = @DFZone4 , DFZone5 = @DFZone5 , " & _
                                    " DFZone6 = @DFZone6 , DFZone7 = @DFZone7 , DFZone8 = @DFZone8 , QuencherNo = @QuencherNo , QTimeMin = @QTimeMin , QTimeSec = @QTimeSec , " & _
                                    " HC1 = @HC1 ,HC1Code = @HC1Code , HC2 = @HC2 ,HC2Code = @HC2Code , HC3 = @HC3 , HC3Code = @HC3Code " & _
                                    " where wheel_number = @wheel_number and heat_number = @heat_number "
                End If
                oCmd.Parameters.Add("@wheel_number", SqlDbType.BigInt, 8).Value = Whl
                oCmd.Parameters.Add("@heat_number", SqlDbType.BigInt, 8).Value = Ht

                oCmd.Parameters.Add("@lab_number", SqlDbType.VarChar, 50).Value = sLabNumber.Trim
                oCmd.Parameters.Add("@NFChargeDate", SqlDbType.SmallDateTime, 4).Value = dateNFChargeDate
                oCmd.Parameters.Add("@NFChargeTime", SqlDbType.VarChar, 5).Value = sNFChargeTime.Trim
                oCmd.Parameters.Add("@NFChargeCondition", SqlDbType.VarChar, 4).Value = sNFChargeCondition.Trim
                oCmd.Parameters.Add("@NFDischargeTime", SqlDbType.VarChar, 5).Value = sNFDischargeTime.Trim
                oCmd.Parameters.Add("@NFZone1", SqlDbType.SmallInt, 2).Value = intNFZone1
                oCmd.Parameters.Add("@NFZone2", SqlDbType.SmallInt, 2).Value = intNFZone2
                oCmd.Parameters.Add("@NFZone3", SqlDbType.SmallInt, 2).Value = intNFZone3
                oCmd.Parameters.Add("@NFZone4", SqlDbType.SmallInt, 2).Value = intNFZone4
                oCmd.Parameters.Add("@NFZone5", SqlDbType.SmallInt, 2).Value = intNFZone5
                oCmd.Parameters.Add("@NFZone6", SqlDbType.SmallInt, 2).Value = intNFZone6
                oCmd.Parameters.Add("@NFZone7", SqlDbType.SmallInt, 2).Value = intNFZone7
                oCmd.Parameters.Add("@DFZone1", SqlDbType.SmallInt, 2).Value = intDFZone1
                oCmd.Parameters.Add("@DFZone2", SqlDbType.SmallInt, 2).Value = intDFZone2
                oCmd.Parameters.Add("@DFZone3", SqlDbType.SmallInt, 2).Value = intDFZone3
                oCmd.Parameters.Add("@DFZone4", SqlDbType.SmallInt, 2).Value = intDFZone4
                oCmd.Parameters.Add("@DFZone5", SqlDbType.SmallInt, 2).Value = intDFZone5
                oCmd.Parameters.Add("@DFZone6", SqlDbType.SmallInt, 2).Value = intDFZone6
                oCmd.Parameters.Add("@DFZone7", SqlDbType.SmallInt, 2).Value = intDFZone7
                oCmd.Parameters.Add("@DFZone8", SqlDbType.SmallInt, 2).Value = intDFZone8
                oCmd.Parameters.Add("@QuencherNo", SqlDbType.VarChar, 10).Value = sQuencherNo.Trim
                oCmd.Parameters.Add("@QTimeMin", SqlDbType.VarChar, 2).Value = sQTimeMin.Trim
                oCmd.Parameters.Add("@QTimeSec", SqlDbType.VarChar, 2).Value = sQTimeSec.Trim
                oCmd.Parameters.Add("@HC1", SqlDbType.VarChar, 2).Value = sHC1.Trim
                oCmd.Parameters.Add("@HC2", SqlDbType.VarChar, 2).Value = sHC2.Trim
                oCmd.Parameters.Add("@HC3", SqlDbType.VarChar, 2).Value = sHC3.Trim
                oCmd.Parameters.Add("@HC1Code", SqlDbType.VarChar, 10).Value = sHubCooler1.Trim
                oCmd.Parameters.Add("@HC2Code", SqlDbType.VarChar, 10).Value = sHubCooler2.Trim
                oCmd.Parameters.Add("@HC3Code", SqlDbType.VarChar, 10).Value = sHubCooler3.Trim
                If oCmd.ExecuteNonQuery > 0 Then done = True
            Catch exp As Exception
                done = False
                Throw New Exception("Adding of Physical values failed !" & exp.Message)
            Finally
                If done Then
                    oCmd.Transaction.Commit()
                Else
                    oCmd.Transaction.Rollback()
                End If
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End Try
            saveHTValues = done
        End Function
#End Region
    End Class
    Public Class Equipments
#Region "  Fields"
        Private sMessage, sInstrument, sIdentification, sLocation, sResponsible, sDoneBy, sRange, sTolerance, sCriteria, sFrequencyUnit, sMaintainedBy, sRemarks As String
        Private dateBaseDate, dateCalibrationDueDate, dateCalibrationDoneDate As Date
        Private decFrequencyValue As Decimal
        Private longEquipID, longCalibrationID As Long
        Private blnGeneration, blnCalibrate As Boolean
#End Region
#Region "  Property"
        ReadOnly Property Calibrate() As Boolean
            Get
                Return blnCalibrate
            End Get
        End Property
        Property CalibrationID() As Long
            Get
                Return longCalibrationID
            End Get
            Set(ByVal Value As Long)
                longCalibrationID = Value
            End Set
        End Property
        Property CalibrationDoneDate() As Date
            Get
                Return dateCalibrationDoneDate
            End Get
            Set(ByVal Value As Date)
                dateCalibrationDoneDate = Value
            End Set
        End Property
        Property CalibrationDueDate() As Date
            Get
                Return dateCalibrationDueDate
            End Get
            Set(ByVal Value As Date)
                dateCalibrationDueDate = Value
            End Set
        End Property
        ReadOnly Property Generation() As Boolean
            Get
                Return blnGeneration
            End Get
        End Property
        Property EquipID() As Long
            Get
                Return longEquipID
            End Get
            Set(ByVal Value As Long)
                longEquipID = Value
            End Set
        End Property
        ReadOnly Property Message() As String
            Get
                Return sMessage
            End Get
        End Property
        Property Remarks() As String
            Get
                Return sRemarks
            End Get
            Set(ByVal Value As String)
                sRemarks = Value
            End Set
        End Property
        Property BaseDate() As Date
            Get
                Return dateBaseDate
            End Get
            Set(ByVal Value As Date)
                dateBaseDate = Value
            End Set
        End Property
        Property MaintainedBy() As String
            Get
                Return sMaintainedBy
            End Get
            Set(ByVal Value As String)
                sMaintainedBy = Value
            End Set
        End Property
        Property FrequencyUnit() As String
            Get
                Return sFrequencyUnit
            End Get
            Set(ByVal Value As String)
                sFrequencyUnit = Value
            End Set
        End Property
        Property FrequencyValue() As Decimal
            Get
                Return decFrequencyValue
            End Get
            Set(ByVal Value As Decimal)
                decFrequencyValue = Value
            End Set
        End Property
        Property Criteria() As String
            Get
                Return sCriteria
            End Get
            Set(ByVal Value As String)
                sCriteria = Value
            End Set
        End Property
        Property Tolerance() As String
            Get
                Return sTolerance
            End Get
            Set(ByVal Value As String)
                sTolerance = Value
            End Set
        End Property
        Property Range() As String
            Get
                Return sRange
            End Get
            Set(ByVal Value As String)
                sRange = Value
            End Set
        End Property
        Property DoneBy() As String
            Get
                Return sDoneBy
            End Get
            Set(ByVal Value As String)
                sDoneBy = Value
            End Set
        End Property
        Property Responsible() As String
            Get
                Return sResponsible
            End Get
            Set(ByVal Value As String)
                sResponsible = Value
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
        Property Identification() As String
            Get
                Return sIdentification
            End Get
            Set(ByVal Value As String)
                sIdentification = Value
            End Set
        End Property
        Property Instrument() As String
            Get
                Return sInstrument
            End Get
            Set(ByVal Value As String)
                sInstrument = Value
            End Set
        End Property
#End Region
#Region "  Methods"
        Private Sub IniVals()
            blnCalibrate = False
            dateCalibrationDoneDate = "1900-01-01"
            dateCalibrationDueDate = "1900-01-01"
            longEquipID = 0
            sMessage = ""
            sInstrument = ""
            sIdentification = ""
            sLocation = ""
            sRange = ""
            sResponsible = ""
            sDoneBy = ""
            sFrequencyUnit = ""
            decFrequencyValue = 0.0
            sTolerance = ""
            sCriteria = ""
            dateBaseDate = "1900-01-01"
            sRemarks = ""
            blnGeneration = False
            longCalibrationID = 0
        End Sub
        Public Sub New()
            IniVals()
        End Sub
        Public Sub Save(Optional ByVal EquipID As Long = 0)
            Dim oCmd As New SqlClient.SqlCommand()
            oCmd.Connection = rwfGen.Connection.ConObj
            Dim done As New Boolean()
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                oCmd.CommandText = "insert into ms_MLabEquipments " & _
                            " ( Instrument , Identification , Location , Responsible , DoneBy , Range , Tolerance , Criteria , FrequencyValue , FrequencyUnit , MaintainedBy , BaseDate , Remarks ) " & _
                            " values ( @Instrument , @Identification , @Location , @Responsible , @DoneBy , @Range , @Tolerance , @Criteria , @FrequencyValue , @FrequencyUnit , @MaintainedBy , @BaseDate , @Remarks ) "
                oCmd.Parameters.Add("@Instrument", SqlDbType.VarChar, 250).Value = sInstrument.Trim
                oCmd.Parameters.Add("@Identification", SqlDbType.VarChar, 50).Value = sIdentification.Trim
                oCmd.Parameters.Add("@Location", SqlDbType.VarChar, 50).Value = sLocation.Trim
                oCmd.Parameters.Add("@Responsible", SqlDbType.VarChar, 50).Value = sResponsible.Trim
                oCmd.Parameters.Add("@DoneBy", SqlDbType.VarChar, 50).Value = sDoneBy.Trim
                oCmd.Parameters.Add("@Range", SqlDbType.VarChar, 50).Value = sRange.Trim
                oCmd.Parameters.Add("@Tolerance", SqlDbType.VarChar, 50).Value = sTolerance.Trim
                oCmd.Parameters.Add("@Criteria", SqlDbType.VarChar, 50).Value = sCriteria.Trim
                oCmd.Parameters.Add("@FrequencyValue", SqlDbType.Float, 8).Value = decFrequencyValue
                oCmd.Parameters.Add("@FrequencyUnit", SqlDbType.VarChar, 50).Value = sFrequencyUnit.Trim
                oCmd.Parameters.Add("@MaintainedBy", SqlDbType.VarChar, 50).Value = sMaintainedBy.Trim
                oCmd.Parameters.Add("@BaseDate", SqlDbType.SmallDateTime, 4).Value = CDate(dateBaseDate)
                oCmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = sRemarks.Trim

                oCmd.Parameters.Add("@EquipID", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output

                If oCmd.ExecuteNonQuery > 0 Then
                    oCmd.CommandText = " select @EquipID = EquipID from ms_MLabEquipments " & _
                                    " where  Instrument = @Instrument and Identification = @Identification "
                    oCmd.ExecuteScalar()
                    longEquipID = IIf(IsDBNull(oCmd.Parameters("@EquipID").Value), 0, oCmd.Parameters("@EquipID").Value)
                    sMessage = "Generated EquipID : '" & longEquipID & "' Successfully ! "
                    done = True
                Else
                    sMessage = "Generation of EquipID failed ! "
                End If
            Catch exp As Exception
                done = False
                sMessage = "Adding of MLab Equipments details failed ; " & exp.Message
            Finally
                If done Then
                    oCmd.Transaction.Commit()
                Else
                    oCmd.Transaction.Rollback()
                End If
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End Try
            blnGeneration = done
            done = Nothing
            EquipID = Nothing
        End Sub
        Public Sub SaveCaliData()
            Dim oCmd As New SqlClient.SqlCommand()
            oCmd.Connection = rwfGen.Connection.ConObj
            Dim done As New Boolean()
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                oCmd.Parameters.Add("@EquipID", SqlDbType.BigInt, 8).Value = longEquipID
                oCmd.Parameters.Add("@CalibrationDueDate", SqlDbType.SmallDateTime, 4).Value = CDate(dateCalibrationDueDate)
                oCmd.Parameters.Add("@CalibrationDoneDate", SqlDbType.SmallDateTime, 4).Value = CDate(dateCalibrationDoneDate)
                oCmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = sRemarks.Trim
                oCmd.Parameters.Add("@CalibrationID", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output
                oCmd.CommandText = " insert into ms_MLabEquipments_Calibration ( EquipID , CalibrationDueDate , CalibrationDoneDate , Remarks ) " & _
                            " values ( @EquipID , @CalibrationDueDate , @CalibrationDoneDate , @Remarks ) "
                If oCmd.ExecuteNonQuery = 1 Then
                    oCmd.CommandText = " select @CalibrationID = CalibrationID from ms_MLabEquipments_Calibration where  EquipID = @EquipID and  CalibrationDueDate = @CalibrationDueDate and " & _
                            "  CalibrationDoneDate = @CalibrationDoneDate "
                    oCmd.ExecuteScalar()
                    longCalibrationID = IIf(IsDBNull(oCmd.Parameters("@CalibrationID").Value), 0, oCmd.Parameters("@CalibrationID").Value)
                    sMessage = "Generated CalibrationID : '" & longCalibrationID & "' Successfully ! "
                    done = True
                    blnCalibrate = True
                End If
            Catch exp As Exception
                done = False
                sMessage = exp.Message
            Finally
                If done Then
                    oCmd.Transaction.Commit()
                Else
                    oCmd.Transaction.Rollback()
                End If
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End Try
        End Sub
#End Region
    End Class
    Public Class ChemicalTesting
#Region "  Fields"
        Private sMaterial, sRemarks, sMessage, sCharName, sSpec, sUnit As String
        Private lMaterialID, lTestType, lCharID As Long
        Private dMinValue, dMaxValue, dNominalValue As Double
        Private iOrderBY As Integer
        Private slab_number, sidn_number, sdbr_number, sBatchNo, stested_by, sValue As String
        Private datetest_date, dateexpected_test_date As Date
        Private ssample_batch_number, ssample_number, ssupplier, slorry_number, sreference_note, suser_id As String
        Private inttest_code, intlab_code As Integer
        Private dtLabResults As DataTable
#End Region
#Region "  Property"
        Property BatchNo() As String
            Get
                Return sBatchNo
            End Get
            Set(ByVal Value As String)
                sBatchNo = Value
            End Set
        End Property
        Property Value() As String
            Get
                Return sValue
            End Get
            Set(ByVal Value As String)
                sValue = Value
            End Set
        End Property
        Property CharID() As Long
            Get
                Return lCharID
            End Get
            Set(ByVal Value As Long)
                lCharID = Value
            End Set
        End Property
        Property lab_code() As Integer
            Get
                Return intlab_code
            End Get
            Set(ByVal Value As Integer)
                intlab_code = Value
            End Set
        End Property
        Property test_code() As Integer
            Get
                Return inttest_code
            End Get
            Set(ByVal Value As Integer)
                inttest_code = Value
            End Set
        End Property
        Property sample_batch_number() As String
            Get
                Return ssample_batch_number
            End Get
            Set(ByVal Value As String)
                ssample_batch_number = Value
            End Set
        End Property
        Property sample_number() As String
            Get
                Return ssample_number
            End Get
            Set(ByVal Value As String)
                ssample_number = Value
            End Set
        End Property
        Property supplier() As String
            Get
                Return ssupplier
            End Get
            Set(ByVal Value As String)
                ssupplier = Value
            End Set
        End Property
        Property lorry_number() As String
            Get
                Return slorry_number
            End Get
            Set(ByVal Value As String)
                slorry_number = Value
            End Set
        End Property
        Property reference_note() As String
            Get
                Return sreference_note
            End Get
            Set(ByVal Value As String)
                sreference_note = Value
            End Set
        End Property
        Property user_id() As String
            Get
                Return suser_id
            End Get
            Set(ByVal Value As String)
                suser_id = Value
            End Set
        End Property
        Property test_date() As Date
            Get
                Return datetest_date
            End Get
            Set(ByVal Value As Date)
                datetest_date = Value
            End Set
        End Property
        Property expected_test_date() As Date
            Get
                Return dateexpected_test_date
            End Get
            Set(ByVal Value As Date)
                dateexpected_test_date = Value
            End Set
        End Property
        Property idn_number() As String
            Get
                Return sidn_number
            End Get
            Set(ByVal Value As String)
                sidn_number = Value
            End Set
        End Property
        Property dbr_number() As String
            Get
                Return sdbr_number
            End Get
            Set(ByVal Value As String)
                sdbr_number = Value
            End Set
        End Property
        Property tested_by() As String
            Get
                Return stested_by
            End Get
            Set(ByVal Value As String)
                stested_by = Value
            End Set
        End Property
        Property lab_number() As String
            Get
                Return slab_number
            End Get
            Set(ByVal Value As String)
                slab_number = Value
            End Set
        End Property
        Property Unit() As String
            Get
                Return sUnit
            End Get
            Set(ByVal Value As String)
                sUnit = Value
            End Set
        End Property
        Property Spec() As String
            Get
                Return sSpec
            End Get
            Set(ByVal Value As String)
                sSpec = Value
            End Set
        End Property
        Property OrderBY() As Integer
            Get
                Return iOrderBY
            End Get
            Set(ByVal Value As Integer)
                iOrderBY = Value
            End Set
        End Property
        Property MaxValue() As Double
            Get
                Return dMaxValue
            End Get
            Set(ByVal Value As Double)
                dMaxValue = Value
            End Set
        End Property
        Property NominalValue() As Double
            Get
                Return dNominalValue
            End Get
            Set(ByVal Value As Double)
                dNominalValue = Value
            End Set
        End Property
        Property MinValue() As Double
            Get
                Return dMinValue
            End Get
            Set(ByVal Value As Double)
                dMinValue = Value
            End Set
        End Property
        Property CharName() As String
            Get
                Return sCharName
            End Get
            Set(ByVal Value As String)
                sCharName = Value
            End Set
        End Property
        Property TestType() As Long
            Get
                Return lTestType
            End Get
            Set(ByVal Value As Long)
                lTestType = Value
            End Set
        End Property
        Property MaterialID() As Long
            Get
                Return lMaterialID
            End Get
            Set(ByVal Value As Long)
                lMaterialID = Value
            End Set
        End Property
        Property Material() As String
            Get
                Return sMaterial
            End Get
            Set(ByVal Value As String)
                sMaterial = Value.Trim
            End Set
        End Property
        ReadOnly Property Message() As String
            Get
                Return sMessage
            End Get
        End Property
        Property Remarks() As String
            Get
                Return sRemarks
            End Get
            Set(ByVal Value As String)
                sRemarks = Value.Trim
            End Set
        End Property
        Property LabResults() As DataTable
            Get
                Return dtLabResults
            End Get
            Set(ByVal Value As DataTable)
                dtLabResults = Value
            End Set
        End Property
#End Region
#Region "  Methods"
        Private Sub iniVals()
            dNominalValue = 0
            sBatchNo = ""
            dtLabResults = Nothing
            sValue = ""
            lCharID = 0
            inttest_code = 0
            intlab_code = 0
            ssample_batch_number = ""
            ssample_number = ""
            ssupplier = ""
            slorry_number = ""
            sreference_note = ""
            suser_id = ""
            datetest_date = CDate("1900-01-01")
            slab_number = ""
            sidn_number = ""
            sdbr_number = ""
            stested_by = ""
            sUnit = ""
            sSpec = ""
            iOrderBY = 0
            dMaxValue = 0.0
            dMinValue = 0.0
            sCharName = ""
            lTestType = 0
            lMaterialID = 0
            sMaterial = ""
            sRemarks = ""
            sMessage = ""
            dateexpected_test_date = CDate("1900-01-01")
        End Sub
        Public Sub New()
            iniVals()
        End Sub
        Public Sub SaveLabResults()
            Dim Done As Boolean
            Dim cnt As Int16
            Dim oCmd As SqlClient.SqlCommand
            oCmd = rwfGen.Connection.CmdObj
            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            oCmd.Transaction = oCmd.Connection.BeginTransaction
            Try
                oCmd.Parameters.Add("@result_date", SqlDbType.SmallDateTime, 4).Value = Now.Date
                If Me.LabResults.Rows.Count > 0 Then
                    oCmd.Parameters.Add("@lab_number", SqlDbType.VarChar, 10).Direction = ParameterDirection.Input
                    oCmd.Parameters.Add("@Value", SqlDbType.VarChar, 100).Direction = ParameterDirection.Input
                    oCmd.Parameters.Add("@CharID", SqlDbType.Int, 4).Direction = ParameterDirection.Input
                    oCmd.Parameters.Add("@remarks", SqlDbType.VarChar, 100).Direction = ParameterDirection.Input
                    oCmd.Parameters.Add("@Cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                    For cnt = 0 To Me.LabResults.Rows.Count - 1
                        oCmd.Parameters("@lab_number").Value = LabResults.Rows(cnt)(0)
                        oCmd.Parameters("@CharID").Value = LabResults.Rows(cnt)(1)
                        oCmd.Parameters("@Value").Value = LabResults.Rows(cnt)(2)
                        oCmd.Parameters("@remarks").Value = LabResults.Rows(cnt)(3)
                        oCmd.CommandText = " select @Cnt = count(*) from ms_test_result where  lab_number = @lab_number  and  characteristic_code = @CharID "
                        oCmd.ExecuteScalar()
                        If IIf(IsDBNull(oCmd.Parameters("@Cnt").Value), 0, oCmd.Parameters("@Cnt").Value) = 0 Then
                            oCmd.CommandText = "insert into ms_test_result " & _
                                    " ( lab_number, characteristic_code, result_value , remarks ) " & _
                                    " values ( @lab_number, @CharID, @Value , @remarks ) "
                        Else
                            oCmd.CommandText = " update ms_test_result set result_value = @Value , remarks = @remarks " & _
                                " where  lab_number = @lab_number  and  characteristic_code = @CharID "
                        End If
                        If oCmd.ExecuteNonQuery() = 1 Then
                            oCmd.CommandText = " update ms_test_sample set result_date = @result_date  " & _
                                " where  lab_number = @lab_number  "
                            If oCmd.ExecuteNonQuery() = 1 Then Done = True
                        Else
                            Throw New Exception(" Updation of Chemical Lab results failed !")
                        End If
                    Next
                End If
            Catch exp As Exception
                sMessage = exp.Message
            Finally
                If Not IsNothing(oCmd) Then
                    If Done Then
                        oCmd.Transaction.Commit()
                        sMessage = " Updation Successful !"
                    Else
                        oCmd.Transaction.Rollback()
                    End If
                    If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                    oCmd.Dispose()
                End If
            End Try
        End Sub
        Public Function UpdateLabResults(ByVal lab_number As String, ByVal CharID As String, ByVal result_value As String, ByVal Remarks As String) As String
            Dim Done As Boolean
            Dim oCmd As SqlClient.SqlCommand
            oCmd = rwfGen.Connection.CmdObj
            Try
                oCmd.Parameters.Add("@lab_number", SqlDbType.VarChar, 10).Value = lab_number
                oCmd.Parameters.Add("@remarks", SqlDbType.VarChar, 100).Value = Remarks
                oCmd.Parameters.Add("@result_value", SqlDbType.VarChar, 100).Value = result_value
                oCmd.Parameters.Add("@CharID", SqlDbType.VarChar, 10).Value = CharID
                oCmd.Parameters.Add("@Cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
            Catch exp As Exception
                UpdateLabResults = " InValid Data !"
                Exit Function
            End Try
            Try
                oCmd.CommandText = "select @Cnt = count(*) from  ms_test_result " & _
                " where lab_number = @lab_number and characteristic_code = @CharID "
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction

                oCmd.ExecuteScalar()
                If IIf(IsDBNull(oCmd.Parameters("@Cnt").Value), 0, oCmd.Parameters("@Cnt").Value) = 0 Then
                    oCmd.CommandText = "insert into ms_test_result " & _
                    " ( lab_number, characteristic_code, result_value , remarks ) " & _
                    " values ( @lab_number, @CharID, @result_value , @remarks ) "
                Else
                    oCmd.CommandText = "update ms_test_result set result_value = @result_value , remarks = @remarks" & _
                    " where lab_number = @lab_number and characteristic_code = @CharID "
                End If

                If oCmd.ExecuteNonQuery = 1 Then
                    Done = True
                Else
                    Throw New Exception(" Updation of Chemical Lab Number failed !")
                End If
            Catch exp As Exception
                UpdateLabResults = exp.Message
            Finally
                If Not IsNothing(oCmd) Then
                    If Done Then
                        oCmd.Transaction.Commit()
                        UpdateLabResults = " Updation Successful !"
                    Else
                        oCmd.Transaction.Rollback()
                    End If
                    If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                    oCmd.Dispose()
                End If
            End Try
        End Function
        Public Function UpdateLabNumber(ByVal lab_number As String, ByVal remarks As String, ByVal idn_number As String, ByVal dbr_number As String, ByVal tested_by As String, ByVal sample_batch_number As String, ByVal sample_number As String, ByVal supplier As String, ByVal lorry_number As String, ByVal reference_note As String, ByVal user_id As String, ByVal BatchNo As String, ByVal result_date As Date, ByVal results As String, ByVal POP As String, ByVal expected_test_date As Date) As String
            Dim Done As Boolean
            Dim oCmd As SqlClient.SqlCommand
            oCmd = rwfGen.Connection.CmdObj
            Try
                oCmd.Parameters.Add("@lab_number", SqlDbType.VarChar, 100).Value = lab_number
                oCmd.Parameters.Add("@remarks", SqlDbType.VarChar, 500).Value = remarks
                oCmd.Parameters.Add("@idn_number", SqlDbType.VarChar, 500).Value = idn_number
                oCmd.Parameters.Add("@dbr_number", SqlDbType.VarChar, 500).Value = dbr_number
                oCmd.Parameters.Add("@tested_by", SqlDbType.VarChar, 500).Value = tested_by
                oCmd.Parameters.Add("@sample_batch_number", SqlDbType.VarChar, 500).Value = sample_batch_number
                oCmd.Parameters.Add("@sample_number", SqlDbType.VarChar, 500).Value = sample_number
                oCmd.Parameters.Add("@supplier", SqlDbType.VarChar, 500).Value = supplier
                oCmd.Parameters.Add("@lorry_number", SqlDbType.VarChar, 500).Value = lorry_number
                oCmd.Parameters.Add("@reference_note", SqlDbType.VarChar, 500).Value = reference_note
                oCmd.Parameters.Add("@user_id", SqlDbType.VarChar, 500).Value = user_id
                oCmd.Parameters.Add("@BatchNo", SqlDbType.VarChar, 50).Value = BatchNo
                oCmd.Parameters.Add("@result_date", SqlDbType.SmallDateTime, 4).Value = result_date
                oCmd.Parameters.Add("@results", SqlDbType.VarChar, 1).Value = results
                oCmd.Parameters.Add("@POP", SqlDbType.VarChar, 1).Value = POP
                oCmd.Parameters.Add("@expected_test_date", SqlDbType.SmallDateTime, 4).Value = expected_test_date
            Catch exp As Exception
                UpdateLabNumber = " InValid Data !"
                Exit Function
            End Try
            Try
                oCmd.CommandText = "update ms_test_sample " & _
                     " set remarks = @remarks , idn_number = @idn_number , dbr_number = @dbr_number , tested_by = @tested_by , " & _
                     " sample_batch_number = @sample_batch_number , sample_number = @sample_number , " & _
                     " supplier = @supplier , lorry_number = @lorry_number , reference_note = @reference_note , " & _
                     " user_id = @user_id  , BatchNo = @BatchNo  , result_date = @result_date , results = @results " & _
                     " , POP = @POP , expected_test_date = @expected_test_date where lab_number = @lab_number "

                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                If oCmd.ExecuteNonQuery = 1 Then
                    Done = True
                Else
                    Throw New Exception(" Updation of Chemical Lab Number failed !")
                End If
            Catch exp As Exception
                UpdateLabNumber = exp.Message
            Finally
                If Not IsNothing(oCmd) Then
                    If Done Then
                        oCmd.Transaction.Commit()
                        UpdateLabNumber = " Updation Successful !"
                    Else
                        oCmd.Transaction.Rollback()
                    End If
                    If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                    oCmd.Dispose()
                End If
            End Try
        End Function
        Public Sub SaveLabNumber(ByVal TestID As Integer, ByVal MaterialID As Integer)
            Dim Done As Boolean
            Dim oCmd As SqlClient.SqlCommand
            oCmd = rwfGen.Connection.CmdObj

            Try
                oCmd.Parameters.Add("@lab_number", SqlDbType.VarChar, 100).Value = slab_number
                oCmd.Parameters.Add("@remarks", SqlDbType.VarChar, 500).Value = sRemarks
                oCmd.Parameters.Add("@idn_number", SqlDbType.VarChar, 500).Value = sidn_number
                oCmd.Parameters.Add("@dbr_number", SqlDbType.VarChar, 500).Value = sdbr_number
                oCmd.Parameters.Add("@tested_by", SqlDbType.VarChar, 500).Value = stested_by
                oCmd.Parameters.Add("@sample_batch_number", SqlDbType.VarChar, 500).Value = ssample_batch_number
                oCmd.Parameters.Add("@sample_number", SqlDbType.VarChar, 500).Value = ssample_number
                oCmd.Parameters.Add("@supplier", SqlDbType.VarChar, 500).Value = ssupplier
                oCmd.Parameters.Add("@lorry_number", SqlDbType.VarChar, 500).Value = slorry_number
                oCmd.Parameters.Add("@reference_note", SqlDbType.VarChar, 500).Value = sreference_note
                oCmd.Parameters.Add("@user_id", SqlDbType.VarChar, 500).Value = suser_id
                oCmd.Parameters.Add("@test_date", SqlDbType.SmallDateTime, 4).Value = datetest_date
                oCmd.Parameters.Add("@lab_code", SqlDbType.Int, 4).Value = MaterialID
                oCmd.Parameters.Add("@test_code", SqlDbType.Int, 4).Value = TestID
                oCmd.Parameters.Add("@BatchNo", SqlDbType.VarChar, 50).Value = sBatchNo
                oCmd.Parameters.Add("@expected_test_date", SqlDbType.SmallDateTime, 4).Value = dateexpected_test_date
            Catch exp As Exception
                sMessage = " InValid Data !"
                Exit Sub
            End Try
            Try
                oCmd.CommandText = "insert into ms_test_sample " & _
                     " ( lab_number, remarks, idn_number, dbr_number, tested_by, " & _
                     "  test_date, test_code, lab_code , sample_batch_number, sample_number, " & _
                     " supplier, lorry_number, reference_note, user_id , BatchNo , expected_test_date ) " & _
                     " values ( @lab_number, @remarks, @idn_number, @dbr_number, @tested_by," & _
                     " @test_date, @test_code, @lab_code , @sample_batch_number, @sample_number, " & _
                     " @supplier, @lorry_number, @reference_note, @user_id , @BatchNo , @expected_test_date ) "

                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                If oCmd.ExecuteNonQuery = 1 Then
                    Done = True
                Else
                    Throw New Exception(" Generation of Chemical Lab Number failed !")
                End If
            Catch exp As Exception
                sMessage = exp.Message
            Finally
                If Not IsNothing(oCmd) Then
                    If Done Then
                        oCmd.Transaction.Commit()
                        sMessage = " Updation Successful !"
                    Else
                        oCmd.Transaction.Rollback()
                    End If
                    If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                    oCmd.Dispose()
                End If
            End Try
        End Sub
        Public Sub SaveMaterialCharacteristics(Optional ByVal CharID As Integer = 0)
            Dim Done As Boolean
            Dim oCmd As SqlClient.SqlCommand
            oCmd = rwfGen.Connection.CmdObj

            Try
                oCmd.Parameters.Add("@CharName", SqlDbType.VarChar, 500).Value = sCharName
                oCmd.Parameters.Add("@MinValue", SqlDbType.Float, 8).Value = dMinValue
                oCmd.Parameters.Add("@MaxValue", SqlDbType.Float, 8).Value = dMaxValue
                oCmd.Parameters.Add("@NominalValue", SqlDbType.Float, 8).Value = dNominalValue
                oCmd.Parameters.Add("@MaterialID", SqlDbType.BigInt, 8).Value = lMaterialID
                oCmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 50).Value = sRemarks
                oCmd.Parameters.Add("@Unit", SqlDbType.VarChar, 50).Value = sUnit
                oCmd.Parameters.Add("@CharID", SqlDbType.BigInt, 8).Value = Val(CharID)
                oCmd.Parameters.Add("@OrderBY", SqlDbType.Int, 4).Value = iOrderBY
            Catch exp As Exception
                sMessage = " InValid Data !"
                Exit Sub
            End Try
            Try
                If CharID = 0 Then
                    oCmd.CommandText = "insert into ms_ChemicalTesting_MaterialCharacteristics " & _
                         " ( CharName , MinValue , MaxValue , Remarks , MaterialID , OrderBY , Unit  , NominalValue ) " & _
                         " values ( @CharName , @MinValue , @MaxValue , @Remarks , @MaterialID , @OrderBY  , @Unit , @NominalValue ) "
                Else
                    oCmd.CommandText = " Update ms_ChemicalTesting_MaterialCharacteristics " & _
                            " set CharName = @CharName , Remarks = @Remarks , NominalValue = @NominalValue , " & _
                            " MinValue = @MinValue , MaxValue = @MaxValue , OrderBY = @OrderBY , Unit = @Unit " & _
                            " where MaterialID = @MaterialID and  CharID = @CharID "
                End If
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                If oCmd.ExecuteNonQuery = 1 Then
                    Done = True
                Else
                    Throw New Exception(" updation of Chemical Testing Master data failed !")
                End If
            Catch exp As Exception
                sMessage = exp.Message
            Finally
                If Not IsNothing(oCmd) Then
                    If Done Then
                        oCmd.Transaction.Commit()
                        sMessage = " Updation Successful !"
                    Else
                        oCmd.Transaction.Rollback()
                    End If
                    If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                    oCmd.Dispose()
                End If
            End Try
            oCmd = Nothing
        End Sub
        Public Sub SaveMaterialList(Optional ByVal MaterialID As Integer = 0)
            Dim Done As Boolean
            Dim oCmd As SqlClient.SqlCommand
            oCmd = rwfGen.Connection.CmdObj

            Try
                oCmd.Parameters.Add("@TestType", SqlDbType.BigInt, 8).Value = lTestType
                oCmd.Parameters.Add("@Material", SqlDbType.VarChar, 50).Value = sMaterial
                oCmd.Parameters.Add("@Spec", SqlDbType.VarChar, 50).Value = sSpec
                oCmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 50).Value = sRemarks
                oCmd.Parameters.Add("@MaterialID", SqlDbType.BigInt, 8).Value = Val(MaterialID)
            Catch exp As Exception
                sMessage = " InValid Data !"
                Exit Sub
            End Try
            Try
                If MaterialID = 0 Then
                    oCmd.CommandText = "insert into ms_ChemicalTesting_MaterialList " & _
                                                    " ( Material , Spec , Remarks , TestType ) " & _
                                                    " values ( @Material , @Spec , @Remarks , @TestType   ) "
                Else
                    oCmd.CommandText = " Update ms_ChemicalTesting_MaterialList " & _
                            " set Material = @Material , Remarks = @Remarks , Spec = @Spec " & _
                            " where MaterialID = @MaterialID and  TestType = @TestType "
                End If
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                If oCmd.ExecuteNonQuery = 1 Then
                    Done = True
                Else
                    Throw New Exception(" updation of Chemical Testing Master data failed !")
                End If
            Catch exp As Exception
                sMessage = exp.Message
            Finally
                If Not IsNothing(oCmd) Then
                    If Done Then
                        oCmd.Transaction.Commit()
                        sMessage = " Updation Successful !"
                    Else
                        oCmd.Transaction.Rollback()
                    End If
                    If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                    oCmd.Dispose()
                End If
            End Try
        End Sub
        Public Function SaveSandSample(ByVal batch_number As String, ByVal sand_cts As Decimal, ByVal sand_hts As Decimal, ByVal sand_stick_point As Decimal, ByVal date_prepared As Date, ByVal shift_code As String, ByVal date_tested As Date, ByVal operator1 As String, ByVal test_status As String, ByVal expected_test_date As Date) As Boolean
            Dim Done As Boolean
            Dim oCmd As SqlClient.SqlCommand
            oCmd = rwfGen.Connection.CmdObj

            Try
                oCmd.Parameters.Add("@batch_number", SqlDbType.VarChar, 50).Value = batch_number
                oCmd.Parameters.Add("@sand_cts", SqlDbType.Float, 8).Value = sand_cts
                oCmd.Parameters.Add("@sand_hts", SqlDbType.Float, 8).Value = sand_hts
                oCmd.Parameters.Add("@sand_stick_point", SqlDbType.Float, 8).Value = sand_stick_point
                oCmd.Parameters.Add("@date_prepared", SqlDbType.SmallDateTime, 4).Value = date_prepared
                oCmd.Parameters.Add("@shift_code", SqlDbType.VarChar, 10).Value = shift_code
                oCmd.Parameters.Add("@date_tested", SqlDbType.SmallDateTime, 4).Value = date_tested
                oCmd.Parameters.Add("@operator", SqlDbType.VarChar, 50).Value = operator1
                oCmd.Parameters.Add("@test_status", SqlDbType.VarChar, 1).Value = test_status
                oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                oCmd.Parameters.Add("@expected_test_date", SqlDbType.SmallDateTime, 4).Value = expected_test_date
            Catch exp As Exception
                sMessage = " InValid Data !"
                Exit Function
            End Try
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                oCmd.CommandText = "select @cnt = count(*) from mm_sand_preparation " &
                    " where batch_number = @batch_number and shift_code = @shift_code and date_prepared = @date_prepared"
                oCmd.ExecuteScalar()
                If IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value) = 0 Then
                    oCmd.CommandText = "INSERT INTO mm_sand_preparation  " &
                        " ( batch_number , sand_cts , sand_hts , sand_stick_point , date_prepared , shift_code , date_tested , operator )" &
                        " values ( @batch_number , @sand_cts , @sand_hts , @sand_stick_point , @date_prepared , @shift_code , @date_tested , @operator) "
                Else
                    oCmd.CommandText = " Update mm_sand_preparation " &
                            " set sand_cts = @sand_cts , sand_hts = @sand_hts , sand_stick_point = @sand_stick_point  , " &
                            " date_tested = @date_tested , operator = @operator " &
                            " where batch_number = @batch_number and shift_code = @shift_code and date_prepared = @date_prepared "
                End If

                If oCmd.ExecuteNonQuery = 1 Then
                    oCmd.CommandText = " Update mm_sand_system " &
                            " set sample_cts = @sand_cts , sample_hts = @sand_hts , sample_stick_point = @sand_stick_point  , " &
                            " test_status = @test_status , expected_test_date = @expected_test_date " &
                            " where sample_batch_number = @batch_number and shift_code = @shift_code and sand_date = @date_prepared "
                    If oCmd.ExecuteNonQuery = 1 Then
                        Done = True
                    End If
                Else
                    Throw New Exception(" updation of Sand Testing data failed !")
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If Not IsNothing(oCmd) Then
                    If Done Then
                        oCmd.Transaction.Commit()
                        sMessage = " Updation Successful !"
                    Else
                        oCmd.Transaction.Rollback()
                    End If
                    If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                    oCmd.Dispose()
                End If
            End Try
            Return Done
        End Function
        Public Function SaveSpectro(ByVal heat_number As Long, ByVal car_car As Decimal, ByVal man_man As Decimal, ByVal sil_sil As Decimal, ByVal pho_pho As Decimal, ByVal sul_sul As Decimal, ByVal chr_chr As Decimal, ByVal cop_cop As Decimal, ByVal alu_alu As Decimal, ByVal Ven_Ven As Decimal, ByVal moly_moly As Decimal, ByVal nitro_nitro As Decimal, ByVal hydro_hydro As Decimal) As Boolean
            Dim Done As Boolean
            Dim oCmd As SqlClient.SqlCommand
            oCmd = rwfGen.Connection.CmdObj
            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            Try
                oCmd.Parameters.Add("@heat_number", SqlDbType.BigInt, 8).Value = heat_number
                oCmd.Parameters.Add("@sample_number", SqlDbType.VarChar, 10).Value = "JMP"
                oCmd.Parameters.Add("@car_car", SqlDbType.Float, 8).Value = car_car
                oCmd.Parameters.Add("@man_man", SqlDbType.Float, 8).Value = man_man
                oCmd.Parameters.Add("@sil_sil", SqlDbType.Float, 8).Value = sil_sil
                oCmd.Parameters.Add("@pho_pho", SqlDbType.Float, 8).Value = pho_pho
                oCmd.Parameters.Add("@sul_sul", SqlDbType.Float, 8).Value = sul_sul
                oCmd.Parameters.Add("@chr_chr", SqlDbType.Float, 8).Value = chr_chr
                oCmd.Parameters.Add("@cop_cop", SqlDbType.Float, 8).Value = cop_cop
                oCmd.Parameters.Add("@alu_alu", SqlDbType.Float, 8).Value = alu_alu
                oCmd.Parameters.Add("@Ven_Ven", SqlDbType.Float, 8).Value = Ven_Ven
                oCmd.Parameters.Add("@moly_moly", SqlDbType.Float, 8).Value = moly_moly
                oCmd.Parameters.Add("@nitro_nitro", SqlDbType.Float, 8).Value = nitro_nitro
                oCmd.Parameters.Add("@hydro_hydro", SqlDbType.Float, 8).Value = hydro_hydro

                oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                oCmd.CommandText = "select @cnt = count(*) FROM mm_spectro_results " & _
                    " WHERE heat_number = @heat_number and sample_number = @sample_number "
                oCmd.ExecuteScalar()
                Done = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)
                If Done Then
                    Done = False
                    oCmd.CommandText = "update mm_spectro_results " & _
                        " set car_car = @car_car , sil_sil = @sil_sil ," & _
                        " man_man = @man_man , pho_pho = @pho_pho , sul_sul = @sul_sul , chr_chr = @chr_chr , " & _
                        " cop_cop = @cop_cop , alu_alu = @alu_alu , Ven_Ven = @Ven_Ven , moly_moly = @moly_moly , " & _
                        " nitro_nitro = @nitro_nitro ,  hydro_hydro = @hydro_hydro  " & _
                        " where heat_number = @heat_number and sample_number = @sample_number "
                Else
                    oCmd.CommandText = "insert into mm_spectro_results   " & _
                        " ( heat_number , sample_number ,  car_car , man_man , sil_sil , pho_pho , sul_sul , chr_chr , " & _
                        " cop_cop , alu_alu , Ven_Ven , moly_moly , nitro_nitro , hydro_hydro ) " & _
                        " values ( @heat_number , @sample_number , @car_car , @man_man , @sil_sil , @pho_pho , @sul_sul , @chr_chr , " & _
                        " @cop_cop , @alu_alu , @Ven_Ven , @moly_moly , @nitro_nitro , @hydro_hydro ) "
                End If
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                If oCmd.ExecuteNonQuery = 1 Then
                    Done = True
                Else
                    Exit Function
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If Not IsNothing(oCmd) Then
                    If Done Then
                        oCmd.Transaction.Commit()
                    Else
                        oCmd.Transaction.Rollback()
                    End If
                    If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                    oCmd.Dispose()
                End If
            End Try
            Return Done
        End Function
#End Region
    End Class
    Public Class AxleCastTest
        Public Function UpdateCastGroup(ByVal ProductCode As String, ByVal CastGroup As String) As Boolean
            Dim oCmd As New SqlClient.SqlCommand()
            oCmd.Connection = rwfGen.Connection.ConObj
            Dim blnDone As Boolean
            Try
                oCmd.Parameters.Add("@product_code", SqlDbType.VarChar, 50).Direction = ParameterDirection.Input
                oCmd.Parameters("@product_code").Value = ProductCode
                oCmd.Parameters.Add("@cast_group", SqlDbType.VarChar, 50).Direction = ParameterDirection.Input
                oCmd.Parameters("@cast_group").Value = CastGroup
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.CommandText = " update mm_product_master set cast_group = @cast_group where product_code = @product_code"
                If oCmd.ExecuteNonQuery() > 0 Then blnDone = True
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End Try
            Return blnDone
        End Function
        Public Function UpdateR43R16SpecsTable()
            Dim blnDone As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.Transaction = cmd.Connection.BeginTransaction
                cmd.CommandText = " insert into mm_AxleProductMaster_R43R16Specs ( product_code , R43R16 ) " & _
                        " select a.product_code, '' from mm_product_master a left outer join mm_AxleProductMaster_R43R16Specs b " & _
                        " on a.product_code = b.product_code where a.product_code like '[3,4]%' and r43r16 is null "
                If cmd.ExecuteNonQuery > 0 Then blnDone = True
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If IsNothing(cmd) = False Then
                    If blnDone Then cmd.Transaction.Commit() Else cmd.Transaction.Rollback()
                    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                    cmd.Dispose()
                End If
            End Try
            Return blnDone
        End Function
        Public Function CasttestPhysicalValues(ByVal axle_number As String, ByVal test_date As Date, ByVal lab_number As String, ByVal ut_strength As Decimal, ByVal yield_strength As Decimal, ByVal elongation As Decimal, ByVal reduction As Decimal, ByVal charpy As Decimal, ByVal astm As String, ByVal macro_vert As String, ByVal macro_long As String, ByVal remarks As String, ByVal result As String) As Boolean
            Dim Done As Boolean
            Dim oCmd As SqlClient.SqlCommand
            oCmd = rwfGen.Connection.CmdObj
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                oCmd.CommandText = "select @cnt = count(*) from ms_casttest_physical where lab_number = @lab_number "
                oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                oCmd.Parameters.Add("@axle_number", SqlDbType.VarChar, 50).Value = axle_number
                oCmd.Parameters.Add("@lab_number", SqlDbType.VarChar, 10).Value = lab_number
                oCmd.Parameters.Add("@ut_strength", SqlDbType.Float, 8).Value = ut_strength
                oCmd.Parameters.Add("@yield_strength", SqlDbType.Float, 8).Value = yield_strength
                oCmd.Parameters.Add("@elongation", SqlDbType.Float, 8).Value = elongation
                oCmd.Parameters.Add("@reduction", SqlDbType.Float, 8).Value = reduction
                oCmd.Parameters.Add("@charpy", SqlDbType.Float, 8).Value = charpy
                oCmd.Parameters.Add("@astm", SqlDbType.VarChar, 50).Value = astm
                oCmd.Parameters.Add("@macro_vert", SqlDbType.VarChar, 50).Value = macro_vert
                oCmd.Parameters.Add("@macro_long", SqlDbType.VarChar, 50).Value = macro_long
                oCmd.Parameters.Add("@remarks", SqlDbType.VarChar, 50).Value = remarks
                oCmd.Parameters.Add("@test_date", SqlDbType.SmallDateTime, 4).Value = test_date
                oCmd.Parameters.Add("@result", SqlDbType.VarChar, 1).Value = result
                oCmd.ExecuteScalar()
                If IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value) = 0 Then
                    oCmd.CommandText = "insert into ms_casttest_physical( lab_number , ut_strength , " & _
                    " yield_strength , elongation , reduction , charpy , astm , macro_vert , " & _
                    " macro_long , remarks , test_date ) values ( @lab_number , @ut_strength , " & _
                    " @yield_strength , @elongation , @reduction , @charpy , @astm , @macro_vert , " & _
                    " @macro_long , @remarks , @test_date ) "
                Else
                    oCmd.CommandText = "update ms_casttest_physical set ut_strength = @ut_strength , " & _
                    " yield_strength = @yield_strength , elongation = @elongation , reduction = @reduction , " & _
                    " charpy = @charpy , astm = @astm , macro_vert = @macro_vert , " & _
                    " macro_long = @macro_long , remarks = @remarks , test_date = @test_date " & _
                    " where lab_number = @lab_number "
                End If
                If oCmd.ExecuteNonQuery = 1 Then
                    oCmd.CommandText = "update ms_cast_test_sample  " & _
                        " set result = @result , received_date = @test_date , " & _
                        " test_date = @test_date where lab_number = @lab_number "
                    If oCmd.ExecuteNonQuery = 1 Then
                        If axle_number.Trim.StartsWith("RWF") Then
                            oCmd.CommandText = " update mm_nonrwf_axles set cast_result = @result  " & _
                                    " where axle_number = @axle_number "
                        Else
                            oCmd.CommandText = " update mm_axle_master set cast_result = @result  " & _
                                    " where axle_number = @axle_number "
                        End If
                        If oCmd.ExecuteNonQuery > 0 Then Done = True
                    End If
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If Not IsNothing(oCmd) Then
                    If Done Then
                        oCmd.Transaction.Commit()
                    Else
                        oCmd.Transaction.Rollback()
                    End If
                    If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                    oCmd.Dispose()
                End If
            End Try
            Return Done
        End Function
        Public Function UpdateValues(ByVal lab_number As String, ByVal test_date As Date, ByVal charpy As Decimal) As Boolean
            Dim Done As Boolean
            Dim oCmd As SqlClient.SqlCommand
            oCmd = rwfGen.Connection.CmdObj
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                oCmd.CommandText = "update ms_casttest_physical set charpy = @charpy , " & _
                    " test_date = @test_date " & _
                    " where lab_number = @lab_number "
                oCmd.Parameters.Add("@lab_number", SqlDbType.VarChar, 10).Value = lab_number
                oCmd.Parameters.Add("@charpy", SqlDbType.Float, 8).Value = charpy
                oCmd.Parameters.Add("@test_date", SqlDbType.SmallDateTime, 4).Value = test_date
                If oCmd.ExecuteNonQuery = 1 Then Done = True
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If Not IsNothing(oCmd) Then
                    If Done Then
                        oCmd.Transaction.Commit()
                    Else
                        oCmd.Transaction.Rollback()
                    End If
                    If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                    oCmd.Dispose()
                End If
            End Try
            Return Done
        End Function
        Public Function CastTestSample(ByVal sent_date As Date, ByVal shift_code As String, ByVal operator_code As String, ByVal axle_number As String, ByVal remarks As String, ByVal lab_number As String, ByVal cast_number As String, ByVal cast_group As String, ByVal drawing_number As String) As Boolean
            Dim Done As Boolean
            Dim oCmd As SqlClient.SqlCommand
            oCmd = rwfGen.Connection.CmdObj
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                oCmd.CommandText = "insert into ms_cast_test_sample ( " & _
                    " sent_date , shift_code , operator_code , axle_number , remarks , lab_number , " & _
                    " cast_number , cast_group , drawing_number ) values (  " & _
                    " @sent_date , @shift_code , @operator_code , @axle_number , @remarks , @lab_number , " & _
                    " @cast_number , @cast_group , @drawing_number ) "
                oCmd.Parameters.Add("@sent_date", SqlDbType.SmallDateTime, 4).Value = sent_date
                oCmd.Parameters.Add("@shift_code", SqlDbType.VarChar, 1).Value = shift_code
                oCmd.Parameters.Add("@operator_code", SqlDbType.VarChar, 10).Value = operator_code.Trim
                oCmd.Parameters.Add("@axle_number", SqlDbType.VarChar, 10).Value = axle_number
                oCmd.Parameters.Add("@remarks", SqlDbType.VarChar, 30).Value = remarks.Trim
                oCmd.Parameters.Add("@lab_number", SqlDbType.VarChar, 10).Value = lab_number
                oCmd.Parameters.Add("@cast_number", SqlDbType.VarChar, 50).Value = cast_number.Trim
                oCmd.Parameters.Add("@cast_group", SqlDbType.VarChar, 10).Value = cast_group.Trim
                oCmd.Parameters.Add("@drawing_number", SqlDbType.VarChar, 50).Value = drawing_number
                If oCmd.ExecuteNonQuery = 1 Then Done = True
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If Not IsNothing(oCmd) Then
                    If Done Then
                        oCmd.Transaction.Commit()
                    Else
                        oCmd.Transaction.Rollback()
                    End If
                    If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                    oCmd.Dispose()
                End If
            End Try
            Return Done
        End Function
        Public Function NonRWFAxleLabNo(ByVal txtDate As Date, ByVal Shift As String, ByVal Operator1 As String, ByVal AxleNo As String, ByVal Remarks As String, ByVal lab_number As String, ByVal Cast_no As String, ByVal Cast_grp As String, ByVal Drawing_no As String, ByVal PcoRef As String, ByVal PcoRefId As Double, ByVal ProductCode As String, ByVal CastTestCertNo As String, ByVal CastCertificateDate As Date) As Boolean
            Dim blnDone As Boolean
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            Try
                cmd.Parameters.Add("@txtDate", SqlDbType.SmallDateTime, 4).Value = txtDate
                cmd.Parameters.Add("@rblShift", SqlDbType.VarChar, 1).Value = Shift
                cmd.Parameters.Add("@txtOperator_code", SqlDbType.VarChar, 6).Value = Operator1
                cmd.Parameters.Add("@txtAxle_number", SqlDbType.VarChar, 50).Value = AxleNo
                cmd.Parameters.Add("@txtRemarks", SqlDbType.VarChar, 30).Value = Remarks
                cmd.Parameters.Add("@txtlab_number", SqlDbType.VarChar, 10).Value = lab_number
                cmd.Parameters.Add("@CastNumber", SqlDbType.VarChar, 50).Value = Cast_no
                cmd.Parameters.Add("@cast_group", SqlDbType.VarChar, 10).Value = Cast_grp
                cmd.Parameters.Add("@drawing_number", SqlDbType.VarChar, 50).Value = Drawing_no
                cmd.Parameters.Add("@Result", SqlDbType.VarChar, 1).Value = PcoRef
                cmd.Parameters.Add("@RitesReference", SqlDbType.BigInt, 8).Value = PcoRefId
                cmd.Parameters.Add("@Product_Code", SqlDbType.VarChar, 6).Value = ProductCode
                cmd.Parameters.Add("@CastCertificateNumber", SqlDbType.VarChar, 100).Value = CastTestCertNo
                cmd.Parameters.Add("@CastCertificateDate", SqlDbType.SmallDateTime, 4).Value = CastCertificateDate
                cmd.Parameters.Add("@SaveDateTime", SqlDbType.DateTime, 8).Value = CDate(Now)
                blnDone = True
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally

            End Try
            If blnDone = False Then
                Exit Function
            Else
                blnDone = False
            End If
            Try
                Dim sqlstr As String = "insert into ms_cast_test_sample ( sent_date,shift_code,operator_code,axle_number,remarks,lab_number,cast_number,cast_group,drawing_number, result,test_date) values("
                sqlstr &= "@txtDate,@rblShift,@txtOperator_code,@txtAxle_number,@txtRemarks,@txtlab_number,@CastNumber,@cast_group,@drawing_number, @result , @txtDate )"

                Dim sqlstr3 As String = " insert into mm_Nonrwf_Axles_CertificateBasedCastResults  " &
                " (RitesReference, CastNumber, Drawing_number, Cast_Group, Result, Product_Code, CastCertificateNumber, CastCertificateDate, Lab_Number, LabEmpCode, SaveDateTime, SampleDate, SampleShift ) " &
                " values " &
                " (@RitesReference, @CastNumber, @Drawing_number, @Cast_Group, @Result, @Product_Code, @CastCertificateNumber, @CastCertificateDate, @txtlab_number, @txtOperator_code, @SaveDateTime, @txtDate, @rblShift) "
                If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
                cmd.CommandText = sqlstr
                cmd.Transaction = cmd.Connection.BeginTransaction
                If cmd.ExecuteNonQuery = 1 Then
                    cmd.CommandText = sqlstr3
                    If cmd.ExecuteNonQuery = 1 Then blnDone = True
                End If
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If blnDone Then
                    cmd.Transaction.Commit()
                Else
                    cmd.Transaction.Rollback()
                End If
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
            End Try
            Return blnDone
        End Function
        Public Function UpdateAxleProductMaster_R43R16Specs(ByVal ProductCode As String, ByVal Specs As String)
            Dim blnDone As Boolean
            Try
                Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
                cmd.Parameters.Add("@Product_code", SqlDbType.VarChar, 6)
                cmd.Parameters("@Product_code").Direction = ParameterDirection.Input
                cmd.Parameters.Add("@R43R16", SqlDbType.VarChar, 4)
                cmd.Parameters("@R43R16").Direction = ParameterDirection.Input
                Try
                    cmd.Parameters("@Product_code").Value = ProductCode
                    cmd.Parameters("@R43R16").Value = Specs
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
                    cmd.CommandText = " update mm_AxleProductMaster_R43R16Specs set  R43R16 = @R43R16 where Product_code = @Product_code"
                    If cmd.ExecuteNonQuery > 0 Then blnDone = True
                Catch exp As Exception
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
            Catch exp As Exception
                Throw New Exception(exp.Message)
            End Try
            Return blnDone
        End Function
    End Class
    Friend Class WheelSample
        Inherits metLab.WheelHardness
        Public Shared Function LabNumberList() As DataTable
            Dim ds As New DataSet()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = "ms_sp_LabNumberList"
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.Fill(ds)
                LabNumberList = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function getPreviousHeats() As DataTable
            Dim ds As New DataSet()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Try
                da.SelectCommand.CommandText = "select heat_from HeatFrom , heat_to HeatTo , " & _
                    " lab_number LabNo , Wheel , wheel_type WheelDescription , test_type TestType " & _
                    " from ms_wheel_hardness_sample " & _
                    " where sent_date = (select max(sent_date) from ms_wheel_hardness_sample) "
                da.Fill(ds)
                getPreviousHeats = ds.Tables(0)
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                da.Dispose()
                ds.Dispose()
            End Try
        End Function
        Public Shared Function VerifyWheel(ByVal Heat As Long, ByVal Wheel As Long) As Boolean
            Dim oCmd As New SqlClient.SqlCommand()
            oCmd.Connection = rwfGen.Connection.ConObj
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                oCmd.CommandText = " select  @cnt = count(*) from mm_wheel a where ((a.location = 'mopo' and a.status like 'x%') or ((a.location in ('clmt', 'clqc', 'clfq')  and a.status like 'XC%' and a.status not like 'XC8%' ) or ( a.location = 'clfi' and a.status like 'r%'))) " & _
                        " and a.heat_number = " & Heat & " and a.wheel_number = " & Wheel & " "
                oCmd.ExecuteScalar()
                VerifyWheel = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)
            Catch exp As Exception
                VerifyWheel = ""
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End Try
        End Function
        Public Shared Function GetDescription(ByVal Heat As Long, ByVal Wheel As Long) As String
            Dim oCmd As New SqlClient.SqlCommand()
            oCmd.Connection = rwfGen.Connection.ConObj
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Parameters.Add("@description", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                oCmd.CommandText = " select  @description = rtrim(description) from mm_wheel a  " & _
                        " where a.heat_number = " & Heat & " and a.wheel_number = " & Wheel & " "
                oCmd.ExecuteScalar()
                GetDescription = IIf(IsDBNull(oCmd.Parameters("@description").Value), "", oCmd.Parameters("@description").Value)
            Catch exp As Exception
                GetDescription = ""
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End Try
        End Function
        Public Shared Function CheckValidHeatNumber(ByVal Heat As Long) As Integer
            Dim oCmd As New SqlClient.SqlCommand()
            oCmd.Connection = rwfGen.Connection.ConObj
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                oCmd.CommandText = " select  @cnt = count(*) from mm_wheel a  " & _
                        " where a.heat_number = " & Heat & " "
                oCmd.ExecuteScalar()
                CheckValidHeatNumber = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)
            Catch exp As Exception
                CheckValidHeatNumber = 0
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End Try
        End Function
        Public Shared Function IsSampleReceived(ByVal Heat As Long, ByVal Wheel As Long) As Boolean
            Dim oCmd As New SqlClient.SqlCommand()
            oCmd.Connection = rwfGen.Connection.ConObj
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                oCmd.CommandText = " select  @cnt = count(*) from ms_wheel_hardness_sample a  " & _
                        " where a.heat_number = " & Heat & " and a.wheel_number = " & Wheel & " "
                oCmd.ExecuteScalar()
                IsSampleReceived = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)
            Catch exp As Exception
                IsSampleReceived = ""
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End Try
        End Function
        Public Shared Function CheckValidHeatFrom(ByVal WhlType As String) As Integer
            Dim oCmd As New SqlClient.SqlCommand()
            oCmd.Connection = rwfGen.Connection.ConObj
            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Parameters.Add("@WhlType", SqlDbType.VarChar, 50).Value = WhlType.Trim
                oCmd.Parameters.Add("@heat_to", SqlDbType.Int, 4).Direction = ParameterDirection.Output
                oCmd.CommandText = " select  top 1 @heat_to = heat_to  from ms_wheel_hardness_sample" & _
                    " where wheel_type = @WhlType and test_type = 'Regular' " & _
                    " order by heat_to desc "
                oCmd.ExecuteScalar()
                CheckValidHeatFrom = IIf(IsDBNull(oCmd.Parameters("@heat_to").Value), 0, oCmd.Parameters("@heat_to").Value)
            Catch exp As Exception
                CheckValidHeatFrom = 0
                Throw New Exception(exp.Message)
            Finally
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End Try
        End Function
        Public Function SaveSampleWheel(ByVal WhlNo As String, ByVal WheelNumber As Long, ByVal HeatNumber As Long, ByVal HeatFrom As Long, ByVal HeatTo As Long, ByVal LabNumber As String, ByVal inspector As String, ByVal Description As String, ByVal SentDt As Date) As Boolean
            Dim blnDone As Boolean
            Dim oCmd As New SqlClient.SqlCommand()
            oCmd.Connection = rwfGen.Connection.ConObj
            Dim WhlClass As String = IIf(Description.Trim = "BOXN WHL", "A", "B")
            Dim test_type As String = IIf(HeatFrom = HeatTo, "Experimental", "Regular")
            oCmd.Parameters.Add("@wheel_number", SqlDbType.BigInt, 8).Value = WheelNumber
            oCmd.Parameters.Add("@heat_number", SqlDbType.BigInt, 8).Value = HeatNumber
            oCmd.Parameters.Add("@heat_from", SqlDbType.BigInt, 8).Value = HeatFrom
            oCmd.Parameters.Add("@heat_to", SqlDbType.BigInt, 8).Value = HeatTo
            oCmd.Parameters.Add("@sent_date", SqlDbType.SmallDateTime, 4).Value = SentDt
            oCmd.Parameters.Add("@lab_number", SqlDbType.VarChar, 50).Value = LabNumber
            oCmd.Parameters.Add("@ProdCode", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            oCmd.Parameters.Add("@inspector", SqlDbType.VarChar, 50).Value = inspector
            oCmd.Parameters.Add("@wheel", SqlDbType.VarChar, 50).Value = WhlNo
            oCmd.Parameters.Add("@Description", SqlDbType.VarChar, 50).Value = Description

            Try
                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                oCmd.Transaction = oCmd.Connection.BeginTransaction
                oCmd.CommandText = "select @ProdCode = ProdCode from mm_vw_mmwheel_ProductCodes " & _
                    " where whl = @wheel_number and ht = @heat_number "
                oCmd.ExecuteScalar()
                oCmd.Parameters("@ProdCode").Direction = ParameterDirection.Input
                oCmd.CommandText = "insert into ms_wheel_hardness_sample ( wheel_number, heat_number, " & _
                        " heat_from , heat_to , sent_date , lab_number , shift_code , inspector , wheel , " & _
                        " wheel_type , test_type , wheel_class ) values ( @wheel_number , @heat_number , " & _
                        " @heat_from , @heat_to , @sent_date , @lab_number , 'A' , @inspector , @wheel , " & _
                        " @Description , '" & test_type & "' , '" & WhlClass.Trim & "' ) "
                If oCmd.ExecuteNonQuery > 0 Then blnDone = True
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                If blnDone = True Then
                    oCmd.Transaction.Commit()
                Else
                    oCmd.Transaction.Rollback()
                End If
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End Try
            Return blnDone
        End Function
    End Class
End Namespace