<%@ Page Language="vb" AutoEventWireup="false" Codebehind="BHNHeatTreatmentDetails.aspx.vb" Inherits="WebApplication2.BHNHeatTreatmentDetails" Culture="en-GB" uiCulture="en-GB" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>BHNHeatTreatmentDetails</title>
		
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
     <!--<link rel="stylesheet" href="../../../../StyleSheet1.css" />-->
	</HEAD>
	<BODY >
                <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
  <a class="navbar-brand p-0" href="#"><img src="../../../../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
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
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../../wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home " style="font-size:30px"></i>
        </a></li>

       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out" style="font-size:30px"> </i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
         
        <img src="../../../../NewFolder1/CRIS-Recruitment.jpg" height="45" style="border-radius:43%"/>
       </a>
      </li>
     </ul>
      
  </div>
</nav>
        <script>
 $(document).ready(function () {
                       
                        $('#txtNFChargeDate').datepicker({
                            dateFormat: "dd-mm-yy", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtNFChargeDate').datepicker('getDate');           
                                                 
                              
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
		<FORM id="Form1" method="post" runat="server">
            <div class="row"><div class="table">
			<asp:Panel id="Panel1"  runat="server">
				<TABLE id="Table2" class="table">
					<div class="row">
						<div class="col" align="center"><STRONG><FONT size="5px">HARDNESS SURVEY - HEAT TREATMENT 
							DETAILS</FONT> </STRONG>
                        </div>
                        </div>
                        <div class="row">
							<asp:label id="lblMode" runat="server" ForeColor="Blue"></asp:label></div>
					</div>
                
				</TABLE>
                </br>
				<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label>
				<TABLE id="Table3" class="table">
					<div class="row">
						<div class="col">Wheel Number</div>
						<div class="col">
							<asp:dropdownlist id="ddlWheelNumber" runat="server" CssClass="form-control ll" AutoPostBack="True" Width="100px"></asp:dropdownlist></div>
						<div class="col" style="margin-left:-125px">
							<asp:textbox id="txtWheel" runat="server" CssClass="form-control" AutoPostBack="True" Width="100px"></asp:textbox></div>
						<div class="col">Lab Number</div>
						<div class="col">
							<asp:label id="lblLabNum" runat="server" ></asp:label></div>
					</div>
				</TABLE>
                <br />
				<TABLE id="Table4" class="table">
					<div class="row">
						<div class="col">Wheel Charge In Date</div>
						<div class="col">
							<asp:textbox id="txtNFChargeDate" runat="server" CssClass="form-control"></asp:textbox></div>
						<div class="col">Time(hh:mm)</div>
						<div class="col">
							<asp:textbox id="txtNFChargeTime" runat="server" CssClass="form-control"></asp:textbox></div>
						<div class="col">Wheel Charge Condition</div>
						<div class="col">
							<asp:dropdownlist id="ddlNFChargeCondition" runat="server" CssClass="form-control ll">
								<asp:ListItem Value="Hot" Selected="True">Hot</asp:ListItem>
								<asp:ListItem Value="Cold">Cold</asp:ListItem>
							</asp:dropdownlist></div>
						<div class="col">Wheel Discharge Time(hh:mm)</div>
						<div class="col">
							<asp:textbox id="txtNFDischargeTime" runat="server" CssClass="form-control" MaxLength="5"></asp:textbox></div>
                        <div class="col"></div>
					</div>
				</TABLE>
                 <br />
				<TABLE id="Table5" class="table">
					<div class="row">
						<div class="col">Quencher No</div>
						<div class="col">
							<asp:dropdownlist id="ddlQuencherNo" runat="server" CssClass="form-control ll"></asp:dropdownlist></div>
						<div class="col">Duration:</div>
						<div class="col">
							<asp:textbox id="txtQTimeMin" runat="server" CssClass="form-control" MaxLength="1"></asp:textbox></div>
						<div class="col">min</div>
						<div class="col">
							<asp:textbox id="txtQTimeSec" runat="server" CssClass="form-control"></asp:textbox></div>
						<div class="col">sec</div>
                        <div class="col"></div>
                        <div class="col"></div>
					</div>
				</TABLE>
                 <br />
				<TABLE id="Table6" class="table">
					<div class="row">
						<div class="col">Zone Number</div>
						<div class="col">Zone 1</div>
						<div class="col">Zone 2</div>
						<div class="col">Zone 3</div>
						<div class="col">Zone 4</div>
						<div class="col">Zone 5</div>
						<div class="col">Zone 6</div>
						<div class="col">Zone 7</div>
						<div class="col">Zone 8</div>
					</div>
                     <br />
					<div class="row">
						<div class="col">NFTemp <br />(Close To Discharge Time)</div>
						<div class="col">
							<asp:textbox id="txtNFZone1" tabIndex="-1" runat="server" CssClass="form-control" MaxLength="3">0</asp:textbox></div>
						<div class="col">
							<asp:textbox id="txtNFZone2" runat="server" CssClass="form-control" MaxLength="4"></asp:textbox></div>
						<div class="col">
							<asp:textbox id="txtNFZone3" runat="server" CssClass="form-control" MaxLength="4"></asp:textbox></div>
						<div class="col">
							<asp:textbox id="txtNFZone4" runat="server" CssClass="form-control" MaxLength="3"></asp:textbox></div>
						<div class="col">
							<asp:textbox id="txtNFZone5" runat="server" CssClass="form-control" MaxLength="3"></asp:textbox></div>
						<div class="col">
							<asp:textbox id="txtNFZone6" runat="server" CssClass="form-control" MaxLength="3"></asp:textbox></div>
						<div class="col">
							<asp:textbox id="txtNFZone7" runat="server" CssClass="form-control" MaxLength="3"></asp:textbox></div>
						<div class="col"></div>
					</div>
                     <br />
					<div class="row">
						<div class="col">DF Temp(Close To Discharge Time)</div>
						<div class="col"><asp:textbox id="txtDFZone1" runat="server" CssClass="form-control" MaxLength="3"></asp:textbox></div>
						<div class="col"><asp:textbox id="txtDFZone2" runat="server" CssClass="form-control" MaxLength="3"></asp:textbox></div>
						<div class="col"><asp:textbox id="txtDFZone3" runat="server" CssClass="form-control" MaxLength="3"></asp:textbox></div>
						<div class="col">
							<asp:textbox id="txtDFZone4" runat="server" CssClass="form-control" MaxLength="3"></asp:textbox></div>
						<div class="col">
							<asp:textbox id="txtDFZone5" runat="server" CssClass="form-control" MaxLength="3"></asp:textbox></div>
						<div class="col">
							<asp:textbox id="txtDFZone6" runat="server" CssClass="form-control" MaxLength="3"></asp:textbox></div>
						<div class="col">
							<asp:textbox id="txtDFZone7" runat="server" CssClass="form-control" MaxLength="3"></asp:textbox></div>
						<div class="col">
							<asp:textbox id="txtDFZone8" runat="server" CssClass="form-control" MaxLength="3"></asp:textbox></div>
					</div>

				</TABLE>
                 <br />
				<TABLE id="Table7" class="table">
					<div class="row">
						<div class="col">Hub Cooler</div>
						<div class="col"><asp:dropdownlist id="ddlHubCooler1" runat="server" CssClass="form-control ll" Enabled="False"></asp:dropdownlist></div>
						<div class="col">
							<asp:dropdownlist id="ddlHubCooler2" runat="server" CssClass="form-control ll" Enabled="False"></asp:dropdownlist></div>
						<div class="col">
							<asp:dropdownlist id="ddlHubCooler3" runat="server" CssClass="form-control ll" Enabled="False"></asp:dropdownlist></div>
                        <div class="col"></div>
                         <div class="col"></div>
                         <div class="col"></div>
                         <div class="col"></div>
                         <div class="col"></div>
               
					</div>
                     <br />
					<div class="row">
						<div class="col">Duration In Sec</div>
						<div class="col">
							<asp:textbox id="txtHC1" runat="server" CssClass="form-control" MaxLength="2"></asp:textbox></div>
						<div class="col">
							<asp:textbox id="txtHC2" runat="server" CssClass="form-control" MaxLength="2"></asp:textbox></div>
						<div class="col">
							<asp:textbox id="txtHC3" runat="server" CssClass="form-control" MaxLength="2"></asp:textbox></div>
                         <div class="col"></div>
                         <div class="col"></div>
                         <div class="col"></div>
                         <div class="col"></div>
                         <div class="col"></div>
					</div>
				</TABLE>
                 <br />
				<TABLE id="Table1" class="table">
					<div class="row">
						<TD vAlign="top" align="middle" colSpan="10">
							<asp:button id="btnSave" runat="server" Text="Save" Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:button id="btnClear" runat="server" Text="Clear" Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark"></asp:button></div>
					</div>
				</TABLE>
			</asp:Panel>
                </div></div>
		</FORM>
            </div>
          <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;position:relative;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>

	</BODY>
</HTML>
