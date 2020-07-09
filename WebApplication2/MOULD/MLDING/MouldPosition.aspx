<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MouldPosition.aspx.vb" Inherits="WebApplication2.MouldPosition" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>MouldPosition</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR"/>
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
             <meta charset="utf-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css"/>
  <script  src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js"></script>
         <link type="text/css" rel="stylesheet" href="https://cdn.datatables.net/1.10.9/css/dataTables.bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="https://cdn.datatables.net/responsive/1.0.7/css/responsive.bootstrap.min.css" />
    <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.9/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/responsive/1.0.7/js/dataTables.responsive.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.9/js/dataTables.bootstrap.min.js"></script>
    <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
        <%--<link rel="stylesheet" href="../../StyleSheet1.css" />--%>
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
<!--/.Navbar -->
      <div class="container">    
		<form id="Form1" method="post" runat="server">
            <div class="row">
    
           <%--       <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
      </div>

             <div class="row">
                 <div class="table-responsive">
			        <asp:panel id="Panel2" runat="server">
                            <div class="container-fluid">
								<div class="row">
                                    <div class="col">Mould Position at begining of the Shift</div>
                                 </div>
                              </div>
                         <div class="container-fluid">
                             <div class="row">
                                    <div class="col" ><asp:label id="lblMessage" runat="server" Width="357px" Font-Size="Medium" Font-Bold="True" ForeColor="Red"></asp:label></div>
                                 </div>

								<div class="row">
                                    <div class="col-3">Date : </div>
                                   <div class="col-3"> <asp:textbox id="txtDate" runat="server" BorderStyle="Groove" AutoPostBack="True" CssClass="form-control"></asp:textbox></div>
                                     <div class="col-3">Shift : </div>
                                    <div class="col-3">
                                        <asp:radiobuttonlist id="rblShift" runat="server" CssClass="rbl" AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal">
											<asp:ListItem Value="A" Selected="True">A</asp:ListItem>
											<asp:ListItem Value="B">B</asp:ListItem>
											<asp:ListItem Value="C">C</asp:ListItem>
										</asp:radiobuttonlist>
                                    </div>
                                    </div>

                             	<div class="row">
                                    <div class="col">
                                        <asp:RadioButtonList id="rblType" runat="server" CssClass="rbl" AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal">
											<asp:ListItem Value="OnLINE" Selected="True">OnLINE</asp:ListItem>
											<asp:ListItem Value="MOMPO1">MOMPO1</asp:ListItem>
											<asp:ListItem Value="MOMPO2">MOMPO2</asp:ListItem>
											<asp:ListItem Value="MOMPO3">MOMPO3</asp:ListItem>
										</asp:RadioButtonList>
                                        </div>
                                     </div>

                             <div class="row">
                                    <div class="col">
                                        	<asp:RadioButtonList id="rblMould" runat="server" CssClass="rbl" AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal">
											<asp:ListItem Value="C" Selected="True">Cope</asp:ListItem>
											<asp:ListItem Value="D">Drag</asp:ListItem>
										</asp:RadioButtonList>
                                        </div>
                                 </div>

                             <div class="row">
                                    <div class="col-3">MouldType :</div>
                                 <div class="col-3"><asp:DropDownList id="ddlWhlType" runat="server" AutoPostBack="True" CssClass=" form-control ll"></asp:DropDownList></div>
                            
                                    <div class="col-3">Value :</div>
                                    <div class="col-3"><asp:textbox id="txtValue" runat="server" AutoPostBack="True" CssClass="form-control"></asp:textbox></div>

                                <div class="col"><asp:Label id="lblSlNo" runat="server" Visible="False"></asp:Label></div>
                            </div>

                             <br />
                             <div class="row">
                                 <div class="col-6"><asp:Button id="btnSave" runat="server" Text="Save" CssClass="button button2" style="margin-left:540px;" Width="100px"></asp:Button></div>
                             </div>
                                
                       </div>

                        	<asp:Panel id="Panel1" runat="server">
                                   <div class="container-fluid">
								     <div class="row">
                                      <div class="col">Mould Transaction Query</div>
						</div>
						 <div class="row">
                            <div class="col-3">FromDate : </div>
							<div class="col-3">
								<asp:TextBox id="txtFromDate" runat="server" Width="" CssClass="form-control"></asp:TextBox></div>
						
                            <div class="col-3">ToDate : </div>
							<div class="col-3">
								<asp:TextBox id="txtToDate" runat="server" Width="" CssClass="form-control"></asp:TextBox></div>
						</div>
					</div>

    <asp:RadioButtonList id="rblTranType" runat="server" Width="" CssClass="rbl" AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal"></asp:RadioButtonList>

<br />
					<div class="container-fluid">
					    <div class="row">
                            <div class="col">
								<asp:Button id="Button1" runat="server" Text="Show DateWise Transaction Details" CssClass="button button2" style="margin-left:500px;" Width=""></asp:Button></div>
						</div>
                        <br />
						 <div class="row">
                            <div class="col-3">MouldNo : </div>
							<div class="col-3">
								<asp:TextBox id="txtMouldNo" runat="server" AutoPostBack="True" CssClass="form-control"></asp:TextBox></div>
						</div>
                        <br />
						 <div class="row">
                            <div class="col">
								<asp:Button id="Button2" runat="server" Text="Show Mould Transaction Details" CssClass="button button2" style="margin-left:500px;" Width=""></asp:Button></div>
						</div>
					</div>

                    <asp:DataGrid id="DataGrid1" runat="server" BorderStyle="None" BorderColor="#CC9966" BorderWidth="1px" BackColor="White" CellPadding="4" CssClass="table">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<Columns>
						<asp:ButtonColumn Text="Delete" CommandName="Delete"></asp:ButtonColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>

                           <asp:DataGrid id="DataGrid2" runat="server" BorderStyle="None" BorderColor="#3366CC" BorderWidth="1px" BackColor="White" CellPadding="4" CssClass="table">
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid>

                        <asp:DataGrid id="DataGrid3" runat="server" BorderStyle="None" BorderColor="#CC9966" BorderWidth="1px" BackColor="White" CellPadding="4" CssClass="table">
						<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
						<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
						<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
						<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
						<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
					</asp:DataGrid>
</asp:Panel>
                 </asp:panel>
                </div>
              </div>

 </form>           
 </div>
</body>
</html>
