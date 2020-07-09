<%@ Page Language="vb" AutoEventWireup="false" Codebehind="IngateAssemblyEdit.aspx.vb" Inherits="WebApplication2.IngateAssemblyEdit" %>
<!DOCTYPE HTML>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>IngateAssemblyEdit</title>
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
                        <script>

function OnlyNumericEntry() {
        if ((event.keyCode < 48 || event.keyCode > 57)) {
        event.returnValue = false;
    }
                            }
                            </script>
	</head>
	<body >
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
          <i class="fab glyphicon glyphicon-home "  style="font-size:30px;"></i>
        </a></li>

       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out"  style="font-size:30px;"></i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
         
        <img src="../../../NewFolder1/CRIS-Recruitment.jpg" height="45" style="border-radius:43%"/>
       </a>
      </li>
     </ul>
      
  </div>
</nav>   
<!--/.Navbar -->
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
            <div class="table">
			<asp:panel id="Panel1"  runat="server" >
                
                 <div class="container">
					
								<div class="row">
									<div class="col" align="center"><h3><strong>Ingate Assembly&nbsp;Details - Edit</strong></h3>

									</div>
								</div><br />
							<div class="row">
                                <div class="col">
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></div>
                                </div>
							<br />
								<div class="row">
									<div class="col">Date</div>
									
									<div class="col">
										<asp:textbox id="txtIngateDate" runat="server" CssClass="form-control" AutoPostBack="True" BorderStyle="Groove" ToolTip="date format mm/dd/yyyy" onkeypress="OnlyNumericEntry()"  Width="103px"></asp:textbox>
										<asp:requiredfieldvalidator id="rfvld1" runat="server" ErrorMessage="*" ControlToValidate="txtIngateDate" Display="Dynamic"></asp:requiredfieldvalidator></div>
									<div class="col">Shift</div>
									
									<div class="col">
										<asp:radiobuttonlist id="rblShift" runat="server" CssClass="rbl" AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal">
											<asp:ListItem Value="A" Selected="True">A&nbsp;</asp:ListItem>
											<asp:ListItem Value="B">B&nbsp;</asp:ListItem>
											<asp:ListItem Value="C">C&nbsp;</asp:ListItem>
										</asp:radiobuttonlist></div>
								
									<div class="col">Drag No</div>
									
									<div class="col" >
										<asp:textbox id="txtMouldNumber" runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="6" ToolTip="enter drag number(only numeric)" onkeypress="OnlyNumericEntry()"  Width="103px"></asp:textbox>
										<asp:requiredfieldvalidator id="rfvMldNo" runat="server" ErrorMessage="*" ControlToValidate="txtMouldNumber" Display="Dynamic"></asp:requiredfieldvalidator></div>
								</div>
                     <br />
								<div class="row">
                                    <div class="col">Past IG</div>
									
									<div class="col">
										<asp:textbox id="txtPastIngate" runat="server" CssClass="form-control" BorderStyle="Groove"  Width="103px"></asp:textbox></div>
								
									<div class="col">Present IG</div>
									
									<div class="col">
										<asp:radiobuttonlist id="rblPresentIng" runat="server" CssClass="rbl" RepeatLayout="Flow" RepeatDirection="Horizontal">
											<asp:ListItem Value="B21" Selected="True">B21&nbsp;</asp:ListItem>
											<asp:ListItem Value="B2">B2&nbsp;</asp:ListItem>
											<asp:ListItem Value="B3">B3&nbsp;</asp:ListItem>
											<asp:ListItem Value="B4">B4&nbsp;</asp:ListItem>
											<asp:ListItem Value="D14">D14&nbsp;</asp:ListItem>
											<asp:ListItem Value="D17">D17&nbsp;</asp:ListItem>
											<asp:ListItem Value="D19">D19&nbsp;</asp:ListItem>
											<asp:ListItem Value="D21">D21&nbsp;</asp:ListItem>
										</asp:radiobuttonlist></div>
								
								
									<div class="col" >Date Fitted</div>
									
									<div class="col">
										<asp:textbox id="txtDtFitted" runat="server" CssClass="form-control" ToolTip="date format mm/dd/yyyy" onkeypress="OnlyNumericEntry()"  Width="103px"></asp:textbox></div>
								</div>
                     <br />
								<div class="row">
                                    <div class="col">Date Removed</div>
									
									<div class="col">
										<asp:textbox id="txtDtRemoved" runat="server" CssClass="form-control" ToolTip="date format mm/dd/yyyy" onkeypress="OnlyNumericEntry()"  Width="103px"></asp:textbox>
										<asp:requiredfieldvalidator id="rfvld4" runat="server" ErrorMessage="*" ControlToValidate="txtDtRemoved" Display="Dynamic"></asp:requiredfieldvalidator></div>
								
									<div class="col">Wheel Cast</div>
								
									<div class="col" >
										<asp:textbox id="txtWheels_cast" runat="server" CssClass="form-control" ToolTip="enter wheel cast number(0 to 999999)" onkeypress="OnlyNumericEntry()" Width="103px"></asp:textbox>
										<asp:rangevalidator id="rngvld1" runat="server" ErrorMessage="*" ControlToValidate="txtWheels_cast" Display="Dynamic" Type="Integer" MinimumValue="0" MaximumValue="999999"></asp:rangevalidator></div>
									<div class="col">IG Supplier</div>
									
									<div class="col">
										<asp:radiobuttonlist id="rblSupplier" runat="server" CssClass="rbl" RepeatLayout="Flow" RepeatDirection="Horizontal">
											<asp:ListItem Value="ZIRCAR">ZIRCAR&nbsp;</asp:ListItem>
											<asp:ListItem Value="VESUVIUS">VESUVIUS&nbsp;</asp:ListItem>
										</asp:radiobuttonlist></div>
								</div>
                     <br />
								<div class="row">
									<div class="col">Reason</div>
									
									<div class="col">
										<asp:dropdownlist id="ddlReason" runat="server" CssClass="form-control ll" Width="350px"></asp:dropdownlist></div>
								
                     <div class="col"></div>
                            <div class="col"></div>
                            <div class="col"></div>
                          
                                    </div>
							<br />
                     <div class="row">
									<div class="col" align="center">
                                          <asp:button id="btnSave" runat="server" Text="Save"  Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" ></asp:button>
                                        </div>
                         <div class="col">
									  <asp:button id="btnClear" runat="server" Text="Clear"  Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" ></asp:button>
									</div>
								</div>
							
				
				
				<asp:DataGrid id="grdIngateAssembly" runat="server" CssClass="table" BorderStyle="None" AutoGenerateColumns="False" CellPadding="4" BackColor="White" BorderWidth="1px" BorderColor="#CC9966">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<Columns>
						<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
						<asp:BoundColumn DataField="IgDate" ReadOnly="True" HeaderText="IgDate"></asp:BoundColumn>
						<asp:BoundColumn DataField="Shift" ReadOnly="True" HeaderText="Shift"></asp:BoundColumn>
						<asp:BoundColumn DataField="DragNo" ReadOnly="True" HeaderText="DragNo"></asp:BoundColumn>
						<asp:BoundColumn DataField="EngNo" ReadOnly="True" HeaderText="EngNo"></asp:BoundColumn>
						<asp:BoundColumn DataField="PresentIG" ReadOnly="True" HeaderText="PresentIG"></asp:BoundColumn>
						<asp:BoundColumn DataField="Supplier" ReadOnly="True" HeaderText="Supplier"></asp:BoundColumn>
						<asp:BoundColumn DataField="PastIG" ReadOnly="True" HeaderText="PastIG"></asp:BoundColumn>
						<asp:BoundColumn DataField="WC" ReadOnly="True" HeaderText="WC"></asp:BoundColumn>
						<asp:BoundColumn DataField="DateFitted" ReadOnly="True" HeaderText="DateFitted"></asp:BoundColumn>
						<asp:BoundColumn DataField="DateRemoved" ReadOnly="True" HeaderText="DateRemoved"></asp:BoundColumn>
						<asp:BoundColumn DataField="reason" ReadOnly="True" HeaderText="reason"></asp:BoundColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
			    </asp:panel>
		</div></form>
        <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;position:absolute;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS></div>
        <script type="text/javascript">
           
           
             $(document).ready(function () {
                       
                        $('#txtDtFitted').datepicker({
                            dateFormat: "dd/mm/yy", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtDtFitted').datepicker('getDate');           
                                                 
                              
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
                       
                        $('#txtIngateDate').datepicker({
                            dateFormat: "dd/mm/yy", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtIngateDate').datepicker('getDate');           
                                                 
                              
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
                       
                        $('#txtDtRemoved').datepicker({
                            dateFormat: "dd/mm/yy", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtDtRemoved').datepicker('getDate');           
                                                 
                              
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
