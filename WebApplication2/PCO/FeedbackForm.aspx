<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FeedbackForm.aspx.vb" Inherits="WebApplication2.FeedbackForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" >
    <title></title>
   
    <link href="Content/bootstrap.css" rel="stylesheet" /> 
</head>
<body>
    <form id="form1" runat="server">
         <div style="text-align: center;">
             <div class="container">
                 <h1 class="heading">
        <asp:Label ID="RWPB" runat="server" Text="RAIL WHEEL PLANT/BELA" Font-Bold="True" Font-Overline="False" Font-Size="Large" Font-Strikeout="False" Font-Underline="True" >
        </asp:Label> </h1>  
        <asp:Label ID="FBoCS" runat="server" BorderColor="Black" BorderStyle="None" Height="30px" Text="FEEDBACK ON CUSTOMER SATISFACTION   " Font-Size="Medium" Font-Underline="True" Width="334px" ></asp:Label>
        </div>
             </div>
        <br />
        <br />
        <center>
            <div class="container">
        <table class="table table-borderless">  
          
        <tr >  
            <th>   </th> 
            <th>
                <asp:Label ID="one" runat="server" Text="1" ></asp:Label></th>
               <th>
                <asp:Label ID="two" runat="server" Text="2"></asp:Label>
                </th>
            <th>
                <asp:Label ID="three" runat="server" Text="3"></asp:Label>
             </th>
            <th>
                <asp:Label ID="four" runat="server" Text="4"></asp:Label>
            </th>
            <th>
                <asp:Label ID="five" runat="server" Text="5"></asp:Label>
            </th>  
            
        </tr>  
        <tr>
            <td>  
                <asp:Label ID="QOP" runat="server"   
                    Text="1. Quality of Product"></asp:Label>  
            </td> 
            
            <td>  
                <asp:RadioButton ID="QOP_1" runat="server" GroupName="A" value="1"/>
            </td>  
             <td>  
                <asp:RadioButton ID="QOP_2" runat="server" GroupName="A" value="2" />
            </td> 
             <td>  
                <asp:RadioButton ID="QOP_3" runat="server" GroupName="A" value="3" />
            </td> 
             <td>  
                <asp:RadioButton ID="QOP_4" runat="server" GroupName="A" value="4"/>
            </td> 
             <td>  
                <asp:RadioButton ID="QOP_5" runat="server" GroupName="A" value="5"/>
            </td> 
              

        </tr>  
        <tr>  
            <td>  
                <asp:Label ID="QOWIIOW" runat="server" Text="2. Quality of Wheel ID Indication on Wheel"></asp:Label>  
            </td>  
             
            <td>  
                <asp:RadioButton ID="QOWIIOW_1" runat="server" GroupName="B" value="1"/>
            </td>  
             <td>  
                <asp:RadioButton ID="QOWIIOW_2" runat="server" GroupName="B" value="2" />
            </td> 
             <td>  
                <asp:RadioButton ID="QOWIIOW_3" runat="server" GroupName="B" value="3" />
            </td> 
             <td>  
                <asp:RadioButton ID="QOWIIOW_4" runat="server" GroupName="B" value="4"/>
            </td> 
             <td>  
                <asp:RadioButton ID="QOWIIOW_5" runat="server" GroupName="B" value="5"/>
            </td>   
              
        </tr>  
        <tr>  
            <td>  
                <asp:Label ID="SD" runat="server"   
                    Text="3. Scheduled Delivery"></asp:Label>  
            </td>  
            <td>  
                <asp:RadioButton ID="SD_1" runat="server" GroupName="C" value="1"/>
            </td>  
             <td>  
                <asp:RadioButton ID="SD_2" runat="server" GroupName="C" value="2" />
            </td> 
             <td>  
                <asp:RadioButton ID="SD_3" runat="server" GroupName="C" value="3" />
            </td> 
             <td>  
                <asp:RadioButton ID="SD_4" runat="server" GroupName="C" value="4"/>
            </td> 
             <td>  
                <asp:RadioButton ID="SD_5" runat="server" GroupName="C" value="5"/>
            </td>   
             
        </tr>  
        <tr>  
            <td class="auto-style1">  
                <asp:Label ID="CEoHaSP" runat="server"   
                    Text="4. Customer Education of Handling and Storing Product"></asp:Label>  
            </td>  
            <td>  
                <asp:RadioButton ID="CEOHASP_1" runat="server" GroupName="D" value="1"/>
            </td>  
             <td>  
                <asp:RadioButton ID="CEOHASP_2" runat="server" GroupName="D" value="2" />
            </td> 
             <td>  
                <asp:RadioButton ID="CEOHASP_3" runat="server" GroupName="D" value="3" />
            </td> 
             <td>  
                <asp:RadioButton ID="CEOHASP_4" runat="server" GroupName="D" value="4"/>
            </td> 
             <td>  
                <asp:RadioButton ID="CEOHASP_5" runat="server" GroupName="D" value="5"/>
            </td>  
             
        </tr>  
            <tr>  
            <td>  
                <asp:Label ID="RTCQ" runat="server"   
                    Text="5. Response to Customer Query"></asp:Label>  
            </td>  
            <td>  
                <asp:RadioButton ID="RTCQ_1" runat="server" GroupName="E" value="1"/>
            </td>  
             <td>  
                <asp:RadioButton ID="RTCQ_2" runat="server" GroupName="E" value="2" />
            </td> 
             <td>  
                <asp:RadioButton ID="RTCQ_3" runat="server" GroupName="E" value="3" />
            </td> 
             <td>  
                <asp:RadioButton ID="RTCQ_4" runat="server" GroupName="E" value="4"/>
            </td> 
             <td>  
                <asp:RadioButton ID="RTCQ_5" runat="server" GroupName="E" value="5"/>
            </td>   
             
        </tr>  
            <tr>  
            <td>  
                <asp:Label ID="PoPQC" runat="server"   
                    Text="6. Provision of Product Quality Certificate"></asp:Label>  
            </td>  
           <td>  
                <asp:RadioButton ID="POPQC_1" runat="server" GroupName="F" value="1"/>
            </td>  
             <td>  
                <asp:RadioButton ID="POPQC_2" runat="server" GroupName="F" value="2" />
            </td> 
             <td>  
                <asp:RadioButton ID="POPQC_3" runat="server" GroupName="F" value="3" />
            </td> 
             <td>  
                <asp:RadioButton ID="POPQC_4" runat="server" GroupName="F" value="4"/>
            </td> 
             <td>  
                <asp:RadioButton ID="POPQC_5" runat="server" GroupName="F" value="5"/>
            </td>   
             
        </tr>  
            <tr>  
            <td>  
                <asp:Label ID="AOROASWDWC" runat="server"   
                    Text="7. Attitude of RWF Officials and Staff While Dealing with Customer"></asp:Label>  
            </td>  
           <td>  
                <asp:RadioButton ID="AOROASWDWC_1" runat="server" GroupName="G" value="1"/>
            </td>  
             <td>  
                <asp:RadioButton ID="AOROASWDWC_2" runat="server" GroupName="G" value="2" />
            </td> 
             <td>  
                <asp:RadioButton ID="AOROASWDWC_3" runat="server" GroupName="G" value="3" />
            </td> 
             <td>  
                <asp:RadioButton ID="AOROASWDWC_4" runat="server" GroupName="G" value="4"/>
            </td> 
             <td>  
                <asp:RadioButton ID="AOROASWDWC_5" runat="server" GroupName="G" value="5"/>
            </td> 
             
        </tr>  
            <tr>  
            <td>  
                <asp:Label ID="RTC" runat="server"   
                    Text="8. Response to Complaints"></asp:Label>  
            </td>  
            <td>  
                <asp:RadioButton ID="RTC_1" runat="server" GroupName="H" value="1"/>
            </td>  
             <td>  
                <asp:RadioButton ID="RTC_2" runat="server" GroupName="H" value="2" />
            </td> 
             <td>  
                <asp:RadioButton ID="RTC_3" runat="server" GroupName="H" value="3" />
            </td> 
             <td>  
                <asp:RadioButton ID="RTC_4" runat="server" GroupName="H" value="4"/>
            </td> 
             <td>  
                <asp:RadioButton ID="RTC_5" runat="server" GroupName="H" value="5"/>
            </td>   
             
        </tr>  
            <tr>  
            <td>  
                <asp:Label ID="PIPRITC" runat="server"   
                    Text="9. Promptness in Providing Required Informaiton to Customer"></asp:Label>  
            </td>  
            <td>  
                <asp:RadioButton ID="PIPRITC_1" runat="server" GroupName="I" value="1"/>
            </td>  
             <td>  
                <asp:RadioButton ID="PIPRITC_2" runat="server" GroupName="I" value="2" />
            </td> 
             <td>  
                <asp:RadioButton ID="PIPRITC_3" runat="server" GroupName="I" value="3" />
            </td> 
             <td>  
                <asp:RadioButton ID="PIPRITC_4" runat="server" GroupName="I" value="4"/>
            </td> 
             <td>  
                <asp:RadioButton ID="PIPRITC_5" runat="server" GroupName="I" value="5"/>
            </td>   
             
        </tr>  
            <tr>  
            <td>  
                <asp:Label ID="PIWR" runat="server"   
                    Text="10. Promptness in Warranty Replacement"></asp:Label>  
            </td>  
           <td>  
                <asp:RadioButton ID="PIWR_1" runat="server" GroupName="J" value="1"/>
            </td>  
             <td>  
                <asp:RadioButton ID="PIWR_2" runat="server" GroupName="J" value="2" />
            </td> 
             <td>  
                <asp:RadioButton ID="PIWR_3" runat="server" GroupName="J" value="3" />
            </td> 
             <td>  
                <asp:RadioButton ID="PIWR_4" runat="server" GroupName="J" value="4"/>
            </td> 
             <td>  
                <asp:RadioButton ID="PIWR_5" runat="server" GroupName="J" value="5"/>
            </td>   
             
        </tr>  
            <tr>  
            <td>  
                <asp:Label ID="PICH" runat="server"   
                    Text="11. Promptness in Complaint Handling"></asp:Label>  
            </td>  
            <td>  
                <asp:RadioButton ID="PICH_1" runat="server" GroupName="K" value="1"/>
            </td>  
             <td>  
                <asp:RadioButton ID="PICH_2" runat="server" GroupName="K" value="2" />
            </td> 
             <td>  
                <asp:RadioButton ID="PICH_3" runat="server" GroupName="K" value="3" />
            </td> 
             <td>  
                <asp:RadioButton ID="PICH_4" runat="server" GroupName="K" value="4"/>
            </td> 
             <td>  
                <asp:RadioButton ID="PICH_5" runat="server" GroupName="K" value="5"/>
            </td>   
             
        </tr>  

             
         
    </table> 
            </div>
        <br />
    <br />
            <div class="row" style="background-color:lavender;">

                <div class="col">
                    <asp:Label ID="Label6" runat="server" Font-Size="Large" Text="Scale Indicates :"  Font-Underline="True" ></asp:Label>
                    <br />
                    
                </div>
                </div>
                 <div class="row" style="background-color:lavender;">

                
                <div class="col" >
                    <asp:Label ID="Label12" runat="server" Text="1:" ></asp:Label>
                    
                    <asp:Label ID="Label17" runat="server" Text="NOT SATISFACTORY"></asp:Label>
                    </div>
                        <div class="col" >
        <asp:Label ID="Label13" runat="server" Text="2 :"></asp:Label>

                           
        <asp:Label ID="Label18" runat="server" Text="SATISFACTORY"></asp:Label>

                                </div>
                                <div class="col" >
        <asp:Label ID="Label14" runat="server" Text="3 :"></asp:Label>

                                    
        <asp:Label ID="Label19" runat="server" Text="GOOD"></asp:Label>

                                        </div>
                                        <div class="col">
        <asp:Label ID="Label15" runat="server" Text="4 :"></asp:Label>

                                            
        <asp:Label ID="Label20" runat="server" Text="VERY GOOD"></asp:Label>

                                                </div>
                                                <div class="col">
        <asp:Label ID="Label16" runat="server" Text="5 :"></asp:Label>

                                                    
        <asp:Label ID="Label21" runat="server" Text="EXCELLENT"></asp:Label>
       
                                                        </div>
                </div>
                     <br />
            <div class="row">
                <div class="col">
            <asp:Label ID="Label22" runat="server" Font-Size="Large" Text="Suggestion if any to improve customer service/product : " Font-Underline="True"></asp:Label>
            
            <br /></div>
                    <div class="col">
            <asp:TextBox ID="SuggestionBox" runat="server" Height="100px" Width="320px"></asp:TextBox>
        <br />
        
                        </div>
                </div>
            <div class="row" style="background-color:lavender;">
                <div class="col">
        <asp:Label ID="date" runat="server" Text="DATE :" ></asp:Label>
        &nbsp;&nbsp;<asp:TextBox ID="UDate" runat="server" Width="120px" placeholder="yyyy-mm-dd"></asp:TextBox></div>
        <div class="col"><asp:Label ID="place" runat="server" Text="PLACE :"></asp:Label>
        &nbsp;&nbsp;<asp:TextBox ID="UPlace" runat="server" Width="120px"></asp:TextBox></div>
       <div class="col"><asp:Label ID="CSWOS" runat="server" Text="CUSTOMER'S SIGNATURE  WITH OFFICE SEAL :"></asp:Label>
        <br />
           </div>
        </div>
            <div class="row" style="background-color:lavender;">
                <div class="col" ></div>
            <div class="col" ></div>
                <div class="col">
        <asp:Label ID="Mail" runat="server" Text="Email ID -"></asp:Label>     
        <asp:TextBox ID="Umail" runat="server" ></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Umail" ErrorMessage="Email ID format not correct" ForeColor="#CC0000" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ></asp:RegularExpressionValidator>
        </div>
                </div>
            <div class ="row" style="background-color:lavender;">
                <div class="col"></div>
                <div class="col"></div>
                    <div class="col" >
        <asp:Label ID="Mobile" runat="server" Text="Contact No. -" ></asp:Label>
  
        <asp:TextBox ID="Umobile" runat="server" ></asp:TextBox>
        <asp:Label ID="ValLabel" runat="server" Text="+91(...)"></asp:Label>
        
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="Umobile" ErrorMessage="Mobile No. Format Incorrect" ForeColor="#CC0000" ValidationExpression="((\+){1}91){1}[1-9]{1}[0-9]{9}" CssClass="auto-style3"></asp:RegularExpressionValidator>
        <br />
        </div>
                </div>
        <asp:Button id="SubButton" runat="server" Text="Submit" /> 
         </center>  
    </form>
</body>
</html>
