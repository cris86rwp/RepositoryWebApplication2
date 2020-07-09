Imports System.Data.SqlClient
Imports System.Data

Public Class WFPSWarpageDetails
    Inherits System.Web.UI.Page
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents TxtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtTime As System.Web.UI.WebControls.TextBox
    Protected WithEvents DDLshift As System.Web.UI.WebControls.DropDownList
    Protected WithEvents TxtOperator As System.Web.UI.WebControls.TextBox
    Protected WithEvents txt_sic As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtHeat_No As System.Web.UI.WebControls.TextBox
    Protected WithEvents DDLMouldNo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DDLWPageStatus As System.Web.UI.WebControls.DropDownList
    Protected WithEvents TxtWarpage As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents BtnSave As System.Web.UI.WebControls.Button
    Protected WithEvents BtnClear As System.Web.UI.WebControls.Button
    Protected WithEvents BtnExit As System.Web.UI.WebControls.Button

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
        If Page.IsPostBack = False Then
            Try
                GetMouldNo()
                getDateShift()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Protected Sub TxtOperator_TextChanged(sender As Object, e As EventArgs) Handles TxtOperator.TextChanged

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
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj

        cmd.CommandText = "Insert INTO mm_warpage (date,time, shift_code,operator_code,SIC, heat_number, mould_no, warpage_value, status, remark)   
                         VALUES ('" & Format(CDate(TxtDate.Text), "MM/dd/yyyy") & "', '" & TxtTime.Text & "', '" & DDLshift.SelectedItem.Value & "' , '" & TxtOperator.Text & "','" & txt_sic.Text & "','" & TxtHeat_No.Text & "', 
'" & DDLMouldNo.SelectedItem.Value & "','" & TxtWarpage.Text & "','" & DDLWPageStatus.SelectedItem.Value & "','" & TxtRemarks.Text & "')"

        Try
            cmd.Connection.Open()

            If cmd.ExecuteNonQuery() = 1 Then done = True

        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            cmd = Nothing

        End Try
        Return done
    End Function
    Protected Sub Btnclear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        TxtDate.Text = ""
        TxtOperator.Text = ""
        txt_sic.Text = ""
        TxtWarpage.Text = ""
        TxtHeat_No.Text = ""
        TxtTime.Text = ""
        TxtRemarks.Text = ""
        Label1.Text = ""

    End Sub

    Public Function GetMouldNo()
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.Connection.Open()
        Dim heat As Integer = Val(TxtHeat_No.Text)
        cmd.CommandText = "Select engraved_number from mm_pouring  where heat_number =@heat"
        cmd.Parameters.AddWithValue("@heat", heat)
        'cmd.ExecuteScalar()
        DDLMouldNo.DataSource = cmd.ExecuteReader()
        DDLMouldNo.DataTextField = "engraved_number"
        DDLMouldNo.DataBind()
    End Function

    Public Sub getDateShift()
        If Now.Hour = 0 OrElse Now.Hour = 1 OrElse Now.Hour = 2 OrElse Now.Hour = 3 OrElse Now.Hour = 4 OrElse Now.Hour = 5 Then
            TxtDate.Text = CDate(Now.Date.AddDays(-1))
        Else
            TxtDate.Text = CDate(Now.Date)
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
        GetMouldNo()
    End Sub
End Class
