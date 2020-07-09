Public Class BHNPostResultEdit
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblMode As System.Web.UI.WebControls.Label
    Protected WithEvents lblLabNumber As System.Web.UI.WebControls.Label
    Protected WithEvents lblClosure As System.Web.UI.WebControls.Label
    Protected WithEvents ini As System.Web.UI.WebControls.Label
    Protected WithEvents fin As System.Web.UI.WebControls.Label
    Protected WithEvents txtUTS_rim As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtUTS_plate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtJoules_a As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtYS_rim As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtYS_plate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtJoules_b As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtKlengation_rim As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtKlengation_plate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtJoules_c As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRedn_rim As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRedn_plate As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblAvg As System.Web.UI.WebControls.Label
    Protected WithEvents lblJoules As System.Web.UI.WebControls.Label
    Protected WithEvents rblAThin As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblAThick As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblBThin As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblBThick As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblCThin As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblCThick As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblDThin As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblDThick As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblStructure As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents chkGrain As System.Web.UI.WebControls.CheckBoxList
    Protected WithEvents rblMacro As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblResult As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWheelNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents radClosure As System.Web.UI.WebControls.RadioButtonList
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
        'strMode = Request.QueryString("mode")
        If Not IsPostBack Then
            lblMode.Text = "edit"
            ini.Visible = False
            fin.Visible = False
        End If
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
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtWheelNumber.Text.Trim.Length = 0 Then
            lblMessage.Text = " Please enter Wheel Number !"
            Exit Sub
        ElseIf lblClosure.Text.Length <= 0 Then
            lblMessage.Text = " Closere values not valid !"
            Exit Sub
        End If
        Dim oWhl As New metLab.Product()
        Try
            FillInclusion()
            SetGrainSize()
            oWhl.WheelNumber = ReturnWheel(txtWheelNumber.Text.Trim)
            oWhl.HeatNumber = ReturnHeat(txtWheelNumber.Text.Trim)
            oWhl.LabNumber = lblLabNumber.Text.Trim
            oWhl.grain_size = CType(viewstate("GrainSize"), String)
            oWhl.InclusionTable = CType(viewstate("Inclusion"), DataTable)
            oWhl.initial_gaugelength = Val(ini.Text.Trim)
            oWhl.final_gaugelength = Val(fin.Text.Trim)
            oWhl.closure = radClosure.SelectedItem.Text
            oWhl.uts_rim = Val(txtUTS_rim.Text.Trim)
            oWhl.ys_rim = Val(txtYS_rim.Text.Trim)
            oWhl.klengation_rim = Val(txtKlengation_rim.Text.Trim)
            oWhl.rednarea_rim = Val(txtRedn_rim.Text.Trim)
            oWhl.uts_plate = Val(txtUTS_plate.Text.Trim)
            oWhl.ys_plate = Val(txtYS_plate.Text.Trim)
            oWhl.klengation_plate = Val(txtKlengation_plate.Text.Trim)
            oWhl.rednarea_plate = Val(txtRedn_plate.Text.Trim)
            oWhl.kurim_a = Val(txtJoules_a.Text.Trim)
            oWhl.kurim_b = Val(txtJoules_b.Text.Trim)
            oWhl.kurim_c = Val(txtJoules_c.Text.Trim)
            oWhl.datetoday = Date.Now
            oWhl.micro = rblStructure.SelectedItem.Text.Trim
            oWhl.macro = rblMacro.SelectedItem.Text.Trim
            oWhl.result = rblResult.SelectedItem.Value.Trim
            oWhl.remarks = txtRemarks.Text.Trim
            If oWhl.savePhysicalValues(oWhl.LabNumber, lblMode.Text.Trim) Then
                Clear()
                lblMessage.Text = "Records Updateded !"
            Else
                lblMessage.Text = "Records Updation Failed !"
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub Clear()
        lblAvg.Text = ""
        lblClosure.Text = ""
        ini.Text = ""
        fin.Text = ""
        lblJoules.Text = ""
        lblLabNumber.Text = ""
        rblStructure.SelectedIndex = 0
        radClosure.SelectedIndex = 0
        rblMacro.SelectedIndex = 0
        rblResult.SelectedIndex = 0
        txtJoules_a.Text = ""
        txtJoules_b.Text = ""
        txtJoules_c.Text = ""
        txtKlengation_plate.Text = ""
        txtKlengation_rim.Text = ""
        txtRedn_plate.Text = ""
        txtRedn_rim.Text = ""
        txtRemarks.Text = ""
        txtUTS_plate.Text = ""
        txtUTS_rim.Text = ""
        txtYS_plate.Text = ""
        txtYS_rim.Text = ""
        viewstate("GrainSize") = Nothing
        viewstate("Inclusion") = Nothing
        rblAThin.SelectedIndex = 0
        rblAThick.SelectedIndex = 0
        rblBThin.SelectedIndex = 0
        rblBThick.SelectedIndex = 0
        rblCThin.SelectedIndex = 0
        rblCThick.SelectedIndex = 0
        rblDThin.SelectedIndex = 0
        rblDThick.SelectedIndex = 0
    End Sub
    Private Sub txtWheelNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWheelNumber.TextChanged
        Dim mywheel As String = ReturnWheel(Trim(txtWheelNumber.Text))
        Dim myheat As String = ReturnHeat(Trim(txtWheelNumber.Text))
        If Session("UserID") = "074940" Then
            If myheat <= "81450" Then
                Response.Redirect("\testmss\BHNPostResult.aspx?mode=edit")
            End If
        End If
        If txtWheelNumber.Text.Trim.Length = 0 Then
            lblMessage.Text = " Please enter Wheel Number !"
            Exit Sub
        Else
            Clear()
            Dim ds As New DataSet()
            Dim int As Integer = 0
            Dim i, j As Int16
            Dim Gsize As Array
            Try
                ds = metLab.tables.GetHardnessValues(mywheel, myheat, Trim(txtWheelNumber.Text))
                If ds.Tables(0).Rows.Count <= 0 Then
                    lblMessage.Text = "Closure Values Not Entered !"
                Else
                    lblLabNumber.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("lab_number")), 0, ds.Tables(0).Rows(0)("lab_number"))
                    ini.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("initial_gaugelength")), 0, ds.Tables(0).Rows(0)("initial_gaugelength"))
                    fin.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("final_gaugelength")), 0, ds.Tables(0).Rows(0)("final_gaugelength"))
                    lblClosure.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("initial_gaugelength") - ds.Tables(0).Rows(0)("final_gaugelength")), 0, (ds.Tables(0).Rows(0)("initial_gaugelength") - ds.Tables(0).Rows(0)("final_gaugelength")))
                    For int = 0 To radClosure.Items.Count - 1
                        If radClosure.Items(int).Text.Trim = Trim(ds.Tables(0).Rows(0)("closure")) Then
                            radClosure.SelectedIndex = int
                            Exit For
                        End If
                    Next
                    txtUTS_rim.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("uts_rim")), 0, ds.Tables(0).Rows(0)("uts_rim"))
                    txtYS_rim.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("ys_rim")), 0, ds.Tables(0).Rows(0)("ys_rim"))
                    txtKlengation_rim.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("klengation_rim")), 0, ds.Tables(0).Rows(0)("klengation_rim"))
                    txtRedn_rim.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("rednarea_rim")), 0, ds.Tables(0).Rows(0)("rednarea_rim"))

                    txtUTS_plate.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("uts_plate")), 0, ds.Tables(0).Rows(0)("uts_plate"))
                    txtYS_plate.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("ys_plate")), 0, ds.Tables(0).Rows(0)("ys_plate"))
                    txtKlengation_plate.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("klengation_plate")), 0, ds.Tables(0).Rows(0)("klengation_plate"))
                    txtRedn_plate.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("rednarea_plate")), 0, ds.Tables(0).Rows(0)("rednarea_plate"))

                    txtJoules_a.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("kurim_a")), 0, ds.Tables(0).Rows(0)("kurim_a"))
                    txtJoules_b.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("kurim_b")), 0, ds.Tables(0).Rows(0)("kurim_b"))
                    txtJoules_c.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("kurim_c")), 0, ds.Tables(0).Rows(0)("kurim_c"))

                    int = 0
                    For int = 0 To ds.Tables(2).Rows.Count - 1
                        Select Case Trim(ds.Tables(2).Rows(int)("inclusion"))
                            Case "A"
                                For i = 0 To rblAThin.Items.Count - 1
                                    If rblAThin.Items(i).Text.Trim = Trim(ds.Tables(2).Rows(int)("thin")) Then
                                        rblAThin.ClearSelection()
                                        rblAThin.SelectedIndex = i
                                        Exit For
                                    End If
                                Next
                                For j = 0 To rblAThick.Items.Count - 1
                                    If rblAThick.Items(j).Text.Trim = Trim(ds.Tables(2).Rows(int)("thick")) Then
                                        rblAThick.ClearSelection()
                                        rblAThick.SelectedIndex = j
                                        Exit For
                                    End If
                                Next
                            Case "B"
                                For i = 0 To rblBThin.Items.Count - 1
                                    If rblBThin.Items(i).Text.Trim = Trim(ds.Tables(2).Rows(int)("thin")) Then
                                        rblBThin.ClearSelection()
                                        rblBThin.SelectedIndex = i
                                        Exit For
                                    End If
                                Next
                                For j = 0 To rblBThick.Items.Count - 1
                                    If rblBThick.Items(j).Text.Trim = Trim(ds.Tables(2).Rows(int)("thick")) Then
                                        rblBThick.ClearSelection()
                                        rblBThick.SelectedIndex = j
                                        Exit For
                                    End If
                                Next
                            Case "C"
                                For i = 0 To rblCThin.Items.Count - 1
                                    If rblCThin.Items(i).Text.Trim = Trim(ds.Tables(2).Rows(int)("thin")) Then
                                        rblCThin.ClearSelection()
                                        rblCThin.SelectedIndex = i
                                        Exit For
                                    End If
                                Next
                                For j = 0 To rblCThick.Items.Count - 1
                                    If rblCThick.Items(j).Text.Trim = Trim(ds.Tables(2).Rows(int)("thick")) Then
                                        rblCThick.ClearSelection()
                                        rblCThick.SelectedIndex = j
                                        Exit For
                                    End If
                                Next
                            Case "D"
                                For i = 0 To rblDThin.Items.Count - 1
                                    If rblDThin.Items(i).Text.Trim = Trim(ds.Tables(2).Rows(int)("thin")) Then
                                        rblDThin.ClearSelection()
                                        rblDThin.SelectedIndex = i
                                        Exit For
                                    End If
                                Next
                                For j = 0 To rblDThick.Items.Count - 1
                                    If rblDThick.Items(j).Text.Trim = Trim(ds.Tables(2).Rows(int)("thick")) Then
                                        rblDThick.ClearSelection()
                                        rblDThick.SelectedIndex = j
                                        Exit For
                                    End If
                                Next
                        End Select
                    Next
                    int = 0
                    For int = 0 To rblStructure.Items.Count - 1
                        If rblStructure.Items(int).Text.Trim = Trim(ds.Tables(1).Rows(0)("micro")) Then
                            rblStructure.SelectedIndex = int
                            Exit For
                        End If
                    Next

                    int = 0
                    For int = 0 To rblMacro.Items.Count - 1
                        If rblMacro.Items(int).Text.Trim = Trim(ds.Tables(1).Rows(0)("macro")) Then
                            rblMacro.SelectedIndex = int
                            Exit For
                        End If
                    Next

                    int = 0
                    For int = 0 To rblResult.Items.Count - 1
                        If rblResult.Items(int).Text.Trim.Substring(0, 1) = Trim(ds.Tables(1).Rows(0)("result")) Then
                            rblResult.SelectedIndex = int
                            Exit For
                        End If
                    Next
                    Gsize = IIf(IsDBNull(ds.Tables(1).Rows(0)("grain_size")), 0, ds.Tables(1).Rows(0)("grain_size").Split("-"))
                    int = 0
                    i = 0
                    chkGrain.ClearSelection()
                    For int = 0 To chkGrain.Items.Count - 1
                        For i = 0 To Gsize.Length - 1
                            If Gsize(i) = chkGrain.Items(int).Text Then
                                chkGrain.Items(int).Selected = True
                                Exit For
                            End If
                        Next
                    Next
                    txtRemarks.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)("remarks")), 0, ds.Tables(1).Rows(0)("remarks"))
                End If
            Catch exp As Exception
                lblMessage.Text = exp.Message
            Finally
                mywheel = Nothing
                myheat = Nothing
                int = Nothing
                i = Nothing
                j = Nothing
            End Try
        End If
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
    Private Sub txtJoules_c_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtJoules_c.TextChanged
        Dim val, a, b, c As Double
        Try
            val = txtJoules_c.Text
            c = txtJoules_c.Text
            b = txtJoules_b.Text
            a = txtJoules_a.Text
            c = (a + b + c) / 3
            lblAvg.Text = c
        Catch exp As Exception
            lblMessage.Text = "Enter Numbers Only"
        Finally
            If val < 5 Or val > 30 Then
                lblJoules.Text = "Range Should be Between 05 and 30"
            Else
                lblJoules.Text = ""
                Setfocus(rblAThin)
            End If
            val = Nothing
        End Try
    End Sub
    Private Sub txtJoules_b_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtJoules_b.TextChanged
        Dim val, a, b, c As Double
        Try
            val = txtJoules_b.Text
            c = txtJoules_c.Text
            b = txtJoules_b.Text
            a = txtJoules_a.Text
            c = (a + b + c) / 3
            lblAvg.Text = c
        Catch exp As Exception
            lblMessage.Text = "Enter Numbers Only"
        Finally
            If val < 5 Or val > 30 Then
                lblJoules.Text = "Range Should be Between 05 and 30"
            Else
                lblJoules.Text = ""
                Setfocus(txtJoules_c)
            End If
            val = Nothing
        End Try
    End Sub
    Private Sub txtJoules_a_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtJoules_a.TextChanged
        Dim val, a, b, c As Double
        Try
            val = txtJoules_a.Text
            c = txtJoules_c.Text
            b = txtJoules_b.Text
            a = txtJoules_a.Text
            c = (a + b + c) / 3
            lblAvg.Text = c
        Catch exp As Exception
            lblMessage.Text = "Enter Numbers Only"
        Finally
            If val < 5 Or val > 30 Then
                lblJoules.Text = "Range Should be Between 05 and 30"
            Else
                lblJoules.Text = ""
                Setfocus(txtJoules_b)
            End If
            val = Nothing
        End Try
    End Sub
End Class
