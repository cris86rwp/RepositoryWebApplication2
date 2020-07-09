Public Class EmpyLadleWeightsEntry
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblGroupName As System.Web.UI.WebControls.Label
    Protected WithEvents txtHeat_number As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtw3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents pnlMould As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlMelt As System.Web.UI.WebControls.Panel
    Protected WithEvents txtw1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtw2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblw1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblw2 As System.Web.UI.WebControls.Label
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents lblGoup As System.Web.UI.WebControls.Label
    Protected WithEvents txtLadle_number As System.Web.UI.WebControls.TextBox
    Protected WithEvents li As System.Web.UI.WebControls.Label
    Protected WithEvents Ht As System.Web.UI.WebControls.Label
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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        'Put user code to initialize the page here
        lblGoup.Visible = False
        If Page.IsPostBack = False Then
            lblGoup.Text = Session("Group")
            Dim UserId As String = Session("UserID")
            Dim InValid As Boolean = False
            'Un commented due to ladle weight entry check
            'lblGoup.Text = "WHLMLT"
            'UserId = "078844"
            '---------------------------------------
            Try
                lblGroupName.Text = RMR.GetGroupName(lblGoup.Text, UserId)
                If lblGroupName.Text.Trim.Length > 0 Then InValid = True
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            'If Not InValid Then
            '    Response.Redirect("/wap/logon.aspx")
            'Else
            '    SetLabel()
            'End If
        End If
    End Sub
    Private Sub SetLabel()
        ''pnlMould.Visible = False
        ''pnlMelt.Visible = False
        'If lblGoup.Text = "MLDING" Then
        '    pnlMould.Visible = True
        '    clearForm()
        'Else
        '    pnlMelt.Visible = True
        '    clearMeltForm()
        'End If
    End Sub
    Private Sub txtHeat_number_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHeat_number.TextChanged
        If IsNumeric(txtHeat_number.Text) = False Then
            lblMessage.Text = "Please enter nuemeric heat number "
            txtHeat_number.Text = ""
            Exit Sub
        Else
            lblMessage.Text = ""
        End If
        If lblGoup.Text = "WHLMLT" Then
            Dim intcount As Integer
            intcount = RWF.MLDING.CheckLadleWeights(CInt(txtHeat_number.Text))
            If intcount = 0 Then
                lblMessage.Text = "Heat Number " & txtHeat_number.Text & " Weights W1 and W2 are Not entered , Please wait for some time"
                txtHeat_number.Text = ""
            Else
                lblMessage.Text = ""
            End If
            If Trim(txtHeat_number.Text) <> "" Then
                populateData()
            Else
                clearForm()
            End If
            intcount = Nothing
        Else
            Dim intcount As Integer = RWF.Melting.CheckHeat(CInt(txtHeat_number.Text))
            If intcount = 0 Then
                lblMessage.Text = "Heat Number " & txtHeat_number.Text & " Not entered in Heat Sheet-301 form, Please wait for some time"
                txtHeat_number.Text = ""
            Else
                lblMessage.Text = ""
            End If
            If Trim(txtHeat_number.Text) <> "" Then
                populateMeltData()
            Else
                clearMeltForm()
            End If
            intcount = Nothing
        End If
    End Sub
    Private Sub populateData()
        Dim dt As DataTable
        dt = RWF.MLDING.LadleWeights(CInt(txtHeat_number.Text))
        If dt.Rows.Count > 0 Then
            If IsDBNull(dt.Rows(0)("w1")) = False Then
                lblw1.Text = dt.Rows(0)("w1")
            Else
                lblw1.Text = ""
            End If

            If IsDBNull(dt.Rows(0)("w2")) = False Then
                lblw2.Text = dt.Rows(0)("w2")
            Else
                lblw2.Text = ""
            End If
            If IsDBNull(dt.Rows(0)("w3")) = False Then
                txtw3.Text = dt.Rows(0)("w3")
            Else
                txtw3.Text = ""
            End If
        Else
            lblMessage.Text = "No data exists for this Heat " & txtHeat_number.Text
            clearForm()
        End If
        dt = Nothing
    End Sub
    Private Sub clearForm()
        txtHeat_number.Text = ""
        txtw3.Text = ""
        lblw1.Text = ""
        lblw2.Text = ""
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If lblGoup.Text = "MLDING" Then
            If Trim(txtw3.Text) = "" Then
                lblMessage.Text = "Please Enter W3.Thank you"
                Exit Sub
            End If
            If IsNumeric(Trim(txtw3.Text)) = False Then
                lblMessage.Text = "Please Enter W3 a Numeric Value.Thank you"
                txtw3.Text = ""
                Exit Sub
            End If
            If CDbl(Trim(txtw3.Text)) < CDbl(Trim(lblw1.Text)) Then
                lblMessage.Text = "Weight W3 can not be lessthan W1. Thank you"
                txtw3.Text = ""
                Exit Sub
            End If
            If CDbl(Trim(txtw3.Text)) > CDbl(Trim(lblw2.Text)) Then
                lblMessage.Text = "Weight W3 can not be Greater than  W2. Thank you"
                txtw3.Text = ""
                Exit Sub
            End If
            Dim wt, wp As Double
            wt = CDbl(lblw2.Text) - CDbl(lblw1.Text)
            wp = CDbl(lblw2.Text) - CDbl(txtw3.Text)
            Dim done As Boolean
            Try
                done = New RWF.MLDING().UpdateLadleWeights(CInt(txtHeat_number.Text), CDbl(Trim(txtw3.Text)), wt, wp)
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            If done Then
                lblMessage.Text = "Weight W3 Updated Sucessfully"
                clearForm()
            End If
            done = Nothing
            wt = Nothing
            wp = Nothing
        Else
            If Val(txtHeat_number.Text) = 0 Then
                lblMessage.Text = "Please Enter Heat Number .Thank you"
                Exit Sub
            End If
            If Trim(txtw1.Text) = "" Then
                lblMessage.Text = "Please Enter W1.Thank you"
                Exit Sub
            End If
            If IsNumeric(Trim(txtw1.Text)) = False Then
                lblMessage.Text = "Please Enter W1 a Numeric Value.Thank you"
                txtw1.Text = ""
                Exit Sub
            End If
            If IsNumeric(Trim(txtw2.Text)) Then
                If CDbl(Trim(txtw2.Text)) < CDbl(Trim(txtw1.Text)) Then
                    lblMessage.Text = "Weight W2 can not be lessthan W1. Thank you"
                    txtw2.Text = ""
                    Exit Sub
                End If
                If CDbl(Trim(txtw2.Text)) = CDbl(Trim(txtw1.Text)) Then
                    lblMessage.Text = "Weight W2 can not be Equal to W1. Thank you"
                    txtw2.Text = ""
                    Exit Sub
                End If
            End If
            Dim done As Boolean
            Try
                done = New RWF.Melting().LadleWeights(CInt(txtHeat_number.Text), CDbl(Val(txtw1.Text)), CDbl(Val(txtw2.Text)))
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            If done Then
                lblMessage.Text = "Weights Recorded"
                clearMeltForm()
            End If
            done = Nothing
        End If
    End Sub
    Private Sub clearMeltForm()
        txtHeat_number.Text = ""
        txtw1.Text = ""
    End Sub
    Private Sub populateMeltData()
        Dim dt As DataTable
        dt = RWF.Melting.LadleWeightsData(CInt(txtHeat_number.Text))
        If dt.Rows.Count > 0 Then
            If IsDBNull(dt.Rows(0)("w1")) = False Then
                txtw1.Text = dt.Rows(0)("w1")
            Else
                txtw1.Text = ""
            End If

            If IsDBNull(dt.Rows(0)("w2")) = False Then
                txtw2.Text = dt.Rows(0)("w2")
            Else
                txtw2.Text = ""
            End If
        Else
            lblMessage.Text = "No data exists for this Heat " & txtHeat_number.Text
            clearMeltForm()
        End If
        dt = Nothing
    End Sub

    Protected Sub txtLadle_number_TextChanged(sender As Object, e As EventArgs) Handles txtLadle_number.TextChanged
        If txtLadle_number.Text.Trim.Length > 0 Then
            Dim dt As DataTable
            dt = RWF.Melting.PreviousLadleDetails(Val(txtHeat_number.Text), txtLadle_number.Text.Trim)
            If dt.Rows.Count > 0 Then
                li.Text = IIf(IsDBNull(dt.Rows(0)(0)), 0, dt.Rows(0)(0))
                Ht.Text = IIf(IsDBNull(dt.Rows(0)(1)), 0, dt.Rows(0)(1))
                'txtw1.Text = LadleWeight.Values.EmptyWt(txtHeat_number.Text)
            End If
            dt.Dispose()
            dt = Nothing
        End If
    End Sub
End Class
