<%@ Page Language="vb" AutoEventWireup="false" Codebehind="TreadDiaChangeBeforePressing.aspx.vb" Inherits="WebApplication2.TreadDiaChangeBeforePressing" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>TreadDiaChangeBeforePressing</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">

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
         
	</HEAD>
	<body >
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
		<form id="Form1" method="post" runat="server">
                  <div class="row">
    
                <%--  <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>--%>
            
<%--                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>--%>
                 <br />
      </div>
            <div class="row"><div class="table-responsive">
			<TABLE id="Table2" class="table"></table>
				
						<TABLE id="Table3" class="table">
							<TR>
								<TD><FONT size="4">Update tread dia&nbsp;for Wheel Number before pressing</FONT><hr class="prettyline" /></TD>
							</TR>
						</TABLE>
						<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label>
						<TABLE id="Table1" class="table">
							<TR>
								<TD>WheelNumber/HeatNumber</TD>
								<TD>:</TD>
								<TD>
									<asp:textbox id="txtWheel" runat="server" AutoPostBack="True" CssClass="form-control"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>Required Tread Diameter</TD>
								<TD>:</TD>
								<TD>
									<asp:TextBox id="txtReqTreadDia" runat="server" CssClass="form-control"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD vAlign="top" align="middle" colSpan="3">
									<asp:button id="btnUpdate" runat="server" Text="Update Tread Dia" CssClass="button button2"></asp:button></TD>
							</TR>
						</TABLE>
					
					<asp:panel id="Panel1" runat="server">
							<asp:DataGrid id="DataGrid1" runat="server" ForeColor="Black" GridLines="None" CellPadding="2" BackColor="LightGoldenrodYellow" BorderWidth="1px" BorderColor="Tan">
								<SelectedItemStyle ForeColor="GhostWhite" BackColor="DarkSlateBlue"></SelectedItemStyle>
								<AlternatingItemStyle BackColor="PaleGoldenrod"></AlternatingItemStyle>
								<HeaderStyle Font-Bold="True" BackColor="Tan"></HeaderStyle>
								<FooterStyle BackColor="Tan"></FooterStyle>
								<PagerStyle HorizontalAlign="Center" ForeColor="DarkSlateBlue" BackColor="PaleGoldenrod"></PagerStyle>
							</asp:DataGrid>
							<asp:DataGrid id="DataGrid2" runat="server" CellPadding="4" BackColor="White" BorderWidth="1px" BorderColor="#CC9966" BorderStyle="None">
								<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
								<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
								<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
								<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
							</asp:DataGrid>
							<asp:DataGrid id="DataGrid3" runat="server" CellPadding="4" BackColor="White" BorderWidth="1px" BorderColor="#3366CC" BorderStyle="None">
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid>
							<asp:DataGrid id="DataGrid4" runat="server" CellPadding="3" BackColor="#DEBA84" BorderWidth="1px" BorderColor="#DEBA84" BorderStyle="None" CellSpacing="2">
								<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#738A9C"></SelectedItemStyle>
								<ItemStyle ForeColor="#8C4510" BackColor="#FFF7E7"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#A55129"></HeaderStyle>
								<FooterStyle ForeColor="#8C4510" BackColor="#F7DFB5"></FooterStyle>
								<PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid>
							<asp:DataGrid id="DataGrid5" runat="server" GridLines="Horizontal" CellPadding="3" BackColor="White" BorderWidth="1px" BorderColor="#E7E7FF" BorderStyle="None">
								<SelectedItemStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#738A9C"></SelectedItemStyle>
								<AlternatingItemStyle BackColor="#F7F7F7"></AlternatingItemStyle>
								<ItemStyle ForeColor="#4A3C8C" BackColor="#E7E7FF"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#4A3C8C"></HeaderStyle>
								<FooterStyle ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
								<PagerStyle HorizontalAlign="Right" ForeColor="#4A3C8C" BackColor="#E7E7FF" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid>
							<asp:DataGrid id="DataGrid6" runat="server" ForeColor="Black" GridLines="Vertical" CellPadding="3" BackColor="White" BorderWidth="1px" BorderColor="#999999" BorderStyle="Solid">
								<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#000099"></SelectedItemStyle>
								<AlternatingItemStyle BackColor="#CCCCCC"></AlternatingItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Black"></HeaderStyle>
								<FooterStyle BackColor="#CCCCCC"></FooterStyle>
								<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999"></PagerStyle>
							</asp:DataGrid>
							<asp:DataGrid id="DataGrid7" runat="server" GridLines="Horizontal" CellPadding="4" BackColor="White" BorderWidth="3px" BorderColor="#336666" BorderStyle="Double">
								<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#339966"></SelectedItemStyle>
								<ItemStyle ForeColor="#333333" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#336666"></HeaderStyle>
								<FooterStyle ForeColor="#333333" BackColor="White"></FooterStyle>
								<PagerStyle HorizontalAlign="Center" ForeColor="White" BackColor="#336666" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid>
							<asp:DataGrid id="DataGrid8" runat="server" ForeColor="Black" GridLines="Horizontal" CellPadding="4" BackColor="White" BorderWidth="1px" BorderColor="#CCCCCC" BorderStyle="None">
								<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#CC3333"></SelectedItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#333333"></HeaderStyle>
								<FooterStyle ForeColor="Black" BackColor="#CCCC99"></FooterStyle>
								<PagerStyle HorizontalAlign="Right" ForeColor="Black" BackColor="White"></PagerStyle>
							</asp:DataGrid>
							<asp:DataGrid id="DataGrid9" runat="server" ForeColor="Black" GridLines="Vertical" CellPadding="4" BackColor="White" BorderWidth="1px" BorderColor="#DEDFDE" BorderStyle="None">
								<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#CE5D5A"></SelectedItemStyle>
								<AlternatingItemStyle BackColor="White"></AlternatingItemStyle>
								<ItemStyle BackColor="#F7F7DE"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#6B696B"></HeaderStyle>
								<FooterStyle BackColor="#CCCC99"></FooterStyle>
								<PagerStyle HorizontalAlign="Right" ForeColor="Black" BackColor="#F7F7DE" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid>
						</asp:panel>
		</div></div></form></div>
         <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
