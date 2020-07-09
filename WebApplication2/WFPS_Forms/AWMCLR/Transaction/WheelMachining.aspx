<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WheelMachining.aspx.vb" Inherits="WebApplication2.WheelMachining" uiCulture="en-GB" Culture="en-GB" %>
<!DOCTYPE HTML>
<HTML xmlns="http://www.w3.org/1999/xhtml">
	<HEAD runat="server">
		<title>WheelMachining</title>
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
       <%--<link rel="stylesheet" href="../../..StyleSheet1.css">--%>
         

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
        <script>
            function isNumber(evt, element)
            {

        var charCode = (evt.which) ? evt.which : event.keyCode

        if (
           
            (charCode != 47 || $(element).val().indexOf('/') != -1) &&    
            (charCode < 48 || charCode > 57))
            return false;

        return true;
             }    

            function isNumber1(evt, element)
            {

                    var charCode = (evt.which) ? evt.which : event.keyCode

                      if (
                           (charCode != 45 ) && (charCode != 47 ) &&     // 
                           (charCode < 48 || charCode > 57))
                      return false;

                  return true;
            } 
            </script>

       
        <div class="container">
		<FORM id="Form1" method="post" runat="server">
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
            <div class="row"><div class="table-responsive">
			<TABLE id="Table2" class="table">
				<TR>
					<TD colspan="6">
						<P><STRONG><FONT color="#6633ff" size="4">WHEEL MACHINING</FONT></STRONG></P><hr class="prettyline" />
					</TD>
				</TR>
				<TR>
					<TD  colSpan="4" ><asp:label id="lblMessage" runat="server"  ForeColor="Red" Font-Bold="True">Messages</asp:label></TD>
					<TD >Mode</TD>
					<TD><asp:label id="lblMode" runat="server" ></asp:label></TD>
				</TR>
				<TR>
					<TD >Date</TD>
					<TD ><asp:textbox id="txtDate" runat="server" CssClass="form-control" AutoPostBack="True" onkeypress="return isNumber1(event,this)" MaxLength="10" ></asp:textbox><asp:requiredfieldvalidator id="rfvDate" runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="txtDate"></asp:requiredfieldvalidator></TD>
					<TD >Shift</TD>
					<TD><asp:dropdownlist id="ddlShift" runat="server" CssClass="form-control ll" AutoPostBack="True">
							<asp:ListItem Value="Select" Selected="True">Select</asp:ListItem>
							<asp:ListItem Value="A">A</asp:ListItem>
							<asp:ListItem Value="B">B</asp:ListItem>
							<asp:ListItem Value="C">C</asp:ListItem>
							<asp:ListItem Value="G">G</asp:ListItem>
						</asp:dropdownlist><asp:customvalidator id="cvshift" runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="ddlShift"></asp:customvalidator></TD>
					<TD >Op</TD>
					<TD><asp:textbox id="txtOperator" runat="server" CssClass="form-control" AutoPostBack="True" ></asp:textbox><asp:requiredfieldvalidator id="rfvOperator" runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="txtOperator"></asp:requiredfieldvalidator><asp:customvalidator id="cvOperator" runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="txtOperator"></asp:customvalidator></TD>
				</TR>
				<TR>
					<TD >Type for wheel</TD>
					<TD ><asp:dropdownlist id="ddlSetForWhlType" runat="server" CssClass="form-control ll" AutoPostBack="True">
							<asp:ListItem Value="Select" Selected="True">Select</asp:ListItem>
							<asp:ListItem Value="120120">BOXN</asp:ListItem>
							<asp:ListItem Value="110123">ICF</asp:ListItem>

						<%--	<asp:ListItem Value="210145    ">MGC</asp:ListItem>
							<asp:ListItem Value="120224">840</asp:ListItem>--%>
							<%--<asp:ListItem Value="MGLO">MGLO</asp:ListItem>
							<asp:ListItem Value="BGL">BGL</asp:ListItem>
							<asp:ListItem Value="120316 ">WGN</asp:ListItem>
							<asp:ListItem Value="120513 ">1090</asp:ListItem>
							<asp:ListItem Value="120617">915D</asp:ListItem>
							<asp:ListItem Value="150146">DSL</asp:ListItem>
							<asp:ListItem Value="150320">910D</asp:ListItem>
							<asp:ListItem Value="150423">910</asp:ListItem>
							<asp:ListItem Value="150515">HPDH</asp:ListItem>
							<asp:ListItem Value="150644">HPDHL</asp:ListItem>
							<asp:ListItem Value="210110    ">MGLO</asp:ListItem>
							<asp:ListItem Value="210249    ">MG/F</asp:ListItem>
							<asp:ListItem Value="210446">851D</asp:ListItem>
							<asp:ListItem Value="210540">860</asp:ListItem>
							<asp:ListItem Value="290120    ">MGDM</asp:ListItem>
							<asp:ListItem Value="210643">MGC1</asp:ListItem>
							<asp:ListItem Value="210747">MGC2</asp:ListItem>
							<asp:ListItem Value="120549    ">UIC</asp:ListItem>
							<asp:ListItem Value="120410    ">CH36</asp:ListItem>
							<asp:ListItem Value="110344">EMUBG</asp:ListItem>
							<asp:ListItem Value="111220">EMU ROUGH</asp:ListItem>
							<asp:ListItem Value="FBCLHB">FBCLHB</asp:ListItem>
							<asp:ListItem Value="120549">BOX WGN</asp:ListItem>--%>
						</asp:dropdownlist><asp:customvalidator id="cvwhltype" runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="ddlSetForWhlType"></asp:customvalidator></TD>
					<TD >Mcn Opn</TD>
					<TD ><asp:dropdownlist id="ddlSetForMcn" runat="server" CssClass="form-control ll" AutoPostBack="True">
							<asp:ListItem Value="Select" Selected="True">Select</asp:ListItem>
							<asp:ListItem Value="HT">HT</asp:ListItem>
							<asp:ListItem Value="HF">HF</asp:ListItem>
							<asp:ListItem Value="VT">VT</asp:ListItem>
							<asp:ListItem Value="HP">HP</asp:ListItem>
							<asp:ListItem Value="HB">HB</asp:ListItem>
							<asp:ListItem Value="BH">BH</asp:ListItem>
							<asp:ListItem Value="HR">HR</asp:ListItem>
							<asp:ListItem Value="BR">BR</asp:ListItem>
							<asp:ListItem Value="WAPXMIS">WAPXMIS</asp:ListItem>
							<asp:ListItem Value="WBAD MC">WBAD MC</asp:ListItem>
							<asp:ListItem Value="WBAD GR">WBAD GR</asp:ListItem>
							<asp:ListItem Value="WBNC">WBNC</asp:ListItem>
							<asp:ListItem Value="WBRDEB">WBRDEB</asp:ListItem>
							<asp:ListItem Value="WBRDGB">WBRDGB</asp:ListItem>
							<asp:ListItem Value="WDEPPAD">WDEPPAD</asp:ListItem>
							<asp:ListItem Value="WDGH">WDGH</asp:ListItem>
							<asp:ListItem Value="WDGR">WDGR</asp:ListItem>
							<asp:ListItem Value="WGB">WGB</asp:ListItem>
							<asp:ListItem Value="WHB">WHB</asp:ListItem>
							<asp:ListItem Value="WHPMC">WHPMC</asp:ListItem>
							<asp:ListItem Value="WHPMC-DGSPG">WHPMC-DGSPG</asp:ListItem>
							<asp:ListItem Value="WHPMC-WFPS">WHPMC-WFPS</asp:ListItem>
							<asp:ListItem Value="WHRMC">WHRMC</asp:ListItem>
							<asp:ListItem Value="WHTMC">WHTMC</asp:ListItem>
							<asp:ListItem Value="WHWMC">WHWMC</asp:ListItem>
							<asp:ListItem Value="WRFHR">WRFHR</asp:ListItem>
							<asp:ListItem Value="WSRF">WSRF</asp:ListItem>
							<asp:ListItem Value="WSPMC">WSPMC</asp:ListItem>
							<asp:ListItem Value="WSPMC-HSSW">WSPMC-HSSW</asp:ListItem>
							<asp:ListItem Value="WUB-EB">WUB-EB</asp:ListItem>
							<asp:ListItem Value="WUB-PB">WUB-PB</asp:ListItem>
							<asp:ListItem Value="WUB-SB">WUB-SB</asp:ListItem>
							<asp:ListItem Value="WVTL">WVTL</asp:ListItem>
						</asp:dropdownlist><asp:customvalidator id="cvmcnopn" runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="ddlSetForMcn"></asp:customvalidator><asp:checkbox id="chkOverride" runat="server" AutoPostBack="True" Visible="False" Text="Override"></asp:checkbox></TD>
					<TD >Machining Agency</TD>
					<TD><asp:dropdownlist id="ddlMcnAgency" runat="server" CssClass="form-control ll" AutoPostBack="True">
							<asp:ListItem Value="Select" Selected="True">Select</asp:ListItem>
							<asp:ListItem Value="RWP">RWP</asp:ListItem>
							<%--<asp:ListItem Value="EXCEL">EXCEL</asp:ListItem>
							<asp:ListItem Value="KAVITHA">KAVITHA</asp:ListItem>
							<asp:ListItem Value="TEC">TEC</asp:ListItem>
							<asp:ListItem Value="KALA">KALA</asp:ListItem>
							<asp:ListItem Value="TECTOOLS">TECTOOLS</asp:ListItem>
							<asp:ListItem Value="SEEMA">SEEMA</asp:ListItem>--%>
						</asp:dropdownlist><asp:customvalidator id="cvMcnAgency" runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="ddlMcnAgency"></asp:customvalidator></TD>
				</TR>
				<tr>
					<TD >Machine Id</TD>
					<TD><asp:dropdownlist id="ddlMachineId" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist><asp:customvalidator id="cvmcnId" runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="ddlMachineId"></asp:customvalidator></TD>
				</tr>
                <tr>
                    <%--<TD >
						Gate Pass&nbsp;:</TD>
						<td><asp:textbox id="txtGatePass" runat="server" CssClass="form-control ll"></asp:textbox></td>--%>
                    	
					
					<TD >Wheel Number<span class="glyphicon-asterisk"></span></TD>
					<TD ><asp:textbox id="txtWheel" runat="server" CssClass="form-control" AutoPostBack="True"  ToolTip="Enter Wheel Number(only numeric)" onkeypress="return isNumber(event, this)" ></asp:textbox><asp:requiredfieldvalidator id="rfvwheel" runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="txtWheel"></asp:requiredfieldvalidator>DoNot 
						Prefix Zeroes</TD>
                    <TD >&nbsp;Remarks</TD>
					<TD><asp:textbox id="txtRemarks" runat="server" CssClass="form-control" MaxLength="250"></asp:textbox></TD>
				
                    </tr>
                <tr>
					<TD ><asp:button id="btnSend" runat="server" CssClass="button button2" Text="Sent for M/c"></asp:button></TD>
					<TD ><asp:button id="btnMachined" runat="server" CssClass="button button2" Text="Machined Inhouse"></asp:button></TD>
					<TD ><asp:button id="btnRecd" runat="server" CssClass="button button2" Text="Recd After M/c"></asp:button></TD>
					<TD align="middle"><asp:button id="btnClear" runat="server" CssClass="button button2" Text="Clear"></asp:button></TD>
				</TR>
				<TR>
					<TD align="left" colSpan="6">
						<asp:Label id="lblMcnMark" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label></TD>
				</TR>
				<TR>
					<TD align="middle" colSpan="6" rowSpan="1">-:&nbsp; Machining Done for the Date 
						&amp; Shift :-</TD>
				</TR>
				<TR>
					<TD colSpan="6" rowSpan="1"><asp:datagrid id="GrdInfo" runat="server" CssClass="table" BorderColor="White" BorderStyle="Ridge" CellSpacing="1" BorderWidth="2px" BackColor="White" CellPadding="3" GridLines="None" ShowFooter="True" Height="135px">
							<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#9471DE"></SelectedItemStyle>
							<ItemStyle ForeColor="Black" BackColor="#DEDFDE"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="#E7E7FF" BackColor="#4A3C8C"></HeaderStyle>
							<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
							<Columns>
								<asp:ButtonColumn Text="Delete" HeaderText="Delete" CommandName="Delete"></asp:ButtonColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Right" ForeColor="Black" BackColor="#C6C3C6"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
		</div></div></FORM></div>
        <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
