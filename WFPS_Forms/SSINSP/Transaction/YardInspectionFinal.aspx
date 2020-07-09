<%@ Page Language="vb" AutoEventWireup="false" Codebehind="YardInspectionFinal.aspx.vb" Inherits="WebApplication2.YardInspectionFinal" smartNavigation="True" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>YardInspectionFinal</title>
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
       <%--<link rel="stylesheet" href="../../../StyleSheet1.css" />--%>
	</HEAD>
	<body >
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
<!--/.Navbar -->
        <div class="container">
		<form id="Form1" method="post" runat="server">
                         <div class="row">
    
                  <%--<h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>--%>
            
               <%--  <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>--%>
                 <br />
      </div>
            <div class="row"><div class="table-responsive">
			<TABLE id="Table2" class="table">
				<TR>
					<TD align="middle" colSpan="2"><FONT size="5">Yard Inspection (Final stock Rework Wheel)</FONT><hr class="prettyline" /></TD>
				</TR>
				<TR>
					<TD align="middle" colSpan="2">(Final Inspector code :
						<asp:label id="lblFinalInsp" runat="server"></asp:label>)</TD>
				</TR>
				<TR>
					<TD >Message:</TD>
					<TD  noWrap>Wheels to be Verified</TD>
				</TR>
                </table>
				<FONT color="#ff0066" size="5"><asp:checkbox id="CheckBox1" runat="server" AutoPostBack="True" Text="Help: "></asp:checkbox></FONT>
                                    <asp:panel id="pnlhelp" runat="server" >
            <TABLE id="Table3" class="table">
												<TR>
													<TD noWrap>1. Yard Insp Final wheels are picked from Yard Insp Magna inputs</TD>
												</TR>
												<TR>
													<TD noWrap>2. Select wheel from list or input wheel number &amp; heat number</TD>
												</TR>
												<TR>
													<TD noWrap>3. To change Insp parameters edit in relevent text box <FONT size="3"><FONT color="#ff3366">
																before</FONT> </FONT>clicking "Verify" button.</TD>
												</TR>
												<TR>
													<TD noWrap>4. Click 'Verified' button to finalise the verification process for the 
														wheel</TD>
												</TR>
												<TR>
													<TD noWrap>5. Unless verification is complete for a wheel it is not counted in 
														outturn.</TD>
												</TR>
											</TABLE>&nbsp;
                                       </asp:panel> <FONT color="#ff0066" size="5">PLEASE VERIFY XC WHEELS WITHOUT FAIL.</FONT>
								
                        <TABLE id="Table1" class="table">
							<TR>
								<TD align="middle" colSpan="6"><asp:label id="Label1" runat="server"  ForeColor="Green" Font-Bold="True" Font-Size="Large">Check wheels by ticking on and off 'XC Wheels' option</asp:label></TD>
							</TR>
                            <tr>
                                <TD colspan="6">
						<p><asp:checkbox id="chkXCWheels" tabIndex="-1" runat="server" AutoPostBack="True" Text="XC Wheels"></asp:checkbox>
                            <asp:checkbox id="chkReInspect" tabIndex="-1" runat="server" AutoPostBack="True" Text="ReInspect" Font-Bold="True"></asp:checkbox>
							<asp:checkbox id="chkRLPTWheels" tabIndex="-1" runat="server" Text="RLPTWheels" AutoPostBack="True" Font-Bold="True"></asp:checkbox></p>
						<p ><asp:listbox id="lstWheelsForVerfiy" runat="server" AutoPostBack="True"   Width="400px" CssClass="ll form-control"></asp:listbox></p>
					</TD>
                            </tr>
							<TR>
								<TD>Wheel Number</TD>
								<TD>:</TD>
								<TD noWrap><asp:textbox id="txtWheelNumber" runat="server" AutoPostBack="True" CssClass="form-control"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" EnableClientScript="False" ErrorMessage="*" Display="Dynamic" ControlToValidate="txtWheelNumber"></asp:requiredfieldvalidator></TD>
								<TD>Heat Number</TD>
								<TD>:</TD>
								<TD><asp:textbox id="txtHeatNumber" runat="server" AutoPostBack="True" CssClass="form-control"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" EnableClientScript="False" ErrorMessage="*" Display="Dynamic" ControlToValidate="txtHeatNumber"></asp:requiredfieldvalidator></TD>
							</TR>
							<TR>
								<TD><asp:label id="lblhdTreadDia" runat="server">Tread Dia</asp:label></TD>
								<TD></TD>
								<TD noWrap><asp:textbox id="txtTreaddia" runat="server" AutoPostBack="True" CssClass="form-control"></asp:textbox></TD>
								<TD><asp:label id="lblhdBoreStatus" runat="server">Bore Status</asp:label></TD>
								<TD></TD>
								<TD><asp:textbox id="txtBoreSts" runat="server" AutoPostBack="True" CssClass="form-control"></asp:textbox>
                                    <asp:label id="lblBoreDia" runat="server">Bore Dia</asp:label>
                                    <asp:textbox id="txtBoreDia" runat="server" AutoPostBack="True" CssClass="form-control"></asp:textbox></TD>
							</TR>
							<TR>
								<TD><asp:label id="lblhdPlateStatus" runat="server">Plate Status</asp:label></TD>
								<TD></TD>
								<TD noWrap><asp:textbox id="txtPlateSts" runat="server" AutoPostBack="True" CssClass="form-control"></asp:textbox></TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
                                <td></td>
							</TR>
                            <tr>
                                <td>rim width</td>
                                <td><asp:TextBox ID="txt1" runat="server" CssClass="form-control"></asp:TextBox></td>
                                <td>HUb Length</td>
                                <td><asp:TextBox ID="txt2" runat="server" CssClass="form-control"></asp:TextBox></td>
                            </tr>
							<TR>
								<TD  colSpan="3"><asp:label id="lblDisposition" runat="server">Wheel Disposition</asp:label></TD>
								<TD colSpan="3"><asp:radiobuttonlist id="rdoDisposition" runat="server" AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl">
										<asp:ListItem Value="P">Pass</asp:ListItem>
										<asp:ListItem Value="W">Hold</asp:ListItem>
										<asp:ListItem Value="R">Reject</asp:ListItem>
									</asp:radiobuttonlist></TD>
							</TR>
							<TR>
								<TD>
									<asp:label id="lblCode" runat="server" Visible="False">Code</asp:label></TD>
								<TD colSpan="3">
									<asp:dropdownlist id="ddlRej" runat="server" AutoPostBack="True" CssClass="form-control ll" Visible="False"></asp:dropdownlist></TD>
								<TD colSpan="2">
									<asp:dropdownlist id="ddlRew" runat="server" AutoPostBack="True" CssClass="form-control ll" Visible="False"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD align="middle" colSpan="6"><asp:label id="lblTreadDia" runat="server" Visible="False"></asp:label>
                                    <asp:label id="lblMaxTD" runat="server" Visible="False"></asp:label>
                                    <asp:label id="lblminTD" runat="server" Visible="False"></asp:label>
                                    <asp:label id="lblPlateSts" runat="server" Visible="False"></asp:label>
                                    <asp:label id="lblBoreSts" runat="server" Visible="False"></asp:label>
                                    <asp:label id="lblMagDisposition" runat="server"></asp:label>
                                    <asp:button id="btnSave" runat="server" Text="Verified" CssClass="button button2"></asp:button></TD>
							</TR>
							<TR>
								<TD align="middle" colSpan="6"><asp:label id="lblMessage" runat="server"  ForeColor="Red" Font-Bold="True" Font-Size="Medium"></asp:label></TD>
							</TR>
							<TR>
								<TD align="middle" colSpan="6"><asp:label id="lblSaveMessage" runat="server" ForeColor="Blue" Font-Bold="True" Font-Size="Small"></asp:label></TD>
							</TR>
						</TABLE>
					
				
						<asp:datagrid id="dgVerify" runat="server" CssClass="table" GridLines="Horizontal" CellPadding="3" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#E7E7FF" AutoGenerateColumns="False">
							<SelectedItemStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#738A9C"></SelectedItemStyle>
							<AlternatingItemStyle BackColor="#F7F7F7"></AlternatingItemStyle>
							<ItemStyle ForeColor="#4A3C8C" BackColor="#E7E7FF"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#4A3C8C"></HeaderStyle>
							<FooterStyle ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
							<Columns>
								<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel" EditText="Edit"></asp:EditCommandColumn>
								<asp:BoundColumn DataField="Wheel" ReadOnly="True" HeaderText="Wheel"></asp:BoundColumn>
								<asp:BoundColumn DataField="WaitingFrom" ReadOnly="True" HeaderText="WaitingFrom"></asp:BoundColumn>
								<asp:BoundColumn DataField="Shift" ReadOnly="True" HeaderText="Shift"></asp:BoundColumn>
								<asp:BoundColumn DataField="LastMcnOpn" ReadOnly="True" HeaderText="LastMcnOpn"></asp:BoundColumn>
								<asp:BoundColumn DataField="MagnaDisposition" ReadOnly="True" HeaderText="MagnaDisp"></asp:BoundColumn>
								<asp:BoundColumn DataField="Disposition" ReadOnly="True" HeaderText="FI_Disposition"></asp:BoundColumn>
								<asp:BoundColumn DataField="TreadDia" HeaderText="TreadDia"></asp:BoundColumn>
								<asp:BoundColumn DataField="BoreSts" HeaderText="BoreSts"></asp:BoundColumn>
								<asp:BoundColumn DataField="BoreDia" HeaderText="BoreDia"></asp:BoundColumn>
								<asp:BoundColumn DataField="PlateSts" HeaderText="PlateSts"></asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Right" ForeColor="#4A3C8C" BackColor="#E7E7FF" Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
				
						<asp:dropdownlist id="ddlGridOption" runat="server" AutoPostBack="True" CssClass="form-control ll" Width="400px">
							<asp:ListItem Value="Saved Data">Saved Data</asp:ListItem>
							<asp:ListItem Value="Score">Score</asp:ListItem>
						</asp:dropdownlist>Verified Records for the 
						Day
						<asp:datagrid id="dgYardInsp" runat="server" ForeColor="Black" CssClass="table" BorderColor="Tan" BorderWidth="1px" BackColor="LightGoldenrodYellow" CellPadding="2" GridLines="None">
							<SelectedItemStyle ForeColor="GhostWhite" BackColor="DarkSlateBlue"></SelectedItemStyle>
							<AlternatingItemStyle BackColor="PaleGoldenrod"></AlternatingItemStyle>
							<HeaderStyle Font-Bold="True" BackColor="Tan"></HeaderStyle>
							<FooterStyle BackColor="Tan"></FooterStyle>
							<PagerStyle HorizontalAlign="Center" ForeColor="DarkSlateBlue" BackColor="PaleGoldenrod"></PagerStyle>
						</asp:datagrid>
				
		</div></div></form></div>
        <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
