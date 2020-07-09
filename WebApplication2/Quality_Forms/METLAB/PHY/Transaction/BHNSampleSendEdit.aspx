<%@ Page Language="vb" AutoEventWireup="false" Codebehind="BHNSampleSendEdit.aspx.vb" Inherits="WebApplication2.BHNSampleSendEdit" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>BHNSampleSendEdit</title>
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
     <%--<link rel="stylesheet" href="../../../../StyleSheet1.css" />--%>
	</HEAD>
	<body >
         <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
   <a class="navbar-brand p-0" href="#"><img src="../../../../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
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
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../../wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home " style="font-size:30px;"></i>
        </a></li>
       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out" style="font-size:30px;"></i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
          <img src="../../../../NewFolder1/CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="45"/>
        </a>
      </li>
     </ul>
      
  </div>
</nav>
<!--/.Navbar -->
        <div class="container">
		<form id="Form1" method="post" runat="server">
            <div class="row"><div class="table-responsive">
			<TABLE id="Table1" class="table">
				<TR>
					<TD noWrap colSpan="3"><FONT size="5">BHN Sample Wheel Edit</FONT><hr class="prettyline" /></TD>
				</TR>
				<TR>
					<TD noWrap>Message</TD>
					<TD noWrap>:</TD>
					<TD noWrap><asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label>&nbsp;</TD>
				</TR>
				<TR>
					<TD noWrap>Lab Number</TD>
					<TD noWrap>:</TD>
					<TD noWrap><asp:textbox id="txtLabNumber" runat="server" AutoPostBack="True" CssClass="form-control"></asp:textbox></TD>
				</TR>
				<TR>
					<TD noWrap>Present Wheel Number</TD>
					<TD noWrap>:</TD>
					<TD noWrap><asp:label id="lblWh" runat="server"></asp:label><asp:label id="lblFrHt" runat="server" Visible="False"></asp:label>&nbsp;</TD>
				</TR>
				<TR>
					<TD noWrap>Present Heat Number</TD>
					<TD noWrap>:</TD>
					<TD noWrap><asp:label id="lblHt" runat="server"></asp:label><asp:label id="lblToHt" runat="server" Visible="False"></asp:label>&nbsp;</TD>
				</TR>
				<TR>
					<TD noWrap>Present Wheel Descripton</TD>
					<TD noWrap>:</TD>
					<TD noWrap><asp:label id="lblDes" runat="server"></asp:label>&nbsp;</TD>
				</TR>
				<TR>
					<TD noWrap>Present Test Type</TD>
					<TD noWrap>:</TD>
					<TD noWrap><asp:label id="lblTestType" runat="server"></asp:label>&nbsp;</TD>
				</TR>
				<TR>
					<TD noWrap>Change Wheel Number</TD>
					<TD noWrap>:</TD>
					<TD noWrap><asp:textbox id="txtWh" runat="server" AutoPostBack="True" CssClass="form-control"></asp:textbox></TD>
				</TR>
				<TR>
					<TD noWrap>Change Heat Number</TD>
					<TD noWrap>:</TD>
					<TD noWrap><asp:textbox id="txtHt" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox></TD>
				</TR>
				<TR>
					<TD noWrap>Change Wheel Description</TD>
					<TD noWrap>:</TD>
					<TD noWrap>
						<asp:Label id="lblChangeDesc" runat="server"></asp:Label>&nbsp;</TD>
				</TR>
				<TR>
					<TD vAlign="top" noWrap align="middle" colSpan="3">
						<asp:Button id="btnUpdate" runat="server" Text="Update" CssClass="button button2"></asp:Button></TD>
				</TR>
			</TABLE>
                </div></div>
		</form>
            </div>
          <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
