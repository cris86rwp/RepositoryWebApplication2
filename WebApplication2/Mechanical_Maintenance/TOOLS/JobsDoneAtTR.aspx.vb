Public Class JobsDoneAtTR
    Inherits System.Web.UI.Page
    Protected WithEvents txtReceivedDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents rblShop As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtWONo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWOQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtAttendedBy As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtHourTaken As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtStatus As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWODesc As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWODate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtHandedOverTo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
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

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If IsPostBack = False Then
            txtReceivedDate.Text = Now.Date
            Dim dt As DataTable
            'dt = ToolRoom.Tables.ShopListForTRJobs
            'rblShop.DataSource = dt
            'rblShop.DataTextField = dt.Columns(1).ColumnName
            'rblShop.DataValueField = dt.Columns(0).ColumnName
            'rblShop.DataBind()
            'rblShop.SelectedIndex = 0
            'Try
            '    FillGrid()
            'Catch exp As Exception
            '    lblMessage.Text = exp.Message
            'End Try
        End If
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
    Private Sub FillGrid()
        DataGrid1.SelectedIndex = -1
        Try
            DataGrid1.DataSource = ToolRoom.Tables.JobsDoneAtTR(CDate(txtReceivedDate.Text))
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtReceivedDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReceivedDate.TextChanged
        lblMessage.Text = ""
        Dim dt, dt1 As Date
        Try
            dt = CDate(txtReceivedDate.Text)
            txtReceivedDate.Text = dt
            If dt > Now.Date Then
                lblMessage.Text = "Date cannot be greater than Today !"
                txtReceivedDate.Text = Now.Date
            End If
            Try
                dt1 = CDate(txtWODate.Text)
                If dt1 > dt Then
                    lblMessage.Text = "WODate cannot be greater than Received Date !"
                    txtReceivedDate.Text = txtWODate.Text
                End If
            Catch exp As Exception
            End Try
            FillGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt = Nothing
            dt1 = Nothing
        End Try
    End Sub

    Private Sub txtWONo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWONo.TextChanged
        lblMessage.Text = ""
        Try
            If ToolRoom.Tables.CheckWO(txtWONo.Text.Trim, rblShop.SelectedItem.Value) Then
                lblMessage.Text = "WONo : '" & txtWONo.Text.Trim & "' already exists for the given Shop !"
                txtWONo.Text = ""
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally

        End Try
    End Sub

    Private Sub txtWODate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWODate.TextChanged
        lblMessage.Text = ""
        Dim dt As Date
        Try
            dt = CDate(txtWODate.Text)
            txtWODate.Text = dt
            If dt > Now.Date Then
                lblMessage.Text = "Date cannot be greater than Today !"
                txtWODate.Text = Now.Date
            ElseIf dt > CDate(txtReceivedDate.Text) Then
                lblMessage.Text = "WO Date cannot be greater than Received Date !"
                txtReceivedDate.Text = txtWODate.Text
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt = Nothing
        End Try
    End Sub

    Private Sub rblShop_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblShop.SelectedIndexChanged
        lblMessage.Text = ""
        Clear()
    End Sub

    Private Sub Clear()
        txtWONo.Text = ""
        txtWODate.Text = Now.Date
        txtWOQty.Text = ""
        txtAttendedBy.Text = ""
        txtHourTaken.Text = ""
        txtStatus.Text = ""
        txtWODesc.Text = ""
        txtWODate.Text = ""
        txtHandedOverTo.Text = ""
        txtRemarks.Text = ""
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        Dim done As Boolean
        Dim Job As New ToolRoom.Tool("")
        Try
            done = Job.SaveJobs(txtWONo.Text.Trim, CDate(txtWODate.Text), CDate(txtReceivedDate.Text), rblShop.SelectedItem.Value, txtWODesc.Text.Trim, txtWOQty.Text.Trim, txtAttendedBy.Text.Trim, txtHourTaken.Text.Trim, txtStatus.Text.Trim, txtHandedOverTo.Text.Trim, txtRemarks.Text.Trim)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If done Then
            Clear()
            Try
                FillGrid()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            lblMessage.Text &= "  Data Saved !"
        Else
            lblMessage.Text &= "  Data Not Saved !"
        End If
    End Sub

    Private Sub DataGrid1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.ItemCommand
        lblMessage.Text = ""
        Try
            Select Case e.CommandName
                Case "Select"
                    txtReceivedDate.Text = e.Item.Cells(1).Text.Replace("01-01-1900", "")
                    txtWONo.Text = e.Item.Cells(2).Text.Replace("&nbsp;", "")
                    txtWODate.Text = e.Item.Cells(3).Text.Replace("01-01-1900", "")
                    rblShop.ClearSelection()
                    Dim i As Int16
                    For i = 0 To rblShop.Items.Count - 1
                        If rblShop.Items(i).Text = e.Item.Cells(4).Text.Trim Then
                            rblShop.Items(i).Selected = True
                            Exit For
                        End If
                    Next
                    txtWODesc.Text = e.Item.Cells(5).Text.Replace("&nbsp;", "")
                    txtWOQty.Text = e.Item.Cells(6).Text.Replace("&nbsp;", "")
                    txtAttendedBy.Text = e.Item.Cells(7).Text.Replace("&nbsp;", "")
                    txtHourTaken.Text = e.Item.Cells(8).Text.Replace("&nbsp;", "")
                    txtStatus.Text = e.Item.Cells(9).Text.Replace("&nbsp;", "")
                    txtHandedOverTo.Text = e.Item.Cells(10).Text.Replace("&nbsp;", "")
                    txtRemarks.Text = e.Item.Cells(11).Text.Replace("&nbsp;", "")
            End Select
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
End Class
