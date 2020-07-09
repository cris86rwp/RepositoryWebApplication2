<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ChemicalTestResults.aspx.vb" Inherits="WebApplication2.ChemicalTestResults" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD runat="server">
		<title>ChemicalTestResults</title>
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
			<P>
				<asp:Panel  runat="server">
<TABLE id="Table2" class="table">
  <TR>
    <TD><FONT size=5>Test Results</FONT><hr class="prettyline" /></TD></TR>

</TABLE>
<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label>
<TABLE id="Table1" class="table">
  <TR>
    <TD>LabNumber</TD>
    <TD>:</TD>
    <TD>
<asp:dropdownlist id="ddlLabNumber" runat="server" AutoPostBack="True" CssClass="form-control ll"></asp:dropdownlist></TD></TR></TABLE>
<asp:label id="lblMaterial" runat="server" ForeColor="Red"></asp:label>
<TABLE id="Table4" class="table">
  <TR>
    <TD>
<asp:DataGrid id="grdCharacteristics" runat="server" CssClass="table" AutoGenerateColumns="False" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4" Width="923px">
						<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
						<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
						<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
						<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
						<Columns>
							<asp:BoundColumn DataField="CharID" ReadOnly="True" HeaderText="SlNo"></asp:BoundColumn>
							<asp:BoundColumn DataField="CharName" ReadOnly="True" HeaderText="CharName"></asp:BoundColumn>
							<asp:TemplateColumn HeaderText="TestValue">
								<ItemTemplate>
									<asp:TextBox id="txtValue" runat="server" Width="70px"></asp:TextBox>
								</ItemTemplate>
							</asp:TemplateColumn>
							<asp:BoundColumn DataField="Unit" ReadOnly="True" HeaderText="Unit"></asp:BoundColumn>
							<asp:BoundColumn DataField="MinValue" ReadOnly="True" HeaderText="MinValue"></asp:BoundColumn>
							<asp:BoundColumn DataField="MaxValue" ReadOnly="True" HeaderText="MaxValue"></asp:BoundColumn>
							<asp:BoundColumn DataField="NominalValue" ReadOnly="True" HeaderText="NominalValue"></asp:BoundColumn>
							<asp:TemplateColumn HeaderText="Remarks">
								<ItemTemplate>
									<asp:TextBox id="txtRemarks" runat="server"></asp:TextBox>
								</ItemTemplate>
							</asp:TemplateColumn>
						</Columns>
						<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
					</asp:DataGrid></TD></TR></TABLE>
<TABLE id="Table3" class="table">
  <TR>
    <TD vAlign=top align=middle colSpan=3>
<asp:Button id="btnSave" tabIndex=-1 runat="server" Text="Save" CssClass="button button2"></asp:Button></TD></TR>

</TABLE>
				</asp:Panel></P>
                </div></div>
		</form>
            </div>
        <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
