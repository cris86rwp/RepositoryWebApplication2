Public Class ChemicalLabNumberChange
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents ddlLabNumber As System.Web.UI.WebControls.DropDownList
    Protected WithEvents dgSavedData As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents lblTestID As System.Web.UI.WebControls.Label
    Protected WithEvents lblMaterialID As System.Web.UI.WebControls.Label
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel

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

        ' Page.Theme = themeValue
        Page.Theme = Session("Theme")
    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None
        'Put user code to initialize the page here
        lblTestID.Visible = False
        lblMaterialID.Visible = False
        If IsPostBack = False Then
            Try
                GetLabNumbers()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
    Private Sub GetLabNumbers()
        ddlLabNumber.Items.Add("Select")
        Dim dt As DataTable
        dt = metLab.tables.GetLabNumbersForChange
        ddlLabNumber.DataSource = dt
        ddlLabNumber.DataValueField = dt.Columns("lab_number").ColumnName
        ddlLabNumber.DataTextField = dt.Columns("Material").ColumnName
        ddlLabNumber.DataBind()
        ddlLabNumber.Items.Insert(0, "Select")
        dt.Dispose()
    End Sub

    Private Sub ddlLabNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlLabNumber.SelectedIndexChanged
        lblMessage.Text = ""
        If ddlLabNumber.SelectedItem.Text = "Select" Then
            lblMessage.Text = "Plase select Lab Number for Change !"
        Else
            FillSavedList()
        End If
    End Sub
    Private Sub FillSavedList()
        Dim dt As DataTable
        dt = metLab.tables.GetMaterialListForChange(ddlLabNumber.SelectedItem.Value)
        dgSavedData.DataSource = dt
        dgSavedData.DataBind()
        dt.Dispose()
        If IsNothing(dgSavedData.CurrentPageIndex) Then dgSavedData.CurrentPageIndex = 0
        If dt.Rows.Count > 10 Then
            dgSavedData.AllowPaging = True
            dgSavedData.PageSize = 10
            dgSavedData.PagerStyle.Mode = PagerMode.NumericPages
        End If
    End Sub
    Private Sub dgSavedData_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgSavedData.PageIndexChanged
        lblMessage.Text = ""
        Try
            dgSavedData.CurrentPageIndex = e.NewPageIndex
            FillSavedList()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        lblMessage.Text = ""
        If ddlLabNumber.SelectedItem.Text = "Select" Then
            lblMessage.Text = "In Valid LabNuber !"
            Exit Sub
        End If
        Dim i, j As Integer
        Dim chkBox As CheckBox
        j = 0
        Try
            For i = 0 To dgSavedData.Items.Count - 1
                chkBox = dgSavedData.Items(i).FindControl("chkMaterialID")
                If chkBox.Checked Then
                    lblTestID.Text = dgSavedData.Items(i).Cells(1).Text
                    lblMaterialID.Text = dgSavedData.Items(i).Cells(2).Text
                    j = j + 1
                End If
            Next
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
        If j <> 1 Then
            lblMessage.Text = "Please select any One Material !"
            Exit Sub
        End If
        Dim Done As Boolean
        Dim oCmd As SqlClient.SqlCommand
        oCmd = rwfGen.Connection.CmdObj
        Try
            oCmd.Parameters.Add("@lab_number", SqlDbType.VarChar, 100).Value = ddlLabNumber.SelectedItem.Value
            oCmd.Parameters.Add("@TestID", SqlDbType.VarChar, 500).Value = lblTestID.Text
            oCmd.Parameters.Add("@MaterialID", SqlDbType.VarChar, 500).Value = lblMaterialID.Text
        Catch exp As Exception
            lblMessage.Text = " InValid Data ! " + exp.Message
            Exit Sub
        End Try
        Try
            oCmd.CommandText = "update ms_test_sample " & _
                 " set test_code = @TestID , lab_code = @MaterialID  " & _
                 " where lab_number = @lab_number "

            If oCmd.Connection.State = ConnectionState.Closed Then oCmd.Connection.Open()
            oCmd.Transaction = oCmd.Connection.BeginTransaction
            If oCmd.ExecuteNonQuery = 1 Then
                Done = True
            Else
                Throw New Exception(" Updation of Chemical Lab Number failed !")
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            If Not IsNothing(oCmd) Then
                If Done Then
                    oCmd.Transaction.Commit()
                    lblMessage.Text = " Updation Successful !"
                Else
                    oCmd.Transaction.Rollback()
                End If
                If oCmd.Connection.State = ConnectionState.Open Then oCmd.Connection.Close()
                oCmd.Dispose()
            End If
        End Try
        If Done Then
            Try
                GetLabNumbers()
            Catch exp As Exception
                lblMessage.Text &= exp.Message
            End Try
        End If
    End Sub
End Class
