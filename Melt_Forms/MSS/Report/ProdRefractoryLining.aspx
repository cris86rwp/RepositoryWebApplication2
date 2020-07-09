<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ProdRefractoryLining.aspx.vb" Inherits="WebApplication2.ProdRefractoryLining" %>
<!DOCTYPE HTML PUBLIC >
<html>
	<head runat="server">
		<title>ProdRefractoryLining</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0"/>
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5 "/>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css"/>

        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js"></script>
  <link type="text/css" rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
        <%--<link rel="stylesheet" href="../../../StyleSheet1.css" />--%>

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
<!--/.Navbar -->
        <div class="container">

		<form id="Form1" method="post" runat="server">

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

			<asp:Panel id="pnlMain" runat="server">

                  <div class="row">
            <div class="table-responsive">

				<table id="Table1" class="table">
					<tr>
						<td colSpan="3">Refractory Lining Reports<hr class="prettyline" /></td>
					</tr>
					<tr>
						<td colspan="3">
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></td>
					</tr>
					<tr>
						<td>WorkCompleted :</td>
						<td>FromDate</td>
						<td>ToDate</td>
					</tr>
					<tr>
						<td></td>
						<td>
							<asp:textbox id="txtFrDt" runat="server" CssClass="form-control"></asp:textbox></td>
						<td>
							<asp:textbox id="txtToDt" runat="server"  CssClass="form-control"></asp:textbox></td>
					</tr>
				</table>
				<table id="Table3" class="table"  >
					<tr>
						<td>
							<asp:RadioButtonList id="rblLiningType" runat="server" AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl"></asp:RadioButtonList></td>
					</tr>
				</table>
				<table id="Table7" class="table" >
					<tr>
						<td colspan="3">PONumber</td>
						<td>:</td>
						<td>
							<asp:DropDownList id="ddlPONo" runat="server" CssClass="form-control ll"></asp:DropDownList></td>
					</tr>
					<tr>
						<td  colspan="5" >
							<asp:Button id="btnGen" runat="server"  Text="Generate Data" CssClass="button button2"></asp:Button></td>
					</tr>
					<tr>
						<td align="center" colspan="5">
							<asp:Button id="btnPONo" runat="server" Text="Show PO Report" CssClass="button button2"></asp:Button></td>
					</tr>
				</table>
				<asp:Panel id="pnl1" runat="server">
					<table id="Table2" class="table" >
						<tr>
							<td colspan="3">Furnace:
								<asp:RadioButtonList id="rblFur" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl">
									<asp:ListItem Value="A" Selected="True">A</asp:ListItem>
									<asp:ListItem Value="B">B</asp:ListItem>
									<asp:ListItem Value="C">C</asp:ListItem>
									<asp:ListItem Value="ALL">ALL</asp:ListItem>
								</asp:RadioButtonList></td>
						</tr>
						<tr>
							<td colspan="3">
								<asp:RadioButtonList id="rblFWPType" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl">
									<asp:ListItem Value="1" Selected="True">Lining Heat Summary</asp:ListItem>
								</asp:RadioButtonList></td>
						</tr>
						<tr>
							<td align="center" colspan="3">
								<asp:Button id="btnFWP" runat="server" Text="Show Report" CssClass="button button2"></asp:Button></td>
						</tr>
					</table>
					<table id="Table4" class="table" >
						<tr>
							<td colspan="3">FurnaceLiningNo</td>
							<td>:</td>
							<td colspan="5">
								<asp:DropDownList id="ddlLiningNo" runat="server" CssClass="form-control ll"></asp:DropDownList></td>
						</tr>
						<tr>
							<td colspan="5">
								<asp:Button id="btnLiningNo" runat="server" Text="Furnace Lining No Register" CssClass="button button2"></asp:Button></td>
						</tr>
					</table>
					<table id="Table11" class="table" >
						<tr>
							<td>LOANo</td>
							<td>:</td>
							<td>
								<asp:DropDownList id="ddlLOANo" runat="server" CssClass="form-control ll"></asp:DropDownList></td>
						</tr>
						<tr>
							<td align="center" colspan="3">
								<asp:Button id="btnLOANo" runat="server" Text="Show LOA Details" CssClass="button button2"></asp:Button></td>
						</tr>
					</table>
				</asp:Panel>
				<asp:Panel id="pnl3" runat="server">
					<table id="Table8" class="table">
						<tr>
							<td >Ladle No</td>
							<td >:</td>
							<td>
								<asp:RadioButtonList id="rblLiningItemNo" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl"></asp:RadioButtonList></td>
						</tr>
					</table>
					<table id="Table6" class="table" >
						<tr>
							<td colspan="3">
								<asp:RadioButtonList id="rblLRLType" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl">
									<asp:ListItem Value="1" Selected="True">Ladle Lining Summary</asp:ListItem>
								</asp:RadioButtonList></td>
						</tr>
						<tr>
							<td align="center" colspan="3">
								<asp:Button id="btnLRL" runat="server" Text="Show Report" CssClass="button button2"></asp:Button></td>
						</tr>
					</table>
					<table id="Table5" class="table" >
						<tr>
							<td>LadleLiningNo</td>
							<td>:</td>
							<td>
								<asp:DropDownList id="ddlLiningNo3" runat="server" CssClass="form-control ll"></asp:DropDownList></td>
						</tr>
						<tr>
							<td colspan="3">
								<asp:Button id="btnlLiningNo3" runat="server" Text="Ladle Lining No Register" CssClass="button button2"></asp:Button></td>
						</tr>
					</table>
				</asp:Panel>
				<asp:Panel id="pnl4" runat="server">
					<table id="Table9" class="table" >
						<tr>
							<td >RoofNo</td>
							<td >:</td>
							<td>
								<asp:RadioButtonList id="rblRoofNo" runat="server" Width="676px" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl"></asp:RadioButtonList></td>
						</tr>
					</table>
					<table id="Table10" class="table" >
						<tr>
							<td colspan="3">
								<asp:RadioButtonList id="rblRRLType" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl">
									<asp:ListItem Value="1" Selected="True">Roof Lining Summary</asp:ListItem>
								</asp:RadioButtonList></td>
						</tr>
						<tr>
							<td align="center" colspan="3">
								<asp:Button id="btnRRL" runat="server" Text="Show Report" CssClass="button button2"></asp:Button></td>
						</tr>
					</table>
				</asp:Panel>
                </div></div>
			</asp:Panel>
		</form></div>
        <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</html>
