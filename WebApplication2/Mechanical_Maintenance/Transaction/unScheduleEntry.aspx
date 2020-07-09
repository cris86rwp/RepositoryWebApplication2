<%@ Page Language="vb" AutoEventWireup="false" Codebehind="unScheduleEntry.aspx.vb" Inherits="WebApplication2.unScheduleEntry" Culture="en-GB" uiCulture="en-GB" %>
<!DOCTYPE html PUBLIC "-//W3C//Dtd html 4.0 transitional//EN">
<html>
	<head runat="server">
		<title>unScheduleEntry</title>
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
        <%--<link rel="stylesheet" href="../../StyleSheet1.css" />--%>

	</head>
	<body>
		<form id="Form1" method="post" runat="server">
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

<div class="row">
<div class="table-responsive">
     
                
    
                              <%--<h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                             <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                                 <asp:ListItem>select</asp:ListItem>
                                 <asp:ListItem>Theme1</asp:ListItem>
                                 <asp:ListItem>Theme2</asp:ListItem>
                                 <asp:ListItem>Theme3</asp:ListItem>
                             </asp:DropDownList>
                             <br />--%>
                
			<asp:Panel id="Panel1" runat="server">
				<table id="table2" class="table">
					<tr>
						<td align="middle">Condition Based&nbsp;Maintenance Entry
							<asp:label id="lblGroup" runat="server" Visible="False"></asp:label></td>
						<td align="right">Mode :
							<asp:label id="lblMode" runat="server" ForeColor="Red"></asp:label></td>
					</tr>
				</table>
				<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label>
				<table id="table3" class="table">
					<tr>
						<td>Group</td>
						<td>:</td>
						<td>
							<asp:label id="lblMGroup" runat="server"></asp:label></td>
						<td>Date</td>
						<td>:</td>
						<td>
							<asp:textbox id="txtdate" runat="server" CssClass="form-control" AutoPostBack="true"></asp:textbox></td>
					</tr>
					<tr>
						<td>Location</td>
						<td>:</td>
						<td>
							<asp:dropdownlist id="ddlShopCode" runat="server" AutoPostBack="true" CssClass="form-control ll"></asp:dropdownlist></td>
						<td>WorkOrderNo</td>
						<td>:</td>
						<td>
							<asp:textbox id="txtWorkOrderNo" runat="server" CssClass="form-control"></asp:textbox>
							<asp:dropdownlist id="cboWorkOrderNo" runat="server" CssClass="form-control ll" AutoPostBack="true"></asp:dropdownlist></td>
					</tr>
				</table>
				<table id="table4" class="table">
					<tr>
						<td>MachineID</td>
						<td>:</td>
						<td>
							<asp:dropdownlist id="cboMachine" runat="server" CssClass="form-control ll" AutoPostBack="true"></asp:dropdownlist></td>
					</tr>
					<tr>
						<td>SubAssembly</td>
						<td>:</td>
						<td>
							<asp:dropdownlist id="cboAssembly" runat="server" CssClass="form-control ll" AutoPostBack="true"></asp:dropdownlist></td>
					</tr>
				</table>
				<table id="table5" class="table">
					</table>
							<table id="table6" class="table">
								<tr>
									<td>DateAttendedFrom</td>
									<td>
										<asp:textbox id="txtFrom" runat="server" CssClass="form-control" AutoPostBack="true"></asp:textbox></td>
									<td>
										<asp:textbox id="txtFrom_time" runat="server" CssClass="form-control"></asp:textbox></td>
									<td>(DD/MM/YYY HH:MM)</td>
								</tr>
							</table>
						
							<table id="table7" class="table">
								<tr>
									<td>DateAttendedTo</td>
									<td>
										<asp:textbox id="txtTo" runat="server" CssClass="form-control" AutoPostBack="true"></asp:textbox></td>
									<td>
										<asp:textbox id="txtTo_time" runat="server" CssClass="form-control"></asp:textbox></td>
									<td>
										<P>(DD/MM/YYY HH:MM)</P>
									</td>
								</tr>
							</table>
				
				
				<table id="table8" class="table">
					<tr>
						<td>Details of Work Done</td>
						<td>
							<asp:textbox id="txtWork_done" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:textbox></td>
					</tr>
				</table>
				<table id="table9" class="table">
					<tr>
						<td>AttendedBy</td>
						<td>
							<asp:textbox id="txtAttendent" runat="server" CssClass="form-control"></asp:textbox></td>
						<td>( PFNo.s)</td>
						<td>Supervisor</td>
						<td>
							<asp:textbox id="txtSupervisor" runat="server" CssClass="form-control"></asp:textbox></td>
					</tr>
				</table>
				<table id="table10" class="table">
					<tr>
						<td>Remarks</td>
						<td>:</td>
						<td>
							<asp:textbox id="txtremarks" runat="server" CssClass="form-control"></asp:textbox></td>
					</tr>
				</table>
				<table id="table12" class="table">
					<tr>
						<td>CarriedOut</td>
						<td>:</td>
						<td>
							<asp:radiobuttonlist id="radType" runat="server" CssClass="rbl" Repeatdirection="Horizontal" RepeatLayout="Flow">
								<asp:ListItem Value="Daily" Selected="true">WeekDay</asp:ListItem>
								<asp:ListItem Value="Sunday">Sunday</asp:ListItem>
								<asp:ListItem Value="Annual">Shutdown</asp:ListItem>
								<asp:ListItem Value="Holiday">Holiday</asp:ListItem>
							</asp:radiobuttonlist></td>
					</tr>
				</table>
				<table id="table13" class="table">
					<tr>
						<td>
							<P>SparesList</P>
						</td>
						<td>:</td>
						<td>
							<P>
								<asp:dropdownlist id="cboSpares" runat="server" AutoPostBack="true" CssClass="form-control ll"></asp:dropdownlist></P>
						</td>
					</tr>
				</table>
				<table id="table1" class="table">
					<tr>
						<td>Pl No.</td>
						<td>:</td>
						<td>
							<asp:textbox id="txtPLNumber" runat="server" CssClass="form-control"></asp:textbox></td>
						<td >Quantity</td>
						<td >:</td>
						<td >
							<asp:textbox id="txtpl_qty" runat="server" CssClass="form-control" AutoPostBack="true"></asp:textbox></td>
					</tr>
					<tr>
						<td>SpareType</td>
						<td >:</td>
						<td >
							<asp:radiobuttonlist id="rblSpareType" runat="server" CssClass="rbl" Repeatdirection="Horizontal" RepeatLayout="Flow">
								<asp:ListItem Value="New" Selected="true">New</asp:ListItem>
								<asp:ListItem Value="Serviced">Serviced</asp:ListItem>
							</asp:radiobuttonlist></td>
						<td >CostPerUnit</td>
						<td >:</td>
						<td >
							<asp:textbox id="txtSpareCost" runat="server" CssClass="form-control"></asp:textbox></td>
					</tr>
					<tr>
						<td>
							<asp:label id="lblDept" runat="server" Visible="False"></asp:label>
							<asp:button id="Button1" runat="server" Text="Add Pl`s" CssClass="button button2"></asp:button>
							<asp:label id="lblUserID" runat="server" Visible="False"></asp:label></td>
					</tr>
				</table>
				<asp:datagrid id="grdSpares" runat="server" AlternatingItemStyle-BackColor="#6699cc" headerStyle-ForeColor="#cccccc" CssClass="Table">
					<AlternatingItemStyle BackColor="#6699CC"></AlternatingItemStyle>
					<headerStyle ForeColor="#3366FF"></headerStyle>
				</asp:datagrid>
				<asp:Label id="lblMessage1" runat="server" ForeColor="Red"></asp:Label>
				<table id="table11" class="table">
					<tr>
						<td>
							<asp:button id="btnSave" runat="server" CssClass="button button2" Text="Save" BorderStyle="Groove"></asp:button></td>
						<td>
							<asp:button id="btnClear" runat="server" CssClass="button button2" Text="Clear" BorderStyle="Groove"></asp:button></td>
						<td>
							<asp:button id="btnExit" runat="server" CssClass="button button2" Text="Exit" BorderStyle="Groove"></asp:button></td>
					</tr>
				</table>
			</asp:Panel>&nbsp;
    </div>
    </div>
    </div>
    </form>
          <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</html>
