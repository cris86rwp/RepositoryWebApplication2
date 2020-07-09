Public Class calibration_bhn
    Inherits System.Web.UI.Page
    Protected WithEvents txtOperator As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlWheelType As System.Web.UI.WebControls.DropDownList
    Protected WithEvents rblLine As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblShift As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtBhnCert As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBhnMeanObtd As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtResult As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRemark As System.Web.UI.WebControls.TextBox

    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Perc As System.Web.UI.WebControls.Label
    Protected WithEvents txtDueDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblPro As System.Web.UI.WebControls.Label
    Protected WithEvents lblAcc As System.Web.UI.WebControls.Label
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    'new
    Protected WithEvents txtcope As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtelect As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtmech As System.Web.UI.WebControls.TextBox

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
        lblPro.Text = "10"
        If Page.IsPostBack = False Then
            'Session("UserID") = "013904"
            'Session("Group") = "CLRMAG"
            txtOperator.Text = Session("UserID")
            txtDate.Text = Now.Date
            Try
                'Dim oEmp As New rwfGen.Employee()
                'If oEmp.Check(Session("UserID"), Session("Group")) = True Then
                '    txtOperator.Text = Session("UserID")
                'Else
                '    txtOperator.Text = ""
                'End If
                'If txtOperator.Text = "" Then
                '    Response.Redirect("InvalidSession.aspx")
                'End If
                lblMessage.Text = CalibrationTest.Tables.LastRecord
                getWhlType()
                FillGrid()
                'oEmp = Nothing
            Catch exp As Exception
                lblMessage.Text = exp.Message
                Response.Redirect("InvalidSession.aspx")
            End Try
        End If
    End Sub
    Private Sub getWhlType()
        Dim dt As DataTable
        Dim i As Integer = 0
        Try
            dt = CalibrationTest.Tables.getWhlType
            ddlWheelType.DataSource = dt
            ddlWheelType.DataTextField = dt.Columns("WhlType").ColumnName
            ddlWheelType.DataValueField = dt.Columns("WhlType").ColumnName
            ddlWheelType.DataBind()
            For i = 0 To ddlWheelType.Items.Count - 1
                If Trim("BOXN") = ddlWheelType.Items(i).Text Then
                    ddlWheelType.SelectedIndex = i
                End If
            Next
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        dt = Nothing
        i = Nothing
    End Sub

    Private Sub FillGrid()
        DataGrid1.SelectedIndex = -1
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            DataGrid1.DataSource = CalibrationTest.Tables.getBHNData(CDate(txtDate.Text))
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtDueDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDueDate.TextChanged
        lblMessage.Text = ""
        Dim Startdate As Date
        Dim Duedate As Date
        Try
            Duedate = CDate(Trim(txtDueDate.Text))
        Catch
            lblMessage.Text = "Due Date Not in correct format"
            txtDueDate.Text = ""
            Exit Sub
        End Try

        If Trim(txtDate.Text) <> "" Then
            Try
                Startdate = CDate(Trim(txtDate.Text))
                DateCompare(Startdate, Duedate)
            Catch
                lblMessage.Text = "Start Date not in desired format"
                txtDate.Text = ""
                Exit Sub
            End Try
        End If
        Startdate = Nothing
        Duedate = Nothing
    End Sub

    Private Sub DateCompare(ByVal date1 As Date, ByVal date2 As Date)
        If date2 < date1 Then
            lblMessage.Text = "Due date cannot be less than the Calibration Date"  'date1 & "   " & date2  '
            txtDueDate.Text = ""
            Exit Sub
        Else
            lblMessage.Text = ""
            txtResult.Text = "FOUND SATISFACTORY"
        End If
    End Sub

    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        lblMessage.Text = ""
        Dim StartDate, Duedate As Date
        Try
            StartDate = CDate(Trim(txtDate.Text))
        Catch
            lblMessage.Text = "Input Date not in desired format"
            txtDate.Text = ""
            Exit Sub
        End Try
        If StartDate > Date.Today Then
            lblMessage.Text = "Input Date cannot be more than current date" & txtDate.Text
            txtDate.Text = ""
        End If
        If Trim(txtDueDate.Text) <> "" Then
            Try
                Duedate = CDate(Trim(txtDueDate.Text))
                DateCompare(StartDate, Duedate)
            Catch
                lblMessage.Text = "Input Date in DD/MM/YYYY"
                txtDueDate.Text = ""
                Exit Sub
            End Try
        End If
        Try
            FillGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        StartDate = Nothing
        Duedate = Nothing
    End Sub

    Private Function CheckForNumeric(ByVal mystr As String) As Boolean
        Dim floatstr As String = Trim(mystr)
        If IsNumeric(floatstr) Then
            Return True
        Else
            Return False
        End If
        floatstr = Nothing
    End Function

    Private Function NoDecimal(ByVal str As String) As String
        Dim mystr As String = Trim(str)
        Dim i As Integer
        If mystr <> "" Then
            For i = 1 To Len(mystr)
                If Mid(mystr, i, 1) = Trim(".") Then
                    lblMessage.Text = "Please Don't put decimal here"
                    Return ("")
                Else
                    If i = Len(mystr) And Mid(mystr, i, 1) <> Trim(".") Then
                        lblMessage.Text = ""
                        Return mystr
                    End If
                End If
            Next
        End If
        i = Nothing
    End Function

    Private Sub txtBhnCert_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBhnCert.TextChanged
        lblMessage.Text = ""
        If CheckForNumeric(txtBhnCert.Text) = False Then
            lblMessage.Text = "Input for Bhn Certified  must be a numeric type"
            txtBhnCert.Text = ""
        Else
            txtBhnCert.Text = NoDecimal(txtBhnCert.Text)
            If txtBhnCert.Text <> "" Then
                Dim mystr As String = Trim(txtBhnCert.Text)
                Dim i As Integer
                For i = 1 To Len(mystr)
                    If Asc(Mid(mystr.ToUpper, i, 1)) >= 65 And Asc(Mid(mystr.ToUpper, i, 1)) <= 90 Then
                        lblMessage.Text = "Please Enter Valid Number for Bhn Certified"
                        txtBhnCert.Text = ""
                        Exit Sub
                    End If
                Next
                i = Nothing
                mystr = Nothing
            End If
        End If
    End Sub

    Private Sub txtBhnMeanObtd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBhnMeanObtd.TextChanged
        lblMessage.Text = ""
        Select Case Val(txtBhnCert.Text)
            Case 318
                lblAcc.Text = "9"
            Case 302
                lblAcc.Text = "9"
            Case 277
                lblAcc.Text = "8"
            Case 341
                lblAcc.Text = "10"
            Case Else
                lblAcc.Text = "9"
        End Select
        If CheckForNumeric(txtBhnMeanObtd.Text) = False Then
            lblMessage.Text = "Input for Bhn Mean Obtained must be a numeric type"
            txtBhnMeanObtd.Text = ""
        Else
            txtBhnMeanObtd.Text = NoDecimal(txtBhnMeanObtd.Text)
            If Not Val(txtBhnMeanObtd.Text) < Val(txtBhnCert.Text) + Val(lblAcc.Text) AndAlso Val(txtBhnMeanObtd.Text) > Val(txtBhnCert.Text) - Val(lblAcc.Text) Then
                lblMessage.Text = "Bhn Mean Obtained must be a within BHN Certified limits +/- " & lblAcc.Text
                txtBhnMeanObtd.Text = ""
            End If
        End If
    End Sub

    Private Sub txtOperator_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOperator.TextChanged
        lblMessage.Text = ""
        If Len(Trim(txtOperator.Text)) < 6 Or Left(Trim(txtOperator.Text), 1) <> "0" Then
            lblMessage.Text = "Invalid Inspector" & txtOperator.Text
            txtOperator.Text = ""
            Exit Sub
        End If
        If Not IsNumeric(Trim(txtOperator.Text)) Then
            lblMessage.Text = "Only Numeric values for valid Inspector"
            txtOperator.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtOperator.Text = "" Then
            Response.Redirect("http://172.16.25.53/mms/InvalidSession.aspx")
        End If
        Dim paradate, duedate As Date
        Dim bhnmean1, proctol1, accept1 As Double
        Dim done As Boolean
        Try
            If Trim(txtBhnMeanObtd.Text) <> "" Then
                bhnmean1 = CType(Trim(txtBhnMeanObtd.Text), Double)
                done = True
            End If
            If Trim(lblPro.Text) <> "" Then
                proctol1 = CType(Trim(lblPro.Text), Double)
                done = True
            End If
            If Trim(lblAcc.Text) <> "" Then
                accept1 = CType(Trim(lblAcc.Text), Double)
                done = True
            End If
            'paradate = CDate(Trim(txtDate.Text))
            'duedate = CDate(Trim(txtDueDate.Text))
            paradate = Convert.ToDateTime(txtDate.Text)
            duedate = Convert.ToDateTime(txtDueDate.Text)
        Catch exp As Exception
            done = False
            lblMessage.Text = exp.Message
        End Try
        If done Then
            Dim oBHN As New CalibrationTest.BHN()
            'oBHN.CalibrationDate = CDate(txtDate.Text)
            oBHN.CalibrationDate = Convert.ToDateTime(txtDate.Text)
            oBHN.Shift = rblShift.SelectedItem.Text
            oBHN.LineNumber = rblLine.SelectedItem.Text
            oBHN.Inspector = txtOperator.Text
            oBHN.WheelType = ddlWheelType.SelectedItem.Text
            oBHN.BHNObtained = bhnmean1
            oBHN.Tolerance = proctol1
            oBHN.BHNCertified = txtBhnCert.Text.Trim
            oBHN.AccCriteria = accept1
            'oBHN.DueDate = CDate(Trim(txtDueDate.Text))
            oBHN.DueDate = Convert.ToDateTime((txtDueDate.Text))
            oBHN.Results = txtResult.Text
            oBHN.Remarks = txtRemark.Text.Trim
            oBHN.BHNcope = Convert.ToInt64(txtcope.Text)
            oBHN.BHNelect = txtelect.Text
            oBHN.BHNmech = txtmech.Text
            oBHN.SaveBHN()
            lblMessage.Text = oBHN.Message
        End If
        Clear()
        Try
            FillGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        paradate = Nothing
        duedate = Nothing
        bhnmean1 = Nothing
        proctol1 = Nothing
        accept1 = Nothing
        done = Nothing
    End Sub

    Private Sub DataGrid1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.ItemCommand
        lblMessage.Text = ""
        Try
            Select Case e.CommandName
                Case "Select"
                    Dim i As Integer = 0
                    rblShift.ClearSelection()
                    If Not e.Item.Cells(2).Text Is Nothing Then
                        For i = 0 To rblShift.Items.Count - 1
                            If rblShift.Items(i).Value = e.Item.Cells(2).Text Then
                                rblShift.SelectedIndex = i
                                Exit For
                            End If
                        Next
                    End If
                    i = 0
                    rblLine.ClearSelection()
                    If Not e.Item.Cells(3).Text Is Nothing Then
                        For i = 0 To rblLine.Items.Count - 1
                            If rblLine.Items(i).Value = e.Item.Cells(3).Text Then
                                rblLine.SelectedIndex = i
                                Exit For
                            End If
                        Next
                    End If
                    i = 0
                    ddlWheelType.ClearSelection()
                    If Not e.Item.Cells(4).Text Is Nothing Then
                        For i = 0 To ddlWheelType.Items.Count - 1
                            If ddlWheelType.Items(i).Value = e.Item.Cells(4).Text Then
                                ddlWheelType.SelectedIndex = i
                                Exit For
                            End If
                        Next
                    End If
                    txtOperator.Text = e.Item.Cells(5).Text.Replace("&nbsp;", "")
                    txtBhnCert.Text = e.Item.Cells(6).Text.Replace("&nbsp;", "")
                    txtBhnMeanObtd.Text = e.Item.Cells(7).Text.Replace("&nbsp;", "")
                    lblPro.Text = e.Item.Cells(8).Text.Replace("&nbsp;", "").Replace("+/- ", "")
                    lblAcc.Text = e.Item.Cells(9).Text.Replace("&nbsp;", "").Replace("+/- ", "")
                    txtDueDate.Text = e.Item.Cells(10).Text.Replace("&nbsp;", "")
                    txtResult.Text = e.Item.Cells(11).Text.Replace("&nbsp;", "")
                    txtRemark.Text = e.Item.Cells(12).Text.Replace("&nbsp;", "")
                    i = Nothing
            End Select
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub Clear()
        lblPro.Text = ""
        lblAcc.Text = ""
        txtResult.Text = "SATISFACTORY"
        txtRemark.Text = ""
        txtBhnCert.Text = ""
        txtBhnMeanObtd.Text = ""
        txtDueDate.Text = ""
    End Sub
End Class
