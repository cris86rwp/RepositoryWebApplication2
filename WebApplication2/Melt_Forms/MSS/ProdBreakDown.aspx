<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ProdBreakDown.aspx.vb" Inherits="WebApplication2.ProdBreakDown" %>
<!DOCTYPE HTML >
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>ProdBreakDown</title>
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
 
         
	</head>
     <style type="text/css">
         .ui-datepicker {
    background: #333;
    border: 1px solid #555;
    color: #EEE;
    
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
               
           
			<asp:Panel id="Panel2" runat="server">
                 <div class ="row">
                

				<div class="table">
			</div>

							<asp:Panel id="Panel1" runat="server">
								<div class="table">
									<div class="row">
										<div class="col" align="center"><strong>Break Down Memo-Time Loss duration ( will be taken for PCDO only if Break Down if saved as 'Affected - Yes')</strong></div>
									</div>
								</div>
								<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label>
								<div class="table">
									<div class="row">
										<div class="col">Break Down Date  &nbsp &nbsp &nbsp &nbsp &nbsp</div>
										
										<div class="col">
											<asp:TextBox id="txtBrDate" runat="server" CssClass="form-control" width="100px" AutoPostBack="True"></asp:TextBox></div>
                                        <div class="col"></div>
                                        <div class="col"></div>
                                        
                                    
									</div>
								</div>
                                </div>
                <div class="table-responsive">
								<asp:DataGrid id="DataGrid1" runat="server" CssClass="table">
									<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
									<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
									<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
									<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
									<Columns>
										<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
									</Columns>
									<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
								</asp:DataGrid>
                    </div>
                <br>
								<div class="table">
									<br><div class="row">
										<div class="col">Time Loss As Per PCDO</div>
										<div class="col">
											<asp:TextBox id="txtLoss" runat="server"  width="100px" CssClass="form-control"></asp:TextBox></div>
										<div class="col">Memo Slip No</div>
										<div class="col">
											<asp:TextBox id="txtMemoSlipNo" runat="server"  width="100px" CssClass="form-control"></asp:TextBox></div>
										<div class="col">Affected</div>
										<div class="col">
											<asp:RadioButtonList id="rblAff" runat="server" CssClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow">
												<asp:ListItem Value="1">&nbsp;Yes&nbsp</asp:ListItem>
												<asp:ListItem Value="0">&nbsp;No</asp:ListItem>
											</asp:RadioButtonList></div>
									</div>
								</div><br>
								<div class="table">
									<div class="row">
										<div class="col" >
											<asp:Label id="lblSlipNo" runat="server" Visible="False"></asp:Label>
											<asp:Button id="btnUpdate"  Font-Size="20px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark"  runat="server"  align="center" Text="Update"></asp:Button>
											<asp:Label id="lblMemoNo" runat="server" Visible="False"></asp:Label></div>
									</div>
								</div>
							</asp:Panel>
				
				<div class="table">
			</div>
							<asp:Panel id="pnlOff" runat="server" >
								<div class="table">
									<div class="row">
										<div class="col"><h3>Off Heat Remarks</h3></div>
									</div><br>
									<div class="row">
										<div class="col" >Heat No  &nbsp &nbsp &nbsp &nbsp  &nbsp &nbsp &nbsp &nbsp  &nbsp &nbsp &nbsp &nbsp  &nbsp &nbsp &nbsp &nbsp  &nbsp &nbsp &nbsp &nbsp;</div>
									
										<div class="col" >
											<asp:TextBox id="txtHeatNo" runat="server"  width="100px"  CssClass="form-control" AutoPostBack="True"></asp:TextBox></div>
                                        <div class="col"></div>
                                        <div class="col"></div>
                                        <div class="col"></div>
                                        <div class="col"></div>
                                        
                                        
									</div>
								</div>
								<div class="table">
									<div class="row">
										<div class="col">Remarks&nbsp &nbsp &nbsp &nbsp  &nbsp &nbsp &nbsp &nbsp  &nbsp &nbsp &nbsp &nbsp  &nbsp &nbsp &nbsp &nbsp  &nbsp &nbsp &nbsp &nbsp;
						
										</div>
										
										<div class="col">
											<asp:TextBox id="txtHeatRemarks" runat="server" width="100px"  CssClass="form-control" TextMode="MultiLine" ></asp:TextBox></div>
									 <div class="col"></div>
                                        <div class="col"></div>
                                        <div class="col"></div>
                                        <div class="col"></div>
                                        
                                        
                                    </div>
								</div>
								<div class="table">
									<div class="row">
										<div class="col" align="center">
											<asp:Button id="btnRem"  Font-Size="20px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark"  runat="server" Text="Update Remarks"></asp:Button></div>
									</div>
								</div>
							</asp:Panel>
                </div>
			</asp:Panel>
		</form>
             
        
           <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;position:relative;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
	<script>
 $(document).ready(function () {
                       
                        $('#txtBrDate').datepicker({
                            dateFormat: "dd-mm-yy", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtBrDate').datepicker('getDate');           
                                                 
                              
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
