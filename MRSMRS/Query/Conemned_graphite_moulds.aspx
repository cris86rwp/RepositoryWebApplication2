<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Conemned_graphite_moulds.aspx.vb" Inherits="WebApplication2.Conemned_graphite_moulds" %>
<!DOCTYPE HTML>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<title>Conemned_graphite_moulds</title>
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
         .auto-style3 {
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
	   

	</HEAD>
	
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
</nav>
      


		<form id="Form1" method="post" runat="server">
			<asp:Panel id="Panel1" runat="server">
				<div class="container">
                    <div class="row">
						 <div class="col" align="center"><h3><strong>Condemned Graphite</strong></h3> </div >
					 </div >
                    <br />
					 <div class="row">
						 <div class="col">
							<asp:RadioButtonList id="rblReport" CssClass="rbl" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
								<asp:ListItem Value="C" Selected="True">Condemned Graphite &nbsp;</asp:ListItem>
								<asp:ListItem Value="N">New Mould Introduced &nbsp;</asp:ListItem>
							</asp:RadioButtonList> </div >
					 </div ><br /><br />
					 <div class="row">
						 <div class="col"> 
							<asp:RadioButtonList id="rblGrid" CssClass="rbl" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
								<asp:ListItem Value="Details" Selected="True">Details</asp:ListItem>
								<asp:ListItem Value="Summary">Summary &nbsp;</asp:ListItem>
								<asp:ListItem Value="C">FirmWise Performance&nbsp;</asp:ListItem>
								<asp:ListItem Value="P">ProductWise Performance&nbsp;</asp:ListItem>
							</asp:RadioButtonList> </div >
					 </div >
                    <br />
                    <br />
					 <div class="row">
						 <div class="col"> 
							<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label> </div >
					 </div >
					 <div class="row">
						 <div class="col">From Date </div >
						 
						 <div class="col">
							<asp:TextBox id="txtFromDt" runat="server" CssClass="auto-style3" onkeypress="return isNumber1(event,this)" MaxLength="10" placeholder="dd/mm/yyyy" Width="103px"></asp:TextBox> </div >
						 <div class="col">To Date </div >
						
						 <div class="col">
							<asp:TextBox id="txtToDate" runat="server" CssClass="auto-style3" onkeypress="return isNumber1(event,this)" MaxLength="10" placeholder="dd/mm/yyyy" Width="103px"></asp:TextBox> </div >
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtToDate" ControlToValidate="txtFromDt" ErrorMessage="To Date should be greater than From Date" ForeColor="#FF3300" Operator="LessThanEqual" Type="Date"></asp:CompareValidator>

					 </div ><br />
                    <br />
					 <div class="row">
						 <div class="col" align="center"> 
							<asp:button id="btnShpw" runat="server" Text="Show Details"  Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" ></asp:button>
							</div>
                         </div> <br />
                    <div class="row">
					
						 <div class="col" align ="center">  
							<asp:button id="Button1" runat="server" Text="Export to Excel"  Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" ></asp:button>
							
					 </div >
				</div>
				<asp:DataGrid id="DataGrid1" runat="server" BorderStyle="None" BorderColor="#CC9966" BorderWidth="1px" BackColor="White" CellPadding="4">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
			</asp:Panel>
		</form>
                                          </div>
                </div>
            </div>
    <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;position:absolute;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
         <script type="text/javascript">
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
              
 $(document).ready(function () {
                       
                        $('#txtFromDt').datepicker({
                            dateFormat: "dd-mm-yy", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtFromDt').datepicker('getDate');           
                                                 
                              
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
