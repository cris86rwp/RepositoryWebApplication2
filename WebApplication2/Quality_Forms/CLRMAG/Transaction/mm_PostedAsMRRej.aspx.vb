Public Class mm_PostedAsMRRej
    Inherits System.Web.UI.Page
    Protected WithEvents lblEmpCode As System.Web.UI.WebControls.Label
    Protected WithEvents btnChange As System.Web.UI.WebControls.Button
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtChange As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtHeat As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWhl As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
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
    Protected Sub Dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub


    Private Sub Page_PreInit(ByVal sender As Object, ByVal e As EventArgs)

        ' Page.Theme = themeValue
        Page.Theme = Session("Theme")
    End Sub


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If IsPostBack = False Then
            Session("UserId") = "111111"
            Session("Group") = "CLRMAG"
            lblEmpCode.Text = Session("UserId")
            'Dim oEmp As New rwfGen.Employee()
            'If oEmp.Check(lblEmpCode.Text, Session("Group")) = False Then
            '    lblEmpCode.Text = ""
            'End If
            'If lblEmpCode.Text.Trim = "" Then
            '    'Response.Redirect("http://mmsserver/mms/InvalidSession.aspx")
            '    Exit Sub
            'End If
        End If
    End Sub

    Private Sub txtHeat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHeat.TextChanged
        lblMessage.Text = ""
        If Val(txtWhl.Text) <= 0 Then
            SetFocus(txtWhl)
            lblMessage.Text = "Please provide wheel number"
        Else
            If Val(txtHeat.Text) > 0 Then
                CheckWheel()
            Else
                SetFocus(txtHeat)
                lblMessage.Text = "Please provide heat number"
            End If
        End If
    End Sub

    Private Sub txtWhl_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWhl.TextChanged
        lblMessage.Text = ""
        If Val(txtHeat.Text) <= 0 Then
            lblMessage.Text = "Please provide heat number"
            SetFocus(txtHeat)
        Else
            If Val(txtWhl.Text) > 0 Then
                CheckWheel()
            Else
                SetFocus(txtWhl)
                lblMessage.Text = "Please provide wheel number"
            End If
        End If
    End Sub

    Private Sub SetFocus(ByVal ctrl As Control)
        Dim focusScript As String = "<script language=" & "javascript" & " > " & _
        "document.getElementById('" + ctrl.ClientID.ToString.Trim & _
        "').focus();</script>"
        Page.RegisterStartupScript("FocusScript", focusScript)
    End Sub

    Private Sub CheckWheel()
        txtChange.Text = ""
        Dim dt As DataTable
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            dt = RWF.MLDING.GetMRWhlData(Val(txtWhl.Text), Val(txtHeat.Text))
            If dt.Rows.Count > 0 Then
                txtChange.Text = Trim(dt.Rows(0)("MRSts"))
                DataGrid1.DataSource = dt
                DataGrid1.DataBind()
                SetFocus(txtChange)
            Else
                lblMessage.Text = "InValid Wheel !"
                txtWhl.Text = ""
                txtHeat.Text = ""
                txtChange.Text = ""
            End If
            dt = Nothing
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChange.Click
        lblMessage.Text = ""
        If txtChange.Text.Trim.Length = 0 Then
            lblMessage.Text = " XC status cannot be empty!"
            Exit Sub
        End If
        If Not txtChange.Text.Trim.ToUpper.StartsWith("X") Then
            lblMessage.Text = " In-correct XC status !"
            Exit Sub
        End If
        If txtChange.Text.Trim.ToUpper.Substring(1, 1).Trim.Length = 0 Then
            lblMessage.Text = " InValid XC status !"
            Exit Sub
        End If
        If txtChange.Text.Trim.ToUpper.Substring(1, 1).Trim = "C" Then
            lblMessage.Text = " InValid XC Code !"
            Exit Sub
        End If
        Dim done As Boolean
        Try
            done = New RWF.MLDING().PostAsMRXC(Val(txtWhl.Text), Val(txtHeat.Text), txtChange.Text.Trim.ToUpper)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If done Then
            lblMessage.Text &= "Updated !"
            DataGrid1.DataSource = Nothing
            DataGrid1.DataBind()
            txtWhl.Text = ""
            txtHeat.Text = ""
            txtChange.Text = ""
        Else
            lblMessage.Text &= " Updation Failed !"
        End If
        done = Nothing
    End Sub

    Private Sub txtChange_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtChange.TextChanged
        lblMessage.Text = ""
        txtChange.Text = txtChange.Text.ToUpper
        If txtChange.Text.Trim.StartsWith("XC") Then
            lblMessage.Text = "InValid XC Code !"
            txtChange.Text = ""
        End If
        SetFocus(btnChange)
    End Sub
End Class
