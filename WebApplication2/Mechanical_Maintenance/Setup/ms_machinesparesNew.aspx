<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ms_machinesparesNew.aspx.vb" Inherits="WebApplication2.ms_machinesparesNew" %>
<!DOCTYPE HTML PUBLIC "-//W3C//Dtd HTML 4.0 transitional//EN">
<html>
	<head runat="server">
		<title>ms_machinesparesNew</title>
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
       <%-- <link rel="stylesheet" href="../../StyleSheet1.css" />--%>

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
     
                
    
                             <%-- <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                             <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                                 <asp:ListItem>select</asp:ListItem>
                                 <asp:ListItem>Theme1</asp:ListItem>
                                 <asp:ListItem>Theme2</asp:ListItem>
                                 <asp:ListItem>Theme3</asp:ListItem>
                             </asp:DropDownList>
                             <br />--%>
                

         
			<table id="table2" class="table">
				<tr>
					<td><asp:label id="Label1" runat="server" Font-Underline="true"><h3>RTSHOP</h3></asp:label><asp:label id="lblGrp" runat="server" Visible="False"></asp:label><asp:label id="lblUserID" runat="server" Visible="False"></asp:label></td>
				</tr>
				<tr>
					<td><asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></td>
				</tr></table>
				<asp:panel id="pnlLocation" runat="server">
							<table id="table1" class="table">
								<tr>
									<td><h4>Group</h4></td>
									<td>
										<asp:label id="lblMaintenance_group" runat="server"></asp:label></td>
								</tr>
                               
								<tr>
									<td><h4>Location</h4></td>
									<td>
										<asp:dropdownlist id="cboLocation" runat="server" AutoPostBack="true" CssClass="form-control ll"></asp:dropdownlist></td>
								</tr>
								<tr>
									<td><h4>Machine Group</h4></td>
									<td>
										<asp:dropdownlist id="ddlMachineGroup" runat="server" AutoPostBack="true" CssClass="form-control ll"></asp:dropdownlist></td>
								</tr>
								<tr>
									<td colspan="2">
										<asp:RadioButtonList id="rdoTypeOfGroup" runat="server" AutoPostBack="true" Repeatdirection="Horizontal" CssClass="rbl" RepeatLayout="Flow">
											<asp:ListItem Value="GroupPLs">GroupPLs</asp:ListItem>
											<asp:ListItem Value="MachinePLs">MachinePLs</asp:ListItem>
											<asp:ListItem Value="SubAssemblyPLs">SubAssemblyPLs</asp:ListItem>
										</asp:RadioButtonList></td>
								</tr>
							</table>
						</asp:panel><asp:panel id="pnlSubAssembly" runat="server">
							<table id="table6" class="table">
								<tr>
									<td>Location</td>
									<td>
										<asp:Label id="lblLocationS" runat="server"></asp:Label></td>
								</tr>
								<tr>
									<td>MachineGroup</td>
									<td>
										<asp:Label id="lblGroupS" runat="server"></asp:Label></td>
								</tr>
								<tr>
									<td>SubAssemblyList</td>
									<td>
										<asp:ListBox id="lstSubAssemblyCode" CssClass="ll" runat="server" SelectionMode="Multiple"></asp:ListBox></td>
								</tr>
								<tr>
									<td>PL Number</td>
									<td>
										<asp:TextBox id="txtPlNumberS" runat="server" Width="83px" AutoPostBack="true"></asp:TextBox>
										<asp:Label id="lblPlDescS" runat="server" Width="272px"></asp:Label></td>
								</tr>
								<tr>
									<td >Pl Qty for Each selected SubAssm</td>
									<td >
										<asp:TextBox id="txtQtyS" runat="server" CssClass="form-control"></asp:TextBox>
										<asp:Label id="lblUnitS" runat="server"></asp:Label></td>
								</tr>
								<tr>
									<td >Purpose</td>
									<td >
										<asp:TextBox id="txtPurposeS" runat="server" CssClass="form-control"></asp:TextBox></td>
								</tr>
								<tr>
									<td >
										<asp:Button id="btnChangeGroupS" runat="server" Text="ChangeGroup" CssClass="button button2"></asp:Button></td>
									<td >
										<asp:Button id="btnSaveSubAssembly" runat="server" Text="SaveSubAssemblyPLs" CssClass="button button2"></asp:Button></td>
								</tr>
								<tr>
									<td ></td>
									<td ></td>
								</tr>
							</table>
						</asp:panel><asp:panel id="pnlGroup" runat="server" >
							<table id="table5" class="table">
								<tr>
									<td>Location</td>
									<td>
										<asp:label id="lblLocationG" runat="server"></asp:label></td>
								</tr>
								<tr>
									<td >MachineGroup</td>
									<td>
										<asp:Label id="lblGroupG" runat="server"></asp:Label></td>
								</tr>
								<tr>
									<td>MachineList</td>
									<td>
										<asp:listbox id="lstMachineCode" CssClass="ll" runat="server" SelectionMode="Multiple"></asp:listbox></td>
								</tr>
								<tr>
									<td>Pl Number</td>
									<td>
										<asp:TextBox id="txtPlNumberG" runat="server" AutoPostBack="true" CssClass="form-control"></asp:TextBox>
										<asp:Label id="lblPlDescG" runat="server"></asp:Label></td>
								</tr>
								<tr>
									<td >Pl Qty for Each selected M/c</td>
									<td>
										<asp:TextBox id="txtQty" runat="server" CssClass="form-control"></asp:TextBox>
										<asp:Label id="lblUnitG" runat="server"></asp:Label></td>
								</tr>
								<tr>
									<td >Purpose</td>
									<td>
										<asp:TextBox id="txtPurposeG" runat="server" CssClass="form-control"></asp:TextBox></td>
								</tr>
								<tr>
									<td>
										<asp:Button id="btnChangeGroupG" runat="server" Text="ChangeGroup" CssClass="button button2"></asp:Button></td>
									<td>
										<asp:Button id="btnSaveGroup" runat="server" Text="SaveGroupPLs"  CssClass="button button2"></asp:Button></td>
								</tr>
							</table>
						</asp:panel><asp:panel id="pnlMachine" runat="server">
							<table id="table3" class="table">
								<tr>
									<td>Location</td>
									<td>
										<asp:Label id="lblLocationM" runat="server"></asp:Label></td>
								</tr>
								<tr>
									<td>MachineGroup</td>
									<td>
										<asp:Label id="lblGroupM" runat="server"></asp:Label></td>
								</tr>
								<tr>
									<td>Machine&nbsp;Code</td>
									<td>
										<asp:dropdownlist id="ddlMachineCode" runat="server" CssClass="form-control ll" AutoPostBack="true"></asp:dropdownlist></td>
								</tr>
								<tr>
									<td>
										<asp:radiobuttonlist id="rdoTypeOfSpares" runat="server" AutoPostBack="true" Repeatdirection="Horizontal" CssClass="rbl">
											<asp:ListItem Value="MachinePls">MachinePLs</asp:ListItem>
											<asp:ListItem Value="SubAssemblyPLs">SubAssemblyPLs</asp:ListItem>
										</asp:radiobuttonlist></td>
								</tr>
							</table>
						</asp:panel><asp:panel id="pnlSpares" runat="server">
							<table id="table4" class="table">
								<tr>
									<td>Location</td>
									<td>
										<asp:label id="lblLocation" runat="server"></asp:label>
										<asp:Label id="lblMachineCode" runat="server" Visible="False"></asp:Label></td>
								</tr>
								<tr>
									<td>Machine</td>
									<td>
										<asp:label id="lblMachine" runat="server"></asp:label></td>
								</tr>
								<tr>
									<td>
										<asp:label id="lblSubAssm" runat="server">SubAssembly</asp:label></td>
									<td>
										<asp:dropdownlist id="cboAssembly" runat="server" AutoPostBack="true" CssClass="form-control ll"></asp:dropdownlist>
										<asp:label id="lblSubAssembly" runat="server"></asp:label></td>
								</tr>
								<tr>
									<td>Pl Number</td>
									<td>
										<asp:textbox id="txtPLNumber" runat="server" AutoPostBack="true" CssClass="form-control"></asp:textbox>
										<asp:Label id="lblPlDesc" runat="server"></asp:Label></td>
								</tr>
								<tr>
									<td>Quantity Required</td>
									<td>
										<asp:textbox id="txtQtyReqd" runat="server" CssClass="form-control"></asp:textbox>
										<asp:Label id="lblUnit" runat="server"></asp:Label></td>
								</tr>
								<tr>
									<td>Purpose</td>
									<td>
										<asp:textbox id="txtPurpose" runat="server" CssClass="form-control"></asp:textbox></td>
								</tr>
								<tr>
									<td>
										<asp:button id="btnChangeMachine" runat="server" CssClass="button button2" Text="ChangeMachine"></asp:button>
										<asp:Button id="btnChangeGroup" runat="server" CssClass="button button2" Text="ChangeGroup"></asp:Button></td>
									<td>
										<asp:button id="btnSave" runat="server" CssClass="button button2"></asp:button>
										<asp:button id="btnCancel" runat="server" Text="Cancel" CssClass="button button2"></asp:button></td>
								</tr>
							</table>
						</asp:panel><asp:datagrid id="DataGrid2" runat="server" CssClass="Table"></asp:datagrid><asp:datagrid id="DataGrid1" runat="server" CssClass="Table">
							<Columns>
								<asp:ButtonColumn Text="Delete" CommandName="Delete"></asp:ButtonColumn>
							</Columns>
						</asp:datagrid>
			   </div>
   </div>
    </div>
		</form>
      
        <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
            
	</body>
</html>
