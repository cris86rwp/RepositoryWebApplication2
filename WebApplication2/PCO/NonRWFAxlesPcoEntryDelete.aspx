<%@ Page Language="vb" AutoEventWireup="false" Codebehind="NonRWFAxlesPcoEntryDelete.aspx.vb" Inherits="WebApplication2.NonRWFAxlesPcoEntryDelete" %>
<!DOCTYPE HTML >
<HTML>
	<HEAD>
		<title>NonRWFAxlesPcoEntryDelete</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">

        <meta charset="utf-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css"/>
  <script  src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js"></script>
         <link type="text/css" rel="stylesheet" href="https://cdn.datatables.net/1.10.9/css/dataTables.bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="https://cdn.datatables.net/responsive/1.0.7/css/responsive.bootstrap.min.css" />
    <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.9/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/responsive/1.0.7/js/dataTables.responsive.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.9/js/dataTables.bootstrap.min.js"></script>
    <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
      <%-- <link rel="stylesheet" href="StyleSheet1.css" />--%>
    
	</HEAD>
	<body  >
        <div><h1 style="text-align:center;">Rail Wheel Plant Bela (PCO Module)</h1></div>
        <div class="page-header"><img src="NewFolder1/imageedit_3_3734794333 (1).gif" height="60"/><div class="header-right "><img src="NewFolder1/ezgif.com-resize.gif" height="60"  /> </div> </div>
        <div class="container">
		<form id="Form1" method="post" runat="server">
             <div class="row">
                <div class="table-responsive">
			<TABLE id="Table1" class="table">
				<TR>
					<TD noWrap="nowrap" align="center" colSpan="6"><STRONG><FONT size="4">Non-RWF Axles PCO Entry-- 
								Delete</FONT></STRONG><hr class="prettyline" /></TD>
				</TR>
				<TR>
					<TD noWrap="nowrap" align="right" colSpan="6">Mode
						<asp:label id="lblMode" runat="server" Font-Bold="True"></asp:label></TD>
				</TR>
				<TR>
					<TD noWrap="nowrap">Message</TD>
					<TD noWrap="nowrap" colSpan="5"><asp:label id="lblMessage" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:label></TD>
				</TR>
				<TR>
					<TD noWrap="nowrap">Emp Code</TD>
					<TD noWrap="nowrap" colSpan="5"><asp:label id="lblPcoEmpcode" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD noWrap="nowrap">Rites QAC</TD>
					<TD noWrap="nowrap" colSpan="5"><asp:dropdownlist id="ddlQac" tabIndex="1" runat="server" AutoPostBack="True" CssClass="form-control ll"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD noWrap="nowrap">Rites QAC Date</TD>
					<TD noWrap="nowrap" colSpan="5"><asp:label id="lblQacDt" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD noWrap="nowrap">Product Code</TD>
					<TD noWrap="nowrap" colSpan="5"><asp:label id="lblProductCode" runat="server"></asp:label>&nbsp;</TD>
				</TR>
				<TR>
					<TD noWrap="nowrap">Product Descr</TD>
					<TD noWrap="nowrap" colSpan="5"><asp:label id="lblProdDescr" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD noWrap="nowrap">Product Drg</TD>
					<TD noWrap="nowrap" colSpan="5"><asp:label id="lblRwfDrg" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD noWrap="nowrap">Cust Drg</TD>
					<TD noWrap="nowrap" colSpan="5"><asp:label id="lblCustDrg" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD noWrap="nowrap">Manufacturer</TD>
					<TD noWrap="nowrap" colSpan="5"><asp:label id="lblManufacturer" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD noWrap="nowrap">Contractor</TD>
					<TD noWrap="nowrap" colSpan="5"><asp:label id="lblContractor" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD noWrap="nowrap">Contract</TD>
					<TD noWrap="nowrap" colSpan="5"><asp:label id="lblContract" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD noWrap="nowrap">Cur Supply</TD>
					<TD noWrap="nowrap"><asp:label id="lblCurSupply" runat="server"></asp:label></TD>
					<TD noWrap="nowrap">Posted</TD>
					<TD noWrap="nowrap"><asp:label id="lblPosted" runat="server"></asp:label></TD>
					<TD noWrap="nowrap">Bal. for Posting</TD>
					<TD noWrap="nowrap"><asp:label id="lblBalForPosting" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD noWrap="nowrap">Cast/Heat Number</TD>
					<TD noWrap="nowrap"><asp:textbox id="txtCastHeatNo" tabIndex="2" runat="server" CssClass="form-control"></asp:textbox></TD>
					<TD noWrap="nowrap" colSpan="3">Customer Axle Number</TD>
					<TD noWrap="nowrap"><asp:textbox id="txtCustAxleNo" tabIndex="3" runat="server" CssClass="form-control"></asp:textbox></TD>
				</TR>
				<TR>
					<TD noWrap="nowrap" align="center" colSpan="6"><asp:button id="BtnSave" tabIndex="4" runat="server" CssClass="button button4" Text="Delete"></asp:button></TD>
				</TR>
				<TR>
					<TD noWrap="nowrap" colSpan="6"><asp:datagrid id="dgData" tabIndex="-1" runat="server" BorderColor="White" BorderStyle="Ridge" CellSpacing="1" BorderWidth="2px" BackColor="White" CellPadding="3" GridLines="None">
							<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#9471DE"></SelectedItemStyle>
							<ItemStyle ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
							<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
							<PagerStyle HorizontalAlign="Right" ForeColor="Black" BackColor="#C6C3C6"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
                     </div> </div>
		</form>
            </div>
        <div class="card-footer"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
