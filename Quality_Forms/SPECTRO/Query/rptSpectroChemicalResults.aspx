<%@ Page Language="vb" AutoEventWireup="false" Codebehind="rptSpectroChemicalResults.aspx.vb" Inherits="WebApplication2.rptSpectroChemicalResults" Culture="en-GB" uiCulture="en-GB" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>rptSpectroChemicalResults</title>
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
    <%-- <link rel="stylesheet" href="../../../StyleSheet1.css" />--%>
	</HEAD>
	<body >
        <body>
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
            <div class="row"><div class="table-responsive">
			<asp:Panel id="Panel4" runat="server">
				<TABLE id="Table7" class="table">
					<TR>
						<TD><FONT size="5">Spectro Chemical Analysis</FONT><hr class="prettyline" /></TD>
					</TR>
				</TABLE>
				<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label>
				<TABLE id="Table8" class="table"></TABLE>
					
							<TABLE id="Table4" class="table">
								<TR>
									<TD>FromDate</TD>
									<TD>:</TD>
									<TD>
										<asp:textbox id="txtFromDate" runat="server" CssClass="form-control"></asp:textbox></TD>
									<TD>ToDate</TD>
									<TD>:</TD>
									<TD>
										<asp:textbox id="txtToDate" runat="server" CssClass="form-control"></asp:textbox></TD>
								</TR>
							</TABLE>
							<TABLE id="Table2"  class="table">
								<TR>
									<TD style="WIDTH: 21px" vAlign="top" align="middle" colSpan="3">
										<asp:RadioButtonList id="rdoProduct" runat="server" CssClass="rbl">
											<asp:ListItem Value="1" Selected="True">Wheel</asp:ListItem>
											
										</asp:RadioButtonList></TD>
                                    <!-- <asp:ListItem Value="2">Axle</asp:ListItem>
											<asp:ListItem Value="3">Process Count</asp:ListItem>
											<asp:ListItem Value="4">Magna FL &amp; OffLoads</asp:ListItem>  REMOVED-->
								</TR>
							</TABLE>
							<TABLE id="Table1" class="table">
								<TR>
									<TD align="middle">
										<asp:Button id="btnProductNo" runat="server" Text="Show DateWise data" CssClass="button button2"></asp:Button></TD>
								</TR>
							</TABLE>
						
							<TABLE id="Table5" class="table">
								<TR>
									<TD>FromHeat</TD>
									<TD>
										<asp:TextBox id="TextBox1" runat="server" CssClass="form-control"></asp:TextBox></TD>
									<TD>ToHeat</TD>
									<TD>
										<asp:TextBox id="TextBox2" runat="server" CssClass="form-control"></asp:TextBox></TD>
								</TR>
							</TABLE>
							<TABLE id="Table3" class="table">
								<TR>
									<TD align="middle" colSpan="3">
										<asp:RadioButtonList id="rblType" runat="server" CssClass="rbl">
											<asp:ListItem Value="1" Selected="True">JMP Chemistry</asp:ListItem>
											
										</asp:RadioButtonList></TD>
                                    <!-- <asp:ListItem Value="2">MR Processed</asp:ListItem>
											<asp:ListItem Value="3">MR Pending Wheels</asp:ListItem>
											<asp:ListItem Value="4">Completed Heats Summary</asp:ListItem>
											<asp:ListItem Value="5">Pending Wheels at WFPS</asp:ListItem>
											<asp:ListItem Value="6">XC 624 of completly processed heats</asp:ListItem> -- REMOVED-->
								</TR>
							</TABLE>
							<TABLE id="Table10" class="table">
								<TR>
									<TD align="middle">
										<asp:Button id="Button1" runat="server" Text="Show HeatWise Results" CssClass="button button2"></asp:Button></TD>
								</TR>
							</TABLE>
						
                <table>
                    <tr>
                        <td>Select Type Of Test</td>
                        <td><asp:RadioButtonList ID="testrbl" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rbl">
                            <asp:ListItem Selected="True" Value="0">METLAB Testing</asp:ListItem>
                              <asp:ListItem Value="1">SPECTRO Testing</asp:ListItem>
                              <asp:ListItem Value="2">MECHANICAL Testing</asp:ListItem>
                              <asp:ListItem Value="3">NDT Testing</asp:ListItem>
                            </asp:RadioButtonList></td>
                    </tr>
                    <tr>
                        <td>Select Lab Working Shift</td>
                        <td><asp:RadioButtonList ID="shiftrbl" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rbl">
                            <asp:ListItem Selected="True" Value="A">A</asp:ListItem>
                            <asp:ListItem Value="B">B</asp:ListItem>
                            <asp:ListItem Value="C">C</asp:ListItem>
                            <asp:ListItem Value="G">G</asp:ListItem>
                            </asp:RadioButtonList></td>
                    </tr>
                    <tr>
                        <td>Select Status Of Testing</td>
                        <td><asp:RadioButtonList ID="statusrbl" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rbl">
                            <asp:ListItem Selected="true" Value="P">Partially</asp:ListItem>
                            <asp:ListItem Value="F">Fully</asp:ListItem>
                            </asp:RadioButtonList></td>
                    </tr>
                    <tr>
                        <td colspan="2"><asp:Button runat="server" ID="labbtn" Text=" Generate Lab Number" CssClass="button button2" />
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lab" runat="server" Text="Lab No" Visible="false"></asp:Label></td>
                        <td><asp:TextBox ID="labtxt" runat="server" Visible="false" MaxLength="18" CssClass="form-control"></asp:TextBox></td>
                    </tr>
                </table>
				
				<TABLE id="Table9" class="table">
					<TR>
						<TD>
							<asp:Button id="Button2" runat="server" Text="Export to Excel" CssClass="button button2"></asp:Button></TD>
					</TR>
				</TABLE>
				<asp:datagrid id="DataGrid1" runat="server" BackColor="White" CellPadding="4" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:datagrid>
			</asp:Panel>
                </div></div>
		</form>
            </div>
             <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
