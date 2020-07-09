Imports System.Data.SqlClient
Imports System.Data


Public Class ChalanAndGatePassIssue
    Inherits System.Web.UI.Page


    Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
    Private con As New SqlConnection(ConfigurationManager.AppSettings("con"))
    Dim i As Integer
    Dim strsql As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Try

                SetType()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If

    End Sub

    Private Sub SetType()
        txtdesdate.Text = Now.Date

    End Sub


    Private Sub GetMemo()
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj

        cmd.CommandText = "Select top 5 Memo_No from mm_despatchMemo where CONVERT(varchar, Despatch_Date , 103)='" & Format(CDate(txtdesdate.Text), "dd/MM/yyyy") & "'"

        cmd.Connection.Open()

        ddlmemo.DataSource = cmd.ExecuteReader()
        ddlmemo.DataTextField = "Memo_No"
        ddlmemo.DataBind()

        cmd.Connection.Close()

        GetDetails()
    End Sub

    Protected Sub txtdesdate_TextChanged(sender As Object, e As EventArgs) Handles txtdesdate.TextChanged
        GetMemo()
        gridFunc()
    End Sub

    Protected Sub gridFunc()

        Dim str4 As String
        str4 = "select Memo_No,DespatchDate,Quantity,DCNo,GatePass from mm_Chalan_gatePass_Issue where DespatchDate='" & Format(CDate(txtdesdate.Text), "yyyy-MM-dd") & "'"

        Call BindDataGrid(str4)
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
            grid1.DataSource = arr
            grid1.DataBind()
            grid1.DataSource = objDr
            grid1.DataBind()
        Catch exp As SqlException
            strsql = exp.StackTrace
            lblMessage.Text = "Line : " & Mid(strsql, InStr(strsql, "line") + 5) & " Message : " + exp.Message

        Catch exp As Exception
            strsql = exp.StackTrace
            lblMessage.Text = "Line : " & Mid(strsql, InStr(strsql, "line") + 5) & " Message : " + exp.Message
        End Try

        con.Close()

    End Sub

    Protected Sub btngenDC_Click(sender As Object, e As EventArgs) Handles btngenDC.Click
        getNextChalanNo()
        getNextGatePassNo()
    End Sub

    Private Sub getNextChalanNo()
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.CommandText = "Select top 1 DCNo from mm_wheelDespatch_details order by DCNo desc"

        cmd.Connection.Open()



        Dim curValue As Integer
        Dim result As String
        result = cmd.ExecuteScalar().ToString()
        result = result.Substring(1)
        Int32.TryParse(result, curValue)
        curValue = curValue + 1
        txtDCNo.Text = "A" + curValue.ToString("D6")



    End Sub

    Private Sub getNextGatePassNo()
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj

        cmd.CommandText = "Select top 1 GatePass from mm_Chalan_gatePass_Issue order by ID desc"
        Try


            cmd.Connection.Open()

            Dim fyear As Integer
            Dim curValue As Integer
            Dim res As String
            Dim result As String
            Dim yr As String
            result = cmd.ExecuteScalar().ToString()
            'Response.Write(result)
            'If result = Nothing Then
            '    txtgp.Text = "WFPS/Gate Pass/2020-21/0001"
            'Else
            yr = result.Substring(15, 4)

                res = result.Substring(0, 23)
                Int32.TryParse(result.Substring(23, 4), curValue)
                If (yr = Now.Year) Then
                    curValue = curValue + 1
                    txtgp.Text = res + curValue.ToString("D4")
                Else
                    Int32.TryParse(result.Substring(21, 2), fyear)
                    fyear = fyear + 1
                    Dim yearValue As String
                    yearValue = Now.Year
                    curValue = 1
                    txtgp.Text = result.Substring(0, 15) + yearValue + result.Substring(20, 1) + fyear + curValue.ToString("D4")
                End If

        Catch exp As SqlException
            strsql = exp.StackTrace
            lblMessage.Text = "Line : " & Mid(strsql, InStr(strsql, "line") + 5) & " Message : " + exp.Message

        Catch exp As Exception
            strsql = exp.StackTrace
            lblMessage.Text = "Line : " & Mid(strsql, InStr(strsql, "line") + 5) & " Message : " + exp.Message
        End Try

    End Sub

    Protected Sub ddlmemo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlmemo.SelectedIndexChanged
        GetDetails()
    End Sub

    Protected Function checkmemo()
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj



        cmd.Connection.Open()
        cmd.CommandText = "Select count(*) from mm_Chalan_gatePass_Issue where Memo_No='" & ddlmemo.SelectedItem.Text & "' or DCNo='" & txtDCNo.Text & "'"
        Response.Write(cmd.ExecuteScalar())
        If cmd.ExecuteScalar() <> 0 Then
            Return False
        Else
            Return True
        End If
        cmd.Connection.Close()
    End Function

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim done As Boolean
        Dim doneC As Boolean
        doneC = checkmemo()
        Response.Write(doneC)
        If doneC = False Then
            lblMessage.Text = "Record Exists!"
            Exit Sub
        Else
            done = save()
            If done Then
                sendSMS()

                lblMessage.Text = "Saved"

            End If
        End If
    End Sub

    Protected Function save()

        Dim done As Boolean

        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj




        cmd.CommandText = "Insert INTO mm_Chalan_gatePass_Issue(Memo_No, Quantity, DCNo, GatePass, DespatchDate) 
           VALUES('" & ddlmemo.SelectedItem.Text & "', '" & txtquan.Text & "',  '" & txtDCNo.Text & "',  '" & txtgp.Text & "',  '" & Format(CDate(txtdesdate.Text), "yyy-MM-dd") & "')"

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


    Protected Sub GetDetails()
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj



        cmd.CommandText = "select Despatch_Date,Consignee_Name,Wheel_Type,Drawing_No,Specification_No,WtaNo,WtaDate,Rail_Letter,LorryNo,Driver_Name,Driver_ID,Rep_Name,Rep_ContactNo,Quantity,LRCNno,LRDate,RoadPermit,Contractor_Name from mm_despatchMemo where Memo_No='" & ddlmemo.SelectedItem.Text & "'"

        Try


            cmd.Connection.Open()

            Using sdr As SqlDataReader = cmd.ExecuteReader()
                sdr.Read()
                txtWhlTyp.Text = sdr("Wheel_Type").ToString()
                txtdraw.Text = sdr("Drawing_No").ToString()
                txtSpec.Text = sdr("Specification_No").ToString()
                txtwta.Text = sdr("WtaNo").ToString()
                txtWtaDate.Text = sdr("WtaDate").ToString()
                txtRailLetter.Text = sdr("Rail_Letter").ToString()
                txtlorry.Text = sdr("LorryNo").ToString()
                txtDriverName.Text = sdr("Driver_Name").ToString()
                txtdriverID.Text = sdr("Driver_ID").ToString()
                txtrepname.Text = sdr("Rep_Name").ToString()
                txtrepc.Text = sdr("Rep_ContactNo").ToString()
                txtcon.Text = sdr("Contractor_Name").ToString()
                txtLR.Text = sdr("LRCNno").ToString()
                txtRRdate.Text = sdr("LRDate").ToString()
                txtroad.Text = sdr("RoadPermit").ToString()
                txtquan.Text = sdr("Quantity").ToString()
                'txtval.Text = sdr("Drawing_No").ToString()
                'txtinvoice.Text = sdr("Specification_No").ToString()
                Dim desdate As String = sdr("Despatch_Date").ToString()
                txtdesdate.Text = Left(LTrim(desdate), 10)
                txtConsig.Text = sdr("Consignee_Name").ToString()






            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try


        cmd.Connection.Close()



    End Sub
    Protected Sub sendSMS()

        Dim message = " ADVICE MEMO NO: " + ddlmemo.SelectedItem.Text + vbNewLine + "CHALAN NO: " + txtDCNo.Text + vbNewLine + "GATE PASS NO: " + txtgp.Text + " IS ISSUED "

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