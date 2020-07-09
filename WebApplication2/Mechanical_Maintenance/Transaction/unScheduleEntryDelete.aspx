<%@ Page Language="vb" AutoEventWireup="false" Codebehind="unScheduleEntryDelete.aspx.vb" Inherits="WebApplication2.unScheduleEntryDelete" Culture="en-GB" uiCulture="en-GB" %>
<!DOCTYPE html PUBLIC "-//W3C//Dtd html 4.0 transitional//EN">
<html>
	<head runat="server">
		<title>unScheduleEntryDelete</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR" />
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE" />
		<meta content="JavaScript" name="vs_defaultClientScript" />
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
         <meta charset="utf-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css"/>
  <script  src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js"></script>
        <link type="text/css" rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
       <%-- <link rel="stylesheet" href="../../StyleSheet1.css" />--%>

	</head>
	<body>

		<form id="Form1" method="post" runat="server">
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
     
                
    
                             <%-- <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                             <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                                 <asp:ListItem>select</asp:ListItem>
                                 <asp:ListItem>Theme1</asp:ListItem>
                                 <asp:ListItem>Theme2</asp:ListItem>
                                 <asp:ListItem>Theme3</asp:ListItem>
                             </asp:DropDownList>
                             <br />--%>
			<asp:panel id="Panel1" runat="server">
				<table id="table1" class="table">
					<tr>
						<td colSpan="4"><FONT size="3">ConditionBasedMaintenanceEntry-Delete WO </FONT>
						</td>
					</tr>
					<tr>
						<td colSpan="4">
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></td>
					</tr>
					<tr>
						<td>Group</td>
						<td>:</td>
						<td colSpan="2">
							<asp:label id="lblMaintenance_group" runat="server"></asp:label></td>
					</tr>
					<tr>
						<td>Date</td>
						<td>:</td>
						<td>
							<asp:textbox id="txtdate" runat="server" AutoPostBack="true" CssClass="form-control"></asp:textbox></td>
						<td>
							<asp:label id="lblDept" runat="server" Visible="False"></asp:label></td>
					</tr>
					<tr>
						<td>Location</td>
						<td>:</td>
						<td>
							<asp:dropdownlist id="ddlShopCode" runat="server" CssClass="form-control ll" AutoPostBack="true"></asp:dropdownlist></td>
						<td>
							<asp:Label id="lblUserID" runat="server" Visible="False"></asp:Label></td>
					</tr>
					<tr>
						<td>WONo</td>
						<td>:</td>
						<td>
							<asp:dropdownlist id="cboWorkOrderNo" runat="server" CssClass="form-control ll" AutoPostBack="true"></asp:dropdownlist></td>
						<td>
							<asp:label id="lblGroup" runat="server" Visible="False"></asp:label></td>
					</tr>
					<tr>
						<td vAlign="top" align="middle" colSpan="4">
							<asp:Button id="btnDeleteWO" runat="server" Text="Delete WO" CssClass="button button2"></asp:Button></td>
					</tr>
					<tr>
						<td vAlign="top" align="middle" colSpan="4">
							<asp:Button id="btnSpares" runat="server" Text="Show Spares" CssClass="button button2"></asp:Button></td>
					</tr>
				</table>
				<asp:DataGrid id="DataGrid1" runat="server" BorderColor="#CC9966" BorderStyle="None" BackColor="White" CellPadding="4" CssClass="Table">
					<SelectedItemStyle Font-Bold="true" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<headerStyle Font-Bold="true" ForeColor="#FFFFCC" BackColor="#990000"></headerStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<Columns>
						<asp:ButtonColumn Text="Delete" CommandName="Delete"></asp:ButtonColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
                
			</asp:panel>
    </div>
    </div>
    </div>
    </form>
          <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</html>
