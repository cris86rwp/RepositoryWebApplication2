<%@ Page Language="vb" AutoEventWireup="false" Codebehind="mm_pco_WTA_ComplianceAdd.aspx.vb" Inherits="WebApplication2.mm_pco_WTA_ComplianceAdd" Culture="en-GB" uiCulture="en-GB" %>
<!DOCTYPE HTML>
<HTML xmlns="http://www.w3.org/1999/xhtml">
	<HEAD runat="server">
		<title>mm_pco_WTA_ComplianceAdd</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR"/>
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css"/>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
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
   <%--   <link rel="stylesheet" href="../StyleSheet1.css" />--%>
	</HEAD>
	<body>
         <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
  <a class="navbar-brand p-0" href="#"><img src="../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent-333"
    aria-controls="navbarSupportedContent-333" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>
  <div class="collapse navbar-collapse " id="navbarSupportedContent-333" >
      <ul class="navbar-nav ml-auto navbar-center">
         <li class="nav-item" style="font-weight: bold">
             <h1 style="color:white; font-size:30px; margin-left:325px; margin-top:5px">Rail Wheel Plant, Bela</h1> 
       
         </li>
          </ul>
    <ul class="navbar-nav ml-auto  navbar-right">
        <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home " style="font-size:30px;"></i>
        </a></li>

       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out" style="font-size:30px;"></i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
          <%--<img src="../../../CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="50" style="border-width: 34px; background-position: 5px 5px; width:50px;margin-top:3px;border-color:white; border-width:50px"/>
        --%><img src="../NewFolder1/CRIS-Recruitment.jpg" height="45" style="border-radius:43%"/>
       </a>
      </li>
     </ul>
      
  </div>
</nav>
<!--/.Navbar -->

         
         <div class="container">
              <div class="row">
                <div class="table-responsive">

		<form id="Form1" method="post" runat="server">
           <%-- <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>--%>
                 <br />
			<TABLE id="Table1" class="table" <%--style="Z-INDEX: 101; LEFT: 4px; POSITION: absolute; TOP: 7px" cellSpacing="1" cellPadding="1" width="300"--%> >
				<TR>
					<TD colSpan="3"><h2>WTA Compliance</h2><hr class="prettyline" /></TD>
				</TR>
				<TR>
					<TD colSpan="3">Mode :
						<asp:label id="lblMode" runat="server" ForeColor="Red"></asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="3">Message :
						<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></TD>
				</TR>
                </table>
				<table id="table7" class="table">
							<TR>
								<TD>DC Number&nbsp; :&nbsp;
									<asp:textbox id="txtDCNumber" runat="server" Font-Bold="True" CssClass="form-control" ></asp:textbox></TD>
								<TD>DC Quantity&nbsp; :&nbsp;
									<asp:textbox id="txtDCQty" runat="server" Font-Bold="True" CssClass="form-control"></asp:textbox></TD>
								<TD>DC Remarks&nbsp; :&nbsp;
									<asp:textbox id="txtDCRemarks" runat="server" CssClass="form-control"></asp:textbox></TD>
							</TR>
							<TR>
								<TD><asp:button id="btnShowPlan" runat="server" Text="Show Plan" CssClass="button button2"></asp:button></TD>
								<TD><asp:button id="btnShowSupply" runat="server" Text="Show Supply" CssClass="button button2"></asp:button></TD>
								<TD vAlign="top" align="center">&nbsp;
									<asp:button id="btnSave" runat="server" Text="Save" CssClass="button button2"></asp:button>&nbsp;
									<asp:button id="btnChangeSupplyID" runat="server" Text="Change SupplyID" CssClass="button button2"></asp:button></TD>
							</TR>
							</table>
                                
									<TABLE id="Table5" class="table" <%--cellSpacing="1" cellPadding="1" width="300"--%>>
										<TR>
											<TD>PlanID</TD>
											<TD>:</TD>
											<TD><asp:label id="lblPlanID" runat="server"></asp:label>&nbsp;</TD>
										</TR>
										<TR>
											<TD>ProductCode</TD>
											<TD>:</TD>
											<TD><asp:label id="lblProductCode" runat="server"></asp:label>&nbsp;</TD>
										</TR>
										<TR>
											<TD>ProductDesc</TD>
											<TD>:</TD>
											<TD><asp:label id="lblProductDesc" runat="server"></asp:label>&nbsp;</TD>
										</TR>
										<TR>
											<TD>ProductQty</TD>
											<TD>:</TD>
											<TD><asp:label id="lblProductQty" runat="server"></asp:label>&nbsp;</TD>
										</TR>
										<TR>
											<TD>WTA Number &amp; Dt</TD>
											<TD>:</TD>
											<TD><asp:label id="lblWTANumDt" runat="server"></asp:label>&nbsp;</TD>
										</TR>
										<TR>
											<TD>Order Number &amp; Dt</TD>
											<TD>:</TD>
											<TD><asp:label id="lblOrderNumDt" runat="server"></asp:label>&nbsp;</TD>
										</TR>
									 
										<TR>
											<TD>SupplyID</TD>
											<TD>:</TD>
											<TD><asp:label id="lblSupplyID" runat="server"></asp:label>&nbsp;</TD>
										</TR>
										<TR>
											<TD>SupplierCode</TD>
											<TD>:</TD>
											<TD><asp:label id="lblSupplierCode" runat="server"></asp:label>&nbsp;</TD>
										</TR>
										<TR>
											<TD>SupplierName</TD>
											<TD>:</TD>
											<TD><asp:label id="lblSupplierName" runat="server"></asp:label>&nbsp;</TD>
										</TR>
										<TR>
											<TD>SupplyQty</TD>
											<TD>:</TD>
											<TD><asp:label id="lblSupplyQty" runat="server"></asp:label>&nbsp;</TD>
										</TR>
									</TABLE>
								
									<TABLE id="Table8" class="table" <%--cellSpacing="1" cellPadding="1" width="300"--%> >
										<TR>
											<TD>Despatch From Date</TD>
											<TD>:</TD>
											<TD><asp:textbox id="txtFrDt" runat="server" CssClass="form-control"></asp:textbox><asp:label id="lblFrDt" runat="server" ></asp:label>&nbsp;</TD>
										</TR>
										<TR>
											<TD>DespatchTo Date</TD>
											<TD>:</TD>
											<TD><asp:textbox id="txtToDt" runat="server" CssClass="form-control"></asp:textbox><asp:label id="lblToDt" runat="server"></asp:label>&nbsp;</TD>
										<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtToDt" ControlToValidate="txtFrDt" ErrorMessage="To Date should be greater than From Date" ForeColor="#FF3300" Operator="LessThanEqual" Type="Date"></asp:CompareValidator>

                                        </TR>
										<TR>
											<TD colSpan="3"><asp:button id="btnShowDespatches" runat="server" Text="Show Despatches" CssClass="button button2"></asp:button>&nbsp;</TD>
										</TR>
									</TABLE>
								
                
            	<TABLE id="Table9" class="table" >
				<TR>
					<TD colSpan="3">
                        <asp:datagrid id="DataGrid1" runat="server" CssClass="table">
                            <SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>

							<Columns>
								<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
							</Columns>
                            <PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD colSpan="3">
						<asp:Panel id="pnlCompliance" CssClass="table" runat="server">
							<asp:DataGrid id="dgDCNumbers" runat="server">
                                <SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
                                <PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
							</asp:DataGrid>
						</asp:Panel></TD>
				</TR>
			</TABLE>
		</form></div></div></div>
        <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>

	</body>
</HTML>
