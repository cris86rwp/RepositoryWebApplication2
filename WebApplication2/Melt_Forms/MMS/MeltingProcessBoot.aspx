<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MeltingProcessBoot.aspx.vb" Inherits="WebApplication2.MeltingProcessBoot" %>

<HTML>
	<HEAD runat="server">
		<title>MeltingProcess</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR"/>
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/> 

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
  <%-- <link rel="stylesheet" href="../../App_Themes/Theme3/Theme3.css" />--%>
	    <style type="text/css">
            .auto-style4 {
                width: 999px;
            }
            .auto-style5 {
                width: 100%;
                border-collapse: collapse;
                max-width: 100%;
                text-align: center;
                height: 35px;
                margin-bottom: 20px;
                background-color: transparent;
            }
            .auto-style6 {
                width: 205px;
            }
            .auto-style7 {
                height: 39px;
            }
            </style>
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
<!--/.Navbar -->
         <div class="container">
		<form id="Form1" method="post" runat="server">
              <div class="row">
    
       <%--           <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
      </div>
             <div class="row">
                <div class="table-responsive">
			<asp:panel id="pnlAll" runat="server">
				<TABLE id="Table1" class="table">
					<TR>
						<TD align="center" class="auto-style4">HEAT SHEET ENTRY- MS-011<hr class="prettyline" />
							<asp:RadioButtonList id="rblSheet" runat="server" CssClass="rbl" AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal">
								<asp:ListItem Value="1" Selected="True">Sheet 1</asp:ListItem>
								<asp:ListItem Value="2">Sheet 2</asp:ListItem>
								<asp:ListItem Value="3">Sheet 3</asp:ListItem>
								<asp:ListItem Value="4">Sample</asp:ListItem>
							</asp:RadioButtonList></TD>
					</TR>
					<TR>
						<TD align="left" class="auto-style4">
							<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></TD>
					</TR>
				</TABLE>
				<asp:Panel id="pnlSheet1" runat="server" >
					<TABLE id="Table3" runat="server">
						<TR>
							<TD>HeatNo</TD>
							<TD>
								<asp:textbox id="txtHeatNo1" runat="server" CssClass="form-control" AutoPostBack="True" BorderStyle="Groove"></asp:textbox></TD>
							<TD>FurNo</TD>
							<TD>
								<asp:DropDownList ID="FurNo" runat="server"  AutoPostBack="True"   CssClass="form-control ll" Width="79px"  >
                                    <asp:ListItem>A</asp:ListItem>
                                    <asp:ListItem>B</asp:ListItem>
                                    <asp:ListItem>C</asp:ListItem>
                                    <asp:ListItem></asp:ListItem>
                                </asp:DropDownList>
                            </TD>
							<TD>Date</TD>
							<TD>
								<asp:textbox id="txtDate" runat="server" CssClass="form-control" AutoPostBack="True" BorderStyle="Groove"></asp:textbox></TD>
							<TD>Shift</TD>
							<TD class="auto-style6">
								<asp:RadioButtonList id="rblShift" runat="server" CssClass="rbl" RepeatLayout="Flow" RepeatDirection="Horizontal">
									<asp:ListItem Value="A" Selected="True">A</asp:ListItem>
									<asp:ListItem Value="B">B</asp:ListItem>
									<asp:ListItem Value="C">C</asp:ListItem>
								</asp:RadioButtonList></TD>
							<TD>ShiftI/C</TD>
							<TD>
								<asp:textbox id="txtShift_incharge" runat="server" CssClass="form-control" BorderStyle="Groove" MaxLength="30"></asp:textbox></TD>
							<TD>FurI/C</TD>
							<TD>
								<asp:textbox id="txtFurnace_incharge" runat="server" CssClass="form-control" BorderStyle="Groove" MaxLength="30"></asp:textbox></TD>
							<TD>
								<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" CssClass="form-control" ErrorMessage="Furnace In Charge is Empty" ControlToValidate="txtFurnace_incharge"></asp:RequiredFieldValidator></TD>
                            <TD>FurOPR</TD>
                            <TD> <asp:textbox id="txtFurnace_Operator" runat="server" CssClass="form-control" BorderStyle="Groove" MaxLength="30"></asp:textbox></TD>

						</TR>
                       
					</TABLE>
                    <TABLE ID="Table24"  runat="server" CssClass="form-control" class="auto-style5">
                        <TR>
                           <TD > WO No. </TD>
                            <TD>
                                <asp:DropDownList ID="DDLWO" runat="server"  AutoPostBack="True" BorderStyle="Groove"  CssClass="form-control ll">
                                </asp:DropDownList>
                                 </TD>
                        </TR>
                        </TABLE>
                   
 <asp:DataGrid ID="DataGrid2" runat="server" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" CssClass="table">
                        <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                        <ItemStyle BackColor="White" ForeColor="#330099" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                    </asp:DataGrid>   
                  
                   
					<TABLE id="Table2" class="table"></TABLE>
						
								<TABLE id="Table8" class="table">
									<TR>
										<TD colSpan="3">Furnace&nbsp;Conditions&nbsp;</TD>
                                        <TD>Remarks&nbsp;</TD>
									</TR>
									<TR>
										<TD>Bottom</TD>
										<TD>:</TD>
										<TD>
											<asp:DropDownList id="txtFurnace_bottom" runat="server" CssClass="form-control ll" BorderStyle="Groove" MaxLength="20" AutoCompleteType="Enabled" AutoPostBack="True">
                                                <asp:ListItem>OK</asp:ListItem>
                                                <asp:ListItem>NOT OK</asp:ListItem>
                                            </asp:DropDownList></TD>
                                         <TD><asp:textbox ID ="FBRMK" RUNAT="server" CssClass="form-control ll"  Visible="False"></asp:textbox></TD>
									</TR>
									<TR>
										<TD>S/Wall up</TD>
										<TD>:</TD>
										<TD>
											<asp:DropDownList id="txtSidewall_up" runat="server" CssClass="form-control ll" BorderStyle="Groove" MaxLength="20" AutoPostBack="True">
                                                <asp:ListItem>OK</asp:ListItem>
                                                <asp:ListItem>NOT OK</asp:ListItem>
                                            </asp:DropDownList></TD>
                                        <TD><asp:textbox ID ="FSWURMK" RUNAT="server"  CssClass="form-control ll"  Visible="False"></asp:textbox></TD>
									</TR>
									<TR>
										<TD>S/Wall lo</TD>
										<TD>:</TD>
										<TD>
											<asp:DropDownList id="txtSidewall_lo" runat="server" CssClass="form-control ll" BorderStyle="Groove" MaxLength="20" AutoPostBack="True">
                                                <asp:ListItem>OK</asp:ListItem>
                                                <asp:ListItem>NOT OK</asp:ListItem>
                                            </asp:DropDownList></TD>
                                        <TD><asp:textbox ID ="FSWLRMK" RUNAT="server" CssClass="form-control ll"  Visible="False"></asp:textbox></TD>
									</TR>
									<TR>
										<TD>Bank</TD>
										<TD>:</TD>
										<TD>
											<asp:DropDownList id="txtBank" runat="server" CssClass="form-control ll" BorderStyle="Groove" MaxLength="6" AutoPostBack="True">
                                                <asp:ListItem>OK</asp:ListItem>
                                                <asp:ListItem>NOT OK</asp:ListItem>
                                            </asp:DropDownList></TD>
                                        <TD><asp:textbox ID ="FBTRMK" RUNAT="server" CssClass="form-control ll"  Visible="False"></asp:textbox></TD>
									</TR>
									<TR>
										<TD>Fur. Life</TD>
										<TD>:</TD>
										<TD>
											<asp:textbox id="txtFunace_life" runat="server" CssClass="form-control" BorderStyle="Groove"></asp:textbox></TD>
									</TR>
                                    <TR>
										<TD>DRM Life</TD>
										<TD>:</TD>
										<TD>
											<asp:textbox id="TXTDRM" runat="server" CssClass="form-control" BorderStyle="Groove" MaxLength="4" AutoPostBack="True"></asp:textbox></TD>
									</TR>
                                      <TR>
										<TD>Brick Life</TD>
										<TD>:</TD>
										<TD>
											<asp:textbox id="TXTBRICK" runat="server" CssClass="form-control" BorderStyle="Groove" MaxLength="4" AutoPostBack="True"></asp:textbox></TD>
									</TR>
								</TABLE>
							
								<TABLE id="Table4" class="table">
									<TR>
										<TD>Ladle No<FONT color="#ff0033"><strong>*</strong></TD>
										<TD>:</TD>
										<TD>
											<asp:textbox id="txtLadle_number" runat="server" CssClass="form-control" AutoPostBack="True" BorderStyle="Groove" MaxLength="5"></asp:textbox>
											<asp:rangevalidator id="rngvalLadleNo" runat="server" ErrorMessage="NumOnly" ControlToValidate="txtLadle_number" MaximumValue="9999" MinimumValue="1" Display="Dynamic"></asp:rangevalidator></TD>
									</TR>
									<TR>
										<TD>PreHeat/Life</TD>
										<TD>:</TD>
										<TD>
											<asp:Label id="Ht" runat="server"></asp:Label>&nbsp;/
											<asp:label id="li" runat="server"></asp:label></TD>
									</TR>
									<TR>
										<TD>Ladle<FONT color="#ff0033">EmptyWt</FONT></TD>
										<TD>:</TD>
										<TD>
											<asp:textbox id="txtw1" runat="server" CssClass="form-control"></asp:textbox></TD>
									</TR>
									<TR>
										<TD>Life<FONT color="#ff0033"><strong>*</strong></TD>
										<TD>:</TD>
										<TD>
											<asp:textbox id="txtLadle_life" runat="server" CssClass="form-control" BorderStyle="Groove" MaxLength="4"></asp:textbox>
											<asp:rangevalidator id="RangeValidator1" runat="server" ErrorMessage="NumOnly" ControlToValidate="txtLadle_life" MaximumValue="9999" MinimumValue="1" Display="Dynamic"></asp:rangevalidator></TD>
									</TR>
									<TR>
										<TD>Bottom</TD>
										<TD>:</TD>
										<TD>
											<asp:DropDownList id="txtLadle_bottom" runat="server" CssClass="form-control ll" BorderStyle="Groove" MaxLength="20" AutoPostBack="True">
                                                <asp:ListItem>JMP</asp:ListItem>
                                                <asp:ListItem>LPH</asp:ListItem>
                                                <asp:ListItem></asp:ListItem>
                                            </asp:DropDownList></TD>
									</TR>
									<TR>
										<TD>S/Wall</TD>
										<TD>:</TD>
										<TD>
											<asp:DropDownList id="txtLadle_sidewall" runat="server" CssClass="form-control ll" BorderStyle="Groove" MaxLength="20" AutoPostBack="True">
                                                <asp:ListItem>OK</asp:ListItem>
                                                <asp:ListItem>NOT OK</asp:ListItem>
                                                <asp:ListItem></asp:ListItem>
                                            </asp:DropDownList></TD>
                                      </TR>
								</TABLE>
							
								<TABLE id="Table5" class="table">
									<TR>
										<TD colSpan="3">Roof&nbsp;Details</TD>
									</TR>
									<TR>
										<TD>No(<strong>*</strong>)</TD>
										<TD>:</TD>
										<TD>
											<asp:textbox id="txtRoof_number" runat="server" CssClass="form-control" BorderStyle="Groove" MaxLength="20"></asp:textbox>
											<asp:requiredfieldvalidator id="rfvld1" runat="server" ErrorMessage="*" ControlToValidate="txtRoof_number" Display="Dynamic"></asp:requiredfieldvalidator></TD>
									</TR>
									<TR>
										<TD>Life</TD>
										<TD>:</TD>
										<TD>
											<asp:textbox id="txtRoof_life" runat="server" CssClass="form-control" BorderStyle="Groove" MaxLength="4"></asp:textbox>
											<asp:rangevalidator id="RangeValidator3" runat="server" ErrorMessage="NumOnly" ControlToValidate="txtRoof_life" MaximumValue="9999" MinimumValue="1" Display="Dynamic"></asp:rangevalidator></TD>
									</TR>
									<TR>
										<TD>Delta</TD>
										<TD>:</TD>
										<TD>
											<asp:textbox id="txtRoof_delta" runat="server" CssClass="form-control" BorderStyle="Groove" MaxLength="50"></asp:textbox></TD>
									</TR>
									<TR>
										<TD>Outer</TD>
										<TD>:</TD>
										<TD>
											<asp:textbox id="txtRoof_outer" runat="server" CssClass="form-control" BorderStyle="Groove" MaxLength="50"></asp:textbox></TD>
									</TR>
								</TABLE>
							
								<TABLE id="Table7" class="table">
									<TR>
										<TD  colSpan="3">Bucket&nbsp;&nbsp;Details&nbsp;</TD>
									</TR>
									<TR>
										<TD >No</TD>
										<TD >:</TD>
										<TD >
											<asp:textbox id="txtBucket_number" runat="server" CssClass="form-control" BorderStyle="Groove" MaxLength="10"></asp:textbox></TD>
									</TR>
									<TR>
										<TD >C/Oper</TD>
										<TD >:</TD>
										<TD >
											<asp:textbox id="txtBucket_enteredby" runat="server" CssClass="form-control" BorderStyle="Groove" MaxLength="30"></asp:textbox></TD>
									</TR>
									<TR>
										<TD >No</TD>
										<TD >:</TD>
										<TD >
											<asp:textbox id="txtBucket_number2" runat="server" CssClass="form-control" BorderStyle="Groove" MaxLength="10"></asp:textbox></TD>
									</TR>
									<TR>
										<TD >C/Oper</TD>
										<TD>:</TD>
										<TD >
											<asp:textbox id="txtBucket_enteredby2" runat="server" CssClass="form-control" BorderStyle="Groove" MaxLength="10"></asp:textbox></TD>
									</TR>
									<TR>
										<TD >No</TD>
										<TD >:</TD>
										<TD >
											<asp:textbox id="txtBucket_number3" runat="server" CssClass="form-control" BorderStyle="Groove" MaxLength="10"></asp:textbox></TD>
									</TR>
									<TR>
										<TD >C/Oper</TD>
										<TD >:</TD>
										<TD >
											<asp:textbox id="txtBucket_enteredby3" runat="server" CssClass="form-control" BorderStyle="Groove" MaxLength="10"></asp:textbox></TD>
									</TR>
								</TABLE>
							
								<TABLE id="Table9" class="table">
									<TR>
										<TD>FettlingDetails</TD>
										<TD>Make</TD>
										<TD>quantity</TD>
									</TR>
									<TR>
										<TD>DRMas(MT)</TD>
										<TD>
											<asp:DropDownList id="txtFrmi_make" runat="server" CssClass="form-control" BorderStyle="Groove" MaxLength="50"></asp:DropDownList></TD>
										<TD>
											<asp:textbox id="txtFrmi_quantity" runat="server" CssClass="form-control" BorderStyle="Groove"></asp:textbox></TD>
									</TR>
									<TR>
										<TD>WRMass</TD>
										<TD>
											<asp:DropDownList id="txtFWrmi_make" runat="server" CssClass="form-control" BorderStyle="Groove" MaxLength="50"></asp:DropDownList></TD>
										<TD>
											<asp:textbox id="txtFWrmi_quantity" runat="server" CssClass="form-control" BorderStyle="Groove" MaxLength="50"></asp:textbox></TD>
									</TR>
									<TR>
										<TD>G/Mix (MT)</TD>
										<TD>
											<asp:DropDownList id="txtFgmi_make" runat="server" CssClass="form-control" BorderStyle="Groove" MaxLength="50"></asp:DropDownList></TD>
										<TD>
											<asp:textbox id="txtFgmi_quantity" runat="server" CssClass="form-control" BorderStyle="Groove"></asp:textbox></TD>
									</TR>
								</TABLE>
							
					
					
						
								<TABLE id="Table11" class="table">
									<TR>
										<TD>Elec. Details</TD>
										<TD>E1</TD>
										<TD>E2</TD>
										<TD>E3</TD>
									</TR>
									<TR>
										<TD>Make</TD>
										<TD>
											<asp:textbox id="txtEmake_e1" runat="server" CssClass="form-control" BorderStyle="Groove" MaxLength="50"></asp:textbox></TD>
										<TD>
											<asp:textbox id="txtEmake_e2" runat="server" CssClass="form-control" BorderStyle="Groove" MaxLength="50"></asp:textbox></TD>
										<TD>
											<asp:textbox id="txtEmake_e3" runat="server" CssClass="form-control" BorderStyle="Groove" MaxLength="50"></asp:textbox></TD>
									</TR>
									<TR>
										<TD>Added /Adj</TD>
										<TD>
											<asp:textbox id="txtEadded_e1" runat="server" CssClass="form-control" BorderStyle="Groove" MaxLength="4"></asp:textbox></TD>
										<TD>
											<asp:textbox id="txtEadded_e2" runat="server" CssClass="form-control" BorderStyle="Groove" MaxLength="4"></asp:textbox></TD>
										<TD>
											<asp:textbox id="txtEadded_e3" runat="server" CssClass="form-control" BorderStyle="Groove" MaxLength="4"></asp:textbox></TD>
									</TR>
									<TR>
										<TD>Tip&nbsp; Profile</TD>
										<TD>
											<asp:textbox id="txtEtip_e1" runat="server" CssClass="form-control" BorderStyle="Groove" MaxLength="500"></asp:textbox></TD>
										<TD>
											<asp:textbox id="txtEtip_e2" runat="server" CssClass="form-control" BorderStyle="Groove" MaxLength="500"></asp:textbox></TD>
										<TD>
											<asp:textbox id="txtEtip_e3" runat="server" CssClass="form-control" BorderStyle="Groove" MaxLength="500"></asp:textbox></TD>
									</TR>
									<TR>
										<TD >Breakage</TD>
										<TD  colSpan="3">
											<asp:RadioButtonList id="rblBreakage" runat="server" AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl">
												<asp:ListItem Value="No" Selected="True">No</asp:ListItem>
												<asp:ListItem Value="Yes">Yes</asp:ListItem>
											</asp:RadioButtonList></TD>
									</TR>
								</TABLE>
								<asp:Panel id="pnlElec" runat="server">
									<TABLE id="Table20" class="table">
										<TR>
											<TD>ElectrodeNo</TD>
											<TD>:</TD>
											<TD>
												<asp:RadioButtonList id="rblNo" runat="server" AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl">
													<asp:ListItem Value="E1" Selected="True">E1</asp:ListItem>
													<asp:ListItem Value="E2">E2</asp:ListItem>
													<asp:ListItem Value="E3">E3</asp:ListItem>
												</asp:RadioButtonList></TD>
										</TR>
										<TR>
											<TD colSpan="3">
												<asp:RadioButtonList id="rblReason" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl">
													<asp:ListItem Value="Initial Arcing" Selected="True">Initial Arcing</asp:ListItem>
													<asp:ListItem Value="Process">Process</asp:ListItem>
													<asp:ListItem Value="Handling">Handling</asp:ListItem>
												</asp:RadioButtonList></TD>
										</TR>
										<TR>
											<TD colSpan="3" class="auto-style7">
												<asp:RadioButtonList id="rblLoc" runat="server"  RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl">
													<asp:ListItem Value="Upper Joint" Selected="True">Upper Joint</asp:ListItem>
													<asp:ListItem Value="Lower Joint">Lower Joint</asp:ListItem>
													<asp:ListItem Value="Full Column">Full Column</asp:ListItem>
												</asp:RadioButtonList></TD>
										</TR>
										<TR>
											<TD>BreakageTime</TD>
											<TD colSpan="2">
												<asp:TextBox id="txtEDate" runat="server" CssClass="form-control"></asp:TextBox>&nbsp; 
												&nbsp;
												<asp:textbox id="txtETime" runat="server" CssClass="form-control" BorderStyle="Groove" placeholder="HH:MM" MaxLength="5"></asp:textbox></TD>
										</TR>
										<TR>
											<TD>Remarks</TD>
											<TD>:</TD>
											<TD>
												<asp:textbox id="txtERemarks" runat="server" CssClass="form-control" BorderStyle="Groove" TextMode="MultiLine"></asp:textbox></TD>
										</TR>
									</TABLE>
								</asp:Panel>
							
								<TABLE id="Table22" class="table"></TABLE>
									
											<TABLE id="Table12" class="table">
												<TR>
													<TD  colSpan="8">MetalicCharge</TD>
												</TR>
												<TR>
													<TD>Riser/Hub</TD>
													<TD >
														<asp:textbox id="txtRiserhub" runat="server" CssClass="form-control" AutoPostBack="True" BorderStyle="Groove"></asp:textbox></TD>
													<TD>MetalCake</TD>
													<TD>
														<asp:textbox id="txtPygmy_pot" runat="server" CssClass="form-control" AutoPostBack="True" BorderStyle="Groove"></asp:textbox></TD>
													<TD>Hot heal</TD>
													<TD>
														<asp:textbox id="txtHot_heal" runat="server" CssClass="form-control" AutoPostBack="True" BorderStyle="Groove"></asp:textbox></TD>
													<TD>Wheel</TD>
													<TD>
														<asp:textbox id="txtWheel" runat="server" CssClass="form-control" AutoPostBack="True" BorderStyle="Groove"></asp:textbox></TD>
												</TR>
												<TR>
													<TD>HMS</TD>
													<TD >
														<asp:textbox id="txtWheel_cut" runat="server" CssClass="form-control" AutoPostBack="True" BorderStyle="Groove"></asp:textbox></TD>
													<TD>LMS</TD>
													<TD>
														<asp:textbox id="txtLMS" runat="server" CssClass="form-control" AutoPostBack="True" BorderStyle="Groove"></asp:textbox></TD>
													<TD>Chips</TD>
													<TD>
														<asp:textbox id="txtTurningboring" runat="server" CssClass="form-control" AutoPostBack="True" BorderStyle="Groove"></asp:textbox></TD>
													<TD><strong>Total</strong></TD>
													<TD>
														<asp:TextBox ID="txtTotal" runat="server" BorderStyle="Groove" ReadOnly="True" CssClass="form-control"></asp:TextBox>
                                                    </TD>
												</TR>
												<TR>
													<TD  colSpan="2">Miscellaneos :</TD>
													<TD>Qty</TD>
													<TD>
														<asp:textbox id="txtSlpr_cut" runat="server" CssClass="form-control" AutoPostBack="True" BorderStyle="Groove"></asp:textbox></TD>
													<TD>Remarks</TD>
													<TD colSpan="3">
														<asp:TextBox id="txtChargeRemarks" runat="server" CssClass="form-control"></asp:TextBox></TD>
												</TR>
											</TABLE>

											<TABLE id="Table23" class="table">
												<TR>
													<TD>NonMetalicCharge</TD>
													<TD>G/Granuals</TD>
													<TD>
														<asp:textbox id="Textbox1" runat="server" CssClass="form-control" AutoPostBack="True" BorderStyle="Groove"></asp:textbox></TD>
													<TD>G/Dust</TD>
													<TD>
														<asp:textbox id="txtNMgdust" runat="server" CssClass="form-control" BorderStyle="Groove"></asp:textbox></TD>
													<TD>Cal/lime</TD>
													<TD>
														<asp:textbox id="txtNMclime" runat="server" CssClass="form-control" BorderStyle="Groove"></asp:textbox></TD>
												</TR>
											</TABLE>
										
								
							
                    <TABLE id="Table6" class="table">
						<TR>
							<TD vAlign="top" align="center">
								<asp:button id="btnSave" runat="server" CssClass="button button2" BorderStyle="Groove" Text="Save" Font-Names="Arial" Font-Size="X-Small"></asp:button>
								<asp:button id="btnClear" runat="server" CssClass="button button2" BorderStyle="Groove" Text="Clear" Font-Names="Arial" Font-Size="X-Small" CausesValidation="False"></asp:button></TD>
						</TR>
					</TABLE>
				</asp:Panel>
				<asp:Panel id="pnlSheet2" runat="server" >
					<TABLE id="Table13" class="table">
						<TR>
							<TD >HeatNo :
								<asp:TextBox id="txtHeatNo2" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox></TD>
							<TD  colSpan="2">HEAT&nbsp;EVENT&nbsp;LOG</TD>
							<TD ></TD>
							<TD>Furnace</TD>
							<TD>Laddle</TD>
						</TR>
					<TR>
							<TD >FurnaceInspn(hh:mm)</TD>
							<TD>
								<asp:TextBox id="txtFurnace_inspectionDate" runat="server" CssClass="form-control"></asp:TextBox></TD>
							<TD >
								<asp:textbox id="txtFurnace_inspection" runat="server" CssClass="form-control" BorderStyle="Groove " placeholder="HH:MM" MaxLength="5"></asp:textbox></TD>
							<TD >G.Dust</TD>
							<TD>
								<asp:textbox id="txtFgdust" runat="server" CssClass="form-control" BorderStyle="Groove"></asp:textbox></TD>
							<TD>
								<asp:textbox id="txtLgdust" runat="server" CssClass="form-control" BorderStyle="Groove"></asp:textbox></TD>
						</TR>
						<TR>
							<TD >RoofOutTime(hh:mm)</TD>
							<TD>
								<asp:TextBox id="txtRoof_outtimeDate" runat="server" CssClass="form-control"></asp:TextBox></TD>
							<TD >
								<asp:textbox id="txtRoof_outtime" runat="server" CssClass="form-control" BorderStyle="Groove" placeholder="HH:MM" MaxLength="5"></asp:textbox></TD>
							<TD >GGranuals</TD>
							<TD>
								<asp:textbox id="txtFlimestone" runat="server" CssClass="form-control" BorderStyle="Groove"></asp:textbox></TD>
							<TD>
								<asp:textbox id="txtLlimestone" runat="server" CssClass="form-control" BorderStyle="Groove"></asp:textbox></TD>
						</TR>
						<TR>
							<TD >Chg.Start(hh:mm)</TD>
							<TD>
								<asp:TextBox id="txtCharge_startDate" runat="server" CssClass="form-control"></asp:TextBox></TD>
							<TD >
								<asp:textbox id="txtCharge_start" runat="server" CssClass="form-control" BorderStyle="Groove" placeholder="HH:MM" MaxLength="5"></asp:textbox></TD>
							<TD >Si-Mn</TD>
							<TD></TD>
							<TD>
								<asp:textbox id="txtLsimn" runat="server" CssClass="form-control" BorderStyle="Groove"></asp:textbox></TD>
						</TR>
						<TR>
							<TD >ChargeMet(hh:mm)</TD>
							<TD>
								<asp:TextBox id="txtCharge_metDate" runat="server" CssClass="form-control"></asp:TextBox></TD>
							<TD >
								<asp:textbox id="txtCharge_met" runat="server" CssClass="form-control" BorderStyle="Groove" placeholder="HH:MM" MaxLength="5"></asp:textbox></TD>

							<TD >Fe-Si</TD>
							<TD>
								<asp:textbox id="txtFfesi" runat="server" CssClass="form-control" BorderStyle="Groove"></asp:textbox></TD>
							<TD>
								<asp:textbox id="txtLfesi" runat="server" CssClass="form-control" BorderStyle="Groove"></asp:textbox></TD>
						</TR>
						<TR>
							<TD >BucketChrg(hh:mm)</TD>
							<TD>
								<asp:TextBox id="txtBucket_chargeDate" runat="server" CssClass="form-control"></asp:TextBox></TD>
							<TD >
								<asp:textbox id="txtBucket_charge" runat="server" CssClass="form-control" BorderStyle="Groove" placeholder="HH:MM" MaxLength="5"></asp:textbox></TD>
							<TD >Fe-Mn</TD>
							<TD>
								<asp:textbox id="txtfFeMn" runat="server" CssClass="form-control" BorderStyle="Groove"></asp:textbox></TD>
							<TD>
								<asp:textbox id="txtLFeMn" runat="server" CssClass="form-control" BorderStyle="Groove"></asp:textbox></TD>
						</TR>
						<TR>
							
							<TD >RemovedMet(hh:mm)</TD>
							<TD>
								<asp:TextBox id="txtremoved_materialDate" runat="server" CssClass="form-control"></asp:TextBox></TD>
							<TD >
								<asp:textbox id="txtremoved_material" runat="server" CssClass="form-control" BorderStyle="Groove" placeholder="HH:MM" MaxLength="5"></asp:textbox></TD>
							
							<TD >Floor</TD>
							<TD>
								<asp:textbox id="txtFfloor" runat="server" CssClass="form-control" BorderStyle="Groove"></asp:textbox></TD>
							<TD>
								<asp:textbox id="txtLfloor" runat="server" CssClass="form-control" BorderStyle="Groove"></asp:textbox></TD>
						</TR>
						<TR>
							<TD >Levelling(hh:mm)</TD>
							<TD>
								<asp:TextBox id="txtLevellingDate" runat="server" CssClass="form-control"></asp:TextBox></TD>
							<TD >
								<asp:textbox id="txtLevelling" runat="server" CssClass="form-control" BorderStyle="Groove" placeholder="HH:MM" MaxLength="5"></asp:textbox></TD>
							
							<TD >CalciumLime</TD>
							<TD>
								<asp:textbox id="txtfCalLime" runat="server" CssClass="form-control" BorderStyle="Groove"></asp:textbox></TD>
							<TD></TD>
						</TR>
						<TR>
							<TD>RoofIn(hh:mm)</TD>
							<TD>
								<asp:TextBox id="txtRoof_inDate" runat="server" CssClass="form-control"></asp:TextBox></TD>
							<TD >
								<asp:textbox id="txtRoof_in" runat="server" CssClass="form-control" BorderStyle="Groove" placeholder="HH:MM" MaxLength="5"></asp:textbox></TD>
							
							<TD >(inMT)</TD>
							<TD>RSM</TD>
							<TD></TD>
						</TR>
						<TR>
							<TD >Chg.End(hh:mm)</TD>
							<TD>
								<asp:TextBox id="txtCharge_endDate" runat="server" CssClass="form-control"></asp:TextBox></TD>
							<TD >
								<asp:textbox id="txtCharge_end" runat="server" CssClass="form-control" BorderStyle="Groove" placeholder="HH:MM" MaxLength="5"></asp:textbox></TD>
							
							<TD >Dept</TD>
							<TD>
								<asp:textbox id="txtrsm_dept" runat="server" CssClass="form-control" BorderStyle="Groove"></asp:textbox></TD>
							<TD></TD>
						</TR>
						<TR>
							<TD>BackChrMet(hh:mm)</TD>
							<TD>
								<asp:TextBox id="txtBucket_chargemetDate" runat="server" CssClass="form-control"></asp:TextBox></TD>
							<TD >
								<asp:textbox id="txtBucket_chargemet" runat="server" CssClass="form-control" BorderStyle="Groove" placeholder="HH:MM" MaxLength="5"></asp:textbox></TD>
							<TD >Contract</TD>
							<TD>
								<asp:textbox id="txtrsm_contract" runat="server" CssClass="form-control" BorderStyle="Groove"></asp:textbox></TD>
							<TD></TD>
						</TR>
						<TR>
						    <TD>
								<asp:DropDownList ID="DDLPOWERON" runat="server" AutoPostBack="True" BorderStyle="Groove" CssClass="form-control ll">
                                    <asp:ListItem Value="PowerOnT01">PowerOnT01</asp:ListItem>
                                    <asp:ListItem Value="PowerOnT02">PowerOnT02</asp:ListItem>
				                    <asp:ListItem Value="PowerOnT03">PowerOnT03</asp:ListItem>
                                    <asp:ListItem Value="PowerOnT04">PowerOnT04</asp:ListItem>
				                    <asp:ListItem Value="PowerOnT05">PowerOnT05</asp:ListItem>
                                    <asp:ListItem Value="PowerOnT06">PowerOnT06</asp:ListItem>
				                    <asp:ListItem Value="PowerOnT07">PowerOnT07</asp:ListItem>
                                    <asp:ListItem Value="PowerOnT08">PowerOnT08</asp:ListItem>
                                    <asp:ListItem Value="PowerOnT09">PowerOnT09</asp:ListItem>
                                    <asp:ListItem Value="PowerOnT10" Selected="True">PowerOnT10</asp:ListItem>
				                    <asp:ListItem Value="PowerOnT11">PowerOnT11</asp:ListItem>
                                    <asp:ListItem Value="PowerOnT12">PowerOnT12</asp:ListItem>
                                    <asp:ListItem Value="PowerOnT13">PowerOnT13</asp:ListItem>
                                    <asp:ListItem Value="PowerOnT14">PowerOnT14</asp:ListItem>
				                    <asp:ListItem Value="PowerOnT15">PowerOnT15</asp:ListItem>
                                    <asp:ListItem Value="PowerOnT16">PowerOnT16</asp:ListItem>
				                    <asp:ListItem Value="PowerOnT17">PowerOnT17</asp:ListItem>                                  
                                    </asp:DropDownList> </TD>
							<TD>
								<asp:TextBox id="txtPower_t101Date" runat="server" CssClass="form-control"></asp:TextBox></TD>
							<TD >
								<asp:textbox id="txtPower_t101" runat="server" CssClass="form-control" BorderStyle="Groove" placeholder="HH:MM" MaxLength="5"></asp:textbox></TD>
							
							<TD >ContractNo</TD>
							<TD colSpan="2">
								<asp:TextBox id="txtContractNo" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox></TD>
						</TR>
						<%--<TR>
							<TD >PonT4(hh:mm)</TD>
							<TD>
								<asp:TextBox id="txtPower_t4Date" runat="server" CssClass="form-control"></asp:TextBox></TD>
							<TD >
								<asp:textbox id="txtPower_t4" runat="server" CssClass="form-control" BorderStyle="Groove" placeholder="HH:MM" MaxLength="5"></asp:textbox></TD>
							<TD ></TD>
							</TR>

                        <TR>
							<TD >PonT6(hh:mm)</TD>
							<TD>
								<asp:TextBox id="txtPower_t6Date" runat="server" CssClass="form-control"></asp:TextBox></TD>
							<TD >
								<asp:textbox id="txtPower_t6" runat="server" CssClass="form-control" BorderStyle="Groove" placeholder="HH:MM" MaxLength="5"></asp:textbox></TD>
							<TD ></TD>
							</TR>
                        <TR>
							<TD >PonT8(hh:mm)</TD>
							<TD>
								<asp:TextBox id="txtPower_t8Date" runat="server" CssClass="form-control"></asp:TextBox></TD>
							<TD >
								<asp:textbox id="txtPower_t8" runat="server" CssClass="form-control" BorderStyle="Groove" placeholder="HH:MM" MaxLength="5"></asp:textbox></TD>
							<TD></TD>
							<TD></TD>
							<TD></TD>
						</TR>
                        <TR>
							<TD >PonT10(hh:mm)</TD>
							<TD>
								<asp:TextBox id="txtPower_t102Date" runat="server" CssClass="form-control"></asp:TextBox></TD>
							<TD>
								<asp:textbox id="txtPower_t102" runat="server" CssClass="form-control" BorderStyle="Groove" placeholder="HH:MM" MaxLength="5"></asp:textbox></TD>
							<TD ></TD>
							<TD></TD>
							<TD></TD>
						</TR>
                        <TR>
							<TD>PonT12(hh:mm)</TD>
							<TD>
								<asp:TextBox id="txtPower_t12Date" runat="server" CssClass="form-control" ></asp:TextBox></TD>
							<TD>
								<asp:textbox id="txtPower_t12" runat="server" CssClass="form-control" BorderStyle="Groove" placeholder="HH:MM" MaxLength="5"></asp:textbox></TD>
							<TD></TD>
							<TD></TD>
							<TD></TD>
						</TR>--%>
                        <TR>
                        	<TD>
								<asp:button id="btnSheet2" accessKey="s" runat="server" CssClass="button button2" BorderStyle="Groove" Text="Save" Font-Names="Arial" Font-Size="X-Small"></asp:button></TD>
							<TD>
								<asp:button id="Button1" accessKey="c" runat="server" CssClass="button button2" BorderStyle="Groove" Text="Clear" Font-Names="Arial" Font-Size="X-Small" CausesValidation="False"></asp:button></TD>
							<TD></TD>
							<TD></TD>
						</TR>
					</TABLE>
					<asp:DataGrid id="dgContractNo" CssClass="table" runat="server" BorderStyle="None" CellPadding="4" BackColor="White" BorderWidth="1px" BorderColor="#CC9966">
						<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
						<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
						<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
						<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
						<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
					</asp:DataGrid>
				</asp:Panel>
				<asp:Panel id="pnlSample" runat="server">
					<TABLE id="Table10" class="table">
						<TR>
							<TD vAlign="middle" align="left"  colSpan="9">HeatNo :
								<asp:TextBox id="txtHeatNoSample" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;Chemical 
								Analysis</TD>
						</TR>
						<TR>
							<TD vAlign="middle" align="center"  colSpan="9">( provide two digit 
								numbers in Hr and Min values with leading or ending zeros )</TD>
						</TR>
						<TR>
							<TD vAlign="middle" align="center"  colSpan="9">
								<asp:RadioButtonList id="rblSample" runat="server"  AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl">
									<asp:ListItem Value="S1">S1</asp:ListItem>
									<asp:ListItem Value="S2">S2</asp:ListItem>
									<asp:ListItem Value="S3">S3</asp:ListItem>
									<asp:ListItem Value="S4">S4</asp:ListItem>
									<asp:ListItem Value="S5">S5</asp:ListItem>
									<asp:ListItem Value="S6">S6</asp:ListItem>
									<asp:ListItem Value="S7">S7</asp:ListItem>
									<asp:ListItem Value="SOS">SOS</asp:ListItem>
									<asp:ListItem Value="JMP">JMP</asp:ListItem>
									<asp:ListItem Value="W/F">W/F</asp:ListItem>
								</asp:RadioButtonList></TD>
						</TR>
						<TR>
							<TD>Sample</TD>
							<TD>Time(01:50)</TD>
							<TD>Temp</TD>
							<TD>C</TD>
							<TD>Mn</TD>
							<TD>Si</TD>
							<TD>P</TD>
						</TR>
						<TR>
							<TD >
								<asp:textbox id="txtSampleNo" runat="server" CssClass="form-control" AutoPostBack="True" BorderStyle="Groove" Enabled="False"></asp:textbox></TD>
							<TD >
								<asp:textbox id="txtSampleTimeHr" runat="server" CssClass="form-control" placeholder="HH:MM" MaxLength="5" BorderStyle="Groove"></asp:textbox></TD>
							<%--<TD  colSpan="2">&nbsp;</TD>--%>
							<TD >
								<asp:textbox id="txtSampleTemp" runat="server" CssClass="form-control" BorderStyle="Groove"></asp:textbox></TD>
							<TD >
								<asp:textbox id="txtCarbon" runat="server" CssClass="form-control" placeholder="0.000" MaxLength="5" BorderStyle="Groove"></asp:textbox></TD>
							<TD>
								<asp:textbox id="txtMn" runat="server" CssClass="form-control" placeholder="0.000" MaxLength="5" BorderStyle="Groove"></asp:textbox></TD>
							<TD>
								<asp:textbox id="txtSi" runat="server" CssClass="form-control" placeholder="0.000" MaxLength="5" BorderStyle="Groove"></asp:textbox></TD>
							<TD>
								<asp:textbox id="txtPhosph" runat="server" CssClass="form-control" placeholder="0.000" MaxLength="5" BorderStyle="Groove"></asp:textbox></TD>
						</TR>
						<TR>
							<TD>S</TD>
							<TD>Cr</TD>
							<TD >Ni</TD>
							<TD>Cu</TD>
							<TD>Al</TD>
							<TD>Moly</TD>
							<TD>V</TD>
							<TD>Nitro</TD>
							<TD>Hydro</TD>
						</TR>
						<TR>
							<TD >
								<asp:textbox id="txtSulpher" runat="server" CssClass="form-control" placeholder="0.000" MaxLength="5" BorderStyle="Groove"></asp:textbox></TD>
							<TD >
								<asp:textbox id="txtCr" runat="server" CssClass="form-control" placeholder="0.000" MaxLength="5" BorderStyle="Groove"></asp:textbox></TD>
							<TD >
								<asp:textbox id="txtNi" runat="server" CssClass="form-control" placeholder="0.000" MaxLength="5" BorderStyle="Groove"></asp:textbox></TD>
							<TD >
								<asp:textbox id="txtCu" runat="server" CssClass="form-control" placeholder="0.000" MaxLength="5" BorderStyle="Groove"></asp:textbox></TD>
							<TD >
								<asp:textbox id="txtAl" runat="server" CssClass="form-control" placeholder="0.000" MaxLength="5" BorderStyle="Groove"></asp:textbox></TD>
							<TD>
								<asp:textbox id="txtMoly" runat="server" CssClass="form-control" placeholder="0.000" MaxLength="5" BorderStyle="Groove"></asp:textbox></TD>
							<TD>
								<asp:textbox id="txtVen" runat="server" CssClass="form-control" placeholder="0.000" MaxLength="5" BorderStyle="Groove"></asp:textbox></TD>
							<TD>
								<asp:textbox id="txtNitro" runat="server" CssClass="form-control" placeholder="0.000" MaxLength="5" BorderStyle="Groove"></asp:textbox></TD>
							<TD>
								<asp:textbox id="txtHydro" runat="server" CssClass="form-control" placeholder="0.000" MaxLength="5"  BorderStyle="Groove"></asp:textbox></TD>
						</TR>
						<TR>
							<TD vAlign="middle" align="center" colSpan="9">
								<asp:button id="btnSaveSample" accessKey="s" runat="server" CssClass="button button2" BorderStyle="Groove" Text="Save" Font-Names="Arial" Font-Size="X-Small"></asp:button>
								<asp:button id="btnClearSample" accessKey="c" runat="server" CssClass="button button2" BorderStyle="Groove" Text="Clear" Font-Names="Arial" Font-Size="X-Small" CausesValidation="False"></asp:button></TD>
						</TR>
					</TABLE>
					<asp:DataGrid id="DataGrid1" runat="server" BorderStyle="None" CssClass="table" CellPadding="4" BackColor="White" BorderWidth="1px" BorderColor="#CC9966">
						<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
						<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
						<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
						<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
						<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
					</asp:DataGrid>
				</asp:Panel>
				<asp:Panel id="pnlSheet3" runat="server" >
					<TABLE id="Table14" class="table">
						<TR>
							<TD>HeatNo</TD>
							<TD>
								<asp:TextBox id="txtHeatNo3" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox></TD>
							<TD>Heat Status :
								<asp:RadioButtonList id="cboHeatStatus" runat="server" AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl">
									<asp:ListItem Value="1" Selected="True">G</asp:ListItem>
									<asp:ListItem Value="0">O</asp:ListItem>
								</asp:RadioButtonList></TD>
							<TD>TapDrain :
								<asp:radiobuttonlist id="rdBtnlst1" runat="server"  RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl">
									<asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
									<asp:ListItem Value="0">No</asp:ListItem>
								</asp:radiobuttonlist></TD>
						</TR>
						<TR>
							<TD>Tip Make</TD>
							<TD>
								<asp:DropDownList id="txtTip_make" runat="server" CssClass="form-control ll" BorderStyle="Groove"></asp:DropDownList></TD>
							<TD>&nbsp;Tip Qty ( Nos )</TD>
							<TD>
								<asp:textbox id="txtTip_quantity" runat="server" CssClass="form-control" BorderStyle="Groove"></asp:textbox></TD>
						</TR>
						<TR>
							<TD>L/Pipe Make</TD>
							<TD>
								<asp:DropDownList id="txtLpipe_make" runat="server" CssClass="form-control ll" BorderStyle="Groove"></asp:DropDownList></TD>
							<TD>L/Pipe Qty ( mts )</TD>
							<TD>
								<asp:textbox id="txtLpipe_quantity" runat="server" CssClass="form-control" BorderStyle="Groove">0</asp:textbox></TD>
						</TR>
					</TABLE>
					<TABLE id="Table15" class="table">
						<TR>
							<TD ></TD>
							<TD>Post Melting</TD>
							<TD></TD>
							<TD></TD>
							<TD></TD>
							<TD></TD>
						</TR>
						<TR>
							<TD >Tap Temp</TD>
							<TD>
								<asp:textbox id="txtTap_temperature" runat="server" CssClass="form-control" BorderStyle="Groove">0</asp:textbox></TD>
							<TD></TD>
							<TD></TD>
							<TD></TD>
							<TD></TD>
						</TR>
						<TR>
							<TD >Tap Begin </TD>
							<TD>
								<asp:TextBox id="txtTapBeginDate" runat="server" CssClass="form-control" BorderStyle="Groove"></asp:TextBox>
								<asp:textbox id="txtTap_beginHr" runat="server" CssClass="form-control" BorderStyle="Groove" placeholder="HH:MM" MaxLength="5"></asp:textbox>
								<%--<asp:textbox id="txtTap_beginMn" runat="server" CssClass="form-control" BorderStyle="Groove" MaxLength="2"></asp:textbox></TD>--%>
							<TD>JMP St Temp</TD>
							<TD>
								<asp:textbox id="txtJMPstart_temperature" runat="server" CssClass="form-control" BorderStyle="Groove">0</asp:textbox></TD>
							<TD>JMP AL Star</TD>
							<TD>
								<asp:textbox id="txtJMP_ALstar" runat="server" CssClass="form-control" BorderStyle="Groove"></asp:textbox></TD>
						</TR>
						<TR>
							<TD >Tap End( <strong> hh.mm </strong>)</TD>
							<TD>
								<asp:textbox id="txtTap_end" runat="server" CssClass="form-control" placeholder="HH.MM" MaxLength="5" BorderStyle="Groove"></asp:textbox></TD>
							<TD>Slag Cond</TD>
							<TD>
								<asp:DropDownList id="txtSlag_condition" runat="server" CssClass="form-control ll" BorderStyle="Groove" AutoPostBack="True">
                                    <asp:ListItem>THIN</asp:ListItem>
                                    <asp:ListItem>THICK</asp:ListItem>
                                </asp:DropDownList></TD>
							<TD>Total Molten Metal Wt.</TD>
							<TD>
								<asp:textbox id="txtLMlevel_final" runat="server" CssClass="form-control" BorderStyle="Groove" ReadOnly="True"></asp:textbox></TD>
						</TR>
						<TR>
							<TD >Tap - Tap Time(<strong> hh.mm </strong>)</TD>
							<TD>
								<asp:textbox id="txtTap_laptime" runat="server" CssClass="form-control" BorderStyle="Groove" MaxLength="5">1</asp:textbox></TD>
							<TD>LM Level</TD>
							<TD>
								<asp:textbox id="txtLM_level" runat="server" CssClass="form-control" BorderStyle="Groove"></asp:textbox></TD>
							<TD><FONT color="#ff0000">LadleWtAfter Tap</FONT></TD>
							<TD>
								<asp:textbox id="txtw2" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox></TD>
						</TR>
                        <TR>
							<TD >T.AKT(<strong> HH:MM:SS </strong>)</TD>
							<TD>
								<asp:textbox id="txtTotalArchTime" runat="server" CssClass="form-control" BorderStyle="Groove" placeholder="HH:MM:SS" MaxLength="8"> </asp:textbox></TD>
							<TD>Energy Consumption</TD>
							<TD>
								<asp:textbox id="txtEnergyConsumption" runat="server" CssClass="form-control" BorderStyle="Groove"></asp:textbox></TD>
						</TR>	

						<TR>
							<TD >Process Delays</TD>
							<TD>
								<asp:radiobuttonlist id="rdBtnlst2" runat="server" CssClass="rbl" AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal">
									<asp:ListItem Value="1">Yes</asp:ListItem>
									<asp:ListItem Value="0" Selected="True">No</asp:ListItem>
								</asp:radiobuttonlist></TD>
							<TD>LOF</TD>
							<TD>
                                <asp:DropDownList ID="DDLLOF" runat="server" AutoPostBack="True" BorderStyle="Groove" CssClass="form-control ll">
                                    <asp:ListItem>NO</asp:ListItem>
                                    <asp:ListItem>YES</asp:ListItem>
                                    <asp:ListItem>PARTIAL</asp:ListItem>
                                    <asp:ListItem></asp:ListItem>
                                </asp:DropDownList>
                            </TD>
							<TD>SOS</TD>
							<TD>
                                <asp:DropDownList ID="DDLSOS" runat="server" AutoPostBack="True" BorderStyle="Groove" CssClass="form-control ll">
                                    <asp:ListItem>DONE</asp:ListItem>
                                    <asp:ListItem>NOT DONE</asp:ListItem>
                                    <asp:ListItem></asp:ListItem>
                                </asp:DropDownList>
                            </TD>
						</TR>
					</TABLE>
					
					<TABLE id="Table18" class="table">

						<TR>
							<TD>HeatSheetRemarks</TD>
							<TD colSpan="2">
								<asp:textbox id="txtTrail_material_methods" runat="server" CssClass="form-control" BorderStyle="Groove" TextMode="MultiLine" ToolTip="Remarks for Process Delay/Offheat"></asp:textbox></TD>
						</TR>
						<TR>
							<TD></TD>
							<TD>
								<asp:button id="btnSheet3" runat="server" CssClass="button button2" BorderStyle="Groove" Text="Save" Font-Names="Arial"></asp:button></TD>
							<TD>
								<asp:button id="Button3" accessKey="c" runat="server" CssClass="button button2" BorderStyle="Groove" Text="Clear" Font-Names="Arial" CausesValidation="False"></asp:button></TD>
						</TR>
					</TABLE>
                       <asp:panel id="Panel1" runat="server"  Visible="False">
						<TABLE id="Table16" class="table">
							<TR>
								<TD vAlign="middle" align="left"  colSpan="4">
									<asp:label id="lblDelay" runat="server" ForeColor="Red"></asp:label></TD>
							</TR>
							<TR>
								<TD>Delay Code</TD>
								<TD>FromTim(hh:mm)</TD>
								<TD>To-Time(hh:mm)</TD>
								<TD>DelayRemarks</TD>
							</TR>
							<TR>
								<TD >
									<asp:textbox id="txtDelay_code" runat="server" CssClass="form-control" BorderStyle="Groove"></asp:textbox></TD>
								<TD >
									<asp:textbox id="txtFromtime" runat="server" CssClass="form-control" BorderStyle="Groove"></asp:textbox></TD>
								<TD>
									<asp:textbox id="txtToTime" runat="server" CssClass="form-control" BorderStyle="Groove"></asp:textbox></TD>
								<TD >
									<asp:textbox id="txtRemarks" runat="server" CssClass="form-control" BorderStyle="Groove"></asp:textbox></TD>
							</TR>
							<TR>
								<TD colSpan="3">
									<asp:DropDownList id="cboDelayCd" runat="server" AutoPostBack="True" CssClass="form-control ll"></asp:DropDownList></TD>
								<TD>
									<asp:button id="btnDelay_save" runat="server" CssClass="button button2" BorderStyle="Groove" Text="Save" Font-Names="Arial"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:button id="btnDelay_clear" runat="server" CssClass="button button2" BorderStyle="Groove" Text="Clear" Font-Names="Arial" CausesValidation="False"></asp:button></TD>
							</TR>
						</TABLE>
					</asp:panel>
				</asp:Panel>
             
			</asp:panel></div></div></form></div>
        <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
