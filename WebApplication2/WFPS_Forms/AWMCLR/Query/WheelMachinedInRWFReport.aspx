<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WheelMachinedInRWFReport.aspx.vb" Inherits="WebApplication2.WheelMachinedInRWFReport" Culture="en-GB" uiCulture="en-GB" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Baking station</title>
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

    <%--<link href="../../../StyleSheet1.css" rel="stylesheet" />--%>
    </head>
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
            <div class="row">
                <div class="table-responsive">
		<form id="Form1" method="post" runat="server">
       <%--      <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
			<asp:panel id="Panel1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute" runat="server" Width="48px">
				<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="300" border="1">
					<TR>
						<TD noWrap align="middle" width="100%" colSpan="3"><STRONG><FONT size="5">Wheels&nbsp;Machined 
									in RWF Report</FONT></STRONG></TD>
					</TR>
					<TR>
						<TD>Message</TD>
						<TD>:</TD>
						<TD>
							<asp:Label id="lblmessage" runat="server" Width="200px" ForeColor="Red"></asp:Label></TD>
					</TR>
					<TR>
						<TD>Machined Date</TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="txtMachinedDate" runat="server" Width="119px" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD noWrap align="middle" width="100%" colSpan="3">
							<asp:Button id="Button1" runat="server" Text="Show Data in Grid" CssClass="form-control"></asp:Button></TD>
					</TR>
				</TABLE>
				<asp:panel id="Panel2" runat="server" Width="112px" ForeColor="White"  Height="93px">
					<TABLE id="Table2" style="WIDTH: 266px; HEIGHT: 90px" cellSpacing="1" cellPadding="1" width="266" border="1">
						<TR>
							<TD>FromDate</TD>
							<TD style="WIDTH: 1px ">:</TD>
							<TD>
								<asp:TextBox id="txtFrDate" runat="server" Width="84px" AutoPostBack="True" CssClass="form-control"></asp:TextBox></TD>
						</TR>
						<TR>
							<TD>ToDate</TD>
							<TD style="WIDTH: 1px">:</TD>
							<TD>
								<asp:TextBox id="txtToDate" runat="server" Width="84px" AutoPostBack="True" CssClass="form-control"></asp:TextBox></TD>
						</TR>
						<TR>
							<TD vAlign="top" align="left" colSpan="3">
								<asp:radiobuttonlist id="rblQry" runat="server" RepeatLayout="Flow">
									<asp:ListItem Value="1" Selected="True">ShiftWiseData</asp:ListItem>
									<asp:ListItem Value="2">WheelTypeWiseSummary</asp:ListItem>
									<asp:ListItem Value="3">WheelTypeWiseDateWiseDetails</asp:ListItem>
									<asp:ListItem Value="4">MachineWiseSummary</asp:ListItem>
								</asp:radiobuttonlist></TD>
						</TR>
						<TR>
							<TD vAlign="top" align="middle" colSpan="3">
								<asp:Button id="ShowData" runat="server" Text="ShowData" CssClass="form-control"></asp:Button></TD>
						</TR>
					</TABLE>
				</asp:panel>
				<asp:DataGrid id="DataGrid1" runat="server" BackColor="White" CellPadding="4" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
			</asp:panel>
		</form>
	 </div>
                </div>
            </div>
     <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>

