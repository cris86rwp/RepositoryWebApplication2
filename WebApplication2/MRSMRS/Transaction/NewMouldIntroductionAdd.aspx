<%@ Page Language="vb" AutoEventWireup="false" Codebehind="NewMouldIntroductionAdd.aspx.vb" Inherits="WebApplication2.NewMouldIntroductionAdd" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>NewMouldIntroductionAdd</title>
		    <LINK id="mss" href="/wap.css" rel="stylesheet"/>
		<META content="Microsoft Visual Studio.NET 7.0" name="GENERATOR"/>
		<META content="Visual Basic 7.0" name="CODE_LANGUAGE"/>
		<META content="JavaScript" name="vs_defaultClientScript"/>
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
        
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css"/>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js" type="text/javascript"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js" type="text/javascript"></script>
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
 
     <style type="text/css">
         .ui-datepicker {
    background: #333;
    border: 1px solid #555;
    color: #EEE;
    
}
         </style>
        </head>
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
          <i class="fab glyphicon glyphicon-home " style="font-size:30px;"></i>
        </a></li>

       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href=../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out" style="font-size:30px;"></i>
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
		<form id="Form1" method="post" runat="server">
             <div class="table">
			<asp:panel id="Panel1"  runat="server">
                
        <div class="container">
					<div class="row">
						<div class="col" style="HEIGHT: 5px" colSpan="6"><FONT size="5">New&nbsp;Mould Introduction-- Add
								<asp:label id="lblOperator" runat="server" Visible="False"></asp:label></FONT><hr class="prettyline" /></div>
					</div><br /><br /><br />
					<div class="row">
						<div class="col">Message</div>
						<div class="col" colSpan="4">
							<asp:label id="lblMessage" runat="server" Width="265px" ForeColor="Red"></asp:label>&nbsp;</div>
					</div>
					<div class="row">
						<div class="col">Date</div>
						
						<div class="col">
							<asp:textbox id="txtDate" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox></div>
						<div class="col" >Shift</div>
						<div class="col">
							<asp:radiobuttonlist id="rblShift" runat="server" CssClass="rbl" RepeatLayout="Flow" RepeatDirection="Horizontal">
								<asp:ListItem Value="A" Selected="True">A</asp:ListItem>
								<asp:ListItem Value="B">B</asp:ListItem>
								<asp:ListItem Value="C">C</asp:ListItem>
							</asp:radiobuttonlist></div>
					
						<div class="col" >Cope/DragNo</div>
						
						<div class="col">
							<asp:textbox id="txtCope_drag_number" runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="5"></asp:textbox></div>
						</div>
					<div class="row">
                        <div class="col" >Type</div>
						<div class="col">
							<asp:radiobuttonlist id="rblType" runat="server" CssClass="rbl" AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal">
								<asp:ListItem Value="C" Selected="True">Cope</asp:ListItem>
								<asp:ListItem Value="D">Drag</asp:ListItem>
							</asp:radiobuttonlist></div>
					</div>
					<br />
							<asp:panel id="pnlIng" runat="server" >
									<div class="row">
										<div class="col">EngNo</div>
										<div class="col">
											<asp:textbox id="txtEngraved_number" runat="server" CssClass="form-control"></asp:textbox></div>
										<div class="col">IngSupplier</div>
										<div class="col">
											<asp:radiobuttonlist id="rblSupplier" runat="server" CssClass="rbl" RepeatLayout="Flow" RepeatDirection="Horizontal">
												<asp:ListItem Value="ZIRCAR">ZIRCAR</asp:ListItem>
												<asp:ListItem Value="VESUVIUS">VESUVIUS</asp:ListItem>
											</asp:radiobuttonlist></div>
									
										<div class="col">IngType</div>
										<div class="col" colSpan="3">
											<asp:radiobuttonlist id="rblPresentIng" runat="server" CssClass="rbl" RepeatLayout="Flow" RepeatDirection="Horizontal">
												<asp:ListItem Value="B21">B21</asp:ListItem>
												<asp:ListItem Value="B2">B2</asp:ListItem>
												<asp:ListItem Value="B3">B3</asp:ListItem>
												<asp:ListItem Value="B4">B4</asp:ListItem>
												<asp:ListItem Value="D14">D14</asp:ListItem>
												<asp:ListItem Value="D17">D17</asp:ListItem>
												<asp:ListItem Value="D19">D19</asp:ListItem>
												<asp:ListItem Value="D21">D21</asp:ListItem>
											</asp:radiobuttonlist></div>
									</div>
								
							</asp:panel>
					<div class="row">
						<div class="col">ProductID</div>
						<div class="col">
							<asp:dropdownlist id="ddlProductCode" runat="server" AutoPostBack="True" CssClass="form-control ll"></asp:dropdownlist></div>
						<div class="col" >WAPDrawingNo</div>
						<div class="col">
							<asp:label id="lblDrawing_number" runat="server" ForeColor="Red"></asp:label></div>
				
						<div class="col">Supplier</div>
						<div class="col" colSpan="4">
							<asp:dropdownlist id="ddlSupplier" runat="server" CssClass="form-control ll"></asp:dropdownlist></div>
					</div><br />
					<div class="row">
						<div class="col">BlankNumber</div>
						<div class="col">
							<asp:textbox id="txtBlank_number" runat="server" CssClass="form-control"></asp:textbox></div>
						<div class="col" style="WIDTH: 76px">MouldStatus</div>
						
						<div class="col">
							<asp:dropdownlist id="cboMouldStatus" runat="server" CssClass="form-control ll">
								<asp:ListItem Value="H">H-Custody</asp:ListItem>
								<asp:ListItem Value="P" Selected="True">P-Sent to MR</asp:ListItem>
								<asp:ListItem Value="A">A-Assembled</asp:ListItem>
								<asp:ListItem Value="M">M-Machined</asp:ListItem>
								<asp:ListItem Value="R">R-Recvd From MR</asp:ListItem>
								<asp:ListItem Value="I">I-Ingate Press</asp:ListItem>
								<asp:ListItem Value="O">O-Others</asp:ListItem>
								<asp:ListItem Value="  "></asp:ListItem>
							</asp:dropdownlist></div>
					
						<div class="col">InitialHeight</div>
						<div class="col">
							<asp:textbox id="txtIntial_height" runat="server" CssClass="form-control"></asp:textbox></div>
                        </div><br />
					<div class="row">
						<div class="col" style="WIDTH: 76px">StandardHeight</div>
						<div class="col">
							<asp:textbox id="txtStandard_height" runat="server" CssClass="form-control"></asp:textbox></div>
					
						<div class="col">Permiability</div>
						
						<div class="col">
							<asp:textbox id="txtPermiability" runat="server" CssClass="form-control"></asp:textbox></div>
						<div class="col" style="WIDTH: 76px">AshContent</div>
						
						<div class="col">
							<asp:textbox id="txtAsh_content" runat="server" CssClass="form-control"></asp:textbox></div>
					</div><br />
					<div class="row">
						<div class="col">PONumber</div>
						<div class="col">
							<asp:textbox id="txtPONumber" runat="server" CssClass="form-control" AutoPostBack="True"></asp:textbox></div>
						<div class="col" style="WIDTH: 76px">MouldSize</div>
						<div class="col">
							<asp:radiobuttonlist id="rblMouldSize" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="rbl">
								<asp:ListItem Value="52.5">52.5</asp:ListItem>
								<asp:ListItem Value="48.5" Selected="True">48.5</asp:ListItem>
								<asp:ListItem Value="43.5">43.5</asp:ListItem>
							</asp:radiobuttonlist></div>
					
						<div class="col">RealesedDate</div>
						
						<div class="col">
							<asp:textbox id="txtRelease_date" runat="server" CssClass="form-control"></asp:textbox></div>
						</div><br />
					<div class="row">
                        <div class="col" >Remarks</div>
						<div class="col">
							<asp:textbox id="txtRemarks" runat="server" CssClass="form-control"></asp:textbox></div>
					</div>
					<div class="row">
						<div class="col" vAlign="top" align="center" colSpan="6">
                             <asp:button id="btnSave" runat="server" Text="Save"  Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" ></asp:button>&nbsp;
			
							<asp:RadioButtonList id="rblPL" runat="server" CssClass="table" RepeatLayout="Flow" RepeatDirection="Horizontal">
								<asp:ListItem Value="76971510" Selected="True">76971510</asp:ListItem>
								<asp:ListItem Value="81980802">81980802</asp:ListItem>
								<asp:ListItem Value="81980851">81980851</asp:ListItem>
							</asp:RadioButtonList>
				</div>
					</div>
            </div>
				<asp:DataGrid id="DataGrid1" runat="server" CellPadding="4" CssClass="table-responsive" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
			</asp:panel> </div></div></form></div><br /><br /><br />
        <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;position:fixed;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
