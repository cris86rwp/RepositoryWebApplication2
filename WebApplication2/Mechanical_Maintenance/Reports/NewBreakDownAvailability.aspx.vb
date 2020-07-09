Public Class NewBreakDownAvailability
    Inherits System.Web.UI.Page
    Protected WithEvents rblYear As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblMonth As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblProdAffected As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtAvailability As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RangeValidator1 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents dgGroups As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgMachines As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnPrint As System.Web.UI.WebControls.Button
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    Shared themeValue As String
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
    Private Sub Page_PreInit(ByVal sender As Object, ByVal e As EventArgs)
        Page.Theme = themeValue
    End Sub

    Public Sub New()
        AddHandler PreInit, New EventHandler(AddressOf Page_PreInit)
    End Sub

    Protected Sub dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        btnPrint.Visible = False
        If Page.IsPostBack = False Then
            Try
                GetBrDnYear()
                GetBrDnMonth()
                txtAvailability.Text = "98"
                SubmitValues()
                SetDgMachines()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
    Private Sub SetDgMachines()
        dgMachines.Visible = False
        btnPrint.Visible = False
        dgMachines.DataSource = Nothing
        dgMachines.DataBind()
    End Sub
    Private Sub GetBrDnYear()
        Dim dvYear As DataView
        Try
            dvYear = NewBreakDownTables.GetBreakDownYear.DefaultView
            rblYear.DataSource = dvYear
            rblYear.DataValueField = dvYear.Table.Columns(0).ColumnName
            rblYear.DataTextField = dvYear.Table.Columns(0).ColumnName
            rblYear.DataBind()
            Dim i As Integer
            For i = 0 To rblYear.Items.Count - 1
                If rblYear.Items(i).Text = Now.Year Then
                    rblYear.SelectedIndex = i
                    Exit For
                End If
            Next
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            dvYear.Dispose()
        End Try
    End Sub
    Private Sub GetBrDnMonth()
        Dim dvMonth As DataView
        Try
            dvMonth = NewBreakDownTables.GetBreakDownMonth.DefaultView
            rblMonth.DataSource = dvMonth
            rblMonth.DataValueField = dvMonth.Table.Columns(0).ColumnName
            rblMonth.DataTextField = dvMonth.Table.Columns(1).ColumnName
            rblMonth.DataBind()
            Dim i As Integer
            For i = 0 To rblMonth.Items.Count - 1
                If rblMonth.Items(i).Value = Now.Month Then
                    rblMonth.SelectedIndex = i
                    Exit For
                End If
            Next
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            dvMonth.Dispose()
        End Try
    End Sub
    Private Sub SubmitValues()
        lblMessage.Text = ""
        SetDgMachines()
        Try
            GetGroupData()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub GetGroupData()
        dgGroups.DataSource = Nothing
        dgGroups.DataBind()
        dgGroups.Visible = False
        dgGroups.SelectedIndex = -1
        Dim dv As New DataView()
        Try
            dv = NewBreakDownTables.GetGroupWise(rblProdAffected.SelectedItem.Value, rblYear.SelectedItem.Value, rblMonth.SelectedItem.Value, txtAvailability.Text.Trim).DefaultView
            dgGroups.DataSource = dv
            dgGroups.DataBind()
            If dgGroups.Items.Count > 1 Then
                dgGroups.Visible = True
            Else
                lblMessage.Text = "No Records Please ! "
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dv.Dispose()
        End Try
    End Sub
    Public Class NewBreakDownTables
        Public Shared Function GetMachineWise(ByVal Affected As String, ByVal Year As Integer, ByVal Month As Integer, ByVal Availability As Decimal, ByVal GroupName As String) As DataTable
            Dim dtMachineWise As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select GroupName , MachineCode , MachineShortName , TimeLossinMin inMin , Availablity from dbo.ms_fn_BreakdownAvailabilityMachineWise('" & Affected.Trim & "'," & Year & "," & Month & "," & Availability & ",'" & GroupName.Trim & "') where GroupName <> 'ALL SHOPS' "
            Try
                da.Fill(ds, "MachineWise")
                dtMachineWise = ds.Tables("MachineWise")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtMachineWise
        End Function
        Public Shared Function GetGroupWise(ByVal Affected As String, ByVal Year As Integer, ByVal Month As Integer, ByVal Availability As Decimal) As DataTable
            Dim dtGroupWise As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select distinct Affected , GroupName  from dbo.ms_fn_BreakdownAvailabilityMachineWise('" & Affected.Trim & "'," & Year & "," & Month & "," & Availability & ",'ALL SHOPS') order by Affected desc"
            Try
                da.Fill(ds, "GroupWise")
                dtGroupWise = ds.Tables("GroupWise")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtGroupWise
        End Function
        Public Shared Function GetBreakDownYear() As DataTable
            Dim dtYears As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select distinct year(breakdown_date) BreakDownYear from ms_breakdown_memo where year(breakdown_date) > 2005 order by year(breakdown_date) "
            Try
                da.Fill(ds, "Years")
                dtYears = ds.Tables("Years")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtYears
        End Function
        Public Shared Function GetBreakDownMonth() As DataTable
            Dim dtMonth As New DataTable()
            Dim da As System.Data.SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
            Dim ds As New DataSet()
            da.SelectCommand.CommandText = " select distinct month(breakdown_date) BreakDownMonth , convert(varchar(3), breakdown_date , 107) BreakDownMonthName from ms_breakdown_memo " & _
                                    " where year(breakdown_date) = 2007 order by month(breakdown_date), convert(varchar(3), breakdown_date , 107) "
            Try
                da.Fill(ds, "Month")
                dtMonth = ds.Tables("Month")
            Catch exp As Exception
                Throw New Exception(exp.Message)
            Finally
                ds.Dispose()
                da.Dispose()
            End Try
            Return dtMonth
        End Function
    End Class

    Private Sub rblYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblYear.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            SubmitValues()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub rblMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblMonth.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            SubmitValues()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub rblProdAffected_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblProdAffected.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            SubmitValues()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtAvailability_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAvailability.TextChanged
        lblMessage.Text = ""
        Try
            SubmitValues()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub dgGroups_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgGroups.ItemCommand
        lblMessage.Text = ""
        'SetDgMachines()
        Try
            Select Case e.CommandName
                Case "Select"
                    lblMessage.Text = e.Item.Cells(2).Text.Trim
                    dgMachines.DataSource = NewBreakDownTables.GetMachineWise(rblProdAffected.SelectedItem.Value, rblYear.SelectedItem.Value, rblMonth.SelectedItem.Value, txtAvailability.Text.Trim, e.Item.Cells(2).Text.Trim).DefaultView
                    dgMachines.DataBind()
                    If dgMachines.Items.Count > 0 Then
                        dgMachines.Visible = True
                        'btnPrint.Visible = True
                        btnPrint.Text = "Show Report for : " & e.Item.Cells(2).Text.Trim
                    End If
            End Select
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strPathName As String
        'strPathName = "/wap/mss/spares/reports/formats/SparecellPODues.rpt?user0=report&password0=report&promptonrefresh=0&prompt0=DateTime(" & Format(CDate(txtFromDate.Text), "yyyy,MM,dd 00, 00, 00") & ")&prompt1=DateTime(" & Format(CDate(txtToDate.Text), "yyyy,MM,dd 00, 00, 00") & ")"
        strPathName = "/wap/mss/mechMaintenance/Reports/Formats/ms_BreakdownAvailabilityMachineWiseReport.rpt?user0=report&password0=report&prompt0=" & rblProdAffected.SelectedItem.Value & "&prompt1=" & rblYear.SelectedItem.Value & "&prompt2=" & rblMonth.SelectedItem.Value & "&prompt3=" & txtAvailability.Text.Trim & "&prompt4=" & lblMessage.Text.Trim & "&promptonrefresh=0"
        Response.Redirect(strPathName)
    End Sub
End Class
