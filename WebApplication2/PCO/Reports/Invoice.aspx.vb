Public Class Invoice
    Inherits System.Web.UI.Page
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents ddlRefID As System.Web.UI.WebControls.DropDownList
    Protected WithEvents pnlMrk As System.Web.UI.WebControls.Panel
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents rblGroup As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblInvoice As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents ddlDespatchAdviceNo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnShowReport As System.Web.UI.WebControls.Button
    Protected WithEvents ddlSaleOrders As System.Web.UI.WebControls.DropDownList
    Protected WithEvents pnlWard As System.Web.UI.WebControls.Panel
    Protected WithEvents Panel2 As System.Web.UI.WebControls.Panel
    Protected WithEvents btnExportDetails As System.Web.UI.WebControls.Button
    Protected WithEvents btnShow As System.Web.UI.WebControls.Button
    Protected WithEvents txtToDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFromDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents pnlPCO As System.Web.UI.WebControls.Panel
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


    Protected Sub dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        rblGroup.Visible = True
        If IsPostBack = False Then
            Session("Group") = "PCOPCO"
            txtFromDate.Text = Now.Date
            txtToDate.Text = Now.Date

            rblGroup.ClearSelection()
            Try
                Dim i As Int16
                For i = 0 To rblGroup.Items.Count - 1
                    If rblGroup.Items(i).Text = Session("Group") Then
                        rblGroup.Items(i).Selected = True
                        Exit For
                    End If
                Next
                SetGroup()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub SetGroup()
        pnlMrk.Visible = False
        pnlPCO.Visible = False
        pnlWard.Visible = False
        SavedDespatchAdvices()
        If lblMessage.Text = "No Invoice for printing !" Then Exit Sub
        ReferenceDetails()
        If rblGroup.SelectedItem.Text = "PCOPCO" OrElse rblGroup.SelectedItem.Text = "C&F" Then
            pnlPCO.Visible = True
        ElseIf rblGroup.SelectedItem.Text = "MRKTING" Then
            pnlMrk.Visible = True
        ElseIf rblGroup.SelectedItem.Text = "WARD30" Then
            pnlWard.Visible = True
        End If
    End Sub

    Private Sub SavedDespatchAdvices()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        Try
            Dim dt As DataTable = Marketing.GroupReference(rblGroup.SelectedItem.Text)
            If dt.Rows.Count = 0 Then
                lblMessage.Text = "No Invoice for printing !"
            Else
                If rblGroup.SelectedItem.Text = "PCOPCO" OrElse rblGroup.SelectedItem.Text = "C&F" Then
                    ddlDespatchAdviceNo.DataSource = dt
                    ddlDespatchAdviceNo.DataTextField = dt.Columns(0).ColumnName
                    ddlDespatchAdviceNo.DataValueField = dt.Columns(0).ColumnName
                    ddlDespatchAdviceNo.DataBind()
                ElseIf rblGroup.SelectedItem.Text = "MRKTING" Then
                    ddlRefID.DataSource = dt
                    ddlRefID.DataTextField = dt.Columns(0).ColumnName
                    ddlRefID.DataValueField = dt.Columns(0).ColumnName
                    ddlRefID.DataBind()
                ElseIf rblGroup.SelectedItem.Text = "WARD30" Then
                    ddlSaleOrders.DataSource = dt
                    ddlSaleOrders.DataTextField = dt.Columns(0).ColumnName
                    ddlSaleOrders.DataValueField = dt.Columns(0).ColumnName
                    ddlSaleOrders.DataBind()
                End If
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub ReferenceDetails()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        Try
            Dim dt As DataTable
            If rblGroup.SelectedItem.Text = "PCOPCO" OrElse rblGroup.SelectedItem.Text = "C&F" Then
                dt = Marketing.ReferenceDetails(rblGroup.SelectedItem.Text, ddlDespatchAdviceNo.SelectedItem.Text)
            ElseIf rblGroup.SelectedItem.Text = "MRKTING" Then
                dt = Marketing.ReferenceDetails(rblGroup.SelectedItem.Text, ddlRefID.SelectedItem.Text)
            ElseIf rblGroup.SelectedItem.Text = "WARD30" Then
                dt = Marketing.ReferenceDetails(rblGroup.SelectedItem.Text, ddlSaleOrders.SelectedItem.Text)
            End If
            If dt.Rows.Count = 0 Then
                lblMessage.Text = "No InVoiceNo available for " & ddlDespatchAdviceNo.SelectedItem.Text
            Else
                rblInvoice.DataSource = dt
                rblInvoice.DataTextField = dt.Columns(0).ColumnName
                rblInvoice.DataValueField = dt.Columns(0).ColumnName
                rblInvoice.DataBind()
                rblInvoice.SelectedIndex = 0
                DataGrid1.DataSource = dt
                DataGrid1.DataBind()
                btnShowReport.Text = "Show report for Invoice No : " & rblInvoice.SelectedItem.Text
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub rblInvoice_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblInvoice.SelectedIndexChanged
        lblMessage.Text = ""
        btnShowReport.Text = "Show report for Invoice No : " & rblInvoice.SelectedItem.Text
    End Sub

    Private Sub btnShowReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowReport.Click
        If btnShowReport.Text.StartsWith("Show") Then
            Dim strPathName As String

            If rblGroup.SelectedIndex = 0 Then
                strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?id=25805&apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&user0=sa&password0=sadev123&promptonrefresh=0" &
                        "&prompt0=" & rblGroup.SelectedItem.Value & "" &
                        "&prompt1=" & ddlDespatchAdviceNo.SelectedItem.Value & "" &
                        "&prompt2=" & rblInvoice.SelectedItem.Value & ""

            End If
            Response.Redirect(strPathName)
        Else
            lblMessage.Text = "InValid Selection !"
        End If
    End Sub

    Private Sub ddlSaleOrders_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlSaleOrders.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            ReferenceDetails()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub ddlDespatchAdviceNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlDespatchAdviceNo.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            ReferenceDetails()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub SavedDespatchInvoiceNos()
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        Try
            Dim dt As DataTable
            If rblGroup.SelectedItem.Text = "PCOPCO" OrElse rblGroup.SelectedItem.Text = "C&F" Then
                dt = Marketing.SavedGroupReferences(ddlDespatchAdviceNo.SelectedItem.Value, rblGroup.SelectedItem.Text)
            Else
                dt = Marketing.SavedDespatchInvoiceNos(ddlSaleOrders.SelectedItem.Value, rblGroup.SelectedItem.Text)
            End If
            rblInvoice.DataSource = dt
            rblInvoice.DataTextField = dt.Columns(0).ColumnName
            rblInvoice.DataValueField = dt.Columns(0).ColumnName
            rblInvoice.DataBind()
            rblInvoice.SelectedIndex = 0
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnExportDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportDetails.Click
        If DataGrid2.Items.Count > 0 Then
            Dim prevstate As Boolean = Me.EnableViewState
            Dim tw As New System.IO.StringWriter()
            Dim hw As New System.Web.UI.HtmlTextWriter(tw)
            Try
                Response.ContentType = "application/vnd.ms_excel"
                Response.Charset = ""
                Me.EnableViewState = False
                DataGrid2.RenderControl(hw)
                Response.Write(tw.ToString)
                Response.End()
                Me.EnableViewState = prevstate
            Catch exp As Exception
                lblMessage.Text = exp.Message
            Finally
                prevstate = Nothing
                tw = Nothing
                hw = Nothing
            End Try
        Else
            lblMessage.Text = "No Data in Grid to export !"
        End If
    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        DataGrid2.DataSource = Nothing
        DataGrid2.DataBind()
        lblMessage.Text = ""
        Try
            DataGrid2.DataSource = Marketing.SavedInvoicedetails(rblGroup.SelectedItem.Value, CDate(txtFromDate.Text), CDate(txtToDate.Text))
            DataGrid2.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub ddlRefID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlRefID.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            ReferenceDetails()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
End Class
