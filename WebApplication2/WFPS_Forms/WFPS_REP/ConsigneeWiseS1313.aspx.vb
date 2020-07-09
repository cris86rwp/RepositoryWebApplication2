Public Class ConsigneeWiseS1313
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtFromDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtToDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnProductNo As System.Web.UI.WebControls.Button
    Protected WithEvents CustomValidator1 As System.Web.UI.WebControls.CustomValidator
    Protected WithEvents pnlProductNo As System.Web.UI.WebControls.Panel
    Protected WithEvents lblConsignee As System.Web.UI.WebControls.Label
    Protected WithEvents ddlPLNumber As System.Web.UI.WebControls.DropDownList
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
    Dim Notvalid As Boolean
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If IsPostBack = False Then
            Notvalid = False
            txtFromDate.Text = Now.Date
            txtToDate.Text = Now.Date
            Session("Group") = "ssmold"
            Session("UserID") = "073533"
            Dim Group As String = Session("Group")
            Dim UserId As String = Session("UserID")
            Dim InValid As Boolean = False
            Dim dt As New DataTable()
            Try
                lblConsignee.Text = CriticalItems.ItemTables.GetConsignee(Group, UserId)
                If lblConsignee.Text.Trim.Length = 4 Then InValid = True
                dt = CriticalItems.ItemTables.GetS1313Pls(lblConsignee.Text.Trim)
                ddlPLNumber.DataSource = dt.DefaultView
                ddlPLNumber.DataTextField = dt.Columns(1).ColumnName
                ddlPLNumber.DataValueField = dt.Columns(0).ColumnName
                ddlPLNumber.DataBind()
                ddlPLNumber.Items.Insert(0, "ALL")
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
            'If Not InValid Then
            '    Response.Redirect("/wap/logon.aspx")
            'End If
        End If
    End Sub

    Private Sub btnProductNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProductNo.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=26675&user0=sa&password0=sadev123" &
      lblConsignee.Text.Trim & "&prompt1=DateTime(" & Format(CDate(txtFromDate.Text), "yyyy,MM,dd ,00, 00, 00") & ")&prompt2=DateTime(" & Format(CDate(txtToDate.Text), "yyyy,MM,dd ,00, 00, 00") & ")&prompt3=" & ddlPLNumber.SelectedItem.Value.Trim & ""
        Response.Redirect(strPathName)
    End Sub
    Private Sub clear()
        lblMessage.Text = ""
        txtFromDate.Text = ""
        txtToDate.Text = ""
    End Sub

    Private Sub CustomValidator1_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CustomValidator1.ServerValidate
        lblMessage.Text = ""
        Dim dt1, dt2 As Date
        Dim dt1IsValid, dt2IsValid As Boolean
        dt1IsValid = False
        dt2IsValid = False
        Try
            dt1 = txtFromDate.Text.Trim
            dt1IsValid = True
            dt2 = txtToDate.Text.Trim
            dt2IsValid = True
            If dt1 > Today.Date Then
                lblMessage.Text = "From Date:'" & txtFromDate.Text.Trim & "' Can Not Be Greater Than Current Date. "
                txtFromDate.Text = ""
            End If

            If dt2 > Today.Date Then
                lblMessage.Text &= "To Date:'" & txtToDate.Text.Trim & "' Can Not Be Greater Than Current Date. "
                txtToDate.Text = ""
            End If

            If dt1 > dt2 Then
                lblMessage.Text &= " From Date is more than To Date ! (From Date:" & txtFromDate.Text & " To Date: " & txtToDate.Text & "). "
                txtFromDate.Text = ""
                txtToDate.Text = ""
            End If

        Catch exp As Exception
            If exp.Message.StartsWith("Cast") Then
                If dt1IsValid = False Then
                    lblMessage.Text &= " From Date:'" & txtFromDate.Text.Trim & "'  is not Valid. "
                    txtFromDate.Text = ""
                ElseIf dt2IsValid = False Then
                    lblMessage.Text &= " To Date:'" & txtToDate.Text.Trim & "'  is not Valid. "
                    txtToDate.Text = ""
                End If
            End If
        End Try
        If txtFromDate.Text = "" Or txtToDate.Text = "" Then
            Notvalid = True
        End If
    End Sub

    Private Sub txtFromDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFromDate.TextChanged
        lblMessage.Text = ""
    End Sub

End Class
