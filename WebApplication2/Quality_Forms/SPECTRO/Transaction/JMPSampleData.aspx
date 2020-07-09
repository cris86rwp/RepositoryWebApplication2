<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="JMPSampledata.aspx.vb" Inherits="WebApplication2.JMPSampledata" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>JMP SAMPLE DATA</title>
    <meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR"/>
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>

     <meta charset="utf-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css"/>
  <script  src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js"></script>

         <link type="text/css" rel="stylesheet" href="https://cdn.datatables.net/1.10.9/css/dataTables.bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="https://cdn.datatables.net/responsive/1.0.7/css/responsive.bootstrap.min.css" />
    <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.9/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/responsive/1.0.7/js/dataTables.responsive.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.9/js/dataTables.bootstrap.min.js"></script>
    <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
   
</head>
<body>
      <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
  <a class="navbar-brand p-0" href="#"><img src="../../../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent-333"
    aria-controls="navbarSupportedContent-333" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>
  <div class="collapse navbar-collapse " id="navbarSupportedContent-333">
      <ul class="navbar-nav ml-auto  navbar-center">
          <li class="nav-item"> <a class="nav-link" href="#" style="color:white; font-size:25px;">Rail Wheel Plant Bela</a></li>
      </ul>
    <ul class="navbar-nav ml-auto  navbar-right">
       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home " style="font-size:30px;"></i>
        </a></li>
       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out" style="font-size:30px;"></i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
          <img src="../../../NewFolder1/CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="45"/>
        </a>
      </li>
     </ul>
      
  </div>
</nav>
<!--/.Navbar -->
    <div class="container">
    <form id="form1" runat="server">
        <div class="row"><div class="table-responsive">
            <asp:Panel ID="panel1" runat="server">
            <table class="table">
                <tr><td>CHEMICAL ANALYSIS</td></tr>
                <tr>
                    <td><asp:Label ID="lblmsg" runat="server"></asp:Label></td>
                </tr>
                <tr>
                     <td>DATE</td>
                    <td><asp:TextBox ID="txtdate" runat="server" CssClass="form-control" AutoPostBack="True" TabIndex="1"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Date format is wrong" ControlToValidate="txtdate" ValidationExpression="^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[13-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$"></asp:RegularExpressionValidator></td>
                    <td>Time</td>
                    <td><asp:TextBox ID="txttime" runat="server" CssClass="form-control" TabIndex="2"></asp:TextBox></td>
                    <td>Shift</td>
                    <td><asp:RadioButtonList ID="shiftrbl" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rbl">
                        <asp:ListItem Value="A" Selected="True">A</asp:ListItem>
                        <asp:ListItem Value="B">B</asp:ListItem>
                        <asp:ListItem Value="C">C</asp:ListItem>
                        <asp:ListItem Value="G">G</asp:ListItem>
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td>CMA/CMS</td>
                    <td><asp:TextBox ID="txtcmacms" runat="server" CssClass="form-control" TabIndex="3"></asp:TextBox></td>
                    <td>Heat Number</td>
                    <td><asp:TextBox ID="txtheat" runat="server" AutoPostBack="true" CssClass="form-control" TabIndex="4"></asp:TextBox></td>
                    <td>Sample Type</td>
                    <td tabindex="5"><asp:RadioButtonList ID="rblsample" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rbl">
                       <asp:ListItem Value="S1" >S1</asp:ListItem>
                         <asp:ListItem Value="S2" >S2</asp:ListItem>
                         <asp:ListItem Value="S3" >S3</asp:ListItem>
                        <asp:ListItem Value="S4" >S4</asp:ListItem>
                        <asp:ListItem Value="S5" >S5</asp:ListItem>
                        <asp:ListItem Value="S6" >S6</asp:ListItem>
                        <asp:ListItem Value="S7" >S7</asp:ListItem>
                        <asp:ListItem Value="SOS" >SOS</asp:ListItem>
                        <asp:ListItem Value="JMP" Selected="True">JMP</asp:ListItem>
                        <asp:ListItem Value="product">Poduct</asp:ListItem>
                        </asp:RadioButtonList></td>
                       
                
            </table>
                       <table class="table">
                <tr>
                    <td>Carbon</td>
                    <td><asp:TextBox ID="txtc" runat="server" CssClass="form-control" placeholder="0.0" TabIndex="6"></asp:TextBox></td>
                    <td>Manganese</td>
                     <td><asp:TextBox ID="txtmn" runat="server" CssClass="form-control" placeholder="0.0" TabIndex="7"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td>Silicon</td>
                    <td><asp:TextBox ID="txtsi" runat="server" CssClass="form-control" placeholder="0.0" TabIndex="8"></asp:TextBox></td>
                    <td>Phosphorous</td>
                     <td><asp:TextBox ID="txtp" runat="server" CssClass="form-control" placeholder="0.0" TabIndex="9"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td>Sulphur</td>
                    <td><asp:TextBox ID="txts" runat="server" CssClass="form-control" placeholder="0.0" TabIndex="10"></asp:TextBox></td>
                    <td>Chromium</td>
                     <td><asp:TextBox ID="txtcr" runat="server" CssClass="form-control" placeholder="0.0" AutoPostBack="True" TabIndex="11"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td>Nickle</td>
                    <td><asp:TextBox ID="txtni" runat="server" CssClass="form-control" placeholder="0.0" AutoPostBack="True" TabIndex="12"></asp:TextBox></td>
                    <td>Copper</td>
                     <td><asp:TextBox ID="txtcu" runat="server" CssClass="form-control" placeholder="0.0" TabIndex="13"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td>Molybdenum</td>
                    <td><asp:TextBox ID="txtmo" runat="server" CssClass="form-control" placeholder="0.0" AutoPostBack="True" TabIndex="14"></asp:TextBox></td>
                    <td>Vanadium</td>
                     <td><asp:TextBox ID="txtv" runat="server" CssClass="form-control" placeholder="0.0" TabIndex="15"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td>Aluminium</td>
                    <td><asp:TextBox ID="txtal" runat="server" CssClass="form-control" placeholder="0.0" TabIndex="16"></asp:TextBox></td>
                    <td>Nitrogen </td>
                     <td><asp:TextBox ID="txtn" runat="server" CssClass="form-control" placeholder="0.0" TabIndex="17"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td>Hydrogen </td>
                    <td><asp:TextBox ID="txth" runat="server" CssClass="form-control" placeholder="0.0" TabIndex="18"></asp:TextBox></td>
                    <td>Chromium+Nickle+Molybdenum)</td>
                     <td><asp:TextBox ID="txtcnm" runat="server" CssClass="form-control" placeholder="0.0" TabIndex="19"></asp:TextBox></td>
                </tr>
                         <tr> 
                          <td> 
                          <asp:Label ID="lblhsts" Text="Heat Status" runat="server" Visible="false" ></asp:Label>   
            
                    <asp:DropDownList ID="ddljmp" runat="server" CssClass="form-control ll" Visible="false">
                        <asp:ListItem Value="JMP Pass" Selected="True">JMP Pass </asp:ListItem>
                        <asp:ListItem Value="JMP Off">JMP Off</asp:ListItem>
                        </asp:DropDownList>
                
       

                          </td>

                        <%-- </tr>   

                       <tr>--%>
                           <td> 
                         
           <asp:Label ID="lblhsts1" Text="Heat Status" runat="server"  Visible="false"></asp:Label> 
                    <asp:DropDownList ID="ddlproduct" runat="server" CssClass="form-control ll" Visible="false">
                        <asp:ListItem Value="Product Pass" Selected="True">Product Pass</asp:ListItem>
                        <asp:ListItem Value="Product Off">Product Off</asp:ListItem>
                        </asp:DropDownList>
        </td>

                         <%--</tr>     
               
                            <tr>--%>
                  <td colspan="1">Remarks</td>
                  <td colspan="2"><asp:TextBox ID="txtremarks" runat="server" CssClass="form-control" TabIndex="20"></asp:TextBox></td>
              </tr>
                      <tr>
                    <td colspan="2"><asp:Button ID="btnsave" runat="server" Text="SAVE" CssClass="button button2" /></td>
                    <td colspan="2"><asp:Button ID="btnclear" runat="server" Text="CLEAR" CssClass="button button2"/></td>
                </tr>

             
            </table>
                <asp:GridView ID="data1" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" AutoGenerateSelectButton="True"    OnRowDataBound="OnRowDataBound" OnSelectedIndexChanged = "data1_SelectedIndexChanged">
                     <Columns>
    <asp:TemplateField HeaderText = "SlNo" ItemStyle-Width="50">
        <ItemTemplate>
            <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
        
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
            </ItemTemplate>
    </asp:TemplateField>
</Columns>
                </asp:GridView>
             
        </asp:Panel>


            <asp:Panel ID="panel5" runat="server">
            <table class="table">
                <tr>
                    <td>From Heat</td>
                    <td><asp:TextBox ID="txtfheat" runat="server" CssClass="form-control"></asp:TextBox></td>
                    <td>To Heat</td>
                    <td><asp:TextBox ID="txttheat" runat="server" CssClass="form-control"></asp:TextBox></td>
                </tr>
                <tr>
                   <td colspan="4"> <asp:RadioButtonList id="rblmetal" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl">
									<asp:ListItem Value="C" Selected="True">C</asp:ListItem>
									<asp:ListItem Value="Ni">Ni</asp:ListItem>
									<asp:ListItem Value="Mn">Mn</asp:ListItem>
									<asp:ListItem Value="Si">Si</asp:ListItem>
									<asp:ListItem Value="P">P</asp:ListItem>
									<asp:ListItem Value="S">S</asp:ListItem>
									<asp:ListItem Value="Cr">Cr</asp:ListItem>
									<asp:ListItem Value="Cu">Cu</asp:ListItem>
									<asp:ListItem Value="V">V</asp:ListItem>
									<asp:ListItem Value="Al">Al</asp:ListItem>
									<asp:ListItem Value="Mo">Mo</asp:ListItem>
									<asp:ListItem Value="N">N</asp:ListItem>
									<asp:ListItem Value="H">H</asp:ListItem>
								</asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td colspan="2"><asp:Button ID="B1" runat="server" Text="Show Spectro Results Details" CssClass="button button2"/></td>
                      <td colspan="2"><asp:Button ID="B2" runat="server" Text="Export To Excel" CssClass="button button2" /></td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="panel6" runat="server">
            <asp:DataGrid ID="DataGrid1" runat="server" CssClass="table" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                <ItemStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" Mode="NumericPages" />
                <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            </asp:DataGrid>
        </asp:Panel>

            </div></div>
    </form>
        </div>
</body>
</html>
