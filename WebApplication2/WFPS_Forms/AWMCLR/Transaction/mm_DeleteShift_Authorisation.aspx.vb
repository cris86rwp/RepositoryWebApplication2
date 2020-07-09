Public Class mm_DeleteShift_Authorisation
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
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
        If Page.IsPostBack = False Then
            'Session("UserID") = "073947"
            'Session("Group") = "AWMCLR"
            'If Session("UserID") = "073947" AndAlso Session("Group") = "AWMCLR" Then
            'Else
            '    Response.Redirect("/mms/InvalidSession.aspx")
            '    Exit Sub
            'End If
            Try
                Dim oEmp As New rwfGen.Employee()
                If oEmp.Check(Session("UserID"), Session("Group")) = True Then
                    ShowDataGrid()
                Else
                    Response.Redirect("/mms/InvalidSession.aspx")
                End If
                oEmp = Nothing
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
    Private Sub ShowDataGrid()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            DataGrid1.DataSource = RWF.AWMCLR.GetTop1Data
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub DataGrid1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.ItemCommand
        lblMessage.Text = ""
        Select Case e.CommandName
            Case "Delete"
                Dim Done As Boolean = New RWF.AWMCLR().DeleteContinueShift(CDate(e.Item.Cells(1).Text), e.Item.Cells(2).Text, e.Item.Cells(3).Text, e.Item.Cells(4).Text)
                If Done Then
                    lblMessage.Text = " Updation Successful !"
                Else
                    lblMessage.Text &= " Updation Failed ! "
                End If
        End Select
        ShowDataGrid()
    End Sub
End Class
