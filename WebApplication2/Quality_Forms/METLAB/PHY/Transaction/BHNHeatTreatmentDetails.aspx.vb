Public Class BHNHeatTreatmentDetails
    Inherits System.Web.UI.Page
    Protected WithEvents txtNFChargeDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNFChargeTime As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNFZone1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNFZone2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNFZone3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNFZone4 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNFZone5 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNFZone6 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNFZone7 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDFZone1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDFZone2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDFZone3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDFZone4 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDFZone5 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDFZone6 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDFZone7 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDFZone8 As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlQuencherNo As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblMode As System.Web.UI.WebControls.Label
    Protected WithEvents txtHC1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtHC2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtHC3 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtQTimeMin As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents btnClear As System.Web.UI.WebControls.Button
    Protected WithEvents ddlNFChargeCondition As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblLabNum As System.Web.UI.WebControls.Label
    Protected WithEvents txtNFDischargeTime As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtWheel As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlHubCooler1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlHubCooler2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlHubCooler3 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtQTimeSec As System.Web.UI.WebControls.TextBox
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents ddlWheelNumber As System.Web.UI.WebControls.DropDownList
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
        If Not IsPostBack Then
            Dim strTime As String
            strTime = Date.Now
            Try
                lblMode.Text = Request.QueryString("mode")
                'lblMode.Text = "edit"
                ddlWheelNumber.Visible = False
                txtWheel.Visible = False
                txtNFChargeDate.Text = Format(CDate(strTime), "dd/MM/yyyy")
                txtNFChargeTime.Text = Format(CDate(strTime), "hh:mm")
                txtNFDischargeTime.Text = Format(CDate(strTime), "hh:mm")
                txtQTimeMin.Text = Format(CDate(strTime), "mm").Substring(1)
                txtQTimeSec.Text = Format(CDate(strTime), "ss")
                GetDDLValues()
                If lblMode.Text.Trim.ToLower.Equals("add") Then ddlWheelNumber.Visible = True Else txtWheel.Visible = True
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub

    Private Sub FillDDLs(ByVal dt As DataTable, ByVal ddl As DropDownList)
        ddl.DataSource = dt.DefaultView
        ddl.DataTextField = dt.Columns(1).ColumnName
        ddl.DataValueField = dt.Columns(0).ColumnName
        ddl.DataBind()
    End Sub

    Private Sub GetDDLValues()
        Dim ds As New DataSet()
        clear()
        Try
            ddlQuencherNo.ClearSelection()
            ddlQuencherNo.Items.Clear()
            ddlHubCooler1.Items.Clear()
            ddlHubCooler2.Items.Clear()
            ddlHubCooler3.Items.Clear()
            ds = metLab.tables.GetDDLValues
            FillDDLs(ds.Tables(0), ddlQuencherNo)
            FillDDLs(ds.Tables(1), ddlHubCooler1)
            FillDDLs(ds.Tables(1), ddlHubCooler2)
            FillDDLs(ds.Tables(1), ddlHubCooler3)
            FillDDLs(ds.Tables(2), ddlWheelNumber)
            ddlQuencherNo.Items.Insert(0, "Select")
            ddlQuencherNo.Items(0).Selected = True
            ddlHubCooler1.Items.Insert(0, "Select")
            ddlHubCooler1.Items(1).Selected = True
            ddlHubCooler2.Items.Insert(0, "Select")
            ddlHubCooler2.Items(2).Selected = True
            ddlHubCooler3.Items.Insert(0, "Select")
            ddlHubCooler3.Items(3).Selected = True
            ddlWheelNumber.Items.Insert(0, "Select")
            ddlWheelNumber.Items(0).Selected = True
        Catch exp As Exception
            Throw New Exception("DDL Filling Error !")
        End Try
    End Sub

    Private Sub getWheelNumbers()
        ddlWheelNumber.ClearSelection()
        clear()
        ddlWheelNumber.Items.Clear()
        Dim dt As DataTable
        Try
            dt = metLab.tables.getWheelNumbers
            Dim dr As DataRow
            For Each dr In dt.Rows
                ddlWheelNumber.Items.Add(New ListItem(CStr(dr("wheel_number")) + "/" + CStr(dr("heat_number")), dr("lab_number")))
            Next
            ddlWheelNumber.Items.Insert(0, "Select")
            ddlWheelNumber.Items(0).Selected = True
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
        End Try
    End Sub
    Private Function ReturnWheel(ByVal mystr As String) As Long
        Dim myarray As Array
        If mystr <> "" Then
            myarray = Split(mystr, "/")
            ReturnWheel = (myarray(0))
        End If
    End Function
    Private Function ReturnHeat(ByVal mystr As String) As Long
        Dim myarray As Array
        If mystr <> "" Then
            myarray = Split(mystr, "/")
            ReturnHeat = myarray(1)
        End If
    End Function
    Private Sub clear()
        lblLabNum.Text = ""
        txtNFZone1.Text = "0"
        txtNFZone2.Text = ""
        txtNFZone3.Text = ""
        txtNFZone4.Text = ""
        txtNFZone5.Text = ""
        txtNFZone6.Text = ""
        txtNFZone7.Text = ""
        txtDFZone1.Text = ""
        txtDFZone2.Text = ""
        txtDFZone3.Text = ""
        txtDFZone4.Text = ""
        txtDFZone5.Text = ""
        txtDFZone6.Text = ""
        txtDFZone7.Text = ""
        txtDFZone8.Text = ""
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If lblMode.Text.Trim.ToLower.Equals("add") Then
            If ddlWheelNumber.SelectedIndex = 0 Then
                lblMessage.Text = "WheelNumber not selected "
                Exit Sub
            End If
        Else
            If txtWheel.Text.Trim.Length = 0 Then
                lblMessage.Text = "WheelNumber not selected "
                Exit Sub
            End If
        End If
        If ddlQuencherNo.SelectedIndex = 0 Then
            lblMessage.Text = "Quencher Number not selected "
            Exit Sub
        End If
        Dim done As New Boolean()
        Dim oCmd As New SqlClient.SqlCommand()
        Dim oHT As New metLab.Product()
        Session("oHT") = oHT
        Try
            CType(Session("oHT"), metLab.Product).LabNumber = lblLabNum.Text.Trim
            CType(Session("oHT"), metLab.Product).NFChargeDate = txtNFChargeDate.Text.Trim
            CType(Session("oHT"), metLab.Product).NFChargeTime = txtNFChargeTime.Text.Trim
            CType(Session("oHT"), metLab.Product).NFChargeCondition = ddlNFChargeCondition.SelectedItem.Text.Trim
            CType(Session("oHT"), metLab.Product).NFDischargeTime = txtNFDischargeTime.Text.Trim
            CType(Session("oHT"), metLab.Product).NFZone1 = txtNFZone1.Text.Trim
            CType(Session("oHT"), metLab.Product).NFZone2 = txtNFZone2.Text.Trim
            CType(Session("oHT"), metLab.Product).NFZone3 = txtNFZone3.Text.Trim
            CType(Session("oHT"), metLab.Product).NFZone4 = txtNFZone4.Text.Trim
            CType(Session("oHT"), metLab.Product).NFZone5 = txtNFZone5.Text.Trim
            CType(Session("oHT"), metLab.Product).NFZone6 = txtNFZone6.Text.Trim
            CType(Session("oHT"), metLab.Product).NFZone7 = txtNFZone7.Text.Trim
            CType(Session("oHT"), metLab.Product).DFZone1 = txtDFZone1.Text.Trim
            CType(Session("oHT"), metLab.Product).DFZone2 = txtDFZone2.Text.Trim
            CType(Session("oHT"), metLab.Product).DFZone3 = txtDFZone3.Text.Trim
            CType(Session("oHT"), metLab.Product).DFZone4 = txtDFZone4.Text.Trim
            CType(Session("oHT"), metLab.Product).DFZone5 = txtDFZone5.Text.Trim
            CType(Session("oHT"), metLab.Product).DFZone6 = txtDFZone6.Text.Trim
            CType(Session("oHT"), metLab.Product).DFZone7 = txtDFZone7.Text.Trim
            CType(Session("oHT"), metLab.Product).DFZone8 = txtDFZone8.Text.Trim
            CType(Session("oHT"), metLab.Product).QuencherNo = ddlQuencherNo.SelectedItem.Value.Trim
            CType(Session("oHT"), metLab.Product).QTimeMin = txtQTimeMin.Text.Trim
            CType(Session("oHT"), metLab.Product).QTimeSec = txtQTimeSec.Text.Trim
            CType(Session("oHT"), metLab.Product).HC1 = txtHC1.Text.Trim
            CType(Session("oHT"), metLab.Product).HC2 = txtHC2.Text.Trim
            CType(Session("oHT"), metLab.Product).HC3 = txtHC3.Text.Trim
            CType(Session("oHT"), metLab.Product).HubCooler1 = ddlHubCooler1.SelectedItem.Value.Trim
            CType(Session("oHT"), metLab.Product).HubCooler2 = ddlHubCooler2.SelectedItem.Value.Trim
            CType(Session("oHT"), metLab.Product).HubCooler3 = ddlHubCooler3.SelectedItem.Value.Trim
            If lblMode.Text.Trim.ToLower.Equals("add") Then
                done = CType(Session("oHT"), metLab.Product).saveHTValues(ReturnWheel(ddlWheelNumber.SelectedItem.Text.Trim), ReturnHeat(ddlWheelNumber.SelectedItem.Text.Trim), lblMode.Text)
            Else
                done = CType(Session("oHT"), metLab.Product).saveHTValues(ReturnWheel(txtWheel.Text.Trim), ReturnHeat(txtWheel.Text.Trim), lblMode.Text)
            End If
            If done Then
                lblMessage.Text = "Data Saved"
            Else
                lblMessage.Text = "Data could not be saved"
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            oHT = Nothing
            clear()
        End Try
        If lblMode.Text.Equals("add") Then
            getWheelNumbers()
        Else
            txtWheel.Text = ""
        End If
    End Sub

    Private Sub ddlWheelNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlWheelNumber.SelectedIndexChanged
        lblLabNum.Text = ddlWheelNumber.SelectedItem.Value.Trim
    End Sub

    Private Sub txtWheel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWheel.TextChanged
        lblMessage.Text = ""
        Dim dt As New DataTable()
        Try
            dt = metLab.tables.GetHTDetails(ReturnWheel(txtWheel.Text.Trim), ReturnHeat(txtWheel.Text.Trim))
            If dt.Rows.Count > 0 Then
                lblLabNum.Text = dt.Rows(0)("lab_number") & ""
                txtNFChargeDate.Text = dt.Rows(0)("NFChargeDate") & ""
                txtNFChargeTime.Text = dt.Rows(0)("NFChargeTime") & ""
                Dim int As Integer = 0
                For int = 0 To ddlNFChargeCondition.Items.Count - 1
                    If ddlNFChargeCondition.Items(int).Text.Trim = dt.Rows(0)("NFChargeCondition") Then
                        ddlNFChargeCondition.SelectedIndex = int
                        Exit For
                    End If
                Next
                txtNFDischargeTime.Text = dt.Rows(0)("NFDischargeTime") & ""
                txtNFZone1.Text = dt.Rows(0)("NFZone1") & ""
                txtNFZone2.Text = dt.Rows(0)("NFZone2") & ""
                txtNFZone3.Text = dt.Rows(0)("NFZone3") & ""
                txtNFZone4.Text = dt.Rows(0)("NFZone4") & ""
                txtNFZone5.Text = dt.Rows(0)("NFZone5") & ""
                txtNFZone6.Text = dt.Rows(0)("NFZone6") & ""
                txtNFZone7.Text = dt.Rows(0)("NFZone7") & ""
                txtDFZone1.Text = dt.Rows(0)("DFZone1") & ""
                txtDFZone2.Text = dt.Rows(0)("DFZone2") & ""
                txtDFZone3.Text = dt.Rows(0)("DFZone3") & ""
                txtDFZone4.Text = dt.Rows(0)("DFZone4") & ""
                txtDFZone5.Text = dt.Rows(0)("DFZone5") & ""
                txtDFZone6.Text = dt.Rows(0)("DFZone6") & ""
                txtDFZone7.Text = dt.Rows(0)("DFZone7") & ""
                txtDFZone8.Text = dt.Rows(0)("DFZone8") & ""
                int = 0
                For int = 0 To ddlQuencherNo.Items.Count - 1
                    If ddlQuencherNo.Items(int).Text.Trim = dt.Rows(0)("QuencherNo") Then
                        ddlQuencherNo.SelectedIndex = int
                        Exit For
                    End If
                Next
                txtQTimeMin.Text = dt.Rows(0)("QTimeMin") & ""
                txtQTimeSec.Text = dt.Rows(0)("QTimeSec") & ""
                txtHC1.Text = dt.Rows(0)("HC1") & ""
                txtHC2.Text = dt.Rows(0)("HC2") & ""
                txtHC3.Text = dt.Rows(0)("HC3") & ""
                int = 0
                For int = 0 To ddlHubCooler1.Items.Count - 1
                    If ddlHubCooler1.Items(int).Text.Trim = dt.Rows(0)("HC1Code") Then
                        ddlHubCooler1.SelectedIndex = int
                        Exit For
                    End If
                Next
                int = 0
                For int = 0 To ddlHubCooler2.Items.Count - 1
                    If ddlHubCooler2.Items(int).Text.Trim = dt.Rows(0)("HC2Code") Then
                        ddlHubCooler2.SelectedIndex = int
                        Exit For
                    End If
                Next
                int = 0
                For int = 0 To ddlHubCooler3.Items.Count - 1
                    If ddlHubCooler3.Items(int).Text.Trim = dt.Rows(0)("HC3Code") Then
                        ddlHubCooler3.SelectedIndex = int
                        Exit For
                    End If
                Next
            Else
                txtWheel.Text = ""
                Throw New Exception("Wheel Number not valid !")
            End If
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            dt.Dispose()
        End Try
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        clear()
    End Sub
End Class
