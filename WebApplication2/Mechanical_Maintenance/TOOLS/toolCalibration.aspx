<%@ Page Language="vb" AutoEventWireup="false" Codebehind="toolCalibration.aspx.vb" Inherits="WebApplication2.toolCalibration" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>toolCalibration</title>
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
				<TABLE id="Table2" class="table">
		       <TR>
						<TD colSpan="3">Tool Calibration&nbsp;<hr class="prettyline" />
							<asp:label id="lblMode" runat="server" ForeColor="Blue" Font-Bold="True" Font-Names="Arial" Font-Size="Smaller" Width="63px"></asp:label></TD>
					</TR>
                   
					<TR>
						<TD colSpan="3">
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></TD>
                        
					</TR>
					<TR>
						<TD>MaintenanceGroup</TD>
						<TD>:</TD>
						<TD>
							<asp:label id="lblMaintenance_group" runat="server" Width="55px"></asp:label></TD>
					</TR>
					<TR>
						<TD colSpan="3">
							<asp:Label id="lblCalibration_code" runat="server" Visible="False"></asp:Label></TD>
					</TR>
					<TR>
						<TD>Shop</TD>
						<TD>:</TD>
						<TD>
							<asp:DropDownList id="cboShop_code" CssClass="form-control ll" runat="server" AutoPostBack="True"></asp:DropDownList></TD>
					</TR>
					<TR>
						<TD colSpan="3">
							<asp:label id="lblShop_code" runat="server" Width="365px"></asp:label></TD>
					</TR>
					<TR>
						<TD>InstrumentNumber</TD>
						<TD>:</TD>
						<TD>
							<asp:DropDownList id="cboTool" CssClass="form-control ll" runat="server" AutoPostBack="True"></asp:DropDownList></TD>
					</TR>
					<TR>
						<TD>
							<asp:requiredfieldvalidator id="Requiredfieldvalidator10" runat="server" ErrorMessage="*" ControlToValidate="txtInstrument_Number"></asp:requiredfieldvalidator></TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="txtInstrument_Number" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox></TD>
					</TR>
				</TABLE>
				<TABLE id="Table1" class="table">
					<TR>
						<TD>CalibrationDate</TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="txtDate" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox></TD>
						<TD>
							<asp:RangeValidator id="RangeValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtDate" MinimumValue="1/1/1990" MaximumValue="1/1/9999" Type="Date"></asp:RangeValidator>
							<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtDate"></asp:RequiredFieldValidator></TD>
					</TR>
					<TR>
						<TD>StandardReading</TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="txtstandrad_reading" CssClass="form-control" runat="server" Width="117px"></asp:TextBox></TD>
						<TD>
							<asp:requiredfieldvalidator id="Requiredfieldvalidator9" runat="server" ErrorMessage="*" ControlToValidate="txtstandrad_reading"></asp:requiredfieldvalidator></TD>
					</TR>
					<TR>
						<TD>PlusErrorCorrected</TD>
						<TD>:</TD>
						<TD>
							<asp:textbox id="txtError_plus" runat="server" CssClass="form-control"></asp:textbox></TD>
						<TD>
							<asp:requiredfieldvalidator id="Requiredfieldvalidator7" runat="server" ErrorMessage="*" ControlToValidate="txtError_plus"></asp:requiredfieldvalidator></TD>
					</TR>
					<TR>
						<TD>MinusErroCorrected</TD>
						<TD>:</TD>
						<TD>
							<asp:textbox id="txtError_minus" CssClass="form-control" runat="server" Width="115px"></asp:textbox></TD>
						<TD>
							<asp:requiredfieldvalidator id="Requiredfieldvalidator8" runat="server" ErrorMessage="*" ControlToValidate="txtError_minus"></asp:requiredfieldvalidator></TD>
					</TR>
					<TR>
						<TD>AccuracyCalibrated</TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="txtAccuracy" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtAccuracy"></asp:RequiredFieldValidator></TD>
					</TR>
					<TR>
						<TD>AmbientTempInDegrees</TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="txtTemp" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:RequiredFieldValidator id="RequiredFieldValidator6" runat="server" ErrorMessage="*" ControlToValidate="txtTemp"></asp:RequiredFieldValidator></TD>
					</TR>
					<TR>
						<TD>CalibratingPerson</TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="txtPerson" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtPerson"></asp:RequiredFieldValidator></TD>
					</TR>
					<TR>
						<TD>Verified By</TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="txtVerified" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="txtVerified"></asp:RequiredFieldValidator></TD>
					</TR>
					<TR>
						<TD>Remarks</TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="txtRemarks" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server" ErrorMessage="*" ControlToValidate="txtRemarks"></asp:RequiredFieldValidator></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 267px" align="middle" width="267" colSpan="3">
							<asp:Button id="btnSave" runat="server" CssClass="button button2" Font-Size="Smaller" Font-Names="Arial"  BorderStyle="Groove" Text="Save"></asp:Button>
							<asp:Button id="btnClear" runat="server" CssClass="button button2" Font-Size="Smaller" Font-Names="Arial" BorderStyle="Groove" Text="Clear"></asp:Button>
							<asp:Button id="BtnExit" runat="server" CssClass="button button2" Font-Size="Smaller" Font-Names="Arial" BorderStyle="Groove" Text="Exit" CausesValidation="False"></asp:Button></TD>
						<TD style="WIDTH: 267px" align="middle" width="267"></TD>
					</TR>
				</TABLE>
				<asp:DataGrid id="DataGrid1" runat="server" BorderStyle="None" CellPadding="4" BackColor="White" BorderWidth="1px" BorderColor="#CC9966">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
			</asp:panel></form>
                 <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
