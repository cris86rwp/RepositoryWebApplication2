<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WheelInspectionDelete.aspx.vb" Inherits="WebApplication2.WheelInspectionDelete" Culture="en-GB" uiCulture="en-GB" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>WheelInspectionDelete</title>
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
       <%--<link rel="stylesheet" href="../../../StyleSheet1.css" />--%>
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
    
                  <%--<h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
      </div>
            <div class="row"><div class="table-responsive">
			<TABLE id="Table3" class="table"></TABLE>
				
						<TABLE id="Table1" class="table">
							<TR>
								<TD  align="middle" colSpan="4"><STRONG><FONT size="4">Wheel Final 
											Inspection </FONT></STRONG><hr class="prettyline" />
								</TD>
							</TR>
							<TR>
								<TD  align="right" colSpan="4"><FONT size="4">Mode: <STRONG>Delete</STRONG></FONT></TD>
							</TR>
							<TR>
								<TD >Help</TD>
								<TD  colSpan="3">
									<P>Deleted wheels are shown for the current date in desc order of entry.</P>
									<P><STRONG>YOU CANNOT DELETE WHEELS OF ANOTHER SHIFT</STRONG></P>
								</TD>
							</TR>
							<TR>
								<TD >
									EmpCode</TD>
								<TD  colSpan="3">
									<asp:Label id="lblEmpCode" runat="server"></asp:Label></TD>
							</TR>
							<TR>
								<TD  colSpan="4">
									<asp:CheckBox id="chkGShiftEntry" runat="server" ToolTip="Check this if G Shift Wheel to be deleted." Text="Entered In G Shift" Font-Bold="True"></asp:CheckBox></TD>
							</TR>
							<TR>
								<TD>Message</TD>
								<TD colSpan="3">
									<asp:label id="lblMessage" runat="server"  Font-Bold="True" ForeColor="Red" Font-Size="Medium"></asp:label></TD>
							</TR>
							<TR>
								<TD>
									WheelNumber</TD>
								<TD>
									<asp:textbox id="txtWheelNumber" runat="server" AutoPostBack="True" CssClass="form-control"></asp:textbox></TD>
								<TD>
									HeatNumber</TD>
								<TD>
									<asp:textbox id="txtHeatNumber" runat="server" AutoPostBack="True" CssClass="form-control"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>
									WheelStatus</TD>
								<TD>
									<asp:label id="lblWheelStatus" runat="server" CssClass="form-control"></asp:label></TD>
								<TD>
									BoreStatus</TD>
								<TD>
									<asp:label id="lblBoreStatus" runat="server" CssClass="form-control"></asp:label></TD>
							</TR>
							<TR>
								<TD>
									TreadDia</TD>
								<TD>
									<asp:label id="lblTreadDia" runat="server" CssClass="form-control"></asp:label></TD>
								<TD>
									PlateThickness</TD>
								<TD>
									<asp:label id="lblPlateThickness" runat="server" CssClass="form-control"></asp:label></TD>
							</TR>
							<TR>
								<TD>Remarks</TD>
								<TD colSpan="3">
									<asp:label id="lblRemarks" runat="server" CssClass="form-control"></asp:label></TD>
							</TR>
							<TR>
								<TD align="middle" colSpan="4">
									<asp:button id="btnDelete" runat="server" CssClass="button button2" Text="Delete"></asp:button>
									<asp:button id="btnClear" runat="server" CssClass="button button2" Text="Clear"></asp:button></TD>
							</TR>
							<TR>
								<TD align="middle" colSpan="4"><STRONG>Deleted Wheels in this Shift</STRONG></TD>
							</TR>
							<TR>
								<TD align="left" colSpan="4">
									<asp:DataGrid id="dgDeletedWheels" runat="server" CellSpacing="2" CellPadding="3" BorderWidth="1px" BorderStyle="None" BorderColor="#DEBA84" BackColor="#DEBA84">
										<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#738A9C"></SelectedItemStyle>
										<ItemStyle ForeColor="#8C4510" BackColor="#FFF7E7"></ItemStyle>
										<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#A55129"></HeaderStyle>
										<FooterStyle ForeColor="#8C4510" BackColor="#F7DFB5"></FooterStyle>
										<PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages"></PagerStyle>
									</asp:DataGrid></TD>
							</TR>
						</TABLE>
					
						<asp:Panel id="pnlHistory" runat="server" >
							<TABLE id="Table2" class="table">
								<TR>
									<TD>Master History of Wheel:</TD>
								</TR>
								<TR>
									<TD>
										<asp:DataGrid id="dgMasterHistory" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
											<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
											<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
											<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
											<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
											<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
											<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
										</asp:DataGrid></TD>
								</TR>
								<TR>
									<TD>Magna History:</TD>
								</TR>
								<TR>
									<TD>
										<asp:DataGrid id="dgMagHistory" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
											<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
											<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
											<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
											<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
											<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
											<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
										</asp:DataGrid></TD>
								</TR>
								<TR>
									<TD>Final Insp History:</TD>
								</TR>
								<TR>
									<TD>
										<asp:DataGrid id="dgFIHistory" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
											<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
											<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
											<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
											<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
											<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
											<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
										</asp:DataGrid></TD>
								</TR>
								<TR>
									<TD>Yard History:</TD>
								</TR>
								<TR>
									<TD>
										<asp:DataGrid id="dgYIHistory" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
											<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
											<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
											<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
											<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
											<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
											<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
										</asp:DataGrid></TD>
								</TR>
								<TR>
									<TD>QC Insp History:</TD>
								</TR>
								<TR>
									<TD>
										<asp:DataGrid id="dgQChistory" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
											<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
											<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
											<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
											<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
											<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
											<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
										</asp:DataGrid></TD>
								</TR>
								<TR>
									<TD>Wheel Load History:</TD>
								</TR>
								<TR>
									<TD>
										<asp:DataGrid id="dgWhlLoadHistory" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
											<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
											<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
											<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
											<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
											<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
											<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
										</asp:DataGrid></TD>
								</TR>
								<TR>
									<TD>Axle Assembly History:</TD>
								</TR>
								<TR>
									<TD>
										<asp:DataGrid id="dgPressHistory" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
											<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
											<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
											<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
											<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
											<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
											<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
										</asp:DataGrid></TD>
								</TR>
								<TR>
									<TD>Despatch History:</TD>
								</TR>
								<TR>
									<TD>
										<asp:DataGrid id="dgDespHistory" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
											<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
											<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
											<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
											<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
											<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
											<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
										</asp:DataGrid></TD>
								</TR>
							</TABLE>
						</asp:Panel>
			
		</div></div></form></div>
	</body>
</HTML>
