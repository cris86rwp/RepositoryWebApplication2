<%@ Page Language="vb" AutoEventWireup="false" Codebehind="RMRQry.aspx.vb" Inherits="WebApplication2.RMRQry" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>RMRQry</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
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
      <%-- <link rel="stylesheet" href="StyleSheet1.css" />--%>
	
    
    </HEAD>
	<body MS_POSITIONING="GridLayout" bgColor="#99ccff">
	
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
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home "style="font-size:30px;"></i>
        </a></li>

       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../logon.aspx">
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
						<TD colSpan="3">RMR Qry -
							<asp:label id="lblConsignee" runat="server"></asp:label><hr class="prettyline" /></TD>
					</TR>
					<TR>
						<TD colSpan="3">
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></TD>
					</TR>
					<TR>
						<TD>Year</TD>
						<TD>:</TD>
						<TD>
							<asp:RadioButtonList id="rblYear" CssClass="rbl" runat="server" AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal"></asp:RadioButtonList></TD>
					</TR>
					<TR>
						<TD>Month</TD>
						<TD>:</TD>
						<TD>
							<asp:DropDownList id="ddlMonth" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:DropDownList></TD>
					</TR>
					<TR>
						<TD>PLNumber</TD>
						<TD>:</TD>
						<TD>
							<asp:DropDownList id="ddlPLs" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:DropDownList></TD>
					</TR>
				</TABLE>
				<asp:RadioButtonList id="rblQry" CssClass="rbl" runat="server" RepeatLayout="Flow">
					<asp:ListItem Value="Statement" Selected="True">Statement</asp:ListItem>
					<asp:ListItem Value="Entry">Entry</asp:ListItem>
					<asp:ListItem Value="UnUsed">UnUsed</asp:ListItem>
					<asp:ListItem Value="New Statement">New Statement</asp:ListItem>
					<asp:ListItem Value="StockItems">StockItems</asp:ListItem>
					<asp:ListItem Value="NonStockItems">NonStockItems</asp:ListItem>
				</asp:RadioButtonList>
				<TABLE id="Table2" class="table">
					<TR>
						<TD vAlign="top" align="middle">
							<asp:Button id="btnShow" CssClass="button button2" BorderStyle="Groove" runat="server" Text="Show Data"></asp:Button>
							<asp:Label id="lblConsumDate" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD align="middle">
							<asp:Button id="Button1" runat="server" CssClass="button button2" BorderStyle="Groove" Text="Export to Excel"></asp:Button></TD>
					</TR>
				</TABLE>
				<asp:DataGrid id="DataGrid1" runat="server" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
			</asp:Panel>
		</form>
              <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
