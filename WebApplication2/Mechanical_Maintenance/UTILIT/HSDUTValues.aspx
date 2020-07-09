<%@ Page Language="vb" AutoEventWireup="false" Codebehind="HSDUTValues.aspx.vb" Inherits="WebApplication2.HSDUTValues" Culture="en-GB" uiCulture="en-GB" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>LPG and BMCG Values</title>
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
        <div class="container">
		
             <%--<div class="row">
    
                  <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>--%>
                <div class="table">
		
		
				<div  class="row">
					<div  class="col" >
                        </div >
              </div>
					      <div  class="row">
								<div  class="col" ><FONT size="5">LPG and Cutting Gas Values</FONT><hr class="auto-style55" /></div >
                       
							</div >
                      </asp:panel>
						
                    <asp:Panel id="Panel5" runat="server">
					
              
                	<div  class="row">
								<div  class="col" align="center" >Date </div >
                        <div  class="col"> <asp:TextBox id="txtDate" runat="server" AutoPostBack="True" Width="103px" CssClass="form-control" ></asp:TextBox></div >
                                </div >
                                <div  class="row">
								<div  class="col" align="center"><asp:CheckBox id="CheckBox1" runat="server" AutoPostBack="True" Text="ReSet" CssClass="checkbox" Width="300px"></asp:CheckBox></div >
                                </div ><br />
                    </asp:panel>
						
                    <asp:Panel id="Panel7" runat="server">
					              

							<div  class="row">
                               
								<div  class="col" >
									<asp:RadioButtonList id="RadioButtonList1" runat="server" CSSClass="rbl" RepeatDirection="horizontal" RepeatLayout="Flow" AutoPostBack="True">
											<asp:ListItem Value="LPG" Selected="True">LPG</asp:ListItem>
								            <asp:ListItem Value="BMCG">BMCG</asp:ListItem>
										   </asp:RadioButtonList>
                                    </div >
                                   </div > 

                                   <div  class="row">
                               
								<div  class="col"  >
								 <asp:RadioButtonList ID="rblArea" runat="server" AutoPostBack="True" CSSClass="rbl" RepeatDirection="horizontal" RepeatLayout="Flow">
                                        <asp:ListItem Value="LPH" Selected="True">LPH</asp:ListItem>
                                        <asp:ListItem Value="NF">NF</asp:ListItem>
                                        <asp:ListItem Value="DF">DF</asp:ListItem>
                                        <asp:ListItem Value="SP">SP</asp:ListItem>
                                        <asp:ListItem Value="TANK1">TANK1</asp:ListItem>
                                        <asp:ListItem Value="TANK2">TANK2</asp:ListItem>
                                        <asp:ListItem Value="Receipt-No.ofWag">Receipt-No.ofWag</asp:ListItem>
                                        <asp:ListItem Value="Receipt-QtyinKgs">Receipt-QtyinKgs</asp:ListItem>
                                    </asp:RadioButtonList>
                                   </div >
                                       </div >
                                <div  class="row">
                                   <div  class="col"  >
                                       <asp:RadioButtonList id="RadioButtonList2" runat="server" AutoPostBack="True" CSSClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow">
									 <asp:ListItem Value="HC1" Selected="True">HC1</asp:ListItem>
									 	<asp:ListItem Value="HC2">HC2</asp:ListItem>
										<asp:ListItem Value="HC3">HC3</asp:ListItem>
										<asp:ListItem Value="MRS">MRS</asp:ListItem>
                                        <%--<asp:ListItem Value="NF">NF</asp:ListItem>
										<asp:ListItem Value="DF">DF</asp:ListItem>
										<asp:ListItem Value="SP">SP</asp:ListItem>--%>
										<%--<asp:ListItem Value="TANK1">TANK1</asp:ListItem>
                                        <asp:ListItem Value="TANK2">TANK2</asp:ListItem>--%>
									  <%--  <asp:ListItem Value="Receipt-No.ofWag">Receipt-No.ofWag</asp:ListItem>--%>
										<asp:ListItem Value="Receipt-QtyinKgs">Receipt-QtyinKgs</asp:ListItem>
                                        <asp:ListItem Value="No_of_Cylnd">No_of_Cylnd</asp:ListItem>
									</asp:RadioButtonList>
                              
                                </div >
                                   </div > 
                    <br />

                         <div  class="row">
								<div  class="col"  >
									<asp:Label id="Label1" runat="server" ForeColor="Red"></asp:Label></div >
							</div >
							<br />		
							<div  class="row">
						
							<div  class="col">
                                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>    </div >
                               </div >
            </asp:panel>

                <asp:Panel id="Panel4" runat="server">
					              
							<div  class="row">
								<div  class="col" >Value </div >
								
								<div  class="col" >
									<asp:TextBox id="txtValue" runat="server" AutoPostBack="True" Width="103px" CssClass="form-control"></asp:TextBox></div >
                                <div class="col"></div>
                                <div class="col"></div>
                                <div class="col"></div>
                                <div class="col"></div>
							</div ><br />
							<%--<div  class="row">
								<div  class="col" colSpan="2">
									<asp:Panel id="Panel2" runat="server">&nbsp;Present Meter MaxValue : 
                                       <asp:TextBox id="txtMax" runat="server" Width="62px"></asp:TextBox>&nbsp;Next 
                                           Meter Initial Reading : 
                                           <asp:TextBox id="txtInitial" runat="server" Width="63px"></asp:TextBox></asp:Panel></div >
						     	</div >--%>
                	     <div  class="row">
                             	
			
								<div  class="col" >Challan Number </div >
							    <div  class="col" >
									<asp:TextBox id="txtChallanNumber" runat="server" AutoPostBack="True" Width="103px" CssClass="form-control"></asp:TextBox></div >
							
								<div  class="col" >Challan Date   </div >
                             <div  class="col"><asp:TextBox id="txtChallanDate" runat="server" AutoPostBack="True" Width="103px"  CssClass="form-control"></asp:TextBox>
							</div >
                                  
								<div  class="col" >Remarks </div >
								<div  class="col" >
									<asp:TextBox id="txtRemarks" runat="server" AutoPostBack="True" Width="103px" CssClass="form-control"></asp:TextBox></div >
							
								</div ><br />
                                  </asp:panel>
						
                    <asp:Panel id="Panel6" runat="server">
					          
				
                    <div  class="row">
                                		
								<div  class="col"  align="center">
                          <asp:button id="btnSave" runat="server" Text="Save"  Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" ></asp:button></div >
							</div >
					
				
                        <div class="row">
                         <asp:datagrid id="dgSavedData" CssClass="table" runat="server" CellPadding="1" CellSpacing="1" AutoGenerateColumns="False" forecolor="Black">
                    <AlternatingItemStyle BackColor="White"></AlternatingItemStyle>
                    <HeaderStyle ForeColor="White" BackColor="Navy"></HeaderStyle>
                    <Columns>
                    <asp:ButtonColumn Text="Select" HeaderText="Select" CommandName="Select"></asp:ButtonColumn>
                    <asp:BoundColumn DataField="ItemDate" HeaderText="Date"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Item" HeaderText="Item "></asp:BoundColumn>
                    <asp:BoundColumn DataField="ItemValue" HeaderText="Value"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Remarks" HeaderText="remark"></asp:BoundColumn>
                      <asp:BoundColumn DataField="ChallanNumber" HeaderText="Challan number"></asp:BoundColumn>
                      <asp:BoundColumn DataField="ChallanDate" HeaderText="Challan Date"></asp:BoundColumn>
                    </Columns>
                    </asp:datagrid>
                    </div>
                            </div>
			
                </asp:panel>
      </div>
           
      
		</form>
            
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
</HTML>

