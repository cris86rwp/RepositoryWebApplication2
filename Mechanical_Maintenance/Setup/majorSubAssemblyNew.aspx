<%@ Page Language="vb" AutoEventWireup="false" Codebehind="majorSubAssemblyNew.aspx.vb" Inherits="WebApplication2.majorSubAssemblyNew" Culture="en-GB" uiCulture="en-GB" %> %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>majorSubAssemblyNew</title>
			<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">

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
       <%--<link rel="stylesheet" href="../../StyleSheet1.css" />--%>
	</HEAD>
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
			<TABLE id="Table2" class="table">
				<TR>
					<TD vAlign="top" align="middle"><STRONG><FONT size="4">Major Sub Assembly</FONT><hr class="prettyline" />

					                                </STRONG></TD>
				</TR>
				<TR>
					<TD><asp:label id="lblMessage" runat="server" ForeColor="Red" Width="611px"></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:panel id="pnlLocation" runat="server" Width="275px" Height="101px">
							
								<TR>
									<TD>Group</TD>
									<TD colSpan="2">
										<asp:label id="lblMaintenance_group" runat="server"></asp:label>
										<asp:Label id="lblGrp" runat="server" Visible="False"></asp:Label>
										<asp:Label id="lblUserID" runat="server" Visible="False"></asp:Label></TD>
								</TR>
								<TR>
									<TD>Location</TD>
									<TD colSpan="2">
										<asp:dropdownlist id="ddlLocation" runat="server" CssClass="form-control ll" Width="152px" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD>Machine Group</TD>
									<TD colSpan="2">
										<asp:dropdownlist id="ddlMachineGroup" CssClass="form-control ll" runat="server" Width="278px"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD>SubAssembly For
									</TD>
									<TD colSpan="2">
										<asp:radiobuttonlist id="radParent" CssClass="rbl" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
											<asp:ListItem Value="Machine">Machine</asp:ListItem>
											<asp:ListItem Value="MachineList">MachineList</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD colSpan="3"></TD>
								</TR>
							
						</asp:panel><asp:panel id="pnlMachine" runat="server" Width="503px" Height="64px">
							
								<TR>
									<TD style="WIDTH: 128px">Location</TD>
									<TD style="WIDTH: 188px">
										<asp:Label id="lblLocationM" runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 128px; HEIGHT: 21px">MachineGroup</TD>
									<TD style="WIDTH: 188px; HEIGHT: 21px">
										<asp:Label id="lblGroupM" runat="server" Width="261px"></asp:Label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 128px">Machine&nbsp; Code</TD>
									<TD style="WIDTH: 188px">
										<asp:dropdownlist id="ddlMachineCode" CssClass="form-control ll" runat="server" Width="325px" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 128px">SubAssemblyCode</TD>
									<TD style="WIDTH: 188px">
										<asp:TextBox id="txtMacSubAssemblyCode" CssClass="form-control" runat="server"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 128px">SubAssemblyDesc</TD>
									<TD style="WIDTH: 188px">
										<asp:TextBox id="txtMacSubAssemblyDesc" CssClass="form-control" runat="server"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 128px">
										<asp:Button id="btnChangeGroup" CssClass="button button2" BorderStyle="Groove" runat="server" Width="106px" Text="ChangeGroup"></asp:Button></TD>
									<TD style="WIDTH: 188px">
										<asp:Button id="btnSaveSubAssembly" CssClass="button button2" BorderStyle="Groove" runat="server"></asp:Button></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 128px" colSpan="2"></TD>
								</TR>
								<TR>
								</TR>
							
						</asp:panel><asp:panel id="pnlMachineList" runat="server" Width="283px" Height="43px">
							
								<TR>
									<TD style="WIDTH: 187px">Location</TD>
									<TD>
										<asp:label id="lblLocationG" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 187px">MachineGroup</TD>
									<TD>
										<asp:Label id="lblGroupG" runat="server" Width="203px"></asp:Label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 187px">MachineList</TD>
									<TD>
										<asp:listbox id="lstMachineCode" runat="server" CssClass="ll" Width="371px" SelectionMode="Multiple"></asp:listbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 187px">SubAssemblyCode</TD>
									<TD>
										<asp:TextBox id="txtSubAssemblyCode" CssClass="form-control" runat="server"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 200px">SubAssemblyDesc</TD>
									<TD>
										<asp:TextBox id="txtSubAssemblyDesc" CssClass="form-control" runat="server"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 200px"></TD>
									<TD></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 200px">
										<asp:Button id="btnChangeGroupG" CssClass="button button2" BorderStyle="Groove" runat="server" Text="ChangeGroup"></asp:Button></TD>
									<TD>
										<asp:Button id="btnSaveGroup" CssClass="button button2" BorderStyle="Groove" runat="server" Text="SaveSubAssemblies"></asp:Button></TD>
								</TR>
							
						</asp:panel><asp:panel id="pnlSubAssembly" runat="server">
							
								<TR>
									<TD style="WIDTH: 155px" noWrap>Location</TD>
									<TD noWrap>
										<asp:Label id="lblLocationS" runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 155px" noWrap>MachineGroup</TD>
									<TD noWrap>
										<asp:Label id="lblGroupS" runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 155px" noWrap>SubAssemblyList</TD>
									<TD noWrap>
										<asp:ListBox id="lstSubAssemblyCode" runat="server" Width="386px" SelectionMode="Multiple"></asp:ListBox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 155px" noWrap>NextSubAssemblyCode</TD>
									<TD noWrap>
										<asp:TextBox id="txtNextSubAssemblyCode" CssClass="form-control" runat="server" AutoPostBack="True"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 155px" noWrap>NextSubAssemblyDesc</TD>
									<TD noWrap>
										<asp:TextBox id="txtNextSubAssemblyDesc" CssClass="form-control" runat="server" ></asp:TextBox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 155px" noWrap>
										<asp:Button id="btnChangeGroupS" CssClass="button button2" BorderStyle="Groove" runat="server" Text="ChangeGroup"></asp:Button></TD>
									<TD noWrap>
										<asp:Button id="btnSaveSubAssemblies" CssClass="button button2" BorderStyle="Groove" runat="server" Text="SaveNextSubAssemblies"></asp:Button></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 155px" noWrap></TD>
									<TD noWrap></TD>
								</TR>
							
						</asp:panel><asp:datagrid id="DataGrid1" runat="server" Width="755px"></asp:datagrid><asp:datagrid id="DataGrid2" runat="server" Width="756px">
							<Columns>
								<asp:ButtonColumn Text="Delete" CommandName="Delete"></asp:ButtonColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
			</TABLE>
		</asp:panel></form>
               <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
