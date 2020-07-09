<%@ Page Language="vb" AutoEventWireup="false" Codebehind="BreakDownMaintenaceSummary.aspx.vb" Inherits="WebApplication2.BreakDownMaintenaceSummary" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>BreakDownMaintenaceSummary</title>
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
		<form id="Form1" method="post" runat="server">
             <div class="row">
                <%--<h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" class="formcontrolll" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
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
						<TD colSpan="3">BreakDown Maintenace Summary&nbsp; List&nbsp;Report</TD>
					</TR>
					<TR>
						<TD colSpan="3">
							<asp:label id="lblMessage" runat="server" BackColor="Transparent" ForeColor="Red"></asp:label></TD>
					</TR>
					<TR>
						<TD>Group</TD>
						<TD colSpan="2">
							<asp:label id="lblMaintenance_group" runat="server"></asp:label></TD>
					</TR>
					<TR>
						<TD>From Dt</TD>
						<TD colSpan="2">
							<asp:TextBox id="txtFrDt" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>To Dt</TD>
						<TD colSpan="2">
							<asp:TextBox id="txtToDt" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>Location</TD>
						<TD colSpan="2">
							<asp:dropdownlist id="cboLocation" runat="server" AutoPostBack="True" CssClass="form-control ll"></asp:dropdownlist></TD>
					<TR>
						<TD>Machine Code</TD>
						<TD colSpan="2">
							<asp:DropDownList id="ddlMachineCode" runat="server" CssClass="form-control ll"></asp:DropDownList></TD>
					</TR>
					<TR>
						<TD>BreakDown Type</TD>
						<TD colSpan="2">
							<asp:DropDownList id="ddlType" runat="server" CssClass="form-control ll"></asp:DropDownList></TD>
					</TR>
					<TR>
						<TD>Production&nbsp;&nbsp;Affected</TD>
						<TD colSpan="2">
							<asp:RadioButtonList id="radProduction" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl">
								<asp:ListItem Value="1">Yes</asp:ListItem>
								<asp:ListItem Value="0">No</asp:ListItem>
								<asp:ListItem Value="2" Selected="True">Both</asp:ListItem>
							</asp:RadioButtonList></TD>
					</TR>
					<TR>
						<TD>MinimumLoss</TD>
						<TD colSpan="2">
							<asp:textbox id="txtTime" runat="server" CssClass="form-control" BorderStyle="Groove">0</asp:textbox>(inMin 
							, eg : 10 , 70 )</TD>
					</TR>
					<TR>
						<TD align="middle" colSpan="3">
							<asp:button id="btnShowReport" runat="server" Text="Show Report" CssClass="button button2"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:Button id="Button1" runat="server" Text="Export" CssClass="button button2"></asp:Button></TD>
					</TR>
				</TABLE>
				<asp:DataGrid id="dgDetails" runat="server" BackColor="White" BorderStyle="None" CellPadding="4" BorderWidth="1px" BorderColor="#CC9966" CssClass="table">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
			</asp:panel></div>
               </form> 
        </div>
      
        <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
