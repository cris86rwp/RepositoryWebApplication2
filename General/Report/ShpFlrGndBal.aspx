<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ShpFlrGndBal.aspx.vb" Inherits="WebApplication2.ShpFlrGndBal" %>
<!DOCTYPE HTML >
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>ShpFlrGndBal</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR"/>
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
          <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"/>
         <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
  <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
         <link type="text/css" rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
          <%--<link rel="Stylesheet" href="../../StyleSheet1.css" />--%>
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
          <i class="fab glyphicon glyphicon-home "style="font-size:30px;"></i>
        </a></li>
               <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out"style="font-size:30px;"></i>
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
         <%--       <div class="row">
    
                  <h4>&nbsp&nbsp&nbspSelect Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px" >
                     
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />
                </div>--%>
			<asp:Panel id="Panel1"  runat="server">
                            <div class ="row">
                <div class="table-responsive">
              <%--  style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px"--%>
				<table id="Table2" class="table">
                    <%--cellSpacing="1" cellPadding="1" width="300"--%>
					<tr>
						<td  ><strong>Shop Floor Ground Balance</strong><hr class="prettyline" />
								<asp:Label id="lblConsignee" runat="server" Visible="False"></asp:Label></td>
					</tr>
					<tr>
						<td>
							<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></td>
					</tr>
					<tr>
						<td >
							<asp:dropdownlist id="cboCode" CssClass="form-control ll" runat="server" ></asp:dropdownlist></td>
					</tr>
					<tr>
						<td >
							<asp:RadioButtonList id="rblYear" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:RadioButtonList></td>
					</tr>
				</table>
				<table id="Table3" class="table">
                    <%--style="WIDTH: 608px; HEIGHT: 28px" cellSpacing="1" cellPadding="1" width="608"--%>
					<tr>
						<td >
							<asp:RadioButtonList id="rblMonth" runat="server" CssClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:RadioButtonList></td>
					</tr>
					<tr>
						<td align="center">
							<asp:button id="BtnShow" runat="server" CssClass="button button2"   Text="Show Report" ></asp:button></td>
					</tr>
				</table>
				<asp:Panel id="Panel2" runat="server">
					<table id="Table1" class="table" >
                       <%--  cellSpacing="1" cellPadding="1" width="300"--%>
						<tr>
							<td align="center">
								<asp:Button id="Button1" runat="server" CssClass="button button2" Text="Closure Advise"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								<asp:Button id="btnPCDO" runat="server" CssClass="button button2" Text="PCDO"></asp:Button></td>
						</tr>
					</table>
				</asp:Panel>
                      </div>
             </div>
			</asp:Panel></form>
                    </div>
           <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
              
	</body>
</html>
