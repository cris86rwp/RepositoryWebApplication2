Imports System.Data
Imports System.Data.SqlClient

Public Class WheelShopFloorBalanceReconcilation
    Inherits System.Web.UI.Page
    Protected WithEvents txtInputDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlShift As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtOperator As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtBoxNQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents txt840Qty As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBGCQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMGCQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtOthersQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCBForDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txt915DQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEMUBGQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEMUQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDisQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWhlQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Cal1 As System.Web.UI.WebControls.Calendar
    Protected WithEvents WheelShopCB As System.Web.UI.WebControls.DataGrid
    Public con As New SqlConnection(ConfigurationManager.AppSettings("con"))

#Region " Web Form Designer Generated Code "
    Dim i As String
    Dim qty As String
    Dim strSql As String
    'This call is required by the Web Form Designer.
    '<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    'End Sub

    'Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
    '    'CODEGEN: This method call is required by the Web Form Designer
    '    'Do not modify it using the code editor.
    '    InitializeComponent()
    'End Sub

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
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        'Put user code to initialize the page here

        If Page.IsPostBack = False Then
            Session("Group") = "PCOPCO"
            Session("UserID") = "078844"

            Try
                If IsNothing(Session("group")) OrElse CStr(Session("group")) = "" OrElse IsNothing(Session("userID")) OrElse CStr(Session("UserID")) = "" Then
                    Response.Redirect("InvalidSession.aspx")
                    Exit Sub
                End If
                If Session("group") <> "PCOPCO" Then
                    Response.Redirect("InvalidSession.aspx")
                    Exit Sub
                End If

                txtInputDate.Text = CDate(Now.Date)

            Catch exp As Exception
                Response.Redirect("InvalidSession.aspx")
                Exit Sub
            End Try
        End If
        ' Ddlshift_SelectedIndexChanged(sender, e)
    End Sub
    Private Sub getLastData()
        Dim dt As Date
        Try
            dt = RWF.AWMCLR.GetLastDate
            txtCBForDate.Text = dt
            ViewState("ReqdDate") = dt
            btnSave.Enabled = True
        Catch exp As Exception
            lblMessage.Text = exp.Message
            btnSave.Enabled = False
            Exit Sub
        End Try
        dt = Nothing
        btnSave.Enabled = True
        txtCBForDate.ReadOnly = True
        ' Get Existing Closing Balances
        ' Get Existing Closing Balances
        Dim sqlrdr As DataTable
        Try
            sqlrdr = RWF.AWMCLR.GetWheelShopFloorBalance(CDate(txtCBForDate.Text))
            If sqlrdr.Rows.Count > 0 Then
                Dim i As Integer
                i = 0
                For i = 0 To sqlrdr.Rows.Count - 1
                    If sqlrdr.Rows(i)("Product_code") = "BoxN" Then
                        txtBoxNQty.Text = IIf(IsDBNull(sqlrdr.Rows(i)("Closing_Balance")), "0", sqlrdr.Rows(i)("Closing_Balance"))
                    End If
                    'If sqlrdr.Rows(i)("Product_code") = "840" Then
                    '    txt840Qty.Text = IIf(IsDBNull(sqlrdr.Rows(i)("Closing_Balance")), "0", sqlrdr.Rows(i)("Closing_Balance"))
                    'End If
                    'If sqlrdr.Rows(i)("Product_code") = "Others" Then
                    '    txtOthersQty.Text = IIf(IsDBNull(sqlrdr.Rows(i)("Closing_Balance")), "0", sqlrdr.Rows(i)("Closing_Balance"))
                    'End If
                    If sqlrdr.Rows(i)("Product_code") = "ICF" Then
                        txtBGCQty.Text = IIf(IsDBNull(sqlrdr.Rows(i)("Closing_Balance")), "0", sqlrdr.Rows(i)("Closing_Balance"))
                    End If
                    'If sqlrdr.Rows(i)("Product_code") = "Dis" Then
                    '    txtDisQty.Text = IIf(IsDBNull(sqlrdr.Rows(i)("Closing_Balance")), "0", sqlrdr.Rows(i)("Closing_Balance"))
                    'End If
                    'If sqlrdr.Rows(i)("Product_code") = "Whl" Then
                    '    txtWhlQty.Text = IIf(IsDBNull(sqlrdr.Rows(i)("Closing_Balance")), "0", sqlrdr.Rows(i)("Closing_Balance"))
                    'End If
                    'If sqlrdr.Rows(i)("Product_code") = "MGC" Then
                    '    txtMGCQty.Text = IIf(IsDBNull(sqlrdr.Rows(i)("Closing_Balance")), "0", sqlrdr.Rows(i)("Closing_Balance"))
                    'End If
                    'If sqlrdr.Rows(i)("Product_code") = "915as" Then
                    '    txt915DQty.Text = IIf(IsDBNull(sqlrdr.Rows(i)("Closing_Balance")), "0", sqlrdr.Rows(i)("Closing_Balance"))
                    'End If
                    'If sqlrdr.Rows(i)("Product_code") = "EMUBG" Then
                    '    txtEMUBGQty.Text = IIf(IsDBNull(sqlrdr.Rows(i)("Closing_Balance")), "0", sqlrdr.Rows(i)("Closing_Balance"))
                    'End If
                    'If sqlrdr.Rows(i)("Product_code") = "EMU" Then
                    '    txtEMUQty.Text = IIf(IsDBNull(sqlrdr.Rows(i)("Closing_Balance")), "0", sqlrdr.Rows(i)("Closing_Balance"))
                    'End If
                Next
                i = Nothing
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
            ClearData()
        Finally
            sqlrdr = Nothing
        End Try
    End Sub
    Private Sub ClearData()
        ' txtMGCQty.Text = ""
        txtBGCQty.Text = ""
        txtBoxNQty.Text = ""
        txtWhlQty.Text = ""
        txtDisQty.Text = ""
        'txtOthersQty.Text = ""
        'txt840Qty.Text = ""
        'txt915DQty.Text = ""
        'txtEMUBGQty.Text = ""
        'txtEMUQty.Text = ""
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim dInputDate, dCBforDate, dSavedDate As Date
        Try
            dCBforDate = CDate(txtCBForDate.Text)
            dInputDate = CDate(txtInputDate.Text)
            dSavedDate = Now
            If dInputDate > Today.Date Then
                lblMessage.Text = "You cannot give future Date !"
                Exit Sub
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
            Exit Sub
        End Try
        Dim blnQtyGiven As Boolean
        blnQtyGiven = False
        If txtBoxNQty.Text <> "" Then
            If Val(txtBoxNQty.Text) < 0 Then
                lblMessage.Text = "Qty Less than 0 not meaningful "
                Exit Sub
            Else
                blnQtyGiven = True
            End If
        ElseIf txtBGCQty.Text <> "" Then
            If Val(txtBGCQty.Text) < 0 Then
                lblMessage.Text = "Qty Less than 0 not meaningful "
                Exit Sub
            Else
                blnQtyGiven = True
            End If
        ElseIf txtDisQty.Text <> "" Then
            If Val(txtDisQty.Text) < 0 Then
                lblMessage.Text = "Qty Less than 0 not meaningful "
                Exit Sub
            Else
                blnQtyGiven = True
            End If
        ElseIf txtWhlQty.Text <> "" Then
            If Val(txtWhlQty.Text) < 0 Then
                lblMessage.Text = "Qty Less than 0 not meaningful "
                Exit Sub
            Else
                blnQtyGiven = True
            End If

            ''  ElseIf txt840Qty.Text <> "" Then
            ''     If Val(txt840Qty.Text) < 0 Then
            '' lblMessage.Text = "Qty Less than 0 not meaningful "
            ''Exit Sub
            ''Else
            'blnQtyGiven = True
            'End If
            'ElseIf txtMGCQty.Text <> "" Then
            '    If Val(txtMGCQty.Text) < 0 Then
            '        lblMessage.Text = "Qty Less than 0 not meaningful "
            '        Exit Sub
            '    Else
            '        blnQtyGiven = True
            '    End If

            'ElseIf txt915DQty.Text <> "" Then
            '    If Val(txt915DQty.Text) < 0 Then
            '        lblMessage.Text = "Qty Less than 0 not meaningful "
            '        Exit Sub
            '    Else
            '        blnQtyGiven = True
            '    End If
            'ElseIf txtEMUBGQty.Text <> "" Then
            '    If Val(txtEMUBGQty.Text) < 0 Then
            '        lblMessage.Text = "Qty Less than 0 not meaningful "
            '        Exit Sub
            '    Else
            '        blnQtyGiven = True
            '    End If
            'ElseIf txtEMUQty.Text <> "" Then
            '    If Val(txtEMUQty.Text) < 0 Then
            '        lblMessage.Text = "Qty Less than 0 not meaningful "
            '        Exit Sub
            '    Else
            '        blnQtyGiven = True
            '    End If
            'ElseIf txtOthersQty.Text <> "" Then
            '    If Val(txtOthersQty.Text) < 0 Then
            '        lblMessage.Text = "Qty Less than 0 not meaningful "
            '        Exit Sub
            '    Else
            '        blnQtyGiven = True
            '    End If
        End If
        'If txtOperator.Text = "" Then
        '    lblMessage.Text = "Operator Code not input/captured"
        '    Exit Sub
        'End If
        If blnQtyGiven = False Then
            lblMessage.Text = "Input Qty to atleast one head"
            Exit Sub
        End If

        'If dCBforDate <> CType(ViewState("ReqdDate"), Date) Then
        '    lblMessage.Text = "Invalid Date for CB For Date"
        '    Exit Sub
        'End If
        Dim blnSaved As Boolean
        Dim dt As New DataTable()
        Dim dr As DataRow
        dt.TableName = "wheels"
        dt.Columns.Add("CBQty")
        dt.Columns.Add("ProductCode")
        Try
            If txtBoxNQty.Text <> "" Then
                dr = dt.NewRow
                dr("CBQty") = Val(txtBoxNQty.Text)
                dr("ProductCode") = "BoxN"
                dt.Rows.Add(dr)
            End If
            If txtBGCQty.Text <> "" Then
                dr = dt.NewRow
                dr("CBQty") = Val(txtBGCQty.Text)
                dr("ProductCode") = "ICF"
                dt.Rows.Add(dr)
            End If
            'If txtDisQty.Text <> "" Then
            '    dr = dt.NewRow
            '    dr("CBQty") = Val(txtDisQty.Text)
            '    dr("ProductCode") = "Dis"
            '    dt.Rows.Add(dr)
            'End If

            'If txtWhlQty.Text <> "" Then
            '    dr = dt.NewRow
            '    dr("CBQty") = Val(txtWhlQty.Text)
            '    dr("ProductCode") = "Whl"
            '    dt.Rows.Add(dr)
            'End If
            'If txt840Qty.Text <> "" Then
            '    dr = dt.NewRow
            '    dr("CBQty") = Val(txt840Qty.Text)
            '    dr("ProductCode") = "840"
            '    dt.Rows.Add(dr)
            'End If
            'If txtMGCQty.Text <> "" Then
            '    dr = dt.NewRow
            '    dr("CBQty") = Val(txtMGCQty.Text)
            '    dr("ProductCode") = "MGC"
            '    dt.Rows.Add(dr)
            'End If

            'If txt915DQty.Text <> "" Then
            '    dr = dt.NewRow
            '    dr("CBQty") = Val(txt915DQty.Text)
            '    dr("ProductCode") = "915as"
            '    dt.Rows.Add(dr)
            'End If
            'If txtEMUBGQty.Text <> "" Then
            '    dr = dt.NewRow
            '    dr("CBQty") = Val(txtEMUBGQty.Text)
            '    dr("ProductCode") = "EMUBG"
            '    dt.Rows.Add(dr)
            'End If
            'If txtEMUQty.Text <> "" Then
            '    dr = dt.NewRow
            '    dr("CBQty") = Val(txtEMUQty.Text)
            '    dr("ProductCode") = "EMU"
            '    dt.Rows.Add(dr)
            'End If
            'If txtOthersQty.Text <> "" Then
            '    dr = dt.NewRow
            '    dr("CBQty") = Val(txtOthersQty.Text)
            '    dr("ProductCode") = "Others"
            '    dt.Rows.Add(dr)
            'End If
            blnSaved = New RWF.AWMCLR().Save(CDate(txtInputDate.Text), ddlShift.SelectedItem.Text, txtOperator.Text, txtDisQty.Text, txtWhlQty.Text, CDate(txtCBForDate.Text), dt)
            If blnSaved Then
                lblMessage.Text = "Saved"
                lblMessage.ForeColor = System.Drawing.Color.Black
            Else
                lblMessage.Text = "Nothing to Save or Not Updated"
                lblMessage.ForeColor = System.Drawing.Color.Red
            End If
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
        Try
            'getLastData()
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
        dInputDate = Nothing
        dCBforDate = Nothing
        dSavedDate = Nothing
        dr = Nothing
        dt = Nothing
        blnSaved = Nothing
        blnQtyGiven = Nothing
    End Sub
    Protected Sub txtcbfdate_textchanged(sender As Object, e As EventArgs) Handles txtCBForDate.TextChanged

        ' Protected Sub Ddlshift_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlShift.SelectedIndexChanged
        Dim sqlstr1 As String
        'sqlstr1 = "select InputDate,InputShift,Operator_code,ProductCode,CBForDate,CBQty from mm_WheelShopFloorBalance_ReconciledCB where InputDate='" & Format(CDate(txtInputDate.Text), "MM/dd/yyyy") & "'  and InputShift='" & ddlShift.SelectedItem.Value & "'"
        sqlstr1 = "select InputDate,InputShift,Operator_code,ProductCode,CBForDate,CBQty,Dispatch,Wheels from mm_WheelShopFloorBalance_ReconciledCB where CBForDate='" & Format(CDate(txtCBForDate.Text), "MM/dd/yyyy") & "' and ProductCode in('BoxN', 'ICF')"

        Call BindDataGrid(sqlstr1)
    End Sub
    Private Sub BindDataGrid(ByVal strArg As String)
        Dim objCmd As SqlCommand
        Dim objDr As SqlDataReader

        If con.State = ConnectionState.Closed Then
            con.Open()
        Else
            con.Close()
            con.Open()
        End If
        Try
            objCmd = New SqlCommand(strArg, con)
            objDr = objCmd.ExecuteReader()
            Dim arr() As String
            WheelShopCB.DataSource = arr
            WheelShopCB.DataBind()
            WheelShopCB.DataSource = objDr
            WheelShopCB.DataBind()
        Catch exp As SqlException
            strSql = exp.StackTrace
            lblMessage.Text = "Line : " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message

        Catch exp As Exception
            strSql = exp.StackTrace
            lblMessage.Text = "Line : " & Mid(strSql, InStr(strSql, "line") + 5) & " Message : " + exp.Message
        End Try

        con.Close()

    End Sub
    Protected Sub WheelShopCB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles WheelShopCB.SelectedIndexChanged
        WheelShopCB.SelectedIndex = i
        qty = WheelShopCB.Items(i).Cells(5).Text

        If qty = "ICF" Then

            txtBGCQty.Text = WheelShopCB.Items(i).Cells(7).Text

            txtBoxNQty.Text = ""
        End If


        If qty = "BoxN" Then
            txtBoxNQty.Text = WheelShopCB.Items(i).Cells(7).Text
            txtBGCQty.Text = ""

        End If
        ddlShift.SelectedItem.Value = Trim(WheelShopCB.Items(i).Cells(3).Text)
        txtInputDate.Text = Trim(WheelShopCB.Items(i).Cells(2).Text)
        txtOperator.Text = Trim(WheelShopCB.Items(i).Cells(4).Text)
        txtCBForDate.Text = Trim(WheelShopCB.Items(i).Cells(6).Text)
        txtDisQty.Text = Trim(WheelShopCB.Items(i).Cells(8).Text)
        txtWhlQty.Text = Trim(WheelShopCB.Items(i).Cells(9).Text)
    End Sub
    Private Sub WheelShopCB_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles WheelShopCB.ItemCommand
        i = e.Item.ItemIndex()
    End Sub

    'Protected Sub cal1_SelectionChanged(sender As Object, e As EventArgs) Handles Cal1.SelectionChanged

    '    txtInputDate.Text = Cal1.SelectedDate.ToShortDateString
    '    Cal1.Visible = "False"

    'End Sub
    'Sub Date_selected(ByVal sender As Object, ByVal e As EventArgs)
    '    txtInputDate.Text = Cal1.SelectedDate.ToShortDateString
    '    Cal1.Visible = "False"

    'End Sub
    'Sub show_date()
    '    If Cal1.Visible = "True" Then
    '        Cal1.Visible = "False"
    '    Else
    '        Cal1.Visible = "True"
    '        txtInputDate.Text = ""
    '    End If
    'End Sub

    Protected Sub OnItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            CType(e.Item.FindControl("lblRowNumber"), Label).Text = (e.Item.ItemIndex + 1).ToString()
        End If
    End Sub
End Class
