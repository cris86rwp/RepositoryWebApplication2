Imports System.Data
Imports System.Data.SqlClient

Public Class SandPreparationNew

    Inherits System.Web.UI.Page

    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents sanddate As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblshift As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents sse_jename As System.Web.UI.WebControls.TextBox
    Protected WithEvents operator1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents tboperator2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents chk_recipe As System.Web.UI.WebControls.CheckBox
    Protected WithEvents bumker1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents bumker2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents bumker3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents silo As System.Web.UI.WebControls.TextBox
    Protected WithEvents strttime As System.Web.UI.WebControls.TextBox
    Protected WithEvents stptime As System.Web.UI.WebControls.TextBox
    Protected WithEvents tbhexa As System.Web.UI.WebControls.TextBox
    Protected WithEvents btchcoated As System.Web.UI.WebControls.TextBox
    Protected WithEvents resin As System.Web.UI.WebControls.TextBox
    Protected WithEvents make As System.Web.UI.WebControls.TextBox
    Protected WithEvents sandmnth As System.Web.UI.WebControls.TextBox
    Protected WithEvents remarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents lbldate As System.Web.UI.WebControls.Label
    Protected WithEvents lblshift As System.Web.UI.WebControls.Label
    Protected WithEvents lbl_sseje As System.Web.UI.WebControls.Label
    Protected WithEvents lbl_operator1 As System.Web.UI.WebControls.Label
    Protected WithEvents lbl_operator2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblrecipe As System.Web.UI.WebControls.Label
    Protected WithEvents lblbumker1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblbumker2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblbumker3 As System.Web.UI.WebControls.Label
    Protected WithEvents lblsilo As System.Web.UI.WebControls.Label
    Protected WithEvents lbldrier As System.Web.UI.WebControls.Label
    Protected WithEvents lblhexa As System.Web.UI.WebControls.Label
    Protected WithEvents lblmsg As System.Web.UI.WebControls.Label
    Protected WithEvents lblstrttime As System.Web.UI.WebControls.Label
    Protected WithEvents lblstptime As System.Web.UI.WebControls.Label
    Protected WithEvents lblhxlprep As System.Web.UI.WebControls.Label
    Protected WithEvents rblhxlprep As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents lblbtchcoated As System.Web.UI.WebControls.Label
    Protected WithEvents lblresin As System.Web.UI.WebControls.Label
    Protected WithEvents lblmake As System.Web.UI.WebControls.Label
    Protected WithEvents lblbatch As System.Web.UI.WebControls.Label
    'Protected WithEvents lbl_batch As System.Web.UI.WebControls.Label
    Protected WithEvents lblsandmnth As System.Web.UI.WebControls.Label
    Protected WithEvents lblremarks As System.Web.UI.WebControls.Label
    'Protected WithEvents btn_batch As System.Web.UI.WebControls.Button
    Protected WithEvents btnsave As System.Web.UI.WebControls.Button
    Protected WithEvents btnreset As System.Web.UI.WebControls.Button
    ' Protected WithEvents vw_batch As System.Web.UI.WebControls.TextBox
    Protected WithEvents sample_no1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents sample_no2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents sample_no3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents sample_no4 As System.Web.UI.WebControls.TextBox
    Protected WithEvents sample_no5 As System.Web.UI.WebControls.TextBox
    Protected WithEvents sample_no6 As System.Web.UI.WebControls.TextBox
    Protected WithEvents sample_no7 As System.Web.UI.WebControls.TextBox
    Protected WithEvents sample_no8 As System.Web.UI.WebControls.TextBox
    Protected WithEvents sample_no9 As System.Web.UI.WebControls.TextBox
    Protected WithEvents sample_no10 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Vw_batch_no As System.Web.UI.WebControls.DataGrid
    Protected WithEvents vw_sand_details As System.Web.UI.WebControls.DataGrid
    ' Protected WithEvents tb_batch As System.Web.UI.WebControls.TextBox
    Protected WithEvents silo1 As System.Web.UI.WebControls.TextBox

    Protected WithEvents check As System.Web.UI.WebControls.Label

    'Dim con As New SqlConnection
    Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
    Dim cmd1 As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
    Dim dt As Date
    Dim Shift As String
    Dim i As Integer

    Shared themeValue As String

    Public Sub New()

        AddHandler PreInit, New EventHandler(AddressOf Page_PreInit)
    End Sub

    Private Sub Page_PreInit(ByVal sender As Object, ByVal e As EventArgs)

        Page.Theme = themeValue
    End Sub


    Protected Sub Dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'formclear()
        lblmsg.Visible = False
        ' lbl_batch.Visible = False
        If IsPostBack = False Then
            getdateshift()
        End If
        'getdateshift()

    End Sub

    Private Sub getdateshift()
        If Now.Hour = 0 OrElse Now.Hour = 1 OrElse Now.Hour = 2 OrElse Now.Hour = 3 OrElse Now.Hour = 4 OrElse Now.Hour = 5 Then
            sanddate.Text = Now.Date.AddDays(-1)
        Else
            sanddate.Text = Now.Date
        End If

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
        rblshift.ClearSelection()
        For i = 0 To rblshift.Items.Count - 1
            If rblshift.Items(i).Text = Shift Then
                rblshift.Items(i).Selected = True
                Exit For
            End If
        Next
        dt = Nothing
        Shift = Nothing
    End Sub

    Private Sub formclear()
        'sanddate.Text = ""
        sse_jename.Text = ""
        operator1.Text = ""
        tboperator2.Text = ""
        bumker1.Text = ""
        bumker2.Text = ""
        bumker3.Text = ""
        silo1.Text = ""
        strttime.Text = ""
        stptime.Text = ""
        tbhexa.Text = ""
        btchcoated.Text = ""
        resin.Text = ""
        make.Text = ""
        sandmnth.Text = ""
        remarks.Text = ""
        ' vw_batch.Text = ""
        sample_no1.Text = ""
        sample_no2.Text = ""
        sample_no3.Text = ""
        sample_no4.Text = ""
        sample_no5.Text = ""
        sample_no6.Text = ""
        sample_no7.Text = ""
        sample_no8.Text = ""
        sample_no9.Text = ""
        sample_no10.Text = ""

    End Sub



    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click

        Dim done, donne, done1 As Boolean

        If btchcoated.Text <> String.Empty Then

            Dim n As Integer = checks()

            If n > 0 Then
                done = Update()
                done1 = Update1()

            Else
                donne = insert_data()

            End If

            'If done1 And donne Then
            If donne Then
                lblmsg.Text = " record saved !"
            ElseIf done Or done1 Then
                lblmsg.Text = "updated"
            End If
        Else
            lblmsg.Text = "PLEASE ENTER NUMBER OF BATCH COATED!"
        End If
        'rblshift_SelectedIndexChanged(sender, e)
        SetFocus(btchcoated)
    End Sub

    Public Function Update1()
        Dim done1 As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj

        Dim txt_date As DateTime = Format(CDate(sanddate.Text), "dd/MM/yyyy")
        Dim txt_shift As String = rblshift.SelectedItem.Value
        Dim sample1 As String = sample_no1.Text
        Dim sample2 As String = sample_no2.Text
        Dim sample3 As String = sample_no3.Text
        Dim sample4 As String = sample_no4.Text
        Dim sample5 As String = sample_no5.Text
        Dim sample6 As String = sample_no6.Text
        Dim sample7 As String = sample_no7.Text
        Dim sample8 As String = sample_no8.Text
        Dim sample9 As String = sample_no9.Text
        Dim sample10 As String = sample_no10.Text

        cmd.CommandText = ("UPDATE mm_sand_batches set BatchSample1=@sample1,BatchSample2=@sample2,BatchSample3=@sample3,BatchSample4=@sample4,BatchSample5=@sample5,BatchSample6=@sample6,BatchSample7=@sample7,BatchSample8=@sample8,BatchSample9=@sample9,BatchSample10=@sample10 where date=@txt_date and shift=@txt_shift")

        cmd.Parameters.AddWithValue("@txt_date", txt_date)
        cmd.Parameters.AddWithValue("@txt_shift", txt_shift)
        cmd.Parameters.AddWithValue("@sample1", sample1)
        cmd.Parameters.AddWithValue("@sample2", sample2)
        cmd.Parameters.AddWithValue("@sample3", sample3)
        cmd.Parameters.AddWithValue("@sample4", sample4)
        cmd.Parameters.AddWithValue("@sample5", sample5)
        cmd.Parameters.AddWithValue("@sample6", sample6)
        cmd.Parameters.AddWithValue("@sample7", sample7)
        cmd.Parameters.AddWithValue("@sample8", sample8)
        cmd.Parameters.AddWithValue("@sample9", sample9)
        cmd.Parameters.AddWithValue("@sample10", sample10)
        Try
            cmd.Connection.Open()
            If cmd.ExecuteNonQuery() = 1 Then done1 = True

        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
        End Try
        Return done1
    End Function

    Public Function Update()
        Dim done As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj

        Dim txt_date As DateTime = Format(CDate(sanddate.Text), "dd/MM/yyyy")
        Dim txt_shift As String = rblshift.SelectedItem.Value
        Dim bumker_1 As String = bumker1.Text
        Dim bumker_2 As String = bumker2.Text
        Dim bumker_3 As String = bumker3.Text
        Dim silo_1 As String = silo1.Text

        Dim tb_hexa As String = tbhexa.Text
        Dim btch_coated As String = btchcoated.Text
        Dim resin_1 As String = resin.Text
        Dim make_1 As String = make.Text

        cmd.CommandText = ("UPDATE mm_sandPreparation set bumker1=@bumker_1,bumker2=@bumker_2,bumker3=@bumker_3,silo=@silo_1,hexa_resol=@rblhxl_prep,hexa_used=@tb_hexa,batch_coated=@btch_coated,resin_used=@resin_1,make=@make_1 where date=@txt_date and shift=@txt_shift ")

        cmd.Parameters.AddWithValue("@txt_date", txt_date)
        cmd.Parameters.AddWithValue("@txt_shift", txt_shift)
        cmd.Parameters.AddWithValue("@bumker_1", bumker_1)
        cmd.Parameters.AddWithValue("@bumker_2", bumker_2)
        cmd.Parameters.AddWithValue("@bumker_3", bumker_3)
        cmd.Parameters.AddWithValue("@silo_1", silo_1)
        cmd.Parameters.AddWithValue("@rblhxl_prep", rblhxlprep.SelectedValue)
        cmd.Parameters.AddWithValue("@tb_hexa", tb_hexa)
        cmd.Parameters.AddWithValue("@btch_coated", btch_coated)
        cmd.Parameters.AddWithValue("@resin_1", resin_1)
        cmd.Parameters.AddWithValue("@make_1", make_1)
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



    Public Function checks()

        Dim sand_date As Date = Format(CDate(sanddate.Text))
        Dim tx_shift As String = rblshift.SelectedItem.Value


        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.Connection.Open()
        cmd.CommandText = ("SELECT COUNT(*) From mm_sandPreparation where date=@sand_date And shift=@tx_shift ")
        cmd.Parameters.AddWithValue("@sand_date", sand_date)
        cmd.Parameters.AddWithValue("@tx_shift", tx_shift)
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

    Private Sub show_sand()
        Try
            cmd.Connection.Open()
            cmd.CommandText = "select bumker1 Bumker_1 , bumker2 Bumker_2  , bumker3 Bumker_3 , silo Silo_No , CONVERT(VARCHAR(5), start_time, 108) Drier_Strt_Time ,
                                CONVERT(VARCHAR(5), end_time, 108) End_Time, hexa_resol Hexa_Sol_Prep , hexa_used Hexa_Used, batch_coated Coated_Batch, resin_used Resin_Used, sand_quantity Make from mm_sandPreparation where date='" & Format(CDate(sanddate.Text), "MM/dd/yyyy") & "' "
            'and shift='" & rblshift.SelectedValue & "' "
            Using sda As New SqlDataAdapter()
                sda.SelectCommand = cmd
                Using dt As New DataSet()
                    sda.Fill(dt)
                    vw_sand_details.DataSource = dt
                    vw_sand_details.DataBind()
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            cmd.Connection.Close()
        End Try
    End Sub

    Private Sub show_batch()
        Vw_batch_no.DataSource = Nothing
        Vw_batch_no.DataBind()
        Try
            cmd.Connection.Open()
            cmd.CommandText = "Select (LEFT(Date,11)) Date,shift Shift,BatchSample1 Sample1,BatchSample2 Sample2,BatchSample3 Sample3,BatchSample4 Sample4,BatchSample5 Sample5,BatchSample6 Sample6,BatchSample7 Sample7,BatchSample8 Sample8,BatchSample9 Sample9,BatchSample10 Sample10 from mm_sand_batches where date='" & Format(CDate(sanddate.Text), "MM/dd/yyyy") & "' "
            'and shift='" & rblshift.SelectedValue & "'"
            Using sda As New SqlDataAdapter()
                sda.SelectCommand = cmd
                Using dt As New DataSet()
                    sda.Fill(dt)
                    Vw_batch_no.DataSource = dt
                    Vw_batch_no.DataBind()
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            cmd.Connection.Close()
        End Try
        formclear()
    End Sub

    Private Function insert_data()
        Dim donne As Boolean
        Try
            cmd.Connection.Open()
            cmd.CommandText = "INSERT INTO mm_sandPreparation(date,shift,sse_je,operator1,operator2,bumker1,bumker2,bumker3,silo,start_time,end_time,hexa_resol,hexa_used,batch_coated,resin_used,make,sand_quantity,remarks) VALUES ('" & Format(CDate(sanddate.Text), "MM/dd/yyyy") & "',
         '" & rblshift.SelectedValue.ToString() & "','" & sse_jename.Text & "','" & operator1.Text & "','" & tboperator2.Text & "','" & bumker1.Text & "','" & bumker2.Text & "','" & bumker3.Text & "','" & silo1.Text & "','" & Format(CDate(strttime.Text), "HH:mm") & "','" & Format(CDate(stptime.Text), "HH:mm") & "',
            '" & rblhxlprep.SelectedValue.ToString() & "','" & tbhexa.Text & "','" & btchcoated.Text & "','" & resin.Text & "' , '" & make.Text & "' ,'" & sandmnth.Text & "','" & remarks.Text & "')"

            cmd.ExecuteNonQuery()

            cmd1.Connection.Open()
            cmd1.CommandText = "INSERT INTO mm_sand_batches(date,shift,BatchSample1,BatchSample2,BatchSample3,BatchSample4,BatchSample5,BatchSample6,BatchSample7,BatchSample8,BatchSample9,BatchSample10) VALUES ('" & Format(CDate(sanddate.Text), "MM/dd/yyyy") & "','" & rblshift.SelectedValue.ToString() & "','" & sample_no1.Text & "','" & sample_no2.Text & "','" & sample_no3.Text & "','" & sample_no4.Text & "','" & sample_no5.Text & "','" & sample_no6.Text & "','" & sample_no7.Text & "','" & sample_no8.Text & "','" & sample_no9.Text & "','" & sample_no10.Text & "')"
            cmd1.ExecuteNonQuery()

            If cmd.ExecuteNonQuery() = 1 And cmd1.ExecuteNonQuery() = 1 Then donne = True

        Catch ex As Exception
        Finally
            cmd.Connection.Close()
            cmd1.Connection.Close()

        End Try
        Return donne

    End Function

    Protected Sub chk_recipe_CheckedChanged(sender As Object, e As EventArgs) Handles chk_recipe.CheckedChanged
        If chk_recipe.Checked = True Then
            Dim url As String = "sand_recipe_table.aspx"
            Dim s As String = "window.open('" & url + "', 'popup_window', 'width=700,height=800,left=500,top=100,resizable=yes');"
            ClientScript.RegisterStartupScript(Me.GetType(), "script", s, True)
        End If
    End Sub


    Protected Sub rblhxlprep_SelectedIndexChanged(sender As Object, e As EventArgs)
        If rblhxlprep.SelectedValue = 1 Then
            lblhexa.Visible = True
            tbhexa.Visible = True
        Else
            lblhexa.Visible = False
            tbhexa.Visible = False
        End If
    End Sub


    Protected Sub btnreset_Click(sender As Object, e As EventArgs) Handles btnreset.Click
        formclear()
    End Sub


    Protected Sub vw_sand_details_SelectedIndexChanged(sender As Object, e As EventArgs) Handles vw_sand_details.SelectedIndexChanged
        vw_sand_details.SelectedIndex = i

        bumker1.Text = Trim(vw_sand_details.Items(i).Cells(1).Text)
        bumker2.Text = Trim(vw_sand_details.Items(i).Cells(2).Text)

        bumker3.Text = Trim(vw_sand_details.Items(i).Cells(3).Text)

        silo1.Text = Trim(vw_sand_details.Items(i).Cells(4).Text)
        strttime.Text = Trim(vw_sand_details.Items(i).Cells(5).Text)
        stptime.Text = Trim(vw_sand_details.Items(i).Cells(6).Text)

        'rblhxlprep.SelectedItem.Value = Trim(vw_sand_details.Items(i).Cells(7).Text)

        tbhexa.Text = Trim(vw_sand_details.Items(i).Cells(8).Text)
        btchcoated.Text = Trim(vw_sand_details.Items(i).Cells(9).Text)
        resin.Text = Trim(vw_sand_details.Items(i).Cells(10).Text)
        make.Text = Trim(vw_sand_details.Items(i).Cells(11).Text)

    End Sub

    Private Sub vw_sand_details_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles vw_sand_details.ItemCommand

        i = e.Item.ItemIndex()
    End Sub

    Protected Sub Vw_batch_no_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Vw_batch_no.SelectedIndexChanged
        Vw_batch_no.SelectedIndex = i
        'sanddate.Text = Trim(Vw_batch_no.Items(i).Cells(1).Text)
        rblshift.SelectedItem.Value = Trim(Vw_batch_no.Items(i).Cells(2).Text)
        sample_no1.Text = Trim(Vw_batch_no.Items(i).Cells(3).Text)
        sample_no2.Text = Trim(Vw_batch_no.Items(i).Cells(4).Text)
        sample_no3.Text = Trim(Vw_batch_no.Items(i).Cells(5).Text)
        sample_no4.Text = Trim(Vw_batch_no.Items(i).Cells(6).Text)
        sample_no5.Text = Trim(Vw_batch_no.Items(i).Cells(7).Text)
        sample_no6.Text = Trim(Vw_batch_no.Items(i).Cells(8).Text)
        sample_no7.Text = Trim(Vw_batch_no.Items(i).Cells(9).Text)
        sample_no8.Text = Trim(Vw_batch_no.Items(i).Cells(10).Text)
        sample_no9.Text = Trim(Vw_batch_no.Items(i).Cells(11).Text)
        sample_no10.Text = Trim(Vw_batch_no.Items(i).Cells(12).Text)
    End Sub

    Private Sub Vw_batch_no_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles Vw_batch_no.ItemCommand

        i = e.Item.ItemIndex()
    End Sub

    Protected Sub sanddate_TextChanged(sender As Object, e As EventArgs) Handles sanddate.TextChanged
        show_sand()
        show_batch()
    End Sub
End Class