<%@ Page Language="vb" AutoEventWireup="false" Codebehind="RMWheels.aspx.vb" Inherits="WebApplication2.RMWheels" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML runat="server">
	<HEAD runat="server">
		<title>RMWheels</title>
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
      <%-- <link rel="stylesheet" href="../../../StyleSheet1.css" />--%>

	</HEAD>

	<body >
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

        <script>
            function isNumber1(evt, element) {

                    var charCode = (evt.which) ? evt.which : event.keyCode

                      if (
                           (charCode != 45 ) && (charCode != 47 ) &&     // 
                           (charCode < 48 || charCode > 57))
                      return false;

                  return true;
            } 
        </script>
   <div class="container">
		<form id="Form1" method="post" runat="server">
              <div class="row">
    
                 <%-- <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
      </div>
            <div class="row"><div class="table-responsive">
			<asp:panel id="Panel2"  runat="server">
				<TABLE id="Table4" class="table"> </table>
					
							<TABLE id="Table3" class="table">
								<TR>
									<TD align="middle"><FONT size="5">RM Wheels Loading</FONT><hr class="prettyline" /></TD>
								</TR>
								<TR>
									<TD>
										<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></TD>
								</TR>
							</TABLE>
						
							<TABLE id="Table1" class="table">
								<TR>
									<TD>User Group</TD>
									<TD>:</TD>
									<TD>
										<asp:Label id="lblUserGroup" runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD>Date</TD>
									<TD>:</TD>
									<TD>
										<asp:TextBox id="txtLoadedDate" runat="server" CssClass="form-control" AutoPostBack="True" onkeypress="return isNumber1(event,this)" MaxLength="10"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD colSpan="3">
										<asp:RadioButtonList id="rblSentIn" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl">
											<%--<asp:ListItem Value="1" Selected="True">Dumper</asp:ListItem>
											<asp:ListItem Value="2">Dept Wagon</asp:ListItem>
											<asp:ListItem Value="3">Traffic Wagon</asp:ListItem>--%>
											<asp:ListItem Value="4">Flt</asp:ListItem>
										</asp:RadioButtonList></TD>
								</TR>
								<TR>
									<TD>Vehicle No</TD>
									<TD>:</TD>
									<TD>
										<asp:TextBox id="txtLoadedIn" runat="server" AutoPostBack="True" CssClass="form-control"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD>WheelNumber/HeatNumber</TD>
									<TD>:</TD>
									<TD>
										<asp:TextBox id="txtPart" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox>
										<asp:Label id="lblPcode" runat="server" Visible="False"></asp:Label></TD>
								</TR>
							</TABLE>
							<TABLE id="Table2" class="table">
								<TR>
									<TD vAlign="top" align="middle">
										<asp:Button id="btnSave" runat="server" Text="Save" CssClass="button button2"></asp:Button>&nbsp;&nbsp;&nbsp;
										<asp:Button id="Button1" runat="server" Text="Export to Excel Details" CssClass="button button2"></asp:Button></TD>
								</TR>
								<TR>
									<TD vAlign="top" align="middle">
										<asp:Button id="Button2" runat="server" Text="Export to Excel Wagons" CssClass="button button2"></asp:Button></TD>
								</TR>
								<TR>
									<TD vAlign="top" align="middle">
										<asp:Button id="Button3" runat="server" Text="Export to Excel WhlType" CssClass="button button2"></asp:Button></TD>
								</TR>
							</TABLE>
						
							<asp:DataGrid id="DataGrid1" runat="server" BorderColor="#CC9966" CssClass="table" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4">
								<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
								<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
								<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
								<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
							</asp:DataGrid>
							<asp:DataGrid id="DataGrid2" runat="server" ForeColor="Black" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" BackColor="White" CellPadding="3" GridLines="Vertical">
								<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#000099"></SelectedItemStyle>
								<AlternatingItemStyle BackColor="#CCCCCC"></AlternatingItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Black"></HeaderStyle>
								<FooterStyle BackColor="#CCCCCC"></FooterStyle>
								<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999"></PagerStyle>
							</asp:DataGrid>
				
				<asp:DataGrid id="dgSaveData" runat="server" CssClass="table" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4" AlternatingItemStyle-CssClass="table">
					<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
				</asp:DataGrid>
			</asp:panel></div></div></form></div>
        <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
