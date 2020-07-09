<%@ Page language="vb" AutoEventWireup="false" Codebehind="LiquidOxygenValues.aspx.vb" Inherits="WebApplication2.LiquidOxygenValues" Culture="en-GB" uiCulture="en-GB" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>LiquidOxygenValues</title>
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
    
        
		<form id="Form1" method="post" runat="server">
            <div class="container">
            <%-- <div class="row">
    
                  <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />
      </div>--%>
			<asp:panel id="Panel3" runat="server">
			
                            <div class="table">
				<div class="row">
					<div class="col" vAlign="top" align="left"></div></div>
                        <asp:panel id="Panel1" runat="server">
							<div class="container">
								<div class="row">
									<div class="col" colSpan="3"> <FONT size="8"> Daily Oxygen Consumption </FONT> <hr class="prettyline" /></div>
								</div>
								<div class="row">
									<div class="col" colSpan="3">
										<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></div>
								</div>
								<%--<div class="row">
									<div class="col" colSpan="3">Date and Time in 24 hours format</div>
								</div>--%>
								<div class="row">
                                    <div class="col"></div>
                                    <div class="col"></div>
									<div class="col">Date</div>
									
									<div class="col">
										<asp:TextBox id="txtDate" runat="server" Width="103px" AutoPostBack="True" CssClass="form-control"></asp:TextBox>
										<asp:CheckBox id="CheckBox1" runat="server" AutoPostBack="True" Text="ReSet " CssClass="checkbox"></asp:CheckBox>&nbsp;</div>
								<div class="col"></div>
                                    <div class="col"></div>
								</div><br />
								<div class="row">
									<div class="col" colSpan="3">
										<asp:RadioButtonList id="rblHour" runat="server" Width="443px" AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl">
										 <asp:ListItem Value="FurA" Selected="True">FurA</asp:ListItem>
											<asp:ListItem Value="FurB">FurB</asp:ListItem>
											<asp:ListItem Value="FurC">FurC</asp:ListItem>
											<asp:ListItem Value="HC_MRS">HC_MRS</asp:ListItem>
										
                                        </asp:RadioButtonList></div>
								</div>
								<div class="row">
									<div class="col" colSpan="3">
										<asp:RadioButtonList id="rblArea" runat="server" AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl">
											<asp:ListItem Value="TPCL1" Selected="True">TPCL1</asp:ListItem>
											<asp:ListItem Value="TPCL2">TPCL2</asp:ListItem>
											<asp:ListItem Value="TBDC1">TBDC1</asp:ListItem>
											<asp:ListItem Value="TBDC2">TBDC2</asp:ListItem>
											
                                           	
										</asp:RadioButtonList></div>
								</div>
                               <div class="row">
									<div class="col" colSpan="3">
										<asp:RadioButtonList id="rblQuant" runat="server" AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl">
											<asp:ListItem Value="No. of tanks " Selected="True">Receipt-No.of Tanks</asp:ListItem>
											<asp:ListItem Value=" Tanks QtyKgs">Receipt-QtyKgs</asp:ListItem>
											
										</asp:RadioButtonList></div>
								</div><br />
								<div class="row">
									<div class="col">Meter Reading</div>
						
									<div class="col">
										<asp:TextBox id="txtValue" runat="server" Width="86px" AutoPostBack="True" CssClass="form-control"></asp:TextBox>&nbsp;
									</div>
						<div class="col"></div>
                                    <div class="col"></div>
                                    <div class="col"></div>
                                    <div class="col"></div>
								</div>
							<br />
					
										<asp:Panel id="Panel2" runat="server">
								<div class="row">
									<div class="col" colSpan="4">&nbsp;Present Meter 
            MaxValue  </div>
                                    <div class="col">
<asp:TextBox id="txtMax" runat="server" CSSClass="form-control"></asp:TextBox></div><div class="col">&nbsp;Next 
            Meter Initial Reading : </div><div class="col">
<asp:TextBox id="txtInitial" runat="server" CSSClass="form-control"></asp:TextBox></div>
                                    <div class="col"></div>
<div class="col"></div>								</div>

                                    </asp:Panel>
								<br />
			
							<div class="row">
									<div class="col">Challan Number</div>
									
									<div class="col">
										<asp:TextBox id="txtCallanNumber" runat="server" AutoPostBack="True" CssClass="form-control" Width="103px"></asp:TextBox></div>
								
									<div class="col">Challan Date</div>
									
									<div class="col">
										<asp:TextBox id="txtCallanDate" runat="server" AutoPostBack="True" CssClass="form-control" Width="103px"></asp:TextBox></div>
								
									<div class="col">Remarks</div>
									
									<div class="col">
										<asp:TextBox id="txtRemarks" runat="server" AutoPostBack="True" CssClass="form-control" Width="103px"></asp:TextBox></div>
								</div>
                                <br />
								<div class="row">
									<div class="col" vAlign="top" align="center" >
                                       <asp:button id="btnSave" runat="server" Text="Save"  Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" ></asp:button>
				
									</div>

								</div>
							
						</asp:panel>
				
                         <asp:datagrid id="dgMeterRdg" CssClass="table" runat="server" CellPadding="1" CellSpacing="1" AutoGenerateColumns="False" forecolor="Black">
                   		 <AlternatingItemStyle BackColor="White"></AlternatingItemStyle>
                    <HeaderStyle ForeColor="White" BackColor="Navy"></HeaderStyle>
                    <Columns>
                    <asp:ButtonColumn Text="Select" HeaderText="Select" CommandName="Select"></asp:ButtonColumn>
                          
                    <asp:BoundColumn DataField="OxyDate" HeaderText="Date"></asp:BoundColumn>
                   <asp:BoundColumn DataField="Item" HeaderText="Item"></asp:BoundColumn>
                          <asp:BoundColumn DataField="Item1" HeaderText="Item1"></asp:BoundColumn>
                          <asp:BoundColumn DataField="Item2" HeaderText="Item2"></asp:BoundColumn>
                         <asp:BoundColumn DataField="ItemValue" HeaderText="Value"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Remarks" HeaderText="Remarks"></asp:BoundColumn>
                  
                        <asp:BoundColumn DataField="ChallanNumber" HeaderText="Challan Number"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ChallanDate" HeaderText="Challan Date"></asp:BoundColumn>
                   
                    </Columns>
						</asp:datagrid>

                        <asp:DataGrid id="dgSavedData" runat="server" BorderWidth="1px">
								<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
								<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
								<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
								<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
							</asp:DataGrid>
						</asp:panel>
					</div>
		
             
             <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
            </asp:Panel> 
                      
		</form>
        <script type="text/javascript">
     $(document).ready(function () {
                       
                        $('#txtDate').datepicker({
                            dateFormat: "dd/mm/yy", 
                       
                            onSelect: function(date){            
                                var date1 = $('txtDate').datepicker('getDate');           
                                                 
                              
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
                       
                        $('#txtCallanDate').datepicker({
                            dateFormat: "dd/mm/yy", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtCallanDate').datepicker('getDate');           
                                                 
                              
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