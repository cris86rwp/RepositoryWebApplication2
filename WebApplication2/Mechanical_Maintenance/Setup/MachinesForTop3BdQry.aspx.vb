Public Class MachinesForTop3BdQry
    Inherits System.Web.UI.Page
    Protected WithEvents txtSearchString As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lstMachines As System.Web.UI.WebControls.ListBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents chkSel As System.Web.UI.WebControls.CheckBox
    Protected WithEvents btnFilter As System.Web.UI.WebControls.Button
    Protected WithEvents chkRemove As System.Web.UI.WebControls.CheckBox
    Protected WithEvents lblNoOfMcnsInQueryTable As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList


    Dim strCheck As String = "select count(*) from ms_MachinesForTop3BdQry where machine_code  like @MachineCode+'%'"
    Dim strUpdtUnSelected As String = "Update ms_MachinesForTop3BdQry set selected = 0 where machine_code = @MachineCode "
    Dim strUpdtSelected As String = "Update ms_MachinesForTop3BdQry set selected = 1  where machine_code = @MachineCode "
    Dim strAddMcn As String = "insert into ms_MachinesForTop3BdQry select @MachineCode,1 "
    Dim strRemoveFromSelected As String = "Delete ms_MachinesForTop3BdQry  where machine_code = @MachineCode"
    Dim strCount As String = "select sum(case when selected = 1 then 1 else 0 end) SelectedMcns, (case when selected = 0 then 1 else 0 end ) NotSelectedMcns, sum(1) TotalMcns from ms_MachinesForTop3BdQry group by selected"

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
        If Page.IsPostBack = False Then
            Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
            cmd.CommandText = strCount
            Try
                cmd.Connection.Open()
                GetStatus(cmd)
            Catch exp As Exception
            Finally
                If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
                cmd.Dispose()
            End Try
        End If
    End Sub

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


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim cmd As SqlClient.SqlCommand = rwfGen.Connection.CmdObj
        Dim i As Integer
        lblNoOfMcnsInQueryTable.Text = ""
        Dim blnDone As Boolean
        Dim sMessage As String = ""
        cmd.Parameters.Add("@MachineCode", SqlDbType.VarChar, 50)
        cmd.Parameters("@MachineCode").Value = ""
        Try
            cmd.Connection.Open()
            blnDone = True
        Catch exp As Exception
            lblMessage.Text = "Server Connection broken"
        Finally

        End Try
        If blnDone = False Then
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
            Exit Sub
        Else
            blnDone = False
        End If
        Dim seletedCnt As Integer
        seletedCnt = 0
        For i = 0 To lstMachines.Items.Count - 1
            If lstMachines.Items(i).Selected = True Then
                cmd.Parameters("@MachineCode").Value = lstMachines.Items(i).Value
                seletedCnt += 1
                Try
                    cmd.CommandText = strCheck
                    Dim recExists As Integer
                    recExists = cmd.ExecuteScalar()
                    If recExists = 0 Then
                        cmd.CommandText = strAddMcn
                        sMessage = "Machine Code(s) added to Query Table"
                    ElseIf chkSel.Checked Then
                        If chkRemove.Checked = False Then
                            cmd.CommandText = strUpdtSelected
                            sMessage = "Machine Code(s) updated as selected in Query Table"
                        Else
                            cmd.CommandText = strRemoveFromSelected
                            sMessage = "Machine Code(s) removed from Query Table"
                        End If
                    ElseIf chkSel.Checked = False Then
                        If chkRemove.Checked = False Then
                            cmd.CommandText = strUpdtUnSelected
                            sMessage = "Machine Code(s) updated as not selected in Query Table"
                        Else
                            cmd.CommandText = strRemoveFromSelected
                            sMessage = "Machine Code(s) removed from Query Table"
                        End If
                    End If
                    If cmd.ExecuteNonQuery > 0 Then
                        blnDone = True
                        Filter()
                    Else
                        blnDone = False
                    End If
                    GetStatus(cmd)
                Catch exp As Exception
                    blnDone = False
                    lblMessage.Text = "Save Error : " & exp.Message
                End Try
                If blnDone = False Then
                    Exit For
                Else
                    blnDone = False
                    lblMessage.Text = ""
                End If
            End If
        Next
        If lblMessage.Text = "" Then
            lblMessage.Text = sMessage
        End If
        If IsNothing(cmd) = False Then
            If cmd.Connection.State = ConnectionState.Open Then cmd.Connection.Close()
            cmd.Dispose()
        End If

    End Sub

    Private Sub GetStatus(ByRef cmd As SqlClient.SqlCommand)
        cmd.CommandText = strCount
        Dim dr As SqlClient.SqlDataReader
        dr = cmd.ExecuteReader
        Dim iSelected, iNotSelected, iTotal As Integer
        iSelected = 0
        iNotSelected = 0
        iTotal = 0
        While dr.Read
            iSelected += dr("selectedMcns")
            iNotSelected += dr("NotSelectedMcns")
            iTotal += dr("TotalMcns")
        End While
        dr.Close()
        lblNoOfMcnsInQueryTable.Text = "Mcn Count in Query Table : Selected-" & CStr(iSelected).Trim & ", Not Selected-" & CStr(iNotSelected).Trim & ", Total Mcns-" & CStr(iTotal).Trim
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        lblMessage.Text = ""
        Filter()
    End Sub

    Private Sub Filter()
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Dim ds As New DataSet()

        If chkSel.Checked = False Then
            da.SelectCommand.CommandText = "Select ltrim(rtrim(machine_code))+'   -   '+rtrim(Description) txtfld , machine_code, Description from ms_machinery_master where machine_code like '" & txtSearchString.Text & "%' and machine_code not in ( select machine_code from ms_MachinesForTop3BdQry ) order by machine_code"
            lblMessage.Text = "Selected from Machinery Master"
        Else
            da.SelectCommand.CommandText = "Select ltrim(rtrim(a.machine_code))+'   -   '+rtrim(a.Description) txtfld , a.machine_code, a.Description from ms_machinery_master a inner join ms_MachinesForTop3BdQry b on a.machine_code = b.machine_code" & _
            " where a.machine_code like '" & txtSearchString.Text & "%'  order by a.machine_code"
            lblMessage.Text = "Selected from Selected List"
        End If
        Dim blnDone As Boolean
        Try
            da.Fill(ds)
            blnDone = True
        Catch exp As Exception
            lblMessage.Text = exp.Message
        Finally
            If blnDone Then
                lstMachines.DataSource = ds.Tables(0)
                lstMachines.DataTextField = ds.Tables(0).Columns(0).ColumnName
                lstMachines.DataValueField = ds.Tables(0).Columns(1).ColumnName
                lstMachines.DataBind()
                lstMachines.Visible = True
            Else
                lstMachines.Visible = False
            End If
            da.Dispose()
            ds.Dispose()
        End Try
    End Sub
End Class
