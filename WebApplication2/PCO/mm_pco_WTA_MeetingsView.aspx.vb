Public Class mm_pco_WTA_MeetingsView
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
            'strMode = "add"
            'strMode = "edit"
            'strMode = "delete"
            strMode = "view"
            ' strMode = Request.QueryString("mode")
            ViewState("mode") = strMode
            LblMode.Text = strMode
            populateGrid()
            If strMode = "edit" Or strMode = "delete" Then
                GetWTANumberList()
                LblWTANumber.Visible = True
                DdlWTANumber.Visible = True
            ElseIf strMode = "add" Then
                LblWTANumber.Visible = False
                DdlWTANumber.Visible = False
            ElseIf strMode = "view" Then
                Panel1.Visible = False
                populateGrid()
            End If
        End If
    End Sub
    Private Sub populateGrid()
        DgData.DataSource = PCO.tables.WTA_NumberList
        DgData.DataBind()
    End Sub
    Private Sub GetWTANumberList()
        Dim dtNumberList As DataTable
        dtNumberList = PCO.tables.WTA_NumberList
        DdlWTANumber.DataSource = dtNumberList.DefaultView
        DdlWTANumber.DataTextField = dtNumberList.Columns(1).ColumnName
        DdlWTANumber.DataValueField = dtNumberList.Columns(0).ColumnName
        DdlWTANumber.DataBind()
        DdlWTANumber.Items.Insert(0, New ListItem("select", 0))
    End Sub
    Private Sub txtWTADate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtWTADate.TextChanged
        LblMessage.Text = ""
        Dim dt As Date
        Try
            dt = CDate(TxtWTADate.Text.Trim)
        Catch exp As Exception
            LblMessage.Text = "Date not in correct format"
        End Try
    End Sub
    Private Sub ddlWTANumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DdlWTANumber.SelectedIndexChanged
        LblMessage.Text = ""
        TxtWTANumber.Text = ""
        TxtWTADate.Text = ""
        mode = CType(ViewState("mode"), String)
        If mode = "edit" Or mode = "delete" Then
            If DdlWTANumber.SelectedItem.Text = "select" Then
                LblMessage.Text = " Please select WTA Number "
                Exit Sub
            Else
                Try
                    Dim WTA_Prod As New PCO.WTA_NumberList()
                    ViewState("WTAProd") = WTA_Prod
                    WTA_Prod.GetWtaRefDetails(DdlWTANumber.SelectedItem.Value.Trim)
                    TxtWTANumber.Text = WTA_Prod.WtaNumber
                    TxtWTADate.Text = WTA_Prod.WtaDate
                    TxtRemarks.Text = WTA_Prod.WTARefRemarks
                Catch exp As Exception
                    LblMessage.Text = exp.Message
                End Try
            End If
        End If
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        LblMessage.Text = ""
        mode = CType(ViewState("mode"), String)
        Dim Save As Boolean
        If mode = "add" Then
            If TxtWTANumber.Text = "" Then
                LblMessage.Text = " Please enter WTA Number "
                Exit Sub
            Else
                Save = SaveWTANumber(mode)
            End If
        ElseIf mode = "edit" Or mode = "delete" Then
            If DdlWTANumber.SelectedItem.Text = "select" Then
                LblMessage.Text = " Please select WTA Number ! "
                Exit Sub
            Else
                Save = SaveWTANumber(mode)
            End If
        End If
        If Save = True Then
            LblMessage.Text = " Data Saved ! "
        Else
            LblMessage.Text = " Data Saving error " & LblMessage.Text
        End If
    End Sub
    Private Function SaveWTANumber(ByVal mode As String) As Boolean
        Dim blnSave As Boolean
        Try
            CType(ViewState("WTAProd"), PCO.WTA_NumberList).WtaNumber = TxtWTANumber.Text.Trim
            CType(ViewState("WTAProd"), PCO.WTA_NumberList).WtaDate = TxtWTADate.Text.Trim
            CType(ViewState("WTAProd"), PCO.WTA_NumberList).WTARefRemarks = TxtRemarks.Text.Trim
            CType(ViewState("WTAProd"), PCO.WTA_NumberList).Save(IIf(mode = "delete", True, False), IIf(mode = "add", 0, TxtWTANumber.Text.Trim))
            If mode = "add" Then
                DdlWTANumber.ClearSelection()
                DdlWTANumber.SelectedIndex = 0
            Else
                GetWTANumberList()
                DdlWTANumber.ClearSelection()
                DdlWTANumber.SelectedIndex = 0
            End If
            populateGrid()
            TxtWTANumber.Text = ""
            TxtWTADate.Text = ""
            TxtRemarks.Text = ""
            blnSave = True
        Catch exp As Exception
            blnSave = False
            LblMessage.Text = exp.Message
        End Try
        Return blnSave
    End Function
    Private Sub TxtWTANumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtWTANumber.TextChanged
        mode = CType(ViewState("mode"), String)
        If mode = "add" Then
            If TxtWTANumber.Text = "" Then
                LblMessage.Text = " Please enter WTA Number "
                Exit Sub
            Else
                Dim WTA_Prod As New PCO.WTA_NumberList()
                ViewState("WTAProd") = WTA_Prod
            End If
        End If
    End Sub
End Class
