<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PLNumersforBreakDownMemo.aspx.vb" Inherits="WebApplication2.PLNumersforBreakDownMemo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>PLNumersforBreakDownMemo</title>
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
       <%--<link rel="stylesheet" href="StyleSheet1.css" />--%>
	
    </HEAD>
	<body MS_POSITIONING="GridLayout" bgColor="#99ccff">
	
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
		<form id="Form2" method="post" runat="server">
             <div class="row">
    
                  <%--<h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 </br>--%>
      </div>
            
             <div class="row">
                <div class="table-responsive">

        
       <%-- <form id="Form1" method="post" runat="server">--%>
			<TABLE id="Table2" class="table">
				<TR>
					<TD align="middle" colSpan="6" style="HEIGHT: 21px"><FONT size="5">BreakDownMemo 
							(Maintenance)(To add PL Numbers even after closing B/D Memo)</FONT><hr class="prettyline" /></TD>
				</TR>
				<TR>
					<TD align="right" colSpan="6" style="HEIGHT: 5px"><asp:label id="lblUserID" runat="server"></asp:label><asp:label id="lblGroup" runat="server"></asp:label><asp:label id="lblMode" runat="server" ForeColor="Blue">Edit</asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="6" style="HEIGHT: 2px"><asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 157px; HEIGHT: 5px">Department</TD>
					<TD style="HEIGHT: 5px">:</TD>
					<TD style="WIDTH: 278px; HEIGHT: 5px"><asp:label id="lblDepartment_code" runat="server" Width="40px">M</asp:label></TD>
					<TD style="WIDTH: 150px; HEIGHT: 5px">Date of BreakDown</TD>
					<TD style="HEIGHT: 5px">:</TD>
					<TD style="HEIGHT: 5px"><asp:textbox id="txtDate" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 157px; HEIGHT: 7px">Group</TD>
					<TD style="HEIGHT: 7px">:</TD>
					<TD style="WIDTH: 278px; HEIGHT: 7px"><asp:label id="lblMaintenance_group" runat="server"></asp:label></TD>
					<TD style="WIDTH: 150px; HEIGHT: 7px">Type of Failure</TD>
					<TD style="HEIGHT: 7px">:</TD>
					<TD style="HEIGHT: 7px"><asp:dropdownlist id="ddlBDtype" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 157px; HEIGHT: 11px">Machine&nbsp;Code</TD>
					<TD style="HEIGHT: 11px">:</TD>
					<TD style="WIDTH: 278px; HEIGHT: 11px"><asp:label id="lblMachineCode" runat="server"></asp:label></TD>
					<TD style="WIDTH: 150px; HEIGHT: 11px">Shop&nbsp;Code</TD>
					<TD style="HEIGHT: 11px">:</TD>
					<TD style="HEIGHT: 11px"><asp:dropdownlist id="ddlShopCode" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 157px; HEIGHT: 27px">Operator</TD>
					<TD style="HEIGHT: 27px"></TD>
					<TD style="WIDTH: 278px; HEIGHT: 27px"><asp:textbox id="txtOperator" runat="server" CssClass="form-control" ></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" Display="Dynamic" ErrorMessage="*" ControlToValidate="txtOperator"></asp:requiredfieldvalidator></TD>
					<TD style="WIDTH: 150px; HEIGHT: 27px">Breakdown Memo No.</TD>
					<TD style="HEIGHT: 27px">:</TD>
					<TD style="HEIGHT: 27px"><asp:dropdownlist id="cboMemoNumber" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 157px; HEIGHT: 1px">Break Down Details:</TD>
					<TD style="HEIGHT: 1px"></TD>
					<TD align="left" width="100" colSpan="4" style="HEIGHT: 1px"></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 157px; HEIGHT: 7px">Failure Code</TD>
					<TD style="HEIGHT: 7px"></TD>
					<TD style="WIDTH: 278px; HEIGHT: 7px"><asp:label id="lblBreakDownDetail" runat="server"></asp:label></TD>
					<TD style="WIDTH: 150px; HEIGHT: 7px">Desc. of Break Down</TD>
					<TD style="HEIGHT: 7px"></TD>
					<TD style="HEIGHT: 7px"><asp:label id="lblDesc" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 157px; HEIGHT: 2px">From Date</TD>
					<TD style="HEIGHT: 2px"></TD>
					<TD style="WIDTH: 278px; HEIGHT: 2px"><asp:textbox id="txtBDnFromDate" CssClass="form-control" runat="server" Enabled="False" MaxLength="10"></asp:textbox>(dd/mm/yy)</TD>
					<TD style="WIDTH: 150px; HEIGHT: 2px">To Date</TD>
					<TD style="HEIGHT: 2px"></TD>
					<TD style="HEIGHT: 2px"><asp:textbox id="txtBDnToDate" runat="server" CssClass="form-control" Enabled="False" MaxLength="10"></asp:textbox>(dd/mm/yy)</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 157px; HEIGHT: 2px">Time</TD>
					<TD style="HEIGHT: 2px"></TD>
					<TD style="WIDTH: 278px; HEIGHT: 2px"><asp:textbox id="txtBDnFromTime" runat="server" CssClass="form-control" Enabled="False" MaxLength="10"></asp:textbox>(hh:mm)</TD>
					<TD style="WIDTH: 150px; HEIGHT: 2px">Time</TD>
					<TD style="HEIGHT: 2px"></TD>
					<TD style="HEIGHT: 2px"><asp:textbox id="txtBDnToTime" runat="server" CssClass="form-control" Enabled="False" MaxLength="10"></asp:textbox>(hh:mm 
						)</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 157px; HEIGHT: 8px">Total Time loss :
					</TD>
					<TD style="HEIGHT: 8px"></TD>
					<TD style="WIDTH: 278px; HEIGHT: 8px"><asp:label id="lblTotal_time" runat="server"></asp:label></TD>
					<TD style="WIDTH: 150px; HEIGHT: 8px">Staff Attended (Maint.)</TD>
					<TD style="HEIGHT: 8px">:</TD>
					<TD style="HEIGHT: 8px"><asp:textbox id="txtStaff" CssClass="form-control" runat="server" ></asp:textbox>PF 
						No.s seperated by commas</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 5px" align="left" width="100" colSpan="6"><asp:label id="lblMessage2" runat="server" ForeColor="Red"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 157px; HEIGHT: 8px">Nature&nbsp;of Failure</TD>
					<TD style="HEIGHT: 8px">:</TD>
					<TD style="WIDTH: 278px; HEIGHT: 8px"><asp:dropdownlist id="cboFaliure" CssClass="form-control ll" runat="server" Visible="False"></asp:dropdownlist><asp:label id="lblFailureNature" runat="server" Width="112px"></asp:label></TD>
					<TD style="WIDTH: 150px; HEIGHT: 8px">Sub Assembly</TD>
					<TD style="HEIGHT: 8px">:</TD>
					<TD style="HEIGHT: 8px"><asp:dropdownlist id="ddlSubAssembly" runat="server" CssClass="form-control ll" Visible="False"></asp:dropdownlist><asp:label id="lblSubAssembly" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 157px; HEIGHT: 12px">Details of Work Done</TD>
					<TD style="HEIGHT: 12px">:</TD>
					<TD style="WIDTH: 278px; HEIGHT: 12px"><asp:textbox id="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:textbox></TD>
					<TD style="WIDTH: 150px; HEIGHT: 12px">
						<P>Spares List</P>
					</TD>
					<TD style="HEIGHT: 12px">:</TD>
					<TD style="HEIGHT: 12px"><asp:dropdownlist id="cboSpares" runat="server" CssClass="form-control ll" AutoPostBack="True" Visible="False"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 157px; HEIGHT: 1px">
						<P>PL Numbers</P>
					</TD>
					<TD style="HEIGHT: 1px"></TD>
					<TD style="WIDTH: 278px; HEIGHT: 1px"><asp:textbox id="txtPLNumber" runat="server" CssClass="form-control" ></asp:textbox></TD>
					<TD style="WIDTH: 150px; HEIGHT: 1px">Quantity Consumed</TD>
					<TD style="HEIGHT: 1px"></TD>
					<TD style="HEIGHT: 1px"><asp:textbox id="txtpl_qty" runat="server" CssClass="form-control" ></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="middle" colSpan="6" style="HEIGHT: 3px"><asp:button id="btnPls" runat="server" CssClass="button button2" BorderStyle="Groove" Text="Add Pl`s"></asp:button></TD>
				</TR>
				<TR>
					<TD align="left" colSpan="6" style="HEIGHT: 24px" vAlign="top">
						<asp:DataGrid id="grdSpares" runat="server" BorderStyle="None" BorderColor="#CC9966" BorderWidth="1px" BackColor="White" CellPadding="4">
							<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
							<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
							<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
							<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
						</asp:DataGrid></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 16px" align="middle" colSpan="6">
						<asp:button id="btnSave" CssClass="button button2" runat="server" Text="Save" BorderStyle="Groove" Font-Names="Arial" Font-Size="Smaller"></asp:button>
						<asp:button id="btnClear" runat="server" CssClass="button button2" Text="Clear" BorderStyle="Groove" Font-Names="Arial" Font-Size="Smaller" CausesValidation="False"></asp:button>
						<asp:button id="btnExit" runat="server" CssClass="button button2" Text="Exit" BorderStyle="Groove" Font-Names="Arial" Font-Size="Smaller" CausesValidation="False"></asp:button></TD>
				</TR>
			</TABLE>
		</form>
              <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
