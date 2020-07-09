<%@ Page Language="vb" AutoEventWireup="false" Codebehind="GroupToolEdit.aspx.vb" Inherits="WebApplication2.GroupToolEdit" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>GroupToolEdit</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
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
    
                 <%-- <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
      </div>
            </div>
			<asp:Panel id="Panel1" runat="server">
				<TABLE id="Table1" class="table">
					<TR>
						<TD>Group Edit</TD>
					</TR>
				</TABLE>
				<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label>
				<TABLE id="Table3" class="table">
					<TR>
						<TD style="WIDTH: 79px">GroupNo</TD>
						<TD>
							<asp:DropDownList id="ddlGroup" CssClass="form-control ll" runat="server" AutoPostBack="True"></asp:DropDownList></TD>
					</TR>
				</TABLE>
				<TABLE id="Table5" class="table">
					<TR>
						<TD>Range</TD>
						<TD>
							<asp:textbox id="txtRange" CssClass="form-control" runat="server"></asp:textbox></TD>
						<TD>
							<asp:requiredfieldvalidator id="RequiredFieldValidator7" runat="server" ControlToValidate="txtRange" ErrorMessage="*"></asp:requiredfieldvalidator></TD>
						<TD>ReferenceStd.No</TD>
						<TD>
							<asp:textbox id="txtcalibration_prodedure" CssClass="form-control" runat="server"></asp:textbox></TD>
						<TD>
							<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" ControlToValidate="txtcalibration_prodedure" ErrorMessage="*"></asp:requiredfieldvalidator></TD>
					</TR>
					<TR>
						<TD>UnitOfMeasure</TD>
						<TD>
							<asp:textbox id="txtUnit_of_measure" CssClass="form-control" runat="server"></asp:textbox></TD>
						<TD>
							<asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" ControlToValidate="txtUnit_of_measure" ErrorMessage="*"></asp:requiredfieldvalidator></TD>
						<TD>AccuracyCriteria</TD>
						<TD>
							<asp:textbox id="txtCriteria" CssClass="form-control" runat="server"></asp:textbox></TD>
						<TD>
							<asp:requiredfieldvalidator id="RequiredFieldValidator8" runat="server" ControlToValidate="txtCriteria" ErrorMessage="*"></asp:requiredfieldvalidator></TD>
					</TR>
					<TR>
						<TD>CalibrationFrequency</TD>
						<TD>
							<asp:dropdownlist id="ddlFrequency" CssClass="form-control ll" runat="server"></asp:dropdownlist></TD>
						<TD></TD>
						<TD>CalibrationLink</TD>
						<TD>
							<asp:textbox id="txtLink" CssClass="form-control" runat="server"></asp:textbox></TD>
						<TD>
							<asp:requiredfieldvalidator id="RequiredFieldValidator9" runat="server" ControlToValidate="txtLink" ErrorMessage="*"></asp:requiredfieldvalidator></TD>
					</TR>
					<TR>
						<TD>ProcessTolerance</TD>
						<TD>
							<asp:textbox id="txtTolerance" CssClass="form-control" runat="server"></asp:textbox></TD>
						<TD>
							<asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" ControlToValidate="txtTolerance" ErrorMessage="*"></asp:requiredfieldvalidator></TD>
						<TD>WorkInstructionNumber</TD>
						<TD>
							<asp:textbox id="txtInstruction_number" CssClass="form-control" runat="server"></asp:textbox></TD>
						<TD>
							<asp:requiredfieldvalidator id="RequiredFieldValidator10" runat="server" ControlToValidate="txtInstruction_number" ErrorMessage="*"></asp:requiredfieldvalidator></TD>
					</TR>
					<TR>
						<TD>Plus Error</TD>
						<TD>
							<asp:textbox id="txtError_plus" CssClass="form-control" runat="server"></asp:textbox></TD>
						<TD>
							<asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server" ControlToValidate="txtError_plus" ErrorMessage="*"></asp:requiredfieldvalidator></TD>
						<TD>Minus Error</TD>
						<TD>
							<asp:textbox id="txtError_minus" CssClass="form-control" runat="server"></asp:textbox></TD>
						<TD>
							<asp:requiredfieldvalidator id="RequiredFieldValidator11" runat="server" ControlToValidate="txtError_minus" ErrorMessage="*"></asp:requiredfieldvalidator></TD>
					</TR>
					<TR>
						<TD>InstrumentDescription</TD>
						<TD colSpan="5">
							<asp:textbox id="txtType" CssClass="form-control" runat="server"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="middle" colSpan="6">
							<asp:Button id="btnGroup" CssClass="button button2" runat="server" Text="Save Group"></asp:Button></TD>
					</TR>
				</TABLE>
			</asp:Panel>
		</form>
         <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
