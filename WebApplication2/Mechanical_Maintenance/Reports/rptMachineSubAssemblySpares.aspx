<%@ Page Language="vb" AutoEventWireup="false" Codebehind="rptMachineSubAssemblySpares.aspx.vb" Inherits="WebApplication2.rptMachineSubAssemblySpares" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>rptMachineSubAssemblySpares</title>
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
        <%-- <link rel="stylesheet" href="../../StyleSheet1.css" />--%>
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
		<form id="Form1" method="post" runat="server"> <div class="row">
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
                    <TABLE id="Table1" class="table">
					<TR>
						<TD colSpan="3">MACHINERY&nbsp; SPARES LIST REPORT</TD>
					</TR>
					<TR>
						<TD colSpan="3">
							<asp:label id="lblMessage" runat="server"></asp:label></TD>
					</TR>
					<TR>
						<TD>Group</TD>
						<TD colSpan="2">
							<asp:label id="lblMaintenance_group" runat="server"></asp:label>
							<asp:label id="lblGrp" runat="server" Visible="False"></asp:label></TD>
					</TR>
					<TR>
						<TD>Location</TD>
						<TD colSpan="2">
							<asp:dropdownlist id="cboLocation" runat="server" AutoPostBack="True" CssClass="form-control ll"></asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD colSpan="1" rowSpan="1">Machine&nbsp; 
							Code</TD>
						<TD>
							<asp:dropdownlist id="ddlMachineCode" runat="server" AutoPostBack="True" CssClass="form-control ll"></asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD align="middle" colSpan="3" rowSpan="1">
							<asp:radiobuttonlist id="rblStockType" runat="server" CssClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow">
								<asp:ListItem Value="With Stock Type">With Stock Type</asp:ListItem>
								<asp:ListItem Value="Without Stock Type" Selected="True">Without Stock Type</asp:ListItem>
							</asp:radiobuttonlist></TD>
					</TR>
					<TR>
						<TD align="middle" colSpan="3">
							<asp:button id="btnShowReport" runat="server" Text="Show Report" CssClass="button button2"></asp:button></TD>
					</TR>
				</TABLE>
				<TABLE id="Table2" class="table">
					<TR>
						<TD >PL Number
							<asp:CheckBox id="chkSelectAll" runat="server" Height="21px" AutoPostBack="True" Text="Select All"></asp:CheckBox></TD>
						<TD>:</TD>
						<TD>
							<asp:ListBox id="lsbPLNumber" runat="server" SelectionMode="Multiple" CssClass="ll"></asp:ListBox></TD>
					</TR>
					<TR>
						<TD vAlign="top" noWrap align="middle"  colSpan="3" rowSpan="1">
							<asp:Button id="btnPLReport" runat="server" Text="Show PL population detail Report" CssClass="button button2"></asp:Button></TD>
					</TR>
					<TR>
						<TD vAlign="top" noWrap align="middle" colSpan="3">
							<asp:Button id="Button2" runat="server" Text="Show PL population summary Report" CssClass="button button2"></asp:Button></TD>
					</TR>
				</TABLE>
				<asp:Panel id="Panel2" runat="server" ForeColor="White" >
					<TABLE id="Table3" class="table">
						<TR>
							<TD colSpan="3">Short Description of Pl</TD>
						</TR>
						<TR>
							<TD colSpan="3">
								<asp:RadioButtonList id="rblPlDesc" runat="server" CssClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow">
									<asp:ListItem Value="S" Selected="True">Stock</asp:ListItem>
									<asp:ListItem Value="N">Non-Stock</asp:ListItem>
									<asp:ListItem Value="A">Both</asp:ListItem>
									<asp:ListItem Value="C">Combined</asp:ListItem>
								</asp:RadioButtonList></TD>
						</TR>
						<TR>
							<TD colSpan="3">Machine Code :
								<asp:DropDownList id="ddlMachine" runat="server" CssClass="form-control ll"></asp:DropDownList></TD>
						</TR>
						<TR>
							<TD vAlign="top" align="middle" colSpan="3">
								<asp:Button id="btnReport" runat="server" Text="Report" CssClass="button button2"></asp:Button></TD>
						</TR>
					</TABLE>
				</asp:Panel>
				<asp:Panel id="Panel3" runat="server" ForeColor="White">
					<TABLE id="Table4" class="table">
						<TR>
							<TD vAlign="top" align="middle" colSpan="3">Stock In Store&nbsp;</TD>
						</TR>
						<TR>
							<TD vAlign="top" align="middle" colSpan="3">
								<asp:RadioButtonList id="rblInStore" runat="server" RepeatLayout="Flow" CssClass="rbl">
									<asp:ListItem Value="0" Selected="True">Nil Stock</asp:ListItem>
									<asp:ListItem Value="1">Less Than ES/EAR Qty</asp:ListItem>
								</asp:RadioButtonList></TD>
						</TR>
						<TR>
							<TD vAlign="top" align="middle" colSpan="3">
								<asp:Button id="Button1" runat="server" Text="Show Results in Grid" CssClass="button button2"></asp:Button></TD>
						</TR>
						<TR>
							<TD colSpan="3">
								<asp:DataGrid id="DataGrid1" runat="server" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" CssClass="table">
									<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
									<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
									<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
									<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
									<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
								</asp:DataGrid></TD>
						</TR>
					</TABLE>
				</asp:Panel>
			</asp:panel>

            </div>
               </form> 
        </div>
      
        <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
