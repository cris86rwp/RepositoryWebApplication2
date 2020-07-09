<%@ Page Language="vb" AutoEventWireup="false" Codebehind="LadleWeights.aspx.vb" Inherits="WebApplication2.LadleWeights" %>
<!DOCTYPE HTML >
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>LadleWeights</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR"/>
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
          <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css"/>
  <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js"></script>
  <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js"></script>

        
    <link type="text/css" rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
   
         <%-- <link rel="stylesheet" href="../../StyleSheet1.css" />--%>
	</head>
	<body>
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
          <i class="fab glyphicon glyphicon-home "style="font-size:30px;" ></i>
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
          
			<asp:panel id="Panel1" runat="server">
                  <div class="row">
                <div class="table-responsive">
				<table id="Table1" class="table">
					<tr>
						<td colspan="3">Ladle Weight Entry -
							<asp:Label id="lblGroupName" runat="server"></asp:Label>
							<asp:Label id="lblGoup" runat="server"></asp:Label><hr class="prettyline"/></td>
					</tr>
					<tr>
						<td colspan="3">
							<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></td>
					</tr>
					<tr>
						<td>HeatNumber</td>
						<td>:</td>
						<td>
							<asp:textbox id="txtHeat_number" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox>
							<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtHeat_number" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></td>
					</tr>
				</table>
				<asp:Panel id="pnlMould" runat="server">
					<table id="Table2" class="table">
						<tr>
							<td>Weight of Ladle&nbsp;after Pouring (W3)</td>
							<td>:</td>
							<td>
								<asp:textbox id="txtw3" runat="server" CssClass="form-control"></asp:textbox></td>
						</tr>
						<tr>
							<td>Weight W1&nbsp;:&nbsp;
								<asp:Label id="lblw1" runat="server"></asp:Label></td>
							<td colspan="2">Weight W2&nbsp;:&nbsp;
								<asp:Label id="lblw2" runat="server"></asp:Label></td>
						</tr>
					</table>
				</asp:Panel>
				<asp:Panel id="pnlMelt" runat="server">
					<table id="Table3" class="table">
						<tr>
							<td>Weight of Empty Ladle (W1) (New)</td>
							<td>:</td>
							<td>
								<asp:textbox id="txtw1" runat="server" CssClass="form-control"></asp:textbox></td>
						</tr>
						<tr>
							<td>Weight After Tapping (W2)</td>
							<td>:</td>
							<td>
								<asp:textbox id="txtw2" runat="server" CssClass="form-control"></asp:textbox></td>
						</tr>
					</table>
				</asp:Panel>
				<table id="Table4" class="table">
					<tr>
						<td  align="center">
							<asp:button id="btnSave" runat="server"  Text="Save" CssClass="button button2"  ></asp:button></td>
					</tr>
				</table>
                    </div>
                      </div>
			</asp:panel></form>
            </div>
          <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</html>
