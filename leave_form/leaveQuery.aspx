<%@ Page Language="vb" AutoEventWireup="false" Codebehind="leaveQuery.aspx.vb" Inherits="WebApplication2.leaveQuery" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>leaveQuery</title>
		<link href="/wap.css" rel="stylesheet">
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
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

          <link rel="stylesheet"  href="../StyleSheet1.css"/>
	</HEAD>
	<body >
         <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
  <a class="navbar-brand p-0" href="#"><img src=" ../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
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
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../wapframesetpp.aspx" >
          <i class="fab glyphicon glyphicon-home "></i>
        </a></li>
       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}"  href="../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out"></i>
        </a></li>
           <li class="nav-item ">
        <a class="nav-link p-0" href="#">
          <img src="../NewFolder1/CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="45"/>
        </a>
      </li>
     </ul>
      
  </div>
</nav>
         <div class="container ">

		<form id="Form1" method="post" runat="server">
             <div class="row">
    
                  <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="200px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />
      </div>
            <div class="row">
                <div class="table-responsive">
			<TABLE id="Table1" class="table" >
				<TR>
					<TD align="middle" colSpan="3"><FONT color="blue">Leave Details Query</FONT><hr class="prettyline" /></TD>
				</TR>
				<TR>
					<TD colSpan="3">
						<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></TD>
				</TR>
				<TR>
					<TD >Employee Code</TD>
					<TD >:</TD>
					<TD>
						<asp:TextBox id="txtEmployeeCode" runat="server" MaxLength="20" AutoPostBack="True" CssClass="form-control" Width="200px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:Label id="lblName" runat="server"  ForeColor="#0000C0"></asp:Label>
						<asp:Label id="txtDesignation" runat="server" ForeColor="#0000C0"></asp:Label></TD>
				</TR>
				<TR>
					<TD >Joining Date</TD>
					<TD >:</TD>
					<TD>
						<asp:TextBox id="txtjoiningDate" runat="server" ReadOnly="True" BorderStyle="Groove" CssClass="form-control"  Width="200px"></asp:TextBox></TD>
				</TR>
			</TABLE>
                    </div></div>
                     <div class="row">
                <div class="table-responsive">
			<TABLE id="Table2" class="table" >
				<TR>
					<TD vAlign="top" align="left" width="611" style="WIDTH: 611px">
						<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderStyle="None" BorderColor="#DEBA84" CssClass="table">
							<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#738A9C"></SelectedItemStyle>
							<EditItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></EditItemStyle>
							<ItemStyle HorizontalAlign="Center" ForeColor="#8C4510" BackColor="#FFF7E7"></ItemStyle>
							<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" BackColor="#A55129"></HeaderStyle>
							<FooterStyle ForeColor="#8C4510" BackColor="#F7DFB5"></FooterStyle>
							<Columns>
								<asp:BoundColumn DataField="application_number" ReadOnly="True" HeaderText="Application-No."></asp:BoundColumn>
								<asp:BoundColumn DataField="description" ReadOnly="True" HeaderText="Leave Code"></asp:BoundColumn>
								<%--<asp:BoundColumn DataField="application_type" HeaderText="DB/Cr."></asp:BoundColumn>--%>
								<asp:BoundColumn DataField="from_date" HeaderText="From Date"></asp:BoundColumn>
								<asp:BoundColumn DataField="to_date" HeaderText="To Date"></asp:BoundColumn>
								<asp:BoundColumn DataField="number_of_days" HeaderText="Days"></asp:BoundColumn>
								<%--<asp:BoundColumn DataField="from_f_a_indicator" HeaderText="F_ind"></asp:BoundColumn>--%>
								<%--<asp:BoundColumn DataField="to_f_a_indicator" HeaderText="A_ind"></asp:BoundColumn>--%>
								<%--<asp:BoundColumn DataField="Office_order_number" HeaderText="Office order Number"></asp:BoundColumn>--%>
                                <asp:BoundColumn DataField="l_confirm" HeaderText="Status"></asp:BoundColumn>
                                <asp:BoundColumn DataField="applied_to" HeaderText="Applied_to empno"></asp:BoundColumn>
                                <asp:BoundColumn DataField="empname" HeaderText="Applied_to empname"></asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD></tr>
                <tr>
					<TD vAlign="top" align="center" width="50%">
						<asp:datagrid id="Datagrid2" runat="server" BorderStyle="None"  BackColor="#DEBA84" AutoGenerateColumns="False" BorderColor="#DEBA84" CssClass="table">
							<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#738A9C"></SelectedItemStyle>
							<EditItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></EditItemStyle>
							<ItemStyle HorizontalAlign="Center" ForeColor="#8C4510" BackColor="#FFF7E7"></ItemStyle>
							<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" BackColor="#A55129"></HeaderStyle>
							<FooterStyle ForeColor="#8C4510" BackColor="#F7DFB5"></FooterStyle>
							<Columns>
								<asp:BoundColumn DataField="leave_code" ReadOnly="True" HeaderText="Leave Type"></asp:BoundColumn>
								<asp:BoundColumn DataField="leave_availed" HeaderText="Availed"></asp:BoundColumn>
								<asp:BoundColumn DataField="balance" HeaderText="Balance"></asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
               
			</TABLE>
                     </div></div>
		</form></div>
         <div class="card-footer" style="text-align:right; position:fixed; width:100%; left:0; bottom:0;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
