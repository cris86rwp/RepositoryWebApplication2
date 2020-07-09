Public Class PreHeatedLadleReport
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtFrDt As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtToDt As System.Web.UI.WebControls.TextBox
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents btnlLining As System.Web.UI.WebControls.Button
    Protected WithEvents ddlLiningNo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnDetails As System.Web.UI.WebControls.Button
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
            txtFrDt.Text = Now.Date
            txtToDt.Text = Now.Date
            Dim dt As DataTable
            dt = RWF.Melting.GetLadlePreHeatLiningNos
            ddlLiningNo.DataSource = dt
            ddlLiningNo.DataTextField = dt.Columns(0).ColumnName
            ddlLiningNo.DataValueField = dt.Columns(0).ColumnName
            ddlLiningNo.DataBind()
            ddlLiningNo.SelectedIndex = 0
            Try
                GetLadleDetails()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub GetLadleDetails()
        DataGrid1.DataSource = RWF.Melting.GetLiningDetails(ddlLiningNo.SelectedItem.Text)
        DataGrid1.DataBind()
    End Sub

    Private Sub btnDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        Dim Done As Boolean
        lblMessage.Text = ""
        Try
            txtFrDt.Text = CDate(txtFrDt.Text)
            txtToDt.Text = CDate(txtToDt.Text)
        Catch exp As Exception
            lblMessage.Text = exp.Message
            Done = True
        End Try
        If CDate(txtFrDt.Text) > Now.Date Then
            lblMessage.Text = "From Date cannot greater than Today!"
            Exit Sub
        End If
        If CDate(txtToDt.Text) > Now.Date Then
            lblMessage.Text = "To Date cannot greater than Today!"
            Exit Sub
        End If
        If CDate(txtToDt.Text) < CDate(txtFrDt.Text) Then
            lblMessage.Text = "To Date cannot be less than From Date !"
            Exit Sub
        End If

        If Not Done Then
            Dim strPathName As String

            strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=24835&user0=sa&password0=sadev123" &
            "&promptex0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & ", " & CDate(txtFrDt.Text).Day & ", 0,0,0)" &
            "&promptex1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)" &
            "&promptex2=3" &
            "&prompt3=0"
            Response.Redirect(strPathName)
        End If

        'label1.Text = CDate(txtFrDt.Text).Month & "/" & CDate(txtFrDt.Text).Day & "/" & CDate(txtFrDt.Text).Year & " " & "0:0:0"
    End Sub

    Private Sub btnlLining_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlLining.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=24845&user0=sa&password0=sadev123" &
        "&promptex0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & "," & CDate(txtFrDt.Text).Day & " 0,0,0)" &
        "&promptex1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & " 0,0,0)" &
        "&promptex2=" & ddlLiningNo.SelectedItem.Text & "" &
        "&promptex3=1"
        Response.Redirect(strPathName)
    End Sub

    Private Sub ddlLiningNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlLiningNo.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            GetLadleDetails()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
End Class
