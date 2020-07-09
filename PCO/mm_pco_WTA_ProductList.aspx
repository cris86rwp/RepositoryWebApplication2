<%@ Page Language="vb" AutoEventWireup="false" Codebehind="mm_pco_WTA_ProductList.aspx.vb" Inherits="WebApplication2.mm_pco_WTA_ProductList" smartNavigation="True" %>
<!DOCTYPE HTML >
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>mm_pco_WTA_ProductList</title>
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
     <%-- <link rel="stylesheet" href="../StyleSheet1.css" />--%>
	</head>
	<body >
         <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
  <a class="navbar-brand p-0" href="#"><img src="../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent-333"
    aria-controls="navbarSupportedContent-333" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>
  <div class="collapse navbar-collapse " id="navbarSupportedContent-333" >
      <ul class="navbar-nav ml-auto navbar-center">
         <li class="nav-item" style="font-weight: bold">
             <h1 style="color:white; font-size:30px; margin-left:325px; margin-top:5px">Rail Wheel Plant, Bela</h1> 
       
         </li>
          </ul>
    <ul class="navbar-nav ml-auto  navbar-right">
        <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home " style="font-size:30px;"></i>
        </a></li>

       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out" style="font-size:30px;"></i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
          <%--<img src="../../../CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="50" style="border-width: 34px; background-position: 5px 5px; width:50px;margin-top:3px;border-color:white; border-width:50px"/>
        --%><img src="../NewFolder1/CRIS-Recruitment.jpg" height="45" style="border-radius:43%"/>
       </a>
      </li>
     </ul>
      
  </div>
</nav>
<!--/.Navbar -->

         
         <div class="container">
              <div class="row">
                <div class="table-responsive">

		<form id="Form1" method="post" runat="server">
           <%-- <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>--%>
                 <br />
			<TABLE id="Table1" class="table" <%--style="Z-INDEX: 101; LEFT: 11px; WIDTH: 424px; POSITION: absolute; TOP: 16px; HEIGHT: 189px" cellSpacing="1" cellPadding="1" width="424"--%>>
				<TR>
					<TD vAlign="top" align="center" colSpan="5"><h2>WTA Product List&nbsp;&nbsp;
							<asp:Label id="lblHeading" runat="server">( Added from Product Master )</asp:Label></h2><hr class="prettyline" /></TD>
				</TR>
				<TR>
					<TD colSpan="5">
						<asp:Label id="lblMode" runat="server" ForeColor="Red" BackColor="Transparent"></asp:Label></TD>
				</TR>
				<TR>
					<TD colSpan="5">
						Message:
						<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></TD>
				</TR>
				</table>
					
						<asp:Panel id="Panel1" runat="server">
							<TABLE id="Table2"  class="table" <%--cellSpacing="1" cellPadding="1" width="300"--%>>
								<TR>
									<TD>Product Code</TD>
									<TD>:</TD>
									<TD>
										<asp:DropDownList id="ddlProductList" runat="server" AutoPostBack="True" CssClass="form-control ll"></asp:DropDownList>
										<asp:DropDownList id="ddlProductCodes" runat="server" AutoPostBack="True" CssClass="form-control ll"></asp:DropDownList></TD>
								</TR>
								<TR>
									<TD>RWF Drawing</TD>
									<TD>:</TD>
									<TD>
										<asp:TextBox id="txtRWFDrg" runat="server" CssClass="form-control"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD>Customer Drawing</TD>
									<TD>:</TD>
									<TD>
										<asp:TextBox id="txtCustomerDrg" runat="server" CssClass="form-control"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD vAlign="top" align="center" colSpan="3">
										<asp:Button id="btnSave" runat="server" Text="Save" class="button button2"></asp:Button></TD>
								</TR>
							</TABLE>
						</asp:Panel>
				
                
           <TABLE id="Table3" class="table">
				<TR>
					<TD vAlign="top" align="left" colSpan="5">
						<asp:DataGrid id="dgData" runat="server" BackColor="White" BorderColor="White" BorderStyle="Ridge" CellSpacing="1" BorderWidth="2px" CellPadding="3" GridLines="None" CssClass="table">
							<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#9471DE"></SelectedItemStyle>
							<ItemStyle ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
							<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
							<PagerStyle HorizontalAlign="Right" ForeColor="Black" BackColor="#C6C3C6"></PagerStyle>
						</asp:DataGrid></TD>
				</TR>
			</TABLE>
		</form> </div></div></div>
        <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</html>
