Public Class ArcFurnaceMeltingStats
    Inherits System.Web.UI.Page
    Protected WithEvents lblProgressive_units1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblProgressive_melts1 As System.Web.UI.WebControls.Label
    Protected WithEvents btnExit As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
    Protected WithEvents btnSubmit_Clicks As System.Web.UI.WebControls.Button
    Protected WithEvents lblSlno As System.Web.UI.WebControls.Label
    Protected WithEvents lblMode As System.Web.UI.WebControls.Label
    Protected WithEvents txtVCB_no As System.Web.UI.WebControls.TextBox
    Protected WithEvents RangeValidator2 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents RangeValidator6 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents lblDay_melts1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblDay_melts2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblDay_melts3 As System.Web.UI.WebControls.Label
    Protected WithEvents lblDay_consumption1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblDay_consumption2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblDay_consumption3 As System.Web.UI.WebControls.Label
    Protected WithEvents lblDay_average1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblDay_average2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblDay_average3 As System.Web.UI.WebControls.Label
    Protected WithEvents lblProgressive_melts2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblProgressive_melts3 As System.Web.UI.WebControls.Label
    Protected WithEvents lblProgressive_units2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblProgressive_units3 As System.Web.UI.WebControls.Label
    Protected WithEvents lblMonth_average1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblMonth_average2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblMonth_average3 As System.Web.UI.WebControls.Label
    Protected WithEvents lblMonth_average As System.Web.UI.WebControls.Label
    Protected WithEvents lblDay_average As System.Web.UI.WebControls.Label
    Protected WithEvents RequiredFieldValidator4 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator5 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents RangeValidator1 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtMelt_no As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDemand As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblConsumption As System.Web.UI.WebControls.Label
    Protected WithEvents RangeValidator4 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents RequiredFieldValidator7 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator3 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator6 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents grdAFS As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtTR1From As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTR1To As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTR1Initial As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTR1Final As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTR2From As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTR2to As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTR2final As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTR3From As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTR3to As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTR3Initial As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTR3final As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator18 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Rangevalidator3 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents Rangevalidator12 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents lblMeltingTime As System.Web.UI.WebControls.Label
    Protected WithEvents lblTtoPsameAF As System.Web.UI.WebControls.Label
    Protected WithEvents lblTtoTanyAF As System.Web.UI.WebControls.Label
    Protected WithEvents txtTR1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTR2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTR3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlAF As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblTtoTsameAF As System.Web.UI.WebControls.Label
    Protected WithEvents txtTR2Initial As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblAF_Aa As System.Web.UI.WebControls.Label
    Protected WithEvents lblAF_Ab As System.Web.UI.WebControls.Label
    Protected WithEvents lblAF_Ac As System.Web.UI.WebControls.Label
    Protected WithEvents lblAF_Ad As System.Web.UI.WebControls.Label
    Protected WithEvents lblAF_Ae As System.Web.UI.WebControls.Label
    Protected WithEvents lblTotalAF_A As System.Web.UI.WebControls.Label
    Protected WithEvents lblAF_Ba As System.Web.UI.WebControls.Label
    Protected WithEvents lblAF_Bb As System.Web.UI.WebControls.Label
    Protected WithEvents lblAF_Bc As System.Web.UI.WebControls.Label
    Protected WithEvents lblAF_Bd As System.Web.UI.WebControls.Label
    Protected WithEvents lblAF_Be As System.Web.UI.WebControls.Label
    Protected WithEvents lblTotalAF_B As System.Web.UI.WebControls.Label
    Protected WithEvents lblAF_Ca As System.Web.UI.WebControls.Label
    Protected WithEvents lblAF_Cb As System.Web.UI.WebControls.Label
    Protected WithEvents lblAF_Cc As System.Web.UI.WebControls.Label
    Protected WithEvents lblAF_Cd As System.Web.UI.WebControls.Label
    Protected WithEvents lblAF_Ce As System.Web.UI.WebControls.Label
    Protected WithEvents lblTotalAF_C As System.Web.UI.WebControls.Label
    Protected WithEvents lblTotalHeats As System.Web.UI.WebControls.Label
    Protected WithEvents lblUnitsPerTonforDayA As System.Web.UI.WebControls.Label
    Protected WithEvents lblUnitsPerTonforDayB As System.Web.UI.WebControls.Label
    Protected WithEvents lblUnitsPerTonforDayC As System.Web.UI.WebControls.Label
    Protected WithEvents lblUnitsPerTonforMonthA As System.Web.UI.WebControls.Label
    Protected WithEvents lblUnitsPerTonforMonthB As System.Web.UI.WebControls.Label
    Protected WithEvents lblUnitsPerTonforMonthC As System.Web.UI.WebControls.Label
    Protected WithEvents lblTotalTonnageforDay As System.Web.UI.WebControls.Label
    Protected WithEvents lblTotalTonnageforMonth As System.Web.UI.WebControls.Label
    Protected WithEvents lblConsumptionforDay As System.Web.UI.WebControls.Label
    Protected WithEvents lblProgressiveunitsformonth As System.Web.UI.WebControls.Label
    Protected WithEvents lblProgressiveMeltsforMonth As System.Web.UI.WebControls.Label
    Protected WithEvents lblUnitsPerTonDayAvg As System.Web.UI.WebControls.Label
    Protected WithEvents lblUnitsPerTonMonthAvg As System.Web.UI.WebControls.Label
    Protected WithEvents rblMF As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents txtMelt_month As System.Web.UI.WebControls.TextBox
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
        lblMode.Text = Request.QueryString("mode")
        lblMode.Text = "add"
        'lblMode.Text = "edit"
        'lblMode.Text = "delete"
        lblMessage.Text = ""
        If Not Page.IsPostBack Then
            txtDate.Text = Now.Date
            txtTR1From.Text = Now.Date
            txtTR1To.Text = Now.Date

            If lblMode.Text.Equals("edit") Then
                'btnExit1.Visible = True
                lblMessage.Text = "Please enter the Melt No to be edited"
                txtMelt_month.Text = ""
                txtMelt_no.Text = ""
                RequiredFieldValidator2.Enabled = False
                RequiredFieldValidator3.Enabled = False
                RequiredFieldValidator4.Enabled = False
                RequiredFieldValidator5.Enabled = False
                RequiredFieldValidator6.Enabled = False
                RequiredFieldValidator7.Enabled = False
            ElseIf lblMode.Text.Equals("delete") Then
                lblMessage.Text = "Please enter the Melt no to be deleted"
                btnSubmit_Clicks.Text = "Delete"
                txtMelt_month.Text = ""
                txtMelt_no.Text = ""
                RequiredFieldValidator2.Enabled = False
                RequiredFieldValidator3.Enabled = False
                RequiredFieldValidator4.Enabled = False
                RequiredFieldValidator5.Enabled = False
                RequiredFieldValidator6.Enabled = False
                RequiredFieldValidator7.Enabled = False
            Else
                Try
                    BindGrid()
                    getMelt_numbers()
                    getDetails()
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                End Try
            End If
        End If 'End of IsPostBack
    End Sub

    Sub getDetails()
        Dim dt As DataTable
        Try
            dt = Maintenance.ElecTables.getArcFurnaceDetails(CDate(txtDate.Text.Trim))

            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0)(0)) Then
                    lblDay_melts1.Text = dt.Rows(0)(0)
                End If
                If Not IsDBNull(dt.Rows(0)(1)) Then
                    lblDay_melts2.Text = dt.Rows(0)(1)
                End If
                If Not IsDBNull(dt.Rows(0)(2)) Then
                    lblDay_melts3.Text = dt.Rows(0)(2)
                End If
                If Not IsDBNull(dt.Rows(0)(3)) Then
                    lblDay_consumption1.Text = dt.Rows(0)(3)
                End If
                If Not IsDBNull(dt.Rows(0)(4)) Then
                    lblDay_consumption2.Text = dt.Rows(0)(4)
                End If
                If Not IsDBNull(dt.Rows(0)(5)) Then
                    lblDay_consumption3.Text = dt.Rows(0)(5)
                End If
                'lblUnitsPerTonforDayA.Text
                If Not IsDBNull(dt.Rows(0)(6)) Then
                    lblUnitsPerTonforDayA.Text = dt.Rows(0)(6)
                End If
                If Not IsDBNull(dt.Rows(0)(7)) Then
                    lblUnitsPerTonforDayB.Text = dt.Rows(0)(7)
                End If
                If Not IsDBNull(dt.Rows(0)(8)) Then
                    lblUnitsPerTonforDayC.Text = dt.Rows(0)(8)
                End If
                'lblDay_average1
                If Not IsDBNull(dt.Rows(0)(9)) Then
                    lblDay_average1.Text = dt.Rows(0)(9)
                End If
                If Not IsDBNull(dt.Rows(0)(10)) Then
                    lblDay_average2.Text = dt.Rows(0)(10)
                End If
                If Not IsDBNull(dt.Rows(0)(11)) Then
                    lblDay_average3.Text = dt.Rows(0)(11)
                End If

                If Not IsDBNull(dt.Rows(0)(12)) Then
                    lblProgressive_melts1.Text = dt.Rows(0)(12)
                End If
                If Not IsDBNull(dt.Rows(0)(13)) Then
                    lblProgressive_melts2.Text = dt.Rows(0)(13)
                End If
                If Not IsDBNull(dt.Rows(0)(14)) Then
                    lblProgressive_melts3.Text = dt.Rows(0)(14)
                End If

                If Not IsDBNull(dt.Rows(0)(15)) Then
                    lblProgressive_units1.Text = dt.Rows(0)(15)
                End If
                If Not IsDBNull(dt.Rows(0)(16)) Then
                    lblProgressive_units2.Text = dt.Rows(0)(16)
                End If
                If Not IsDBNull(dt.Rows(0)(17)) Then
                    lblProgressive_units3.Text = dt.Rows(0)(17)
                End If
                'lblUnitsPerTonforMonthC
                If Not IsDBNull(dt.Rows(0)(18)) Then
                    lblUnitsPerTonforMonthA.Text = dt.Rows(0)(18)
                End If
                If Not IsDBNull(dt.Rows(0)(19)) Then
                    lblUnitsPerTonforMonthB.Text = dt.Rows(0)(19)
                End If
                If Not IsDBNull(dt.Rows(0)(20)) Then
                    lblUnitsPerTonforMonthC.Text = dt.Rows(0)(20)
                End If

                If Not IsDBNull(dt.Rows(0)(21)) Then
                    lblMonth_average1.Text = dt.Rows(0)(21)
                End If
                If Not IsDBNull(dt.Rows(0)(22)) Then
                    lblMonth_average2.Text = dt.Rows(0)(22)
                End If
                If Not IsDBNull(dt.Rows(0)(23)) Then
                    lblMonth_average3.Text = dt.Rows(0)(23)
                End If

                If Not IsDBNull(dt.Rows(0)(24)) Then
                    lblTotalHeats.Text = dt.Rows(0)(24)
                End If


                'lblConsumptionforDay
                If Not IsDBNull(dt.Rows(0)(25)) Then
                    lblConsumptionforDay.Text = dt.Rows(0)(25)
                End If

                'lblProgressiveunitsformonth
                If Not IsDBNull(dt.Rows(0)(26)) Then
                    lblProgressiveMeltsforMonth.Text = dt.Rows(0)(26)
                End If
                If Not IsDBNull(dt.Rows(0)(27)) Then
                    lblProgressiveunitsformonth.Text = dt.Rows(0)(27)
                End If
                'lbl_average
                If Not IsDBNull(dt.Rows(0)(28)) Then
                    lblDay_average.Text = dt.Rows(0)(28)
                End If
                'lblUnitsPerTonDayAvg
                If Not IsDBNull(dt.Rows(0)(29)) Then
                    lblUnitsPerTonDayAvg.Text = dt.Rows(0)(29)
                End If
                If Not IsDBNull(dt.Rows(0)(30)) Then
                    lblMonth_average.Text = dt.Rows(0)(30)
                End If
                'lblUnitsPerTonDayAvg
                If Not IsDBNull(dt.Rows(0)(31)) Then
                    lblUnitsPerTonMonthAvg.Text = dt.Rows(0)(31)
                End If
                'lblTotalTonnage
                If Not IsDBNull(dt.Rows(0)(32)) Then
                    lblTotalTonnageforDay.Text = dt.Rows(0)(32)
                End If
                If Not IsDBNull(dt.Rows(0)(33)) Then
                    lblTotalTonnageforMonth.Text = dt.Rows(0)(33)
                End If
                ' codes for fur
                If Not IsDBNull(dt.Rows(0)(34)) Then
                    lblAF_Aa.Text = dt.Rows(0)(34)
                End If

                If Not IsDBNull(dt.Rows(0)(35)) Then
                    lblAF_Ab.Text = dt.Rows(0)(35)
                End If
                If Not IsDBNull(dt.Rows(0)(36)) Then
                    lblAF_Ac.Text = dt.Rows(0)(36)
                End If
                If Not IsDBNull(dt.Rows(0)(37)) Then
                    lblAF_Ad.Text = dt.Rows(0)(37)
                End If
                If Not IsDBNull(dt.Rows(0)(38)) Then
                    lblAF_Ae.Text = dt.Rows(0)(38)
                End If
                If Not IsDBNull(dt.Rows(0)(39)) Then
                    lblTotalAF_A.Text = dt.Rows(0)(39)
                End If
                If Not IsDBNull(dt.Rows(0)(40)) Then
                    lblAF_Ba.Text = dt.Rows(0)(40)
                End If
                If Not IsDBNull(dt.Rows(0)(41)) Then
                    lblAF_Bb.Text = dt.Rows(0)(41)
                End If
                If Not IsDBNull(dt.Rows(0)(42)) Then
                    lblAF_Bc.Text = dt.Rows(0)(42)
                End If
                If Not IsDBNull(dt.Rows(0)(43)) Then
                    lblAF_Bd.Text = dt.Rows(0)(43)
                End If
                If Not IsDBNull(dt.Rows(0)(44)) Then
                    lblAF_Be.Text = dt.Rows(0)(44)
                End If
                If Not IsDBNull(dt.Rows(0)(45)) Then
                    lblTotalAF_B.Text = dt.Rows(0)(45)
                End If
                If Not IsDBNull(dt.Rows(0)(46)) Then
                    lblAF_Ca.Text = dt.Rows(0)(46)
                End If
                If Not IsDBNull(dt.Rows(0)(47)) Then
                    lblAF_Cb.Text = dt.Rows(0)(47)
                End If
                If Not IsDBNull(dt.Rows(0)(48)) Then
                    lblAF_Cc.Text = dt.Rows(0)(48)
                End If
                If Not IsDBNull(dt.Rows(0)(49)) Then
                    lblAF_Cd.Text = dt.Rows(0)(49)
                End If
                If Not IsDBNull(dt.Rows(0)(50)) Then
                    lblAF_Ce.Text = dt.Rows(0)(50)
                End If
                If Not IsDBNull(dt.Rows(0)(51)) Then
                    lblTotalAF_C.Text = dt.Rows(0)(51)
                End If

                'If Not IsDBNull(dt.Rows(0)(5)) Then
                '    Dim time As String
                '    time = dt.Rows(0)(5)
                '    txtMin_time.Text = time.Substring(11)
                'End If
                'If Not IsDBNull(dt.Rows(0)(6)) Then
                '    txtMax_voltage.Text = dt.Rows(0)(6)
                'End If
                'If Not IsDBNull(dt.Rows(0)(7)) Then
                '    Dim time As String
                '    time = dt.Rows(0)(7)
                '    txtMax_time.Text = time.Substring(11)
                'End If

                'If Not IsDBNull(dt.Rows(0)(20)) Then
                '    Dim intCnt As Integer
                '    For intCnt = 0 To ddlAFA.Items.Count - 1
                '        If ddlAFA.Items(intCnt).Text = dt.Rows(0)(20) Then
                '            ddlAFA.SelectedIndex = intCnt
                '            Exit For
                '        End If
                '    Next
                'End If

            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
        End Try
    End Sub

    Sub getMelt_numbers()
        Dim intCnt As Integer
        Dim dt As DataTable
        Try
            dt = Maintenance.ElecTables.getMeltNoMonth
            If Not dt.Rows.Count = 0 Then
                txtMelt_no.Text = dt.Rows(0)(0) + 1
                txtMelt_month.Text = dt.Rows(0)(1) + 1
            Else
                txtMelt_no.Text = 1
                txtMelt_month.Text = 1
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnSubmit_Clicks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit_Clicks.Click
        lblMessage.Text = ""
        getUnits()
        Dim Done As Boolean
        Try
            Done = New Maintenance.Electrical().SaveFurnaceData(lblMode.Text, CDate(txtDate.Text), Val(txtMelt_no.Text), Val(txtMelt_month.Text), Val(lblConsumption.Text), Val(txtDemand.Text), ddlAF.SelectedItem.Text, txtVCB_no.Text, lblMeltingTime.Text.Trim, lblTtoTsameAF.Text.Trim, lblTtoPsameAF.Text.Trim, lblTtoTanyAF.Text.Trim, txtRemarks.Text.Trim, txtTR1.Text.Trim, CDate(txtTR1From.Text), CDate(txtTR1To.Text), Val(txtTR1Final.Text.Trim), Val(txtTR1Initial.Text.Trim), txtTR2.Text.Trim, CDate(txtTR2From.Text), CDate(txtTR2to.Text), Val(txtTR2final.Text.Trim), Val(txtTR2Initial.Text.Trim), txtTR3.Text.Trim, CDate(txtTR3From.Text), CDate(txtTR3to.Text), Val(txtTR3final.Text.Trim), Val(txtTR3Initial.Text.Trim))
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If Done Then
            If lblMode.Text.ToLower = "delete" Then
                lblMessage.Text = "Record Deleted !"
            ElseIf lblMode.Text.ToLower = "add" Then
                lblMessage.Text = "Record Inserted"
            Else
                lblMessage.Text = "Record Updated !"
            End If
            Try
                clear()
                BindGrid()
                getMelt_numbers()
                getDetails()
            Catch exp As Exception
                lblMessage.Text &= exp.Message
            End Try
        Else
            lblMessage.Text &= "Record Insertion Failed !"
        End If
    End Sub

    Sub BindGrid()
        grdAFS.DataSource = Nothing
        grdAFS.DataBind()
        Try
            grdAFS.DataSource = Maintenance.ElecTables.getFurnaceData(CDate(txtDate.Text.Trim))
            grdAFS.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Sub clear()
        txtDate.Text = Date.Today
        txtMelt_no.Text = ""
        lblConsumption.Text = ""
        lblSlno.Text = ""
        ddlAF.SelectedIndex = 0
        lblTtoTsameAF.Text = ""
        lblTtoPsameAF.Text = ""
        lblTtoTanyAF.Text = ""
        txtMelt_month.Text = ""
        lblMeltingTime.Text = ""
        txtTR1.Text = ""
        txtRemarks.Text = ""
        txtTR1To.Text = ""
        txtVCB_no.Text = ""
        txtTR1From.Text = ""
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        clear()
        lblMessage.Text = ""
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Server.Transfer("/mss/selectModule.aspx")
    End Sub

    Private Sub btnExit1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Server.Transfer("/mss/selectModule.aspx")
    End Sub

    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        If lblMode.Text.Equals("edit") Or lblMode.Text.Equals("delete") Then
            lblMessage.Text = "Please enter the Melt No to be edited"
        Else
            BindGrid()
            getDetails()
        End If
    End Sub

    Private Sub txtTR1To_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTR1To.TextChanged
        lblMessage.Text = ""
        getMeltingTime()

    End Sub
    Private Sub getMeltingTime()
        Dim TR1From, TR2From, TR3From As DateTime
        Dim TR1To, TR2To, TR3To As DateTime
        Dim meltingtime, tr1, tr2, tr3 As Integer
        Dim str As String
        Try
            TR1From = CDate(txtTR1From.Text)
            TR1To = CDate(txtTR1To.Text)
            tr1 = DateDiff(DateInterval.Minute, TR1From, TR1To)

            TR2From = txtTR2From.Text
            TR2To = txtTR2to.Text
            tr2 = DateDiff(DateInterval.Minute, TR2From, TR2To)

            TR3From = txtTR3From.Text
            TR3To = txtTR3to.Text
            tr3 = DateDiff(DateInterval.Minute, TR3From, TR3To)
            meltingtime = tr1 + tr2 + tr3
            lblMeltingTime.Text = Maintenance.ElecTables.ConvertTimeInNumberToHour(meltingtime)
        Catch exp As Exception
            lblMessage.Text = "Enter Proper Time"
            Exit Sub
        End Try
    End Sub

    Private Sub txtTR1From_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTR1From.TextChanged
        lblMessage.Text = ""
        Dim DT As DateTime
        Try
            DT = txtTR1From.Text
        Catch exp As Exception
            lblMessage.Text = "Date not in correct format "
        End Try
    End Sub

    Private Sub txtTR2to_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTR2to.TextChanged
        lblMessage.Text = ""
        getMeltingTime()
    End Sub

    Private Sub txtTR3to_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTR3to.TextChanged
        lblMessage.Text = ""
        getMeltingTime()
    End Sub

    Private Sub txtTR2From_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTR2From.TextChanged
        lblMessage.Text = ""
        Dim DT As DateTime
        Try
            DT = txtTR2From.Text
        Catch exp As Exception
            lblMessage.Text = "Date not in correct format "
        End Try
    End Sub

    Private Sub txtTR3From_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTR3From.TextChanged
        lblMessage.Text = ""
        Dim DT As DateTime
        Try
            DT = txtTR3From.Text
        Catch exp As Exception
            lblMessage.Text = "Date not in correct format "
        End Try
    End Sub
    Private Sub getUnits()
        If Val(txtTR1Final.Text) < Val(txtTR1Initial.Text) Then
            lblMessage.Text = "Final Reading of TR1 is Less Than Initial"
            txtTR1Initial.Text = ""
            Exit Sub
        ElseIf Val(txtTR2final.Text) < Val(txtTR2Initial.Text) Then
            lblMessage.Text = "Final Reading of TR2 is Less Than Initial"
            txtTR1Initial.Text = ""
            Exit Sub
        ElseIf Val(txtTR3final.Text) < Val(txtTR3Initial.Text) Then
            lblMessage.Text = "Final Reading of TR3 is Less Than Initial"
            txtTR1Initial.Text = ""
            Exit Sub
        End If
        Dim Diff, diff1, diff2, diff3 As Decimal
        diff1.Round(23, 2)
        diff2.Round(23, 2)
        diff3.Round(23, 2)
        Diff.Round(23, 2)
        diff1 = diff1.Round(Convert.ToDecimal((txtTR1Final.Text.Trim - txtTR1Initial.Text.Trim) * rblMF.SelectedItem.Text), 2)
        diff2 = diff2.Round(Convert.ToDecimal((txtTR2final.Text.Trim - txtTR2Initial.Text.Trim) * rblMF.SelectedItem.Text), 2)
        diff3 = diff3.Round(Convert.ToDecimal((txtTR3final.Text.Trim - txtTR3Initial.Text.Trim) * rblMF.SelectedItem.Text), 2)
        Diff = diff1 + diff2 + diff3
        lblConsumption.Text = Diff
    End Sub
    Private Sub txtTR1Final_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTR1Final.TextChanged
        getUnits()
    End Sub

    Private Sub txtTR2final_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTR2final.TextChanged
        getUnits()
    End Sub

    Private Sub txtTR3final_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTR3final.TextChanged
        getUnits()
    End Sub

    Private Sub ddlAF_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlAF.SelectedIndexChanged
        Try
            populateTtoT()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub populateTtoT()
        Dim TtoTsame, TtoPsame, TtoTany As DateTime
        Dim AFTo, AFFrom As DateTime
        Dim TtoTsameAF, TtoPsameAF, TtoTanyAF As Integer
        Dim myarray As Array
        Dim myhour, mymin, mystr As String
        If txtTR3.Text <> 0 Then
            AFTo = Format(CDate(txtTR3to.Text), "dd-MM-yyyy HH:mm:ss")
        Else
            If txtTR2.Text <> 0 Then
                AFTo = Format(CDate(txtTR2to.Text), "dd-MM-yyyy HH:mm:ss")
            Else
                AFTo = Format(CDate(txtTR1To.Text), "dd-MM-yyyy HH:mm:ss")
            End If
        End If
        AFFrom = CDate(txtTR1From.Text.Trim)
        TtoTsame = Maintenance.ElecTables.TtoTsame(Val(txtMelt_no.Text), ddlAF.SelectedItem.Text)
        TtoTany = Maintenance.ElecTables.TtoTany(Val(txtMelt_no.Text))
        TtoTsameAF = DateDiff(DateInterval.Minute, TtoTsame, AFTo)
        If TtoTsameAF < 0 Then TtoTsameAF = 0
        lblTtoTsameAF.Text = Maintenance.ElecTables.ConvertTimeInNumberToHour(TtoTsameAF)
        mystr = lblTtoTsameAF.Text.Trim
        If mystr <> "" Then
            myarray = Split(mystr, ":")
            myhour = myarray(0)
            mymin = myarray(1)
            If myhour >= 24 And mymin >= 0 Then
                lblTtoTsameAF.Text = "00:00"
            Else
                lblTtoTsameAF.Text = lblTtoTsameAF.Text
            End If
        End If
        TtoPsameAF = DateDiff(DateInterval.Minute, TtoTsame, AFFrom)
        If TtoPsameAF < 0 Then TtoPsameAF = 0
        lblTtoPsameAF.Text = Maintenance.ElecTables.ConvertTimeInNumberToHour(TtoPsameAF)
        mystr = lblTtoPsameAF.Text.Trim
        If mystr <> "" Then
            myarray = Split(mystr, ":")
            myhour = myarray(0)
            mymin = myarray(1)
            If myhour >= 24 And mymin >= 0 Then
                lblTtoPsameAF.Text = "00:00"
            Else
                lblTtoPsameAF.Text = lblTtoPsameAF.Text
            End If
        End If
        TtoTanyAF = DateDiff(DateInterval.Minute, TtoTany, AFTo)
        If TtoTanyAF < 0 Then TtoTanyAF = 0
        lblTtoTanyAF.Text = Maintenance.ElecTables.ConvertTimeInNumberToHour(TtoTanyAF)
        mystr = lblTtoTanyAF.Text.Trim
        If mystr <> "" Then
            myarray = Split(mystr, ":")
            myhour = myarray(0)
            mymin = myarray(1)
            If myhour > 24 Then
                lblTtoTanyAF.Text = "00:00"
            Else
                lblTtoTanyAF.Text = lblTtoTanyAF.Text
            End If
        End If
    End Sub

    Private Sub txtMelt_no_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMelt_no.TextChanged
        If lblMode.Text.Equals("edit") Or lblMode.Text.Equals("delete") Then
            getEditDetails()
        End If
    End Sub

    Private Sub txtMelt_month_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMelt_month.TextChanged
        If lblMode.Text.Equals("edit") Or lblMode.Text.Equals("delete") Then
        End If
    End Sub

    Private Sub getEditDetails()
        Dim ds As DataSet
        Try
            ds = Maintenance.ElecTables.getEditDetails(Val(txtMelt_no.Text.Trim))
            Dim i As Integer
            i = 0
            For i = 0 To ds.Tables(0).Rows.Count - 1
                If i = 0 Then
                    If Not IsDBNull(ds.Tables(0).Rows(i)(0)) Then txtTR1.Text = ds.Tables(0).Rows(i)(1)
                    If Not IsDBNull(ds.Tables(0).Rows(i)(1)) Then txtTR1From.Text = ds.Tables(0).Rows(i)(2)
                    If Not IsDBNull(ds.Tables(0).Rows(i)(2)) Then txtTR1To.Text = ds.Tables(0).Rows(i)(3)
                    If Not IsDBNull(ds.Tables(0).Rows(i)(3)) Then txtTR1Initial.Text = ds.Tables(0).Rows(i)(5)
                    If Not IsDBNull(ds.Tables(0).Rows(i)(4)) Then txtTR1Final.Text = ds.Tables(0).Rows(i)(4)
                ElseIf i = 1 Then
                    If Not IsDBNull(ds.Tables(0).Rows(i)(0)) Then txtTR2.Text = ds.Tables(0).Rows(i)(1)
                    If Not IsDBNull(ds.Tables(0).Rows(i)(1)) Then txtTR2From.Text = ds.Tables(0).Rows(i)(2)
                    If Not IsDBNull(ds.Tables(0).Rows(i)(2)) Then txtTR2to.Text = ds.Tables(0).Rows(i)(3)
                    If Not IsDBNull(ds.Tables(0).Rows(i)(3)) Then txtTR2Initial.Text = ds.Tables(0).Rows(i)(5)
                    If Not IsDBNull(ds.Tables(0).Rows(i)(4)) Then txtTR2final.Text = ds.Tables(0).Rows(i)(4)
                ElseIf i = 2 Then
                    If Not IsDBNull(ds.Tables(0).Rows(i)(0)) Then txtTR2.Text = ds.Tables(0).Rows(i)(1)
                    If Not IsDBNull(ds.Tables(0).Rows(i)(1)) Then txtTR3From.Text = ds.Tables(0).Rows(i)(2)
                    If Not IsDBNull(ds.Tables(0).Rows(i)(2)) Then txtTR3to.Text = ds.Tables(0).Rows(i)(3)
                    If Not IsDBNull(ds.Tables(0).Rows(i)(3)) Then txtTR3Initial.Text = ds.Tables(0).Rows(i)(5)
                    If Not IsDBNull(ds.Tables(0).Rows(i)(4)) Then txtTR3final.Text = ds.Tables(0).Rows(i)(4)
                Else
                End If
            Next
            Dim Cnt As Int16
            Cnt = 0
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0)(0)) Then txtDate.Text = ds.Tables(1).Rows(0)(0)
                If Not IsDBNull(ds.Tables(1).Rows(0)(1)) Then txtMelt_month.Text = ds.Tables(1).Rows(0)(2)
                If Not IsDBNull(ds.Tables(1).Rows(0)(2)) Then txtMelt_no.Text = ds.Tables(1).Rows(0)(1)
                If Not IsDBNull(ds.Tables(1).Rows(0)(3)) Then lblConsumption.Text = ds.Tables(1).Rows(0)(3)

                If Not IsDBNull(ds.Tables(1).Rows(0)(2)) Then txtDemand.Text = ds.Tables(1).Rows(0)(7)
                If Not IsDBNull(ds.Tables(1).Rows(0)(8)) Then
                    For Cnt = 0 To ddlAF.Items.Count - 1
                        If ddlAF.Items(Cnt).Text = ds.Tables(1).Rows(0)(8) Then
                            ddlAF.SelectedIndex = Cnt
                            Exit For
                        End If
                    Next
                End If
                If Not IsDBNull(ds.Tables(1).Rows(0)(3)) Then txtVCB_no.Text = ds.Tables(1).Rows(0)(9)
                If Not IsDBNull(ds.Tables(1).Rows(0)(4)) Then lblMeltingTime.Text = ds.Tables(1).Rows(0)(10)
                If Not IsDBNull(ds.Tables(1).Rows(0)(0)) Then lblTtoTsameAF.Text = ds.Tables(1).Rows(0)(11)
                If Not IsDBNull(ds.Tables(1).Rows(0)(1)) Then lblTtoPsameAF.Text = ds.Tables(1).Rows(0)(12)
                If Not IsDBNull(ds.Tables(1).Rows(0)(2)) Then lblTtoTanyAF.Text = ds.Tables(1).Rows(0)(13)
                If Not IsDBNull(ds.Tables(1).Rows(0)(3)) Then txtRemarks.Text = ds.Tables(1).Rows(0)(14)
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            ds.Dispose()
        End Try
    End Sub
End Class
