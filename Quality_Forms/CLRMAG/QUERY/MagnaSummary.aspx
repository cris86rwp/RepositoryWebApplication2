<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MagnaSummary.aspx.vb" Inherits="WebApplication2.MagnaSummary" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>MagnaSummary</title>
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
     <!--<link rel="stylesheet" href="../../../StyleSheet1.css" />-->
	</HEAD>
	<body >
         <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
  <a class="navbar-brand p-0" href="#"><img src="../../../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
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
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home " style="font-size:30px;"></i>
        </a></li>
       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out" style="font-size:30px;"></i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
         
        <img src="../../../NewFolder1/CRIS-Recruitment.jpg" height="45" style="border-radius:43%"/>
       </a>
      </li>
     </ul>
      
  </div>
</nav>
         <script type="text/javascript">
$(document).ready(function () {
                       
                        $('#txtTo').datepicker({
                            dateFormat: "dd-mm-yy"
                        });
                       
                        $("#txtFrom").datepicker({
                            dateFormat: "dd-mm-yy",
                           
                            onSelect: function(date){            
                                var date1 = $('#txtFrom').datepicker('getDate');          
                                                 
                                $('#txtTo').datepicker("option","minDate",date1);            
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
			<asp:panel id="Panel1"  runat="server" >
				<TABLE id="Table1" class="table">
					<div class="row">
						<div class="col"align="center"><STRONG><FONT size="5">Magna Summary</FONT></div>
					</div>
                    </STRONG>
                    <br />
					<div class="row">
		                <div class="col" >
							<asp:Label id="lblmessage" runat="server" Width="272px" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label></div>
					</div>
                    <br />
					<div class="row">
						<div class="col" vAlign="top" align="middle">
							<asp:RadioButtonList id="rblList" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" AutoPostBack="True" CssClass="rbl">
								<asp:ListItem Value="Date" Selected="True">Date&nbsp;&nbsp;&nbsp</asp:ListItem>
								<asp:ListItem Value="Heat">Heat&nbsp</asp:ListItem>
							</asp:RadioButtonList></div>
					</div>
                        <br />
					<div class="row">
						<div class="col">From
						</div>
						
						<div class="col">
							<asp:TextBox id="txtFrom" runat="server" Width="120px" CssClass="form-control"></asp:TextBox></div>
						<div class="col">To
						</div>
						
						<div class="col">
							<asp:TextBox id="txtTo" runat="server" Width="120px" CssClass="form-control"></asp:TextBox></div>
					</div>
                        <br />
					<div class="row">
						<div class="col">Line</div>
						
						<div class="col" >
							<asp:RadioButtonList id="rblLine" runat="server" CssClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow" >
								<asp:ListItem Value="1">1&nbsp</asp:ListItem>
								<asp:ListItem Value="1A">1A &nbsp</asp:ListItem>
								<asp:ListItem Value="2">2 &nbsp</asp:ListItem>
								<asp:ListItem Value="2A">2A &nbsp</asp:ListItem>
								<asp:ListItem Value="All" Selected="True">All</asp:ListItem>
							</asp:RadioButtonList></div>
					
						<div class="col">Shift</div>
						
						<div class="col">
							<asp:RadioButtonList id="rblShift" runat="server" CssClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow" >
								<asp:ListItem Value="A">A &nbsp</asp:ListItem>
								<asp:ListItem Value="B">B &nbsp</asp:ListItem>
								<asp:ListItem Value="C">C &nbsp</asp:ListItem>
								<asp:ListItem Value="All" Selected="True">All</asp:ListItem>
							</asp:RadioButtonList></div>
					</div>
                    <br />
                    <br />
					<div class="row">
						<div class="col" vAlign="top" align="left">
							<asp:RadioButtonList id="rblQry" runat="server" CssClass="rbl" RepeatDirection="Horizontal">
								<asp:ListItem Value="9" Selected="True">Daily Position&nbsp</asp:ListItem>
								<asp:ListItem Value="1">Processed, Stocked and XC&nbsp</asp:ListItem>
								<asp:ListItem Value="6">Processed, Stocked and XC Summary&nbsp</asp:ListItem>
								<asp:ListItem Value="2">Off Load Wheel Type Wise&nbsp</asp:ListItem>
								<asp:ListItem Value="3">Off Load New Reload&nbsp</asp:ListItem>
								<asp:ListItem Value="4">Defects List&nbsp</asp:ListItem>
								<asp:ListItem Value="7">Off Load List&nbsp</asp:ListItem>
								<asp:ListItem Value="5">Not Posted Wheels&nbsp</asp:ListItem>
								<asp:ListItem Value="8">Not Posted Wheels Made RM&nbsp</asp:ListItem>
								<asp:ListItem Value="10">Posted in Magna and Spl&nbsp</asp:ListItem>
								<asp:ListItem Value="11">Unique Processed&nbsp</asp:ListItem>
								<asp:ListItem Value="12">Converted MR XC&nbsp</asp:ListItem>
								<asp:ListItem Value="13">New Wheels Posted as MR XC based on Tapped Date</asp:ListItem>
							</asp:RadioButtonList></div>
					</div></TABLE>
                    <br/>
                <div class="table">
					<div class="row">
						<div class="col" align="center">
							<asp:Button id="btnReport" runat="server" Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" Text="Show Results"></asp:Button></div>
					</div>
                    <br />
					<div class="row">
						<div class="col" align="center">
							<asp:Button id="Button1" runat="server" Text="Export to Excel" Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark"></asp:Button></div>
					</div>
				</div>
				<asp:DataGrid id="DataGrid1" runat="server" CssClass="table" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966">
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
