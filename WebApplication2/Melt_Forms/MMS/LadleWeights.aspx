<%@ Page Language="vb" AutoEventWireup="false" Codebehind="LadleWeights.aspx.vb" Inherits="ProductionMelting.LadleWeights" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>LadleWeights</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body bgColor="#99ccff" >
		<form id="Form1" method="post" runat="server">
			<asp:panel id="Panel1" style="Z-INDEX: 103; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server" Width="361px">
				<TABLE id="Table1" style="WIDTH: 376px; HEIGHT: 52px" cellSpacing="1" cellPadding="1" width="376" border="1">
					<TR>
						<TD colSpan="3">Ladle Weight Entry -
							<asp:Label id="lblGroupName" runat="server"></asp:Label>
							<asp:Label id="lblGoup" runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD colSpan="3">
							<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></TD>
					</TR>
					<TR>
						<TD>HeatNumber</TD>
						<TD>:</TD>
						<TD>
							<asp:textbox id="txtHeat_number" runat="server" Width="70px" AutoPostBack="True"></asp:textbox>
							<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtHeat_number" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator></TD>
					</TR>
				</TABLE>
				<asp:Panel id="pnlMould" runat="server">
					<TABLE id="Table2" style="WIDTH: 443px; HEIGHT: 56px" cellSpacing="1" cellPadding="1" width="443" border="1">
						<TR>
							<TD>Weight of Ladle&nbsp;after Pouring (W3)</TD>
							<TD>:</TD>
							<TD>
								<asp:textbox id="txtw3" runat="server" Width="65px"></asp:textbox></TD>
						</TR>
						<TR>
							<TD>Weight W1&nbsp;:&nbsp;
								<asp:Label id="lblw1" runat="server"></asp:Label></TD>
							<TD colSpan="2">Weight W2&nbsp;:&nbsp;
								<asp:Label id="lblw2" runat="server"></asp:Label></TD>
						</TR>
					</TABLE>
				</asp:Panel>
				<asp:Panel id="pnlMelt" runat="server">
					<TABLE id="Table3" style="WIDTH: 447px; HEIGHT: 61px" cellSpacing="1" cellPadding="1" width="447" border="1">
						<TR>
							<TD>Weight of Empty Ladle (W1) (New)</TD>
							<TD>:</TD>
							<TD>
								<asp:textbox id="txtw1" runat="server" Width="88px"></asp:textbox></TD>
						</TR>
						<TR>
							<TD>Weight After Tapping (W2)</TD>
							<TD>:</TD>
							<TD>
								<asp:textbox id="txtw2" runat="server" Width="88px"></asp:textbox></TD>
						</TR>
					</TABLE>
				</asp:Panel>
				<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="300" border="1">
					<TR>
						<TD align="center">
							<asp:button id="btnSave" runat="server" Width="71px" Text="Save" Height="24px" BorderStyle="Groove"></asp:button></TD>
					</TR>
				</TABLE>
			</asp:panel></form>
	</body>
</HTML>
