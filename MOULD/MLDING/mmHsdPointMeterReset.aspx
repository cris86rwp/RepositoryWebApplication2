<%@ Page Language="vb" AutoEventWireup="false" Codebehind="mmHsdPointMeterReset.aspx.vb" Inherits="WebApplication2.mmHsdPointMeterReset" Culture="en-GB" uiCulture="en-GB" smartNavigation="True" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>mmHsdPoint</title>
		<LINK href="/wap/MailStyles.css" rel="stylesheet">
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="403" border="1">
				<TR>
					<TD align="center" colSpan="2"><STRONG><FONT color="#0000cc" size="4"><asp:label id="lblHeader" runat="server"></asp:label></FONT></STRONG></TD>
				</TR>
				<TR>
					<TD>Message</TD>
					<TD><asp:label id="lblMessage" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:label></TD>
				</TR>
				<TR>
					<TD><asp:checkbox id="chkHelp" tabIndex="-1" runat="server" AutoPostBack="True" Text="Help"></asp:checkbox></TD>
					<TD><asp:label id="lblHelp" runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD>Logged In By</TD>
					<TD><asp:label id="lblLogInEmpCode" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD>LPG &amp; BMCG Point</TD>
					<TD><asp:dropdownlist id="ddlHsdPoints" tabIndex="1" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" colSpan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:button id="btnReset" tabIndex="15" runat="server" Width="241px"></asp:button></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
