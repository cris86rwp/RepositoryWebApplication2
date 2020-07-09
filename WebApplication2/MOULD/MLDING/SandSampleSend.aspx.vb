Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports System.Data
Imports System.DateTime
Imports System.Web.UI.WebControls

Public Class SandSampleSend

    Inherits System.Web.UI.Page

    Protected WithEvents rblshift As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rbl_vw_Batch As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents sanddate As System.Web.UI.WebControls.TextBox
    'Protected WithEvents Expected_testdate As System.Web.UI.WebControls.TextBox
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents DDLsample As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Vw_batch_no As System.Web.UI.WebControls.DataGrid

    Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj

    Dim i As Integer
    Dim strsql As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then

            sanddate.Text = CDate(Now.Date)
            Expected_testdate.Text = CDate(Now.Date)
            Try

                SetScreen()
            Catch exp As Exception
                Label1.Text = exp.Message
            End Try
        End If
    End Sub
    Private Sub SetScreen()
        Panel1.Visible = True

        Vw_batch_no.DataSource = Nothing
        Vw_batch_no.DataBind()
    End Sub

    Private Sub BindDataGrid(ByVal strArg As String)
        Dim objCmd As SqlCommand
        Dim objDr2 As SqlDataReader
        Dim con As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")

        If con.State = ConnectionState.Closed Then
            con.Open()
        Else
            con.Close()
            con.Open()
        End If
        Dim strsql As String
        Try
            objCmd = New SqlCommand(strArg, con)
            objDr2 = objCmd.ExecuteReader()
            Dim arr2() As String
            Vw_batch_no.DataSource = arr2
            Vw_batch_no.DataBind()
            Vw_batch_no.DataSource = objDr2
            Vw_batch_no.DataBind()


        Catch exp As SqlException
            strsql = exp.StackTrace
            Label1.Text = "Line : " & Mid(strsql, InStr(strsql, "line") + 5) & " Message : " + exp.Message

        Catch exp As Exception
            strsql = exp.StackTrace
            Label1.Text = "Line : " & Mid(strsql, InStr(strsql, "line") + 5) & " Message : " + exp.Message
        End Try

        con.Close()

    End Sub
    Protected Sub rblshift_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblshift.SelectedIndexChanged

        SetScreen()
        Dim sqlstr1 As String
        sqlstr1 = "select date, shift, BatchSample1, BatchSample2, BatchSample3, BatchSample4, BatchSample5, BatchSample6,BatchSample7,BatchSample8,BatchSample9,BatchSample10 from mm_sand_batches where date='" & Format(CDate(sanddate.Text), "MM/dd/yyyy") & "'  and shift='" & rblshift.SelectedValue.ToString() & "'"
        Call BindDataGrid(sqlstr1)
    End Sub

    Protected Sub Vw_batch_no_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Vw_batch_no.SelectedIndexChanged
        Vw_batch_no.SelectedIndex = i

        Dim arr(20) As ListItem     'If u put arr() in Place of arr() or if i put new keyword it giving me probs.

        arr(0) = New ListItem
        arr(0).Text = (Vw_batch_no.Items(i).Cells(3).Text)
        arr(0).Value = (Vw_batch_no.Items(i).Cells(3).Text)

        arr(1) = New ListItem
        arr(1).Text = (Vw_batch_no.Items(i).Cells(4).Text)
        arr(1).Value = (Vw_batch_no.Items(i).Cells(4).Text)

        arr(2) = New ListItem
        arr(2).Text = (Vw_batch_no.Items(i).Cells(5).Text)
        arr(2).Value = (Vw_batch_no.Items(i).Cells(5).Text)

        arr(3) = New ListItem
        arr(3).Text = (Vw_batch_no.Items(i).Cells(6).Text)
        arr(3).Value = (Vw_batch_no.Items(i).Cells(6).Text)

        arr(4) = New ListItem
        arr(4).Text = (Vw_batch_no.Items(i).Cells(7).Text)
        arr(4).Value = (Vw_batch_no.Items(i).Cells(7).Text)

        arr(5) = New ListItem
        arr(5).Text = (Vw_batch_no.Items(i).Cells(8).Text)
        arr(5).Value = (Vw_batch_no.Items(i).Cells(8).Text)

        arr(6) = New ListItem
        arr(6).Text = (Vw_batch_no.Items(i).Cells(9).Text)
        arr(6).Value = (Vw_batch_no.Items(i).Cells(9).Text)

        arr(7) = New ListItem
        arr(7).Text = (Vw_batch_no.Items(i).Cells(10).Text)
        arr(7).Value = (Vw_batch_no.Items(i).Cells(10).Text)

        arr(8) = New ListItem
        arr(8).Text = (Vw_batch_no.Items(i).Cells(11).Text)
        arr(8).Value = (Vw_batch_no.Items(i).Cells(11).Text)

        arr(9) = New ListItem
        arr(9).Text = (Vw_batch_no.Items(i).Cells(12).Text)
        arr(9).Value = (Vw_batch_no.Items(i).Cells(12).Text)
        'Response.Write(arr(0))

        DDLsample.Items.Add(arr(0))
        DDLsample.Items.Add(arr(1))
        DDLsample.Items.Add(arr(2))
        DDLsample.Items.Add(arr(3))
        DDLsample.Items.Add(arr(4))
        DDLsample.Items.Add(arr(5))
        DDLsample.Items.Add(arr(6))
        DDLsample.Items.Add(arr(7))
        DDLsample.Items.Add(arr(8))
        DDLsample.Items.Add(arr(9))
    End Sub

    Private Sub Vw_batch_no_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles Vw_batch_no.ItemCommand
        i = e.Item.ItemIndex()
    End Sub

    'Protected Sub Btnsave_Click(sender As Object, e As EventArgs) Handles Btnsave.Click
    '    Dim done As Boolean
    '    Try

    '    Catch exp As Exception
    '        Throw New Exception(exp.Message)
    '    End Try
    '    done = True
    'End Sub

    Public Function formclear()
        'rblshift.Text = ""
        'sanddate.Text = ""
        Label2.Text = ""
        'Label1.Text = ""
        DDLsample.ClearSelection()
    End Function

    Protected Sub Btnclear_Click(sender As Object, e As EventArgs) Handles Btnclear.Click
        formclear()
    End Sub

    ' Protected Sub btn_batch_Click(sender As Object, e As EventArgs) Handles btn_batch.Click
    'Dim donne As Boolean
    'Label2.Text = ""
    'Try
    '    cmd.Connection.Open()
    '    cmd.CommandText = "INSERT INTO mm_sand_system(sand_date,shift_code,sample_batch_number,expected_test_date) VALUES ('" & Format(CDate(sanddate.Text), "MM/dd/yyyy") & "','" & rblshift.SelectedValue.ToString() & "','" & DDLsample.SelectedItem.Value & "','" & Format(CDate(Expected_testdate.Text), "MM/dd/yyyy") & "')"
    '    cmd.ExecuteNonQuery()
    '    If cmd.ExecuteNonQuery() = 1 Then
    '        donne = True
    '        Label2.Text = "Data inserted sucessfully!!"
    '    End If
    'Catch ex As Exception
    '    'Throw New Exception(ex.Message)
    'Finally
    '    cmd.Connection.Close()
    'End Try

    'If donne = True Then
    '    Label2.Text = "Data inserted sucessfully!!"
    '    Label2.Text = ""
    'Else
    '    Label2.Text = "Already Data inserted!!"
    '    Label2.Text = ""
    '    'formclear()
    'End If

    'Label2.Text = ""
    ''Response.Redirect("Data inserted sucessfully")

    'Label2.Text = ""
    '' formclear()
    'End Sub

    Protected Sub btn_batch_Click(sender As Object, e As EventArgs) Handles btn_batch.Click
        Dim Donne As Boolean
        Try
            Donne = save()
            Label1.Text = ""
            If Donne Then
                Label1.Text = "Inserted sucessfully!!"
                formclear()
            End If
        Catch
            Label1.Text = "Already sample inserted for testing"
        End Try
    End Sub

    Public Function save()
        Dim donne As Boolean
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.CommandText = "INSERT INTO mm_sand_system(sand_date,shift_code,sample_batch_number,expected_test_date) VALUES ('" & Format(CDate(sanddate.Text), "MM/dd/yyyy") & "','" & rblshift.SelectedValue.ToString() & "','" & DDLsample.SelectedItem.Value & "','" & Format(CDate(Expected_testdate.Text), "MM/dd/yyyy") & "')"
        Try
            cmd.Connection.Open()

            If cmd.ExecuteNonQuery() = 1 Then donne = True

        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally

            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing

        End Try
        Return donne
    End Function

    Protected Sub DDLsample_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDLsample.SelectedIndexChanged

    End Sub
End Class