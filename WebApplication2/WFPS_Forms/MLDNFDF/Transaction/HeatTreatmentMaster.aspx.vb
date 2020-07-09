Imports System.Data.SqlClient
Imports System.Data

Public Class HeatTreatmentMaster
    Inherits System.Web.UI.Page
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents TxtDate As System.Web.UI.WebControls.TextBox
    'Protected WithEvents TxtTime As System.Web.UI.WebControls.TextBox
    Protected WithEvents DDLshift As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtSrNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtOperator As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtHeat_No As System.Web.UI.WebControls.TextBox
    Protected WithEvents DDLWheelNo As System.Web.UI.WebControls.DropDownList
    'Protected WithEvents DDLWhlStatus As System.Web.UI.WebControls.DropDownList
    Protected WithEvents TxtBatchNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblSl_No As System.Web.UI.WebControls.Label
    Protected WithEvents BtnSave As System.Web.UI.WebControls.Button
    Protected WithEvents BtnClear As System.Web.UI.WebControls.Button
    Protected WithEvents BtnExit As System.Web.UI.WebControls.Button
    Protected WithEvents addsrno As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Dim sFormat As System.Globalization.DateTimeFormatInfo = New System.Globalization.DateTimeFormatInfo()
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
        incr_batchsrno()

        If Page.IsPostBack = False Then
            Try
                GetBatchwheel()
                getDateShift()
                GetBatchwheel()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub



    Protected Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim Done As Boolean
        Try
            Done = Save()
        Catch exp As Exception
            Label1.Text = exp.Message
        End Try
        If Done Then
            Label1.Text = "insertion is successfully"
        End If

    End Sub

    Public Function Save()
        Dim done As Boolean
        'Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Dim cmd1 As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        'cmd.CommandText = "Insert INTO mm_wheel_heat_treatment_summary (heat_treatment_date,shift_code,operator_code, heat_no, wheel_number, batch_no, remark) 
        '                    VALUES ('" & Format(CDate(TxtDate.Text), "MM/dd/yyyy") & "', '" & DDLshift.SelectedItem.Value & "' , '" & TxtOperator.Text & "','" & TxtHeat_No.Text & "', 				 
        ''" & DDLWheelNo.SelectedItem.Value & "','" & TxtBatchNo.Text & "','" & TxtRemarks.Text & "')"

        cmd1.CommandText = "Insert INTO mm_wheel_heat_batch_details (HTBatch_Date,Shift_Code,Batch_Operator, Batch_No,Batch_SrNo, Heat_No, Wheel_Number,Remark) 
                         VALUES ('" & Format(CDate(TxtDate.Text), "MM/dd/yyyy") & "', '" & DDLshift.SelectedItem.Value & "' , '" & TxtOperator.Text & "','" & TxtBatchNo.Text & "','" & txtSrNo.Text & "','" & TxtHeat_No.Text & "', 				 
				 '" & DDLWheelNo.SelectedItem.Value & "','" & TxtRemarks.Text & "')"

        'Try
        '    cmd.Connection.Open()
        '    If cmd.ExecuteNonQuery() = 1 Then done = True
        'Catch exp As Exception
        '    Throw New Exception(exp.Message)
        'Finally
        '    If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
        '    cmd.Dispose()
        '    cmd = Nothing
        'End Try
        'Return done
        Try
            cmd1.Connection.Open()
            If cmd1.ExecuteNonQuery() = 1 Then done = True
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            If cmd1.Connection.State = ConnectionState.Open Then cmd1.Connection.Close()
            cmd1.Dispose()
            cmd1 = Nothing
        End Try
        Return done
        incr_batchsrno()
        GetBatchwheel()
    End Function

    Private Sub GetBatchData()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            DataGrid1.DataSource = RWF.MLDING.GetMasterBatchData(Val(TxtBatchNo.Text))
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Protected Sub Btnclear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        TxtDate.Text = ""
        'TxtOperator.Text = ""
        TxtBatchNo.Text = ""
        TxtHeat_No.Text = ""
        'TxtTime.Text = ""
        txtSrNo.Text = ""
        TxtRemarks.Text = ""
        Label1.Text = ""
        'lblSl_No.Text = ""
        TxtBatchNo.Text = ""
    End Sub

    Public Function GetBatchwheel()
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.Connection.Open()
        Dim heat As Integer = Val(TxtHeat_No.Text)
        cmd.CommandText = "Select Wheel_number from mm_draw_furnace_details  where heat_number =@heat and ht_status='PASS' "
        cmd.Parameters.AddWithValue("@heat", heat)
        'cmd.ExecuteScalar()
        DDLWheelNo.DataSource = cmd.ExecuteReader()
        DDLWheelNo.DataTextField = "Wheel_number"
        DDLWheelNo.DataBind()
    End Function

    Private Sub incr_batchsrno()
        sFormat.ShortDatePattern = "MM/dd/yyyy"
        Dim in_srno As Integer
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        TxtDate.Text = Format(Convert.ToDateTime(Now.Date, sFormat), "MM/dd/yyyy")
        Try
            cmd.Connection.Open()
            cmd.CommandText = "select  * from mm_wheel_heat_batch_details order by Batch_SrNo desc"
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            dr.Read()
            Dim ld As Date = dr("HTBatch_Date").ToString()
            'lblMessage.Text = ld.ToString()
            If dr.HasRows() Then
                cmd.CommandText = "select top(1) Batch_SrNo from mm_wheel_heat_batch_details where loading_date=@ld"
                'dr.Read()
                txtSrNo.Text = dr("Batch_SrNo").ToString()
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

    Private Sub getsrno()
        Dim srno As Integer
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        sFormat.ShortDatePattern = "MM/dd/yyyy"
        TxtDate.Text = Format(Convert.ToDateTime(Now.Date, sFormat), "MM/dd/yyyy")
        Try
            cmd.Connection.Open()
            cmd.CommandText = "Select top(1) Batch_SrNo from mm_wheel_heat_batch_details order by Batch_No desc"
            Dim srn As SqlDataReader
            srn = cmd.ExecuteReader()
            srn.Read()
            txtSrNo.Text = srn("Batch_SrNo").ToString()
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

    Protected Sub addsrno_Click(sender As Object, e As EventArgs) Handles addsrno.Click
        Dim sr As Integer
        Dim res As MsgBoxResult = MsgBox("Want to reset Sr no ??", MsgBoxStyle.YesNo Or MsgBoxStyle.Question Or MsgBoxStyle.DefaultButton2, "Reset Sr No")

        If res = MsgBoxResult.Yes Then
            'lblMessage.Text = "ok"
            sr = 1
            txtSrNo.Text = sr.ToString()
            Exit Sub
        End If
        If res = MsgBoxResult.No Then
            'lblMessage.Text = "no"
            getsrno()
            Exit Sub
        End If
        lblMessage.Text = "ext sub"
    End Sub

    Public Sub getDateShift()
        TxtDate.AutoPostBack = False
        If Now.Hour = 0 OrElse Now.Hour = 1 OrElse Now.Hour = 2 OrElse Now.Hour = 3 OrElse Now.Hour = 4 OrElse Now.Hour = 5 Then

            TxtDate.Text = Format(CDate(Now.Date.AddDays(-1)), "dd-MM-yyyy")
            'Now.Date.AddDays(-1)
        Else
            TxtDate.Text = Format(CDate(Now.Date), "dd-MM-yyyy")
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
        DDLshift.ClearSelection()
        For i = 0 To DDLshift.Items.Count - 1
            If DDLshift.Items(i).Text = Shift Then
                DDLshift.Items(i).Selected = True
                Exit For
            End If
        Next
        dt = Nothing

        Shift = Nothing
        i = Nothing
    End Sub
    Protected Sub TxtHeat_No_TextChanged(sender As Object, e As EventArgs) Handles TxtHeat_No.TextChanged
        GetBatchwheel()
    End Sub

End Class
