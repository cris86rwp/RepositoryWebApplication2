Imports System.Data
Imports System.Data.SqlClient
Public Class spraystationentry
    Inherits System.Web.UI.Page
    Protected WithEvents lblmessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtsdate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtsseje As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtop As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtwo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtop1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtop2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtstime As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtftime As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtbatch1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtbaume1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtbatch2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtbaume2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtbatch3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtbaume3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddshift As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtheat As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddmponumber As System.Web.UI.WebControls.DropDownList
    Protected WithEvents rblmouldorigin As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblspray As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents lheat As System.Web.UI.WebControls.Label
    Protected WithEvents lmpo As System.Web.UI.WebControls.Label
    Protected WithEvents lcreason As System.Web.UI.WebControls.Label
    Protected WithEvents txtcopenumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtcopetemp As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtcctc As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtcspr As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtcbaume As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtchub As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtcplate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtcrim As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtctank As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtcatom As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtctrigger As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtcstoppipemake As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtcstopperheadmake As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtccardboardtubemake As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtcremark As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblstation As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents ddholdingoven As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddstatus As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddreason As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddcopecleanermachine As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddctc As System.Web.UI.WebControls.DropDownList
    Protected WithEvents dddomedisc As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnsave As System.Web.UI.WebControls.Button
    Protected WithEvents btnclear As System.Web.UI.WebControls.Button
    Protected WithEvents btnexit As System.Web.UI.WebControls.Button
    Protected WithEvents txtdragnumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtdragtemp As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtdt As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtdspr As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtdbaume As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtdhub As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtdplaterim As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtdtank As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtdatom As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtdtrigger As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtdremark As System.Web.UI.WebControls.TextBox
    Protected WithEvents rbldstation As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents dddholdingoven As System.Web.UI.WebControls.DropDownList
    Protected WithEvents dddstatus As System.Web.UI.WebControls.DropDownList
    Protected WithEvents dddreason As System.Web.UI.WebControls.DropDownList
    Protected WithEvents dddragcleanermachine As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnsave1 As System.Web.UI.WebControls.Button
    Protected WithEvents btnclear1 As System.Web.UI.WebControls.Button
    Protected WithEvents btnexit1 As System.Web.UI.WebControls.Button
    Protected WithEvents panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents panel2 As System.Web.UI.WebControls.Panel
    Protected WithEvents panelcope As System.Web.UI.WebControls.Panel
    Protected WithEvents paneldrag As System.Web.UI.WebControls.Panel
    Protected WithEvents panelgrid As System.Web.UI.WebControls.Panel
    Protected WithEvents DGCope As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DGdrag As System.Web.UI.WebControls.DataGrid
    Protected WithEvents data1 As System.Web.UI.WebControls.GridView
    Protected WithEvents data2 As System.Web.UI.WebControls.GridView
    Public con As New SqlConnection(ConfigurationManager.AppSettings("con"))
    Dim cmd As New SqlCommand
    Dim i As String
    Dim strSql As String
    Shared themeValue As String

    Public Sub New()

        AddHandler PreInit, New EventHandler(AddressOf Page_PreInit)
    End Sub

    Private Sub Page_PreInit(ByVal sender As Object, ByVal e As EventArgs)

        ' Page.Theme = themeValue
        Page.Theme = Session("Theme")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None
        'put usercode to initialize the page
        Try
            If Page.IsPostBack = False Then

                SetScreen()

            End If
        Catch exp As Exception
            lblmessage.Text = exp.Message
        End Try
    End Sub
    Private Sub SetScreen()
        getcopeheat()
        panelcope.Visible = False
        paneldrag.Visible = False
        Try

            If rblspray.SelectedItem.Value = "cope" Then

                panelcope.Visible = True
                paneldrag.Visible = False
                setcope()
                viewcopedata()
                If rblstation.SelectedItem.Value = "station1" And rblspray.SelectedItem.Value = "cope" Then
                    txtcspr.Text = txtop1.Text
                ElseIf rblstation.SelectedItem.Value = "station2" And rblspray.SelectedItem.Value = "cope" Then
                    txtcspr.Text = txtop2.Text
                End If
            Else
                panelcope.Visible = False
                paneldrag.Visible = True
                setdrag()
                viewdragdata()
                If rbldstation.SelectedItem.Value = "station1" And rblspray.SelectedItem.Value = "drag" Then
                    txtdspr.Text = txtop1.Text
                ElseIf rbldstation.SelectedItem.Value = "station2" And rblspray.SelectedItem.Value = "drag" Then

                    txtdspr.Text = txtop2.Text
                End If
            End If
            If rblmouldorigin.SelectedItem.Value = "heat" Then
                lheat.Visible = True
                getcopeheat()
                txtheat.Visible = True
                lmpo.Visible = False
                ddmponumber.Visible = False
                ddmponumber.SelectedItem.Value = "null"
            Else
                lheat.Visible = False
                txtheat.Text = "0"
                txtheat.Visible = False
                lmpo.Visible = True
                ddmponumber.Visible = True
            End If
        Catch exp As Exception
            lblmessage.Text = exp.Message
        End Try
    End Sub
    Private Sub setcope()
        getcopeheat()
        GetHeatWoNo()
        txtsdate.Text = RWF.tables.GetWorkingDate("MLDING")
        getdatacope()
        txtstime.Text = "00:00"
        txtftime.Text = "00:00"
        txtcopenumber.Text = ""
        txtcopetemp.Text = "000"
        txtcspr.Text = ""
        'txtchub.Text = "0.0"
        'txtcplate.Text = "0.0"
        'txtcrim.Text = "0.0"
        'txtctank.Text = "0.0"
        'txtcatom.Text = "0.0"
        'txtctrigger.Text = "0.0"
        txtbaume1.Text = "0.0"
        txtbaume2.Text = "0.0"
        txtbaume3.Text = "0.0"
        'txtcbaume.Text = "0.0"
        txtcremark.Text = ""
        txtcstoppipemake.Text = ""
        txtcstopperheadmake.Text = ""
        txtccardboardtubemake.Text = ""
    End Sub
    Private Sub setdrag()
        getdragheat()
        GetHeatWoNo()
        txtsdate.Text = RWF.tables.GetWorkingDate("MLDING")
        getdatadrag()
        txtstime.Text = "00:00"
        txtftime.Text = "00:00"
        txtdragtemp.Text = "000"
        txtdbaume.Text = "0.0"
        txtdragnumber.Text = ""
        txtdspr.Text = ""
        'txtdhub.Text = "0.0"
        'txtdplaterim.Text = "0.0"
        txtdremark.Text = ""
        txtir.Text = ""
        'txtdtank.Text = "0.0"
        'txtdatom.Text = "0.0"
        'txtdtrigger.Text = "0.0"
        txtbaume1.Text = "0.0"
        txtbaume2.Text = "0.0"
        txtbaume3.Text = "0.0"
    End Sub
    Private Sub GetHeatWoNo()
        Dim dt As New DataTable()
        dt = RWF.tables.GetMeltingWO(Val(txtheat.Text))
        If dt.Rows.Count > 0 Then
            txtwo.Text = IIf(IsDBNull(dt.Rows(0)("WO")), "", dt.Rows(0)("WO"))

        Else
            txtwo.Text = ""

        End If
        dt = Nothing
    End Sub

    Protected Sub ddstatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddstatus.SelectedIndexChanged
        If ddstatus.SelectedItem.Value = "not ok" Then
            lcreason.Visible = True
            ddreason.Visible = True
        Else
            lcreason.Visible = False
            ddreason.Visible = False
            ddreason.SelectedValue = "null"

        End If
    End Sub

    Protected Sub dddstatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dddstatus.SelectedIndexChanged
        If dddstatus.SelectedItem.Value = "not ok" Then
            ldreason.Visible = True
            dddreason.Visible = True
        Else
            ldreason.Visible = False
            dddreason.Visible = False
            dddreason.SelectedValue = "null"
        End If
    End Sub

    Protected Sub btnclear_Click(sender As Object, e As EventArgs) Handles btnclear.Click
        clear()
    End Sub
    Private Sub clear()
        txtsdate.Text = Now.Date
        txtsseje.Text = ""
        txtop.Text = ""
        txtop1.Text = ""
        txtop2.Text = ""
        txtbatch1.Text = ""
        txtbatch2.Text = ""
        txtbatch3.Text = ""
        txtstime.Text = "00:00"
        txtftime.Text = "00:00"
        txtcopenumber.Text = ""
        txtcopetemp.Text = "0.0"
        txtcspr.Text = ""
        txtchub.Text = "0.0"
        txtcplate.Text = "0.0"
        txtcrim.Text = "0.0"
        txtctank.Text = "0.0"
        txtcatom.Text = "0.0"
        txtctrigger.Text = "0.0"
        txtcstoppipemake.Text = ""
        txtcstopperheadmake.Text = ""
        txtccardboardtubemake.Text = ""
        txtbaume1.Text = "0.0"
        txtbaume2.Text = "0.0"
        txtbaume3.Text = "0.0"
        txtcbaume.Text = "0.0"
        txtcremark.Text = ""
    End Sub
    Private Sub clear2()
        txtsdate.Text = Now.Date
        txtsseje.Text = ""
        txtop.Text = ""
        txtop1.Text = ""
        txtop2.Text = ""
        txtbatch1.Text = ""
        txtbatch2.Text = ""
        txtbatch3.Text = ""
        txtstime.Text = "00:00"
        txtftime.Text = "00:00"
        txtdragtemp.Text = "0.0"
        txtdbaume.Text = "0.0"
        txtdragnumber.Text = ""
        txtdspr.Text = ""
        txtdhub.Text = "0.0"
        txtdplaterim.Text = "0.0"
        txtdremark.Text = ""
        txtir.Text = ""
        txtdtank.Text = "0.0"
        txtdatom.Text = "0.0"
        txtdtrigger.Text = "0.0"
        txtbaume1.Text = "0.0"
        txtbaume2.Text = "0.0"
        txtbaume3.Text = "0.0"
    End Sub

    Protected Sub btnclear1_Click(sender As Object, e As EventArgs) Handles btnclear1.Click
        clear2()
    End Sub
    Public Function f1()
        Dim done As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Dim con As New SqlConnection

        Dim stime As DateTime = CDate(txtsdate.Text + " " & txtstime.Text)
        Dim ftime As DateTime = CDate(txtsdate.Text + " " & txtftime.Text)


        Try
            'con.ConnectionString = "Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User ID=sa;Password=sadev123"
            'con.Open()
            'cmd.Connection = con
            cmd.Connection.Open()
            cmd.CommandText = "INSERT INTO mm_spraystation_header values('" & Format(CDate(txtsdate.Text), "MM/dd/yyyy") & "','" & ddshift.SelectedItem.Value & "','" & txtsseje.Text & "','" & txtop.Text & "','" & txtwo.Text & "',
                                '" & txtop1.Text & "','" & txtop2.Text & "', '" & Format(CDate(stime), "MM/dd/yyyy HH:mm") & "', '" & Format(CDate(ftime), "MM/dd/yyyy HH:mm") & "',
                                   '" & txtbatch1.Text & "', '" & Convert.ToDecimal(txtbaume1.Text) & "','" & txtbatch2.Text & "','" & Convert.ToDecimal(txtbaume2.Text) & "','" & txtbatch3.Text & "',
                                '" & Convert.ToDecimal(txtbaume3.Text) & "')"
            If cmd.ExecuteNonQuery() = 1 Then done = True

        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            cmd.Connection.Close()
        End Try
        Return done
    End Function

    Public Function f2()
        Dim done As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Dim con As New SqlConnection

        Try

            cmd.Connection.Open()
            cmd.CommandText = "INSERT INTO mm_spraystation_cope (date , shift,mould_origin,heat_number,mpo_number,spray_type,cope_number,cope_temp,ctc_operator,spr_operator,station,
                                                                       holding_oven,status,reason,baume,hub,plate,rim,tank_pressure,atom_pressure,trigger_pressure,
                                                                       cope_cleaner_machine,stop_pipe_make,stopper_head_make,cardboard_tube_make,
                                                                         ctc,dome_disc,remarks)
                                                                   values('" & Format(CDate(txtsdate.Text), "MM/dd/yyyy") & "','" & ddshift.SelectedItem.Value & "'
                                                                     ,'" & rblmouldorigin.SelectedItem.Value & "','" & Convert.ToInt64(txtheat.Text) & "',
                                                                   '" & ddmponumber.SelectedItem.Value & "','" & rblspray.SelectedItem.Value & "',
                                                                     '" & Convert.ToInt64(txtcopenumber.Text) & "','" & Convert.ToDecimal(txtcopetemp.Text) & "',
                                                                        '" & txtcctc.Text & "','" & txtcspr.Text & "','" & rblstation.SelectedItem.Value & "','" & ddholdingoven.SelectedItem.Value & "',
                                                                        '" & ddstatus.SelectedItem.Value & "','" & ddreason.SelectedItem.Value & "', '" & Convert.ToDecimal(txtcbaume.Text) & "',
                                                                        '" & Convert.ToDecimal(txtchub.Text) & "','" & Convert.ToDecimal(txtcplate.Text) & "','" & Convert.ToDecimal(txtcrim.Text) & "',
                                                                        '" & Convert.ToDecimal(txtctank.Text) & "','" & Convert.ToDecimal(txtcatom.Text) & "','" & Convert.ToDecimal(txtctrigger.Text) & "',
                                                                        '" & ddcopecleanermachine.SelectedItem.Value & "','" & txtcstoppipemake.Text & "','" & txtcstopperheadmake.Text & "',
                                                                        '" & txtccardboardtubemake.Text & "','" & ddctc.SelectedItem.Value & "','" & dddomedisc.SelectedItem.Value & "',
                                                                        '" & txtcremark.Text & "'
                                                                        )"
            If cmd.ExecuteNonQuery() = 1 Then done = True

        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            cmd.Connection.Close()
        End Try
        Return done
    End Function

    Public Function f3()
        Dim done As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Dim con As New SqlConnection

        Try

            cmd.Connection.Open()
            cmd.CommandText = "INSERT INTO mm_spraystation_drag (date , shift,mould_origin,heat_number,mpo_number,spray_type,drag_number,drag_temp,dt_operator,spr_operator, ingate_reamer,station,holding_oven,status,reason,baume,hub,
                plate_and_rim,tank_pressure,atom_pressure,trigger_pressure, drag_cleaner_machine,remarks) 
                                        values ('" & Format(CDate(txtsdate.Text), "MM/dd/yyyy") & "','" & ddshift.SelectedItem.Value & "','" & rblmouldorigin.SelectedItem.Value & "',
                                               '" & Convert.ToInt64(txtheat.Text) & "','" & ddmponumber.SelectedItem.Value & "','" & rblspray.SelectedItem.Value & "',
                                               '" & Convert.ToInt64(txtdragnumber.Text) & "','" & Convert.ToDecimal(txtdragtemp.Text) & "',
                                             '" & txtdt.Text & "','" & txtdspr.Text & "','" & txtir.Text & "','" & rbldstation.SelectedItem.Value & "','" & dddholdingoven.SelectedItem.Value & "',
                                           '" & dddstatus.SelectedItem.Value & "','" & dddreason.SelectedItem.Value & "','" & Convert.ToDecimal(txtdbaume.Text) & "',
                                            '" & Convert.ToDecimal(txtdhub.Text) & "','" & Convert.ToDecimal(txtdplaterim.Text) & "',
                                      '" & Convert.ToDecimal(txtdtank.Text) & "','" & Convert.ToDecimal(txtdatom.Text) & "','" & Convert.ToDecimal(txtdtrigger.Text) & "',
                                              '" & dddragcleanermachine.SelectedItem.Value & "','" & txtdremark.Text & "')"
            If cmd.ExecuteNonQuery() = 1 Then done = True

        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            cmd.Connection.Close()
        End Try
        Return done
    End Function

    Public Function f4()
        Dim done As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj

        Dim sdate As Date = CDate(txtsdate.Text)
        Dim shift As String = ddshift.SelectedItem.Value
        Dim sseje As String = txtsseje.Text
        Dim op As String = txtop.Text
        Dim wo As String = txtwo.Text
        Dim op1 As String = txtop1.Text
        Dim op2 As String = txtop2.Text
        Dim stime As DateTime = Convert.ToDateTime(txtstime.Text)
        Dim ftime As DateTime = Convert.ToDateTime(txtftime.Text)
        Dim bone As String = txtbatch1.Text
        Dim btwo As String = txtbatch2.Text
        Dim bthree As String = txtbatch3.Text
        Dim baone As String = Convert.ToDecimal(txtbaume1.Text)
        Dim batwo As String = Convert.ToDecimal(txtbaume2.Text)
        Dim bathree As String = Convert.ToDecimal(txtbaume3.Text)

        Try

            cmd.Connection.Open()

            cmd.CommandText = ("Update mm_spraystation_header set date=@sdate , shift=@shift , sse_or_je=@sseje ,operator=@op ,
                                         melting_workorder=@wo , spr_operator_one =@op1 , spr_operator_two = @op2 ,
                                         starttime=@stime, finishtime=@ftime, batch_one=@bone , baume_one=@baone,
                                          batch_two=@btwo , baume_two=@batwo,batch_three=@bthree , baume_three=@bathree
                                           where  date=@sdate and shift=@shift ")

            cmd.Parameters.AddWithValue("@sdate", sdate)
            cmd.Parameters.AddWithValue("@shift", shift)
            cmd.Parameters.AddWithValue("@sseje", sseje)
            cmd.Parameters.AddWithValue("@op", op)
            cmd.Parameters.AddWithValue("@wo", wo)
            cmd.Parameters.AddWithValue("@op1", op1)
            cmd.Parameters.AddWithValue("@op2", op2)
            cmd.Parameters.AddWithValue("@stime", stime)
            cmd.Parameters.AddWithValue("@ftime", ftime)
            cmd.Parameters.AddWithValue("@bone", bone)
            cmd.Parameters.AddWithValue("@baone", baone)
            cmd.Parameters.AddWithValue("@btwo", btwo)
            cmd.Parameters.AddWithValue("@batwo", batwo)
            cmd.Parameters.AddWithValue("@bthree", bthree)
            cmd.Parameters.AddWithValue("@bathree", bathree)

            If cmd.ExecuteNonQuery() = 1 Then done = True
            cmd.Connection.Close()
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally

        End Try
        Return done
    End Function

    Public Function f5()
        Dim done As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Dim con As New SqlConnection

        Dim sdate As Date = CDate(txtsdate.Text)
        Dim shift As String = ddshift.SelectedItem.Value
        Dim mould_origin As String = rblmouldorigin.SelectedItem.Value
        Dim heat_number As Integer = Convert.ToInt64(txtheat.Text)
        Dim mpo_number As String = ddmponumber.SelectedItem.Value
        Dim spray_type As String = rblspray.SelectedItem.Value
        Dim cope_number As Integer = Convert.ToInt64(txtcopenumber.Text)
        Dim cope_temp As Integer = Convert.ToDecimal(txtcopetemp.Text)
        Dim ctc_operator As String = txtcctc.Text
        Dim spr_operator As String = txtcspr.Text
        Dim station As String = rblstation.SelectedItem.Value
        Dim holding_oven As String = ddholdingoven.SelectedItem.Value
        Dim status As String = ddstatus.SelectedItem.Value
        Dim reason As String = ddreason.SelectedItem.Value
        Dim baume As String = Convert.ToDecimal(txtcbaume.Text)
        Dim hub As String = Convert.ToDecimal(txtchub.Text)
        Dim plate As String = Convert.ToDecimal(txtcplate.Text)
        Dim rim As String = Convert.ToDecimal(txtcrim.Text)
        Dim tank_pressure As String = Convert.ToDecimal(txtctank.Text)
        Dim atom_pressure As String = Convert.ToDecimal(txtcatom.Text)
        Dim trigger_pressure As String = Convert.ToDecimal(txtctrigger.Text)
        Dim cope_cleaner_machine As String = ddcopecleanermachine.SelectedItem.Value
        Dim stop_pipe_make As String = txtcstoppipemake.Text
        Dim stopper_head_make As String = txtcstopperheadmake.Text
        Dim cardboard_tube_make As String = txtccardboardtubemake.Text
        Dim ctc As String = ddctc.SelectedItem.Value
        Dim dome_disc As String = dddomedisc.SelectedItem.Value

        Try

            cmd.Connection.Open()
            cmd.CommandText = ("Update mm_spraystation_cope set mould_origin=@mould_origin,heat_number=@heat_number,mpo_number=@mpo_number,spray_type=@spray_type,cope_number=@cope_number,cope_temp=@cope_temp,ctc_operator=@ctc_operator,
	spr_operator=@spr_operator,station=@station,holding_oven=@holding_oven,status=@status,reason=@reason,baume=@baume,hub=@hub,plate=@plate,rim=@rim,tank_pressure=@tank_pressure,atom_pressure=@atom_pressure,
       trigger_pressure=@trigger_pressure, cope_cleaner_machine=@cope_cleaner_machine,stop_pipe_make=@stop_pipe_make,stopper_head_make=@stopper_head_make,cardboard_tube_make=@cardboard_tube_make,ctc=@ctc,dome_disc=@dome_disc
       where  date=@sdate and shift=@shift and cope_number=@cope_number")

            cmd.Parameters.AddWithValue("@sdate", sdate)
            cmd.Parameters.AddWithValue("@shift", shift)
            cmd.Parameters.AddWithValue("@mould_origin", mould_origin)
            cmd.Parameters.AddWithValue("@heat_number", heat_number)
            cmd.Parameters.AddWithValue("@mpo_number", mpo_number)
            cmd.Parameters.AddWithValue("@spray_type", spray_type)
            cmd.Parameters.AddWithValue("@cope_number", cope_number)
            cmd.Parameters.AddWithValue("@cope_temp", cope_temp)
            cmd.Parameters.AddWithValue("@ctc_operator", ctc_operator)
            cmd.Parameters.AddWithValue("@spr_operator", spr_operator)
            cmd.Parameters.AddWithValue("@station", station)
            cmd.Parameters.AddWithValue("@holding_oven", holding_oven)
            cmd.Parameters.AddWithValue("@status", status)
            cmd.Parameters.AddWithValue("@reason", reason)
            cmd.Parameters.AddWithValue("@baume", baume)
            cmd.Parameters.AddWithValue("@hub", hub)
            cmd.Parameters.AddWithValue("@plate", plate)
            cmd.Parameters.AddWithValue("@rim", rim)
            cmd.Parameters.AddWithValue("@tank_pressure", tank_pressure)
            cmd.Parameters.AddWithValue("@atom_pressure", atom_pressure)
            cmd.Parameters.AddWithValue("@trigger_pressure", trigger_pressure)
            cmd.Parameters.AddWithValue("@cope_cleaner_machine", cope_cleaner_machine)
            cmd.Parameters.AddWithValue("@stop_pipe_make", stop_pipe_make)
            cmd.Parameters.AddWithValue("@stopper_head_make", stopper_head_make)
            cmd.Parameters.AddWithValue("@cardboard_tube_make", cardboard_tube_make)
            cmd.Parameters.AddWithValue("@ctc", ctc)
            cmd.Parameters.AddWithValue("@dome_disc", dome_disc)

            If cmd.ExecuteNonQuery() = 1 Then done = True
            cmd.Connection.Close()
            SetScreen()
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally

        End Try
        Return done
    End Function

    Public Function f6()
        Dim done As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Dim con As New SqlConnection

        Dim sdate As Date = CDate(txtsdate.Text)
        Dim shift As String = ddshift.SelectedItem.Value
        Dim mould_origin As String = rblmouldorigin.SelectedItem.Value
        Dim heat_number As Integer = Convert.ToInt64(txtheat.Text)
        Dim mpo_number As String = ddmponumber.SelectedItem.Value
        Dim spray_type As String = rblspray.SelectedItem.Value
        Dim drag_number As Integer = Convert.ToInt64(txtdragnumber.Text)
        Dim drag_temp As Integer = Convert.ToDecimal(txtdragtemp.Text)
        Dim dt_operator As String = txtdt.Text
        Dim spr_operator As String = txtdspr.Text
        Dim ingate_reamer As String = txtir.Text
        Dim station As String = rbldstation.SelectedItem.Value
        Dim holding_oven As String = dddholdingoven.SelectedItem.Value
        Dim status As String = dddstatus.SelectedItem.Value
        Dim reason As String = dddreason.SelectedItem.Value
        Dim baume As String = Convert.ToDecimal(txtdbaume.Text)
        Dim hub As String = Convert.ToDecimal(txtdhub.Text)
        Dim platerim As String = Convert.ToDecimal(txtdplaterim.Text)
        Dim tank_pressure As String = Convert.ToDecimal(txtdtank.Text)
        Dim atom_pressure As String = Convert.ToDecimal(txtdatom.Text)
        Dim trigger_pressure As String = Convert.ToDecimal(txtdtrigger.Text)
        Dim drag_cleaner_machine As String = dddragcleanermachine.SelectedItem.Value

        Try

            cmd.Connection.Open()

            cmd.CommandText = ("Update mm_spraystation_drag set mould_origin=@mould_origin,heat_number=@heat_number,mpo_number=@mpo_number,spray_type=@spray_type,drag_number=@drag_number,drag_temp=@drag_temp,dt_operator=@dt_operator,
	ingate_reamer=@ingate_reamer, spr_operator=@spr_operator,station=@station,holding_oven=@holding_oven,status=@status,reason=@reason,baume=@baume,hub=@hub,plate_and_rim=@platerim,tank_pressure=@tank_pressure,
       atom_pressure=@atom_pressure,trigger_pressure=@trigger_pressure, drag_cleaner_machine=@drag_cleaner_machine where  date=@sdate and shift=@shift and drag_number=@drag_number")

            cmd.Parameters.AddWithValue("@sdate", sdate)
            cmd.Parameters.AddWithValue("@shift", shift)
            cmd.Parameters.AddWithValue("@mould_origin", mould_origin)
            cmd.Parameters.AddWithValue("@heat_number", heat_number)
            cmd.Parameters.AddWithValue("@mpo_number", mpo_number)
            cmd.Parameters.AddWithValue("@spray_type", spray_type)
            cmd.Parameters.AddWithValue("@drag_number", drag_number)
            cmd.Parameters.AddWithValue("@drag_temp", drag_temp)
            cmd.Parameters.AddWithValue("@dt_operator", dt_operator)
            cmd.Parameters.AddWithValue("@spr_operator", spr_operator)
            cmd.Parameters.AddWithValue("@ingate_reamer", ingate_reamer)
            cmd.Parameters.AddWithValue("@station", station)
            cmd.Parameters.AddWithValue("@holding_oven", holding_oven)
            cmd.Parameters.AddWithValue("@status", status)
            cmd.Parameters.AddWithValue("@reason", reason)
            cmd.Parameters.AddWithValue("@baume", baume)
            cmd.Parameters.AddWithValue("@hub", hub)
            cmd.Parameters.AddWithValue("@platerim", platerim)
            cmd.Parameters.AddWithValue("@tank_pressure", tank_pressure)
            cmd.Parameters.AddWithValue("@atom_pressure", atom_pressure)
            cmd.Parameters.AddWithValue("@trigger_pressure", trigger_pressure)
            cmd.Parameters.AddWithValue("@drag_cleaner_machine", drag_cleaner_machine)

            If cmd.ExecuteNonQuery() = 1 Then done = True
            cmd.Connection.Close()
            SetScreen()
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally

        End Try
        Return done
    End Function

    Public Function check()
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.Connection.Open()

        Dim sdate As Date = CDate(txtsdate.Text)
        Dim shift As String = ddshift.SelectedItem.Value

        cmd.CommandText = ("SELECT COUNT(*) FROM mm_spraystation_header where date=@sdate and shift=@shift")
        cmd.Parameters.AddWithValue("@sdate", sdate)
        cmd.Parameters.AddWithValue("@shift", shift)

        Try
            Dim i As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            Return i
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
        End Try


    End Function

    Public Function Ccheck()
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Dim con As New SqlConnection
        Dim sdate As Date = CDate(txtsdate.Text)
        Dim shift As String = ddshift.SelectedItem.Value
        Dim CopeNo As Integer = Convert.ToInt64(txtcopenumber.Text)

        cmd.Connection.Open()
        cmd.CommandText = ("SELECT COUNT(*) FROM mm_spraystation_cope where date=@sdate and shift=@shift and cope_number=@CopeNo")
        cmd.Parameters.AddWithValue("@sdate", sdate)
        cmd.Parameters.AddWithValue("@shift", shift)
        cmd.Parameters.AddWithValue("@CopeNo", CopeNo)

        Try
            Dim i As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            Return i
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
        End Try
    End Function

    Public Function Dcheck()
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Dim con As New SqlConnection
        Dim sdate As Date = CDate(txtsdate.Text)
        Dim shift As String = ddshift.SelectedItem.Value
        Dim DragNo As Integer = Convert.ToInt64(txtdragnumber.Text)

        cmd.Connection.Open()
        cmd.CommandText = ("SELECT COUNT(*) FROM mm_spraystation_drag where date=@sdate and shift=@shift and drag_number=@DragNo")
        cmd.Parameters.AddWithValue("@sdate", sdate)
        cmd.Parameters.AddWithValue("@shift", shift)
        cmd.Parameters.AddWithValue("@DragNo", DragNo)

        Try
            Dim i As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            Return i
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
        End Try
    End Function

    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Dim done, donne As Boolean

        If txtcopenumber.Text <> String.Empty Then
            Dim n As Integer = check()
            If n > 0 Then
                done = f4()
            Else
                done = f1()
            End If
            Dim nc As Integer = Ccheck()
            If nc > 0 Then
                donne = f5()
            Else
                donne = f2()
            End If

            If done And donne Then
                viewcopedata()
                lblmessage.Text = " Updation Successful !"
            End If
        Else
            lblmessage.Text = "PLEASE ENTER COPE NUMBER!"
        End If

    End Sub
    Protected Sub btnsave1_Click(sender As Object, e As EventArgs) Handles btnsave1.Click
        Dim done, donne As Boolean
        If txtdragnumber.Text <> String.Empty Then
            Dim n As Integer = check()
            If n > 0 Then
                done = f4()
            Else
                done = f1()
            End If
            Dim nd As Integer = Dcheck()
            If nd > 0 Then
                donne = f6()
            Else
                donne = f3()
            End If

            If done And donne Then
                viewdragdata()
                lblmessage.Text = " Updation Successful !"
            End If
        Else
            lblmessage.Text = "PLEASE ENTER DRAG NUMBER!"
        End If
    End Sub

    Protected Sub rblspray_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblspray.SelectedIndexChanged
        If rblspray.SelectedItem.Value = "cope" Then
            panelcope.Visible = True
            paneldrag.Visible = False
            setcope()
            viewcopedata()
            If rblstation.SelectedItem.Value = "station1" And rblspray.SelectedItem.Value = "cope" Then
                txtcspr.Text = txtop1.Text
            ElseIf rblstation.SelectedItem.Value = "station2" And rblspray.SelectedItem.Value = "cope" Then

                txtcspr.Text = txtop2.Text
            End If

        Else
            panelcope.Visible = False
            paneldrag.Visible = True
            setdrag()
            viewdragdata()
            If rbldstation.SelectedItem.Value = "station1" And rblspray.SelectedItem.Value = "drag" Then
                txtdspr.Text = txtop1.Text
            ElseIf rbldstation.SelectedItem.Value = "station2" And rblspray.SelectedItem.Value = "drag" Then

                txtdspr.Text = txtop2.Text
            End If
        End If
    End Sub

    Protected Sub rblmouldorigin_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblmouldorigin.SelectedIndexChanged
        If rblmouldorigin.SelectedItem.Value = "heat" Then
            lheat.Visible = True
            txtheat.Visible = True

            lmpo.Visible = False
            ddmponumber.Visible = False
            ddmponumber.SelectedItem.Value = "null"
        Else
            lheat.Visible = False
            txtheat.Text = "0"
            txtheat.Visible = False
            lmpo.Visible = False
            ddmponumber.Visible = False
        End If
    End Sub

    Private Sub getdatacope()
        Dim temp As Boolean = False
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Dim con As New SqlConnection

        cmd.Connection.Open()
        cmd.CommandText = ("select baume ,hub,plate,rim,tank_pressure,atom_pressure,trigger_pressure  from mm_spraystation_cope where heat_number =(
                                                                                select top 1 heat_number from mm_spraystation_cope order by heat_number desc)")
        Dim dr As SqlDataReader = cmd.ExecuteReader()

        While dr.Read()
            txtcbaume.Text = dr.GetDecimal(0)
            txtchub.Text = dr.GetDecimal(1)
            txtcplate.Text = dr.GetDecimal(2)
            txtcrim.Text = dr.GetDecimal(3)
            txtctank.Text = dr.GetDecimal(4)
            txtcatom.Text = dr.GetDecimal(5)
            txtctrigger.Text = dr.GetDecimal(6)
            temp = True
        End While

        If temp = False Then
            lblmessage.Text = "please add a record"
        End If
        cmd.Connection.Close()
    End Sub

    Private Sub getdatadrag()
        Dim temp As Boolean = False
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Dim con As New SqlConnection

        'Dim con As SqlConnection = New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User ID=sa;Password=sadev123")
        'con.Open()
        cmd.Connection.Open()
        cmd.CommandText = ("select baume,hub,plate_and_rim,tank_pressure,atom_pressure,trigger_pressure  from mm_spraystation_drag where heat_number =(
                                                                                select top 1 heat_number from mm_spraystation_drag order by heat_number desc)")
        Dim dr As SqlDataReader = cmd.ExecuteReader()

        While dr.Read()
            txtdbaume.Text = dr.GetDecimal(0)
            txtdhub.Text = dr.GetDecimal(1)
            txtdplaterim.Text = dr.GetDecimal(2)
            txtdtank.Text = dr.GetDecimal(3)
            txtdatom.Text = dr.GetDecimal(4)
            txtdtrigger.Text = dr.GetDecimal(5)
            temp = True
        End While

        If temp = False Then
            lblmessage.Text = "please add a record"
        End If
        cmd.Connection.Close()
    End Sub
    Public Sub getcopeheat()
        Dim temp As Boolean = False
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Dim con As New SqlConnection

        cmd.Connection.Open()
        cmd.CommandText = ("select top 1 heat_number from mm_spraystation_cope order by heat_number desc ")

        txtheat.Text = cmd.ExecuteScalar()

        temp = True
        If temp = False Then
            lblmessage.Text = "please add a record"
        End If
        cmd.Connection.Close()
    End Sub
    Public Sub getdragheat()
        Dim temp As Boolean = False
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Dim con As New SqlConnection

        cmd.Connection.Open()
        cmd.CommandText = ("select top 1 heat_number from mm_spraystation_drag order by heat_number desc ")

        txtheat.Text = cmd.ExecuteScalar()

        temp = True
        If temp = False Then
            lblmessage.Text = "please add a record"
        End If
        cmd.Connection.Close()
    End Sub

    Public Sub viewcopedata()
        Dim sqlstr1
        sqlstr1 = "SELECT ROW_NUMBER() OVER(ORDER BY id asc) AS ID,CONVERT(VARCHAR,LEFT(date,11)) date,shift,mould_origin,heat_number,spray_type ,cope_number,cope_temp,ctc_operator,spr_operator,station,holding_oven,status,reason,baume,hub,plate ,rim,tank_pressure,atom_pressure,trigger_pressure ,cope_cleaner_machine ,stop_pipe_make,stopper_head_make,cardboard_tube_make ,ctc ,dome_disc ,remarks FROM mm_spraystation_cope where date='" & Format(CDate(txtsdate.Text), "MM/dd/yyyy") & "'  and shift='" & ddshift.SelectedItem.Value & "' order by ID desc"
        Call BindCopeGrid(sqlstr1)
    End Sub

    Public Sub viewdragdata()
        Dim sqlstr2
        sqlstr2 = "SELECT ROW_NUMBER() OVER(ORDER BY id asc) AS ID,CONVERT(VARCHAR,LEFT(date,11)) date ,shift,mould_origin,heat_number,spray_type,drag_number,drag_temp ,dt_operator ,spr_operator,ingate_reamer ,station,holding_oven,status ,reason,baume,hub,plate_and_rim ,tank_pressure ,atom_pressure,trigger_pressure ,drag_cleaner_machine,remarks FROM wap.dbo.mm_spraystation_drag where date='" & Format(CDate(txtsdate.Text), "MM/dd/yyyy") & "'  and shift='" & ddshift.SelectedItem.Value & "' order by ID desc"
        Call BindDragGrid(sqlstr2)
    End Sub

    Private Sub BindCopeGrid(ByVal strArg As String)
        Dim objCmd As SqlCommand
        Dim objDr As SqlDataReader

        If con.State = ConnectionState.Closed Then
            con.Open()
        Else
            con.Close()
            con.Open()
        End If
        Try
            objCmd = New SqlCommand(strArg, con)
            objDr = objCmd.ExecuteReader()
            Dim arr() As String
            DGCope.DataSource = arr
            DGCope.DataBind()
            DGCope.DataSource = objDr
            DGCope.DataBind()
        Catch exp As SqlException
            strSql = exp.StackTrace
            lblmessage.Text = "Line :  " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message

        Catch exp As Exception
            strSql = exp.StackTrace
            lblmessage.Text = "Line  " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message
        End Try
        con.Close()
    End Sub

    Private Sub BindDragGrid(ByVal strArg As String)
        Dim objCmd As SqlCommand
        Dim objDr As SqlDataReader

        If con.State = ConnectionState.Closed Then
            con.Open()
        Else
            con.Close()
            con.Open()
        End If
        Try
            objCmd = New SqlCommand(strArg, con)
            objDr = objCmd.ExecuteReader()
            Dim arr() As String
            DGdrag.DataSource = arr
            DGdrag.DataBind()
            DGdrag.DataSource = objDr
            DGdrag.DataBind()
        Catch exp As SqlException
            strSql = exp.StackTrace
            lblmessage.Text = "Line :  " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message

        Catch exp As Exception
            strSql = exp.StackTrace
            lblmessage.Text = "Line  " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message
        End Try
        con.Close()
    End Sub

    Private Sub DGDrag_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DGdrag.ItemCommand
        i = e.Item.ItemIndex()
    End Sub

    Private Sub DGCope_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DGCope.ItemCommand
        i = e.Item.ItemIndex()
    End Sub

    Protected Sub DGCope_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DGCope.SelectedIndexChanged
        DGCope.SelectedIndex = i

        rblmouldorigin.SelectedItem.Text = DGCope.Items(i).Cells(4).Text
        txtheat.Text = Trim(DGCope.Items(i).Cells(5).Text)
        rblspray.SelectedItem.Text = DGCope.Items(i).Cells(6).Text
        txtcopenumber.Text = Trim(DGCope.Items(i).Cells(7).Text)
        txtcopetemp.Text = Trim(DGCope.Items(i).Cells(8).Text)
        rblstation.SelectedItem.Text = DGCope.Items(i).Cells(11).Text
        ddholdingoven.SelectedItem.Text = DGCope.Items(i).Cells(12).Text
        ddstatus.SelectedItem.Text = DGCope.Items(i).Cells(13).Text
        ddreason.SelectedItem.Text = DGCope.Items(i).Cells(14).Text
        txtcbaume.Text = Trim(DGCope.Items(i).Cells(15).Text)
        txtchub.Text = Trim(DGCope.Items(i).Cells(16).Text)
        txtcplate.Text = Trim(DGCope.Items(i).Cells(17).Text)
        txtcrim.Text = Trim(DGCope.Items(i).Cells(18).Text)
        txtctank.Text = Trim(DGCope.Items(i).Cells(19).Text)
        txtcatom.Text = Trim(DGCope.Items(i).Cells(20).Text)
        txtctrigger.Text = Trim(DGCope.Items(i).Cells(21).Text)
        ddcopecleanermachine.SelectedItem.Text = DGCope.Items(i).Cells(22).Text
        txtcstoppipemake.Text = Trim(DGCope.Items(i).Cells(23).Text)
        txtcstopperheadmake.Text = Trim(DGCope.Items(i).Cells(24).Text)
        txtccardboardtubemake.Text = Trim(DGCope.Items(i).Cells(25).Text)
        ddctc.SelectedItem.Text = DGCope.Items(i).Cells(26).Text
        dddomedisc.SelectedItem.Text = DGCope.Items(i).Cells(27).Text
        txtcremark.Text = Trim(DGCope.Items(i).Cells(28).Text)
    End Sub

    Protected Sub DGDrag_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DGdrag.SelectedIndexChanged
        DGdrag.SelectedIndex = i

        rblmouldorigin.SelectedItem.Text = DGCope.Items(i).Cells(4).Text
        txtheat.Text = Trim(DGCope.Items(i).Cells(5).Text)
        rblspray.SelectedItem.Text = DGCope.Items(i).Cells(6).Text
        txtdragnumber.Text = Trim(DGCope.Items(i).Cells(7).Text)
        txtdragtemp.Text = Trim(DGCope.Items(i).Cells(8).Text)
        txtdt.Text = Trim(DGCope.Items(i).Cells(9).Text)
        txtir.Text = Trim(DGCope.Items(i).Cells(11).Text)
        rblstation.SelectedItem.Text = DGCope.Items(i).Cells(12).Text
        dddholdingoven.SelectedItem.Text = DGCope.Items(i).Cells(13).Text
        dddstatus.SelectedItem.Text = DGCope.Items(i).Cells(14).Text
        dddreason.SelectedItem.Text = DGCope.Items(i).Cells(15).Text
        txtdbaume.Text = Trim(DGCope.Items(i).Cells(16).Text)
        txtdhub.Text = Trim(DGCope.Items(i).Cells(17).Text)
        txtdplaterim.Text = Trim(DGCope.Items(i).Cells(18).Text)
        txtdtank.Text = Trim(DGCope.Items(i).Cells(19).Text)
        txtdatom.Text = Trim(DGCope.Items(i).Cells(20).Text)
        txtdtrigger.Text = Trim(DGCope.Items(i).Cells(21).Text)
        dddragcleanermachine.SelectedItem.Text = DGCope.Items(i).Cells(22).Text
        txtcremark.Text = Trim(DGCope.Items(i).Cells(23).Text)
    End Sub

    Protected Sub txtsdate_TextChanged(sender As Object, e As EventArgs) Handles txtsdate.TextChanged
        If rblspray.SelectedItem.Value = "cope" Then
            panelcope.Visible = True
            paneldrag.Visible = False
            'setcope()
            viewcopedata()

        Else
            panelcope.Visible = False
            paneldrag.Visible = True
            'setdrag()
            viewdragdata()
        End If
    End Sub

    Protected Sub ddshift_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddshift.SelectedIndexChanged
        If rblspray.SelectedItem.Value = "cope" Then
            panelcope.Visible = True
            paneldrag.Visible = False
            'setcope()
            viewcopedata()
            If rblstation.SelectedItem.Value = "station1" And rblspray.SelectedItem.Value = "cope" Then
                txtcspr.Text = txtop1.Text
            ElseIf rblstation.SelectedItem.Value = "station2" And rblspray.SelectedItem.Value = "cope" Then

                txtcspr.Text = txtop2.Text
            End If
        Else
            panelcope.Visible = False
            paneldrag.Visible = True
            'setdrag()
            viewdragdata()
            If rbldstation.SelectedItem.Value = "station1" And rblspray.SelectedItem.Value = "drag" Then
                txtdspr.Text = txtop1.Text
            ElseIf rbldstation.SelectedItem.Value = "station2" And rblspray.SelectedItem.Value = "drag" Then

                txtdspr.Text = txtop2.Text
            End If
        End If
    End Sub

    Protected Sub rblstation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblstation.SelectedIndexChanged
        If rblstation.SelectedItem.Value = "station1" Then
            txtcspr.Text = txtop1.Text
        ElseIf rblstation.SelectedItem.Value = "station2" Then

            txtcspr.Text = txtop2.Text
        End If
    End Sub

    Protected Sub rbldstation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rbldstation.SelectedIndexChanged
        If rbldstation.SelectedItem.Value = "station1" Then
            txtdspr.Text = txtop1.Text
        ElseIf rbldstation.SelectedItem.Value = "station2" Then

            txtdspr.Text = txtop2.Text
        End If
    End Sub

    Protected Sub txtop1_TextChanged(sender As Object, e As EventArgs) Handles txtop1.TextChanged
        If rblstation.SelectedItem.Value = "station1" And rblspray.SelectedItem.Value = "cope" Then
            txtcspr.Text = txtop1.Text
        ElseIf rblstation.SelectedItem.Value = "station2" And rblspray.SelectedItem.Value = "cope" Then

            txtcspr.Text = txtop2.Text
        End If
        If rbldstation.SelectedItem.Value = "station1" And rblspray.SelectedItem.Value = "drag" Then
            txtdspr.Text = txtop1.Text
        ElseIf rbldstation.SelectedItem.Value = "station2" And rblspray.SelectedItem.Value = "drag" Then

            txtdspr.Text = txtop2.Text
        End If
    End Sub

    Protected Sub txtop2_TextChanged(sender As Object, e As EventArgs) Handles txtop2.TextChanged
        If rblstation.SelectedItem.Value = "station1" And rblspray.SelectedItem.Value = "cope" Then
            txtcspr.Text = txtop1.Text
        ElseIf rblstation.SelectedItem.Value = "station2" And rblspray.SelectedItem.Value = "cope" Then

            txtcspr.Text = txtop2.Text
        End If
        If rbldstation.SelectedItem.Value = "station1" And rblspray.SelectedItem.Value = "drag" Then
            txtdspr.Text = txtop1.Text
        ElseIf rbldstation.SelectedItem.Value = "station2" And rblspray.SelectedItem.Value = "drag" Then

            txtdspr.Text = txtop2.Text
        End If
    End Sub


End Class