<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ConsumablesStockingDetailsReport.aspx.vb" Inherits="WebApplication2.ConsumablesStockingDetailsReport" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>ConsumablesStockingDetailsReport</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body bgColor="#99cccc">
		<form id="Form1" method="post" runat="server">
			<asp:Panel id="Panel1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 7px" runat="server">
				<TABLE id="Table3" style="WIDTH: 598px; HEIGHT: 26px" cellSpacing="1" cellPadding="1" width="598" border="1">
					<TR>
						<TD><FONT size="5">
								<asp:Label id="lblConsignee" runat="server"></asp:Label>Consumable&nbsp;Amendments 
								Details&nbsp;&nbsp;</FONT>&nbsp;</TD>
					</TR>
					<TR>
						<TD>
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></TD>
					</TR>
				</TABLE>
				<TABLE id="Table2" style="WIDTH: 237px; HEIGHT: 30px" cellSpacing="1" cellPadding="1" width="237" border="1">
					<TR>
						<TD>PL Number</TD>
						<TD>:</TD>
						<TD>
							<asp:DropDownList id="ddlPLNumber" runat="server" AutoPostBack="True"></asp:DropDownList></TD>
					</TR>
				</TABLE>
				<asp:DataGrid id="DataGrid1" runat="server" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
			</asp:Panel>
		</form>
	</body>
</HTML>
