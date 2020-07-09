<%@ Page Language="vb" AutoEventWireup="false" Codebehind="StockIDNStatusListDetails.aspx.vb" Inherits="WebApplication2.StockIDNStatusListDetails" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>StockIDNStatusListDetails</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body bgColor="#99ccff" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:panel id="Panel1" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server">
				<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="300" border="1">
					<TR>
						<TD>Stock IDN Status Details</TD>
					</TR>
					<TR>
						<TD>
							<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></TD>
					</TR>
				</TABLE>
				<TABLE id="Table2" style="WIDTH: 987px; HEIGHT: 85px" cellSpacing="1" cellPadding="1" width="987" bgColor="#ffccff" border="1">
					<TR>
						<TD style="WIDTH: 206px; HEIGHT: 3px">Received From&nbsp;Date</TD>
						<TD style="WIDTH: 1px; HEIGHT: 3px">:</TD>
						<TD style="WIDTH: 87px; HEIGHT: 3px">
							<asp:textbox id="txtFromDate" runat="server" Width="79px" AutoPostBack="True"></asp:textbox></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 206px; HEIGHT: 5px">Received To&nbsp;Date</TD>
						<TD style="WIDTH: 1px; HEIGHT: 5px">:</TD>
						<TD style="WIDTH: 87px; HEIGHT: 5px">
							<asp:textbox id="txtToDate" runat="server" Width="79px" AutoPostBack="True"></asp:textbox></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 206px; HEIGHT: 3px">IDN
							<asp:RadioButtonList id="rblType" runat="server" AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal">
								<asp:ListItem Value="1" Selected="True">PO </asp:ListItem>
								<asp:ListItem Value="2">PL </asp:ListItem>
							</asp:RadioButtonList>&nbsp;Number</TD>
						<TD style="WIDTH: 1px; HEIGHT: 3px">:</TD>
						<TD style="WIDTH: 87px; HEIGHT: 3px">
							<asp:DropDownList id="ddlType" runat="server" AutoPostBack="True"></asp:DropDownList></TD>
						<TD style="HEIGHT: 3px">
							<asp:Label id="lblName" runat="server" Width="654px"></asp:Label></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 168px">
							<asp:Button id="btnDetails" runat="server"></asp:Button></TD>
						<TD style="WIDTH: 168px" colSpan="3">
							<asp:Button id="btnUsage" runat="server"></asp:Button></TD>
					</TR>
				</TABLE>
				<TABLE id="Table1" style="WIDTH: 178px; HEIGHT: 97px" cellSpacing="1" cellPadding="1" width="178" bgColor="#ffcc66" border="1">
					<TR>
						<TD>
							<asp:RadioButtonList id="rblDetails" runat="server" Width="215px" AutoPostBack="True" RepeatLayout="Flow">
								<asp:ListItem Value="5" Selected="True">Cleared IDN Details</asp:ListItem>
								<asp:ListItem Value="6">Pending IDN Details</asp:ListItem>
								<asp:ListItem Value="7">REJECTED IDN Details</asp:ListItem>
								<asp:ListItem Value="14">WS Critical Items List</asp:ListItem>
								<asp:ListItem Value="15">MR Critical Items List</asp:ListItem>
							</asp:RadioButtonList></TD>
					</TR>
					<TR>
						<TD>
							<asp:Button id="btnShow" runat="server"></asp:Button></TD>
					</TR>
				</TABLE>
				<TABLE id="Table4" style="WIDTH: 212px; HEIGHT: 116px" cellSpacing="1" cellPadding="1" width="212" bgColor="#ff9999" border="1">
					<TR>
						<TD>SandPONumber</TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="txtPO" runat="server" Width="92px" AutoPostBack="True"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD align="left" colSpan="3">
							<asp:RadioButtonList id="rblPO" runat="server" AutoPostBack="True">
								<asp:ListItem Value="8" Selected="True">DBR Details</asp:ListItem>
								<asp:ListItem Value="9">Lab Results Details</asp:ListItem>
							</asp:RadioButtonList></TD>
					</TR>
					<TR>
						<TD align="middle" colSpan="3">
							<asp:Button id="btnSandPO" runat="server"></asp:Button></TD>
					</TR>
				</TABLE>
				<TABLE id="Table5" style="WIDTH: 189px; HEIGHT: 90px" cellSpacing="1" cellPadding="1" width="189" bgColor="#ff99ff" border="1">
					<TR>
						<TD>FromDate</TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="txtFr" runat="server" Width="100px"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>ToDate</TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="txtTo" runat="server" Width="100px"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD align="left" colSpan="3">
							<asp:RadioButtonList id="rblNS" runat="server" AutoPostBack="True">
								<asp:ListItem Value="10" Selected="True">PO Details</asp:ListItem>
								<asp:ListItem Value="13">WS NonStock Indents</asp:ListItem>
							</asp:RadioButtonList></TD>
					</TR>
					<TR>
						<TD align="middle" colSpan="3">
							<asp:Button id="btnDateDetails" runat="server" Text=" "></asp:Button></TD>
					</TR>
				</TABLE>
				<asp:DataGrid id="DataGrid1" runat="server" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
			</asp:panel></form>
	</body>
</HTML>
