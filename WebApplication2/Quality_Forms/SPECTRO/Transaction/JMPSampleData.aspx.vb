Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports System.DateTime

Public Class JMPSampledata
    Inherits System.Web.UI.Page
    Protected WithEvents panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents panel2 As System.Web.UI.WebControls.Panel
    Protected WithEvents panel3 As System.Web.UI.WebControls.Panel
    Protected WithEvents panel4 As System.Web.UI.WebControls.Panel
    Protected WithEvents panel5 As System.Web.UI.WebControls.Panel
    Protected WithEvents panel6 As System.Web.UI.WebControls.Panel
    Protected WithEvents lblmsg As System.Web.UI.WebControls.Label
    Protected WithEvents lblhsts As System.Web.UI.WebControls.Label
    Protected WithEvents lblhsts1 As System.Web.UI.WebControls.Label
    Protected WithEvents rblsample As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents shiftrbl As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblmetal As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtdate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txttime As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtheat As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtremarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtcmacms As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtc As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtmn As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtsi As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtp As System.Web.UI.WebControls.TextBox
    Protected WithEvents txts As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtcr As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtni As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtcu As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtmo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtv As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtal As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtn As System.Web.UI.WebControls.TextBox
    Protected WithEvents txth As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtcnm As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtfheat As System.Web.UI.WebControls.TextBox
    Protected WithEvents txttheat As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddljmp As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlproduct As System.Web.UI.WebControls.DropDownList
    Protected WithEvents grid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnclear As System.Web.UI.WebControls.Button
    Protected WithEvents btnsave As System.Web.UI.WebControls.Button
    Protected WithEvents B1 As System.Web.UI.WebControls.Button
    Protected WithEvents B2 As System.Web.UI.WebControls.Button
    Protected WithEvents data1 As System.Web.UI.WebControls.GridView
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label

    Dim strSql As String
    Dim cmd As New SqlCommand
    Dim i As String



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None
        Try
            If Page.IsPostBack = False Then

                SetScreen()

            End If
        Catch exp As Exception
            lblmsg.Text = exp.Message
        End Try

        txtdate_TextChanged(sender, e)

    End Sub
    Private Sub SetScreen()
        txtdate.Text = DateTime.Now.Date
        txttime.Text = DateTime.Now.ToShortTimeString
        getdata()
        If rblsample.SelectedItem.Value = "JMP" Then
            lblhsts.Visible = True
            ddljmp.Visible = True
            lblhsts1.Visible = False
            ddlproduct.Visible = False
        ElseIf rblsample.SelectedItem.Value = "product" Then
            lblhsts1.Visible = True
            ddlproduct.Visible = True
            lblhsts.Visible = False
            ddljmp.Visible = False
        Else
            lblhsts1.Visible = True
            ddlproduct.Visible = True
            lblhsts.Visible = False
            ddljmp.Visible = False
            ddlproduct.Visible = False
        End If

    End Sub



    Protected Sub rblsample_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblsample.SelectedIndexChanged
        If rblsample.SelectedItem.Value = "JMP" Then
            lblhsts.Visible = True
            ddljmp.Visible = True
            lblhsts1.Visible = False
            ddlproduct.Visible = False
        Else
            lblhsts1.Visible = True
            ddlproduct.Visible = True
            lblhsts.Visible = False
            ddljmp.Visible = False
        End If
    End Sub

    Public Function f1()
        Dim done As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj

        Dim status As String
        If rblsample.SelectedItem.Value = "JMP" Then
            status = ddljmp.SelectedItem.Value
        ElseIf rblsample.SelectedItem.Value = "product" Then
            status = ddlproduct.SelectedItem.Value
        Else
            status = ""
        End If
        If txtc.Text = "" Then
            txtc.Text = "0.0"
        End If
        If txtmn.Text = "" Then
            txtmn.Text = "0.0"
        End If
        If txtsi.Text = "" Then
            txtsi.Text = "0.0"
        End If
        If txtp.Text = "" Then
            txtp.Text = "0.0"
        End If
        If txts.Text = "" Then
            txts.Text = "0.0"
        End If
        If txtcr.Text = "" Then
            txtcr.Text = "0.0"
        End If
        If txtni.Text = "" Then
            txtni.Text = "0.0"
        End If
        If txtcu.Text = "" Then
            txtcu.Text = "0.0"
        End If
        If txtmo.Text = "" Then
            txtmo.Text = "0.0"
        End If
        If txtv.Text = "" Then
            txtv.Text = "0.0"
        End If
        If txtal.Text = "" Then
            txtal.Text = "0.0"
        End If
        If txtn.Text = "" Then
            txtn.Text = "0.0"
        End If
        If txth.Text = "" Then
            txth.Text = "0.0"
        End If
        If txtcnm.Text = "" Then
            txtcnm.Text = "0.0"
        End If

        cmd.CommandText = "insert into mm_spectro_results_new (date,time,shift,[cma/cms],heatnumber,sampletype,carbon,manganese,silicon,phosphorus,sulphur,chromium,nickle,copper,molybdenum,vanadium,alunimum,nitrogen,hydrogen,nicrmo,heatstatus,remarks)values('" & Format(CDate(txtdate.Text), "MM/dd/yyyy") & "','" & (txttime.Text) & "',
                                  '" & shiftrbl.SelectedValue & "','" & txtcmacms.Text & "','" & Convert.ToInt64(txtheat.Text) & "','" & rblsample.SelectedValue & "',
                                    '" & Convert.ToDouble(txtc.Text) & "',  '" & Convert.ToDouble(txtmn.Text) & "','" & Convert.ToDouble(txtsi.Text) & "','" & Convert.ToDouble(txtp.Text) & "',
                                  '" & Convert.ToDouble(txts.Text) & "','" & Convert.ToDouble(txtcr.Text) & "','" & Convert.ToDouble(txtni.Text) & "',
            '" & Convert.ToDouble(txtcu.Text) & "','" & Convert.ToDouble(txtmo.Text) & "','" & Convert.ToDouble(txtv.Text) & "','" & Convert.ToDouble(txtal.Text) & "',
                                  '" & Convert.ToDouble(txtn.Text) & "','" & Convert.ToDouble(txth.Text) & "','" & Convert.ToDouble(txtcnm.Text) & "',
                                    '" & status & "', '" & txtremarks.Text & "')"

        Try
            cmd.Connection.Open()

            Dim i As Integer = cmd.ExecuteNonQuery()

            If cmd.ExecuteNonQuery() = 1 Then done = True


        Catch exp As Exception
            'Throw New Exception(exp.Message)
        Finally

            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing

        End Try
        Return done
    End Function

    Public Function update()

        Dim done1 As Boolean
        'Try
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj

        Dim txt_date As Date = Format(CDate(txtdate.Text))
        'Dim txt_time As Date = Format(CDate(txttime.Text))
        Dim txt_shift As String = shiftrbl.SelectedValue
        Dim txt_sampetype As String = rblsample.SelectedValue
        Dim txt_c As String = Convert.ToDouble(txtc.Text)
        Dim txt_mn As String = Convert.ToDouble(txtmn.Text)
        Dim txt_si As String = Convert.ToDouble(txtsi.Text)
        Dim txt_p As String = Convert.ToDouble(txtp.Text)
        Dim txt_s As String = Convert.ToDouble(txts.Text)
        Dim txt_cr As String = Convert.ToDouble(txtcr.Text)
        Dim txt_ni As String = Convert.ToDouble(txtni.Text)
        Dim txt_cu As String = Convert.ToDouble(txtcu.Text)
        Dim txt_mo As String = Convert.ToDouble(txtmo.Text)
        Dim txt_v As String = Convert.ToDouble(txtv.Text)
        Dim txt_al As String = Convert.ToDouble(txtal.Text)
        Dim txt_n As String = Convert.ToDouble(txtn.Text)
        Dim txt_h As String = Convert.ToDouble(txth.Text)
        Dim txt_cnm As String = Convert.ToDouble(txtcnm.Text)

        cmd.CommandText = ("update mm_spectro_results_new Set carbon=@txt_c,manganese=@txt_mn,silicon=@txt_si,phosphorus=@txt_p,sulphur=@txt_s,chromium=@txt_cr,nickle=@txt_ni,copper=@txt_cu,molybdenum=@txt_mo,vanadium=@txt_v,alunimum=@txt_al,nitrogen=@txt_n,hydrogen=@txt_h,nicrmo=@txt_cnm where date =@txt_date and shift=@txt_shift and sampletype=@txt_sampetype")

        cmd.Parameters.AddWithValue("@txt_date", txt_date)
        ' cmd.Parameters.AddWithValue("@txt_time", txt_time)
        cmd.Parameters.AddWithValue("@txt_shift", txt_shift)
        cmd.Parameters.AddWithValue("@txt_sampetype", txt_sampetype)
        cmd.Parameters.AddWithValue("@txt_c", txt_c)
        cmd.Parameters.AddWithValue("@txt_mn", txt_mn)
        cmd.Parameters.AddWithValue("@txt_si", txt_si)
        cmd.Parameters.AddWithValue("@txt_p", txt_p)
        cmd.Parameters.AddWithValue("@txt_s", txt_s)
        cmd.Parameters.AddWithValue("@txt_cr", txt_cr)
        cmd.Parameters.AddWithValue("@txt_ni", txt_ni)
        cmd.Parameters.AddWithValue("@txt_cu", txt_cu)
        cmd.Parameters.AddWithValue("@txt_mo", txt_mo)
        cmd.Parameters.AddWithValue("@txt_v", txt_v)
        cmd.Parameters.AddWithValue("@txt_al", txt_al)
        cmd.Parameters.AddWithValue("@txt_n", txt_n)
        cmd.Parameters.AddWithValue("@txt_h", txt_h)
        cmd.Parameters.AddWithValue("@txt_cnm", txt_cnm)

        Try
            cmd.Connection.Open()

            If cmd.ExecuteNonQuery() = 1 Then done1 = True

        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally

            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing

        End Try
        Return done1

    End Function


    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click

        Dim Done As Boolean
        Dim done1 As Boolean
        Dim h As Integer

        Try

            h = updatecheck()

            If h > 0 Then

                done1 = update()

            Else

                Done = f1()

            End If

        Catch exp As Exception
            lblmsg.Text = exp.Message
        End Try
        If done1 Then
            lblmsg.Text = " Updation Successful !"
        ElseIf Done Then
            lblmsg.Text = "Successful Inserted!"
        End If

    End Sub
    Public Function checkheat()
        ' Dim i As Integer
        Dim hh As Integer = Convert.ToInt64(txtheat.Text)
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.CommandText = ("SELECT COUNT(*) FROM mm_vw_spectro_results_JMP where heat_number=@hh ")
        cmd.Parameters.AddWithValue("@hh", hh)

        Try
            cmd.Connection.Open()
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
    Public Function updatecheck()

        'Dim txt_date As Date = Format(CDate(txtdate.Text))
        Dim HeatNo As Integer = Convert.ToInt64(txtheat.Text)
        Dim SamType As String = rblsample.SelectedValue
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.Connection.Open()
        cmd.CommandText = ("SELECT COUNT(*) FROM mm_spectro_results_new where heatnumber=@HeatNo and sampletype=@SamType ")
        cmd.Parameters.AddWithValue("@HeatNo", HeatNo)
        cmd.Parameters.AddWithValue("@SamType", SamType)

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

    Protected Sub txtheat_TextChanged(sender As Object, e As EventArgs) Handles txtheat.TextChanged
        If txtheat.Text = "" Then
            lblmsg.Text = "please enter heat number"
        End If
        Dim n As Integer = checkheat()

        If n = 0 Then
            lblmsg.Text = "invalid heat"
        Else
            lblmsg.Text = ""
        End If
    End Sub


    Protected Sub txtdate_TextChanged(sender As Object, e As EventArgs) Handles txtdate.TextChanged
        getdata()
    End Sub
    Private Sub getdata()
        Dim sdate As String = Format(CDate(txtdate.Text), "MM/dd/yyyy")
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.CommandText = ("SELECT convert(varchar, date, 105) Date,time Time,shift,[cma/cms] Incharge, heatnumber HeatNo, sampletype SType, carbon C, manganese Mn, silicon Si, phosphorus P, sulphur S, chromium Cr, nickle Ni, copper Cu, molybdenum Mo, vanadium V, alunimum Al , hydrogen H, nitrogen N, nicrmo, heatstatus HSts, remarks Remarks from  mm_spectro_results_new where date=@sdate order by heatnumber, time  ")
        cmd.Parameters.AddWithValue("@sdate", sdate)

        Try
            cmd.Connection.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            data1.DataSource = dr
            data1.DataBind()
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally

            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing

        End Try

    End Sub

    Protected Sub data1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles data1.SelectedIndexChanged

        txtdate.Text = Trim(data1.SelectedRow.Cells(2).Text)
        txttime.Text = Trim(data1.SelectedRow.Cells(3).Text)
        shiftrbl.SelectedValue = Trim(data1.SelectedRow.Cells(4).Text)
        txtcmacms.Text = Trim(data1.SelectedRow.Cells(5).Text)
        txtheat.Text = Trim(data1.SelectedRow.Cells(6).Text)
        rblsample.SelectedValue = Trim(data1.SelectedRow.Cells(7).Text)
        txtc.Text = Trim(data1.SelectedRow.Cells(8).Text)
        txtmn.Text = Trim(data1.SelectedRow.Cells(9).Text)
        txtsi.Text = Trim(data1.SelectedRow.Cells(10).Text)
        txtp.Text = Trim(data1.SelectedRow.Cells(11).Text)
        txts.Text = Trim(data1.SelectedRow.Cells(12).Text)
        txtcr.Text = Trim(data1.SelectedRow.Cells(13).Text)
        txtni.Text = Trim(data1.SelectedRow.Cells(14).Text)
        txtcu.Text = Trim(data1.SelectedRow.Cells(15).Text)
        txtmo.Text = Trim(data1.SelectedRow.Cells(16).Text)
        txtv.Text = Trim(data1.SelectedRow.Cells(17).Text)
        txtal.Text = Trim(data1.SelectedRow.Cells(18).Text)
        txth.Text = Trim(data1.SelectedRow.Cells(19).Text)
        txtn.Text = Trim(data1.SelectedRow.Cells(20).Text)
        txtcnm.Text = Trim(data1.SelectedRow.Cells(21).Text)
        If rblsample.SelectedItem.Value = "JMP" Then
            ddljmp.SelectedValue = Trim(data1.SelectedRow.Cells(22).Text)
        ElseIf rblsample.SelectedItem.Value = "product" Then
            ddlproduct.SelectedValue = Trim(data1.SelectedRow.Cells(22).Text)
        End If
    End Sub

    Protected Sub B2_Click(sender As Object, e As EventArgs) Handles B2.Click
        If DataGrid1.Items.Count > 0 Then
            Dim prevstate As Boolean = Me.EnableViewState
            Dim tw As New System.IO.StringWriter()
            Dim hw As New System.Web.UI.HtmlTextWriter(tw)
            Try
                Response.ContentType = "application/vnd.ms_excel"
                Response.Charset = ""
                Me.EnableViewState = False
                DataGrid1.RenderControl(hw)
                Response.Write(tw.ToString)
                Response.End()
                Me.EnableViewState = prevstate
            Catch exp As Exception
                lblmsg.Text = exp.Message
            Finally
                prevstate = Nothing
                tw = Nothing
                hw = Nothing
            End Try
        Else
            lblmsg.Text = "No Data in Grid to export !"
        End If
    End Sub

    Private Sub getheatdetails()
        Dim hh = Convert.ToInt64(txtheat.Text)
        Dim cmdd As New SqlCommand
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.CommandText = " select carbon, manganese , silicon, phosphorus, sulphur,chromium, nickle , copper,molybdenum,vanadium,alunimum,nitrogen,hydrogen,nicrmo from mm_spectro_results_new where heatnumber=@hh "
        cmd.Parameters.AddWithValue("@hh", hh)

        Try
            cmd.Connection.Open()
            Using sdr As SqlDataReader = cmd.ExecuteReader()
                sdr.Read()
                txtc.Text = sdr("carbon").ToString()
                txtmn.Text = sdr("manganese").ToString()
                txtsi.Text = sdr("silicon").ToString()
                txtp.Text = sdr("phosphorus").ToString()
                txts.Text = sdr("sulphur").ToString()
                txtcr.Text = sdr("chromium").ToString()
                txtni.Text = sdr("nickle").ToString()
                txtcu.Text = sdr("copper").ToString()
                txtmo.Text = sdr("molybdenum").ToString()
                txtv.Text = sdr("vanadium").ToString()
                txtal.Text = sdr("alunimum").ToString()
                txtn.Text = sdr("nitrogen").ToString()
                txth.Text = sdr("hydrogen").ToString()
                txtcnm.Text = sdr("nicrmo").ToString()
            End Using

        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally

            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing

        End Try

    End Sub
    Private Sub CalTotalCrNiMo()
        Dim total As Double
        total = 0
        If txtcr.Text <> "" And IsNumeric(txtcr.Text) Then total += CDbl(txtcr.Text)
        If txtni.Text <> "" And IsNumeric(txtni.Text) Then total += CDbl(txtni.Text)
        If txtmo.Text <> "" And IsNumeric(txtmo.Text) Then total += CDbl(txtmo.Text)
        txtcnm.Text = CStr(total)
        total = Nothing
    End Sub

    Protected Sub txtcr_TextChanged(sender As Object, e As EventArgs) Handles txtcr.TextChanged
        CalTotalCrNiMo()
        SetFocus(txtcr)
    End Sub

    Protected Sub txtni_TextChanged(sender As Object, e As EventArgs) Handles txtni.TextChanged
        CalTotalCrNiMo()
        SetFocus(txtni)
    End Sub

    Protected Sub txtmo_TextChanged(sender As Object, e As EventArgs) Handles txtmo.TextChanged
        CalTotalCrNiMo()
        SetFocus(txtmo)
    End Sub

    Protected Sub B1_Click(sender As Object, e As EventArgs) Handles B1.Click
        lblmsg.Text = ""
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            panel6.Visible = True
            DataGrid1.DataSource = metLab.tables.SpectroDetails(CLng(txtfheat.Text), CLng(txttheat.Text), rblmetal.SelectedItem.Text)
            DataGrid1.DataBind()

        Catch exp As Exception
            lblmsg.Text = exp.Message
        End Try
    End Sub
    Protected Sub OnRowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            TryCast(e.Row.FindControl("lblRowNumber"), Label).Text = (e.Row.RowIndex + 1).ToString()
        End If
    End Sub
End Class