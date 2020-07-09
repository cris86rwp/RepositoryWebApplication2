Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports System.DateTime
Public Class HSDRTSValues
    Inherits System.Web.UI.Page
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblArea As System.Web.UI.WebControls.RadioButtonList
    'Protected WithEvents RadioButtonList1 As System.Web.UI.WebControls.RadioButtonList
    ' Protected WithEvents RadioButtonList2 As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtChallanNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtChallanDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtValue As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents dgMeterRdg As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgSavedData As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Panel5 As System.Web.UI.WebControls.Panel
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Panel4 As System.Web.UI.WebControls.Panel
    Protected WithEvents Panel6 As System.Web.UI.WebControls.Panel
    Protected WithEvents Panel7 As System.Web.UI.WebControls.Panel

    Protected WithEvents Panel3 As System.Web.UI.WebControls.Panel

    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents CheckBox1 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents txtInitial As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMax As System.Web.UI.WebControls.TextBox
    Protected WithEvents Panel2 As System.Web.UI.WebControls.Panel
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList


#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub
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

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Page.IsPostBack = False Then
            txtDate.Text = Now.Date
            Try
                GetGridData()
                GetValue()
                Setfocus(txtValue)
                Panel2.Visible = CheckBox1.Checked
            Catch exp As Exception
                ' txtDate.Text = ""
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    'Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    'Put user code to initialize the page here
    '    If Not Page.IsPostBack Then
    '        txtDate.Text = Now.Date
    '        ' txtDate.Text = "2019-08-22"
    '        Try
    '            GetGridData()
    '            GetValue()
    '            Setfocus(txtValue)
    '            Panel2.Visible = CheckBox1.Checked
    '        Catch exp As Exception
    '            txtDate.Text = ""
    '            lblMessage.Text = exp.Message
    '        End Try
    '    End If
    'End Sub

    Private Sub Setfocus(ByVal ctrl As Control)
        'Define the JavaScript function for the specefied control.
        Dim focusScript As String = "<script language = 'javascript'>" &
        "document.getElementById('" + ctrl.ClientID &
        "').focus();</script>"
        'Add the JavaScript code to the page.
        Page.RegisterStartupScript("FocusScript", focusScript)
        ' MarkControlsAsSelected(ctrl)
    End Sub
    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        lblMessage.Text = ""
        Dim dt As New Date()
        Try
            Panel2.Visible = CheckBox1.Checked
            dt = CDate(txtDate.Text)
            txtDate.Text = dt
            GetGridData()
            GetValue()
        Catch exp As Exception
            txtDate.Text = ""
            lblMessage.Text = exp.Message
        End Try
    End Sub
    'Private Sub GetGridData()
    '    Dim objCmd As SqlCommand
    '    Dim objDr As SqlDataReader
    '    Dim con As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")

    '    If con.State = ConnectionState.Closed Then
    '        con.Open()
    '    Else
    '        con.Close()
    '        con.Open()
    '    End If
    '    Dim strSql As String
    '    Try
    '        Dim da As SqlClient.SqlCommand = rwfGen.Connection.CmdObj

    '        Dim strArg As String

    '        'da.Parameters.Add("@Item", SqlDbType.VarChar, 50).Value = Item

    '        objCmd = New SqlCommand(strArg, con)
    '        'If rblArea.SelectedItem.Value Then
    '        strArg = "select * from ms_HSDValuesRTSHOPRTSHOP  where ItemDate='" & Format(CDate(txtDate.Text), "MM/dd/yyyy") & "' and Item= '" & rblArea.SelectedItem.Value & "'"
    '        '  End If
    '        objDr = objCmd.ExecuteReader()
    '        Dim arr() As String
    '        DataGrid1.DataSource = arr
    '        DataGrid1.DataBind()
    '        DataGrid1.DataSource = objDr
    '        DataGrid1.DataBind()
    '    Catch exp As SqlException
    '        strSql = exp.StackTrace
    '        lblMessage.Text = "Line :  " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message

    '    Catch exp As Exception
    '        strSql = exp.StackTrace
    '        lblMessage.Text = "Line  " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message
    '    End Try

    '    con.Close()

    'End Sub
    Private Sub GetGridData()
        Dim objCmd As SqlCommand
        Dim objDr As SqlDataReader
        Dim con As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")

        If con.State = ConnectionState.Closed Then
            con.Open()
        Else
            con.Close()
            con.Open()
        End If
        Dim strSql As String
        Try
            Dim strArg As String

            strArg = "select * from ms_HSDValuesRTSHOP  where ItemDate='" & Format(CDate(txtDate.Text), "MM/dd/yyyy") & "' and Item= '" & rblArea.SelectedItem.Value & "'"
            objCmd = New SqlCommand(strArg, con)

            objDr = objCmd.ExecuteReader()
            Dim arr() As String
            DataGrid1.DataSource = arr
            DataGrid1.DataBind()
            DataGrid1.DataSource = objDr
            DataGrid1.DataBind()
        Catch exp As SqlException
            strSql = exp.StackTrace
            lblMessage.Text = "Line :  " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message

        Catch exp As Exception
            strSql = exp.StackTrace
            lblMessage.Text = "Line  " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message
        End Try

        con.Close()

    End Sub

    Protected Sub DataGrid1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DataGrid1.SelectedIndexChanged
        Dim i As String
        DataGrid1.SelectedIndex = i
        txtDate.Text = Trim(DataGrid1.Items(i).Cells(1).Text)
        txtValue.Text = DataGrid1.Items(i).Cells(2).Text
        txtRemarks.Text = DataGrid1.Items(i).Cells(3).Text
        rblArea.SelectedValue = DataGrid1.Items(i).Cells(4).Text
        txtChallanNumber.Text = Trim(DataGrid1.Items(i).Cells(5).Text)
        txtChallanDate.Text = DataGrid1.Items(i).Cells(6).Text


    End Sub

    Private Sub DataGrid1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.ItemCommand
        Dim i As String
        i = e.Item.ItemIndex()
    End Sub
    'Panel2.Visible = CheckBox1.Checked
    'dgSavedData.DataSource = Nothing
    'dgSavedData.DataBind()
    'dgMeterRdg.DataSource = Nothing
    'dgMeterRdg.DataBind()
    'Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
    'Dim ds As New DataSet()
    'Dim a, b As String
    'da.SelectCommand.Parameters.Add("@dt", SqlDbType.SmallDateTime, 4).Value = CDate(txtDate.Text).AddDays(-1)
    'da.SelectCommand.Parameters.Add("@dto", SqlDbType.SmallDateTime, 4).Value = CDate(txtDate.Text)
    'da.SelectCommand.CommandText = " select HSDItemDate , LPH , NF , DF , SP , DSAC , RHF , Total , Remarks " &
    '                " Differenc , TANK1 , TANK2  , TankTOTAL , ConsDIP , RT , DG , recpofWag , RecpQtyinLts , SFM , RFM  , ConsFM from ms_vw_HSDValuesNew where  HSDItemDate between  @dt and @dto order by HSDItemDate  ;" &
    '                " select HSDItemDate , LPH , NF , DF , SP , DSAC , RHF , Remarks , TANK1 , TANK2 , RT , DG , recpofWag , RecpQtyinLts , SFM , RFM from ms_vw_HSDValues where  HSDItemDate between  @dt and @dto order by HSDItemDate  ;"
    'Try
    '    da.Fill(ds)
    '    dgSavedData.DataSource = ds.Tables(0).Copy
    '    dgSavedData.DataBind()
    '    dgMeterRdg.DataSource = ds.Tables(1).Copy
    '    dgMeterRdg.DataBind()
    '    Setfocus(txtValue)
    'Catch exp As Exception
    '    Throw New Exception(exp.Message)
    'Finally
    '    da.Dispose()
    '    ds.Dispose()
    'End Try
    'End Sub
    Private Sub clear()
        txtValue.Text = ""
        txtRemarks.Text = ""
    End Sub
    'Private Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
    '    lblMessage.Text = ""

    '    Try
    '        'GetValue()
    '        GetGridData()

    '    Catch exp As Exception
    '        lblMessage.Text = exp.Message
    '    End Try
    'End Sub
    Private Sub rblArea_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblArea.SelectedIndexChanged
        lblMessage.Text = ""

        Try
            GetValue()
            GetGridData()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub


    Private Sub GetValue()
        Panel2.Visible = CheckBox1.Checked
        clear()
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()
        Dim data As New DataTable()
        da.SelectCommand.Parameters.Add("@dt", SqlDbType.SmallDateTime, 4).Value = CDate(txtDate.Text)
        'If RadioButtonList1.SelectedValue = "LPG" Then
        da.SelectCommand.Parameters.Add("@Item", SqlDbType.VarChar, 50).Value = rblArea.SelectedItem.Value

        'Else
        '    da.SelectCommand.Parameters.Add("@Item", SqlDbType.VarChar, 50).Value = RadioButtonList2.SelectedItem.Text.Trim
        'End If

        da.SelectCommand.CommandText = " select * from ms_HSDValuesRTSHOP where  ItemDate = @dt and Item=@Item  ;"
        Try
            da.Fill(ds)
            data = ds.Tables(0).Copy
            If data.Rows.Count > 0 Then
                txtValue.Text = IIf(IsDBNull(data.Rows(0)(2)), 0, data.Rows(0)(2))
                txtRemarks.Text = IIf(IsDBNull(data.Rows(0)(4)), "", data.Rows(0)(4))
            End If
            Setfocus(txtValue)
        Catch exp As Exception
            data = Nothing
            Throw New Exception(exp.Message)
        Finally
            da.Dispose()
            ds.Dispose()
        End Try
    End Sub
    Private Sub txtValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtValue.TextChanged
        lblMessage.Text = ""
        GetGridData()
        Dim V As Double
        Try
            V = txtValue.Text.Trim
            Setfocus(txtRemarks)
        Catch exp As Exception
            If exp.Message.StartsWith("Cast from string") Then
                lblMessage.Text = " InValid Value! : '" & txtValue.Text.Trim & "'"
            Else
                lblMessage.Text = exp.Message
            End If
            txtValue.Text = ""
        End Try

        Setfocus(btnSave)
    End Sub
    Private Sub txtChallanNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRemarks.TextChanged
        Setfocus(btnSave)
    End Sub
    Private Sub txtChallanDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRemarks.TextChanged
        Setfocus(btnSave)
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        lblMessage.Text = ""
        Try
            Panel2.Visible = CheckBox1.Checked
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        Dim oCmd As New SqlClient.SqlCommand()
        oCmd.Connection = rwfGen.Connection.ConObj
        Dim done As New Boolean()
        Try
            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()

            oCmd.Parameters.Add("@ItemDate", SqlDbType.SmallDateTime, 4).Value = CDate(txtDate.Text)


            oCmd.Parameters.Add("@Item", SqlDbType.VarChar, 50).Value = rblArea.SelectedItem.Value

            oCmd.Parameters.Add("@ChallanNumber", SqlDbType.VarChar, 4).Value = txtChallanNumber.Text
            oCmd.Parameters.Add("@ChallanDate", SqlDbType.VarChar, 20).Value = txtChallanDate.Text
            oCmd.Parameters.Add("@ItemValue", SqlDbType.Float, 20).Value = txtValue.Text
            oCmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 250).Value = txtRemarks.Text.Trim
            oCmd.Parameters.Add("@SlNo", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output

            oCmd.Transaction = oCmd.Connection.BeginTransaction
            If CheckBox1.Checked Then
                oCmd.CommandText = " select SlNo = @SlNo from ms_HSDValuesRTSHOP where ItemDate = @ItemDate and  Item = @Item "
                oCmd.ExecuteScalar()
                If IIf(IsDBNull(oCmd.Parameters("@SlNo").Value), 0, oCmd.Parameters("@SlNo").Value) = 0 Then
                    oCmd.CommandText = "insert into ms_HSDValuesRTSHOP " &
                        " ( ItemDate ,Item , ItemValue , Remarks,ChallanNumber, ChallanDate, Reset  ) " &
                                " values ( @ItemDate, @Item , @ItemValue , @Remarks ,@ChallanNumber, @ChallanDate, " & 1 & " )"

                Else
                    oCmd.CommandText = " update ms_HSDValuesRTSHOP set ItemValue = @ItemValue , " &
                                " Remarks = @Remarks , Reset = " & 1 & " where  ItemDate = @ItemDate and  Item = @Item  "
                End If
                If oCmd.ExecuteNonQuery > 0 Then
                    done = False
                    oCmd.CommandText = " select @SlNo = SlNo from ms_HSDValuesRTSHOP where ItemDate = @ItemDate and  Item = @Item "
                    oCmd.ExecuteScalar()
                    If IIf(IsDBNull(oCmd.Parameters("@SlNo").Value), 0, oCmd.Parameters("@SlNo").Value) > 0 Then
                        If Val(txtMax.Text) < Val(txtValue.Text) OrElse Val(txtInitial.Text) < 0 Then
                            lblMessage.Text = "InValid Reset Values !"
                        Else
                            oCmd.Parameters.Add("@PreMaxValue", SqlDbType.Float, 8).Value = Val(txtMax.Text)
                            oCmd.Parameters.Add("@NextIniValue", SqlDbType.Float, 8).Value = Val(txtInitial.Text)
                            oCmd.Parameters("@SlNo").Direction = ParameterDirection.Input
                            oCmd.CommandText = "insert into ms_HSDResetValues " &
                               " ( ItemValue , Remarks ) " &
                            " values ( @ItemValue , @Remarks )"

                            If oCmd.ExecuteNonQuery > 0 Then
                                done = True
                            End If
                        End If
                    End If
                End If
            Else
                oCmd.CommandText = " select @SlNo = SlNo from ms_HSDValuesRTSHOP where ItemDate = @ItemDate and  Item = @Item "
                oCmd.ExecuteScalar()
                If IIf(IsDBNull(oCmd.Parameters("@SlNo").Value), 0, oCmd.Parameters("@SlNo").Value) = 0 Then
                    oCmd.CommandText = "insert into ms_HSDValuesRTSHOP " &
                                " ( ItemDate , Item , ItemValue ,ChallanNumber, ChallanDate, Remarks ) " &
                                " values ( @ItemDate, @Item , @ItemValue ,@ChallanNumber, @ChallanDate, @Remarks )"
                Else
                    oCmd.CommandText = " update ms_HSDValuesRTSHOP set ItemValue = @ItemValue , " &
                                " Remarks = @Remarks where  ItemDate = @ItemDate and  Item = @Item  "
                End If
                If oCmd.ExecuteNonQuery > 0 Then
                    done = True
                End If
            End If
            done = True
        Catch exp As Exception
            done = False
            lblMessage.Text = "Adding of HSD Values failed !" & exp.Message
        Finally
            If done Then

                oCmd.Transaction.Commit()
                lblMessage.Text = "Records Updated"
            Else
                oCmd.Transaction.Rollback()
                lblMessage.Text = "Updation failed"
            End If
            If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
            oCmd.Dispose()
        End Try
        Try
            GetGridData()
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
    End Sub


End Class
