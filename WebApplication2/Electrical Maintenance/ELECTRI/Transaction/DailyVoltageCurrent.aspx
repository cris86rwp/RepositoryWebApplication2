<%@ Page Language="vb" AutoEventWireup="false" Codebehind="DailyVoltageCurrent.aspx.vb" Inherits="WebApplication2.DailyVoltageCurrent" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>DailyVoltageCurrent</title>
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
      <%-- <link rel="stylesheet" href="StyleSheet1.css" />--%>
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

		<FORM id="Form1" method="post" runat="server">
              <div class="row">
    
                 <%-- <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" >
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
      </div>
            <div class="row table-responsive">
		
			<asp:Panel id="Panel1"  runat="server" >
				<TABLE id="Table1" class="table" >
					<TR>
						<TD  colSpan="2">DAILY VOLTAGE&nbsp; CURRENT 
							&nbsp;STATISTICS</TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<asp:label id="lblMessage" runat="server" Width="391px" ForeColor="Red"></asp:label></TD>
					</TR>
					<TR>
						<TD >Date :
							<asp:textbox id="txtDate" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox>
							<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtDate" ErrorMessage="*"></asp:requiredfieldvalidator></TD>
						<TD>Time :
							<asp:dropdownlist id="ddlMinutes" runat="server" CssClass="form-control ll" AutoPostBack="True">
								<asp:ListItem Value="Select" Selected="True">Select</asp:ListItem>
								<asp:ListItem Value="h00m00">00:00</asp:ListItem>
								<asp:ListItem Value="h00m30">00:30</asp:ListItem>
								<asp:ListItem Value="h01m00">01:00</asp:ListItem>
								<asp:ListItem Value="h01m30">01:30</asp:ListItem>
								<asp:ListItem Value="h02m00">02:00</asp:ListItem>
								<asp:ListItem Value="h02m30">02:30</asp:ListItem>
								<asp:ListItem Value="h03m00">03:00</asp:ListItem>
								<asp:ListItem Value="h03m30">03:30</asp:ListItem>
								<asp:ListItem Value="h04m00">04:00</asp:ListItem>
								<asp:ListItem Value="h04m30">04:30</asp:ListItem>
								<asp:ListItem Value="h05m00">05:00</asp:ListItem>
								<asp:ListItem Value="h05m30">05:30</asp:ListItem>
								<asp:ListItem Value="h06m00">06:00</asp:ListItem>
								<asp:ListItem Value="h06m30">06:30</asp:ListItem>
								<asp:ListItem Value="h07m00">07:00</asp:ListItem>
								<asp:ListItem Value="h07m30">07:30</asp:ListItem>
								<asp:ListItem Value="h08m00">08:00</asp:ListItem>
								<asp:ListItem Value="h08m30">08:30</asp:ListItem>
								<asp:ListItem Value="h09m00">09:00</asp:ListItem>
								<asp:ListItem Value="h09m30">09:30</asp:ListItem>
								<asp:ListItem Value="h10m00">10:00</asp:ListItem>
								<asp:ListItem Value="h10m30">10:30</asp:ListItem>
								<asp:ListItem Value="h11m00">11:00</asp:ListItem>
								<asp:ListItem Value="h11m30">11:30</asp:ListItem>
								<asp:ListItem Value="h12m00">12:00</asp:ListItem>
								<asp:ListItem Value="h12m30">12:30</asp:ListItem>
								<asp:ListItem Value="h13m00">13:00</asp:ListItem>
								<asp:ListItem Value="h13m30">13:30</asp:ListItem>
								<asp:ListItem Value="h14m00">14:00</asp:ListItem>
								<asp:ListItem Value="h14m30">14:30</asp:ListItem>
								<asp:ListItem Value="h15m00">15:00</asp:ListItem>
								<asp:ListItem Value="h15m30">15:30</asp:ListItem>
								<asp:ListItem Value="h16m00">16:00</asp:ListItem>
								<asp:ListItem Value="h16m30">16:30</asp:ListItem>
								<asp:ListItem Value="h17m00">17:00</asp:ListItem>
								<asp:ListItem Value="h17m30">17:30</asp:ListItem>
								<asp:ListItem Value="h18m00">18:00</asp:ListItem>
								<asp:ListItem Value="h18m30">18:30</asp:ListItem>
								<asp:ListItem Value="h19m00">19:00</asp:ListItem>
								<asp:ListItem Value="h19m30">19:30</asp:ListItem>
								<asp:ListItem Value="h20m00">20:00</asp:ListItem>
								<asp:ListItem Value="h20m30">20:30</asp:ListItem>
								<asp:ListItem Value="h21m00">21:00</asp:ListItem>
								<asp:ListItem Value="h21m30">21:30</asp:ListItem>
								<asp:ListItem Value="h22m00">22:00</asp:ListItem>
								<asp:ListItem Value="h22m30">22:30</asp:ListItem>
								<asp:ListItem Value="h23m00">23:00</asp:ListItem>
								<asp:ListItem Value="h23m30">23:30</asp:ListItem>
							</asp:dropdownlist>Hours. Min.</TD>
					</TR>
					<TR>
						<TD >Voltage Statistics</TD>
						<TD>
							<asp:textbox id="txt66" runat="server" CssClass="form-control"></asp:textbox>132KV
							<asp:requiredfieldvalidator id="rfv66" runat="server" ControlToValidate="txt66" ErrorMessage="*"></asp:requiredfieldvalidator>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
					</TR>
					<TR>
						<TD >Current</TD>
						<TD>
							<asp:textbox id="txtCurrent" runat="server" CssClass="form-control"></asp:textbox>Ampere</TD>
					</TR>
					<TR>
						<TD >Power</TD>
						<TD>
							<asp:textbox id="txtPower" runat="server" CssClass="form-control"></asp:textbox>MVA</TD>
					</TR>
					<TR>
						<TD  colSpan="2" rowSpan="1">
							<asp:button id="btnSubmit_Clicks" runat="server"  CssClass="button button2" Font-Names="Arial" Font-Size="Smaller" Text="Save" BorderStyle="Groove"></asp:button>
							<asp:button id="btnCancel" runat="server" CssClass="button button2" Font-Names="Arial" Font-Size="Smaller" Text="Clear" BorderStyle="Groove"></asp:button>
							<asp:button id="btnExit" runat="server" CssClass="button button2" Font-Names="Arial" Font-Size="Smaller" Text="Exit" BorderStyle="Groove" CausesValidation="False"></asp:button></TD>
					</TR>
				</TABLE>
				<asp:DataGrid id="DataGrid1" runat="server" BorderStyle="None" CellPadding="4" BackColor="White" BorderWidth="1px" BorderColor="#CC9966">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
			</asp:Panel>
			<TABLE id="Table2" class="table">
			</TABLE>
		</div>

		</form></div>
	</body>
</HTML>
