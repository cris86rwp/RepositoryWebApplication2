<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ToolReceipt.aspx.vb" Inherits="WebApplication2.ToolReceipt" smartNavigation="True" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>ToolReceipt</title>
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
    
                 <%-- <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" CssClass="form-control ll" OnSelectedIndexChanged="dd1_SelectedIndexChanged"  Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
      </div>
            <div class="table-responsive">
			<asp:panel id="Panel1" runat="server">
				<TABLE id="Table2" class="table">
		       <TR>
						<TD colSpan="3">Measiurable Tool Receipt&nbsp;<hr class="prettyline" />
							<asp:label id="lblMode" runat="server" ForeColor="Blue" Font-Bold="True" Font-Names="Arial" Font-Size="Smaller" Width="63px"></asp:label></TD>
					</TR>
                    <TR>
						<TD>
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></TD>
					</TR>
					<TR>
						<TD>
							<asp:RadioButtonList id="rblShop" runat="server" CssClass="rbl" RepeatLayout="Flow" RepeatDirection="Horizontal" AutoPostBack="True" Width="829px"></asp:RadioButtonList></TD>
					</TR>
				</TABLE>
				<TABLE id="Table3" class="table">
					<TR>
						<TD>InstrumentNumber
						</TD>
						<TD>:</TD>
						<TD>
							<asp:DropDownList id="ddlInstruments" CssClass="form-control ll" runat="server" AutoPostBack="True"></asp:DropDownList></TD>
						<TD>
							<asp:Label id="lblInstrumentType" runat="server"></asp:Label></TD>
					</TR>
				</TABLE>
				<asp:DataGrid id="DataGrid1" runat="server" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
				<asp:Panel id="pnlEdit" runat="server">
					<TABLE id="Table1" class="table">
						<TR>
							<TD colSpan="3">Instrument Selected For Edit</TD>
						</TR>
						<TR>
							<TD>InstrumentNo</TD>
							<TD>:</TD>
							<TD>
								<asp:textbox id="txtInstrumentNumber" runat="server" CssClass="form-control" Enabled="False"></asp:textbox></TD>
						</TR>
						<TR>
							<TD>ShopCode</TD>
							<TD>:</TD>
							<TD>
								<asp:textbox id="txtShop" runat="server" CssClass="form-control" Enabled="False"></asp:textbox></TD>
						</TR>
					</TABLE>
				</asp:Panel>
				<TABLE id="Table5" class="table">
					<TR>
						<TD>ReceiptDate</TD>
						<TD>
							<asp:textbox id="txtRecipt_date" runat="server" AutoPostBack="True" CssClass="form-control"></asp:textbox></TD>
						<TD>
							<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtRecipt_Date"></asp:requiredfieldvalidator>
							<asp:rangevalidator id="RangeValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtRecipt_Date" MinimumValue="1/1/1990" MaximumValue="1/1/9999" Type="Date"></asp:rangevalidator></TD>
						<TD>RecivedAndCheckedBy</TD>
						<TD>
							<asp:textbox id="txtRecived" runat="server" CssClass="form-control"></asp:textbox></TD>
						<TD>
							<asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtRecived"></asp:requiredfieldvalidator></TD>
						<TD>PlusErrorReceived</TD>
						<TD>
							<asp:textbox id="txtError_plus" runat="server" CssClass="form-control"></asp:textbox></TD>
						<TD>
							<asp:rangevalidator id="Rangevalidator5" runat="server" ErrorMessage="*" ControlToValidate="txtError_plus" MinimumValue="0" MaximumValue="99999.999" Type="Double"></asp:rangevalidator>
							<asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="txtError_plus"></asp:requiredfieldvalidator></TD>
					</TR>
					<TR>
						<TD>MinusErrorReceived</TD>
						<TD>
							<asp:textbox id="txtError_minus" runat="server" CssClass="form-control"></asp:textbox></TD>
						<TD>
							<asp:rangevalidator id="Rangevalidator4" runat="server" ErrorMessage="*" ControlToValidate="txtError_minus" MinimumValue="0" MaximumValue="99999.999" Type="Double"></asp:rangevalidator>
							<asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" ErrorMessage="*" ControlToValidate="txtError_minus"></asp:requiredfieldvalidator></TD>
						<TD>AccuracyReceived</TD>
						<TD>
							<asp:textbox id="txtAccuracy_received" runat="server" CssClass="form-control">0</asp:textbox></TD>
						<TD>
							<asp:rangevalidator id="Rangevalidator3" runat="server" ErrorMessage="*" ControlToValidate="txtAccuracy_received" MinimumValue="0" MaximumValue="99999.999" Type="Double"></asp:rangevalidator>
							<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" ErrorMessage="*" ControlToValidate="txtAccuracy_received"></asp:requiredfieldvalidator></TD>
						<TD>Discripency</TD>
						<TD>
							<asp:textbox id="txtDiscripency" runat="server" CssClass="form-control">0</asp:textbox></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD>Remarks</TD>
						<TD colSpan="8">
							<asp:textbox id="txtRemarks" runat="server" CssClass="form-control"></asp:textbox></TD>
					</TR>
					<TR>
						<TD>
							<asp:label id="lblreceipt" runat="server" Width="63px" Visible="False"></asp:label></TD>
						<TD>
							<asp:button id="btnSave" runat="server" CssClass="button button2" BorderStyle="Groove" Text="Save" Font-Size="Smaller" Font-Names="Arial"></asp:button></TD>
						<TD></TD>
						<TD>
							<asp:button id="btnClear" runat="server"  BorderStyle="Groove" CssClass="button button2" Text="Clear" Font-Size="Smaller" Font-Names="Arial" CausesValidation="False"></asp:button></TD>
						<TD>
							<asp:button id="btnExit" runat="server" CssClass="button button2" BorderStyle="Groove" Text="Exit" Font-Size="Smaller" Font-Names="Arial" CausesValidation="False"></asp:button></TD>
						<TD></TD>
						<TD></TD>
						<TD></TD>
						<TD></TD>
					</TR>
				</TABLE>
				<asp:DataGrid id="DataGrid2" runat="server" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4" AllowPaging="True" PageSize="5">
					<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<Columns>
						<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
				</asp:DataGrid>
			</asp:panel>&nbsp;</form>
                 <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
