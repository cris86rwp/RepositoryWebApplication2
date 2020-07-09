<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PCDOEntry.aspx.vb" Inherits="WebApplication2.PCDOEntry" %>
<!DOCTYPE HTML  >
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>PCDO Entry</title>
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
 
          <%--<link rel="stylesheet" href="../../../StyleSheet1.css" />--%>
	</head>
    <style>
         .rbl input[type="radio"] {
    margin-left: 10px;
    margin-right: 10px;
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

        <div class="container">
		<form id="Form1" method="post" runat="server">
              
          
			<asp:Panel id="Panel1"   runat="server">
                    <div class="row">
               
				<div class="table">
					<div class="row">
						<div class="col" align="center"><h2><b>PCDO Entry</b></h2></div>
					</div>
				</div>
				<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label>
				<div class="table">
					<div class="row">
						<div class="col">
							<asp:RadioButtonList id="rblYear" runat="server" CssClass="rbl " AutoPostBack="True" RepeatDirection="Horizontal" RepeatLayout="flow"></asp:RadioButtonList></div>
						<div class="col">
							<asp:RadioButtonList id="rblMonth" runat="server" CssClass="rbl" AutoPostBack="True" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:RadioButtonList></div>
					</div>
				</div>
				<div  class="table">
					 </div>
							<div class="table">
								<div class="row">
									<div class="col">Accidents</div>
									<div class="col">
										<asp:TextBox id="txtAccidents" runat="server"  CssClass="form-control"></asp:TextBox></div>
									<div class="col">DAR Cases</div>
									<div class="col">
										<asp:TextBox id="txtDAR" runat="server" CssClass="form-control"  ></asp:TextBox></div>
									<div class="col">OT Hours</div>
									<div class="col">
										<asp:TextBox id="txtOT" runat="server" CssClass="table"></asp:TextBox></div>
								</div>
							</div>
							<div  class="table">
								<div class="row">
									<div class="col">PF No</div>
									<div class="col">
										<asp:TextBox id="txtPFNo" runat="server" AutoPostBack="True"  CssClass="form-control"></asp:TextBox></div>
                                    <div class="col"></div>
                                     <div class="col"></div>
                                     <div class="col"></div>
                                     <div class="col"></div>
								</div>
							</div>
						 
							<asp:DataGrid id="DataGrid1" runat="server"  CssClass="table">
								<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
								<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
								<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
								<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
							</asp:DataGrid>
				<div class="table">
					<div class="row">
						<div class="col"> (Enter the remarks in the following textbox without pressing 'Enter' key to 
							move to next line&nbsp;)</div>
					</div>
				</div>
				<div  class="table">
					<div class="row">
						<div class="col">PF Remarks</div>
						<div class="col">
							<asp:TextBox id="txtPFRemarks" runat="server"  CssClass="form-control" TextMode="MultiLine"></asp:TextBox></div>
                         <div class="col"></div>
                                     <div class="col"></div>
                                     <div class="col"></div>
                                     <div class="col"></div>
					</div>
				</div>
				<div  class="table">
					<div class="row">
						<div class="col" align="center">
							<asp:Button id="btnSave" runat="server" Font-Size="20px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" Text="Save Details"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:CheckBox id="chkDelete" runat="server" Text="Delete ?"></asp:CheckBox></div>
					</div>
				</div>
				<asp:DataGrid id="DataGrid2" runat="server"  CssClass="table" AutoGenerateColumns="False">
					<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<Columns>
						<asp:BoundColumn DataField="PFNo" ReadOnly="True" HeaderText="PFNo"></asp:BoundColumn>
						<asp:BoundColumn DataField="EmployeeName" ReadOnly="True" HeaderText="EmployeeName"></asp:BoundColumn>
						<asp:BoundColumn DataField="Designation" ReadOnly="True" HeaderText="Designation"></asp:BoundColumn>
						<asp:BoundColumn DataField="PFRemarks" ReadOnly="True" HeaderText="PFRemarks"></asp:BoundColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
				</asp:DataGrid>
                         
        </div>
			</asp:Panel>
   
		</form>
                </div>
        <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;position:absolute;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
	</body>
</html>
