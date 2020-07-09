Public Class BHNSample
    Inherits System.Web.UI.Page
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblLab_Number As System.Web.UI.WebControls.Label
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents grdReadings As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblInsp As System.Web.UI.WebControls.Label
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtHeatFrom As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtHeatTo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWheelNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtHeatNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents lblDescription As System.Web.UI.WebControls.Label
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
            'Session("UserID") = "078844"
            lblInsp.Text = CType(Session("UserID"), String)
            txtDate.Text = Date.Today
            getPreviousHeats()
            lblLab_Number.Text = New metLab.WheelSample().GetLabNumber
            BindGrid()
        End If
    End Sub

    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        lblMessage.Text = ""
        Dim d As Date
        Try
            d = CDate(txtDate.Text)
            If d.Compare(d, Date.Today) > 0 Then Throw New Exception("Date Should Not Be More Than Today")
        Catch exp As Exception
            txtDate.Text = ""
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub BindGrid()
        Try
            grdReadings.DataSource = metLab.WheelSample.LabNumberList
            grdReadings.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub getPreviousHeats()
        Try
            DataGrid1.DataSource = metLab.WheelSample.getPreviousHeats
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtWheelNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWheelNumber.TextChanged
        lblMessage.Text = ""
        lblDescription.Text = ""
        If txtWheelNumber.Text <> "" And txtHeatNumber.Text <> "" And IsNumeric(txtWheelNumber.Text) And IsNumeric(txtHeatNumber.Text) Then
            GetDescription()
        Else
            txtHeatNumber.Text = ""
        End If
    End Sub

    Private Sub GetDescription()
        lblMessage.Text = ""
        Try
            lblDescription.Text = metLab.WheelSample.GetDescription(Val(txtHeatNumber.Text), Val(txtWheelNumber.Text))
            If lblDescription.Text = "" Then
                txtWheelNumber.Text = ""
                txtHeatNumber.Text = ""
            End If
        Catch exp As Exception
            txtWheelNumber.Text = ""
            txtHeatNumber.Text = ""
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtHeatNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHeatNumber.TextChanged
        lblMessage.Text = ""
        lblDescription.Text = ""
        If txtHeatNumber.Text = "" Or Not IsNumeric(txtHeatNumber.Text) Then
            lblMessage.Text = "Enter valid Heat Number "
            txtHeatNumber.Text = ""
            txtWheelNumber.Text = ""
            Exit Sub
        End If
        If Trim(txtHeatNumber.Text) <> "" Then
            If Trim(txtHeatNumber.Text) >= Trim(txtHeatFrom.Text) And Trim(txtHeatNumber.Text) <= Trim(txtHeatTo.Text) Then
            Else
                lblMessage.Text = "Heat Number " & txtHeatNumber.Text & " does not lies in the range " & txtHeatFrom.Text & " and " & txtHeatTo.Text
                txtHeatNumber.Text = ""
                txtWheelNumber.Text = ""
                Exit Sub
            End If
            If metLab.WheelSample.VerifyWheel(Val(txtHeatNumber.Text), Val(txtWheelNumber.Text)) = 0 Then
                If Trim(txtHeatFrom.Text) = Trim(txtHeatTo.Text) Then
                    'Avoided checking to make LabNumber as Experimental Type
                    GetDescription()
                Else
                    lblMessage.Text = "Wheel No. " & txtWheelNumber.Text & " is Invalid or doesn't fall in the given heat range...."
                    txtWheelNumber.Text = ""
                    txtHeatNumber.Text = ""
                    Exit Sub
                End If
            Else
                lblMessage.Text = ""
                If metLab.WheelSample.IsSampleReceived(Val(txtHeatNumber.Text), Val(txtWheelNumber.Text)) Then
                    lblMessage.Text = "Already Sample Received"
                    txtWheelNumber.Text = ""
                    txtHeatNumber.Text = ""
                    Exit Sub
                Else
                    GetDescription()
                End If
            End If
        End If
    End Sub

    Private Sub txtHeatFrom_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHeatFrom.TextChanged
        lblMessage.Text = ""
        txtWheelNumber.Text = ""
        txtHeatNumber.Text = ""
        If metLab.WheelSample.CheckValidHeatNumber(Val(txtHeatFrom.Text)) = 0 Then
            lblMessage.Text = " Heat No. " & Val(txtHeatFrom.Text) & " is Invalid or doesn't exist..."
        Else
            txtHeatFrom.Text = Val(txtHeatFrom.Text)
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        If Val(txtHeatFrom.Text) <= metLab.WheelSample.CheckValidHeatFrom(lblDescription.Text.Trim) Then
            lblMessage.Text = "Heat From : '" & txtHeatFrom.Text & "'  cannot be less than previuos LabNumber Heat Range !"
            txtHeatFrom.Text = ""
            txtHeatTo.Text = ""
            Exit Sub
        End If
        If Val(txtWheelNumber.Text) = 0 Then
            lblMessage.Text = "InValid Wheel Number !"
            txtHeatFrom.Text = ""
            txtHeatTo.Text = ""
            txtWheelNumber.Text = ""
            txtHeatNumber.Text = ""
            Exit Sub
        End If
        If Val(txtHeatNumber.Text) = 0 Then
            lblMessage.Text = "InValid Heat Number !"
            txtHeatFrom.Text = ""
            txtHeatTo.Text = ""
            txtWheelNumber.Text = ""
            txtHeatNumber.Text = ""
            Exit Sub
        End If
        Dim Done As Boolean
        Try
            Done = New metLab.WheelSample().SaveSampleWheel(txtWheelNumber.Text.Trim + "/" + txtHeatNumber.Text.Trim, Val(txtWheelNumber.Text), Val(txtHeatNumber.Text), Val(txtHeatFrom.Text), Val(txtHeatTo.Text), lblLab_Number.Text, lblInsp.Text, lblDescription.Text, CDate(txtDate.Text))
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If Done Then
            lblLab_Number.Text = New metLab.WheelSample().GetLabNumber
            Clear()
            BindGrid()
            getPreviousHeats()
            lblMessage.Text = "Record Inserted !" & lblMessage.Text
        End If
    End Sub

    Private Sub txtHeatTo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHeatTo.TextChanged
        lblMessage.Text = ""
        txtWheelNumber.Text = ""
        txtHeatNumber.Text = ""
    End Sub

    Private Sub Clear()
        txtHeatFrom.Text = ""
        txtHeatTo.Text = ""
        txtHeatNumber.Text = ""
        txtWheelNumber.Text = ""
        lblDescription.Text = ""
    End Sub
End Class
