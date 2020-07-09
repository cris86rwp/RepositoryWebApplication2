<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ChemicalMaterialCharacteristics.aspx.vb" Inherits="WebApplication2.ChemicalMaterialCharacteristics" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>ChemicalMaterialCharacteristics</title>
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
    <%-- <link rel="stylesheet" href="../../../../StyleSheet1.css" />--%>
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
			<asp:Panel id="Panel1"  runat="server">
				<TABLE id="Table3" class="table">
					<TR>
						<TD><FONT size="5">Chemical Testing Material Characteristics&nbsp;&nbsp;
								<asp:Label id="lblUser" runat="server"></asp:Label></FONT><hr class="prettyline" /></TD>
					</TR>
				</TABLE>
				<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label>
				<TABLE id="Table4" class="table">
					<TR>
						<TD style="WIDTH: 97px">TypeOfTesting</TD>
						<TD style="WIDTH: 6px">:</TD>
						<TD>
							<asp:RadioButtonList id="rblMaterialType" runat="server" RepeatLayout="Flow" AutoPostBack="True" RepeatDirection="Horizontal" CssClass="rbl"></asp:RadioButtonList></TD>
					</TR>
				</TABLE>
				<TABLE id="Table5" class="table">
					<TR>
						<TD>MaterialName</TD>
						<TD>:</TD>
						<TD>
							<asp:DropDownList id="ddlMaterial" runat="server" AutoPostBack="True" CssClass="form-control ll"></asp:DropDownList></TD>
					</TR>
				</TABLE>
				<TABLE id="Table1" class="table-active">
					<TR>
						<TD style="WIDTH: 139px">Characteristics</TD>
						<TD>:</TD>
						<TD colSpan="4">
							<asp:TextBox id="txtCharacteristics" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD  vAlign="top" align="right">
							<asp:CheckBox id="chkUnit" runat="server" AutoPostBack="True" Text="Other Unit"></asp:CheckBox></TD>
						<TD>:</TD>
						<TD colSpan="4">
							<asp:TextBox id="txtUnit" runat="server" CssClass="form-control"></asp:TextBox>&nbsp;</TD>
					</TR>
					<TR>
						<TD  colSpan="6">
							<asp:RadioButtonList id="rblUnit" runat="server" RepeatLayout="Flow" CssClass="rbl" RepeatDirection="Horizontal">
								<asp:ListItem Value="gm/CC" Selected="True">gm/CC</asp:ListItem>
								<asp:ListItem Value="%">%</asp:ListItem>
								<asp:ListItem Value="mg/litre">mg/litre</asp:ListItem>
								<asp:ListItem Value="microns">microns</asp:ListItem>
								<asp:ListItem Value="gm/cm3">gm/cm3</asp:ListItem>
								<asp:ListItem Value="ppm">ppm</asp:ListItem>
								<asp:ListItem Value="PSI">PSI</asp:ListItem>
								<asp:ListItem Value="mm">mm</asp:ListItem>
								<asp:ListItem Value="&#176;C">&#176;C</asp:ListItem>
								<asp:ListItem Value="&#176;F">&#176;F</asp:ListItem>
								<asp:ListItem Value="AFS">AFS</asp:ListItem>
								<asp:ListItem Value="RND/SAG">RND/SAG</asp:ListItem>
							</asp:RadioButtonList></TD>
					</TR>
					<TR>
						<TD  colSpan="6">
							<TABLE id="Table2" class="table">
								<TR>
									<TD>MinimumValue</TD>
									<TD>
										<asp:TextBox id="txtMinValue" runat="server" CssClass="form-control"></asp:TextBox></TD>
									<TD>MaximumValue</TD>
									<TD>
										<asp:TextBox id="txtMaxValue" runat="server" CssClass="form-control"></asp:TextBox></TD>
									<TD>NominalValue</TD>
									<TD>
										<asp:TextBox id="txtNominalValue" runat="server" CssClass="form-control"></asp:TextBox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD>Remarks</TD>
						<TD>:</TD>
						<TD colSpan="4">
							<asp:TextBox id="txtRemarks" runat="server" CssClass="form-control"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
							Order No&nbsp;:
							<asp:TextBox id="txtOrderBY" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="middle" colSpan="6">
							<asp:Button id="btnSave" runat="server" Text="Save" CssClass="button button2"></asp:Button>
							<asp:Label id="lblCharID" runat="server" Visible="False"></asp:Label></TD>
					</TR>
				</TABLE>
				<asp:DataGrid id="dgMaterialList" runat="server" PageSize="5" CssClass="table" AllowPaging="True" CellPadding="4" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966" BackColor="White">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<Columns>
						<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
			</asp:Panel>
                </div></div>
		</form>
            </div>

         <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
