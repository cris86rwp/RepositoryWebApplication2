<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ms_BreakDownDetails_New.aspx.vb" Inherits="WebApplication2.ms_BreakDownDetails_New" Culture="en-GB" uiCulture="en-GB" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>ms_BreakDownDetails_New</title>
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
         <%--<link rel="stylesheet" href="../../StyleSheet1.css" />--%>
	</HEAD>
	<body>
        <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
 <a class="navbar-brand p-0" href="#"><img src="../../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
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
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home " style="font-size:30px;"></i>
        </a></li>
       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out" style="font-size:30px;"></i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
          <img src="../../NewFolder1/CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="45"/>
        </a>
      </li>
     </ul>
      
  </div>
</nav>
<!--/.Navbar -->
           <div class="container">
		<form id="Form1" method="post" runat="server">
            <div class="row">
                <%--<h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
            </div>
           
            <div class="row table-responsive">
			<asp:panel id="Panel1" runat="server">
                <TABLE id="Table1" class="table">
					<TR>
						<TD align="middle" colSpan="6"><hr class="prettyline" /></TD>
                        </TR>
                                </TABLE>
				<TABLE id="Table2" class="table">
					<TR>
						<TD vAlign="top" align="middle" colSpan="3">Breakdown Details
							<asp:Label id="lblGrp" runat="server" Visible="False"></asp:Label></TD>
					</TR>
					<TR>
						<TD colSpan="3">
							<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label>&nbsp;</TD>
					</TR>
					<TR>
						<TD>From Date</TD>
						<TD>:</TD>
						<TD>
							<asp:textbox id="txtFromDate" runat="server" CssClass="form-control" BorderStyle="Groove"></asp:textbox>
							<asp:RequiredFieldValidator id="rfvld1" runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="txtFromDate"></asp:RequiredFieldValidator></TD>
					</TR>
					<TR>
						<TD>To Date</TD>
						<TD>:</TD>
						<TD>
							<asp:textbox id="txtToDate" runat="server" CssClass="form-control" BorderStyle="Groove"></asp:textbox>
							<asp:RequiredFieldValidator id="rfvld2" runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="txtToDate"></asp:RequiredFieldValidator></TD>
					</TR>
					<TR>
						<TD>BreakDown Type
						</TD>
						<TD>:</TD>
						<TD>
							<asp:DropDownList id="cboBD_Type" runat="server" CssClass="form-control ll"></asp:DropDownList></TD>
					</TR>
					<TR>
						<TD>Production&nbsp;&nbsp;Affected</TD>
						<TD>:</TD>
						<TD>
							<asp:RadioButtonList id="radProduction" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl">
								<asp:ListItem Value="1">Yes</asp:ListItem>
								<asp:ListItem Value="0">No</asp:ListItem>
								<asp:ListItem Value="2" Selected="True">Both</asp:ListItem>
							</asp:RadioButtonList></TD>
					</TR>
					<TR>
						<TD>MinimumLoss</TD>
						<TD>:</TD>
						<TD>
							<asp:textbox id="txtTime" runat="server" CssClass="form-control" BorderStyle="Groove">0</asp:textbox>(inMin 
							, eg : 10 , 70 )</TD>
					</TR>
					<TR>
						<TD>No. of Working Days</TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="txtWkDays" runat="server" CssClass="form-control">0</asp:TextBox></TD>
					</TR>
					<TR>
						<TD colSpan="3">
							<asp:RadioButtonList id="rdSelect" runat="server" CssClass="rbl" RepeatLayout="Flow" RepeatDirection="Horizontal" AutoPostBack="True">
								<asp:ListItem Value="0" Selected="True">Location</asp:ListItem>
								<asp:ListItem Value="1">Location &amp;  MachineCode</asp:ListItem>
							</asp:RadioButtonList></TD>
					</TR>
					<TR>
						<TD>Location
						</TD>
						<TD>:</TD>
						<TD>
							<asp:DropDownList id="ddlLocation" runat="server" CssClass="form-control ll"></asp:DropDownList></TD>
					</TR>
					<TR>
						<TD>
							<asp:Label id="lblMAchineCode" runat="server" Visible="False" Width="117px">Machine Code :</asp:Label>&nbsp;</TD>
						<TD>:</TD>
						<TD>
							<asp:DropDownList id="ddlMachineCode" runat="server" Visible="False" CssClass="form-control ll"></asp:DropDownList>&nbsp;</TD>
					</TR>
					<TR>
						<TD vAlign="top" align="middle" colSpan="3">
							<asp:button id="btnShowReport" runat="server" CssClass="button button2" Text="Report"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:Button id="btnElecCranes" runat="server" Text="Elec Cranes Report" CssClass="button button2"></asp:Button></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="middle" colSpan="3">
							<asp:Button id="btnGrid" runat="server" Text="BreakDown Data in Grid" CssClass="button button2"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;
						</TD>
					</TR>
					<TR>
						<TD vAlign="top" align="middle" colSpan="3">
							<asp:Button id="Button2" runat="server" Text="Elec Cranes Data in Grid" CssClass="button button2"></asp:Button></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="middle" colSpan="3">
							<asp:Button id="Button1" runat="server" Text="Export to Excel" CssClass="button button2"></asp:Button></TD>
					</TR>
				</TABLE>
				<asp:DataGrid id="DataGrid1" runat="server" BorderStyle="None" CellPadding="4" BackColor="White" BorderWidth="1px" BorderColor="#CC9966">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
			</asp:panel>

            </div>
               </form> 
        </div>
      
        <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
