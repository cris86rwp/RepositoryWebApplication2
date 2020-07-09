<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Summary_list_of_rmrs_rpt.aspx.vb" Inherits="WebApplication2.Summary_list_of_rmrs_rpt" %>
<!DOCTYPE HTML>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>Summary_list_of_rmrs_rpt</title>
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

       <%--  <link rel="stylesheet" href="../../StyleSheet1.css" />--%>
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
<!--/.Navbar -->

         
         <div class="container">
              <div class="row">
                <div class="table-responsive">

		<form id="Form1" method="post" runat="server">
            <%--<h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
			<asp:Panel id="Panel1" runat="server">
				<TABLE id="Table1" class="table">
					<TR>
						<TD colSpan="3"><h2>RMR Details</h2><hr class="prettyline" /></TD>
					</TR>
					<TR>
						<TD colSpan="3">
							<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></TD>
					</TR>
					<TR>
						<TD>WO Number</TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="txtWO" runat="server" CssClass="form-control" ToolTip="enter 4-digit Workorder number"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD align="middle" colSpan="3">
							<asp:Button id="BtnShow" runat="server" Text="Print Summary" CssClass="button button2"></asp:Button></TD>
					</TR>
					<TR>
						<TD align="middle" colSpan="3">
							<asp:Button id="Button1" runat="server" Text="Show Data on Grid" CssClass="button button2"></asp:Button></TD>
					</TR></TABLE>
					
							<TABLE id="Table2" class="table">
								<TR>
									<TD align="middle" colSpan="2">RMR Issued Details</TD>
								</TR>
								<TR>
									<TD>From Date</TD>
									<TD>
										<asp:textbox id="txtFromDate" runat="server" CssClass="form-control"></asp:textbox></TD>
								</TR>
								<TR>
									<TD>To Date</TD>
									<TD>
										<asp:textbox id="txtToDate" runat="server" CssClass="form-control"></asp:textbox></TD>
								</TR>
								<TR>
									<TD>MaterialList</TD>
									<TD>
										<asp:dropdownlist id="ddlMaterial" tabIndex="1" runat="server" CssClass="form-control ll"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD align="middle" colSpan="2">
										<asp:button id="btnReport" runat="server" CssClass="button button2" Text="Show Data on Grid"></asp:button></TD>
								</TR>
								<TR>
									<TD align="middle" colSpan="2">
										<asp:button id="btnExportDetails" runat="server" CssClass="button button2" Text="Export To EXCEL"></asp:button></TD>
								</TR>
							</TABLE>
						
				
				<asp:DataGrid id="DataGrid1" runat="server" CssClass="table" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
			</asp:Panel>
		</form>
        </div></div></div>
        <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</html>
