<%@ Page Language="vb" AutoEventWireup="false" Codebehind="AdminEnergyConsumptionEdit.aspx.vb" Inherits="WebApplication2.AdminEnergyConsumptionEdit" Culture="en-GB" uiCulture="en-GB" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>AdminEnergyConsumption</title>
	
        <LINK id="mss" href="/wap.css" rel="stylesheet"/>
		<META content="Microsoft Visual Studio.NET 7.0" name="GENERATOR"/>
		<META content="Visual Basic 7.0" name="CODE_LANGUAGE"/>
		<META content="JavaScript" name="vs_defaultClientScript"/>
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
        
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css"/>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js" type="text/javascript"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js" type="text/javascript"></script>
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
             position: relative;
             width: 100%;
             -ms-flex-preferred-size: 0;
             flex-basis: 0;
             -ms-flex-positive: 1;
             flex-grow: 1;
             max-width: 100%;
             left: 0px;
             top: 0px;
             padding-left: 15px;
             padding-right: 15px;
         }
         </style>
        </head>
	<body>
           
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
    
<!--/.Navbar -->
        <div class="container">

		<FORM id="Form1" method="post" runat="server">
              <div class="row">
    
                 <%-- <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" >
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
      </div>
            <div class="table">

				<div  class="row">
					<div  class="col"  colSpan="7"><STRONG>&nbsp;ADMIN</STRONG></div >
					<div  class="col" ></div >
				</div >
				<div  class="row">
					<div  class="col"  colSpan="7">DAILY ENERGY CONSUMPTION STATEMENT</div >
					<div  class="col" ></div >
				</div >
				<div  class="row">
					<div  class="col"  colSpan="7" rowSpan="1"><asp:label id="lblMode" runat="server" ForeColor="Blue" Font-Bold="True" Font-Names="Arial" Font-Size="Smaller" Width="101px"></asp:label></div >
					<div  class="col" ></div >
				</div >
				<div  class="row">
					<div  class="col"  colSpan="7" rowSpan="1"><asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></div >
					<div  class="col" ></div >
				</div >
				<div  class="row">
					<div  class="col"  colSpan="7">DATE : </div>
                        <div class="col"><asp:textbox id="txtDate" runat="server" CssClass="form-control" AutoPostBack="True" Width="103px"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtDate" ErrorMessage="*"></asp:requiredfieldvalidator><asp:rangevalidator id="RangeValidator1" runat="server" ControlToValidate="txtDate" ErrorMessage="*" MinimumValue="1/1/1900" MaximumValue="1/1/9999" Type="Date"></asp:rangevalidator></div >
					<div  class="col" >
                         <asp:button id="btnCalculateAll" runat="server" Text="Calculate All"  Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" ></asp:button>
				</div >
                    
				<div class="col"></div >
                    <div class="col"></div >
                    <div class="col"></div >
                   
                    </div>
				<div  class="row">
					<div  class="col" >SL NO</div >
					<div  class="col" >DESCRIPTION</div >
					<div  class="col" >INITIAL READING</div >
					<div  class="col" >FINAL READING</div >
					<div  class="col" >
						<P>DIFFERENCE</P>
					</div >
					<div  class="col" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; M.F</div >
					<div  class="col" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; UNIT CONSUMPTION</div >
					<div  class="col" >PROGRESSIVE UNITS FOR THE MONTH</div >
				</div >
				<div  class="row">
					<div  class="col" >01</div >
					<div  class="col" >NBPDCL Consumption</div >
					<div  class="col" ><asp:textbox id="txtKPTCL_initial" runat="server" CssClass="form-control"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ControlToValidate="txtKPTCL_initial" ErrorMessage="*"></asp:requiredfieldvalidator></div >
					<div  class="col" >
						<P><asp:textbox id="txtKPTCL_final" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox><asp:rangevalidator id="RangeValidator7" runat="server" ControlToValidate="txtKPTCL_final" ErrorMessage="*" MinimumValue="0" MaximumValue="999999999999999" Type="Double"></asp:rangevalidator><asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" ControlToValidate="txtKPTCL_final" ErrorMessage="*"></asp:requiredfieldvalidator></P>
					</div >
					<div  class="col"  colSpan="1" rowSpan="1"><asp:label id="lblDIFF_kptcl" runat="server" Width="75" Height="16"></asp:label></div >
					<div  class="col" ><asp:dropdownlist id="ddlMFkptcl" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></div >
					<div  class="col" ><asp:label id="lblKPTCL_unit" runat="server" Width="159" Height="16"></asp:label></div >
					<div  class="col" ><asp:label id="lblKPTCL_month" runat="server"></asp:label></div >
				</div >
				<div  class="row">
					<div  class="col" >02</div >
					<div  class="col" >D.G. Energy Generated</div >
					<div  class="col" ><asp:textbox id="txtDGGenI_initial" runat="server" CssClass="form-control"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" ControlToValidate="txtDGGenI_initial" ErrorMessage="*"></asp:requiredfieldvalidator></div >
					<div  class="col" ><asp:textbox id="txtDGGenI_final" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox><asp:rangevalidator id="RangeValidator8" runat="server" ControlToValidate="txtDGGenI_final" ErrorMessage="*" MinimumValue="0" MaximumValue="999999999999999" Type="Double"></asp:rangevalidator><asp:requiredfieldvalidator id="RequiredFieldValidator19" runat="server" ControlToValidate="txtDGGenI_final" ErrorMessage="*"></asp:requiredfieldvalidator></div >
					<div  class="col"  colSpan="1" rowSpan="1"><asp:label id="lblDIFF_dgI" runat="server" Width="75px" Height="16px"></asp:label></div >
					<div  class="col" ><asp:dropdownlist id="ddlMFdgI" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></div >
					<div  class="col" ><asp:label id="lblDGGenI_unit" runat="server" Width="159px" Height="16px"></asp:label></div >
					<div  class="col"  colSpan="1" rowSpan="1"><asp:label id="lblDGGenI_month" runat="server" Width="75px"></asp:label></div >
				</div >
				<%--<div  class="row">
					<div  class="col" >03</div >
					<div  class="col" >D.G. Energy Gen II</div >
					<div  class="col" ><asp:textbox id="txtDGGenII_initial" runat="server" CssClass="form-control"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator24" runat="server" ControlToValidate="txtDGGenII_initial" ErrorMessage="*"></asp:requiredfieldvalidator></div >
					<div  class="col" ><asp:textbox id="txtDGGenII_final" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox><asp:rangevalidator id="Rangevalidator25" runat="server" ControlToValidate="txtDGGenII_final" ErrorMessage="*" MinimumValue="0" MaximumValue="999999999999999" Type="Double"></asp:rangevalidator><asp:requiredfieldvalidator id="Requiredfieldvalidator25" runat="server" ControlToValidate="txtDGGenII_final" ErrorMessage="*"></asp:requiredfieldvalidator></div >
					<div  class="col" ><asp:label id="lblDIFF_dgII" runat="server" Width="87px"></asp:label></div >
					<div  class="col" ><asp:dropdownlist id="ddlMFdgII" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></div >
					<div  class="col" ><asp:label id="lblDGGenII_unit" runat="server" Width="150px"></asp:label></div >
					<div  class="col" ><asp:label id="lblDGGenII_month" runat="server" Width="85px"></asp:label></div >
				</div >
				<div  class="row">
					<div  class="col" >04</div >
					<div  class="col" >D.G.Energy Gen III</div >
					<div  class="col" ><asp:textbox id="txtDGGenIII_initial" runat="server" CssClass="form-control"></asp:textbox></div >
					<div  class="col" ><asp:textbox id="txtDGGenIII_final" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox></div >
					<div  class="col" ><asp:label id="lblDIFF_dgIII" runat="server" Width="87px"></asp:label></div >
					<div  class="col" ><asp:dropdownlist id="ddlMFdgIII" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></div >
					<div  class="col" ><asp:label id="lblDGGenIII_unit" runat="server" Width="150px"></asp:label></div >
					<div  class="col" ><asp:label id="lblDGGenIII_month" runat="server" Width="85px"></asp:label></div >
				</div >--%>
				<div  class="row">
					<div  class="col" >03</div >
					<div  class="col" >ARC Furnace No. A</div >
					<div  class="col" ><asp:textbox id="txtArc1_initial" runat="server" CssClass="form-control"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" ControlToValidate="txtArc1_initial" ErrorMessage="*"></asp:requiredfieldvalidator></div >
					<div  class="col" ><asp:textbox id="txtArc1_final" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox><asp:rangevalidator id="RangeValidator9" runat="server" ControlToValidate="txtArc1_final" ErrorMessage="*" MinimumValue="0" MaximumValue="999999999999999" Type="Double"></asp:rangevalidator><asp:requiredfieldvalidator id="RequiredFieldValidator18" runat="server" ControlToValidate="txtArc1_final" ErrorMessage="*"></asp:requiredfieldvalidator></div >
					<div  class="col"  colSpan="1" rowSpan="1"><asp:label id="lblDIFF_arc1" runat="server" Width="75px" Height="16px"></asp:label></div >
					<div  class="col" ><asp:dropdownlist id="ddlMFarcA" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></div >
					<div  class="col"  colSpan="1" rowSpan="1"><asp:label id="lblArc1_unit" runat="server" Width="159px" Height="16px"></asp:label></div >
					<div  class="col"  colSpan="1" rowSpan="1"><asp:label id="lblArc1_month" runat="server"></asp:label></div >
				</div >
				<div  class="row">
					<div  class="col" >04</div >
					<div  class="col" >ARC Furnace No. B</div >
					<div  class="col" ><asp:textbox id="txtArc2_initial" runat="server" CssClass="form-control"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server" ControlToValidate="txtArc2_initial" ErrorMessage="*"></asp:requiredfieldvalidator></div >
					<div  class="col" ><asp:textbox id="txtArc2_final" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox><asp:rangevalidator id="RangeValidator10" runat="server" ControlToValidate="txtArc2_final" ErrorMessage="*" MinimumValue="0" MaximumValue="10000000" Type="Double"></asp:rangevalidator><asp:requiredfieldvalidator id="RequiredFieldValidator17" runat="server" ControlToValidate="txtArc2_final" ErrorMessage="*"></asp:requiredfieldvalidator></div >
					<div  class="col"  colSpan="1" rowSpan="1"><asp:label id="lblDIFF_arc2" runat="server" Width="75px" Height="16px"></asp:label></div >
					<div  class="col" ><asp:dropdownlist id="ddlMFarcB" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></div >
					<div  class="col"  colSpan="1" rowSpan="1"><asp:label id="lblArc2_unit" runat="server" Width="159px" Height="16px"></asp:label></div >
					<div  class="col"  colSpan="1" rowSpan="1"><asp:label id="lblArc2_month" runat="server"></asp:label></div >
				</div >
				<div  class="row">
					<div  class="col" >05</div >
					<div  class="col" >ARC Furnace No. C</div >
					<div  class="col" ><asp:textbox id="txtArc3_initial" runat="server" CssClass="form-control"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator7" runat="server" ControlToValidate="txtArc3_initial" ErrorMessage="*"></asp:requiredfieldvalidator></div >
					<div  class="col" ><asp:textbox id="txtArc3_final" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox><asp:rangevalidator id="RangeValidator11" runat="server" ControlToValidate="txtArc3_final" ErrorMessage="*" MinimumValue="0" MaximumValue="999999999999999" Type="Double"></asp:rangevalidator><asp:requiredfieldvalidator id="RequiredFieldValidator16" runat="server" ControlToValidate="txtArc3_final" ErrorMessage="*"></asp:requiredfieldvalidator></div >
					<div  class="col"  colSpan="1" rowSpan="1"><asp:label id="lblDIFF_arc3" runat="server" Width="75px" Height="16px"></asp:label></div >
					<div  class="col" ><asp:dropdownlist id="ddlMFarcC" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></div >
					<div  class="col"  colSpan="1" rowSpan="1"><asp:label id="lblArc3_unit" runat="server" Width="159px" Height="16px"></asp:label></div >
					<div  class="col"  colSpan="1" rowSpan="1"><asp:label id="lblArc3_month" runat="server"></asp:label></div >
				</div >
				<div  class="row">
					<div  class="col" >06</div >
					<div  class="col" >Pump House Sub-Station</div >
					<div  class="col" ><asp:textbox id="txtPump_initial" runat="server" CssClass="form-control"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator8" runat="server" ControlToValidate="txtPump_initial" ErrorMessage="*"></asp:requiredfieldvalidator></div >
					<div  class="col" ><asp:textbox id="txtPump_final" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox><asp:rangevalidator id="RangeValidator13" runat="server" ControlToValidate="txtPump_final" ErrorMessage="*" MinimumValue="0" MaximumValue="999999999999999" Type="Double"></asp:rangevalidator><asp:requiredfieldvalidator id="RequiredFieldValidator15" runat="server" ControlToValidate="txtPump_final" ErrorMessage="*"></asp:requiredfieldvalidator></div >
					<div  class="col"  colSpan="1" rowSpan="1"><asp:label id="lblDIFF_pump" runat="server" Width="75px" Height="16px"></asp:label></div >
					<div  class="col" ><asp:dropdownlist id="ddlMFpump" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></div >
					<div  class="col"  colSpan="1" rowSpan="1"><asp:label id="lblPump_unit" runat="server" Width="159px" Height="16px"></asp:label></div >
					<div  class="col"  colSpan="1" rowSpan="1"><asp:label id="lblPump_month" runat="server"></asp:label></div >
				</div >

                <div  class="row">
					<div  class="col" >07</div >
					<div  class="col" >Melt Sub-Station</div >
					<div  class="col" ><asp:textbox id="MeltESS_initial" runat="server" CssClass="form-control"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator24" runat="server" ControlToValidate="MeltESS_initial" ErrorMessage="*"></asp:requiredfieldvalidator></div >
					<div  class="col" ><asp:textbox id="MeltESS_final" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox><asp:rangevalidator id="RangeValidator2" runat="server" ControlToValidate="MeltESS_final" ErrorMessage="*" MinimumValue="0" MaximumValue="999999999999999" Type="Double"></asp:rangevalidator><asp:requiredfieldvalidator id="RequiredFieldValidator25" runat="server" ControlToValidate="MeltESS_final" ErrorMessage="*"></asp:requiredfieldvalidator></div >
					<div  class="col"  colSpan="1" rowSpan="1"><asp:label id="lblDIFF_MeltESS" runat="server" Width="75px" Height="16px"></asp:label></div >
					<div  class="col" ><asp:dropdownlist id="ddlMeltESS" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></div >
					<div  class="col"  colSpan="1" rowSpan="1"><asp:label id="lblMeltESS_unit" runat="server" Width="159px" Height="16px"></asp:label></div >
					<div  class="col"  colSpan="1" rowSpan="1"><asp:label id="lblMeltESS_month" runat="server"></asp:label></div >
				</div >

                 <div  class="row">
					<div  class="col" >08</div >
					<div  class="col" >Tube Pre-heat Sub-Station</div >
					<div  class="col" ><asp:textbox id="TubePHESS_initial" runat="server" CssClass="form-control"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator26" runat="server" ControlToValidate="TubePHESS_initial" ErrorMessage="*"></asp:requiredfieldvalidator></div >
					<div  class="col" ><asp:textbox id="TubePHESS_final" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox><asp:rangevalidator id="RangeValidator3" runat="server" ControlToValidate="TubePHESS_final" ErrorMessage="*" MinimumValue="0" MaximumValue="999999999999999" Type="Double"></asp:rangevalidator><asp:requiredfieldvalidator id="RequiredFieldValidator27" runat="server" ControlToValidate="TubePHESS_final" ErrorMessage="*"></asp:requiredfieldvalidator></div >
					<div  class="col"  colSpan="1" rowSpan="1"><asp:label id="lblDIFF_TubePHESS" runat="server" Width="75px" Height="16px"></asp:label></div >
					<div  class="col" ><asp:dropdownlist id="ddlTubePHESS" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></div >
					<div  class="col"  colSpan="1" rowSpan="1"><asp:label id="TubePHESS_unit" runat="server" Width="159px" Height="16px"></asp:label></div >
					<div  class="col"  colSpan="1" rowSpan="1"><asp:label id="TubePHESS_month" runat="server"></asp:label></div >
				</div >

                <div  class="row">
					<div  class="auto-style1" >09</div >
					<div  class="col" >Mould Pre-heat Sub-Station</div >
					<div  class="col" ><asp:textbox id="MouldPHESS_initial" runat="server" CssClass="form-control"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator28" runat="server" ControlToValidate="MouldPHESS_initial" ErrorMessage="*"></asp:requiredfieldvalidator></div >
					<div  class="col" ><asp:textbox id="MouldPHESS_final" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox><asp:rangevalidator id="RangeValidator4" runat="server" ControlToValidate="MouldPHESS_final" ErrorMessage="*" MinimumValue="0" MaximumValue="999999999999999" Type="Double"></asp:rangevalidator><asp:requiredfieldvalidator id="RequiredFieldValidator29" runat="server" ControlToValidate="MouldPHESS_final" ErrorMessage="*"></asp:requiredfieldvalidator></div >
					<div  class="col"  colSpan="1" rowSpan="1"><asp:label id="lblDIFF_MouldPHESS" runat="server" Width="75px" Height="16px"></asp:label></div >
					<div  class="col" ><asp:dropdownlist id="ddlMouldPHESS" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></div >
					<div  class="col"  colSpan="1" rowSpan="1"><asp:label id="MouldPHESS_unit" runat="server" Width="159px" Height="16px"></asp:label></div >
					<div  class="col"  colSpan="1" rowSpan="1"><asp:label id="MouldPHESS_month" runat="server"></asp:label></div >
				</div >
                <div  class="row">
					<div  class="col" >10</div >
					<div  class="col" >Fume Sub-Station</div >
					<div  class="col" ><asp:textbox id="FumePHESS_initial" runat="server" CssClass="form-control"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator9" runat="server" ControlToValidate="FumePHESS_initial" ErrorMessage="*"></asp:requiredfieldvalidator></div >
					<div  class="col" ><asp:textbox id="FumePHESS_final" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox><asp:rangevalidator id="RangeValidator5" runat="server" ControlToValidate="FumePHESS_final" ErrorMessage="*" MinimumValue="0" MaximumValue="999999999999999" Type="Double"></asp:rangevalidator><asp:requiredfieldvalidator id="RequiredFieldValidator10" runat="server" ControlToValidate="FumePHESS_final" ErrorMessage="*"></asp:requiredfieldvalidator></div >
					<div  class="col"  colSpan="1" rowSpan="1"><asp:label id="lblDIFF_FumePHESS" runat="server" Width="75px" Height="16px"></asp:label></div >
					<div  class="col" ><asp:dropdownlist id="ddlFumePHESS" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></div >
					<div  class="col"  colSpan="1" rowSpan="1"><asp:label id="FumePHESS_unit" runat="server" Width="159px" Height="16px"></asp:label></div >
					<div  class="col"  colSpan="1" rowSpan="1"><asp:label id="FumePHESS_month" runat="server"></asp:label></div >
				</div >

                <div  class="row">
					<div  class="col" >11</div >
					<div  class="col" >Compressor Sub-Station</div >
					<div  class="col" ><asp:textbox id="txtSubstation_initial" runat="server" CssClass="form-control"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator30" runat="server" ControlToValidate="txtSubstation_initial" ErrorMessage="*"></asp:requiredfieldvalidator></div >
					<div  class="col" ><asp:textbox id="txtSubstation_final" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox><asp:rangevalidator id="RangeValidator19" runat="server" ControlToValidate="txtSubstation_final" ErrorMessage="*" MinimumValue="0" MaximumValue="999999999999999" Type="Double"></asp:rangevalidator><asp:requiredfieldvalidator id="RequiredFieldValidator31" runat="server" ControlToValidate="txtSubstation_final" ErrorMessage="*"></asp:requiredfieldvalidator></div >
					<div  class="col"   colSpan="1" rowSpan="1"><asp:label id="lblDIFF_emms" runat="server" Width="75px" Height="16px"></asp:label></div >
					<div  class="col"  colSpan="1" rowSpan="1"><asp:dropdownlist id="ddlMFemms" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></div >
					<div  class="col"  colSpan="1" rowSpan="1"><asp:label id="lblSubstation_unit" runat="server" Width="159px" Height="16px"></asp:label></div >
					<div  class="col" ><asp:label id="lblSubstation_month" runat="server"></asp:label></div >
				</div >
				<div  class="row">
					<div  class="col" >12</div >
					<div  class="col" >Colony Sub-Station 1&2</div >
					<div  class="col" ><asp:textbox id="txtColony12_initial" runat="server" CssClass="form-control"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator11" runat="server" ControlToValidate="txtColony12_initial" ErrorMessage="*"></asp:requiredfieldvalidator></div >
					<div  class="col" ><asp:textbox id="txtColony12_final" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox><asp:rangevalidator id="RangeValidator15" runat="server" ControlToValidate="txtColony12_final" ErrorMessage="*" MinimumValue="0" MaximumValue="999999999999999" Type="Double"></asp:rangevalidator><asp:requiredfieldvalidator id="RequiredFieldValidator14" runat="server" ControlToValidate="txtColony12_final" ErrorMessage="*"></asp:requiredfieldvalidator></div >
					<div  class="col"  colSpan="1" rowSpan="1"><asp:label id="lblDIFF_col12" runat="server" Width="75px" Height="16px"></asp:label></div >
					<div  class="col"  colSpan="1" rowSpan="1"><asp:dropdownlist id="ddlMFcol12" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></div >
					<div  class="col"  colSpan="1" rowSpan="1"><asp:label id="lblColony12_unit" runat="server" Width="159px" Height="16px"></asp:label></div >
					<div  class="col"  colSpan="1" rowSpan="1"><asp:label id="lblColony12_month" runat="server"></asp:label></div >
				</div >
                <div  class="row">
					<div  class="col" >13</div >
					<div  class="col" >Colony Sub-Station 3&4</div >
					<div  class="col" ><asp:textbox id="txtColony34_initial" runat="server" CssClass="form-control"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator12" runat="server" ControlToValidate="txtColony34_initial" ErrorMessage="*"></asp:requiredfieldvalidator></div >
					<div  class="col" ><asp:textbox id="txtColony34_final" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox><asp:rangevalidator id="RangeValidator6" runat="server" ControlToValidate="txtColony34_final" ErrorMessage="*" MinimumValue="0" MaximumValue="999999999999999" Type="Double"></asp:rangevalidator><asp:requiredfieldvalidator id="RequiredFieldValidator13" runat="server" ControlToValidate="txtColony34_final" ErrorMessage="*"></asp:requiredfieldvalidator></div >
					<div  class="col"  colSpan="1" rowSpan="1"><asp:label id="lblDIFF_col34" runat="server" Width="75px" Height="16px"></asp:label></div >
					<div  class="col"  colSpan="1" rowSpan="1"><asp:dropdownlist id="ddlMFcol34" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></div >
					<div  class="col"  colSpan="1" rowSpan="1"><asp:label id="lblColony34_unit" runat="server" Width="159px" Height="16px"></asp:label></div >
					<div  class="col"  colSpan="1" rowSpan="1"><asp:label id="lblColony34_month" runat="server"></asp:label></div >
				</div >

				<div  class="row">
					<div  class="col" >14</div >
					<div  class="col" >Admn. Bldg.</div >
					<div  class="col" ><asp:textbox id="txtAdmin_initial" runat="server" CssClass="form-control" ></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator20" runat="server" ControlToValidate="txtAdmin_initial" ErrorMessage="*"></asp:requiredfieldvalidator></div >
					<div  class="col" ><asp:textbox id="txtAdmin_final" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox><asp:rangevalidator id="RangeValidator17" runat="server" ControlToValidate="txtAdmin_final" ErrorMessage="*" MinimumValue="0" MaximumValue="999999999999999" Type="Double"></asp:rangevalidator><asp:requiredfieldvalidator id="RequiredFieldValidator21" runat="server" ControlToValidate="txtAdmin_final" ErrorMessage="*"></asp:requiredfieldvalidator></div >
					<div  class="col"  colSpan="1" rowSpan="1"><asp:label id="lblDIFF_Admn" runat="server" Width="75px" Height="16px"></asp:label></div >
					<div  class="col"  colSpan="1" rowSpan="1"><asp:dropdownlist id="ddlMFadmn" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></div >
					<div  class="col"  colSpan="1" rowSpan="1"><asp:label id="lblAdmin_unit" runat="server" Width="159px" Height="16px"></asp:label></div >
					<div  class="col"  colSpan="1" rowSpan="1"><asp:label id="lblAdmin_month" runat="server"></asp:label></div >
				</div >
				<div  class="row">
					<div  class="col" >15</div >
					<div  class="col" >Station Aux.</div >
					<div  class="col" ><asp:textbox id="txtAux_initial" runat="server" CssClass="form-control" ></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator22" runat="server" ControlToValidate="txtAux_initial" ErrorMessage="*"></asp:requiredfieldvalidator></div >
					<div  class="col" ><asp:textbox id="txtAux_final" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator23" runat="server" ControlToValidate="txtAux_final" ErrorMessage="*"></asp:requiredfieldvalidator><asp:rangevalidator id="Rangevalidator21" runat="server" ControlToValidate="txtAux_final" ErrorMessage="*" MinimumValue="0" MaximumValue="999999999999999" Type="Double"></asp:rangevalidator></div >
					<div  class="col" colSpan="1" rowSpan="1"><asp:label id="lblDIFF_aux" runat="server" Width="75px" Height="16px"></asp:label></div >
					<div  class="col" ><asp:dropdownlist id="ddlMFaux" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></div >
					<div  class="col"  colSpan="1" rowSpan="1"><asp:label id="lblAux_unit" runat="server" Width="159px" Height="16px"></asp:label></div >
					<div  class="col"  colSpan="1" rowSpan="1"><asp:label id="lblAux_month" runat="server" Width="109px"></asp:label></div >
				</div >
				<div  class="row">
					<div  class="col"  >16</div >
					<div  class="col" >RWP generarion</div >
					<div  class="col" ><asp:textbox id="txtrwfgen_initial" runat="server" CssClass="form-control"></asp:textbox></div >
					<div  class="col" ><asp:textbox id="txtrwfgen_final" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox></div >
					<div  class="col" ><asp:label id="lblDIFF_rwfgen" runat="server" Width="75px" Height="16px"></asp:label></div >
					<div  class="col" ><asp:dropdownlist id="ddlMFrwfgen" runat="server" AutoPostBack="True" CssClass="form-control ll"></asp:dropdownlist></div >
					<div  class="col" ><asp:label id="lblRwfgen_unit" runat="server" Width="159px" Height="16px"></asp:label></div >
					<div  class="col" ><asp:label id="lblRwfgen_month" runat="server" Width="121px"></asp:label></div >
				</div >
                <br />
				<div  class="row">
					<div  class="col" >17</div >
					<div  class="col" >PCS</div >
					<div  class="col" ><asp:textbox id="txtPCS_initial" runat="server" CssClass="form-control"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator32" runat="server" ControlToValidate="txtPCS_initial" ErrorMessage="*"></asp:requiredfieldvalidator></div >
					<div  class="col" ><asp:textbox id="txtPCS_final" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator33" runat="server" ControlToValidate="txtPCS_final" ErrorMessage="*"></asp:requiredfieldvalidator><asp:rangevalidator id="Rangevalidator23" runat="server" ControlToValidate="txtPCS_final" ErrorMessage="*" MinimumValue="0" MaximumValue="999999999999999" Type="Double"></asp:rangevalidator></div >
					<div  class="col"  colSpan="1" rowSpan="1"><asp:label id="lblDIFF_PCS" runat="server" Width="75px" Height="16px"></asp:label></div >
					<div  class="col" ><asp:dropdownlist id="ddlMFPCS" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></div >
					<div  class="col"  colSpan="1" rowSpan="1"><asp:label id="lblPCS_unit" runat="server" Width="159px" Height="16px"></asp:label></div >
					<div  class="col"  colSpan="1" rowSpan="1"><asp:label id="lblPCS_month" runat="server" Width="121px"></asp:label></div >
				</div >
				
				<div  class="row">
					<div  class="col"  align="center">
                           <asp:button id="btnSubmit_Clicks" runat="server" Text="Save" autopostback="true" Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" ></asp:button>
				
                         &nbsp;&nbsp;&nbsp;&nbsp;
                           <asp:button id="btnCancel" runat="server" Text="Clear"  Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" ></asp:button>
				
           	&nbsp;&nbsp;&nbsp;&nbsp;
                           <asp:button id="btnExit" runat="server" Text="Exit"  Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" ></asp:button>
				
					</div >
					<div  class="col" ></div >
				</div >
			<div style="overflow-x:scroll">
                  <asp:datagrid id="DataGrid1" CssClass="table" runat="server" CellPadding="1" CellSpacing="1" AutoGenerateColumns="False" forecolor="Black">
                    <AlternatingItemStyle BackColor="White"></AlternatingItemStyle>
                    <HeaderStyle ForeColor="White" BackColor="Navy"></HeaderStyle>
                    <Columns>
                    <asp:ButtonColumn Text="Select" HeaderText="Select" CommandName="Select"></asp:ButtonColumn>                         
                    <asp:BoundColumn DataField="consumption_date" HeaderText="Date"></asp:BoundColumn>
                    <asp:BoundColumn DataField="dg_gen1_initial" HeaderText="DG gen1 initial"></asp:BoundColumn>
                    <asp:BoundColumn DataField="dg_gen1_final" HeaderText="DG gen1 final"></asp:BoundColumn> 
                    <asp:BoundColumn DataField="kptcl_initial" HeaderText="kptcl initial"></asp:BoundColumn>
                    <asp:BoundColumn DataField="kptcl_final" HeaderText="kptcl final"></asp:BoundColumn> 
                         <asp:BoundColumn DataField="arc1_initial" HeaderText="arcA initial"></asp:BoundColumn>
                    <asp:BoundColumn DataField="arc1_final" HeaderText="arcA final"></asp:BoundColumn> 
                         <asp:BoundColumn DataField="arc2_initial" HeaderText="arcB initial"></asp:BoundColumn>
                    <asp:BoundColumn DataField="arc2_final" HeaderText="arcB final"></asp:BoundColumn> 
                         <asp:BoundColumn DataField="arc3_initial" HeaderText="arcC initial"></asp:BoundColumn>
                    <asp:BoundColumn DataField="arc3_final" HeaderText="arcC final"></asp:BoundColumn> 
                                             <asp:BoundColumn DataField="pumphouse_initial" HeaderText="pumphouse initial"></asp:BoundColumn>
                    <asp:BoundColumn DataField="pumphouse_final" HeaderText="pumphouse final"></asp:BoundColumn> 
                         <asp:BoundColumn DataField="Melt_initial1" HeaderText="Melt initial"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Melt_final1" HeaderText="Melt final"></asp:BoundColumn> 
                         <asp:BoundColumn DataField="Tube_initial1" HeaderText="Tube initial"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Tube_initial1" HeaderText="Tube final"></asp:BoundColumn>
                         <asp:BoundColumn DataField="Mould_initial1" HeaderText="mould initial"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Mould_final1" HeaderText="mould final"></asp:BoundColumn> 
                         <asp:BoundColumn DataField="Fume_initial1" HeaderText="Fume initial"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Fume_final1" HeaderText="Fume final"></asp:BoundColumn> 
                         <asp:BoundColumn DataField="emms_initial" HeaderText="emms initial"></asp:BoundColumn>
                    <asp:BoundColumn DataField="emms_initial" HeaderText="emms final"></asp:BoundColumn>
                    <asp:BoundColumn DataField="colony_initial" HeaderText="colony initial"></asp:BoundColumn>
                    <asp:BoundColumn DataField="colony_final" HeaderText="colony final"></asp:BoundColumn> 
                         <asp:BoundColumn DataField="colony_initial1" HeaderText="colony initia1l"></asp:BoundColumn>
                    <asp:BoundColumn DataField="colony_final1" HeaderText="colony final1"></asp:BoundColumn> 
                         <asp:BoundColumn DataField="adminbldg_initial" HeaderText="adminbldg initial"></asp:BoundColumn>
                    <asp:BoundColumn DataField="adminbldg_final" HeaderText="adminbldg final"></asp:BoundColumn>

                        <asp:BoundColumn DataField="stnaux_initial" HeaderText="status initial"></asp:BoundColumn>
                    <asp:BoundColumn DataField="stnaux_final" HeaderText="status final"></asp:BoundColumn> 
                         <asp:BoundColumn DataField="rwfgen_initial" HeaderText="rwfgen initia1"></asp:BoundColumn>
                    <asp:BoundColumn DataField="rwfgen_final" HeaderText="rwfgen final"></asp:BoundColumn> 
                         <asp:BoundColumn DataField="pcs_initial" HeaderText="pcs initial"></asp:BoundColumn>
                    <asp:BoundColumn DataField="pcs_final" HeaderText="pcs final"></asp:BoundColumn>

                    </Columns>
                    </asp:datagrid>
                <br />
                <br />
                <br />
                <br />
                <br /></div>
	</div>	</form></div>
       <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;position:fixed;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
 	</body>
</HTML>

