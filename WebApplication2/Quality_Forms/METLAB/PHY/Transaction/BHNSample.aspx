<%@ Page Language="vb" AutoEventWireup="false" Codebehind="BHNSample.aspx.vb" Inherits="WebApplication2.BHNSample" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>BHNSample</title>
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
    <script type="text/javascript"     <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
        <%--<link rel="stylesheet" href="../../../../StyleSheet1.css" />--%>
</HEAD>
	<body>
  <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
   <a class="navbar-brand p-0" href="#"><img src="../../../../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
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
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../../wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home " style="font-size:30px;"></i>
        </a></li>
       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out" style="font-size:30px;"></i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
          <img src="../../../../NewFolder1/CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="45"/>
        </a>
      </li>
     </ul>
      
  </div>
</nav>
	
        <div class="container">
		<form id="Form1" method="post" runat="server">
            <div class="row"><div class="table-responsive">
			<asp:Panel id="Panel1"  runat="server">
				<TABLE id="Table1" class="table">
					<TR>
						<TD align="middle" colSpan="3"><STRONG>BHN Sample</STRONG>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
							Inspector :
							<asp:Label id="lblInsp" runat="server"></asp:Label><hr class="prettyline" /></TD>
					</TR>
				</TABLE>
				<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label>
				<TABLE id="Table4" class="table">
					<TR>
						<TD>Previous LabNumber Details :<hr class="prettyline" /></TD>
					</TR>
				</TABLE>
				<asp:DataGrid id="DataGrid1" runat="server" CssClass="table" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4">
					<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
				</asp:DataGrid>
				<TABLE id="Table3" class="table">
					<TR>
						<TD>NewLabNumber :</TD>
						<TD>
							<asp:label id="lblLab_Number" runat="server" ForeColor="Red"></asp:label></TD>
						<TD>SentDate</TD>
						<TD>
							<asp:textbox id="txtDate" runat="server" AutoPostBack="True" CssClass="form-control"></asp:textbox></TD>
					</TR>
					<TR>
						<TD>NewHeatFrom</TD>
						<TD>
							<asp:textbox id="txtHeatFrom" runat="server" AutoPostBack="True" CssClass="form-control"></asp:textbox></TD>
						<TD>NewHeatTo&nbsp;</TD>
						<TD>
							<asp:textbox id="txtHeatTo" runat="server" AutoPostBack="True" CssClass="form-control"></asp:textbox></TD>
					</TR>
					<TR>
						<TD>WheelNo</TD>
						<TD>
							<asp:textbox id="txtWheelNumber" runat="server" CssClass="form-control"></asp:textbox></TD>
						<TD>HeatNo</TD>
						<TD>
							<asp:textbox id="txtHeatNumber" runat="server" AutoPostBack="True" CssClass="form-control"></asp:textbox></TD>
					</TR>
					<TR>
						<TD colSpan="2">WheelType:
							<asp:label id="lblDescription" runat="server" ForeColor="Red"></asp:label>&nbsp;</TD>
						<TD align="middle" colSpan="2">
							<asp:Button id="btnSave" runat="server" Text="Save" CssClass="button button2"></asp:Button></TD>
					</TR>
					<TR>
						<TD colSpan="4">List of latest LabNumber of various Wheel Types:</TD>
					</TR>
				</TABLE>
				<asp:DataGrid id="grdReadings" runat="server" CssClass="table" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
			</asp:Panel>
                </div></div>
		</form>
            </div>
         <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
