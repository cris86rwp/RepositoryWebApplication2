<%@ Page Language="vb" AutoEventWireup="false" Codebehind="CalibrationOfMagAndUTInWheelShop.aspx.vb" Inherits="WebApplication2.CalibrationOfMagAndUTInWheelShop" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>CalibrationOfMagAndUTInWheelShop</title>
		

		
 
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

	</head>
	<body>         <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
  <a class="navbar-brand p-0" href="#"><img src="../../..//NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
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
          <i class="fab glyphicon glyphicon-home "></i>
        </a></li>

       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out"></i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
         
        <img src="../../../NewFolder1/CRIS-Recruitment.jpg" height="45" style="border-radius:43%"/>
       </a>
      </li>
     </ul>
      
  </div>
</nav>
        </style>

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

                        
</script>
        <br />
<!--/.Navbar -->
        <div class="container">
             <div class="row">
                 <div class="table-responsive">
                     
            
 
		<form id="Form1" method="post" runat="server">
            <!-- <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
                <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true"  CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />-->

			<asp:panel id="Panel1" runat="server">
				<TABLE id="Table4" class="table">
					<div class="row">
						<div class="col" vAlign="top" align="center" colSpan="5"><FONT size="6" Font-Bold="True" >Calibration</FONT></div>
					</div>
                    <br />
					<div class="row">
						<div class="col" colSpan="5">
							<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></div>
					</div>
                    <br />
					<div class="row">
						<div class="col" vAlign="top" align="middle" colSpan="5">
							<asp:radiobuttonlist id="rblTestType" runat="server" CssClass="rbl" AutoPostBack="True" RepeatDirection="Horizontal" RepeatLayout="Flow">
								<asp:ListItem Value="MAG" Selected="True">MAG</asp:ListItem>
								<asp:ListItem Value="UT  Results">UT</asp:ListItem>
								<asp:ListItem Value="UT SetUp">UT SetUp</asp:ListItem>
							</asp:radiobuttonlist>
							<asp:Label id="lblSlNo" runat="server" Visible="False"></asp:Label></div>
					</div>
                    <br />
					<div class="row">
						<div class="col">Date</div>
						<div class="col">
							<asp:textbox id="txtDate" runat="server" AutoPostBack="True" CssClass="form-control"></asp:textbox></div>
						<div class="col">Shift</div>
						<div class="col">
							<asp:radiobuttonlist id="rblShift" runat="server" AutoPostBack="True" CssClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow">
								<asp:ListItem Value="A" Selected="True">A</asp:ListItem>
								<asp:ListItem Value="B">B</asp:ListItem>
								<asp:ListItem Value="C">C</asp:ListItem>
                                <asp:ListItem Value="G">G</asp:ListItem>
							</asp:radiobuttonlist></div>
						<div class="col">Operator</div>
                        
                        <div class="col">Cope(l)</div>
                        
					</div>
                    <br />
					<div class="row">
                       <!-- line number changed -->
						<div class="col">LineNumber</div>
						<div class="col">
							<asp:radiobuttonlist id="rblLine" runat="server" AutoPostBack="True" CssClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow">
								<asp:ListItem Value="1" Selected="True">1</asp:ListItem>
								<asp:ListItem Value="2">2</asp:ListItem>
								<asp:ListItem Value="3">3</asp:ListItem>
								<asp:ListItem Value="4">4</asp:ListItem>
							</asp:radiobuttonlist></div>
						<div class="col">Present WhlType</div>
						<div class="col">
							<asp:dropdownlist id="ddlWheelType" CssClass="form-control ll" runat="server" AutoPostBack="True"></asp:dropdownlist></div>
						<div class="col">
							<asp:TextBox id="txtOperator" runat="server" CssClass="form-control"></asp:TextBox></div>
                        <div class="col"><asp:TextBox ID="txtcope" runat="server" CssClass="form-control"></asp:TextBox></div>
					</div>
				</TABLE>
				<table id="Table1" class="table"></table>
					
							<asp:Panel id="pnlMAG" runat="server">
								<TABLE id="Table2" class="table">
									<div class="row">
										<div class="col">BathConcentration:</div>
									
										<div class="col">
											<asp:textbox id="txtBathConc" runat="server" AutoPostBack="True" CssClass="form-control" MaxLength="4"></asp:textbox></div>
										<div class="col">Shim/PieGauge Check:</div>
										
										<div class="col">
											<asp:RadioButtonList id="rblShim" runat="server" CssClass="rbl" RepeatLayout="Flow">
												<asp:ListItem Value="FOUND SATISFACTORY" Selected="True">FOUND SATISFACTORY</asp:ListItem>
												<asp:ListItem Value="FOUND NOT SATISFACTORY">FOUND NOT SATISFACTORY</asp:ListItem>
											</asp:RadioButtonList></div>
									</div>
                                    <br />
								</TABLE>
							</asp:Panel>
							<asp:Panel id="pnlUT" runat="server">
								<TABLE id="Table7" class="table">
									<div class="row">
										<div class="col">TimeFrom</div>
										<div class="col">
											<asp:textbox id="txtTimeFrom" runat="server" AutoPostBack="True" CssClass="form-control" MaxLength="5"></asp:textbox></div>
										<div class="col">TimeTo</div>
										<div class="col">
											<asp:textbox id="txtTimeTo" runat="server" AutoPostBack="True" CssClass="form-control" MaxLength="5"></asp:textbox></div>
									</div>
								</TABLE>
								<table id="Table3" class="table">
                                    </table>
									
											<asp:Panel id="pnlResults" runat="server">
												<TABLE id="Table5" class="table">
													<div class="row">
														<div class="col">Results</div>
														<div class="col">
															<asp:textbox id="txtResult" runat="server" CssClass="form-control">SATISFACTORY</asp:textbox></div>
													</div>
												</TABLE>
											</asp:Panel>
											<asp:Panel id="pnlSetUp" runat="server">
												<TABLE id="Table6" class="table">
													<div class="row">
                                                        <div class="col">Changed To WhlType</div>
														<div class="col">
															<asp:dropdownlist id="ddlWheelType1" runat="server" CssClass="form-control ll"></asp:dropdownlist></div>
													</div>
												</TABLE>
											</asp:Panel>
							
								
							</asp:Panel>
					<table class="table">
                        <div class="row">
						<div class="col">Remarks</div>
						<div class="col">
							<asp:textbox id="txtRemark" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:textbox></div>
					</div>
                        <br />
					<div class="row">
						<div class="col" align="Center" colspan="6">
							<asp:button id="btnSave" runat="server" Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" Text="Save"></asp:button></div>
					</div>
                        <br/>
				</table>
				<asp:DataGrid id="DataGrid1" runat="server" CssClass="table" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<Columns>
						<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
			</asp:panel></form></div></div></div>
            <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
	</body>
</html>
