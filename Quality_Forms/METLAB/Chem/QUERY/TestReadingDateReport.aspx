<%@ Page Language="vb" AutoEventWireup="false" Codebehind="TestReadingDateReport.aspx.vb" Inherits="WebApplication2.TestReadingDateReport" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>TestReadingDateReport</title>
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
   <%--  <link rel="stylesheet" href="../../../../StyleSheet1.css" />--%>
    
	</HEAD>
	<body >
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
<!--/.Navbar -->
        <div class="container">
		<form id="Form1" method="post" runat="server">
            <div class="row" ><div class="table-responsive">
			<asp:Panel id="Panel1"  runat="server">
				<TABLE id="Table2" class="table">
					<TR>
						<TD vAlign="top" align="middle" colSpan="3">Test Results<hr class="prettyline" /></TD>
					</TR>
					<TR>
						<TD colSpan="3">
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label>
							<asp:RangeValidator id="RangeValidator1" runat="server" ErrorMessage="Enter Proper Date" ControlToValidate="txtFrom" Type="Date" MinimumValue="1/1/2003" MaximumValue="1/1/2100"></asp:RangeValidator>
							<asp:RangeValidator id="RangeValidator2" runat="server" ErrorMessage="Enter Proper Date" ControlToValidate="txtTo" Type="Date" MinimumValue="1/1/2003" MaximumValue="1/1/2100"></asp:RangeValidator>
							<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Enter From Date" ControlToValidate="txtFrom"></asp:RequiredFieldValidator>
							<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="Enter To Date" ControlToValidate="txtTo"></asp:RequiredFieldValidator></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="middle" colSpan="3">From Date :
							<asp:TextBox id="txtFrom" runat="server" CssClass="form-control"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
							To Date :
							<asp:TextBox id="txtTo" runat="server" CssClass="form-control"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:Button id="Button1" runat="server" CssClass="button button2" Text="Export Grid Data"></asp:Button></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="middle"  colSpan="3" rowSpan="1">Old&nbsp;Material 
							List&nbsp;:
							<asp:DropDownList id="cboLab" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:DropDownList></TD>
					</TR>
					<TR>
						<TD colSpan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:button id="btnSubmit" runat="server" CssClass="button button2" Text="Show Old Material Results" Height="24px" BorderStyle="Groove" Font-Size="Smaller" Font-Names="Arial"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						</TD>
					</TR>
					<TR>
						<TD vAlign="top" align="middle"  colSpan="3">New Material List :
							<asp:DropDownList id="ddlMaterial" runat="server" CssClass="form-control ll"></asp:DropDownList></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="middle"  colSpan="3">
							<asp:Button id="Button2" runat="server" CssClass="button button2" Text="Show New Material Results"></asp:Button></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="middle"  colSpan="3" rowSpan="1">
							<asp:RadioButtonList id="rblMaterial" runat="server" AutoPostBack="True" CssClass="rbl" RepeatDirection="Horizontal">
								<asp:ListItem Value="10003" Selected="True">CALCINED LIME</asp:ListItem>
								<asp:ListItem Value="10024">SLAG</asp:ListItem>
								<asp:ListItem Value="10002">SILICA SAND 45 AFS.</asp:ListItem>
								<asp:ListItem Value="10005">P. F.  RESIN</asp:ListItem>
								<asp:ListItem Value="10004">FUSED SILICA POWDER</asp:ListItem>
								<asp:ListItem Value="Daily Samples Position">Daily Samples Position</asp:ListItem>
							</asp:RadioButtonList></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="middle"  colSpan="3">
							<asp:Button id="btnRevised" runat="server" CssClass="button button2"></asp:Button></TD>
					</TR>
				</TABLE>
				<asp:DataGrid id="DataGrid1" runat="server" BorderStyle="None" CssClass="table" BorderColor="#CC9966" BorderWidth="1px" BackColor="White" CellPadding="4">
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
