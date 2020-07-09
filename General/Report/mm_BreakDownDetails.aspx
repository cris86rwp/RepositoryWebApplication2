<%@ Page Language="vb" AutoEventWireup="false" Codebehind="mm_BreakDownDetails.aspx.vb" Inherits="WebApplication2.mm_BreakDownDetails" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>mm_BreakDownDetails</title>
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

   <%-- <link href="../../StyleSheet1.css" rel="stylesheet" />--%>

	</head>
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
          <i class="fab glyphicon glyphicon-home "style="font-size:30px;"></i>
        </a></li>

       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out"style="font-size:30px;"></i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
          <img src="../../NewFolder1/CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="45"/>
        </a>
      </li>
     </ul>
      
  </div>
</nav>
     <div class="container">
            <div class="row">
                <div class="table-responsive">


		<form id="Form1" method="post" runat="server">
                   <%-- <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
            <TR>
						<TD>  Breakdown Details</TD>
					</TR>
			    <asp:panel id="Panel1"  runat="server" >
				<TABLE id="Table1" class="table" >
					
					<TR>
						<TD >
							<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></TD>
					</TR>
					<TR>
                        <TD style="WIDTH: 20px" vAlign="left" align="left" colSpan="10">
						<TR>From Date :<TR>
                            <asp:textbox id="txtFromDate" runat="server" Width="100px"   CssClass="form-control"></asp:textbox>
							<asp:RequiredFieldValidator id="rfvld1" runat="server" ErrorMessage="*" ControlToValidate="txtFromDate"></asp:RequiredFieldValidator>&nbsp;&nbsp; 
						<TR>To Date : <T>
                            <asp:textbox id="txtToDate" runat="server" Width="100px" CssClass="form-control"></asp:textbox>
							<asp:RequiredFieldValidator id="rfvld2" runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="txtToDate"></asp:RequiredFieldValidator></T>
					</TR>
					<TR>
						<TD><TR>Location </TR>
							:&nbsp;&nbsp;
							<asp:RadioButtonList id="rblLocation" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:RadioButtonList></TD>
					</TR>
					<TR>
						<TD ><TR>
							<asp:button id="BtnShow" runat="server" Width="120px" Height="50px" BorderStyle="Groove" Font-Size="Smaller" Font-Names="Arial" Text="Show Report" CssClass="form-control"> </asp:button></TR></TD>
					</TR>
					<TR>
						<TD >
							<asp:Button id="btnDetails" runat="server" Text="Show Details on Grid"></asp:Button></TD>
					</TR>
					<TR>
						<TD>
							<asp:DropDownList id="ddlMachine" runat="server"></asp:DropDownList></TD>
					</TR>
					<TR>
						<TD>
							<asp:Button id="btnReport" runat="server" Text="Selected Machine Data"></asp:Button></TD>
					</TR>
					<TR>
						<TD vAlign="center" align="middle" bgColor="#ffcc33" colSpan="4">
							<asp:Button id="Button1" runat="server" Text="Export to Excel"></asp:Button></TD>
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
                     </div>
			</asp:panel></form>
                     </div>
                </div>
            </div>
     <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>


