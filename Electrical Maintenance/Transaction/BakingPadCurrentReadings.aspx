<%@ Page Language="vb" AutoEventWireup="false" Codebehind="BakingPadCurrentReadings.aspx.vb" Inherits="WebApplication2.BakingPadCurrentReadings" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>BakingPadCurrentReadings</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout" bgColor="#99cc99">
		<form id="Form1" method="post" runat="server">
			<asp:Panel id="Panel1" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server">
				<TABLE id="Table1" style="WIDTH: 418px; HEIGHT: 63px" cellSpacing="1" cellPadding="1" width="418" border="1">
					<TR>
						<TD colSpan="6"><FONT size="5">Baking Pad Current Readings</FONT> (&nbsp;ampere )</TD>
					</TR>
					<TR>
						<TD colSpan="6">
							<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></TD>
					</TR>
					<TR>
						<TD>Date</TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="txtDate" runat="server" AutoPostBack="True" Width="87px"></asp:TextBox></TD>
						<TD>Shift</TD>
						<TD>:</TD>
						<TD>
							<asp:RadioButtonList id="rblShift" runat="server" AutoPostBack="True" Width="38px" RepeatDirection="Horizontal" RepeatLayout="Flow">
								<asp:ListItem Value="A" Selected="True">A</asp:ListItem>
							</asp:RadioButtonList></TD>
					</TR>
					<TR>
						<TD>of C5IE</TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="C5IE" runat="server" Width="86px"></asp:TextBox></TD>
						<TD>of C5IW</TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="C5IW" runat="server" Width="116px"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>of C5KE</TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="C5KE" runat="server" Width="86px"></asp:TextBox></TD>
						<TD>of C5KW</TD>
						<TD></TD>
						<TD>
							<asp:TextBox id="C5KW" runat="server" Width="116px"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="middle" colSpan="6">
							<asp:Button id="btnSave" runat="server" Text="Save"></asp:Button></TD>
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
