
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ProdLiningDetails.aspx.vb" Inherits="WebApplication2.ProdLiningDetails" %>
<!DOCTYPE HTML PUBLIC >
<html>

	<head runat="server">
		<title>ProdLiningDetails</title>
		<link rel="stylesheet" type="text/css" href="css/jquery-ui.css">

		
 
   <LINK id="mss" href="/wap.css" rel="stylesheet"/>
		<META content="Microsoft Visual Studio.NET 7.0" name="GENERATOR"/>
		<META content="Visual Basic 7.0" name="CODE_LANGUAGE"/>
		<META content="JavaScript" name="vs_defaultClientScript"/>
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
         <meta charset="utf-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css"/>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js"></script>
         <link type="text/css" rel="stylesheet" href="https://cdn.datatables.net/1.10.9/css/dataTables.bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="https://cdn.datatables.net/responsive/1.0.7/css/responsive.bootstrap.min.css" />
        <link href="jQuery.datetimepicker.min.css" rel="stylesheet" />
        <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.9/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/responsive/1.0.7/js/dataTables.responsive.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.9/js/dataTables.bootstrap.min.js"></script>
            <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
        <script type="text/javascript" src= "https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js">  </script>
<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
<script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
<script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
<script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
	</head>
    <style>
         .rbl input[type="radio"] {
    margin-left: 15px;
    margin-right: 5px;
}
        </style>
	<body>

        
 <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
  <a class="navbar-brand p-0" href="#"><img src="../../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent-333"
    aria-controls="navbarSupportedContent-333" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>
  <div class="collapse navbar-collapse " id="navbarSupportedContent-333" >
      <ul class="navbar-nav ml-auto navbar-center">
         <li class="nav-item" style="font-weight: bold">
             <h1 style="color:white; font-size:30px; margin-left:430px; margin-top:5px">Rail Wheel Plant, Bela</h1> 
       
         </li>
          </ul>
    <ul class="navbar-nav ml-auto  navbar-right">
        <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home " style="font-size:30px"></i>
        </a></li>
       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out"style="font-size:30px"></i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
         
        <img src="../../NewFolder1/CRIS-Recruitment.jpg" height="45" style="border-radius:43%"/>
       </a>
      </li>
     </ul>
      
  </div>
</nav>
<!--/.Navbar -->
        <style>
        .table > tbody > tr > td,
.table > tbody > tr > th {
    border-top: none;
    border: none;
}</style>

           <div class="container" align="center">
               	<form id="Form1" method="post" runat="server">
               
     

                       	<asp:Panel id="pnlMain" runat="server" >

            <div class ="row">
	
		
               <%-- style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px"Width="123px"--%>
				<div class="table" >
                   <%-- style="WIDTH: 651px; HEIGHT: 3px" cellSpacing="1" cellPadding="1" width="651"--%>
					<div class="row">
						<div class="col"  font-weight: bold;" align="center">
							<asp:label id="lblConsignee" runat="server" Font-Bold="True"></asp:label>&nbsp;<STRONG><h2> 
								Lining&nbsp;Details</STRONG></h2></div>
					</div>
					<br><div class="row">
						<div class="col">
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></div>
					</div>
					<div class="row">
						<div class="col">Please Remove from usage</FONT> any Items 
							before Updating the Last Lining No details</div>
					</div>
				</div>
				<div class="table" >
                  <%--  style="WIDTH: 179px; HEIGHT: 28px" cellSpacing="1" cellPadding="1" width="179"--%>
					<div class="row">
						<div class="col">
							<asp:RadioButtonList id="rblItemName"  runat="server"  AutoPostBack="True" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rbl">
								<asp:ListItem Value="3" Selected="True">Ladle No&nbsp</asp:ListItem>
								<asp:ListItem Value="4">&nbsp;Roof No&nbsp</asp:ListItem>
							</asp:RadioButtonList></div>
					</div>
				</div>
				<div class="table">
                   <%-- cellSpacing="1" cellPadding="1" width="300"--%>
					<div class="row">
						<div class="col">
							<asp:RadioButtonList id="rblType"  runat="server"  AutoPostBack="True" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rbl"  >
								<asp:ListItem Value="1" Selected="True">For Updation&nbsp</asp:ListItem>
								<asp:ListItem Value="2">&nbsp;Remove from usage&nbsp</asp:ListItem>
								<asp:ListItem Value="3">&nbsp;Delete&nbsp</asp:ListItem>
								<asp:ListItem Value="4">&nbsp;Zero First Heats</asp:ListItem>
							</asp:RadioButtonList></div>
					</div>
				</div>
				<div class="table" >
                   <%-- style="WIDTH: 1093px; HEIGHT: 28px" cellSpacing="1" cellPadding="1" width="1093"--%>
					<div class="row">
						<div class="col">
							<asp:RadioButtonList id="rblItems"  runat="server"  AutoPostBack="True" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rbl"></asp:RadioButtonList></div>
					</div>
				</div>
               <div class="table-responsive">
				<asp:DataGrid id="DataGrid1" runat="server" CssClass="table" >  <%--CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966"--%>
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
                   </div>
                    
				<asp:Panel id="pnl1" runat="server">
					<div class="table" >
                        <%--cellSpacing="1" cellPadding="1" width="300"--%>
					<br>	<div class="row">
							<div class="col">First Heat No</div>
							
							<div class="col">
								<asp:TextBox id="txtFirstHeatNo" runat="server" CssClass="form-control"></asp:TextBox></div>
						</div>
						<br><div class="row">
							<div class="col">Last Heat No</div>
							
							<div class="col">
								<asp:TextBox id="txtLastHeatNo" runat="server" CssClass="form-control"></asp:TextBox></div>
						</div>
					</div>
				</asp:Panel>
				<asp:Panel id="pnl2" runat="server">
					<div class="table" >
						<div class="row">
							<div class="col">Bottom</div>
						
							<div class="col">
								<asp:TextBox id="txtBottom" runat="server" CssClass="form-control"></asp:TextBox></div>
						</div>
						<div class="row">
							<div class="col">Side Wall</div>
							
							<div class="col">
								<asp:TextBox id="txtSideWall" runat="server" CssClass="form-control"></asp:TextBox></div>
						</div>
						<div class="row">
							<div class="col">Remarks</div>
							
							<div class="col">
								<asp:TextBox id="txtRemarks" runat="server" CssClass="form-control"></asp:TextBox></div>
						</div>
					</div>
				</asp:Panel>
				<div class="table" >
					<div class="row">
						<div class="col" align="center">
							<asp:Button id="btnSave" Font-Size="20px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" runat="server"></asp:Button></div>
					</div>
				</div></div>
			</asp:Panel>
		</form>
                    </div>
               
               
 <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;position:relative;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>

	</body>
</html>
