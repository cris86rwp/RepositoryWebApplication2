Public Class TODReadings
    Inherits System.Web.UI.Page
    Protected WithEvents ddlMFC0 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlMFC1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblC0diff As System.Web.UI.WebControls.Label
    Protected WithEvents lblC1diff As System.Web.UI.WebControls.Label
    Protected WithEvents lblC2diff As System.Web.UI.WebControls.Label
    Protected WithEvents lblC0Day As System.Web.UI.WebControls.Label
    Protected WithEvents lblC1Day As System.Web.UI.WebControls.Label
    Protected WithEvents lblC2Day As System.Web.UI.WebControls.Label
    Protected WithEvents lblC0Month As System.Web.UI.WebControls.Label
    Protected WithEvents lblC1Month As System.Web.UI.WebControls.Label
    Protected WithEvents lblC2Month As System.Web.UI.WebControls.Label
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtC0_initial As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtC0_final As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtC1_initial As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtC1_final As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtC2_initial As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtC2_final As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator3 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents txtRemarksC0 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRemarksC1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRemarksC2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents ddlMFC2 As System.Web.UI.WebControls.DropDownList
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
        'Put user code to initialize the page here
        If Page.IsPostBack = False Then
            Try
                txtDate.Text = Now.Date
                GetTables()
                getData()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
    Private Sub GetTables()
        Dim dtMF As DataTable
        Try
            dtMF = Maintenance.ElecTables.GetMFValues
            getMFvalues(dtMF)
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            dtMF.Dispose()
        End Try
    End Sub
    Private Sub getMFvalues(ByRef dtMF As DataTable)
        Try
            FillDDL(ddlMFC0, dtMF)
            SelectDDL(ddlMFC0, 180000)
            FillDDL(ddlMFC1, dtMF)
            SelectDDL(ddlMFC1, 180000)
            FillDDL(ddlMFC2, dtMF)
            SelectDDL(ddlMFC2, 180000)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub FillDDL(ByRef ddl As System.Web.UI.WebControls.DropDownList, ByRef dt As DataTable)
        ddl.DataSource = dt.DefaultView
        ddl.DataTextField = dt.Columns(0).ColumnName
        ddl.DataValueField = dt.Columns(0).ColumnName
        ddl.DataBind()
    End Sub
    Private Sub SelectDDL(ByRef ddl As System.Web.UI.WebControls.DropDownList, ByRef dtVal As String)
        ddl.ClearSelection()
        Dim blnSelected As Boolean
        Dim i As Integer = 0
        For i = 0 To ddl.Items.Count - 1
            If ddl.Items(i).Text = CStr(dtVal) Then
                ddl.Items(i).Selected = True
                blnSelected = True
                Exit For
            End If
        Next
        If blnSelected = False Then
            ddl.Items(0).Selected = True
        End If
        blnSelected = False
    End Sub
    Private Sub getInitialValues()
        Dim dt As DataTable
        Try
            dt = Maintenance.ElecTables.getTODInitialValues(CDate(txtDate.Text))
            If dt.Rows.Count > 0 Then
                If dt.Rows(0)(0) = "Yes" Then
                    If Not IsDBNull(dt.Rows(0)(1)) Then txtC0_initial.Text = dt.Rows(0)(1)
                    If Not IsDBNull(dt.Rows(0)(2)) Then txtC1_initial.Text = dt.Rows(0)(2)
                    If Not IsDBNull(dt.Rows(0)(3)) Then txtC2_initial.Text = dt.Rows(0)(3)
                Else
                    If Not IsDBNull(dt.Rows(0)(1)) Then txtC0_initial.Text = dt.Rows(0)(1)
                    If Not IsDBNull(dt.Rows(0)(2)) Then txtC0_final.Text = dt.Rows(0)(2)
                    If Not IsDBNull(dt.Rows(0)(3)) Then txtC1_initial.Text = dt.Rows(0)(3)
                    If Not IsDBNull(dt.Rows(0)(4)) Then txtC1_final.Text = dt.Rows(0)(4)
                    If Not IsDBNull(dt.Rows(0)(5)) Then txtC2_initial.Text = dt.Rows(0)(5)
                    If Not IsDBNull(dt.Rows(0)(6)) Then txtC2_final.Text = dt.Rows(0)(6)
                    SelectDDL(ddlMFC0, dt.Rows(0)(7))
                    SelectDDL(ddlMFC1, dt.Rows(0)(8))
                    SelectDDL(ddlMFC2, dt.Rows(0)(9))
                    lblC0diff.Text = CDbl(txtC0_final.Text) - CDbl(txtC0_initial.Text)
                    lblC1diff.Text = CDbl(txtC1_final.Text) - CDbl(txtC1_initial.Text)
                    lblC2diff.Text = CDbl(txtC2_final.Text) - CDbl(txtC2_initial.Text)
                    lblC0Day.Text = (CDbl(txtC0_final.Text) - CDbl(txtC0_initial.Text)) * ddlMFC0.SelectedItem.Value
                    lblC1Day.Text = (CDbl(txtC1_final.Text) - CDbl(txtC1_initial.Text)) * ddlMFC1.SelectedItem.Value
                    lblC2Day.Text = (CDbl(txtC2_final.Text) - CDbl(txtC2_initial.Text)) * ddlMFC2.SelectedItem.Value
                    txtRemarksC0.Text = IIf(IsDBNull(dt.Rows(0)(10)), "", dt.Rows(0)(10))
                    txtRemarksC1.Text = IIf(IsDBNull(dt.Rows(0)(11)), "", dt.Rows(0)(11))
                    txtRemarksC2.Text = IIf(IsDBNull(dt.Rows(0)(12)), "", dt.Rows(0)(12))
                End If
            Else
                Throw New Exception("No data for the Given Date !")
            End If
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            dt.Dispose()
        End Try
    End Sub
    Private Sub getUnitsforMonth()
        Dim dt As DataTable
        Try
            dt = Maintenance.ElecTables.getTODUnitsforMonth(CDate(txtDate.Text))
            If IsNothing(dt) = False Then
                lblC0Month.Text = IIf(IsDBNull(dt.Rows(0)("C0")), 0, dt.Rows(0)("C0"))
                lblC1Month.Text = IIf(IsDBNull(dt.Rows(0)("C1")), 0, dt.Rows(0)("C1"))
                lblC2Month.Text = IIf(IsDBNull(dt.Rows(0)("C2")), 0, dt.Rows(0)("C2"))
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
        End Try
    End Sub
    Private Sub getUnitsforDay()
        Dim dt As DataTable
        Try
            dt = Maintenance.ElecTables.getTODUnitsforDay(CDate(txtDate.Text))
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0)(1)) Then txtC0_initial.Text = dt.Rows(0)(1)
                If Not IsDBNull(dt.Rows(0)(2)) Then txtC0_final.Text = dt.Rows(0)(2)
                If Not IsDBNull(dt.Rows(0)(3)) Then txtC1_initial.Text = dt.Rows(0)(3)
                If Not IsDBNull(dt.Rows(0)(4)) Then txtC1_final.Text = dt.Rows(0)(4)
                If Not IsDBNull(dt.Rows(0)(5)) Then txtC2_initial.Text = dt.Rows(0)(5)
                If Not IsDBNull(dt.Rows(0)(6)) Then txtC2_final.Text = dt.Rows(0)(6)
                lblC0diff.Text = CDbl(txtC0_final.Text) - CDbl(txtC0_initial.Text)
                lblC1diff.Text = CDbl(txtC1_final.Text) - CDbl(txtC1_initial.Text)
                lblC2diff.Text = CDbl(txtC2_final.Text) - CDbl(txtC2_initial.Text)
                lblC0Day.Text = (CDbl(txtC0_final.Text) - CDbl(txtC0_initial.Text)) * ddlMFC0.SelectedItem.Value
                lblC1Day.Text = (CDbl(txtC1_final.Text) - CDbl(txtC1_initial.Text)) * ddlMFC1.SelectedItem.Value
                lblC2Day.Text = (CDbl(txtC2_final.Text) - CDbl(txtC2_initial.Text)) * ddlMFC2.SelectedItem.Value
                txtRemarksC0.Text = IIf(IsDBNull(dt.Rows(0)(7)), "", dt.Rows(0)(7))
                txtRemarksC1.Text = IIf(IsDBNull(dt.Rows(0)(8)), "", dt.Rows(0)(8))
                txtRemarksC2.Text = IIf(IsDBNull(dt.Rows(0)(9)), "", dt.Rows(0)(9))
            Else
                Throw New Exception("No data for the Given Date !")
            End If
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            dt.Dispose()
        End Try
    End Sub

    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        lblMessage.Text = ""
        Dim dt As Date
        Dim blnOK As Boolean
        Try
            dt = CDate(txtDate.Text.Trim)
            If dt > Now.Date Then
                txtDate.Text = ""
                blnOK = False
                lblMessage.Text = "Future Date not allowed !"
            Else
                txtDate.Text = dt
                blnOK = True
            End If
        Catch exp As Exception
            txtDate.Text = ""
            blnOK = False
            lblMessage.Text = exp.Message
        End Try
        If blnOK = True Then
            blnOK = False
        Else
            Exit Sub
        End If
        Try
            getData()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub getData()
        Try
            clear()
            Dim i As Long
            i = Maintenance.ElecTables.CheckTopTODData(CDate(txtDate.Text))
            If i > 0 Then
                getInitialValues()
            ElseIf i = 0 Then
                getUnitsforDay()
            End If
            getUnitsforMonth()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            DataGrid1.DataSource = Maintenance.ElecTables.getTOP5InitialValues
            DataGrid1.DataBind()
        End Try
    End Sub
    Private Sub clear()
        txtC0_final.Text = ""
        txtC0_initial.Text = ""
        txtC1_initial.Text = ""
        txtC1_final.Text = ""
        txtC2_initial.Text = ""
        txtC2_final.Text = ""
        lblC0Month.Text = ""
        lblC1Month.Text = ""
        lblC2Month.Text = ""
        lblC0Day.Text = ""
        lblC1Day.Text = ""
        lblC2Day.Text = ""
        lblC0diff.Text = ""
        lblC1diff.Text = ""
        lblC2diff.Text = ""
        txtRemarksC0.Text = ""
        txtRemarksC1.Text = ""
        txtRemarksC2.Text = ""
    End Sub

    Private Sub txtC0_final_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtC0_final.TextChanged
        lblMessage.Text = ""
        lblC0Day.Text = 0
        Try
            Try
                Dim d1, d2, val As Double
                d1 = txtC0_final.Text
                d2 = txtC0_initial.Text
                val = (d1 - d2)
                lblC0diff.Text = val
            Catch exp As Exception
                lblMessage.Text = "Enter Numeric Values"
                Exit Sub
            End Try
            If CDbl(txtC0_final.Text) < CDbl(txtC0_initial.Text) Then
                lblMessage.Text = "Final Reading is Less Than Initial"
                txtC0_initial.Text = ""
                Exit Sub
            End If
            If txtC0_final.Text = "" And txtC0_initial.Text = "" Then

            Else
                lblC0Day.Text = (CDbl(txtC0_final.Text) - CDbl(txtC0_initial.Text)) * ddlMFC0.SelectedItem.Value
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtC1_final_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtC1_final.TextChanged
        lblMessage.Text = ""
        lblC1Day.Text = 0
        Try
            Try
                Dim d1, d2, val As Double
                d1 = txtC1_final.Text
                d2 = txtC1_initial.Text
                val = (d1 - d2)
                lblC1diff.Text = val
            Catch exp As Exception
                lblMessage.Text = "Enter Numeric Values"
                Exit Sub
            End Try
            If CDbl(txtC1_final.Text) < CDbl(txtC1_initial.Text) Then
                lblMessage.Text = "Final Reading is Less Than Initial"
                txtC1_initial.Text = ""
                Exit Sub
            End If
            If txtC1_final.Text = "" And txtC1_initial.Text = "" Then

            Else
                lblC1Day.Text = (CDbl(txtC1_final.Text) - CDbl(txtC1_initial.Text)) * ddlMFC1.SelectedItem.Value
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtC2_final_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtC2_final.TextChanged
        lblMessage.Text = ""
        lblC2Day.Text = 0
        Try
            Try
                Dim d1, d2, val As Double
                d1 = txtC2_final.Text
                d2 = txtC2_initial.Text
                val = (d1 - d2)
                lblC2diff.Text = val
            Catch exp As Exception
                lblMessage.Text = "Enter Numeric Values"
                Exit Sub
            End Try
            If CDbl(txtC2_final.Text) < CDbl(txtC2_initial.Text) Then
                lblMessage.Text = "Final Reading is Less Than Initial"
                txtC2_initial.Text = ""
                Exit Sub
            End If
            If txtC2_final.Text = "" And txtC2_initial.Text = "" Then

            Else
                lblC2Day.Text = (CDbl(txtC2_final.Text) - CDbl(txtC2_initial.Text)) * ddlMFC2.SelectedItem.Value
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub FillTexts(ByVal oObj As Object, ByVal TRname As String, ByVal initial As Decimal, ByVal final As Decimal, ByVal mf As Decimal, ByVal diff As System.Web.UI.WebControls.Label, ByVal units As System.Web.UI.WebControls.Label)
        Dim i As Int16
        For i = 0 To CType(oObj, Maintenance.Electrical.Energy).count - 1
            If CType(oObj, Maintenance.Electrical.Energy).TR(i).Name.ToLower = TRname.Trim.ToLower Then
                CType(oObj, Maintenance.Electrical.Energy).TR(i).Reading.initial = initial
                CType(oObj, Maintenance.Electrical.Energy).TR(i).Reading.final = final
                CType(oObj, Maintenance.Electrical.Energy).TR(i).Reading.rad = mf
                diff.Text = CType(oObj, Maintenance.Electrical.Energy).TR(i).Reading.diff
                units.Text = CType(oObj, Maintenance.Electrical.Energy).TR(i).Reading.units
                If TRname.Trim.ToLower = "c0" Then
                    CType(oObj, Maintenance.Electrical.Energy).TR(i).Reading.Remarks = txtRemarksC0.Text
                ElseIf TRname.Trim.ToLower = "c1" Then
                    CType(oObj, Maintenance.Electrical.Energy).TR(i).Reading.Remarks = txtRemarksC1.Text
                ElseIf TRname.Trim.ToLower = "c2" Then
                    CType(oObj, Maintenance.Electrical.Energy).TR(i).Reading.Remarks = txtRemarksC2.Text
                End If

                Exit For
            End If
        Next
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        Try
            Dim oTOD As New Maintenance.Electrical.Energy()
            oTOD.ConsumptionDate = CDate(txtDate.Text)

            FillTexts(oTOD, "C0", IIf(IsDBNull(txtC0_initial.Text), 0.0, (Val(txtC0_initial.Text))), IIf(IsDBNull(txtC0_final.Text), 0.0, (Val(txtC0_final.Text))), (Val(ddlMFC0.SelectedItem.Text)), lblC0diff, lblC0Month)
            FillTexts(oTOD, "C1", IIf(IsDBNull(txtC1_initial.Text), 0.0, (Val(txtC1_initial.Text))), IIf(IsDBNull(txtC1_final.Text), 0.0, (Val(txtC1_final.Text))), (Val(ddlMFC1.SelectedItem.Text)), lblC1diff, lblC1Month)
            FillTexts(oTOD, "C2", IIf(IsDBNull(txtC2_initial.Text), 0.0, (Val(txtC2_initial.Text))), IIf(IsDBNull(txtC2_final.Text), 0.0, (Val(txtC2_final.Text))), (Val(ddlMFC2.SelectedItem.Text)), lblC2diff, lblC2Month)

            oTOD.SaveTODEnergyConsumption(CDate(txtDate.Text))
            lblMessage.Text = oTOD.Message
            clear()
            txtDate.Text = Now.Date
            DataGrid1.DataSource = Maintenance.ElecTables.getTOP5InitialValues
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub DataGrid1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.ItemCommand
        lblMessage.Text = ""
        Dim Done As Boolean
        Select Case e.CommandName
            Case "Delete"
                Dim i As Integer
                If Not e.Item.Cells(1).Text Is Nothing Then
                    Dim oTOD As New Maintenance.Electrical.Energy()
                    oTOD.ConsumptionDate = CDate(e.Item.Cells(1).Text)
                    Done = oTOD.SaveTODEnergyConsumption(CDate(e.Item.Cells(1).Text), True)
                End If
        End Select
        If Done Then
            Try
                DataGrid1.DataSource = Maintenance.ElecTables.getTOP5InitialValues
                DataGrid1.DataBind()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            lblMessage.Text &= " Data deleted !"
        End If
    End Sub
End Class
