<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ProdConsumableDetails.aspx.vb" Inherits="WebApplication2.ProdConsumableDetails" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>ProdConsumableDetails</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<LINK href="wap.css" rel="stylesheet">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body bgColor="#99ccff">
		<form id="Form1" method="post" runat="server">
			<asp:panel id="Panel2" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server">
				<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="300" border="1" DESIGNTIMEDRAGDROP="52">
					<TR>
						<TD vAlign="top" align="left">
							<asp:panel id="Panel1" runat="server" Width="205px" Height="40px">
								<TABLE id="Table1" style="WIDTH: 335px; HEIGHT: 34px" cellSpacing="1" cellPadding="1" width="335" border="1">
									<TR>
										<TD>
											<asp:label id="lblConsignee" runat="server" Font-Bold="True"></asp:label>&nbsp;<STRONG>Production 
												Consumables Details</STRONG></TD>
									</TR>
									<TR>
										<TD>
											<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></TD>
									</TR>
									<TR>
										<TD>
											<asp:RadioButtonList id="rblType" runat="server" AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal"></asp:RadioButtonList></TD>
									</TR>
								</TABLE>
								<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="300" border="1">
									<TR>
										<TD>
											<asp:Label id="lblType" runat="server"></asp:Label>Date</TD>
										<TD>:</TD>
										<TD>
											<asp:TextBox id="txtTransDate" runat="server" Width="104px" AutoPostBack="True"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD>
											<asp:Label id="lblType1" runat="server"></asp:Label>Number</TD>
										<TD>:</TD>
										<TD>
											<asp:TextBox id="txtNumber" runat="server" AutoPostBack="True"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD>DrawnQty</TD>
										<TD>:</TD>
										<TD>
											<asp:TextBox id="txtQty" runat="server" Width="63px"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD colSpan="3">
											<asp:Panel id="pnlNonPl" runat="server">
												<TABLE id="Table5" cellSpacing="1" cellPadding="1" width="300" border="1">
													<TR>
														<TD>Supplier</TD>
														<TD>:</TD>
														<TD>
															<asp:TextBox id="txtSupplier" runat="server"></asp:TextBox></TD>
													</TR>
												</TABLE>
											</asp:Panel>
											<asp:Panel id="pnlPl" runat="server">
												<TABLE id="Table6" cellSpacing="1" cellPadding="1" width="300" border="1">
													<TR>
														<TD colSpan="3">
															<asp:RadioButtonList id="rblPL" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"></asp:RadioButtonList></TD>
													</TR>
												</TABLE>
											</asp:Panel></TD>
									</TR>
									<TR>
										<TD>Remarks</TD>
										<TD>:</TD>
										<TD>
											<asp:TextBox id="txtRemarks" runat="server"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD align="center" colSpan="3">
											<asp:Button id="btnSave" runat="server" Text="Save"></asp:Button>
											<asp:Label id="lblTransID" runat="server"></asp:Label></TD>
									</TR>
								</TABLE>
							</asp:panel></TD>
						<TD vAlign="top" align="left">
							<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="300" border="1">
								<TR>
									<TD>
										<asp:Label id="lblType2" runat="server"></asp:Label>&nbsp; Details :</TD>
								</TR>
								<TR>
									<TD>
										<asp:DataGrid id="DataGrid1" runat="server" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4">
											<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
											<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
											<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
											<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
											<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
										</asp:DataGrid></TD>
								</TR>
								<TR>
									<TD>Drawal&nbsp;Details for the number&nbsp;:</TD>
								</TR>
								<TR>
									<TD>
										<asp:DataGrid id="DataGrid2" runat="server" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4">
											<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
											<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
											<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
											<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
											<Columns>
												<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
											</Columns>
											<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
										</asp:DataGrid></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD vAlign="top" align="left" colSpan="2">Drawal&nbsp;Details for PL :
							<asp:Label id="lblPLNo" runat="server"></asp:Label>&nbsp; for the month :
							<asp:Label id="lblQty" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="left" colSpan="2">
							<asp:DataGrid id="DataGrid3" runat="server" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" BackColor="#DEBA84" CellPadding="3" CellSpacing="2">
								<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#738A9C"></SelectedItemStyle>
								<ItemStyle ForeColor="#8C4510" BackColor="#FFF7E7"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#A55129"></HeaderStyle>
								<FooterStyle ForeColor="#8C4510" BackColor="#F7DFB5"></FooterStyle>
								<PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="left" colSpan="2">Drawal&nbsp;Details for the Day :</TD>
					</TR>
				</TABLE>
				<asp:DataGrid id="DataGrid4" runat="server" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" BackColor="White" CellPadding="4" GridLines="Horizontal">
					<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#339966"></SelectedItemStyle>
					<ItemStyle ForeColor="#333333" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#336666"></HeaderStyle>
					<FooterStyle ForeColor="#333333" BackColor="White"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="White" BackColor="#336666" Mode="NumericPages"></PagerStyle>
				</asp:DataGrid>
			</asp:panel></form>
	</body>
</HTML>
