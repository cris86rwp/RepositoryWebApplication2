Public Class ProdRefractoryLining
    Inherits System.Web.UI.Page
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents txtFrDt As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtToDt As System.Web.UI.WebControls.TextBox
    Protected WithEvents rblLiningType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents pnl1 As System.Web.UI.WebControls.Panel
    Protected WithEvents rblFur As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnFWP As System.Web.UI.WebControls.Button
    Protected WithEvents rblFWPType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents ddlLiningNo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnLiningNo As System.Web.UI.WebControls.Button
    Protected WithEvents pnl3 As System.Web.UI.WebControls.Panel
    Protected WithEvents ddlLiningNo3 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnlLiningNo3 As System.Web.UI.WebControls.Button
    Protected WithEvents rblLiningItemNo As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblLRLType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnLRL As System.Web.UI.WebControls.Button
    Protected WithEvents ddlPONo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnPONo As System.Web.UI.WebControls.Button
    Protected WithEvents pnl4 As System.Web.UI.WebControls.Panel
    Protected WithEvents rblRoofNo As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnRRL As System.Web.UI.WebControls.Button
    Protected WithEvents rblRRLType As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents btnGen As System.Web.UI.WebControls.Button
    Protected WithEvents ddlLOANo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnLOANo As System.Web.UI.WebControls.Button
    Protected WithEvents pnlMain As System.Web.UI.WebControls.Panel
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
            Dim Group As String = Session("Group")
            Dim UserId As String = Session("UserID")
            Dim InValid As Boolean = False
            ''''''''''''''''
            Group = "SSMELT"
            UserId = "074510"
            ''''''''''''''''
            'Try
            '    If ProductionConsumables.GetConsignee(Group, UserId).Trim.Length = 4 Then InValid = True
            'Catch exp As Exception
            '    lblMessage.Text = exp.Message
            'End Try
            'If Not InValid Then
            '    Response.Redirect("/mss/logon.aspx")
            'Else
            txtFrDt.Text = Now.Date
            txtToDt.Text = Now.Date
            Dim dt As DataTable
            Dim ds As DataSet
            dt = ProductionConsumables.GetLiningType 'GetLiningNos
            rblLiningType.DataSource = dt
            rblLiningType.DataTextField = dt.Columns(1).ColumnName
            rblLiningType.DataValueField = dt.Columns(0).ColumnName
            rblLiningType.DataBind()
            rblLiningType.SelectedIndex = 0
            ds = ProductionConsumables.GetLiningNos
            ddlLiningNo.DataSource = ds.Tables(0)
            ddlLiningNo.DataTextField = ds.Tables(0).Columns(0).ColumnName
            ddlLiningNo.DataValueField = ds.Tables(0).Columns(0).ColumnName
            ddlLiningNo.DataBind()
            ddlLiningNo.SelectedIndex = 0
            ddlLiningNo3.DataSource = ds.Tables(1)
            ddlLiningNo3.DataTextField = ds.Tables(1).Columns(0).ColumnName
            ddlLiningNo3.DataValueField = ds.Tables(1).Columns(0).ColumnName
            ddlLiningNo3.DataBind()
            ddlLiningNo3.SelectedIndex = 0
            dt = ProductionConsumables.GetLiningItems("LadleNo")
            rblLiningItemNo.DataSource = dt
            rblLiningItemNo.DataTextField = dt.Columns(0).ColumnName
            rblLiningItemNo.DataValueField = dt.Columns(0).ColumnName
            rblLiningItemNo.DataBind()
            rblLiningItemNo.Items.Add("ALL")
            rblLiningItemNo.SelectedIndex = 0
            dt = ProductionConsumables.GetLiningItems("RoofNo")
            rblRoofNo.DataSource = dt
            rblRoofNo.DataTextField = dt.Columns(0).ColumnName
            rblRoofNo.DataValueField = dt.Columns(0).ColumnName
            rblRoofNo.DataBind()
            rblRoofNo.Items.Add("ALL")
            rblRoofNo.SelectedIndex = 0
            dt = ProductionConsumables.GetLiningItems("LOA")
            ddlLOANo.DataSource = dt
            ddlLOANo.DataTextField = dt.Columns(0).ColumnName
            ddlLOANo.DataValueField = dt.Columns(0).ColumnName
            ddlLOANo.DataBind()
            ddlLOANo.SelectedIndex = 0
            dt = Nothing
            ds = Nothing
            SetType()
        End If
        'End If
    End Sub

    Private Sub SetType()
        pnl1.Visible = False
        pnl3.Visible = False
        pnl4.Visible = False
        If rblLiningType.SelectedItem.Value = 1 Then
            pnl1.Visible = True
        ElseIf rblLiningType.SelectedItem.Value = 3 Then
            pnl3.Visible = True
        ElseIf rblLiningType.SelectedItem.Value = 4 Then
            pnl4.Visible = True
        End If
        Try
            GetPOs()
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
    End Sub

    Private Sub GetPOs()
        Dim dt As DataTable
        dt = ProductionConsumables.GetLiningPOs(rblLiningType.SelectedItem.Value)
        ddlPONo.DataSource = dt
        ddlPONo.DataTextField = dt.Columns(0).ColumnName
        ddlPONo.DataValueField = dt.Columns(1).ColumnName
        ddlPONo.DataBind()
        ddlPONo.SelectedIndex = 0
        dt = Nothing
    End Sub

    Private Sub btnFWP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFWP.Click
        Dim Done As Boolean
        lblMessage.Text = ""
        Try
            txtFrDt.Text = CDate(txtFrDt.Text)
            txtToDt.Text = CDate(txtToDt.Text)
        Catch exp As Exception
            lblMessage.Text = exp.Message
            Done = True
        End Try
        If CDate(txtFrDt.Text) < CDate("01-05-2015") Then
            lblMessage.Text = "From Date cannot be less than May'2015 !"
            Exit Sub
        End If
        If CDate(txtToDt.Text) < CDate(txtFrDt.Text) Then
            lblMessage.Text = "To Date cannot be less than From Date !"
            Exit Sub
        End If
        If Not Done Then
            Dim strPathName As String
            Select Case rblFWPType.SelectedItem.Value
                Case 1
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=24864&user0=sa&password0=sadev123" &
                    "&prompt0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & "," & CDate(txtFrDt.Text).Day & ", 0,0,0)" &
                    "&prompt1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)" &
                    "&prompt2=" & rblFur.SelectedItem.Text & "" &
                    "&prompt3=" & rblFWPType.SelectedItem.Value & ""
                Case Else
                    Exit Sub
            End Select
            Response.Redirect(strPathName)
        End If
    End Sub

    Private Sub rblLiningType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblLiningType.SelectedIndexChanged
        lblMessage.Text = ""
        SetType()
    End Sub

    Private Sub btnLiningNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLiningNo.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=16401&user0=sa&password0=sadev123" &
        "&prompt0=" & ddlLiningNo.SelectedItem.Value & "" &
        "&prompt1=1" &
        "&user0@SubReport1.rpt=report&password0@SubReport1.rpt=report" &
        "&user0@SubReport2.rpt=report&password0@SubReport2.rpt=report" &
        "&user0@SubReport3.rpt=report&password0@SubReport3.rpt=report"
        Response.Redirect(strPathName)
    End Sub

    Private Sub btnlLiningNo3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlLiningNo3.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=16724&user0=sa&password0=sadev123" &
        "&prompt0=" & ddlLiningNo3.SelectedItem.Value & "" &
        "&prompt1=1" &
        "&user0@SubReport1.rpt=report&password0@SubReport1.rpt=report" &
        "&user0@SubReport2.rpt=report&password0@SubReport2.rpt=report"
        Response.Redirect(strPathName)
    End Sub

    Private Sub btnLRL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLRL.Click
        Dim Done As Boolean
        lblMessage.Text = ""
        Try
            txtFrDt.Text = CDate(txtFrDt.Text)
            txtToDt.Text = CDate(txtToDt.Text)
        Catch exp As Exception
            lblMessage.Text = exp.Message
            Done = True
        End Try
        If CDate(txtFrDt.Text) < CDate("01-04-2015") Then
            lblMessage.Text = "From Date cannot be less than April '2015 !"
            Exit Sub
        End If
        If CDate(txtToDt.Text) < CDate(txtFrDt.Text) Then
            lblMessage.Text = "To Date cannot be less than From Date !"
            Exit Sub
        End If
        If Not Done Then
            Dim strPathName As String
            Select Case rblFWPType.SelectedItem.Value
                Case 1
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=13656&user0=sa&password0=sadev123" &
                    "&prompt0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & "," & CDate(txtFrDt.Text).Day & ", 0,0,0)" &
                    "&prompt1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)" &
                    "&prompt2=" & rblLiningItemNo.SelectedItem.Text & "" &
                    "&prompt3=" & rblLRLType.SelectedItem.Value & "" &
                    "&user0@SubReport.rpt=report&password0@SubReport.rpt=report"
                Case Else
                    Exit Sub
            End Select
            Response.Redirect(strPathName)
        End If
    End Sub

    Private Sub btnPONo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPONo.Click
        lblMessage.Text = ""
        Try
            If Not ProductionConsumables.CheckFurnacePODetailsData(rblLiningType.SelectedItem.Value, ddlPONo.SelectedItem.Value) Then
                lblMessage.Text = "No generated data for the said PO , Generate data and then view report !"
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        If lblMessage.Text.StartsWith("No") Then Exit Sub
        Dim strPathName As String
        Dim PO As Int16 = rblLiningType.SelectedItem.Value
        If PO = 1 OrElse PO = 2 Then
            strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=24874&user0=sa&password0=sadev123" &
            "&prompt0=" & rblLiningType.SelectedItem.Value & "" &
            "&prompt1=" & ddlPONo.SelectedItem.Value & "" &
            "&prompt2=0"
        ElseIf PO = 3 OrElse PO = 4 Then
            strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=13656&user0=sa&password0=sadev123" &
            "&prompt0=" & rblLiningType.SelectedItem.Value & "" &
            "&prompt1=" & ddlPONo.SelectedItem.Value & "" &
            "&prompt2=0" &
            "&user0@SubReport1.rpt=report&password0@SubReport1.rpt=report"
        Else
            Exit Sub
        End If
        Response.Redirect(strPathName)
    End Sub

    Private Sub btnRRL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRRL.Click
        Dim Done As Boolean
        lblMessage.Text = ""
        Try
            txtFrDt.Text = CDate(txtFrDt.Text)
            txtToDt.Text = CDate(txtToDt.Text)
        Catch exp As Exception
            lblMessage.Text = exp.Message
            Done = True
        End Try
        If CDate(txtFrDt.Text) < CDate("01-04-2015") Then
            lblMessage.Text = "From Date cannot be less than April '2015 !"
            Exit Sub
        End If
        If CDate(txtToDt.Text) < CDate(txtFrDt.Text) Then
            lblMessage.Text = "To Date cannot be less than From Date !"
            Exit Sub
        End If
        If Not Done Then
            Dim strPathName As String
            Select Case rblFWPType.SelectedItem.Value
                Case 1
                    strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=16739&user0=sa&password0=sadev123" &
                    "&prompt0=DateTime(" & CDate(txtFrDt.Text).Year & "," & CDate(txtFrDt.Text).Month & "," & CDate(txtFrDt.Text).Day & ", 0,0,0)" &
                    "&prompt1=DateTime(" & CDate(txtToDt.Text).Year & "," & CDate(txtToDt.Text).Month & "," & CDate(txtToDt.Text).Day & ", 0,0,0)" &
                    "&prompt2=" & rblRoofNo.SelectedItem.Text & "" &
                    "&prompt3=" & rblRRLType.SelectedItem.Value & ""
                Case Else
                    Exit Sub
            End Select
            Response.Redirect(strPathName)
        End If
    End Sub

    Private Sub btnGen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGen.Click
        lblMessage.Text = ""
        Dim dt As DataTable
        Try
            dt = ProductionConsumables.FurnacePODetailsData(rblLiningType.SelectedItem.Value, ddlPONo.SelectedItem.Value)
            If dt.Rows.Count > 0 Then
                lblMessage.Text = "Data Generated ! View report immediately for the selected PO !"
            Else
                lblMessage.Text = "Data Generation failed !"
            End If
        Catch exp As Exception
            lblMessage.Text &= exp.Message
        End Try
    End Sub

    Private Sub btnLOANo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLOANo.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=24973&user0=sa&password0=sadev123" &
        "&prompt0=" & ddlLOANo.SelectedItem.Value & "" &
        "&prompt1=5"
        Response.Redirect(strPathName)
    End Sub
End Class
