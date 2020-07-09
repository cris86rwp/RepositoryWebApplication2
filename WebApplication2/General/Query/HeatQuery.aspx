<%@ Page Language="vb" AutoEventWireup="false" Codebehind="HeatQuery.aspx.vb" Inherits="WebApplication2.HeatQuery" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>Heat Details Query</title>
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
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../wapframeset.aspx" >
          <i class="fab glyphicon glyphicon-home "></i>
        </a></li>
       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}"  href="../../logon.aspx">
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
<asp:Label id="Label2"  runat="server" style="text-align: center" >Heat Details</asp:Label><hr class="prettyline" />
                    </td>
                </tr>
			<tr>
                <td>
                    <asp:label id="lblMessage"  runat="server"  ForeColor="Red"></asp:label>
                </td>
			</tr>
                <tr>
                    <td>
                        <asp:Label id="Label1"  runat="server" >From Date</asp:Label>

                    </td>
                    <td>
 <asp:TextBox id="txtFrmdt"  runat="server"   Width="150px"></asp:TextBox>
                    </td>
                         <td>
                        <asp:Label id="Label3"  runat="server" >To Date</asp:Label>

                    </td>
                    <td>
 <asp:TextBox id="txtTodt"  runat="server" Width="150px"></asp:TextBox>
                    </td>
                <td>

                
			
			
			
                     </tr>
                <tr>
                    <td colspan="3">
                   <asp:button id="cmdReport"  runat="server"  Text="Show" CssClass="button button2"></asp:button><asp:button id="cmdClear"  runat="server"  Text=" Clear"  CausesValidation="False" CssClass="button button2"></asp:button>
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
								<asp:BoundColumn DataField="date" ReadOnly="True" HeaderText="Date"></asp:BoundColumn>
								<asp:BoundColumn DataField="Heat" ReadOnly="True" HeaderText="Heat No"></asp:BoundColumn>
								<asp:BoundColumn DataField="wheel_cast" ReadOnly="True" HeaderText="Wheel Cast"></asp:BoundColumn>
								<asp:BoundColumn DataField="IT" ReadOnly="True" HeaderText="Int Temp"></asp:BoundColumn>
								<asp:BoundColumn DataField="FT" ReadOnly="True" HeaderText="Fin Temp"></asp:BoundColumn>
								<asp:BoundColumn DataField="TPT" ReadOnly="True" HeaderText="Tot Pour Time"></asp:BoundColumn>
								<asp:BoundColumn DataField="Sup" ReadOnly="True" HeaderText="Pour Inch"></asp:BoundColumn>
								<asp:BoundColumn DataField="LLT" ReadOnly="True" HeaderText="Ladle Lift Time"></asp:BoundColumn>
								<asp:BoundColumn DataField="TNo" ReadOnly="True" HeaderText="Tube No"></asp:BoundColumn>
								<asp:BoundColumn DataField="TL" ReadOnly="True" HeaderText="Tube Life"></asp:BoundColumn>
								<asp:BoundColumn DataField="Tap" ReadOnly="True" HeaderText="Tap End"></asp:BoundColumn>
								<asp:BoundColumn DataField="LNo" ReadOnly="True" HeaderText="Ladle No"></asp:BoundColumn>
                                <asp:BoundColumn DataField="LL" ReadOnly="True" HeaderText="Ladle Life"></asp:BoundColumn>
								<asp:BoundColumn DataField="TOut" ReadOnly="True" HeaderText="Tube Out Time"></asp:BoundColumn>
								<asp:BoundColumn DataField="RWt" ReadOnly="True" HeaderText="Riser Wt"></asp:BoundColumn>
								<asp:BoundColumn DataField="Remarks" ReadOnly="True" HeaderText="Remarks"></asp:BoundColumn>
								
								
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
&nbsp;</div>
             
                   
                </form></div>
        <div class="card-footer" style="text-align:right; position:fixed; width:100%; left:0; bottom:0;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
