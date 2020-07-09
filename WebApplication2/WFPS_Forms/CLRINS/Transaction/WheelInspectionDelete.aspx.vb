Public Class WheelInspectionDelete
    Inherits System.Web.UI.Page
    Protected WithEvents txtHeatNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWheelNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnDelete As System.Web.UI.WebControls.Button
    Protected WithEvents lblWheelStatus As System.Web.UI.WebControls.Label
    Protected WithEvents lblBoreStatus As System.Web.UI.WebControls.Label
    Protected WithEvents lblTreadDia As System.Web.UI.WebControls.Label
    Protected WithEvents lblRemarks As System.Web.UI.WebControls.Label
    Protected WithEvents lblPlateThickness As System.Web.UI.WebControls.Label
    Protected WithEvents btnClear As System.Web.UI.WebControls.Button
    Protected WithEvents dgMasterHistory As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgMagHistory As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgFIHistory As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgYIHistory As System.Web.UI.WebControls.DataGrid
    Protected WithEvents pnlHistory As System.Web.UI.WebControls.Panel
    Protected WithEvents dgQChistory As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgWhlLoadHistory As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgPressHistory As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgDespHistory As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblEmpCode As System.Web.UI.WebControls.Label
    Protected WithEvents dgDeletedWheels As System.Web.UI.WebControls.DataGrid
    Protected WithEvents chkGShiftEntry As System.Web.UI.WebControls.CheckBox
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
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Page.IsPostBack = False Then
            'Session("UserID") = "080821"
            Session("UserID") = "01698"
            Session("Group") = "CLRINS"
            Dim blnUnAuthorised As Boolean
            Try
                If Session("Group") <> "CLRINS" Or Session("UserID") = "" Then
                    blnUnAuthorised = True
                End If
            Catch exp As Exception
                blnUnAuthorised = True
            Finally

            End Try
            If blnUnAuthorised Then
                Response.Redirect("/mms/InvalidSession.aspx")
                Exit Sub
            End If
            Dim FiWhlForDel As InspWheelDeleteAssistant
            Session("vFiDelWhl") = FiWhlForDel
            lblEmpCode.Text = Session("UserID")
            populateDeletedWheelsGrid()
            blnUnAuthorised = Nothing
            FiWhlForDel = Nothing
        End If
    End Sub
    Private Sub populateDeletedWheelsGrid()
        Try
            Dim FiWhlDel As InspWheelDeleteAssistant
            dgDeletedWheels.DataSource = FiWhlDel.DeletedWheelsInShift(Now.Date)
            dgDeletedWheels.DataBind()
            FiWhlDel = Nothing
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try

    End Sub

    Private Sub txtWheelNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWheelNumber.TextChanged
        pnlHistory.Visible = False
        txtHeatNumber.Text = ""
        lblMessage.Text = ""
        If Val(txtWheelNumber.Text) > 99999 Then
            txtHeatNumber.Text = "0"
        Else
            txtHeatNumber.Text = ""
        End If
        If txtHeatNumber.Text <> "" Then
            CheckWheel()
        End If
    End Sub
    Private Sub CheckWheel()
        If txtHeatNumber.Text <> "" And txtWheelNumber.Text <> "" Then
            Try
                Session("vFiDelWhl") = Nothing
                Dim FiWhlForDel As New InspWheelDeleteAssistant(CLng(txtWheelNumber.Text), CLng(txtHeatNumber.Text), chkGShiftEntry.Checked)
                chkGShiftEntry.Enabled = False
                Session("vFiDelWhl") = FiWhlForDel
                txtWheelNumber.Text = CType(Session("vFiDelWhl"), InspWheelDeleteAssistant).WheelNumber
                txtHeatNumber.Text = CType(Session("vFiDelWhl"), InspWheelDeleteAssistant).HeatNumber
                lblBoreStatus.Text = CType(Session("vFiDelWhl"), InspWheelDeleteAssistant).BoreStatus
                lblPlateThickness.Text = CType(Session("vFiDelWhl"), InspWheelDeleteAssistant).PlateThickness
                lblWheelStatus.Text = CType(Session("vFiDelWhl"), InspWheelDeleteAssistant).WheelStatus
                lblTreadDia.Text = CType(Session("vFiDelWhl"), InspWheelDeleteAssistant).TreadDiameter
                lblRemarks.Text = CType(Session("vFiDelWhl"), InspWheelDeleteAssistant).Remarks
                showWheelHistory()
                If txtWheelNumber.Text <> "" Then
                    btnDelete.Enabled = True
                    btnDelete.Text = "ConFirm Deletion"
                    lblMessage.Text = CType(Session("vFiDelWhl"), InspWheelDeleteAssistant).Message
                End If
                FiWhlForDel = Nothing
            Catch exp As Exception
                btnDelete.Text = "Delete"
                btnDelete.Enabled = False
                lblMessage.Text = exp.Message
                Dim FiWhlForDel As InspWheelDeleteAssistant
                Session("vFiDelWhl") = FiWhlForDel
                txtWheelNumber.Text = ""
                txtHeatNumber.Text = ""
                lblRemarks.Text = ""
                lblTreadDia.Text = ""
                lblPlateThickness.Text = ""
                lblWheelStatus.Text = ""
                lblBoreStatus.Text = ""
                FiWhlForDel = Nothing
            Finally

            End Try
        End If
    End Sub
    Private Sub showWheelHistory()
        Dim ds As New DataSet()
        Dim dvMaster As New DataView()
        Dim dvMag As New DataView()
        Dim dvFI As New DataView()
        Dim dvYI As New DataView()
        Dim dvqc As New DataView()
        Dim dvWhlLoad As New DataView()
        Dim dvPress As New DataView()
        Dim dvDesp As New DataView()

        ds = CType(Session("vFiDelWhl"), InspWheelDeleteAssistant).getBriefHistory
        dvMaster.Table = ds.Tables(0)
        dvMag.Table = ds.Tables(1)
        dvFI.Table = ds.Tables(2)
        dvYI.Table = ds.Tables(3)
        dvqc.Table = ds.Tables(4)
        dvWhlLoad.Table = ds.Tables(5)
        dvPress.Table = ds.Tables(6)
        dvDesp.Table = ds.Tables(7)
        dgMasterHistory.DataSource = dvMaster
        dgMasterHistory.DataBind()
        dgMagHistory.DataSource = dvMag
        dgMagHistory.DataBind()
        dgFIHistory.DataSource = dvFI
        dgFIHistory.DataBind()
        dgYIHistory.DataSource = dvYI
        dgYIHistory.DataBind()
        dgQChistory.DataSource = dvqc
        dgQChistory.DataBind()
        dgWhlLoadHistory.DataSource = dvWhlLoad
        dgWhlLoadHistory.DataBind()
        dgPressHistory.DataSource = dvPress
        dgPressHistory.DataBind()
        dgDespHistory.DataSource = dvDesp
        dgDespHistory.DataBind()
        ds.Dispose()
        pnlHistory.Visible = True
        If dvPress.Count > 0 Then
            lblMessage.Text = "Wheel Pressed in Assembly : " & txtWheelNumber.Text & "/" & txtHeatNumber.Text
            txtWheelNumber.Text = ""
            txtHeatNumber.Text = ""
            btnDelete.Enabled = False
        ElseIf dvWhlLoad.Count > 0 Then
            lblMessage.Text = "Wheel loaded in Assembly : " & txtWheelNumber.Text & "/" & txtHeatNumber.Text
            txtWheelNumber.Text = ""
            txtHeatNumber.Text = ""
            btnDelete.Enabled = False
        ElseIf dvDesp.Count > 0 Then
            lblMessage.Text = "Wheel Despatched : " & txtWheelNumber.Text & "/" & txtHeatNumber.Text
            txtWheelNumber.Text = ""
            txtHeatNumber.Text = ""
            btnDelete.Enabled = False
        ElseIf dvqc.Count > 0 Then
            ' If fi date is more than QC date wheel can be deleted from fi.
            ' corrected on 28-12-2007
            If dvFI(0)(2) > dvqc(0)(2) Then
                ' delete enabled
            Else
                lblMessage.Text = "Wheel Under QC Insp : " & txtWheelNumber.Text & "/" & txtHeatNumber.Text
                txtWheelNumber.Text = ""
                txtHeatNumber.Text = ""
                btnDelete.Enabled = False
            End If

            '  End If
        ElseIf dvYI.Count > 0 Then
            'Dim dr As DataRow
            'Dim blnUnderYI As Boolean
            'For Each dr In dvYI.Table.Rows
            '    If dr("Yard_Inspection_date") >= Now.Date Then
            '        blnUnderYI = True
            '        Exit For
            '    End If
            'Next
            'If blnUnderYI Then
            lblMessage.Text = "Wheel Under Yard Insp : " & txtWheelNumber.Text & "/" & txtHeatNumber.Text
            txtWheelNumber.Text = ""
            txtHeatNumber.Text = ""
            btnDelete.Enabled = False
            'End If
        End If
        ds = Nothing
        dvMaster = Nothing
        dvMag = Nothing
        dvFI = Nothing
        dvYI = Nothing
        dvqc = Nothing
        dvWhlLoad = Nothing
        dvPress = Nothing
        dvDesp = Nothing
    End Sub
    Private Sub txtHeatNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHeatNumber.TextChanged
        If txtWheelNumber.Text.Replace("0", "") <> "" Then
            If txtHeatNumber.Text <> "" Then
                CheckWheel()
            End If
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If Not btnDelete.Text = "ConFirm Deletion" Or txtWheelNumber.Text = "" Or txtHeatNumber.Text = "" Then
            Exit Sub
        End If
        Try
            lblMessage.Text = CType(Session("vFiDelWhl"), InspWheelDeleteAssistant).Delete(chkGShiftEntry.Checked)
        Catch exp As Exception
            lblMessage.Text = exp.Message & ":" & txtWheelNumber.Text & "/" & txtHeatNumber.Text
            txtWheelNumber.Text = ""
            txtHeatNumber.Text = ""
        Finally
            chkGShiftEntry.Enabled = True
            chkGShiftEntry.Checked = False
            btnDelete.Text = "Delete"
        End Try
        populateDeletedWheelsGrid()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        btnDelete.Text = "Delete"
        btnDelete.Enabled = False
        Dim FiWhlForDel As InspWheelDeleteAssistant
        Session("vFiDelWhl") = FiWhlForDel
        txtWheelNumber.Text = ""
        txtHeatNumber.Text = ""
        lblRemarks.Text = ""
        lblTreadDia.Text = ""
        lblPlateThickness.Text = ""
        lblWheelStatus.Text = ""
        lblBoreStatus.Text = ""
        chkGShiftEntry.Enabled = True
        chkGShiftEntry.Checked = False
        FiWhlForDel = Nothing
    End Sub

End Class
