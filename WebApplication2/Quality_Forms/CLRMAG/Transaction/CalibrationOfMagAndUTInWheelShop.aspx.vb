Public Class CalibrationOfMagAndUTInWheelShop
    Inherits System.Web.UI.Page
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents rblTestType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblShift As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlWheelType As System.Web.UI.WebControls.DropDownList
    Protected WithEvents rblLine As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents pnlMAG As System.Web.UI.WebControls.Panel
    Protected WithEvents txtBathConc As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblShim As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents pnlUT As System.Web.UI.WebControls.Panel
    Protected WithEvents txtTimeFrom As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtResult As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRemark As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents lblSlNo As System.Web.UI.WebControls.Label
    Protected WithEvents txtOperator As System.Web.UI.WebControls.TextBox
    Protected WithEvents pnlResults As System.Web.UI.WebControls.Panel
    Protected WithEvents txtTimeTo As System.Web.UI.WebControls.TextBox
    Protected WithEvents pnlSetUp As System.Web.UI.WebControls.Panel
    Protected WithEvents ddlWheelType1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    'new
    Protected WithEvents txtcope As System.Web.UI.WebControls.TextBox
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
    Protected Sub Dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        lblSlNo.Visible = False
        If Page.IsPostBack = False Then
            'Session("UserID") = "013905"
            'Session("UserID") = "013904"
            'Session("Group") = "CLRMAG"

            'Dim oEmp As New rwfGen.Employee()
            'If oEmp.Check(Session("UserID"), Session("Group")) = True Then
            '    txtOperator.Text = Session("UserID")
            'Else
            '    txtOperator.Text = ""
            'End If
            'If txtOperator.Text = "" Then
            '    Response.Redirect("InvalidSession.aspx")
            'End If
            txtOperator.Text = Session("UserID")
            txtDate.Text = Now.Date
            Try
                getWhlType()
                CalibrationType()
                FillGrid()
            Catch exp As Exception
                lblMessage.Text = exp.Message
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
            ddlWheelType1.DataSource = dt
            ddlWheelType1.DataTextField = dt.Columns("WhlType").ColumnName
            ddlWheelType1.DataValueField = dt.Columns("WhlType").ColumnName
            ddlWheelType1.DataBind()
            For i = 0 To ddlWheelType1.Items.Count - 1
                If Trim("BOXN") = ddlWheelType1.Items(i).Text Then
                    ddlWheelType1.SelectedIndex = i
                End If
            Next
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        dt = Nothing
        i = Nothing
    End Sub
    Private Sub CalibrationType()
        Clear()
        If rblTestType.SelectedItem.Value.ToLower = "mag" Then
            pnlMAG.Visible = True
            pnlUT.Visible = False
        Else
            pnlMAG.Visible = False
            pnlUT.Visible = True
            If rblTestType.SelectedItem.Value.ToLower.EndsWith("results") Then
                pnlResults.Visible = True
            Else
                pnlSetUp.Visible = True
            End If
        End If
    End Sub
    Private Sub Clear()
        pnlSetUp.Visible = False
        pnlResults.Visible = False
        pnlMAG.Visible = False
        pnlUT.Visible = False
        txtBathConc.Text = ""
        txtTimeFrom.Text = ""
        txtTimeTo.Text = ""
        txtResult.Text = "SATISFACTORY"
        txtRemark.Text = ""
    End Sub

    Private Sub rblTestType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblTestType.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            CalibrationType()
            FillGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        lblMessage.Text = ""
        Dim dt As Date
        Try
            dt = CDate(txtDate.Text)
            If dt > Today Then
                lblMessage.Text = "Future Date : " & txtDate.Text & " Not Acceptable !"
                txtDate.Text = ""
            Else
                txtDate.Text = dt
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message & " : " & txtDate.Text
            txtDate.Text = ""
        End Try
        Try
            FillGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        dt = Nothing
    End Sub

    Private Sub rblShift_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblShift.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            FillGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub FillGrid()
        DataGrid1.SelectedIndex = -1
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            DataGrid1.DataSource = CalibrationTest.Tables.getCalibrationDetails(rblTestType.SelectedItem.Text, CDate(txtDate.Text), rblShift.SelectedItem.Text, rblLine.SelectedItem.Text, ddlWheelType.SelectedItem.Text)
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub ddlWheelType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlWheelType.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            FillGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub DataGrid1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.ItemCommand
        lblMessage.Text = ""
        lblSlNo.Text = ""
        Select Case e.CommandName
            Case "Select"
                If rblTestType.SelectedItem.Text.ToLower = "mag" Then
                    pnlMAG.Visible = True
                    pnlUT.Visible = False
                    Dim i As Integer = 0
                    i = 0
                    ddlWheelType.ClearSelection()
                    If Not e.Item.Cells(5).Text Is Nothing Then
                        For i = 0 To ddlWheelType.Items.Count - 1
                            If ddlWheelType.Items(i).Value = e.Item.Cells(5).Text Then
                                ddlWheelType.SelectedIndex = i
                                Exit For
                            End If
                        Next
                    End If
                    txtBathConc.Text = e.Item.Cells(6).Text.Replace("&nbsp;", "")
                    txtOperator.Text = e.Item.Cells(3).Text
                    txtcope.Text = e.Item.Cells(10).Text
                    'txtOperator.Text = e.Item.Cells(3).Text.Replace("&nbsp;", "")
                    'If Not e.Item.Cells(3).Text Is Nothing Then
                    'For i = 0 To txtOperator.Text - 1
                    ' If txtOperator.Text = e.Item.Cells(3).Text Then
                    'txtOperator.SelectedIndex = i
                    'Exit For
                    'End If
                    'Next
                    'End If
                    i = 0
                    rblShim.ClearSelection()
                    If Not e.Item.Cells(1).Text Is Nothing Then
                        For i = 0 To rblShim.Items.Count - 1
                            If rblShim.Items(i).Value = e.Item.Cells(7).Text Then
                                rblShim.SelectedIndex = i
                                Exit For
                            End If
                        Next
                    End If
                    txtRemark.Text = e.Item.Cells(8).Text.Replace("&nbsp;", "")

                    lblSlNo.Text = e.Item.Cells(9).Text.Replace("&nbsp;", "")
                    i = Nothing
                Else
                    pnlMAG.Visible = False
                    pnlUT.Visible = True
                    Dim i As Integer = 0
                    i = 0
                    ddlWheelType.ClearSelection()
                    If Not e.Item.Cells(5).Text Is Nothing Then
                        For i = 0 To ddlWheelType.Items.Count - 1
                            If ddlWheelType.Items(i).Value = e.Item.Cells(5).Text Then
                                ddlWheelType.SelectedIndex = i
                                Exit For
                            End If
                        Next
                    End If
                    txtOperator.Text = e.Item.Cells(3).Text
                    txtcope.Text = e.Item.Cells(10).Text
                    txtTimeFrom.Text = e.Item.Cells(6).Text.Replace("&nbsp;", "")
                    txtTimeTo.Text = e.Item.Cells(7).Text.Replace("&nbsp;", "")
                    txtRemark.Text = e.Item.Cells(9).Text.Replace("&nbsp;", "")
                    lblSlNo.Text = e.Item.Cells(10).Text.Replace("&nbsp;", "")
                    If e.Item.Cells(11).Text.Replace("&nbsp;", "") = "Results" Then
                        pnlResults.Visible = True
                        pnlSetUp.Visible = False
                        txtResult.Text = e.Item.Cells(8).Text.Replace("&nbsp;", "")
                    Else
                        pnlSetUp.Visible = True
                        pnlResults.Visible = False
                        ddlWheelType1.ClearSelection()
                        If Not e.Item.Cells(8).Text Is Nothing Then
                            For i = 0 To ddlWheelType1.Items.Count - 1
                                If ddlWheelType1.Items(i).Value = e.Item.Cells(8).Text Then
                                    ddlWheelType1.SelectedIndex = i
                                    Exit For
                                End If
                            Next
                        End If
                    End If

                    i = Nothing
                End If
        End Select
    End Sub

    Private Sub rblLine_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblLine.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            FillGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'If txtOperator.Text = "" Then
        '    Response.Redirect("http://RWFAPP03/mms/InvalidSession.aspx")
        'End If
        lblMessage.Text = ""
        Try
            If rblTestType.SelectedItem.Text.ToLower = "mag" Then
                If txtRemark.Text.Trim.Length = 0 Then
                    lblMessage.Text = "Shim Check Results not provided !"
                Else
                    Dim oMAG As New CalibrationTest.MAG()
                    oMAG.CalibrationDate = CDate(txtDate.Text)
                    oMAG.Shift = rblShift.SelectedItem.Text
                    oMAG.LineNumber = rblLine.SelectedItem.Text
                    oMAG.Inspector = txtOperator.Text
                    oMAG.WheelType = ddlWheelType.SelectedItem.Text
                    oMAG.BathConcentration = txtBathConc.Text
                    oMAG.Results = rblShim.SelectedItem.Value
                    oMAG.copemag = Convert.ToInt64(txtcope.Text)
                    If rblShim.SelectedIndex = 0 Then
                        txtRemark.Text = "Shim check OK"
                    End If
                    oMAG.Remarks = txtRemark.Text.Trim
                    oMAG.SlNo = IIf((Val(lblSlNo.Text) = 0), 0, Val(lblSlNo.Text))
                    oMAG.Save(oMAG.SlNo)
                    lblMessage.Text = oMAG.Message
                    oMAG = Nothing
                End If
            Else
                Dim oUT As New CalibrationTest.UT()
                oUT.CalibrationDate = CDate(txtDate.Text)
                oUT.Shift = rblShift.SelectedItem.Text
                oUT.LineNumber = rblLine.SelectedItem.Text
                oUT.Inspector = txtOperator.Text
                oUT.WheelType = ddlWheelType.SelectedItem.Text
                oUT.TimeFrom = txtTimeFrom.Text.Trim
                oUT.TimeTo = txtTimeTo.Text.Trim
                oUT.copeut = Convert.ToInt64(txtcope.Text)
                If rblTestType.SelectedItem.Value.ToLower.EndsWith("results") Then
                    oUT.Results = txtResult.Text
                    oUT.SetUp = "Results"
                Else
                    oUT.Results = ddlWheelType1.SelectedItem.Text
                    oUT.SetUp = "SetUp"
                End If
                oUT.Remarks = txtRemark.Text.Trim
                oUT.SlNo = IIf((Val(lblSlNo.Text) = 0), 0, Val(lblSlNo.Text))
                oUT.Save(oUT.SlNo)
                lblMessage.Text = oUT.Message
                oUT = Nothing
            End If
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
        Try
            FillGrid()
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
    End Sub
End Class
