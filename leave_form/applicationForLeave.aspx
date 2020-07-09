<%@ Page Language="vb" AutoEventWireup="false" Codebehind="applicationForLeave.aspx.vb" Inherits="WebApplication2.applicationForLeave" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
	<HEAD runat="server">
		<title>applicationForLeave</title>
		<LINK href="/
            .css" rel="stylesheet"/>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR"/>
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
         <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css"/>
  <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js"></script>
  <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js"></script>

                <link type="text/css" rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />

	

        <link rel="stylesheet" href="../StyleSheet1.css" />

        <script>
        
               function isNumber1(evt) {

        var charCode = (evt.which) ? evt.which : event.keyCode

        if (
            (charCode != 47 ) &&    
            (charCode != 45 ) &&     
            (charCode < 48 || charCode > 57))
            return false;

        return true;
            }  
           
            </script>
	    <style type="text/css">
            .auto-style1 {
                width: 120px;
                height: 16px;
            }
            .auto-style2 {
                height: 16px;
            }
            .auto-style3 {
                width: 209px;
                height: 16px;
            }
            .auto-style4 {
                width: 163px;
                height: 16px;
            }
        </style>
	</HEAD>
	<body>
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
        
        
        <div class="container">
		<form id="Form1" method="post" runat="server">
                <div class="row">
    
                  <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />
      </div>

        <div class ="row">
        <div class="table-responsive">
			<table id="Table2"  class="table">
				<tr>
					<td align="middle" colspan="6">
						<asp:label id="Label1" runat="server" Width="148px" Height="20px" Font-Bold="True">Leave Application</asp:label><hr class="prettyline" /></td>
				</tr>
				<tr>
					<td style="WIDTH: 318px; HEIGHT: 23px" colspan="3"><asp:label id="lblMessage" runat="server" ForeColor="Blue" Width="171px"></asp:label></td>
					<td colspan="3" style="HEIGHT: 23px"  ><asp:label id="lblMode" runat="server" ForeColor="Blue" Width="116px"></asp:label></td>
				</tr>
				<TR>
					<TD style="WIDTH: 120px; HEIGHT: 21px">Appl. Number</TD>
					<TD style="HEIGHT: 21px">:</TD>
					<TD style="WIDTH: 209px; HEIGHT: 21px"><asp:textbox id="txtapplication_number" runat="server"  CssClass="form-control" ReadOnly="True" AutoPostBack="True"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtapplication_number" ErrorMessage="*"></asp:requiredfieldvalidator></TD>
					<TD style="WIDTH: 163px; HEIGHT: 21px"></TD>
					<TD style="HEIGHT: 21px"></TD>
					<TD style="HEIGHT: 21px"></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 120px; HEIGHT: 24px">Employee Code</TD>
					<TD style="HEIGHT: 24px">:</TD>
					<TD style="WIDTH: 209px; HEIGHT: 24px"><asp:textbox id="txtemployee_code" runat="server"  CssClass="form-control" AutoPostBack="True" MaxLength="20" ></asp:textbox><asp:label id="Lblempcode" runat="server" ForeColor="White" Width="171px"></asp:label><asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ControlToValidate="txtemployee_code" ErrorMessage="*"></asp:requiredfieldvalidator></TD>
					<TD style="WIDTH: 163px; HEIGHT: 24px"><asp:label id="lblname" runat="server"></asp:label></TD>
					<TD style="HEIGHT: 24px"><asp:label id="lbldesignation" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 120px; HEIGHT: 23px">Leave Code</TD>
					<TD style="HEIGHT: 23px">:</TD>
					<TD style="WIDTH: 209px; HEIGHT: 23px"><asp:dropdownlist id="ddlleave_code" CssClass="form-control ll" runat="server" AutoPostBack="True">		<%--<TD style="WIDTH: 163px; HEIGHT: 23px">Commute ?</TD>--%>
                    <asp:ListItem ></asp:ListItem>
						
                        <asp:ListItem Value="11">LAP</asp:ListItem>
							<asp:ListItem Value="31">LHAP</asp:ListItem>
                    <asp:ListItem Value="14">CL</asp:ListItem>
							<asp:ListItem Value="17">RH</asp:ListItem>
                    <asp:ListItem Value="CCL">CHILD CARE</asp:ListItem>
							<asp:ListItem Value="04">LWP</asp:ListItem>
                    <asp:ListItem Value="08">MATERNITY</asp:ListItem>
							<asp:ListItem Value="PL">PATERNITY</asp:ListItem>
                        	<asp:ListItem Value="SCL">SPECIAL CL</asp:ListItem>
                        <asp:ListItem Value="CR">COMP REST</asp:ListItem>
						<asp:ListItem Value="07">STUDY LEAVE</asp:ListItem>
						
                   </asp:dropdownlist><asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" ControlToValidate="ddlleave_code" ErrorMessage="*"></asp:requiredfieldvalidator></TD>
			
                        <TD><asp:label id="lblcommute" runat="server" ></asp:label></TD>
					<%--<TD style="HEIGHT: 23px">:</TD>--%>
					<TD style="HEIGHT: 23px"><asp:dropdownlist id="ddlconvert" runat="server" CssClass="form-control ll" AutoPostBack="True">
							<asp:ListItem></asp:ListItem>
							<asp:ListItem Value="Y">YES</asp:ListItem>
							<asp:ListItem Value="N">NO</asp:ListItem>
						</asp:dropdownlist>
                        <asp:label id="Lblcom" runat="server" ForeColor="White" Width="171px"></asp:label>
					</TD>
                    </tr>
                    <tr>
                    <td> <asp:label id="Lblhol" runat="server" align="center" ForeColor="White" Width="171px"></asp:label></td>
                    <TD><asp:dropdownlist id="Ddlholiday" runat="server" align="center" Visible="false" CssClass="form-control ll" AutoPostBack="True"></asp:dropdownlist>
                        <asp:label id="Lblholiday" runat="server" ForeColor="White" Width="171px"></asp:label>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 120px; HEIGHT: 24px">Leave from</TD>
					<TD style="HEIGHT: 24px">:</TD>
					<TD style="WIDTH: 209px; HEIGHT: 24px"><asp:textbox id="txtleave_from" runat="server"   CssClass="form-control" AutoPostBack="True" onkeypress="return isNumber1(event)" MaxLength="10" Placeholder="MM/DD/YYYY"></asp:textbox>&nbsp;<%--<FONT color="blue">--%><%--<FONT color="blue">DD/MM/YYYY</FONT></FONT>--%></TD>
					<%--<TD style="WIDTH: 163px; HEIGHT: 24px">1st Half/2nd half</TD>--%>
					<TD>
                        <asp:ImageButton ID="img1" runat="server" Height="22px" ImageUrl="~/images/calender.jpg" CausesValidation="False" />
                          <asp:Calendar ID="cal1" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" Width="220px" ShowGridLines="True">
                            <SelectedDayStyle BackColor="red" />
                            <DayHeaderStyle BackColor="#FFCC66" Height="1px" Font-Bold="True" />
                            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                            <OtherMonthDayStyle ForeColor="#CC9966" />
                            <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                            <SelectorStyle BackColor="#FFCC66" />
                            <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                            <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                        </asp:Calendar>
                       
                        <asp:label id="lblcl1" runat="server" ></asp:label></TD>
                    <%--<TD style="HEIGHT: 24px">:</TD>--%>
					<TD style="HEIGHT: 24px"><asp:dropdownlist id="ddlfirst_half_from" CssClass="form-control ll" runat="server" AutoPostBack="True">
							<asp:ListItem></asp:ListItem>
							<asp:ListItem Value="F">FORE NOON</asp:ListItem>
							<asp:ListItem Value="A">AFTER NOON</asp:ListItem>
						</asp:dropdownlist>
                        <asp:label id="Lbl1" runat="server" ForeColor="White" Width="171px"></asp:label>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 120px; HEIGHT: 36px">Leave to</TD>
					<TD style="HEIGHT: 36px">:</TD>
					<TD style="WIDTH: 209px; HEIGHT: 36px"><asp:textbox id="txtleave_to" runat="server" CssClass="form-control"    AutoPostBack="True" onkeypress="return isNumber1(event)" MaxLength="10" Placeholder="MM/DD/YYYY"></asp:textbox><%--<FONT color="blue"></FONT>--%></TD>
					<%--<TD style="WIDTH: 163px; HEIGHT: 36px">1st Half/2nd half</TD>--%>
					<TD>
                        <asp:ImageButton ID="img2" runat="server" Height="21px" ImageUrl="~/images/calender.jpg" Width="22px" CausesValidation="False" />
                         <asp:Calendar ID="Cal2" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" Width="220px" ShowGridLines="True">
                            <SelectedDayStyle BackColor="red" />
                            <DayHeaderStyle BackColor="#FFCC66" Height="1px" Font-Bold="True" />
                            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                            <OtherMonthDayStyle ForeColor="#CC9966" />
                            <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                            <SelectorStyle BackColor="#FFCC66" />
                            <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                            <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                        </asp:Calendar>
                        <asp:label id="lblcl2" runat="server" ></asp:label></TD>
                    <%--<TD style="HEIGHT: 36px">:</TD>--%>
					<TD style="HEIGHT: 36px"><asp:dropdownlist id="ddlfirst_half_to" CssClass="form-control ll" runat="server" AutoPostBack="True">
							<asp:ListItem></asp:ListItem>
							<asp:ListItem Value="F">FORE NOON</asp:ListItem>
							<asp:ListItem Value="A">AFTER NOON</asp:ListItem>
						</asp:dropdownlist>
                        <asp:label id="Lbl2" runat="server" ForeColor="White" Width="171px"></asp:label>
					</TD>
				</TR>
				<TR>
					<TD class="auto-style1">Total Days</TD>
					<TD class="auto-style2">:</TD>
					<TD class="auto-style3"><asp:textbox id="txtdays" runat="server" CssClass="form-control"     ReadOnly="True" MaxLength="6"></asp:textbox></TD>
					<TD class="auto-style4">Reason :</TD>
					<TD class="auto-style2"><asp:textbox id="txtreason" runat="server"    CssClass="form-control" MaxLength="100" Width="350 px"></asp:textbox><asp:label id="Lblreason" runat="server" ForeColor="White" Width="171px"></asp:label><asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="txtApplication_number"></asp:requiredfieldvalidator></TD></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 120px; HEIGHT: 61px">Out Station/ Head Quarters</TD>
					<TD style="HEIGHT: 61px">:</TD>
					<TD style="WIDTH: 209px; HEIGHT: 61px"><asp:dropdownlist id="ddloutstation_or_hq" CssClass="form-control" AutoPostBack="true" runat="server">
							<asp:ListItem></asp:ListItem>
							<asp:ListItem Value="O">OUT STATION</asp:ListItem>
							<asp:ListItem Value="H">HEAD QUARTERS</asp:ListItem>
						</asp:dropdownlist>
                        <asp:label id="Lblout" runat="server" ForeColor="White" Width="171px"></asp:label>
					</TD>
                    <asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" ErrorMessage="*" ControlToValidate="txtApplication_number"></asp:requiredfieldvalidator></TD>
                    	<TD style="WIDTH: 209px; HEIGHT: 61px"><asp:dropdownlist id="ddlout" CssClass="form-control" runat="server">
							<asp:ListItem selected="false" >Outside/within India</asp:ListItem>
							<asp:ListItem Value="Out">OUTSIDE INDIA</asp:ListItem>
							<asp:ListItem Value="Within">WITHIN INDIA</asp:ListItem>
						</asp:dropdownlist>
                        <asp:label id="Label2" runat="server" ForeColor="White" Width="171px"></asp:label>
					</TD>
                
					<asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server" ErrorMessage="*" ControlToValidate="txtApplication_number"></asp:requiredfieldvalidator></TD></TD>
				</TR>
                <tr><TD style="WIDTH: 163px; HEIGHT: 61px">Address</TD>
                    <TD style="HEIGHT: 61px">:</TD>
					<TD style="HEIGHT: 41px"><asp:textbox id="txtaddress" runat="server"   CssClass="form-control" MaxLength="30"  TextMode="MultiLine"></asp:textbox>
                        <asp:label id="Lbladd" runat="server" ForeColor="White" Width="171px"></asp:label></tr>
                <TR>
					<TD style="WIDTH: 90px; HEIGHT: 2px">
                       <asp:textbox id="Txtupload" runat="server" CssClass="form-control" text="Upload document if needed" readonly="true" MaxLength="6"></asp:textbox>
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                            <asp:Button ID="Btndoc" runat="server" Text="Upload"  CssClass="button button2" /> </TD>
                   <td> <asp:Label ID="lbl_image" runat="server" Text="(only .jpg,.png,.bmp files allowed)"></asp:Label></td>
                    <asp:Label ID="lblmessage1" runat="server"></asp:Label>
					<TD style="HEIGHT: 2px"></TD>
					<TD style="WIDTH: 209px; HEIGHT: 2px">&nbsp;</TD>
					<TD style="WIDTH: 163px; HEIGHT: 2px"></TD>
                    <TD style="HEIGHT: 2px"></TD>
					<TD style="HEIGHT: 2px"></TD>
				<TR>
					<TD style="WIDTH: 120px; HEIGHT: 2px">&nbsp;</TD>
					<TD style="HEIGHT: 2px"></TD>
					<TD style="WIDTH: 209px; HEIGHT: 2px">&nbsp;</TD>
					<TD style="WIDTH: 163px; HEIGHT: 2px"></TD>
					<TD style="HEIGHT: 2px"></TD>
					<TD style="HEIGHT: 2px"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px" align="middle" colspan="6">
						<asp:Button id="cmdSave" runat="server"   CssClass="button button2"    Text="Save" Width="133px"></asp:Button>
						&nbsp;
						<asp:Button id="cmdCancel" runat="server"   CssClass="button button2"     Text="Cancel"></asp:Button>
						</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 318px; HEIGHT: 105px" colspan="4"><asp:datagrid id="DataGrid1" CssClass="table" runat="server"   AutoGenerateColumns="False" BackColor="Gray" ForeColor="Black" PageSize="5" AllowPaging="True">
							<SelectedItemStyle ForeColor="LightGray"></SelectedItemStyle>
							<EditItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></EditItemStyle>
							<AlternatingItemStyle BackColor="White"></AlternatingItemStyle>
							<ItemStyle HorizontalAlign="Center" BackColor="LightGray"></ItemStyle>
							<HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="Navy"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="description" ReadOnly="True" HeaderText="Leave Code"></asp:BoundColumn>
								<asp:BoundColumn DataField="from_date" HeaderText="From Date"></asp:BoundColumn>
								<asp:BoundColumn DataField="to_date" HeaderText="To Date"></asp:BoundColumn>
								<asp:BoundColumn DataField="number_of_days" HeaderText="Days"></asp:BoundColumn>
                                <asp:BoundColumn DataField="l_confirm" HeaderText="Status"></asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>

					<TD colspan="4" style="HEIGHT: 105px"><asp:datagrid id="Datagrid2" runat="server" CssClass="table"   AutoGenerateColumns="False" BackColor="Gray"  ForeColor="Black">
							<SelectedItemStyle ForeColor="LightGray"></SelectedItemStyle>
							<EditItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></EditItemStyle>
							<AlternatingItemStyle BackColor="White"></AlternatingItemStyle>
							<ItemStyle HorizontalAlign="Center" BackColor="LightGray"></ItemStyle>
							<HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="Navy"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="leavecode" ReadOnly="True" HeaderText="Leave Type"></asp:BoundColumn>
								<asp:BoundColumn DataField="leaveavailed" HeaderText="Availed"></asp:BoundColumn>
								<asp:BoundColumn DataField="balance" HeaderText="Balance"></asp:BoundColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
           
			</table>
                 </div>
            </div>
			&nbsp;</form></div>
          <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</html>
