Public Class CaliFreqUpdate
    Inherits System.Web.UI.Page
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents ddlInstruments As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblInstrumentType As System.Web.UI.WebControls.Label
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents rblFQ As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents lblEnd As System.Web.UI.WebControls.Label
    Protected WithEvents lblStart As System.Web.UI.WebControls.Label
    Protected WithEvents btnChange As System.Web.UI.WebControls.Button
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
        'If IsPostBack = False Then
        '    btnChange.Text = ""
        Try
                GetToolsList()
                FillGrid()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        'End If
    End Sub

    Private Sub GetToolsList()
        Dim ds As DataSet
        ds = ToolRoom.Tables.ToolsForFQChange
        If ds.Tables(0).Rows.Count > 0 Then
            ddlInstruments.DataSource = ds.Tables(0)
            ddlInstruments.DataTextField = ds.Tables(0).Columns("InstrumentNumber").ColumnName
            ddlInstruments.DataValueField = ds.Tables(0).Columns("InstrumentType").ColumnName
            ddlInstruments.DataBind()
            ddlInstruments.SelectedIndex = 0
            lblInstrumentType.Text = ddlInstruments.SelectedItem.Value
            rblFQ.DataSource = ds.Tables(1)
            rblFQ.DataTextField = ds.Tables(1).Columns("Frequency").ColumnName
            rblFQ.DataValueField = ds.Tables(1).Columns("FrequencyCode").ColumnName
            rblFQ.DataBind()
        End If
    End Sub

    Private Sub ddlInstruments_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlInstruments.SelectedIndexChanged
        lblMessage.Text = ""
        lblInstrumentType.Text = ddlInstruments.SelectedItem.Value
        FillGrid()
    End Sub

    Private Sub FillGrid()
        Dim ds As DataSet
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        Try
            ds = ToolRoom.Tables.ToolHistory(ddlInstruments.SelectedItem.Text.Trim)
            DataGrid1.DataSource = ds.Tables(0)
            DataGrid1.DataBind()
            DataGrid2.DataSource = ds.Tables(2)
            DataGrid2.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub Check()
        Dim i As Long
        lblStart.Text = ""
        lblEnd.Text = ""
        Dim chkBoxFrom, chkBoxTo As CheckBox
        Dim checkedFrom, checkedTo As Integer
        checkedFrom = 0
        checkedTo = 0
        For i = 0 To DataGrid2.Items.Count - 1
            chkBoxFrom = DataGrid2.Items(i).FindControl("chkFrom")
            chkBoxTo = DataGrid2.Items(i).FindControl("chkTo")
            If chkBoxFrom.Checked Then
                checkedFrom = checkedFrom + 1
                lblStart.Text = DataGrid2.Items(i).Cells(8).Text
            End If
            If chkBoxTo.Checked Then
                checkedTo = checkedTo + 1
                lblEnd.Text = DataGrid2.Items(i).Cells(8).Text
            End If
        Next
        If checkedFrom > 1 OrElse checkedTo > 1 Then Throw New Exception("More than one Selection in From Or To Wheel !")
        If Val(lblStart.Text) > Val(lblEnd.Text) Then Throw New Exception("From ID and To ID selection mis-match ! ")
        chkBoxFrom = Nothing
        chkBoxTo = Nothing
        checkedFrom = Nothing
        checkedTo = Nothing
    End Sub

    Private Sub rblFQ_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblFQ.SelectedIndexChanged
        lblMessage.Text = ""
        btnChange.Text = " Change to " & rblFQ.SelectedItem.Text
    End Sub

    Private Sub btnChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChange.Click
        lblMessage.Text = ""
        If btnChange.Text.Trim.Length = 0 Then
            lblMessage.Text = "Please select Change To Frequency !"
            Exit Sub
        End If
        Dim Done As Boolean
        Try
            Check()
            Done = New ToolRoom.Tool("T").UpdateFQ(ddlInstruments.SelectedItem.Text, Val(lblStart.Text), Val(lblEnd.Text), rblFQ.SelectedItem.Value)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If Done Then
            FillGrid()
            lblMessage.Text &= " Data Updated !"
        End If
        Done = Nothing
    End Sub
End Class
