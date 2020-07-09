<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ProdLiningRemarks.aspx.vb" Inherits="WebApplication2.ProdLiningRemarks" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>ProdLiningRemarks</title>
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
 
          <link rel="stylesheet" href="../StyleSheet1.css" />
	  <%--  <style type="text/css">
            .auto-style1 {
                display: block;
                font-size: 1rem;
                font-weight: 400;
                line-height: 1.5;
                color: #495057;
                background-clip: padding-box;
                border-radius: .25rem;
                transition: none;
                border: 1px solid #ced4da;
                background-color: #fff;
            }
        </style>--%>
	  <%--  <style type="text/css">
            .auto-style1 {
                width: 1620px;
            }
        </style>--%>

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
        <div class="container" align="center">
            	<form id="Form1" method="post" runat="server">
            
           
	
			<asp:panel id="Panel1"  runat="server">
                 <div class ="row">
               
                <%--style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px"--%>
				<div class="table">
                   <%-- cellSpacing="1" cellPadding="1" width="300"--%>
					<div class="row">
						 <div class="col">
							<asp:label id="lblConsignee" runat="server" Font-Bold="True"></asp:label><strong><h2>&nbsp;Lining&nbsp;Remarks</strong></h2></div>
					</div>
					
						 <div class="col">
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></div>
					</div>
				</div>
				<div class="table">
                  <%--  style="WIDTH: 1079px; HEIGHT: 28px" cellSpacing="1" cellPadding="1" width="1079"--%>
					<div class=
						 <div class="col">
							<asp:RadioButtonList id="rblLiningType" runat="server"  CssClass="rbl"    RepeatDirection="Horizontal" AutoPostBack="True"></asp:RadioButtonList></div>
					</div>
				</div>
				<div class="table" >
                   <%-- style="WIDTH: 223px; HEIGHT: 32px" cellSpacing="1" cellPadding="1" width="223"--%>
					<div class="row">
						 <div class="col">Lining No &nbsp  &nbsp   &nbsp   &nbsp   &nbsp  &nbsp  &nbsp  &nbsp  &nbsp  &nbsp  &nbsp  &nbsp  &nbsp  &nbsp  &nbsp  &nbsp  &nbsp  &nbsp </div>
						 
						 <div class="col">
							<asp:DropDownList id="ddlLiningNo"  CssClass=" form-control" runat="server" AutoPostBack="True"></asp:DropDownList></div>
					<div class="col">
                                </div>
                        <div class="col">
                                </div>
                        <div class="col">
                                </div>
                    </div>
				</div>
				<asp:DataGrid id="DataGrid1" runat="server" CssClass="table" >
                   <%-- BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4"--%>
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
				<div class="table">
                    <%--cellSpacing="1" cellPadding="1" width="300" bgColor="#cccc33"--%>
					<div class="row">
						<div class="col">Refractory Condemned To</div>
				
						 <div class="col">
							<asp:RadioButtonList id="rblRefCondemned" CssClass="rbl" runat="server"  RepeatDirection="Horizontal"></asp:RadioButtonList></div>
                         <div class="col"></div>
					</div>
				</div>
				<asp:Panel id="pnlLT3" runat="server">
					<table id="Table9" class="table">
						<div class="row">
							<div class="col">
                                </div>
                            </div>
                        </table>
								<div class="table">
									<div class="row">
										<div class="col" colspan="2"><b>Bottom</b></div>
                                        
									</div>
									<br><div class="row">
										<div class="col" colspan="2">
											<asp:RadioButtonList id="rblSpalling"  CssClass="rbl" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"  >
												<asp:ListItem Value="1">Spalling</asp:ListItem>
												<asp:ListItem Value="0" Selected="True">No Spalling</asp:ListItem>
											</asp:RadioButtonList></div>
									</div>
									<br><div class="row">
										 <div class="col">Depth &nbsp  &nbsp   &nbsp   &nbsp   &nbsp  &nbsp  &nbsp  &nbsp  &nbsp  &nbsp  &nbsp  &nbsp &nbsp  &nbsp &nbsp &nbsp &nbsp &nbsp </div>
										 <div class="col">
											<asp:TextBox id="txtSpallingDepth" runat="server" CssClass="form-control"></asp:TextBox></div>
                                         <div class="col"></div>
										 <div class="col"></div>
										 <div class="col"></div>
			
									</div>
								<br>	<div class="row">
										 <div class="col">Area &nbsp  &nbsp   &nbsp   &nbsp   &nbsp  &nbsp  &nbsp  &nbsp  &nbsp  &nbsp  &nbsp  &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp  &nbsp &nbsp </div>
										 <div class="col">
											<asp:TextBox id="txtSpallingArea" runat="server" CssClass="form-control"></asp:TextBox></div>
                                     <div class="col"></div>
										 <div class="col"></div>
										 <div class="col"></div>
									</div>
								</div>
							
						
								<div class="table">
									<div class="row">
										 <div class="col"><b>Side Wall</b></div>
										
                                        
									</div>
									<br><div class="row">
										 <div class="col">Maximum Erosion of Bricks &nbsp  &nbsp   </div>
										 <div class="col">
											<asp:TextBox id="txtMaxErosion" runat="server" CssClass="form-control"></asp:TextBox></div>
										 <div class="col">MM</div>
										 <div class="col">Location &nbsp  &nbsp&nbsp  &nbsp &nbsp  &nbsp&nbsp  &nbsp&nbsp </div>
										<div class="col"  colspan="2">
											<asp:TextBox id="txtErosionLoc" runat="server" CssClass="form-control"></asp:TextBox></div>
								
                                        </div>
									<br><div class="row">
										 <div class="col">Maximum Penetration of metal</div>
										 <div class="col">
											<asp:TextBox id="txtMaxPenitration" runat="server" CssClass="form-control"></asp:TextBox></div>
										 <div class="col">MM</div>
										 <div class="col">Location  &nbsp  &nbsp&nbsp  &nbsp &nbsp  &nbsp&nbsp  &nbsp&nbsp</div>
										<div class="col" colspan="2">
											<asp:TextBox id="txtPenitrationLoc" runat="server" CssClass="form-control"></asp:TextBox></div>
									</div>
									<br><div class="row">
										 <div class="col">Condition of safety lining&nbsp  &nbsp&nbsp  &nbsp &nbsp  &nbsp  </div>
										<div class="col" colspan="2">
											<asp:TextBox id="txtLiningCondition" runat="server" CssClass="form-control"></asp:TextBox></div>
                                         <div class="col"></div>
                                         
                                         
										<div class="col" colspan="2">Area in Sq.Inches</div>
										 <div class="col">
											<asp:TextBox id="txtAreaCon" runat="server" CssClass="form-control"></asp:TextBox></div>
                                        
										 
									
									</div>
								</div>
					
				</asp:Panel>
				<div class="table">
					<div class="row">
						 <div class="col">Remarks &nbsp  &nbsp&nbsp  &nbsp &nbsp  &nbsp &nbsp  &nbsp&nbsp  &nbsp &nbsp  &nbsp &nbsp  &nbsp&nbsp  &nbsp &nbsp  &nbsp</div>
						 <div class="col">
							<asp:TextBox id="txtRemarks" runat="server" CssClass="form-control"></asp:TextBox></div>
                         <div class="col"></div>
										 <div class="col"></div>
										 <div class="col"></div>
					</div>
				</div>
				<div class="table">
					<div class="row">
						<div class="col" align="center">
							<asp:Button id="btnRemarks" runat="server"   Font-Size="20px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark"  Text="Save"></asp:Button></div>
					</div>
				</div>
				<asp:DataGrid id="DataGrid2" CssClass="table"  runat="server" >
                    <%--BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4"--%>
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
                   
            </div>
			</asp:panel></form>
                    </div>
            <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;position:relative;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
             
              
	</body>
</html>
