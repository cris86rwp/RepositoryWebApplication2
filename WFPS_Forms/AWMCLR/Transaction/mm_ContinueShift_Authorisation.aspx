<%@ Page Language="vb" AutoEventWireup="false" Codebehind="mm_ContinueShift_Authorisation.aspx.vb" Inherits="WebApplication2.mm_ContinueShift_Authorisation" Culture="en-GB" uiCulture="en-GB" %>
<!DOCTYPE HTML PUBLIC "-//W3C//Dtd HTML 4.0 transitional//EN">
<html>
	<head runat="server">
		<title>mm_ContinueShift_Authorisation</title>
		<LINK href="../../MailStyles.css" rel="stylesheet"/>
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
              <div class="row">
                <div class="table-responsive">

			<table id="table1" class="table">
                <%--style="Z-INDEX: 101; LEFT: 8px; WIDTH: 752px; POSITION: absolute; TOP: 8px; HEIGHT: 176px" cellSpacing="1" cellPadding="1" width="752" border="1"--%>
				<tr>
					<td align="middle" colspan="4"><StrONG><FONT size="4">Authorisation for Continuing Shift to 
								meet Production Exegencies</FONT></StrONG>
                        <hr class="prettyline" />
					</td>
				</tr>
				<tr>
					<td align="right" colspan="3">&nbsp;</td>
					<td align="right">
						<asp:label id="lblMode" runat="server"></asp:label></td>
				</tr>
				<tr>
					<td noWrap colspan="4" rowspan="1"><asp:label id="lblMessage" runat="server" Font-Bold="true" ForeColor="Red" Font-Size="Medium"></asp:label></td>
				</tr>
				<tr>
					<td noWrap colspan="4">
						<asp:table id="aspTbl" runat="server"></asp:table></td>
				</tr>
				<tr>
					<td colspan="4"><asp:checkbox id="chkHelp" runat="server" Text="Help" AutoPostBack="true"></asp:checkbox></td>
				</tr>
				<tr>
					<td noWrap colspan="4"><asp:label id="lblHelp" runat="server" Font-Underline="true"></asp:label></td>
				</tr>
				<tr>
					<td noWrap>Employee Code</td>
					<td><asp:label id="lblEmpCode" runat="server"></asp:label></td>
					<td>Product</td>
					<td><asp:label id="lblProduct" runat="server"></asp:label></td>
				</tr>
				<tr>
					<td><asp:label id="lblDateType" runat="server">Inspection Date</asp:label></td>
					<td><asp:label id="lblInspDate" runat="server"></asp:label></td>
					<td noWrap>Shift</td>
					<td><asp:label id="lblInspShift" runat="server"></asp:label></td>
				</tr>
				<tr>
					<td noWrap><asp:checkbox id="chkQtyToBePosted" runat="server" Text="Number of Records to be posted" AutoPostBack="true"></asp:checkbox></td>
					<td><asp:textbox id="txtQtyReqd" runat="server" AutoPostBack="true" CssClass="form-control"></asp:textbox><asp:requiredfieldvalidator id="rfvQty" runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="txtQtyReqd"></asp:requiredfieldvalidator></td>
					<td noWrap>Number of Records Posted</td>
					<td><asp:label id="lblPosted" runat="server"></asp:label></td>
				</tr>
				<tr>
					<td align="middle" colspan="4"><asp:button id="btnSave" runat="server" Text="Save" CssClass="button button2"></asp:button></td>
				</tr>
				<tr>
					<td align="left" colSpan="4"><asp:datagrid id="dgData" runat="server"  BackColor="White" CellPadding="4" CssClass="table">
                        <%--BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px"--%>
							<SelectedItemStyle Font-Bold="true" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
							<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Bold="true" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
							<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
							<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
						</asp:datagrid></td>
				</tr>
			</table>
                    </div></div>
		</form></div>
        <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</html>
