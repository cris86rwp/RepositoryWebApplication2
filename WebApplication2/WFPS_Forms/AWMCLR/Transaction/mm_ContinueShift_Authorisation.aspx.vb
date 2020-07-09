Public Class mm_ContinueShift_Authorisation
    Inherits System.Web.UI.Page
    Protected WithEvents lblEmpCode As System.Web.UI.WebControls.Label
    Protected WithEvents lblInspDate As System.Web.UI.WebControls.Label
    Protected WithEvents lblInspShift As System.Web.UI.WebControls.Label
    Protected WithEvents lblProduct As System.Web.UI.WebControls.Label
    Protected WithEvents lblPosted As System.Web.UI.WebControls.Label
    Protected WithEvents txtQtyReqd As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblHelp As System.Web.UI.WebControls.Label
    Protected WithEvents chkHelp As System.Web.UI.WebControls.CheckBox
    Protected WithEvents lblMode As System.Web.UI.WebControls.Label
    Protected WithEvents chkQtyToBePosted As System.Web.UI.WebControls.CheckBox
    Protected WithEvents rfvQty As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents lblDateType As System.Web.UI.WebControls.Label
    Protected WithEvents dgData As System.Web.UI.WebControls.DataGrid
    Protected WithEvents aspTbl As System.Web.UI.WebControls.Table
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
            ' Session("UserID") = "073947"
            'Session("Group") = "AWMCLR"
            'If Session("UserID") = "073947" AndAlso Session("Group") = "AWMCLR" Then
            chkQtyToBePosted.Text = "Number of Records to be posted"
            lblDateType.Text = "Inspection Date"
            'Else
            ' Response.Redirect("/InvalidSession.aspx")
            '    Exit Sub
            'End If
            Try
                Dim oEmp As New rwfGen.Employee()
                If oEmp.Check(Session("UserID"), Session("Group")) = True Then
                    lblEmpCode.Text = Session("UserID")
                Else
                    lblEmpCode.Text = ""
                End If
                oEmp = Nothing
            Catch exp As Exception
                lblEmpCode.Text = ""
                lblMessage.Text = exp.Message
            End Try
            If lblEmpCode.Text = "" Then
                btnSave.Visible = True
                'False
                ' Response.Redirect("/InvalidSession.aspx")
                Exit Sub
            Else
                lblInspShift.Text = "A"
                btnSave.Visible = True
                btnSave.Enabled = False
                lblProduct.Text = "W"
                GetNextPhlDate()
            End If
            Dim str As New System.Text.StringBuilder()
            If lblProduct.Text = "W" Then
                str.Append("01. This program continues Previous day and shift till Reqd Qty of Records are saved.")
                str.Append("<br>")
                str.Append("02.<B><I>Production Highlights should not have been done</I></B>")
                str.Append("<br>")
                str.Append("03. Records counted and saved irrespective of product Status")
                str.Append("<br>")
                str.Append("04.<B><I>No data should have been saved in Final Inspection</I></B>")
                str.Append("<br>")
                str.Append("05. Edit till the first wheel is posted/Production Highlights generated")
                str.Append("<br>")
                str.Append("06. Some of the reports/queries may show figures including quantity transferred")
                str.Append("<br>")
                str.Append("07. This adjustment takes care of accountal of production")
                str.Append("<br>")
                str.Append("08. Records may suffer chronological status problems in wheel history.")
                str.Append("<br>")
                str.Append("09. If Reqd Qty> 40 input color turns red and until 'Number of Records to be posted' ")
                str.Append("<br>")
                str.Append("is checked Save button is disabled.")
                str.Append("<br>")
                str.Append("10. Click Refresh check box to know how may records are posted by FI out of required quantity.")
            End If
            lblHelp.Text = str.ToString
            lblHelp.Visible = chkHelp.Checked
            ShowDataGrid()
            str = Nothing
        End If
    End Sub

    Private Sub ShowDataGrid()
        Try
            dgData.DataSource = RWF.AWMCLR.GetShiftedCount
            dgData.DataBind()
        Catch exp As Exception
            dgData.DataSource = Nothing
            dgData.DataBind()
        Finally
            dgData.Visible = dgData.Items.Count > 0
        End Try
    End Sub
    Private Sub GetNextPhlDate()
        Dim data As DataTable
        Dim reasonable_Qty As Integer
        Try
            data = RWF.AWMCLR.getLatestData()
            If data.Rows.Count > 0 Then
                txtQtyReqd.Text = data.Rows(0)("QtyReqd")
                lblInspDate.Text = data.Rows(0)("InspDate")
                lblInspShift.Text = data.Rows(0)("InspShift")
                lblPosted.Text = RWF.AWMCLR.GetPosted(CDate(lblInspDate.Text), lblInspShift.Text)
                reasonable_Qty = 40
                If txtQtyReqd.Text > reasonable_Qty Then
                    txtQtyReqd.ForeColor = System.Drawing.Color.Red
                    chkQtyToBePosted.Checked = False
                    btnSave.Enabled = False
                Else
                    txtQtyReqd.ForeColor = System.Drawing.Color.Black
                    chkQtyToBePosted.Checked = False
                    btnSave.Enabled = True
                End If
            Else
                lblMessage.Text = "Invalid Data !"
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        data = Nothing
        reasonable_Qty = Nothing
    End Sub
    Private Sub chkHelp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHelp.CheckedChanged
        lblHelp.Visible = chkHelp.Checked
    End Sub
    Private Sub txtQtyReqd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQtyReqd.TextChanged
        Dim reasonable_Qty As Integer
        reasonable_Qty = 40
        btnSave.Enabled = False
        chkQtyToBePosted.Checked = False
        If Val(txtQtyReqd.Text) > 0 Then
            If Val(txtQtyReqd.Text) > reasonable_Qty Then
                txtQtyReqd.ForeColor = System.Drawing.Color.Red
                btnSave.Enabled = chkQtyToBePosted.Checked
            Else
                txtQtyReqd.ForeColor = System.Drawing.Color.Black
                btnSave.Enabled = True
            End If
        Else
            btnSave.Enabled = False
        End If
        reasonable_Qty = Nothing
    End Sub
    Private Sub chkQtyToBePosted_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkQtyToBePosted.CheckedChanged
        btnSave.Enabled = (chkQtyToBePosted.Checked Or (Val(txtQtyReqd.Text) < 40 AndAlso Val(txtQtyReqd.Text) > 0)) AndAlso lblInspDate.Text <> "" AndAlso lblEmpCode.Text <> ""
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            lblMessage.Text = New RWF.AWMCLR().ContinueShift(CDate(lblInspDate.Text), lblInspShift.Text, lblEmpCode.Text, Val(txtQtyReqd.Text))
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
End Class
