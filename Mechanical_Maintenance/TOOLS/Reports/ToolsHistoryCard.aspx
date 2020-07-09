<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ToolsHistoryCard.aspx.vb" Inherits="WebApplication2.ToolsHistoryCard" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>ToolsHistoryCard</title> 
		<!--<LINK id="mss" href="/wap.css" rel="stylesheet">-->
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
      <%--<link rel="stylesheet" href="../../../StyleSheet1.css" />--%>
	</HEAD>
	<body MS_POSITIONING="GridLayout" bgColor="#b6dcf5">
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
        
			<div class="container">
		<form id="Form2" method="post" runat="server">
             <div class="row">
    
                  <%--<h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" CssClass="form-control ll" OnSelectedIndexChanged="dd1_SelectedIndexChanged"  Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
      </div>
            <div class="table-responsive">
			<asp:Panel id="Panel1" runat="server">
				<TABLE id="Table2" class="table">
		<TR>
						<TD colSpan="3">History Card for The Tool&nbsp;<hr class="prettyline" />
							<asp:label id="lblMode" runat="server" ForeColor="Blue" Font-Bold="True" Font-Names="Arial" Font-Size="Smaller" Width="63px"></asp:label></TD>
					</TR>
                    <TR>
						<TD colSpan="3">
							<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></TD>
					</TR>
				</TABLE>
				<TABLE id="Table1" class="table">
					<TR>
						<TD>SelectHistoryCardNo</TD>
						<TD>:</TD>
						<TD>
							<asp:DropDownList id="cboIns" CssClass="form-control ll" runat="server" AutoPostBack="True"></asp:DropDownList></TD>
					</TR>
					<TR>
						<TD align="middle" colSpan="3">
							<asp:Button id="Submit" runat="server" CssClass="button button2" Text="Show HistoryCard Report"></asp:Button></TD>
					</TR>
					<TR>
						<TD align="middle" colSpan="3">
							<asp:Button id="Button1" runat="server" CssClass="button button2" Text="Show All History Data in Grid "></asp:Button></TD>
					</TR>
				</TABLE>
				<asp:Panel id="Panel2" runat="server">
					<TABLE id="Table4" class="table">
						<TR>
							<TD align="middle" colSpan="3">In-House Calibration Format FI - 020</TD>
						</TR>
					</TABLE>
					<TABLE id="Table5" class="table">
						<TR>
							<TD>FromDate</TD>
							<TD>:</TD>
							<TD>
								<asp:textbox id="txtFromDate" runat="server" CssClass="form-control"></asp:textbox></TD>
						</TR>
						<TR>
							<TD>ToDate</TD>
							<TD>:</TD>
							<TD>
								<asp:textbox id="txtToDate" runat="server" CssClass="form-control"></asp:textbox>
								<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" Display="Dynamic" ControlToValidate="txtToDate" ErrorMessage="*"></asp:RequiredFieldValidator></TD>
						</TR>
					</TABLE>
					<TABLE id="Table6" class="table">
						<TR>
							<TD align="middle">
								<asp:Button id="BTNInHouse" CssClass="button button2" runat="server" Text="In - House Calibration Report"></asp:Button></TD>
						</TR>
					</TABLE>
				</asp:Panel>
				<TABLE id="Table3" class="table">
					<TR>
						<TD>SelectDeletedToolHistoryCardNo</TD>
						<TD>:</TD>
						<TD>
							<asp:DropDownList id="ddlDeletedHC" CssClass="form-control ll" runat="server" AutoPostBack="True"></asp:DropDownList></TD>
					</TR>
					<TR>
						<TD align="middle" colSpan="3" rowSpan="1">
							<asp:Button id="Button2" runat="server" CssClass="button button2" Text="Show Deleted Tool History Data in Grid "></asp:Button></TD>
					</TR>
				</TABLE>
				<asp:DataGrid id="DataGrid1" runat="server" BorderStyle="None" BackColor="White" CellPadding="4" BorderWidth="1px" BorderColor="#CC9966">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
				<asp:DataGrid id="DataGrid2" runat="server" BorderStyle="None" BackColor="White" CellPadding="4" BorderWidth="1px" BorderColor="#3366CC">
					<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
				</asp:DataGrid>
			</asp:Panel>
			&nbsp;
		</form>
                 <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
