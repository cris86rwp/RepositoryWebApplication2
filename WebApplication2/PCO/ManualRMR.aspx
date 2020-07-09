    <%@ Page Language="vb" AutoEventWireup="false" Codebehind="ManualRMR.aspx.vb" Inherits="WebApplication2.ManualRMR" %>
<!DOCTYPE HTML>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>Manual RMR</title>
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

    <%--     <link rel="stylesheet" href="../StyleSheet1.css" />--%>
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
                <div class="table">
       
		<form id="Form1" method="post" runat="server">
           <%--  <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
			<div class="table">
				<div class="row">
					<div class="col" align="center" colSpan="3"><h2>Manual RMR</h2>
						<asp:label id="lblUser" runat="server" Visible="False"></asp:label></div>
				</div>
				<div class="row">
					<div class="col" align="center"><asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></div>
				</div></div>
				
					<asp:panel id="Panel1" runat="server" >
							<div class="table">
								<div class="row">
									<div class="col" colSpan="2"></div>
								</div>
								<div class="row">
                                    <div class="col"></div>
									<div class="col">
										<asp:Label id="lblOldPassword" runat="server">Password</asp:Label></div>
									<div class="col">
										<asp:TextBox id="txtOldPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox></div>
                                    <div class="col"></div>

								</div>
                                <br />
								<div class="row">
                                    <div class="col"></div>

									<div class="col">
										<asp:Label id="lblNewPassword" runat="server">New Password</asp:Label></div>
									<div class="col">
										<asp:TextBox id="txtNewPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>&nbsp;</div>
                                    <div class="col"></div>
								</div>
                                <br />
								<div class="row">
									<div class="col" align="center" colSpan="2">
										<asp:Button id="btnLogin" runat="server" borderStyle="Solid" Font-Bold="True" Font-Size="20px" CssClass="btn btn-dark" Text="Login"></asp:Button>&nbsp;
										<asp:Button id="btnCancel" runat="server" borderStyle="Solid" Font-Bold="True" Font-Size="20px" CssClass="btn btn-dark" Text="Cancel"></asp:Button>&nbsp;&nbsp;</div>
								</div>
								<div class="row">
									<div class="col" align="right" colSpan="2">
										<asp:Button id="btnChange" runat="server" Text="Change Password" BorderStyle="None"  CssClass="button button2"></asp:Button></div>
								</div>
							</div>
						</asp:panel>
				
					<asp:panel id="Panel2" runat="server" Visible="False" >
							<div class="table">
								<div class="row">
									<div class="col" colSpan="2"></div>
								</div>
								<div class="row">
									<div class="col" >Work Order</div>
									<div class="col">
										<asp:DropDownList id="ddlWorkorder" runat="server" AutoPostBack="True" CssClass="form-control ll "></asp:DropDownList>
										<asp:Label id="lblWorkOrder" runat="server"></asp:Label></div>
								<%--</div>
								<div class="row">--%>
									<div class="col" >Shop Code</div>
									<div class="col">
										<asp:DropDownList id="ddlShopCode" runat="server" AutoPostBack="True" CssClass="form-control ll"></asp:DropDownList>
										<asp:Label id="lblShopCode" runat="server"></asp:Label></div>
								</div>
                                <br />
								<div class="row">
									<div class="col" >PL Number</div>
									<div class="col">
										<asp:DropDownList id="ddlPlNumber" runat="server" AutoPostBack="True" CssClass="form-control ll"></asp:DropDownList>
										<asp:Label id="lblPLNumber" runat="server"></asp:Label></div>
								<%--</div>
								<div class="row">--%>
									<div class="col" >Route Code</div>
									<div class="col" >
										<asp:DropDownList id="ddlRouteCode" runat="server" AutoPostBack="True" CssClass="form-control ll"></asp:DropDownList>
										<asp:Label id="lblRouteCode" runat="server"></asp:Label></div>
								</div>
                                <br />
								<div class="row">
									<div class="col" >Route Sequence</div>
									<div class="col" >
										<asp:DropDownList id="ddlRouteSeq" runat="server" AutoPostBack="True" CssClass="form-control ll"></asp:DropDownList>
										<asp:Label id="lblRouteSequence" runat="server"></asp:Label></div>
								<%--</div>
								<div class="row">--%>
									<div class="col" vAlign="top" >PL Number Details</div>
									<div class="col">
										<asp:Label id="lblPLDetails" runat="server" Visible="False"></asp:Label></div>
								</div>
                                <br />
								<div class="row">
									<div class="col" vAlign="top" >Quantity</div>
									<div class="col">
										<asp:TextBox id="txtPLQty" runat="server"  CssClass="form-control"></asp:TextBox>
										<asp:Label id="lblQuantity" runat="server"></asp:Label></div>
								<%--</div>
								<div class="row">--%>
									<div class="col" vAlign="top" align="center" colSpan="2">
										<asp:Label id="lblWarning" runat="server" Font-Bold="True"></asp:Label></div>
                                    <div class="col"></div>
								</div>
                                <br />
								<div class="row">
									<div class="col" align="center" >
										<asp:Button id="btnGenerate" runat="server"  Text="Generate RMR" borderStyle="Solid" Font-Bold="True" Font-Size="20px" CssClass="btn btn-dark"></asp:Button>&nbsp;
										<asp:Button id="btnCancel1" runat="server" Visible="False" Width="93px" Text="No" CausesValidation="False" borderStyle="Solid" Font-Bold="True" Font-Size="20px" CssClass="btn btn-dark"></asp:Button></div>
								</div>
                                <br />
								<div class="row">
									<div class="col" align="right"  colSpan="2">
										<asp:Button id="btnLogOut" runat="server" Text="LogOut" borderStyle="Solid" Font-Bold="True" Font-Size="20px" CssClass="btn btn-dark"></asp:Button></div>
								</div>
								<div class="row">
									<div class="col" align="right"  colSpan="2"></div>
								</div>
                                </div>
                        <div class="table-responsive">
								<div class="row">
									<div class="col" align="center" colSpan="2">
										<asp:DataGrid id="grdView" runat="server" Visible="False" AutoGenerateColumns="False" CssClass="table">
											<ItemStyle BackColor="#FFE6CC"></ItemStyle>
											<HeaderStyle BackColor="#99CCFF"></HeaderStyle>
											<Columns>
												<asp:BoundColumn DataField="workorder_number" HeaderText="Work Order"></asp:BoundColumn>
												<asp:BoundColumn DataField="Pl_number" HeaderText="Pl Number"></asp:BoundColumn>
												<asp:BoundColumn DataField="number" HeaderText="RMR Number"></asp:BoundColumn>
												<asp:BoundColumn DataField="rmr_quantity" HeaderText="Quantity"></asp:BoundColumn>
											</Columns>
										</asp:DataGrid></div>
								</div>
							</div>
						</asp:panel>
				
			
		</form>
            </div></div></div>
        <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;height:45px;width:100%;bottom:0;position:relative"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
			</body>
</html>
