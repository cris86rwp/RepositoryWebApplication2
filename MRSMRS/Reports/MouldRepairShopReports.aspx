<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MouldRepairShopReports.aspx.vb" Inherits="WebApplication2.MouldRepairShopReports" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> Mould Repair Shop</title>
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


 
    <style type="text/css">
        .auto-style1 {
            background-color: rgba(0,0,0,.03);
            position: absolute;
            bottom: 0;
            width: 100%;
            height: 60px;
            margin-top: 0px;
        }
    </style>


 
</head>
	<body MS_POSITIONING="GridLayout" bgColor="#99ccff">
        <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
   <a class="navbar-brand p-0" href="#"><img src="../../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
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
           <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home " style="font-size:30px;"></i>
        </a></li>
       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out" style="font-size:30px;"></i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
          <img src="../../NewFolder1/CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="45"/>
        </a>
      </li>
     </ul>
      
  </div>
</nav>
     
   
              

		<form id="Form1" method="post" runat="server">
            <%-- <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
			<asp:Panel id="Panel1" style="Z-INDEX: 103; LEFT: 8px; POSITION: absolute" runat="server">
                  </asp:Panel>
	
       <div class="auto-style1" style="text-align:right;background-color:#cccccc;vertical-align:middle;"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
     
                  <div class="table">
                      <div class="container">
					<div class="row">
						<div class="col" align="center" ><strong><h3>Mould&nbsp;Repair Shop Reports</h3></strong></div>
					</div>
					<div class="row">
						<div class="col">
							<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></div>
					</div>
					<div class="row">
						<div class="col" align="center">
                            <asp:button id="btnMouldPopulation" runat="server" Text="Mould Population Report"  Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" ></asp:button>
						</div>
					</div>
                          <br />
                          <br />
					<div class="row">
						<div class="col" >BlankNumber</div>
							<div class="col"><asp:TextBox id="txtBlank" runat="server" AutoPostBack="True" Width="104px" CssClass="form-control"></asp:TextBox></div>
                        <div class="col"></div>
                        <div class="col"></div>
					</div><br />
					<div class="row">
						<div class="col">Mould Repair Shop Qry</div>
					</div>
                          <div class="row">					
						<div class="col">
							<asp:RadioButtonList id="rblQry" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" width="1040px">
								<asp:ListItem Value="0">Drag Details Active&nbsp</asp:ListItem>
								<asp:ListItem Value="1">Drag Details Condemned&nbsp;</asp:ListItem>
								<asp:ListItem Value="2">Cope Details Active&nbsp;</asp:ListItem>
								<asp:ListItem Value="3">Cope Details Condemned&nbsp;</asp:ListItem>
								<asp:ListItem Value="4">Graphite Blocks&nbsp;</asp:ListItem>
								<asp:ListItem Value="5">Latest Details&nbsp;</asp:ListItem>
							</asp:RadioButtonList></div>
                        <div class="col">
							<asp:RadioButtonList id="rblMouldType" runat="server" ForeColor="Black" AutoPostBack="True" Width="935px"  RepeatLayout="Flow"></asp:RadioButtonList></div>
					
					</div>
					<div class="row">
						<div class="col" align="center">
                            <asp:button id="Button1" runat="server" Text="Export to Excel"  Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" ></asp:button>
						</div>
					</div>
				 </div>
                
				<asp:DataGrid id="DataGrid1" runat="server" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
		</form>
	
       </body>
</HTML>