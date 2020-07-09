<%@ Page Language="vb" AutoEventWireup="false" Codebehind="mm_pco_WTA_SuppliesView.aspx.vb" Inherits="WebApplication2.mm_pco_WTA_SuppliesView" %>
<!DOCTYPE HTML>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>mm_pco_WTA_SuppliesView</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR"/>
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/> 

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
    <%--  <link rel="stylesheet" href="../StyleSheet1.css" />--%>
    
	</head>
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
            <%--<h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>--%>
                 <br />
			<TABLE id="Table1" class="table" >
                <%--style="Z-INDEX: 101; LEFT: 7px; WIDTH: 402px; POSITION: absolute; TOP: 4px; HEIGHT: 447px" cellSpacing="1" cellPadding="1" width="402"--%>
				<TR>
					<TD colSpan="3" align="middle"><h2>WTA Planned Quantities&nbsp;(&nbsp;Details 
							Consignee-wise&nbsp;)</h2></TD>
				</TR>
				<TR>
					<TD colSpan="3">Mode :
						<asp:label id="lblMode" runat="server" ForeColor="Red"></asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="3">Message :<asp:label id="lblMessage" runat="server" ForeColor="Red" ></asp:label></TD>
                    <%--Width="561px"--%>
				</TR>
                
				<TR>
					<TD colSpan="3">
                        <asp:datagrid id="dgPlanDetails" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="3">
                            <SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
                            							<Columns>
								<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn DataField="PlanId" ReadOnly="True" HeaderText="PlanId"></asp:BoundColumn>
								<asp:BoundColumn DataField="ProductCode" ReadOnly="True" HeaderText="ProductCode"></asp:BoundColumn>
								<asp:BoundColumn DataField="Description" ReadOnly="True" HeaderText="Description"></asp:BoundColumn>
								<asp:BoundColumn DataField="WtaNumber" ReadOnly="True" HeaderText="WtaNumber"></asp:BoundColumn>
								<asp:BoundColumn DataField="WtaDate" ReadOnly="True" HeaderText="WtaDate"></asp:BoundColumn>
								<asp:BoundColumn DataField="OrderNumber" ReadOnly="True" HeaderText="OrderNumber"></asp:BoundColumn>
								<asp:BoundColumn DataField="OrderDate" ReadOnly="True" HeaderText="OrderDate"></asp:BoundColumn>
								<asp:BoundColumn DataField="OrderQty" ReadOnly="True" HeaderText="OrderQty"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="OrdId" ReadOnly="True" HeaderText="OrdId"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="Ref" ReadOnly="True" HeaderText="Ref"></asp:BoundColumn>
							</Columns>
                            <PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
							
						</asp:datagrid></TD>
				</TR>
                        </TABLE>
				<asp:panel id="pnlPlan" runat="server" Visible="False">
							<TABLE id="Table2" class="table" >
                                 <%--style="WIDTH: 388px; HEIGHT: 131px" cellSpacing="1" cellPadding="1" width="388"--%>
								<TR>
									<TD>Product Code</TD>
									<TD>:</TD>
									<TD>
										<asp:dropdownlist id="ddlProductCode" runat="server" AutoPostBack="True" CssClass="form-control ll"></asp:dropdownlist>
										<asp:label id="lblPlanID" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD>WTA Number</TD>
									<TD>:</TD>
									<TD>
										<asp:dropdownlist id="ddlWTANumber" runat="server" AutoPostBack="True" CssClass="form-control ll"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD>WTA Order</TD>
									<TD>:</TD>
									<TD>
										<asp:dropdownlist id="ddlOrderNumber" runat="server" AutoPostBack="True" CssClass="form-control ll"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD>Quantity Date</TD>
									<TD>:</TD>
									<TD>
										<asp:textbox id="txtQuantityDate" runat="server" cssclass="form-control" AutoPostBack="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD>Order Quantity</TD>
									<TD>:</TD>
									<TD>
										<asp:textbox id="txtOrderQty" runat="server" cssclass="form-control" AutoPostBack="True"></asp:textbox></TD>
								</TR>
							</TABLE>
						</asp:panel>
				<asp:panel id="pnlConsignee" runat="server" ForeColor="White">
							<TABLE id="Table3" class="table" >
                                 <%--style="WIDTH: 351px; HEIGHT: 109px" cellSpacing="1" cellPadding="1" width="351"--%>
								<TR>
									<TD>ConsigneeCode</TD>
									<TD>:</TD>
									<TD>
										<asp:dropdownlist id="ddlConsigneeCode" runat="server" CssClass="form-control ll"></asp:dropdownlist>
										<asp:Label id="lblSupplyID" runat="server" cssclass="form-control" visible ="False"></asp:Label></TD>
								</TR>
								<TR>
									<TD>Ordered Qty</TD>
									<TD>:</TD>
									<TD>
										<asp:textbox id="txtOrderedQty" runat="server" cssclass="form-control" AutoPostBack="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD>Remarks</TD>
									<TD>:</TD>
									<TD>
										<asp:textbox id="txtSupplyRemarks" runat="server" cssclass="form-control"></asp:textbox></TD>
								</TR>
								<TR>
									<TD vAlign="top" align="middle" colSpan="3">
										<asp:button id="btnSave" runat="server" Text="Delete" CssClass="button button2"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									</TD>
								</TR>
							</TABLE>
						</asp:panel>
                <table class="table">
				<TR>
					<TD vAlign="top" align="middle" colSpan="3">
						<asp:Button id="btnChange" runat="server" Text="Change PlanID" CssClass="button button2"></asp:Button></TD>
				</TR></table>
                    
                
                    <TABLE id="Table4" class="table" >
				<TR>
					<TD vAlign="top" align="left" colSpan="3"><asp:datagrid id="dgData" runat="server" BackColor="White" Height="160px" CellPadding="4" BorderWidth="1px" BorderStyle="None" BorderColor="#3366CC" CssClass="table">
							<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
							<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
							<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
							<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
                        </TABLE>
              
			
		</form>
                    </div></div></div>
        <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</html>
