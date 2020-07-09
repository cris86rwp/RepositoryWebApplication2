<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ToolRoomReports.aspx.vb" Inherits="WebApplication2.ToolRoomReports" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>ToolRoomReports</title>
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
      <%--<link rel="stylesheet" href="../../../StyleSheet1.css" />--%>
	</HEAD>
	<body MS_POSITIONING="GridLayout" bgColor="#b6dcf5">
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
			<asp:panel id="Panel1" runat="server">
				<TABLE id="Table3" class="table">
					<TR>
						<TD vAlign="top" align="left" colSpan="2">
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="left">
		       <TR>
						<TD colSpan="3">Tool Room Reports&nbsp;<hr class="prettyline" />
							<asp:label id="lblMode" runat="server" ForeColor="Blue" Font-Bold="True" Font-Names="Arial" Font-Size="Smaller" Width="63px"></asp:label></TD>
					</TR>
                            <TR>
									<TD>
										<asp:RadioButtonList id="rblList" CssClass="rbl" runat="server" AutoPostBack="True">
											<asp:ListItem Value="MasterCalibrationPlan" Selected="True">Master Calibration Plan</asp:ListItem>
											<asp:ListItem Value="MasterCalibrationList">Master Calibration List</asp:ListItem>
											<asp:ListItem Value="ToolMaster">Tool Master</asp:ListItem>
											<asp:ListItem Value="DeletedToolMaster">Deleted Tool Master</asp:ListItem>
											<asp:ListItem Value="CalibrationOverDue">Calibration Over Due</asp:ListItem>
											<asp:ListItem Value="LocationWiseTools">Location Wise Tools</asp:ListItem>
										</asp:RadioButtonList></TD>
								</TR>
								<TR>
									<TD align="middle">
										<asp:Button id="btnShow" CssClass="button button2" runat="server"></asp:Button></TD>
								</TR>
							</>
						</TD>
						<TD>
								<TR>
									<TD align="middle">
										
											<TR>
												<TD>FromDate</TD>
												<TD>:</TD>
												<TD>
													<asp:textbox id="txtFromDate" CssClass="form-control" runat="server" Width="150px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD>ToDate</TD>
												<TD>:</TD>
												<TD>
													<asp:textbox id="txtToDate" runat="server" CssClass="form-control" Width="150px"></asp:textbox>
													<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtToDate" Display="Dynamic"></asp:RequiredFieldValidator></TD>
											</TR>
										</TABLE>
										<TABLE id="Table4" class="table">
											<TR>
												<TD>
													<asp:RadioButtonList id="rblQry" runat="server" CssClass="rbl">
														<asp:ListItem Value="1" Selected="True">Receipt</asp:ListItem>
														<asp:ListItem Value="2">Calibration</asp:ListItem>
														<asp:ListItem Value="3">Issue</asp:ListItem>
														<asp:ListItem Value="4">New Tools Introduced</asp:ListItem>
														<asp:ListItem Value="5">Tools Deleted</asp:ListItem>
														<asp:ListItem Value="6">Waiting for Calibration</asp:ListItem>
														<asp:ListItem Value="7">New Tools Introduced but not in use</asp:ListItem>
														<asp:ListItem Value="8">OUTSIDE AGENCY Tools</asp:ListItem>
													</asp:RadioButtonList></TD>
											</TR>
											<TR>
												<TD align="middle">
													<asp:Button id="btnGrid" runat="server" CssClass="button button2" Text="Show Results in Grid"></asp:Button></TD>
											</TR>
											<TR>
												<TD align="middle">
													<asp:Button id="btnExport" runat="server" CssClass="button button2" Text="Export to Excel"></asp:Button></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
						
						</TD>
					</TR>
			
				<asp:DataGrid id="DataGrid1" runat="server" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
			</asp:panel>
		</form>
                 <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
