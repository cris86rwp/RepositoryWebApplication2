Public Class PPC_RB
    Inherits System.Web.UI.Page
    Protected WithEvents ddlPlanPeriod As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents ddlFrom As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents ddlTo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents CompareValidator1 As System.Web.UI.WebControls.CompareValidator
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents regexpFinYr As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents rfvProduct As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents ddlProduct As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblmessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblNewQty As System.Web.UI.WebControls.Label
    Protected WithEvents RangeValidator1 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents txtNewQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblLoggedInBy As System.Web.UI.WebControls.Label
    Protected WithEvents lblAuthority As System.Web.UI.WebControls.Label
    Protected WithEvents txtAuthority As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents txtPlannedWDays As System.Web.UI.WebControls.TextBox
    Protected WithEvents chkUpdate As System.Web.UI.WebControls.CheckBox
    Protected WithEvents pnlUpdate As System.Web.UI.WebControls.Panel
    Protected WithEvents btnSubmit As System.Web.UI.WebControls.Button
    Protected WithEvents btnClear As System.Web.UI.WebControls.Button
    Protected WithEvents txtfinYear As System.Web.UI.WebControls.TextBox
    Protected WithEvents dgResults As System.Web.UI.WebControls.DataGrid
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
        Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None
        If Page.IsPostBack = False Then
            Session("Group") = "PCOPCO"
            Session("UserID") = "111111"
            Try
                If CStr(Session("UserID")) <> "" AndAlso CStr(Session("Group")) = "PCOPCO" Then
                    lblLoggedInBy.Text = Session("UserID")
                Else
                    Response.Redirect("InvalidSession.aspx")
                    Exit Sub
                End If
            Catch exp As Exception
                Response.Redirect("InvalidSession.aspx")
                Exit Sub
            End Try
            lblLoggedInBy.Text = Session("UserID")
            chkUpdate.Checked = False
            pnlUpdate.Visible = chkUpdate.Checked
            ddlFrom.Visible = False
            ddlTo.Visible = False
        End If
    End Sub
    Private Sub ddlPlanPeriod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlPlanPeriod.SelectedIndexChanged
        dgResults.DataSource = Nothing
        dgResults.DataBind()
        dgResults.Visible = False
        ddlProduct.SelectedIndex = 0
        lblmessage.Text = ""
        If txtfinYear.Text.Trim.Length = 0 Then
            lblmessage.Text = "Please provide Fin Year !"
            ddlPlanPeriod.SelectedIndex = 0
            Exit Sub
        End If
        pnlUpdate.Visible = False
        chkUpdate.Checked = False
        ddlFrom.Items.Clear()
        ddlTo.Items.Clear()
        ddlFrom.Visible = True
        ddlTo.Visible = True
        Label3.Visible = True
        Label2.Visible = True
        Label6.Visible = False
        txtPlannedWDays.Visible = False
        Select Case ddlPlanPeriod.SelectedItem.Value
            Case "Day"
                MonthNames(ddlFrom)
                MonthNames(ddlTo)
            Case "Month"
                MonthNames(ddlFrom)
                MonthNames(ddlTo)
                Label6.Visible = True
                txtPlannedWDays.Visible = True
            Case "Year"
                ddlFrom.Visible = False
                ddlTo.Visible = False
                Label3.Visible = False
                Label2.Visible = False
                Label6.Visible = True
                txtPlannedWDays.Visible = True
        End Select
    End Sub
    Private Sub clear()
        ddlFrom.Items.Clear()
        ddlTo.Items.Clear()
        ddlPlanPeriod.ClearSelection()
        ddlPlanPeriod.SelectedIndex = 0
        ddlProduct.ClearSelection()
        ddlProduct.SelectedIndex = 0
        ddlFrom.Visible = False
        ddlTo.Visible = False
        pnlUpdate.Visible = False
        chkUpdate.Visible = False
        txtAuthority.Text = ""
        txtNewQty.Text = ""
        txtPlannedWDays.Text = ""
        txtfinYear.Text = ""
        lblmessage.Text = ""

    End Sub
    Private Sub MonthNames(ByRef ddl As System.Web.UI.WebControls.DropDownList)
        Dim dt As New DataTable()
        Dim dr As DataRow
        dt.TableName = "MonthName"
        dt.Columns.Add("MonthName")
        dt.Columns.Add("MonthValue")

        Dim MyListItem As ListItem

        MyListItem = New ListItem()
        MyListItem.Text = "04-April"
        MyListItem.Value = 1
        dr = dt.NewRow
        dr("MonthName") = "04-April"
        dr("MonthValue") = 1
        dt.Rows.Add(dr)
        ddl.Items.Add(MyListItem)

        MyListItem = New ListItem()
        dr = dt.NewRow
        dr("MonthName") = "05-May"
        dr("MonthValue") = 2
        dt.Rows.Add(dr)
        MyListItem.Text = "05-May"
        MyListItem.Value = 2
        ddl.Items.Add(MyListItem)

        MyListItem = New ListItem()
        dr = dt.NewRow
        dr("MonthName") = "06-June"
        dr("MonthValue") = 3
        dt.Rows.Add(dr)
        MyListItem.Text = "06-June"
        MyListItem.Value = 3
        ddl.Items.Add(MyListItem)

        MyListItem = New ListItem()
        dr = dt.NewRow
        dr("MonthName") = "07-July"
        dr("MonthValue") = 4
        dt.Rows.Add(dr)
        MyListItem.Text = "07-July"
        MyListItem.Value = 4
        ddl.Items.Add(MyListItem)

        MyListItem = New ListItem()
        dr = dt.NewRow
        dr("MonthName") = "08-August"
        dr("MonthValue") = 5
        dt.Rows.Add(dr)
        MyListItem.Text = "08-August"
        MyListItem.Value = 5
        ddl.Items.Add(MyListItem)

        MyListItem = New ListItem()
        dr = dt.NewRow
        dr("MonthName") = "09-September"
        dr("MonthValue") = 6
        dt.Rows.Add(dr)
        MyListItem.Text = "09-September"
        MyListItem.Value = 6
        ddl.Items.Add(MyListItem)

        MyListItem = New ListItem()
        dr = dt.NewRow
        dr("MonthName") = "10-October"
        dr("MonthValue") = 7
        dt.Rows.Add(dr)
        MyListItem.Text = "10-October"
        MyListItem.Value = 7
        ddl.Items.Add(MyListItem)

        MyListItem = New ListItem()
        dr = dt.NewRow
        dr("MonthName") = "11-November"
        dr("MonthValue") = 8
        dt.Rows.Add(dr)
        MyListItem.Text = "11-November"
        MyListItem.Value = 8
        ddl.Items.Add(MyListItem)

        MyListItem = New ListItem()
        dr = dt.NewRow
        dr("MonthName") = "12-December"
        dr("MonthValue") = 9
        dt.Rows.Add(dr)
        MyListItem.Text = "12-December"
        MyListItem.Value = 9
        ddl.Items.Add(MyListItem)

        MyListItem = New ListItem()
        dr = dt.NewRow
        dr("MonthName") = "01-January"
        dr("MonthValue") = 10
        dt.Rows.Add(dr)
        MyListItem.Text = "01-January"
        MyListItem.Value = 10
        ddl.Items.Add(MyListItem)

        MyListItem = New ListItem()
        dr = dt.NewRow
        dr("MonthName") = "02-February"
        dr("MonthValue") = 11
        dt.Rows.Add(dr)
        MyListItem.Text = "02-February"
        MyListItem.Value = 11
        ddl.Items.Add(MyListItem)

        MyListItem = New ListItem()
        dr = dt.NewRow
        dr("MonthName") = "03-March"
        dr("MonthValue") = 12
        dt.Rows.Add(dr)
        MyListItem.Text = "03-March"
        MyListItem.Value = 12
        ddl.Items.Add(MyListItem)
        Session("MonthTable") = dt
        dt = Nothing
        dr = Nothing
        MyListItem = Nothing
    End Sub
    Private Sub UpdateYearTargets()
        If txtfinYear.Text = "" Then
            Exit Sub
        End If
        If ddlProduct.SelectedItem.Text.ToLower = "select" Then
            rfvProduct.IsValid = False
            Exit Sub
        End If
        Dim len As Boolean
        Try
            len = New PCO.PCO().RBUpdateYearTargets(txtPlannedWDays.Text, txtNewQty.Text, txtfinYear.Text, ddlProduct.SelectedItem.Value)
            If len Then lblmessage.Text = "updated"
        Catch exp As Exception
            Throw New Exception(exp.Message)
        End Try
        len = Nothing
    End Sub
    Private Sub GetYearTargets()
        Dim dt As DataTable
        dgResults.DataSource = Nothing
        dgResults.DataBind()
        dgResults.Visible = False
        Try
            dt = PCO.tables.RBGetYearTargets(ddlProduct.SelectedItem.Value, txtfinYear.Text)
            dgResults.DataSource = dt
            dgResults.DataBind()
            dgResults.Visible = True
        Catch exp As Exception
            Throw New Exception("Rertival Error !")
        End Try
        dt = Nothing
    End Sub
    Private Sub updateMonthTarget()
        Dim Done As Boolean
        Try
            Done = New PCO.PCO().RBupdateMonthTarget(ddlProduct.SelectedItem.Value, txtfinYear.Text, txtPlannedWDays.Text, txtNewQty.Text, ddlFrom.SelectedItem.Value, ddlTo.SelectedItem.Value, Session("MonthTable"))
        Catch exp As Exception
            lblmessage.Text = exp.Message
        End Try
        If Done Then lblmessage.Text = "updated"
        Done = Nothing
    End Sub
    Private Sub GetMonthTargets()
        Dim dt As DataTable
        dgResults.DataSource = Nothing
        dgResults.DataBind()
        dgResults.Visible = False
        Dim sqlstr As New System.Text.StringBuilder()
        Dim i As Integer
        Try
            sqlstr.Append(" and month_number in ( ")
            For i = ddlFrom.SelectedItem.Value To ddlTo.SelectedItem.Value
                sqlstr.Append("'" & Left(ddlTo.Items(i - 1).Text, 2) & "'")
                If i <> ddlTo.SelectedItem.Value Then
                    sqlstr.Append(",")
                End If
                sqlstr.Append(" ")
            Next
            sqlstr.Append("  )")
            dt = PCO.tables.RBGetMonthTargets(ddlProduct.SelectedItem.Value, txtfinYear.Text, sqlstr.ToString)
            dgResults.DataSource = dt
            dgResults.DataBind()
            dgResults.Visible = True
        Catch exp As Exception
            Throw New Exception("Retrival Error !")
        End Try
        dt = Nothing
        i = Nothing
        sqlstr = Nothing
    End Sub
    Private Sub GetDayTargets()
        Dim dt As DataTable
        dgResults.DataSource = Nothing
        dgResults.DataBind()
        dgResults.Visible = False
        Try
            dt = PCO.tables.RBGetDayTargets(ddlFrom.SelectedItem.Value, ddlTo.SelectedItem.Value, ddlProduct.SelectedItem.Value, txtfinYear.Text)
            dgResults.DataSource = dt
            dgResults.DataBind()
            dgResults.Visible = True
        Catch exp As Exception
            Throw New Exception(exp.Message)
        End Try
        dt = Nothing
    End Sub
    Private Sub UpdateDayTargets()
        If txtfinYear.Text = "" Then
            Exit Sub
        End If
        If ddlProduct.SelectedItem.Text.ToLower = "select" Then
            rfvProduct.IsValid = False
            Exit Sub
        End If
        Dim Done As Boolean
        Try
            Done = New PCO.PCO().RBUpdateDayTargets(ddlFrom.SelectedItem.Value, ddlTo.SelectedItem.Value, txtNewQty.Text, txtfinYear.Text, ddlProduct.SelectedItem.Value)
            If Done = False Then Throw New Exception("Inalid Updation")
        Catch exp As Exception
            Throw New Exception("Update Error !")
        End Try
        Done = Nothing
    End Sub
    Private Sub CheckFinYear()
        Try
            Dim dt, dt1 As Date
            dt = CDate("01/04/" + Left(txtfinYear.Text, 4))
            dt1 = CDate("31/03/" + "20" + Right(txtfinYear.Text.Trim, 2))
            Dim tmspan As New TimeSpan()
            tmspan = dt1.Subtract(dt)
            If tmspan.TotalDays > 366 Then
                lblmessage.Text = "Financial year error"
                txtfinYear.Text = ""
            Else
                Dim todaydt As Date = Today
                Dim dYearStartDate As Date
                If todaydt.Month < 4 Then
                    dYearStartDate = CDate("01/04/" + CStr(todaydt.Year - 1).Trim)
                Else
                    dYearStartDate = CDate("01/04/" + CStr(todaydt.Year).Trim)
                End If
                '     dYearStartDate = dYearStartDate.AddYears(-1)
                If dt < dYearStartDate Then
                    lblmessage.Text = "Financial year error"
                    txtfinYear.Text = ""
                End If
                Dim dYearEndDate As Date
                dYearEndDate = dYearStartDate.AddYears(2)
                If dt1 > dYearEndDate Then
                    lblmessage.Text = "Financial Year error."
                    txtfinYear.Text = ""
                End If
                dYearStartDate = Nothing
                dYearEndDate = Nothing
                todaydt = Nothing
            End If
            tmspan = Nothing
            dt1 = Nothing
            dt = Nothing
        Catch exp As Exception
            lblmessage.Text = "error : " & exp.Message
            txtfinYear.Text = ""
        End Try
    End Sub
    Private Sub chkUpdate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUpdate.CheckedChanged
        pnlUpdate.Visible = chkUpdate.Checked
    End Sub
    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        lblmessage.Text = ""
        dgResults.Visible = False
        CheckFinYear()
        If txtfinYear.Text = "" Then
            Exit Sub
        End If
        If ddlProduct.SelectedItem.Text.ToLower = "select" Then
            rfvProduct.IsValid = False
            Exit Sub
        End If
        If IsNothing(ddlPlanPeriod.SelectedItem) OrElse ddlPlanPeriod.SelectedItem.Text.ToLower = "select" Then
            lblmessage.Text = "Plan Period not selected"
            Exit Sub
        End If
        CheckTargetData() ' Inserts records of targets if does not exist
        Select Case ddlPlanPeriod.SelectedItem.Value.ToLower
            Case Is = "day"
                GetDayTargets() ' gets day figures
                If chkUpdate.Checked = True Then
                    UpdateDayTargets() ' updates figues given by user.
                End If
                GetDayTargets() ' gets day figures
            Case Is = "month"
                GetMonthTargets() 'gets month figures
                If chkUpdate.Checked Then
                    updateMonthTarget() ' updates figues given by user.
                End If
                GetMonthTargets() 'gets month figures
            Case Is = "year"
                GetYearTargets() ' get year figures
                If chkUpdate.Checked Then
                    UpdateYearTargets() ' updates figues given by user.
                End If
                GetYearTargets() ' get year figures
                If chkUpdate.Checked Then
                    Dim Update As Boolean
                    Try
                        Update = New PCO.PCO().RBUpdateMMSAuthorisations(Session("Group"), Left(CStr(Session("UserID")), 6))
                        If Update = False Then Throw New Exception("Authorisation Failed !")
                    Catch exp As Exception
                        lblmessage.Text &= " Compliance Save Error: " & exp.Message
                    End Try
                    Update = Nothing
                End If
        End Select
    End Sub
    Private Sub CheckTargetData()
        Dim Done1, Done2 As Boolean
        Try
            If PCO.tables.RBCntRecords(txtfinYear.Text) = 0 Then
                Done1 = New PCO.PCO().RBInsertDayAnnualTargets(txtfinYear.Text, lblLoggedInBy.Text & "", txtAuthority.Text.ToUpper)
            End If
            If PCO.tables.RBCntMonthTargets(txtfinYear.Text) = 0 Then
                Done2 = New PCO.PCO().RBInsertMonthTargets(txtfinYear.Text)
            End If
        Catch exp As Exception
            lblmessage.Text = exp.Message
        End Try
        Done1 = Nothing
        Done2 = Nothing
    End Sub
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        clear()
    End Sub
End Class
