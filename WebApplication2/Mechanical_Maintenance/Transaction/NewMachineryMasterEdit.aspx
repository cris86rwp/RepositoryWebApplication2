<%@ Page Language="vb" AutoEventWireup="false" Codebehind="NewMachineryMasterEdit.aspx.vb" Inherits="WebApplication2.NewMachineryMasterEdit" Culture="en-GB" uiCulture="en-GB" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>NewMachineryMasterEdit</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR"/>
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
            <meta charset="utf-8"/>
  <link rel="stylesheet" type="text/css" href="css/jquery-ui.css" />
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
      <%--   <link rel="stylesheet" href="../../StyleSheet1.css" />--%>
	</head>
	<body>
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
          <%--<li class="nav-item"> <a class="nav-link" href="#" style="color:white; font-size:25px;">Rail Wheel Plant Bela</a></li>--%>
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
          <%--<img src="../../NewFolder1/CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="45"/>--%>
            <img src="../../NewFolder1/CRIS-Recruitment.jpg" height="45" style="border-radius:43%"/>
        </a>
      </li>
     </ul>
      
  </div>
</nav> 
<br />
	
<!--/.Navbar -->
    	<form id="Form1" method="post" runat="server">
             <%-- <div class="row">
    
                  <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />
      </div>--%>
            <div class="table-responsive">
			
                    <div class="container">
	<br />
				<div class="row">
					<div class="col" align="center"><FONT size="5">Machinery Master -- Edit</FONT><hr class="prettyline" /></div>
				</div>
			<br />	<div class="row">
					<div class="col"><asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></div>
				</div>
		<br />		<div class="row">
					<div class="col">Machine Code</div>
				
					<div class="col"><asp:textbox id="txtMachine" runat="server" AutoPostBack="True" CssClass="form-control" Width="103px"></asp:textbox></div>
			
					<div class="col">Description</div>
					
					<div class="col"><asp:textbox id="txtDescription" runat="server" CssClass="form-control" Width="103px"></asp:textbox></div>
				
					<div class="col">AM Base Date</div>
					
					<div class="col"><asp:textbox id="txtAMBasedate" runat="server" CssClass="form-control" Width="103px"></asp:textbox></div>
					</div>
              <br />          <div class="row">
                            <div class="col">Manufacturer</div>
					
					<div class="col"><asp:textbox id="txtManufacturer" runat="server" CssClass="form-control" Width="103px"></asp:textbox></div>
				
					<div class="col">Model</div>
			
					<div class="col"><asp:textbox id="txtModel" runat="server" CssClass="form-control" Width="103px"></asp:textbox></div>
					<div class="col">Vendor</div>
					
					<div class="col"><asp:textbox id="txtVendor" runat="server" CssClass="form-control" Width="103px"></asp:textbox></div>
				</div>
				<br /><div class="row">
					<div class="col">PO Number</div>
					
					<div class="col"><asp:textbox id="txtPO" runat="server" CssClass="form-control" Width="103px"></asp:textbox>(9char)</div>
					<div class="col">PO Date</div>
				
					<div class="col"><asp:textbox id="txtPODt" runat="server" AutoPostBack="True" CssClass="form-control" Width="103px"></asp:textbox></div>
			
					<div class="col">Cost</div>
					
					<div class="col"><asp:textbox id="txtCost" runat="server" CssClass="form-control" Width="103px"></asp:textbox></div>
				</div><br />
				<div class="row">
                    <div class="col">Date In Service</div>
					
					<div class="col"><asp:textbox id="txtDtInService" runat="server" AutoPostBack="True" CssClass="form-control" Width="103px"></asp:textbox></div>
			
					<div class="col">Warrnty From</div>
					
					<div class="col"><asp:textbox id="txtWarrantyFrom" runat="server" CssClass="form-control" Width="103px"></asp:textbox></div>
					<div class="col">Warranty To</div>
					
					<div class="col"><asp:textbox id="txtWarrantyTo" runat="server" AutoPostBack="True" CssClass="form-control" Width="103px"> </asp:textbox></div>
				</div><br />
				<div class="row">
					<div class="col" align="center">
                         <asp:Button id="btnSave" Text="Edit" runat="server" BorderStyle="Solid" Font-Bold="True" Font-Size="20px" CssClass="btn btn-dark"></asp:Button></div>
				
					</div>
				</div>
			
		</div></form>
    <div class="card-footer" style="text-align:right;background-color:#cccccc;bottom:0;width:100%;position:absolute;vertical-align:middle;height:60px" ><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
<script type="text/javascript">
     $(document).ready(function () {
                       
                        $('#txtAMBasedate').datepicker({
                            dateFormat: "yy/mm/dd", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtAMBasedate').datepicker('getDate');           
                                                 
                              
                            }
                        });
    
  function getDate( element ) {
    var date;
    var dateFormat = "yyyy/MM/dd";
    try {
      date = $.datepicker.parseDate( dateFormat, element.value );
    } catch( error ) {
      date = null;
    }

    return date;
  }
    });
     $(document).ready(function () {
                       
                        $('#txtDtInService').datepicker({
                            dateFormat: "yy/mm/dd", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtDtInService').datepicker('getDate');           
                                                 
                              
                            }
                        });
    
  function getDate( element ) {
    var date;
    var dateFormat = "yyyy/MM/dd";
    try {
      date = $.datepicker.parseDate( dateFormat, element.value );
    } catch( error ) {
      date = null;
    }

    return date;
  }
    });
     $(document).ready(function () {
                       
                        $('#txtWarrantyFrom').datepicker({
                            dateFormat: "yy/mm/dd", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtWarrantyFrom').datepicker('getDate');           
                                                 
                              
                            }
                        });
    
  function getDate( element ) {
    var date;
    var dateFormat = "yyyy/MM/dd";
    try {
      date = $.datepicker.parseDate( dateFormat, element.value );
    } catch( error ) {
      date = null;
    }

    return date;
  }
    });
     $(document).ready(function () {
                       
                        $('#txtWarrantyTo').datepicker({
                            dateFormat: "yy/mm/dd", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtWarrantyTo').datepicker('getDate');           
                                                 
                              
                            }
                        });
    
  function getDate( element ) {
    var date;
    var dateFormat = "yyyy/MM/dd";
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