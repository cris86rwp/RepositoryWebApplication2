Public Class mm_CloseShift_Authorisation
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblEmpCode As System.Web.UI.WebControls.Label
    Protected WithEvents lblProduct As System.Web.UI.WebControls.Label
    Protected WithEvents lblDateType As System.Web.UI.WebControls.Label
    Protected WithEvents lblInspDate As System.Web.UI.WebControls.Label
    Protected WithEvents lblInspShift As System.Web.UI.WebControls.Label
    Protected WithEvents txtQtyReqd As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfvQty As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents lblPosted As System.Web.UI.WebControls.Label
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents chkQtyToBePosted As System.Web.UI.WebControls.CheckBox
    Protected WithEvents lblReq As System.Web.UI.WebControls.Label
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    Dim row As DataRow
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
                'Response.Redirect("/InvalidSession.aspx")
                Exit Sub
            Else
                btnSave.Visible = True
                'btnSave.Enabled = False
                lblProduct.Text = "W"
                lblInspDate.Text = Now.Date
                Try
                    Dim str As String
                    Select Case Now.Hour
                        Case 6 To 13
                            str = "A"
                        Case 14 To 21
                            str = "B"
                        Case Else
                            str = "C"
                            lblInspDate.Text = Now.Date.AddDays(-1)
                    End Select
                    lblInspShift.Text = str
                    ShowDataGrid()
                    str = Nothing
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                End Try
            End If
        End If
    End Sub
    Private Sub ShowDataGrid()
        Dim dt As New DataTable()
        Try
            dt = RWF.AWMCLR.GetShiftedCount(lblInspDate.Text, lblInspShift.Text)
            If dt.Rows.Count > 0 Then
                lblReq.Text = dt.Rows(0)("ReqdWhls")
                lblPosted.Text = RWF.AWMCLR.GetPosted(lblInspDate.Text, lblInspShift.Text, 1)
            Else
                Throw New Exception("No Requeirement posted !")
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
            dt = Nothing
        End Try
    End Sub
    Private Sub txtQtyReqd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQtyReqd.TextChanged
        lblMessage.Text = ""
        'btnSave.Enabled = False
        'chkQtyToBePosted.Checked = False
        'If Val(txtQtyReqd.Text) >= Val(lblPosted.Text) Then
        '    txtQtyReqd.ForeColor = System.Drawing.Color.Black
        '    btnSave.Enabled = True
        'Else
        '    txtQtyReqd.Text = Val(txtQtyReqd.Text)
        '    txtQtyReqd.ForeColor = System.Drawing.Color.Red
        '    btnSave.Enabled = chkQtyToBePosted.Checked
        '    lblMessage.Text = "Qty Reqd and Qty Posted mis-match !"
        'End If
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim blnUpdated As Boolean
        Try
            blnUpdated = New RWF.AWMCLR().UpdateContinueShift(CDate(lblInspDate.Text), lblInspShift.Text, lblEmpCode.Text, Val(txtQtyReqd.Text))
        Catch exp As Exception
            If blnUpdated Then
                lblMessage.Text = "Update Failed : " & exp.Message
            Else
                lblMessage.Text = "Insert Failed : " & exp.Message
            End If
        Finally
            If blnUpdated Then
                lblMessage.Text = "Updated"
                txtQtyReqd.Text = 0
                ShowDataGrid()
            Else
                lblMessage.Text = "Inserted"
            End If
        End Try
        blnUpdated = Nothing
    End Sub
End Class
