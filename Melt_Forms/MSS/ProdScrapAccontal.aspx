<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ProdScrapAccontal.aspx.vb" Inherits="WebApplication2.ProdScrapAccontal" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0   transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>ProdScrapAccontal</title>
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
	<body>
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


        <div class="container">
        
           
		<form id="Form1" method="post" runat="server">
           
			<asp:panel id="Panel1" runat="server"  >
                 <div class ="row">
                
				<div class="table" >
                  <%--  style="WIDTH: 381px; HEIGHT: 27px" cellSpacing="1" cellPadding="1" width="381"--%>
					<div class="row">
						<div class="col" align="center"  >
							<asp:label id="lblConsignee" runat="server" Font-Bold="  true"></asp:label>&nbsp;<strong><h2>Production 
								Scrap&nbsp;Accountal Details</strong></h2></div>
					</div>
				</div>
				<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label>
				
                <div  class="table">
                   <%-- style="WIDTH: 202px; HEIGHT: 15px" cellSpacing="1" cellPadding="1" width="202"--%>
					<div class="row">
						<div class="col">
							<asp:Label id="lblDate" runat="server"></asp:Label>   Date</div>
						
						<div class="col" style="margin-left:20px">
							<asp:textbox id="txtUsageDate" runat="server" width="100px" AutoPostBack="true" CssClass="form-control"></asp:textbox></div>
						<div class="col">
							<asp:RadioButtonList id="rblType"     runat="server" AutoPostBack="  true"  RepeatLayout="Flow" RepeatDirection="Horizontal" Width="221px" >
                              <%--  Width="114px"Height="2px"--%>
								<asp:ListItem Value="0" Selected="  true">Usage</asp:ListItem>
								<asp:ListItem Value="CB">&nbsp;CB</asp:ListItem>
							</asp:RadioButtonList></div>
                            <div class="col"></div>
                        <div class="col"></div>
                          
                          

                        </div>
                    </div>
						                      
							<asp:panel id="Panel2" runat="server">
								
                                <div class="table"  >
                                   <%-- style="WIDTH: 177px; HEIGHT: 32px" cellSpacing="1" cellPadding="1" width="177"--%>
									<div class="row">
										<div class="col">MRXC Wheel Wt</div>
										<div class="col">
											<asp:TextBox id="txtMRXC" runat="server" CssClass="form-control"></asp:TextBox></div>
										<div class="col">MR Risers Hub</div>
										<div class="col">
											<asp:TextBox id="txtMRRisersHub" runat="server" CssClass="form-control"></asp:TextBox></div>
									</div>
							 </div>
							</asp:panel>
                       
				<asp:Panel id="Panel3" runat="server">
					<div class="table"  >
						<div class="row">
							<div class="col" >Heats 
								<asp:Label id="lblH" runat="server" Style="Color:#C000C0"></asp:Label>&nbsp; 
								WheelCast 
								<asp:Label id="lblC" runat="server" Style="Color:#804040"></asp:Label>&nbsp; 
								Total OB 
								<asp:Label id="lblTOB" runat="server" Style="Color:Purple"></asp:Label>&nbsp;Total 
								Receipt &nbsp;
								<asp:Label id="lbltr" runat="server" Style="Color:#C00000"></asp:Label>&nbsp;&nbsp; 
								Total Usage 
								<asp:Label id="lblTU" runat="server" Style="Color:Blue"></asp:Label>&nbsp;&nbsp;AvgPerHeat
								<asp:Label id="lblAvg" runat="server" Style="Color:Red"></asp:Label></div>
						</div>
					</div>
				</asp:Panel>
				<div class="table">
					<div class="row">
						<div class="col" ></div>
						<div class="col" style="margin-left:-20px" ><b>HMS&nbsp &nbsp &nbsp &nbsp&nbsp</b></div>
						<%--<TD align="center" colSpan="2">Axle End Cut</td>
						<<TD align="center" colSpan="2">Rail Cut</td>
						TD align="center" colSpan="2">ProScrap</td>--%>
						<div class="col"><b>Risers Hub</b></div>
						<div class="col" style="margin-left:20px" ><b>&nbsp &nbsp LMS</b></div>
						<div class="col" ><b>Chips AMSCR</b>&nbsp;</div>
                        
                         
					</div>
					<br><div class="row">
						<div class="col"><b>Item</b></div>
						<div class="col">Receipt</div>
						<div class="col">Usage</div>
						<%--<td>Receipt</td>
						<td>Usage</td>
						<td>Receipt</td>
						<td>Usage</td>
						<td>Receipt</td>
						<td>Usage</td>--%>
						<div class="col">Receipt&nbsp;</div>
						<div  class="col">Usage</div>
						<div class="col">Receipt</div>
						<div class="col">Usage&nbsp;&nbsp;&nbsp;</div>
						<div class="col">Receipt</div>
						<div class="col">Usage</div>
					</div>
					<br><div class="row">
						<div class="col">
							<asp:Label id="lblOB" runat="server"><b>OB</b></asp:Label></div>
						<div class="col">
							<asp:Label id="lblWCOB" runat="server"></asp:Label></div>
						<div class="col"></div>
					
						<div class="col">
							<asp:Label id="lblRHOB" runat="server"></asp:Label></div>
						<div class="col" ></div>
						<div class="col" >
							<asp:Label id="lblLOB" runat="server"></asp:Label></div>
						<div class="col" ></div>
						<div class="col">
							<asp:Label id="lblCOB" runat="server"></asp:Label></div>
						<div class="col"  ></div>
					</div>
					<div class="row">
						<div class="col"  >
							<asp:Label id="lbl" runat="server"></asp:Label></div>
						<div class="col"  >
							<asp:Label id="lblWCR" runat="server"></asp:Label></div>
						<div class="col" style="margin-left:-12px">
							<asp:TextBox id="txtWCU" runat="server" AutoPostBack="true" CssClass="form-control"></asp:TextBox></div>
						<div class="col"  >
							<asp:Label id="lblRHR" runat="server"></asp:Label></div>
						<div class="col">
							<asp:TextBox id="txtrHU" runat="server" AutoPostBack="  true" CssClass="form-control"></asp:TextBox></div>
						<div class="col">
							<asp:Label id="lblLR" runat="server"></asp:Label></div>
						<div class="col">
							<asp:TextBox id="txtLU" runat="server" AutoPostBack="  true" CssClass="form-control"></asp:TextBox></div>
						<div class="col">
							<asp:Label id="lblCR" runat="server"></asp:Label></div>
						<div class="col">
							<asp:TextBox id="txtCU" runat="server" AutoPostBack="  true" CssClass="form-control"></asp:TextBox></div>
					</div>
					<br><div class="row">
						<div class="col" align="center" >
							<asp:Button id="btnSave" runat="server" Font-Size="20px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" Text="Save"></asp:Button></div>
					</div>
				</div>
				<asp:DataGrid id="DataGrid1" runat="server" CssClass="table"  >
					<SelectedItemStyle Font-Bold="  true" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="  true" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
                    
              </div>
			</asp:panel>
            
		</form>
             </div>       
              <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;position:absolute;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div> 
	<script>
 $(document).ready(function () {
                       
                        $('#txtUsageDate').datepicker({
                            dateFormat: "dd-mm-yy", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtUsageDate').datepicker('getDate');           
                                                 
                              
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
