<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ProdConsumableRegister.aspx.vb" Inherits="WebApplication2.ProdConsumableRegister" %>
<!DOCTYPE HTML PUBLIC >
<html>
	<head runat="server">
		<title>ProdConsumableRegister</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR"/>
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
         <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css"/>

        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js"></script>

         <link type="text/css" rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
       <%-- <link rel="stylesheet" href="../../../StyleSheet1.css" />--%>
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
    
                 <%-- <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
      </div>

			<asp:Panel id="pnlMain"  runat="server" >
                <div class="row">
            <div class="table-responsive">

				<table id="Table6" class="table" border="0">
					<tr>
						<td>
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></td>
					</tr>
				</table>
				<asp:panel id="pnlConsumables" runat="server">
					<table id="Table1" class="table" border="0">
						<tr>
							<td colspan="3">
								<asp:label id="lblConsignee" runat="server" Font-Bold="True"></asp:label>&nbsp;<STRONG>Production 
									Consumables&nbsp;Register</STRONG><hr class="prettyline" /></td>
						</tr>
						<tr>
							<td colspan="3">
								<asp:DropDownList id="ddlPLs" runat="server" CssClass="form-control ll"></asp:DropDownList></td>
						</tr>
					</table>
					<table id="Table2" class="table" border="0">
						<tr>
							<td>FromDate</td>
							<td>:</td>
							<td>
								<asp:textbox id="txtFrDt" runat="server" CssClass="form-control"></asp:textbox></td>
							<td>( Data generation should be for the month only ie start of the month and end of 
								the month,&nbsp;not in-between dates)</td>
						</tr>
						<tr>
							<td>ToDate</td>
							<td>:</td>
							<td>
								<asp:textbox id="txtToDt" runat="server"  CssClass="form-control"></asp:textbox></td>
							<td>
								<asp:Button id="btnDataForReport" runat="server" Text="Generate Data For 'Register for All PLs'  Report" CssClass="button button2"></asp:Button></td>
						</tr>
					</table>
					<table id="Table3" class="table" border="0">
						<tr>
							<td>
								<asp:RadioButtonList id="rblType" runat="server" CssClass="rbl"  RepeatLayout="Flow">
									<asp:ListItem Value="1" Selected="True">Register in Single Page</asp:ListItem>
									<asp:ListItem Value="2">Register in Multiple Pages</asp:ListItem>
									<asp:ListItem Value="3">Cummulative Consumption Statement</asp:ListItem>
									<asp:ListItem Value="4">Register for All PLs</asp:ListItem>
									<%--<asp:ListItem Value="5">Drawal</asp:ListItem>--%>
								</asp:RadioButtonList></td>
						</tr>
						<tr>
							<td align="Center">
								<asp:Button id="btnReport" runat="server" Text="Show  Consumables Register" CssClass="button button2"></asp:Button></td>
						</tr>
					</table>
				</asp:panel>
			<%--	<table id="Table4" class="table" border="0">
					<tr>
						<td colspan="3">Material Dump Register</td>
					</tr>
					<tr>
						<td>PL Number</td>
						<td>:</td>
						<td>
							<asp:DropDownList id="ddlDumpPl" runat="server" AutoPostBack="True" CssClass="form-control ll"></asp:DropDownList></td>
						<td>
							<asp:Label id="lblPLDescr1" runat="server" Width="357px"></asp:Label></td>
					</tr>
					<tr>
						<td>PO Number</td>
						<td>:</td>
						<td>
							<asp:DropDownList id="ddlPONumber" runat="server" CssClass="form-control ll"></asp:DropDownList></td>
					</tr>
					<tr>
						<td colspan="3">
							<asp:Button id="Button1" runat="server" Text="Show Material Dump Register" CssClass="button button2"></asp:Button></td>
					</tr>
				</table>--%>
				<table id="Table5" class="table" border="0">
					<tr>
						<td colspan="3">Rejected CALCINED LIME</td>
					</tr>
					<tr>
						<td>PONumber</td>
						<td >:</td>
						<td >
							<asp:DropDownList id="ddlRejPOs" runat="server" AutoPostBack="True" CssClass="form-control ll"></asp:DropDownList></td>
						<td>
							<asp:Label id="lblRejPOs" runat="server" Width="524px"></asp:Label></td>
					</tr>
					<tr>
						<td  align="center" colspan="3">
							<asp:Button id="Button2" runat="server" Text="Show Calcined Lime Report" CssClass="button button2"></asp:Button></td>
					</tr>
				</table></div></div>
				<asp:DataGrid id="DataGrid1" runat="server" CssClass="table" BackColor="White"  >
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>

           
			</asp:Panel></form></div>
           <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</html>
