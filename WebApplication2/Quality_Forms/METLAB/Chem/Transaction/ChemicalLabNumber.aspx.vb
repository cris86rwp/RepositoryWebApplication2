Public Class ChemicalLabNumber
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblLabNumber As System.Web.UI.WebControls.Label
    Protected WithEvents txtNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDBR As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSampleBatchNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLorry As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSupplier As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSampleNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTestedBy As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblUser As System.Web.UI.WebControls.Label
    Protected WithEvents txtNumberDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblSub As System.Web.UI.WebControls.Label
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents txtReferenceNote As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtremarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblTestID As System.Web.UI.WebControls.Label
    Protected WithEvents lblMaterialID As System.Web.UI.WebControls.Label
    Protected WithEvents txtBatchNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents dgLabNumbers As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtExpectedTestDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents pnlIDN As System.Web.UI.WebControls.Panel
    Protected WithEvents rblType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents ddlMaterialList As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox

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

        ' Page.Theme = themeValue
        Page.Theme = Session("Theme")
    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None
        'Put user code to initialize the page here
        lblTestID.Visible = False
        lblMaterialID.Visible = False
        rblType.Enabled = True
        If Not IsPostBack Then
            txtExpectedTestDate.Text = Now.Date
            rblType.SelectedIndex = 0
            SetType()
            lblUser.Text = Session("UserID")
            txtDate.Text = Now.Date
            Try
                GetLabNumber()
                FillSavedList()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
    Private Sub SetType()
        ddlMaterialList.Visible = False
        pnlIDN.Visible = False
        If rblType.SelectedIndex = 0 Then
            pnlIDN.Visible = True
        Else
            ddlMaterialList.Visible = True
            If rblType.SelectedIndex = 1 Then
                GetMaterialList()
            Else
                GetHardnessMaterialList()
            End If
        End If
    End Sub
    Private Sub GetMaterialList()
        Dim dt As DataTable
        dt = metLab.tables.GetMaterialList
        ddlMaterialList.DataSource = dt
        ddlMaterialList.DataTextField = dt.Columns(0).ColumnName
        ddlMaterialList.DataValueField = dt.Columns(1).ColumnName
        ddlMaterialList.DataBind()
    End Sub
    Private Sub GetHardnessMaterialList()
        Dim dt As DataTable
        dt = metLab.tables.GetHardnessMaterialList
        ddlMaterialList.DataSource = dt
        ddlMaterialList.DataTextField = dt.Columns(0).ColumnName
        ddlMaterialList.DataValueField = dt.Columns(1).ColumnName
        ddlMaterialList.DataBind()
    End Sub
    Private Sub GetLabNumber()
        lblMessage.Text = ""
        lblLabNumber.Text = metLab.tables.GetLabNumber(CDate(txtDate.Text))
    End Sub

    Private Sub txtNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumber.TextChanged
        lblMessage.Text = ""
        Dim dt As DataTable
        Clear()
        If rblType.SelectedItem.Text = "IDN" Then
            Try
                dt = metLab.tables.GetNumberDetails(rblType.SelectedItem.Value, txtNumber.Text.Trim)
                If dt.Rows.Count > 0 Then
                    txtNumberDate.Text = dt.Rows(0)("Dt")
                    txtDBR.Text = dt.Rows(0)("DBR")
                    txtSampleBatchNo.Text = dt.Rows(0)("DumpNo")
                    lblSub.Text = dt.Rows(0)("Sub")
                    txtReferenceNote.Text = dt.Rows(0)("Ref")
                    txtSampleNo.Text = dt.Rows(0)("SampleNo")
                    txtSupplier.Text = dt.Rows(0)("Supplier")
                    txtLorry.Text = dt.Rows(0)("Lorry")
                    lblTestID.Text = dt.Rows(0)("TestID")
                    lblMaterialID.Text = dt.Rows(0)("MaterialID")
                Else
                    txtNumber.Text = ""
                    lblMessage.Text = "InValid IDN number !"
                End If
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        Else
            Try
                lblTestID.Text = metLab.tables.GetTestID(ddlMaterialList.SelectedItem.Value)
                lblMaterialID.Text = ddlMaterialList.SelectedItem.Value
                If Val(lblMaterialID.Text) = 10003 OrElse Val(lblMaterialID.Text) = 10002 Then
                    dt = metLab.tables.GetCalcinedLimeData(txtNumber.Text.Trim, Val(lblMaterialID.Text))
                    If dt.Rows.Count > 0 Then
                        txtNumber.Text = ""
                        txtDBR.Text = dt.Rows(0)("dbr_number")
                        txtSampleBatchNo.Text = dt.Rows(0)("sample_batch_number")
                        txtSupplier.Text = dt.Rows(0)("supplier")
                        txtLorry.Text = dt.Rows(0)("lorry_number")
                        txtReferenceNote.Text = dt.Rows(0)("reference_note")
                    End If
                End If
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
        dt = Nothing
    End Sub
    Private Sub Clear()
        txtNumberDate.Text = ""
        txtDBR.Text = ""
        txtSampleBatchNo.Text = ""
        lblSub.Text = ""
        txtReferenceNote.Text = ""
        txtSampleNo.Text = ""
        txtSupplier.Text = ""
        txtLorry.Text = ""
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        If Val(lblMaterialID.Text) < 10000 Then
            lblMessage.Text = "InValid Matarial selection !"
            Clear()
            Exit Sub
        End If
        Dim oChemLabNum As New metLab.ChemicalTesting()
        Try
            oChemLabNum.lab_number = lblLabNumber.Text
            oChemLabNum.Remarks = txtremarks.Text.Trim
            oChemLabNum.idn_number = txtNumber.Text.Trim + " Dt : " + txtNumberDate.Text
            oChemLabNum.dbr_number = txtDBR.Text.Trim
            oChemLabNum.test_date = CDate(txtDate.Text)
            oChemLabNum.tested_by = txtTestedBy.Text
            oChemLabNum.test_code = Val(lblTestID.Text)
            oChemLabNum.sample_batch_number = txtSampleBatchNo.Text.Trim
            oChemLabNum.sample_number = txtSampleNo.Text.Trim
            oChemLabNum.supplier = txtSupplier.Text.Trim
            oChemLabNum.lorry_number = txtLorry.Text.Trim
            oChemLabNum.reference_note = txtReferenceNote.Text.Trim
            oChemLabNum.lab_code = Val(lblMaterialID.Text)
            oChemLabNum.user_id = lblUser.Text.Trim
            oChemLabNum.BatchNo = txtBatchNo.Text.Trim
            Try
                oChemLabNum.expected_test_date = CDate(txtExpectedTestDate.Text)
            Catch exp As Exception
                oChemLabNum.expected_test_date = Now.Date
            End Try
            oChemLabNum.SaveLabNumber(Val(lblTestID.Text), Val(lblMaterialID.Text))
            lblMessage.Text = oChemLabNum.Message
        Catch exp As Exception
            lblMessage.Text = oChemLabNum.Message
        End Try
        Try
            dgLabNumbers.CurrentPageIndex = 0
            dgLabNumbers.SelectedIndex = -1
            FillSavedList()
            GetLabNumber()
            Clear()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub FillSavedList()
        Dim dt As DataTable
        Try
            dt = metLab.tables.GetSavedLabNumbers(CDate(txtDate.Text))
            If Not dt Is Nothing Then
                If IsNothing(dgLabNumbers.CurrentPageIndex) Then dgLabNumbers.CurrentPageIndex = 0
                dgLabNumbers.DataSource = dt
                dgLabNumbers.DataBind()
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub rblType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblType.SelectedIndexChanged
        lblMessage.Text = ""
        SetType()
        txtNumber.Text = ""
        Clear()
        Try
            lblTestID.Text = metLab.tables.GetTestID(ddlMaterialList.SelectedItem.Value)
            lblMaterialID.Text = ddlMaterialList.SelectedItem.Value
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub ddlMaterialList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMaterialList.SelectedIndexChanged
        lblMessage.Text = ""
        txtNumber.Text = ""
        Clear()
        Try
            lblTestID.Text = metLab.tables.GetTestID(ddlMaterialList.SelectedItem.Value)
            lblMaterialID.Text = ddlMaterialList.SelectedItem.Value
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        lblMessage.Text = ""
        Try
            If CDate(txtDate.Text) > Now.Date Then
                txtDate.Text = ""
                lblMessage.Text = "Date cannot be greater than today !"
            Else
                FillSavedList()
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub ChemicalLabNumber_Error(sender As Object, e As EventArgs) Handles Me.[Error]

    End Sub

    Private Sub ChemicalLabNumber_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed

    End Sub
End Class
