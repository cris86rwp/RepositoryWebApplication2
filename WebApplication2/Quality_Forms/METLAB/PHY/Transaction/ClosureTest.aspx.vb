Public Class ClosureTest
    Inherits System.Web.UI.Page
    Protected WithEvents btnClear As System.Web.UI.WebControls.Button
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents txtDate_received As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFinal_guage As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboSupplier_type As System.Web.UI.WebControls.DropDownList
    Protected WithEvents rfvNewNumber As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents btnExit As System.Web.UI.WebControls.Button
    Protected WithEvents lblMode As System.Web.UI.WebControls.Label
    Protected WithEvents lblLab_Number As System.Web.UI.WebControls.Label
    Protected WithEvents txtWheel_Number As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblTestType As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents cboWheel_Number As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtIntial_guage As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblClosure_value As System.Web.UI.WebControls.Label
    Protected WithEvents lblWheelType As System.Web.UI.WebControls.Label
    Protected WithEvents rblResult As System.Web.UI.WebControls.RadioButtonList

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
        If Page.IsPostBack = False Then
            txtDate.Text = Now.Date
            Try
                'lblMode.Text = Request.QueryString("mode").ToLower
                lblMode.Text = "add"
                Select Case lblMode.Text
                    Case "add"
                        txtDate_received.Enabled = False
                        populatewheels()
                    Case "edit"
                        cboWheel_Number.Visible = False
                        txtWheel_Number.Visible = True
                        txtDate_received.Enabled = False
                    Case "view"
                        btnClear.Visible = False
                        btnExit.Visible = False
                        btnSave.Visible = False
                    Case "delete"
                        cboWheel_Number.Visible = False
                        txtWheel_Number.Visible = True
                        txtDate_received.Enabled = False
                        btnSave.Text = "Delete All"
                        lblMessage.Text = "Carefull while using delete all button "
                End Select
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If

    End Sub

    Private Sub populatewheels()
        Dim dt As New DataTable()
        Try
            cboWheel_Number.Items.Clear()
            dt = metLab.tables.GetClosureWheels
            cboWheel_Number.DataSource = dt
            cboWheel_Number.DataTextField = dt.Columns("whlno").ColumnName
            cboWheel_Number.DataValueField = dt.Columns("Lab_number").ColumnName
            cboWheel_Number.DataBind()
            cboWheel_Number.Items.Insert(0, "Select")
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            dt.Dispose()
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        If lblMode.Text = "add" Then
            If btnSave.Text = "Add" Then
                btnSave.Text = "Save"
                lblMessage.Text = ""
                Call clearform()
                Exit Sub
            Else
                If cboWheel_Number.SelectedIndex = 0 Then ' moved from outside if block by svi 12-10-04
                    lblMessage.Text = "Please Select the wheel number"
                    Exit Sub
                End If
                'Declaring parameters and assigning for  table
                Dim wheel, heat As Integer
                Dim arr As Array
                arr = Split(cboWheel_Number.SelectedItem.Text.Trim, "/")
                wheel = CInt(arr(0))
                heat = CInt(arr(1))
                Dim oCmd As New SqlClient.SqlCommand()
                oCmd.Connection = rwfGen.Connection.ConObj
                Dim done As New Boolean()
                Try
                    If lblTestType.Text = "Experimental" Then
                        If rblResult.SelectedItem.Text.StartsWith("N") Or rblResult.SelectedItem.Text.StartsWith("S") Then
                            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                            oCmd.Transaction = oCmd.Connection.BeginTransaction
                            oCmd.CommandText = "insert into mm_closuretest_details(report_date , date_received , heat_number , wheel_number , closure_result , final_guage , intial_guage , closure_value ) " & _
                                    " VALUES (@report_date , @date_received , @heat_number , @wheel_number, @closure_result , 0 , 0 , 0 )"
                            oCmd.Parameters.Add("@report_date", SqlDbType.SmallDateTime, 4).Value = CDate(Trim(txtDate.Text))
                            oCmd.Parameters.Add("@date_received", SqlDbType.SmallDateTime, 4).Value = CDate(Trim(txtDate_received.Text))
                            oCmd.Parameters.Add("@Heat_number", SqlDbType.BigInt, 9).Value = heat
                            oCmd.Parameters.Add("@wheel_number", SqlDbType.BigInt, 9).Value = wheel
                            oCmd.Parameters.Add("@closure_result", SqlDbType.VarChar, 1).Value = rblResult.SelectedItem.Text.Substring(0, 1)
                        Else
                            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                            oCmd.Transaction = oCmd.Connection.BeginTransaction
                            oCmd.CommandText = "insert into mm_closuretest_details(report_date , date_received , final_guage , heat_number , intial_guage , remarks , closure_value , wheel_number , drawing_no , closure_result ) " & _
                                    " VALUES ( @report_date , @date_received , @final_guage , @heat_number , @intial_guage , @remarks , @closure_value , @wheel_number , @drawing_no , @closure_result )"
                            oCmd.Parameters.Add("@report_date", SqlDbType.SmallDateTime, 4).Value = CDate(Trim(txtDate.Text))
                            oCmd.Parameters.Add("@date_received", SqlDbType.SmallDateTime, 4).Value = CDate(Trim(txtDate_received.Text))
                            oCmd.Parameters.Add("@Final_guage", SqlDbType.Float, 9).Value = CSng(txtFinal_guage.Text)
                            oCmd.Parameters.Add("@Heat_number", SqlDbType.BigInt, 9).Value = heat
                            oCmd.Parameters.Add("@Intial_guage", SqlDbType.Float, 9).Value = CSng(txtIntial_guage.Text)
                            oCmd.Parameters.Add("@remarks", SqlDbType.VarChar, 50).Value = txtRemarks.Text
                            oCmd.Parameters.Add("@closure_value", SqlDbType.Float, 9).Value = CSng(lblClosure_value.Text)
                            oCmd.Parameters.Add("@wheel_number", SqlDbType.BigInt, 9).Value = wheel
                            oCmd.Parameters.Add("@drawing_no", SqlDbType.VarChar, 50).Value = Trim(lblWheelType.Text)
                            oCmd.Parameters.Add("@closure_result", SqlDbType.VarChar, 1).Value = rblResult.SelectedItem.Text.Substring(0, 1)
                        End If
                    Else
                        If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                        oCmd.Transaction = oCmd.Connection.BeginTransaction
                        oCmd.CommandText = "insert into mm_closuretest_details(report_date , date_received , final_guage , heat_number , intial_guage , remarks , closure_value , wheel_number , drawing_no , closure_result ) " & _
                                " VALUES ( @report_date , @date_received , @final_guage , @heat_number , @intial_guage , @remarks , @closure_value , @wheel_number , @drawing_no , @closure_result )"
                        oCmd.Parameters.Add("@report_date", SqlDbType.SmallDateTime, 4).Value = CDate(Trim(txtDate.Text))
                        oCmd.Parameters.Add("@date_received", SqlDbType.SmallDateTime, 4).Value = CDate(Trim(txtDate_received.Text))
                        oCmd.Parameters.Add("@Final_guage", SqlDbType.Float, 9).Value = CSng(txtFinal_guage.Text)
                        oCmd.Parameters.Add("@Heat_number", SqlDbType.BigInt, 9).Value = heat
                        oCmd.Parameters.Add("@Intial_guage", SqlDbType.Float, 9).Value = CSng(txtIntial_guage.Text)
                        oCmd.Parameters.Add("@remarks", SqlDbType.VarChar, 50).Value = txtRemarks.Text
                        oCmd.Parameters.Add("@closure_value", SqlDbType.Float, 9).Value = CSng(lblClosure_value.Text)
                        oCmd.Parameters.Add("@wheel_number", SqlDbType.BigInt, 9).Value = wheel
                        oCmd.Parameters.Add("@drawing_no", SqlDbType.VarChar, 50).Value = Trim(lblWheelType.Text)
                        oCmd.Parameters.Add("@closure_result", SqlDbType.VarChar, 1).Value = rblResult.SelectedItem.Text.Substring(0, 1)
                    End If
                    If oCmd.ExecuteNonQuery > 0 Then
                        btnSave.Text = "Add"
                        lblMessage.Text = "Data Added:Press Add to Add one more"
                        Call clearform()
                        done = True
                    End If
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                Finally
                    If done Then
                        oCmd.Transaction.Commit()
                    Else
                        oCmd.Transaction.Rollback()
                    End If
                    If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                    oCmd.Dispose()
                    done = Nothing
                    wheel = Nothing
                    heat = Nothing
                    arr = Nothing
                End Try
            End If 'end of add if
            Try
                populatewheels()
            Catch exp As Exception
                lblMessage.Text &= exp.Message
            End Try
        Else
            If lblMode.Text = "edit" Then
                If btnSave.Text = "edit" Then
                    Call clearform()
                    btnSave.Text = "Save"
                Else
                    Dim wheel, heat As Integer
                    Dim arr As Array
                    arr = Split(txtWheel_Number.Text.Trim, "/")
                    wheel = CInt(arr(0))
                    heat = CInt(arr(1))
                    Dim oCmd As New SqlClient.SqlCommand()
                    oCmd.Connection = rwfGen.Connection.ConObj
                    Dim done As New Boolean()
                    Dim strsql As String
                    Try
                        If lblTestType.Text = "Experimental" Then
                            If rblResult.SelectedItem.Text.StartsWith("N") Or rblResult.SelectedItem.Text.StartsWith("S") Then
                                If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                                oCmd.Transaction = oCmd.Connection.BeginTransaction
                                oCmd.CommandText = "update mm_closuretest_details set report_date = @report_date , date_received = @date_received , closure_result = @closure_result  " & _
                                        " where heat_number = @heat_number and wheel_number = @wheel_number "
                                oCmd.Parameters.Add("@report_date", SqlDbType.SmallDateTime, 4).Value = CDate(Trim(txtDate.Text))
                                oCmd.Parameters.Add("@date_received", SqlDbType.SmallDateTime, 4).Value = CDate(Trim(txtDate_received.Text))
                                oCmd.Parameters.Add("@Heat_number", SqlDbType.BigInt, 9).Value = heat
                                oCmd.Parameters.Add("@wheel_number", SqlDbType.BigInt, 9).Value = wheel
                                oCmd.Parameters.Add("@closure_result", SqlDbType.VarChar, 1).Value = rblResult.SelectedItem.Text.Substring(0, 1)
                            End If
                        Else
                            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
                            oCmd.Transaction = oCmd.Connection.BeginTransaction
                            oCmd.CommandText = " UPDATE mm_closuretest_details SET report_date = @report_date , date_received = @date_received , " & _
                                        " final_guage = @Final_guage , intial_guage = @Intial_guage , closure_result = @closure_result , " & _
                                        " remarks = @remarks , closure_value = @closure_value , drawing_no = @drawing_no WHERE wheel_number = @wheel_number AND heat_number = @Heat_number "
                            oCmd.Parameters.Add("@report_date", SqlDbType.SmallDateTime, 4).Value = CDate(Trim(txtDate.Text))
                            oCmd.Parameters.Add("@date_received", SqlDbType.SmallDateTime, 4).Value = CDate(Trim(txtDate_received.Text))
                            oCmd.Parameters.Add("@Final_guage", SqlDbType.Float, 9).Value = CSng(txtFinal_guage.Text)
                            oCmd.Parameters.Add("@Heat_number", SqlDbType.BigInt, 9).Value = heat
                            oCmd.Parameters.Add("@Intial_guage", SqlDbType.Float, 9).Value = CSng(txtIntial_guage.Text)
                            oCmd.Parameters.Add("@remarks", SqlDbType.VarChar, 50).Value = txtRemarks.Text
                            oCmd.Parameters.Add("@closure_value", SqlDbType.Float, 9).Value = CSng(lblClosure_value.Text)
                            oCmd.Parameters.Add("@wheel_number", SqlDbType.BigInt, 9).Value = wheel
                            oCmd.Parameters.Add("@drawing_no", SqlDbType.VarChar, 50).Value = Trim(lblWheelType.Text)
                            oCmd.Parameters.Add("@closure_result", SqlDbType.VarChar, 1).Value = rblResult.SelectedItem.Text.Substring(0, 1)
                        End If
                        If ocmd.ExecuteNonQuery > 0 Then
                            lblMessage.Text = "Data Updated Sucessfully"
                            btnSave.Text = "edit"
                            Call clearform()
                            done = True
                        End If
                    Catch exp As Exception
                        strsql = exp.StackTrace
                        lblMessage.Text = "Line : " & Mid(strsql, InStr(strsql, "line") + 5) & " Message : " + exp.Message
                    Finally
                        If done Then
                            oCmd.Transaction.Commit()
                        Else
                            oCmd.Transaction.Rollback()
                        End If
                        If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                        oCmd.Dispose()
                        done = Nothing
                        wheel = Nothing
                        heat = Nothing
                        arr = Nothing
                    End Try
                End If
            End If
        End If
        If lblMode.Text = "delete" Then
            If btnSave.Text = "Delete All" Then
                lblMessage.Text = "*************You Are Not Authorized To Delete*************"
                btnSave.Enabled = False
            End If
        End If
    End Sub

    Private Sub clearform()
        txtDate_received.Text = ""
        txtFinal_guage.Text = ""
        txtIntial_guage.Text = ""
        txtRemarks.Text = ""
        txtDate.Text = ""
        lblClosure_value.Text = ""
        cboWheel_Number.SelectedIndex = 0
        lblWheelType.Text = ""
        lblTestType.Text = ""
        lblLab_Number.Text = ""
    End Sub

    Private Sub fillClosureData(ByVal wheel As String)
        Dim dt As New DataTable()
        Try
            dt = metLab.tables.fillClosureData(ReturnWheel(wheel.Trim), ReturnHeat(wheel.Trim))
            txtDate_received.Text = dt.Rows(0)("date_received")
            txtFinal_guage.Text = dt.Rows(0)("final_guage")
            txtIntial_guage.Text = dt.Rows(0)("intial_guage")
            txtRemarks.Text = dt.Rows(0)("remarks")
            txtDate.Text = dt.Rows(0)("report_date")
            lblClosure_value.Text = dt.Rows(0)("closure_value")
            lblWheelType.Text = dt.Rows(0)("drawing_no")
            lblLab_Number.Text = dt.Rows(0)("lab_number")
            lblTestType.Text = dt.Rows(0)("test_type")
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            dt.Dispose()
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

    Private Sub txtFinal_guage_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFinal_guage.TextChanged
        lblMessage.Text = ""
        If Me.txtIntial_guage.Text <> "" And Me.txtFinal_guage.Text <> "" Then
            Dim intintial_guage, intfinal_guage, intclosure_value As Double
            intintial_guage = CDbl(Trim(txtIntial_guage.Text))
            intfinal_guage = CDbl(Trim(txtFinal_guage.Text))
            intclosure_value = CDbl(intintial_guage - intfinal_guage)
            lblClosure_value.Text = System.Math.Round(intclosure_value, 2)
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("http://localhost:/mss/selectModule.aspx")
    End Sub

    Private Sub cboWheel_Number_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboWheel_Number.SelectedIndexChanged
        Dim wheel, heat As Integer
        Dim arr As Array
        arr = Split(cboWheel_Number.SelectedItem.Text.Trim, "/")
        wheel = CInt(arr(0))
        heat = CInt(arr(1))
        Dim dt As New DataTable()
        Try
            dt = metLab.tables.GetClosureData(wheel, heat)
            txtDate_received.Text = dt.Rows(0)("sent_date")
            lblWheelType.Text = dt.Rows(0)("wheel_type")
            lblLab_Number.Text = IIf(cboWheel_Number.SelectedItem.Value = "Select", "", cboWheel_Number.SelectedItem.Value)
            lblTestType.Text = dt.Rows(0)("test_type")
            If lblMode.Text = "edit" Or lblMode.Text = "delete" Then
                fillClosureData(CStr(txtWheel_Number.Text))
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
            arr = Nothing
            wheel = Nothing
            heat = Nothing
        End Try
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        clearform()
    End Sub

    Private Sub txtWheel_Number_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWheel_Number.TextChanged
        lblMessage.Text = ""
        Try
            fillClosureData(CStr(txtWheel_Number.Text))
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtIntial_guage_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIntial_guage.TextChanged
        lblMessage.Text = ""
        lblClosure_value.Text = ""
    End Sub
End Class
