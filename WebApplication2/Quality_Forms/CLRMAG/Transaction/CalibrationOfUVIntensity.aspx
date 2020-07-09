<%@ Page Language="vb" AutoEventWireup="false" Codebehind="CalibrationOfUVIntensity.aspx.vb" Inherits="WebApplication2.CalibrationOfUVIntensity" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>CalibrationOfUVIntensity</title>
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
     <!--   <link href="../../../StyleSheet1.css" rel="stylesheet" />-->
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
<!--/.Navbar -->
        <div class="container">
             <div class="row">
                 <div class="table">
                     
            
             
	
		<form id="Form1" method="post" runat="server">
            <!--  <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
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
						<div class="col" vAlign="top" align="middle" colSpan="5"><FONT size="5"> UV Intensity Records</FONT></div>
					</div>
                    <br />
					<div class="row">
						<div class="col" colSpan="5">
							<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></div>
					</div>
					<div class="row">
						<div class="col">Date</div>
                        <div class="col"></div>
						<div class="col" >
							<asp:textbox id="txtDate" runat="server" CssClass="form-control" AutoPostBack="True" Width="100px" ></asp:textbox></div>
					<div class="col"></div>	
                        <div class="col"></div>
                        <div class="col"></div><div class="col" >Shift</div><div class="col"></div>
						<div class="col">
							<asp:radiobuttonlist id="rblShift" runat="server" CssClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow" style="margin-left:-30px" >
								<asp:ListItem Value="A" Selected="True">A &nbsp</asp:ListItem>
								<asp:ListItem Value="B">B &nbsp</asp:ListItem>
								<asp:ListItem Value="C">C &nbsp</asp:ListItem>
                                <asp:ListItem Value="G">G &nbsp</asp:ListItem>
							</asp:radiobuttonlist></div>
                        
                        
					</div>
                    <br />
					<div class="row">
						<div class="col">Line Number</div>
						<div class="col">
							<asp:radiobuttonlist id="rblLine" runat="server" CssClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow" Height="10px" style="margin-left:50px">
								<asp:ListItem Value="1" Selected="True">1 &nbsp</asp:ListItem>
								<asp:ListItem Value="2">2 &nbsp</asp:ListItem>
								<asp:ListItem Value="3">3 &nbsp</asp:ListItem>
								<asp:ListItem Value="4">4 &nbsp</asp:ListItem>
							</asp:radiobuttonlist></div>
						<div class="col">Operator</div>
						<div class="col">
							<asp:TextBox id="txtOperator" runat="server" CssClass="form-control" AutoPostBack="True" Width="100px" style="margin-left:-65px"></asp:TextBox></div>
                        <div class="col">Drag(l)</div>
                        <div class="col"><asp:TextBox ID="txtdrag" runat="server" CssClass="form-control" Width="100px" style="margin-left:68px"></asp:TextBox></div>
					</div>
				</TABLE>
				<TABLE id="Table1" class="table">
					<div class="row">
						<div class="col">Cope:</div>
                        <div class="col">C1</div>
			
						<div class="col">
							<asp:textbox id="txtCopeone" runat="server" CssClass="form-control" MaxLength="4"></asp:textbox></div>
                        <div class="col">C2</div>
                        <div class="col"><asp:textbox id="txtCopetwo" runat="server" CssClass="form-control" MaxLength="4"></asp:textbox></div>
                        <div class="col">C3</div>
                        <div class="col"><asp:textbox id="txtCopethree" runat="server" CssClass="form-control"  MaxLength="4"></asp:textbox></div>
                        <div class="col">C4</div>
                        <div class="col"><asp:textbox id="txtCopefour" runat="server" CssClass="form-control"  MaxLength="4"></asp:textbox></div>
                        </div>
                    <br />
                    <div class="row">
						<div class="col">Drag:</div>
						<div class="col">D1</div>
						<div class="col">
							<asp:textbox id="txtDragone" runat="server" CssClass="form-control"  MaxLength="4"></asp:textbox></div>
                        <div class="col">D2</div>
                        <div class="col"><asp:textbox id="txtDragtwo" runat="server" CssClass="form-control"  MaxLength="4"></asp:textbox></div>
                        <div class="col">D3</div>
                        <div class="col"><asp:textbox id="txtDragthree" runat="server" CssClass="form-control"  MaxLength="4"></asp:textbox></div>
                        <div class="col">D4</div>
                        <div class="col"><asp:textbox id="txtDragfour" runat="server" CssClass="form-control" MaxLength="4"></asp:textbox></div>
					</div>
                    <br />
                    <div class="row">
                        <div class="col">Tread</div>
                        <div class="col" style="margin-left:-42px"><asp:TextBox runat="server" CssClass="form-control" ID="txttread" Width="100px"></asp:TextBox></div>
                    
                    
						
                        <div class="col">Due Date:</div>
						
						<div class="col">
							<asp:textbox id="txtDueDate" runat="server" CssClass="form-control" AutoPostBack="True" Width="100px" style="margin-left:-85px"></asp:textbox></div>
					</div>
                    <br />
                    <div class="row">
                        
                        <div class="col" style="margin-left:250px">( Intensity measured in 
							µW/cm² )</div>
                        </div>
                    
					<br />
					<div class="row">
						<div class="col">Results:</div>
						
						<div class="col" style="margin-left:-50px">
							<asp:RadioButtonList id="rblShim" runat="server" CssClass="rbl" RepeatLayout="Flow">
								<asp:ListItem Value="1" Selected="True">&nbsp;FOUND SATISFACTORY &nbsp</asp:ListItem>
								<asp:ListItem Value="2">&nbsp;FOUND NOT SATISFACTORY </asp:ListItem>
							</asp:RadioButtonList></div>
					
						<div class="col">Remarks:</div>
						
						<div class="col" >
							<asp:textbox id="txtRemark" runat="server" CssClass="form-control" TextMode="MultiLine" style="margin-left:-85px"></asp:textbox></div>
					</div>
                    <br />
					<div class="row">
						<div class="col" align="middle">
							<asp:button id="btnSave" runat="server"  Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" Text="Save"></asp:button>
							<asp:Label id="lblSl" runat="server" Visible="False"></asp:Label></div>
					</div>
				</TABLE>
				<asp:DataGrid id="DataGrid1" runat="server" CssClass="table" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" BackColor="White">
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
