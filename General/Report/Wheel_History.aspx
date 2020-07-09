<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Wheel_History.aspx.vb" Inherits="WebApplication2.Wheel_History" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Baking station</title>
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

   <!-- <link href="../../StyleSheet1.css" rel="stylesheet" />-->

 
</head>
	<body bgColor="#b6dcf5" MS_POSITIONING="GridLayout">
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
          <i class="fab glyphicon glyphicon-home "style="font-size:30px;"></i>
        </a></li>

       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out"style="font-size:30px;"></i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
          <img src="../../NewFolder1/CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="45"/>
        </a>
      </li>
     </ul>
      
  </div>
</nav>
 <br />
     <div class="container">
            <div class="row">
                <div class="table">
		<form id="Form1" method="post" runat="server">
           <!-- <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true"  CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />-->
                       
			<asp:Panel id="Panel1" runat="server">
				
					<div class="row">
						<div class="col" align="center"><STRONG><FONT size="5" >Wheel History Report</FONT></STRONG></div>
					</div>
                <br />
					<div class="row">
						<div class="col" >
							<asp:Label id="lblerr" runat="server" ForeColor="Red"></asp:Label></div>
					</div>
                <br />
					<div class="row">
						<div class="col">Wheel No</div>
						<div class="col">
							<asp:textbox id="txtWheel" runat="server" Width="120px" CssClass="form-control"></asp:textbox>
							<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" Display="Dynamic" ControlToValidate="txtWheel">*</asp:RequiredFieldValidator></div>
						<div class="col">Heat No</div>
						<div class="col">
							<asp:textbox id="txtHeat" runat="server" Width="120px" CssClass="form-control"></asp:textbox>
							<asp:RequiredFieldValidator id="rfvld2" runat="server" Display="Dynamic" ControlToValidate="txtHeat">*</asp:RequiredFieldValidator></div>
					</div>
                <br />
                  <br />
                  <br />
                  <br />
					<div class="row">
						<div class="col" align="center">
							<asp:button id="BtnShow" runat="server"  Text="Show Report" Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark"></asp:button></div>
					</div>
                <br />
					<div class="row">
						<div class="col" align="middle">
							<asp:Button id="Button1" runat="server" Text="Set WO for the Wheel"  Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark"></asp:Button></div>
					</div>
				
				<asp:DataGrid id="DataGrid1" runat="server" Width="782px" BorderStyle="None" AutoGenerateColumns="False" CellPadding="4" BackColor="White" BorderWidth="1px" BorderColor="#CC9966">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<Columns>
						<asp:BoundColumn DataField="Whl" ReadOnly="True" HeaderText="Whl"></asp:BoundColumn>
						<asp:BoundColumn DataField="Ht" ReadOnly="True" HeaderText="Ht"></asp:BoundColumn>
						<asp:BoundColumn DataField="WhlProduct" ReadOnly="True" HeaderText="WhlProduct"></asp:BoundColumn>
						<asp:BoundColumn DataField="WSetCode" ReadOnly="True" HeaderText="WSetCode"></asp:BoundColumn>
						<asp:BoundColumn DataField="AxlMake" ReadOnly="True" HeaderText="AxlMake"></asp:BoundColumn>
						<asp:BoundColumn DataField="SetDescr" ReadOnly="True" HeaderText="SetDescr"></asp:BoundColumn>
						<asp:BoundColumn DataField="WONumber" ReadOnly="True" HeaderText="WONumber"></asp:BoundColumn>
						<asp:BoundColumn DataField="BatchNo" ReadOnly="True" HeaderText="BatchNo"></asp:BoundColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
			</asp:Panel>
		</form>
	</div>
                </div>
            </div>
     <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;position:absolute;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>

	</body>
</HTML>