<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Invoice.aspx.vb" Inherits="WebApplication2.Invoice" %>
<!DOCTYPE HTML>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>Invoice</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR"/>
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
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

        <%-- <link rel="stylesheet" href="../../StyleSheet1.css" />--%>
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
			<asp:panel id="Panel1" runat="server">
				<TABLE id="Table1" class="table">
					<TR>
						<TD><h2>Invoice TAX Report</h2><hr class="prettyline" /></TD>
					</TR>
				</TABLE>
				<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label>
				<TABLE id="Table3" class="table">
					<TR>
						<TD>
							<asp:RadioButtonList id="rblGroup" runat="server" CssClass="rbl" AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal" Width="352px">
								<%--<asp:ListItem Value="MRKTING" Selected="True">MRKTING</asp:ListItem>--%>
								<asp:ListItem Value="PCOPCO">PCOPCO</asp:ListItem>
								<%--<asp:ListItem Value="WARD30">WARD30</asp:ListItem>--%>
								<%--<asp:ListItem Value="CnF">C&amp;F</asp:ListItem>--%>
							</asp:RadioButtonList></TD>
					</TR>
				</TABLE>
				<asp:Panel id="pnlMrk" runat="server">
					<TABLE id="Table2" class="table">
						<TR>
							<TD>ReferenceID</TD>
							<TD>:</TD>
							<TD>
								<asp:DropDownList id="ddlRefID" CssClass="form-control ll" runat="server" AutoPostBack="True"></asp:DropDownList></TD>
						</TR>
					</TABLE>
				</asp:Panel>
				<asp:Panel id="pnlPCO" runat="server">
					<TABLE id="Table12" class="table">
						<TR>
							<TD>Despatch Advice No</TD>
							<TD colSpan="2">
								<asp:DropDownList id="ddlDespatchAdviceNo" CssClass="form-control ll" runat="server" AutoPostBack="True"></asp:DropDownList></TD>
						</TR>
					</TABLE>
				</asp:Panel>
				<asp:Panel id="pnlWard" runat="server">
					<TABLE id="Table15" class="table">
						<TR>
							<TD>SaleOrders</TD>
							<TD>
								<asp:DropDownList id="ddlSaleOrders" runat="server" CssClass="form-control" AutoPostBack="True"></asp:DropDownList></TD>
						</TR>
                       
					</TABLE>
					<TABLE id="Table16">
                         
					</TABLE>
				</asp:Panel>
				<TABLE id="Table14" class="table">
					<TR>
						<TD colspan="2">InvoiceNo</TD>
						<TD>
							<asp:RadioButtonList id="rblInvoice" CssClass="rbl" runat="server" AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal"></asp:RadioButtonList></TD>
					</TR>
				</TABLE>
                <table class="table">
				<asp:DataGrid id="DataGrid1" CssClass="table" runat="server" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid></table>
				<TABLE id="Table4" class="table">
					<TR>
						<TD>
							<asp:Button id="btnShowReport" Text="ShowReport" runat="server" CssClass="button button2"></asp:Button></TD>
					</TR>
				</TABLE>
				<asp:Panel id="Panel2" runat="server">
					<TABLE id="Table5" class="table">
						<TR>
							<TD>FromDate</TD>
							<TD>
								<asp:TextBox id="txtFromDate" runat="server" AutoPostBack="True" CssClass="form-control"></asp:TextBox></TD>
							<TD>ToDate</TD>
							<TD>
								<asp:TextBox id="txtToDate" runat="server" AutoPostBack="True" CssClass="form-control"></asp:TextBox></TD>
						<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtToDate" ControlToValidate="txtFromDate" ErrorMessage="To Date should be greater than From Date" ForeColor="#FF3300" Operator="LessThanEqual" Type="Date"></asp:CompareValidator>

                        </TR>
						<TR>
							<TD align="middle" colSpan="4">
								<asp:Button id="btnShow" runat="server" Text="Show Data in Grid" CssClass="button button2"></asp:Button></TD>
						</TR>
						<TR>
							<TD align="middle" colSpan="4">
								<asp:button id="btnExportDetails" runat="server" Text="Export To EXCEL" CssClass="button button2"></asp:button></TD>
						</TR>
					</TABLE>
					<asp:DataGrid id="DataGrid2" CssClass="table" runat="server" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966">
						<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
						<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
						<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
						<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
						<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
					</asp:DataGrid>
				</asp:Panel>
			</asp:panel></form>
         </div></div></div>
        <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</html>
