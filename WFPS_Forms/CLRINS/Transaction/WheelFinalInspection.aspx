<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WheelFinalInspection.aspx.vb" Inherits="WebApplication2.WheelFinalInspection" Culture="en-GB" uiCulture="en-GB" smartNavigation="True" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
	<head runat="server">
		<title>WheelFinalInspection</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR"/>
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
         <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css"/>

   <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js"></script>
         <link type="text/css" rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
       <%-- <link rel="stylesheet" href="../../../StyleSheet1.css" />--%>
             <script type="text/javascript">
    
          
    function isInputNumber(evt) {

                    var ch = String.fromCharCode(evt.which);
        if (!(/[0-9]/.test(ch)))
        {
        evt.preventDefault();
    }

         }
</script>
	</head>
	<body  >
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
    
                  <%--<h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
      </div>
            <div class="row"><div class="table-responsive">
			<table id="Table7"  class="table"></table>
                 
				 <%--<asp:panel id="pnlLoginSts" runat="server"   >
								
							
						</asp:panel>--%>
                        
				       
						<%--<table id="Table8"  class="table"></table>--%>
           
							<asp:panel id="pnlWheel" runat="server">
                                	
										<table id="Table2" class="table">
											<tr>
												<td   colspan="5"><strong><FONT color="#0066ff" size="4">Wheel 
															Final Inspection<hr class="prettyline"/></FONT></strong></td>
											</tr>
											<tr>
												<td  colspan="5"><%--vAlign="center" noWrap align="middle" width="100%"--%>
													<asp:Label id="Label1" runat="server" ForeColor="Red"></asp:Label></td>
											</tr>
											<tr>
												<td >Message</td>
												<td colspan="4">
													<asp:Label id="lblMessage" runat="server" Width="507px" Font-Size="Medium" Font-Bold="True" ForeColor="Red"></asp:Label></td>
											</tr>
                                            
									<tr>
										<td>  Insp Date</td>
											<td><asp:Label id="lblInspDate" runat="server"  Font-Size="Small"></asp:Label></td>
								 
										<td><strong>Shift </strong></td>
                                        	<td>
                                                  <asp:DropDownList ID="shift_dd1" runat="server" AutoPostBack="true"  CssClass="form-control ll"  >
                                                                    <%--  <asp:ListItem>select</asp:ListItem>--%>
                                                               <asp:ListItem>A</asp:ListItem>
                                                         <asp:ListItem>B</asp:ListItem>
                                                           <asp:ListItem>C</asp:ListItem>
                                                            <asp:ListItem>G</asp:ListItem>
                                                      </asp:DropDownList>
											<%--<asp:Label id="lblShift" runat="server"  Font-Size="Small"></asp:Label>
											<asp:CheckBox id="chkGenShift" runat="server" AutoPostBack="True" Text="G"></asp:CheckBox>--%></td>
									 </tr>
									<tr>
										<td><strong><FONT size="2">Inspector</FONT></strong></td>
										<td><asp:Label id="lblInspector" runat="server"  Font-Size="Small"></asp:Label></td>
									</tr>
									
								 
											<tr>
												
												<td nowrap>Heat Number</td>
												<td style="WIDTH: 107px"  >
													<asp:TextBox id="txtHeatNumber" runat="server"  CssClass="form-control" onkeypress="isInputNumber(event)" ToolTip="enter Heat number(in numeric)" MaxLength="6" AutoPostBack="True"></asp:TextBox></td>
												<td>Wheel Number [Alt+W]</td>
												<td  nowrap>
													<asp:TextBox id="txtWheelNumber" accessKey="W" runat="server" onkeypress="isInputNumber(event)"  ToolTip="enter Wheel number(in numeric)" MaxLength="3" CssClass="form-control" AutoPostBack="True"></asp:TextBox></td>
                                                <td>
													<asp:Label id="lbl20thWheel" runat="server" Font-Bold="True" ForeColor="Magenta" Visible="False">20th Wheel</asp:Label>
													<asp:Label id="lblFirstCastWheel" runat="server" Font-Bold="True" ForeColor="Blue" Visible="False">1st Cast Wheel</asp:Label></td>
											</tr>
											<tr>
											<%--	<td noWrap>Wheel Location</td>
												<td noWrap>
													<asp:Label id="lblLocation" runat="server" Font-Bold="True"></asp:Label></td>--%>
												<td noWrap>Wheel Sts</td>
												<td style="WIDTH: 107px" noWrap>
													<asp:Label id="lblMasterStatus" runat="server" Font-Bold="True"></asp:Label></td>
												<td noWrap>Mag Sts:
													<asp:Label id="lblMagSts" runat="server" Font-Bold="True"></asp:Label></td>
											</tr></table>
											 
													<table id="Table4"  class="table">
														<tr>
															<td noWrap>&nbsp;
																<asp:Label id="lblMcnWhl" runat="server" Font-Bold="True" ForeColor="Blue">M/c whl</asp:Label></td>
															<td noWrap>Tread Dia</td>
															<td noWrap>Bore Dia</td>
															<td noWrap>Plate Thickness</td>
														<%--	<td noWrap>Rim Thickness</td>--%>
															<td noWrap>Captured Data</td>
														</tr>
														<tr>
															<td noWrap>Size</td>
															<td noWrap>
																<asp:TextBox id="txtTreadDia" runat="server" CssClass="form-control"     ToolTip="enter Tread diameter(in mm)" AutoPostBack="True"></asp:TextBox></td>
															<td noWrap>
																<asp:TextBox id="txtBoreDia" runat="server" CssClass="form-control"     ToolTip="enter Bore diameter(in mm)"  AutoPostBack="True"></asp:TextBox>-1=UB;0=OK</td>
															<td noWrap>
																<asp:textbox id="txtPlateThickness" runat="server" CssClass="form-control"    ToolTip="enter Plate Thickness(in mm)" AutoPostBack="True"></asp:textbox></td>
														<%--	<td noWrap>--%>
															<%--	<asp:textbox id="txtRimThickness" runat="server" CssClass="form-control"  ToolTip="enter  Rim Thickness(in mm)" AutoPostBack="True"></asp:textbox>--%></td>
															<td noWrap>Wheel Weight</td>
														</tr>
                                                    <%--    </table>
                                <table id="table12" class="table">--%>
														<tr>
															<td noWrap>Bore_Status</td>
															<%--<td vAlign="center" nowrap >N.A.</td>--%>
															<td noWrap>
                                                                 <asp:DropDownList ID="rdoBoreSt" runat="server" AutoPostBack="true"  CssClass="form-control ll"  >
                                                                    <%--  <asp:ListItem>select</asp:ListItem>--%>
                                                               <asp:ListItem>OK</asp:ListItem>
                                                         <asp:ListItem>Over Size</asp:ListItem>
                                                           <asp:ListItem>UB</asp:ListItem>
                                                            <asp:ListItem>BNC</asp:ListItem>
                                                                <asp:ListItem>GB</asp:ListItem>
                                                                   <asp:ListItem>UBPB</asp:ListItem>
                                                                      </asp:DropDownList>
                    
																<%--<asp:radiobuttonlist id="rdoBoreSts" runat="server" CssClass="rbl" RepeatLayout="Flow" AutoPostBack="True" RepeatDirection="Horizontal">
																	<asp:ListItem Value="OK">OK</asp:ListItem>
																	<asp:ListItem Value="BOS">Over Size</asp:ListItem>
																	<asp:ListItem Value="UB">UB</asp:ListItem>
                                                                    <asp:ListItem Value="UB">BNC</asp:ListItem>
                                                                  <asp:ListItem Value="UB">GB</asp:ListItem>
                                                                  <asp:ListItem Value="UB">UBPB</asp:ListItem></asp:radiobuttonlist>
                                                                  --%>

                                                                  
																</td>
                                                            <td noWrap>Plate_Status</td>
															<td noWrap>
                                                                 <asp:DropDownList ID="rdoPlateSt" runat="server" AutoPostBack="true"   CssClass="form-control ll"  >
                                                                  <%--    <asp:ListItem>select</asp:ListItem>--%>
                                                               <asp:ListItem>OK</asp:ListItem>
                                                         <asp:ListItem>NOT OK</asp:ListItem>
                                                        
                                                                      </asp:DropDownList>
																<%--<asp:radiobuttonlist id="rdoPlateSts" runat="server" CssClass="rbl" RepeatLayout="Flow" AutoPostBack="True" RepeatDirection="Horizontal">
																	<asp:ListItem Value="OK">OK</asp:ListItem>
                                                                    <asp:ListItem Value="NOTOK">NOT OK</asp:ListItem>
																</asp:radiobuttonlist>--%></td>
                                                            <td noWrap>Rim_Status</td>
															<td noWrap>
                                                                 <asp:DropDownList ID="rdoRimSt" runat="server" AutoPostBack="true"   CssClass="form-control ll"  >
                                                                      <%--<asp:ListItem>select</asp:ListItem>--%>
                                                               <asp:ListItem>OK</asp:ListItem>
                                                         <asp:ListItem>NOT OK</asp:ListItem>
                                                        
                                                                      </asp:DropDownList>
																<%--<asp:radiobuttonlist id="rdoRimSts" runat="server"  CssClass="rbl" RepeatLayout="Flow" AutoPostBack="True"    RepeatDirection="Horizontal">
																	<asp:ListItem Value="OK">OK</asp:ListItem>
                                                                    <asp:ListItem Value="NOTOK">NOT OK</asp:ListItem>
																</asp:radiobuttonlist>--%></td>
															<td noWrap>
																<asp:Label id="lblWheelWeight" runat="server"></asp:Label></td>
														</tr>
                                                        <tr>
                                                            <td >HubLength</td>
                                                            <td  >
                                                                 <asp:DropDownList ID="hubst" runat="server" AutoPostBack="true"  CssClass="form-control ll" >
                                                                      <%--<asp:ListItem>select</asp:ListItem>--%>
                                                               <asp:ListItem>OK</asp:ListItem>
                                                         <asp:ListItem>NOT OK</asp:ListItem>
                                                        
                                                                      </asp:DropDownList>
	                                                        <%--   <asp:radiobuttonlist id="Radiobuttonlist2" runat="server" CssClass="rbl" RepeatLayout="Flow" AutoPostBack="True" RepeatDirection="Horizontal">
																	<asp:ListItem Value="OK">OK</asp:ListItem>
                                                                    <asp:ListItem Value="NOTOK">NOT OK</asp:ListItem>
																</asp:radiobuttonlist>--%>
                                                            </td>
                                                            <td>Hub Dia</td>
                                                            <td >
                                                                 <asp:DropDownList ID="hubdiast" runat="server" AutoPostBack="true"  CssClass="form-control ll" >
                                                                      <%--<asp:ListItem>select</asp:ListItem>--%>
                                                               <asp:ListItem>OK</asp:ListItem>
                                                         <asp:ListItem>NOT OK</asp:ListItem>
                                                        
                                                                      </asp:DropDownList>
                                                                	<%--<asp:radiobuttonlist id="Radiobuttonlist3" runat="server" CssClass="rbl" RepeatLayout="Flow" AutoPostBack="True" RepeatDirection="Horizontal">
																	<asp:ListItem Value="OK">OK</asp:ListItem>
                                                                    <asp:ListItem Value="NOTOK">NOT OK</asp:ListItem>
																</asp:radiobuttonlist>--%>
                                                            </td>
                                                            </tr>
													</table>
													<asp:Label id="lblFiMcnOpn" runat="server"  Font-Bold="True" Visible="False"></asp:Label>
													<asp:Label id="lblReclWhl" runat="server" Font-Size="Medium" Font-Bold="True" ForeColor="Red" Visible="False"></asp:Label></TD>
										 <table id="Table5" class="table">
														<tr>
															<td >BOC_Remarks:
																<%--<asp:CheckBox id="chk20thwhlRems" runat="server" AutoPostBack="True" Text="Put 20th wheel remarks" Font-Bold="True" Visible="False"></asp:CheckBox>&nbsp;
																<asp:CheckBox id="chkAllowLPTRej" runat="server" AutoPostBack="True" Text="Allow Hold Wheel Rejection" Font-Bold="True" Visible="False"></asp:CheckBox>
																<asp:CheckBox id="chkRDTY" runat="server" AutoPostBack="True" Text="RDTY BOC OK" Font-Bold="True"></asp:CheckBox>--%>&nbsp;&nbsp;</td>
                                                            <td colspan="2">
																<asp:TextBox id="txtRemarks" runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="250" Width="400px"></asp:TextBox></td>
                                                       </tr>
                                                        <tr><td>
                                                                        <asp:Label ID="lblRdtyBoc" runat="server" Font-Bold="True"> Rty BOC:</asp:Label>
                                                                    </td>
                                                            <td>
                                                                	<asp:radiobuttonlist id="Radiobuttonlist1" runat="server" CssClass="rbl" RepeatLayout="Flow" AutoPostBack="True" RepeatDirection="Horizontal">
																	<asp:ListItem Value="OK">OK</asp:ListItem>
                                                                    <asp:ListItem Value="NOTOK">NOT OK</asp:ListItem>
																</asp:radiobuttonlist>
                                                                       <%-- <asp:TextBox ID="txtRdtyBoc" runat="server" CssClass="form-control" MaxLength="5" Width="400px"></asp:TextBox>--%>
                                                                    </td>
														</tr>
													<tr><%--<td>	<asp:Label id="lblRdtySize" runat="server"  Font-Bold="True"> RDTY Size:</asp:Label></td>
															<td>	<asp:TextBox id="txtRdtySize" runat="server" CssClass="form-control" MaxLength="5" Width="400px"></asp:TextBox></td>--%>
                                                        
													</tr>		
                                                            
														
													
														<tr>
															<td >Wheel Status</td>
															
																
														
															<td  noWrap>
																<asp:radiobuttonlist id="rdoWheelSts" runat="server" CssClass="rbl" AutoPostBack="True" RepeatDirection="Horizontal" RepeatLayout="Flow">
																	<asp:ListItem Value="PASSED">Pass</asp:ListItem>
																	<asp:ListItem Value="UnBore Pass">UnBore Pass</asp:ListItem>
																	<asp:ListItem Value="W">Rework</asp:ListItem>
																	<asp:ListItem Value="R">Reject</asp:ListItem>
																</asp:radiobuttonlist></td>
															<td noWrap>
															<%--	<asp:dropdownlist id="ddlRewRejcodes" runat="server" CssClass="form-control ll" AutoPostBack="True" Width="400px"></asp:dropdownlist></td>
														<td nowrap>
                                                            <asp:Label id="lblRejRewCodes" runat="server">Rej/Rew Codes</asp:Label>
														</td></tr>
														<tr>
															<td  noWrap colspan="2">
																<asp:radiobuttonlist id="rdoUbPassType" runat="server" CssClass="form-control ll" AutoPostBack="True" Visible="False" RepeatDirection="Horizontal" RepeatLayout="Flow">
																	<asp:ListItem Value="UnBore-AB">UnBorePass-AccentricBore</asp:ListItem>
																	<asp:ListItem Value="UnBore-GB">UnBorePass-GougedBore</asp:ListItem>
																	<asp:ListItem Value="UnBorePass_SmallBore">UnBorePass_SmallBore</asp:ListItem>
																	<asp:ListItem Value="UnBore_NB">UnBorePass_MachineDown</asp:ListItem>
																</asp:radiobuttonlist></td>--%>
														</tr>
													</table>
											<%--	<strong>Grid Option:</strong>&nbsp;
													<asp:DropDownList id="ddlGridOption" runat="server" AutoPostBack="True" CssClass="form-control ll" Width="400px">
														<asp:ListItem Value="Saved Data">Saved Data</asp:ListItem>
														<asp:ListItem Value="Score">Score</asp:ListItem>
														<asp:ListItem Value="InspParams">Insp Params</asp:ListItem>
														<asp:ListItem Value="Sieve Analysis">Sieve Analysis</asp:ListItem>--%>
													</asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
													<asp:button id="btnSave" runat="server" CssClass="button button2" Text="Save"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
													<asp:Button id="btnClear" runat="server" CssClass="button button2" Text="Clear"></asp:Button></TD>
											
									
									<%--	<asp:CheckBox id="chkRefreshGrid" runat="server" AutoPostBack="True" Text="Refresh Grid below" Font-Bold="True"></asp:CheckBox>--%>
									</asp:panel>
                      </div>
						<asp:datagrid id="dgInspParams" runat="server" CssClass="table" Height="108px" BackColor="White" Width="675px" BorderWidth="1px" Visible="False" BorderStyle="None" BorderColor="#E7E7FF" CellPadding="3" GridLines="Horizontal"  >
							<SelectedItemStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#738A9C"></SelectedItemStyle>
							<AlternatingItemStyle BackColor="#F7F7F7"></AlternatingItemStyle>
							<ItemStyle ForeColor="#4A3C8C" BackColor="#E7E7FF"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#4A3C8C"></HeaderStyle>
							<FooterStyle ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
							<PagerStyle HorizontalAlign="Right" ForeColor="#4A3C8C" BackColor="#E7E7FF" Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
              
                    
                <asp:datagrid id="dgData" runat="server" CssClass="table" Height="93px" BackColor="LightGoldenrodYellow" Width="671px" BorderWidth="1px" ForeColor="Black" BorderColor="Tan" CellPadding="1" GridLines="None">
							<SelectedItemStyle ForeColor="GhostWhite" BackColor="DarkSlateBlue"></SelectedItemStyle>
							<AlternatingItemStyle BackColor="PaleGoldenrod"></AlternatingItemStyle>
							<HeaderStyle Font-Bold="True" BackColor="Tan"></HeaderStyle>
							<FooterStyle BackColor="Tan"></FooterStyle>
							<PagerStyle HorizontalAlign="Center" ForeColor="DarkSlateBlue" BackColor="PaleGoldenrod"></PagerStyle>
						</asp:datagrid>
				</div></div>
        </form></div>
        <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</html>
