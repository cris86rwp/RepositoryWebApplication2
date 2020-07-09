Public Class PLNumersforBreakDownMemo
    Inherits System.Web.UI.Page
    Protected WithEvents btnPls As System.Web.UI.WebControls.Button
    Protected WithEvents txtpl_qty As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPLNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboSpares As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtDescription As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboFaliure As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblMessage2 As System.Web.UI.WebControls.Label
    Protected WithEvents txtStaff As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblTotal_time As System.Web.UI.WebControls.Label
    Protected WithEvents txtBDnToTime As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBDnFromTime As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBDnToDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBDnFromDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblDesc As System.Web.UI.WebControls.Label
    Protected WithEvents lblBreakDownDetail As System.Web.UI.WebControls.Label
    Protected WithEvents cboMemoNumber As System.Web.UI.WebControls.DropDownList
    Protected WithEvents RequiredFieldValidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtOperator As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMachineCode As System.Web.UI.WebControls.Label
    Protected WithEvents lblMaintenance_group As System.Web.UI.WebControls.Label
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblDepartment_code As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblMode As System.Web.UI.WebControls.Label
    'Dim strsql As String
    'Dim myBDnFromDateTime As String
    'Dim myBDnToDateTime As String
    'Dim myObsFromDateTime As String
    'Dim myObsToDateTime As String
    'Dim strmode, app, strCmd As String
    Protected WithEvents lblFailureNature As System.Web.UI.WebControls.Label
    Protected WithEvents lblSubAssembly As System.Web.UI.WebControls.Label
    Protected WithEvents lblGroup As System.Web.UI.WebControls.Label
    Protected WithEvents lblUserID As System.Web.UI.WebControls.Label
    Protected WithEvents ddlSubAssembly As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlShopCode As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnExit As System.Web.UI.WebControls.Button
    Protected WithEvents btnClear As System.Web.UI.WebControls.Button
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents grdSpares As System.Web.UI.WebControls.DataGrid
    Protected WithEvents ddlBDtype As System.Web.UI.WebControls.DropDownList
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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            ''+++++++++++++
            'lblUserID.Text = "078844"
            'Session("Group") = "MA2"
            'lblMaintenance_group.Text = "MA2"
            'strmode = "edit"
            ''+++++++++++++
            'Session("UserID") = "077243"
            'Session("group") = "MW1"

            lblGroup.Text = ""
            lblUserID.Text = Session("UserID")
            lblGroup.Visible = False
            lblUserID.Visible = False
            lblMessage.Text = ""
            lblMessage2.Text = ""
            lblDepartment_code.Text = "M"
            Dim Done As Boolean
            Dim GRP As String
            Try
                lblMode.Text = Request.QueryString("mode")
                If Trim(Session("Group")) = "RTSHOP" Then
                    lblMaintenance_group.Text = "MRT"
                Else
                    lblMaintenance_group.Text = Session("Group")
                End If
                GRP = lblMaintenance_group.Text
                lblGroup.Text = lblMaintenance_group.Text
                lblDepartment_code.Text = GRP.Substring(0, 1)
                lblMaintenance_group.Text = GRP.Substring(1)
                Done = True
            Catch exp As Exception
                lblMessage.Text = " Login Failed ! "
                lblMessage2.Text = " Login Failed ! "
            End Try
            If Done = False Then
                Exit Sub
            Else
                Done = False
                Try
                    PopulateShopCode()
                    get_Spares()
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                End Try
            End If
        End If
    End Sub

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


    Private Sub FillDDLs(ByVal dt As DataTable, ByVal ddl As DropDownList)
        ddl.DataSource = dt.DefaultView
        ddl.DataTextField = dt.Columns(1).ColumnName
        ddl.DataValueField = dt.Columns(0).ColumnName
        ddl.DataBind()
    End Sub
    Private Sub FillDDLShopCode()
        Dim dt As New DataTable()
        Try
            dt = Maintenance.tables.ShopCode(lblMaintenance_group.Text.Trim)
            FillDDLs(dt, ddlShopCode)
        Catch exp As Exception
            Throw New Exception("InValid Filling of DDLs")
        Finally
            dt.Dispose()
        End Try
    End Sub
    Private Sub FillDDLFaliure()
        Dim dt As New DataTable()
        Try
            dt = Maintenance.tables.Failure()
            FillDDLs(dt, cboFaliure)
        Catch exp As Exception
            Throw New Exception("InValid Filling of DDLs")
        Finally
            dt.Dispose()
        End Try
    End Sub
    Private Sub FillDDLBDtype()
        Dim dt As New DataTable()
        Try
            dt = Maintenance.tables.CodeType()
            FillDDLs(dt, ddlBDtype)
        Catch exp As Exception
            Throw New Exception("InValid Filling of DDLs")
        Finally
            dt.Dispose()
        End Try
    End Sub

    Private Sub PopulateShopCode()
        FillDDLShopCode()
        ddlShopCode.Items.Insert(0, "select")
        FillDDLFaliure()
        FillDDLBDtype()
    End Sub
    Private Sub ddlShopCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlShopCode.SelectedIndexChanged
        lblMessage.Text = ""
        lblMessage2.Text = ""
        PopulateMemoNumber()
    End Sub

    Private Sub PopulateMemoNumber()
        Dim dt As Date
        Dim done As Boolean
        Try
            dt = CDate(txtDate.Text)
            done = True
        Catch
            lblMessage.Text = "Enter BreakDown date in 'dd/MM/yyyy' Format"
            txtDate.Text = ""
        End Try
        If done Then
            Dim dtMemo As DataTable
            Try
                dtMemo = Maintenance.tables.MemoNumber(Trim(ddlShopCode.SelectedItem.Value), CDate(txtDate.Text), ddlBDtype.SelectedItem.Value, lblGroup.Text)
                FillDDLs(dtMemo, cboMemoNumber)
                cboMemoNumber.Items.Insert(0, "select")
            Catch exp As Exception
                lblMessage.Text = exp.Message
            Finally
                dtMemo.Dispose()
            End Try
        End If
    End Sub

    Private Sub cboMemoNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMemoNumber.SelectedIndexChanged
        lblMessage.Text = ""
        Clear()
        If cboMemoNumber.SelectedIndex = 0 Then
            Exit Sub
        Else
            Try
                If Maintenance.tables.CheckMemo(Trim(ddlShopCode.SelectedItem.Value), Trim(cboMemoNumber.SelectedItem.Value)) = 0 Then
                    lblMessage.Text = "DATA DOES NOT EXISTS ! USE EDIT MODE TO ENTER DATA !"
                    Exit Sub
                Else
                    PopulateText()
                    get_Spares()
                End If
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub PopulateText()
        Dim myBDnFromDateTime As String
        Dim myBDnToDateTime As String
        Dim ds As New DataSet()
        Try
            ds = Maintenance.tables.MemoNumberDetails(Trim(ddlShopCode.SelectedItem.Value), CDate(Trim(txtDate.Text)), Trim(cboMemoNumber.SelectedItem.Value), ddlBDtype.SelectedItem.Value)
            lblDesc.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("remarks")), "", ds.Tables(0).Rows(0)("remarks"))
            myBDnFromDateTime = IIf(IsDBNull(ds.Tables(0).Rows(0)("breakdown_from_time")), "", ds.Tables(0).Rows(0)("breakdown_from_time"))
            myBDnToDateTime = IIf(IsDBNull(ds.Tables(0).Rows(0)("breakdown_to_time")), "", ds.Tables(0).Rows(0)("breakdown_to_time"))
            If myBDnFromDateTime <> "" Then
                Dim myBdnFromArray As Array = Split(myBDnFromDateTime)
                txtBDnFromDate.Text = Trim(myBdnFromArray(0))
                If myBdnFromArray.Length > 1 Then
                    txtBDnFromTime.Text = Trim(myBdnFromArray(1))
                End If
            End If

            If myBDnToDateTime <> "" Then
                Dim myBdnToArray As Array = Split(myBDnToDateTime)
                txtBDnToDate.Text = Trim(myBdnToArray(0))
                If myBdnToArray.Length > 1 Then
                    txtBDnToTime.Text = Trim(myBdnToArray(1))
                End If
            End If
            txtOperator.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("operator")), "", ds.Tables(0).Rows(0)("operator"))
            lblGroup.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("maintenance_group")), "", ds.Tables(0).Rows(0)("maintenance_group"))
            lblMachineCode.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("machine_code")), "", ds.Tables(0).Rows(0)("machine_code"))
            ddlSubAssembly.Items.Clear()
            Dim group As String
            Dim dt As DataTable
            group = lblDepartment_code.Text + lblMaintenance_group.Text
            dt = Maintenance.tables.SubAssembly(lblMachineCode.Text.Trim, group)
            ddlSubAssembly.DataSource = dt.DefaultView
            ddlSubAssembly.DataTextField = dt.Columns(1).ColumnName
            ddlSubAssembly.DataTextField = dt.Columns(0).ColumnName
            ddlSubAssembly.DataBind()
            ddlSubAssembly.Items.Insert(0, "Select")
            If ds.Tables(1).Rows.Count > 0 Then
                lblBreakDownDetail.Text = Trim(IIf(IsDBNull(ds.Tables(1).Rows(0)("BreakDownDetail")), "", ds.Tables(1).Rows(0)("BreakDownDetail")))
            End If
            If ds.Tables(2).Rows.Count > 0 Then
                txtStaff.Text = IIf(IsDBNull(ds.Tables(2).Rows(0)("staff")), "", ds.Tables(2).Rows(0)("staff"))
                lblFailureNature.Text = IIf(IsDBNull(ds.Tables(2).Rows(0)("failure_nature")), "", ds.Tables(2).Rows(0)("failure_nature"))
                lblSubAssembly.Text = IIf(IsDBNull(ds.Tables(2).Rows(0)("sub_assembly")), "", ds.Tables(2).Rows(0)("sub_assembly"))
                txtDescription.Text = IIf(IsDBNull(ds.Tables(2).Rows(0)("work_done")), "", ds.Tables(2).Rows(0)("work_done"))
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub TimeDifference()
        Dim mydatetime1 As String
        Dim mydatetime2 As String
        Dim myyear1 As Integer
        Dim myyear2 As Integer
        Dim mymonth1 As Integer
        Dim mymonth2 As Integer
        Dim myday1 As Integer
        Dim myday2 As Integer
        Dim myhour1 As Integer
        Dim myhour2 As Integer
        Dim mymin1 As Integer
        Dim mymin2 As Integer
        Dim mysec1, mysec2 As Integer
        myyear1 = Year(Trim(mydatetime1))
        myyear2 = Year(Trim(mydatetime2))
        mymonth1 = Month(Trim(mydatetime1))
        mymonth2 = Month(Trim(mydatetime2))
        myday1 = Day(Trim(mydatetime1))
        myday2 = Day(Trim(mydatetime2))
        myhour1 = Hour(Trim(mydatetime1))
        myhour2 = Hour(Trim(mydatetime2))
        mymin1 = Minute(Trim(mydatetime1))
        mymin2 = Minute(Trim(mydatetime2))
        mysec1 = mysec2 = 29

        Dim date1 As New System.DateTime(myyear1 & "," & mymonth1 & "," & myday1 & "," & myhour1 & "," & mymin1 & "," & mysec1)
        Dim date2 As New System.DateTime(myyear2 & "," & mymonth2 & "," & myday2 & "," & myhour2 & "," & mymin2 & "," & mysec2)

        Dim mydatediff As Long = DateDiff(DateInterval.Second, date1, date2)
        Dim mysec As Long
        Dim mymin, myminfraction As Long
        Dim myhour, myhourfraction As Long
        Dim myday, mydayfraction As Long
        If mydatediff >= (3600 * 24) Then
            myday = mydatediff / (3600 * 24)
            mydayfraction = mydatediff Mod (3600 * 24)
            If mydayfraction >= 3600 Then
                myhour = mydayfraction / 3600
            ElseIf mydayfraction >= 60 Then
                mymin = mydayfraction / 60
            Else
                mysec = mydayfraction
            End If
            lblTotal_time.Text = myday & " days, " & myhour & " hrs, " & mymin & " mins, " & mysec & " secs"
        ElseIf mydatediff >= 3600 Then
            myhour = mydatediff / 3600
            myhourfraction = mydatediff Mod 3600
            If myhourfraction >= 60 Then
                mymin = myhourfraction / 60
                mysec = myhourfraction Mod 60
            Else
                mysec = myhourfraction
            End If
            lblTotal_time.Text = myhour & " hrs, " & mymin & " mins, " & mysec & " secs"
        ElseIf mydatediff >= 60 Then
            mymin = mydatediff / 60
            mysec = mydatediff Mod 60
            lblTotal_time.Text = mymin & " mins " & " and " & mysec & " secs"
        Else
            mysec = mydatediff
            lblTotal_time.Text = mysec & " secs"
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim Done As Boolean
        Dim oBrk As New Maintenance.Breakdown()
        Try
            Dim cnt As Int16
            Dim dt As New DataTable()
            Dim dr As DataRow
            Try
                dt.TableName = "spares"
                dt.Columns.Add("PlNumber")
                dt.Columns.Add("Quantity")
                dt.Columns.Add("ReplacedQuantity")
                If grdSpares.Items.Count > 0 Then
                    For cnt = 0 To grdSpares.Items.Count - 1
                        dr = dt.NewRow
                        dr("PlNumber") = grdSpares.Items(cnt).Cells(0).Text
                        dr("Quantity") = grdSpares.Items(cnt).Cells(3).Text
                        dr("ReplacedQuantity") = grdSpares.Items(cnt).Cells(3).Text
                        dt.Rows.Add(dr)
                    Next
                End If
                oBrk.SparesList = dt
                Done = True
            Catch exp As Exception
                lblMessage.Text = exp.Message
            Finally
                dt.Dispose()
                dr = Nothing
            End Try
            If Done = True Then
                Done = False
            Else
                oBrk = Nothing
                Exit Sub
            End If

            oBrk.Machinery.GroupCode = lblGroup.Text.Trim
            oBrk.MemoNumber = cboMemoNumber.SelectedItem.Value
            oBrk.SparesNumber = cboMemoNumber.SelectedItem.Value
            oBrk.MachineCode = lblMachineCode.Text
            oBrk.ShopCode = ddlShopCode.SelectedItem.Value
            oBrk.Staff = txtStaff.Text.Trim
            oBrk.FailureNature = cboFaliure.SelectedItem.Text
            oBrk.SubAssembly = IIf((ddlSubAssembly.SelectedItem.Value.ToLower = "select"), "", ddlSubAssembly.SelectedItem.Value)
            oBrk.WorkDone = txtDescription.Text.Trim
            oBrk.Group = lblMaintenance_group.Text
            oBrk.Operator1 = lblUserID.Text
            oBrk.BreakdownType = ddlBDtype.SelectedItem.Value
            If oBrk.SaveWorkDoneDetails(oBrk.MemoNumber) Then
                Done = True
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
            oBrk = Nothing

        End Try
        If Done Then
            lblMessage.Text = "Record Updated..."
            lblMessage2.Text = "Record Updated..."
            Clear()
            ClearDetails()
        Else
            lblMessage.Text = "Record Updatedtion Failed ! "
            lblMessage2.Text = "Record Updatedtion Failed ! "
        End If
    End Sub

    Private Sub Clear()
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim cnt As Int16
        dt.TableName = "spares"
        dt.Columns.Add("Pl Number")
        dt.Columns.Add("Description")
        dt.Columns.Add("Unit")
        dt.Columns.Add("Quantity")
        grdSpares.DataSource = dt
        grdSpares.DataBind()
        cboSpares.Items.Clear()
    End Sub

    Private Sub ClearSpares()
        txtPLNumber.Text = ""
        txtpl_qty.Text = ""
    End Sub
    Private Sub ClearDetails()
        txtDescription.Text = ""
        ddlBDtype.SelectedIndex = 0
        cboMemoNumber.SelectedIndex = 0
        lblMachineCode.Text = ""
        ddlShopCode.SelectedIndex = 0
        txtStaff.Text = ""
        cboFaliure.SelectedIndex = 0
        ddlSubAssembly.SelectedIndex = 0
        cboSpares.SelectedIndex = 0
        txtDescription.Text = ""
        lblMachineCode.Text = ""
        txtBDnFromDate.Text = ""
        txtBDnFromTime.Text = ""
        txtBDnToDate.Text = ""
        txtBDnToTime.Text = ""
    End Sub

    Private Sub PopulateDatatable()
        Dim dt As New DataTable()
        Dim dtPl As New DataTable()
        Dim dr As DataRow
        Dim cnt As Int16
        Dim desc, unit As String
        Try
            dt.TableName = "spares"
            dt.Columns.Add("Pl Number")
            dt.Columns.Add("Description")
            dt.Columns.Add("Unit")
            dt.Columns.Add("Quantity")
            If grdSpares.Items.Count > 0 Then
                For cnt = 0 To grdSpares.Items.Count - 1
                    If grdSpares.Items(cnt).Cells(0).Text.Trim <> Trim(txtPLNumber.Text) Then
                        dr = dt.NewRow
                        dr("Pl Number") = grdSpares.Items(cnt).Cells(0).Text
                        dr("Description") = grdSpares.Items(cnt).Cells(1).Text
                        dr("Unit") = grdSpares.Items(cnt).Cells(2).Text
                        dr("Quantity") = grdSpares.Items(cnt).Cells(3).Text
                        dt.Rows.Add(dr)
                    End If
                Next
            End If

            dtPl = Maintenance.tables.PLDetails(Trim(txtPLNumber.Text))

            If Trim(IIf(IsDBNull(dtPl.Rows(0)("pl_number")), 0, dtPl.Rows(0)("pl_number"))) = 0 Then
                lblMessage.Text = "Pl Number do not exists..."
                Exit Sub
            Else
                desc = Trim(IIf(IsDBNull(dtPl.Rows(0)("PlShortName")), "", dtPl.Rows(0)("PlShortName")))
                unit = Trim(IIf(IsDBNull(dtPl.Rows(0)("PlUnitName")), "", dtPl.Rows(0)("PlUnitName")))
            End If

            dr = dt.NewRow
            dr("Pl Number") = txtPLNumber.Text
            dr("Description") = Trim(desc)
            dr("Unit") = Trim(unit)
            dr("Quantity") = txtpl_qty.Text
            dt.Rows.Add(dr)
            grdSpares.DataSource = dt
            grdSpares.DataBind()
            txtPLNumber.Text = ""
            txtpl_qty.Text = ""
            cboSpares.SelectedIndex = 0
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
            dtPl.Dispose()
        End Try
    End Sub

    Private Sub btnPls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPls.Click
        PopulateDatatable()
    End Sub

    Sub get_Spares()
        Dim group As String
        Dim dt As DataTable
        group = lblDepartment_code.Text + lblMaintenance_group.Text
        Try
            cboSpares.Items.Clear()
            If ddlSubAssembly.SelectedIndex < 1 Then
                dt = Maintenance.tables.Spares(group, lblMachineCode.Text)
            Else
                dt = Maintenance.tables.Spares(group, lblMachineCode.Text, ddlSubAssembly.SelectedItem.Value)
            End If
            FillDDLs(dt, cboSpares)
            cboSpares.Items.Insert(0, "select")
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
        End Try
    End Sub

    Private Sub cboSpares_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSpares.SelectedIndexChanged
        lblMessage.Text = ""
        lblMessage2.Text = ""
        txtpl_qty.Text = ""
        Dim group As String
        Dim dt As DataTable
        group = lblDepartment_code.Text + lblMaintenance_group.Text
        If cboSpares.SelectedIndex = 0 Then
            txtPLNumber.Text = ""
            Exit Sub
        End If
        Try
            txtPLNumber.Text = cboSpares.SelectedItem.Value
            If ddlSubAssembly.SelectedItem.Text = "Select" Then
                dt = Maintenance.tables.Spares(group, lblMachineCode.Text, , txtPLNumber.Text.Trim)
            Else
                dt = Maintenance.tables.Spares(group, lblMachineCode.Text, ddlSubAssembly.SelectedItem.Value.Trim, txtPLNumber.Text.Trim)
            End If

            If Not IsDBNull(dt.Rows(0)("qtyreqd")) Then
                txtpl_qty.Text = dt.Rows(0)("qtyreqd")
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
        End Try
    End Sub

    Private Sub ddlBDtype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlBDtype.SelectedIndexChanged
        lblMessage.Text = ""
        lblMessage2.Text = ""
        PopulateMemoNumber()
    End Sub

    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        Dim dt As Date
        lblMessage.Text = ""
        Try
            dt = CDate(txtDate.Text)
            txtDate.Text = dt
        Catch
            lblMessage.Text = "Enter BreakDown date in 'dd/MM/yyyy' Format"
            txtDate.Text = ""
        Finally
            dt = Nothing
        End Try
    End Sub

    Private Sub ddlSubAssembly_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlSubAssembly.SelectedIndexChanged
        txtPLNumber.Text = ""
        txtpl_qty.Text = ""
        get_Spares()
    End Sub
End Class


