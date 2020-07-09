<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Mould_history.aspx.vb" Inherits="WebApplication2.Mould_history" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Baking station</title>
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
 <style type="text/css">
    .radioButtonList { list-style:none; margin: 0; padding: 0;}
    .radioButtonList.horizontal li { display: inline;}

    .radioButtonList label{
        display:inline;
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
           <%-- <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
                       
			
                <div class="table">
                    <div class="container">
										
											<div class="row">
												<div class="col" align="center"><h3><strong>Mould History</strong></h3></div>
											</div>
                        <br />
											<div class="row">
												<div class="col">
													<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></div>
											</div>
                                            <br />
											<div class="row">
												<div class="col">Mould No</div>
												
                                               
												<div class="col">
													<asp:TextBox id="txtMldNo" Width="103px" runat="server" CssClass="form-control" MaxLength="5" ToolTip="pls enter 5-digit mould no" onkeypress="OnlyNumericEntry()"></asp:TextBox></div>
											<div class="col"></div>
                                                <div class="col"></div>
                                            </div>
                        <br />
											<div class="row">
												<div class="col">
												<asp:button id="btnQuerry" runat="server" Text="Show Querry"  Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" ></asp:button>
							</div>
												<div class="col">
													 <asp:button id="btnReport" runat="server" Text="Show Report"  Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" ></asp:button>
							</div>
												<div class="col">
                                                     <asp:button id="Button1" runat="server" Text="Show XC Wheels List"  Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" ></asp:button>
							
												</div>
											
												<div class="col">
                                                    <asp:button id="Button2" runat="server" Text="Show Wheels Cast Details"  Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" ></asp:button>
							
												</div>
								</div>
							<br />		
				<div class="row">
					<div class="col"><asp:panel id="Panel1" runat="server">
									<div class="col">
										<asp:DataGrid id="dgStatus" runat="server" CssClass="table" BorderStyle="None" BorderColor="#CC9966" BorderWidth="1px" BackColor="White" CellPadding="4">
											<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
											<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
											<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
											<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
											<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
										</asp:DataGrid></div>
							
							<asp:DataGrid id="DataGrid1" runat="server" CssClass="table" BorderStyle="None" BorderColor="#CC9966" BorderWidth="1px" BackColor="White" CellPadding="4" Height="76px">
								<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
								<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
								<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
								<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
							</asp:DataGrid>
							<asp:DataGrid id="DataGrid2" runat="server" CssClass="table" BorderStyle="None" BorderColor="#CC9966" BorderWidth="1px" BackColor="White" CellPadding="4" Height="112px">
								<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
								<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
								<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
								<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
							</asp:DataGrid>
							<asp:DataGrid id="DataGrid3" runat="server" CssClass="table" BorderStyle="None" BorderColor="#CC9966" BorderWidth="1px" BackColor="White" CellPadding="4" Height="125px">
								<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
								<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
								<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
								<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
							</asp:DataGrid>
							<asp:DataGrid id="DataGrid4" runat="server" CssClass="table" BorderStyle="None" BorderColor="#3366CC" BorderWidth="1px" BackColor="White" CellPadding="4" Height="91px">
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid>
							<asp:DataGrid id="DataGrid5" runat="server" CssClass="table" BorderStyle="None" BorderColor="#3366CC" BorderWidth="1px" BackColor="White" CellPadding="4" Height="125px">
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid>
							<asp:DataGrid id="DataGrid7" runat="server" CssClass="table" BorderStyle="None" BorderColor="#3366CC" BorderWidth="1px" BackColor="White" CellPadding="4" Height="94px">
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid>
							<asp:DataGrid id="DataGrid8" runat="server" ForeColor="Black" CssClass="table" BorderStyle="Solid" BorderColor="#999999" BorderWidth="1px" BackColor="White" CellPadding="3" GridLines="Vertical">
								<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#000099"></SelectedItemStyle>
								<AlternatingItemStyle BackColor="#CCCCCC"></AlternatingItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Black"></HeaderStyle>
								<FooterStyle BackColor="#CCCCCC"></FooterStyle>
								<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999"></PagerStyle>
							</asp:DataGrid>
						</asp:panel></div>
				</div>
              </div>
                    </div>
                    
					<div class="container">	
							<div class="row">
								<div class="col">PO Number</div>
								
								<div class="col"><asp:textbox id="txtPO" Width="103px" runat="server" CssClass="form-control" MaxLength="6" ToolTip="enter 6-digit PO number(only numeric)" onkeypress="OnlyNumericEntry()"></asp:textbox></div>
							
                        <div class="col"> </div>
                        <div class="col"></div>
                        </div>
                                <br />
							<div class="row">
								<div class="col"><asp:radiobuttonlist id="rblPO" runat="server" CssClass="rbl"  RepeatDirection="Horizontal" AutoPostBack="true">
										<asp:ListItem Value="0" Selected="True">PO&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Details&nbsp;</asp:ListItem>
										<asp:ListItem Value="1">PO&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Summary&nbsp;</asp:ListItem>
										<asp:ListItem Value="2">XC Wheels Details&nbsp;</asp:ListItem>
										<asp:ListItem Value="3">XC Wheels Summary&nbsp;</asp:ListItem>
										<asp:ListItem Value="4">Offload Wheel Summary&nbsp;</asp:ListItem>
										<asp:ListItem Value="5">PO Condemned and Active moulds&nbsp;</asp:ListItem>
										<asp:ListItem Value="6">Offload(624, 626, 46, 56)&nbsp;</asp:ListItem>
										<asp:ListItem Value="7">Offload Wheels Details&nbsp;</asp:ListItem>
									</asp:radiobuttonlist></div>
							</div>
                         <br />
							<div class="row">
                               
								<div class="col">
							
								<asp:button id="btnSum" runat="server" Text="Show Data in Grid"  Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" ></asp:button>
							</div>
								<div class="col">
                                	<asp:button id="btnExportDetails" runat="server" Text="Export Details"  Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" ></asp:button>
							</div>
						</div>
						<br />
                            <div class="row">
                                <div class="col">
						<asp:datagrid id="DataGrid6" runat="server" CssClass="table" BorderStyle="None" BorderColor="#CC9966" BorderWidth="1px" BackColor="White" CellPadding="4">
							<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
							<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
							<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
							<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
						</asp:datagrid>
                                    </div>
				</div>
		</div>
		</form>
        
      <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;position:absolute;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</div>
     
	</body>
</HTML>


