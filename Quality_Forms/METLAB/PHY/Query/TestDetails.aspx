<%@ Page Language="vb" AutoEventWireup="false" Codebehind="TestDetails.aspx.vb" Inherits="WebApplication2.TestDetails" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>TestDetails</title>
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
			<asp:Panel id="Panel1"  runat="server" >
				<asp:RadioButtonList id="rblType" runat="server" CssClass="rbl" AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal">
					<asp:ListItem Value="1" Selected="True">Wheel Test Samples</asp:ListItem>
					<asp:ListItem Value="2">Cast Test Samples</asp:ListItem>
					<asp:ListItem Value="3">DrawingWise Axle Cast Test Details </asp:ListItem>
				</asp:RadioButtonList>
				<TABLE id="Table1" class="table">
					<TR>
						<TD>
							<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></TD>
					</TR>
				</TABLE>
				<asp:Panel id="PanelWheel" runat="server" >
					<TABLE id="Table2" class="table">
						<TR>
							<TD>
								<asp:radiobuttonlist id="rblTesttype" runat="server" CssClass="rbl" AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal">
									<asp:ListItem Value="Regular" Selected="True">Regular</asp:ListItem>
									<asp:ListItem Value="Experimental">Experimental</asp:ListItem>
								</asp:radiobuttonlist></TD>
						</TR>
						<TR>
							<TD>Wheel Type :
								<asp:DropDownList id="ddlWheelType" runat="server" AutoPostBack="True" CssClass="form-control ll"></asp:DropDownList></TD>
						</TR>
						<TR>
							<TD>
								<asp:RadioButtonList id="rblQry" runat="server" AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl">
									<asp:ListItem Value="All">All</asp:ListItem>
									<asp:ListItem Value="Top !0" Selected="True">Top !0</asp:ListItem>
								</asp:RadioButtonList></TD>
						</TR>
					</TABLE>
				</asp:Panel>
				<asp:panel id="pnlResults" runat="server" >&nbsp; 
<TABLE id="Table5" class="table">
						<TR>
							<TD>
								<asp:RadioButtonList id="rblNo" runat="server" AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl">
									<asp:ListItem Value="Axle" Selected="True">Axle</asp:ListItem>
									<asp:ListItem Value="Cast">Cast</asp:ListItem>
									<asp:ListItem Value="Lab">Lab</asp:ListItem>
								</asp:RadioButtonList>Number</TD>
							<TD>
								<asp:TextBox id="txtNumber" runat="server" AutoPostBack="True" CssClass="form-control"></asp:TextBox></TD>
						</TR>
					</TABLE>
<TABLE id="Table4" class="table">
						<TR>
							<TD  vAlign="center" align="left"  colSpan="9">Test 
								Date:
								<asp:label id="lblTest_date" runat="server"></asp:label>&nbsp;,&nbsp;Cast 
								Number:
								<asp:label id="lblCast_number" runat="server"></asp:label>&nbsp;,&nbsp;&nbsp;CastGroup:
								<asp:label id="lblCastGroup" runat="server"></asp:label>&nbsp;,&nbsp; Result :
								<asp:label id="lblResults" runat="server"></asp:label></TD>
						</TR>
						<TR>
							<TD  vAlign="center" align="left" colSpan="9">Operator:
								<asp:Label id="lblOperator" runat="server"></asp:Label>&nbsp;, Lab Number:
								<asp:Label id="lblLab" runat="server"></asp:Label>&nbsp;, Spec:
								<asp:Label id="lblSpec" runat="server"></asp:Label>&nbsp;,&nbsp;SpecGroup:
								<asp:label id="lblSpec_group" runat="server"></asp:label>,&nbsp;Drg :&nbsp;
								<asp:label id="lblDrg" runat="server"></asp:label></TD>
						</TR>
						<TR>
							<TD  align="left" width="367" colSpan="4"><FONT color="#3300cc">Physical 
									Properties</FONT><hr class="prettyline" /></TD>
							<TD >&nbsp;</TD>
							<TD align="middle"  colSpan="4"><FONT color="#3300cc">Chemical&nbsp;Properties</FONT></TD>
						</TR>
						<TR>
							<TD >UT Strength</TD>
							<TD >:</TD>
							<TD >
								<asp:label id="lblUTstrength" runat="server"></asp:label>&nbsp;</TD>
							<TD>NM/mm2
							</TD>
							<TD >&nbsp;</TD>
							<TD >&nbsp;</TD>
							<TD>Carbon</TD>
							<TD >:</TD>
							<TD>
								<asp:label id="lblCarbon" runat="server"></asp:label>&nbsp;</TD>
						</TR>
						<TR>
							<TD>Yield Strength</TD>
							<TD>:</TD>
							<TD>
								<asp:label id="lblYeild" runat="server"></asp:label>&nbsp;</TD>
							<TD >NM/mm2</TD>
							<TD >&nbsp;</TD>
							<TD>&nbsp;</TD>
							<TD>Manganese</TD>
							<TD >:</TD>
							<TD>
								<asp:label id="lblMang" runat="server"></asp:label>&nbsp;</TD>
						</TR>
						<TR>
							<TD >Elongation</TD>
							<TD>:</TD>
							<TD >
								<asp:label id="lblElongation" runat="server"></asp:label>&nbsp;</TD>
							<TD >&nbsp;</TD>
							<TD>&nbsp;</TD>
							<TD >&nbsp;</TD>
							<TD >Silicon</TD>
							<TD>:</TD>
							<TD>
								<asp:label id="lblSilicon" runat="server"></asp:label>&nbsp;</TD>
						</TR>
						<TR>
							<TD>Reduction Area</TD>
							<TD >:</TD>
							<TD>
								<asp:label id="lblReduArea" runat="server"></asp:label>&nbsp;</TD>
							<TD >&nbsp;</TD>
							<TD >&nbsp;</TD>
							<TD >&nbsp;</TD>
							<TD>Phosphorous</TD>
							<TD >:</TD>
							<TD>
								<asp:label id="lblPhos" runat="server"></asp:label>&nbsp;</TD>
						</TR>
						<TR>
							<TD >Charpy U Notch</TD>
							<TD>:</TD>
							<TD >
								<asp:label id="lblCharpyU" runat="server"></asp:label>&nbsp;</TD>
							<TD>Joules</TD>
							<TD>&nbsp;</TD>
							<TD >&nbsp;</TD>
							<TD>Sulphur</TD>
							<TD >:</TD>
							<TD>
								<asp:label id="lblSulphur" runat="server"></asp:label>&nbsp;</TD>
						</TR>
						<TR>
							<TD>Impact Test</TD>
							<TD>&nbsp;</TD>
							<TD >&nbsp;</TD>
							<TD >&nbsp;</TD>
							<TD >&nbsp;</TD>
							<TD >&nbsp;
							</TD>
							<TD >Chromium</TD>
							<TD >:</TD>
							<TD>
								<asp:label id="lblChromium" runat="server"></asp:label>&nbsp;</TD>
						</TR>
						<TR>
							<TD >ASTMGrainSize#</TD>
							<TD >:</TD>
							<TD>
								<asp:label id="lblASTM_size" runat="server"></asp:label>&nbsp;</TD>
							<TD> &nbsp;</TD>
							<TD>&nbsp;</TD>
							<TD >&nbsp;</TD>
							<TD >Nickel</TD>
							<TD >:</TD>
							<TD>
								<asp:label id="lblNickel" runat="server"></asp:label>&nbsp;</TD>
						</TR>
						<TR>
							<TD >Macro Vertical</TD>
							<TD >:</TD>
							<TD >
								<asp:label id="lblMacroV" runat="server"></asp:label>&nbsp;</TD>
							<TD>&nbsp;</TD>
							<TD>&nbsp;</TD>
							<TD>&nbsp;</TD>
							<TD >copper</TD>
							<TD >:</TD>
							<TD>
								<asp:label id="lblCopper" runat="server"></asp:label>&nbsp;</TD>
						</TR>
						<TR>
							<TD>Macro Long</TD>
							<TD>:</TD>
							<TD ><asp:label id="lblMacroL" runat="server"></asp:label>&nbsp;</TD>
							<TD >&nbsp;</TD>
							<TD>&nbsp;</TD>
							<TD >&nbsp;</TD>
							<TD >Molybdenum</TD>
							<TD >:</TD>
							<TD>
								<asp:label id="lblMolybd" runat="server"></asp:label>&nbsp;</TD>
						</TR>
						<TR>
							<TD >&nbsp;</TD>
							<TD>&nbsp;</TD>
							<TD>&nbsp;&nbsp;</TD>
							<TD>&nbsp;</TD>
							<TD>&nbsp;</TD>
							<TD>&nbsp;</TD>
							<TD>Vanadium</TD>
							<TD >:</TD>
							<TD>
								<asp:label id="lblVanadium" runat="server"></asp:label>&nbsp;</TD>
						</TR>
						<TR>
							<TD >&nbsp;</TD>
							<TD>&nbsp;</TD>
							<TD >&nbsp;</TD>
							<TD >&nbsp;&nbsp;</TD>
							<TD >&nbsp;</TD>
							<TD >&nbsp;</TD>
							<TD >Phos+Sulphur</TD>
							<TD >:</TD>
							<TD>
								<asp:Label id="lblPhos_Sul" runat="server"></asp:Label>&nbsp;</TD>
						</TR>
					</TABLE></asp:panel>
				<asp:Panel id="PanelDrawing" runat="server" >
					<TABLE id="Table3" class="table">
						<TR>
							<TD>DrawingNumber</TD>
							<TD >:</TD>
							<TD>
								<asp:DropDownList id="ddlDrg" runat="server" AutoPostBack="True" CssClass="form-control ll"></asp:DropDownList></TD>
						</TR>
						<TR>
							<TD>TestedFromDate</TD>
							<TD>:</TD>
							<TD>
								<asp:TextBox id="txtFromDate" runat="server" CssClass="form-control"></asp:TextBox></TD>
						</TR>
						<TR>
							<TD>ToDate</TD>
							<TD >:</TD>
							<TD>
								<asp:TextBox id="txtToDate" runat="server" CssClass="form-control"></asp:TextBox></TD>
						</TR>
						<TR>
							<TD noWrap align="middle" colSpan="3">
								<asp:Button id="Button1" runat="server" CssClass="button button2" Text="Show Details"></asp:Button></TD>
						</TR> 
					</TABLE>
				</asp:Panel>
				<asp:DataGrid id="DataGrid1" CssClass="table" runat="server" Width="301px" BackColor="White" CellPadding="4" BorderWidth="1px" BorderColor="#CC9966" BorderStyle="None">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
			</asp:Panel>
                </div></div>
		</form></div>
         <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
