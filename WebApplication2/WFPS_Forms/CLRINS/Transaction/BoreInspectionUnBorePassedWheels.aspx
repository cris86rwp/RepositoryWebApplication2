<%@ Page Language="vb" AutoEventWireup="false" Codebehind="BoreInspectionUnBorePassedWheels.aspx.vb" Inherits="WebApplication2.BoreInspectionUnBorePassedWheels" %>
<!DOCTYPE HTML >
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>BoreInspectionUnBorePassedWheels</title>
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
       
       <%-- <link rel="stylesheet" href="StyleSheet1.css" />--%>
 
	</head>
	<body>
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
             <div class="row">
                 <div class="table-responsive">
		<form id="Form1" method="post" runat="server">
            
                 <%-- <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
      
			<asp:panel id="Panel1" runat="server">
               <table id="Table6" class="table">
								<TR>
									<TD><h2>Bore Inspection of UnBore Passed Wheels</h2><hr class="prettyline" /></TD>
								</TR>
							</table>
                <asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label>
							<table id="Table7" class="table">
								<TR>
									<TD>Date:</TD>
									<TD>
										<asp:textbox id="txtDate" tabIndex="1" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox></TD>
									<TD>Shift</TD>
									<TD>
										<asp:RadioButtonList id="rblShift" runat="server" CssClass="rbl" AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal">
											<asp:ListItem Value="A">A</asp:ListItem>
											<asp:ListItem Value="B">B</asp:ListItem>
											<asp:ListItem Value="C">C</asp:ListItem>
											<asp:ListItem Value="G" Selected="True">G</asp:ListItem>
										</asp:RadioButtonList></TD>
									<TD>Inspector</TD>
									<TD>
										<asp:textbox id="txtInspector" tabIndex="-1" runat="server" CssClass="form-control" placeholder="Enter inspector"></asp:textbox></TD>
								</TR>
							</table>
                <table id="Table2" class="table">
								<TR>
									<TD>Wheel(Alt+W)</TD>
									<TD>
										<asp:textbox id="txtWheelNumber" accessKey="W" tabIndex="3" runat="server" CssClass="form-control"  AutoPostBack="True"></asp:textbox></TD>
									<TD>HeatNo</TD>
									<TD>
										<asp:textbox id="txtHeatNumber" tabIndex="4" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox></TD>
								</TR>
							</table>
				
							
							
							<table id="Table3" class="table">
								<TR>
									<TD colSpan="3">Last Bore Inspection&nbsp; Details :</TD>
								</TR>
								<TR>
									<TD colSpan="3">
										<asp:DataGrid id="dgLastInsp" runat="server" BackColor="White" BorderColor="#3366CC">
											<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
											<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
											<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
											<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
											<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
										</asp:DataGrid></TD>
								</TR>
								<TR>
									<TD colSpan="3"><U>Input if Change in Bore Status or Bore Dia&nbsp; only</U></TD>
								</TR>
								<TR>
									<TD>BoreSts</TD>
									<TD>
										<asp:checkbox id="chkBoreWheel" tabIndex="5" runat="server" Text="UnBore" CssClass="form-control"></asp:checkbox></TD>
									<TD>BoreDia:</TD>
										<TD><asp:textbox id="txtBoreDia" tabIndex="6" runat="server" CssClass="form-control"  AutoPostBack="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD colSpan="3">
										<asp:CheckBox id="chkHelp" runat="server" AutoPostBack="True" Text="Help" Checked="True"></asp:CheckBox></TD>
								</TR>
								<TR>
									<TD colSpan="3">
										<asp:Panel id="pnlHelp" runat="server">
											<P><FONT size="4"><U><EM>
															<table id="Table5" class="table">
																<TR>
																	<TD><EM><U><FONT size="4">Note: Bore Dia is updated only if it is entered as value &gt; 0</FONT></U></EM></TD>
																</TR>
																<TR>
																	<TD><EM><U><FONT size="4">This will not change date of passing of the wheel.</FONT></U></EM></TD>
																</TR>
																<TR>
																	<TD><EM><U><FONT size="4">Bore Inspection is updated for the same day, shift </FONT></U>
																		</EM>
																	</TD>
																</TR>
																<TR>
																	<TD>
																		<P><EM><U><FONT size="4">and wheel else inserted into database.</FONT></U></EM></P>
																	</TD>
																</TR>
															</table>
														</EM></U></FONT>
											</P>
										</asp:Panel>
								
								<TR>
									<TD>Remarks</TD>
									<TD colSpan="2">
										<asp:textbox id="txtRemarks" tabIndex="7" runat="server" CssClass="form-control" MaxLength="30"></asp:textbox></TD>
								</TR>
								<TR>
									<TD align="middle" colSpan="2">
										<asp:button id="btnSave" tabIndex="-1" runat="server" CssClass="button button2" Text="Save"></asp:button></TD>
									<TD>
										<asp:button id="btnClear" tabIndex="-1" runat="server" CssClass="button button2" Text="Clear"></asp:button></TD>
								</TR>
								<TR>
									<TD colSpan="3">Score :</TD>
                                    <td><asp:DataGrid id="dgScore" runat="server"  BackColor="White" BorderColor="#CC9966">
								<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
								<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
								<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
								<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
							</asp:DataGrid></td>
								</TR>
							</table>
              
							
							
							<asp:datagrid id="dgWheels" runat="server" BackColor="White" BorderColor="#999999" GridLines="Vertical">
								<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
								<AlternatingItemStyle BackColor="#DCDCDC"></AlternatingItemStyle>
								<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
								<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
								<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
						<TD vAlign="top" align="left">
							<%--<asp:Panel id="pnlHistory" runat="server" BackColor="#FFFFC0">
								<table id="Table4" class="table" border="1">
									<TR>
										<TD>Master History of Wheel:</TD>
									</TR>
									<TR>
										<TD>
											<asp:DataGrid id="dgMasterHistory" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
												<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
												<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
												<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
												<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
												<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
												<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
											</asp:DataGrid></TD>
									</TR>
									<TR>
										<TD>Magna History:</TD>
									</TR>
									<TR>
										<TD>
											<asp:DataGrid id="dgMagHistory" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
												<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
												<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
												<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
												<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
												<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
												<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
											</asp:DataGrid></TD>
									</TR>
									<TR>
										<TD>Final Insp History:</TD>
									</TR>
									<TR>
										<TD>
											<asp:DataGrid id="dgFIHistory" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
												<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
												<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
												<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
												<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
												<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
												<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
											</asp:DataGrid></TD>
									</TR>
									<TR>
										<TD>Yard History:</TD>
									</TR>
									<TR>
										<TD>
											<asp:DataGrid id="dgYIHistory" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
												<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
												<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
												<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
												<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
												<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
												<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
											</asp:DataGrid></TD>
									</TR>
									<TR>
										<TD>QC Insp History:</TD>
									</TR>
									<TR>
										<TD>
											<asp:DataGrid id="dgQChistory" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
												<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
												<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
												<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
												<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
												<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
												<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
											</asp:DataGrid></TD>
									</TR>
									<TR>
										<TD>Wheel Load History:</TD>
									</TR>
									<TR>
										<TD>
											<asp:DataGrid id="dgWhlLoadHistory" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
												<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
												<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
												<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
												<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
												<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
												<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
											</asp:DataGrid></TD>
									</TR>
									<TR>
										<TD>Axle Assembly History:</TD>
									</TR>
									<TR>
										<TD>
											<asp:DataGrid id="dgPressHistory" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
												<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
												<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
												<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
												<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
												<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
												<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
											</asp:DataGrid></TD>
									</TR>
									<TR>
										<TD>Despatch History:</TD>
									</TR>
									<TR>
										<TD>
											<asp:DataGrid id="dgDespHistory" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
												<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
												<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
												<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
												<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
												<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
												<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
											</asp:DataGrid></TD>
									</TR>
							--%>	<%--</table>
							</asp:Panel></TD>--%>
					</TR>
				</table>
           
			</asp:panel>
            <asp:Panel id="pnlHistory" runat="server">
								<table id="Table4" class="table">
									<TR>
										<TD>Master History of Wheel:</TD>
									</TR>
									<TR>
										<TD>
											<asp:DataGrid id="dgMasterHistory" runat="server" BackColor="White" BorderColor="#999999"  GridLines="Vertical">
												<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
												<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
												<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
												<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
												<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
												<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
											</asp:DataGrid></TD>
									</TR>
									<TR>
										<TD>Magna History:</TD>
									</TR>
									<TR>
										<TD>
											<asp:DataGrid id="dgMagHistory" runat="server" BackColor="White" BorderColor="#999999" GridLines="Vertical">
												<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
												<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
												<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
												<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
												<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
												<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
											</asp:DataGrid></TD>
									</TR>
									<TR>
										<TD>Final Insp History:</TD>
									</TR>
									<TR>
										<TD>
											<asp:DataGrid id="dgFIHistory" runat="server" BackColor="White" BorderColor="#999999" GridLines="Vertical">
												<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
												<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
												<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
												<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
												<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
												<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
											</asp:DataGrid></TD>
									</TR>
									<TR>
										<TD>Yard History:</TD>
									</TR>
									<TR>
										<TD>
											<asp:DataGrid id="dgYIHistory" runat="server" BackColor="White" BorderColor="#999999" GridLines="Vertical">
												<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
												<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
												<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
												<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
												<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
												<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
											</asp:DataGrid></TD>
									</TR>
									<TR>
										<TD>QC Insp History:</TD>
									</TR>
									<TR>
										<TD>
											<asp:DataGrid id="dgQChistory" runat="server" BackColor="White" BorderColor="#999999" GridLines="Vertical">
												<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
												<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
												<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
												<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
												<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
												<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
											</asp:DataGrid></TD>
									</TR>
									<TR>
										<TD>Wheel Load History:</TD>
									</TR>
									<TR>
										<TD>
											<asp:DataGrid id="dgWhlLoadHistory" runat="server" BackColor="White" BorderColor="#999999" GridLines="Vertical">
												<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
												<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
												<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
												<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
												<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
												<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
											</asp:DataGrid></TD>
									</TR>
									<TR>
										<TD>Axle Assembly History:</TD>
									</TR>
									<TR>
										<TD>
											<asp:DataGrid id="dgPressHistory" runat="server" BackColor="White" BorderColor="#999999" GridLines="Vertical">
												<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
												<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
												<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
												<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
												<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
												<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
											</asp:DataGrid></TD>
									</TR>
									<TR>
										<TD>Despatch History:</TD>
									</TR>
									<TR>
										<TD>
											<asp:DataGrid id="dgDespHistory" runat="server" BackColor="White" BorderColor="#999999" GridLines="Vertical">
												<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
												<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
												<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
												<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
												<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
												<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
											</asp:DataGrid></TD>
									</TR>
							</table>
				</asp:Panel>
        </form>
        </div></div></div>
        <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</html>
