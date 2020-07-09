Public Class NonRWFAxlesPcoEntryDelete
    Inherits System.Web.UI.Page
    Protected WithEvents lblMode As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblPcoEmpcode As System.Web.UI.WebControls.Label
    Protected WithEvents ddlQac As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblQacDt As System.Web.UI.WebControls.Label
    Protected WithEvents lblProductCode As System.Web.UI.WebControls.Label
    Protected WithEvents lblProdDescr As System.Web.UI.WebControls.Label
    Protected WithEvents lblRwfDrg As System.Web.UI.WebControls.Label
    Protected WithEvents lblCustDrg As System.Web.UI.WebControls.Label
    Protected WithEvents lblManufacturer As System.Web.UI.WebControls.Label
    Protected WithEvents lblContractor As System.Web.UI.WebControls.Label
    Protected WithEvents lblContract As System.Web.UI.WebControls.Label
    Protected WithEvents lblCurSupply As System.Web.UI.WebControls.Label
    Protected WithEvents lblPosted As System.Web.UI.WebControls.Label
    Protected WithEvents lblBalForPosting As System.Web.UI.WebControls.Label
    Protected WithEvents txtCastHeatNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCustAxleNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents BtnSave As System.Web.UI.WebControls.Button
    Protected WithEvents dgData As System.Web.UI.WebControls.DataGrid

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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Page.IsPostBack = False Then
            Dim oPcoAxleEntry As NonRwfAxles.CertifiedAxles
            lblMode.Text = "Delete"
            Dim blnDone As Boolean
            Session("UserID") = "081111"
            Dim oPcoEmpCode As New rwfGen.Employee()

            Try
                If oPcoEmpCode.Check(Session("UserID"), "PCOPCO") = False Then
                    lblMessage.Text = "Invalid login : " & Session("UserID") & ""
                Else
                    oPcoAxleEntry = New NonRwfAxles.CertifiedAxles(Session("UserID"))
                    blnDone = True
                End If
            Catch exp As Exception
                Try
                    If oPcoEmpCode.Check(Session("UserID") & "", "AXLREF") = False Then
                        lblMessage.Text = "Invalid login : " & Session("UserID") & ""
                    Else
                        oPcoAxleEntry = New NonRwfAxles.CertifiedAxles(Session("UserID"))
                        blnDone = True
                    End If
                Catch EXP1 As Exception
                    lblMessage.Text = EXP1.Message
                End Try
                If Not blnDone Then
                    lblMessage.Text = exp.Message
                End If
            End Try
            If blnDone = True Then
#Disable Warning BC42104 ' Variable is used before it has been assigned a value
                viewState("vPcoAxle") = oPcoAxleEntry
#Enable Warning BC42104 ' Variable is used before it has been assigned a value
                PopulateDdl()
                PopulateGrid()
                lblPcoEmpcode.Text = oPcoAxleEntry.EmpCode
                If lblMode.Text = "Delete" Then
                    BtnSave.Visible = True
                End If
            Else
                BtnSave.Visible = False
            End If
            oPcoEmpCode = Nothing
            oPcoAxleEntry = Nothing
            blnDone = Nothing
        End If
    End Sub
    Private Sub PopulateDdl()
        Dim dt As DataTable = CType(viewState("vPcoAxle"), NonRwfAxles.CertifiedAxles).DdlTable
        Dim dv As New DataView()
        dv.Table = dt
        dv.Sort = "ValFld Desc"
        ddlQac.DataSource = dv
        ddlQac.DataTextField = "TxtFld"
        ddlQac.DataValueField = "ValFld"
        ddlQac.DataBind()
        ddlQac.Items.Insert(0, "Select")
        ddlQac.Items(0).Selected = True
        dt.Dispose()
        dv.Dispose()
        dv = Nothing
        dt = Nothing
    End Sub
    Private Sub PopulateGrid()
        Dim ref As Long
        If ddlQac.SelectedItem.Text = "Select" Then
            ref = 0
        Else
            ref = ddlQac.SelectedItem.Value
        End If
        If ref > 0 Then
            dgData.DataSource = NonRwfAxles.PcoNonRwfAxleClass.PcoSavedNonRwfAxles(ref)
        Else
            dgData.DataSource = Nothing
        End If
        dgData.DataBind()
        ShowScore()
        ref = Nothing
    End Sub
    Private Sub ddlQac_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlQac.SelectedIndexChanged
        lblMessage.Text = ""
        If IsNothing(ddlQac.SelectedItem) = True Then
            Exit Sub
        End If
        Dim dv As New DataView()
        Try
            dv.Table = NonRwfAxles.PcoNonRwfAxleClass.RitesCertificateTable
            dv.RowFilter = "RefId = " & ddlQac.SelectedItem.Value

            lblProductCode.Text = dv(0)("ProdCode") & ""
            lblManufacturer.Text = dv(0)("Manufacturer") & ""
            lblCurSupply.Text = IIf(IsDBNull(dv(0)("CurSupply")), 0, dv(0)("CurSupply"))
            lblContract.Text = dv(0)("ContractReference") & ""
            lblContractor.Text = dv(0)("Contractor") & ""
            lblCustDrg.Text = dv(0)("CustDrg") & ""
            lblQacDt.Text = dv(0)("CertDt")

            dv.Table = NonRwfAxles.PcoNonRwfAxleClass.RwfProductTable(lblProductCode.Text)
            lblProdDescr.Text = dv(0)("Description") & ""
            lblRwfDrg.Text = dv(0)("Drawing_Number") & ""
            CType(viewState("vPcoAxle"), NonRwfAxles.CertifiedAxles).RitesReference = ddlQac.SelectedItem.Value
            ShowScore()
            PopulateGrid()
        Catch exp As Exception
            lblMessage.Text = "QAC Selection Error : " & exp.Message
        Finally
            dv.Dispose()
            dv = Nothing
        End Try
    End Sub
    Private Sub ShowScore()
        If ddlQac.SelectedItem.Text <> "Select" Then
            lblPosted.Text = NonRwfAxles.PcoNonRwfAxleClass.PcoSavedNonRwfAxles(ddlQac.SelectedItem.Value).Rows.Count
            lblBalForPosting.Text = Val(lblCurSupply.Text) - Val(lblPosted.Text)
        End If
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        lblMessage.Text = ""
        If txtCastHeatNo.Text.Trim.Length = 0 Then
            lblMessage.Text = "InVaild Cast/Heat Number '" & txtCastHeatNo.Text.Trim & "'!"
            Exit Sub
        ElseIf txtCustAxleNo.Text.Trim.Length = 0 Then
            lblMessage.Text = "InVaild Cast/Heat Number '" & txtCustAxleNo.Text.Trim & "'!"
            Exit Sub
        ElseIf ddlQac.SelectedIndex = 0 Then
            lblMessage.Text = "InVaild Rites QAC Number '" & ddlQac.SelectedItem.Text.Trim & "'!"
            Exit Sub
        End If
        Dim Done As Boolean
        Try
            If New NonRwfAxles.AMSReceivedAxles(Session("UserID")).DeleteRef(ddlQac.SelectedItem.Value, txtCustAxleNo.Text.Trim, txtCastHeatNo.Text.Trim) = True Then Done = True
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            If Done Then
                lblMessage.Text = "Deleted the axle number !"
                txtCustAxleNo.Text = ""
                txtCastHeatNo.Text = ""
            Else
                lblMessage.Text = "Deletion of the axle number failed!"
            End If
        End Try
        Try
            PopulateGrid()
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
        Done = Nothing
    End Sub
End Class
