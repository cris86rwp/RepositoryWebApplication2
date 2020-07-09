<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ConsigneeDetails.aspx.vb" Inherits="WebApplication2.ConsigneeDetails" %>
<!DOCTYPE HTML >
<HTML>
	<HEAD>
		<title>ConsigneeDetails</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <link href="Content/bootstrap.min.css" rel="stylesheet" />

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

         <%--<link rel="stylesheet" href="../StyleSheet1.css" />--%>
            
        <script>

function OnlyNumericEntry() {
        if ((event.keyCode < 48 || event.keyCode > 57)) {
        event.returnValue = false;
    }
            }
              function ValidateAlpha(evt)
    {
        var keyCode = (evt.which) ? evt.which : evt.keyCode
        if ((keyCode < 65 || keyCode > 90) && (keyCode < 97 || keyCode > 123) && keyCode != 32)
         
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
  <div class="collapse navbar-collapse " id="navbarSupportedContent-333" >
      <ul class="navbar-nav ml-auto navbar-center">
         <li class="nav-item" style="font-weight: bold">
             <h1 style="color:white; font-size:30px; margin-left:325px; margin-top:5px">Rail Wheel Plant, Bela</h1> 
       
         </li>
          </ul>
    <ul class="navbar-nav ml-auto  navbar-right">
        <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home " style="font-size:30px;"></i>
        </a></li>

       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out" style="font-size:30px;"></i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
          <%--<img src="../../../CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="50" style="border-width: 34px; background-position: 5px 5px; width:50px;margin-top:3px;border-color:white; border-width:50px"/>
        --%><img src="../NewFolder1/CRIS-Recruitment.jpg" height="45" style="border-radius:43%"/>
       </a>
      </li>
     </ul>
      
  </div>
</nav>
<!--/.Navbar -->

         
         <div class="container">
              <div class="row">
                <div class="table">
		<form id="Form1" method="post" runat="server">
           <%-- <h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
			<asp:panel id="Panel1" runat="server">
                
				<TABLE id="Table3" class="table">
					<div class="row" >
						<div class="col" align="center" colSpan="3"><h2>RWP Consignee Details</h2></div>
					</div>
					<div class="row" >
						<div class="col" >
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></div>
					</div>
                    <br />
					<div class="row" >
						<div class="col" >Consignee ID</div>
						<%--<div class="col" >:</div>--%>
						<div class="col" >
							<asp:textbox id="txtConsignee" runat="server" CssClass="form-control" ToolTip="enter numeric only" onkeypress="OnlyNumericEntry()"></asp:textbox></div>
					<%--</div>
					<div class="row" >--%>
						<div class="col" >Name</div>
						<%--<div class="col" >:</div>--%>
						<div class="col" >
							<asp:textbox id="txtConsignee_name" runat="server" CssClass="form-control" ToolTip="Enter Your Name(only character)" onKeyPress="return ValidateAlpha(event);"></asp:textbox></div>
					<%--</div>
					<div class="row" >--%>
						<div class="col" >Address</div>
						<%--<div class="col" >:</div>--%>
						<div class="col" >
							<asp:textbox id="txtAddress" runat="server" CssClass="form-control"></asp:textbox></div>
					</div>
                    <br />
					<div class="row" >
						<div class="col" >City</div>
						<%--<div class="col" >:</div>--%>
						<div class="col" >
							<asp:textbox id="txtCity" runat="server" CssClass="form-control" ToolTip="enter your city(only character)" onKeyPress="return ValidateAlpha(event);"></asp:textbox></div>
					<%--</div>
					<div class="row" >--%>
						<div class="col" >Pincode</div>
						<%--<div class="col" >:</div>--%>
						<div class="col" >
							<asp:textbox id="txtPincode" runat="server" CssClass="form-control" MaxLength="6" ToolTip="enter 6-digit pincode(only numeric)" onkeypress="OnlyNumericEntry()"></asp:textbox></div>
					<%--</div>
					<div class="row" >--%>
						<div class="col" >Passing Authority</div>
						<%--<div class="col" >:</div>--%>
						<div class="col" >
							<asp:textbox id="txtPaying_authority" runat="server" CssClass="form-control" onkeypress="OnlyNumericEntry()" ToolTip="enter numeric"></asp:textbox></div>
					</div>
                    <br />
					<div class="row" >
						<div class="col" >Customer Code</div>
						<%--<div class="col" >:</div>--%>
						<div class="col" >
							<asp:TextBox id="txtCustomerCode" runat="server" CssClass="form-control"></asp:TextBox></div>
					<%--</div>
					<div class="row" >--%>
						<div class="col" >Short Name</div>
						<%--<div class="col" >:</div>--%>
						<div class="col" >
							<asp:TextBox id="txtShortName" runat="server" CssClass="form-control"></asp:TextBox></div>
					<%--</div>
					<div class="row" >--%>
						<div class="col" >Consignee GST</div>
					<%--	<div class="col" >:</div>
						--%><div class="col" >
							<asp:TextBox id="txtconsignee_gst" runat="server" CssClass="form-control"></asp:TextBox></div>
					</div>
                    <br />
					<div class="row" >
						<div class="col" vAlign="top" align="middle" colSpan="3">
							<asp:button id="btnSave" accessKey="s" runat="server" borderStyle="Solid" Font-Bold="True" Font-Size="20px" CssClass="btn btn-dark" Text="Save" Font-Names="Arial"></asp:button>
							<asp:button id="btnClear" accessKey="c" runat="server" borderStyle="Solid" Font-Bold="True" Font-Size="20px" CssClass="btn btn-dark" Text="Clear" Font-Names="Arial" CausesValidation="False"></asp:button></div>
					</div>
				</TABLE>
               
                 
				<asp:DataGrid id="DataGrid1" runat="server" CssClass="table" AllowPaging="True">
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
           </div></div></div>
      <div class="card-footer" align="middle" style="text-align:right;background-color:#cccccc;vertical-align:middle;height:60px;bottom:0;position:absolute;width:100%"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
		
	</body>
</HTML>
