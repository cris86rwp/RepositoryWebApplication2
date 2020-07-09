<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MouldRoomHeatPosition.aspx.vb" Inherits="WebApplication2.MouldRoomHeatPosition" Culture="en-GB" uiCulture="en-GB" %>
<!DOCTYPE HTML >
<HTML>
	<HEAD runat="server">
		<title>MouldRoomHeatPosition</title>
		<META content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<META content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">

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
        <%--<link rel="stylesheet" href="StyleSheet1.css" />--%>

	</HEAD>
	<BODY >
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
		<FORM id="Form1" method="post" runat="server">
            <div class="row">
    
                  <%--<h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
      </div>
            <div class="row">
                <div class="table-responsive">
			<asp:panel id="Panel1"  runat="server" >
				
							<TABLE id="Table1" class="table">
								<TR>
									<TD colSpan="6"><FONT size="5">MR Daily Heat Position</FONT></TD>
								</TR>
								<TR>
									<TD colSpan="6">
										<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></TD>
								</TR>
								<TR>
									<TD >Heat</TD>
									<TD>:</TD>
									<TD >WC</TD>
									<TD>Itemp</TD>
									<TD>Ftemp</TD>
									<TD>&nbsp;</TD>
								</TR>
								<TR>
									<TD >
										<asp:TextBox id="Heat" runat="server"  AutoPostBack="True" CssClass="form-control"></asp:TextBox></TD>
									<TD >&nbsp;</TD>
									<TD >
										<asp:Label id="WC" runat="server"></asp:Label>&nbsp;</TD>
									<TD >
										<asp:Label id="Itemp" runat="server"></asp:Label>&nbsp;</TD>
									<TD>
										<asp:Label id="Ftemp" runat="server"></asp:Label>&nbsp;</TD>
									<TD >&nbsp;</TD>
								</TR>
								<TR>
									<TD >Remarks1(&lt;32cast)</TD>
									<TD>:</TD>
									<TD colSpan="4">
										<asp:TextBox id="Remarks1" runat="server" CssClass="form-control"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD >Tapping Time</TD>
									<TD>&nbsp;</TD>
									<TD >Date</TD>
									<TD>
										<asp:TextBox id="MPILDate" runat="server" CssClass="form-control"></asp:TextBox></TD>
									<TD>Time</TD>
									<TD>
										<asp:TextBox id="MPILTimeHr" runat="server" CssClass="form-control"></asp:TextBox>:
										<asp:textbox id="MPILTimeMin" runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="2"></asp:textbox></TD>
								</TR>
								<TR>
									<TD >RunOuts
										<asp:TextBox id="RunOuts" runat="server" CssClass="form-control"></asp:TextBox></TD>
									<TD>&nbsp;&nbsp;</TD>
									<TD >LiTank</TD>
									<TD>PST</TD>
									<TD>PET</TD>
									<TD>TPT</TD>
								</TR>
								<TR>
                                    <td>XC 50
                                        <asp:TextBox ID="txtxc50" runat="server" CssClass="form-control"></asp:TextBox></td></tr>
                                <tr>
									<TD >RunBacks
										<asp:TextBox id="RunBacks" runat="server" CssClass="form-control"></asp:TextBox></TD>
									<TD>&nbsp;</TD>
									<TD >
										<asp:Label id="LiTank" runat="server"></asp:Label>&nbsp;</TD>
									<TD>
										<asp:Label id="PST" runat="server"></asp:Label>&nbsp;</TD>
									<TD>
										<asp:Label id="PET" runat="server"></asp:Label>&nbsp;</TD>
									<TD>
										<asp:Label id="TPT" runat="server"></asp:Label>&nbsp;</TD>
								</TR>
                                <tr><td>Overflow<asp:TextBox ID="txtOverflow" runat="server" CssClass="form-control"></asp:TextBox></td></tr>
								<TR>
									<TD >Remarks2(&gt;45min)</TD>
									<TD>:</TD>
									<TD colSpan="4">
										<asp:TextBox id="Remarks2" runat="server" CssClass="form-control"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD>&nbsp;PrgDly(&gt;45)</TD>
									<TD>&nbsp;</TD>
									<TD >
										<asp:Label id="PrgDly" runat="server"></asp:Label>&nbsp;</TD>
									<TD colSpan="2">PrgStrDly(&gt;8)</TD>
									<TD>
										<asp:Label id="PrgStrDly" runat="server"></asp:Label>&nbsp;</TD>
								</TR>
								<TR>
									<TD >Reamrks3(PrgStDly)</TD>
									<TD>:</TD>
									<TD colSpan="4">
										<asp:TextBox id="Remarks3" runat="server" CssClass="form-control"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD vAlign="top" align="center" colSpan="6">
										<asp:Button id="Save" runat="server" Text="Save" CssClass="button button2"></asp:Button></TD>
								</TR>
							</TABLE>
						
							<TABLE id="Table3" class="table">
								<TR>
									<TD>FromHeat</TD>
									<TD>:</TD>
									<TD>
										<asp:TextBox id="frHt" runat="server" CssClass="form-control"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD>ToHeat</TD>
									<TD>:</TD>
									<TD>
										<asp:TextBox id="toHt" runat="server" CssClass="form-control"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD vAlign="top" align="center" colSpan="3">
										<asp:Button id="btnShow" runat="server" Text="Show Details" CssClass="button button2"></asp:Button></TD>
								</TR>
								<TR>
									<TD vAlign="top" align="center" colSpan="3">
										<asp:Button id="btnReport" runat="server" Text="Report" CssClass="button button2"></asp:Button></TD>
								</TR>
							</TABLE>
							<asp:Panel id="Panel2" runat="server">
								<TABLE id="Table4" class="table">
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
											<asp:textbox id="txtToDate" runat="server" CssClass="form-control"></asp:textbox></TD>
									</TR>
									<TR>
										<TD vAlign="top" align="center" colSpan="3">
											<asp:Button id="btnDateWise" runat="server" Text="Date Wise Report" CssClass="button button2"></asp:Button></TD>
									</TR>
								</TABLE>
							</asp:Panel></TD>
				
				
				<asp:DataGrid id="DataGrid1" runat="server" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" CssClass="table">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
			</asp:panel></div></div></FORM>
             </div>
          <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</BODY>
</HTML>
