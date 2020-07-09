<%@ Page Language="vb" AutoEventWireup="false" Codebehind="TODReadings.aspx.vb" Inherits="WebApplication2.TODReadings" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>TODReadings</title>
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
        <%-- <link rel="stylesheet" href="../../../StyleSheet1.css" />--%>
	</HEAD>
	<body >
		           <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
  <a class="navbar-brand p-0" href="#"><img src="../../../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
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
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home " style="font-size:30px;"></i>
        </a></li>
       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out" style="font-size:30px;"></i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
          <img src="../../../NewFolder1/CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="45"/>
        </a>
      </li>
     </ul>
      
  </div>
</nav>
<!--/.Navbar -->
        <div class="container">

		<FORM id="Form1" method="post" runat="server">
              <div class="row">
    
                 <%-- <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" >
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
      </div>
            <div class="row table-responsive">

		
			<asp:panel id="Panel1"  runat="server">
				<TABLE id="Table1" class="table" >
					<TR>
						<TD colSpan="8">TOD Readings</TD>
					</TR>
					<TR>
						<TD colSpan="8">
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></TD>
					</TR>
					<TR>
						<TD colSpan="8">Date :
							<asp:textbox id="txtDate" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox></TD>
					</TR>
					<TR>
						<TD >&nbsp;</TD>
						<TD>INITIALreading&nbsp;
						</TD>
						<TD >FINALreading
						</TD>
						<TD>DIFFERENCE</TD>
						<TD>M.F</TD>
						<TD>UNITSforDay</TD>
						<TD>UNITSforMonth</TD>
						<TD>Remarks</TD>
					</TR>
					<TR>
						<TD >C0</TD>
						<TD>
							<asp:TextBox id="txtC0_initial" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD >
							<asp:TextBox id="txtC0_final" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox>
							<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtC0_final"></asp:RequiredFieldValidator></TD>
						<TD>
							<asp:Label id="lblC0diff" runat="server"></asp:Label>&nbsp;</TD>
						<TD>
							<asp:dropdownlist id="ddlMFC0" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></TD>
						<TD>
							<asp:Label id="lblC0Day" runat="server"></asp:Label>&nbsp;</TD>
						<TD>
							<asp:Label id="lblC0Month" runat="server"></asp:Label>&nbsp;</TD>
						<TD>
							<asp:TextBox id="txtRemarksC0" CssClass="form-control" runat="server"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD >C1</TD>
						<TD>
							<asp:TextBox id="txtC1_initial" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD >
							<asp:TextBox id="txtC1_final" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox>
							<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtC1_final"></asp:RequiredFieldValidator></TD>
						<TD>
							<asp:Label id="lblC1diff" runat="server"></asp:Label>&nbsp;</TD>
						<TD>
							<asp:dropdownlist id="ddlMFC1" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></TD>
						<TD>
							<asp:Label id="lblC1Day" runat="server"></asp:Label>&nbsp;</TD>
						<TD>
							<asp:Label id="lblC1Month" runat="server"></asp:Label>&nbsp;</TD>
						<TD>
							<asp:TextBox id="txtRemarksC1" CssClass="form-control" runat="server"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD >C2</TD>
						<TD>
							<asp:TextBox id="txtC2_initial" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD >
							<asp:TextBox id="txtC2_final" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox>
							<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtC2_final"></asp:RequiredFieldValidator></TD>
						<TD>
							<asp:Label id="lblC2diff" runat="server"></asp:Label>&nbsp;</TD>
						<TD>
							<asp:dropdownlist id="ddlMFC2" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></TD>
						<TD>
							<asp:Label id="lblC2Day" runat="server"></asp:Label>&nbsp;</TD>
						<TD>
							<asp:Label id="lblC2Month" runat="server"></asp:Label>&nbsp;</TD>
						<TD>
							<asp:TextBox id="txtRemarksC2" CssClass="form-control" runat="server"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD  colSpan="8">
							<asp:Button id="btnSave" runat="server" CssClass="button button2" Text="Save"></asp:Button></TD>
					</TR>
				</TABLE>
				<asp:DataGrid id="DataGrid1" runat="server" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<Columns>
						<asp:ButtonColumn Text="Delete" CommandName="Delete"></asp:ButtonColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
			</asp:panel>
                </div>

		</form></div>
         <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
