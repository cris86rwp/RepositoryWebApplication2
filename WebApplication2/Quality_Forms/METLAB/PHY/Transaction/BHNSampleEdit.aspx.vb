Public Class BHNSampleEdit
    Inherits System.Web.UI.Page
    Protected WithEvents btnUpdate As System.Web.UI.WebControls.Button
    Protected WithEvents lblTestType As System.Web.UI.WebControls.Label
    Protected WithEvents lblDes As System.Web.UI.WebControls.Label
    Protected WithEvents lblHt As System.Web.UI.WebControls.Label
    Protected WithEvents lblWh As System.Web.UI.WebControls.Label
    Protected WithEvents txtLabNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtToHt As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFrHt As System.Web.UI.WebControls.TextBox
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
        End If
    End Sub

    Private Sub Clear()
        lblWh.Text = ""
        lblHt.Text = ""
        txtFrHt.Text = ""
        txtToHt.Text = ""
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
                    txtFrHt.Text = dt.Rows(0)("heat_from")
                    txtToHt.Text = dt.Rows(0)("heat_to")
                    lblDes.Text = dt.Rows(0)("wheel_type")
                ElseIf lblTestType.Text.Trim = "Experimental" Then
                    lblWh.Text = dt.Rows(0)("wheel_number")
                    lblHt.Text = dt.Rows(0)("heat_number")
                    txtFrHt.Text = dt.Rows(0)("heat_from")
                    txtToHt.Text = dt.Rows(0)("heat_to")
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

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        lblMessage.Text = ""
        If lblTestType.Text.Trim = "Regular" Then
            Dim Lab As New metLab.RegularTest(txtLabNumber.Text)
            Lab.LabNumber = txtLabNumber.Text
            Lab.HeatFrom = txtFrHt.Text
            Lab.HeatTo = txtToHt.Text
            If Lab.UpdateSampleFrToHeat() Then
                lblMessage.Text = "Records Updated"
                txtLabNumber.Text = ""
                Clear()
            Else
                lblMessage.Text = "Updation of records failed !"
            End If
        Else
            Dim Lab As New metLab.ExperimentalTest(txtLabNumber.Text)
            Lab.LabNumber = txtLabNumber.Text
            Lab.HeatFrom = txtFrHt.Text
            Lab.HeatTo = txtToHt.Text
            If Lab.UpdateSampleFrToHeat Then
                lblMessage.Text = "Records Updated"
                txtLabNumber.Text = ""
                Clear()
            Else
                lblMessage.Text = "Updation of records failed !"
            End If
        End If
    End Sub
End Class
