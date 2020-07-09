<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WaterHardnessData.aspx.vb" Inherits="WebApplication2.WaterHardnessData" Culture="en-GB" uiCulture="en-GB" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>WaterHardnessData</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
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
   <%-- <link rel="stylesheet" href="../../StyleSheet1.css" />--%>

	</HEAD>
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
          <i class="fab glyphicon glyphicon-home " style="font-size:30px;"></i>
        </a></li>
       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out" style="font-size:30px;"></i>
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
             <div class="row">
    
                 <%-- <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
      </div>
            <div class="row">
                <div class="table-responsive">
			<asp:panel id="Panel3" runat="server">
			<TABLE id="Table1" class="table">
				<TR>
					<TD align="middle" colSpan="7"><FONT size="5">Industrial Cooling Water Data</FONT> <hr class="prettyline" /></TD>
				</TR>
				<TR>
					<TD colSpan="7" noWrap width="100%">
						<asp:Label id="lblHelp" runat="server"  CssClass="label"></asp:Label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 222px">Message</TD>
					<TD noWrap colSpan="6"><asp:label id="lblMessage" runat="server" ForeColor="Red" Font-Size="Medium" Font-Bold="True" CssClass="label"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 222px">Shift&nbsp;Date (dd/mm/yyyy)</TD>
					<TD><asp:textbox id="txtShiftDate" runat="server" Width="73px" AutoPostBack="True" CssClass="form-control"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtShiftDate" Display="Dynamic" ErrorMessage="*"></asp:requiredfieldvalidator></TD>
					<TD align="right" colSpan="4">&nbsp; &nbsp; &nbsp; No. of hours Softening Plant 
						worked</TD>
					<TD><asp:textbox id="txtSoftHours" runat="server" Width="73px" CssClass="form-control"></asp:textbox><asp:rangevalidator id="RangeValidator1" runat="server" ControlToValidate="txtSoftHours" Display="Dynamic" ErrorMessage="0  to 24 hrs" Type="Integer" MinimumValue="0" MaximumValue="24"></asp:rangevalidator><asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" ControlToValidate="txtSoftHours" Display="Dynamic" ErrorMessage="*"></asp:requiredfieldvalidator></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 222px">Qty of water added through softner</TD>
					<TD><asp:textbox id="txtTotSoftQty" runat="server" Width="73px" CssClass="form-control"></asp:textbox><asp:rangevalidator id="RangeValidator2" runat="server" ControlToValidate="txtTotSoftQty" Display="Dynamic" ErrorMessage="0  to 1000000  LTRS" Type="Integer" MinimumValue="0" MaximumValue="1000000"></asp:rangevalidator><asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" ControlToValidate="txtTotSoftQty" Display="Dynamic" ErrorMessage="*"></asp:requiredfieldvalidator></TD>
					<TD>Qty of water added bypassing softner</TD>
					<TD>
						<asp:textbox id="txtTotByPassQty" runat="server" Width="73px" CssClass="form-control"></asp:textbox>
						<asp:rangevalidator id="RangeValidator3" runat="server" ErrorMessage="0  to 1000000  LTRS" Display="Dynamic" ControlToValidate="txtTotByPassQty" MaximumValue="1000000" MinimumValue="0" Type="Integer"></asp:rangevalidator>
						<asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="txtTotByPassQty"></asp:requiredfieldvalidator></TD>
					<TD colSpan="2">&nbsp;
						<asp:label id="lblTotwater" runat="server">Total Water added to System:</asp:label>&nbsp;</TD>
					<TD>
						<asp:label id="lblTotQty" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 222px">Data Date Time (24 Hrs)&nbsp;(dd/mm/yyyy 
						hh:mm:ss)</TD>
					<TD colSpan="6">
						<asp:textbox id="txtDataDate" runat="server" Width="137px" AutoPostBack="True" CssClass="form-control"></asp:textbox>
						<asp:customvalidator id="CustomValidator1" runat="server" ErrorMessage="*" Display="Dynamic"></asp:customvalidator>
						<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="txtDataDate"></asp:requiredfieldvalidator>
				</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 222px">Raw Water in PPM</TD>
					<TD><asp:textbox id="txtRawQty" runat="server" Width="73px" CssClass="form-control"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server" ControlToValidate="txtRawQty" Display="Dynamic" ErrorMessage="*"></asp:requiredfieldvalidator>
						<asp:rangevalidator id="RangeValidator4" runat="server" ErrorMessage="0  to 700 " Display="Dynamic" ControlToValidate="txtRawQty" MaximumValue="700" MinimumValue="0" Type="Integer"></asp:rangevalidator></TD>
					<TD>Water after Softening in PPM&nbsp;
					</TD>
					<TD>
						<asp:textbox id="txtSoftQty" runat="server" Width="73px" CssClass="form-control"></asp:textbox>
						<asp:requiredfieldvalidator id="RequiredFieldValidator7" runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="txtSoftQty"></asp:requiredfieldvalidator>
						<asp:rangevalidator id="RangeValidator5" runat="server" ErrorMessage="0  to 700" Display="Dynamic" ControlToValidate="txtSoftQty" MaximumValue="700" MinimumValue="0" Type="Integer"></asp:rangevalidator></TD>
					<TD colSpan="2">Cold Water in PPM</TD>
					<TD>
						<asp:textbox id="txtColdQty" runat="server" Width="73px" CssClass="form-control"></asp:textbox>
						<asp:requiredfieldvalidator id="RequiredFieldValidator8" runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="txtColdQty"></asp:requiredfieldvalidator>
						<asp:rangevalidator id="RangeValidator6" runat="server" ErrorMessage="0  to 1500" Display="Dynamic" ControlToValidate="txtColdQty" MaximumValue="1500" MinimumValue="0" Type="Integer"></asp:rangevalidator></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 222px">Remarks</TD>
					<TD colSpan="6">
						<asp:TextBox id="txtRemarks" runat="server" Width="577px" CssClass="form-control"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD align="middle" colSpan="7">
						<asp:button id="btnSave" runat="server" Text="Save/Update" CssClass="button button2"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:button id="btnDelete" runat="server" Text="Delete" CssClass="button button2"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:button id="btnClearScreen" runat="server" Text="Clear Screen"  CssClass="button button2"></asp:button></TD>
				</TR>
				<TR>
					<TD colSpan="7">
						<asp:datagrid id="dgData" runat="server" BorderColor="White" BorderStyle="Ridge" CellSpacing="1" BorderWidth="2px" BackColor="White" CellPadding="3" GridLines="None">
							<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#9471DE"></SelectedItemStyle>
							<ItemStyle ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
							<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
							<Columns>
								<asp:ButtonColumn Text="Select" HeaderText="Select" CommandName="Select"></asp:ButtonColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Right" ForeColor="Black" BackColor="#C6C3C6"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
            </asp:panel>
                    </div></div>
		</form>
            </div>
         <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
