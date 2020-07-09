<%@ Page Language="vb" AutoEventWireup="false" Codebehind="machineModified.aspx.vb" Inherits="WebApplication2.machineModified" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>Machine Modified</title>
		<LINK id="mss" href="/wap.css" rel="stylesheet">
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css"/>
  <script  src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js"></script>
         <link type="text/css" rel="stylesheet" href="https://cdn.datatables.net/1.10.9/css/dataTables.bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="https://maxcdn.bootstrapcdn.com" /><a href="MachinesForTop3BdQry.aspx">
    <link type="text/css" rel="stylesheet" href="https://cdn.datatables.net/responsive/1.0.7/css/responsive.bootstrap.min.css" />
    <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.9/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/responsive/1.0.7/js/dataTables.responsive.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.9/js/dataTables.bootstrap.min.js"></script>
    <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
       <%--<link rel="stylesheet" href="../../StyleSheet1.css" />--%>
		
	</HEAD>
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


		<%--<form id="Form1" method="post" runat="server">--%>
			<TABLE id="Table1" class="table">
				<TR>
					<TD align="middle" colSpan="6">Machinery Modifications&nbsp;Entry
						<asp:Label id="lblGroup" runat="server" Visible="False"></asp:Label><hr class="prettyline" /></TD>
				</TR>
				<TR>
					<TD align="right" colSpan="6">Mode :
						<asp:label id="lblMode" runat="server" ForeColor="Red"></asp:label>&nbsp;</TD>
				</TR>
				<TR>
					<TD colSpan="6"><asp:label id="lblMessage" runat="server" ForeColor="Red" Width="329px"></asp:label></TD>
				</TR>
				<TR>
					<TD>Maintenance Group</TD>
					<TD>:</TD>
					<TD style="WIDTH: 310px"><asp:label id="lblMaintenance_group" runat="server"></asp:label><asp:label id="lblUserID" runat="server" Visible="False"></asp:label><asp:label id="lblDept" runat="server" Visible="False"></asp:label></TD>
					<TD style="WIDTH: 105px">Date</TD>
					<TD>:</TD>
					<TD><asp:textbox id="txtDate" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox></TD>
				</TR>
				<TR>
					<TD>Location</TD>
					<TD>:</TD>
					<TD style="WIDTH: 310px"><asp:dropdownlist id="ddlShopCode" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></TD>
					<TD style="WIDTH: 105px">WO&nbsp;NO</TD>
					<TD>:</TD>
					<TD><asp:label id="lblWorkOrderNo" runat="server"></asp:label><asp:dropdownlist id="cboWorkOrderNo" CssClass="form-control ll" runat="server" Width="82px" AutoPostBack="True"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>Machine ID</TD>
					<TD>:</TD>
					<TD style="WIDTH: 310px" colSpan="4"><asp:dropdownlist id="ddlMachineCode" CssClass="form-control ll" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>Sub Assembly</TD>
					<TD>:</TD>
					<TD style="WIDTH: 310px" colSpan="4"><asp:dropdownlist id="ddlAssembly" CssClass="form-control ll" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>Date Attended From</TD>
					<TD>:</TD>
					<TD style="WIDTH: 310px"><asp:textbox id="txtFrom" runat="server" CssClass="form-control" ></asp:textbox><asp:textbox id="txtFrom_time" runat="server" Width="84px"></asp:textbox>&nbsp;(DD/MM/YYYY 
						HH:MM)</TD>
					<TD style="WIDTH: 105px">Date Attended To</TD>
					<TD>:</TD>
					<TD><asp:textbox id="txtTo" runat="server" CssClass="form-control" ></asp:textbox><asp:textbox id="txtTo_time" runat="server" Width="72px"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
						(DD/MM/YYYY HH:MM)</TD>
				</TR>
				<TR>
					<TD>Details of Modification</TD>
					<TD>:</TD>
					<TD style="WIDTH: 310px"><asp:textbox id="txtWork_done" CssClass="form-control" runat="server" TextMode="MultiLine" Height="96px"></asp:textbox></TD>
					<TD style="WIDTH: 105px">Reason</TD>
					<TD>:</TD>
					<TD><asp:textbox id="txtObservation" runat="server" CssClass="form-control" TextMode="MultiLine" ></asp:textbox></TD>
				</TR>
				<TR>
					<TD>Initiated/Attended&nbsp;By</TD>
					<TD>:</TD>
					<TD style="WIDTH: 310px"><asp:textbox id="txtAttendent" CssClass="form-control" runat="server"></asp:textbox>(Seperate 
						by Commas)</TD>
					<TD style="WIDTH: 105px">Approved By</TD>
					<TD>:</TD>
					<TD><asp:textbox id="txtApproved" runat="server" CssClass="form-control"></asp:textbox></TD>
				</TR>
				<TR>
					<TD>Benifits</TD>
					<TD>:</TD>
					<TD style="WIDTH: 310px"><asp:textbox id="txtAdvantages" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:textbox></TD>
					<TD style="WIDTH: 105px">Remarks</TD>
					<TD>:</TD>
					<TD><asp:textbox id="txtRemarks" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD style="WIDTH: 310px">
						<P>Spares List</P>
					</TD>
					<TD style="WIDTH: 105px" colSpan="3">
						<P><asp:dropdownlist id="cboSpares" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></P>
					</TD>
				</TR>
				<TR>
					<TD>Pl No.</TD>
					<TD>:</TD>
					<TD style="WIDTH: 310px"><asp:textbox id="txtPLNumber" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox></TD>
					<TD style="WIDTH: 105px">Quantity</TD>
					<TD>:</TD>
					<TD><asp:textbox id="txtPl_qty" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="middle" colSpan="6"><asp:button id="Button1" runat="server" CssClass="button button2" Text="Add Pl`s" BorderStyle="Groove"></asp:button></TD>
				</TR>
				<TR>
					<TD align="middle" colSpan="6"><asp:datagrid id="grdSpares" runat="server" Width="597px" AlternatingItemStyle-BackColor="#6699cc" HeaderStyle-ForeColor="#cccccc" Height="48px" BorderStyle="None" BackColor="White" BorderColor="#CC9966" BorderWidth="1px" CellPadding="4">
							<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
							<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
							<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
							<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD align="left" colSpan="6"><asp:label id="lblMessage1" runat="server" ForeColor="Red" Width="320px"></asp:label></TD>
				</TR>
				<TR>
					<TD align="middle" colSpan="6"><asp:button id="btnSave" runat="server" CssClass="button button2" Text="Save" BorderStyle="Groove"></asp:button><asp:button id="btnClear" CssClass="button button2" runat="server" Text="Clear" BorderStyle="Groove"></asp:button><asp:button id="btnExit" runat="server" CssClass="button button2" Text="Exit" BorderStyle="Groove"></asp:button></TD>
					</TD></TR>
			</TABLE>
		</form>
              <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
