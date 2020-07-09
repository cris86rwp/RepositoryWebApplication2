Imports System.Data
Imports System.Data.SqlClient


Public Class WheelNormalising
    Inherits System.Web.UI.Page
    'Protected WithEvents dgData4 As System.Web.UI.WebControls.DataGrid
    'Protected WithEvents dgData3 As System.Web.UI.WebControls.DataGrid
    'Protected WithEvents dgData2 As System.Web.UI.WebControls.DataGrid
    'Protected WithEvents dgData1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents rblShift As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents pnlMain As System.Web.UI.WebControls.Panel
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lbl_wheel As System.Web.UI.WebControls.Label
    Protected WithEvents txtOP1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDt As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRQ As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtHeatNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWheelNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPedestial As System.Web.UI.WebControls.TextBox
    'Protected WithEvents lblPedestial As System.Web.UI.WebControls.Label
    Protected WithEvents txtStTimeMM As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtStTimeHH As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSup As System.Web.UI.WebControls.TextBox
    'Protected WithEvents lblDate As System.Web.UI.WebControls.Label
    Protected WithEvents rblMcnList As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents rblPos As System.Web.UI.WebControls.RadioButtonList
    'Protected WithEvents lblPosition As System.Web.UI.WebControls.Label
    'Protected WithEvents lblDescriptionC As System.Web.UI.WebControls.Label
    'Protected WithEvents lblTempatRQ As System.Web.UI.WebControls.Label
    'Protected WithEvents lblDescriptionD As System.Web.UI.WebControls.Label
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    'Protected WithEvents lblW As System.Web.UI.WebControls.Label
    'Protected WithEvents lblH As System.Web.UI.WebControls.Label
    Protected WithEvents lblSlNo As System.Web.UI.WebControls.Label
    Protected WithEvents lblDesC As System.Web.UI.WebControls.Label
    'Protected WithEvents lblDesD As System.Web.UI.WebControls.Label
    Protected WithEvents chkCW As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkRW As System.Web.UI.WebControls.CheckBox
    Protected WithEvents btnClear As System.Web.UI.WebControls.Button
    Protected WithEvents btnScore As System.Web.UI.WebControls.Button
    ' Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    'Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dg_insert As System.Web.UI.WebControls.DataGrid
    Protected WithEvents rfv1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents rfv2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents rfv3 As System.Web.UI.WebControls.RequiredFieldValidator
    'Protected WithEvents DataGrid3 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtOP2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList

    Private sqlstr As String
    'Dim aa As Integer
    'Dim hno As Integer
    Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
    'Public con As New SqlConnection(ConfigurationManager.AppSettings("con"))

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
        'aa = Autogenerate_idd()
        'lblSlNo.Text=aa
        lblSlNo.Visible = False
        If IsPostBack = False Then
            txtDt.Text = Now.Date
            Try
                txtHeatNo.Text = RWF.Tables.GetLatestPrePourHeat - 1
                'hno = Val(txtHeatNo.Text)
                txtStTimeHH.Text = Right("0" + CStr(Now.Hour), 2)
                txtStTimeMM.Text = Right("0" + CStr(Now.Minute), 2)
                'GetWheels()
                Dim ds As New DataSet()
                ds = HotWheelLine1.PopulateDdls(1)
                rblMcnList.DataSource = ds.Tables(0).DefaultView
                rblMcnList.DataTextField = "Machine_code"
                rblMcnList.DataValueField = "Machine_code"
                rblMcnList.DataBind()
                rblMcnList.SelectedIndex = 0
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            SetFocus(txtHeatNo)
        End If
    End Sub

    Private Sub SetFocus(ByVal ctrl As Control)
        Dim focusScript As String = "<script language=" & "javascript" & " > " &
        "document.getElementById('" + ctrl.ClientID.ToString.Trim &
        "').focus();</script>"
        ClientScript.RegisterStartupScript(GetType(WheelNormalising), "FocusScript", focusScript)
    End Sub

    'Private Function GetWheels(ByVal Heat As Double, ByVal Type As Int16) As DataTable
    '    Dim dt As New DataTable()
    '    Try
    '        dt = RWF.MLDING.GetNFWheels_rim(Heat, Type)
    '        Return dt
    '    Catch exp As Exception
    '        lblMessage.Text = exp.Message
    '    End Try
    'End Function

    'Private Sub Clear()
    '    dgData1.SelectedIndex = -1
    '    dgData2.SelectedIndex = -1
    '    dgData3.SelectedIndex = -1
    '    dgData4.SelectedIndex = -1
    '    DataGrid2.DataSource = Nothing
    '    DataGrid2.DataBind()
    'End Sub

    'Private Sub GetWheels()
    '    Clear()
    '    Dim dtHeat As DataTable
    '    Try
    '        dtHeat = GetWheels(Val(txtHeatNo.Text), 0)
    '        dgData1.DataSource = dtHeat
    '        dgData1.DataBind()
    '        Dim A As Int16
    '        For A = 0 To dtHeat.Rows.Count - 1
    '            If Not IsDBNull(dtHeat.Rows(A)("WheelNo")) Then
    '                If dtHeat.Rows(A)("WheelNo") = dgData1.Items(A).Cells(1).Text Then
    '                    dgData1.Items(A).Cells(1).BackColor = System.Drawing.Color.Pink
    '                    dgData1.Items(A).Cells(0).BackColor = System.Drawing.Color.Pink
    '                    dgData1.Items(A).Cells(0).Enabled = False
    '                End If
    '            End If
    '        Next
    '        dtHeat = GetWheels(Val(txtHeatNo.Text), 1)
    '        A = 0
    '        If dtHeat.Rows.Count > 1 Then
    '            dgData2.DataSource = dtHeat
    '            dgData2.DataBind()
    '            For A = 0 To dtHeat.Rows.Count - 1
    '                If Not IsDBNull(dtHeat.Rows(A)("WheelNo")) Then
    '                    If dtHeat.Rows(A)("WheelNo") = dgData2.Items(A).Cells(1).Text Then
    '                        dgData2.Items(A).Cells(1).BackColor = System.Drawing.Color.Pink
    '                        dgData2.Items(A).Cells(0).BackColor = System.Drawing.Color.Pink
    '                        dgData2.Items(A).Cells(0).Enabled = False
    '                    End If
    '                End If
    '            Next
    '        End If
    '        dtHeat = GetWheels(Val(txtHeatNo.Text), 2)
    '        dgData3.DataSource = dtHeat
    '        dgData3.DataBind()
    '        A = 0
    '        For A = 0 To dtHeat.Rows.Count - 1
    '            If Not IsDBNull(dtHeat.Rows(A)("WheelNo")) Then
    '                If dtHeat.Rows(A)("WheelNo") = dgData3.Items(A).Cells(1).Text Then
    '                    dgData3.Items(A).Cells(1).BackColor = System.Drawing.Color.Pink
    '                    dgData3.Items(A).Cells(0).BackColor = System.Drawing.Color.Pink
    '                    dgData3.Items(A).Cells(0).Enabled = False
    '                End If
    '            End If
    '        Next
    '        dtHeat = GetWheels(Val(txtHeatNo.Text), 3)
    '        A = 0
    '        If dtHeat.Rows.Count > 1 Then
    '            dgData4.DataSource = dtHeat
    '            dgData4.DataBind()
    '            For A = 0 To dtHeat.Rows.Count - 1
    '                If Not IsDBNull(dtHeat.Rows(A)("WheelNo")) Then
    '                    If dtHeat.Rows(A)("WheelNo") = dgData4.Items(A).Cells(1).Text Then
    '                        dgData4.Items(A).Cells(1).BackColor = System.Drawing.Color.Pink
    '                        dgData4.Items(A).Cells(0).BackColor = System.Drawing.Color.Pink
    '                        dgData4.Items(A).Cells(0).Enabled = False
    '                    End If
    '                End If
    '            Next
    '        End If
    '        DataGrid2.DataSource = RWF.MLDING.GetNFHeatWheels(Val(txtHeatNo.Text))
    '        DataGrid2.DataBind()
    '    Catch exp As Exception
    '        lblMessage.Text = exp.Message
    '    End Try
    'End Sub

    Private Sub txtHeatNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHeatNo.TextChanged
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        lblMessage.Text = ""
        Try
            cmd.Connection.Open()
            cmd.CommandText = "select heat_number from mm_pouring where heat_number='" & txtHeatNo.Text & "'"
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            If Not dr.HasRows Then
                lblMessage.Text = "Invalid Heat No.!!!"
                'txtHeatNo.Text = ""
            End If
            dr.Close()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            cmd.Connection.Close()
        End Try
        'lblMessage.Text = ""
        txtWheelNo.Text = ""
        lblDesC.Text = ""
        txtPedestial.Text = ""
        ClearT()
        'ClearD()
        'If txtHeatNo.Text IsNot hno.ToString() Then
        '    hno = Val(txtHeatNo.Text)
        '    aa = Autogenerate_idd()
        '    'Autogenerate_idd()
        '    lblSlNo.Text = aa
        'End If
        'GetWheels()
    End Sub

    'Private Sub dgData1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgData1.ItemCommand
    '    dgData2.SelectedIndex = -1
    '    dgData3.SelectedIndex = -1
    '    dgData4.SelectedIndex = -1
    '    Select Case e.CommandName
    '        Case "Select"
    '            txtWheelNo.Text = e.Item.Cells(1).Text
    '            lblDesC.Text = e.Item.Cells(2).Text
    '            SetFocus(txtPedestial)
    '    End Select
    'End Sub

    'Private Sub dgData2_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgData2.ItemCommand
    '    dgData1.SelectedIndex = -1
    '    dgData3.SelectedIndex = -1
    '    dgData4.SelectedIndex = -1
    '    Select Case e.CommandName
    '        Case "Select"
    '            txtWheelNo.Text = e.Item.Cells(1).Text
    '            lblDesC.Text = e.Item.Cells(2).Text
    '            SetFocus(txtPedestial)
    '    End Select
    'End Sub

    'Private Sub dgData3_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgData3.ItemCommand
    '    dgData1.SelectedIndex = -1
    '    dgData2.SelectedIndex = -1
    '    dgData4.SelectedIndex = -1
    '    Select Case e.CommandName
    '        Case "Select"
    '            txtWheelNo.Text = e.Item.Cells(1).Text
    '            lblDesC.Text = e.Item.Cells(2).Text
    '            SetFocus(txtPedestial)
    '    End Select
    'End Sub

    'Private Sub dgData4_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgData4.ItemCommand
    '    dgData1.SelectedIndex = -1
    '    dgData2.SelectedIndex = -1
    '    dgData3.SelectedIndex = -1
    '    Select Case e.CommandName
    '        Case "Select"
    '            txtWheelNo.Text = e.Item.Cells(1).Text
    '            lblDesC.Text = e.Item.Cells(2).Text
    '            SetFocus(txtPedestial)
    '    End Select
    'End Sub


    'Public Function Autogenerate_idd()
    '    Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
    '    cmd.Connection.Open()
    '    Dim number As Integer
    '    cmd.CommandText = "Select Max(SlNo) from mm_WheelNormalising where HeatNo='" & hno & "'"
    '    'cmd.ExecuteNonQuery()

    '    If IsDBNull(cmd.ExecuteScalar) Then
    '        number = 1
    '        Return number
    '        'lblSlNo.Text = number
    '    Else
    '        number = (cmd.ExecuteScalar) + 1
    '        Return number
    '        'lblSlNo.Text = number
    '    End If
    '    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
    '    cmd.Dispose()
    '    cmd.Connection.Dispose()
    'End Function


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim dtStart As Date
        'Dim dtStart, dtDisCharge As Date
        lblMessage.Text = ""
        If Val(txtPedestial.Text) < 1 OrElse Val(txtPedestial.Text) > 48 Then
            lblMessage.Text = "InValid Pedestial No !"
            Exit Sub
        End If
        Dim Quencher As String
        Quencher = rblMcnList.SelectedValue.ToString()
        Try
            dtStart = CDate(txtDt.Text + " " + Right("00" + txtStTimeHH.Text, 2) + ":" + Right("00" + txtStTimeMM.Text, 2))
        Catch exp As Exception
            dtStart = Now.Date
        End Try
        'If Val(lblW.Text) > 0 Then
        '    dtDisCharge = dtStart
        'End If

        Dim done, charge, discharge As Boolean
        Try
            If Val(txtWheelNo.Text) > 0 Then
                done = New RWF1.MLDING1().WheelNormalising1(Val(txtHeatNo.Text), Val(txtWheelNo.Text), txtSup.Text.Trim, txtOP1.Text.Trim, txtOP2.Text.Trim, Val(txtPedestial.Text), txtRQ.Text, rblPos.SelectedItem.Text, dtStart, "1900-01-01", "", txtRemarks.Text.Trim)
                'done = New RWF.MLDING().WheelNormalising1(Val(txtHeatNo.Text), Val(txtWheelNo.Text), txtSup.Text.Trim, txtOP1.Text.Trim, txtOP2.Text.Trim, Val(txtPedestial.Text), txtRQ.Text, rblPos.SelectedItem.Text, dtStart, "1900-01-01", "", txtRemarks.Text.Trim, Val(lblSlNo.Text))
                'done = New RWF.MLDING().WheelNormalising(Val(txtHeatNo.Text), Val(txtWheelNo.Text), txtSup.Text.Trim, txtOP1.Text.Trim, txtOP2.Text.Trim, Val(txtPedestial.Text), rblPos.SelectedItem.Text, dtStart, "1900-01-01", "", txtRemarks.Text.Trim)
                charge = True
            End If
            'If Val(lblW.Text) > 0 Then
            '    done = New RWF.MLDING().WheelNormalisingPre1(Val(lblH.Text), Val(lblW.Text), txtSup.Text.Trim, txtOP1.Text.Trim, txtOP2.Text.Trim, Val(lblPedestial.Text), lblTempatRQ.Text, lblPosition.Text.Trim, CDate(lblDate.Text), dtDisCharge, rblMcnList.SelectedItem.Text, txtRemarks.Text.Trim, Val(lblSlNo.Text))
            '    discharge = True
            'End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If done Then
            'GetWheels()
            'GetScore()
            chkCW.Checked = False
            chkRW.Checked = False
            txtWheelNo.Text = ""
            lblDesC.Text = ""
            txtPedestial.Text = ""
            'ClearD()
            Try
                dtStart = dtStart.AddMinutes(2)
                txtDt.Text = dtStart.Date
                txtStTimeHH.Text = Right("0" + CStr(dtStart.Hour), 2)
                txtStTimeMM.Text = Right("0" + CStr(dtStart.Minute), 2)
            Catch exp As Exception
                dtStart = Now.Date
            End Try
        End If
        If charge AndAlso discharge Then
            lblMessage.Text &= " Both Charging & Dis-Charging data Saved !"
        ElseIf charge AndAlso discharge = False Then
            lblMessage.Text &= " Dis-Charging data Saved !"
            show_data()
            'Dim sqlstr As String
            'sqlstr = "select * from mm_WheelNormalising"
            'Call BindDataGrid(sqlstr)

        ElseIf charge = False AndAlso discharge Then
            lblMessage.Text &= " Charging data Saved !"
        End If
    End Sub

    Private Sub show_data()
        Try
            cmd.Connection.Open()
            cmd.CommandText = "select HeatNo, WheelNo, SIC,OP1,OP2,PedNo,TempRQ,PedPosition,TimeIn,TimeOut,Quencher,remarks from mm_WheelNormalising"
            Using sda As New SqlDataAdapter()
                sda.SelectCommand = cmd
                Using dt As New DataSet()
                    sda.Fill(dt)
                    dg_insert.DataSource = dt
                    dg_insert.DataBind()
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            cmd.Connection.Close()
        End Try
    End Sub

    'Private Sub BindDataGrid(ByVal strArg As String)

    '    Dim objCmd As SqlCommand
    '    Dim objDr As SqlDataReader

    '    If con.State = ConnectionState.Closed Then
    '        con.Open()
    '    Else
    '        con.Close()
    '        con.Open()
    '    End If
    '    Try
    '        objCmd = New SqlCommand(strArg, con)
    '        objDr = objCmd.ExecuteReader()
    '        Dim arr() As String
    '        dg_insert.DataSource = arr
    '        dg_insert.DataBind()
    '        dg_insert.DataSource = objDr
    '        dg_insert.DataBind()
    '    Catch exp As SqlException
    '        sqlstr = exp.StackTrace
    '        lblMessage.Text = "Line : " & Mid(sqlstr, InStr(sqlstr, "line") + 5) & " Message : " + exp.Message

    '    Catch exp As Exception
    '        sqlstr = exp.StackTrace
    '        lblMessage.Text = "Line : " & Mid(sqlstr, InStr(sqlstr, "line") + 5) & " Message : " + exp.Message
    '    End Try

    '    con.Close()

    'End Sub

    Private Sub txtPedestial_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPedestial.TextChanged
        lblMessage.Text = ""
        'ClearD()
        If Val(txtPedestial.Text) < 1 OrElse Val(txtPedestial.Text) > 48 Then
            lblMessage.Text = "InValid Pedestial No !"
            Exit Sub
        Else
            'GetDetails()
        End If
    End Sub

    'Private Sub GetDetails()
    '    Dim dt As DataTable
    '    dt = RWF.MLDING.GetPreNFWheel(Val(txtPedestial.Text), rblPos.SelectedItem.Text)
    '    If dt.Rows.Count > 0 Then
    '        lblH.Text = dt.Rows(0)("HeatNo")
    '        lblW.Text = dt.Rows(0)("WheelNo")
    '        lblPedestial.Text = dt.Rows(0)("PedNo")
    '        lblPosition.Text = dt.Rows(0)("PedPosition") '
    '        lblDesD.Text = dt.Rows(0)("wheel_type")
    '        lblDate.Text = dt.Rows(0)("TimeIn")
    '        lblSlNo.Text = dt.Rows(0)("SlNo")
    '    End If
    'End Sub

    'Private Sub ClearD()
    '    lblH.Text = ""
    '    lblW.Text = ""
    '    lblPedestial.Text = ""
    '    lblPosition.Text = ""
    '    lblDesD.Text = ""
    '    lblDate.Text = ""
    '    lblSlNo.Text = ""
    '    DataGrid1.DataSource = Nothing
    '    DataGrid1.DataBind()
    'End Sub

    Private Sub rblPos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblPos.SelectedIndexChanged
        lblMessage.Text = ""
        'ClearD()
        If Val(txtPedestial.Text) < 1 OrElse Val(txtPedestial.Text) > 48 Then
            lblMessage.Text = "InValid Pedestial No !"
            Exit Sub
        Else
            'GetDetails()
        End If
    End Sub

    Private Sub chkCW_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCW.CheckedChanged
        lblMessage.Text = ""
        If chkCW.Checked Then txtRemarks.Text &= " " & chkCW.Text
    End Sub

    Protected Sub chkRW_CheckedChanged(sender As Object, e As EventArgs) Handles chkRW.CheckedChanged
        lblMessage.Text = ""
        If chkRW.Checked Then txtRemarks.Text &= " " & chkRW.Text
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtWheelNo.Text = ""
        lblDesC.Text = ""
        txtPedestial.Text = ""
        'ClearD()
        ClearT()
    End Sub

    Private Sub ClearT()
        txtOP1.Text = ""
        txtOP2.Text = ""
        txtRemarks.Text = ""
        txtRQ.Text = ""
        txtSup.Text = ""
    End Sub


    Protected Sub txtWheelNo_TextChanged(sender As Object, e As EventArgs) Handles txtWheelNo.TextChanged
        checkwheels()

        'Try
        '    cmd.Connection.Open()
        '    cmd.CommandText = "SELECT wheel_type from mm_pouring where engraved_number= '" & txtWheelNo.Text & "'"
        '    Dim sdr As SqlDataReader
        '    sdr = cmd.ExecuteReader()
        '    sdr.Read()
        '    lblDesC.Text = sdr("wheel_type").ToString()
        '    sdr.Close()
        'Catch ex As Exception
        '    Throw New Exception(ex.Message)
        'Finally
        '    cmd.Connection.Close()
        'End Try

    End Sub

    Private Sub checkwheels()
        lblMessage.Text = ""
        Try
            cmd.Connection.Open()
            cmd.CommandText = "select * from mm_pouring where heat_number='" & txtHeatNo.Text & "' and engraved_number='" & txtWheelNo.Text & "'"
            Dim reader As SqlDataReader
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                cmd.CommandText = "SELECT wheel_type from mm_pouring where engraved_number= '" & txtWheelNo.Text & "'"
                reader.Read()
                lblDesC.Text = reader("wheel_type").ToString()
            Else
                lblMessage.Text = "Invalid Wheel No.!!!"
                txtWheelNo.Text = ""
            End If
            reader.Close()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            cmd.Connection.Close()
        End Try
        ifWheelExist()
    End Sub

    Private Sub ifWheelExist()
        lbl_wheel.Text = ""
        Try
            cmd.Connection.Open()
            cmd.CommandText = "select WheelNo from mm_WheelNormalising where HeatNo='" & txtHeatNo.Text & "' and WheelNo='" & txtWheelNo.Text & "'"
            Dim reader As SqlDataReader
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                lbl_wheel.Text = "Wheel No. already exist!!!"
                txtWheelNo.Text = ""
                lblDesC.Text = ""
            End If
            reader.Close()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            cmd.Connection.Close()
        End Try
    End Sub


    'Private Sub txtDt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDt.TextChanged
    '    DataGrid1.DataSource = Nothing
    '    DataGrid1.DataBind()
    '    SetFocus(txtStTimeHH)
    'End Sub

    'Private Sub txtStTimeHH_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStTimeHH.TextChanged
    '    DataGrid1.DataSource = Nothing
    '    DataGrid1.DataBind()
    '    SetFocus(txtStTimeMM)
    'End Sub

    'Private Sub txtStTimeMM_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStTimeMM.TextChanged
    '    DataGrid1.DataSource = Nothing
    '    DataGrid1.DataBind()
    '    SetFocus(rblMcnList)
    'End Sub

    'Private Sub btnScore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScore.Click
    '    GetScore()
    'End Sub

    'Private Sub GetScore()
    '    Dim dtStart As Date
    '    Dim Sh As String
    '    Try
    '        dtStart = CDate(txtDt.Text + " " + Right("00" + txtStTimeHH.Text, 2) + ":" + Right("00" + txtStTimeMM.Text, 2))
    '    Catch exp As Exception
    '        dtStart = Now.Date
    '    End Try
    '    Select Case dtStart.Hour
    '        Case 6 To 13
    '            Sh = "A"
    '            dtStart = CDate(txtDt.Text)
    '        Case 14 To 21
    '            Sh = "B"
    '            dtStart = CDate(txtDt.Text)
    '        Case Else
    '            Sh = "C"
    '            dtStart = CDate(txtDt.Text).AddDays(1)
    '    End Select
    '    Dim ds As New DataSet()
    '    Try
    '        ds = RWF.MLDING.GetNFScore(dtStart, Sh)
    '        DataGrid1.DataSource = ds.Tables(0)
    '        DataGrid1.DataBind()
    '        DataGrid3.DataSource = ds.Tables(1)
    '        DataGrid3.DataBind()
    '    Catch exp As Exception
    '        lblMessage.Text = exp.Message
    '    End Try
    'End Sub




End Class
