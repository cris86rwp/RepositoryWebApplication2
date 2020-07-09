<%@ Page Language="vb" AutoEventWireup="false" Codebehind="DailyMDPF.aspx.vb" Inherits="WebApplication2.DailyMDPF" Culture="en-GB" uiCulture="en-GB" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>DailyMDPF</title>
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
       <%--<link rel="stylesheet" href="../../../StyleSheet1.css" />--%>
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

			<asp:Panel id="Panel1"  runat="server">
				<TABLE id="Table1" class="table">
					<TR>
						<TD colSpan="2">Daily PF and MD</TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></TD>
					</TR>
					<TR>
						<TD>Date  :</TD>
						
						<TD>
							<asp:textbox id="txtDate" runat="server" AutoPostBack="True" CssClass="form-control"></asp:textbox></TD>
					</TR>
					<TR>
						<TD>P. F.  :</TD>
						
						<TD>
							<asp:textbox id="txtPF" runat="server" CssClass="form-control" MaxLength="5">0.000</asp:textbox></TD>
					</TR>
					<TR>
						<TD>M. D.  :</TD>
						
						<TD>
							<asp:textbox id="txtMD" runat="server" CssClass="form-control"></asp:textbox>&nbsp;MVA</TD>
					</TR>
					<TR>
						<TD>MDTrippings  :</TD>
						
						<TD>
							<asp:textbox id="txtMDTrippings" runat="server" CssClass="form-control"></asp:textbox></TD>
					</TR>
					<TR>
						<TD>TotalTime  :</TD>
						
						<TD>
							<asp:textbox id="txtTotalTime" runat="server" CssClass="form-control"></asp:textbox>&nbsp;Minutes</TD>
					</TR>
					<TR>
						<TD  colSpan="2">
							<asp:button id="btnSubmit_Clicks" runat="server"  BorderStyle="Groove" Text="Save" Font-Size="Smaller" Font-Names="Arial" CssClass="button button2"></asp:button></TD>
					</TR>
				</TABLE>
				<TABLE id="Table2" class="table">
					<TR>
						<TD  colSpan="2">Shoot Up MD Statistics</TD>
					</TR>
					<TR>
						<TD >ShiftDate :</TD>
						<TD>
							<asp:textbox id="txtConsumptionDate" runat="server" AutoPostBack="True" CssClass="form-control"></asp:textbox></TD>
					</TR>
					<TR>
						<TD >ShootUpDate</TD>
						<TD>
							<asp:textbox id="txtShootUpDate" runat="server" CssClass="form-control"></asp:textbox></TD>
					</TR>
					<TR>
						<TD >Time</TD>
						<TD>
							<asp:textbox id="txtHr" runat="server" CssClass="form-control" MaxLength="2"></asp:textbox></TD>
                            <TD>
							<asp:textbox id="txtMin" runat="server" CssClass="form-control" MaxLength="2" AutoPostBack="True"></asp:textbox>&nbsp;( 
							hh:mm)</TD>
					</TR>
					<TR>
						<TD >MDValue</TD>
						<TD>
							<asp:textbox id="txtMVA" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox>
							<asp:Label id="lblSL" runat="server" Visible="False"></asp:Label></TD>
					</TR>
					<TR>
						<TD  colSpan="2" rowSpan="1">
							<asp:button id="Button1" runat="server"  BorderStyle="Groove" Text="Save" Font-Size="Smaller" Font-Names="Arial" CssClass="button button2"></asp:button>
							<asp:button id="btnCancel" runat="server"  BorderStyle="Groove" Text="Clear" Font-Size="Smaller" Font-Names="Arial" CssClass="button button2"></asp:button>
							<asp:button id="btnExit" runat="server"  BorderStyle="Groove" Text="Exit" Font-Size="Smaller" Font-Names="Arial" CssClass="button button2"  CausesValidation="False"></asp:button></TD>
					</TR>
				</TABLE>
				<asp:DataGrid id="DataGrid1" runat="server" BorderStyle="None" BorderColor="#CC9966" BorderWidth="1px" BackColor="White" CellPadding="4">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<Columns>
						<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
			</asp:Panel>
	</div>	</form>
            </div>
	</body>
</HTML>
