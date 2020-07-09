Public Class BHNPostExperimentalResultAdd
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblMode As System.Web.UI.WebControls.Label
    Protected WithEvents ddlLabNumber As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblLabNumber As System.Web.UI.WebControls.Label
    Protected WithEvents lblClosure As System.Web.UI.WebControls.Label
    Protected WithEvents ini As System.Web.UI.WebControls.Label
    Protected WithEvents fin As System.Web.UI.WebControls.Label
    Protected WithEvents radClosure As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents lblFinaltemp As System.Web.UI.WebControls.Label
    Protected WithEvents lblTubetemp As System.Web.UI.WebControls.Label
    Protected WithEvents lblDraglife As System.Web.UI.WebControls.Label
    Protected WithEvents lblCopelife As System.Web.UI.WebControls.Label
    Protected WithEvents lblPourorder As System.Web.UI.WebControls.Label
    Protected WithEvents lblWheeltype As System.Web.UI.WebControls.Label
    Protected WithEvents lblTestType As System.Web.UI.WebControls.Label
    Protected WithEvents lblHeatrange As System.Web.UI.WebControls.Label
    Protected WithEvents lblWheelClass As System.Web.UI.WebControls.Label
    Protected WithEvents lblReceiveddate As System.Web.UI.WebControls.Label
    Protected WithEvents lblCastdate As System.Web.UI.WebControls.Label
    Protected WithEvents lblWheel As System.Web.UI.WebControls.Label
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblResult As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblMacro As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents chkGrain As System.Web.UI.WebControls.CheckBoxList
    Protected WithEvents rblStructure As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblDThick As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblDThin As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblCThick As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblCThin As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblBThick As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblBThin As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblAThick As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblAThin As System.Web.UI.WebControls.RadioButtonList
    Dim strMode As String
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
        strMode = "add"
        lblMode.Text = strMode
        ini.Visible = False
        fin.Visible = False
        If Not IsPostBack Then
            lblMode.Text = strMode
            Clear()
            Try
                getLabNumbers()
                GetDDLValues()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
    Private Sub getLabNumbers()
        ddlLabNumber.DataSource = Nothing
        ddlLabNumber.DataBind()
        Dim dt As New DataTable()
        Try
            ddlLabNumber.DataSource = metLab.tables.GetExpResultsLabNumber
            ddlLabNumber.DataTextField = metLab.tables.GetLabNumber.Columns(0).ColumnName
            ddlLabNumber.DataValueField = metLab.tables.GetLabNumber.Columns(1).ColumnName
            ddlLabNumber.DataBind()
            ddlLabNumber.Items.Insert(0, "select")
        Catch exp As Exception
            Throw New Exception("Fetching of LabNumber" & exp.Message)
        End Try
    End Sub
    Private Function ReturnWheel(ByVal mystr As String) As String
        Dim myarray As Array
        Dim mywheel, myheat As String
        If mystr <> "" Then
            myarray = Split(mystr, "/")
            mywheel = myarray(0)
            myheat = myarray(1)
            Return mywheel
        End If
    End Function
    Private Function ReturnHeat(ByVal mystr As String) As String
        Dim myarray As Array
        Dim mywheel, myheat As String
        If mystr <> "" Then
            myarray = Split(mystr, "/")
            mywheel = myarray(0)
            myheat = myarray(1)
            Return myheat
        End If
    End Function
    Private Sub Clear()
        lblWheel.Text = ""
        lblCastdate.Text = ""
        lblClosure.Text = ""
        ini.Text = ""
        fin.Text = ""
        lblCopelife.Text = ""
        lblDraglife.Text = ""
        lblFinaltemp.Text = ""
        lblHeatrange.Text = ""
        lblLabNumber.Text = ""
        lblPourorder.Text = ""
        lblReceiveddate.Text = ""
        lblTubetemp.Text = ""
        lblWheeltype.Text = ""
        lblWheelClass.Text = ""
        lblTestType.Text = ""
        rblStructure.SelectedIndex = 0
        radClosure.SelectedIndex = 0
        rblMacro.SelectedIndex = 0
        rblResult.SelectedIndex = 0
        txtRemarks.Text = ""
        viewstate("GrainSize") = Nothing
        viewstate("Inclusion") = Nothing
        Dim i As Int16
        For i = 0 To chkGrain.Items.Count - 1
            If chkGrain.Items(i).Selected Then
                chkGrain.Items(i).Selected = False
            End If
        Next
    End Sub
    Private Sub ddlLabNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlLabNumber.SelectedIndexChanged
        lblMessage.Text = ""
        Clear()
        If ddlLabNumber.SelectedIndex = 0 Then
            lblMessage.Text = "Please select wheel number !"
            Exit Sub
        Else
            Try
                lblLabNumber.Text = ddlLabNumber.SelectedItem.Value
                getDetails()
            Catch exp As Exception
                lblLabNumber.Text &= exp.Message
            End Try
        End If

    End Sub
    Private Sub getDetails()
        Dim mywheel As String = ReturnWheel(Trim(ddlLabNumber.SelectedItem.Text))
        Dim myheat As String = ReturnHeat(Trim(ddlLabNumber.SelectedItem.Text))
        Dim ds As New DataSet()
        Dim dt As New DataTable()
        Try
            lblClosure.Text = ""
            ds = metLab.tables.GetLabValues(lblLabNumber.Text, mywheel, myheat)
            Session("LabNumber") = lblLabNumber.Text
            If ds.Tables(0).Rows.Count <= 0 Then
                lblMessage.Text = "Closure Values Not Entered !"
            Else
                ini.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)(0)), 0, ds.Tables(0).Rows(0)(0))
                fin.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)(1)), 0, ds.Tables(0).Rows(0)(1))
                lblClosure.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)(2)), 0, ds.Tables(0).Rows(0)(2))
                If IsDBNull(ds.Tables(0).Rows(0)(3)) Then
                    If Val(lblClosure.Text.Trim) < 1 Then
                        radClosure.SelectedIndex = 0
                    Else
                        radClosure.SelectedIndex = 1
                    End If
                Else
                    Dim i As Int16
                    For i = 0 To radClosure.Items.Count - 1
                        If radClosure.Items(i).Text.Substring(0, 1) = Trim(ds.Tables(0).Rows(0)(3)) Then
                            radClosure.Items(i).Selected = True
                            Exit For
                        End If
                    Next
                End If
            End If
            lblReceiveddate.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)(0)), 0, ds.Tables(1).Rows(0)(0))
            lblHeatrange.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)(1)), "", ds.Tables(1).Rows(0)(1)) & " - " & IIf(IsDBNull(ds.Tables(1).Rows(0)(2)), 0, ds.Tables(1).Rows(0)(2))
            lblWheel.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)(3)), "", ds.Tables(1).Rows(0)(3))
            lblWheelClass.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)(4)), "", ds.Tables(1).Rows(0)(4))
            lblTestType.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)(5)), "", ds.Tables(1).Rows(0)(5))

            lblCastdate.Text = IIf(IsDBNull(ds.Tables(2).Rows(0)(0)), 0, ds.Tables(2).Rows(0)(0))
            lblPourorder.Text = IIf(IsDBNull(ds.Tables(2).Rows(0)(1)), 0, ds.Tables(2).Rows(0)(1))
            lblCopelife.Text = IIf(IsDBNull(ds.Tables(2).Rows(0)(2)), 0, ds.Tables(2).Rows(0)(2))
            lblDraglife.Text = IIf(IsDBNull(ds.Tables(2).Rows(0)(3)), 0, ds.Tables(2).Rows(0)(3))
            lblWheeltype.Text = IIf(IsDBNull(ds.Tables(2).Rows(0)(4)), 0, ds.Tables(2).Rows(0)(4))
            lblTubetemp.Text = IIf(IsDBNull(ds.Tables(3).Rows(0)(0)), 0, ds.Tables(3).Rows(0)(0))
            lblFinaltemp.Text = IIf(IsDBNull(ds.Tables(3).Rows(0)(1)), 0, ds.Tables(3).Rows(0)(1))
        Catch expGen As Exception
            lblMessage.Text &= expGen.Message
        Finally
            dt.Dispose()
            ds.Dispose()
        End Try
    End Sub
    Private Sub GetDDLValues()
        Dim ds As New DataSet()
        Try
            ds = metLab.tables.GetDDLValues
        Catch exp As Exception
            Throw New Exception("DDL Filling Error !")
        End Try
    End Sub
    Private Sub FillDDLs(ByVal dt As DataTable, ByVal ddl As DropDownList)
        ddl.DataSource = dt.DefaultView
        ddl.DataTextField = dt.Columns(1).ColumnName
        ddl.DataValueField = dt.Columns(0).ColumnName
        ddl.DataBind()
    End Sub
    Private Sub rblLabValues_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lblMessage.Text = ""
        If ddlLabNumber.SelectedIndex = 0 Then
            lblMessage.Text = "Please select Wheel Number !"
            Exit Sub
        End If
    End Sub
    Private Sub SetGrainSize()
        Dim i, j As Integer
        Dim g As String
        j = 0
        For i = 0 To chkGrain.Items.Count - 1
            If chkGrain.Items(i).Selected Then
                j = j + 1
                If j = 1 Then
                    g = chkGrain.Items(i).Text
                Else
                    g = g + "-" + chkGrain.Items(i).Text
                End If
            End If
        Next
        viewstate("GrainSize") = g
    End Sub
    Private Sub FillInclusion()
        Dim NewDT As New DataTable()
        Try
            Dim dr As DataRow
            Dim cnt As Integer
            NewDT.TableName = "Inclusion"
            NewDT.Columns.Add("lab_number")
            NewDT.Columns.Add("Inclusion")
            NewDT.Columns.Add("thin")
            NewDT.Columns.Add("thick")
            If rblAThin.SelectedIndex > 0 Or rblAThick.SelectedIndex > 0 Then
                dr = NewDT.NewRow
                dr("lab_number") = lblLabNumber.Text.Trim
                dr("Inclusion") = "A"
                dr("thin") = rblAThin.SelectedItem.Value
                dr("thick") = rblAThick.SelectedItem.Value
                NewDT.Rows.Add(dr)
            End If
            If rblBThin.SelectedIndex > 0 Or rblBThick.SelectedIndex > 0 Then
                dr = NewDT.NewRow
                dr("lab_number") = lblLabNumber.Text.Trim
                dr("Inclusion") = "B"
                dr("thin") = rblBThin.SelectedItem.Value
                dr("thick") = rblBThick.SelectedItem.Value
                NewDT.Rows.Add(dr)
            End If
            If rblCThin.SelectedIndex > 0 Or rblCThick.SelectedIndex > 0 Then
                dr = NewDT.NewRow
                dr("lab_number") = lblLabNumber.Text.Trim
                dr("Inclusion") = "C"
                dr("thin") = rblCThin.SelectedItem.Value
                dr("thick") = rblCThick.SelectedItem.Value
                NewDT.Rows.Add(dr)
            End If
            If rblDThin.SelectedIndex > 0 Or rblDThick.SelectedIndex > 0 Then
                dr = NewDT.NewRow
                dr("lab_number") = lblLabNumber.Text.Trim
                dr("Inclusion") = "D"
                dr("thin") = rblDThin.SelectedItem.Value
                dr("thick") = rblDThick.SelectedItem.Value
                NewDT.Rows.Add(dr)
            End If
            viewstate("Inclusion") = NewDT
        Catch exp As Exception
            Throw New Exception(exp.Message)
        End Try
    End Sub
    Private Sub Setfocus(ByVal ctrl As Control)
        'Define the JavaScript function for the specefied control.
        Dim focusScript As String = "<script language = 'javascript'>" & _
        "document.getElementById('" + ctrl.ClientID & _
        "').focus();</script>"
        'Add the JavaScript code to the page.
        Page.RegisterStartupScript("FocusScript", focusScript)
        ' MarkControlsAsSelected(ctrl)
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ddlLabNumber.SelectedIndex = 0 Then
            lblMessage.Text = " Please select Wheel Number !"
            Exit Sub
        ElseIf Not lblTestType.Text = "Experimental" Then
            If lblClosure.Text.Length <= 0 Then
                lblMessage.Text = " Closere values not valid !"
                Exit Sub
            End If
        End If
        Dim oWhl As New metLab.Product()
        Try
            FillInclusion()
            SetGrainSize()
            oWhl.WheelNumber = ReturnWheel(ddlLabNumber.SelectedItem.Text.Trim)
            oWhl.HeatNumber = ReturnHeat(ddlLabNumber.SelectedItem.Text.Trim)
            oWhl.LabNumber = ddlLabNumber.SelectedItem.Value.Trim
            oWhl.grain_size = CType(viewstate("GrainSize"), String)
            oWhl.InclusionTable = CType(viewstate("Inclusion"), DataTable)
            oWhl.micro = rblStructure.SelectedItem.Text.Trim
            oWhl.macro = rblMacro.SelectedItem.Text.Trim
            oWhl.result = rblResult.SelectedItem.Value.Trim
            oWhl.remarks = txtRemarks.Text.Trim
            If oWhl.saveExpWheels(oWhl.LabNumber, lblMode.Text.Trim, "Results") Then
                getLabNumbers()
                Clear()
                lblMessage.Text = "Records Updateded !"
            Else
                lblMessage.Text = "Records Updation Failed !"
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
End Class
