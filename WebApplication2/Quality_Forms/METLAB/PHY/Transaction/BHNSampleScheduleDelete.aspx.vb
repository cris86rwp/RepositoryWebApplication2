Public Class BHNSampleScheduleDelete
    Inherits System.Web.UI.Page
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents ddlWheelType As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label

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
        If IsPostBack = False Then
            Try
                GetScheduledSamples()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
    Private Sub GetScheduledSamples()
        ddlWheelType.Items.Clear()
        Dim dt As New DataTable()
        Try
            dt = metLab.tables.GetScheduledSamples
            ddlWheelType.DataSource = dt
            ddlWheelType.DataTextField = dt.Columns(0).ColumnName
            ddlWheelType.DataValueField = dt.Columns(1).ColumnName
            ddlWheelType.DataBind()
            ddlWheelType.Items.Insert(0, "select")
        Catch exp As Exception
            Throw New Exception(exp.Message)
        End Try
    End Sub
    Private Sub ddlWheelType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlWheelType.SelectedIndexChanged
        lblMessage.Text = ""
        If ddlWheelType.SelectedIndex = 0 Then
            DataGrid1.DataSource = Nothing
            DataGrid1.DataBind()
            lblMessage.Text = "Please select Wheel Type !"
        Else
            Try
                FillGrid()
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
    Private Sub FillGrid()
        DataGrid1.DataSource = Nothing
        DataGrid1.DataBind()
        Try
            DataGrid1.DataSource = metLab.tables.GetScheduledSampleList(ddlWheelType.SelectedItem.Value)
            DataGrid1.DataBind()
        Catch exp As Exception
            Throw New Exception(exp.Message)
        End Try
    End Sub
    Private Sub DataGrid1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.ItemCommand
        lblMessage.Text = ""
        If ddlWheelType.SelectedIndex = 0 Then
            lblMessage.Text = "Please select Wheel Type !"
        Else
            Try
                Select Case e.CommandName
                    Case "Delete"
                        ' insert into ms_wheel_hardness_sample_schedule is in stored procedure ms_sp_GetHeatRangeForHardnessTest
                        ' hence following codes not in class file
                        Dim done As Boolean
                        Try
                            done = New metLab.RegularTest().BHNSampleScheduleDelete(ddlWheelType.SelectedItem.Value, e.Item.Cells(3).Text, e.Item.Cells(4).Text)
                        Catch exp As Exception
                            Throw New Exception(exp.Message)
                        Finally
                            If done Then
                                lblMessage.Text = "Deleted Scheduled Heat Range !"
                            Else
                                lblMessage.Text = "Deletetion Failed !"
                            End If
                        End Try
                        If done Then
                            Try
                                GetScheduledSamples()
                                DataGrid1.DataSource = Nothing
                                DataGrid1.DataBind()
                            Catch exp As Exception
                                lblMessage.Text = exp.Message
                            End Try
                        End If
                End Select
            Catch exp As Exception
                lblMessage.Text = exp.Message
            End Try
        End If
    End Sub
End Class
