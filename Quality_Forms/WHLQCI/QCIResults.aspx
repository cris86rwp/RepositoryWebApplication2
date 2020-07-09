<%@ Page Language="vb" AutoEventWireup="false" Codebehind="QCIResults.aspx.vb" Inherits="WebApplication2.QCIResults" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>QCIResults</title>
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
 
     <style type="text/css">
         .ui-datepicker {
    background: #333;
    border: 1px solid #555;
    color: #EEE;
    
}
</style>
       <!--<link rel="stylesheet" href="StyleSheet1.css" />-->
	</HEAD>

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
          <i class="fab glyphicon glyphicon-log-out" style="font-size:30px"> </i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
         
        <img src="../../NewFolder1/CRIS-Recruitment.jpg" height="45" style="border-radius:43%"/>
       </a>
      </li>
     </ul>
      
  </div>
</nav>
        <script>
 $(document).ready(function () {
                       
                        $('#txtDate').datepicker({
                            dateFormat: "dd-mm-yy", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtDate').datepicker('getDate');           
                                                 
                              
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
  <br />
       
<!--/.Navbar -->

        <div class="container">
		<form id="Form1" method="post" runat="server">
               <%--<div class="row">
    
                  <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />
      </div>--%>
            <div class="row"><div class="table">
			<asp:Panel id="Panel2"  runat="server">
				<div class="table">
					<div class="row">
						<div class="col" vAlign="top" align="middle"><STRONG><FONT size="5">QCI Inspection Details Entry</FONT></STRONG></div>
					</div>
                    <br />
					<div class="row">
						<div class="col"vAlign="top" align="left">
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></div>
					</div>
                     <br />
				</div>
              <div class="row">
					   <div class="col">Date</div>
					   <div class="col">
								<asp:textbox id="txtDate" runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="10" Width="120px"></asp:textbox></div>
					    <div class="col">Shift</div>
											
												<div class="col">
													<asp:RadioButtonList id="rblShift" runat="server" CssClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow">
														<asp:ListItem Value="A">&nbsp;A&nbsp</asp:ListItem>
														<asp:ListItem Value="B">&nbsp;B&nbsp</asp:ListItem>
														<asp:ListItem Value="C">&nbsp;C&nbsp</asp:ListItem>
														<asp:ListItem Value="G" Selected="True">&nbsp;G</asp:ListItem>
													</asp:RadioButtonList></div>
											</div>
                                             <br />
									    <div class="row">
												
												<div class="col">Lab</div>
												
												<div class="col">
													<asp:textbox id="txtLab" runat="server" CssClass="form-control" Width="120px"></asp:textbox>
													<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtLab"></asp:requiredfieldvalidator></div>
											    <div class="col"></div>
                                                 <div class="col"></div>
                                        </div>
                                             <br />
											<div class="row">
												<div class="col"><STRONG>Authority </STRONG></div>
                                                </div>
                <br />
                                            <div class="row">
												<div class="col">Technical</div>
												
												<div class="col">
													<asp:textbox id="txtTechnical" runat="server" CssClass="form-control" Width="120px" ></asp:textbox>
													<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtTechnical"></asp:requiredfieldvalidator></div>
											
											
												
												<div class="col">Inspector</div>
											
												<div class="col">
													<asp:textbox id="txtInspector" runat="server" CssClass="form-control" Width="120px"> </asp:textbox>
													<asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtInspector"></asp:requiredfieldvalidator></div>
											</div>
                                             <br />
	                            <div class="row">
                                    
									<div class="col">Wheel Number</div>
									
									<div class="col">
										<asp:textbox id="txtWheel" runat="server" CssClass="form-control" AutoPostBack="True" Width="120px"></asp:textbox>
										<asp:requiredfieldvalidator id="rfvWheel_number" runat="server" ErrorMessage="*" ControlToValidate="txtWheel"></asp:requiredfieldvalidator></div>
									<div class="col">Heat Number</div>
									
									<div class="col">
										<asp:textbox id="txtHeat" runat="server" CssClass="form-control" AutoPostBack="True" Width="120px"></asp:textbox>
										<asp:requiredfieldvalidator id="rfvHeat_number" runat="server" ErrorMessage="*" ControlToValidate="txtHeat"></asp:requiredfieldvalidator></div>
								</div>
                                 <br />
								<div class="row">
									<div class="col">Last Location / Status</div>
									
									<div class="col"colSpan="3">
										<asp:label id="lblloca" runat="server" ForeColor="Red"></asp:label>&nbsp;/
										<asp:label id="lblstatus" runat="server" ForeColor="Red"></asp:label></div>
									<div class="col">
										<asp:label id="lblwheeltype" runat="server" ForeColor="Red" Visible="False"></asp:label>&nbsp;</div>
								</div>
                                 <br />
							
               
							
								<div class="row">
									<div class="col">Wheel Disposition</div>
								
									<div class="col">
										<asp:textbox id="txtWheel_disposition" runat="server" CssClass="form-control" AutoPostBack="True" Width="120px"></asp:textbox></div>
									<div class="col">Remarks</div>
									
									<div class="col">
										<asp:textbox id="txtRemarks" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:textbox></div>
								</div>
                                 <br />
								<div class="row">
									<div class="col"vAlign="top" align="middle" colSpan="6">
										<asp:button id="btnSave" runat="server" Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" Text="Save"></asp:button>
										<asp:Label id="lblSlNo" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:Button id="btnClear" runat="server" Text="Clear" Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark"></asp:Button></div>
								</div>
                                 <br />
						
						 <br />
							<asp:DataGrid id="DataGrid1" CssClass="table" runat="server" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#3366CC">
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid>

				<asp:DataGrid id="DataGrid2" runat="server" CellPadding="4" CssClass="table" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#3366CC">
					<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<Columns>
						<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
				</asp:DataGrid>
			</asp:Panel>
		</div></div></form></div>
         <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;position:relative;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>

	</body>
</HTML>
