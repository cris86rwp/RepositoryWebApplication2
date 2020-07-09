<%@ Page Language="vb" AutoEventWireup="false" Codebehind="mm_wheel_rej_ana_wap_norms_UI.aspx.vb" Inherits="WebApplication2.mm_wheel_rej_ana_wap_norms_UI" Culture="en-GB" uiCulture="en-GB" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Baking station</title>
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

   <%-- <link href="../../StyleSheet1.css" rel="stylesheet" />--%>

 
</head>
	<body MS_POSITIONING="GridLayout" bgColor="#b6dcf5">
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
            <div class="row">
                <div class="table-responsive">
		<form id="Form1" method="post" runat="server">
        <%--    <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br /> --%>   
			<asp:Panel id="Panel1" style="Z-INDEX: 103; LEFT: 8px; POSITION: absolute" runat="server">
				<TABLE id="Table2" style="WIDTH: 425px; HEIGHT: 87px" cellSpacing="1" cellPadding="1" width="425" border="1" DESIGNTIMEDRAGDROP="48">
					<TR>
						<TD align="middle" colSpan="6">Wheel Rejection Analysis Based on&nbsp;RWP Norms</TD>
					</TR>
					<TR>
						<TD colSpan="6">
							<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></TD>
					</TR>
					<TR>
						<TD>Date</TD>
						<TD>:
							<asp:RequiredFieldValidator id="rfvld1" runat="server" ControlToValidate="txtDate" Display="Dynamic">*</asp:RequiredFieldValidator></TD>
						<TD>
							<asp:textbox id="txtDate" runat="server" Width="103px" BorderStyle="Groove" AutoPostBack="True" CssClass="form-control"></asp:textbox></TD>
						<TD>
							<asp:Label id="lblProductType" runat="server">ProductType : </asp:Label></TD>
						<TD>:</TD>
						<TD>
							<asp:DropDownList id="ddlProduct" runat="server" CssClass="form-control"></asp:DropDownList></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="middle" colSpan="6">
							<asp:button id="BtnShow" runat="server" Width="120px" BorderStyle="Groove" Height="40px" Font-Size="Smaller" Font-Names="Arial" Text="Show Report" CssClass="form-control"></asp:button></TD>
					</TR>
				</TABLE>
			</asp:Panel>
		</form>
	</div>
                </div>
            </div>
     <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
