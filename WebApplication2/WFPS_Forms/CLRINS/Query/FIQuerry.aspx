<%@ Page Language="vb" AutoEventWireup="false" Codebehind="FIQuerry.aspx.vb" Inherits="WebApplication2.FIQuerry" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>FIQuerry</title>
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

         <div class="container ">
            
		<form id="Form1" method="post" runat="server">
            <div class="row">
    
                  <%--<h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
      </div>
			<asp:panel id="Panel1"  runat="server">
                <%--style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px"--%>
				 <div class="row">
                <div class="table-responsive">
                <TABLE id="Table1" class="table" >
					<TR>
						<TD align="middle" colSpan="3"><FONT size="3">Final&nbsp;and WheelSet Inspection 
								Querries</FONT><hr class="prettyline" /></TD>
					</TR>
					<TR>
						<TD colSpan="3">
							<asp:Label id="lblMessage" runat="server" ForeColor="Red" Font-Size="Medium" Font-Bold="True"></asp:Label></TD>
					</TR>
					<TR>
						<TD>From Date</TD>
						<TD colSpan="2">
							<asp:TextBox id="txtFromDate" runat="server" CssClass="form-control" onkeypress="return isNumber1(event,this)" MaxLength="10"></asp:TextBox>
							<asp:RequiredFieldValidator id="rfvFrDate" runat="server" Display="Dynamic" ControlToValidate="txtFromDate" ErrorMessage="*"></asp:RequiredFieldValidator>
                           
						</TD>
					</TR>
					<TR>
						<TD>To Date</TD>
						<TD colSpan="2">
							<asp:TextBox id="txtToDate" runat="server" CssClass="form-control" onkeypress="return isNumber1(event,this)" MaxLength="10"></asp:TextBox>
							<asp:RequiredFieldValidator id="rfvToDt" runat="server" Display="Dynamic" ControlToValidate="txtToDate" ErrorMessage="*"></asp:RequiredFieldValidator></TD>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtToDate" ControlToValidate="txtFromDate" ErrorMessage="To Date should be greator than FromDate" ForeColor="Red" Operator="LessThanEqual"></asp:CompareValidator>
					</TR>
					<TR>
						<TD vAlign="top" align="middle" colSpan="3">
							<asp:RadioButtonList id="rblShift" runat="server"  AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl">
								<asp:ListItem Value="A">A</asp:ListItem>
								<asp:ListItem Value="B">B</asp:ListItem>
								<asp:ListItem Value="C">C</asp:ListItem>
								<asp:ListItem Value="All" Selected="True">All</asp:ListItem>
							</asp:RadioButtonList></TD>
					</TR>
					<TR>
                        <td>For</td>
                        <td><asp:TextBox id="txtGrind" runat="server"  MaxLength="3" CssClass="form-control"></asp:TextBox></td>
                        <td>GrindSts</td>
                       
					</TR>
					<TR>
						<TD align="left" colSpan="3">
							<asp:RadioButtonList id="rblType" runat="server" CssClass="rbl"  RepeatLayout="Flow" RepeatDirection="Horizontal">
								<asp:ListItem Value="1" Selected="True">Stocked Wheels not Tested in Final Inspection</asp:ListItem>
								<asp:ListItem Value="2">FI Passed</asp:ListItem>
								<asp:ListItem Value="3">FI Rejected</asp:ListItem>
								<asp:ListItem Value="4">FI ReWork</asp:ListItem>
								<asp:ListItem Value="5">Unbore Detail</asp:ListItem>
								<asp:ListItem Value="6">Unbore Summary</asp:ListItem>
								<asp:ListItem Value="7">QCI ReClaimed Wheels </asp:ListItem>
								<%--<asp:ListItem Value="8">DateWise WheelSet Inspection Summary</asp:ListItem>--%>
								<asp:ListItem Value="9">BatchWise Inspection Summary</asp:ListItem>
								<asp:ListItem Value="10">Rejected Batches</asp:ListItem>
								<asp:ListItem Value="11">Hold Batches</asp:ListItem>
								<%--<asp:ListItem Value="12">Axle Not Identified</asp:ListItem>--%>
								<asp:ListItem Value="13">Wheel Not Identified</asp:ListItem>
								<%--<asp:ListItem Value="14">Set Not Identified</asp:ListItem>--%>
								<asp:ListItem Value="15">Closure Results</asp:ListItem>
								<asp:ListItem Value="16">Sieve Analysis</asp:ListItem>
								<asp:ListItem Value="17">DespatchConsigneeWiseDetails</asp:ListItem>
								<asp:ListItem Value="18">DespatchConsigneeWiseSummary</asp:ListItem>
								<asp:ListItem Value="19">DespatchDateWiseDetails</asp:ListItem>
								<asp:ListItem Value="20">DespatchDateWiseSummary</asp:ListItem>
								<asp:ListItem Value="21">DuplicateWheelDespatch</asp:ListItem>
								<asp:ListItem Value="22">PassedNotDespatched</asp:ListItem>
								<asp:ListItem Value="23">Yard Wheels</asp:ListItem>
								<asp:ListItem Value="24">Not Checked Wheels at WheelLoading</asp:ListItem>
								<asp:ListItem Value="25">MCN Wheels Details</asp:ListItem>
								<asp:ListItem Value="26">MCN Wheels Summary</asp:ListItem>
					<%--			<asp:ListItem Value="27">Pressed and not despatched</asp:ListItem>--%>
						<%--		<asp:ListItem Value="28">Passed and not despatched as loose wheel</asp:ListItem>--%>
							</asp:RadioButtonList></TD>
					</TR>
					<TR>
						<TD align="middle" colSpan="3">
							<asp:Button id="btnShow" runat="server" Text="Show data in Grid" CssClass="button button2"></asp:Button></TD>
					</TR>
					<TR>
						<TD align="middle" colSpan="3">
							<asp:Button id="Button1" runat="server" Text="Export to Excel" CssClass="button button2"></asp:Button></TD>
					</TR>
					<TR>
						<TD align="middle" colSpan="3"></TD>
					</TR>
				</TABLE>
				<asp:DataGrid id="DataGrid1" runat="server" Width="369px" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4" CssClass="table">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
		</div></div>	</asp:panel></form></div>
        <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
