<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="sand_recipe_table.aspx.vb" Inherits="WebApplication2.sand_recipe_table" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        //for date
        function isNumber1(evt, element) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (
                           (charCode != 45 ) && (charCode != 47 ) &&     // 
                           (charCode < 48 || charCode > 57))
                      return false;
                    return true;
        } 
    </script>
</head>
<body>
    <div class="container">
        <form id="form1" runat="server">
            <asp:Panel ID="panel1" runat="server">
                <div class="row">
                    <div class="table-responsive">
                        <table>
                            <tr>
                                <th> <asp:Label ID="lbl_date" runat="server">Date</asp:Label></th>
                                <td> <asp:TextBox ID="tbx_date" runat="server" ToolTip="date format" onkeypress="return isNumber1(event,this)" MaxLength="10"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <th> <asp:Label ID="lbl_sand" runat="server">Sand Weight</asp:Label>(Kgs)</th>
                                <td> <asp:TextBox ID="tbx_sand" runat="server" CssClass="button button2"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <th> <asp:Label ID="lbl_resin_prcntg" runat="server">Resin Percentage</asp:Label></th>
                                <td> <asp:TextBox ID="tbx_resin_prcntg" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <th> <asp:Label ID="lbl_resin_wght" runat="server">Resin Weight</asp:Label>(kgs)</th>
                                <td> <asp:TextBox ID="tbx_resin_wght" runat="server"></asp:TextBox> </td>
                            </tr>
                            <tr> 
                                <th> <asp:Label ID="lbl_hexa_sol" runat="server">Hexa Solution Weight</asp:Label>(kgs)</th>
                                <td> <asp:TextBox ID="tbx_hexa_sol" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <th> <asp:Label ID="lbl_pre_mix_time" runat="server">Pre Mix Time(Wet Mulling Time)(sec) </asp:Label></th>
                                <td> <asp:TextBox ID="tbx_pre_mix_time" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <th> <asp:Label ID="lbl_main_mix" runat="server">Main Mix Time(Dry Mulling Time)(sec) </asp:Label></th>
                                <td> <asp:TextBox ID="tbx_main_mix" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <th> <asp:Label ID="lbl_sand_intemp" runat="server">Sand Incoming Temperature</asp:Label></th>
                                <td> <asp:TextBox ID="tbx_sand_intemp" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <th> <asp:Label ID="lbl_sand_outtemp" runat="server">Sand Outgoing Temperature</asp:Label></th>
                                <td> <asp:TextBox ID="tbx_sand_outtemp" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <th> <asp:Label ID="lbl_hexa_wtr" runat="server">Water in Hexa Solution</asp:Label></th>
                                <td> <asp:TextBox ID="tbx_hexa_wtr" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <th> <asp:Label ID="lbl_hexa_powder" runat="server">Hexa Powder in Hexa Solution</asp:Label></th>
                                <td> <asp:TextBox ID="tbx_hexa_powder" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <th> <asp:Label ID="lbl_cts" runat="server">CTS Required</asp:Label></th>
                                <td> <asp:TextBox ID="tbx_cts" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <th> <asp:Label ID="lbl_hts" runat="server">HTS Required</asp:Label></th>
                                <td> <asp:TextBox ID="tbx_hts" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <th> <asp:Label ID="lbl_stick_pt" runat="server">Stick Point Required</asp:Label></th>
                                <td> <asp:TextBox ID="tbx_stick_pt" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <th> <asp:Label ID="lbl_timer_set" runat="server">Timer Setting to get 2kgs Hexa Solution</asp:Label></th>
                                <td> <asp:TextBox ID="tbx_timer_set" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <th> <asp:Label ID="lbl_sand_silo" runat="server">Sand temperature setting to go to SILO</asp:Label></th>
                                <td> <asp:TextBox ID="tbx_sand_silo" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                               <th> <asp:Label ID="lbl_remarks" runat="server">Remarks</asp:Label></th>
                                <td> <asp:TextBox ID="tbx_remarks" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>

                                <td>
                                    <asp:Button ID="btn_save" runat="server" text="Save"  CommandName="save"/>
                                </td>
                                <td>
                                    
                                </td>
                                <td>
                                      <asp:Button ID="btn_exit" runat="server" text="Exit"  CommandName="save"/>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </asp:Panel>
        </form>
    </div>
    
</body>
</html>
