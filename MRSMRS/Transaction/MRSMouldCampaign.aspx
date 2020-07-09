<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MRSMouldCampaign.aspx.vb" Inherits="WebApplication2.MRSMouldCampaign" Culture="en-GB" uiCulture="en-GB" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>MRSMouldCampaign</title>
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

	</HEAD>
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
          <i class="fab glyphicon glyphicon-home " style="font-size:30px;"></i>
        </a></li>
       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out" style="font-size:30px;"></i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
         
        <img src="../../NewFolder1/CRIS-Recruitment.jpg" height="45" style="border-radius:43%"/>
       </a>
      </li>
     </ul>
      
  </div>
</nav>
<!--/.Navbar -->
            <div class="row"><div class="table">
		
		
		<form id="Form2" method="post" runat="server">		
<div class="container">
			<div class="table">
				<div class="row">
					<div class="col">Mould population details as on
						<asp:textbox id="CampaignDate" runat="server" CssClass="form-control" AutoPostBack="True" Width="210px"></asp:textbox>
				</div>
					<div class="col"><asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></div>
				</div>
                <br />
				<div class="row">
					<div class="col">&nbsp;</div>
					<div class="col" >StdReqt</div>
					<div class="col">Available(Usable)</div>
					<div class="col">Shortfall</div>
					<div class="col">&nbsp;</div>
                    <div class="col">&nbsp;</div>
					<div class="col">&nbsp;</div>
					<div class="col">&nbsp;</div>
				</div>
				<div class="row">
					<div class="col">Product</div>
					<div class="col">Cope</div>
					<div class="col">Drag</div>
					<div class="col">Cope</div>
					<div class="col" >Drag</div>
					<div class="col">Cope</div>
					<div class="col">Drag</div>
					<div class="col">Remarks</div>
				</div>
                <br />
				<div class="row">
					<div class="col">BoxN</div>
					<div class="col">130</div>
					<div class="col">120</div>
					<div class="col"><asp:textbox id="UsableCopes1" runat="server" CssClass="form-control"></asp:textbox></div>
					<div class="col"><asp:textbox id="UsableDrags1" runat="server" CssClass="form-control"></asp:textbox></div>
					<div class="col"><asp:textbox id="ShortfallCopes1" runat="server" CssClass="form-control"></asp:textbox></div>
					<div class="col"><asp:textbox id="ShortfallDrags1" runat="server" CssClass="form-control"></asp:textbox></div>
					<div class="col"><asp:textbox id="Remarks1" runat="server" CssClass="form-control"></asp:textbox></div>
				</div>
                <br />
				<div class="row">
					<div class="col">BGC</div>
					<div class="col">130</div>
					<div class="col" >120</div>
					<div class="col"><asp:textbox id="UsableCopes2" runat="server" CssClass="form-control"></asp:textbox></div>
					<div class="col" ><asp:textbox id="UsableDrags2" runat="server" CssClass="form-control"></asp:textbox></div>
					<div class="col"><asp:textbox id="ShortfallCopes2" runat="server" CssClass="form-control"></asp:textbox></div>
					<div class="col"><asp:textbox id="ShortfallDrags2" runat="server" CssClass="form-control"></asp:textbox></div>
					<div class="col"><asp:textbox id="Remarks2" runat="server" CssClass="form-control"></asp:textbox></div>
				</div>
                <br /><br />
				<div class="row">
                    
				<div class="col" align="center"><asp:button id="BtnSave" align="center" runat="server" Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" Text="Save"></asp:button>
					</div>
				</div></div>
			</div></form>
		</div></div>
       <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;position:absolute;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
   <script type="text/javascript">
 $(document).ready(function () {
                       
                        $('#CampaignDate').datepicker({
                            dateFormat: "dd-mm-yy", 
                       
                            onSelect: function(date){            
                                var date1 = $('#CampaignDate').datepicker('getDate');           
                                                 
                              
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
</HTML>
