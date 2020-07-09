Public Class ElecPFReadings
    Inherits System.Web.UI.Page
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents Label9 As System.Web.UI.WebControls.Label
    Protected WithEvents Label10 As System.Web.UI.WebControls.Label
    Protected WithEvents Label11 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label12 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label13 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label14 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label15 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label16 As System.Web.UI.WebControls.Label
    Protected WithEvents Label17 As System.Web.UI.WebControls.Label
    Protected WithEvents Label18 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label19 As System.Web.UI.WebControls.Label
    'Protected WithEvents Label20 As System.Web.UI.WebControls.Label
    Protected WithEvents Label21 As System.Web.UI.WebControls.Label
    Protected WithEvents Label22 As System.Web.UI.WebControls.Label
    Protected WithEvents Label23 As System.Web.UI.WebControls.Label
    Protected WithEvents FirstPFAFII As System.Web.UI.WebControls.TextBox
    Protected WithEvents FirstPFAFI As System.Web.UI.WebControls.TextBox
    Protected WithEvents FirstPFKPTCL As System.Web.UI.WebControls.TextBox
    Protected WithEvents FirstPFAFIII As System.Web.UI.WebControls.TextBox
    Protected WithEvents SSKPTCL As System.Web.UI.WebControls.Label
    Protected WithEvents SSAFI As System.Web.UI.WebControls.Label
    Protected WithEvents SSAFII As System.Web.UI.WebControls.Label
    Protected WithEvents SSAFIII As System.Web.UI.WebControls.Label
    Protected WithEvents SSPUMPHOUSE As System.Web.UI.WebControls.Label
    Protected WithEvents SSWHEELSHOPESSENTIAL As System.Web.UI.WebControls.Label
    'Protected WithEvents SSWHEELSHOPNONESSENTIAL As System.Web.UI.WebControls.Label
    Protected WithEvents SSTUBEPREHEAT As System.Web.UI.WebControls.Label
    Protected WithEvents SSMOULDPREHEAT As System.Web.UI.WebControls.Label
    Protected WithEvents SSFUMEEXTRACTION As System.Web.UI.WebControls.Label
    Protected WithEvents SSCOMPRESSOR As System.Web.UI.WebControls.Label
    Protected WithEvents SSASSEMBLY As System.Web.UI.WebControls.Label
    ' Protected WithEvents SSAXLESHOPESSENTIAL As System.Web.UI.WebControls.Label
    ' Protected WithEvents SSAXLESHOPNONESSENTIAL As System.Web.UI.WebControls.Label
    Protected WithEvents SSGFM As System.Web.UI.WebControls.Label
    Protected WithEvents SSCANTEEN As System.Web.UI.WebControls.Label
    Protected WithEvents SSCOLONY As System.Web.UI.WebControls.Label
    Protected WithEvents SSADMIN As System.Web.UI.WebControls.Label
    Protected WithEvents SSEMMS As System.Web.UI.WebControls.Label
    Protected WithEvents SSLOP As System.Web.UI.WebControls.Label
    Protected WithEvents FirstPFLOP As System.Web.UI.WebControls.TextBox
    Protected WithEvents FirstPFEMMS As System.Web.UI.WebControls.TextBox
    ' Protected WithEvents FirstPFAXLESHOPNONESSENTIAL As System.Web.UI.WebControls.TextBox
    Protected WithEvents FirstPFGFM As System.Web.UI.WebControls.TextBox
    Protected WithEvents FirstPFCANTEEN As System.Web.UI.WebControls.TextBox
    Protected WithEvents FirstPFCOLONY As System.Web.UI.WebControls.TextBox
    Protected WithEvents FirstPFCOLONY1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents FirstPFPCS As System.Web.UI.WebControls.TextBox
    Protected WithEvents FirstPFADMIN As System.Web.UI.WebControls.TextBox
    Protected WithEvents FirstPFAXLESHOPESSENTIAL As System.Web.UI.WebControls.TextBox
    Protected WithEvents FirstPFWHEELSHOPNONESSENTIAL As System.Web.UI.WebControls.TextBox
    Protected WithEvents FirstPFTUBEPREHEAT As System.Web.UI.WebControls.TextBox
    Protected WithEvents FirstPFMOULDPREHEAT As System.Web.UI.WebControls.TextBox
    Protected WithEvents FirstPFFUMEEXTRACTION As System.Web.UI.WebControls.TextBox
    Protected WithEvents FirstPFCOMPRESSOR As System.Web.UI.WebControls.TextBox
    Protected WithEvents FirstPFASSEMBLY As System.Web.UI.WebControls.TextBox
    Protected WithEvents FirstPFWHEELSHOPESSENTIAL As System.Web.UI.WebControls.TextBox
    Protected WithEvents FirstPFPUMPHOUSE As System.Web.UI.WebControls.TextBox
    Protected WithEvents RemarksCANTEEN As System.Web.UI.WebControls.TextBox
    Protected WithEvents RemarksCOLONY As System.Web.UI.WebControls.TextBox
    Protected WithEvents RemarksCOLONY1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents RemarksPCS As System.Web.UI.WebControls.TextBox
    Protected WithEvents RemarksADMIN As System.Web.UI.WebControls.TextBox
    Protected WithEvents RemarksEMMS As System.Web.UI.WebControls.TextBox
    Protected WithEvents RemarksLOP As System.Web.UI.WebControls.TextBox
    Protected WithEvents RemarksGFM As System.Web.UI.WebControls.TextBox
    Protected WithEvents RemarksPUMPHOUSE As System.Web.UI.WebControls.TextBox
    Protected WithEvents RemarksWHEELSHOPESSENTIAL As System.Web.UI.WebControls.TextBox
    Protected WithEvents RemarksWHEELSHOPNONESSENTIAL As System.Web.UI.WebControls.TextBox
    Protected WithEvents RemarksTUBEPREHEAT As System.Web.UI.WebControls.TextBox
    Protected WithEvents RemarksMOULDPREHEAT As System.Web.UI.WebControls.TextBox
    Protected WithEvents RemarksFUMEEXTRACTION As System.Web.UI.WebControls.TextBox
    Protected WithEvents RemarksCOMPRESSOR As System.Web.UI.WebControls.TextBox
    Protected WithEvents RemarksASSEMBLY As System.Web.UI.WebControls.TextBox
    '   Protected WithEvents RemarksAXLESHOPESSENTIAL As System.Web.UI.WebControls.TextBox
    '  Protected WithEvents RemarksAXLESHOPNONESSENTIAL As System.Web.UI.WebControls.TextBox
    Protected WithEvents RemarksKPTCL As System.Web.UI.WebControls.TextBox
    Protected WithEvents RemarksAFI As System.Web.UI.WebControls.TextBox
    Protected WithEvents RemarksAFII As System.Web.UI.WebControls.TextBox
    Protected WithEvents RemarksAFIII As System.Web.UI.WebControls.TextBox
    Protected WithEvents SecondLoadADMIN As System.Web.UI.WebControls.TextBox
    Protected WithEvents SecondLoadEMMS As System.Web.UI.WebControls.TextBox
    Protected WithEvents SecondLoadLOP As System.Web.UI.WebControls.TextBox
    Protected WithEvents SecondLoadCANTEEN As System.Web.UI.WebControls.TextBox
    Protected WithEvents SecondLoadCOLONY As System.Web.UI.WebControls.TextBox
    Protected WithEvents SecondLoadCOLONY1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents SecondLoadPCS As System.Web.UI.WebControls.TextBox
    Protected WithEvents SecondLoadGFM As System.Web.UI.WebControls.TextBox
    ' Protected WithEvents SecondLoadAXLESHOPNONESSENTIAL As System.Web.UI.WebControls.TextBox
    Protected WithEvents SecondLoadMOULDPREHEAT As System.Web.UI.WebControls.TextBox
    Protected WithEvents SecondLoadFUMEEXTRACTION As System.Web.UI.WebControls.TextBox
    Protected WithEvents SecondLoadCOMPRESSOR As System.Web.UI.WebControls.TextBox
    Protected WithEvents SecondLoadASSEMBLY As System.Web.UI.WebControls.TextBox
    'Protected WithEvents SecondLoadAXLESHOPESSENTIAL As System.Web.UI.WebControls.TextBox
    Protected WithEvents SecondLoadKPTCL As System.Web.UI.WebControls.TextBox
    Protected WithEvents SecondLoadAFI As System.Web.UI.WebControls.TextBox
    Protected WithEvents SecondLoadAFII As System.Web.UI.WebControls.TextBox
    Protected WithEvents SecondLoadAFIII As System.Web.UI.WebControls.TextBox
    Protected WithEvents SecondLoadPUMPHOUSE As System.Web.UI.WebControls.TextBox
    Protected WithEvents SecondLoadWHEELSHOPESSENTIAL As System.Web.UI.WebControls.TextBox
    Protected WithEvents SecondLoadWHEELSHOPNONESSENTIAL As System.Web.UI.WebControls.TextBox
    Protected WithEvents SecondLoadTUBEPREHEAT As System.Web.UI.WebControls.TextBox
    Protected WithEvents SecondPFKPTCL As System.Web.UI.WebControls.TextBox
    Protected WithEvents SecondPFAFI As System.Web.UI.WebControls.TextBox
    Protected WithEvents SecondPFAFII As System.Web.UI.WebControls.TextBox
    Protected WithEvents SecondPFAFIII As System.Web.UI.WebControls.TextBox
    Protected WithEvents SecondPFPUMPHOUSE As System.Web.UI.WebControls.TextBox
    Protected WithEvents SecondPFWHEELSHOPESSENTIAL As System.Web.UI.WebControls.TextBox
    Protected WithEvents SecondPFWHEELSHOPNONESSENTIAL As System.Web.UI.WebControls.TextBox
    Protected WithEvents SecondPFTUBEPREHEAT As System.Web.UI.WebControls.TextBox
    Protected WithEvents SecondPFMOULDPREHEAT As System.Web.UI.WebControls.TextBox
    Protected WithEvents SecondPFFUMEEXTRACTION As System.Web.UI.WebControls.TextBox
    Protected WithEvents SecondPFCOMPRESSOR As System.Web.UI.WebControls.TextBox
    Protected WithEvents SecondPFASSEMBLY As System.Web.UI.WebControls.TextBox
    '   Protected WithEvents SecondPFAXLESHOPESSENTIAL As System.Web.UI.WebControls.TextBox
    '  Protected WithEvents SecondPFAXLESHOPNONESSENTIAL As System.Web.UI.WebControls.TextBox
    Protected WithEvents SecondPFGFM As System.Web.UI.WebControls.TextBox
    Protected WithEvents SecondPFCANTEEN As System.Web.UI.WebControls.TextBox
    Protected WithEvents SecondPFCOLONY As System.Web.UI.WebControls.TextBox
    Protected WithEvents SecondPFCOLONY1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents SecondPFPCS As System.Web.UI.WebControls.TextBox
    Protected WithEvents SecondPFADMIN As System.Web.UI.WebControls.TextBox
    Protected WithEvents SecondPFEMMS As System.Web.UI.WebControls.TextBox
    Protected WithEvents SecondPFLOP As System.Web.UI.WebControls.TextBox
    Protected WithEvents FirstLoadKPTCL As System.Web.UI.WebControls.TextBox
    Protected WithEvents FirstLoadAFI As System.Web.UI.WebControls.TextBox
    Protected WithEvents FirstLoadAFII As System.Web.UI.WebControls.TextBox
    Protected WithEvents FirstLoadWHEELSHOPNONESSENTIAL As System.Web.UI.WebControls.TextBox
    Protected WithEvents FirstLoadTUBEPREHEAT As System.Web.UI.WebControls.TextBox
    Protected WithEvents FirstLoadMOULDPREHEAT As System.Web.UI.WebControls.TextBox
    Protected WithEvents FirstLoadFUMEEXTRACTION As System.Web.UI.WebControls.TextBox
    Protected WithEvents FirstLoadCOMPRESSOR As System.Web.UI.WebControls.TextBox
    Protected WithEvents FirstLoadASSEMBLY As System.Web.UI.WebControls.TextBox
    '   Protected WithEvents FirstLoadAXLESHOPESSENTIAL As System.Web.UI.WebControls.TextBox
    '  Protected WithEvents FirstLoadAXLESHOPNONESSENTIAL As System.Web.UI.WebControls.TextBox
    Protected WithEvents FirstLoadAFIII As System.Web.UI.WebControls.TextBox
    Protected WithEvents FirstLoadPUMPHOUSE As System.Web.UI.WebControls.TextBox
    Protected WithEvents FirstLoadWHEELSHOPESSENTIAL As System.Web.UI.WebControls.TextBox
    Protected WithEvents FirstLoadGFM As System.Web.UI.WebControls.TextBox
    Protected WithEvents FirstLoadCANTEEN As System.Web.UI.WebControls.TextBox
    Protected WithEvents FirstLoadCOLONY As System.Web.UI.WebControls.TextBox
    Protected WithEvents FirstLoadCOLONY1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents FirstLoadPCS As System.Web.UI.WebControls.TextBox
    Protected WithEvents FirstLoadADMIN As System.Web.UI.WebControls.TextBox
    Protected WithEvents FirstLoadEMMS As System.Web.UI.WebControls.TextBox
    Protected WithEvents FirstLoadLOP As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
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
        If Page.IsPostBack = False Then
            txtDate.Text = Now.Date
            Try
                GetPFDetails(CDate(txtDate.Text.Trim))
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
    Private Sub Clear()
        FirstPFAFII.Text = ""
        FirstPFAFI.Text = ""
        FirstPFKPTCL.Text = ""
        FirstPFAFIII.Text = ""
        'FirstPFLOP.Text = ""
        'FirstPFEMMS.Text = ""
        'FirstPFAXLESHOPNONESSENTIAL.Text = ""
        'FirstPFGFM.Text = ""
        'FirstPFCANTEEN.Text = ""
        FirstPFCOLONY.Text = ""
        FirstPFCOLONY1.Text = ""
        FirstPFPCS.Text = ""
        FirstPFADMIN.Text = ""
        ' FirstPFAXLESHOPESSENTIAL.Text = ""
        'FirstPFWHEELSHOPNONESSENTIAL.Text = ""
        FirstPFTUBEPREHEAT.Text = ""
        FirstPFMOULDPREHEAT.Text = ""
        FirstPFFUMEEXTRACTION.Text = ""
        FirstPFCOMPRESSOR.Text = ""
        '  FirstPFASSEMBLY.Text = ""
        FirstPFWHEELSHOPESSENTIAL.Text = ""
        FirstPFPUMPHOUSE.Text = ""
        'RemarksCANTEEN.Text = ""
        RemarksCOLONY.Text = ""
        RemarksCOLONY1.Text = ""
        RemarksPCS.Text = ""
        RemarksADMIN.Text = ""
        'RemarksEMMS.Text = ""
        'RemarksLOP.Text = ""
        'RemarksGFM.Text = ""
        RemarksPUMPHOUSE.Text = ""
        RemarksWHEELSHOPESSENTIAL.Text = ""
        'RemarksWHEELSHOPNONESSENTIAL.Text = ""
        RemarksTUBEPREHEAT.Text = ""
        RemarksMOULDPREHEAT.Text = ""
        RemarksFUMEEXTRACTION.Text = ""
        RemarksCOMPRESSOR.Text = ""
        'RemarksASSEMBLY.Text = ""
        'RemarksAXLESHOPESSENTIAL.Text = ""
        'RemarksAXLESHOPNONESSENTIAL.Text = ""
        RemarksKPTCL.Text = ""
        RemarksAFI.Text = ""
        RemarksAFII.Text = ""
        RemarksAFIII.Text = ""
        SecondLoadADMIN.Text = ""
        'SecondLoadEMMS.Text = ""
        'SecondLoadLOP.Text = ""
        'SecondLoadCANTEEN.Text = ""
        SecondLoadCOLONY.Text = ""
        SecondLoadCOLONY1.Text = ""
        SecondLoadPCS.Text = ""
        'SecondLoadGFM.Text = ""
        'SecondLoadAXLESHOPNONESSENTIAL.Text = ""
        SecondLoadMOULDPREHEAT.Text = ""
        SecondLoadFUMEEXTRACTION.Text = ""
        SecondLoadCOMPRESSOR.Text = ""
        'SecondLoadASSEMBLY.Text = ""
        'SecondLoadAXLESHOPESSENTIAL.Text = ""
        SecondLoadKPTCL.Text = ""
        SecondLoadAFI.Text = ""
        SecondLoadAFII.Text = ""
        SecondLoadAFIII.Text = ""
        SecondLoadPUMPHOUSE.Text = ""
        SecondLoadWHEELSHOPESSENTIAL.Text = ""
        'SecondLoadWHEELSHOPNONESSENTIAL.Text = ""
        SecondLoadTUBEPREHEAT.Text = ""
        SecondPFKPTCL.Text = ""
        SecondPFAFI.Text = ""
        SecondPFAFII.Text = ""
        SecondPFAFIII.Text = ""
        SecondPFPUMPHOUSE.Text = ""
        SecondPFWHEELSHOPESSENTIAL.Text = ""
        'SecondPFWHEELSHOPNONESSENTIAL.Text = ""
        SecondPFTUBEPREHEAT.Text = ""
        SecondPFMOULDPREHEAT.Text = ""
        SecondPFFUMEEXTRACTION.Text = ""
        SecondPFCOMPRESSOR.Text = ""
        ' SecondPFASSEMBLY.Text = ""
        'SecondPFAXLESHOPESSENTIAL.Text = ""
        'SecondPFAXLESHOPNONESSENTIAL.Text = ""
        'SecondPFGFM.Text = ""
        'SecondPFCANTEEN.Text = ""
        SecondPFCOLONY.Text = ""
        SecondPFCOLONY1.Text = ""
        SecondPFPCS.Text = ""
        SecondPFADMIN.Text = ""
        ' SecondPFEMMS.Text = ""
        ' SecondPFLOP.Text = ""
        FirstLoadKPTCL.Text = ""
        FirstLoadAFI.Text = ""
        FirstLoadAFII.Text = ""
        'FirstLoadWHEELSHOPNONESSENTIAL.Text = ""
        FirstLoadTUBEPREHEAT.Text = ""
        FirstLoadMOULDPREHEAT.Text = ""
        FirstLoadFUMEEXTRACTION.Text = ""
        FirstLoadCOMPRESSOR.Text = ""
        'FirstLoadASSEMBLY.Text = ""
        'FirstLoadAXLESHOPESSENTIAL.Text = ""
        'FirstLoadAXLESHOPNONESSENTIAL.Text = ""
        FirstLoadAFIII.Text = ""
        FirstLoadPUMPHOUSE.Text = ""
        FirstLoadWHEELSHOPESSENTIAL.Text = ""
        'FirstLoadGFM.Text = ""
        'FirstLoadCANTEEN.Text = ""
        FirstLoadCOLONY.Text = ""
        FirstLoadCOLONY1.Text = ""
        FirstLoadPCS.Text = ""
        FirstLoadADMIN.Text = ""
        ' FirstLoadEMMS.Text = ""
        'FirstLoadLOP.Text = ""
    End Sub
    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        lblMessage.Text = ""
        Dim t As Date
        Try
            t = CDate(txtDate.Text.Trim)
            If t > Now.Date Then
                lblMessage.Text = " Date cannot be greater than Today !"
                txtDate.Text = ""
            Else
                GetPFDetails(CDate(txtDate.Text.Trim))
            End If
        Catch exp As Exception
            lblMessage.Text = " Date not in correct format ; " & exp.Message
            txtDate.Text = ""
        End Try
    End Sub

    Private Sub GetPFDetails(ByVal FromDate As Date)
        Dim dt As New DataTable()
        Clear()
        Try
            dt = Maintenance.ElecTables.GetPFDetails(CDate(txtDate.Text))
            If dt.Rows.Count > 0 Then
                If dt.Rows(0)("SlNo") = Label1.Text Then
                    FirstPFKPTCL.Text = dt.Rows(0)("FirstPF")
                    FirstLoadKPTCL.Text = dt.Rows(0)("FirstLoad")
                    SecondPFKPTCL.Text = dt.Rows(0)("SecondPF")
                    SecondLoadKPTCL.Text = dt.Rows(0)("SecondLoad")
                    RemarksKPTCL.Text = dt.Rows(0)("Remarks")
                End If
                If dt.Rows(1)("SlNo") = Label2.Text Then
                    FirstPFAFI.Text = dt.Rows(1)("FirstPF")
                    FirstLoadAFI.Text = dt.Rows(1)("FirstLoad")
                    SecondPFAFI.Text = dt.Rows(1)("SecondPF")
                    SecondLoadAFI.Text = dt.Rows(1)("SecondLoad")
                    RemarksAFI.Text = dt.Rows(1)("Remarks")
                End If
                If dt.Rows(2)("SlNo") = Label3.Text Then
                    FirstPFAFII.Text = dt.Rows(2)("FirstPF")
                    FirstLoadAFII.Text = dt.Rows(2)("FirstLoad")
                    SecondPFAFII.Text = dt.Rows(2)("SecondPF")
                    SecondLoadAFII.Text = dt.Rows(2)("SecondLoad")
                    RemarksAFII.Text = dt.Rows(2)("Remarks")
                End If
                If dt.Rows(3)("SlNo") = Label4.Text Then
                    FirstPFAFIII.Text = dt.Rows(3)("FirstPF")
                    FirstLoadAFIII.Text = dt.Rows(3)("FirstLoad")
                    SecondPFAFIII.Text = dt.Rows(3)("SecondPF")
                    SecondLoadAFIII.Text = dt.Rows(3)("SecondLoad")
                    RemarksAFIII.Text = dt.Rows(3)("Remarks")
                End If
                If dt.Rows(4)("SlNo") = Label5.Text Then
                    FirstPFPUMPHOUSE.Text = dt.Rows(4)("FirstPF")
                    FirstLoadPUMPHOUSE.Text = dt.Rows(4)("FirstLoad")
                    SecondPFPUMPHOUSE.Text = dt.Rows(4)("SecondPF")
                    SecondLoadPUMPHOUSE.Text = dt.Rows(4)("SecondLoad")
                    RemarksPUMPHOUSE.Text = dt.Rows(4)("Remarks")
                End If
                If dt.Rows(5)("SlNo") = Label6.Text Then
                    FirstPFWHEELSHOPESSENTIAL.Text = dt.Rows(5)("FirstPF")
                    FirstLoadWHEELSHOPESSENTIAL.Text = dt.Rows(5)("FirstLoad")
                    SecondPFWHEELSHOPESSENTIAL.Text = dt.Rows(5)("SecondPF")
                    SecondLoadWHEELSHOPESSENTIAL.Text = dt.Rows(5)("SecondLoad")
                    RemarksWHEELSHOPESSENTIAL.Text = dt.Rows(5)("Remarks")
                End If
                'If dt.Rows(6)("SlNo") = Label7.Text Then
                '    FirstPFWHEELSHOPNONESSENTIAL.Text = dt.Rows(6)("FirstPF")
                '    FirstLoadWHEELSHOPNONESSENTIAL.Text = dt.Rows(6)("FirstLoad")
                '    SecondPFWHEELSHOPNONESSENTIAL.Text = dt.Rows(6)("SecondPF")
                '    SecondLoadWHEELSHOPNONESSENTIAL.Text = dt.Rows(6)("SecondLoad")
                '    RemarksWHEELSHOPNONESSENTIAL.Text = dt.Rows(6)("Remarks")
                'End If
                If dt.Rows(6)("SlNo") = Label8.Text Then
                    FirstPFTUBEPREHEAT.Text = dt.Rows(6)("FirstPF")
                    FirstLoadTUBEPREHEAT.Text = dt.Rows(6)("FirstLoad")
                    SecondPFTUBEPREHEAT.Text = dt.Rows(6)("SecondPF")
                    SecondLoadTUBEPREHEAT.Text = dt.Rows(6)("SecondLoad")
                    RemarksTUBEPREHEAT.Text = dt.Rows(6)("Remarks")
                End If
                If dt.Rows(7)("SlNo") = Label9.Text Then
                    FirstPFMOULDPREHEAT.Text = dt.Rows(7)("FirstPF")
                    FirstLoadMOULDPREHEAT.Text = dt.Rows(7)("FirstLoad")
                    SecondPFMOULDPREHEAT.Text = dt.Rows(7)("SecondPF")
                    SecondLoadMOULDPREHEAT.Text = dt.Rows(7)("SecondLoad")
                    RemarksMOULDPREHEAT.Text = dt.Rows(7)("Remarks")
                End If
                If dt.Rows(8)("SlNo") = Label10.Text Then
                    FirstPFFUMEEXTRACTION.Text = dt.Rows(8)("FirstPF")
                    FirstLoadFUMEEXTRACTION.Text = dt.Rows(8)("FirstLoad")
                    SecondPFFUMEEXTRACTION.Text = dt.Rows(8)("SecondPF")
                    SecondLoadFUMEEXTRACTION.Text = dt.Rows(8)("SecondLoad")
                    RemarksFUMEEXTRACTION.Text = dt.Rows(8)("Remarks")
                End If
                If dt.Rows(9)("SlNo") = Label11.Text Then
                    FirstPFCOMPRESSOR.Text = dt.Rows(9)("FirstPF")
                    FirstLoadCOMPRESSOR.Text = dt.Rows(9)("FirstLoad")
                    SecondPFCOMPRESSOR.Text = dt.Rows(9)("SecondPF")
                    SecondLoadCOMPRESSOR.Text = dt.Rows(9)("SecondLoad")
                    RemarksCOMPRESSOR.Text = dt.Rows(9)("Remarks")
                End If
                'If dt.Rows(11)("SlNo") = Label12.Text Then
                '    FirstPFASSEMBLY.Text = dt.Rows(11)("FirstPF")
                '    FirstLoadASSEMBLY.Text = dt.Rows(11)("FirstLoad")
                '    SecondPFASSEMBLY.Text = dt.Rows(11)("SecondPF")
                '    SecondLoadASSEMBLY.Text = dt.Rows(11)("SecondLoad")
                '    RemarksASSEMBLY.Text = dt.Rows(11)("Remarks")
                'End If

                'If dt.Rows(12)("SlNo") = Label13.Text Then
                '    FirstPFAXLESHOPESSENTIAL.Text = dt.Rows(12)("FirstPF")
                '    FirstLoadAXLESHOPESSENTIAL.Text = dt.Rows(12)("FirstLoad")
                '    SecondPFAXLESHOPESSENTIAL.Text = dt.Rows(12)("SecondPF")
                '    SecondLoadAXLESHOPESSENTIAL.Text = dt.Rows(12)("SecondLoad")
                '    RemarksAXLESHOPESSENTIAL.Text = dt.Rows(12)("Remarks")
                'End If

                'If dt.Rows(13)("SlNo") = Label14.Text Then
                '    FirstPFAXLESHOPNONESSENTIAL.Text = dt.Rows(13)("FirstPF")
                '    FirstLoadAXLESHOPNONESSENTIAL.Text = dt.Rows(13)("FirstLoad")
                '    SecondPFAXLESHOPNONESSENTIAL.Text = dt.Rows(13)("SecondPF")
                '    SecondLoadAXLESHOPNONESSENTIAL.Text = dt.Rows(13)("SecondLoad")
                '    RemarksAXLESHOPNONESSENTIAL.Text = dt.Rows(13)("Remarks")
                'End If
                'If dt.Rows(14)("SlNo") = Label15.Text Then
                '    FirstPFGFM.Text = dt.Rows(14)("FirstPF")
                '    FirstLoadGFM.Text = dt.Rows(14)("FirstLoad")
                '    SecondPFGFM.Text = dt.Rows(14)("SecondPF")
                '    SecondLoadGFM.Text = dt.Rows(14)("SecondLoad")
                '    RemarksGFM.Text = dt.Rows(14)("Remarks")
                'End If

                'If dt.Rows(15)("SlNo") = Label16.Text Then
                '    FirstPFCANTEEN.Text = dt.Rows(15)("FirstPF")
                '    FirstLoadCANTEEN.Text = dt.Rows(15)("FirstLoad")
                '    SecondPFCANTEEN.Text = dt.Rows(15)("SecondPF")
                '    SecondLoadCANTEEN.Text = dt.Rows(15)("SecondLoad")
                '    RemarksCANTEEN.Text = dt.Rows(15)("Remarks")
                'End If
                If dt.Rows(10)("SlNo") = Label17.Text Then
                    FirstPFCOLONY.Text = dt.Rows(10)("FirstPF")
                    FirstLoadCOLONY.Text = dt.Rows(10)("FirstLoad")
                    SecondPFCOLONY.Text = dt.Rows(10)("SecondPF")
                    SecondLoadCOLONY.Text = dt.Rows(10)("SecondLoad")
                    RemarksCOLONY.Text = dt.Rows(10)("Remarks")
                End If
                If dt.Rows(11)("SlNo") = Label21.Text Then
                    FirstPFCOLONY1.Text = dt.Rows(11)("FirstPF")
                    FirstLoadCOLONY1.Text = dt.Rows(11)("FirstLoad")
                    SecondPFCOLONY1.Text = dt.Rows(11)("SecondPF")
                    SecondLoadCOLONY1.Text = dt.Rows(11)("SecondLoad")
                    RemarksCOLONY1.Text = dt.Rows(11)("Remarks")
                End If

                If dt.Rows(12)("SlNo") = Label18.Text Then
                    FirstPFADMIN.Text = dt.Rows(12)("FirstPF")
                    FirstLoadADMIN.Text = dt.Rows(12)("FirstLoad")
                    SecondPFADMIN.Text = dt.Rows(12)("SecondPF")
                    SecondLoadADMIN.Text = dt.Rows(12)("SecondLoad")
                    RemarksADMIN.Text = dt.Rows(12)("Remarks")
                End If
                'If dt.Rows(18)("SlNo") = Label19.Text Then
                '    FirstPFEMMS.Text = dt.Rows(18)("FirstPF")
                '    FirstLoadEMMS.Text = dt.Rows(18)("FirstLoad")
                '    SecondPFEMMS.Text = dt.Rows(18)("SecondPF")
                '    SecondLoadEMMS.Text = dt.Rows(18)("SecondLoad")
                '    RemarksEMMS.Text = dt.Rows(18)("Remarks")
                'End If
                'If dt.Rows(19)("SlNo") = Label20.Text Then
                '    FirstPFLOP.Text = dt.Rows(19)("FirstPF")
                '    FirstLoadLOP.Text = dt.Rows(19)("FirstLoad")
                '    SecondPFLOP.Text = dt.Rows(19)("SecondPF")
                '    SecondLoadLOP.Text = dt.Rows(19)("SecondLoad")
                '    RemarksLOP.Text = dt.Rows(19)("Remarks")
                'End If
                If dt.Rows(13)("SlNo") = Label23.Text Then
                    FirstPFPCS.Text = dt.Rows(13)("FirstPF")
                    FirstLoadPCS.Text = dt.Rows(13)("FirstLoad")
                    SecondPFPCS.Text = dt.Rows(13)("SecondPF")
                    SecondLoadPCS.Text = dt.Rows(13)("SecondLoad")
                    RemarksPCS.Text = dt.Rows(13)("Remarks")
                End If

            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub FillValus(ByRef dt As DataTable, ByVal ReadingDate As Date, ByVal SlNo As Integer, ByVal FirstPF As Decimal, ByVal FirstLoad As Integer, ByVal SecondPF As Decimal, ByVal SecondLoad As Integer, ByVal Remarks As String)
        Dim dr As DataRow
        dr = dt.NewRow
        dr("ReadingDate") = ReadingDate
        dr("SlNo") = SlNo
        dr("FirstPF") = FirstPF
        dr("FirstLoad") = FirstLoad
        dr("SecondPF") = SecondPF
        dr("SecondLoad") = SecondLoad
        dr("Remarks") = Remarks
        dt.Rows.Add(dr)
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim dt As New DataTable()
        Dim dr As DataRow
        Dim Done As Boolean
        Try
            dt.TableName = "readings"
            dt.Columns.Add("ReadingDate")
            dt.Columns.Add("SlNo")
            dt.Columns.Add("FirstPF")
            dt.Columns.Add("FirstLoad")
            dt.Columns.Add("SecondPF")
            dt.Columns.Add("SecondLoad")
            dt.Columns.Add("Remarks")

            FillValus(dt, CDate(txtDate.Text), Label1.Text, Val(FirstPFKPTCL.Text), Val(FirstLoadKPTCL.Text), Val(SecondPFKPTCL.Text), Val(SecondLoadKPTCL.Text), RemarksKPTCL.Text)
            FillValus(dt, CDate(txtDate.Text), Label2.Text, Val(FirstPFAFI.Text), Val(FirstLoadAFI.Text), Val(SecondPFAFI.Text), Val(SecondLoadAFI.Text), RemarksAFI.Text)
            FillValus(dt, CDate(txtDate.Text), Label3.Text, Val(FirstPFAFII.Text), Val(FirstLoadAFII.Text), Val(SecondPFAFII.Text), Val(SecondLoadAFII.Text), RemarksAFII.Text)
            FillValus(dt, CDate(txtDate.Text), Label4.Text, Val(FirstPFAFIII.Text), Val(FirstLoadAFIII.Text), Val(SecondPFAFIII.Text), Val(SecondLoadAFIII.Text), RemarksAFIII.Text)
            FillValus(dt, CDate(txtDate.Text), Label5.Text, Val(FirstPFPUMPHOUSE.Text), Val(FirstLoadPUMPHOUSE.Text), Val(SecondPFPUMPHOUSE.Text), Val(SecondLoadPUMPHOUSE.Text), RemarksPUMPHOUSE.Text)
            FillValus(dt, CDate(txtDate.Text), Label6.Text, Val(FirstPFWHEELSHOPESSENTIAL.Text), Val(FirstLoadWHEELSHOPESSENTIAL.Text), Val(SecondPFWHEELSHOPESSENTIAL.Text), Val(SecondLoadWHEELSHOPESSENTIAL.Text), RemarksWHEELSHOPESSENTIAL.Text)
            'FillValus(dt, CDate(txtDate.Text), Label7.Text, Val(FirstPFWHEELSHOPNONESSENTIAL.Text), Val(FirstLoadWHEELSHOPNONESSENTIAL.Text), Val(SecondPFWHEELSHOPNONESSENTIAL.Text), Val(SecondLoadWHEELSHOPNONESSENTIAL.Text), RemarksWHEELSHOPNONESSENTIAL.Text)
            FillValus(dt, CDate(txtDate.Text), Label8.Text, Val(FirstPFTUBEPREHEAT.Text), Val(FirstLoadTUBEPREHEAT.Text), Val(SecondPFTUBEPREHEAT.Text), Val(SecondLoadTUBEPREHEAT.Text), RemarksTUBEPREHEAT.Text)
            FillValus(dt, CDate(txtDate.Text), Label9.Text, Val(FirstPFMOULDPREHEAT.Text), Val(FirstLoadMOULDPREHEAT.Text), Val(SecondPFMOULDPREHEAT.Text), Val(SecondLoadMOULDPREHEAT.Text), RemarksMOULDPREHEAT.Text)
            FillValus(dt, CDate(txtDate.Text), Label10.Text, Val(FirstPFFUMEEXTRACTION.Text), Val(FirstLoadFUMEEXTRACTION.Text), Val(SecondPFFUMEEXTRACTION.Text), Val(SecondLoadFUMEEXTRACTION.Text), RemarksFUMEEXTRACTION.Text)
            FillValus(dt, CDate(txtDate.Text), Label11.Text, Val(FirstPFCOMPRESSOR.Text), Val(FirstLoadCOMPRESSOR.Text), Val(SecondPFCOMPRESSOR.Text), Val(SecondLoadCOMPRESSOR.Text), RemarksCOMPRESSOR.Text)
            'FillValus(dt, CDate(txtDate.Text), Label12.Text, Val(FirstPFASSEMBLY.Text), Val(FirstLoadASSEMBLY.Text), Val(SecondPFASSEMBLY.Text), Val(SecondLoadASSEMBLY.Text), RemarksASSEMBLY.Text)
            'FillValus(dt, CDate(txtDate.Text), Label13.Text, Val(FirstPFAXLESHOPESSENTIAL.Text), Val(FirstLoadAXLESHOPESSENTIAL.Text), Val(SecondPFAXLESHOPESSENTIAL.Text), Val(SecondLoadAXLESHOPESSENTIAL.Text), RemarksAXLESHOPESSENTIAL.Text)
            'FillValus(dt, CDate(txtDate.Text), Label14.Text, Val(FirstPFAXLESHOPNONESSENTIAL.Text), Val(FirstLoadAXLESHOPNONESSENTIAL.Text), Val(SecondPFAXLESHOPNONESSENTIAL.Text), Val(SecondLoadAXLESHOPNONESSENTIAL.Text), RemarksAXLESHOPNONESSENTIAL.Text)
            'FillValus(dt, CDate(txtDate.Text), Label15.Text, Val(FirstPFGFM.Text), Val(FirstLoadGFM.Text), Val(SecondPFGFM.Text), Val(SecondLoadGFM.Text), RemarksGFM.Text)
            'FillValus(dt, CDate(txtDate.Text), Label16.Text, Val(FirstPFCANTEEN.Text), Val(FirstLoadCANTEEN.Text), Val(SecondPFCANTEEN.Text), Val(SecondLoadCANTEEN.Text), RemarksCANTEEN.Text)
            FillValus(dt, CDate(txtDate.Text), Label17.Text, Val(FirstPFCOLONY.Text), Val(FirstLoadCOLONY.Text), Val(SecondPFCOLONY.Text), Val(SecondLoadCOLONY.Text), RemarksCOLONY.Text)
            FillValus(dt, CDate(txtDate.Text), Label21.Text, Val(FirstPFCOLONY1.Text), Val(FirstLoadCOLONY1.Text), Val(SecondPFCOLONY1.Text), Val(SecondLoadCOLONY1.Text), RemarksCOLONY1.Text)
            FillValus(dt, CDate(txtDate.Text), Label18.Text, Val(FirstPFADMIN.Text), Val(FirstLoadADMIN.Text), Val(SecondPFADMIN.Text), Val(SecondLoadADMIN.Text), RemarksADMIN.Text)
            ' FillValus(dt, CDate(txtDate.Text), Label19.Text, Val(FirstPFEMMS.Text), Val(FirstLoadEMMS.Text), Val(SecondPFEMMS.Text), Val(SecondLoadEMMS.Text), RemarksEMMS.Text)
            'FillValus(dt, CDate(txtDate.Text), Label20.Text, Val(FirstPFLOP.Text), Val(FirstLoadLOP.Text), Val(SecondPFLOP.Text), Val(SecondLoadLOP.Text), RemarksLOP.Text)
            FillValus(dt, CDate(txtDate.Text), Label23.Text, Val(FirstPFPCS.Text), Val(FirstLoadPCS.Text), Val(SecondPFPCS.Text), Val(SecondLoadPCS.Text), RemarksPCS.Text)
            DataGrid1.DataSource = dt
            DataGrid1.DataBind()
            Dim oPF As New Maintenance.Electrical()
            oPF.PFDetails = dt
            If oPF.SavePFDetails() Then
                lblMessage.Text = "Data Saved !"
                Clear()
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
            dr = Nothing
        End Try
    End Sub
    Private Sub ff()
        'dr = dt.NewRow
        'dr("ReadingDate") = CDate(txtDate.Text)
        'dr("SlNo") = Label1.Text
        'dr("FirstPF") = Val(FirstPFKPTCL.Text)
        'dr("FirstLoad") = Val(FirstLoadKPTCL.Text)
        'dr("SecondPF") = Val(SecondPFKPTCL.Text)
        'dr("SecondLoad") = Val(SecondLoadKPTCL.Text)
        'dr("Remarks") = RemarksKPTCL.Text
        'dt.Rows.Add(dr)

        'dr = dt.NewRow
        'dr("ReadingDate") = CDate(txtDate.Text)
        'dr("SlNo") = Label2.Text
        'dr("FirstPF") = Val(FirstPFAFI.Text)
        'dr("FirstLoad") = Val(FirstLoadAFI.Text)
        'dr("SecondPF") = Val(SecondPFAFI.Text)
        'dr("SecondLoad") = Val(SecondLoadAFI.Text)
        'dr("Remarks") = RemarksAFI.Text
        'dt.Rows.Add(dr)

        'dr = dt.NewRow
        'dr("ReadingDate") = CDate(txtDate.Text)
        'dr("SlNo") = Label3.Text
        'dr("FirstPF") = Val(FirstPFAFII.Text)
        'dr("FirstLoad") = Val(FirstLoadAFII.Text)
        'dr("SecondPF") = Val(SecondPFAFII.Text)
        'dr("SecondLoad") = Val(SecondLoadAFII.Text)
        'dr("Remarks") = RemarksAFII.Text
        'dt.Rows.Add(dr)

        'dr = dt.NewRow
        'dr("ReadingDate") = CDate(txtDate.Text)
        'dr("SlNo") = Label4.Text
        'dr("FirstPF") = Val(FirstPFAFIII.Text)
        'dr("FirstLoad") = Val(FirstLoadAFIII.Text)
        'dr("SecondPF") = Val(SecondPFAFIII.Text)
        'dr("SecondLoad") = Val(SecondLoadAFIII.Text)
        'dr("Remarks") = RemarksAFIII.Text
        'dt.Rows.Add(dr)

        'dr = dt.NewRow
        'dr("ReadingDate") = CDate(txtDate.Text)
        'dr("SlNo") = Label5.Text
        'dr("FirstPF") = Val(FirstPFPUMPHOUSE.Text)
        'dr("FirstLoad") = Val(FirstLoadPUMPHOUSE.Text)
        'dr("SecondPF") = Val(SecondPFPUMPHOUSE.Text)
        'dr("SecondLoad") = Val(SecondLoadPUMPHOUSE.Text)
        'dr("Remarks") = RemarksPUMPHOUSE.Text
        'dt.Rows.Add(dr)


        'dr = dt.NewRow
        'dr("ReadingDate") = CDate(txtDate.Text)
        'dr("SlNo") = Label6.Text
        'dr("FirstPF") = Val(FirstPFWHEELSHOPESSENTIAL.Text)
        'dr("FirstLoad") = Val(FirstLoadWHEELSHOPESSENTIAL.Text)
        'dr("SecondPF") = Val(SecondPFWHEELSHOPESSENTIAL.Text)
        'dr("SecondLoad") = Val(SecondLoadWHEELSHOPESSENTIAL.Text)
        'dr("Remarks") = RemarksWHEELSHOPESSENTIAL.Text
        'dt.Rows.Add(dr)

        'dr = dt.NewRow
        'dr("ReadingDate") = CDate(txtDate.Text)
        'dr("SlNo") = Label7.Text
        'dr("FirstPF") = Val(FirstPFWHEELSHOPNONESSENTIAL.Text)
        'dr("FirstLoad") = Val(FirstLoadWHEELSHOPNONESSENTIAL.Text)
        'dr("SecondPF") = Val(SecondPFWHEELSHOPNONESSENTIAL.Text)
        'dr("SecondLoad") = Val(SecondLoadWHEELSHOPNONESSENTIAL.Text)
        'dr("Remarks") = RemarksWHEELSHOPNONESSENTIAL.Text
        'dt.Rows.Add(dr)

        'dr = dt.NewRow
        'dr("ReadingDate") = CDate(txtDate.Text)
        'dr("SlNo") = Label8.Text
        'dr("FirstPF") = Val(FirstPFTUBEPREHEAT.Text)
        'dr("FirstLoad") = Val(FirstLoadTUBEPREHEAT.Text)
        'dr("SecondPF") = Val(SecondPFTUBEPREHEAT.Text)
        'dr("SecondLoad") = Val(SecondLoadTUBEPREHEAT.Text)
        'dr("Remarks") = RemarksTUBEPREHEAT.Text
        'dt.Rows.Add(dr)

        'dr = dt.NewRow
        'dr("ReadingDate") = CDate(txtDate.Text)
        'dr("SlNo") = Label9.Text
        'dr("FirstPF") = Val(FirstPFMOULDPREHEAT.Text)
        'dr("FirstLoad") = Val(FirstLoadMOULDPREHEAT.Text)
        'dr("SecondPF") = Val(SecondPFMOULDPREHEAT.Text)
        'dr("SecondLoad") = Val(SecondLoadMOULDPREHEAT.Text)
        'dr("Remarks") = RemarksMOULDPREHEAT.Text
        'dt.Rows.Add(dr)

        'dr = dt.NewRow
        'dr("ReadingDate") = CDate(txtDate.Text)
        'dr("SlNo") = Label10.Text
        'dr("FirstPF") = Val(FirstPFFUMEEXTRACTION.Text)
        'dr("FirstLoad") = Val(FirstLoadFUMEEXTRACTION.Text)
        'dr("SecondPF") = Val(SecondPFFUMEEXTRACTION.Text)
        'dr("SecondLoad") = Val(SecondLoadFUMEEXTRACTION.Text)
        'dr("Remarks") = RemarksFUMEEXTRACTION.Text
        'dt.Rows.Add(dr)

        'dr = dt.NewRow
        'dr("ReadingDate") = CDate(txtDate.Text)
        'dr("SlNo") = Label11.Text
        'dr("FirstPF") = Val(FirstPFCOMPRESSOR.Text)
        'dr("FirstLoad") = Val(FirstLoadCOMPRESSOR.Text)
        'dr("SecondPF") = Val(SecondPFCOMPRESSOR.Text)
        'dr("SecondLoad") = Val(SecondLoadCOMPRESSOR.Text)
        'dr("Remarks") = RemarksCOMPRESSOR.Text
        'dt.Rows.Add(dr)

        'dr = dt.NewRow
        'dr("ReadingDate") = CDate(txtDate.Text)
        'dr("SlNo") = Label12.Text
        'dr("FirstPF") = Val(FirstPFASSEMBLY.Text)
        'dr("FirstLoad") = Val(FirstLoadASSEMBLY.Text)
        'dr("SecondPF") = Val(SecondPFASSEMBLY.Text)
        'dr("SecondLoad") = Val(SecondLoadASSEMBLY.Text)
        'dr("Remarks") = RemarksASSEMBLY.Text
        'dt.Rows.Add(dr)

        'dr = dt.NewRow
        'dr("ReadingDate") = CDate(txtDate.Text)
        'dr("SlNo") = Label13.Text
        'dr("FirstPF") = Val(FirstPFAXLESHOPESSENTIAL.Text)
        'dr("FirstLoad") = Val(FirstLoadAXLESHOPESSENTIAL.Text)
        'dr("SecondPF") = Val(SecondPFAXLESHOPESSENTIAL.Text)
        'dr("SecondLoad") = Val(SecondLoadAXLESHOPESSENTIAL.Text)
        'dr("Remarks") = RemarksAXLESHOPESSENTIAL.Text
        'dt.Rows.Add(dr)

        'dr = dt.NewRow
        'dr("ReadingDate") = CDate(txtDate.Text)
        'dr("SlNo") = Label14.Text
        'dr("FirstPF") = Val(FirstPFAXLESHOPNONESSENTIAL.Text)
        'dr("FirstLoad") = Val(FirstLoadAXLESHOPNONESSENTIAL.Text)
        'dr("SecondPF") = Val(SecondPFAXLESHOPNONESSENTIAL.Text)
        'dr("SecondLoad") = Val(SecondLoadAXLESHOPNONESSENTIAL.Text)
        'dr("Remarks") = RemarksAXLESHOPNONESSENTIAL.Text
        'dt.Rows.Add(dr)


        'dr = dt.NewRow
        'dr("ReadingDate") = CDate(txtDate.Text)
        'dr("SlNo") = Label15.Text
        'dr("FirstPF") = Val(FirstPFGFM.Text)
        'dr("FirstLoad") = Val(FirstLoadGFM.Text)
        'dr("SecondPF") = Val(SecondPFGFM.Text)
        'dr("SecondLoad") = Val(SecondLoadGFM.Text)
        'dr("Remarks") = RemarksGFM.Text
        'dt.Rows.Add(dr)

        'dr = dt.NewRow
        'dr("ReadingDate") = CDate(txtDate.Text)
        'dr("SlNo") = Label16.Text
        'dr("FirstPF") = Val(FirstPFCANTEEN.Text)
        'dr("FirstLoad") = Val(FirstLoadCANTEEN.Text)
        'dr("SecondPF") = Val(SecondPFCANTEEN.Text)
        'dr("SecondLoad") = Val(SecondLoadCANTEEN.Text)
        'dr("Remarks") = RemarksCANTEEN.Text
        'dt.Rows.Add(dr)

        'dr = dt.NewRow
        'dr("ReadingDate") = CDate(txtDate.Text)
        'dr("SlNo") = Label17.Text
        'dr("FirstPF") = Val(FirstPFCOLONY.Text)
        'dr("FirstLoad") = Val(FirstLoadCOLONY.Text)
        'dr("SecondPF") = Val(SecondPFCOLONY.Text)
        'dr("SecondLoad") = Val(SecondLoadCOLONY.Text)
        'dr("Remarks") = RemarksCOLONY.Text
        'dt.Rows.Add(dr)

        'dr = dt.NewRow
        'dr("ReadingDate") = CDate(txtDate.Text)
        'dr("SlNo") = Label18.Text
        'dr("FirstPF") = Val(FirstPFADMIN.Text)
        'dr("FirstLoad") = Val(FirstLoadADMIN.Text)
        'dr("SecondPF") = Val(SecondPFADMIN.Text)
        'dr("SecondLoad") = Val(SecondLoadADMIN.Text)
        'dr("Remarks") = RemarksADMIN.Text
        'dt.Rows.Add(dr)

        'dr = dt.NewRow
        'dr("ReadingDate") = CDate(txtDate.Text)
        'dr("SlNo") = Label19.Text
        'dr("FirstPF") = Val(FirstPFEMMS.Text)
        'dr("FirstLoad") = Val(FirstLoadEMMS.Text)
        'dr("SecondPF") = Val(SecondPFEMMS.Text)
        'dr("SecondLoad") = Val(SecondLoadEMMS.Text)
        'dr("Remarks") = RemarksEMMS.Text
        'dt.Rows.Add(dr)

        'dr = dt.NewRow
        'dr("ReadingDate") = CDate(txtDate.Text)
        'dr("SlNo") = Label20.Text
        'dr("FirstPF") = Val(FirstPFLOP.Text)
        'dr("FirstLoad") = Val(FirstLoadLOP.Text)
        'dr("SecondPF") = Val(SecondPFLOP.Text)
        'dr("SecondLoad") = Val(SecondLoadLOP.Text)
        'dr("Remarks") = RemarksLOP.Text
        'dt.Rows.Add(dr)
    End Sub
End Class
