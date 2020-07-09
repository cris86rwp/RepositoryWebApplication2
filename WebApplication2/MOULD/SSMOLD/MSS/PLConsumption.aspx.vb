Public Class PLConsumption
    Inherits System.Web.UI.Page
    Protected WithEvents ddlPLs As System.Web.UI.WebControls.DropDownList
    Protected WithEvents rblYear As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblMonth As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents txtOB As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtReceipts As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtConsumption As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCB As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents lblPLDesc As System.Web.UI.WebControls.Label
    Protected WithEvents lblUnit As System.Web.UI.WebControls.Label
    Protected WithEvents lblEstQty As System.Web.UI.WebControls.Label
    Protected WithEvents lblWhlsCast As System.Web.UI.WebControls.Label
    Protected WithEvents lblAccQty As System.Web.UI.WebControls.Label
    Protected WithEvents lblRMRQty As System.Web.UI.WebControls.Label
    Protected WithEvents lblRMRCon As System.Web.UI.WebControls.Label
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblConsumDate As System.Web.UI.WebControls.Label
    Protected WithEvents lblConsignee As System.Web.UI.WebControls.Label
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

#End Region
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


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        lblConsumDate.Visible = False
        If Page.IsPostBack = False Then
            'txtRMRDate.Text = Now.Date
            Dim Group As String = Session("Group")
            Dim strMode As String = Request.QueryString("mode")
            Dim UserId As String = Session("UserID")
            Dim InValid As Boolean = False
            ''''''''''''''''
            Group = "SSMOLD"
            UserId = "073533"
            ''''''''''''''''
            If UserId = "073533" Then
                Try
                    lblConsignee.Text = ProductionConsumables.GetConsignee(Group, UserId)
                    If lblConsignee.Text.Trim.Length = 4 Then InValid = True
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                End Try
                If Not InValid Then
                    'Response.Redirect("/mss/logon.aspx")
                    Response.Redirect("InvalidSession.aspx")
                End If
                Try
                    SetMonthYear()
                    GetPLs()
                    GetPLDetails()
                    GetMonthDetails()
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                End Try
            Else
                'Response.Redirect("/mss/logon.aspx")
                Response.Redirect("InvalidSession.aspx")
            End If
        End If
    End Sub
    Private Sub SetMonthYear()
        Dim dt1, dt2 As DataTable
        dt1 = ProductionConsumables.GetYearMonth(0)
        rblMonth.DataSource = dt1
        rblMonth.DataTextField = dt1.Columns(0).ColumnName
        rblMonth.DataValueField = dt1.Columns(1).ColumnName
        rblMonth.DataBind()
        rblMonth.SelectedIndex = 0
        dt2 = ProductionConsumables.GetYearMonth(1)
        rblYear.DataSource = dt2
        rblYear.DataTextField = dt2.Columns(0).ColumnName
        rblYear.DataValueField = dt2.Columns(0).ColumnName
        rblYear.DataBind()
        rblYear.ClearSelection()
        Dim int As Int16
        For int = 0 To rblYear.Items.Count - 1
            If rblYear.Items(int).Value = Now.Year Then
                rblYear.Items(int).Selected = True
                Exit For
            End If
        Next
        int = 0
        rblMonth.ClearSelection()
        For int = 0 To rblMonth.Items.Count - 1
            If rblMonth.Items(int).Value = Now.Month Then
                rblMonth.Items(int).Selected = True
                Exit For
            End If
        Next
        dt1 = Nothing
        dt2 = Nothing
    End Sub

    Private Sub GetPLs()
        Dim dt1 As DataTable
        dt1 = ProductionConsumables.GetProdConsumablePLs(lblConsignee.Text.Trim)
        ddlPLs.DataSource = dt1
        ddlPLs.DataTextField = dt1.Columns(0).ColumnName
        ddlPLs.DataValueField = dt1.Columns(0).ColumnName
        ddlPLs.DataBind()
        ddlPLs.SelectedIndex = 0
        dt1 = Nothing
    End Sub

    Private Sub Clear()
        lblPLDesc.Text = ""
        lblUnit.Text = ""
        lblEstQty.Text = ""
        lblWhlsCast.Text = ""
        lblAccQty.Text = ""
        lblRMRQty.Text = ""
        lblRMRCon.Text = ""

        txtOB.Text = ""
        txtReceipts.Text = ""
        txtConsumption.Text = ""
        txtCB.Text = ""
    End Sub

    Private Sub GetMonthDetails()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            lblConsumDate.Text = Now.DaysInMonth(rblYear.SelectedItem.Value, rblMonth.SelectedItem.Value)
            lblConsumDate.Text = CDate(lblConsumDate.Text & "/" & rblMonth.SelectedItem.Value & "/" & rblYear.SelectedItem.Value)
            DataGrid1.DataSource = ProductionConsumables.PLConsumptionMonthDetails(lblConsignee.Text.Trim, CDate(lblConsumDate.Text), ddlPLs.SelectedItem.Value)
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub GetPLDetails()
        Clear()
        Dim ds As DataSet
        Try
            lblConsumDate.Text = Now.DaysInMonth(rblYear.SelectedItem.Value, rblMonth.SelectedItem.Value)
            lblConsumDate.Text = CDate(lblConsumDate.Text & "/" & rblMonth.SelectedItem.Value & "/" & rblYear.SelectedItem.Value)
            ds = ProductionConsumables.PLConsumptionDetails(lblConsignee.Text.Trim, CDate(lblConsumDate.Text), ddlPLs.SelectedItem.Value)
            If ds.Tables(0).Rows.Count = 0 Then
                lblMessage.Text = "No consumption posted for PL Number !"
                Exit Sub
            Else
                lblPLDesc.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)(1)), "", ds.Tables(0).Rows(0)(1))
                lblUnit.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)(2)), "", ds.Tables(0).Rows(0)(2))
                lblEstQty.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)(6)), "", ds.Tables(0).Rows(0)(6))
                lblWhlsCast.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)(4)), "", ds.Tables(0).Rows(0)(4))
                lblAccQty.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)(7)), "", ds.Tables(0).Rows(0)(7))
                lblRMRQty.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)(3)), "", ds.Tables(0).Rows(0)(3))
                lblRMRCon.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)(5)), "", ds.Tables(0).Rows(0)(5))
            End If
            If ds.Tables(1).Rows.Count > 0 Then
                txtOB.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)("OB")), "", ds.Tables(1).Rows(0)("OB"))
                txtReceipts.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)("Receipts")), "", ds.Tables(1).Rows(0)("Receipts"))
                txtConsumption.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)("Consumption")), "", ds.Tables(1).Rows(0)("Consumption"))
                txtCB.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)("CB")), "", ds.Tables(1).Rows(0)("CB"))
            Else
                If ds.Tables(0).Rows.Count > 0 Then
                    txtReceipts.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)(5)), "", ds.Tables(0).Rows(0)(5))
                End If
                If ds.Tables(2).Rows.Count > 0 Then
                    txtOB.Text = IIf(IsDBNull(ds.Tables(2).Rows(0)("OB")), "", ds.Tables(2).Rows(0)("OB"))
                End If
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        ds = Nothing
    End Sub

    Private Sub ddlPLs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlPLs.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            GetPLDetails()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub rblMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblMonth.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            GetMonthDetails()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub rblYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblYear.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            GetMonthDetails()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtConsumption_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtConsumption.TextChanged
        lblMessage.Text = ""
        Try
            lblAccQty.Text = Val(txtConsumption.Text) / Val(lblWhlsCast.Text)
            txtCB.Text = Val(txtOB.Text) + Val(txtReceipts.Text) - Val(txtConsumption.Text)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        Dim done As Boolean
        Try
            lblConsumDate.Text = Now.DaysInMonth(rblYear.SelectedItem.Value, rblMonth.SelectedItem.Value)
            lblConsumDate.Text = CDate(lblConsumDate.Text & "/" & rblMonth.SelectedItem.Value & "/" & rblYear.SelectedItem.Value)
            done = New ProductionConsumables().SavePLConsumption(CDate(lblConsumDate.Text), ddlPLs.SelectedItem.Value, Val(txtOB.Text), Val(txtReceipts.Text), Val(txtConsumption.Text), (txtCB.Text))
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If done Then
            Try
                GetPLDetails()
                GetMonthDetails()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            lblMessage.Text &= "  Data Saved !"
        Else
            lblMessage.Text &= "  Data Saving Failed !"
        End If
    End Sub
End Class
