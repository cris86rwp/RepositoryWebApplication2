<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ElecPFReadings.aspx.vb" Inherits="WebApplication2.ElecPFReadings" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>ElecPFReadings</title>
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
    
              <%--    <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" >
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
      </div>
            <div class="row table-responsive">
			<asp:panel id="Panel1" runat="server">
				<TABLE id="Table1" class="table">
					<TR>
						<TD colSpan="8">Details of Power Factor Readings&nbsp;</TD>
					</TR>
					<TR>
						<TD colSpan="8">
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label>&nbsp;</TD>
					</TR>
					<TR>
						<TD>Date</TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="txtDate" runat="server" AutoPostBack="True" CssClass="form-control"></asp:TextBox></TD>
						<TD colSpan="2">10:30 HRS</TD>
						<TD colSpan="2">15:30 HRS</TD>
						<TD>&nbsp;</TD>
					</TR>
					<TR>
						<TD>SlNo</TD>
						<TD>&nbsp;</TD>
						<TD>SubStation</TD>
						<TD>PF</TD>
						<TD>LoadinKW</TD>
						<TD>PF</TD>
						<TD>LoadinKW</TD>
						<TD>Remarks</TD>
					</TR>
					<TR>
						<TD >
							<asp:Label id="Label1" runat="server">1</asp:Label></TD>
						<TD >:</TD>
						<TD >
							<asp:Label id="SSKPTCL" runat="server">NBPDCL</asp:Label></TD>
						<TD >
							<asp:TextBox id="FirstPFKPTCL" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox></TD>
						<TD >
							<asp:TextBox id="FirstLoadKPTCL" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD >
							<asp:TextBox id="SecondPFKPTCL" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox></TD>
						<TD >
							<asp:TextBox id="SecondLoadKPTCL" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD >
							<asp:TextBox id="RemarksKPTCL" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>
							<asp:Label id="Label2" runat="server">2</asp:Label></TD>
						<TD>:</TD>
						<TD>
							<asp:Label id="SSAFI" runat="server">AF-I</asp:Label></TD>
						<TD>
							<asp:TextBox id="FirstPFAFI" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="FirstLoadAFI" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SecondPFAFI" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SecondLoadAFI" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="RemarksAFI" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>
							<asp:Label id="Label3" runat="server">3</asp:Label></TD>
						<TD>:</TD>
						<TD>
							<asp:Label id="SSAFII" runat="server">AF-II</asp:Label></TD>
						<TD>
							<asp:TextBox id="FirstPFAFII" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="FirstLoadAFII" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SecondPFAFII" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SecondLoadAFII" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="RemarksAFII" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>
							<asp:Label id="Label4" runat="server">4</asp:Label></TD>
						<TD>:</TD>
						<TD>
							<asp:Label id="SSAFIII" runat="server">AF-III</asp:Label></TD>
						<TD>
							<asp:TextBox id="FirstPFAFIII" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="FirstLoadAFIII" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SecondPFAFIII" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SecondLoadAFIII" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="RemarksAFIII" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>
							<asp:Label id="Label5" runat="server">5</asp:Label></TD>
						<TD>:</TD>
						<TD>
							<asp:Label id="SSPUMPHOUSE" runat="server" Width="266px">PUM PHOUSE </asp:Label></TD>
						<TD>
							<asp:TextBox id="FirstPFPUMPHOUSE" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="FirstLoadPUMPHOUSE" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SecondPFPUMPHOUSE" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SecondLoadPUMPHOUSE" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="RemarksPUMPHOUSE" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>
							<asp:Label id="Label6" runat="server">6</asp:Label></TD>
						<TD>:</TD>
						<TD>
							<asp:Label id="SSWHEELSHOPESSENTIAL" runat="server" Width="260px">MELT SHOP</asp:Label></TD>
						<TD>
							<asp:TextBox id="FirstPFWHEELSHOPESSENTIAL" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="FirstLoadWHEELSHOPESSENTIAL" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SecondPFWHEELSHOPESSENTIAL" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SecondLoadWHEELSHOPESSENTIAL" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="RemarksWHEELSHOPESSENTIAL" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<%--<TR>
						<TD>
							<asp:Label id="Label7" runat="server">7</asp:Label></TD>
						<TD>:</TD>
						<TD>
							<asp:Label id="SSWHEELSHOPNONESSENTIAL" runat="server" Width="272px">WHEEL SHOP NON ESSENTIAL</asp:Label></TD>
						<TD>
							<asp:TextBox id="FirstPFWHEELSHOPNONESSENTIAL" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="FirstLoadWHEELSHOPNONESSENTIAL" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SecondPFWHEELSHOPNONESSENTIAL" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SecondLoadWHEELSHOPNONESSENTIAL" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="RemarksWHEELSHOPNONESSENTIAL" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					--%><TR>
						<TD>
							<asp:Label id="Label8" runat="server">7</asp:Label></TD>
						<TD>:</TD>
						<TD>
							<asp:Label id="SSTUBEPREHEAT" runat="server" Width="270px">TUBE PRE HEAT</asp:Label></TD>
						<TD>
							<asp:TextBox id="FirstPFTUBEPREHEAT" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="FirstLoadTUBEPREHEAT" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SecondPFTUBEPREHEAT" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SecondLoadTUBEPREHEAT" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="RemarksTUBEPREHEAT" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>
							<asp:Label id="Label9" runat="server">8</asp:Label></TD>
						<TD>:</TD>
						<TD>
							<asp:Label id="SSMOULDPREHEAT" runat="server" Width="260px">MOULD PRE HEAT</asp:Label></TD>
						<TD>
							<asp:TextBox id="FirstPFMOULDPREHEAT" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="FirstLoadMOULDPREHEAT" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SecondPFMOULDPREHEAT" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SecondLoadMOULDPREHEAT" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="RemarksMOULDPREHEAT" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>
							<asp:Label id="Label10" runat="server">9</asp:Label></TD>
						<TD>:</TD>
						<TD>
							<asp:Label id="SSFUMEEXTRACTION" runat="server" Width="258px">FUME EXTRACTION</asp:Label></TD>
						<TD>
							<asp:TextBox id="FirstPFFUMEEXTRACTION" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="FirstLoadFUMEEXTRACTION" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SecondPFFUMEEXTRACTION" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SecondLoadFUMEEXTRACTION" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="RemarksFUMEEXTRACTION" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>
							<asp:Label id="Label11" runat="server">10</asp:Label></TD>
						<TD>:</TD>
						<TD>
							<asp:Label id="SSCOMPRESSOR" runat="server" Width="273px">COMPRESSOR</asp:Label></TD>
						<TD>
							<asp:TextBox id="FirstPFCOMPRESSOR" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="FirstLoadCOMPRESSOR" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SecondPFCOMPRESSOR" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SecondLoadCOMPRESSOR" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="RemarksCOMPRESSOR" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<%--<TR>
						<TD>
							<asp:Label id="Label12" runat="server">12</asp:Label></TD>
						<TD>:</TD>
						<TD>
							<asp:Label id="SSASSEMBLY" runat="server" Width="252px">ASSEMBLY</asp:Label></TD>
						<TD>
							<asp:TextBox id="FirstPFASSEMBLY" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="FirstLoadASSEMBLY" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SecondPFASSEMBLY" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SecondLoadASSEMBLY" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="RemarksASSEMBLY" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					--%>
                    <%--<TR>
						<TD>
							<asp:Label id="Label13" runat="server">13</asp:Label></TD>
						<TD>:</TD>
						<TD>
							<asp:Label id="SSAXLESHOPESSENTIAL" runat="server" Width="200px">AXLE SHOP ESSENTIAL</asp:Label></TD>
						<TD>
							<asp:TextBox id="FirstPFAXLESHOPESSENTIAL" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="FirstLoadAXLESHOPESSENTIAL" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SecondPFAXLESHOPESSENTIAL" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SecondLoadAXLESHOPESSENTIAL" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="RemarksAXLESHOPESSENTIAL" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>--%>
					<%--<TR>
						<TD>
							<asp:Label id="Label14" runat="server">14</asp:Label></TD>
						<TD>:</TD>
						<TD>
							<asp:Label id="SSAXLESHOPNONESSENTIAL" runat="server" Width="262px">AXLE SHOP NON ESSENTIAL</asp:Label></TD>
						<TD>
							<asp:TextBox id="FirstPFAXLESHOPNONESSENTIAL" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="FirstLoadAXLESHOPNONESSENTIAL" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SecondPFAXLESHOPNONESSENTIAL" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SecondLoadAXLESHOPNONESSENTIAL" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="RemarksAXLESHOPNONESSENTIAL" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>--%>
					<%--<TR>
						<TD>
							<asp:Label id="Label15" runat="server">15</asp:Label></TD>
						<TD>:</TD>
						<TD>
							<asp:Label id="SSGFM" runat="server" Width="245px">GFM</asp:Label></TD>
						<TD>
							<asp:TextBox id="FirstPFGFM" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="FirstLoadGFM" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SecondPFGFM" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SecondLoadGFM" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="RemarksGFM" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					--%><%--<TR>
						<TD>
							<asp:Label id="Label16" runat="server">16</asp:Label></TD>
						<TD>:</TD>
						<TD>
							<asp:Label id="SSCANTEEN" runat="server">CANTEEN</asp:Label></TD>
						<TD>
							<asp:TextBox id="FirstPFCANTEEN" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="FirstLoadCANTEEN" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SecondPFCANTEEN" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SecondLoadCANTEEN" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="RemarksCANTEEN" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>--%>
					<TR>
						<TD>
							<asp:Label id="Label17" runat="server">11</asp:Label></TD>
						<TD>:</TD>
						<TD>
							<asp:Label id="SSCOLONY" runat="server">COLONY(1&2)</asp:Label></TD>
						<TD>
							<asp:TextBox id="FirstPFCOLONY" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="FirstLoadCOLONY" runat="server" CssClass="form-control" ></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SecondPFCOLONY" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SecondLoadCOLONY" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="RemarksCOLONY" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>
							<asp:Label id="Label21" runat="server">12</asp:Label></TD>
						<TD>:</TD>
						<TD>
							<asp:Label id="Label22" runat="server">COLONY(3&4)</asp:Label></TD>
						<TD>
							<asp:TextBox id="FirstPFCOLONY1" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="FirstLoadCOLONY1" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SecondPFCOLONY1" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SecondLoadCOLONY1" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="RemarksCOLONY1" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					
                    <TR>
						<TD>
							<asp:Label id="Label18" runat="server">13</asp:Label></TD>
						<TD>:</TD>
						<TD>
							<asp:Label id="SSADMIN" runat="server">ADMIN</asp:Label></TD>
						<TD>
							<asp:TextBox id="FirstPFADMIN" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="FirstLoadADMIN" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SecondPFADMIN" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SecondLoadADMIN" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="RemarksADMIN" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<%--<TR>
						<TD>
							<asp:Label id="Label19" runat="server">20</asp:Label></TD>
						<TD>:</TD>
						<TD>
							<asp:Label id="SSEMMS" runat="server">EMMS</asp:Label></TD>
						<TD>
							<asp:TextBox id="FirstPFEMMS" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="FirstLoadEMMS" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SecondPFEMMS" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SecondLoadEMMS" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="RemarksEMMS" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					--%><%--<TR>
						<TD>
							<asp:Label id="Label20" runat="server">21</asp:Label></TD>
						<TD>:</TD>
						<TD>
							<asp:Label id="SSLOP" runat="server">LOP</asp:Label></TD>
						<TD>
							<asp:TextBox id="FirstPFLOP" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="FirstLoadLOP" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SecondPFLOP" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SecondLoadLOP" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="RemarksLOP" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>--%>
                    <TR>
						<TD>
							<asp:Label id="Label23" runat="server">14</asp:Label></TD>
						<TD>:</TD>
						<TD>
							<asp:Label id="Label24" runat="server">PCS</asp:Label></TD>
						<TD>
							<asp:TextBox id="FirstPFPCS" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="FirstLoadPCS" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SecondPFPCS" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SecondLoadPCS" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="RemarksPCS" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					
					<TR>
						<TD  colSpan="8">
							<asp:Button id="btnSave" runat="server" Text="Save" CssClass="button button2"></asp:Button></TD>
					</TR>
				</TABLE>
				<asp:DataGrid id="DataGrid1" runat="server" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
			</asp:panel>
                </div>

		</form></div>
         <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
