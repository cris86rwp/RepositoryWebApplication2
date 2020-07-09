Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration


Public Class NonStockMatDetails
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub DemandRB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DemandRB.CheckedChanged
        If DemandRB.Checked = True Then
            Panel1.Visible = True
            Panel2.Visible = False
            SubBut1.Visible = True
        End If

    End Sub

    Protected Sub SubBut1_Click(sender As Object, e As EventArgs) Handles SubBut1.Click

        If ItmDsc_Txtbx.Text = String.Empty Then


            MsgBox("Item Description cannot be empty")
            Exit Sub
        End If

        If DOD_Txtbx.Text = String.Empty Then
            MsgBox("Demand Date cannot be empty")
            Exit Sub

        End If

        Dim con As SqlConnection = New SqlConnection()
        con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Purva\source\repos\WebApplication1\WebApplication1\App_Data\FeedbackDatabase.mdf;Integrated Security=True"
        Dim cmd As New SqlCommand("INSERT INTO NonStockDemand(ItemDesc,DemandDate,Unit,DemandQty,PODetails,ModifiedQty,BQDetails,Remarks,LikelySupplier_1,LikelySupplier_2,LikelySupplier_3)
        VALUES(@ItemDesc,@DemandDate,@Unit,@DemandQty,@PODetails,@ModifiedQty,@BQDetails,@Remarks,@LikelySupplier_1,@LikelySupplier_2,@LikelySupplier_3)")
        cmd.Connection = con
        cmd.Parameters.AddWithValue("@ItemDesc", ItmDsc_Txtbx.Text)
        cmd.Parameters.AddWithValue("@DemandDate", DOD_Txtbx.Text)
        cmd.Parameters.AddWithValue("@Unit", Unit_txtbx.Text)
        cmd.Parameters.AddWithValue("@DemandQty", DQ_Txtb.Text)


        cmd.Parameters.AddWithValue("@PODetails", SDPOD_Txtbx.Text)
        cmd.Parameters.AddWithValue("@ModifiedQty", MQ_Txtbx.Text)
        cmd.Parameters.AddWithValue("@BQDetails", BQD_Txtbx.Text)
        cmd.Parameters.AddWithValue("@Remarks", Remark_Txtbx.Text)
        cmd.Parameters.AddWithValue("@LikelySupplier_1", LS_Txtbx1.Text)
        cmd.Parameters.AddWithValue("@LikelySupplier_2", LS_Txtbx2.Text)
        cmd.Parameters.AddWithValue("@LikelySupplier_3", LS_Txtbx3.Text)

        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        MsgBox("Submission Successful")
    End Sub

    Protected Sub SupInsRB_CheckedChanged(sender As Object, e As EventArgs) Handles SupInsRB.CheckedChanged
        If SupInsRB.Checked = True Then
            Panel2.Visible = True
            Panel1.Visible = False
            SubBut2.Visible = True
        End If
    End Sub

    Protected Sub SubBut2_Click(sender As Object, e As EventArgs) Handles SubBut2.Click

        If PON_txtbx.Text = String.Empty Then


            MsgBox("PO No. cannot be empty")
            Exit Sub
        End If


        Dim con As SqlConnection = New SqlConnection()
        con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Purva\source\repos\WebApplication1\WebApplication1\App_Data\FeedbackDatabase.mdf;Integrated Security=True"
        Dim cmd As New SqlCommand("INSERT INTO NonStockSupply(ItemDesc,DemandDate,Unit,PONo,PODate,FirmName,RepSubDate,Remarks,SupplyDate1,SupplyQty1,MaterialCellLNo1,InspectionDate1,InspectionStatus1,SupplyDate2,SupplyQty2,MaterialCellLNo2,InspectionDate2,InspectionStatus2,SupplyDate3,SupplyQty3,MaterialCellLNo3,InspectionDate3,InspectionStatus3,SupplyDate4,SupplyQty4,MaterialCellLNo4,InspectionDate4,InspectionStatus4,SupplyDate5,SupplyQty5,MaterialCellLNo5,InspectionDate5,InspectionStatus5)
        VALUES(@ItemDesc,@DemandDate,@Unit,@PONo,@PODate,@FirmName,@RepSubDate,@Remarks,@SupplyDate1,@SupplyQty1,@MaterialCellLNo1,@InspectionDate1,@InspectionStatus1,@SupplyDate2,@SupplyQty2,@MaterialCellLNo2,@InspectionDate2,@InspectionStatus2,@SupplyDate3,@SupplyQty3,@MaterialCellLNo3,@InspectionDate3,@InspectionStatus3,@SupplyDate4,@SupplyQty4,@MaterialCellLNo4,@InspectionDate4,@InspectionStatus4,@SupplyDate5,@SupplyQty5,@MaterialCellLNo5,@InspectionDate5,@InspectionStatus5)")


        cmd.Connection = con





        cmd.Parameters.AddWithValue("@ItemDesc", ItmD_Txtbx.Text)
        cmd.Parameters.AddWithValue("@DemandDate", DateOfD_txtbx.Text)
        cmd.Parameters.AddWithValue("@Unit", Val(UT_txtbx.Text))
        cmd.Parameters.AddWithValue("@PONo", PON_txtbx.Text)
        cmd.Parameters.AddWithValue("@PODate", POD_Txtbx.Text)
        cmd.Parameters.AddWithValue("@FirmName", FN_txtbx.Text)
        cmd.Parameters.AddWithValue("@RepSubDate", RSD_txtbx.Text)
        cmd.Parameters.AddWithValue("@Remarks", rem_txtbx.Text)


        cmd.Parameters.AddWithValue("@SupplyDate1", SupDate_1.Text)
        cmd.Parameters.AddWithValue("@SupplyQty1", Val(SupQty_1.Text))
        cmd.Parameters.AddWithValue("@MaterialCellLNo1", Val(MCLN_1.Text))
        cmd.Parameters.AddWithValue("@InspectionDate1", InsDate_1.Text)
        cmd.Parameters.AddWithValue("@InspectionStatus1", InsStat_1.Text)


        cmd.Parameters.AddWithValue("@SupplyDate2", SupDate_2.Text)
        cmd.Parameters.AddWithValue("@SupplyQty2", Val(SupQty_2.Text))
        cmd.Parameters.AddWithValue("@MaterialCellLNo2", Val(MCLN_2.Text))
        cmd.Parameters.AddWithValue("@InspectionDate2", InsDate_2.Text)
        cmd.Parameters.AddWithValue("@InspectionStatus2", InsStat_2.Text)


        cmd.Parameters.AddWithValue("@SupplyDate3", SupDate_3.Text)
        cmd.Parameters.AddWithValue("@SupplyQty3", Val(SupQty_3.Text))
        cmd.Parameters.AddWithValue("@MaterialCellLNo3", Val(MCLN_3.Text))
        cmd.Parameters.AddWithValue("@InspectionDate3", InsDate_3.Text)
        cmd.Parameters.AddWithValue("@InspectionStatus3", InsStat_3.Text)

        cmd.Parameters.AddWithValue("@SupplyDate4", SupDate_4.Text)
        cmd.Parameters.AddWithValue("@SupplyQty4", Val(SupQty_4.Text))
        cmd.Parameters.AddWithValue("@MaterialCellLNo4", Val(MCLN_4.Text))
        cmd.Parameters.AddWithValue("@InspectionDate4", InsDate_4.Text)
        cmd.Parameters.AddWithValue("@InspectionStatus4", InsStat_4.Text)


        cmd.Parameters.AddWithValue("@SupplyDate5", SupDate_5.Text)
        cmd.Parameters.AddWithValue("@SupplyQty5", Val(SupQty_5.Text))
        cmd.Parameters.AddWithValue("@MaterialCellLNo5", Val(MCLN_5.Text))
        cmd.Parameters.AddWithValue("@InspectionDate5", InsDate_5.Text)
        cmd.Parameters.AddWithValue("@InspectionStatus5", InsStat_5.Text)



        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()


        MsgBox("Submission Successful")
        Response.Redirect(Request.Url.AbsoluteUri)
    End Sub

    Protected Sub POD_Txtbx_TextChanged(sender As Object, e As EventArgs) Handles POD_Txtbx.TextChanged
        If Len(POD_Txtbx.Text) < 10 Then
            MsgBox("You have entered incorrect date")
            POD_Txtbx.Focus()
        End If
    End Sub
End Class