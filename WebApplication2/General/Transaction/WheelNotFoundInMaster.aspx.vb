Public Class WheelNotFoundInMaster
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents rblType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtWhlNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtHeatNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtYearOfManf As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblWhlType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnAWMCLR As System.Web.UI.WebControls.Button
    Protected WithEvents lblGroup As System.Web.UI.WebControls.Label
    Protected WithEvents pnlAWMCLR As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlMLDING As System.Web.UI.WebControls.Panel
    Protected WithEvents lblWhlNo As System.Web.UI.WebControls.Label
    Protected WithEvents lblWhlType As System.Web.UI.WebControls.Label
    Protected WithEvents lblYearOfManf As System.Web.UI.WebControls.Label
    Protected WithEvents txtWhlReadAtMR As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWheel_number As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtheat_number As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSIC As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMRDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnMLDING As System.Web.UI.WebControls.Button
    Protected WithEvents lblSlNo As System.Web.UI.WebControls.Label
    Protected WithEvents lblHeatNo As System.Web.UI.WebControls.Label
    Protected WithEvents pnlSearch As System.Web.UI.WebControls.Panel
    Protected WithEvents rblSearch As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnSearch As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents List1 As System.Web.UI.WebControls.Panel
    Protected WithEvents List1a As System.Web.UI.WebControls.TextBox
    Protected WithEvents List1b As System.Web.UI.WebControls.TextBox
    Protected WithEvents List1c As System.Web.UI.WebControls.TextBox
    Protected WithEvents List2 As System.Web.UI.WebControls.Panel
    Protected WithEvents List2a As System.Web.UI.WebControls.TextBox
    Protected WithEvents List3 As System.Web.UI.WebControls.Panel
    Protected WithEvents List3a As System.Web.UI.WebControls.TextBox
    Protected WithEvents List3b As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFedDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
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
        lblSlNo.Visible = False
        lblGroup.Visible =
        rblType.Visible = True
        If IsPostBack = False Then
            txtMRDate.Text = Now.Date
            txtFedDate.Text = Now.Date
            'Session("Group") = "AWMCLR"
            'Session("Group") = "MLDING"
            lblGroup.Text = Session("Group")
            Try
                SetType()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub SetType()
        pnlAWMCLR.Visible = False
        pnlMLDING.Visible = False
        If lblGroup.Text = "AWMCLR" Then
            pnlAWMCLR.Visible = True
            GetWheelTypes()
        Else
            pnlMLDING.Visible = True
            GetWNFMWheels()
        End If
        List1.Visible = False
        List2.Visible = False
        List3.Visible = False
    End Sub

    Private Sub GetWheelTypes()
        Dim dt As DataTable
        Try
            dt = RWF.WNFM.GetWheelTypes
            rblWhlType.DataSource = dt
            rblWhlType.DataTextField = dt.Columns(0).ColumnName
            rblWhlType.DataValueField = dt.Columns(0).ColumnName
            rblWhlType.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub GetWNFMWheels()
        Dim dt As DataTable
        Try
            dt = RWF.WNFM.GetWNFMWheels
            DataGrid1.SelectedIndex = -1
            If IsNothing(DataGrid1.CurrentPageIndex) Then DataGrid1.CurrentPageIndex = 0
            If dt.Rows.Count > 3 Then
                DataGrid1.AllowPaging = True
                DataGrid1.PageSize = 3
                DataGrid1.PagerStyle.Mode = PagerMode.NumericPages
            End If
            DataGrid1.DataSource = dt
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnAWMCLR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAWMCLR.Click
        lblMessage.Text = ""
        Try
            If New RWF.WNFM().SaveWNFMWheel(txtWhlNo.Text.Trim, txtHeatNo.Text.Trim, rblWhlType.SelectedItem.Text, txtYearOfManf.Text.Trim, CDate(txtFedDate.Text)) Then
                lblMessage.Text = "Data saved !"
                txtWhlNo.Text = ""
                txtHeatNo.Text = ""
                txtYearOfManf.Text = ""
                rblType.ClearSelection()
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub DataGrid1_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DataGrid1.PageIndexChanged
        lblMessage.Text = ""
        Try
            DataGrid1.CurrentPageIndex = e.NewPageIndex
            DataGrid1.EditItemIndex = -1
            GetWNFMWheels()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub Clear()
        List1a.Text = ""
        List1b.Text = ""
        List1c.Text = ""
        List2a.Text = ""
        List3a.Text = ""
        List3b.Text = ""
        rblSearch.ClearSelection()
    End Sub

    Private Sub DataGrid1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.ItemCommand
        lblMessage.Text = ""
        Clear()
        Select Case e.CommandName
            Case "Select"
                lblWhlNo.Text = e.Item.Cells(1).Text.Replace("&nbsp;", "")
                lblHeatNo.Text = e.Item.Cells(2).Text.Replace("&nbsp;", "")
                lblWhlType.Text = e.Item.Cells(3).Text.Replace("&nbsp;", "")
                lblYearOfManf.Text = e.Item.Cells(4).Text.Replace("&nbsp;", "")
                lblSlNo.Text = e.Item.Cells(5).Text.Replace("&nbsp;", "")
            Case "Delete"
                lblWhlNo.Text = e.Item.Cells(1).Text.Replace("&nbsp;", "")
                lblHeatNo.Text = e.Item.Cells(2).Text.Replace("&nbsp;", "")
                lblWhlType.Text = e.Item.Cells(3).Text.Replace("&nbsp;", "")
                lblYearOfManf.Text = e.Item.Cells(4).Text.Replace("&nbsp;", "")
                lblSlNo.Text = e.Item.Cells(5).Text.Replace("&nbsp;", "")
                lblMessage.Text = ""
                Try
                    If New RWF.WNFM().DeleteWNFMWheel(lblWhlNo.Text.Trim, lblHeatNo.Text.Trim, lblWhlType.Text, lblYearOfManf.Text.Trim, Val(lblSlNo.Text)) Then
                        lblMessage.Text = "Data Deleted !"
                        lblWhlNo.Text = ""
                        lblHeatNo.Text = ""
                        lblYearOfManf.Text = ""
                        lblWhlType.Text = ""
                        SetType()
                    Else
                        lblMessage.Text = "Data not Saved !"
                    End If
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                End Try
        End Select
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        lblMessage.Text = ""
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        Dim dt As DataTable
        Try
            Select Case rblSearch.SelectedItem.Value
                Case 1
                    dt = RWF.WNFM.GetWNFMList(rblSearch.SelectedItem.Value, List1a.Text.Trim, List1b.Text, List1c.Text, 0)
                Case 2
                    dt = RWF.WNFM.GetWNFMList(rblSearch.SelectedItem.Value, "", "", "", Val(List2a.Text))
                Case 3
                    dt = RWF.WNFM.GetWNFMList(rblSearch.SelectedItem.Value, List3a.Text.Trim, "", List3b.Text, 0)
            End Select
            DataGrid2.DataSource = dt
            DataGrid2.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub rblSearch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblSearch.SelectedIndexChanged
        lblMessage.Text = ""
        SetSearch()
    End Sub

    Private Sub SetSearch()
        List1.Visible = False
        List2.Visible = False
        List3.Visible = False
        Select Case rblSearch.SelectedItem.Value
            Case 1
                List1.Visible = True
                List1a.Text = lblWhlNo.Text.Trim.Replace("&nbsp;", "")
                List1b.Text = lblWhlType.Text.Replace("&nbsp;", "")
                List1c.Text = lblYearOfManf.Text.Replace("&nbsp;", "")
            Case 2
                List2.Visible = True
                List2a.Text = lblHeatNo.Text.Trim.Replace("&nbsp;", "")
            Case 3
                List3.Visible = True
                List3a.Text = lblWhlNo.Text.Trim.Replace("&nbsp;", "")
                List3b.Text = lblYearOfManf.Text.Trim.Replace("&nbsp;", "")
        End Select

    End Sub

    Private Sub btnMLDING_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMLDING.Click
        lblMessage.Text = ""
        Try
            If New RWF.WNFM().UpdateWNFMWheel(txtWhlReadAtMR.Text.Trim, Val(txtWheel_number.Text.Trim), Val(txtheat_number.Text), CDate(txtMRDate.Text.Trim), txtRemarks.Text.Trim, txtSIC.Text.Trim, Val(lblSlNo.Text)) Then
                lblMessage.Text = "Data saved !"
                txtWhlReadAtMR.Text = ""
                txtWheel_number.Text = ""
                txtheat_number.Text = ""
                txtRemarks.Text = ""
                txtSIC.Text = ""
                lblSlNo.Text = ""
                lblWhlNo.Text = ""
                lblHeatNo.Text = ""
                lblWhlType.Text = ""
                lblYearOfManf.Text = ""
                SetType()
            Else
                lblMessage.Text = "Data not Saved !"
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub


End Class
