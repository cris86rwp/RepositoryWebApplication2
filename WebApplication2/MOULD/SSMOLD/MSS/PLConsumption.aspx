<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PLConsumption.aspx.vb" Inherits="WebApplication2.PLConsumption" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
		<title>PLConsumption</title>
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
   <%-- <link href="../StyleSheet1.css" rel="stylesheet" />--%>
   
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
          <img src="../../../NewFolder1/CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="45"/>
        </a>
      </li>
     </ul>
      
  </div>
</nav>

         <div class="container">
            <div class="row">
                <div class="table-responsive">

		<form id="Form1" method="post" runat="server">
       <%--         <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
			<asp:panel id="Panel1" runat="server">
				<TABLE id="Table1" class="table">
					<TR>
						<TD vAlign="top" align="middle" colSpan="6"><FONT size="3"><FONT size="5">
									<asp:label id="lblConsignee" runat="server"></asp:label>&nbsp;- <FONT size="3">
											<h2>Consumption Statement</h2><hr class="prettyline" /></FONT></FONT></FONT></TD>
					</TR>
					<TR>
						<TD colSpan="6">
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></TD>
					</TR>
				</TABLE>
				<TABLE id="Table4" class="table">
					<TR>
						<TD>ForTheMonth</TD>
						<TD>:</TD>
						<TD>
							<asp:radiobuttonlist id="rblMonth" CssClass="rbl" runat="server" RepeatLayout="Flow" AutoPostBack="True" RepeatDirection="Horizontal"></asp:radiobuttonlist>
							<asp:radiobuttonlist id="rblYear" CssClass="rbl" runat="server" RepeatLayout="Flow" AutoPostBack="True" RepeatDirection="Horizontal"></asp:radiobuttonlist></TD>
					</TR>
				</TABLE>
				<TABLE id="Table5" class="table">
					<TR>
						<td>PLNumber</td>
						<td>:</td>
						<td>
							<asp:DropDownList id="ddlPLs" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:DropDownList></td>
						<TD>
							<asp:Label id="lblPLDesc" runat="server"></asp:Label></TD>
					</TR>
				</TABLE>
				<TABLE id="Table3" class="table">
					<TR>
						<TD>Unit</TD>
						<TD>WhlsCast</TD>
						<TD>RequestQty</TD>
						<TD>ConsumedQty</TD>
						<TD>EstQty</TD>
						<TD>AccQty</TD>
					</TR>
					<TR>
						<TD>
							<asp:Label id="lblUnit" runat="server" ForeColor="Blue"></asp:Label></TD>
						<TD>
							<asp:Label id="lblWhlsCast" runat="server" ForeColor="Green"></asp:Label></TD>
						<TD>
							<asp:Label id="lblRMRQty" runat="server" ForeColor="Magenta"></asp:Label></TD>
						<TD>
							<asp:Label id="lblRMRCon" runat="server" ForeColor="#0000C0"></asp:Label></TD>
						<TD>
							<asp:Label id="lblEstQty" runat="server" ForeColor="Red"></asp:Label></TD>
						<TD>
							<asp:Label id="lblAccQty" runat="server" ForeColor="#C04000"></asp:Label></TD>
					</TR>
				</TABLE>
				<TABLE id="Table2" class="table">
					<TR>
						<TD>OpeningBal</TD>
						<TD>Receipts</TD>
						<TD>Consumption</TD>
						<TD>ClosingBal</TD>
					</TR>
					<TR>
						<TD>
							<asp:TextBox id="txtOB" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="txtReceipts" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="txtConsumption" runat="server" AutoPostBack="True" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="txtCB" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD align="middle" colSpan="4">
							<asp:Button id="btnSave" runat="server" CssClass="button button2" Text="Save"></asp:Button>
							<asp:Label id="lblConsumDate" runat="server"></asp:Label></TD>
					</TR>
				</TABLE>
				<asp:DataGrid id="DataGrid1" runat="server" CssClass="table" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
			</asp:panel></form>
                    </div></div></div>
	</body>
</html>
