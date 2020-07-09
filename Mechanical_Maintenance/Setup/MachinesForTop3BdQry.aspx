<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MachinesForTop3BdQry.aspx.vb" Inherits="WebApplication2.MachinesForTop3BdQry" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>MachinesForTop3BdQry</title>
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
		<form id="Form2" method="post" runat="server">
             <div class="row">
    
                 <%-- <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
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
                    <asp:panel id="Panel1" runat="server">
			<TABLE id="Table5" class="table">
				<TR>
					<TD align="middle" colSpan="2"><STRONG><FONT color="#3333ff" size="4">Query Table Updation 
								for Critical Machine Breakdown query</FONT><hr class="prettyline" /></STRONG></TD>
				</TR>
				<TR>
					<TD colSpan="2"><asp:label id="lblMessage" runat="server" Width="487px" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:label></TD>
				</TR>
				<TR>
					<TD>
						
							<TR>
								<TD noWrap align="middle">
									<asp:label id="Label1" runat="server">Search String</asp:label>
									<asp:textbox id="txtSearchString" CssClass="form-control" runat="server"></asp:textbox></TD>
							</TR>
							<TR>
								<TD noWrap align="middle">
									<asp:checkbox id="chkSel" CssClass="checkbox" runat="server" Text="Selected"></asp:checkbox></TD>
							</TR>
							<TR>
								<TD noWrap align="middle">
									<asp:button id="btnFilter" runat="server" CssClass="button button2" BorderStyle="Groove" Text="Filter"></asp:button></TD>
							</TR>
							<TR>
								<TD noWrap align="middle"><STRONG>List of Machines In Query Table</STRONG></TD>
							</TR>
							<TR>
								<TD noWrap align="middle">
									<asp:listbox id="lstMachines" runat="server" SelectionMode="Multiple" CssClass="ll" Width="300px"></asp:listbox></TD>
							</TR>
							<TR>
								<TD noWrap align="middle">
									<asp:CheckBox id="chkRemove" runat="server" CssClass="checkbox" Text="Remove from Selected List"></asp:CheckBox></TD>
							</TR>
							<TR>
								<TD noWrap align="middle">
									<asp:button id="btnSave" runat="server" CssClass="button button2" BorderStyle="Groove" Text="Save"></asp:button></TD>
							</TR>
							<TR>
								<TD noWrap align="middle">
									<asp:Label id="lblNoOfMcnsInQueryTable" runat="server"></asp:Label></TD>
							</TR>
						
					</TD>
					<TD>
						
							<TR>
								<TD align="middle" colSpan="3"><STRONG>Help</STRONG></TD>
							</TR>
							<TR>
								<TD vAlign="top">1</TD>
								<TD vAlign="top">:</TD>
								<TD>Input Starting characters of machine code in Search String box to search 
									marching machines.</TD>
							</TR>
							<TR>
								<TD vAlign="top">2</TD>
								<TD vAlign="top">:</TD>
								<TD>Check mark 'Selected' and click 'Filter' to show machines in Query Table.</TD>
							</TR>
							<TR>
								<TD vAlign="top">3</TD>
								<TD vAlign="top">:</TD>
								<TD>Remove check mark 'Selected' and click 'Filter' to show machines in Machinery 
									Master.</TD>
							</TR>
							<TR>
								<TD vAlign="top">4</TD>
								<TD vAlign="top">:</TD>
								<TD>Select machines in the 'List of Machines'
									
										<TR>
											<TD>-</TD>
											<TD colSpan="2">hold ctrl key and click to select/un-select randomly
											</TD>
										</TR>
										<TR>
											<TD>-</TD>
											<TD colSpan="2">hold&nbsp; shift key after clicking first machine and then click 
												last item to select/un-select serially.</TD>
										</TR>
									
								</TD>
							</TR>
							<TR>
								<TD vAlign="top">5</TD>
								<TD vAlign="top">:</TD>
								<TD>Check Mark 'Remove From Selected List' to delete&nbsp;machine from Query Table.</TD>
							</TR>
							<TR>
								<TD vAlign="top">6</TD>
								<TD vAlign="top">:</TD>
								<TD>Click 'Save' to save.&nbsp;
									
										<TR>
											<TD>-</TD>
											<TD colSpan="2">Machines are added to Query Table&nbsp;as Selected if not already 
												exist in Query Table.&nbsp;</TD>
										</TR>
										<TR>
											<TD>-</TD>
											<TD colSpan="2">Machines are updated as Selected if 'Selected' is check marked.</TD>
										</TR>
										<TR>
											<TD>-</TD>
											<TD colSpan="2">Machines are updated as not Selected if 'Selected' is not check 
												marked.</TD>
										</TR>
									
								</TD>
							</TR>
					
					</TD>
				</TR>
			</TABLE>
		</asp:panel></form>
               <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
