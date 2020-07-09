<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ElecMachinesUnScheduledReport.aspx.vb" Inherits="WebApplication2.ElecMachinesUnScheduledReport" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>ElecMachinesUnScheduledReport</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
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
        <%-- <link rel="stylesheet" href="../../StyleSheet1.css" />--%>
	</HEAD>
	<body>
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
<!--/.Navbar -->
           <div class="container">
		<form id="Form1" method="post" runat="server">
            <div class="row">
                <%--<h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" class="form-control ll" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
            </div>
           
            <div class="row table-responsive">
			<asp:panel id="Panel1" runat="server">
                <TABLE id="Table1" class="table">
					<TR>
						<TD align="middle" colSpan="6"><hr class="prettyline" /></TD>
                        </TR>
                                </TABLE>
			<TABLE id="Table1" class="table">
				<TR>
					<TD colSpan="3"><FONT size="5">UnScheduled WorkOrder Report</FONT></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px" colSpan="3"><asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 3px" colSpan="3">From Date :&nbsp;
						<asp:textbox id="txtFromDate" runat="server" CssClass="form-control"></asp:textbox><asp:requiredfieldvalidator id="rfv1" runat="server" ControlToValidate="txtFromDate" ErrorMessage="*"></asp:requiredfieldvalidator>&nbsp;&nbsp;&nbsp; 
						To Date :&nbsp;
						<asp:textbox id="txtToDate" runat="server" CssClass="form-control"></asp:textbox><asp:requiredfieldvalidator id="rfv2" runat="server" ControlToValidate="txtToDate" ErrorMessage="*"></asp:requiredfieldvalidator></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 54px" colSpan="3">
                        <asp:radiobuttonlist id="rblShop" runat="server" RepeatLayout="Flow" CssClass="rbl">
							<asp:ListItem Value="FORGE SHOP" Selected="True">FORGE SHOP</asp:ListItem>
							<asp:ListItem Value="OLD LINE">OLD LINE</asp:ListItem>
							<asp:ListItem Value="CNC LINE">CNC LINE</asp:ListItem>
							<asp:ListItem Value="ASSEMBLY SHOP">ASSEMBLY SHOP</asp:ListItem>
							<asp:ListItem Value="ElecCranes">ElecCranes</asp:ListItem>
						</asp:radiobuttonlist></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="middle" colSpan="3">
                        <asp:button id="btnElec" runat="server" Text="Elec  Reports" CssClass="button button2"></asp:button></TD>
				</TR>
			</TABLE>
		</asp:panel></div>
               </form> 
        </div>
      
        <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
