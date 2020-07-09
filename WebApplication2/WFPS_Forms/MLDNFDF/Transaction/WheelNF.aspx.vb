Imports System.Data
Imports System.Data.SqlClient
Imports System.DateTime
Imports System.Configuration
Imports System.Web.UI.WebControls.TableCellCollection
Imports System.Web.UI.WebControls.DataGridColumnCollection
Imports System.Web.UI.WebControls.DataGridColumn
Imports System.Web.UI.WebControls.TemplateColumn


Public Class WheelNF
    Inherits System.Web.UI.Page
    Protected WithEvents txtShiftInC As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtWheel As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtHeat As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblShift As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtInDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtInTime As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtOutDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents txtSrNo As System.Web.UI.WebControls.TextBox
    'Protected WithEvents txtOffLoad As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtOutTime As System.Web.UI.WebControls.TextBox
    'Protected WithEvents txtQDuration As System.Web.UI.WebControls.TextBox
    'Protected WithEvents txTemp As System.Web.UI.WebControls.TextBox
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtOperator As System.Web.UI.WebControls.TextBox
    'Protected WithEvents txtQuencher As System.Web.UI.WebControls.TextBox
    'Protected WithEvents txtHCDuration As System.Web.UI.WebControls.TextBox
    Protected WithEvents Panel2 As System.Web.UI.WebControls.Panel
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid3 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblSl_No As System.Web.UI.WebControls.Label
    Protected WithEvents rblCold As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents addsrno As System.Web.UI.WebControls.Button
    Protected WithEvents txtpour As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblsrbit As System.Web.UI.WebControls.Label


    Dim dte As Date
    Dim Shift As String
    Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
    Dim sFormat As System.Globalization.DateTimeFormatInfo = New System.Globalization.DateTimeFormatInfo()



#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region
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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        'Put user code to initialize the page here


        txtDate.AutoPostBack = False

        If IsPostBack = False Then

            sFormat.ShortDatePattern = "dd-MM-yyyy"
            txtDate.Text = Format(Convert.ToDateTime(Now.Date, sFormat), "dd-MM-yyyy")
            'getdateshift()

            'txtDate.Text = (Now.Date)
            ' txtInDate.Text = Now.Date
            ' txtInTime.Text = Right(("0" + Now.Hour.ToString), 2) + ":" + Right(("0" + Now.Minute.ToString), 2)
            ' txtOutDate.Text = Now.Date
            ' txtOutTime.Text = "00:00"
            Try
                GetNFData1()
                incr_srno()
                inc_resetbit()


            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            SetFocus(txtHeat)
        End If
    End Sub

    Dim sr As Integer
    'Protected Sub addsrno_Click(sender As Object, e As EventArgs) Handles addsrno.Click
    '    'ClientScript.RegisterStartupScript(Me.GetType(), "alert", MsgBox("Want to reset Sr no ??",
    '    '                    MsgBoxStyle.OkCancel Or MsgBoxStyle.Question Or MsgBoxStyle.DefaultButton2, "Reset Sr No"), True)

    '    Dim res As MsgBoxResult = MsgBox("Want to reset Sr no ??", MsgBoxStyle.YesNo Or MsgBoxStyle.Question Or MsgBoxStyle.DefaultButton2, "Reset Sr No")

    '    If res = MsgBoxResult.Yes Then
    '        'lblMessage.Text = "ok"
    '        sr = 1
    '        txtSrNo.Text = sr.ToString()
    '        inc_resetbit()
    '        Exit Sub
    '    End If
    '    If res = MsgBoxResult.No Then
    '        'lblMessage.Text = "no"
    '        getsrno()
    '        Exit Sub
    '    End If
    '    'lblMessage.Text = "ext sub"
    'End Sub
    Private Sub inc_resetbit()
        Dim srbit As Integer
        Dim tmp As Integer
        'sFormat.ShortDatePattern = "MM/dd/yyyy"
        'txtDate.Text = Format(Convert.ToDateTime(Now.Date, sFormat), "MM/dd/yyyy")
        Try
            cmd.Connection.Open()
            cmd.CommandText = "Select top(1) srbit from mm_nf_loading order by srbit desc"
            Dim srn As SqlDataReader
            srn = cmd.ExecuteReader()
            srn.Read()
            lblsrbit.Text = srn("srbit").ToString()
            Int32.TryParse(lblsrbit.Text, srbit)
            srbit = srbit + 1
            lblsrbit.Text = srbit.ToString()
            srn.Close()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            cmd.Connection.Close()
        End Try
    End Sub
    Private Sub getdateshift()
        txtDate.AutoPostBack = False
        If Now.Hour = 0 OrElse Now.Hour = 1 OrElse Now.Hour = 2 OrElse Now.Hour = 3 OrElse Now.Hour = 4 OrElse Now.Hour = 5 Then

            txtDate.Text = Format(CDate(Now.Date.AddDays(-1)), "dd-MM-yyyy")
            'Now.Date.AddDays(-1)
        Else
            txtDate.Text = Format(CDate(Now.Date), "dd-MM-yyyy")
        End If

        dte = Now
        Select Case dte.Hour
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
        rblShift.ClearSelection()
        For i = 0 To rblShift.Items.Count - 1
            If rblShift.Items(i).Text = Shift Then
                rblShift.Items(i).Selected = True
                Exit For
            End If
        Next
        dte = Nothing
        Shift = Nothing
    End Sub


    Private Sub getsrno()
        Dim srno As Integer
        'sFormat.ShortDatePattern = "MM/dd/yyyy"
        'txtDate.Text = Format(Convert.ToDateTime(Now.Date, sFormat), "MM/dd/yyyy")
        Try
            cmd.Connection.Open()
            cmd.CommandText = "Select top(1) wheel_sr_no from mm_nf_loading order by Sl_No desc"
            Dim srn As SqlDataReader
            srn = cmd.ExecuteReader()
            srn.Read()
            txtSrNo.Text = srn("wheel_sr_no").ToString()
            Int32.TryParse(txtSrNo.Text, srno)
            srno = srno + 1
            txtSrNo.Text = srno.ToString()
            srn.Close()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            cmd.Connection.Close()
        End Try
    End Sub

    Private Sub getwheel()

        Dim po As Integer
        Dim done As Boolean
        Dim heat_number As Integer = txtHeat.Text
        done = checkpourorder()

        If done = True Then
            po = getpourorder()
            po = po + 1

        Else
            po = 1
        End If
        txtpour.Text = po
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.Connection.Open()
        cmd.CommandText = "SELECT wheel_number FROM mm_wheel where heat_number=@heat_number and pour_order=@po"
        cmd.Parameters.AddWithValue("@heat_number", Val(heat_number))
        cmd.Parameters.AddWithValue("@po", po)


        Try

            Dim i As Integer = Convert.ToInt32(cmd.ExecuteScalar())

            txtWheel.Text = i

            'Return i
            ' If cmd.ExecuteNonQuery() = 1 Then done1 = True


        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally

            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing

        End Try
        If txtWheel.Text = 0 Then
            lblMessage.Text = "All wheels have been loaded for this heat number"
            txtpour.Text = 1
        End If
    End Sub
    Private Function checkpourorder()

        ' Dim i As Integer

        Dim heat_number As Integer = txtHeat.Text

        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.Connection.Open()
        cmd.CommandText = "SELECT COUNT(*) FROM mm_nf_loading where heat_number=@heat_number "
        cmd.Parameters.AddWithValue("@heat_number", Val(heat_number))

        ' cmd = Nothing
        Try

            Dim i As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            Return i

            ' If cmd.ExecuteNonQuery() = 1 Then done1 = True


        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally

            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing

        End Try

    End Function
    Private Function getpourorder()
        Dim heat_number As Integer = txtHeat.Text
        cmd.CommandText = "Select top 1 pour_order from mm_nf_loading  where heat_number=@heat_number order by pour_order desc"

        cmd.Parameters.AddWithValue("@heat_number", Val(heat_number))

        Try
            cmd.Connection.Open()

            Dim i As Integer = cmd.ExecuteScalar()

            Return i


        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally

            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing

        End Try

    End Function

    Private Sub GetNFData1()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            DataGrid1.DataSource = RWF.MLDING.getheatdata(CDate(txtDate.Text))
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    'Private Sub GetNFData1()
    '    DataGrid3.DataSource = Nothing
    '    DataGrid3.DataBind()
    '    Try
    '        DataGrid3.DataSource = RWF.MLDING.GetNFData1(CDate(txtDate.Text), rblShift.SelectedItem.Text)
    '        DataGrid3.DataBind()
    '    Catch exp As Exception
    '        lblMessage.Text = exp.Message
    '    End Try
    'End Sub

    Private Sub GetNFHeatData1()
        Dim dt As DataTable
        ' DataGrid1.DataSource = Nothing
        ' DataGrid1.DataBind()
        DataGrid2.DataSource = Nothing

        DataGrid2.DataBind()
        Try
            '    dt = RWF.MLDING.GetNFHeatData1(rblCold.SelectedIndex, (txtHeat.Text), CDate(txtDate.Text), rblShift.SelectedItem.Text)
            '    DataGrid1.DataSource = dt
            '    DataGrid1.DataBind()
            '    If dt.Rows.Count > 0 Then
            '        txtDate.Text = dt.Rows(0)("LoadDt")
            '        Dim i As Int16
            '        rblShift.ClearSelection()
            '        For i = 0 To rblShift.Items.Count - 1
            '            If rblShift.Items(i).Text = dt.Rows(0)("Sh") Then
            '                rblShift.Items(i).Selected = True
            '                Exit For
            '            End If
            '        Next
            '        i = Nothing
            '    End If
            DataGrid2.DataSource = RWF.MLDING.GetNFRemainingHeatWhls1(Val(txtHeat.Text))
            DataGrid2.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt = Nothing
        End Try
    End Sub
    'Private Sub GetNFData1()
    '    DataGrid1.DataSource = Nothing
    '    DataGrid1.DataBind()
    '    Try
    '        DataGrid1.DataSource = RWF.MLDING.GetNFData1(CDate(txtDate.Text), rblShift.SelectedItem.Text)
    '        DataGrid1.DataBind()
    '    Catch exp As Exception
    '        lblMessage.Text = exp.Message
    '    End Try
    'End Sub

    'Private Sub GetNFHeatData1()
    '    Dim dt As DataTable
    '    DataGrid1.DataSource = Nothing
    '    DataGrid1.DataBind()
    '    DataGrid2.DataSource = Nothing
    '    DataGrid2.DataBind()
    '    Try
    '        dt = RWF.MLDING.GetNFHeatData1(rblCold.SelectedIndex, (txtHeat.Text), CDate(txtDate.Text), rblShift.SelectedItem.Text)
    '        DataGrid1.DataSource = dt
    '        DataGrid1.DataBind()
    '        If dt.Rows.Count > 0 Then
    '            txtDate.Text = dt.Rows(0)("LoadDt")
    '            Dim i As Int16
    '            rblShift.ClearSelection()
    '            For i = 0 To rblShift.Items.Count - 1
    '                If rblShift.Items(i).Text = dt.Rows(0)("Sh") Then
    '                    rblShift.Items(i).Selected = True
    '                    Exit For
    '                End If
    '            Next
    '            i = Nothing
    '        End If
    '        DataGrid2.DataSource = RWF.MLDING.GetNFRemainingHeatWhls(Val(txtHeat.Text))
    '        DataGrid2.DataBind()
    '    Catch exp As Exception
    '        lblMessage.Text = exp.Message
    '    Finally
    '        dt = Nothing
    '    End Try
    'End Sub
    'Private Sub SetFocus(ByVal ctrl As Control)
    '    Dim focusScript As String = "<script language=" & "javascript" & " > " &
    '    "document.getElementById('" + ctrl.ClientID.ToString.Trim &
    '    "').focus();</script>"
    '    ClientScript.RegisterStartupScript(GetType(WheelNF), "FocusScript", focusScript)
    'End Sub


    Private Sub txtHeat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHeat.TextChanged
        lblMessage.Text = ""
        txtWheel.Text = ""


        If Val(txtHeat.Text) > 0 Then

            GetNFData1()
            GetNFHeatData1()

            If Val(txtWheel.Text) > 0 Then
                CheckWheel()

            Else


                SetFocus(txtWheel)
            End If
        Else
            SetFocus(txtWheel)
        End If
        sFormat.ShortDatePattern = "dd-MM-yyyy"
        txtDate.Text = Format(Convert.ToDateTime(Now.Date, sFormat), "dd-MM-yyyy")
    End Sub


    Private Sub txtWheel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWheel.TextChanged
        lblMessage.Text = ""
        txtSrNo.Text = ""
        'txtRemarks.Text = ""
        If Val(txtWheel.Text) > 0 Then
            If Val(txtHeat.Text) > 0 Then
                CheckWheel()
                'GetNFHeatData1()
                ' GetNFData1()
            Else
                SetFocus(txtHeat)
            End If
        Else
            SetFocus(txtHeat)
        End If
    End Sub

    Private Sub CheckWheel()
        Try
            If RWF.MLDING.CheckWheel(Val(txtWheel.Text), Val(txtHeat.Text)) Then
                lblSl_No.Text = ""
                GetWheelData1()
                SetFocus(txtSrNo)
            Else
                lblMessage.Text = "InValid Wheel/Heat Number !"
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub GetWheelData1()
        Dim dt As DataTable
        Try
            dt = RWF.MLDING.GetWheelData1(Val(txtWheel.Text), Val(txtHeat.Text), CDate(txtDate.Text), rblShift.SelectedItem.Text)
            If dt.Rows.Count > 0 Then
                txtOperator.Text = IIf(IsDBNull(dt.Rows(0)("operator_code")), "", dt.Rows(0)("operator_code"))
                txtShiftInC.Text = IIf(IsDBNull(dt.Rows(0)("supervisor")), "", dt.Rows(0)("supervisor"))
                txtSrNo.Text = IIf(IsDBNull(dt.Rows(0)("wheel_sr_no")), "", dt.Rows(0)("wheel_sr_no"))
                'txtOffLoad.Text = IIf(IsDBNull(dt.Rows(0)("offload_code")), "", dt.Rows(0)("offload_code"))
                'txtQuencher.Text = IIf(IsDBNull(dt.Rows(0)("quenched_number")), "", dt.Rows(0)("quenched_number"))
                'txTemp.Text = IIf(IsDBNull(dt.Rows(0)("temperature_on_discharge")), "", dt.Rows(0)("temperature_on_discharge"))
                'txtQDuration.Text = IIf(IsDBNull(dt.Rows(0)("quenching_duration")), "", dt.Rows(0)("quenching_duration"))
                'txtHCDuration.Text = IIf(IsDBNull(dt.Rows(0)("hubcooling_duration")), "", dt.Rows(0)("hubcooling_duration"))
                'txtRemarks.Text = IIf(IsDBNull(dt.Rows(0)("remarks")), "", dt.Rows(0)("remarks"))
                lblSl_No.Text = IIf(IsDBNull(dt.Rows(0)("Sl_No")), 0, dt.Rows(0)("Sl_No"))
                'Try
                '    txtInDate.Text = IIf(IsDBNull(dt.Rows(0)("charge_in_time")), Now.Date, CDate(dt.Rows(0)("charge_in_time")).ToShortDateString)
                '    txtInTime.Text = Right(("0" + CDate(dt.Rows(0)("charge_in_time")).Hour.ToString), 2) + ":" + Right(("0" + CDate(dt.Rows(0)("charge_in_time")).Minute.ToString), 2)
                'Catch exp As Exception
                '    txtInDate.Text = Now.Date
                '    txtInTime.Text = "00:00"
                'End Try
                'Try
                '    txtOutDate.Text = IIf(IsDBNull(dt.Rows(0)("charge_out_time")), Now.Date, CDate(dt.Rows(0)("charge_out_time")).ToShortDateString)
                '    txtOutTime.Text = Right(("0" + CDate(dt.Rows(0)("charge_out_time")).Hour.ToString), 2) + ":" + Right(("0" + CDate(dt.Rows(0)("charge_out_time")).Minute.ToString), 2)
                'Catch exp As Exception
                '    txtOutDate.Text = Now.Date
                '    txtOutTime.Text = "00:00"
                'End Try
            Else
                lblSl_No.Text = 0
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        dt = Nothing
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        If Not RWF.MLDING.CheckWheel(Val(txtWheel.Text), Val(txtHeat.Text)) Then
            lblMessage.Text = "InValid Wheel/Heat Number !"
            Exit Sub
        End If
        Dim NF As New RWF.MLDING()
        Dim done As Boolean
        Dim Charge, DisCharge As Date
        Charge = CDate(Now.Date)
        DisCharge = Now.Date
        'Try
        '    Charge = CDate(txtInDate.Text + " " & txtInTime.Text)
        'Catch exp As Exception
        '    Charge = Now.Date
        'End Try
        'Try
        '    DisCharge = CDate(txtOutDate.Text + " " & txtOutTime.Text)
        'Catch exp As Exception
        '    DisCharge = Now.Date
        'End Try
        Dim Cold As Integer
        If rblCold.SelectedItem.Text.StartsWith("R") Then
            Cold = 0
        Else
            Cold = 1
        End If
        Try
            done = NF.WheelNFLoading1(CDate(txtDate.Text), rblShift.SelectedItem.Text, txtOperator.Text, txtShiftInC.Text, CInt(txtWheel.Text), CLng(txtHeat.Text), CInt(txtSrNo.Text), Cold, CInt(txtpour.Text), CInt(lblsrbit.Text), CInt(Val(lblSl_No.Text)))
            'done = NF.WheelNFLoading(Format(CDate(txtdate.Text), "MM/dd/yyyy"), rblShift.SelectedItem.Text, txtOperator.Text, txtShiftInC.Text, CInt(txtWheel.Text), CLng(txtHeat.Text), txtSrNo.Text.Trim, Charge, DisCharge, 0, 0, 0, txtRemarks.Text.Trim, 0, 0, Cold, Val(lblSl_No.Text))
            'done = NF.WheelNFLoading(Format(CDate(txtdate.Text), "MM/dd/yyyy"), rblShift.SelectedItem.Text, txtOperator.Text, txtShiftInC.Text, CInt(txtWheel.Text), CLng(txtHeat.Text), txtSrNo.Text.Trim, Charge, DisCharge, txtOffLoad.Text.Trim, txtQuencher.Text.Trim, Val(txTemp.Text), txtRemarks.Text.Trim, txtQDuration.Text, txtHCDuration.Text, Cold, Val(lblSl_No.Text))
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        'sFormat.ShortDatePattern = "dd-MM-yyyy"
        'txtDate.Text = Format(Convert.ToDateTime(Now.Date, sFormat), "dd-MM-yyyy")
        If done Then
            Try
                GetNFHeatData1()
                GetNFData1()
                lblMessage.Text = "Successfully Saved !"
            Catch exp As Exception
                lblMessage.Text &= exp.Message
            End Try
            txtWheel.Text = ""
            SetFocus(txtWheel)
        End If
        NF = Nothing
        done = Nothing
        Charge = Nothing
        DisCharge = Nothing
        clear_data()

        sFormat.ShortDatePattern = "dd-MM-yyyy"
        txtDate.Text = Format(Convert.ToDateTime(Now.Date, sFormat), "dd-MM-yyyy")
        incr_srno()
        If rblCold.SelectedItem.Text = "Regular" Then

            getwheel()
        End If


    End Sub

    Dim in_srno As Integer
    Private Sub incr_srno()
        'sFormat.ShortDatePattern = "MM/dd/yyyy"
        'txtDate.Text = Format(Convert.ToDateTime(Now.Date, sFormat), "MM/dd/yyyy")
        Try
            cmd.Connection.Open()
            cmd.CommandText = "select top(1) wheel_sr_no from mm_nf_loading order by Sl_No desc,loading_date desc "
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            dr.Read()
            If Not dr.HasRows() Then
                in_srno = 1
            Else
                txtSrNo.Text = dr("wheel_sr_no").ToString()
                Int32.TryParse(txtSrNo.Text, in_srno)
                in_srno = in_srno + 1
            End If

            txtSrNo.Text = in_srno.ToString()
            dr.Close()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            cmd.Connection.Close()
        End Try
    End Sub

    Private Sub clear_data()
        'txtOperator.Text = ""
        'txtShiftInC.Text = ""
        'txtHeat.Text = ""
        txtWheel.Text = ""
        'txtSrNo.Text = ""
        'txtRemarks.Text = ""
        'getsrno()
    End Sub

    Dim i As Integer
    Protected Sub DataGrid2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DataGrid2.SelectedIndexChanged
        DataGrid2.SelectedIndex = i
        txtHeat.Text = DataGrid2.Items(i).Cells(2).Text
        txtWheel.Text = DataGrid2.Items(i).Cells(3).Text
    End Sub

    Protected Sub DataGrid2_ItemCommand(source As Object, e As DataGridCommandEventArgs) Handles DataGrid2.ItemCommand
        i = e.Item.ItemIndex()
    End Sub

    Protected Sub rblCold_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblCold.SelectedIndexChanged
        If rblCold.SelectedItem.Text = "Regular" Then

            getwheel()
        ElseIf rblCold.SelectedItem.Text = "Cold" Then
            txtpour.Visible = False

        End If

    End Sub
    Protected Sub OnItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            CType(e.Item.FindControl("lblRowNumber"), Label).Text = (e.Item.ItemIndex + 1).ToString()
        End If
    End Sub

    Protected Sub txtSrNo_TextChanged(sender As Object, e As EventArgs) Handles txtSrNo.TextChanged

    End Sub

    Protected Sub addsrno_Click(sender As Object, e As EventArgs) Handles addsrno.Click

    End Sub
End Class
