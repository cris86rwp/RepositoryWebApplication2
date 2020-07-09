<%@ Page Language="vb" AutoEventWireup="false" Codebehind="BHNSampleEdit.aspx.vb" Inherits="WebApplication2.BHNSampleEdit" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>BHNSampleEdit</title>
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
    <!-- <link rel="stylesheet" href="../../../../StyleSheet1.css" />-->
	</HEAD>
	<body >
         <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
  <a class="navbar-brand p-0" href="#"><img src="../../../../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
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
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../../wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home " style="font-size:30px"></i>
        </a></li>

       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out" style="font-size:30px"> </i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
         
        <img src="../../../../NewFolder1/CRIS-Recruitment.jpg" height="45" style="border-radius:43%"/>
       </a>
      </li>
     </ul>
      
  </div>
</nav>
        <br />
<!--/.Navbar -->
        <div class="container">
		<form id="Form1" method="post" runat="server">
            <div class="row"><div class="table">
			<TABLE id="Table1" class="table">
				<div class="row">
					<div class="col"noWrap colSpan="3" align="center"><STRONG><FONT size="5">BHN Sample Wheel Heat Edit</FONT></STRONG></div>
				</div>
                <br />
				<div class="row">
					
					
					<div class="col"noWrap><asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label>&nbsp;</div>
				</div>
                 <br />
				<div class="row">
					<div class="col"noWrap>Lab Number</div>
					
					<div class="col"noWrap><asp:textbox id="txtLabNumber" runat="server" AutoPostBack="True" CssClass="form-control" Width="120px"></asp:textbox></div>
                    <div class="col"></div>
                     <div class="col"></div>

				</div>
                 <br />
				<div class="row">
					<div class="col"noWrap>Present Wheel Number</div>
					
					<div class="col"noWrap><asp:label id="lblWh" runat="server"></asp:label></div>
				
					<div class="col"noWrap>Present Heat Number</div>
					
					<div class="col"noWrap><asp:label id="lblHt" runat="server"></asp:label>&nbsp;</div>
				</div>
                 <br />
				<div class="row">
					<div class="col"noWrap>Present Wheel Descripton</div>
					
					<div class="col"noWrap><asp:label id="lblDes" runat="server"></asp:label>&nbsp;</div>
				
					<div class="col"noWrap>Present Test Type</div>
					
					<div class="col"noWrap><asp:label id="lblTestType" runat="server"></asp:label>&nbsp;</div>
				</div>
                 <br />
				<div class="row">
					<div class="col"noWrap>From Heat</div>
					
					<div class="col"noWrap><asp:textbox id="txtFrHt" runat="server" CssClass="form-control" Width="120px"></asp:textbox></div>
				
					<div class="col"noWrap>To Heat</div>
					
					<div class="col"noWrap><asp:textbox id="txtToHt" runat="server" CssClass="form-control" Width="120px"></asp:textbox></div>
				</div>
                 <br />
                 <br />
                 <br />
				<div class="row">
					<div class="col"vAlign="top" noWrap align="middle" colSpan="3"><asp:button id="btnUpdate" runat="server" Text="Update" Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark"></asp:button></div>
				</div>
			</TABLE>
                </div></div>
		</form>
            </div>
         <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;position:absolute;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>

	</body>
</HTML>
