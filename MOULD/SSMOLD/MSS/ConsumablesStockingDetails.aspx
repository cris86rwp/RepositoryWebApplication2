<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ConsumablesStockingDetails.aspx.vb" Inherits="WebApplication2.ConsumablesStockingDetails" Culture="en-GB" uiCulture="en-GB" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>ConsumablesStockingDetails</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body bgColor="#ffcc99" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:panel id="Panel1" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server">
				<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="300" border="1">
					<TR>
						<TD colSpan="2"><FONT size="5">
								<asp:label id="lblConsignee" runat="server"></asp:label>&nbsp;Consumable&nbsp;Amendments 
								Details </FONT>
						</TD>
					</TR>
					<TR>
						<TD>
							<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="300" border="1">
								<TR>
									<TD colSpan="3">
										<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></TD>
								</TR>
								<TR>
									<TD>Date</TD>
									<TD>:</TD>
									<TD>
										<asp:TextBox id="txtDate" runat="server" Width="77px" AutoPostBack="True"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD>PL Number</TD>
									<TD>:</TD>
									<TD>
										<asp:textbox id="txtPlNumber" runat="server" Width="71px" AutoPostBack="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD>Required Qty</TD>
									<TD>:</TD>
									<TD>
										<asp:TextBox id="txtReqQty" runat="server" Width="69px" AutoPostBack="True"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD>Remarks</TD>
									<TD>:</TD>
									<TD>
										<asp:TextBox id="txtRemarks" runat="server" Width="186px"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD colSpan="3">
										<asp:Button id="btnSave" runat="server" Text="Save"></asp:Button>
										<asp:Label id="lblSlNo" runat="server" Visible="False"></asp:Label></TD>
								</TR>
							</TABLE>
						</TD>
						<TD vAlign="top" align="left">
							<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="300" border="1">
								<TR>
									<TD>PlDesc</TD>
									<TD>
										<asp:Label id="lblPlDesc" runat="server"></asp:Label>&nbsp;</TD>
								</TR>
								<TR>
									<TD>RecoupType</TD>
									<TD>
										<asp:Label id="lblRecoupType" runat="server"></asp:Label>&nbsp;</TD>
								</TR>
								<TR>
									<TD>RecoupQty</TD>
									<TD>
										<asp:Label id="lblRecoupQty" runat="server"></asp:Label>&nbsp;</TD>
								</TR>
								<TR>
									<TD>UnitName</TD>
									<TD>
										<asp:Label id="lblUnitName" runat="server"></asp:Label>&nbsp;</TD>
								</TR>
								<TR>
									<TD>ExistingQty</TD>
									<TD>&nbsp;
										<asp:TextBox id="txtExistingQty" runat="server" Width="90px"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD>QtyDesc</TD>
									<TD>&nbsp;
										<asp:TextBox id="txtQtyDesc" runat="server"></asp:TextBox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
				<asp:DataGrid id="dgRecoup" runat="server" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<Columns>
						<asp:ButtonColumn Text="Delete" CommandName="Delete"></asp:ButtonColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
				<asp:DataGrid id="dgAll" runat="server" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#3366CC" AutoGenerateColumns="False" PageSize="3">
					<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<Columns>
						<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
						<asp:BoundColumn DataField="RqDate" ReadOnly="True" HeaderText="RqDate"></asp:BoundColumn>
						<asp:BoundColumn DataField="pl_number" ReadOnly="True" HeaderText="pl_number"></asp:BoundColumn>
						<asp:BoundColumn DataField="PlDesc" ReadOnly="True" HeaderText="PlDesc"></asp:BoundColumn>
						<asp:BoundColumn DataField="RecoupType" ReadOnly="True" HeaderText="RecoupType"></asp:BoundColumn>
						<asp:BoundColumn DataField="RecoupQty" ReadOnly="True" HeaderText="RecoupQty"></asp:BoundColumn>
						<asp:BoundColumn DataField="UnitName" ReadOnly="True" HeaderText="UnitName"></asp:BoundColumn>
						<asp:BoundColumn DataField="ExistingQty" ReadOnly="True" HeaderText="ExistingQty"></asp:BoundColumn>
						<asp:BoundColumn DataField="QtyDesc" ReadOnly="True" HeaderText="QtyDesc"></asp:BoundColumn>
						<asp:BoundColumn DataField="QtyReq" ReadOnly="True" HeaderText="QtyReq"></asp:BoundColumn>
						<asp:BoundColumn DataField="Remarks" ReadOnly="True" HeaderText="Remarks"></asp:BoundColumn>
						<asp:BoundColumn DataField="SlNo" ReadOnly="True" HeaderText="SlNo"></asp:BoundColumn>
						<asp:BoundColumn DataField="Consignee" ReadOnly="True" HeaderText="Consignee"></asp:BoundColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
				</asp:DataGrid>
			</asp:panel></form>
	</body>
</HTML>
