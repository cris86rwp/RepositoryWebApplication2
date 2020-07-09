Imports System.Data
Imports System.Data.SqlClient

Public Class sand_recipe_table
    Inherits System.Web.UI.Page

    Protected WithEvents tbx_date As System.Web.UI.WebControls.TextBox
    Protected WithEvents tbx_sand As System.Web.UI.WebControls.TextBox
    Protected WithEvents tbx_resin_prcntg As System.Web.UI.WebControls.TextBox
    Protected WithEvents tbx_resin_wght As System.Web.UI.WebControls.TextBox
    Protected WithEvents tbx_hexa_sol As System.Web.UI.WebControls.TextBox
    Protected WithEvents tbx_pre_mix_time As System.Web.UI.WebControls.TextBox
    Protected WithEvents tbx_main_mix As System.Web.UI.WebControls.TextBox
    Protected WithEvents tbx_sand_intemp As System.Web.UI.WebControls.TextBox
    Protected WithEvents tbx_sand_outtemp As System.Web.UI.WebControls.TextBox
    Protected WithEvents tbx_hexa_wtr As System.Web.UI.WebControls.TextBox
    Protected WithEvents tbx_hexa_powder As System.Web.UI.WebControls.TextBox
    Protected WithEvents tbx_cts As System.Web.UI.WebControls.TextBox
    Protected WithEvents tbx_hts As System.Web.UI.WebControls.TextBox
    Protected WithEvents tbx_stick_pt As System.Web.UI.WebControls.TextBox
    Protected WithEvents tbx_timer_set As System.Web.UI.WebControls.TextBox
    Protected WithEvents tbx_sand_silo As System.Web.UI.WebControls.TextBox
    Protected WithEvents tbx_remarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents lbl_date As System.Web.UI.WebControls.Label
    Protected WithEvents lbl_sand As System.Web.UI.WebControls.Label
    Protected WithEvents lbl_resin_prcntg As System.Web.UI.WebControls.Label
    Protected WithEvents lbl_resin_wght As System.Web.UI.WebControls.Label
    Protected WithEvents lbl_hexa_sol As System.Web.UI.WebControls.Label
    Protected WithEvents lbl_pre_mix_time As System.Web.UI.WebControls.Label
    Protected WithEvents lbl_main_mix As System.Web.UI.WebControls.Label
    Protected WithEvents lbl_sand_intemp As System.Web.UI.WebControls.Label
    Protected WithEvents lbl_sand_outtemp As System.Web.UI.WebControls.Label
    Protected WithEvents lbl_hexa_wtr As System.Web.UI.WebControls.Label
    Protected WithEvents lbl_hexa_powder As System.Web.UI.WebControls.Label
    Protected WithEvents lbl_cts As System.Web.UI.WebControls.Label
    Protected WithEvents lbl_hts As System.Web.UI.WebControls.Label
    Protected WithEvents lbl_stick_pt As System.Web.UI.WebControls.Label
    Protected WithEvents lbl_timer_set As System.Web.UI.WebControls.Label
    Protected WithEvents lbl_sand_silo As System.Web.UI.WebControls.Label
    Protected WithEvents lbl_remarks As System.Web.UI.WebControls.Label



    Protected WithEvents sanddate As System.Web.UI.WebControls.TextBox

    Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            Try
                cmd.Connection.Open()
                cmd.CommandText = " Select  Top 1 * from  mm_sand_recipe order by date_changed desc "

                Dim sdr As SqlDataReader
                sdr = cmd.ExecuteReader()
                sdr.Read()
                tbx_date.Text = sdr("date_changed")
                tbx_sand.Text = sdr("sand_weight").ToString()
                tbx_resin_prcntg.Text = sdr("resin_prcnt").ToString()
                tbx_resin_wght.Text = sdr("resin_wght").ToString()
                tbx_hexa_sol.Text = sdr("hexa_wght").ToString()
                tbx_pre_mix_time.Text = sdr("pre_mix_time").ToString()
                tbx_main_mix.Text = sdr("main_mix_time").ToString()
                tbx_sand_intemp.Text = sdr("sand_in_temp").ToString()
                tbx_sand_outtemp.Text = sdr("sand_out_temp").ToString()
                tbx_hexa_wtr.Text = sdr("water_hexa").ToString()
                tbx_hexa_powder.Text = sdr("hexa_powder").ToString()
                tbx_cts.Text = sdr("cts_required").ToString()
                tbx_hts.Text = sdr("hts_required").ToString()
                tbx_stick_pt.Text = sdr("stick_point_required").ToString()
                tbx_timer_set.Text = sdr("timer_set").ToString()
                tbx_sand_silo.Text = sdr("sand_temp_silo").ToString()
                tbx_remarks.Text = sdr("remarks").ToString()
                sdr.Close()

            Catch ex As Exception
                Throw New Exception(ex.Message)
            Finally
                cmd.Connection.Close()
            End Try
        End If
    End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Try
            cmd.Connection.Open()
            'cmd.CommandText = "UPDATE mm_sand_recipe(date_changed, sand_weight, resin_prcnt, resin_wght, hexa_wght, pre_mix_time, main_mix_time, sand_in_temp, sand_out_temp,
            'water_hexa, hexa_powder, cts_required, hts_required, stick_point_required, timer_set, sand_temp_silo, remarks)
            'VALUES('" & Convert.ToDateTime(tbx_date.Text) & "','" & tbx_sand.Text & "','" & tbx_resin_prcntg.Text & "','" & tbx_resin_wght.Text & "',
            ''" & tbx_hexa_sol.Text & "','" & tbx_pre_mix_time.Text & "','" & tbx_main_mix.Text & "','" & tbx_sand_intemp.Text & "','" & tbx_sand_outtemp.Text & "',
            ''" & tbx_hexa_wtr.Text & "','" & tbx_hexa_powder.Text & "','" & tbx_cts.Text & "','" & tbx_hts.Text & "','" & tbx_stick_pt.Text & "','" & tbx_timer_set.Text & "','" & tbx_sand_silo.Text & "',
            ''" & tbx_remarks.Text & "')"
            cmd.CommandText = "UPDATE mm_sand_recipe set date_changed= '" & Format(CDate(tbx_date.Text), "MM/dd/yyyy") & "',
                sand_weight= '" & tbx_sand.Text & "',resin_prcnt='" & tbx_resin_prcntg.Text & "',
                resin_wght='" & tbx_resin_wght.Text & "',hexa_wght='" & tbx_hexa_sol.Text & "', 
                pre_mix_time='" & tbx_pre_mix_time.Text & "',main_mix_time='" & tbx_main_mix.Text & "',
                sand_in_temp= '" & tbx_sand_intemp.Text & "',sand_out_temp='" & tbx_sand_outtemp.Text & "',
                water_hexa='" & tbx_hexa_wtr.Text & "',hexa_powder='" & tbx_hexa_powder.Text & "',
                cts_required='" & tbx_cts.Text & "',hts_required='" & tbx_hts.Text & "',
                stick_point_required='" & tbx_stick_pt.Text & "', timer_set='" & tbx_timer_set.Text & "',
                sand_temp_silo='" & tbx_sand_silo.Text & "',remarks='" & tbx_remarks.Text & "'"

            cmd.ExecuteNonQuery()
        Catch ex1 As Exception
            Throw New Exception(ex1.Message)
        Finally
            cmd.Connection.Close()
        End Try

    End Sub

    'cmd.CommandText = "UPDATE mm_sand_recipe set date_changed= '" & Convert.ToDateTime(tbx_date.Text) & "',sand_weight= '" & tbx_sand.Text & "',resin_prcnt='" & tbx_resin_prcntg.Text & "',resin_wght='" & tbx_resin_wght.Text & "',hexa_wght='" & tbx_hexa_sol.Text & "', pre_mix_time='" & tbx_pre_mix_time.Text & "',main_mix_time='" & tbx_main_mix.Text & "',sand_in_temp= '" & tbx_sand_intemp.Text & "',sand_out_temp='" & tbx_sand_outtemp.Text & "',water_hexa='" & tbx_hexa_wtr.Text & "',hexa_powder='" & tbx_hexa_powder.Text & "',cts_required='" & tbx_cts.Text & "',hts_required='" & tbx_hts.Text & "',stick_point_required='" & tbx_stick_pt.Text & "', timer_set='" & tbx_timer_set.Text & "',sand_temp_silo='" & tbx_sand_silo.Text & "',remarks='" & tbx_remarks.Text & "'"

    Protected Sub btn_exit_Click(sender As Object, e As EventArgs) Handles btn_exit.Click
        ClientScript.RegisterClientScriptBlock(Me.GetType(), "CloseWindowScript", "window.close();", True)
    End Sub


End Class








'Imports System.Data
'Imports System.Data.SqlClient

'Public Class sand_recipe_table
'    Inherits System.Web.UI.Page

'    Protected WithEvents tbx_date As System.Web.UI.WebControls.TextBox
'    Protected WithEvents tbx_sand As System.Web.UI.WebControls.TextBox
'    Protected WithEvents tbx_resin_prcntg As System.Web.UI.WebControls.TextBox
'    Protected WithEvents tbx_resin_wght As System.Web.UI.WebControls.TextBox
'    Protected WithEvents tbx_hexa_sol As System.Web.UI.WebControls.TextBox
'    Protected WithEvents tbx_pre_mix_time As System.Web.UI.WebControls.TextBox
'    Protected WithEvents tbx_main_mix As System.Web.UI.WebControls.TextBox
'    Protected WithEvents tbx_sand_intemp As System.Web.UI.WebControls.TextBox
'    Protected WithEvents tbx_sand_outtemp As System.Web.UI.WebControls.TextBox
'    Protected WithEvents tbx_hexa_wtr As System.Web.UI.WebControls.TextBox
'    Protected WithEvents tbx_hexa_powder As System.Web.UI.WebControls.TextBox
'    Protected WithEvents tbx_cts As System.Web.UI.WebControls.TextBox
'    Protected WithEvents tbx_hts As System.Web.UI.WebControls.TextBox
'    Protected WithEvents tbx_stick_pt As System.Web.UI.WebControls.TextBox
'    Protected WithEvents tbx_timer_set As System.Web.UI.WebControls.TextBox
'    Protected WithEvents tbx_sand_silo As System.Web.UI.WebControls.TextBox
'    Protected WithEvents tbx_remarks As System.Web.UI.WebControls.TextBox
'    Protected WithEvents lbl_date As System.Web.UI.WebControls.Label
'    Protected WithEvents lbl_sand As System.Web.UI.WebControls.Label
'    Protected WithEvents lbl_resin_prcntg As System.Web.UI.WebControls.Label
'    Protected WithEvents lbl_resin_wght As System.Web.UI.WebControls.Label
'    Protected WithEvents lbl_hexa_sol As System.Web.UI.WebControls.Label
'    Protected WithEvents lbl_pre_mix_time As System.Web.UI.WebControls.Label
'    Protected WithEvents lbl_main_mix As System.Web.UI.WebControls.Label
'    Protected WithEvents lbl_sand_intemp As System.Web.UI.WebControls.Label
'    Protected WithEvents lbl_sand_outtemp As System.Web.UI.WebControls.Label
'    Protected WithEvents lbl_hexa_wtr As System.Web.UI.WebControls.Label
'    Protected WithEvents lbl_hexa_powder As System.Web.UI.WebControls.Label
'    Protected WithEvents lbl_cts As System.Web.UI.WebControls.Label
'    Protected WithEvents lbl_hts As System.Web.UI.WebControls.Label
'    Protected WithEvents lbl_stick_pt As System.Web.UI.WebControls.Label
'    Protected WithEvents lbl_timer_set As System.Web.UI.WebControls.Label
'    Protected WithEvents lbl_sand_silo As System.Web.UI.WebControls.Label
'    Protected WithEvents lbl_remarks As System.Web.UI.WebControls.Label



'    Protected WithEvents sanddate As System.Web.UI.WebControls.TextBox

'    Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj

'    Dim upstring As String

'    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
'        Try
'            cmd.Connection.Open()
'            cmd.CommandText = "SELECT * from mm_sand_recipe ORDER BY date_changed DESC"

'            Dim sdr As SqlDataReader
'            sdr = cmd.ExecuteReader()
'            sdr.Read()
'            tbx_date.Text = sdr("date_changed")
'            tbx_sand.Text = sdr("sand_weight").ToString()
'            tbx_resin_prcntg.Text = sdr("resin_prcnt").ToString()
'            tbx_resin_wght.Text = sdr("resin_wght").ToString()
'            tbx_hexa_sol.Text = sdr("hexa_wght").ToString()
'            tbx_pre_mix_time.Text = sdr("pre_mix_time").ToString()
'            tbx_main_mix.Text = sdr("main_mix_time").ToString()
'            tbx_sand_intemp.Text = sdr("sand_in_temp").ToString()
'            tbx_sand_outtemp.Text = sdr("sand_out_temp").ToString()
'            tbx_hexa_wtr.Text = sdr("water_hexa").ToString()
'            tbx_hexa_sol.Text = sdr("hexa_powder").ToString()
'            tbx_cts.Text = sdr("cts_required").ToString()
'            tbx_hts.Text = sdr("hts_required").ToString()
'            tbx_stick_pt.Text = sdr("stick_point_required").ToString()
'            tbx_timer_set.Text = sdr("timer_set").ToString()
'            tbx_sand_silo.Text = sdr("sand_temp_silo").ToString()
'            tbx_remarks.Text = sdr("remarks").ToString()
'            sdr.Close()

'        Catch ex As Exception
'            Throw New Exception(ex.Message)
'        Finally
'            cmd.Connection.Close()
'        End Try
'    End Sub

'    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click

'        'Try
'        '    cmd.Connection.Open()
'        '    upstring = "UPDATE mm_sand_recipe SET date_changed='" & Date.Parse(tbx_date.Text) & "', sand_weight='" & tbx_sand.Text & "' , resin_prcnt= '" & tbx_resin_prcntg.Text & "', 
'        '    resin_wght=" & tbx_resin_wght.Text & ", hexa_wght=" & tbx_hexa_sol.Text & ",
'        '    pre_mix_time=" & tbx_pre_mix_time.Text & ", main_mix_time=" & tbx_main_mix.Text & ", sand_in_temp='" & tbx_sand_intemp.Text & "', sand_out_temp='" & tbx_sand_outtemp.Text & "',
'        '    water_hexa=" & tbx_hexa_wtr.Text & ", hexa_powder=" & tbx_hexa_powder.Text & ", cts_required=" & tbx_cts.Text & ", hts_required=" & tbx_hts.Text & ",
'        '    stick_point_required=" & tbx_stick_pt.Text & ", timer_set=" & tbx_timer_set.Text & ", sand_temp_silo=" & tbx_sand_silo.Text & ", remarks" & tbx_remarks.Text & "


'        '    cmd.ExecuteNonQuery()
'        'Catch ex1 As Exception
'        '    Throw New Exception(ex1.Message)
'        'Finally
'        '    cmd.Connection.Close()
'        'End Try
'    End Sub



'    Protected Sub btn_exit_Click(sender As Object, e As EventArgs) Handles btn_exit.Click
'        ClientScript.RegisterClientScriptBlock(Me.GetType(), "CloseWindowScript", "window.close();", True)
'    End Sub


'End Class





''Dim strsql As String
''Dim sqlpara(17) As SqlParameter
''sqlpara(0) = New SqlParameter("@txt_date", Trim(tbx_date.Text))
''sqlpara(1) = New SqlParameter("@txt_sand", Trim(tbx_sand.Text))
''sqlpara(2) = New SqlParameter("@txt_resin_cnt", Trim(tbx_resin_prcntg.Text))
''sqlpara(3) = New SqlParameter("@txt_resin_wght", Trim(tbx_resin_wght.Text))
''sqlpara(4) = New SqlParameter("@txt_hx_sol", Trim(tbx_hexa_sol.Text))
''sqlpara(5) = New SqlParameter("@txt_", CDate(txtNF_date.Text))
''sqlpara(6) = New SqlParameter("@cboShift", Trim(cboShift.SelectedItem.Text))
''sqlpara(7) = New SqlParameter("@txtTime_in", CDate(txtTime_in.Text))
''sqlpara(8) = New SqlParameter("@txtTime_out", CDate(txtTime_out.Text))
''sqlpara(9) = New SqlParameter("@txtWheel_number", Trim(txtWheel_number.Text))
'''  sqlPara(10) = New SqlParameter("@txtOffload_code", Trim(txtOffload_code.Text))

'Try
'    strsql = "update mm_normalizing_furnace_loading set operator_code=@txtOperator_name where loading_date='" & txtNF_date.Text & "' and shift_code='" & cboShift.SelectedItem.Text & "' and heat_number='" & txtHeat_number.Text & "'"


'    SqlHelper.ExecuteNonQuery(con, CommandType.Text, strsql, sqlpara)


'UPDATE mm_sand_recipe SET (date_changed, sand_weight, resin_prcnt, resin_wght, hexa_wght, pre_mix_time, main_mix_time, sand_in_temp, sand_out_temp,
'        water_hexa, hexa_powder, cts_required, hts_required, stick_point_required, timer_set, sand_temp_silo, remarks)
'        VALUES('" & Date.Parse(tbx_date.Text) & "','" & tbx_sand.Text & "','" & tbx_resin_prcntg.Text & "','" & tbx_resin_wght.Text & "',
'        '" & tbx_hexa_sol.Text & "','" & tbx_pre_mix_time.Text & "','" & tbx_main_mix.Text & "','" & tbx_sand_intemp.Text & "','" & tbx_sand_outtemp.Text & "',
'        '" & tbx_hexa_wtr.Text & "','" & tbx_hexa_powder.Text & "','" & tbx_cts.Text & "','" & tbx_hts.Text & "','" & tbx_stick_pt.Text & "','" & tbx_timer_set.Text & "','" & tbx_sand_silo.Text & "',
'        '" & tbx_remarks.Text & "')"