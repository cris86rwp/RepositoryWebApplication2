<%@ Page Language="vb" AutoEventWireup="false" Codebehind="StockIDNItemList.aspx.vb" Inherits="WebApplication2.StockIDNItemList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>StockIDNItemList</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body bgColor="#ffcc99">
		<form id="Form1" method="post" runat="server">
			<asp:Panel id="Panel1" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 7px" runat="server" BackColor="#FFC0C0" Height="415px">
				<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="300" border="0">
					<TR>
						<TD>
							<TABLE id="Table1" style="WIDTH: 529px; HEIGHT: 186px" cellSpacing="1" cellPadding="1" width="529" border="0">
								<TR>
									<TD colSpan="6"><FONT size="5">
											<asp:Label id="lblConsignee" runat="server"></asp:Label>&nbsp;- Status of IDNs 
											of Stock items ( ADD)</FONT></TD>
								</TR>
								<TR>
									<TD>Message</TD>
									<TD>:</TD>
									<TD colSpan="4">
										<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></TD>
								</TR>
								<TR>
									<TD>IDN Number</TD>
									<TD>:</TD>
									<TD>
										<asp:TextBox id="txtIDNNumber" runat="server" AutoPostBack="True" Width="102px"></asp:TextBox></TD>
									<TD>IDN Date</TD>
									<TD>:</TD>
									<TD>
										<asp:Label id="lblIDNDate" runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD>IDN Qty</TD>
									<TD>:</TD>
									<TD>
										<asp:Label id="lblIDNQty" runat="server"></asp:Label></TD>
									<TD>
										<asp:Label id="lblPLUnit" runat="server"></asp:Label></TD>
									<TD></TD>
									<TD></TD>
								</TR>
								<TR>
									<TD>PL Number</TD>
									<TD>:</TD>
									<TD>
										<asp:Label id="lblPLNumber" runat="server"></asp:Label></TD>
									<TD>&nbsp;
										<asp:Label id="lblSupplierCode" runat="server" Visible="False"></asp:Label></TD>
									<TD>&nbsp;</TD>
									<TD>&nbsp;</TD>
								</TR>
								<TR>
									<TD>PL Desc</TD>
									<TD>:</TD>
									<TD colSpan="4">
										<asp:Label id="lblPLDesc" runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD>PO Number</TD>
									<TD>:</TD>
									<TD>
										<asp:Label id="lblPONumber" runat="server"></asp:Label></TD>
									<TD>PO Date</TD>
									<TD>:&nbsp;</TD>
									<TD>
										<asp:Label id="lblPODate" runat="server"></asp:Label>&nbsp;</TD>
								</TR>
								<TR>
									<TD>PO Qty</TD>
									<TD>:</TD>
									<TD>
										<asp:Label id="lblPOQty" runat="server"></asp:Label></TD>
									<TD>Dump No</TD>
									<TD>:</TD>
									<TD>
										<asp:Label id="lblDumpNo" runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD>Supplier</TD>
									<TD>:</TD>
									<TD colSpan="4">
										<asp:Label id="lblPOSupplier" runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD>Received date</TD>
									<TD>:</TD>
									<TD>
										<asp:TextBox id="txtReceivedDate" runat="server" AutoPostBack="True" Width="116px"></asp:TextBox></TD>
									<TD>Cleared Date</TD>
									<TD>:</TD>
									<TD>
										<asp:TextBox id="txtClearedDate" runat="server" AutoPostBack="True" Width="118px"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD>Remarks</TD>
									<TD>:</TD>
									<TD colSpan="4">
										<asp:TextBox id="txtRemarks" runat="server" Width="302px"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD vAlign="top" align="middle" colSpan="6">
										<asp:Button id="btnSave" runat="server" Text="Save"></asp:Button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD>
							<asp:DataGrid id="dgStockIDN" runat="server" BackColor="White" CellPadding="4" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966">
								<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
								<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
								<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
								<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
							</asp:DataGrid></TD>
					</TR>
				</TABLE>
			</asp:Panel>
		</form>
	</body>
</HTML>
