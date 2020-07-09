<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Offload.aspx.vb" Inherits="WebApplication2.Offload"%>
<!DOCTYPE HTML >
<HTML>
	<HEAD runat="server">
		<title>Offload</title>
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
       <%--<link rel="stylesheet" href="../../StyleSheet1.css" />--%>
	</HEAD>
	<body >
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
<!--/.Navbar -->

        <div class="container">
		<form id="Form1" method="post" runat="server">
             <div class="row">
    
           <%--       <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
      </div>
            <div class="row">
                <div class="table-responsive">
			<asp:panel id="Panel1" runat="server">
				<TABLE id="Table1" class="table" ></TABLE>
				
							<TABLE id="Table4" class="table">
								<TR>
									<TD colSpan="9"> <FONT size="5">Hub Cut Details</FONT><hr class="prettyline" /></TD>
								</TR>
								<TR>
									<TD colSpan="9">
										<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></TD>
								</TR>
								<TR>
									<TD colSpan="9">
										<asp:RadioButtonList id="rblType" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" class="rbl" AutoPostBack="True">
											<asp:ListItem Value="0" Selected="True">Hub Cut Details</asp:ListItem>
											<asp:ListItem Value="2">Offload</asp:ListItem>
										</asp:RadioButtonList></TD>
								</TR>
								<TR>
									<TD>HeatNo</TD>
									<TD>
										<asp:TextBox id="txtHeatNo" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox></TD>
									<TD>Date</TD>
									<TD>:</TD>
									<TD colSpan="2">
										<asp:TextBox id="txtDate" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox></TD>
									<TD>Shift</TD>
									<TD>:</TD>
									<TD colSpan="3">
										<asp:RadioButtonList id="rblShift" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl" AutoPostBack="True">
											<asp:ListItem Value="A" Selected="True">A</asp:ListItem>
											<asp:ListItem Value="B">B</asp:ListItem>
											<asp:ListItem Value="C">C</asp:ListItem>
										</asp:RadioButtonList></TD>
								</TR>
							</TABLE>
							<TABLE id="Table2" class="table">
								<TR>
									<TD>
										<asp:RadioButtonList id="rblMcnList" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl" AutoPostBack="True"></asp:RadioButtonList></TD>
								</TR>
								<TR>
									<TD>
										<asp:RadioButtonList id="rblOffloadCode" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl" AutoPostBack="True"></asp:RadioButtonList></TD>
								</TR>
							</TABLE>
							<TABLE id="Table3" class="table">
								<TR>
									<TD align="left">ProcessedWithHeatNo:
										<asp:TextBox id="txtProcessed" runat="server" CssClass="form-control"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD align="middle">
										<asp:Button id="btnSave" runat="server" Text="Save" CssClass="button button2"></asp:Button>
										<asp:Label id="lblWheelNo" runat="server" Visible="False"></asp:Label></TD>
								</TR>
							</TABLE>
							<asp:DataGrid id="dgData" runat="server" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4" CssClass="table">
								<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
								<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
								<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
								<Columns>
									<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
									<asp:ButtonColumn Text="Delete" CommandName="Delete"></asp:ButtonColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
							</asp:DataGrid>
						
							<asp:datagrid id="dgWheels" runat="server" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4" AutoGenerateColumns="False" CssClass="table">
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="Select">
										<ItemTemplate>
											<asp:CheckBox id="chkSelected" runat="server"></asp:CheckBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="Heat" ReadOnly="True" HeaderText="Heat"></asp:BoundColumn>
									<asp:BoundColumn DataField="Whl" ReadOnly="True" HeaderText="Whl">
										<ItemStyle Font-Bold="True" ForeColor="#FF3300"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PO" ReadOnly="True" HeaderText="PO"></asp:BoundColumn>
									<asp:BoundColumn DataField="Sts" ReadOnly="True" HeaderText="Sts"></asp:BoundColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
							</asp:datagrid>
					
			</asp:panel></div></div></form></div>
         <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
