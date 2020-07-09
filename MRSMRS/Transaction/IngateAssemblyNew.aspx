<%@ Page Language="vb" AutoEventWireup="false" Codebehind="IngateAssemblyNew.aspx.vb" Inherits="WebApplication2.IngateAssemblyNew" %>
<!DOCTYPE HTML>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>IngateAssemblyNew</title>
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
         .auto-style5 {
             display: block;
             font-size: 14px;
             font-weight: 400;
             line-height: 1.42857143;
             color: #555;
             background-clip: padding-box;
             border-radius: 4px;
             transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
             -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
             box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
             -webkit-transition: border-color ease-in-out .15s, -webkit-box-shadow ease-in-out .15s;
             -o-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
             border: 1px solid #ccc;
             padding: 6px 12px;
             background-color: #fff;
             background-image: none;
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
 <div class="table">
            <div class="container">
			<asp:panel id="Panel1"  runat="server" >
				
					
							
								<div class="row">
									<div class="col" align="center"><h3><strong>Ingate Assembly&nbsp;Details</strong></h3></div>
								</div><br />
								<div class="row">
									<div class="col">
										<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></div>
								</div><br />
								<div class="row">
									<div class="col">Date</div>
								
									<div class="col">
										<asp:textbox id="txtIngateDate" runat="server" CssClass="auto-style5" BorderStyle="Groove" AutoPostBack="True" ToolTip="date format mm/dd/yyyy" onkeypress="OnlyNumericEntry()" Width="105px"></asp:textbox></div>
									<div class="col">Shift</div>
									
									<div class="col">
										<asp:radiobuttonlist id="rblShift" runat="server" CssClass="rbl" AutoPostBack="True" RepeatDirection="Horizontal" RepeatLayout="Flow">
											<asp:ListItem Value="A" Selected="True">A&nbsp;</asp:ListItem>
											<asp:ListItem Value="B">B&nbsp;</asp:ListItem>
											<asp:ListItem Value="C">C&nbsp;</asp:ListItem>
										</asp:radiobuttonlist></div>
								
									<div class="col">Drag No</div>
									
									<div class="col" >
										<asp:textbox id="txtMouldNumber" runat="server" CssClass="auto-style5" AutoPostBack="True" MaxLength="4" ToolTip="enter drag number(only numeric)" onkeypress="OnlyNumericEntry()" Width="103px"></asp:textbox></div>
								</div><br />
								<div class="row">
                                    <div class="col">Past IG</div>
									
									<div class="col">
										<asp:textbox id="txtPastIngate" runat="server" CssClass="auto-style5" BorderStyle="Groove" Width="102px"></asp:textbox></div>
								
									<div class="col">Present IG</div>
									
									<div class="col">
										<asp:radiobuttonlist id="rblPresentIng" runat="server" CssClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow">
											<asp:ListItem Value="B21">B21&nbsp;</asp:ListItem>
											<asp:ListItem Value="B2">B2&nbsp;</asp:ListItem>
											<asp:ListItem Value="B3">B3&nbsp;</asp:ListItem>
											<asp:ListItem Value="B4">B4&nbsp;</asp:ListItem>
											<asp:ListItem Value="D14">D14&nbsp;</asp:ListItem>
											<asp:ListItem Value="D17">D17&nbsp;</asp:ListItem>
											<asp:ListItem Value="D19">D19&nbsp;</asp:ListItem>
											<asp:ListItem Value="D21">D21&nbsp;</asp:ListItem>
										</asp:radiobuttonlist></div>
								
									<div class="col" >Data Fitted</div>
									
									<div class="col">
										<asp:textbox id="txtDtFitted" runat="server" CssClass="form-control" BorderStyle="Groove"  onkeypress="OnlyNumericEntry()" Width="103px"></asp:textbox></div>
									</div>
						<br />
							
								<div class="row">
                                    <div class="col" >Date Removed</div>
									
									<div class="col" >
										<asp:textbox id="txtDtRemoved" runat="server" CssClass="auto-style5" BorderStyle="Groove" ToolTip="date format mm/dd/yyyy" onkeypress="OnlyNumericEntry()" Width="103px"></asp:textbox></div>
								
									<div class="col">Wheel Cast</div>
									
									<div class="col">
										<asp:textbox id="txtWheels_cast" runat="server" CssClass="auto-style5" BorderStyle="Groove" ToolTip="enter wheel cast number(0 to 999999)" onkeypress="OnlyNumericEntry()" Width="103px"></asp:textbox></div>
									<div class="col">IG Supplier</div>
									
									<div class="col">
										<asp:radiobuttonlist id="rblSupplier" CssClass="rbl" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
											<asp:ListItem Value="ZIRCAR">ZIRCAR&nbsp;</asp:ListItem>
											<asp:ListItem Value="VESUVIUS">VESUVIUS&nbsp;</asp:ListItem>
										</asp:radiobuttonlist></div>
								</div>
                <br />
								<div class="row">
									<div class="col">Reason</div>
									
									<div class="col">
										<asp:dropdownlist id="txtReason_for_removal" CssClass="form-control ll" runat="server" Width="350px"></asp:dropdownlist></div>
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
							
						
							<asp:DataGrid id="dgPastDetails" CssClass="table" runat="server" BorderStyle="None" BorderColor="#3366CC" BorderWidth="1px" BackColor="White" CellPadding="4">
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid>&nbsp;
				
				<asp:DataGrid id="grdIngateAssembly" CssClass="table" runat="server" BorderStyle="None" BorderColor="#CC9966" BorderWidth="1px" BackColor="White" CellPadding="4">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
			</asp:panel>
                </div></div></form>
           <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;position:absolute;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
        <script type="text/javascript">
           
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
