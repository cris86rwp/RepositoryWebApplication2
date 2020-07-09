Public Class BakingPadCurrentReadings
    Inherits System.Web.UI.Page
    Protected WithEvents rblShift As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents C5IE As System.Web.UI.WebControls.TextBox
    Protected WithEvents C5IW As System.Web.UI.WebControls.TextBox
    Protected WithEvents C5KE As System.Web.UI.WebControls.TextBox
    Protected WithEvents C5KW As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox

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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Page.IsPostBack = False Then
            txtDate.Text = Now.Date
            Try
                GetData()
                FillGrid()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
    Private Sub FillGrid()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Dim da As SqlClient.SqlDataAdapter
        Dim ds As New DataSet()
        da = rwfGen.Connection.Adapter
        da.SelectCommand.CommandText = "select convert(varchar(11),OutTurnDate,103) OutTurnDate  , Shift ,  " & _
                            " C5IE , C5IW , C5KE  , C5KW    from mm_MROutTurn where OutTurnDate = @OutTurnDate "
        Try
            da.SelectCommand.Parameters.Add("@OutTurnDate", SqlDbType.SmallDateTime, 4).Value = CDate(txtDate.Text)
            da.Fill(ds)
            DataGrid1.DataSource = ds.Tables(0).DefaultView
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = "Data Grid Filling Failed : " & exp.Message
        Finally
            ds.Dispose()
            da.Dispose()
        End Try
    End Sub
    Private Sub clear()
        C5IE.Text = ""
        C5IW.Text = ""
        C5KE.Text = ""
        C5KW.Text = ""
    End Sub
    Private Sub GetData()
        clear()
        Dim da As SqlClient.SqlDataAdapter
        Dim ds As New DataSet()
        da = rwfGen.Connection.Adapter
        da.SelectCommand.CommandText = "select OutTurnDate , Shift , C5IE  , C5IW  , C5KE , C5KW  from mm_MROutTurn where OutTurnDate  = @OutTurnDate and Shift = @Shift "
        Try
            da.SelectCommand.Parameters.Add("@OutTurnDate", SqlDbType.SmallDateTime, 4).Value = CDate(txtDate.Text)
            da.SelectCommand.Parameters.Add("@Shift", SqlDbType.VarChar, 1).Value = rblShift.SelectedItem.Value
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                C5IE.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("C5IE")), "", ds.Tables(0).Rows(0)("C5IE"))
                C5IW.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("C5IW")), "", ds.Tables(0).Rows(0)("C5IW"))
                C5KE.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("C5KE")), "", ds.Tables(0).Rows(0)("C5KE"))
                C5KW.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("C5KW")), "", ds.Tables(0).Rows(0)("C5KW"))
            End If
        Catch exp As Exception
            lblMessage.Text = "Data Filling  Failed : " & exp.Message
        Finally
            ds.Dispose()
            da.Dispose()
        End Try
    End Sub

    Private Sub rblShift_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblShift.SelectedIndexChanged
        lblMessage.Text = ""
        Dim dt As Date
        Try
            dt = CDate(txtDate.Text)
            If dt > Now.Date Then
                lblMessage.Text = "Future date not allowed "
                txtDate.Text = ""
            Else
                txtDate.Text = dt
                GetData()
                FillGrid()
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt = Nothing
        End Try
    End Sub

    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        lblMessage.Text = ""
        Dim dt As Date
        Try
            dt = CDate(txtDate.Text)
            If dt > Now.Date Then
                lblMessage.Text = "Future date not allowed "
                txtDate.Text = ""
            Else
                txtDate.Text = dt
                GetData()
                FillGrid()
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt = Nothing
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim Done As Boolean
        Dim blnInsert As Boolean
        Dim da As SqlClient.SqlDataAdapter
        Dim ds As New DataSet()
        da = rwfGen.Connection.Adapter
        da.SelectCommand.CommandText = "select *  from mm_MROutTurn where OutTurnDate  = @OutTurnDate and Shift = @Shift "
        da.SelectCommand.Parameters.Add("@OutTurnDate", SqlDbType.SmallDateTime, 4).Value = CDate(txtDate.Text)
        da.SelectCommand.Parameters.Add("@Shift", SqlDbType.VarChar, 1).Value = rblShift.SelectedItem.Value
        Try
            da.Fill(ds)
            If ds.Tables(0).Rows.Count = 0 Then
                blnInsert = True
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            ds.Dispose()
            da.Dispose()
        End Try
        Dim dt As Date
        Try
            dt = CDate(txtDate.Text)
            If dt.Date < Now.Date.AddDays(-2) Then
                lblMessage.Text = "Editing of prevoius dates ( " & dt & " )not allowed "
                txtDate.Text = ""
                Exit Sub
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt = Nothing
        End Try
        Dim oCmd As New SqlClient.SqlCommand()
        oCmd = rwfGen.Connection.CmdObj
        Dim strInsert, strUpdate As String

        Try
            oCmd.Parameters.Add("@OutTurnDate", SqlDbType.SmallDateTime, 4)
            oCmd.Parameters("@OutTurnDate").Direction = ParameterDirection.Input
            oCmd.Parameters("@OutTurnDate").Value = CDate(txtDate.Text)
            oCmd.Parameters.Add("@Shift", SqlDbType.VarChar, 1)
            oCmd.Parameters("@Shift").Direction = ParameterDirection.Input
            oCmd.Parameters("@Shift").Value = rblShift.SelectedItem.Value

            strInsert = " insert into mm_MROutTurn ( OutTurnDate,Shift,  C5IE , C5IW , C5KE , C5KW ) values ( @OutTurnDate , @Shift , @C5IE , @C5IW , @C5KE , @C5KW )  "

            strUpdate = " update mm_MROutTurn set  C5IE = @C5IE , C5IW = @C5IW , C5KE = @C5KE , C5KW = @C5KW  where OutTurnDate = @OutTurnDate and Shift = @Shift "

            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            oCmd.Transaction = oCmd.Connection.BeginTransaction
            If blnInsert Then
                oCmd.CommandText = strInsert
            Else
                oCmd.CommandText = strUpdate
            End If
            oCmd.Parameters.Add("@C5IE", SqlDbType.VarChar, 100)
            oCmd.Parameters("@C5IE").Direction = ParameterDirection.Input
            oCmd.Parameters("@C5IE").Value = C5IE.Text & ""
            oCmd.Parameters.Add("@C5IW", SqlDbType.VarChar, 100)
            oCmd.Parameters("@C5IW").Direction = ParameterDirection.Input
            oCmd.Parameters("@C5IW").Value = C5IW.Text & ""
            oCmd.Parameters.Add("@C5KE", SqlDbType.VarChar, 100)
            oCmd.Parameters("@C5KE").Direction = ParameterDirection.Input
            oCmd.Parameters("@C5KE").Value = C5KE.Text & ""
            oCmd.Parameters.Add("@C5KW", SqlDbType.VarChar, 100)
            oCmd.Parameters("@C5KW").Direction = ParameterDirection.Input
            oCmd.Parameters("@C5KW").Value = C5KW.Text & ""
            If oCmd.ExecuteNonQuery = 1 Then
                Done = True
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            If Not IsNothing(oCmd) Then
                If Done Then
                    oCmd.Transaction.Commit()
                    lblMessage.Text = " Updation Successful !"
                    clear()
                Else
                    lblMessage.Text &= " Updation Failed ! "
                    oCmd.Transaction.Rollback()
                End If
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End If
        End Try
        Try
            FillGrid()
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
    End Sub
End Class
