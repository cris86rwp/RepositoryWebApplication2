<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ProdConsumableDetailsData.aspx.vb" Inherits="WebApplication2.ProdConsumableDetailsData" %>
<!DOCTYPE HTML >
<html  xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>ProdConsumableDetailsData</title>
		<link rel="stylesheet" type="text/css" href="css/jquery-ui.css">

		
 
   <LINK id="mss" href="/wap.css" rel="stylesheet"/>
		<META content="Microsoft Visual Studio.NET 7.0" name="GENERATOR"/>
		<META content="Visual Basic 7.0" name="CODE_LANGUAGE"/>
		<META content="JavaScript" name="vs_defaultClientScript"/>
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
         <meta charset="utf-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css"/>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js"></script>
         <link type="text/css" rel="stylesheet" href="https://cdn.datatables.net/1.10.9/css/dataTables.bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="https://cdn.datatables.net/responsive/1.0.7/css/responsive.bootstrap.min.css" />
        <link href="jQuery.datetimepicker.min.css" rel="stylesheet" />
        <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.9/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/responsive/1.0.7/js/dataTables.responsive.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.9/js/dataTables.bootstrap.min.js"></script>
            <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
        <script type="text/javascript" src= "https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js">  </script>
<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
<script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
<script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
<script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
	</head>
      <style type="text/css">
         .ui-datepicker {
    background: #333;
    border: 1px solid #555;
    color: #EEE;
    
}
                .rbl input[type="radio"] {
    margin-left: 10px;
    margin-right: 10px;
}
</style>
	<body>
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
          <i class="fab glyphicon glyphicon-home " style="font-size:30px"></i>
        </a></li>
       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out"style="font-size:30px"></i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
         
        <img src="../../NewFolder1/CRIS-Recruitment.jpg" height="45" style="border-radius:43%"/>
       </a>
      </li>
     </ul>
      
  </div>
</nav>


         <div class="container" align="center">
		<form id="Form1" method="post" runat="server">
           
			<asp:Panel id="Panel" runat="server">
                 <div class ="row">
				<div class="table">
					<div class="row">
						<div class="col" align="center">
							<asp:label id="lblConsignee" runat="server" Font-Bold="True"></asp:label>&nbsp;<STRONG><h2>Production 
								Consumables Details Data</STRONG></h2></div>
					</div>
					<div class="row">
						<div class="col" colSpan="3">
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></div>
					</div>
				</div>
				<div class="table" style="margin-left:200px">
				<br>	<div class="row">
						<div class="col">
							<asp:Label id="Label1" runat="server">  &nbsp &nbsp </asp:Label></div>
						
						<div class="col">
							<asp:textbox id="txtFrDt" runat="server" Width="100px" CssClass="form-control"></asp:textbox></div>
                        <div class="col"> </div>
                       
					</div>
				<br>	<div class="row">
						<div class="col">
							<asp:Label id="Label2" runat="server">  </asp:Label></div>
					
						<div class="col">
							<asp:textbox id="txtToDt" runat="server" Width="100px" CssClass="form-control"></asp:textbox></div>
                        <div class="col"></div>
					</div>
				</div>
				<asp:Panel id="pnl3" runat="server">
					<div class="table">
						<div class="row" style="margin-left:300px">
							<div class="col">PL Number &nbsp &nbsp &nbsp &nbsp</div>
							<div class="col">
								<asp:DropDownList id="ddlPLs" runat="server" CssClass="rbl"  RepeatDirection="vertical" RepeatLayout="Flow" AutoPostBack="True"></asp:DropDownList></div>
							<div class="col">
								<asp:Label id="lblPLDescr" runat="server" ></asp:Label></div>
						</div>
					</div>
				</asp:Panel>
				<asp:Panel id="pnl4" runat="server">
					<div class="table">
						<div class="row" style="margin-left:400px">
							<div class="col" align="center">Furnace</div>
							
							<div class="col">
								<asp:RadioButtonList id="rblFur"  CssClass="rbl" runat="server" AutoPostBack="True" RepeatDirection="horizontal" RepeatLayout="flow">
									<asp:ListItem Value="A">A&nbsp;</asp:ListItem>
									<asp:ListItem Value="B">&nbsp;B&nbsp;</asp:ListItem>
									<asp:ListItem Value="C">&nbsp;C</asp:ListItem>
						
								</asp:RadioButtonList></div>
						</div>
					</div>
				</asp:Panel>
				<div class="table">
					<div class="row">
						<div class="col">
							<asp:RadioButtonList id="rblType" runat="server" CssClass="rbl" AutoPostBack="True"   RepeatDirection="horizontal" RepeatLayout="Flow">
								<asp:ListItem Value="1" Selected="True">Stock  Position&nbsp</asp:ListItem>
								<asp:ListItem Value="2">&nbsp;Metal Consumption&nbsp</asp:ListItem>
								<asp:ListItem Value="3">&nbsp;Material Dump Details&nbsp</asp:ListItem>
								<asp:ListItem Value="4">&nbsp;Furnace Fettling details&nbsp</asp:ListItem>
								<asp:ListItem Value="5">&nbsp;PTMS Stock Items&nbsp</asp:ListItem>
								<asp:ListItem Value="6">&nbsp;PTMS Non Stock Items&nbsp</asp:ListItem>
								<asp:ListItem Value="7">&nbsp;Heat Log Details</asp:ListItem>
							</asp:RadioButtonList></div>
					</div>
					<br> <br><div class="row">
						<div class="col" align="center">
							<asp:Button id="btnReport"   Font-Size="20px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark"  runat="server" Text="Show  Data"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:button id="btnExportDetails" Font-Size="20px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark"  runat="server" Text="Export Details"></asp:button></div>
					</div>
				</div>
				<asp:DataGrid id="DataGrid1" runat="server" CssClass="table">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
                   
                     </div>
			</asp:Panel>
		</form>
             </div>
          <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;position:absolute;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
	<script>
 $(document).ready(function () {
                       
                        $('#txtToDt').datepicker({
                            dateFormat: "dd-mm-yy", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtToDt').datepicker('getDate');           
                                                 
                              
                            }
                        });
    
  function getDate( element ) {
    var date;
    var dateFormat = "dd-MM-yyyy";
    try {
      date = $.datepicker.parseDate( dateFormat, element.value );
    } catch( error ) {
      date = null;
    }

    return date;
  }
        });

         $(document).ready(function () {
                       
                        $('#txtFrDt').datepicker({
                            dateFormat: "dd-mm-yy", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtFrDt').datepicker('getDate');           
                                                 
                              
                            }
                        });
    
  function getDate( element ) {
    var date;
    var dateFormat = "dd-MM-yyyy";
    try {
      date = $.datepicker.parseDate( dateFormat, element.value );
    } catch( error ) {
      date = null;
    }

    return date;
  }
    });

                        
</script>
    </body>
</html>
