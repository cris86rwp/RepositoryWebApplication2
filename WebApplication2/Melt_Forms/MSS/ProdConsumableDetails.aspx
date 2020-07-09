<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ProdConsumableDetails.aspx.vb" Inherits="WebApplication2.ProdConsumableDetails" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>ProdConsumableDetails</title>
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
 
	</HEAD>
     <style type="text/css">
         .ui-datepicker {
    background: #333;
    border: 1px solid #555;
    color: #EEE;
    
}

          .rbl input[type="radio"] 
          {
    margin-left:5px;
    margin-right: 15px;
}
</style>

	<body >
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
        
         <div class="container" align="center">
		<form id="Form1" method="post" runat="server">
			<asp:panel id="Panel2"  runat="server">
				<div class="table">
					<div class="row">
						<div class="col"  >
							<asp:panel id="Panel1" runat="server" >
								<div class=table>
									<div class="row">
										<div class="col" >
											<asp:label id="lblConsignee" runat="server" Font-Bold="True"></asp:label>&nbsp;<STRONG><h2>Production 
												Consumables Details</STRONG></h2></div>
									</div>
									<div class="row">
										<div class="col">
											<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></div>
									</div>
									<div class="row">
										<div class="col">
											<asp:RadioButtonList id="rblType" runat="server" AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal"></asp:RadioButtonList></div>
									</div>
								</div>
								<div class="table">
									<div class="row">
										<div class="col">
											<asp:Label id="lblType" runat="server"></asp:Label>  Date &nbsp &nbsp &nbsp</div>
									
										<div class="col">
											<asp:TextBox id="txtTransDate" runat="server" Width="104px" AutoPostBack="True"></asp:TextBox></div>
									 <div class="col"></div>
                         <div class="col"></div>
                                    </div>
									<br><div class="row">
										<div class="col-3">
											<asp:Label id="lblType1" runat="server"></asp:Label>  Number</div>
										
										<div class="col">
											<asp:TextBox id="txtNumber" Width="104px" runat="server" AutoPostBack="True"></asp:TextBox></div>
									 <div class="col"></div>
                         <div class="col"></div>
                                    </div>
									<br><div class="row">
										<div class="col-3">Drawn Qty  &nbsp &nbsp  &nbsp </div>
										 
										<div class="col">
											<asp:TextBox id="txtQty" Width="104px" runat="server" ></asp:TextBox></div>
									 <div class="col"></div>
                         <div class="col"></div>
                                    </div>
									<br><div class="row">
										<div class="col">
											<asp:Panel id="pnlNonPl" runat="server">
												<div class="table">
													<div class="row">
														<div class="col-3">Supplier &nbsp &nbsp  &nbsp &nbsp</div>
														
														<div class="col">
															<asp:TextBox id="txtSupplier"  Width="104px" runat="server"></asp:TextBox></div>
													 <div class="col"></div>
                         <div class="col"></div>
                                                    </div>
												</div>
											</asp:Panel>
											<asp:Panel id="pnlPl" runat="server">
												<div class="table">
													<div class="row">
														<div class="col" >
															<asp:RadioButtonList id="rblPL" runat="server" RepeatLayout="Flow" CssClass="rbl" AutoPostBack="true" RepeatDirection="Horizontal"></asp:RadioButtonList></div>
													</div>
												</div>
											</asp:Panel></div>
									</div>
									<div class="row">
										<div class="col-3">Remarks  &nbsp &nbsp &nbsp &nbsp </div>
										
										<div class="col">
											<asp:TextBox id="txtRemarks" Width="104px" runat="server"></asp:TextBox></div>
									 <div class="col"></div>
                         <div class="col"></div>
                                    </div>
									<div class="row">
										<div class="col" align="center">
											<asp:Button id="btnSave" Font-Size="20px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark"  runat="server" Text="Save"></asp:Button>
											<asp:Label id="lblTransID" runat="server"></asp:Label></div>
									</div>
								</div>
							</asp:panel></div>
						
							<div class="table">
								<div class="row">
									<div class="col">
										<asp:Label id="lblType2" runat="server"></asp:Label>&nbsp; Details</div>
								</div>
								<div class="row">
									<div class="col">
										<asp:DataGrid id="DataGrid1" runat="server" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4">
											<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
											<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
											<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
											<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
											<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
										</asp:DataGrid></div>
								</div>
								<div class="row">
									<div class="col">Drawal Details for the number</div>
								</div>
								<div class="row">
									<div class="col">
										<asp:DataGrid id="DataGrid2" runat="server" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4">
											<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
											<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
											<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
											<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
											<Columns>
												<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
											</Columns>
											<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
										</asp:DataGrid></div>
								</div>
							</div>
						</div>
					</div>
					<div class="row">
						<div class="col">Drawal Details for PL 
							<asp:Label id="lblPLNo" runat="server"></asp:Label>&nbsp; 
							<asp:Label id="lblQty" runat="server"></asp:Label></div>
					</div>
					<div class="row">
						<div class="col">
							<asp:DataGrid id="DataGrid3" runat="server" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" BackColor="#DEBA84" CellPadding="3" CellSpacing="2">
								<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#738A9C"></SelectedItemStyle>
								<ItemStyle ForeColor="#8C4510" BackColor="#FFF7E7"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#A55129"></HeaderStyle>
								<FooterStyle ForeColor="#8C4510" BackColor="#F7DFB5"></FooterStyle>
								<PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid></div>
					</div>
					<div class="row">
						<div class="col">Drawal Details for the Day </div>
					</div>
				</div>
				<asp:DataGrid id="DataGrid4" runat="server" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" BackColor="White" CellPadding="4" GridLines="Horizontal">
					<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#339966"></SelectedItemStyle>
					<ItemStyle ForeColor="#333333" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#336666"></HeaderStyle>
					<FooterStyle ForeColor="#333333" BackColor="White"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="White" BackColor="#336666" Mode="NumericPages"></PagerStyle>
				</asp:DataGrid>
			</asp:panel></form></div>
        <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;position:absolute;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
	<script>
 $(document).ready(function () {
                       
                        $('#txtTransDate').datepicker({
                            dateFormat: "dd-mm-yy", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtTransDate').datepicker('getDate');           
                                                 
                              
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
