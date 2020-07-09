<%@ Page Title="Melting Queries" Language="vb" AutoEventWireup="false" Codebehind="MeltingQuerry.aspx.vb" Inherits="WebApplication2.MeltingQuerry" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Melting Query</title>
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

	<body>
       <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
  <a class="navbar-brand p-0" href="#"><img src="../../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent-333"
    aria-controls="navbarSupportedContent-333" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>
  <div class="collapse navbar-collapse " id="navbarSupportedContent-333">
      <ul class="navbar-nav ml-auto  navbar-center">
          <li class="nav-item"> <a class="nav-link" href="#" style="color:white; font-size:25px;">Rail Wheel Plant Bela</a></li>
      </ul>
    <ul class="navbar-nav ml-auto  navbar-right">
       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home "style="font-size:30px;"></i>
        </a></li>

       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out"style="font-size:30px;"></i>
        </a></li>
        
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
          <img src="../../NewFolder1/CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="45"/>
       </a>
      </li>
     </ul>
      
  </div>
</nav>
 <div class="container">
            <div class="row">
                <div class="table">
       <form id="Form2" method="post" runat="server">
           
			<asp:panel id="Panel1" runat="server">
				<div class="table">
					<div class="row">
						<div class="col" align="center" colSpan="6"><FONT size="5">Melting Queries</FONT></div>
					</div><br><br>
					<div class="row">
						<div class="col" align="center" colSpan="6">
							<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></div>
					</div>
					<div class="row">
						<div class="col" align ="center">
							<asp:RadioButtonList id="rblList" runat="server" RepeatLayout="Flow" AutoPostBack="True" Font-Bold="True" RepeatDirection="Horizontal" CssClass="rbl">
								<asp:ListItem Value="Date" Selected="True">&nbsp;Date&nbsp;</asp:ListItem>
								<asp:ListItem Value="Heat">&nbsp;Heat</asp:ListItem>
							</asp:RadioButtonList></div>
					</div><br><br>
					<div class="row">
						<div class="col">From </div>
                        <div class="col"></div>

						<div class="col">
							<asp:TextBox id="txtFrom" runat="server" CssClass="form-control" Width="82px"></asp:TextBox></div>
						<div class="col" style="margin-left:100px">To </div>
                        <div class="col"></div>
                        <div class="col"></div>

						<div class="col">
							<asp:TextBox id="txtTo" runat="server" CssClass="form-control" Width="82px"></asp:TextBox></div>
                        <div class="col"></div>
<div class="col"></div>
                        <div class="col"></div>


                        <div class="row">
						<div class="col">Carbon</div>
                            <div class="col"></div>

						<div class="col">
							<asp:TextBox id="TextBox1" runat="server" CssClass="form-control" AutoPostBack="True" Width="85px"></asp:TextBox></div>
                        <div class="col"></div>

                         <div class="col"></div>
					</div><br><br>
                        <div class="col"></div>
<div class="col"></div>
<div class="col"></div>

                        </div>
				
					
                  <br><br>  <div class="container"  style="margin-left:-140px">
					<div class="row">
						<div class="col" >
							<asp:RadioButtonList id="rblQry" runat="server" AutoPostBack="True" RepeatDirection="horizontal" CssClass="rbl" >
								<asp:ListItem Value="1" Selected="True">Carbon Details </asp:ListItem>
								<asp:ListItem Value="2">Heat Position</asp:ListItem>
								<asp:ListItem Value="3">Power Consumption</asp:ListItem>
								<asp:ListItem Value="4">SMS XC Details </asp:ListItem>
								<asp:ListItem Value="5">Magna OffLoads Date Wise</asp:ListItem>
								<asp:ListItem Value="6">Recovery Analysis</asp:ListItem>
								<asp:ListItem Value="7">XC 51 Analysis</asp:ListItem>
								<asp:ListItem Value="8">Electrode Breakage</asp:ListItem>
								<asp:ListItem Value="9">Fettling Details</asp:ListItem>
								<asp:ListItem Value="10">PTMS Contracts Date Wise</asp:ListItem>
								<asp:ListItem Value="11">RSM LOA Details</asp:ListItem>
								<asp:ListItem Value="12">JMP Details</asp:ListItem>
								<asp:ListItem Value="13">Ladle Usage Date Wise</asp:ListItem>
								<asp:ListItem Value="14">Off Heats Date Wise</asp:ListItem>
								<asp:ListItem Value="15">Fume Extraction Date Wise</asp:ListItem>
								<asp:ListItem Value="16">Slag Results Date Wise</asp:ListItem>
								<asp:ListItem Value="17">Melt Shop Heat Loss Date Wise</asp:ListItem>
								<asp:ListItem Value="18">Melting Items Make &amp; Qty</asp:ListItem>
							</asp:RadioButtonList></div>
                                                <div class="col"></div>
                        <div class="col"></div>
                        <div class="col"></div>

					</div>
                        </div>
                      
					<div class="row">
						<dv class="col" align="center" >
							<asp:Button id="btnReport" runat="server" Text="Show Results"   Font-Size="20px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark"></asp:Button></dv>
					</div><br>
					<div class="row">
						<div class="col" align="center" >
							<asp:Button id="Button1" runat="server" Text="Export to Excel"  Font-Size="20px" Font-Bold="True" BorderStyle="Solid"  CssClass="btn btn-dark"   ></asp:Button></div>
					</div>
				</div>
				<asp:DataGrid id="DataGrid1" runat="server" Width="534px" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
			</asp:panel>
		</form>
                    </div>
                </div>
     </div>
                    <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;position:absolute;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>


<script>
 $(document).ready(function () {
                       
                        $('#txtFrom').datepicker({
                            dateFormat: "dd-mm-yy", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtFrom').datepicker('getDate');           
                                                 
                              
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
                       
                        $('#txtTo').datepicker({
                            dateFormat: "dd-mm-yy", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtTo').datepicker('getDate');           
                                                 
                              
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
