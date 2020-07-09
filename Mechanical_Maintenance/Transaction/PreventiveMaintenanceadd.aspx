<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PreventiveMaintenanceadd.aspx.vb" Inherits="WebApplication2.PreventiveMaintenanceadd" Culture="en-GB" uiCulture="en-GB" %>

 
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>Preventive Maintenance entry</title>
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
      <%-- <link rel="stylesheet" href="../../StyleSheet1.css" />--%>
	</HEAD>
	<body >
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
<!--/.Navbar -->
        <div class="container">

		<FORM id="Form1" method="post" runat="server">
              <div class="row">
    
                  <%--<h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" >
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
      </div>
           
            <div class="row table-responsive">
			<asp:Panel id="Panel1" style="Z-INDEX: 102; LEFT: 8px;"  runat="server">
                 
				<TABLE id="Table2" class="table">
					<TR>
						<TD >Preventive Maintenance Entry
							<asp:label id="lblGroup" runat="server" Visible="False"></asp:label></TD>
						<TD >Mode :
							<asp:label id="lblMode" runat="server" ForeColor="Red"></asp:label></TD>
					</TR>
				</TABLE>
				<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label>
				<TABLE id="Table3" class="table">
					<TR>
						<TD>Group  :</TD>
					
						<TD>
							<asp:label id="lblMGroup" runat="server"></asp:label></TD>
						<TD>Date  :</TD>
						
						<TD>
							<asp:textbox id="txtDate" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox></TD>
					</TR>
					<TR>
						<TD>Location  :</TD>
					
						<TD>
							<asp:dropdownlist id="ddlShopCode" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></TD>
					</TR>	
                    <TR>
                        <TD>WorkOrderNo  :</TD>
						
						<TD>
							<asp:textbox id="txtWorkOrderNo" runat="server" CssClass="form-control"></asp:textbox></TD>
						<TD>
							<asp:dropdownlist id="cboWorkOrderNo" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></TD>
					</TR>
				</TABLE>
				<TABLE id="Table4" class="table">
					<TR>
						<TD>MachineID  :</TD>
					
						<TD>
							<asp:dropdownlist id="cboMachine" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></TD>
					
						<TD>SubAssembly  :</TD>
						
						<TD>
							<asp:dropdownlist id="cboAssembly" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></TD>
					</TR>
				</TABLE>
				<TABLE id="Table5" class="table">
					<tr>
                        <td>  

                        </td>
					</tr>
						</TABLE>
							<TABLE id="Table6" class="table">
								<TR>
									<TD>DateAttendedFrom</TD>
									<TD>
										<asp:textbox id="txtFrom" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox></TD>
									<TD>
										<asp:textbox id="txtFrom_time" runat="server" CssClass="form-control"></asp:textbox></TD>
									<TD>(DD/MM/YYY HH:MM)</TD>
								</TR>
							</TABLE>
					
							<TABLE id="Table7" class="table">
								<TR>
									<TD>DateAttendedTo</TD>
									<TD>
										<asp:textbox id="txtTo" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox></TD>
									<TD>
										<asp:textbox id="txtTo_time" runat="server" CssClass="form-control"></asp:textbox></TD>
									<TD>
										<P>(DD/MM/YYY HH:MM)</P>
									</TD>
								</TR>
							</TABLE>
					
				
				<TABLE id="Table8" class="table">
					<TR>
						<TD>Details of Work Done  :</TD>
						<TD>
							<asp:textbox id="txtWork_done" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:textbox></TD>
					</TR>
				</TABLE>
				<TABLE id="Table9" class="table">
					<TR>
						<TD>AttendedBy</TD>
						<TD>
							<asp:textbox id="txtAttendent" runat="server" CssClass="form-control"></asp:textbox></TD>
						<TD>( PFNo.s)</TD>
						<TD>Supervisor</TD>
						<TD>
							<asp:textbox id="txtSupervisor" runat="server" CssClass="form-control"></asp:textbox></TD>
					</TR>
				</TABLE>
				<TABLE id="Table10" class="table">
					<TR>
						<TD>Remarks</TD>
						<TD>:</TD>
						<TD>
							<asp:textbox id="txtRemarks" runat="server" CssClass="form-control"></asp:textbox></TD>
					</TR>
				</TABLE>
				<TABLE id="Table12" class="table">
					<TR>
						<TD>CarriedOut</TD>
						<TD>:</TD>
						<TD>
							<asp:radiobuttonlist id="radType" runat="server" CssClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow">
								<asp:ListItem Value="Weekly" Selected="True">Weekly</asp:ListItem>
								<asp:ListItem Value="Monthly"></asp:ListItem>
								<asp:ListItem Value="Quarterly"></asp:ListItem>
								<asp:ListItem Value="Halfyearly"></asp:ListItem>
                                <asp:ListItem Value="Yearly"></asp:ListItem>
                                <asp:ListItem Value="50Hrs"></asp:ListItem>
                                <asp:ListItem Value="250Hrs"></asp:ListItem>
                                <asp:ListItem Value="500Hrs"></asp:ListItem>
                                <asp:ListItem Value="1000Hrs"></asp:ListItem>
                                 <asp:ListItem Value="10000Hrs"></asp:ListItem>
							</asp:radiobuttonlist></TD>
					</TR>
				</TABLE>
				<TABLE id="Table13" class="table">
					<TR>
						<TD>
							<P>SparesList :</P>
						</TD>
						
						<TD>
							<P>
								<asp:dropdownlist id="cboSpares" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></P>
						</TD>
					</TR>
				</TABLE>
				<TABLE id="Table1" class="table">
					<TR>
						<TD style="WIDTH: 137px; HEIGHT: 4px">Pl No.</TD>
						<TD style="HEIGHT: 4px">:</TD>
						<TD style="WIDTH: 281px; HEIGHT: 4px">
							<asp:textbox id="txtPLNumber" runat="server" CssClass="form-control"></asp:textbox></TD>
						<TD style="WIDTH: 95px; HEIGHT: 4px">Quantity</TD>
						<TD style="WIDTH: 3px; HEIGHT: 4px">:</TD>
						<TD style="HEIGHT: 4px">
							<asp:textbox id="txtpl_qty" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 137px; HEIGHT: 4px">SpareType</TD>
						<TD style="HEIGHT: 4px">:</TD>
						<TD style="WIDTH: 281px; HEIGHT: 4px">
							<asp:radiobuttonlist id="rblSpareType" runat="server" CssClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow">
								<asp:ListItem Value="New" Selected="True">New</asp:ListItem>
								<asp:ListItem Value="Serviced">Serviced</asp:ListItem>
							</asp:radiobuttonlist></TD>
						<TD style="WIDTH: 95px; HEIGHT: 4px">CostPerUnit</TD>
						<TD style="WIDTH: 3px; HEIGHT: 4px">:</TD>
						<TD style="HEIGHT: 4px">
							<asp:textbox id="txtSpareCost" runat="server" CssClass="form-control"></asp:textbox></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 21px" align="middle" colSpan="6">
							<asp:label id="lblDept" runat="server" Visible="False"></asp:label>
							<asp:button id="Button1" runat="server" CssClass="button button2" Text="Add Pl`s"></asp:button>
							<asp:label id="lblUserID" runat="server" Visible="False"></asp:label></TD>
					</TR>
				</TABLE>
				<asp:datagrid id="grdSpares" runat="server" Width="591px" AlternatingItemStyle-BackColor="#6699cc" HeaderStyle-ForeColor="#cccccc">
					<AlternatingItemStyle BackColor="#6699CC"></AlternatingItemStyle>
					<HeaderStyle ForeColor="#3366FF"></HeaderStyle>
				</asp:datagrid>
				<asp:Label id="lblMessage1" runat="server" ForeColor="Red"></asp:Label>
				<TABLE id="Table11" class="table">
					<TR>
						<TD>
							<asp:button id="btnSave" runat="server" CssClass="button button2" Text="Save" BorderStyle="Groove"></asp:button></TD>
						<TD>
							<asp:button id="btnClear" runat="server" CssClass="button button2" Text="Clear" BorderStyle="Groove"></asp:button></TD>
						<TD>
							<asp:button id="btnExit" runat="server" CssClass="button button2" Text="Exit" BorderStyle="Groove"></asp:button></TD>
					</TR>
				</TABLE>
			
                     </asp:Panel>&nbsp;
                	</div> </form>
            </div>
         <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>

