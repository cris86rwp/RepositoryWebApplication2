<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PrintLeavedetails.aspx.vb" Inherits="WebApplication2.PrintLeavedetails" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>PrintLeavedetails</title>
		<LINK href="/wap.css" rel="stylesheet">
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
         <meta charset="utf-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css"/>
  <script  src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js"></script
    <link type="text/css" rel="stylesheet" href="https://cdn.datatables.net/1.10.9/css/dataTables.bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="https://cdn.datatables.net/responsive/1.0.7/css/responsive.bootstrap.min.css" />
    <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.9/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/responsive/1.0.7/js/dataTables.responsive.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.9/js/dataTables.bootstrap.min.js"></script>
    <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>

           <link rel="stylesheet" href="../StyleSheet1.css" />
	</HEAD>
	<body >
         <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
  <a class="navbar-brand p-0" href="#"><img src="../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
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
    
<%--                  <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>--%>
                 <br />
      </div>
            <div class="row">
                <div class="table-responsive">
			<TABLE id="Table2" class="table">
                <tr>
                    <td  colspan="4">
<asp:Label id="Label2"  runat="server" >Leave Details</asp:Label><hr class="prettyline" />
                    </td>
                </tr>
			<tr>
                <td>
                    <asp:label id="lblMessage"  runat="server"  ForeColor="Red"></asp:label>
                </td>
			</tr>
                <tr>
                    <td>
                        <asp:Label id="Label1"  runat="server" >Employee Code</asp:Label>

                    </td>
                    <td>
 <asp:TextBox id="txtEmployee_code"  runat="server" readonly="true" AutoPostBack="True" CssClass="form-control" Width="150px"></asp:TextBox>
                    </td>
               
                <td>

                
			<asp:Label id="Label3"  runat="server" >:</asp:Label>
			</td>
			
			<td>
           <asp:Label id="lblEmployee_name"  runat="server" ></asp:Label>
			</td>
			
                     </tr>
                <tr>
                    <td colspan="3">
                   <asp:button id="cmdReport"  runat="server"  Text="Report" CssClass="button button2"></asp:button><asp:button id="cmdClear"  runat="server"  Text=" Clear"  CausesValidation="False" CssClass="button button2"></asp:button>
                   <%--<asp:button id="cmdExit"  runat="server" Text="Exit"  CausesValidation="False" CssClass="button button2"></asp:button>  </td>--%>
                   
                </tr>
			
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
								<asp:BoundColumn DataField="application_type" ReadOnly="True" HeaderText="Application Type"></asp:BoundColumn>
								<asp:BoundColumn DataField="LEAVECODE" HeaderText="Leave Code"></asp:BoundColumn>
								<asp:BoundColumn DataField="from_date" HeaderText="From Date"></asp:BoundColumn>
								<asp:BoundColumn DataField="to_date" HeaderText="To Date"></asp:BoundColumn>
								<asp:BoundColumn DataField="l_convert" HeaderText="Commute"></asp:BoundColumn>
								<asp:BoundColumn DataField="number_of_days" HeaderText="Total Days"></asp:BoundColumn>
								<asp:BoundColumn DataField="reason" HeaderText="Reason"></asp:BoundColumn>
								<asp:BoundColumn DataField="l_confirm" HeaderText="Confirmation"></asp:BoundColumn>
								<asp:BoundColumn DataField="outstation_or_hq" HeaderText="Outstation/Headquarters"></asp:BoundColumn>
                                </Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
			</Table>
		</TABLE></div></div>
                <div>
                    <style type="text/css">
@media print {
    #printbtn {
        display :  none;
    }
}
</style>
<input id ="printbtn" style="margin-left:300px;height:50px;width:150px;color:black"type="button" value="Print this page" onclick="window.print();" >
        </div>
             
                   
                </form></div>
        <div class="card-footer" style="text-align:right; position:fixed; width:100%; left:0; bottom:0;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
