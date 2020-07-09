Public Class ShopWiseDailyEnergyConsumption
    Inherits System.Web.UI.Page
    Protected WithEvents RangeValidator1 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMode As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents btnExit As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
    Protected WithEvents btnSubmit_Clicks As System.Web.UI.WebControls.Button
    Protected WithEvents lblKPTCL As System.Web.UI.WebControls.Label
    Protected WithEvents txtKPTCL As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtGenerated As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtArc1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtArc2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtArc3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPump As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWheelEssential As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblGenerated As System.Web.UI.WebControls.Label
    Protected WithEvents lblArc1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblArc2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblArc3 As System.Web.UI.WebControls.Label
    Protected WithEvents lblPump As System.Web.UI.WebControls.Label
    Protected WithEvents lblWheelEssential As System.Web.UI.WebControls.Label
    Protected WithEvents txtWheelNonEssential As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblWheelNonEssential As System.Web.UI.WebControls.Label
    Protected WithEvents txtTube As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblTube As System.Web.UI.WebControls.Label
    Protected WithEvents txtMould As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFume As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMould As System.Web.UI.WebControls.Label
    Protected WithEvents lblFume As System.Web.UI.WebControls.Label
    Protected WithEvents txtCompressor As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtAssembly As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblCompressor As System.Web.UI.WebControls.Label
    Protected WithEvents lblAssembly As System.Web.UI.WebControls.Label
    Protected WithEvents lblAxelEssential As System.Web.UI.WebControls.Label
    Protected WithEvents lblAxelNonEssential As System.Web.UI.WebControls.Label
    Protected WithEvents txtAxelEssential As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtGFM As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCanteen As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtColony As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtColony1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtAdmin As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEmms As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblGFM As System.Web.UI.WebControls.Label
    Protected WithEvents lblCanteen As System.Web.UI.WebControls.Label
    Protected WithEvents lblColony As System.Web.UI.WebControls.Label
    Protected WithEvents lblColony1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblAdmin As System.Web.UI.WebControls.Label
    Protected WithEvents lblEmms As System.Web.UI.WebControls.Label
    Protected WithEvents txtAxelNonEssential As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblAux As System.Web.UI.WebControls.Label
    Protected WithEvents txtAux As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblDCOS As System.Web.UI.WebControls.Label
    Protected WithEvents txtDcos As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblTotalTonnageforDay As System.Web.UI.WebControls.Label
    Protected WithEvents lblTotalAF_C As System.Web.UI.WebControls.Label
    Protected WithEvents lblTotalAF_B As System.Web.UI.WebControls.Label
    Protected WithEvents lblTotalAF_A As System.Web.UI.WebControls.Label
    Protected WithEvents lblAF_Ce As System.Web.UI.WebControls.Label
    Protected WithEvents lblAF_Be As System.Web.UI.WebControls.Label
    Protected WithEvents lblAF_Ae As System.Web.UI.WebControls.Label
    Protected WithEvents lblAF_Cd As System.Web.UI.WebControls.Label
    Protected WithEvents lblAF_Bd As System.Web.UI.WebControls.Label
    Protected WithEvents lblAF_Ad As System.Web.UI.WebControls.Label
    Protected WithEvents lblAF_Cc As System.Web.UI.WebControls.Label
    Protected WithEvents lblAF_Bc As System.Web.UI.WebControls.Label
    Protected WithEvents lblAF_Ac As System.Web.UI.WebControls.Label
    Protected WithEvents lblAF_Cb As System.Web.UI.WebControls.Label
    Protected WithEvents lblAF_Bb As System.Web.UI.WebControls.Label
    Protected WithEvents lblAF_Ab As System.Web.UI.WebControls.Label
    Protected WithEvents lblAF_Ca As System.Web.UI.WebControls.Label
    Protected WithEvents lblAF_Ba As System.Web.UI.WebControls.Label
    Protected WithEvents lblAF_Aa As System.Web.UI.WebControls.Label
    Protected WithEvents lblLop As System.Web.UI.WebControls.Label
    'Protected WithEvents txtLop As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblRwfgen As System.Web.UI.WebControls.Label
    Protected WithEvents lblPCS As System.Web.UI.WebControls.Label
    Protected WithEvents txtCheckMeter As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblCheckMeter As System.Web.UI.WebControls.Label
    Protected WithEvents txtRwfgen As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPCS As System.Web.UI.WebControls.TextBox
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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        'Put user code to initialize the page here
        If Not IsPostBack Then
            lblMode.Text = Request.QueryString("mode")

            lblMode.Text = "edit"
            clear()
            Try
                '  txtDate.Text = Date.Today
                getselecteddate()
                getUnitsforMonth()
                '    txtDate.AutoPostBack = True
                'If lblMode.Text = "edit" Or lblMode.Text = "delete" Then
                '    getRemarks()
                'End If
                If lblMode.Text = "edit" Or lblMode.Text = "delete" Then
                    If Maintenance.ElecTables.CheckTopShopWiseData(CDate(txtDate.Text)) = 0 Then
                        getRemarks()
                    Else
                        lblMessage.Text = " Data present for this date : '" & CDate(txtDate.Text) & "' cannot be EDITED for changing data !"
                        txtDate.Text = ""
                        clear()
                        Exit Try
                    End If
                End If
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        lblMessage.Text = ""
        Dim dt As Date
        Dim blnOK As Boolean
        Try
            dt = CDate(txtDate.Text.Trim)
            blnOK = True
        Catch exp As Exception
            txtDate.Text = ""
            blnOK = False
            lblMessage.Text = exp.Message
        End Try
        If blnOK = True Then
            blnOK = False
        Else
            Exit Sub
        End If
        Try
            getUnitsforMonth()
            If lblMode.Text = "edit" Or lblMode.Text = "delete" Then
                If Maintenance.ElecTables.CheckTopShopWiseData(CDate(txtDate.Text)) = 0 Then
                    getRemarks()
                Else
                    lblMessage.Text = " Data present for this date : '" & CDate(txtDate.Text) & "' cannot be EDITED for changing data !"
                    txtDate.Text = ""
                    clear()
                    Exit Try
                End If
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub getselecteddate()
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        cmd.Connection.Open()
        cmd.CommandText = " select top 1 c_date from  ms_electrical_econs order by c_date desc "
        txtDate.Text = Convert.ToDateTime(cmd.ExecuteScalar())
        Try
            If cmd.Connection.State = ConnectionState.Closed Then cmd.Connection.Open()
            cmd.ExecuteScalar()
        Catch exp As Exception
            Throw New Exception(exp.Message)
        Finally
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
        End Try
    End Sub
    Private Sub getUnitsforMonth()
        Dim ds As New DataSet()
        Try
            ds = Maintenance.ElecTables.getUnitsforMonth(CDate(txtDate.Text.Trim))
            If ds.Tables(0).Rows.Count > 0 Then
                lblWheelEssential.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)(0)), 0, ds.Tables(0).Rows(0)(0))
                'lblWheelNonEssential.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)(1)), 0, ds.Tables(0).Rows(0)(1))
                lblTube.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)(1)), 0, ds.Tables(0).Rows(0)(1))
                lblMould.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)(2)), 0, ds.Tables(0).Rows(0)(2))
                lblCompressor.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)(3)), 0, ds.Tables(0).Rows(0)(3))
                lblFume.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)(4)), 0, ds.Tables(0).Rows(0)(4))
            End If
            If ds.Tables(1).Rows.Count > 0 Then
                'lblAxelEssential.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)(0)), 0, ds.Tables(1).Rows(0)(0))
                'lblAxelNonEssential.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)(1)), 0, ds.Tables(1).Rows(0)(1))
                ' lblGFM.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)(2)), 0, ds.Tables(1).Rows(0)(2))
                '  lblAssembly.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)(3)), 0, ds.Tables(1).Rows(0)(3))
                '   lblCanteen.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)(4)), 0, ds.Tables(1).Rows(0)(4))
                '    lblLop.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)(5)), 0, ds.Tables(1).Rows(0)(5))
            End If
            '            If ds.Tables(2).Rows.Count > 0 Then
            If ds.Tables(2).Rows.Count > 0 Then

                lblKPTCL.Text = IIf(IsDBNull(ds.Tables(2).Rows(0)(0)), 0, ds.Tables(2).Rows(0)(0))
                lblGenerated.Text = IIf(IsDBNull(ds.Tables(2).Rows(0)(1)), 0, ds.Tables(2).Rows(0)(1))
                lblArc1.Text = IIf(IsDBNull(ds.Tables(2).Rows(0)(2)), 0, ds.Tables(2).Rows(0)(2))
                lblArc2.Text = IIf(IsDBNull(ds.Tables(2).Rows(0)(3)), 0, ds.Tables(2).Rows(0)(3))
                lblArc3.Text = IIf(IsDBNull(ds.Tables(2).Rows(0)(4)), 0, ds.Tables(2).Rows(0)(4))
                lblPump.Text = IIf(IsDBNull(ds.Tables(2).Rows(0)(5)), 0, ds.Tables(2).Rows(0)(5))
                lblColony.Text = IIf(IsDBNull(ds.Tables(2).Rows(0)(6)), 0, ds.Tables(2).Rows(0)(6))
                lblColony1.Text = IIf(IsDBNull(ds.Tables(2).Rows(0)(7)), 0, ds.Tables(2).Rows(0)(7))
                lblAdmin.Text = IIf(IsDBNull(ds.Tables(2).Rows(0)(8)), 0, ds.Tables(2).Rows(0)(8))
                lblAux.Text = IIf(IsDBNull(ds.Tables(2).Rows(0)(9)), 0, ds.Tables(2).Rows(0)(9))
                '      lblEmms.Text = IIf(IsDBNull(ds.Tables(2).Rows(0)(9)), 0, ds.Tables(2).Rows(0)(9))
                '     lblDCOS.Text = IIf(IsDBNull(ds.Tables(2).Rows(0)(10)), 0, ds.Tables(2).Rows(0)(10))
                lblRwfgen.Text = IIf(IsDBNull(ds.Tables(2).Rows(0)(10)), 0, ds.Tables(2).Rows(0)(10))
                lblPCS.Text = IIf(IsDBNull(ds.Tables(2).Rows(0)(11)), 0, ds.Tables(2).Rows(0)(11))
                '       lblCheckMeter.Text = IIf(IsDBNull(ds.Tables(2).Rows(0)(12)), 0, ds.Tables(2).Rows(0)(12))
            End If
            If ds.Tables(3).Rows.Count > 0 Then
                lblTotalTonnageforDay.Text = IIf(IsDBNull(ds.Tables(3).Rows(0)("TotalTonnagefortheday")), 0, ds.Tables(3).Rows(0)("TotalTonnagefortheday"))
                lblAF_Aa.Text = IIf(IsDBNull(ds.Tables(3).Rows(0)("CodeAFAa")), 0, ds.Tables(3).Rows(0)("CodeAFAa"))
                lblAF_Ab.Text = IIf(IsDBNull(ds.Tables(3).Rows(0)("CodeAFAb")), 0, ds.Tables(3).Rows(0)("CodeAFAb"))
                lblAF_Ac.Text = IIf(IsDBNull(ds.Tables(3).Rows(0)("CodeAFAc")), 0, ds.Tables(3).Rows(0)("CodeAFAc"))
                lblAF_Ad.Text = IIf(IsDBNull(ds.Tables(3).Rows(0)("CodeAFAd")), 0, ds.Tables(3).Rows(0)("CodeAFAd"))
                lblAF_Ae.Text = IIf(IsDBNull(ds.Tables(3).Rows(0)("CodeAFAe")), 0, ds.Tables(3).Rows(0)("CodeAFAe"))
                lblTotalAF_A.Text = IIf(IsDBNull(ds.Tables(3).Rows(0)("TotalCodeAFA")), 0, ds.Tables(3).Rows(0)("TotalCodeAFA"))
                lblAF_Ba.Text = IIf(IsDBNull(ds.Tables(3).Rows(0)("CodeAFBa")), 0, ds.Tables(3).Rows(0)("CodeAFBa"))
                lblAF_Bb.Text = IIf(IsDBNull(ds.Tables(3).Rows(0)("CodeAFBb")), 0, ds.Tables(3).Rows(0)("CodeAFBb"))
                lblAF_Bc.Text = IIf(IsDBNull(ds.Tables(3).Rows(0)("CodeAFBc")), 0, ds.Tables(3).Rows(0)("CodeAFBc"))
                lblAF_Bd.Text = IIf(IsDBNull(ds.Tables(3).Rows(0)("CodeAFBd")), 0, ds.Tables(3).Rows(0)("CodeAFBd"))
                lblAF_Be.Text = IIf(IsDBNull(ds.Tables(3).Rows(0)("CodeAFBe")), 0, ds.Tables(3).Rows(0)("CodeAFBe"))
                lblTotalAF_B.Text = IIf(IsDBNull(ds.Tables(3).Rows(0)("TotalCodeAFB")), 0, ds.Tables(3).Rows(0)("TotalCodeAFB"))
                lblAF_Ca.Text = IIf(IsDBNull(ds.Tables(3).Rows(0)("CodeAFCa")), 0, ds.Tables(3).Rows(0)("CodeAFCa"))
                lblAF_Cb.Text = IIf(IsDBNull(ds.Tables(3).Rows(0)("CodeAFCb")), 0, ds.Tables(3).Rows(0)("CodeAFCb"))
                lblAF_Cc.Text = IIf(IsDBNull(ds.Tables(3).Rows(0)("CodeAFCc")), 0, ds.Tables(3).Rows(0)("CodeAFCc"))
                lblAF_Cd.Text = IIf(IsDBNull(ds.Tables(3).Rows(0)("CodeAFCd")), 0, ds.Tables(3).Rows(0)("CodeAFCd"))
                lblAF_Ce.Text = IIf(IsDBNull(ds.Tables(3).Rows(0)("CodeAFCe")), 0, ds.Tables(3).Rows(0)("CodeAFCe"))
                lblTotalAF_C.Text = IIf(IsDBNull(ds.Tables(3).Rows(0)("TotalCodeAFC")), 0, ds.Tables(3).Rows(0)("TotalCodeAFC"))
            End If

        Catch exp As Exception
            Throw New Exception("Data retrival error : " & exp.Message)
        Finally
            ds.Dispose()
        End Try
    End Sub

    Private Sub getRemarks()
        Dim ds As New DataSet()
        Try
            ds = Maintenance.ElecTables.getRemarks(CDate(txtDate.Text))
            If ds.Tables(0).Rows.Count > 0 Then
                txtKPTCL.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)(0)), "", ds.Tables(0).Rows(0)(0))
                txtGenerated.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)(1)), "", ds.Tables(0).Rows(0)(1))
                txtArc1.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)(2)), "", ds.Tables(0).Rows(0)(2))
                txtArc2.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)(3)), "", ds.Tables(0).Rows(0)(3))
                txtArc3.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)(4)), "", ds.Tables(0).Rows(0)(4))
                txtPump.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)(5)), "", ds.Tables(0).Rows(0)(5))
                txtColony.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)(6)), "", ds.Tables(0).Rows(0)(6))
                txtColony1.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)(7)), "", ds.Tables(0).Rows(0)(7))
                txtAdmin.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)(8)), "", ds.Tables(0).Rows(0)(8))
                'txtEmms.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)(8)), "", ds.Tables(0).Rows(0)(8))
                txtRwfgen.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)(9)), "", ds.Tables(0).Rows(0)(9))
                txtPCS.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)(10)), "", ds.Tables(0).Rows(0)(10))

                'txtCheckMeter.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)(10)), "", ds.Tables(0).Rows(0)(10))
            End If
            ' If ds.Tables(1).Rows.Count > 0 Then
            ' txtAxelEssential.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)(0)), "", ds.Tables(1).Rows(0)(0))
            'txtAxelNonEssential.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)(1)), "", ds.Tables(1).Rows(0)(1))
            'txtGFM.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)(2)), "", ds.Tables(1).Rows(0)(2))
            'txtAssembly.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)(3)), "", ds.Tables(1).Rows(0)(3))
            'txtCanteen.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)(4)), "", ds.Tables(1).Rows(0)(4))
            'txtLop.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)(5)), "", ds.Tables(1).Rows(0)(5))
            'End If
            If ds.Tables(1).Rows.Count > 0 Then
                txtWheelEssential.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)(0)), "", ds.Tables(1).Rows(0)(0))
                'txtWheelNonEssential.Text = IIf(IsDBNull(ds.Tables(2).Rows(0)(1)), "", ds.Tables(2).Rows(0)(1))
                txtTube.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)(1)), "", ds.Tables(1).Rows(0)(1))
                txtMould.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)(2)), "", ds.Tables(1).Rows(0)(2))
                txtCompressor.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)(3)), "", ds.Tables(1).Rows(0)(3))
                txtFume.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)(4)), "", ds.Tables(1).Rows(0)(4))
            End If
        Catch exp As Exception
            Throw New Exception("Data retrival error : " & exp.Message)
        Finally
            ds.Dispose()
        End Try

    End Sub

    Private Sub btnSubmit_Clicks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit_Clicks.Click
        lblMessage.Text = ""
        Dim blnDone As Boolean
        Try
            ' blnDone = New Maintenance.Electrical().saveShopWise(CDate(txtDate.Text), txtKPTCL.Text, txtGenerated.Text, txtArc1.Text.Trim, txtArc2.Text.Trim, txtArc3.Text.Trim, txtPump.Text, txtColony.Text, txtAdmin.Text, txtAux.Text, txtEmms.Text, txtDcos.Text, txtRwfgen.Text, txtAxelEssential.Text, txtAxelNonEssential.Text, txtGFM.Text, txtAssembly.Text, txtCanteen.Text, txtLop.Text, txtWheelEssential.Text, txtWheelNonEssential.Text, txtTube.Text, txtMould.Text, txtCompressor.Text, txtFume.Text, lblMode.Text, Val(lblKPTCL.Text), Val(lblGenerated.Text), Val(lblArc1.Text), Val(lblArc2.Text), Val(lblArc3.Text), Val(lblPump.Text), Val(lblWheelEssential.Text), Val(lblWheelNonEssential.Text), Val(lblTube.Text), Val(lblMould.Text), Val(lblFume.Text), Val(lblCompressor.Text), Val(lblAssembly.Text), Val(lblAxelEssential.Text), Val(lblAxelNonEssential.Text), Val(lblGFM.Text), Val(lblColony.Text), (Val(lblAdmin.Text) + Val(lblAux.Text)), (Val(lblEmms.Text) + Val(lblDCOS.Text)), Val(lblCanteen.Text), Val(lblTotalTonnageforDay.Text), Val(lblAF_Aa.Text), Val(lblAF_Ba.Text), Val(lblAF_Ca.Text), Val(lblAF_Ab.Text), Val(lblAF_Bb.Text), Val(lblAF_Cb.Text), Val(lblAF_Ac.Text), Val(lblAF_Bc.Text), Val(lblAF_Cc.Text), Val(lblAF_Ad.Text), Val(lblAF_Bd.Text), Val(lblAF_Cd.Text), Val(lblAF_Ae.Text), Val(lblAF_Be.Text), Val(lblAF_Ce.Text), Val(lblTotalAF_A.Text), Val(lblTotalAF_B.Text), Val(lblTotalAF_C.Text), Val(lblLop.Text), Val(lblRwfgen.Text), Val(lblCheckMeter.Text), txtCheckMeter.Text.Trim)
            blnDone = New Maintenance.Electrical().saveShopWise(CDate(txtDate.Text), txtKPTCL.Text, txtGenerated.Text, txtArc1.Text.Trim, txtArc2.Text.Trim, txtArc3.Text.Trim, txtPump.Text, txtColony.Text, txtColony1.Text, txtAdmin.Text, txtAux.Text, txtRwfgen.Text, txtPCS.Text, txtWheelEssential.Text, txtTube.Text, txtMould.Text, txtCompressor.Text, txtFume.Text, lblMode.Text, Val(lblKPTCL.Text), Val(lblGenerated.Text), Val(lblArc1.Text), Val(lblArc2.Text), Val(lblArc3.Text), Val(lblPump.Text), Val(lblWheelEssential.Text), Val(lblTube.Text), Val(lblMould.Text), Val(lblFume.Text), Val(lblCompressor.Text), Val(lblColony.Text), Val(lblColony1.Text), (Val(lblAdmin.Text) + Val(lblAux.Text)), Val(lblTotalTonnageforDay.Text), Val(lblAF_Aa.Text), Val(lblAF_Ba.Text), Val(lblAF_Ca.Text), Val(lblAF_Ab.Text), Val(lblAF_Bb.Text), Val(lblAF_Cb.Text), Val(lblAF_Ac.Text), Val(lblAF_Bc.Text), Val(lblAF_Cc.Text), Val(lblAF_Ad.Text), Val(lblAF_Bd.Text), Val(lblAF_Cd.Text), Val(lblAF_Ae.Text), Val(lblAF_Be.Text), Val(lblAF_Ce.Text), Val(lblTotalAF_A.Text), Val(lblTotalAF_B.Text), Val(lblTotalAF_C.Text), Val(lblRwfgen.Text), Val(lblPCS.Text))



        Catch exp As Exception
            blnDone = False
            lblMessage.Text = exp.Message
        Finally
            If blnDone = False Then
                lblMessage.Text = "Remarks Not Updated"
            Else
                lblMessage.Text = "Remarks Updated"
                'txtDate.Text = ""
                'clear()
            End If
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        clear()
        txtDate.Text = Date.Today
    End Sub

    Private Sub clear()
        txtAdmin.Text = ""
        txtArc1.Text = ""
        txtArc2.Text = ""
        txtArc3.Text = ""
        '  txtAssembly.Text = ""
        '   txtAxelEssential.Text = ""
        '    txtAxelNonEssential.Text = ""
        '     txtCanteen.Text = ""
        txtColony.Text = ""
        txtColony1.Text = ""
        txtCompressor.Text = ""
        ' txtEmms.Text = ""
        txtFume.Text = ""
        txtGenerated.Text = ""
        'txtGFM.Text = ""
        txtKPTCL.Text = ""
        txtMould.Text = ""
        txtPump.Text = ""
        txtTube.Text = ""
        txtWheelEssential.Text = ""
        'txtWheelNonEssential.Text = ""
        'txtLop.Text = ""
        lblWheelEssential.Text = ""
        '       lblWheelNonEssential.Text = ""
        lblTube.Text = ""
        lblMould.Text = ""
        lblCompressor.Text = ""
        lblFume.Text = ""
        'lblAxelEssential.Text = ""
        'lblAxelNonEssential.Text = ""
        'lblGFM.Text = ""
        'lblAssembly.Text = ""
        '      lblCanteen.Text = ""
        lblKPTCL.Text = ""
        lblGenerated.Text = ""
        lblArc1.Text = ""
        lblArc2.Text = ""
        lblArc3.Text = ""
        lblPump.Text = ""
        lblColony.Text = ""
        lblColony1.Text = ""
        lblAdmin.Text = ""
        lblAux.Text = ""
        'lblEmms.Text = ""
        'lblDCOS.Text = ""
        lblAF_Aa.Text = ""
        lblAF_Ab.Text = ""
        lblAF_Ac.Text = ""
        lblAF_Ad.Text = ""
        lblAF_Ae.Text = ""
        lblAF_Ba.Text = ""
        lblAF_Bb.Text = ""
        lblAF_Bc.Text = ""
        lblAF_Bd.Text = ""
        lblAF_Be.Text = ""
        lblAF_Ca.Text = ""
        lblAF_Cb.Text = ""
        lblAF_Cc.Text = ""
        lblAF_Cd.Text = ""
        lblAF_Ce.Text = ""
        lblTotalAF_A.Text = ""
        lblTotalAF_B.Text = ""
        lblTotalAF_C.Text = ""
        lblTotalTonnageforDay.Text = ""
        'lblLop.Text = ""
        lblRwfgen.Text = ""
        lblPCS.Text = ""
        txtRwfgen.Text = ""
        txtPCS.Text = ""
        'txtCheckMeter.Text = ""
        'lblCheckMeter.Text = ""
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Server.Transfer("/mss/selectModule.aspx")
    End Sub


End Class
