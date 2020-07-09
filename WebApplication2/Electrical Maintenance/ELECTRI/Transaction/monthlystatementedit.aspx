<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="monthlystatementedit.aspx.vb" Inherits="WebApplication2.monthlystatementedit" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
	<HEAD runat="server">
		<title>Monthly Statement Edit</title>
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
    	</head>
	<body style="overflow-x:hidden">

      <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
  <a class="navbar-brand p-0" href="#"><img src="../../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent-333"
    aria-controls="navbarSupportedContent-333" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>
  <div class="collapse navbar-collapse " id="navbarSupportedContent-333">
      <ul class="navbar-nav ml-auto  navbar-center">
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
<!--/.Navbar -->
     <div class="container">
		<form id="Form1" method="post" runat="server">
            <div class="row">

				<div class="table" id="Table1">
					<div class="row">
						<div class="col-12" align="center" ><h1>MONTHLY STATEMENT<hr/></h1></div>
                        </div><br />
				<div class="row">
					<div class="col-12" align="center">Mode <asp:label id="lblMode" runat="server" Width="57px" ForeColor="Blue" Font-Bold="True" Font-Names="Arial" Font-Size="Smaller"></asp:label></div >
				</div >
				<div class="row">
					<div class="col-12" align="center"><asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></div >
				</div >
				<div class="row">
					<div class="col-2">Date</div >
                    <div class="col-2">
						<asp:textbox id="txtDate" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox></div >
                    <div class="col-2">
                        <asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtDate" ErrorMessage="*"></asp:requiredfieldvalidator></div >
                       
				</div><br />
			
				<div class="row">
					<div class="col-2">NBPDCL Energy Purchase</div >
					<div class="col-2" ><asp:textbox id="txtKpctl" runat="server" CssClass="form-control"></asp:textbox></div >
					<div class="col-2">Dg&nbsp;Energy (Local Generation)</div >
					<div class="col-2"><asp:textbox id="txtDG" runat="server" CssClass="form-control"></asp:textbox></div >
				</div ><br />
				<div class="row">
					<div class="col-12" align="center" ><b><U>Melting Energy</U></b></div >
				</div ><br />
				<div class="row">
					<div class="col-2">Furnace I</div >
					<div class="col-2" ><asp:textbox id="txtfurA" runat="server" CssClass="form-control"></asp:textbox></div >
					<div class="col-2" >Furnace II</div >
					<div class="col-2"><asp:textbox id="txtfurB" runat="server" CssClass="form-control"></asp:textbox></div >
					<div class="col-2" >Furnace III</div >
					<div class="col-2"><asp:textbox id="txtfurC" runat="server" CssClass="form-control"></asp:textbox></div >
				</div ><br />
			
				<div class="row">
					<div class="col-2">Melt Shop Sub-Stn(Essen)</div >
					<div class="col-2" ><asp:textbox id="txtWheelEss" runat="server" CssClass="form-control"></asp:textbox></div >
					<div class="col-2">Melt Shop Sub-Stn (N-Essen)</div >
					<div class="col-2"><asp:textbox id="txtWheelNEss" runat="server" CssClass="form-control"></asp:textbox></div >
                    <div class="col-2">TUBE PREHEAT Ovens</div >
					<div class="col-2" ><asp:textbox id="txtHold" runat="server" CssClass="form-control"></asp:textbox></div >
				</div ><br />
				<div class="row">
					<div class="col-2">Moulding Pre-Heat Oven</div >
					<div class="col-2"><asp:textbox id="txtPreHeat" runat="server" CssClass="form-control"></asp:textbox></div >
                    	<div class="col-2">Fume Extraction</div >
					<div class="col-2" ><asp:textbox id="txtExtract" runat="server" CssClass="form-control"></asp:textbox></div >
					<div class="col-2">Compressor Substation</div >
					<div class="col-2"><asp:textbox id="txtCompress" runat="server" CssClass="form-control"></asp:textbox></div >
				</div ><br />
                    		<div class="row">
					<div class="col-12" align="center" ><b><U>Remaining Energy Points</U></b></div >
				</div ><br />
				<div class="row">
				</div ><br />
		
				<div class="row">
					<div class="col-2">Remainig Shops</div >
					<div class="col-2"><asp:textbox id="txtANEssen" runat="server" CssClass="form-control"></asp:textbox></div >
                    <div class="col-2">Colony(1&amp;2)</div >
					<div class="col-2" ><asp:textbox id="txtColony" runat="server" CssClass="form-control"></asp:textbox></div >
					<div class="col-2">Colony(3&amp;4)</div >
					<div class="col-2" ><asp:textbox id="txtColony1" runat="server" CssClass="form-control"></asp:textbox></div >
				</div ><br />
		
				<div class="row">
			
                    <div class="col-2" >Admn. Bldg. </div >
					<div class="col-2"><asp:textbox id="txtAdmin" runat="server" CssClass="form-control"></asp:textbox></div >
				</div ><br />
				<div class="row">
	
				<div class="row">
                    		<div class="col-2">NBPDCL + Dg Energy</div >
					<div class="col-2" >
						<asp:Label id="lblKp_Dg" runat="server" Width="116px">0</asp:Label></div >
					<div class="col-2">Total Energy</div >
					<div class="col-2">
						<asp:Label id="lblTotalEnergy" runat="server" Width="116px">0</asp:Label></div >
				</div><br />
				<div class="row">
			
					<div class="col-2">Total Steel Scrap Melted</div >
					<div class="col-2"><asp:textbox id="txtTotal_Steel_Scrap" runat="server" CssClass="form-control"></asp:textbox></div >
                      <div class="col-2">PCS</div >
					<div class="col-2"><asp:textbox id="txtPCS" runat="server" CssClass="form-control"></asp:textbox></div >
                       <div class="col-2">Pump</div >
					<div class="col-2"><asp:textbox id="txtpump" runat="server" CssClass="form-control"></asp:textbox></div >
				</div ><br />

                  <div class="row">
                    <div class="col-2">Stn Aux</div >
					<div class="col-2"><asp:textbox id="txtstn_aux" runat="server" CssClass="form-control"></asp:textbox></div >
                      	<div class="col-2">Difference in Energy</div >
					<div class="col-2" >
						<asp:Label id="lblDiff" runat="server" Width="116px">0</asp:Label></div >
                </div ><br />

				<div class="row">
                    <div class="col-2">
						<asp:button id="btnCalculateEnergy" runat="server" CssClass="btn btn-default" Font-Bold="True" Font-Names="Arial" Font-Size="Medium" Text="Calculate Energy"></asp:button></div >
					<div class="col-2"></div >
				</div ><br />
			</div >

                        <div id="Table2" class="table">
							<div class="row">
                                
								<div class="col-2"></div >
								<div class="col-2">CODE</div >
								<div class="col-2">AF-I</div >
								<div class="col-2">AF-II</div >
								<div class="col-2">AF-III</div >
                                <div class="col-2"></div >
							</div ><br />
							<div class="row">
                                 <div class="col-2"></div >
								<div class="col-2">A</div >
								<div class="col-2">
									<asp:textbox id="txtaa" runat="server" CssClass="form-control">0</asp:textbox></div >
								<div class="col-2">
									<asp:textbox id="txtab" runat="server" CssClass="form-control">0</asp:textbox></div >
								<div class="col-2">
									<asp:textbox id="txtac" runat="server" CssClass="form-control">0</asp:textbox></div >
							</div ><br />
							<div class="row">
                                 <div class="col-2"></div >
								<div class="col-2">B</div >
								<div class="col-2">
									<asp:textbox id="txtba" runat="server" CssClass="form-control">0</asp:textbox></div >
								<div class="col-2">
									<asp:textbox id="txtbb" runat="server" CssClass="form-control">0</asp:textbox></div >
								<div class="col-2">
									<asp:textbox id="txtbc" runat="server" CssClass="form-control">0</asp:textbox></div >
							</div ><br />
							<div class="row">
                                 <div class="col-2"></div >
								<div class="col-2">C</div >
								<div class="col-2">
									<asp:textbox id="txtca" runat="server" CssClass="form-control">0</asp:textbox></div >
								<div class="col-2">
									<asp:textbox id="txtcb" runat="server" CssClass="form-control">0</asp:textbox></div >
								<div class="col-2">
									<asp:textbox id="txtcc" runat="server" CssClass="form-control">0</asp:textbox></div >
							</div ><br />
							<div class="row">
                                 <div class="col-2"></div >
								<div class="col-2">D</div >
								<div class="col-2">
									<asp:textbox id="txtda" runat="server" CssClass="form-control">0</asp:textbox></div >
								<div class="col-2">
									<asp:textbox id="txtdb" runat="server" CssClass="form-control">0</asp:textbox></div >
								<div class="col-2">
									<asp:textbox id="txtdc" runat="server" CssClass="form-control">0</asp:textbox></div >
							</div ><br />
							<div class="row">
                                 <div class="col-2"></div >
								<div class="col-2">E</div >
								<div class="col-2">
									<asp:TextBox id="txtea" runat="server" CssClass="form-control">0</asp:TextBox></div >
								<div class="col-2">
									<asp:TextBox id="txteb" runat="server" CssClass="form-control">0</asp:TextBox></div >
								<div class="col-2">
									<asp:TextBox id="txtec" runat="server" CssClass="form-control">0</asp:TextBox></div >
							</div ><br />
							<div class="row">
                                 <div class="col-2"></div >
								<div class="col-2">TOTAL</div >
								<div class="col-2">
									<asp:Label id="lblTotalA" runat="server" CssClass="form-control">0</asp:Label></div >
								<div class="col-2">
									<asp:Label id="lblTotalB" runat="server" CssClass="form-control">0</asp:Label></div >
								<div class="col-2">
									<asp:Label id="lblTotalC" runat="server" CssClass="form-control">0</asp:Label></div >
							</div ><br />
							<div class="row">
                                 <div class="col-2"></div >
								<div class="col-2" >TOTAL NO. OF HEATS</div>
									 <div class="col-2"><asp:Label id="lblTotalABC" runat="server" Width="116px">0</asp:Label></div >
							</div ><br />
							<div class="row">
                                 <div class="col-2"></div >
								<div class="col-2">
									<asp:button id="txtCalculateHeat" runat="server" CssClass="btn btn-default" Font-Bold="True" Font-Names="Arial" Font-Size="Medium" Text="Calculate Heats"></asp:button></div >
							</div ><br />
                   <div class="row">
					<div class="col-12" align="center">
						<asp:button id="btnSave" runat="server" Text="Save" CssClass="btn btn-dark" Font-Bold="True" Font-Names="Arial" Font-Size="Medium"></asp:button>
						<asp:button id="btnCancel" runat="server" Text="Clear" CssClass="btn btn-dark" Font-Bold="True" Font-Names="Arial" Font-Size="Medium"></asp:button>
						<asp:button id="btnExit" runat="server" Text="Exit" CausesValidation="False" CssClass="btn btn-dark" Font-Bold="True" Font-Names="Arial" Font-Size="Medium"></asp:button>
			</div>
				</div><br />
						</div >
		</div> </div></form>
            </div>
        <div class="card-footer" style="text-align:right;background-color:#cccccc; vertical-align:middle;height:45px; width:100%; bottom:0;"><h4 style="color: black;font-size:15px;">MAINTAINED BY CRIS</h4></div>
	</body>
    </html>
