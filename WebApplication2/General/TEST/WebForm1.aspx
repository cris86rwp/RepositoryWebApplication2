<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm1.aspx.vb" Inherits="WebApplication2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="RAIL WHEEL PLANT/BELA" CssClass="auto-style1" Font-Bold="True" Font-Overline="False" Font-Size="Large" Font-Strikeout="False" Font-Underline="True"></asp:Label>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" BorderColor="Black" BorderStyle="None" Height="30px" Text="FEEDBACK ON CUSTOMER SATISFACTION   " Font-Size="Medium" Font-Underline="True" Width="381px"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;
        &nbsp;
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <table>  
          
        <tr>  
            <td>   </td>  
            <td>&nbsp;&nbsp;
                <asp:Label ID="Label30" runat="server" Text="1"></asp:Label>
&nbsp;&nbsp;
                <asp:Label ID="Label31" runat="server" Text="2"></asp:Label>
&nbsp;&nbsp;
                <asp:Label ID="Label32" runat="server" Text="3"></asp:Label>
&nbsp;&nbsp;
                <asp:Label ID="Label33" runat="server" Text="4"></asp:Label>
&nbsp;&nbsp;
                <asp:Label ID="Label34" runat="server" Text="5"></asp:Label>
            </td>  
            
        </tr>  
        <tr>  
            <td>  
                <asp:Label ID="Labe27" runat="server"   
                    Text="1. Quality of Product"></asp:Label>  
            </td>  
            <td>  
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" DataTextField="ans"   
                    DataValueField="ans" RepeatDirection="Horizontal">  
                    <asp:ListItem>1</asp:ListItem>  
                    <asp:ListItem></asp:ListItem>  
                    <asp:ListItem></asp:ListItem>  
                    <asp:ListItem></asp:ListItem> 
		    <asp:ListItem></asp:ListItem>  
                    
		</asp:RadioButtonList>  
            </td>  
              
        </tr>  
        <tr>  
            <td>  
                <asp:Label ID="Label28" runat="server" Text="2. Quality of wheel ID indication on wheel"></asp:Label>  
            </td>  
            <td>  
                <asp:RadioButtonList ID="RadioButtonList2" runat="server" DataTextField="ans1"   
                    DataValueField="ans1" RepeatDirection="Horizontal">  
                    <asp:ListItem></asp:ListItem>  
                    <asp:ListItem></asp:ListItem>  
                    <asp:ListItem></asp:ListItem>  
                    <asp:ListItem></asp:ListItem> 
		    <asp:ListItem></asp:ListItem> 		</asp:RadioButtonList>  
            </td>  
              
        </tr>  
        <tr>  
            <td>  
                <asp:Label ID="Label29" runat="server"   
                    Text="3. Scheduled Delivery"></asp:Label>  
            </td>  
            <td>  
                <asp:RadioButtonList ID="RadioButtonList3" runat="server" DataTextField="ans2"   
                    DataValueField="ans2" RepeatDirection="Horizontal">  
                    <asp:ListItem></asp:ListItem>  
                    <asp:ListItem></asp:ListItem>  
                    <asp:ListItem></asp:ListItem>  
                    <asp:ListItem></asp:ListItem> 
		            <asp:ListItem></asp:ListItem> 		

                </asp:RadioButtonList>  
            </td>  
             
        </tr>  
        <tr>  
            <td class="auto-style1">  
                <asp:Label ID="Label4" runat="server"   
                    Text="4. Customer education"></asp:Label>  
            </td>  
            <td class="auto-style1">  
                <asp:RadioButtonList ID="RadioButtonList4" runat="server" DataTextField="ans2"   
                    DataValueField="ans2" RepeatDirection="Horizontal">  
                    <asp:ListItem></asp:ListItem>  
                    <asp:ListItem></asp:ListItem>  
                    <asp:ListItem></asp:ListItem>  
                    <asp:ListItem></asp:ListItem> 
		            <asp:ListItem></asp:ListItem> 		

                </asp:RadioButtonList>  
            </td>  
             
        </tr>  
            <tr>  
            <td>  
                <asp:Label ID="Label5" runat="server"   
                    Text="5. Response to customer query"></asp:Label>  
            </td>  
            <td>  
                <asp:RadioButtonList ID="RadioButtonList5" runat="server" DataTextField="ans2"   
                    DataValueField="ans2" RepeatDirection="Horizontal">  
                    <asp:ListItem></asp:ListItem>  
                    <asp:ListItem></asp:ListItem>  
                    <asp:ListItem></asp:ListItem>  
                    <asp:ListItem></asp:ListItem> 
		            <asp:ListItem></asp:ListItem> 		

                </asp:RadioButtonList>  
            </td>  
             
        </tr>  
            <tr>  
            <td>  
                <asp:Label ID="Label7" runat="server"   
                    Text="6. Provision of product Quality Certificate"></asp:Label>  
            </td>  
            <td>  
                <asp:RadioButtonList ID="RadioButtonList6" runat="server" DataTextField="ans2"   
                    DataValueField="ans2" RepeatDirection="Horizontal">  
                    <asp:ListItem></asp:ListItem>  
                    <asp:ListItem></asp:ListItem>  
                    <asp:ListItem></asp:ListItem>  
                    <asp:ListItem></asp:ListItem> 
		            <asp:ListItem></asp:ListItem> 		

                </asp:RadioButtonList>  
            </td>  
             
        </tr>  
            <tr>  
            <td>  
                <asp:Label ID="Label8" runat="server"   
                    Text="7. Attitude of RWF officials and staff while dealing with customer"></asp:Label>  
            </td>  
            <td>  
                <asp:RadioButtonList ID="RadioButtonList7" runat="server" DataTextField="ans2"   
                    DataValueField="ans2" RepeatDirection="Horizontal">  
                    <asp:ListItem></asp:ListItem>  
                    <asp:ListItem></asp:ListItem>  
                    <asp:ListItem></asp:ListItem>  
                    <asp:ListItem></asp:ListItem> 
		            <asp:ListItem></asp:ListItem> 		

                </asp:RadioButtonList>  
            </td>  
             
        </tr>  
            <tr>  
            <td>  
                <asp:Label ID="Label9" runat="server"   
                    Text="8. Response to complaints"></asp:Label>  
            </td>  
            <td>  
                <asp:RadioButtonList ID="RadioButtonList8" runat="server" DataTextField="ans2"   
                    DataValueField="ans2" RepeatDirection="Horizontal">  
                    <asp:ListItem></asp:ListItem>  
                    <asp:ListItem></asp:ListItem>  
                    <asp:ListItem></asp:ListItem>  
                    <asp:ListItem></asp:ListItem> 
		            <asp:ListItem></asp:ListItem> 		

                </asp:RadioButtonList>  
            </td>  
             
        </tr>  
            <tr>  
            <td>  
                <asp:Label ID="Label10" runat="server"   
                    Text="9. Promptness in providing required informaiton to customer"></asp:Label>  
            </td>  
            <td>  
                <asp:RadioButtonList ID="RadioButtonList9" runat="server" DataTextField="ans2"   
                    DataValueField="ans2" RepeatDirection="Horizontal">  
                    <asp:ListItem></asp:ListItem>  
                    <asp:ListItem></asp:ListItem>  
                    <asp:ListItem></asp:ListItem>  
                    <asp:ListItem></asp:ListItem> 
		            <asp:ListItem></asp:ListItem> 		

                </asp:RadioButtonList>  
            </td>  
             
        </tr>  
            <tr>  
            <td>  
                <asp:Label ID="Label11" runat="server"   
                    Text="10. Promptness in warranty replacement"></asp:Label>  
            </td>  
            <td>  
                <asp:RadioButtonList ID="RadioButtonList10" runat="server" DataTextField="ans2"   
                    DataValueField="ans2" RepeatDirection="Horizontal">  
                    <asp:ListItem></asp:ListItem>  
                    <asp:ListItem></asp:ListItem>  
                    <asp:ListItem></asp:ListItem>  
                    <asp:ListItem></asp:ListItem> 
		            <asp:ListItem></asp:ListItem> 		

                </asp:RadioButtonList>  
            </td>  
             
        </tr>  
            <tr>  
            <td>  
                <asp:Label ID="Label27" runat="server"   
                    Text="11. Promptness in complaint handling"></asp:Label>  
            </td>  
            <td>  
                <asp:RadioButtonList ID="RadioButtonList11" runat="server" DataTextField="ans2"   
                    DataValueField="ans2" RepeatDirection="Horizontal">  
                    <asp:ListItem></asp:ListItem>  
                    <asp:ListItem></asp:ListItem>  
                    <asp:ListItem></asp:ListItem>  
                    <asp:ListItem></asp:ListItem> 
		            <asp:ListItem></asp:ListItem> 		

                </asp:RadioButtonList>  
            </td>  
             
        </tr>  

             
         
    </table> 
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label6" runat="server" Font-Size="Large" Text="Scale Indicates :"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label12" runat="server" Text="1 :"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label17" runat="server" Text="NOT SATISFACTORY"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label13" runat="server" Text="2 :"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label18" runat="server" Text="SATISFACTORY"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label14" runat="server" Text="3 :"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label19" runat="server" Text="GOOD"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label15" runat="server" Text="4 :"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label20" runat="server" Text="VERY GOOD"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label16" runat="server" Text="5 :"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label21" runat="server" Text="EXCELLENT"></asp:Label>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:HyperLink ID="HyperLink1" runat="server" Font-Size="Large" NavigateUrl="~/WebForm2.aspx">Suggestion if any to improve customer service/product</asp:HyperLink>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label22" runat="server" Text="DATE :"></asp:Label>
        &nbsp;&nbsp;<asp:TextBox ID="UDate" runat="server" Width="55px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label23" runat="server" Text="PLACE :"></asp:Label>
        &nbsp;&nbsp;<asp:TextBox ID="TextBox1" runat="server" Width="55px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label24" runat="server" Text="CUSTOMER'S SIGNATURE  WITH OFFICE SEAL :"></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label25" runat="server" Text="Email ID -"></asp:Label>
        &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
        <asp:TextBox ID="TextBox3" runat="server" Width="170px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label26" runat="server" Text="Contact No. -"></asp:Label>
        &nbsp;&nbsp;
        <asp:TextBox ID="TextBox4" runat="server" Width="137px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="SUBMIT" />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <div>
        </div>
    </form>
</body>
</html>
