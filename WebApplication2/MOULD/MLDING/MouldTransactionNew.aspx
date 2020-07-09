<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MouldTransactionNew.aspx.vb" Inherits="WebApplication2.MouldTransactionNew" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>MouldTransactionNew</title>
		 <meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR"/>
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
            <meta charset="utf-8"/>
  <link rel="stylesheet" type="text/css" href="css/jquery-ui.css" />
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
        <style>
            .rbl input[type="radio"] {
    margin-left: 10px;
    margin-right: 5px;
}
        </style>
      <%--   <link rel="stylesheet" href="../../StyleSheet1.css" />--%>
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
          <li class="nav-item" style="font-weight: bold">
             <h1 style="color:white; font-size:30px; margin-left:430px; margin-top:5px">Rail Wheel Plant, Bela</h1> 
       
         </li>
          <%--<li class="nav-item"> <a class="nav-link" href="#" style="color:white; font-size:25px;">Rail Wheel Plant Bela</a></li>--%>
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
          <%--<img src="../../NewFolder1/CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="45"/>--%>
            <img src="../../NewFolder1/CRIS-Recruitment.jpg" height="45" style="border-radius:43%"/>
        </a>
      </li>
     </ul>
      
  </div>
</nav>
       
<!--/.Navbar -->
           
                        <form id="Form1" method="post" runat="server">
         <%--   <div class="row">
    
                  <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>--%>
                            
	
			        <asp:panel id="Panel1" runat="server">
             <div class="container">
         
                 <div class="table">
                            
								<div class="row">
									<div class="col" align="center"><h3>Mould Transaction (MPO)</h3></div>
								</div>
							 </div><br />
							<div class="row">
							<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                            </div><br />

							<div class="row" >
									<div class="col">Date</div>
									<div class="col">
										<asp:textbox id="txtDate" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox></div>
									<div class="col">Shift</div>
									<div class="col">
										<asp:radiobuttonlist id="rblShift" runat="server" CssClass="rbl" AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal">
											<asp:ListItem Value="A">A</asp:ListItem>
											<asp:ListItem Value="B">B</asp:ListItem>
											<asp:ListItem Value="C">C</asp:ListItem>
                                            <asp:ListItem Value="G">G</asp:ListItem>
										</asp:radiobuttonlist></div>
								
									<div class="col">SSE/JE</div>
									<div class="col">
										<asp:textbox id="txtLineJE" runat="server" CssClass="form-control"  AutoPostBack="True"></asp:textbox></div>
									<div class="col">ShiftIC</div>
									<div class="col">
										<asp:textbox id="txtShiftIC" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox></div>
								</div>

                 
               <br />
							<div class="row">
                                <div class="col">
							<asp:RadioButtonList id="rblType" runat="server" CssClass="rbl"  AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal"></asp:RadioButtonList>
							</div></div>
                           <div class="row">
                                <div class="col">
                                
                                       Wheel Type:&nbsp;</div>
                                    <div class="col">
							<asp:RadioButtonList id="rblwheel" runat="server" CssClass="rbl"  AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal">
                                <asp:ListItem Value="110123">BGC</asp:ListItem>
                                <asp:ListItem Value="120120">BOXN</asp:ListItem>
							</asp:RadioButtonList>
							</div>
                              
                 
                                                  
								                	<div class="col">MouldNumber</div>
											     	<div class="col">
														<asp:DropDownList id="ddlmn" runat="server" AutoPostBack="True" CssClass=" form-control ll"></asp:DropDownList> 
                                                        <br />
                                                    </div>
                      
                      <div class="col"></div>
												</div>
                                  <div class="row">
									<div class="auto-style2">
										&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										  <br />
                                    </div>
							    </div>

                <asp:Panel id="Panel2added" runat="server">
               <div class="container-fluid">
								<div class="row">
									<div class="col">
                                        <br />
                                        MPONo  </div>
										<div class="auto-style1">
                                            <asp:radiobuttonlist id="rdoMpoList" RepeatDirection="Horizontal" runat="server" CssClass="rbl" AutoPostBack="True" RepeatLayout="Flow" style="margin-left:0px"></asp:radiobuttonlist>

										</div>
								</div>
							</div>
                    </asp:Panel>

									<asp:Panel id="pnlAdded" runat="server">
											  <div class="container-fluid">
								                <div class="row">
                                                  
								                	<div class="col">MouldNumber</div>
											     	<div class="col">
														<asp:DropDownList id="ddlMouldNo" runat="server" AutoPostBack="True" CssClass=" form-control ll"></asp:DropDownList> 
                                                        <br />
                                                    </div>
												</div>
											</div>
									</asp:Panel>

										<asp:Panel id="pnlNotAdded" runat="server">
										  <div class="container-fluid"><br />
								                <div class="row">
                                                      <asp:dropdownlist id="ddlDefect" runat="server" AutoPostBack="True" CssClass="form-control ll" style="margin-left: 12px; " Width="400px"></asp:dropdownlist>
                                      </div><br />
                                              <div class="row">
								                	<div class="col">MouldNumber</div>
													<div class="col">
														<asp:textbox id="txtMouldNo" runat="server" CssClass="form-control" AutoPostBack="True" BorderStyle="Groove"></asp:textbox> 
                                                        <br />
                                                    </div>
												</div>
											</div>
										</asp:Panel>

                                    <div class="container-fluid">
								                <div class="row">
								                	<div class="col">
										<asp:Label id="lblLife" runat="server"></asp:Label></div>
								</div>
                                <div class="row">
								     <div class="col">Add After MOULD No</div>
                                   <div class="col">
                                        <asp:TextBox ID="addaftermouldno" runat="server" CssClass="form-control"></asp:TextBox>
                                        <br />
                                     </div>
                                </div>
                                        <%-- <tr>
                                    <td>Total no of MOULDS </td>
                                    <td>
                                        <asp:TextBox ID="totalmoulds" runat="server" CssClass="form-control"></asp:TextBox></td>
                                </tr>--%>
                               <div class="row">
								     <div class="col">Total No of Mould Online  </div>
                                      <div class="col">Cope:<br /><asp:TextBox ID="totalmouldsonlinecope" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox><br />
                                            Drag:<br /><asp:TextBox ID="totalmouldsonlinedrag" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                        </div>
                                  
                                </div>
                                 <div class="row">
								     <div class="col">Total No of Mould in MPO </div>
                                     <div class="col">Cope:<br /><asp:TextBox ID="totalmouldsmpocope" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox><br />
                                            Drag:<br /><asp:TextBox ID="totalmouldsmpodrag" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                        </div>
                                  
                                </div>
							</div>

                         <div class="container-fluid">
								<div class="row" style="margin-top:10px;">
									<div class="col">Date &amp; Time &nbsp;(dd/mm/yyyy&nbsp; HH:MM&nbsp;):</div>
									<div class="col"><asp:TextBox id="txtReWorkDate" runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="2" Width="100px"></asp:TextBox></div>Hrs
									<div class="col"><asp:TextBox id="txtReWorkHr" runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="2" Width="100px"></asp:TextBox></div>Min
									<div class="col"><asp:TextBox id="txtReWorkMin" runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="2" Width="100px"></asp:TextBox></div>
                                        </div>
                             <br />
                             <div class="row">
                                 <div class="col" align="center"><asp:Button id="btnSave" Text="Save" runat="server" BorderStyle="Solid" Font-Bold="True" Font-Size="20px" CssClass="btn btn-dark"></asp:Button>
				
									</div>
                                </div>   
                             <br />
						
							</div>
						
							<asp:DataGrid id="DataGrid4" runat="server" CssClass="table" ForeColor="Black" BorderStyle="Solid" BorderColor="#999999" BorderWidth="1px" BackColor="White" CellPadding="3" GridLines="Vertical">
								<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#000099"></SelectedItemStyle>
								<AlternatingItemStyle BackColor="#CCCCCC"></AlternatingItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Black"></HeaderStyle>
								<FooterStyle BackColor="#CCCCCC"></FooterStyle>
								<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999"></PagerStyle>
							</asp:DataGrid>
						
							<asp:DataGrid id="DataGrid2" runat="server" CssClass="table" BorderStyle="None" BorderColor="#3366CC" BorderWidth="1px" BackColor="White" CellPadding="4">
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid>
							<asp:DataGrid id="DataGrid3" runat="server" CssClass="table" ForeColor="Black" BorderStyle="Solid" BorderColor="#999999" BorderWidth="1px" BackColor="White" CellPadding="3" GridLines="Vertical">
								<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#000099"></SelectedItemStyle>
								<AlternatingItemStyle BackColor="#CCCCCC"></AlternatingItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Black"></HeaderStyle>
								<FooterStyle BackColor="#CCCCCC"></FooterStyle>
								<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999"></PagerStyle>
							</asp:DataGrid>
					
				
				<asp:DataGrid id="DataGrid1" runat="server" CssClass="table" BorderStyle="None" BorderColor="#CC9966" BorderWidth="1px" BackColor="White" CellPadding="4">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<Columns>
						<asp:ButtonColumn Text="Delete" CommandName="Delete"></asp:ButtonColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
			</asp:panel>
                     </div></div></form>
                     
         <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;position:relative;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
	<script type="text/javascript">
     $(document).ready(function () {
                       
                        $('#txtReWorkDate').datepicker({
                            dateFormat: "dd/mm/yy", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtReWorkDate').datepicker('getDate');           
                                                 
                              
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
         
</script>

	</body>
</html>
