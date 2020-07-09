<%@ Page Language="vb" AutoEventWireup="false" Codebehind="TreadDiaChangeAfterPressing.aspx.vb" Inherits="WebApplication2.TreadDiaChangeAfterPressing" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>TreadDiaChangeAfterPressing</title>
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
            
           <%--      <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>--%>
                 <br />
      </div>

            <div class="row"><div class="table-responsive">
			<TABLE id="Table3" class="table"></TABLE>
				
						<TABLE id="Table1" class="table">
							<TR>
								<TD align="middle" colSpan="4"><STRONG><FONT size="4">Tread Dia change After Pressing</FONT></STRONG><hr class="prettyline" /></TD>
							</TR>
							<TR>
								<TD>Message</TD>
								<TD colSpan="3">
									<asp:Label id="lblMessage" runat="server" Width="268px" ForeColor="Red"></asp:Label></TD>
							</TR>
							<TR>
								<TD>BatchNumber</TD>
								<TD>
									<asp:TextBox id="txtBatchNumber" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox>
									<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtBatchNumber" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></TD>
								<TD>Day Serial</TD>
								<TD>
									<asp:TextBox id="txtDaySerial" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox>
									<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="txtDaySerial" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></TD>
							</TR>
							<TR>
								<TD>East Dia</TD>
								<TD>
									<asp:TextBox id="txtEastDia" runat="server" CssClass="form-control"></asp:TextBox>
									<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ControlToValidate="txtEastDia" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></TD>
								<TD noWrap>West Dia</TD>
								<TD>
									<asp:TextBox id="txtWestDia" runat="server" CssClass="form-control"></asp:TextBox>
									<asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" ControlToValidate="txtWestDia" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></TD>
							</TR>
							<TR>
								
											<TD>1. Both East &amp; West Dia will be updated.</TD>
										</TR>
										<TR>
											<TD>2. Usage of this screen is to be discouraged.</TD>
										
									
								
							</TR>
							<TR>
								<TD noWrap align="middle" colSpan="4">
									<asp:Label id="lblPreEastDia" runat="server" Visible="False"></asp:Label>
									<asp:Button id="btnSave" runat="server" CssClass="button button2" Text="Save"></asp:Button>
									<asp:Label id="lblPreWestDia" runat="server" Visible="False"></asp:Label></TD>
							</TR>
						</TABLE>
					
					
						<TABLE id="Table4" class="table">
							<TR>
								<TD>EastWheel</TD>
								<TD>
									<P>
										<asp:Label id="lblEwhl" runat="server"></asp:Label>/
										<asp:Label id="lblEheat" runat="server"></asp:Label></P>
								</TD>
							</TR>
							<TR>
								<TD>WestWheel</TD>
								<TD>
									<asp:Label id="lblWwhl" runat="server"></asp:Label>/
									<asp:Label id="lblWheat" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD>EastWheelLocation</TD>
								<TD>
									<asp:Label id="lblELocation" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD>WestWheelLocation</TD>
								<TD>
									<asp:Label id="lblWLocation" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD>Remarks</TD>
								<TD>
									<asp:Label id="lblRems" runat="server"></asp:Label></TD>
							</TR>
						</TABLE>
					
		</div></div></form></div>
         <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
