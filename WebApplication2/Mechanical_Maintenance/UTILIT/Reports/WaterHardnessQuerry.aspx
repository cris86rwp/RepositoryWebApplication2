<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WaterHardnessQuerry.aspx.vb" Inherits="WebApplication2.WaterHardnessQuerry" Culture="en-GB" uiCulture="en-GB" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>WaterHardnessQuerry</title>
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
</nav>   <br />
			<div class="container">
		<form id="Form2" method="post" runat="server">
             <div class="row">
    
                  <%--<h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" CssClass="form-control ll" OnSelectedIndexChanged="dd1_SelectedIndexChanged"  Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
      </div>
          
			<asp:Panel id="Panel1" runat="server">
		  <div class="table">
              <br />
					<div class="row">
						<div class="col"><FONT size="5"><strong>Industrial Cooling water report as on</strong></FONT></div>
							<div class="col">	<asp:TextBox id="txtDate" runat="server" AutoPostBack="True" CssClass="form-control" Width="103px"></asp:TextBox>
								<asp:CheckBox id="chkRefersh" runat="server" AutoPostBack="True" CssClass="checkbox" Text="Refersh"></asp:CheckBox></div>
					</div>
              <br />
					<div class="row">
						<div class="col">
							<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></div>
					</div>
					<br />
				
				<asp:DataGrid id="DataGrid1" runat="server" AutoGenerateColumns="False" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<Columns>
						<asp:BoundColumn DataField="Date" HeaderText="Date"></asp:BoundColumn>
						<asp:BoundColumn DataField="Time" HeaderText="Time"></asp:BoundColumn>
						<asp:BoundColumn DataField="Raw Water" HeaderText="Raw Water"></asp:BoundColumn>
						<asp:BoundColumn DataField="After Softning" HeaderText="After Softning"></asp:BoundColumn>
						<asp:BoundColumn DataField="Cold Water" HeaderText="Cold Water"></asp:BoundColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
					<div  class="row">
                       
						<div class="col">A)&nbsp; Hardness values of water in ppm</div>
					</div>
              <div  class="row">
						<div class="col">B ) No. of hours Softening Plant worked
							<asp:Label id="lblSofteningHrs" runat="server" Font-Underline="True"></asp:Label>&nbsp;Hrs</div>
					</div>
					<div  class="row">
						<div class="col">C ) Qty of water added through Softener :
							<asp:Label id="lblSoft_Qty" runat="server" Font-Underline="True"></asp:Label>&nbsp;Lts</div>
					</div>
					<div class="row">
						<div class="col">D ) Qty of water added&nbsp;by-passing Softener :
							<asp:Label id="lblByPass_Qty" runat="server" Font-Underline="True"></asp:Label>&nbsp;Lts</div>
					</div>
					<div class="row">
						<div class="col">E ) Total water added to system :
							<asp:Label id="lblTotal_Qty" runat="server" Font-Underline="True"></asp:Label>&nbsp;Lts</div>
					</div>
				<br />
				
					<div class="row">
						<div class="col">From&nbsp;Date</div>
						
						<div class="col">
							<asp:textbox id="txtFromDate" runat="server" CssClass="form-control" Width="103px"></asp:textbox></div>
					
						<div class="col">To Date</div>
						
						<div class="col">
							<asp:textbox id="txtToDate" runat="server" CssClass="form-control" Width="103px"></asp:textbox>
							<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" Display="Dynamic" ControlToValidate="txtToDate" ErrorMessage="*"></asp:RequiredFieldValidator></div>
					</div>
              <br />
					<div class="row">
						<div class="col" align="center">
                             <asp:button id="btnPoNo" runat="server" Text="Get DATA"  Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" ></asp:button>

							<asp:CustomValidator id="CustomValidator1" runat="server" ControlToValidate="txtToDate" ErrorMessage="CustomValidator"></asp:CustomValidator></div>
					</div>
				</div>
				<asp:DataGrid id="DataGrid2" runat="server" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#3366CC">
					<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
				</asp:DataGrid>
			</asp:Panel>

		</form>
                    <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;position:absolute;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
  <script type="text/javascript">
     $(document).ready(function () {
                       
                        $('#txtFromDate').datepicker({
                            dateFormat: "yy/mm/dd", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtFromDate').datepicker('getDate');           
                                                 
                              
                            }
                        });
    
  function getDate( element ) {
    var date;
    var dateFormat = "yyyy/MM/dd";
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
                            dateFormat: "yy/mm/dd", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtToDate').datepicker('getDate');           
                                                 
                              
                            }
                        });
    
  function getDate( element ) {
    var date;
    var dateFormat = "yyyy/MM/dd";
    try {
      date = $.datepicker.parseDate( dateFormat, element.value );
    } catch( error ) {
      date = null;
    }

    return date;
  }
      });
     
    $(document).ready(function () {
                       
                        $('#txtDate').datepicker({
                            dateFormat: "yy/mm/dd", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtDate').datepicker('getDate');           
                                                 
                              
                            }
                        });
    
  function getDate( element ) {
    var date;
    var dateFormat = "yyyy/MM/dd";
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
