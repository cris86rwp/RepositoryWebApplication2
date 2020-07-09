<%@ Page Language="vb" AutoEventWireup="false" Codebehind="HSDUTConsumption.aspx.vb" Inherits="WebApplication2.HSDUTConsumption" %>
<!DOCTYPE html PUBLIC "-//W3C//Dtd html 4.0 transitional//EN">
<html>
	<head runat="server">
		<title>HSDConsumption</title>
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
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home " style="font-size:30px;"></i>
        </a></li>
       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out" style="font-size:30px;"></i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
          <img src="../../NewFolder1/CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="45"/>
        </a>
      </li>
     </ul>
      
  </div>
</nav>  <br />
  
		<form id="Form1" method="post" runat="server">
            


     
                
    
                            <%--  <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                             <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                                 <asp:ListItem>select</asp:ListItem>
                                 <asp:ListItem>Theme1</asp:ListItem>
                                 <asp:ListItem>Theme2</asp:ListItem>
                                 <asp:ListItem>Theme3</asp:ListItem>
                             </asp:DropDownList>--%>
                              
    <FONT size="5"> <asp:Label id="lblShop" runat="server"></asp:Label></FONT>
                                            
			<asp:panel id="Panel1" runat="server">
                <div class="container">
<div class="table">
			
					<div class="row">
						<div class="col"><strong>LPG AND Cutting Gas FLOW METER</strong><FONT size="20">&nbsp;</FONT></div>
					</div><br />
                    <div class="row">
                               
								<div class="col">
									<asp:RadioButtonList id="rblArea" runat="server" CSSClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow" AutoPostBack="True">
											<asp:ListItem Value="LPG" Selected="True">LPG&nbsp;</asp:ListItem>
								            <asp:ListItem Value="BMCG">BMCG&nbsp;</asp:ListItem>
										   </asp:RadioButtonList>
                                    </div>
                                   </div> <br />
                    <div class="row">
                               
								<div class="col">
									<asp:RadioButtonList id="RadioButtonList1" runat="server" CSSClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow" AutoPostBack="True">
											<asp:ListItem Value="NF" >NF</asp:ListItem>
								            <asp:ListItem Value="DF">DF&nbsp;</asp:ListItem>
                                             <asp:ListItem Value="SP">SP&nbsp;</asp:ListItem>
                                         <asp:ListItem Value="LPH">LPH&nbsp;</asp:ListItem>
										 <asp:ListItem Value="TPH">TPH&nbsp;</asp:ListItem>   
                                        </asp:RadioButtonList>
                                    </div>
                                   </div> 
    <br /><div class="row">
                               
								<div class="col">
									<asp:RadioButtonList id="RadioButtonList2" runat="server" CSSClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow" AutoPostBack="True">
											<asp:ListItem Value="HC1" Selected="True">HC1&nbsp;</asp:ListItem>
								            <asp:ListItem Value="HC2">HC2&nbsp;</asp:ListItem>
                                         <asp:ListItem Value="HC3">HC3&nbsp;</asp:ListItem>
                                         <asp:ListItem Value="MRS">MRS&nbsp;</asp:ListItem>
										   </asp:RadioButtonList>
                                    </div>
                                   </div> 
                         <br />    

					<div class="row">
						<div class="col">
							&nbsp;</div>
					</div>
    <br />
					<div class="row">
						<div class="col">
							<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></div>
					</div>
	<br />			
				<%--<table id="table2" class="table">
					<tr>
						<td>
							<asp:RadioButtonList id="rblDataPoints" runat="server" AutoPostBack="true" Repeatdirection="Horizontal" RepeatLayout="Flow" CssClass="rbl">
                               
							</asp:RadioButtonList></td>
					</tr>
				</table>--%>
				<asp:Panel id="Panel2" runat="server">
					
						<div class="row">
							<div class="col">Previous Date</div>
							
							<div class="col">
								<asp:TextBox id="txtPreDate" runat="server" AutoPostBack="true" CssClass="form-control" Width="103px" ></asp:TextBox></div>
							<div class="col">Meter Reading</div>
						
							<div class="col">
								<asp:TextBox id="txtPreMeterReading" runat="server" AutoPostBack="true" CssClass="form-control" width="103px" ></asp:TextBox></div>
							<div class="col">Consumption</div>
							
							<div class="col">
								<asp:Label id="lblConsumption" runat="server"></asp:Label></div>
						</div>
                    <br />
						<div class="row">
							<div class="col">Remarks</div>
							
							<div class="col">
								<asp:TextBox id="txtremarks" runat="server" CssClass="form-control" width="103px" ></asp:TextBox></div>
						
						<div class="col">Date</div>
						
						<div class="col">
							<asp:TextBox id="txtdate" runat="server" AutoPostBack="true" CssClass="form-control" width="103px" ></asp:TextBox></div>
						<div class="col">MeterReading</div>
						
						<div class="col">
							<asp:TextBox id="txtMeterReading" runat="server" AutoPostBack="true" CssClass="form-control" width="103px" ></asp:TextBox></div>
					</div>
                    <br />
					<div class="row">
						<div class="col" align="center">
                          <asp:button id="btnSave" runat="server" Text="Save"  Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" ></asp:button>
				
					</div>
				</div>
                    </div>
                </asp:panel>
				 

            <asp:datagrid id="DataGrid1" CssClass="table" runat="server" CellPadding="1" CellSpacing="1" AutoGenerateColumns="False" forecolor="Black">
                    <AlternatingItemStyle BackColor="White"></AlternatingItemStyle>
                    <HeaderStyle ForeColor="White" BackColor="Navy"></HeaderStyle>
                    <Columns>
                    <asp:ButtonColumn Text="Select" HeaderText="Select" CommandName="Select"></asp:ButtonColumn>                         
                    <asp:BoundColumn DataField="DataDate" HeaderText="Date"></asp:BoundColumn>
                    <asp:BoundColumn DataField="DataPoint" HeaderText="Data Point"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Consumption" HeaderText="Consumption"></asp:BoundColumn> 
                    <asp:BoundColumn DataField="Remarks" HeaderText="Remarks"></asp:BoundColumn>
                                                      <asp:BoundColumn DataField="MeterReading" HeaderText="Reading"></asp:BoundColumn> 
                    </Columns>
                    </asp:datagrid>
			</asp:panel>
    
  
    </form>
       <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;position:fixed;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
  	<script type="text/javascript">
     $(document).ready(function () {
                       
                        $('#txtdate').datepicker({
                            dateFormat: "dd/mm/yy", 
                       
                            onSelect: function(date){            
                                var date1 = $('txtdate').datepicker('getDate');           
                                                 
                              
                            }
                        });
    
  function getDate( element ) {
    var date;
    var dateFormat = "dd/MM/yyyy";
    try {
      date = $.datepicker.parseDate( dateFormat, element.value );
    } catch( error ) {
      date = null;
    }

    return date;
  }
          });
            $(document).ready(function () {
                       
                        $('#txtPreDate').datepicker({
                            dateFormat: "dd/mm/yy", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtPreDate').datepicker('getDate');           
                                                 
                              
                            }
                        });
    
  function getDate( element ) {
    var date;
    var dateFormat = "dd/MM/yyyy";
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