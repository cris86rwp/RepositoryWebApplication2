<%@ Page Language="vb" AutoEventWireup="false" Codebehind="NewMachineryMaster.aspx.vb" Inherits="WebApplication2.NewMachineryMaster" Culture="en-GB" uiCulture="en-GB" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>NewMachineryMaster</title>
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
	<BODY style="overflow-x:hidden">

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
<!--/.Navbar -->
         <div class="container">
        <FORM id="Form1" method="post" runat="server">
             <div class="row">
                 <div class="table-responsive">
			        <asp:panel id="Panel1" runat="server">

                            <div class="container-fluid">
								<div class="row">
									<div class="col">
                                         <b><h1 align="middle" colspan="6">Machinery Master -- Add<hr class="prettyline" />
                                        </h1></b> 
                                     </div>
                                    </div>

                                   <div class="row">
									<div class="col-6">
										<asp:Label id="lblMessage" runat="server" Visible="False"></asp:Label></div>
                                       </div>
                                </div>
                         <div class="container-fluid">
								<div class="row">
									<div class="col-12"><asp:Label id="Label1" runat="server" ForeColor="Red" Width="1121px" Visible="False">
                                        Location : Axle Control, Axle Power, Wheel Control and Wheel Power to be selected when the Machine belongs respectively and EXCLUSIVELY to that shop only
									 </asp:Label></div>
                                    </div>
                             <br />
                             <div class="row">
                                 	<div class="col-2">Location</div>
                                    <div class="col-2"><asp:dropdownlist id="ddlLocation" runat="server" AutoPostBack="True" CssClass="form-control ll" Style="width:103px;"></asp:dropdownlist></div>
                                    <div class="col-2">Equipment Type</div>
                                    <div class="col-2"><asp:dropdownlist id="ddlEqpCode" runat="server" AutoPostBack="True" CssClass="form-control ll" Style="width:103px;"></asp:dropdownlist></div>
                                    <div class="col-2">Machine Id</div>
                                    <div class="col-2"><asp:textbox id="txtMachine" runat="server" CssClass="form-control" AutoPostBack="True" Style="width:103px;"></asp:textbox></div>
                             </div>
                             <br />
                               <div class="row">
                                 	<div class="col-2">Machine Code</div>
                                    <div class="col-2"><asp:label id="lblMachineCode" runat="server" BackColor="#C0C0FF"></asp:label></div>
                                    <div class="col-2">Description</div>
                                    <div class="col-2"><asp:textbox id="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Style="height:35px; width:103px;"></asp:textbox></div>
                                    <div class="col-2"></div>
                                    <div class="col-2"></div>
                             </div>
                             <br />
                               <div class="row">
                                 	<div class="col-2">Mech Maint Done By</div>
                                    <div class="col-4"><asp:radiobuttonlist id="rblMechMaint" runat="server" CssClass="rbl" Enabled="False" RepeatDirection="Horizontal" RepeatLayout="Flow">
								<asp:ListItem Value="MW1">MW1 &nbsp;&nbsp;</asp:ListItem>
								<asp:ListItem Value="MW2">MW2 &nbsp;&nbsp;</asp:ListItem>
								<asp:ListItem Value="MW3">MW3 &nbsp;&nbsp;</asp:ListItem>
								<asp:ListItem Value="MA1">UTILIT &nbsp;</asp:ListItem>
								<asp:ListItem Value="MRT">MRT &nbsp;</asp:ListItem>
								<asp:ListItem Value="EMMS">EMMS</asp:ListItem>
							</asp:radiobuttonlist></div>
                                    <div class="col-2">Elec Maint Done By</div>
                                    <div class="col-4"><asp:radiobuttonlist id="rblElecMaint" runat="server" CssClass="rbl" Enabled="False" RepeatDirection="Horizontal" RepeatLayout="Flow">
								<asp:ListItem Value="EWC">EM1 &nbsp;&nbsp;</asp:ListItem>
                                <asp:ListItem Value="EWC">EM2 &nbsp;&nbsp;</asp:ListItem>
                                <asp:ListItem Value="EWC">EM3 &nbsp;&nbsp;</asp:ListItem>
								<asp:ListItem Value="EAC">EAC &nbsp;&nbsp;</asp:ListItem>
								<asp:ListItem Value="EWP">EWP &nbsp;&nbsp;</asp:ListItem>
								<asp:ListItem Value="EAP">EAP</asp:ListItem>
							</asp:radiobuttonlist></div>
                                  <%--  <div class="col-2"></div>
                                    <div class="col-2"></div>--%>
                             </div>
                             <br />
                               <div class="row">
                                 	<div class="col-2">Group Code</div>
                                    <div class="col-2"><asp:Label id="lblGroupCode" runat="server"></asp:Label></div>
                                    <div class="col-2">Group Name</div>
                                    <div class="col-2"><asp:Label id="lblGroupName" runat="server"></asp:Label></div>
                                    <div class="col-2">AM Base Date</div>
                                    <div class="col-2"><asp:textbox id="txtAMBasedate" runat="server" CssClass="form-control" Style="width:103px;"></asp:textbox></div>
                             </div>
                             <br />
                                <div class="row">
                                 	<div class="col-2">Manufacturer</div>
                                    <div class="col-2"><asp:textbox id="txtManufacturer" runat="server" CssClass="form-control" Style="width:103px;"></asp:textbox></div>
                                    <div class="col-2">Model</div>
                                    <div class="col-2"><asp:textbox id="txtModel" runat="server" CssClass="form-control" Style="width:103px;"></asp:textbox></div>
                                    <div class="col-2">Vendor</div>
                                    <div class="col-2"><asp:textbox id="txtVendor" runat="server" CssClass="form-control" Style="width:103px;"></asp:textbox></div>
                             </div>
                             <br />
                             <div class="row">
									<div class="col-2">PO Number</div>
                                    <div class="col-2"><asp:textbox id="txtPO" runat="server" CssClass="form-control" Style="width:103px;"></asp:textbox></div>
                                    <div class="col-2">PO Date</div>
                                    <div class="col-2"><asp:textbox id="txtPODt" runat="server" AutoPostBack="True" CssClass="form-control" Style="width:103px;"></asp:textbox></div>
                                    <div class="col-2">Cost</div>
                                    <div class="col-2"><asp:textbox id="txtCost" runat="server" CssClass="form-control" Style="width:103px;"></asp:textbox></div>
                                </div>
                            <br />
                             <div class="row">
									<div class="col-2">Date In Service</div>
                                    <div class="col-2"><asp:textbox id="txtDtInService" runat="server" AutoPostBack="True" CssClass="form-control" Style="width:103px;" placeholder="dd/mm/yyyy"></asp:textbox></div>
                                    <div class="col-2">Warrnaty From</div>
                                    <div class="col-2"><asp:textbox id="txtWarrantyFrom" runat="server" CssClass="form-control" Style="width:103px;" placeholder="dd/mm/yyyy"></asp:textbox></div>
                                    <div class="col-2">Warranty To</div>
                                    <div class="col-2"><asp:textbox id="txtWarrantyTo" runat="server" AutoPostBack="True" CssClass="form-control" Style="width:103px;" placeholder="dd/mm/yyyy"></asp:textbox></div>
                                </div>
                            <br />
                            <%--  <div class="row">
                                 	<div class="col-2"></div>
                                    <div class="col-2"></div>
                                    <div class="col-2"></div>
                                    <div class="col-2"></div>
                                    <div class="col-2"></div>
                                    <div class="col-2"></div>
                             </div>
                             <br />--%>
                             </div>
                              <br />
                                <div class="container-fluid">
                                   <div class="row">
									<div class="col-12" align="middle">
										<asp:Button id="btnSave" runat="server" Text="Update" BorderStyle="Solid" CssClass="btn btn-dark" Font-Bold="True" Font-Names="Arial" Font-Size="Medium"></asp:Button></div>
								</div>
                                 <br />
                                 </div>
        </asp:Panel>
                    </div>
             </div>
		</FORM>
            </div>
         <%--<div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>--%>
        <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;height:45px; width:100%; bottom:0;"><h4 style="color: black;font-size:15px;">MAINTAINED BY CRIS</h4></div>
  
        <script>

 $(document).ready(function () {
                       
     $('#txtAMBasedate').datepicker({
         dateFormat: "dd/mm/yy",

         onSelect: function (date) {
             var date1 = $('#txtAMBasedate').datepicker('getDate');
         }


     });
     
        $('#txtPODt').datepicker({
         dateFormat: "dd/mm/yy",

         onSelect: function (date) {
             var date1 = $('#txtPODt').datepicker('getDate');
         }

     });
      $('#txtDtInService').datepicker({
         dateFormat: "dd/mm/yy",

         onSelect: function (date) {
             var date1 = $('#txtEndDate').datepicker('getDate');
         }


     });
     
      $('#txtWarrantyFrom').datepicker({
         dateFormat: "dd/mm/yy",

         onSelect: function (date) {
             var date1 = $('#txtWarrantyFrom').datepicker('getDate');
         }


     });
    
      $('#txtWarrantyTo').datepicker({
         dateFormat: "dd/mm/yy",

         onSelect: function (date) {
             var date1 = $('#txtWarrantyTo').datepicker('getDate');
         }


     });
                       
  function getDate( element ) {
    var date;
    var dateFormat = "dd/MM/yyyy";
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