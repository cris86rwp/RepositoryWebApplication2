Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports System.Data
Imports System.DateTime

Public Class pouringtube_pre
    Inherits System.Web.UI.Page
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents Panel7 As System.Web.UI.WebControls.Panel
    Protected WithEvents shift_dd1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents date_txt As System.Web.UI.WebControls.TextBox
    Protected WithEvents sse_txt As System.Web.UI.WebControls.TextBox
    Protected WithEvents op1_txt As System.Web.UI.WebControls.TextBox
    Protected WithEvents op2_txt As System.Web.UI.WebControls.TextBox
    Protected WithEvents op3_txt As System.Web.UI.WebControls.TextBox
    Protected WithEvents super_txt As System.Web.UI.WebControls.TextBox
    Protected WithEvents pressing_txt As System.Web.UI.WebControls.TextBox
    Protected WithEvents measuring_txt As System.Web.UI.WebControls.TextBox
    Protected WithEvents height_txt As System.Web.UI.WebControls.TextBox
    Protected WithEvents Tube_centeringtn1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Tube_centeringtn2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Tube_centeringtn3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Tube_centeringtn4 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Tube_centeringtn5 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Tube_centeringtn6 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Tube_centeringtn7 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Tube_centeringtn8 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Tube_centeringtn9 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Tube_centeringtn10 As System.Web.UI.WebControls.TextBox
    Protected WithEvents parting_tn1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents parting_tn2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents parting_tn3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents parting_tn4 As System.Web.UI.WebControls.TextBox
    Protected WithEvents parting_tn5 As System.Web.UI.WebControls.TextBox
    Protected WithEvents parting_tn6 As System.Web.UI.WebControls.TextBox
    Protected WithEvents parting_tn7 As System.Web.UI.WebControls.TextBox
    Protected WithEvents parting_tn8 As System.Web.UI.WebControls.TextBox
    Protected WithEvents parting_tn9 As System.Web.UI.WebControls.TextBox
    Protected WithEvents parting_tn10 As System.Web.UI.WebControls.TextBox
    Protected WithEvents tubeno_tn1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents tubeno_tn2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents tubeno_tn3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents tubeno_tn4 As System.Web.UI.WebControls.TextBox
    Protected WithEvents tubeno_tn5 As System.Web.UI.WebControls.TextBox
    Protected WithEvents tubeno_tn6 As System.Web.UI.WebControls.TextBox
    Protected WithEvents tubeno_tn7 As System.Web.UI.WebControls.TextBox
    Protected WithEvents tubeno_tn8 As System.Web.UI.WebControls.TextBox
    Protected WithEvents tubeno_tn9 As System.Web.UI.WebControls.TextBox
    Protected WithEvents tubeno_tn10 As System.Web.UI.WebControls.TextBox
    Protected WithEvents vaccume_txt1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents vaccume_txt2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents vaccume_txt3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents vaccume_txt4 As System.Web.UI.WebControls.TextBox
    Protected WithEvents vaccume_txt5 As System.Web.UI.WebControls.TextBox
    Protected WithEvents vaccume_txt6 As System.Web.UI.WebControls.TextBox
    Protected WithEvents vaccume_txt7 As System.Web.UI.WebControls.TextBox
    Protected WithEvents vaccume_txt8 As System.Web.UI.WebControls.TextBox
    Protected WithEvents vaccume_txt9 As System.Web.UI.WebControls.TextBox
    Protected WithEvents vaccume_txt10 As System.Web.UI.WebControls.TextBox
    Protected WithEvents time_txt1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents time_txt2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents time_txt3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents time_txt4 As System.Web.UI.WebControls.TextBox
    Protected WithEvents time_txt5 As System.Web.UI.WebControls.TextBox
    Protected WithEvents time_txt6 As System.Web.UI.WebControls.TextBox
    Protected WithEvents time_txt7 As System.Web.UI.WebControls.TextBox
    Protected WithEvents time_txt8 As System.Web.UI.WebControls.TextBox
    Protected WithEvents time_txt9 As System.Web.UI.WebControls.TextBox
    Protected WithEvents time_txt10 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txt_glaze As System.Web.UI.WebControls.TextBox
    Protected WithEvents Txt_Baume As System.Web.UI.WebControls.TextBox
    Protected WithEvents txt_remark As System.Web.UI.WebControls.TextBox
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button
    Protected WithEvents lbl_msg As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents dg_show As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dg_show2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dg_show3 As System.Web.UI.WebControls.DataGrid

    Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
    'Private con As New SqlConnection(ConfigurationManager.AppSettings("con"))
    Dim i As Integer
    Dim strsql As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Page.IsPostBack = False Then
            getDateShift()
            Try

                SetScreen()
            Catch exp As Exception
                Label4.Text = exp.Message
            End Try
        End If

    End Sub
    Private Sub SetScreen()
        Panel1.Visible = True
        Panel7.Visible = True
        dg_show.DataSource = Nothing
        dg_show.DataBind()
        dg_show2.DataSource = Nothing
        dg_show2.DataBind()
        dg_show3.DataSource = Nothing
        dg_show3.DataBind()

    End Sub
    Public Sub getDateShift()
        If Now.Hour = 0 OrElse Now.Hour = 1 OrElse Now.Hour = 2 OrElse Now.Hour = 3 OrElse Now.Hour = 4 OrElse Now.Hour = 5 Then
            date_txt.Text = CDate(Now.Date.AddDays(-1))
        Else
            date_txt.Text = CDate(Now.Date)
        End If
        Dim dt As Date
        Dim Shift As String
        dt = Now
        Select Case dt.Hour
            Case 6 To 13
                Shift = "A"
            Case 14 To 21
                Shift = "B"
            Case 9 To 17
                Shift = "G"
            Case Else
                Shift = "C"
        End Select
        Dim i As Integer = 0
        shift_dd1.ClearSelection()
        For i = 0 To shift_dd1.Items.Count - 1
            If shift_dd1.Items(i).Text = Shift Then
                shift_dd1.Items(i).Selected = True
                Exit For
            End If
        Next
        dt = Nothing
        Shift = Nothing
        i = Nothing
    End Sub



    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim done, done1, done2, done3 As Boolean
        Dim n As Integer = checks()
        If n > 0 Then
            done1 = update1()
            done2 = update2()
            done3 = update3()
        Else
            done = fun()
        End If
        If done Then
            lbl_msg.Text = " Record Saved !"
        ElseIf done1 Or done2 Or done3 Then
            lbl_msg.Text = "Updated sucessfully"
        End If

        shift_dd1_SelectedIndexChanged(sender, e)
    End Sub

    Public Function fun()
        Dim done As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.CommandText = "Insert INTO mm_pouring_tube_preparation(date,shift,sse,op1,op2,op3,super_3000in_kg,no_of_hc_pressing,no_of_p_tube,tubehieght_in_inch,tubecentering_tn1,tubecentering_tn2,tubecentering_tn3,tubecentering_tn4,tubecentering_tn5,tubecentering_tn6,tubecentering_tn7,tubecentering_tn8,tubecentering_tn9,tubecentering_tn10,parting_tn1,parting_tn2,parting_tn3,parting_tn4,parting_tn5,parting_tn6,parting_tn7,parting_tn8,parting_tn9,parting_tn10,glindingtubeno_tn1,glindingtubeno_tn2,glindingtubeno_tn3,glindingtubeno_tn4,glindingtubeno_tn5,glindingtubeno_tn6,glindingtubeno_tn7,glindingtubeno_tn8,glindingtubeno_tn9,glindingtubeno_tn10,glindingvaccume_tn1,glindingvaccume_tn2,glindingvaccume_tn3,glindingvaccume_tn4,glindingvaccume_tn5,glindingvaccume_tn6,glindingvaccume_tn7,glindingvaccume_tn8,glindingvaccume_tn9,glindingvaccume_tn10,glindingtime_tn1,glindingtime_tn2,glindingtime_tn3,glindingtime_tn4,glindingtime_tn5,glindingtime_tn6,glindingtime_tn7,glindingtime_tn8,glindingtime_tn9,glindingtime_tn10,glazed_kg,baume,remarks) 
    VALUES ('" & Format(CDate(date_txt.Text), "MM/dd/yyyy") & "',@ans,'" & sse_txt.Text & "','" & op1_txt.Text & "','" & op2_txt.Text & "','" & op3_txt.Text & "','" & super_txt.Text & "','" & pressing_txt.Text & "','" & measuring_txt.Text & "','" & height_txt.Text & "','" & Tube_centeringtn1.Text & "','" & Tube_centeringtn2.Text & "','" & Tube_centeringtn3.Text & "','" & Tube_centeringtn4.Text & "','" & Tube_centeringtn5.Text & "','" & Tube_centeringtn6.Text & "','" & Tube_centeringtn7.Text & "','" & Tube_centeringtn8.Text & "','" & Tube_centeringtn9.Text & "','" & Tube_centeringtn10.Text & "','" & parting_tn1.Text & "','" & parting_tn2.Text & "','" & parting_tn3.Text & "','" & parting_tn4.Text & "','" & parting_tn5.Text & "','" & parting_tn6.Text & "','" & parting_tn7.Text & "','" & parting_tn8.Text & "','" & parting_tn9.Text & "','" & parting_tn10.Text & "','" & tubeno_tn1.Text & "','" & tubeno_tn2.Text & "','" & tubeno_tn3.Text & "','" & tubeno_tn4.Text & "','" & tubeno_tn5.Text & "','" & tubeno_tn6.Text & "','" & tubeno_tn7.Text & "','" & tubeno_tn8.Text & "','" & tubeno_tn9.Text & "','" & tubeno_tn10.Text & "','" & vaccume_txt1.Text & "','" & vaccume_txt2.Text & "','" & vaccume_txt3.Text & "','" & vaccume_txt4.Text & "','" & vaccume_txt5.Text & "','" & vaccume_txt6.Text & "','" & vaccume_txt7.Text & "','" & vaccume_txt8.Text & "','" & vaccume_txt9.Text & "','" & vaccume_txt10.Text & "','" & time_txt1.Text & "','" & time_txt2.Text & "','" & time_txt3.Text & "','" & time_txt4.Text & "','" & time_txt5.Text & "','" & time_txt6.Text & "','" & time_txt7.Text & "','" & time_txt8.Text & "','" & time_txt9.Text & "','" & time_txt10.Text & "','" & txt_glaze.Text & "','" & Txt_Baume.Text & "','" & txt_remark.Text & "')"
        cmd.Parameters.AddWithValue("ans", shift_dd1.SelectedItem.Text)
        Try
            cmd.Connection.Open()
            If cmd.ExecuteNonQuery() = 1 Then
                done = True
            End If
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            cmd.Connection.Close()
        End Try
        Return done
    End Function

    Public Function checks()

        Dim txt_date As Date = CDate(date_txt.Text)
        Dim txt_shift As String = shift_dd1.SelectedItem.Text
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.Connection.Open()
        cmd.CommandText = ("SELECT COUNT(*) FROM mm_pouring_tube_preparation where date=@date and shift=@shift ")

        cmd.Parameters.AddWithValue("@date", txt_date)
        cmd.Parameters.AddWithValue("@shift", txt_shift)
        Try
            Dim i As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            'cmd = Nothing
            'con.Close()
            Return i
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally

            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing

        End Try
    End Function


    Public Function update1()
        Dim done As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        'Dim con As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User ID=sa;Password=sadev123")
        'con.Open()
        Dim txt_date As Date = CDate(date_txt.Text)
        Dim txt_shift As String = shift_dd1.SelectedValue

        Dim txt_sse As String = sse_txt.Text
        Dim txt_op1 As String = op1_txt.Text
        Dim txt_op2 As String = op2_txt.Text
        Dim txt_op3 As String = op3_txt.Text
        Dim txt_super As String = super_txt.Text
        Dim txt_hc_pressing As String = pressing_txt.Text
        Dim txt_measure As String = measuring_txt.Text
        Dim txt_height As String = height_txt.Text


        Dim txxt_glaze As String = txt_glaze.Text
        Dim txxt_Baume As String = Txt_Baume.Text
        Dim txxt_remark As String = txt_remark.Text

        cmd.CommandText = ("update mm_pouring_tube_preparation set sse=@txt_sse,op1=@txt_op1,op2=@txt_op2,op3=@txt_op3,super_3000in_kg=@txt_super,no_of_hc_pressing=@txt_hc_pressing,no_of_p_tube=@txt_measure,tubehieght_in_inch=@txt_height,
glazed_kg=@txxt_glaze, baume=@txxt_Baume,remarks=@txxt_remark
where date=@txt_date and shift=@txt_shift")

        cmd.Parameters.AddWithValue("@txt_date", txt_date)
        cmd.Parameters.AddWithValue("@txt_shift", shift_dd1.SelectedValue)
        cmd.Parameters.AddWithValue("@txt_sse", txt_sse)
        cmd.Parameters.AddWithValue("@txt_op1", txt_op1)
        cmd.Parameters.AddWithValue("@txt_op2", txt_op2)
        cmd.Parameters.AddWithValue("@txt_op3", txt_op3)
        cmd.Parameters.AddWithValue("@txt_super", txt_super)
        cmd.Parameters.AddWithValue("@txt_hc_pressing", txt_hc_pressing)
        cmd.Parameters.AddWithValue("@txt_measure", txt_measure)
        cmd.Parameters.AddWithValue("@txt_height", txt_height)
        cmd.Parameters.AddWithValue("@txxt_glaze", txxt_glaze)
        cmd.Parameters.AddWithValue("@txxt_Baume", txxt_Baume)
        cmd.Parameters.AddWithValue("@txxt_remark", txxt_remark)

        'If cmd.ExecuteNonQuery() = 1 Then done = True
        'con.Close()
        Try
            cmd.Connection.Open()
            If cmd.ExecuteNonQuery() = 1 Then done = True

        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
        End Try
        Return done

    End Function

    Public Function update2()
        Dim donnne As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        'Dim con As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User ID=sa;Password=sadev123")
        'con.Open()
        Dim txt_date As Date = CDate(date_txt.Text)
        Dim txt_shift As String = shift_dd1.SelectedValue

        Dim txt_cent1 As String = Tube_centeringtn1.Text
        Dim txt_cent2 As String = Tube_centeringtn2.Text
        Dim txt_cent3 As String = Tube_centeringtn3.Text
        Dim txt_cent4 As String = Tube_centeringtn4.Text
        Dim txt_cent5 As String = Tube_centeringtn5.Text
        Dim txt_cent6 As String = Tube_centeringtn6.Text
        Dim txt_cent7 As String = Tube_centeringtn7.Text
        Dim txt_cent8 As String = Tube_centeringtn8.Text
        Dim txt_cent9 As String = Tube_centeringtn9.Text
        Dim txt_cent10 As String = Tube_centeringtn10.Text
        Dim txt_part1 As String = parting_tn1.Text
        Dim txt_part2 As String = parting_tn2.Text
        Dim txt_part3 As String = parting_tn3.Text
        Dim txt_part4 As String = parting_tn4.Text
        Dim txt_part5 As String = parting_tn5.Text
        Dim txt_part6 As String = parting_tn6.Text
        Dim txt_part7 As String = parting_tn7.Text
        Dim txt_part8 As String = parting_tn8.Text
        Dim txt_part9 As String = parting_tn9.Text
        Dim txt_part10 As String = parting_tn10.Text

        cmd.CommandText = ("update mm_pouring_tube_preparation set 
tubecentering_tn1=@txt_cent1,tubecentering_tn2=@txt_cent2,tubecentering_tn3=@txt_cent3,tubecentering_tn4=@txt_cent4,tubecentering_tn5=@txt_cent5,tubecentering_tn6=@txt_cent6,tubecentering_tn7=@txt_cent7,tubecentering_tn8=@txt_cent8,tubecentering_tn9=@txt_cent9,tubecentering_tn10=@txt_cent10,
parting_tn1=@txt_part1,parting_tn2=@txt_part2,parting_tn3=@txt_part3,parting_tn4=@txt_part4,parting_tn5=@txt_part5,parting_tn6=@txt_part6,parting_tn7=@txt_part7,parting_tn8=@txt_part8,parting_tn9=@txt_part9,parting_tn10=@txt_part10
where date=@txt_date and shift=@txt_shift")
        cmd.Parameters.AddWithValue("@txt_date", txt_date)
        cmd.Parameters.AddWithValue("@txt_shift", shift_dd1.SelectedValue)
        cmd.Parameters.AddWithValue("@txt_cent1", txt_cent1)
        cmd.Parameters.AddWithValue("@txt_cent2", txt_cent2)
        cmd.Parameters.AddWithValue("@txt_cent3", txt_cent3)
        cmd.Parameters.AddWithValue("@txt_cent4", txt_cent4)
        cmd.Parameters.AddWithValue("@txt_cent5", txt_cent5)
        cmd.Parameters.AddWithValue("@txt_cent6", txt_cent6)
        cmd.Parameters.AddWithValue("@txt_cent7", txt_cent7)
        cmd.Parameters.AddWithValue("@txt_cent8", txt_cent8)
        cmd.Parameters.AddWithValue("@txt_cent9", txt_cent9)
        cmd.Parameters.AddWithValue("@txt_cent10", txt_cent10)
        cmd.Parameters.AddWithValue("@txt_part1", txt_part1)
        cmd.Parameters.AddWithValue("@txt_part2", txt_part2)
        cmd.Parameters.AddWithValue("@txt_part3", txt_part3)
        cmd.Parameters.AddWithValue("@txt_part4", txt_part4)
        cmd.Parameters.AddWithValue("@txt_part5", txt_part5)
        cmd.Parameters.AddWithValue("@txt_part6", txt_part6)
        cmd.Parameters.AddWithValue("@txt_part7", txt_part7)
        cmd.Parameters.AddWithValue("@txt_part8", txt_part8)
        cmd.Parameters.AddWithValue("@txt_part9", txt_part9)
        cmd.Parameters.AddWithValue("@txt_part10", txt_part10)

        'If cmd.ExecuteNonQuery() = 1 Then donnne = True
        'con.Close()
        Try
            cmd.Connection.Open()
            If cmd.ExecuteNonQuery() = 1 Then donnne = True

        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
        End Try
        Return donnne
    End Function
    Public Function update3()
        Dim donne As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj

        Dim txt_date As Date = CDate(date_txt.Text)
        Dim txt_shift As String = shift_dd1.SelectedValue

        Dim txt_tube1 As String = tubeno_tn1.Text
        Dim txt_tube2 As String = tubeno_tn2.Text
        Dim txt_tube3 As String = tubeno_tn3.Text
        Dim txt_tube4 As String = tubeno_tn4.Text
        Dim txt_tube5 As String = tubeno_tn5.Text
        Dim txt_tube6 As String = tubeno_tn6.Text
        Dim txt_tube7 As String = tubeno_tn7.Text
        Dim txt_tube8 As String = tubeno_tn8.Text
        Dim txt_tube9 As String = tubeno_tn9.Text
        Dim txt_tube10 As String = tubeno_tn10.Text
        Dim txt_vac1 As String = vaccume_txt1.Text
        Dim txt_vac2 As String = vaccume_txt2.Text
        Dim txt_vac3 As String = vaccume_txt3.Text
        Dim txt_vac4 As String = vaccume_txt4.Text
        Dim txt_vac5 As String = vaccume_txt5.Text
        Dim txt_vac6 As String = vaccume_txt6.Text
        Dim txt_vac7 As String = vaccume_txt7.Text
        Dim txt_vac8 As String = vaccume_txt8.Text
        Dim txt_vac9 As String = vaccume_txt9.Text
        Dim txt_vac10 As String = vaccume_txt10.Text
        Dim txt_time1 As String = time_txt1.Text
        Dim txt_time2 As String = time_txt2.Text
        Dim txt_time3 As String = time_txt3.Text
        Dim txt_time4 As String = time_txt4.Text
        Dim txt_time5 As String = time_txt5.Text
        Dim txt_time6 As String = time_txt6.Text
        Dim txt_time7 As String = time_txt7.Text
        Dim txt_time8 As String = time_txt8.Text
        Dim txt_time9 As String = time_txt9.Text
        Dim txt_time10 As String = time_txt10.Text

        cmd.CommandText = ("update mm_pouring_tube_preparation set 
glindingtubeno_tn1=@txt_tube1,glindingtubeno_tn2=@txt_tube2,glindingtubeno_tn3=@txt_tube3,glindingtubeno_tn4=@txt_tube4,glindingtubeno_tn5=@txt_tube5,glindingtubeno_tn6=@txt_tube6,glindingtubeno_tn7=@txt_tube7,glindingtubeno_tn8=@txt_tube8,glindingtubeno_tn9=@txt_tube9,glindingtubeno_tn10=@txt_tube10,
glindingvaccume_tn1=@txt_vac1,glindingvaccume_tn2=@txt_vac2,glindingvaccume_tn3=@txt_vac3,glindingvaccume_tn4=@txt_vac4,glindingvaccume_tn6=@txt_vac6,glindingvaccume_tn7=@txt_vac7,glindingvaccume_tn8=@txt_vac8,glindingvaccume_tn9=@txt_vac9,glindingvaccume_tn10=@txt_vac10,
glindingtime_tn1=@txt_time1,glindingtime_tn2=@txt_time2,glindingtime_tn3=@txt_time3,glindingtime_tn4=@txt_time4,glindingtime_tn5=@txt_time5,glindingtime_tn6=@txt_time6,glindingtime_tn7=@txt_time7,glindingtime_tn8=@txt_time8,glindingtime_tn9=@txt_time9,glindingtime_tn10=@txt_time10
where date=@txt_date and shift=@txt_shift")

        cmd.Parameters.AddWithValue("@txt_date", txt_date)
        cmd.Parameters.AddWithValue("@txt_shift", shift_dd1.SelectedValue)
        cmd.Parameters.AddWithValue("@txt_tube1", txt_tube1)
        cmd.Parameters.AddWithValue("@txt_tube2", txt_tube2)
        cmd.Parameters.AddWithValue("@txt_tube3", txt_tube3)
        cmd.Parameters.AddWithValue("@txt_tube4", txt_tube4)
        cmd.Parameters.AddWithValue("@txt_tube5", txt_tube5)
        cmd.Parameters.AddWithValue("@txt_tube6", txt_tube6)
        cmd.Parameters.AddWithValue("@txt_tube7", txt_tube7)
        cmd.Parameters.AddWithValue("@txt_tube8", txt_tube8)
        cmd.Parameters.AddWithValue("@txt_tube9", txt_tube9)
        cmd.Parameters.AddWithValue("@txt_tube10", txt_tube10)
        cmd.Parameters.AddWithValue("@txt_vac1", txt_vac1)
        cmd.Parameters.AddWithValue("@txt_vac2", txt_vac2)
        cmd.Parameters.AddWithValue("@txt_vac3", txt_vac3)
        cmd.Parameters.AddWithValue("@txt_vac4", txt_vac4)
        cmd.Parameters.AddWithValue("@txt_vac5", txt_vac5)
        cmd.Parameters.AddWithValue("@txt_vac6", txt_vac6)
        cmd.Parameters.AddWithValue("@txt_vac7", txt_vac7)
        cmd.Parameters.AddWithValue("@txt_vac8", txt_vac8)
        cmd.Parameters.AddWithValue("@txt_vac9", txt_vac9)
        cmd.Parameters.AddWithValue("@txt_vac10", txt_vac10)
        cmd.Parameters.AddWithValue("@txt_time1", txt_time1)
        cmd.Parameters.AddWithValue("@txt_time2", txt_time2)
        cmd.Parameters.AddWithValue("@txt_time3", txt_time3)
        cmd.Parameters.AddWithValue("@txt_time4", txt_time4)
        cmd.Parameters.AddWithValue("@txt_time5", txt_time5)
        cmd.Parameters.AddWithValue("@txt_time6", txt_time6)
        cmd.Parameters.AddWithValue("@txt_time7", txt_time7)
        cmd.Parameters.AddWithValue("@txt_time8", txt_time8)
        cmd.Parameters.AddWithValue("@txt_time9", txt_time9)
        cmd.Parameters.AddWithValue("@txt_time10", txt_time10)

        'If cmd.ExecuteNonQuery() = 1 Then donne = True
        'con.Close()
        Try
            cmd.Connection.Open()
            If cmd.ExecuteNonQuery() = 1 Then donne = True

        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
        End Try
        Return donne
    End Function

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        sse_txt.Text = ""
        op1_txt.Text = ""
        op2_txt.Text = ""
        op3_txt.Text = ""
        super_txt.Text = ""
        pressing_txt.Text = ""
        height_txt.Text = ""
        measuring_txt.Text = ""
        Tube_centeringtn1.Text = ""
        Tube_centeringtn2.Text = ""
        Tube_centeringtn3.Text = ""
        Tube_centeringtn4.Text = ""
        Tube_centeringtn5.Text = ""
        Tube_centeringtn6.Text = ""
        Tube_centeringtn7.Text = ""
        Tube_centeringtn8.Text = ""
        Tube_centeringtn9.Text = ""
        Tube_centeringtn10.Text = ""
        parting_tn1.Text = ""
        parting_tn2.Text = ""
        parting_tn3.Text = ""
        parting_tn4.Text = ""
        parting_tn5.Text = ""
        parting_tn6.Text = ""
        parting_tn7.Text = ""
        parting_tn8.Text = ""
        parting_tn9.Text = ""
        parting_tn10.Text = ""
        tubeno_tn1.Text = ""
        tubeno_tn2.Text = ""
        tubeno_tn3.Text = ""
        tubeno_tn4.Text = ""
        tubeno_tn5.Text = ""
        tubeno_tn6.Text = ""
        tubeno_tn7.Text = ""
        tubeno_tn8.Text = ""
        tubeno_tn9.Text = ""
        tubeno_tn10.Text = ""
        vaccume_txt1.Text = ""
        vaccume_txt2.Text = ""
        vaccume_txt3.Text = ""
        vaccume_txt4.Text = ""
        vaccume_txt5.Text = ""
        vaccume_txt6.Text = ""
        vaccume_txt7.Text = ""
        vaccume_txt8.Text = ""
        vaccume_txt9.Text = ""
        vaccume_txt10.Text = ""
        time_txt1.Text = ""
        time_txt2.Text = ""
        time_txt3.Text = ""
        time_txt4.Text = ""
        time_txt5.Text = ""
        time_txt6.Text = ""
        time_txt7.Text = ""
        time_txt8.Text = ""
        time_txt9.Text = ""
        time_txt10.Text = ""
        txt_glaze.Text = ""
        Txt_Baume.Text = ""
        txt_remark.Text = ""
        lbl_msg.Text = ""

        Label4.Text = ""

    End Sub
    Private Sub BindDataGrid(ByVal strArg As String)
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Dim strsql As String
        Try
            cmd.Connection.Open()
            cmd = New SqlCommand(strArg, cmd.Connection)
            Dim objDr As SqlDataReader = cmd.ExecuteReader()
            Dim arr() As String
            dg_show.DataSource = arr
            dg_show.DataBind()
            dg_show.DataSource = objDr
            dg_show.DataBind()
        Catch exp As SqlException
            strsql = exp.StackTrace
            Label4.Text = "Line : " & Mid(strsql, InStr(strsql, "line") + 5) & " Message : " + exp.Message

        Catch exp As Exception
            strsql = exp.StackTrace
            Label4.Text = "Line : " & Mid(strsql, InStr(strsql, "line") + 5) & " Message : " + exp.Message

        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
        End Try
    End Sub

    Private Sub BindDataGrid1(ByVal strArg As String)
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Dim strsql As String
        Try
            cmd.Connection.Open()
            cmd = New SqlCommand(strArg, cmd.Connection)
            Dim objDr1 As SqlDataReader = cmd.ExecuteReader()
            Dim arr1() As String
            dg_show2.DataSource = arr1
            dg_show2.DataBind()
            dg_show2.DataSource = objDr1
            dg_show2.DataBind()

        Catch exp As SqlException
            strsql = exp.StackTrace
            Label4.Text = "Line : " & Mid(strsql, InStr(strsql, "line") + 5) & " Message : " + exp.Message

        Catch exp As Exception
            strsql = exp.StackTrace
            Label4.Text = "Line : " & Mid(strsql, InStr(strsql, "line") + 5) & " Message : " + exp.Message

        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
        End Try
    End Sub

    Private Sub BindDataGrid2(ByVal strArg As String)
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Dim strsql As String
        Try
            cmd.Connection.Open()
            cmd = New SqlCommand(strArg, cmd.Connection)
            Dim objDr2 As SqlDataReader = cmd.ExecuteReader()
            Dim arr2() As String
            dg_show3.DataSource = arr2
            dg_show3.DataBind()
            dg_show3.DataSource = objDr2
            dg_show3.DataBind()

        Catch exp As SqlException
            strsql = exp.StackTrace
            Label4.Text = "Line : " & Mid(strsql, InStr(strsql, "line") + 5) & " Message : " + exp.Message

        Catch exp As Exception
            strsql = exp.StackTrace
            Label4.Text = "Line : " & Mid(strsql, InStr(strsql, "line") + 5) & " Message : " + exp.Message

        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
        End Try

    End Sub

    Protected Sub shift_dd1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles shift_dd1.SelectedIndexChanged
        Dim sqlstr3 As String
        sqlstr3 = "select date,shift,sse,op1,op2,op3,super_3000in_kg,no_of_hc_pressing,no_of_p_tube,tubehieght_in_inch,tubecentering_tn1,tubecentering_tn2,tubecentering_tn3,tubecentering_tn4,tubecentering_tn5,tubecentering_tn6,tubecentering_tn7,tubecentering_tn8,tubecentering_tn9,tubecentering_tn10,parting_tn1,parting_tn2,parting_tn3,parting_tn4,parting_tn5,parting_tn6,parting_tn7,parting_tn8,parting_tn9,parting_tn10,glindingtubeno_tn1,glindingtubeno_tn2,glindingtubeno_tn3,glindingtubeno_tn4,glindingtubeno_tn5,glindingtubeno_tn6,glindingtubeno_tn7,glindingtubeno_tn8,glindingtubeno_tn9,glindingtubeno_tn10,glindingvaccume_tn1,glindingvaccume_tn2,glindingvaccume_tn3,glindingvaccume_tn4,glindingvaccume_tn5,glindingvaccume_tn6,glindingvaccume_tn7,glindingvaccume_tn8,glindingvaccume_tn9,glindingvaccume_tn10,glindingtime_tn1,glindingtime_tn2,glindingtime_tn3,glindingtime_tn4,glindingtime_tn5,glindingtime_tn6,glindingtime_tn7,glindingtime_tn8,glindingtime_tn9,glindingtime_tn10,glazed_kg,baume,remarks from mm_pouring_tube_preparation where date='" & Format(CDate(date_txt.Text), "MM/dd/yyyy") & "'  and shift='" & shift_dd1.SelectedItem.Text & "'"
        Call BindDataGrid(sqlstr3)
        Call BindDataGrid1(sqlstr3)
        Call BindDataGrid2(sqlstr3)
    End Sub

    Protected Sub dg_show_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dg_show.SelectedIndexChanged
        dg_show.SelectedIndex = i
        sse_txt.Text = Trim(dg_show.Items(i).Cells(3).Text)
        op1_txt.Text = Trim(dg_show.Items(i).Cells(4).Text)
        op2_txt.Text = Trim(dg_show.Items(i).Cells(5).Text)
        op3_txt.Text = Trim(dg_show.Items(i).Cells(6).Text)
        super_txt.Text = Trim(dg_show.Items(i).Cells(7).Text)
        pressing_txt.Text = Trim(dg_show.Items(i).Cells(8).Text)
        height_txt.Text = Trim(dg_show.Items(i).Cells(9).Text)
        measuring_txt.Text = Trim(dg_show.Items(i).Cells(10).Text)
        txt_glaze.Text = Trim(dg_show.Items(i).Cells(11).Text)
        Txt_Baume.Text = Trim(dg_show.Items(i).Cells(12).Text)
        txt_remark.Text = Trim(dg_show.Items(i).Cells(13).Text)
    End Sub

    Private Sub dg_show_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dg_show.ItemCommand
        i = e.Item.ItemIndex()
    End Sub

    Protected Sub dg_show2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dg_show2.SelectedIndexChanged
        dg_show2.SelectedIndex = i
        Tube_centeringtn1.Text = Trim(dg_show2.Items(i).Cells(1).Text)
        Tube_centeringtn2.Text = Trim(dg_show2.Items(i).Cells(2).Text)
        Tube_centeringtn3.Text = Trim(dg_show2.Items(i).Cells(3).Text)
        Tube_centeringtn4.Text = Trim(dg_show2.Items(i).Cells(4).Text)
        Tube_centeringtn5.Text = Trim(dg_show2.Items(i).Cells(5).Text)
        Tube_centeringtn6.Text = Trim(dg_show2.Items(i).Cells(6).Text)
        Tube_centeringtn7.Text = Trim(dg_show2.Items(i).Cells(7).Text)
        Tube_centeringtn8.Text = Trim(dg_show2.Items(i).Cells(8).Text)
        Tube_centeringtn9.Text = Trim(dg_show2.Items(i).Cells(9).Text)
        Tube_centeringtn10.Text = Trim(dg_show2.Items(i).Cells(10).Text)
        parting_tn1.Text = Trim(dg_show2.Items(i).Cells(11).Text)
        parting_tn2.Text = Trim(dg_show2.Items(i).Cells(12).Text)
        parting_tn3.Text = Trim(dg_show2.Items(i).Cells(13).Text)
        parting_tn4.Text = Trim(dg_show2.Items(i).Cells(14).Text)
        parting_tn5.Text = Trim(dg_show2.Items(i).Cells(15).Text)
        parting_tn6.Text = Trim(dg_show2.Items(i).Cells(16).Text)
        parting_tn7.Text = Trim(dg_show2.Items(i).Cells(17).Text)
        parting_tn8.Text = Trim(dg_show2.Items(i).Cells(18).Text)
        parting_tn9.Text = Trim(dg_show2.Items(i).Cells(19).Text)
        parting_tn10.Text = Trim(dg_show2.Items(i).Cells(20).Text)
    End Sub

    Private Sub dg_show2_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dg_show2.ItemCommand
        i = e.Item.ItemIndex()
    End Sub

    Protected Sub dg_show3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dg_show3.SelectedIndexChanged
        dg_show3.SelectedIndex = i
        tubeno_tn1.Text = Trim(dg_show3.Items(i).Cells(1).Text)
        tubeno_tn2.Text = Trim(dg_show3.Items(i).Cells(2).Text)
        tubeno_tn3.Text = Trim(dg_show3.Items(i).Cells(3).Text)
        tubeno_tn4.Text = Trim(dg_show3.Items(i).Cells(4).Text)
        tubeno_tn5.Text = Trim(dg_show3.Items(i).Cells(5).Text)
        tubeno_tn6.Text = Trim(dg_show3.Items(i).Cells(6).Text)
        tubeno_tn7.Text = Trim(dg_show3.Items(i).Cells(7).Text)
        tubeno_tn8.Text = Trim(dg_show3.Items(i).Cells(8).Text)
        tubeno_tn9.Text = Trim(dg_show3.Items(i).Cells(9).Text)
        tubeno_tn10.Text = Trim(dg_show3.Items(i).Cells(10).Text)
        vaccume_txt1.Text = Trim(dg_show3.Items(i).Cells(11).Text)
        vaccume_txt2.Text = Trim(dg_show3.Items(i).Cells(12).Text)
        vaccume_txt3.Text = Trim(dg_show3.Items(i).Cells(13).Text)
        vaccume_txt4.Text = Trim(dg_show3.Items(i).Cells(14).Text)
        vaccume_txt5.Text = Trim(dg_show3.Items(i).Cells(15).Text)
        vaccume_txt6.Text = Trim(dg_show3.Items(i).Cells(16).Text)
        vaccume_txt7.Text = Trim(dg_show3.Items(i).Cells(17).Text)
        vaccume_txt8.Text = Trim(dg_show3.Items(i).Cells(18).Text)
        vaccume_txt9.Text = Trim(dg_show3.Items(i).Cells(19).Text)
        vaccume_txt10.Text = Trim(dg_show3.Items(i).Cells(20).Text)
        time_txt1.Text = Trim(dg_show3.Items(i).Cells(21).Text)
        time_txt2.Text = Trim(dg_show3.Items(i).Cells(22).Text)
        time_txt3.Text = Trim(dg_show3.Items(i).Cells(23).Text)
        time_txt4.Text = Trim(dg_show3.Items(i).Cells(24).Text)
        time_txt5.Text = Trim(dg_show3.Items(i).Cells(25).Text)
        time_txt6.Text = Trim(dg_show3.Items(i).Cells(26).Text)
        time_txt7.Text = Trim(dg_show3.Items(i).Cells(27).Text)
        time_txt8.Text = Trim(dg_show3.Items(i).Cells(28).Text)
        time_txt9.Text = Trim(dg_show3.Items(i).Cells(29).Text)
        time_txt10.Text = Trim(dg_show3.Items(i).Cells(30).Text)
    End Sub

    Private Sub dg_show3_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dg_show3.ItemCommand
        i = e.Item.ItemIndex()
    End Sub

End Class