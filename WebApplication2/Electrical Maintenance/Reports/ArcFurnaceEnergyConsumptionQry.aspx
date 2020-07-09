<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ArcFurnaceEnergyConsumptionQry.aspx.vb" Inherits="WebApplication2.ArcFurnaceEnergyConsumptionQry" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>ArcFurnaceEnergyConsumption</title>
		<LINK id="mss" href="/wap.css" rel="stylesheet">
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
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
	<body MS_POSITIONING="GridLayout">
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
			<div class="container">
		<form id="Form2" method="post" runat="server">
             <div class="row">
    
         <%--         <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" CssClass="form-control ll" OnSelectedIndexChanged="dd1_SelectedIndexChanged"  Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
      </div>
            <div class="table-responsive">
			<asp:panel id="pnlMain" Width="88px">
				<asp:Panel id="pnlData" runat="server">
					<TABLE id="Table1" class="table">
						<TR>
							<TD>Arc Furnace Energy Consumption</TD>
						</TR>
						<TR>
							<TD>
								<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></TD>
						</TR>
						<TR>
							<TD>&nbsp;Select Month&nbsp;&nbsp;:
								<asp:DropDownList id="cboMonth" CssClass="form-control ll" runat="server"></asp:DropDownList></TD>
						</TR>
						<TR>
							<TD>&nbsp;&nbsp; Select 
								Year&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :
								<asp:DropDownList id="cboYear" CssClass="form-control ll" runat="server"></asp:DropDownList></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 317px" colSpan="3"></TD>
						</TR>
						<TR>
							<TD align="middle" colSpan="3">
								<asp:button id="Button1" CssClass="button button2" runat="server" Font-Names="Arial" Font-Size="Smaller" Text="Submit" BorderStyle="Groove"></asp:button></TD>
						</TR>
					</TABLE>
					<asp:panel id="pnlView" runat="server">
						<TABLE id="Table2" class="table">
							<TR>
								<TD align="middle" colSpan="6">
									<P>Main Receving Station - ELEC</P>
									<P>Monthly Statistics Of ARC Furnace&nbsp;Consumption</P>
									<P>For The Month Of
										<asp:Label id="lblMonth" runat="server"></asp:Label></P>
									<P>
										<asp:label id="lblMessage1" runat="server" ForeColor="Red"></asp:label></P>
								</TD>
							</TR>
							<TR>
								<TD align="middle" colSpan="6"></TD>
							</TR>
							<TR>
								<TD align="middle" colSpan="6">
									<HR width="100%" SIZE="1">
								</TD>
							</TR>
							<TR>
								<TD>Sl. No</TD>
								<TD>Deacription</TD>
								<TD>No. of Melts</TD>
								<TD>Energy Consumption</TD>
								<TD>Average Energy Consumption</TD>
								<TD>Average Energy Consumption of Previous Month&nbsp;</TD>
							</TR>
							<TR>
								<TD colSpan="6">
									<HR width="100%" SIZE="1">
								</TD>
							</TR>
							<TR>
								<TD>1</TD>
								<TD>ARC - I</TD>
								<TD>
									<asp:Label id="lblMelt1" runat="server"></asp:Label></TD>
								<TD>
									<asp:Label id="lblConsumption1" runat="server"></asp:Label></TD>
								<TD>
									<asp:Label id="lblAverage1" runat="server"></asp:Label></TD>
								<TD>
									<asp:Label id="lblPreviousAverage1" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD>2</TD>
								<TD>ARC - II</TD>
								<TD>
									<asp:Label id="lblMelt2" runat="server"></asp:Label></TD>
								<TD>
									<asp:Label id="lblConsumption2" runat="server"></asp:Label></TD>
								<TD>
									<asp:Label id="lblAverage2" runat="server"></asp:Label></TD>
								<TD>
									<asp:Label id="lblPreviousAverage2" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD>3</TD>
								<TD>ARC - III</TD>
								<TD>
									<asp:Label id="lblMelt3" runat="server"></asp:Label></TD>
								<TD>
									<asp:Label id="lblConsumption3" runat="server"></asp:Label></TD>
								<TD>
									<asp:Label id="lblAverage3" runat="server"></asp:Label></TD>
								<TD>
									<asp:Label id="lblPreviousAverage3" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD colSpan="6">
									<HR width="100%" SIZE="1">
								</TD>
							</TR>
							<TR>
								<TD></TD>
								<TD>Total</TD>
								<TD>
									<asp:Label id="lblTotMelts" runat="server"></asp:Label></TD>
								<TD>
									<asp:Label id="lblTotConsumptiuon" runat="server"></asp:Label></TD>
								<TD>
									<asp:Label id="lblTotAverage" runat="server"></asp:Label></TD>
								<TD>
									<asp:Label id="lblTotPreviousAverage" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD colSpan="6">
									<HR width="100%" SIZE="1">
								</TD>
							</TR>
							<TR>
								<TD></TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD>Total No. Of Melts</TD>
                                <TD>:</TD>
									<TD><asp:Label id="lbltotalmelts" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD>Total Melts Energy Consumption</TD>
                                <TD>:</TD>
									<TD><asp:Label id="lbltotalenergy" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD>Total Average Consumption</TD>
								<TD>:</TD>
									<TD><asp:Label id="lbltotalaverage" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD>Date</TD>
								<TD>:</TD>
									<TD><asp:Label id="lblDate" runat="server"></asp:Label></TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
                                <TD>Place</TD>
								<TD>:</TD>
                                    <TD>Bangalore</TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
							</TR>
						</TABLE>
					</asp:panel>
				</asp:Panel>
			</asp:panel></form>
                 <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
