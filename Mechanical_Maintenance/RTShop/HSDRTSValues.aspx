<%@ Page Language="vb" AutoEventWireup="false" Codebehind="HSDRTSValues.aspx.vb" Inherits="WebApplication2.HSDRTSValues" Culture="en-GB" uiCulture="en-GB" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>HSD Values for RTSHOP</title>
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
         </nav> 
    
		<form id="Form1" method="post" runat="server">
            <asp:panel id="Panel3" runat="server">
             <div class="row">
    <div class="container">
              
                <div class="table">
			
				<div class="row">
					<div class="col">
                        </div></div>
              
					      <div class="row"">
								<div class="col"><FONT size="5">HSD Values for RTSHOP </FONT><hr class="auto-style55" /></div>
                       
							</div>
                    <br />
                      </asp:panel>
						
                    <asp:Panel id="Panel5" runat="server">
					            
              
                	<div class="row">
								<div class="col" align="center">Date </div>
                        <div class="col"> <asp:TextBox id="txtDate" runat="server" AutoPostBack="True" Width="103px" CssClass="form-control" ></asp:TextBox></div>
                                </div>
                                <div class="row">
								<div class="col" align="center"><asp:CheckBox id="CheckBox1" runat="server" AutoPostBack="True" Text="ReSet" CssClass="checkbox" Width="300px"></asp:CheckBox></div>
                                </div><br />
                   </asp:panel>
						
                    <asp:Panel id="Panel7" runat="server">
					   

							<div class="row">
                               
								<%--<div class="col">
									<asp:RadioButtonList id="RadioButtonList1" runat="server" CSSClass="rbl" RepeatDirection="horizontal" RepeatLayout="Flow" AutoPostBack="True">
											<asp:ListItem Value="LPG" Selected="True">LPG</asp:ListItem>
								            <asp:ListItem Value="BMCG">BMCG</asp:ListItem>
										   </asp:RadioButtonList>
                                    </div>
                                   </div> --%>
                                </div>
                                   <div class="row">
                               
								<div class="col">
								 <asp:RadioButtonList ID="rblArea" runat="server" AutoPostBack="True" CSSClass="rbl" RepeatDirection="horizontal" RepeatLayout="Flow">
                                        <%--<asp:ListItem Value="LPH" Selected="True">LPH</asp:ListItem>
                                        <asp:ListItem Value="">NF</asp:ListItem>
                                        <asp:ListItem Value="DF">DF</asp:ListItem>
                                        <asp:ListItem Value="SP">SP</asp:ListItem>
                                        <asp:ListItem Value="TANK1">TANK1</asp:ListItem>
                                        <asp:ListItem Value="TANK2">TANK2</asp:ListItem>--%>
                                       <asp:ListItem Value="Receipt-NoofLorrey">Receipt-No. of Lorrey</asp:ListItem>
                                        <asp:ListItem Value="Receipt-QtyinLtrs">Receipt-Qty in Ltrs</asp:ListItem>
                                      <asp:ListItem Value="FM01">FM01</asp:ListItem>
                                    </asp:RadioButtonList>
                                   </div>
                                       </div>
                        <br />
                             <%--  <div class="row">
                                   <div class="col">
                                       <asp:RadioButtonList id="RadioButtonList2" runat="server" AutoPostBack="True" CSSClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow">
									 <asp:ListItem Value="HC1" Selected="True">HC1</asp:ListItem>
									 	<asp:ListItem Value="HC2">HC2</asp:ListItem>
										<asp:ListItem Value="HC3">HC3</asp:ListItem>
										<asp:ListItem Value="MRS">MRS</asp:ListItem>
                                        <asp:ListItem Value="NF">NF</asp:ListItem>
										<asp:ListItem Value="DF">DF</asp:ListItem>
										<asp:ListItem Value="SP">SP</asp:ListItem>
										<asp:ListItem Value="TANK1">TANK1</asp:ListItem>
                                        <asp:ListItem Value="TANK2">TANK2</asp:ListItem>
									    <asp:ListItem Value="Receipt-No.ofWag">Receipt-No.OfLorray</asp:ListItem>
										<asp:ListItem Value="Receipt-QtyinKgs">Receipt-QtyLts</asp:ListItem>
                                        <asp:ListItem Value="No_of_Cylnd">No_of_Cylnd</asp:ListItem>
									</asp:RadioButtonList>
                              
                                </div>
                                   </div>--%>
                    

                         <div class="row">
								<div class="col" >
									<asp:Label id="Label1" runat="server" ForeColor="Red"></asp:Label></div>
							</div>
							<br />		
							<div class="row">
						
							<div class="col">
                                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>    </div>
                               </div>
        </asp:panel>

                <asp:Panel id="Panel4" runat="server">
					         
							<div class="row">
								<div class="col"> Value </div>
								
								<div class="col">
									<asp:TextBox id="txtValue" runat="server" AutoPostBack="True" Width="103px" CssClass="form-control"></asp:TextBox></div>
                                <div class="col"></div>
                                <div class="col"></div>
                                <div class="col"></div>
                                <div class="col"></div>
							</div>
                    <br />
                    	<asp:Panel id="Panel2" runat="server">
							<div class="row">
								<div class="col">
								&nbsp;Present Meter MaxValue </div><div class="col">
                                       <asp:TextBox id="txtMax" runat="server" Width="62px" Height="22px"></asp:TextBox>&nbsp;</div>
                                <div class="col">
                                    Next 
                                           Meter Initial Reading </div><div class="col">
                                           <asp:TextBox id="txtInitial" runat="server" Width="63px"></asp:TextBox></div></div>
						     	</asp:Panel>
                    <br />
                	     <div class="row">
                             	
			
								<div class="col">Challan Number </div>
							    <div class="col" >
									<asp:TextBox id="txtChallanNumber" runat="server" AutoPostBack="True" Width="103px" CssClass="form-control"></asp:TextBox></div>
							
								<div class="col">Challan Date   </div><div class="col"><asp:TextBox id="txtChallanDate" runat="server" AutoPostBack="True" Width="103px"  CssClass="form-control"></asp:TextBox>
							</div>
                                    
								<div class="col"> Remarks </div>
								<div class="col">
									<asp:TextBox id="txtRemarks" runat="server" AutoPostBack="True" Width="103px" CssClass="form-control"></asp:TextBox></div>
							
								</div>
                           <br />         </asp:panel>
						
                    <asp:Panel id="Panel6" runat="server">
					             
				
                    <div class="row">
                                		
								<div class="col" align="center">
                                    <asp:button id="btnSave" runat="server" Text="Save"  Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" ></asp:button>
							</div>
					<br />
				<div class="row">
					<div class="col"><asp:datagrid id="dgMeterRdg" runat="server" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966">
							<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
							<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
							<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
							<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
						</asp:datagrid></div>
				</div>
				<div classs="row">
					<div class="col">
						<asp:Panel id="Panel1" runat="server">
							<asp:DataGrid id="dgSavedData" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid>
						</asp:Panel></div>
				</div>
                        <asp:datagrid id="DataGrid1" CssClass="table" runat="server" CellPadding="1" CellSpacing="1" AutoGenerateColumns="False" forecolor="Black">
                    <AlternatingItemStyle BackColor="White"></AlternatingItemStyle>
                    <HeaderStyle ForeColor="White" BackColor="Navy"></HeaderStyle>
                    <Columns>
                    <asp:ButtonColumn Text="Select" HeaderText="Select" CommandName="Select"></asp:ButtonColumn>
                          
                    <asp:BoundColumn DataField="ItemDate" HeaderText="Date"></asp:BoundColumn>
                   <asp:BoundColumn DataField="ItemValue" HeaderText="Value"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Remarks" HeaderText="Remarks"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Item" HeaderText="Item"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ChallanNumber" HeaderText="Challan Number"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ChallanDate" HeaderText="Challan Date"></asp:BoundColumn>
                   
                    </Columns>
                    </asp:datagrid>
			
                </asp:panel>
                    </div>
                 <br />
      </div>
            <div class="row">
                </div>
		</form>
            </div>
          <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;position:fixed;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
          
 <script type="text/javascript">
     $(document).ready(function () {
                       
                        $('#txtDate').datepicker({
                            dateFormat: "dd/mm/yy", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtDate').datepicker('getDate');           
                                                 
                              
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
                       
                        $('#txtChallanDate').datepicker({
                            dateFormat: "dd/mm/yy", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtChallanDate').datepicker('getDate');           
                                                 
                              
                            }
                        });
    
  function getDate( element ) {
    var date;
    var dateFormat = "dd/MM/yyyyy";
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
