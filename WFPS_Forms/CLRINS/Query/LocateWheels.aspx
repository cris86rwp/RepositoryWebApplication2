<%@ Page Language="vb" AutoEventWireup="false" Codebehind="LocateWheels.aspx.vb" Inherits="WebApplication2.LocateWheels" %>
<!DOCTYPE HTML PUBLIC >
<html>
	<head runat="server">
		<title>WebForm1</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR"/>
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
          <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css"/>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js"></script>
        
    <link type="text/css" rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
       <%-- <link rel="stylesheet" href="../../../StyleSheet1.css" />--%>
	 <%--   <style type="text/css">
            .auto-style1 {
                height: 39px;
            }
        </style>--%>
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
<!--/.Navbar -->
         <div class="container">
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
            <div class="row">
            <div class="table-responsive">
		
			<table id="Table1" class="table"  >
                	<tr><td colspan="4"><strong>
						Wheel Locator</strong><hr class="prettyline" /></td>
			</tr>
				<tr>
					<td >1. Wheel Locator shows entered wheels in Master and also in any of the location 
						Mag, Fi, Yard, Whl Load to AAS as per its latest status</td>
				</tr>
				<tr>
					<td>2. Suffix '/0' to series wheels while inputting wheels (separate&nbsp;multiple 
						wheels by comma, separate heat number from engraved number by '/')</td>
				</tr>
				<tr>
					<td>3.&nbsp;Input Wheel count will be shown.&nbsp; Check it with Master 
						count.&nbsp; If mismatches, check wheels input for duplicates, wrong numbers, 
						etc.</td>
				</tr>
				<tr>
					<td>4. Sum of all counts in each location will match to the count of master (if 
						same wheel number is not entered in query more than once).</td>
				</tr>
				<tr>
					<td>5. Click Export button and change 'Save In' as required, change file type to MS 
						Excel, Type any file name with .XLS extension and click 'Save'</td>
				</tr>
				<tr>
					<td >Message:
						<asp:Label id="lblMessage" runat="server"></asp:Label></td>
				</tr>
				<tr>
					<td ><strong>Wheel Numbers</strong></td>
				</tr>
				<tr>
					<td >
						<asp:Label id="lblInputCount" runat="server" ForeColor="Red" Font-Size="Medium" Font-Bold="True"></asp:Label></td>
				</tr>
				<tr>
					<td >
						<asp:Label id="lblSegregatedCount" runat="server" ForeColor="Blue" Font-Size="Medium" Font-Bold="True"></asp:Label></td>
				</tr>
				<tr>
					<td >&nbsp;<asp:textbox id="txtEngNo" runat="server"  AutoPostBack="True" TextMode="MultiLine" MaxLength="8000"  CssClass="form-control"></asp:textbox></td>
				</tr>
				<tr>
					<td ><asp:radiobuttonlist id="rdoShow" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" CssClass="rbl" >
							<asp:ListItem Value="Master">Master</asp:ListItem>
							<asp:ListItem Value="MagTbl">Mag</asp:ListItem>
							<asp:ListItem Value="FiTbl">Fi</asp:ListItem>
							<asp:ListItem Value="YdTbl">Yard</asp:ListItem>
					<%--		<asp:ListItem Value="LdTbl">WhlLdToAAS</asp:ListItem>--%>
							<asp:ListItem Value="UnBTbl">Un-Bore</asp:ListItem>
					<%--		<asp:ListItem Value="PressTbl">Mounted</asp:ListItem>--%>
							<asp:ListItem Value="DespTbl">Despatched</asp:ListItem>
							<asp:ListItem Value="ReadyTbl">DespatchCheck</asp:ListItem>
							<asp:ListItem Value="Duplicate">Duplicate</asp:ListItem>
							<asp:ListItem Value="NotInMaster">NotInMaster</asp:ListItem>
							<asp:ListItem Value="ClosureTbl">ClosureValue</asp:ListItem>
						</asp:radiobuttonlist></td>
				</tr>
				<tr>
					<td >
						<asp:button id="btnExportDetails" runat="server" Text="Export Details" CssClass="button button2"></asp:button></td>
				</tr>
				<tr>
					
						<asp:datagrid id="dgData" CssClass="table" runat="server"  BackColor="LightGoldenrodYellow"  GridLines="None" ForeColor="Black">
							<SelectedItemStyle ForeColor="GhostWhite" BackColor="DarkSlateBlue"></SelectedItemStyle>
							<AlternatingItemStyle BackColor="PaleGoldenrod"></AlternatingItemStyle>
							<HeaderStyle Font-Bold="True" BackColor="Tan"></HeaderStyle>
							<FooterStyle BackColor="Tan"></FooterStyle>
							<PagerStyle HorizontalAlign="Center" ForeColor="DarkSlateBlue" BackColor="PaleGoldenrod"></PagerStyle>
						</asp:datagrid>
				</tr>
			</table>
		</div></div>
		</form>
                </div>
         <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</html>
