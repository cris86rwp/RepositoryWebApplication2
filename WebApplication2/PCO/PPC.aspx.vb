Public Class PPC
    Inherits System.Web.UI.Page
    Protected WithEvents rblFinYear As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblPlanFor As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents rblFrom As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents rblTo As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtPlannedWDays As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtAuthority As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblAuthority As System.Web.UI.WebControls.Label
    Protected WithEvents RangeValidator1 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents txtNewQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblNewQty As System.Web.UI.WebControls.Label
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblUser As System.Web.UI.WebControls.Label
    Protected WithEvents dgResults As System.Web.UI.WebControls.DataGrid
    Protected WithEvents rblProduct As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents lblGroup As System.Web.UI.WebControls.Label
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
        'Put user code to initialize the page here
        lblUser.Visible = False
        If IsPostBack = False Then
            Session("UserID") = "078844"
            Session("Group") = "PCOPCO"
            '''' authorisation feature inserted as requested by SSE/PCO on 24/5/2006 svi.
            '''' after he alleged targets are changed without his knowledge on 23.5.2006
            Try
                'If PCO.tables.CheckAuthority("RWF Production Targets", "SSPCO") = False Then
                '    Response.Redirect("/mms/InvalidSession.aspx")
                '    Exit Sub
                'End If
                If CStr(Session("UserID")) <> "" AndAlso CStr(Session("Group")) = "PCOPCO" Then
                    lblUser.Text = Session("UserID")
                    lblGroup.Text = Session("Group")
                Else
                    Response.Redirect("/mms/InvalidSession.aspx")
                    Exit Sub
                End If
            Catch exp As Exception
                Response.Redirect("/mms/InvalidSession.aspx")
                Exit Sub
            End Try
            Dim dt As DataTable
            Try
                dt = PCO.tables.PPCFinYear
                rblFinYear.DataSource = dt
                rblFinYear.DataTextField = dt.Columns(0).ColumnName
                rblFinYear.DataValueField = dt.Columns(0).ColumnName
                rblFinYear.DataBind()
                rblFinYear.SelectedIndex = 0
                rblPlanFor.SelectedIndex = 0
                dt = PCO.tables.MonthNames
                rblFrom.DataSource = dt
                rblFrom.DataTextField = dt.Columns(0).ColumnName
                rblFrom.DataValueField = dt.Columns(1).ColumnName
                rblFrom.DataBind()
                rblFrom.SelectedIndex = 0
                rblTo.DataSource = dt
                rblTo.DataTextField = dt.Columns(0).ColumnName
                rblTo.DataValueField = dt.Columns(1).ColumnName
                rblTo.DataBind()
                rblTo.SelectedIndex = 0
                rblProduct.SelectedIndex = 0
                GetTargets()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            Finally
                dt = Nothing
            End Try
        End If
    End Sub

    Private Sub GetTargets()
        dgResults.DataSource = PCO.tables.PPCTergets(rblFinYear.SelectedItem.Text, rblProduct.SelectedItem.Text, rblProduct.SelectedItem.Value)
        dgResults.DataBind()
    End Sub

    Private Sub rblProduct_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblProduct.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            GetTargets()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        If CInt(rblFrom.SelectedItem.Value) > CInt(rblTo.SelectedItem.Value) Then
            lblMessage.Text = "InValid Month Selection !"
            Exit Sub
        Else
            Try
                CheckTargetData() ' Inserts records of targets if does not exist
                Select Case rblPlanFor.SelectedItem.Value.ToLower
                    Case Is = "day"
                        UpdateDayTargets() ' updates figues given by user.
                    Case Is = "month"
                        updateMonthTarget() ' updates figues given by user.
                    Case Is = "year"
                        UpdateYearTargets() ' updates figues given by user.
                End Select
            Catch exp As Exception
                lblMessage.Text = ""
            End Try
            Dim Done As Boolean
            Try
                Done = New PCO.PCO().UpdateMMSAuthorisations(lblGroup.Text, Left(lblUser.Text.Trim, 6))
                'If Done = False Then Throw New Exception("Upation of Authorisation Failed")
                GetTargets()
            Catch exp As Exception
                lblMessage.Text &= " Compliance Save Error: " & exp.Message
            End Try
            Done = Nothing
        End If
    End Sub

    Private Sub Clear()
        txtNewQty.Text = ""
        txtAuthority.Text = ""
        txtPlannedWDays.Text = ""
    End Sub
    Private Sub CheckTargetData()
        Dim Done1, Done2 As Boolean
        Try
            If PCO.tables.CntRecords(rblFinYear.SelectedItem.Text) = 0 Then
                Done2 = New PCO.PCO().InsertDayAnnualTargets(rblFinYear.SelectedItem.Text, lblUser.Text & "", txtAuthority.Text.ToUpper)
                If Done2 = False Then Throw New Exception("InValid Saving")
            End If
            If PCO.tables.CntMonthTargetsNew(rblFinYear.SelectedItem.Text) = 0 Then
                Done1 = New PCO.PCO().InsertMonthTargets(rblFinYear.SelectedItem.Text)
                If Done1 = False Then Throw New Exception("InValid Saving")
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        Done1 = Nothing
        Done2 = Nothing
    End Sub

    Private Sub UpdateDayTargets()
        Dim Done As Boolean
        Try
            Done = New PCO.PCO().UpdateDayTargets(rblFrom.SelectedItem.Value, rblTo.SelectedItem.Value, txtNewQty.Text, rblFinYear.SelectedItem.Text, rblProduct.SelectedItem.Value)
            If Done = False Then Throw New Exception("Inalid Updation")
        Catch exp As Exception
            Throw New Exception("Update Error !")
        End Try
        If Done Then
            lblMessage.Text = "Message: Updated"
            Clear()
        End If
        Done = Nothing
    End Sub

    Private Sub updateMonthTarget()
        Dim dt As New DataTable()
        Dim dr As DataRow
        dt.TableName = "MonthName"
        dt.Columns.Add("MonthName")
        dt.Columns.Add("MonthValue")

        Dim i As Integer
        For i = rblFrom.SelectedItem.Value - 1 To rblTo.SelectedItem.Value - 1
            dr = dt.NewRow
            dr("MonthName") = rblFrom.Items(i).Value
            dr("MonthValue") = Left(rblFrom.Items(i).Text, 2)
            dt.Rows.Add(dr)
        Next
        i = Nothing
        dr = Nothing
        Dim Done As Boolean
        Try
            Done = New PCO.PCO().updateMonthTarget(rblProduct.SelectedItem.Value, txtPlannedWDays.Text, rblFinYear.SelectedItem.Text, txtNewQty.Text, rblFrom.SelectedItem.Value, rblTo.SelectedItem.Value, dt)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If Done Then
            lblMessage.Text = "Message: Updated"
            Clear()
        End If
        Done = Nothing
    End Sub

    Private Sub UpdateYearTargets()
        Dim i As Boolean
        Try
            i = New PCO.PCO().UpdateYearTargets(txtPlannedWDays.Text, txtNewQty.Text, rblProduct.SelectedItem.Value, rblFinYear.SelectedItem.Text)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If i Then
            lblMessage.Text = "Message: Updated"
            Clear()
        End If
        i = Nothing
    End Sub

End Class
