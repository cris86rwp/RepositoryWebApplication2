<%@ Page Language="vb" AutoEventWireup="false" Codebehind="XcDailyAnalysis.aspx.vb" Inherits="WebApplication2.XcDailyAnalysis" Culture="en-GB" uiCulture="en-GB" %>
<!DOCTYPE html>

<HTML xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mould New Reports</title>
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

   <!-- <link href="../../../StyleSheet1.css" rel="stylesheet" />-->

 
    <style type="text/css">
        .auto-style1 {
            width: 538px;
            height: 335px;
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
  <div class="collapse navbar-collapse " id="navbarSupportedContent-333" >
      <ul class="navbar-nav ml-auto navbar-center">
         <li class="nav-item" style="font-weight: bold">
             <h1 style="color:white; font-size:30px; margin-left:430px; margin-top:5px">Rail Wheel Plant, Bela</h1> 
       
         </li>
          </ul>
    <ul class="navbar-nav ml-auto  navbar-right">
        <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home "style="font-size:30px"></i>
        </a></li>

       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out" style="font-size:30px"></i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
         
        <img src="../../../NewFolder1/CRIS-Recruitment.jpg" height="45" style="border-radius:43%"/>
       </a>
      </li>
     </ul>
      
  </div>
</nav>
       <script type="text/javascript">
$(document).ready(function () {
                       
                        $('#Textbox2').datepicker({
                            dateFormat: "dd-mm-yy"
                        });
                       
                        $("#Textbox1").datepicker({
                            dateFormat: "dd-mm-yy",
                           
                            onSelect: function(date){            
                                var date1 = $('#Textbox1').datepicker('getDate');          
                                                 
                                $('#Textbox2').datepicker("option","minDate",date1);            
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
     <div class="container">
            <div class="row">
                <div class="table">
		<form id="Form1" method="post" runat="server">
            <%-- <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
			<asp:panel id="Panel1" runat="server">
				<div class="table">
					<div class="row">
						<div class="col" align="center"><STRONG><Font size="5px">XC Daily Analysis Between Dates</Font></STRONG></div>
					</div>
                        <br />
					<div class="row">
						<div class="col" >
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></div>
					</div>
					
					 <br />
					<%--<TR>
						<TD align="middle" colSpan="3">
							<asp:Button id="btnShow" runat="server" Text="Show Report" CssClass="form-control"></asp:Button></TD>
					</TR>--%>
                    
					<%--<TR>
						<TD>ToDate</TD>
						<TD colSpan="3">
							<asp:textbox id="txtToDt" runat="server" Width="120px" CssClass="form-control"></asp:textbox></TD>
					</TR>--%>
                   <%-- <TR>
						<TD align="middle" colSpan="3">
							<asp:Button id="btnDetails" runat="server" Text="Show Report" CssClass="form-control"></asp:Button></TD>
					</TR>--%>
                    <div class="row">
                       
						<div class="col">From Date</div>
						<div class="col" >
							<asp:textbox id="Textbox1" runat="server" Width="120px" CssClass="form-control"></asp:textbox></div>
					
						<div class="col">To Date</div>
						<div class="col" >
							<asp:textbox id="Textbox2" runat="server" Width="120px" CssClass="form-control"></asp:textbox></div>
					</div>
                    <br />
                     <br />
                     <br />
                     <br />
                    <div class="row">
						<div class="col" align="middle" >
							<asp:Button id="Button1" runat="server" Text="Submit" Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark"></asp:Button></div>
					</div>
                    
                   
                    
				</div>
				
				
			</asp:panel></form>
	 </div>
                </div>
            </div>
     <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;position:absolute;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>

	</body>
</HTML>
