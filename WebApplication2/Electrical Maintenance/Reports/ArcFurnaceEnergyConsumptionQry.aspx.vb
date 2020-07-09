Public Class ArcFurnaceEnergyConsumptionQry
    Inherits System.Web.UI.Page
    Protected WithEvents lblMonth As System.Web.UI.WebControls.Label
    Protected WithEvents lblMelt1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblMelt2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblMelt3 As System.Web.UI.WebControls.Label
    Protected WithEvents lblConsumption1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblConsumption2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblConsumption3 As System.Web.UI.WebControls.Label
    Protected WithEvents lblAverage1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblPreviousAverage1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblAverage2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblPreviousAverage2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblAverage3 As System.Web.UI.WebControls.Label
    Protected WithEvents lblPreviousAverage3 As System.Web.UI.WebControls.Label
    Protected WithEvents lblTotMelts As System.Web.UI.WebControls.Label
    Protected WithEvents lblTotConsumptiuon As System.Web.UI.WebControls.Label
    Protected WithEvents lblTotAverage As System.Web.UI.WebControls.Label
    Protected WithEvents lblTotPreviousAverage As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents cboMonth As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboYear As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents lblDate As System.Web.UI.WebControls.Label
    Protected WithEvents lbltotalmelts As System.Web.UI.WebControls.Label
    Protected WithEvents lbltotalenergy As System.Web.UI.WebControls.Label
    Protected WithEvents pnlMain As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlData As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlView As System.Web.UI.WebControls.Panel
    Protected WithEvents lbltotalaverage As System.Web.UI.WebControls.Label
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList

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
        If Not IsPostBack Then
            getYears()
        End If
    End Sub
    Private Sub Clear()
        lblMonth.Text = ""
        lblMelt1.Text = ""
        lblMelt2.Text = ""
        lblMelt3.Text = ""
        lblConsumption1.Text = ""
        lblConsumption2.Text = ""
        lblConsumption3.Text = ""
        lblAverage1.Text = ""
        lblPreviousAverage1.Text = ""
        lblAverage2.Text = ""
        lblPreviousAverage2.Text = ""
        lblAverage3.Text = ""
        lblPreviousAverage3.Text = ""
        lblTotMelts.Text = ""
        lblTotConsumptiuon.Text = ""
        lblTotAverage.Text = ""
        lblTotPreviousAverage.Text = ""
        lblMessage1.Text = ""
        lblMessage.Text = ""
        lblDate.Text = ""
        lbltotalmelts.Text = ""
        lbltotalenergy.Text = ""
        lbltotalaverage.Text = ""
    End Sub
    Private Sub getYears()
        Dim ds As DataSet
        Dim d As Date
        Dim y, py, ny, m As Int16
        d = Date.Now
        m = d.Month
        Try
            ds = Maintenance.ElecTables.getMonthYear("ms_furnace_melting_statistics", "Consumption_date")
            cboMonth.DataSource = ds.Tables(0)
            cboMonth.DataTextField = ds.Tables(0).Columns(1).ColumnName
            cboMonth.DataValueField = ds.Tables(0).Columns(0).ColumnName
            cboMonth.DataBind()
            cboYear.DataSource = ds.Tables(1)
            cboYear.DataTextField = ds.Tables(1).Columns(0).ColumnName
            cboYear.DataValueField = ds.Tables(1).Columns(0).ColumnName
            cboYear.DataBind()
            cboYear.SelectedIndex = 0
            cboMonth.SelectedIndex = m - 1
        Catch exp As Exception
            lblMessage.Text = exp.Message
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Clear()
        lblMessage.Text = ""
        Try
            lblMonth.Text = cboMonth.SelectedItem.Text
            Dim melts, consumption, energy, premelts, preenergy As Double
            Dim mth, yr As Int16
            'ARC - I
            melts = Maintenance.ElecTables.FurnaceCounts(cboMonth.SelectedItem.Value, cboYear.SelectedItem.Text, "AF-A")
            consumption = Maintenance.ElecTables.FurnaceStats(cboMonth.SelectedItem.Value, cboYear.SelectedItem.Text, "AF-A")
            mth = cboMonth.SelectedItem.Value
            yr = cboYear.SelectedItem.Text
            If mth = 1 Then
                mth = 12
                yr = yr - 1
            Else
                mth = mth - 1
            End If
            premelts = Maintenance.ElecTables.FurnaceCounts(mth, yr, "AF-A")
            preenergy = Maintenance.ElecTables.FurnaceStats(mth, yr, "AF-A")
            If melts = 0 Then
                energy = 0
            Else
                energy = consumption / melts
            End If

            If premelts = 0 Then
                preenergy = 0
            Else
                preenergy = preenergy / premelts
            End If

            lblMelt1.Text = melts
            lblConsumption1.Text = consumption
            lblAverage1.Text = energy
            lblPreviousAverage1.Text = preenergy

            'ARC - II
            melts = Maintenance.ElecTables.FurnaceCounts(cboMonth.SelectedItem.Value, cboYear.SelectedItem.Text, "AF-B")
            consumption = Maintenance.ElecTables.FurnaceStats(cboMonth.SelectedItem.Value, cboYear.SelectedItem.Text, "AF-B")
            mth = cboMonth.SelectedItem.Value
            yr = cboYear.SelectedItem.Text
            If mth = 1 Then
                mth = 12
                yr = yr - 1
            Else
                mth = mth - 1
            End If
            premelts = Maintenance.ElecTables.FurnaceCounts(mth, yr, "AF-B")
            preenergy = Maintenance.ElecTables.FurnaceStats(mth, yr, "AF-B")

            If melts = 0 Then
                energy = 0
            Else
                energy = consumption / melts
            End If
            If premelts = 0 Then
                preenergy = 0
            Else
                preenergy = preenergy / premelts
            End If

            lblMelt2.Text = melts
            lblConsumption2.Text = consumption
            lblAverage2.Text = energy
            lblPreviousAverage2.Text = preenergy

            'ARC - III
            melts = Maintenance.ElecTables.FurnaceCounts(cboMonth.SelectedItem.Value, cboYear.SelectedItem.Text, "AF-C")
            consumption = Maintenance.ElecTables.FurnaceStats(cboMonth.SelectedItem.Value, cboYear.SelectedItem.Text, "AF-C")
            mth = cboMonth.SelectedItem.Value
            yr = cboYear.SelectedItem.Text
            If mth = 1 Then
                mth = 12
                yr = yr - 1
            Else
                mth = mth - 1
            End If
            premelts = Maintenance.ElecTables.FurnaceCounts(mth, yr, "AF-C")
            preenergy = Maintenance.ElecTables.FurnaceStats(mth, yr, "AF-C")

            If melts = 0 Then
                energy = 0
            Else
                energy = consumption / melts
            End If
            If premelts = 0 Then
                preenergy = 0
            Else
                preenergy = preenergy / premelts
            End If

            lblMelt3.Text = melts
            lblConsumption3.Text = consumption
            lblAverage3.Text = energy
            lblPreviousAverage3.Text = preenergy

            'Totals
            Dim int1, int2, int3 As Double
            int1 = lblMelt1.Text
            int2 = lblMelt2.Text
            int3 = lblMelt3.Text
            lblTotMelts.Text = int1 + int2 + int3
            int1 = lblConsumption1.Text
            int2 = lblConsumption2.Text
            int3 = lblConsumption3.Text
            lblTotConsumptiuon.Text = int1 + int2 + int3
            int1 = lblAverage1.Text
            int2 = lblAverage2.Text
            int3 = lblAverage3.Text
            lblTotAverage.Text = int1 + int2 + int3
            int1 = lblPreviousAverage1.Text
            int2 = lblPreviousAverage2.Text
            int3 = lblPreviousAverage3.Text
            lblTotPreviousAverage.Text = int1 + int2 + int3

            lblDate.Text = Date.Today
            lbltotalmelts.Text = lblTotMelts.Text
            lbltotalenergy.Text = lblTotConsumptiuon.Text
            Dim melt, cons, avg As Double
            melt = lbltotalmelts.Text
            cons = lblTotConsumptiuon.Text
            avg = cons / melt
            lbltotalaverage.Text = avg
        Catch Genexp As Exception
            lblMessage1.Text = Genexp.Message
        End Try
    End Sub
    Private Sub InitializeComponent()

    End Sub

End Class
