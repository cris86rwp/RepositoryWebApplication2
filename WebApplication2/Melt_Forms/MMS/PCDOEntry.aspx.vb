Public Class PCDOEntry
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents rblYear As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblMonth As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtAccidents As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDAR As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtOT As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPFNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtPFRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents chkDelete As System.Web.UI.WebControls.CheckBox
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
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


    Protected Sub Dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not Page.IsPostBack Then
            populate_Code()
            SetType()
        End If
    End Sub

    Private Sub populate_Code()
        Dim ds As DataSet
        Try
            ds = PCO.tables.GetShopCodes("WHLMLT")
            rblYear.DataSource = ds.Tables(1)
            rblYear.DataTextField = ds.Tables(1).Columns("ConsumedYear").ColumnName
            rblYear.DataValueField = ds.Tables(1).Columns("ConsumedYear").ColumnName
            rblYear.DataBind()
            rblMonth.DataSource = ds.Tables(2)
            rblMonth.DataTextField = ds.Tables(2).Columns("MName").ColumnName
            rblMonth.DataValueField = ds.Tables(2).Columns("MNo").ColumnName
            rblMonth.DataBind()
            Dim i As Int16
            rblYear.SelectedIndex = 0
            i = 0
            rblMonth.ClearSelection()
            For i = 0 To rblMonth.Items.Count - 1
                If Val(rblMonth.Items(i).Value) = Now.AddMonths(-1).Month Then
                    rblMonth.Items(i).Selected = True
                    Exit For
                End If
            Next
            i = Nothing
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            ds = Nothing
        End Try
    End Sub

    Private Sub txtPFNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPFNo.TextChanged
        lblMessage.Text = ""
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Dim dt As DataTable
        Try
            dt = RWF.Melting.GetPFDetails(txtPFNo.Text.Trim)
            If dt.Rows.Count = 0 Then
                lblMessage.Text = " InValid Employee code : " & txtPFNo.Text
                txtPFNo.Text = ""
            Else
                txtPFRemarks.Text = RWF.Melting.GetPFremarks(rblYear.SelectedItem.Value + rblMonth.SelectedItem.Value, txtPFNo.Text.Trim)
                DataGrid1.DataSource = dt
                DataGrid1.DataBind()
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt = Nothing
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        If txtPFNo.Text.Trim.Length = 0 Then
            lblMessage.Text = " InValid Employee code !"
            Exit Sub
        End If
        Dim done As Boolean
        Try
            done = New RWF.Melting().SavePCDODetails(rblYear.SelectedItem.Value + rblMonth.SelectedItem.Value, Val(txtAccidents.Text), Val(txtDAR.Text), Val(txtOT.Text), txtPFNo.Text.Trim, txtPFRemarks.Text.Trim, chkDelete.Checked)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If done Then
            SetType()
            txtAccidents.Text = ""
            txtDAR.Text = ""
            txtOT.Text = ""
            txtPFNo.Text = ""
            txtPFRemarks.Text = ""
            DataGrid1.DataSource = Nothing
            DataGrid1.DataBind()
            chkDelete.Checked = False
            lblMessage.Text &= " Data Saved !"
        End If
    End Sub

    Private Sub rblYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblYear.SelectedIndexChanged
        lblMessage.Text = ""
        SetType()
    End Sub

    Private Sub rblMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblMonth.SelectedIndexChanged
        lblMessage.Text = ""
        SetType()
    End Sub

    Private Sub SetType()
        Dim dt As DataTable
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        Try
            dt = RWF.Melting.GetMeltPCDODetails(rblYear.SelectedItem.Value + rblMonth.SelectedItem.Value)
            If dt.Rows.Count > 0 Then
                txtAccidents.Text = dt.Rows(0)(0)
                txtDAR.Text = dt.Rows(0)(1)
                txtOT.Text = dt.Rows(0)(2)
                DataGrid2.DataSource = dt
                DataGrid2.DataBind()
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt = Nothing
        End Try
    End Sub
End Class
