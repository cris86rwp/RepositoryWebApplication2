Imports System.Data
Imports System.Data.SqlClient
Imports System.DateTime
Imports System.Configuration
Imports System.Web.UI.WebControls.TableCellCollection
Imports System.Web.UI.WebControls.DataGridColumnCollection
Imports System.Web.UI.WebControls.DataGridColumn
Imports System.Web.UI.WebControls.TemplateColumn

Public Class Baking
    Inherits System.Web.UI.Page

    Protected WithEvents panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents panel2 As System.Web.UI.WebControls.Panel
    Protected WithEvents panel3 As System.Web.UI.WebControls.Panel
    Protected WithEvents panel4 As System.Web.UI.WebControls.Panel
    Protected WithEvents txtdate As System.Web.UI.WebControls.TextBox
    Protected WithEvents Ddlshift As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtSSEJE As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtoperator As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtmould As System.Web.UI.WebControls.TextBox
    Protected WithEvents rbl1 As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents heat As System.Web.UI.WebControls.Label
    Protected WithEvents txtheat As System.Web.UI.WebControls.TextBox
    Protected WithEvents starttime As System.Web.UI.WebControls.Label
    Protected WithEvents txtstarttime As System.Web.UI.WebControls.TextBox
    Protected WithEvents finishtime As System.Web.UI.WebControls.Label
    Protected WithEvents txtfinishtime As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtsandqty As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtdomegm As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtdomekg As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtdometmp1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtdometmp2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpadtmp1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpadtmp2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpadtmp3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpadtmp4 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpad11 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpad12 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpad13 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpad14 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpad15 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpad16 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpad17 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpad18 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpad19 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpad20 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpad21 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpad22 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpad23 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpad24 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpad25 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpad26 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpad27 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpad28 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpad29 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpad30 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpad31 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpad32 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpad33 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpad34 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpad35 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpad36 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpad37 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpad38 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpad39 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpad40 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpad41 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpad42 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpad43 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpad44 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpad45 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpad46 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpad47 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpad48 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpad49 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpad50 As System.Web.UI.WebControls.TextBox
    Protected WithEvents copeno As System.Web.UI.WebControls.Label
    Protected WithEvents txtcopeno As System.Web.UI.WebControls.TextBox
    Protected WithEvents copetmp As System.Web.UI.WebControls.Label
    Protected WithEvents txtcopetmp As System.Web.UI.WebControls.TextBox
    Protected WithEvents padno As System.Web.UI.WebControls.Label
    Protected WithEvents Ddlpadno As System.Web.UI.WebControls.DropDownList
    Protected WithEvents baktime As System.Web.UI.WebControls.Label
    Protected WithEvents txtbaktime As System.Web.UI.WebControls.TextBox
    Protected WithEvents domeno As System.Web.UI.WebControls.Label
    Protected WithEvents Ddldomeno As System.Web.UI.WebControls.DropDownList
    Protected WithEvents dometime As System.Web.UI.WebControls.Label
    Protected WithEvents txtdometime As System.Web.UI.WebControls.TextBox
    Protected WithEvents status As System.Web.UI.WebControls.Label
    Protected WithEvents Ddlstatus As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnsave As System.Web.UI.WebControls.Button
    Protected WithEvents btnclear As System.Web.UI.WebControls.Button
    Protected WithEvents btnexit As System.Web.UI.WebControls.Button
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtremarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfvOperators As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents sandqty As System.Web.UI.WebControls.Label
    Protected WithEvents domeingm As System.Web.UI.WebControls.Label
    Protected WithEvents domeinkg As System.Web.UI.WebControls.Label
    Protected WithEvents dometemp As System.Web.UI.WebControls.Label
    Protected WithEvents padtemp As System.Web.UI.WebControls.Label
    Protected WithEvents lblRowNumber As System.Web.UI.WebControls.Label

    Dim i As String
    Dim strSql As String
    Shared themeValue As String

    Public Sub New()

        AddHandler PreInit, New EventHandler(AddressOf Page_PreInit)

    End Sub

    Private Sub Page_PreInit(ByVal sender As Object, ByVal e As EventArgs)

        Page.Theme = themeValue
    End Sub


    Protected Sub dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            Try
                SetScreen()
                txtmould.Text = GetHeatWoNo()
                getDateShift()
                GetHeatWoNo()
                setpad()

            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
        Ddlshift_SelectedIndexChanged(sender, e)


    End Sub

    Private Sub SetScreen()
        panel3.Visible = False
        panel4.Visible = False
        txtheat.Text = RWF.tables.GetLatestHeatbaking
        GetHeatWoNo()
        Try
            If rbl1.SelectedItem.Value = 1 Then
                panel3.Visible = True
                panel4.Visible = False

            ElseIf rbl1.SelectedItem.Value = 2 Then
                panel3.Visible = False
                panel4.Visible = True
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Protected Sub btnclear_Click(sender As Object, e As EventArgs) Handles btnclear.Click
        clear()
    End Sub

    Protected Sub rbl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rbl1.SelectedIndexChanged
        SetScreen()

    End Sub

    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click

        Dim done, donne, done2, done1 As Boolean

        If txtcopeno.Text <> String.Empty Then
            Response.Write("ch1")
            Dim n As Integer = checks()
            If n > 0 Then
                done1 = update_header()

            Else
                done = save()

            End If

            Dim n2 As Integer = Cchecks()
            If n2 > 0 Then
                done2 = update()

            Else
                donne = save1()

            End If

            If done And donne Then

                lblMessage.Text = " record saved !"
            ElseIf done1 And done2 Then
                lblMessage.Text = "updated"
            End If
        Else
            lblMessage.Text = "PLEASE ENTER COPE NUMBER!"
        End If
        Ddlshift_SelectedIndexChanged(sender, e)
        SetFocus(txtcopeno)
    End Sub
    Public Function update_header()
        Dim done As Boolean
        'Try
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.Connection.Open()
        Dim txt_date As Date = CDate(txtdate.Text)
        Dim txt_shift As String = Ddlshift.SelectedValue

        Dim txt_sseje As String = txtSSEJE.Text
        Dim txt_operator As String = txtoperator.Text
        Dim txt_coreoperator As String = txtCorebakingoperator.Text
        Dim txt_domeoperator As String = txtDomebakingoperator.Text
        Dim txt_mould As String = txtmould.Text
        Dim txt_heat As String = txtheat.Text
        ' Dim a1 As String = Ddlmpo.SelectedValue
        Dim txt_start As String = txtstarttime.Text
        Dim txt_finish As String = txtfinishtime.Text
        Dim txt_riserkg As String = txtriserkg.Text
        Dim txt_domegm As String = txtdomegm.Text
        Dim txt_dometmp1 As String = txtdometmp1.Text
        Dim txt_dometmp2 As String = txtdometmp2.Text
        Dim txt_padtmp1 As String = txtpadtmp1.Text
        Dim txt_padtmp2 As String = txtpadtmp2.Text
        Dim txt_padtmp3 As String = txtpadtmp3.Text
        Dim txt_padtmp4 As String = txtpadtmp4.Text
        Dim txt_pad11 As String = txtpad11.Text
        Dim txt_pad12 As String = txtpad12.Text
        Dim txt_pad13 As String = txtpad13.Text
        Dim txt_pad14 As String = txtpad14.Text
        Dim txt_pad15 As String = txtpad15.Text
        Dim txt_pad16 As String = txtpad16.Text
        Dim txt_pad17 As String = txtpad17.Text
        Dim txt_pad18 As String = txtpad18.Text
        Dim txt_pad19 As String = txtpad19.Text
        Dim txt_pad20 As String = txtpad20.Text
        Dim txt_pad21 As String = txtpad21.Text
        Dim txt_pad22 As String = txtpad22.Text
        Dim txt_pad23 As String = txtpad23.Text
        Dim txt_pad24 As String = txtpad24.Text
        Dim txt_pad25 As String = txtpad25.Text
        Dim txt_pad26 As String = txtpad26.Text
        Dim txt_pad27 As String = txtpad27.Text
        Dim txt_pad28 As String = txtpad28.Text
        Dim txt_pad29 As String = txtpad29.Text
        Dim txt_pad30 As String = txtpad30.Text
        Dim txt_pad31 As String = txtpad31.Text
        Dim txt_pad32 As String = txtpad32.Text
        Dim txt_pad33 As String = txtpad33.Text
        Dim txt_pad34 As String = txtpad34.Text
        Dim txt_pad35 As String = txtpad35.Text
        Dim txt_pad36 As String = txtpad36.Text
        Dim txt_pad37 As String = txtpad37.Text
        Dim txt_pad38 As String = txtpad38.Text
        Dim txt_pad39 As String = txtpad39.Text
        Dim txt_pad40 As String = txtpad40.Text
        Dim txt_pad41 As String = txtpad41.Text
        Dim txt_pad42 As String = txtpad42.Text
        Dim txt_pad43 As String = txtpad43.Text
        Dim txt_pad44 As String = txtpad44.Text
        Dim txt_pad45 As String = txtpad45.Text
        Dim txt_pad46 As String = txtpad46.Text
        Dim txt_pad47 As String = txtpad47.Text
        Dim txt_pad48 As String = txtpad48.Text
        Dim txt_pad49 As String = txtpad49.Text
        Dim txt_pad50 As String = txtpad50.Text


        cmd.CommandText = "update mm_baking_station_header set sseorje=@txt_sseje,operatorname=@txt_operator,core_operator=@txt_coreoperator,dome_operator=@txt_domeoperator,                           mouldingwonumber=@txt_mould,heatnumber=@txt_heat,starttime=@txt_start,finishtime=@txt_finish,riser_hole_kg=@txt_riserkg,dome_gm=@txt_domegm,dometmp1=@txt_dometmp1,dometmp2=@txt_dometmp2,pad_tmp1=@txt_padtmp1,pad_tmp2=@txt_padtmp2, pad_tmp3=@txt_padtmp3,pad_tmp4=@txt_padtmp4,pad1tmp1=@txt_pad11,pad1tmp2=@txt_pad12,pad1tmp3=@txt_pad13,pad1tmp4=@txt_pad14,pad1tmp5=@txt_pad15, pad1tmp6=@txt_pad16, pad1tmp7=@txt_pad17, pad1tmp8=@txt_pad18, pad1tmp9=@txt_pad19,pad1tmp10=@txt_pad20, pad2tmp1=@txt_pad21, pad2tmp2=@txt_pad22, pad2tmp3=@txt_pad23, pad2tmp4=@txt_pad24, pad2tmp5=@txt_pad25, pad2tmp6=@txt_pad26, pad2tmp7=@txt_pad27, pad2tmp8=@txt_pad28, pad2tmp9=@txt_pad29, pad2tmp10=@txt_pad30,pad3tmp1=@txt_pad31, pad3tmp2=@txt_pad32, pad3tmp3=@txt_pad33, pad3tmp4=@txt_pad34, pad3tmp5=@txt_pad35, pad3tmp6=@txt_pad36, pad3tmp7=@txt_pad37,pad3tmp8=@txt_pad38, pad3tmp9=@txt_pad39,pad3tmp10=@txt_pad40, pad4tmp1=@txt_pad41, pad4tmp2=@txt_pad42, pad4tmp3=@txt_pad43, pad4tmp4=@txt_pad44, pad4tmp5=@txt_pad45, pad4tmp6=@txt_pad46, pad4tmp7=@txt_pad47, pad4tmp8=@txt_pad48, pad4tmp9=@txt_pad49,pad4tmp10=@txt_pad50 where date=@txt_date and shift=@txt_shift"

        cmd.Parameters.AddWithValue("@txt_date", txt_date)
        cmd.Parameters.AddWithValue("@txt_shift", Ddlshift.SelectedValue)
        cmd.Parameters.AddWithValue("@txt_sseje", txt_sseje)
        cmd.Parameters.AddWithValue("@txt_operator", txt_operator)
        cmd.Parameters.AddWithValue("@txt_coreoperator", txt_coreoperator)
        cmd.Parameters.AddWithValue("@txt_domeoperator", txt_domeoperator)
        cmd.Parameters.AddWithValue("@txt_mould", txt_mould)
        cmd.Parameters.AddWithValue("@txt_heat", txt_heat)
        '  cmd.Parameters.AddWithValue("@Ddlmp", a1)
        cmd.Parameters.AddWithValue("@txt_start", txt_start)
        cmd.Parameters.AddWithValue("@txt_finish", txt_finish)
        cmd.Parameters.AddWithValue("@txt_riserkg", txt_riserkg)
        cmd.Parameters.AddWithValue("@txt_domegm", txt_domegm)
        cmd.Parameters.AddWithValue("@txt_dometmp1", txt_dometmp1)
        cmd.Parameters.AddWithValue("@txt_dometmp2", txt_dometmp2)
        cmd.Parameters.AddWithValue("@txt_padtmp1", txt_padtmp1)
        cmd.Parameters.AddWithValue("@txt_padtmp2", txt_padtmp2)
        cmd.Parameters.AddWithValue("@txt_padtmp3", txt_padtmp3)
        cmd.Parameters.AddWithValue("@txt_padtmp4", txt_padtmp4)
        cmd.Parameters.AddWithValue("@txt_pad11", txt_pad11)
        cmd.Parameters.AddWithValue("@txt_pad12", txt_pad12)
        cmd.Parameters.AddWithValue("@txt_pad13", txt_pad13)
        cmd.Parameters.AddWithValue("@txt_pad14", txt_pad14)
        cmd.Parameters.AddWithValue("@txt_pad15", txt_pad15)
        cmd.Parameters.AddWithValue("@txt_pad16", txt_pad16)
        cmd.Parameters.AddWithValue("@txt_pad17", txt_pad17)
        cmd.Parameters.AddWithValue("@txt_pad18", txt_pad18)
        cmd.Parameters.AddWithValue("@txt_pad19", txt_pad19)
        cmd.Parameters.AddWithValue("@txt_pad20", txt_pad20)
        cmd.Parameters.AddWithValue("@txt_pad21", txt_pad21)
        cmd.Parameters.AddWithValue("@txt_pad22", txt_pad22)
        cmd.Parameters.AddWithValue("@txt_pad23", txt_pad23)
        cmd.Parameters.AddWithValue("@txt_pad24", txt_pad24)
        cmd.Parameters.AddWithValue("@txt_pad25", txt_pad25)
        cmd.Parameters.AddWithValue("@txt_pad26", txt_pad26)
        cmd.Parameters.AddWithValue("@txt_pad27", txt_pad27)
        cmd.Parameters.AddWithValue("@txt_pad28", txt_pad28)
        cmd.Parameters.AddWithValue("@txt_pad29", txt_pad29)
        cmd.Parameters.AddWithValue("@txt_pad30", txt_pad30)
        cmd.Parameters.AddWithValue("@txt_pad31", txt_pad31)
        cmd.Parameters.AddWithValue("@txt_pad32", txt_pad32)
        cmd.Parameters.AddWithValue("@txt_pad33", txt_pad33)
        cmd.Parameters.AddWithValue("@txt_pad34", txt_pad34)
        cmd.Parameters.AddWithValue("@txt_pad35", txt_pad35)
        cmd.Parameters.AddWithValue("@txt_pad36", txt_pad36)
        cmd.Parameters.AddWithValue("@txt_pad37", txt_pad37)
        cmd.Parameters.AddWithValue("@txt_pad38", txt_pad38)
        cmd.Parameters.AddWithValue("@txt_pad39", txt_pad39)
        cmd.Parameters.AddWithValue("@txt_pad40", txt_pad40)
        cmd.Parameters.AddWithValue("@txt_pad41", txt_pad41)
        cmd.Parameters.AddWithValue("@txt_pad42", txt_pad42)
        cmd.Parameters.AddWithValue("@txt_pad43", txt_pad43)
        cmd.Parameters.AddWithValue("@txt_pad44", txt_pad44)
        cmd.Parameters.AddWithValue("@txt_pad45", txt_pad45)
        cmd.Parameters.AddWithValue("@txt_pad46", txt_pad46)
        cmd.Parameters.AddWithValue("@txt_pad47", txt_pad47)
        cmd.Parameters.AddWithValue("@txt_pad48", txt_pad48)
        cmd.Parameters.AddWithValue("@txt_pad49", txt_pad49)
        cmd.Parameters.AddWithValue("@txt_pad50", txt_pad50)



        If cmd.ExecuteNonQuery() = 1 Then done = True
        cmd.Connection.Close()

        Return done

    End Function
    Public Function checks()

        Dim txt_date As Date = CDate(txtdate.Text)
        Dim txt_shift As String = Ddlshift.SelectedItem.Text
        Response.Write("chfn")

        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.CommandText = "SELECT COUNT(*) FROM mm_baking_station_header where date=@txt_date and shift=@txt_shift"

        cmd.Parameters.AddWithValue("@txt_date", txt_date)
        cmd.Parameters.AddWithValue("@txt_shift", txt_shift)
        Try
            cmd.Connection.Open()
            Response.Write("con")


            Dim i As Integer = Convert.ToInt32(cmd.ExecuteScalar())

            Return i
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally

            cmd.Connection.Close()

        End Try

    End Function
    Public Function Cchecks()

        Dim txt_date As Date = CDate(txtdate.Text)
        Dim txt_shift As String = Ddlshift.SelectedItem.Text
        Dim copeno As String = txtcopeno.Text

        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.CommandText = "SELECT COUNT(*) FROM mm_bakingstation where date=@date and shift=@shift and cope_no=@copeno"

        cmd.Parameters.AddWithValue("@date", txt_date)
        cmd.Parameters.AddWithValue("@shift", txt_shift)
        cmd.Parameters.AddWithValue("@copeno", copeno)
        Try
            cmd.Connection.Open()
            Dim i As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            Return i
        Catch ex As Exception
            Throw New Exception(ex.Message)

        Finally
            cmd.Connection.Close()
            'lblmessage.Text = i
        End Try
    End Function
    Public Function update()
        Dim done As Boolean
        'Try

        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.Connection.Open()
        Dim txt_date As Date = CDate(txtdate.Text)
        Dim txt_shift As String = Ddlshift.SelectedValue

        Dim mouldorigin As String = rbl1.SelectedItem.Value
        Dim copeno As String = txtcopeno.Text
        Dim copetemp As String = txtcopetmp.Text
        Dim padno As String = Ddlpadno.SelectedItem.Text
        Dim padbaktime As String = txtbaktime.Text
        Dim domeno As String = Ddldomeno.SelectedItem.Text
        ' Dim a1 As String = Ddlmpo.SelectedValue
        Dim domebaktime As String = txtdometime.Text
        Dim status As String = Ddlstatus.SelectedItem.Text
        Dim remarks As String = txtremarks.Text
        Dim heatnumber As String = txtheat.Text

        cmd.CommandText = "update mm_bakingstation set mouldorigin=@mouldorigin,cope_tmp=@copetemp,pad_no=@padno,pad_bak_time=@padbaktime,dome_no=@domeno,dome_bak_time=@domebaktime,status=@status,remarks=@remarks,heatnumber=@heatnumber where date=@txt_date and shift=@txt_shift and cope_no =@copeno"

        cmd.Parameters.AddWithValue("@txt_date", txt_date)
        cmd.Parameters.AddWithValue("@txt_shift", Ddlshift.SelectedValue)
        cmd.Parameters.AddWithValue("@mouldorigin", mouldorigin)
        cmd.Parameters.AddWithValue("@copeno", copeno)
        cmd.Parameters.AddWithValue("@copetemp", copetemp)
        cmd.Parameters.AddWithValue("@padno", padno)
        cmd.Parameters.AddWithValue("@padbaktime", padbaktime)
        cmd.Parameters.AddWithValue("@domeno", domeno)
        cmd.Parameters.AddWithValue("@domebaktime", domebaktime)
        cmd.Parameters.AddWithValue("@status", status)
        cmd.Parameters.AddWithValue("@remarks", remarks)
        cmd.Parameters.AddWithValue("@heatnumber", heatnumber)

        If cmd.ExecuteNonQuery() = 1 Then done = True
        cmd.Connection.Close()
      
        Return done

    End Function


    Public Function save()

        Dim done As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj

        Dim stime As DateTime = CDate(txtdate.Text + " " & txtstarttime.Text)
        Dim ftime As DateTime = CDate(txtdate.Text + " " & txtfinishtime.Text)
        Try
            cmd.Connection.Open()

            If rbl1.SelectedItem.Value = 1 Then
                cmd.CommandText = "Insert INTO mm_baking_station_header(date,shift,sseorje,operatorname,core_operator,dome_operator,mouldingwonumber,heatnumber,starttime,finishtime,riser_hole_kg,dome_gm,dometmp1,dometmp2,pad_tmp1,pad_tmp2,pad_tmp3,pad_tmp4,pad1tmp1,pad1tmp2,pad1tmp3,pad1tmp4,
 pad1tmp5, pad1tmp6, pad1tmp7, pad1tmp8, pad1tmp9, pad1tmp10, pad2tmp1, pad2tmp2, pad2tmp3, pad2tmp4, pad2tmp5, pad2tmp6, pad2tmp7, pad2tmp8, pad2tmp9, pad2tmp10, pad3tmp1, pad3tmp2, pad3tmp3, pad3tmp4, pad3tmp5, pad3tmp6, pad3tmp7,
 pad3tmp8, pad3tmp9, pad3tmp10, pad4tmp1, pad4tmp2, pad4tmp3, pad4tmp4, pad4tmp5, pad4tmp6, pad4tmp7, pad4tmp8, pad4tmp9, pad4tmp10) 
                    values('" & Format(CDate(txtdate.Text), "MM/dd/yyyy") & "', '" & Ddlshift.SelectedItem.Value & "' , '" & txtSSEJE.Text & "', '" & txtoperator.Text & "',
                      '" & txtCorebakingoperator.Text & "', '" & txtDomebakingoperator.Text & "','" & txtmould.Text & "',
                      '" & Convert.ToInt64(txtheat.Text) & "' , '" & Format(CDate(stime), "MM/dd/yyyy HH:mm") & "', '" & Format(CDate(ftime), "MM/dd/yyyy HH:mm") & "', 
		       '" & txtriserkg.Text & "', '" & txtdomegm.Text & "', '" & txtdometmp1.Text & "', '" & txtdometmp2.Text & "', '" & txtpadtmp1.Text & "',
                       '" & txtpadtmp2.Text & "', '" & txtpadtmp3.Text & "', '" & txtpadtmp4.Text & "', '" & txtpad11.Text & "', '" & txtpad12.Text & "',
                       '" & txtpad13.Text & "',  '" & txtpad14.Text & "',  '" & txtpad15.Text & "',  '" & txtpad16.Text & "',  '" & txtpad17.Text & "',  '" & txtpad18.Text & "','" & txtpad19.Text & "',
                       '" & txtpad20.Text & "',  '" & txtpad21.Text & "', '" & txtpad22.Text & "', '" & txtpad23.Text & "', '" & txtpad24.Text & "', '" & txtpad25.Text & "', '" & txtpad26.Text & "',
                       '" & txtpad27.Text & "', '" & txtpad28.Text & "', '" & txtpad29.Text & "', '" & txtpad30.Text & "', '" & txtpad31.Text & "', '" & txtpad32.Text & "', '" & txtpad33.Text & "','" & txtpad34.Text & "',
                       '" & txtpad35.Text & "', '" & txtpad36.Text & "', '" & txtpad37.Text & "', '" & txtpad38.Text & "', '" & txtpad39.Text & "', '" & txtpad40.Text & "', '" & txtpad41.Text & "', '" & txtpad42.Text & "',
                      '" & txtpad43.Text & "', '" & txtpad44.Text & "', '" & txtpad45.Text & "', '" & txtpad46.Text & "', '" & txtpad47.Text & "', '" & txtpad48.Text & "', '" & txtpad49.Text & "', '" & txtpad50.Text & "')"

                If cmd.ExecuteNonQuery() = 1 Then done = True
            End If
            If rbl1.SelectedItem.Value = 2 Then

                cmd.CommandText = "Insert INTO mm_baking_station_header(date,shift,sseorje,operatorname,core_operator,dome_operator,mouldingwonumber,starttime,finishtime,riser_hole_kg,dome_gm,dometmp1,dometmp2,pad_tmp1,pad_tmp2,pad_tmp3,pad_tmp4,pad1tmp1,pad1tmp2,pad1tmp3,pad1tmp4,
                              pad1tmp5, pad1tmp6, pad1tmp7, pad1tmp8, pad1tmp9, pad1tmp10, pad2tmp1, pad2tmp2, pad2tmp3, pad2tmp4, pad2tmp5, pad2tmp6, pad2tmp7, pad2tmp8, pad2tmp9, pad2tmp10, pad3tmp1, pad3tmp2, pad3tmp3, pad3tmp4, pad3tmp5, pad3tmp6, pad3tmp7,
                              pad3tmp8, pad3tmp9, pad3tmp10, pad4tmp1, pad4tmp2, pad4tmp3, pad4tmp4, pad4tmp5, pad4tmp6, pad4tmp7, pad4tmp8, pad4tmp9, pad4tmp10) 
                    values('" & Format(CDate(txtdate.Text), "MM/dd/yyyy") & "', '" & Ddlshift.SelectedItem.Value & "' , '" & txtSSEJE.Text & "', '" & txtoperator.Text & "',
                           '" & txtCorebakingoperator.Text & "', '" & txtDomebakingoperator.Text & "','" & txtmould.Text & "',
                                '" & Format(CDate(stime), "MM/dd/yyyy HH:mm") & "', '" & Format(CDate(ftime), "MM/dd/yyyy HH:mm") & "', '" & txtriserkg.Text & "', '" & txtdomegm.Text & "', '" & txtdometmp1.Text & "', '" & txtdometmp2.Text & "', '" & txtpadtmp1.Text & "',
                               '" & txtpadtmp2.Text & "', '" & txtpadtmp3.Text & "', '" & txtpadtmp4.Text & "', '" & txtpad11.Text & "', '" & txtpad12.Text & "',
                               '" & txtpad13.Text & "',  '" & txtpad14.Text & "',  '" & txtpad15.Text & "',  '" & txtpad16.Text & "',  '" & txtpad17.Text & "',  '" & txtpad18.Text & "',
                                '" & txtpad19.Text & "',  '" & txtpad21.Text & "', '" & txtpad22.Text & "', '" & txtpad23.Text & "', '" & txtpad24.Text & "', '" & txtpad25.Text & "', '" & txtpad26.Text & "',
                               '" & txtpad27.Text & "', '" & txtpad28.Text & "', '" & txtpad29.Text & "', '" & txtpad31.Text & "', '" & txtpad32.Text & "', '" & txtpad33.Text & "','" & txtpad34.Text & "',
                                '" & txtpad35.Text & "', '" & txtpad36.Text & "', '" & txtpad37.Text & "', '" & txtpad38.Text & "', '" & txtpad39.Text & "', '" & txtpad41.Text & "', '" & txtpad42.Text & "',
                               '" & txtpad43.Text & "', '" & txtpad44.Text & "', '" & txtpad45.Text & "', '" & txtpad46.Text & "', '" & txtpad47.Text & "', '" & txtpad48.Text & "', '" & txtpad49.Text & "')"

                If cmd.ExecuteNonQuery() = 1 Then done = True

            End If
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            cmd.Connection.Close()
        End Try
        Return done
    End Function

    Public Function save1()
        Dim done As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj

        Try
            cmd.Connection.Open()
            cmd.CommandText = "Insert INTO mm_bakingstation(date,shift,mouldorigin,cope_no,cope_tmp,pad_no,pad_bak_time,dome_no,dome_bak_time,status,remarks,heatnumber)
values('" & Format(CDate(txtdate.Text), "MM/dd/yyyy") & "','" & Ddlshift.SelectedItem.Value & "','" & rbl1.SelectedItem.Value & "', '" & Convert.ToInt64(txtcopeno.Text) & "', '" & txtcopetmp.Text & "','" & Ddlpadno.SelectedItem.Text & "' , '" & txtbaktime.Text & "', '" & Ddldomeno.SelectedItem.Text & "', '" & txtdometime.Text & "', '" & Ddlstatus.SelectedItem.Text & "','" & txtremarks.Text & "','" & Convert.ToInt64(txtheat.Text) & "')"

            If cmd.ExecuteNonQuery() = 1 Then done = True

        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            cmd.Connection.Close()
        End Try
        Return done
    End Function


    Private Sub clear()
        txtdate.Text = ""
        txtSSEJE.Text = ""
        txtoperator.Text = ""
        txtmould.Text = ""
        txtheat.Text = ""
        txtstarttime.Text = ""
        txtfinishtime.Text = ""
        txtdomegm.Text = ""
        txtriserkg.Text = ""

        txtcopeno.Text = ""
        txtcopetmp.Text = ""
        txtbaktime.Text = ""
        txtdometime.Text = ""
        txtremarks.Text = ""
    End Sub

    Private Sub setpad()
        txtstarttime.Text = "00:00"
        txtfinishtime.Text = "00:00"
        txtdomegm.Text = ""
        txtriserkg.Text = ""
        txtdometmp1.Text = "0.0"
        txtdometmp2.Text = "0.0"
        txtpadtmp1.Text = "0.0"
        txtpadtmp2.Text = "0.0"
        txtpadtmp3.Text = "0.0"
        txtpadtmp4.Text = "0.0"
        txtpad11.Text = "0.0"
        txtpad12.Text = "0.0"
        txtpad13.Text = "0.0"
        txtpad14.Text = "0.0"
        txtpad15.Text = "0.0"
        txtpad16.Text = "0.0"
        txtpad17.Text = "0.0"
        txtpad18.Text = "0.0"
        txtpad19.Text = "0.0"
        txtpad20.Text = "0.0"
        txtpad21.Text = "0.0"
        txtpad22.Text = "0.0"
        txtpad23.Text = "0.0"
        txtpad24.Text = "0.0"
        txtpad25.Text = "0.0"
        txtpad26.Text = "0.0"
        txtpad27.Text = "0.0"
        txtpad28.Text = "0.0"
        txtpad29.Text = "0.0"
        txtpad30.Text = "0.0"
        txtpad31.Text = "0.0"
        txtpad32.Text = "0.0"
        txtpad33.Text = "0.0"
        txtpad34.Text = "0.0"
        txtpad35.Text = "0.0"
        txtpad36.Text = "0.0"
        txtpad37.Text = "0.0"
        txtpad38.Text = "0.0"
        txtpad39.Text = "0.0"
        txtpad40.Text = "0.0"
        txtpad41.Text = "0.0"
        txtpad42.Text = "0.0"
        txtpad43.Text = "0.0"
        txtpad44.Text = "0.0"
        txtpad45.Text = "0.0"
        txtpad46.Text = "0.0"
        txtpad47.Text = "0.0"
        txtpad48.Text = "0.0"
        txtpad49.Text = "0.0"
        txtpad50.Text = "0.0"
        txtcopetmp.Text = "0.0"
        txtbaktime.Text = ""
        txtdometime.Text = ""
        txtremarks.Text = ""

    End Sub


    Private Sub txtheat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtheat.TextChanged
        GetHeatWoNo()
    End Sub

    Public Function GetHeatWoNo()
        Dim dt As New DataTable()
        dt = RWF.tables.getHeatWo(Val(txtheat.Text))
        If dt.Rows.Count > 0 Then
            txtmould.Text = IIf(IsDBNull(dt.Rows(0)("number")), "", dt.Rows(0)("number"))

        Else
            txtmould.Text = ""

        End If
        dt = Nothing
        Return dt
    End Function

    Public Sub getDateShift()
        If Now.Hour = 0 OrElse Now.Hour = 1 OrElse Now.Hour = 2 OrElse Now.Hour = 3 OrElse Now.Hour = 4 OrElse Now.Hour = 5 Then
            txtdate.Text = CDate(Now.Date.AddDays(-1))
        Else
            txtdate.Text = CDate(Now.Date)
        End If
        Dim dt As Date
        Dim Shift As String
        dt = Now
        Select Case dt.Hour
            Case 6 To 13
                Shift = "A"
            Case 14 To 21
                Shift = "B"
            Case Else
                Shift = "C"
        End Select
        Dim i As Integer = 0
        Ddlshift.ClearSelection()
        For i = 0 To Ddlshift.Items.Count - 1
            If Ddlshift.Items(i).Text = Shift Then
                Ddlshift.Items(i).Selected = True
                Exit For
            End If
        Next
        dt = Nothing
        Shift = Nothing
        i = Nothing
    End Sub


    Protected Sub txtSSEJE_TextChanged(sender As Object, e As EventArgs) Handles txtSSEJE.TextChanged
        txtSSEJE.Text = txtSSEJE.Text.ToUpper
    End Sub

    Protected Sub txtcopeno_TextChanged(sender As Object, e As EventArgs) Handles txtcopeno.TextChanged
        lblMessage.Text = ""
        Try
            ValidateCope()


        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try

    End Sub

    Protected Sub ValidateCope()
        If txtcopeno.Text = "" Or txtcopeno.Text = "0" Then
            Exit Sub
        End If
        Dim Len As String
        Try
            Len = RWF.tables.ValidateCope_baking(Val(txtcopeno.Text.Trim), Val(txtheat.Text))
            lblMessage.Text = Len
            btnsave.Enabled = True
            SetFocus(txtcopeno)

        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try

        Len = Nothing
    End Sub

    Protected Sub Ddlshift_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Ddlshift.SelectedIndexChanged
        Dim sqlstr3, sqlstr4, sqlstr5 As String
        sqlstr3 = "select date,shift,sseorje,heatnumber,startTime,finishTime,operatorname,core_operator,dome_operator,mouldingwonumber from mm_baking_station_header where date='" & Format(CDate(txtdate.Text), "MM/dd/yyyy") & "'  and shift='" & Ddlshift.SelectedItem.Value & "'"
        sqlstr4 = "select ROW_NUMBER() OVER(ORDER BY id asc) AS ID,date,shift,mouldorigin,cope_no,cope_tmp,pad_no,pad_bak_time,dome_no,dome_bak_time,status,remarks,heatnumber from mm_bakingstation where date='" & Format(CDate(txtdate.Text), "MM/dd/yyyy") & "'  and shift='" & Ddlshift.SelectedItem.Value & "' order by ID desc"
        sqlstr5 = "select date,shift,heatnumber,pad1tmp1,pad1tmp2,pad1tmp3,pad1tmp4,pad1tmp5,pad1tmp6,pad1tmp7,pad1tmp8,pad1tmp9,pad1tmp10,pad2tmp1,pad2tmp2,pad2tmp3,pad2tmp4,pad2tmp5,pad2tmp6,pad2tmp7,pad2tmp8,pad2tmp9,pad2tmp10,pad3tmp1,pad3tmp2,pad3tmp3,pad3tmp4,pad3tmp5,pad3tmp6,pad3tmp7,pad3tmp8,pad3tmp9,pad3tmp10,pad4tmp1,pad4tmp2,pad4tmp3,pad4tmp4,pad4tmp5,pad4tmp6,pad4tmp7,pad4tmp8,pad4tmp9,pad4tmp10 from mm_baking_station_header where date='" & Format(CDate(txtdate.Text), "MM/dd/yyyy") & "'  and shift='" & Ddlshift.SelectedItem.Value & "'"
        Call BindDataGrid(sqlstr3)
        Call BindDataGrid1(sqlstr4)
        Call BindDataGrid2(sqlstr5)
    End Sub
    Private Sub BindDataGrid2(ByVal strArg As String)
        Dim objCmd As SqlCommand
        Dim objDr As SqlDataReader
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj

        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        Else
            cmd.Connection.Close()
            cmd.Connection.Open()
        End If
        Try
            objCmd = New SqlCommand(strArg, cmd.Connection)
            objDr = objCmd.ExecuteReader()
            Dim arr() As String
            dgtemp.DataSource = arr
            dgtemp.DataBind()
            dgtemp.DataSource = objDr
            dgtemp.DataBind()
        Catch exp As SqlException
            strSql = exp.StackTrace
            lblMessage.Text = "Line : " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message

        Catch exp As Exception
            strSql = exp.StackTrace
            lblMessage.Text = "Line : " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message
        End Try

        cmd.Connection.Close()

    End Sub
    Private Sub BindDataGrid(ByVal strArg As String)
        Dim objCmd As SqlCommand
        Dim objDr As SqlDataReader
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj

        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        Else
            cmd.Connection.Close()
            cmd.Connection.Open()
        End If
        Try
            objCmd = New SqlCommand(strArg, cmd.Connection)
            objDr = objCmd.ExecuteReader()
            Dim arr() As String
            bakingstationheader.DataSource = arr
            bakingstationheader.DataBind()
            bakingstationheader.DataSource = objDr
            bakingstationheader.DataBind()
        Catch exp As SqlException
            strSql = exp.StackTrace
            lblMessage.Text = "Line : " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message

        Catch exp As Exception
            strSql = exp.StackTrace
            lblMessage.Text = "Line : " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message
        End Try

        cmd.Connection.Close()

    End Sub
    Private Sub BindDataGrid1(ByVal strArg As String)
        Dim objCmd As SqlCommand
        Dim objDr As SqlDataReader
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj

        If cmd.Connection.State = ConnectionState.Closed Then
            cmd.Connection.Open()
        Else
            cmd.Connection.Close()
            cmd.Connection.Open()
        End If
        Try
            objCmd = New SqlCommand(strArg, cmd.Connection)
            objDr = objCmd.ExecuteReader()
            Dim arr() As String

            bakingstation.DataSource = arr
            bakingstation.DataBind()
            bakingstation.DataSource = objDr
            bakingstation.DataBind()

        Catch exp As SqlException
            strSql = exp.StackTrace
            lblMessage.Text = "Line : " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message

        Catch exp As Exception
            strSql = exp.StackTrace
            lblMessage.Text = "Line : " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message
        End Try

        cmd.Connection.Close()

    End Sub

    Protected Sub bakingstationheader_SelectedIndexChanged(sender As Object, e As EventArgs) Handles bakingstationheader.SelectedIndexChanged

        bakingstationheader.SelectedIndex = i
        Ddlshift.SelectedItem.Value = Trim(bakingstationheader.Items(i).Cells(3).Text)
        txtSSEJE.Text = Trim(bakingstationheader.Items(i).Cells(4).Text)
        txtheat.Text = Trim(bakingstationheader.Items(i).Cells(5).Text)
        txtstarttime.Text = Trim(bakingstationheader.Items(i).Cells(6).Text)
        txtfinishtime.Text = Trim(bakingstationheader.Items(i).Cells(7).Text)
        ' Ddlmpo.SelectedItem.Value = Trim(bakingstationheader.Items(i).Cells(7).Text)
        txtmould.Text = bakingstationheader.Items(i).Cells(11).Text
        txtoperator.Text = bakingstationheader.Items(i).Cells(8).Text
        txtCorebakingoperator.Text = bakingstationheader.Items(i).Cells(9).Text
        txtDomebakingoperator.Text = bakingstationheader.Items(i).Cells(10).Text

    End Sub

    Private Sub bakingstationheader_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles bakingstationheader.ItemCommand
        i = e.Item.ItemIndex()
    End Sub

    Protected Sub bakingstation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles bakingstation.SelectedIndexChanged
        bakingstation.SelectedIndex = i
        Ddlshift.SelectedItem.Value = Trim(bakingstation.Items(i).Cells(4).Text)
        rbl1.SelectedItem.Value = Trim(bakingstation.Items(i).Cells(5).Text)
        txtcopeno.Text = Trim(bakingstation.Items(i).Cells(6).Text)
        txtcopetmp.Text = Trim(bakingstation.Items(i).Cells(7).Text)
        Ddlpadno.SelectedItem.Value = Trim(bakingstation.Items(i).Cells(8).Text)
        txtbaktime.Text = Trim(bakingstation.Items(i).Cells(9).Text)
        Ddldomeno.SelectedItem.Value = bakingstation.Items(i).Cells(10).Text
        txtdometime.Text = bakingstation.Items(i).Cells(11).Text
        Ddlstatus.SelectedItem.Value = bakingstation.Items(i).Cells(12).Text
        txtremarks.Text = bakingstation.Items(i).Cells(13).Text
    End Sub
    Private Sub bakingstation_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles bakingstationheader.ItemCommand
        i = e.Item.ItemIndex()
    End Sub
    Protected Sub dgtemp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dgtemp.SelectedIndexChanged
        dgtemp.SelectedIndex = i
        txtpad11.Text = Trim(dgtemp.Items(i).Cells(5).Text)
        txtpad12.Text = Trim(dgtemp.Items(i).Cells(6).Text)
        txtpad13.Text = Trim(dgtemp.Items(i).Cells(7).Text)
        txtpad14.Text = Trim(dgtemp.Items(i).Cells(8).Text)
        txtpad15.Text = Trim(dgtemp.Items(i).Cells(9).Text)
        txtpad16.Text = Trim(dgtemp.Items(i).Cells(10).Text)
        txtpad17.Text = Trim(dgtemp.Items(i).Cells(11).Text)
        txtpad18.Text = Trim(dgtemp.Items(i).Cells(12).Text)
        txtpad19.Text = Trim(dgtemp.Items(i).Cells(13).Text)
        txtpad20.Text = Trim(dgtemp.Items(i).Cells(14).Text)
        txtpad21.Text = Trim(dgtemp.Items(i).Cells(15).Text)
        txtpad22.Text = Trim(dgtemp.Items(i).Cells(16).Text)
        txtpad23.Text = Trim(dgtemp.Items(i).Cells(17).Text)
        txtpad24.Text = Trim(dgtemp.Items(i).Cells(18).Text)
        txtpad25.Text = Trim(dgtemp.Items(i).Cells(19).Text)
        txtpad26.Text = Trim(dgtemp.Items(i).Cells(20).Text)
        txtpad27.Text = Trim(dgtemp.Items(i).Cells(21).Text)
        txtpad28.Text = Trim(dgtemp.Items(i).Cells(22).Text)
        txtpad29.Text = Trim(dgtemp.Items(i).Cells(23).Text)
        txtpad30.Text = Trim(dgtemp.Items(i).Cells(24).Text)
        txtpad31.Text = Trim(dgtemp.Items(i).Cells(25).Text)
        txtpad32.Text = Trim(dgtemp.Items(i).Cells(26).Text)
        txtpad33.Text = Trim(dgtemp.Items(i).Cells(27).Text)
        txtpad34.Text = Trim(dgtemp.Items(i).Cells(28).Text)
        txtpad35.Text = Trim(dgtemp.Items(i).Cells(29).Text)
        txtpad36.Text = Trim(dgtemp.Items(i).Cells(30).Text)
        txtpad37.Text = Trim(dgtemp.Items(i).Cells(31).Text)
        txtpad38.Text = Trim(dgtemp.Items(i).Cells(32).Text)
        txtpad39.Text = Trim(dgtemp.Items(i).Cells(33).Text)
        txtpad40.Text = Trim(dgtemp.Items(i).Cells(34).Text)
        txtpad41.Text = Trim(dgtemp.Items(i).Cells(35).Text)
        txtpad42.Text = Trim(dgtemp.Items(i).Cells(36).Text)
        txtpad43.Text = Trim(dgtemp.Items(i).Cells(37).Text)
        txtpad44.Text = Trim(dgtemp.Items(i).Cells(38).Text)
        txtpad45.Text = Trim(dgtemp.Items(i).Cells(39).Text)
        txtpad46.Text = Trim(dgtemp.Items(i).Cells(40).Text)
        txtpad47.Text = Trim(dgtemp.Items(i).Cells(41).Text)
        txtpad48.Text = Trim(dgtemp.Items(i).Cells(42).Text)
        txtpad49.Text = Trim(dgtemp.Items(i).Cells(43).Text)
        txtpad50.Text = Trim(dgtemp.Items(i).Cells(44).Text)

    End Sub

    Private Sub dgtemp_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgtemp.ItemCommand
        i = e.Item.ItemIndex()
    End Sub



    Protected Sub OnItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            CType(e.Item.FindControl("lblRowNumber"), Label).Text = (e.Item.ItemIndex + 1).ToString()
        End If
    End Sub
End Class


