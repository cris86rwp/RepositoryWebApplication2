<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PTMSCriticalItemSelect.aspx.vb" Inherits="WebApplication2.PTMSCriticalItemSelect" smartNavigation="True" %>
<!DOCTYPE HTML>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server" >
		<title>PTMSCriticalItemSelect</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0"/>
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
          <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"/>
  <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
  <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
         <link type="text/css" rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
          <link rel="Stylesheet" href="../StyleSheet1.css" />
         
	</head>
	<body>
           <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
  <a class="navbar-brand p-0" href="#"><img src="../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
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
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="http://localhost:52240/wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home "></i>
        </a></li>
       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}">
          <i class="fab glyphicon glyphicon-log-out"></i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
          <img  src="../NewFolder1/CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="45"/>
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
             <div class ="row">
                <div class="table-responsive">
			<table id="Table3" class="table">
				</table>						
                    <table id="Table2" class="table">
							 <tr>
								<td colspan="6" style=" color: #FFFFFF;"> 
										<asp:label id="lblConsignee" runat="server"></asp:label>
										&nbsp;Critical Item Selection<hr class="prettyline"/></td>
							</tr>
							 <tr>
								<td style=" color: #FFFFFF;">Message :
									<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></td>
							</tr>
							 <tr>
								<td style=" color: #FFFFFF;">PL Number</td>
								<td style=" color: #FFFFFF;" >:</td>
								<td  colspan="4">
									<asp:dropdownlist id="ddlPlNumber" CssClass="form-control ll" runat="server" AutoPostBack="True"></asp:dropdownlist>&nbsp;</td>
							</tr>
						</table>
				
						<asp:datagrid id="dgSavedData" runat="server" CssClass="table" BorderColor="#999999" BackColor="White" GridLines="Vertical" BorderStyle="None" BorderWidth="1px" CellPadding="3">
							<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
							<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
							<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
							<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
							<Columns>
								<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
						<table id="Table1" class="table">
							 <tr>
								<td colspan="6" style=" color: #FFFFFF;">
									<asp:CheckBox id="chkSelection"  runat="server" Text="To be Selected"></asp:CheckBox></td>
							</tr>
							 <tr>
								<td  align="center" colspan="6">
									<asp:button id="btnSave" CssClass="button button2" runat="server" Text="Save"></asp:button></td>
							</tr>
						</table>
				
                        </div>
             </div>
		</form>
                    </div>
           <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
            
	</body>
</html>
