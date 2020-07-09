<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MouldRoomPosition.aspx.vb" Inherits="WebApplication2.MouldRoomPosition" %>
<!DOCTYPE HTML >
<HTML>
	<HEAD runat="server">
		<title>MouldRoomPosition</title>
		<META content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<META content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">

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
        <link rel="stylesheet" href="../../StyleSheet1.css" />
	</HEAD>
	<BODY >
         <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
  <a class="navbar-brand p-0" href="#"><img src="../../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent-333"
    aria-controls="navbarSupportedContent-333" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>
  <div class="collapse navbar-collapse " id="navbarSupportedContent-333">
      <ul class="navbar-nav ml-auto  navbar-center">
          <li class="nav-item" style="font-weight: bold">
             <h1 style="color:white; font-size:30px; margin-left:430px; margin-top:5px">Rail Wheel Plant, Bela</h1> 
       
         </li>
          <%--<li class="nav-item"> <a class="nav-link" href="#" style="color:white; font-size:25px;">Rail Wheel Plant Bela</a></li>--%>
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
          <%--<img src="../../NewFolder1/CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="45"/>--%>
            <img src="../../NewFolder1/CRIS-Recruitment.jpg" height="45" style="border-radius:43%"/>
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
			<asp:panel id="Panel1"  runat="server" >
				<TABLE id="Table4" class="table">
					<TR>
						<TD></TD></TR></table>
							<asp:Panel id="Panel2" runat="server" >
								<TABLE id="Table2" class="table">
									<TR>
										<TD colSpan="3"><FONT size="5">Mould Room Out-Turn</FONT><hr class="prettyline" />
										</TD>
									</TR>
									<TR>
										<TD colSpan="3">
											<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></TD>
									</TR>
									<TR>
										<TD >Date</TD>
										<TD>:</TD>
										<TD>
											<asp:TextBox id="txtDate" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 69px">Shift</TD>
										<TD>:</TD>
										<TD>
											<asp:RadioButtonList id="rblShift" runat="server" CssClass="rbl" AutoPostBack="True" RepeatDirection="Horizontal" RepeatLayout="Flow">
												<asp:ListItem Value="A" Selected="True">A</asp:ListItem>
												<asp:ListItem Value="B">B</asp:ListItem>
												<asp:ListItem Value="C">C</asp:ListItem>
											</asp:RadioButtonList></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 69px">ShiftInCharge</TD>
										<TD>:</TD>
										<TD>
											<asp:TextBox id="ShiftInC" runat="server" CssClass="form-control"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 69px">WheelsCast</TD>
										<TD>:</TD>
										<TD>
											<asp:TextBox id="WhlsCast" runat="server" CssClass="form-control"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 69px">MROffLoad</TD>
										<TD>:</TD>
										<TD>
											<asp:TextBox id="MROffLoad" runat="server" CssClass="form-control"></asp:TextBox></TD>
									</TR>
								</TABLE>
							</asp:Panel>
						
							<asp:Panel id="Panel3" runat="server" >
								<TABLE id="Table3" class="table">
									<TR>
										<TD>FromDate</TD>
										<TD>:</TD>
										<TD>
											<asp:TextBox id="txtFr" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD>ToDate</TD>
										<TD>:</TD>
										<TD>
											<asp:TextBox id="txtTo" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD align="center" colSpan="3">
											<asp:Button id="btnShow" runat="server" Text="Show" CssClass="button button2"></asp:Button></TD>
									</TR>
								</TABLE>
							</asp:Panel>
							<asp:Panel id="Panel4" runat="server" >
								<TABLE id="Table5" class="table">
									<TR>
										<TD colSpan="3">Melting : Rail Cuts</TD>
									</TR>
									<TR>
										<TD>RailCuts&lt;12"</TD>
										<TD>:</TD>
										<TD>
											<asp:TextBox id="RCLess12" runat="server" CssClass="form-control"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD>RailCuts&gt;18"</TD>
										<TD>:</TD>
										<TD>
											<asp:TextBox id="RCGr18" runat="server" CssClass="form-control"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD colSpan="3">
											<asp:Button id="btnMelt" runat="server" Text="Save Rail Cuts Data" CssClass="button button2"></asp:Button></TD>
									</TR>
								</TABLE>
							</asp:Panel>
						
							
						
					
				<TABLE id="Table1" class="table">
					<TR>
						<TD>SlNo</TD>
						<TD >Equipment</TD>
						<TD>Qty</TD>
						<TD>LineInCharge</TD>
						<TD>Remarks</TD>
					</TR>
					<TR>
						<TD >1</TD>
						<TD >SPG1</TD>
						<TD >
							<asp:TextBox id="SW1Qty" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD >
							<asp:TextBox id="SW1InC" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD >
							<asp:TextBox id="SW1Remarks" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>2</TD>
						<TD >SPG2</TD>
						<TD>
							<asp:TextBox id="SW2Qty" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SW2InC" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SW2Remarks" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>3</TD>
						<TD >SPG3</TD>
						<TD>
							<asp:TextBox id="SW3Qty" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SW3InC" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SW3Remarks" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>4</TD>
						<TD >SPG4</TD>
						<TD>
							<asp:TextBox id="SW4Qty" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SW4InC" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SW4Remarks" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>5</TD>
						<TD >SPG5</TD>
						<TD>
							<asp:TextBox id="SW5Qty" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SW5InC" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SW5Remarks" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>6</TD>
						<TD >SPG6</TD>
						<TD>
							<asp:TextBox id="SW6Qty" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SW6InC" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SW6Remarks" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>7</TD>
						<TD >SPG7</TD>
						<TD>
							<asp:TextBox id="SW7Qty" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SW7InC" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SW7Remarks" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>8</TD>
						<TD >SPG8</TD>
						<TD>
							<asp:TextBox id="SW8Qty" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SW8InC" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SW8Remarks" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>&nbsp;</TD>
						<TD >No.ofSWwheelsChipped</TD>
						<TD>
							<asp:TextBox id="SWCQty" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SWCInC" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SWCRemarks" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>9</TD>
						<TD >SprueGrindingMachine1</TD>
						<TD>
							<asp:TextBox id="SGM1Qty" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SGM1InC" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SGM1Remarks" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>10</TD>
						<TD >SprueGrindingMachine2</TD>
						<TD>
							<asp:TextBox id="SGM2Qty" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SGM2InC" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SGM2Remarks" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>11</TD>
						<TD >SprueGrindingMachine3</TD>
						<TD>
							<asp:TextBox id="SGM3Qty" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SGM3InC" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SGM3Remarks" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>12</TD>
						<TD >SprueGrindingMachine4</TD>
						<TD>
							<asp:TextBox id="SGM4Qty" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SGM4InC" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SGM4REmarks" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>&nbsp;</TD>
						<TD >No.ofSPGwheelsChipped</TD>
						<TD>
							<asp:TextBox id="SWPGQty" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SWPGInC" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="SWPGRemarks" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>&nbsp;</TD>
						<TD >NoofWheelsSW(WTL)</TD>
						<TD>
							<asp:TextBox id="SWLess400" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>WrkStsOfTempRec</TD>
						<TD>
							<asp:TextBox id="SWRecSts" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>13</TD>
						<TD >HubCuttingMachine1</TD>
						<TD>
							<asp:TextBox id="HCM1Qty" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="HCM1InC" runat="server" CssClass="form-control" ></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="HCM1Remarks" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>14</TD>
						<TD >HubCuttingMachine2</TD>
						<TD>
							<asp:TextBox id="HCM2Qty" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="HCM2InC" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="HCM2Remarks" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>15</TD>
						<TD >HubCuttingMachine3</TD>
						<TD>
							<asp:TextBox id="HCM3Qty" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="HCM3InC" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="HCM3Remarks" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<%--<TR>
						<TD>16</TD>
						<TD style="WIDTH: 89px">HubCuttingMachine4</TD>
						<TD>
							<asp:TextBox id="HCM4Qty" runat="server" Width="83px"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="HCM4InC" runat="server" Width="83px"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="HCM4Remarks" runat="server" Width="118px"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>17</TD>
						<TD style="WIDTH: 89px">HubCuttingMachine5</TD>
						<TD>
							<asp:TextBox id="HCM5Qty" runat="server" Width="83px"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="HCM5InC" runat="server" Width="83px"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="HCM5Remarks" runat="server" Width="118px"></asp:TextBox></TD>
					</TR>
					--%><TR>
						<TD>&nbsp;</TD>
						<TD >NoofWheelsHC(WTL)</TD>
						<TD>
							<asp:TextBox id="HCLess250" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>WrkStsOfTempRec</TD>
						<TD>
							<asp:TextBox id="HCRecSts" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<%--<TR>
						<TD>18</TD>
						<TD style="WIDTH: 89px">NFChargingOnlyNNDwhls</TD>
						<TD>
							<asp:TextBox id="NFCQty" runat="server" Width="83px"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="NFCInC" runat="server" Width="83px"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="NFCRemarks" runat="server" Width="118px"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>19</TD>
						<TD style="WIDTH: 89px">NFDisChargingOnlyNNDwhls</TD>
						<TD>
							<asp:TextBox id="NFDQty" runat="server" Width="83px"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="NFDInC" runat="server" Width="83px"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="NFDRemarks" runat="server" Width="118px"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>20</TD>
						<TD style="WIDTH: 89px">DFDisChargingWhls</TD>
						<TD>
							<asp:TextBox id="DFDQty" runat="server" Width="83px"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="DFDInC" runat="server" Width="83px"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="DFDRemarks" runat="server" Width="118px"></asp:TextBox></TD>
					</TR>
					--%><TR>
						<TD>16</TD>
						<TD >NoOfCopesBaked</TD>
						<TD>
							<asp:TextBox id="CBQty" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="CBInC" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="CBRemarks" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>&nbsp;</TD>
						<TD >BrushStatusofRK1</TD>
						<TD>
							<asp:TextBox id="RK1BrushSts" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>Brush Sts of RK2</TD>
						<TD>
							<asp:TextBox id="RK2BrushSts" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>&nbsp;</TD>
						<TD >PadCurrentofC5IE</TD>
						<TD>
							<asp:TextBox id="C5IE" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox></TD>
						<TD>of C5IW</TD>
						<TD>
							<asp:TextBox id="C5IW" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>&nbsp;</TD>
						<TD style="WIDTH: 89px">PadCurrentofC5KE</TD>
						<TD>
							<asp:TextBox id="C5KE" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>of C5KW</TD>
						<TD>
							<asp:TextBox id="C5KW" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>17</TD>
						<TD >NoOfCopesSprayed</TD>
						<TD>
							<asp:TextBox id="CSQty" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="CSInC" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="CSRemarks" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>&nbsp;</TD>
						<TD >NoOfCopesSpared&gt;230`C</TD>
						<TD>
							<asp:TextBox id="CSGr230" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>&nbsp;&lt; 170` C</TD>
						<TD>
							<asp:TextBox id="CSLess170" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>&nbsp;</TD>
						<TD >WrkStsofTempRecorder</TD>
						<TD colSpan="3">
							<asp:TextBox id="CSRecSts" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>18</TD>
						<TD >NoOfDragsSprayed</TD>
						<TD>
							<asp:TextBox id="DSQty" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="DSInC" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="DSRemarks" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>&nbsp;</TD>
						<TD>NoOfDrasSpared&gt;230`C</TD>
						<TD>
							<asp:TextBox id="DSGr230" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>&nbsp;&lt; 170` C</TD>
						<TD>
							<asp:TextBox id="DSLess170" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>&nbsp;</TD>
						<TD >WrkStsofTempRecorder</TD>
						<TD colSpan="3">
							<asp:TextBox id="DSRecSts" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>19</TD>
						<TD >NoOfCopesOnLine</TD>
						<TD>
							<asp:TextBox id="COLQty" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="COLInC" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="COLRemarks" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>20</TD>
						<TD >NoOfDragsOnLine</TD>
						<TD>
							<asp:TextBox id="DOLQty" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="DOLInC" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="DOLRemarks" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>21</TD>
						<TD >NoOfBakingDamage</TD>
						<TD>
							<asp:TextBox id="NBDQty" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="NBDInC" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="NBDRemarks" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>22</TD>
						<TD >DomeDiscUsed</TD>
						<TD>
							<asp:TextBox id="DDUQty" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="DDUInC" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:TextBox id="DDURemarks" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<%--<TR>
						<TD>&nbsp;</TD>
						<TD >
							<asp:Button id="btnSave" runat="server" Text="Save" CssClass="button button2"></asp:Button></TD>
						<TD>&nbsp;</TD>
						<TD>
							<asp:Button id="btnClear" runat="server" Text="Clear" CssClass="button button2"></asp:Button></TD>
						<TD>&nbsp;</TD>
					</TR>--%>
				</TABLE>
                <TABLE id="Table6" class="table">
								<TR>
									<TD colSpan="2">AddedToLine</TD>
									<TD>Qty</TD>
									<TD>LineInCharge</TD>
									<TD>Remarks</TD>
								</TR>
								<TR>
									<TD>23</TD>
									<TD>Copes</TD>
									<TD>
										<asp:TextBox id="CopesQty" runat="server" CssClass="form-control"></asp:TextBox></TD>
									<TD>
										<asp:TextBox id="CopesInC" runat="server" CssClass="form-control"></asp:TextBox></TD>
									<TD>
										<asp:TextBox id="CopesRemarks" runat="server" CssClass="form-control"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD></TD>
									<TD>Drags</TD>
									<TD>
										<asp:TextBox id="DragsQty" runat="server" CssClass="form-control"></asp:TextBox></TD>
									<TD>
										<asp:TextBox id="DragsInC" runat="server" CssClass="form-control"></asp:TextBox></TD>
									<TD>
										<asp:TextBox id="DragsRemarks" runat="server" CssClass="form-control"></asp:TextBox></TD>
								</TR>
                                <tr>
                                    <td>24</td>
                                    <td>
                                        Sent to MRS:<br /></td>
                                    </tr>
                                <tr>
                                    <td></td>
                                    <td>
                                        cope</td>
                                    <td><asp:TextBox ID="CopesMQty" runat="server" CssClass="form-control"></asp:TextBox></td>
                                    <td><asp:TextBox ID="CopesMInc" runat="server" CssClass="form-control"></asp:TextBox></td>
                                    <td><asp:TextBox ID="CopesMRemarks" runat="server" CssClass="form-control"></asp:TextBox></td>
                                      </tr>
                                <tr> 
                                    <td></td>
                                    <td>Drag</td>
                                    
                                    <td><asp:TextBox ID="DragsMQty" runat="server" CssClass="form-control"></asp:TextBox><br /></td>
                                    <td><asp:TextBox ID="DragsMInc" runat="server" CssClass="form-control"></asp:TextBox> </td>
                                    <td><asp:TextBox ID="DragsMRemarks" runat="server" CssClass="form-control"></asp:TextBox></td>
                                    </tr>
								<TR>
									<TD>25</TD>
									<TD>SandBatches</TD>
									<TD>
										<asp:TextBox id="SandQty" runat="server" CssClass="form-control"></asp:TextBox></TD>
									<TD>
										<asp:TextBox id="SandInC" runat="server" CssClass="form-control"></asp:TextBox></TD>
									<TD>
										<asp:TextBox id="SandRemarks" runat="server" CssClass="form-control"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD>26</TD>
									<TD>PouringTubes</TD>
									<TD>
										<asp:TextBox id="PTQty" runat="server" CssClass="form-control"></asp:TextBox></TD>
									<TD>
										<asp:TextBox id="PTInC" runat="server" CssClass="form-control"></asp:TextBox></TD>
									<TD>
										<asp:TextBox id="PTRemarks" runat="server" CssClass="form-control"></asp:TextBox></TD>
								</TR>
							</TABLE>
							<TABLE id="Table7" class="table">
								<TR>
									<TD></TD>
									<TD>MPO1</TD>
									<TD>MPO2</TD>
									<TD>MPO3</TD>
								</TR>
								<TR>
									<TD>InUse</TD>
									<TD>
										<asp:RadioButtonList id="MPO1" runat="server" CssClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow">
											<asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
											<asp:ListItem Value="0">No</asp:ListItem>
										</asp:RadioButtonList></TD>
									<TD>
										<asp:RadioButtonList id="MPO2" runat="server" CssClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow">
											<asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
											<asp:ListItem Value="0">No</asp:ListItem>
										</asp:RadioButtonList></TD>
									<TD>
										<asp:RadioButtonList id="MPO3" runat="server" CssClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow">
											<asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
											<asp:ListItem Value="0">No</asp:ListItem>
										</asp:RadioButtonList></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="4"></TD>
								</TR>
                     <TR>
						<TD>&nbsp;</TD>
						<TD >
							<asp:Button id="btnSave" runat="server" Text="Save" CssClass="button button2"></asp:Button></TD>
						<TD>&nbsp;</TD>
						<TD>
							<asp:Button id="btnClear" runat="server" Text="Clear" CssClass="button button2"></asp:Button></TD>
						<TD>&nbsp;</TD>
					</TR>
                               
							</TABLE>
				<asp:DataGrid id="DataGrid1" runat="server" BackColor="White" CellPadding="4" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
			</asp:panel></div></div>
		</FORM></div>
         <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</BODY>
</HTML>
