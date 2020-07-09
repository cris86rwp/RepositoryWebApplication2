<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ChemicalMaterialList.aspx.vb" Inherits="WebApplication2.ChemicalMaterialList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>ChemicalMaterialList</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
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
   <%--  <link rel="stylesheet" href="../../../../StyleSheet1.css" />--%>

	</HEAD>
    
	<body >
            <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
  <a class="navbar-brand p-0" href="#"><img src="../../../../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent-333"
    aria-controls="navbarSupportedContent-333" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>
  <div class="collapse navbar-collapse " id="navbarSupportedContent-333">
      <ul class="navbar-nav ml-auto  navbar-center">
          <li class="nav-item"> <a class="nav-link" href="#" style="color:white; font-size:25px;">Rail Wheel Plant Bela</a></li>
      </ul>
    <ul class="navbar-nav ml-auto  navbar-right">
       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../../wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home " style="font-size:30px;"></i>
        </a></li>
       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out" style="font-size:30px;"></i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
          <img src="../../../../NewFolder1/CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="45"/>
        </a>
      </li>
     </ul>
      
  </div>
</nav>
<!--/.Navbar -->
        <div class="container">
		<form id="Form1" method="post" runat="server">
            <div class="row"><div class="table-responsive">
			<asp:panel id="Panel1"  runat="server">
				<TABLE id="Table2" class="table"></TABLE>
					
							<TABLE id="Table1" class="table">
								<TR>
									<TD colSpan="3"><FONT size="5">Chemical Testing Material List</FONT><hr class="prettyline" /></TD>
								</TR>
								<TR>
									<TD colSpan="3">
										<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></TD>
								</TR>
								<TR>
									<TD>Type of Testing</TD>
									<TD>:</TD>
									<TD>
										<asp:RadioButtonList id="rblMaterialType" runat="server" AutoPostBack="True" RepeatLayout="Flow" CssClass="rbl"></asp:RadioButtonList></TD>
								</TR>
								<TR>
									<TD>Material Name&nbsp;or PL No ( if Stock/NonStock )</TD>
									<TD>:</TD>
									<TD>
										<asp:TextBox id="txtMaterial" runat="server" AutoPostBack="True" CssClass="form-control"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD colSpan="3">
										<asp:Panel id="pnlName" runat="server" >
											<asp:Label id="lblName" runat="server" ForeColor="Transparent" ></asp:Label>
										</asp:Panel></TD>
								</TR>
								<TR>
									<TD>Specification</TD>
									<TD>:</TD>
									<TD>
										<asp:TextBox id="txtSpec" runat="server" CssClass="form-control"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD>Remarks</TD>
									<TD>:</TD>
									<TD>
										<asp:TextBox id="txtRemarks" runat="server" CssClass="form-control"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD vAlign="top" align="middle" colSpan="3">
										<asp:Button id="btnSave" runat="server" Text="Save" CssClass="button button2"></asp:Button>
										<asp:Label id="lblMaterialID" runat="server" Visible="False"></asp:Label></TD>
								</TR>
							</TABLE>
						
							<TABLE id="Table3" class="table">
								<TR>
									<TD>Search PL Number</TD>
								</TR>
								<TR>
									<TD>Based on
										<asp:RadioButtonList id="rblBased" runat="server" AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl">
											<asp:ListItem Value="Description" Selected="True">Description</asp:ListItem>
											<asp:ListItem Value="PL Number">PL Number</asp:ListItem>
										</asp:RadioButtonList></TD>
								</TR>
								<TR>
									<TD>
										<asp:TextBox id="txtOn" runat="server" CssClass="form-control"></asp:TextBox>
										<asp:Button id="btnSearch" runat="server" Text="Search" CssClass="button button2"></asp:Button></TD>
								</TR>
							</TABLE>
							<asp:DataGrid id="dgPL" runat="server" CssClass="table" BackColor="White" PageSize="5" AllowPaging="True" GridLines="None" CellPadding="3" BorderWidth="2px" CellSpacing="1" BorderStyle="Ridge" BorderColor="White">
								<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#9471DE"></SelectedItemStyle>
								<ItemStyle ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
								<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
								<PagerStyle HorizontalAlign="Right" ForeColor="Black" BackColor="#C6C3C6"></PagerStyle>
							</asp:DataGrid>
				
				<asp:DataGrid id="dgMaterialList" runat="server" CssClass="table" BackColor="White" PageSize="5" AllowPaging="True" CellPadding="4" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<Columns>
						<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
			</asp:panel>
                </div></div>
                </form>
            </div>
        <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
