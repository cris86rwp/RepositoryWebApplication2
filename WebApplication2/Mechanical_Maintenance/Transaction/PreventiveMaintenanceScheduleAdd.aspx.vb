Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports System.DateTime
Public Class PreventiveMaintenanceScheduleAdd
    Inherits System.Web.UI.Page

    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents lblMode As System.Web.UI.WebControls.Label
    Protected WithEvents txtFrom As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTo As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnClear As System.Web.UI.WebControls.Button
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboMachine As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboAssembly As System.Web.UI.WebControls.DropDownList
    Protected WithEvents radType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents lblDept As System.Web.UI.WebControls.Label
    Protected WithEvents lblUserID As System.Web.UI.WebControls.Label
    Protected WithEvents lblGroup As System.Web.UI.WebControls.Label
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents lblMGroup As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage1 As System.Web.UI.WebControls.Label
    'Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid

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
    Dim i As String

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim grp As String
        Dim shop As String
        lblUserID.Visible = False
        lblGroup.Visible = False
        lblMode.Text = Request.QueryString("mode")
        lblUserID.Text = Session("UserID")
        'lblMode.Text = "edit"
        lblMode.Text = "add"
        'Session("group") = "EW3"
        'lblUserID.Text = "111111"
        'If Session("group") = "RTSHOP" Then
        '    Session("group") = "MRT"
        'End If
        grp = Session("group")
        shop = rblshopCode.SelectedItem.Text.Trim()

        lblDept.Text = grp.Substring(0)
        lblDept.Visible = False
        lblMGroup.Text = grp.Substring(1)
        lblUserID.Text = Session("UserID")
        lblGroup.Text = Session("group")
        If Not Page.IsPostBack Then
            Try
                If lblMode.Text = "add" Then
                    lblMode.Text = "add"
                    txtFrom.Visible = True
                    ' cboWorkOrderNo.Visible = False
                    txtFrom.Text = Date.Today
                    txtTo.Text = Today.AddDays(7)
                    GetGridData()

                End If
                PopulateMachineCode(lblMode.Text, shop, grp)
                PopulateSubAssembly()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If

    End Sub

    Protected Sub dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())
    End Sub
    'End Sub
    Private Sub GetGridData()
        Dim objCmd As SqlCommand
        Dim objDr As SqlDataReader
        Dim con As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User Id=sa;Password=sadev123")

        If con.State = ConnectionState.Closed Then
            con.Open()
        Else
            con.Close()
            con.Open()
        End If
        Dim strSql As String
        Try
            Dim strArg As String

            strArg = "select * from ms_preventiveMaintenanceDetails  where ShopCode='" & rblshopCode.SelectedItem.Value & "'"
            objCmd = New SqlCommand(strArg, con)

            objDr = objCmd.ExecuteReader()
            Dim arr() As String
            datagrid1.DataSource = arr
            datagrid1.DataBind()
            datagrid1.DataSource = objDr
            datagrid1.DataBind()
        Catch exp As SqlException
            strSql = exp.StackTrace
            lblMessage.Text = "Line :  " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message

        Catch exp As Exception
            strSql = exp.StackTrace
            lblMessage.Text = "Line  " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message
        End Try

        con.Close()

    End Sub

    Protected Sub DataGrid1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles datagrid1.SelectedIndexChanged
        ' Dim i As String
        datagrid1.SelectedIndex = i
        rblshopCode.SelectedItem.Value = datagrid1.Items(i).Cells(1).Text
        txtFrom.Text = datagrid1.Items(i).Cells(2).Text
        txtRemarks.Text = datagrid1.Items(i).Cells(4).Text
        txtTo.Text = datagrid1.Items(i).Cells(3).Text
        cboMachine.SelectedItem.Value = Trim(datagrid1.Items(i).Cells(6).Text)
        radType.Text = datagrid1.Items(i).Cells(5).Text


    End Sub

    Private Sub DataGrid1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles datagrid1.ItemCommand

        i = e.Item.ItemIndex()
    End Sub
    Private Sub PopulateMachineCode(ByVal mode As String, ByVal shop As String, ByVal Group As String)
        cboMachine.Items.Clear()
        Dim dt As DataTable
        Try
            dt = Maintenance.tables.PMSMachineCode(mode, rblshopCode.SelectedItem.Text.Trim, CDate(txtFrom.Text), lblGroup.Text.Trim)
            cboMachine.DataSource = dt.DefaultView
            cboMachine.DataValueField = dt.Columns("machine_code").ColumnName
            cboMachine.DataTextField = dt.Columns("Description").ColumnName
            cboMachine.DataBind()
            cboMachine.Items.Insert(0, "Select")
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
        End Try
    End Sub


    Private Sub FillDDLs(ByVal dt As DataTable, ByVal ddl As DropDownList)
        ddl.DataSource = dt.DefaultView
        ddl.DataTextField = dt.Columns(1).ColumnName
        ddl.DataValueField = dt.Columns(0).ColumnName
        ddl.DataBind()
    End Sub



    Private Sub PopulateSubAssembly()
        Dim dt As DataTable
        Dim grp As String
        grp = lblDept.Text + lblMGroup.Text
        Try
            dt = Maintenance.tables.GetPMSSubAssemblyList(lblMode.Text, cboMachine.SelectedItem.Value, grp, rblshopCode.SelectedItem.Text.Trim)
            cboAssembly.DataSource = dt
            cboAssembly.DataTextField = dt.Columns("description").ColumnName
            cboAssembly.DataValueField = dt.Columns("code").ColumnName
            cboAssembly.DataBind()

            cboAssembly.Items.Insert(0, "Select")
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
        End Try
    End Sub

    Private Sub ClearDetails()
        txtFrom.Text = ""
        '  txtFrom_time.Text = ""
        txtTo.Text = ""
        'txtTo_time.Text = ""
    End Sub



    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        lblMessage1.Text = ""
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj

        Dim maintenance_group As String = lblGroup.Text
        'Dim txt_time As Date = Format(CDate(txttime.Text))
        Dim maintenance_type As String = radType.SelectedItem.Value
        Dim machine_code As String = cboMachine.SelectedItem.Value
        Dim PM_Done_Date As DateTime = CDate(txtFrom.Text)
        Dim Next_Due_date As DateTime = CDate(txtTo.Text)
        Dim sub_assembly As String = cboAssembly.SelectedItem.Value
        Dim remarks As String = txtRemarks.Text
        Dim ShopCode As String = rblshopCode.SelectedItem.Value
        cmd.Parameters.Add("@SlNo", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output

        If cboMachine.SelectedItem.Text.ToLower = "select" Then
            lblMessage.Text = "Please select Machine ID to save data !"
            lblMessage1.Text = "Please select Machine ID to save data !"

        Else
            Dim done1 As Boolean
            'Try

            Try

                cmd.Connection.Open()
                cmd.CommandText = "select @SlNo=SlNo from ms_preventiveMaintenanceDetails where machine_code=@machine_code and ShopCode=@ShopCode "
                '  cmd.ExecuteNonQuery()
                If IIf(IsDBNull(cmd.Parameters("@SlNo").Value), 0, cmd.Parameters("@SlNo").Value) = 0 Then
                    cmd.CommandText = "insert into ms_preventiveMaintenanceDetails ( maintenance_group , maintenance_type, PM_Done_Date , Next_Due_date ,machine_code, sub_assembly , remarks, ShopCode,SlNo )" &
                    " values ( @maintenance_group , @maintenance_type ,  @PM_Done_Date , @Next_Due_date , @machine_code , @sub_assembly, @remarks,@ShopCode,@SlNo ) "
                Else
                    cmd.CommandText = " update ms_preventiveMaintenanceDetails set remarks=@remarks where ShopCode=@ShopCode and machine_code=@machine_code"
                    ' cmd.CommandText = "update ms_preventiveMaintenanceDetails set Next_Due_date= @Next_Due_date and remarks=@remarks  "
                End If
                cmd.Parameters.AddWithValue("@maintenance_group", maintenance_group)
                ' cmd.Parameters.AddWithValue("@txt_time", txt_time)
                cmd.Parameters.AddWithValue("@maintenance_type", maintenance_type)
                cmd.Parameters.AddWithValue("@PM_Done_Date ", PM_Done_Date)
                cmd.Parameters.AddWithValue("@Next_Due_date", Next_Due_date)
                cmd.Parameters.AddWithValue("@machine_code", machine_code)
                cmd.Parameters.AddWithValue("@sub_assembly", sub_assembly)
                cmd.Parameters.AddWithValue("@remarks", remarks)
                cmd.Parameters.AddWithValue("@ShopCode", ShopCode)

                ' cmd.Connection.Open()

                If cmd.ExecuteNonQuery() = 1 Then done1 = True

            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally

                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
                cmd = Nothing

            End Try
            If done1 = True Then
                lblMessage.Text = "Data Saved"
            Else
                lblMessage.Text = "updation failed"
            End If
            '
        End If
        GetGridData()

    End Sub


    Private Sub Clear()
        Dim dt As New DataTable()
        'Dim dr As DataRow
        ' Dim cnt As Int16
        dt.TableName = "spares"
        dt.Columns.Add("Pl Number")
        dt.Columns.Add("Description")
        dt.Columns.Add("Unit")
        dt.Columns.Add("Quantity")
        'grdSpares.DataSource = dt
        'grdSpares.DataBind()

        ' txtAttendent.Text = ""
        txtRemarks.Text = ""
        '  txtWork_done.Text = ""
        'txtPLNumber.Text = ""
        'txtpl_qty.Text = ""
        'txtSpareCost.Text = ""
        cboAssembly.Items.Clear()
        cboMachine.Items.Clear()
        ' cboSpares.Items.Clear()
    End Sub

    Protected Sub rblshopCode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblshopCode.SelectedIndexChanged
        Dim grp = Session("group")
        Dim shop = rblshopCode.SelectedItem.Text.Trim
        PopulateMachineCode(lblMode.Text, shop, grp)
        GetGridData()
    End Sub

    Protected Sub radType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles radType.SelectedIndexChanged

        Dim IntervalType As String

        If radType.SelectedItem.Text = "Weekly" Then
            txtTo.Text = Today.AddDays(7)
            txtFrom.Text = Today

        ElseIf radType.SelectedItem.Text = "Monthly" Then
            IntervalType = "m"
            txtTo.Text = DateAdd(IntervalType, 1, txtFrom.Text)

        ElseIf radType.SelectedItem.Value = "Quarterly" Then
            IntervalType = "m"
            txtTo.Text = DateAdd(IntervalType, 3, txtFrom.Text)

        ElseIf radType.SelectedItem.Value = "Halfyearly" Then
            IntervalType = "m"
            txtTo.Text = DateAdd(IntervalType, 6, txtFrom.Text)

        ElseIf radType.SelectedItem.Value = "Yearly" Then
            IntervalType = "yyyy"
            txtTo.Text = DateAdd(IntervalType, 1, txtFrom.Text)

        ElseIf radType.SelectedItem.Value = "50Hrs" Then
            txtTo.Text = Today.AddDays(2)


        ElseIf radType.SelectedItem.Value = "250Hrs" Then
            txtTo.Text = Today.AddDays(10)


        ElseIf radType.SelectedItem.Value = "500Hrs" Then
            txtTo.Text = Today.AddDays(21)

        ElseIf radType.SelectedItem.Value = "1000Hrs" Then
            txtTo.Text = Today.AddDays(41)

        ElseIf radType.SelectedItem.Value = "10000Hrs" Then
            txtTo.Text = Today.AddDays(416)
        End If
    End Sub


End Class