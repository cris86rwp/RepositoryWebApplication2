Public Class BHNSampleSendEdit
    Inherits System.Web.UI.Page
    Protected WithEvents txtLabNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblWh As System.Web.UI.WebControls.Label
    Protected WithEvents lblHt As System.Web.UI.WebControls.Label
    Protected WithEvents txtWh As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtHt As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnUpdate As System.Web.UI.WebControls.Button
    Protected WithEvents lblFrHt As System.Web.UI.WebControls.Label
    Protected WithEvents lblToHt As System.Web.UI.WebControls.Label
    Protected WithEvents lblDes As System.Web.UI.WebControls.Label
    Protected WithEvents lblChangeDesc As System.Web.UI.WebControls.Label
    Protected WithEvents lblTestType As System.Web.UI.WebControls.Label
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
        If Not IsPostBack Then
            lblFrHt.Visible = False
            lblToHt.Visible = False
        End If
    End Sub

    Private Sub Clear()
        lblWh.Text = ""
        lblHt.Text = ""
        lblFrHt.Text = ""
        lblToHt.Text = ""
        lblDes.Text = ""
        lblTestType.Text = ""
    End Sub

    Private Sub txtLabNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLabNumber.TextChanged
        Clear()
        lblMessage.Text = ""
        Dim dt As New DataTable()
        Try
            dt = metLab.tables.GetLabDetails(txtLabNumber.Text.Trim)
            If dt.Rows.Count > 0 Then
                lblTestType.Text = dt.Rows(0)("test_type")
                If lblTestType.Text.Trim = "Regular" Then
                    lblWh.Text = dt.Rows(0)("wheel_number")
                    lblHt.Text = dt.Rows(0)("heat_number")
                    lblFrHt.Text = dt.Rows(0)("heat_from")
                    lblToHt.Text = dt.Rows(0)("heat_to")
                    lblDes.Text = dt.Rows(0)("wheel_type")
                ElseIf lblTestType.Text.Trim = "Experimental" Then
                    lblWh.Text = dt.Rows(0)("wheel_number")
                    lblHt.Text = dt.Rows(0)("heat_number")
                    lblFrHt.Text = dt.Rows(0)("heat_from")
                    lblToHt.Text = dt.Rows(0)("heat_to")
                    lblDes.Text = dt.Rows(0)("wheel_type")
                End If
            Else
                lblMessage.Text = "InValid Lab Number '" & txtLabNumber.Text & "' !"
                txtLabNumber.Text = ""
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Function Check(ByVal Wh As Long, ByVal Ht As Long) As String
        Try
            lblChangeDesc.Text = metLab.tables.CheckDesc(Val(txtWh.Text), Val(txtHt.Text), lblDes.Text.Trim, lblTestType.Text.Trim)
            Check = lblChangeDesc.Text
        Catch exp As Exception
            lblMessage.Text = exp.Message
            Check = ""
        End Try
    End Function

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        lblMessage.Text = ""
        If lblTestType.Text.Trim = "Regular" Then
            Dim Lab As New metLab.RegularTest(txtLabNumber.Text)
            Lab.LabNumber = txtLabNumber.Text
            Lab.WheelNumber = txtWh.Text
            Lab.HeatNumber = txtHt.Text
            Lab.wheel = CStr(txtWh.Text.Trim + "/" + txtHt.Text.Trim)
            If Lab.UpdateSample(lblTestType.Text.Trim) Then
                lblMessage.Text = "Records Updated"
                txtWh.Text = ""
                txtHt.Text = ""
                lblChangeDesc.Text = ""
                txtLabNumber.Text = ""
                Clear()
            Else
                lblMessage.Text = "Updation of records failed !"
            End If
        Else
            Dim Lab As New metLab.ExperimentalTest(txtLabNumber.Text)
            Lab.LabNumber = txtLabNumber.Text
            Lab.WheelNumber = txtWh.Text
            Lab.HeatNumber = txtHt.Text
            Lab.HeatFrom = txtHt.Text
            Lab.HeatTo = txtHt.Text
            Lab.wheel = CStr(txtWh.Text.Trim + "/" + txtHt.Text.Trim)
            If Lab.UpdateSample(lblTestType.Text.Trim) Then
                lblMessage.Text = "Records Updated"
                txtWh.Text = ""
                txtHt.Text = ""
                lblChangeDesc.Text = ""
                txtLabNumber.Text = ""
                Clear()
            Else
                lblMessage.Text = "Updation of records failed !"
            End If
        End If
    End Sub

    Private Sub txtWh_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWh.TextChanged
        lblMessage.Text = ""
        Try
            If Val(txtWh.Text.Trim) > 0 Then
                If Val(txtHt.Text.Trim) > 0 Then
                    lblChangeDesc.Text = Check(Val(txtWh.Text.Trim), Val(txtHt.Text.Trim))
                End If
            Else
                lblMessage.Text = "InValid Wheel Number !"
                txtWh.Text = ""
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtHt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHt.TextChanged
        lblMessage.Text = ""
        Try
            If Val(txtHt.Text.Trim) > 0 Then
                If Val(txtWh.Text.Trim) > 0 Then
                    lblChangeDesc.Text = Check(Val(txtWh.Text.Trim), Val(txtHt.Text.Trim))
                End If
            Else
                lblMessage.Text = "InValid Heat Number !"
                txtHt.Text = ""
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
End Class
