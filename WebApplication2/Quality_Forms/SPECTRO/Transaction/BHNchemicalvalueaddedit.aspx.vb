Imports System.Data
Imports System.Data.SqlClient
Public Class BHNchemicalvalueaddedit
    Inherits System.Web.UI.Page
    Protected WithEvents panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents panel2 As System.Web.UI.WebControls.Panel
    Protected WithEvents panel3 As System.Web.UI.WebControls.Panel
    Protected WithEvents pane4 As System.Web.UI.WebControls.Panel
    Protected WithEvents pane5 As System.Web.UI.WebControls.Panel
    Protected WithEvents lblmsg As System.Web.UI.WebControls.Label
    Protected WithEvents rblsample As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblmode As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtdate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txttime As System.Web.UI.WebControls.TextBox
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
    Protected WithEvents txtheat As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtlab As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtinsp As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtlabb As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtinspp As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtwhltype As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlwheel As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnclear As System.Web.UI.WebControls.Button
    Protected WithEvents btnsave As System.Web.UI.WebControls.Button





    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            txtdate.Text = DateTime.Now.Date
            txttime.Text = DateTime.Now.ToLongTimeString

            panel2.Visible = False
            panel3.Visible = False
            pane4.Visible = False
            pane5.Visible = False

            If rblsample.SelectedItem.Value = "JMP" Then
                panel2.Visible = True
                panel3.Visible = False
                pane4.Visible = True
                txtinsp.Text = "078844"

                pane5.Visible = True
                'setpanel()

            Else
                panel2.Visible = False
                panel3.Visible = True

                ' getWheelNumbers()
                txtinspp.Text = "078844"
                txtheat.Text = "0"
                pane4.Visible = True
                pane5.Visible = True
                'setpanel()
            End If




        Catch exp As Exception
            lblmsg.Text = exp.Message
        End Try
    End Sub
    Private Sub setpanel()
        txtc.Text = "0.0"
        txtmn.Text = "0.0"
        txtsi.Text = "0.0"
        txtp.Text = "0.0"
        txts.Text = "0.0"
        txtcr.Text = "0.0"
        txtni.Text = "0.0"
        txtcu.Text = "0.0"
        txtmo.Text = "0.0"
        txtv.Text = "0.0"
        txtal.Text = "0.0"
        txtn.Text = "0.0"
        txth.Text = "0.0"
        txtcnm.Text = "0.0"
    End Sub
    'Private Sub getWheelNumbers()
    '    ddlwheel.Items.Clear()
    '    Dim dt As New DataTable()

    '    Try
    '        dt = metLab.tables.GetWheelNumbers(rblmode.SelectedItem.Value)
    '        ddlwheel.DataSource = dt
    '        ddlwheel.DataTextField = dt.Columns(0).ColumnName
    '        ddlwheel.DataValueField = dt.Columns(1).ColumnName
    '        ddlwheel.DataBind()
    '        ddlwheel.Items.Insert(0, "Select")
    '        ViewState("vdtw") = dt
    '    Catch exp As Exception
    '        Throw New Exception(exp.Message)
    '    Finally
    '        dt.Dispose()
    '    End Try
    'End Sub

    Protected Sub txtheat_TextChanged(sender As Object, e As EventArgs) Handles txtheat.TextChanged
        Dim n As Integer = checkheat()
        If n = 0 Then
            lblmsg.Text = "invalid heat"
        End If
    End Sub
    Public Function checkheat()
        ' Dim i As Integer
        Dim hh As Integer = Convert.ToInt64(txtheat.Text)
        Dim con As New SqlConnection("Data Source=192.168.0.125;Initial Catalog=wapdev;Persist Security Info=True;User ID=sa;Password=sa")
        con.Open()
        Dim cmd As New SqlCommand("SELECT COUNT(*) FROM mm_heatsheet_header where heat_number=@hh ", con)
        cmd.Parameters.AddWithValue("@hh", hh)
        Dim i As Integer = Convert.ToInt32(cmd.ExecuteScalar())
        cmd = Nothing
        con.Close()
        Return i
    End Function

    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Dim Done, Donne As Boolean
        Try
            Done = f1()
            If rblsample.SelectedItem.Value = "product" Then
                Donne = f2()
            Else
                Donne = f3()
            End If

        Catch exp As Exception
            lblmsg.Text = exp.Message
        End Try
        If Done And Donne Then
            lblmsg.Text = " Updation Successful !"
        End If

    End Sub
    Public Function f1()
        Dim done As Boolean
        Dim con As New SqlConnection
        Dim cmd, cmdd As New SqlCommand
        Try
            con.ConnectionString = "Data Source=192.168.0.125;Initial Catalog=wapdev;Persist Security Info=True;User ID=sa;Password=sa"
            con.Open()
            cmd.Connection = con

            cmd.CommandText = "insert into ms_wheel_hardness_empcode_nnew values('" & txtlab.Text & "' , '" & txtinsp.Text & "' , '" & Convert.ToDateTime(txtdate.Text) & "' , '" & Convert.ToDateTime(Date.Now) & "' ,   '" & shiftrbl.SelectedItem.Value & "' , '" & txtcmacms.Text & "' , '" & rblsample.SelectedItem.Value & "' )"


            If cmd.ExecuteNonQuery() = 1 Then done = True

        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            con.Close()
        End Try
        Return done
    End Function
    Public Function f2()
        Dim done As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
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
        Try
            con.ConnectionString = "Data Source=192.168.0.125;Initial Catalog=wapdev;Persist Security Info=True;User ID=sa;Password=sa"
            con.Open()
            cmd.Connection = con

            Dim wheel As String = ddlwheel.SelectedItem.Value

            cmd.CommandText = " insert into ms_wheel_hardness_chemical_nnew values('" & txtlabb.Text & "','" & wheel & "','" & Convert.ToInt64(txtheat.Text) & "','" & Convert.ToDecimal(txtc.Text) & "',  '" & Convert.ToDecimal(txtmn.Text) & "','" & Convert.ToDecimal(txtsi.Text) & "','" & Convert.ToDecimal(txtp.Text) & "',
                                  '" & Convert.ToDecimal(txts.Text) & "','" & Convert.ToDecimal(txtcr.Text) & "','" & Convert.ToDecimal(txtni.Text) & "',
            '" & Convert.ToDecimal(txtcu.Text) & "','" & Convert.ToDecimal(txtmo.Text) & "','" & Convert.ToDecimal(txtv.Text) & "','" & Convert.ToDecimal(txtal.Text) & "',
                                  '" & Convert.ToDecimal(txtn.Text) & "','" & Convert.ToDecimal(txth.Text) & "','" & Convert.ToDecimal(txtcnm.Text) & "')"
            If cmd.ExecuteNonQuery() = 1 Then done = True

        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            con.Close()
        End Try
        Return done
    End Function
    Public Function f3()
        Dim done As Boolean
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
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
        Try
            con.ConnectionString = "Data Source=192.168.0.125;Initial Catalog=wapdev;Persist Security Info=True;User ID=sa;Password=sa"
            con.Open()
            cmd.Connection = con



            cmd.CommandText = " insert into ms_wheel_hardness_chemical_nnew values('" & txtlab.Text & "','" & "null" & "','" & Convert.ToInt64(txtheat.Text) & "','" & Convert.ToDecimal(txtc.Text) & "',  '" & Convert.ToDecimal(txtmn.Text) & "','" & Convert.ToDecimal(txtsi.Text) & "','" & Convert.ToDecimal(txtp.Text) & "',
                                  '" & Convert.ToDecimal(txts.Text) & "','" & Convert.ToDecimal(txtcr.Text) & "','" & Convert.ToDecimal(txtni.Text) & "',
            '" & Convert.ToDecimal(txtcu.Text) & "','" & Convert.ToDecimal(txtmo.Text) & "','" & Convert.ToDecimal(txtv.Text) & "','" & Convert.ToDecimal(txtal.Text) & "',
                                  '" & Convert.ToDecimal(txtn.Text) & "','" & Convert.ToDecimal(txth.Text) & "','" & Convert.ToDecimal(txtcnm.Text) & "')"
            If cmd.ExecuteNonQuery() = 1 Then done = True

        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            con.Close()
        End Try
        Return done
    End Function

    Protected Sub ddlwheel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlwheel.SelectedIndexChanged
        loadlab()
        loadtype()

    End Sub


    Private Sub loadlab()

        Dim wheel As String = ddlwheel.SelectedItem.Value

        Dim con As New SqlConnection("Data Source=192.168.0.125;Initial Catalog=wapdev;Persist Security Info=True;User ID=sa;Password=sa")
        con.Open()
        Dim cmd As New SqlCommand("select lab_number  from ms_wheel_hardness_sample where (convert(varchar,wheel_number)+'/'+ convert(varchar,heat_number)) =@wheel", con)
        cmd.Parameters.AddWithValue("@wheel", wheel)

        ' Dim i As String = (cmd.ExecuteScalar())
        txtlabb.Text = (cmd.ExecuteScalar())
        cmd = Nothing
        con.Close()
    End Sub
    Private Sub loadtype()
        Dim wheel As String = ddlwheel.SelectedItem.Value

        Dim con As New SqlConnection("Data Source=192.168.0.125;Initial Catalog=wapdev;Persist Security Info=True;User ID=sa;Password=sa")
        con.Open()
        Dim cmd As New SqlCommand("select wheel_type  from ms_wheel_hardness_sample where (convert(varchar,wheel_number)+'/'+ convert(varchar,heat_number)) =@wheel", con)
        cmd.Parameters.AddWithValue("@wheel", wheel)

        ' Dim i As String = (cmd.ExecuteScalar())
        txtwhltype.Text = (cmd.ExecuteScalar())
        cmd = Nothing
        con.Close()
    End Sub


End Class