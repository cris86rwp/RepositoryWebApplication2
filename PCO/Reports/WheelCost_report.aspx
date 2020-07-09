<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WheelCost_report.aspx.vb" Inherits="WebApplication2.WheelCost" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Wheel Manufacturing Cost</title>
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

   <%-- <link href="../../StyleSheet1.css" rel="../../stylesheet" />--%>

 
    <style type="text/css">
        .auto-style1 {
            font-size: large;
        }
    </style>

 
</head>
	<body bgColor="#b6dcf5" MS_POSITIONING="GridLayout">
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
     <div class="container">
            <div class="row">
                <div class="table-responsive">
		<form id="Form1" method="post" runat="server">
    <%--         <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
			<asp:Panel id="Panel1" style="Z-INDEX: 101; LEFT: 122px; POSITION: absolute; top: 28px; height: 95px; width: 431px;" runat="server">
				<TABLE id="Table1" style="WIDTH: 395px; HEIGHT: 121px" cellSpacing="1" cellPadding="1" width="395" border="0">
					<TR>
						<TD vAlign="center" align="middle" width="100%" colSpan="4"><b>&nbsp;&nbsp;&nbsp;
                            <br />
                            <br />
                            <br />
                            <br />
                            <span class="auto-style1">Costing Report Form<br />
                            <br />
                            </span></b></TD>
					</TR>
					<TR>
						<TD vAlign="center" align="middle" width="100%" colSpan="4"><b>Enter Year, From Month and To Month.</b></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 588px" vAlign="center" align="left" colSpan="4">
							<asp:Label id="lblerr" runat="server" ForeColor="Red"></asp:Label></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 152px">
                            <br />
                            <br />
                            <span class="auto-style1">Year</span><asp:textbox id="txtYear" runat="server" Width="137px" BorderStyle="Groove" CssClass="form-control"></asp:textbox>
							<asp:RequiredFieldValidator id="rfvld1" runat="server" ControlToValidate="txtYear" Display="Dynamic">*</asp:RequiredFieldValidator>
                            <br />
                        </TD>
						<TD style="WIDTH: 82px"></TD>
                        <caption>
                            &nbsp;&nbsp;
                            <tr>
                                <td class="auto-style1">From&nbsp;&nbsp;&nbsp;&nbsp; Month</td>
                                <td>
                                    <asp:TextBox ID="txtFrommonth" runat="server" BorderStyle="Groove" CssClass="form-control" Width="118px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvld2" runat="server" ControlToValidate="txtFrommonth" Display="Dynamic">*</asp:RequiredFieldValidator>
                                </td>
                                <caption>
                                    &nbsp;&nbsp;
                                    <tr>
                                        <td class="auto-style1">To&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Month</td>
                                        <td>
                                            <br />
                                            <asp:TextBox ID="txtTomonth" runat="server" BorderStyle="Groove" CssClass="form-control" Width="120px"></asp:TextBox>
                                            <br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTomonth" Display="Dynamic">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                </caption>
                            </tr>
                        </caption>
					</TR>
					<TR>
						<TD vAlign="center" align="middle" colSpan="4">
							<asp:button id="BtnShow" runat="server" Height="62px" Width="120px" Font-Size="Smaller" Font-Names="Arial" BorderStyle="Groove" Text="Show Report" CssClass="form-control"></asp:button>
                            <br />
                        </TD>
					</TR>
				</TABLE>
			</asp:Panel>
		</form>
	</div>
                </div>
            </div>
     <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
