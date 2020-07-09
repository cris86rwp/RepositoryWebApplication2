<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MMSOfflineReports.aspx.vb" Inherits="WebApplication2.MMSOfflineReports" Culture="en-GB" uiCulture="en-GB"%>
<!DOCTYPE HTML>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>viewspoolfile</title>
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
	<body>
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
			<P align="left">
				<TABLE id="Table1" class="table">
					<TR>
						<TD align="middle" colSpan="3"><h2>MMS OFFLINE REPORTS</h2><hr class="prettyline" /></TD>
					</TR>
					<TR>
						<TD colSpan="3">
							<P><EM><U>These are offline copies and data represented may not be as of now.</U></EM>
							</P>
							<P><EM><U>When Asked: Click Open to view/Print. Click Save to save report on your disk. </U>
								</EM>
							</P>
							<P><EM><U>(Select Crystal Offline Viewer when asked. Select Printer/Forms as required)</U></EM></P>
						</TD>
					</TR>
					<TR>
						<TD colSpan="2">Type of Reports</TD>
						<TD>Report Name</TD>
					</TR>
					<TR>
						<TD colSpan="2">Message</TD>
						<TD>
							<asp:Label id="lblmessage" runat="server" ForeColor="Red"></asp:Label></TD>
					</TR>
					<TR>
						<TD colSpan="2">Production 
							Highlights(UserName/Password:pco)</TD>
						<TD>
                            <asp:dropdownlist id="ddlProductionHighlights" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD colSpan="2">Pink Sheets(UserName/Password:pink)</TD>
						<TD>
                            <asp:dropdownlist id="ddlPinkSheets" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<asp:Label id="lblAfsReps" runat="server" Visible="False">Forge Shop Daily<br>(UserName/Password:mms_user)</asp:Label></TD>
						<TD>
                            <asp:dropdownlist id="ddlAFSDaily" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<asp:Label id="lblAmsDlyReps" runat="server" Visible="False">Machine Shop Daily<br>(UserName/Password:mms_user)</asp:Label></TD>
						<TD>
                            <asp:dropdownlist id="ddlAMSDaily" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<asp:Label id="lblAasDlyReps" runat="server" Visible="False">Assembly Shop Daily<br>(UserName/Password:mms_user)</asp:Label></TD>
						<TD><asp:dropdownlist id="ddlASSDaily" runat="server" Width="208px" AutoPostBack="True"></asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<asp:Label id="lblUtMptDlyReps" runat="server" Visible="False">UT/MPT Daily<br>(UserName/Password:mms_user)</asp:Label></TD>
						<TD><asp:dropdownlist id="ddlUTMPTDaily" runat="server" CssClass="form-control ll" AutoPostBack="True" Visible="False"></asp:dropdownlist></TD>
					</TR>
				</TABLE>
			</P>
		</form>
        </div></div></div>
        <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</html>
