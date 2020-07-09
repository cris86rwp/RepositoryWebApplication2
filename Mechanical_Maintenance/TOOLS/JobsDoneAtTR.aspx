<%@ Page Language="vb" AutoEventWireup="false" Codebehind="JobsDoneAtTR.aspx.vb" Inherits="WebApplication2.JobsDoneAtTR" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>JobsDoneAtTR</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
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
      <%-- <link rel="stylesheet" href="../../StyleSheet1.css" />--%>
	    <style type="text/css">
            .auto-style1 {
                height: 38px;
            }
            .auto-style2 {
                height: 50px;
            }
        </style>
	</HEAD>
	<BODY MS_POSITIONING="GridLayout" bgColor="#ffcccc">
	<body bgColor="#99ccff" >
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
		<form id="Form2" method="post" runat="server">
             <div class="row">
    
                  <%--<h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" CssClass="form-control ll" OnSelectedIndexChanged="dd1_SelectedIndexChanged"  Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
      </div>
            </div>
            <div class="table-responsive">
			<asp:panel id="Panel1" runat="server">
				<TABLE id="Table4" class="table">
							<TR>
						<TD colSpan="3">InterShop Maintenance&nbsp;Jobs&nbsp;Mfg./Rectified&nbsp;At ToolRoom&nbsp;<hr class="prettyline" />
							<asp:label id="Label1" runat="server" ForeColor="Blue" Font-Bold="True" Font-Names="Arial" Font-Size="Smaller" Width="63px"></asp:label></TD>
					</TR>      

                  
					<TR>
						<TD>
							<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></TD>
					</TR>
					<TR>
						<TD>Received Date :
							<asp:TextBox id="txtReceivedDate" CssClass="form-control" runat="server" AutoPostBack="True"></asp:TextBox></TD>
					</TR>
				</TABLE>
				<TABLE id="Table2" class="table">
					<TR>
						<TD>
							<asp:RadioButtonList id="rblShop" runat="server" CssClass="rbl" AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal"></asp:RadioButtonList></TD>
					</TR>
					<TR>
						<TD>( Be careful while entering WONo . It cannot be be changed ! If Changed another 
							record will be created .&nbsp;)</TD>
					</TR>
				</TABLE>
				<TABLE id="Table3" class="table">
					<TR>
						<TD>WONo</TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="txtWONo" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox></TD>
						<TD>WODate</TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="txtWODate" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>Description ( Do Not Press 'Enter' key to move to next line )</TD>
						<TD>:</TD>
						<TD colSpan="4">
							<asp:TextBox id="txtWODesc" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>WOQty</TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="txtWOQty" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>AttendedBy</TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="txtAttendedBy" CssClass="form-control" runat="server"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>HoursTaken</TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="txtHourTaken" runat="server" CssClass="form-control"></asp:TextBox></TD>
						<TD>Status</TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="txtStatus" CssClass="form-control" runat="server"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>HandedOverTo</TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="txtHandedOverTo" CssClass="form-control" runat="server"></asp:TextBox></TD>
						<TD>Remarks</TD>
						<TD>:</TD>
						<TD>
							<asp:TextBox id="txtRemarks" CssClass="form-control" runat="server"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD align="middle" colSpan="6">
							<asp:Button id="btnSave" CssClass="button button2" runat="server" Text="Save"></asp:Button></TD>
					</TR>
				</TABLE>
				<asp:DataGrid id="DataGrid1" runat="server" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<Columns>
						<asp:ButtonColumn Text="Edit" CommandName="Select"></asp:ButtonColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
			</asp:panel></form>
                 <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
