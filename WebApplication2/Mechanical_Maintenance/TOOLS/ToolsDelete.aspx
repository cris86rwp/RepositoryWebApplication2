<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ToolsDelete.aspx.vb" Inherits="WebApplication2.ToolsDelete" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>ToolsDelete</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
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
       <%-- <link rel="stylesheet" href="../../StyleSheet1.css" />--%>
	    <style type="text/css">
            .auto-style1 {
                height: 38px;
            }
            .auto-style2 {
                height: 50px;
            }
        </style>
	</HEAD>
	<BODY MS_POSITIONING="GridLayout" bgColor="#ffcccc">
	<body bgColor="#99ccff" >
		  <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
  <a class="navbar-brand p-0" href="#"><img src="../../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
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
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home " style="font-size:30px;"></i>
        </a></li>
       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out" style="font-size:30px;"></i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
          <img src="../../NewFolder1/CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="45"/>
        </a>
      </li>
     </ul>
      
  </div>
</nav>
      
			<div class="container">
		<form id="Form2" method="post" runat="server">
             <div class="row">
    
                  <%--<h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" CssClass="form-control ll" OnSelectedIndexChanged="dd1_SelectedIndexChanged"  Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
      </div>
            <div class="table-responsive">
		
			<asp:panel id="Panel1" runat="server">
				<TABLE id="Table2" class="table">
		       <TR>
						<TD colSpan="3">Delete History Card No&nbsp;<hr class="prettyline" />
							<asp:label id="lblMode" runat="server" ForeColor="Blue" Font-Bold="True" Font-Names="Arial" Font-Size="Smaller" Width="63px"></asp:label></TD>
					</TR>			<TR>
						<TD colSpan="3">
							<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></TD>
					</TR>
					<TR>
						<TD>SelectHistoryCardNo</TD>
						<TD>:</TD>
						<TD>
							<asp:DropDownList id="ddlIns" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:DropDownList></TD>
					</TR>
	
					<TR>
						<TD>DeletedDate</TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="txtDeletedDate" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" Width="161px" ControlToValidate="txtDeletedDate" ErrorMessage="DeletedDateRequired"></asp:RequiredFieldValidator></TD>
					</TR>
					<TR>
						<TD>DeletedBy</TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="txtDeletedBy" CssClass="form-control" runat="server"></asp:TextBox></TD>
						<TD>
							<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="txtDeletedBy" ErrorMessage="DeletedByRequired"></asp:RequiredFieldValidator></TD>
					</TR>
					<TR>
						<TD>Reasons</TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="txtReasons" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ControlToValidate="txtReasons" ErrorMessage="Reason Required"></asp:RequiredFieldValidator></TD>
					</TR>
					<TR>
						<TD>LetterNo</TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="txtLetterNo" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>&nbsp;</TD>
					</TR>
					<TR>
						<TD>Remarks</TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="txtRemarks" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>
							<asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" ControlToValidate="txtRemarks" ErrorMessage="Remarks Required"></asp:RequiredFieldValidator></TD>
					</TR>
					<TR>
						<TD align="middle" colSpan="4">
							<asp:Button id="btnDelete" runat="server" CssClass="button button2" Text="Delete from Master"></asp:Button></TD>
					</TR>
				</TABLE>
			</asp:panel></form>
                 <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
