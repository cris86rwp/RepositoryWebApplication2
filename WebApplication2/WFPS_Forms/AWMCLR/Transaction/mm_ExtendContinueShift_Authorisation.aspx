<%@ Page Language="vb" AutoEventWireup="false" Codebehind="mm_ExtendContinueShift_Authorisation.aspx.vb" Inherits="WebApplication2.mm_ExtendContinueShift_Authorisation" Culture="en-GB" uiCulture="en-GB" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
	<head runat="server">
		<title>mm_ExtendContinueShift_Authorisation</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0"/>
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>

         <meta charset="utf-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css"/>
  <script  src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js"></script>
        <link type="text/css" rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
       <%-- <link rel="stylesheet" href="../../../StyleSheet1.css" />--%>
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
                 <%--  <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
                     </div>
        
     <hr class="prettyline" />
			<asp:Panel id="Panel2" runat="server">
                 <div class="row">
                <div class="table-responsive">
				<table id="Table3" class="table">
					<tr>
						<td align="middle"><strong><font size="4">Authorisation for Extention of&nbsp;Continuation 
									of&nbsp;Shift to meet Production Exegencies.&nbsp; </font></strong></td>
					</tr>
					<tr>
						<td align="middle"><font color="#ff3300" size="5">( used to extend the shift only) </font></td>
					</tr>
					<tr>
						<td align="centre"><strong><font size="4">(Use&nbsp; 'Closing of&nbsp;Continuation 
									of&nbsp;Shift'&nbsp;screen to change or edit or close number of records to be 
									posted)</font></strong></td>
					</tr>
					<tr>
						<td>
							<asp:label id="lblMessage" runat="server" Font-Bold="True" ForeColor="Red" Font-Size="Medium"></asp:label></td>
					</tr>
					<tr>
						<td>
							<asp:checkbox id="chkHelp" runat="server" Text="Help" AutoPostBack="True"></asp:checkbox></td>
					</tr>
				</table>
				<table id="Table4" class="table" >
					<tr>
						<td>
							<asp:label id="lblHelp" runat="server" Font-Underline="True"></asp:label></td>
					</tr>
				</table>
				<table id="Table5" class="table" >
					<tr>
						<td>Employee Code</td>
						<td>
							<asp:label id="lblEmpCode" runat="server"></asp:label></td>
						<td>Product</td>
						<td>
							<asp:label id="lblProduct" runat="server"></asp:label></td>
					</tr>
				</table>
				<table id="Table6" class="table" >
					<tr>
						<td>Previous Authorisation details:</td>
						<td>
							<asp:datagrid id="dgData" runat="server" CssClass="table" BackColor="White"  CellPadding="3" GridLines="None" CellSpacing="1">
                                <%-- BorderColor="White" BorderStyle="Ridge"  BorderWidth="2px" >--%>
								<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#9471DE"></SelectedItemStyle>
								<ItemStyle ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
								<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
								<PagerStyle HorizontalAlign="Right" ForeColor="Black" BackColor="#C6C3C6"></PagerStyle>
							</asp:datagrid></td>
					</tr>
				</table>
                    <table id="Table2" class="table">
									<tr>
										<td>
											<asp:label id="lblDateType" runat="server">Extended Inspection Date</asp:label></td>
										<td>
											<asp:label id="lblInspDate" runat="server"></asp:label></td>
										<td>Shift</td>
										<td>
											<asp:label id="lblInspShift" runat="server"></asp:label></td>
									</tr>
								</table>
				<table id="Table1" class="table">
					<tr>
						<td colspan="4"> 
							<asp:Panel id="Panel1" runat="server"><%-- BackColor="#C0C0FF" >--%>
								<%--<table id="Table2" >
									<tr>
										<td>
											<asp:label id="lblDateType" runat="server">Extended Inspection Date</asp:label></td>
										<td>
											<asp:label id="lblInspDate" runat="server"></asp:label></td>
										<td>Shift</td>
										<td>
											<asp:label id="lblInspShift" runat="server"></asp:label></td>
									</tr>
								</table>--%>
							</asp:Panel></td>
					</tr>
					<tr>
						<td   > <%-->--%>
							<asp:checkbox id="chkQtyToBePosted" runat="server" Text="Number of Records to be posted" AutoPostBack="True" ></asp:checkbox></td>
						<td >
							<asp:textbox id="txtQtyReqd" runat="server" AutoPostBack="True" CssClass="form-control"></asp:textbox>
							<asp:requiredfieldvalidator id="rfvQty" runat="server" ControlToValidate="txtQtyReqd" Display="Dynamic" ErrorMessage="*"></asp:requiredfieldvalidator></td>
						<td style="white-space: nowrap" >Number of Records Posted</td>
						<td >
							<asp:label id="lblPosted" runat="server"></asp:label></td>
					</tr>
					<tr>
						<td colspan="4">
							<asp:button id="btnSave" runat="server" Text="Save" CssClass="button button2"></asp:button></td>
					</tr>
				</table>
                    </div></div>
			</asp:Panel>
                  
		</form></div>
         <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</html>
