<%@ Page Language="vb" AutoEventWireup="false" Codebehind="RoofFixing.aspx.vb" Inherits="WebApplication2.RoofFixing"%>
<!DOCTYPE HTML >
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>RoofFixing</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR"/>
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
             <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css"/>
  <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js"></script>
  <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js"></script>

        
    <link type="text/css" rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
   
         <%-- <link rel="stylesheet" href="../../../StyleSheet1.css" />--%>
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

		<form id="Form1" method="post" runat="server">
                <div class="row">
    
                 <%-- <h4>&nbsp&nbsp&nbspSelect Your Theme : &nbsp&nbsp&nbsp </h4>
            
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
				<table id="Table1"  runat="server">
					<tr>
						<td>
							<asp:RadioButtonList id="rblType" CssClass="rbl" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" RepeatLayout="Flow" >
								<asp:ListItem Value="0" Selected="True">Roof Fixing</asp:ListItem>
								<asp:ListItem Value="1">ContractNo</asp:ListItem>
							</asp:RadioButtonList></td>
					</tr>
				</table>
				<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label>
				<asp:Panel id="pnlRoof" runat="server">
					<table id="Table2"  class="table">
						<tr>
							<td>RoofNo</td>
							<td>:</td>
							<td>
								<asp:RadioButtonList id="rblRoofNo" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" RepeatLayout="Flow"  CssClass="rbl"></asp:RadioButtonList></td>
						</tr>
					</table>
					<table id="Table3" class="table">
						<tr>
							<td>FurnaceCode</td>
							<td>:</td>
							<td>
								<asp:RadioButtonList id="rblFur" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rbl" AutoPostBack="True">
									<asp:ListItem Value="A" Selected="True">A</asp:ListItem>
									<asp:ListItem Value="B">B</asp:ListItem>
									<asp:ListItem Value="C">C</asp:ListItem>
								</asp:RadioButtonList></td>
						</tr>
						<tr>
							<td>IntroducedFromHeatNo</td>
							<td>:</td>
							<td>
								<asp:TextBox id="txtFromHeatNo" runat="server"  CssClass="form-control"></asp:TextBox></td>
						</tr>
						<tr>
							<td>WithdrawnHeatNo</td>
							<td>:</td>
							<td>
								<asp:TextBox id="txtToHeatNo" runat="server"  CssClass="form-control"></asp:TextBox></td>
						</tr>
						<tr>
							<td>Reason</td>
							<td>:</td>
							<td>
								<asp:RadioButtonList id="rblReason" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"  CssClass="rbl">
									<asp:ListItem Value="For ReLining" Selected="True">For ReLining</asp:ListItem>
									<asp:ListItem Value="For Repair">For Repair</asp:ListItem>
								</asp:RadioButtonList></td>
						</tr>
					</table>
					<table id="Table4"  class="table">
						<tr>
							<td>Remarks</td>
							<td>:</td>
							<td>
								<asp:TextBox id="txtRemarks" runat="server"  CssClass="form-control"></asp:TextBox></td>
						</tr>
					</table>
					<table id="Table5" class="table">
						<tr>
							<td align="center">
								<asp:Button id="btnSave" CssClass="button button2" runat="server" Text="Save"></asp:Button></td>
						</tr>
					</table>
					<asp:DataGrid id="DataGrid1" runat="server"   BackColor="White"  CssClass="table">
						<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
						<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
						<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
						<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
						<Columns>
							<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
						</Columns>
						<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
					</asp:DataGrid>
				</asp:Panel>
				<asp:Panel id="pnlCon" runat="server">
					<table id="Table6"  class="table">
						<tr>
							<td>ContractNo</td>
							<td>:</td>
							<td>
								<asp:TextBox id="txtContractNo" runat="server" AutoPostBack="True" CssClass="form-control"></asp:TextBox></td>
						</tr>
						<tr>
							<td>Qty</td>
							<td>:</td>
							<td>
								<asp:TextBox id="txtQty" runat="server"  CssClass="form-control"></asp:TextBox></td>
						</tr>
						<tr>
							<td align="center" colspan="3">
								<asp:Button id="btnCon" CssClass="button button2" runat="server" Text="Save"></asp:Button></td>
						</tr>
					</table>
					<asp:DataGrid id="DataGrid2" runat="server"  CssClass="table" BackColor="White" CellPadding="4">
						<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
						<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
						<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
						<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
						<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
					</asp:DataGrid>
                   
				</asp:Panel>
                     </div>
                     </div>
			</asp:panel></form></div>
          <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</html>
