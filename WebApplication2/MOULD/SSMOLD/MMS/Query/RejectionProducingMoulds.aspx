<%@ Page Language="vb" AutoEventWireup="false" Codebehind="RejectionProducingMoulds.aspx.vb" Inherits="WebApplication2.RejectionProducingMoulds" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>RejectionProducingMoulds</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body bgColor="#99ccff">
		<form id="Form1" method="post" runat="server">
			<asp:Panel id="Panel1" style="Z-INDEX: 102; LEFT: 2px; POSITION: absolute; TOP: 4px" runat="server">
				<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label>
				<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="300" border="1">
					<TR>
						<TD vAlign="top" align="left" colSpan="3">
							<TABLE id="Table5" style="WIDTH: 275px; HEIGHT: 32px" cellSpacing="1" cellPadding="1" width="275" border="1">
								<TR>
									<TD>FromDate</TD>
									<TD>
										<asp:TextBox id="txtFromDate" runat="server" Width="73px" AutoPostBack="True"></asp:TextBox></TD>
									<TD>ToDate</TD>
									<TD>
										<asp:TextBox id="txtToDate" runat="server" Width="74px"></asp:TextBox></TD>
								</TR>
							</TABLE>
							<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="300" border="1">
								<TR>
									<TD>
										<asp:RadioButtonList id="rblQry" runat="server" RepeatLayout="Flow" Width="493px">
											<asp:ListItem Value="1" Selected="True">Cope Performance based on Introduced Date</asp:ListItem>
											<asp:ListItem Value="2">Tapped Heats </asp:ListItem>
											<asp:ListItem Value="3">Pouring Tube Data</asp:ListItem>
											<asp:ListItem Value="4">Magna Off Loads</asp:ListItem>
											<asp:ListItem Value="5">ChangeToMRXC ( ReWork Wheels ) based on Posted Date</asp:ListItem>
											<asp:ListItem Value="6">PostedByMagna ( Direct Rejection ) based on Tapped Date</asp:ListItem>
											<asp:ListItem Value="7">Punched Wheels</asp:ListItem>
											<asp:ListItem Value="8">Yet To Punch Wheels</asp:ListItem>
											<asp:ListItem Value="9">Magna Process</asp:ListItem>
											<asp:ListItem Value="10">Old Heats FI Passed</asp:ListItem>
											<asp:ListItem Value="11">MR OffLoad Position</asp:ListItem>
											<asp:ListItem Value="12">Production Performance Details</asp:ListItem>
											<asp:ListItem Value="13">Production Performance XC Details</asp:ListItem>
											<asp:ListItem Value="14">MRXC based on Posted Date</asp:ListItem>
											<asp:ListItem Value="15">Mould performance data</asp:ListItem>
											<asp:ListItem Value="16">Production Performance as per Norms</asp:ListItem>
										</asp:RadioButtonList></TD>
								</TR>
							</TABLE>
						</TD>
						<TD vAlign="top" align="left">
							<asp:RadioButtonList id="rblMould" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" Width="414px" BackColor="#C0FFFF">
								<asp:ListItem Value="C" Selected="True">Rejection Producing Cope</asp:ListItem>
								<asp:ListItem Value="D">Rejection Producing Drag</asp:ListItem>
							</asp:RadioButtonList>
							<asp:RadioButtonList id="rblWhlType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" Width="376px" BackColor="#FFE0C0"></asp:RadioButtonList>
							<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="300" border="1">
								<TR>
									<TD vAlign="top" align="center">
										<asp:Button id="Button1" runat="server" Text="Show Results"></asp:Button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD vAlign="top" align="left" colSpan="3">
							<asp:Button id="Button3" runat="server" Text="Show Details in Grid"></asp:Button></TD>
						<TD vAlign="top" align="left">
							<asp:button id="btnExportDetails" runat="server" Text="Export Details"></asp:button></TD>
					</TR>
				</TABLE>
				<asp:DataGrid id="DataGrid1" runat="server" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4">
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
