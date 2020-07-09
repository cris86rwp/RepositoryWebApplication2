Public Class FumeExtraction
    Inherits System.Web.UI.Page
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents txtFromHeat As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtToHeat As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEndDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents lblSlNo As System.Web.UI.WebControls.Label
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtStartDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtStartTime As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEndTime As System.Web.UI.WebControls.TextBox
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
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
        If IsPostBack = False Then
            txtStartDate.Text = Now.Date
            txtEndDate.Text = Now.Date
            txtStartTime.Text = "00:00"
            txtEndTime.Text = "00:00"
            Try
                GetFumeExtractionDetails()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
    ' Commented to remove the warnings 06 mar 19

    'Private Sub SetFocus(ByVal ctrl As Control)
    '    Dim focusScript As String = "<script language=" & "javascript" & " > " & _
    '    "document.getElementById('" + ctrl.ClientID.ToString.Trim & _
    '    "').focus();</script>"
    '    Page.RegisterStartupScript("FocusScript", focusScript)
    'End Sub

    Private Sub txtEndDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEndDate.TextChanged
        lblMessage.Text = ""
        Dim dt As Date
        Try
            dt = CDate(txtEndDate.Text)
            txtEndDate.Text = dt
            If dt > Now.Date Then
                lblMessage.Text = "Date Cannot be greater than Today !"
                txtEndDate.Text = ""
                SetFocus(txtEndDate)
            End If
        Catch exp As Exception
            SetFocus(txtEndDate)
            lblMessage.Text = exp.Message
        End Try
        dt = Nothing
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        Dim Done As Boolean
        Dim dtStart, dtEnd As Date
        Try
            dtStart = CDate(txtStartDate.Text + " " + Right("0" + txtStartTime.Text, 5))
        Catch exp As Exception
            dtStart = Now.Date
        End Try
        Try
            dtEnd = CDate(txtEndDate.Text + " " + Right("0" + txtEndTime.Text, 5))
        Catch exp As Exception
            dtEnd = Now.Date
        End Try
        If dtStart > dtEnd Then
            lblMessage.Text = "InValid Offtime or OnTime !"
            Exit Sub
        End If
        If Val(txtFromHeat.Text) > Val(txtToHeat.Text) Then
            lblMessage.Text = "InValid Heat numbers !"
            Exit Sub
        End If
        Try
            Done = New RWF.Melting().SaveFumeExtractionDetails(Val(txtFromHeat.Text), Val(txtToHeat.Text), dtStart, dtEnd, txtRemarks.Text.Trim, Val(lblSlNo.Text))
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If Done Then
            Clear()
            lblMessage.Text = "Records updated ! "
            Try
                GetFumeExtractionDetails()
            Catch exp As Exception
                lblMessage.Text &= exp.Message
            End Try
        End If
        dtStart = Nothing
        dtEnd = Nothing
    End Sub

    Private Sub GetFumeExtractionDetails()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Dim dt As DataTable
        Try
            dt = RWF.Melting.GetFumeExtractionDetails
            If dt.Rows.Count > 0 Then
                DataGrid1.DataSource = dt
                DataGrid1.DataBind()
            Else
                lblMessage.Text &= "No Fume Extraction Details available !"
            End If
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
        dt = Nothing
    End Sub

    Private Sub txtStartDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStartDate.TextChanged
        lblMessage.Text = ""
        Dim dt As Date
        Try
            dt = CDate(txtStartDate.Text)
            txtStartDate.Text = dt
            If dt > Now.Date Then
                lblMessage.Text = "Date Cannot be greater than Today !"
                txtStartDate.Text = ""
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        dt = Nothing
    End Sub

    Private Sub DataGrid1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.ItemCommand
        lblMessage.Text = ""
        lblSlNo.Text = ""
        Dim Done As Boolean
        Select Case e.CommandName
            Case "Select"
                Try
                    txtFromHeat.Text = IIf(IsDBNull(e.Item.Cells(1).Text), "", e.Item.Cells(1).Text)
                    txtToHeat.Text = IIf(IsDBNull(e.Item.Cells(2).Text), "", e.Item.Cells(2).Text)
                    Try
                        txtStartDate.Text = IIf(IsDBNull(e.Item.Cells(3).Text), Now.Date, e.Item.Cells(3).Text)
                    Catch exp As Exception
                        txtStartDate.Text = Now.Date
                    End Try
                    Try
                        txtStartTime.Text = IIf(IsDBNull(e.Item.Cells(4).Text), Now.Date, e.Item.Cells(4).Text)
                    Catch exp As Exception
                        txtStartTime.Text = "00:00"
                    End Try
                    Try
                        txtEndDate.Text = IIf(IsDBNull(e.Item.Cells(5).Text), Now.Date, e.Item.Cells(5).Text)
                    Catch exp As Exception
                        txtEndDate.Text = Now.Date
                    End Try
                    Try
                        txtEndTime.Text = IIf(IsDBNull(e.Item.Cells(6).Text), Now.Date, e.Item.Cells(6).Text)
                    Catch exp As Exception
                        txtEndTime.Text = "00:00"
                    End Try
                    txtRemarks.Text = IIf(IsDBNull(e.Item.Cells(7).Text), "", e.Item.Cells(7).Text.Replace("&nbsp;", ""))
                    lblSlNo.Text = IIf(IsDBNull(e.Item.Cells(8).Text), 0, e.Item.Cells(8).Text)
                    GetFESLink()
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                End Try
                lblMessage.Text &= " FromHeat should not be changed during edting!"
                txtFromHeat.BackColor = System.Drawing.Color.Pink
            Case "Delete"
                Try
                    Done = New RWF.Melting().SaveFumeExtractionDetails(IIf(IsDBNull(e.Item.Cells(1).Text), "", e.Item.Cells(1).Text), Val(txtToHeat.Text), Now.Date, Now.Date, txtRemarks.Text.Trim, IIf(IsDBNull(e.Item.Cells(8).Text), 0, e.Item.Cells(8).Text), True)
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                End Try
                If Done Then
                    Clear()
                    lblMessage.Text = "Records Deleted ! "
                    Try
                        GetFumeExtractionDetails()
                    Catch exp As Exception
                        lblMessage.Text &= exp.Message
                    End Try
                Else
                    lblMessage.Text = "Record Deletion failed ! "
                End If
        End Select

    End Sub

    Private Sub txtFromHeat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFromHeat.TextChanged
        lblMessage.Text = ""
        Try
            GetFESLink()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub GetFESLink()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        Dim dt As DataTable
        Try
            dt = RWF.Melting.GetFESLink(Val(txtFromHeat.Text))
            If dt.Rows.Count > 0 Then
                DataGrid2.DataSource = dt
                DataGrid2.DataBind()
            Else
                lblMessage.Text &= "No Fume Extraction Link available !"
            End If
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
        dt = Nothing
    End Sub

    Private Sub Clear()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        txtFromHeat.Text = ""
        txtToHeat.Text = ""
        txtRemarks.Text = ""
        txtStartDate.Text = Now.Date
        txtEndDate.Text = Now.Date
        txtStartTime.Text = "00:00"
        txtEndTime.Text = "00:00"
    End Sub
End Class
