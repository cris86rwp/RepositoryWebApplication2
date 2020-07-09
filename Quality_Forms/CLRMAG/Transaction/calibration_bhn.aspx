<%@ Page Language="vb" AutoEventWireup="false" Codebehind="calibration_bhn.aspx.vb" Inherits="WebApplication2.calibration_bhn" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>CalibrationBHN</title>
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
       
       <!-- <link rel="stylesheet" href="../../../StyleSheet1.css" />-->
 
	</head>
	<body>
        <script>
 $(document).ready(function () {
                       
                        $('#txtDate').datepicker({
                            dateFormat: "dd-mm-yy", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtDate').datepicker('getDate');           
                                                 
                              
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
                       
                        $('#txtDueDate').datepicker({
                            dateFormat: "dd-mm-yy", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtDueDate').datepicker('getDate');           
                                                 
                              
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
            <div class="row"><div class="table-responsive">
			<asp:Panel id="Panel1" runat="server">
				<table id="Table4" class="table">
					<div class="row">
						<div class="col" vAlign="top" align="middle" colSpan="5"><h2>Calibration of BHN</h2></div>
					</div>
                    <br />
					<div class="row">
						<div class="col">
							<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></div>
					</div>
                    <br />
					<div class="row">
						<div class="col">Date:</div>
						<div class="col">
							<asp:textbox id="txtDate" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox></div>
						<div class="col">Shift:</div>
						<div class="col">
							<asp:radiobuttonlist id="rblShift" runat="server" CssClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow">
								<asp:ListItem Value="A" Selected="True">A</asp:ListItem>
								<asp:ListItem Value="B">B</asp:ListItem>
								<asp:ListItem Value="C">C</asp:ListItem>
                                <asp:ListItem Value="G">G</asp:ListItem>
							</asp:radiobuttonlist></div>
						<div class="col">Operator:</div>
                        <div class="col">
							<asp:TextBox id="txtOperator" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox></div>

					</div>
                    <br />
                    <div class="row">
                        <div class="col">Cope(l)</div>
                        <div class="col">
							<asp:TextBox id="txtcope" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox></div>
                        <div class="col">Elect Operator:</div>
                        <div class="col">
							<asp:TextBox id="txtelect" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox></div>
                        <div class="col">Mech Operator:</div>
                        <div class="col">
							<asp:TextBox id="txtmech" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox></div>
                    </div>
                    <br />
					<div class="row">
						<div class="col">LineNumber:</div>
						<div class="col">
							<asp:radiobuttonlist id="rblLine" runat="server" CssClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow">
								<asp:ListItem Value="1" Selected="True">1</asp:ListItem>
								
								<asp:ListItem Value="2">2</asp:ListItem>
								
							</asp:radiobuttonlist></div>
						<div class="col">WhlType:</div>
						<div class="col">
							<asp:dropdownlist id="ddlWheelType" runat="server" CssClass="ll form-control" Width="200px"></asp:dropdownlist></div>
						
					</div>
                    <br />
				</table>
				<table id="Table1" class="table">
					<div class="row">
						<div class="col">BHN Standard</div>
						
						<div class="col">
							<asp:textbox id="txtBhnCert" runat="server" CssClass="form-control"  AutoPostBack="True" MaxLength="3" Width="200px"></asp:textbox></div>
						<div class="col">BhnObtained:</div>
						
						<div class="col">
							<asp:textbox id="txtBhnMeanObtd" runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="3" Width="200px"></asp:textbox></div>
					</div>
                    <br />
					<div class="row">
						<div class="col">AcceptableCriteria:</div>
							<div class="col">+/-<asp:Label id="lblAcc" runat="server"></asp:Label></div>
						
					
						<div class="col">ProcTolerance:</div>
						
						<div class="col">+/-
							<asp:Label id="lblPro" runat="server"></asp:Label>
							<asp:label id="Perc" runat="server" Font-Bold="True">%</asp:label></div>
					</div>
                    <br />
					<div class="row">
						<div class="col">Due Date:</div>
						
						<div class="col" colSpan="3">
							<asp:textbox id="txtDueDate" runat="server" CssClass="form-control" AutoPostBack="True" Width="200px"></asp:textbox></div>
                        <div class="col">Results:</div>
						
						<div class="col" colSpan="3">
							<asp:textbox id="txtResult" runat="server" CssClass="form-control" Width="200px">SATISFACTORY</asp:textbox></div>
					
					</div>
                    <br />
					
					<div class="row">
						<div class="col">Remarks:</div>
					
						<div class="col" colSpan="3">
							<asp:textbox id="txtRemark" runat="server" CssClass="form-control" TextMode="MultiLine" Style="margin-left:-293px"></asp:textbox></div>
					</div>
                    <br />
					<div class="row">
						<div class="col" align="middle" colSpan="4">
							<asp:button id="btnSave" runat="server" Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" Text="Save"></asp:button></div>
					</div>
				</table>
				<asp:DataGrid id="DataGrid1" CssClass="table" runat="server" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" BackColor="White">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<Columns>
						<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
			</asp:Panel>
                </div></div>
		</form>
            </div>
        <div class="card-footer" style="text-align:right;background-color:#cccccc;"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
	</body>
</html>
