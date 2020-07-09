Public Class mm_ExtendContinueShift_Authorisation
    Inherits System.Web.UI.Page
    Protected WithEvents chkHelp As System.Web.UI.WebControls.CheckBox
    Protected WithEvents lblHelp As System.Web.UI.WebControls.Label
    Protected WithEvents lblEmpCode As System.Web.UI.WebControls.Label
    Protected WithEvents lblProduct As System.Web.UI.WebControls.Label
    Protected WithEvents dgData As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblDateType As System.Web.UI.WebControls.Label
    Protected WithEvents lblInspDate As System.Web.UI.WebControls.Label
    Protected WithEvents lblInspShift As System.Web.UI.WebControls.Label
    Protected WithEvents chkQtyToBePosted As System.Web.UI.WebControls.CheckBox
    Protected WithEvents txtQtyReqd As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfvQty As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents lblPosted As System.Web.UI.WebControls.Label
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents Panel2 As System.Web.UI.WebControls.Panel
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
            ' Session("UserID") = "073947"
            'Session("Group") = "AWMCLR"
            'If Session("UserID") = "073947" AndAlso Session("Group") = "AWMCLR" Then
            chkQtyToBePosted.Text = "Number of Records to be posted"
            ' Else
            ' Response.Redirect("/InvalidSession.aspx")
            '    Exit Sub
            ' End If
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
                'Response.Redirect("/InvalidSession.aspx")
                Exit Sub
            Else
                btnSave.Visible = True
                btnSave.Enabled = False
                lblProduct.Text = "W"
                Try
                    ShowDataGrid()
                    GetNextPhlDate()
                    Dim str As New System.Text.StringBuilder()
                    If lblProduct.Text = "W" Then
                        str.Append("01. This program continues First Authorisation day's  Shift till Reqd Qty of Records are saved.")
                        str.Append("<br>")
                        str.Append("02.<B><I>Production Highlights should not have been done</I></B>")
                        str.Append("<br>")
                        str.Append("03. Records counted and saved irrespective of product Status")
                        str.Append("<br>")
                        str.Append("04.<B><I>No data should not have been saved in Final Inspection</I></B>")
                        str.Append("<br>")
                        str.Append("05. Edit till the first wheel is posted/Production Highlights generated")
                        str.Append("<br>")
                        str.Append("06. Some of the reports/queries may show figures including quantity transferred")
                        str.Append("<br>")
                        str.Append("07. This adjustment takes care of accountal of production")
                        str.Append("<br>")
                        str.Append("08. Records may suffer chronological status problems in wheel history.")
                        str.Append("<br>")
                        str.Append("09. If Reqd Qty> 100 input color turns red and until 'Number of Records to be posted' is checked Save button is disabled.")
                        str.Append("<br>")
                        str.Append("10. Click Refresh check box to know how may records are posted by FI out of required quantity.")
                    End If
                    lblHelp.Text = str.ToString
                    lblHelp.Visible = chkHelp.Checked
                    str = Nothing
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                End Try
            End If
        End If
    End Sub
    Private Sub ShowDataGrid()
        Try
            dgData.DataSource = RWF.AWMCLR.GetLastShiftedCount
            dgData.DataBind()
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
        dgData.Visible = dgData.Items.Count > 0
    End Sub
    Private Sub GetNextPhlDate()
        Dim i As Integer
        Dim dtGrid, dtNext As Date
        Dim shiftGrid, shiftNext, Str As String
        If IsNothing(dgData.Items) = False AndAlso dgData.Items.Count > 0 Then
            For i = 0 To dgData.Items.Count - 1
                lblInspDate.Text = dgData.Items(i).Cells(0).Text
                dtGrid = Format(CDate(lblInspDate.Text.Trim), "yyyy/MM/dd")
                shiftGrid = dgData.Items(i).Cells(1).Text.Trim
                lblInspDate.Text = ""
            Next
        End If
        If shiftGrid.Trim = "A" Then
            dtNext = dtGrid
            shiftNext = "B"
        ElseIf shiftGrid.Trim = "B" Then
            dtNext = dtGrid
            shiftNext = "C"
        ElseIf shiftGrid.Trim = "C" Then
            dtNext = dtGrid.AddDays(1)
            shiftNext = "A"
        End If
        Dim dt As Date = RWF.AWMCLR.LatestPHLDate
        If dt = dtNext Then
            Dim dt2 As DataTable
            dt2 = RWF.AWMCLR.getNextLatestData
            If dt2.Rows.Count > 0 Then
                lblInspDate.Text = dt2.Rows(0)("InspDate")
                lblInspShift.Text = dt2.Rows(0)("InspShift")
                txtQtyReqd.Text = IIf(IsDBNull(dt2.Rows(0)("QtyReqd")), 0, dt2.Rows(0)("QtyReqd"))
                Dim reasonable_Qty As Integer
                reasonable_Qty = 100
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
                lblInspDate.Text = dtNext
                lblInspShift.Text = shiftNext.Trim
                txtQtyReqd.Text = 0
            End If
            dt2 = Nothing
        Else
            lblInspDate.Text = dtNext
            lblInspShift.Text = shiftNext.Trim
            txtQtyReqd.Text = 0
        End If
        lblPosted.Text = RWF.AWMCLR.GetPosted(CDate(lblInspDate.Text), lblInspShift.Text)
        dt = Nothing
        i = Nothing
        dtGrid = Nothing
        dtNext = Nothing
        shiftGrid = Nothing
        shiftNext = Nothing
        Str = Nothing
    End Sub
    Private Sub chkHelp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHelp.CheckedChanged
        lblHelp.Visible = chkHelp.Checked
    End Sub
    Private Sub txtQtyReqd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQtyReqd.TextChanged
        Dim reasonable_Qty As Integer = 100
        btnSave.Enabled = False
        chkQtyToBePosted.Checked = False
        If Val(txtQtyReqd.Text) > 0 Then
            If Val(txtQtyReqd.Text) > reasonable_Qty Then
                txtQtyReqd.Text = Val(txtQtyReqd.Text)
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
        btnSave.Enabled = (chkQtyToBePosted.Checked Or (Val(txtQtyReqd.Text) < 100 AndAlso Val(txtQtyReqd.Text) > 0)) AndAlso lblInspDate.Text <> "" AndAlso lblEmpCode.Text <> ""
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        If CDate(lblInspDate.Text) > Now.Date.AddDays(1) Then
            lblMessage.Text = "InValid Date !"
            Exit Sub
        End If
        Try
            lblMessage.Text = New RWF.AWMCLR().ContinueShift(CDate(lblInspDate.Text), lblInspShift.Text, lblEmpCode.Text, Val(txtQtyReqd.Text))
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
End Class
