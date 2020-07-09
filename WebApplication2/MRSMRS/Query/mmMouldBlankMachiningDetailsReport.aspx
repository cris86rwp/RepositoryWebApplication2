<%@ Page Language="vb" AutoEventWireup="false" Codebehind="mmMouldBlankMachiningDetailsReport.aspx.vb" Inherits="WebApplication2.mmMouldBlankMachiningDetailsReport" %>
<!DOCTYPE HTML>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<title>mmMouldBlankMachiningDetailsReport</title>
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
         .auto-style4 {
             background-color: rgba(0,0,0,.03);
             position: absolute;
             bottom: -173px;
             width: 100%;
             height: 60px;
             left: 5px;
         }
         .auto-style5 {
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
	
	
        <script>
           function isNumber1(evt, element) {

                    var charCode = (evt.which) ? evt.which : event.keyCode

                      if (
                           (charCode != 45 ) && (charCode != 47 ) &&     // 
                           (charCode < 48 || charCode > 57))
                      return false;

                  return true;
            } 
           
   
        </script>
	</head>
	<body>

               <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
  <a class="navbar-brand p-0" href="#"><img src="../../../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
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
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home "  style="font-size:30px"></i>
        </a></li>

       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out"  style="font-size:30px"></i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
         
        <img src="../../../NewFolder1/CRIS-Recruitment.jpg" height="45" style="border-radius:43%"/>
       </a>
      </li>
     </ul>
      
  </div>
</nav>     
		<form id="Form1" method="post" runat="server">
           <%-- <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
			<asp:Panel id="Panel1" runat="server">
                 <div class="container">
       
                <div class="table">

				<div class="row">
                    
				
						 <div class="col" align="center"><h2>MRS Querries</h2> </div>
					 </div>
					 <div class="row">
						 <div class="col">Message </div>
						 <div class="col" >
							<asp:Label id="lblMessage" runat="server" ForeColor="Red" Font-Size="Medium" Font-Bold="True"></asp:Label> </div>
					 </div>
					 </div >
                     <div class="row">
						 <div class="col">FromDate </div>
						 <div class="col">
							<asp:TextBox id="txtFromDate" runat="server" CssClass="auto-style5" AutoPostBack="True" onkeypress="return isNumber1(event,this)" MaxLength="10" placeholder="dd/mm/yyyy" Width="103px"></asp:TextBox> </div>
						 <div class="col">ToDate </div>
						 <div class="col">
							<asp:TextBox id="txtToDate" runat="server" CssClass="auto-style5" AutoPostBack="True" onkeypress="return isNumber1(event,this)" MaxLength="10" placeholder="dd/mm/yyyy" Width="103px"></asp:TextBox> </div>
                            </div>
                     </div>
                    <div class="row">
                        <div class="col"> <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtToDate" ControlToValidate="txtFromDate" ErrorMessage="To Date should be greater than From Date" ForeColor="#FF3300" Operator="LessThanEqual"></asp:CompareValidator>
						</div>
					</div>
					 
						 <div class="col" align="center">
                             
							<asp:RadioButtonList id="rblQry" runat="server" CssClass="rbl" AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal">
								<asp:ListItem Value="1" Selected="True">Mould Machining Details  Mis-Match &nbsp;</asp:ListItem>
								<asp:ListItem Value="2">Condemned Moulds Status Mis-Match &nbsp;</asp:ListItem>
								<asp:ListItem Value="3">Supplier wise mould consumption details &nbsp;</asp:ListItem>
								<asp:ListItem Value="4">Mould Consumption Summary &nbsp;</asp:ListItem>
								<asp:ListItem Value="6">DateWise Qry &nbsp;</asp:ListItem>
								<asp:ListItem Value="7">FirmWise Qry &nbsp;&nbsp;</asp:ListItem>
								<asp:ListItem Value="8">MouldConsumptionSummaryMonthWise &nbsp;</asp:ListItem>
								<asp:ListItem Value="9">MouldConsumptionTotalSummary &nbsp;</asp:ListItem>
								<asp:ListItem Value="10">Ingate Performance Details &nbsp;</asp:ListItem>
								<asp:ListItem Value="11">Ingate Performance Summary Firmwise &nbsp;</asp:ListItem>
								<asp:ListItem Value="21">Ingate Performance Summary Reasonwise &nbsp;</asp:ListItem>
								<asp:ListItem Value="12">Ingate Performance Below 26 WC Details &nbsp; </asp:ListItem>
								<asp:ListItem Value="13">CR XC Details &nbsp;</asp:ListItem>
								<asp:ListItem Value="14">FirmWise Mould Population &nbsp;</asp:ListItem>
								<asp:ListItem Value="15">ProductWise Mould Population &nbsp;</asp:ListItem>
								<asp:ListItem Value="16">Mould received from MR Semmary &nbsp;</asp:ListItem>
								<asp:ListItem Value="22">Mould received from MR Details &nbsp;</asp:ListItem>
								<asp:ListItem Value="17">Mould Issued to MR &nbsp;</asp:ListItem>
								<asp:ListItem Value="18">Mould Population &nbsp;</asp:ListItem>
								<asp:ListItem Value="19">Ingate XC Details &nbsp;</asp:ListItem>
								<asp:ListItem Value="20">Ingate Fitted Datewise &nbsp;</asp:ListItem>
								<asp:ListItem Value="23">Mould Machining Datewise &nbsp;</asp:ListItem>
								<asp:ListItem Value="24">Ingate Blanks &nbsp;</asp:ListItem>
							</asp:RadioButtonList> </div>
					<br />
                <br />
					<div class="row">
						 <div class="col" align="center">
					  <asp:button id="btnShow" runat="server" Text="Show Data in Grid"  Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" ></asp:button></div>
							
					 
						 <div class="col">
                         <asp:button id="btnExportDetails" runat="server" Text="Export To EXCEL"  Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" ></asp:button>
						</div>	
					 </div>
				
				<asp:DataGrid id="DataGrid1" runat="server" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
			</asp:Panel>
		</form>
                    
                                                             
     <div class="auto-style4" style="text-align:right;background-color:#cccccc;vertical-align:middle;"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
 
<script>
     $(document).ready(function () {
                       
                        $('#txtFromDate').datepicker({
                            dateFormat: "dd-mm-yy", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtFromDate').datepicker('getDate');           
                                                 
                              
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
      $(document).ready(function () {
                       
                        $('#txtToDate').datepicker({
                            dateFormat: "dd-mm-yy", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtToDate').datepicker('getDate');           
                                                 
                              
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
</html>
