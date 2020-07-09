<%@ Page Language="vb" AutoEventWireup="false" Codebehind="YardInspectionMagna.aspx.vb" Inherits="WebApplication2.YardInspectionMagna" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>YardInspectionMagna</title>
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
      <%-- <link rel="stylesheet" href="../../../StyleSheet1.css" />--%>

	</HEAD>
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
    
                 <%-- <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>--%>
            
             <%--    <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>--%>
                 <br />
      </div>
            <div class="row"><div class="table-responsive">
			<asp:panel id="Panel1"  runat="server">
				<TABLE id="Table1" class="table">
					<TR>
						<TD align="middle"><STRONG><FONT size="4">JIC &nbsp;&nbsp;Yard&nbsp;Inspection Magna &nbsp;Details</FONT></STRONG><hr class="prettyline" /></TD>
					</TR>
					<TR>
						<TD align="right"><STRONG>Mode:
								<asp:label id="lblMode" runat="server" ForeColor="Red"></asp:label></STRONG></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></TD>
					</TR>
				</TABLE>
				<TABLE id="Table2" class="table">
					<TR>
						<TD noWrap>Date</TD>
						<TD noWrap>&nbsp;
							<asp:textbox id="txtDate" runat="server" CssClass="form-control" MaxLength="10" AutoPostBack="True"></asp:textbox>
							<asp:requiredfieldvalidator id="rfvDate" runat="server" ControlToValidate="txtDate">*</asp:requiredfieldvalidator></TD>
						<TD noWrap>Shift:&nbsp;</TD>
						<TD noWrap>&nbsp;
							<asp:label id="lblShift" runat="server">G</asp:label>&nbsp;&nbsp;
						</TD>
						<TD noWrap>Lab Inspector&nbsp;
							<asp:label id="lblLabAuthority" runat="server"></asp:label></TD>
						<TD noWrap colSpan="2">&nbsp; &nbsp;Tech Inspector
						</TD>
						<TD noWrap>&nbsp;
							<asp:textbox id="txtTechnicalAuthority" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox>
							<asp:requiredfieldvalidator id="rfvTechInsp" runat="server" ControlToValidate="txtTechnicalAuthority">*</asp:requiredfieldvalidator></TD>
					</TR>
                    <tr>
                        <td>SSE/MR</td>
                        <td><asp:TextBox ID="txtmr" runat="server"></asp:TextBox></td>
                        <td>SSE/SMS</td>
                        <td><asp:TextBox ID="txtsms" runat="server"></asp:TextBox></td>
                        <td>SSE/WFPS</td>
                        <td><asp:TextBox ID="txtwfps" runat="server"></asp:TextBox></td>
                        <td>Authority Technical</td>
                        <td><asp:TextBox ID="txtautech" runat="server"></asp:TextBox></td>
                    </tr>
				</TABLE>
				<TABLE id="Table3" class="table">
					<TR>
						<TD >WheelNumber</TD>
						<TD>
							<asp:textbox id="txtWheelNumber" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox>
							<asp:requiredfieldvalidator id="rfvWhlNum" runat="server" ControlToValidate="txtWheelNumber">*</asp:requiredfieldvalidator></TD>
						<TD>HeatNumber</TD>
						<TD>
							<asp:textbox id="txtHeatNumber" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox>
							<asp:requiredfieldvalidator id="rfvHtNum" runat="server" ControlToValidate="txtHeatNumber">*</asp:requiredfieldvalidator></TD>
						<TD>
							<asp:label id="lblStatus" runat="server" ForeColor="Red" ></asp:label></TD>
						<TD>
							<asp:label id="lblLoca" runat="server" ForeColor="Red" ></asp:label></TD>
					</TR>
					<TR>
						<TD >Last Rej(XC)Status</TD>
						<TD>
							<asp:textbox id="txtWheelDisposition" runat="server" CssClass="form-control" AutoPostBack="True" ToolTip="if XC enter with code"></asp:textbox></TD>
						<TD>
							<asp:checkbox id="chkReMachine" runat="server" AutoPostBack="True" Font-Bold="True" Text="ReMachine"></asp:checkbox></TD>
						<TD>BHN
							<asp:textbox id="txtBHN" runat="server" CssClass="form-control" MaxLength="3" AutoPostBack="True" ToolTip="Good BHN only if empty"></asp:textbox></TD>
						<TD>Yard No</TD>
						<TD>
							<asp:textbox id="txtBdNo" runat="server" CssClass="form-control" MaxLength="2" AutoPostBack="True" ToolTip="Yard Line Board No. where wheel is kept while inspecting"></asp:textbox></TD>
					</TR>
					<TR>
						<TD >TreadDia (mm)</TD>
						<TD>
							<asp:textbox id="txtTreadDiameter" runat="server" CssClass="form-control" AutoPostBack="True">0</asp:textbox></TD>
						<TD>BoreStatus</TD>
						<TD>
							<asp:textbox id="txtBorestatus" runat="server" CssClass="form-control" AutoPostBack="True" ToolTip="U=Unbore else Bore ">OK</asp:textbox></TD>
						<TD>PlateTickness</TD>
						<TD>
							<asp:textbox id="txtPlateThickness" runat="server" CssClass="form-control" AutoPostBack="True">OK</asp:textbox></TD>
					</TR>
					<TR>
						<TD  colSpan="6">
							<asp:checkbox id="chkAllowStockWheel" runat="server" Width="198px" AutoPostBack="True" Font-Bold="True" Text="Allow Stock Wheel"></asp:checkbox></TD>
					</TR>
                    <tr>
                        <td>JIC Status</td>
                        <td><asp:TextBox ID="txtjicstatus" runat="server"></asp:TextBox></td>
                        <td>JIC Remark</td>
                        <td><asp:TextBox ID="txtjicremark" runat="server"></asp:TextBox></td>
                    </tr>
					<TR>
						<TD ></TD>
						<TD>
							<asp:button id="btnSave" runat="server" CssClass="button button2" ></asp:button></TD>
						<TD>
							<asp:button id="btnClear" runat="server" CssClass="button button2" Text="Clear"  CausesValidation="False"></asp:button></TD>
						<TD>
							<asp:button id="btnDelete" runat="server" CssClass="button button2" Text="Delete"></asp:button></TD>
						<TD>
							<asp:button id="btnExit" runat="server" CssClass="button button2" Text="Exit"  CausesValidation="False"></asp:button></TD>
						<TD></TD>
					</TR>
				</TABLE>
				<asp:DataGrid id="grdYard" runat="server" BorderColor="#CC9966" CssClass="table" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
			</asp:panel></div></div></form></div>
         <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
