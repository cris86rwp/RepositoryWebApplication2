Public Class ArcFurnaceReadings
    Inherits System.Web.UI.Page
    Protected WithEvents txtFurAInitial As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFurBInitial As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFurCInitial As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFurAFinal As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFurBFinal As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFurCFinal As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblFurADiff As System.Web.UI.WebControls.Label
    Protected WithEvents lblFurBDiff As System.Web.UI.WebControls.Label
    Protected WithEvents lblFurCDiff As System.Web.UI.WebControls.Label
    Protected WithEvents ddlMFarcA As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlMFarcB As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlMFarcC As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblArcAUnits As System.Web.UI.WebControls.Label
    Protected WithEvents lblArcBUnits As System.Web.UI.WebControls.Label
    Protected WithEvents lblArcCUnits As System.Web.UI.WebControls.Label
    Protected WithEvents txtarcBRemark As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtCdate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtarcARemark As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents txtarcCRemark As System.Web.UI.WebControls.TextBox
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
        Try

        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If Not IsPostBack Then
            txtCdate.Text = Now.Date
            Try
                getinitialvalues()
                getMFvalues()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
    Private Sub getinitialvalues()
        Dim ds As New DataSet()
        Try
            ds = Maintenance.ElecTables.getinitialvalues
            If Not ds.Tables(0).Rows.Count = 0 Then
                txtFurAInitial.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item(1)), 0, ds.Tables(0).Rows(0).Item(1))
                txtFurBInitial.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item(2)), 0, ds.Tables(0).Rows(0).Item(2))
                txtFurCInitial.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item(3)), 0, ds.Tables(0).Rows(0).Item(3))
                Dim intCnt1 As Integer
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(4)) Then
                    For intCnt1 = 0 To ddlMFarcA.Items.Count - 1
                        If ddlMFarcA.Items(intCnt1).Text = ds.Tables(0).Rows(0).Item(4) Then
                            ddlMFarcA.SelectedIndex = intCnt1
                            Exit For
                        End If
                    Next
                End If
                Dim intCnt2 As Integer
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(5)) Then
                    For intCnt2 = 0 To ddlMFarcB.Items.Count - 1
                        If ddlMFarcB.Items(intCnt2).Text = ds.Tables(0).Rows(0).Item(5) Then
                            ddlMFarcB.SelectedIndex = intCnt2
                            Exit For
                        End If
                    Next
                End If
                Dim intCnt3 As Integer
                If Not IsDBNull(ds.Tables(0).Rows(0).Item(6)) Then
                    For intCnt3 = 0 To ddlMFarcC.Items.Count - 1
                        If ddlMFarcC.Items(intCnt3).Text = ds.Tables(0).Rows(0).Item(6) Then
                            ddlMFarcC.SelectedIndex = intCnt3
                            Exit For
                        End If
                    Next
                End If
            End If
            txtFurAFinal.Text = ""
            txtFurBFinal.Text = ""
            txtFurCFinal.Text = ""
            lblFurADiff.Text = ""
            lblFurBDiff.Text = ""
            lblFurCDiff.Text = ""
            lblArcAUnits.Text = ""
            lblArcBUnits.Text = ""
            lblArcCUnits.Text = ""
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub getMFvalues()
        Dim dtMF As DataTable
        Try
            dtMF = Maintenance.ElecTables.getMFvaluesLimited
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        ddlMFarcA.DataSource = dtMF.DefaultView
        ddlMFarcA.DataTextField = "MF"
        ddlMFarcA.DataValueField = "MF"
        ddlMFarcA.DataBind()

        ddlMFarcB.DataSource = dtMF.DefaultView
        ddlMFarcB.DataTextField = "MF"
        ddlMFarcB.DataValueField = "MF"
        ddlMFarcB.DataBind()

        ddlMFarcC.DataSource = dtMF.DefaultView
        ddlMFarcC.DataTextField = "MF"
        ddlMFarcC.DataValueField = "MF"
        ddlMFarcC.DataBind()
    End Sub

    Private Sub ddlMFarcA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMFarcA.SelectedIndexChanged
        lblArcAUnits.Text = Val(lblFurADiff.Text) * Val(ddlMFarcA.SelectedItem.Text)
    End Sub

    Private Sub ddlMFarcB_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMFarcB.SelectedIndexChanged
        lblArcBUnits.Text = Val(lblFurBDiff.Text) * Val(ddlMFarcB.SelectedItem.Text)
    End Sub

    Private Sub ddlMFarcC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMFarcC.SelectedIndexChanged
        lblArcCUnits.Text = Val(lblFurCDiff.Text) * Val(ddlMFarcC.SelectedItem.Text)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim blnDone As Boolean = False
        Try
            lblArcAUnits.Text = (Val(txtFurAFinal.Text) - Val(txtFurAInitial.Text)) * Val(ddlMFarcA.SelectedItem.Text)
            lblArcBUnits.Text = (Val(txtFurBFinal.Text) - Val(txtFurBInitial.Text)) * Val(ddlMFarcB.SelectedItem.Text)
            lblArcCUnits.Text = (Val(txtFurCFinal.Text) - Val(txtFurCInitial.Text)) * Val(ddlMFarcC.SelectedItem.Text)
            blnDone = New Maintenance.Electrical().saveArcFurnaceData(CDate(txtCdate.Text.Trim), Val(txtFurAInitial.Text), Val(txtFurAFinal.Text.Trim), Val(txtFurBInitial.Text), Val(txtFurBFinal.Text), Val(txtFurCInitial.Text), Val(txtFurCFinal.Text), txtarcARemark.Text.Trim, txtarcBRemark.Text.Trim, txtarcCRemark.Text.Trim, IIf(IsDBNull(ddlMFarcA.SelectedItem.Text.Trim), "1", ddlMFarcA.SelectedItem.Text.Trim), IIf(IsDBNull(ddlMFarcB.SelectedItem.Text.Trim), "1", ddlMFarcB.SelectedItem.Text.Trim), IIf(IsDBNull(ddlMFarcC.SelectedItem.Text.Trim), "1", ddlMFarcC.SelectedItem.Text.Trim), Val(lblArcAUnits.Text), Val(lblArcBUnits.Text), Val(lblArcCUnits.Text))
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If blnDone Then
            lblMessage.Text = "Records saved"
        Else
            lblMessage.Text = "Records Not saved"
        End If
    End Sub

    Private Sub txtFurAFinal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFurAFinal.TextChanged
        lblMessage.Text = ""
        Dim d1, d2, val As Double
        Try
            Try
                d1 = txtFurAFinal.Text
                d2 = txtFurAInitial.Text
                val = (d1 - d2)
                lblFurADiff.Text = val
            Catch exp As Exception
                lblMessage.Text = "Enter Numeric Values"
                txtFurAInitial.Text = ""
                txtFurAFinal.Text = ""
                lblFurADiff.Text = ""
                Exit Sub
            End Try
            If d1 < d2 Then
                lblMessage.Text = "Final Reading is Less Than Initial"
                txtFurAInitial.Text = ""
                txtFurAFinal.Text = ""
                lblFurADiff.Text = ""
                Exit Sub
            End If
            If txtFurAFinal.Text = "" And txtFurAInitial.Text = "" Then
            Else
                lblFurADiff.Text = d1 - d2
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtFurBFinal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFurBFinal.TextChanged
        lblMessage.Text = ""
        Dim d1, d2, val As Double
        Try
            Try
                d1 = txtFurBFinal.Text
                d2 = txtFurBInitial.Text
                val = (d1 - d2)
                lblFurBDiff.Text = val
            Catch exp As Exception
                lblMessage.Text = "Enter Numeric Values"
                txtFurBInitial.Text = ""
                txtFurBFinal.Text = ""
                lblFurBDiff.Text = ""
                Exit Sub
            End Try
            If d1 < d2 Then
                lblMessage.Text = "Final Reading is Less Than Initial"
                txtFurBInitial.Text = ""
                txtFurBFinal.Text = ""
                lblFurBDiff.Text = ""
                Exit Sub
            End If
            If txtFurBFinal.Text = "" And txtFurBInitial.Text = "" Then

            Else
                lblFurBDiff.Text = d1 - d2
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtFurCFinal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFurCFinal.TextChanged
        lblMessage.Text = ""
        Dim d1, d2, val As Double
        Try
            Try
                d1 = txtFurCFinal.Text
                d2 = txtFurCInitial.Text
                val = (d1 - d2)
                lblFurCDiff.Text = val
            Catch exp As Exception
                lblMessage.Text = "Enter Numeric Values"
                txtFurCInitial.Text = ""
                txtFurCFinal.Text = ""
                lblFurCDiff.Text = ""
                Exit Sub
            End Try
            If d1 < d2 Then
                lblMessage.Text = "Final Reading is Less Than Initial"
                txtFurCInitial.Text = ""
                txtFurCFinal.Text = ""
                lblFurCDiff.Text = ""
                Exit Sub
            End If
            If txtFurCFinal.Text = "" And txtFurCInitial.Text = "" Then

            Else
                lblFurCDiff.Text = d1 - d2
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtCdate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCdate.TextChanged
        lblFurADiff.Text = ""
        lblFurBDiff.Text = ""
        lblFurCDiff.Text = ""
        lblArcAUnits.Text = ""
        lblArcBUnits.Text = ""
        lblArcCUnits.Text = ""
        txtarcARemark.Text = ""
        txtarcBRemark.Text = ""
        txtarcCRemark.Text = ""
        Dim ds As New DataSet()
        Try
            ds = Maintenance.ElecTables.getArcfurnaceValues(CDate(txtCdate.Text))
            'If CType(CType(ds.Tables(1).Rows(0).Item(0), Object), Integer).m_value = 0 Then
            If Not ds.Tables(1).Rows(0).Item(0) = 0 Then
                If Not ds.Tables(0).Rows.Count = 0 Then
                    txtFurAFinal.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item(1)), 0, ds.Tables(0).Rows(0).Item(1))
                    txtFurBFinal.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item(2)), 0, ds.Tables(0).Rows(0).Item(2))
                    txtFurCFinal.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item(3)), 0, ds.Tables(0).Rows(0).Item(3))
                    Dim intCnt1 As Integer
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(4)) Then
                        For intCnt1 = 0 To ddlMFarcA.Items.Count - 1
                            If ddlMFarcA.Items(intCnt1).Text = ds.Tables(0).Rows(0).Item(4) Then
                                ddlMFarcA.SelectedIndex = intCnt1
                                Exit For
                            End If
                        Next
                    End If
                    Dim intCnt2 As Integer
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(5)) Then
                        For intCnt2 = 0 To ddlMFarcB.Items.Count - 1
                            If ddlMFarcB.Items(intCnt2).Text = ds.Tables(0).Rows(0).Item(5) Then
                                ddlMFarcB.SelectedIndex = intCnt2
                                Exit For
                            End If
                        Next
                    End If
                    Dim intCnt3 As Integer
                    If Not IsDBNull(ds.Tables(0).Rows(0).Item(6)) Then
                        For intCnt3 = 0 To ddlMFarcC.Items.Count - 1
                            If ddlMFarcC.Items(intCnt3).Text = ds.Tables(0).Rows(0).Item(6) Then
                                ddlMFarcC.SelectedIndex = intCnt3
                                Exit For
                            End If
                        Next
                    End If
                End If
                txtFurAInitial.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item(7)), 0, ds.Tables(0).Rows(0).Item(7))
                txtFurBInitial.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item(8)), 0, ds.Tables(0).Rows(0).Item(8))
                txtFurCInitial.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item(9)), 0, ds.Tables(0).Rows(0).Item(9))
                txtarcARemark.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item(10)), "", ds.Tables(0).Rows(0).Item(10))
                txtarcBRemark.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item(11)), "", ds.Tables(0).Rows(0).Item(11))
                txtarcCRemark.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item(12)), "", ds.Tables(0).Rows(0).Item(12))
            Else
                getinitialvalues()
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            ds.Dispose()
        End Try
    End Sub
End Class
