<%@ Page Language="vb" AutoEventWireup="false" Codebehind="BHNPostResultAdd.aspx.vb" Inherits="WebApplication2.BHNPostResultAdd" smartNavigation="False" Culture="en-GB" uiCulture="en-GB" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>BHNPostResultAdd</title>
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
			
									<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="608" border="1">
										<div class="row">
											<div class="col"vAlign="top" noWrap align="middle" colSpan="4" rowSpan="1"><FONT size="5px">Wheel 
														Mechanical and Metallographic properties&nbsp;&nbsp;&nbsp;&nbsp;
														<asp:label id="lblMode" runat="server" ForeColor="Blue"></asp:label></FONT>
										</div>
                                            <br />
                                           
                                            </div></TABLE>

                 <br />
                                           <br />
                                          
										
												<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label>
												<TABLE id="Table12" class="table">
													<div class="row">
														<div class="col">Wheel Number</div>
														<div class="col">
															<asp:dropdownlist id="ddlLabNumber" tabIndex="1" runat="server" AutoPostBack="True" CssClass="form-control ll" Width="120px"></asp:dropdownlist></div>
														<div class="col">Lab Number</div>
														<div class="col">
															<asp:label id="lblLabNumber" runat="server"></asp:label></div>
                                                        <div class="col"></div>
													</div>
                                                     <br />
												</TABLE>
												
                                                <TABLE id="Table3" class="table">

													<div class="row">
														<div class="col" >Closure In mm</div>
														<div class="col" style="margin-left:40px">
															<asp:label id="lblClosure" runat="server" Height="3px"></asp:label>
															<asp:label id="ini" runat="server" Visible="False"></asp:label>
															<asp:label id="fin" runat="server" Visible="False"></asp:label></div>
														<div class="col" style="margin-left:30px">Nature Of Closure
														</div>
														<div class="col" ><asp:radiobuttonlist id="radClosure" runat="server" Width="275px" Enabled="False" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl">
																<asp:ListItem Value="Open" Selected="True">&nbsp;Open&nbsp;</asp:ListItem>
																<asp:ListItem Value="Closed">&nbsp;Closed&nbsp;</asp:ListItem>
																<asp:ListItem Value="Not Done">&nbsp;Not Done&nbsp;</asp:ListItem>
																<asp:ListItem Value="Skip">&nbsp;Skip&nbsp;</asp:ListItem>
															</asp:radiobuttonlist></div>
                                                           <div class="col-sm-2"></div>
													</div>
                                                     <br />
													<div class="row">
														<div class="col">&nbsp;</div>
														<div class="col">RIM</div>
														<div class="col">PLATE</div>
														<div class="col" colSpan="1" rowSpan="1">CharpyUnotch</div>
														<div class="col" colSpan="1" rowSpan="1">
															KUInJoulesRIM</div>
													</div>
                                                     <br />
													<div class="row">
														<div class="col">
															UTS(N/mm<SUP>2</SUP>)</div>
														<div class="col"><asp:textbox id="txtUTS_rim" tabIndex="2" runat="server" AutoPostBack="True" CssClass="form-control" Width="120px"></asp:textbox></div>
														<div class="col"><asp:textbox id="txtUTS_plate" tabIndex="6" runat="server" AutoPostBack="True" CssClass="form-control" Width="120px"></asp:textbox></div>
														<div class="col"><FONT size="4">&nbsp;a</FONT></div>
														<div class="col"colSpan="1" rowSpan="1"><asp:textbox id="txtJoules_a" tabIndex="10" runat="server" AutoPostBack="True" CssClass="form-control" Width="120px"></asp:textbox></div>
													</div>
                                                     <br />
													<div class="row">
														<div class="col">YS(N/mm<SUP>2</SUP>)</div>
														<div class="col"><asp:textbox id="txtYS_rim" tabIndex="3" runat="server" AutoPostBack="True" CssClass="form-control" Width="120px"></asp:textbox></div>
														<div class="col"><asp:textbox id="txtYS_plate" tabIndex="7" runat="server" AutoPostBack="True" CssClass="form-control" Width="120px"></asp:textbox></div>
														<div class="col">&nbsp;<FONT size="4">b</FONT></div>
														<div class="col"colSpan="1" rowSpan="1"><asp:textbox id="txtJoules_b" tabIndex="11" runat="server" AutoPostBack="True" CssClass="form-control" Width="120px"></asp:textbox></div>
													</div>
                                                     <br />
													<div class="row">
														<div class="col">
															Elongation %</div>
														<div class="col"><asp:textbox id="txtKlengation_rim" tabIndex="4" runat="server" AutoPostBack="True" CssClass="form-control" Width="120px"></asp:textbox></div>
														<div class="col"><asp:textbox id="txtKlengation_plate" tabIndex="8" runat="server" AutoPostBack="True" CssClass="form-control" Width="120px"></asp:textbox></div>
														<div class="col"colSpan="1" rowSpan="1">&nbsp;<FONT size="4">c</FONT></div>
														<div class="col"colSpan="1" rowSpan="1"><asp:textbox id="txtJoules_c" tabIndex="12" runat="server" AutoPostBack="True" CssClass="form-control" Width="120px"></asp:textbox></div>
													</div>
                                                     <br />
													<div class="row">
														<div class="col">
															Reductionn in Area %</div>
														<div class="col"><asp:textbox id="txtRedn_rim" tabIndex="5" runat="server" AutoPostBack="True" CssClass="form-control" Width="120px"></asp:textbox></div>
														<div class="col"><asp:textbox id="txtRDedn_plate" tabIndex="9" runat="server" CssClass="form-control" Width="120px"></asp:textbox></div>
														<div class="col"colSpan="1" rowSpan="1">&nbsp;
															<asp:label id="lblAvg" runat="server"></asp:label></div>
														<div class="col"colSpan="1" rowSpan="1"><asp:label id="lblJoules" runat="server" ForeColor="Red"></asp:label></div>
													</div>
                                                     <br />
												</TABLE>

												<TABLE id="Table11" class="table">
													<div class="row">
														<div class="col">Inclusion</div>
														<div class="col">Thin</div>
														<div class="col">Thick</div>
														

													</div>
                                                     <br />
													<div class="row">
														<div class="col"align="middle">A</div>
														<div class="col" >
															<asp:radiobuttonlist id="rblAThin" tabIndex="13" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rbl">
																<asp:ListItem Value="0" Selected="True">&nbsp;0&nbsp;</asp:ListItem>
																<asp:ListItem Value="0.5">&nbsp;0.5&nbsp;</asp:ListItem>
																<asp:ListItem Value="1">&nbsp;1&nbsp;</asp:ListItem>
																<asp:ListItem Value="1.5">&nbsp;1.5&nbsp;</asp:ListItem>
																<asp:ListItem Value="2">&nbsp;2&nbsp;</asp:ListItem>
																<asp:ListItem Value="2.5">&nbsp;2.5&nbsp;</asp:ListItem>
																<asp:ListItem Value="3">&nbsp;3&nbsp;</asp:ListItem>
															</asp:radiobuttonlist></div>
														<div class="col">
															<asp:radiobuttonlist id="rblAThick" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rbl">
																<asp:ListItem Value="0" Selected="True">&nbsp;0&nbsp;</asp:ListItem>
																<asp:ListItem Value="0.5">&nbsp;0.5&nbsp;</asp:ListItem>
																<asp:ListItem Value="1">&nbsp;1&nbsp;</asp:ListItem>
																<asp:ListItem Value="1.5">&nbsp;1.5&nbsp;</asp:ListItem>
																<asp:ListItem Value="2">&nbsp;2&nbsp;</asp:ListItem>
																<asp:ListItem Value="2.5">&nbsp;2.5&nbsp;</asp:ListItem>
																<asp:ListItem Value="3">&nbsp;3&nbsp;</asp:ListItem>
															</asp:radiobuttonlist></div>
                                                       
													</div>
                                                     <br />
													<div class="row">
														<div class="col"align="middle">B</div>
														<div class="col"><asp:radiobuttonlist id="rblBThin" runat="server"  RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl">
																<asp:ListItem Value="0" Selected="True">&nbsp;0&nbsp;</asp:ListItem>
																<asp:ListItem Value="0.5">&nbsp;0.5&nbsp;</asp:ListItem>
																<asp:ListItem Value="1">&nbsp;1&nbsp;</asp:ListItem>
																<asp:ListItem Value="1.5">&nbsp;1.5&nbsp;</asp:ListItem>
																<asp:ListItem Value="2">&nbsp;2&nbsp;</asp:ListItem>
																<asp:ListItem Value="2.5">&nbsp;2.5&nbsp;</asp:ListItem>
																<asp:ListItem Value="3">&nbsp;3&nbsp;</asp:ListItem>
															</asp:radiobuttonlist></div>
														<div class="col"><asp:radiobuttonlist id="rblBThick" runat="server" CssClass="rbl" RepeatLayout="Flow" RepeatDirection="Horizontal">
																<asp:ListItem Value="0" Selected="True">&nbsp;0&nbsp;</asp:ListItem>
																<asp:ListItem Value="0.5">&nbsp;0.5&nbsp;</asp:ListItem>
																<asp:ListItem Value="1">&nbsp;1&nbsp;</asp:ListItem>
																<asp:ListItem Value="1.5">&nbsp;1.5&nbsp;</asp:ListItem>
																<asp:ListItem Value="2">&nbsp;2&nbsp;</asp:ListItem>
																<asp:ListItem Value="2.5">&nbsp;2.5&nbsp;</asp:ListItem>
																<asp:ListItem Value="3">&nbsp;3&nbsp;</asp:ListItem>
															</asp:radiobuttonlist></div>
													</div>
                                                     <br />
													<div class="row">
														<div class="col"align="middle">C</div>
														<div class="col">
															<asp:radiobuttonlist id="rblCThin" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rbl">
																<asp:ListItem Value="0" Selected="True">&nbsp;0&nbsp;</asp:ListItem>
																<asp:ListItem Value="0.5">&nbsp;0.5&nbsp;</asp:ListItem>
																<asp:ListItem Value="1">&nbsp;1&nbsp;</asp:ListItem>
																<asp:ListItem Value="1.5">&nbsp;1.5&nbsp;</asp:ListItem>
																<asp:ListItem Value="2">&nbsp;2&nbsp;</asp:ListItem>
																<asp:ListItem Value="2.5">&nbsp;2.5&nbsp;</asp:ListItem>
																<asp:ListItem Value="3">&nbsp;3&nbsp;</asp:ListItem>
															</asp:radiobuttonlist></div>
														<div class="col">
															<asp:radiobuttonlist id="rblCThick" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rbl">
																<asp:ListItem Value="0" Selected="True">&nbsp;0&nbsp;</asp:ListItem>
																<asp:ListItem Value="0.5">&nbsp;0.5&nbsp;</asp:ListItem>
																<asp:ListItem Value="1">&nbsp;1&nbsp;</asp:ListItem>
																<asp:ListItem Value="1.5">&nbsp;1.5&nbsp;</asp:ListItem>
																<asp:ListItem Value="2">&nbsp;2&nbsp;</asp:ListItem>
																<asp:ListItem Value="2.5">&nbsp;2.5&nbsp;</asp:ListItem>
																<asp:ListItem Value="3">&nbsp;3&nbsp;</asp:ListItem>
															</asp:radiobuttonlist></div>
													</div>
                                                     <br />
													<div class="row">
														<div class="col"align="middle">D</div>
														<div class="col"><asp:radiobuttonlist id="rblDThin" runat="server" CssClass="rbl" RepeatLayout="Flow" RepeatDirection="Horizontal">
																<asp:ListItem Value="0" Selected="True">&nbsp;0&nbsp;</asp:ListItem>
																<asp:ListItem Value="0.5">&nbsp;0.5&nbsp;</asp:ListItem>
																<asp:ListItem Value="1">&nbsp;1&nbsp;</asp:ListItem>
																<asp:ListItem Value="1.5">&nbsp;1.5&nbsp;</asp:ListItem>
																<asp:ListItem Value="2">&nbsp;2&nbsp;</asp:ListItem>
																<asp:ListItem Value="2.5">&nbsp;2.5&nbsp;</asp:ListItem>
																<asp:ListItem Value="3">&nbsp;3&nbsp;</asp:ListItem>
															</asp:radiobuttonlist></div>
														<div class="col">
															<asp:radiobuttonlist id="rblDThick" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rbl">
																<asp:ListItem Value="0" Selected="True">&nbsp;0&nbsp;</asp:ListItem>
																<asp:ListItem Value="0.5">&nbsp;0.5&nbsp;</asp:ListItem>
																<asp:ListItem Value="1">&nbsp;1&nbsp;</asp:ListItem>
																<asp:ListItem Value="1.5">&nbsp;1.5&nbsp;</asp:ListItem>
																<asp:ListItem Value="2">&nbsp;2&nbsp;</asp:ListItem>
																<asp:ListItem Value="2.5">&nbsp;2.5&nbsp;</asp:ListItem>
																<asp:ListItem Value="3">&nbsp;3&nbsp;</asp:ListItem>
															</asp:radiobuttonlist></div>
													</div>
                                                     <br />
												</TABLE>
												<TABLE id="Table4" class="table">
													<div class="row">
														<div class="col" noWrap colSpan="1" rowSpan="1">MicroStructure</div>
														<div class="col" colSpan="3">
															<asp:radiobuttonlist id="rblStructure" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rbl">
																<asp:ListItem Value="Uniform Fine Pearlitic" Selected="True">&nbsp;Uniform Fine Pearlitic&nbsp;</asp:ListItem>
																<asp:ListItem Value="Uniform Pearlitic">&nbsp;Uniform Pearlitic&nbsp;</asp:ListItem>
																<asp:ListItem Value="Anything">&nbsp;Anything&nbsp;</asp:ListItem>
															</asp:radiobuttonlist></div>
                                                        <div class="col"></div>
													</div>
                                                     <br />
													<div class="row">
														<div class="col" noWrap width="101">Grain Size No.</div>
														<div class="col"colSpan="3">
															<asp:checkboxlist id="chkGrain" runat="server" Height="5px" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rbl">
																<asp:ListItem Value="4">&nbsp;4&nbsp;</asp:ListItem>
																<asp:ListItem Value="5">&nbsp;5&nbsp;</asp:ListItem>
																<asp:ListItem Value="6">&nbsp;6&nbsp;</asp:ListItem>
																<asp:ListItem Value="7">&nbsp;7&nbsp;</asp:ListItem>
																<asp:ListItem Value="8">&nbsp;8&nbsp;</asp:ListItem>
															</asp:checkboxlist></div>
                                                        <div class="col"></div>
													</div>
                                                     <br />
													<div class="row">
														<div class="col">Macro</div>
														<div class="col" colSpan="3">
															<asp:radiobuttonlist id="rblMacro" runat="server" Height="11px" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rbl">
																<asp:ListItem Value="Satisfactory" Selected="True">&nbsp;Satisfactory&nbsp;</asp:ListItem>
																<asp:ListItem Value="Not Satisfactory">&nbsp;Not Satisfactory&nbsp;</asp:ListItem>
																<asp:ListItem Value="Not Done">&nbsp;Not Done&nbsp;</asp:ListItem>
															</asp:radiobuttonlist></div>
                                                        <div class="col"></div>
													</div>
                                                     <br />
													<div class="row">
														<div class="col">Test Results</div>
														<div class="col"colSpan="3">
															<asp:radiobuttonlist id="rblResult" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rbl">
																<asp:ListItem Value="P" Selected="True">&nbsp;Pass&nbsp;</asp:ListItem>
																<asp:ListItem Value="R">&nbsp;Reject&nbsp;</asp:ListItem>
															</asp:radiobuttonlist></div>
                                                        <div class="col"></div>
													</div>
                                                     <br />
													<div class="row">
														<div class="col">Remarks</div>
														<div class="col"colSpan="3">
															<asp:textbox id="txtRemarks" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:textbox></div>
                                                        <div class="col"></div>
													</div>
                                                     <br />
												</TABLE>
                                                <div class="row">
														<div class="col" align="center">
												<asp:button id="btnSave" runat="server" Text="Save" Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark"></asp:button></div>
                                                    </div >
                <br />
									
								
									<TABLE id="Table8" class="table"></TABLE>
										
												<asp:radiobuttonlist id="rblLabValues" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rbl">
													<asp:ListItem Value="Wheel Details">&nbsp;Wheel Details&nbsp;</asp:ListItem>
													<asp:ListItem Value="Wheel Details">&nbsp;Wheel Details&nbsp;</asp:ListItem>
													<asp:ListItem Value="Chemical">&nbsp;Chemical&nbsp;</asp:ListItem>
													<asp:ListItem Value="BHN Values">&nbsp;BHN Values&nbsp;</asp:ListItem>
													<asp:ListItem Value="Spec">&nbsp;Spec&nbsp;</asp:ListItem>
													<asp:ListItem Value="HT Details">&nbsp;HT Details&nbsp;</asp:ListItem>
												</asp:radiobuttonlist>
												<asp:panel id="Panel1" runat="server" >
													<TABLE id="Table5" class="table" >
														<div class="row">
															<div class="col">WheelNumber</div>
															<div class="col">
																<asp:label id="lblWheel" runat="server" Width="80px"></asp:label></div>
															<div class="col">Cast date</div>
															<div class="col">
																<asp:label id="lblCastdate" runat="server"></asp:label></div>
														</div>
                                                         <br />
														<div class="row">
															<div class="col">Received Date</div>
															<div class="col">
																<asp:label id="lblReceiveddate" runat="server"></asp:label></div>
															<div class="col">Wheel Class</div>
															<div class="col">
																<asp:label id="lblWheelClass" runat="server"></asp:label></div>
														</div>
                                                         <br />
														<div class="row">
															<div class="col">Heat Range</div>
															<div class="col">
																<asp:label id="lblHeatrange" runat="server"></asp:label></div>
															<div class="col">Test Type</div>
															<div class="col">
																<asp:label id="lblTestType" runat="server"></asp:label></div>
														</div>
                                                         <br />
														<div class="row">
															<div class="col">Wheel Type</div>
															<div class="col">
																<asp:label id="lblWheeltype" runat="server"></asp:label></div>
															<div class="col">Pour Order</div>
															<div class="col">
																<asp:label id="lblPourorder" runat="server"></asp:label></div>
														</div>
                                                         <br />
														<div class="row">
															<div class="col">Cope Life</div>
															<div class="col">
																<asp:label id="lblCopelife" runat="server"></asp:label></div>
															<div class="col">Drag Life</div>
															<div class="col">
																<asp:label id="lblDraglife" runat="server"></asp:label></div>
														</div>
                                                         <br />
														<div class="row">
															<div class="col">Tube in Temp</div>
															<div class="col">
																<asp:label id="lblTubetemp" runat="server"></asp:label></div>
															<div class="col">Final Temperature</div>
															<div class="col">
																<asp:label id="lblFinaltemp" runat="server"></asp:label></div>
														</div>
                                                         <br />
													</TABLE>
												</asp:panel>
												<asp:panel id="Panel2" runat="server" >
													<TABLE id="Table7" class="table">
														<div class="row">
															<div class="col">Carbon</div>
															<div class="col">
																<asp:textbox id="txtC" runat="server" Enabled="False" CssClass="form-control">0.0</asp:textbox>%</div>
															<div class="col">Manganese</div>
															<div class="col">
																<asp:textbox id="txtMn" runat="server" Enabled="False" CssClass="form-control">0.0</asp:textbox>%</div>
														</div>
                                                         <br />
														<div class="row">
															<div class="col">Silicon</div>
															<div class="col">
																<asp:textbox id="txtSi" runat="server" Enabled="False" CssClass="form-control">0.0</asp:textbox>%</div>
															<div class="col">Phosphorus</div>
															<div class="col">
																<asp:textbox id="txtP" runat="server" AutoPostBack="True" Enabled="False" CssClass="form-control">0.0</asp:textbox>%</div>
														</div>
                                                         <br />
														<div class="row">
															<div class="col">Sulphur</div>
															<div class="col">
																<asp:textbox id="txtS" runat="server" AutoPostBack="True" Enabled="False" CssClass="form-control">0.0</asp:textbox>%</div>
															<div class="col">Chromium</div>
															<div class="col">
																<asp:textbox id="txtCr" runat="server" Enabled="False" CssClass="form-control">0.0</asp:textbox>%</div>
														</div>
                                                         <br />
														<div class="row">
															<div class="col">Nickel</div>
															<div class="col">
																<asp:textbox id="txtNi" runat="server" Enabled="False" CssClass="form-control">0.0</asp:textbox>%</div>
															<div class="col">Copper</div>
															<div class="col">
																<asp:textbox id="txtCu" runat="server" Enabled="False" CssClass="form-control">0.0</asp:textbox>%</div>
														</div>
                                                         <br />
														<div class="row">
															<div class="col">Molybdenum</div>
															<div class="col">
																<asp:textbox id="txtMo" runat="server" Enabled="False" CssClass="form-control">0.0</asp:textbox>%</div>
															<div class="col">Vanadium</div>
															<div class="col">
																<asp:textbox id="txtV" runat="server" Enabled="False" CssClass="form-control">0.0</asp:textbox>%</div>
														</div>
														<div class="row">
															<div class="col">Phosphorus+Sulphur</div>
															<div class="col">
																<asp:textbox id="txtP_S" runat="server" Enabled="False" CssClass="form-control">0.0</asp:textbox>%</div>
															<div class="col">Alunimum</div>
															<div class="col">
																<asp:textbox id="txtAl" runat="server" Enabled="False" CssClass="form-control">0.0</asp:textbox>%</div>
														</div>
                                                         <br />
														<div class="row">
															<div class="col">Nitrogen</div>
															<div class="col">
																<asp:textbox id="txtN" runat="server" Enabled="False" CssClass="form-control">0.0</asp:textbox>ppm</div>
															<div class="col">Hydrogen</div>
															<div class="col">
																<asp:textbox id="txtH" runat="server" Enabled="False" CssClass="form-control">0.0</asp:textbox>ppm</div>
														</div>
                                                         <br />
													</TABLE>
												</asp:panel>
												<asp:panel id="Panel3"  runat="server">
													<uc1:BHNViewHardnessValues id="BHNViewHardnessValues1" ></uc1:BHNViewHardnessValues>
												</asp:panel>
												<asp:panel id="Panel4" runat="server">
													<TABLE id="Table9" class="table"></TABLE>
														
																<TABLE id="Table10" class="table">
																	<div class="row">
																		<div class="col">Charge-in-Date:</div>
																		<div class="col">
																			<asp:textbox id="txtNFChargeDate" runat="server" Enabled="False" CssClass="form-control"></asp:textbox></div>
																		<div class="col">Time (&nbsp;hh:mm&nbsp;):</div>
																		<div class="col">
																			<asp:textbox id="txtNFChargeTime" runat="server" Enabled="False" CssClass="form-control"></asp:textbox></div>
																		<div class="col"style="WIDTH: 17px">Wheel Charge condition:</div>
																		<div class="col">
																			<asp:dropdownlist id="ddlNFChargeCondition" runat="server" Enabled="False" CssClass="form-control ll">
																				<asp:ListItem Value="Hot" Selected="True">Hot</asp:ListItem>
																				<asp:ListItem Value="Cold">Cold</asp:ListItem>
																			</asp:dropdownlist></div>
																		<div class="col"colSpan="2">Wheel Discharge Time:(hh:mm)</div>
																		<div class="col">
																			<asp:textbox id="txtNFDischargeTime" runat="server" Enabled="False" CssClass="form-control" MaxLength="5"></asp:textbox></div>
																	</div>
                                                                     <br />
																	<div class="row">
																		<div class="col">Quencher No:</div>
																		<div class="col"style="WIDTH: 109px">
																			<asp:dropdownlist id="ddlQuencherNo" runat="server" Enabled="False" CssClass="form-control ll"></asp:dropdownlist></div>
																		<div class="col">Duration:</div>
																		<div class="col">
																			<asp:textbox id="txtQTimeMin" runat="server" Enabled="False" CssClass="form-control" MaxLength="1"></asp:textbox>min</div>
																		<div class="col"style="WIDTH: 17px">
																			<asp:textbox id="txtQTimeSec" runat="server" Enabled="False" CssClass="form-control"></asp:textbox>sec</div>
																		<div class="col"></div>
																		<div class="col"></div>
																		<div class="col"></div>
																		<div class="col"></div>
																	</div>
                                                                     <br />
																	<div class="row">
																		<div class="col">Zone Number:</div>
																		<div class="col">Zone 1</div>
																		<div class="col">Zone 2</div>
																		<div class="col">Zone 3</div>
																		<div class="col">Zone 4</div>
																		<div class="col">Zone 5</div>
																		<div class="col">Zone 6</div>
																		<div class="col">Zone 7</div>
																		<div class="col">Zone 8</div>
																	</div>
                                                                     <br />
																	<div class="row">
																		<div class="col">Temperature of NF (close to discharge time )</div>
																		<div class="col">
																			<asp:textbox id="txtNFZone1" tabIndex="-1" runat="server" Enabled="False" CssClass="form-control" MaxLength="3">0</asp:textbox></div>
																		<div class="col">
																			<asp:textbox id="txtNFZone2" runat="server" Enabled="False" CssClass="form-control" MaxLength="4"></asp:textbox></div>
																		<div class="col">
																			<asp:textbox id="txtNFZone3" runat="server" Enabled="False" CssClass="form-control" MaxLength="4"></asp:textbox></div>
																		<div class="col">
																			<asp:textbox id="txtNFZone4" runat="server" Enabled="False" CssClass="form-control" MaxLength="3"></asp:textbox></div>
																		<div class="col">
																			<asp:textbox id="txtNFZone5" runat="server" Enabled="False" CssClass="form-control" MaxLength="3"></asp:textbox></div>
																		<div class="col">
																			<asp:textbox id="txtNFZone6" runat="server" Enabled="False" CssClass="form-control" MaxLength="3"></asp:textbox></div>
																		<div class="col">
																			<asp:textbox id="txtNFZone7" runat="server" Enabled="False" CssClass="form-control" MaxLength="3"></asp:textbox></div>
																		<div class="col"></div>
																	</div>
                                                                     <br />
																	<div class="row">
																		<div class="col">Temperature of DF (close to discharge time )</div>
																		<div class="col">
																			<asp:textbox id="txtDFZone1" runat="server" Enabled="False" CssClass="form-control" MaxLength="3"></asp:textbox></div>
																		<div class="col">
																			<asp:textbox id="txtDFZone2" runat="server" Enabled="False" CssClass="form-control" MaxLength="3"></asp:textbox></div>
																		<div class="col">
																			<asp:textbox id="txtDFZone3" runat="server" Enabled="False" CssClass="form-control" MaxLength="3"></asp:textbox></div>
																		<div class="col">
																			<asp:textbox id="txtDFZone4" runat="server" Enabled="False" CssClass="form-control" MaxLength="3"></asp:textbox></div>
																		<div class="col">
																			<asp:textbox id="txtDFZone5" runat="server" Enabled="False" CssClass="form-control" MaxLength="3"></asp:textbox></div>
																		<div class="col">
																			<asp:textbox id="txtDFZone6" runat="server" Enabled="False" CssClass="form-control" MaxLength="3"></asp:textbox></div>
																		<div class="col">
																			<asp:textbox id="txtDFZone7" runat="server" Enabled="False" CssClass="form-control" MaxLength="3"></asp:textbox></div>
																		<div class="col">
																			<asp:textbox id="txtDFZone8" runat="server" Enabled="False" CssClass="form-control" MaxLength="3"></asp:textbox></div>
																	</div>
                                                                     <br />
																	<div class="row">
																		<div class="col">Hub Cooler</div>
																		<div class="col">
																			<asp:dropdownlist id="ddlHubCooler1" runat="server" Enabled="False" CssClass="form-control ll"></asp:dropdownlist></div>
																		<div class="col">
																			<asp:dropdownlist id="ddlHubCooler2" runat="server" Enabled="False" CssClass="form-control ll"></asp:dropdownlist></div>
																		<div class="col">
																			<asp:dropdownlist id="ddlHubCooler3" runat="server" Enabled="False" CssClass="form-control ll"></asp:dropdownlist></div>
																		<div class="col"></div>
																		<div class="col"></div>
																		<div class="col"></div>
																		<div class="col"></div>
																		<div class="col"></div>
																	</div>
                                                                     <br />
																	<div class="row">
																		<div class="col">Duration ( in sec )</div>
																		<div class="col">
																			<asp:textbox id="txtHC1" runat="server" Enabled="False" CssClass="form-control" MaxLength="2"></asp:textbox></div>
																		<div class="col">
																			<asp:textbox id="txtHC2" runat="server" Enabled="False" CssClass="form-control" MaxLength="2"></asp:textbox></div>
																		<div class="col">
																			<asp:textbox id="txtHC3" runat="server" Enabled="False" CssClass="form-control" MaxLength="2"></asp:textbox></div>
																		<div class="col"></div>
																		<div class="col"></div>
																		<div class="col"></div>
																		<div class="col"></div>
																		<div class="col"></div>
																	</div>
                                                                     <br />
																</TABLE>
															
													
												</asp:panel>
									
									<asp:panel id="pnlImage" runat="server" Width="117px">
										<asp:Panel id="pnlA" runat="server" Width="24px">
											<asp:Image id="ImageA" runat="server" ImageUrl="../../NewFolder1/imgClassA.jpg"></asp:Image>
										</asp:Panel>
										<asp:Panel id="pnlB" runat="server" Width="51px">
											<asp:Image id="Image1" runat="server" Height="568px" Width="600px" ImageUrl="../../NewFolder1/imgClassB.jpg"></asp:Image>
										</asp:Panel>
										<asp:Panel id="pnlSpl" runat="server">
											<asp:Image id="ImageSpl" runat="server" ImageUrl="../../NewFolder1/imgClassSpl.jpg"></asp:Image>
										</asp:Panel>
									</asp:panel>

                </div></div>
		</form>
            </div>
        <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;position:relative;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>

	</body>
</HTML>
