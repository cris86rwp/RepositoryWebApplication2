Public Class rptMachineSubAssemblySpares
    Inherits System.Web.UI.Page
    Protected WithEvents ddlMachineCode As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboLocation As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblMaintenance_group As System.Web.UI.WebControls.Label
    Protected WithEvents btnShowReport As System.Web.UI.WebControls.Button
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents rblStockType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents lsbPLNumber As System.Web.UI.WebControls.ListBox
    Protected WithEvents btnPLReport As System.Web.UI.WebControls.Button
    Protected WithEvents chkSelectAll As System.Web.UI.WebControls.CheckBox
    Protected WithEvents Panel2 As System.Web.UI.WebControls.Panel
    Protected WithEvents rblPlDesc As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnReport As System.Web.UI.WebControls.Button
    Protected WithEvents ddlMachine As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Panel3 As System.Web.UI.WebControls.Panel
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents rblInStore As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button
    Protected WithEvents lblGrp As System.Web.UI.WebControls.Label
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    Shared themeValue As String
    Private strMode As String
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
        'strMode = Request.QueryString("mode")
        Session("group") = "EW1"
        If Session("group") = "RTSHOP" Then
            Session("group") = "MRT"
        End If
        lblGrp.Text = Session("group")
        lblMaintenance_group.Text = lblGrp.Text
        If Not Page.IsPostBack Then
            PopulateLocation()
        End If
    End Sub
    Private Sub PopulateLocation()
        Dim dt As New DataTable()
        Try
            dt = Maintenance.tables.GetLocation(lblMaintenance_group.Text.Trim)
            cboLocation.DataSource = dt.DefaultView
            cboLocation.DataTextField = dt.Columns(1).ColumnName
            cboLocation.DataValueField = dt.Columns(0).ColumnName
            cboLocation.DataBind()
            cboLocation.Items.Insert(0, New ListItem("Select", "0"))
            cboLocation.SelectedIndex = 0
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
        End Try
    End Sub

    Private Sub cboLocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLocation.SelectedIndexChanged
        lblMessage.Text = ""
        PopulateMachineCode()
        PopulatePLList()
    End Sub
    Private Sub PopulatePLList()
        Dim dt As New DataTable()
        lsbPLNumber.Items.Clear()
        Try
            If cboLocation.SelectedItem.Text = "ALL" Then
                dt = Maintenance.tables.GetMachinePLs(lblGrp.Text, "ALL")
            Else
                dt = Maintenance.tables.GetMachinePLs(lblGrp.Text, Trim(cboLocation.SelectedItem.Value))
            End If
            lsbPLNumber.DataSource = dt.DefaultView
            lsbPLNumber.DataValueField = dt.Columns(0).ColumnName
            lsbPLNumber.DataTextField = dt.Columns(1).ColumnName
            lsbPLNumber.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
        End Try
    End Sub
    Private Sub PopulateMachineCode()
        Dim dt As New DataTable()
        ddlMachineCode.Items.Clear()
        Try
            If cboLocation.SelectedItem.Text = "ALL" Then
                dt = Maintenance.tables.GetMachineCodes(lblGrp.Text, "ALL")
            Else
                dt = Maintenance.tables.GetMachineCodes(lblGrp.Text, Trim(cboLocation.SelectedItem.Value))
            End If
            ddlMachineCode.DataSource = dt.DefaultView
            ddlMachineCode.DataValueField = dt.Columns(0).ColumnName
            ddlMachineCode.DataTextField = dt.Columns(1).ColumnName
            ddlMachineCode.DataBind()
            ddlMachineCode.Items.Insert(0, New ListItem("ALL", "0"))
            ddlMachineCode.SelectedIndex = 0

            ddlMachine.DataSource = dt.DefaultView
            ddlMachine.DataValueField = dt.Columns(0).ColumnName
            ddlMachine.DataTextField = dt.Columns(1).ColumnName
            ddlMachine.DataBind()
            ddlMachine.Items.Insert(0, New ListItem("ALL", "0"))
            ddlMachine.SelectedIndex = 0

        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
        End Try
    End Sub

    Private Sub btnShowReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowReport.Click
        Dim strPathName As String
        If rblStockType.SelectedIndex = 0 Then
            If cboLocation.SelectedItem.Text.Trim.ToUpper = "ALL" Then
                If ddlMachineCode.SelectedItem.Text.Trim.ToUpper = "ALL" Then
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=8141&user0=sa&password0=sadev123" &
      lblGrp.Text.Trim & "&prompt1=ALL&promptonrefresh=0"
                Else
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=8141&user0=sa&password0=sadev123" &
      lblGrp.Text.Trim & "&prompt1=" & ddlMachineCode.SelectedItem.Value.Trim & "&promptonrefresh=0"
                End If
            Else
                If ddlMachineCode.SelectedItem.Text.Trim.ToUpper = "ALL" Then
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=8141&user0=sa&password0=sadev123" &
      lblGrp.Text.Trim & "&prompt1=" & cboLocation.SelectedItem.Value.Trim & "&promptonrefresh=0"
                Else
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=8141&user0=sa&password0=sadev123" &
      lblGrp.Text.Trim & "&prompt1=" & ddlMachineCode.SelectedItem.Value.Trim & "&promptonrefresh=0"
                End If
            End If
        Else
            If cboLocation.SelectedItem.Text.Trim.ToUpper = "ALL" Then
                If ddlMachineCode.SelectedItem.Text.Trim.ToUpper = "ALL" Then
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=27589&user0=sa&password0=sadev123" &
     lblGrp.Text.Trim & "&prompt1=ALL&promptonrefresh=0"
                Else
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=27589&user0=sa&password0=sadev123" &
      lblGrp.Text.Trim & "&prompt1=" & ddlMachineCode.SelectedItem.Value.Trim & "&promptonrefresh=0"
                End If
            Else
                If ddlMachineCode.SelectedItem.Text.Trim.ToUpper = "ALL" Then
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=27589&user0=sa&password0=sadev123" &
      lblGrp.Text.Trim & "&prompt1=ALL&promptonrefresh=0"
                Else
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=27589&user0=sa&password0=sadev123" &
      lblGrp.Text.Trim & "&prompt1=" & ddlMachineCode.SelectedItem.Value.Trim & "&promptonrefresh=0"
                End If
            End If
        End If

        Response.Redirect(strPathName)
    End Sub

    Private Sub chkSelectAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSelectAll.CheckedChanged
        lblMessage.Text = ""
        Dim i As Integer
        Try
            If chkSelectAll.Checked Then
                For i = 0 To lsbPLNumber.Items.Count - 1
                    lsbPLNumber.Items(i).Selected = True
                Next
            Else
                For i = 0 To lsbPLNumber.Items.Count - 1
                    lsbPLNumber.Items(i).Selected = False
                Next
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub btnPLReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPLReport.Click
        lblMessage.Text = ""
        Dim i, cnt, SelCnt, ChkCnt As Integer
        Dim mySelectionFormula, strPathName As String

        If chkSelectAll.Checked Then
            mySelectionFormula = ""
        Else
            SelCnt = 0
            ChkCnt = 0
            For cnt = 0 To lsbPLNumber.Items.Count - 1
                If lsbPLNumber.Items(cnt).Selected = True Then
                    SelCnt = SelCnt + 1
                End If
            Next

            If SelCnt = lsbPLNumber.Items.Count Then
                mySelectionFormula = ""
            Else
                For i = 0 To lsbPLNumber.Items.Count - 1
                    If i = 0 Then
                        mySelectionFormula = "{ms_sp_GroupSpares.pl_number} in MakeArray ("
                    End If
                    If lsbPLNumber.Items(i).Selected = True Then
                        ChkCnt = ChkCnt + 1
                        mySelectionFormula &= "'" & lsbPLNumber.Items(i).Value.Trim & "'"
                        If ChkCnt = SelCnt Then
                            mySelectionFormula &= ") "
                        Else
                            mySelectionFormula &= " , "
                        End If
                    End If
                Next
            End If
        End If
        If ddlMachineCode.SelectedItem.Text.Trim.ToUpper = "ALL" Then
            strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?id=27868&apsuser=Administrator&apspassword=Cris@123&apsauthtype=secEnterprise&user0=sa&password0=sadev123&promptonrefresh=0&prompt0=" & lblGrp.Text.Trim & "&prompt1=ALL&promptonrefresh=0"
        Else
            strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?id=27868&apsuser=Administrator&apspassword=Cris@123&apsauthtype=secEnterprise&user0=sa&password0=sadev123&prompt0=" & lblGrp.Text.Trim & "&prompt1=" & ddlMachineCode.SelectedItem.Value.Trim & "&promptonrefresh=0"
        End If
        strPathName &= "&sf=" & mySelectionFormula
        Response.Redirect(strPathName)
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim strPathName As String
        If rblPlDesc.SelectedItem.Text.StartsWith("Com") Then
            strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?id=18320&apsuser=Administrator&apspassword=Cris@123&apsauthtype=secEnterprise&user0=sa&password0=sadev123&prompt0=" & lblGrp.Text.Trim & "&prompt1=" & ddlMachine.SelectedItem.Value.Trim & "&prompt2=A&promptonrefresh=0"
            Response.Redirect(strPathName)
        Else
            strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?id=18327&apsuser=Administrator&apspassword=Cris@123&apsauthtype=secEnterprise&user0=sa&password0=sadev123&prompt0=" & lblGrp.Text.Trim & "&prompt1=" & ddlMachine.SelectedItem.Value.Trim & "&prompt2=" & rblPlDesc.SelectedItem.Value.Trim & "&promptonrefresh=0"
            Response.Redirect(strPathName)
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            DataGrid1.DataSource = Maintenance.tables.SparesInStore(rblInStore.SelectedItem.Value, lblGrp.Text.Trim)
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?id=27890&apsuser=Administrator&apspassword=Cris@123&apsauthtype=secEnterprise&user0=sa&password0=sadev123&promptonrefresh=0&prompt0=" & lblGrp.Text.Trim & "&prompt1=AAA&promptonrefresh=0"
        Response.Redirect(strPathName)
    End Sub
End Class
