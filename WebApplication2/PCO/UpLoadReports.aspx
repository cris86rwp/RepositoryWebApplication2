<%@ Page Language="vb" AutoEventWireup="false" Codebehind="UpLoadReports.aspx.vb" Inherits="WebApplication2.UpLoadReports" Culture="en-GB" uiCulture="en-GB" %>
<!DOCTYPE HTML>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>WebForm1</title>
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

        <%-- <link rel="stylesheet" href="../StyleSheet1.css" />--%>
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
		<form id="Form1" method="post" encType="multipart/form-data" runat="server">
            <%-- <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
			<TABLE id="Table1" class="table">
				<TR>
					<TD align="middle" colSpan="3"><h2>Uploading Cyrstal 
								Report Offline Files to Network</h2><hr class="prettyline" /></TD>
				</TR>
				<TR>
					<TD align="right" colSpan="3">Emp.Code:
						<asp:label id="lblEmployee" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD>Report Details</TD>
					<TD noWrap>Report For Date
						<asp:textbox id="txtDate" runat="server" CssClass="form-control"></asp:textbox></TD>
					<TD noWrap>Report Type
						<asp:dropdownlist id="ddlReportTypes" runat="server" CssClass="form-control ll" AutoPostBack="True">
							<asp:ListItem Value="Select" Selected="True">Select</asp:ListItem>
							<asp:ListItem Value="Pink">PinkSheet</asp:ListItem>
							<asp:ListItem Value="PHS">Production Highlights</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD noWrap>Offline File To Upload</TD>
					<TD noWrap colSpan="2">
                        <INPUT id="File1" type="file" size="75" name="File1" runat="server">
						<asp:checkbox id="chkAddStr" runat="server" AutoPostBack="True" Text="Product Type :" Visible="False"></asp:checkbox><asp:textbox id="txtAddToFileName" runat="server" Width="100px" AutoPostBack="True" Visible="False"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="middle"><asp:checkbox id="chkHelp" runat="server" Width="96px" AutoPostBack="True" Text="Show Help"></asp:checkbox></TD>
					<TD align="middle" colSpan="3">
                        <input id="SubmitFile1" type="submit" value="Upload" name="SubmitFile1" runat="server">
						<asp:label id="lblMessage" runat="server" Width="240px"></asp:label></TD>
				</TR>
				<TR>
					<TD align="middle" colSpan="3"><asp:panel id="Panel1" runat="server" Width="917px">
							<TABLE id="Table2" class="table">
								<TR>
									<TD>1. Generate Report using Link provided in your login.</TD>
								</TR>
								<TR>
									<TD>2. Export the report to a shared&nbsp;folder (preferrably name that folder as 
										"Shared" and follow uniform naming pattern&nbsp;)</TD>
								</TR>
								<TR>
									<TD>3. Check the contents of the report and date of the report to your 
										satisfaction.</TD>
								</TR>
								<TR>
									<TD>4. 0 Upload the Offline copy to server using this program.</TD>
								</TR>
								<TR>
									<TD>4.1 Input Date in DD/MM/YYYY format for which you have offline copy</TD>
								</TR>
								<TR>
									<TD>4.2. Select Report Type from drop down list.</TD>
								</TR>
								<TR>
									<TD>4.3 Type name of the exported file with path or use "Browse" button to locate 
										that file and select it.</TD>
								</TR>
								<TR>
									<TD>4.4 To Upload Product-wise Pink Sheets, Click "Add to File Name :" and give 
										Wheel Type in the adjoining text box</TD>
								</TR>
								<TR>
									<TD>4.5 Click Upload button.&nbsp; The program displays message beside Upload 
										button itself. (Watch out!)</TD>
								</TR>
							</TABLE>
						</asp:panel></TD>
				</TR>
			</TABLE>
		</form>
                     </div></div></div>
        <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</html>
