<%@ Page Language="vb" AutoEventWireup="false" Codebehind="TotalTestedWheel.aspx.vb" Inherits="WebApplication2.TotalTestedWheel" Culture="en-GB" uiCulture="en-GB" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mould New Reports</title>
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

    <%--<link href="../../../StyleSheet1.css" rel="stylesheet" />--%>

 
    <style type="text/css">
        .auto-style1 {
            width: 538px;
            height: 335px;
        }
    </style>

 
</head>

	<body bgColor="#99ccff" MS_POSITIONING="GridLayout">

     <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
  <a class="navbar-brand p-0" href="#"><img src="../../../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent-333"
    aria-controls="navbarSupportedContent-333" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>
  <div class="collapse navbar-collapse " id="navbarSupportedContent-333" >
      <ul class="navbar-nav ml-auto navbar-center">
         <li class="nav-item" style="font-weight: bold">
             <h1 style="color:white; font-size:30px; margin-left:430px; margin-top:5px">Rail Wheel Plant, Bela</h1> 
       
         </li>
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
         
        <img src="../../../NewFolder1/CRIS-Recruitment.jpg" height="45" style="border-radius:43%"/>
       </a>
      </li>
     </ul>
      
  </div>
</nav>
     <div class="container">
            <div class="row">
                <div class="table-responsive">
		<form id="Form1" method="post" runat="server">
          <%--   <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
			<asp:panel id="Panel1" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute" runat="server">
				<TABLE id="Table1" cellSpacing="1" cellPadding="1" border="1" class="auto-style1">
					<TR>
						<TD colSpan="3">Sample Register Of Total Tested Wheel On Date</TD>
					</TR>
					<TR>
						<TD colSpan="3">
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></TD>
					</TR>
					
					
					<%--<TR>
						<TD align="middle" colSpan="3">
							<asp:Button id="btnShow" runat="server" Text="Show Report" CssClass="form-control"></asp:Button></TD>
					</TR>--%>
                    
					<%--<TR>
						<TD>ToDate</TD>
						<TD colSpan="3">
							<asp:textbox id="txtToDt" runat="server" Width="120px" CssClass="form-control"></asp:textbox></TD>
					</TR>--%>
                   <%-- <TR>
						<TD align="middle" colSpan="3">
							<asp:Button id="btnDetails" runat="server" Text="Show Report" CssClass="form-control"></asp:Button></TD>
					</TR>--%>
                    <TR>
                       
						<TD>TestDate</TD>
						<TD colSpan="3">
							<asp:textbox id="Textbox1" runat="server" Width="120px" CssClass="form-control"></asp:textbox></TD>
					</TR>
					<TR>
						<TD>Shift</TD>
						<TD colSpan="3">
							<asp:textbox id="Textbox2" runat="server" Width="120px" CssClass="form-control"></asp:textbox></TD>
					</TR>
                    <TR>
						<TD align="middle" colSpan="3">
							<asp:Button id="Button1" runat="server" Text="Submit" CssClass="form-control"></asp:Button></TD>
					</TR>
                    
                   
				</TABLE>
				
			</asp:panel></form>
	 </div>
                </div>
            </div>
     <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
