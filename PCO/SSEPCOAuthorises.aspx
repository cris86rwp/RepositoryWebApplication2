<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SSEPCOAuthorises.aspx.vb" Inherits="WebApplication2.SSEPCOAuthorises" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>SSEPCOAuthorises</title>
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

        <%-- <link rel="stylesheet" href="../StyleSheet1.css" />--%>
	</head>
	
    <body>
        <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
  <a class="navbar-brand p-0" href="#"><img src="../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent-333"
    aria-controls="navbarSupportedContent-333" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>
  <div class="collapse navbar-collapse " id="navbarSupportedContent-333" >
      <ul class="navbar-nav ml-auto navbar-center">
         <li class="nav-item" style="font-weight: bold">
             <h1 style="color:white; font-size:30px; margin-left:325px; margin-top:5px">Rail Wheel Plant, Bela</h1> 
       
         </li>
          </ul>
    <ul class="navbar-nav ml-auto  navbar-right">
        <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home " style="font-size:30px;"></i>
        </a></li>

       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out" style="font-size:30px;"></i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
          <%--<img src="../../../CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="50" style="border-width: 34px; background-position: 5px 5px; width:50px;margin-top:3px;border-color:white; border-width:50px"/>
        --%><img src="../NewFolder1/CRIS-Recruitment.jpg" height="45" style="border-radius:43%"/>
       </a>
      </li>
     </ul>
      
  </div>
</nav>
<!--/.Navbar -->

         
         <div class="container">
              <div class="row">
                <div class="table-responsive">

		<form id="Form1" method="post" runat="server">
           <%-- <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
			<table id="Table1" class="table">
				<TR>
					<TD align="middle"><h2>AUTHORISATION FOR UPDATING UNDER 
								PCOPCO LOGIN</h2><hr class="prettyline" /></TD>
				</TR>
				<TR>
					<TD><asp:label id="lblMessage" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD><U><STRONG><FONT color="#ff6699">Please Note:</FONT></STRONG></U>
						<DIV><STRONG><FONT color="#ff3399">All 
									necessary approvals of Competent Authorities, on paper/file, to be taken by 
									SSE/PCO and then Allow Inputs which can be done under&nbsp;login PCOPCO.&nbsp; 
									You may also input authorisation remarks here under:</FONT></STRONG></DIV>
						<P><asp:textbox id="txtAuthorisationRemarks" runat="server" CssClass="form-control" MaxLength="5000" TextMode="MultiLine"></asp:textbox>&nbsp;</P>
						<P>Tick to Authorise following activities:</P>
					</TD>
				</TR>
				<tr>
					<TD><asp:checkboxlist id="chkAutorisableItems" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
							<asp:ListItem Value="Bill of Material - Wheel Shop - Melting">Bill of Material - Wheel Shop - Melting</asp:ListItem>
							<asp:ListItem Value="Bill of Material - Wheel Shop - Moulding">Bill of Material - Wheel Shop - Moulding</asp:ListItem>
							<asp:ListItem Value="Bill of Material - Wheel Shop - WFP Shop">Bill of Material - Wheel Shop - WFP Shop</asp:ListItem>
							<asp:ListItem Value="RWF Production Targets">RWF Production Targets</asp:ListItem>
							<asp:ListItem Value="Rly Board Targets">Rly Board Targets</asp:ListItem>
						</asp:checkboxlist></TD>
				</tr>
				<tr>
					<td><asp:button id="BtnAllow" runat="server" Text="Allow Inputs" CssClass="button button2"></asp:button></td>
				</tr>
			</table>
			&nbsp;
		</form>
                   </div></div></div>
        <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</html>
