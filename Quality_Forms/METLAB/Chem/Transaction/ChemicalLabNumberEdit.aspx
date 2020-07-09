<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ChemicalLabNumberEdit.aspx.vb" Inherits="WebApplication2.ChemicalLabNumberEdit" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>ChemicalLabNumberEdit</title>
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
     <%--<link rel="stylesheet" href="../../../../StyleSheet1.css" />--%>
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
				<TABLE id="Table1" class="table">
					<TR>
						<TD colSpan="3"><FONT size="5">Lab Number Data Edit</FONT><hr class="prettyline" /></TD>
					</TR>
					<TR>
						<TD colSpan="3">
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></TD>
					</TR>
					<TR>
						<TD>LabNumber</TD>
						<TD>:</TD>
						<TD>
							<asp:DropDownList id="ddlLabNumber" runat="server" AutoPostBack="True" CssClass="form-control ll"></asp:DropDownList></TD>
					</TR>
					<TR>
						<TD colSpan="3">
							<asp:Label id="lblLabTestName" runat="server"></asp:Label></TD>
					</TR>
				</TABLE>
				<TABLE id="Table2" class="table">
					<TR>
						<TD>LoggedInBy</TD>
						<TD>:</TD>
						<TD>
							<asp:Label id="lblUser" runat="server"></asp:Label></TD>
						<TD>TestedBy</TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="txtTestedBy" runat="server" CssClass="form-control"></asp:TextBox>&nbsp;ExpectedDt 
							:
							<asp:textbox id="txtExpectedDt" runat="server"  CssClass="form-control"></asp:textbox></TD>
					</TR>
					<TR>
						<TD>IDNNumber</TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="txtNumber" runat="server" AutoPostBack="True"  CssClass="form-control"></asp:TextBox></TD>
						<TD>DBRNo</TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="txtDBR" runat="server"  CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>DumpNo</TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="txtSampleBatchNo" runat="server"  CssClass="form-control"></asp:TextBox></TD>
						<TD>SampleNo</TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="txtSampleNo" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>BatchNo</TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="txtBatchNo" runat="server"  CssClass="form-control"></asp:TextBox></TD>
						<TD>Supplier</TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="txtSupplier" runat="server"  CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>Lorry No</TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="txtLorry" runat="server"  CssClass="form-control"></asp:TextBox></TD>
						<TD>Ref</TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="txtReferenceNote" runat="server"  CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>Result</TD>
						<TD>:</TD>
						<TD>
							<asp:RadioButtonList id="rblResult" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rbl">
								<asp:ListItem Value="P" Selected="True">P</asp:ListItem>
								<asp:ListItem Value="R">R</asp:ListItem>
							</asp:RadioButtonList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:CheckBox id="chkPOP" runat="server" Text="POP"></asp:CheckBox></TD>
						<TD>ResultDate</TD>
						<TD>:</TD>
						<TD>
							<asp:textbox id="txtTestedDate" runat="server" AutoPostBack="True"  CssClass="form-control"></asp:textbox></TD>
					</TR>
					<TR>
						<TD>Remarks</TD>
						<TD>:</TD>
						<TD colSpan="4">
							<asp:TextBox id="txtremarks" runat="server"  CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD align="middle" colSpan="6">
							<asp:Button id="btnUpdate" runat="server" Text="Update" CssClass="button button2"></asp:Button></TD>
					</TR>
				</TABLE>
			</asp:Panel>
                </div></div></form>
            </div>
         <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
