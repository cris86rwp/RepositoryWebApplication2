<%@ Page Language="vb" AutoEventWireup="false" Codebehind="NewMachineSparesDelete.aspx.vb" Inherits="WebApplication2.NewMachineSparesDelete" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>NewMachineSparesDelete</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout" bgColor="#cccc00">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="1" cellPadding="1" width="300" border="1">
				<TR>
					<TD colSpan="3"><FONT size="5">Machine Spares - delete
							<asp:label id="lblUserID" runat="server" Visible="False"></asp:label><asp:label id="lblGrp" runat="server" Visible="False"></asp:label></FONT></TD>
				</TR>
				<TR>
					<TD colSpan="3"><asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="3"><asp:radiobuttonlist id="rdoTypeOfGroup" runat="server" RepeatLayout="Flow" Width="225px" AutoPostBack="True" RepeatDirection="Horizontal">
							<asp:ListItem Value="MachinePLs" Selected="True">MachinePLs</asp:ListItem>
							<asp:ListItem Value="SubAssemblyPLs">SubAssemblyPLs</asp:ListItem>
						</asp:radiobuttonlist></TD>
				</TR>
				<TR>
					<TD>Machine</TD>
					<TD>:</TD>
					<TD><asp:panel id="pnlSubAssemlies" runat="server">
							<asp:DropDownList id="ddlSubAssemlies" runat="server" AutoPostBack="True"></asp:DropDownList>
						</asp:panel><asp:panel id="pnlMachine" runat="server">
							<asp:DropDownList id="ddlMachines" runat="server" AutoPostBack="True"></asp:DropDownList>
						</asp:panel></TD>
				</TR>
				<TR>
					<TD>
						PLNumber</TD>
					<TD>:</TD>
					<TD><asp:dropdownlist id="ddlPLNumber" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD>Qty</TD>
					<TD>:</TD>
					<TD><asp:textbox id="txtQty" runat="server" Width="73px"></asp:textbox>
						<asp:Label id="lblUnit" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<TD>Purpose</TD>
					<TD>:</TD>
					<TD><asp:textbox id="txtPurpose" runat="server" Width="207px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD vAlign="top" noWrap align="middle" colSpan="3" rowSpan="1"><asp:button id="btnSave" runat="server" Text="Delete"></asp:button></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
