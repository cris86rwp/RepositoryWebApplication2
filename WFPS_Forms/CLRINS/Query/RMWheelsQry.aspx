<%@ Page Language="vb" AutoEventWireup="false" Codebehind="RMWheelsQry.aspx.vb" Inherits="WebApplication2.RMWheelsQry" Culture="en-GB" uiCulture="en-GB" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>RMWheelsQry</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout" bgColor="#99ccff">
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
      <div class="container">
		<form id="Form1" method="post" runat="server">
			<asp:Panel id="Panel1" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server" Width="437px" Height="96px">
				<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="300" border="1">
					<TR>
						<TD align="middle" colSpan="3">RM Wheels Report</TD>
					</TR>
					<TR>
						<TD colSpan="3">
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></TD>
					</TR>
					<TR>
						<TD>RM Dates</TD>
						<TD>:</TD>
						<TD>
							<asp:DropDownList id="ddlRMDates" runat="server"></asp:DropDownList></TD>
					</TR>
					<TR>
						<TD align="middle" colSpan="3">
							<asp:Button id="btnShow" runat="server" Text="Show Report"></asp:Button></TD>
					</TR>
				</TABLE>
				<TABLE id="Table2" style="WIDTH: 396px; HEIGHT: 59px" cellSpacing="1" cellPadding="1" width="396" border="1">
					<TR>
						<TD><FONT face="Arial">FromDate</FONT></TD>
						<TD>:</TD>
						<TD>
							<asp:textbox id="txtFromDate" runat="server" Width="88px" BorderStyle="Groove"></asp:textbox></TD>
						<TD>ToDate</TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="txtToDate" runat="server" Width="96px"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD align="middle" colSpan="6">
							<asp:RadioButtonList id="rblType" runat="server">
								<asp:ListItem Value="1" Selected="True">RM Wheel Summary</asp:ListItem>
								<asp:ListItem Value="2">RM Wheel Details</asp:ListItem>
							</asp:RadioButtonList></TD>
					</TR>
					<TR>
						<TD align="middle" colSpan="6">
							<asp:button id="Button2" runat="server" Height="24px" Width="146px" Text="Show Details in Grid" BorderStyle="Groove" Font-Size="Smaller" Font-Names="Arial"></asp:button></TD>
					</TR>
					<TR>
						<TD align="middle" colSpan="6">
							<asp:Button id="Button1" runat="server" Text="Export Details"></asp:Button></TD>
					</TR>
				</TABLE>
				<asp:DataGrid id="DataGrid1" runat="server" BorderStyle="None" BorderColor="#CC9966" BorderWidth="1px" BackColor="White" CellPadding="4">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
			</asp:Panel>
		</form>
          </div>
	</body>
</HTML>
