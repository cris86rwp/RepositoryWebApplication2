<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SandTestResults.aspx.vb" Inherits="WebApplication2.SandTestResults" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>SandTestResults</title>
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
    <%-- <link rel="stylesheet" href="../../../../StyleSheet1.css" />--%>
    
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
            <div class="row"><div class="table-responsive">
			<asp:Panel id="Panel1"  runat="server">
				<TABLE id="Table2" class="table">
					<TR>
						<TD colSpan="9"><FONT size="4">Sand Sample Results</FONT><hr class="prettyline" /></TD>
					</TR>
					<TR>
						<TD colSpan="9">
							<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></TD>
					</TR>
					<TR>
						<TD>SendDate</TD>
						<TD>:</TD>
						<TD>
							<asp:textbox id="txtSentDate" runat="server" CssClass="form-control"  AutoPostBack="True"></asp:textbox></TD>
						<TD>Shift</TD>
						<TD>:</TD>
						<TD>
							<asp:radiobuttonlist id="rblShift" runat="server" CssClass="rbl" AutoPostBack="True" RepeatDirection="Horizontal" RepeatLayout="Flow">
								<asp:ListItem Value="A" Selected="True">A</asp:ListItem>
								<asp:ListItem Value="B">B</asp:ListItem>
								<asp:ListItem Value="C">C</asp:ListItem>
                                <asp:ListItem Value="G">G</asp:ListItem>
							</asp:radiobuttonlist></TD>
						<TD>TestedBy</TD>
						<TD>:</TD>
						<TD>
							<asp:textbox id="txtOperator" runat="server" CssClass="form-control"></asp:textbox></TD>
					</TR>
				</TABLE>
				<TABLE id="Table3" class="table">
					<TR>
						<TD>
							<asp:RadioButtonList id="rblBatch" runat="server" CssClass="rbl" AutoPostBack="True" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:RadioButtonList></TD>
					</TR>
				</TABLE>
				<TABLE id="Table4" class="table">
					<TR>
						<TD>CTS</TD>
						<TD>:</TD>
						<TD>
							<asp:textbox id="txtCTS" runat="server" CssClass="form-control"></asp:textbox></TD>
						<TD>HTS</TD>
						<TD>:</TD>
						<TD>
							<asp:textbox id="txtHTS" runat="server" CssClass="form-control"></asp:textbox></TD>
						<TD>SP</TD>
						<TD>:</TD>
						<TD>
							<asp:textbox id="txtSP" runat="server" CssClass="form-control"></asp:textbox></TD>
					</TR>
					<TR>
						<TD>Result</TD>
						<TD>:</TD>
						<TD>
							<asp:RadioButtonList id="rblResult" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rbl">
								<asp:ListItem Value="P" Selected="True">P</asp:ListItem>
								<asp:ListItem Value="R">R</asp:ListItem>
							</asp:RadioButtonList></TD>
						<TD>ExpectedTestDt</TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="txtExpectedTestDate" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>TestedDt</TD>
						<TD>:</TD>
						<TD>
							<asp:textbox id="txtTestedDate" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox></TD>
					</TR>
					<TR>
						<TD vAlign="top" noWrap align="middle" colSpan="9">
							<asp:Button id="btnSave" runat="server" Text="Save" CssClass="button button2"></asp:Button></TD>
					</TR>
				</TABLE>
				<asp:DataGrid id="DataGrid1" runat="server" CellPadding="4" CssClass="table" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966">
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
