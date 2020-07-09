<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ShopWiseDailyEnergyConsumption.aspx.vb" Inherits="WebApplication2.ShopWiseDailyEnergyConsumption" Culture="en-GB" uiCulture="en-GB" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
	<HEAD runat="server">
			<title>Shopwise Daily Energy Consumption Edit</title>
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
	<body style="overflow-x:hidden">

      <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
  <a class="navbar-brand p-0" href="#"><img src="../../../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent-333"
    aria-controls="navbarSupportedContent-333" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>
  <div class="collapse navbar-collapse " id="navbarSupportedContent-333">
      <ul class="navbar-nav ml-auto  navbar-center">
          <li class="nav-item" style="font-weight: bold">
             <h1 style="color:white; font-size:30px; margin-left:430px; margin-top:5px">Rail Wheel Plant, Bela</h1> 
       
         </li>
          <%--<li class="nav-item"> <a class="nav-link" href="#" style="color:white; font-size:25px;">Rail Wheel Plant Bela</a></li>--%>
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
         <%--<img src="../../NewFolder1/CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="45"/>--%>
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
						<div class="col-12" align="center" ><h4>MAIN RECEIVING STATION</h4></div>
				</div>
				<div class="row">
						<div class="col-12" align="center" ><h4>DAILY ENERGY CONSUMPTION STATEMENT, SHOPWISE</h4></div>
				</div><br />
				<div class="row">
						<div class="col-12" align="center">
                            <asp:label id="lblMode" runat="server" Width="101px" ForeColor="Blue" Font-Bold="True" Font-Names="Arial" Font-Size="Smaller"></asp:label></div>
				</div><br />
			<div class="row">
						<div class="col-12"><asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></div>
				</div><br />
		
                    	<div class="row">
						<div class="col-2">Date</div>
							<div class="col-2"><asp:textbox id="txtDate" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox></div>
							<div class="col-2"><asp:rangevalidator id="RangeValidator1" runat="server" ControlToValidate="txtDate" ErrorMessage="*" MinimumValue="1/1/1900" MaximumValue="1/1/9999" Type="Date"></asp:rangevalidator></div>
							<div class="col-2"><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtDate"></asp:requiredfieldvalidator></div>
					</div><br />
				<div class="row">
					<div class="col-2">SL.NO.</div>
					<div class="col-2">DESCRIPTION</div>
					<div class="col-2">UNIT CONSUMPTION in KWh</div>
					<div class="col-2">REMARKS</div>
				</div><br />
				<div class="row">
					<div class="col-2">1.</div>
					<div class="col-2">NBPDCL Consumption</div>
                    <%--<span style="color: rgb(0, 0, 0); font-family: docs-Calibri; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: pre-wrap; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">N. B. P. D. C. L </span>. Consumption</div>--%>
					<div class="col-2"><asp:label id="lblKPTCL" runat="server" Width="85px"></asp:label></div>
					<div class="col-2"><asp:textbox id="txtKPTCL" runat="server" CssClass="form-control"></asp:textbox></div>
				</div><br />
				<div class="row">
					<div class="col-2">2.</div>
					<div class="col-2">D.G. Energy Generated</div>
					<div class="col-2"><asp:label id="lblGenerated" runat="server" Width="85px"></asp:label></div>
					<div class="col-2"><asp:textbox id="txtGenerated" runat="server" CssClass="form-control"></asp:textbox></div>
				</div><br />
				<div class="row">
					<div class="col-2">3.</div>
					<div class="col-2">ARC Furnace No. I</div>
					<div class="col-2"><asp:label id="lblArc1" runat="server" Width="85px"></asp:label></div>
					<div class="col-2"><asp:textbox id="txtArc1" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox></div>
				</div><br />
				<div class="row">
					<div class="col-2">4.</div>
					<div class="col-2">ARC Furnace No. II</div>
					<div class="col-2"><asp:label id="lblArc2" runat="server" Width="85px"></asp:label></div>
					<div class="col-2"><asp:textbox id="txtArc2" runat="server" CssClass="form-control"></asp:textbox></div>
				</div><br />
				<div class="row">
					<div class="col-2">5.</div>
					<div class="col-2">ARC Furnace No. III</div>
					<div class="col-2"><asp:label id="lblArc3" runat="server" Width="85px"></asp:label></div>
					<div class="col-2"><asp:textbox id="txtArc3" runat="server" CssClass="form-control"></asp:textbox></div>
				</div><br />
				<div class="row">
					<div class="col-2">6.</div>
					<div class="col-2">Pump House Sub-Station</div>
					<div class="col-2"><asp:label id="lblPump" runat="server" Width="85px"></asp:label></div>
					<div class="col-2"><asp:textbox id="txtPump" runat="server" CssClass="form-control"></asp:textbox></div>
				</div><br />
				<div class="row">
					<div class="col-2">7.</div>
					<div class="col-2">&nbsp;MELT Sub Station</div>
					<div class="col-2"><asp:label id="lblWheelEssential" runat="server" Width="85px"></asp:label></div>
					<div class="col-2"><asp:textbox id="txtWheelEssential" runat="server" CssClass="form-control"></asp:textbox></div>
				</div><br />
                <%--<div class="row">
					<div class="col-2">8.</div>
					<div class="col-2">Wheel Shop Sub-Station (Non-essential)</div>
					<div class="col-2"><asp:label id="lblWheelNonEssential" runat="server" Width="85px"></asp:label></div>
					<div class="col-2"><asp:textbox id="txtWheelNonEssential" runat="server" CssClass="form-control"></asp:textbox></div>
				</div>--%>
				<div class="row">
					<div class="col-2">8.</div>
					<div class="col-2">Tube Pre-heat Sub-Station</div>
					<div class="col-2"><asp:label id="lblTube" runat="server" Width="85px"></asp:label></div>
					<div class="col-2"><asp:textbox id="txtTube" runat="server" CssClass="form-control"></asp:textbox></div>
				</div><br />
				<div class="row">
					<div class="col-2">9.</div>
					<div class="col-2">Mould Pre-heat Sub-Station</div>
					<div class="col-2"><asp:label id="lblMould" runat="server" Width="85px"></asp:label></div>
					<div class="col-2"><asp:textbox id="txtMould" runat="server" CssClass="form-control"></asp:textbox></div>
				</div><br />
				<div class="row">
					<div class="col-2">10.</div>
					<div class="col-2">Fume Sub-Station</div>
					<div class="col-2"><asp:label id="lblFume" runat="server" Width="85px"></asp:label></div>
					<div class="col-2"><asp:textbox id="txtFume" runat="server" CssClass="form-control"></asp:textbox></div>
				</div><br />
				<div class="row">
					<div class="col-2">11.</div>
					<div class="col-2">Compressor Sub-Station</div>
					<div class="col-2"><asp:label id="lblCompressor" runat="server" Width="85px"></asp:label></div>
					<div class="col-2"><asp:textbox id="txtCompressor" runat="server" CssClass="form-control"></asp:textbox></div>
				</div><br />
				<%--<div class="row">
					<div class="col-2">13.</div>
					<div class="col-2">Assembly Shop Sub-Station</div>
					<div class="col-2"><asp:label id="lblAssembly" runat="server" Width="85px"></asp:label></div>
					<div class="col-2"><asp:textbox id="txtAssembly" runat="server" CssClass="form-control"></asp:textbox></div>
				</div>
				<div class="row">
					<div class="col-2">14.</div>
					<div class="col-2">Axle Shop Sub-Station (Essential)</div>
					<div class="col-2"><asp:label id="lblAxelEssential" runat="server" Width="85px"></asp:label></div>
					<div class="col-2"><asp:textbox id="txtAxelEssential" runat="server" CssClass="form-control"></asp:textbox></div>
				</div>
				<div class="row">
					<div class="col-2">15.</div>
					<div class="col-2">Axle Shop Sub-Station (Non-essential)</div>
					<div class="col-2"><asp:label id="lblAxelNonEssential" runat="server" Width="85px"></asp:label></div>
					<div class="col-2"><asp:textbox id="txtAxelNonEssential" runat="server" CssClass="form-control"></asp:textbox></div>
				</div>
				<div class="row">
					<div class="col-2">16.</div>
					<div class="col-2">G.F.M. Sub-Station</div>
					<div class="col-2"><asp:label id="lblGFM" runat="server" Width="85px"></asp:label></div>
					<div class="col-2"><asp:textbox id="txtGFM" runat="server" CssClass="form-control"></asp:textbox></div>
				</div>
				<div class="row">
					<div class="col-2">17.</div>
					<div class="col-2">Canteen Sub-Station</div>
					<div class="col-2"><asp:label id="lblCanteen" runat="server" Width="85px"></asp:label></div>
					<div class="col-2"><asp:textbox id="txtCanteen" runat="server" CssClass="form-control"></asp:textbox></div>
				</div>
				--%>
                <div class="row">
					<div class="col-2">12.</div>
					<div class="col-2">Colony Sub Station (1&2)</div>
					<div class="col-2"><asp:label id="lblColony" runat="server" Width="85px"></asp:label></div>
					<div class="col-2"><asp:textbox id="txtColony" runat="server" CssClass="form-control"></asp:textbox></div>
				</div><br />
                <div class="row">
					<div class="col-2">13.</div>
					<div class="col-2">Colony Sub Station (3&4)</div>
					<div class="col-2"><asp:label id="lblColony1" runat="server" Width="85px"></asp:label></div>
					<div class="col-2"><asp:textbox id="txtColony1" runat="server" CssClass="form-control"></asp:textbox></div>
				</div><br />
				<div class="row">
					<div class="col-2">14.</div>
					<div class="col-2">Admn. Bldg.ddd</div>
					<div class="col-2"><asp:label id="lblAdmin" runat="server" Width="85px"></asp:label></div>
					<div class="col-2"><asp:textbox id="txtAdmin" runat="server" CssClass="form-control"></asp:textbox></div>
				</div><br />
				<div class="row">
					<div class="col-2">15.</div>
					<div class="col-2">Station Aux.</div>
					<div class="col-2"><asp:label id="lblAux" runat="server" Width="85px"></asp:label></div>
					<div class="col-2"><asp:textbox id="txtAux" runat="server" CssClass="form-control"></asp:textbox></div>
				</div><br />
				<%--<div class="row">
					<div class="col-2" >21.</div>
					<div class="col-2" >E.M.M.S. Sub-Station</div>
					<div class="col-2" ><asp:label id="lblEmms" runat="server" Width="85px"></asp:label></div>
					<div class="col-2" ><asp:textbox id="txtEmms" runat="server" CssClass="form-control" ></asp:textbox></div>
				</div>
				<div class="row">
					<div class="col-2" >22.</div>
					<div class="col-2" >DCOS</div>
					<div class="col-2" ><asp:label id="lblDCOS" runat="server" Width="85px"></asp:label></div>
					<div class="col-2" ><asp:textbox id="txtDcos" runat="server" CssClass="form-control"></asp:textbox></div>
				</div>
				<div class="row">
					<div class="col-2" >23.</div>
					<div class="col-2" >Liquid Oxygen Plant</div>
					<div class="col-2" >
						<asp:label id="lblLop" runat="server" Width="85px"></asp:label></div>
					<div class="col-2" >
						<asp:textbox id="txtLop" runat="server" CssClass="form-control"></asp:textbox></div>
				</div>
				--%>
                <div class="row">
					<div class="col-2" >16.</div>
					<div class="col-2" >RWP Generation</div>
					<div class="col-2" >
						<asp:label id="lblRwfgen" runat="server" Width="85px"></asp:label></div>
					<div class="col-2" >
						<asp:textbox id="txtRwfgen" runat="server" CssClass="form-control"></asp:textbox></div>
				</div><br />
                <div class="row">
					<div class="col-2" >17.</div>
					<div class="col-2" >PCS</div>
					<div class="col-2" >
						<asp:label id="lblPCS" runat="server" Width="85px"></asp:label></div>
					<div class="col-2" >
						<asp:textbox id="txtPCS" runat="server" CssClass="form-control"></asp:textbox></div>
				</div><br />
                <%--<div class="row">
					<div class="col-2" >25.</div>
					<div class="col-2" >Check Meter</div>
					<div class="col-2" >
						<asp:label id="lblCheckMeter" runat="server" Width="85px"></asp:label></div>
					<div class="col-2" >
						<asp:TextBox id="txtCheckMeter" runat="server" CssClass="form-control"></asp:TextBox></div>
				</div>--%>
				</div>
						<div id="Table5" class="table">
							<div class="row">
								<div class="col-2" >Code</div>
								<div class="col-2" >AF-A</div>
								<div class="col-2" >AF-B</div>
								<div class="col-2" >AF-C</div>
							</div><br />
							<div class="row">
								<div class="col-2" >a</div>
								<div class="col-2" >
									<asp:label id="lblAF_Aa" runat="server"></asp:label></div>
								<div class="col-2" >
									<asp:label id="lblAF_Ba" runat="server"></asp:label></div>
								<div class="col-2" >
									<asp:label id="lblAF_Ca" runat="server"></asp:label></div>
							</div><br />
							<div class="row">
								<div class="col-2" >b</div>
								<div class="col-2" >
									<asp:label id="lblAF_Ab" runat="server"></asp:label></div>
								<div class="col-2" >
									<asp:label id="lblAF_Bb" runat="server"></asp:label></div>
								<div class="col-2" >
									<asp:label id="lblAF_Cb" runat="server"></asp:label></div>
							</div><br />
							<div class="row">
								<div class="col-2" >c</div>
								<div class="col-2" ">
									<asp:label id="lblAF_Ac" runat="server"></asp:label></div>
								<div class="col-2" >
									<asp:label id="lblAF_Bc" runat="server"></asp:label></div>
								<div class="col-2" >
									<asp:label id="lblAF_Cc" runat="server"></asp:label></div>
							</div><br />
							<div class="row">
								<div class="col-2" >d</div>
								<div class="col-2" >
									<asp:label id="lblAF_Ad" runat="server"></asp:label></div>
								<div class="col-2" >
									<asp:label id="lblAF_Bd" runat="server"></asp:label></div>
								<div class="col-2" >
									<asp:label id="lblAF_Cd" runat="server"></asp:label></div>
							</div><br />
							<div class="row">
								<div class="col-2" >e</div>
								<div class="col-2" >
									<asp:label id="lblAF_Ae" runat="server"></asp:label></div>
								<div class="col-2" >
									<asp:label id="lblAF_Be" runat="server"></asp:label></div>
								<div class="col-2" >
									<asp:label id="lblAF_Ce" runat="server"></asp:label></div>
							</div><br />
							<div class="row">
								<div class="col-2" >Total</div>
								<div class="col-2" >
									<asp:label id="lblTotalAF_A" runat="server"></asp:label></div>
								<div class="col-2" >
									<asp:label id="lblTotalAF_B" runat="server"></asp:label></div>
								<div class="col-2" >
									<asp:label id="lblTotalAF_C" runat="server"></asp:label></div>
							</div><br />
							<div class="row">
								<div class="col-2" >Total Tonnage</div>
								<div class="col-2" ><asp:label id="lblTotalTonnageforDay" runat="server"></asp:label></div>
							</div><br />

                            <div class="row">
					<div class="col-12" align="center"><asp:button id="btnSubmit_Clicks" runat="server" Text="Save" CssClass="btn btn-dark" Font-Bold="True" Font-Names="Arial" Font-Size="Medium"></asp:button>
                        <asp:button id="btnCancel" runat="server" Text="Clear" CssClass="btn btn-dark" Font-Bold="True" Font-Names="Arial" Font-Size="Medium"></asp:button>
                        <asp:button id="btnExit" runat="server" Text="Exit" CausesValidation="False" CssClass="btn btn-dark" Font-Bold="True" Font-Names="Arial" Font-Size="Medium"></asp:button></div>
				</div><br />
						</div>	
		
		</div></form>
            </div>
             <%-- <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS </h4></div>--%>
        <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;height:45px; width:100%; bottom:0;"><h4 style="color: black;font-size:15px;">MAINTAINED BY CRIS</h4></div>
	</body>
</html>