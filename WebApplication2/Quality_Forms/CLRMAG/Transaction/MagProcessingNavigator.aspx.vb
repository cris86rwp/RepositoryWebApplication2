Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports System.DateTime
Public Class MagProcessingNavigator
    Inherits System.Web.UI.Page
    Protected WithEvents panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents panel2 As System.Web.UI.WebControls.Panel
    Protected WithEvents panel3 As System.Web.UI.WebControls.Panel
    Protected WithEvents panel4 As System.Web.UI.WebControls.Panel
    Protected WithEvents panel5 As System.Web.UI.WebControls.Panel
    Protected WithEvents panel6 As System.Web.UI.WebControls.Panel
    Protected WithEvents panel7 As System.Web.UI.WebControls.Panel
    Protected WithEvents panel8 As System.Web.UI.WebControls.Panel
    Protected WithEvents panel9 As System.Web.UI.WebControls.Panel
    Protected WithEvents panel11 As System.Web.UI.WebControls.Panel
    Protected WithEvents panel10 As System.Web.UI.WebControls.Panel
    Protected WithEvents panel12 As System.Web.UI.WebControls.Panel
    Protected WithEvents txtuid As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpass As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtuidd As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpasss As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtMPIRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents rbl As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblshift As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rbldefects As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents RBLProductType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnsub As System.Web.UI.WebControls.Button
    Protected WithEvents lblmsg As System.Web.UI.WebControls.Label
    Protected WithEvents lblmsg1 As System.Web.UI.WebControls.Label
    Protected WithEvents LblWhlMesg As System.Web.UI.WebControls.Label
    Protected WithEvents lbld As System.Web.UI.WebControls.Label
    Protected WithEvents txtdate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtdrag As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtcope As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddline As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddwhltype As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddOperReqd As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtheat As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtwheel As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtbased As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtamm As System.Web.UI.WebControls.TextBox
    Protected WithEvents lbltype As System.Web.UI.WebControls.Label
    Protected WithEvents ddtyped As System.Web.UI.WebControls.DropDownList
    Protected WithEvents chkgrdsts As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkmcnopn As System.Web.UI.WebControls.CheckBox
    Protected WithEvents txtbhnone As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtbhntwo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtbhnthree As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtbcf As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtutbatch As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtutwheel As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtutstatus As System.Web.UI.WebControls.TextBox
    Protected WithEvents txthtbatch As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtDefectCode As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtWFPSdone As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFinalstatus As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtGrinding As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtMachining As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtUTDefectCode As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddutstatus As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddhtstatus As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DDDefTNull As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnstock As System.Web.UI.WebControls.Button
    Protected WithEvents btnclear As System.Web.UI.WebControls.Button
    Protected WithEvents BtnUpdate As System.Web.UI.WebControls.Button
    Protected WithEvents btnMagStatus As System.Web.UI.WebControls.Button
    Protected WithEvents PreMagnaGrid As System.Web.UI.WebControls.DataGrid
    Protected WithEvents MAGNAGRID As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents Message As System.Web.UI.WebControls.Label
    Protected WithEvents Help_Code As System.Web.UI.WebControls.CheckBox
    Public con As New SqlConnection(ConfigurationManager.AppSettings("con"))
    'Dim con As New SqlConnection
    Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
    Dim i As String
    Dim strSql As String
    Shared themeValue As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None
        Try
            If Page.IsPostBack = False Then
                getDateShift()
                clearscreen()
                SetScreen()
            End If
        Catch exp As Exception
            lblmsg.Text = exp.Message
        End Try
    End Sub

    Private Sub SetScreen()
        panel2.Visible = False
        panel3.Visible = False
        panel4.Visible = True
        panel5.Visible = False
        panel6.Visible = False
        panel7.Visible = False
        panel8.Visible = False
        panel9.Visible = False
        panel11.Visible = False
        panel12.Visible = False
        TxtMPIRemarks.Text = "OK"
    End Sub

    Public Sub getDateShift()
        If Now.Hour = 0 OrElse Now.Hour = 1 OrElse Now.Hour = 2 OrElse Now.Hour = 3 OrElse Now.Hour = 4 OrElse Now.Hour = 5 Then
            txtdate.Text = DateTime.Now.Date.AddDays(-1)
        Else
            txtdate.Text = DateTime.Now.Date
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
        rblshift.ClearSelection()
        For i = 0 To rblshift.Items.Count - 1
            If rblshift.Items(i).Text = Shift Then
                rblshift.Items(i).Selected = True
                Exit For
            End If
        Next
        dt = Nothing
        Shift = Nothing
        i = Nothing
    End Sub

    Protected Function validateCope()
        Dim j As Integer
        Dim uidd As String = txtuidd.Text
        Dim passs As String = txtpasss.Text

        Dim cmdd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmdd.Connection.Open()
        Try
            cmdd.CommandText = "SELECT COUNT(*) FROM menu_your_password_new where employee_code=@uidd and password=@passs "
            cmdd.Parameters.AddWithValue("@uidd", uidd)
            cmdd.Parameters.AddWithValue("@passs", passs)
            j = Convert.ToInt32(cmdd.ExecuteScalar())

        Catch ex As Exception
        End Try

        cmdd.Connection.Close()
        cmdd = Nothing
        Return j
    End Function

    Protected Function validateDrag()
        Dim uid As String = txtuid.Text
        Dim pass As String = txtpass.Text
        Dim k As Integer
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.Connection.Open()
        Try
            cmd.CommandText = "SELECT COUNT(*) FROM menu_your_password_new where employee_code=@uid and password=@pass  "
            cmd.Parameters.AddWithValue("@uid", uid)
            cmd.Parameters.AddWithValue("@pass", pass)

            k = Convert.ToInt32(cmd.ExecuteScalar())

        Catch ex As Exception

        End Try
        cmd.Connection.Close()
        cmd = Nothing
        Return k
    End Function

    Protected Sub btnsub_Click(sender As Object, e As EventArgs) Handles btnsub.Click

        Dim k As Integer = validateDrag()
        Dim j As Integer = validateCope()

        If k >= 1 And j >= 1 Then
            panel1.Visible = False
            panel2.Visible = True

            'Dim ss As String = rbl.SelectedItem.Value
            Dim dd As String = txtuid.Text
            Dim cc As String = txtuidd.Text
            setp2(dd, cc)
        Else
            lblmsg1.Visible = True
            lblmsg1.Text = "Invalid login user or Password"
        End If
    End Sub

    Private Sub setp2(ByVal dd As String, ByVal cc As String)

        txtdate.Text = DateTime.Now.Date
        txtcope.Text = cc.ToString()
        txtdrag.Text = dd.ToString()
        lbltype.Visible = True
        'ddtyped.Visible = True

    End Sub

    Protected Sub Help_Code_CheckedChanged(sender As Object, e As EventArgs) Handles Help_Code.CheckedChanged
        If Help_Code.Checked = True Then
            Dim url As String = "Help_MagnaCode.pdf"
            Dim s As String = "window.open('" & url + "', 'popup_window', 'width=700,height=800,left=500,top=100,resizable=yes');"
            ClientScript.RegisterStartupScript(Me.GetType(), "script", s, True)
        End If
    End Sub

    Protected Sub btnstock_Click(sender As Object, e As EventArgs) Handles btnstock.Click
        Dim Done As Boolean
        Try
            Done = f1()
        Catch exp As Exception
            lblmsg.Text = "Please Enter the Heat & Wheel No for Magna Testing"
            'MsgBox("Please Enter the Heat & Wheel No for Magna Testing")
        End Try
        If Done Then
            'MsgBox(" Magna Test Records Inserted Successfully !")
            lblmsg.Text = " Magna Test Records Inserted Successfully !"
            clearscreen()
        End If
        Dim sqlstr1 As String
        sqlstr1 = "select CONVERT(varchar, TestDate,106) TestDate,Shift ,ProdType,CopeInsp , DragInsp, LineNumber,HeatNo, WheelNo ,WheelType,DefectCodes, MPI_Remarks,  Machining, Grinding, BHN ,MbsCurrent, BCF, UtBatch , UtWheelNo , UtStatus , UtDefectCode,  FinalStatus from mm_magnaglow_new_shiftwiserecords where TestDate='" & Format(CDate(txtdate.Text), "MM/dd/yyyy") & "' and Shift='" & rblshift.SelectedItem.Value & "'"
        Call BindDataGrid(sqlstr1)
    End Sub

    Protected Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        Dim Done As Boolean
        Try
            Dim n As Integer = updatecheck()
            If n > 0 Then
                Done = f2()
            End If
        Catch exp As Exception
            lblmsg.Text = "Please select grid data for Edit the Records"
        End Try
        If Done Then
            'MsgBox("Magna Records Updation Successful!")
            lblmsg.Text = "Magna Records Updation is Successful !"
            clearscreen()
        End If
        Dim sqlstr1 As String
        sqlstr1 = "select CONVERT(varchar, TestDate,106) TestDate,Shift ,ProdType,CopeInsp , DragInsp, LineNumber,HeatNo, WheelNo ,WheelType,DefectCodes, MPI_Remarks,  Machining, Grinding, BHN ,MbsCurrent, BCF, UtBatch , UtWheelNo , UtStatus , UtDefectCode,  FinalStatus from mm_magnaglow_new_shiftwiserecords where TestDate='" & Format(CDate(txtdate.Text), "MM/dd/yyyy") & "' and Shift='" & rblshift.SelectedItem.Value & "'"
        Call BindDataGrid(sqlstr1)
    End Sub

    Public Function updatecheck()
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.Connection.Open()
        Dim mdate As Date = CDate(txtdate.Text)
        Dim shift As String = rblshift.SelectedItem.Value
        Dim HTNo As Integer = Convert.ToInt64(txtheat.Text)
        Dim WLNo As Integer = Convert.ToInt64(txtwheel.Text)
        Dim LineNo As Integer = ddline.SelectedItem.Value
        Dim FStatus As String = txtFinalstatus.Text

        cmd.CommandText = ("SELECT COUNT(*) FROM mm_magnaglow_new_shiftwiserecords where TestDate=@mdate and shift=@Shift and HeatNo=@HTNo and WheelNo=@WLNo and  LineNumber=@LineNo and FinalStatus=@FStatus")
        cmd.Parameters.AddWithValue("@mdate", mdate)
        cmd.Parameters.AddWithValue("@shift", shift)
        cmd.Parameters.AddWithValue("@HTNo", HTNo)
        cmd.Parameters.AddWithValue("@WLNo", WLNo)
        cmd.Parameters.AddWithValue("@LineNo", LineNo)
        cmd.Parameters.AddWithValue("@FStatus", FStatus)

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

    Private Sub clearscreen()
        txtheat.Text = ""
        txtwheel.Text = ""
        txtbhnone.Text = ""
        txtbhntwo.Text = ""
        txtbhnthree.Text = ""
        TxtMachining.Text = ""
        TxtGrinding.Text = ""
        TxtMPIRemarks.Text = "OK"
        TxtUTDefectCode.Text = ""
        TxtDefectCode.Text = ""
        TxtWFPSdone.Text = ""
        txtutwheel.Text = ""
        'lblmsg.Text = ""
        LblWhlMesg.Text = ""
    End Sub

    Protected Sub btnclear_Click(sender As Object, e As EventArgs) Handles btnclear.Click
        getDateShift()
        clearscreen()
    End Sub

    Public Function f1()
        Dim done As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Dim con As New SqlConnection
        cmd.Connection.Open()
        Dim oprtype As String = ""
        If ddOperReqd.SelectedItem.Value = "GRINDING" Then
            oprtype = TxtGrinding.Text
        ElseIf ddOperReqd.SelectedItem.Value = "MCNGRD" Then
            oprtype = TxtMachining.Text
        ElseIf ddOperReqd.SelectedItem.Value = "MACHINING" Then
            oprtype = TxtMachining.Text
        ElseIf ddOperReqd.SelectedItem.Value = "DEFECTXC" Then
            oprtype = "XC"
        ElseIf ddOperReqd.SelectedItem.Value = "NODEFECT" Then
            oprtype = DDDefTNull.SelectedItem.Value
        End If
        Response.Write(oprtype)
        Dim BhnRange As String = ""
        If RBLProductType.SelectedItem.Value = "BGC" And Val(txtbhnone.Text) < 321 And Val(txtbhnone.Text) > 255 Then
            BhnRange = "VALID"
        ElseIf RBLProductType.SelectedItem.Value = "BGC" And Val(txtbhnone.Text) > 321 Then
            BhnRange = "INVALID"
        ElseIf RBLProductType.SelectedItem.Value = "BGC" And Val(txtbhnone.Text) < 255 Then
            BhnRange = "INVALID"
        End If
        If RBLProductType.SelectedItem.Value = "BOXN" And Val(txtbhnone.Text) < 341 And Val(txtbhnone.Text) > 277 Then
            BhnRange = "VALID"
        ElseIf RBLProductType.SelectedItem.Value = "BOXN" And Val(txtbhnone.Text) > 341 Then
            BhnRange = "INVALID"
        ElseIf RBLProductType.SelectedItem.Value = "BOXN" And Val(txtbhnone.Text) < 277 Then
            BhnRange = "INVALID"
        End If
        Response.Write(BhnRange)

        Dim status As String = ""
        If oprtype = "OK" And ddutstatus.SelectedItem.Value = "Passed" And BhnRange = "VALID" Then
            status = "STOCK"
        ElseIf oprtype = "OK" And ddutstatus.SelectedItem.Value = "Passed" And BhnRange = "INVALID" Then
            status = "RHT"
        ElseIf BhnRange = "INVALID" And (ddOperReqd.SelectedItem.Value = "MACHINING" Or ddOperReqd.SelectedItem.Value = "GRINDING" Or ddOperReqd.SelectedItem.Value = "MCNGRD") Then
            status = "RHT"
        ElseIf oprtype = "XC" And ddOperReqd.SelectedItem.Value = "DEFECTXC" Then
            status = "XC"
        ElseIf BhnRange = "VALID" And (ddutstatus.SelectedItem.Value = "Passed" Or ddutstatus.SelectedItem.Value = "UnChecked") And (ddOperReqd.SelectedItem.Value = "MACHINING" Or ddOperReqd.SelectedItem.Value = "MCNGRD") Then
            status = TxtMachining.Text.Trim
        ElseIf BhnRange = "VALID" And ddutstatus.SelectedItem.Value = "Reject" Then
            status = "RLUT"
        ElseIf BhnRange = "VALID" And ddutstatus.SelectedItem.Value = "FReject" Then
            status = "XC"
        ElseIf oprtype = "OK" And ddutstatus.SelectedItem.Value = "UnChecked" And BhnRange = "VALID" Then
            status = "RLUT"
        ElseIf BhnRange = "VALID" And ddutstatus.SelectedItem.Value = "Passed" And ddOperReqd.SelectedItem.Value = "GRINDING" Then
            status = TxtGrinding.Text.Trim
        ElseIf BhnRange = "VALID" And ddutstatus.SelectedItem.Value = "UnChecked" And ddOperReqd.SelectedItem.Value = "GRINDING" Then
            status = TxtGrinding.Text.Trim
        ElseIf BhnRange = "VALID" And ddutstatus.SelectedItem.Value = "Passed" And ddOperReqd.SelectedItem.Value = "MACHINING" Then
            status = TxtMachining.Text.Trim
        ElseIf BhnRange = "VALID" And ddutstatus.SelectedItem.Value = "UnChecked" And ddOperReqd.SelectedItem.Value = "MACHINING" Then
            status = TxtMachining.Text.Trim
        ElseIf oprtype = "RLC" And ddOperReqd.SelectedItem.Value = "NODEFECT" And BhnRange = "VALID" Then
            status = "RLC"
        ElseIf oprtype = "RLB" And ddOperReqd.SelectedItem.Value = "NODEFECT" And BhnRange = "VALID" Then
            status = "RLB"
        ElseIf oprtype = "RLM" And ddOperReqd.SelectedItem.Value = "NODEFECT" And BhnRange = "VALID" Then
            status = "RLM"
        End If

        Response.Write(status)
        'txtFinalstatus.Text = status

        Try

            cmd.CommandText = "insert into mm_magnaglow_new_shiftwiserecords (TestDate  ,Shift  ,ProdType  ,CopeInsp  ,DragInsp  ,LineNumber  ,WheelType ,HeatNo  ,WheelNo ,DefectCodes ,MPI_OperType ,MPI_Remarks ,Machining ,Grinding ,BHN ,MbsCurrent ,BCF  ,UtBatch ,UtWheelNo ,UtStatus ,UtDefectCode ,FinalStatus  ,
	OperDoneWFPS,HTBatch ,HTStatus) values  ('" & Format(CDate(txtdate.Text), "MM/dd/yyyy") & "','" & rblshift.SelectedItem.Value & "',
                    '" & RBLProductType.SelectedItem.Value & "', '" & txtcope.Text & "', '" & txtdrag.Text & "','" & ddline.SelectedItem.Value & "', 
                    '" & ddwhltype.SelectedItem.Text & "', '" & Convert.ToInt64(txtheat.Text) & "', '" & Convert.ToInt64(txtwheel.Text) & "',
                    '" & TxtDefectCode.Text & "','" & ddOperReqd.SelectedItem.Value & "' ,'" & TxtMPIRemarks.Text & "', '" & TxtMachining.Text & "',
                    '" & TxtGrinding.Text & "', '" & Convert.ToInt64(txtbhnone.Text) & "',  '" & Convert.ToDecimal(txtamm.Text) & "' ,'" & txtbcf.Text & "',
                    '" & txtutbatch.Text & "','" & txtutwheel.Text & "','" & ddutstatus.SelectedItem.Value & "','" & TxtUTDefectCode.Text & "',
                    '" & status & "' ,'" & TxtWFPSdone.Text & "','" & txthtbatch.Text & "','" & ddhtstatus.SelectedItem.Value & "' )"

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

        Dim mdate As Date = CDate(txtdate.Text)
        Dim shift As String = rblshift.SelectedItem.Value
        Dim CInsp As String = txtcope.Text
        Dim DInsp As String = txtdrag.Text
        Dim LineNo As String = ddline.SelectedItem.Value
        Dim WHLTYPE As String = ddwhltype.SelectedItem.Text
        Dim HTNo As Integer = Convert.ToInt64(txtheat.Text)
        Dim WLNo As Integer = Convert.ToInt64(txtwheel.Text)
        Dim DefCode As String = TxtDefectCode.Text
        Dim MPIRem As String = TxtMPIRemarks.Text
        Dim Machining As String = TxtMachining.Text
        Dim Grinding As String = TxtGrinding.Text
        Dim BHN As Integer = Convert.ToInt64(txtbhnone.Text)
        Dim MbsCur As Decimal = Convert.ToDecimal(txtamm.Text)
        Dim BCF As String = txtbcf.Text
        Dim UTWHLNO As String = txtutwheel.Text
        Dim UTBATCH As String = txtutbatch.Text
        Dim UTSTS As String = ddutstatus.SelectedItem.Value
        Dim UTDEFCode As String = TxtUTDefectCode.Text
        Dim FStatus As String = txtFinalstatus.Text

        Try

            cmd.Connection.Open()

            cmd.CommandText = ("Update mm_magnaglow_new_shiftwiserecords set WheelType=@WHLTYPE , LineNumber= @LineNo, DefectCodes =@DefCode, MPI_Remarks=@MPIRem ,Machining=@Machining ,Grinding=@Grinding ,BHN=@BHN ,MbsCurrent=@MbsCur ,BCF=@BCF  ,UtBatch=@UTBATCH ,UtWheelNo=@UTWHLNO ,UtStatus=@UTSTS ,UtDefectCode=@UTDEFCode ,FinalStatus=@FStatus  where TestDate=@mdate and Shift=@shift and  WheelNo=@WLNo and HeatNo=@HTNo and FinalStatus=@FStatus")

            cmd.Parameters.AddWithValue("@mdate", mdate)
            cmd.Parameters.AddWithValue("@shift", shift)
            cmd.Parameters.AddWithValue("@CInsp", CInsp)
            cmd.Parameters.AddWithValue("@DInsp", DInsp)
            cmd.Parameters.AddWithValue("@WHLTYPE", WHLTYPE)
            cmd.Parameters.AddWithValue("@HTNo", HTNo)
            cmd.Parameters.AddWithValue("@WLNo", WLNo)
            cmd.Parameters.AddWithValue("@LineNo", LineNo)
            cmd.Parameters.AddWithValue("@DefCode", DefCode)
            cmd.Parameters.AddWithValue("@MPIRem", MPIRem)
            cmd.Parameters.AddWithValue("@Machining", Machining)
            cmd.Parameters.AddWithValue("@Grinding", Grinding)
            cmd.Parameters.AddWithValue("@BHN", BHN)
            cmd.Parameters.AddWithValue("@MbsCur", MbsCur)
            cmd.Parameters.AddWithValue("@BCF", BCF)
            cmd.Parameters.AddWithValue("@UTWHLNO", UTWHLNO)
            cmd.Parameters.AddWithValue("@UTBATCH", UTBATCH)
            cmd.Parameters.AddWithValue("@UTSTS", UTSTS)
            cmd.Parameters.AddWithValue("@UTDEFCode", UTDEFCode)
            cmd.Parameters.AddWithValue("@FStatus", FStatus)

            If cmd.ExecuteNonQuery() = 1 Then done = True

        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            cmd.Connection.Close()
        End Try
        Return done
    End Function

    Protected Sub txtwheel_TextChanged(sender As Object, e As EventArgs) Handles txtwheel.TextChanged
        validatewheel()
        GetHTbatchNo()
        GetPreMagnaData()
        MagWheelTest()
        Gettop2BHN()
        lblmsg.Text = ""
    End Sub

    Protected Sub Gettop2BHN()
        Dim ww As String = txtwheel.Text
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            cmd.Connection.Open()
            'Dim con As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User ID=sa;Password=sadev123")
            'con.Open()
            cmd.CommandText = "SELECT COUNT(*) FROM mm_wheel_heat_batch_details where Wheel_Number=@ww"
            cmd.Parameters.AddWithValue("@ww", ww)

            Dim i As Integer = Convert.ToInt32(cmd.ExecuteScalar())

            If i >= 1 Then

                GetBHNData()

            Else
                txtbhnone.Text = "0"
                txtbhntwo.Text = "0"
                txtbhnthree.Text = "0"

            End If

            cmd.Connection.Close()
        Catch exp As SqlException
            strSql = exp.StackTrace
            lblMessage.Text = "Line : " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message

        Catch exp As Exception
            strSql = exp.StackTrace
            lblMessage.Text = "Line : " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message
        End Try

    End Sub
    Protected Sub GetBHNData()

        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.Connection.Open()
        cmd.CommandText = ("SELECT TOP 2 BHN FROM mm_magnaglow_new_shiftwiserecords order by Magid desc")

        Dim reader As SqlDataReader
        reader = cmd.ExecuteReader()
        Dim label As TextBox() = New TextBox() {txtbhntwo, txtbhnthree}
        For Each l As TextBox In label
            If reader.Read() Then l.Text = reader.GetInt64(0)
        Next
        reader.Close()
        cmd.Connection.Close()
    End Sub
    Protected Sub ddwhltype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddwhltype.SelectedIndexChanged
        If ddwhltype.SelectedItem.Value = "M" Then
            panel8.Visible = True
            panel11.Visible = True
        ElseIf ddwhltype.SelectedItem.Value = "F" Then
            panel8.Visible = False
            panel11.Visible = False
        End If
    End Sub

    Protected Sub TxtDefectCode_TextChanged(sender As Object, e As EventArgs) Handles TxtDefectCode.TextChanged
        If TxtDefectCode.Text.Trim = "" Then
            panel3.Visible = True
            panel4.Visible = True
            TxtMPIRemarks.Text = DDDefTNull.SelectedItem.Value
        End If
    End Sub

    Protected Sub ddOperReqd_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddOperReqd.SelectedIndexChanged

        Dim oprtype As String = ""

        If ddOperReqd.SelectedItem.Value = "MACHINING" Then
            panel3.Visible = False
            panel4.Visible = False
            panel5.Visible = True
            panel6.Visible = False
            panel7.Visible = False
            oprtype = TxtMachining.Text
        ElseIf ddOperReqd.SelectedItem.Value = "GRINDING" Then
            panel3.Visible = False
            panel4.Visible = False
            panel5.Visible = False
            panel6.Visible = True
            panel7.Visible = False
            oprtype = TxtGrinding.Text
        ElseIf ddOperReqd.SelectedItem.Value = "MCNGRD" Then
            panel3.Visible = False
            panel4.Visible = False
            panel5.Visible = True
            panel6.Visible = True
            panel7.Visible = False
            oprtype = TxtMachining.Text
            'oprtype = TxtGrinding.Text
        ElseIf ddOperReqd.SelectedItem.Value = "DEFECTXC" Then
            panel3.Visible = True
            panel4.Visible = False
            panel5.Visible = False
            panel6.Visible = False
            panel7.Visible = False
            TxtMPIRemarks.Text = "XC"
            oprtype = "XC"
        ElseIf ddOperReqd.SelectedItem.Value = "NODEFECT" Then
            panel3.Visible = False
            panel4.Visible = True
            panel5.Visible = False
            panel6.Visible = False
            panel7.Visible = False
            TxtMPIRemarks.Text = DDDefTNull.SelectedItem.Value
            oprtype = DDDefTNull.SelectedItem.Value
        End If
        Response.Write(oprtype)
    End Sub

    Private Sub validatewheel()
        If txtwheel.Text = "" Or txtwheel.Text = "0" Then
            Exit Sub
        End If

        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            Dim WHNo As String = txtwheel.Text.Trim
            Dim HNo As String = txtheat.Text.Trim
            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            oCmd.Parameters.AddWithValue("@WHNo", WHNo)
            oCmd.Parameters.AddWithValue("@HNo", HNo)
            oCmd.CommandText = " select COUNT(*) FROM mm_wheel_heat_batch_details where Wheel_Number=@WHNo and heat_No=@HNo"

            Dim WhValid As Integer = Convert.ToInt32(oCmd.ExecuteScalar())
            If WhValid > 0 Then
                txtwheel.Text = Val(txtwheel.Text.Trim)
            Else
                txtwheel.Text = ""
            End If

            If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
            If WhValid > 0 Then
                txtwheel.Text = Val(txtwheel.Text.Trim)
                SetFocus(txtwheel)
            End If
        Catch exp As Exception
            MsgBox(" Please Enter Valid Wheel Number")
            lblmsg.Text = " Please enter valid Wheel N umber"
        End Try
    End Sub
    Private Sub MagWheelTest()
        LblWhlMesg.Text = ""
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.Connection.Open()
        Dim wheelno As String = txtwheel.Text.Trim
        Dim heatno As String = txtheat.Text.Trim
        Dim cnt As Integer
        cmd.CommandText = ("SELECT @cnt=COUNT(*) FROM mm_magnaglow_new_shiftwiserecords where HeatNo=@heatno and WheelNo=@wheelno")
        cmd.Parameters.AddWithValue("@wheelno", wheelno)
        cmd.Parameters.AddWithValue("@heatno", heatno)
        cmd.Parameters.Add("@cnt", SqlDbType.Int, 1).Direction = ParameterDirection.Output
        Try
            cmd.ExecuteScalar()
            Dim cnt1 As Integer = IIf(IsDBNull(cmd.Parameters("@cnt").Value), 0, cmd.Parameters("@cnt").Value)
            If cnt1 > 0 Then
                LblWhlMesg.Text = "Wheel No " & txtwheel.Text & " of Heat No " & txtheat.Text & " is already tested In Magna " & cnt1 & " times"
            Else
                If (ddline.SelectedItem.Value = "1" Or ddline.SelectedItem.Value = "2") And Val(txtwheel.Text) > 0 Then

                    LblWhlMesg.Text = "Wheel No " & txtwheel.Text & " of Heat No " & txtheat.Text & " is comes in Magna First Time"
                ElseIf (ddline.SelectedItem.Value = "3" Or ddline.SelectedItem.Value = "4") And Val(txtwheel.Text) > 0 Then
                    LblWhlMesg.Text = "Please check Wheel No " & txtwheel.Text & " of Heat No " & txtheat.Text & " in Line No 3 or 4"
                ElseIf txtwheel.Text.Trim = "" Then
                    LblWhlMesg.Text = "Please Enter the Valid Wheel No of Heat No " & txtheat.Text & " for Magna Testing"
                End If
            End If
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing
        End Try
    End Sub

    Private Sub GetHTbatchNo()
        Dim dt As New DataTable()
        dt = RWF.Magna.GetHTbatchNo(Val(txtwheel.Text), Val(txtheat.Text))
        If dt.Rows.Count > 0 Then
            txthtbatch.Text = IIf(IsDBNull(dt.Rows(0)("BNo")), "", dt.Rows(0)("BNo"))
        Else
            txthtbatch.Text = ""
        End If
        dt = Nothing
    End Sub

    Private Sub GetLine3newdata()
        Dim dt As New DataTable()
        dt = RWF.Magna.GetLine3newdata(Val(txtwheel.Text), Val(txtheat.Text))
        If dt.Rows.Count > 0 Then
            txtutwheel.Text = IIf(IsDBNull(dt.Rows(0)("UTWNo")), "", dt.Rows(0)("UTWNo"))
            txtutbatch.Text = IIf(IsDBNull(dt.Rows(0)("UTBTNo")), "", dt.Rows(0)("UTBTNo"))
            txtbcf.Text = IIf(IsDBNull(dt.Rows(0)("BCF")), "", dt.Rows(0)("BCF"))
            ddutstatus.SelectedItem.Value = IIf(IsDBNull(dt.Rows(0)("UTSTS")), "", dt.Rows(0)("UTSTS"))
            txtbhnone.Text = IIf(IsDBNull(dt.Rows(0)("BHN")), "", dt.Rows(0)("BHN"))
            ddwhltype.SelectedItem.Value = IIf(IsDBNull(dt.Rows(0)("WHLTYPE")), "", dt.Rows(0)("WHLTYPE"))
        End If
        dt = Nothing
    End Sub

    Protected Sub ddline_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddline.SelectedIndexChanged
        If ddline.SelectedItem.Value = "3" Then
            GetLine3newdata()
            txtutbatch.Enabled = False
            txtutwheel.Enabled = False
            txtbcf.Enabled = False
            ddutstatus.Enabled = False
            txtbhnone.Enabled = False
            ddwhltype.Enabled = False
        ElseIf ddline.SelectedItem.Value = "4" Then
            GetLine3newdata()
            txtutbatch.Enabled = False
            txtutwheel.Enabled = False
            txtbcf.Enabled = False
            ddutstatus.Enabled = False
            txtbhnone.Enabled = False
            ddwhltype.Enabled = False
        Else
            txtutbatch.Enabled = True
            txtutwheel.Enabled = True
            txtbcf.Enabled = True
            ddutstatus.Enabled = True
            txtbhnone.Enabled = True
            ddwhltype.Enabled = True
        End If
    End Sub

    Protected Sub txtdate_TextChanged(sender As Object, e As EventArgs) Handles txtdate.TextChanged
        Dim sqlstr1 As String
        sqlstr1 = "select CONVERT(varchar, TestDate,106) TestDate,Shift,ProdType,CopeInsp, DragInsp, LineNumber,HeatNo, WheelNo ,WheelType,DefectCodes, MPI_Remarks,  Machining, Grinding, BHN ,MbsCurrent, BCF, UtBatch , UtWheelNo , UtStatus , UtDefectCode,  FinalStatus from mm_magnaglow_new_shiftwiserecords where TestDate='" & Format(CDate(txtdate.Text), "MM/dd/yyyy") & "' and Shift='" & rblshift.SelectedItem.Value & "'"
        'sqlstr1 = "select CONVERT(varchar, TestDate,106) TestDate,Shift,CopeInsp, DragInsp, LineNumber,HeatNo, WheelNo ,WheelType,DefectCodes, MPI_Remarks,  Machining, Grinding, BHN ,MbsCurrent, BCF, UtBatch , UtWheelNo , UtStatus , UtDefectCode,  FinalStatus from mm_magnaglow_new_shiftwiserecords where TestDate='" & Format(CDate(txtdate.Text), "MM/dd/yyyy") & "'"
        Call BindDataGrid(sqlstr1)
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
            Response.Write(objCmd)

            objDr = objCmd.ExecuteReader()
            Response.Write(objDr)

            Dim arr() As String

            MAGNAGRID.DataSource = arr
            MAGNAGRID.DataBind()
            MAGNAGRID.DataSource = objDr
            MAGNAGRID.DataBind()
        Catch exp As SqlException
            strSql = exp.StackTrace
            lblMessage.Text = "Line :  " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message
        Catch exp As Exception
            strSql = exp.StackTrace
            lblMessage.Text = "Line : " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message
        End Try
        con.Close()
    End Sub

    Private Sub MAGNAGRID_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles MAGNAGRID.ItemCommand
        i = e.Item.ItemIndex()
    End Sub

    Protected Sub MAGNAGRID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MAGNAGRID.SelectedIndexChanged
        MAGNAGRID.SelectedIndex = i

        txtdate.Text = MAGNAGRID.Items(i).Cells(1).Text
        rblshift.SelectedItem.Value = Trim(MAGNAGRID.Items(i).Cells(2).Text)
        RBLProductType.SelectedItem.Value = Trim(MAGNAGRID.Items(i).Cells(3).Text)
        txtcope.Text = Trim(MAGNAGRID.Items(i).Cells(4).Text)
        txtdrag.Text = Trim(MAGNAGRID.Items(i).Cells(5).Text)
        ddline.SelectedItem.Value = Trim(MAGNAGRID.Items(i).Cells(6).Text)
        txtheat.Text = Trim(MAGNAGRID.Items(i).Cells(7).Text)
        txtwheel.Text = MAGNAGRID.Items(i).Cells(8).Text
        ddwhltype.SelectedItem.Value = Trim(MAGNAGRID.Items(i).Cells(9).Text)
        TxtDefectCode.Text = MAGNAGRID.Items(i).Cells(10).Text
        TxtMPIRemarks.Text = MAGNAGRID.Items(i).Cells(11).Text
        TxtMachining.Text = MAGNAGRID.Items(i).Cells(12).Text
        TxtGrinding.Text = MAGNAGRID.Items(i).Cells(13).Text
        txtbhnone.Text = MAGNAGRID.Items(i).Cells(14).Text
        txtamm.Text = MAGNAGRID.Items(i).Cells(15).Text
        txtbcf.Text = MAGNAGRID.Items(i).Cells(16).Text
        txtutbatch.Text = MAGNAGRID.Items(i).Cells(17).Text
        txtutwheel.Text = MAGNAGRID.Items(i).Cells(18).Text
        ddutstatus.SelectedItem.Value = Trim(MAGNAGRID.Items(i).Cells(19).Text)
        TxtUTDefectCode.Text = MAGNAGRID.Items(i).Cells(20).Text
        txtFinalstatus.Text = MAGNAGRID.Items(i).Cells(21).Text
    End Sub

    Protected Sub rblshift_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblshift.SelectedIndexChanged
        Dim sqlstr1 As String
        sqlstr1 = "select CONVERT(varchar, TestDate,106) TestDate,Shift ,ProdType,CopeInsp , DragInsp, LineNumber,HeatNo, WheelNo ,WheelType,DefectCodes, MPI_Remarks,  Machining, Grinding, BHN ,MbsCurrent, BCF, UtBatch , UtWheelNo , UtStatus , UtDefectCode,  FinalStatus from mm_magnaglow_new_shiftwiserecords where TestDate='" & Format(CDate(txtdate.Text), "MM/dd/yyyy") & "' and Shift='" & rblshift.SelectedItem.Value & "'"
        Call BindDataGrid(sqlstr1)
    End Sub

    Protected Sub txtheat_TextChanged(sender As Object, e As EventArgs) Handles txtheat.TextChanged
        MagWheelTest()
    End Sub

    Protected Sub ddutstatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddutstatus.SelectedIndexChanged
        If ddutstatus.SelectedItem.Value = "Reject" Or ddutstatus.SelectedItem.Value = "FReject" Then
            panel9.Visible = True
            panel12.Visible = True
        Else
            panel9.Visible = False
            panel12.Visible = False
        End If
    End Sub

    Protected Sub btnMagStatus_Click(sender As Object, e As EventArgs) Handles btnMagStatus.Click
        Dim url As String
        url = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?id=29195&apsuser=Administrator&apspassword=Cris@123&apsauthtype=secEnterprise&user0=sa&password0=sadev123&promptonrefresh=0" &
            "&promptex0=DateTime(" & CDate(txtdate.Text).Year & "," & CDate(txtdate.Text).Month & ", " & CDate(txtdate.Text).Day & ", 0,0,0)" &
            "&promptex1=" & rblshift.SelectedItem.Value
        'Response.Redirect(strPathName)

        Dim s As String = "window.open('" & url + "', 'popup_window', 'width=700,height=800,left=500,top=100,resizable=yes');"
        ClientScript.RegisterStartupScript(Me.GetType(), "script", s, True)
    End Sub

    Private Sub GetPreMagnaData()
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Dim wheelno As String = txtwheel.Text.Trim
        Dim heatno As String = txtheat.Text.Trim
        'Dim sdate As String = Format(CDate(txtdate.Text), "MM/dd/yyyy")
        cmd.Connection.Open()
        cmd.CommandText = ("select FinalStatus, MPI_Remarks ,Machining ,Grinding, DefectCodes,UtStatus ,UtDefectCode ,BHN ,CONVERT(varchar, TestDate,106) TESTDATE  ,Shift  ,CopeInsp  ,DragInsp from mm_magnaglow_new_shiftwiserecords where HeatNo=@heatno and WheelNo =@wheelno order by MagId desc")
        cmd.Parameters.AddWithValue("@wheelno", wheelno)
        cmd.Parameters.AddWithValue("@heatno", heatno)
        Try
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            PreMagnaGrid.DataSource = dr
            PreMagnaGrid.DataBind()

        Catch exp As SqlException
            strSql = exp.StackTrace
            Message.Text = "Line : " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message

        Catch exp As Exception
            strSql = exp.StackTrace
            Message.Text = "Line : " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message
        End Try
        cmd.Connection.Close()
    End Sub

End Class