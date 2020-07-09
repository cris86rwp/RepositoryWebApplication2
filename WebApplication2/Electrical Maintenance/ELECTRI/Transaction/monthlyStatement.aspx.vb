Public Class monthlyStatement
    Inherits System.Web.UI.Page
    Protected WithEvents RangeValidator1 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblMode As System.Web.UI.WebControls.Label
    Protected WithEvents txtKpctl As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDG As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtfurB As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCool As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtfurC As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWheelEss As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtHold As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtExtract As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtForge As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWheelNEss As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPreHeat As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCompress As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtANEssen As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCanteen As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtfurA As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtColony As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtColony1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtAEssen As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtAdmin As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtAssembly As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEmms As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnExit As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents txtaa As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtab As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtac As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtba As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtbb As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtbc As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtca As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtcb As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtcc As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtda As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtdb As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtdc As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblTotalA As System.Web.UI.WebControls.Label
    Protected WithEvents lblTotalB As System.Web.UI.WebControls.Label
    Protected WithEvents lblTotalC As System.Web.UI.WebControls.Label
    Protected WithEvents lblTotalABC As System.Web.UI.WebControls.Label
    Protected WithEvents btnCalculateEnergy As System.Web.UI.WebControls.Button
    Protected WithEvents txtCalculateHeat As System.Web.UI.WebControls.Button
    Protected WithEvents lblKp_Dg As System.Web.UI.WebControls.Label
    Protected WithEvents lblDiff As System.Web.UI.WebControls.Label
    Protected WithEvents lblTotalEnergy As System.Web.UI.WebControls.Label
    Protected WithEvents txtea As System.Web.UI.WebControls.TextBox
    Protected WithEvents txteb As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtec As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLOP As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtrwfgen As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPCS As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpump As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtstn_aux As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTotal_Steel_Scrap As System.Web.UI.WebControls.TextBox
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
        ' lblMode.Text = Request.QueryString("mode")
        lblMode.Text = "add"

        If Not Page.IsPostBack Then
            txtDate.Text = Date.Today
            '------------
            If lblMode.Text.Equals("edit") Then
                getData()
            End If
            '------------
        End If
    End Sub

    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        If Not IsDate(Trim(txtDate.Text)) Then
            lblMessage.Text = "Enter Date in 'dd/MM/yyyy' Format"
            txtDate.Text = ""
            Exit Sub
        End If

        If lblMode.Text.Equals("add") Then
            CheckDate()
        ElseIf lblMode.Text.Equals("edit") Then
            getData()
        End If
    End Sub

    Private Function CheckDate() As Boolean
        If lblMode.Text = "add" Then
            If Maintenance.ElecTables.CheckCDate(CDate(txtDate.Text.Trim)) Then
                lblMessage.Text = "Statement for the given date " & Trim(txtDate.Text) & " is already posted.."
                txtDate.Text = ""
                Return False
            Else
                lblMessage.Text = ""
                Return True
            End If
        End If
    End Function

    Private Function Setparameters() As Boolean

    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim Done As Boolean
        lblMessage.Text = ""
        Try
            CalculateHeat()
            CalculateEnergy()
            '            Done = New Maintenance.Electrical().ECons(CDate(txtDate.Text.Trim), Val(txtKpctl.Text), Val(txtDG.Text), Val(txtfurA.Text), Val(txtfurB.Text), Val(txtfurC.Text), Val(txtCool.Text), Val(txtWheelEss.Text), Val(txtWheelNEss.Text), Val(txtHold.Text), Val(txtPreHeat.Text), Val(txtExtract.Text), Val(txtCompress.Text), Val(txtAssembly.Text), Val(txtAEssen.Text), Val(txtANEssen.Text), Val(txtForge.Text), Val(txtCanteen.Text), Val(txtColony.Text), Val(txtAdmin.Text), Val(txtEmms.Text), Val(txtTotal_Steel_Scrap.Text), Val(txtaa.Text), Val(txtab.Text), Val(txtac.Text), Val(txtba.Text), Val(txtbb.Text), Val(txtbc.Text), Val(txtca.Text), Val(txtcb.Text), Val(txtcc.Text), Val(txtda.Text), Val(txtdb.Text), Val(txtdc.Text), Val(txtea.Text), Val(txteb.Text), Val(txtec.Text), Val(lblTotalA.Text), Val(lblTotalB.Text), Val(lblTotalC.Text), Val(txtLOP.Text), Val(txtrwfgen.Text), Val(txtPCS.Text), Val(txtpump.Text), Val(txtstn_aux.Text), Val(txtColony1.Text))
            Done = New Maintenance.Electrical().ECons(CDate(txtDate.Text.Trim), Val(txtKpctl.Text), Val(txtDG.Text), Val(txtfurA.Text), Val(txtfurB.Text), Val(txtfurC.Text), Val(txtWheelEss.Text), Val(txtWheelNEss.Text), Val(txtHold.Text), Val(txtPreHeat.Text), Val(txtExtract.Text), Val(txtCompress.Text), Val(txtANEssen.Text), Val(txtColony.Text), Val(txtAdmin.Text), Val(txtTotal_Steel_Scrap.Text), Val(txtaa.Text), Val(txtab.Text), Val(txtac.Text), Val(txtba.Text), Val(txtbb.Text), Val(txtbc.Text), Val(txtca.Text), Val(txtcb.Text), Val(txtcc.Text), Val(txtda.Text), Val(txtdb.Text), Val(txtdc.Text), Val(txtea.Text), Val(txteb.Text), Val(txtec.Text), Val(lblTotalA.Text), Val(lblTotalB.Text), Val(lblTotalC.Text), Val(txtPCS.Text), Val(txtpump.Text), Val(txtstn_aux.Text), Val(txtColony1.Text))

        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If Done Then
            lblMessage.Text = "Data Updated !"
        Else
            lblMessage.Text &= ". Data Updatedation Failed !..."
        End If
    End Sub

    Private Sub getData()
        lblMessage.Text = ""
        Dim dt As DataTable
        Try
            dt = Maintenance.ElecTables.getData(CDate(txtDate.Text.Trim), CDate(txtDate.Text.Trim))
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If dt.Rows.Count <= 0 Then
            lblMessage.Text = "No Data exists for the given date " & Trim(txtDate.Text) '& " is already posted.."
            txtDate.Text = ""
            Exit Sub
        Else
            txtKpctl.Text = dt.Rows(0)("kebrdng")
            txtDG.Text = dt.Rows(0)("dgenergy")
            txtfurA.Text = dt.Rows(0)("furnace_a")
            txtfurB.Text = dt.Rows(0)("furnace_b")
            txtfurC.Text = dt.Rows(0)("furnace_c")
            ' txtCool.Text = dt.Rows(0)("cooling")
            txtWheelEss.Text = dt.Rows(0)("w_essen")
            txtWheelNEss.Text = dt.Rows(0)("w_nessen")
            txtHold.Text = dt.Rows(0)("holding")
            txtPreHeat.Text = dt.Rows(0)("preheat")
            txtExtract.Text = dt.Rows(0)("fume_ex")
            txtCompress.Text = dt.Rows(0)("comprsr")
            'txtAssembly.Text = dt.Rows(0)("assembly")
            'txtAEssen.Text = dt.Rows(0)("a_essen")
            txtANEssen.Text = dt.Rows(0)("a_nessen")
            'txtForge.Text = dt.Rows(0)("forging")
            txtColony.Text = dt.Rows(0)("colony")
            txtAdmin.Text = dt.Rows(0)("admin")
            'txtEmms.Text = dt.Rows(0)("emms")
            'txtCanteen.Text = dt.Rows(0)("canteen")
            ' txtLOP.Text = dt.Rows(0)("lop")
            'txtrwfgen.Text = dt.Rows(0)("rwfgen")
            txtPCS.Text = dt.Rows(0)("PCS")
            txtpump.Text = dt.Rows(0)("PUMP")
            txtstn_aux.Text = dt.Rows(0)("Stn_Aux")
            txtColony1.Text = dt.Rows(0)("Colony1")
            txtTotal_Steel_Scrap.Text = dt.Rows(0)("totalsteel")

            txtaa.Text = dt.Rows(0)("slaba_a")
            txtab.Text = dt.Rows(0)("slaba_b")
            txtac.Text = dt.Rows(0)("slaba_c")

            txtba.Text = dt.Rows(0)("slabb_a")
            txtbb.Text = dt.Rows(0)("slabb_b")
            txtbc.Text = dt.Rows(0)("slabb_c")

            txtca.Text = dt.Rows(0)("slabc_a")
            txtcb.Text = dt.Rows(0)("slabc_b")
            txtcc.Text = dt.Rows(0)("slabc_c")

            txtda.Text = dt.Rows(0)("slabd_a")
            txtdb.Text = dt.Rows(0)("slabd_b")
            txtdc.Text = dt.Rows(0)("slabd_c")
            '-----------------------Changed By Mohith on 16/05/2003--------------
            txtea.Text = IIf(IsDBNull(dt.Rows(0)("slabe_a")), 0, dt.Rows(0)("slabe_a"))
            txteb.Text = IIf(IsDBNull(dt.Rows(0)("slabe_b")), 0, dt.Rows(0)("slabe_b"))
            txtec.Text = IIf(IsDBNull(dt.Rows(0)("slabe_c")), 0, dt.Rows(0)("slabe_c"))
            '--------------------------------------------------------------------

            lblTotalA.Text = dt.Rows(0)("heat_a")
            lblTotalB.Text = dt.Rows(0)("heat_b")
            lblTotalC.Text = dt.Rows(0)("heat_c")
        End If
    End Sub

    Private Function CheckNumeric() As Boolean
        Dim ctrl As Control
        Dim ctrltext As TextBox
        'ctrl = System.Web.UI.WebControls.TextBoxControlBuilder.CreateBuilderFromType
        For Each ctrl In Page.Controls
            ' = FindControl(ctrl.ID)
            ctrltext.Text = CType(ctrl, TextBox).Text
            If Not IsNumeric(Trim(ctrltext.Text)) Then
                lblMessage.Text = "Numeric Please"
                Return False
            End If
        Next
        lblMessage.Text = ""
        Return True
    End Function


    Private Sub txtCalculateHeat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCalculateHeat.Click
        CalculateHeat()
    End Sub

    Private Sub CalculateHeat()
        lblTotalA.Text = CDbl(txtaa.Text) + CDbl(txtba.Text) + CDbl(txtca.Text) + CDbl(txtda.Text) + CDbl(txtea.Text)
        lblTotalB.Text = CDbl(txtab.Text) + CDbl(txtbb.Text) + CDbl(txtcb.Text) + CDbl(txtdb.Text) + CDbl(txteb.Text)
        lblTotalC.Text = CDbl(txtac.Text) + CDbl(txtbc.Text) + CDbl(txtcc.Text) + CDbl(txtdc.Text) + CDbl(txtec.Text)
        lblTotalABC.Text = CDbl(lblTotalA.Text) + CDbl(lblTotalB.Text) + CDbl(lblTotalC.Text)
    End Sub

    Private Sub btnCalculateEnergy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalculateEnergy.Click
        CalculateEnergy()
    End Sub

    Private Sub CalculateEnergy()
        lblKp_Dg.Text = CDbl(txtKpctl.Text) + CDbl(txtDG.Text)
        ' lblTotalEnergy.Text = CDbl(txtfurA.Text) + CDbl(txtfurB.Text) + CDbl(txtfurC.Text) + CDbl(txtCool.Text) + CDbl(txtWheelEss.Text) + CDbl(txtWheelNEss.Text) + CDbl(txtPreHeat.Text) + CDbl(txtHold.Text) + CDbl(txtExtract.Text) + CDbl(txtCompress.Text) + CDbl(txtAssembly.Text) + CDbl(txtAEssen.Text) + CDbl(txtANEssen.Text) + CDbl(txtForge.Text) + CDbl(txtCanteen.Text) + CDbl(txtColony.Text) + CDbl(txtColony1.Text) + CDbl(txtAdmin.Text) + CDbl(txtEmms.Text) + CDbl(txtLOP.Text) + CDbl(txtrwfgen.Text)
        lblTotalEnergy.Text = CDbl(txtfurA.Text) + CDbl(txtfurB.Text) + CDbl(txtfurC.Text) + CDbl(txtWheelEss.Text) + CDbl(txtWheelNEss.Text) + CDbl(txtPreHeat.Text) + CDbl(txtHold.Text) + CDbl(txtExtract.Text) + CDbl(txtCompress.Text) + CDbl(txtANEssen.Text) + CDbl(txtColony.Text) + CDbl(txtColony1.Text) + CDbl(txtAdmin.Text) + CDbl(txtPCS.Text) + CDbl(txtpump.Text) + CDbl(txtstn_aux.Text)
        lblDiff.Text = CDbl(lblKp_Dg.Text) - CDbl(lblTotalEnergy.Text)
    End Sub


End Class
