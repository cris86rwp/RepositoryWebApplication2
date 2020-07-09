Public Class ProdConsumableDetails
    Inherits System.Web.UI.Page
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents rblType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblType1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblType As System.Web.UI.WebControls.Label
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents txtTransDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblType2 As System.Web.UI.WebControls.Label
    Protected WithEvents Panel2 As System.Web.UI.WebControls.Panel
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid3 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSupplier As System.Web.UI.WebControls.TextBox
    Protected WithEvents DataGrid4 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblPLNo As System.Web.UI.WebControls.Label
    Protected WithEvents lblQty As System.Web.UI.WebControls.Label
    Protected WithEvents lblTransID As System.Web.UI.WebControls.Label
    Protected WithEvents pnlNonPl As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlPl As System.Web.UI.WebControls.Panel
    Protected WithEvents rblPL As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents lblConsignee As System.Web.UI.WebControls.Label

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
        lblTransID.Visible = False
        If IsPostBack = False Then
            Dim Group As String = Session("Group")
            Dim UserId As String = Session("UserID")
            Dim InValid As Boolean = False
            ''''''''''''''''
            ''Group = "SSMELT"
            ''UserId = "111111"
            ''''''''''''''''
            Try
                lblConsignee.Text = ProductionConsumables.GetConsignee(Group, UserId)
                If lblConsignee.Text.Trim.Length = 4 Then InValid = True
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            'If Not InValid Then
            '    Response.Redirect("/mss/logon.aspx")
            'Else
            txtTransDate.Text = Now.Date
                Try
                    GetPLType()
                    SetPnl()
                    GetTransDateDetails()
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                End Try
            End If
            SetFocus(txtNumber)
        ''End If
    End Sub

    Private Sub SetFocus(ByVal ctrl As Control)
        Dim focusScript As String = "<script language=" & "javascript" & " > " & _
        "document.getElementById('" + ctrl.ClientID.ToString.Trim & _
        "').focus();</script>"
        Page.RegisterStartupScript("FocusScript", focusScript)
    End Sub

    Private Sub GetTransDateDetails()
        DataGrid4.DataSource = Nothing
        DataGrid4.DataBind()
        DataGrid4.DataSource = ProductionConsumables.GetTransDateDetails(lblConsignee.Text, CDate(txtTransDate.Text))
        DataGrid4.DataBind()
    End Sub

    Private Sub GetPLType()
        Dim dt1 As DataTable
        dt1 = ProductionConsumables.GetPLType
        rblType.DataSource = dt1
        rblType.DataTextField = dt1.Columns(0).ColumnName
        rblType.DataValueField = dt1.Columns(1).ColumnName
        rblType.DataBind()
        rblType.SelectedIndex = 0
        lblType.Text = rblType.SelectedItem.Text
        lblType1.Text = rblType.SelectedItem.Text
        lblType2.Text = rblType.SelectedItem.Text
        SetPnl()
        dt1 = Nothing
    End Sub

    Private Sub SetPnl()
        pnlPl.Visible = False
        pnlNonPl.Visible = False
        If rblType.SelectedItem.Value = 2 Then
            Dim dt As DataTable
            dt = ProductionConsumables.GetScrapName(lblPLNo.Text)
            rblPL.DataSource = dt
            rblPL.DataTextField = dt.Columns(0).ColumnName
            rblPL.DataValueField = dt.Columns(0).ColumnName
            rblPL.DataBind()
            rblPL.SelectedIndex = 0
            If lblPLNo.Text = "98050096" OrElse lblPLNo.Text = "98050060" OrElse lblPLNo.Text = "98050280" Then
                pnlPl.Visible = True
            Else
                pnlNonPl.Visible = True
            End If
        Else
            pnlNonPl.Visible = True
        End If
    End Sub

    Private Sub rblType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblType.SelectedIndexChanged
        lblMessage.Text = ""
        lblType.Text = rblType.SelectedItem.Text
        lblType1.Text = rblType.SelectedItem.Text
        lblType2.Text = rblType.SelectedItem.Text
        txtNumber.Text = ""
        txtQty.Text = ""
        txtRemarks.Text = ""
        lblPLNo.Text = ""
        txtSupplier.Text = ""
        lblTransID.Text = ""
        SetFocus(txtNumber)
        ClearGrid()
        SetPnl()
    End Sub

    Private Sub ClearGrid()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        DataGrid3.DataSource = Nothing
        DataGrid3.DataBind()
    End Sub

    Private Sub txtNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumber.TextChanged
        lblMessage.Text = ""
        lblPLNo.Text = ""
        txtQty.Text = ""
        txtSupplier.Text = ""
        txtRemarks.Text = ""
        lblTransID.Text = ""
        ClearGrid()
        txtNumber.Text = CStr(txtNumber.Text).ToUpper.Trim
        SetFocus(txtQty)
        GetDetails()
        If lblMessage.Text = "Error converting data type varchar to numeric." Then
            lblMessage.Text = "Check Type selection !"
            SetFocus(txtNumber)
        End If
    End Sub

    Private Sub GetDetails()
        Dim ds As DataSet
        Try
            ds = ProductionConsumables.GetProdConsumableDetails(txtNumber.Text.Trim, lblConsignee.Text, rblType.SelectedItem.Value)
            If ds.Tables(0).Rows.Count = 0 Then
                Throw New Exception("InValid PL Number!")
            Else
                lblPLNo.Text = ds.Tables(0).Rows(0)(2)
                DataGrid1.DataSource = ds.Tables(0)
                DataGrid1.DataBind()
                If ds.Tables(1).Rows.Count > 0 Then
                    DataGrid2.DataSource = ds.Tables(1)
                    DataGrid2.DataBind()
                End If
                If ds.Tables(2).Rows.Count > 0 Then
                    DataGrid3.DataSource = ds.Tables(2)
                    DataGrid3.DataBind()
                End If
                If ds.Tables(3).Rows.Count > 0 Then
                    lblQty.Text = IIf(IsDBNull(ds.Tables(3).Rows(0)(0)), "", ds.Tables(3).Rows(0)(0))
                End If
                SetPnl()
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
            txtNumber.Text = ""
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        If lblPLNo.Text = "" Then
            lblMessage.Text = "InValid Entry , Please try again !"
            Exit Sub
        End If
        If Val(txtQty.Text) = 0 Then
            lblMessage.Text = "InValid Drawn Qty , Please try again !"
            Exit Sub
        End If
        Dim Done As Boolean
        Try
            If lblPLNo.Text = "98050060" OrElse lblPLNo.Text = "98050096" Then
                txtSupplier.Text = rblPL.SelectedItem.Text.Trim
            End If
            Done = New ProductionConsumables().SaveTransDetails(lblConsignee.Text, lblPLNo.Text, txtNumber.Text.Trim, CDate(txtTransDate.Text), Val(txtQty.Text), txtRemarks.Text.Trim, rblType.SelectedItem.Value, txtSupplier.Text.Trim, Val(lblTransID.Text))
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
        If Done Then
            Try
                GetDetails()
                GetTransDateDetails()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            lblMessage.Text = " Data Saved ! " & lblMessage.Text
        End If
    End Sub

    Private Sub txtTransDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTransDate.TextChanged
        lblMessage.Text = ""
        GetTransDateDetails()
    End Sub

    Private Sub DataGrid2_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid2.ItemCommand
        lblMessage.Text = ""
        txtTransDate.Text = ""
        txtQty.Text = ""
        txtSupplier.Text = ""
        txtRemarks.Text = ""
        lblTransID.Text = ""
        Try
            Select Case e.CommandName
                Case "Select"
                    txtTransDate.Text = e.Item.Cells(3).Text.Replace("&nbsp;", "").Trim
                    txtQty.Text = e.Item.Cells(5).Text.Replace("&nbsp;", "").Trim
                    txtSupplier.Text = e.Item.Cells(6).Text.Replace("&nbsp;", "").Trim
                    txtRemarks.Text = e.Item.Cells(7).Text.Replace("&nbsp;", "").Trim
                    lblTransID.Text = e.Item.Cells(8).Text.Trim
            End Select
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
End Class
