Public Class SandTestResults
    Inherits System.Web.UI.Page
    Protected WithEvents txtOperator As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSentDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtCTS As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtHTS As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblResult As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtTestedDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSP As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblShift As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtExpectedTestDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents rblBatch As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel

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

        ' Page.Theme = themeValue
        Page.Theme = Session("Theme")
    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None
        'Put user code to initialize the page here
        If IsPostBack = False Then
            txtOperator.Text = Session("USERID")
            txtSentDate.Text = Now.Date
            txtTestedDate.Text = Now.Date
            txtExpectedTestDate.Text = Now.Date
            FillGrid()
        End If
    End Sub

    Private Sub FillGrid()
        DataGrid1.SelectedIndex = -1
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Clear()
        Dim dt As DataTable
        Try
            dt = metLab.tables.SandSamples(CDate(txtSentDate.Text))
            If dt.Rows.Count = 0 Then
                Throw New Exception("No batches present for the selected date")
            Else
                rblBatch.DataSource = dt
                rblBatch.DataTextField = dt.Columns("Batch").ColumnName
                rblBatch.DataValueField = dt.Columns("Batch").ColumnName
                rblBatch.DataBind()
                rblBatch.SelectedIndex = 0
                Dim i As Int16 = 0
                For i = 0 To rblShift.Items.Count - 1
                    If rblShift.Items(i).Text = dt.Rows(0)(1) Then
                        rblShift.Items(i).Selected = True
                        Exit For
                    End If
                Next
                txtCTS.Text = IIf(IsDBNull(dt.Rows(0)(3)), 0, dt.Rows(0)(3))
                txtHTS.Text = IIf(IsDBNull(dt.Rows(0)(4)), 0, dt.Rows(0)(4))
                txtSP.Text = IIf(IsDBNull(dt.Rows(0)(5)), 0, dt.Rows(0)(5))
                DataGrid1.DataSource = dt
                DataGrid1.DataBind()
                lblMessage.Text = "Please select Batch from the Radio Button below to Edit !"
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtSentDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSentDate.TextChanged
        lblMessage.Text = ""
        Try
            Dim dt As Date = CDate(txtSentDate.Text)
            DataGrid1.CurrentPageIndex = 0
            FillGrid()
        Catch
            lblMessage.Text &= "Enter Valid date in 'dd/mm/yyyy' Format"
            txtSentDate.Text = ""
        End Try
    End Sub

    Private Sub txtTestedDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTestedDate.TextChanged
        lblMessage.Text = ""
        Try
            Dim dt As Date = CDate(txtTestedDate.Text)
        Catch
            lblMessage.Text &= "Enter Valid date in 'dd/mm/yyyy' Format"
            txtTestedDate.Text = ""
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        Dim done As Boolean
        Try
            done = New metLab.ChemicalTesting().SaveSandSample(rblBatch.SelectedItem.Text.ToUpper.Trim, Val(txtCTS.Text), Val(txtHTS.Text), Val(txtSP.Text), CDate(txtSentDate.Text), rblShift.SelectedItem.Text, CDate(txtTestedDate.Text), txtOperator.Text.Trim, rblResult.SelectedItem.Text, CDate(txtExpectedTestDate.Text))
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If done Then
            DataGrid1.CurrentPageIndex = 0
            DataGrid1.EditItemIndex = -1
            FillGrid()
            Clear()
            lblMessage.Text = "Data Saved !" & lblMessage.Text
        Else
            lblMessage.Text &= "Data Saveing Failed !"
        End If
    End Sub

    Private Sub rblBatch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblBatch.SelectedIndexChanged
        lblMessage.Text = ""
        Clear()
        Dim dt As DataTable
        Try
            dt = metLab.tables.SandSamples(CDate(txtSentDate.Text), rblBatch.SelectedItem.Text)
            rblShift.ClearSelection()
            Dim i As Int16 = 0
            For i = 0 To rblShift.Items.Count - 1
                If rblShift.Items(i).Text = dt.Rows(0)(1) Then
                    rblShift.Items(i).Selected = True
                    Exit For
                End If
            Next
            txtCTS.Text = IIf(IsDBNull(dt.Rows(0)(3)), 0, dt.Rows(0)(3))
            txtHTS.Text = IIf(IsDBNull(dt.Rows(0)(4)), 0, dt.Rows(0)(4))
            txtSP.Text = IIf(IsDBNull(dt.Rows(0)(5)), 0, dt.Rows(0)(5))
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub Clear()
        txtCTS.Text = ""
        txtHTS.Text = ""
        txtSP.Text = ""
    End Sub
End Class
