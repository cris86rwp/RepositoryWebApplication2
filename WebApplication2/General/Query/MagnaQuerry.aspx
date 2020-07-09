<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MagnaQuerry.aspx.vb" Inherits="WebApplication2.MagnaQuerry" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>MagnaQuerry</title>
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
    <!-- <link rel="stylesheet" href="../../StyleSheet1.css" />-->
	</HEAD>
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
          <i class="fab glyphicon glyphicon-home " style="font-size:30px"></i>
        </a></li>

       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out" style="font-size:30px"> </i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
         
        <img src="../../NewFolder1/CRIS-Recruitment.jpg" height="45" style="border-radius:43%"/>
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
			<asp:panel id="Panel1"  runat="server">
				<TABLE id="Table1" class="table">
					<div class="row">
						<div class="col"align="middle" colSpan="6"><STRONG><FONT size="5">Magna&nbsp;Wheels Details</FONT></STRONG></div>
					</div>
                    <br />
					<div class="row">
						
						<div class="col"colSpan="4">
							<asp:Label id="lblmessage" runat="server"  ForeColor="Red" Font-Size="Medium" Font-Bold="True"></asp:Label></div>
					</div>
                     <br />
					<div class="row">
						<div class="col"vAlign="top" align="middle" colSpan="6">
							<asp:RadioButtonList id="rblList" runat="server" AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl">
								<asp:ListItem Value="Date" Selected="True">&nbsp;Date&nbsp;</asp:ListItem>
								<asp:ListItem Value="Heat">&nbsp;Heat&nbsp;</asp:ListItem>
							</asp:RadioButtonList></div>
					</div>
                     <br />
					<div class="row">
						<div class="col">From
						</div>
                         
						
						<div class="col">
							<asp:TextBox id="txtFrom" runat="server" CssClass="form-control" Width="120px"></asp:TextBox></div>
						<div class="col">To
						</div>
						
						<div class="col">
							<asp:TextBox id="txtTo" runat="server" CssClass="form-control" Width="120px"></asp:TextBox></div>
					</div>
                     <br />
					<div class="row">
						<div class="col"align="middle" colSpan="6">
							<asp:RadioButtonList id="rblQry" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl" >
								<asp:ListItem Value="PinkSheetXCWhlsDetails And Summary" Selected="True">&nbsp;PinkSheet XC Wheels Details And Summary&nbsp</asp:ListItem>
								<asp:ListItem Value="PinkSheetXCWhlsHeatWiseSummary">&nbsp;PinkSheet XC Wheels Heat Wise Summary&nbsp</asp:ListItem>
								<asp:ListItem Value="MagnaMCNOffloadsDetails And Summary">&nbsp;Magna MCN Offloads Details And Summary&nbsp</asp:ListItem>
								<asp:ListItem Value="MagnaMCNOffloadsHeatWiseSummary">&nbsp;Magna MCN Offloads HeatWise Summary&nbsp</asp:ListItem>
								<asp:ListItem Value="MagnaOffLoad">&nbsp;Magna OffLoad&nbsp</asp:ListItem>
								<asp:ListItem Value="MagnaXCDetails">&nbsp;Magna XC Details&nbsp</asp:ListItem>
								<asp:ListItem Value="PinkSheetSummary">&nbsp;PinkSheet Summary&nbsp</asp:ListItem>
								<asp:ListItem Value="PourOrder wise Rejection">&nbsp;PourOrder wise Rejection&nbsp</asp:ListItem>
								<asp:ListItem Value="PinkSheetMisXCWhlsDetails And Summary">&nbsp;PinkSheet Mis XC Wheels Details And Summary</asp:ListItem>
							</asp:RadioButtonList></div>
					</div>
                     <br />
					<div class="row">
						<div class="col"align="middle" colSpan="6">
							<asp:Button id="btnReport" runat="server" Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark"  Text="Show Results"></asp:Button></div>
					</div>
                     <br />
					<div class="row">
						<div class="col"align="middle" colSpan="6">
							<asp:Button id="Button1" runat="server" Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark"  Text="Export to Excel"></asp:Button></div>
					</div>
                     <br />
				</TABLE>
				<asp:DataGrid id="DataGrid1" runat="server" CssClass="table" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
				<asp:DataGrid id="DataGrid2" runat="server" CssClass="table" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4">
					<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
				</asp:DataGrid>
			</asp:panel>
                </div></div></form></div>
         <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;position:absolute;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>

	</body>
</HTML>
