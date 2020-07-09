<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BHNchemicalvalueaddedit.aspx.vb" Inherits="WebApplication2.BHNchemicalvalueaddedit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BHN CHEMICAL VALUES </title>
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
    <%-- <link rel="stylesheet" href="../../../StyleSheet1.css" />--%>

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
                <tr><td>SPECTRO CHEMICAL VALUES (ADD/EDIT)</td></tr>
                <tr><td><asp:Label ID="lblmsg" runat="server"></asp:Label></td></tr>
                <tr>'
                    <td>DATE</td>
                    <td><asp:TextBox ID="txtdate" runat="server" CssClass="form-control"></asp:TextBox></td>
                    <td>Time</td>
                    <td><asp:TextBox ID="txttime" runat="server" CssClass="form-control"></asp:TextBox></td>
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
                    <td><asp:TextBox ID="txtcmacms" runat="server" CssClass="form-control"></asp:TextBox></td>
                   <!-- <td>Mode</td>
                    <td><asp:RadioButtonList ID="rblmode" runat="server">
                        <asp:ListItem Value="add" Selected="True">ADD</asp:ListItem>
                        <asp:ListItem Value="edit">EDIT</asp:ListItem>
                        </asp:RadioButtonList></td> -->
                    <td>Sample Type</td>
                    <td><asp:RadioButtonList ID="rblsample" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rbl">
                        <asp:ListItem Value="JMP" Selected="True">JMP</asp:ListItem>
                        <asp:ListItem Value="product">Poduct</asp:ListItem>
                        </asp:RadioButtonList></td>
                </tr>
            </table>
        </asp:Panel>

        <asp:Panel ID="panel2" runat="server">
            <table class="table">
                <tr>
                    <td>heat number</td>
                    <td><asp:TextBox ID="txtheat" runat="server" AutoPostBack="true" CssClass="form-control"></asp:TextBox></td>
                    <td>Lab number</td>
                    <td><asp:TextBox ID="txtlab" runat="server" CssClass="form-control"></asp:TextBox></td>
                    <td>Inspector</td>
                    <td><asp:TextBox ID="txtinsp" runat="server" CssClass="form-control"></asp:TextBox></td>
                </tr>
            </table>
        </asp:Panel>

        <asp:Panel ID="panel3" runat="server">
            <table>
                <tr>
                    <td>wheel number</td>
                    <td><asp:DropDownList ID="ddlwheel" runat="server" AutoPostBack="True" CssClass="form-control ll" DataSourceID="SqlDataSource1" DataTextField="Column1" DataValueField="Column1" AppendDataBoundItems="true">
                        <Items>
       <asp:ListItem Text="Select" Value="" />
   </Items>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" SelectCommand="select (convert(varchar,a.wheel_number)+'/'+ convert(varchar,a.heat_number)) 
 from ms_wheel_hardness_sample a , mm_wheel b 
where convert(numeric,a.wheel_number) = b.wheel_number and a.heat_number = b.heat_number"></asp:SqlDataSource>
                    </td>
                    <td>Lab number</td>
                    <td><asp:TextBox ID="txtlabb" runat="server" CssClass="form-control"></asp:TextBox></td>
                    <td>Wheel Type</td>
                    <td><asp:TextBox ID="txtwhltype" runat="server" CssClass="form-control"></asp:TextBox></td>
                    <td>Inspector</td>
                    <td><asp:TextBox ID="txtinspp" runat="server" CssClass="form-control"></asp:TextBox></td>
                </tr>
            </table>
        </asp:Panel>

        <asp:Panel ID="pane4" runat="server">
            <h3>Please Refer Following Chemical Composition (in %)</h3>
            <asp:GridView id="helpgrid" runat="server" DataSourceID="SqlDataSource2" CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="table">
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" SelectCommand="select * from specified_chemistry_of_wheel"></asp:SqlDataSource>
        </asp:Panel>
        <asp:Panel ID="pane5" runat="server">
            <table class="table">
                <tr>
                    <td>Carbon</td>
                    <td><asp:TextBox ID="txtc" runat="server" CssClass="form-control"></asp:TextBox></td>
                    <td>Manganese</td>
                     <td><asp:TextBox ID="txtmn" runat="server" CssClass="form-control"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td>Silicon</td>
                    <td><asp:TextBox ID="txtsi" runat="server" CssClass="form-control"></asp:TextBox></td>
                    <td>Phosphorous</td>
                     <td><asp:TextBox ID="txtp" runat="server" CssClass="form-control"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td>Sulphur</td>
                    <td><asp:TextBox ID="txts" runat="server" CssClass="form-control"></asp:TextBox></td>
                    <td>Chromium</td>
                     <td><asp:TextBox ID="txtcr" runat="server" CssClass="form-control"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td>Nickle</td>
                    <td><asp:TextBox ID="txtni" runat="server" CssClass="form-control"></asp:TextBox></td>
                    <td>Copper</td>
                     <td><asp:TextBox ID="txtcu" runat="server" CssClass="form-control"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td>Molybdenum</td>
                    <td><asp:TextBox ID="txtmo" runat="server" CssClass="form-control"></asp:TextBox></td>
                    <td>Vanadium</td>
                     <td><asp:TextBox ID="txtv" runat="server" CssClass="form-control"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td>Aluminium</td>
                    <td><asp:TextBox ID="txtal" runat="server" CssClass="form-control"></asp:TextBox></td>
                    <td>Nitrogen(in ppm)</td>
                     <td><asp:TextBox ID="txtn" runat="server" CssClass="form-control"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td>Hydrogen(in ppm)</td>
                    <td><asp:TextBox ID="txth" runat="server" CssClass="form-control"></asp:TextBox></td>
                    <td>Chromium+Nickle+Molybdenum)</td>
                     <td><asp:TextBox ID="txtcnm" runat="server" CssClass="form-control"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2"><asp:Button ID="btnsave" runat="server" Text="SAVE" CssClass="button button2" /></td>
                    <td colspan="2"><asp:Button ID="btnclear" runat="server" Text="CLEAR"  CssClass="button button2"/></td>
                </tr>
            </table>
        </asp:Panel>

             </div></div>
    </form>

        </div>
</body>
</html>
