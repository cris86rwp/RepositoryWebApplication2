<%@ Page Language="vb" AutoEventWireup="false" Codebehind="NewBreakDownAvailability.aspx.vb" Inherits="WebApplication2.NewBreakDownAvailability" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>NewBreakDownAvailability</title>
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
               <%-- <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
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
					<TD vAlign="top" align="left">
						<TR>
								<TD colSpan="3"><FONT size="5">Machine Availabilty</FONT></TD>
							</TR>
							<TR>
								<TD colSpan="3">Message :
									<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></TD>
							</TR>
							<TR>
								<TD colSpan="3">
                                    <asp:radiobuttonlist id="rblYear" runat="server" AutoPostBack="True" RepeatLayout="Flow" CssClass="rbl" RepeatDirection="Horizontal"></asp:radiobuttonlist></TD>
							</TR>
							<TR>
								<TD colSpan="3">
                                    <asp:radiobuttonlist id="rblMonth" runat="server" AutoPostBack="True" RepeatLayout="Flow" CssClass="rbl" RepeatDirection="Horizontal"></asp:radiobuttonlist></TD>
							</TR>
							<TR>
								<TD vAlign="top" align="middle" colSpan="3">Production&nbsp;
									<asp:radiobuttonlist id="rblProdAffected" runat="server" AutoPostBack="True" RepeatLayout="Flow" CssClass="rbl" RepeatDirection="Horizontal">
										<asp:ListItem Value="1" Selected="True">Affected</asp:ListItem>
										<asp:ListItem Value="0">Not Affected</asp:ListItem>
									</asp:radiobuttonlist></TD>
							</TR>
							<TR>
								<TD colSpan="3">Availability Less Than&nbsp;
									<asp:textbox id="txtAvailability" runat="server" AutoPostBack="True" CssClass="form-control"></asp:textbox>&nbsp; 
									%
									<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" Display="Dynamic" ControlToValidate="txtAvailability" ErrorMessage="Required"></asp:requiredfieldvalidator>
                                    <asp:rangevalidator id="RangeValidator1" runat="server" Display="Dynamic" ControlToValidate="txtAvailability" ErrorMessage="InValid" Type="Integer" MinimumValue="0" MaximumValue="100"></asp:rangevalidator></TD>
							</TR>
							<TR>
								<TD colSpan="3">
									<TR>
											<TD>
												<asp:datagrid id="dgGroups" runat="server" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="3" GridLines="Horizontal" CssClass="table">
													<SelectedItemStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#738A9C"></SelectedItemStyle>
													<AlternatingItemStyle BackColor="#F7F7F7"></AlternatingItemStyle>
													<ItemStyle ForeColor="#4A3C8C" BackColor="#E7E7FF"></ItemStyle>
													<HeaderStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#4A3C8C"></HeaderStyle>
													<FooterStyle ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
													<Columns>
														<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
													</Columns>
													<PagerStyle HorizontalAlign="Right" ForeColor="#4A3C8C" BackColor="#E7E7FF" Mode="NumericPages"></PagerStyle>
												</asp:datagrid></TD>
											<TD>
												<asp:Button id="btnPrint" runat="server" Text="Show  Report" Visible="False" CssClass="button button2"></asp:Button></TD>
										</TR>
								</TD>
							</TR>
					</TD>
					<TD vAlign="top" align="left"><asp:datagrid id="dgMachines" runat="server" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4">
							<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
							<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
							<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
							<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
		</asp:panel>

            </div>
               </form> 
        </div>
      
        <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>

