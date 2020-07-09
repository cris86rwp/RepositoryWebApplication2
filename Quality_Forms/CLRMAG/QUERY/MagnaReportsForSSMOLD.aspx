<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MagnaReportsForSSMOLD.aspx.vb" Inherits="WebApplication2.MagnaReportsForSSMOLD" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>MagnaReportsForSSMOLD</title>
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
 
     <style type="text/css">
         .ui-datepicker {
    background: #333;
    border: 1px solid #555;
    color: #EEE;
    
}
</style>
    <!-- <link rel="stylesheet" href="../../../StyleSheet1.css" />-->
	</HEAD>
	<body >
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
        <script>
 $(document).ready(function () {
                       
                        $('#txtDate').datepicker({
                            dateFormat: "dd-mm-yy", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtDate').datepicker('getDate');           
                                                 
                              
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
        <br />
<!--/.Navbar -->
        <div class="container">
		<form id="Form1" method="post" runat="server">
            <div class="row"><div class="table">
			<asp:panel id="Panel1"  runat="server">
				<TABLE id="Table2" class="table">
					<div class="row">
						<div class="col" vAlign="top" align="middle" ><FONT size="5">Magna View</FONT></div>
					</div>
                    <br />
					<div class="row">
						<div class="col">
							<asp:label id="lblMessage" runat="server" DESIGNTIMEDRAGDROP="162" Font-Size="Small" ForeColor="Red" Font-Bold="True"></asp:label></div>
					</div>
                    <br />
					<div class="row">
						<div class="col">Heat Number</div>
						
						<div class="col" style="WIDTH: 197px">
							<asp:TextBox id="txtHeatNo" runat="server" CssClass="form-control" Width="120px"></asp:TextBox></div>
						<div class="col">
							<asp:Button id="Button1" runat="server" Text="302 Details For MagnaGlow Inspection" Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark"></asp:Button></div>
					</div>
                    <br />
					<div class="row">
						<div class="col">Date </div>
						
						<div class="col" style="WIDTH: 197px">
							<asp:TextBox id="txtDate" runat="server" CssClass="form-control" Width="120px"></asp:TextBox></div>
						<div class="col">
							<asp:Button id="Button2" runat="server" Text="FI Score" Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark"></asp:Button></div>
					</div>
                    <br />
					<div class="row">
						<div class="col">Date </div>
						
						<div class="col" style="WIDTH: 197px">As Above</div>
						<div class="col">
							<asp:Button id="Button3" runat="server" Text="MagnaGlow Inspection Hourly Status" Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark"></asp:Button></div>
					</div>
                    <br />
					<div class="row">
						<div class="col">Date </div>
						
						<div class="col" style="WIDTH: 197px">As Above</div>
						<div class="col">
							<asp:Button id="Button4" runat="server" Text="MagnaGlow Inspection Score" Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark"></asp:Button></div>
					</div>
                    <br />
					<div class="row">
						<div class="col">Date </div>
						<div class="col" style="WIDTH: 197px">As above</div>
						<div class="col" >
							<asp:Button id="Button5" runat="server" Text="MagnaGlow Inspection Offload Score" Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark"></asp:Button></div>
					</div>
                    <br />
					<div class="row" >
						<div class="col" >Date As Above </div>
					
						<div class="col"  style="WIDTH: 197px">
							<asp:RadioButtonList id="rblLine" runat="server" CssClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow">
								<asp:ListItem Value="1">1 &nbsp</asp:ListItem>
								<asp:ListItem Value="1A">1A &nbsp</asp:ListItem>
								<asp:ListItem Value="2">2 &nbsp</asp:ListItem>
								<asp:ListItem Value="2A">2A &nbsp</asp:ListItem>
								<asp:ListItem Value="All" Selected="True">All</asp:ListItem>
							</asp:RadioButtonList></div>
						<div class="col" >
							<asp:Button id="Button6" runat="server" Text="MagnaGlow Inspection Wheels Saved " Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark"></asp:Button></div>
					</div>
                    <br />
					<div class="row" >
						<div class="col" >Date As Above </div>
					
						<div class="col" style="WIDTH: 197px">
							<asp:RadioButtonList id="rblShift" runat="server" CssClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow">
								<asp:ListItem Value="A">A &nbsp</asp:ListItem>
								<asp:ListItem Value="B">B &nbsp</asp:ListItem>
								<asp:ListItem Value="C">C &nbsp</asp:ListItem>
								<asp:ListItem Value="All" Selected="True">All</asp:ListItem>
							</asp:RadioButtonList></div>
						<div class="col" >
							<asp:Button id="Button8" runat="server" Text="MagnaGlow Processing" Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark"></asp:Button></div>
					</div>
                        <br />
					<div class="row" >
						<div class="col" >Date </div>
						
						<div class="col"  style="WIDTH: 197px">As Above</div>
						<div class="col" >
							<asp:Button id="Button7" runat="server" Text="MagnaGlow Inspection XC Score" Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark"></asp:Button></div>
					</div>
                        <br />
				</TABLE>
				<asp:DataGrid id="DataGrid1" runat="server" Width="672px" CellPadding="4" CssClass="table" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
			</asp:panel>
                </div></div></form>
            </div>
        <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
    </body>
</HTML>
