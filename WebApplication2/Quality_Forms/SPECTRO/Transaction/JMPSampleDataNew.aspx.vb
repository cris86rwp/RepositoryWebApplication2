Imports System.Data
Imports System.Data.SqlClient

Public Class JMPSampledataNew
    Inherits System.Web.UI.Page
    Protected WithEvents panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents panel2 As System.Web.UI.WebControls.Panel
    Protected WithEvents panel3 As System.Web.UI.WebControls.Panel
    Protected WithEvents panel4 As System.Web.UI.WebControls.Panel
    Protected WithEvents panel5 As System.Web.UI.WebControls.Panel
    Protected WithEvents panel6 As System.Web.UI.WebControls.Panel
    Protected WithEvents lblmsg As System.Web.UI.WebControls.Label
    Protected WithEvents lblhsts As System.Web.UI.WebControls.Label
    Protected WithEvents lblhsts1 As System.Web.UI.WebControls.Label
    Protected WithEvents rblsample As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents shiftrbl As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblmetal As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtdate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txttime As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtheat As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtremarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtcmacms As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtc As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtmn As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtsi As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtp As System.Web.UI.WebControls.TextBox
    Protected WithEvents txts As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtcr As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtni As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtcu As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtmo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtv As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtal As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtn As System.Web.UI.WebControls.TextBox
    Protected WithEvents txth As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtcnm As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtfheat As System.Web.UI.WebControls.TextBox
    Protected WithEvents txttheat As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddljmp As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlproduct As System.Web.UI.WebControls.DropDownList
    Protected WithEvents grid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnclear As System.Web.UI.WebControls.Button
    Protected WithEvents btnsave As System.Web.UI.WebControls.Button
    Protected WithEvents btnupd As System.Web.UI.WebControls.Button
    Protected WithEvents btnedit As System.Web.UI.WebControls.Button
    Protected WithEvents B1 As System.Web.UI.WebControls.Button
    Protected WithEvents B2 As System.Web.UI.WebControls.Button
    Protected WithEvents data1 As System.Web.UI.WebControls.GridView

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btnupd.Visible = False
        btnsave.Visible = True
        btnedit.Visible = True
        btnclear.Visible = True
        Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None
        Try
            If Page.IsPostBack = False Then

                SetScreen()


            End If
        Catch exp As Exception
            lblmsg.Text = exp.Message
        End Try
    End Sub
    Private Sub SetScreen()

        txtdate.Text = DateTime.Now.Date
        txttime.Text = DateTime.Now.ToShortTimeString
        getdata()
        If rblsample.SelectedItem.Value = "JMP" Then
            lblhsts.Visible = True
            ddljmp.Visible = True
            lblhsts1.Visible = False
            ddlproduct.Visible = False
        ElseIf rblsample.SelectedItem.Value = "product" Then
            lblhsts1.Visible = True
            ddlproduct.Visible = True
            lblhsts.Visible = False
            ddljmp.Visible = False
        Else
            lblhsts1.Visible = True
            ddlproduct.Visible = True
            lblhsts.Visible = False
            ddljmp.Visible = False
            ddlproduct.Visible = False
        End If
    End Sub



    Protected Sub rblsample_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblsample.SelectedIndexChanged
        If rblsample.SelectedItem.Value = "JMP" Then
            lblhsts.Visible = True
            ddljmp.Visible = True
            lblhsts1.Visible = False
            ddlproduct.Visible = False
        Else
            lblhsts1.Visible = True
            ddlproduct.Visible = True
            lblhsts.Visible = False
            ddljmp.Visible = False
        End If
    End Sub

    Public Function f1()
        Dim done As Boolean
        Dim con As New SqlConnection
        Dim cmd, cmdd As New SqlCommand

        Dim status As String
        If rblsample.SelectedItem.Value = "JMP" Then
            status = ddljmp.SelectedItem.Value
        ElseIf rblsample.SelectedItem.Value = "product" Then
            status = ddlproduct.SelectedItem.Value
        Else
            status = ""
        End If
        If txtc.Text = "" Then
            txtc.Text = "0.0"
        End If
        If txtmn.Text = "" Then
            txtmn.Text = "0.0"
        End If
        If txtsi.Text = "" Then
            txtsi.Text = "0.0"
        End If
        If txtp.Text = "" Then
            txtp.Text = "0.0"
        End If
        If txts.Text = "" Then
            txts.Text = "0.0"
        End If
        If txtcr.Text = "" Then
            txtcr.Text = "0.0"
        End If
        If txtni.Text = "" Then
            txtni.Text = "0.0"
        End If
        If txtcu.Text = "" Then
            txtcu.Text = "0.0"
        End If
        If txtmo.Text = "" Then
            txtmo.Text = "0.0"
        End If
        If txtv.Text = "" Then
            txtv.Text = "0.0"
        End If
        If txtal.Text = "" Then
            txtal.Text = "0.0"
        End If
        If txtn.Text = "" Then
            txtn.Text = "0.0"
        End If
        If txth.Text = "" Then
            txth.Text = "0.0"
        End If
        If txtcnm.Text = "" Then
            txtcnm.Text = "0.0"
        End If

        Try
            con.ConnectionString = "Data Source=cris-sql.public.a226b58b96ec.database.windows.net,3342;Initial Catalog=wap;User ID=crissqlserver;Password=cris-bela@1234567890"
            con.Open()
            cmd.Connection = con



            cmd.CommandText = "insert into mm_spectro_results_new values('" & Format(CDate(txtdate.Text), "MM/dd/yyyy") & "','" & (txttime.Text) & "',
                                  '" & shiftrbl.SelectedItem.Value & "','" & txtcmacms.Text & "','" & Convert.ToInt64(txtheat.Text) & "','" & rblsample.SelectedItem.Value & "',
                                    '" & Convert.ToDouble(txtc.Text) & "',  '" & Convert.ToDouble(txtmn.Text) & "','" & Convert.ToDouble(txtsi.Text) & "','" & Convert.ToDouble(txtp.Text) & "',
                                  '" & Convert.ToDouble(txts.Text) & "','" & Convert.ToDouble(txtcr.Text) & "','" & Convert.ToDouble(txtni.Text) & "',
            '" & Convert.ToDouble(txtcu.Text) & "','" & Convert.ToDouble(txtmo.Text) & "','" & Convert.ToDouble(txtv.Text) & "','" & Convert.ToDouble(txtal.Text) & "',
                                  '" & Convert.ToDouble(txtn.Text) & "','" & Convert.ToDouble(txth.Text) & "','" & Convert.ToDouble(txtcnm.Text) & "',
                                    '" & status & "', '" & txtremarks.Text & "')"


            If cmd.ExecuteNonQuery() = 1 Then done = True

        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            con.Close()
        End Try
        Return done
    End Function

    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Dim Done As Boolean

        Try
            Done = f1()


        Catch exp As Exception
            lblmsg.Text = exp.Message
        End Try
        If Done Then
            lblmsg.Text = " Updation Successful !"

        End If
    End Sub
    Public Function checkheat()
        ' Dim i As Integer
        Dim hh As Integer = Convert.ToInt64(txtheat.Text)
        Dim con As New SqlConnection("Data Source=cris-sql.public.a226b58b96ec.database.windows.net,3342;Initial Catalog=wap;User ID=crissqlserver;Password=cris-bela@1234567890")
        con.Open()
        Dim cmd As New SqlCommand("SELECT COUNT(*) FROM mm_vw_spectro_results_JMP where heat_number=@hh ", con)
        cmd.Parameters.AddWithValue("@hh", hh)
        Dim i As Integer = Convert.ToInt32(cmd.ExecuteScalar())
        cmd = Nothing
        con.Close()
        Return i
    End Function

    Protected Sub txtheat_TextChanged(sender As Object, e As EventArgs) Handles txtheat.TextChanged
        If txtheat.Text = "" Then
            lblmsg.Text = "please enter heat number"
        End If
        Dim n As Integer = checkheat()
        If n = 0 Then
            lblmsg.Text = "invalid heat"
        Else
            lblmsg.Text = ""
        End If
    End Sub

    Protected Sub txtdate_TextChanged(sender As Object, e As EventArgs) Handles txtdate.TextChanged
        getdata()
    End Sub
    Private Sub getdata()
        Dim sdate As String = Format(CDate(txtdate.Text), "MM/dd/yyyy")
        Dim con As SqlConnection = New SqlConnection("Data Source=cris-sql.public.a226b58b96ec.database.windows.net,3342;Initial Catalog=wap;User ID=crissqlserver;Password=cris-bela@1234567890")
        con.Open()
        Dim cmd As SqlCommand = New SqlCommand("SELECT convert(varchar, date, 105) Date,time Time,shift,[cma/cms] Incharge, heatnumber HeatNo, sampletype SType, carbon C, manganese Mn, silicon Si, phosphorus P, sulphur S, chromium Cr, nickle Ni, copper Cu, molybdenum Mo, vanadium V, alunimum Al , hydrogen H, nitrogen N, nicrmo, heatstatus HSts, remarks Remarks from  mm_spectro_results_new where date=@sdate order by heatnumber, time  ", con)
        cmd.Parameters.AddWithValue("@sdate", sdate)
        Dim dr As SqlDataReader = cmd.ExecuteReader()
        data1.DataSource = dr
        data1.DataBind()
        con.Close()
    End Sub


    Protected Sub B2_Click(sender As Object, e As EventArgs) Handles B2.Click
        If DataGrid1.Items.Count > 0 Then
            Dim prevstate As Boolean = Me.EnableViewState
            Dim tw As New System.IO.StringWriter()
            Dim hw As New System.Web.UI.HtmlTextWriter(tw)
            Try
                Response.ContentType = "application/vnd.ms_excel"
                Response.Charset = ""
                Me.EnableViewState = False
                DataGrid1.RenderControl(hw)
                Response.Write(tw.ToString)
                Response.End()
                Me.EnableViewState = prevstate
            Catch exp As Exception
                lblmsg.Text = exp.Message
            Finally
                prevstate = Nothing
                tw = Nothing
                hw = Nothing
            End Try
        Else
            lblmsg.Text = "No Data in Grid to export !"
        End If

    End Sub


    Private Sub getheatdetails()
        Dim hh = Convert.ToInt64(txtheat.Text)
        Dim con As New SqlConnection
        Dim cmd, cmdd As New SqlCommand
        con.ConnectionString = "Data Source=cris-sql.public.a226b58b96ec.database.windows.net,3342;Initial Catalog=wap;User ID=crissqlserver;Password=cris-bela@1234567890"
        con.Open()
        cmd.Connection = con
        cmd.CommandText = " select carbon, manganese , silicon, phosphorus, sulphur, chromium, nickle , copper,molybdenum,vanadium,alunimum,nitrogen,hydrogen,nicrmo from mm_spectro_results_new where heatnumber=@hh "
        cmd.Parameters.AddWithValue("@hh", hh)
        Using sdr As SqlDataReader = cmd.ExecuteReader()
            sdr.Read()
            txtc.Text = sdr("carbon").ToString()
            txtmn.Text = sdr("manganese").ToString()
            txtsi.Text = sdr("silicon").ToString()
            txtp.Text = sdr("phosphorus").ToString()
            txts.Text = sdr("sulphur").ToString()
            txtcr.Text = sdr("chromium").ToString()
            txtni.Text = sdr("nickle").ToString()
            txtcu.Text = sdr("copper").ToString()
            txtmo.Text = sdr("molybdenum").ToString()
            txtv.Text = sdr("vanadium").ToString()
            txtal.Text = sdr("alunimum").ToString()
            txtn.Text = sdr("nitrogen").ToString()
            txth.Text = sdr("hydrogen").ToString()
            txtcnm.Text = sdr("nicrmo").ToString()
        End Using
        con.Close()
    End Sub
    Private Sub CalTotalCrNiMo()
        Dim total As Double
        total = 0
        If txtcr.Text <> "" And IsNumeric(txtcr.Text) Then total += CDbl(txtcr.Text)
        If txtni.Text <> "" And IsNumeric(txtni.Text) Then total += CDbl(txtni.Text)
        If txtmo.Text <> "" And IsNumeric(txtmo.Text) Then total += CDbl(txtmo.Text)
        txtcnm.Text = CStr(total)
        total = Nothing
    End Sub

    Protected Sub txtcr_TextChanged(sender As Object, e As EventArgs) Handles txtcr.TextChanged
        CalTotalCrNiMo()
        SetFocus(txtcr)
    End Sub

    Protected Sub txtni_TextChanged(sender As Object, e As EventArgs) Handles txtni.TextChanged
        CalTotalCrNiMo()
        SetFocus(txtni)
    End Sub

    Protected Sub txtmo_TextChanged(sender As Object, e As EventArgs) Handles txtmo.TextChanged
        CalTotalCrNiMo()
        SetFocus(txtmo)
    End Sub

    Protected Sub B1_Click(sender As Object, e As EventArgs) Handles B1.Click
        lblmsg.Text = ""
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            panel6.Visible = True
            DataGrid1.DataSource = metLab.tables.SpectroDetails(CLng(txtfheat.Text), CLng(txttheat.Text), rblmetal.SelectedItem.Text)
            DataGrid1.DataBind()

        Catch exp As Exception
            lblmsg.Text = exp.Message
        End Try
    End Sub

    Protected Sub btnedit_Click(sender As Object, e As EventArgs) Handles btnedit.Click
        Dim dt As New DataTable()
        btnsave.Visible = False
        btnupd.Visible = True
        btnclear.Visible = False
        Try
            txtdate.Text = DateTime.Now.Date
            txttime.Text = DateTime.Now.ToShortTimeString
            Call getdetail()

        Catch exp As Exception
            Throw New Exception(exp.Message)

        End Try
    End Sub


    Public Shared Function CheckHeatpost(ByVal HeatNumber As Long) As Boolean
        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        oCmd.Parameters.Add("@cnt", SqlDbType.Int, 4).Direction = ParameterDirection.Output
        Try
            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            oCmd.CommandText = "select @cnt = heat_number from  mm_post_pouring where heat_number = " & CInt(HeatNumber)
            oCmd.ExecuteScalar()
            CheckHeatpost = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)
        Catch exp As Exception
            CheckHeatpost = 0
            Throw New Exception(exp.Message)
        Finally
            If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
            oCmd.Dispose()
            oCmd = Nothing
        End Try
    End Function


    Public Function update()

        txtdate.Text = DateTime.Now.Date
        txttime.Text = DateTime.Now.ToShortTimeString
        Dim hh = Convert.ToInt64(txtheat.Text)
        Dim con As New SqlConnection
        Dim cmd, cmdd As New SqlCommand
        Dim done As New Boolean
        con.ConnectionString = "Data Source=cris-sql.public.a226b58b96ec.database.windows.net,3342;Initial Catalog=wap;User ID=crissqlserver;Password=cris-bela@1234567890"
        con.Open()
        cmd.Connection = con
        Try

            Dim status As String
            If rblsample.SelectedItem.Value = "JMP" Then
                status = ddljmp.SelectedItem.Value
            ElseIf rblsample.SelectedItem.Value = "product" Then
                status = ddlproduct.SelectedItem.Value
            Else
                status = ""
            End If
            cmd.CommandText = "UPDATE mm_spectro_results_new SET date=@date,time=@time,Shift=@shift,[cma/cms]=@cmacms,heatnumber=@heat,sampletype=@sample,carbon=@carbon,manganese=@manganese,silicon=@silicon,phosphorus=@phosphorus,sulphur=@sulphur,chromium=@chromium,nickle=@nickle,copper=@copper,molybdenum=@molybdenum,vanadium=@vanadium,alunimum=@alunimum,nitrogen=@nitrogen,hydrogen=@hydrogen,nicrmo=@nicrmo,heatstatus=@status,remarks=@remarks" &
               " WHERE Heatnumber ='" & txtheat.Text & "' AND   AND  Shift = '" & shiftrbl.SelectedItem.Value & "' And date='" & Format(CDate(txtdate.Text), "MM/dd/yyyy") & "' And sampletype='" & rblsample.SelectedItem.Value & "' "

            cmd.Parameters.AddWithValue("@date", Format(CDate(txtdate.Text), "MM/dd/yyyy"))
            cmd.Parameters.AddWithValue("@time", txttime.Text)
            cmd.Parameters.AddWithValue("@shift", shiftrbl.SelectedItem.Value)
            cmd.Parameters.AddWithValue("@cmacms", txtcmacms.Text)
            cmd.Parameters.AddWithValue("@heat", txtheat.Text)
            cmd.Parameters.AddWithValue("@sample", rblsample.SelectedItem.Value)
            cmd.Parameters.AddWithValue("@carbon", txtc.Text)
            cmd.Parameters.AddWithValue("@manganese", txtmn.Text)
            cmd.Parameters.AddWithValue("@silicon", txtsi.Text)
            cmd.Parameters.AddWithValue("@phosphorus", txtp.Text)
            cmd.Parameters.AddWithValue("@sulphur", txts.Text)
            cmd.Parameters.AddWithValue("@chromium", txtcr.Text)
            cmd.Parameters.AddWithValue("@nickle", txtni.Text)
            cmd.Parameters.AddWithValue("@copper", txtcu.Text)
            cmd.Parameters.AddWithValue("@molybdenum", txtmo.Text)
            cmd.Parameters.AddWithValue("@vanadium", txtv.Text)
            cmd.Parameters.AddWithValue("@alunimum", txtal.Text)
            cmd.Parameters.AddWithValue("@nitrogen", txtn.Text)
            cmd.Parameters.AddWithValue("@hydrogen", txth.Text)
            cmd.Parameters.AddWithValue("@nicrmo", txtcnm.Text)
            cmd.Parameters.AddWithValue("@status", status)
            cmd.Parameters.AddWithValue("@remarks", txtremarks.Text)
            cmd.ExecuteNonQuery()

            'btnsave.Text = "SAVE DETAILS"
            'Call clearform()


            If cmd.ExecuteNonQuery() = 1 Then done = True

        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            con.Close()
        End Try

        Return done


    End Function

    Protected Sub btnupd_Click(sender As Object, e As EventArgs) Handles btnupd.Click
        Dim done As New Boolean

        Try
            done = update()


            lblmsg.Text = "updated sucessfully"


        Catch exp As Exception
            lblmsg.Text = exp.Message
        End Try


        lblmsg.Text = " Updation Successful !"

    End Sub

    Private Sub getdetail()

        Dim constr As String = "Data Source=cris-sql.public.a226b58b96ec.database.windows.net,3342;Initial Catalog=wap;User ID=crissqlserver;Password=cris-bela@1234567890"
        Dim con As SqlConnection = New SqlConnection(constr)
        Try
            Dim cmd As SqlCommand = New SqlCommand("SELECT * from mm_spectro_results_new  WHERE Heatnumber ='" & txtheat.Text & "' AND  Shift = '" & shiftrbl.SelectedItem.Value & "' And date='" & Format(CDate(txtdate.Text), "MM/dd/yyyy") & "' And sampletype='" & rblsample.SelectedItem.Value & "' ")
            cmd.CommandType = CommandType.Text
            cmd.Connection = con
            con.Open()
            cmd.ExecuteNonQuery()


            Dim sdr As SqlDataReader = cmd.ExecuteReader
            sdr.Read()
            'If sdr.HasRows() Then

            txtc.Text = sdr("carbon").ToString()
            txtmn.Text = sdr("manganese").ToString()
            txtsi.Text = sdr("silicon").ToString()
            txtp.Text = sdr("phosphorus").ToString()
            txts.Text = sdr("sulphur").ToString()
            txtcr.Text = sdr("chromium").ToString()
            txtni.Text = sdr("nickle").ToString()
            txtcu.Text = sdr("copper").ToString()
            txtmo.Text = sdr("molybdenum").ToString()
            txtv.Text = sdr("vanadium").ToString()
            txtal.Text = sdr("alunimum").ToString()
            txtn.Text = sdr("nitrogen").ToString()
            txth.Text = sdr("hydrogen").ToString()
            txtni.Text = sdr("nicrmo").ToString()
            txtremarks.Text = sdr("remarks").ToString()
            sdr.Close()

            '  Else
            ' lblmsg.Text = "no data present"
            'sdr.Close()
            'End If


        Catch exp As Exception
            lblmsg.Text = exp.Message
        End Try


        con.Close()


    End Sub
End Class

