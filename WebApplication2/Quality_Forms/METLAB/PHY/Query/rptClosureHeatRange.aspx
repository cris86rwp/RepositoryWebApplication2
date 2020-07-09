<%@ Page Language="vb" AutoEventWireup="false" Codebehind="rptClosureHeatRange.aspx.vb" Inherits="WebApplication2.rptClosureHeatRange" Culture="en-GB" uiCulture="en-GB" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>rptClosureHeatRange</title>
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
    <%-- <link rel="stylesheet" href="../../../../StyleSheet1.css" />--%>
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
<!--/.Navbar -->
        <div class="container">
		<form id="Form1" method="post" runat="server">
            <div class="row"><div class="table-responsive">
			<asp:Panel id="Panel1"  runat="server">
				<TABLE id="Table1" class="table">
					<TR>
						<TD colSpan="3"><FONT size="5">Heat Range &amp; Closure</FONT><hr class="prettyline" /></TD>
					</TR>
					<TR>
						<TD colSpan="3">
							<asp:label id="lblMessage" runat="server" ></asp:label></TD>
					</TR></TABLE>
					
							<TABLE id="Table2" class="table">
								<TR>
									<TD >FromDate</TD>
									<TD>:</TD>
									<TD>
										<asp:textbox id="txtFromDate" runat="server" CssClass="form-control"></asp:textbox></TD>
								</TR>
								<TR>
									<TD >ToDate</TD>
									<TD>:</TD>
									<TD>
										<asp:textbox id="txtToDate" runat="server" CssClass="form-control"></asp:textbox>
										<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtToDate" Display="Dynamic"></asp:RequiredFieldValidator></TD>
								</TR>
							</TABLE>
							<asp:CustomValidator id="CustomValidator1" runat="server" ErrorMessage="CustomValidator" ControlToValidate="txtToDate"></asp:CustomValidator>
							<asp:panel id="pnlProductNo" runat="server" >
								<TABLE id="Table3" class="table">
									<TR>
										<TD vAlign="top" align="middle">
											<asp:RadioButtonList id="rblChoice" runat="server" CssClass="rbl" RepeatLayout="Flow" RepeatDirection="Horizontal">
												<asp:ListItem Value="SentDateWise" Selected="True">SentDateWise</asp:ListItem>
												<asp:ListItem Value="TestDateWise">TestDateWise</asp:ListItem>
											</asp:RadioButtonList></TD>
									</TR>
									<TR>
										<TD vAlign="top" align="middle">
											<asp:DropDownList id="ddlWheelType" runat="server" CssClass="form-control ll"></asp:DropDownList></TD>
									</TR>
									<TR>
										<TD vAlign="top" align="middle">
											<asp:Button id="btnProductNo" runat="server" Text="Submit" CssClass="button button2"></asp:Button></TD>
									</TR>
								</TABLE>
							</asp:panel>
							<asp:Button id="btnDesp" runat="server" Text="Despatched Wheels Status " CssClass="button button2"></asp:Button>
				<asp:datagrid id="DataGrid1" runat="server" BackColor="White" CssClass="table" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
					<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
				</asp:datagrid>
			</asp:Panel>
                </div></div>
		</form>
            </div>
         <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
