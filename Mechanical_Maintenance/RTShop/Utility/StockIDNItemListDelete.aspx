<%@ Page Language="vb" AutoEventWireup="false" Codebehind="StockIDNItemListDelete.aspx.vb" Inherits="WebApplication2.StockIDNItemListDelete" smartNavigation="True" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>StockIDNItemListDelete</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout" bgColor="#ff9999">
		<form id="Form1" method="post" runat="server">
			<asp:Panel id="Panel1" style="Z-INDEX: 101; LEFT: 1px; POSITION: absolute; TOP: 0px" runat="server" BackColor="#FFE0C0" Width="11px">
				<TABLE id="Table1" style="WIDTH: 554px; HEIGHT: 181px" cellSpacing="1" cellPadding="1" width="554" border="0">
					<TR>
						<TD colSpan="6"><FONT size="5">
								<asp:Label id="lblConsignee" runat="server"></asp:Label>&nbsp;- Status of IDNs 
								of Stock items ( Delete )</FONT></TD>
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
							<asp:DropDownList id="ddlIDNNumber" runat="server" AutoPostBack="True"></asp:DropDownList></TD>
						<TD>IDN Date</TD>
						<TD>:</TD>
						<TD>
							<asp:Label id="lblIDNDate" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD>PL Number</TD>
						<TD>:</TD>
						<TD>
							<asp:Label id="lblPLNumber" runat="server"></asp:Label></TD>
						<TD>&nbsp;</TD>
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
						<TD>&nbsp;
							<asp:Label id="lblSupplierCode" runat="server" Visible="False"></asp:Label></TD>
						<TD>&nbsp;</TD>
						<TD>&nbsp;</TD>
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
							<asp:TextBox id="txtReceivedDate" runat="server" Width="86px" AutoPostBack="True"></asp:TextBox></TD>
						<TD>Cleared Date</TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="txtClearedDate" runat="server" Width="83px" AutoPostBack="True"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>Remarks</TD>
						<TD>:</TD>
						<TD colSpan="4">
							<asp:TextBox id="txtRemarks" runat="server" Width="302px"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="middle" colSpan="6">
							<asp:Button id="btnSave" runat="server" Text="Delete"></asp:Button>
							<asp:Label id="lblIDNid" runat="server"></asp:Label></TD>
					</TR>
				</TABLE>
				<asp:DataGrid id="dgStockIDN" runat="server"></asp:DataGrid>
			</asp:Panel>
		</form>
	</body>
</HTML>
