<%@ Page Language="vb" AutoEventWireup="false" Codebehind="StockIDNItemListItems.aspx.vb" Inherits="WebApplication2.StockIDNItemListItems" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>StockIDNItemListItems</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body bgColor="#99ccff" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:panel id="Panel2" style="Z-INDEX: 102; LEFT: 2px; POSITION: absolute; TOP: 3px" runat="server">
				<TABLE id="Table1" style="WIDTH: 297px; HEIGHT: 41px" cellSpacing="1" cellPadding="1" width="297" border="1">
					<TR>
						<TD colSpan="3">
							<asp:Label id="lblConsignee" runat="server"></asp:Label>- Usage of IDNs of 
							Stock items
						</TD>
					</TR>
					<TR>
						<TD colSpan="3">
							<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></TD>
					</TR>
					<TR>
						<TD colSpan="3">
							<asp:RadioButtonList id="rblType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" AutoPostBack="True">
								<asp:ListItem Value="IDN" Selected="True">IDN</asp:ListItem>
								<asp:ListItem Value="Sand">Sand</asp:ListItem>
							</asp:RadioButtonList></TD>
					</TR>
				</TABLE>
				<asp:Panel id="pnlIDN" runat="server">
					<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="300" border="1">
						<TR>
							<TD>IDN</TD>
							<TD>:</TD>
							<TD>
								<asp:DropDownList id="ddlIDNs" runat="server" AutoPostBack="True" Width="130px"></asp:DropDownList></TD>
						</TR>
					</TABLE>
					<asp:DataGrid id="DataGrid2" runat="server" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966">
						<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
						<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
						<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
						<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
						<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
					</asp:DataGrid>
					<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="300" border="1">
						<TR>
							<TD>FromHeatNo</TD>
							<TD>:</TD>
							<TD>
								<asp:TextBox id="txtFromHeatNo" runat="server" AutoPostBack="True" Width="82px"></asp:TextBox></TD>
							<TD>ToHeatNo</TD>
							<TD>:</TD>
							<TD>
								<asp:TextBox id="txtToHeatNo" runat="server" AutoPostBack="True" Width="82px"></asp:TextBox></TD>
							<TD>QtyConsumed</TD>
							<TD>:</TD>
							<TD>
								<asp:TextBox id="txtQtyTested" runat="server" AutoPostBack="True" Width="72px"></asp:TextBox></TD>
							<TD>UsedFromDate</TD>
							<TD>
								<asp:TextBox id="txtUsedFromDate" runat="server" AutoPostBack="True" Width="82px"></asp:TextBox></TD>
							<TD>UsedToDate</TD>
							<TD>
								<asp:TextBox id="txtUsedToDate" runat="server" AutoPostBack="True" Width="82px"></asp:TextBox></TD>
						</TR>
					</TABLE>
					<TABLE id="Table2" style="WIDTH: 695px; HEIGHT: 61px" cellSpacing="1" cellPadding="1" width="695" border="1">
						<TR>
							<TD>Remarks</TD>
							<TD>:</TD>
							<TD>
								<asp:TextBox id="txtRemarks" runat="server" Width="616px"></asp:TextBox></TD>
						</TR>
						<TR>
							<TD align="middle" colSpan="3">
								<asp:Button id="btnUsage" runat="server" Text="Save Usage"></asp:Button>
								<asp:Label id="lblItemsID" runat="server" Visible="False"></asp:Label></TD>
						</TR>
					</TABLE>
					<asp:DataGrid id="dgStockIDN" runat="server" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#3366CC" AutoGenerateColumns="False">
						<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
						<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
						<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
						<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
						<Columns>
							<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
							<asp:BoundColumn DataField="IDNid" ReadOnly="True" HeaderText="IDNid"></asp:BoundColumn>
							<asp:BoundColumn DataField="UsedFrDt" ReadOnly="True" HeaderText="UsedFrDt"></asp:BoundColumn>
							<asp:BoundColumn DataField="UsedToDt" ReadOnly="True" HeaderText="UsedToDt"></asp:BoundColumn>
							<asp:BoundColumn DataField="FromHeat" ReadOnly="True" HeaderText="FromHeat"></asp:BoundColumn>
							<asp:BoundColumn DataField="ToHeat" ReadOnly="True" HeaderText="ToHeat"></asp:BoundColumn>
							<asp:BoundColumn DataField="QtyTested" ReadOnly="True" HeaderText="QtyTested"></asp:BoundColumn>
							<asp:BoundColumn DataField="Remarks" ReadOnly="True" HeaderText="Remarks"></asp:BoundColumn>
							<asp:BoundColumn DataField="ItemsID" ReadOnly="True" HeaderText="ItemsID"></asp:BoundColumn>
							<asp:ButtonColumn Text="Delete" CommandName="Delete"></asp:ButtonColumn>
						</Columns>
						<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
					</asp:DataGrid>
				</asp:Panel>
				<asp:Panel id="pnlSand" runat="server">
					<TABLE id="Table5" style="WIDTH: 149px; HEIGHT: 32px" cellSpacing="1" cellPadding="1" width="149" border="1">
						<TR>
							<TD>PONo</TD>
							<TD>:</TD>
							<TD>
								<asp:TextBox id="txtPONo" runat="server" AutoPostBack="True" Width="86px"></asp:TextBox></TD>
						</TR>
					</TABLE>
					<asp:DataGrid id="dgSand" runat="server" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966">
						<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
						<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
						<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
						<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
						<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
					</asp:DataGrid>
					<asp:DataGrid id="dgPO" runat="server" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#3366CC" AutoGenerateColumns="False">
						<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
						<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
						<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
						<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
						<Columns>
							<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
							<asp:BoundColumn DataField="FromHeat" HeaderText="FromHeat"></asp:BoundColumn>
							<asp:BoundColumn DataField="ToHeat" HeaderText="ToHeat"></asp:BoundColumn>
							<asp:BoundColumn DataField="Remarks" HeaderText="Remarks"></asp:BoundColumn>
							<asp:BoundColumn DataField="ItemsID" HeaderText="ItemsID"></asp:BoundColumn>
							<asp:ButtonColumn Text="Delete" CommandName="Delete"></asp:ButtonColumn>
						</Columns>
						<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
					</asp:DataGrid>
					<TABLE id="Table6" cellSpacing="1" cellPadding="1" width="300" border="1">
						<TR>
							<TD>FromHeatNo</TD>
							<TD>:</TD>
							<TD>
								<asp:TextBox id="txtSandFr" runat="server" AutoPostBack="True" Width="82px"></asp:TextBox></TD>
							<TD>ToHeatNo</TD>
							<TD>:</TD>
							<TD>
								<asp:TextBox id="txtSandTo" runat="server" AutoPostBack="True" Width="82px"></asp:TextBox></TD>
						</TR>
					</TABLE>
					<TABLE id="Table7" style="WIDTH: 360px; HEIGHT: 61px" cellSpacing="1" cellPadding="1" width="360" border="1">
						<TR>
							<TD>Remarks</TD>
							<TD>:</TD>
							<TD>
								<asp:TextBox id="txtSandRemarks" runat="server" Width="254px"></asp:TextBox></TD>
						</TR>
						<TR>
							<TD align="middle" colSpan="3">
								<asp:Button id="btnSand" runat="server" Text="Save Sand Usage"></asp:Button>
								<asp:Label id="lblSandItemsID" runat="server" Visible="False"></asp:Label></TD>
						</TR>
					</TABLE>
				</asp:Panel>
			</asp:panel></form>
	</body>
</HTML>
