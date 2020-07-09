Imports System.Data
Imports System.Data.SqlClient

Public Class RoofLining
    Inherits System.Web.UI.Page


    Protected WithEvents rbA As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rbB As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rbC As System.Web.UI.WebControls.RadioButtonList


    Dim i As String
    Dim strSql As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Dim Group As String = Session("Group")
            Dim UserId As String = Session("UserID")
            Dim InValid As Boolean = False
            ''''''''''''''''
            'Session("Group") = "SSMELT"
            'Session("UserID") = "074510"
            Group = "SSMELT"
            UserId = "111111"
            ''''''''''''''''

            If InValid Then
                Response.Redirect("/mss/logon.aspx")
            Else
                rbA.Visible = False
                rbB.Visible = False
                rbC.Visible = False


                txtLOADate.Text = Now.Date

                txtHandedOverOnDate.Text = Now.Date
                txtWorkStartedOnDate.Text = Now.Date
                txtWorkCompletedOnDate.Text = Now.Date
                txtHandedOverOnTime.Text = "00:00"
                txtWorkStartedOnTime.Text = "00:00"
                txtWorkCompletedOnTime.Text = "00:00"
                SetType()
            End If
        End If

    End Sub
    Private Sub SetType()
        txtLiningNo.Text = ""
        txtLastHeatNo.Text = ""
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        DataGrid3.DataSource = Nothing
        DataGrid3.DataBind()
        pnlLadle.Visible = False
        pnlFWP.Visible = False
        rbA.Visible = True
        rbB.Visible = False
        rbC.Visible = False

        'rblLiningRoofNo.Visible = False
        txtFFLNo.Text = ""
        GetLiningSavedData()
        GetTopDetails()
    End Sub
    Private Sub rbLiningItemNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbLiningItemNo.SelectedIndexChanged
        Response.Write("rbl_selected")
        If rbLiningItemNo.SelectedItem.Value = "A" Then
            rbA.Visible = True
            rbB.Visible = False
            rbC.Visible = False

        End If
        If rbLiningItemNo.SelectedItem.Value = "B" Then
            rbA.Visible = False
            rbB.Visible = True
            rbC.Visible = False

        End If
        If rbLiningItemNo.SelectedItem.Value = "C" Then
            rbA.Visible = False
            rbB.Visible = False
            rbC.Visible = True

        End If

        ' GetTopDetails()
    End Sub

    Private Sub GetLiningSavedData()

        Dim str As String

        str = "select top 6 LiningNo , " &
            " LinedBy , LiningItemNo , FirstHeatNo , LastHeatNo ," &
            " convert(varchar(10),HandedOverOn,103) HODt , convert(varchar(5),HandedOverOn,114) HOTime ," &
            " convert(varchar(10),WorkStartedOn,103) WSDt , convert(varchar(5),WorkStartedOn,114) WSTime ," &
            " convert(varchar(10),WorkCompletedOn,103) WCDt , convert(varchar(5),WorkCompletedOn,114) WCTime , " &
            " InspectionNote , LOANo, convert(varchar(10),LOADate,103) LOADt , ScheduledQty SchQty , CompletedQty UsedQty , " &
            " PreLiningNo , SlNo " &
            " from ms_FurnaceLining a inner join ( select distinct LT , LiningType from ms_vw_LiningType ) b on a.LT = b.LT " &
            " inner join ms_vw_LinedBy c on a.LB = c.LB" &
            " where a.LT = '4' and a.LB = '" & rblinedby.SelectedItem.Value & "'  order by WorkCompletedOn desc , LiningNo desc"

        Call BindDataGrid2(str)
    End Sub
    Private Sub BindDataGrid2(ByVal strArg As String)
        Dim objCmd As SqlCommand
        Dim objDr As SqlDataReader

        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj

        If oCmd.Connection.State = ConnectionState.Closed Then
            oCmd.Connection.Open()
        Else
            oCmd.Connection.Close()
            oCmd.Connection.Open()
        End If
        Try
            objCmd = New SqlCommand(strArg, oCmd.Connection)
            objDr = objCmd.ExecuteReader()
            Dim arr() As String
            DataGrid2.DataSource = arr
            DataGrid2.DataBind()
            DataGrid2.DataSource = objDr
            DataGrid2.DataBind()
        Catch exp As SqlException
            strSql = exp.StackTrace
            lblMessage.Text = "Line : " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message

        Catch exp As Exception
            strSql = exp.StackTrace
            lblMessage.Text = "Line : " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message
        End Try

        oCmd.Connection.Close()

    End Sub
    Private Sub rbA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbA.SelectedIndexChanged


        GetTopDetails()
    End Sub
    Private Sub rbB_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbB.SelectedIndexChanged

        GetTopDetails()

    End Sub
    Private Sub rbC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbC.SelectedIndexChanged

        GetTopDetails()

    End Sub

    Private Sub GetTopDetails()
        Response.Write("infn")
        Dim Roof As String
        If rbLiningItemNo.SelectedItem.Value = "A" Then
            Roof = rbA.SelectedValue
        End If

        If rbLiningItemNo.SelectedItem.Value = "B" Then
            Response.Write(" inB ")
            Roof = rbB.SelectedValue

            Response.Write(Roof)
        End If

        If rbLiningItemNo.SelectedItem.Value = "C" Then
            Roof = rbC.SelectedValue
        End If


        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj


        ' Dim str As String
        cmd.CommandText = "select top 1 LiningNo , " &
            " convert(varchar(10),HandedOverOn,103) HODt , convert(varchar(5),HandedOverOn,114) HOTime ," &
            " convert(varchar(10),WorkStartedOn,103) WSDt , convert(varchar(5),WorkStartedOn,114) WSTime ," &
            " convert(varchar(10),WorkCompletedOn,103) WCDt , convert(varchar(5),WorkCompletedOn,114) WCTime , " &
            " InspectionNote , LOANo, convert(varchar(10),LOADate,103) LOADt , " &
            " ScheduledQty SchQty , CompletedQty UsedQty , SlNo " &
            " from ms_FurnaceLining a inner join ( select distinct LT , LiningType from ms_vw_LiningType ) b on a.LT = b.LT " &
            " inner join ms_vw_LinedBy c on a.LB = c.LB" &
            " where LiningItemNo = @Roof and a.LT = '4' " &
            " order by WorkCompletedOn desc , LiningNo desc "

        cmd.Parameters.Add("@Roof", SqlDbType.VarChar, 4).Value = Roof


        Try
            cmd.Connection.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            DataGrid3.DataSource = dr
            DataGrid3.DataBind()
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally

            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing

        End Try
    End Sub


    Private Sub txtLastHeatNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLastHeatNo.TextChanged
        lblMessage.Text = ""
        Dim sqlstr1 As String
        sqlstr1 = "select roof_number ,  " &
                " convert(varchar(10),TappedDate,103) TappedDt  , TappedShift Sh , " &
                " convert(varchar(5),Heat_Tapped,114) TapTime " &
                " from mm_vw_HeatTapped a inner join mm_roof_details b" &
                " on a.heat_number = b.heat_number" &
                " where a.heat_number = '" & txtLastHeatNo.Text & "' "


        Call BindDataGrid(sqlstr1)


    End Sub

    Private Sub BindDataGrid(ByVal strArg As String)
        Dim objCmd As SqlCommand
        Dim objDr As SqlDataReader

        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj

        If oCmd.Connection.State = ConnectionState.Closed Then
            oCmd.Connection.Open()
        Else
            oCmd.Connection.Close()
            oCmd.Connection.Open()
        End If
        Try
            objCmd = New SqlCommand(strArg, oCmd.Connection)
            objDr = objCmd.ExecuteReader()
            Dim arr() As String
            DataGrid1.DataSource = arr
            DataGrid1.DataBind()
            DataGrid1.DataSource = objDr
            DataGrid1.DataBind()
        Catch exp As SqlException
            strSql = exp.StackTrace
            lblMessage.Text = "Line : " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message

        Catch exp As Exception
            strSql = exp.StackTrace
            lblMessage.Text = "Line : " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message
        End Try

        oCmd.Connection.Close()

    End Sub

    Protected Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim done, doneS, done1 As Boolean
        lblMessage.Text = ""
        If txtLiningNo.Text = "" Then
            lblMessage.Text = "InValid Lining No"
            Exit Sub
        End If
        Dim Line As Int16 = Val(Left(txtLiningNo.Text, 1))
        If Line = 0 Then
            lblMessage.Text = "InValid Lining No"
            Exit Sub
        End If
        Line = Nothing
        If txtLastHeatNo.Text = "" Then
            lblMessage.Text = "InValid HeatNo"
            Exit Sub
        End If
        Dim HandedOverOn, WorkStartedOn, WorkCompletedOn As DateTime

        Try
            HandedOverOn = CDate(txtHandedOverOnDate.Text) & " " & txtHandedOverOnTime.Text
            done = True
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If done = False Then
            lblMessage.Text = "InValid HandedOverOn Date Time !"
            Exit Sub
        Else
            done = False
        End If

        Try
            WorkStartedOn = CDate(txtWorkStartedOnDate.Text) & " " & txtWorkStartedOnTime.Text
            done = True
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If done = False Then
            lblMessage.Text = "InValid WorkStartedOn Date Time !"
            Exit Sub
        Else
            done = False
        End If

        Try
            WorkCompletedOn = CDate(txtWorkCompletedOnDate.Text) & " " & txtWorkCompletedOnTime.Text
            done = True
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If done = False Then
            lblMessage.Text = "InValid WorkCompletedOn Date Time !"
            Exit Sub
        Else
            done = False
        End If


        Dim Roof As String
        If rbLiningItemNo.SelectedItem.Value = "A" Then
            Roof = rbA.SelectedItem.Value
        End If

        If rbLiningItemNo.SelectedItem.Value = "B" Then
            Roof = rbB.SelectedItem.Value
        End If

        If rbLiningItemNo.SelectedItem.Value = "C" Then
            Roof = rbC.SelectedItem.Value
        End If
        Response.Write("ch1")
        Dim n As Integer = checks()
        Response.Write(n)
        If n > 0 Then

            done1 = update(txtLiningNo.Text.Trim, Val(txtLastHeatNo.Text), HandedOverOn, WorkStartedOn, WorkCompletedOn, txtLOANo.Text.Trim, CDate(txtLOADate.Text), Val(txtScheduledQty.Text), Val(txtCompletedQty.Text), txtInspectionNote.Text.Trim, txtPreLiningNo.Text.Trim)


        Else




            doneS = SaveFurnaceLining(txtLiningNo.Text.Trim, "4", rblinedby.SelectedItem.Value, Roof, Val(txtLastHeatNo.Text), HandedOverOn, WorkStartedOn, WorkCompletedOn, txtLOANo.Text.Trim, CDate(txtLOADate.Text), Val(txtScheduledQty.Text), Val(txtCompletedQty.Text), txtInspectionNote.Text.Trim, txtPreLiningNo.Text.Trim, txtGroupLeader1.Text.Trim, txtGroupLeader2.Text.Trim, txtLOARemarks.Text.Trim)


        End If
        If doneS Then
            lblMessage.Text = "Data Saved successfully !"
        ElseIf done1 Then
            lblMessage.Text = "Data Updated successfully !"
        Else
            lblMessage.Text = "Data Not Saved !"
        End If
        GetLiningSavedData()
        GetTopDetails()
    End Sub
    Public Function checks()

        Dim liningno As String = txtLiningNo.Text
        Response.Write("chfn")

        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.CommandText = "SELECT COUNT(*) FROM ms_FurnaceLining where LiningNo=@liningno and LT='4'"

        cmd.Parameters.AddWithValue("@liningno", liningno)
        Try
            cmd.Connection.Open()
            Response.Write("con")


            Dim i As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            Response.Write(i)
            Return i
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally

            cmd.Connection.Close()

        End Try


    End Function
    Public Function update(ByVal LiningNo As String, ByVal LastHeatNo As Long, ByVal HandedOverOn As DateTime, ByVal WorkStartedOn As DateTime, ByVal WorkCompletedOn As DateTime, ByVal LOANo As String, ByVal LOADate As Date, ByVal ScheduledQty As Integer, ByVal CompletedQty As Integer, ByVal InspectionNote As String, ByVal PreLiningNo As String) As Boolean
        Dim done As Boolean


        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.Connection.Open()

        Try
            cmd.Parameters.Add("@LiningNo", SqlDbType.VarChar, 50).Value = LiningNo
            cmd.Parameters.Add("@LastHeatNo", SqlDbType.BigInt, 8).Value = LastHeatNo
            cmd.Parameters.Add("@HandedOverOn", SqlDbType.SmallDateTime, 4).Value = HandedOverOn
            cmd.Parameters.Add("@WorkStartedOn", SqlDbType.SmallDateTime, 4).Value = WorkStartedOn
            cmd.Parameters.Add("@WorkCompletedOn", SqlDbType.SmallDateTime, 4).Value = WorkCompletedOn
            cmd.Parameters.Add("@LOANo", SqlDbType.VarChar, 50).Value = LOANo
            cmd.Parameters.Add("@LOADate", SqlDbType.SmallDateTime, 4).Value = LOADate
            cmd.Parameters.Add("@ScheduledQty", SqlDbType.Int, 4).Value = ScheduledQty
            cmd.Parameters.Add("@CompletedQty", SqlDbType.Int, 4).Value = CompletedQty
            cmd.Parameters.Add("@InspectionNote", SqlDbType.VarChar, 250).Value = InspectionNote
            cmd.Parameters.Add("@PreLiningNo", SqlDbType.VarChar, 50).Value = PreLiningNo


            cmd.CommandText = " update ms_FurnaceLining set  " &
                            " HandedOverOn = @HandedOverOn , WorkStartedOn = @WorkStartedOn , WorkCompletedOn = @WorkCompletedOn , " &
                            " LOANo = @LOANo , LOADate = @LOADate ,  ScheduledQty = @ScheduledQty , " &
                            " CompletedQty = @CompletedQty , InspectionNote = @InspectionNote ," &
                            " LastHeatNo = @LastHeatNo , " &
                            " where LiningNo = @LiningNo and LT='4' "



            If cmd.ExecuteNonQuery() = 1 Then done = True

        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            cmd.Connection.Close()
        End Try
        Return done

    End Function

    Public Function SaveFurnaceLining(ByVal LiningNo As String, ByVal LT As Int16, ByVal LB As Int16, ByVal LiningItemNo As String, ByVal LastHeatNo As Long, ByVal HandedOverOn As DateTime, ByVal WorkStartedOn As DateTime, ByVal WorkCompletedOn As DateTime, ByVal LOANo As String, ByVal LOADate As Date, ByVal ScheduledQty As Integer, ByVal CompletedQty As Integer, ByVal InspectionNote As String, ByVal PreLiningNo As String, ByVal GroupLeader1 As String, ByVal GroupLeader2 As String, ByVal LOARemarks As String) As Boolean
        Dim Done As Boolean
        Dim roof As Boolean
        Dim oCmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Try
            oCmd.Parameters.Add("@LiningNo", SqlDbType.VarChar, 50).Value = LiningNo
            oCmd.Parameters.Add("@LT", SqlDbType.Int, 4).Value = LT
            oCmd.Parameters.Add("@LB", SqlDbType.Int, 4).Value = LB
            oCmd.Parameters.Add("@LiningItemNo", SqlDbType.VarChar, 50).Value = LiningItemNo
            oCmd.Parameters.Add("@LastHeatNo", SqlDbType.BigInt, 8).Value = LastHeatNo
            oCmd.Parameters.Add("@HandedOverOn", SqlDbType.SmallDateTime, 4).Value = HandedOverOn
            oCmd.Parameters.Add("@WorkStartedOn", SqlDbType.SmallDateTime, 4).Value = WorkStartedOn
            oCmd.Parameters.Add("@WorkCompletedOn", SqlDbType.SmallDateTime, 4).Value = WorkCompletedOn
            oCmd.Parameters.Add("@LOANo", SqlDbType.VarChar, 50).Value = LOANo
            oCmd.Parameters.Add("@LOADate", SqlDbType.SmallDateTime, 4).Value = LOADate
            oCmd.Parameters.Add("@ScheduledQty", SqlDbType.Int, 4).Value = ScheduledQty
            oCmd.Parameters.Add("@CompletedQty", SqlDbType.Int, 4).Value = CompletedQty
            oCmd.Parameters.Add("@InspectionNote", SqlDbType.VarChar, 250).Value = InspectionNote
            oCmd.Parameters.Add("@PreLiningNo", SqlDbType.VarChar, 50).Value = PreLiningNo
            oCmd.Parameters.Add("@GroupLeader1", SqlDbType.VarChar, 6).Value = GroupLeader1
            oCmd.Parameters.Add("@GroupLeader2", SqlDbType.VarChar, 6).Value = GroupLeader2
            oCmd.Parameters.Add("@LOARemarks", SqlDbType.VarChar, 50).Value = LOARemarks

            Try
                oCmd.Connection.Open()
                oCmd.CommandText = " insert into ms_FurnaceLining ( LiningNo , LT , LB , " &
                        " LiningItemNo , HandedOverOn , WorkStartedOn , LOARemarks , " &
                        " WorkCompletedOn , LOANo , LOADate ,  ScheduledQty , CompletedQty , InspectionNote , " &
                        " LastHeatNo , PreLiningNo , GroupLeader1 , GroupLeader2 ) " &
                        " values ( @LiningNo , @LT , @LB , @LiningItemNo , @HandedOverOn , @WorkStartedOn , @LOARemarks , " &
                        " @WorkCompletedOn , @LOANo , @LOADate ,  @ScheduledQty , @CompletedQty , @InspectionNote ," &
                        " @LastHeatNo , @PreLiningNo ,  @GroupLeader1 , @GroupLeader2) "

                If oCmd.ExecuteNonQuery = 1 Then Done = True

            Catch exp As Exception
                Throw New Exception(" Furnace Lining Updation failed !" & exp.Message)
            End Try
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            oCmd.Connection.Close()
        End Try
        Return Done
    End Function

    'Protected Sub datagrid3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DataGrid3.SelectedIndexChanged
    '    DataGrid3.SelectedIndex = i
    '    txtLiningNo.Text = Trim(DataGrid3.Items(i).Cells(1).Text)
    '    txtHandedOverOnDate.Text = Trim(DataGrid3.Items(i).Cells(2).Text)
    '    txtHandedOverOnTime.Text = Trim(DataGrid3.Items(i).Cells(3).Text)
    '    txtWorkStartedOnDate.Text = Trim(DataGrid3.Items(i).Cells(4).Text)
    '    txtWorkStartedOnTime.Text = Trim(DataGrid3.Items(i).Cells(5).Text)
    '    txtWorkCompletedOnDate.Text = Trim(DataGrid3.Items(i).Cells(6).Text)
    '    txtWorkCompletedOnTime.Text = Trim(DataGrid3.Items(i).Cells(7).Text)
    '    txtInspectionNote.Text = Trim(DataGrid3.Items(i).Cells(8).Text)
    '    txtLOANo.Text = Trim(DataGrid3.Items(i).Cells(9).Text)
    '    txtLOADate.Text = Trim(DataGrid3.Items(i).Cells(10).Text)
    '    txtScheduledQty.Text = DataGrid3.Items(i).Cells(11).Text
    '    txtCompletedQty.Text = DataGrid3.Items(i).Cells(12).Text
    'End Sub
    'Private Sub DataGrid3_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid3.ItemCommand
    '    i = e.Item.ItemIndex()
    'End Sub


    Protected Sub DataGrid2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DataGrid2.SelectedIndexChanged
        Dim str As String
        Dim str1 As String

        DataGrid2.SelectedIndex = i
        txtLiningNo.Text = Trim(DataGrid2.Items(i).Cells(1).Text)
        rblinedby.SelectedValue = Trim(DataGrid2.Items(i).Cells(2).Text)

        'str1 = Left(LTrim(Trim(DataGrid2.Items(i).Cells(3).Text)), 1)

        'If str1 = "A" Then
        '    Response.Write(str1)
        '    rbLiningItemNo.SelectedValue = "A"
        '    rbA.Visible = True
        '    rbB.Visible = False
        '    rbC.Visible = False
        '    rbA.SelectedItem.Value = Trim(DataGrid2.Items(i).Cells(3).Text)

        'ElseIf str1 = "B" Then

        '    Response.Write(str1)
        '    rbLiningItemNo.SelectedValue = "B"
        '    rbA.Visible = False
        '    rbB.Visible = True
        '    rbC.Visible = False
        '    rbB.SelectedItem.Value = Trim(DataGrid2.Items(i).Cells(3).Text)

        'ElseIf str1 = "C" Then

        '    Response.Write(str1)
        '    rbLiningItemNo.SelectedValue = "C"
        '    rbA.Visible = False
        '    rbB.Visible = False
        '    rbC.Visible = True
        '    rbC.SelectedItem.Value = Trim(DataGrid2.Items(i).Cells(3).Text)
        'End If

        txtLastHeatNo.Text = Trim(DataGrid2.Items(i).Cells(5).Text)
        txtHandedOverOnDate.Text = Trim(DataGrid2.Items(i).Cells(6).Text)
        txtHandedOverOnTime.Text = Trim(DataGrid2.Items(i).Cells(7).Text)
        txtWorkStartedOnDate.Text = Trim(DataGrid2.Items(i).Cells(8).Text)
        txtWorkStartedOnTime.Text = Trim(DataGrid2.Items(i).Cells(9).Text)
        txtWorkCompletedOnDate.Text = Trim(DataGrid2.Items(i).Cells(10).Text)
        txtWorkCompletedOnTime.Text = Trim(DataGrid2.Items(i).Cells(11).Text)
        txtInspectionNote.Text = Trim(DataGrid2.Items(i).Cells(12).Text)
        txtLOANo.Text = Trim(DataGrid2.Items(i).Cells(13).Text)
        txtLOADate.Text = Trim(DataGrid2.Items(i).Cells(14).Text)
        txtScheduledQty.Text = DataGrid2.Items(i).Cells(15).Text
        txtCompletedQty.Text = DataGrid2.Items(i).Cells(16).Text
        txtPreLiningNo.Text = Trim(DataGrid2.Items(i).Cells(17).Text)
        'txtBMOM.Text = Trim(DataGrid2.Items(i).Cells(18).Text)
        'txtTTT.Text = Trim(DataGrid2.Items(i).Cells(19).Text)
        'txtTMOM.Text = DataGrid2.Items(i).Cells(20).Text
        'txtDepth.Text = DataGrid2.Items(i).Cells(21).Text

    End Sub
    Private Sub DataGrid2_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid2.ItemCommand
        i = e.Item.ItemIndex()
    End Sub







End Class

