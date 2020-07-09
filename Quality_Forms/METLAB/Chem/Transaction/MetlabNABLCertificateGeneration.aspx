<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MetlabNABLCertificateGeneration.aspx.vb" Inherits="WebApplication2.MetlabNABLCertificateGeneration" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>MetlabNABLCertificateGeneration</title>
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
    
	    <style type="text/css">
            .auto-style1 {
                height: 50px;
            }
        </style>
    
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
			<asp:Panel id="Panel1"  runat="server" Height="563px">

				<TABLE id="Table2" class="table">
					<TR>
						<TD><FONT size="5">METLAB NABL CERTIFICATE GENERATION </FONT><hr class="prettyline" /></TD>
					</TR>
				</TABLE>

 <table id="table1" class="table">
		         <TR>
						<TD >Enter Lab Number </TD>						
						<TD > <asp:TextBox id="txtLabnumber" Width="160px" runat="server" CssClass="form-control"></asp:TextBox></TD>
            </TR>

             <TR> 
                        <TD class="auto-style1" > Select NABL Type </TD>
                        <td><asp:RadioButtonList ID="rblNABLType" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rbl">
                       <asp:ListItem Value="F" Selected="True" >Fully</asp:ListItem>
                         <asp:ListItem Value="P" >Partial</asp:ListItem>
                        </asp:RadioButtonList></td>
             </TR>

             <TR> 			<TD class="auto-style1" > Select Test Type </TD>
                        <td><asp:RadioButtonList ID="rblTestType" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rbl">
                       <asp:ListItem Value="P" Selected="True" >Physical</asp:ListItem>
                         <asp:ListItem Value="C" >Chemical</asp:ListItem>
                         <asp:ListItem Value="PC" >Physical & Chemical</asp:ListItem>
                            <asp:ListItem Value="W" >Wheel Sample</asp:ListItem>
                        </asp:RadioButtonList></td>
            </TR>

     					</TR>
                 <td align="middle" colspan="6">
                     <asp:Button ID="btnUpdate" runat="server" CssClass="button button2" Text="Generate Certificate" />
                     <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                 </td>
              <TR>
					<TD style="HEIGHT: 1px" width="100%" colSpan="3"><asp:label id="LblMessage" runat="server" Font-Bold="True" Font-Size="Medium" Height="12px" Width="655px"></asp:label></TD>
				</TR>
				</TABLE>
			</asp:Panel>
                </div></div>
		</form>

            </div>
         <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
