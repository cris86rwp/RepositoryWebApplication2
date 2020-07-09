<%@ Page Language="vb" AutoEventWireup="false" Codebehind="DailyVoltageCurrentDelete.aspx.vb" Inherits="WebApplication2.DailyVoltageCurrentDelete" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>DailyVoltageCurrentDelete</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body bgColor="#99ccff" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:panel id="Panel1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server">
				<TABLE id="Table1" style="WIDTH: 519px; HEIGHT: 81px" cellSpacing="1" cellPadding="1" width="519" border="1" DESIGNTIMEDRAGDROP="12">
					<TR>
						<TD colSpan="3">DAILY VOLTAGE&nbsp; CURRENT &nbsp;STATISTICS ( Delete )</TD>
					</TR>
					<TR>
						<TD colSpan="3">
							<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></TD>
					</TR>
					<TR>
						<TD>Latest Consumption Date for which data will be deleted</TD>
						<TD>:</TD>
						<TD>
							<asp:Label id="lblDate" runat="server" ForeColor="Red"></asp:Label></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="middle" colSpan="3">
							<asp:Button id="Button1" runat="server" Text="Delete data"></asp:Button></TD>
					</TR>
				</TABLE>
				<asp:DataGrid id="DataGrid1" runat="server" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
			</asp:panel></form>
	</body>
</HTML>
