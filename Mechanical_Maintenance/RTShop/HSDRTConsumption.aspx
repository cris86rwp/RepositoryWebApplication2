<%@ Page Language="vb" AutoEventWireup="false" Codebehind="HSDRTConsumption.aspx.vb" Inherits="WebApplication2.HSDRTConsumption" %>
<!DOCTYPE html PUBLIC "-//W3C//Dtd html 4.0 transitional//EN">
<html>
	<head runat="server">
		<title>HSD RTSHOP Consumption</title>
		<LINK id="mss" href="/wap.css" rel="stylesheet"/>
		<META content="Microsoft Visual Studio.NET 7.0" name="GENERATOR"/>
		<META content="Visual Basic 7.0" name="CODE_LANGUAGE"/>
		<META content="JavaScript" name="vs_defaultClientScript"/>
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
        
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css"/>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js" type="text/javascript"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js" type="text/javascript"></script>
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
</nav> 
                                 
			<form id="Form2" method="post" runat="server">
            
<asp:panel id="Panel1" runat="server">
				<div class="table">
                    <div class="container">
					<div  class="row">
                        
							<asp:Label id="lblShop" runat="server"></asp:Label>
						<div  class="col" align="center" ><strong>RTSHOP HSD FLOW METER </strong><FONT size="20">&nbsp;</FONT></div >
					</div >
 <%--                   <TR>
                               
								<TD class="auto-style2">
									<asp:RadioButtonList id="rblArea" runat="server" CSSClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow" AutoPostBack="True">
											<asp:ListItem Value="LPG" Selected="True">LPG</asp:ListItem>
								            <asp:ListItem Value="BMCG">BMCG</asp:ListItem>
										   </asp:RadioButtonList>
                                    </TD>
                   <%--                </TR> --%>
                   <%-- <TR>
                               
								<TD class="auto-style2">
									<asp:RadioButtonList id="RadioButtonList1" runat="server" CSSClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow" AutoPostBack="True">
											<asp:ListItem Value="FM01" Selected="True">FM01</asp:ListItem>
								            <asp:ListItem Value="DF">DF</asp:ListItem>
                                             <asp:ListItem Value="SP">SP</asp:ListItem>
                                         <asp:ListItem Value="LPH">LPH</asp:ListItem>
										 <asp:ListItem Value="TPH">TPH</asp:ListItem>   
                                        </asp:RadioButtonList>
                                    </TD>
                                   </TR> --%>
                                <%--<TR>
                               
								<TD class="auto-style2">
									<asp:RadioButtonList id="RadioButtonList2" runat="server" CSSClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow" AutoPostBack="True">
											<asp:ListItem Value="HC1" Selected="True">HC1</asp:ListItem>
								            <asp:ListItem Value="HC2">HC2</asp:ListItem>
                                         <asp:ListItem Value="HC3">HC3</asp:ListItem>
                                         <asp:ListItem Value="MRS">MRS</asp:ListItem>
										   </asp:RadioButtonList>
                                    </TD>
                                   </TR>--%>
                             

					<%--<div  class="row">
						<div  class="col" align="middle">
							&nbsp;</div >
					</div >--%>
					<div  class="row">
						<div  class="col">
							<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></div >
					</div >
			<br />
					<div  class="row">
						<div  class="col" align="center">
							<asp:RadioButtonList id="rblDataPoints" runat="server" AutoPostBack="true" Repeatdirection="Horizontal" RepeatLayout="Flow" CssClass="rbl">
                               
							</asp:RadioButtonList></div >
					</div >
				<br />
				<asp:Panel id="Panel2" runat="server">
					
						<div  class="row">
							<div  class="col">Previous Date</div >
							
							<div  class="col">
								<asp:TextBox id="txtPreDate" runat="server" AutoPostBack="true" CssClass="form-control"></asp:TextBox></div >
							<div  class="col">Meter Reading</div >
							
							<div  class="col">
								<asp:TextBox id="txtPreMeterReading" runat="server" AutoPostBack="true" CssClass="form-control"></asp:TextBox></div >
							<div  class="col">Consumption</div >
						
							<div  class="col">
								<asp:Label id="lblConsumption" runat="server"></asp:Label></div >
						</div >
						<br/>
                    <div  class="row">
							<div  class="col">Remarks</div >
							
							<div  class="col" >
								<asp:TextBox id="txtremarks" runat="server" CssClass="form-control"></asp:TextBox></div >
                            <div class="col"></div>
                            <div class="col"></div>
                            <div class="col"></div>
                            <div class="col"></div>
						</div >
					<br />
				</asp:Panel>
		
					<div  class="row">
						<div  class="col">Date</div >
						
						<div  class="col">
							<asp:TextBox id="txtdate" runat="server" AutoPostBack="true" CssClass="form-control"></asp:TextBox></div >
						<div  class="col">Meter Reading</div >
						
						<div  class="col">
							<asp:TextBox id="txtMeterReading" runat="server" AutoPostBack="true" CssClass="form-control"></asp:TextBox></div >
                        <div class="col"></div>
                        <div class="col"></div>
					</div >
                        <br />
					<div  class="row">
						<div  class="col" align="center">
                          <asp:button id="btnSave" runat="server" Text="Save"  Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" ></asp:button>
					</div >
                       </div>
                    </div>
    <br />
                <div class="container">
			
				<asp:datagrid id="DataGrid1" CssClass="table" runat="server" CellPadding="1" CellSpacing="1" AutoGenerateColumns="False" forecolor="Black">
                    <AlternatingItemStyle BackColor="White"></AlternatingItemStyle>
                    <HeaderStyle ForeColor="White" BackColor="Navy"></HeaderStyle>
                    <Columns>
                    <asp:ButtonColumn Text="Select" HeaderText="Select" CommandName="Select"></asp:ButtonColumn>                         
                    <asp:BoundColumn DataField="DataDate" HeaderText="Date"></asp:BoundColumn>
                    <asp:BoundColumn DataField="MeterReading" HeaderText="MeterReading"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Consumption" HeaderText="Consumption"></asp:BoundColumn> 
                    <asp:BoundColumn DataField="remarks" HeaderText="Remarks"></asp:BoundColumn>
                                           
                    </Columns>
                    </asp:datagrid>
                    </div>
			</asp:panel>
   
    </form>
            <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;position:fixed;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
          
 <script type="text/javascript">
     $(document).ready(function () {
                       
                        $('#txtPreDate').datepicker({
                            dateFormat: "yy/mm/dd", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtPreDate').datepicker('getDate');           
                                                 
                              
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
                       
                        $('#txtdate').datepicker({
                            dateFormat: "yy/mm/dd", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtdate').datepicker('getDate');           
                                                 
                              
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
</html>