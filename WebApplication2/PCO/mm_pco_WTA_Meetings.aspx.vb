Public Class mm_pco_WTA_Meetings
    Inherits System.Web.UI.Page
    Protected WithEvents LblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents DdlWTANumber As System.Web.UI.WebControls.DropDownList
    Protected WithEvents LblWTANumber As System.Web.UI.WebControls.Label
    Protected WithEvents TxtWTANumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtWTADate As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents BtnSave As System.Web.UI.WebControls.Button
    Protected WithEvents DgData As System.Web.UI.WebControls.DataGrid
    Protected WithEvents LblMode As System.Web.UI.WebControls.Label
    Dim strMode As String
    Dim mode As String
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
            strMode = "add"
            'strMode = "edit"
            'strMode = "delete"
            'strMode = "view"
            ' strMode = Request.QueryString("mode")
            ViewState("mode") = strMode
            lblMode.Text = strMode
            populateGrid()
            If strMode = "edit" Or strMode = "delete" Then
                GetWTANumberList()
                lblWTANumber.Visible = True
                ddlWTANumber.Visible = True
            ElseIf strMode = "add" Then
                lblWTANumber.Visible = False
                ddlWTANumber.Visible = False
            ElseIf strMode = "view" Then
                Panel1.Visible = False
                populateGrid()
            End If
        End If
    End Sub
    Private Sub populateGrid()
        dgData.DataSource = PCO.tables.WTA_NumberList
        dgData.DataBind()
    End Sub
    Private Sub GetWTANumberList()
        Dim dtNumberList As DataTable
        dtNumberList = PCO.tables.WTA_NumberList
        ddlWTANumber.DataSource = dtNumberList.DefaultView
        ddlWTANumber.DataTextField = dtNumberList.Columns(1).ColumnName
        ddlWTANumber.DataValueField = dtNumberList.Columns(0).ColumnName
        ddlWTANumber.DataBind()
        ddlWTANumber.Items.Insert(0, New ListItem("select", 0))
    End Sub
    Private Sub txtWTADate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWTADate.TextChanged
        lblMessage.Text = ""
        Dim dt As Date
        Try
            dt = CDate(txtWTADate.Text.Trim)
        Catch exp As Exception
            lblMessage.Text = "Date not in correct format"
        End Try
    End Sub
    Private Sub ddlWTANumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlWTANumber.SelectedIndexChanged
        lblMessage.Text = ""
        txtWTANumber.Text = ""
        txtWTADate.Text = ""
        mode = CType(viewstate("mode"), String)
        If mode = "edit" Or mode = "delete" Then
            If ddlWTANumber.SelectedItem.Text = "select" Then
                lblMessage.Text = " Please select WTA Number "
                Exit Sub
            Else
                Try
                    Dim WTA_Prod As New PCO.WTA_NumberList()
                    viewstate("WTAProd") = WTA_Prod
                    WTA_Prod.GetWtaRefDetails(ddlWTANumber.SelectedItem.Value.Trim)
                    txtWTANumber.Text = WTA_Prod.WtaNumber
                    txtWTADate.Text = WTA_Prod.WtaDate
                    txtRemarks.Text = WTA_Prod.WTARefRemarks
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                End Try
            End If
        End If
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        mode = CType(viewstate("mode"), String)
        Dim Save As Boolean
        If mode = "add" Then
            If txtWTANumber.Text = "" Then
                lblMessage.Text = " Please enter WTA Number "
                Exit Sub
            Else
                Save = SaveWTANumber(mode)
            End If
        ElseIf mode = "edit" Or mode = "delete" Then
            If ddlWTANumber.SelectedItem.Text = "select" Then
                lblMessage.Text = " Please select WTA Number ! "
                Exit Sub
            Else
                Save = SaveWTANumber(mode)
            End If
        End If
        If Save = True Then
            lblMessage.Text = " Data Saved ! "
        Else
            lblMessage.Text = " Data Saving error " & lblMessage.Text
        End If
    End Sub
    Private Function SaveWTANumber(ByVal mode As String) As Boolean
        Dim blnSave As Boolean
        Try
            CType(viewstate("WTAProd"), PCO.WTA_NumberList).WtaNumber = txtWTANumber.Text.Trim
            CType(viewstate("WTAProd"), PCO.WTA_NumberList).WtaDate = txtWTADate.Text.Trim
            CType(viewstate("WTAProd"), PCO.WTA_NumberList).WTARefRemarks = txtRemarks.Text.Trim
            CType(viewstate("WTAProd"), PCO.WTA_NumberList).Save(IIf(mode = "delete", True, False), IIf(mode = "add", 0, txtWTANumber.Text.Trim))
            If mode = "add" Then
                ddlWTANumber.ClearSelection()
                ddlWTANumber.SelectedIndex = 0
            Else
                GetWTANumberList()
                ddlWTANumber.ClearSelection()
                ddlWTANumber.SelectedIndex = 0
            End If
            populateGrid()
            txtWTANumber.Text = ""
            txtWTADate.Text = ""
            txtRemarks.Text = ""
            blnSave = True
        Catch exp As Exception
            blnSave = False
            lblMessage.Text = exp.Message
        End Try
        Return blnSave
    End Function
    Private Sub TxtWTANumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWTANumber.TextChanged
        mode = CType(ViewState("mode"), String)
        If mode = "add" Then
            If txtWTANumber.Text = "" Then
                lblMessage.Text = " Please enter WTA Number "
                Exit Sub
            Else
                Dim WTA_Prod As New PCO.WTA_NumberList()
                ViewState("WTAProd") = WTA_Prod
            End If
        End If
    End Sub
End Class
