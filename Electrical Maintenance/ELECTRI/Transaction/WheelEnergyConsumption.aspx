<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WheelEnergyConsumption.aspx.vb" Inherits="WebApplication2.WheelEnergyConsumption" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>Energy Consumption For The Day</title>
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
                height: 61px;
            }
        </style>

	</HEAD>
	<BODY >
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
			<TABLE id="Table2" class="table">
				<TR>
					<TD colSpan="4"><STRONG>NO : SSE / EL / WS (P) - 20</STRONG></TD>
					<TD style="WIDTH: 9px"></TD>
					<TD></TD>
					<TD colSpan="2"><STRONG>OFFICE OF THE SSE / EL / WS (P)</STRONG></TD>
				</TR>
				<TR>
					<TD  colSpan="8" rowSpan="1"><STRONG>WHEEL 
								SHOP ENERGY CONSUMPTION FOR THE DAY </STRONG>
					</TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					
					<TD><asp:label id="lblMode" runat="server" Width="101px" ForeColor="Blue" Font-Bold="True" Font-Names="Arial" Font-Size="Smaller"></asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="8"><asp:label id="lblMessage" runat="server" Width="873px" ForeColor="Red"></asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="3">Date :&nbsp;&nbsp;
						<asp:textbox id="txtDate" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtDate" ErrorMessage="*"></asp:requiredfieldvalidator><%--<asp:rangevalidator id="RangeValidator1" runat="server" ControlToValidate="txtDate" ErrorMessage="*" MinimumValue="1/1/1900" MaximumValue="1/1/9999" Type="Date"></asp:rangevalidator>--%></TD>
					<TD></TD>
					<TD ></TD>
					
					<TD><asp:button id="btnCalculateAll" runat="server" DESIGNTIMEDRAGDROP="2275" CausesValidation="False" CssClass="button button2"  Text="Calculate All"></asp:button></TD>
				</TR>
				<TR>
					<TD class="auto-style1">SlNo</TD>
					<TD class="auto-style1"><STRONG>SUB-STATION</STRONG></TD>
					<TD class="auto-style1">KWH&nbsp; 
						INITIAL&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					</TD>
					<TD class="auto-style1">KWH&nbsp; 
						FINAL&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					</TD>
					<TD class="auto-style1" >DIFFERENCE</TD>
					<TD class="auto-style1">MF</TD>
					<TD class="auto-style1">UNIT CONSUMPTION&nbsp;</TD>
					<TD class="auto-style1">PROGRESSIVE UNITS</TD>
				</TR>
				<TR>
					<TD>1</TD>
					<TD>MELTESS TR1
					</TD>
					<TD>
						<P><asp:textbox id="txtwsEss_initial" runat="server"  AutoPostBack="True" CssClass="form-control"></asp:textbox></P>
					</TD>
					<TD>
						<P><asp:textbox id="txtwsEss_final" tabIndex="1" runat="server"  AutoPostBack="True" CssClass="form-control"></asp:textbox></P>
					</TD>
					<TD >
						<P><asp:label id="lblMF_essential" runat="server"></asp:label></P>
					</TD>
					<TD>
						<P><asp:dropdownlist id="ddlMFwsess" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></P>
					</TD>
					<TD>
						<P><asp:label id="lblUnit_essential" runat="server"></asp:label></P>
					</TD>
					<TD>
						<P><asp:label id="lblTotal_essential" runat="server"></asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD>2</TD>
					<TD>MELTESS TR2</TD>
					<TD>
						<P><asp:textbox id="txtwsEss_initial1" tabIndex="3" runat="server"  AutoPostBack="True" CssClass="form-control"></asp:textbox></P>
					</TD>
					<TD>
						<P><asp:textbox id="txtwsEss_final1" tabIndex="4" runat="server"  AutoPostBack="True" CssClass="form-control"></asp:textbox></P>
					</TD>
					<TD >
						<P><asp:label id="lblMF_essential1" runat="server"></asp:label></P>
					</TD>
					<TD>
						<P><asp:dropdownlist id="ddlMFwsess1" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></P>
					</TD>
					<TD>
						<P><asp:label id="lblUnit_essential1" runat="server"></asp:label></P>
					</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD>3</TD>
					<TD>MELTESS TR3
					</TD>
					<TD>
						<P><asp:textbox id="txtwsNonEss_initial" tabIndex="6" runat="server"  AutoPostBack="True" CssClass="form-control"></asp:textbox></P>
					</TD>
					<TD>
						<P><asp:textbox id="txtwsNonEss_final" tabIndex="7" runat="server"  AutoPostBack="True" CssClass="form-control"></asp:textbox></P>
					</TD>
					<TD ><asp:label id="lblMF_nonessential" runat="server"></asp:label></TD>
					<TD>
						<P><asp:dropdownlist id="ddlMFwsnon" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></P>
					</TD>
					<TD>
						<P><asp:label id="lblUnit_nonessential" runat="server" Width="138px"></asp:label></P>
					</TD>
					<TD>
						<P><asp:label id="lblTotal_nonessential" runat="server"></asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD>4</TD>
					<TD>MELTESS TR4
					</TD>
					<TD>
						<P><asp:textbox id="txtwsNonEss_initial1" tabIndex="9" runat="server"  AutoPostBack="True" CssClass="form-control"></asp:textbox></P>
					</TD>
					<TD>
						<P><asp:textbox id="txtwsNonEss_final1" tabIndex="10" runat="server"  AutoPostBack="True" CssClass="form-control"></asp:textbox></P>
					</TD>
					<TD >
						<P><asp:label id="lblMF_nonessential1" runat="server"></asp:label></P>
					</TD>
					<TD>
						<P><asp:dropdownlist id="ddlMFwsnon1" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></P>
					</TD>
					<TD>
						<P><asp:label id="lblUnit_nonessential1" runat="server" Width="138px"></asp:label></P>
					</TD>
					<TD></TD>
				</TR>
                <TR>
					<TD>5</TD>
					<TD>MELTESS TR5
					</TD>
					<TD>
						<P><asp:textbox id="txtwsNonEss_initial2" tabIndex="9" runat="server"  AutoPostBack="True" CssClass="form-control"></asp:textbox></P>
					</TD>
					<TD>
						<P><asp:textbox id="txtwsNonEss_final2" tabIndex="10" runat="server"  AutoPostBack="True" CssClass="form-control"></asp:textbox></P>
					</TD>
					<TD >
						<P><asp:label id="lblMF_nonessential2" runat="server"></asp:label></P>
					</TD>
					<TD>
						<P><asp:dropdownlist id="ddlMFwsnon2" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></P>
					</TD>
					<TD>
						<P><asp:label id="lblUnit_nonessential2" runat="server" Width="138px"></asp:label></P>
					</TD>
					<TD></TD>
				</TR>
				
				<TR>
					<TD>6</TD>
					<TD>TUBE PRE-HEAT TR1</TD>
					<TD>
						<P><asp:textbox id="txtTube_initial" tabIndex="12" runat="server" CssClass="form-control" AutoPostBack="True" ></asp:textbox></P>
					</TD>
					<TD>
						<P><asp:textbox id="txtTube_final" tabIndex="13" runat="server" CssClass="form-control" AutoPostBack="True" ></asp:textbox></P>
					</TD>
					<TD >
						<P><asp:label id="lblMF_tube" runat="server"></asp:label></P>
					</TD>
					<TD>
						<P><asp:dropdownlist id="ddlMFtube" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></P>
					</TD>
					<TD>
						<P><asp:label id="lblUnit_tube" runat="server"></asp:label></P>
					</TD>
					<TD>
						<P><asp:label id="lblTotal_tube" runat="server"></asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD>7</TD>
					<TD>TUBE PRE-HEAT TR2</TD>
					<TD>
						<P><asp:textbox id="txtTube_initial1" tabIndex="15" runat="server" CssClass="form-control" AutoPostBack="True" ></asp:textbox></P>
					</TD>
					<TD>
						<P><asp:textbox id="txtTube_final1" tabIndex="16" runat="server"  CssClass="form-control" AutoPostBack="True" DESIGNTIMEDRAGDROP="4631" ></asp:textbox></P>
					</TD>
					<TD >
						<P><asp:label id="lblMF_tube1" runat="server"></asp:label></P>
					</TD>
					<TD>
						<P><asp:dropdownlist id="ddlMFtube1" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></P>
					</TD>
					<TD>
						<P><asp:label id="lblUnit_tube1" runat="server"></asp:label></P>
					</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD>8</TD>
					<TD>
						<P>MOULD PRE-HEAT TR1</P>
					</TD>
					<TD>
						<P><asp:textbox id="txtMould_initial" tabIndex="18" runat="server"  AutoPostBack="True" CssClass="form-control"></asp:textbox></P>
					</TD>
					<TD>
						<P><asp:textbox id="txtMould_final" tabIndex="19" runat="server"  AutoPostBack="True" CssClass="form-control"></asp:textbox></P>
					</TD>
					<TD >
						<P><asp:label id="lblMF_mould" runat="server"></asp:label></P>
					</TD>
					<TD>
						<P><asp:dropdownlist id="ddlMFmould" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></P>
					</TD>
					<TD>
						<P><asp:label id="lblUnit_mould" runat="server"></asp:label></P>
					</TD>
					<TD>
						<P><asp:label id="lblTotal_mould" runat="server"></asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD>9</TD>
					<TD>
						<P>MOULD PRE-HEAT TR2</P>
					</TD>
					<TD>
						<P><asp:textbox id="txtMould_initial1" tabIndex="21" runat="server" CssClass="form-control" AutoPostBack="True" ></asp:textbox></P>
					</TD>
					<TD>
						<P><asp:textbox id="txtMould_final1" tabIndex="22" runat="server"  AutoPostBack="True" CssClass="form-control"></asp:textbox></P>
					</TD>
					<TD >
						<P><asp:label id="lblMF_mould1" runat="server"></asp:label></P>
					</TD>
					<TD>
						<P><asp:dropdownlist id="ddlMFmould1" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></P>
					</TD>
					<TD>
						<P><asp:label id="lblUnit_mould1" runat="server"></asp:label></P>
					</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD>10</TD>
					<TD>
						<P>MOULD PRE-HEAT TR3</P>
					</TD>
					<TD><asp:textbox id="txtMould_initial2" tabIndex="21" runat="server" CssClass="form-control" AutoPostBack="True" ></asp:textbox></TD>
					<TD><asp:textbox id="txtMould_final2" tabIndex="22" runat="server"  AutoPostBack="True" CssClass="form-control"></asp:textbox></TD>
					<TD ><asp:label id="lblMF_mould2" runat="server"></asp:label></TD>
					<TD><asp:dropdownlist id="ddlMFmould2" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></TD>
					<TD><asp:label id="lblUnit_mould2" runat="server"></asp:label></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD >11</TD>
					<TD >FUME EXTRACTION TR1</TD>
					<TD >
						<P><asp:textbox id="txtFume_initial" tabIndex="30" runat="server" CssClass="form-control" AutoPostBack="True" ></asp:textbox></P>
					</TD>
					<TD >
						<P><asp:textbox id="txtFume_final" tabIndex="31" runat="server"  AutoPostBack="True" CssClass="form-control"></asp:textbox></P>
					</TD>
					<TD >
						<P><asp:label id="lblMF_fume" runat="server"></asp:label></P>
					</TD>
					<TD >
						<P><asp:dropdownlist id="ddlMFfume" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></P>
					</TD>
					<TD >
						<P><asp:label id="lblUnit_fume" runat="server"></asp:label></P>
					</TD>
					<TD >
						<P><asp:label id="lblTotal_fume" runat="server"></asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD>12</TD>
					<TD>FUME EXTRACTION TR2</TD>
					<TD>
						<P><asp:textbox id="txtFume_initial1" tabIndex="33" runat="server" CssClass="form-control" AutoPostBack="True" ></asp:textbox></P>
					</TD>
					<TD >
						<P><asp:textbox id="txtFume_final1" tabIndex="34" runat="server" CssClass="form-control"  AutoPostBack="True" ></asp:textbox></P>
					</TD>
					<TD >
						<P><asp:label id="lblMF_fume1" runat="server"></asp:label></P>
					</TD>
					<TD>
						<P><asp:dropdownlist id="ddlMFfume1" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></P>
					</TD>
					<TD>
						<P><asp:label id="lblUnit_fume1" runat="server" Width="110px"></asp:label></P>
					</TD>
					<TD>
						<P>&nbsp;</P>
					</TD>
				</TR>
				<TR>
					<TD>13</TD>
					<TD>COMPRESSOR TR1</TD>
					<TD>
						<P><asp:textbox id="txtCompressor_initial" tabIndex="24" runat="server"  AutoPostBack="True" CssClass="form-control"></asp:textbox></P>
					</TD>
					<TD>
						<P><asp:textbox id="txtCompressor_final" tabIndex="25" runat="server" CssClass="form-control" AutoPostBack="True" ></asp:textbox></P>
					</TD>
					<TD >
						<P><asp:label id="lblMF_compressor" runat="server"></asp:label></P>
					</TD>
					<TD>
						<P><asp:dropdownlist id="ddlMFcomp" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></P>
					</TD>
					<TD>
						<P><asp:label id="lblUnit_compressor" runat="server"></asp:label></P>
					</TD>
					<TD>
						<P><asp:label id="lblTotal_compressor" runat="server"></asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD>14</TD>
					<TD>COMPRESSOR TR2</TD>
					<TD>
						<P><asp:textbox id="txtCompressor_initial1" tabIndex="27" runat="server"  AutoPostBack="True" CssClass="form-control"></asp:textbox></P>
					</TD>
					<TD>
						<P><asp:textbox id="txtCompressor_final1" tabIndex="28" runat="server"  AutoPostBack="True" CssClass="form-control"></asp:textbox></P>
					</TD>
					<TD >
						<P><asp:label id="lblMF_compressor1" runat="server"></asp:label></P>
					</TD>
					<TD>
						<P><asp:dropdownlist id="ddlMFcomp1" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></P>
					</TD>
					<TD>
						<P><asp:label id="lblUnit_compressor1" runat="server" Width="138px"></asp:label></P>
					</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD  colSpan="8"><asp:label id="lblMessage2" runat="server" Width="904px" ForeColor="Red"></asp:label></TD>
				</TR>
                <TR>
					<TD>15.1</TD>
					<TD>PUMPESSTR1</TD>
					<TD>
						<P><asp:textbox id="txtpumpesstr_initial" tabIndex="27" runat="server"  AutoPostBack="True" CssClass="form-control"></asp:textbox></P>
					</TD>
					<TD>
						<P><asp:textbox id="txtpumpesstr_final" tabIndex="28" runat="server"  AutoPostBack="True" CssClass="form-control"></asp:textbox></P>
					</TD>
					<TD >
						<P><asp:label id="lblmf_pumpesstr" runat="server"></asp:label></P>
					</TD>
					<TD>
						<P><asp:dropdownlist id="ddlpumpesstr1" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></P>
					</TD>
					<TD>
						<P><asp:label id="lblunit_pumpesstr" runat="server" Width="138px"></asp:label></P>
					</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD  colSpan="8"><asp:label id="Label5" runat="server" Width="904px" ForeColor="Red"></asp:label></TD>
				</TR>
                <TR>
					<TD>15.2</TD>
					<TD>PUMPESSTR2</TD>
					<TD>
						<P><asp:textbox id="txtpumpesstr1_initial" tabIndex="27" runat="server"  AutoPostBack="True" CssClass="form-control"></asp:textbox></P>
					</TD>
					<TD>
						<P><asp:textbox id="txtpumpesstr1_final" tabIndex="28" runat="server"  AutoPostBack="True" CssClass="form-control"></asp:textbox></P>
					</TD>
					<TD >
						<P><asp:label id="lblmf_pumpesstr1" runat="server"></asp:label></P>
					</TD>
					<TD>
						<P><asp:dropdownlist id="ddlpumpesstr2" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></P>
					</TD>
					<TD>
						<P><asp:label id="lblunit_pumpesstr1" runat="server" Width="138px"></asp:label></P>
					</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD  colSpan="8"><asp:label id="Label8" runat="server" Width="904px" ForeColor="Red"></asp:label></TD>
				</TR>
                <TR>
					<TD>16.1</TD>
					<TD>PCSESSTR1</TD>
					<TD>
						<P><asp:textbox id="txtpcsesstr_initial" tabIndex="27" runat="server"  AutoPostBack="True" CssClass="form-control"></asp:textbox></P>
					</TD>
					<TD>
						<P><asp:textbox id="txtpcsesstr_final" tabIndex="28" runat="server"  AutoPostBack="True" CssClass="form-control"></asp:textbox></P>
					</TD>
					<TD >
						<P><asp:label id="lblmf_pcsesstr" runat="server"></asp:label></P>
					</TD>
					<TD>
						<P><asp:dropdownlist id="ddlpcsesstr1" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></P>
					</TD>
					<TD>
						<P><asp:label id="lblunit_pcsesstr" runat="server" Width="138px"></asp:label></P>
					</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD  colSpan="8"><asp:label id="Label11" runat="server" Width="904px" ForeColor="Red"></asp:label></TD>
				</TR>
                <TR>
					<TD>16.2</TD>
					<TD>PCSESSTR2</TD>
					<TD>
						<P><asp:textbox id="txtpcsesstr1_initial" tabIndex="27" runat="server"  AutoPostBack="True" CssClass="form-control"></asp:textbox></P>
					</TD>
					<TD>
						<P><asp:textbox id="txtpcsesstr1_final" tabIndex="28" runat="server"  AutoPostBack="True" CssClass="form-control"></asp:textbox></P>
					</TD>
					<TD >
						<P><asp:label id="lblmf_pcsesstr1" runat="server"></asp:label></P>
					</TD>
					<TD>
						<P><asp:dropdownlist id="ddlpcsesstr2" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></P>
					</TD>
					<TD>
						<P><asp:label id="lblunit_pcsesstr1" runat="server" Width="138px"></asp:label></P>
					</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD  colSpan="8"><asp:label id="Label14" runat="server" Width="904px" ForeColor="Red"></asp:label></TD>
				</TR>
				<TR>
					<TD  colSpan="8"><asp:button id="btnSubmit_Clicks" runat="server" CssClass="button button2" Font-Names="Arial" Font-Size="Smaller" Text="Save"  BorderStyle="Groove"></asp:button><asp:button id="btnCancel" runat="server" CssClass="button button2" Font-Names="Arial" Font-Size="Smaller" Text="Clear"  BorderStyle="Groove"></asp:button><asp:button id="btnExit" runat="server" CssClass="button button2" Font-Names="Arial" Font-Size="Smaller" CausesValidation="False" Text="Exit"  BorderStyle="Groove"></asp:button></TD>
				</TR>
			</TABLE>
			
	</div>	</FORM>
            </div>
         <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</BODY>
</HTML>
