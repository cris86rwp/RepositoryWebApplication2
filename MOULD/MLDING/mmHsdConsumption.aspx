<%@ Page Language="vb" AutoEventWireup="false" Codebehind="mmHsdConsumption.aspx.vb" Inherits="WebApplication2.mmHsdConsumption" Culture="en-GB" uiCulture="en-GB" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>mmHsdConsumption</title>
		<link href="/wap/MailStyles.css" rel="stylesheet">
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<asp:Panel id="Panel1" style="Z-INDEX: 103; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server">
				<TABLE id="Table1" style="WIDTH: 851px; HEIGHT: 359px" cellSpacing="1" cellPadding="1" width="851" border="1">
					<TR>
						<TD align="center" colSpan="8">
							<asp:label id="lblHeader" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#0000C0"></asp:label></TD>
					</TR>
					<TR>
						<TD>Message</TD>
						<TD colSpan="7">
							<asp:label id="lblMessage" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:label>&nbsp;</TD>
					</TR>
					<TR>
						<TD>
							<asp:checkbox id="chkHelp" tabIndex="-1" runat="server" AutoPostBack="True" Text="Help"></asp:checkbox></TD>
						<TD colSpan="7">
							<asp:label id="lblHelp" runat="server" Visible="False"></asp:label>&nbsp;</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 41px">LoggedInBy</TD>
						<TD style="WIDTH: 330px; HEIGHT: 41px" colSpan="5">
							<asp:label id="lblLogInEmpCode" runat="server"></asp:label></TD>
						<TD style="WIDTH: 50px; HEIGHT: 41px">Mode</TD>
						<TD style="HEIGHT: 41px">
							<asp:label id="lblMode" runat="server"></asp:label>&nbsp;</TD>
					</TR>
					<TR>
						<TD>Date</TD>
						<TD colSpan="3">
							<asp:textbox id="txtCurRdgDt" runat="server" AutoPostBack="True" Width="117px"></asp:textbox></TD>
						<TD style="WIDTH: 206px" colSpan="2">&nbsp;</TD>
						<TD style="WIDTH: 50px">Shift</TD>
						<TD>
							<asp:radiobuttonlist id="rdoCurRdgShift" runat="server" AutoPostBack="True" Width="248px" RepeatLayout="Flow" RepeatDirection="Horizontal">
								<asp:ListItem Value="A">06:15</asp:ListItem>
								<asp:ListItem Value="B">14:15</asp:ListItem>
								<asp:ListItem Value="C">22:15</asp:ListItem>
							</asp:radiobuttonlist></TD>
					</TR>
					<TR>
						<TD>LPG & BMCG Point</TD>
						<TD colSpan="3">
							<asp:dropdownlist id="ddlHsdPoints" tabIndex="1" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
						<TD style="WIDTH: 68px">MeterUnit</TD>
						<TD style="WIDTH: 120px">
							<asp:label id="lblMtrUnit" runat="server"></asp:label>&nbsp;</TD>
						<TD style="WIDTH: 50px">MultiplyingFactor</TD>
						<TD>
							<asp:label id="lblMultiplyingFactor" runat="server"></asp:label>&nbsp;</TD>
					</TR>
					<TR>
						<TD>Usedfor
						</TD>
						<TD colSpan="7">
							<asp:label id="lblMtrUsedFor" runat="server"></asp:label>&nbsp;</TD>
					</TR>
					<TR>
						<TD colSpan="8">Last Reading</TD>
					</TR>
					<TR>
						<TD>Date</TD>
						<TD colSpan="3">
							<asp:label id="lblPrevRdgDate" runat="server"></asp:label>&nbsp;</TD>
						<TD style="WIDTH: 68px">Shift</TD>
						<TD style="WIDTH: 120px">
							<asp:label id="lblPrevRdgShift" runat="server"></asp:label></TD>
						<TD style="WIDTH: 50px">MeterReading</TD>
						<TD>
							<asp:label id="lblPrevRdg" runat="server"></asp:label>&nbsp;</TD>
					</TR>
					<TR>
						<TD colSpan="8">Current Reading</TD>
					</TR>
					<TR>
						<TD>MeterReading</TD>
						<TD style="WIDTH: 330px" colSpan="5">
							<asp:textbox id="txtCurRdg" runat="server" AutoPostBack="True" Width="117px"></asp:textbox></TD>
						<TD style="WIDTH: 50px">Consumption</TD>
						<TD>
							<asp:label id="lblConsumption" runat="server"></asp:label>&nbsp;</TD>
					</TR>
					<TR>
						<TD>Remarks</TD>
						<TD colSpan="7">
							<asp:textbox id="txtRemarks" runat="server" AutoPostBack="True" Width="591px" MaxLength="50"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="center" colSpan="8">
							<asp:button id="btnSave" runat="server" Text="Save" Width="199px"></asp:button></TD>
					</TR>
				</TABLE>
				<asp:datagrid id="dgData" runat="server" BorderColor="White" BorderStyle="Ridge" CellSpacing="1" BorderWidth="2px" BackColor="White" CellPadding="3" GridLines="None">
					<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#9471DE"></SelectedItemStyle>
					<ItemStyle ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
					<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
					<PagerStyle HorizontalAlign="Right" ForeColor="Black" BackColor="#C6C3C6"></PagerStyle>
				</asp:datagrid>
			</asp:Panel></form>
	</body>
</HTML>
