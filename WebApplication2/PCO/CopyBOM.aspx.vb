Public Class CopyBOM
    Inherits System.Web.UI.Page
    Protected WithEvents LblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents TxtDesinationProduct As System.Web.UI.WebControls.TextBox
    Protected WithEvents TxtSource As System.Web.UI.WebControls.TextBox
    Protected WithEvents DgSourceBOMList As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DgSourceDetails As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DgDestinationDetails As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DgDestinationBOMList As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents RblProduct As System.Web.UI.WebControls.RadioButtonList

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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Page.IsPostBack = False Then
            Session("UserID") = "073314"
            Try
                Dim oChkEmp As New rwfGen.Employee()
                If oChkEmp.Check(Session("UserID"), "PCOPCO") = False Then
                    Response.Redirect("InvalidSession.aspx")
                End If
                oChkEmp = Nothing
            Catch exp As Exception
                Response.Redirect("InvalidSession.aspx")
            End Try
        End If
    End Sub

    Private Sub SetGrid(ByVal Type As String)
        Dim ds As DataSet
        Try
            If Type.Trim = "Source" Then
                ds = PCO.tables.BOMList(rblProduct.SelectedItem.Value, txtSource.Text.Trim)
                dgSourceBOMList.DataSource = ds.Tables(0)
                dgSourceBOMList.DataBind()
                dgSourceDetails.DataSource = ds.Tables(1)
                dgSourceDetails.DataBind()
                If dgSourceBOMList.Items.Count = 0 Then
                    txtSource.Text = ""
                    Throw New Exception("Source Product is InValid !")
                End If
            Else
                ds = PCO.tables.BOMList(rblProduct.SelectedItem.Value, txtDesinationProduct.Text.Trim)
                dgDestinationBOMList.DataSource = ds.Tables(0)
                dgDestinationBOMList.DataBind()
                dgDestinationDetails.DataSource = ds.Tables(1)
                dgDestinationDetails.DataBind()
                If ds.Tables(0).Rows.Count > 0 Then
                    txtDesinationProduct.Text = ""
                    Throw New Exception("Desination Product has already BOM List !")
                End If
                If ds.Tables(2).Rows.Count = 0 Then
                    txtSource.Text = ""
                    txtDesinationProduct.Text = ""
                    Throw New Exception("CastGroup or Specification of Source and Desination ProductCodes does not match !")
                End If
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub TxtSource_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSource.TextChanged
        LblMessage.Text = ""
        If TxtSource.Text.StartsWith("1") = True OrElse TxtSource.Text.StartsWith("2") = True Then
            LblMessage.Text = "InValid Product Code !"
            TxtSource.Text = ""
            Exit Sub
        End If
        Try
            DgSourceBOMList.DataSource = Nothing
            DgSourceBOMList.DataBind()
            DgSourceDetails.DataSource = Nothing
            DgSourceDetails.DataBind()
            DgDestinationBOMList.DataSource = Nothing
            DgDestinationBOMList.DataBind()
            DgDestinationDetails.DataSource = Nothing
            DgDestinationDetails.DataBind()
            SetGrid("Source")
        Catch exp As Exception
            LblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub TxtDesinationProduct_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDesinationProduct.TextChanged
        LblMessage.Text = ""
        If TxtSource.Text.StartsWith("1") = True OrElse TxtSource.Text.StartsWith("2") = True Then
            LblMessage.Text = "InValid Product Code !"
            TxtSource.Text = ""
            Exit Sub
        End If
        If TxtSource.Text.Trim.Length = 0 Then
            LblMessage.Text = "Please provide Source Code !"
            TxtDesinationProduct.Text = ""
            Exit Sub
        End If
        Try
            DgDestinationBOMList.DataSource = Nothing
            DgDestinationBOMList.DataBind()
            DgDestinationDetails.DataSource = Nothing
            DgDestinationDetails.DataBind()
            SetGrid("Destination")
        Catch exp As Exception
            LblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub RblProduct_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RblProduct.SelectedIndexChanged
        LblMessage.Text = ""
        DgSourceBOMList.DataSource = Nothing
        DgSourceBOMList.DataBind()
        DgSourceDetails.DataSource = Nothing
        DgSourceDetails.DataBind()

        DgDestinationBOMList.DataSource = Nothing
        DgDestinationBOMList.DataBind()
        DgDestinationDetails.DataSource = Nothing
        DgDestinationDetails.DataBind()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        lblMessage.Text = ""
        If txtSource.Text.Trim.Length = 0 Then
            lblMessage.Text = "Please provide Source Code !"
            txtSource.Text = ""
            Exit Sub
        End If
        If txtDesinationProduct.Text.Trim.Length = 0 Then
            lblMessage.Text = "Please provide Desination Code !"
            txtDesinationProduct.Text = ""
            Exit Sub
        End If
        Dim Done As Boolean
        Try
            Done = New PCO.PCO().CopyBOM(txtSource.Text.Trim, txtDesinationProduct.Text.Trim)
            SetGrid("Destination")
            If Done Then lblMessage.Text &= "  Copied New BOM "
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        Done = Nothing
    End Sub
End Class
