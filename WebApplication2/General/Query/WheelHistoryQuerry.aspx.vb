Public Class WheelHistoryQuerry
    Inherits System.Web.UI.Page
    Protected WithEvents txtWheel As System.Web.UI.WebControls.TextBox
    Protected WithEvents pnlMain As System.Web.UI.WebControls.Panel
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents WhlMaster As System.Web.UI.WebControls.DataGrid
    Protected WithEvents WhlMaster1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Pouring As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Magna As System.Web.UI.WebControls.DataGrid
    Protected WithEvents WhlMachining As System.Web.UI.WebControls.DataGrid
    Protected WithEvents FinalInsp As System.Web.UI.WebControls.DataGrid
    Protected WithEvents UnBoreInsp As System.Web.UI.WebControls.DataGrid
    Protected WithEvents YardInsp As System.Web.UI.WebControls.DataGrid
    Protected WithEvents QCIInsp As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Mounting As System.Web.UI.WebControls.DataGrid
    Protected WithEvents WheelSet As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Demount As System.Web.UI.WebControls.DataGrid
    Protected WithEvents ReturnedStores As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Duplicates As System.Web.UI.WebControls.DataGrid
    Protected WithEvents chkRefresh As System.Web.UI.WebControls.CheckBox
    Protected WithEvents WheelDespatchAsSetDetails As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Despatch As System.Web.UI.WebControls.DataGrid
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
        If IsPostBack = False Then
            SetFocus(txtWheel)
        End If
    End Sub

    'Private Sub SetFocus(ByVal ctrl As Control)
    '    Dim focusScript As String = "<script language=" & "javascript" & " > " & _
    '    "document.getElementById('" + ctrl.ClientID.ToString.Trim & _
    '    "').focus();</script>"
    '    Page.RegisterStartupScript("FocusScript", focusScript)
    'End Sub

    Private Sub txtWheel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWheel.TextChanged
        lblMessage.Text = ""
        Dim i As Integer
        For i = 0 To txtWheel.Text.Trim.ToString.Length - 1
            If IsNumeric(txtWheel.Text.Trim.Substring(i, 1)) = False And txtWheel.Text.Trim.Substring(i, 1).Equals("/") = False Then
                lblMessage.Text = "Invalid Wheel Number.  Separate Engraved Number and Heat Number by / "
                Exit Sub
            End If
        Next
        ShowHistory()
    End Sub

    Private Sub chkRefresh_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRefresh.CheckedChanged
        lblMessage.Text = ""
        Dim i As Integer
        For i = 0 To txtWheel.Text.Trim.ToString.Length - 1
            If IsNumeric(txtWheel.Text.Trim.Substring(i, 1)) = False And txtWheel.Text.Trim.Substring(i, 1).Equals("/") = False Then
                lblMessage.Text = "Invalid Wheel Number.  Separate Engraved Number and Heat Number by / "
                Exit Sub
            End If
        Next
        ShowHistory()
    End Sub

    Private Sub ShowHistory()
        Dim ds As New DataSet()
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Try
            da.SelectCommand.CommandText = "mm_sp_si_wheelHistory"
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.Add("@whlstr", SqlDbType.VarChar, 50).Value = txtWheel.Text.Trim.ToUpper
            da.Fill(ds)
            WhlMaster.DataSource = ds.Tables(0).DefaultView
            WhlMaster1.DataSource = ds.Tables(1).DefaultView
            Pouring.DataSource = ds.Tables(2).DefaultView
            Magna.DataSource = ds.Tables(3).DefaultView
            WhlMachining.DataSource = ds.Tables(4).DefaultView
            FinalInsp.DataSource = ds.Tables(5).DefaultView
            YardInsp.DataSource = ds.Tables(6).DefaultView
            QCIInsp.DataSource = ds.Tables(7).DefaultView
            Mounting.DataSource = ds.Tables(8).DefaultView
            WheelSet.DataSource = ds.Tables(9).DefaultView
            Demount.DataSource = ds.Tables(10).DefaultView
            Despatch.DataSource = ds.Tables(11).DefaultView
            Duplicates.DataSource = ds.Tables(12).DefaultView
            ReturnedStores.DataSource = ds.Tables(13).DefaultView
            'UnBoreInsp.DataSource = ds.Tables(14).DefaultView
            'WheelDespatchAsSetDetails.DataSource = ds.Tables(15).DefaultView
            WhlMaster.DataBind()
            WhlMaster1.DataBind()
            Pouring.DataBind()
            Magna.DataBind()
            WhlMachining.DataBind()
            FinalInsp.DataBind()
            YardInsp.DataBind()
            QCIInsp.DataBind()
            Mounting.DataBind()
            WheelSet.DataBind()
            Demount.DataBind()
            Despatch.DataBind()
            Duplicates.DataBind()
            ReturnedStores.DataBind()
            'UnBoreInsp.DataBind()
            'WheelDespatchAsSetDetails.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            da.Dispose()
            ds.Dispose()
        End Try
    End Sub
End Class
