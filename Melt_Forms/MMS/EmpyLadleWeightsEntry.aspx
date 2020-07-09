<%@ Page Language="vb" AutoEventWireup="false" Codebehind="EmpyLadleWeightsEntry.aspx.vb" Inherits="WebApplication2.EmpyLadleWeightsEntry" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>LadleWeights</title>
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
              <body>
            <div>
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
</nav><br>
            
                <div class="container" align="center">
            <form id="Form1" method="post" runat="server">
			<asp:panel id="Panel1"  runat="server" width="357px">
				<div class="table" >
					<div class="row">
						<div class="col"><h2><b>New Ladle Weight Entry</b></h2><br> <br><br>
							<asp:Label id="lblGroupName" runat="server"></asp:Label>
							<asp:Label id="lblGoup" runat="server"></asp:Label></div>
					</div>
					<div class="row">
						<div class="col" align="center">
							<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></div>
					</div>
                    
					<div class="row">
						<div class="col" align="center" style="margin-left:-62px">Heat Number</div>
						
						<div align="center">
							<asp:textbox id="txtHeat_number" runat="server" Width="70px" BorderStyle="Groove" AutoPostBack="True"></asp:textbox>
							<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtHeat_number" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></div>
					</div>
                    <br>
                    <div class="row">
						<div class="col" align="center" style="margin-left:-75px">Ladle No</div>
					
						<div>
							<asp:textbox id="txtLadle_number" runat="server" Width="70px" AutoPostBack="True" BorderStyle="Groove" MaxLength="5"></asp:textbox>
							
					</div>
                        </div>
                    </div>
                <br>
			<div>
				<asp:Panel id="pnlMould" runat="server">
					<div class="table" >
						<div class="row">
                            <div class="col">
							<div class="col" align="center" style="margin-left:-125px">Pre Heat Life</div>
                                <asp:Label ID="Ht" runat="server"></asp:Label>
                               
                                <asp:Label ID="li" runat="server"></asp:Label>
                            </div>
							
						</div>
                    </asp:Panel>
					
					</div>
				
				<asp:Panel id="pnlMelt" runat="server">
					<div class="table" align="center">
						<div class="row">
							<div class="col" align="center" style="margin-right:-30px">Weight of Empty Ladle (W1)</div>
						
							<div>
								<asp:textbox id="txtw1" runat="server" BorderStyle="Groove" Width="70px"></asp:textbox></div>
						</div>
					</div>
				</asp:Panel>
				<div class="table">
					<div class ="row">
						<div class="col" align="center">
							<asp:button id="btnSave" runat="server" Width="71px" Text="Save"  Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" ></asp:button></div>
					</div>
				</div>
			    </asp:panel></form>
                    </div>
                </div>
                <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;position:absolute;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4>

                </div>      
	</body>
</HTML>
