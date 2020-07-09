<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MetlabReports.aspx.vb" Inherits="WebApplication2.MetlabReports" %>

<!DOCTYPE HTML>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>Metlab Material Testing Report</title>
		<link id="PCORepo" href="/wap.css" rel="stylesheet"/>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0"/>
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
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

        <%-- <link rel="stylesheet" href="../../../../StyleSheet1.css" />--%>
        <script>
              function isNumber1(evt, element) {

                    var charCode = (evt.which) ? evt.which : event.keyCode

                      if (
                           (charCode != 45 ) && (charCode != 47 ) &&     // 
                           (charCode < 48 || charCode > 57))
                      return false;

                  return true;
            } 
        </script>	</head>

	<body>
             <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
 <a class="navbar-brand p-0" href="#"><img src="../../../../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
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
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../../wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home " style="font-size:30px;"></i>
        </a></li>
       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out" style="font-size:30px;"></i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
          <img src="../../../../NewFolder1/CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="45"/>
        </a>
      </li>
     </ul>
      
  </div>
</nav>
<!--/.Navbar -->

         
         <div class="container">
              <div class="row">
                <div class="table-responsive">

		<form id="Form1" method="post" runat="server">
             <%--<h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
			<asp:Panel id="Panel1" runat="server">
				
				<TABLE id="Table2" class="table">
					<TR>
						<TD colSpan="3"> Metlab Material Testing Report</TD>
					</TR>
					<TR>
						<TD align="right"> LabNumber </TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="txtLabNumber" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD align="middle" colSpan="3">
                            <asp:Button id="btnFEMNCHEM" CssClass="button button2" runat="server" Text="FEMN Chemical Report"></asp:Button>
						</TD>
					</TR>
					<TR>
						<TD align="middle" colSpan="3">
                            <asp:Button id="btnFESICHEM" CssClass="button button2" runat="server" Text=" FESI Chemical Report">
							</asp:Button>
                            <asp:Button ID="btnSANDCHEM" runat="server" CssClass="button button2" Text="Sand Chemical Report" />
                        </TD>
					</TR>
					<TR>
						<TD align="middle" colSpan="3">
                            <asp:Button id="btnSIMNCHEM" CssClass="button button2" runat="server" Text="SIMN Chemical Report"></asp:Button>
							</TD>
					</TR>
					<TR>
						<TD align="middle" colSpan="3">
                             <asp:Button id="btnGP2CHEM" CssClass="button button2" runat="server" Text="GRAPHITE GRANUAL Chemical Report"></asp:Button>
                            
							</TD>
					</TR>
					<TR>
						<TD align="middle" colSpan="3">
                           <asp:Button id="btnLIMECHEM" runat="server" CssClass="button button2" Text="Calcelime Chemical Report"></asp:Button>
							</TD>
					</TR>
					<TR>
						<TD align="middle" colSpan="3">
                            <asp:Button id="btnSANDPHY" runat="server" CssClass="button button2" Text="Sand Physical Report"></asp:Button>
							</TD>
                        	<TD align="middle" colSpan="3">
                                &nbsp;</TD>
					</TR>
					<TR>
						<TD align="middle" colSpan="3">
                            <asp:Button id="btnFRCLAYPHY" runat="server" CssClass="button button2" Text="FireClay Physical Report"></asp:Button>
						</TD>
                        <TD align="middle" colSpan="3">
                            <asp:Button id="btnFRCLAYCHEM" runat="server" CssClass="button button2" Text="FireClay Chemical Report"></asp:Button>
						</TD>
					</TR>
                    <TR>
						<TD align="middle" colSpan="3">
                            <asp:Button id="btnMagBRkPHY" runat="server" CssClass="button button2" Text="Magnesite Bricks Physical Report"></asp:Button>
						</TD>
                        <TD align="middle" colSpan="3">
                            <asp:Button id="btnMagBRKCHEM" runat="server" CssClass="button button2" Text="Magnesite Bricks Chemical Report"></asp:Button>
						</TD>
					</TR>
                    <TR>
						<TD align="middle" colSpan="3">
                            <asp:Button id="btnMCBPHY" runat="server" CssClass="button button2" Text="Magnesia carbon Bricks Physical Report"></asp:Button>
						</TD>
                        <TD align="middle" colSpan="3">
                            <asp:Button id="btnMCBCHEM" runat="server" CssClass="button button2" Text="Magnesia carbon Bricks Chemical Report"></asp:Button>
						</TD>
					</TR>
                    <TR>
						<TD align="middle" colSpan="3">
                            <asp:Button id="btnHABPHY" runat="server" CssClass="button button2" Text="High Alumina Bricks Physical Report"></asp:Button>
						</TD>
                        <TD align="middle" colSpan="3">
                            <asp:Button id="btnHABCHEM" runat="server" CssClass="button button2" Text="High Alumina Bricks Chemical Report"></asp:Button>
						</TD>
					
                     
						<TD align="middle" colSpan="3">
                            <asp:Button id="btnISBPHY" runat="server" CssClass="button button2" Text="Safety Bricks Physical Report"></asp:Button>
						</TD>
                    </TR>
                    <tr>
                        <TD align="middle" colSpan="3">
                            <asp:Button id="btnISBCHEM" runat="server" CssClass="button button2" Text="Safety Bricks Chemical Report"></asp:Button>
						</TD>
                         <TD align="middle" colSpan="3">
                            <asp:Button id="btnVEEGUM" runat="server" CssClass="button button2" Text="Veegum Granules Chemical Report"></asp:Button>
						</TD>
                        </tr>
                    <tr>
                         <TD align="middle" colSpan="3">
                            <asp:Button id="btnSTEELSHOTS" runat="server" CssClass="button button2" Text="Steel Shots Report"></asp:Button>
						</TD>
                        
                         <TD align="middle" colSpan="3">
                            <asp:Button id="btnSLAG" runat="server" CssClass="button button2" Text="Slag Report"></asp:Button>
						</TD>
                        </tr>
                    <tr>
                          <TD align="middle" colSpan="3">
                            <asp:Button id="btnGAZEBINDER" runat="server" CssClass="button button2" Text="GAZE BIND Report"></asp:Button>
						</TD>
                          <TD align="middle" colSpan="3">
                            <asp:Button id="btnGAZETUBE" runat="server" CssClass="button button2" Text="GAZE TUBE Report"></asp:Button>
						</TD>
                          <TD align="middle" colSpan="3">
                            <asp:Button id="btnDOMEDISC" runat="server" CssClass="button button2" Text="DOME DISC Report"></asp:Button>
						</TD>
                        </tr>
                    <tr>
                         <TD align="middle" colSpan="3">
                            <asp:Button id="btnCOATEDSAND" runat="server" CssClass="button button2" Text="COATED SAND Report"></asp:Button>
						</TD>
                         <TD align="middle" colSpan="3">
                            <asp:Button id="btnALMSTAR" runat="server" CssClass="button button2" Text="ALUMINIUM STAR Report"></asp:Button>
						</TD>
                         <TD align="middle" colSpan="3">
                            <asp:Button id="btnAIRSETMORTOR" runat="server" CssClass="button button2" Text="AIRSETMORTOR"></asp:Button>
						</TD>
                        </tr>
                    <tr>
                         <TD align="middle" colSpan="3">
                            <asp:Button id="btnABSGASKET" runat="server" CssClass="button button2" Text="ABSGASKET"></asp:Button>
						</TD>
                         <TD align="middle" colSpan="3">
                            <asp:Button id="btnCERNONABSGASKET" runat="server" CssClass="button button2" Text="CERNONABSGASKET"></asp:Button>
						</TD>
                         <TD align="middle" colSpan="3">
                            <asp:Button id="btnCLAYGRAPSTOPPER" runat="server" CssClass="button button2" Text="CLAYGRAPSTOPPER"></asp:Button>
						</TD>
                        </tr>
                    <tr>

                         <TD align="middle" colSpan="3">
                            <asp:Button id="btnCMC" runat="server" CssClass="button button2" Text="CMC"></asp:Button>
						</TD>
                          
                          <TD align="middle" colSpan="3">
                            <asp:Button id="btnCRUSRAWDOLOMITE" runat="server" CssClass="button button2" Text="CRUSRAWDOLOMITE"></asp:Button>
						</TD>
                          <TD align="middle" colSpan="3">
                            <asp:Button id="btnDELTACASTABLE" runat="server" CssClass="button button2" Text="DELTACASTABLE"></asp:Button>
						</TD>
                        </tr>
                    <tr>
                          <TD align="middle" colSpan="3">
                            <asp:Button id="btnDRINKWATER" runat="server" CssClass="button button2" Text="DRINKWATER"></asp:Button>
						</TD>
                          <TD align="middle" colSpan="3">
                            <asp:Button id="btnDryRAMMASS" runat="server" CssClass="button button2" Text="DryRAMMASS"></asp:Button>
						</TD>
                         <TD align="middle" colSpan="3">
                            <asp:Button id="btnFLOURANCHALK" runat="server" CssClass="button button2" Text="FLOURANCHALK"></asp:Button>
						</tr>
                    <tr>
                         </TD>
                         <TD align="middle" colSpan="3">
                            <asp:Button id="btnFLOUSPHAR" runat="server" CssClass="button button2" Text="FLOUSPHAR"></asp:Button>
						</TD>
                        </tr>
                    <tr>
                         <TD align="middle" colSpan="3">
                            <asp:Button id="btnFUSEDSILICASAND" runat="server" CssClass="button button2" Text="FUSEDSILICASAND"></asp:Button>
						</TD>
                         <TD align="middle" colSpan="3">
                            <asp:Button id="btnGARLOCKPOURTUBEGASKET" runat="server" CssClass="button button2" Text="GARLOCKPOURTUBEGASKET"></asp:Button>
						</TD>
                        </tr>
                    <tr>
                         <TD align="middle" colSpan="3">
                            <asp:Button id="btnGRAPHMOULDBLANKET" runat="server" CssClass="button button2" Text="GRAPHMOULDBLANKET"></asp:Button>
						</TD>
                        </tr>
                    <tr>
                          <TD align="middle" colSpan="3">
                            <asp:Button id="btnGUNNINGMASS" runat="server" CssClass="button button2" Text="GUNNINGMASS"></asp:Button>
						</TD>
                          <TD align="middle" colSpan="3">
                            <asp:Button id="btnHDDRM" runat="server" CssClass="button button2" Text="HDDRM"></asp:Button>
						</TD>
                        </tr>
                    <tr>
                          <TD align="middle" colSpan="3">
                            <asp:Button id="btnHEXAMINE" runat="server" CssClass="button button2" Text="HEXAMINE"></asp:Button>
						</TD>
                        </tr>
                    <tr>
                          <TD align="middle" colSpan="3">
                            <asp:Button id="btnINGATESLEEVE" runat="server" CssClass="button button2" Text="INGATESLEEVE"></asp:Button>
						</TD>
                          <TD align="middle" colSpan="3">
                            <asp:Button id="btnLADLEINSULATMATERIAL" runat="server" CssClass="button button2" Text="LADLEINSULATMATERIAL"></asp:Button>
						</TD>
                        </tr>
                    <tr>
                         <TD align="middle" colSpan="3">
                            <asp:Button id="btnMSPLATE" runat="server" CssClass="button button2" Text="MSPLATE"></asp:Button>
						</TD>
                        </tr>
                    <tr>
                         <TD align="middle" colSpan="3">
                            <asp:Button id="btnPOURINGTUBE" runat="server" CssClass="button button2" Text="POURINGTUBE"></asp:Button>
						</TD>
                         <TD align="middle" colSpan="3">
                            <asp:Button id="btnWETRAMMINGMASS" runat="server" CssClass="button button2" Text="WETRAMMINGMASS"></asp:Button>
						</TD>
                         </tr>
					
				</TABLE>
				
				
			</asp:Panel>
		</form>
                     </div></div></div>
        <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</html>