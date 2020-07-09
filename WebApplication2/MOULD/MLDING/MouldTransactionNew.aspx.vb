Public Class MouldTransactionNew
    Inherits System.Web.UI.Page
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblShift As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblWheel As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rdoMpoList As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtLineJE As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtShiftIC As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMouldNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid3 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid4 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtReWorkMin As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtReWorkHr As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtReWorkDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlDefect As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents panel2added As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlNotAdded As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlAdded As System.Web.UI.WebControls.Panel
    Protected WithEvents ddlMouldNo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlmn As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblLife As System.Web.UI.WebControls.Label
    'new
    Protected WithEvents addaftermouldno As System.Web.UI.WebControls.TextBox
    'Protected WithEvents totalmoulds As System.Web.UI.WebControls.TextBox
    Protected WithEvents totalmouldsonlinecope As System.Web.UI.WebControls.TextBox
    Protected WithEvents totalmouldsonlinedrag As System.Web.UI.WebControls.TextBox
    Protected WithEvents totalmouldsmpocope As System.Web.UI.WebControls.TextBox
    Protected WithEvents totalmouldsmpodrag As System.Web.UI.WebControls.TextBox
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList

    'Pankaj Motwani: Test Code over Collabration on 28/05/2020'
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
    Public Function DateTime(X As Date) As String
        DateTime = "Date(" & Year(X) & " , " & Month(X) & "," & Day(X) & " 0,0,0)"
    End Function

    Protected Sub dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        'Put user code to initialize the page here
        'Session("UserID") = "016002"
        If Page.IsPostBack = False Then
            txtDate.Text = CDate(Now.Date)
            txtReWorkDate.Text = CDate(Now.Date)
            Dim str As String
            Select Case Now.Hour
                Case 6 To 13
                    str = "A"
                Case 14 To 21
                    str = "B"
                Case Else
                    str = "C"
                    txtDate.Text = CDate(Now.Date.AddDays(-1))
                    txtReWorkDate.Text = CDate(Now.Date.AddDays(-1))
            End Select
            txtReWorkHr.Text = CStr(Now.Hour).PadLeft("0")
            txtReWorkHr.Text = Right(txtReWorkHr.Text, 2)
            txtReWorkMin.Text = CStr(Now.Minute).PadLeft("0")
            txtReWorkMin.Text = Right(txtReWorkMin.Text, 2)
            rblShift.ClearSelection()
            Dim i As Integer
            For i = 0 To rblShift.Items.Count - 1
                If str = rblShift.Items(i).Text Then
                    rblShift.Items(i).Selected = True
                    Exit For
                End If
            Next
            Try
                PopulateDdl()
                FillGrid()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            SetFocus(txtDate)
            str = Nothing
            i = Nothing
        End If
        CountOnlineCope(txtDate.Text)

        '    Dim Date1 As Date = CDate(Now.Date)


        'Dim dt2 As New DataTable()

        'dt2 = CountOnlineDrag("Date1")

        'If dt2.Rows.Count > 0 Then

        '    totalmouldsonlinedrag.Text = IIf(IsDBNull(dt2.Rows(0)("CNT2")), "", dt2.Rows(0)("CNT2"))

        'Else

        '    totalmouldsonlinedrag.Text = ""
        'End If
        'Dim dt3 As New DataTable()

        'dt3 = CountMPOCope("Date1")

        'If dt3.Rows.Count > 0 Then

        '    totalmouldsmpocope.Text = IIf(IsDBNull(dt3.Rows(0)("CNT3")), "", dt3.Rows(0)("CNT3"))

        'Else

        '    totalmouldsmpocope.Text = ""
        'End If
        'Dim dt4 As New DataTable()

        'dt4 = CountMPODrag("Date1")

        'If dt4.Rows.Count > 0 Then

        '    totalmouldsmpodrag.Text = IIf(IsDBNull(dt4.Rows(0)("CNT4")), "", dt4.Rows(0)("CNT4"))

        'Else

        '    totalmouldsmpodrag.Text = ""

        'End If
        'End Sub

        'Private Sub SetFocus(ByVal ctrl As Control)
        '    Dim focusScript As String = "<script language=" & "javascript" & " > " & _
        '    "document.getElementById('" + ctrl.ClientID.ToString.Trim & _
        '    "').focus();</script>"
        '    Page.RegisterStartupScript("FocusScript", focusScript)
        '    '  MarkControlAsSelected(ctrl)
    End Sub

    Private Sub PopulateDdl()
        Dim ds As New DataSet()
        Try
            ds = RWF.MLDING.MouldTransData
            rdoMpoList.DataSource = ds.Tables(0).DefaultView
            rdoMpoList.DataTextField = "Description"
            rdoMpoList.DataValueField = "Machine_code"
            rdoMpoList.DataBind()
            rdoMpoList.Items(0).Selected = True
            rblType.DataSource = ds.Tables(1).DefaultView
            rblType.DataTextField = "TransName"
            rblType.DataValueField = "TransNo"
            rblType.DataBind()
            rblType.Items(0).Selected = True
            ddlDefect.DataSource = ds.Tables(2).DefaultView
            ddlDefect.DataTextField = "CodeDesc"
            ddlDefect.DataValueField = "code"
            ddlDefect.DataBind()
            ddlDefect.Items.Insert(0, "Select")
            ddlDefect.Items(0).Selected = True
            ddlmn.DataSource = ds.Tables(3).DefaultView
            ddlmn.DataTextField = "MouldNo"
            ddlmn.DataValueField = "Mould_No"
            ddlmn.DataBind()
            ddlmn.Items.Insert(0, "Select")
            ddlmn.Items(0).Selected = True
            SetPanel()
            SetPanel1()

        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            ds.Dispose()
            ds = Nothing
        End Try
    End Sub

    Private Sub FillGrid()
        txtLineJE.Text = ""
        txtShiftIC.Text = ""
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        DataGrid3.DataSource = Nothing
        DataGrid3.DataBind()
        DataGrid4.DataSource = Nothing
        DataGrid4.DataBind()
        Dim ds As New DataSet()
        Try
            ds = RWF.MLDING.MouldTransShiftData(CDate(txtDate.Text), rblShift.SelectedItem.Text)
            DataGrid1.DataSource = ds.Tables(0)
            DataGrid1.DataBind()
            DataGrid2.DataSource = ds.Tables(1)
            DataGrid2.DataBind()
            DataGrid3.DataSource = ds.Tables(2)
            DataGrid3.DataBind()
            DataGrid4.DataSource = ds.Tables(3)
            DataGrid4.DataBind()
            If ds.Tables(0).Rows.Count > 0 Then
                txtLineJE.Text = ds.Tables(0).Rows(0)("LineJE")
                txtShiftIC.Text = ds.Tables(0).Rows(0)("ShiftIC")
            End If
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            ds.Dispose()
            ds = Nothing
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        If rblType.SelectedItem.Value = 1 Or rblType.SelectedItem.Value = 3 Then
            ddlDefect.ClearSelection()
            ddlDefect.SelectedIndex = 0
            If txtReWorkHr.Text.Trim.PadLeft(2, "0").Substring(0, 2) = "00" Then
                If txtReWorkMin.Text.Trim.PadLeft(2, "0").Substring(0, 2) = "00" Then
                    lblMessage.Text = "InValid Time !"
                    Exit Sub
                End If
            End If
        End If

        If rblType.SelectedItem.Value <> 1 Then
            If txtMouldNo.Text.Trim.Length = 0 Then
                lblMessage.Text = "Please provide Mould No  !"
                Exit Sub
            End If
        End If
        Dim done As New Boolean()
        Dim EstimateID, Defect As Long
        Dim TransTime As DateTime
        Try
            Try
                If ddlDefect.SelectedIndex = 0 Then
                    Defect = 0
                Else
                    Defect = ddlDefect.SelectedItem.Value
                End If
                TransTime = CDate(txtReWorkDate.Text).Year.ToString + "-" + CDate(txtReWorkDate.Text).Month.ToString.PadLeft(2, "0").Substring(0, 2) + "-" + CDate(txtReWorkDate.Text).Day.ToString.PadLeft(2, "0").Substring(0, 2) + " " + txtReWorkHr.Text.Trim.PadLeft(2, "0").Substring(0, 2) + ":" + txtReWorkMin.Text.Trim.PadLeft(2, "0").Substring(0, 2) + ":00"
            Catch exp As Exception
                TransTime = CDate("1900-01-01")
            End Try
            'If rblType.SelectedItem.Value = 1 Then
            '    done = New RWF.MLDING().SaveMouldTran(CDate(txtDate.Text), rblShift.SelectedItem.Value, txtLineJE.Text.Trim, txtShiftIC.Text.Trim, rblType.SelectedItem.Value, rdoMpoList.SelectedItem.Value.Trim, ddlMouldNo.SelectedItem.Text.Trim, Defect, TransTime, addaftermouldno.Text.Trim, totalmoulds.Text.Trim, totalmouldsonlinecope.Text.Trim, totalmouldsmpodrag.Text.Trim, totalmouldsonlinecope.Text.Trim, totalmouldsonlinedrag.Text.Trim)
            'Else
            '    done = New RWF.MLDING().SaveMouldTran(CDate(txtDate.Text), rblShift.SelectedItem.Value, txtLineJE.Text.Trim, txtShiftIC.Text.Trim, rblType.SelectedItem.Value, rdoMpoList.SelectedItem.Value.Trim, txtMouldNo.Text.Trim, Defect, TransTime, addaftermouldno.Text.Trim, totalmoulds.Text.Trim, totalmouldsonlinecope.Text.Trim, totalmouldsmpodrag.Text.Trim, totalmouldsonlinecope.Text.Trim, totalmouldsonlinedrag.Text.Trim)
            'End If

            If rblType.SelectedItem.Value = 1 Then
                done = New RWF.MLDING().SaveMouldTran(CDate(txtDate.Text), rblShift.SelectedItem.Value, txtLineJE.Text.Trim, txtShiftIC.Text.Trim, rblType.SelectedItem.Value, rdoMpoList.SelectedItem.Value.Trim, ddlMouldNo.SelectedItem.Text.Trim, Defect, TransTime, addaftermouldno.Text.Trim)
            Else
                done = New RWF.MLDING().SaveMouldTran(CDate(txtDate.Text), rblShift.SelectedItem.Value, txtLineJE.Text.Trim, txtShiftIC.Text.Trim, rblType.SelectedItem.Value, rdoMpoList.SelectedItem.Value.Trim, txtMouldNo.Text.Trim, Defect, TransTime, addaftermouldno.Text.Trim)
            End If
            If done Then
                lblMessage.Text = "Mould Number Saved ! "
                lblLife.Text = ""
                txtMouldNo.Text = ""
            Else
                lblMessage.Text = "Mould Number Saving failed ! "
            End If
        Catch exp As Exception
            done = False
            lblMessage.Text &= exp.Message
        End Try
        If done Then
            Try
                FillGrid()
                MouldTransList()
            Catch exp As Exception
                lblMessage.Text &= exp.Message
            Finally
            End Try
        Else
            lblMessage.Text &= "InValid Data !"
        End If
        done = Nothing
        EstimateID = Nothing
        Defect = Nothing
        TransTime = Nothing

        SetFocus(rblType)
    End Sub

    Private Sub DataGrid1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.ItemCommand
        lblMessage.Text = ""
        Select Case e.CommandName
            Case "Delete"
                Dim Done As Boolean
                Try
                    Dim oCmd As SqlClient.SqlCommand
                    oCmd = rwfGen.Connection.CmdObj
                    If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                    Try
                        oCmd.Parameters.Add("@MouldNo", SqlDbType.VarChar, 50).Value = e.Item.Cells(8).Text
                        oCmd.Parameters.Add("@SlNo", SqlDbType.Int, 4).Value = e.Item.Cells(9).Text
                    Catch exp As Exception
                        lblMessage.Text = " InValid Data !"
                        Exit Sub
                    End Try
                    Try
                        oCmd.CommandText = " delete mm_MouldTransactionNew where MouldNo = @MouldNo and SlNo  = @SlNo "
                        oCmd.Transaction = oCmd.Connection.BeginTransaction
                        Try
                            If oCmd.ExecuteNonQuery = 1 Then
                                Done = True
                            End If
                        Catch exp As Exception
                            Throw New Exception(" Deletion of MouldNo failed !" & exp.Message)
                        End Try
                    Catch exp As Exception
                        lblMessage.Text = exp.Message
                    Finally
                        If Not IsNothing(oCmd) Then
                            If Done Then
                                oCmd.Transaction.Commit()
                                lblMessage.Text = " Deletion Successful !"
                            Else
                                oCmd.Transaction.Rollback()
                            End If
                            If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                            oCmd.Dispose()
                            oCmd = Nothing
                        End If
                    End Try
                    Done = True
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                    Done = False
                End Try
                If Done Then
                    Try
                        DataGrid1.CurrentPageIndex = 0
                        FillGrid()
                    Catch exp As Exception
                        lblMessage.Text = exp.Message
                    End Try
                End If
                Done = Nothing
        End Select
    End Sub

    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        lblMessage.Text = ""
        Try
            FillGrid()
            ' Dim s As String
            ' s = txtDate.Text
            Dim dt1 As New DataTable()
            dt1 = CountOnlineCope(txtDate.Text)
            If dt1.Rows.Count > 0 Then
                totalmouldsonlinecope.Text = IIf(IsDBNull(dt1.Rows(0)("CNT1")), "", dt1.Rows(0)("CNT1"))
            Else
                totalmouldsonlinecope.Text = ""
            End If
            Dim dt2 As New DataTable()

            dt2 = CountOnlineDrag(txtDate.Text)

            If dt2.Rows.Count > 0 Then

                totalmouldsonlinedrag.Text = IIf(IsDBNull(dt2.Rows(0)("CNT2")), "", dt2.Rows(0)("CNT2"))

            Else

                totalmouldsonlinedrag.Text = ""
            End If
            Dim dt3 As New DataTable()

            dt3 = CountMPOCope(txtDate.Text)

            If dt3.Rows.Count > 0 Then

                totalmouldsmpocope.Text = IIf(IsDBNull(dt3.Rows(0)("CNT3")), "", dt3.Rows(0)("CNT3"))

            Else

                totalmouldsmpocope.Text = ""
            End If
            Dim dt4 As New DataTable()

            dt4 = CountMPODrag(txtDate.Text)

            If dt4.Rows.Count > 0 Then

                totalmouldsmpodrag.Text = IIf(IsDBNull(dt4.Rows(0)("CNT4")), "", dt4.Rows(0)("CNT4"))

            Else

                totalmouldsmpodrag.Text = ""

            End If
            'CountOnlineCope(txtDate.Text)

        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
        End Try
        SetFocus(rblShift)
    End Sub

    Private Sub rblShift_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblShift.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            FillGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
        End Try
        SetFocus(txtLineJE)
    End Sub

    Private Sub txtLineJE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLineJE.TextChanged
        lblMessage.Text = ""
        SetFocus(txtShiftIC)
    End Sub

    Private Sub txtShiftIC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShiftIC.TextChanged
        lblMessage.Text = ""
        SetFocus(rblType)
    End Sub

    Private Sub rblType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblType.SelectedIndexChanged
        lblMessage.Text = ""
        SetFocus(ddlDefect)
        Try
            SetPanel()
            SetPanel1()

        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub rdoMpoList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoMpoList.SelectedIndexChanged
        lblMessage.Text = ""
        SetFocus(txtMouldNo)
    End Sub

    Private Sub txtMouldNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMouldNo.TextChanged
        lblMessage.Text = ""
        lblLife.Text = ""
        Try
            If RWF.MLDING.CheckMldNo(txtMouldNo.Text.Trim) = 0 Then
                txtMouldNo.Text = ""
                Throw New Exception("InValid Mould Number !")
            Else
                GetMldDetails()
            End If
        Catch exp As Exception
            txtMouldNo.Text = ""
            lblMessage.Text = exp.Message
        End Try
        SetFocus(txtReWorkDate)
    End Sub

    Private Sub ddlDefect_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlDefect.SelectedIndexChanged
        lblMessage.Text = ""
        SetFocus(rdoMpoList)
    End Sub

    Private Sub GetMldDetails(Optional ByVal Add As Boolean = False)
        Dim dt As DataTable
        Try
            If Add Then
                dt = RWF.MLDING.GetMldDetails(ddlMouldNo.SelectedItem.Text.Trim)
            Else
                dt = RWF.MLDING.GetMldDetails(txtMouldNo.Text.Trim)
            End If
            If dt.Rows(0)(0) = "D" Then
                lblLife.Text = "DL: " & CStr(dt.Rows(0)(1)) & " ; IgL: " & CStr(dt.Rows(0)(2)) & " Sts: " & dt.Rows(0)(3)
            Else
                lblLife.Text = "CL : " & CStr(dt.Rows(0)(2)) & " Sts: " & dt.Rows(0)(3)
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub MouldTransList()
        Try
            Dim dt As DataTable
            dt = RWF.MLDING.MouldTransList(CDate(txtDate.Text), rblShift.SelectedItem.Text)
            ddlMouldNo.DataSource = dt
            ddlMouldNo.DataTextField = dt.Columns(0).ColumnName
            ddlMouldNo.DataValueField = dt.Columns(0).ColumnName
            ddlMouldNo.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub SetPanel()
        lblLife.Text = ""
        txtMouldNo.Text = ""
        pnlAdded.Visible = False
        pnlNotAdded.Visible = False
        If rblType.SelectedItem.Value = 1 Then
            pnlAdded.Visible = True
            MouldTransList()
            GetMldDetails(True)
        Else
            pnlNotAdded.Visible = True
        End If


    End Sub
    Private Sub SetPanel1()
        lblLife.Text = ""
        txtMouldNo.Text = ""
        panel2added.Visible = True

        If rblType.SelectedItem.Value = 2 Then
            panel2added.Visible = False
            rdoMpoList.SelectedItem.Value = ""
            MouldTransList()
            GetMldDetails(True)
        Else
            panel2added.Visible = True

        End If
    End Sub

    Private Sub ddlMouldNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMouldNo.SelectedIndexChanged
        lblMessage.Text = ""
        lblLife.Text = ""
        Try
            If RWF.MLDING.CheckMldNo(ddlMouldNo.SelectedItem.Text.Trim) = 0 Then
                ddlMouldNo.SelectedIndex = 0
                Throw New Exception("InValid Mould Number !")
            Else
                GetMldDetails(True)
            End If
        Catch exp As Exception
            txtMouldNo.Text = ""
            lblMessage.Text = exp.Message
        End Try
        SetFocus(txtReWorkDate)
    End Sub

    Private Sub txtReWorkDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReWorkDate.TextChanged
        SetFocus(txtReWorkHr)
    End Sub

    Private Sub txtReWorkHr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReWorkHr.TextChanged
        SetFocus(txtReWorkMin)
    End Sub

    Private Sub txtReWorkMin_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReWorkMin.TextChanged
        SetFocus(btnSave)
    End Sub

    Public Function CountOnlineCope(ByVal date1 As DateTime) As DataTable




        Dim ds As New DataSet()
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Try

            da.SelectCommand.Parameters.Add("@date1", SqlDbType.DateTime, 4).Value = date1
            da.SelectCommand.CommandText = "select  sum(Cope) CNT1 from mm_vw_MouldTransPosition where TransNo=1 and TransDate=@date1"
            'da.SelectCommand.CommandText = "select  sum(Cope) CNT1 from mm_vw_MouldTransPosition where TransNo=1 and TransDate='2019-04-18 00:00:00'"

            da.Fill(ds)
            Return ds.Tables(0)
        Catch exp As Exception

        Finally
            da.Dispose()
            ds.Dispose()
            ds = Nothing
            da = Nothing
        End Try

    End Function

    'Public Function CountOnlineCope(ByVal toDate1 As String) As DataTable
    '    Dim ds As New DataSet()
    '    Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
    '    Try
    '        da.SelectCommand.CommandText = "select  count(*) CNT1 from mm_MouldTransactionNew where TransType=1 and TransDate=@toDate1"
    '        da.SelectCommand.Parameters.Add("@toDate1", SqlDbType.DateTime, 8).Direction = ParameterDirection.Output
    '        da.Fill(ds)
    '        Return ds.Tables(0)
    '    Catch exp As Exception

    '    Finally
    '        da.Dispose()
    '        ds.Dispose()
    '        ds = Nothing
    '        da = Nothing
    '    End Try
    'End Function

    Public Function CountOnlineDrag(ByVal Date1 As DateTime) As DataTable
        Dim ds As New DataSet()
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Try
            da.SelectCommand.Parameters.Add("@Date1", SqlDbType.DateTime, 4).Value = Date1
            da.SelectCommand.CommandText = "select sum(Drag)   CNT2 from mm_vw_MouldTransPosition where TransNo=2 and TransDate=@Date1"
            'da.SelectCommand.CommandText = "select  sum(Drag) CNT2 from mm_vw_MouldTransPosition where TransNo=1 and TransDate='2019-04-18 00:00:00'"

            da.Fill(ds)
            Return ds.Tables(0)
        Catch exp As Exception

        Finally
            da.Dispose()
            ds.Dispose()
            ds = Nothing
            da = Nothing
        End Try


    End Function


    Public Function CountMPOCope(ByVal Date1 As DateTime) As DataTable
        Dim ds As New DataSet()
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Try
            da.SelectCommand.Parameters.Add("@Date1", SqlDbType.DateTime, 4).Value = Date1
            da.SelectCommand.CommandText = "select sum(Cope)   CNT3 from mm_vw_MouldTransPosition where TransNo=3 and TransDate=@Date1"

            da.Fill(ds)
            Return ds.Tables(0)
        Catch exp As Exception

        Finally
            da.Dispose()
            ds.Dispose()
            ds = Nothing
            da = Nothing
        End Try
    End Function

    Public Function CountMPODrag(ByVal Date1 As DateTime) As DataTable
        Dim ds As New DataSet()
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Try
            'da.SelectCommand.CommandText = "select  count(*) CNT4 from mm_MouldTransactionNew where TransType=4 and TransDate=@toDate4"
            da.SelectCommand.Parameters.Add("@Date1", SqlDbType.DateTime, 4).Value = Date1
            da.SelectCommand.CommandText = "select sum(Drag)   CNT4 from mm_vw_MouldTransPosition where TransNo=4 and TransDate=@Date1"
            da.Fill(ds)
            Return ds.Tables(0)
        Catch exp As Exception

        Finally
            da.Dispose()
            ds.Dispose()
            ds = Nothing
            da = Nothing
        End Try
    End Function


    'Private Sub totalmouldsonlinecope_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles totalmouldsonlinecope.TextChanged
    '    lblMessage.Text = ""
    '    totalmouldsonlinecope.Text = ""
    '    Try
    '        If RWF.MLDING.CountOnlineCope(totalmouldsonlinecope.Text.Trim) = 0 Then
    '            totalmouldsonlinecope = 0
    '            Throw New Exception("InValid Cope Count !")
    '        Else
    '            CountOnlineCope(True)
    '        End If
    '    Catch exp As Exception
    '        totalmouldsonlinecope.Text = ""
    '        lblMessage.Text = exp.Message
    '    End Try
    '    SetFocus(totalmouldsonlinecope)
    'End Sub

    Private Sub ddlmn_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlmn.SelectedIndexChanged
        lblMessage.Text = ""
        lblLife.Text = ""
        Try
            If RWF.MLDING.CheckMldNo(ddlMouldNo.SelectedItem.Text.Trim) = 0 Then
                ddlMouldNo.SelectedIndex = 0
                Throw New Exception("InValid Mould Number !")
            Else
                GetMldDetails1(True)
            End If
        Catch exp As Exception
            ddlmn.Text = ""
            lblMessage.Text = exp.Message
        End Try
        SetFocus(txtReWorkDate)
    End Sub

    Private Function GetMldDetails1(Optional ByVal Add As Boolean = False)
        Dim ds As New DataSet()
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter

        Dim dt As DataTable
        Try
            If Add Then
                dt = RWF.MLDING.GetMldDetails(ddlmn.SelectedItem.Text.Trim)
            Else
                dt = RWF.MLDING.GetMldDetails(ddlmn.Text.Trim)
            End If
            If rblWheel.SelectedItem.Value = "BGC" Then
                ddlmn.Text = "110123"

                da.SelectCommand.CommandText = "select mould_number from mm_mould_master where product_code='110123'"
                da.Fill(ds)
                Return ds.Tables(3)

            Else
                ddlmn.Text = "120120"

                da.SelectCommand.CommandText = "select mould_number from mm_mould_master where product_code='120120'"
                da.Fill(ds)
                Return ds.Tables(0)
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            da.Dispose()
            ds.Dispose()
            ds = Nothing
            da = Nothing
        End Try
    End Function

End Class
