<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ProdLiningPLs.aspx.vb" Inherits="WebApplication2.ProdLiningPLs" %>
<!DOCTYPE HTML PUBLIC >
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>ProdLiningPLs</title>
		<link rel="stylesheet" type="text/css" href="css/jquery-ui.css">

		
 
   <LINK id="mss" href="/wap.css" rel="stylesheet"/>
		<META content="Microsoft Visual Studio.NET 7.0" name="GENERATOR"/>
		<META content="Visual Basic 7.0" name="CODE_LANGUAGE"/>
		<META content="JavaScript" name="vs_defaultClientScript"/>
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
         <meta charset="utf-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css"/>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js"></script>
         <link type="text/css" rel="stylesheet" href="https://cdn.datatables.net/1.10.9/css/dataTables.bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="https://cdn.datatables.net/responsive/1.0.7/css/responsive.bootstrap.min.css" />
        <link href="jQuery.datetimepicker.min.css" rel="stylesheet" />
        <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.9/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/responsive/1.0.7/js/dataTables.responsive.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.9/js/dataTables.bootstrap.min.js"></script>
            <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
        <script type="text/javascript" src= "https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js">  </script>
<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
<script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
<script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
<script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
	</head>
    <style>
    .rbl input[type="radio"] {
    margin-left: 15px;
    margin-right: 5px;
}
        </style>

	<body>


    <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
  <a class="navbar-brand p-0" href="#"><img src="../../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent-333"
    aria-controls="navbarSupportedContent-333" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>
  <div class="collapse navbar-collapse " id="navbarSupportedContent-333" >
      <ul class="navbar-nav ml-auto navbar-center">
         <li class="nav-item" style="font-weight: bold">
             <h1 style="color:white; font-size:30px; margin-left:430px; margin-top:5px">Rail Wheel Plant, Bela</h1> 
       
         </li>
          </ul>
    <ul class="navbar-nav ml-auto  navbar-right">
        <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home " style="font-size:30px"></i>
        </a></li>
       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out"style="font-size:30px"></i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
         
        <img src="../../NewFolder1/CRIS-Recruitment.jpg" height="45" style="border-radius:43%"/>
       </a>
      </li>
     </ul>
      
  </div>
</nav>
<!--/.Navbar -->


         <div class="container">
             <form id="Form1" method="post" runat="server">
              
                 <asp:panel id="Panel1"  runat="server">

            <div class ="row">
                
		
			
             <%--   style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px"--%>
				<div class="table" >
                   <%-- style="WIDTH: 1077px; HEIGHT: 51px" cellSpacing="1" cellPadding="1" width="1077"--%>
					<div class="row">
						<div class="col" align="center">
							<asp:label id="lblConsignee" runat="server" Font-Bold="True"></asp:label>&nbsp;<STRONG><h2>&nbsp;Lining&nbsp;PLs</STRONG></h2></div>
					</div>
					<div class="row">
						<div class="col">
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></div>
					</div>
				</div>
				<div class="table" border="0">
					<div class="row">
						<div class="col">
							<asp:RadioButtonList id="rblLiningType" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rbl"></asp:RadioButtonList></div>
					</div>
				</div>
                </div>
				<div class="table" border="0">
                     <%--style="WIDTH: 399px; HEIGHT: 28px" cellSpacing="1" cellPadding="1" width="399"--%>
					<div class="row">
						<div class="col">
							<asp:RadioButtonList id="rblLinedBy"  runat="server" AutoPostBack="True" RepeatDirection="Horizontal" RepeatLayout="Flow"  CssClass="rbl" ></asp:RadioButtonList></div>
					</div>
				</div>
				<div class="table" border="0">
					<div class="row">
						<div class="col">Lining No</div>
					
						<div class="col">
							
                           <asp:DropDownList id="ddlLiningNo" CssClass="form-control ll" runat="server" AutoPostBack="True"></asp:DropDownList></div>
					<div class="col"></div>
                        <div class="col"></div>
                         <div class="col"></div>
                    </div>
				</div>
                    <div class="row">
                        <div class="table-responsive">
				<asp:DataGrid id="DataGrid1" CssClass="table" runat="server" >
                    <%--CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966"--%>
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid></div></div>
				<div class="table" border="0">
                  <%--  style="WIDTH: 807px; HEIGHT: 28px" cellSpacing="1" cellPadding="1" width="807"--%>
					<div  class="row">
						<div class="col">
							<asp:RadioButtonList id="rblPL" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rbl"></asp:RadioButtonList></div>
					</div>
				</div>
				<div class="table" border="0">
                    <%--cellSpacing="1" cellPadding="1" width="300" --%>
					<div class="row">
						<div class="col">
							<div class="table" border="0"></div>
                                <%-- style="WIDTH: 211px; HEIGHT: 88px" cellSpacing="1" cellPadding="1" width="211"--%>
								<div class="row">
									<div class="col">PO/DBR No</div>
								
									<div class="col">
										<asp:DropDownList id="ddlPO" runat="server" CssClass="form-control ll" AutoPostBack="True"></asp:DropDownList></div>
								<div class="col"></div>
                        <div class="col"></div>
                         <div class="col"></div>
                                </div>
								<br><div class="row">
									<div class="col" colspan="3">
										<asp:Label id="lblSupplier" runat="server"></asp:Label></div>
								<div class="col"></div>
                        <div class="col"></div>
                         <div class="col"></div>
                                </div>
								<br><div class="row">
									<div class="col">Qty</div>
								
									<div class="col">
										<asp:TextBox id="txtQty" runat="server" CssClass="form-control"></asp:TextBox></div>
								<div class="col"></div>
                        <div class="col"></div>
                         <div class="col"></div>
                                </div>
								<br><div class="row">
									<div class="col">Set No</div>
								
									<div class="col">
										<asp:TextBox id="txtSetNo" runat="server" CssClass="form-control" ></asp:TextBox></div>
								<div class="col"></div>
                        <div class="col"></div>
                         <div class="col"></div>
                                </div>
								<br><div class="row">
									<div class="col"  align="center" >
										<asp:Button id="btnSave" runat="server"  Font-Size="20px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark"  Text="Save"></asp:Button></div>
								</div>
								<div class="row">
									<div class="col"  align="left" >Saved PLs :</div>
								</div>
					<div class="row">
							<asp:DataGrid id="DataGrid3" runat="server" CssClass="table" >  <%--CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966"--%>
								<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
								<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
								<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
								<Columns>
									<asp:ButtonColumn Text="Delete" CommandName="Delete"></asp:ButtonColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
							</asp:DataGrid></div>
						<td vAlign="top" align="left">
							<asp:DataGrid id="DataGrid2" runat="server" CssClass="table" > <%--CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#3366CC"--%>
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid></td>
					</div>
				</div></div>
			</asp:panel></form>
                    </div>
              <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;position:relative;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
	</body>
</html>
