<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ChalanAndGatePassIssue.aspx.vb" Inherits="WebApplication2.ChalanAndGatePassIssue" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

    <title></title>
    <head runat="server">
		<title>Chalan and Gate Pass</title>
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
       	<asp:Panel id="Panel1" runat="server">
                <div class="row">
            <div class="table">
                  <div class="col" align="middle" colSpan="3">
                      <h1 class="heading">
            <asp:Label ID="Heading" runat="server"  Font-Bold="True"   Font-Size="X-Large" Text="CHALAN AND GATE PASS ISSUE" align="center"></asp:Label>
              </h1>
                        </div>
                <br />
					<div class="row">
						<div class="col">
							<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></div>
					</div>
					<div class="row">
                        <div class="col">
                        <asp:Label id="lbldesdate" runat="server" Text="Despatch Date"></asp:Label></div>
						
                       <div class="col">
                           <asp:TextBox id="txtdesdate" runat="server" CssClass="form-control" AutoPostBack="True" ></asp:TextBox>
							
                       </div>
                        <div class="col"></div>
                        <div class="col"></div>
                        <div class="col"></div>
                        <div class="col"></div>

                        </div>
                </br>
                <div class="row">
                        <div class ="col">
                         <asp:Label id="lblmemo" runat="server" Text="Advice Memo No"></asp:Label></div>
						
                       <div class="col">
                           <asp:dropdownlist id="ddlmemo" runat="server" CssClass="form-control" MaxLength="6" AutoPostBack="true"></asp:dropdownlist>
							
                </div>
                         <div class="col">
                        <asp:Label id="lblDCNo" runat="server" Text="Despatch Chalan No."></asp:Label></div>
						
                       <div class="col">
                           <asp:TextBox id="txtDCNo" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox>
							
                       </div>
                      <div class="col">
                        <asp:Label id="lblgp" runat="server" Text="Gate Pass No."></asp:Label></div>
						
                       <div class="col">
                           <asp:TextBox id="txtgp" runat="server" CssClass="form-control" AutoPostBack="True"  MaxLength="6"></asp:TextBox>
							
                       </div>
                       
					</div>
                <br />
                    <div class="row">

                        <div class="col-2">
                       
                        <asp:Label id="lblwhltyp" runat="server" Text="Wheel Type"></asp:Label></div>
						
                        <div class="col">
                             <asp:textbox ID="txtWhlTyp" runat="server" AutoPostBack="true" CssClass="form-control ll" enabled="false">
                   
                 </asp:textbox>   </div> 

                      <div class="col">
                        <asp:Label id="lbldraw" runat="server" Text="Drawing No."></asp:Label></div>
						
                       <div class="col">
                          <asp:Textbox ID="txtdraw" runat="server" AutoPostBack="true" CssClass="form-control ll" enabled="false">
                 </asp:Textbox>
                       </div>
                      
                     <div class="col">
                        <asp:Label id="lblspec" runat="server" Text="Specification No."></asp:Label></div>
						
                       <div class="col">
                          <asp:Textbox ID="txtSpec" runat="server" AutoPostBack="true" CssClass="form-control ll" enabled="false">
                 </asp:Textbox>
                       </div>
                      
              
                </div>
                <br />
                <div class="row">
                           <div class ="col">
                         <asp:Label id="lblwta" runat="server" Text="WTA No"></asp:Label></div>
						
                       <div class="col">
                           <asp:textbox id="txtwta" runat="server" CssClass="form-control" AutoPostBack="True"  MaxLength="6" enabled="false">
                               
                           </asp:textbox>
							
                </div>
                           <div class ="col">
                         <asp:Label id="lblwtadate" runat="server" Text="WTA Date/Railway Letter Issue Date"></asp:Label></div>
						
                       <div class="col">
                           <asp:Textbox id="txtWtaDate" runat="server" CssClass="form-control" AutoPostBack="True"  MaxLength="6" enabled="false"></asp:Textbox>
							
                </div>
                     <div class ="col">
                         <asp:Label id="Label1" runat="server" Text="Railway Letter"></asp:Label></div>
						
                       <div class="col">
                           <asp:TextBox id="txtRailLetter" runat="server" CssClass="form-control" AutoPostBack="True" enabled="false" MaxLength="6"></asp:TextBox>
							
                </div>
                     </div>
                <br />
                <div class="row">
                     <div class ="col">
                         <asp:Label id="lbllorry" runat="server" Text="Lorry No"></asp:Label></div>
						
                       <div class="col">
                           <asp:TextBox id="txtlorry" runat="server" CssClass="form-control" AutoPostBack="True" enabled="false" MaxLength="6"></asp:TextBox>
							
                </div>
                    <div class ="col">
                         <asp:Label id="lbldriverName" runat="server" Text="Driver Name"></asp:Label></div>
						
                       <div class="col">
                           <asp:TextBox id="txtDriverName" runat="server" CssClass="form-control" AutoPostBack="True" enabled="false" MaxLength="6"></asp:TextBox>
							
                </div>
                    <div class ="col">
                         <asp:Label id="lbldriver" runat="server" Text="Driver ID"></asp:Label></div>
						
                       <div class="col">
                           <asp:TextBox id="txtdriverID" runat="server" CssClass="form-control" AutoPostBack="True" enabled="false" MaxLength="6"></asp:TextBox>
							
                </div>
                    </div>
                <br />
         <div class="row">
             
              <div class="col">
                        <asp:Label id="lblrep" runat="server" Text="Representative Name"></asp:Label></div>
						
                       <div class="col">
                           <asp:TextBox id="txtrepname" runat="server" CssClass="form-control" AutoPostBack="True" enabled="false" MaxLength="6"></asp:TextBox>
							
                       </div> <div class="col">
                        <asp:Label id="lblrepc" runat="server" Text="Representative Contact No."></asp:Label></div>
						
                       <div class="col">
                           <asp:TextBox id="txtrepc" runat="server" CssClass="form-control" AutoPostBack="True" enabled="false" MaxLength="10"></asp:TextBox>
							
                       </div>
             <div class="col">
                        <asp:Label id="lblcon" runat="server" Text="Contractor Name"></asp:Label></div>
						
                       <div class="col">
                           <asp:TextBox id="txtcon" runat="server" CssClass="form-control" AutoPostBack="True" enabled="false" MaxLength="6"></asp:TextBox>
							
                       </div>

            
         </div>
            
                <br />
                <div class="row">
                       <div class="col">
                        <asp:Label id="lblLR" runat="server" Text="LR/CN Number"></asp:Label></div>
						
                       <div class="col">
                           <asp:TextBox id="txtLR" runat="server" CssClass="form-control" AutoPostBack="True" enabled="false" MaxLength="6"></asp:TextBox>
							
                       </div>
                   <div class="col">
                        <asp:Label id="lblRRdate" runat="server" Text="LR/CN Date"></asp:Label></div>
						
                       <div class="col">
                           <asp:TextBox id="txtRRdate" runat="server" CssClass="form-control" AutoPostBack="True" enabled="false" MaxLength="6"></asp:TextBox>
							</div>
                        <div class="col">
                        <asp:Label id="lblRR" runat="server" Text="Road Permit No"></asp:Label></div>
						
                       <div class="col">
                           <asp:TextBox id="txtroad" runat="server" CssClass="form-control" AutoPostBack="True" enabled="false" MaxLength="6"></asp:TextBox>
							
                       </div>
                       </div>
                   
         
                       
                <br />
                <div class="row">
                      <div class="col-2">
                        <asp:Label id="lblquan" runat="server" Text="Total Quantity"></asp:Label></div>
						
                       <div class="col-2">
                           <asp:TextBox id="txtquan" runat="server" CssClass="form-control" AutoPostBack="True" enabled="false" MaxLength="6"></asp:TextBox>
							
                       </div>
                      
                      
                      <div class="col-2">
                        <asp:Label id="lblConsignee" runat="server" Text="Consignee Name"></asp:Label></div>
						
                        <div class="col">
                             <asp:textbox ID="txtConsig" runat="server" AutoPostBack="true" CssClass="form-control ll" enabled="false" Width="278px">
                    
                 </asp:textbox>   </div> 
                    <div class="col"></div>
                       <div class="col"></div>
                      

                     
                </div>
               
    
                <br />
       </asp:Panel>
  <asp:Panel ID="panel3" runat="server">
                  <asp:DataGrid ID="grid1" runat="server" align="center" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" autogeneratecolumns="false" CssClass="table">
            <AlternatingItemStyle BackColor="White"></AlternatingItemStyle>
							
          
                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                <ItemStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" Mode="NumericPages" />
                <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                   <Columns>
								<asp:BoundColumn DataField="DespatchDate" HeaderText="Despatch Date"></asp:BoundColumn>
							<asp:BoundColumn DataField="Memo_No" HeaderText="Memo No"></asp:BoundColumn>
								<asp:BoundColumn DataField="DCNo" HeaderText="DCNo"></asp:BoundColumn>
                             <asp:BoundColumn DataField="Quantity" HeaderText="Quantity"></asp:BoundColumn>
						<asp:BoundColumn DataField="GatePass" HeaderText="Gate Pass"></asp:BoundColumn>
							
                      
							</Columns>
            </asp:DataGrid>
        </asp:Panel>
           	
        <div class="table">
					<div class="row">
					<div class="col" align="middle"  colSpan="3"> <asp:button id="btngenDC" runat="server"  BorderStyle="Solid" Font-Bold="True" Font-Size="20px" CssClass="btn btn-dark" Text="Generate New Chalan and GatePass No"></asp:button>
					</div>
				</div>
            <br />
					<div class="row">
					<div class="col" align="middle"  colSpan="3">
            <asp:button id="btnUpdate" runat="server"  BorderStyle="Solid" Font-Bold="True" Font-Size="20px" CssClass="btn btn-dark" Text="Update Memo"></asp:button>
				</div>
    </form>
                        <br />
         </div>
        <div class="card-footer" style="text-align:right;background-color:#cccccc;bottom:0;width:100%;vertical-align:middle;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>

</body>
</html>
