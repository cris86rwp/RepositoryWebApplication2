<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MouldRoomFormatsReport.aspx.vb" Inherits="WebApplication2.MouldRoomFormatsReport" Culture="en-GB" uiCulture="en-GB" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mould Room Format</title>
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

   <%-- <link href="../../StyleSheet1.css" rel="stylesheet" />--%>

 
    <style type="text/css">
        .auto-style1 {
            display: block;
            font-size: 14px;
            font-weight: 400;
            line-height: 1.42857143;
            color: #555;
            background-clip: padding-box;
            border-radius: 4px;
            transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
            -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
            box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
            -webkit-transition: border-color ease-in-out .15s, -webkit-box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
            border: 1px solid #ccc;
            margin-top: 51;
            padding: 6px 12px;
            background-color: #fff;
            background-image: none;
            margin-left:500px;
        }
    </style>

 
</head>
	<body bgColor="#99ccff" MS_POSITIONING="GridLayout">
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
     <div class="container">
            <div class="row">
                <div class="table-responsive">


		<form id="Form1" method="post" runat="server">
         <%--   <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
			<asp:panel id="Panel1" runat="server">
				<TABLE id="Table1" class="table">
					<TR>
						<TD>Mould Room Formats</TD>
					</TR>
					<TR>
						<TD>
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></TD>
					</TR>
					<TR>
						<TD>Heat Number :</TD>
						<TD>
							<asp:textbox id="txtHeatNumber" runat="server" CssClass="form-control"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="middle" colSpan="3">
							<asp:RadioButtonList id="rblType" runat="server" RepeatLayout="Flow" CssClass="rbl">
								<asp:ListItem Value="1" Selected="True">HUB CUTTER FORMAT
								</asp:ListItem>
								<asp:ListItem Value="2">NF RECORD FORMAT</asp:ListItem>
								<asp:ListItem Value="3">CORE BAKING FORMAT</asp:ListItem>
								<asp:ListItem Value="4">COPE SPRAY FORMAT</asp:ListItem>
								<asp:ListItem Value="5">DRAG  SPRAY FORMAT</asp:ListItem>
								<asp:ListItem Value="6">DRAG Inspection</asp:ListItem>
								<asp:ListItem Value="7">Offload Format</asp:ListItem>
							</asp:RadioButtonList></TD>
					</TR>
					<TR>
						<TD>
							<asp:Button id="btnShow" runat="server" Text="Show Report" CssClass="auto-style1"></asp:Button></TD>
					</TR>
				</TABLE>
			</asp:panel>
		</form>
                     </div>
                </div>
            </div>
     <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</html>
