Public Class ProdLiningPLs
    Inherits System.Web.UI.Page
    Protected WithEvents lblConsignee As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents rblLiningType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblLinedBy As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents ddlLiningNo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents rblPL As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents ddlPO As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtQty As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid3 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblSupplier As System.Web.UI.WebControls.Label
    Protected WithEvents txtSetNo As System.Web.UI.WebControls.TextBox
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
                dt = ProductionConsumables.GetLiningType
                rblLiningType.DataSource = dt
                rblLiningType.DataTextField = dt.Columns(1).ColumnName
                rblLiningType.DataValueField = dt.Columns(0).ColumnName
                rblLiningType.DataBind()
                rblLiningType.SelectedIndex = 0
                dt = ProductionConsumables.GetLiningBy
                rblLinedBy.DataSource = dt
                rblLinedBy.DataTextField = dt.Columns(1).ColumnName
                rblLinedBy.DataValueField = dt.Columns(0).ColumnName
                rblLinedBy.DataBind()
                rblLinedBy.SelectedIndex = 0
                SetType()
            End If
        'End If
    End Sub

    Private Sub SetType()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        DataGrid3.DataSource = Nothing
        DataGrid3.DataBind()
        ddlLiningNo.Items.Clear()
        ddlPO.Items.Clear()
        rblPL.Items.Clear()

        Dim dt As DataTable
        Try
            dt = ProductionConsumables.GetFurnaceLiningNos(rblLiningType.SelectedItem.Value, rblLinedBy.SelectedItem.Value)
            If dt.Rows.Count > 0 Then
                ddlLiningNo.DataSource = dt
                ddlLiningNo.DataTextField = dt.Columns(0).ColumnName
                ddlLiningNo.DataValueField = dt.Columns(0).ColumnName
                ddlLiningNo.DataBind()
                ddlLiningNo.SelectedIndex = 0
            Else
                lblMessage.Text = "No Details for the selection !"
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
            GetPLDetails()
            GetSavedPLDetails()
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
    End Sub

    Private Sub GetLiningDetails()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        rblPL.Items.Clear()
        Dim ds As DataSet
        Try
            ds = ProductionConsumables.GetFurnaceLiningDetails(rblLiningType.SelectedItem.Value, ddlLiningNo.SelectedItem.Value)
            DataGrid1.DataSource = ds.Tables(0)
            DataGrid1.DataBind()

            DataGrid2.DataSource = ds.Tables(1)
            DataGrid2.DataBind()

            rblPL.DataSource = ds.Tables(1)
            rblPL.DataTextField = ds.Tables(1).Columns(0).ColumnName
            rblPL.DataValueField = ds.Tables(1).Columns(0).ColumnName
            rblPL.DataBind()
            rblPL.SelectedIndex = 0

        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
    End Sub

    Private Sub GetPLDetails()
        lblSupplier.Text = ""
        ddlPO.Items.Clear()
        Dim dt As DataTable
        Try
            dt = ProductionConsumables.GetFurnaceLiningPLs(rblPL.SelectedItem.Text)
            If dt.Rows.Count > 0 Then
                ddlPO.DataSource = dt
                ddlPO.DataTextField = dt.Columns(0).ColumnName
                ddlPO.DataValueField = dt.Columns(1).ColumnName
                ddlPO.DataBind()
                ddlPO.SelectedIndex = 0
                If rblPL.SelectedItem.Text = "81970791" Then
                    lblSupplier.Text = ddlPO.SelectedItem.Value.Substring(10, ddlPO.SelectedItem.Value.Length - 10)
                Else
                    lblSupplier.Text = ddlPO.SelectedItem.Value.Substring(11, ddlPO.SelectedItem.Value.Length - 11)
                End If
            Else
                lblMessage.Text = "No PODBR Details for PL : " & rblPL.SelectedItem.Text.Trim & " selection ! "
            End If
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        Finally
            dt = Nothing
        End Try
    End Sub

    Private Sub GetSavedPLDetails()
        DataGrid3.DataSource = Nothing
        DataGrid3.DataBind()
        Dim dt As DataTable
        Try
            dt = ProductionConsumables.GetSavedPLs(ddlLiningNo.SelectedItem.Text, rblLiningType.SelectedItem.Value)
            If dt.Rows.Count > 0 Then
                DataGrid3.DataSource = dt
                DataGrid3.DataBind()
            Else
                lblMessage.Text &= " No Saved PL Details for Lining No : " & ddlLiningNo.SelectedItem.Text.Trim & " selection !"
            End If
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        Finally
            dt = Nothing
        End Try
    End Sub

    Private Sub rblLiningType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblLiningType.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            SetType()
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
    End Sub

    Private Sub rblLinedBy_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblLinedBy.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            SetType()
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
    End Sub

    Private Sub rblPL_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblPL.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            GetPLDetails()
            GetSavedPLDetails()
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim Done As Boolean
        lblMessage.Text = ""
        Try
            Done = New ProductionConsumables().SaveFurnaceLiningPLs(rblLiningType.SelectedItem.Value, ddlLiningNo.SelectedItem.Text.Trim, rblPL.SelectedItem.Text, Val(txtQty.Text), ddlPO.SelectedItem.Text, Val(txtSetNo.Text))
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

    Private Sub ddlLiningNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlLiningNo.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            GetLiningDetails()
            GetPLDetails()
            GetSavedPLDetails()
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
    End Sub

    Private Sub ddlPO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlPO.SelectedIndexChanged
        lblMessage.Text = ""
        lblSupplier.Text = ddlPO.SelectedItem.Value.Substring(11, ddlPO.SelectedItem.Value.Length - 11)
    End Sub

    Private Sub DataGrid3_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid3.ItemCommand
        lblMessage.Text = ""
        Try
            Select Case e.CommandName
                Case "Delete"
                    Dim Done As Boolean
                    Dim Group As String = Session("Group")
                    Dim UserId As String = Session("UserID")
                    If Group = "SSMELT" AndAlso UserId = "074510" Then
                        Try
                            Done = New ProductionConsumables().SaveFurnaceLiningPLs(rblLiningType.SelectedItem.Value, ddlLiningNo.SelectedItem.Text.Trim, e.Item.Cells(1).Text.Trim, Val(txtQty.Text), e.Item.Cells(2).Text.Trim, Val(txtSetNo.Text), True)
                            If Done Then
                                GetSavedPLDetails()
                                lblMessage.Text &= "Data deleted !"
                            Else
                                lblMessage.Text &= "Data deletetion failed !"
                            End If
                        Catch exp As Exception
                            lblMessage.Text = exp.Message
                        End Try
                    Else
                        lblMessage.Text = "Data deletetion Not Allowed !"
                    End If
            End Select
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
End Class
