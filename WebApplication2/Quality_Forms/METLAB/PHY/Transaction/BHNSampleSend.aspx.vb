Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient

Public Class BHNSampleSend
    Inherits System.Web.UI.Page
    Protected WithEvents lblFrom As System.Web.UI.WebControls.Label
    Protected WithEvents lblMode As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents btnExit As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
    Protected WithEvents btnSubmit_Clicks As System.Web.UI.WebControls.Button
    Public cnn As New SqlConnection(ConfigurationSettings.AppSettings("con"))
    Protected WithEvents lblTo As System.Web.UI.WebControls.Label
    Protected WithEvents RangeValidator1 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents grdReadings As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblLab As System.Web.UI.WebControls.Label
    Protected WithEvents lblLab_Number As System.Web.UI.WebControls.Label
    Protected WithEvents txtHeatFrom As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtHeatTo As System.Web.UI.WebControls.TextBox
    Dim strCmd, strsql As String
    Public rdrTemp As SqlDataReader
    Protected WithEvents txtWheelNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtHeatNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblDescription As System.Web.UI.WebControls.Label
    Protected WithEvents cboShift_Code As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtInspector As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfvwheel As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents rfvheat As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents rfvfrheat As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents rfvtoheat As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents rfInsp As System.Web.UI.WebControls.RequiredFieldValidator
    Dim strMode As String

    Shared themeValue As String

    Public Sub New()

        AddHandler PreInit, New EventHandler(AddressOf Page_PreInit)
    End Sub


    Private Sub Page_PreInit(ByVal sender As Object, ByVal e As EventArgs)

        ' Page.Theme = themeValue
        Page.Theme = Session("Theme")
    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        'strMode = Request.QueryString("mode")
        strMode = "add"
        'strMode = "edit"
        'strMode = "delete"
        strMode = strMode.ToLower
        lblMode.Text = strMode
        lblMessage.Text = ""
        If Not IsPostBack Then
            txtDate.Text = Date.Today
            If strMode.Equals("add") Then
                txtDate.AutoPostBack = True
                'grdReadings.Visible = False
                'getHeats()
                getPreviousHeats()
                lblLab.Visible = True
                lblLab_Number.Visible = True
                getlab_Number()
            End If 'End of add Mode
            'Mohith-------------------------------------------
            If strMode.Equals("add") Or strMode.Equals("edit") Or strMode.Equals("delete") Then
                'Mohith--------------------------------------
                BindGrid()

            End If 'End of edit Mode
        End If 'End of IsPostBack
    End Sub

    Sub getlab_Number()
        Try
            If cnn.State = ConnectionState.Closed Then
                cnn.Open()
            End If
            Dim intBid As Integer
            Dim code, yr, yrTemp As String
            strCmd = "select max(lab_code) from ms_wheel_hardness_sample "
            If IsDBNull(SqlHelper.ExecuteScalar(cnn, CommandType.Text, strCmd)) Then
                intBid = 1
                yr = Date.Today.Year
                yr = yr.Substring(2)
            Else
                intBid = SqlHelper.ExecuteScalar(cnn, CommandType.Text, strCmd)
                strCmd = " select lab_number from ms_wheel_hardness_sample where lab_code='" & intBid & "'  "
                code = SqlHelper.ExecuteScalar(cnn, CommandType.Text, strCmd)
                yrTemp = code.Substring(0, 2)
                yr = Date.Today.Year
                yr = yr.Substring(2)
                intBid = code.Substring(3)
                If Not yrTemp.Equals(yr) Then
                    intBid = 0
                End If
                intBid = intBid + 1
            End If
            lblLab_Number.Text = yr & "/" & intBid
        Catch exp As SqlException
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        Dim d As Date
        Dim strCmd As String
        Dim dt As Integer
        Dim code, yr, yrTemp As String
        Dim intBid As Integer
        d = CDate(txtDate.Text)
        If d.Compare(d, Date.Today) > 0 Then
            lblMessage.Text = "Date Should Not Be More Than Today"
            Exit Sub
        End If
        Try
            If cnn.State = ConnectionState.Closed Then
                cnn.Open()
            End If
            strCmd = "select max(lab_code) from ms_wheel_hardness_sample "
            If IsDBNull(SqlHelper.ExecuteScalar(cnn, CommandType.Text, strCmd)) Then
                intBid = 1
                yr = Date.Today.Year
                yr = yr.Substring(2)
            Else
                intBid = SqlHelper.ExecuteScalar(cnn, CommandType.Text, strCmd)
                strCmd = "select lab_number from ms_wheel_hardness_sample where lab_code='" & intBid & "'  "
                code = SqlHelper.ExecuteScalar(cnn, CommandType.Text, strCmd)
                yrTemp = code.Substring(0, 2)
                yr = Year(txtDate.Text)
                yr = yr.Substring(2)
                intBid = code.Substring(3)
                If Not yrTemp.Equals(yr) Then
                    intBid = 0
                End If
                intBid = intBid + 1
            End If
            lblLab_Number.Text = yr & "/" & intBid
        Catch exp As SqlException
            lblMessage.Text = exp.Message
        End Try
        'If Year(txtDate.Text) = Year(Date.Today) Then
        '    strCmd = "SELECT MAX(lab_code) FROM ms_wheel_hardness_sample YEAR(test_date) = '" & Right(txtDate.Text, 4) & "'"
        '    dt = SqlHelper.ExecuteScalar(cnn, CommandType.Text, strCmd)
        '    yr = Date.Today.Year
        '    yr = yr.Substring(2)
        'End If
        BindGrid()
    End Sub

    Sub getPreviousHeats()
        Try
            strCmd = " select heat_from,heat_to from ms_wheel_hardness_sample where "
            strCmd &= " sent_date = (select max(sent_date) from ms_wheel_hardness_sample)"
            rdrTemp = SqlHelper.ExecuteReader(cnn, CommandType.Text, strCmd)
            While rdrTemp.Read
                lblFrom.Text = rdrTemp(0)
                lblTo.Text = rdrTemp(1)
            End While
            rdrTemp.Close()
        Catch exp As SqlException
            lblMessage.Text = exp.Message
        End Try
    End Sub


    Private Sub Clear()
        txtHeatFrom.Text = ""
        txtHeatTo.Text = ""
        txtHeatNumber.Text = ""
        txtWheelNumber.Text = ""
    End Sub
    'Sub getHeats()
    '    cboFrom.Items.Clear()
    '    cboTo.Items.Clear()
    '    Try
    '        strCmd = "select distinct(heat_number) from mm_magnaglow_results where bhn_status <>'R' order by heat_number"
    '        rdrTemp = SqlHelper.ExecuteReader(cnn, CommandType.Text, strCmd)
    '        While rdrTemp.Read
    '            cboFrom.Items.Add(New ListItem(rdrTemp(0)))
    '            cboTo.Items.Add(New ListItem(rdrTemp(0)))
    '        End While
    '        rdrTemp.Close()
    '    Catch exp As SqlException
    '        lblMessage.Text = exp.Message
    '    End Try
    'End Sub

    'Private Sub cboTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    cboWheel.Items.Clear()
    '    Try
    '        strCmd = "select wheel_number,heat_number from mm_magnaglow_results where "
    '        strCmd &= "heat_number>= '" & cboFrom.SelectedItem.Text & "' and "
    '        strCmd &= "heat_number<= '" & cboTo.SelectedItem.Text & "' order by wheel_number"
    '        rdrTemp = SqlHelper.ExecuteReader(cnn, CommandType.Text, strCmd)
    '        While rdrTemp.Read
    '            cboWheel.Items.Add(New ListItem(rdrTemp(0), rdrTemp(1)))
    '        End While
    '        rdrTemp.Close()
    '    Catch exp As SqlException
    '        lblMessage.Text = exp.Message
    '    End Try
    'End Sub

    Private Sub btnSubmit_Clicks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit_Clicks.Click
        Dim d As Date
        d = CDate(txtDate.Text)
        If d.Compare(d, Date.Today) > 0 Then
            lblMessage.Text = "Date Should Not Be More Than Today"
            Exit Sub
        End If
        If Not strMode.Equals("add") Then
            lblMessage.Text = "Not In Add Mode"
            Exit Sub
        End If
        Dim param() As SqlParameter
        If strMode.Equals("add") Then
            strCmd = "select count(*) from ms_wheel_hardness_sample where wheel_number='" & txtWheelNumber.Text & "' and heat_number = " & txtHeatNumber.Text
            Dim cnt As Integer
            cnt = SqlHelper.ExecuteScalar(cnn, CommandType.Text, strCmd)
            If cnt > 0 Then
                lblMessage.Text = "Already Sample Received"
                Exit Sub
            End If

            strCmd = "  select ProdCode from mm_vw_mmwheel_ProductCodes where whl = '" & txtWheelNumber.Text & "' and ht = " & txtHeatNumber.Text
            Dim prodCode As String = SqlHelper.ExecuteScalar(cnn, CommandType.Text, strCmd)
            Dim wheel As String
            wheel = txtWheelNumber.Text.Trim + "/" + txtHeatNumber.Text.Trim
            Dim WhlClass As String = IIf(lblDescription.Text.Trim = "BOXN WHL", "A", "B")
            strCmd = "insert into ms_wheel_hardness_sample ( wheel_number, heat_number, "
            strCmd &= " heat_from,heat_to,sent_date,lab_number,shift_code,inspector,wheel,wheel_type , test_type , wheel_class ) values(@wheel_number,@heat_number,"
            strCmd &= "@heat_from,@heat_to,@sent_date,@lab_number,@shift_code,@inspector,@wheel,'" & lblDescription.Text.Trim & "','Regular','" & WhlClass.Trim & "')"
            ReDim param(8)
            param(0) = New SqlParameter("@wheel_number", Trim(txtWheelNumber.Text))
            param(1) = New SqlParameter("@heat_number", Trim(txtHeatNumber.Text))
            param(2) = New SqlParameter("@heat_from", Trim(txtHeatFrom.Text))
            param(3) = New SqlParameter("@heat_to", Trim(txtHeatTo.Text))
            param(4) = New SqlParameter("@sent_date", Format(CDate(Trim(txtDate.Text)), "MM/dd/yyyy"))
            param(5) = New SqlParameter("@lab_number", lblLab_Number.Text)
            param(6) = New SqlParameter("@shift_code", cboShift_Code.SelectedItem.Text)
            param(7) = New SqlParameter("@inspector", txtInspector.Text)
            param(8) = New SqlParameter("@wheel", wheel.Trim)
            Try
                SqlHelper.ExecuteNonQuery(cnn, CommandType.Text, strCmd, param)
                Dim strNew As String = " insert into ms_wheel_hardness_sample_schedule " & _
                            " select '" & prodCode & "', @heat_from , @heat_to , 0 , 0   "
                SqlHelper.ExecuteNonQuery(cnn, CommandType.Text, strNew, param)
                lblMessage.Text = "Record Inserted"
                getlab_Number()
                Clear()
                BindGrid()
            Catch exp As SqlException
                lblMessage.Text = exp.Message
            Catch expGen As Exception
                lblMessage.Text = expGen.Message
            End Try
        End If 'End of add Mode
    End Sub

    Sub BindGrid()
        If cnn.State = ConnectionState.Closed Then
            cnn.Open()
        End If
        'strCmd modified on 04/08/2006 to display only one lab_number number
        ' for distinct type of wheel
        strCmd = " SELECT HS.wheel_number, HS.heat_number, HS.sent_date, W.description, HS.heat_from, HS.heat_to,HS.lab_number  "
        strCmd &= " FROM ms_wheel_hardness_sample as HS, mm_wheel as W  "
        strCmd &= " WHERE convert(varchar,W.wheel_number) = HS.wheel_number "
        strCmd &= " and W.heat_number = HS.heat_number and HS.lab_number in "
        strCmd &= " (select a.lab_number FROM ms_wheel_hardness_sample a inner join  "
        strCmd &= " ( SELECT max(convert(integer,left(lab_number , charindex('/',lab_number)-1)+ right('00'+substring(lab_number , charindex('/',lab_number)+1,6),3))) lab_number , MAX(h.sent_date) as sent_date1   "
        strCmd &= " FROM ms_wheel_hardness_sample as h, mm_wheel as wh WHERE convert(varchar,wh.wheel_number) = h.wheel_number    "
        strCmd &= " and wh.heat_number = h.heat_number GROUP BY Left(wh.description,4 )) b  "
        strCmd &= " on b.lab_number = convert(integer,left(a.lab_number , charindex('/',a.lab_number)-1)+ right('00'+substring(a.lab_number , charindex('/',a.lab_number)+1,6),3)) )   "
        strCmd &= " ORDER BY HS.sent_date desc  "
        'strCmd = "SELECT wheel_number, heat_number, sent_date, description, heat_from, heat_to, lab_number FROM "
        'strCmd &= " (SELECT HS.wheel_number, HS.heat_number, HS.sent_date, W.description, HS.heat_from, HS.heat_to,HS.lab_number FROM ms_wheel_hardness_sample as HS, mm_wheel as W WHERE convert(varchar,W.wheel_number) = HS.wheel_number and W.heat_number = HS.heat_number ) "
        'strCmd &= "as Table1, "
        'strCmd &= " (SELECT MAX(h.sent_date) as sent_date1 , Left(wh.description,4) as description1 FROM ms_wheel_hardness_sample as h, mm_wheel as wh WHERE convert(varchar,wh.wheel_number) = h.wheel_number and wh.heat_number = h.heat_number GROUP BY Left(wh.description,4)) "
        'strCmd &= "as Table2 "
        'strCmd &= " WHERE Table1.description LIKE Table2.description1 + '%' and Table1.sent_date = Table2.sent_date1 "
        Try
            rdrTemp = SqlHelper.ExecuteReader(cnn, CommandType.Text, strCmd)
            grdReadings.DataSource = rdrTemp
            grdReadings.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            rdrTemp.Close()
        End Try

    End Sub

    Sub EditRow(ByVal objSource As System.Object, ByVal objArgs As DataGridCommandEventArgs)
        If strMode.Equals("edit") Then
            grdReadings.EditItemIndex = objArgs.Item.ItemIndex
            BindGrid()
        Else
            lblMessage.Text = " Not In Edit Mode"
        End If
    End Sub

    Sub UpdateRow(ByVal objSource As System.Object, ByVal objArgs As DataGridCommandEventArgs)
        Dim param() As SqlParameter
        Dim text1, text2, text3, text4 As TextBox
        Dim sno As String
        Try
            sno = objArgs.Item.Cells(1).Text
            text1 = objArgs.Item.Cells(2).Controls(0)
            text2 = objArgs.Item.Cells(3).Controls(0)
            text3 = objArgs.Item.Cells(4).Controls(0)
            text4 = objArgs.Item.Cells(5).Controls(0)

            strCmd = "update ms_wheel_hardness_sample set wheel_number=@wheel_number,"
            strCmd &= "heat_number=@heat_number,heat_from=@heat_from,heat_to=@heat_to where "
            strCmd &= "lab_number=@lab_number"
            ReDim param(4)
            param(0) = New SqlParameter("@wheel_number", text1.Text)
            param(1) = New SqlParameter("@heat_number", text2.Text)
            param(2) = New SqlParameter("@heat_from", text3.Text)
            param(3) = New SqlParameter("@heat_to", text4.Text)
            param(4) = New SqlParameter("@lab_number", sno)

            If cnn.State = ConnectionState.Closed Then
                cnn.Open()
            End If
            SqlHelper.ExecuteNonQuery(cnn, CommandType.Text, strCmd, param)
            grdReadings.EditItemIndex = -1
            lblMessage.Text = "Record UpDated"
            BindGrid()
        Catch exp As SqlException
            If exp.Number = 8114 Then
                lblMessage.Text = "Enter Proper Values"
                Exit Sub
            End If
            lblMessage.Text = exp.Message
        Catch expGen As Exception
            lblMessage.Text = expGen.Message
        End Try
    End Sub

    Sub CancelOperation(ByVal objSource As System.Object, ByVal objArgs As DataGridCommandEventArgs)
        grdReadings.EditItemIndex = -1
        BindGrid()
    End Sub

    Sub DeleteRow(ByVal objSource As System.Object, ByVal objArgs As DataGridCommandEventArgs)
        If Not strMode.Equals("delete") Then
            lblMessage.Text = "Not In Delete Mode"
            Exit Sub
        End If
        Dim trans As SqlTransaction
        Try
            If cnn.State = ConnectionState.Closed Then
                cnn.Open()
            End If
            trans = cnn.BeginTransaction
            Dim sno As String
            sno = objArgs.Item.Cells(1).Text
            strCmd = "select * from ms_wheel_hardness_sample where lab_number='" & sno & "'"
            rdrTemp = SqlHelper.ExecuteReader(trans, CommandType.Text, strCmd)
            While rdrTemp.Read
                strCmd = "insert into ms_wheel_hardness_sample(lab_number,wheel_number,heat_number,heat_from,heat_to,sent_date) "
                strCmd &= " values('" & rdrTemp(0) & "','" & rdrTemp(1) & "','" & rdrTemp(2) & "','" & rdrTemp(3) & "','" & rdrTemp(4) & "','" & rdrTemp(5) & "')"
            End While
            rdrTemp.Close()
            cnn.ChangeDatabase("deleted_wap")
            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, strCmd)

            cnn.ChangeDatabase("wap")
            strCmd = "delete from ms_wheel_hardness_sample where "
            strCmd &= "lab_number='" & sno & "' "
            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, strCmd)
            trans.Commit()
            BindGrid()
            lblMessage.Text = "Record Deleted"
        Catch exp As SqlException
            trans.Rollback()
            lblMessage.Text = exp.Message
        Catch expGen As Exception
            trans.Rollback()
            lblMessage.Text = expGen.Message
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        txtDate.Text = Date.Today
        'cboFrom.SelectedIndex = 0
        'cboTo.SelectedIndex = 0
        'cboWheel.SelectedIndex = 0
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        If cnn.State = ConnectionState.Open Then
            cnn.Close()
        End If
        Server.Transfer("/wap/selectModule.aspx")
    End Sub

    Private Sub InitializeComponent()

    End Sub

    Private Sub txtWheelNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWheelNumber.TextChanged
        'PopulateHeatNumber(Trim(txtWheelNumber.Text))
        If txtWheelNumber.Text <> "" And txtHeatNumber.Text <> "" And IsNumeric(txtWheelNumber.Text) And IsNumeric(txtHeatNumber.Text) Then
            GetDescription()
        Else
            txtHeatNumber.Text = ""
            txtWheelNumber.Text = ""
        End If
    End Sub

    Private Sub GetDescription()
        Try
            strCmd = "SELECT description FROM mm_wheel WHERE wheel_number = " & txtWheelNumber.Text & " and heat_number = " & txtHeatNumber.Text
            Dim strDescription As String = SqlHelper.ExecuteScalar(cnn, CommandType.Text, strCmd)
            lblDescription.Text = IIf(IsDBNull(strDescription.Trim), "", strDescription.Trim)
            If lblDescription.Text = "" Then
                txtWheelNumber.Text = ""
                txtHeatNumber.Text = ""
            End If
        Catch
            txtWheelNumber.Text = ""
            txtHeatNumber.Text = ""
        End Try
    End Sub
    'Private Sub PopulateHeatNumber(ByVal mywheel As String)
    '    strsql = "select heat_number from mm_magnaglow_results where wheel_number=" & mywheel
    '    rdrTemp = SqlHelper.ExecuteScalar(cnn, CommandType.Text, strsql)
    '    ddlHeatNumber.DataSource = rdrTemp
    '    ddlHeatNumber.DataTextField = "heat_number"
    '    ddlHeatNumber.DataValueField = "heat_number"
    '    ddlHeatNumber.DataBind()
    '    rdrTemp.Close()
    'End Sub

    Private Sub txtHeatFrom_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHeatFrom.TextChanged
        'txtHeatFrom.Text = CInt(txtHeatFrom.Text)
        txtHeatFrom.Text = CheckValidHeatNumber(Trim(txtHeatFrom.Text))
    End Sub

    Private Sub txtHeatTo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHeatTo.TextChanged
        'txtHeatTo.Text = CheckValidHeatNumber(Trim(txtHeatTo.Text))
    End Sub

    Private Function CheckValidHeatNumber(ByVal myheatStr As String) As String
        strsql = "select count(heat_number) from mm_wheel where heat_number=" & myheatStr
        Dim rec_count As Integer = SqlHelper.ExecuteScalar(cnn, CommandType.Text, strsql)
        If rec_count = 0 Then
            lblMessage.Text = " Heat No. " & myheatStr & " is Invalid or doesn't exist..."
            Return ("")
        Else
            Return myheatStr
            lblMessage.Text = ""
        End If
    End Function


    'Private Sub txtHeatNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHeatNumber.TextChanged

    'End Sub

    Private Sub txtHeatNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHeatNumber.TextChanged
        If txtHeatNumber.Text = "" Or Not IsNumeric(txtHeatNumber.Text) Then
            lblMessage.Text = "Enter valid Heat Number "
            txtHeatNumber.Text = ""
            txtWheelNumber.Text = ""
            Exit Sub
        End If
        'txtHeatNumber.Text = CheckValidHeatNumber(Trim(txtHeatNumber.Text))
        If Trim(txtHeatNumber.Text) <> "" Then
            If Trim(txtHeatNumber.Text) >= Trim(txtHeatFrom.Text) And Trim(txtHeatNumber.Text) <= Trim(txtHeatTo.Text) Then
            Else
                lblMessage.Text = "Heat Number " & txtHeatNumber.Text & "doesnot lies in the range " & txtHeatFrom.Text & " and " & txtHeatTo.Text
                txtHeatNumber.Text = ""
                txtWheelNumber.Text = ""
                Exit Sub
            End If

            'strsql = "select count(wheel_number) from mm_magnaglow_results where"
            'strsql &= " heat_number =" & Trim(txtHeatNumber.Text)
            'strsql &= " and wheel_number =" & Trim(txtWheelNumber.Text)
            'strsql &= " and wheel_status like 'XC%' and wheel_status <> 'XC8'"

            strsql = " select  count(*) from mm_wheel a where ((a.location = 'mopo' and a.status like 'x%') or ((a.location in ('clmt', 'clqc', 'clfq')  and a.status like 'XC%' and a.status not like 'XC8%' ) or ( a.location = 'clfi' and a.status like 'r%'))) "
            strsql &= " and a.heat_number = " & Trim(txtHeatNumber.Text) & " and a.wheel_number = " & Trim(txtWheelNumber.Text) & " "
            Dim mycount As Integer = SqlHelper.ExecuteScalar(cnn, CommandType.Text, strsql)

            If mycount = 0 Then
                lblMessage.Text = "Wheel No. " & txtWheelNumber.Text & " is Invalid or doesn't fall in the given heat range...."
                txtWheelNumber.Text = ""
                txtHeatNumber.Text = ""
                Exit Sub
            Else
                lblMessage.Text = ""
                GetDescription()
            End If
        End If
    End Sub

End Class
