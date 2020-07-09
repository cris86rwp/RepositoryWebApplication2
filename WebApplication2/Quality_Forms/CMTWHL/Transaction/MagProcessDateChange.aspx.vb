Public Class MagProcessDateChange
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtNewDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblShift As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblEmpCode As System.Web.UI.WebControls.Label
    Protected WithEvents lblTestDate As System.Web.UI.WebControls.Label
    Protected WithEvents lblMag1Start As System.Web.UI.WebControls.Label
    Protected WithEvents lblMag1End As System.Web.UI.WebControls.Label
    Protected WithEvents lblMag2End As System.Web.UI.WebControls.Label
    Protected WithEvents lblMag2Start As System.Web.UI.WebControls.Label
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel

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
        lblTestDate.Visible = False
        lblEmpCode.Visible = False
        If IsPostBack = False Then
            txtNewDate.Text = Now.Date
            'Session("UserId") = "076355"
            'Session("Group") = "CMTWHL"
            lblEmpCode.Text = Session("UserId")
            Dim oEmp As New rwfGen.Employee()
            'Try
            '    If oEmp.Check(lblEmpCode.Text, Session("Group")) = False Then lblEmpCode.Text = ""
            'Catch exp As Exception
            '    lblMessage.Text = exp.Message
            'End Try

            'If lblEmpCode.Text.Trim = "" Then
            '    Response.Redirect("http://172.16.25.53/mms/InvalidSession.aspx")
            '    Exit Sub
            'End If
            'If lblEmpCode.Text <> "076355" Then
            '    If lblEmpCode.Text <> "076697" Then
            '        Response.Redirect("http://172.16.25.53/mms/InvalidSession.aspx")
            '        Exit Sub
            '    End If
            'End If
            Dim ds As DataSet
            Try
                ds = RWF.Magna.GetLatestDateProcessedWheels
                DataGrid1.DataSource = ds.Tables(0)
                DataGrid1.DataBind()
                lblTestDate.Text = ds.Tables(1).Rows(0)(0)
                GetProcessedValues()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            ds = Nothing
        End If
    End Sub

    Private Sub txtNewDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNewDate.TextChanged
        lblMessage.Text = ""
        If Not RWF.Magna.CheckNewDate(CDate(txtNewDate.Text)) Then
            lblMessage.Text = "InValid New Date : " & CDate(txtNewDate.Text) & " ; Pink Sheet is already Generated !"
            txtNewDate.Text = ""
        Else
            Try
                DataGrid2.DataSource = RWF.Magna.GetProcessedValues(CDate(txtNewDate.Text))
                DataGrid2.DataBind()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub GetProcessedValues()
        Try
            DataGrid2.DataSource = RWF.Magna.GetProcessedValues(CDate(txtNewDate.Text))
            DataGrid2.DataBind()
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        lblMessage.Text = ""
        If txtNewDate.Text.Trim.Length = 0 Then
            lblMessage.Text = "InValid Date ! "
            Exit Sub
        End If
        Dim Done As Boolean
        Try
            Check()
            Done = New RWF.Magna().UpdateMagDate(CDate(lblTestDate.Text), CDate(txtNewDate.Text), rblShift.SelectedItem.Text, lblEmpCode.Text.Trim, Val(lblMag1Start.Text), Val(lblMag2Start.Text), Val(lblMag1End.Text), Val(lblMag2End.Text))
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If Done Then
            lblMessage.Text = "Data Updated !"
            GetProcessedValues()
            DataGrid1.DataSource = Nothing
            DataGrid1.DataBind()
        End If
        Done = Nothing
    End Sub

    Private Sub Check()
        Dim i As Long
        lblMag1Start.Text = ""
        lblMag1End.Text = ""
        lblMag2Start.Text = ""
        lblMag2End.Text = ""
        Dim chkBoxFrom, chkBoxTo As CheckBox
        Dim checkedFrom, checkedTo As Integer
        checkedFrom = 0
        checkedTo = 0
        For i = 0 To DataGrid1.Items.Count - 1
            chkBoxFrom = DataGrid1.Items(i).FindControl("chkFrom")
            chkBoxTo = DataGrid1.Items(i).FindControl("chkTo")
            If chkBoxFrom.Checked Then
                checkedFrom = checkedFrom + 1
                lblMag1Start.Text = DataGrid1.Items(i).Cells(10).Text
                lblMag2Start.text = DataGrid1.Items(i).Cells(11).Text
            End If
            If chkBoxTo.Checked Then
                checkedTo = checkedTo + 1
                lblMag1End.Text = DataGrid1.Items(i).Cells(10).Text
                lblMag2End.Text = DataGrid1.Items(i).Cells(11).Text
            End If
        Next
        If checkedFrom > 1 OrElse checkedTo > 1 Then Throw New Exception("More than one Selection in From Or To Wheel !")
        If Val(lblMag1Start.Text) > Val(lblMag1End.Text) OrElse Val(lblMag2Start.Text) > Val(lblMag2End.Text) Then Throw New Exception("From Wheel and To Wheel selection mis-match ! ")
        chkBoxFrom = Nothing
        chkBoxTo = Nothing
        checkedFrom = Nothing
        checkedTo = Nothing
    End Sub
End Class
