Public Class mmHsdPointMeterReset
    Inherits System.Web.UI.Page
    Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblHelp As System.Web.UI.WebControls.Label
    Protected WithEvents chkHelp As System.Web.UI.WebControls.CheckBox
    Protected WithEvents lblLogInEmpCode As System.Web.UI.WebControls.Label
    Protected WithEvents ddlHsdPoints As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnReset As System.Web.UI.WebControls.Button

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

    ' write code for retrival of data after key fields are entered.

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Page.IsPostBack = False Then
            btnReset.Visible = True
            btnReset.Text = "Reset Meter Readining"
            'If Session("UserID") = "016002" Then
            Session("UserID") = "016002"
            Session("Group") = "MLDING"
            Dim oEmp As rwfGen.Employee
                Dim oHsdPoint As HSD_Data.HsdPoint
                Try
                'oEmp = New rwfGen.Employee()
                'If oEmp.Check(Session("UserID"), Session("Group")) = True Then
                oHsdPoint = New HSD_Data.HsdPoint(Session("UserID"), Session("Group"))
                Session("oHsdPoint") = oHsdPoint
                'End If
                lblHeader.Text = oHsdPoint.ScreenHeader & "<br>Meter Resetting"
                    lblLogInEmpCode.Text = oHsdPoint.EnteredBy
                    If IsNothing(oHsdPoint) = False Then
                        populateDDL()
                    End If
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                End Try
                oEmp = Nothing
                oHsdPoint = Nothing
            'Else
            '    Response.Redirect("/mms/InvalidSession.aspx")
            'End If
        End If
    End Sub
    Private Sub populateDDL()
        Dim dv As New DataView()
        dv.Table = CType(Session("oHsdPoint"), HSD_Data.HsdPoint).HsdPointsTable
        dv.Sort = "HsdPoint"
        Dim i As Integer
        For i = 0 To dv.Count - 1
            ddlHsdPoints.Items.Add(dv(i)("HsdPoint"))
        Next
        ddlHsdPoints.Items.Insert(0, "Select")
        dv.Dispose()
        dv = Nothing
    End Sub
    Private Sub ddlHsdPoints_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ddlHsdPoints.SelectedItem.Text <> "Select" Then
            CType(Session("oHsdPoint"), HSD_Data.HsdPoint).HsdPoint = ddlHsdPoints.SelectedItem.Text
        Else
            CType(Session("oHsdPoint"), HSD_Data.HsdPoint).HsdPoint = ""
        End If
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        If btnReset.Text = "Reset Meter Readining" Then
            btnReset.Text = "conFirm Resetting"
        Else
            Dim oReset As HSD_Data.HsdPointReset
            Try
                oReset = New HSD_Data.HsdPointReset(Session("UserID"), Session("Group"), ddlHsdPoints.SelectedItem.Text)
                If oReset.Done Then lblMessage.Text = oReset.Message
            Catch exp As Exception
                lblMessage.Text = "Reset Error: " & exp.Message
            End Try
            btnReset.Text = "Reset Meter Reading"
            oReset = Nothing
        End If
    End Sub

    Protected Sub ddlHsdPoints_SelectedIndexChanged1(sender As Object, e As EventArgs) Handles ddlHsdPoints.SelectedIndexChanged

    End Sub
End Class
