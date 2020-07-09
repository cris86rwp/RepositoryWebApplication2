<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ms_Monthly_Energy_Consumption.aspx.vb" Inherits="WebApplication2.ms_MonthlyEnergyConsumptionReport" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>Monthly Energy Consumption Report</title> 
		<%--<LINK href="/wap.css" rel="stylesheet">--%>
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
       <%-- <link rel="stylesheet" href="StyleSheet1.css" />--%>
	</HEAD>
	<body bgColor="#b6dcf5" MS_POSITIONING="GridLayout">
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
        <hr class="prettyline" />
			<div class="container">
		<form id="Form2" method="post" runat="server">
             <div class="row">
    
                  <%--<h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" CssClass="form-control ll" OnSelectedIndexChanged="dd1_SelectedIndexChanged"  Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
      </div>
            <div class="table-responsive">
                <asp:Panel id="Panel1" runat="server">
			<TABLE id="Table" class="table">
				<TR>
					<TD align="middle" colSpan="6">Monthly Energy Consumption Report</TD>
				</TR>
				<TR>
					<TD colSpan="6">
						<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></TD>
				</TR>
				<TR>
					<TD>Key in From Date</TD>
					<TD>:</TD>
					<TD>
						<asp:textbox id="txtFromDate" runat="server" CssClass="form-control"></asp:textbox>
						<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtFromDate"></asp:requiredfieldvalidator>
						<asp:rangevalidator id="RangeValidator1" runat="server" ErrorMessage="Invalid Date" ControlToValidate="txtFromDate" Type="Date" MinimumValue="1/1/1990" MaximumValue="1/1/9999"></asp:rangevalidator></TD>
					<TD>Key in To Date</TD>
					<TD>:</TD>
					<TD>
						<asp:textbox id="txtToDate" runat="server" CssClass="form-control"></asp:textbox>
						<asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" ErrorMessage="*" ControlToValidate="txtToDate"></asp:requiredfieldvalidator>
						<asp:rangevalidator id="Rangevalidator2" runat="server" ErrorMessage="Invalid Date" ControlToValidate="txtToDate" Type="Date" MinimumValue="1/1/1990" MaximumValue="1/1/9999"></asp:rangevalidator></TD>
				</TR>
				<TR>
					<TD>Year Beginning Date</TD>
					<TD>:</TD>
					<TD>
						<asp:textbox id="txtBeginDate" runat="server" CssClass="form-control"></asp:textbox>
						<asp:requiredfieldvalidator id="Requiredfieldvalidator3" runat="server" ErrorMessage="*" ControlToValidate="txtBeginDate"></asp:requiredfieldvalidator>
						<asp:rangevalidator id="Rangevalidator3" runat="server" ErrorMessage="Invalid Date" ControlToValidate="txtBeginDate" Type="Date" MinimumValue="1/1/1990" MaximumValue="1/1/9999"></asp:rangevalidator></TD>
					<TD>Date End of Period</TD>
					<TD>:</TD>
					<TD>
						<asp:textbox id="txtEndDate" runat="server" CssClass="form-control"></asp:textbox>
						<asp:requiredfieldvalidator id="Requiredfieldvalidator4" runat="server" ErrorMessage="*" ControlToValidate="txtEndDate"></asp:requiredfieldvalidator>
						<asp:rangevalidator id="Rangevalidator4" runat="server" ErrorMessage="Invalid Date" ControlToValidate="txtEndDate" Type="Date" MinimumValue="1/1/1990" MaximumValue="1/1/9999"></asp:rangevalidator></TD>
				</TR>
				<TR>
					<TD>No. of wheelsets despatched for the Month</TD>
					<TD>:</TD>
					<TD>
						<asp:textbox id="txtWheelsMonth" runat="server" CssClass="form-control"></asp:textbox>
						<asp:requiredfieldvalidator id="Requiredfieldvalidator5" runat="server" ErrorMessage="*" ControlToValidate="txtWheelsMonth"></asp:requiredfieldvalidator></TD>
					<TD>No. of wheels cast</TD>
					<TD>:</TD>
					<TD>
						<asp:textbox id="txtWheelsCast" runat="server" CssClass="form-control"></asp:textbox>
						<asp:requiredfieldvalidator id="Requiredfieldvalidator6" runat="server" ErrorMessage="*" ControlToValidate="txtWheelsCast"></asp:requiredfieldvalidator></TD>
				</TR>
				<TR>
					<TD>No. of axles forged</TD>
					<TD></TD>
					<TD>
						<asp:textbox id="txtAxlesForged" runat="server" CssClass="form-control"></asp:textbox>
						<asp:requiredfieldvalidator id="Requiredfieldvalidator7" runat="server" ErrorMessage="*" ControlToValidate="txtAxlesForged"></asp:requiredfieldvalidator></TD>
					<TD>Total wheelsets despatched for the year</TD>
					<TD></TD>
					<TD>
						<asp:textbox id="txtWheelsYear" runat="server" CssClass="form-control"></asp:textbox>
						<asp:requiredfieldvalidator id="Requiredfieldvalidator8" runat="server" ErrorMessage="*" ControlToValidate="txtWheelsYear"></asp:requiredfieldvalidator></TD>
				</TR>
				<TR>
					<TD align="middle" colSpan="6">
						<asp:button id="btnSave" runat="server" CssClass="button button2" BorderStyle="Groove" Text="Generate Report"></asp:button>&nbsp;
						<asp:button id="Button1" runat="server" CssClass="button button2" BorderStyle="Groove" Text="Show Report" CausesValidation="False"></asp:button></TD>
				</TR>
			</TABLE> </asp:Panel>
		</form>
                 <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
