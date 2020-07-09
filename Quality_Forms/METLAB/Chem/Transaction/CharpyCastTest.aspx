<%@ Page Language="vb" AutoEventWireup="false" Codebehind="CharpyCastTest.aspx.vb" Inherits="WebApplication2.CharpyCastTest" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>CharpyCastTest</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">

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
			<asp:Panel id="Panel1" runat="server">
				<TABLE id="Table4" class="table">
					<TR>
						<TD><FONT size="5">Wheel Charpy Test Results&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								<asp:label id="lblMode" runat="server" Font-Size="Smaller" Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:label></FONT><hr class="prettyline" /></TD>
					</TR>
				</TABLE>
				<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label>
				<TABLE id="Table2" class="table">
					<TR>
						<TD >Wheel No.</TD>
						<TD >
							<asp:dropdownlist id="cboLab_number" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist>
							<asp:textbox id="txtAxleNumber" runat="server" CssClass="form-control" AutoPostBack="True" Visible="False"></asp:textbox></TD>
						<TD >TestDate</TD>
						<TD >
							<asp:textbox id="txtDate" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox>
							<asp:rangevalidator id="Rangevalidator8" runat="server" ControlToValidate="txtDate" MaximumValue="1/1/9999" MinimumValue="1/1/1990" Type="Date" ErrorMessage="*"></asp:rangevalidator>
							<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtDate" ErrorMessage="*"></asp:requiredfieldvalidator></TD>
					</TR>
					<TR>
						<TD >LabNumber</TD>
						<TD >
							<asp:label id="lblLabNumber" runat="server" ></asp:label>&nbsp;</TD>
						<TD >ProdDrgNo.</TD>
						<TD >
							<asp:label id="lblProdno" runat="server" ></asp:label>&nbsp;</TD>
					</TR>
					<TR>
						<TD>CastNo.</TD>
						<TD>
							<asp:label id="lblCast_number" runat="server" ></asp:label>&nbsp;</TD>
						<TD>SentDate</TD>
						<TD>
							<asp:label id="lblSend_Date" runat="server"></asp:label>&nbsp;</TD>
					</TR>
					<TR>
						<TD>ReceivedDate</TD>
						<TD>
							<asp:label id="lblRecived_date" runat="server" ></asp:label>&nbsp;</TD>
						<TD>SpecnGroup</TD>
						<TD>
							<asp:label id="lblGropu" runat="server" ></asp:label>&nbsp;</TD>
					</TR>
					<TR>
						<TD>Test Type</TD>
						<TD colSpan="3">
							<asp:radiobuttonlist id="radTesttype" runat="server" CssClass="rbl" RepeatLayout="Flow" Height="8px" RepeatDirection="Horizontal" Enabled="False">
								<asp:ListItem Value="Regular" Selected="True">Regular</asp:ListItem>
								<asp:ListItem Value="Experimental">Experimental</asp:ListItem>
							</asp:radiobuttonlist></TD>
					</TR>
				</TABLE>
				
							<TABLE id="Table6" class="table">
								<TR>
									<TD></TD>
									<TD>PhysicalProperties</TD>
									<TD></TD>
									<TD></TD>
								</TR>
								<TR>
									<TD>UTStrengtt(N/mm<SUP>2</SUP>)</TD>
									<TD>
										<asp:textbox id="txtUT_strength" runat="server" Enabled="False" CssClass="form-control">0</asp:textbox></TD>
									<TD>YieldStrengt(N/mm<SUP>2</SUP>)</TD>
									<TD>
										<asp:textbox id="txtYield_strength" runat="server" CssClass="form-control" Enabled="False">0</asp:textbox></TD>
								</TR>
								<TR>
									<TD>Elongation%</TD>
									<TD>
										<asp:textbox id="txtElongation" runat="server" CssClass="form-control" Enabled="False">0</asp:textbox></TD>
									<TD>ReductionInArea%</TD>
									<TD>
										<asp:textbox id="txtReduction" runat="server" CssClass="form-control" Enabled="False">0</asp:textbox></TD>
								</TR>
							</TABLE>
							<TABLE id="Table7" class="table">
								<TR>
									<TD>CharpyU-notchImpactTest(KUinJoules)</TD>
									<TD>
										<asp:textbox id="txtCharpy" runat="server" CssClass="form-control" >0</asp:textbox></TD>
								</TR>
							</TABLE>
							<TABLE id="Table8" class="table">
								<TR>
									<TD colSpan="3">ASTM Grain Size No.</TD>
									<TD>
										<asp:textbox id="txtASTM" runat="server" CssClass="form-control" Enabled="False">0</asp:textbox></TD>
								</TR>
								<TR>
									<TD>MacroVert</TD>
									<TD>
										<asp:textbox id="txtVert_macro" runat="server" CssClass="form-control" Enabled="False">Acceptable</asp:textbox></TD>
									<TD>MacroLong</TD>
									<TD>
										<asp:textbox id="txtLong_macro" runat="server" CssClass="form-control" Enabled="False">Acceptable</asp:textbox></TD>
								</TR>
							</TABLE>
                <TABLE id="Table3" class="table"></TABLE>
					
                            <TABLE id="Table5" class="table">
								<TR>
									<TD >Chemical Analysis
									</TD>
								</TR>
								<TR>
									<TD>Carbon</TD>
									<TD>
										<asp:textbox id="txtC" runat="server" CssClass="form-control" Enabled="False">0.0</asp:textbox>%</TD>
									<TD >
										<P>Manganese</P>
									</TD>
									<TD>
										<asp:textbox id="txtMn" runat="server" CssClass="form-control" Enabled="False">0.0</asp:textbox>%</TD>
								</TR>
								<TR>
									<TD >Silicon</TD>
									<TD >
										<asp:textbox id="txtSi" runat="server" CssClass="form-control" Enabled="False">0.0</asp:textbox>%</TD>
									<TD >Phosphorus</TD>
									<TD>
										<asp:textbox id="txtP" runat="server" CssClass="form-control" AutoPostBack="True" Enabled="False">0.0</asp:textbox>%</TD>
								</TR>
								<TR>
									<TD >
										<P>Sulphur</P>
									</TD>
									<TD >
										<asp:textbox id="txtS" runat="server" CssClass="form-control" AutoPostBack="True" Enabled="False">0.0</asp:textbox>%</TD>
									<TD >Chromium</TD>
									<TD>
										<asp:textbox id="txtCr" runat="server" CssClass="form-control" Enabled="False">0.0</asp:textbox>%</TD>
								</TR>
								<TR>
									<TD >Nickel</TD>
									<TD>
										<asp:textbox id="txtNi" runat="server" CssClass="form-control" Enabled="False">0.0</asp:textbox>%</TD>
									<TD >Copper</TD>
									<TD>
										<asp:textbox id="txtCu" runat="server" CssClass="form-control" Enabled="False">0.0</asp:textbox>%</TD>
								</TR>
								<TR>
									<TD >Molybdenum</TD>
									<TD >
										<asp:textbox id="txtMo" runat="server" CssClass="form-control" Enabled="False">0.0</asp:textbox>%</TD>
									<TD >Vanadium</TD>
									<TD>
										<asp:textbox id="txtV" runat="server" CssClass="form-control" Enabled="False">0.0</asp:textbox>%</TD>
								</TR>
								<TR>
									<TD >Phosphorus+Sulphur</TD>
									<TD >
										<asp:textbox id="txtP_S" runat="server" CssClass="form-control" Enabled="False">0.0</asp:textbox>%</TD>
									<TD >Remarks</TD>
									<TD>
										<asp:textbox id="txtRemarks" runat="server" Width="188px" Enabled="False"></asp:textbox></TD>
								</TR>
							</TABLE>
						
				
				<TABLE class="table">
					<TR>
						<TD>Test Result :
							<asp:radiobuttonlist id="radResult" runat="server" CssClass="rbl" RepeatLayout="Flow" RepeatDirection="Horizontal" Enabled="False">
								<asp:ListItem Value="P" Selected="True">Pass</asp:ListItem>
								<asp:ListItem Value="R">Reject</asp:ListItem>
							</asp:radiobuttonlist></TD>
					</TR>
					<TR>
						<TD align="middle" width="100%">
							<asp:button id="btnSave" runat="server" CssClass="button button2" Font-Size="Smaller" Font-Names="Arial" Height="24px" Text="Save" BorderStyle="Groove"></asp:button>
							<asp:button id="btnCancel" runat="server" CssClass="button button2" Font-Size="Smaller" Font-Names="Arial" Height="24px" Text="Clear" BorderStyle="Groove"></asp:button>
							<asp:button id="btnExit" runat="server" CssClass="button button2" Font-Size="Smaller" Font-Names="Arial" Height="24px" Text="Exit" BorderStyle="Groove" CausesValidation="False"></asp:button></TD>
					</TR>
				</TABLE>
			</asp:Panel>

                </div></div>
		</form>
            </div>
          <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
