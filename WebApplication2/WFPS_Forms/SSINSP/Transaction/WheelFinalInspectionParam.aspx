<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WheelFinalInspectionParam.aspx.vb" Inherits="WebApplication2.WheelFinalInspectionParam" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>WheelFinalInspectionParam</title>
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
      <%-- <link rel="stylesheet" href="../../../StyleSheet1.css" />--%>
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
    
               <%--   <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>--%>
            
            <%--     <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>--%>
                 <br />
      </div>
            <div class="row"><div class="table-responsive">
			<asp:Panel id="Panel1"  runat="server">
				<TABLE id="Table1" class="table">
					<TR>
						<TD>Final Inspection Parameters</TD>
					</TR>
					<TR>
						<TD>
							<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></TD>
					</TR>
					<TR>
						<TD>
							<asp:RadioButtonList id="rblType" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rbl">
								<asp:ListItem Value="Wheel" Selected="True">Wheel</asp:ListItem>
								
							</asp:RadioButtonList>
                          <!--  <asp:ListItem Value="TrackGuages">TrackGuages</asp:ListItem>
								<asp:ListItem Value="MountPressures">MountPressures</asp:ListItem> -->
						</TD>
					</TR>
					<TR>
						<TD>
							<asp:DropDownList id="ddlProduct" runat="server" AutoPostBack="True" CssClass="form-control"></asp:DropDownList></TD>
					</TR>
					<TR>
						<TD><FONT color="brown">All Dimensions in mm</FONT></TD>
					</TR>
				</TABLE>
				<asp:Panel id="pnlW" runat="server">
					<TABLE id="Table2" class="table">
						<TR>
							<TD>Min Tread Dia</TD>
							<TD>
								<asp:TextBox id="MinTD" runat="server" CssClass="form-control"></asp:TextBox></TD>
							<TD>Max Tread Dia</TD>
							<TD>
								<asp:TextBox id="MaxTD" runat="server" CssClass="form-control"></asp:TextBox></TD>
						</TR>
						<TR>
							<TD>Min Bore Dia</TD>
							<TD>
								<asp:TextBox id="MinBore" runat="server" CssClass="form-control"></asp:TextBox></TD>
							<TD>Max Bore Dia</TD>
							<TD>
								<asp:TextBox id="MaxBore" runat="server" CssClass="form-control"></asp:TextBox></TD>
						</TR>
						<TR>
							<TD>min Hub Length</TD>
							<TD>
								<asp:TextBox id="minHubLen" runat="server" CssClass="form-control"></asp:TextBox></TD>
							<TD>max Hub Length</TD>
							<TD>
								<asp:TextBox id="maxHubLen" runat="server" CssClass="form-control"></asp:TextBox></TD>
						</TR>
						<TR>
							<TD>min Rim Thickness</TD>
							<TD>
								<asp:TextBox id="minRimTh" runat="server" CssClass="form-control"></asp:TextBox></TD>
							<TD>max Rim Thickness</TD>
							<TD>
								<asp:TextBox id="maxRimTh" runat="server" CssClass="form-control"></asp:TextBox></TD>
						</TR>
						<TR>
							<TD>min Back Hub Projection</TD>
							<TD>
								<asp:TextBox id="minHubProj" runat="server" CssClass="form-control"></asp:TextBox></TD>
							<TD>max Back Hub Projection</TD>
							<TD>
								<asp:TextBox id="maxHubProj" runat="server" CssClass="form-control"></asp:TextBox></TD>
						</TR>
						<TR>
							<TD>Min Plate Thickness</TD>
							<TD>
								<asp:TextBox id="MinPT" runat="server" CssClass="form-control"></asp:TextBox></TD>
							<TD>Max Plate Thickness</TD>
							<TD>
								<asp:TextBox id="MaxPT" runat="server" CssClass="form-control"></asp:TextBox></TD>
						</TR>
						<TR>
							<TD>Over Size Min</TD>
							<TD>
								<asp:TextBox id="OverSizeMin" runat="server" CssClass="form-control"></asp:TextBox></TD>
							<TD>Over Size Max</TD>
							<TD>
								<asp:TextBox id="OverSizeMax" runat="server" CssClass="form-control"></asp:TextBox></TD>
						</TR>
						<TR>
							<TD>Min Wheel No</TD>
							<TD>
								<asp:TextBox id="MinWhlNo" runat="server" CssClass="form-control"></asp:TextBox></TD>
							<TD>Max Wheel No</TD>
							<TD>
								<asp:TextBox id="MaxWhlNo" runat="server" CssClass="form-control"></asp:TextBox></TD>
						</TR>
						<TR>
							<TD>Mcn Min Dia</TD>
							<TD>
								<asp:TextBox id="McnMinDia" runat="server" CssClass="form-control"></asp:TextBox></TD>
							<TD></TD>
							<TD></TD>
						</TR>
                        <TR>
							<TD>MIN RIM THICKNESS</TD>
							<TD>:</TD>
							<TD><asp:TextBox id="TextBox1" runat="server" CssClass="form-control"></asp:TextBox></TD>
						</TR>
					</TABLE>
				</asp:Panel>
				<asp:Panel id="pnlM" runat="server">
					<TABLE id="Table4" class="table">
						<TR>
							<TD>MinPressure</TD>
							<TD>:</TD>
							<TD>
								<asp:TextBox id="min_pressure" runat="server" CssClass="form-control"></asp:TextBox></TD>
						</TR>
						<TR>
							<TD>MaxPressure</TD>
							<TD>:</TD>
							<TD>
								<asp:TextBox id="max_pressure" runat="server" CssClass="form-control"></asp:TextBox></TD>
						</TR>
						<TR>
							<TD></TD>
							<TD></TD>
							<TD></TD>
						</TR>
					</TABLE>
				</asp:Panel>
				<asp:Panel id="pnlT" runat="server">
					<TABLE id="Table5" class="table">
						<TR>
							<TD>MinGuage</TD>
							<TD>:</TD>
							<TD>
								<asp:TextBox id="Min_Guage" runat="server" CssClass="form-control"></asp:TextBox></TD>
						</TR>
						<TR>
							<TD>MaxGuage</TD>
							<TD>:</TD>
							<TD>
								<asp:TextBox id="max_Guage" runat="server" CssClass="form-control"></asp:TextBox></TD>
						</TR>
						
					</TABLE>
				</asp:Panel>
				<TABLE id="Table3" class="table">
					<TR>
						<TD align="middle">
							<asp:Button id="btnUpdate" runat="server" Text="Update" CssClass="button button2"></asp:Button></TD>
					</TR>
				</TABLE>
				<asp:DataGrid id="DataGrid1" runat="server" BorderColor="#CC9966" CssClass="table" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
			</asp:Panel>
		</div></div></form></div>
        <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
