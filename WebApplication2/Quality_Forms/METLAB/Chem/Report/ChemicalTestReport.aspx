<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ChemicalTestReport.aspx.vb" Inherits="WebApplication2.ChemicalTestReport" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Baking station</title>
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

   <%-- <link href="../../../../StyleSheet1.css" rel="stylesheet" />--%>

 
</head>
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
     <div class="container">
            <div class="row">
                <div class="table-responsive">

		<form id="Form1" method="post" runat="server">
           <%--  <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
			<asp:panel id="Panel1" runat="server">
				<TABLE id="Table1" class="table">
					<TR>
						<TD align="middle" colSpan="3">Test Report<hr class="prettyline" /></TD>
					</TR>
					<TR>
						<TD colSpan="3">
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="middle" colSpan="3">
							<asp:RadioButtonList id="rblGroup" runat="server" AutoPostBack="True" RepeatLayout="Flow" CssClass="rbl"></asp:RadioButtonList></TD>
					</TR>
					<TR>
						<TD>Lab Number</TD>
						<TD>:</TD>
						<TD>
							<asp:DropDownList id="ddlLabNumber" runat="server" CssClass="form-control ll"></asp:DropDownList></TD>
					</TR>
					<TR>
						<TD align="middle" colSpan="3">
							<asp:Button id="Button1" runat="server" Text="Show Report" CssClass="button button2" ></asp:Button></TD>
					</TR>
				</TABLE>
				<asp:Panel id="Panel3" runat="server" >
					<TABLE id="Table2" class="table">
						<TR>
							<TD><FONT size="5">Calcined Lime Sample Inspection Report</FONT><hr class="prettyline" /></TD>
						</TR>
						<TR>
							<TD>
								<asp:RadioButtonList id="rblDBRList" runat="server" AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl"></asp:RadioButtonList></TD>
						</TR>
					</TABLE>
					<asp:DataGrid id="DataGrid1" runat="server" BackColor="White" CssClass="table" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
						<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
						<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
						<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
						<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
						<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
					</asp:DataGrid>
					<TABLE id="Table3" class="table">
						<TR>
							<TD>Gross Weight :
								<asp:TextBox id="TextBox1" runat="server" CssClass="form-control"></asp:TextBox></TD>
						</TR>
						<TR>
							<TD align="middle">
								<asp:Button id="Button2" runat="server" Text="Show Sample Inspection Report" CssClass="button button2">  </asp:Button></TD>
						</TR>
					</TABLE>
				</asp:Panel>
				<TABLE id="Table6" class="table"></TABLE>
					
							<asp:Panel id="Panel2" runat="server">
								<TABLE id="Table4" class="table">
									<TR>
										<TD><FONT size="5">Calcined Lime Sampling Lable</FONT><hr class="prettyline" /></TD>
									</TR>
								</TABLE>
								<TABLE id="Table5" class="table">
									<TR>
										<TD>DBR No List ( Choose One Or More than One using 'Ctrl' button on key-board )</TD>
										<TD vAlign="top" align="left">
											<asp:ListBox id="lsbDBR" runat="server" Width="103px" SelectionMode="Multiple" CssClass="ll"></asp:ListBox></TD>
									</TR>
									<TR>
										<TD align="middle" colSpan="2">
											<asp:Button id="Button3" runat="server" Text="Sampling Lable Report" CssClass="button button2"></asp:Button></TD>
									</TR>
								</TABLE>
							</asp:Panel>
				
				<TABLE id="Table7" class="table">
					<TR>
						<TD colSpan="3">SILICA SAND 45 AFS.&nbsp; Inspection Report</TD>
					</TR>
					<TR>
						<TD colSpan="3">
							<asp:RadioButtonList id="rblSand" runat="server" AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl"></asp:RadioButtonList></TD>
					</TR>
					<TR>
						<TD colSpan="3">
							<asp:DataGrid id="DataGrid2" runat="server" CssClass="table" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid></TD>
					</TR>
					<TR>
						<TD colSpan="3">
							<asp:Button id="Button4" runat="server" Text="Inspectio  Report for  SILICA SAND 45 AFS.  " CssClass="button button2"></asp:Button></TD>
					</TR>
				</TABLE>
			</asp:panel></form>
	 </div>
                </div>
            </div>
     <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>

