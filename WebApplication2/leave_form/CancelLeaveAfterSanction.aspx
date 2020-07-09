<%@ Page Language="vb" AutoEventWireup="false" Codebehind="CancelLeaveAfterSanction.aspx.vb" Inherits="WebApplication2.CancelLeaveAfterSanction" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
<HEAD runat="server">
<title>CancelApplicationForLeave</title>
<LINK href="/
    .css" rel="stylesheet">
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

           <link rel="stylesheet" href="../StyleSheet1.css" />
    <script>
        function isInputNumber(evt) {

                    var ch = String.fromCharCode(evt.which);
        if (!(/[0-9]/.test(ch)))
        {
        evt.preventDefault();
    }

            }
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
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../wapframesetpp.aspx">
          <i class="fab glyphicon glyphicon-home "></i>
        </a></li>
       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../logon.aspx">
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
					<td><FONT color="white" size="5">LEAVE CANCELLATION</FONT><hr class="prettyline" /></td>
				</tr>
			</table>
			<table id="Table1"  class="table">
				<TR>
					<TD><asp:label id="lblMessage" runat="server" ForeColor="#FF8080"></asp:label></TD>
                    <TD><asp:label id="mode" runat="server"></asp:label></TD>
					<TD><asp:label id="lblMode" runat="server"></asp:label></TD>
                    <TD></TD>
                    <TD></TD>
				 
				</TR>
                <TR>
					<TD style="WIDTH: 178px">Employee Code</TD>
					<TD style="WIDTH: 80px"><asp:textbox id="txtEmployee_Code" CssClass="form-control" AutoPostBack="true" runat="server" Width="200px"></asp:textbox></TD>
					<TD style="WIDTH: 174px"><asp:label id="lblName" runat="server"></asp:label></TD>
					<TD><asp:label id="lblDesignation" runat="server"></asp:label></TD>
					<TD></TD>
				</TR>

                 <%--  <tr><TD class="auto-style1" >
                     <asp:label id="Label1" Text="" runat="server"></asp:label>
                    <td> <asp:dropdownlist id="dde" runat="server" Width="200px" AutoPostBack="True" CssClass="form-control ll">
                     <asp:ListItem Value="0" Text="SELECT DATE" Enabled="false"></asp:ListItem>
                 </asp:DropDownList></td>
                     </tr>--%>
              
				<TR>
					<TD style="WIDTH: 178px; HEIGHT: 27px">Application Number</TD>
					<TD style="WIDTH: 80px; HEIGHT: 27px"><asp:textbox id="txtAppl" runat="server" onkeypress="isInputNumber(event)" ReadOnly="true" CssClass="form-control"></asp:textbox></TD>
					<TD style="WIDTH: 174px; HEIGHT: 27px"></TD>
					<TD style="HEIGHT: 27px"></TD>
					<TD style="HEIGHT: 27px"></TD>
				</TR>
				 <%--<tr><TD><asp:label id="Lbldate" Text="Date" runat="server"></asp:label></TD>
				<td><asp:dropdownlist id="ddldate" CssClass="form-control ll" runat="server" AutoPostBack="True" Width="200px">
                     <asp:ListItem></asp:ListItem>
                       <asp:ListItem>select date</asp:ListItem>
				</asp:dropdownlist></td>--%>
             
                 <tr><TD class="auto-style1" >
                     <asp:label id="Lbldate" Text="Date" runat="server"></asp:label>
                    <td> <asp:dropdownlist id="ddldate" runat="server" Width="200px" AutoPostBack="True" CssClass="form-control ll">
                     <asp:ListItem Value="0" Text="SELECT DATE" Enabled="false"></asp:ListItem>
                 </asp:DropDownList></td>
                     </tr>
                <TR>
					<TD style="  HEIGHT: 35px">Leave Code</TD>
					<TD style="  HEIGHT: 35px"><asp:textbox id="txtLeaveCode" CssClass="form-control" runat="server" Width="200px" ></asp:textbox></TD>
					<TD style="  HEIGHT: 35px"><asp:textbox id="txtleaveDescription" CssClass="form-control" runat="server" Width="200px"  ></asp:textbox></TD>
					<TD style="HEIGHT: 36px"></TD>
					<TD style="HEIGHT: 36px"></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 178px">From Date</TD>
					<TD style="WIDTH: 80px"><asp:textbox id="txtLeave_from" CssClass="form-control" runat="server" AutoPostBack="true" Width="200px" ReadOnly="true"></asp:textbox></TD>
					<TD style="WIDTH: 174px"></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD  >To date</TD>
					<TD ><asp:textbox id="txtLeave_to" CssClass="form-control" runat="server" Width="200px"></asp:textbox></TD>
					<TD ></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD  >Total Number of Days</TD>
					<TD ><asp:textbox id="txtdays" CssClass="form-control" runat="server" Width="200px"></asp:textbox></TD>
					<TD ></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD ><asp:button id="cmdSave" CssClass="button button2" runat="server" Text="Save"  ></asp:button></TD>
					<TD  ><asp:button id="cmdCancel" CssClass="button button2" runat="server"  Text="clear fields"  ></asp:button></TD>

					<TD ><asp:datagrid id="DataGrid1" CssClass="table" runat="server"   AutoGenerateColumns="False" BackColor="Gray" ForeColor="Black" PageSize="5" AllowPaging="True">
							<SelectedItemStyle ForeColor="LightGray"></SelectedItemStyle>
							<EditItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></EditItemStyle>
							<AlternatingItemStyle BackColor="White"></AlternatingItemStyle>
							<ItemStyle HorizontalAlign="Center" BackColor="LightGray"></ItemStyle>
							<HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="Navy"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="empno" ReadOnly="True" HeaderText="Empno"></asp:BoundColumn>
                                <asp:BoundColumn DataField="description" ReadOnly="True" HeaderText="Desc"></asp:BoundColumn>
								<asp:BoundColumn DataField="from_date" HeaderText="From Date"></asp:BoundColumn>
								<asp:BoundColumn DataField="to_date" HeaderText="To Date"></asp:BoundColumn>
								<asp:BoundColumn DataField="number_of_days" HeaderText="Days"></asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
					<TD></TD>
					<TD></TD>
				</TR>
			</table>
			
            </div>
            </div>
		</form>
            </div>
         <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</html>
