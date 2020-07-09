Imports System.Data.SqlClient
Public Class Stock_Item_Form
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RB_SSE.CheckedChanged
        If RB_SSE.Checked = True Then
            P_SSE.Visible = True
            P_Others.Visible = False
            Submit.Visible = True

        End If
    End Sub

    Protected Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RB_Others.CheckedChanged
        If RB_Others.Checked = True Then
            P_Others.Visible = True
            P_SSE.Visible = False
            Submit.Visible = True

        End If
    End Sub

    Protected Sub Submit_Click(sender As Object, e As EventArgs) Handles Submit.Click
        If PO_No.Text = String.Empty Then
            MsgBox("Enter PO_No")
            Exit Sub
        End If
        If I_Date.Text = String.Empty Then
            MsgBox("Enter Inspection Date")
            Exit Sub
        End If

        Dim rbsse As String

        If RB_SSE.Checked = True Then
            rbsse = "SSE"
            Dim con As SqlConnection = New SqlConnection()
            con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\source\repos\WebApplication1\WebApplication1\App_Data\Database1.mdf;Integrated Security=True"
            Dim cmd As New SqlCommand("INSERT INTO Stock_Item_Inspection_Detail(Inspection_type,Item_Desc,PO_No,PO_Date,PO_Qty,Firm_Name,Supply_Date,Supply_Qty,Inspection_Date,Inspection_Status,Report_Submission_Date,Inspection_Remarks) VALUES(@Inspection_type,@Item_Desc,@PO_No,@PO_Date,@PO_Qty,@Firm_Name,@Supply_Date,@Supply_Qty,@Inspection_Date,@Inspection_Status,@Report_Submission_Date,@Inspection_Remarks)")
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@Inspection_type", RB_SSE.Text)
            cmd.Parameters.AddWithValue("@Item_Desc", Item_Desc.SelectedItem.Text)
            cmd.Parameters.AddWithValue("@PO_No", PO_No.Text)
            cmd.Parameters.AddWithValue("@PO_Date", PO_Date.Text)
            cmd.Parameters.AddWithValue("@PO_Qty", PO_Qty.Text)
            cmd.Parameters.AddWithValue("@Firm_Name", Firm_Name.Text)
            cmd.Parameters.AddWithValue("@Supply_Date", S_Date.Text)
            cmd.Parameters.AddWithValue("@Supply_Qty", S_Qty.Text)
            cmd.Parameters.AddWithValue("@Inspection_Date", I_Date.Text)
            cmd.Parameters.AddWithValue("@Inspection_Status", I_Status.Text)
            cmd.Parameters.AddWithValue("@Report_Submission_Date", R_S_Date.Text)
            cmd.Parameters.AddWithValue("@Inspection_Remarks", I_Remarks.Text)

            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        End If


        If RB_Others.Checked = True Then
            rbsse = "Others"
            Dim con As SqlConnection = New SqlConnection()
            con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\source\repos\WebApplication1\WebApplication1\App_Data\Database1.mdf;Integrated Security=True"
            Dim cmd As New SqlCommand("INSERT INTO Stock_Item_Inspection_Detail(Inspection_type,Item_Desc,PO_No,PO_Date,PO_Qty,Firm_Name,Supply_Date,Supply_Qty,Inspection_Done_By,Inspection_Date,Inspection_Status,Inspection_Remarks) VALUES(@Inspection_type,@Item_Desc,@PO_No,@PO_Date,@PO_Qty,@Firm_Name,@Supply_Date,@Supply_Qty,@Inspection_Done_By,@Inspection_Date,@Inspection_Status,@Inspection_Remarks)")
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@Inspection_type", RB_Others.Text)
            cmd.Parameters.AddWithValue("@Item_Desc", O_Item_Desc.SelectedItem.Text)
            cmd.Parameters.AddWithValue("@PO_No", P_No.Text)
            cmd.Parameters.AddWithValue("@PO_Date", P_Date.Text)
            cmd.Parameters.AddWithValue("@PO_Qty", P_Q.Text)
            cmd.Parameters.AddWithValue("@Firm_Name", F_Name.Text)
            cmd.Parameters.AddWithValue("@Supply_Date", Sup_Date.Text)
            cmd.Parameters.AddWithValue("@Supply_Qty", S_Q.Text)
            cmd.Parameters.AddWithValue("@Inspection_Done_By", I_Done_By.Text)
            cmd.Parameters.AddWithValue("@Inspection_Date", Ins_Date.Text)
            cmd.Parameters.AddWithValue("@Inspection_Status", I_S.Text)
            cmd.Parameters.AddWithValue("@Inspection_Remarks", Ins_Rem.Text)

            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        End If

        MsgBox("Submitted Successfully")
        Response.Redirect(Request.Url.AbsoluteUri)
    End Sub
End Class