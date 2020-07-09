Public Class TreadDiaChangeBeforePressing
    Inherits System.Web.UI.Page
    Protected WithEvents txtWheel As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnUpdate As System.Web.UI.WebControls.Button
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid3 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid4 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid5 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid6 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid7 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid8 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid9 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtReqTreadDia As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
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

        ' Page.Theme = themeValue
        Page.Theme = Session("Theme")
    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Page.IsPostBack = False Then
            lblMessage.Text = ""
            Session("UserID") = "078887"
            Session("Group") = "SSINSP"
            Try
                Dim oEmp As New rwfGen.Employee()
                If oEmp.Check(Session("UserID") & "", Session("Group")) Then
                    If Session("Group") <> "SSINSP" Then
                        Throw New Exception("Invalid Login")
                    End If
                End If
                SetFocus(txtWheel)
                oEmp = Nothing
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
    Private Sub SetFocus(ByVal ctrl As Control)
        Dim focusScript As String = "<script language=" & "javascript" & " > " & _
        "document.getElementById('" + ctrl.ClientID.ToString.Trim & _
        "').focus();</script>"
        Page.RegisterStartupScript("FocusScript", focusScript)
    End Sub
    Private Sub txtWheel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWheel.TextChanged
        lblMessage.Text = ""
        btnUpdate.Visible = SSINSP.IsValidWheel(ReturnWheel(txtWheel.Text.Trim), ReturnHeat(txtWheel.Text.Trim))
        If btnUpdate.Visible = False Then
            txtWheel.Text = ""
            lblMessage.Text = "InValid Wheel Number !"
            SetFocus(txtWheel)
        Else
            showWheelHistory()
            SetFocus(txtReqTreadDia)
        End If
    End Sub
    Private Function ReturnWheel(ByVal mystr As String) As String
        Dim myarray As Array
        Dim mywheel, myheat As String
        If mystr <> "" Then
            myarray = Split(mystr, "/")
            mywheel = myarray(0)
            myheat = myarray(1)
            Return mywheel
        End If
        myarray = Nothing
        myheat = Nothing
    End Function
    Private Function ReturnHeat(ByVal mystr As String) As String
        Dim myarray As Array
        Dim mywheel, myheat As String
        If mystr <> "" Then
            myarray = Split(mystr, "/")
            mywheel = myarray(0)
            myheat = myarray(1)
            Return myheat
        End If
        myarray = Nothing
        mywheel = Nothing
    End Function
    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        lblMessage.Text = ""
        Dim blnDone As New Boolean()
        Try
            blnDone = SSINSP.IsValidDia(ReturnWheel(txtWheel.Text.Trim), ReturnHeat(txtWheel.Text.Trim), Val(txtReqTreadDia.Text.Trim))
            If blnDone Then
                blnDone = False
                blnDone = New SSINSP().UpdateTreadDia(ReturnWheel(txtWheel.Text.Trim), ReturnHeat(txtWheel.Text.Trim), Val(txtReqTreadDia.Text.Trim))
                If blnDone Then
                    lblMessage.Text = "Data saved !"
                Else
                    lblMessage.Text &= ". Data Not saved"
                End If
            Else
                lblMessage.Text = "Tread Dia Mis-Match !. Data Not saved"
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try
        blnDone = Nothing
        txtWheel.Text = ""
        txtReqTreadDia.Text = ""
    End Sub
    Private Sub showWheelHistory()
        clear()
        Dim ds As DataSet
        Try
            ds = RWF.CLRINS.getBriefHistory(ReturnWheel(txtWheel.Text.Trim), ReturnHeat(txtWheel.Text.Trim))
            DataGrid1.DataSource = ds.Tables(0)
            DataGrid2.DataSource = ds.Tables(1)
            DataGrid3.DataSource = ds.Tables(2)
            DataGrid4.DataSource = ds.Tables(3)
            DataGrid5.DataSource = ds.Tables(4)
            DataGrid6.DataSource = ds.Tables(5)
            DataGrid7.DataSource = ds.Tables(6)
            DataGrid8.DataSource = ds.Tables(7)
            DataGrid1.DataBind()
            DataGrid2.DataBind()
            DataGrid3.DataBind()
            DataGrid4.DataBind()
            DataGrid5.DataBind()
            DataGrid6.DataBind()
            DataGrid7.DataBind()
            DataGrid8.DataBind()
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            ds.Dispose()
            ds = Nothing
        End Try
    End Sub
    Private Sub clear()
        DataGrid1.DataSource = Nothing
        DataGrid2.DataSource = Nothing
        DataGrid3.DataSource = Nothing
        DataGrid4.DataSource = Nothing
        DataGrid5.DataSource = Nothing
        DataGrid6.DataSource = Nothing
        DataGrid7.DataSource = Nothing
        DataGrid8.DataSource = Nothing
        DataGrid9.DataSource = Nothing

        DataGrid1.DataBind()
        DataGrid2.DataBind()
        DataGrid3.DataBind()
        DataGrid4.DataBind()
        DataGrid5.DataBind()
        DataGrid6.DataBind()
        DataGrid7.DataBind()
        DataGrid8.DataBind()
        DataGrid9.DataBind()
    End Sub
End Class
