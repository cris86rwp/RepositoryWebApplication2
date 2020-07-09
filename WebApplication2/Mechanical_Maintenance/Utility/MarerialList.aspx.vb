Public Class MarerialList
    Inherits System.Web.UI.Page
    Protected WithEvents lblApp As System.Web.UI.WebControls.Label
    Protected WithEvents lblGroup As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtEquipmentName As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblEquipCount As System.Web.UI.WebControls.Label
    Protected WithEvents ckbRefersh As System.Web.UI.WebControls.CheckBox
    Protected WithEvents ddlEuipmentID As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtUnit As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblFailureId As System.Web.UI.WebControls.Label
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents lblConsignee As System.Web.UI.WebControls.Label
    Protected WithEvents lblUserId As System.Web.UI.WebControls.Label
    Dim InValid As Boolean
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    Shared themeValue As String
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
    Private Sub Page_PreInit(ByVal sender As Object, ByVal e As EventArgs)

        Page.Theme = themeValue
    End Sub
    Public Sub New()

        AddHandler PreInit, New EventHandler(AddressOf Page_PreInit)
    End Sub
    Protected Sub dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        lblFailureId.Visible = True
        lblGroup.Visible = False
        lblApp.Visible = False
        lblUserId.Visible = False
        If IsPostBack = False Then
            If Session("Group") = "RTSHOP" Then
                Session("group") = "MRT"
            End If
            'Session("UserID") = "077243"
            Session("Apps") = "MSS"
            'Session("Group") = "MA2"
            ViewState("saveMode") = "add"
            lblGroup.Text = Session("Group")
            lblApp.Text = Session("Apps")
            lblUserId.Text = Session("UserID")
            Try
                lblConsignee.Text = CriticalItems.ItemTables.GetConsignee(lblGroup.Text, lblUserId.Text)
                If lblConsignee.Text.Trim.Length = 4 Then InValid = True
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            If Not InValid Then
                'Response.Redirect("/wap/logon.aspx")
            End If
            Try
                SentenceIDs()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
    Private Sub SentenceIDs()
        Dim dt As New DataTable()
        Try
            dt = Maintenance.ElecTables.GetSentenceIDs(lblApp.Text, lblConsignee.Text)
            ddlEuipmentID.DataSource = dt.DefaultView
            ddlEuipmentID.DataTextField = dt.Columns("Sentence").ColumnName
            ddlEuipmentID.DataValueField = dt.Columns("sentenceId").ColumnName
            ddlEuipmentID.DataBind()
            ddlEuipmentID.Items.Insert(0, "select")
            ddlEuipmentID.Enabled = True
            ddlEuipmentID.SelectedIndex = 0
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub txtEquipmentName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEquipmentName.TextChanged
        Dim strEquip As String
        lblMessage.Text = ""
        lblEquipCount.Text = ""
        Clear()
        If CType(viewstate("saveMode"), String).ToLower = "add" Then
            lblFailureId.Text = ""
        End If
        Dim Equip As Array
        If txtEquipmentName.Text.Trim.Length <= 0 Then
            lblMessage.Text = "Please fill search string "
            Exit Sub
        Else
            Dim dt As New DataTable()
            Try
                Equip = Split(txtEquipmentName.Text.Trim, " ")
                Dim i As Integer
                For i = 0 To Equip.Length - 1
                    If i = 0 Then
                        strEquip = " word like  (  '%" & Equip(i) & "%' ) "
                    Else
                        strEquip &= " or word like ( '%" & Equip(i) & "%' ) "
                    End If
                Next
                dt = Maintenance.ElecTables.GetSentenceIDs(lblApp.Text, lblConsignee.Text, txtEquipmentName.Text)
                'dt = Maintenance.ElecTables.GetSentenceIDs(lblApp.Text, lblConsignee.Text, strEquip.Trim)
                ddlEuipmentID.DataSource = dt.DefaultView
                ddlEuipmentID.DataTextField = dt.Columns("Sentence").ColumnName
                ddlEuipmentID.DataValueField = dt.Columns("sentenceId").ColumnName
                ddlEuipmentID.DataBind()
                ddlEuipmentID.Items.Insert(0, "select")
                lblEquipCount.Text = dt.Rows.Count
                ddlEuipmentID.SelectedIndex = 0
                ddlEuipmentID.Enabled = True
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If

    End Sub
    Private Sub ckbRefersh_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbRefersh.CheckedChanged
        txtEquipmentName.Text = ""
        lblMessage.Text = ""
        Clear()
        Try
            SentenceIDs()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub ddlEuipmentID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlEuipmentID.SelectedIndexChanged
        lblMessage.Text = ""
        If CType(viewstate("saveMode"), String).ToLower = "add" Then
            lblFailureId.Text = ""
        End If
        If ddlEuipmentID.SelectedIndex > 0 Then
            lblFailureId.Text = SubStoreStock.Tables.GetMListNumber(ddlEuipmentID.SelectedItem.Value, lblConsignee.Text.Trim)
        Else
            lblMessage.Text = "Please Key-In Equipment Name"
        End If
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblMessage.Text = ""
        Dim blnDone As Boolean
        Dim MList As New SubStoreStock.StockMaster()
        Try
            If ddlEuipmentID.SelectedIndex = 0 AndAlso txtEquipmentName.Text.Trim.Length > 0 Then
                Dim Equip As Array
                Dim i, j, k As Integer
                Dim dt As New DataTable()
                Dim dr As DataRow

                Try
                    k = Maintenance.ElecTables.MaxSentenceID(lblApp.Text, lblGroup.Text) + 1
                    Equip = Split(txtEquipmentName.Text.Trim, " ")
                    dt.TableName = "Equip"
                    dt.Columns.Add("Word")
                    dt.Columns.Add("WordSeqID")
                    dt.Columns.Add("sentenceId")
                    For i = 0 To Equip.Length - 1
                        j = i + 1
                        dr = dt.NewRow
                        dr("Word") = Equip(i)
                        dr("WordSeqID") = j
                        dr("sentenceId") = k
                        dt.Rows.Add(dr)
                    Next
                    MList.EquipmentList = dt
                    MList.EquipmentID = k
                Catch exp As Exception
                    lblMessage.Text = exp.Message
                Finally
                    dt.Dispose()
                End Try
            Else
                MList.EquipmentID = ddlEuipmentID.SelectedItem.Value
            End If
            MList.Application = lblApp.Text.Trim
            MList.GroupCode = lblConsignee.Text.Trim
            MList.Unit = txtUnit.Text.Trim
            Select Case CType(viewstate("saveMode"), String).ToLower
                Case "add"
                    If MList.SaveMaterialList() Then lblMessage.Text = " Generated Material ID : " & MList.pl_number & " successfully ! "
                Case "update"
                    'If Eqp.SaveEquipmentFailure(Eqp.FailureID) Then lblMessage.Text = " Updated Failure ID : " & Eqp.FailureID & " successfully ! "
                Case "delete"
                    'If Eqp.SaveEquipmentFailure(Eqp.FailureID, True) Then lblMessage.Text = " Deleted Failure ID : " & Eqp.FailureID & " successfully ! "
            End Select
            lblFailureId.Text = MList.pl_number
            SentenceIDs()
            Clear()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub Clear()
        ddlEuipmentID.ClearSelection()
        ddlEuipmentID.SelectedIndex = 0
        ddlEuipmentID.Enabled = True
        lblFailureId.Text = ""
        txtUnit.Text = ""
    End Sub

End Class
