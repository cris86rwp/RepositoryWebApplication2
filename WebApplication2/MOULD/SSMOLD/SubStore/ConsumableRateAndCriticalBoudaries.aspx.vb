Imports System.Data.SqlClient
Public Class ConsumableRateAndCriticalBoudaries
    Inherits System.Web.UI.Page
    Protected WithEvents rd As Global.System.Web.UI.WebControls.RadioButton
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



    Protected Sub Button_Click(sender As Object, e As EventArgs) Handles Submit1.Click
        Dim rd As String
        If Stock.Checked Then
            rd = "Stock"
        ElseIf (NonStock.Checked) Then
            rd = "Non-Stock"
        ElseIf (Others.Checked) Then
            rd = "Others"
        End If

        If HMonth.SelectedValue = 1 Then
            HMonth.Text = "Jan"
        ElseIf (HMonth.SelectedValue = 2) Then
            HMonth.Text = "Feb"
        ElseIf (HMonth.SelectedValue = 3) Then
            HMonth.Text = "Mar"
        ElseIf (HMonth.SelectedValue = 4) Then
            HMonth.Text = "April"
        ElseIf (HMonth.SelectedValue = 5) Then
            HMonth.Text = "May"
        ElseIf (HMonth.SelectedValue = 6) Then
            HMonth.Text = "June"
        ElseIf (HMonth.SelectedValue = 7) Then
            HMonth.Text = "July"
        ElseIf (HMonth.SelectedValue = 8) Then
            HMonth.Text = "Aug"
        ElseIf (HMonth.SelectedValue = 9) Then
            HMonth.Text = "Sep"
        ElseIf (HMonth.SelectedValue = 10) Then
            HMonth.Text = "Oct"
        ElseIf (HMonth.SelectedValue = 11) Then
            HMonth.Text = "Nov"
        ElseIf (HMonth.SelectedValue = 12) Then
            HMonth.Text = "Dec"
        End If


        If WMonth.SelectedValue = 1 Then
            WMonth.Text = "Jan"
        ElseIf (WMonth.SelectedValue = 2) Then
            WMonth.Text = "Feb"
        ElseIf (WMonth.SelectedValue = 3) Then
            WMonth.Text = "Mar"
        ElseIf (WMonth.SelectedValue = 4) Then
            WMonth.Text = "April"
        ElseIf (WMonth.SelectedValue = 5) Then
            WMonth.Text = "May"
        ElseIf (WMonth.SelectedValue = 6) Then
            WMonth.Text = "June"
        ElseIf (WMonth.SelectedValue = 7) Then
            WMonth.Text = "July"
        ElseIf (WMonth.SelectedValue = 8) Then
            WMonth.Text = "Aug"
        ElseIf (WMonth.SelectedValue = 9) Then
            WMonth.Text = "Sep"
        ElseIf (WMonth.SelectedValue = 10) Then
            WMonth.Text = "Oct"
        ElseIf (WMonth.SelectedValue = 11) Then
            WMonth.Text = "Nov"
        ElseIf (WMonth.SelectedValue = 12) Then
            WMonth.Text = "Dec"
        End If
        'If IsNumeric(HHeat) Then
        '    '
        'Else
        '    MsgBox("Enter valid year")
        '    Exit Sub
        'End If

        'If IsNumeric(WYear) Then
        '    '
        '    Exit Sub
        'Else
        '    MsgBox("Enter valid year")
        '    Exit Sub
        'End If

        'If IsNumeric(CritItem) Then
        '    '
        '    Exit Sub
        'Else
        '    MsgBox("Enter valid Item")
        '    Exit Sub
        'End If

        'If IsNumeric(HCount) Then
        '    '
        '    Exit Sub
        'Else
        '    MsgBox("Enter valid count")
        '    Exit Sub
        'End If

        'If IsNumeric(WCount) Then
        '    '
        '    Exit Sub
        'Else
        '    MsgBox("Enter valid count")

        'End If

        Dim con As SqlConnection = New SqlConnection()
        con.ConnectionString = "Data Source=DESKTOP-V6A84DH\NAMRITA;Initial Catalog=wapdev;persist Security Info=True;User ID=sa;Password=cris"

        Dim cmd As New SqlCommand("INSERT INTO Cons_Rate_and_Crit_Item_Boun(Cri_item,Item_desc, cons_rate,per_unit, Crit_item, h_month, h_year, heat_count, w_month, w_year , wheel_count2) VALUES (@Cri_item,@Item_desc,@cons_rate,@per_unit,@Crit_item,@h_month,@h_year,@heat_count,@w_month,@w_year,@wheel_count)")
        cmd.Connection = con
        cmd.Parameters.AddWithValue("@Cri_item", rd)
        cmd.Parameters.AddWithValue("@Item_desc", Itemdesc.Text)
        cmd.Parameters.AddWithValue("@cons_rate", ConRate.Text)
        cmd.Parameters.AddWithValue("@per_unit", PerUnit.SelectedItem.Text)
        cmd.Parameters.AddWithValue("@Crit_item", CritItem.Text)
        cmd.Parameters.AddWithValue("@h_month", HMonth.SelectedItem.Text)
        cmd.Parameters.AddWithValue("@h_year", HHeat.Text)
        cmd.Parameters.AddWithValue("@heat_count", HCount.Text)
        cmd.Parameters.AddWithValue("@w_month", WMonth.SelectedItem.Text)
        cmd.Parameters.AddWithValue("@w_year", WYear.Text)
        cmd.Parameters.AddWithValue("@wheel_count", WCount.Text)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        MsgBox("Submitted Sucessfully")
        Response.Redirect(Request.Url.AbsoluteUri)

    End Sub
End Class