<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Stock_Item_Form.aspx.vb" Inherits="WebApplication2.Stock_Item_Form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
       
            <div style="text-align:center;">
            
                <h1 class="heading">
                        <asp:Label ID="Heading" runat="server" Text="Stock Item Inspection Details" BackColor="Yellow" BorderStyle="Inset" Font-Bold="True" Font-Size="25px"  TabIndex="5"></asp:Label>
                 </h1>
               <br />
                <br />
              
             
              <div class="row" >
                   <div class="col" >
                       </div>
                   <div class="col" >
                         <asp:RadioButton ID="RB_SSE" runat="server" GroupName="A" Text="By SSE/MR" AutoPostBack="True" Font-Bold="True" Height="30px" />
                    </div>   
                   <div class="col" >
                       <asp:RadioButton ID="RB_Others" runat="server" GroupName="A" Text="By Others" AutoPostBack="True" Font-Bold="True" Height="30px" />
                  </div>
                   <div class="col" >
                    </div>
              </div>
            <asp:Panel ID="P_SSE" runat="server" Visible="False" Width="1300px">
               
                
                 <br />
               <div class="row">
                   <div class="col" >
                <asp:Label ID="L_Item_Desc" runat="server" Height="30px" TabIndex="5" Text="Item Desc" Width="120px"></asp:Label>
                <asp:DropDownList ID="Item_Desc" runat="server" AutoPostBack="True" Height="30px" TabIndex="5" Width="120px">
                    <asp:ListItem>Q</asp:ListItem>
                    <asp:ListItem>W</asp:ListItem>
                    <asp:ListItem>E</asp:ListItem>
                    <asp:ListItem>R</asp:ListItem>
                </asp:DropDownList>
                  </div>
                   <div class="col" >
                   <asp:Label ID="L_PO_No" runat="server" Height="30px" TabIndex="5" Text="PO No" Width="120px"></asp:Label>
                   <asp:TextBox ID="PO_No" runat="server" Height="30px" TabIndex="5" Width="120px"></asp:TextBox>
                </div>
                  <div class="col" >
                       <asp:Label ID="L_PO_Date" runat="server" Height="30px" TabIndex="5" Text="PO Date" Width="120px"></asp:Label>
                   <asp:TextBox ID="PO_Date" runat="server" Height="30px" TabIndex="5" Width="120px" placeholder="YYYY-MM-DD"></asp:TextBox>
                   </div>
                   </div>
                <br />
                <br />

                <div class="row" >
                    <div class="col" >
                       <asp:Label ID="L_PO_Qty" runat="server" Text="PO Qty" Height="30px" TabIndex="5" Width="120px"></asp:Label>
                       <asp:TextBox ID="PO_Qty" runat="server" Height="30px" TabIndex="5" Width="120px" ></asp:TextBox>
                    </div>
                   
                     <div class="col" >
                        <asp:Label ID="L_Firm_Name" runat="server" Height="30px" TabIndex="5" Text="Firm Name" Width="120px"></asp:Label>
                        <asp:TextBox ID="Firm_Name" runat="server" Height="30px" TabIndex="5" Width="120px"></asp:TextBox>
                      </div>

                    <div class="col" >
                         <asp:Label ID="L_S_Date" runat="server" Height="30px" TabIndex="5" Text="Supply Date" Width="120px"></asp:Label>
                         <asp:TextBox ID="S_Date" runat="server" Height="30px" TabIndex="5" Width="120px" placeholder="YYYY-MM-DD"></asp:TextBox>
                    </div>
                </div>
                <br />
                <br />
                <div class="row" >
                    <div class="col" >
                        <asp:Label ID="L_S_Qty" runat="server" Height="30px" TabIndex="5" Text="Supply Qty" Width="120px"></asp:Label>
                        <asp:TextBox ID="S_Qty" runat="server" Height="30px" TabIndex="5" Width="120px"></asp:TextBox>
                    </div>
                
                    <div class="col" >
                         <asp:Label ID="L_I_Date" runat="server" Height="30px" TabIndex="5" Text="Inspection Date" Width="120px"></asp:Label>
                         <asp:TextBox ID="I_Date" runat="server" Height="30px" TabIndex="5" Width="120px" placeholder="YYYY-MM-DD"></asp:TextBox>
                    </div>
                
                   <div class="col" > 
                         <asp:Label ID="L_I_Status" runat="server" Height="30px" TabIndex="5" Text="Inspection Status" Width="120px"></asp:Label>
                         <asp:TextBox ID="I_Status" runat="server" Height="30px" TabIndex="5" Width="120px"></asp:TextBox>
                    </div>
                </div>

                <br />
               
                
                <div class="row" >
                    <div class="col" >
                         <asp:Label ID="L_R_S_Date" runat="server" Height="30px" TabIndex="5" Text="Report Submission Date" Width="120px"></asp:Label>
                         <asp:TextBox ID="R_S_Date" runat="server" Height="30px" TabIndex="5" Width="120px" placeholder="YYYY-MM-DD"></asp:TextBox>
                    </div>
               
                    <div class="col" >
                        <asp:Label ID="L_I_Remarks" runat="server" Height="30px" TabIndex="5" Text="Inspection Remarks" Width="120px"></asp:Label>
                         <asp:TextBox ID="I_Remarks" runat="server" Height="30px" TabIndex="5" Width="120px"></asp:TextBox>
                    </div>
                    <div class="col" >
                        </div>
                </div>
                        
                        </asp:Panel>
           
           
            <asp:Panel ID="P_Others" runat="server" Visible="False"  Width="1300px">
               
               <br />
              <div class="row" >
                  <div class="col" >
                        <asp:Label ID="L_I_D" runat="server" Height="30px" TabIndex="5" Text="Item Desc" Width="120px"></asp:Label>
                        <asp:DropDownList ID="O_Item_Desc" runat="server" AutoPostBack="True" Height="30px" TabIndex="5" Width="120px">
                         <asp:ListItem>A</asp:ListItem>
                            <asp:ListItem>B</asp:ListItem>
                            <asp:ListItem>C</asp:ListItem>
                            <asp:ListItem>D</asp:ListItem>
                         </asp:DropDownList>
                 </div>
                
                  <div class="col" >
                         <asp:Label ID="L_P_No" runat="server" Height="30px" TabIndex="5" Text="PO No" Width="120px"></asp:Label>
                         <asp:TextBox ID="P_No" runat="server" Height="30px" TabIndex="5" Width="120px"></asp:TextBox>
                 </div>
                     
                 <div class="col" >
                         <asp:Label ID="L_P_Date" runat="server" Height="30px" TabIndex="5" Text="PO Date" Width="120px"></asp:Label>
                         <asp:TextBox ID="P_Date" runat="server" Height="30px" TabIndex="5" Width="120px" placeholder="YYYY-MM-DD"></asp:TextBox>
                </div>
            </div>

                <br />
                <br />
            <div class="row" >
                 <div class="col" >
                         <asp:Label ID="L_P_Q" runat="server" Text="PO Qty" Height="30px" TabIndex="5" Width="120px"></asp:Label>
                         <asp:TextBox ID="P_Q" runat="server" Height="30px" TabIndex="5" Width="120px" ></asp:TextBox>
                </div>
                
                <div class="col" >
                         <asp:Label ID="L_F_Name" runat="server" Height="30px" TabIndex="5" Text="Firm Name" Width="120px"></asp:Label>
                         <asp:TextBox ID="F_Name" runat="server" Height="30px" TabIndex="5" Width="120px"></asp:TextBox>
                </div>
                    
                <div class="col" >
                         <asp:Label ID="L_Sup_Date" runat="server" Height="30px" TabIndex="5" Text="Supply Date" Width="120px"></asp:Label>
                         <asp:TextBox ID="Sup_Date" runat="server" Height="30px" TabIndex="5" Width="120px" placeholder="YYYY-MM-DD"></asp:TextBox>
                </div>
            </div>
                <br />
                <br />

            <div class="row" >
                 <div class="col" >
                         <asp:Label ID="L_S_Q" runat="server" Height="30px" TabIndex="5" Text="Supply Qty" Width="120px"></asp:Label>
                         <asp:TextBox ID="S_Q" runat="server" Height="30px" TabIndex="5" Width="120px"></asp:TextBox>
                 </div>
                     
                 <div class="col" >
                         <asp:Label ID="L_I_Done_By" runat="server" Height="30px" TabIndex="5" Text="Inspection Done By" Width="120px"></asp:Label>
                         <asp:TextBox ID="I_Done_By" runat="server" Height="30px" TabIndex="5" Width="120px"></asp:TextBox>
                 </div>
                     
                 <div class="col" >
                         <asp:Label ID="L_Ins_Date" runat="server" Height="30px" TabIndex="5" Text="Inspection Date" Width="120px"></asp:Label>
                         <asp:TextBox ID="Ins_Date" runat="server" Height="30px" TabIndex="5" Width="120px" placeholder="YYYY-MM-DD"></asp:TextBox>
                 </div>
            </div>         
                     
                     <br />
                     <br />

            <div class="row" >
                <div class="col" >
                         <asp:Label ID="L_I_S" runat="server" Height="30px" TabIndex="5" Text="Inspection Status" Width="120px"></asp:Label>
                         <asp:TextBox ID="I_S" runat="server" Height="30px" TabIndex="5" Width="120px"></asp:TextBox>
                </div>
                    
                 <div class="col" >
                         <asp:Label ID="L_Ins_Rem" runat="server" Height="30px" TabIndex="5" Text="Inspection Remarks" Width="120px"></asp:Label>
                         <asp:TextBox ID="Ins_Rem" runat="server" Height="30px" TabIndex="5" Width="120px"></asp:TextBox>
                  </div>
                <div class="col" >
                 </div>
            </div>
                     
                     
                     </asp:Panel>
            <br />
                 <br />
            <br />
           
        
            <asp:Button ID="Submit" runat="server" Text="Submit" BackColor="#00CCFF" BorderStyle="Solid" Font-Bold="True" Font-Size="25px" Visible="False" />
            
            
            </div>
      </div>      
       
    </form>
</body>
</html>
