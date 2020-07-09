Public Class ProdLiningRemarks
    Inherits System.Web.UI.Page
    Protected WithEvents lblConsignee As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents rblLiningType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents ddlLiningNo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents rblSpalling As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtSpallingDepth As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSpallingArea As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnRemarks As System.Web.UI.WebControls.Button
    Protected WithEvents txtMaxErosion As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtErosionLoc As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMaxPenitration As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPenitrationLoc As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLiningCondition As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtAreaCon As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRemarks As System.Web.UI.WebControls.TextBox
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents rblRefCondemned As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents pnlLT3 As System.Web.UI.WebControls.Panel
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
        If IsPostBack = False Then
            Dim Group As String = Session("Group")
            Dim UserId As String = Session("UserID")
            Dim InValid As Boolean = False
            ''''''''''''''''
            'Session("Group") = "SSMELT"
            'Session("UserID") = "074510"
            'Group = "SSMELT"
            'UserId = "074510"
            ''''''''''''''''
            Try
                lblConsignee.Text = ProductionConsumables.GetConsignee(Group, UserId)
                If lblConsignee.Text.Trim.Length = 4 Then InValid = True
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            'If Not InValid Then
            '    Response.Redirect("/mss/logon.aspx")
            'Else
            Dim dt As DataTable
                dt = ProductionConsumables.GetLiningType(True)
                rblLiningType.DataSource = dt
                rblLiningType.DataTextField = dt.Columns(1).ColumnName
                rblLiningType.DataValueField = dt.Columns(0).ColumnName
                rblLiningType.DataBind()
                rblLiningType.SelectedIndex = 0
                dt = ProductionConsumables.GetRefCondemned
                rblRefCondemned.DataSource = dt
                rblRefCondemned.DataTextField = dt.Columns(1).ColumnName
                rblRefCondemned.DataValueField = dt.Columns(0).ColumnName
                rblRefCondemned.DataBind()
                rblRefCondemned.SelectedIndex = 0
                SetType()
            End If
        'End If
    End Sub

    Private Sub SetType()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Dim dt As DataTable
        Try
            dt = ProductionConsumables.GetFurnaceLiningNos(rblLiningType.SelectedItem.Value, 1)
            If dt.Rows.Count > 0 Then
                ddlLiningNo.DataSource = dt
                ddlLiningNo.DataTextField = dt.Columns(0).ColumnName
                ddlLiningNo.DataValueField = dt.Columns(0).ColumnName
                ddlLiningNo.DataBind()
                ddlLiningNo.SelectedIndex = 0
            Else
                lblMessage.Text = "No Details for the selection !"
            End If
            pnlLT3.Visible = False
            If rblLiningType.SelectedItem.Value = 3 Then
                pnlLT3.Visible = True
            End If
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        Finally
            dt = Nothing
        End Try
        If lblMessage.Text = "No Details for the selection !" Then
            Exit Sub
        End If
        Try
            GetLiningDetails()
            GetSavedPLDetails()
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
    End Sub

    Private Sub GetLiningDetails()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Dim ds As DataSet
        Try
            ds = ProductionConsumables.GetFurnaceLiningDetails(rblLiningType.SelectedItem.Value, ddlLiningNo.SelectedItem.Value)
            DataGrid1.DataSource = ds.Tables(0)
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
    End Sub

    Private Sub Clear()
        txtSpallingDepth.Text = ""
        txtSpallingArea.Text = ""
        txtMaxErosion.Text = ""
        txtErosionLoc.Text = ""
        txtMaxPenitration.Text = ""
        txtPenitrationLoc.Text = ""
        txtLiningCondition.Text = ""
        txtAreaCon.Text = ""
        txtRemarks.Text = ""
    End Sub

    Private Sub GetSavedPLDetails()
        Clear()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        Dim dt As DataTable
        Try
            dt = ProductionConsumables.GetSavedRemarks(ddlLiningNo.SelectedItem.Text, rblLiningType.SelectedItem.Value)
            If dt.Rows.Count > 0 Then
                txtSpallingDepth.Text = dt.Rows(0)("SpallingDepth")
                txtSpallingArea.Text = dt.Rows(0)("SpallingArea")
                txtMaxErosion.Text = dt.Rows(0)("MaxErosion")
                txtErosionLoc.Text = dt.Rows(0)("ErosionLoc")
                txtMaxPenitration.Text = dt.Rows(0)("MaxPenitration")
                txtPenitrationLoc.Text = dt.Rows(0)("PenitrationLoc")
                txtLiningCondition.Text = dt.Rows(0)("LiningCondition")
                txtAreaCon.Text = dt.Rows(0)("AreaCon")
                txtRemarks.Text = dt.Rows(0)("Remarks")
                Dim i As Int16 = 0
                rblSpalling.ClearSelection()
                For i = 0 To rblSpalling.Items.Count - 1
                    If Trim(dt.Rows(0)("Spalling")) = rblSpalling.Items(i).Text Then
                        rblSpalling.Items(i).Selected = True
                        Exit For
                    End If
                Next
                i = 0
                rblRefCondemned.ClearSelection()
                For i = 0 To rblRefCondemned.Items.Count - 1
                    If Trim(dt.Rows(0)("RefCondDueTo")) = rblRefCondemned.Items(i).Text Then
                        rblRefCondemned.Items(i).Selected = True
                        Exit For
                    End If
                Next
                DataGrid2.DataSource = dt
                DataGrid2.DataBind()
            Else
                lblMessage.Text = "No Remarks Details for Lining selection ! "
            End If
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        Finally
            dt = Nothing
        End Try
    End Sub

    Private Sub ddlLiningNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlLiningNo.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            GetLiningDetails()
            GetSavedPLDetails()
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
    End Sub

    Private Sub btnRemarks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemarks.Click
        Dim Done As Boolean
        lblMessage.Text = ""
        Try
            If rblSpalling.SelectedItem.Value = 0 Then
                txtSpallingDepth.Text = ""
                txtSpallingArea.Text = ""
            End If
            Done = New ProductionConsumables().SaveFurnaceLiningRemarks(ddlLiningNo.SelectedItem.Text.Trim, rblLiningType.SelectedItem.Value, txtMaxErosion.Text.Trim, txtErosionLoc.Text.Trim, txtMaxPenitration.Text.Trim, txtPenitrationLoc.Text.Trim, txtLiningCondition.Text.Trim, txtAreaCon.Text.Trim, rblSpalling.SelectedItem.Value, txtSpallingDepth.Text.Trim, txtSpallingArea.Text.Trim, txtRemarks.Text.Trim, rblRefCondemned.SelectedItem.Value)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If Done Then
            GetSavedPLDetails()
            lblMessage.Text &= " Data Saved successfully !"
        Else
            lblMessage.Text &= " Data Not Saved ! "
        End If
    End Sub

    Private Sub rblLiningType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblLiningType.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            SetType()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
End Class
