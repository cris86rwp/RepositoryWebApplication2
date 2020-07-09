Public Class BHNChemicalValues
    Inherits System.Web.UI.Page
    Protected WithEvents btnProduct As System.Web.UI.WebControls.Button
    Protected WithEvents rdoProduct As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents lblProdType As System.Web.UI.WebControls.Label
    Protected WithEvents lblProductType As System.Web.UI.WebControls.Label
    Protected WithEvents lblProductNoCopy As System.Web.UI.WebControls.Label
    Protected WithEvents lblProductNo As System.Web.UI.WebControls.Label
    Protected WithEvents lblProductCopy As System.Web.UI.WebControls.Label
    Protected WithEvents pnlDetails As System.Web.UI.WebControls.Panel
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents btnProductNo As System.Web.UI.WebControls.Button
    Protected WithEvents ddlProductNo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblLabel As System.Web.UI.WebControls.Label
    Protected WithEvents lblProduct As System.Web.UI.WebControls.Label
    Protected WithEvents pnlProductNo As System.Web.UI.WebControls.Panel
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents pnlProduct As System.Web.UI.WebControls.Panel
    Protected WithEvents btnChangeProductNo As System.Web.UI.WebControls.Button
    Protected WithEvents btnChangeProduct As System.Web.UI.WebControls.Button
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents txtPS As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtV As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMo As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblPer As System.Web.UI.WebControls.Label
    Protected WithEvents txtAl As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblAlu As System.Web.UI.WebControls.Label
    Protected WithEvents txtCu As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNi As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCr As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtS As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtP As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSi As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMn As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtC As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEmployeeCode As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblInspector As System.Web.UI.WebControls.Label
    Protected WithEvents lblLabNumber As System.Web.UI.WebControls.Label
    Protected WithEvents pnlDetails1 As System.Web.UI.WebControls.Panel
    Protected WithEvents txtN As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtH As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblH As System.Web.UI.WebControls.Label
    Protected WithEvents lblPPM As System.Web.UI.WebControls.Label
    Protected WithEvents imgChemClassA As System.Web.UI.WebControls.Image
    Protected WithEvents pnlA As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlB As System.Web.UI.WebControls.Panel
    Protected WithEvents imgChemClassB As System.Web.UI.WebControls.Image
    Protected WithEvents pnlSpl As System.Web.UI.WebControls.Panel
    Protected WithEvents imgChemSpl As System.Web.UI.WebControls.Image
    Protected WithEvents lblClass As System.Web.UI.WebControls.Label
    Protected WithEvents lblMode As System.Web.UI.WebControls.Label
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

#End Region
    Shared themeValue As String


    Private Sub Page_PreInit(ByVal sender As Object, ByVal e As EventArgs)

        Page.Theme = themeValue
    End Sub

    Protected Sub dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        'Session("UserID") = "078844"
        'lblMode.Text = "add"
        If Not IsPostBack Then
            txtEmployeeCode.Text = Session("UserID")
            lblMode.Text = Request.QueryString("mode")
            pnlDetails.Visible = False
            pnlDetails1.Visible = False
            pnlProductNo.Visible = False
            lblClass.Visible = False
            Image()
        End If
    End Sub
    Private Sub Image()
        pnlA.Visible = False
        pnlB.Visible = False
        pnlSpl.Visible = False
        If lblClass.Text.Trim.Length > 0 Then
            If rdoProduct.SelectedItem.Value = "Axle" Then

            ElseIf rdoProduct.SelectedItem.Value = "Wheel" Then
                Select Case lblClass.Text.Trim
                    Case "A"
                        pnlA.Visible = True
                    Case "B"
                        pnlB.Visible = True
                    Case Else
                        pnlSpl.Visible = True
                End Select
            End If
        End If
    End Sub
    Private Sub btnProduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProduct.Click
        lblMessage.Text = ""
        If Not IsNothing(rdoProduct.SelectedItem) Then
            Try
                pnlProduct.Visible = False
                pnlProductNo.Visible = True
                If rdoProduct.SelectedItem.Value = "Axle" Then
                    GetAxles()
                    lblLabel.Text = "Axle Number"
                ElseIf rdoProduct.SelectedItem.Value = "Wheel" Then
                    getWheelNumbers()
                    lblLabel.Text = "Wheel Number"
                End If
                lblProduct.Text = rdoProduct.SelectedItem.Value
                Image()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        Else
            lblMessage.Text = "Please select Product !"
        End If
    End Sub
    Private Sub getWheelNumbers()
        ddlProductNo.Items.Clear()
        Dim dt As New DataTable()

        Try
            dt = metLab.tables.GetWheelNumbers(lblMode.Text)
            ddlProductNo.DataSource = dt
            ddlProductNo.DataTextField = dt.Columns(0).ColumnName
            ddlProductNo.DataValueField = dt.Columns(1).ColumnName
            ddlProductNo.DataBind()
            ddlProductNo.Items.Insert(0, "Select")
            ViewState("vdtw") = dt
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            dt.Dispose()
        End Try
    End Sub
    Private Sub GetAxles()
        ddlProductNo.Items.Clear()
        Dim dt As New DataTable()
        Try
            dt = metLab.tables.GetAxleNumbers(lblMode.Text.Trim)
            ddlProductNo.DataSource = dt
            ddlProductNo.DataTextField = dt.Columns(0).ColumnName
            ddlProductNo.DataValueField = dt.Columns(1).ColumnName
            ddlProductNo.DataBind()
            ViewState("vdta") = dt
            ddlProductNo.Items.Insert(0, "Select")
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            dt.Dispose()
        End Try
    End Sub
    Private Sub ShowValues()
        Dim dt As New DataTable()
        Try
            dt = metLab.tables.GetProdValues(rdoProduct.SelectedItem.Value.Trim, ddlProductNo.SelectedItem.Value)
            txtC.Text = IIf(IsDBNull(dt.Rows(0)("carbon")), "0.0", dt.Rows(0)("carbon"))
            txtP.Text = IIf(IsDBNull(dt.Rows(0)("phosphorus")), "0.0", dt.Rows(0)("phosphorus"))
            txtMn.Text = IIf(IsDBNull(dt.Rows(0)("manganese")), "0.0", dt.Rows(0)("manganese"))
            txtS.Text = IIf(IsDBNull(dt.Rows(0)("sulphur")), "0.0", dt.Rows(0)("sulphur"))
            txtSi.Text = IIf(IsDBNull(dt.Rows(0)("silicon")), "0.0", dt.Rows(0)("silicon"))
            txtCr.Text = IIf(IsDBNull(dt.Rows(0)("chromium")), "0.0", dt.Rows(0)("chromium"))
            txtNi.Text = IIf(IsDBNull(dt.Rows(0)("nickle")), "0.0", dt.Rows(0)("nickle"))
            txtCu.Text = IIf(IsDBNull(dt.Rows(0)("copper")), "0.0", dt.Rows(0)("copper"))
            txtMo.Text = IIf(IsDBNull(dt.Rows(0)("molybdenum")), "0.0", dt.Rows(0)("molybdenum"))
            txtV.Text = IIf(IsDBNull(dt.Rows(0)("vanadium")), "0.0", dt.Rows(0)("vanadium"))
            txtPS.Text = IIf(IsDBNull(dt.Rows(0)("phosphorus_sulphur")), "0.0", dt.Rows(0)("phosphorus_sulphur"))
            txtN.Text = IIf(IsDBNull(dt.Rows(0)("nitrogen")), "0.0", dt.Rows(0)("nitrogen"))
            If rdoProduct.SelectedItem.Value = "Wheel" Then
                txtAl.Text = IIf(IsDBNull(dt.Rows(0)("alunimum")), "0.0", dt.Rows(0)("alunimum"))
                txtH.Text = IIf(IsDBNull(dt.Rows(0)("hydrogen")), "0.0", dt.Rows(0)("hydrogen"))
            End If
            'txtEmployeeCode.Text = IIf(IsDBNull(dt.Rows(0)("EmpCode")), "", dt.Rows(0)("EmpCode"))
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
        End Try
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        lblMessage.Text = ""
        clear()
        rdoProduct.SelectedItem.Selected = False
        pnlProduct.Visible = True
        pnlProductNo.Visible = False
        pnlDetails.Visible = False
        pnlDetails1.Visible = False
        Image()
    End Sub
    Private Sub clear()
        lblClass.Text = ""
        txtH.Text = "0.0"
        txtN.Text = "0.0"
        txtC.Text = "0.0"
        txtP.Text = "0.0"
        txtMn.Text = "0.0"
        txtS.Text = "0.0"
        txtSi.Text = "0.0"
        txtCr.Text = "0.0"
        txtNi.Text = "0.0"
        txtCu.Text = "0.0"
        txtV.Text = "0.0"
        txtMo.Text = "0.0"
        txtPS.Text = "0.0"
    End Sub
    Private Sub getProdType()
        lblProdType.Text = ""
        lblProductType.Text = ""
        lblClass.Text = ""
        Dim dt As New DataTable()
        Dim dv As New DataView()
        If rdoProduct.SelectedItem.Value = "Axle" Then
            dt = CType(ViewState("vdta"), DataTable)
        ElseIf rdoProduct.SelectedItem.Value = "Wheel" Then
            dt = CType(ViewState("vdtw"), DataTable)
        End If
        dv.Table = dt
        dv.RowFilter = "lab_number = '" & ddlProductNo.SelectedItem.Value & "'"
        lblProdType.Text = CStr(dv.Item(0)(2)).Trim
        lblProductType.Text = rdoProduct.SelectedItem.Value + " Type : "
        If rdoProduct.SelectedItem.Value = "Wheel" Then
            lblClass.Text = CStr(dv.Item(0)(3)).Trim
        End If
    End Sub
    Private Sub btnProductNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProductNo.Click
        lblMessage.Text = ""
        If IsNothing(ddlProductNo.SelectedIndex) OrElse ddlProductNo.SelectedIndex = 0 Then
            lblMessage.Text = " Select A Product Number "
            Exit Sub
        Else
            Try
                getProdType()
                lblProductCopy.Text = rdoProduct.SelectedItem.Value
                lblProductNoCopy.Text = ddlProductNo.SelectedItem.Text
                pnlProductNo.Visible = False
                pnlDetails.Visible = True
                pnlDetails1.Visible = True
                If ddlProductNo.SelectedIndex = 0 Then
                    rdoProduct.SelectedItem.Selected = False
                    pnlProduct.Visible = True
                    pnlDetails.Visible = False
                    pnlDetails1.Visible = False
                    Exit Sub
                Else
                    If lblMode.Equals("edit") Then
                        ShowValues()
                    End If
                    If rdoProduct.SelectedItem.Value = "Axle" Then
                        lblProductNo.Text = "Axle Number"
                        lblLabNumber.Text = ddlProductNo.SelectedItem.Value
                        lblInspector.Visible = True
                        txtEmployeeCode.Visible = True
                        lblAlu.Visible = False
                        txtAl.Visible = False
                        lblPer.Visible = False
                        lblH.Visible = False
                        txtH.Visible = False
                        lblPPM.Visible = False
                    ElseIf rdoProduct.SelectedItem.Value = "Wheel" Then
                        lblProductNo.Text = "Wheel Number"
                        lblLabNumber.Text = ddlProductNo.SelectedItem.Value
                        lblInspector.Visible = True
                        txtEmployeeCode.Visible = True
                        lblAlu.Visible = True
                        txtAl.Visible = True
                        lblPer.Visible = True
                        lblH.Visible = True
                        txtH.Visible = True
                        lblPPM.Visible = True
                    Else
                        clear()
                    End If
                End If
                Image()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
    Private Sub btnChangeProduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeProduct.Click
        clear()
        rdoProduct.SelectedItem.Selected = False
        pnlProduct.Visible = True
        pnlProductNo.Visible = False
        pnlDetails.Visible = False
        pnlDetails1.Visible = False
        Image()
    End Sub
    Private Sub btnChangeProductNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeProductNo.Click
        clear()
        pnlProduct.Visible = False
        pnlProductNo.Visible = True
        pnlDetails.Visible = False
        pnlDetails1.Visible = False
        Image()
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ddlProductNo.SelectedIndex = 0 Then
            lblMessage.Text = " Select A Product Number "
            Exit Sub
        Else
            Dim oPro As New metLab.Product()
            Session("oPro") = oPro
            Try
                CType(Session("oPro"), metLab.Product).LabNumber = lblLabNumber.Text
                CType(Session("oPro"), metLab.Product).EmployeeCode = txtEmployeeCode.Text.Trim
                CType(Session("oPro"), metLab.Product).carbon = txtC.Text.Trim
                CType(Session("oPro"), metLab.Product).phosphorus = txtP.Text.Trim
                CType(Session("oPro"), metLab.Product).manganese = txtMn.Text.Trim
                CType(Session("oPro"), metLab.Product).sulphur = txtS.Text.Trim
                CType(Session("oPro"), metLab.Product).silicon = txtSi.Text.Trim
                CType(Session("oPro"), metLab.Product).chromium = txtCr.Text.Trim
                CType(Session("oPro"), metLab.Product).nickle = txtNi.Text.Trim
                CType(Session("oPro"), metLab.Product).copper = txtCu.Text.Trim
                CType(Session("oPro"), metLab.Product).alunimum = txtAl.Text
                CType(Session("oPro"), metLab.Product).molybdenum = txtMo.Text.Trim
                CType(Session("oPro"), metLab.Product).vanadium = txtV.Text.Trim
                CType(Session("oPro"), metLab.Product).nitrogen = txtN.Text.Trim
                CType(Session("oPro"), metLab.Product).hydrogen = txtH.Text.Trim
                If CType(Session("oPro"), metLab.Product).SaveChemicalValues(rdoProduct.SelectedItem.Value.Trim, lblMode.Text) Then
                    lblMessage.Text = "Record Saved"
                Else
                    lblMessage.Text = CType(Session("oPro"), metLab.Product).Message
                End If
            Catch exp As Exception
                lblMessage.Text = exp.Message
                Exit Sub
            Finally
                clear()
                pnlProduct.Visible = False
                pnlProductNo.Visible = True
                pnlDetails.Visible = False
                pnlDetails1.Visible = False
                If rdoProduct.SelectedItem.Value.Trim = "Axle" Then
                    GetAxles()
                Else
                    getWheelNumbers()
                End If
            End Try
        End If
    End Sub
    Private Sub sumP_S()
        Try
            Dim p, s, p_s As Double
            If Not txtS.Text = "" Then
                s = txtS.Text
            End If
            If Not txtP.Text = "" Then
                p = txtP.Text
            End If
            p_s = p + s
            txtPS.Text = p_s
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub txtP_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtP.TextChanged
        sumP_S()
    End Sub
    Private Sub txtS_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtS.TextChanged
        sumP_S()
    End Sub
    Private Sub ddlProductNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlProductNo.SelectedIndexChanged
        If rdoProduct.SelectedItem.Value = "Axle" Or rdoProduct.SelectedItem.Value = "Wheel" Then
            lblLabNumber.Text = ddlProductNo.SelectedItem.Value
            If lblMode.Text.Equals("edit") Then
                ShowValues()
            End If
            Image()
        Else
            clear()
        End If
    End Sub
End Class
