Public Class QCIResults
    Inherits System.Web.UI.Page
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblShift As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtLab As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtTechnical As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator3 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtInspector As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWheel As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfvWheel_number As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtHeat As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfvHeat_number As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtWheel_disposition As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblwheeltype As System.Web.UI.WebControls.Label
    Protected WithEvents lblstatus As System.Web.UI.WebControls.Label
    Protected WithEvents lblloca As System.Web.UI.WebControls.Label
    Protected WithEvents Panel2 As System.Web.UI.WebControls.Panel
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnClear As System.Web.UI.WebControls.Button
    Protected WithEvents lblSlNo As System.Web.UI.WebControls.Label
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
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


    Protected Sub dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None
        'Put user code to initialize the page here
        lblSlNo.Visible = False
        If Page.IsPostBack = False Then
            'Session("UserID") = "076697"
            txtLab.Text = Session("UserID")
            txtDate.Text = Now.Date
            Dim Shift As String
            Select Case Now.Hour
                Case 6 To 13
                    Shift = "A"
                Case 14 To 21
                    Shift = "B"
                Case 0 To 5
                    Shift = "C"
                    txtDate.Text = Now.Date.AddDays(-1)
                Case Else
                    Shift = "C"
            End Select
            rblShift.ClearSelection()
            Dim i As Integer = 0
            For i = 0 To rblShift.Items.Count - 1
                If Shift.Trim = rblShift.Items(i).Text Then
                    rblShift.Items(i).Selected = True
                    Exit For
                End If
            Next
            Try
                FillGrid(CDate(txtDate.Text))
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            i = Nothing
            Shift = Nothing
        End If
    End Sub

    Private Sub txtWheel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWheel.TextChanged
        lblMessage.Text = ""
        lblSlNo.Text = ""
        If CInt(Trim(txtWheel.Text)) >= 10000 Then
            txtHeat.Text = "0"
        End If
        If txtHeat.Text = "" Then
            lblMessage.Text = "please enter heat number"
            Exit Sub
        Else
            Try
                checkwheel()
            Catch exp As Exception
                lblMessage.Text &= exp.Message
            End Try
            SetFocus(txtHeat)
        End If
    End Sub

    Private Sub txtHeat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHeat.TextChanged
        lblMessage.Text = ""
        lblSlNo.Text = ""
        If CInt(Trim(txtWheel.Text)) >= 10000 Then
            txtHeat.Text = "0"
        End If
        If txtWheel.Text = "" Then
            lblMessage.Text = "please enter Wheel number"
            Exit Sub
        Else
            Try
                checkwheel()
            Catch exp As Exception
                lblMessage.Text &= exp.Message
            End Try
            SetFocus(txtWheel_disposition)
        End If
    End Sub

    Private Sub checkwheel()
        Dim sqlstr As String
        Dim temp As String
        Dim dt As DataTable
        If RWF.WHLQCI.CheckQCIInsp(CDate(txtDate.Text), CInt(Trim(txtWheel.Text)), CInt(Trim(txtHeat.Text))) Then
            lblMessage.Text = "Wheel Already Exists as QCI Wheel !"
            txtWheel.Text = ""
            txtHeat.Text = ""
            Exit Sub
        End If
        dt = RWF.WHLQCI.GetQCIWheelsDetails(CInt(Trim(txtWheel.Text)), CInt(Trim(txtHeat.Text)))
        If dt.Rows.Count = 0 Then
            lblMessage.Text = "Wheel Not found in Master"
            txtWheel.Text = ""
            txtHeat.Text = ""
        Else
            lblwheeltype.Text = IIf(IsDBNull(dt.Rows(0)("description")), "", Trim(dt.Rows(0)("description")))
            temp = Trim(dt.Rows(0)("status"))
            If Trim(dt.Rows(0)("location")) = "CLMT" Then
                If temp = "REJECTED" Or Left(temp.ToUpper, 3) = "REJ" Or Left(temp.ToUpper, 2) = "XC" Then
                    lblMessage.Text = "This is rejected wheel having status " & dt.Rows(0)("status") & " Location:" & dt.Rows(0)("location")
                    btnSave.Enabled = True
                    lblstatus.Text = dt.Rows(0)("status")
                    lblloca.Text = dt.Rows(0)("location")
                    If Left(lblstatus.Text, 3).ToUpper = "XC8" Then
                        lblMessage.Text = "This wheel is not a Rejected having the status " & dt.Rows(0)("status") & " Location:" & dt.Rows(0)("location")
                        txtWheel.Text = ""
                        txtHeat.Text = ""
                        Exit Sub
                    End If
                Else
                    lblMessage.Text = "This wheel is not a Rejected having the status " & dt.Rows(0)("status") & " Location:" & dt.Rows(0)("location")
                    txtWheel.Text = ""
                    txtHeat.Text = ""
                    Exit Sub
                End If
            End If
            If Trim(dt.Rows(0)("location")) = "CLFI" Then
                If Left(Trim(dt.Rows(0)("status")).ToUpper, 3) = "REJ" Or Left(Trim(dt.Rows(0)("status")).ToUpper, 1) = "R" And Left(Trim(dt.Rows(0)("status")).ToUpper, 3) <> "REW" Then
                    lblMessage.Text = "This wheel is having the status " & dt.Rows(0)("status") & " Location:" & dt.Rows(0)("location")
                    lblstatus.Text = dt.Rows(0)("status")
                    lblloca.Text = dt.Rows(0)("location")
                Else
                    lblMessage.Text = "This wheel is having the last status:" & dt.Rows(0)("status") & " Location:" & dt.Rows(0)("location")
                    txtWheel.Text = ""
                    txtHeat.Text = ""
                End If
            End If
            If Trim(dt.Rows(0)("location")) = "CLQC" Then
                If (Left(Trim(dt.Rows(0)("status")).ToUpper, 1)) = "X" Or (Left(Trim(dt.Rows(0)("status")).ToUpper, 2)) = "RL" Then
                    lblMessage.Text = "This wheel is in Location:" & dt.Rows(0)("location") & " having the status " & dt.Rows(0)("status") & " Location:" & dt.Rows(0)("location")
                    lblstatus.Text = dt.Rows(0)("status")
                    lblloca.Text = dt.Rows(0)("location")
                Else
                    lblMessage.Text = "This wheel is having the last status:" & dt.Rows(0)("status") & " Location:" & dt.Rows(0)("location")
                    txtWheel.Text = ""
                    txtHeat.Text = ""
                End If
            End If
            If Trim(dt.Rows(0)("location")) = "CLFQ" Then
                If (Left(Trim(dt.Rows(0)("status")).ToUpper, 1)) = "X" Or (Left(Trim(dt.Rows(0)("status")).ToUpper, 1)) = "W" Or (Left(Trim(dt.Rows(0)("status")).ToUpper, 2)) = "RM" Then
                    lblMessage.Text = "This wheel is having the last status:" & dt.Rows(0)("status") & " Location:" & dt.Rows(0)("location")
                    txtWheel.Text = ""
                    txtHeat.Text = ""
                End If
            End If
            If Trim(dt.Rows(0)("location")) <> "CLQC" And Trim(dt.Rows(0)("location")) <> "CLMT" And Trim(dt.Rows(0)("location")) <> "CLFI" Then
                lblMessage.Text = "This wheel is having the status " & dt.Rows(0)("status") & " Location:" & dt.Rows(0)("location")
                txtWheel.Text = ""
                txtHeat.Text = ""
            End If
        End If
        sqlstr = Nothing
        temp = Nothing
        dt = Nothing
    End Sub

    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        lblMessage.Text = ""
        Try
            Clear()
            FillGrid(CDate(Trim(txtDate.Text)))
        Catch
            lblMessage.Text = "Enter valid date in DATE FORMAT DD/MM/YYYY"
            txtDate.Text = ""
            Exit Sub
        End Try
        lblMessage.Text = ""
        If CDate(Trim(txtDate.Text)) > Now Then
            lblMessage.Text = "Date Can Not Be Greater Than Today's Date"
            txtDate.Text = ""
            Exit Sub
        End If
        If RWF.WHLQCI.CheckInspDate(CDate(Trim(txtDate.Text))) >= 1 Then
            lblMessage.Text = "You Can Not Add or Edit the Data for the date for which Pink Sheet Already Generated"
            txtDate.Text = ""
        End If
    End Sub

    Private Sub FillGrid(ByVal InspDate As Date)
        Clear()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        Dim ds As DataSet
        Try
            ds = RWF.WHLQCI.GetSavedQCIWheels(InspDate)
            DataGrid2.DataSource = ds.Tables(0)
            DataGrid2.DataBind()
            DataGrid1.DataSource = ds.Tables(1)
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            ds = Nothing
        End Try
    End Sub

    Private Sub SetFocus(ByVal ctrl As Control)
        Dim focusScript As String = "<script language=" & "javascript" & " > " & _
        "document.getElementById('" + ctrl.ClientID.ToString.Trim & _
        "').focus();</script>"
        Page.RegisterStartupScript("FocusScript", focusScript)
    End Sub

    Private Sub Clear()
        txtWheel_disposition.Text = ""
        txtWheel.Text = ""
        txtHeat.Text = ""
        lblstatus.Text = ""
        lblloca.Text = ""
        lblwheeltype.Text = ""
        txtRemarks.Text = ""
        lblSlNo.Text = ""
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim Done As Boolean
        If txtWheel.Text = "" AndAlso txtHeat.Text = "" AndAlso txtDate.Text.Trim.Length = 0 AndAlso txtWheel_disposition.Text.Trim.Length = 0 Then
            lblMessage.Text = "InValid Data !"
        Else
            If RWF.WHLQCI.CheckQCIInsp(CDate(txtDate.Text), CInt(Trim(txtWheel.Text)), CInt(Trim(txtHeat.Text))) Then
                lblMessage.Text = "Wheel Already Exists as QCI Wheel !"
                txtWheel.Text = ""
                txtHeat.Text = ""
                Exit Sub
            End If
            Done = New RWF.WHLQCI().QCIWheelAdd(CDate(txtDate.Text), rblShift.SelectedItem.Text, txtLab.Text.Trim, txtTechnical.Text.Trim, txtInspector.Text.Trim, Val(txtWheel.Text), Val(txtHeat.Text), lblstatus.Text.Trim, lblloca.Text.Trim, lblwheeltype.Text.Trim, txtWheel_disposition.Text.Trim, txtRemarks.Text.Trim, Val(lblSlNo.Text))
        End If
        If Done Then
            If Val(lblSlNo.Text) = 0 Then
                lblMessage.Text = "Data Inserted Successfully !"
            Else
                lblMessage.Text = "Data UpDated Successfully !"
            End If
            Try
                FillGrid(CDate(txtDate.Text))
            Catch exp As Exception
                lblMessage.Text &= exp.Message
            End Try
        Else
            lblMessage.Text = "Data Insertion Failed !"
        End If
        SetFocus(txtWheel)
        Done = Nothing
    End Sub

    Private Sub txtWheel_disposition_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWheel_disposition.TextChanged
        If Left(Trim(txtWheel_disposition.Text).ToUpper, 1) = "W" Then
            If Trim(txtWheel_disposition.Text.Length) = 1 Then
                lblMessage.Text = "Valid code is not present after:" & Trim(txtWheel_disposition.Text)
                txtWheel_disposition.Text = ""
            Else
                SetFocus(txtHeat)
            End If
        Else
            lblMessage.Text = "This is Not a Valid code ; Wheels for ReClaim Only !"
            txtWheel_disposition.Text = ""
        End If
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        SetFocus(txtWheel)
        Clear()
    End Sub

    Private Sub DataGrid2_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid2.ItemCommand
        lblMessage.Text = ""
        lblSlNo.Text = ""
        DataGrid2.SelectedIndex = -1
        If txtDate.Text = "" Then
            lblMessage.Text = "InValid Date !"
            Exit Sub
        End If
        Select Case e.CommandName
            Case "Select"
                lblSlNo.Text = e.Item.Cells(2).Text
                txtLab.Text = e.Item.Cells(5).Text
                txtTechnical.Text = e.Item.Cells(6).Text
                txtInspector.Text = e.Item.Cells(7).Text
                txtWheel.Text = e.Item.Cells(8).Text
                txtHeat.Text = e.Item.Cells(9).Text
                lblloca.Text = e.Item.Cells(10).Text
                lblstatus.Text = e.Item.Cells(11).Text
                txtWheel_disposition.Text = e.Item.Cells(12).Text
                txtRemarks.Text = e.Item.Cells(13).Text.Replace("&nbsp;", "")
        End Select
    End Sub
End Class
