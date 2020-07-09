<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="NonStockMatDetails.aspx.vb" Inherits="WebApplication2.NonStockMatDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <div style="text-align: center;">
        <asp:Label ID="NSMPD" runat="server" Text="NON STOCK MATERIAL PROCUREMENT DETAILS" Font-Bold="True" Font-Size="Large" Font-Underline="True"></asp:Label>
        
        <br />
        <br />
        
        <div class="row">
              
       <div class="col">
            
        <asp:RadioButton ID="DemandRB" runat="server" AutoPostBack="True" GroupName="A" Text="Demand" />
        </div>
        <div class="col">
            <asp:RadioButton ID="SupInsRB" runat="server" AutoPostBack="True" GroupName="A" Text="Supply &amp; Inspection" />
        </div>
         </div>
       
            <br />
        <br />
       
        <asp:Panel ID="Panel1" runat="server" Height="314px" Visible="False">
            <div class="row">
                <div class="col">  
            <asp:Label ID="Itm_dsc" runat="server" Text="Item Desc" Height="30px" TabIndex="5" Width="120px"></asp:Label>
            
            <asp:TextBox ID="ItmDsc_Txtbx" runat="server" Height="30px" TabIndex="5" Width="120px"></asp:TextBox>
                </div>
                
                <div class="col"> 
            <asp:Label ID="DOD" runat="server" Text="Date of Demands" Height="30px" TabIndex="5" Width="120px"></asp:Label>
            <asp:TextBox ID="DOD_Txtbx" runat="server" Height="30px" TabIndex="5" Width="120px" placeholder="YYYY-MM-DD"></asp:TextBox>
                </div>
                <div class="col">  
                <asp:Label ID="Unit" runat="server" Text="Unit" Height="30px" TabIndex="5" Width="120px"></asp:Label>
            
            <asp:TextBox ID="Unit_txtbx" runat="server" Height="30px" TabIndex="5" Width="120px"></asp:TextBox>
                </div>
            </div>
            <br />
            
           <div class="row">
                <div class="col">  
            <asp:Label ID="DQ" runat="server" Text="Demand Qty" Height="30px" TabIndex="5" Width="120px"></asp:Label>
            <asp:TextBox ID="DQ_Txtb" runat="server" Height="30px" TabIndex="5" Width="120px"></asp:TextBox>
                    </div>
                <div class="col">  
            <asp:Label ID="SDPOD" runat="server" Text="Spec/Drawing/PO Details" Height="30px" TabIndex="5" Width="120px"></asp:Label>
            <asp:TextBox ID="SDPOD_Txtbx" runat="server" Height="30px" TabIndex="5" Width="120px"></asp:TextBox>
                 </div>
                <div class="col">
               <asp:Label ID="MQ" runat="server" Text="Modified Qty" Height="30px" TabIndex="5" Width="120px"></asp:Label>
            <asp:TextBox ID="MQ_Txtbx" runat="server" Height="30px" TabIndex="5" Width="120px"></asp:TextBox>
            
                     </div>
               </div>
            <br />
            <div class="row">
                 <div class="col">
            <asp:Label ID="BQD" runat="server" Text="BQ Details" Height="30px" TabIndex="5" Width="120px"></asp:Label>
            <asp:TextBox ID="BQD_Txtbx" runat="server" Height="30px" TabIndex="5" Width="120px"></asp:TextBox>
                      </div>
           
                
           
            <div class="col text-center">
            <table border="1">
                <tr>
                    <td></td>
                    <td >
                        <asp:Label ID="Label30" runat="server" Text="Likely Suppliers"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label31" runat="server" Text="1"></asp:Label>
                        
                    </td>
                    <td>
                        <asp:TextBox ID="LS_Txtbx1" runat="server"></asp:TextBox>
                        
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label9" runat="server" Text="2"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="LS_Txtbx2" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label10" runat="server" Text="3"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="LS_Txtbx3" runat="server"></asp:TextBox>
                    </td>
                </tr>
                
                
            </table>
                </div>
                 <div class="col">
            <asp:Label ID="Remarks" runat="server" Text="Remarks" Height="30px" TabIndex="5" Width="120px"></asp:Label>
           <asp:TextBox ID="Remark_Txtbx" runat="server" Height="30px" TabIndex="5" Width="120px"></asp:TextBox>
                </div>
               
            </div>
            <br />
            <br />
            <br />
            <asp:Button ID="SubBut1" runat="server" Text="Submit" />
            <br />
            
            
            
        </asp:Panel>
        <br />
           <div class="container"> 
        <asp:Panel ID="Panel2" runat="server" Height="422px" Visible="False">
            <div class="row">
                <div class="col">
            <asp:Label ID="ItmDsc" runat="server" Text="Item Desc" Height="30px" TabIndex="5" Width="120px"></asp:Label>
            <asp:TextBox ID="ItmD_Txtbx" runat="server" Height="30px" TabIndex="5" Width="120px"></asp:TextBox>
                </div>
                <div class="col">
            <asp:Label ID="DoD2" runat="server" Text="Date of Demands" Height="30px" TabIndex="5" Width="120px"></asp:Label>
           <asp:TextBox ID="DateOfD_txtbx" runat="server" Height="30px" TabIndex="5" Width="120px" placeholder="YYYY-MM-DD"></asp:TextBox>
                 </div>
                <div class="col">
            <asp:Label ID="UT" runat="server" Text="Unit" Height="30px" TabIndex="5" Width="120px"></asp:Label>
            <asp:TextBox ID="UT_txtbx" runat="server" Height="30px" TabIndex="5" Width="120px"></asp:TextBox>
            </div>
                </div>
            
            <br />
            <br />
            <div class="row">
                <div class="col">
            <asp:Label ID="PONo" runat="server" Text="PO No." Height="30px" TabIndex="5" Width="120px"></asp:Label>
            <asp:TextBox ID="PON_txtbx" runat="server" Height="30px" TabIndex="5" Width="120px"></asp:TextBox>
            </div>
                <div class="col">
            <asp:Label ID="POD" runat="server" Text="PO Date" Height="30px" TabIndex="5" Width="120px"></asp:Label>
            <asp:TextBox ID="POD_Txtbx" runat="server" Height="30px" TabIndex="5" Width="120px" placeholder="YYYY-MM-DD"></asp:TextBox>
            </div>
                <div class="col">
            <asp:Label ID="FN" runat="server" Text="Firm Name" Height="30px" TabIndex="5" Width="120px"></asp:Label>
            <asp:TextBox ID="FN_txtbx" runat="server" Height="30px" TabIndex="5" Width="120px"></asp:TextBox>
            </div>
                </div>
            <br />
            <br />
            <div class="row">
                <div class="col">
            <asp:Label ID="RSD" runat="server" Text="Report Submission Date" Height="30px" TabIndex="5" Width="120px"></asp:Label>
            <asp:TextBox ID="RSD_txtbx" runat="server" Height="30px" TabIndex="5" Width="120px" placeholder="YYYY-MM-DD"></asp:TextBox>
            </div>
            <div class="col">
                <asp:Label ID="Remark" runat="server" Text="Remarks" Height="30px" TabIndex="5" Width="120px"></asp:Label>
            <asp:TextBox ID="rem_txtbx" runat="server"  Height="30px" TabIndex="5" Width="120px"></asp:TextBox>
            </div>
                <div class="col"></div>
                </div>
                <br />
            <br />
           <div class="table-responsive">
            <table border="1" class="table">
              <thead>
                <tr>
                    
                        <th scope="col"><asp:Label ID="ItmDet" runat="server" Text="Item Details" Height="30px" TabIndex="5" Width="120px"></asp:Label></th>
                    <th scope="col">
                        <asp:Label ID="SupDate" runat="server" Text="Supply Date" Height="30px" TabIndex="5" Width="120px"></asp:Label>
                    </th>
                    <th scope="col">
                        <asp:Label ID="SupQty" runat="server" Text="Supply Qty" Height="30px" TabIndex="5" Width="120px"></asp:Label>
                    </th>
                    <th scope="col">
                        <asp:Label ID="MCLN" runat="server" Text="Material Cell L No." Height="30px" TabIndex="5" Width="120px"></asp:Label>
                    </th>
                    <th scope="col">
                        <asp:Label ID="InsDate" runat="server" Text="Inspection Date" Height="30px" TabIndex="5" Width="120px"></asp:Label>
                    </th>
                    <th scope="col">
                        <asp:Label ID="InsStat" runat="server" Text="Inspection Status" Height="30px" TabIndex="5" Width="120px"></asp:Label>
                    </th>
                    
                    
                </tr>
                  </thead>
                <tbody>
                <tr>
                    <th scope="row">
                        <asp:Label ID="Label42" runat="server" Text="1"></asp:Label>
                       
                    </th>
                    <td>
                        <asp:TextBox ID="SupDate_1" runat="server" borderstyle="None" placeholder="YYYY-MM-DD" ></asp:TextBox>
                        
                    </td>
                     <td>
                        <asp:TextBox ID="SupQty_1" runat="server" borderstyle="None" ></asp:TextBox>
                        
                    </td>
                     <td>
                        <asp:TextBox ID="MCLN_1" runat="server" borderstyle="None"></asp:TextBox>
                        
                    </td>
                     <td>
                        <asp:TextBox ID="InsDate_1" runat="server" borderstyle="None" placeholder="YYYY-MM-DD"></asp:TextBox>
                        
                    </td>
                     <td>
                        <asp:TextBox ID="InsStat_1" runat="server" borderstyle="None"></asp:TextBox>
                        
                    </td>
                    
                </tr>
                <tr>
                    <th scope="row" >
                        <asp:Label ID="Label43" runat="server" Text="2"></asp:Label>
                    </th>
                    <td>
                        <asp:TextBox ID="SupDate_2" runat="server" borderstyle="None" placeholder="YYYY-MM-DD"></asp:TextBox>
                    </td>
                     <td>
                        <asp:TextBox ID="SupQty_2" runat="server" borderstyle="None"></asp:TextBox>
                        
                    </td>
                 <td>
                        <asp:TextBox ID="MCLN_2" runat="server" borderstyle="None"></asp:TextBox>
                        
                    </td>
                 <td>
                        <asp:TextBox ID="InsDate_2" runat="server" borderstyle="None" placeholder="YYYY-MM-DD"></asp:TextBox>
                        
                    </td>
                     <td>
                        <asp:TextBox ID="InsStat_2" runat="server" borderstyle="None"></asp:TextBox>
                        
                    </td>
                    
                </tr>
                <tr>
                <th scope="row">
                        <asp:Label ID="Label44" runat="server" Text="3"></asp:Label>
                    </th>
                    <td>
                        <asp:TextBox ID="SupDate_3" runat="server" borderstyle="None" placeholder="YYYY-MM-DD"></asp:TextBox>
                    </td>
                     <td>
                        <asp:TextBox ID="SupQty_3" runat="server" borderstyle="None"></asp:TextBox>
                        
                    </td>
                 <td>
                        <asp:TextBox ID="MCLN_3" runat="server" borderstyle="None"></asp:TextBox>
                        
                    </td>
                 <td>
                        <asp:TextBox ID="InsDate_3" runat="server" borderstyle="None" placeholder="YYYY-MM-DD"></asp:TextBox>
                        
                    </td>
                    <td>
                        <asp:TextBox ID="InsStat_3" runat="server" borderstyle="None"></asp:TextBox>
                        
                    </td>
                   
                </tr>
                <tr>
                    <th scope="row">
                        <asp:Label ID="Label16" runat="server" Text="4"></asp:Label>
                    </th>
                    <td>
                        <asp:TextBox ID="SupDate_4" runat="server" borderstyle="None" placeholder="YYYY-MM-DD"></asp:TextBox>
                      
                    </td>
                    <td>
                        <asp:TextBox ID="SupQty_4" runat="server" borderstyle="None"></asp:TextBox>
                    </td>
                     <td>
                        <asp:TextBox ID="MCLN_4" runat="server" borderstyle="None"></asp:TextBox>
                       
                    </td>
                 <td>
                        <asp:TextBox ID="InsDate_4" runat="server" borderstyle="None" placeholder="YYYY-MM-DD "></asp:TextBox>
                       
                    </td>
                 <td>
                        <asp:TextBox ID="InsStat_4" runat="server" borderstyle="None"></asp:TextBox>
                       
                    </td>
                    
                 </tr>
                <tr>
                    <th scope="row">
                        <asp:Label ID="Label17" runat="server" Text="5"></asp:Label>
                    </th>
                    <td>
                        <asp:TextBox ID="SupDate_5" runat="server" borderstyle="None" placeholder="YYYY-MM-DD"></asp:TextBox>
                       
                    </td>
                    <td>
                        <asp:TextBox ID="SupQty_5" runat="server" borderstyle="None"></asp:TextBox>
                    </td>
                     <td>
                        <asp:TextBox ID="MCLN_5" runat="server" borderstyle="None"></asp:TextBox>
                       
                    </td>
                 <td>
                        <asp:TextBox ID="InsDate_5" runat="server" borderstyle="None" placeholder="YYYY-MM-DD"></asp:TextBox>
                        
                    </td>
                 <td>
                        <asp:TextBox ID="InsStat_5" runat="server" borderstyle="None"></asp:TextBox>
                        
                    </td>
                    
                 </tr>
                </tbody>
            </table>
            </div> 
            <br />
             <br />
            <br />
            <asp:Button ID="SubBut2" runat="server" Text="Submit" />
             
            <br />
            
       
                
        <br />
        <br />
        <br />
       
        
       
         </asp:Panel>
            </div>
            </div>
    </form>
</body>
</html>
