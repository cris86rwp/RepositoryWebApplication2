Imports System.Data
Imports System.Data.SqlClient
Public Class magnaprocessingnavigator
    Inherits System.Web.UI.Page
    Protected WithEvents panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents panel2 As System.Web.UI.WebControls.Panel
    Protected WithEvents panel3 As System.Web.UI.WebControls.Panel
    Protected WithEvents panel4 As System.Web.UI.WebControls.Panel
    Protected WithEvents panel5 As System.Web.UI.WebControls.Panel
    Protected WithEvents txtuid As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpass As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtuidd As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpasss As System.Web.UI.WebControls.TextBox
    Protected WithEvents rbl As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblshift As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rbldefects As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnsubmit As System.Web.UI.WebControls.Button
    Protected WithEvents lblmsg As System.Web.UI.WebControls.Label
    Protected WithEvents lblmsg1 As System.Web.UI.WebControls.Label
    Protected WithEvents lbld As System.Web.UI.WebControls.Label
    Protected WithEvents txtdate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtdrag As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtcope As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddline As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddwhltype As System.Web.UI.WebControls.DropDownList
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
    Protected WithEvents TxtmMchining As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtGrinding As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtXCcodes As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddutstatus As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddhtstatus As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnstock As System.Web.UI.WebControls.Button
    Protected WithEvents btnclear As System.Web.UI.WebControls.Button
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label

    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim i As String
    Dim strSql As String
    Shared themeValue As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None
        Try
            If Page.IsPostBack = False Then

                SetScreen()
                clearscreen()
                'panel3.Visible = True
            End If
        Catch exp As Exception
            lblmsg.Text = exp.Message
        End Try
    End Sub
    Private Sub SetScreen()
        panel2.Visible = False
        panel3.Visible = False
        Panel4.Visible = False
        Panel5.Visible = False
        Panel6.Visible = False
    End Sub

    Protected Sub btnsub_Click(sender As Object, e As EventArgs) Handles btnsub.Click
        Dim uid As String = txtuid.Text
        Dim pass As String = txtpass.Text
        Dim uidd As String = txtuidd.Text
        Dim passs As String = txtpasss.Text
        Dim con As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User ID=sa;Password=sadev123")
        con.Open()
        Dim cmd As New SqlCommand("SELECT COUNT(*) FROM menu_your_password_new where   employee_code=@uid and password=@pass  ", con)
        Dim cmdd As New SqlCommand("SELECT COUNT(*) FROM menu_your_password_new where  employee_code=@uidd and password=@passs ", con)
        cmd.Parameters.AddWithValue("@uid", uid)
        cmd.Parameters.AddWithValue("@pass", pass)
        cmdd.Parameters.AddWithValue("@uidd", uidd)
        cmdd.Parameters.AddWithValue("@passs", passs)
        Dim i As Integer = Convert.ToInt32(cmd.ExecuteScalar())
        Dim j As Integer = Convert.ToInt32(cmdd.ExecuteScalar())
        cmd = Nothing
        cmdd = Nothing
        con.Close()

        If i >= 1 And j >= 1 Then
            panel1.Visible = False
            panel2.Visible = True

            'Dim ss As String = rbl.SelectedItem.Value
            Dim dd As String = txtuid.Text
            Dim cc As String = txtuidd.Text
            setp2(dd, cc)
        Else
            lblmsg1.Visible = True
            lblmsg1.Text = "invalid login"
        End If
    End Sub
    Private Sub setp2(ByVal dd As String, ByVal cc As String)

        txtdate.Text = DateTime.Now.Date


        txtcope.Text = cc.ToString()

        txtdrag.Text = dd.ToString()

        If rbldefects.SelectedItem.Value = "yes" Then
            lbltype.Visible = True
            ddtyped.Visible = True

        End If
        If ddtyped.SelectedItem.Value = "no defects" Then
            chkgrdsts.Checked = False
            Chkmcnopn.Checked = False
        End If


    End Sub

    Protected Sub rbldefects_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rbldefects.SelectedIndexChanged
        If rbldefects.SelectedItem.Value = "yes" Then
            lbltype.Visible = True
            ddtyped.Visible = True
            lbltype.Enabled = True
            ddtyped.Enabled = True
            chkgrdsts.Enabled = True
            Chkmcnopn.Enabled = True
        Else
            lbltype.Enabled = False
            ddtyped.Enabled = False
            chkgrdsts.Enabled = False
            Chkmcnopn.Enabled = False
        End If
    End Sub

    Private Sub clearscreen()
        txtheat.Text = ""
        txtwheel.Text = ""
        txtbhnone.Text = ""
        txtbhntwo.Text = ""
        txtbhnthree.Text = ""
        TxtmMchining.Text = ""
        TxtGrinding.Text = ""
    End Sub

    Protected Sub ddtyped_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddtyped.SelectedIndexChanged
        If ddtyped.SelectedItem.Value = "no defects" Then
            chkgrdsts.Checked = False
            Chkmcnopn.Checked = False
            Panel4.Visible = False
            Panel5.Visible = False
            Panel6.Visible = False
        ElseIf ddtyped.SelectedItem.Value = "defects for grinding" Then
            chkgrdsts.Checked = True
            Chkmcnopn.Checked = False
            Panel4.Visible = False
            Panel5.Visible = True
            Panel6.Visible = False
        ElseIf ddtyped.SelectedItem.Value = "defects for machining" Then
            chkgrdsts.Checked = False
            Chkmcnopn.Checked = True
            Panel4.Visible = True
            Panel5.Visible = False
            Panel6.Visible = False
        ElseIf ddtyped.SelectedItem.Value = "defects for machining and grinding" Then
            chkgrdsts.Checked = True
            Chkmcnopn.Checked = True
            Panel4.Visible = True
            Panel5.Visible = True
            Panel6.Visible = False
        ElseIf ddtyped.SelectedItem.Value = "Defects for XC" Then
            chkgrdsts.Checked = False
            Chkmcnopn.Checked = False
            Panel4.Visible = False
            Panel5.Visible = False
            Panel6.Visible = True
        End If
    End Sub

    Protected Sub btnstock_Click(sender As Object, e As EventArgs) Handles btnstock.Click
        Dim Done As Boolean
        Try
            Done = f1()

        Catch exp As Exception

            lblmsg.Text = exp.Message
        End Try
        If Done Then
            lblmsg.Text = " Updation Successful !"
            panel3.Visible = True
        End If

    End Sub

    Protected Sub btnclear_Click(sender As Object, e As EventArgs) Handles btnclear.Click

    End Sub
    Public Function f1()
        Dim done As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Try
            con.ConnectionString = "Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User ID=sa;Password=sadev123"
            con.Open()
            cmd.Connection = con

            Dim type As String = ""
            If rbldefects.SelectedItem.Value = "yes" Then
                type = ddtyped.SelectedItem.Value
            Else
                type = "no defects"
            End If

            Dim status As String = ""
            If type = "no defects" And ddutstatus.SelectedItem.Value = "passed" And Val(txtbhnone.Text) < 321 And Val(txtbhnone.Text) > 255 Then
                status = "stock"
            ElseIf type = "no defects" And ddutstatus.SelectedItem.Value = "passed" And Val(txtbhnone.Text) < 255 Then
                status = "RHT"
            ElseIf type = "no defects" And ddutstatus.SelectedItem.Value = "passed" And Val(txtbhnone.Text) > 321 Then
                status = "RHT"
            ElseIf type = "defects for grinding" And ddutstatus.SelectedItem.Value = "passed" Then
                status = "UT Passed"
            ElseIf type = "defects for machining" And ddutstatus.SelectedItem.Value = "passed" Then
                status = "UT Passed"
            ElseIf type = "defects for machining and grinding" And ddutstatus.SelectedItem.Value = "passed" Then
                status = "UT Passed"
            ElseIf type = "no defects" And ddutstatus.SelectedItem.Value = "reject" Then
                status = "UT failed"
            ElseIf type = "defects for grinding" And ddutstatus.SelectedItem.Value = "reject" Then
                status = "UT failed"
            ElseIf type = "defects for machining" And ddutstatus.SelectedItem.Value = "reject" Then
                status = "UT failed"
            ElseIf type = "defects for machining and grinding" And ddutstatus.SelectedItem.Value = "reject" Then
                status = "UT failed"
            ElseIf type = "no defects" And ddutstatus.SelectedItem.Value = "unchecked" Then
                status = "UT unchecked"
            ElseIf type = "defects for grinding" And ddutstatus.SelectedItem.Value = "unchecked" Then
                status = "UT unckecked"
            ElseIf type = "defects for machining" And ddutstatus.SelectedItem.Value = "unchecked" Then
                status = "UT unckecked"
            ElseIf type = "defects for machining and grinding" And ddutstatus.SelectedItem.Value = "unchecked" Then
                status = "UT unckecked"
            ElseIf type = "Defects for XC" Then
                status = "XC Wheel"
            End If


            'cmd.CommandText = "insert into mm_magnaglow_shiftwiserecords_new values('" & Format(CDate(txtdate.Text), "MM/dd/yyyy") & "','" & rblshift.SelectedItem.Value & "',
            '                      '" & Convert.ToInt64(txtcope.Text) & "', '" & Convert.ToInt64(txtdrag.Text) & "','" & ddline.SelectedItem.Value & "',
            '                        '" & ddwhltype.SelectedItem.Value & "', '" & Convert.ToInt64(txtheat.Text) & "', '" & Convert.ToInt64(txtwheel.Text) & "',
            '                        '" & rbldefects.SelectedItem.Value & "','" & type & "' , '" & Convert.ToInt64(txtbhnone.Text) & "',
            '                        '" & Convert.ToDecimal(txtamm.Text) & "','" & txtbcf.Text & "','" & txtutbatch.Text & "','" & txtutwheel.Text & "',
            '                        '" & status & "' ,'" & txtutstatus.Text & "','" & txthtbatch.Text & "','" & ddhtstatus.SelectedItem.Value & "' )"

            cmd.CommandText = "insert into mm_magnaglow_shiftwiserecords_new values('" & Format(CDate(txtdate.Text), "MM/dd/yyyy") & "','" & rblshift.SelectedItem.Value & "',
                                  '" & Convert.ToInt64(txtcope.Text) & "', '" & Convert.ToInt64(txtdrag.Text) & "','" & ddline.SelectedItem.Value & "',
                                    '" & ddwhltype.SelectedItem.Value & "', '" & Convert.ToInt64(txtheat.Text) & "', '" & Convert.ToInt64(txtwheel.Text) & "',
                                    '" & rbldefects.SelectedItem.Value & "','" & type & "' , '" & Convert.ToInt64(txtbhnone.Text) & "','" & Convert.ToDecimal(txtamm.Text) & "',
                                    '" & txtbcf.Text & "','" & txtutbatch.Text & "','" & txtutwheel.Text & "' ,'" & status & "' ,'" & txtutstatus.Text.Trim & "',
                                    '" & txthtbatch.Text & "','" & ddhtstatus.SelectedItem.Value & "','" & TxtmMchining.Text.Trim & "','" & TxtGrinding.Text.Trim & "','" & TxtXCcodes.Text.Trim & "')"



            If cmd.ExecuteNonQuery() = 1 Then done = True

        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            con.Close()
        End Try
        Return done
    End Function

    Protected Sub txtwheel_TextChanged(sender As Object, e As EventArgs) Handles txtwheel.TextChanged
        'CheckWheelNo(txtheat.Text.Trim, txtwheel.Text.Trim)
        validatewheel()
        GetHTbatchNo()
        Dim ww As String = txtwheel.Text
        Dim con As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User ID=sa;Password=sadev123")
        con.Open()
        Dim cmd As New SqlCommand("SELECT COUNT(*) FROM mm_magnaglow_shiftwiserecords_new where wheelno=@ww  ", con)

        cmd.Parameters.AddWithValue("@ww", ww)
        Dim i As Integer = Convert.ToInt32(cmd.ExecuteScalar())

        cmd = Nothing

        con.Close()

        If i >= 1 Then
            con.Open()
            'Dim cmdd As New SqlCommand("SELECT TOP 3 bhn FROM mm_magnaglow_shiftwiserecords_new where   wheelno=@ww  ", con)
            Dim cmdd As New SqlCommand("SELECT TOP 3 bhn FROM mm_magnaglow_shiftwiserecords_new order by Magid desc", con)
            cmdd.Parameters.AddWithValue("@ww", ww)

            Dim reader As SqlDataReader
            reader = cmdd.ExecuteReader()
            Dim label As TextBox() = New TextBox() {txtbhnone, txtbhntwo, txtbhnthree}
            For Each l As TextBox In label
                If reader.Read() Then l.Text = reader.GetInt64(0)
            Next

            reader.Close()
        Else
            txtbhnone.Text = "0"
            txtbhntwo.Text = "0"
            txtbhnthree.Text = "0"
        End If
    End Sub

    'Private Sub CheckWheelNo(ByVal HeatNumber As Integer, ByVal WheelNumber As Integer)

    '    Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
    '    oCmd.Parameters.Add("@cnt", SqlDbType.Int, 3).Direction = ParameterDirection.Output
    '    Try
    '        If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
    '        oCmd.CommandText = "select @cnt = Wheel_Number mm_wheel_heat_batch_details where Wheel_Number= " & CInt(WheelNumber) And heat_No = " & CInt(HeatNumber)"
    '        oCmd.ExecuteScalar()
    '        CheckWheelNo = IIf(IsDBNull(oCmd.Parameters("@cnt").Value), 0, oCmd.Parameters("@cnt").Value)
    '    Catch exp As Exception
    '        CheckWheelNo = 0
    '        Throw New Exception(exp.Message)
    '    Finally
    '        If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
    '        oCmd.Dispose()
    '        oCmd = Nothing
    '    End Try
    'End Sub
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
            lblmsg.Text = exp.Message

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
    Private Sub GetLine3data()
        Dim dt As New DataTable()
        dt = RWF.Magna.GetLine3data(Val(txtwheel.Text), Val(txtheat.Text))
        If dt.Rows.Count > 0 Then
            txtutwheel.Text = IIf(IsDBNull(dt.Rows(0)("UTWNo")), "", dt.Rows(0)("UTWNo"))
            txtutbatch.Text = IIf(IsDBNull(dt.Rows(0)("UTBTNo")), "", dt.Rows(0)("UTBTNo"))
            txtbcf.Text = IIf(IsDBNull(dt.Rows(0)("BCF")), "", dt.Rows(0)("BCF"))
            txtutstatus.Text = IIf(IsDBNull(dt.Rows(0)("UTSTS")), "", dt.Rows(0)("UTSTS"))
            txtbhnone.Text = IIf(IsDBNull(dt.Rows(0)("BHN")), "", dt.Rows(0)("BHN"))
        End If
        dt = Nothing
    End Sub

    Protected Sub ddline_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddline.SelectedIndexChanged

        If ddline.SelectedItem.Value = "3" Then
            GetLine3data()
            txtutbatch.Enabled = False
            txtutwheel.Enabled = False
            txtbcf.Enabled = False
            txtutstatus.Enabled = False
            txtbhnone.Enabled = False
        Else
            txtutbatch.Enabled = True
            txtutwheel.Enabled = True
            txtbcf.Enabled = True
            txtutstatus.Enabled = True
            txtbhnone.Enabled = True
        End If
    End Sub
    Protected Sub txtdate_TextChanged(sender As Object, e As EventArgs) Handles txtdate.TextChanged
        Dim sqlstr1 As String
        sqlstr1 = "select CONVERT(varchar, date,106) date,shift ,copeinsp , draginsp, linenumber,heatno, wheelno ,bhn , utbatch , utwheelno , utstatus , utxcwhlsts , Machining, Grinding, XcCodes  from mm_magnaglow_shiftwiserecords_new where date='" & Format(CDate(txtdate.Text), "MM/dd/yyyy") & "'  and shift='" & rblshift.SelectedItem.Value & "'"
        Call BindDataGrid(sqlstr1)
    End Sub
    Private Sub BindDataGrid(ByVal strArg As String)

        Dim objCmd As SqlCommand
        Dim objDr As SqlDataReader
        Dim con As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")

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
            MAGNAGRID.DataSource = arr
            MAGNAGRID.DataBind()
            MAGNAGRID.DataSource = objDr
            MAGNAGRID.DataBind()
        Catch exp As SqlException
            strSql = exp.StackTrace
            lblMessage.Text = "Line : " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message

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

        rblshift.SelectedItem.Value = Trim(MAGNAGRID.Items(i).Cells(2).Text)
        txtcope.Text = Trim(MAGNAGRID.Items(i).Cells(3).Text)
        txtdrag.Text = Trim(MAGNAGRID.Items(i).Cells(4).Text)
        ddline.SelectedItem.Value = Trim(MAGNAGRID.Items(i).Cells(5).Text)
        txtheat.Text = Trim(MAGNAGRID.Items(i).Cells(6).Text)
        txtwheel.Text = MAGNAGRID.Items(i).Cells(7).Text
        txtbhnone.Text = MAGNAGRID.Items(i).Cells(8).Text
        txtutbatch.Text = MAGNAGRID.Items(i).Cells(9).Text
        txtutwheel.Text = MAGNAGRID.Items(i).Cells(10).Text
        txtutstatus.Text = MAGNAGRID.Items(i).Cells(11).Text
        TxtmMchining.Text = MAGNAGRID.Items(i).Cells(12).Text
        TxtGrinding.Text = MAGNAGRID.Items(i).Cells(13).Text
        TxtXCcodes.Text = MAGNAGRID.Items(i).Cells(14).Text
    End Sub


    Protected Sub rblshift_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblshift.SelectedIndexChanged
        Dim sqlstr1 As String
        sqlstr1 = "select CONVERT(varchar, date,106) date,shift ,copeinsp , draginsp, linenumber,heatno, wheelno ,bhn , utbatch , utwheelno , utstatus , utxcwhlsts , Machining, Grinding, XcCodes  from mm_magnaglow_shiftwiserecords_new where date='" & Format(CDate(txtdate.Text), "MM/dd/yyyy") & "'  and shift='" & rblshift.SelectedItem.Value & "'"
        Call BindDataGrid(sqlstr1)
    End Sub
    'Protected Sub txtdate_TextChanged(sender As Object, e As EventArgs) Handles txtdate.TextChanged
    '    panel3.Visible = True
    'End Sub
End Class