<%@ Page Language="vb" AutoEventWireup="false" Codebehind="GroupToolAdd.aspx.vb" Inherits="WebApplication2.GroupToolAdd" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>GroupToolAdd</title>
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
        <div class="row">
            
    <form id="Form2" method="post" runat="server">
                  <%--<h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
      </div>
            </div>
        <div class="table-responsive">
			<asp:panel id="Panel1" runat="server">
				<TABLE id="Table1" class="table">
					<TR>
						<TD>New
							<asp:RadioButtonList id="rblType" CssClass="rbl" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" RepeatLayout="Flow">
								<asp:ListItem Value="Group" Selected="True">Group</asp:ListItem>
								<asp:ListItem Value="Tool">Tool</asp:ListItem>
							</asp:RadioButtonList></TD>
					</TR>
				</TABLE>
				<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label>
				<TABLE id="Table4" class="table">
					<TR>
						<TD>
							<asp:Panel id="pnlGroup" runat="server">
								
									<TR>
										<TD>GroupName</TD>
										<TD>
											<asp:textbox id="txtGroup" runat="server" CssClass="form-control"> </asp:textbox></TD>
										<TD>
											<asp:requiredfieldvalidator id="rfvGroup" runat="server" Enabled="False" ControlToValidate="txtGroup" ErrorMessage="*" Visible="False"></asp:requiredfieldvalidator></TD>
										<TD>Range</TD>
										<TD>
											<asp:textbox id="txtRange" CssClass="form-control" runat="server"></asp:textbox></TD>
										<TD>
											<asp:requiredfieldvalidator id="RequiredFieldValidator7" runat="server" ControlToValidate="txtRange" ErrorMessage="*"></asp:requiredfieldvalidator></TD>
									</TR>
									<TR>
										<TD>UnitOfMeasure</TD>
										<TD>
											<asp:textbox id="txtUnit_of_measure" runat="server" CssClass="form-control"></asp:textbox></TD>
										<TD>
											<asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" ControlToValidate="txtUnit_of_measure" ErrorMessage="*"></asp:requiredfieldvalidator></TD>
										<TD>AccuracyCriteria</TD>
										<TD>
											<asp:textbox id="txtCriteria" runat="server" CssClass="form-control"></asp:textbox></TD>
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
											<asp:textbox id="txtLink" runat="server" CssClass="form-control"></asp:textbox></TD>
										<TD>
											<asp:requiredfieldvalidator id="RequiredFieldValidator9" runat="server" ControlToValidate="txtLink" ErrorMessage="*"></asp:requiredfieldvalidator></TD>
									</TR>
									<TR>
										<TD>ProcessTolerance</TD>
										<TD>
											<asp:textbox id="txtTolerance" runat="server" CssClass="form-control"></asp:textbox></TD>
										<TD>
											<asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" ControlToValidate="txtTolerance" ErrorMessage="*"></asp:requiredfieldvalidator></TD>
										<TD>WorkInstructionNumber</TD>
										<TD>
											<asp:textbox id="txtInstruction_number" runat="server" CssClass="form-control"></asp:textbox></TD>
										<TD>
											<asp:requiredfieldvalidator id="RequiredFieldValidator10" runat="server" ControlToValidate="txtInstruction_number" ErrorMessage="*"></asp:requiredfieldvalidator></TD>
									</TR>
									<TR>
										<TD>Plus Error</TD>
										<TD>
											<asp:textbox id="txtError_plus" runat="server" CssClass="form-control"></asp:textbox></TD>
										<TD>
											<asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server" ControlToValidate="txtError_plus" ErrorMessage="*"></asp:requiredfieldvalidator></TD>
										<TD>Minus Error</TD>
										<TD>
											<asp:textbox id="txtError_minus" runat="server" CssClass="form-control"></asp:textbox></TD>
										<TD>
											<asp:requiredfieldvalidator id="RequiredFieldValidator11" runat="server" ControlToValidate="txtError_minus" ErrorMessage="*"></asp:requiredfieldvalidator></TD>
									</TR>
									<TR>
										<TD>ReferenceStd.No</TD>
										<TD colSpan="5">
											<asp:textbox id="txtcalibration_prodedure" runat="server" CssClass="form-control"></asp:textbox></TD>
									</TR>
									<TR>
										<TD>Type of Instrument</TD>
										<TD colSpan="5">
											<asp:textbox id="txtType" runat="server" CssClass="form-control"></asp:textbox>
											<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" ControlToValidate="txtcalibration_prodedure" ErrorMessage="*"></asp:requiredfieldvalidator></TD>
									</TR>
									<TR>
										<TD align="middle" colSpan="6">
											<asp:Button id="btnGroup" runat="server" CssClass="button button2" Text="Save Group"></asp:Button></TD>
									</TR>
							
							</asp:Panel></TD>
					</TR>
					<TR>
						<TD>
							<asp:Panel id="pnlTool" runat="server">
																	<TR>
										<TD>GroupName</TD>
										<TD>
											<asp:DropDownList id="ddlGroup" CssClass="form-control ll" runat="server" AutoPostBack="True"></asp:DropDownList></TD>
									</TR>
									<TR>
										<TD>ShopCode</TD>
										<TD>
											<asp:DropDownList id="ddlShop" CssClass="form-control ll" runat="server"></asp:DropDownList></TD>
									</TR>
								<asp:DataGrid id="dgGroup" runat="server" CellPadding="4" BackColor="White" BorderWidth="1px" CssClass="table" BorderStyle="None" BorderColor="#CC9966">
									<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
									<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
									<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
									<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
									<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
								</asp:DataGrid>
								
									<TR>
										<TD>InstrumentNumber</TD>
										<TD>
											<asp:textbox id="txtInstrument_number" CssClass="form-control" runat="server"></asp:textbox></TD>
										<TD>
											<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ControlToValidate="txtInstrument_number" ErrorMessage="*"></asp:requiredfieldvalidator></TD>
										<TD>Make</TD>
										<TD>
											<asp:TextBox id="txtMake" runat="server" CssClass="form-control"></asp:TextBox></TD>
										<TD>
											<asp:RequiredFieldValidator id="RequiredFieldValidator14" runat="server" ControlToValidate="txtMake" ErrorMessage="*"></asp:RequiredFieldValidator></TD>
									</TR>
									<TR>
										<TD>HistoryCardNumber</TD>
										<TD>
											<asp:textbox id="txtHistory_number" CssClass="form-control" runat="server" AutoPostBack="True"></asp:textbox></TD>
										<TD>
											<asp:requiredfieldvalidator id="rfvHistory" runat="server" ControlToValidate="txtHistory_number" ErrorMessage="*"></asp:requiredfieldvalidator></TD>
										<TD>Model</TD>
										<TD>
											<asp:TextBox id="txtModel" runat="server" CssClass="form-control"></asp:TextBox></TD>
										<TD>
											<asp:RequiredFieldValidator id="RequiredFieldValidator13" runat="server" ControlToValidate="txtModel" ErrorMessage="*"></asp:RequiredFieldValidator></TD>
									</TR>
									<TR>
										<TD>Stranded</TD>
										<TD>
											<asp:textbox id="txtStranded" runat="server" CssClass="form-control"></asp:textbox></TD>
										<TD>
											<asp:RequiredFieldValidator id="RequiredFieldValidator12" runat="server" ControlToValidate="txtStranded" ErrorMessage="*"></asp:RequiredFieldValidator></TD>
										<TD>DateOfEntry</TD>
										<TD>
											<asp:TextBox id="txtEntry" runat="server" CssClass="form-control"></asp:TextBox></TD>
										<TD></TD>
									</TR>
									<TR>
										<TD align="middle">
											<asp:Button id="btnTool" runat="server" CssClass="button button2" Text="Save Tool"></asp:Button></TD>
									</TR>
				
								<asp:DataGrid id="dgTools" runat="server" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#3366CC" CssClass="table">
									<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
									<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
									<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
									<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
									<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
								</asp:DataGrid>
							</asp:Panel></TD>
					</TR>
				</TABLE>
			</asp:panel>
            </div>
            </form>
         <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
