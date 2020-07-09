Imports System.Data.SqlClient
Imports System.Data

Public Class WheelDespatch

    Inherits System.Web.UI.Page
    Protected WithEvents Panel1 As Global.System.Web.UI.WebControls.Panel
    Protected WithEvents Heading As Global.System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage As Global.System.Web.UI.WebControls.Label
    Protected WithEvents lbldesdate As Global.System.Web.UI.WebControls.Label
    Protected WithEvents txtdesdate As Global.System.Web.UI.WebControls.TextBox
    Protected WithEvents lblmemo As Global.System.Web.UI.WebControls.Label
    Protected WithEvents ddlmemo As Global.System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblConsignee As Global.System.Web.UI.WebControls.Label
    Protected WithEvents ddlConsig As Global.System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblwhltyp As Global.System.Web.UI.WebControls.Label
    Protected WithEvents txtWhlTyp As Global.System.Web.UI.WebControls.TextBox
    Protected WithEvents lbldraw As Global.System.Web.UI.WebControls.Label
    Protected WithEvents txtdraw As Global.System.Web.UI.WebControls.TextBox
    Protected WithEvents lblspec As Global.System.Web.UI.WebControls.Label
    Protected WithEvents txtSpec As Global.System.Web.UI.WebControls.TextBox
    Protected WithEvents lblwta As Global.System.Web.UI.WebControls.Label
    Protected WithEvents ddlwta As Global.System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblwtadate As Global.System.Web.UI.WebControls.Label
    Protected WithEvents txtWtaDate As Global.System.Web.UI.WebControls.TextBox
    Protected WithEvents Label1 As Global.System.Web.UI.WebControls.Label
    Protected WithEvents txtRailLetter As Global.System.Web.UI.WebControls.TextBox
    Protected WithEvents lbllorry As Global.System.Web.UI.WebControls.Label
    Protected WithEvents txtlorry As Global.System.Web.UI.WebControls.TextBox
    Protected WithEvents lbldriverName As Global.System.Web.UI.WebControls.Label
    Protected WithEvents txtDriverName As Global.System.Web.UI.WebControls.TextBox
    Protected WithEvents lbldriver As Global.System.Web.UI.WebControls.Label
    Protected WithEvents txtdriverID As Global.System.Web.UI.WebControls.TextBox
    Protected WithEvents lblrep As Global.System.Web.UI.WebControls.Label
    Protected WithEvents txtrepname As Global.System.Web.UI.WebControls.TextBox
    Protected WithEvents lblrepc As Global.System.Web.UI.WebControls.Label
    Protected WithEvents txtrepc As Global.System.Web.UI.WebControls.TextBox
    Protected WithEvents lblcon As Global.System.Web.UI.WebControls.Label
    Protected WithEvents txtcon As Global.System.Web.UI.WebControls.TextBox
    Protected WithEvents lblLR As Global.System.Web.UI.WebControls.Label
    Protected WithEvents txtLR As Global.System.Web.UI.WebControls.TextBox
    Protected WithEvents lblRRdate As Global.System.Web.UI.WebControls.Label
    Protected WithEvents txtRRdate As Global.System.Web.UI.WebControls.TextBox
    Protected WithEvents lblRR As Global.System.Web.UI.WebControls.Label
    Protected WithEvents txtroad As Global.System.Web.UI.WebControls.TextBox
    Protected WithEvents lblquan As Global.System.Web.UI.WebControls.Label
    Protected WithEvents txtquan As Global.System.Web.UI.WebControls.TextBox
    Protected WithEvents lblvalue As Global.System.Web.UI.WebControls.Label
    Protected WithEvents txtval As Global.System.Web.UI.WebControls.TextBox
    Protected WithEvents lblinvoice As Global.System.Web.UI.WebControls.Label
    Protected WithEvents txtinvoice As Global.System.Web.UI.WebControls.TextBox
    Protected WithEvents lblDCNo As Global.System.Web.UI.WebControls.Label
    Protected WithEvents lblDC As Global.System.Web.UI.WebControls.Label
    Protected WithEvents lblgp As Global.System.Web.UI.WebControls.Label
    Protected WithEvents txtgp As Global.System.Web.UI.WebControls.TextBox
    Protected WithEvents btnUpdate As Global.System.Web.UI.WebControls.Button
    Protected WithEvents upd As Global.System.Web.UI.WebControls.CheckBox

    Protected WithEvents chkRLetter As Global.System.Web.UI.WebControls.RadioButton

    Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
    Private con As New SqlConnection(ConfigurationManager.AppSettings("con"))
    Dim i As Integer
    Dim strsql As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            getWTANo()
            getWheelType()
            getNextMemoNo()
            txtdesdate.Text = Format(CDate(Now.Date), "dd/MM/yyyy")
            GetConsignee()
            GetChaalan()
        End If
        If chkRLetter.Checked Then
            ddlConsig_SelectedIndexChanged(sender, e)
            ddlWhlTyp_SelectedIndexChanged(sender, e)
        Else
            ddlwta_SelectedIndexChanged(sender, e)
            ddlConsig_SelectedIndexChanged(sender, e)
            ddlWhlTyp_SelectedIndexChanged(sender, e)

        End If

    End Sub
    Private Sub GetChaalan()
        Dim done As Boolean

        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.CommandText = "Select DCNo from mm_Chalan_gatePass_Issue where Memo_No='" & txtmemo.Text & "'"

        Try
            cmd.Connection.Open()

            If cmd.ExecuteScalar() <> "" Then
                lblDC.Text = cmd.ExecuteScalar()
            Else
                lblMessage.Text = "Chalan No. corresponding to this Memo No. does not exist"
            End If

        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally

            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing

        End Try

    End Sub
    Private Sub getWheelType()
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.CommandText = "Select distinct Wheel_Type from mm_productSpecification"

        cmd.Connection.Open()

        ddlWhlTyp.DataSource = cmd.ExecuteReader()
        ddlWhlTyp.DataTextField = "Wheel_Type"
        ddlWhlTyp.DataBind()

        cmd.Connection.Close()

    End Sub

    Private Sub getNextMemoNo()
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.CommandText = "Select top 1 Memo_No from mm_despatchMemo order by id desc"

        cmd.Connection.Open()

        Dim fyear As Integer
        Dim curValue As Integer
        Dim res As String
        Dim result As String
        result = cmd.ExecuteScalar().ToString()
        Response.Write(result)
        res = result.Substring(8)
        Int32.TryParse(res, curValue)


        If (Now.Year = Left(LTrim(result), 4)) Then
            curValue = curValue + 1
            Response.Write(curValue)
            txtmemo.Text = Left(LTrim(result), 8) + curValue.ToString("D4")
        Else
            Int32.TryParse(result.Substring(6, 2), fyear)
            fyear = fyear + 1
            Dim yearValue As String
            yearValue = Now.Year
            curValue = 1
            txtgp.Text = yearValue + result.Substring(5, 1) + fyear + curValue.ToString("D4")
        End If
        cmd.Connection.Close()

    End Sub

    Public Function getWTANo()
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.Connection.Open()

        cmd.CommandText = "select top 4 WtaNumber from mm_pco_WTA_Meetings order by WtaRef desc"

        ddlwta.DataSource = cmd.ExecuteReader()
        ddlwta.DataTextField = "WtaNumber"
        ddlwta.DataBind()


        cmd.Connection.Close()

    End Function

    Protected Sub ddlwta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlwta.SelectedIndexChanged
        getWTADate()
    End Sub

    Protected Sub ddlWhlTyp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlWhlTyp.SelectedIndexChanged
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj

        cmd.CommandText = "select Drawing_No,Specification_No from mm_productSpecification where Wheel_Type='" & ddlWhlTyp.SelectedItem.Text & "'"
        Try


            cmd.Connection.Open()

            Using sdr As SqlDataReader = cmd.ExecuteReader()
                sdr.Read()

                txtdraw.Text = sdr("Drawing_No").ToString()
                txtSpec.Text = sdr("Specification_No").ToString()
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try


        cmd.Connection.Close()

    End Sub

    Public Function getWTADate()
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj

        cmd.CommandText = "select WtaDate from mm_pco_WTA_Meetings where WtaNumber='" & ddlwta.SelectedItem.Text & "'"

        Try


            cmd.Connection.Open()

            Using sdr As SqlDataReader = cmd.ExecuteReader()
                sdr.Read()

                Dim lltstr As String = sdr("WtaDate").ToString()
                txtWtaDate.Text = Format(CDate(Left(LTrim(lltstr), 10)), "dd/MM/yyyy")

            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try


        cmd.Connection.Close()
    End Function
    Public Function GetConsignee()
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.Connection.Open()

        cmd.CommandText = "Select ShortName from mm_customer_Consignee where code like'RWP%'"

        'cmd.ExecuteScalar()
        ddlConsig.DataSource = cmd.ExecuteReader()
        ddlConsig.DataTextField = "ShortName"
        ddlConsig.DataBind()

        cmd.Connection.Close()

    End Function
    Protected Sub ddlConsig_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlConsig.SelectedIndexChanged

        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.Connection.Open()

        cmd.CommandText = "Select consignee_gst from mm_customer_Consignee where ShortName='" & ddlConsig.SelectedItem.Text & "'"

        txtgstn.Text = cmd.ExecuteScalar()

        cmd.Connection.Close()

    End Sub


    Protected Sub txtdesdate_TextChanged(sender As Object, e As EventArgs) Handles txtdesdate.TextChanged
        gridFunc()
    End Sub

    Protected Sub upd_SelectedIndexChanged(sender As Object, e As EventArgs) Handles upd.CheckedChanged

        If upd.checked Then
            txtLR.Visible = True
            txtRRdate.Visible = True
            txtroad.Visible = True
            lblLR.Visible = True
            lblRRdate.Visible = True
            lblRR.Visible = True
            gridFunc()
        End If


    End Sub

    Protected Sub ChkRailLetter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles chkRLetter.CheckedChanged

        If chkRLetter.Checked Then
            txtRailLetter.Enabled = True
            txtWtaDate.Text = Now.Date
            ddlwta.Enabled = False
            ddlwta.SelectedItem.Text = ""

        End If



    End Sub
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim done As Boolean

        done = saveFunc()
        If done Then
            sendSMS()
            lblMessage.Text = "Saved"
        End If
    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim done As Boolean

        done = updateFunc()
        If done Then
            lblMessage.Text = "Updated"
        End If
    End Sub

    Protected Function saveFunc()
        Dim done As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj

        cmd.CommandText = "Insert INTO mm_despatchMemo(Memo_No, Despatch_Date, Consignee_Name, Wheel_Type, Drawing_No, Specification_No, WtaNumber, WtaDate, LorryNo, Driver_name, Driver_ID, Rep_Name, Rep_ContactNo, Quantity, Contractor_Name, Lorry_Placement_time) 
           VALUES('" & txtmemo.Text & "','" & Format(CDate(txtdesdate.Text), "yyyy-MM-dd") & "','" & ddlConsig.SelectedItem.Text & "','" & ddlWhlTyp.SelectedItem.Text & "','" & txtdraw.Text & "','" & txtSpec.Text & "','" & ddlwta.SelectedItem.Text & "','" & Format(CDate(txtWtaDate.Text), "yyyy-MM-dd") & "','" & txtlorry.Text & "','" & txtDriverName.Text & "','" & txtdriverID.Text & "','" & txtrepname.Text & "','" & txtrepc.Text & "', '" & txtquan.Text & "', '" & txtcon.Text & "', '" & txtlorrytime.Text & "')"

        Try
            cmd.Connection.Open()

            If cmd.ExecuteNonQuery() = 1 Then done = True

        Catch exp As SqlException
            strsql = exp.StackTrace
            lblMessage.Text = "Line : " & Mid(strsql, InStr(strsql, "line") + 5) & " Message : " + exp.Message

        Catch exp As Exception
            strsql = exp.StackTrace
            lblMessage.Text = "Line : " & Mid(strsql, InStr(strsql, "line") + 5) & " Message : " + exp.Message

        Finally

            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing


        End Try
        Return done
    End Function

    Protected Function updateFunc()

        ' despatch date k corresponding sb advice memo display krna yyani grid m
        ' txtdate change event p bhi grid call kr dena

        ' where m sirf date laana

        Dim done As Boolean


        Dim cmd2 As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd2.Connection.Open()
            Try


            Dim txtRR_date As Date = Format(CDate(txtRRdate.Text), "yyyy-MM-dd")
            Dim txt_LR As String = Val(txtLR.Text)
                Dim memo As String = txtmemo.Text
                Dim txt_road As String = txtroad.Text


            cmd2.CommandText = "update mm_despatchMemo Set LRCNno =@txt_LR, LRDate =@txtRR_date, RoadPermit =@txt_road where Memo_No=@memo"

            cmd2.Parameters.AddWithValue("@txt_LR", txt_LR)
                cmd2.Parameters.AddWithValue("@txtRR_date", txtRR_date)
                cmd2.Parameters.AddWithValue("@txt_road", txt_road)
                cmd2.Parameters.AddWithValue("@memo", memo)


                If cmd2.ExecuteNonQuery() = 1 Then done = True


        Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally

                cmd2.Connection.Close()
            End Try


            Return done

    End Function


    Protected Sub gridFunc()

        Dim str4 As String
        str4 = "select Memo_No,Despatch_Date,Consignee_Name,Wheel_Type,Drawing_No,Specification_No,WtaNumber,WtaDate,Rail_Letter,LorryNo,Driver_Name,Driver_ID,Rep_Name,Rep_ContactNo,Quantity,DCNo,Contractor_Name from mm_despatchMemo where Despatch_Date='" & txtdesdate.Text & "'"

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

    Protected Sub grid1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grid1.SelectedIndexChanged
        grid1.SelectedIndex = i

        lblDC.Text = Trim(grid1.Items(i).Cells(3).Text)
        ' ddlConsig.SelectedValue = grid1.Items(i).Cells(4).Text
        'ddlWhlTyp.SelectedValue = grid1.Items(i).Cells(5).Text
        txtdraw.Text = Trim(grid1.Items(i).Cells(6).Text)
        txtSpec.Text = Trim(grid1.Items(i).Cells(7).Text)
        ' ddlwta.SelectedValue = grid1.Items(i).Cells(8).Text
        txtWtaDate.Text = Trim(grid1.Items(i).Cells(9).Text)
        txtRailLetter.Text = Trim(grid1.Items(i).Cells(10).Text)
        txtlorry.Text = Trim(grid1.Items(i).Cells(11).Text)
        txtDriverName.Text = Trim(grid1.Items(i).Cells(12).Text)
        txtdriverID.Text = Trim(grid1.Items(i).Cells(13).Text)
        txtrepname.Text = Trim(grid1.Items(i).Cells(14).Text)
        txtrepc.Text = Trim(grid1.Items(i).Cells(15).Text)
        txtquan.Text = Trim(grid1.Items(i).Cells(16).Text)
        txtcon.Text = Trim(grid1.Items(i).Cells(17).Text)




    End Sub
    Private Sub grid1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grid1.ItemCommand
        i = e.Item.ItemIndex()
    End Sub


    Protected Sub sendSMS()

        Dim message = " ADVICE MEMO NO: " + txtmemo.Text + vbNewLine + "IS GENERATED"
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

            MsgBox("Message Sent")
            cmd = Nothing
            cmd.Connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub






End Class