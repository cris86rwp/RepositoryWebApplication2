Public Class TreadDiaChangeAfterPressing
    Inherits System.Web.UI.Page
    Protected WithEvents txtBatchNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDaySerial As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtEastDia As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWestDia As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblEwhl As System.Web.UI.WebControls.Label
    Protected WithEvents lblEheat As System.Web.UI.WebControls.Label
    Protected WithEvents lblWwhl As System.Web.UI.WebControls.Label
    Protected WithEvents lblWheat As System.Web.UI.WebControls.Label
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents lblELocation As System.Web.UI.WebControls.Label
    Protected WithEvents lblWLocation As System.Web.UI.WebControls.Label
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator3 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator4 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents lblPreEastDia As System.Web.UI.WebControls.Label
    Protected WithEvents lblPreWestDia As System.Web.UI.WebControls.Label
    Protected WithEvents lblRems As System.Web.UI.WebControls.Label
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

        ' Page.Theme = themeValue
        Page.Theme = Session("Theme")
    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None
        'Put user code to initialize the page here
        If Page.IsPostBack = False Then
            Session("UserID") = "078887"
            Session("Group") = "SSINSP"
            Try
                btnSave.Enabled = False
                If Session("Group") <> "SSINSP" Or Session("UserID") = "" Then
                    Response.Redirect("\wap\InvalidSession.aspx")
                    Exit Sub
                End If
                SetFocus(txtBatchNumber)
            Catch exp As Exception
                Response.Redirect("\wap\InvalidSession.aspx")
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub SetFocus(ByVal ctrl As Control)
        Dim focusScript As String = "<script language=" & "javascript" & " > " & _
        "document.getElementById('" + ctrl.ClientID.ToString.Trim & _
        "').focus();</script>"
        Page.RegisterStartupScript("FocusScript", focusScript)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        btnSave.Enabled = False
        Dim blnDone As Boolean
        Try
            blnDone = SSINSP.IsValidDia(Val(lblEwhl.Text), Val(lblEheat.Text), Val(txtEastDia.Text))
            If blnDone Then
                blnDone = False
                blnDone = SSINSP.IsValidDia(Val(lblWwhl.Text), Val(lblWheat.Text), Val(txtWestDia.Text))
                If blnDone Then
                    blnDone = False
                Else
                    lblMessage.Text = "West Wheel Tread Dia Mis-Match !"
                    Exit Sub
                End If
            Else
                lblMessage.Text = "East Wheel Tread Dia Mis-Match !"
                Exit Sub
            End If
            blnDone = New SSINSP().UpdateTreafDiaAfterPress(txtBatchNumber.Text.ToUpper, Val(txtDaySerial.Text), Session("UserID"), lblELocation.Text.Trim, lblWLocation.Text.Trim, Val(lblEwhl.Text), Val(lblEheat.Text), Val(txtEastDia.Text), CDec(lblPreEastDia.Text), Val(lblWwhl.Text), Val(lblWheat.Text), CDec(txtWestDia.Text), CDec(lblPreWestDia.Text))
        Catch exp As Exception
            lblMessage.Text = exp.Message
            blnDone = True
        Finally
            If blnDone = False Then
                lblMessage.Text &= " : Not Updated"
            Else
                lblMessage.Text = "Updated (" & lblELocation.Text.Trim & " Wheel )"
                lblMessage.Text &= " (" & lblWLocation.Text.Trim & " Wheel )"
            End If
        End Try
        blnDone = Nothing
    End Sub

    Private Sub Clear()
        lblPreEastDia.Text = ""
        lblPreWestDia.Text = ""
        lblRems.Text = ""
        lblELocation.Text = ""
        lblWLocation.Text = ""
        txtEastDia.Text = ""
        txtWestDia.Text = ""
        lblEwhl.Text = ""
        lblEheat.Text = ""
        lblWwhl.Text = ""
        lblWheat.Text = ""
    End Sub

    Private Sub getBatchDetails()
        Clear()
        btnSave.Enabled = True
        Dim dt As DataTable
        Try
            dt = SSINSP.PressSetDetails(txtBatchNumber.Text, Val(txtDaySerial.Text))
            If dt.Rows.Count > 0 Then
                txtBatchNumber.Text = txtBatchNumber.Text.ToUpper
                txtEastDia.Text = IIf(IsDBNull(CDec(dt.Rows(0)("ETreDia"))), 0.0, CDec(dt.Rows(0)("ETreDia")))
                txtWestDia.Text = IIf(IsDBNull(CDec(dt.Rows(0)("WTreDia"))), 0.0, CDec(dt.Rows(0)("WTreDia")))
                lblPreEastDia.Text = txtEastDia.Text
                lblPreWestDia.Text = txtWestDia.Text
                lblEheat.Text = IIf(IsDBNull(CDec(dt.Rows(0)("EHt"))), 0.0, CDec(dt.Rows(0)("EHt")))
                lblEwhl.Text = IIf(IsDBNull(CDec(dt.Rows(0)("EWhl"))), 0.0, CDec(dt.Rows(0)("EWhl")))
                lblWheat.Text = IIf(IsDBNull(CDec(dt.Rows(0)("WHt"))), 0.0, CDec(dt.Rows(0)("WHt")))
                lblWwhl.Text = IIf(IsDBNull(CDec(dt.Rows(0)("WWhl"))), 0.0, CDec(dt.Rows(0)("WWhl")))
                lblRems.Text = IIf(IsDBNull(dt.Rows(0)("Rem")), "", dt.Rows(0)("Rem"))
                lblELocation.Text = IIf(IsDBNull(dt.Rows(0)("ELoc")), "", dt.Rows(0)("ELoc"))
                lblWLocation.Text = IIf(IsDBNull(dt.Rows(0)("WLoc")), "", dt.Rows(0)("WLoc"))
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
            btnSave.Enabled = False
        Finally
            dt.Dispose()
            dt = Nothing
        End Try
    End Sub

    Private Sub txtBatchNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBatchNumber.TextChanged
        lblMessage.Text = ""
        If Val(txtBatchNumber.Text) > 0 Then
            lblMessage.Text = "InValid Batch Number !"
            txtBatchNumber.Text = ""
            Clear()
            SetFocus(txtBatchNumber)
        Else
            If Val(txtDaySerial.Text) > 0 Then
                getBatchDetails()
            End If
            SetFocus(txtDaySerial)
            txtBatchNumber.Text = txtBatchNumber.Text.ToUpper
        End If
    End Sub

    Private Sub txtDaySerial_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDaySerial.TextChanged
        lblMessage.Text = ""
        If Val(txtDaySerial.Text) = 0 Then
            lblMessage.Text = "InValid Day Serial Number !"
            txtDaySerial.Text = ""
            Clear()
            SetFocus(txtDaySerial)
        Else
            If Val(txtBatchNumber.Text) = 0 Then
                getBatchDetails()
                SetFocus(txtEastDia)
            End If
        End If
    End Sub
End Class
