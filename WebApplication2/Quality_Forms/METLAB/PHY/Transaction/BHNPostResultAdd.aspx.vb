Public Class BHNPostResultAdd
    Inherits System.Web.UI.Page
    Protected WithEvents lblMode As System.Web.UI.WebControls.Label
    Protected WithEvents ddlLabNumber As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblLabNumber As System.Web.UI.WebControls.Label
    Protected WithEvents lblJoules As System.Web.UI.WebControls.Label
    Protected WithEvents lblAvg As System.Web.UI.WebControls.Label
    Protected WithEvents txtJoules_c As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtJoules_b As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtJoules_a As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRedn_plate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRedn_rim As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtKlengation_plate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtKlengation_rim As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtYS_plate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtYS_rim As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtUTS_plate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtUTS_rim As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblClosure As System.Web.UI.WebControls.Label
    Protected WithEvents rblAThin As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents chkGrain As System.Web.UI.WebControls.CheckBoxList
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents lblFinaltemp As System.Web.UI.WebControls.Label
    Protected WithEvents lblTubetemp As System.Web.UI.WebControls.Label
    Protected WithEvents lblDraglife As System.Web.UI.WebControls.Label
    Protected WithEvents lblCopelife As System.Web.UI.WebControls.Label
    Protected WithEvents lblPourorder As System.Web.UI.WebControls.Label
    Protected WithEvents lblWheeltype As System.Web.UI.WebControls.Label
    Protected WithEvents lblHeatrange As System.Web.UI.WebControls.Label
    Protected WithEvents lblReceiveddate As System.Web.UI.WebControls.Label
    Protected WithEvents lblCastdate As System.Web.UI.WebControls.Label
    Protected WithEvents rblLabValues As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents Panel2 As System.Web.UI.WebControls.Panel
    Protected WithEvents txtAl As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtP_S As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtV As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCu As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNi As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCr As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtS As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtP As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSi As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMn As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtC As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblWheel As System.Web.UI.WebControls.Label
    Protected WithEvents lblWheelClass As System.Web.UI.WebControls.Label
    Protected WithEvents lblTestType As System.Web.UI.WebControls.Label
    Protected WithEvents rblAThick As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblBThin As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblBThick As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblCThin As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblCThick As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblDThin As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblDThick As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblStructure As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblMacro As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblResult As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents radClosure As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents ini As System.Web.UI.WebControls.Label
    Protected WithEvents fin As System.Web.UI.WebControls.Label
    Protected WithEvents txtN As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtH As System.Web.UI.WebControls.TextBox
    Protected WithEvents Panel3 As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlImage As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlA As System.Web.UI.WebControls.Panel
    Protected WithEvents ImageA As System.Web.UI.WebControls.Image
    Protected WithEvents pnlB As System.Web.UI.WebControls.Panel
    Protected WithEvents ImageB As System.Web.UI.WebControls.Image
    Protected WithEvents Image1 As System.Web.UI.WebControls.Image
    Protected WithEvents pnlSpl As System.Web.UI.WebControls.Panel
    Protected WithEvents ImageSpl As System.Web.UI.WebControls.Image
    Protected WithEvents Panel4 As System.Web.UI.WebControls.Panel
    Protected WithEvents txtHC3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtHC2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtHC1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlHubCooler3 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlHubCooler2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlHubCooler1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtDFZone8 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDFZone7 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDFZone6 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDFZone5 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDFZone4 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDFZone3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDFZone2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDFZone1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNFZone7 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNFZone6 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNFZone5 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNFZone4 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNFZone3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNFZone2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNFZone1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtQTimeSec As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtQTimeMin As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlQuencherNo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtNFDischargeTime As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlNFChargeCondition As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtNFChargeTime As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNFChargeDate As System.Web.UI.WebControls.TextBox
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
        'Put user code to initialize the page here
        'strMode = Request.QueryString("mode")
        lblMode.Text = "add"
        ini.Visible = False
        fin.Visible = False
        If Not IsPostBack Then
            Clear()
            PanelVisible()
            Try
                getLabNumbers()
                GetDDLValues()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
    Private Sub getLabNumbers()
        ddlLabNumber.DataSource = Nothing
        ddlLabNumber.DataBind()
        Dim dt As New DataTable()
        Try
            ddlLabNumber.DataSource = metLab.tables.GetLabNumber
            ddlLabNumber.DataTextField = metLab.tables.GetLabNumber.Columns(0).ColumnName
            ddlLabNumber.DataValueField = metLab.tables.GetLabNumber.Columns(1).ColumnName
            ddlLabNumber.DataBind()
            ddlLabNumber.Items.Insert(0, "select")
        Catch exp As Exception
            Throw New Exception("Fetching of LabNumber" & exp.Message)
        End Try
    End Sub
    Private Function ReturnWheel(ByVal mystr As String) As String
        Dim myarray As Array
        Dim mywheel, myheat As String
        If mystr <> "" Then
            myarray = Split(mystr, "/")
            mywheel = myarray(0)
            myheat = myarray(1)
            Return mywheel
        End If
    End Function
    Private Function ReturnHeat(ByVal mystr As String) As String
        Dim myarray As Array
        Dim mywheel, myheat As String
        If mystr <> "" Then
            myarray = Split(mystr, "/")
            mywheel = myarray(0)
            myheat = myarray(1)
            Return myheat
        End If
    End Function
    Private Sub Clear()
        lblWheel.Text = ""
        lblAvg.Text = ""
        lblCastdate.Text = ""
        lblClosure.Text = ""
        ini.Text = ""
        fin.Text = ""
        lblCopelife.Text = ""
        lblDraglife.Text = ""
        lblFinaltemp.Text = ""
        lblHeatrange.Text = ""
        lblJoules.Text = ""
        lblLabNumber.Text = ""
        lblPourorder.Text = ""
        lblReceiveddate.Text = ""
        lblTubetemp.Text = ""
        lblWheeltype.Text = ""
        lblWheelClass.Text = ""
        lblTestType.Text = ""

        rblStructure.SelectedIndex = 0
        radClosure.SelectedIndex = 0
        rblMacro.SelectedIndex = 0
        rblResult.SelectedIndex = 0

        txtAl.Text = ""
        txtC.Text = ""
        txtCr.Text = ""
        txtCu.Text = ""
        txtJoules_a.Text = ""
        txtJoules_b.Text = ""
        txtJoules_c.Text = ""
        txtKlengation_plate.Text = ""
        txtKlengation_rim.Text = ""
        txtMn.Text = ""
        txtMo.Text = ""
        txtP.Text = ""
        txtP_S.Text = ""
        txtN.Text = ""
        txtH.Text = ""

        'txtRedn_plate.Text = ""

        txtRedn_rim.Text = ""
        txtRemarks.Text = ""
        txtS.Text = ""
        txtSi.Text = ""
        txtUTS_plate.Text = ""
        txtUTS_rim.Text = ""
        txtV.Text = ""
        txtYS_plate.Text = ""
        txtYS_rim.Text = ""
        txtNi.Text = ""
        viewstate("GrainSize") = Nothing
        viewstate("Inclusion") = Nothing
        Dim i As Int16
        For i = 0 To chkGrain.Items.Count - 1
            If chkGrain.Items(i).Selected Then
                chkGrain.Items(i).Selected = False
            End If
        Next
    End Sub
    Private Sub ddlLabNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlLabNumber.SelectedIndexChanged
        lblMessage.Text = ""
        rblLabValues.ClearSelection()
        Clear()
        PanelVisible()
        If ddlLabNumber.SelectedIndex = 0 Then
            lblMessage.Text = "Please select wheel number !"
            Exit Sub
        Else
            Try
                lblLabNumber.Text = ddlLabNumber.SelectedItem.Value
                getDetails()
            Catch exp As Exception
                lblLabNumber.Text &= exp.Message
            End Try
        End If

    End Sub
    Private Sub getDetails()
        Dim mywheel As String = ReturnWheel(Trim(ddlLabNumber.SelectedItem.Text))
        Dim myheat As String = ReturnHeat(Trim(ddlLabNumber.SelectedItem.Text))
        Dim ds As New DataSet()
        Dim dt As New DataTable()
        Try
            lblClosure.Text = ""
            ds = metLab.tables.GetLabValues(lblLabNumber.Text, mywheel, myheat)
            Session("LabNumber") = lblLabNumber.Text
            If ds.Tables(0).Rows.Count <= 0 Then
                lblMessage.Text = "Closure Values Not Entered !"
                lblTestType.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)(5)), "", ds.Tables(1).Rows(0)(5))
                If lblTestType.Text = "Experimental" Then
                    radClosure.SelectedIndex = 2
                End If
            Else
                ini.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)(0)), 0, ds.Tables(0).Rows(0)(0))
                fin.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)(1)), 0, ds.Tables(0).Rows(0)(1))
                lblClosure.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)(2)), 0, ds.Tables(0).Rows(0)(2))
                'If IsDBNull(ds.Tables(0).Rows(0)(3)) Then
                If Val(lblClosure.Text.Trim) < 1 Then
                    radClosure.SelectedIndex = 0
                Else
                    radClosure.SelectedIndex = 1
                End If
                'Else
                'Dim i As Int16
                'For i = 0 To radClosure.Items.Count - 1
                '    If radClosure.Items(i).Text.Substring(0, 1) = Trim(ds.Tables(0).Rows(0)(3)) Then
                '        radClosure.Items(i).Selected = True
                '        Exit For
                '    End If
                'Next
                'End If
            End If
            lblReceiveddate.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)(0)), 0, ds.Tables(1).Rows(0)(0))
            lblHeatrange.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)(1)), "", ds.Tables(1).Rows(0)(1)) & " - " & IIf(IsDBNull(ds.Tables(1).Rows(0)(2)), 0, ds.Tables(1).Rows(0)(2))
            lblWheel.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)(3)), "", ds.Tables(1).Rows(0)(3))
            lblWheelClass.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)(4)), "", ds.Tables(1).Rows(0)(4))
            lblTestType.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)(5)), "", ds.Tables(1).Rows(0)(5))

            lblCastdate.Text = IIf(IsDBNull(ds.Tables(2).Rows(0)(0)), 0, ds.Tables(2).Rows(0)(0))
            lblPourorder.Text = IIf(IsDBNull(ds.Tables(2).Rows(0)(1)), 0, ds.Tables(2).Rows(0)(1))
            lblCopelife.Text = IIf(IsDBNull(ds.Tables(2).Rows(0)(2)), 0, ds.Tables(2).Rows(0)(2))
            lblDraglife.Text = IIf(IsDBNull(ds.Tables(2).Rows(0)(3)), 0, ds.Tables(2).Rows(0)(3))
            lblWheeltype.Text = IIf(IsDBNull(ds.Tables(2).Rows(0)(4)), 0, ds.Tables(2).Rows(0)(4))
            lblTubetemp.Text = IIf(IsDBNull(ds.Tables(3).Rows(0)(0)), 0, ds.Tables(3).Rows(0)(0))
            lblFinaltemp.Text = IIf(IsDBNull(ds.Tables(3).Rows(0)(1)), 0, ds.Tables(3).Rows(0)(1))

            If ds.Tables(4).Rows.Count <= 0 Then
                lblMessage.Text &= "; Chemical Values Not Entered !"
            Else
                txtC.Text = IIf(IsDBNull(ds.Tables(4).Rows(0)("carbon")), "0.0", ds.Tables(4).Rows(0)("carbon"))
                txtP.Text = IIf(IsDBNull(ds.Tables(4).Rows(0)("phosphorus")), "0.0", ds.Tables(4).Rows(0)("phosphorus"))
                txtMn.Text = IIf(IsDBNull(ds.Tables(4).Rows(0)("manganese")), "0.0", ds.Tables(4).Rows(0)("manganese"))
                txtS.Text = IIf(IsDBNull(ds.Tables(4).Rows(0)("sulphur")), "0.0", ds.Tables(4).Rows(0)("sulphur"))
                txtSi.Text = IIf(IsDBNull(ds.Tables(4).Rows(0)("silicon")), "0.0", ds.Tables(4).Rows(0)("silicon"))
                txtCr.Text = IIf(IsDBNull(ds.Tables(4).Rows(0)("chromium")), "0.0", ds.Tables(4).Rows(0)("chromium"))
                txtNi.Text = IIf(IsDBNull(ds.Tables(4).Rows(0)("nickle")), "0.0", ds.Tables(4).Rows(0)("nickle"))
                txtCu.Text = IIf(IsDBNull(ds.Tables(4).Rows(0)("copper")), "0.0", ds.Tables(4).Rows(0)("copper"))
                txtV.Text = IIf(IsDBNull(ds.Tables(4).Rows(0)("vanadium")), "0.0", ds.Tables(4).Rows(0)("vanadium"))
                txtMo.Text = IIf(IsDBNull(ds.Tables(4).Rows(0)("molybdenum")), "0.0", ds.Tables(4).Rows(0)("molybdenum"))
                txtP_S.Text = IIf(IsDBNull(ds.Tables(4).Rows(0)("phosphorus_sulphur")), "0.0", ds.Tables(4).Rows(0)("phosphorus_sulphur"))
                txtAl.Text = IIf(IsDBNull(ds.Tables(4).Rows(0)("alunimum")), "0.0", ds.Tables(4).Rows(0)("alunimum"))
                txtN.Text = IIf(IsDBNull(ds.Tables(4).Rows(0)("nitrogen")), "0.0", ds.Tables(4).Rows(0)("nitrogen"))
                txtH.Text = IIf(IsDBNull(ds.Tables(4).Rows(0)("hydrogen")), "0.0", ds.Tables(4).Rows(0)("hydrogen"))
            End If
            If ds.Tables(5).Rows.Count <= 0 Then
                lblMessage.Text &= "; BHN Values Not Entered !"
            Else
                'DataGrid1.DataSource = ds.Tables(5)
                'DataGrid1.DataBind()
            End If
            If ds.Tables(6).Rows.Count <= 0 Then
                lblMessage.Text &= "; HT Details Not Entered !"
            Else
                dt = ds.Tables(6)
                txtNFChargeDate.Text = dt.Rows(0)("NFChargeDate") & ""
                txtNFChargeTime.Text = dt.Rows(0)("NFChargeTime") & ""
                Dim int As Integer = 0
                For int = 0 To ddlNFChargeCondition.Items.Count - 1
                    If ddlNFChargeCondition.Items(int).Text.Trim = dt.Rows(0)("NFChargeCondition") Then
                        ddlNFChargeCondition.SelectedIndex = int
                        Exit For
                    End If
                Next
                txtNFDischargeTime.Text = dt.Rows(0)("NFDischargeTime") & ""
                txtNFZone1.Text = dt.Rows(0)("NFZone1") & ""
                txtNFZone2.Text = dt.Rows(0)("NFZone2") & ""
                txtNFZone3.Text = dt.Rows(0)("NFZone3") & ""
                txtNFZone4.Text = dt.Rows(0)("NFZone4") & ""
                txtNFZone5.Text = dt.Rows(0)("NFZone5") & ""
                txtNFZone6.Text = dt.Rows(0)("NFZone6") & ""
                txtNFZone7.Text = dt.Rows(0)("NFZone7") & ""
                txtDFZone1.Text = dt.Rows(0)("DFZone1") & ""
                txtDFZone2.Text = dt.Rows(0)("DFZone2") & ""
                txtDFZone3.Text = dt.Rows(0)("DFZone3") & ""
                txtDFZone4.Text = dt.Rows(0)("DFZone4") & ""
                txtDFZone5.Text = dt.Rows(0)("DFZone5") & ""
                txtDFZone6.Text = dt.Rows(0)("DFZone6") & ""
                txtDFZone7.Text = dt.Rows(0)("DFZone7") & ""
                txtDFZone8.Text = dt.Rows(0)("DFZone8") & ""
                int = 0
                For int = 0 To ddlQuencherNo.Items.Count - 1
                    If ddlQuencherNo.Items(int).Text.Trim = dt.Rows(0)("QuencherNo") Then
                        ddlQuencherNo.SelectedIndex = int
                        Exit For
                    End If
                Next
                txtQTimeMin.Text = dt.Rows(0)("QTimeMin") & ""
                txtQTimeSec.Text = dt.Rows(0)("QTimeSec") & ""
                txtHC1.Text = dt.Rows(0)("HC1") & ""
                txtHC2.Text = dt.Rows(0)("HC2") & ""
                txtHC3.Text = dt.Rows(0)("HC3") & ""
                int = 0
                For int = 0 To ddlHubCooler1.Items.Count - 1
                    If ddlHubCooler1.Items(int).Text.Trim = dt.Rows(0)("HC1Code") Then
                        ddlHubCooler1.SelectedIndex = int
                        Exit For
                    End If
                Next
                int = 0
                For int = 0 To ddlHubCooler2.Items.Count - 1
                    If ddlHubCooler2.Items(int).Text.Trim = dt.Rows(0)("HC2Code") Then
                        ddlHubCooler2.SelectedIndex = int
                        Exit For
                    End If
                Next
                int = 0
                For int = 0 To ddlHubCooler3.Items.Count - 1
                    If ddlHubCooler3.Items(int).Text.Trim = dt.Rows(0)("HC3Code") Then
                        ddlHubCooler3.SelectedIndex = int
                        Exit For
                    End If
                Next
            End If
        Catch expGen As Exception
            lblMessage.Text &= expGen.Message
        Finally
            dt.Dispose()
            ds.Dispose()
        End Try
    End Sub
    Private Sub GetDDLValues()
        Dim ds As New DataSet()
        clearHT()
        Try
            ddlQuencherNo.ClearSelection()
            ddlQuencherNo.Items.Clear()
            ddlHubCooler1.Items.Clear()
            ddlHubCooler2.Items.Clear()
            ddlHubCooler3.Items.Clear()
            ds = metLab.tables.GetDDLValues
            FillDDLs(ds.Tables(0), ddlQuencherNo)
            FillDDLs(ds.Tables(1), ddlHubCooler1)
            FillDDLs(ds.Tables(1), ddlHubCooler2)
            FillDDLs(ds.Tables(1), ddlHubCooler3)
            ddlQuencherNo.Items.Insert(0, "Select")
            ddlQuencherNo.Items(0).Selected = True
            ddlHubCooler1.Items.Insert(0, "Select")
            ddlHubCooler1.Items(1).Selected = True
            ddlHubCooler2.Items.Insert(0, "Select")
            ddlHubCooler2.Items(2).Selected = True
            ddlHubCooler3.Items.Insert(0, "Select")
            ddlHubCooler3.Items(3).Selected = True
        Catch exp As Exception
            Throw New Exception("DDL Filling Error !")
        End Try
    End Sub
    Private Sub FillDDLs(ByVal dt As DataTable, ByVal ddl As DropDownList)
        ddl.DataSource = dt.DefaultView
        ddl.DataTextField = dt.Columns(1).ColumnName
        ddl.DataValueField = dt.Columns(0).ColumnName
        ddl.DataBind()
    End Sub
    Private Sub clearHT()
        txtNFZone1.Text = "0"
        txtNFZone2.Text = ""
        txtNFZone3.Text = ""
        txtNFZone4.Text = ""
        txtNFZone5.Text = ""
        txtNFZone6.Text = ""
        txtNFZone7.Text = ""
        txtDFZone1.Text = ""
        txtDFZone2.Text = ""
        txtDFZone3.Text = ""
        txtDFZone4.Text = ""
        txtDFZone5.Text = ""
        txtDFZone6.Text = ""
        txtDFZone7.Text = ""
        txtDFZone8.Text = ""
    End Sub
    Private Sub PanelVisible()
        Panel1.Visible = False
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
        pnlImage.Visible = False
        pnlA.Visible = False
        pnlB.Visible = False
        pnlSpl.Visible = False
    End Sub
    Private Sub rblLabValues_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblLabValues.SelectedIndexChanged
        lblMessage.Text = ""
        PanelVisible()
        If ddlLabNumber.SelectedIndex = 0 Then
            lblMessage.Text = "Please select Wheel Number !"
            rblLabValues.ClearSelection()
            Exit Sub
        Else
            Try
                If rblLabValues.SelectedIndex = 0 Then
                    Panel1.Visible = True
                ElseIf rblLabValues.SelectedIndex = 1 Then
                    Panel2.Visible = True
                ElseIf rblLabValues.SelectedIndex = 2 Then
                    Panel3.Visible = True
                ElseIf rblLabValues.SelectedIndex = 3 Then
                    pnlImage.Visible = True
                    If lblWheelClass.Text.Trim = "A" Then
                        pnlA.Visible = True
                        pnlB.Visible = False
                        pnlSpl.Visible = False
                    ElseIf lblWheelClass.Text.Trim = "B" Then
                        pnlA.Visible = False
                        pnlB.Visible = True
                        pnlSpl.Visible = False
                    Else
                        pnlA.Visible = False
                        pnlB.Visible = False
                        pnlSpl.Visible = True
                    End If
                ElseIf rblLabValues.SelectedIndex = 4 Then
                    Panel4.Visible = True
                End If
            Catch exp As Exception
                lblLabNumber.Text &= exp.Message
            End Try
        End If
    End Sub
    Private Sub FillInclusion()
        Dim NewDT As New DataTable()
        Try
            Dim dr As DataRow
            Dim cnt As Integer
            NewDT.TableName = "Inclusion"
            NewDT.Columns.Add("lab_number")
            NewDT.Columns.Add("Inclusion")
            NewDT.Columns.Add("thin")
            NewDT.Columns.Add("thick")
            If rblAThin.SelectedIndex > 0 Or rblAThick.SelectedIndex > 0 Then
                dr = NewDT.NewRow
                dr("lab_number") = lblLabNumber.Text.Trim
                dr("Inclusion") = "A"
                dr("thin") = rblAThin.SelectedItem.Value
                dr("thick") = rblAThick.SelectedItem.Value
                NewDT.Rows.Add(dr)
            End If
            If rblBThin.SelectedIndex > 0 Or rblBThick.SelectedIndex > 0 Then
                dr = NewDT.NewRow
                dr("lab_number") = lblLabNumber.Text.Trim
                dr("Inclusion") = "B"
                dr("thin") = rblBThin.SelectedItem.Value
                dr("thick") = rblBThick.SelectedItem.Value
                NewDT.Rows.Add(dr)
            End If
            If rblCThin.SelectedIndex > 0 Or rblCThick.SelectedIndex > 0 Then
                dr = NewDT.NewRow
                dr("lab_number") = lblLabNumber.Text.Trim
                dr("Inclusion") = "C"
                dr("thin") = rblCThin.SelectedItem.Value
                dr("thick") = rblCThick.SelectedItem.Value
                NewDT.Rows.Add(dr)
            End If
            If rblDThin.SelectedIndex > 0 Or rblDThick.SelectedIndex > 0 Then
                dr = NewDT.NewRow
                dr("lab_number") = lblLabNumber.Text.Trim
                dr("Inclusion") = "D"
                dr("thin") = rblDThin.SelectedItem.Value
                dr("thick") = rblDThick.SelectedItem.Value
                NewDT.Rows.Add(dr)
            End If
            viewstate("Inclusion") = NewDT
        Catch exp As Exception
            Throw New Exception(exp.Message)
        End Try
    End Sub
    Private Sub SetGrainSize()
        Dim i, j As Integer
        Dim g As String
        j = 0
        For i = 0 To chkGrain.Items.Count - 1
            If chkGrain.Items(i).Selected Then
                j = j + 1
                If j = 1 Then
                    g = chkGrain.Items(i).Text
                Else
                    g = g + "-" + chkGrain.Items(i).Text
                End If
            End If
        Next
        viewstate("GrainSize") = g
    End Sub
    Private Sub Setfocus(ByVal ctrl As Control)
        'Define the JavaScript function for the specefied control.
        Dim focusScript As String = "<script language = 'javascript'>" & _
        "document.getElementById('" + ctrl.ClientID & _
        "').focus();</script>"
        'Add the JavaScript code to the page.
        Page.RegisterStartupScript("FocusScript", focusScript)
        ' MarkControlsAsSelected(ctrl)
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ddlLabNumber.SelectedIndex = 0 Then
            lblMessage.Text = " Please select Wheel Number !"
            Exit Sub
        ElseIf Not lblTestType.Text = "Experimental" Then
            If lblClosure.Text.Length <= 0 Then
                lblMessage.Text = " Closere values not valid !"
                Exit Sub
            End If
        End If
        Dim oWhl As New metLab.Product()
        Try
            FillInclusion()
            SetGrainSize()
            oWhl.WheelNumber = ReturnWheel(ddlLabNumber.SelectedItem.Text.Trim)
            oWhl.HeatNumber = ReturnHeat(ddlLabNumber.SelectedItem.Text.Trim)
            oWhl.LabNumber = ddlLabNumber.SelectedItem.Value.Trim
            oWhl.grain_size = CType(viewstate("GrainSize"), String)
            oWhl.InclusionTable = CType(viewstate("Inclusion"), DataTable)
            oWhl.initial_gaugelength = Val(ini.Text.Trim)
            oWhl.final_gaugelength = Val(fin.Text.Trim)
            oWhl.closure = radClosure.SelectedItem.Text
            oWhl.uts_rim = Val(txtUTS_rim.Text.Trim)
            oWhl.ys_rim = Val(txtYS_rim.Text.Trim)
            oWhl.klengation_rim = Val(txtKlengation_rim.Text.Trim)
            oWhl.rednarea_rim = Val(txtRedn_rim.Text.Trim)
            oWhl.uts_plate = Val(txtUTS_plate.Text.Trim)
            oWhl.ys_plate = Val(txtYS_plate.Text.Trim)
            oWhl.klengation_plate = Val(txtKlengation_plate.Text.Trim)
            oWhl.rednarea_plate = Val(txtRedn_plate.Text.Trim)
            oWhl.kurim_a = Val(txtJoules_a.Text.Trim)
            oWhl.kurim_b = Val(txtJoules_b.Text.Trim)
            oWhl.kurim_c = Val(txtJoules_c.Text.Trim)
            oWhl.datetoday = Date.Now
            oWhl.micro = rblStructure.SelectedItem.Text.Trim
            oWhl.macro = rblMacro.SelectedItem.Text.Trim
            oWhl.result = rblResult.SelectedItem.Value.Trim
            oWhl.remarks = txtRemarks.Text.Trim
            If oWhl.savePhysicalValues(oWhl.LabNumber, lblMode.Text.Trim) Then
                getLabNumbers()
                Clear()
                lblMessage.Text = "Records Updateded !"
            Else
                lblMessage.Text = "Records Updation Failed !"
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub txtUTS_rim_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUTS_rim.TextChanged
        Setfocus(txtYS_rim)
    End Sub

    Private Sub txtYS_rim_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtYS_rim.TextChanged
        Setfocus(txtKlengation_rim)
    End Sub

    Private Sub txtKlengation_rim_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKlengation_rim.TextChanged
        Setfocus(txtRedn_rim)
    End Sub

    Private Sub txtRedn_rim_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRedn_rim.TextChanged
        Setfocus(txtUTS_plate)
    End Sub

    Private Sub txtUTS_plate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUTS_plate.TextChanged
        Setfocus(txtYS_plate)
    End Sub

    Private Sub txtYS_plate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtYS_plate.TextChanged
        Setfocus(txtKlengation_plate)
    End Sub

    Private Sub txtKlengation_plate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKlengation_plate.TextChanged
        Setfocus(txtRedn_plate)
    End Sub

    Private Sub txtRedn_plate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRedn_plate.TextChanged
        Setfocus(txtJoules_a)
    End Sub

    Private Sub txtJoules_a_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtJoules_a.TextChanged
        Dim val, a, b, c As Double
        Try
            val = txtJoules_a.Text
            c = txtJoules_c.Text
            b = txtJoules_b.Text
            a = txtJoules_a.Text
            c = (a + b + c) / 3
            lblAvg.Text = c
        Catch exp As Exception
            lblMessage.Text = "Enter Numbers Only"
        Finally
            If val < 5 Or val > 30 Then
                lblJoules.Text = "Range Should be Between 05 and 30"
            Else
                lblJoules.Text = ""
                Setfocus(txtJoules_b)
            End If
            val = Nothing
            a = Nothing
            b = Nothing
            c = Nothing
        End Try
    End Sub

    Private Sub txtJoules_b_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtJoules_b.TextChanged
        Dim val, a, b, c As Double
        Try
            val = txtJoules_b.Text
            c = txtJoules_c.Text
            b = txtJoules_b.Text
            a = txtJoules_a.Text
            c = (a + b + c) / 3
            lblAvg.Text = c
        Catch exp As Exception
            lblMessage.Text = "Enter Numbers Only"
        Finally
            If val < 5 Or val > 30 Then
                lblJoules.Text = "Range Should be Between 05 and 30"
            Else
                lblJoules.Text = ""
                Setfocus(txtJoules_c)
            End If
            val = Nothing
            a = Nothing
            b = Nothing
            c = Nothing
        End Try
    End Sub

    Private Sub txtJoules_c_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtJoules_c.TextChanged
        Dim val, a, b, c As Double
        Try
            val = txtJoules_c.Text
            c = txtJoules_c.Text
            b = txtJoules_b.Text
            a = txtJoules_a.Text
            c = (a + b + c) / 3
            lblAvg.Text = c
        Catch exp As Exception
            lblMessage.Text = "Enter Numbers Only"
        Finally
            If val < 5 Or val > 30 Then
                lblJoules.Text = "Range Should be Between 05 and 30"
            Else
                lblJoules.Text = ""
                Setfocus(rblAThin)
            End If
            val = Nothing
            a = Nothing
            b = Nothing
            c = Nothing
        End Try
    End Sub
End Class
