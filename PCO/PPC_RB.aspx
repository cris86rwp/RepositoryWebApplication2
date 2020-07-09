<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PPC_RB.aspx.vb" Inherits="WebApplication2.PPC_RB" Culture="en-GB" uiCulture="en-GB" %>
<!DOCTYPE HTML>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>PPC</title> 
		<!--<link href="/wap.css" rel="stylesheet"> !-->
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
      
<%--         <link rel="stylesheet" href="../StyleSheet1.css" />--%>
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
					<div class="col" lign="center" noWrap align="middle" ><h2>RWP 
								Production Rly Board Targets</h2></div>
				</div>
                <br />
				<div class="row">
					<div class="col" noWrap>Message 
						<asp:label id="lblmessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:label></div>
				</div>
                <br />
				<div class="row">
					<div class="col" vAlign="center" noWrap align="right" >Logged In:
						<asp:label id="lblLoggedInBy" runat="server" Font-Bold="True"></asp:label></div>
				</div>
                <br />
				<div class="row">
					<div class="col" noWrap><asp:label id="Label5" runat="server" >Financial Year</asp:label></div>
                 <div class="col"><asp:textbox id="txtfinYear" runat="server" CssClass="form-control" ></asp:textbox><asp:regularexpressionvalidator id="regexpFinYr" runat="server" ValidationExpression="\d{4}\-\d{2}" ErrorMessage="*" Display="Dynamic" ControlToValidate="txtfinYear"></asp:regularexpressionvalidator></div>
				<%--</div>
				<div class="row">--%>
					<div class="col" noWrap>
                        <asp:label id="Label1" runat="server">Plan For</asp:label></div>
                   <div class="col"> <asp:dropdownlist id="ddlPlanPeriod" runat="server" CssClass="form-control ll" AutoPostBack="True">
							<asp:ListItem Value="Select" Selected="True">Select</asp:ListItem>
							<asp:ListItem Value="Day">Day</asp:ListItem>
							<asp:ListItem Value="Month">Month</asp:ListItem>
							<asp:ListItem Value="Year">Year</asp:ListItem>
						</asp:dropdownlist></div>
					<div class="col">	<asp:label id="Label3" runat="server">From </asp:label></div>
					<div class="col">	<asp:dropdownlist id="ddlFrom" runat="server" CssClass="form-control ll"></asp:dropdownlist></div>
					<div class="col">	<asp:label id="Label2" runat="server" >To </asp:label></div>
					<div class="col">	<asp:dropdownlist id="ddlTo" runat="server" CssClass="form-control ll"></asp:dropdownlist><asp:comparevalidator id="CompareValidator1" runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="ddlTo" Operator="GreaterThanEqual" ControlToCompare="ddlFrom" ValueToCompare="ddlto.selecteditem.value" Type="Integer"></asp:comparevalidator></div>
				</div>
                <br />
				<div class="row">
					<div class="col" noWrap><asp:label id="Label4" runat="server" >Product</asp:label></div>
                        <div class="col"><asp:dropdownlist id="ddlProduct" runat="server" CssClass="form-control ll">
							<asp:ListItem Value="Select" Selected="True">Select</asp:ListItem>
							<asp:ListItem Value="01C">Wheels Cast</asp:ListItem>
							<asp:ListItem Value="01G">Good Wheels</asp:ListItem>
                        <%--<asp:ListItem Value="03">Sets</asp:ListItem>--%>
							<%--<asp:ListItem Value="02">Axles</asp:ListItem>--%>
							
						</asp:dropdownlist>
                            </div><asp:requiredfieldvalidator id="rfvProduct" runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="ddlProduct" InitialValue='"Select"'></asp:requiredfieldvalidator>
             <div class="col"></div>
             <div class="col"></div>
             <div class="col"></div>
                    <div class="col"></div>
                  <div class="col"></div>
             <div class="col"></div>
				</div>
                <div class="row">
                  <div class="col" align="center"><asp:checkbox id="chkUpdate" runat="server" AutoPostBack="True" Text="Update Figures"></asp:checkbox></div>
          
			</div></div>
				<div class="row">
					<div class="col" noWrap><asp:panel id="pnlUpdate" runat="server" >
							<asp:label id="lblNewQty" runat="server">New Quantity</asp:label>
							<asp:textbox id="txtNewQty" runat="server"  CssClass="form-control"></asp:textbox>
							<asp:rangevalidator id="RangeValidator1" runat="server" ControlToValidate="txtNewQty" Display="Dynamic" ErrorMessage="*" Type="Integer" MinimumValue="1" MaximumValue="999999"></asp:rangevalidator>
							<asp:Label id="lblAuthority" runat="server" >Authority</asp:Label>
							<asp:TextBox id="txtAuthority" runat="server" MaxLength="6"  CssClass="form-control"></asp:TextBox>
							<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtAuthority" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
							<asp:Label id="Label6" runat="server">Planned WDays</asp:Label>
							<asp:TextBox id="txtPlannedWDays" runat="server" CssClass="form-control"></asp:TextBox>
						</asp:panel></div>
				</div>
				<div class="row">
					<div class="col" vAlign="center" noWrap align="middle">
                        <asp:button id="btnSubmit" runat="server" Text="Submit" BorderStyle="Solid" Font-Bold="True" Font-Size="20px" CssClass="btn btn-dark"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:button id="btnClear" runat="server" Text="Clear " BorderStyle="Solid" Font-Bold="True" Font-Size="20px" CssClass="btn btn-dark"></asp:button></div>
				</div>
				<div class="row">
					<div class="col" noWrap><asp:datagrid id="dgResults" runat="server" CssClass="table">
							<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
							<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
							<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
							<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
						</asp:datagrid></div>
				</div>
			</div>
                    
		</form>
            </div></div></div>
        <div class="card-footer" style="text-align:right;background-color:#cccccc;bottom:0;width:100%;vertical-align:middle;height:60px;position:absolute"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
</body>
</html>
