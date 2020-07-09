<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ProductionHighlightsReport.aspx.vb" Inherits="WebApplication2.ProductionHighlightsReport" %>
<!DOCTYPE HTML>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>ProductionHighlightsReport</title>
		<link id="PCORepo" href="/wap.css" rel="stylesheet"/>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0"/>
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
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

<%--         <link rel="stylesheet" href="../../StyleSheet1.css" />--%>
        <script>
              function isNumber1(evt, element) {

                    var charCode = (evt.which) ? evt.which : event.keyCode

                      if (
                           (charCode != 45 ) && (charCode != 47 ) &&     // 
                           (charCode < 48 || charCode > 57))
                      return false;

                  return true;
            } 
        </script>	</head>

	<body>
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
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home "style="font-size:30px;"></i>
        </a></li>

       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out"style="font-size:30px;"></i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
          <img src="../../NewFolder1/CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="45"/>
        </a>
      </li>
     </ul>
      
  </div>
</nav>
<!--/.Navbar -->

         
         <div class="container">
              <div class="row">
                <div class="table-responsive">

		<form id="Form1" method="post" runat="server">
             <%--<h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
			<asp:Panel id="Panel1" runat="server">
				<TABLE id="Table3" class="table">
					<TR>
						<TD align="middle" colSpan="3"><h2>Production Highlights Reports</h2><hr class="prettyline" /></TD>
					</TR></TABLE>
					<TABLE class="table">
                        <TR>
						<TD align="left" colSpan="3">
							<asp:Label id="lblmessage" runat="server" ForeColor="Red"></asp:Label></TD>
					</TR>
					<TR>
						<TD>PHLfor
						</TD>
						<TD>
							<asp:DropDownList id="ddlPHLs" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:DropDownList></TD>
						<TD>
							<asp:TextBox id="txtDate" runat="server" AutoPostBack="True" CssClass="form-control" onkeypress="return isNumber1(event,this)" MaxLength="10" placeholder="dd/mm/yyyy"></asp:TextBox></TD>
					</TR>
				</TABLE>
				<TABLE id="Table2" class="table">
					<TR>
						<TD colSpan="3">New Production Highlights Report</TD>
					</TR>
					<TR>
						<TD align="right">Date</TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="txtPHLDate" runat="server" CssClass="form-control"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD align="middle" colSpan="3">
                            <asp:Button id="btnCWEA" CssClass="button button2" runat="server" Text="CWEA"></asp:Button>
							</TD>
					</TR>
					<TR>
						<TD align="middle" colSpan="3">
                            <asp:Button id="btnCWEW" CssClass="button button2" runat="server" Text="CWEW">
							</asp:Button></TD>
					</TR>
					<TR>
						<TD align="middle" colSpan="3">
                            <asp:Button id="btnMag" CssClass="button button2" runat="server" Text="Mag Inspectors"></asp:Button>
							</TD>
					</TR>
					<TR>
						<TD align="middle" colSpan="3">
                             <asp:Button id="Button1" CssClass="button button2" runat="server" Text="New PHL Report"></asp:Button>
                            
							</TD>
					</TR>
					<%--<TR>
						<TD align="middle" colSpan="3">
                           <asp:Button id="Button4" runat="server" CssClass="button button2" Text="Production at a Glance"></asp:Button>
							</TD>
					</TR>--%>
					<TR>
						<TD align="middle" colSpan="3">
                            <asp:Button id="Button6" runat="server" CssClass="button button2" Text="New  Production at Glance Report"></asp:Button>
							</TD>
					</TR>
					<%--<TR>
						<TD align="middle" colSpan="3">
                            <asp:Button id="Button5" runat="server" CssClass="button button2" Text="Generate Data for New  Production at Glance"></asp:Button>
							</TD>
					</TR>--%>
				</TABLE>
				<TABLE id="Table1">
					<%--<TR>
						<TD align="middle" colSpan="3">Axle Shop Rejection</TD>
					</TR>--%>
				<%--	<TR>
						<TD align="right">RejDate</TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="txtRejDate" runat="server" Width="83px"></asp:TextBox></TD>
					</TR>--%>
					<%--<TR>
						<TD align="middle" colSpan="3">
							<asp:Button id="Button2" runat="server" Text="Generate Axle Shop Rejection Data"></asp:Button></TD>
					</TR>--%>
					<%--<TR>
						<TD align="middle" colSpan="3">
							<asp:Button id="Button3" runat="server" Text="Show Rejection Report"></asp:Button></TD>
					</TR>--%>
				</TABLE>
				<TABLE id="Table4" style="WIDTH: 161px; HEIGHT: 74px" cellSpacing="1" cellPadding="1" width="161" bgColor="#ffccff" border="1">
					<%--<TR>
						<TD>FromDate</TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="txtFromDate" runat="server" Width="81px"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>ToDate</TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="txtToDate" runat="server" Width="78px"></asp:TextBox></TD>
					</TR>--%>
					<%--<TR>
						<TD colSpan="3">
							<asp:RadioButtonList id="rblPCO" runat="server" Width="249px" RepeatLayout="Flow">
								<asp:ListItem Value="1" Selected="True">WheelSet Inventory Stores</asp:ListItem>
							</asp:RadioButtonList></TD>
					</TR>--%>
					<%--<TR>
						<TD align="middle" colSpan="3">
							<asp:Button id="btnPCOQry" runat="server" Text="Show Details"></asp:Button></TD>
					</TR>--%>
				</TABLE>
				<asp:DataGrid id="DataGrid1" runat="server" CssClass="table" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
			</asp:Panel>
		</form>
                     </div></div></div>
        <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</html>
