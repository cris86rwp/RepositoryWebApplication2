Public Class MouldRoomPosition
    Inherits System.Web.UI.Page
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblShift As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents SW1Qty As System.Web.UI.WebControls.TextBox
    Protected WithEvents SW2Qty As System.Web.UI.WebControls.TextBox
    Protected WithEvents SW3Qty As System.Web.UI.WebControls.TextBox
    Protected WithEvents SW4Qty As System.Web.UI.WebControls.TextBox
    Protected WithEvents SW1InC As System.Web.UI.WebControls.TextBox
    Protected WithEvents SW1Remarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents SW2InC As System.Web.UI.WebControls.TextBox
    Protected WithEvents SW2Remarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents SW3InC As System.Web.UI.WebControls.TextBox
    Protected WithEvents SW3Remarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents SW4InC As System.Web.UI.WebControls.TextBox
    Protected WithEvents SW4Remarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents SW5Qty As System.Web.UI.WebControls.TextBox
    Protected WithEvents SW5InC As System.Web.UI.WebControls.TextBox
    Protected WithEvents SW5Remarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents SW6Qty As System.Web.UI.WebControls.TextBox
    Protected WithEvents SW6InC As System.Web.UI.WebControls.TextBox
    Protected WithEvents SW6Remarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents SW7Qty As System.Web.UI.WebControls.TextBox
    Protected WithEvents SW7InC As System.Web.UI.WebControls.TextBox
    Protected WithEvents SW7Remarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents SW8Qty As System.Web.UI.WebControls.TextBox
    Protected WithEvents SW8InC As System.Web.UI.WebControls.TextBox
    Protected WithEvents SW8Remarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents SGM1Qty As System.Web.UI.WebControls.TextBox
    Protected WithEvents SGM2Qty As System.Web.UI.WebControls.TextBox
    Protected WithEvents SGM3Qty As System.Web.UI.WebControls.TextBox
    Protected WithEvents SGM4Qty As System.Web.UI.WebControls.TextBox
    Protected WithEvents HCM1Qty As System.Web.UI.WebControls.TextBox
    Protected WithEvents HCM2Qty As System.Web.UI.WebControls.TextBox
    Protected WithEvents HCM3Qty As System.Web.UI.WebControls.TextBox
    'Protected WithEvents HCM4Qty As System.Web.UI.WebControls.TextBox
    'Protected WithEvents HCM5Qty As System.Web.UI.WebControls.TextBox
    'Protected WithEvents NFCQty As System.Web.UI.WebControls.TextBox
    'Protected WithEvents NFDQty As System.Web.UI.WebControls.TextBox
    'Protected WithEvents DFDQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents CBQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents CSQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents DSQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents COLQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents DOLQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents CSInC As System.Web.UI.WebControls.TextBox
    Protected WithEvents CSRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents DSInC As System.Web.UI.WebControls.TextBox
    Protected WithEvents DSRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents COLInC As System.Web.UI.WebControls.TextBox
    Protected WithEvents COLRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents DOLInC As System.Web.UI.WebControls.TextBox
    Protected WithEvents DOLRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents SGM1InC As System.Web.UI.WebControls.TextBox
    Protected WithEvents SGM1Remarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents SGM2InC As System.Web.UI.WebControls.TextBox
    Protected WithEvents SGM2Remarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents SGM3InC As System.Web.UI.WebControls.TextBox
    Protected WithEvents SGM3Remarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents SGM4InC As System.Web.UI.WebControls.TextBox
    Protected WithEvents SGM4REmarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents HCM1InC As System.Web.UI.WebControls.TextBox
    Protected WithEvents HCM1Remarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents HCM2InC As System.Web.UI.WebControls.TextBox
    Protected WithEvents HCM2Remarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents HCM3InC As System.Web.UI.WebControls.TextBox
    Protected WithEvents HCM3Remarks As System.Web.UI.WebControls.TextBox
    'Protected WithEvents HCM4InC As System.Web.UI.WebControls.TextBox
    'Protected WithEvents HCM4Remarks As System.Web.UI.WebControls.TextBox
    'Protected WithEvents HCM5InC As System.Web.UI.WebControls.TextBox
    'Protected WithEvents HCM5Remarks As System.Web.UI.WebControls.TextBox
    'Protected WithEvents NFCInC As System.Web.UI.WebControls.TextBox
    'Protected WithEvents NFCRemarks As System.Web.UI.WebControls.TextBox
    'Protected WithEvents NFDInC As System.Web.UI.WebControls.TextBox
    'Protected WithEvents NFDRemarks As System.Web.UI.WebControls.TextBox
    'Protected WithEvents DFDInC As System.Web.UI.WebControls.TextBox
    'Protected WithEvents DFDRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents CBInC As System.Web.UI.WebControls.TextBox
    Protected WithEvents CBRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents ShiftInC As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnClear As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents WhlsCast As System.Web.UI.WebControls.TextBox
    Protected WithEvents MROffLoad As System.Web.UI.WebControls.TextBox
    Protected WithEvents Panel2 As System.Web.UI.WebControls.Panel
    Protected WithEvents Panel3 As System.Web.UI.WebControls.Panel
    Protected WithEvents txtFr As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTo As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnShow As System.Web.UI.WebControls.Button
    Protected WithEvents Panel4 As System.Web.UI.WebControls.Panel
    Protected WithEvents RCLess12 As System.Web.UI.WebControls.TextBox
    Protected WithEvents RCGr18 As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnMelt As System.Web.UI.WebControls.Button
    Protected WithEvents SWLess400 As System.Web.UI.WebControls.TextBox
    Protected WithEvents HCLess250 As System.Web.UI.WebControls.TextBox
    Protected WithEvents CSGr230 As System.Web.UI.WebControls.TextBox
    Protected WithEvents CSLess170 As System.Web.UI.WebControls.TextBox
    Protected WithEvents DSGr230 As System.Web.UI.WebControls.TextBox
    Protected WithEvents DSLess170 As System.Web.UI.WebControls.TextBox
    Protected WithEvents CSRecSts As System.Web.UI.WebControls.TextBox
    Protected WithEvents DSRecSts As System.Web.UI.WebControls.TextBox
    Protected WithEvents SWRecSts As System.Web.UI.WebControls.TextBox
    Protected WithEvents HCRecSts As System.Web.UI.WebControls.TextBox
    Protected WithEvents RK1BrushSts As System.Web.UI.WebControls.TextBox
    Protected WithEvents RK2BrushSts As System.Web.UI.WebControls.TextBox
    Protected WithEvents C5IE As System.Web.UI.WebControls.TextBox
    Protected WithEvents C5IW As System.Web.UI.WebControls.TextBox
    Protected WithEvents C5KE As System.Web.UI.WebControls.TextBox
    Protected WithEvents C5KW As System.Web.UI.WebControls.TextBox
    Protected WithEvents SWCQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents SWCInC As System.Web.UI.WebControls.TextBox
    Protected WithEvents SWPGQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents SWPGInC As System.Web.UI.WebControls.TextBox
    Protected WithEvents SWPGRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents SWCRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents NBDQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents DDUQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents DDUInC As System.Web.UI.WebControls.TextBox
    Protected WithEvents NBDInC As System.Web.UI.WebControls.TextBox
    Protected WithEvents NBDRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents DDURemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents MPO1 As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents MPO2 As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents MPO3 As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents CopesQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents DragsQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents SandQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents CopesMQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents DragsMQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents PTQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents CopesInC As System.Web.UI.WebControls.TextBox
    Protected WithEvents CopesRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents DragsInC As System.Web.UI.WebControls.TextBox
    Protected WithEvents DragsRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents CopesMInC As System.Web.UI.WebControls.TextBox
    Protected WithEvents CopesMRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents DragsMInC As System.Web.UI.WebControls.TextBox
    Protected WithEvents DragsMRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents SandInC As System.Web.UI.WebControls.TextBox
    Protected WithEvents PTInC As System.Web.UI.WebControls.TextBox
    Protected WithEvents SandRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents PTRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
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
        'Session("UserID") = "016002"
        'Session("Group") = "MLDING"
        C5IE.ReadOnly = True
        C5KE.ReadOnly = True
        C5IW.ReadOnly = True
        C5KW.ReadOnly = True

        If Page.IsPostBack = False Then
            txtDate.Text = Now.Date
            txtFr.Text = Now.Date
            txtTo.Text = Now.Date
            Dim str As String
            Select Case Now.Hour
                Case 6 To 13
                    str = "A"
                Case 14 To 21
                    str = "B"
                Case Else
                    str = "C"
                    txtDate.Text = Now.Date.AddDays(-1)
                    txtFr.Text = Now.Date.AddDays(-1)
                    txtTo.Text = Now.Date.AddDays(-1)
            End Select
            rblShift.ClearSelection()
            Dim i As Integer
            For i = 0 To rblShift.Items.Count - 1
                If str = rblShift.Items(i).Text Then
                    rblShift.Items(i).Selected = True
                    Exit For
                End If
            Next
            Try
                GetData()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        lblMessage.Text = ""
        Dim dt As Date
        Try
            dt = CDate(txtDate.Text)
            If dt > Now.Date Then
                lblMessage.Text = "Future date not allowed "
                txtDate.Text = ""
            Else
                txtDate.Text = dt
                GetData()
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt = Nothing
        End Try
    End Sub

    Private Sub rblShift_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblShift.SelectedIndexChanged
        lblMessage.Text = ""
        Dim dt As Date
        Try
            dt = CDate(txtDate.Text)
            If dt > Now.Date Then
                lblMessage.Text = "Future date not allowed "
                txtDate.Text = ""
            Else
                txtDate.Text = dt
                GetData()
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt = Nothing
        End Try
    End Sub
    Private Sub GetData()
        Clear()
        Dim ds As New DataSet()
        Try
            ds = RWF.MLDING.MROutTurnData(CDate(txtDate.Text), rblShift.SelectedItem.Value)
            If ds.Tables(0).Rows.Count > 0 Then
                WhlsCast.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("WhlsCast")), 0, ds.Tables(0).Rows(0)("WhlsCast"))
                MROffLoad.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("MROffLoad")), 0, ds.Tables(0).Rows(0)("MROffLoad"))
                SW1Qty.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("SW1Qty")), 0, ds.Tables(0).Rows(0)("SW1Qty"))
                SW1InC.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("SW1InC")), "", ds.Tables(0).Rows(0)("SW1InC"))
                SW1Remarks.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("SW1Remarks")), "", ds.Tables(0).Rows(0)("SW1Remarks"))
                SW2Qty.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("SW2Qty")), 0, ds.Tables(0).Rows(0)("SW2Qty"))
                SW2InC.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("SW2InC")), "", ds.Tables(0).Rows(0)("SW2InC"))
                SW2Remarks.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("SW2Remarks")), "", ds.Tables(0).Rows(0)("SW2Remarks"))
                SW3Qty.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("SW3Qty")), 0, ds.Tables(0).Rows(0)("SW3Qty"))
                SW3InC.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("SW3InC")), "", ds.Tables(0).Rows(0)("SW3InC"))
                SW3Remarks.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("SW3Remarks")), "", ds.Tables(0).Rows(0)("SW3Remarks"))
                SW4Qty.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("SW4Qty")), 0, ds.Tables(0).Rows(0)("SW4Qty"))
                SW4InC.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("SW4InC")), "", ds.Tables(0).Rows(0)("SW4InC"))
                SW4Remarks.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("SW4Remarks")), "", ds.Tables(0).Rows(0)("SW4Remarks"))
                SW5Qty.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("SW5Qty")), 0, ds.Tables(0).Rows(0)("SW5Qty"))
                SW5InC.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("SW5InC")), "", ds.Tables(0).Rows(0)("SW5InC"))
                SW5Remarks.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("SW5Remarks")), "", ds.Tables(0).Rows(0)("SW5Remarks"))
                SW6Qty.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("SW6Qty")), 0, ds.Tables(0).Rows(0)("SW6Qty"))
                SW6InC.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("SW6InC")), "", ds.Tables(0).Rows(0)("SW6InC"))
                SW6Remarks.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("SW6Remarks")), "", ds.Tables(0).Rows(0)("SW6Remarks"))
                SW7Qty.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("SW7Qty")), 0, ds.Tables(0).Rows(0)("SW7Qty"))
                SW7InC.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("SW7InC")), "", ds.Tables(0).Rows(0)("SW7InC"))
                SW7Remarks.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("SW7Remarks")), "", ds.Tables(0).Rows(0)("SW7Remarks"))
                SW8Qty.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("SW8Qty")), 0, ds.Tables(0).Rows(0)("SW8Qty"))
                SW8InC.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("SW8InC")), "", ds.Tables(0).Rows(0)("SW8InC"))
                SW8Remarks.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("SW8Remarks")), "", ds.Tables(0).Rows(0)("SW8Remarks"))
                SGM1Qty.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("SGM1Qty")), 0, ds.Tables(0).Rows(0)("SGM1Qty"))
                SGM1InC.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("SGM1InC")), "", ds.Tables(0).Rows(0)("SGM1InC"))
                SGM1Remarks.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("SGM1Remarks")), "", ds.Tables(0).Rows(0)("SGM1Remarks"))
                SGM2Qty.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("SGM2Qty")), 0, ds.Tables(0).Rows(0)("SGM2Qty"))
                SGM2InC.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("SGM2InC")), "", ds.Tables(0).Rows(0)("SGM2InC"))
                SGM2Remarks.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("SGM2Remarks")), "", ds.Tables(0).Rows(0)("SGM2Remarks"))
                SGM3Qty.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("SGM3Qty")), 0, ds.Tables(0).Rows(0)("SGM3Qty"))
                SGM3InC.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("SGM3InC")), "", ds.Tables(0).Rows(0)("SGM3InC"))
                SGM3Remarks.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("SGM3Remarks")), "", ds.Tables(0).Rows(0)("SGM3Remarks"))
                SGM4Qty.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("SGM4Qty")), 0, ds.Tables(0).Rows(0)("SGM4Qty"))
                SGM4InC.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("SGM4InC")), "", ds.Tables(0).Rows(0)("SGM4InC"))
                SGM4REmarks.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("SGM4REmarks")), "", ds.Tables(0).Rows(0)("SGM4REmarks"))
                HCM1Qty.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("HCM1Qty")), 0, ds.Tables(0).Rows(0)("HCM1Qty"))
                HCM1InC.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("HCM1InC")), "", ds.Tables(0).Rows(0)("HCM1InC"))
                HCM1Remarks.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("HCM1Remarks")), "", ds.Tables(0).Rows(0)("HCM1Remarks"))
                HCM2Qty.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("HCM2Qty")), 0, ds.Tables(0).Rows(0)("HCM2Qty"))
                HCM2InC.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("HCM2InC")), "", ds.Tables(0).Rows(0)("HCM2InC"))
                HCM2Remarks.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("HCM2Remarks")), "", ds.Tables(0).Rows(0)("HCM2Remarks"))
                HCM3Qty.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("HCM3Qty")), 0, ds.Tables(0).Rows(0)("HCM3Qty"))
                HCM3InC.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("HCM3InC")), "", ds.Tables(0).Rows(0)("HCM3InC"))
                HCM3Remarks.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("HCM3Remarks")), "", ds.Tables(0).Rows(0)("HCM3Remarks"))
                'HCM4Qty.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("HCM4Qty")), 0, ds.Tables(0).Rows(0)("HCM4Qty"))
                'HCM4InC.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("HCM4InC")), "", ds.Tables(0).Rows(0)("HCM4InC"))
                'HCM4Remarks.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("HCM4Remarks")), "", ds.Tables(0).Rows(0)("HCM4Remarks"))
                'HCM5Qty.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("HCM5Qty")), 0, ds.Tables(0).Rows(0)("HCM5Qty"))
                'HCM5InC.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("HCM5InC")), "", ds.Tables(0).Rows(0)("HCM5InC"))
                'HCM5Remarks.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("HCM5Remarks")), "", ds.Tables(0).Rows(0)("HCM5Remarks"))
                'NFCQty.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("NFCQty")), 0, ds.Tables(0).Rows(0)("NFCQty"))
                'NFCInC.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("NFCInC")), "", ds.Tables(0).Rows(0)("NFCInC"))
                'NFCRemarks.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("NFCRemarks")), "", ds.Tables(0).Rows(0)("NFCRemarks"))
                'NFDQty.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("NFDQty")), 0, ds.Tables(0).Rows(0)("NFDQty"))
                'NFDInC.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("NFDInC")), "", ds.Tables(0).Rows(0)("NFDInC"))
                'NFDRemarks.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("NFDRemarks")), "", ds.Tables(0).Rows(0)("NFDRemarks"))
                'DFDQty.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("DFDQty")), 0, ds.Tables(0).Rows(0)("DFDQty"))
                'DFDInC.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("DFDInC")), "", ds.Tables(0).Rows(0)("DFDInC"))
                'DFDRemarks.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("DFDRemarks")), "", ds.Tables(0).Rows(0)("DFDRemarks"))
                CBQty.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("CBQty")), 0, ds.Tables(0).Rows(0)("CBQty"))
                CBInC.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("CBInC")), "", ds.Tables(0).Rows(0)("CBInC"))
                CBRemarks.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("CBRemarks")), "", ds.Tables(0).Rows(0)("CBRemarks"))
                CSQty.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("CSQty")), 0, ds.Tables(0).Rows(0)("CSQty"))
                CSInC.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("CSInC")), "", ds.Tables(0).Rows(0)("CSInC"))
                CSRemarks.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("CSRemarks")), "", ds.Tables(0).Rows(0)("CSRemarks"))
                DSQty.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("DSQty")), 0, ds.Tables(0).Rows(0)("DSQty"))
                DSInC.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("DSInC")), "", ds.Tables(0).Rows(0)("DSInC"))
                DSRemarks.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("DSRemarks")), "", ds.Tables(0).Rows(0)("DSRemarks"))
                COLQty.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("COLQty")), 0, ds.Tables(0).Rows(0)("COLQty"))
                COLInC.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("COLInC")), "", ds.Tables(0).Rows(0)("COLInC"))
                COLRemarks.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("COLRemarks")), "", ds.Tables(0).Rows(0)("COLRemarks"))
                DOLQty.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("DOLQty")), 0, ds.Tables(0).Rows(0)("DOLQty"))
                DOLInC.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("DOLInC")), "", ds.Tables(0).Rows(0)("DOLInC"))
                DOLRemarks.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("DOLRemarks")), "", ds.Tables(0).Rows(0)("DOLRemarks"))
                ShiftInC.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("ShiftInC")), "", ds.Tables(0).Rows(0)("ShiftInC"))

                RCLess12.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("RCLess12")), "", ds.Tables(0).Rows(0)("RCLess12"))
                RCGr18.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("RCGr18")), "", ds.Tables(0).Rows(0)("RCGr18"))

                SWLess400.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("SWLess400")), 0, ds.Tables(0).Rows(0)("SWLess400"))
                HCLess250.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("HCLess250")), 0, ds.Tables(0).Rows(0)("HCLess250"))
                CSGr230.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("CSGr230")), 0, ds.Tables(0).Rows(0)("CSGr230"))
                CSLess170.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("CSLess170")), 0, ds.Tables(0).Rows(0)("CSLess170"))
                DSGr230.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("DSGr230")), 0, ds.Tables(0).Rows(0)("DSGr230"))
                DSLess170.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("DSLess170")), 0, ds.Tables(0).Rows(0)("DSLess170"))

                SWRecSts.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("SWRecSts")), "", ds.Tables(0).Rows(0)("SWRecSts"))
                HCRecSts.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("HCRecSts")), "", ds.Tables(0).Rows(0)("HCRecSts"))
                CSRecSts.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("CSRecSts")), "", ds.Tables(0).Rows(0)("CSRecSts"))
                DSRecSts.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("DSRecSts")), "", ds.Tables(0).Rows(0)("DSRecSts"))
                RK1BrushSts.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("RK1BrushSts")), "", ds.Tables(0).Rows(0)("RK1BrushSts"))
                RK2BrushSts.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("RK2BrushSts")), "", ds.Tables(0).Rows(0)("RK2BrushSts"))
                C5IE.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("C5IE")), "", ds.Tables(0).Rows(0)("C5IE"))
                C5IW.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("C5IW")), "", ds.Tables(0).Rows(0)("C5IW"))
                C5KE.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("C5KE")), "", ds.Tables(0).Rows(0)("C5KE"))
                C5KW.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("C5KW")), "", ds.Tables(0).Rows(0)("C5KW"))

                SWCQty.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("SWCQty")), 0, ds.Tables(0).Rows(0)("SWCQty"))
                SWCInC.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("SWCInC")), "", ds.Tables(0).Rows(0)("SWCInC"))
                SWCRemarks.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("SWCRemarks")), "", ds.Tables(0).Rows(0)("SWCRemarks"))
                SWPGQty.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("SWPGQty")), 0, ds.Tables(0).Rows(0)("SWPGQty"))
                SWPGInC.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("SWPGInC")), "", ds.Tables(0).Rows(0)("SWPGInC"))
                SWPGRemarks.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("SWPGRemarks")), "", ds.Tables(0).Rows(0)("SWPGRemarks"))
                NBDQty.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("NBDQty")), 0, ds.Tables(0).Rows(0)("NBDQty"))
                NBDInC.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("NBDInC")), "", ds.Tables(0).Rows(0)("NBDInC"))
                NBDRemarks.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("NBDRemarks")), "", ds.Tables(0).Rows(0)("NBDRemarks"))
                DDUQty.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("DDUQty")), 0, ds.Tables(0).Rows(0)("DDUQty"))
                DDUInC.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("DDUInC")), "", ds.Tables(0).Rows(0)("DDUInC"))
                DDURemarks.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("DDURemarks")), "", ds.Tables(0).Rows(0)("DDURemarks"))

                CopesQty.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("CopesQty")), 0, ds.Tables(0).Rows(0)("CopesQty"))
                CopesInC.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("CopesInC")), "", ds.Tables(0).Rows(0)("CopesInC"))
                CopesRemarks.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("CopesRemarks")), "", ds.Tables(0).Rows(0)("CopesRemarks"))

                DragsQty.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("DragsQty")), 0, ds.Tables(0).Rows(0)("DragsQty"))
                DragsInC.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("DragsInC")), "", ds.Tables(0).Rows(0)("DragsInC"))
                DragsRemarks.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("DragsRemarks")), "", ds.Tables(0).Rows(0)("DragsRemarks"))

                CopesQty.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("CopesMQty")), 0, ds.Tables(0).Rows(0)("CopesQty"))
                CopesInC.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("CopesMInC")), "", ds.Tables(0).Rows(0)("CopesInC"))
                CopesRemarks.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("CopesMRemarks")), "", ds.Tables(0).Rows(0)("CopesRemarks"))

                DragsQty.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("DragsMQty")), 0, ds.Tables(0).Rows(0)("DragsQty"))
                DragsInC.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("DragsMInC")), "", ds.Tables(0).Rows(0)("DragsInC"))
                DragsRemarks.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("DragsMRemarks")), "", ds.Tables(0).Rows(0)("DragsRemarks"))

                SandQty.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("SandQty")), 0, ds.Tables(0).Rows(0)("SandQty"))
                SandInC.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("SandInC")), "", ds.Tables(0).Rows(0)("SandInC"))
                SandRemarks.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("SandRemarks")), "", ds.Tables(0).Rows(0)("SandRemarks"))

                PTQty.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("PTQty")), 0, ds.Tables(0).Rows(0)("PTQty"))
                PTInC.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("PTInC")), "", ds.Tables(0).Rows(0)("PTInC"))
                PTRemarks.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("PTRemarks")), "", ds.Tables(0).Rows(0)("PTRemarks"))
                Dim i As Int16
                i = 0
                MPO1.ClearSelection()
                For i = 0 To MPO1.Items.Count - 1
                    If MPO1.Items(i).Value = Val(IIf(IsDBNull(ds.Tables(0).Rows(0)("MPO1")), 0, ds.Tables(0).Rows(0)("MPO1"))) Then
                        MPO1.Items(i).Selected = True
                        Exit For
                    End If
                Next

                i = 0
                MPO2.ClearSelection()
                For i = 0 To MPO2.Items.Count - 1
                    If MPO2.Items(i).Value = Val(IIf(IsDBNull(ds.Tables(0).Rows(0)("MPO2")), 0, ds.Tables(0).Rows(0)("MPO2"))) Then
                        MPO2.Items(i).Selected = True
                        Exit For
                    End If
                Next

                i = 0
                MPO3.ClearSelection()
                For i = 0 To MPO3.Items.Count - 1
                    If MPO3.Items(i).Value = Val(IIf(IsDBNull(ds.Tables(0).Rows(0)("MPO3")), 0, ds.Tables(0).Rows(0)("MPO3"))) Then
                        MPO3.Items(i).Selected = True
                        Exit For
                    End If
                Next
            End If
        Catch exp As Exception
            lblMessage.Text = "Data Filling  Failed : " & exp.Message
        Finally
            ds.Dispose()
        End Try
        Try
            FillGrid()
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
    End Sub
    Private Sub FillGrid()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Dim dt As New DataTable()
        Try
            dt = RWF.MLDING.MROutTurn(CDate(txtDate.Text), rblShift.SelectedItem.Value)
            DataGrid1.DataSource = dt.DefaultView
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = "Data Grid Filling Failed : " & exp.Message
        Finally
            dt.Dispose()
        End Try
    End Sub

    Private Sub Clear()
        C5KW.Text = ""
        C5KE.Text = ""
        C5IW.Text = ""
        C5IE.Text = ""
        RK2BrushSts.Text = ""
        RK1BrushSts.Text = ""
        DSRecSts.Text = ""
        CSRecSts.Text = ""
        HCRecSts.Text = ""
        SWRecSts.Text = ""
        DSLess170.Text = ""
        DSGr230.Text = ""
        CSLess170.Text = ""
        CSGr230.Text = ""
        HCLess250.Text = ""
        SWLess400.Text = ""
        RCLess12.Text = ""
        RCGr18.Text = ""
        WhlsCast.Text = ""
        MROffLoad.Text = ""
        SW1Qty.Text = ""
        SW1InC.Text = ""
        SW1Remarks.Text = ""
        SW2Qty.Text = ""
        SW2InC.Text = ""
        SW2Remarks.Text = ""
        SW3Qty.Text = ""
        SW3InC.Text = ""
        SW3Remarks.Text = ""
        SW4Qty.Text = ""
        SW4InC.Text = ""
        SW4Remarks.Text = ""
        SW5Qty.Text = ""
        SW5InC.Text = ""
        SW5Remarks.Text = ""
        SW6Qty.Text = ""
        SW6InC.Text = ""
        SW6Remarks.Text = ""
        SW7Qty.Text = ""
        SW7InC.Text = ""
        SW7Remarks.Text = ""
        SW8Qty.Text = ""
        SW8InC.Text = ""
        SW8Remarks.Text = ""
        SGM1Qty.Text = ""
        SGM1InC.Text = ""
        SGM1Remarks.Text = ""
        SGM2Qty.Text = ""
        SGM2InC.Text = ""
        SGM2Remarks.Text = ""
        SGM3Qty.Text = ""
        SGM3InC.Text = ""
        SGM3Remarks.Text = ""
        SGM4Qty.Text = ""
        SGM4InC.Text = ""
        SGM4REmarks.Text = ""
        HCM1Qty.Text = ""
        HCM1InC.Text = ""
        HCM1Remarks.Text = ""
        HCM2Qty.Text = ""
        HCM2InC.Text = ""
        HCM2Remarks.Text = ""
        HCM3Qty.Text = ""
        HCM3InC.Text = ""
        HCM3Remarks.Text = ""
        'HCM4Qty.Text = ""
        'HCM4InC.Text = ""
        'HCM4Remarks.Text = ""
        'HCM5Qty.Text = ""
        'HCM5InC.Text = ""
        'HCM5Remarks.Text = ""
        'NFCQty.Text = ""
        'NFCInC.Text = ""
        'NFCRemarks.Text = ""
        'NFDQty.Text = ""
        'NFDInC.Text = ""
        'NFDRemarks.Text = ""
        'DFDQty.Text = ""
        'DFDInC.Text = ""
        'DFDRemarks.Text = ""
        CBQty.Text = ""
        CBInC.Text = ""
        CBRemarks.Text = ""
        CSQty.Text = ""
        CSInC.Text = ""
        CSRemarks.Text = ""
        DSQty.Text = ""
        DSInC.Text = ""
        DSRemarks.Text = ""
        COLQty.Text = ""
        COLInC.Text = ""
        COLRemarks.Text = ""
        DOLQty.Text = ""
        DOLInC.Text = ""
        DOLRemarks.Text = ""
        ShiftInC.Text = ""
        NBDQty.Text = ""
        NBDInC.Text = ""
        NBDRemarks.Text = ""
        DDUQty.Text = ""
        DDUInC.Text = ""
        DDURemarks.Text = ""
        CopesQty.Text = ""
        CopesInC.Text = ""
        CopesRemarks.Text = ""
        DragsMQty.Text = ""
        DragsMInC.Text = ""
        DragsMRemarks.Text = ""
        CopesMQty.Text = ""
        CopesMInC.Text = ""
        CopesMRemarks.Text = ""
        DragsMQty.Text = ""
        DragsMInC.Text = ""
        DragsMRemarks.Text = ""
        SandQty.Text = ""
        SandInC.Text = ""
        SandRemarks.Text = ""
        PTQty.Text = ""
        PTInC.Text = ""
        PTRemarks.Text = ""
        MPO1.SelectedIndex = 0
        MPO2.SelectedIndex = 0
        MPO3.SelectedIndex = 0
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim Done As Boolean
        Dim blnInsert As Boolean
        Dim dt As Date
        Try
            dt = CDate(txtDate.Text)
            'If dt.Date < Now.Date.AddDays(-3) Then
            '    lblMessage.Text = "Editing of prevoius dates ( " & dt & " )not allowed "
            '    txtDate.Text = ""
            '    Exit Sub
            'End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt = Nothing
        End Try
        Try
            Done = New RWF.MLDING().OutTurn(CDate(txtDate.Text),
            rblShift.SelectedItem.Value, ShiftInC.Text.Trim & "",
            Val(SW1Qty.Text), SW1InC.Text & "", SW1Remarks.Text & "",
            Val(SW2Qty.Text), SW2InC.Text & "", SW2Remarks.Text & "",
            Val(SW3Qty.Text), SW3InC.Text & "", SW3Remarks.Text & "",
            Val(SW4Qty.Text), SW4InC.Text & "", SW4Remarks.Text & "",
            Val(SW5Qty.Text), SW5InC.Text & "", SW5Remarks.Text & "",
            Val(SW6Qty.Text), SW6InC.Text & "", SW6Remarks.Text & "",
            Val(SW7Qty.Text), SW7InC.Text & "", SW7Remarks.Text & "",
            Val(SW8Qty.Text), SW8InC.Text & "", SW8Remarks.Text & "",
            Val(SGM1Qty.Text), SGM1InC.Text & "", SGM1Remarks.Text & "",
            Val(SGM2Qty.Text), SGM2InC.Text & "", SGM2Remarks.Text & "",
            Val(SGM3Qty.Text), SGM3InC.Text & "", SGM3Remarks.Text & "",
            Val(SGM4Qty.Text), SGM4InC.Text & "", SGM4REmarks.Text & "",
            Val(HCM1Qty.Text), HCM1InC.Text & "", HCM1Remarks.Text & "",
            Val(HCM2Qty.Text), HCM2InC.Text & "", HCM2Remarks.Text & "",
            Val(HCM3Qty.Text), HCM3InC.Text & "", HCM3Remarks.Text & "",
            Val(CBQty.Text), CBInC.Text & "", CBRemarks.Text & "",
            Val(CSQty.Text), CSInC.Text & "", CSRemarks.Text & "",
            Val(DSQty.Text), DSInC.Text & "", DSRemarks.Text & "",
            Val(COLQty.Text), COLInC.Text & "", COLRemarks.Text & "",
            Val(DOLQty.Text), DOLInC.Text & "", DOLRemarks.Text & "",
            Val(WhlsCast.Text), Val(MROffLoad.Text), Val(SWLess400.Text),
            Val(HCLess250.Text), Val(CSGr230.Text), Val(CSLess170.Text),
            Val(DSGr230.Text), Val(DSLess170.Text),
            SWRecSts.Text & "", HCRecSts.Text & "",
            CSRecSts.Text & "", DSRecSts.Text & "",
            RK1BrushSts.Text & "", RK2BrushSts.Text & "",
            C5IE.Text & "", C5IW.Text & "", C5KE.Text & "", C5KW.Text & "",
            Val(SWCQty.Text), SWCInC.Text & "", SWCRemarks.Text,
            Val(SWPGQty.Text), SWPGInC.Text & "", SWPGRemarks.Text,
            Val(NBDQty.Text), NBDInC.Text & "", NBDRemarks.Text & "",
            Val(DDUQty.Text), DDUInC.Text & "", DDURemarks.Text & "",
            Val(CopesQty.Text), CopesInC.Text, CopesRemarks.Text & "",
            Val(DragsQty.Text), DragsInC.Text & "", DragsRemarks.Text & "",
            Val(CopesMQty.Text), CopesMInC.Text, CopesMRemarks.Text & "",
            Val(DragsMQty.Text), DragsMInC.Text & "", DragsMRemarks.Text & "",
            Val(SandQty.Text), SandInC.Text & "", SandRemarks.Text.Trim,
            Val(PTQty.Text), PTInC.Text.Trim, PTRemarks.Text.Trim,
            MPO1.SelectedItem.Value, MPO2.SelectedItem.Value, MPO3.SelectedItem.Value)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            If Done Then
                lblMessage.Text = " Updation Successful !"
                Clear()
            Else
                lblMessage.Text &= " Updation Failed ! "
            End If
        End Try
        Try
            FillGrid()
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Clear()
    End Sub

    Private Sub txtFr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFr.TextChanged
        lblMessage.Text = ""
        Dim dt As Date
        Try
            dt = CDate(txtFr.Text)
            If dt > Now.Date Then
                lblMessage.Text = "Future date not allowed "
                txtFr.Text = ""
            Else
                txtFr.Text = dt
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt = Nothing
        End Try
    End Sub

    Private Sub txtTo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTo.TextChanged
        lblMessage.Text = ""
        Dim dt As Date
        Try
            dt = CDate(txtTo.Text)
            If dt > Now.Date Then
                lblMessage.Text = "Future date not allowed "
                txtTo.Text = ""
            Else
                txtTo.Text = dt
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt = Nothing
        End Try
    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Dim dt As New DataTable()
        Try
            dt = RWF.MLDING.MROutTurnData(CDate(txtFr.Text), CDate(txtTo.Text))
            DataGrid1.DataSource = dt.DefaultView
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = "Data Grid Filling  Failed : " & exp.Message
        Finally
            dt.Dispose()
        End Try
    End Sub

    Private Sub btnMelt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMelt.Click
        Dim Done As Boolean
        Dim blnInsert As Boolean
        Dim da As SqlClient.SqlDataAdapter
        Dim ds As New DataSet()
        da = rwfGen.Connection.Adapter
        da.SelectCommand.CommandText = "select *  from mm_MROutTurnNew where OutTurnDate  = @OutTurnDate and Shift = @Shift "
        da.SelectCommand.Parameters.Add("@OutTurnDate", SqlDbType.SmallDateTime, 4).Value = CDate(txtDate.Text)
        da.SelectCommand.Parameters.Add("@Shift", SqlDbType.VarChar, 1).Value = rblShift.SelectedItem.Value
        Try
            da.Fill(ds)
            If ds.Tables(0).Rows.Count = 0 Then
                blnInsert = True
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            ds.Dispose()
            da.Dispose()
        End Try
        Dim dt As Date
        Try
            dt = CDate(txtDate.Text)
            If dt.Date < Now.Date.AddDays(-2) Then
                lblMessage.Text = "Editing of prevoius dates ( " & dt & " )not allowed "
                txtDate.Text = ""
                Exit Sub
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt = Nothing
        End Try
        Dim oCmd As New SqlClient.SqlCommand()
        oCmd = rwfGen.Connection.CmdObj
        Dim strInsert, strUpdate As String

        Try
            oCmd.Parameters.Add("@OutTurnDate", SqlDbType.SmallDateTime, 4)
            oCmd.Parameters("@OutTurnDate").Direction = ParameterDirection.Input
            oCmd.Parameters("@OutTurnDate").Value = CDate(txtDate.Text)
            oCmd.Parameters.Add("@Shift", SqlDbType.VarChar, 1)
            oCmd.Parameters("@Shift").Direction = ParameterDirection.Input
            oCmd.Parameters("@Shift").Value = rblShift.SelectedItem.Value

            strInsert = " insert into mm_MROutTurnNew ( OutTurnDate,Shift, RCLess12 , RCGr18 ) values ( @OutTurnDate,@Shift,@RCLess12,@RCGr18 )  "

            strUpdate = " update mm_MROutTurnNew set RCLess12 = @RCLess12 , RCGr18 = @RCGr18 where OutTurnDate = @OutTurnDate and Shift = @Shift "

            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            oCmd.Transaction = oCmd.Connection.BeginTransaction
            If blnInsert Then
                oCmd.CommandText = strInsert
            Else
                oCmd.CommandText = strUpdate
            End If
            oCmd.Parameters.Add("@RCLess12", SqlDbType.Decimal, 9, 2)
            oCmd.Parameters("@RCLess12").Direction = ParameterDirection.Input
            oCmd.Parameters("@RCLess12").Value = RCLess12.Text.Trim & ""
            oCmd.Parameters.Add("@RCGr18", SqlDbType.Decimal, 9, 2)
            oCmd.Parameters("@RCGr18").Direction = ParameterDirection.Input
            oCmd.Parameters("@RCGr18").Value = RCGr18.Text & ""
            If oCmd.ExecuteNonQuery = 1 Then
                Done = True
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            If Not IsNothing(oCmd) Then
                If Done Then
                    oCmd.Transaction.Commit()
                    lblMessage.Text = " Updation Successful !"
                    Clear()
                Else
                    lblMessage.Text &= " Updation Failed ! "
                    oCmd.Transaction.Rollback()
                End If
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End If
        End Try
        Try
            FillGrid()
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
    End Sub

    Protected Sub DataGrid1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DataGrid1.SelectedIndexChanged

    End Sub
End Class
