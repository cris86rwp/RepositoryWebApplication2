<%@ Page Language="vb" AutoEventWireup="false" Codebehind="NonRWFWheels.aspx.vb" Inherits="WebApplication2.NonRWFWheels" Culture="en-GB" uiCulture="en-GB" smartNavigation="True" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD  runat="server">
		<title>NonRWFWheels</title>
		<LINK id="nonrwfwheel" href="/wap.css" rel="StyleSheet">
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
      <%-- <link rel="stylesheet" href="../../../StyleSheet1.css" />--%>
	</HEAD>


	<body >
            <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
  <a class="navbar-brand p-0" href="#"><img src="../../../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
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
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home " style="font-size:30px;"></i>
        </a></li>
       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out" style="font-size:30px;"></i>
        </a></li>
        
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
          <img src="../../../NewFolder1/CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="45"/>
        </a>
      </li>
     </ul>
      
  </div>
</nav>
<!--/.Navbar -->

        <div class="container">
		<form id="Form1" method="post" runat="server">
             <div class="row">
    
                 <%-- <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
      </div>
            <div class="row"><div class="table-responsive">
			<TABLE id="Table1" class="table">
				<TR>
					<TD noWrap align="middle" width="100%" colSpan="4" rowSpan="1"><FONT  size="5">Non-RWF 
							Wheels</FONT><hr class="prettyline" /></TD>
				</TR>
				<TR>
					<TD noWrap align="left" width="100%" colSpan="5">
						<asp:textbox id="TextBox1" tabIndex="-1" runat="server" ReadOnly="True"  CssClass="form-control"></asp:textbox>Editable 
						fields&nbsp;
						<asp:textbox id="Textbox2" tabIndex="-1" runat="server" ReadOnly="True"  CssClass="form-control"></asp:textbox>&nbsp;Once 
						assigned cannot be changed.
						<asp:textbox id="Textbox3" tabIndex="-1" runat="server" ReadOnly="True"  CssClass="form-control"></asp:textbox>&nbsp;Once 
						Deleted cannot be retrieved.</TD>
				</TR>
				<TR>
					<TD align="left" width="100%" colSpan="5">
						<P>
							<asp:label id="lblMessage" tabIndex="-1" runat="server"></asp:label>
							<asp:label id="lblPressStatus" tabIndex="-1" runat="server" ></asp:label>
							<asp:requiredfieldvalidator id="rfvwheel" tabIndex="-1" runat="server" ErrorMessage="Enter Wheel Number" ControlToValidate="txtWheel"></asp:requiredfieldvalidator>
							<asp:requiredfieldvalidator id="RFVtreadDia" tabIndex="-1" runat="server"  ErrorMessage="Enter Tread Dia" Display="Dynamic" ControlToValidate="txtTreadDia"></asp:requiredfieldvalidator>
							<asp:customvalidator id="cvDate" runat="server"  ErrorMessage="Enter Date" Display="Dynamic" ControlToValidate="txtDate"></asp:customvalidator></P>
					</TD>
				</TR>
				<TR>
					<TD >Date</TD>
					<TD><asp:textbox id="txtDate" tabIndex="-1" runat="server" CssClass="form-control" AutoPostBack="True" BackColor="#FFE0C0"></asp:textbox></TD>
					<TD >Final Insp</TD>
					<TD><asp:textbox id="txtFinalInsp" tabIndex="-1" runat="server" CssClass="form-control" Enabled="False"></asp:textbox></TD>
				</TR>
				<TR>
					<TD>Wheel Source
					</TD>
					<TD><asp:textbox id="txtSource" tabIndex="-1" runat="server" CssClass="form-control">DSP (ICF)</asp:textbox></TD>
					<TD>Product</TD>
					<TD><asp:dropdownlist id="ddlProducts" tabIndex="-1" runat="server" BackColor="#FFE0C0" CssClass="form-control ll"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>Forged/Cast</TD>
					<TD><asp:radiobuttonlist id="rdoCastType" tabIndex="-1" runat="server" CssClass="rbl" Enabled="False" RepeatDirection="Horizontal">
							<asp:ListItem Value="Forged" Selected="True">Forged</asp:ListItem>
							<asp:ListItem Value="Cast ">Cast </asp:ListItem>
						</asp:radiobuttonlist></TD>
					<TD>Bore Status</TD>
					<TD colSpan="3"><asp:textbox id="txtBoreStatus" tabIndex="-1" runat="server" CssClass="form-control" Enabled="False">OK</asp:textbox></TD>
				</TR>
				<TR>
					<TD>
						<P>RWF Number
							<asp:TextBox id="txtRWFNUmber" runat="server" BackColor="#E0E0E0" CssClass="form-control" AutoPostBack="True" tabIndex="1"></asp:TextBox></P>
					</TD>
					<TD  noWrap >
						<P><asp:textbox id="txtWheel" tabIndex="2" runat="server" CssClass="form-control" AutoPostBack="True" BackColor="#FFE0C0"></asp:textbox></P>
					</TD>
					<TD>Tread Dia</TD>
					<TD><asp:textbox id="txtTreadDia" tabIndex="3" runat="server" CssClass="form-control" BackColor="#FFE0C0"></asp:textbox></TD>
				</TR>
				<TR>
					<TD>Bore Diameter</TD>
					<TD><asp:textbox id="txtBoreDia" tabIndex="-1" runat="server" CssClass="form-control" Enabled="False">OK</asp:textbox></TD>
					<TD>Rim Thickness</TD>
					<TD><asp:textbox id="txtRimThickness" tabIndex="-1" runat="server" CssClass="form-control" Enabled="False">OK</asp:textbox></TD>
				</TR>
				<TR>
					<TD>Plate Thickness</TD>
					<TD><asp:textbox id="txtPlateThickness" tabIndex="-1" runat="server" CssClass="form-control" Enabled="False">OK</asp:textbox></TD>
					<TD>WheelStatus</TD>
					<TD><asp:checkbox id="chkStatus" tabIndex="-1" runat="server" AutoPostBack="True" Enabled="False" Checked="True" Text="Passed"></asp:checkbox></TD>
				</TR>
				<TR>
					<TD noWrap align="middle" colSpan="4" rowSpan="1"><asp:button id="btnsave" accessKey="S" tabIndex="4" runat="server" CssClass="button button2" Text="Save/Update"></asp:button></TD>
				</TR>
				<TR>
					<TD noWrap align="middle" colSpan="4">
						<asp:DataGrid id="dgWheels" CssClass="table" runat="server" Width="566px" BorderColor="White" BorderStyle="Ridge" CellSpacing="1" BorderWidth="2px" BackColor="White" CellPadding="3" GridLines="None" tabIndex="-1">
							<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#9471DE"></SelectedItemStyle>
							<ItemStyle ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
							<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
							<Columns>
								<asp:ButtonColumn Text="Delete" CommandName="Delete"></asp:ButtonColumn>
								<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="" CancelText="" EditText="Edit"></asp:EditCommandColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Right" ForeColor="Black" BackColor="#C6C3C6"></PagerStyle>
						</asp:DataGrid></TD>
				</TR>
			</TABLE>
		</div></div></form></div>
        <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
