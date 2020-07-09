<%@ Page Language="vb" AutoEventWireup="false" Codebehind="CastTest.aspx.vb" Inherits="WebApplication2.CastTest" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>CastTest</title>
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
    
		<LINK id="Link1" href="/wap.css" rel="stylesheet">
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
			<asp:Panel id="Panel1"  runat="server">
				<TABLE id="Table4" class="table">
					<TR>
						<TD align="middle">Wheel Cast Test Results&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:label id="lblMode" runat="server" Font-Size="Smaller" Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:label><hr class="prettyline" /></TD>
					</TR>
				</TABLE>
				<asp:label id="lblMessage" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:label>
				<TABLE id="Table2" class="table">
					<TR>
						<TD >Wheel No.</TD>
						<TD>
							<asp:DropDownList id="cboLab_number" runat="server" AutoPostBack="True" CssClass="form-control ll"></asp:DropDownList>
							<asp:textbox id="txtAxleNumber" runat="server" Width="79px" AutoPostBack="True" Visible="False" CssClass="form-control"></asp:textbox></TD>
						<TD>Test Date</TD>
						<TD>
							<asp:textbox id="txtDate" runat="server" Width="80px" AutoPostBack="True" CssClass="form-control"></asp:textbox>
							<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Required" ControlToValidate="txtDate"></asp:requiredfieldvalidator></TD>
					</TR>
					<TR>
						<TD >LabNumber</TD>
						<TD >
							<asp:label id="lblLabNumber" runat="server"></asp:label></TD>
						<TD >Prod.DrgNo.</TD>
						<TD >
							<asp:label id="lblProdno" runat="server"></asp:label>
							<asp:rangevalidator id="Rangevalidator8" runat="server" ErrorMessage="Incorrect Date" ControlToValidate="txtDate" Type="Date" MinimumValue="1/1/1990" MaximumValue="1/1/9999"></asp:rangevalidator></TD>
					</TR>
					<TR>
						<TD>CastNo.</TD>
						<TD>
							<asp:label id="lblCast_number" runat="server"></asp:label></TD>
						<TD>SentDate</TD>
						<TD>
							<asp:label id="lblSend_Date" runat="server"></asp:label></TD>
					</TR>
					<TR>
						<TD>SpecnGroup</TD>
						<TD colSpan="3">
							<asp:label id="lblGropu" runat="server"></asp:label></TD>
					</TR>
					<TR>
						<TD>TestType</TD>
						<TD colSpan="3">
							<asp:radiobuttonlist id="radTesttype" runat="server"  RepeatDirection="Horizontal" CssClass="rbl" RepeatLayout="Flow">
								<asp:ListItem Value="Regular" Selected="True">Regular</asp:ListItem>
								<asp:ListItem Value="Experimental">Experimental</asp:ListItem>
							</asp:radiobuttonlist></TD>
					</TR>
				</TABLE>
				<TABLE id="Table6" class="table"></TABLE>
					
							<TABLE id="Table7" class="table">
								<TR>
									<TD align="middle" colSpan="4">Physical Properties</TD>
								</TR>
								<TR>
									<TD>UT Strength(N/mm<SUP>2</SUP>)</TD>
									<TD>
										<asp:textbox id="txtUT_strength" runat="server" CssClass="form-control">0</asp:textbox></TD>
									<TD>Yield&nbsp;Strength(N/mm<SUP>2</SUP>)</TD>
									<TD>
										<asp:textbox id="txtYield_strength" runat="server" CssClass="form-control">0</asp:textbox></TD>
								</TR>
								<TR>
									<TD>Elongation%</TD>
									<TD>
										<asp:textbox id="txtElongation" runat="server" CssClass="form-control">0</asp:textbox></TD>
									<TD>Reduction in&nbsp;Area%</TD>
									<TD>
										<asp:textbox id="txtReduction" runat="server" CssClass="form-control">0</asp:textbox></TD>
								</TR>
							</TABLE>
							<TABLE id="Table8" class="table">
								<TR>
									<TD>CharpyUnotchImpactTest(KUinJoules)</TD>
									<TD>
										<asp:textbox id="txtCharpy" runat="server" CssClass="form-control">0</asp:textbox></TD>
								</TR>
							</TABLE>
							<TABLE id="Table3" class="table">
								<TR>
									<TD  colSpan="2">ASTM Grain Size No.</TD>
									<TD >
										<asp:textbox id="txtASTM" runat="server" CssClass="form-control">0</asp:textbox></TD>
									<TD></TD>
								</TR>
								<TR>
									<TD >Macro Vert.</TD>
									<TD >
										<asp:textbox id="txtVert_macro" runat="server" CssClass="form-control">Acceptable</asp:textbox></TD>
									<TD>Macro Long.</TD>
									<TD>
										<asp:textbox id="txtLong_macro" runat="server" CssClass="form-control">Acceptable</asp:textbox></TD>
								</TR>
							</TABLE>
						
							<TABLE id="Table5" class="table">
								<TR>
									<TD  align="middle" colSpan="4">Chemical Analysis</TD>
								</TR>
								<TR>
									<TD >Carbon</TD>
									<TD >
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
									<TD >
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
									<TD>
										<asp:textbox id="txtP_S" runat="server" CssClass="form-control" Enabled="False">0.0</asp:textbox>%</TD>
									<TD >Remarks</TD>
									<TD>
										<asp:textbox id="txtRemarks" runat="server" CssClass="form-control"></asp:textbox></TD>
								</TR>
							</TABLE>
						
				
				<TABLE id="Table1" class="table">
					<TR>
						<TD>Test Result :
							<asp:radiobuttonlist id="radResult" runat="server" CssClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow">
								<asp:ListItem Value="P" Selected="True">Pass</asp:ListItem>
								<asp:ListItem Value="R">Reject</asp:ListItem>
							</asp:radiobuttonlist></TD>
					</TR>
					<TR>
						<TD align="middle" width="100%">
							<asp:button id="btnSave" runat="server" CssClass="button button2" Font-Size="Smaller" Font-Names="Arial" Height="24px" BorderStyle="Groove" Text="Save"></asp:button>
							<asp:button id="btnCancel" runat="server" CssClass="button button2" Font-Size="Smaller" Font-Names="Arial" Height="24px" BorderStyle="Groove" Text="Clear"></asp:button>
							<asp:button id="btnExit" runat="server" CssClass="button button2" Font-Size="Smaller" Font-Names="Arial" Height="24px" BorderStyle="Groove" Text="Exit" CausesValidation="False"></asp:button></TD>
					</TR>
				</TABLE>
			</asp:Panel>

                </div></div>
		</form>

            </div>
         <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
