<%@ Page Language="vb" AutoEventWireup="false" Codebehind="UpdatePOofMoulds.aspx.vb" Inherits="WebApplication2.UpdatePOofMoulds" %>
<!DOCTYPE HTML>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>UpdatePOofMoulds</title>
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
       <%--<link rel="stylesheet" href="StyleSheet1.css" />--%>
                <script>

function OnlyNumericEntry() {
        if ((event.keyCode < 48 || event.keyCode > 57)) {
        event.returnValue = false;
    }
                    }
                    </script>
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
                padding: 6px 12px;
                background-color: #fff;
                background-image: none;
            }
        </style>
	</head>
	<body >
         <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
  <a class="navbar-brand p-0" href="#"><img src="../../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent-333"
    aria-controls="navbarSupportedContent-333" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>
  <div class="collapse navbar-collapse " id="navbarSupportedContent-333" >
      <ul class="navbar-nav ml-auto navbar-center">
         <li class="nav-item" style="font-weight: bold">
             <h1 style="color:white; font-size:30px; margin-left:430px; margin-top:5px">Rail Wheel Plant, Bela</h1> 
       
         </li>
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
         
        <img src="../../NewFolder1/CRIS-Recruitment.jpg" height="45" style="border-radius:43%"/>
       </a>
      </li>
     </ul>
      
  </div>
</nav>
<!--/.Navbar -->
        <div class="container">
		<form id="Form1" method="post" runat="server">
               <%-- <div class="row">
    
                  <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />
      </div>--%>
            <div class="table">
			<asp:panel id="Panel1"  runat="server">
				
					<div class="row">
						<div class="col" align="center"><h3><strong>Update PO Number</strong></h3>
								<asp:Label id="lblOperator" runat="server" Visible="False"></asp:Label><hr class="prettyline" /></div>
					</div>
		
						
							<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label>
								<div class="row">
					<div class="col">
						Mould Number </div>
						
						<div class="col" >
							<asp:TextBox id="txtMldNo" runat="server" AutoPostBack="True" CssClass="auto-style1" MaxLength="5" ToolTip="enter 5-digit mould number(only numeric)" onkeypress="OnlyNumericEntry()" Width="80px"></asp:TextBox></div>
					
                        
						<div class="col" >Product ID</div>
						
						<div class="col">
							<asp:dropdownlist id="ddlProductCode" runat="server" AutoPostBack="True" CssClass="form-control ll" Width="200px" ></asp:dropdownlist></div>
				  
					
						<div class="col">
							<asp:dropdownlist id="ddlSupplier" runat="server" CssClass="form-control ll" Width="201px"></asp:dropdownlist></div>
                                 
						</div><br />
					<div class="row">
						<div class="col">Mould Size</div>
						
						<div class="col">
							<asp:radiobuttonlist id="rblMouldSize" runat="server" RepeatDirection="Horizontal" CssClass="rbl" RepeatLayout="Flow">
								<asp:ListItem Value="52.5">52.5 &nbsp;</asp:ListItem>
								<asp:ListItem Value="48.5" Selected="True">48.5&nbsp;</asp:ListItem>
								<asp:ListItem Value="43.5">43.5&nbsp;</asp:ListItem>
							</asp:radiobuttonlist></div>
						
					<div class="col"></div>
						<div class="col">PL Number</div>
						
						<div class="col">
							<asp:RadioButtonList id="rblPL" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rbl">
								<asp:ListItem Value="76971510" Selected="True">76971510&nbsp;</asp:ListItem>
								<asp:ListItem Value="81980802">81980802&nbsp;</asp:ListItem>
								<asp:ListItem Value="81980851">81980851&nbsp;</asp:ListItem>
							</asp:RadioButtonList></div>
			</div><br /><div class="row">
						<div class="col">New PO</div>
					
						<div class="col">
							<asp:textbox id="txtPONumber" runat="server" AutoPostBack="True" CssClass="form-control" ToolTip="enter New Product order number(only numeric)" onkeypress="OnlyNumericEntry()" Width="88px"></asp:textbox>
						</div>
                <div class="col"></div>
				<div class="col"></div>
                <div class="col"></div>
                <div class="col"></div>
                </div>
                <br />
					<div class="row">
						<div class="col" align="center">
                            
							<asp:button id="btnSave" runat="server" Text="Update"  Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" ></asp:button>
							</div>
					</div>
				
				<asp:DataGrid id="DataGrid1" runat="server" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
			<br />
            <br />
            <div class="table">
					<div class="row">
						<div class="col">Update Firm Name</div>
					</div>
                <br />
					<div class="row">
						<div class="col">Mould Number</div>
						
						<div class="col">
							<asp:TextBox id="txtMould" runat="server" AutoPostBack="True" CssClass="auto-style1" ToolTip="enter 6-digit mould number(only numeric)" onkeypress="OnlyNumericEntry()" Width="80px"></asp:TextBox></div>
				
                        
					
						<div class="col">
							<asp:DataGrid id="DataGrid2" runat="server" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966">
								<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
								<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
								<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
								<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
							</asp:DataGrid></div>
					
					<div class="col"></div>
                        	<div class="col"></div>
						<div class="col">
							<asp:DropDownList id="ddlSupplierCode" runat="server" CssClass="form-control ll" Width="201px"></asp:DropDownList></div>
					</div>
                <br />
					<div class="row">
						<div class="col" align="center">
                        	<asp:button id="btnFirm" runat="server" Text="Change Firm"  Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" ></asp:button></div>
						
					</div>
				</div>
			</asp:panel></div></div></form></div>
         <div class="footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;position:absolute;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
	</body>
</html>
