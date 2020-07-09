<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MRShiftWiseReport.aspx.vb" Inherits="WebApplication2.MRShiftWiseReport" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MR Daily Report</title>
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

   <%-- <link href="../../StyleSheet1.css" rel="stylesheet" />--%>
</head>

	<body>
        <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark">
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

			<asp:Panel id="Panel1"  runat="server">
				<TABLE id="Table3" class="table">
					<TR>
						<TD>Mould Room Shift Position</TD>
					</TR>
				</TABLE>
				<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label>
				<TABLE id="Table1">
					<TR>
						<TD>Date : </TD>
						<TD>
							<asp:textbox id="txtDate" runat="server" Width="120px" BorderStyle="Groove" CssClass="form-control"></asp:textbox></TD>
					</TR>
					<TR>
						<TD>Shift : </TD>
						<TD>
							<asp:radiobuttonlist id="rblShift" runat="server" Width="98px" RepeatLayout="Flow" RepeatDirection="Horizontal">
								<asp:ListItem Value="A" Selected="True">A</asp:ListItem>
								<asp:ListItem Value="B">B</asp:ListItem>
								<asp:ListItem Value="C">C</asp:ListItem>
							</asp:radiobuttonlist></TD>
					</TR>
					<TR>
						<TD>
							<asp:Button id="btnGen" runat="server" Text="Generate Shift Wise Data" CssClass="btn btn-success" Style="margin-left:100px;"></asp:Button></TD>
					</TR>
					<TR>
						<TD>
							<TABLE id="Table2" class="table">
								<TR>
									<TD>FrHt</TD>
									<TD>
										<asp:TextBox id="txtFrHt" runat="server" CssClass="form-control"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD>ToHt</TD>
									<TD>
										<asp:TextBox id="txtToHt" runat="server" CssClass="form-control"></asp:TextBox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD>
							<asp:Button id="Button3" runat="server" Text="Generarte Heat Wise Data" CssClass="button button2"></asp:Button>
                            <br />
                        </TD>
					</TR>
               
                        <br />
                        <tr>
                            <td>
                                <asp:Button ID="btnShow" runat="server" CssClass="button button2" Text="Show Report Page 1" />
                                <br />
                            </td>
                        </tr>
                    
                            <br />
                            <tr>
                                <td>
                                    <asp:Button ID="Button4" runat="server" CssClass="button button2" Text="Show Heat Wise Data in Grid" />
                                    <br />
                                </td>
                            </tr>
                         
                                <br />
 
				</TABLE>
				<asp:DataGrid id="DataGrid1" runat="server" BorderStyle="None" BorderColor="#CC9966" BorderWidth="1px" BackColor="White" CellPadding="4">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
			</asp:Panel>
		</form>
                 	</div>
                </div>
            </div>
     <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
    </html>