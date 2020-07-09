Public Class mouldCondemnation
    Inherits System.Web.UI.Page
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblShift As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents lblOperator As System.Web.UI.WebControls.Label
    Protected WithEvents lblMouldType As System.Web.UI.WebControls.Label
    Protected WithEvents lblMouldStatus As System.Web.UI.WebControls.Label
    Protected WithEvents lblInitialHt As System.Web.UI.WebControls.Label
    Protected WithEvents lblFinalHt As System.Web.UI.WebControls.Label
    Protected WithEvents txtMouldNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents rfvMldNo As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
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
        If Page.IsPostBack = False Then
            'Session("UserID") = "074405"
            txtDate.Text = Now.Date
            lblOperator.Text = Session("UserID")
            Try
                setobj()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
    Private Sub setobj()
        If Not IsNothing(Session("Mld")) Then Session.Remove("Mld")
        Session.Remove("Mld")
        Dim oMld As New MouldMaster.Moulds()
        Session("Mld") = oMld
        CType(Session("Mld"), MouldMaster.Moulds).ForCondemnation = True
        CType(Session("Mld"), MouldMaster.Moulds).MouldDate = txtDate.Text
        oMld = Nothing
        FillGrid()
    End Sub
    Private Sub FillGrid()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            DataGrid1.DataSource = CType(Session("Mld"), MouldMaster.Moulds).CondemnedMouldsSavedData
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
    End Sub
    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        Dim dt As New Date()
        Try
            dt = txtDate.Text.Trim
            If dt > Now.Date Then
                txtDate.Text = ""
                lblMessage.Text = "Date cannot be greater than Current Date"
            Else
                CType(Session("Mld"), MouldMaster.Moulds).MouldDate = dt
                txtDate.Text = dt
            End If
            FillGrid()
        Catch exp As Exception
            txtDate.Text = ""
            lblMessage.Text = exp.Message
        End Try
        dt = Nothing
    End Sub
    Private Sub Clear()
        lblMouldType.Text = ""
        lblMouldStatus.Text = ""
        lblInitialHt.Text = ""
        lblFinalHt.Text = ""
        txtRemarks.Text = ""
    End Sub
    Private Sub txtMouldNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMouldNumber.TextChanged
        lblMessage.Text = ""
        Try
            Clear()
            CType(Session("Mld"), MouldMaster.Moulds).MouldNumber = txtMouldNumber.Text.Trim
            lblMouldType.Text = CType(Session("Mld"), MouldMaster.Moulds).MouldType
            lblMouldStatus.Text = CType(Session("Mld"), MouldMaster.Moulds).MouldStatus
            lblInitialHt.Text = CType(Session("Mld"), MouldMaster.Moulds).Mould_intial_height
            lblFinalHt.Text = CType(Session("Mld"), MouldMaster.Moulds).Mould_final_height
            txtRemarks.Text = CType(Session("Mld"), MouldMaster.Moulds).Remarks
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        Try
            CType(Session("Mld"), MouldMaster.Moulds).Shift = rblShift.SelectedItem.Text
            If CType(Session("Mld"), MouldMaster.Moulds).ValidCondemnationDate Then
                CType(Session("Mld"), MouldMaster.Moulds).Remarks = txtRemarks.Text.Trim
                CType(Session("Mld"), MouldMaster.Moulds).CondemnMould()
                lblMessage.Text = CType(Session("Mld"), MouldMaster.Moulds).Message
                Clear()
            Else
                lblMessage.Text = CType(Session("Mld"), MouldMaster.Moulds).Message
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            setobj()
        End Try
    End Sub
End Class
