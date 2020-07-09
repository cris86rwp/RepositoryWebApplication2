Public Class ProdIDNDetails
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtIDNNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtRecDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlPresentStatus As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtClearedDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLabNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFileNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlCriteria As System.Web.UI.WebControls.DropDownList
    Protected WithEvents rblClearedBy As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnIDN As System.Web.UI.WebControls.Button
    Protected WithEvents lblQty As System.Web.UI.WebControls.Label
    Protected WithEvents lblDate As System.Web.UI.WebControls.Label
    Protected WithEvents txtAccQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRejQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents pnlClear As System.Web.UI.WebControls.Panel
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
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


    Protected Sub Dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        lblQty.Visible = False
        lblDate.Visible = False
        If IsPostBack = False Then
            txtRecDate.Text = Now.Date
            FillDDLs()
            pnlClear.Visible = False
        End If
    End Sub

    Private Sub txtIDNNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIDNNo.TextChanged
        lblMessage.Text = ""
        FillGrid()
    End Sub

    Private Sub FillGrid()
        Dim ds As DataSet
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        DataGrid2.SelectedIndex = -1
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        Try
            ds = ProductionConsumables.IDNDetails(txtIDNNo.Text)
            DataGrid1.DataSource = ds.Tables(0)
            DataGrid1.DataBind()
            If DataGrid1.Items.Count = 0 Then
                lblMessage.Text = "InValid IDNNo !"
                txtIDNNo.Text = ""
            Else
                lblDate.Text = DataGrid1.Items(0).Cells(0).Text
                lblQty.Text = DataGrid1.Items(0).Cells(1).Text
            End If
            If ds.Tables(1).Rows.Count > 0 Then
                DataGrid2.DataSource = ds.Tables(1)
                DataGrid2.DataBind()
            End If
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
    End Sub

    Private Sub FillDDLs()
        Dim ds As DataSet
        Try
            ds = ProductionConsumables.IDNPresentStatus
            ddlPresentStatus.DataSource = ds.Tables(0)
            ddlPresentStatus.DataTextField = ds.Tables(0).Columns(1).ColumnName
            ddlPresentStatus.DataValueField = ds.Tables(0).Columns(0).ColumnName
            ddlPresentStatus.DataBind()
            ddlCriteria.DataSource = ds.Tables(1)
            ddlCriteria.DataTextField = ds.Tables(1).Columns(1).ColumnName
            ddlCriteria.DataValueField = ds.Tables(1).Columns(0).ColumnName
            ddlCriteria.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnIDN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIDN.Click
        lblMessage.Text = ""
        Dim Done As Boolean
        Try

            If CDate(lblDate.Text) > CDate(txtRecDate.Text) Then
                lblMessage.Text = "InValid IDN received date !"
                txtRecDate.Text = ""
                Exit Sub
            ElseIf Val(lblQty.Text) < (Val(txtAccQty.Text) + Val(txtRejQty.Text)) Then
                lblMessage.Text = "InValid IDN Qty !"
                txtAccQty.Text = ""
                txtRejQty.Text = ""
                Exit Sub
            ElseIf ddlPresentStatus.SelectedItem.Value < 7 Then
                ddlCriteria.SelectedIndex = 0
            ElseIf ddlPresentStatus.SelectedItem.Value >= 7 Then
                If ddlCriteria.SelectedItem.Value > 0 Then
                    If CDate(txtClearedDate.Text) < CDate(txtRecDate.Text) Then
                        lblMessage.Text = "InValid IDN Cleared date !"
                        txtClearedDate.Text = ""
                        Exit Sub
                    End If
                Else
                    lblMessage.Text = "InValid Clearance Criteria cannot be blank !"
                    Exit Sub
                End If
            ElseIf ddlCriteria.SelectedItem.Value = 0 Then
                rblClearedBy.ClearSelection()
            End If
            Dim CrDt As Date
            If ddlCriteria.SelectedItem.Value = 0 Then
                CrDt = CDate("1900-01-01")
            Else
                CrDt = CDate(txtClearedDate.Text)
            End If
            Dim CrBy As String
            If ddlCriteria.SelectedItem.Value = 0 Then
                CrBy = ""
            Else
                CrBy = rblClearedBy.SelectedItem.Text
            End If
            Done = New ProductionConsumables().IDNDataDetails(txtIDNNo.Text.Trim, CDate(txtRecDate.Text), ddlPresentStatus.SelectedItem.Value, Val(txtAccQty.Text), Val(txtRejQty.Text), CrDt, txtLabNo.Text.Trim, txtFileNo.Text.Trim, ddlCriteria.SelectedItem.Value, CrBy)
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
        If Done Then
            FillGrid()
            lblMessage.Text &= " Data Inserted successfully !"
        Else
            lblMessage.Text &= " Data Failed !"
        End If
    End Sub

    Private Sub ddlCriteria_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlCriteria.SelectedIndexChanged
        lblMessage.Text = ""
        pnlClear.Visible = False
        If ddlCriteria.SelectedItem.Value > 0 Then
            pnlClear.Visible = True
        End If
    End Sub

    Private Sub DataGrid2_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid2.ItemCommand
        lblMessage.Text = ""
        Select Case e.CommandName
            Case Is = "Select"
                Try
                    txtRecDate.Text = IIf(IsDBNull(e.Item.Cells(1).Text), Now.Date, e.Item.Cells(1).Text)
                    Dim i As Int16
                    ddlPresentStatus.ClearSelection()
                    For i = 0 To ddlPresentStatus.Items.Count - 1
                        If e.Item.Cells(2).Text = ddlPresentStatus.Items(i).Text Then
                            ddlPresentStatus.Items(i).Selected = True
                            Exit For
                        End If
                    Next
                    i = 0
                    txtAccQty.Text = IIf(IsDBNull(e.Item.Cells(3).Text), 0, e.Item.Cells(3).Text.Replace("&nbsp;", ""))
                    txtRejQty.Text = IIf(IsDBNull(e.Item.Cells(4).Text), 0, e.Item.Cells(4).Text.Replace("&nbsp;", ""))
                    txtClearedDate.Text = IIf(IsDBNull(e.Item.Cells(5).Text), "", e.Item.Cells(5).Text.Replace("&nbsp;", ""))
                    txtLabNo.Text = IIf(IsDBNull(e.Item.Cells(6).Text), "", e.Item.Cells(6).Text.Replace("&nbsp;", ""))
                    txtFileNo.Text = IIf(IsDBNull(e.Item.Cells(7).Text), "", e.Item.Cells(7).Text.Replace("&nbsp;", ""))
                    ddlCriteria.ClearSelection()
                    For i = 0 To ddlCriteria.Items.Count - 1
                        If e.Item.Cells(8).Text = ddlCriteria.Items(i).Text Then
                            ddlCriteria.Items(i).Selected = True
                            Exit For
                        End If
                    Next
                    i = 0
                    rblClearedBy.ClearSelection()
                    For i = 0 To rblClearedBy.Items.Count - 1
                        If e.Item.Cells(9).Text = rblClearedBy.Items(i).Text Then
                            rblClearedBy.Items(i).Selected = True
                            Exit For
                        End If
                    Next
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                End Try
                lblMessage.Text &= " Do not change Received date while edting !"
        End Select
    End Sub
End Class
