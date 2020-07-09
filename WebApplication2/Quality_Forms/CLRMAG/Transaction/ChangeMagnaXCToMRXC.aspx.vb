Public Class ChangeMagnaXCToMRXC
    Inherits System.Web.UI.Page
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents txtHeat As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWhl As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnChange As System.Web.UI.WebControls.Button
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtChange As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblPresent As System.Web.UI.WebControls.Label
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblEmpCode As System.Web.UI.WebControls.Label
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label

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
        'Put user code to initialize the page here
        lblEmpCode.Visible = False
        If IsPostBack = False Then
            'Session("UserId") = "076355"
            'Session("Group") = "CLRMAG"
            lblEmpCode.Text = Session("UserId")
            Dim oEmp As New rwfGen.Employee()
            'If oEmp.Check(lblEmpCode.Text, Session("Group")) = False Then
            '    lblEmpCode.Text = ""
            'End If
            'If lblEmpCode.Text.Trim = "" Then
            '    Response.Redirect("http://mmsserver/mms/InvalidSession.aspx")
            '    Exit Sub
            'End If
            'If lblEmpCode.Text <> "076355" AndAlso lblEmpCode.Text <> "077059" AndAlso lblEmpCode.Text <> "076769" AndAlso lblEmpCode.Text <> "081120" AndAlso lblEmpCode.Text <> "078828" AndAlso lblEmpCode.Text <> "081947" Then
            '    'If lblEmpCode.Text <> "076697" Then
            '    Response.Redirect("http://mmsserver/mms/InvalidSession.aspx")
            '    Exit Sub
            '    'End If
            'End If
            SetFocus(txtWhl)
            oEmp = Nothing
            GetNotPostedWheels()
        End If
    End Sub

    Private Sub SetFocus(ByVal ctrl As Control)
        Dim focusScript As String = "<script language=" & "javascript" & " > " & _
        "document.getElementById('" + ctrl.ClientID.ToString.Trim & _
        "').focus();</script>"
        Page.RegisterStartupScript("FocusScript", focusScript)
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

    Private Sub GetNotPostedWheels()
        Try
            DataGrid2.DataSource = RWF.MLDING.GetNotPostedWheels
            DataGrid2.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub CheckWheel()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        lblPresent.Text = ""
        txtChange.Text = ""
        Dim dt As DataTable
        Try
            dt = RWF.MLDING.GetWhlData(Val(txtWhl.Text), Val(txtHeat.Text))
            If dt.Rows.Count > 0 Then
                If Left(Trim(dt.Rows(0)("WhlSts")), 2) <> "XC" Then
                    lblMessage.Text = "Wheel not rejected in Magna !"
                Else
                    lblPresent.Text = Trim(dt.Rows(0)("WhlSts"))
                    txtChange.Text = Trim(dt.Rows(0)("WhlSts"))
                    DataGrid1.DataSource = dt
                    DataGrid1.DataBind()
                    SetFocus(txtChange)
                End If
            Else
                lblMessage.Text = "InValid Wheel !"
                txtWhl.Text = ""
                txtHeat.Text = ""
                txtChange.Text = ""
                lblPresent.Text = ""
            End If
            dt = Nothing
        Catch exp As Exception
            lblMessage.Text = ""
        End Try
    End Sub

    Private Sub txtChange_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtChange.TextChanged
        lblMessage.Text = ""
        txtChange.Text = txtChange.Text.ToUpper
        SetFocus(txtRemarks)
    End Sub

    Private Sub btnChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChange.Click
        lblMessage.Text = ""
        If txtChange.Text.Trim.Length = 0 Then
            lblMessage.Text = " Please provide 'ChangeTo' XC status !"
            Exit Sub
        End If
        If Not txtChange.Text.Trim.ToUpper.StartsWith("X") Then
            lblMessage.Text = " InCorrect XC status !"
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
            done = New RWF.MLDING().ChangeMagnaXCToMRXC(Val(txtWhl.Text), Val(txtHeat.Text), txtChange.Text.Trim, txtRemarks.Text.Trim)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If done Then
            GetNotPostedWheels()
            lblMessage.Text &= "Updated !"
        Else
            lblMessage.Text &= " Updation Failed !"
        End If
        done = Nothing
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        txtWhl.Text = ""
        txtHeat.Text = ""
        txtChange.Text = ""
        lblPresent.Text = ""
    End Sub
End Class
