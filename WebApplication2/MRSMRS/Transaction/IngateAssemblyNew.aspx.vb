Public Class IngateAssemblyNew
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtDtRemoved As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblShift As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtMouldNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPastIngate As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblPresentIng As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents grdIngateAssembly As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents txtDtFitted As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWheels_cast As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblSupplier As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtReason_for_removal As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents dgPastDetails As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnClear As System.Web.UI.WebControls.Button
    Protected WithEvents txtIngateDate As System.Web.UI.WebControls.TextBox
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
        If Page.IsPostBack = False Then
            ' Session("UserID") = "074421"
            'Session("UserID") = "072557"
            'Try
            '    Dim oChkEmp As New rwfGen.Employee()
            '    If oChkEmp.Check(Session("UserID"), "MRSMRS") = False Then
            '        'Response.Redirect("../wap/InvalidSession.aspx")
            '        Response.Redirect("InvalidSession.aspx")
            '    End If
            '    oChkEmp = Nothing
            'Catch exp As Exception
            '    ' Response.Redirect("../wap/InvalidSession.aspx")
            '    Response.Redirect("InvalidSession.aspx")
            'End Try
            Try
                getDateShift()
                PopulateGrid()
                FillReason()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
    Private Sub getDateShift()
        If Now.Hour = 0 OrElse Now.Hour = 1 OrElse Now.Hour = 2 OrElse Now.Hour = 3 OrElse Now.Hour = 4 OrElse Now.Hour = 5 Then
            txtIngateDate.Text = Now.Date.AddDays(-1)
            txtDtRemoved.Text = Now.Date.AddDays(-1)
        Else
            txtIngateDate.Text = Now.Date
            txtDtRemoved.Text = Now.Date
        End If
        Dim dt As Date
        Dim Shift As String
        dt = Now
        Select Case dt.Hour
            Case 6 To 13
                Shift = "A"
            Case 14 To 21
                Shift = "B"
            Case Else
                Shift = "C"
        End Select
        Dim i As Integer = 0
        rblShift.ClearSelection()
        For i = 0 To rblShift.Items.Count - 1
            If rblShift.Items(i).Text = Shift Then
                rblShift.Items(i).Selected = True
                Exit For
            End If
        Next
        dt = Nothing
        Shift = Nothing
    End Sub
    Private Sub setobj()
        If Not IsNothing(Session("Mld")) Then Session.Remove("Mld")
        Session.Remove("Mld")
        Dim oMld As New MouldMaster.Moulds()
        Session("Mld") = oMld
        CType(Session("Mld"), MouldMaster.Moulds).ForIngateAssembly = True
        CType(Session("Mld"), MouldMaster.Moulds).MouldDate = txtIngateDate.Text
        PopulateGrid()
        oMld = Nothing
    End Sub

    Private Sub txtIngateDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIngateDate.TextChanged
        lblMessage.Text = ""
        Try
            checkDate()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub checkDate()
        Dim dt As New Date()
        Try
            dt = txtIngateDate.Text.Trim
            If dt > Now.Date Then
                txtIngateDate.Text = ""
                lblMessage.Text = "Date cannot be greater than Current Date"
            Else
                txtIngateDate.Text = dt
                txtDtRemoved.Text = dt
                PopulateGrid()
            End If
        Catch exp As Exception
            txtIngateDate.Text = ""
            lblMessage.Text = exp.Message
        End Try
        dt = Nothing
    End Sub
    Private Sub PopulateGrid()
        Dim Dt As DataTable
        grdIngateAssembly.HorizontalAlign = HorizontalAlign.Left
        grdIngateAssembly.Visible = True
        Try
            Dt = MouldMaster.tables.getIngateAssemblyDetails(CDate(txtIngateDate.Text), rblShift.SelectedItem.Text)
            If Dt.Rows.Count > 5 Then
                grdIngateAssembly.AllowPaging = True
                grdIngateAssembly.PageSize = 5
                grdIngateAssembly.PagerStyle.Mode = PagerMode.NumericPages
            End If

            grdIngateAssembly.DataSource = Dt.DefaultView
            grdIngateAssembly.DataBind()
            If grdIngateAssembly.Items.Count = 0 Then
                lblMessage.Text = "No moulds Ingate fitted for the given date."
                grdIngateAssembly.Visible = False
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        Dt = Nothing
    End Sub
    Private Sub FillReason()
        Dim dt As DataTable
        Try
            dt = MouldMaster.tables.getIngateReasons
            txtReason_for_removal.DataSource = dt
            txtReason_for_removal.DataTextField = "Code"
            txtReason_for_removal.DataValueField = "description"
            txtReason_for_removal.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        dt = Nothing
    End Sub
    Private Sub Clear()
        dgPastDetails.DataSource = Nothing
        dgPastDetails.DataBind()
        txtPastIngate.Text = ""
        txtDtFitted.Text = ""
        txtWheels_cast.Text = 0
    End Sub
    Private Sub txtMouldNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMouldNumber.TextChanged
        lblMessage.Text = ""
        Clear()
        Try
            setobj()
            CType(Session("Mld"), MouldMaster.Moulds).MouldNumber = txtMouldNumber.Text.Trim
            txtPastIngate.Text = CType(Session("Mld"), MouldMaster.Moulds).PastIngate
            txtDtFitted.Text = CType(Session("Mld"), MouldMaster.Moulds).DtFitted
            txtWheels_cast.Text = CType(Session("Mld"), MouldMaster.Moulds).WheelsCast
            dgPastDetails.DataSource = CType(Session("Mld"), MouldMaster.Moulds).DragsPastDetails
            dgPastDetails.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub rblShift_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblShift.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            checkDate()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        rblSupplier.SelectedIndex = 0
        txtPastIngate.Text = ""
        rblPresentIng.SelectedIndex = 0
        txtDtFitted.Text = ""
        txtDtRemoved.Text = Now.Date
        txtWheels_cast.Text = ""
        txtMouldNumber.Text = ""
        txtReason_for_removal.SelectedIndex = 0
    End Sub

    Private Sub grdIngateAssembly_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdIngateAssembly.PageIndexChanged
        grdIngateAssembly.CurrentPageIndex = e.NewPageIndex
        grdIngateAssembly.EditItemIndex = -1
        Try
            PopulateGrid()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        If txtMouldNumber.Text.Trim.Length = 0 Then
            lblMessage.Text = "Please enter Mould Number"
            Exit Sub
        End If
        Dim i As Integer
        Dim done As Boolean
        For i = 0 To rblPresentIng.Items.Count - 1
            If rblPresentIng.Items(i).Selected = True Then
                done = True
                Exit For
            End If
        Next
        If done Then
            i = 0
            done = False
            For i = 0 To rblSupplier.Items.Count - 1
                If rblSupplier.Items(i).Selected = True Then
                    done = True
                    Exit For
                End If
            Next
            If done Then
                Try
                    If CType(Session("Mld"), MouldMaster.Moulds).AllowIngateAssembly Then
                        CType(Session("Mld"), MouldMaster.Moulds).MouldDate = CDate(txtIngateDate.Text)
                        CType(Session("Mld"), MouldMaster.Moulds).Shift = rblShift.SelectedItem.Text
                        CType(Session("Mld"), MouldMaster.Moulds).PastIngate = txtPastIngate.Text
                        CType(Session("Mld"), MouldMaster.Moulds).DtFitted = CDate(txtDtFitted.Text)
                        CType(Session("Mld"), MouldMaster.Moulds).WheelsCast = CInt(txtWheels_cast.Text)
                        CType(Session("Mld"), MouldMaster.Moulds).PresentIngate = rblPresentIng.SelectedItem.Text
                        CType(Session("Mld"), MouldMaster.Moulds).Supplier = rblSupplier.SelectedItem.Text
                        CType(Session("Mld"), MouldMaster.Moulds).DtRemoved = CDate(txtDtRemoved.Text)
                        CType(Session("Mld"), MouldMaster.Moulds).Reason = Trim(Replace(txtReason_for_removal.SelectedItem.Value, "'", "''"))
                        CType(Session("Mld"), MouldMaster.Moulds).AssembleIngate()
                        lblMessage.Text = CType(Session("Mld"), MouldMaster.Moulds).Message
                        Clear()
                    Else
                        lblMessage.Text = CType(Session("Mld"), MouldMaster.Moulds).Message
                    End If
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                Finally
                    setobj()
                End Try
            Else
                lblMessage.Text = "Please select Ingate Supplier !"
            End If
        Else
            lblMessage.Text = "Please select Ingate Type !"
        End If
        i = Nothing
        done = Nothing
    End Sub
End Class
