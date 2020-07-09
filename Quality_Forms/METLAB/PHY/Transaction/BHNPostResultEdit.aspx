<%@ Page Language="vb" AutoEventWireup="false" Codebehind="BHNPostResultEdit.aspx.vb" Inherits="WebApplication2.BHNPostResultEdit" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>BHNPostResultEdit</title>
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
			<TABLE id="Table2" class="table"></TABLE>
				
						<TABLE id="Table1" class="table">
							<div class="row">
								<div class="col"vAlign="top" noWrap align="middle" colSpan="4" rowSpan="1"><STRONG><FONT size="5px">Wheel 
											Mechanical and Metallographic properties - Edit</FONT></STRONG></div>
							</div>
                            <br />
							<div class="row">
								<div class="col"colSpan="3"><asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label>&nbsp;</div>
								<div class="col"><asp:label id="lblMode" runat="server" ForeColor="Blue"></asp:label>&nbsp;</div>
							</div>
                             <br />
							<div class="row">
								<div class="col">Wheel Number</div>
								<div class="col"><asp:textbox id="txtWheelNumber" runat="server" CssClass="form-control" AutoPostBack="True"  Width="120px"></asp:textbox></div>
								<div class="col">Lab Number</div>
								<div class="col"><asp:label id="lblLabNumber" runat="server"></asp:label>&nbsp;</div>
                                <div class="col"></div>
							</div>
                             <br />
						</TABLE>
							
									<TABLE id="Table3" class="table">
										<div class="row">
											<div class="col">Closure in mm</div>
											<div class="col"><asp:label id="lblClosure" runat="server" Height="3px"></asp:label><asp:label id="ini" runat="server" Visible="False"></asp:label><asp:label id="fin" runat="server" Visible="False"></asp:label></div>
											<div class="col">Nature of closure
											</div>
											<div class="col">
												<asp:radiobuttonlist id="radClosure" runat="server" CssClass="rbl" Enabled="False" RepeatLayout="Flow" RepeatDirection="Horizontal">
													<asp:ListItem Value="Open" Selected="True">&nbsp;Open&nbsp;</asp:ListItem>
													<asp:ListItem Value="Closed">&nbsp;Closed&nbsp;</asp:ListItem>
													<asp:ListItem Value="Not Done">&nbsp;Not Done&nbsp;</asp:ListItem>
													<asp:ListItem Value="Skip">&nbsp;Skip&nbsp;</asp:ListItem>
												</asp:radiobuttonlist></div>
                                             <div class="col"></div>
										</div>
                                         <br />
										<div class="row">
											<div class="col">&nbsp;</div>
											<div class="col">RIM</div>
											<div class="col">PLATE</div>
											<div class="col" colSpan="1" rowSpan="1">CharpyU-notch</div>
											<div class="col" colSpan="1" rowSpan="1">KU in Joules RIM</div>
										</div>
                                         <br />
										<div class="row">
											<div class="col">UTS (N/mm<SUP>2</SUP>)</div>
											<div class="col"><asp:textbox id="txtUTS_rim" tabIndex="2" runat="server" CssClass="form-control" AutoPostBack="True"  Width="120px"></asp:textbox></div>
											<div class="col"><asp:textbox id="txtUTS_plate" tabIndex="6" runat="server" CssClass="form-control" AutoPostBack="True"  Width="120px"></asp:textbox></div>
											<div class="col"><FONT size="4">&nbsp;a</FONT></div>
											<div class="col"><asp:textbox id="txtJoules_a" tabIndex="10" runat="server" CssClass="form-control" AutoPostBack="True"  Width="120px"></asp:textbox></div>
										</div>
                                         <br />
										<div class="row">
											<div class="col">YS (N/mm<SUP>2</SUP>)</div>
											<div class="col"><asp:textbox id="txtYS_rim" tabIndex="3" runat="server" CssClass="form-control" AutoPostBack="True"  Width="120px"></asp:textbox></div>
											<div class="col"><asp:textbox id="txtYS_plate" tabIndex="7" runat="server" CssClass="form-control" AutoPostBack="True"  Width="120px"></asp:textbox></div>
											<div class="col">&nbsp;<FONT size="4">b</FONT></div>
											<div class="col"colSpan="1" rowSpan="1"><asp:textbox id="txtJoules_b" tabIndex="11" runat="server" CssClass="form-control"  Width="120px" AutoPostBack="True"></asp:textbox></div>
										</div>
                                         <br />
										<div class="row">
											<div class="col">Elongation&nbsp; %</div>
											<div class="col"><asp:textbox id="txtKlengation_rim" tabIndex="4" runat="server" CssClass="form-control" AutoPostBack="True"  Width="120px"></asp:textbox></div>
											<div class="col"><asp:textbox id="txtKlengation_plate" tabIndex="8" runat="server" CssClass="form-control" AutoPostBack="True"  Width="120px"></asp:textbox></div>
											<div class="col" colSpan="1" rowSpan="1">&nbsp;<FONT size="4">c</FONT></div>
											<div class="col" colSpan="1" rowSpan="1"><asp:textbox id="txtJoules_c" tabIndex="12" runat="server" CssClass="form-control" AutoPostBack="True"  Width="120px"></asp:textbox></div>
										</div>
                                         <br />
										<div class="row">
											<div class="col">Reduction in Area %</div>
											<div class="col"><asp:textbox id="txtRedn_rim" tabIndex="5" runat="server" CssClass="form-control" AutoPostBack="True"  Width="120px"></asp:textbox></div>
											<div class="col"><asp:textbox id="txtRedn_plate" tabIndex="9" runat="server" CssClass="form-control"  Width="120px"></asp:textbox></div>
											<div class="col"colSpan="1" rowSpan="1">&nbsp;
												<asp:label id="lblAvg" runat="server"></asp:label></div>
											<div class="col" colSpan="1" rowSpan="1"><asp:label id="lblJoules" runat="server" ForeColor="Red"></asp:label></div>
										</div>
                                         <br />
									</TABLE>
									<TABLE id="Table4" class="table">
										<div class="row">
											<div class="col" ">&nbsp;Inclusion&nbsp;</div>
											<div class="col">&nbsp;Thin</div>
											
											<div class="col">Thick</div>
                                            <div class="col"></div>
										</div>
                                         <br />
										<div class="row">
											<div class="col" >A</div>
											<div class="col" style="margin-left:-70px"><asp:radiobuttonlist id="rblAThin" tabIndex="13" runat="server"  RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rbl">
													<asp:ListItem Value="0" Selected="True">&nbsp;0&nbsp;</asp:ListItem>
													<asp:ListItem Value="0.5">&nbsp;0.5&nbsp;</asp:ListItem>
													<asp:ListItem Value="1">&nbsp;1&nbsp;</asp:ListItem>
													<asp:ListItem Value="1.5">&nbsp;1.5&nbsp;</asp:ListItem>
													<asp:ListItem Value="2">&nbsp;2&nbsp;</asp:ListItem>
													<asp:ListItem Value="2.5">&nbsp;2.5&nbsp;</asp:ListItem>
													<asp:ListItem Value="3">&nbsp;3&nbsp;</asp:ListItem>
												</asp:radiobuttonlist></div>
										
											<div class="col"><asp:radiobuttonlist id="rblAThick" runat="server"  RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rbl">
													<asp:ListItem Value="0" Selected="True">&nbsp;0&nbsp;</asp:ListItem>
													<asp:ListItem Value="0.5">&nbsp;0.5&nbsp;</asp:ListItem>
													<asp:ListItem Value="1">&nbsp;1&nbsp;</asp:ListItem>
													<asp:ListItem Value="1.5">&nbsp;1.5&nbsp;</asp:ListItem>
													<asp:ListItem Value="2">&nbsp;2&nbsp;</asp:ListItem>
													<asp:ListItem Value="2.5">&nbsp;2.5&nbsp;</asp:ListItem>
													<asp:ListItem Value="3">&nbsp;3&nbsp;</asp:ListItem>
												</asp:radiobuttonlist></div>
                                            	<div class="col"></div>
                                            	
                                            
                                            
										</div>
                                         <br />
										<div class="row">
											<div class="col"  >B</div>
											<div class="col" style="margin-left:-70px"><asp:radiobuttonlist id="rblBThin" runat="server" CssClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow">
													<asp:ListItem Value="0" Selected="True">&nbsp;0&nbsp;</asp:ListItem>
													<asp:ListItem Value="0.5">&nbsp;0.5&nbsp;</asp:ListItem>
													<asp:ListItem Value="1">&nbsp;1&nbsp;</asp:ListItem>
													<asp:ListItem Value="1.5">&nbsp;1.5&nbsp;</asp:ListItem>
													<asp:ListItem Value="2">&nbsp;2&nbsp;</asp:ListItem>
													<asp:ListItem Value="2.5">&nbsp;2.5&nbsp;</asp:ListItem>
													<asp:ListItem Value="3">&nbsp;3&nbsp;</asp:ListItem>
												</asp:radiobuttonlist></div>
											
											<div class="col"><asp:radiobuttonlist id="rblBThick" runat="server" CssClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow">
													<asp:ListItem Value="0" Selected="True">&nbsp;0&nbsp;</asp:ListItem>
													<asp:ListItem Value="0.5">&nbsp;0.5&nbsp;</asp:ListItem>
													<asp:ListItem Value="1">&nbsp;1&nbsp;</asp:ListItem>
													<asp:ListItem Value="1.5">&nbsp;1.5&nbsp;</asp:ListItem>
													<asp:ListItem Value="2">&nbsp;2&nbsp;</asp:ListItem>
													<asp:ListItem Value="2.5">&nbsp;2.5&nbsp;</asp:ListItem>
													<asp:ListItem Value="3">&nbsp;3&nbsp;</asp:ListItem>
												</asp:radiobuttonlist></div>
                                            <div class="col"></div>
										</div>
                                         <br />
										<div class="row">
											<div class="col" >C</div>
											<div class="col" style="margin-left:-70px"><asp:radiobuttonlist id="rblCThin" runat="server" CssClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow">
													<asp:ListItem Value="0" Selected="True">&nbsp;0&nbsp;</asp:ListItem>
													<asp:ListItem Value="0.5">&nbsp;0.5&nbsp;</asp:ListItem>
													<asp:ListItem Value="1">&nbsp;1&nbsp;</asp:ListItem>
													<asp:ListItem Value="1.5">&nbsp;1.5&nbsp;</asp:ListItem>
													<asp:ListItem Value="2">&nbsp;2&nbsp;</asp:ListItem>
													<asp:ListItem Value="2.5">&nbsp;2.5&nbsp;</asp:ListItem>
													<asp:ListItem Value="3">&nbsp;3&nbsp;</asp:ListItem>
												</asp:radiobuttonlist></div>
										
											<div class="col"><asp:radiobuttonlist id="rblCThick" runat="server" CssClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow">
													<asp:ListItem Value="0" Selected="True">0</asp:ListItem>
													<asp:ListItem Value="0.5">&nbsp;0.5&nbsp;</asp:ListItem>
													<asp:ListItem Value="1">&nbsp;1&nbsp;</asp:ListItem>
													<asp:ListItem Value="1.5">&nbsp;1.5&nbsp;</asp:ListItem>
													<asp:ListItem Value="2">&nbsp;2&nbsp;</asp:ListItem>
													<asp:ListItem Value="2.5">&nbsp;2.5&nbsp;</asp:ListItem>
													<asp:ListItem Value="3">&nbsp;3&nbsp;</asp:ListItem>
												</asp:radiobuttonlist></div>
                                            	<div class="col"></div>
										</div>
                                         <br />
										<div class="row">
											<div class="col" >D</div>
											<div class="col" style="margin-left:-70px"><asp:radiobuttonlist id="rblDThin" runat="server" CssClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow">
													<asp:ListItem Value="0" Selected="True">&nbsp;0&nbsp;</asp:ListItem>
													<asp:ListItem Value="0.5">&nbsp;0.5&nbsp;</asp:ListItem>
													<asp:ListItem Value="1">&nbsp;1&nbsp;</asp:ListItem>
													<asp:ListItem Value="1.5">&nbsp;1.5&nbsp;</asp:ListItem>
													<asp:ListItem Value="2">&nbsp;2&nbsp;</asp:ListItem>
													<asp:ListItem Value="2.5">&nbsp;2.5&nbsp;</asp:ListItem>
													<asp:ListItem Value="3">&nbsp;3&nbsp;</asp:ListItem>
												</asp:radiobuttonlist></div>
											
											<div class="col"><asp:radiobuttonlist id="rblDThick" runat="server" CssClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow">
													<asp:ListItem Value="0" Selected="True">&nbsp;0&nbsp;</asp:ListItem>
													<asp:ListItem Value="0.5">&nbsp;0.5&nbsp;</asp:ListItem>
													<asp:ListItem Value="1">&nbsp;1&nbsp;</asp:ListItem>
													<asp:ListItem Value="1.5">&nbsp;1.5&nbsp;</asp:ListItem>
													<asp:ListItem Value="2">&nbsp;2&nbsp;</asp:ListItem>
													<asp:ListItem Value="2.5">&nbsp;2.5&nbsp;</asp:ListItem>
													<asp:ListItem Value="3">&nbsp;3&nbsp;</asp:ListItem>
												</asp:radiobuttonlist></div>
                                            <div class="col"></div>
										</div>
                                         <br />
										<div class="row">
											<div class="col" noWrap  colSpan="1" rowSpan="1">Micro 
												Structure</div>
											<div class="col" style="margin-left:-70px"><asp:radiobuttonlist id="rblStructure" runat="server" CssClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow">
													<asp:ListItem Value="Uniform Fine Pearlitic" Selected="True">&nbsp;Uniform Fine Pearlitic&nbsp;</asp:ListItem>
													<asp:ListItem Value="Uniform Pearlitic">&nbsp;Uniform Pearlitic&nbsp;</asp:ListItem>
													<asp:ListItem Value="Anything">&nbsp;Anything&nbsp;</asp:ListItem>
												</asp:radiobuttonlist></div>
                                           
                                           
										</div>
                                         <br />
										<div class="row">
											<div class="col"noWrap >Grain Size No.</div>
											<div class="col" colSpan="3" style="margin-left:-70px"><asp:checkboxlist id="chkGrain" runat="server"  RepeatDirection="Horizontal" RepeatLayout="Flow">
													<asp:ListItem Value="4">&nbsp;4&nbsp;</asp:ListItem>
													<asp:ListItem Value="5">&nbsp;5&nbsp;</asp:ListItem>
													<asp:ListItem Value="6">&nbsp;6&nbsp;</asp:ListItem>
													<asp:ListItem Value="7">&nbsp;7&nbsp;</asp:ListItem>
													<asp:ListItem Value="8">&nbsp;8&nbsp;</asp:ListItem>
												</asp:checkboxlist></div>
										</div>
                                         <br />
										<div class="row">
											<div class="col">Macro</div>
											<div class="col"colSpan="3" style="margin-left:-70px"><asp:radiobuttonlist id="rblMacro" runat="server" CssClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow">
													<asp:ListItem Value="Satisfactory" Selected="True">&nbsp;Satisfactory&nbsp;</asp:ListItem>
													<asp:ListItem Value="Not Satisfactory">&nbsp;Not Satisfactory&nbsp;</asp:ListItem>
												</asp:radiobuttonlist></div>
										</div>
                                        <br />
										<div class="row">
											<div class="col">Test Results</div>
											<div class="col"colSpan="3" style="margin-left:-70px"><asp:radiobuttonlist id="rblResult" runat="server" CssClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow">
													<asp:ListItem Value="P" Selected="True">&nbsp;Pass&nbsp;</asp:ListItem>
													<asp:ListItem Value="R">&nbsp;Reject&nbsp;</asp:ListItem>
												</asp:radiobuttonlist></div>
										</div>
                                         <br />
										<div class="row">
											<div class="col">Remarks</div>
											<div class="col"colSpan="3" style="margin-left:-70px"><asp:textbox id="txtRemarks" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:textbox></div>
										</div>
                                         <br />
									</TABLE>
                                     <div class="row">
											<div class="col" align="center">
									<asp:button id="btnSave" runat="server" Text="Save" Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark"></asp:button></asp:button></div>
							            </div>
						
					
			</div></div>
		</form>
            </div>
           <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;position:relative;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>

	</body>
</HTML>
