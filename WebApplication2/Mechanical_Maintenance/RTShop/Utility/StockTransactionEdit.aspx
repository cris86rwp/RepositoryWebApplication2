<%@ Page Language="vb" AutoEventWireup="false" Codebehind="StockTransactionEdit.aspx.vb" Inherits="WebApplication2.StockTransactionEdit" Culture="en-GB" uiCulture="en-GB" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>StockTransactionEdit</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR" />
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE" />
		<meta content="JavaScript" name="vs_defaultClientScript" />
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
         <meta charset="utf-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css"/>
  <script  src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js"></script>
        <link type="text/css" rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
        <%--<link rel="stylesheet" href="../../../StyleSheet1.css" />--%>

	</HEAD>
	<body>

		<form id="Form1" method="post" runat="server">
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
<div class="container">

<div class="row">
<div class="table-responsive">
     
                
    
<%--                              <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                             <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                                 <asp:ListItem>select</asp:ListItem>
                                 <asp:ListItem>Theme1</asp:ListItem>
                                 <asp:ListItem>Theme2</asp:ListItem>
                                 <asp:ListItem>Theme3</asp:ListItem>
                             </asp:DropDownList>
                             <br />--%>
			<asp:panel id="pnlMain" runat="server">
				<asp:panel id="pnlPlDesc" runat="server">
					<TABLE id="Table2" class="table">
						<TR>
							<TD style="COLOR: blue; BACKGROUND-COLOR: transparent" vAlign="top" noWrap align="middle" colSpan="3">STOCK 
								TRANSACTION (&nbsp;Edit )&nbsp;for
								<asp:Label id="lblGroup" runat="server" Visible="False"></asp:Label>
								<asp:Label id="lblUserID" runat="server" Visible="False"></asp:Label>
								<asp:Label id="lblConsignee" runat="server"></asp:Label>
								<asp:Label id="lblPLID" runat="server" Visible="False"></asp:Label>
								<asp:Label id="lblTransID" runat="server" Visible="False"></asp:Label></TD>
						</TR>
						<TR>
							<TD vAlign="top" noWrap align="left">TransactionType:
							</TD>
							<TD vAlign="top" noWrap align="middle"><STRONG><FONT color="#0000ff">&nbsp;
										<asp:dropdownlist id="ddlTransType" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></FONT></STRONG></TD>
							<TD vAlign="top" noWrap align="left">&nbsp;
								<asp:label id="lblMessage" runat="server" ForeColor="Red" Font-Bold="True"></asp:label></TD>
						</TR>
					</TABLE>
					<TABLE id="Table8" class="table">
						<TR>
							<TD>PLNumber:</TD>
							<TD>
								<asp:TextBox id="txtPlNumber" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox></TD>
							<TD>BinCardNo :</TD>
							<TD>
								<asp:TextBox id="txtLedgerNo" runat="server" CssClass="form-control"></asp:TextBox></TD>
							<TD>PageNo</TD>
							<TD>
								<asp:TextBox id="txtPageNo" runat="server" CssClass="form-control"></asp:TextBox></TD>
							<TD>Location</TD>
							<TD>
								<asp:DropDownList id="ddlLocation" runat="server" CssClass="form-control ll"></asp:DropDownList></TD>
							<TD>MinBalQty</TD>
							<TD>
								<asp:TextBox id="txtOrderQty" runat="server" CssClass="form-control"></asp:TextBox></TD>
							<TD>Rate</TD>
							<TD>
								<asp:TextBox id="txtRate" runat="server" CssClass="form-control"></asp:TextBox></TD>
						</TR>
						<TR>
							<TD colSpan="10">
								<asp:TextBox id="lblPlDesc" runat="server" BackColor="Silver" CssClass="form-control" ForeColor="#004040" TextMode="MultiLine" Rows="3" ReadOnly="True"></asp:TextBox></TD>
						</TR>
						<TR>
							<TD colSpan="10">Machine :
								<asp:DropDownList id="ddlMachineID" runat="server" CssClass="form-control ll"></asp:DropDownList></TD>
						</TR>
                        </TABLE>
						
									<TABLE id="Table4" class="table">
										<TR>
											<TD>Received Date</TD>
											<TD>
												<asp:label id="lblReceiveType1" runat="server" ForeColor="#C00000"></asp:label></TD>
											<TD>:</TD>
											<TD>
												<asp:textbox id="txtIDNLPNo" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox></TD>
											<TD>Date</TD>
											<TD>:</TD>
											<TD>
												<asp:textbox id="txtIDNLPDate" runat="server" CssClass="form-control"></asp:textbox></TD>
											<TD>RecdQty</TD>
											<TD>Balance</TD>
										</TR>
										<TR>
											<TD>
												<asp:textbox id="txtTransDate" runat="server" CssClass="form-control"></asp:textbox></TD>
											<TD>
												<asp:label id="lblReceiveType2" runat="server"></asp:label></TD>
											<TD>:</TD>
											<TD>
												<asp:textbox id="txtPOChalNoteNo" runat="server" CssClass="form-control"></asp:textbox></TD>
											<TD>
												<asp:Label id="lblDate" runat="server">Date</asp:Label></TD>
											<TD>:</TD>
											<TD>
												<asp:textbox id="txtPOChalNoteDate" runat="server" CssClass="form-control"></asp:textbox></TD>
											<TD>
												<asp:textbox id="txtQty" runat="server" CssClass="form-control"></asp:textbox></TD>
											<TD>
												<asp:TextBox id="txtBalance" runat="server" CssClass="form-control"></asp:TextBox></TD>
										</TR>
										<TR>
											<TD>Remarks</TD>
											<TD colSpan="6">
												<asp:textbox id="txtReceiptRemarks" runat="server" CssClass="form-control"></asp:textbox></TD>
											<TD>
												<asp:label id="lblPlUnit" runat="server"></asp:label></TD>
											<TD>
												<asp:label id="lblPlUnit1" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD vAlign="top" align="middle" colSpan="9">
												<asp:Button id="btnSave" runat="server" CssClass="button button2" Text="Save"></asp:Button></TD>
										</TR>
									</TABLE>
								
					
					<asp:DataGrid id="dgData" runat="server" Height="142px" BackColor="White" CellPadding="4" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966" CssClass="Table">
						<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
						<ItemStyle Font-Size="Smaller" ForeColor="#330099" BackColor="White"></ItemStyle>
						<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
						<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
						<Columns>
							<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
						</Columns>
						<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
					</asp:DataGrid>
				</asp:panel>
			</asp:panel>
			<P></P>
			<P>
			<P></P>
			<P><asp:panel id="pnlIssue1" runat="server"></asp:panel></P>
			<P></P>
			<P>&nbsp;</P>
			<P>&nbsp;</P>
			<P>&nbsp;</P>
			<P>
				<TABLE id="Table1" class="table">
					<TR>
						<TD></TD>
						<TD></TD>
						<TD></TD>
					</TR>
				</TABLE>
			</P>
		</form>
         <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
