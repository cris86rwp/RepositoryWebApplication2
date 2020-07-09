<%@ Page Language="vb" AutoEventWireup="false" Codebehind="_302_cleaningroom_report.aspx.vb" Inherits="WebApplication2._302_cleaningroom_report" %>
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

   <!-- <link href="../../StyleSheet1.css" rel="stylesheet" />-->

 
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

  <br />
     <div class="container">
            <div class="row">
                <div class="table">
		<form id="Form1" method="post" runat="server">

			
				<div class="row">
					<div class="col"vAlign="center" align="middle" width="100%" ><STRONG><FONT size="5px";Font-Bold="True" >Cleaning Room 302 Form</FONT></STRONG></div>
				</div>
                <br />
				
               
				<div class="row">
					<div class="col"style="WIDTH: 588px" vAlign="center" align="left" colSpan="4">
						<asp:Label id="lblerr" runat="server" ForeColor="Red"></asp:Label></div>
				</div>
                <br />
				<div class="row">
					
                        <div class="col"> From Heat</div>
                        <div class="col">
						<asp:textbox id="txtFromHt" runat="server" Width="90px"  CssClass="form-control" BorderStyle="Groove"></asp:textbox>
						<asp:RequiredFieldValidator id="rfvld1" runat="server" ControlToValidate="txtFromHt" Display="Dynamic">*</asp:RequiredFieldValidator></div>
				
					<div class="col">To Heat</div>
					<div class="col">
						<asp:textbox id="txtToHt" runat="server" Width="90px"  CssClass="form-control" BorderStyle="Groove"></asp:textbox>
						<asp:RequiredFieldValidator id="rfvld2" runat="server" ControlToValidate="txtToHt" Display="Dynamic">*</asp:RequiredFieldValidator></div>
				    </div>
             
                    <br />
                 <br />
                 <br />
                 <br />
				<div class="row">
					<div class="col" align="center" >
						<asp:button id="BtnShow" runat="server" Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" Text="Show Report"></asp:button></div>
				</div>
			
		</form>
	
                     </div>
                </div>
            </div>
    <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;position:absolute;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>

	</body>
</HTML>
