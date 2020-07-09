<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ClosureTest.aspx.vb" Inherits="WebApplication2.ClosureTest" Culture="en-GB" uiCulture="en-GB" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>ClosureTest</title>
		<LINK href="/mss.css" rel="stylesheet">
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
			<asp:Panel id="Panel1"  runat="server">
				<TABLE id="Table2" class="table">
					<TR>
						<TD>Closure Test Details&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:label id="lblMode" runat="server" ForeColor="#FF8080" ></asp:label><hr class="prettyline" /></TD>
					</TR>
				</TABLE>
				<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label>
				<TABLE id="Table3" class="table">
					<TR>
						<TD>WheelNumber</TD>
						<TD>
							<asp:DropDownList id="cboWheel_Number" runat="server" AutoPostBack="True" CssClass="form-control ll"></asp:DropDownList></TD>
						<TD>
							<asp:textbox id="txtWheel_Number" runat="server" CssClass="form-control" AutoPostBack="True" Visible="False"></asp:textbox></TD>
						<TD>DateRecieved</TD>
						<TD>
							<asp:textbox id="txtDate_received" runat="server" CssClass="form-control"></asp:textbox></TD>
					</TR>
					<TR>
						<TD>ReportDate</TD>
						<TD colSpan="2">
							<asp:textbox id="txtDate" runat="server" CssClass="form-control"></asp:textbox></TD>
						<TD colSpan="2">WheelType:
							<asp:Label id="lblWheelType" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD>IntialGuageInMM</TD>
						<TD colSpan="2">
							<asp:textbox id="txtIntial_guage" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox></TD>
						<TD>FinalGuageInMM</TD>
						<TD>
							<asp:textbox id="txtFinal_guage" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox></TD>
					</TR>
					<TR>
						<TD>ClosureValue</TD>
						<TD colSpan="2">
							<asp:label id="lblClosure_value" runat="server" ></asp:label></TD>
						<TD>StatusRemarks</TD>
						<TD>
							<asp:textbox id="txtRemarks" runat="server" CssClass="form-control"></asp:textbox></TD>
					</TR>
				</TABLE>
				<TABLE id="Table1" class="table">
					<TR>
						<TD >Lab 
							Number :
							<asp:label id="lblLab_Number" runat="server" ForeColor="Blue" ></asp:label>&nbsp; 
							Test Type :&nbsp;
							<asp:label id="lblTestType" runat="server" ForeColor="Blue"></asp:label>&nbsp;&nbsp;</TD>
					</TR>
					<TR>
						<TD >Results 
							:&nbsp;
							<asp:radiobuttonlist id="rblResult" runat="server" CssClass="rbl" RepeatLayout="Flow" RepeatDirection="Horizontal">
								<asp:ListItem Value="P" Selected="True">Pass</asp:ListItem>
								<asp:ListItem Value="R">Reject</asp:ListItem>
								<asp:ListItem Value="N">Not Done</asp:ListItem>
								<asp:ListItem Value="S">Skip</asp:ListItem>
							</asp:radiobuttonlist></TD>
					</TR>
					<TR>
						<TD vAlign="center" align="middle" width="100%" colSpan="9">
							<asp:button id="btnSave" runat="server" CssClass="button button2" Text="Save" ></asp:button>&nbsp;
							<asp:button id="btnClear" runat="server" CssClass="button button2" Text="Clear"  CausesValidation="False"></asp:button>&nbsp;
							<asp:button id="btnExit" runat="server" CssClass="button button2" Text="Exit"  CausesValidation="False"></asp:button></TD>
					</TR>
				</TABLE>
			</asp:Panel>
                </div></div>
		</form>
            </div>
        <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
