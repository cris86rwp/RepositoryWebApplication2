<%@ Page Language="vb" AutoEventWireup="false" Codebehind="HSDConsumption.aspx.vb" Inherits="WebApplication2.HSDConsumption" %>
<!DOCTYPE HTML >
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>HSDConsumption</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR"/>
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
	     <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css"/>
  <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js"></script>
  <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js"></script>

        
    <link type="text/css" rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
   
          <link rel="stylesheet" href="../../StyleSheet1.css" />
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
       <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home "></i>
        </a></li>
       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out"></i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
          <img src="../../NewFolder1/CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="45"/>
        </a>
      </li>
     </ul>
      
  </div>
</nav>
        <div class="container">
		<form id="Form1" method="post" runat="server">
            <div class="row">
    
                  <h4>&nbsp&nbsp&nbspSelect Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px" >
                     
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />
                </div>
			<asp:panel id="Panel1" runat="server">
                        <div class ="row">
                <div class="table-responsive">
				<table id="Table1" class="table" >
					<tr>
						<td align="center">LPG and BMCG Flow Meter Readings<hr class="prettyline"/></td>
					</tr>
					<tr>
						<td align="center">
							<asp:Label id="lblShop" runat="server"></asp:Label></td>
					</tr>
					<tr>
						<td >
							<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></td>
					</tr>
				</table>
				<table id="Table2" class="table">
					<tr>
						<td>
							<asp:RadioButtonList id="rblDataPoints" runat="server" CssClass="rbl" AutoPostBack="True" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:RadioButtonList></td>
					</tr>
				</table>
				<asp:Panel id="Panel2" runat="server">
					<table id="Table4" class="table">
						<tr>
							<td>PreviousDate</td>
							<td>:</td>
							<td>
								<asp:TextBox id="txtPreDate" runat="server" AutoPostBack="True" CssClass="form-control"></asp:TextBox></td>
							<td>MeterReading</td>
							<td>:</td>
							<td>
								<asp:TextBox id="txtPreMeterReading" runat="server" CssClass="form-control" AutoPostBack="True" Width="52px"></asp:TextBox></td>
							<td>Consumption</td>
							<td>:</td>
							<td>
								<asp:Label id="lblConsumption" runat="server"></asp:Label></td>
						</tr>
						<tr>
							<td>Remarks</td>
							<td>:</td>
							<td colspan="7">
								<asp:TextBox id="txtRemarks" CssClass="form-control" runat="server"></asp:TextBox></td>
						</tr>
					</table>
				</asp:Panel>
				<table id="Table5" class="table">
					<tr>
						<td>Date</td>
						<td>:</td>
						<td>
							<asp:TextBox id="txtDate" CssClass="form-control" runat="server" AutoPostBack="True" ></asp:TextBox></td>
						<td>MeterReading</td>
						<td>:</td>
						<td>
							<asp:TextBox id="txtMeterReading"  CssClass="form-control" runat="server" AutoPostBack="True" Width="52px"></asp:TextBox></td>
					</tr>
					<tr>
						<TD vAlign="top" align="center" colspan="6">
							<asp:Button id="btnSave" CssClass="button button2" runat="server" Text="Save"></asp:Button></TD>
					</tr>
				</table>
				<asp:DataGrid id="DataGrid1" runat="server"  CssClass="table" >
                    <%--BackColor="White" CellPadding="4" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966"--%>
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
                          </div>
                            </div>
			</asp:panel></form>
            </div>
           <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</html>
