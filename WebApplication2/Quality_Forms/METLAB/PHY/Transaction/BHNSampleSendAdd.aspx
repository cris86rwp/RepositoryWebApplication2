<%@ Page Language="vb" AutoEventWireup="false" Codebehind="BHNSampleSendAdd.aspx.vb" Inherits="WebApplication2.BHNSampleSendAdd" Culture="en-GB" uiCulture="en-GB" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>BHNSampleSendAdd</title>
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
    <%-- <link rel="stylesheet" href="../../../../StyleSheet1.css" />--%>
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
			<asp:panel id="Panel1"  runat="server" >
                
				
							<TABLE id="Table6" class="table">
								<TR>
									<TD noWrap><FONT size="5">Wheel&nbsp;Sample for Physical Tests</FONT><hr class="prettyline" /></TD>
								</TR>
								<TR>
									<TD noWrap>
										<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></TD>
								</TR>
								<TR>
									<TD noWrap>Inspector&nbsp; :
										<asp:Label id="lblInsp" runat="server"></asp:Label>
										<asp:CheckBox id="chkHelp" runat="server" ForeColor="Crimson" AutoPostBack="True" Text="Help"></asp:CheckBox>
										<asp:label id="lblLab" runat="server">Saved Lab Number : </asp:label>
										<asp:label id="lblLabNumber" runat="server" ForeColor="Red"></asp:label></TD>
								</TR></TABLE>
								
										<asp:Panel id="pnlHelp" runat="server" >
											<TABLE id="Table1" class="table">
												<TR>
													<TD>Test Type : <STRONG>Regular</STRONG></TD>
												</TR>
												<TR>
													<TD>1.Based on selected Wheel Type&nbsp;and TestType, Steel Class and pending 
														HeatRange is&nbsp;obtained.</TD>
												</TR>
												<TR>
													<TD>2.Based on selected HeatRange, XC wheels are listed in WheelNumber DDL.</TD>
												</TR>
												<TR>
													<TD>3.After wheel number is saved the Lab Number is obtained.</TD>
												</TR>
												<TR>
													<TD>Test Type : <STRONG>Experimental</STRONG></TD>
												</TR>
												<TR>
													<TD>1.Based on selected Wheel Type, Steel Class is obtained.</TD>
												</TR>
												<TR>
													<TD>1.Wheel Number and Heat Number are captured.</TD>
												</TR>
												<TR>
													<TD>3.Given wheel number is checked for validity.</TD>
												</TR>
												<TR>
													<TD>4.FromHeat and ToHeat are set.</TD>
												</TR>
												<TR>
													<TD>5.After wheel number is saved the Lab Number is obtained</TD>
												</TR>
												<TR>
													<TD>6.Force Range feature is used to short close the Heat Range.
													</TD>
												</TR>
											</TABLE>
										</asp:Panel></TD>
								
										<TABLE id="Table2" class="table">
											<TR>
												<TD  noWrap colSpan="1" rowSpan="1">SentDate</TD>
												<TD>:</TD>
												<TD>
													<asp:textbox id="txtDate" runat="server" CssClass="form-control" ReadOnly="True"></asp:textbox>
													<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtDate"></asp:requiredfieldvalidator>
													<asp:rangevalidator id="RangeValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtDate" MinimumValue="1/1/1900" MaximumValue="1/1/9999" Type="Date"></asp:rangevalidator></TD>
												<TD >ShiftCode</TD>
												<TD >:&nbsp;</TD>
												<TD >
													<asp:RadioButtonList id="rblShift" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rbl">
														<asp:ListItem Value="A" Selected="True">A</asp:ListItem>
														<asp:ListItem Value="B">B</asp:ListItem>
														<asp:ListItem Value="C">C</asp:ListItem>
													</asp:RadioButtonList></TD>
											</TR>
											<TR>
												<TD noWrap colSpan="1" rowSpan="1">WheelType</TD>
												<TD>:</TD>
												<TD>
													<asp:DropDownList id="ddlWheelType" runat="server" AutoPostBack="True" CssClass="form-control ll"></asp:DropDownList></TD>
												<TD colSpan="3">
													<asp:radiobuttonlist id="rblTesttype" runat="server" CssClass="rbl" AutoPostBack="True" RepeatDirection="Horizontal" RepeatLayout="Flow">
														<asp:ListItem Value="Regular" Selected="True">Regular</asp:ListItem>
														<asp:ListItem Value="Experimental">Experimental</asp:ListItem>
													</asp:radiobuttonlist></TD>
											</TR>
											<TR>
												<TD noWrap colSpan="1" rowSpan="1">WheelClass</TD>
												<TD >:</TD>
												<TD colSpan="4">
													<asp:RadioButtonList id="rblWhClass" runat="server" CssClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow" Enabled="False">
														<asp:ListItem Value="A">A</asp:ListItem>
														<asp:ListItem Value="B">B</asp:ListItem>
														<asp:ListItem Value="C">C</asp:ListItem>
														<asp:ListItem Value="Special">Special</asp:ListItem>
													</asp:RadioButtonList>&nbsp;&nbsp;
													<asp:CheckBox id="chkForce" runat="server" AutoPostBack="True" Text="Force Range"></asp:CheckBox></TD>
											</TR>
											<TR>
												<TD noWrap colSpan="1" rowSpan="1">FromHeat</TD>
												<TD >:</TD>
												<TD>
													<asp:textbox id="txtHeatFrom" runat="server" CssClass="form-control" ReadOnly="True"></asp:textbox>
													<asp:RequiredFieldValidator id="rfvfrheat" runat="server" ErrorMessage="*" ControlToValidate="txtHeatFrom" Display="Dynamic"></asp:RequiredFieldValidator></TD>
												<TD >ToHeat</TD>
												<TD>:</TD>
												<TD>
													<asp:textbox id="txtHeatTo" runat="server" CssClass="form-control" ReadOnly="True"></asp:textbox>
													<asp:RequiredFieldValidator id="rfvtoheat" runat="server" ErrorMessage="*" ControlToValidate="txtHeatTo" Display="Dynamic"></asp:RequiredFieldValidator></TD>
											</TR>
                                            </TABLE>
											
													<asp:Panel id="pnlExperimental" runat="server">
														<TABLE id="Table3" class="table">
															<TR>
																<TD>WheelNumber</TD>
																<TD>:</TD>
																<TD>
																	<asp:TextBox id="txtWheelNumber" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox></TD>
																<TD>HeatNumber</TD>
																<TD>:</TD>
																<TD>
																	<asp:TextBox id="txtHeatNumber" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox></TD>
															</TR>
														</TABLE>
													</asp:Panel>
													<asp:Panel id="pnlRegular" runat="server">
														<TABLE id="Table4" class="table">
															<TR>
																<TD>WheelNumber</TD>
																<TD>:</TD>
																<TD>
																	<asp:DropDownList id="ddlWheel" runat="server" CssClass="form-control ll" ></asp:DropDownList></TD>
															</TR>
														</TABLE>
													</asp:Panel></TD>
											<table class="table">
											<TR>
												<TD vAlign="top" noWrap align="middle" colSpan="6">ExpectedTestDate :
													<asp:TextBox id="txtExpectedTestDate" runat="server" CssClass="form-control"></asp:TextBox></TD>
											</TR>
											<TR>
												<TD vAlign="top" noWrap align="middle" colSpan="6">
													<asp:button id="btnSubmit" runat="server" CssClass="button button2" Text="Save" BorderStyle="Groove" Font-Size="Smaller" Font-Names="Arial"></asp:button>
													<asp:button id="btnCancel" runat="server" CssClass="button button2" Text="Clear" BorderStyle="Groove" Font-Size="Smaller" Font-Names="Arial"></asp:button>
													<asp:button id="btnExit" runat="server" CssClass="button button2" Text="Exit" BorderStyle="Groove" Font-Size="Smaller" Font-Names="Arial" CausesValidation="False"></asp:button></TD>
											</TR></table>
										
									
						
						
							<asp:datagrid id="grdReadings" runat="server" CssClass="table" BackColor="White" BorderStyle="None" CellPadding="4" BorderWidth="1px" BorderColor="#CC9966" AllowPaging="True">
								<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
								<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
								<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
								<Columns>
									<asp:ButtonColumn Text="Select" HeaderText="HeatRange" CommandName="Select"></asp:ButtonColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
							</asp:datagrid></TD>
				
			</asp:panel>
            
            </div></div>
        </form>
            </div>
        <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
