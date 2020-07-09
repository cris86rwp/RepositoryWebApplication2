<%@ Page Language="vb" AutoEventWireup="false" Codebehind="BreakDownMemoMWEdit.aspx.vb" Inherits="WebApplication2.BreakDownMemoMWEdit" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>BreakDownMemoEdit</title>
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
</nav>  <br />
		
<!--/.Navbar -->

         

		<form id="Form1" method="post" runat="server">
          <%--   <div class="row">
    
                  <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />
      </div>--%>
       
             
			<asp:panel id="Panel2" runat="server">
		         <div class="container">
                        <div class="table">
					<div class="row">
						<div class="col" align="center">Break Down Memo </div>
					</div>
				<br />
                        <asp:panel id="Panel1" runat="server" >
                      
								<div class="row" >
									<div class="col" align="center"><FONT size="5"><strong>BreakDownMemo (Maintenance)-Edit&nbsp;</strong></FONT></div>
								</div>
                            <br />
								<div class="row">
                                    
									<div class="col">
										<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label>
										<asp:label id="lblGroup" runat="server"></asp:label>
										<asp:label id="lblUserID" runat="server"></asp:label></div>
								</div>
						
						<br />
								
						<div class="row">
							<div class="col"><asp:RadioButtonList id="rblBDShop" runat="server" AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl"></asp:RadioButtonList>
						</div>
                                </div>
								<div class="row">
									<div class="col">
										<asp:RadioButtonList id="rblBDType" runat="server" CssClass="rbl" AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal"></asp:RadioButtonList></div>
								</div>
						<div class="row">
							<div class="col"><asp:RadioButtonList id="rblMemo" runat="server" CssClass="rbl" AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal"></asp:RadioButtonList>
						</div>
                                </div>
                            <br />
                            <div class="row">
									<div class="col">Break Down Date</div>
									
									<div class="col">
										<asp:textbox id="txtDate" runat="server" CssClass="form-control" Width="103px"></asp:textbox></div>
								
									<div class="col">Maintenance Remarks</div>
									
									<div class="col">
										<asp:textbox id="txtWorkDone" runat="server" CssClass="form-control" TextMode="MultiLine" ></asp:textbox></div>
							
									<div class="col">Staff Attended</div>
								
									<div class="col">
										<asp:textbox id="txtStaff" runat="server" CssClass="form-control" Width="103px"></asp:textbox>&nbsp;&nbsp;
										<asp:radiobuttonlist id="rblTypeOfFailure" runat="server" CssClass="rbl" RepeatDirection="Horizontal">
											<asp:ListItem Value="M" Selected="True">Maintenance&nbsp;</asp:ListItem>
											<asp:ListItem Value="O">Operational&nbsp;</asp:ListItem>
										</asp:radiobuttonlist>&nbsp;
									</div>
								</div>
                            <br />
								<div  class="row">
									<div class="col">Do you want to add Spares ?</div>
										<div class="col"><asp:RadioButtonList id="rblSpares" runat="server" CssClass="rbl" AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal">
											<asp:ListItem Value="No" Selected="True">No&nbsp;</asp:ListItem>
											<asp:ListItem Value="Yes">Yes&nbsp;</asp:ListItem>
										</asp:RadioButtonList></div>
                                    <div class="col"></div>
                                    <div class="col"></div>
                                    <div class="col"></div>
                                    <div class="col"></div>
                                    </div>
								</div>
						</div>
                
						</asp:panel>
					<div class="col" align="left">
                        <asp:datagrid id="DataGrid1" runat="server" CssClass="table" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966">
							<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
							<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
							<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
							<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
						</asp:datagrid><asp:label id="lblMachineCode" runat="server" Visible="False"></asp:label><asp:label id="lblSubAssembly" runat="server" Visible="False"></asp:label>
						<asp:label id="lblFailure" runat="server" Visible="False"></asp:label>
						<asp:label id="lblMaintenanceGroup" runat="server" Visible="False"></asp:label></div>
				
				<div class="row">
					<div class="col" align="left" ><asp:panel id="pnlSpares" runat="server">
							
								<div class="row">
									<div class="col" align="left">
																<div class="row">
												<div class="col">
													<P>SparesList</P>
												</div>
											
												<div class="col">
													<asp:dropdownlist id="ddlSparesList" CssClass="form-control ll" runat="server" AutoPostBack="True"></asp:dropdownlist></div>
											</div>
											<div class="row">
												<div class="col">PLNumber</div>
												
												<div class="col">
													<asp:textbox id="txtPLNumber" runat="server" CssClass="form-control" AutoPostBack="True" Height="22px"></asp:textbox></div>
											</div>
											<div class="row">
												<div class="col">Quantity</div>
												
												<div class="col">
													<asp:textbox id="txtPlQty" runat="server" CssClass="form-control"></asp:textbox></div>
											</div>
											<div class="row">
												<div class="col" align="center">
                                                     <asp:button id="btnPls" runat="server" Text="Add PL Number`s"  Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" ></asp:button>

												</div>
											</div>
							
									</div>
									<div class="col" align="left">
										<asp:DataGrid id="grdSpares" runat="server" CssClass="table" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4">
											<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
											<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
											<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
											<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
											<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
										</asp:DataGrid></div>
								</div>
							
						</asp:panel></div>
				</div>
				<div class="row">
                    <div class="col"></div>
                      <div class="col"></div>
					<div class="col" align="center" >
  <asp:button id="btnSave" runat="server" Text="Save"  Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" ></asp:button></div>
                   
                    <div class="col" align="center" >
                          <asp:button id="btnClear" runat="server" Text="Clear"  Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" ></asp:button>

                       </div>
                     <div class="col"></div>
			<div class="col"></div>
                    </div>
              
                    </asp:panel>
                   
                 
		</form>
             
           <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;position:absolute;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
  <script type="text/javascript">
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
