<%@ Page Language="vb" AutoEventWireup="false" Codebehind="mm_ContinueShift_AuthorisationView.aspx.vb" Inherits="WebApplication2.mm_ContinueShift_AuthorisationView" %>
<!DOCTYPE HTML PUBLIC "-//W3C//Dtd HTML 4.0 transitional//EN">
<html>
	<head runat="server">
		<title>mm_ContinueShift_AuthorisationView</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0"/>
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
         <meta charset="utf-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css"/>
  <script  src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js"></script>
        <link type="text/css" rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
        <%--<link rel="stylesheet" href="../../../StyleSheet1.css" />--%>

	</head>
	<body >
        <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
  <a class="navbar-brand p-0" href="#"><img src="../../../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
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
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home " style="font-size:30px;"></i>
        </a></li>
       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out" style="font-size:30px;"></i>
        </a></li>
    
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
          <img src="../../../NewFolder1/CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="45"/>
        </a>
      </li>
     </ul>
      
  </div>
</nav>
          <div class="container ">
               
        
            
		<form id="Form1" method="post" runat="server">
             <div class="row">
 <%--<h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
      </div>
			<asp:Panel id="Panel1"  runat="server">
                 <div class="row">
                <div class="table-responsive">
				<table id="table1" class="table">
					<tr>
						<td colSpan="3">
							<asp:Label id="lblMessage" runat="server"></asp:Label></td>
					</tr>
					<tr>
						<td>Date</td>
						<td>:</td>
						<td>
							<asp:TextBox id="txtdt" runat="server" AutoPostBack="true" CssClass="form-control"></asp:TextBox></td>
					</tr>
					<tr>
						<td colSpan="3">
							<asp:DataGrid id="DataGrid2" runat="server" CssClass="table">
                                <%--BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4">--%>
								<SelectedItemStyle Font-Bold="true" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Bold="true" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid></td>
					</tr>
				</table>
				<table id="table2">
                          
            
					<tr>
						<td> <%--vAlign="top" align="left" colSpan="1" rowSpan="1">--%>
                            
							<asp:DataGrid id="DataGrid1" runat="server" CssClass="table" BorderColor="#CC9966">
                              
								<SelectedItemStyle Font-Bold="true" ForeColor="#663399" BackColor="#FFCC66" ></SelectedItemStyle>
								<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Bold="true"  ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
								<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
								<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
							</asp:DataGrid></td>
						<td vAlign="top" align="left">
							<asp:DataGrid id="DataGrid3" runat="server" CssClass="table" ForeColor="Black" BackColor="White" GridLines="Vertical">
                                <%-- BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px"  CellPadding="4" >--%>
								<SelectedItemStyle Font-Bold="true" ForeColor="Black" BackColor="#CE5D5A" > </SelectedItemStyle>
								<AlternatingItemStyle  BackColor="White"> </AlternatingItemStyle>
								<ItemStyle   BackColor="#F7F7DE" > </ItemStyle> 
								<HeaderStyle Font-Bold="true" ForeColor="White" BackColor="#6B696B" ></HeaderStyle>
								<FooterStyle   BackColor="#CCCC99"></FooterStyle>
								<PagerStyle HorizontalAlign="Right"   Mode="NumericPages" ForeColor="Black" BackColor="#F7F7DE"></PagerStyle>
							</asp:DataGrid>
                            
						</td>
                        
					</tr>
                          
            
				</table>
			</div></div></asp:Panel>
		</form></div>
         <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</html>
