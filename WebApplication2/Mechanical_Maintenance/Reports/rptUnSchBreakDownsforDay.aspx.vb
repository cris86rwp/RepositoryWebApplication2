Public Class rptUnSchBreakDownsforDay
    Inherits System.Web.UI.Page
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents lblErr As System.Web.UI.WebControls.Label
    Protected WithEvents txtToDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblGroup As System.Web.UI.WebControls.Label
    Protected WithEvents btnReport As System.Web.UI.WebControls.Button
    Protected WithEvents cboLocation As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnSelected As System.Web.UI.WebControls.Button
    Protected WithEvents lstMachineCode As System.Web.UI.WebControls.ListBox
    Protected WithEvents btnShow As System.Web.UI.WebControls.Button
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
        ' Session("Group") = "AC"
        If Not Page.IsPostBack Then
            lblGroup.Visible = False
            lblGroup.Text = Session("Group")
            txtDate.Text = Format(Now.Date)
            txtToDate.Text = Format(Now.Date)
            Try
                FillDDLShopCode()
                cboLocation.Items.Insert(0, "ALL")
            Catch exp As Exception
                lblErr.Text = exp.Message
            End Try
        End If
    End Sub
    Private Sub PopulateMachineCode()
        Try
            lstMachineCode.Items.Clear()
            lstMachineCode.DataSource = Maintenance.tables.GetUnScheduledEntryMachines(lblGroup.Text, cboLocation.SelectedItem.Text)
            lstMachineCode.DataTextField = "desc1"
            lstMachineCode.DataValueField = "machine_code"
            lstMachineCode.DataBind()
        Catch exp As Exception
            lblErr.Text = exp.Message
        End Try
    End Sub
    Private Sub FillDDLShopCode()
        Dim dt As New DataTable()
        Try
            dt = Maintenance.tables.ShopCode(lblGroup.Text)
            FillDDLs(dt, cboLocation)
        Catch exp As Exception
            Throw New Exception("InValid Filling of DDLs")
        Finally
            dt.Dispose()
        End Try
    End Sub
    Private Sub FillDDLs(ByVal dt As DataTable, ByVal ddl As DropDownList)
        ddl.DataSource = dt.DefaultView
        ddl.DataTextField = dt.Columns(1).ColumnName
        ddl.DataValueField = dt.Columns(0).ColumnName
        ddl.DataBind()
    End Sub
    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        Dim dt, dt1 As Date
        Try
            dt = CDate(txtDate.Text)
            dt1 = CDate(txtToDate.Text)
        Catch
            lblErr.Text = "Enter Date in 'dd/MM/yyyy' Format"
            txtDate.Text = ""
            txtToDate.Text = ""
            Exit Sub
        End Try

        Dim strRptNameWithPath, strRptName As String
        Dim strServer, strPathName As String

        strServer = Server.MachineName
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=27564&user0=sa&password0=sadev123"
        'strPathName &= "&prompt0= DateTime(" & dt.Year & ", " & dt.Month & ", " & dt.Day & ")"
        'strPathName &= "&prompt1= DateTime(" & dt1.Year & ", " & dt1.Month & ", " & dt1.Day & ")"
        strPathName &= "&prompt0= DateTime(" & CStr(CDate(dt).Year) & "," & CStr(CDate(dt).Month) & "," & CStr(CDate(dt).Day) & ", 0,0,0)"
        strPathName &= "&prompt1= DateTime(" & CStr(CDate(dt1).Year) & "," & CStr(CDate(dt1).Month) & "," & CStr(CDate(dt1).Day) & ", 0,0,0)"
        strPathName &= "&prompt2=ALL"
        strPathName &= "&prompt3=ALL"
        strPathName &= "&prompt4=ALL"
        strPathName &= "&prompt5=" & lblGroup.Text.ToUpper
        Response.Redirect(strPathName)
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim dt, dt1 As Date
        Try
            dt = CDate(txtDate.Text)
            dt1 = CDate(txtToDate.Text)
        Catch
            lblErr.Text = "Enter Date in 'dd/MM/yyyy' Format"
            txtDate.Text = ""
            txtToDate.Text = ""
            Exit Sub
        End Try

        Dim strRptNameWithPath, strRptName As String
        Dim strServer, strPathName As String

        strServer = Server.MachineName

        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=27556&user0=sa&password0=sadev123"
        strPathName &= "&prompt0= DateTime(" & CStr(CDate(dt).Year) & "," & CStr(CDate(dt).Month) & "," & CStr(CDate(dt).Day) & ", 0,0,0)"
        strPathName &= "&prompt1= DateTime(" & CStr(CDate(dt1).Year) & "," & CStr(CDate(dt1).Month) & "," & CStr(CDate(dt1).Day) & ", 0,0,0)"
        strPathName &= "&prompt2=ALL"
        strPathName &= "&prompt3=ALL"
        strPathName &= "&prompt4=ALL"
        strPathName &= "&prompt5=" & lblGroup.Text.ToUpper
        Response.Redirect(strPathName)
    End Sub

    Private Sub cboLocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLocation.SelectedIndexChanged
        PopulateMachineCode()
    End Sub

    Private Sub btnSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelected.Click
        Dim dt, dt1 As Date
        Try
            dt = CDate(txtDate.Text)
            dt1 = CDate(txtToDate.Text)
        Catch
            lblErr.Text = "Enter Date in 'dd/MM/yyyy' Format"
            txtDate.Text = ""
            txtToDate.Text = ""
            Exit Sub
        End Try
        Dim i, cnt, SelCnt, ChkCnt As Integer
        Dim mySelectionFormula, strPathName As String
        mySelectionFormula = ""
        SelCnt = 0
        ChkCnt = 0
        For cnt = 0 To lstMachineCode.Items.Count - 1
            If lstMachineCode.Items(cnt).Selected = True Then
                SelCnt = SelCnt + 1
            End If
        Next

        If SelCnt = lstMachineCode.Items.Count Then
            mySelectionFormula = ""
        Else
            For i = 0 To lstMachineCode.Items.Count - 1
                If i = 0 Then
                    mySelectionFormula = ""
                End If
                If lstMachineCode.Items(i).Selected = True Then
                    ChkCnt = ChkCnt + 1
                    mySelectionFormula &= "" & lstMachineCode.Items(i).Value.Trim & ""
                    If ChkCnt = SelCnt Then
                        mySelectionFormula &= ""
                    Else
                        mySelectionFormula &= " , "
                    End If
                End If
            Next
        End If
        Dim strRptNameWithPath, strRptName As String
        Dim strServer As String

        strServer = Server.MachineName

        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=8021&user0=sa&password0=sadev123"
        strPathName &= "&prompt0= DateTime(" & CStr(CDate(dt).Year) & "," & CStr(CDate(dt).Month) & "," & CStr(CDate(dt).Day) & ", 0,0,0)"
        strPathName &= "&prompt1= DateTime(" & CStr(CDate(dt1).Year) & "," & CStr(CDate(dt1).Month) & "," & CStr(CDate(dt1).Day) & ", 0,0,0)"
        strPathName &= "&prompt2=" & Left(cboLocation.SelectedItem.Text.Trim, 2)
        strPathName &= "&prompt3=" & mySelectionFormula
        strPathName &= "&prompt4=" & lblGroup.Text.ToUpper
        Response.Redirect(strPathName)
    End Sub
End Class
