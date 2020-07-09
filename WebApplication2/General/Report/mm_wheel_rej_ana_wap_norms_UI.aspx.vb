Public Class mm_wheel_rej_ana_wap_norms_UI
    Inherits System.Web.UI.Page
    Protected WithEvents BtnShow As System.Web.UI.WebControls.Button
    Protected WithEvents lblProductType As System.Web.UI.WebControls.Label
    Protected WithEvents rfvld1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents ddlProduct As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList



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
        'Response.Redirect("http://reportserver/mmsreports/cmtwhl/mm_wheel_rej_ana_wap_norms_UI.aspx")
        Panel1.Visible = True
    End Sub

    Private Sub BtnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShow.Click
        Dim done As Boolean
        Try
            done = New RWF.Magna().GenerateRWFNormsData(CDate(txtDate.Text), ddlProduct.SelectedItem.Text.Trim)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If done Then
            Dim strPathName As String
            strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?id=8277&apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&user0=sa&password0=sadev123&promptonrefresh=0" &
                    "&prompt0=" & ddlProduct.SelectedItem.Text.Trim & "" &
                    "&prompt1=DateTime(" & CStr(CDate(txtDate.Text).Year) & "," & CStr(CDate(txtDate.Text).Month) & "," & CStr(CDate(txtDate.Text).Day) & ", 00, 00, 00)"
            Response.Redirect(strPathName)
        Else
            lblMessage.Text &= "Error in Data ! "
        End If
    End Sub

    Private Sub FillddlProductForGeneration()
        Dim dt As DataTable
        ddlProduct.Items.Clear()
        Try
            dt = RWF.MagnaQuerryDetails.GetProductType(CDate(txtDate.Text))
            ddlProduct.DataSource = dt
            ddlProduct.DataTextField = dt.Columns(0).ColumnName
            ddlProduct.DataValueField = dt.Columns(0).ColumnName
            ddlProduct.DataBind()
            ddlProduct.Items.Add("Total")
            ddlProduct.ClearSelection()
            Dim i As Integer
            i = 0
            For i = 0 To ddlProduct.Items.Count - 1
                If ddlProduct.Items(i).Text = "Total" Then
                    ddlProduct.Items(i).Selected = True
                End If
            Next
        Catch exp As Exception
            lblMessage.Text = " Retrival of WhlType Details List " & exp.Message
        Finally
            dt.Dispose()
        End Try
    End Sub

    Private Sub txtDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged
        Try
            Dim dt As Date
            dt = CDate(txtDate.Text)
            FillddlProductForGeneration()
        Catch
            lblMessage.Text = "Enter date in 'dd/mm/yyyy' Format"
            txtDate.Text = ""
        End Try
    End Sub
End Class
