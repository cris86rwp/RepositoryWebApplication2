<%@ Page Language="vb" AutoEventWireup="false" Codebehind="addGroupTools.aspx.vb" Inherits="WebApplication2.addGroupTools" Culture="en-GB" uiCulture="en-GB" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>Add Tools</title>
		<META content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<META content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
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
	    <style type="text/css">
            .auto-style1 {
                height: 38px;
            }
            .auto-style2 {
                height: 50px;
            }
        </style>
	</HEAD>
	<BODY MS_POSITIONING="GridLayout" bgColor="#ffcccc">
	<body bgColor="#99ccff" >
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
				<TABLE id="Table4" class="table">
					<TR>
						<TD align="middle">Add New Tool</TD>
					</TR>
					<TR>
						<TD>
							<asp:label id="lblMode" runat="server" ForeColor="Blue" Font-Bold="True" Font-Names="Arial" Font-Size="Smaller"></asp:label></TD>
					</TR>
					<TR>
						<TD>
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></TD>
					</TR>
					<TR>
						<TD class="auto-style1">Maintenance Group
							<asp:label id="lblMaintenance_group" runat="server"></asp:label></TD>
					</TR>
					<TR>
						<TD>Add
							<asp:radiobuttonlist id="radType" runat="server" CssClass="rbl" Font-Bold="True" AutoPostBack="True" RepeatDirection="Horizontal" RepeatLayout="Flow">
								<asp:ListItem Value="G">Group</asp:ListItem>
								<asp:ListItem Value="T" Selected="True">Tool</asp:ListItem>
							</asp:radiobuttonlist></TD>
					</TR>
					<TR>
						<TD>
							<asp:panel id="pnlEdit" runat="server">History Card Number&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;: 
<asp:DropDownList id="cboHistory_number" CssClass="form-control ll" runat="server" AutoPostBack="True"></asp:DropDownList></asp:panel></TD>
					</TR>
				</TABLE>
				<TABLE id="Table5" class="table">
					<TR>
						<TD>GroupName</TD>
						<TD>
							<asp:textbox id="txtGroup" runat="server" CssClass="form-control" Visible="False"></asp:textbox>
							<asp:dropdownlist id="cboGroup" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></TD>
						<TD>
							<asp:requiredfieldvalidator id="rfvGroup" runat="server" Visible="False" ErrorMessage="*" ControlToValidate="txtGroup" Enabled="False"></asp:requiredfieldvalidator></TD>
						<TD>Range</TD>
						<TD>
							<asp:textbox id="txtRange" runat="server" CssClass="form-control"></asp:textbox></TD>
						<TD>
							<asp:requiredfieldvalidator id="RequiredFieldValidator7" runat="server" ErrorMessage="*" ControlToValidate="txtRange"></asp:requiredfieldvalidator></TD>
					</TR>
					<TR>
						<TD class="auto-style2">UnitOfMeasure</TD>
						<TD class="auto-style2">
							<asp:textbox id="txtUnit_of_measure" runat="server" CssClass="form-control"></asp:textbox></TD>
						<TD class="auto-style2">
							<asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="txtUnit_of_measure"></asp:requiredfieldvalidator></TD>
						<TD class="auto-style2">AccuracyCriteria</TD>
						<TD class="auto-style2">
							<asp:textbox id="txtCriteria" runat="server" CssClass="form-control"></asp:textbox></TD>
						<TD class="auto-style2">
							<asp:requiredfieldvalidator id="RequiredFieldValidator8" runat="server" ErrorMessage="*" ControlToValidate="txtCriteria"></asp:requiredfieldvalidator></TD>
					</TR>
					<TR>
						<TD>CalibrationFrequency</TD>
						<TD>
							<asp:dropdownlist id="cboFrequency" CssClass="form-control ll" runat="server"></asp:dropdownlist></TD>
						<TD></TD>
						<TD>CalibrationLink</TD>
						<TD>
							<asp:textbox id="txtLink" runat="server" CssClass="form-control"></asp:textbox></TD>
						<TD>
							<asp:requiredfieldvalidator id="RequiredFieldValidator9" runat="server" ErrorMessage="*" ControlToValidate="txtLink"></asp:requiredfieldvalidator></TD>
					</TR>
					<TR>
						<TD>ProcessTolerance</TD>
						<TD>
							<asp:textbox id="txtTolerance" runat="server" CssClass="form-control"></asp:textbox></TD>
						<TD>
							<asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" ErrorMessage="*" ControlToValidate="txtTolerance"></asp:requiredfieldvalidator></TD>
						<TD>WorkInstructionNumber</TD>
						<TD>
							<asp:textbox id="txtInstruction_number" runat="server" CssClass="form-control"></asp:textbox></TD>
						<TD>
							<asp:requiredfieldvalidator id="RequiredFieldValidator10" runat="server" ErrorMessage="*" ControlToValidate="txtInstruction_number"></asp:requiredfieldvalidator></TD>
					</TR>
					<TR>
						<TD>Plus Error</TD>
						<TD>
							<asp:textbox id="txtError_plus" runat="server" CssClass="form-control"></asp:textbox></TD>
						<TD>
							<asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server" ErrorMessage="*" ControlToValidate="txtError_plus"></asp:requiredfieldvalidator></TD>
						<TD>Minus Error</TD>
						<TD>
							<asp:textbox id="txtError_minus" runat="server" CssClass="form-control"></asp:textbox></TD>
						<TD>
							<asp:requiredfieldvalidator id="RequiredFieldValidator11" runat="server" ErrorMessage="*" ControlToValidate="txtError_minus"></asp:requiredfieldvalidator></TD>
					</TR>
					<TR>
						<TD>ReferenceStd.No</TD>
						<TD>
							<asp:textbox id="txtcalibration_prodedure" runat="server" CssClass="form-control"></asp:textbox></TD>
						<TD>
							<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" ErrorMessage="*" ControlToValidate="txtcalibration_prodedure"></asp:requiredfieldvalidator></TD>
						<TD>Type of Instrument</TD>
						<TD>
							<asp:textbox id="txtType" runat="server" CssClass="form-control"></asp:textbox></TD>
						<TD></TD>
					</TR>
				</TABLE>
				<asp:panel id="pnlTool" runat="server">
					<TABLE id="Table2" class="table">
						<TR>
							<TD>ShopCode</TD>
							<TD>
								<asp:DropDownList id="cboShop_code" CssClass="form-control ll" runat="server"></asp:DropDownList></TD>
							<TD>
								<asp:Label id="lblShop_code" runat="server" Visible="False"></asp:Label></TD>
							<TD>
								<asp:DropDownList id="cboTool" runat="server" CssClass="form-control ll" Visible="False"></asp:DropDownList></TD>
							<TD></TD>
							<TD></TD>
						</TR>
						<TR>
							<TD>InstrumentNumber</TD>
							<TD>
								<asp:textbox id="txtInstrument_number" runat="server" CssClass="form-control"></asp:textbox></TD>
							<TD>
								<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtInstrument_number"></asp:requiredfieldvalidator></TD>
							<TD>Make</TD>
							<TD>
								<asp:TextBox id="txtMake" runat="server" CssClass="form-control"></asp:TextBox></TD>
							<TD>
								<asp:RequiredFieldValidator id="RequiredFieldValidator14" runat="server" ErrorMessage="*" ControlToValidate="txtMake"></asp:RequiredFieldValidator></TD>
						</TR>
						<TR>
							<TD>HistoryCardNumber</TD>
							<TD>
								<asp:textbox id="txtHistory_number" runat="server" CssClass="form-control"></asp:textbox></TD>
							<TD>
								<asp:requiredfieldvalidator id="rfvHistory" runat="server" ErrorMessage="*" ControlToValidate="txtHistory_number"></asp:requiredfieldvalidator></TD>
							<TD>Model</TD>
							<TD>
								<asp:TextBox id="txtModel" runat="server" CssClass="form-control"></asp:TextBox></TD>
							<TD>
								<asp:RequiredFieldValidator id="RequiredFieldValidator13" runat="server" ErrorMessage="*" ControlToValidate="txtModel"></asp:RequiredFieldValidator></TD>
						</TR>
						<TR>
							<TD>Stranded</TD>
							<TD>
								<asp:textbox id="txtStranded" runat="server" CssClass="form-control"></asp:textbox></TD>
							<TD>
								<asp:RequiredFieldValidator id="RequiredFieldValidator12" runat="server" ErrorMessage="*" ControlToValidate="txtStranded"></asp:RequiredFieldValidator></TD>
							<TD>DateOfEntry</TD>
							<TD>
								<asp:TextBox id="txtEntry" runat="server" CssClass="form-control"></asp:TextBox></TD>
							<TD></TD>
						</TR>
					</TABLE>
				</asp:panel>
				<TABLE id="Table1" class="table">
					<TR>
						<TD>
							<asp:button id="btnSave" runat="server" Font-Names="Arial" Font-Size="Smaller" CssClass="button button2" BorderStyle="Groove" Text="Save"></asp:button></TD>
						<TD>
							<asp:button id="btnClear" runat="server" Font-Names="Arial" Font-Size="Smaller" CssClass="button button2" BorderStyle="Groove" Text="Clear"></asp:button></TD>
						<TD>
							<asp:button id="btnExit" runat="server" Font-Names="Arial" Font-Size="Smaller" CssClass="button button2" BorderStyle="Groove" Text="Exit" CausesValidation="False"></asp:button></TD>
					</TR>
				</TABLE>
				<asp:DataGrid id="DataGrid1" runat="server" BorderStyle="None" BorderColor="#CC9966" BorderWidth="1px" BackColor="White" CellPadding="4">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
			</asp:Panel>
		</FORM>
                 <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</BODY>
</HTML>
