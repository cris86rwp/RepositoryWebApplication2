<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PowerFailure.aspx.vb" Inherits="WebApplication2.PowerFailure" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>PowerFailure</title>
		
                     
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

		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR"/>
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>

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
<!--/.Navbar -->
        <div class="container">

		<FORM id="Form1" method="post" runat="server">
              <div class="row">
    
                 <%-- <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" >
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
      </div>
            <div class="row table-responsive">
		
		
			<asp:Panel id="Panel1"  runat="server">
				<TABLE id="Table1" class="table">
					<TR>
						<TD  colSpan="2">Power Failure</TD>
					</TR>
					<TR>
						<TD  colSpan="2">
							<asp:label id="lblMode" runat="server" Font-Size="Smaller" Font-Names="Arial" Font-Bold="True" ForeColor="Blue" Width="80px"></asp:label></TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></TD>
					</TR>
					<TR>
						<TD colSpan="2">Date :
							<asp:textbox id="txtDate" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox>
							<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtDate"></asp:requiredfieldvalidator>
							<%--<asp:rangevalidator id="RangeValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtDate" Type="Date" MaximumValue="1/1/9999" MinimumValue="1/1/1900"></asp:rangevalidator>--%></TD>
					</TR>
				</TABLE>
				<TABLE id="Table4" class="table">
					<TR>
						<TD >Sl.No.</TD>
						<TD >Power Failure
						</TD>
						<TD >Time(HH:MM)</TD>
						<TD ></TD>
						<TD ></TD>
					</TR>
					<TR>
						<TD ></TD>
						<TD >From Time</TD>
						<TD >To Time&nbsp;</TD>
						<TD >Duration</TD>
						<TD ></TD>
					</TR>
					<TR>
						<TD >
							<asp:textbox id="txtSlNo" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox></TD>
						<TD >
							<asp:textbox id="txtFrom_time" runat="server" CssClass="form-control"></asp:textbox>
							<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtFrom_time"></asp:requiredfieldvalidator></TD>
						<TD >
							<asp:textbox id="txtTo_time" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox>
							<asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtTo_time"></asp:requiredfieldvalidator></TD>
						<TD >
							<asp:label id="lblDuration" runat="server"></asp:label></TD>
						<TD ></TD>
					</TR>
					<TR>
						<TD >Remarks</TD>
						<TD  colSpan="3">
							<asp:textbox id="txtRemarks" runat="server" CssClass="form-control"></asp:textbox></TD>
						<TD ></TD>
					</TR>
					<TR>
						<TD ></TD>
						<TD >Single Furnace</TD>
						<TD >RestrictionTime(HH:MM)</TD>
						<TD ></TD>
						<TD ></TD>
					</TR>
					<TR>
						<TD ></TD>
						<TD >From Time&nbsp;</TD>
						<TD >To Time&nbsp;</TD>
						<TD >&nbsp;Duration</TD>
						<TD ></TD>
					</TR>
					<TR>
						<TD ></TD>
						<TD >
							<asp:textbox id="txtSf_from_time" runat="server" CssClass="form-control">01/01/2000 00:00</asp:textbox>
							<asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="txtSf_from_time"></asp:requiredfieldvalidator></TD>
						<TD >
							<asp:textbox id="txtSf_to_time" runat="server" CssClass="form-control" AutoPostBack="True">01/01/2000 00:00</asp:textbox>
							<asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" ErrorMessage="*" ControlToValidate="txtSf_to_time"></asp:requiredfieldvalidator></TD>
						<TD >
							<asp:label id="lblSf_duration" runat="server"></asp:label></TD>
						<TD ></TD>
					</TR>
					<TR>
						<TD ></TD>
						<TD >Both Furnace
						</TD>
						<TD >RestrictionTime(HH:MM)</TD>
						<TD ></TD>
						<TD ></TD>
					</TR>
					<TR>
						<TD ></TD>
						<TD >From Time&nbsp;</TD>
						<TD >To Time&nbsp;</TD>
						<TD >Duration&nbsp;</TD>
						<TD >TotalRestriction</TD>
					</TR>
					<TR>
						<TD ></TD>
						<TD >
							<asp:textbox id="txtDf_from_time" runat="server" CssClass="form-control">01/01/2000 00:00</asp:textbox>
							<asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server" ErrorMessage="*" ControlToValidate="txtDf_from_time"></asp:requiredfieldvalidator></TD>
						<TD >
							<asp:textbox id="txtDf_to_time" runat="server" CssClass="form-control" AutoPostBack="True">01/01/2000 00:00</asp:textbox>
							<asp:requiredfieldvalidator id="RequiredFieldValidator7" runat="server" ErrorMessage="*" ControlToValidate="txtDf_to_time"></asp:requiredfieldvalidator></TD>
						<TD >
							<asp:label id="lblDf_duration" runat="server"></asp:label></TD>
						<TD >
							<asp:label id="lblTotalRes" runat="server" Width="90px"></asp:label></TD>
					</TR>
					<TR>
						<TD ></TD>
						<TD >
							<asp:button id="btnSubmit_Clicks" runat="server" Font-Size="Smaller" Font-Names="Arial"  BorderStyle="Groove" CssClass="button button2" Text="Save"></asp:button></TD>
						<TD >
							<asp:button id="btnCancel" runat="server" Font-Size="Smaller" Font-Names="Arial"  BorderStyle="Groove" CssClass="button button2" Text="Clear"></asp:button></TD>
						<TD ">
							<asp:button id="btnExit" runat="server" Font-Size="Smaller" Font-Names="Arial" BorderStyle="Groove" CssClass="button button2" Text="Exit" CausesValidation="False"></asp:button></TD>
						<TD ></TD>
					</TR>
				</TABLE>
				<asp:datagrid id="grdPower" runat="server" Width="1016px" BorderColor="Gray" BackColor="Green" AutoGenerateColumns="False">
					<AlternatingItemStyle BackColor="White"></AlternatingItemStyle>
					<HeaderStyle ForeColor="White" BackColor="Navy"></HeaderStyle>
					<Columns>
						<asp:BoundColumn DataField="serial_number" ReadOnly="True" HeaderText="Sl.No."></asp:BoundColumn>
						<asp:BoundColumn DataField="failure_date" ReadOnly="True" HeaderText="Date"></asp:BoundColumn>
						<asp:BoundColumn DataField="from_time" HeaderText="From"></asp:BoundColumn>
						<asp:BoundColumn DataField="to_time" HeaderText="To"></asp:BoundColumn>
						<asp:BoundColumn DataField="failure_duration" ReadOnly="True" HeaderText="Failure Duration"></asp:BoundColumn>
						<asp:BoundColumn DataField="sf_restriction_from" HeaderText="Single From"></asp:BoundColumn>
						<asp:BoundColumn DataField="sf_restriction_to" HeaderText="Single To"></asp:BoundColumn>
						<asp:BoundColumn DataField="sf_duration" ReadOnly="True" HeaderText="Single Duration"></asp:BoundColumn>
						<asp:BoundColumn DataField="df_restriction_from" HeaderText="Both From"></asp:BoundColumn>
						<asp:BoundColumn DataField="df_restriction_to" HeaderText="Both To"></asp:BoundColumn>
						<asp:BoundColumn DataField="df_duration" ReadOnly="True" HeaderText="Both Duration"></asp:BoundColumn>
						<asp:BoundColumn DataField="total_restriction" HeaderText="Total Restriction"></asp:BoundColumn>
						<asp:BoundColumn DataField="Remarks" HeaderText="Remarks"></asp:BoundColumn>
					</Columns>
				</asp:datagrid>
			</asp:Panel>
	</div>
                </form>
            </div>
         <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
