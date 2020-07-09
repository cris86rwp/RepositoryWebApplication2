Public Class ChemicalTestReport
    Inherits System.Web.UI.Page
    Protected WithEvents rblGroup As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents ddlLabNumber As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents Panel2 As System.Web.UI.WebControls.Panel
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents rblDBRList As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents TextBox1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button
    Protected WithEvents lsbDBR As System.Web.UI.WebControls.ListBox
    Protected WithEvents Button3 As System.Web.UI.WebControls.Button
    Protected WithEvents Panel3 As System.Web.UI.WebControls.Panel
    Protected WithEvents Button4 As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents rblSand As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList



    Shared themeValue As String

    Public Sub New()

        AddHandler PreInit, New EventHandler(AddressOf Page_PreInit)
    End Sub
    Protected Sub Dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub


    Private Sub Page_PreInit(ByVal sender As Object, ByVal e As EventArgs)

        ' Page.Theme = themeValue
        Page.Theme = Session("Theme")
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
        'Put user code to initialize the page here
        Session("Group") = "STORES"
        If Session("Group") = "STORES" Then
            Panel2.Visible = True
        Else
            Panel2.Visible = False
        End If
        If Page.IsPostBack = False Then
            Session("Group") = "STORES"
            Try
                GetData()
                GetLabNumbers(rblGroup.SelectedItem.Value)
                GetDBRList()
                GetDBRDetails()
                GetSandDBRDetails()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
    Private Sub GetDBRDetails()
        Dim dt As DataTable
        Try
            dt = metLab.tables.DBRDetails(rblDBRList.SelectedItem.Text)
            DataGrid1.DataSource = dt
            DataGrid1.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub GetSandDBRDetails()
        Dim dt As DataTable
        Try
            dt = metLab.tables.SandDBRDetails(rblSand.SelectedItem.Text)
            DataGrid2.DataSource = dt
            DataGrid2.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub GetDBRList()
        Dim dt As DataTable
        Try
            dt = metLab.tables.DBRList
            rblDBRList.DataSource = dt
            rblDBRList.DataTextField = dt.Columns("dbr_number").ColumnName
            rblDBRList.DataValueField = dt.Columns("dbr_number").ColumnName
            rblDBRList.DataBind()
            rblDBRList.SelectedIndex = 0

            lsbDBR.DataSource = dt
            lsbDBR.DataTextField = dt.Columns("dbr_number").ColumnName
            lsbDBR.DataValueField = dt.Columns("dbr_number").ColumnName
            lsbDBR.DataBind()

            dt = metLab.tables.SandDBRList
            rblSand.DataSource = dt
            rblSand.DataTextField = dt.Columns("dbr_number").ColumnName
            rblSand.DataValueField = dt.Columns("dbr_number").ColumnName
            rblSand.DataBind()
            rblSand.SelectedIndex = 0

        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub GetData()
        Dim dt As DataTable
        Try
            dt = metLab.tables.MaterialListGroup(Session("Group"))
            rblGroup.DataSource = dt
            rblGroup.DataTextField = dt.Columns("Material").ColumnName
            rblGroup.DataValueField = dt.Columns("MaterialID").ColumnName
            rblGroup.DataBind()
            rblGroup.SelectedIndex = 0
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub
    Private Sub GetLabNumbers(ByVal MaterialID As Integer)
        Dim dt As DataTable
        Try
            dt = metLab.tables.MaterialLabNumbers(MaterialID)
            ddlLabNumber.DataSource = dt
            ddlLabNumber.DataTextField = dt.Columns(0).ColumnName
            ddlLabNumber.DataValueField = dt.Columns(0).ColumnName
            ddlLabNumber.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub rblGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblGroup.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            GetLabNumbers(rblGroup.SelectedItem.Value)
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=18415&user0=sa&password0=sadev123" &
      "&prompt0=" & Trim(ddlLabNumber.SelectedItem.Text) & "&prompt1=" & 0 & ""
        strPathName &= "&user0@TestSampleResultsRemarks.rpt=sa&password0@TestSampleResultsRemarks.rpt=sadev123"
        Response.Redirect(strPathName)
    End Sub

    Private Sub rblDBRList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblDBRList.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            GetDBRDetails()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim strServer, strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=27460&user0=sa&password0=sadev123&promptonrefresh=0& prompt0=" & Trim(rblDBRList.SelectedItem.Text) & "&prompt1=" & Val(TextBox1.Text) & ""
        strPathName &= "&prompt2=" & 0 & "&prompt3=''"
        Response.Redirect(strPathName)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        lblMessage.Text = ""
        Dim i, cnt, SelCnt, ChkCnt As Integer
        Dim mySelectionFormula, strPathName As String
        Dim strRptNameWithPath, strRptName As String
        Dim strServer As String

        SelCnt = 0
        ChkCnt = 0
        For cnt = 0 To lsbDBR.Items.Count - 1
            If lsbDBR.Items(cnt).Selected = True Then
                SelCnt = SelCnt + 1
            End If
        Next
        If SelCnt = 0 Then
            mySelectionFormula = ""
            lblMessage.Text = "DBR Number selection cannot be empty !"
            Exit Sub
        ElseIf SelCnt = lsbDBR.Items.Count Then
            mySelectionFormula = ""
        Else
            For i = 0 To lsbDBR.Items.Count - 1
                If i = 0 Then
                    mySelectionFormula = ""
                End If
                If lsbDBR.Items(i).Selected = True Then
                    ChkCnt = ChkCnt + 1
                    mySelectionFormula &= "" & lsbDBR.Items(i).Value.Trim & ""
                    If ChkCnt = SelCnt Then
                        mySelectionFormula &= " "
                    Else
                        mySelectionFormula &= " , "
                    End If
                End If
            Next
        End If

        strServer = Server.MachineName

        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=18439&user0=sa&password0=sadev123&promptonrefresh=0 &prompt0=''&prompt1=''"
        strPathName &= "&prompt2=" & 1 & "&prompt3=" & mySelectionFormula
        Response.Redirect(strPathName)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim strServer, strPathName As String
        strServer = Server.MachineName
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=18544&user0=sa&password0=sadev123 &prompt0=" & Trim(rblSand.SelectedItem.Text) & "&prompt1='0'"
        Response.Redirect(strPathName)
    End Sub

    Private Sub rblSand_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblSand.SelectedIndexChanged
        lblMessage.Text = ""
        Try
            GetSandDBRDetails()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
    End Sub

End Class
