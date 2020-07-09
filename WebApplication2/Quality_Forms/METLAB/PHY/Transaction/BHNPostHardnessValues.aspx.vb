Public Class BHNPostHardnessValues
    Inherits System.Web.UI.Page
    Protected WithEvents ddlWheelNumber As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtF11 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtR11 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtR12 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtR13 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtR14 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtR21 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtR22 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtR23 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtR24 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtR31 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtR32 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtR33 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtR34 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtR41 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtR42 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtR43 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtP11 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtP12 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtP21 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtP31 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtP41 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtP51 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtP61 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtP71 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtP81 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtH12 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtH21 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtH22 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtH23 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtH24 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtP91 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtH31 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtH32 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtH33 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtH34 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtH35 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtH36 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtH25 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtH26 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBHN As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents CustomValidator1 As System.Web.UI.WebControls.CustomValidator
    Protected WithEvents lblmessage As System.Web.UI.WebControls.Label
    Protected WithEvents imgHSBlank As System.Web.UI.WebControls.Image
    Protected WithEvents txtH11 As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblProductType As System.Web.UI.WebControls.Label
    Dim strMode As String
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblLabNum As System.Web.UI.WebControls.Label
    Protected WithEvents lblTestType As System.Web.UI.WebControls.Label
    Dim IsValidBHN As Boolean
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Shared themeValue As String

    Public Sub New()

        AddHandler PreInit, New EventHandler(AddressOf Page_PreInit)
    End Sub


    Private Sub Page_PreInit(ByVal sender As Object, ByVal e As EventArgs)

        ' Page.Theme = themeValue
        ' Page.Theme = Session("Theme")
    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        'strMode = Request.QueryString("mode")
        strMode = "add"
        If Page.IsPostBack = False Then
            lblTestType.Visible = False
            imgHSBlank.BackColor = System.Drawing.Color.Blue
            Autopostbackfalse()
            getWheelNumbers()
            Dim ds As New DataSet()
            Dim da As New SqlClient.SqlDataAdapter()
            da.SelectCommand = New SqlClient.SqlCommand()
            da.SelectCommand.CommandText = "select Product_code, low_bhn, High_bhn from mm_product_master where product_code like '[1,2]%' and isnull(low_bhn,0) > 0 and isnull(high_bhn,0) > 0 "
            da.SelectCommand.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
            Try
                da.Fill(ds, "ProdMaster")
                da.SelectCommand.CommandText = "select point , Point_zone, 0 bhnvalue from  ms_wheel_hardness_PointZones "
                da.Fill(ds, "Points")
                viewstate("vDs") = ds
            Catch exp As Exception
                lblmessage.Text = exp.Message
                ' Response.Redirect("\wap\InvalidSession.aspx")
            Finally
                da.Dispose()
            End Try
        End If
    End Sub
    Private Sub getWheelNumbers()
        ddlWheelNumber.Items.Clear()
        Dim strCmd As String
        If strMode.Equals("add") Then
            strCmd = "select (convert(varchar,a.wheel_number)+'/'+ convert(varchar,a.heat_number)) , a.lab_number  , b.description , c.product_code , a.test_type from ms_wheel_hardness_sample a , mm_wheel b , mm_product_master c  where "
            strCmd &= " convert(numeric,a.wheel_number) = b.wheel_number and a.heat_number = b.heat_number and b.description = c.description and a.lab_number not in (select distinct lab_number from ms_wheel_hardness_values )  and a.sent_date > '2006-07-15' "

            'strCmd = "select (convert(varchar,wheel_number)+'/'+ convert(varchar,heat_number)) ,lab_number from ms_wheel_hardness_sample where " 'sent_date > '2006-07-15' "
            'strCmd &= " convert(varchar,convert(bigint,wheel_number))+'/'+ convert(varchar, heat_number)  not in (select convert(varchar,wheel_number)+'/'+ convert(varchar, heat_number) from ms_wheel_hardness_chemical ) "
            'strCmd &= " and sent_date > '2006-07-15' "
        Else
            'strCmd = " select (convert(varchar,wheel_number)+'/'+ convert(varchar,heat_number)) , lab_number from ms_wheel_hardness_sample " ' where 
            strCmd = " select (convert(varchar,a.wheel_number)+'/'+ convert(varchar,a.heat_number)) , a.lab_number , b.description , c.product_code , a.test_type from ms_wheel_hardness_sample a , mm_wheel b , mm_product_master c where "
            strCmd &= " convert(numeric,a.wheel_number) = b.wheel_number and a.heat_number = b.heat_number and b.description = c.description and a.lab_number in (select distinct lab_number from ms_wheel_hardness_values ) and a.sent_date > '2006-07-15' order by a.lab_number desc "
        End If
        ddlWheelNumber.Items.Clear()

        Dim oCmd As New SqlClient.SqlCommand()
        Dim ds As New DataSet()
        oCmd.CommandText = strCmd
        oCmd.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
        Dim da As New SqlClient.SqlDataAdapter(oCmd)

        Try
            da.Fill(ds, ("tWheelNumbers"))
            ddlWheelNumber.DataSource = ds.Tables(0).DefaultView
            ddlWheelNumber.DataTextField = ds.Tables(0).Columns(0).ColumnName
            ddlWheelNumber.DataValueField = ds.Tables(0).Columns(1).ColumnName
            ddlWheelNumber.DataBind()
            viewstate("vDsw") = ds
        Catch exp As Exception
            ds.Dispose()
            lblmessage.Text = exp.Message
        Finally
            da.Dispose()
        End Try
        ddlWheelNumber.Items.Insert(0, "Select")
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If LeastMinMax() = False Then
            Exit Sub
        End If
        lblmessage.Text = ""
        If ddlWheelNumber.SelectedItem.Text = "Select" Then
            lblmessage.Text = "Please select WheelNumber"
            Exit Sub
        End If
        If IsValidBHN Then
            SaveData()
            clear()
            getWheelNumbers()
        Else
            lblmessage.Text &= "Invalid BHN values found "
        End If
    End Sub
    Private Function SaveData() As String
        Dim strInsert, strCheck, strUpdate As String
        strInsert = "insert into ms_wheel_hardness_values (lab_number ,  point , hardnessvalue , piont_zone ) values ( @lab_number,  @point , @hardnessvalue , @piont_zone ) "
        strCheck = "Select count(*) from ms_wheel_hardness_values where lab_number = @lab_number and  point = @point and  piont_zone = @piont_zone"
        strUpdate = "update ms_wheel_hardness_values  set hardnessvalue = @hardnessvalue where lab_number = @lab_number and  point = @point and  piont_zone = @piont_zone"
        Dim ocmd As New SqlClient.SqlCommand()
        ocmd.Connection = New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("con"))
        ocmd.CommandText = strInsert
        ocmd.Parameters.Add("@lab_number", SqlDbType.VarChar, 50)
        ocmd.Parameters("@lab_number").Direction = ParameterDirection.Input
        ocmd.Parameters.Add("@point", SqlDbType.VarChar, 10)
        ocmd.Parameters("@point").Direction = ParameterDirection.Input
        ocmd.Parameters.Add("@hardnessvalue", SqlDbType.Float, 9)
        ocmd.Parameters("@hardnessvalue").Direction = ParameterDirection.Input
        ocmd.Parameters.Add("@piont_zone", SqlDbType.VarChar, 10)
        ocmd.Parameters("@piont_zone").Direction = ParameterDirection.Input
        ocmd.Parameters("@lab_number").Value = Trim(ddlWheelNumber.SelectedItem.Value)
        Dim blnDone As Boolean

        Dim txtCol As New Collection()
        txtCol.Add(txtF11)
        txtCol.Add(txtR11)
        txtCol.Add(txtR12)
        txtCol.Add(txtR13)
        txtCol.Add(txtR14)
        txtCol.Add(txtR21)
        txtCol.Add(txtR22)
        txtCol.Add(txtR23)
        txtCol.Add(txtR24)
        txtCol.Add(txtR31)
        txtCol.Add(txtR32)
        txtCol.Add(txtR33)
        txtCol.Add(txtR34)
        txtCol.Add(txtR41)
        txtCol.Add(txtR42)
        txtCol.Add(txtR43)
        txtCol.Add(txtP11)
        txtCol.Add(txtP12)
        txtCol.Add(txtP21)
        txtCol.Add(txtP31)
        txtCol.Add(txtP41)
        txtCol.Add(txtP51)
        txtCol.Add(txtP61)
        txtCol.Add(txtP71)
        txtCol.Add(txtP81)
        txtCol.Add(txtP91)
        txtCol.Add(txtH11)
        txtCol.Add(txtH12)
        txtCol.Add(txtH21)
        txtCol.Add(txtH22)
        txtCol.Add(txtH23)
        txtCol.Add(txtH24)
        txtCol.Add(txtH31)
        txtCol.Add(txtH32)
        txtCol.Add(txtH33)
        txtCol.Add(txtH34)
        txtCol.Add(txtH35)
        txtCol.Add(txtH36)
        txtCol.Add(txtH25)
        txtCol.Add(txtH26)
        txtCol.Add(txtBHN)
        Try
            If ocmd.Connection.State = ConnectionState.Closed Then ocmd.Connection.Open()
            ocmd.Transaction = ocmd.Connection.BeginTransaction
            Dim i As Integer = 0
            For i = 1 To 41
                AssignValues(ocmd, i, txtCol)
                ocmd.CommandText = strCheck
                If ocmd.ExecuteScalar > 0 Then
                    ocmd.CommandText = strUpdate
                Else
                    ocmd.CommandText = strInsert
                End If
                ocmd.ExecuteNonQuery()
            Next
            ocmd.CommandText = "select count(*) from ms_wheel_hardness_values where lab_number = @lab_Number"
            Dim cnt As Integer = ocmd.ExecuteScalar
            blnDone = cnt = 41
        Catch exp As Exception
            blnDone = False
            lblmessage.Text = exp.Message
        Finally
            If blnDone Then
                ocmd.Transaction.Commit()
                lblmessage.Text = " Records Updated"
            Else
                ocmd.Transaction.Rollback()
                lblmessage.Text = " Records Not Updated"
            End If
            If ocmd.Connection.State = ConnectionState.Open Then ocmd.Connection.Close()
            ocmd.Dispose()
        End Try
    End Function
    Private Sub AssignValues(ByRef ocmd As SqlClient.SqlCommand, ByVal i As Integer, ByRef txtCol As Collection)
        ocmd.Parameters("@point").Value = txtCol(i).ID.Substring(3)
        ocmd.Parameters("@hardnessvalue").Value = txtCol(i).Text
        ocmd.Parameters("@piont_zone").Value = IIf("BHN,F11,R11,R12,R13,R14,R21,R22,R23,R24".IndexOf(txtCol(i).ID.Substring(3)) >= 0, "H", "N")
    End Sub
    Private Sub ddlWheelNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlWheelNumber.SelectedIndexChanged
        lblmessage.Text = ""
        ' btnSave.Text = ""
        clear()
        Try
            getProdType()
        Catch exp As Exception
            lblmessage.Text = exp.Message
        End Try
        If ddlWheelNumber.SelectedItem.Text = "Select" Then
            lblmessage.Text = "Please select WheelNumber"
            Exit Sub
        End If
        '  btnSave.Text = "Save WheelNumber : '" & ddlWheelNumber.SelectedItem.Text.Trim & "' "
    End Sub
    Private Sub getProdType()
        lblProductType.Text = ""
        lblLabNum.Text = ""
        lblTestType.Text = ""
        Dim ds As New DataSet()
        Dim dv As New DataView()
        ds = CType(viewstate("vDsw"), DataSet)
        dv.Table = ds.Tables(0)
        If ddlWheelNumber.SelectedItem.Value = "Select" Then
        Else
            dv.RowFilter = "lab_number = '" & ddlWheelNumber.SelectedItem.Value & "'"
            lblProductType.Text = CStr(dv.Item(0)(2)).Trim
            lblLabNum.Text = CStr(dv.Item(0)(1)).Trim
            lblTestType.Text = CStr(dv.Item(0)(4)).Trim
        End If
    End Sub
    Private Sub Autopostbackfalse()
        txtF11.AutoPostBack = False
        txtR11.AutoPostBack = False
        txtR12.AutoPostBack = False
        txtR13.AutoPostBack = False
        txtR14.AutoPostBack = False
        txtR21.AutoPostBack = False
        txtR22.AutoPostBack = False
        txtR23.AutoPostBack = False
        txtR24.AutoPostBack = False
        txtR31.AutoPostBack = False
        txtR32.AutoPostBack = False
        txtR33.AutoPostBack = False
        txtR34.AutoPostBack = False
        txtR41.AutoPostBack = False
        txtR42.AutoPostBack = False
        txtR43.AutoPostBack = False
        txtP11.AutoPostBack = False
        txtP12.AutoPostBack = False
        txtP21.AutoPostBack = False
        txtP31.AutoPostBack = False
        txtP41.AutoPostBack = False
        txtP51.AutoPostBack = False
        txtP61.AutoPostBack = False
        txtP71.AutoPostBack = False
        txtP81.AutoPostBack = False
        txtH12.AutoPostBack = False
        txtH21.AutoPostBack = False
        txtH22.AutoPostBack = False
        txtH23.AutoPostBack = False
        txtH24.AutoPostBack = False
        txtP91.AutoPostBack = False
        txtH31.AutoPostBack = False
        txtH32.AutoPostBack = False
        txtH33.AutoPostBack = False
        txtH34.AutoPostBack = False
        txtH35.AutoPostBack = False
        txtH36.AutoPostBack = False
        txtH25.AutoPostBack = False
        txtH26.AutoPostBack = False
        txtBHN.AutoPostBack = False
        txtH11.AutoPostBack = False
    End Sub
    Private Sub CustomValidator1_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CustomValidator1.ServerValidate
        If LeastMinMax() = False Then
            Exit Sub
        End If
        lblmessage.Text = ""
        If lblTestType.Text = "Experimental" Then
            IsValidBHN = True
        Else
            Dim MinBHN, MaxBHN As Integer
            MinBHN = 170
            MaxBHN = 360
            Try
                If args.Value <= MinBHN OrElse args.Value >= MaxBHN Then
                    IsValidBHN = False
                Else
                    IsValidBHN = True
                End If
            Catch exp As Exception
                lblmessage.Text = exp.Message
            Finally
                MinBHN = Nothing
                MaxBHN = Nothing
            End Try
        End If
    End Sub
    Private Function LeastMinMax() As Boolean
        lblmessage.Text = ""
        Dim txtCol As New Collection()
        txtCol.Add(txtF11)
        txtCol.Add(txtR11)
        txtCol.Add(txtR12)
        txtCol.Add(txtR13)
        txtCol.Add(txtR14)
        txtCol.Add(txtR21)
        txtCol.Add(txtR22)
        txtCol.Add(txtR23)
        txtCol.Add(txtR24)
        txtCol.Add(txtR31)
        txtCol.Add(txtR32)
        txtCol.Add(txtR33)
        txtCol.Add(txtR34)
        txtCol.Add(txtR41)
        txtCol.Add(txtR42)
        txtCol.Add(txtR43)
        txtCol.Add(txtP11)
        txtCol.Add(txtP12)
        txtCol.Add(txtP21)
        txtCol.Add(txtP31)
        txtCol.Add(txtP41)
        txtCol.Add(txtP51)
        txtCol.Add(txtP61)
        txtCol.Add(txtP71)
        txtCol.Add(txtP81)
        txtCol.Add(txtP91)
        txtCol.Add(txtH11)
        txtCol.Add(txtH12)
        txtCol.Add(txtH21)
        txtCol.Add(txtH22)
        txtCol.Add(txtH23)
        txtCol.Add(txtH24)
        txtCol.Add(txtH31)
        txtCol.Add(txtH32)
        txtCol.Add(txtH33)
        txtCol.Add(txtH34)
        txtCol.Add(txtH35)
        txtCol.Add(txtH36)
        txtCol.Add(txtH25)
        txtCol.Add(txtH26)
        txtCol.Add(txtBHN)
        Dim txtbox As System.Web.UI.WebControls.TextBox
        LeastMinMax = True
        If Not lblTestType.Text = "Experimental" Then
            For Each txtbox In txtCol
                If txtbox.Text >= 170 And txtbox.Text <= 360 Then
                    lblmessage.Text = lblmessage.Text.Replace("Some values are beyond 170 to 360. Check Inputs!", "")
                Else
                    'If txtbox.Text > 0 Then LeastMinMax = False ' allows editing of not entered values
                    If IsDBNull(txtbox.Text) = False Then LeastMinMax = False ' not allows editing of not entered values
                End If
            Next
        End If
        lblmessage.Text &= " Some values are beyond 170 to 360. Check Inputs!"
    End Function
    Private Sub clear()
        txtF11.Text = "0"
        txtR11.Text = "0"
        txtR12.Text = "0"
        txtR13.Text = "0"
        txtR14.Text = "0"
        txtR21.Text = "0"
        txtR22.Text = "0"
        txtR23.Text = "0"
        txtR24.Text = "0"
        txtR31.Text = "0"
        txtR32.Text = "0"
        txtR33.Text = "0"
        txtR34.Text = "0"
        txtR41.Text = "0"
        txtR42.Text = "0"
        txtR43.Text = "0"
        txtP11.Text = "0"
        txtP12.Text = "0"
        txtP21.Text = "0"
        txtP31.Text = "0"
        txtP41.Text = "0"
        txtP51.Text = "0"
        txtP61.Text = "0"
        txtP71.Text = "0"
        txtP81.Text = "0"
        txtH12.Text = "0"
        txtH21.Text = "0"
        txtH22.Text = "0"
        txtH23.Text = "0"
        txtH24.Text = "0"
        txtP91.Text = "0"
        txtH31.Text = "0"
        txtH32.Text = "0"
        txtH33.Text = "0"
        txtH34.Text = "0"
        txtH35.Text = "0"
        txtH36.Text = "0"
        txtH25.Text = "0"
        txtH26.Text = "0"
        txtBHN.Text = "0"
        txtH11.Text = "0"
    End Sub
End Class
