<%@ Page Language="vb" AutoEventWireup="false" Codebehind="BHNPostExperimentaPhysicalAdd.aspx.vb" Inherits="WebApplication2.BHNPostExperimentaPhysicalAdd" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>BHNPostExperimentaPhysicalAdd</title>
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
<!--/.Navbar -->
        <div class="container">
		<form id="Form1" method="post" runat="server">
            <div class="row"><div class="table">
			<TABLE id="Table2" class="table"></TABLE>
				
						<TABLE id="Table6" class="table"></TABLE>
							
									<TABLE id="Table1" class="table">
										<div class="row">
											<div class="col"vAlign="top" noWrap align="middle" colSpan="4" rowSpan="1"><FONT size="5px">Wheel 
														Mechanical and Metallographic properties - Experimental Wheels</FONT></div>
										</div>
                                        <br />
										<div class="row">
											<div class="col"colSpan="3"><asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label>&nbsp;</div>
											<div class="col"><asp:label id="lblMode" runat="server" ForeColor="Blue"></asp:label>&nbsp;</div>
										</div>
                                          <br />
										<div class="row">
											<div class="col">Wheel Number</div>
											<div class="col"><asp:dropdownlist id="ddlLabNumber" tabIndex="1" runat="server" AutoPostBack="True" CssClass="form-control ll" Width="120px"></asp:dropdownlist></div>
											<div class="col">Lab Number</div>
											<div class="col"><asp:label id="lblLabNumber" runat="server"></asp:label>&nbsp;</div>
                                            <div class="col"></div>
										</div>
                                          <br />
										<div class="row">
											<div class="col">Closure-in-mm</div>
											<div class="col" <asp:label id="lblClosure" runat="server" Height="3px"></asp:label><asp:label id="ini" runat="server" Visible="False"></asp:label><asp:label id="fin" runat="server" Visible="False"></asp:label></div>
											<div class="col" >Nature Of Closure</div>
											<div class="col"><asp:radiobuttonlist id="radClosure" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" Enabled="False" CssClass="rbl">
													<asp:ListItem Value="Open" Selected="True">&nbsp;Open&nbsp;</asp:ListItem>
													<asp:ListItem Value="Closed">&nbsp;Closed&nbsp;</asp:ListItem>
													<asp:ListItem Value="Not Done">&nbsp;Not Done&nbsp;</asp:ListItem>
													<asp:ListItem Value="Skip">&nbsp;Skip&nbsp;</asp:ListItem>
												</asp:radiobuttonlist></div>
                                            <div class="col-sm" ></div>
                                            
										</div>
                                          <br />
									</TABLE>
									<TABLE id="Table3" class="table">
										<div class="row">
											<div class="col">&nbsp;</div>
											<div class="col">RIM</div>
											<div class="col">PLATE</div>
											<div class="col"colSpan="1" rowSpan="1">CharpyU-notch</div>
											<div class="col" colSpan="1" rowSpan="1">KU in Joules RIM</div>
										</div>
                                          <br />
										<div class="row">
											<div class="col">UTS(N/mm<SUP>2</SUP>)</div>
											<div class="col"><asp:textbox id="txtUTS_rim" tabIndex="2" runat="server" AutoPostBack="True" CssClass="form-control" Width="120px"></asp:textbox></div>
											<div class="col"><asp:textbox id="txtUTS_plate" tabIndex="6" runat="server" AutoPostBack="True" CssClass="form-control" Width="120px"></asp:textbox></div>
											<div class="col"><FONT size="4">&nbsp;a</FONT></div>
											<div class="col" colSpan="1" rowSpan="1"><asp:textbox id="txtJoules_a" tabIndex="10" runat="server" AutoPostBack="True" CssClass="form-control" Width="120px"></asp:textbox></div>
										</div>
                                          <br />
										<div class="row">
											<div class="col">YS(N/mm<SUP>2</SUP>)</div>
											<div class="col"><asp:textbox id="txtYS_rim" tabIndex="3" runat="server" AutoPostBack="True" CssClass="form-control" Width="120px"></asp:textbox></div>
											<div class="col"><asp:textbox id="txtYS_plate" tabIndex="7" runat="server" AutoPostBack="True" CssClass="form-control" Width="120px"></asp:textbox></div>
											<div class="col">&nbsp;<FONT size="4">b</FONT></div>
											<div class="col" colSpan="1" rowSpan="1"><asp:textbox id="txtJoules_b" tabIndex="11" runat="server" AutoPostBack="True" CssClass="form-control" Width="120px"></asp:textbox></div>
										</div>
                                          <br />
										<div class="row">
											<div class="col">Elongation&nbsp; %</div>
											<div class="col"><asp:textbox id="txtKlengation_rim" tabIndex="4" runat="server" AutoPostBack="True" CssClass="form-control" Width="120px"></asp:textbox></div>
											<div class="col"><asp:textbox id="txtKlengation_plate" tabIndex="8" runat="server" AutoPostBack="True" CssClass="form-control" Width="120px"></asp:textbox></div>
											<div class="col" colSpan="1" rowSpan="1">&nbsp;<FONT size="4">c</FONT></div>
											<div class="col" colSpan="1" rowSpan="1"><asp:textbox id="txtJoules_c" tabIndex="12" runat="server" AutoPostBack="True" CssClass="form-control" width="120px"></asp:textbox></div>
										</div>
                                          <br />
										<div class="row">
											<div class="col">Reduction in Area %</div>
											<div class="col"><asp:textbox id="txtRedn_rim" tabIndex="5" runat="server" AutoPostBack="True" CssClass="form-control" Width="120px"></asp:textbox></div>
											<div class="col"><asp:textbox id="txtRedn_plate" tabIndex="9" runat="server" CssClass="form-control" Width="120px"></asp:textbox ></div>
											<div class="col"colSpan="1" rowSpan="1">&nbsp;
												<asp:label id="lblAvg" runat="server"></asp:label></div>
											<div class="col" colSpan="1" rowSpan="1"><asp:label id="lblJoules" runat="server" ForeColor="Red"></asp:label></div>
										</div>
                                          <br />
									</TABLE>
                <div class="row">
											<div class="col" align="center">
									<asp:button id="btnSave" runat="server" Text="Save" Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark"></asp:button></div>
                    </div>
                <br />
									<TABLE id="Table5" class="table">
										<div class="row">
											<div class="col">Wheel Number</div>
											<div class="col"><asp:label id="lblWheel" runat="server" Width="80px"></asp:label>&nbsp;</div>
											<div class="col">Cast date</div>
											<div class="col"><asp:label id="lblCastdate" runat="server"></asp:label>&nbsp;</div>
										</div>
                                          <br />
										<div class="row">
											<div class="col">Received Date</div>
											<div class="col"><asp:label id="lblReceiveddate" runat="server"></asp:label>&nbsp;&nbsp;</div>
											<div class="col">Wheel Class</div>
											<div class="col"><asp:label id="lblWheelClass" runat="server"></asp:label>&nbsp;</div>
										</div>
                                        <br />
										<div class="row">
											<div class="col">Heat Range</div>
											<div class="col"><asp:label id="lblHeatrange" runat="server"></asp:label>&nbsp;</div>
											<div class="col">Test Type</div>
											<div class="col"><asp:label id="lblTestType" runat="server"></asp:label>&nbsp;</div>
										</div>
                                          <br />
										<div class="row">
											<div class="col">Wheel Type</div>
											<div class="col"><asp:label id="lblWheeltype" runat="server"></asp:label>&nbsp;</div>
											<div class="col">Pour Order</div>
											<div class="col"><asp:label id="lblPourorder" runat="server"></asp:label>&nbsp;</div>
										</div>
                                          <br />
										<div class="row">
											<div class="col">Cope Life</div>
											<div class="col"><asp:label id="lblCopelife" runat="server"></asp:label>&nbsp;</div>
											<div class="col">Drag Life</div>
											<div class="col"><asp:label id="lblDraglife" runat="server"></asp:label>&nbsp;</div>
										</div>
                                          <br />
										<div class="row">
											<div class="col">Tube in Temp</div>
											<div class="col"><asp:label id="lblTubetemp" runat="server"></asp:label>&nbsp;&nbsp;</div>
											<div class="col">Final Temperature</div>
											<div class="col"><asp:label id="lblFinaltemp" runat="server"></asp:label>&nbsp;&nbsp;</div>
										</div>
									</TABLE>
				</div></div>				
		</form>
            </div>
         <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;position:relative;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>

	

	</body>
</HTML>
