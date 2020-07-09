<%@ Page Language="vb" AutoEventWireup="false" Codebehind="BreakDownMemo.aspx.vb" Inherits="WebApplication2.BreakDownMemo" Culture="en-GB" uiCulture="en-GB" %>
<!DOCTYPE HTML >
<HTML>
	<HEAD runat="server">
		<title>BreakDownMemo</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR"/>
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
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
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home "style="font-size:30px;" ></i>
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
    
                  <%--<h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
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
				<TABLE id="Table1" class="table">
					<TR>
						<TD align="middle" colSpan="6">Break Down Memo <hr class="prettyline" /></TD>
					</TR>
					<TR>
						<TD colSpan="4">update&nbsp;UpTime after up in Edit mode.</TD>
						<TD align="right">Mode :</TD>
						<TD>
							<asp:label id="lblMode" runat="server" ForeColor="white"></asp:label></TD>
					</TR>
					<TR>
						<TD colSpan="6">
							<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></TD>
					</TR>
					<TR>
						<TD>Date Of Input</TD>
						<TD>:</TD>
						<TD>
							<asp:textbox id="txtDate" runat="server" class="form-control" MaxLength="10" AutoPostBack="True"></asp:textbox>
							<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" Display="Dynamic" ErrorMessage="*" ControlToValidate="txtDate"></asp:requiredfieldvalidator></TD>
						<TD>Shift</TD>
						<TD>:</TD>
						<TD>
							<asp:radiobuttonlist id="rblShift" runat="server" CssClass="rbl" AutoPostBack="True" RepeatDirection="Horizontal" RepeatLayout="Flow">
								<asp:ListItem Value="A" Selected="True">A</asp:ListItem>
								<asp:ListItem Value="B">B</asp:ListItem>
								<asp:ListItem Value="C">C</asp:ListItem>
							</asp:radiobuttonlist></TD>
					</TR>
					<TR>
						<TD>Department</TD>
						<TD>:</TD>
						<TD>
							<asp:label id="lblDepartment_code" runat="server">M</asp:label></TD>
						<TD>Shop Code</TD>
						<TD>:</TD>
						<TD>
							<asp:radiobuttonlist id="rblShop" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rbl"></asp:radiobuttonlist></TD>
					</TR>
					<TR>
						<TD>Group</TD>
						<TD>:</TD>
						<TD>
							<asp:label id="lblGroupCode" runat="server"></asp:label></TD>
						<TD>Operator:</TD>
						<TD>:</TD>
						<TD>
							<asp:textbox id="txtOperator" runat="server" CssClass="form-control"></asp:textbox></TD>
					</TR>
					<TR>
						<TD>BreakdownMemoNo</TD>
						<TD>:</TD>
						<TD>
							<asp:label id="lblMemo" runat="server"></asp:label></TD>
						<TD>MemoSlipnumber</TD>
						<TD>:</TD>
						<TD>
							<asp:textbox id="txtMemoslip" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox>
							<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtMemoslip"></asp:RequiredFieldValidator></TD>
					</TR>
				</TABLE>
				<TABLE id="Table2" class="table">
					<TR>
						<TD>MachineCode :&nbsp;
							<asp:dropdownlist id="ddlMachineCodes" runat="server" AutoPostBack="True" CssClass="ll form-control"></asp:dropdownlist></TD>
					</TR>
				</TABLE>
				<asp:radiobuttonlist id="rblBDType" runat="server" CssClass="rbl" AutoPostBack="True" RepeatDirection="Horizontal"></asp:radiobuttonlist>
				<TABLE id="Table3" class="table">
					<TR>
						<TD vAlign="top" align="left">
							<asp:listbox id="lstBDCodes" runat="server" CssClass="ll"></asp:listbox></TD>
						<TD vAlign="top" align="middle">
							<TABLE id="Table5" >
                             
								<TR >
									<TD>Production affected</TD>
									<TD>:</TD>
									<TD>
										<asp:radiobuttonlist id="radYN" runat="server" CssClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow">
											<asp:ListItem Value="1">Yes</asp:ListItem>
											<asp:ListItem Value="0" Selected="True">No</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR >
									<TD>Start date (dd/mm/yy)</TD>
									<TD>:</TD>
									<TD>
										<asp:textbox id="txtFrom_date" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox></TD>
								</TR>
								<TR >
									<TD>time (hh:mm)</TD>
									<TD>:</TD>
									<TD>
										<asp:textbox id="txtFrom_time" runat="server" CssClass="form-control" MaxLength="5"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
				<TABLE id="Table4" class="table">
					<TR>
						<TD>Remarks</TD>
						<TD>:</TD>
						<TD>
							<asp:textbox id="txtRemarks" runat="server" CssClass="form-control" TextMode="MultiLine" Height="42px"></asp:textbox></TD>
					</TR>
					<TR>
						<TD></TD>
						<TD></TD>
						<TD>
							<asp:button id="btnSave" runat="server" CssClass="button button2" Font-Size="Smaller" Font-Names="Arial" BorderStyle="Groove" Text="Save"></asp:button>&nbsp;
							<asp:button id="btnClear" runat="server" CssClass="button button2" Font-Size="Smaller" Font-Names="Arial" BorderStyle="Groove" Text="Clear" CausesValidation="False"></asp:button>&nbsp;
							<asp:button id="btnExit" runat="server" CssClass="button button2" Font-Size="Smaller" Font-Names="Arial" BorderStyle="Groove" Text="Exit" CausesValidation="False"></asp:button></TD>
					</TR>
				</TABLE>
				<asp:DataGrid id="DataGrid1" runat="server" >
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
			</asp:panel>
                    </div></div></form>
             </div>
        <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
