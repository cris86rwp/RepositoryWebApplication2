Public Class PHL_Report_Generation
    Inherits System.Web.UI.Page
    Protected WithEvents txtPHLDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblmessage As System.Web.UI.WebControls.Label
    Protected WithEvents chkAll As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkHighlights As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkGenList As System.Web.UI.WebControls.CheckBoxList
    Protected WithEvents rdoProcessStyle As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnGenReport As System.Web.UI.WebControls.Button
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
        Session("UserID") = "078844"
        Session("Group") = "PCOPCO"
        If Page.IsPostBack = False Then
            Dim dt, lastphldt As Date
            lastphldt = PCO.tables.lastphldt
            dt = lastphldt
            txtPHLDate.Text = lastphldt
            If dt = #1/1/1900# Or dt > Today Then
                txtPHLDate.Text = ""
            Else
                Try
                    If PCO.tables.PHLCheckDate(CDate(txtPHLDate.Text)) Then Generated() Else NotGenerated()
                Catch exp As Exception
                    lblmessage.Text = exp.Message
                End Try
            End If
            txtPHLDate.ReadOnly = True
            If lblmessage.Text = "" Then
                chkAll.Visible = rdoProcessStyle.SelectedItem.Text = "Queue"
            End If
            dt = Nothing
            lastphldt = Nothing
        End If
    End Sub
    Private Sub btnGenReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenReport.Click
        ' rlyboard targets to be added
        ' chkgenlist.item index not to be disturbed....
        Dim blnDone As Boolean = True
        lblmessage.Text = ""
        If chkHighlights.Checked = True Then
            If New PCO.PCO().GenPHLReport(CDate(txtPHLDate.Text)) = False OrElse New PCO.PCO().GenPHLRBReport(CDate(txtPHLDate.Text)) = False Then
                blnDone = False
            Else
                blnDone = True
            End If
            chkHighlights.Checked = Not blnDone
            If Not chkAll.Visible Then
                lblmessage.Text = "Generated !"
                Exit Sub
            End If
        End If
        Dim PHLGen As DataTable
        Try
            PHLGen = New PCO.PCO().GenPHLDetailReport(CDate(txtPHLDate.Text), blnDone, chkGenList.Items(0).Selected, chkGenList.Items(1).Selected, chkGenList.Items(2).Selected, chkGenList.Items(3).Selected, chkGenList.Items(4).Selected, chkGenList.Items(5).Selected, chkGenList.Items(6).Selected, chkGenList.Items(7).Selected, chkGenList.Items(8).Selected, chkGenList.Items(9).Selected, chkGenList.Items(10).Selected)
            Dim i As Integer
            If PHLGen.Rows.Count > 0 Then
                If PHLGen.Rows(0)(1) = False Then
                    lblmessage.Text = "Generated !"
                Else
                    lblmessage.Text = "Re-Generated !"
                End If
                i = 0
                For i = 0 To PHLGen.Rows.Count - 1
                    chkGenList.Items(PHLGen.Rows(i)(0)).Selected = PHLGen.Rows(i)(1)
                Next
                chkHighlights.Checked = False
            End If
            i = Nothing
        Catch exp As Exception
            lblmessage.Text = exp.Message
        End Try
        blnDone = Nothing
        PHLGen = Nothing
    End Sub
    Private Sub txtPHLDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPHLDate.TextChanged
        lblmessage.Text = ""
        Try
            If PCO.tables.PHLCheckDate(CDate(txtPHLDate.Text)) Then Generated() Else NotGenerated()
        Catch exp As Exception
            lblmessage.Text = exp.Message
        End Try
    End Sub
    Private Sub NotGenerated()
        btnGenReport.Text = "Generate"
        btnGenReport.Enabled = True
    End Sub
    Private Sub Generated()
        btnGenReport.Text = "Re-Generate"
        btnGenReport.Enabled = True
    End Sub
    Private Sub chkAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAll.CheckedChanged
        Dim chkitem As ListItem
        For Each chkitem In chkGenList.Items
            chkitem.Selected = PCO.tables.NotDone(chkitem.Text, CDate(txtPHLDate.Text))
        Next
        chkHighlights.Checked = PCO.tables.NotDone(chkHighlights.Text, CDate(txtPHLDate.Text))
    End Sub
    Private Sub rdoProcessStyle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoProcessStyle.SelectedIndexChanged
        chkAll.Visible = rdoProcessStyle.SelectedItem.Text = "Queue"
        If chkAll.Visible = False Then
            Dim chkitem As ListItem
            For Each chkitem In chkGenList.Items
                chkitem.Selected = False
            Next
            chkHighlights.Checked = False
            chkitem = Nothing
        End If
    End Sub
End Class
