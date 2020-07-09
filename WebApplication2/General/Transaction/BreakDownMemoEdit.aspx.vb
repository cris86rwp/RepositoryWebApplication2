Public Class BreakDownMemoEdit
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblDepartment_code As System.Web.UI.WebControls.Label
    Protected WithEvents txtOperator As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMachineCode As System.Web.UI.WebControls.Label
    Protected WithEvents lblTotal_time As System.Web.UI.WebControls.Label
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents btnClear As System.Web.UI.WebControls.Button
    Protected WithEvents btnExit As System.Web.UI.WebControls.Button
    Protected WithEvents Rangevalidator1 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents txtBDnFromDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBDnToDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBDnFromTime As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBDnToTime As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMemoNumber As System.Web.UI.WebControls.Label
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents CustomValidator1 As System.Web.UI.WebControls.CustomValidator
    Protected WithEvents lblMemoSlipNumber As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents ddlProductionAffected As System.Web.UI.WebControls.DropDownList
    Protected WithEvents chkExtEdit As System.Web.UI.WebControls.CheckBox
    Protected WithEvents lblGroupCode As System.Web.UI.WebControls.Label
    Protected WithEvents rblShop As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblBDCodeType As System.Web.UI.WebControls.Label
    Dim Notvalid As Boolean
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Calendar1 As System.Web.UI.WebControls.Calendar
    Protected WithEvents Calendar2 As System.Web.UI.WebControls.Calendar

    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
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
        'txtBDnFromDate.Text = CDate(Now.Date)
        Dim grp, app As String
        lblMessage.Text = ""
        Session("Apps") = "MMS"
        'txtBDnFromDate.Focus()
        'Session("UserID") = "013901"
        'Session("Group") = "WHLMLT"
        If Session("Group") = "MLDING" Then
            If Session("UserID") = "077500" OrElse Session("UserID") = "083571" OrElse Session("UserID") = "076857" OrElse Session("UserID") = "078060" Then
            Else
                chkExtEdit.Visible = False
            End If
        End If
        app = Session("Apps")
        If app.Equals("MMS") Then
            lblGroupCode.Text = Session("Group")
            lblDepartment_code.Text = "M"
        Else
            lblGroupCode.Text = Session("Group")
            grp = lblGroupCode.Text
            lblDepartment_code.Text = grp.Substring(0, 1)
            lblGroupCode.Text = grp.Substring(1)
        End If

        If Not Page.IsPostBack Then
            GetShopCodes()
            PopulateMemoNumber(chkExtEdit.Checked)
        End If
        txtBDnFromDate.ReadOnly = True
        txtBDnFromTime.ReadOnly = True
        grp = Nothing
        app = Nothing
    End Sub

    Private Sub GetShopCodes()
        Dim dt As DataTable
        dt = RWF.BreakDown.GetShopCodes(lblGroupCode.Text)
        rblShop.DataSource = dt
        rblShop.DataTextField = dt.Columns(0).ColumnName
        rblShop.DataValueField = dt.Columns(1).ColumnName
        rblShop.DataBind()
        rblShop.SelectedIndex = 0
        dt = Nothing
    End Sub

    Private Sub rblShop_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblShop.SelectedIndexChanged
        PopulateMemoNumber(chkExtEdit.Checked)
    End Sub

    Private Sub PopulateMemoNumber(Optional ByVal ExtendedEdit As Boolean = False)
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            DataGrid1.DataSource = RWF.BreakDown.PopulateMemoNumber(lblGroupCode.Text.Trim, rblShop.SelectedItem.Text.Trim, ExtendedEdit)
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Notvalid Then
            lblMessage.Text = "Invalid Time !"
            Exit Sub
        End If
        Dim BDMemoUpdate As New RWF.BreakDown()
        Try
            BDMemoUpdate.BDFromTime = Trim(txtBDnFromDate.Text) & " " & Trim(txtBDnFromTime.Text)
            Try
                BDMemoUpdate.BDToTime = Trim(txtBDnToDate.Text) & " " & Trim(txtBDnToTime.Text)
            Catch exp As Exception
                BDMemoUpdate.BDToTime = CDate("1/1/1900")
            End Try
            BDMemoUpdate.Remarks = IIf(IsDBNull(txtRemarks.Text.Trim), "", txtRemarks.Text.Trim)
            BDMemoUpdate.MemoNo = IIf(IsDBNull(lblMemoNumber.Text.Trim), "", lblMemoNumber.Text.Trim)
            BDMemoUpdate.Shop = IIf(IsDBNull(rblShop.SelectedItem.Text.Trim), "", rblShop.SelectedItem.Text.Trim)
            BDMemoUpdate.Group = IIf(IsDBNull(lblGroupCode.Text.Trim), "", lblGroupCode.Text.Trim)
            BDMemoUpdate.Aff = IIf(IsDBNull(ddlProductionAffected.SelectedItem.Value), "", ddlProductionAffected.SelectedItem.Value)

            If BDMemoUpdate.UpdateMemo Then
                lblMessage.Text = "Record Updated..."
                Clear()
            Else
                lblMessage.Text = "Record Not Updated..."
            End If
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
        PopulateMemoNumber()
        BDMemoUpdate = Nothing
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Clear()
    End Sub

    Private Sub Clear()
        txtRemarks.Text = ""
        txtOperator.Text = ""
        txtBDnFromDate.Text = ""
        txtBDnToDate.Text = ""
        txtBDnFromTime.Text = ""
        txtBDnToTime.Text = ""
        lblMemoNumber.Text = ""
        lblMemoSlipNumber.Text = ""
        lblMachineCode.Text = ""
        lblBDCodeType.Text = ""
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Server.Transfer("/mms/selectModule.aspx")
    End Sub

    Private Sub DataGrid1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.ItemCommand
        Dim myBDnFromDateTime As String
        Dim myBDnToDateTime As String
        Select Case e.CommandName
            Case "Select"
                myBDnFromDateTime = e.Item.Cells(1).Text
                If myBDnFromDateTime <> "" Then
                    Dim myBdnFromArray As Array = Split(myBDnFromDateTime)
                    txtBDnFromDate.Text = Trim(myBdnFromArray(0))
                    If myBdnFromArray.Length > 1 Then
                        txtBDnFromTime.Text = Trim(myBdnFromArray(1))
                    End If
                    myBdnFromArray = Nothing
                End If
                myBDnToDateTime = e.Item.Cells(8).Text ' "01/01/1900 00:00"
                If myBDnToDateTime <> "" Then
                    Dim myBdnToArray As Array = Split(myBDnToDateTime)
                    txtBDnToDate.Text = Trim(myBdnToArray(0))
                    If myBdnToArray.Length > 1 Then
                        txtBDnToTime.Text = Trim(myBdnToArray(1))
                    End If
                    myBdnToArray = Nothing
                End If
                lblMachineCode.Text = e.Item.Cells(2).Text
                lblMemoNumber.Text = e.Item.Cells(3).Text
                lblMemoSlipNumber.Text = e.Item.Cells(4).Text
                txtRemarks.Text = IIf(IsDBNull((e.Item.Cells(5).Text)) Or e.Item.Cells(5).Text = "&nbsp;", "", e.Item.Cells(5).Text)
                txtOperator.Text = IIf(IsDBNull(e.Item.Cells(6).Text), "", e.Item.Cells(6).Text)
                Dim i As Integer
                If Not e.Item.Cells(7).Text Is Nothing Then
                    For i = 0 To ddlProductionAffected.Items.Count - 1
                        If ddlProductionAffected.Items(i).Value = e.Item.Cells(7).Text Then
                            ddlProductionAffected.SelectedIndex = i
                        End If
                    Next
                End If
                lblBDCodeType.Text = e.Item.Cells(9).Text
                i = Nothing
        End Select
        myBDnFromDateTime = Nothing
        myBDnToDateTime = Nothing
    End Sub


    Private Sub CustomValidator1_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CustomValidator1.ServerValidate
        lblMessage.Text = ""
        Dim dt1, dt2 As Date
        Dim dt1IsValid, dt2IsValid As Boolean
        dt1IsValid = False
        dt2IsValid = False
        Dim myBDnFromDateTime As String
        Dim myBDnToDateTime As String
        myBDnFromDateTime = Trim(txtBDnFromDate.Text) & " " & (txtBDnFromTime.Text)
        myBDnToDateTime = Trim(txtBDnToDate.Text) & " " & (txtBDnToTime.Text)

        Try
            dt1 = Format(CDate(myBDnFromDateTime), "yyyy/MM/dd HH:mm:ss.000")
            dt1IsValid = True
            dt2 = Format(CDate(myBDnToDateTime), "yyyy/MM/dd HH:mm:ss.000")
            dt2IsValid = True
            If dt2 > Date.Now Then
                lblMessage.Text &= "BreakDown To Time :'" & dt2 & "' Can Not Be Greater Than Current DateTime. "
                txtBDnToDate.Text = ""
                txtBDnToTime.Text = ""
            End If

            If dt1 > dt2 Then
                lblMessage.Text &= "BreakDown FromTime is more than BreakDown ToTime ! (From : '" & dt1 & "' To : '" & dt2 & "')"
                txtBDnToDate.Text = ""
                txtBDnToTime.Text = ""
            End If

        Catch exp As Exception
            If exp.Message.StartsWith("Cast") Then
                If dt1IsValid = False Then
                    lblMessage.Text &= " To Date:'" & txtBDnToDate.Text.Trim & "'  is not Valid. "
                    txtBDnToDate.Text = ""
                End If
            End If
        End Try
        If txtBDnToDate.Text = "" Or txtBDnToTime.Text = "" Then
            Notvalid = True
        End If
        dt1 = Nothing
        dt2 = Nothing
        dt1IsValid = Nothing
        dt2IsValid = Nothing
        myBDnFromDateTime = Nothing
        myBDnToDateTime = Nothing
    End Sub

    Private Sub chkExtEdit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkExtEdit.CheckedChanged
        If IsNothing(rblShop.SelectedItem) = False Then
            If rblShop.SelectedItem.Text <> "Select" Then
                PopulateMemoNumber(chkExtEdit.Checked)
            End If
        End If
    End Sub


    'Private Sub Calendar1_SelectionChanged(sender As Object, e As EventArgs) Handles Calendar1.SelectionChanged
    '    txtBDnFromDate.Text = CDate(Calendar1.SelectedDate.ToString("dd/MM/yyyy"))
    '    Calendar1.Visible = False
    'End Sub

    'Private Sub Calendar2_SelectionChanged(sender As Object, e As EventArgs) Handles Calendar2.SelectionChanged
    '    txtBDnToDate.Text = CDate(Calendar2.SelectedDate.ToString("dd/MM/yyyy"))
    '    Calendar2.Visible = False
    'End Sub

    Protected Sub txtBDnFromDate_TextChanged(sender As Object, e As EventArgs) Handles txtBDnFromDate.TextChanged

    End Sub

    Protected Sub txtBDnToDate_TextChanged(sender As Object, e As EventArgs) Handles txtBDnToDate.TextChanged
        'Dim startDate As DateTime = System.DateTime.Now.ToString("dd-MM-yyyy")

        'startDate = Convert.ToDateTime(txtBDnFromDate.Text)

        'Dim endDate As DateTime = Convert.ToDateTime(txtBDnToDate.Text)

        'If endDate > startDate Then
        '    Label2.Text = "Date is invalid"
        'End If

        'If Calendar1.VisibleDate.Year > Calendar2.VisibleDate.Year Or Calendar1.VisibleDate.Year = Calendar2.VisibleDate.Year And Calendar1.VisibleDate.Month >= Calendar2.VisibleDate.Month Then
        '    txtBDnToDate.Text = String.Empty

        'End If

    End Sub
    'Sub Date_Selected(ByVal sender As Object, ByVal e As EventArgs)
    '    txtBDnFromDate.Text = Calendar1.SelectedDate.ToShortDateString
    '    Calendar1.Visible = "false"
    'End Sub

    'Sub show_date()
    '    If Calendar1.Visible = "true" Then
    '        Calendar1.Visible = "false"
    '    Else
    '        Calendar1.Visible = "true"
    '        txtBDnFromDate.Text = ""
    '    End If
    'End Sub

    'Sub Date_Selected1(ByVal sender As Object, ByVal e As EventArgs)
    '    txtBDnToDate.Text = Calendar2.SelectedDate.ToShortDateString
    '    Calendar2.Visible = "false"
    'End Sub

    'Sub show_date1()
    '    If Calendar2.Visible = "true" Then
    '        Calendar2.Visible = "false"
    '    Else
    '        Calendar2.Visible = "true"
    '        txtBDnToDate.Text = ""
    '    End If
    'End Sub

    'Protected Sub getDate(sender As Object, e As EventArgs)

    '    Dim startDate As DateTime = Convert.ToDateTime(txtBDnFromDate.Text)
    '    Dim endDate As DateTime = Convert.ToDateTime(txtBDnToDate.Text)

    '    If endDate > startDate Then
    '        Label2.Text = "Date is invalid"
    '    End If
    'End Sub

    'Dim startDate As String
    '   startDate = DateTimePicker1.Value.ToString("yyyy/MM/dd")

    'Protected Sub DatesValidator_Validate(ByVal source As Object, ByVal args As ServerValidateEventArgs)

    'Dim startDate As DateTime = System.DateTime.Now.ToString("dd-MM-yyyy")

    'startDate = Convert.ToDateTime(txtBDnFromDate.Text)

    'Dim endDate As DateTime = Convert.ToDateTime(txtBDnToDate.Text)

    'If endDate > startDate Then
    '    args.IsValid = False
    'End If
    'End Sub


    'Dim date1 As DateTime = System.DateTime.Now.ToString("dd-MMM-yyyy")
    'Dim dt2 As DateTime = Convert.ToDateTime(txtBDnFromDate.Text)

    'Dim dt1 As DateTime = Convert.ToDateTime(date1)

    'If dt1 > dt2 Then
    '       txtBDnToDate.Text = ""
    'End If


    '    DateTime dt1 = New DateTime.Now;
    'String.Format("{0:dd-MMM-yyyy}", dt1);
    'DateTime dt2 = Convert.ToDateTime(txtDate.text);
    'String.Format("{0:dd-MMM-yyyy}", dt1);
    'int result = String.Compare(dt1, dt2, True);
    'String relationship;
    'If (result < 0)
    '   relationship = "is earlier than";
    'ElseIf (result == 0)
    '   relationship = "is the same time as";         
    'Else
    '   relationship = "is later than";

End Class
