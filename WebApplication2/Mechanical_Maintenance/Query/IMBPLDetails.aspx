<%@ Page Language="vb" AutoEventWireup="false" Codebehind="IMBPLDetails.aspx.vb" Inherits="WebApplication2.IMBPLDetails" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>IMBPLDetails</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
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
      <%-- <link rel="stylesheet" href="../../StyleSheet1.css" />--%>
	   
    </HEAD>
	<body bgColor="#99ccff" MS_POSITIONING="GridLayout">
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

         <div class="container">
		<form id="Form2" method="post" runat="server">
             <div class="row">
    
                 <%-- <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 </br>--%>
      </div>
            
             <div class="row">
                <div class="table-responsive">


		<%--<form id="Form1" method="post" runat="server">--%>
			<asp:Panel id="Panel1" runat="server">
				<TABLE id="Table1" class="table">
					<TR>
						<TD><FONT size="5">PL Number Details </FONT><hr class="prettyline" />
						</TD>
					</TR>
				</TABLE>
				<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label>
				<TABLE id="Table5" class="table">
					<TR>
						<TD>FromDate</TD>
						<TD>
							<asp:TextBox id="txtFromDate" CssClass="form-control" runat="server" ></asp:TextBox></TD>
						<TD>ToDate</TD>
						<TD>
							<asp:TextBox id="txtToDate" runat="server" CssClass="form-control" ></asp:TextBox></TD>
					</TR>
				</TABLE>
				<TABLE id="Table3" class="table">
					<TR>
						<TD>PLNumber</TD>
						<TD>
							<asp:dropdownlist id="ddlPLNumber" CssClass="form-control ll" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
					</TR>
				</TABLE>
				<TABLE id="Table4" class="table">
					<TR>
						<TD>LedgerNo</TD>
						<TD style="WIDTH: 105px">
							<asp:label id="lblLedgerNo" runat="server"></asp:label>&nbsp;</TD>
						<TD>UOM</TD>
						<TD>
							<asp:Label id="lblPLUnit" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD>Location</TD>
						<TD style="WIDTH: 105px">
							<asp:label id="lblLocationID" runat="server"></asp:label>&nbsp;</TD>
						<TD colSpan="2">
							<asp:label id="lblLocation" runat="server" Width="276px"></asp:label></TD>
					</TR>
					<TR>
						<TD>BalanceIMB</TD>
						<TD style="WIDTH: 105px">
							<asp:Label id="lblBalance" runat="server"></asp:Label></TD>
						<TD>InStore</TD>
						<TD>
							<asp:label id="lblInStore" runat="server" Width="125px"></asp:label></TD>
					</TR>
					<TR>
						<TD>UnitRate</TD>
						<TD style="WIDTH: 105px">
							<asp:Label id="lblUnitRate" runat="server"></asp:Label></TD>
						<TD></TD>
						<TD></TD>
					</TR>
				</TABLE>
				<TABLE id="Table2" class="table">
					<TR>
						<TD align="middle" colSpan="3">
							<asp:Button id="Button1" CssClass="button button2" BorderStyle="Groove" runat="server" Text="Export to Excel"></asp:Button></TD>
					</TR>
				</TABLE>
				<asp:DataGrid id="DataGrid1" runat="server" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
			</asp:Panel>
		</form>
	</body>
</HTML>
