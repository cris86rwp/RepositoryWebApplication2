Imports System.Data.SqlClient
Imports System.Data

Public Class WheelDespatchDetails
    Inherits System.Web.UI.Page



    Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
    Private con As New SqlConnection(ConfigurationManager.AppSettings("con"))
    Dim i As Integer
    Dim strsql As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Try

                SetType()
                ' getChalanNo()
                getCount()
                getMemo()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub getMemo()

        Dim lltstr As String = txtdate.Text
        Dim strdate As Date = Left(LTrim(lltstr), 10)
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.Connection.Open()
        cmd.CommandText = "Select Memo_No from mm_despatchMemo where Despatch_Date=@strdate"
        cmd.Parameters.AddWithValue("@strdate", strdate)


        ddlmemo.DataSource = cmd.ExecuteReader()
        ddlmemo.DataTextField = "Memo_No"
        ddlmemo.DataBind()
        cmd.Connection.Close()

        getChalanNo()
    End Sub


    Private Sub getChalanNo()

        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.CommandText = "Select DCNo from mm_Chalan_gatePass_Issue where Memo_No='" & ddlmemo.SelectedItem.Text & "'"

        cmd.Connection.Open()


        txtDC.Text = cmd.ExecuteScalar()
        cmd.Connection.Close()

    End Sub


    Private Sub getCount()
        lblcountmsg.Visible = True
        lblCount.Visible = True
        Dim count As String

        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.CommandText = "Select COUNT(*) from mm_wheelDespatch_details where DCNo='" & txtDC.Text & "' and WheelNo='" & txtwheel.Text & "'"

        cmd.Connection.Open()
        lblcountmsg.Text = "No. of enteries for Wheel No. '" & txtwheel.Text & "' and Chalan No. '" & txtDC.Text & "' are :"


        lblCount.Text = cmd.ExecuteScalar()

    End Sub

    Protected Sub txtdate_TextChanged(sender As Object, e As EventArgs) Handles txtdate.TextChanged
        getMemo()

    End Sub

    Private Sub SetType()
        lblcountmsg.Visible = False
        lblCount.Visible = False
        txtheat.Text = ""
        txtwheel.Text = ""
        txttread.Text = ""
        txtbore.Text = ""
        txtplate.Text = ""
        txtbhn.Text = ""
        txtdate.Text = Now.Date
        txttime.Text = Now.Hour.ToString() + ":" + Now.Minute.ToString() + ":" + Now.Second.ToString()
    End Sub
    Protected Function check()

        Dim wheelno As String

        wheelno = Val(txtwheel.Text)
        Try
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj

            cmd.Connection.Open()





            cmd.CommandText = "SELECT COUNT(*) FROM  mm_wheelDespatch_details where WheelNo=@wheelno "
            cmd.Parameters.AddWithValue("@wheelno", wheelno)
            Dim i As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            Return i
            cmd = Nothing
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            cmd.Connection.Close()
        End Try




    End Function

    Protected Sub ddlmemo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlmemo.SelectedIndexChanged
        getChalanNo()
    End Sub

    Protected Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim donne As Boolean
        Dim Done As Boolean
        Dim done1 As Integer
        Try
            done1 = check()
            donne = compareQuan()
            If done1 = 0 And donne Then
                Done = save()

            ElseIf donne = False Then
                lblsave.Text = "Wheel count exceeds the total quantity"
            ElseIf done1 = 0 Then

                lblsave.Text = "Wheel No already exists"
            Else

                lblsave.Text = "Check the data entered"
            End If

        Catch exp As Exception

            lblMessage.Text = exp.Message
        End Try
        If Done Then
            updDespatchStatus()
            sendSMS()
            lblsave.Text = "Data Saved ! "



        End If
    End Sub
    Public Function compareQuan()

        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Dim donne As Boolean = True


        Try

            cmd.Connection.Open()

            cmd.CommandText = "select top 1 Quantity from mm_despatchMemo where DCNo='" & txtDC.Text & "'"

            Dim quantity As Integer = cmd.ExecuteScalar()

            If quantity < Val(lblCount.Text) Then
                donne = False

            End If
            Return donne
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try


        cmd.Connection.Close()







    End Function



    Public Function save()
        Dim done As Boolean



        Try
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj

            cmd.Connection.Open()


            cmd.CommandText = "Insert INTO mm_wheelDespatch_details(DCNo,HeatNo,WheelNo,TreadDia,BoreDia,PlateThickness,BHN,FinalStatus)  
           VALUES ('" & txtDC.Text & "', '" & Val(txtheat.Text) & "' , '" & Val(txtwheel.Text) & "', '" & Val(txttread.Text) & "',
          '" & Val(txtbore.Text) & "', '" & Val(txtplate.Text) & "', '" & Val(txtbhn.Text) & "', '" & ddlstat.SelectedItem.Text & "') "

            If cmd.ExecuteNonQuery() = 1 Then


                done = True
            End If

        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally

            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing


        End Try


    End Function

    Protected Sub updDespatchStatus()
        Dim done As Boolean


        Dim cmd2 As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd2.Connection.Open()
        Try


            Dim whl As String = Val(txtwheel.Text)
            Dim heat As String = Val(txtheat.Text)


            cmd2.CommandText = "update mm_wheelInspection Set Des_status='yes' where Heatnumber=@heat and Wheelnumber=@whl"

            cmd2.Parameters.AddWithValue("@whl", whl)
            cmd2.Parameters.AddWithValue("@heat", heat)



            If cmd2.ExecuteNonQuery() = 1 Then done = True

        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally

            cmd2.Connection.Close()
        End Try




    End Sub
    Protected Sub txtheat_SelectedTextChanged(sender As Object, e As EventArgs) Handles txtheat.TextChanged

        lblMessage.Visible = False
        getheatchemstatus()
        Dim sqlstr3 As String
        If (txtheat.Text <> "") Then

            sqlstr3 = "select wi.Heatnumber,wi.Wheelnumber,wi.threaddia,wi.boredia,wi.platethickness,wi.wheelStatus,mg.BHN,mg.UtStatus,mg.FinalStatus from mm_WheelInspection wi, mm_magnaglow_new_shiftwiserecords mg where wi.Heatnumber=mg.HeatNo and wi.Wheelnumber=mg.WheelNo and wi.Heatnumber='" & Val(txtheat.Text) & "' and wheelStatus='Pass' and wi.Des_status is null"
            Call BindDataGrid(sqlstr3)
            lblMessage.Visible = False
        Else
            lblMessage.Text = "Enter the Heat Number"
        End If
    End Sub

    Protected Sub getheatchemstatus()
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.CommandText = "Select heatstatus from mm_spectro_results_new where heatnumber='" & txtheat.Text & "' and sampletype='JMP'"

        cmd.Connection.Open()

        Dim jmpstat As String = cmd.ExecuteScalar()
        If (jmpstat = "JMP Pass") Then
            lblheatchem.Text = jmpstat
        Else
            cmd.CommandText = "Select heatstatus from mm_spectro_results_new where heatnumber='" & txtheat.Text & "' and sampletype='product'"

            lblheatchem.Text = cmd.ExecuteScalar()

        End If
        cmd.Connection.Close()

    End Sub

    Protected Sub getheattreattatus()
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.CommandText = "Select top 1 ht_status from mm_draw_furnace_details where heat_number='" & txtheat.Text & "' and Wheel_number='" & txtwheel.Text & "'"

        cmd.Connection.Open()

        lblheattreat.Text = cmd.ExecuteScalar()

        cmd.Connection.Close()

    End Sub

    Protected Sub txtwheel_SelectedTextChanged(sender As Object, e As EventArgs) Handles txtwheel.TextChanged
        getCount()
        getheattreattatus()


    End Sub

    Private Sub BindDataGrid(ByVal strArg As String)

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
            DataGrid1.DataSource = arr
            DataGrid1.DataBind()
            DataGrid1.DataSource = objDr
            DataGrid1.DataBind()
        Catch exp As SqlException
            strsql = exp.StackTrace
            lblMessage.Text = "Line : " & Mid(strsql, InStr(strsql, "line") + 5) & " Message : " + exp.Message

        Catch exp As Exception
            strsql = exp.StackTrace
            lblMessage.Text = "Line : " & Mid(strsql, InStr(strsql, "line") + 5) & " Message : " + exp.Message
        End Try

        con.Close()

    End Sub

    Protected Sub datagrid1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DataGrid1.SelectedIndexChanged
        DataGrid1.SelectedIndex = i
        txtheat.Text = Trim(DataGrid1.Items(i).Cells(1).Text)
        txtwheel.Text = Trim(DataGrid1.Items(i).Cells(2).Text)
        txttread.Text = Trim(DataGrid1.Items(i).Cells(3).Text)
        txtbore.Text = Trim(DataGrid1.Items(i).Cells(4).Text)
        txtplate.Text = Trim(DataGrid1.Items(i).Cells(5).Text)
        ddlstat.SelectedItem.Text = DataGrid1.Items(i).Cells(6).Text
        txtbhn.Text = Trim(DataGrid1.Items(i).Cells(7).Text)
    End Sub
    Private Sub datagrid1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.ItemCommand
        i = e.Item.ItemIndex()
    End Sub

    Protected Sub sendSMS()

        Dim message = " WHEEL WITH ADVICE MEMO NO: " + ddlmemo.SelectedItem.Text + vbNewLine + "CHALAN NO: " + txtDC.Text + vbNewLine + vbNewLine + "WHEEL NO: " + txtwheel.Text + " IS DESPATCHED "

        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.Connection.Open()

        Try
            cmd.CommandText = "SELECT Mobile_No FROM Maint_user_contact_details where Shop_User_Code IN ('DWSTORE','DWPCO','DWWFPS') "

            Dim reader As SqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                Dim no As String = reader("Mobile_No").ToString()

                Dim number As String = "91" + no
                Dim strGet As String
                Dim url1 As String = "http://enterprise.smsgupshup.com/GatewayAPI/rest?method=SendMessage&send_to="
                Dim url2 As String = "&msg="
                Dim url3 As String = "&msg_type=TEXT&userid=2000184632&auth_scheme=plain&password=pWK3H5&v=1.1&format=text"
                strGet = url1 + number + url2 + message + url3
                Dim webClient As New System.Net.WebClient
                Dim result As String = webClient.DownloadString(strGet)
            End While


            cmd = Nothing
            cmd.Connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub




End Class