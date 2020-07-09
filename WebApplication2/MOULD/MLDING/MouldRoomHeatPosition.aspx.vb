Public Class MouldRoomHeatPosition
    Inherits System.Web.UI.Page
    Protected WithEvents Heat As System.Web.UI.WebControls.TextBox
    Protected WithEvents WC As System.Web.UI.WebControls.Label
    Protected WithEvents Remarks1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Itemp As System.Web.UI.WebControls.Label
    Protected WithEvents Ftemp As System.Web.UI.WebControls.Label
    Protected WithEvents LiTank As System.Web.UI.WebControls.Label
    Protected WithEvents PST As System.Web.UI.WebControls.Label
    Protected WithEvents PET As System.Web.UI.WebControls.Label
    Protected WithEvents TPT As System.Web.UI.WebControls.Label
    Protected WithEvents Remarks2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents PrgDly As System.Web.UI.WebControls.Label
    Protected WithEvents PrgStrDly As System.Web.UI.WebControls.Label
    Protected WithEvents Remarks3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Save As System.Web.UI.WebControls.Button
    Protected WithEvents btnShow As System.Web.UI.WebControls.Button
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents frHt As System.Web.UI.WebControls.TextBox
    Protected WithEvents toHt As System.Web.UI.WebControls.TextBox
    Protected WithEvents MPILDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents MPILTimeHr As System.Web.UI.WebControls.TextBox
    Protected WithEvents MPILTimeMin As System.Web.UI.WebControls.TextBox
    Protected WithEvents RunOuts As System.Web.UI.WebControls.TextBox
    Protected WithEvents RunBacks As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnReport As System.Web.UI.WebControls.Button
    Protected WithEvents Panel2 As System.Web.UI.WebControls.Panel
    Protected WithEvents txtFromDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtToDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnDateWise As System.Web.UI.WebControls.Button
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    'new
    Protected WithEvents txtxc50 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtOverflow As System.Web.UI.WebControls.TextBox
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
        'Session("UserID") = "016002"
        'Session("Group") = "MLDING"
        'Response.Redirect("http://reportserver/mmsreports/mlding/MouldRoomHeatPosition.aspx")
        If Page.IsPostBack = False Then
            MPILDate.Text = Now.Date
            txtFromDate.Text = Now.Date
            txtToDate.Text = Now.Date
            MPILTimeHr.Text = CStr(Now.Hour).PadLeft(2, "0").Substring(0, 2)
            MPILTimeMin.Text = CStr(Now.Minute).PadLeft(2, "0").Substring(0, 2)
            frHt.Text = RWF.tables.GetLatestPrePourHeat
            toHt.Text = RWF.tables.GetLatestPrePourHeat
        End If
    End Sub
    Private Sub Clear()
        WC.Text = "0"
        Itemp.Text = "0"
        Ftemp.Text = "0"
        LiTank.Text = "0"
        PST.Text = "01-01-1900"
        PET.Text = "01-01-1900"
        TPT.Text = "01-01-1900"
        PrgDly.Text = "0"
        PrgStrDly.Text = "0"
        Remarks1.Text = ""
        Remarks2.Text = ""
        Remarks3.Text = ""
        RunOuts.Text = ""
        RunBacks.Text = ""
        txtxc50.Text = ""
        txtOverflow.Text = ""
    End Sub
    Private Sub Heat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Heat.TextChanged
        lblMessage.Text = ""
        Clear()
        If CInt(Heat.Text) > 0 Then
            Dim ds As New DataSet()
            Try
                ds = RWF.MLDING.MRHeatDetails(CInt(Heat.Text))
                If ds.Tables(0).Rows.Count > 0 Then
                    WC.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("WC")), 0, ds.Tables(0).Rows(0)("WC"))
                    Itemp.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("Itemp")), 0, ds.Tables(0).Rows(0)("Itemp"))
                    Ftemp.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("Ftemp")), 0, ds.Tables(0).Rows(0)("Ftemp"))
                    'TapTm.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("TapTm")), 0, ds.Tables(0).Rows(0)("TapTm"))
                    LiTank.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("LiTank")), 0, ds.Tables(0).Rows(0)("LiTank"))
                    PST.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("PST")), "01-01-1900", ds.Tables(0).Rows(0)("PST"))
                    PET.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("PET")), "01-01-1900", ds.Tables(0).Rows(0)("PET"))
                    TPT.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("TPT")), "01-01-1900", ds.Tables(0).Rows(0)("TPT"))
                    PrgDly.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("PrgDly")), 0, ds.Tables(0).Rows(0)("PrgDly"))
                    PrgStrDly.Text = IIf(IsDBNull(ds.Tables(0).Rows(0)("PrgStrDly")), 0, ds.Tables(0).Rows(0)("PrgStrDly"))
                    If ds.Tables(1).Rows.Count > 0 Then
                        MPILDate.Text = IIf(ds.Tables(1).Rows(0)("MPILDate") = "01/01/1900", "", ds.Tables(1).Rows(0)("MPILDate"))
                        'MPILTimeHr.Text = CStr(IIf(IsDBNull(ds.Tables(1).Rows(0)("MPILTime")), "00", IIf(ds.Tables(1).Rows(0)("MPILTime").GetType.ToString.Length = 10, "00", ds.Tables(1).Rows(0)("MPILTime"))).Substring(11, 2))
                        'MPILTimeMin.Text = CStr(IIf(IsDBNull(ds.Tables(1).Rows(0)("MPILTime")), "00", IIf(ds.Tables(1).Rows(0)("MPILTime").GetType.ToString.Length = 15, "00", ds.Tables(1).Rows(0)("MPILTime"))).Substring(14, 2))
                        MPILTimeHr.Text = IIf(ds.Tables(1).Rows(0)("MPILDate") = "01/01/1900", "", ds.Tables(1).Rows(0)("MPILHr"))
                        MPILTimeMin.Text = IIf(ds.Tables(1).Rows(0)("MPILDate") = "01/01/1900", "", ds.Tables(1).Rows(0)("MPILMn"))
                        Remarks1.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)("Remarks1")), "", ds.Tables(1).Rows(0)("Remarks1"))
                        Remarks2.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)("Remarks2")), "", ds.Tables(1).Rows(0)("Remarks2"))
                        Remarks3.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)("Remarks3")), "", ds.Tables(1).Rows(0)("Remarks3"))
                        RunOuts.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)("RunOuts")), "", ds.Tables(1).Rows(0)("RunOuts"))
                        RunBacks.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)("RunBacks")), "", ds.Tables(1).Rows(0)("RunBacks"))
                        txtxc50.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)("XC50")), "", ds.Tables(1).Rows(0)("XC50"))
                        txtOverflow.Text = IIf(IsDBNull(ds.Tables(1).Rows(0)("Overflow")), "", ds.Tables(1).Rows(0)("Overflow"))
                    End If
                End If
            Catch exp As Exception
                lblMessage.Text = "Data Filling  Failed : " & exp.Message
            Finally
                ds.Dispose()
                ds = Nothing
            End Try
        Else
            lblMessage.Text = "InValid Heat Number : '" & Heat.Text & "'"
        End If
    End Sub

    Private Sub Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save.Click
        lblMessage.Text = ""
        If CDate(MPILDate.Text) > Now.Date Then
            lblMessage.Text = "Date cannot be greater than today !"
        Else
            Dim Done As Boolean
            Try
                Dim str As String = CDate(MPILDate.Text).Year.ToString + "-" + CDate(MPILDate.Text).Month.ToString.PadLeft(2, "0").Substring(0, 2) + "-" + CDate(MPILDate.Text).Day.ToString.PadLeft(2, "0").Substring(0, 2) + " " + MPILTimeHr.Text.PadLeft(2, "0").Substring(0, 2) + ":" + MPILTimeMin.Text.PadLeft(2, "0").Substring(0, 2)
                Done = New RWF.MLDING().SaveMRHeatPosition(str, CInt(Heat.Text), Remarks1.Text.Trim.ToLower & "", Remarks2.Text.Trim.ToLower & "", Remarks3.Text.Trim.ToLower & "", Val(RunOuts.Text), Val(RunBacks.Text), Val(txtxc50.Text), Val(txtOverflow.Text))
                str = Nothing
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
            Done = Nothing
        End If
    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        lblMessage.Text = ""
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            DataGrid1.DataSource = RWF.MLDING.MRHeatPositionData(CInt(frHt.Text), CInt(toHt.Text))
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = "Data Grid Filling  Failed : " & exp.Message
        End Try
    End Sub
    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim strPathName As String
        Dim txtDate As New TextBox()
        txtDate.Text = CDate("1900-01-01")
        strPathName = "http://" & rwfGen.ReportServer.ServerName & "" & _
                    "/" & rwfGen.ReportServer.ServerName & "/mmsreports/mlding/formats/MRHeatPosition.rpt?user0=report&password0=report" & _
                    "&prompt0=" & CInt(frHt.Text) & "" & _
                    "&prompt1=" & CInt(toHt.Text) & "" & _
                    "&prompt2=DateTime(" & CDate(txtDate.Text).Year & "," & CDate(txtDate.Text).Month & "," & CDate(txtDate.Text).Day & ",00,00,00)" & _
                    "&prompt3=DateTime(" & CDate(txtDate.Text).Year & "," & CDate(txtDate.Text).Month & "," & CDate(txtDate.Text).Day & ",00,00,00)" & _
                    "&prompt4=0" & _
                    "&promptonrefresh=0"
        Response.Redirect(strPathName)
    End Sub
    Private Sub CheckDate()
        Dim dtFrom, dtTo As Date
        Try
            dtFrom = CDate(txtFromDate.Text)
            dtTo = CDate(txtToDate.Text)
            If dtFrom > dtTo Then
                Throw New Exception("From Date is more than To Date !")
            End If
            If dtFrom > Now.Today.Date Then
                Throw New Exception("From Date is more than Today !")
            End If
        Catch exp As Exception
            Throw New Exception("Date to be in DD/MM/YYYY format : " & exp.Message)
        End Try
        dtFrom = Nothing
        dtTo = Nothing
    End Sub
    Private Sub btnDateWise_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDateWise.Click
        Try
            CheckDate()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If lblMessage.Text <> "" Then
            Exit Sub
        End If
        Dim strPathName As String
        strPathName = "http://" & rwfGen.ReportServer.ServerName & "/mmsreports/mlding/formats/MRHeatPosition.rpt?user0=report&password0=report" & _
                    "&prompt0=" & CInt(0) & "" & _
                    "&prompt1=" & CInt(0) & "" & _
                    "&prompt2=DateTime(" & CDate(txtFromDate.Text).Year & "," & CDate(txtFromDate.Text).Month & "," & CDate(txtFromDate.Text).Day & ",00,00,00)" & _
                    "&prompt3=DateTime(" & CDate(txtToDate.Text).Year & "," & CDate(txtToDate.Text).Month & "," & CDate(txtToDate.Text).Day & ",00,00,00)" & _
                    "&prompt4=1" & _
                    "&promptonrefresh=0"
        Response.Redirect(strPathName)
    End Sub
End Class
