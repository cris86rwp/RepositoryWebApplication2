<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ArcFurnaceReadings.aspx.vb" Inherits="WebApplication2.ArcFurnaceReadings" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>ArcFurnaceReadings</title>

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
			<TABLE id="Table2" class="table">
				<TR>
					<TD><h4>Arc Furnace Details( Add and Edit mode )</h4> 
						</TD>
				</TR>
				<TR>
					<TD  ><asp:label id="lblMessage" runat="server" ForeColor="Red" BackColor="LightSkyBlue" ></asp:label></TD>
				</TR>
				<TR>
					<TD >Date :</TD>
					<TD><asp:textbox id="txtCdate" runat="server" CssClass="form-control"  AutoPostBack="True"></asp:textbox></TD>
					
				</TR>
				<TR>
					<TD >As of 24:00 Hrs</TD>
					<%--<TD>Initial</TD>--%>
					<%--<TD>Final</TD>--%>
					<%--<TD>Difference</TD>--%>
					<%--<TD>M.F.</TD>--%>
					<%--<TD>Consumption</TD>--%>
					<%--<TD>Remarks</TD>--%>
				</TR>
				<TR>
					<TD >Arc furnace - A</TD>
					<TD>Initial</TD>
                    <TD><asp:textbox id="txtFurAInitial" runat="server" CssClass="form-control"  AutoPostBack="True"></asp:textbox></TD>
					<TD>Final</TD>
                    <TD><asp:textbox id="txtFurAFinal" runat="server" CssClass="form-control"  AutoPostBack="True"></asp:textbox></TD>
					
                    <TD>Difference</TD>
                    <TD><asp:label id="lblFurADiff" runat="server" ></asp:label></TD>
				
                    <TD>M.F.</TD>
                    <TD><asp:dropdownlist id="ddlMFarcA" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></TD>
					<TD>Consumption</TD>
                    <TD><asp:label id="lblArcAUnits" runat="server" ></asp:label>&nbsp;</TD>
					<TD>Remarks</TD>
                    <TD><asp:textbox id="txtarcARemark" CssClass="form-control" width="50px" runat="server"></asp:textbox></TD>
				</TR>
				<TR>
					<TD >Arc furnace - B</TD>
					<TD>Initial</TD>
                    <TD><asp:textbox id="txtFurBInitial" runat="server" CssClass="form-control"  AutoPostBack="True"></asp:textbox></TD>
					<TD>Final</TD>
                    <TD><asp:textbox id="txtFurBFinal" runat="server" CssClass="form-control"  AutoPostBack="True"></asp:textbox></TD>
					
                    <TD>Difference</TD>
                    <TD><asp:label id="lblFurBDiff" runat="server" ></asp:label></TD>
				
                    <TD>M.F.</TD>
                    <TD><asp:dropdownlist id="ddlMFarcB" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></TD>
					<TD>Consumption</TD>
                    <TD><asp:label id="lblArcBUnits" runat="server"></asp:label>&nbsp;</TD>
					<TD>Remarks</TD>
                    <TD><asp:textbox id="txtarcBRemark" CssClass="form-control" width="50px" runat="server"></asp:textbox></TD>
				</TR>
				<TR>
					<TD>Arc furnace - C</TD>
					<TD>Initial</TD>
                    <TD><asp:textbox id="txtFurCInitial" runat="server" CssClass="form-control"  AutoPostBack="True"></asp:textbox></TD>
					<TD>Final</TD>
                    <TD><asp:textbox id="txtFurCFinal" runat="server" CssClass="form-control"  AutoPostBack="True"></asp:textbox></TD>
					<TD>Difference</TD>
                    <TD><asp:label id="lblFurCDiff" runat="server" ></asp:label></TD>
				
                    <TD>M.F.</TD>
                    <TD><asp:dropdownlist id="ddlMFarcC" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist></TD>
					<TD>Consumption</TD>
                    <TD><asp:label id="lblArcCUnits" runat="server"></asp:label>&nbsp;</TD>
					<TD>Remarks</TD>
                    <TD><asp:textbox id="txtarcCRemark" CssClass="form-control" width="50px" runat="server"></asp:textbox></TD>
				</TR>
				<TR>
					<TD >&nbsp;</TD>
					<%--<TD><asp:button id="btnSave" runat="server" CssClass="button button2" Text="Save"></asp:button></TD>--%>
					
					<TD><asp:button id="btnSave" runat="server" CssClass="button button2" Text="Save"></asp:button></TD>
                    <TD>&nbsp;</TD>
					
				</TR>
			</TABLE>
	</div>	</form>
            </div>
         <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
