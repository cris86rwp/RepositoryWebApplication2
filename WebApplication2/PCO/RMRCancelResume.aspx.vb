Public Class RMRCancelResume
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtRmrNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboRmr As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnGenerateRMR As System.Web.UI.WebControls.Button
    Protected WithEvents btnExit As System.Web.UI.WebControls.Button
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents rblType As System.Web.UI.WebControls.RadioButtonList
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
        Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None
        'Put user code to initialize the page here
        If Page.IsPostBack = False Then
            SetTable()
        End If
    End Sub
    Private Sub SetTable()
        txtRmrNo.Text = ""
        txtRmrNo.Visible = False
        cboRmr.Enabled = False
        cboRmr.Visible = False
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Select Case rblType.SelectedItem.Text
            Case "suspend"
                btnGenerateRMR.Text = "suspend"
                If txtRmrNo.Visible = False Then
                    txtRmrNo.Visible = True
                End If
            Case "resume"
                btnGenerateRMR.Text = "Resume"
                If cboRmr.Enabled = False Then
                    cboRmr.Enabled = True
                End If
                If cboRmr.Visible = False Then
                    cboRmr.Visible = True
                End If
                If txtRmrNo.Visible = True Then
                    txtRmrNo.Visible = False
                End If
                FillCancelledRmRs()
                If cboRmr.Items.Count = 0 Then
                    lblMessage.Text = "No Suspended RmR Nos Existing."
                    Exit Sub
                End If
                fillRmRData()
        End Select
    End Sub
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("selectModule.aspx")
    End Sub
    Private Sub FillCancelledRmRs()
        Dim dt As DataTable
        Try
            dt = PCO.tables.FillCancelledRmRs
            cboRmr.DataSource = dt
            cboRmr.DataTextField = dt.Columns("number").ColumnName
            cboRmr.DataValueField = dt.Columns("number").ColumnName
            cboRmr.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
#Disable Warning BC42104 ' Variable is used before it has been assigned a value
            dt.Dispose()
#Enable Warning BC42104 ' Variable is used before it has been assigned a value
            dt = Nothing
        End Try
        If cboRmr.Items.Count = 0 Then
            lblMessage.Text = "No Suspended RmR Nos Existing."
            Exit Sub
        End If
    End Sub
    Private Sub fillRmRData()
        Dim dt As DataTable
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            If rblType.SelectedItem.Text = "suspend" Then
                dt = PCO.tables.fillRmRData(rblType.SelectedItem.Text, txtRmrNo.Text)
            Else
                dt = PCO.tables.fillRmRData(rblType.SelectedItem.Text, cboRmr.SelectedItem.Text)
            End If
            If dt.Rows.Count > 0 Then
                DataGrid1.DataSource = dt
                DataGrid1.DataBind()
            Else
                lblMessage.Text = "The RMR No:" & txtRmrNo.Text & " is InValid !"
                txtRmrNo.Text = ""
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
#Disable Warning BC42104 ' Variable is used before it has been assigned a value
            dt.Dispose()
#Enable Warning BC42104 ' Variable is used before it has been assigned a value
            dt = Nothing
        End Try
    End Sub

    Private Sub rblType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblType.SelectedIndexChanged
        lblMessage.Text = ""
        SetTable()
    End Sub

    Private Sub txtRmrNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRmrNo.TextChanged
        lblMessage.Text = ""
        If txtRmrNo.Visible Then
            fillRmRData()
        End If
    End Sub

    Private Sub cboRmr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRmr.SelectedIndexChanged
        lblMessage.Text = ""
        If cboRmr.Enabled Then
            fillRmRData()
        End If
    End Sub

    Private Sub btnGenerateRMR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerateRMR.Click
        lblMessage.Text = ""
        Dim Done As Boolean
        Try
            If rblType.SelectedItem.Text = "suspend" Then
                If btnGenerateRMR.Text = "conFirm" Then
                    Done = New PCO.PCO().RegulateRMR(rblType.SelectedItem.Text, CInt(txtRmrNo.Text))
                    If Done Then
                        lblMessage.Text = "RMR No:" & txtRmrNo.Text & " Is Suspended Successfully."
                        btnGenerateRMR.Text = "Suspend"
                    End If
                Else
                    btnGenerateRMR.Text = "conFirm"
                    Exit Sub
                End If
            ElseIf rblType.SelectedItem.Text = "resume" Then
                Done = New PCO.PCO().RegulateRMR(rblType.SelectedItem.Text, CInt(cboRmr.SelectedItem.Text))
                If Done Then lblMessage.Text = "RMR No:" & cboRmr.SelectedItem.Text & " Is Resumed Successfully."
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        Done = Nothing
    End Sub
End Class
