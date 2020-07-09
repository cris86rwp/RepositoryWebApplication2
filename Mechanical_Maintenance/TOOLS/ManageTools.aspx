<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ManageTools.aspx.vb" Inherits="WebApplication2.ManageTools" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>ManageTools</title>
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
        <hr class="prettyline " />
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
		
			<asp:panel id="pnlMain" runat="server">
				<TABLE id="Table10" class="table">
					<TR>
						<TD>
							<asp:RadioButtonList id="rblType" runat="server" CssClass="rbl" AutoPostBack="True" RepeatDirection="Horizontal" RepeatLayout="Flow">
								<asp:ListItem Value="Receipt" Selected="True">Receipt</asp:ListItem>
								<asp:ListItem Value="Calibrate">Calibrate</asp:ListItem>
								<asp:ListItem Value="InHouseCalibration">InHouseCalibration</asp:ListItem>
								<asp:ListItem Value="Issue">Issue</asp:ListItem>
							</asp:RadioButtonList>
							<asp:Label id="lblUserID" runat="server" Visible="False"></asp:Label>
							<asp:Label id="lblCaliCode" runat="server" Visible="False"></asp:Label></TD>
					</TR>
				</TABLE>
				<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label>
				<TABLE class="table">
					<TR>
						<TD>
							<asp:RadioButtonList id="rblShop" runat="server" CssClass="rbl" AutoPostBack="True" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:RadioButtonList></TD>
					</TR>
				</TABLE>
				<TABLE id="Table3" class="table">
					<TR>
						<TD>InstrumentNumber</TD>
						<TD>:</TD>
						<TD>
							<asp:DropDownList id="ddlInstruments" CssClass="form-control ll" runat="server" AutoPostBack="True"></asp:DropDownList></TD>
						<TD>
							<asp:Label id="lblInstrumentType" runat="server"></asp:Label></TD>
					</TR>
				</TABLE>
				<asp:DataGrid id="DataGrid1" CssClass="table" runat="server" BackColor="White" CellPadding="4" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
				<asp:Panel id="pnlEdit" runat="server">
					<TABLE id="Table1" class="table">
						<TR>
							<TD colSpan="3">Instrument Selected For Edit</TD>
						</TR>
						<TR>
							<TD>InstrumentNo</TD>
							<TD>:</TD>
							<TD>
								<asp:textbox id="txtInstrumentNumber" CssClass="form-control" runat="server" Width="103px" Enabled="False"></asp:textbox></TD>
						</TR>
						<TR>
							<TD>ShopCode</TD>
							<TD>:</TD>
							<TD>
								<asp:textbox id="txtShop" runat="server" CssClass="form-control" Enabled="False"></asp:textbox></TD>
						</TR>
					</TABLE>
				</asp:Panel>
				<asp:panel id="pnlReceipt" runat="server">
					<TABLE id="Table4" class="table">
						<TR>
							<TD>ReceiptDate</TD>
							<TD>
								<asp:textbox id="txtRecipt_date" CssClass="form-control" runat="server" AutoPostBack="True"></asp:textbox></TD>
							<TD>
								<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ControlToValidate="txtRecipt_Date" ErrorMessage="*"></asp:requiredfieldvalidator></TD>
							<TD>
								<asp:rangevalidator id="RangeValidator1" runat="server" ControlToValidate="txtRecipt_Date" ErrorMessage="*" Type="Date" MaximumValue="1/1/9999" MinimumValue="1/1/1990"></asp:rangevalidator></TD>
							<TD>RecivedAndCheckedBy</TD>
							<TD>
								<asp:textbox id="txtRecived" CssClass="form-control" runat="server"></asp:textbox></TD>
							<TD>
								<asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" ControlToValidate="txtRecived" ErrorMessage="*"></asp:requiredfieldvalidator></TD>
							<TD>PlusErrorReceived</TD>
							<TD>
								<asp:textbox id="txtError_plus" runat="server" CssClass="form-control" AutoPostBack="True" ForeColor="Black"></asp:textbox></TD>
							<TD>
								<asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" ControlToValidate="txtCaliPlusErr" ErrorMessage="*"></asp:requiredfieldvalidator></TD>
							<TD>
								<asp:rangevalidator id="Rangevalidator5" runat="server" ControlToValidate="txtCaliPlusErr" ErrorMessage="*" Type="Double" MaximumValue="99999.999" MinimumValue="0"></asp:rangevalidator></TD>
						</TR>
						<TR>
							<TD>MinusErrorReceived</TD>
							<TD>
								<asp:textbox id="txtError_minus" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox></TD>
							<TD>
								<asp:rangevalidator id="Rangevalidator4" runat="server" ControlToValidate="txtError_minus" ErrorMessage="*" Type="Double" MaximumValue="99999.999" MinimumValue="0"></asp:rangevalidator></TD>
							<TD>
								<asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" ControlToValidate="txtError_minus" ErrorMessage="*"></asp:requiredfieldvalidator></TD>
							<TD>AccuracyReceived
								<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" ControlToValidate="txtAccuracy_received" ErrorMessage="*" Height="8px"></asp:requiredfieldvalidator></TD>
							<TD>
								<asp:textbox id="txtAccuracy_received" runat="server" CssClass="form-control">0</asp:textbox></TD>
							<TD>
								<asp:rangevalidator id="Rangevalidator3" runat="server" ControlToValidate="txtAccuracy_received" ErrorMessage="*" Type="Double" MaximumValue="99999.999" MinimumValue="0"></asp:rangevalidator></TD>
							<TD>Discripency</TD>
							<TD>
								<asp:textbox id="txtDiscripency" runat="server" CssClass="form-control">OK</asp:textbox></TD>
							<TD></TD>
							<TD></TD>
						</TR>
						<TR>
							<TD>Remarks</TD>
							<TD colSpan="5">
								<asp:textbox id="txtRemarks" runat="server" CssClass="form-control"></asp:textbox></TD>
							<TD></TD>
							<TD>
								<asp:Label id="lblPlusErr" runat="server" Visible="False"></asp:Label></TD>
							<TD></TD>
							<TD></TD>
							<TD></TD>
						</TR>
						<TR>
							<TD>
								<asp:label id="lblreceiptCode" runat="server" Width="63px" Visible="False"></asp:label></TD>
							<TD colSpan="3">
								<asp:button id="btnSave" runat="server" CssClass="button button2" BorderStyle="Groove"  Font-Names="Arial" Font-Size="Smaller" Text="Save Receipt"></asp:button></TD>
							<TD>
								<asp:button id="btnReceiptClear" runat="server" CssClass="button button2" BorderStyle="Groove" Font-Names="Arial" Font-Size="Smaller" Text="Clear" CausesValidation="False"></asp:button></TD>
							<TD>
								<asp:button id="btnReceiptExit" runat="server" CssClass="button button2" BorderStyle="Groove" Font-Names="Arial" Font-Size="Smaller" Text="Exit" CausesValidation="False"></asp:button></TD>
							<TD></TD>
							<TD>
								<asp:Label id="lblMinusErr" runat="server" Visible="False"></asp:Label></TD>
							<TD></TD>
							<TD></TD>
							<TD></TD>
						</TR>
					</TABLE>
				</asp:panel>
				<asp:panel id="pnlCalibrate" runat="server">
					<TABLE id="Table5" class="table">
						<TR>
							<TD>CalibrationDate</TD>
							<TD>
								<asp:TextBox id="txtDate" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox></TD>
							<TD>
								<asp:RangeValidator id="RangeValidator2" runat="server" ControlToValidate="txtDate" ErrorMessage="*" Type="Date" MaximumValue="1/1/9999" MinimumValue="1/1/1990"></asp:RangeValidator></TD>
							<TD>
								<asp:RequiredFieldValidator id="RequiredFieldValidator15" runat="server" ControlToValidate="txtDate" ErrorMessage="*"></asp:RequiredFieldValidator></TD>
							<TD>StandardReading</TD>
							<TD>
								<asp:TextBox id="txtstandrad_reading" runat="server" CssClass="form-control"></asp:TextBox></TD>
							<TD>
								<asp:requiredfieldvalidator id="Requiredfieldvalidator9" runat="server" ControlToValidate="txtstandrad_reading" ErrorMessage="*"></asp:requiredfieldvalidator></TD>
							<TD>PlusErrorCorrected</TD>
							<TD>
								<asp:textbox id="txtCaliPlusErr" runat="server" CssClass="form-control"></asp:textbox></TD>
							<TD>
								<asp:requiredfieldvalidator id="Requiredfieldvalidator7" runat="server" ControlToValidate="txtCaliPlusErr" ErrorMessage="*"></asp:requiredfieldvalidator></TD>
						</TR>
						<TR>
							<TD>MinusErroCorrected</TD>
							<TD>
								<asp:textbox id="txtCaliMinusErr" runat="server" CssClass="form-control"></asp:textbox></TD>
							<TD>
								<asp:requiredfieldvalidator id="Requiredfieldvalidator8" runat="server" ControlToValidate="txtCaliMinusErr" ErrorMessage="*"></asp:requiredfieldvalidator></TD>
							<TD></TD>
							<TD>AccuracyCalibrated</TD>
							<TD>
								<asp:TextBox id="txtAccuracy" runat="server" CssClass="form-control"></asp:TextBox></TD>
							<TD>
								<asp:RequiredFieldValidator id="RequiredFieldValidator14" runat="server" ControlToValidate="txtAccuracy" ErrorMessage="*"></asp:RequiredFieldValidator></TD>
							<TD>AmbientTempInDegrees</TD>
							<TD>
								<asp:TextBox id="txtTemp" runat="server" CssClass="form-control"></asp:TextBox></TD>
							<TD>
								<asp:RequiredFieldValidator id="RequiredFieldValidator6" runat="server" ControlToValidate="txtTemp" ErrorMessage="*"></asp:RequiredFieldValidator></TD>
						</TR>
						<TR>
							<TD>CalibratingPerson</TD>
							<TD>
								<asp:TextBox id="txtPerson" runat="server" CssClass="form-control"></asp:TextBox></TD>
							<TD>
								<asp:RequiredFieldValidator id="RequiredFieldValidator13" runat="server" ControlToValidate="txtPerson" ErrorMessage="*"></asp:RequiredFieldValidator></TD>
							<TD></TD>
							<TD>Verified By</TD>
							<TD>
								<asp:TextBox id="txtVerified" runat="server" CssClass="form-control"></asp:TextBox></TD>
							<TD>
								<asp:RequiredFieldValidator id="RequiredFieldValidator12" runat="server" ControlToValidate="txtVerified" ErrorMessage="*"></asp:RequiredFieldValidator></TD>
							<TD>Remarks
							</TD>
							<TD>
								<asp:TextBox id="txtCaliRemarks" runat="server" CssClass="form-control"></asp:TextBox></TD>
							<TD>
								<asp:RequiredFieldValidator id="RequiredFieldValidator11" runat="server" ControlToValidate="txtCaliRemarks" ErrorMessage="*"></asp:RequiredFieldValidator></TD>
						</TR>
						<TR>
							<TD>
								<asp:Label id="lblCalibrationCode" runat="server" Visible="False"></asp:Label></TD>
							<TD>
								<asp:Button id="btnCalibrateSave" runat="server" BorderStyle="Groove" CssClass="button button2" Font-Names="Arial" Font-Size="Smaller" Text="Save Calibration"></asp:Button></TD>
							<TD></TD>
							<TD></TD>
							<TD>
								<asp:Button id="btnCalibrateClear" runat="server" CssClass="button button2" BorderStyle="Groove" Font-Names="Arial" Font-Size="Smaller" Text="Clear"></asp:Button></TD>
							<TD>
								<asp:Button id="btnCalibrateExit" runat="server" CssClass="button button2" BorderStyle="Groove" Font-Names="Arial" Font-Size="Smaller" Text="Exit" CausesValidation="False"></asp:Button></TD>
							<TD></TD>
							<TD></TD>
							<TD></TD>
							<TD></TD>
						</TR>
					</TABLE>
				</asp:panel>
				<asp:Panel id="pnlIssue" runat="server">
					<TABLE id="Table6" class="table">
						<TR>
							<TD>CalibrationFrequency</TD>
							<TD>
								<asp:DropDownList id="ddlIssFrq" CssClass="form-control ll" runat="server"></asp:DropDownList></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 152px" colSpan="2">
								<asp:CheckBox id="chkFRQ" runat="server" CssClass="checkbox" AutoPostBack="True" Text="Change Frequency"></asp:CheckBox></TD>
						</TR>
						<TR>
							<TD>Issued Date</TD>
							<TD>:
								<asp:textbox id="txtIssueDate" CssClass="form-control" runat="server" AutoPostBack="True"></asp:textbox>
								<asp:rangevalidator id="Rangevalidator6" runat="server" ControlToValidate="txtDate" ErrorMessage="*" Type="Date" MaximumValue="1/1/9999" MinimumValue="1/1/1990"></asp:rangevalidator>
								<asp:requiredfieldvalidator id="Requiredfieldvalidator18" runat="server" ControlToValidate="txtIssueDate" ErrorMessage="*"></asp:requiredfieldvalidator></TD>
						</TR>
						<TR>
							<TD>Issued By</TD>
							<TD>:
								<asp:textbox id="txtIssued_by" runat="server" CssClass="form-control"></asp:textbox>
								<asp:requiredfieldvalidator id="Requiredfieldvalidator17" runat="server" ControlToValidate="txtIssued_by" ErrorMessage="*"></asp:requiredfieldvalidator></TD>
						</TR>
						<TR>
							<TD>Issued To</TD>
							<TD>:
								<asp:textbox id="txtIssued_to" CssClass="form-control" runat="server"></asp:textbox>
								<asp:requiredfieldvalidator id="Requiredfieldvalidator16" runat="server" ControlToValidate="txtIssued_to" ErrorMessage="*"></asp:requiredfieldvalidator></TD>
						</TR>
						<TR>
							<TD align="middle" width="100%" colSpan="2">
								<asp:button id="btnIssue" runat="server" CssClass="button button2" BorderStyle="Groove" Font-Names="Arial" Font-Size="Smaller" Text="Save Issue"></asp:button>
								<asp:button id="btnClear" runat="server" BorderStyle="Groove" CssClass="button button2" Font-Names="Arial" Font-Size="Smaller" Text="Clear"></asp:button>
								<asp:button id="btnExit" runat="server" CssClass="button button2" BorderStyle="Groove"  Font-Names="Arial" Font-Size="Smaller" Text="Exit" CausesValidation="False"></asp:button></TD>
						</TR>
					</TABLE>
					<asp:label id="lblIssueCode" runat="server" Visible="False"></asp:label>
				</asp:Panel>
				<asp:DataGrid id="DataGrid2" runat="server" CssClass="table" BackColor="White" CellPadding="4" BorderWidth="1px" BorderStyle="None" BorderColor="#3366CC" PageSize="5" AllowPaging="True">
					<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<Columns>
						<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
				</asp:DataGrid>
				<asp:Panel id="pnlData" runat="server">
					<TABLE id="Table7" class="table">
						<TR>
							<TD>CalibrationDate</TD>
							<TD>:</TD>
							<TD>
								<asp:TextBox id="txtDataDate" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox></TD>
						</TR>
					</TABLE>
					<TABLE id="Table8" class="table">
						<TR>
							<TD>SlNo</TD>
							<TD>Size</TD>
							<TD>Reading</TD>
							<TD>Error</TD>
						</TR>
						<TR>
							<TD>
								<asp:TextBox id="txtSl" runat="server" CssClass="form-control"></asp:TextBox></TD>
							<TD>
								<asp:TextBox id="txtSize" runat="server" CssClass="form-control"></asp:TextBox></TD>
							<TD>
								<asp:TextBox id="txtReading" runat="server" CssClass="form-control"></asp:TextBox></TD>
							<TD>
								<asp:TextBox id="txtError" runat="server" CssClass="form-control"></asp:TextBox></TD>
						</TR>
						<TR>
							<TD vAlign="top" align="middle" colSpan="4">
								<asp:Label id="lblInHouseID" runat="server" Visible="False"></asp:Label>
								<asp:Button id="btnInHouseData" runat="server" CssClass="button button2" Text="Save InHouse Data"></asp:Button></TD>
						</TR>
					</TABLE>
					<TABLE id="Table9" class="table">
						<TR>
							<TD vAlign="top" align="left">Present Readings :
							</TD>
							<TD vAlign="top" align="left">Previous Readings :</TD>
						</TR>
						<TR>
							<TD vAlign="top" align="left">
								<asp:DataGrid id="DataGrid3" runat="server" CssClass="table" ForeColor="Black" BackColor="White" CellPadding="3" BorderWidth="1px" BorderStyle="Solid" BorderColor="#999999" GridLines="Vertical">
									<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#000099"></SelectedItemStyle>
									<AlternatingItemStyle BackColor="#CCCCCC"></AlternatingItemStyle>
									<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Black"></HeaderStyle>
									<FooterStyle BackColor="#CCCCCC"></FooterStyle>
									<Columns>
										<asp:ButtonColumn Text="Delete" CommandName="Delete"></asp:ButtonColumn>
									</Columns>
									<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999"></PagerStyle>
								</asp:DataGrid></TD>
							<TD vAlign="top" align="left">
								<asp:DataGrid id="DataGrid4" runat="server" BackColor="White" CssClass="table" CellPadding="4" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966">
									<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
									<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
									<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
									<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
									<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
								</asp:DataGrid></TD>
						</TR>
					</TABLE>
				</asp:Panel>
			</asp:panel></form>
                 <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
