<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WheelDespatchDetails.aspx.vb" Inherits="WebApplication2.WheelDespatchDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<html xmlns="http://www.w3.org/1999/xhtml">

    <title></title>
    <head runat="server">
		<title>WHEEL DESPATCH DETAILS</title>
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
        <script type="text/javas cript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.9/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/responsive/1.0.7/js/dataTables.responsive.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.9/js/dataTables.bootstrap.min.js"></script>
            <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
        <script type="text/javascript" src= "https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js">  </script>
<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
<script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
<script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
<script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>

	</HEAD>
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
             <h1 style="color:white; font-size:30px; margin-left:325px; margin-top:5px">Rail Wheel Plant, Bela</h1> 
       
         </li>
          </ul>
    <ul class="navbar-nav ml-auto  navbar-right">
        <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home "></i>
        </a></li>

       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out"></i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
          <%--<img src="../../../CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="50" style="border-width: 34px; background-position: 5px 5px; width:50px;margin-top:3px;border-color:white; border-width:50px"/>
        --%><img src="../../NewFolder1/CRIS-Recruitment.jpg" height="45" style="border-radius:43%"/>
       </a>
      </li>
     </ul>
      
  </div>
</nav>

     <div class="container">
            

    <form id="form1" runat="server">
        <div>
            	<asp:Panel id="Panel2" runat="server">
                     <div class="row">
            <div class="table">
                  <div class="col" align="middle" colSpan="3">
                      <h1 class="heading">
            <asp:Label ID="Heading" runat="server"  Font-Bold="True"   Font-Size="X-Large" Text="WHEEL DESPATCH DETAILS" align="center"></asp:Label>
              </h1>
                        </div>
                <br />
					<div class="row">
						<div class="col">
							<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                            <asp:Label id="lblsave" runat="server" ForeColor="Red"></asp:Label>
						</div>
					</div>
                <div class="row">
                 
						<div class="col"><asp:Label id="lblcountmsg" runat="server" ForeColor="Blue"></asp:Label>
							<asp:Label id="lblCount" runat="server" ForeColor="Blue"></asp:Label></div>
					</div>

                <div class="row">
                       <div class="col">
                        <asp:Label id="lbldate" runat="server" Text="Date"></asp:Label></div>
						
                       <div class="col">
                           <asp:TextBox id="txtdate" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox>
							
                       </div>
                     <div class="col">

                        <asp:Label id="lblmemo" runat="server" Text="Advice Memo No."></asp:Label></div>
						
                       <div class="col">
                           <asp:DropDownList id="ddlmemo" runat="server" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>
							
                       </div>
                      <div class="col">
                        <asp:Label id="lblDCNo" runat="server" Text="Despatch Chalan No."></asp:Label></div>
						
                       <div class="col">
                           <asp:TextBox id="txtDC" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox>
							
                       </div>
                   
                    
                    
                </div> <br />
                <div class="row">
              
                    
                     <div class="col">
                        <asp:Label id="lblheat" runat="server" Text="Heat No"></asp:Label></div>
						
                       <div class="col">
                           <asp:TextBox id="txtheat" runat="server" CssClass="form-control" AutoPostBack="True"  MaxLength="6"></asp:TextBox>
							
                       </div>
            
                    <div class="col">
                        <asp:Label id="lblwheel" runat="server" Text="Wheel No"></asp:Label></div>
						
                       <div class="col">
                           <asp:TextBox id="txtwheel" runat="server" CssClass="form-control" AutoPostBack="True"  MaxLength="6"></asp:TextBox>
							
                       </div>
                    <div class="col">
                        <asp:Label id="lblBHN" runat="server" Text="BHN"></asp:Label></div>
						
                       <div class="col">
                           <asp:TextBox id="txtbhn" runat="server" CssClass="form-control" AutoPostBack="True"  MaxLength="6"></asp:TextBox>
							
                       </div>

                    </div>
                <br />
                    <div class ="row">
                    
                
                     <div class="col">
                        <asp:Label id="lbltread" runat="server" Text="Tread Dia"></asp:Label></div>
						
                       <div class="col">
                           <asp:TextBox id="txttread" runat="server" CssClass="form-control" AutoPostBack="True"  MaxLength="6"></asp:TextBox>
							
                       </div> <div class="col">
                        <asp:Label id="lblbore" runat="server" Text="Bore Dia"></asp:Label></div>
						
                       <div class="col">
                           <asp:TextBox id="txtbore" runat="server" CssClass="form-control" AutoPostBack="True"  MaxLength="6"></asp:TextBox>
							
                       </div>
                        <div class="col">
                        <asp:Label id="lblplate" runat="server" Text="Plate Thickness"></asp:Label></div>
						
                       <div class="col">
                           <asp:TextBox id="txtplate" runat="server" CssClass="form-control" AutoPostBack="True"  MaxLength="6"></asp:TextBox>
							
                       </div> 
                </div>
                <br />
                    <div class ="row">
                     

                       
                
                    <div class="col">
                         <asp:Label id="lblstat" runat="server" Text="Status"></asp:Label></div>
						
                       <div class="col">
                            <asp:DropDownList ID="ddlstat" runat="server" AutoPostBack="true" CssClass="form-control ll">
                    <asp:ListItem Value="Pass">Pass</asp:ListItem>
                     <asp:ListItem Value="Reject">Reject</asp:ListItem>
                 </asp:DropDownList>
                    </div>
                        <div class="col">
                        <asp:Label id="Label1" runat="server" Text="Heat Chemistry Status"></asp:Label></div>
						
                        <div class="col">
                        <asp:Label id="lblheatchem" runat="server"></asp:Label></div>
                         <div class="col">
						 <asp:Label id="Label3" runat="server" Text="Heat Treatment Status"></asp:Label></div>
						
                        <div class="col">
                        <asp:Label id="lblheattreat" runat="server"></asp:Label></div>
						
                </div>
                <br />
                    <div class ="row">
                        <div class="col">
                        <asp:Label id="lbltime" runat="server" Text="Lorry Receipt Time"></asp:Label></div>
						
                       <div class="col">
                           <asp:TextBox id="txttime" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox>
							
                       </div>
                           
                       
                        <div class="col"></div>
                        <div class="col"></div>
                        
                        <div class="col"></div>
                        <div class="col"></div>
                        </div>
                <br />
                <br />
                	<div class="table">
					<div class="row">
					<div class="col" align="middle"  colSpan="3"><asp:button id="btnSave" runat="server"  BorderStyle="Solid" Font-Bold="True" Font-Size="20px" CssClass="btn btn-dark" Text="Save"></asp:button>
                       </div>
				</div>
				</div>
            </div>
                     <asp:DataGrid id="DataGrid1" runat="server"   BackColor="White"  CssClass="table" AutoGenerateColumns="false">
						<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
						<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
						<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
						<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
						<Columns>
							<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
                            <asp:BoundColumn DataField="Heatnumber" HeaderText="Heat No"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Wheelnumber" HeaderText="Wheel No"></asp:BoundColumn>
                            <asp:BoundColumn DataField="threaddia" HeaderText="Tread Dia"></asp:BoundColumn>
                            <asp:BoundColumn DataField="boredia" HeaderText="Bore Dia"></asp:BoundColumn>
                            <asp:BoundColumn DataField="platethickness" HeaderText="Plate Thickness"></asp:BoundColumn>
                             <asp:BoundColumn DataField="wheelStatus" HeaderText="Status"></asp:BoundColumn>
                          <asp:BoundColumn DataField="BHN" HeaderText="BHN"></asp:BoundColumn>
                            <asp:BoundColumn DataField="FinalStatus" HeaderText="Magna Status"></asp:BoundColumn>
                            <asp:BoundColumn DataField="UTStatus" HeaderText="UT Status"></asp:BoundColumn>
                           
                          
						</Columns>
						<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
					</asp:DataGrid>
           </div></div>    
</asp:Panel>
        </div>
    </form>
         </div>
</body>
</html>
