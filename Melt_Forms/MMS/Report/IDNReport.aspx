<%@ Page Language="vb" AutoEventWireup="false" Codebehind="IDNReport.aspx.vb" Inherits="WebApplication2.IDNReport" %>
<!DOCTYPE HTML PUBLIC >
<html>
	<head runat="server">
		<title>IDNReport</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0"/>
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
         <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css"/>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js"></script>

   
    <link type="text/css" rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />

       <%-- <link rel="stylesheet" href="../../../StyleSheet1.css" />--%>
    
	</head>
	<body>

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


			<asp:Panel id="Panel1"  runat="server">

                  <div class="row">
            <div class="table-responsive">
				<table id="Table1" class="table" border="0">
					<tr>
						<td align="center">IDN Report<hr class="prettyline" /></td>
					</tr>
				</table>
				<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label>
				<table id="Table4" class="table" border="0">
					<tr>
						<td>
							<asp:RadioButtonList id="rblType" runat="server"  RepeatLayout="Flow" RepeatDirection="Horizontal" AutoPostBack="True" CssClass="rbl">
								<asp:ListItem Value="0" Selected="True">Based on Received Date</asp:ListItem>
								<asp:ListItem Value="1">Based on Cleared Date</asp:ListItem>
							</asp:RadioButtonList></td>
					</tr>
				</table>
				<table id="Table3" class="table" border="0">
					<tr>
						<td>FromDate :</td>
						<td>
							<asp:textbox id="txtFrDt" runat="server" CssClass="form-control"></asp:textbox></td>
						<td>ToDate :</td>
						<td>
							<asp:textbox id="txtToDt" runat="server"  CssClass="form-control"></asp:textbox></td>
					</tr>
				</table>
				<asp:Panel id="Panel2" runat="server">
					<asp:DropDownList id="ddlPresentStatus" runat="server" CssClass="form-control ll"></asp:DropDownList>
				</asp:Panel>
				<table id="Table2" class="table" border="0">
					<tr>
						<td align="center">
							<asp:Button id="btnIDN" runat="server" Text="Show Report" CssClass="button button2"></asp:Button></td>
					</tr>
				</table></div></div>
			</asp:Panel>
		</form></div>
        <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</html>
