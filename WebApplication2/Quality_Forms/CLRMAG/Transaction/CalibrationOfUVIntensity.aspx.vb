Public Class CalibrationOfUVIntensity
    Inherits System.Web.UI.Page
    Protected WithEvents rblLine As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents rblShift As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents txtRemark As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDueDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    ' Protected WithEvents txtCope As System.Web.UI.WebControls.TextBox
    ' Protected WithEvents txtDrag As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblShim As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents lblSl As System.Web.UI.WebControls.Label
    Protected WithEvents txtOperator As System.Web.UI.WebControls.TextBox
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    'new
    Protected WithEvents txtCopeone As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCopetwo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCopethree As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCopefour As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDragone As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDragtwo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDragthree As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDragfour As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtdrag As System.Web.UI.WebControls.TextBox
    Protected WithEvents txttread As System.Web.UI.WebControls.TextBox

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
    Protected Sub Dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        lblSl.Visible = False
        If Page.IsPostBack = False Then
            'Session("UserID") = "111111"
            'Session("Group") = "CLRMAG"
            txtOperator.Text = Session("UserID")
            txtDate.Text = Now.Date
            Try
                Dim oEmp As New rwfGen.Employee()
                'If oEmp.Check(Session("UserID"), Session("Group")) = True Then
                '    txtOperator.Text = Session("UserID")
                'Else
                '    txtOperator.Text = ""
                'End If
                'If txtOperator.Text = "" Then
                '    Response.Redirect("InvalidSession.aspx")
                'End If
                FillGrid()
                oEmp = Nothing
            Catch exp As Exception
                lblMessage.Text = exp.Message
                ''Response.Redirect("http://172.16.25.53/mms/InvalidSession.aspx")
            End Try
        End If
    End Sub

    Private Sub FillGrid()
        DataGrid1.SelectedIndex = -1
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            DataGrid1.DataSource = CalibrationTest.Tables.getUVData(CDate(txtDate.Text))
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtDueDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDueDate.TextChanged
        lblMessage.Text = ""
        Dim Startdate, Duedate As Date
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
            rblShim.SelectedIndex = 0
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
        mystr = Nothing
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtOperator.Text = "" Then
            Response.Redirect("http://172.16.25.53/mms/InvalidSession.aspx")
        End If
        Dim paradate, duedate As Date
        Dim bhnmean1, proctol1, accept1 As Double
        Dim done As Boolean
        Try
            'If Trim(txtCope.Text) <> "" Then
            '    bhnmean1 = CType(Trim(txtCope.Text), Double)
            '    done = True
            'End If
            'If Trim(txtDrag.Text) <> "" Then
            '    proctol1 = CType(Trim(txtDrag.Text), Double)
            '    done = True
            'End If
            'paradate = CDate(Trim(txtDate.Text))
            'duedate = CDate(Trim(txtDueDate.Text))
            paradate = Convert.ToDateTime(txtDate.Text)
            duedate = Convert.ToDateTime(txtDueDate.Text)
        Catch exp As Exception
            done = False
            lblMessage.Text = exp.Message
        End Try
        Dim oUV As New CalibrationTest.UV()
        Try
            oUV.CalibrationDate = Convert.ToDateTime(txtDate.Text)
            oUV.Shift = rblShift.SelectedItem.Text
            oUV.LineNumber = rblLine.SelectedItem.Text
            oUV.Inspector = txtOperator.Text
            'oUV.CopeIntensity = Val(txtCope.Text)
            'oUV.DragIntensity = Val(txtDrag.Text)
            oUV.Setcopec1 = Convert.ToInt64(txtCopeone.Text)
            oUV.Setcopec2 = Convert.ToInt64(txtCopetwo.Text)
            oUV.Setcopec3 = Convert.ToInt64(txtCopethree.Text)
            oUV.Setcopec4 = Convert.ToInt64(txtCopefour.Text)
            oUV.Setdragd1 = Convert.ToInt64(txtDragone.Text)
            oUV.Setdragd2 = Convert.ToInt64(txtDragtwo.Text)
            oUV.Setdragd3 = Convert.ToInt64(txtDragthree.Text)
            oUV.Setdragd4 = Convert.ToInt64(txtDragfour.Text)
            oUV.Setdrag = Convert.ToInt64(txtdrag.Text)
            oUV.SetTread = Convert.ToInt64(txttread.Text)
            oUV.DueDate = Convert.ToDateTime(txtDueDate.Text)
            oUV.ResultID = rblShim.SelectedItem.Value
            oUV.Remarks = txtRemark.Text.Trim
            oUV.SlNo = IIf((Val(lblSl.Text) = 0), 0, Val(lblSl.Text))
            oUV.SaveUV(oUV.SlNo)
            lblMessage.Text = oUV.Message
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        Finally
            oUV = Nothing
        End Try
        Clear()
        Try
            FillGrid()
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
        paradate = Nothing
        duedate = Nothing
        bhnmean1 = Nothing
        proctol1 = Nothing
        accept1 = Nothing
        done = Nothing
    End Sub

    'Private Sub txtCope_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCope.TextChanged
    '    lblMessage.Text = ""
    '    If CheckForNumeric(txtCope.Text) = False Then
    '        lblMessage.Text = "Input for Cope must be a numeric type"
    '        txtCope.Text = ""
    '    Else
    '        txtCope.Text = NoDecimal(txtCope.Text)
    '        If txtCope.Text <> "" Then
    '            Dim mystr As String = Trim(txtCope.Text)
    '            Dim i As Integer
    '            For i = 1 To Len(mystr)
    '                If Asc(Mid(mystr.ToUpper, i, 1)) >= 65 And Asc(Mid(mystr.ToUpper, i, 1)) <= 90 Then
    '                    lblMessage.Text = "Please Enter Valid Number"
    '                    txtCope.Text = ""
    '                    Exit Sub
    '                End If
    '            Next
    '            i = Nothing
    '            mystr = Nothing
    '        End If
    '    End If
    'End Sub

    'Private Sub txtDrag_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDrag.TextChanged
    '    lblMessage.Text = ""
    '    If CheckForNumeric(txtDrag.Text) = False Then
    '        lblMessage.Text = "Input for Drag must be a numeric type"
    '        txtDrag.Text = ""
    '    Else
    '        txtDrag.Text = NoDecimal(txtDrag.Text)
    '        If txtDrag.Text <> "" Then
    '            Dim mystr As String = Trim(txtDrag.Text)
    '            Dim i As Integer
    '            For i = 1 To Len(mystr)
    '                If Asc(Mid(mystr.ToUpper, i, 1)) >= 65 And Asc(Mid(mystr.ToUpper, i, 1)) <= 90 Then
    '                    lblMessage.Text = "Please Enter Valid Number "
    '                    txtDrag.Text = ""
    '                    Exit Sub
    '                End If
    '            Next
    '            i = Nothing
    '            mystr = Nothing
    '        End If
    '    End If
    'End Sub

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

    Private Sub DataGrid1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.ItemCommand
        lblMessage.Text = ""
        lblSl.Text = ""
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
                    txtOperator.Text = e.Item.Cells(4).Text.Replace("&nbsp;", "")
                    'txtCope.Text = e.Item.Cells(5).Text.Replace("&nbsp;", "")
                    txtdrag.Text = e.Item.Cells(6).Text.Replace("&nbsp;", "")
                    txtDueDate.Text = e.Item.Cells(7).Text.Replace("&nbsp;", "")
                    rblShim.ClearSelection()
                    If Not e.Item.Cells(8).Text Is Nothing Then
                        For i = 0 To rblShim.Items.Count - 1
                            If rblShim.Items(i).Text = e.Item.Cells(8).Text Then
                                rblShim.SelectedIndex = i
                                Exit For
                            End If
                        Next
                    End If
                    txtRemark.Text = e.Item.Cells(9).Text.Replace("&nbsp;", "")
                    lblSl.Text = e.Item.Cells(10).Text
                    i = Nothing
            End Select
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub Clear()
        txtRemark.Text = ""
        'txtCope.Text = ""
        txtdrag.Text = ""
        txtDueDate.Text = ""
        lblSl.Text = ""
    End Sub
End Class
