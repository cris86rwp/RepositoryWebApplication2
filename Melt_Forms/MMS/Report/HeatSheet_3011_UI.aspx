<%@ Page Language="vb" AutoEventWireup="false" Codebehind="HeatSheet_3011_UI.aspx.vb" Inherits="WebApplication2.HeatSheet_3011_UI" %>
<!DOCTYPE html >
<html ="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>HeatSheet_3011_UI</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR"/>
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
         <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"/>
         <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
  <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
          <link type="text/css" rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
          
          <%--<link href="../../../StyleSheet1.css" rel="stylesheet" />--%>

	  <%--  <style type="text/css">
            .auto-style1 {
                width: 1476px;
            }
        </style>--%>
	</head>
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
        <div class="container">
		<form id="Form1" method="post" runat="server">
              <div class="row">
    
                  <%--<h4>&nbsp&nbsp&nbspSelect Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px" >
                     
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
                </div>
			<asp:Panel id="Panel1" runat="server" >
                    <div class ="row">
                <div class="table-responsive">
                <%--style="Z-INDEX: 100; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server" Width="307px" Height="106px"--%>
				<table id="Table1" class="table">
                    <%--style="WIDTH: 322px; HEIGHT: 4px" cellSpacing="1" cellPadding="1" width="322"--%>
					<tr>
						<td colspan="4" style=" color: #FFFFFF;">STEEL MELTING-HEAT SHEET - FW - 301<hr class="prettyline"/></td>
					</tr>
				</table>
				<asp:Label id="lblerr" runat="server" ForeColor="Red"></asp:Label>
				<table id="Table6" class="table">
                    <%--style="HEIGHT: 32px" cellSpacing="1" cellPadding="1" width="167"--%>
					<tr>
						<td style=" ">EnterHeatNo:</td>
						<td>
							<asp:textbox id="txtFromHeat" runat="server" CssClass="form-control" BorderStyle="Groove"></asp:textbox></td>
						<td>
							<asp:RequiredFieldValidator id="rfvld1" runat="server" Display="Dynamic" ControlToValidate="txtFromHeat">*</asp:RequiredFieldValidator></td>
					</tr>
				</table>
				<table id="Table7" class="table">
                  <%--  style="WIDTH: 219px; HEIGHT: 32px" cellSpacing="1" cellPadding="1" width="219"--%>
					<tr>
						<td align="center">
							<asp:button id="BtnShow" runat="server" CssClass="button button2"   Text="Show 301 Report "></asp:button></td>
                       <%-- Height="24px" Width="144px"--%>
					</tr>
				</table>
				<table id="Table2" class="table" >
					<tr>
						<td align="center"   style=" color: #FFFFFF;" colspan="3">Summary Of Off Heats<hr class="prettyline"/></td>
					</tr>
					<tr>
						<td style=" ">HeatNumber</td>
						<td style=" ">:</td>
						<td>
							<asp:TextBox id="txtHeatNumber" runat="server" CssClass="form-control"></asp:TextBox></td>
					</tr>
					<tr>
						<td align="center" colspan="3">
							<asp:Button id="btnSubmit" CssClass="button button2" runat="server" Text="Off Heats Report"></asp:Button></td>
					</tr>
				</table>
                	<table id="Table4" class="table">
				<%--<TABLE id="Table3"  Style="background-color:#ff99cc" border="1">--%>
                    <%--style="WIDTH: 271px; HEIGHT: 51px" cellSpacing="1" cellPadding="1" width="271"--%>
					<tr>
						<td  align="center"  style="font-weight: bold; color: #FFFFFF;" colspan="6">Melt Room 301 Form (Heat Sheets)<hr class="prettyline"/></td>
					</tr>
					<tr>
						<td  align="left"  colspan="6" style=" color: #FFFFFF;">Enter From Heat and To Heat.</td>
					</tr>
				<%--</TABLE>--%>
			
                   <%-- style="WIDTH: 287px; HEIGHT: 32px" cellSpacing="1" cellPadding="1" width="287"--%>
					<tr>
						<td style=" ">FromHeat</td>
						<td>
							<asp:textbox id="txtFromHt" runat="server" CssClass="form-control" BorderStyle="Groove"></asp:textbox></td>
						<td>
							<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" Display="Dynamic" ControlToValidate="txtFromHt">*</asp:RequiredFieldValidator></td>
						<td style=" ">ToHeat</td>
						<td>
							<asp:textbox id="txtToHt" CssClass="form-control" runat="server"  BorderStyle="Groove"></asp:textbox></td>
						<td>
							<asp:RequiredFieldValidator id="rfvld2" runat="server" Display="Dynamic" ControlToValidate="txtToHt">*</asp:RequiredFieldValidator></td>
					</tr>
				</table>
				<table id="Table5"class="table" >
					<tr>
						<td align="center">
							<asp:button id="Button1" runat="server" CssClass="button button2"    Text="Show Heat Sheets Report"></asp:button></td>
					</tr>
				</table>
                    </div>
                        </div>
			</asp:Panel>
		</form>
            </div>
             <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</html>
