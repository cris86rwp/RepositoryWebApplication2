
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class FeedbackForm
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand


    Protected WithEvents SuggestionBox As System.Web.UI.WebControls.TextBox
    Protected WithEvents SubButton As System.Web.UI.WebControls.Button

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles SubButton.Click

        If Umail.Text = String.Empty Then


            MsgBox("Email cannot be empty")
            Exit Sub
        End If

        Dim rd1 As String
        If QOP_1.Checked Then
            rd1 = "1"
        ElseIf (QOP_2.Checked) Then
            rd1 = "2"
        ElseIf (QOP_3.Checked) Then
            rd1 = "3"
        ElseIf (QOP_4.Checked) Then
            rd1 = "4"
        ElseIf (QOP_5.Checked) Then
            rd1 = "5"
        End If

        Dim rd2 As String
        If QOWIIOW_1.Checked Then
            rd2 = "1"
        ElseIf (QOWIIOW_2.Checked) Then
            rd2 = "2"
        ElseIf (QOWIIOW_3.Checked) Then
            rd2 = "3"
        ElseIf (QOWIIOW_4.Checked) Then
            rd2 = "4"
        ElseIf (QOWIIOW_5.Checked) Then
            rd2 = "5"
        End If

        Dim rd3 As String
        If SD_1.Checked Then
            rd3 = "1"
        ElseIf (SD_2.Checked) Then
            rd3 = "2"
        ElseIf (SD_3.Checked) Then
            rd3 = "3"
        ElseIf (SD_4.Checked) Then
            rd3 = "4"
        ElseIf (SD_5.Checked) Then
            rd3 = "5"
        End If

        Dim rd4 As String
        If CEOHASP_1.Checked Then
            rd4 = "1"
        ElseIf (CEOHASP_2.Checked) Then
            rd4 = "2"
        ElseIf (CEOHASP_3.Checked) Then
            rd4 = "3"
        ElseIf (CEOHASP_4.Checked) Then
            rd4 = "4"
        ElseIf (CEOHASP_5.Checked) Then
            rd4 = "5"
        End If

        Dim rd5 As String
        If RTCQ_1.Checked Then
            rd5 = "1"
        ElseIf (RTCQ_2.Checked) Then
            rd5 = "2"
        ElseIf (RTCQ_3.Checked) Then
            rd5 = "3"
        ElseIf (RTCQ_4.Checked) Then
            rd5 = "4"
        ElseIf (RTCQ_5.Checked) Then
            rd5 = "5"
        End If

        Dim rd6 As String
        If POPQC_1.Checked Then
            rd6 = "1"
        ElseIf (POPQC_2.Checked) Then
            rd6 = "2"
        ElseIf (POPQC_3.Checked) Then
            rd6 = "3"
        ElseIf (POPQC_4.Checked) Then
            rd6 = "4"
        ElseIf (POPQC_5.Checked) Then
            rd6 = "5"
        End If

        Dim rd7 As String
        If AOROASWDWC_1.Checked Then
            rd7 = "1"
        ElseIf (AOROASWDWC_2.Checked) Then
            rd7 = "2"
        ElseIf (AOROASWDWC_3.Checked) Then
            rd7 = "3"
        ElseIf (AOROASWDWC_4.Checked) Then
            rd7 = "4"
        ElseIf (AOROASWDWC_5.Checked) Then
            rd7 = "5"
        End If

        Dim rd8 As String
        If RTC_1.Checked Then
            rd8 = "1"
        ElseIf (RTC_2.Checked) Then
            rd8 = "2"
        ElseIf (RTC_3.Checked) Then
            rd8 = "3"
        ElseIf (RTC_4.Checked) Then
            rd8 = "4"
        ElseIf (RTC_5.Checked) Then
            rd8 = "5"
        End If

        Dim rd9 As String
        If PIPRITC_1.Checked Then
            rd9 = "1"
        ElseIf (PIPRITC_2.Checked) Then
            rd9 = "2"
        ElseIf (PIPRITC_3.Checked) Then
            rd9 = "3"
        ElseIf (PIPRITC_4.Checked) Then
            rd9 = "4"
        ElseIf (PIPRITC_5.Checked) Then
            rd9 = "5"
        End If

        Dim rd10 As String
        If PIWR_1.Checked Then
            rd10 = "1"
        ElseIf (PIWR_2.Checked) Then
            rd10 = "2"
        ElseIf (PIWR_3.Checked) Then
            rd10 = "3"
        ElseIf (PIWR_4.Checked) Then
            rd10 = "4"
        ElseIf (PIWR_5.Checked) Then
            rd10 = "5"
        End If

        Dim rd11 As String
        If PICH_1.Checked Then
            rd11 = "1"
        ElseIf (PICH_2.Checked) Then
            rd11 = "2"
        ElseIf (PICH_3.Checked) Then
            rd11 = "3"
        ElseIf (PICH_4.Checked) Then
            rd11 = "4"
        ElseIf (PICH_5.Checked) Then
            rd11 = "5"
        End If





        Dim con As SqlConnection = New SqlConnection()
        con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Purva\source\repos\WebApplication1\WebApplication1\App_Data\FeedbackDatabase.mdf;Integrated Security=True"
        Dim cmd As New SqlCommand("INSERT INTO FeedbackDB(Email,Date,Place,Contact_No,ProductQuality,WheelQuality,ScheduledDelivery,CustHandlingStoringProduct,RespToCustQuery,ProdQualCert,RWPAttitude,ResponseToComplaints,InfoToCust,WarrantyReplacement,ComplaintHandling,Suggestions)
VALUES(@Email,@Date,@Place,@Contact_No,@ProductQuality,@WheelQuality,@ScheduledDelivery,@CustHandlingStoringProduct,@RespToCustQuery,@ProdQualCert,@RWPAttitude,@ResponseToComplaints,@InfoToCust,@WarrantyReplacement,@ComplaintHandling,@Suggestions)")
        cmd.Connection = con
        cmd.Parameters.AddWithValue("@Email", Umail.Text)
        cmd.Parameters.AddWithValue("@Date", UDate.Text)
        cmd.Parameters.AddWithValue("@Place", UPlace.Text)
        cmd.Parameters.AddWithValue("@Contact_No", Umobile.Text)

        'cmd.Parameters.AddWithValue("@Date", DropDownList1.SelectedItem.Text)
        cmd.Parameters.AddWithValue("@ProductQuality", rd1)
        cmd.Parameters.AddWithValue("@WheelQuality", rd2)
        cmd.Parameters.AddWithValue("@ScheduledDelivery", rd3)
        cmd.Parameters.AddWithValue("@CustHandlingStoringProduct", rd4)
        cmd.Parameters.AddWithValue("@RespToCustQuery", rd5)
        cmd.Parameters.AddWithValue("@ProdQualCert", rd6)
        cmd.Parameters.AddWithValue("@RWPAttitude", rd7)
        cmd.Parameters.AddWithValue("@ResponseToComplaints", rd8)
        cmd.Parameters.AddWithValue("@InfoToCust", rd9)
        cmd.Parameters.AddWithValue("@WarrantyReplacement", rd10)
        cmd.Parameters.AddWithValue("@ComplaintHandling", rd11)
        cmd.Parameters.AddWithValue("@Suggestions", SuggestionBox.Text)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()






        MsgBox("Submission Successful")
        Response.Redirect(Request.Url.AbsoluteUri)
    End Sub

    Protected Sub SuggestionBox_TextChanged(sender As Object, e As EventArgs) Handles SuggestionBox.TextChanged

    End Sub
End Class