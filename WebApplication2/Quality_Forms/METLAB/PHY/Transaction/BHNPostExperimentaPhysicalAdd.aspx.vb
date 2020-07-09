Public Class BHNPostExperimentaPhysicalAdd
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
    Protected WithEvents lblWheel As System.Web.UI.WebControls.Label
    Protected WithEvents lblCastdate As System.Web.UI.WebControls.Label
    Protected WithEvents lblReceiveddate As System.Web.UI.WebControls.Label
    Protected WithEvents lblWheelClass As System.Web.UI.WebControls.Label
    Protected WithEvents lblHeatrange As System.Web.UI.WebControls.Label
    Protected WithEvents lblTestType As System.Web.UI.WebControls.Label
    Protected WithEvents lblWheeltype As System.Web.UI.WebControls.Label
    Protected WithEvents lblPourorder As System.Web.UI.WebControls.Label
    Protected WithEvents lblCopelife As System.Web.UI.WebControls.Label
    Protected WithEvents lblDraglife As System.Web.UI.WebControls.Label
    Protected WithEvents lblTubetemp As System.Web.UI.WebControls.Label
    Protected WithEvents lblJoules As System.Web.UI.WebControls.Label
    Protected WithEvents lblAvg As System.Web.UI.WebControls.Label
    Protected WithEvents txtRedn_plate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRedn_rim As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtJoules_c As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtKlengation_plate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtKlengation_rim As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtJoules_b As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtYS_plate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtYS_rim As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtJoules_a As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtUTS_plate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtUTS_rim As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblFinaltemp As System.Web.UI.WebControls.Label
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
            ddlLabNumber.DataSource = metLab.tables.GetExpPhyLabNumber
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
        lblAvg.Text = ""
        lblCastdate.Text = ""
        lblClosure.Text = ""
        ini.Text = ""
        fin.Text = ""
        lblCopelife.Text = ""
        lblDraglife.Text = ""
        lblFinaltemp.Text = ""
        lblHeatrange.Text = ""
        lblJoules.Text = ""
        lblLabNumber.Text = ""
        lblPourorder.Text = ""
        lblReceiveddate.Text = ""
        lblTubetemp.Text = ""
        lblWheeltype.Text = ""
        lblWheelClass.Text = ""
        lblTestType.Text = ""

        radClosure.SelectedIndex = 0

        txtJoules_a.Text = ""
        txtJoules_b.Text = ""
        txtJoules_c.Text = ""
        txtKlengation_plate.Text = ""
        txtKlengation_rim.Text = ""
        txtRedn_plate.Text = ""
        txtRedn_rim.Text = ""
        txtUTS_plate.Text = ""
        txtUTS_rim.Text = ""
        txtYS_plate.Text = ""
        txtYS_rim.Text = ""
        viewstate("GrainSize") = Nothing
        viewstate("Inclusion") = Nothing
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
                If Val(lblClosure.Text.Trim) < 1 Then
                    radClosure.SelectedIndex = 0
                Else
                    radClosure.SelectedIndex = 1
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
            End If
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
            oWhl.WheelNumber = ReturnWheel(ddlLabNumber.SelectedItem.Text.Trim)
            oWhl.HeatNumber = ReturnHeat(ddlLabNumber.SelectedItem.Text.Trim)
            oWhl.LabNumber = ddlLabNumber.SelectedItem.Value.Trim
            oWhl.grain_size = CType(viewstate("GrainSize"), String)
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
            If oWhl.saveExpWheels(oWhl.LabNumber, lblMode.Text.Trim, "Physical") Then
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
    Private Sub txtUTS_rim_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUTS_rim.TextChanged
        Setfocus(txtYS_rim)
    End Sub

    Private Sub txtYS_rim_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtYS_rim.TextChanged
        Setfocus(txtKlengation_rim)
    End Sub

    Private Sub txtKlengation_rim_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKlengation_rim.TextChanged
        Setfocus(txtRedn_rim)
    End Sub

    Private Sub txtRedn_rim_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRedn_rim.TextChanged
        Setfocus(txtUTS_plate)
    End Sub

    Private Sub txtUTS_plate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUTS_plate.TextChanged
        Setfocus(txtYS_plate)
    End Sub

    Private Sub txtYS_plate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtYS_plate.TextChanged
        Setfocus(txtKlengation_plate)
    End Sub

    Private Sub txtKlengation_plate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKlengation_plate.TextChanged
        Setfocus(txtRedn_plate)
    End Sub

    Private Sub txtRedn_plate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRedn_plate.TextChanged
        Setfocus(txtJoules_a)
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
            a = Nothing
            b = Nothing
            c = Nothing
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
            a = Nothing
            b = Nothing
            c = Nothing
        End Try
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
            End If
            val = Nothing
            a = Nothing
            b = Nothing
            c = Nothing
        End Try
    End Sub
End Class
