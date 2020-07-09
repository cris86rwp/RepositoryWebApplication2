Public Class HoldHeatsFromFIPassing
    Inherits System.Web.UI.Page
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents txtMessage As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtToDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFromDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtHeat As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblEmpCode As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
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


    Protected Sub dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Page.IsPostBack = False Then
            Session("UserID") = "078887"
            txtFromDate.Text = Now.Date
            txtToDate.Text = Now.Date
            Try
                If Session("UserID") = "" Then
                    Response.Redirect("InvalidSession.aspx")
                    Exit Sub
                Else
                    FillSavedList()
                End If
            Catch exp As Exception
                Response.Redirect("InvalidSession.aspx")
                Exit Sub
            End Try
            lblEmpCode.Text = Session("UserID")
        End If
    End Sub
    Private Sub FillSavedList()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Dim dt As DataTable
        Try
            dt = RWF.CLRINS.HoldHeatsFromFIPassing
            DataGrid1.SelectedIndex = -1
            If IsNothing(DataGrid1.CurrentPageIndex) Then DataGrid1.CurrentPageIndex = 0
            If dt.Rows.Count > 10 Then
                DataGrid1.AllowPaging = True
                DataGrid1.PageSize = 10
                DataGrid1.PagerStyle.Mode = PagerMode.NumericPages
            End If
            DataGrid1.DataSource = dt
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt = Nothing
        End Try
    End Sub
    Private Sub txtHeat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHeat.TextChanged
        lblMessage.Text = ""
        Try
            If Not RWF.CLRINS.ValidHeat(txtHeat.Text) Then
                lblMessage.Text = "InValid Heat Number !"
                txtHeat.Text = ""
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Function CheckDate(ByVal frdt As Date, ByVal todt As Date) As Boolean
        Dim blnDoNotContinue As Boolean
        Try
            If frdt > todt Then
                lblMessage.Text = "From Date is more than To Date."
                txtFromDate.Text = ""
                txtToDate.Text = ""
                blnDoNotContinue = True
            End If
            If frdt > Today Then
                lblMessage.Text = "From Date is more than ToDay."
                txtFromDate.Text = ""
                txtToDate.Text = ""
                blnDoNotContinue = True
            End If
            If todt > Today Then
                lblMessage.Text = "To Date is more than ToDay."
                txtFromDate.Text = ""
                txtToDate.Text = ""
                blnDoNotContinue = True
            End If
        Catch exp As Exception
            lblMessage.Text = "Date Error : " & exp.Message
            txtFromDate.Text = ""
            txtToDate.Text = ""
            blnDoNotContinue = True
        End Try
        Return blnDoNotContinue
    End Function
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        If Val(txtHeat.Text) = 0 Then
            lblMessage.Text = "InValid Heat Number !"
            Exit Sub
        End If
        If txtMessage.Text.Trim.Length = 0 Then
            lblMessage.Text = "InValid Data without Message !"
            Exit Sub
        End If
        Try
            If New RWF.CLRINS().SaveHeats("mm_HoldHeatsFromFIPassing", Val(txtHeat.Text), CDate(txtFromDate.Text), CDate(txtToDate.Text), txtMessage.Text.Trim, lblEmpCode.Text.Trim) Then
                lblMessage.Text = "Heat Number successfully inserted !"
                txtHeat.Text = ""
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        Try
            FillSavedList()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub DataGrid1_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid1.PageIndexChanged
        lblMessage.Text = ""
        Try
            DataGrid1.CurrentPageIndex = e.NewPageIndex
            DataGrid1.EditItemIndex = -1
            FillSavedList()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub DataGrid1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.ItemCommand
        lblMessage.Text = ""
        Select Case e.CommandName
            Case "Select"
                txtHeat.Text = e.Item.Cells(1).Text
                txtFromDate.Text = e.Item.Cells(2).Text.Replace("&nbsp;", "")
                txtToDate.Text = e.Item.Cells(3).Text.Replace("&nbsp;", "")
                txtMessage.Text = e.Item.Cells(4).Text
        End Select
    End Sub
End Class

