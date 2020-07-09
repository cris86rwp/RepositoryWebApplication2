<%@ Page Language="vb" AutoEventWireup="false" Codebehind="HSD.aspx.vb" Inherits="WebApplication2.HSD" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Baking station</title>
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

  <%--  <link href="../../StyleSheet1.css" rel="stylesheet" />--%>

 
</head>
	<body MS_POSITIONING="GridLayout" bgColor="#99ccff">
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
             <%--<h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
                       
			<asp:Panel id="Panel1" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute" runat="server">
				<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="300" border="1">
					<TR>
						<TD>HSD</TD>
					</TR>
					<TR>
						<TD>
							<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></TD>
					</TR>
				</TABLE>
				<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="300" border="1">
					<TR>
						<TD>Date</TD>
						<TD>LPH</TD>
						<TD>NF</TD>
						<TD>DF</TD>
						<TD>SP</TD>
						<%--<TD>AxleShop</TD>--%>
						<TD>RTShop</TD>
						<TD>DG</TD>
					</TR>
					<TR>
						<TD>
							<asp:TextBox id="ConsumptionDate" runat="server" AutoPostBack="True" Width="120px" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="LPH" runat="server" Width="70px"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="NF" runat="server" Width="70px"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="DF" runat="server" Width="70px"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SP" runat="server" Width="70px"></asp:TextBox></TD>
						<%--<TD>
							<asp:TextBox id="AxleShop" runat="server" Width="70px"></asp:TextBox></TD>--%>
						<TD>
							<asp:TextBox id="RTShop" runat="server" Width="70px"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="DG" runat="server" Width="70px"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>Remarks</TD>
						<TD colSpan="7">
							<asp:TextBox id="Remarks" runat="server" Width="299px"></asp:TextBox></TD>
					</TR>
				</TABLE>
				<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="300" bgColor="#ffcc66" border="1">
					<TR>
						<TD align="middle" colSpan="5">LPG</TD>
					</TR>
					<TR>
						<TD>Wheel</TD>
						<TD>HubCut</TD>
						<TD>BilletCut</TD>
						<%--<TD>AxleEndCut</TD>--%>
						<TD>PCBay</TD>
					</TR>
					<TR>
						<TD>
							<asp:TextBox id="Wheel" runat="server" Width="70px"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="HubCut" runat="server" Width="70px"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="BilletCut" runat="server" Width="70px"></asp:TextBox></TD>
						<%--<TD>
							<asp:TextBox id="AxleEndCut" runat="server" Width="70px"></asp:TextBox></TD>--%>
						<TD>
							<asp:TextBox id="PCBay" runat="server" Width="70px"></asp:TextBox></TD>
					</TR>
				</TABLE>
				<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="300" border="1">
					<TR>
						<TD>
							<asp:Button id="Save" runat="server" Text="Save" CssClass="form-control"></asp:Button></TD>
					</TR>
					<TR>
						<TD align="middle">
							<asp:Button id="btnEnergy" runat="server" CssClass="form-control"></asp:Button></TD>
					</TR>
				</TABLE>
				<asp:DataGrid id="DataGrid1" runat="server" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
			</asp:Panel>
		</form>
	</div>
                </div>
            </div>
     <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
