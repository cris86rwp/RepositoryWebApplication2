<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ArcFurnaceMeltingStats.aspx.vb" Inherits="WebApplication2.ArcFurnaceMeltingStats" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>arcFurnaceMeltingStats</title>
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
      <%-- <link rel="stylesheet" href="../../../StyleSheet1.css" />--%>
        <style type="text/css">
            .auto-style1 {
                display: block;
                font-size: 14px;
                font-weight: 400;
                line-height: 1.42857143;
                color: #555;
                background-clip: padding-box;
                border-radius: 4px;
                transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
                -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
                box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
                -webkit-transition: border-color ease-in-out .15s, -webkit-box-shadow ease-in-out .15s;
                -o-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
                border: 1px solid #ccc;
                padding: 6px 12px;
                background-color: #fff;
                background-image: none;
            }
        </style>
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

		<FORM id="Form1" method="post" runat="server">
              <div class="row">
    
                  <%--<h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" >
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
      </div>
            <div class="row table-responsive">

			<asp:Panel id="Panel1"  runat="server">
				<TABLE id="Table2" class="table" >
					<TR>
						<TD>MRS. / 
							Electrical&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
							ARC FURNACE 
							MELTING 
							STATISTICS&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
					</TR>
					<TR>
						<TD>
							<asp:label id="lblMode" runat="server" Font-Bold="True" ForeColor="Blue" Font-Size="Smaller" Font-Names="Arial" Width="67px"></asp:label></TD>
					</TR>
					<TR>
						<TD>
							<asp:label id="lblMessage" runat="server" ForeColor="Red" Width="624px"></asp:label></TD>
					</TR>
					<TR>
						<TD>Date :
							<asp:textbox id="txtDate" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox>
							<%--<asp:rangevalidator id="RangeValidator1" runat="server" ErrorMessage="*" MaximumValue="01/01/2500" MinimumValue="01/01/1900" Type="Date" ControlToValidate="txtDate"></asp:rangevalidator>--%>
							<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtDate"></asp:requiredfieldvalidator></TD>
					</TR>
				</TABLE>
				<TABLE id="Table4" class="table">
					<TR>
						<TD ></TD>
						<TD ></TD>
						<TD ></TD>
						<TD ></TD>
						<TD >Time Furnace</TD>
						<TD >Worked</TD>
						<TD >Energy</TD>
						<TD >Readings</TD>
					</TR>
					<TR>
						<TD >
							<asp:label id="Label1" runat="server" Visible="False">SLNO</asp:label></TD>
						<%--<TD >Melt for the month</TD>--%>
						<%--<TD >Melt No.</TD>--%>
						<%--<TD >TR no</TD>--%>
						<%--<TD >From</TD>--%>
						<%--<TD >To</TD>--%>
						<%--<TD >Initial</TD>--%>
						<%--<TD>Final</TD>--%>
					</TR>
					<TR>
						<TD >
							<asp:label id="lblSlno" runat="server" Width="9px" Visible="False"></asp:label></TD>
						
                            <TD >Melt for the month</TD>
                            <TD >
							<asp:textbox id="txtMelt_month" runat="server" Width="100px" CssClass="auto-style1"></asp:textbox>
							<asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtMelt_month"></asp:requiredfieldvalidator>
							<asp:rangevalidator id="RangeValidator6" runat="server" ErrorMessage="*" MaximumValue="9999999" MinimumValue="0" Type="Double" ControlToValidate="txtMelt_month"></asp:rangevalidator></TD>
					<TD >Melt No.</TD>
                        <TD >
							<asp:textbox id="txtMelt_no" runat="server" CssClass="form-control" AutoPostBack="True" Width="100px"></asp:textbox>
							<asp:requiredfieldvalidator id="RequiredFieldValidator18" runat="server" ErrorMessage="*" ControlToValidate="txtMelt_no"></asp:requiredfieldvalidator>
							<asp:rangevalidator id="Rangevalidator3" runat="server" ErrorMessage="*" MaximumValue="9999999" MinimumValue="0" Type="Double" ControlToValidate="txtMelt_no"></asp:rangevalidator></TD>
						</TR>
                            <TR>
                        <TD >TR no</TD>
                        <TD >
							<asp:textbox id="txtTR1" runat="server" CssClass="auto-style1" Width="100px"></asp:textbox></TD>
						<TD >From</TD>
                                <TD >
							<asp:textbox id="txtTR1From" runat="server" CssClass="auto-style1" AutoPostBack="True" Width="100px"></asp:textbox>
							<asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="txtTR1From"></asp:requiredfieldvalidator></TD>
						<TD >To</TD>
                                <TD >
							<asp:textbox id="txtTR1To" runat="server" CssClass="auto-style1" AutoPostBack="True" Width="100px"></asp:textbox>
							<asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" ErrorMessage="*" ControlToValidate="txtTR1To"></asp:requiredfieldvalidator></TD>
						</TR>
                            <TR>
                             <TD >Initial</TD>
                                <TD >
							<asp:textbox id="txtTR1Initial" runat="server" Width="100px" CssClass="auto-style1"></asp:textbox>
							<asp:rangevalidator id="RangeValidator2" runat="server" ErrorMessage="*" MaximumValue="999999999" MinimumValue="0" Type="Double" ControlToValidate="txtTR1Initial"></asp:rangevalidator>
							<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtTR1Initial"></asp:requiredfieldvalidator></TD>
					<TD>Final</TD>
                                <TD >
							<asp:textbox id="txtTR1Final" runat="server" CssClass="auto-style1" AutoPostBack="True" Width="100px"></asp:textbox>
							<asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server" ErrorMessage="*" ControlToValidate="txtTR1Final"></asp:requiredfieldvalidator>
							<asp:rangevalidator id="Rangevalidator12" runat="server" ErrorMessage="*" MaximumValue="999999999" MinimumValue="0" Type="Double" ControlToValidate="txtTR1Final"></asp:rangevalidator>
							<asp:RadioButtonList id="rblMF" runat="server" CssClass="rbl" RepeatDirection="Horizontal">
								<asp:ListItem Value="1" Selected="True">1</asp:ListItem>
								<asp:ListItem Value="16000">16000</asp:ListItem>
								<asp:ListItem Value="18000">18000</asp:ListItem>
							</asp:RadioButtonList></TD>
					</TR>
					<TR>
						<TD ></TD>
						<TD ></TD>
						<TD ></TD>
                        </TR>
					<TR>
						 <TD >TR no</TD>
                        <TD >
							<asp:textbox id="txtTR2" runat="server" CssClass="auto-style1" Width="100px">0</asp:textbox></TD>
						<TD >From</TD>
                       
                        <TD >
							<asp:textbox id="txtTR2From" runat="server" Width="100px" CssClass="form-control">01/01/1900 00:00:00</asp:textbox></TD>
						<TD >To</TD>
                        <TD >
							<asp:textbox id="txtTR2to" runat="server" CssClass="form-control" Width="100px" AutoPostBack="True">01/01/1900 00:00:00</asp:textbox></TD>
						</TR>
					<TR>
                        <TD >Initial</TD>
                        <TD >
							<asp:textbox id="txtTR2Initial" runat="server" DESIGNTIMEDRAGDROP="241" Width="100px" CssClass="form-control">0</asp:textbox></TD>
					  <TD>Final</TD>
                        <TD >
							<asp:textbox id="txtTR2final" runat="server" CssClass="form-control" Width="100px" AutoPostBack="True">0</asp:textbox></TD>
					</TR>
					<TR>
						<TD ></TD>
						<TD ></TD>
						<TD ></TD>
                            </TR>
					<TR>
                        <TD >TR no</TD>
						<TD >
							<asp:textbox id="txtTR3" runat="server" CssClass="form-control" Width="100px">0</asp:textbox></TD>
						<TD >From</TD>
                        
                         <TD >
							<asp:textbox id="txtTR3From" runat="server" Width="100px" CssClass="form-control">01/01/1900 00:00:00</asp:textbox></TD>
						<TD >To</TD>
                        <TD >
							<asp:textbox id="txtTR3to" runat="server" Width="100px" CssClass="form-control" AutoPostBack="True">01/01/1900 00:00:00</asp:textbox></TD>
						</TR>
					<TR>
                        <TD >Initial</TD>
                        <TD >
							<asp:textbox id="txtTR3Initial" runat="server" Width="100px" CssClass="form-control">0</asp:textbox></TD>
						 <TD>Final</TD>
                        <TD >
							<asp:textbox id="txtTR3final" runat="server" Width="100px" CssClass="form-control" AutoPostBack="True">0</asp:textbox></TD>
					</TR>
					<TR>
						<TD >Consumption</TD>
						<TD >
							<asp:label id="lblConsumption" runat="server"></asp:label></TD>
						<TD ></TD>
						<TD ></TD>
						<TD ></TD>
						<TD ></TD>
						<TD ></TD>
						<TD ></TD>
					</TR>
					<TR>
						<TD >M.D.</TD>
						<TD >
							<asp:textbox id="txtDemand" runat="server" DESIGNTIMEDRAGDROP="380" CssClass="form-control" Width="100px"></asp:textbox>
							<asp:requiredfieldvalidator id="RequiredFieldValidator7" runat="server" ErrorMessage="*" ControlToValidate="txtDemand"></asp:requiredfieldvalidator>
							<asp:rangevalidator id="RangeValidator4" runat="server" ErrorMessage="*" MaximumValue="999999999" MinimumValue="0" Type="Double" ControlToValidate="txtDemand"></asp:rangevalidator></TD>
						<TD >AF No.ssss</TD>
						<TD >
							<asp:dropdownlist id="ddlAF" runat="server" CssClass="form-control ll" AutoPostBack="True" Width="100px">
								<asp:ListItem Value="select" Selected="True">select</asp:ListItem>
								<asp:ListItem Value="AF-A">AF-A</asp:ListItem>
								<asp:ListItem Value="AF-B">AF-B</asp:ListItem>
								<asp:ListItem Value="AF-C">AF-C</asp:ListItem>
							</asp:dropdownlist></TD>
						<TD >VCB No.</TD>
						<TD >
							<asp:textbox id="txtVCB_no" runat="server" CssClass="form-control" Width="100px"></asp:textbox></TD>
						<TD >MeltingTime(hh:mm)</TD>
						<TD >
							<asp:label id="lblMeltingTime" runat="server"></asp:label></TD>
					</TR>
					<TR>
						<TD >TaptoTap sameAF</TD>
						<TD >
							<asp:label id="lblTtoTsameAF" runat="server"></asp:label></TD>
						<TD >TaptoPowerOn same&nbsp;AF</TD>
						<TD >
							<asp:label id="lblTtoPsameAF" runat="server"></asp:label></TD>
						<TD >TaptoTap&nbsp;anyAF</TD>
						<TD >
							<asp:label id="lblTtoTanyAF" runat="server"></asp:label></TD>
						<TD >Remarks</TD>
						<TD >
							<asp:textbox id="txtRemarks" runat="server" DESIGNTIMEDRAGDROP="404"  TextMode="MultiLine" CssClass="form-control"></asp:textbox></TD>
					</TR>
					<TR>
						<TD ></TD>
						<TD ></TD>
						<TD >
							<asp:button id="btnSubmit_Clicks" runat="server" Font-Size="Smaller" Font-Names="Arial" CssClass="button button2" Text="Save" BorderStyle="Groove"></asp:button></TD>
						<TD >
							<asp:button id="btnCancel" runat="server" Font-Size="Smaller" Font-Names="Arial" CssClass="button button2" Text="Clear" BorderStyle="Groove"></asp:button></TD>
						<TD >
							<asp:button id="btnExit" runat="server" Font-Size="Smaller" Font-Names="Arial" CssClass="button button2" Text="Exit" BorderStyle="Groove" CausesValidation="False"></asp:button></TD>
						<TD ></TD>
						<TD ></TD>
						<TD ></TD>
					</TR>
				</TABLE>
				<asp:datagrid id="grdAFS" runat="server" Width="460px" Height="98px"  BorderStyle="None" BorderColor="#DEBA84" CellSpacing="1" BorderWidth="1px" BackColor="#DEBA84" CellPadding="1" AllowCustomPaging="True" AllowPaging="True" AllowSorting="True">
					<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#738A9C"></SelectedItemStyle>
					<ItemStyle ForeColor="#8C4510" BackColor="#FFF7E7"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#A55129"></HeaderStyle>
					<AlternatingItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
					<FooterStyle ForeColor="#8C4510" BackColor="#F7DFB5"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages"></PagerStyle>
				</asp:datagrid>
				<TABLE id="Table3" class="table">
					<TR>
						<TD >&nbsp;</TD>
						<TD >No of melts&nbsp;</TD>
						<TD >UnitsConsumed</TD>
						<TD >Units/Ton</TD>
						<TD >Ave&nbsp;Unit/Heat</TD>
						<TD >Progressive melts for month</TD>
						<TD >Progressive units for month</TD>
						<TD >Units/Ton for the month</TD>
						<TD>Progressive average units&nbsp;for month</TD>
					</TR>
					<TR>
						<TD >Arc Furnace A</TD>
						<TD >
							<asp:label id="lblDay_melts1" runat="server"></asp:label></TD>
						<TD >
							<asp:label id="lblDay_consumption1" runat="server"></asp:label></TD>
						<TD >
							<asp:Label id="lblUnitsPerTonforDayA" runat="server"></asp:Label></TD>
						<TD >
							<asp:label id="lblDay_average1" runat="server"></asp:label></TD>
						<TD >
							<asp:label id="lblProgressive_melts1" runat="server"></asp:label></TD>
						<TD >
							<asp:label id="lblProgressive_units1" runat="server"></asp:label></TD>
						<TD>
							<asp:Label id="lblUnitsPerTonforMonthA" runat="server"></asp:Label></TD>
						<TD>
							<asp:label id="lblMonth_average1" runat="server"></asp:label></TD>
					</TR>
					<TR>
						<TD >Arc Furnace B</TD>
						<TD >
							<asp:label id="lblDay_melts2" runat="server"></asp:label></TD>
						<TD >
							<asp:label id="lblDay_consumption2" runat="server"></asp:label></TD>
						<TD >
							<asp:Label id="lblUnitsPerTonforDayB" runat="server"></asp:Label></TD>
						<TD >
							<asp:label id="lblDay_average2" runat="server"></asp:label></TD>
						<TD >
							<asp:label id="lblProgressive_melts2" runat="server"></asp:label></TD>
						<TD >
							<asp:label id="lblProgressive_units2" runat="server"></asp:label></TD>
						<TD >
							<asp:Label id="lblUnitsPerTonforMonthB" runat="server"></asp:Label></TD>
						<TD >
							<asp:label id="lblMonth_average2" runat="server"></asp:label></TD>
					</TR>
					<TR>
						<TD >Arc Furnace C</TD>
						<TD >
							<asp:label id="lblDay_melts3" runat="server"></asp:label></TD>
						<TD >
							<asp:label id="lblDay_consumption3" runat="server"></asp:label></TD>
						<TD >
							<asp:Label id="lblUnitsPerTonforDayC" runat="server"></asp:Label></TD>
						<TD >
							<asp:label id="lblDay_average3" runat="server"></asp:label></TD>
						<TD >
							<asp:label id="lblProgressive_melts3" runat="server"></asp:label></TD>
						<TD >
							<asp:label id="lblProgressive_units3" runat="server"></asp:label></TD>
						<TD>
							<asp:Label id="lblUnitsPerTonforMonthC" runat="server"></asp:Label></TD>
						<TD>
							<asp:label id="lblMonth_average3" runat="server"></asp:label></TD>
					</TR>
					<TR>
						<TD >Total</TD>
						<TD >
							<asp:Label id="lblTotalHeats" runat="server"></asp:Label></TD>
						<TD >
							<asp:Label id="lblConsumptionforDay" runat="server"></asp:Label></TD>
						<TD >&nbsp;</TD>
						<TD >&nbsp;</TD>
						<TD >
							<asp:Label id="lblProgressiveMeltsforMonth" runat="server"></asp:Label></TD>
						<TD >
							<asp:Label id="lblProgressiveunitsformonth" runat="server"></asp:Label></TD>
						<TD>&nbsp;</TD>
						<TD>&nbsp;</TD>
					</TR>
					<TR>
						<TD >Average</TD>
						<TD >&nbsp;</TD>
						<TD >
							<asp:label id="lblDay_average" runat="server"></asp:label></TD>
						<TD >
							<asp:Label id="lblUnitsPerTonDayAvg" runat="server"></asp:Label></TD>
						<TD >&nbsp;</TD>
						<TD >&nbsp;</TD>
						<TD >
							<asp:label id="lblMonth_average" runat="server"></asp:label></TD>
						<TD>
							<asp:Label id="lblUnitsPerTonMonthAvg" runat="server"></asp:Label></TD>
						<TD>&nbsp;</TD>
					</TR>
					<TR>
						<TD >Total Tonnage</TD>
						<TD >&nbsp;</TD>
						<TD >&nbsp;</TD>
						<TD >
							<asp:Label id="lblTotalTonnageforDay" runat="server"></asp:Label></TD>
						<TD >&nbsp;</TD>
						<TD>&nbsp;</TD>
						<TD >&nbsp;</TD>
						<TD>
							<asp:Label id="lblTotalTonnageforMonth" runat="server"></asp:Label></TD>
						<TD>&nbsp;</TD>
					</TR>
					<TR>
						<TD  colSpan="3">
                            	</TD>
						
					</TR>
				</TABLE>
							<TABLE id="Table5" class="table">
								<TR>
									<TD >Code</TD>
									<TD >AF-A</TD>
									<TD >AF-B</TD>
									<TD >AF-C</TD>
								</TR>
								<TR>
									<TD >a</TD>
									<TD >
										<asp:Label id="lblAF_Aa" runat="server"></asp:Label></TD>
									<TD >
										<asp:Label id="lblAF_Ba" runat="server"></asp:Label></TD>
									<TD >
										<asp:Label id="lblAF_Ca" runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD >b</TD>
									<TD >
										<asp:Label id="lblAF_Ab" runat="server"></asp:Label></TD>
									<TD >
										<asp:Label id="lblAF_Bb" runat="server"></asp:Label></TD>
									<TD>
										<asp:Label id="lblAF_Cb" runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD >c</TD>
									<TD >
										<asp:Label id="lblAF_Ac" runat="server"></asp:Label></TD>
									<TD >
										<asp:Label id="lblAF_Bc" runat="server"></asp:Label></TD>
									<TD >
										<asp:Label id="lblAF_Cc" runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD >d</TD>
									<TD >
										<asp:Label id="lblAF_Ad" runat="server"></asp:Label></TD>
									<TD >
										<asp:Label id="lblAF_Bd" runat="server"></asp:Label></TD>
									<TD >
										<asp:Label id="lblAF_Cd" runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD >e</TD>
									<TD >
										<asp:Label id="lblAF_Ae" runat="server"></asp:Label></TD>
									<TD >
										<asp:Label id="lblAF_Be" runat="server"></asp:Label></TD>
									<TD >
										<asp:Label id="lblAF_Ce" runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD >Total</TD>
									<TD >
										<asp:Label id="lblTotalAF_A" runat="server"></asp:Label></TD>
									<TD >
										<asp:Label id="lblTotalAF_B" runat="server"></asp:Label></TD>
									<TD >
										<asp:Label id="lblTotalAF_C" runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD " colSpan="2"></TD>
									<TD ></TD>
									<TD ></TD>
								</TR>
							</TABLE>
						
			</asp:Panel>
	</div>	</form>
            </div>
         <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
